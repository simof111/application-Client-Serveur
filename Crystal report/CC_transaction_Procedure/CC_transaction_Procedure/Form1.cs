using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace CC_transaction_Procedure
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public static SqlConnection Cone = new SqlConnection("Data Source=.;Initial Catalog=Gestion_Notes;Integrated Security=True");
        public static SqlCommand Cmb = new SqlCommand();
        public static SqlCommand Cmb1 = new SqlCommand();

        public static SqlDataReader Rd;
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        public void ImpStagiaire()
        {
            Cone.Open();
            Cmb1.Connection = Cone;
            Cmb1.CommandText = "Select Matricule from Stagiaire";
            Rd = Cmb1.ExecuteReader();
            DataTable tabsec = new DataTable();
            tabsec.Load(Rd);
            cmbStagajout.DataSource = tabsec;
            cmbStagajout.ValueMember = "Matricule";
            Rd.Close();
            Cone.Close();
 
        }

        public void ImpModule()
        {
            Cone.Open();
            Cmb1.Connection = Cone;
            Cmb1.CommandText = "Select Numero  from Module";
            Rd = Cmb1.ExecuteReader();
            DataTable tabmod = new DataTable();
            tabmod.Load(Rd);
            cmbmoduleajout.DataSource = tabmod;
            cmbmoduleajout.ValueMember = "Numero";
            Rd.Close();
            Cone.Close();

        }

        public void ImpFor()
        {
            Cone.Open();
            Cmb1.Connection = Cone;
            Cmb1.CommandText = "Select Matricule  from Formateur";
            Rd = Cmb1.ExecuteReader();
            DataTable tbafor = new DataTable();
            tbafor.Load(Rd);
            cmbformatajout.DataSource = tbafor;
            cmbformatajout.ValueMember = "Matricule";
            Rd.Close();
            Cone.Close();

        }

        public void ImpSection()
        {
            Cone.Open();
            Cmb.Connection = Cone;
            Cmb.CommandText = "Select Code from Section";
            Rd = Cmb.ExecuteReader();
            DataTable tabsec = new DataTable();
            tabsec.Load(Rd);
            cmbsection.DataSource = tabsec;
            cmbsection.ValueMember = "Code";
            Rd.Close();
            Cone.Close();

        }
        private void button1_Click(object sender, EventArgs e)
        {
            SqlCommand Cmbproc = new SqlCommand("SPDeleteSection", Cone);
            Cmbproc.CommandType = CommandType.StoredProcedure;
            SqlParameter pcodesection = new SqlParameter("@codesection", SqlDbType.VarChar);
            pcodesection.Value = cmbsection.Text;
            Cmbproc.Parameters.Add(pcodesection);
            Cone.Open();
            Cmbproc.Connection = Cone;
            Cmbproc.ExecuteNonQuery();
            Cone.Close();

            
        }

        private void rbprocsec_CheckedChanged(object sender, EventArgs e)
        {
            groupBox1.Visible = true;
            ImpSection();
           
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            groupBox2.Visible = true;
            ImpStagiaire();
            ImpModule();
            ImpFor();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlCommand Cmbproc = new SqlCommand("SPInsertNote", Cone);
            Cmbproc.CommandType = CommandType.StoredProcedure;

            SqlParameter pstag = new SqlParameter("@stagiaire", SqlDbType.VarChar);
            SqlParameter pmod = new SqlParameter("@nummodule  ", SqlDbType.VarChar);
            SqlParameter pfor = new SqlParameter("@formateur ", SqlDbType.VarChar);
            SqlParameter pcc1 = new SqlParameter("@cc1 ", SqlDbType.Float);
            SqlParameter pcc2 = new SqlParameter("@cc2 ", SqlDbType.Float);
            SqlParameter pefm = new SqlParameter("@efm ", SqlDbType.Float);

            pstag.Value = cmbStagajout.Text;
            pmod.Value = cmbmoduleajout.Text;
            pfor.Value = cmbformatajout.Text;
            pcc1.Value = txtcc1.Text;
            pcc2.Value = txtcc2.Text;
            pefm.Value = txtefm.Text;

            Cmbproc.Parameters.Add(pstag);
            Cmbproc.Parameters.Add(pmod);
            Cmbproc.Parameters.Add(pfor);
            Cmbproc.Parameters.Add(pcc1);
            Cmbproc.Parameters.Add(pcc2);
            Cmbproc.Parameters.Add(pefm);
            Cone.Open();
            Cmbproc.Connection = Cone;
            Cmbproc.ExecuteNonQuery();
            Cone.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {

           

            // code button modifier
            SqlCommand Cmbproc = new SqlCommand("[SPUpdateNotes]", Cone);
            Cmbproc.CommandType = CommandType.StoredProcedure;

            SqlParameter pstag = new SqlParameter("@stagiaire", SqlDbType.VarChar);
            SqlParameter pmod = new SqlParameter("@module   ", SqlDbType.VarChar);
            
            SqlParameter pcc1 = new SqlParameter("@cc1 ", SqlDbType.Float);
            SqlParameter pcc2 = new SqlParameter("@cc2 ", SqlDbType.Float);
            SqlParameter pefm = new SqlParameter("@efm ", SqlDbType.Float);

            pstag.Value = cmbstagm.Text;
            pmod.Value = Cmbmodm.Text;
            
            pcc1.Value = txtcc1m.Text;
            pcc2.Value = txtcc2m.Text;
            pefm.Value = txtefmm.Text;

            Cmbproc.Parameters.Add(pstag);
            Cmbproc.Parameters.Add(pmod);
            
            Cmbproc.Parameters.Add(pcc1);
            Cmbproc.Parameters.Add(pcc2);
            Cmbproc.Parameters.Add(pefm);
            Cone.Open();
            Cmbproc.Connection = Cone;
            Cmbproc.ExecuteNonQuery();
            Cone.Close();
        }

        private void radioButton5_CheckedChanged(object sender, EventArgs e)
        {
            groupBox4.Visible = true;

            // impli stag

            Cone.Open();
            Cmb1.Connection = Cone;
            Cmb1.CommandText = "Select Matricule from Stagiaire";
            Rd = Cmb1.ExecuteReader();
            DataTable tabsec = new DataTable();
            tabsec.Load(Rd);
            cmbstagm.DataSource = tabsec;
            cmbstagm.ValueMember = "Matricule";
            Rd.Close();
            Cone.Close();

            // impli mod
            Cone.Open();
            Cmb1.Connection = Cone;
            Cmb1.CommandText = "Select Numero  from Module";
            Rd = Cmb1.ExecuteReader();
            DataTable tabmod = new DataTable();
            tabmod.Load(Rd);
            Cmbmodm.DataSource = tabmod;
            Cmbmodm.ValueMember = "Numero";
            Rd.Close();
            Cone.Close();
        }

        private void radioButton7_CheckedChanged(object sender, EventArgs e)
        {
            groupBox3.Visible = true;

            // impli stag

            Cone.Open();
            Cmb1.Connection = Cone;
            Cmb1.CommandText = "Select Matricule from Stagiaire";
            Rd = Cmb1.ExecuteReader();
            DataTable tabsec = new DataTable();
            tabsec.Load(Rd);
            cmbstagiaire.DataSource = tabsec;
            cmbstagiaire.ValueMember = "Matricule";
            Rd.Close();
            Cone.Close();

            // impli Section
            Cone.Open();
            Cmb1.Connection = Cone;
            Cmb1.CommandText = "Select Code  from Section";
            Rd = Cmb1.ExecuteReader();
            DataTable tabmod = new DataTable();
            tabmod.Load(Rd);
            cmbsecstag.DataSource = tabmod;
            cmbsecstag.ValueMember = "Code";
            Rd.Close();
            Cone.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SqlCommand Cmbproc = new SqlCommand("SPUpdatestagiaire", Cone);
            Cmbproc.CommandType = CommandType.StoredProcedure;

            SqlParameter pstag = new SqlParameter("@matricule ", SqlDbType.VarChar);
            SqlParameter pmod = new SqlParameter("@codesection   ", SqlDbType.VarChar);

         

            pstag.Value = cmbstagiaire.Text;
            pmod.Value = cmbsecstag.Text;

            Cmbproc.Parameters.Add(pstag);
            Cmbproc.Parameters.Add(pmod);

           
            Cone.Open();
            Cmbproc.Connection = Cone;
            Cmbproc.ExecuteNonQuery();
            Cone.Close();
        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        private void label16_Click(object sender, EventArgs e)
        {

        }

        private void radioButton9_CheckedChanged(object sender, EventArgs e)
        {
            groupBox5.Visible = true;

            Cone.Open();
            Cmb1.Connection = Cone;
            Cmb1.CommandText = "Select Code  from Filier";
            Rd = Cmb1.ExecuteReader();
            DataTable tabmod = new DataTable();
            tabmod.Load(Rd);
            cmbfiliere.DataSource = tabmod;
            cmbfiliere.ValueMember = "Code";
            Rd.Close();
            Cone.Close();

        }

        private void button5_Click(object sender, EventArgs e)
        {
            SqlCommand Cmbproc = new SqlCommand("supprimertablfiliere", Cone);
            Cmbproc.CommandType = CommandType.StoredProcedure;

            SqlParameter pstag = new SqlParameter("@codefiliere ", SqlDbType.VarChar);

            pstag.Value = cmbfiliere.Text;


            Cmbproc.Parameters.Add(pstag);
          
            Cone.Open();
            Cmbproc.Connection = Cone;
            Cmbproc.ExecuteNonQuery();
            Cone.Close();
        }
    }
}
