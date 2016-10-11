using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHeroKill.Model.Skills
{
    public interface ISkill
    {
        string Name { get; set; }
        string ImgUrl { get; set; }
        MyHeroKill.Model.Enums.ESkillType SkillType { get; set; }
        int AddDamage { get; set; }
        int AddLife { get; set; }
        int AddAttackDistance { get; set; }
        /// <summary>
        /// 增加单回合杀的次数
        /// </summary>
        int AddAttackCount { get; set; }

        bool CanProvideSha { get; set; }
        bool CanProvideShan { get; set; }
        bool CanProvideJuedou { get; set; }
        bool CanProvideWuxiekeji { get; set; }

        bool CanProvideYao { get; set; }

        /// <summary>
        /// 技能激活之后
        /// </summary>
        void OnSkillActive();

        void OnBeforeSha();
        void OnAfterSha(bool isSuccess);

        void OnBeforeShan();

        void OnAfterShan(bool isSuccess);

        void OnAskYao();
        void OnAskSha();
        void OnAskShan();
        void OnAskJuedou();
        void OnAskWuxiekeji();
    }
}
