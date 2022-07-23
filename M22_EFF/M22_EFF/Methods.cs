using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;



using System.Windows.Forms;namespace M22_EFF
{
    public class Methods
    {
        public SqlConnection cnx = new SqlConnection("Data Source=.;Initial Catalog=Gestion_Questionnaire;Integrated Security=True");
        public SqlCommand cmd = new SqlCommand();
        public SqlDataReader rd;

        public void ChargeGrid(DataGridView gr, string script)
        {
            cnx.Open();
            cmd.Connection = cnx;
            cmd.CommandText = script;
            rd = cmd.ExecuteReader();
            DataTable tab = new DataTable();
            tab.Load(rd);
            gr.DataSource = tab;
            rd.Close();
            cnx.Close();
        }
        public void ChargeGrid(ComboBox cmb, string script, string vm)
        {
            cnx.Open();
            cmd.Connection = cnx;
            cmd.CommandText = script;
            rd = cmd.ExecuteReader();
            DataTable tab = new DataTable();
            tab.Load(rd);
            cmb.DataSource = tab;
            cmb.ValueMember = vm;
            rd.Close();
            cnx.Close();
        }

        public void GetCommand(string script)
        {
            cnx.Open();
            cmd.Connection = cnx;
            cmd.CommandText = script;
            cmd.ExecuteNonQuery();
            cnx.Close();

        }
        
    }
}
