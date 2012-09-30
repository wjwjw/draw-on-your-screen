namespace 屏幕绘制
{
    partial class DrawForm
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.oToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.penToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.线ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.三角形ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.矩形ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.圆ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.实心ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.线框ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.阴影画刷ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.颜色画刷ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.后台运行WToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.线ToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.三角形2ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.圆形3ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.三角形4ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.撤销ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.重画ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.异或线ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.变细ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.箭头ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.oToolStripMenuItem,
            this.penToolStripMenuItem,
            this.tuToolStripMenuItem,
            this.后台运行WToolStripMenuItem,
            this.线ToolStripMenuItem1,
            this.三角形2ToolStripMenuItem,
            this.圆形3ToolStripMenuItem,
            this.三角形4ToolStripMenuItem,
            this.撤销ToolStripMenuItem,
            this.重画ToolStripMenuItem,
            this.异或线ToolStripMenuItem,
            this.变细ToolStripMenuItem,
            this.箭头ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1105, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            this.menuStrip1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.menuStrip1_MouseUp);
            this.menuStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.menuStrip1_ItemClicked);
            // 
            // oToolStripMenuItem
            // 
            this.oToolStripMenuItem.Name = "oToolStripMenuItem";
            this.oToolStripMenuItem.Size = new System.Drawing.Size(59, 20);
            this.oToolStripMenuItem.Text = "截图(&Q)";
            this.oToolStripMenuItem.Click += new System.EventHandler(this.oToolStripMenuItem_Click);
            // 
            // penToolStripMenuItem
            // 
            this.penToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.线ToolStripMenuItem,
            this.三角形ToolStripMenuItem,
            this.矩形ToolStripMenuItem,
            this.圆ToolStripMenuItem});
            this.penToolStripMenuItem.Name = "penToolStripMenuItem";
            this.penToolStripMenuItem.Size = new System.Drawing.Size(41, 20);
            this.penToolStripMenuItem.Text = "图形";
            this.penToolStripMenuItem.Click += new System.EventHandler(this.penToolStripMenuItem_Click);
            // 
            // 线ToolStripMenuItem
            // 
            this.线ToolStripMenuItem.Name = "线ToolStripMenuItem";
            this.线ToolStripMenuItem.Size = new System.Drawing.Size(106, 22);
            this.线ToolStripMenuItem.Text = "线";
            // 
            // 三角形ToolStripMenuItem
            // 
            this.三角形ToolStripMenuItem.Name = "三角形ToolStripMenuItem";
            this.三角形ToolStripMenuItem.Size = new System.Drawing.Size(106, 22);
            this.三角形ToolStripMenuItem.Text = "三角形";
            // 
            // 矩形ToolStripMenuItem
            // 
            this.矩形ToolStripMenuItem.Name = "矩形ToolStripMenuItem";
            this.矩形ToolStripMenuItem.Size = new System.Drawing.Size(106, 22);
            this.矩形ToolStripMenuItem.Text = "矩形";
            // 
            // 圆ToolStripMenuItem
            // 
            this.圆ToolStripMenuItem.Name = "圆ToolStripMenuItem";
            this.圆ToolStripMenuItem.Size = new System.Drawing.Size(106, 22);
            this.圆ToolStripMenuItem.Text = "圆";
            // 
            // tuToolStripMenuItem
            // 
            this.tuToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.实心ToolStripMenuItem,
            this.线框ToolStripMenuItem,
            this.阴影画刷ToolStripMenuItem,
            this.颜色画刷ToolStripMenuItem});
            this.tuToolStripMenuItem.Name = "tuToolStripMenuItem";
            this.tuToolStripMenuItem.Size = new System.Drawing.Size(65, 20);
            this.tuToolStripMenuItem.Text = "图形属性";
            this.tuToolStripMenuItem.Click += new System.EventHandler(this.tuToolStripMenuItem_Click);
            // 
            // 实心ToolStripMenuItem
            // 
            this.实心ToolStripMenuItem.Name = "实心ToolStripMenuItem";
            this.实心ToolStripMenuItem.Size = new System.Drawing.Size(130, 22);
            this.实心ToolStripMenuItem.Text = "实心";
            this.实心ToolStripMenuItem.Click += new System.EventHandler(this.实心ToolStripMenuItem_Click);
            // 
            // 线框ToolStripMenuItem
            // 
            this.线框ToolStripMenuItem.Name = "线框ToolStripMenuItem";
            this.线框ToolStripMenuItem.Size = new System.Drawing.Size(130, 22);
            this.线框ToolStripMenuItem.Text = "线框";
            this.线框ToolStripMenuItem.Click += new System.EventHandler(this.线框ToolStripMenuItem_Click);
            // 
            // 阴影画刷ToolStripMenuItem
            // 
            this.阴影画刷ToolStripMenuItem.Name = "阴影画刷ToolStripMenuItem";
            this.阴影画刷ToolStripMenuItem.Size = new System.Drawing.Size(130, 22);
            this.阴影画刷ToolStripMenuItem.Text = "阴影画刷一";
            this.阴影画刷ToolStripMenuItem.Click += new System.EventHandler(this.阴影画刷ToolStripMenuItem_Click);
            // 
            // 颜色画刷ToolStripMenuItem
            // 
            this.颜色画刷ToolStripMenuItem.Name = "颜色画刷ToolStripMenuItem";
            this.颜色画刷ToolStripMenuItem.Size = new System.Drawing.Size(130, 22);
            this.颜色画刷ToolStripMenuItem.Text = "阴影画刷二";
            this.颜色画刷ToolStripMenuItem.Click += new System.EventHandler(this.颜色画刷ToolStripMenuItem_Click);
            // 
            // 后台运行WToolStripMenuItem
            // 
            this.后台运行WToolStripMenuItem.Name = "后台运行WToolStripMenuItem";
            this.后台运行WToolStripMenuItem.Size = new System.Drawing.Size(83, 20);
            this.后台运行WToolStripMenuItem.Text = "后台运行(&W)";
            this.后台运行WToolStripMenuItem.Click += new System.EventHandler(this.后台运行WToolStripMenuItem_Click);
            // 
            // 线ToolStripMenuItem1
            // 
            this.线ToolStripMenuItem1.Name = "线ToolStripMenuItem1";
            this.线ToolStripMenuItem1.Size = new System.Drawing.Size(47, 20);
            this.线ToolStripMenuItem1.Text = "线(&1)";
            this.线ToolStripMenuItem1.Click += new System.EventHandler(this.线ToolStripMenuItem1_Click);
            // 
            // 三角形2ToolStripMenuItem
            // 
            this.三角形2ToolStripMenuItem.Name = "三角形2ToolStripMenuItem";
            this.三角形2ToolStripMenuItem.Size = new System.Drawing.Size(59, 20);
            this.三角形2ToolStripMenuItem.Text = "直线(&2)";
            this.三角形2ToolStripMenuItem.Click += new System.EventHandler(this.三角形2ToolStripMenuItem_Click);
            // 
            // 圆形3ToolStripMenuItem
            // 
            this.圆形3ToolStripMenuItem.Name = "圆形3ToolStripMenuItem";
            this.圆形3ToolStripMenuItem.Size = new System.Drawing.Size(59, 20);
            this.圆形3ToolStripMenuItem.Text = "矩形(&3)";
            this.圆形3ToolStripMenuItem.Click += new System.EventHandler(this.圆形3ToolStripMenuItem_Click);
            // 
            // 三角形4ToolStripMenuItem
            // 
            this.三角形4ToolStripMenuItem.Name = "三角形4ToolStripMenuItem";
            this.三角形4ToolStripMenuItem.Size = new System.Drawing.Size(59, 20);
            this.三角形4ToolStripMenuItem.Text = "椭圆(&4)";
            this.三角形4ToolStripMenuItem.Click += new System.EventHandler(this.三角形4ToolStripMenuItem_Click);
            // 
            // 撤销ToolStripMenuItem
            // 
            this.撤销ToolStripMenuItem.Name = "撤销ToolStripMenuItem";
            this.撤销ToolStripMenuItem.Size = new System.Drawing.Size(41, 20);
            this.撤销ToolStripMenuItem.Text = "撤销";
            this.撤销ToolStripMenuItem.Click += new System.EventHandler(this.撤销ToolStripMenuItem_Click);
            // 
            // 重画ToolStripMenuItem
            // 
            this.重画ToolStripMenuItem.Name = "重画ToolStripMenuItem";
            this.重画ToolStripMenuItem.Size = new System.Drawing.Size(41, 20);
            this.重画ToolStripMenuItem.Text = "重画";
            this.重画ToolStripMenuItem.Click += new System.EventHandler(this.重画ToolStripMenuItem_Click);
            // 
            // 异或线ToolStripMenuItem
            // 
            this.异或线ToolStripMenuItem.Name = "异或线ToolStripMenuItem";
            this.异或线ToolStripMenuItem.Size = new System.Drawing.Size(41, 20);
            this.异或线ToolStripMenuItem.Text = "加粗";
            this.异或线ToolStripMenuItem.Click += new System.EventHandler(this.异或线ToolStripMenuItem_Click);
            // 
            // 变细ToolStripMenuItem
            // 
            this.变细ToolStripMenuItem.Name = "变细ToolStripMenuItem";
            this.变细ToolStripMenuItem.Size = new System.Drawing.Size(41, 20);
            this.变细ToolStripMenuItem.Text = "变细";
            this.变细ToolStripMenuItem.Click += new System.EventHandler(this.变细ToolStripMenuItem_Click);
            // 
            // 箭头ToolStripMenuItem
            // 
            this.箭头ToolStripMenuItem.Name = "箭头ToolStripMenuItem";
            this.箭头ToolStripMenuItem.Size = new System.Drawing.Size(59, 20);
            this.箭头ToolStripMenuItem.Text = "箭头(&5)";
            this.箭头ToolStripMenuItem.Click += new System.EventHandler(this.箭头ToolStripMenuItem_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Location = new System.Drawing.Point(0, 24);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(1105, 458);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseMove);
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            this.pictureBox1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseDown);
            this.pictureBox1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseUp);
            // 
            // DrawForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1105, 482);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.menuStrip1);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "DrawForm";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem oToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 后台运行WToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem penToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 线ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 三角形ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tuToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 实心ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 线框ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 矩形ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 圆ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 阴影画刷ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 颜色画刷ToolStripMenuItem;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ToolStripMenuItem 线ToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem 三角形2ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 圆形3ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 三角形4ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 撤销ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 重画ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 异或线ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 变细ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 箭头ToolStripMenuItem;
    }
}

