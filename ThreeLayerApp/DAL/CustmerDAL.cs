using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;

namespace DAL
{
    public class CustmerDAL
    {
        public void Insert(Custmer cust)
        {
            SqlConnection cx = new SqlConnection("Data Source=.;Initial Catalog=Data_Custmers;Integrated Security=True");
            cx.Open();
            string requet = string.Format("insert into Custmers(Name,Adress,Country,City,PinCode) values('{0}','{1}','{2}','{3}','{4}') ", cust.Name, cust.Adress, cust.Country, cust.City, cust.PinCode);
            SqlCommand cmd = new SqlCommand(requet, cx);
            cmd.ExecuteNonQuery();
            cx.Close();
        }
        public void Update(Custmer cust)
        {
            SqlConnection cx = new SqlConnection("Data Source=.;Initial Catalog=Data_Custmers;Integrated Security=True");
            cx.Open();
            string requet = string.Format("update Custmers set Name = '{0}', Adress = '{1}' , Country = '{2}' , City =' {3}' , PinCode = '{4}' where Id = '{5}'", cust.Name, cust.Adress, cust.Country, cust.City, cust.PinCode, cust.Id);
            SqlCommand cmd = new SqlCommand(requet, cx);
            cmd.ExecuteNonQuery();
            cx.Close();
        }
        public List<Custmer> ShowCustmomer(int Id)
        {
            List<Custmer> newcustmer = new List<Custmer>();
            SqlConnection cx = new SqlConnection("Data Source=.;Initial Catalog=Data_Custmers;Integrated Security=True");
            cx.Open();
            string requet = "Select * from Custmers Where Id = '"+Id+"' ";
            SqlCommand cmd = new SqlCommand(requet, cx);
            SqlDataReader re = cmd.ExecuteReader();
            while (re.Read())
            {
                Custmer c = new Custmer();
                c.Id = int.Parse(re[0].ToString());
                c.Name = re[1].ToString();
                c.Adress = re[2].ToString();
                c.Country = re[3].ToString();
                c.City = re[4].ToString();
                c.PinCode = re[3].ToString();
                newcustmer.Add(c);
            }
            re.Close();
            cx.Close();
            return newcustmer;

        }
        public void Delete(int id)
        {
            SqlConnection cx = new SqlConnection("Data Source=.;Initial Catalog=Data_Custmers;Integrated Security=True");
            cx.Open();
            string requet = string.Format("delete from Custmers where Id ={0}", id);
            SqlCommand cmd = new SqlCommand(requet, cx);
            cmd.ExecuteNonQuery();
            cx.Close();
        }
        public List<Custmer> ShowAll()
        {
            List<Custmer> newcustmer = new List<Custmer>();
            SqlConnection cx = new SqlConnection("Data Source=.;Initial Catalog=Data_Custmers;Integrated Security=True");
            cx.Open();
            string requet = "Select * from Custmers ";
            SqlCommand cmd = new SqlCommand(requet, cx);
            SqlDataReader re = cmd.ExecuteReader();
            while (re.Read())
            {
                Custmer c = new Custmer();
                c.Id = int.Parse(re[0].ToString());
                c.Name = re[1].ToString();
                c.Adress = re[2].ToString();
                c.Country = re[3].ToString();
                c.City = re[4].ToString();
                c.PinCode = re[3].ToString();
                newcustmer.Add(c);
            }
            re.Close();
            cx.Close();
            return newcustmer;
        }



    }
}
