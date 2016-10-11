using MyHeroKill.Model.Skills;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHeroKill.Model.Roles
{
    public class BianqueRole : BaseRole
    {
        public BianqueRole()
        {
            this.IndexOfRoles = 1;
            this.Name = "扁鹊";
            this.SkinId = 0;
            this.BaseDamage = 1;
            this.BaseLife = 3;
            this.BaseAttackDistance = 1;
            this.BaseAttackCount = 1;
            this.BaseSkills = new List<Skills.ISkill>();
            //默认疗伤技能
            LiaoshangSkill skill = new LiaoshangSkill();
            HuichunSkill skill2 = new HuichunSkill();
            this.BaseSkills.Add(skill);
            this.BaseSkills.Add(skill2);
            this.AdditionalSkills = new List<Skills.ISkill>();
            this.AdditionalWeapons = new List<Wepons.IWeapon>();

            this.CurrentDamage = this.BaseDamage;
            this.CurrentLife = this.BaseLife;
            this.CurrentAttackDistance = this.BaseAttackDistance;
            this.SumRoleProperties();
        }
    }
}
