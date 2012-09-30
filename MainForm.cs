using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using gma.System.Windows;
using System.IO;
namespace 屏幕绘制
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }
        UserActivityHook Global_hook;
        int Keys_sum, MouseX, MouseY;
        public static DrawForm DrawForm;
        public static bool IsmaxSize;
        bool[] key_save;
        int[,] Hotkey;
        enum mykeys { MODOFIERS = 260, KEYCODE, SHIFT, CONTROL, ALT };

        private void MainForm_Load(object sender, EventArgs e)
        {
            Keys_sum = 0;
            DrawForm = null;
            key_save = new bool[300];
            Hotkey = new int[20, 5];
            for (int i = 0; i < 300; i++)
                key_save[i] = false;
            Global_hook = new UserActivityHook();
            Global_hook.KeyDown += new KeyEventHandler(MyKeyDown);
            Global_hook.KeyUp += new KeyEventHandler(MyKeyUp);
            Global_hook.OnMouseActivity += new MouseEventHandler(MouseMoved);
            //最大化边界设定
            this.MaximizedBounds = Screen.GetWorkingArea(this);
            //默认为最大化按钮
            IsmaxSize = false;
            //一开始有托盘
            notifyIcon1.Visible = true;
          /*  this.Hide();
            this.ShowInTaskbar = false;*/
            SetKey();
            ReadKey();
            LabelTextSet();

        }
        public void LabelTextSet()
        {
            label25.Text = "";
            label25.Text += "    该软件为一款实用的投影演示软件，";
            label25.Text += "软件功能包括屏幕截\r\n图、屏幕放大、屏幕标识，后续功能有待添加。";
            label25.Text += "软件可以由用\r\n户自己设置系统全局快捷键,让你指定热键来更方便的进入缩\r\n放或标注功能。\r\n";
            label25.Text += "\r\n";
            label25.Text += "\r\n";
            label25.Text += "\r\n";
            label25.Text += "\r\n";

        }

        public void MouseMoved(object sender, MouseEventArgs e)
        {
            label1.Text = String.Format("x={0}  y={1} wheel={2}", e.X, e.Y, e.Delta);
        }
        public void MyKeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Modifiers)
                key_save[260] = true;
            else if (e.KeyCode == Keys.KeyCode)
                key_save[261] = true;
            else if (e.KeyCode == Keys.Shift)
                key_save[262] = true;
            else if (e.KeyCode == Keys.Control)
                key_save[263] = true;
            else if (e.KeyCode == Keys.Alt)
                key_save[264] = true;
            else
                key_save[(int)e.KeyCode] = true;
            label1.Text = e.KeyCode.ToString() + "," + ((int)e.KeyCode).ToString();

            for (int i = 1; i <= 15; i++)
            {
                bool judge = true;
                for (int j = 1; j <= Hotkey[i, 0]; j++)
                {
                    if (!key_save[Hotkey[i, j]])
                        judge = false;
                }
                if (judge)
                {
                    switch (i)
                    {
                        case 1:
                            if (DrawForm == null)
                            {
                                DrawForm = new DrawForm();
                                DrawForm.Show();
                            }
                            break;
                        case 2:
                            if (DrawForm != null)
                            {
                                DrawForm.Close();
                                DrawForm = null;
                            }
                            break;
                        case 3:
                            if (DrawForm != null)
                                DrawForm.ChangeToLines();
                            break;
                        case 4:
                            if (DrawForm != null)
                                DrawForm.ChangeToStline();
                            break;
                        case 5:
                            if (DrawForm != null)
                                DrawForm.ChangeToArrow();
                            break;
                        case 6:
                            if (DrawForm != null)
                                DrawForm.ChangeToRect();
                            break;
                        case 7:
                            if (DrawForm != null)
                                DrawForm.ChangeToCircle();
                            break;
                        case 8:
                            if (DrawForm != null)
                                DrawForm.ColorToRed();
                            break;
                        case 9:
                            if (DrawForm != null)
                                DrawForm.ColorToBlue();
                            break;
                        case 10:
                            if (DrawForm != null)
                                DrawForm.ColorToDark();
                            break;
                        case 11:
                            if (DrawForm != null)
                                DrawForm.ColorToWhite();
                            break;
                        case 12:
                            if (DrawForm != null)
                                DrawForm.ReBack();
                            break;
                        case 13:
                            if (DrawForm != null)
                                DrawForm.Redo();
                            break;
                        case 14:
                            if (DrawForm != null)
                                DrawForm.AddLineWidth();
                            break;
                        case 15:
                            if (DrawForm != null)
                                DrawForm.RedLineWidth();
                            break;
                    }
                }
            }
        }
        public void MyKeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Modifiers)
                key_save[260] = false;
            else if (e.KeyCode == Keys.KeyCode)
                key_save[261] = false;
            else if (e.KeyCode == Keys.Shift)
                key_save[262] = false;
            else if (e.KeyCode == Keys.Control)
                key_save[263] = false;
            else if (e.KeyCode == Keys.Alt)
                key_save[264] = false;
            else
                key_save[(int)e.KeyCode] = false;
        }
        private void MainForm_SizeChanged(object sender, EventArgs e)
        {
        }
        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {

        }
        private void button1_Click_1(object sender, EventArgs e)
        {
            Global_hook.Stop();
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Global_hook.Start();
        }

        private void MainForm_DragDrop(object sender, DragEventArgs e)
        {

        }

        private void MainForm_MouseDown(object sender, MouseEventArgs e)
        {
            MouseX = e.X;
            MouseY = e.Y;
        }

        private void MainForm_MouseUp(object sender, MouseEventArgs e)
        {
            this.SetBounds(this.Location.X + (e.X - MouseX), this.Location.Y + (e.Y - MouseY), this.Size.Width, this.Size.Height);
        }

        private void MainForm_MouseMove(object sender, MouseEventArgs e)
        {
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            //this.WindowState = FormWindowState.Minimized;
            this.Hide();
            notifyIcon1.Visible = true;
        }

        private void button3_MouseClick(object sender, MouseEventArgs e)
        {
            if (IsmaxSize)
            {
                this.WindowState = FormWindowState.Maximized;
                button3.Text = "O";
            }
            else
            {
                this.WindowState = FormWindowState.Normal;
                button3.Text = "口";
            }
            IsmaxSize = !IsmaxSize;
        }

        private void notifyIcon1_DoubleClick(object sender, EventArgs e)
        {
            if (IsmaxSize)
                this.Hide();
            else
             this.Show();
            IsmaxSize = !IsmaxSize;
        }
        void ReadKey()
        {

            for (int i = 0; i < 20; i++) Hotkey[i, 0] = 0;
            Hotkey[12, 1] = Hotkey[13, 1] = 162;
            Hotkey[12, 0] = Hotkey[13, 0] = 2;
            Hotkey[12, 2] = (int)'Z';
            Hotkey[13, 2] = (int)'Y';
            Hotkey[14, 0] = Hotkey[15, 0] = 1;
            Hotkey[14, 1] = 107;          //+
            Hotkey[15, 1] = 109;          //-

            for (int index = 0; index < panel1.Controls.Count; index++)
            {
                int id = 0;
                switch (panel1.Controls[index].GetType().Name)
                {
                    case "ComboBox":
                        ComboBox Bx = (ComboBox)panel1.Controls[index];
                        id = int.Parse(panel1.Controls[index].Tag.ToString());
                        if (Bx.Text != "无" && Bx.Text != "")
                        {
                            if (Bx.Text[0] >= 'A' && Bx.Text[0] <= 'Z')
                                Hotkey[id, ++Hotkey[id, 0]] = (int)Bx.Text[0];
                            else if (Bx.Text[0] == '~')
                                Hotkey[id, ++Hotkey[id, 0]] = 192;
                            else if (Bx.Text[0] >= '0' && Bx.Text[0] <= '9')
                                Hotkey[id, ++Hotkey[id, 0]] = (int)Bx.Text[0];
                        }
                        break;
                    case "CheckedListBox":
                        CheckedListBox Cx = (CheckedListBox)panel1.Controls[index];
                        id = int.Parse(panel1.Controls[index].Tag.ToString());
                        if (Cx.GetItemChecked(0))
                            Hotkey[id, ++Hotkey[id, 0]] = 162;
                        if (Cx.GetItemChecked(1))
                            Hotkey[id, ++Hotkey[id, 0]] = 164;
                        if (Cx.GetItemChecked(2))
                            Hotkey[id, ++Hotkey[id, 0]] = 160;
                        break;
                }
            }
        }
        private void WriteToFile(String Filestring)
        {
            FileStream F_save = new FileStream(Filestring, FileMode.OpenOrCreate, FileAccess.Write);
            StreamWriter strwriter = new StreamWriter(F_save);
            for (int i = 1; i <= 11; i++)
            {
                int j, temp = Hotkey[i, 0];
                strwriter.Write(((i) / 10).ToString() + ((i) % 10).ToString() + ' ');
                //Ctrl
                for (j = 1; j <= temp; j++)
                {
                    if (Hotkey[i, j] == 162)
                    {
                        break;
                    }
                }
                if (j > temp) strwriter.Write("0 ");
                else strwriter.Write("1 ");
                //Alt
                for (j = 1; j <= temp; j++)
                {
                    if (Hotkey[i, j] == 164)
                    {
                        break;
                    }
                }
                if (j > temp) strwriter.Write("0 ");
                else strwriter.Write("1 ");
                //Shift
                for (j = 1; j <= temp; j++)
                {
                    if (Hotkey[i, j] == 160)
                    {
                        break;
                    }
                }
                if (j > temp) strwriter.Write("0 ");
                else strwriter.Write("1 ");
                //combobox字符
                //combobox字符
                for (j = 1; j <= temp; j++)
                {
                    if (Hotkey[i, j] < 160 || Hotkey[i, j] == 192)
                    {
                        break;
                    }
                }
                if (j > temp) strwriter.WriteLine(" ");
                else if (Hotkey[i, j] == 192) strwriter.WriteLine("~");
                else strwriter.WriteLine((char)(Hotkey[i, j]));
            }
            strwriter.Close();
        }
        private void SetKey()
        {
            FileInfo F_load = new FileInfo("Log.ini");
            if (!F_load.Exists)
            {
                //MessageBox.Show("File NO Exists!");
                FileStream F_save = new FileStream("Log.ini", FileMode.OpenOrCreate, FileAccess.Write);
                ReSetKey();
                WriteToFile("Log.ini");
            }
            else
            {
                ReadFromFile("Log.ini");
            }
        }
        private void ReadFromFile(String Filestring)
        {
            StreamReader strreader = new StreamReader(Filestring);
            String t;
            for (int i = 1; i <= 11; i++)
            {
                t = strreader.ReadLine();
                for (int index = 0; index < panel1.Controls.Count; index++)
                {
                    int id;
                    switch (panel1.Controls[index].GetType().Name)
                    {
                        case "ComboBox":
                            id = int.Parse(panel1.Controls[index].Tag.ToString());
                            if (id == i)
                            {
                                ComboBox Bx = (ComboBox)panel1.Controls[index];
                                Bx.Text = t[9].ToString();
                            }
                            break;
                        case "CheckedListBox":
                            id = int.Parse(panel1.Controls[index].Tag.ToString());
                            if (id == i)
                            {
                                CheckedListBox Cx = (CheckedListBox)panel1.Controls[index];
                                Cx.SetItemChecked(0, (t[3] - '0') == 0 ? false : true);
                                Cx.SetItemChecked(1, (t[5] - '0') == 0 ? false : true);
                                Cx.SetItemChecked(2, (t[7] - '0') == 0 ? false : true);
                            }
                            break;
                    }
                }
            }
            strreader.Close();
        }
        private void ReSetKey()
        {
            //开始绘制
            checkedListBox1.SetItemChecked(0, true);
            comboBox1.Text = "~";
            //结束绘制
            checkedListBox2.SetItemChecked(1, true);
            comboBox2.Text = "~";
            //随意画
            checkedListBox3.SetItemChecked(0, true);
            comboBox3.Text = "1";
            //画直线
            checkedListBox4.SetItemChecked(0, true);
            comboBox4.Text = "2";
            //画箭头
            checkedListBox5.SetItemChecked(0, true);
            comboBox5.Text = "3";
            //画矩形
            checkedListBox6.SetItemChecked(0, true);
            comboBox6.Text = "4";
            //画椭圆
            checkedListBox7.SetItemChecked(0, true);
            comboBox7.Text = "5";
            comboBox8.Text = "R";
            comboBox9.Text = "B";
            comboBox10.Text = "D";
            comboBox11.Text = "W";
        }
        private void button6_Click(object sender, EventArgs e)
        {
        }

        private void button5_Click(object sender, EventArgs e)
        {

        }

        private void button6_Click_1(object sender, EventArgs e)
        {
            ReSetKey();
        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            int[,] Hotkey_temp = new int[15, 7];
            int[] cal = new int[15];
            int sum;
            int Isfool = 0;
            //保存一份Hotkey
            for (int i = 1; i <= 11; i++)
            {
                Hotkey_temp[i, 0] = Hotkey[i, 0];
                for (int j = 1; j <= Hotkey_temp[i, 0]; j++)
                {
                    Hotkey_temp[i, j] = Hotkey[i, j];
                }
            }
            ReadKey();
            for (int i = 1; i <= 11; i++)
            {
                int temp = Hotkey[i, 0];
                cal[i] = 0;
                for (int j = 1; j <= temp; j++)
                {
                    if (Hotkey[i, j] == 162) cal[i] += (1000);
                    else if (Hotkey[i, j] == 164) cal[i] += (10000);
                    else if (Hotkey[i, j] == 160) cal[i] += (100000);
                    else if (Hotkey[i, j] == 192) cal[i] += (1000000);
                    else cal[i] += Hotkey[i, j];
                }
            }
            for (int i = 1; i <= 11; i++)
            {
                for (int j = 1; j <= 11; j++)
                {
                    if (i == j) continue;
                    if (cal[i] == cal[j])
                    {
                        Isfool = 1;
                        break;
                    }
                }
                if (Isfool == 1) break;
            }
            if (Isfool == 1)
            {
                MessageBox.Show("设置的快捷键冲突了，请重新设置一下!");
                //还原Hotkey
                for (int i = 1; i <= 11; i++)
                {
                    Hotkey[i, 0] = Hotkey_temp[i, 0];
                    for (int j = 1; j <= Hotkey_temp[i, 0]; j++)
                    {
                        Hotkey[i, j] = Hotkey_temp[i, j];
                    }
                }
            }
            else
            {
                WriteToFile("Log.ini");
                MessageBox.Show("保存成功！");
            }

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
