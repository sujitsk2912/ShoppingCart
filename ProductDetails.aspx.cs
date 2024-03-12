using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ShoppingCart_Application
{
    public partial class ProductDetails : System.Web.UI.Page
    {
        string connection = "Data Source=LAPTOP-CNVSH31R\\SQLEXPRESS01;Initial Catalog=Shopping_Cart;Integrated Security=True";

        SqlConnection con;
        SqlDataAdapter adapter;
        DataSet dataset;
        protected void Page_Load(object sender, EventArgs e)
        {
            int PID = Convert.ToInt32(Request.QueryString["PID"]);
          //  Session["PID"] = PID;

            con = new SqlConnection(connection);
            try
            {
                con.Open();

                string Query = null;

                SqlCommand Max1 = new SqlCommand("select max(ProductID) from Product_Table", con);
                int MaxProductID = Convert.ToInt32(Max1.ExecuteScalar());
                SqlCommand Min1 = new SqlCommand("select min(ProductID) from Product_Table", con);
                int MinProductID = Convert.ToInt32(Min1.ExecuteScalar());

                SqlCommand Max2 = new SqlCommand("select max(ProductID) from Mens_Products", con);
                int MaxMensID = Convert.ToInt32(Max2.ExecuteScalar());
                SqlCommand Min2 = new SqlCommand("select min(ProductID) from Mens_Products", con);
                int MinMensID = Convert.ToInt32(Min2.ExecuteScalar());

                SqlCommand Max3 = new SqlCommand("select max(ProductID) from Womens_Products", con);
                int MaxWomensID = Convert.ToInt32(Max3.ExecuteScalar());
                SqlCommand Min3 = new SqlCommand("select min(ProductID) from Womens_Products", con);
                int MinWomensID = Convert.ToInt32(Min3.ExecuteScalar());

                SqlCommand Max4 = new SqlCommand("select max(ProductID) from Kids_Products", con);
                int MaxKidsID = Convert.ToInt32(Max4.ExecuteScalar());
                SqlCommand Min4 = new SqlCommand("select min(ProductID) from Kids_Products", con);
                int MinKidsID = Convert.ToInt32(Min4.ExecuteScalar());

                SqlCommand Max5 = new SqlCommand("select max(ProductID) from Home_Leaving_Products", con);
                int MaxHomeLeaveID = Convert.ToInt32(Max5.ExecuteScalar());
                SqlCommand Min5 = new SqlCommand("select min(ProductID) from Home_Leaving_Products", con);
                int MinHomeLeaveID = Convert.ToInt32(Min5.ExecuteScalar());

                SqlCommand Max6 = new SqlCommand("select max(ProductID) from Beauty_Products", con);
                int MaxBeautyID = Convert.ToInt32(Max6.ExecuteScalar());
                SqlCommand Min6 = new SqlCommand("select min(ProductID) from Beauty_Products", con);
                int MinBeautyID = Convert.ToInt32(Min6.ExecuteScalar());

                SqlCommand Max7 = new SqlCommand("select max(ProductID) from Electronics_Products", con);
                int MaxElectronicsID = Convert.ToInt32(Max7.ExecuteScalar());
                SqlCommand Min7 = new SqlCommand("select min(ProductID) from Electronics_Products", con);
                int MinElectronicsID = Convert.ToInt32(Min7.ExecuteScalar());


                if (PID >= MinProductID && PID <= MaxProductID)
                {
                    Query = "SELECT * FROM Product_Table  where ProductID = '"+ PID +"' ";
                }
                else if (PID >= MinMensID && PID <= MaxMensID)
                {
                    Query = "SELECT * FROM Mens_Products  where ProductID = '"+ PID +"' ";
                }
                else if (PID >= MinWomensID && PID <= MaxWomensID)
                {
                    Query = "SELECT * FROM Womens_Products  where ProductID = '"+ PID +"' ";
                }
                else if (PID >= MinKidsID && PID <= MaxKidsID)
                {
                    Query = "SELECT * FROM Kids_Products  where ProductID = '"+ PID +"' ";
                }
                else if (PID >= MinHomeLeaveID && PID <= MaxHomeLeaveID)
                {
                    Query = "SELECT * FROM Home_Leaving_Products  where ProductID = '" + PID + "' ";
                }
                else if (PID >= MinBeautyID && PID <= MaxBeautyID)
                {
                    Query = "SELECT * FROM Beauty_Products where ProductID = '" + PID + "' ";
                }
                else if (PID >= MinElectronicsID && PID <= MaxElectronicsID)
                {
                    Query = "SELECT * FROM Electronics_Products where ProductID = '" + PID + "' ";
                }

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

        protected void DataList1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}