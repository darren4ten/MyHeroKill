using MyHeroKill.Model;
using MyHeroKill.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHeroKill.Managers
{
    public class HandCardManager
    {
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
