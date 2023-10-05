<%@ Page Language="C#" AutoEventWireup="true" CodeFile="bill5.aspx.cs" Inherits="Sale_bill5" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
     <script type="text/javascript">
function printdiv(dropHere)
{
    var printContents = document.getElementById(dropHere).innerHTML;
    var originalContents = document.body.innerHTML;

    document.body.innerHTML = printContents;

    window.print();

    document.body.innerHTML = originalContents;
}
</script>
    <script>
        function Closepopup() {
            $('#myModal').modal('close');
           
        }
    </script>
       <meta charset="UTF-8">

    <title></title>
    <style>
     #invoice-POS {
    box-shadow: 0 0 1in -0.25in rgba(0, 0, 0, 0.5);
    padding: 5mm;
    margin: 0 auto;
    width: 70mm;
    background: #FFF;
}

     span{
         font-size:14px;
     }
     th{
             font-weight: 100 !important;
     }

            #invoice-POS ::selection {
                background: #f31544;
                color: #FFF;
            }

            #invoice-POS ::moz-selection {
                background: #f31544;
                color: #FFF;
            }

            #invoice-POS h1 {
                font-size: 1.5em;
                color: #222;
            }

            #invoice-POS h2 {
                /*font-size: .9em;*/
            }

            #invoice-POS h3 {
                font-size: 1.2em;
                font-weight: 300;
                line-height: 2em;
            }

            #invoice-POS p {
                font-size: 10px;
                /*color: #666;*/
                line-height: 17px;
            }

            #invoice-POS #top, #invoice-POS #mid, #invoice-POS #bot {
                /* Targets all id with 'col-' */
                border-bottom: 1px solid #EEE;
            }

            #invoice-POS #top {
                /*min-height: 100px;*/
            }

            #invoice-POS #mid {
                min-height: 80px;
            }

            #invoice-POS #bot {
                min-height: 50px;
            }

            #invoice-POS #top .logo {
                height: 60px;
                width: 60px;
                background: url(../dist/img/logoclient.jpg) no-repeat;
                background-size: 60px 60px;
            }

            #invoice-POS .clientlogo {
                float: left;
                height: 60px;
                width: 60px;
                background: url(../dist/img/logoclient.jpg) no-repeat;
                background-size: 60px 60px;
                border-radius: 50px;
            }
        #invoice-POS .info {
            display: block;
            margin-left: 0;
        }

            #invoice-POS .title {
                float: right;
            }

                #invoice-POS .title p {
                    text-align: right;
                }

            #invoice-POS table {
                width: 100%;
                border-collapse: collapse;
            }

            #invoice-POS .tabletitle {
                font-size: .5em;
                background: #EEE;
            }

            #invoice-POS .service {
                border-bottom: 1px solid #EEE;
            }

            #invoice-POS .item {
                width: 24mm;
            }

            #invoice-POS .itemtext {
                font-size: .5em;
            }

            #invoice-POS #legalcopy {
                margin-top: 5mm;
            }
    </style>
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/paper-css/0.3.0/paper.css" />
    <style>
        @page {
            /*size: 8.5in 11in;*/
        }

        .m-t-cust-7 {
            /*margin-top: 30px !important;*/
        }

        body {
            font-size: 17px !important;
            /*line-height: 8px !important;*/
        }

        table {
            line-height: 8px !important;
        }
    </style>
</head>

