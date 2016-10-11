using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHeroKill.Model.Skills
{
    public class ShucaiSkill : BaseSkill
    {
        public ShucaiSkill()
        {
            this.Name = "疏财";
            this.AddAttackDistance = 0;
            this.AddDamage = 0;
            this.AddLife = 0;
            this.AddAttackCount = 0;
            this.CanProvideJuedou = false;
            this.CanProvideSha = false;
            this.CanProvideShan = false;
            this.CanProvideWuxiekeji = false;
            this.CanProvideYao = false;
            this.SkillType = Enums.ESkillType.MainSkill;
        }

        public override void OnSkillActive()
        {
            //出牌时可以将手牌给任意角色，如果给了两张及以上牌则自身恢复一滴血
        }
    }
}
