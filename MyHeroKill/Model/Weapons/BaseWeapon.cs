using MyHeroKill.Model.Wepons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHeroKill.Model.Weapons
{
    public abstract class BaseWeapon : IWeapon
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
        /// <summary>
        /// 装备位置：0-防御马，1-进攻马，2-防具，3-武器
        /// </summary>
        public int PositionOfWeaponList { get; set; }

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
        public int AddDefenceDistance { get; set; }
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

        /// <summary>
        /// 装备位置：0-防御马，1-进攻马，2-防具，3-武器
        /// </summary>
        public BaseWeapon()
        {
            this.Name = "武器";
            this.IndexOfCards = 0;

            this.PositionOfWeaponList = 0;
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
        }

        public virtual void OnAfterSha(bool isSuccess)
        {
        }

        public virtual void OnAfterShan(bool isSuccess)
        {
        }


        public virtual void OnBeforeSha()
        {

        }

        public virtual void OnBeforeShan()
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


        public bool OnReplySha(Managers.HandCardManager handCardManager, int fromUserIndex, AttackCardModel attackCardModel, DefenseCardModel defenseCardContainer)
        {
            return true;
        }

        public bool OnLifeChange(int deltaLife, Managers.HandCardManager handCardManager)
        {
            return true;
        }
    }
}
