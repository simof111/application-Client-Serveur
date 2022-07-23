using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace M22_EFF
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void employeeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Employee em = new Employee();
            em.Show();
            Hide();
        }

        private void responseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Reponse rep = new Reponse();
            rep.Show();
            Hide();
        }

        private void questionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Question qe = new Question();
            qe.Show();
            Hide();

        }

        private void quitterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
