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
    public partial class PageSwitch : UserControl
    {
        public PageSwitch()
        {
            InitializeComponent();
            FlowPanel_PageNum.Controls.Clear();
        }

        public Action<int> Event_PageChange;

        private int _nowPageNumber = 1;
        public int NowPageNumber
        {
            get
            {
                return _nowPageNumber;
            }
            set
            {
                _nowPageNumber = value;
            }
        }

        private int MaximumPageNumber = 1;
        private List<Button> List_PageButtons = new List<Button>();
        public void SetMaximumPageNumber(int MaximumPageNumber)
        {
            this.MaximumPageNumber = MaximumPageNumber;
            int ButtonCount = List_PageButtons.Count;

            if (MaximumPageNumber == ButtonCount)
            {
                return;
            }

            FlowPanel_PageNum.Controls.Clear();

            if (ButtonCount > MaximumPageNumber)
            {
                List_PageButtons.RemoveRange(MaximumPageNumber, ButtonCount-MaximumPageNumber);
            }
            if (ButtonCount < MaximumPageNumber)
            {
                for (int i = ButtonCount; i < MaximumPageNumber; i++)
                {
                    Button NewPageButton = new Button()
                    {
                        Text = (i + 1).ToString(),
                        Tag = i + 1,
                        Size = new Size(35, BTN_Next.Height),
                        FlatStyle = BTN_Next.FlatStyle,
                        Font = BTN_Next.Font,
                        Margin = new Padding(0),
                        Cursor = Cursors.Hand
                    };
                    NewPageButton.Click += BTN_PageChange;
                    List_PageButtons.Add(NewPageButton);
                }
            }
            NowPageNumber = 1;
            SetList_PageButtonsVisible(1);
            FlowPanel_PageNum.Controls.AddRange(List_PageButtons.ToArray());
        }

        private void SetList_PageButtonsVisible(int NowPage)
        {
            foreach (var item in List_PageButtons)
            {
                int EachPageNumber = Convert.ToInt32(item.Tag);
                item.Visible = (EachPageNumber > NowPage - 5) && (EachPageNumber < NowPage + 4);
                if (EachPageNumber== NowPage )
                {
                    item.BackColor = Color.FromArgb(0, 123, 255);
                    item.ForeColor = Color.White;
                }
                else
                {
                    item.BackColor = Color.Transparent;
                    item.ForeColor = Color.Black;
                }
            }
            BTN_Preview.Enabled = NowPage > 1;
            BTN_Next.Enabled = NowPage < MaximumPageNumber;
        }

        public void BTN_PageChange(object sender,EventArgs e)
        {
            Button ClickedButton = sender as Button;
            int ClickedPage = Convert.ToInt32(ClickedButton.Tag);
            NowPageNumber = ClickedPage;
            SetList_PageButtonsVisible(ClickedPage);
            Event_PageChange?.Invoke(NowPageNumber);
        }

        private void BTN_Preview_Click(object sender, EventArgs e)
        {
            int ClickedPage = NowPageNumber-1;
            NowPageNumber = ClickedPage;
            SetList_PageButtonsVisible(ClickedPage);
            Event_PageChange?.Invoke(NowPageNumber);
        }

        private void BTN_Next_Click(object sender, EventArgs e)
        {
            int ClickedPage = NowPageNumber + 1;
            NowPageNumber = ClickedPage;
            SetList_PageButtonsVisible(ClickedPage);
            Event_PageChange?.Invoke(NowPageNumber);
        }
    }
}
