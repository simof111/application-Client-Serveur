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
    public partial class Circoncription : Form
    {
        public Circoncription()
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

        private void Circoncription_Load(object sender, EventArgs e)
        {
            TestConnection();
            Cone.Open();
            Com.Connection = Cone;
            Com.CommandText = "select IdCirconcription from Circoncription";
            Read1 = Com.ExecuteReader();
            //DataTable Id = new DataTable();
            //Id.Load(Read1);
            //cmbidprovince.DataSource = Id;
            while (Read1.Read())
            {
                cmbcin.Items.Add(Read1[0].ToString());
            }
            Read1.Close();
            Cone.Close();
        }

        private void cmbcin_SelectedIndexChanged(object sender, EventArgs e)
        {
            // charge de id  
            TestConnection();
            Cone.Open();
            Com.Connection = Cone;
            Com.CommandText = "select nomCirconscription from Circoncription where IdCirconcription = '" + cmbcin.Text + "' ";
            Read1 = Com.ExecuteReader();
            while (Read1.Read())
            {
                cmbnom.Items.Add(Read1[0].ToString());
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
            Com.CommandText = "select * from Circoncription where nomCirconscription = '" + cmbnom.Text + "' ";
            Read1 = Com.ExecuteReader();
            DataTable tbl = new DataTable();
            tbl.Load(Read1);
            dataGridView1.DataSource = tbl;
            Read1.Close();
            Cone.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Cone.Open();
            Com.Connection = Cone;
            Com.CommandText = "select * from Circoncription ";
            Read1 = Com.ExecuteReader();
            DataTable tbl1 = new DataTable();
            tbl1.Load(Read1);
            dataGridView1.DataSource = tbl1;
            Read1.Close();
            Cone.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            TestConnection();
            Cone.Open();
            Com.Connection = Cone;
            Com.CommandText = "insert into Circoncription values('" + dataGridView1[0, dataGridView1.CurrentRow.Index].Value.ToString() + "','" + dataGridView1[1, dataGridView1.CurrentRow.Index].Value.ToString() + "','" + dataGridView1[2, dataGridView1.CurrentRow.Index].Value.ToString() + "','" + dataGridView1[3, dataGridView1.CurrentRow.Index].Value.ToString() + "')";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // validation of insert new values to table
            Com.ExecuteNonQuery();
            Cone.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            dataGridView1[0, dataGridView1.CurrentRow.Index].Value = "";
            dataGridView1[1, dataGridView1.CurrentRow.Index].Value = "";
            dataGridView1[2, dataGridView1.CurrentRow.Index].Value = "";
            dataGridView1[3, dataGridView1.CurrentRow.Index].Value = "";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            TestConnection();
            Cone.Open();
            Com.Connection = Cone;
            Com.CommandText = "delete from Circoncription where IdCirconcription = '" + (dataGridView1[0, dataGridView1.CurrentRow.Index].Value).ToString() + "'";
            Com.ExecuteNonQuery();
            Cone.Close();
        }
    }
}