<body>
    <form id="form1" runat="server">
     <button type="button" id="Button2" onclick="printdiv('dropHere');" title="Print Format-1" class="btn btnsqr btn-primary6 btngap"> <i class="fa fa-print"></i> Print</button>
    <div id="dropHere">
        <div id="invoice-POS">
            <center id="top">
                 <%--<div class="logo"></div>--%>
                <h2><asp:Label ID="lbl_company_name2" runat="server" Text=""></asp:Label></h2>
                <div class="info">
                    <%--<h2><asp:Label ID="lbl_company_name" runat="server" Text="Label"></asp:Label></h2>--%>
                 <asp:Label ID="lbl_company_address" runat="server" Text="Label"></asp:Label>
                    <asp:Label ID="Label11" runat="server" Text="Phone :- "></asp:Label><asp:Label ID="lbl_company_contact" runat="server" Text=""></asp:Label><br />

                    <asp:Label ID="lbl_gst" runat="server" Text="GST No."></asp:Label><asp:Label ID="lbl_company_gst" runat="server" Text=""></asp:Label> <br />

                  <asp:Label ID="Label12" runat="server" Text="Invoice No:- "></asp:Label>  <asp:Label ID="lbl_invoice_no" runat="server" Text=""></asp:Label> 
                    <asp:Label ID="Label13" runat="server" Text="Date :- "></asp:Label><asp:Label ID="lbl_invoice_date" runat="server" Text="Label"></asp:Label>
                </div>
            </center>
            <div id="mid">
                <div class="info">
                  
                    <p>
                        <asp:Label ID="Label7" runat="server" Text="Customer Name:-"></asp:Label> <asp:Label ID="lbl_customer_name" runat="server" Text=""></asp:Label><br />
                        <asp:Label ID="Label8" runat="server" Text="Address :"></asp:Label><asp:Label ID="lbl_customer_address" runat="server" Text=""></asp:Label></br>
                       <asp:Label ID="Label9" runat="server" Text=" Email :"></asp:Label><asp:Label ID="lbl_email" runat="server" Text=""></asp:Label></br>
                       <asp:Label ID="Label10" runat="server" Text=" Phone :"></asp:Label> <asp:Label ID="lbl_customer_contact" runat="server" Text=""></asp:Label></br>
                    </p>
                </div>
            </div>
            <div id="bot">
                <div id="table">
                 <table class="table table-bordered" id="table">
  <thead style="background-color:White; color:black;">
    <tr  class="tabletitle">
      <th scope="col">
          <asp:Label ID="lbl_product" runat="server" Text="Product"></asp:Label></th>
     
      <th scope="col">
          <asp:Label ID="lbl_size" runat="server" Text="Size"></asp:Label></th>
   
     
      <th scope="col">
          <asp:Label ID="lbl_qnty" runat="server" Text="Qty"></asp:Label></th>
      
      <th scope="col">
          <asp:Label ID="lbl_rate" runat="server" Text="Rate"></asp:Label></th>
      <th scope="col">
          <asp:Label ID="lbl_total_amt" runat="server" Text="Total"></asp:Label></th>
     
    </tr>
  </thead>

  <tbody>
      <asp:Repeater ID="Repeater2" runat="server">
 <ItemTemplate>
    <tr class="service">
      <td style="padding:6px">
          <asp:Label ID="lbl_product" runat="server" Text='<%# Eval("s_product_name") %>'></asp:Label></td>
    
        <td style="padding:6px"><asp:Label ID="lbl_height" runat="server" Text='<%# Eval("s_height") %>'></asp:Label> <asp:Label ID="Label1" runat="server" Text="x"></asp:Label> <asp:Label ID="lbl_width" runat="server" Text='<%# Eval("s_width") %>'></asp:Label></td>
     
   
          <td style="padding:6px"><asp:Label ID="lbl_qty" runat="server" Text='<%# Eval("s_quantity") %>'></asp:Label></td>
       
      <td style="padding:6px"><asp:Label ID="lbl_rate" runat="server" Text='<%# Eval("s_rate") %>'></asp:Label></td>
      <td style="padding:6px"><asp:Label ID="lbl_stotal" runat="server" Text='<%# Eval("s_stotal") %>'></asp:Label></td>
      
    </tr>
       </ItemTemplate>

          </asp:Repeater>
  </tbody>

</table>
      <div class="row"> 
            <!-- accepted payments column -->
       
        <br />
            <!-- /.col -->
             
            <div class=" col-lg-6 col-md-6 " style="margin-left:120px !important;">
              
              <div class="table-responsive">
                <table class="table table-bordered">
                  <tbody><tr>
                    <th style="width:50%; padding:5px;">
                        <asp:Label ID="Label3" runat="server" Text="Subtotal :"></asp:Label></th>
                    <td> <asp:Label ID="lbl_subtotal" runat="server" Text=""></asp:Label></td>
                  </tr>
          
                  <tr>
                    <th style="padding:5px;">
                        <asp:Label ID="Label2" runat="server" Text="Advance :"></asp:Label></th>
                    <td> <asp:Label ID="lbl_adjustment" runat="server" Text=""></asp:Label></td>
                  </tr>
                  <tr>
                    <th style="padding:5px;">
                        <asp:Label ID="Label4" runat="server" Text="Discount :"></asp:Label></th>
                    <td> <asp:Label ID="lbl_discount" runat="server" Text=""></asp:Label></td>
                  </tr>
                           <tr>
                    <th style="padding:5px;">
                        <asp:Label ID="Label5" runat="server" Text="Balance :"></asp:Label></th>
                    <td><asp:Label ID="lbl_balance" runat="server" Text=""></asp:Label></td>
                    
                  </tr>
                  <tr>
                    <th style="padding:5px;">
                        <asp:Label ID="Label6" runat="server" Text="Total :"></asp:Label></th>
                    <td> <asp:Label ID="lbl_total" runat="server" Text=""></asp:Label></td>
                  </tr>
                </tbody></table>
              </div>
            </div>
                  <div class="col-md-12 m-t-6">
                   <div class="row">
                       <div class="col-md-7"></div>
                       <div class="col-md-3"></div>
                       <div class="col-md-2">Provider Sign</div>
                       
                   </div>
                  </div>
      
            <!-- /.col --> 
          </div>
          <!-- /.row --> 


                </div>
                <div id="legalcopy"  style="border-bottom:1px solid rgba(0,0,0,.2);">
                  Thank You ! Please come again soon..
                </div>
            </div>
        </div>
    </div>
    </form>
</body>
</html>
