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

        /// <summary>
        /// 获取无序的新牌
        /// </summary>
        /// <returns></returns>
        public List<int> GetNewCardsAsList()
        {
            return this.GetNewCards().ToList();
        }

        public Stack<int> GetNewCardAsStack()
        {
            return new Stack<int>(this.GetNewCards());
        }

        public List<Card> GetAllCard()
        {
            var list = new List<Card>();
            list.Add(new Card() { IndexInCards = 1, CardGloabalType = Enums.ECardGloabalType.Juedou, IsJuedou = true, Name = "红桃A", Number = 1, Type = Enums.ECardColorAndSignType.HongTao });
            list.Add(new Card() { IndexInCards = 2, CardGloabalType = Enums.ECardGloabalType.Hufu, IsHufu = true, Name = "黑桃A", Number = 1, Type = Enums.ECardColorAndSignType.HeiTao });
            list.Add(new Card() { IndexInCards = 3, CardGloabalType = Enums.ECardGloabalType.Xiuyangshengxi, IsXiuyangshengxi = true, Name = "方块A", Number = 1, Type = Enums.ECardColorAndSignType.FangPian });
            list.Add(new Card() { IndexInCards = 4, CardGloabalType = Enums.ECardGloabalType.Shoupenglei, IsShoupenglei = true, Name = "梅花A", Number = 1, Type = Enums.ECardColorAndSignType.MeiHua });

            list.Add(new Card() { IndexInCards = 5, CardGloabalType = Enums.ECardGloabalType.Tanlangquwu, IsTanlangquwu = true, Name = "红桃2", Number = 2, Type = Enums.ECardColorAndSignType.HongTao });
            list.Add(new Card() { IndexInCards = 6, CardGloabalType = Enums.ECardGloabalType.Sha, IsSha = true, Name = "黑桃2", Number = 2, Type = Enums.ECardColorAndSignType.HeiTao });
            list.Add(new Card() { IndexInCards = 7, CardGloabalType = Enums.ECardGloabalType.Shan, IsShan = true, Name = "方块2", Number = 2, Type = Enums.ECardColorAndSignType.FangPian });
            list.Add(new Card() { IndexInCards = 8, CardGloabalType = Enums.ECardGloabalType.Yuruyi, IsYuruyi = true, Name = "梅花2", Number = 2, Type = Enums.ECardColorAndSignType.MeiHua });

            list.Add(new Card() { IndexInCards = 9, CardGloabalType = Enums.ECardGloabalType.Yao, IsYao = true, Name = "红桃3", Number = 3, Type = Enums.ECardColorAndSignType.HongTao });
            list.Add(new Card() { IndexInCards = 10, CardGloabalType = Enums.ECardGloabalType.Fudichouxin, IsFudichouxin = true, Name = "黑桃3", Number = 3, Type = Enums.ECardColorAndSignType.HeiTao });
            list.Add(new Card() { IndexInCards = 11, CardGloabalType = Enums.ECardGloabalType.Shan, IsShan = true, Name = "方块3", Number = 3, Type = Enums.ECardColorAndSignType.FangPian });
            list.Add(new Card() { IndexInCards = 12, CardGloabalType = Enums.ECardGloabalType.Fudichouxin, IsFudichouxin = true, Name = "梅花3", Number = 3, Type = Enums.ECardColorAndSignType.MeiHua });

            list.Add(new Card() { IndexInCards = 13, CardGloabalType = Enums.ECardGloabalType.Tanlangquwu, IsTanlangquwu = true, Name = "红桃4", Number = 4, Type = Enums.ECardColorAndSignType.HongTao });
            list.Add(new Card() { IndexInCards = 14, CardGloabalType = Enums.ECardGloabalType.Sha, IsSha = true, Name = "黑桃4", Number = 4, Type = Enums.ECardColorAndSignType.HeiTao });
            list.Add(new Card() { IndexInCards = 15, CardGloabalType = Enums.ECardGloabalType.Wugufengdeng, IsWugufengdeng = true, Name = "方块4", Number = 4, Type = Enums.ECardColorAndSignType.FangPian });
            list.Add(new Card() { IndexInCards = 16, CardGloabalType = Enums.ECardGloabalType.Tanlangquwu, IsTanlangquwu = true, Name = "梅花4", Number = 4, Type = Enums.ECardColorAndSignType.MeiHua });

            list.Add(new Card() { IndexInCards = 17, CardGloabalType = Enums.ECardGloabalType.Fangyuma, IsFangyuma = true, Name = "红桃5", Number = 5, Type = Enums.ECardColorAndSignType.HongTao });
            list.Add(new Card() { IndexInCards = 18, CardGloabalType = Enums.ECardGloabalType.Sha, IsSha = true, Name = "黑桃5", Number = 5, Type = Enums.ECardColorAndSignType.HeiTao });
            list.Add(new Card() { IndexInCards = 19, CardGloabalType = Enums.ECardGloabalType.Bolangchui, IsBolangchui = true, Name = "方块5", Number = 5, Type = Enums.ECardColorAndSignType.FangPian });
            list.Add(new Card() { IndexInCards = 20, CardGloabalType = Enums.ECardGloabalType.Panlonggun, IsPanlonggun = true, Name = "梅花5", Number = 5, Type = Enums.ECardColorAndSignType.MeiHua });

            list.Add(new Card() { IndexInCards = 21, CardGloabalType = Enums.ECardGloabalType.Sha, IsSha = true, Name = "红桃6", Number = 6, Type = Enums.ECardColorAndSignType.HongTao });
            list.Add(new Card() { IndexInCards = 22, CardGloabalType = Enums.ECardGloabalType.Sha, IsSha = true, Name = "黑桃6", Number = 6, Type = Enums.ECardColorAndSignType.HeiTao });
            list.Add(new Card() { IndexInCards = 23, CardGloabalType = Enums.ECardGloabalType.Huadiweilao, IsHuadiweilao = true, Name = "方块6", Number = 6, Type = Enums.ECardColorAndSignType.FangPian });
            list.Add(new Card() { IndexInCards = 24, CardGloabalType = Enums.ECardGloabalType.Yuchangjian, IsYuchangjian = true, Name = "梅花6", Number = 6, Type = Enums.ECardColorAndSignType.MeiHua });

            list.Add(new Card() { IndexInCards = 25, CardGloabalType = Enums.ECardGloabalType.Wuzhongshengyou, IsWuzhongshengyou = true, Name = "红桃7", Number = 7, Type = Enums.ECardColorAndSignType.HongTao });
            list.Add(new Card() { IndexInCards = 26, CardGloabalType = Enums.ECardGloabalType.Fenghuolangyan, IsFenghuolangyang = true, Name = "黑桃7", Number = 7, Type = Enums.ECardColorAndSignType.HeiTao });
            list.Add(new Card() { IndexInCards = 27, CardGloabalType = Enums.ECardGloabalType.Sha, IsSha = true, Name = "方块7", Number = 7, Type = Enums.ECardColorAndSignType.FangPian });
            list.Add(new Card() { IndexInCards = 28, CardGloabalType = Enums.ECardGloabalType.Sha, IsSha = true, Name = "梅花7", Number = 7, Type = Enums.ECardColorAndSignType.MeiHua });

            list.Add(new Card() { IndexInCards = 29, CardGloabalType = Enums.ECardGloabalType.Wuzhongshengyou, IsWuzhongshengyou = true, Name = "红桃8", Number = 8, Type = Enums.ECardColorAndSignType.HongTao });
            list.Add(new Card() { IndexInCards = 30, CardGloabalType = Enums.ECardGloabalType.Sha, IsSha = true, Name = "黑桃8", Number = 8, Type = Enums.ECardColorAndSignType.HeiTao });
            list.Add(new Card() { IndexInCards = 31, CardGloabalType = Enums.ECardGloabalType.Sha, IsSha = true, Name = "方块8", Number = 8, Type = Enums.ECardColorAndSignType.FangPian });
            list.Add(new Card() { IndexInCards = 32, CardGloabalType = Enums.ECardGloabalType.Sha, IsSha = true, Name = "梅花8", Number = 8, Type = Enums.ECardColorAndSignType.MeiHua });

            list.Add(new Card() { IndexInCards = 33, CardGloabalType = Enums.ECardGloabalType.Wuzhongshengyou, IsWuzhongshengyou = true, Name = "红桃9", Number = 9, Type = Enums.ECardColorAndSignType.HongTao });
            list.Add(new Card() { IndexInCards = 34, CardGloabalType = Enums.ECardGloabalType.Sha, IsSha = true, Name = "黑桃9", Number = 9, Type = Enums.ECardColorAndSignType.HeiTao });
            list.Add(new Card() { IndexInCards = 35, CardGloabalType = Enums.ECardGloabalType.Sha, IsSha = true, Name = "方块9", Number = 9, Type = Enums.ECardColorAndSignType.FangPian });
            list.Add(new Card() { IndexInCards = 36, CardGloabalType = Enums.ECardGloabalType.Sha, IsSha = true, Name = "梅花9", Number = 9, Type = Enums.ECardColorAndSignType.MeiHua });

            list.Add(new Card() { IndexInCards = 37, CardGloabalType = Enums.ECardGloabalType.Sha, IsSha = true, Name = "红桃10", Number = 10, Type = Enums.ECardColorAndSignType.HongTao });
            list.Add(new Card() { IndexInCards = 38, CardGloabalType = Enums.ECardGloabalType.Sha, IsSha = true, Name = "黑桃10", Number = 10, Type = Enums.ECardColorAndSignType.HeiTao });
            list.Add(new Card() { IndexInCards = 39, CardGloabalType = Enums.ECardGloabalType.Sha, IsSha = true, Name = "方块10", Number = 10, Type = Enums.ECardColorAndSignType.FangPian });
            list.Add(new Card() { IndexInCards = 40, CardGloabalType = Enums.ECardGloabalType.Sha, IsSha = true, Name = "梅花10", Number = 10, Type = Enums.ECardColorAndSignType.MeiHua });

            list.Add(new Card() { IndexInCards = 41, CardGloabalType = Enums.ECardGloabalType.Wuzhongshengyou, IsWuzhongshengyou = true, Name = "红桃J", Number = 11, Type = Enums.ECardColorAndSignType.HongTao });
            list.Add(new Card() { IndexInCards = 42, CardGloabalType = Enums.ECardGloabalType.Sha, IsSha = true, Name = "黑桃J", Number = 11, Type = Enums.ECardColorAndSignType.HeiTao });
            list.Add(new Card() { IndexInCards = 43, CardGloabalType = Enums.ECardGloabalType.Shan, IsShan = true, Name = "方块J", Number = 11, Type = Enums.ECardColorAndSignType.FangPian });
            list.Add(new Card() { IndexInCards = 44, CardGloabalType = Enums.ECardGloabalType.Tanlangquwu, IsTanlangquwu = true, Name = "梅花J", Number = 11, Type = Enums.ECardColorAndSignType.MeiHua });

            list.Add(new Card() { IndexInCards = 45, CardGloabalType = Enums.ECardGloabalType.Wuxiekeji, IsWuxiekeji = true, Name = "红桃Q", Number = 12, Type = Enums.ECardColorAndSignType.HongTao });
            list.Add(new Card() { IndexInCards = 46, CardGloabalType = Enums.ECardGloabalType.Wuxiekeji, IsWuxiekeji = true, Name = "黑桃Q", Number = 12, Type = Enums.ECardColorAndSignType.HeiTao });
            list.Add(new Card() { IndexInCards = 47, CardGloabalType = Enums.ECardGloabalType.Shoupenglei, IsShoupenglei = true, Name = "方块Q", Number = 12, Type = Enums.ECardColorAndSignType.FangPian });
            list.Add(new Card() { IndexInCards = 48, CardGloabalType = Enums.ECardGloabalType.Luyeqiang, IsLuyeqiang = true, Name = "梅花Q", Number = 12, Type = Enums.ECardColorAndSignType.MeiHua });

            list.Add(new Card() { IndexInCards = 49, CardGloabalType = Enums.ECardGloabalType.Shan, IsShan = true, Name = "红桃K", Number = 13, Type = Enums.ECardColorAndSignType.HongTao });
            list.Add(new Card() { IndexInCards = 50, CardGloabalType = Enums.ECardGloabalType.Wuxiekeji, IsWuxiekeji = true, Name = "黑桃K", Number = 13, Type = Enums.ECardColorAndSignType.HeiTao });
            list.Add(new Card() { IndexInCards = 51, CardGloabalType = Enums.ECardGloabalType.Sha, IsSha = true, Name = "方块K", Number = 13, Type = Enums.ECardColorAndSignType.FangPian });
            list.Add(new Card() { IndexInCards = 52, CardGloabalType = Enums.ECardGloabalType.Jingongma, IsJingongma = true, Name = "梅花K", Number = 13, Type = Enums.ECardColorAndSignType.MeiHua });

            //第二幅牌

            list.Add(new Card() { IndexInCards = 53, CardGloabalType = Enums.ECardGloabalType.Hufu, IsHufu = true, Name = "红桃A", Number = 1, Type = Enums.ECardColorAndSignType.HongTao });
            list.Add(new Card() { IndexInCards = 54, CardGloabalType = Enums.ECardGloabalType.Juedou, IsJuedou = true, Name = "黑桃A", Number = 1, Type = Enums.ECardColorAndSignType.HeiTao });
            list.Add(new Card() { IndexInCards = 55, CardGloabalType = Enums.ECardGloabalType.Wanjianqifa, IsWanjianqifa = true, Name = "方块A", Number = 1, Type = Enums.ECardColorAndSignType.FangPian });
            list.Add(new Card() { IndexInCards = 56, CardGloabalType = Enums.ECardGloabalType.Longlingdao, IsLonglindao = true, Name = "梅花A", Number = 1, Type = Enums.ECardColorAndSignType.MeiHua });

            list.Add(new Card() { IndexInCards = 57, CardGloabalType = Enums.ECardGloabalType.Shan, IsShan = true, Name = "红桃2", Number = 2, Type = Enums.ECardColorAndSignType.HongTao });
            list.Add(new Card() { IndexInCards = 58, CardGloabalType = Enums.ECardGloabalType.Yuruyi, IsYuruyi = true, Name = "黑桃2", Number = 2, Type = Enums.ECardColorAndSignType.HeiTao });
            list.Add(new Card() { IndexInCards = 59, CardGloabalType = Enums.ECardGloabalType.Shan, IsShan = true, Name = "方块2", Number = 2, Type = Enums.ECardColorAndSignType.FangPian });
            list.Add(new Card() { IndexInCards = 60, CardGloabalType = Enums.ECardGloabalType.Longlingdao, IsLonglindao = true, Name = "梅花2", Number = 2, Type = Enums.ECardColorAndSignType.MeiHua });

            list.Add(new Card() { IndexInCards = 61, CardGloabalType = Enums.ECardGloabalType.Tanlangquwu, IsTanlangquwu = true, Name = "红桃3", Number = 3, Type = Enums.ECardColorAndSignType.HongTao });
            list.Add(new Card() { IndexInCards = 62, CardGloabalType = Enums.ECardGloabalType.Fudichouxin, IsFudichouxin = true, Name = "黑桃3", Number = 3, Type = Enums.ECardColorAndSignType.HeiTao });
            list.Add(new Card() { IndexInCards = 63, CardGloabalType = Enums.ECardGloabalType.Shan, IsShan = true, Name = "方块3", Number = 3, Type = Enums.ECardColorAndSignType.FangPian });
            list.Add(new Card() { IndexInCards = 64, CardGloabalType = Enums.ECardGloabalType.Fudichouxin, IsFudichouxin = true, Name = "梅花3", Number = 3, Type = Enums.ECardColorAndSignType.MeiHua });

            list.Add(new Card() { IndexInCards = 65, CardGloabalType = Enums.ECardGloabalType.Yao, IsYao = true, Name = "红桃4", Number = 4, Type = Enums.ECardColorAndSignType.HongTao });
            list.Add(new Card() { IndexInCards = 66, CardGloabalType = Enums.ECardGloabalType.Fudichouxin, IsFudichouxin = true, Name = "黑桃4", Number = 4, Type = Enums.ECardColorAndSignType.HeiTao });
            list.Add(new Card() { IndexInCards = 67, CardGloabalType = Enums.ECardGloabalType.Shan, IsShan = true, Name = "方块4", Number = 4, Type = Enums.ECardColorAndSignType.FangPian });
            list.Add(new Card() { IndexInCards = 68, CardGloabalType = Enums.ECardGloabalType.Fudichouxin, IsFudichouxin = true, Name = "梅花4", Number = 4, Type = Enums.ECardColorAndSignType.MeiHua });

            list.Add(new Card() { IndexInCards = 69, CardGloabalType = Enums.ECardGloabalType.Bawanggong, IsBawanggong = true, Name = "红桃5", Number = 5, Type = Enums.ECardColorAndSignType.HongTao });
            list.Add(new Card() { IndexInCards = 70, CardGloabalType = Enums.ECardGloabalType.Fangyuma, IsFangyuma = true, Name = "黑桃5", Number = 5, Type = Enums.ECardColorAndSignType.HeiTao });
            list.Add(new Card() { IndexInCards = 71, CardGloabalType = Enums.ECardGloabalType.Shan, IsShan = true, Name = "方块5", Number = 5, Type = Enums.ECardColorAndSignType.FangPian });
            list.Add(new Card() { IndexInCards = 72, CardGloabalType = Enums.ECardGloabalType.Fangyuma, IsFangyuma = true, Name = "梅花5", Number = 5, Type = Enums.ECardColorAndSignType.MeiHua });

            list.Add(new Card() { IndexInCards = 73, CardGloabalType = Enums.ECardGloabalType.Yao, IsYao = true, Name = "红桃6", Number = 6, Type = Enums.ECardColorAndSignType.HongTao });
            list.Add(new Card() { IndexInCards = 74, CardGloabalType = Enums.ECardGloabalType.Huadiweilao, IsHuadiweilao = true, Name = "黑桃6", Number = 6, Type = Enums.ECardColorAndSignType.HeiTao });
            list.Add(new Card() { IndexInCards = 75, CardGloabalType = Enums.ECardGloabalType.Shan, IsShan = true, Name = "方块6", Number = 6, Type = Enums.ECardColorAndSignType.FangPian });
            list.Add(new Card() { IndexInCards = 76, CardGloabalType = Enums.ECardGloabalType.Huadiweilao, IsHuadiweilao = true, Name = "梅花6", Number = 6, Type = Enums.ECardColorAndSignType.MeiHua });

            list.Add(new Card() { IndexInCards = 77, CardGloabalType = Enums.ECardGloabalType.Yao, IsYao = true, Name = "红桃7", Number = 7, Type = Enums.ECardColorAndSignType.HongTao });
            list.Add(new Card() { IndexInCards = 78, CardGloabalType = Enums.ECardGloabalType.Fenghuolangyan, IsFenghuolangyang = true, Name = "黑桃7", Number = 7, Type = Enums.ECardColorAndSignType.HeiTao });
            list.Add(new Card() { IndexInCards = 79, CardGloabalType = Enums.ECardGloabalType.Shan, IsShan = true, Name = "方块7", Number = 7, Type = Enums.ECardColorAndSignType.FangPian });
            list.Add(new Card() { IndexInCards = 80, CardGloabalType = Enums.ECardGloabalType.Fenghuolangyan, IsFenghuolangyang = true, Name = "梅花7", Number = 7, Type = Enums.ECardColorAndSignType.MeiHua });

            list.Add(new Card() { IndexInCards = 81, CardGloabalType = Enums.ECardGloabalType.Yao, IsYao = true, Name = "红桃8", Number = 8, Type = Enums.ECardColorAndSignType.HongTao });
            list.Add(new Card() { IndexInCards = 82, CardGloabalType = Enums.ECardGloabalType.Sha, IsSha = true, Name = "黑桃8", Number = 8, Type = Enums.ECardColorAndSignType.HeiTao });
            list.Add(new Card() { IndexInCards = 83, CardGloabalType = Enums.ECardGloabalType.Shan, IsShan = true, Name = "方块8", Number = 8, Type = Enums.ECardColorAndSignType.FangPian });
            list.Add(new Card() { IndexInCards = 84, CardGloabalType = Enums.ECardGloabalType.Sha, IsSha = true, Name = "梅花8", Number = 8, Type = Enums.ECardColorAndSignType.MeiHua });

            list.Add(new Card() { IndexInCards = 85, CardGloabalType = Enums.ECardGloabalType.Yao, IsYao = true, Name = "红桃9", Number = 9, Type = Enums.ECardColorAndSignType.HongTao });
            list.Add(new Card() { IndexInCards = 86, CardGloabalType = Enums.ECardGloabalType.Sha, IsSha = true, Name = "黑桃9", Number = 9, Type = Enums.ECardColorAndSignType.HeiTao });
            list.Add(new Card() { IndexInCards = 87, CardGloabalType = Enums.ECardGloabalType.Shan, IsShan = true, Name = "方块9", Number = 9, Type = Enums.ECardColorAndSignType.FangPian });
            list.Add(new Card() { IndexInCards = 88, CardGloabalType = Enums.ECardGloabalType.Sha, IsSha = true, Name = "梅花9", Number = 9, Type = Enums.ECardColorAndSignType.MeiHua });

            list.Add(new Card() { IndexInCards = 89, CardGloabalType = Enums.ECardGloabalType.Sha, IsSha = true, Name = "红桃10", Number = 10, Type = Enums.ECardColorAndSignType.HongTao });
            list.Add(new Card() { IndexInCards = 90, CardGloabalType = Enums.ECardGloabalType.Sha, IsSha = true, Name = "黑桃10", Number = 10, Type = Enums.ECardColorAndSignType.HeiTao });
            list.Add(new Card() { IndexInCards = 91, CardGloabalType = Enums.ECardGloabalType.Shan, IsShan = true, Name = "方块10", Number = 10, Type = Enums.ECardColorAndSignType.FangPian });
            list.Add(new Card() { IndexInCards = 92, CardGloabalType = Enums.ECardGloabalType.Sha, IsSha = true, Name = "梅花10", Number = 10, Type = Enums.ECardColorAndSignType.MeiHua });

            list.Add(new Card() { IndexInCards = 93, CardGloabalType = Enums.ECardGloabalType.Sha, IsSha = true, Name = "红桃J", Number = 11, Type = Enums.ECardColorAndSignType.HongTao });
            list.Add(new Card() { IndexInCards = 94, CardGloabalType = Enums.ECardGloabalType.Sha, IsSha = true, Name = "黑桃J", Number = 11, Type = Enums.ECardColorAndSignType.HeiTao });
            list.Add(new Card() { IndexInCards = 95, CardGloabalType = Enums.ECardGloabalType.Shan, IsShan = true, Name = "方块J", Number = 11, Type = Enums.ECardColorAndSignType.FangPian });
            list.Add(new Card() { IndexInCards = 96, CardGloabalType = Enums.ECardGloabalType.Wuxiekeji, IsWuxiekeji = true, Name = "梅花J", Number = 11, Type = Enums.ECardColorAndSignType.MeiHua });

            list.Add(new Card() { IndexInCards = 97, CardGloabalType = Enums.ECardGloabalType.Yao, IsYao = true, Name = "红桃Q", Number = 12, Type = Enums.ECardColorAndSignType.HongTao });
            list.Add(new Card() { IndexInCards = 98, CardGloabalType = Enums.ECardGloabalType.Jiedaosharen, IsJiedaosharen = true, Name = "黑桃Q", Number = 12, Type = Enums.ECardColorAndSignType.HeiTao });
            list.Add(new Card() { IndexInCards = 99, CardGloabalType = Enums.ECardGloabalType.Fudichouxin, IsFudichouxin = true, Name = "方块Q", Number = 12, Type = Enums.ECardColorAndSignType.FangPian });
            list.Add(new Card() { IndexInCards = 100, CardGloabalType = Enums.ECardGloabalType.Fudichouxin, IsFudichouxin = true, Name = "梅花Q", Number = 12, Type = Enums.ECardColorAndSignType.MeiHua });

            list.Add(new Card() { IndexInCards = 101, CardGloabalType = Enums.ECardGloabalType.Jingongma, IsJingongma = true, Name = "红桃K", Number = 13, Type = Enums.ECardColorAndSignType.HongTao });
            list.Add(new Card() { IndexInCards = 102, CardGloabalType = Enums.ECardGloabalType.Jiedaosharen, IsJiedaosharen = true, Name = "黑桃K", Number = 13, Type = Enums.ECardColorAndSignType.HeiTao });
            list.Add(new Card() { IndexInCards = 103, CardGloabalType = Enums.ECardGloabalType.Jingongma, IsJingongma = true, Name = "方块K", Number = 13, Type = Enums.ECardColorAndSignType.FangPian });
            list.Add(new Card() { IndexInCards = 104, CardGloabalType = Enums.ECardGloabalType.Fenghuolangyan, IsFenghuolangyang = true, Name = "梅花K", Number = 13, Type = Enums.ECardColorAndSignType.MeiHua });

            //额外的两张牌
            list.Add(new Card() { IndexInCards = 105, CardGloabalType = Enums.ECardGloabalType.Yao, IsYao = true, Name = "方块Q", Number = 12, Type = Enums.ECardColorAndSignType.FangPian });
            list.Add(new Card() { IndexInCards = 101, CardGloabalType = Enums.ECardGloabalType.Yao, IsYao = true, Name = "红桃Q", Number = 12, Type = Enums.ECardColorAndSignType.HongTao });

            return list;
        }

        public Card GetCard(int index)
        {
            return this.GetAllCard().Where(p => p.IndexInCards == index).First();
        }
    }
}
