using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHeroKill.Model
{
    public interface IRole
    {
        /// <summary>
        /// 角色在牌堆中的位置
        /// </summary>
        int IndexOfRoles { get; set; }
        string Name { get; set; }
        string ImgUrl { get; set; }

        /// <summary>
        /// 皮肤ID
        /// </summary>
        int SkinId { get; set; }

        int BaseDamage { get; set; }
        int BaseLife { get; set; }
        int BaseAttackDistance { get; set; }

        /// <summary>
        /// 血量变动，比如掉血、回血
        /// </summary>
        /// <param name="deltaLife">血量变化值，可为负数</param>
        void ChangeLife(int deltaLife);


    }
}
