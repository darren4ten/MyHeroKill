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
            foreach (int targetUserIndex in targetUserIndexes)
            {

                Console.WriteLine("{0}对{1}使用了{2}", fromUserIndex, targetUserIndex, cardModel.FromCardGloabalType);
                //获取目标用户的HandCardManager
                new HandCardManager().DefenceHandOut(fromUserIndex, cardModel);
            }
        }

    }
}
