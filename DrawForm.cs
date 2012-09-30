using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using gma.System.Windows;
using System.Drawing.Drawing2D;
using System.Collections;

namespace 屏幕绘制
{
    public partial class DrawForm : Form
    {
        public DrawForm()
        {
            InitializeComponent();
        }
        //全局变量
        bool isLMouseDown;
        double PI = Math.Acos(-1.0);
        Point startPoint = Point.Empty;         //全局起始位置
        Point endPoint = Point.Empty;           //全局终点
        Color G_color = Color.Gold;              //画线颜色

        //绘图枚举类型，线段，直线，椭圆，矩形,箭头
        enum PaintType { P_LINES, P_STLINE, P_CIRCLE, P_RECTANGLE, P_ARROW };

        PaintType FigureType = PaintType.P_LINES;           //图形类型

        Pen G_pen = new Pen(Color.Red);

        Graphics g;                                         //画板
        Image G_image;                                      //画纸
        Bitmap map;                                         //全局位图
        object[] myStack;                                    //图片栈
        int[,] zoom;
        int cnt, index;                                     //下表索引

        //WJW
        static Image img;
        static int changenum = 1;
        static int img_x;
        static int img_y;
        private Point myPoint;
        private Rectangle rc;
        private Bitmap bmp;


        private void Form1_Load(object sender, EventArgs e) //初始化
        {
            isLMouseDown = false;
            //创建图
            G_image = new Bitmap(Screen.AllScreens[0].Bounds.Width, Screen.AllScreens[0].Bounds.Height);
            g = Graphics.FromImage(G_image);
            map = new Bitmap(G_image);
            g.CopyFromScreen(new Point(0, 0), new Point(0, 0), Screen.AllScreens[0].Bounds.Size);
            pictureBox1.Image = G_image;
            //设置全屏边框
            this.TopMost = true;
            this.FormBorderStyle = FormBorderStyle.None;
            this.WindowState = FormWindowState.Maximized;
            this.menuStrip1.Hide();
            //线宽
            G_pen.Width = 3;
            cnt = index = 0;
            //初始化图片栈
            myStack = new Image[10];
            zoom = new int[10, 3];
            img_x = pictureBox1.Width >> 1;
            img_y = pictureBox1.Height >> 1;
            for (int i = 0; i < 10; i++)
            {
                myStack[i] = pictureBox1.Image.Clone();
                zoom[i, 0] = 1;
                zoom[i, 1] = img_x;
                zoom[i, 2] = img_y;
            }
            //WJW
            Image tmp = (Image)(G_image.Clone());
            img = (Image)(tmp.Clone());
            this.pictureBox1.MouseWheel += new MouseEventHandler(pictureBox1_MouseWheel);
            bmp = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            this.pictureBox1.Focus();
        }
        //坐标转换
        void PosChange(ref Point t)
        {
            t.X /=changenum;
            t.Y /=changenum;
        }
        private void PictureSizeChang(int x, int y, int flat)
        {
            Image tmp = (Image)(img.Clone());
            pictureBox1.Image = (Image)(tmp.Clone());

            img_x = (x - pictureBox1.Width / 2) / changenum + img_x;
            img_y = (y - pictureBox1.Height / 2) / changenum + img_y;
            changenum += flat;
            if (changenum <= 1)
            {
                img_x = pictureBox1.Width >> 1;
                img_y = pictureBox1.Height >> 1;
                return;
            }

            int rcWidth = pictureBox1.Width / changenum;//截取区域宽
            int rcHeight = pictureBox1.Height / changenum;//截取区域长

            if (img_x < rcWidth / 2) img_x = rcWidth / 2;
            if (img_x > pictureBox1.Width - rcWidth / 2) img_x = pictureBox1.Width - rcWidth / 2;
            if (img_y < rcHeight / 2) img_y = rcHeight / 2;
            if (img_y > pictureBox1.Height - rcHeight / 2) img_y = pictureBox1.Height - rcHeight / 2 - 1;
            if (img_x >= rcWidth / 2 && img_x <= pictureBox1.Width - rcWidth / 2
                && img_y >= rcHeight / 2 && img_y <= pictureBox1.Height - rcHeight / 2)
            {
                //rc = new Rectangle(img_x - rcWidth / 2, img_y - rcHeight / 2, rcWidth-1, rcHeight-1);
                rc.X = img_x - rcWidth / 2;
                rc.Y = img_y - rcHeight / 2;
                rc.Width = rcWidth - 1;
                rc.Height = rcHeight - 1;

                //pictureBox1.DrawToBitmap(bmp, pictureBox1.DisplayRectangle);
                bmp = new Bitmap(img);
                pictureBox1.Image = bmp.Clone(rc, bmp.PixelFormat);//注意rc的范围不要超出，否则抛 内存不足 异常
            }
            pictureBox1.Refresh();
        }
        private void pictureBox1_MouseWheel(object sender, MouseEventArgs e)
        {
            //响应鼠标滚轮的缩放
            if (e.Delta > 0 && changenum < 10)
            {
                try
                {
                    PictureSizeChang(e.X, e.Y, 1);
                }
                catch { }
            }
            else
            {
                if (changenum < 2)
                {
                    changenum = 2;
                }
                try
                {
                    PictureSizeChang(e.X, e.Y, -1);
                }
                catch { }
            }
        }

