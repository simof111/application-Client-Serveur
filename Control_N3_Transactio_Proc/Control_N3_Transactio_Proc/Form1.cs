using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
namespace Control_N3_Transactio_Proc
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public static SqlConnection Cone = new SqlConnection("data source=(local) ;initial catalog = Gestion_Notes  ; integrated security =true");
        public static SqlCommand OCN1 = new SqlCommand();
        public static SqlCommand OCMD1 = new SqlCommand();
        public static SqlDataReader ORD1;
        public static SqlTransaction OTR1;

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
