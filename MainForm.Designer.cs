namespace Year2013
{
    public class DoubeBufferDrawPanel : System.Windows.Forms.Panel
    {
        public DoubeBufferDrawPanel()
        {
            this.SetStyle(System.Windows.Forms.ControlStyles.AllPaintingInWmPaint | //不擦除背景 ,减少闪烁
                          System.Windows.Forms.ControlStyles.OptimizedDoubleBuffer | //双缓冲
                          System.Windows.Forms.ControlStyles.UserPaint, //使用自定义的重绘事件,减少闪烁
                          true); 
        }
    }
    partial class MainForm
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.DrawPanel = new System.Windows.Forms.Panel();
            this.StartGame = new System.Windows.Forms.Button();
            this.DrawPicture = new System.Windows.Forms.PictureBox();
            this.DrawTimer = new System.Windows.Forms.Timer(this.components);
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.ResultList = new System.Windows.Forms.ListView();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader3 = new System.Windows.Forms.ColumnHeader();
            this.StartPauseTimer = new System.Windows.Forms.Timer(this.components);
            this.WaitResultTimer = new System.Windows.Forms.Timer(this.components);
            this.NumberPanel = new Year2013.DoubeBufferDrawPanel();
            this.DrawPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DrawPicture)).BeginInit();
            this.SuspendLayout();
            // 
            // DrawPanel
            // 
            this.DrawPanel.Controls.Add(this.StartGame);
            this.DrawPanel.Controls.Add(this.NumberPanel);
            this.DrawPanel.Controls.Add(this.DrawPicture);
            this.DrawPanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.DrawPanel.Location = new System.Drawing.Point(0, 0);
            this.DrawPanel.Name = "DrawPanel";
            this.DrawPanel.Size = new System.Drawing.Size(723, 730);
            this.DrawPanel.TabIndex = 1;
            // 
            // StartGame
            // 
            this.StartGame.BackColor = System.Drawing.Color.Goldenrod;
            this.StartGame.Location = new System.Drawing.Point(584, 617);
            this.StartGame.Name = "StartGame";
            this.StartGame.Size = new System.Drawing.Size(139, 70);
            this.StartGame.TabIndex = 3;
            this.StartGame.Text = "开始";
            this.StartGame.UseVisualStyleBackColor = false;
            this.StartGame.Click += new System.EventHandler(this.StartGame_Click);
            // 
            // DrawPicture
            // 
            this.DrawPicture.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DrawPicture.Image = global::Year2013.Properties.Resources.bj;
            this.DrawPicture.ImageLocation = "";
            this.DrawPicture.Location = new System.Drawing.Point(0, 0);
            this.DrawPicture.Name = "DrawPicture";
            this.DrawPicture.Size = new System.Drawing.Size(723, 730);
            this.DrawPicture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.DrawPicture.TabIndex = 0;
            this.DrawPicture.TabStop = false;
            // 
            // DrawTimer
            // 
            this.DrawTimer.Interval = 10;
            this.DrawTimer.Tick += new System.EventHandler(this.DrawTimer_Tick);
            // 
            // splitter1
            // 
            this.splitter1.Location = new System.Drawing.Point(723, 0);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(3, 730);
            this.splitter1.TabIndex = 3;
            this.splitter1.TabStop = false;
            // 
            // ResultList
            // 
            this.ResultList.BackColor = System.Drawing.Color.DarkRed;
            this.ResultList.BackgroundImage = global::Year2013.Properties.Resources.bj;
            this.ResultList.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.ResultList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3});
            this.ResultList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ResultList.Font = new System.Drawing.Font("微软雅黑", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ResultList.ForeColor = System.Drawing.Color.Yellow;
            this.ResultList.GridLines = true;
            this.ResultList.Location = new System.Drawing.Point(726, 0);
            this.ResultList.Name = "ResultList";
            this.ResultList.Size = new System.Drawing.Size(292, 730);
            this.ResultList.TabIndex = 4;
            this.ResultList.UseCompatibleStateImageBehavior = false;
            this.ResultList.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "工号";
            this.columnHeader1.Width = 100;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "分数";
            this.columnHeader2.Width = 85;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "结果";
            this.columnHeader3.Width = 200;
            // 
            // StartPauseTimer
            // 
            this.StartPauseTimer.Interval = 1000;
            this.StartPauseTimer.Tick += new System.EventHandler(this.StartPauseTimer_Tick);
            // 
            // WaitResultTimer
            // 
            this.WaitResultTimer.Tick += new System.EventHandler(this.WaitResultTimer_Tick);
            // 
            // NumberPanel
            // 
            this.NumberPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.NumberPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.NumberPanel.Location = new System.Drawing.Point(62, 187);
            this.NumberPanel.Name = "NumberPanel";
            this.NumberPanel.Size = new System.Drawing.Size(588, 357);
            this.NumberPanel.TabIndex = 4;
            this.NumberPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.NumberPanel_Paint);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1018, 730);
            this.Controls.Add(this.ResultList);
            this.Controls.Add(this.splitter1);
            this.Controls.Add(this.DrawPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "英雄三国-2013云计算摇奖程序";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.DrawPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DrawPicture)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel DrawPanel;
        private System.Windows.Forms.Timer DrawTimer;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.ListView ResultList;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.PictureBox DrawPicture;
        private System.Windows.Forms.Button StartGame;
        private DoubeBufferDrawPanel NumberPanel;
        private System.Windows.Forms.Timer StartPauseTimer;
        private System.Windows.Forms.Timer WaitResultTimer;
    }
}

