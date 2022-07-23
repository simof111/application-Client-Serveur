using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
namespace Transaction__PS
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public static SqlConnection Cone = new SqlConnection("data source=(local) ;initial catalog =Datassuramce  ; integrated security =true");
        public static SqlCommand Com = new SqlCommand();
        public static SqlCommand Com2 = new SqlCommand();
        public static SqlCommand Com3 = new SqlCommand();
        public static SqlDataReader Read1;
        public static SqlTransaction otr1;

        public void TestConnection()
        {
            if (Cone.State == ConnectionState.Open)
            {
                Cone.Close();
            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            // CIN Client
            TestConnection();
            Cone.Open();
            Com.Connection = Cone;
            Com.CommandText = "select distinct CINclient from Client ";
            Read1 = Com.ExecuteReader();

            DataTable tab = new DataTable();
            tab.Load(Read1);
            cmbcin2.DataSource = tab;
            cmbcin2.ValueMember = "CINclient";

            Read1.Close();
            Cone.Close();

            TestConnection();
            Cone.Open();
            Com.Connection = Cone;
            Com.CommandText = "select Numeropolic from Police ";
            Read1 = Com.ExecuteReader();
            DataTable tab1 = new DataTable();
            tab1.Load(Read1);
            cmbnum.DataSource = tab1;
            cmbnum.ValueMember = "Numeropolic";
            Read1.Close();
            Cone.Close();

            // police2

            TestConnection();
            Cone.Open();
            Com.Connection = Cone;
            Com.CommandText = "select Numeropolic from Police ";
            Read1 = Com.ExecuteReader();
            DataTable tabnum = new DataTable();
            tabnum.Load(Read1);
            cmbnum2.DataSource = tabnum;
            cmbnum2.ValueMember = "Numeropolic";
            Read1.Close();
            Cone.Close();

            // risque

            TestConnection();
            Cone.Open();
            Com.Connection = Cone;
            Com.CommandText = "select CodeRisque from Risque ";
            Read1 = Com.ExecuteReader();
            DataTable tab2 = new DataTable();
            tab2.Load(Read1);
            cmbrisque.DataSource = tab2;
            cmbrisque.ValueMember = "CodeRisque";
            Read1.Close();
            Cone.Close();

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked == true)
            {
                
                comboBox2.Show();
                comboBox3.Hide();
                comboBox4.Hide();

                TestConnection();
                Cone.Open();
                Com.Connection = Cone;
                Com.CommandText = "select CodeRisque from Risque where Numeropolic = '" + cmbnum.Text + "' ";
                Read1 = Com.ExecuteReader();
                DataTable tab = new DataTable();
                tab.Load(Read1);
                comboBox2.DataSource = tab;
                comboBox2.ValueMember = "CodeRisque";
                Read1.Close();
                Cone.Close();
            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            TestConnection();
            Cone.Open();
            Com.Connection = Cone;
            Com.CommandText = "select * from Risque where CodeRisque = '" + comboBox2.Text + "' ";
            Read1 = Com.ExecuteReader();
            DataTable tab1 = new DataTable();
            tab1.Load(Read1);
            dataGridView1.DataSource = tab1;
            Read1.Close();
            Cone.Close();

            // Total tarif
            TestConnection();
            Cone.Open();
            Com.Connection = Cone;
            Com.CommandText = "select sum(Tarif) from Risque where CodeRisque = '" + comboBox2.Text + "'";
            textBox1.Text = Com.ExecuteScalar().ToString();
            Read1.Close();
            Cone.Close();
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked == true)
            {
                comboBox3.Items.Clear();
                comboBox3.Show();
                comboBox2.Hide();
                comboBox4.Hide();

                TestConnection();
                Cone.Open();
                Com.Connection = Cone;
                Com.CommandText = "select Intitule from Risque  where Numeropolic = '" + cmbnum.Text + "'";
                Read1 = Com.ExecuteReader();
                while (Read1.Read())
                {
                    comboBox3.Items.Add(Read1[0]);
                }
                Read1.Close();
                Cone.Close();
            }
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton3.Checked == true)
            {
                comboBox4.Items.Clear();
                comboBox4.Show();
                comboBox3.Hide();
                comboBox2.Hide();


                TestConnection();
                Cone.Open();
                Com.Connection = Cone;
                Com.CommandText = "select Tarif from Risque  where Numeropolic = '" + cmbnum.Text + "'";
                Read1 = Com.ExecuteReader();
                while (Read1.Read())
                {
                    comboBox4.Items.Add(Read1[0]);
                }
                Read1.Close();
                Cone.Close();
            }
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            TestConnection();
            Cone.Open();
            Com.Connection = Cone;
            Com.CommandText = "select * from Risque where Intitule = '" + comboBox3.Text + "' ";
            Read1 = Com.ExecuteReader();
            DataTable tab1 = new DataTable();
            tab1.Load(Read1);
            dataGridView1.DataSource = tab1;
            Read1.Close();
            Cone.Close();

            // Total tarif
            TestConnection();
            Cone.Open();
            Com.Connection = Cone;
            Com.CommandText = "select sum(Tarif) from Risque where Intitule = '" + comboBox3.Text + "'";
            textBox1.Text = Com.ExecuteScalar().ToString();
            Read1.Close();
            Cone.Close();
        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            TestConnection();
            Cone.Open();
            Com.Connection = Cone;
            Com.CommandText = "select * from Risque where Tarif = '" + comboBox4.Text + "' ";
            Read1 = Com.ExecuteReader();
            DataTable tab1 = new DataTable();
            tab1.Load(Read1);
            dataGridView1.DataSource = tab1;
            Read1.Close();
            Cone.Close();

            // Total tarif
            TestConnection();
            Cone.Open();
            Com.Connection = Cone;
            Com.CommandText = "select sum(Tarif) from Risque where Tarif = '" + comboBox4.Text + "'";
            textBox1.Text = Com.ExecuteScalar().ToString();
            Read1.Close();
            Cone.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            // l'Affichage total
            TestConnection();
            Cone.Open();
            Com.Connection = Cone;
            Com.CommandText = "select * from Risque ";
            Read1 = Com.ExecuteReader();
            DataTable tabtotal = new DataTable();
            tabtotal.Load(Read1);
            dataGridView1.DataSource = tabtotal;
            Read1.Close();
            Cone.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {

                // risque 
                Cone.Open();
                otr1 = Cone.BeginTransaction();
                Com3.Connection = Cone;
                Com3.CommandText = "delete from Risque where Numeropolic in(select Numeropolic from Police where CINclient  = '" + cmbcin2.Text + "' )";
                Com3.Transaction = otr1;
                Com3.ExecuteNonQuery();



                 // police 

                 Com2.Connection = Cone;
                 Com2.CommandText = "delete from Police where CINclient = '" + cmbcin2.Text + "' ";
                 Com2.Transaction = otr1;
                 Com2.ExecuteNonQuery();



                 // Client 
                
                 Com.Connection = Cone;
                 Com.CommandText = "delete from Client where CINclient = '" + cmbcin2.Text + "' ";
                 Com.Transaction = otr1;
                 Com.ExecuteNonQuery();


                 otr1.Commit();
                 MessageBox.Show("Transaction effectuée");
                 Cone.Close();
                


            }
            catch
            {
                otr1.Rollback();
                errorProvider1.SetError(button1,"Transaction annulée");

            }


        }

       
        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                // risque 
                Cone.Open();
                otr1 = Cone.BeginTransaction();
                Com3.Connection = Cone;
                Com3.CommandText = "delete from Risque where Numeropolic in(select Numeropolic from Police where CINclient  = '" + cmbcin2.Text + "' )";
                Com3.Transaction = otr1;
                Com3.ExecuteNonQuery();



                // police 

                Com2.Connection = Cone;
                Com2.CommandText = "delete from Police where CINclient = '" + cmbcin2.Text + "' ";
                Com2.Transaction = otr1;
                Com2.ExecuteNonQuery();

                otr1.Commit();
                MessageBox.Show("Transaction effectuée");
                Cone.Close();
            }
            catch
            {
                otr1.Rollback();
                errorProvider1.SetError(button1, "Transaction annulée");

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                // risque 
                Cone.Open();
                otr1 = Cone.BeginTransaction();
                Com3.Connection = Cone;
                Com3.CommandText = "update  Risque set Tarif = Tarif*(1.2) where CodeRisque  = '" + cmbrisque.Text + "'";
                Com3.Transaction = otr1;
                Com3.ExecuteNonQuery();




                otr1.Commit();
                MessageBox.Show("Transaction effectuée");
                Cone.Close();
            }
            catch
            {
                otr1.Rollback();
                errorProvider1.SetError(button1, "Transaction annulée");

            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Cone.Open();
            otr1 = Cone.BeginTransaction();

            // ajouetr Client 

            Com.Connection = Cone;
            Com.CommandText = "insert into Client values('" + dataGridView1[0, dataGridView1.CurrentRow.Index].Value + "', '" + dataGridView1[1, dataGridView1.CurrentRow.Index].Value + "', '" + dataGridView1[0, dataGridView1.CurrentRow.Index].Value + "') ";
            Com.Transaction = otr1;
            Com.ExecuteNonQuery();

        }

        
    }
}

