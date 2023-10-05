<%@ Page Title="" Language="C#" MasterPageFile="~/Orders/Orders.master" AutoEventWireup="true" CodeFile="bill.aspx.cs" Inherits="Orders_bill" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <meta charset="utf-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />

    <!-- Tell the browser to be responsive to screen width -->
    <meta content="width=device-width, initial-scale=1, maximum-scale=1, user-scalable=no" name="viewport" />

    <!-- v4.0.0 -->
    <link rel="stylesheet" href="../dist/bootstrap/css/bootstrap.min.css" media="screen, print"/>

    <!-- Favicon -->
    <link rel="icon" type="image/png" sizes="16x16" href="../dist/img/favicon-16x16.png" media="screen, print"/>

    <!-- Google Font -->
    <link href="https://fonts.googleapis.com/css?family=Poppins:300,400,500,600,700" rel="stylesheet" media="screen, print"/>

    <!-- Theme style -->
    <link rel="stylesheet" href="../dist/css/style.css" media="screen, print"/>
    <link rel="stylesheet" href="../dist/css/font-awesome/css/font-awesome.min.css" media="screen, print"/>
    <link rel="stylesheet" href="../dist/css/et-line-font/et-line-font.css" media="screen, print"/>
    <link rel="stylesheet" href="../dist/css/themify-icons/themify-icons.css" media="screen, print"/>
    <link rel="stylesheet" href="../dist/css/simple-lineicon/simple-line-icons.css" media="screen, print"/>
     <script type="text/javascript">
    window.setTimeout(function() {
    $(".alert").fadeTo(500, 0).slideUp(500, function(){
        $(this).remove(); 
    });
}, 4000);
</script>
     
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
 <%--   <style type="text/css" media="print">
    @page 
    {
        size: auto;   /* auto is the initial value */
        margin: 0mm;  /* this affects the margin in the printer settings */
    }
</style>--%>
    <style>
   @media print {
 
    @page { margin: 0; }
  }
    </style>
  <style>
      .table-bordered>thead>tr>th, .table-bordered>thead>tr>td {
	border-bottom-width: 2px;
    background-color:#2a6282 !important;
    color:white !important;

}
  
      </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="content-wrapper"> 
    <!-- Content Header (Page header) -->
    <section class="content-header sty-one">
      <h1>Order Details</h1>
      <ol class="breadcrumb">
        <li><a href="#">Orders</a></li>
        <li><i class="fa fa-angle-right"></i> Order Details</li>
      </ol>
    </section>
     <section  class="content">
         <asp:Panel ID="Panel3" runat="server">
              <div class="alert alert-success" role="alert">
  <button type="button" class="close" data-dismiss="alert" aria-label="Close"><span aria-hidden="true">&times;</span></button>
  <strong>Success!</strong> Order Invoice successfully updated!
