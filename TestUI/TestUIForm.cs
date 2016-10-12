using MyHeroKill.Managers;
using MyHeroKill.Model;
using MyHeroKill.Model.Roles;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TestUI
{
    public partial class TestUIForm : Form
    {
        private HostManager hostManager = new HostManager();
        public TestUIForm()
        {
            InitializeComponent();
            this.panelCardOperationButtons.Visible = false;
        }

        private void TestUIForm_Load(object sender, EventArgs e)
        {
            InitRoles();
        }

        void InitRoles()
        {
            //绘制图片
            var rroleA = new XiangyuRole();
            var rroleB = new SongjiangRole();
            var rroleC = new YangyanzhaoRole();

            roleA.Text = rroleA.Name;
            lblLifeA.Text = rroleA.CurrentLife.ToString();
            lblCardNumA.Text = "0";

            roleB.Text = rroleB.Name;
            lblLifeB.Text = rroleB.CurrentLife.ToString();
            lblCardNumB.Text = "0";

            roleC.Text = rroleC.Name;
            lblLifeC.Text = rroleC.CurrentLife.ToString();
            lblCardNumC.Text = "0";

            //通知hostmanager
            Dictionary<int, IRole> dicRoles = new Dictionary<int, IRole>();
            dicRoles.Add(0, rroleA);
            dicRoles.Add(1, rroleB);
            dicRoles.Add(2, rroleC);
            hostManager.RolesPositionDic = dicRoles;

            //发牌
            SendCards(dicRoles);

            //显示当前用户的牌
            ShowCards(dicRoles[2]);

            //刷新其他角色的手牌
            RefreshRolesCards(dicRoles);
        }

        private void RefreshRolesCards(Dictionary<int, IRole> dicRoles)
        {
            lblCardNumA.Text = dicRoles[0].CardsInHand.Count.ToString();
            lblCardNumB.Text = dicRoles[1].CardsInHand.Count.ToString();
            lblCardNumC.Text = dicRoles[2].CardsInHand.Count.ToString();
        }

        private void ShowCardOptionsButton(bool show)
        {
            panelCardOperationButtons.Visible = show;
        }

        private void ShowCards(IRole role)
        {
            int initX = 3;
            foreach (var card in role.CardsInHand)
            {
                var newBtnCard = new Button();
                newBtnCard.Size = new Size(67, 82);
                newBtnCard.Margin = new Padding(3, 3, 3, 3);
                newBtnCard.Text = "";
                newBtnCard.Location = new Point(initX, 11);
                string bgPath = "Images/HandCards/All/" + card.CardGloabalType.ToString() + ".jpg";

                newBtnCard.FlatStyle = FlatStyle.Flat;
                newBtnCard.FlatAppearance.BorderSize = 0;
                newBtnCard.BackgroundImage = Image.FromFile(bgPath);
                newBtnCard.BackgroundImageLayout = ImageLayout.Stretch;
                newBtnCard.BackColor = System.Drawing.Color.Transparent;

                newBtnCard.Click += (object sender, EventArgs e) =>
                {
                    Button curBtn = (Button)sender;
                    int curY = curBtn.Location.Y;
                    if (curY < 11)
                    {
                        curBtn.Location = new Point(curBtn.Location.X, 11);
                        ShowCardOptionsButton(false);
                    }
                    else
                    {
                        curBtn.Location = new Point(curBtn.Location.X, 2);
                        ShowCardOptionsButton(true);
                    }
                };

                Label lbSign = new Label();
                lbSign.Size = new Size(38, 12);
                lbSign.Margin = new Padding(3, 0, 3, 0);
                lbSign.Text = card.GetColorAndSignText();
                lbSign.Location = new Point(6, 2);
                lbSign.Font = new Font("宋体", 10, FontStyle.Bold);
                lbSign.ForeColor = card.GetColor() == Enums.ECardColors.Red ? Color.Red : Color.Black;

                Label lbNumber = new Label();
                lbNumber.Size = new Size(38, 12);
                lbNumber.Margin = new Padding(3, 0, 3, 0);
                lbNumber.Text = card.GetNumberText();
                lbNumber.Location = new Point(6, 18);
                lbNumber.Font = new Font("宋体", 10, FontStyle.Bold);
                lbNumber.ForeColor = card.GetColor() == Enums.ECardColors.Red ? Color.Red : Color.Black;

                newBtnCard.Controls.Add(lbSign);
                newBtnCard.Controls.Add(lbNumber);

                initX += 60;
                panelHandCards.Controls.Add(newBtnCard);

            }
        }

        void SendCards(Dictionary<int, IRole> dicRoles)
        {
            //每人发4张牌
            foreach (var role in dicRoles)
            {
                role.Value.CardsInHand = hostManager.GetCards(4);
            }
        }
    }
}
