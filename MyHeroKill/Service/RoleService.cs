using MyHeroKill.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHeroKill.Service
{
    public class RoleService
    {
        public IRole GetRole(int index)
        {
            return null;
        }

        public List<IRole> GetAll()
        {
            //---------------------------------------------------
            //【君】：
            //[常见]：[刘彻][李煜][朱元璋][李自成][吕雉][嬴政][铁木真]
            //        [刘邦][赵匡胤][勾践][项羽][李世民][武则天][慕容][曹操][陈胜]
            //[不常见]：[孙权][杨广][康熙][赵雍] [埃及艳后][拿破仑][凯撒]

            //【臣】
            //[常见]：[狄仁杰][张飞][墨子][诸葛亮][程咬金][商鞅][虞姬][刘伯温]
            //        [岳飞][韩信][褒姒][花木兰][关羽][杨延昭][澹台名][秦琼][赵飞燕]
            //[不常见]：[廉颇][孙武][杨玉环][罗成][罗宾汉][贞德][织田信长][明成皇后][白起][穆桂英][王昭君]

            //【民】
            //[常见]：[张三丰][林冲][李白][小乔][荆轲][任桓之][鲁智深]
            //        [时迁][李逵][武松][宋江][西施][扁鹊][陈圆圆][李师师]
            //[不常见]：[潘安][鲁班][貂蝉][唐伯虎][伯乐][罗宾汉][南丁格尔][斯巴达克][福尔摩斯][穆桂英][鬼谷子]
            //---------------------------------------------------

            List<IRole> list = new List<IRole>();
            //list.Add()
            return list;
        }
    }
}
