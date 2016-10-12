using MyHeroKill.Model.Skills;
using MyHeroKill.Model.Weapons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHeroKill.Model.Roles
{
    public class GuanyuRole : BaseRole
    {
        public GuanyuRole()
        {
            this.IndexOfRoles = 1;
            this.Name = "关羽";
            this.SkinId = 0;
            this.CampType = Enums.ERoleCampType.Chen;
            this.BaseDamage = 1;
            this.BaseLife = 4;
            this.BaseAttackDistance = 1;
            this.BaseAttackCount = 1;
            //默认霸王技能
            this.BaseSkills = new List<Skills.ISkill>();
            BudaoSkill skill = new BudaoSkill();
            this.BaseSkills.Add(skill);
            JingongmaWeapon wp = new JingongmaWeapon();
            this.BaseWeapons = new List<Wepons.IWeapon>();
            this.BaseWeapons.Add(wp);

            this.AdditionalSkills = new List<Skills.ISkill>();
            this.AdditionalWeapons = new List<Wepons.IWeapon>();

            this.CurrentDamage = this.BaseDamage;
            this.CurrentLife = this.BaseLife;
            this.CurrentAttackDistance = this.BaseAttackDistance;
            this.SumRoleProperties();
        }
    }
}
