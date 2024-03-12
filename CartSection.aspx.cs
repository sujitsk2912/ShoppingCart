using System;
using System.Data.SqlClient;
using System.Data;
using System.Web.UI.WebControls;

namespace ShoppingCart_Application
{
    public partial class CartSection : System.Web.UI.Page
    {
        string connection = "Data Source=LAPTOP-CNVSH31R\\SQLEXPRESS01;Initial Catalog=Shopping_Cart;Integrated Security=True";
        SqlDataReader reader;
        protected void Page_Load(object sender, EventArgs e)
        {
            

            SqlConnection con = new SqlConnection(connection);

            int PID = Convert.ToInt32(Request.QueryString["ProductID"]);
            Session["ProductID"] = PID;

            string ProdName = null;
            string ProdDesc = null;
            float ProdPrice = 0;
            int Qty = 0;
            string ProdImage = null;
            string SessionId = null;

            SessionId = Session.SessionID;

            try
            {
                con.Open();

                string Query1 = "select count(*) from Cart_Details where ProductID = @ProductID and SessionID = @SessionID1";
                SqlCommand cmd1 = new SqlCommand(Query1, con);
                cmd1.Parameters.AddWithValue("@ProductID", PID);
                cmd1.Parameters.AddWithValue("@SessionID1", SessionId);
                int cnt = 0;
                cnt = Convert.ToInt32(cmd1.ExecuteScalar());

                try
                {
                    string Query2 = null;

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

                    if (cnt == 0)
                    {
                        if (PID >= MinProductID && PID <= MaxProductID)
                        {
                            Query2 = "SELECT * FROM Product_Table  where ProductID = @ProductID ";
                        }
                        else if (PID >= MinMensID && PID <= MaxMensID)
                        {
                            Query2 = "SELECT * FROM Mens_Products  where ProductID = @ProductID ";
                        }
                        else if (PID >= MinWomensID && PID <= MaxWomensID)
                        {
                            Query2 = "SELECT * FROM Womens_Products  where ProductID = @ProductID ";
                        }
                        else if (PID >= MinKidsID && PID <= MaxKidsID)
                        {
                            Query2 = "SELECT * FROM Kids_Products  where ProductID = @ProductID ";
                        }
                        else if (PID >= MinHomeLeaveID && PID <= MaxHomeLeaveID)
                        {
                            Query2 = "SELECT * FROM Home_Leaving_Products  where ProductID = @ProductID ";
                        }
                        else if (PID >= MinBeautyID && PID <= MaxBeautyID)
                        {
                            Query2 = "SELECT * FROM Beauty_Products where ProductID = @ProductID ";
                        }
                        else if (PID >= MinElectronicsID && PID <= MaxElectronicsID)
                        {
                            Query2 = "SELECT * FROM Electronics_Products where ProductID = @ProductID ";
                        }

                        SqlCommand cmd2 = new SqlCommand(Query2, con);
                        cmd2.Parameters.AddWithValue("@ProductID", PID);

                        using (reader = cmd2.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                ProdName = reader["ProductName"].ToString();
                                ProdDesc = reader["Description"].ToString();
                                ProdPrice = Convert.ToSingle(reader["ProductPrice"]);
                                Qty = 1;
                                ProdImage = reader["ProductImage"].ToString();
                            }

                            reader.Close();

                            // Insert record into cart

                            Query2 = "insert into Cart_Details values (@ProductID, @ProductName, @Description, @ProductPrice, @ProductImage, @SessionID, @Quantity, @Total)";
                            cmd2 = new SqlCommand(Query2, con);

                            cmd2.Parameters.AddWithValue("@ProductID", PID);
                            cmd2.Parameters.AddWithValue("@ProductName", ProdName);
                            cmd2.Parameters.AddWithValue("@Description", ProdDesc);
                            cmd2.Parameters.AddWithValue("@ProductPrice", ProdPrice);
                            cmd2.Parameters.AddWithValue("@ProductImage", ProdImage);
                            cmd2.Parameters.AddWithValue("@SessionID", SessionId);
                            cmd2.Parameters.AddWithValue("@Quantity", Qty);
                            cmd2.Parameters.AddWithValue("@Total", (Qty * ProdPrice));

                            cmd2.ExecuteNonQuery();
                        }
                    }
                    else
                    {
                        string Query3 = "select * from Cart_Details where ProductID = @ProductID and SessionID = @SessionID2";
                        SqlCommand cmd3 = new SqlCommand(Query3, con);

                        cmd3.Parameters.AddWithValue("@ProductID", PID);
                        cmd3.Parameters.AddWithValue("@SessionID2", SessionId);
                        int Qty1 = 0;
                        using (reader = cmd3.ExecuteReader())
                        {

                            while (reader.Read())
                            {
                                ProdName = reader["ProductName"].ToString();
                                ProdDesc = reader["Description"].ToString();
                                ProdPrice = Convert.ToSingle(reader["ProductPrice"]);
                                Qty1 = Convert.ToInt32(reader["Quantity"].ToString());
                                Qty1 = Qty1 + 1;
                                ProdImage = reader["ProductImage"].ToString();

                            }

                            reader.Close();

                            //Update the Qunatity record in Cart Table

                            Query3 = "update Cart_Details set Quantity = @Quantity, Total = @Total where ProductID = @ProductID and SessionID = @SessionID2";
                            cmd3 = new SqlCommand(Query3, con);

                            cmd3.Parameters.AddWithValue("@Quantity", Qty1);
                            cmd3.Parameters.AddWithValue("@Total", (Qty1 * ProdPrice));
                            cmd3.Parameters.AddWithValue("@ProductID", PID);
                            cmd3.Parameters.AddWithValue("@SessionID2", SessionId);

                            cmd3.ExecuteNonQuery();
                        }
                    }

                    string Query4 = "select ProductID, ProductName, Description, ProductPrice, ProductImage, SessionID, Quantity, Total  from Cart_Details where SessionID = @SessionID";

                    SqlDataAdapter adapter = new SqlDataAdapter(Query4, con);

                    adapter.SelectCommand.Parameters.AddWithValue("@SessionID", SessionId);
                    DataSet dataset = new DataSet();
                    adapter.Fill(dataset, "Cart");
                    DataList1.DataSource = dataset.Tables["Cart"];
                    DataList1.DataBind();

                    float GrandTotal = 0;

                    foreach (DataRow dr1 in dataset.Tables["Cart"].Rows)
                    {
                        GrandTotal = GrandTotal + Convert.ToSingle(dr1["Total"]);
                    }

                    lblGrandTotal.Text = GrandTotal.ToString();

                }
                catch (Exception ext)
                {
                    Response.Write(ext.ToString());
                }
            }
            catch (Exception ex)
            {
                Response.Write(ex.ToString());
            }
            finally
            {
                con.Close();
            }
        }