        //取最大值
        int GetMin(int a, int b)
        {
            return a < b ? a : b;
        }
        //取最小值
        int GetMax(int a, int b)
        {
            return a > b ? a : b;
        }
        //归一起始点和终点
        void ReSetPoint(ref Point s, ref Point e)
        {
            Point rs = Point.Empty, re = Point.Empty;
            rs.X = GetMin(s.X, e.X); rs.Y = GetMin(s.Y, e.Y);
            re.X = GetMax(s.X, e.X); re.Y = GetMax(s.Y, e.Y);
            s = rs;
            e = re;
        }
        int PointToPoint(Point s, Point e)
        {
            return (s.X - e.X) * (s.X - e.X) + (s.Y - e.Y) * (s.Y - e.Y);
        }
        void DrawEllipse(Point s, Point e)                         //画椭圆。s,e都是相对于全局的
        {
            ReSetPoint(ref s, ref e);
            double midy = Math.Abs(s.Y - e.Y) >> 1;
            double midx = Math.Abs(s.X - e.X) >> 1;

            Point center = new Point((s.X + e.X) >> 1, (s.Y + e.Y) >> 1);
            Point a1 = center;
            Point a2 = a1;
            a1.X += (int)(midx * Math.Cos(0.0));
            a1.Y += (int)(midy * Math.Sin(0.0));
            for (int i = 1; i <= 60; i++)
            {
                int x = (int)(midx * Math.Cos((i * 6 + 0.0) / 180.0 * PI));
                int y = (int)(midy * Math.Sin((i * 6 + 0.0) / 180.0 * PI));
                a2 = center;
                a2.X += x;
                a2.Y += y;
                DrawXorLine(a1, a2);
                Drawpixel(a1.X, a1.Y);
                a1 = a2;
            }
        }
        void Drawpixel(int x, int y)
        {
            try
            {
                if (x < map.Width && y < map.Height && x >= 0 && y >= 0)
                {
                    Color ctmp = map.GetPixel(x, y);
                    map.SetPixel(x, y, Color.FromArgb(ctmp.R ^ G_color.R, ctmp.G ^ G_color.G, ctmp.B ^ G_color.B));
                }
            }
            catch { }

        }
        void MidpointLine(int x0, int y0, int x1, int y1)
        {
            int a, b, d1, d2, d, x, y; float m;
            if (x1 < x0)
            {
                d = x0; x0 = x1; x1 = d; d = y0; y0 = y1; y1 = d;
            }
            a = y0 - y1;
            b = x1 - x0;
            if (b == 0)
                m = -1 * a * 100;
            else m = (float)a / (x0 - x1); x = x0; y = y0;
            Drawpixel(x, y);
            if (m >= 0 && m <= 1)
            {
                d = 2 * a + b; d1 = 2 * a; d2 = 2 * (a + b);
                while (x < x1)
                {
                    if (d <= 0) { x++; y++; d += d2; }
                    else { x++; d += d1; }
                    Drawpixel(x, y);
                }
            }
            else if (m <= 0 && m >= -1)
            {
                d = 2 * a - b; d1 = 2 * a - 2 * b; d2 = 2 * a;
                while (x < x1)
                {
                    if (d > 0) { x++; y--; d += d1; }
                    else { x++; d += d2; }
                    Drawpixel(x, y);
                }
            }
            else if (m > 1)
            {
                d = a + 2 * b; d1 = 2 * (a + b); d2 = 2 * b;
                while (y < y1)
                {
                    if (d > 0) { x++; y++; d += d1; }
                    else { y++; d += d2; }
                    Drawpixel(x, y);
                }
            }
            else
            {
                d = a - 2 * b; d1 = -2 * b; d2 = 2 * (a - b);
                while (y > y1)
                {
                    if (d <= 0) { x++; y--; d += d2; }
                    else { y--; d += d1; }
                    Drawpixel(x, y);
                }
            }
        }
        //画异或线
        void DrawXorLine(Point p, Point q)
        {
            MidpointLine(p.X, p.Y, q.X, q.Y);
        }

