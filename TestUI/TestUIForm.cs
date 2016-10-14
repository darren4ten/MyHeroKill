using MyHeroKill.Managers;
using MyHeroKill.Model;
using MyHeroKill.Model.Roles;
using System;
using System.Collections;
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
            hostManager.Init(dicRoles, 2, 2);

            //发牌
            SendCards(dicRoles);

            //显示当前用户的牌
            ShowCards(dicRoles[2]);

            //刷新其他角色的手牌
            RefreshRolesCards(dicRoles);

            rroleC.CurrentHandCardManager.CurrentIndex = 2;
            rroleC.CurrentHandCardManager.CurrentRole = rroleC;
        }

        private void RefreshRolesCards(Dictionary<int, IRole> dicRoles)
        {
            lblCardNumA.Text = dicRoles[0].CardsInHand.Count.ToString();
            lblCardNumB.Text = dicRoles[1].CardsInHand.Count.ToString();
            lblCardNumC.Text = dicRoles[2].CardsInHand.Count.ToString();
        }

        private void ShowCardOptionsButton()
        {
            var cHandCardManager = this.hostManager.GetRole(2).CurrentHandCardManager;
            if (cHandCardManager.CurrentRole.CardsInHand.Count(p => p.IsSelected) == 1)
            {
                var curCard = cHandCardManager.CurrentRole.CardsInHand.First(p => p.IsSelected);
                //获取选定的牌
                if (!cHandCardManager.IsNeedSelectTargets(curCard))
                {
                    //这张牌可以主动出才可以出
                    panelCardOperationButtons.Visible = cHandCardManager.CanActiveHandout(curCard);
                    if (cHandCardManager.CanActiveHandout(curCard))
                    {
                        panelCardOperationButtons.Visible = true;
                        //this.handCardManager.IsSelectingTarget = false;
                    }
                    else
                    {

                    }
                }
                else
                {
                    //需要选定目标
                    panelCardOperationButtons.Visible = false;
                    //this.handCardManager.IsSelectingTarget = true;
                }
            }
            else
            {
                panelCardOperationButtons.Visible = false;
                // this.handCardManager.IsSelectingTarget = false;
            }

        }

        private void ShowCards(IRole role)
        {
            var cHandCardManager = this.hostManager.GetRole(2).CurrentHandCardManager;
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
                        card.IsSelected = false;
                        //如果取消出牌则清空选中目标
                        cHandCardManager.CleanTargets();
                        RefreshSelectedTargetsStatus();
                        RefreshAttackableTargetStatus();
                    }
                    else
                    {
                        curBtn.Location = new Point(curBtn.Location.X, 2);
                        card.IsSelected = true;
                        //准备出牌时候检查攻击范围
                        if (cHandCardManager.GetHandoutCard() != null)
                        {

                            RefreshAttackableTargetStatus(card.AttackDistance);

                        }
                        else
                        {
                            //选了多张牌，如果是芦叶枪这种辅助攻击则TODO
                            RefreshAttackableTargetStatus();
                        }
                    }

                    ShowCardOptionsButton();
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
                lbNumber.Location = new Point(6, 15);
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


        private void btnHandout_Click(object sender, EventArgs e)
        {
            var cHandCardManager = this.hostManager.GetRole(2).CurrentHandCardManager;
            if (cHandCardManager.IsAttack)
            {
                //主动出牌
                cHandCardManager.AttackHandOut(this.hostManager);

            }
            else
            {
                //被动出牌
            }
        }

        //角色选中事件
        private void roleB_Click(object sender, EventArgs e)
        {
            var cHandCardManager = this.hostManager.GetRole(2).CurrentHandCardManager;
            int maxSelectCount = cHandCardManager.GetCanSelectedTargetCount();
            //如果当前有正要出的牌，则表示选中，否则无动作
            if (maxSelectCount > 0)
            {
                var curRole = this.hostManager.GetRole(1);
                //如果当前角色是选中的，则高亮，否则灰掉
                cHandCardManager.AddTarget(curRole, maxSelectCount);
                RefreshSelectedTargetsStatus();
            }
            else
            {
                //btnRoleStatusA.BackColor = Color.Gray;
            }

        }

        private void roleA_Click(object sender, EventArgs e)
        {
            var cHandCardManager = this.hostManager.GetRole(2).CurrentHandCardManager;
            int maxSelectCount = cHandCardManager.GetCanSelectedTargetCount();
            //如果当前有正要出的牌，则表示选中，否则无动作
            if (maxSelectCount > 0)
            {
                var curRole = this.hostManager.GetRole(0);
                //如果当前角色是选中的，则高亮，否则灰掉
                cHandCardManager.AddTarget(curRole, maxSelectCount);
                RefreshSelectedTargetsStatus();
            }
            else
            {
                //btnRoleStatusA.BackColor = Color.Gray;
            }
        }

        #region 刷新界面

        /// <summary>
        /// 刷新选中状态
        /// </summary>
        void RefreshSelectedTargetsStatus()
        {
            var cHandCardManager = this.hostManager.GetRole(2).CurrentHandCardManager;
            if (cHandCardManager.ContainsRoleInTargets(this.hostManager.GetRole(0)))
            {
                btnRoleStatusA.BackColor = Color.Red;
            }
            else
            {
                btnRoleStatusA.BackColor = Color.Gray;
            }

            if (cHandCardManager.ContainsRoleInTargets(this.hostManager.GetRole(1)))
            {
                btnRoleStatusB.BackColor = Color.Red;
            }
            else
            {
                btnRoleStatusB.BackColor = Color.Gray;
            }

            if (cHandCardManager.ContainsRoleInTargets(this.hostManager.GetRole(2)))
            {
                btnRoleStatusC.BackColor = Color.Red;
            }
            else
            {
                btnRoleStatusC.BackColor = Color.Gray;
            }
            //如果有选中的，则显示操作按钮
            if (cHandCardManager.GetTargets().Count > 0)
            {
                panelCardOperationButtons.Visible = true;
            }
        }

        /// <summary>
        /// 刷新可以攻击的范围
        /// </summary>
        void RefreshAttackableTargetStatus(int attackDistance = -1)
        {
            if (attackDistance == -1)
            {
                //复原
                btnRoleStatusA.FlatAppearance.BorderColor = Color.Gray;
                btnRoleStatusB.FlatAppearance.BorderColor = Color.Gray;
                btnRoleStatusC.FlatAppearance.BorderColor = Color.Gray;
            }
            else
            {
                //查找在攻击范围内的角色
                if (this.hostManager.GetRoleDistance(0, 2) <= 0)
                {
                    btnRoleStatusA.FlatAppearance.BorderColor = Color.Green;
                }
                else
                {
                    btnRoleStatusA.FlatAppearance.BorderColor = Color.Gray;
                }

                if (this.hostManager.GetRoleDistance(1, 2) <= 0)
                {
                    btnRoleStatusB.FlatAppearance.BorderColor = Color.Green;
                }
                else
                {
                    btnRoleStatusB.FlatAppearance.BorderColor = Color.Gray;
                }


            }
        }
        #endregion
    }
}
