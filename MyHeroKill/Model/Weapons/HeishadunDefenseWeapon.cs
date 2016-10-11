using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHeroKill.Model.Weapons
{
    public class HeishadunDefenseWeapon : BaseDefenseWeapon
    {
        public HeishadunDefenseWeapon()
        {
            this.BaseTriggerRate = 0;
            this.StarDeltaRate = 5;
            this.Star = 1;
            this.CanDefenceFenghuolangyan = false;
            this.CanDefenceHeiSha = true;
            this.CanDefenceHongSha = false;
            this.CanDefenceWanjianqifa = false;
            this.TriggerColor = Enums.ECardColors.Black;
        }

        public Enums.ECardColors GetCardColor()
        {
            //TODO:检查牌是颜色
            return Enums.ECardColors.Black;
        }


        public override void OnAskShan()
        {
            //根据概率判断是否能够免伤
            if (this.TriggerColor == this.GetCardColor())
            {
                Random r = new Random();
                int seed = r.Next(1, 101);
                if (seed <= this.TriggerRate)
                {
                    //可以免伤
                    Console.WriteLine("不可以免伤");
                }
                else
                {
                    //不能免伤，需要出闪
                    Console.WriteLine("可以免伤");
                }
            }

        }
    }
}
