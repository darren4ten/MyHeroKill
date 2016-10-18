using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHeroKill.Model
{
    public class AttackCardContainer
    {
        /// <summary>
        /// 需要出的牌的花色
        /// </summary>
        public Enums.ECardColorAndSignType NeedHandoutCardColorAndSign { get; set; }

        /// <summary>
        /// 需要出的数量
        /// </summary>
        public int NeedHandoutCardCount { get; set; }

        /// <summary>
        /// 需要出的牌的真实类型
        /// </summary>
        public Enums.ECardGloabalType NeedHandoutGloabalType { get; set; }
    }

    public class DefenseCardContainer
    {
        public DefenseCardContainer()
        {
            this.FromCards = new List<Card>();
        }
        public Enums.ECardColorAndSignType HandoutCardColorAndSign { get; set; }
        public Enums.ECardGloabalType NeedHandoutGloabalType { get; set; }

        public List<Card> FromCards { get; set; }

        /// <summary>
        /// 强制抵消，如玉如意当做闪，则认为是抵挡过了，不过不会有出牌
        /// </summary>
        public bool IsDefensed { get; set; }
    }
    /// <summary>
    /// 出牌的牌模型
    /// </summary>
    public class AttackCardModel
    {
        /// <summary>
        /// 所出的牌的真实类型
        /// </summary>
        public MyHeroKill.Model.Enums.ECardGloabalType FromCardGloabalType { get; set; }

        /// <summary>
        /// 需要出的牌的集合，序号越小优先级越高，多个NeedHandoutCards之间是或者的关系
        /// </summary>
        public List<AttackCardContainer> NeedHandoutCards { get; set; }

        /// <summary>
        /// 是否不可以抵御杀
        /// </summary>
        public bool CanNotDefenseSha { get; set; }

        /// <summary>
        /// 来源牌，原始牌（出牌方所出的牌）
        /// </summary>
        public List<Card> FromCards { get; set; }


        /// <summary>
        /// 命中造成的伤害值
        /// </summary>
        public int AddDamage { get; set; }

        /// <summary>
        /// 命中会增加的血量
        /// </summary>
        public int AddLife { get; set; }

    }

    public class DefenseCardModel
    {
        public DefenseCardModel()
        {
            this.DefenseCardContainers = new List<DefenseCardContainer>();
        }
        public List<DefenseCardContainer> DefenseCardContainers { get; set; }

        /// <summary>
        /// 是否强制抵消伤害，比如黑杀盾，触发黑杀盾，则可以认为是强制抵消
        /// </summary>
        public bool IsDefensed { get; set; }

        /// <summary>
        /// 是否出牌结束
        /// </summary>
        public bool IsHandoutOver { get; set; }

    }
}
