using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
namespace GestionTournoi
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public SqlConnection cnx = new SqlConnection("Data Source=.;Initial Catalog=DataTournoi;Integrated Security=True");
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

        public void ShowDG(DataGridView dg ,String script)
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

        public void ShowCMB(ComboBox  cmb, String script , String vmb)
        {
            Connection();
            cmd.Connection = cnx;
            cmd.CommandText = script;
            rd = cmd.ExecuteReader();
            DataTable tab = new DataTable();
            tab.Load(rd);
            cmb.DataSource = tab;
            cmb.ValueMember = vmb;
            rd.Close();
            cnx.Close();
        }
        public void Insert( String script)
        {
            Connection();
            cmd.Connection = cnx;
            cmd.CommandText = script;
            cmd.ExecuteNonQuery();
            cnx.Close();
            MessageBox.Show("Insert Successfuly ^_^");
        }

        public void Update(String script)
        {
            Connection();
            cmd.Connection = cnx;
            cmd.CommandText = script;
            cmd.ExecuteNonQuery();
            cnx.Close();
            MessageBox.Show("Update Successfuly ^_^");
        }

        public void Delete(String script)
        {
            Connection();
            cmd.Connection = cnx;
            cmd.CommandText = script;
            cmd.ExecuteNonQuery();
            cnx.Close();
            MessageBox.Show("Delete Successfuly ^_^");
        }




        private void Form1_Load(object sender, EventArgs e)
        {
            // sportif
            ShowDG(dataGridView1, "Select * from Sportif");
            ShowCMB(cmbsp, "select Spetialite from Sportif ", "Spetialite");

            // sport
            ShowDG(dataGridView2, "Select * from Sport");

        }

        private void button1_Click(object sender, EventArgs e)
        {
            // insert sportif
            string script = "insert into Sportif values('" + txtnumero.Text + "','" + txtnom.Text + "','" + txtprenom.Text + "','" + cmbsp.Text + "')";
            Insert(script);
            ShowDG(dataGridView1, "Select * from Sportif");
        }

        private void button6_Click(object sender, EventArgs e)
        {
            // insert sport
            string script = "insert into Sport values('" + txtcode.Text + "','" + txtintitule.Text + "','" + txttype.Text + "')";
            Insert(script);
            ShowDG(dataGridView2, "Select * from Sport");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // update sportif
            string script = "update Sportif set Nom = '" + txtnom.Text + "' , Prenom = '" + txtprenom.Text + "' , Spetialite =  '" + cmbsp.Text + "' where Numero =  '"+txtnumero.Text+"'";
            Update(script);
            ShowDG(dataGridView1, "Select * from Sportif");
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // implementer fichies sportif
            txtnumero.Text = dataGridView1[0, dataGridView1.CurrentRow.Index].Value.ToString();
            txtnom.Text = dataGridView1[1, dataGridView1.CurrentRow.Index].Value.ToString();
            txtprenom.Text = dataGridView1[2, dataGridView1.CurrentRow.Index].Value.ToString();
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            // delete sportif
            string script = "delete from Sportif where  Numero = '" + txtnumero.Text + "'";
            Delete(script);
            ShowDG(dataGridView1, "Select * from Sportif");
        }

        private void button5_Click(object sender, EventArgs e)
        {
            // update sort
            string script = " update Sport set Intitule =  '" + txtintitule.Text + "', Type = '" + txttype.Text + "' where Code = '" + txtcode.Text + "'";
            Update(script);
            ShowDG(dataGridView2, "Select * from Sport");

        }

        private void button4_Click(object sender, EventArgs e)
        {
            // delete sport
            string script = "delete from Sport Where Code = '" + txtcode.Text + "'";
            Delete(script);
            ShowDG(dataGridView2, "Select * from Sport");
        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // implementer fichies sport
            txtcode.Text = dataGridView2[0, dataGridView1.CurrentRow.Index].Value.ToString();
            txtintitule.Text = dataGridView2[1, dataGridView1.CurrentRow.Index].Value.ToString();
            txttype.Text = dataGridView2[2, dataGridView1.CurrentRow.Index].Value.ToString();
        }

        private void com(object sender, EventArgs e)
        {

        }

        private void tabPage3_Enter(object sender, EventArgs e)
        {
            ShowDG(dataGridView3, "select * from Resultat");

            ShowCMB(cmbsport, "select Code from Sport ", "Code");
            ShowCMB(cmbsportif, "select Numero from Sportif ", "Numero");
        }

        private void button8_Click(object sender, EventArgs e)
        {
            // calcule moyenne
            txtmoyenne.Text = ((Convert.ToDouble(txtn1.Text) +Convert.ToDouble(txtn1.Text) + Convert.ToDouble(txtn1.Text))/3).ToString();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            // archif
            string script = "insert into Resultat values('" + cmbsportif.Text + "','" + cmbsport.Text + "','" + txtn1.Text + "','" + txtn2.Text + "','" + txtn3.Text + "','" + txtmoyenne.Text + "')";
            Insert(script);
            ShowDG(dataGridView3, "select * from Resultat");
        }

        private void button9_Click(object sender, EventArgs e)
        {
            // Afficher graphe
            CR ocr1 = new CR();
            Connection();
            cmd.CommandText = "select Numero,Moyenne from Resultat";
            rd = cmd.ExecuteReader();
            DataTable tab = new DataTable();
            tab.Load(rd);
            ocr1.SetDataSource(tab);
            crystalReportViewer1.ReportSource = ocr1;
            crystalReportViewer1.Refresh();

        }

        

        
    }
}
