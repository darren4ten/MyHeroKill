using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHeroKill.Model.Skills
{
    public class BudaoSkill : BaseSkill
    {
        public BudaoSkill()
        {
            this.Name = "补刀";
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

        public override void OnAskSha()
        {
            //在询问杀的时候，如果被攻击者在攻击范围内，则可以进行补刀
            Console.WriteLine("在询问杀的时候，如果被攻击者在攻击范围内，则可以进行补刀");
        }
    }
}
