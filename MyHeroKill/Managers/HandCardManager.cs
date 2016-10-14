using MyHeroKill.Model;
using MyHeroKill.Service;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHeroKill.Managers
{
    public class HandCardManager
    {

        //是否是主动出牌
        public bool IsAttack = true;


        //当前用户在所有角色中的位置
        public int CurrentIndex = 0;

        /// <summary>
        /// 当前的HostManager
        /// </summary>
        public HostManager CurrentHostManager = new HostManager();

        //当前的CardModel
        protected AttackCardModel _currentCardModel { get; set; }

        protected ArrayList _currentTargets = new ArrayList();
        /// <summary>
        /// 获取当前的角色
        /// </summary>
        public IRole CurrentRole { get; set; }
        #region 获取用户的相关信息
        /// <summary>
        /// 获取用户手牌
        /// </summary>
        /// <returns></returns>
        protected List<Card> GetUserCards()
        {
            var cardService = new CardService();
            //TEST
            List<Card> list = new List<Card>();
            list.Add(cardService.GetCard(6));
            list.Add(cardService.GetCard(7));
            list.Add(cardService.GetCard(9));
            return list;
        }

        /// <summary>
        /// 获取当前用户的位置
        /// </summary>
        /// <returns></returns>
        protected int GetCurrentUserIndex()
        {
            //TEST
            return 1;
        }

        #endregion

        /// <summary>
        /// 清空目标
        /// </summary>
        public void CleanTargets()
        {
            _currentTargets = new ArrayList();
        }

        /// <summary>
        /// 添加目标（取消）
        /// </summary>
        /// <param name="role"></param>
        /// <param name="maxTargetNum">最大的目标数</param>
        public void AddTarget(IRole role, int maxTargetNum = 1)
        {

            //加上攻击目标，如果目标已经选中则将其移除，不存在则添加

            var currentRole = (from IRole r in _currentTargets
                               where r.Name == role.Name
                               select r).FirstOrDefault();

            if (currentRole == null)
            {
                //不存在，则检查是否达到最大攻击目标数
                //如果达到最大攻击目标数，则不添加
                if (_currentTargets.Count >= maxTargetNum)
                {
                    //去掉最后一个
                    _currentTargets.RemoveAt(_currentTargets.Count - 1);
                    _currentTargets.Add(role);
                }
                else
                {
                    _currentTargets.Add(role);

                }
            }
            else
            {
                _currentTargets.Remove(currentRole);

            }

        }

        /// <summary>
        /// 获取当前选中的目标
        /// </summary>
        /// <returns></returns>
        public ArrayList GetTargets()
        {
            return this._currentTargets;
        }

        /// <summary>
        /// 目标中是否包含指定角色
        /// </summary>
        /// <param name="role"></param>
        /// <returns></returns>
        public bool ContainsRoleInTargets(IRole role)
        {
            var query = from IRole r in this._currentTargets
                        where r.Name == role.Name
                        select r;
            return query != null && query.Count() > 0;
        }

        /// <summary>
        /// 可以选择的目标数量
        /// </summary>
        /// <returns></returns>
        public int GetCanSelectedTargetCount()
        {
            //CASE 1：当前手牌只有一张，且是需要选中目标才能出牌
            //CASE 2: TODO:当前手牌有多张，将其当做一张来用
            var selectedCard = this.CurrentRole.CardsInHand.FirstOrDefault(p => p.IsSelected);
            if (this.CurrentRole.CardsInHand.Count(p => p.IsSelected) == 1 &&
                          this.IsNeedSelectTargets(selectedCard))
            {
                //武器中有狼牙棒，且只剩下最后一张杀，可以指定3个角色
                if (this.CurrentRole.AdditionalWeapons.Any(p => p.Name == "狼牙棒") &&
                            selectedCard.CardGloabalType == Enums.ECardGloabalType.Sha &&
                                this.CurrentRole.CardsInHand.Count == 1)
                {
                    return 3;
                }
                else if (selectedCard.CardGloabalType == Enums.ECardGloabalType.Jiedaosharen)
                {
                    //借刀杀人目标是2
                    return 2;
                }
                else
                {
                    return 1;
                }
            }
            else
            {
                return 0;
            }

        }

        /// <summary>
        /// 是否可以主动出牌且需要选定角色
        /// </summary>
        /// <param name="card"></param>
        /// <returns></returns>
        public bool IsNeedSelectTargets(Card card)
        {
            //【需要主动选取对象的牌】
            //[基本牌]
            //杀（血杀，暗杀）
            //[锦郎牌]
            //探囊取物、釜底抽薪、画地为牢、决斗、借刀杀人（隔岸观火、合纵连横、绝粮莫兴、舍我其谁、偷梁换柱）
            //【不能主动出牌】
            if (card != null && (card.CardGloabalType == Enums.ECardGloabalType.Sha || card.CardGloabalType == Enums.ECardGloabalType.Tanlangquwu
                || card.CardGloabalType == Enums.ECardGloabalType.Fudichouxin || card.CardGloabalType == Enums.ECardGloabalType.Huadiweilao
                || card.CardGloabalType == Enums.ECardGloabalType.Juedou || card.CardGloabalType == Enums.ECardGloabalType.Jiedaosharen)
                )
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 指定的牌是否可以主动出
        /// </summary>
        /// <param name="card"></param>
        /// <returns></returns>
        public bool CanActiveHandout(Card card)
        {
            //不能主动出的牌：闪，无懈可击
            if (card.CardGloabalType == Enums.ECardGloabalType.Shan || card.CardGloabalType == Enums.ECardGloabalType.Wuxiekeji)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        /// <summary>
        /// 获取当前可以出的牌，如果没有可以出的牌（或者选定的牌太多）则返回null
        /// </summary>
        /// <returns></returns>
        public Card GetHandoutCard()
        {
            if (this.CurrentRole.CardsInHand.Count(p => p.IsSelected) == 1)
            {
                var card = this.CurrentRole.CardsInHand.First(p => p.IsSelected);
                return card;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 获取出牌模型
        /// </summary>
        /// <returns></returns>
        public AttackCardModel GetCardModel()
        {
            return this._currentCardModel;
        }

        /// <summary>
        /// 更新模型
        /// </summary>
        /// <param name="cardModel"></param>
        public void SetCardModel(AttackCardModel cardModel)
        {
            this._currentCardModel = cardModel;
        }


        /// <summary>
        /// 获取指定牌需要出什么牌
        /// </summary>
        /// <param name="attackCardType"></param>
        /// <returns></returns>
        protected List<Enums.ECardGloabalType> GetNeedHandoutCardType(Enums.ECardGloabalType attackCardType)
        {
            List<Enums.ECardGloabalType> typeList = new List<Enums.ECardGloabalType>();
            //TODO:枚举的按位与和按位或
            switch (attackCardType)
            {
                case Enums.ECardGloabalType.Sha:
                    typeList.Add(Enums.ECardGloabalType.Shan);
                    break;
                case Enums.ECardGloabalType.Wanjianqifa:
                    typeList.Add(Enums.ECardGloabalType.Shan);
                    break;
                case Enums.ECardGloabalType.Fudichouxin:
                    typeList.Add(Enums.ECardGloabalType.Wuxiekeji);
                    break;
                case Enums.ECardGloabalType.Jiedaosharen:
                    typeList.Add(Enums.ECardGloabalType.Sha);
                    typeList.Add(Enums.ECardGloabalType.Wuxiekeji);
                    break;
                case Enums.ECardGloabalType.Juedou:
                    typeList.Add(Enums.ECardGloabalType.Sha);
                    typeList.Add(Enums.ECardGloabalType.Wuxiekeji);
                    break;
                case Enums.ECardGloabalType.Fenghuolangyan:
                    typeList.Add(Enums.ECardGloabalType.Sha);
                    typeList.Add(Enums.ECardGloabalType.Wuxiekeji);
                    break;
                case Enums.ECardGloabalType.Tanlangquwu:
                    typeList.Add(Enums.ECardGloabalType.Wuxiekeji);
                    break;
                default:
                    typeList.Add(Enums.ECardGloabalType.Any);
                    break;
            }
            return typeList;
        }

        /// <summary>
        /// 更新CardModel
        /// </summary>
        /// <param name="hostManager"></param>
        /// <returns></returns>
        public AttackCardModel SetCardModel()
        {
            if (this.GetTargets().Count > 0)
            {
                Model.AttackCardModel cardModel = new AttackCardModel();
                cardModel.FromCardGloabalType = this.CurrentRole.CardsInHand.First(p => p.IsSelected).CardGloabalType;
                cardModel.FromCards = this.CurrentRole.CardsInHand.Where(p => p.IsSelected).ToList();

                cardModel.CanNotDefenseSha = false;
                cardModel.NeedHandoutCards = new List<CardContainer>();

                var needCardTypes = this.GetNeedHandoutCardType(cardModel.FromCardGloabalType);
                foreach (var item in needCardTypes)
                {
                    var cardContainer = new CardContainer();
                    cardContainer.NeedHandoutCardColorAndSign = Enums.ECardColorAndSignType.Any;
                    //根据角色技能、装备决定伤害值
                    cardContainer.NeedHandoutCardCount = 1;
                    //根据真实牌类型来判断需要出什么牌
                    cardContainer.NeedHandoutGloabalTypes = item;
                    cardModel.NeedHandoutCards.Add(cardContainer);
                }
                this._currentCardModel = cardModel;
                return this._currentCardModel;
            }
            else
            {
                Console.WriteLine("没牌啊，出啥？");
                return null;
            }
        }

        public void HandoutCard(int attackerUserIndex, AttackCardModel attackCardModel, DefenseCardModel defenseCardModel)
        {
            foreach (var card in defenseCardModel.FromCards)
            {
                this.CurrentRole.CardsInHand.Remove(card);
            }
            this.CurrentHostManager.ReplyRequest(this.CurrentHostManager.GetRoleIndex(this.CurrentRole), attackerUserIndex, attackCardModel, defenseCardModel);
        }

        /// <summary>
        /// 主动出牌攻击
        /// </summary>
        public void AttackHandOut()
        {
            //根据角色的武器、技能来构造CardModel。如攻击强度、所需要出牌数
            this.SetCardModel();
            var cardModel = this.GetCardModel();
            if (cardModel.FromCardGloabalType == Enums.ECardGloabalType.Sha)
            {
                this.CurrentRole.BaseWeapons.ForEach(p =>
                {
                    p.OnBeforeSha(this);
                });
                this.CurrentRole.AdditionalWeapons.ForEach(p =>
                {
                    p.OnBeforeSha(this);
                });
                this.CurrentRole.BaseSkills.ForEach(p =>
                {
                    p.OnBeforeSha(this);
                });
                this.CurrentRole.AdditionalSkills.ForEach(p =>
                {
                    p.OnBeforeSha(this);
                });
            }

            var t = this.GetTargets().ToArray().Select(p => this.CurrentHostManager.GetRoleIndex((IRole)p));
            CurrentHostManager.SendRequest(this.GetCurrentUserIndex(), t.ToArray(), cardModel);
        }

        /// <summary>
        /// 攻击对方之后，对方出的牌
        /// </summary>
        /// <param name="fromUserIndex"></param>
        /// <param name="attackCardModel"></param>
        /// <param name="defenseCardModel"></param>
        public void AttackHandoutReply(int fromUserIndex, AttackCardModel attackCardModel, DefenseCardModel defenseCardModel)
        {

        }


        /// <summary>
        /// 被动出牌。收到外部消息，比如被杀，被釜底抽薪
        /// </summary>
        /// <param name="attackerUserIndex"></param>
        /// <param name="cardsFrom"></param>
        /// <param name="needToHandOut">需要出的牌的种类</param>
        public void DefencerHandOut(int attackerUserIndex, Model.AttackCardModel cardModel)
        {
            if (cardModel != null)
            {
                foreach (var needCard in cardModel.NeedHandoutCards)
                {
                    //程序判断当前用户是否可以抵御（有对应的牌），如果没有则直接返回结果
                    //如果既有杀，又有决斗，先响应无懈可击再响应杀，但是如果出了决斗就不能再出杀


                    //判断是否有抵御的牌
                    //1. 检查是否有对应的手牌；
                    //2. 检查是否有技能可以提供并满足技能要求
                    if (this.CurrentRole.CardsInHand.Any(p => p.CardGloabalType == needCard.NeedHandoutGloabalTypes))
                    {
                        //有可以出的手牌，弹出第一张可以出的牌
                        //如果是AI，则直接出牌,TODO:机器人不出无邪；
                        //如果是人类，等待选择牌
                        if (this.CurrentRole.RoleStatus == Enums.ERoleStatus.AI)
                        {
                            //AI先出无懈可击
                            var cards = this.CurrentRole.CardsInHand.Where(p => p.CardGloabalType == needCard.NeedHandoutGloabalTypes).ToList();
                            if (cards.Count > 0)
                            {
                                DefenseCardModel dModel = new DefenseCardModel();
                                dModel.FromCards = new List<Card>();
                                //出掉手中最多的需要的牌
                                for (int i = 0; i < Math.Min(needCard.NeedHandoutCardCount, cards.Count); i++)
                                {
                                    dModel.FromCards.Add(cards[i]);
                                }
                                dModel.IsHandoutOver = true;
                                this.HandoutCard(attackerUserIndex, cardModel, dModel);
                                break;
                            }
                            else
                            {
                                continue;
                            }
                        }
                        else
                        {
                            //是人的话等待人出牌
                        }

                    }
                    else
                    {
                        //没有手牌可出，判断是否有技能或者装备可以提供
                    }

                }
            }
            else
            {
                Console.WriteLine("异常：没牌让我出啥");
            }
        }

        private void DoHandOutShan(int fromUserIndex, AttackCardModel cardModel)
        {
            // 检查是否有闪
            var cards = this.GetUserCards();
            //TODO:检查是否有可以当闪用或者免疫杀的装备
            var firstCard = cards.FirstOrDefault(p => p.IsShan);
            if (firstCard != null)
            {
                //有闪,
                //弹出这张闪，等待用户选择是否需要出

            }
            else
            {
                //没闪
                //掉血，检查是否出发掉血相关的技能

            }

        }

    }
}
