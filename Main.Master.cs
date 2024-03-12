using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ShoppingCart_Application
{
    public partial class Home : System.Web.UI.MasterPage
    {
       
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void PerformSearch()
        {
            Response.Redirect("SearchProducts.aspx?Search=" + Search.Text + "");
        }

    }
}