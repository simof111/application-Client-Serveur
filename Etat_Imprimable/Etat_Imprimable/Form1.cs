using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Configuration;


namespace Etat_Imprimable
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public static SqlConnection Cone = new SqlConnection("data source=(local) ;initial catalog = Gestion_Comm ; integrated security =true");
        public static SqlCommand Com = new SqlCommand();
        public static SqlDataReader Read1;
        public static SqlDataReader DR1;
       

        private void Form1_Load(object sender, EventArgs e)
        {

            Cone.Open();
            Com.Connection = Cone;
            Com.CommandText = "select NCom from Commande";
            DR1 = Com.ExecuteReader();
            DataTable d = new DataTable();
            d.Load(DR1);
            comboBox1.DataSource = d;
            comboBox1.ValueMember = "NCom";
            DR1.Close();
            Cone.Close();

            
        }

        private void btconfirm_Click(object sender, EventArgs e)
        {

        }

        private void btconfirm_Click_1(object sender, EventArgs e)
        {
            CrystalReport1 orv1 = new CrystalReport1();
            Cone.Open();
            Com.Connection = Cone;
            Com.CommandText = "select Commande.CIN, Commande.NCom, Referance,  Prix_U from Commande inner join Detail on Commande.NCom = Detail.NCom where Commande.NCom ='"+comboBox1.Text+"'";
            Read1 = Com.ExecuteReader();
            DataTable tab = new DataTable();
            tab.Load(Read1);
            orv1.SetDataSource(tab);
            crystalReportViewer1.ReportSource = orv1;
            crystalReportViewer1.Refresh();
            Read1.Close();
            Cone.Close();
           
        }
    }
}
