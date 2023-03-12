using System;
using System.Windows.Forms;


namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        int timerInterval = 500;
        int lastSymbol = 0;
        int pass_count = 0;
        int err_count = 0;
        Random rnd = new Random();
        Timer timer = new Timer();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.MinimizeBox = false;
            this.MaximizeBox = false;
            timer.Tick += new EventHandler(timerCallback);
            trackBar1.Minimum = timerInterval;
            trackBar1.Maximum = timerInterval + 500;
            trackBar1.Value = trackBar1.Maximum;
        }

        private void timerCallback(object sender, EventArgs e)
        {
            lastSymbol = rnd.Next(1072, 1103);
            if (textBox1.Text.Length < 10)
                textBox1.Text += (char)lastSymbol;
            else
            {
                timer.Stop();
                btn_start.Enabled = true;
                MessageBox.Show("Игра окончена");
            }
        }

        private void btn_start_Click(object sender, EventArgs e)
        {
            if (timer.Enabled) return;
            pass_count = 0;
            err_count = 0;
            textBox1.Text = "";
            lbl_pass_count.Text = pass_count.ToString();
            lbl_err_count.Text = err_count.ToString();
            timer.Interval = timerInterval;
            textBox1.Focus();
            timer.Start();
            btn_start.Enabled = false;
        }

        private void btn_stop_Click(object sender, EventArgs e)
        {
            if (timer.Enabled)
            {
                timer.Stop();
                btn_start.Enabled = true;
            }
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
            if (timer.Enabled)
            {
                if (e.KeyChar == lastSymbol)
                {
                    string text = textBox1.Text;
                    textBox1.Text = text.Substring(0, text.Length - 1);
                    pass_count++;
                    lbl_pass_count.Text = pass_count.ToString();
                }
                else
                {
                    err_count++;
                    lbl_err_count.Text = err_count.ToString();
                }
            }
        }

        private void trackBar1_ValueChanged(object sender, EventArgs e)
        {
            timerInterval = trackBar1.Value;
        }
    }
}
