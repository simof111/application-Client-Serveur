using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace MDeconnecter_modification_produit
{
   public class ADO
    {
        public SqlConnection Con = new SqlConnection("data source=(local) ;initial catalog =G_Data_ADO.NET  ; integrated security =true");
        public SqlCommand Cmd = new SqlCommand();
        public SqlDataReader Dread;
        public SqlDataAdapter ADP;
        public SqlCommandBuilder Cmb ;
        public DataSet Ds = new DataSet();
        public DataRow Drow;


        public void Connecter()
        {
            if (Con.State == ConnectionState.Closed)
            {
                Con.Open();
            }
            Cmd.Connection = Con;
        }

        public void Desconnecter()
        {
            if (Con.State == ConnectionState.Open)
            {
                Con.Close();
            }
        }
    }
}