        public void DataList1_ItemCommand(object source, DataListCommandEventArgs e)
        {
            if (e.CommandName == "Delete")
            {
                int productIdToDelete = Convert.ToInt32(e.CommandArgument);
                DeleteCartItem(productIdToDelete);
                BindCartData();
            }
        }

        private void DeleteCartItem(int productId)
        {
            using (SqlConnection con = new SqlConnection(connection))
            {
                try
                {
                    con.Open();

                    string query = "DELETE FROM Cart_Details WHERE ProductID = @ProductID ";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@ProductID", productId);
                   

                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                   // Response.Write(ex.ToString());
                }
            }
        }

        private void BindCartData()
        {
            using (SqlConnection con = new SqlConnection(connection))
            {
                try
                {
                    con.Open();

                    string query = "SELECT ProductID, ProductName, Description, ProductPrice, ProductImage, SessionID, Quantity, Total FROM Cart_Details WHERE SessionID = @SessionID";
                    SqlDataAdapter adapter = new SqlDataAdapter(query, con);
                    adapter.SelectCommand.Parameters.AddWithValue("@SessionID", Session.SessionID);

                    DataSet dataset = new DataSet();
                    adapter.Fill(dataset, "Cart");

                    DataList1.DataSource = dataset.Tables["Cart"];
                    DataList1.DataBind();

                    float grandTotal = 0;

                    foreach (DataRow dr1 in dataset.Tables["Cart"].Rows)
                    {
                        grandTotal += Convert.ToSingle(dr1["Total"]);
                    }

                    lblGrandTotal.Text = grandTotal.ToString();
                }
                catch (Exception ex)
                {
                  //  Response.Write(ex.ToString());
                }
            }
        }

    }
}
