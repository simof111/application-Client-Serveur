using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
namespace Proc_Output
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

        private void label1_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("SPoutnb2", Cone);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlParameter pcount = new SqlParameter("@count", SqlDbType.Int);
            pcount.Direction = ParameterDirection.Output;
            cmd.Parameters.Add(pcount);
            Cone.Open();
            cmd.ExecuteNonQuery();
            textBox1.Text = pcount.Value.ToString();
            Cone.Close();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            SqlCommand a = new SqlCommand("defupdate", Cone);
            a.CommandType = CommandType.StoredProcedure;
            Com.CommandType = CommandType.StoredProcedure;
            Com.CommandText = "defupdate";
            SqlParameter pcode = new SqlParameter("@code", SqlDbType.VarChar);
            SqlParameter pprenom = new SqlParameter("@prenom", SqlDbType.VarChar);
            SqlParameter pcout = new SqlParameter("@pcout", SqlDbType.VarChar);

            pcode.Value = dataGridView1[0, dataGridView1.CurrentRow.Index].Value;
            pprenom.Value = dataGridView1[2, dataGridView1.CurrentRow.Index].Value;
            pcout.Direction = ParameterDirection.Output;

            Com.Parameters.Add(pcode);
            Com.Parameters.Add(pprenom);
            Com.Parameters.Add(pcout);

            Cone.Open();
            Com.ExecuteNonQuery();
            a.ExecuteNonQuery();
            textBox2.Text = pcout.Value.ToString();
            Cone.Close();
            
           

        }

        private void button1_Click(object sender, EventArgs e)
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

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
