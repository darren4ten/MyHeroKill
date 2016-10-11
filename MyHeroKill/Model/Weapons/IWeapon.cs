using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHeroKill.Model.Wepons
{
    public interface IWeapon
    {
        string Name { get; set; }
        /// <summary>
        /// 在牌堆中的位置
        /// </summary>
        int IndexOfCards { get; set; }
        string ImgUrl { get; set; }
        int BaseDamage { get; set; }
        int BaseLife { get; set; }
        int BaseAttackDistance { get; set; }

        int AddDamage { get; set; }
        int AddLife { get; set; }
        int AddAttackDistance { get; set; }
        /// <summary>
        /// 增加单回合杀的次数
        /// </summary>
        int AddAttackCount { get; set; }

        bool CanProvideSha { get; set; }
        bool CanProvideShan { get; set; }
        bool CanProvideJuedou { get; set; }
        bool CanProvideWuxiekeji { get; set; }

        void OnBeforeSha();
        void OnAfterSha(bool isSuccess);


        void OnBeforeShan();

        void OnAfterShan(bool isSuccess);

        void OnAskSha();
        void OnAskShan();
        void OnAskJuedou();
        void OnAskWuxiekeji();
    }
}
