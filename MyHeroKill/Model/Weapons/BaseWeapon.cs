using MyHeroKill.Model.Wepons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHeroKill.Model.Weapons
{
    public class BaseWeapon : IWeapon
    {
        #region 属性
        public string Name
        {
            get;
            set;
        }

        public int IndexOfCards
        {
            get;
            set;
        }

        public string ImgUrl
        {
            get;
            set;
        }

        public int BaseDamage
        {
            get;
            set;
        }

        public int BaseLife
        {
            get;
            set;
        }

        public int BaseAttackDistance
        {
            get;
            set;
        }

        public int AddDamage
        {
            get;
            set;
        }

        public int AddLife
        {
            get;
            set;
        }

        public int AddAttackDistance
        {
            get;
            set;
        }
        #endregion

        public BaseWeapon()
        {
            this.Name = "武器";
            this.IndexOfCards = 0;
            this.BaseLife = 0;
            this.BaseDamage = 0;
            this.BaseAttackDistance = 1;
            this.AddAttackDistance = 1;
            this.AddDamage = 0;
            this.AddLife = 0;
        }


        public void CanDoEvents()
        {
            
        }

        public void MustDoEvents()
        {
            
        }
    }
}
