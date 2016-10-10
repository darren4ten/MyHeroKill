using MyHeroKill.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHeroKill.Managers
{
    /// <summary>
    /// 主控管理，发牌的中间人
    /// </summary>
    public class HostManager
    {
        /// <summary>
        /// 接受客户端（具体人物的出牌请求）
        /// </summary>
        /// <param name="fromUserIndex">从哪个位置出的牌，如5人场，则为0，1，2，3</param>
        /// <param name="targetUserIndexes">攻击目标的位置索引</param>
        /// <param name="globalType">所出牌的真实类型</param>
        /// <param name="cardsFrom">所出的真实手牌牌（如，两张牌当做杀来用）</param>
        public void SendRequest(int fromUserIndex, int[] targetUserIndexes, CardModel cardModel)
        {
            switch (cardModel.NeedHandoutGloabalType)
            {
                case Enums.ECardGloabalType.Sha:
                    {
                        DoSha(fromUserIndex, targetUserIndexes, cardModel);
                    };
                    break;
                case Enums.ECardGloabalType.Shan:
                    {
                        DoShan();
                    }
                    break;
                case Enums.ECardGloabalType.Yao:
                    {
                        DoYao();
                    }
                    break;
                case Enums.ECardGloabalType.Wanjianqifa:
                    {
                        DoWuxiekeji();
                    }
                    break;
                case Enums.ECardGloabalType.Xiuyangshengxi:
                    {
                        DoXiuyangshengxi();
                    }
                    break;
                case Enums.ECardGloabalType.Wugufengdeng:
                    {
                        DoWugufengdeng();
                    }
                    break;
                case Enums.ECardGloabalType.Huadiweilao:
                    {
                        DoHuadiweilao();
                    }
                    break;
                case Enums.ECardGloabalType.Shoupenglei:
                    {
                        DoShoupenglei();
                    }
                    break;
                case Enums.ECardGloabalType.Fudichouxin:
                    {
                        DoFudichouxin();
                    }
                    break;
                case Enums.ECardGloabalType.Jiedaosharen:
                    {
                        DoJiedaosharen();
                    }
                    break;
                case Enums.ECardGloabalType.Juedou:
                    {
                        DoJuedou();
                    }
                    break;
                case Enums.ECardGloabalType.Fenghuolangyan:
                    {
                        DoFenghuolangyan();
                    }
                    break;
                case Enums.ECardGloabalType.Wuxiekeji:
                    {
                        DoWuxiekeji();
                    }
                    break;
                case Enums.ECardGloabalType.Wuzhongshengyou:
                    {
                        DoWuzhongshengyou();
                    }
                    break;
                case Enums.ECardGloabalType.Tanlangquwu:
                    {
                        DoTanlangquwu();
                    }
                    break;
                case Enums.ECardGloabalType.Jingongma:
                    {
                        DoJingongma();
                    }
                    break;
                case Enums.ECardGloabalType.Fangyuma:
                    {
                        DoFangyuma();
                    }
                    break;
                case Enums.ECardGloabalType.Yuruyi:
                    {
                        DoYuruyi();
                    }
                    break;
                case Enums.ECardGloabalType.Yuchangjian:
                    {
                        DoYuchangjian();
                    }
                    break;
                case Enums.ECardGloabalType.Langyabang:
                    {
                        DoLangyabang();
                    }
                    break;
                case Enums.ECardGloabalType.Luyeqiang:
                    {
                        DoLuyeqiang();
                    }
                    break;
                case Enums.ECardGloabalType.Longlingdao:
                    {
                        DoLonglingdao();
                    }
                    break;
                case Enums.ECardGloabalType.Bawanggong:
                    {
                        DoBawanggong();
                    }
                    break;
                case Enums.ECardGloabalType.Hufu:
                    {
                        DoHufu();
                    }
                    break;
                case Enums.ECardGloabalType.Bolangchui:
                    {
                        DoBolangchui();
                    }
                    break;
                default: { ; }
                    break;
            }
        }



        private void DoYuchangjian()
        {
            throw new NotImplementedException();
        }

        private void DoBolangchui()
        {
            throw new NotImplementedException();
        }

        private void DoHufu()
        {
            throw new NotImplementedException();
        }

        private void DoBawanggong()
        {
            throw new NotImplementedException();
        }

        private void DoLonglingdao()
        {
            throw new NotImplementedException();
        }

        private void DoLuyeqiang()
        {
            throw new NotImplementedException();
        }

        private void DoLangyabang()
        {
            throw new NotImplementedException();
        }

        private void DoYuruyi()
        {
            throw new NotImplementedException();
        }

        private void DoFangyuma()
        {
            throw new NotImplementedException();
        }

        private void DoJingongma()
        {
            throw new NotImplementedException();
        }

        private void DoTanlangquwu()
        {
            throw new NotImplementedException();
        }

        private void DoWuzhongshengyou()
        {
            throw new NotImplementedException();
        }

        private void DoFenghuolangyan()
        {
            throw new NotImplementedException();
        }

        private void DoJuedou()
        {
            throw new NotImplementedException();
        }

        private void DoJiedaosharen()
        {
            throw new NotImplementedException();
        }

        private void DoFudichouxin()
        {
            throw new NotImplementedException();
        }

        private void DoShoupenglei()
        {
            throw new NotImplementedException();
        }

        private void DoHuadiweilao()
        {
            throw new NotImplementedException();
        }

        private void DoWugufengdeng()
        {
            throw new NotImplementedException();
        }

        private void DoXiuyangshengxi()
        {
            throw new NotImplementedException();
        }

        private void DoWuxiekeji()
        {
            throw new NotImplementedException();
        }

        private void DoYao()
        {
            throw new NotImplementedException();
        }

        private void DoShan()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 杀
        /// </summary>
        /// <param name="fromUserIndex"></param>
        /// <param name="targetUserIndexes"></param>
        /// <param name="cardsFrom"></param>
        private void DoSha(int fromUserIndex, int[] targetUserIndexes, CardModel cardModel)
        {
            //是杀，目标需要出闪或者防具
            foreach (int tUserIndex in targetUserIndexes)
            {
                //获取目标用户的HandCardManager
                new HandCardManager().Receiver(fromUserIndex, cardModel);
            }
        }
    }
}
