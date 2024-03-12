<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="KidsSection.aspx.cs" Inherits="ShoppingCart_Application.Kids" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
            <head>

              <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.5.2/css/bootstrap.min.css">
    <script src="https://code.jquery.com/jquery-3.5.1.slim.min.js"></script>
    <script src="https://cdn.jsdelivr.net/npm/@popperjs/core@2.10.2/dist/umd/popper.min.js"></script>
    <script src="https://stackpath.bootstrapcdn.com/bootstrap/4.5.2/js/bootstrap.min.js"></script>


    
    <style type="text/css">

         .carousel-inner img {
             width: 100%;
             height: 100%;
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

            
      <!-- start of carousel section -->

        <div class="container-fluid" margin-top:2%">
	        <div id="demo" class="carousel slide" data-ride="carousel" data-interval="4000">	

		        <!-- The slideshow -->
		        <div class="carousel-inner">
			        <div class="carousel-item active">
				        <img src="Kids_bg/kbg1.png" alt="" >
			        </div>
			        <div class="carousel-item">
				        <img src="Kids_bg/kbg2.png" alt="" >
			        </div>
			        <div class="carousel-item">
				        <img src="Kids_bg/kbg3.png" alt="" >
			        </div>
                    <div class="carousel-item">
                        <img src="Kids_bg/kbg4.png" alt="" >
                    </div>
                    <div class="carousel-item">
                        <img src="Kids_bg/kbg5.png" alt="" >
                    </div>
                    <div class="carousel-item">
                        <img src="Kids_bg/kbg6.png" alt="" >
                    </div>
                    <div class="carousel-item">
                        <img src="Kids_bg/kbg7.jpg" alt="" >
                    </div>
                     <div class="carousel-item">
                         <img src="Kids_bg/kbg8.png" alt="" >
                     </div>
                     <div class="carousel-item">
                         <img src="Kids_bg/kbg9.png" alt="" >
                     </div>
                     <div class="carousel-item">
                         <img src="Kids_bg/kbg10.gif" alt="" >
                     </div>
		        </div>
		
		         <!-- Left and right controls -->
		        <a class="carousel-control-prev" href="#demo" data-slide="prev">
			        <span class="carousel-control-prev-icon"></span>
		        </a>
		        <a class="carousel-control-next" href="#demo" data-slide="next">
			        <span class="carousel-control-next-icon"></span>
		        </a>
		
		        <!-- Indicators -->
		        <ul class="carousel-indicators" style="background-color:transparent">
			        <li data-target="#demo" data-slide-to="0" class="active"></li>
			        <li data-target="#demo" data-slide-to="1"></li>
			        <li data-target="#demo" data-slide-to="2"></li>
			        <li data-target="#demo" data-slide-to="3"></li>
			        <li data-target="#demo" data-slide-to="4"></li>
			        <li data-target="#demo" data-slide-to="5"></li>
			        <li data-target="#demo" data-slide-to="6"></li>
			        <li data-target="#demo" data-slide-to="7"></li>
			        <li data-target="#demo" data-slide-to="8"></li>
			        <li data-target="#demo" data-slide-to="9"></li>
		        </ul> 
	        </div>
        </div>

        <!--end of carousel section -->

            <div>
                <br />
        <h2 class="newStyle5" style="text-align: center; font-weight:700; padding:20px; background-color:#93d6f77e; letter-spacing:2px">Kid's Wear</h2>
            <asp:DataList ID="DataList1" runat="server" DataKeyField="ProductID" DataSourceID="SqlDataSource1" RepeatColumns="3" Width="100%" Height="744px" OnItemCommand="DataList1_ItemCommand" >

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
                               <img id="Img1" alt='<%#Eval("ProductImage")%>' src='<%# "/Product_Images/" + Eval("ProductImage", "{0}") %>' style="border-width:0; padding:10px 0" height="200
                                   "  runat="server" />
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
<asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:Shopping_CartConnectionString %>" SelectCommand="SELECT * FROM [Kids_Products]"></asp:SqlDataSource>
    
    </div>
    </body>
</asp:Content>
