using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;
using System.Security.Cryptography;
using TheArtOfDevHtmlRenderer.Adapters;

namespace ShoppingCart_Application.Electronics_bg
{
    
    public partial class SeachProducts : System.Web.UI.Page
    {
        string connection = "Data Source=LAPTOP-CNVSH31R\\SQLEXPRESS01;Initial Catalog=Shopping_Cart;Integrated Security=True";

        SqlConnection con;
        SqlDataAdapter adapter;
        DataSet dataset;
        protected void Page_Load(object sender, EventArgs e)
        {
            string SearchValue = Request.QueryString["Search"].ToString();

            con = new SqlConnection(connection);
            try
            {
                con.Open();

                string Query = "SELECT * FROM Product_Table WHERE ProductName LIKE '%" + SearchValue + "%' " +
                "UNION " +
                "SELECT * FROM Beauty_Products WHERE ProductName LIKE '%" + SearchValue + "%' " +
                "UNION " +
                "SELECT * FROM Electronics_Products WHERE ProductName LIKE '%" + SearchValue + "%' " +
                "UNION " +
                "SELECT * FROM Home_Leaving_Products WHERE ProductName LIKE '%" + SearchValue + "%' " +
                "UNION " +
                "SELECT * FROM Kids_Products WHERE ProductName LIKE '%" + SearchValue + "%' " +
                "UNION " +
                "SELECT * FROM Mens_Products WHERE ProductName LIKE '%" + SearchValue + "%' " +
                "UNION " +
                "SELECT * FROM Womens_Products WHERE ProductName LIKE '%" + SearchValue + "%'";

                adapter = new SqlDataAdapter(Query, con);
                dataset = new DataSet();
                adapter.Fill(dataset, "ProductDetails");
                DataList1.DataSource = dataset.Tables["ProductDetails"];
                DataList1.DataBind();

            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
            }
            finally
            {
                con.Close();
            }
        }

        protected void DataList1_ItemCommand(object source, DataListCommandEventArgs e)
        {

            int PID = Convert.ToInt32(e.CommandArgument);

            Response.Redirect("ProductDetails.aspx?PID=" + PID);
        }
    }
}