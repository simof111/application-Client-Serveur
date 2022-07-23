using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
namespace ClassConnetion
{
    public class OCConnection
    {
        public static SqlConnection OCN;
        public static SqlCommand OCMD;
        public static SqlDataReader ODR;

        public OCConnection()
        {
            OCN = new SqlConnection("data source=(local) ;initial catalog =G_Data_ADO.NET  ; integrated security =true");
            OCMD = new SqlCommand();
        }

        public string OpenConnection(string scriptcmd)
        {

            if (OCN.State == System.Data.ConnectionState.Open)
            {
                OCN.Close();
            }

            OCMD.Connection = OCN;
            OCMD.CommandText = scriptcmd;
            ODR = OCMD.ExecuteReader();
            
            return ODR;
            ODR.Close();
            OCN.Close();

 
        }
    }
}
