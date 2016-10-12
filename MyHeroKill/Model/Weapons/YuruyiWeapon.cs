using MyHeroKill.Model.Wepons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHeroKill.Model.Weapons
{
    public class YuruyiWeapon : BaseWeapon
    {

        public YuruyiWeapon()
        {
            this.Name = "玉如意";
            this.IndexOfCards = 0;
            this.PositionOfWeaponList = 2;
            this.BaseLife = 0;
            this.BaseDamage = 0;
            this.BaseAttackDistance = 0;
            this.AddAttackDistance = 2;
            this.AddDamage = 0;
            this.AddLife = 0;
            this.AddAttackCount = 0;
            this.CanProvideJuedou = false;
            this.CanProvideSha = false;
            //能提供闪
            this.CanProvideShan = true;
            this.CanProvideWuxiekeji = false;
        }

        public override void OnAskShan()
        {
            //询问用户是否需要用玉如意出闪
            Console.WriteLine("是否用玉如意？");

            //判定是否为红牌
            Console.WriteLine("正在判断是为红牌");

            //如果是红牌则什么不做
        }
    }
}
