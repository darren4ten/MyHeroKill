using MyHeroKill.Managers;
using MyHeroKill.Model.Skills;
using MyHeroKill.Model.Wepons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHeroKill.Model
{
    public interface IRole
    {
        /// <summary>
        /// 角色在牌堆中的位置
        /// </summary>
        int IndexOfRoles { get; set; }
        string Name { get; set; }
        string ImgUrl { get; set; }
        MyHeroKill.Model.Enums.ERoleCampType CampType { get; set; }
        List<Card> CardsInHand { get; set; }
        HandCardManager CurrentHandCardManager { get; set; }
        /// <summary>
        /// 皮肤ID
        /// </summary>
        int SkinId { get; set; }
        int BaseDamage { get; set; }
        int BaseLife { get; set; }
        int BaseAttackDistance { get; set; }
        int BaseDefenseDistance { get; set; }
        int BaseAttackCount { get; set; }
        List<ISkill> BaseSkills { get; set; }
        List<IWeapon> BaseWeapons { get; set; }
        List<ISkill> AdditionalSkills { get; set; }
        List<IWeapon> AdditionalWeapons { get; set; }

        int CurrentDamage { get; set; }
        int CurrentLife { get; set; }
        int CurrentAttackDistance { get; set; }
        int CurrentDefenceDistance { get; set; }
        int CurrentAttackCount { get; set; }
        int MaxLife { get; set; }
        /// <summary>
        /// 血量变动，比如掉血、回血
        /// </summary>
        /// <param name="deltaLife">血量变化值，可为负数</param>
        void OnLifeChange(int deltaLife);

        void OnRoleDying();
        void OnRolePlaying();
        void OnRoleIdle();
        /// <summary>
        /// 加装备
        /// </summary>
        void EquipWeapon(IWeapon wp);
        /// <summary>
        /// 下装备，如被釜底抽薪
        /// </summary>
        void UnEquipWeapon(IWeapon wp);
    }
}
