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

namespace _4_3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        class SharedRes
        {
            public static Mutex mtx = new Mutex();
        }

        private void TextFirst()
        {
            try
            {
                // Получить мьютекс
                SharedRes.mtx.WaitOne();
                listBox1.Invoke((MethodInvoker)delegate ()
                {
                    listBox1.Items.Add("First");
                });
                Thread.Sleep(50);
                // Освободить мьютекс
                SharedRes.mtx.ReleaseMutex();
            }
            catch (Exception ex) {  }
        }
        private void TextSecond()
        {
            try
            {
                // Получить мьютекс
                SharedRes.mtx.WaitOne();
                listBox1.Invoke((MethodInvoker)delegate ()
                {
                    listBox1.Items.Add("Second");
                });
                Thread.Sleep(50);
                // Освободить мьютекс
                SharedRes.mtx.ReleaseMutex();
            }
            catch (Exception ex) { }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 10; i++)
            {
                Thread thread1 = new Thread(TextFirst);
                thread1.Start();
               // Thread.Sleep(1);
                Thread thread2 = new Thread(TextSecond);
                thread2.Start();
            }
   
        }
    }
}
