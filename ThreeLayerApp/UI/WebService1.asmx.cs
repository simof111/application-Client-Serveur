using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using DAL;
using BLL;
using System.Collections;
using System.Xml.Linq;
using System.Web.Services.Protocols;
using Newtonsoft.Json;
using System.Data;

namespace UI
{
    /// <summary>
    /// Summary description for WebService1
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    [System.Web.Script.Services.ScriptService]
    public class WebService1 : System.Web.Services.WebService
    {

        //[WebMethod]
        //public int HelloWorld(int a)
        //{
        //    return a;
        //}

        //CustmerDAL dal;
        //[WebMethod]
        //public void InsetB(Custmer custmer)
        //{
        //    dal = new CustmerDAL();
        //    dal.Insert(custmer);
        //}

        //[WebMethod]
        //public List<Custmer> ShowCustomer(int Id)
        //{
        //    CustmerBLL bll = new CustmerBLL();
        //    return bll.ShowCustomer(Id);
        //}
        //[WebMethod]
        //public void UpdateB(Custmer custmer)
        //{
        //    dal = new CustmerDAL();
        //    dal.Update(custmer);
        //}
        //[WebMethod]
        //public void DeleteB(int id)
        //{
        //    dal = new CustmerDAL();
        //    dal.Delete(id);
        //}
        [WebMethod]
        public String ShowAll()
        {
            
            CustmerBLL b = new CustmerBLL();


            return JsonConvert.SerializeObject(b.ShowAll(), Formatting.Indented);

        }
    }
}
