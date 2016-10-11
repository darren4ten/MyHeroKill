using MyHeroKill.Model.Wepons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHeroKill.Model.Roles
{
    public abstract class BaseRole : IRole
    {
        #region 属性
        public int IndexOfRoles
        {
            get;
            set;
        }

        public string Name
        {
            get;
            set;
        }

        public string ImgUrl
        {
            get;
            set;
        }

        public int SkinId
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
        public int BaseAttackCount
        {
            get;
            set;
        }
        public List<Skills.ISkill> BaseSkills
        {
            get;
            set;
        }

        public List<Wepons.IWeapon> BaseWeapons
        {
            get;
            set;
        }
        public List<Skills.ISkill> AdditionalSkills
        {
            get;
            set;
        }

        public List<Wepons.IWeapon> AdditionalWeapons
        {
            get;
            set;
        }
        public int MaxLife { get; set; }

        public int CurrentDamage
        {
            get;
            set;
        }

        public int CurrentLife
        {
            get;
            set;
        }

        public int CurrentAttackDistance
        {
            get;
            set;
        }
        public int CurrentAttackCount { get; set; }
        #endregion

        public BaseRole()
        {
            this.IndexOfRoles = 1;
            this.Name = "英雄";
            this.SkinId = 0;
            this.BaseDamage = 1;
            this.BaseLife = 3;
            this.BaseAttackDistance = 1;
            this.BaseAttackCount = 1;
            this.BaseSkills = new List<Skills.ISkill>();
            this.BaseWeapons = new List<Wepons.IWeapon>();
            this.AdditionalSkills = new List<Skills.ISkill>();
            this.AdditionalWeapons = new List<Wepons.IWeapon>();
            this.CurrentDamage = this.BaseDamage;
            this.CurrentLife = this.BaseLife;
            this.CurrentAttackDistance = this.BaseAttackDistance;
            this.CurrentAttackCount = this.BaseAttackCount;
            this.SumRoleProperties();
        }

        public virtual void OnLifeChange(int deltaLife)
        {
            this.CurrentLife += deltaLife;
            if (this.CurrentLife > this.MaxLife)
            {
                this.CurrentLife = this.MaxLife;
            }
            if (this.CurrentLife <= 0)
            {
                //血量小于1，求药
                Console.WriteLine("要死了。。。");
            }
        }

        public virtual void OnRoleDying()
        {
        }

        public virtual void OnRolePlaying()
        {
        }

        public virtual void OnRoleIdle()
        {
        }

        public delegate void RoleEvents();
        public event RoleEvents OnRoleAskShaEvents;
        public event RoleEvents OnRoleAskShanEvents;
        public event RoleEvents OnRoleAskWuxiekejiEvents;
        public event RoleEvents OnRoleAskYaoEvents;
        public event RoleEvents OnRoleAskJuedouEvents;
        public virtual void TriggerOnRoleAskShaEvents()
        {
            this.OnRoleAskShaEvents();
        }
        public virtual void TriggerOnRoleAskShanEvents()
        {
            this.OnRoleAskShanEvents();
        }
        public virtual void TriggerOnRoleAskWuxiekejiEvents()
        {
            this.OnRoleAskWuxiekejiEvents();
        }
        public virtual void TriggerOnRoleAskYaoEvents()
        {
            this.OnRoleAskYaoEvents();
        }
        public virtual void TriggerOnRoleAskJuedouEvents()
        {
            this.OnRoleAskJuedouEvents();
        }


        /// <summary>
        /// 计算角色的综合属性
        /// </summary>
        protected virtual void SumRoleProperties()
        {
            //处理附加武器和附加技能增加的攻击距离。最大攻击距离=最大基础距离+最大附加距离的最大值
            int maxDistance = this.BaseAttackDistance;
            //分析角色所自带的武器、技能加成
            foreach (var item in this.BaseSkills)
            {
                this.CurrentLife += item.AddLife;
                this.CurrentDamage += item.AddDamage;
                this.BaseAttackDistance += item.AddAttackDistance;
                this.CurrentAttackDistance += item.AddAttackDistance;
                this.CurrentAttackCount += item.AddAttackCount;
                //事件
                this.OnRoleAskShaEvents += item.OnAskSha;
                this.OnRoleAskShanEvents += item.OnAskShan;
                this.OnRoleAskWuxiekejiEvents += item.OnAskWuxiekeji;
                this.OnRoleAskYaoEvents += item.OnAskYao;

            }
            foreach (var item in this.AdditionalSkills)
            {
                this.CurrentLife += item.AddLife;
                this.CurrentDamage += item.AddDamage;
                this.CurrentAttackDistance += item.AddAttackDistance;
                this.CurrentAttackCount += item.AddAttackCount;
                maxDistance = maxDistance > item.AddAttackDistance ? maxDistance : item.AddAttackDistance;
                //事件
                this.OnRoleAskShaEvents += item.OnAskSha;
                this.OnRoleAskShanEvents += item.OnAskShan;
                this.OnRoleAskWuxiekejiEvents += item.OnAskWuxiekeji;
                this.OnRoleAskYaoEvents += item.OnAskYao;
            }
            foreach (var item in this.BaseWeapons)
            {
                this.CurrentLife += item.AddLife;
                this.CurrentDamage += item.AddDamage;
                this.BaseAttackDistance += item.AddAttackDistance;
                this.CurrentAttackDistance = Math.Max(this.CurrentAttackDistance, item.AddAttackDistance);
                //this.CurrentAttackDistance += item.AddAttackDistance;
                this.CurrentAttackCount += item.AddAttackCount;

                //事件
                this.OnRoleAskShaEvents += item.OnAskSha;
                this.OnRoleAskShanEvents += item.OnAskShan;
                this.OnRoleAskWuxiekejiEvents += item.OnAskWuxiekeji;
            }
            foreach (var item in this.AdditionalWeapons)
            {
                this.CurrentLife += item.AddLife;
                this.CurrentDamage += item.AddDamage;
                this.CurrentAttackDistance = Math.Max(this.CurrentAttackDistance, item.AddAttackDistance);
                maxDistance = maxDistance > item.AddAttackDistance ? maxDistance : item.AddAttackDistance;
                this.CurrentAttackCount += item.AddAttackCount;

                //事件
                this.OnRoleAskShaEvents += item.OnAskSha;
                this.OnRoleAskShanEvents += item.OnAskShan;
                this.OnRoleAskWuxiekejiEvents += item.OnAskWuxiekeji;
            }
            this.CurrentAttackDistance = this.BaseAttackDistance + maxDistance;

        }

        public virtual void EquipWeapon(IWeapon wp)
        {
            this.AdditionalWeapons.Add(wp);
            this.SumRoleProperties();
        }

        public virtual void UnEquipWeapon(IWeapon wp)
        {
            this.AdditionalWeapons.Remove(wp);
            this.SumRoleProperties();
        }

        public override string ToString()
        {
            string bwp = "基础武器：" + string.Join("、", this.BaseWeapons.Select(p => p.Name));
            string awp = "装备武器：" + string.Join("、", this.AdditionalWeapons.Select(p => p.Name));

            string bsk = "基础技能：" + string.Join("、", this.BaseSkills.Select(p => p.Name));
            string ask = "附加技能：" + string.Join("、", this.AdditionalSkills.Select(p => p.Name));

            string msg = String.Format("角色名称：{0}\r\n基础血量：{1}\r\n攻击范围:{2}\r\n单回合可攻击次数：{3}\r\n{4}\r\n{5}\r\n{6}\r\n{7}\r\n",
                                            this.Name, this.BaseLife, this.CurrentAttackDistance, this.CurrentAttackCount, bwp, awp, bsk, ask);

            return msg;
        }


    }
}
