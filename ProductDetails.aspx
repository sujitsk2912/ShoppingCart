<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="ProductDetails.aspx.cs" Inherits="ShoppingCart_Application.ProductDetails" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap@4.6.2/dist/css/bootstrap.min.css">
    <style type="text/css">
      
         *{
             padding:0;
             margin:0;
             box-sizing:border-box;
             background-color:#fff;
         }
        .newStyle5 {
            font-family: "Segoe UI", Tahoma, Geneva, Verdana, sans-serif;
        }
        .newStyle6 {
            font-family: "Segoe UI", Tahoma, Geneva, Verdana, sans-serif;
            text-align: center;
            padding:10px;
            letter-spacing:2px;
        }
        
        .newStyle7 {
            font-family: "Segoe UI", Tahoma, Geneva, Verdana, sans-serif;
        }
        .newStyle8 {
            font-family: "Segoe UI", Tahoma, Geneva, Verdana, sans-serif;
            font-size: medium;
        }
        .newStyle9 {
            font-size: large;
            font-family: "Segoe UI", Tahoma, Geneva, Verdana, sans-serif;
        }

        .btn{
            margin:5px;
            color:#fff;
            font-weight:400;
        }

        .btnBuy{
            background-color:#FB641B;
        }

        .btnCart{
            background-color:#FF9F00;
        }

         .btn.btnCart:hover {
             background-color: #cd8000;
             color:#fff;
         }

         .btn.btnBuy:hover {
             background-color: #cf4300;
             color:#fff;
         }

        .hover-image {
            transition: transform 0.4s ease;
        }

        .hover-image:hover {
            transform: scale(1.1);
        }

    </style>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2 class="newStyle6">Product Details</h2>
       <hr/>
    <asp:DataList ID="DataList1" runat="server" Width="100%" CssClass="newStyle9">
        <ItemTemplate>

            <table align="center" style="width:100%; padding:20px" border="0">
                <tr>
                    <td style="padding:10px">
                        <Center>
                            <asp:Image Height="350" runat="server" ID="img1" ImageUrl='<%#  "/Product_Images/" + Eval("ProductImage") %>' class="hover-image" />
                        </Center>
                            </td>

                    <td style="padding:10px; line-height:30px">
                        <p id="Prodname" style="font-weight:600">
                        <asp:Label   runat="server" ID="pname"  Text='<%# Eval("ProductName") %>' /></p>

                        <p id="description">
                           <asp:Label   runat="server" ID="pdesc" Text='<%# Eval("Description") %>' /></p>

                        <p id="price" style="font-weight:600">
                      Price : ₹</span><asp:Label   runat="server" ID="pprice" Text='<%# Eval("ProductPrice") %>' /></p>

                        <div style="">
                            <asp:Button type="button" class="btn btn-info" runat="server" ID="backbutton" Text="Back" PostBackUrl="~/HomePage.aspx" />
                                 <button type="button" class="btn btnCart" runat="server" ID="Button1">
                                    <a href='<%# Eval("ProductID","CartSection.aspx?ProductID={0}") %>' style="text-decoration:none; color:#fff; font-weight:400">Add To Cart</a>
                                </button>
                             <button type="button" class="btn btnBuy" ID="btnBuy" runat="server" CommandName="Buy" CommandArgument='<%#Eval("ProductID")%>'>Buy Now</button>
                        </div>
                    </td>

                </tr>
            </table>
           
        </ItemTemplate>
       
    </asp:DataList>
    
</asp:Content>

