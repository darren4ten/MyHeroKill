using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHeroKill.Model
{
    public class Enums
    {
        public enum ECardColorAndSignType
        {
            Any = 0,//任意类型
            MeiHua,
            FangPian,
            HeiTao,
            HongTao
        }

        public enum ECardGloabalType
        {
            Sha,//30
            Shan,//15
            Yao,//8
            Wanjianqifa,//1
            Xiuyangshengxi,//1
            Wugufengdeng,//2
            Huadiweilao,//3
            Shoupenglei,//2
            Fudichouxin,//6
            Jiedaosharen,//2
            Juedou,//3
            Fenghuolangyan,//3
            Wuxiekeji,//4
            Wuzhongshengyou,//4
            Tanlangquwu,//5
            Jingongma,//+1,3
            Fangyuma,//-1,3
            Yuruyi,//2
            Yuchangjian,//9
            Langyabang,//1
            Luyeqiang,//1
            Longlingdao,//1
            Bawanggong,//1
            Hufu,//2
            Bolangchui,//1
        }
    }
}
