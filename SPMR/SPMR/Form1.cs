using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SPMR
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Pbstart.Increment(2);
            pvalue.Text = Pbstart.Value + "%";
            if(Pbstart.Value==100)
            {
                timer1.Stop();
                Form2 f2 = new Form2();
                f2.Show();
                Hide();

            }
           
        }
    }
}
