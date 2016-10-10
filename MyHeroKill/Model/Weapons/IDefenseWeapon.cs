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
        /// 突发概率
        /// </summary>
        int TriggerRate { get; }

        /// <summary>
        /// 触发颜色
        /// </summary>
        MyHeroKill.Model.Enums.ECardColors TriggerColor { get; }

        bool CanDefenceSha { get; }

        /// <summary>
        /// 可以免疫杀
        /// </summary>
        bool CanDefenceHeiSha { get; }

        bool CanDefenceHongSha { get; }

        bool CanDefenceFenghuolangyan { get; }
        bool CanDefenceWanjianqifa { get; }
    }
}
