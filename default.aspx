<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="WebAuction._default"%>
<%--<%=_watch.name%>
<%=_watch.highestBid%>
<%=_watch.currentBid%>--%>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
  <meta name="viewport" content="width=device-width, initial-scale=1"/>
     <link rel="stylesheet" href="Styles/bootstrap.css" />
     <link href="https://fonts.googleapis.com/css?family=Nunito+Sans|Tangerine" rel="stylesheet"/>
     <link rel="stylesheet" href="Styles/styles.css" />
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.2.1/jquery.min.js"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/js/bootstrap.min.js"></script>
    <title></title>    
</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager> 
        <asp:Timer ID="Timer1" runat="server" OnTick="Timer1_Tick" Interval="60000">
        </asp:Timer>
     
            <h1> Vintage Watch Auction</h1>
        <hr />
            
        
        <h3 id="listing">Current selection available for bidding</h3>
        <div class="container content">
              <div class="row">
                   <div class="col-md-4">
                    <asp:Image ID="Image1" runat="server" Height="200" Width="200" ImageUrl="~/rolextp.png"/> 
                </div>
                  <div class="col-md-4">
                  <asp:Image ID="Image2" runat="server" Height="200" Width="200" ImageUrl="~/Chanel1.png"/>
                   </div>
                  <div class="col-md-4">
             <asp:Image ID="Image3" runat="server" Height="200" Width="200" ImageUrl="~/omegasm.png"/>
                </div>
            </div>
            <div class ="row">
                  <div class="col-md-4">
                    <button type="button" class="btn btn-info" data-toggle="collapse" data-target="#demo">Rolex Oyster Description</button>
                        <div id="demo" class="collapse">
                            Outstanding 1979 Rolex Oyster Perpetual Date Gents Vintage Watch. 12-Hour Dial, COSC Certified Chronometer, Date Indicator, Screwback Case
                        </div>
                </div> 
                 <div class="col-md-4">
                    <button type="button" class="btn btn-info" data-toggle="collapse" data-target="#demo2"> Chanel J12 Description</button>
                        <div id="demo2" class="collapse">
                            Chanel J12 White Unisex Watch
                            Crisp, contemporary, and effortlessly chic, this Chanel J12 White Unisex Watch exudes the unrivalled confidence, style,
                             and sophistication that we have come to expect from this iconic brand.
                        </div>
                </div> 
                 <div class="col-md-4">
                    <button type="button" class="btn btn-info" data-toggle="collapse" data-target="#demo3">Omega Sea Master Description</button>
                        <div id="demo3" class="collapse">
                            This Seamaster 300 has a blue enamel dial with 18K white gold hands coated with "vintage" Super-LumiNova. The polished ceramic bezel ring has an 850-grade platinum Liquidmetal® diving scale.
                            The 41 mm brushed and polished 950 platinum case is presented on a matching bracelet.
                        </div>
                </div> 
        </div>
    </div>

       
       <div class="container"> 
           <div class="jumbotron">
        <h3>CURRENT TIME REMAINING:</h3> 
             <asp:Label ID="Label5" runat="server" Font-Size="Medium" Font-Underline="true" Text="Time remaining"></asp:Label>
              
        <hr />
        <p>Please select an option from the dropdown list to start bidding 
         <asp:ListBox ID="ListBox1" runat="server" Height="51px" Width="152px" ForeColor="Black">
        </asp:ListBox>
       </p>
       
        </div>
         </div>
        <div class="container">
            <div class="jumbotron" id="bidTicker">
                  <h3>Please enter the amount you would like to bid</h3>
            <asp:updatepanel runat="server">
     <ContentTemplate>
         &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
         <asp:Button ID="bid" runat="server" Height="33px" Text="BID(£)" Width="109px" OnClick="bid_Click" ForeColor="Black" CausesValidation="true"/>
         <asp:TextBox ID="inputB" runat="server" BackColor="White" ForeColor="#000099" ToolTip="Enter a amount in £x.xx"></asp:TextBox>
         &nbsp;&nbsp;
          
        <asp:RegularExpressionValidator runat="server" id="bidAmount"
            ControlToValidate="inputB"
            ErrorMessage="Only numeric allowed." ForeColor="Red"
            ValidationExpression="^[0-9]+(\.[0-9]{1,2})?$" Text="*Please enter in Currency Format Please"/>
         
         <br />
         
         <asp:RangeValidator runat="server" id="bidRange"
           ControlToValidate ="inputB"
           MinimumValue="1"
           MaximumValue="999999"
           Type="Double"
           SetFocusOnError="true"
           Text="Please enter an amount between 1-999,999" /> 
                
            <br />
     
                 <asp:Label ID="Label1" runat="server"></asp:Label>
     
                 <div>
                     <updatepanel> 
                         <h3>**Current Bid Status**</h3>
                     </updatepanel>
                 </div>
                    <asp:Label ID="_label2" runat="server" Text="_Label2"></asp:Label>
     
                 <br />
                    <asp:Label ID="label4" runat="server" Text="label4"></asp:Label>
                 <br />
                     <asp:Label ID="label6" runat="server" Text="Label"></asp:Label>
                 <asp:Timer ID="Timer2" runat="server" Interval="15000" OnTick="Timer2_Tick"></asp:Timer>
             </ContentTemplate>
            </asp:updatepanel>
         </div>
   </div>  
        <div class="container">
            <div class ="jumbotron">

            <asp:Panel ID="Panel1" Height ="200px" Width="81%" runat ="server" style="margin-left: 61px; margin-top: 18px">
            
                <asp:Label  ID="EndAuction" runat="server" Font-Size="Large" Font-Bold="True" Font-Names="Arial" CssClass="text-success"></asp:Label>
                 <br />
                 <asp:Label  ID="EndAuction1" runat="server" Text="" Font-Size="Large" Font-Bold="True" Font-Names="Arial" CssClass="text-success"></asp:Label>
                <br />
                <asp:Label  ID="EndAuction2" runat="server" Text="" Font-Size="Large" Font-Bold="True" Font-Names="Arial" CssClass="text-success"></asp:Label>

                <asp:Label  ID="EndAuction3" runat="server" Text="" Font-Size="Large" Font-Bold="True" Font-Names="Arial" CssClass="text-success"></asp:Label>
        </asp:Panel>
            </div>
        </div>

      
    </form>
</body>
</html>
