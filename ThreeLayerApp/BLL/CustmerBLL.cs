using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL;
namespace BLL
{
    public class CustmerBLL
    {
        CustmerDAL dal;
        public void InsetB(Custmer custmer)
        {
            dal = new CustmerDAL();
            dal.Insert(custmer);
        }
        public void UpdateB(Custmer custmer)
        {
            dal = new CustmerDAL();
            dal.Update(custmer);
        }
        public void DeleteB(int id)
        {
            dal = new CustmerDAL();
            dal.Delete(id);
        }
        public List<Custmer> ShowAll()
        {
            
            dal = new CustmerDAL();
            return dal.ShowAll();

        }

        public List<Custmer> ShowCustomer(int Id)
        {
            dal = new CustmerDAL();
            return dal.ShowCustmomer(Id);

        }
           
    }
}
