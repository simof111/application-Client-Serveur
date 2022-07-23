using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using DAL;


namespace UI
{
    public partial class Home_page : System.Web.UI.Page
    {
        CustmerBLL bll;
        
        public void Afficher()
        {
            
            GridView1.DataSource = bll.ShowAll();
            GridView1.DataBind();
        }
        public int index;
        public void ClearText()
        {
            txtname.Text = txtadress.Text = txtpincode.Text = txtcountry.Text = txtcity.Text = "";
        }

        public void Save()
        {
            bll = new CustmerBLL();
            Custmer cust = new Custmer();
            cust.Name = txtname.Text;
            cust.Adress = txtadress.Text;
            cust.Country = txtcountry.Text;
            cust.City = txtcity.Text;
            cust.PinCode = txtpincode.Text;
            bll.InsetB(cust);
        }
        public void Upadate()
        {
            bll = new CustmerBLL();
            
            Custmer CustUpdate = new Custmer();
            CustUpdate.Id = index;
            CustUpdate.Name = txtname.Text;
            CustUpdate.Adress = txtadress.Text;
            CustUpdate.Country = txtcountry.Text;
            CustUpdate.City = txtcity.Text;
            CustUpdate.PinCode = txtpincode.Text;
            bll.UpdateB(CustUpdate);
            
        }
        
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void add_Click(object sender, EventArgs e)
        {
            if (drType.Text == "New Custmer")
            {
                Save();

            }
            else if (drType.Text == "Update Custmer")
            {
                Upadate();
               
            }
            Afficher();
            ClearText();
            
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            bll = new CustmerBLL();
            Afficher();
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            ClearText();
            index = GridView1.SelectedIndex;
            txtname.Text = GridView1.Rows[index].Cells[0].Text;
            txtadress.Text = GridView1.Rows[index].Cells[1].Text;
            txtcountry.Text = GridView1.Rows[index].Cells[2].Text;
            txtcity.Text = GridView1.Rows[index].Cells[3].Text;
            txtpincode.Text = GridView1.Rows[index].Cells[4].Text;
            
           
        }

        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {

            
        }

        protected void GridView1_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {
            
           
        }

        protected void radnew_CheckedChanged(object sender, EventArgs e)
        {
            

        }

        protected void radup_CheckedChanged(object sender, EventArgs e)
        {
           
            
        }
    }
}