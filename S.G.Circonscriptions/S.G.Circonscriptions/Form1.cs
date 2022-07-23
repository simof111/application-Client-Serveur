using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace S.G.Circonscriptions
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void regionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Region r = new Region();
            r.Show();
            Hide();
        }

        private void partiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Parti p = new Parti();
            p.Show();
            Hide();
        }

        private void condidatToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Candidat c = new Candidat();
            c.Show();
            Hide();

        }

        private void circonscriptionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Circoncription ci = new Circoncription();
            ci.Show();
            Hide();


        }

        private void provinceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Province pr = new Province();
            pr.Show();
            Hide();
        }

        private void tranchAgeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Tranch_Age tr = new Tranch_Age();
            tr.Show();
            Hide();
        }
    }
}
