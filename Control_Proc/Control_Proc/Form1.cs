using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
namespace Control_Proc
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public static SqlConnection Cone = new SqlConnection("Data Source=.;Initial Catalog=Gestion_Notes;Integrated Security=True");
        public static SqlCommand Cmb = new SqlCommand();
        public static SqlDataReader Rd;

        public void ShowSection()
        {
            Cone.Open();
            Cmb.Connection = Cone;
            Cmb.CommandText = "Select *  from Section";
            Rd = Cmb.ExecuteReader();
            DataTable tabsec = new DataTable();
            tabsec.Load(Rd);
            dataGridView1.DataSource = tabsec;
            Rd.Close();
            Cone.Close();
        }

        public void ShowNote()
        {
            Cone.Open();
            Cmb.Connection = Cone;
            Cmb.CommandText = "Select *  from Note";
            Rd = Cmb.ExecuteReader();
            DataTable tabsec = new DataTable();
            tabsec.Load(Rd);
            dataGridView1.DataSource = tabsec;
            Rd.Close();
            Cone.Close();
        }

        public void ShowStagiaire()
        {
            Cone.Open();
            Cmb.Connection = Cone;
            Cmb.CommandText = "Select *  from Stagiaire";
            Rd = Cmb.ExecuteReader();
            DataTable tabsec = new DataTable();
            tabsec.Load(Rd);
            dataGridView1.DataSource = tabsec;
            Rd.Close();
            Cone.Close();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            ShowSection();
            
        }

        private void cmbsupprimer_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            Cone.Close();
            SqlCommand Cmbproc = new SqlCommand("SPDeleteSection",Cone);
         
            Cmbproc.CommandType = CommandType.StoredProcedure;
            SqlParameter pcodesection = new SqlParameter("@codesection", SqlDbType.VarChar);
            pcodesection.Value = cmbsupprimer.Text;
            Cmbproc.Parameters.Add(pcodesection);
            Cone.Open();
            Cmbproc.Connection = Cone;
            Cmbproc.ExecuteNonQuery();
            Cone.Close();
            ShowSection();
 
        }
    }
}
