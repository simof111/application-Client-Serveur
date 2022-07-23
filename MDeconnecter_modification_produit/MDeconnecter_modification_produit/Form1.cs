using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace MDeconnecter_modification_produit
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        // remplisage de DataGridView

        public void RemDataGrid()
        {
            if (oa.Ds.Tables["Produit"] != null)
            {
                oa.Ds.Tables["Produit"].Clear();
            }

            oa.Connecter();
            oa.ADP = new SqlDataAdapter("select * from Produit", oa.Con);
            oa.ADP.Fill(oa.Ds, "Produit");
            dataGridView1.DataSource = oa.Ds.Tables[0];
        }

        // remplisage de Combobox
        public void RemCombobox()

        {
            if (oa.Ds.Tables["Namepro"] != null)
            {
                oa.Ds.Tables["Namepro"].Clear();
            }

            oa.ADP = new SqlDataAdapter("select * from Namepro", oa.Con);
            oa.ADP.Fill(oa.Ds, "Namepro");
            cmbdes.DataSource = oa.Ds.Tables["Namepro"];
            cmbdes.DisplayMember = "Designation";
            cmbdes.ValueMember = "Num";
        }

        public ADO oa = new ADO();
        private void Form1_Load(object sender, EventArgs e)
        {
            RemDataGrid();
            RemCombobox();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (txtcodepro.Text == " " || txtlibelle.Text == "" || txtquantite.Text == "")
            {
                MessageBox.Show("Remplir Tous les Champs please !!");
                return;
            }

            oa.Drow = oa.Ds.Tables["Produit"].NewRow();
            oa.Drow[0] = txtcodepro.Text;
            oa.Drow[1] = txtlibelle.Text;
            oa.Drow[2] = cmbdes.Text;
            oa.Drow[3] = txtquantite.Text;

            for (int i = 0; i < oa.Ds.Tables["Produit"].Rows.Count; i++)
            {
                if (txtcodepro.Text == oa.Ds.Tables["Produit"].Rows[i][0].ToString())
                {
                    MessageBox.Show("le Produit existe deja (are you fucking serious !!) ");
                    return;
                }
            }

            oa.Ds.Tables["Produit"].Rows.Add(oa.Drow);
            MessageBox.Show("le Produit ajouter avec succes");
            dataGridView1.DataSource = oa.Ds.Tables["Produit"];
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (txtcodepro.Text == "")
            {
                MessageBox.Show("Donner code de produit");
                return;
            }

            bool trouve = false;
            for (int i = 0; i < oa.Ds.Tables["Produit"].Rows.Count; i++)
            {
                if (txtcodepro.Text == oa.Ds.Tables["Produit"].Rows[i][0].ToString())
                {
                    trouve = true;
                    oa.Ds.Tables["Produit"].Rows[i].Delete();
                    MessageBox.Show("le Produit est Supprimer avec succes");
                    dataGridView1.DataSource = oa.Ds.Tables["Produit"];
                    break;
                }
                
            }
            if (trouve == false)
            {
                MessageBox.Show("le produit pas existe");
                return;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            txtcodepro.Text = "";
            txtlibelle.Text = "";
            txtquantite.Text = "";
            cmbdes.Text = "";
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {

            if (txtcodepro.Text == " " || txtlibelle.Text == "" || txtquantite.Text == "")
            {
                MessageBox.Show("Remplir Tous les Champs please !!");
                return;
            }

            bool trouve = false;
            for (int i = 0; i < oa.Ds.Tables["Produit"].Rows.Count; i++)
            {
                if (txtcodepro.Text == oa.Ds.Tables["Produit"].Rows[i][0].ToString())
                {
                    trouve = true;
                    oa.Ds.Tables["Produit"].Rows[i][1] = txtlibelle.Text;
                    oa.Ds.Tables["Produit"].Rows[i][2] = txtlibelle.Text;
                    oa.Ds.Tables["Produit"].Rows[i][3] = cmbdes.Text;
                    MessageBox.Show("le Produit est Modifier avec succes");
                    dataGridView1.DataSource = oa.Ds.Tables["Produit"];
                    break;
                }

            }
            if (trouve == false)
            {
                MessageBox.Show("le produit pas existe");
                return;
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            oa.Cmb = new SqlCommandBuilder(oa.ADP);
            oa.ADP.Update(oa.Ds, "Produit");
            MessageBox.Show("la Modification est Enregistrer ^_^ ");
        }
    }
}
