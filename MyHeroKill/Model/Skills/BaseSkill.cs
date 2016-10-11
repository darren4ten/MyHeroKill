using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHeroKill.Model.Skills
{
    public abstract class BaseSkill : ISkill
    {
        #region 属性
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
        public Enums.ESkillType SkillType
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
        public bool CanProvideYao
        {
            get;
            set;
        }
        #endregion

        public BaseSkill()
        {
            this.Name = "技能";
            this.AddAttackDistance = 0;
            this.AddDamage = 0;
            this.AddLife = 0;
            this.AddAttackCount = 0;
            this.CanProvideJuedou = false;
            this.CanProvideSha = false;
            this.CanProvideShan = false;
            this.CanProvideWuxiekeji = false;
            this.CanProvideYao = false;
            this.SkillType = Enums.ESkillType.Any;
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
        public virtual void OnAskYao()
        {
        }

        /// <summary>
        /// 技能激活之后
        /// </summary>
        public virtual void OnSkillActive()
        {

        }
    }
}
