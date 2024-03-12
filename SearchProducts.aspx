<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="SearchProducts.aspx.cs" Inherits="ShoppingCart_Application.Electronics_bg.SeachProducts" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <head>
 

     <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.5.2/css/bootstrap.min.css">
     <script src="https://code.jquery.com/jquery-3.5.1.slim.min.js"></script>
     <script src="https://cdn.jsdelivr.net/npm/@popperjs/core@2.10.2/dist/umd/popper.min.js"></script>
     <script src="https://stackpath.bootstrapcdn.com/bootstrap/4.5.2/js/bootstrap.min.js"></script>

     <link href="StyleSheet.css"/>
     <style type="text/css">

     .carousel-inner img {
         width: 100%;
         height: 100%;
     }


     table tr{
         line-height:1.5;
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

    .newStyle5 {
         font-family: "Segoe UI", Tahoma, Geneva, Verdana, sans-serif;
    }

     </style>

 </head>
 
 <body>

     <!-- Table Section -->

             <h2 class="newStyle5" style="text-align: center; font-weight:700; padding:15px; background-color:#93d6f77e; letter-spacing:2px">Search Product's</h2>
            <asp:DataList ID="DataList1" runat="server" DataKeyField="ProductID"  RepeatColumns="3" Width="100%" Height="744px" OnItemCommand="DataList1_ItemCommand"  >

           <ItemTemplate>

            <table style="width:100%; display:flex; justify-content:center">
            <tr style="width:100%">
                <td style="width:100%">
                    <table style="width:100%; padding:20px; margin:15px; display:flex; justify-content:center">
                        <tr width="100%" style="margin:10px">
                            <td  align="center" valign="top">
                                <asp:Label ID="lblProductName" runat="server" Font-Bold="true" Text='<%# Eval("ProductName")%>'></asp:Label>
                            </td>
                        </tr>
                         <tr width="100%"  style="margin:10px" >
                            <td  align="center" valign="top">
                                <asp:Label ID="lblProductDescription" runat="server" Text='<%# Eval("Description")%>'></asp:Label>
                            </td>
                        </tr>
                  <tr width="100%">
                  
                            <td  align="center" valign="top">
                                    <a href='<%# Eval("ProductID","ProductDetails.aspx?PID={0}")%>'>
                                <img id="Img1" alt='<%#Eval("ProductImage")%>' src='<%# "/Product_Images/" + Eval("ProductImage","{0}")%>' style="border-width:0; padding:10px 0" height="200"  runat="server" />
                                </a> 
                            </td>
                        </tr>
             
                        <tr width="100%">
                            <td  align="center" valign="top">
                                Price: <asp:Label ID="lblPrice" Font-Bold="true" runat="server" Text='<%#Eval("ProductPrice","₹{0}")%>'></asp:Label>
                            </td>
                        </tr>
                        <tr width="100%">
                            <td  align="center" valign="top" style="padding:10px">
                                <button type="button" class="btn btnCart" runat="server" ID="cartbutton">
                                    <a href='<%# Eval("ProductID","CartSection.aspx?ProductID={0}") %>' style="text-decoration:none; color:#fff; font-weight:400">Add To Cart</a>
                                </button>
                                <button type="button" class="btn btnBuy" ID="btnBuy" runat="server" CommandName="Buy" CommandArgument='<%#Eval("ProductID")%>'>Buy Now</button>

                            </td>
                        </tr>
                    </table>
                </td>
              
            </tr>
        </table>

    </ItemTemplate>

</asp:DataList>

     </body>
</asp:Content>
