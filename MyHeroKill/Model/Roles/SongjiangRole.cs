using MyHeroKill.Model.Skills;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHeroKill.Model.Roles
{
    public class SongjiangRole : BaseRole
    {
        public SongjiangRole()
        {
            this.IndexOfRoles = 1;
            this.Name = "宋江";
            this.SkinId = 0;
            this.BaseDamage = 1;
            this.BaseLife = 4;
            this.BaseAttackDistance = 1;
            this.BaseAttackCount = 1;
            this.BaseSkills = new List<Skills.ISkill>();
            //默认疏财技能
            ShucaiSkill skill = new ShucaiSkill();
            this.BaseSkills.Add(skill);

            this.AdditionalSkills = new List<Skills.ISkill>();
            this.AdditionalWeapons = new List<Wepons.IWeapon>();

            this.CurrentDamage = this.BaseDamage;
            this.CurrentLife = this.BaseLife;
            this.CurrentAttackDistance = this.BaseAttackDistance;
            this.SumRoleProperties();
        }
    }
}
