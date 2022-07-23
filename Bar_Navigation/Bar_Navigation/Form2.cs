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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }


        public SqlConnection cnx = new SqlConnection("data source=(local) ;initial catalog =Gestion_Notes  ; integrated security =true");
        public SqlCommand cmd = new SqlCommand();
        public SqlDataAdapter adp;
        public DataSet ds;

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void Form2_Load(object sender, EventArgs e)
        {
            adp = new SqlDataAdapter("select * from Stagiaire", "data source=(local) ;initial catalog =Gestion_Notes ; integrated security =true");
            ds = new DataSet();
            adp.Fill(ds, "Stagiaire");
            BindingSource bs = new BindingSource(ds.Tables["Stagiaire"], null);
            bindingNavigator1.BindingSource = bs;
            dataGridView1.DataSource = bs;
            comboBox1.DataSource = bs;
            comboBox1.ValueMember = "Matricule";

            
            
           
        }              
                                        
        private void dataGridView1_CellEnter_1(object sender, DataGridViewCellEventArgs e)
        {
            txtmaricule.Text = dataGridView1[0, dataGridView1.CurrentRow.Index].Value.ToString();
            txtsection.Text = dataGridView1[1, dataGridView1.CurrentRow.Index].Value.ToString();
            txtnom.Text = dataGridView1[2, dataGridView1.CurrentRow.Index].Value.ToString();
            txtprenom.Text = dataGridView1[3, dataGridView1.CurrentRow.Index].Value.ToString();
            txtbac.Text = dataGridView1[4, dataGridView1.CurrentRow.Index].Value.ToString();

            cnx.Open();
            cmd.Connection = cnx;
            cmd.CommandText = "select * from Note where Stagiaire = '" + comboBox1.Text + "'";
            adp.SelectCommand = cmd;
            ds = new DataSet();
            adp.Fill(ds, "Note");
            cnx.Close();
            dataGridView2.DataSource = ds.Tables["Note"];

            double moyenne = 0, sum = 0 , module = 0;
            for (int i = 0; i < dataGridView2.Rows.Count -1; i++)
            {
                sum += Convert.ToDouble(dataGridView2[6,i].Value);
                module++;
            }

            moyenne = sum / module;
            txtmoyenne.Text = moyenne.ToString();
            if (moyenne < 10)
            {
                txtdec.Text = "No valider";
            }
            else txtdec.Text = "Valider";




            //for (int i = 0; i < ds.Tables["Note"].Rows.Count; i++)
            //{
            //    if (comboBox1.Text == ds.Tables["Note"].Rows[i][2].ToString())
            //    {
            //        dataGridView2.Rows.Add(ds.Tables["Note"].Rows[i][0], ds.Tables["Note"].Rows[i][1], ds.Tables["Note"].Rows[i][2], ds.Tables["Note"].Rows[i][3], ds.Tables["Note"].Rows[i][4], ds.Tables["Note"].Rows[i][5]);
            //    }
            //}
               
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
          
           

        }

        private void button1_Click(object sender, EventArgs e)
        {
            cnx.Open();
            cmd.Connection = cnx;
            cmd.CommandText = "insert into releve values('" + comboBox1.Text + "','" + txtmoyenne.Text + "','" + txtdec.Text + "') ";
            cmd.ExecuteNonQuery();
            cnx.Close();
            MessageBox.Show("Confirme");
        }


        

        
    }
}
