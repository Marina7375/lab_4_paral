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
namespace lab_4_32
{
    public partial class Form1 : Form
    {
        private static Semaphore sem;

        public Form1()
        {
            InitializeComponent();
          
        }
        
           
        private void TextFirst()
        {
           
                // Получить семафор
                sem.WaitOne();
                listBox1.Invoke((MethodInvoker)delegate ()
                {
                    listBox1.Items.Add("First");
                });
                Thread.Sleep(50);
                // Освободить семафор
                sem.Release();
                    
        }
        private void TextSecond()
        {
            
                // Получить семафор
                sem.WaitOne();
                listBox1.Invoke((MethodInvoker)delegate ()
                {
                    listBox1.Items.Add("Second");
                });
                Thread.Sleep(50);
                // Освободить семафор
                sem.Release();
            
        }
        private void button1_Click(object sender, EventArgs e)
        {
           sem= new Semaphore(1, 1);
            for (int i = 0; i < 10; i++)
            {
                Thread thread1 = new Thread(TextFirst);
                thread1.Start();
                 Thread.Sleep(1);
                Thread thread2 = new Thread(TextSecond);
                thread2.Start();
            }

        }
    }
}

