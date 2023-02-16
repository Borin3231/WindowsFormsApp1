using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }


        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
    }

        private void button1_Click(object sender, EventArgs e)
        {
            int f = Convert.ToInt32(textBox1.Text);
            int d = Convert.ToInt32(textBox2.Text);
            Thread myThread1 = new Thread(Print);
            Thread myThread2 = new Thread(new ThreadStart(Print));
            // запускаем поток myThread
            myThread1.Start();

            // действия, выполняемые в главном потоке
            for (int i = 0; i < f; i++)
            {
                listBox1.Items.Add($"Главный поток: {i}");
                Thread.Sleep(400);
            }

            void Print()
            {
                for (int i = 0; i < d; i++)
                {
                    listBox2.Invoke(new Action(() => listBox2.Items.Add($"Второй поток: {i}")));

                    Thread.Sleep(400);
                }
            }
        }
    }
}
