﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace Year2013
{
    public struct NumberState
    {        
        const int MAX_NUMBER = 10;
        int Dir; // 0:上 1:下
        int CurrentNum;
        int CurrentProcess;
        const int MAX_PROCESS = 100;
        double UpdateSpeed;
        const double SPEED_MODIFIER = 15;
        const double SPEED_INC = 3;
        public void Init(int dir, int index)
        {
            CurrentProcess = 0;
            Dir = dir;
            if (Dir == 0)
            {
                CurrentNum = 9;
            }
            else
            {
                CurrentNum = 1;
            }
            Reset(index);
        }
        public void Reset(int index)
        {
            Random ran = new Random();
            int RandKey = ran.Next(50, 100);
            UpdateSpeed = SPEED_MODIFIER + RandKey - index * 10;
        }
        public int GetCurrentNum()
        {
            return CurrentNum;
        }
        public double GetCurrentProcess()
        {
            return (double)CurrentProcess / (double)MAX_PROCESS;
        }
        public int GetNextNum(int num)
        {
            if (Dir == 0)
            {
                // 上
                num += 1;
                if (num >= MAX_NUMBER)
                {
                    num -= MAX_NUMBER;
                }
            }
            else
            {
                num -= 1;
                if (num < 0)
                {
                    num += MAX_NUMBER;
                }
            }
            return num;
        }
        public void Update()
        {
            if (UpdateSpeed < 10000)
            {
                UpdateSpeed += SPEED_INC;
            }
            CurrentProcess += (int)(UpdateSpeed / SPEED_MODIFIER);
            if (CurrentProcess < MAX_PROCESS)   
            {
                return;
            }
            CurrentProcess = 0;
            CurrentNum = GetNextNum(CurrentNum);            
        }
        public void Stop()
        {
            if (CurrentProcess == 0)
            {
                return;
            }
            Update();
        }
        public bool IsStopped()
        {
            if (CurrentProcess == 0)
            {
                return true;
            }
            return false;
        }
        public int[] GetNumbers()
        {
            int[] result = new int[3];
            result[0] = CurrentNum;
            result[1] = GetNextNum(CurrentNum);
            result[2] = GetNextNum(result[1]);
            return result;
        }
    }

    /// <summary>
    /// 主类////////////////////////////////////////////////////////////////////////////
    /// </summary>
    public partial class MainForm : Form
    {
        const bool IS_DEBUG = false;
        int[] PriceSetting;
        NumberState[] PictureState;
        bool GameStart = false;
        int StartPauseTick;
        public static MainForm pWindow = null;
        List<UserInfo> ResultDataList;
        string CurrentPlayerName;
        public MainForm()
        {
            InitializeComponent();
            pWindow = this;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            // 初始化
            // 奖项设置
            PriceSetting = new int[3];
            PriceSetting[0] = 2;
            PriceSetting[1] = 8;
            PriceSetting[2] = 28;
            ResultDataList = new List<UserInfo>();
            this.DoubleBuffered = true;
            DrawTimer.Enabled = false;
            InitStart();
        }

        private void InitStart()
        {
            PictureState = new NumberState[4];
            for (int i = 0; i < 4; i++)
            {
                PictureState[i] = new NumberState();
                PictureState[i].Init(i % 2, i);
            }

            if (IS_DEBUG)
            {
                for (int i = 10000; i < 10050; i++)
                {
                    AddUserInfo(i.ToString(), i);
                }
                UpdateUserInfoToList();
            }
        }

        private void DrawNumber(Graphics g)
        {
            // 画四道分割线
            // 字号: 100, 宽度: 178.7
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;
            double base_width = NumberPanel.Width / 4;
            double fontDistance = NumberPanel.Height / 2;
            int fontSize = 100;
            double startPos = -(double)fontDistance;
            Font curFont = new Font("Verdana", fontSize);
            SolidBrush brush = new SolidBrush(Color.Gold);
            SolidBrush shadow = new SolidBrush(Color.Red);
            int shadowSize = 5;
            for (int i = 0; i < 4; i++)
            {
                int[] result = PictureState[i].GetNumbers();
                for (int num = 0; num < 3; num++)
                {
                    double pos = 0;
                    if (i % 2 == 0)
                    {
                        pos = startPos + fontDistance * num + fontDistance * (1 - PictureState[i].GetCurrentProcess() - 0.5);
                    }
                    else
                    {
                        pos = startPos + fontDistance * (2 - num) + fontDistance * (PictureState[i].GetCurrentProcess() + 0.5);
                    }
                    
                    int drawX = (int)(base_width * i);
                    int drawY = (int)pos;
                    // 阴影
                    g.DrawString(result[num].ToString(), curFont, shadow, drawX + shadowSize, drawY + shadowSize);
                    g.DrawString(result[num].ToString(), curFont, shadow, drawX + shadowSize, drawY - shadowSize);
                    g.DrawString(result[num].ToString(), curFont, shadow, drawX - shadowSize, drawY + shadowSize);
                    g.DrawString(result[num].ToString(), curFont, shadow, drawX - shadowSize, drawY - shadowSize);
                    g.DrawString(result[num].ToString(), curFont, shadow, drawX + 0, drawY + shadowSize);
                    g.DrawString(result[num].ToString(), curFont, shadow, drawX + 0, drawY - shadowSize);
                    g.DrawString(result[num].ToString(), curFont, shadow, drawX + shadowSize, drawY + 0);
                    g.DrawString(result[num].ToString(), curFont, shadow, drawX - shadowSize, drawY + 0);
                    g.DrawString(result[num].ToString(), curFont, brush, drawX, drawY);
                }
            }
        }

        private void DrawTimer_Tick(object sender, EventArgs e)
        {
            // 更新滚动进度
            if(GameStart)
            {
                for (int i = 0; i < 4; i++)
                {
                    PictureState[i].Update();
                }
            }
            else
            {
                for (int i = 0; i < 4; i++)
                {
                    PictureState[i].Stop();
                }
            }
            
            NumberPanel.Refresh();
        }

        private void StartGame_Click(object sender, EventArgs e)
        {
            DrawTimer.Enabled = true;
            if (GameStart)
            {
                GameStart = false;
                StartGame.Text = string.Format("开始({0:G}人)", ResultDataList.Count + 1);
                WaitResultTimer.Enabled = true;
            }
            else
            {
                StartGame.Text = "停止"; 
                GameStart = true;
                for (int i = 0; i < 4; i++)
                {
                    PictureState[i].Reset(i);
                }

                StartPauseTimer.Enabled = true;
                StartPauseTick = 3;
                if (!IS_DEBUG)
                {
                    StartGame.Visible = false;
                }
            }
        }

        private void NumberPanel_Paint(object sender, PaintEventArgs e)
        {
            DrawNumber(e.Graphics);
        }

        private void StartPauseTimer_Tick(object sender, EventArgs e)
        {
            StartPauseTick -= 1;
            if (StartPauseTick == 0)
            {
                StartGame.Visible = true;
                StartPauseTimer.Enabled = false;
            }
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult mess = MessageBox.Show("是否退出?",
                    "退出提示", MessageBoxButtons.YesNo);
            if (mess == DialogResult.No)
            {
                e.Cancel = true;
                return;
            }
        }

        private int GetResult()
        {
            int result = 0;
            for (int i = 0; i < 4; i++)
            {
                if (!PictureState[i].IsStopped())
                {
                    return -1;
                }
                result += (int)(PictureState[i].GetNumbers()[1] * Math.Pow(10, 3 - i));
            }
            return result;
        }

        private void ShowResultForm(int result)
        {
            InputUserInfo frm = new InputUserInfo();
            frm.Location = new Point(this.Location.X + 700, this.Location.Y + 150);
            frm.InitText(result);
            frm.ShowDialog();
        }

        private void WaitResultTimer_Tick(object sender, EventArgs e)
        {
            int result = GetResult();
            if (result == -1)
            {
                return;
            }
            WaitResultTimer.Enabled = false;
            ShowResultForm(result);
            UpdateUserInfoToList();
        }

        public bool AddUserInfo(string name, int result)
        {
            name = name.Trim().ToLower();
            foreach (UserInfo user in ResultDataList)
            {
                if (user.name == name)
                {
                    return false;
                }
            }

            CurrentPlayerName = name;
            UserInfo curUser = new UserInfo();
            curUser.name = name;
            curUser.result = result;
            curUser.price = 0;
            ResultDataList.Add(curUser);
            ResultDataList.Sort(delegate(UserInfo small, UserInfo big) { return big.result - small.result; });

            for (int i=0; i<ResultDataList.Count; i++)
            {
                int priceIndex = 0;
                for (int j =0; j < PriceSetting.Length; j++)
                {
                    if (i < PriceSetting[j])
                    {
                        priceIndex = j;
                        break;
                    }
                    priceIndex = j+1;
                }
                priceIndex += 1;
                ResultDataList[i].price = priceIndex;
            }

            FileStream sFile = new FileStream("bak.txt", FileMode.Create);
            StreamWriter sw = new StreamWriter(sFile);

            foreach (UserInfo user in ResultDataList)
            {
                string curString = string.Format("{0:G}\t{1:G}\t{2:G}", user.name, user.result, user.price);
                sw.WriteLine(curString);
            }
            sw.Flush();
            sw.Close();
            return true;
        }

        private void UpdateUserInfoToList()
        {
            ResultList.BeginUpdate();
            ResultList.Items.Clear();
            System.Windows.Forms.ListViewItem visibleListView = null;
            foreach (UserInfo user in ResultDataList)
            {
                System.Windows.Forms.ListViewItem listViewItem1 = new System.Windows.Forms.ListViewItem(user.name);
                listViewItem1.SubItems.Add(user.result.ToString());
                listViewItem1.SubItems.Add(user.GetPriceText());
                if (CurrentPlayerName == user.name)
                {
                    listViewItem1.ForeColor = Color.YellowGreen;
                    listViewItem1.Selected = true;
                    visibleListView = listViewItem1;
                }
                else
                {
                    listViewItem1.ForeColor = Color.Yellow;
                }
                ResultList.Items.Add(listViewItem1);
            }
            ResultList.EndUpdate();
            if (visibleListView != null)
            {
                visibleListView.EnsureVisible();
            }
        }
    }

    public class UserInfo
    {
        public string name;
        public int result;
        public int price;
        public string GetPriceText()
        {
            switch (price)
            {
                case 1:
                    return "一等奖!!";
                case 2:
                    return "二等奖!";
                case 3:
                    return "三等奖";
                default:
                    return "";
            }
        }
    }
}
