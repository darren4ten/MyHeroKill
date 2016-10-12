using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHeroKill.Model.Weapons
{
    public class FangyumaWeapon : BaseWeapon
    {
        public FangyumaWeapon()
        {
            this.Name = "防御马";
            this.PositionOfWeaponList = 0;
            this.IndexOfCards = 0;
            this.BaseLife = 0;
            this.BaseDamage = 0;
            this.BaseAttackDistance = 0;
            this.AddAttackDistance = 0;
            this.AddDefenceDistance = 1;
            this.AddDamage = 0;
            this.AddLife = 0;
            this.AddAttackCount = 0;
            this.CanProvideJuedou = false;
            this.CanProvideSha = false;
            this.CanProvideShan = false;
            this.CanProvideWuxiekeji = false;
        }

    }
}