</div>     
        </asp:Panel>
      <div class="card m-t-3">
      <div class="exportbtn">
          <button type="button" id="btn_sms" runat="server" onserverclick="btn_convert_Click" title="Convert to Sale Invoice"  class="btn btnsqr btn-primary8 btngap"> <i class="fa fa-exchange"></i> Convert</button>
      <button type="button" id="Button2" onclick="printdiv('dropHere');" title="Print" class="btn btnsqr btn-primary6"> <i class="fa fa-print"></i> Print</button>
  
      </div>
         <asp:Panel ID="Panel1" runat="server">
      <div id="dropHere" class="card"> 
         
      <div class="card-body">
          
          <!--  Place a single ASPXToPDF control in the page  -->
        
        <!-- Main content -->
        <section class="invoice"> 
          <!-- title row -->
          <div class="row">
              
            <div class="col-lg-12 m-b-3">
             
            </div>

            <!-- /.col --> 
          </div>
          <!-- info row -->
          <div class="row">
              <div class="col-sm-4 invoice-col"> 
            
                   <asp:Image ID="Image1" Height="70px" runat="server" />
          
            </div>
              <div class="col-sm-4 invoice-col"> 
            
                <h3><b>ORDER </b></h3> 
          
            </div>
               <div class="col-sm-4"> 
            
                 <h3><span class="pull-right"># <asp:Label ID="lbl_invoice_no"  runat="server" Text=""></asp:Label></span></h3> 
          
            </div>
            
          </div>
            <!-- /.col -->
            
             <div class="row">
                   <div class="col-sm-4 invoice-col"> 
                  
             <h4> <b> <asp:Label ID="lbl_company_name" runat="server" Text=""></asp:Label></b></h4>
            
              <asp:Label ID="lbl_company_address" runat="server" Text=""></asp:Label><br/>
              Phone: <asp:Label ID="lbl_company_contact" runat="server" Text=""></asp:Label><br/>
             GST no: <asp:Label ID="lbl_company_gst" runat="server" Text=""></asp:Label><br/>
              Email: <asp:Label ID="lbl_company_email" runat="server" Text=""></asp:Label>
              
            </div>

            <div class="col-sm-4 invoice-col"> To
              <address>
              <strong>
                    <asp:Label ID="lbl_customer_name" runat="server" Text=""></asp:Label></strong><br/>
              <asp:Label ID="lbl_customer_address" runat="server" Text=""></asp:Label><br/>
              Phone: <asp:Label ID="lbl_customer_contact" runat="server" Text=""></asp:Label><br/>
              <%--GST no: <asp:Label ID="lbl_gst_no" runat="server" Text=""></asp:Label><br/>--%>
             Email: <asp:Label ID="lbl_email" runat="server" Text=""></asp:Label>
              </address>
            </div>

               
            <!-- /.col -->
            <div class="col-sm-4 invoice-col text-right">
                 <div class="table-responsive" >
                <table class="table table-bordered">
                  <tbody>
                   
                      <tr>
                    <th style="width:50%">Designer</th>
                    <td><asp:Label ID="lbl_order_no" runat="server" Text=""></asp:Label></td>
                  </tr>
               
                  <tr>
                    <th>Order Date:</th>
                    <td><asp:Label ID="lbl_invoice_date" runat="server" Text=""></asp:Label></td>
                  </tr>
                  <tr>
                    <th>Due Date:</th>
                    <td><asp:Label ID="lbl_due_date" runat="server" Text=""></asp:Label></td>
                  </tr>
                 
                </tbody></table>
              </div>
                
                
               
            </div>  
             </div>
            <!-- /.col --> 
       
              
          <!-- /.row --> 
        
          <!-- Table row   table-striped-->
          <div class="table-responsive" >
            <div >
                <br/>
              <table  class="table table-bordered">
 <thead id="ths" runat="server">
    <tr id="tblpro">
      <th scope="col">Product</th>
    
      <th scope="col">Size</th>
      
      <th scope="col">Unit</th>
      <th scope="col">Qty</th>
      <th scope="col">Rate</th>
      <th scope="col">Total</th>
  
      <th scope="col">Status</th>
      
     
      <th scope="col">Amount</th>
    </tr>
  </thead>

  <tbody>
      <asp:Repeater ID="Repeater2" runat="server">
 <ItemTemplate>
    <tr>
      <td>
          <b><asp:Label ID="lbl_product" runat="server" Text='<%# Eval("s_product_name") %>'></asp:Label></b><br/>
           <asp:Label ID="Label1" runat="server" style="font-size: 12px;" Text='<%# Eval("s_desc") %>'></asp:Label> 
      </td>
      <%--<td><asp:Label ID="lbl_hsn" runat="server" Text='<%# Eval("s_product_hsn") %>'></asp:Label></td>--%>
        <td><asp:Label ID="lbl_height" runat="server" Text='<%# Eval("s_height") %>'></asp:Label> X <asp:Label ID="lbl_width" runat="server" Text='<%# Eval("s_width") %>'></asp:Label></td>
     
      
    <td><asp:Label ID="Label4" runat="server" Text='<%# Eval("s_unit") %>'></asp:Label></td>
          <td><asp:Label ID="lbl_qty" runat="server" Text='<%# Eval("s_quantity") %>'></asp:Label></td>
       
      <td><asp:Label ID="lbl_rate" runat="server" Text='<%# Eval("s_rate") %>'></asp:Label></td>
      <td><asp:Label ID="lbl_stotal" runat="server" Text='<%# Eval("s_stotal") %>'></asp:Label></td>
<%--      <td><asp:Label ID="lbl_cgst" runat="server" Text='<%# Eval("s_cgstp") %>'></asp:Label></td>

      <td><asp:Label ID="lbl_sgst" runat="server" Text='<%# Eval("s_sgstp") %>'></asp:Label></td>--%>
      <td><asp:Label ID="lbl_igst" runat="server" Text='<%# Eval("s_status") %>'></asp:Label></td>

    <td><asp:Label ID="lbl_amount" runat="server" Text='<%# Eval("s_amount") %>'></asp:Label></td>
    </tr>
       </ItemTemplate>

          </asp:Repeater>
  </tbody>

