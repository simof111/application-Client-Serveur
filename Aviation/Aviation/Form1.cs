using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
namespace Aviation
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public static SqlConnection OCN1 = new SqlConnection("data source = (local) ; initial catalog = First_Data ; integrated security = true ");
        public static SqlCommand OCMD1 = new SqlCommand();
        public static SqlCommand OCMD2 = new SqlCommand();
        public static SqlDataReader ORD1;
        public static SqlTransaction OTR1;

        public void Testconnection()
        {
            if (OCN1.State == ConnectionState.Open)
            {
                OCN1.Close();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Code pilote
            Testconnection();
            OCN1.Open();
            OCMD1.Connection = OCN1;
            OCMD1.CommandText = "select distinct Codep from  Vol ";
            ORD1 = OCMD1.ExecuteReader();
            DataTable tbl1 = new DataTable();
            tbl1.Load(ORD1);
            txtCodepilote.DataSource = tbl1;
            txtCodepilote.ValueMember = "Codep";
            ORD1.Close();
            OCN1.Close();

            // Numero avion 
            Testconnection();
            OCN1.Open();
            OCMD1.Connection = OCN1;
            OCMD1.CommandText = "select distinct Numavion from  Vol ";
            ORD1 = OCMD1.ExecuteReader();
            DataTable tbl2 = new DataTable();
            tbl2.Load(ORD1);
            txtnumeroav.DataSource = tbl2;
            txtnumeroav.ValueMember = "Numavion";
            ORD1.Close();
            OCN1.Close();

            // destination 
            Testconnection();
            OCN1.Open();
            OCMD1.Connection = OCN1;
            OCMD1.CommandText = "select distinct Destination from  Vol ";
            ORD1 = OCMD1.ExecuteReader();
            DataTable tbl3 = new DataTable();
            tbl3.Load(ORD1);
            txtdestination.DataSource = tbl3;
            txtdestination.ValueMember = "Destination";
            ORD1.Close();
            OCN1.Close();


        }

        private void txtCodepilote_SelectedIndexChanged(object sender, EventArgs e)
        {
            // emplemente datagrid avec Code pilote
            Testconnection();
            OCN1.Open();
            OCMD1.Connection = OCN1;
            OCMD1.CommandText = "select * from  Vol where Codep = '" + txtCodepilote.Text + "'";
            ORD1 = OCMD1.ExecuteReader();
            DataTable tbl1 = new DataTable();
            tbl1.Load(ORD1);
            dataGridView1.DataSource = tbl1;
            ORD1.Close();
            OCN1.Close();
        }

        private void txtnumeroav_SelectedIndexChanged(object sender, EventArgs e)
        {
            // emplemente datagrid avec numero d'avion
            Testconnection();
            OCN1.Open();
            OCMD1.Connection = OCN1;
            OCMD1.CommandText = "select * from  Vol where Numavion = '" + txtnumeroav.Text + "'";
            ORD1 = OCMD1.ExecuteReader();
            DataTable tbl1 = new DataTable();
            tbl1.Load(ORD1);
            dataGridView1.DataSource = tbl1;
            ORD1.Close();
            OCN1.Close();
        }

        private void txtdestination_SelectedIndexChanged(object sender, EventArgs e)
        {
            // emplemente datagrid avec numero d'avion
            Testconnection();
            OCN1.Open();
            OCMD1.Connection = OCN1;
            OCMD1.CommandText = "select * from  Vol where Destination = '" + txtdestination.Text + "'";
            ORD1 = OCMD1.ExecuteReader();
            DataTable tbl1 = new DataTable();
            tbl1.Load(ORD1);
            dataGridView1.DataSource = tbl1;
            ORD1.Close();
            OCN1.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                // delete vol
                Testconnection();
                OCN1.Open();
                OTR1 = OCN1.BeginTransaction();
                OCMD2.Connection = OCN1;
                OCMD2.CommandText = " delete from Vol where Codep = '" + txtCodepilote.Text + "'";
                OCMD2.Transaction = OTR1;
                OCMD2.ExecuteNonQuery();


                // delete pilote
               
                OCMD1.Connection = OCN1;
                OCMD1.CommandText = " delete from Pilote where Code = '" + txtCodepilote.Text + "'";
                OCMD1.Transaction = OTR1;
                OCMD1.ExecuteNonQuery();

                OTR1.Commit();
                MessageBox.Show("Transaction effectuée");
                OCN1.Close();

            }
            catch
            {
                OTR1.Rollback();
                errorProvider1.SetError(button1, "Transaction annulée");
 
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {

            try
            {
                // delete vol

                OCMD2.Connection = OCN1;
                OCMD2.CommandText = " delete from Vol where Codep = '" + txtnumeroav.Text + "'";
                OCMD2.Transaction = OTR1;
                OCMD2.ExecuteNonQuery();

                OTR1.Commit();
                MessageBox.Show("Transaction effectuée");
                OCN1.Close();

            }
            catch
            {
                OTR1.Rollback();
                errorProvider1.SetError(button1, "Transaction annulée");
 
            }

            
        }

        private void button5_Click(object sender, EventArgs e)
        {
           
            Testconnection();
            OCN1.Open();
            OCMD1.Connection = OCN1;
            OCMD1.CommandText = "select * from  Vol ";
            ORD1 = OCMD1.ExecuteReader();
            DataTable tbl1 = new DataTable();
            tbl1.Load(ORD1);
            dataGridView1.DataSource = tbl1;
            ORD1.Close();
            OCN1.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Testconnection();
            OCN1.Open();
            OCMD1.Connection = OCN1;
            OCMD1.CommandText = "insert into Vol values('" + dataGridView1[0, dataGridView1.CurrentRow.Index].Value + "','" + dataGridView1[1, dataGridView1.CurrentRow.Index].Value + "','" + dataGridView1[2, dataGridView1.CurrentRow.Index].Value + "','" + dataGridView1[3, dataGridView1.CurrentRow.Index].Value + "','" + dataGridView1[4, dataGridView1.CurrentRow.Index].Value + "') ";
            OCMD1.ExecuteNonQuery();
            OCN1.Close();
        }
    }
}
