using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
namespace Data_Salaire
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public SqlConnection cnx = new SqlConnection("data source=(local) ;initial catalog =DataSalaire  ; integrated security =true");
        public SqlCommand cmd = new SqlCommand();
        public SqlDataReader rd;
        private void Form1_Load(object sender, EventArgs e)
        {
            cnx.Open();
            cmd.Connection = cnx;
            cmd.CommandText = "select * from Salaire";
            rd = cmd.ExecuteReader();
            DataTable tab = new DataTable();
            tab.Load(rd);
            dataGridView1.DataSource = tab;
            rd.Close();
            cnx.Close();

            // Combobox impli

            cnx.Open();
            cmd.Connection = cnx;
            cmd.CommandText = "select Code_Employe from Salaire";
            rd = cmd.ExecuteReader();
            DataTable tab2 = new DataTable();
            tab2.Load(rd);
            comboBox1.DataSource = tab2;
            comboBox1.ValueMember = "Code_Employe";
            rd.Close();
            cnx.Close();



        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlDataReader rd;
            CrystalReport2 orv1 = new CrystalReport2();
            cnx.Open();
            cmd.Connection = cnx;
            cmd.CommandText = "select * from Salaire";
            rd = cmd.ExecuteReader();
            DataTable tab = new DataTable();
            tab.Load(rd);
            orv1.SetDataSource(tab);
            crystalReportViewer1.ReportSource = orv1;
            crystalReportViewer1.Refresh();
            rd.Close();
            cnx.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlDataReader rd;
            RPR1 orv2 = new RPR1();
            cnx.Open();
            cmd.Connection = cnx;
            cmd.CommandText = "select * from Salaire where Code_Employe = '"+comboBox1.Text+"'";
            rd = cmd.ExecuteReader();
            DataTable tab = new DataTable();
            tab.Load(rd);
            orv2.SetDataSource(tab);
            crystalReportViewer2.ReportSource = orv2;
            crystalReportViewer2.Refresh();
            rd.Close();
            cnx.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            SqlDataReader rd;
            RPG orv3 = new RPG();
            cnx.Open();
            cmd.Connection = cnx;
            cmd.CommandText = "select Code_Employe, SalaireNete  from Salaire";
            rd = cmd.ExecuteReader();
            DataTable tab = new DataTable();
            tab.Load(rd);
            orv3.SetDataSource(tab);
            crystalReportViewer3.ReportSource = orv3;
            crystalReportViewer3.Refresh();
            rd.Close();
            cnx.Close();
        }
    }
}
