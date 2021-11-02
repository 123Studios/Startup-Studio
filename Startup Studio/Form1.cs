using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Startup_Studio
{
    public partial class Form1 : Form
    {
        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn(
        int nLeftRect,     
        int nTopRect,      
        int nRightRect,    
        int nBottomRect,   
        int nWidthEllipse,
        int nHeightEllipse 
        );
        int mov;
        int movX;
        int movY;
        public Form1()
        {
            InitializeComponent();
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 20, 20));

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
        private void panel2_mousedown(object sender, MouseEventArgs e)
        {
            mov = 1;
            movX = e.X;
            movY = e.Y;
        }

        private void panel2_mousemove(object sender, MouseEventArgs e)
        {
            if (mov == 1)
            {
                this.SetDesktopLocation(MousePosition.X - movX, MousePosition.Y - movY);
            }
        }

        private void panel2_mouseup(object sender, MouseEventArgs e)
        {
            mov = 0;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            MessageBox.Show("Welcome To Startup Studio Thanks For Checking Us Out. Please Note This Application Uses Some Actions That May Trigger Your Anti-Virus To Go Haywire. We Promise And Ensure You That We Are Safe. Our Code Can Always Be Inspected Through DnSpy And You Will See It Contains No Obfuscated Strings Or Any Malware. So Please Make An Exception For It In Your Anti-Virus. Besides That Thank You For Checking Us Out And Please Leave A Star On My GitHub.");
        }
        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);
            if (m.Msg == WM_NCHITTEST)
            m.Result = (IntPtr)(HT_CAPTION);
        }

        private const int WM_NCHITTEST = 0x84;
        private const int HT_CLIENT = 0x1;
        private const int HT_CAPTION = 0x2;

        private void button1_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Process.Start("https://github.com/123Studios/Startup-Studio");
        }

        private void upButton_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPage1;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Coming Soon...", "Startup Studio");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPage2;

        }
    }
}
