using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHeroKill.Model.Skills
{
    public class LiaoshangSkill : BaseSkill
    {
        public LiaoshangSkill()
        {
            this.Name = "疗伤";
            this.AddAttackDistance = 0;
            this.AddDamage = 0;
            this.AddLife = 0;
            this.AddAttackCount = 0;
            this.CanProvideJuedou = false;
            this.CanProvideSha = false;
            this.CanProvideShan = false;
            this.CanProvideWuxiekeji = false;
            //可以提供药
            this.CanProvideYao = true;
            this.SkillType = Enums.ESkillType.MainSkill;
        }

        public override void OnSkillActive()
        {
            //可以将手牌当做药
            Console.WriteLine("请出一张牌恢复一点血");
        }

        public override void OnAskYao()
        {
            //
        }
    }
}
