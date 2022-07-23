using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
namespace S.G.Circonscriptions
{
    public partial class Candidat : Form
    {
        public Candidat()
        {
            InitializeComponent();
        }
        public static SqlConnection Cone = new SqlConnection("data source=(local) ;initial catalog =Gestion Electorale v1 ; integrated security =true");
        public static SqlCommand Com = new SqlCommand();
        public static SqlDataReader Read1;

        public void TestConnection()
        {
            if (Cone.State == ConnectionState.Open)
            {
                Cone.Close();
            }
        }
        private void button3_Click(object sender, EventArgs e)
        {
            TestConnection();
            Cone.Open();
            Com.Connection = Cone;
            Com.CommandText = "insert into Candidat values('" + dataGridView1[0, dataGridView1.CurrentRow.Index].Value.ToString() + "','" + dataGridView1[1, dataGridView1.CurrentRow.Index].Value.ToString() + "','" + dataGridView1[2, dataGridView1.CurrentRow.Index].Value.ToString() + "','" + dataGridView1[3, dataGridView1.CurrentRow.Index].Value.ToString() + "','" + dataGridView1[4, dataGridView1.CurrentRow.Index].Value.ToString() + "','" + dataGridView1[5, dataGridView1.CurrentRow.Index].Value.ToString() + "','" + dataGridView1[6, dataGridView1.CurrentRow.Index].Value.ToString() + "','" + dataGridView1[7, dataGridView1.CurrentRow.Index].Value.ToString() + "','" + dataGridView1[8, dataGridView1.CurrentRow.Index].Value.ToString() + "','" + dataGridView1[9, dataGridView1.CurrentRow.Index].Value.ToString() + "')";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // validation of insert new values to table
            Com.ExecuteNonQuery();
            Cone.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            TestConnection();
            Cone.Open();
            Com.Connection = Cone;
            Com.CommandText = "delete from Candidat where CINCandidat = '" + (dataGridView1[0, dataGridView1.CurrentRow.Index].Value).ToString() + "'";
            Com.ExecuteNonQuery();
            Cone.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            dataGridView1[0, dataGridView1.CurrentRow.Index].Value = "";
            dataGridView1[1, dataGridView1.CurrentRow.Index].Value = "";
            dataGridView1[2, dataGridView1.CurrentRow.Index].Value = "";
            dataGridView1[3, dataGridView1.CurrentRow.Index].Value = "";
            dataGridView1[4, dataGridView1.CurrentRow.Index].Value = "";
            dataGridView1[5, dataGridView1.CurrentRow.Index].Value = "";
            dataGridView1[6, dataGridView1.CurrentRow.Index].Value = "";
            dataGridView1[7, dataGridView1.CurrentRow.Index].Value = "";
            dataGridView1[8, dataGridView1.CurrentRow.Index].Value = "";
            dataGridView1[9, dataGridView1.CurrentRow.Index].Value = "";
        }

        private void button5_Click(object sender, EventArgs e)
        {
            
            Cone.Open();
            Com.Connection = Cone;
            Com.CommandText = "select * from Candidat ";
            Read1 = Com.ExecuteReader();
            DataTable tbl1 = new DataTable();
            tbl1.Load(Read1);
            dataGridView1.DataSource = tbl1;
            Read1.Close();
            Cone.Close();
        }

        private void cmbcondidat_SelectedIndexChanged(object sender, EventArgs e)
        {
            // charge de datadrid view 
            TestConnection();
            Cone.Open();
            Com.Connection = Cone;
            Com.CommandText = "select NomCandidat from Candidat where CINCandidat = '" + cmbcondidat.Text + "' ";
            Read1 = Com.ExecuteReader();
            while (Read1.Read())
            {
                cmbnom.Items.Add(Read1[0].ToString());
            }
            Read1.Close();
            Cone.Close();
        }

        private void Candidat_Load(object sender, EventArgs e)
        {
            TestConnection();
            Cone.Open();
            Com.Connection = Cone;
            Com.CommandText = "select CINCandidat from Candidat";
            Read1 = Com.ExecuteReader();
            //DataTable Id = new DataTable();
            //Id.Load(Read1);
            //cmbidprovince.DataSource = Id;
            while (Read1.Read())
            {
                cmbcondidat.Items.Add(Read1[0].ToString());
            }
            Read1.Close();
            Cone.Close();

        }

        private void cmbnom_SelectedIndexChanged(object sender, EventArgs e)
        {
            // charge de datadrid view 
            TestConnection();
            Cone.Open();
            Com.Connection = Cone;
            Com.CommandText = "select * from Candidat where NomCandidat = '" + cmbnom.Text + "' ";
            Read1 = Com.ExecuteReader();
            DataTable tbl = new DataTable();
            tbl.Load(Read1);
            dataGridView1.DataSource = tbl;
            Read1.Close();
            Cone.Close();
        }
    }
}
