using MyHeroKill.Model.Roles;
using MyHeroKill.Model.Weapons;
using MyHeroKill.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MyHeroKill
{
    class Program
    {
        static void Main(string[] args)
        {

            TestRoles();
            Console.Read();
        }

        static void GetAllCardType()
        {
            var cardService = new CardService();
            var cards = cardService.GetAllCard();
        }

        static void TestRoles()
        {
            //YangyanzhaoRole yyz = new YangyanzhaoRole();
            //SongjiangRole sj = new SongjiangRole();
            //BianqueRole bq = new BianqueRole();
            //XiangyuRole xy = new XiangyuRole();
            //GuanyuRole gy = new GuanyuRole();
            //Console.WriteLine(yyz.ToString());
            //Console.WriteLine(sj.ToString());
            //Console.WriteLine(bq.ToString());
            //Console.WriteLine(xy.ToString());
            //Console.WriteLine(gy.ToString());
            //bq.TriggerOnRoleAskYaoEvents();

            ////给宋江装备上玉如意、龙鳞刀
            //YuruyiWeapon wyry = new YuruyiWeapon();
            //Longlindao wlld = new Longlindao();
            //FangyumaWeapon wfym=new FangyumaWeapon();
            //sj.EquipWeapon(wyry);
            //sj.EquipWeapon(wlld);
            //Console.WriteLine(sj);
            ////给关羽装上龙鳞刀
            //gy.EquipWeapon(wlld);
            //gy.EquipWeapon(wfym);
            //Console.WriteLine(gy);

            //Longlindao wlld1 = new Longlindao();
            //SongjiangRole sj1 = new SongjiangRole();
            ////sj1.EquipWeapon(wlld1);
            //Console.WriteLine(sj1);

            YuruyiWeapon wyry = new YuruyiWeapon();
            Longlindao wlld = new Longlindao();
            FangyumaWeapon wfym = new FangyumaWeapon();
            HufuWeapon whf = new HufuWeapon();
            GuanyuRole gy = new GuanyuRole();
            Console.WriteLine(gy);
            gy.TriggerOnRoleAskShanEvents();
            gy.EquipWeapon(wyry);
            gy.EquipWeapon(wlld);
            gy.EquipWeapon(wfym);
            Console.WriteLine(gy);
            gy.TriggerOnRoleAskShanEvents();
            gy.EquipWeapon(whf);
            Console.WriteLine(gy);
            gy.UnEquipWeapon(wyry);
            Console.WriteLine(gy);
            gy.TriggerOnRoleAskShanEvents();

        }
        static void TestCard()
        {
            var cardService = new CardService();
            for (int i = 0; i < 5; i++)
            {
                var ret = cardService.GetNewCards();
                Print(ret);
                Console.WriteLine("_______________");
                Thread.Sleep(1000);
            }
        }
        static void Print(int[] arr)
        {
            Console.WriteLine(string.Join(",", arr));
        }
    }
}
