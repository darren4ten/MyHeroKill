using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHeroKill.Model.Weapons
{
    public class HufuWeapon : BaseWeapon
    {
        public HufuWeapon()
        {
            this.Name = "虎符";
            this.IndexOfCards = 0;
            this.BaseLife = 0;
            this.BaseDamage = 0;
            this.BaseAttackDistance = 0;
            this.AddAttackDistance = 1;
            this.AddDamage = 0;
            this.AddLife = 0;
            this.AddAttackCount = 9999;
            this.CanProvideJuedou = false;
            this.CanProvideSha = false;
            this.CanProvideShan = false;
            this.CanProvideWuxiekeji = false;
        }
    }
}
