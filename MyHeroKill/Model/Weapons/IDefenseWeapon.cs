using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHeroKill.Model.Weapons
{
    public interface IDefenseWeapon
    {
        /// <summary>
        /// 是几星
        /// </summary>
        int Star { get; set; }

        /// <summary>
        /// 没星增加的几率
        /// </summary>
        int StarDeltaRate { get; set; }

        /// <summary>
        /// 是几级
        /// </summary>
        int Level { get; set; }

        int BaseTriggerRate { get; set; }
        /// <summary>
        /// 突发概率
        /// </summary>
        int TriggerRate { get; }

        /// <summary>
        /// 触发颜色
        /// </summary>
        MyHeroKill.Model.Enums.ECardColors TriggerColor { get; set; }

        /// <summary>
        /// 可以免疫杀
        /// </summary>
        bool CanDefenceHeiSha { get; set; }

        bool CanDefenceHongSha { get; set; }

        bool CanDefenceFenghuolangyan { get; set; }
        bool CanDefenceWanjianqifa { get; set; }
    }
}
