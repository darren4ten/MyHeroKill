using MyHeroKill.Model;
using MyHeroKill.Service;
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
        public int StartRoleIndex = 0;
        //洗过的整副牌
        protected Stack<int> currentCardIndexes = new Stack<int>();
        protected Dictionary<int, IRole> _rolesPositionDic = new Dictionary<int, IRole>();
        protected CardService cardService = new CardService();
        protected int currentActiveRoleIndex = 0;

        /// <summary>
        /// 获取指定位置的角色
        /// </summary>
        /// <param name="indexOfPosition"></param>
        /// <returns></returns>
        public IRole GetRole(int indexOfPosition)
        {
            if (this._rolesPositionDic.Keys.Contains(indexOfPosition))
            {
                return this._rolesPositionDic[indexOfPosition];
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 获取当前是谁的回合
        /// </summary>
        /// <returns></returns>
        public int GetCurrentActiveRoleIndex()
        {
            return currentActiveRoleIndex;
        }

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

        /// <summary>
        /// 初始化
        /// </summary>
        /// <param name="dic">所有角色及序号</param>
        /// <param name="startRoleIndex">从角色列表中的哪个角色开始</param>
        public void Init(Dictionary<int, IRole> dic, int currentRoleIndex, int startRoleIndex = -1)
        {
            //洗牌
            this.currentCardIndexes = cardService.GetNewCardAsStack();
            if (dic != null)
            {
                if (startRoleIndex == -1)
                {
                    //开始出牌的是谁
                    this.StartRoleIndex = new Random().Next(dic.Count + 1);
                    //当前出牌的是谁
                    this.currentActiveRoleIndex = this.StartRoleIndex;
                }
                else
                {
                    this.StartRoleIndex = startRoleIndex;
                    this.currentActiveRoleIndex = startRoleIndex;
                }

            }
            this._rolesPositionDic = dic;

        }

        /// <summary>
        /// 摸牌
        /// </summary>
        /// <param name="number"></param>
        public List<Card> GetCards(int number)
        {
            List<Card> list = new List<Card>();
            for (int i = 0; i < number; i++)
            {
                if (this.currentCardIndexes.Count > 0)
                {
                    list.Add(cardService.GetCard(this.currentCardIndexes.Pop()));
                }
                else
                {
                    //没牌重新洗牌
                    Console.WriteLine("没牌了，重新洗牌");
                    this.currentCardIndexes = cardService.GetNewCardAsStack();
                    list.Add(cardService.GetCard(this.currentCardIndexes.Pop()));
                }
            }
            return list;
        }
    }
}
