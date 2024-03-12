<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="CartSection.aspx.cs" Inherits="ShoppingCart_Application.CartSection" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

     <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap@4.6.2/dist/css/bootstrap.min.css">
   

    <style type="text/css">
        *{
            padding:0;
            margin:0;
            box-sizing:border-box;
        }
        .newStyle5 {
            font-family: "Segoe UI", Tahoma, Geneva, Verdana, sans-serif;
        }

        table tr th{
            background-color:#E2EAFF;
            text-align:center;
            padding:15px;
            
        }

       .newStyle6 td {
          padding:20px;
       }

       table td label{
           text-align:center;
       }

        .btn{
         margin:5px;
         color:#fff;
         font-weight:400;
        }
        
         .btnBuy{
             background-color:#FB641B;
         }

          .btn.btnBuy:hover {
              background-color: #cf4300;
              color:#fff;
          }

    </style>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:DataList ID="DataList1" runat="server" Width="100%" CssClass="newStyle5" OnItemCommand="DataList1_ItemCommand">
        
       <HeaderTemplate>
            <table width="100%" align="center">
               <tr>
                 <th>Product Name</th>
                 <th>Description</th>
                 <th>Price</th>
                 <th>Image</th>
                 <th>Quantity</th>
                 <th>Total</th>
                 <th></th>
                </tr>

       </HeaderTemplate>

        <ItemTemplate>
           
                 <tr style="text-align:center; border:1px solid #1e1d1d79" class="newStyle6">

                     <td>
                           <asp:Label   runat="server" ID="pname" Text='<%# Eval("ProductName") %>' />
                     </td>
                     <td>
                           <asp:Label   runat="server" ID="pdesc" Text='<%# Eval("Description") %>' />
                     </td>
                     <td>
                            Price : ₹<asp:Label BorderStyle="None" runat="server" ID="pprice" Text='<%# Eval("ProductPrice") %>' />
                     </td>
                     <td>
                        <asp:image width="" Height="120"  runat="server" ID="img1" ImageUrl='<%# "/Product_Images/" +  Eval("ProductImage") %>' />

                     </td>
                      <td >
                        <asp:Label BorderStyle="None" runat="server" ID="txtqty" Text='<%# Eval("Quantity") %>' />
                      </td>
                     <td>
                        ₹<asp:Label BorderStyle="None" runat="server" ID="txttotal" Text='<%# Eval("Total") %>' />
                    </td>
                      <td>
                       <asp:Button type="button" class="btn btn-danger" runat="server" ID="deletebutton" Text="Remove"  CommandName="Delete" CommandArgument='<%#Eval("ProductID")%>' PostBackUrl="~/CartSection.aspx" />
                      </td>
                 </tr>
           

        </ItemTemplate>

        <FooterTemplate>
               </table>
        </FooterTemplate>

    </asp:DataList>

   <strong><p  style="padding: 20px 80px 0 0" class="text-right">Grand Total : ₹<asp:Label ID="lblGrandTotal" runat="server" Text="0"></asp:Label>
    </p></strong>
    
                        <div style="text-align:center; padding-bottom:10px">
                            <asp:Button type="button" class="btn btn-info" runat="server" ID="backbutton" Text="Back" PostBackUrl="~/HomePage.aspx" />
                        <button type="button" class="btn btnBuy" ID="btnBuy" runat="server" CommandName="ProceedtoBuy" CommandArgument='<%#Eval("ProductID")%>'>Proceed To Buy</button></div>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:Shopping_CartConnectionString %>" SelectCommand="SELECT * FROM [Cart_Details]"></asp:SqlDataSource>

</asp:Content>
   
