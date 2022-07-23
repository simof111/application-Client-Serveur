using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace M22_EFF
{
    public partial class Employee : Form
    {
        public Employee()
        {
            InitializeComponent();
        }
        public Methods method = new Methods();
        private void Employee_Load(object sender, EventArgs e)
        {
            method.ChargeGrid(dataGridView1, "select * from Employee");
        }
        public Button btn1 = new Button();
        private void button1_Click(object sender, EventArgs e)
        {

            string script;
            script = "insert into Employee values ('" + dataGridView1[0, dataGridView1.CurrentRow.Index].Value +
                "','" + dataGridView1[1, dataGridView1.CurrentRow.Index].Value + "','" +
                dataGridView1[2, dataGridView1.CurrentRow.Index].Value + "','" +
                dataGridView1[3, dataGridView1.CurrentRow.Index].Value + "','" +
                dataGridView1[4, dataGridView1.CurrentRow.Index].Value + "','" + 
                dataGridView1[5, dataGridView1.CurrentRow.Index].Value + "','" +
                dataGridView1[6, dataGridView1.CurrentRow.Index].Value + "','" +
                dataGridView1[7, dataGridView1.CurrentRow.Index].Value + "')";
                method.GetCommand(script);
           method.ChargeGrid(dataGridView1, "select * from Employee");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string script;
            script = "update  Employee set Nom = '" + dataGridView1[1, dataGridView1.CurrentRow.Index].Value + "', Prenom = '" +
                dataGridView1[2, dataGridView1.CurrentRow.Index].Value + "',Adresse = '" +
                dataGridView1[3, dataGridView1.CurrentRow.Index].Value + "', Tel = '" +
                dataGridView1[4, dataGridView1.CurrentRow.Index].Value + "', Nbre_Reponse = '" +
                dataGridView1[5, dataGridView1.CurrentRow.Index].Value + "', Login = '" +
                dataGridView1[6, dataGridView1.CurrentRow.Index].Value + "', Password = '" +
                dataGridView1[7, dataGridView1.CurrentRow.Index].Value + "' ";
            method.GetCommand(script);
            method.ChargeGrid(dataGridView1, "select * from Employee");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string script = "delete from Employee where IDE = '" + dataGridView1[0, dataGridView1.CurrentRow.Index].Value + "'";
            method.GetCommand(script);
            method.ChargeGrid(dataGridView1, "select * from Employee");

        }

    }
}
