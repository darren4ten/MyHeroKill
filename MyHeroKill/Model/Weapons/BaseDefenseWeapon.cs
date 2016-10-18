using MyHeroKill.Model.Wepons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHeroKill.Model.Weapons
{
    public abstract class BaseDefenseWeapon : IDefenseWeapon, IWeapon
    {
        #region 属性
        public int Level
        {
            get;
            set;
        }
        public int Star { get; set; }
        public int StarDeltaRate { get; set; }
        public int BaseTriggerRate
        {
            get;
            set;
        }

        public int TriggerRate
        {
            get { return BaseTriggerRate + Level * Star * StarDeltaRate; }

        }

        public Enums.ECardColors TriggerColor
        {
            get;
            set;
        }

        public bool CanDefenceHeiSha
        {
            get;
            set;
        }

        public bool CanDefenceHongSha
        {
            get;
            set;
        }

        public bool CanDefenceFenghuolangyan
        {
            get;
            set;
        }

        public bool CanDefenceWanjianqifa
        {
            get;
            set;
        }
        #endregion

        #region IWeapon的属性
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

        public int PositionOfWeaponList
        {
            get;
            set;
        }

        public int PositionOfSkillList
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

        public int AddAttackCount
        {
            get;
            set;
        }
        public int AddDefenceDistance
        {
            get;
            set;
        }
        public bool CanProvideSha
        {
            get;
            set;
        }

        public bool CanProvideShan
        {
            get;
            set;
        }

        public bool CanProvideJuedou
        {
            get;
            set;
        }

        public bool CanProvideWuxiekeji
        {
            get;
            set;
        }
        #endregion

        public BaseDefenseWeapon()
        {
            #region IWeapon

            this.Name = "防具";
            this.IndexOfCards = 0;
            this.BaseLife = 0;
            this.BaseDamage = 0;
            this.BaseAttackDistance = 1;
            this.AddAttackDistance = 1;
            this.AddDefenceDistance = 0;
            this.AddDamage = 0;
            this.AddLife = 0;
            this.AddAttackCount = 0;
            this.CanProvideJuedou = false;
            this.CanProvideSha = false;
            this.CanProvideShan = false;
            this.CanProvideWuxiekeji = false;

            #endregion


            #region IDefenseWeapon

            this.BaseTriggerRate = 0;
            this.StarDeltaRate = 5;
            this.Star = 1;
            this.CanDefenceFenghuolangyan = false;
            this.CanDefenceHeiSha = false;
            this.CanDefenceHongSha = false;
            this.CanDefenceWanjianqifa = false;
            this.TriggerColor = Enums.ECardColors.Any;

            #endregion
        }


        public virtual void OnBeforeSha()
        {

        }

        public virtual void OnAfterSha(bool isSuccess)
        {

        }

        public virtual void OnBeforeShan()
        {

        }

        public virtual void OnAfterShan(bool isSuccess)
        {

        }

        public virtual void OnAskSha()
        {

        }

        public virtual void OnAskShan()
        {

        }

        public virtual void OnAskJuedou()
        {

        }

        public virtual void OnAskWuxiekeji()
        {

        }



        public void OnBeforeSha(Managers.HandCardManager handCardManager)
        {
        }

        public void OnAfterSha(Managers.HandCardManager handCardManager, bool isSuccess)
        {
        }

        public void OnBeforeShan(Managers.HandCardManager handCardManager)
        {
        }

        public void OnAfterShan(Managers.HandCardManager handCardManager, bool isSuccess)
        {
        }

        public void OnAskSha(Managers.HandCardManager handCardManager)
        {
        }

        public void OnAskShan(Managers.HandCardManager handCardManager)
        {
        }

        public void OnAskJuedou(Managers.HandCardManager handCardManager)
        {
        }

        public void OnAskWuxiekeji(Managers.HandCardManager handCardManager)
        {
        }


        public virtual bool OnReplySha(Managers.HandCardManager handCardManager, int fromUserIndex, AttackCardModel attackCardModel, DefenseCardModel defenseCardContainer)
        {
            return true;
        }

        public virtual bool OnLifeChange(int deltaLife, Managers.HandCardManager handCardManager)
        {
            return true;
        }
    }
}
