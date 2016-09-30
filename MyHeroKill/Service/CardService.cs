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

        public Card GetCard(int index)
        {
            var list = new List<Card>();
            list.Add(new Card() { IndexInCards = 1, Name = "红桃A", Number = 1, Type = Enums.CardType.HongTao });
            list.Add(new Card() { IndexInCards = 2, Name = "黑桃A", Number = 1, Type = Enums.CardType.HeiTao });
            list.Add(new Card() { IndexInCards = 3, Name = "方块A", Number = 1, Type = Enums.CardType.FangPian });
            list.Add(new Card() { IndexInCards = 4, Name = "梅花A", Number = 1, Type = Enums.CardType.MeiHua });

            list.Add(new Card() { IndexInCards = 5, Name = "红桃2", Number = 2, Type = Enums.CardType.HongTao });
            list.Add(new Card() { IndexInCards = 6, Name = "黑桃2", Number = 2, Type = Enums.CardType.HeiTao });
            list.Add(new Card() { IndexInCards = 7, Name = "方块2", Number = 2, Type = Enums.CardType.FangPian });
            list.Add(new Card() { IndexInCards = 8, Name = "梅花2", Number = 2, Type = Enums.CardType.MeiHua });

            list.Add(new Card() { IndexInCards = 9, Name = "红桃3", Number = 3, Type = Enums.CardType.HongTao });
            list.Add(new Card() { IndexInCards = 10, Name = "黑桃3", Number = 3, Type = Enums.CardType.HeiTao });
            list.Add(new Card() { IndexInCards = 11, Name = "方块3", Number = 3, Type = Enums.CardType.FangPian });
            list.Add(new Card() { IndexInCards = 12, Name = "梅花3", Number = 3, Type = Enums.CardType.MeiHua });

            list.Add(new Card() { IndexInCards = 1, Name = "红桃A", Number = 4, Type = Enums.CardType.HongTao });
            list.Add(new Card() { IndexInCards = 1, Name = "黑桃A", Number = 4, Type = Enums.CardType.HeiTao });
            list.Add(new Card() { IndexInCards = 1, Name = "方块A", Number = 4, Type = Enums.CardType.FangPian });
            list.Add(new Card() { IndexInCards = 1, Name = "梅花A", Number = 4, Type = Enums.CardType.MeiHua });

            list.Add(new Card() { IndexInCards = 1, Name = "红桃A", Number = 1, Type = Enums.CardType.HongTao });
            list.Add(new Card() { IndexInCards = 1, Name = "黑桃A", Number = 1, Type = Enums.CardType.HeiTao });
            list.Add(new Card() { IndexInCards = 1, Name = "方块A", Number = 1, Type = Enums.CardType.FangPian });
            list.Add(new Card() { IndexInCards = 1, Name = "梅花A", Number = 1, Type = Enums.CardType.MeiHua });

            list.Add(new Card() { IndexInCards = 1, Name = "红桃A", Number = 1, Type = Enums.CardType.HongTao });
            list.Add(new Card() { IndexInCards = 1, Name = "黑桃A", Number = 1, Type = Enums.CardType.HeiTao });
            list.Add(new Card() { IndexInCards = 1, Name = "方块A", Number = 1, Type = Enums.CardType.FangPian });
            list.Add(new Card() { IndexInCards = 1, Name = "梅花A", Number = 1, Type = Enums.CardType.MeiHua });

            list.Add(new Card() { IndexInCards = 1, Name = "红桃A", Number = 1, Type = Enums.CardType.HongTao });
            list.Add(new Card() { IndexInCards = 1, Name = "黑桃A", Number = 1, Type = Enums.CardType.HeiTao });
            list.Add(new Card() { IndexInCards = 1, Name = "方块A", Number = 1, Type = Enums.CardType.FangPian });
            list.Add(new Card() { IndexInCards = 1, Name = "梅花A", Number = 1, Type = Enums.CardType.MeiHua });

            list.Add(new Card() { IndexInCards = 1, Name = "红桃A", Number = 1, Type = Enums.CardType.HongTao });
            list.Add(new Card() { IndexInCards = 1, Name = "黑桃A", Number = 1, Type = Enums.CardType.HeiTao });
            list.Add(new Card() { IndexInCards = 1, Name = "方块A", Number = 1, Type = Enums.CardType.FangPian });
            list.Add(new Card() { IndexInCards = 1, Name = "梅花A", Number = 1, Type = Enums.CardType.MeiHua });

            list.Add(new Card() { IndexInCards = 1, Name = "红桃A", Number = 1, Type = Enums.CardType.HongTao });
            list.Add(new Card() { IndexInCards = 1, Name = "黑桃A", Number = 1, Type = Enums.CardType.HeiTao });
            list.Add(new Card() { IndexInCards = 1, Name = "方块A", Number = 1, Type = Enums.CardType.FangPian });
            list.Add(new Card() { IndexInCards = 1, Name = "梅花A", Number = 1, Type = Enums.CardType.MeiHua });

            list.Add(new Card() { IndexInCards = 1, Name = "红桃A", Number = 1, Type = Enums.CardType.HongTao });
            list.Add(new Card() { IndexInCards = 1, Name = "黑桃A", Number = 1, Type = Enums.CardType.HeiTao });
            list.Add(new Card() { IndexInCards = 1, Name = "方块A", Number = 1, Type = Enums.CardType.FangPian });
            list.Add(new Card() { IndexInCards = 1, Name = "梅花A", Number = 1, Type = Enums.CardType.MeiHua });

            list.Add(new Card() { IndexInCards = 1, Name = "红桃A", Number = 1, Type = Enums.CardType.HongTao });
            list.Add(new Card() { IndexInCards = 1, Name = "黑桃A", Number = 1, Type = Enums.CardType.HeiTao });
            list.Add(new Card() { IndexInCards = 1, Name = "方块A", Number = 1, Type = Enums.CardType.FangPian });
            list.Add(new Card() { IndexInCards = 1, Name = "梅花A", Number = 1, Type = Enums.CardType.MeiHua });

            list.Add(new Card() { IndexInCards = 1, Name = "红桃A", Number = 1, Type = Enums.CardType.HongTao });
            list.Add(new Card() { IndexInCards = 1, Name = "黑桃A", Number = 1, Type = Enums.CardType.HeiTao });
            list.Add(new Card() { IndexInCards = 1, Name = "方块A", Number = 1, Type = Enums.CardType.FangPian });
            list.Add(new Card() { IndexInCards = 1, Name = "梅花A", Number = 1, Type = Enums.CardType.MeiHua });

            list.Add(new Card() { IndexInCards = 1, Name = "红桃A", Number = 1, Type = Enums.CardType.HongTao });
            list.Add(new Card() { IndexInCards = 1, Name = "黑桃A", Number = 1, Type = Enums.CardType.HeiTao });
            list.Add(new Card() { IndexInCards = 1, Name = "方块A", Number = 1, Type = Enums.CardType.FangPian });
            list.Add(new Card() { IndexInCards = 1, Name = "梅花A", Number = 1, Type = Enums.CardType.MeiHua });


            return list.Where(p => p.IndexInCards == index).First();
        }
    }
}
