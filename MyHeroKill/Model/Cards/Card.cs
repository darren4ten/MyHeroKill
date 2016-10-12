using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHeroKill.Model
{
    /// <summary>
    /// 手牌
    /// </summary>
    public class Card
    {
        /// <summary>
        /// 卡牌名称
        /// </summary>
        public string Name { get; set; }
        public string ImgUrl { get; set; }

        /// <summary>
        /// 卡牌类型
        /// </summary>
        public MyHeroKill.Model.Enums.ECardColorAndSignType Type { get; set; }

        /// <summary>
        /// 数值，比如A=1，2=2，J=11
        /// </summary>
        public int Number { get; set; }

        /// <summary>
        /// 在牌堆中的序号
        /// </summary>
        public int IndexInCards { get; set; }

        #region Is属性

        #region 普通牌
        /// <summary>
        /// 是杀
        /// </summary>
        public bool IsSha { get; set; }
        public bool IsShan { get; set; }
        public bool IsYao { get; set; }
        #endregion

        #region 锦囊牌
        /// <summary>
        /// 是杀
        /// </summary>
        public bool IsWuxiekeji { get; set; }
        public bool IsHuadiweilao { get; set; }
        public bool IsJiedaosharen { get; set; }
        public bool IsWugufengdeng { get; set; }
        public bool IsWuzhongshengyou { get; set; }
        /// <summary>
        /// 修养声息
        /// </summary>
        public bool IsXiuyangshengxi { get; set; }
        public bool IsFenghuolangyang { get; set; }
        public bool IsWanjianqifa { get; set; }
        public bool IsTanlangquwu { get; set; }
        public bool IsFudichouxin { get; set; }
        public bool IsJuedou { get; set; }
        public bool IsShoupenglei { get; set; }
        #endregion

        #region 装备牌

        #region 武器
        public bool IsHufu { get; set; }
        public bool IsLonglindao { get; set; }
        public bool IsPanlonggun { get; set; }
        public bool IsYuchangjian { get; set; }
        public bool IsBolangchui { get; set; }
        public bool IsLangyabang { get; set; }
        public bool IsBawanggong { get; set; }
        public bool IsLuyeqiang { get; set; }

        #endregion

        #region 防具
        public bool IsYuruyi { get; set; }
        public bool IsFangyuma { get; set; }
        public bool IsJingongma { get; set; }

        #endregion

        #endregion

        #endregion

    }
}
