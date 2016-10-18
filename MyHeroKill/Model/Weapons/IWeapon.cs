using MyHeroKill.Managers;
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
        int PositionOfWeaponList { get; set; }
        string ImgUrl { get; set; }
        int BaseDamage { get; set; }
        int BaseLife { get; set; }
        int BaseAttackDistance { get; set; }

        int AddDamage { get; set; }
        int AddLife { get; set; }
        int AddAttackDistance { get; set; }
        int AddDefenceDistance { get; set; }
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

        void OnBeforeSha(HandCardManager handCardManager);
        void OnAfterSha(HandCardManager handCardManager, bool isSuccess);

        void OnBeforeShan(HandCardManager handCardManager);

        void OnAfterShan(HandCardManager handCardManager, bool isSuccess);

        void OnAskSha(HandCardManager handCardManager);
        void OnAskShan(HandCardManager handCardManager);
        void OnAskJuedou(HandCardManager handCardManager);
        void OnAskWuxiekeji(HandCardManager handCardManager);

        /// <summary>
        /// 响应杀之后的事件,比如三板斧，一张闪则各掉一滴血，两闪则我方掉血，没闪则敌方掉两血
        /// </summary>
        /// <param name="handCardManager"></param>
        /// <param name="defenseCardContainer"></param>
        /// <returns>是否可以继续执行别的OnReplySha事件</returns>
        bool OnReplySha(HandCardManager handCardManager, int fromUserIndex, AttackCardModel attackCardModel, DefenseCardModel defenseCardContainer);

        /// <summary>
        /// 血量改变的时候触发
        /// </summary>
        /// <param name="handCardManager"></param>
        bool OnLifeChange(int deltaLife, HandCardManager handCardManager);
    }
}
