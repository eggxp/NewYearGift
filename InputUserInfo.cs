using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Year2013
{
    public partial class InputUserInfo : Form
    {
        private bool IsTextColorRed;
        private int Result;
        public InputUserInfo()
        {
            InitializeComponent();
        }

        public void InitText(int text)
        {
            labMark.Text = text.ToString();
            Result = text;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (IsTextColorRed)
            {
                labMark.ForeColor = System.Drawing.Color.Yellow;
                IsTextColorRed = false;
            }
            else
            {
                IsTextColorRed = true;
                labMark.ForeColor = System.Drawing.Color.Red;
            }
        }

        private void InputUserInfo_Load(object sender, EventArgs e)
        {
            IsTextColorRed = true;
        }

        private void ButtonOKClick(object sender, EventArgs e)
        {
            string name = InputName.Text.Trim();
            if (name.Length == 0)
            {
                MessageBox.Show("请输入姓名!");
                return;
            }
            while(!MainForm.pWindow.AddUserInfo(name, Result))
            {
                MessageBox.Show("工号重复了!");
                return;
            }

            string promString = string.Format("您的工号是<{0:G}>, 确定吗?", name);
            DialogResult mess = MessageBox.Show(promString,
                    "确认提示", MessageBoxButtons.YesNo);
            if (mess == DialogResult.No)
            {
                InputName.Text = "";
                return;
            }
            this.Close();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            Button currentButton = (Button)sender;
            int inputNumb = 0;
            if (!int.TryParse(currentButton.Text, out inputNumb))
            {
                InputName.Text = "";
                return;
            }
            if (InputName.Text.Length >= 4)
            {
                return;
            }
            InputName.Text += inputNumb.ToString();
        }
    }
}
