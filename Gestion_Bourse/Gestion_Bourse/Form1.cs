using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
namespace Gestion_Bourse
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public SqlConnection cnx = new SqlConnection(@"Data Source=.;Initial Catalog=DataBourse;Integrated Security=True");
        public SqlCommand cmd = new SqlCommand();
        public SqlDataReader rd;

        public void Connection()
        {
            if (cnx.State == ConnectionState.Open)
            {
                cnx.Close();
            }
            cnx.Open();
            cmd.Connection = cnx;

        }

        public void ShowDG(DataGridView dg, String script)
        {
            Connection();
            cmd.Connection = cnx;
            cmd.CommandText = script;
            rd = cmd.ExecuteReader();
            DataTable tab = new DataTable();
            tab.Load(rd);
            dg.DataSource = tab;
            rd.Close();
            cnx.Close();
        }
        //ComboBox

        public void Form1_Load(object sender, EventArgs e)
        {
            
            ShowDG(dataGridView1, "select * from TransactionBourse");
        }
    }
}
