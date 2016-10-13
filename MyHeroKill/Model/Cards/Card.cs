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

        /// <summary>
        /// 卡牌的攻击范围
        /// </summary>
        public int AttackDistance { get; set; }

        public MyHeroKill.Model.Enums.ECardGloabalType CardGloabalType { get; set; }

        /// <summary>
        /// 是否是选中状态
        /// </summary>
        public bool IsSelected { get; set; }
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

        /// <summary>
        /// 获取牌的颜色
        /// </summary>
        /// <returns></returns>
        public MyHeroKill.Model.Enums.ECardColors GetColor()
        {
            if (this.Type == Enums.ECardColorAndSignType.HeiTao || this.Type == Enums.ECardColorAndSignType.MeiHua)
            {
                return Enums.ECardColors.Black;
            }
            else
            {
                return Enums.ECardColors.Red;
            }
        }

        /// <summary>
        /// 获取牌的花色字符，如♠♥♦♣
        /// </summary>
        /// <returns></returns>
        public string GetColorAndSignText()
        {
            switch (this.Type)
            {
                case Enums.ECardColorAndSignType.Any:
                    return "";
                case Enums.ECardColorAndSignType.MeiHua:
                    return "♣";
                case Enums.ECardColorAndSignType.FangPian:
                    return "♦";
                case Enums.ECardColorAndSignType.HeiTao:
                    return "♠";
                case Enums.ECardColorAndSignType.HongTao:
                    return "♠";
                default:
                    return "";
            }
        }

        /// <summary>
        /// 获取卡牌的文字显示，如K
        /// </summary>
        /// <returns></returns>
        public string GetNumberText()
        {
            switch (this.Number)
            {
                case 1:
                    return "A";
                case 2:
                case 3:
                case 4:
                case 5:
                case 6:
                case 7:
                case 8:
                case 9:
                case 10:
                    return this.Number.ToString();
                case 11:
                    return "J";
                case 12:
                    return "Q";
                case 13:
                    return "K";
                default:
                    return "";
            }
        }

    }
}