        void DrawRectangle(Point s, Point e)
        {
            ReSetPoint(ref s, ref e);
            MidpointLine(s.X, s.Y, e.X, s.Y);
            Drawpixel(e.X, s.Y);
            MidpointLine(e.X, s.Y, e.X, e.Y);
            Drawpixel(e.X, e.Y);
            MidpointLine(e.X, e.Y, s.X, e.Y);
            Drawpixel(s.X, e.Y);
            MidpointLine(s.X, e.Y, s.X, s.Y);

        }
        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
        }

        private void oToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void 截图pToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        //鼠标按下回调函数
        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                isLMouseDown = true;
                startPoint = new Point(e.X, e.Y);
                PosChange(ref startPoint);
                map = new Bitmap(pictureBox1.Image);
                g = Graphics.FromImage(pictureBox1.Image);
                g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            }
            //右键设置拖动中心点
            if (e.Button == MouseButtons.Right)
            {
                myPoint.X = e.X;
                myPoint.Y = e.Y;
            }
        }
        //鼠标移动回调函数
        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            
            if (isLMouseDown)
            {
                Point tmp = new Point(e.X, e.Y);
                PosChange(ref tmp);
                if (FigureType == PaintType.P_CIRCLE)                  //椭圆
                {
                    if (endPoint != Point.Empty)
                        DrawEllipse(startPoint, endPoint);
                    endPoint = tmp;
                    DrawEllipse(startPoint, endPoint);

                }
                else if (FigureType == PaintType.P_RECTANGLE)           //矩形
                {
                    if (endPoint != Point.Empty)
                        DrawRectangle(startPoint, endPoint);
                    endPoint = tmp;
                    DrawRectangle(startPoint, endPoint);
                }
                else if (FigureType == PaintType.P_STLINE || FigureType == PaintType.P_ARROW)           //直线
                {
                    if (endPoint != Point.Empty)
                        DrawXorLine(startPoint, endPoint);
                    endPoint = tmp;
                    DrawXorLine(startPoint, endPoint);
                }
                else if (FigureType == PaintType.P_LINES)
                {
                    endPoint.X = e.X;
                    endPoint.Y = e.Y;
                    PosChange(ref endPoint);
                    g.DrawLine(G_pen, startPoint, endPoint);
                    startPoint = endPoint;
                }
                if (FigureType != PaintType.P_LINES)
                    pictureBox1.Image = map;
                pictureBox1.Refresh();
                
            }
            //右键拖动图片
            if (e.Button == MouseButtons.Right)
            {
                if ((e.X - myPoint.X) * (e.X - myPoint.X) + (e.Y- myPoint.Y) * (e.Y - myPoint.Y)<10)
                    return ;
                this.Cursor = Cursors.Hand;
                if (e.X < myPoint.X)
                {
                    try
                    {
                        PictureSizeChang(pictureBox1.Width / 2 + (myPoint.X - e.X), pictureBox1.Height / 2, 0);
                    }
                    catch { }
                }
                if (e.X > myPoint.X)
                {
                    try
                    {
                        PictureSizeChang(pictureBox1.Width / 2 - (e.X - myPoint.X), pictureBox1.Height / 2, 0);
                    }
                    catch { }
                }
                if (e.Y < myPoint.Y)
                {
                    try
                    {
                        PictureSizeChang(pictureBox1.Width / 2, pictureBox1.Height / 2 + (myPoint.Y - e.Y), 0);
                    }
                    catch { }
                }
                if (e.Y > myPoint.Y)
                {
                    try
                    {
                        PictureSizeChang(pictureBox1.Width / 2, pictureBox1.Height / 2 - (e.Y - myPoint.Y), 0);
                    }
                    catch { }
                }
                myPoint.X = e.X;
                myPoint.Y = e.Y;
            }
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void menuStrip1_MouseUp(object sender, MouseEventArgs e)
        {
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
             if (e.Button == MouseButtons.Right)
                 this.Cursor = Cursors.Default;
            if (e.Button == MouseButtons.Left && (g != null && map != null))
            {
                isLMouseDown = false;
                endPoint = new Point(e.X, e.Y);
                PosChange(ref endPoint);
                if (FigureType == PaintType.P_CIRCLE)               //画椭圆
                {
                    DrawEllipse(startPoint, endPoint);
                    pictureBox1.Image = map;
                    g = Graphics.FromImage(pictureBox1.Image);
                    g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                    g.DrawEllipse(G_pen, startPoint.X, startPoint.Y, endPoint.X - startPoint.X, endPoint.Y - startPoint.Y);

                }
                else if (FigureType == PaintType.P_RECTANGLE)      //矩形
                {
                    DrawRectangle(startPoint, endPoint);
                    pictureBox1.Image = map;
                    ReSetPoint(ref startPoint, ref endPoint);
                    g = Graphics.FromImage(pictureBox1.Image);
                    g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                    g.DrawRectangle(G_pen, startPoint.X, startPoint.Y, endPoint.X - startPoint.X, endPoint.Y - startPoint.Y);
                }
                else if (FigureType == PaintType.P_STLINE)     //直线
                {
                    DrawXorLine(startPoint, endPoint);
                    pictureBox1.Image = map;
                    g = Graphics.FromImage(pictureBox1.Image);
                    g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                    g.DrawLine(G_pen, startPoint, endPoint);
                }
                else if (FigureType == PaintType.P_ARROW)
                {
                    DrawXorLine(startPoint, endPoint);
                    pictureBox1.Image = map;
                    g = Graphics.FromImage(pictureBox1.Image);
                    g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                    G_pen.CustomEndCap = new System.Drawing.Drawing2D.AdjustableArrowCap(4, 6);
                    g.DrawLine(G_pen, startPoint.X, startPoint.Y, endPoint.X, endPoint.Y);

                }
                pictureBox1.Refresh();
                cnt = (cnt + 1) % 10;
                myStack[cnt] = pictureBox1.Image.Clone();
                zoom[cnt, 0] = changenum;
                zoom[cnt, 1] = img_x;
                zoom[cnt, 2] = img_y;
                //终点置空
                endPoint = Point.Empty;
            }
        }

        private void 后台运行WToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void notifyIcon1_DoubleClick(object sender, EventArgs e)
        {
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void 实心ToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void 线框ToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void 阴影画刷ToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void 颜色画刷ToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void penToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
        public void ChangeToLines()
        {
            FigureType = PaintType.P_LINES;
            G_pen.EndCap = LineCap.NoAnchor;
        }
        private void 线ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FigureType = PaintType.P_LINES;
            G_pen.EndCap = LineCap.NoAnchor;
        }
        public void ChangeToCircle()
        {
            FigureType = PaintType.P_CIRCLE;
        }
        private void 三角形4ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FigureType = PaintType.P_CIRCLE;
        }
        public void ChangeToStline()
        {
            FigureType = PaintType.P_STLINE;
            G_pen.EndCap = LineCap.NoAnchor;
        }
        private void 三角形2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FigureType = PaintType.P_STLINE;
            G_pen.EndCap = LineCap.NoAnchor;
            //虚线
            // G_pen.DashStyle = DashStyle.Dash;
        }
        public void ChangeToRect()
        {
            FigureType = PaintType.P_RECTANGLE;
        }
        private void 圆形3ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FigureType = PaintType.P_RECTANGLE;
        }

        private void 撤销ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            cnt = (cnt + 9) % 10;
            Image tmp = (Image)myStack[cnt];
            pictureBox1.Image = (Image)(tmp.Clone());
            pictureBox1.Refresh();
        }

        private void 重画ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            cnt = (cnt + 1) % 10;
            Image tmp = (Image)myStack[cnt];
            pictureBox1.Image = (Image)(tmp.Clone());
            pictureBox1.Refresh();
        }
        public void Redo()
        {
            cnt = (cnt + 1) % 10;
            Image tmp = (Image)myStack[cnt];
            pictureBox1.Image = (Image)(tmp.Clone());
            pictureBox1.Refresh();
            img_x = zoom[cnt, 1];
            img_y = zoom[cnt, 2];
            changenum = zoom[cnt, 0];
        }
        public void ReBack()
        {
            cnt = (cnt + 9) % 10;
            Image tmp = (Image)myStack[cnt];
            pictureBox1.Image = (Image)(tmp.Clone());
            pictureBox1.Refresh();
            img_x = zoom[cnt, 1];
            img_y = zoom[cnt, 2];
            changenum = zoom[cnt, 0];
        }
        private void 异或线ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            G_pen.Width += 1;
        }

        private void tuToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void 变细ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            G_pen.Width -= 1;
        }
        public void AddLineWidth()
        {
            G_pen.Width += 1;
        }
        public void RedLineWidth()
        {
            G_pen.Width -= 1;
        }
        public void ChangeToArrow()
        {
            FigureType = PaintType.P_ARROW;
        }
        private void 箭头ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FigureType = PaintType.P_ARROW;
        }
        public void ColorToRed()
        {
            G_pen.Color = Color.Red;
        }
        public void ColorToBlue()
        {
            G_pen.Color = Color.Blue;
        }
        public void ColorToDark()
        {
            G_pen.Color = Color.Black;
        }
        public void ColorToWhite()
        {
            G_pen.Color = Color.White;
        }
    }
}
