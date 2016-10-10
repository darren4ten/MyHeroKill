﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHeroKill.Model.Weapons
{
    public class Longlindao : BaseWeapon
    {
        public Longlindao()
        {
            this.Name = "龙鳞刀";
            this.IndexOfCards = 0;
            this.BaseLife = 0;
            this.BaseDamage = 0;
            this.BaseAttackDistance = 0;
            this.AddAttackDistance = 2;
            this.AddDamage = 0;
            this.AddLife = 0;
        }

        public void CanDoEvents()
        {
            //选择两张牌弃掉
        }

    }
}
