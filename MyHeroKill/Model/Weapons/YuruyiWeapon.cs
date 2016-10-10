using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHeroKill.Model.Weapons
{
    public class YuruyiWeapon : IDefenseWeapon
    {

        public int TriggerRate
        {
            get { return 100; }
        }

        public Enums.ECardColors TriggerColor
        {
            get { return Enums.ECardColors.Red; }
        }

        public bool CanDefenceHeiSha
        {
            get { return false; }
        }

        public bool CanDefenceHongSha
        {
            get { return false; }
        }

        public bool CanDefenceFenghuolangyan
        {
            get { return false; }
        }

        public bool CanDefenceWanjianqifa
        {
            get { return false; }
        }


        public bool CanDefenceSha
        {
            get { return true; }
        }
    }
}
