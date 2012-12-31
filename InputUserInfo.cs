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
                MessageBox.Show("姓名重复了!");
                return;
            }
            this.Close();
        }
    }
}
