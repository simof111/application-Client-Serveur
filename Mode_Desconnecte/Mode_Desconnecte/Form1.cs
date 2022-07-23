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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public static SqlConnection Cone = new SqlConnection("data source=(local) ;initial catalog =G_Data_ADO.NET  ; integrated security =true");
        public static SqlCommand Com = new SqlCommand();
        public static SqlDataReader Read1;
        public static SqlDataAdapter OdaAuth = new SqlDataAdapter();
        public static DataSet OdsAuth = new DataSet();

        private void label4_Click(object sender, EventArgs e)
        {

        }
        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
        private void Form1_Load(object sender, EventArgs e)
        {
            Cone.Open();
            Com.Connection = Cone;
            Com.CommandText = "select *  from Authentification";
            OdaAuth.SelectCommand = Com;
            OdaAuth.Fill(OdsAuth, "Authentification");
            txtdomaine.DataSource = OdsAuth.Tables[0];
            txtdomaine.ValueMember = "Domaine";
            Cone.Close();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
               
                    textBox1.Text = txtdomaine.SelectedIndex.ToString();
                    if (txtusername.Text == (OdsAuth.Tables[0].Rows[txtdomaine.SelectedIndex][0]).ToString() && txtpw.Text == OdsAuth.Tables[0].Rows[txtdomaine.SelectedIndex][1].ToString() && txtdomaine.Text == OdsAuth.Tables[0].Rows[txtdomaine.SelectedIndex][2].ToString())
                    {
                        Form2 f2 = new Form2();
                        f2.Show();
                        Hide();
                    }
                
            }
            catch
            {
                MessageBox.Show("Password or Username uncorrect");
            }
        }
        private void txtusername_TextChanged(object sender, EventArgs e)
        {

        }
        private void txtpw_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
