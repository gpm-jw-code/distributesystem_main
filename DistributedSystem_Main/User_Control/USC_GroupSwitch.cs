using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DistributedSystem_Main.User_Control
{
    public partial class USC_GroupSwitch : UserControl
    {
        public Dictionary<string, Button> Dict_GroupButtons = new Dictionary<string, Button>();
        string NowGroupName = "";

        public Action<string> Event_ChangeGroupName;

        public USC_GroupSwitch()
        {
            InitializeComponent();
        }

        public void InitializeGroupButtons()
        {
            FlowPanel_Buttons.Controls.Clear();
        }

        public void AddGroupButton(string GroupName)
        {
            Button NewGroupButton = new Button()
            {
                Text = GroupName,
                BackColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Margin = new Padding(10, 10, 10, 20),
                Size = new Size(144,55),
            };
            NewGroupButton.SetCornerRound(15);
            NewGroupButton.MouseClick += GroupButton_MouseClick;
            Dict_GroupButtons.Add(GroupName, NewGroupButton);
            FlowPanel_Buttons.Controls.Add(NewGroupButton);
        }

        public void ChangeSelectGroup(string NewGroupName)
        {
            if (NowGroupName != "")
            {
                Dict_GroupButtons[NowGroupName].BackColor = Color.White;
            }
            Dict_GroupButtons[NewGroupName].BackColor = Color.FromArgb(15, 173, 255);
            NowGroupName = NewGroupName;
        }

        private void GroupButton_MouseClick(object sender, MouseEventArgs e)
        {
            var TargetBTN = sender as Button;
            ChangeSelectGroup(TargetBTN.Text);
            Event_ChangeGroupName?.Invoke(NowGroupName);
        }
    }
}
