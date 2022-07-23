using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
namespace Procedure
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public static SqlConnection Cone = new SqlConnection("data source=(local) ;initial catalog =G_Data_ADO.NET  ; integrated security =true");
        public static SqlCommand Com = new SqlCommand();
        public static SqlDataReader Read1;

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Cone.Open();
            Com.Connection = Cone;
            Com.CommandType = CommandType.StoredProcedure;
            SqlParameter pcode = new SqlParameter("@code", SqlDbType.VarChar);
            SqlParameter pnom = new SqlParameter("@nom", SqlDbType.VarChar);
            SqlParameter pprenom = new SqlParameter("@prenom", SqlDbType.VarChar);
            SqlParameter pgrade = new SqlParameter("@grade", SqlDbType.VarChar);
            
           // pcode.Value = Convert.ToInt32( textBox1.Text);
           // pname.Value = textBox2.Text;
            Com.Parameters.Add(pcode);
            Com.Parameters.Add(pnom);
            Com.Parameters.Add(pprenom);
            Com.Parameters.Add(pgrade);
            pcode.Value = dataGridView1[0, dataGridView1.CurrentRow.Index].Value;
            pnom.Value = dataGridView1[1, dataGridView1.CurrentRow.Index].Value;
            pprenom.Value = dataGridView1[2, dataGridView1.CurrentRow.Index].Value;
            pgrade.Value = dataGridView1[3, dataGridView1.CurrentRow.Index].Value;
            Com.CommandText = "SPInsertPilote1";
            Com.ExecuteNonQuery();
            Cone.Close();
            Com.Parameters.Clear();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Cone.Open();
            Com.Connection = Cone;
            Com.CommandType = CommandType.StoredProcedure;
            Com.CommandText = "Affichage_Vol";
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
            Com.CommandType = CommandType.StoredProcedure;
            Com.CommandText = "Affichage_Avion";
            Read1 = Com.ExecuteReader();
            DataTable tbl = new DataTable();
            tbl.Load(Read1);
            dataGridView1.DataSource = tbl;
            Read1.Close();
            Cone.Close();

        }

        private void button6_Click(object sender, EventArgs e)
        {
            Cone.Open();
            Com.Connection = Cone;
            
            Com.CommandText = "select * from Pilote";
            Read1 = Com.ExecuteReader();
            DataTable tbl = new DataTable();
            tbl.Load(Read1);
            dataGridView1.DataSource = tbl;
            Read1.Close();
            Cone.Close();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Cone.Open();
            Com.Connection = Cone;
            Com.CommandType = CommandType.StoredProcedure;
            SqlParameter pnumero = new SqlParameter("@numero", SqlDbType.VarChar);
            SqlParameter pmarque = new SqlParameter("@marque", SqlDbType.VarChar);
            SqlParameter pserie = new SqlParameter("@serie", SqlDbType.VarChar);
            SqlParameter ptype = new SqlParameter("@type", SqlDbType.VarChar);
            SqlParameter paerpot = new SqlParameter("@arepot", SqlDbType.VarChar);
            SqlParameter pdate = new SqlParameter("@date_m_c", SqlDbType.Date);
            SqlParameter pnbplace = new SqlParameter("@nbpalce", SqlDbType.Int);


            Com.Parameters.Add(pnumero);
            Com.Parameters.Add(pmarque);
            Com.Parameters.Add(pserie);
            Com.Parameters.Add(ptype);
            Com.Parameters.Add(paerpot);
            Com.Parameters.Add(pdate);
            Com.Parameters.Add(pnbplace);

            pnumero.Value = dataGridView1[0, dataGridView1.CurrentRow.Index].Value;
            pmarque.Value = dataGridView1[1, dataGridView1.CurrentRow.Index].Value;
            pserie.Value = dataGridView1[2, dataGridView1.CurrentRow.Index].Value;
            ptype.Value = dataGridView1[3, dataGridView1.CurrentRow.Index].Value;
            paerpot.Value = dataGridView1[4, dataGridView1.CurrentRow.Index].Value;
            pdate.Value = dataGridView1[5, dataGridView1.CurrentRow.Index].Value;
            pnbplace.Value = dataGridView1[6, dataGridView1.CurrentRow.Index].Value;

            Com.CommandText = "SPUpdateAvion";
            Com.ExecuteNonQuery();
            Cone.Close();
            Com.Parameters.Clear();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Cone.Open();
            Com.Connection = Cone;
            Com.CommandType = CommandType.StoredProcedure;
            SqlParameter pcode = new SqlParameter("@code", SqlDbType.VarChar);
            Com.Parameters.Add(pcode);
            pcode.Value = dataGridView1[0, dataGridView1.CurrentRow.Index].Value;
            Com.CommandText = "SPDeletePilote";
            Com.ExecuteNonQuery();
            Cone.Close();
            Com.Parameters.Clear();
        }
    }
}
