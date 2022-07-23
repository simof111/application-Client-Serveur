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
    public partial class Province : Form
    {
        public Province()
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

        private void Province_Load(object sender, EventArgs e)
        {
            TestConnection();
            Cone.Open();
            Com.Connection = Cone;
            Com.CommandText = "select IdprovPref from ProvincePrefecture";
            Read1 = Com.ExecuteReader();
            //DataTable Id = new DataTable();
            //Id.Load(Read1);
            //cmbidprovince.DataSource = Id;
            while (Read1.Read())
            {
                cmbidprovince.Items.Add(Read1[0].ToString());
            }
            Read1.Close();
            Cone.Close();

        }

        private void cmbidprovince_SelectedIndexChanged(object sender, EventArgs e)
        {
            // charge de datadrid view 
            TestConnection();
            Cone.Open();
            Com.Connection = Cone;
            Com.CommandText = "select * from ProvincePrefecture where IdprovPref = '"+cmbidprovince.Text+"' ";
            Read1 = Com.ExecuteReader();
            DataTable dataprovince = new DataTable();
            dataprovince.Load(Read1);
            dataGridView1.DataSource = dataprovince;
            Cone.Close();

           
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // nombre de province par region 
            TestConnection();
            Cone.Open();
            Com.Connection = Cone;
            Com.CommandText = "select  count(*) from ProvincePrefecture where IdRegion = '" + (dataGridView1[2, dataGridView1.CurrentRow.Index].Value).ToString() + "'";

            label4.Text = Com.ExecuteScalar().ToString();
            Cone.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            TestConnection();
            Cone.Open();
            Com.Connection = Cone;
            Com.CommandText = "delete from ProvincePrefecture where IdProvPref = '" + (dataGridView1[0, dataGridView1.CurrentRow.Index].Value).ToString() + "'";
            Com.ExecuteNonQuery();
            Cone.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            
                TestConnection();
                Cone.Open();
                Com.Connection = Cone;
                Com.CommandText = "insert into ProvincePrefecture values('" + dataGridView1[0, dataGridView1.CurrentRow.Index].Value + "','" + dataGridView1[1, dataGridView1.CurrentRow.Index].Value + "','" + dataGridView1[2, dataGridView1.CurrentRow.Index].Value + "')";
          
            
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
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Cone.Open();
            Com.Connection = Cone;
            Com.CommandText = "select * from ProvincePrefecture ";
            Read1 = Com.ExecuteReader();
            DataTable tbl1 = new DataTable();
            tbl1.Load(Read1);
            dataGridView1.DataSource = tbl1;
            Read1.Close();
            Cone.Close();
            
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
