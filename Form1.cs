using System;
/*using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;*/
using System.Windows.Forms;


namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        static int timerStart = 2000;
        string str = "";
        int lastSymbol = 0;
        int pass_count = 0;
        int err_count = 0;
        Random rnd = new Random();
        Timer timer = new Timer();

        public Form1()
        {
            InitializeComponent();
        }

        private void timerCallback(object sender, EventArgs ea)
        {
            lastSymbol = rnd.Next(1072, 1103);
            if (str.Length < 10)
            {
                str += (char)lastSymbol;
                textBox1.Text = str;
            }
            else
            {
                timer.Stop();
                MessageBox.Show("Игра окончена");
            }
        }

        private void btn_start_Click(object sender, EventArgs e)
        {
            pass_count = 0;
            err_count = 0;
            lbl_pass_count.Text = pass_count.ToString();
            lbl_err_count.Text = err_count.ToString();
            timer.Interval = timerStart;
            timer.Tick += new EventHandler(timerCallback);
            timer.Start();
            textBox1.Focus();
        }

        private void btn_stop_Click(object sender, EventArgs e)
        {
            if(timer.Enabled) timer.Stop();
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
            if (timer.Enabled)
            {
                if (e.KeyChar == lastSymbol)
                {
                    str = str.Substring(0, str.Length - 1);
                    pass_count++;
                    textBox1.Text = str;
                    lbl_pass_count.Text = pass_count.ToString();
                }
                else
                {
                    err_count++;
                    lbl_err_count.Text = err_count.ToString();
                }
            }
        }

        /*private void trackBar1_ValueChanged(object sender, EventArgs e)
        {
            textBox2.Clear();
            textBox2.Text += trackBar1.Value.ToString();
        }*/
    }
}
