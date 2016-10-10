using MyHeroKill.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHeroKill.Managers
{
    public class HandCardManager
    {
        /// <summary>
        /// 收到外部消息，比如被杀，被釜底抽薪
        /// </summary>
        /// <param name="fromUserIndex"></param>
        /// <param name="cardsFrom"></param>
        /// <param name="needToHandOut">需要出的牌的种类</param>
        public void Receiver(int fromUserIndex, Model.CardModel cardModel)
        {
            //让用户出牌
            switch (cardModel.NeedHandoutGloabalType)
            {
                case MyHeroKill.Model.Enums.ECardGloabalType.Sha:
                    break;
                case MyHeroKill.Model.Enums.ECardGloabalType.Shan:
                    {
                        DoHandOutShan(fromUserIndex, cardModel.CardsFrom);
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

        private void DoHandOutShan(int fromUserIndex, List<Card> list)
        {
            throw new NotImplementedException();
        }

    }
}
