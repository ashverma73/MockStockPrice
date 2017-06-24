<%@ Page Title="Home Page" Language="C#" AutoEventWireup="true"
    CodeBehind="Default.aspx.cs" Inherits="MockStockPrice._Default" %>
<html xmlns="http://www.w3.org/1999/xhtml" xml:lang="en">
<head runat="server">
    <title></title>
    
    <link href="Styles/Site.css" rel="stylesheet" type="text/css" />
    <link href="http://ajax.googleapis.com/ajax/libs/jqueryui/1.8/themes/base/jquery-ui.css" rel="stylesheet" type="text/css" />
    
    <script language="javascript"  type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.5/jquery.min.js"></script>  
    <script language="javascript"  type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jqueryui/1.8/jquery-ui.min.js"></script> 
    <script language="javascript"  type="text/javascript" src="Scripts/Stock.js"></script> 
    <script src="Scripts/jquery.signalR-2.2.2.js"></script>
    <script src="signalr/hubs"></script>
     <script src="Scripts/SignalR.PriceTicker.js"></script>
    
</head>
<body>
     <div class="page">
    <form runat="server">
                <table width="100%"><tr><td align="middle">
        
            <asp:Label ID="Label1" runat="server" Text="Stock Price Mocker"></asp:Label>
       
          </td></tr>  
            <tr><td> Enter stock ticker: <asp:TextBox ID="txtTicker" runat="server"></asp:TextBox></td></tr>

        </table>
    
     <br />
     <div>
        <table id="tblStocks" class="tblStocks"  >            
            <thead>
                <tr>
                    <th  class="stockth">Ticker</th>    
                    <th  class="stockth">Name</th>    
                    <th  class="stockth">Prev. Close</th>    
                    <th  class="stockth">CurrentPrice</th> 
                    <th  class="stockth">Chg</th>
                    <th  class="stockth">Direction</th>
                     
                </tr>
            </thead> 
            <tbody>
            
            </tbody> 
        </table>        
     </div>
         </form>
   
   
   

         </div>
</body>
</html>
