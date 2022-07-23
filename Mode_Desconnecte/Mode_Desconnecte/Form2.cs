using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Mode_Desconnecte
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        public static SqlConnection Cone = new SqlConnection("data source=(local) ;initial catalog =G_Data_ADO.NET  ; integrated security =true");
        public static SqlCommand Com = new SqlCommand();
        public static SqlDataReader Read1;
        public static SqlDataAdapter OdaAuth = new SqlDataAdapter();
        public static DataSet OdsAuth = new DataSet();
        SqlCommandBuilder odb = new SqlCommandBuilder(OdaAuth);

        public void SavePilote()
        {
            Cone.Open();
            OdaAuth.Update(OdsAuth, "Pilote");
            OdsAuth.Tables[0].Rows.Clear();
            Com.Connection = Cone;
            Com.CommandText = "select *  from Pilote";
            OdaAuth.SelectCommand = Com;
            OdaAuth.Fill(OdsAuth, "Pilote");
            Cone.Close();

        }

        private void Form2_Load(object sender, EventArgs e)
        {
            Cone.Open();
            Com.Connection = Cone;
            Com.CommandText = "select *  from Pilote";
            OdaAuth.SelectCommand = Com;
            OdaAuth.Fill(OdsAuth, "Pilote");
            Cone.Close();

            cmbcode.DataSource = OdsAuth.Tables["Pilote"];
            cmbcode.ValueMember = "Code";
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void cmbcode_SelectedIndexChanged(object sender, EventArgs e)
        {

            //txtnom.Text = OdsAuth.Tables["Pilote"].Rows[cmbcode.SelectedIndex][1].ToString();
            //txtprenom.Text = OdsAuth.Tables["Pilote"].Rows[cmbcode.SelectedIndex][2].ToString();
            //txtgrade.Text = OdsAuth.Tables["Pilote"].Rows[cmbcode.SelectedIndex][3].ToString();

            dataGridView1.DataSource = OdsAuth.Tables["Pilote"];
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(txtnom.Text =="" || txtprenom.Text =="" || txtgrade.Text == "" || cmbcode.Text =="")
            {
                MessageBox.Show("Remplir tous les champs");
                return;
            }

            DataRow row1;
            row1 = OdsAuth.Tables[0].NewRow();
            row1[0] = cmbcode.Text;
            row1[1] = txtnom.Text;
            row1[2] = txtprenom.Text;
            row1[3] = txtgrade.Text;
            OdsAuth.Tables[0].Rows.Add(row1);
            dataGridView1.DataSource = OdsAuth.Tables["Pilote"];
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (txtnom.Text == "" || txtprenom.Text == "" || txtgrade.Text == "" || cmbcode.Text == "")
            {
                MessageBox.Show("Remplir tous les champs");
                return;
            }
            OdsAuth.Tables[0].Rows[cmbcode.SelectedIndex][1] = txtnom.Text;
            OdsAuth.Tables[0].Rows[cmbcode.SelectedIndex][2] = txtprenom.Text;
            OdsAuth.Tables[0].Rows[cmbcode.SelectedIndex][3] = txtgrade.Text;

            dataGridView1.DataSource = OdsAuth.Tables["Pilote"];
        }

        private void button3_Click(object sender, EventArgs e)
        {
            OdsAuth.Tables["Pilote"].Rows.RemoveAt(cmbcode.SelectedIndex);

            dataGridView1.DataSource = OdsAuth.Tables["Pilote"];
        }

        private void button4_Click(object sender, EventArgs e)
        {
            
             
        

        }
    }
}