</table>
            </div>
            <!-- /.col --> 
          </div>
          <!-- /.row -->
          <br/>
          <div class="row"> 
            <!-- accepted payments column -->
              <div class="col-lg-6 col-md-6">
              <p class="lead" style="font-size:16px">Note :</p>
             
              <p class="text-muted well well-sm no-shadow" style="font-size: 13px;">1. Subject to our home Jurisdiction.<br>2. Our Responsibility Ceases as soon as goods leaves our Premises.<br>3. Goods once sold will not taken back.<br>4. Delivery Ex-Premises.</p>
           <asp:HiddenField ID="lbl_opening_balance" runat="server" />
                <hr/>
                <p class="lead" style="font-size:16px">Bank Details :</p>
                <p class="text-muted" style="font-size: 13px;"><b>Bank Name : </b>&nbsp&nbsp<asp:Label ID="lbl_bank_name" runat="server" Text=""></asp:Label></p>
                 <p class="text-muted" style="font-size: 13px;"><b>Branch : </b>&nbsp&nbsp<asp:Label ID="lbl_branch" runat="server" Text=""></asp:Label></p>
                 <p class="text-muted" style="font-size: 13px;"><b>Bank A/C No : </b>&nbsp&nbsp<asp:Label ID="lbl_ac" runat="server" Text=""></asp:Label></p>
                 <p class="text-muted" style="font-size: 13px;"><b>Bank Branch IFSC : </b>&nbsp&nbsp<asp:Label ID="lbl_ifsc" runat="server" Text=""></asp:Label></p>
                 </div>
            <!-- /.col -->
            <div class="col-lg-6 col-md-6 text-right">
              
              <div class="table-responsive">
                  <table class="table table-bordered">
                  <tbody>
                      
                      <tr>
                    <th >Subtotal:</th>
                    <td style="width:20%">₹ <asp:Label ID="lbl_subtotal" runat="server" Text=""></asp:Label></td>

                           <th >Design Charges:</th>
                    <td>₹ <asp:Label ID="lbl_design" runat="server" Text=""></asp:Label></td>
                  </tr>
                

                    
                  <tr>
                    <th  >Transport:</th>
                    <td style="width:20%">₹ <asp:Label ID="lbl_shipping" runat="server" Text=""></asp:Label></td>
                  <th>Fitting / Framing Charges :</th>
                    <td style="width:20%">₹ <asp:Label ID="lbl_fitting_framing" runat="server" Text=""></asp:Label></td>
                        </tr>
                           

                  <tr class="no-print">
                    <th>Advance:</th>
                    <td style="width:20%">₹ <asp:Label ID="lbl_adjustment" runat="server" Text=""></asp:Label></td>
                       <th>Discount:</th>
                    <td style="width:20%">₹ <asp:Label ID="lbl_discount" runat="server" Text=""></asp:Label></td>
                        </tr>
             
                           <tr>
                                <th>Total:</th>
                    <td style="width:20%">₹ <asp:Label ID="lbl_total" runat="server" Text=""></asp:Label></td>
                    <th>Balance:</th>
                    <td style="width:20%">₹ <asp:Label ID="lbl_balance" runat="server" Text=""></asp:Label></td>
                    
                  </tr>
                      <tr>
                          <th>Payment Method:</th>
                    <td ><asp:Label ID="lbl_payment_method" runat="server" Text=""></asp:Label></td>
                      </tr>
                 
                </tbody></table>
                  
                   
              </div>
            </div>
              
              <div class="col-md-12"><div style="border-top: 1px solid rgba(0,0,0,.1);border-bottom: 1px solid rgba(0,0,0,.1);padding: 5px;">
                  <span style="margin-left:10px;"><b> In Words : </b><asp:Label ID="lbl_word" runat="server" Text=""></asp:Label> RUPEES ONLY</span>
             </div></div>
              
              <div class="col-md-12 m-t-6">
                     <div class="row">
                     
                       
                       <div class="col-md-2" style="border-bottom:1px solid rgba(0,0,0,.2);margin-bottom: 54px;"></div>
                        

                       <div class="col-md-2">Customer Sign</div>



                        <div class="offset-md-4 col-md-4">
                                 <div class="col-md-4" style="border-bottom:1px solid rgba(0,0,0,.2);"></div>
                         <br />
                                        <h5 style="margin-left:40px;">(Ajit Arts)</h5>
                                    <h5>Authorised Signatory</h5>
                           </div>

                       
                   </div>
                  </div>
            <!-- /.col --> 
          </div>
          <!-- /.row --> 
      
        </section>
           <!-- this row will not appear when printing -->
         
        <!-- /.content --> 
      </div></div>
            </asp:Panel> 
             </div>
    </section>
        </div>

  
</asp:Content>

