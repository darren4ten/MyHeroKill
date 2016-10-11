using MyHeroKill.Model.Weapons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHeroKill.Model.Roles
{
    public class YangyanzhaoRole : BaseRole
    {
        public YangyanzhaoRole()
        {
            this.IndexOfRoles = 1;
            this.Name = "杨延昭";
            this.SkinId = 0;
            this.BaseDamage = 1;
            this.BaseLife = 4;
            this.BaseAttackDistance = 1;
            this.BaseAttackCount = 1;
            this.CurrentAttackCount = this.BaseAttackCount;
            this.BaseSkills = new List<Skills.ISkill>();
            //默认装备虎符
            this.BaseWeapons = new List<Wepons.IWeapon>();
            HufuWeapon hufu = new HufuWeapon();
            this.BaseWeapons.Add(hufu);

            this.AdditionalSkills = new List<Skills.ISkill>();
            this.AdditionalWeapons = new List<Wepons.IWeapon>();

            this.CurrentDamage = this.BaseDamage;
            this.CurrentLife = this.BaseLife;
            this.CurrentAttackDistance = this.BaseAttackDistance;
            this.SumRoleProperties();
        }
    }
}
