using MyHeroKill.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHeroKill.Service
{
    public class CardService
    {
        /// <summary>
        /// 获取无序的新牌
        /// </summary>
        /// <returns></returns>
        public int[] GetNewCards()
        {
            int[] cards = Enumerable.Range(1, 106).ToArray();//1 2 3 4 
            Random r = new Random();
            for (int i = 0; i < cards.Length; i++)
            {
                int tempIndex = r.Next(i, cards.Length);
                int tempValue = cards[tempIndex];
                cards[tempIndex] = cards[i];
                cards[i] = tempValue;
            }
            return cards;
        }

        public List<Card> GetAllCard()
        {
            var list = new List<Card>();
            list.Add(new Card() { IndexInCards = 1, IsJuedou = true, Name = "红桃A", Number = 1, Type = Enums.ECardColorAndSignType.HongTao });
            list.Add(new Card() { IndexInCards = 2, IsHufu = true, Name = "黑桃A", Number = 1, Type = Enums.ECardColorAndSignType.HeiTao });
            list.Add(new Card() { IndexInCards = 3, IsXiuyangshengxi = true, Name = "方块A", Number = 1, Type = Enums.ECardColorAndSignType.FangPian });
            list.Add(new Card() { IndexInCards = 4, IsShoupenglei = true, Name = "梅花A", Number = 1, Type = Enums.ECardColorAndSignType.MeiHua });

            list.Add(new Card() { IndexInCards = 5, IsTanlangquwu = true, Name = "红桃2", Number = 2, Type = Enums.ECardColorAndSignType.HongTao });
            list.Add(new Card() { IndexInCards = 6, IsSha = true, Name = "黑桃2", Number = 2, Type = Enums.ECardColorAndSignType.HeiTao });
            list.Add(new Card() { IndexInCards = 7, IsShan = true, Name = "方块2", Number = 2, Type = Enums.ECardColorAndSignType.FangPian });
            list.Add(new Card() { IndexInCards = 8, IsYuruyi = true, Name = "梅花2", Number = 2, Type = Enums.ECardColorAndSignType.MeiHua });

            list.Add(new Card() { IndexInCards = 9, IsYao = true, Name = "红桃3", Number = 3, Type = Enums.ECardColorAndSignType.HongTao });
            list.Add(new Card() { IndexInCards = 10, IsFudichouxin = true, Name = "黑桃3", Number = 3, Type = Enums.ECardColorAndSignType.HeiTao });
            list.Add(new Card() { IndexInCards = 11, IsShan = true, Name = "方块3", Number = 3, Type = Enums.ECardColorAndSignType.FangPian });
            list.Add(new Card() { IndexInCards = 12, IsFudichouxin = true, Name = "梅花3", Number = 3, Type = Enums.ECardColorAndSignType.MeiHua });

            list.Add(new Card() { IndexInCards = 13, IsTanlangquwu = true, Name = "红桃4", Number = 4, Type = Enums.ECardColorAndSignType.HongTao });
            list.Add(new Card() { IndexInCards = 14, IsSha = true, Name = "黑桃4", Number = 4, Type = Enums.ECardColorAndSignType.HeiTao });
            list.Add(new Card() { IndexInCards = 15, IsWugufengdeng = true, Name = "方块4", Number = 4, Type = Enums.ECardColorAndSignType.FangPian });
            list.Add(new Card() { IndexInCards = 16, IsTanlangquwu = true, Name = "梅花4", Number = 4, Type = Enums.ECardColorAndSignType.MeiHua });

            list.Add(new Card() { IndexInCards = 17, IsFangyuma = true, Name = "红桃5", Number = 5, Type = Enums.ECardColorAndSignType.HongTao });
            list.Add(new Card() { IndexInCards = 18, IsSha = true, Name = "黑桃5", Number = 5, Type = Enums.ECardColorAndSignType.HeiTao });
            list.Add(new Card() { IndexInCards = 19, IsBolangchui = true, Name = "方块5", Number = 5, Type = Enums.ECardColorAndSignType.FangPian });
            list.Add(new Card() { IndexInCards = 20, IsPanlonggun = true, Name = "梅花5", Number = 5, Type = Enums.ECardColorAndSignType.MeiHua });

            list.Add(new Card() { IndexInCards = 21, IsSha = true, Name = "红桃6", Number = 6, Type = Enums.ECardColorAndSignType.HongTao });
            list.Add(new Card() { IndexInCards = 22, IsSha = true, Name = "黑桃6", Number = 6, Type = Enums.ECardColorAndSignType.HeiTao });
            list.Add(new Card() { IndexInCards = 23, IsHuadiweilao = true, Name = "方块6", Number = 6, Type = Enums.ECardColorAndSignType.FangPian });
            list.Add(new Card() { IndexInCards = 24, IsYuchangjian = true, Name = "梅花6", Number = 6, Type = Enums.ECardColorAndSignType.MeiHua });

            list.Add(new Card() { IndexInCards = 25, IsWuzhongshengyou = true, Name = "红桃7", Number = 7, Type = Enums.ECardColorAndSignType.HongTao });
            list.Add(new Card() { IndexInCards = 26, IsFenghuolangyang = true, Name = "黑桃7", Number = 7, Type = Enums.ECardColorAndSignType.HeiTao });
            list.Add(new Card() { IndexInCards = 27, IsSha = true, Name = "方块7", Number = 7, Type = Enums.ECardColorAndSignType.FangPian });
            list.Add(new Card() { IndexInCards = 28, IsSha = true, Name = "梅花7", Number = 7, Type = Enums.ECardColorAndSignType.MeiHua });

            list.Add(new Card() { IndexInCards = 29, IsWuzhongshengyou = true, Name = "红桃8", Number = 8, Type = Enums.ECardColorAndSignType.HongTao });
            list.Add(new Card() { IndexInCards = 30, IsSha = true, Name = "黑桃8", Number = 8, Type = Enums.ECardColorAndSignType.HeiTao });
            list.Add(new Card() { IndexInCards = 31, IsSha = true, Name = "方块8", Number = 8, Type = Enums.ECardColorAndSignType.FangPian });
            list.Add(new Card() { IndexInCards = 32, IsSha = true, Name = "梅花8", Number = 8, Type = Enums.ECardColorAndSignType.MeiHua });

            list.Add(new Card() { IndexInCards = 33, IsWuzhongshengyou = true, Name = "红桃9", Number = 9, Type = Enums.ECardColorAndSignType.HongTao });
            list.Add(new Card() { IndexInCards = 34, IsSha = true, Name = "黑桃9", Number = 9, Type = Enums.ECardColorAndSignType.HeiTao });
            list.Add(new Card() { IndexInCards = 35, IsSha = true, Name = "方块9", Number = 9, Type = Enums.ECardColorAndSignType.FangPian });
            list.Add(new Card() { IndexInCards = 36, IsSha = true, Name = "梅花9", Number = 9, Type = Enums.ECardColorAndSignType.MeiHua });

            list.Add(new Card() { IndexInCards = 37, IsSha = true, Name = "红桃10", Number = 10, Type = Enums.ECardColorAndSignType.HongTao });
            list.Add(new Card() { IndexInCards = 38, IsSha = true, Name = "黑桃10", Number = 10, Type = Enums.ECardColorAndSignType.HeiTao });
            list.Add(new Card() { IndexInCards = 39, IsSha = true, Name = "方块10", Number = 10, Type = Enums.ECardColorAndSignType.FangPian });
            list.Add(new Card() { IndexInCards = 40, IsSha = true, Name = "梅花10", Number = 10, Type = Enums.ECardColorAndSignType.MeiHua });

            list.Add(new Card() { IndexInCards = 41, IsWuzhongshengyou = true, Name = "红桃J", Number = 11, Type = Enums.ECardColorAndSignType.HongTao });
            list.Add(new Card() { IndexInCards = 42, IsSha = true, Name = "黑桃J", Number = 11, Type = Enums.ECardColorAndSignType.HeiTao });
            list.Add(new Card() { IndexInCards = 43, IsShan = true, Name = "方块J", Number = 11, Type = Enums.ECardColorAndSignType.FangPian });
            list.Add(new Card() { IndexInCards = 44, IsTanlangquwu = true, Name = "梅花J", Number = 11, Type = Enums.ECardColorAndSignType.MeiHua });

            list.Add(new Card() { IndexInCards = 45, IsWuxiekeji = true, Name = "红桃Q", Number = 12, Type = Enums.ECardColorAndSignType.HongTao });
            list.Add(new Card() { IndexInCards = 46, IsWuxiekeji = true, Name = "黑桃Q", Number = 12, Type = Enums.ECardColorAndSignType.HeiTao });
            list.Add(new Card() { IndexInCards = 47, IsShoupenglei = true, Name = "方块Q", Number = 12, Type = Enums.ECardColorAndSignType.FangPian });
            list.Add(new Card() { IndexInCards = 48, IsLuyeqiang = true, Name = "梅花Q", Number = 12, Type = Enums.ECardColorAndSignType.MeiHua });

            list.Add(new Card() { IndexInCards = 49, IsShan = true, Name = "红桃K", Number = 13, Type = Enums.ECardColorAndSignType.HongTao });
            list.Add(new Card() { IndexInCards = 50, IsWuxiekeji = true, Name = "黑桃K", Number = 13, Type = Enums.ECardColorAndSignType.HeiTao });
            list.Add(new Card() { IndexInCards = 51, IsSha = true, Name = "方块K", Number = 13, Type = Enums.ECardColorAndSignType.FangPian });
            list.Add(new Card() { IndexInCards = 52, IsJingongma = true, Name = "梅花K", Number = 13, Type = Enums.ECardColorAndSignType.MeiHua });

            //第二幅牌

            list.Add(new Card() { IndexInCards = 53, IsHufu = true, Name = "红桃A", Number = 1, Type = Enums.ECardColorAndSignType.HongTao });
            list.Add(new Card() { IndexInCards = 54, IsJuedou = true, Name = "黑桃A", Number = 1, Type = Enums.ECardColorAndSignType.HeiTao });
            list.Add(new Card() { IndexInCards = 55, IsWanjianqifa = true, Name = "方块A", Number = 1, Type = Enums.ECardColorAndSignType.FangPian });
            list.Add(new Card() { IndexInCards = 56, IsLonglindao = true, Name = "梅花A", Number = 1, Type = Enums.ECardColorAndSignType.MeiHua });

            list.Add(new Card() { IndexInCards = 57, IsShan = true, Name = "红桃2", Number = 2, Type = Enums.ECardColorAndSignType.HongTao });
            list.Add(new Card() { IndexInCards = 58, IsYuruyi = true, Name = "黑桃2", Number = 2, Type = Enums.ECardColorAndSignType.HeiTao });
            list.Add(new Card() { IndexInCards = 59, IsShan = true, Name = "方块2", Number = 2, Type = Enums.ECardColorAndSignType.FangPian });
            list.Add(new Card() { IndexInCards = 60, IsLonglindao = true, Name = "梅花2", Number = 2, Type = Enums.ECardColorAndSignType.MeiHua });

            list.Add(new Card() { IndexInCards = 61, IsTanlangquwu = true, Name = "红桃3", Number = 3, Type = Enums.ECardColorAndSignType.HongTao });
            list.Add(new Card() { IndexInCards = 62, IsFudichouxin = true, Name = "黑桃3", Number = 3, Type = Enums.ECardColorAndSignType.HeiTao });
            list.Add(new Card() { IndexInCards = 63, IsShan = true, Name = "方块3", Number = 3, Type = Enums.ECardColorAndSignType.FangPian });
            list.Add(new Card() { IndexInCards = 64, IsFudichouxin = true, Name = "梅花3", Number = 3, Type = Enums.ECardColorAndSignType.MeiHua });

            list.Add(new Card() { IndexInCards = 65, IsYao = true, Name = "红桃4", Number = 4, Type = Enums.ECardColorAndSignType.HongTao });
            list.Add(new Card() { IndexInCards = 66, IsFudichouxin = true, Name = "黑桃4", Number = 4, Type = Enums.ECardColorAndSignType.HeiTao });
            list.Add(new Card() { IndexInCards = 67, IsShan = true, Name = "方块4", Number = 4, Type = Enums.ECardColorAndSignType.FangPian });
            list.Add(new Card() { IndexInCards = 68, IsFudichouxin = true, Name = "梅花4", Number = 4, Type = Enums.ECardColorAndSignType.MeiHua });

            list.Add(new Card() { IndexInCards = 69, IsBawanggong = true, Name = "红桃5", Number = 5, Type = Enums.ECardColorAndSignType.HongTao });
            list.Add(new Card() { IndexInCards = 70, IsFangyuma = true, Name = "黑桃5", Number = 5, Type = Enums.ECardColorAndSignType.HeiTao });
            list.Add(new Card() { IndexInCards = 71, IsShan = true, Name = "方块5", Number = 5, Type = Enums.ECardColorAndSignType.FangPian });
            list.Add(new Card() { IndexInCards = 72, IsFangyuma = true, Name = "梅花5", Number = 5, Type = Enums.ECardColorAndSignType.MeiHua });

            list.Add(new Card() { IndexInCards = 73, IsYao = true, Name = "红桃6", Number = 6, Type = Enums.ECardColorAndSignType.HongTao });
            list.Add(new Card() { IndexInCards = 74, IsHuadiweilao = true, Name = "黑桃6", Number = 6, Type = Enums.ECardColorAndSignType.HeiTao });
            list.Add(new Card() { IndexInCards = 75, IsShan = true, Name = "方块6", Number = 6, Type = Enums.ECardColorAndSignType.FangPian });
            list.Add(new Card() { IndexInCards = 76, IsHuadiweilao = true, Name = "梅花6", Number = 6, Type = Enums.ECardColorAndSignType.MeiHua });

            list.Add(new Card() { IndexInCards = 77, IsYao = true, Name = "红桃7", Number = 7, Type = Enums.ECardColorAndSignType.HongTao });
            list.Add(new Card() { IndexInCards = 78, IsFenghuolangyang = true, Name = "黑桃7", Number = 7, Type = Enums.ECardColorAndSignType.HeiTao });
            list.Add(new Card() { IndexInCards = 79, IsShan = true, Name = "方块7", Number = 7, Type = Enums.ECardColorAndSignType.FangPian });
            list.Add(new Card() { IndexInCards = 80, IsFenghuolangyang = true, Name = "梅花7", Number = 7, Type = Enums.ECardColorAndSignType.MeiHua });

            list.Add(new Card() { IndexInCards = 81, IsYao = true, Name = "红桃8", Number = 8, Type = Enums.ECardColorAndSignType.HongTao });
            list.Add(new Card() { IndexInCards = 82, IsSha = true, Name = "黑桃8", Number = 8, Type = Enums.ECardColorAndSignType.HeiTao });
            list.Add(new Card() { IndexInCards = 83, IsShan = true, Name = "方块8", Number = 8, Type = Enums.ECardColorAndSignType.FangPian });
            list.Add(new Card() { IndexInCards = 84, IsSha = true, Name = "梅花8", Number = 8, Type = Enums.ECardColorAndSignType.MeiHua });

            list.Add(new Card() { IndexInCards = 85, IsYao = true, Name = "红桃9", Number = 9, Type = Enums.ECardColorAndSignType.HongTao });
            list.Add(new Card() { IndexInCards = 86, IsSha = true, Name = "黑桃9", Number = 9, Type = Enums.ECardColorAndSignType.HeiTao });
            list.Add(new Card() { IndexInCards = 87, IsShan = true, Name = "方块9", Number = 9, Type = Enums.ECardColorAndSignType.FangPian });
            list.Add(new Card() { IndexInCards = 88, IsSha = true, Name = "梅花9", Number = 9, Type = Enums.ECardColorAndSignType.MeiHua });

            list.Add(new Card() { IndexInCards = 89, IsSha = true, Name = "红桃10", Number = 10, Type = Enums.ECardColorAndSignType.HongTao });
            list.Add(new Card() { IndexInCards = 90, IsSha = true, Name = "黑桃10", Number = 10, Type = Enums.ECardColorAndSignType.HeiTao });
            list.Add(new Card() { IndexInCards = 91, IsShan = true, Name = "方块10", Number = 10, Type = Enums.ECardColorAndSignType.FangPian });
            list.Add(new Card() { IndexInCards = 92, IsSha = true, Name = "梅花10", Number = 10, Type = Enums.ECardColorAndSignType.MeiHua });

            list.Add(new Card() { IndexInCards = 93, IsSha = true, Name = "红桃J", Number = 11, Type = Enums.ECardColorAndSignType.HongTao });
            list.Add(new Card() { IndexInCards = 94, IsSha = true, Name = "黑桃J", Number = 11, Type = Enums.ECardColorAndSignType.HeiTao });
            list.Add(new Card() { IndexInCards = 95, IsShan = true, Name = "方块J", Number = 11, Type = Enums.ECardColorAndSignType.FangPian });
            list.Add(new Card() { IndexInCards = 96, IsWuxiekeji = true, Name = "梅花J", Number = 11, Type = Enums.ECardColorAndSignType.MeiHua });

            list.Add(new Card() { IndexInCards = 97, IsYao = true, Name = "红桃Q", Number = 12, Type = Enums.ECardColorAndSignType.HongTao });
            list.Add(new Card() { IndexInCards = 98, IsJiedaosharen = true, Name = "黑桃Q", Number = 12, Type = Enums.ECardColorAndSignType.HeiTao });
            list.Add(new Card() { IndexInCards = 99, IsFudichouxin = true, Name = "方块Q", Number = 12, Type = Enums.ECardColorAndSignType.FangPian });
            list.Add(new Card() { IndexInCards = 100, IsFudichouxin = true, Name = "梅花Q", Number = 12, Type = Enums.ECardColorAndSignType.MeiHua });

            list.Add(new Card() { IndexInCards = 101, IsJingongma = true, Name = "红桃K", Number = 13, Type = Enums.ECardColorAndSignType.HongTao });
            list.Add(new Card() { IndexInCards = 102, IsJiedaosharen = true, Name = "黑桃K", Number = 13, Type = Enums.ECardColorAndSignType.HeiTao });
            list.Add(new Card() { IndexInCards = 103, IsJingongma = true, Name = "方块K", Number = 13, Type = Enums.ECardColorAndSignType.FangPian });
            list.Add(new Card() { IndexInCards = 104, IsFenghuolangyang = true, Name = "梅花K", Number = 13, Type = Enums.ECardColorAndSignType.MeiHua });

            //额外的两张牌
            list.Add(new Card() { IndexInCards = 105, IsYao = true, Name = "方块Q", Number = 12, Type = Enums.ECardColorAndSignType.FangPian });
            list.Add(new Card() { IndexInCards = 101, IsYao = true, Name = "红桃Q", Number = 12, Type = Enums.ECardColorAndSignType.HongTao });

            return list;
        }

        public Card GetCard(int index)
        {
            return this.GetAllCard().Where(p => p.IndexInCards == index).First();
        }
    }
}
