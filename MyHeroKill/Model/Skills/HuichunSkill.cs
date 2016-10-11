using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHeroKill.Model.Skills
{
    public class HuichunSkill : BaseSkill
    {
        public HuichunSkill()
        {
            this.Name = "回春";
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
            //
        }

        public override void OnAskYao()
        {
            //自己的回合外，在询问药的时候可以用红桃当做药
            Console.WriteLine("可以出一张红桃牌给血量为<=0的角色一点血");
        }
    }
}
