namespace Year2013
{
    partial class InputUserInfo
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.InputName = new System.Windows.Forms.TextBox();
            this.ButtonOK = new System.Windows.Forms.Button();
            this.labMark = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(29, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "您的得分是:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(29, 107);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(95, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "请输入您的姓名:";
            // 
            // InputName
            // 
            this.InputName.Font = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.InputName.Location = new System.Drawing.Point(31, 140);
            this.InputName.Name = "InputName";
            this.InputName.Size = new System.Drawing.Size(217, 34);
            this.InputName.TabIndex = 2;
            // 
            // ButtonOK
            // 
            this.ButtonOK.Location = new System.Drawing.Point(328, 153);
            this.ButtonOK.Name = "ButtonOK";
            this.ButtonOK.Size = new System.Drawing.Size(78, 46);
            this.ButtonOK.TabIndex = 3;
            this.ButtonOK.Text = "确定";
            this.ButtonOK.UseVisualStyleBackColor = true;
            this.ButtonOK.Click += new System.EventHandler(this.ButtonOKClick);
            // 
            // labMark
            // 
            this.labMark.AutoSize = true;
            this.labMark.Font = new System.Drawing.Font("微软雅黑", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labMark.ForeColor = System.Drawing.Color.Red;
            this.labMark.Location = new System.Drawing.Point(105, 44);
            this.labMark.Name = "labMark";
            this.labMark.Size = new System.Drawing.Size(30, 39);
            this.labMark.TabIndex = 4;
            this.labMark.Text = "-";
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 50;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // InputUserInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(422, 211);
            this.Controls.Add(this.labMark);
            this.Controls.Add(this.ButtonOK);
            this.Controls.Add(this.InputName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "InputUserInfo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "InputUserInfo";
            this.Load += new System.EventHandler(this.InputUserInfo_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox InputName;
        private System.Windows.Forms.Button ButtonOK;
        private System.Windows.Forms.Label labMark;
        private System.Windows.Forms.Timer timer1;
    }
}