﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ShoppingCart_Application
{
    public partial class MenPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void DataList1_ItemCommand(object source, DataListCommandEventArgs e)
        {
            int PID = Convert.ToInt32(e.CommandArgument);

            Response.Redirect("ProductDetails.aspx?PID=" + PID);
        }

    }
}