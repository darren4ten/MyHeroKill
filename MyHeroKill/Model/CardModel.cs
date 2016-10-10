using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHeroKill.Model
{
    /// <summary>
    /// 出牌的牌模型
    /// </summary>
    public class CardModel
    {
        /// <summary>
        /// 需要出的牌的真实类型
        /// </summary>
        public MyHeroKill.Model.Enums.ECardGloabalType NeedHandoutGloabalType { get; set; }

        /// <summary>
        /// 牌需要的花色
        /// </summary>
        public MyHeroKill.Model.Enums.ECardColorAndSignType NeedHandoutCardColorAndSign { get; set; }

        /// <summary>
        /// 需要出牌的数量
        /// </summary>
        public int NeedHandoutCardCount { get; set; }

        /// <summary>
        /// 来源牌，原始牌（出牌方所出的牌）
        /// </summary>
        public List<Card> CardsFrom { get; set; }

        
        /// <summary>
        /// 命中造成的伤害值
        /// </summary>
        public int AddDamage { get; set; }

        /// <summary>
        /// 命中会增加的血量
        /// </summary>
        public int AddLife { get; set; }

    }
}
