using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Timer
{   
    public partial class Form1 : Form
    {
        UInt16 Timer_Value = 0;
        UInt16 Timer_Count = 0;
        byte Timer_Status = 0; // 0 - 停止  1 - 计时  2 - 暂停

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            byte i;
            for (i = 0; i < 60; i++)
            {
                comboBox1.Items.Add(i.ToString());
                comboBox2.Items.Add(i.ToString());
            }

            comboBox1.Text = "0";
            comboBox2.Text = "0";

            button2.Enabled = false;
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            switch (Timer_Status)
            {
                case 0:
                    {
                        Timer_Value = Convert.ToUInt16(comboBox1.Text, 10);
                        Timer_Value *= 60;
                        Timer_Value += Convert.ToUInt16(comboBox2.Text, 10);

                        if (Timer_Value > 0)
                        {
                            textBox1.Text = Timer_Value.ToString();
                            button1.Text = "暂停计时";
                            button2.Enabled = true;
                            comboBox1.Enabled = false;
                            comboBox2.Enabled = false;
                            Timer_Status = 1;
                            timer1.Enabled = true;
                        }
                        else
                        {
                            MessageBox.Show("定时时间不能为“0”！", "警告");
                        }

                        break;
                    }
                case 1:
                    {
                        button1.Text = "恢复计时";
                        button2.Enabled = true;
                        timer1.Stop();
                        Timer_Status = 2;

                        break;
                    }
                case 2:
                    {
                        button1.Text = "暂停计时";
                        button2.Enabled = true;
                        timer1.Start();
                        Timer_Status = 1;

                        break;
                    }
                default:
                    {
                        break;
                    }
            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            button2.Enabled = false;
            button1.Text = "开始计时";
            comboBox1.Enabled = true;
            comboBox2.Enabled = true;
            timer1.Enabled = false;
            textBox1.Clear();
            progressBar1.Value = 0;
            Timer_Status = 0;
            Timer_Count = 0;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Timer_Count++;

            progressBar1.Maximum = Timer_Value;
            if (Timer_Value == 1)
            {
                progressBar1.Value = 1;
            }
            else
            {
                progressBar1.Value = Timer_Count;
            }

            textBox1.Text = (Timer_Value - Timer_Count).ToString();

            if (Timer_Count == Timer_Value)
            {
                timer1.Enabled = false;
                Timer_Count = 0;

                button1.Text = "计时结束";
                MessageBox.Show("时间到了!", "提示");

                button1.Text = "开始计时";
                button2.Enabled = false;
                textBox1.Clear();
                progressBar1.Value = 0;
                Timer_Status = 0;
                comboBox1.Enabled = true;
                comboBox2 .Enabled = true;
            }
        }

        private void progressBar1_Click(object sender, EventArgs e)
        {

        }
    }
}
