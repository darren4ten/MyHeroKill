﻿using MyHeroKill.Model;
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

        //当前的CardModel
        protected CardModel _currentCardModel { get; set; }

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
        public CardModel GetCardModel()
        {
            return this._currentCardModel;
        }

        /// <summary>
        /// 更新模型
        /// </summary>
        /// <param name="cardModel"></param>
        public void SetCardModel(CardModel cardModel)
        {
            this._currentCardModel = cardModel;
        }


        /// <summary>
        /// 获取指定牌需要出什么牌
        /// </summary>
        /// <param name="attackCardType"></param>
        /// <returns></returns>
        protected Enums.ECardGloabalType GetNeedHandoutCardType(Enums.ECardGloabalType attackCardType)
        {
            //TODO:枚举的按位与和按位或
            switch (attackCardType)
            {
                case Enums.ECardGloabalType.Sha:
                    return Enums.ECardGloabalType.Shan;

                case Enums.ECardGloabalType.Wanjianqifa:
                    return Enums.ECardGloabalType.Shan;

                case Enums.ECardGloabalType.Fudichouxin:
                    return Enums.ECardGloabalType.Wuxiekeji;

                case Enums.ECardGloabalType.Jiedaosharen:
                    return Enums.ECardGloabalType.Sha | Enums.ECardGloabalType.Wuxiekeji;

                case Enums.ECardGloabalType.Juedou:
                    return Enums.ECardGloabalType.Sha | Enums.ECardGloabalType.Wuxiekeji;

                case Enums.ECardGloabalType.Fenghuolangyan:
                    return Enums.ECardGloabalType.Sha | Enums.ECardGloabalType.Wuxiekeji;

                case Enums.ECardGloabalType.Tanlangquwu:
                    return Enums.ECardGloabalType.Wuxiekeji;

                default:
                    return Enums.ECardGloabalType.Any;
            }
        }

        /// <summary>
        /// 更新CardModel
        /// </summary>
        /// <param name="hostManager"></param>
        /// <returns></returns>
        public CardModel SetCardModel(HostManager hostManager)
        {
            if (this.GetTargets().Count > 0)
            {
                Model.CardModel cardModel = new CardModel();
                cardModel.FromCardGloabalType = this.CurrentRole.CardsInHand.First(p => p.IsSelected).CardGloabalType;
                cardModel.FromCards = this.CurrentRole.CardsInHand.Where(p => p.IsSelected).ToList();

                cardModel.CanNotDefenseSha = false;
                cardModel.NeedHandoutCardColorAndSign = Enums.ECardColorAndSignType.Any;
                //根据角色技能、装备决定伤害值
                cardModel.NeedHandoutCardCount = 1;
                //根据真实牌类型来判断需要出什么牌
                cardModel.NeedHandoutGloabalType = this.GetNeedHandoutCardType(cardModel.FromCardGloabalType);

                var t = this.GetTargets().ToArray().Select(p => hostManager.GetRoleIndex((IRole)p));
                hostManager.SendRequest(this.GetCurrentUserIndex(), t.ToArray(), cardModel);
                return cardModel;
            }
            else
            {
                Console.WriteLine("没牌啊，出啥？");
                return null;
            }
        }

        public void AttackHandOut(HostManager hostManager)
        {
            //根据角色的武器、技能来构造CardModel。如攻击强度、所需要出牌数
            this.SetCardModel(hostManager);
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
        }

        /// <summary>
        /// 主动出牌
        /// </summary>
        /// <param name="targetUserIndexes">攻击目标</param>
        /// <param name="cards">所出的手牌</param>
        /// <param name="realCardType">要将手牌当做的牌</param>
        public void AttackHandOut(int[] targetUserIndexes, List<Card> cards, MyHeroKill.Model.Enums.ECardGloabalType realCardType)
        {
            var hostManager = new HostManager();
            //根据角色的武器、技能来构造CardModel。如攻击强度、所需要出牌数
            //TODO
            Model.CardModel cardModel = new CardModel();
            cardModel.FromCardGloabalType = realCardType;
            cardModel.FromCards = cards;
            cardModel.NeedHandoutCardColorAndSign = Enums.ECardColorAndSignType.Any;
            //根据角色技能、装备决定伤害值
            cardModel.NeedHandoutCardCount = 1;
            //根据真实牌类型来判断需要出什么牌
            cardModel.NeedHandoutGloabalType = Enums.ECardGloabalType.Shan;

            hostManager.SendRequest(this.GetCurrentUserIndex(), targetUserIndexes, cardModel);
        }

        /// <summary>
        /// 被动出牌。收到外部消息，比如被杀，被釜底抽薪
        /// </summary>
        /// <param name="fromUserIndex"></param>
        /// <param name="cardsFrom"></param>
        /// <param name="needToHandOut">需要出的牌的种类</param>
        public void DefenceHandOut(int fromUserIndex, Model.CardModel cardModel)
        {
            //让用户出牌
            switch (cardModel.NeedHandoutGloabalType)
            {
                case MyHeroKill.Model.Enums.ECardGloabalType.Sha:
                    break;
                case MyHeroKill.Model.Enums.ECardGloabalType.Shan:
                    {
                        DoHandOutShan(fromUserIndex, cardModel);
                    };
                    break;
                case MyHeroKill.Model.Enums.ECardGloabalType.Yao:
                    break;
                case MyHeroKill.Model.Enums.ECardGloabalType.Wanjianqifa:
                    break;
                case MyHeroKill.Model.Enums.ECardGloabalType.Xiuyangshengxi:
                    break;
                case MyHeroKill.Model.Enums.ECardGloabalType.Wugufengdeng:
                    break;
                case MyHeroKill.Model.Enums.ECardGloabalType.Huadiweilao:
                    break;
                case MyHeroKill.Model.Enums.ECardGloabalType.Shoupenglei:
                    break;
                case MyHeroKill.Model.Enums.ECardGloabalType.Fudichouxin:
                    break;
                case MyHeroKill.Model.Enums.ECardGloabalType.Jiedaosharen:
                    break;
                case MyHeroKill.Model.Enums.ECardGloabalType.Juedou:
                    break;
                case MyHeroKill.Model.Enums.ECardGloabalType.Fenghuolangyan:
                    break;
                case MyHeroKill.Model.Enums.ECardGloabalType.Wuxiekeji:
                    break;
                case MyHeroKill.Model.Enums.ECardGloabalType.Wuzhongshengyou:
                    break;
                case MyHeroKill.Model.Enums.ECardGloabalType.Tanlangquwu:
                    break;
                case MyHeroKill.Model.Enums.ECardGloabalType.Jingongma:
                    break;
                case MyHeroKill.Model.Enums.ECardGloabalType.Fangyuma:
                    break;
                case MyHeroKill.Model.Enums.ECardGloabalType.Yuruyi:
                    break;
                case MyHeroKill.Model.Enums.ECardGloabalType.Yuchangjian:
                    break;
                case MyHeroKill.Model.Enums.ECardGloabalType.Langyabang:
                    break;
                case MyHeroKill.Model.Enums.ECardGloabalType.Luyeqiang:
                    break;
                case MyHeroKill.Model.Enums.ECardGloabalType.Longlingdao:
                    break;
                case MyHeroKill.Model.Enums.ECardGloabalType.Bawanggong:
                    break;
                case MyHeroKill.Model.Enums.ECardGloabalType.Hufu:
                    break;
                case MyHeroKill.Model.Enums.ECardGloabalType.Bolangchui:
                    break;
                default:
                    break;
            }
        }


        private void DoHandOutShan(int fromUserIndex, CardModel cardModel)
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
