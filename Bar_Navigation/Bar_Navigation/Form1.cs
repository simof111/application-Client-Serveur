using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
namespace Bar_Navigation
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public SqlConnection cnx = new SqlConnection("data source=(local) ;initial catalog =G_Data_ADO.NET  ; integrated security =true");
        public SqlCommand cmd = new SqlCommand();
        public SqlDataAdapter adp;
        public DataSet ds;
        private void Form1_Load(object sender, EventArgs e)
        {
            cnx.Open();
            cmd.Connection = cnx;
            cmd.CommandText = "select * from Pilote";
            adp = new SqlDataAdapter();
            ds = new DataSet();
            adp.SelectCommand = cmd;
            adp.Fill(ds, "Pilote");
            cnx.Close();
            BindingSource bs = new BindingSource(ds.Tables["Pilote"],null);
            bindingNavigator1.BindingSource = bs;
            comboBox1.DataSource = bs;
            comboBox1.ValueMember = "Code";
            dataGridView1.DataSource = bs;
            txtnom.Text = dataGridView1[0, dataGridView1.CurrentRow.Index].Value.ToString();
            txtprenom.Text = dataGridView1[1, dataGridView1.CurrentRow.Index].Value.ToString();
            txtgrade.Text = dataGridView1[2, dataGridView1.CurrentRow.Index].Value.ToString(); 

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }

        private void dataGridView1_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            txtnom.Text = dataGridView1[0, dataGridView1.CurrentRow.Index].Value.ToString();
            txtprenom.Text = dataGridView1[1, dataGridView1.CurrentRow.Index].Value.ToString();
            txtgrade.Text = dataGridView1[2, dataGridView1.CurrentRow.Index].Value.ToString(); 
        }
    }
}
