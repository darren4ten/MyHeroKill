using MyHeroKill.Managers;
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

        public List<Card> CardsInHand { get; set; }

        public int SkinId
        {
            get;
            set;
        }
        /// <summary>
        /// 角色状态，是机器人、人类待机、人类正常、人类掉线
        /// </summary>
        public Enums.ERoleStatus RoleStatus
        {
            get;
            set;
        }

        public Enums.ERoleCampType CampType
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

        /// <summary>
        /// 基础防御距离
        /// </summary>
        public int BaseDefenseDistance
        {
            get;
            set;
        }

        /// <summary>
        /// 当前防御距离
        /// </summary>
        public int CurrentDefenceDistance
        {
            get;
            set;
        }

        /// <summary>
        /// 当前的HandCardManager
        /// </summary>
        public Managers.HandCardManager CurrentHandCardManager
        {
            get;
            set;
        }

        #endregion

        public BaseRole()
        {
            this.IndexOfRoles = 1;
            this.CampType = Enums.ERoleCampType.Any;
            this.RoleStatus = Enums.ERoleStatus.AI;
            this.Name = "英雄";
            this.SkinId = 0;
            this.BaseDamage = 1;
            this.BaseLife = 3;
            this.BaseAttackDistance = 1;
            this.BaseAttackCount = 1;
            this.BaseDefenseDistance = 0;
            this.CardsInHand = new List<Card>();
            this.BaseSkills = new List<Skills.ISkill>();
            this.BaseWeapons = new List<Wepons.IWeapon>();
            this.AdditionalSkills = new List<Skills.ISkill>();
            this.AdditionalWeapons = new List<Wepons.IWeapon>();
            this.CurrentDamage = this.BaseDamage;
            this.CurrentLife = this.BaseLife;
            this.MaxLife = this.CurrentLife;
            this.CurrentDefenceDistance = this.BaseDefenseDistance;
            this.CurrentAttackDistance = this.BaseAttackDistance;
            this.CurrentAttackCount = this.BaseAttackCount;
            this.CurrentHandCardManager = new Managers.HandCardManager();
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

        public virtual bool OnReplySha(Managers.HandCardManager handCardManager, DefenseCardModel defenseCardContainer)
        {

            return true;
        }

        /// <summary>
        /// 血量变化事件
        /// </summary>
        /// <param name="deltaLife"></param>
        /// <param name="handCardManager"></param>
        public virtual void OnLifeChange(int deltaLife, Managers.HandCardManager handCardManager)
        {
            this.CurrentLife += deltaLife;
            this.CurrentLife = this.CurrentLife > this.MaxLife ? this.MaxLife : this.CurrentLife;
            //血量小于1则求药
            if (this.CurrentLife < 1)
            {
                this.TriggerOnRoleAskYaoEvents();
            }
        }

        public delegate void RoleEvents();
        public event RoleEvents OnRoleAskShaEvents;
        public event RoleEvents OnRoleAskShanEvents;
        public event RoleEvents OnRoleAskWuxiekejiEvents;
        public event RoleEvents OnRoleAskYaoEvents;
        public event RoleEvents OnRoleAskJuedouEvents;

        public delegate bool RoleEventsDefense(HandCardManager handCardManager, DefenseCardModel defenseModel);
        public event RoleEventsDefense OnReplyShaEvents;

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
        public virtual void TriggerOnReplyShaEvents(DefenseCardModel defense)
        {
            this.OnReplyShaEvents(this.CurrentHandCardManager, defense);
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
                this.CurrentDefenceDistance += item.AddDefenceDistance;
                //事件
                this.OnRoleAskShaEvents += item.OnAskSha;
                this.OnRoleAskShanEvents += item.OnAskShan;
                this.OnRoleAskWuxiekejiEvents += item.OnAskWuxiekeji;
                this.OnRoleAskYaoEvents += item.OnAskYao;
                //this.OnReplyShaEvents += item.OnReplySha;

            }
            foreach (var item in this.AdditionalSkills)
            {
                this.CurrentLife += item.AddLife;
                this.CurrentDamage += item.AddDamage;
                this.CurrentAttackDistance += item.AddAttackDistance;
                this.CurrentAttackCount += item.AddAttackCount;
                this.CurrentDefenceDistance += item.AddDefenceDistance;
                maxDistance = maxDistance > item.AddAttackDistance ? maxDistance : item.AddAttackDistance;
                //事件
                this.OnRoleAskShaEvents += item.OnAskSha;
                this.OnRoleAskShanEvents += item.OnAskShan;
                this.OnRoleAskWuxiekejiEvents += item.OnAskWuxiekeji;
                this.OnRoleAskYaoEvents += item.OnAskYao;
                //this.OnReplyShaEvents += item.OnReplySha;
            }
            foreach (var item in this.BaseWeapons)
            {
                this.CurrentLife += item.AddLife;
                this.CurrentDamage += item.AddDamage;
                this.BaseAttackDistance += item.AddAttackDistance;
                this.CurrentAttackDistance = Math.Max(this.CurrentAttackDistance, item.AddAttackDistance);
                this.CurrentDefenceDistance += item.AddDefenceDistance;
                this.CurrentAttackCount += item.AddAttackCount;

                //事件
                this.OnRoleAskShaEvents += item.OnAskSha;
                this.OnRoleAskShanEvents += item.OnAskShan;
                this.OnRoleAskWuxiekejiEvents += item.OnAskWuxiekeji;
                //this.OnReplyShaEvents += item.OnReplySha;
            }
            foreach (var item in this.AdditionalWeapons)
            {
                this.CurrentLife += item.AddLife;
                this.CurrentDamage += item.AddDamage;
                this.CurrentDefenceDistance += item.AddDefenceDistance;
                this.CurrentAttackDistance = Math.Max(this.CurrentAttackDistance, item.AddAttackDistance);
                maxDistance = maxDistance > item.AddAttackDistance ? maxDistance : item.AddAttackDistance;
                this.CurrentAttackCount += item.AddAttackCount;

                //事件
                this.OnRoleAskShaEvents += item.OnAskSha;
                this.OnRoleAskShanEvents += item.OnAskShan;
                this.OnRoleAskWuxiekejiEvents += item.OnAskWuxiekeji;
                // this.OnReplyShaEvents += item.OnReplySha;
            }
            this.CurrentAttackDistance = Math.Max(this.BaseAttackDistance, maxDistance);

        }

        protected void AddWeapon(IWeapon wp)
        {
            Console.WriteLine("。。。加装备-" + wp.Name);
            this.CurrentLife += wp.AddLife;
            this.CurrentDamage += wp.AddDamage;
            this.CurrentDefenceDistance += wp.AddDefenceDistance;
            if (wp.PositionOfWeaponList == 3)
            {
                //检查是否有进攻马，最后减去默认的距离1
                var jingongma = this.AdditionalWeapons.FirstOrDefault(p => p.PositionOfWeaponList == 1);
                this.CurrentAttackDistance = this.BaseAttackDistance + (jingongma == null ? 0 : 1) + wp.AddAttackDistance - 1;
            }

            this.CurrentAttackCount += wp.AddAttackCount;
            this.AdditionalWeapons.Add(wp);
            //事件
            this.OnRoleAskShaEvents += wp.OnAskSha;
            this.OnRoleAskShanEvents += wp.OnAskShan;
            this.OnRoleAskWuxiekejiEvents += wp.OnAskWuxiekeji;
            //this.OnReplyShaEvents += wp.OnReplySha;
        }

        public virtual void EquipWeapon(IWeapon wp)
        {
            var existsWeapon = this.AdditionalWeapons.FirstOrDefault(p => p.PositionOfWeaponList == wp.PositionOfWeaponList);
            if (existsWeapon != null)
            {
                this.UnEquipWeapon(existsWeapon);
            }
            this.AddWeapon(wp);
        }

        public virtual void UnEquipWeapon(IWeapon wp)
        {
            Console.WriteLine("。。。卸掉装备-" + wp.Name);
            //去除该武器所加的所有属性
            this.CurrentLife -= wp.AddLife;
            this.CurrentDamage -= wp.AddDamage;
            this.CurrentDefenceDistance -= wp.AddDefenceDistance;
            this.CurrentAttackDistance = Math.Max(this.CurrentAttackDistance - wp.AddAttackDistance, 1);

            //如果是进攻武器，则直接重新计算距离
            if (wp.PositionOfWeaponList == 3)
            {
                //检查是否有进攻马，最后减去默认的距离1
                var jingongma = this.AdditionalWeapons.FirstOrDefault(p => p.PositionOfWeaponList == 1);
                this.CurrentAttackDistance = this.BaseAttackDistance + (jingongma == null ? 0 : 1);
            }

            this.CurrentAttackCount -= wp.AddAttackCount;
            //事件
            this.OnRoleAskShaEvents -= wp.OnAskSha;
            this.OnRoleAskShanEvents -= wp.OnAskShan;
            this.OnRoleAskWuxiekejiEvents -= wp.OnAskWuxiekeji;
            //this.OnReplyShaEvents -= wp.OnReplySha;

            this.AdditionalWeapons.Remove(wp);
        }

        public override string ToString()
        {
            string bwp = "基础武器：" + string.Join("、", this.BaseWeapons.Select(p => p.Name));
            string awp = "装备武器：" + string.Join("、", this.AdditionalWeapons.Select(p => p.Name));

            string bsk = "基础技能：" + string.Join("、", this.BaseSkills.Select(p => p.Name));
            string ask = "附加技能：" + string.Join("、", this.AdditionalSkills.Select(p => p.Name));

            string msg = String.Format("角色名称：{0}\r\n基础血量：{1}\r\n攻击范围:{2}\r\n防御距离：{8}\r\n单回合可攻击次数：{3}\r\n{4}\r\n{5}\r\n{6}\r\n{7}\r\n",
                                            this.Name, this.BaseLife, this.CurrentAttackDistance, this.CurrentAttackCount, bwp, awp, bsk, ask, this.CurrentDefenceDistance);

            return msg;
        }



        public bool OnReplySha(HandCardManager handCardManager, int fromUserIndex, AttackCardModel attackCardModel, DefenseCardModel defenseCardModel)
        {
            IRole role = this.CurrentHandCardManager.CurrentHostManager.GetRole(fromUserIndex);
            if (defenseCardModel.IsDefensed)
            {
                //被抵挡，什么都不做
            }
            else
            {
                //出了闪？
                if (defenseCardModel.DefenseCardContainers != null && defenseCardModel.DefenseCardContainers.Count > 0)
                {
                    //TODO:检查杀被闪掉之后是否强制命中，如博浪锤，盘龙棍

                }
                else
                {
                    //掉血
                    role.CurrentHandCardManager.TiggerChangeLife(fromUserIndex, -1);
                }
            }
            return true;
        }
    }
}
