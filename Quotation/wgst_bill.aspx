<%@ Page Title="" Language="C#" MasterPageFile="~/Quotation/Quotation.master" AutoEventWireup="true" CodeFile="wgst_bill.aspx.cs" Inherits="Quotation_wgst_bill" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
  
     
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
      <h1>GST Quotation Details</h1>
      <ol class="breadcrumb">
        <li><a href="#">Quotation</a></li>
        <li><i class="fa fa-angle-right"></i> GST Quotation Details</li>
      </ol>
    </section>
     <section  class="content">
      <div class="card">
      <div class="exportbtn">
        <button type="button" id="Button1" onclick="printdiv('dropHere');" title="Print Format-1" class="btn btnsqr btn-primary6 btngap"> <i class="fa fa-print"></i> Print Format-1</button>
        <button type="button" id="btn_print" runat="server" onserverclick="print" title="Print Format-2" class="btn btnsqr btn-primary"> <i class="fa fa-print"></i> Print Format-2</button>
        <%-- <button type="button" id="btn_pdf" title="Export PDF" class="btn btnsqr btn-primary2"> <i class="fa fa-file-pdf-o"></i> PDF</button>--%>
         
        
      </div>
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
            
                   <asp:Image ID="Image1" Height="70px" width="170px" runat="server" /><br/>
          
            </div>
              <div class="col-sm-4 invoice-col"> 
            
                  
          
            </div>
              <div class="col-sm-4 invoice-col"> 
            
                  <h3><b>QUOTATION </b> <span class="pull-right"># <asp:Label ID="lbl_invoice_no"  runat="server" Text=""></asp:Label></span></h3> 
          
            </div>
          
          </div>
            <!-- /.col -->
           
             <div class="row">
                   <div class="col-sm-4 invoice-col"> 
                  
             <h4> <strong> <asp:Label ID="lbl_company_name" runat="server" Text=""></asp:Label></strong></h4>
            
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
              GST no: <asp:Label ID="lbl_gst_no" runat="server" Text=""></asp:Label>
              </address>
            </div>
            <!-- /.col -->
            <div class="col-sm-4 invoice-col text-right">
                 <div class="table-responsive">
                <table class="table table-bordered">
                  <tbody>
                 
                  <tr>
                    <th>Quotation Date:</th>
                    <td><asp:Label ID="lbl_invoice_date" runat="server" Text=""></asp:Label></td>
                  </tr>
                  <tr>
                    <th>Valid Date:</th>
                    <td><asp:Label ID="lbl_due_date" runat="server" Text=""></asp:Label></td>
                  </tr>
                 
                </tbody></table>
              </div>
                
                
               
            </div>  
             </div>
            <!-- /.col --> 
       
              
          <!-- /.row --> 
        
          <!-- Table row   table-striped-->
          <div class="table-responsive">
            <div>
                <br/>
              <table class="table table-bordered">
  <thead style="background-color:White; color:black;">
    <tr>
      <th scope="col">Product</th>
      <th scope="col">HSN</th>
      <th scope="col">Size</th>
    
      <th scope="col">Unit</th>
      <th scope="col">Qty</th>
      
      <th scope="col">Rate</th>
      <th scope="col">Total</th>
     
    </tr>
  </thead>

  <tbody>
      <asp:Repeater ID="Repeater2" runat="server">
 <ItemTemplate>
    <tr>
      <td>
          <asp:Label ID="lbl_product" runat="server" Text='<%# Eval("qw_product_name") %>'></asp:Label><br /><asp:Label ID="Label1" runat="server" Text='<%# Eval("qw_desc") %>'></asp:Label></td>
      <td><asp:Label ID="lbl_hsn" runat="server" Text='<%# Eval("qw_hsn") %>'></asp:Label></td>
        <td><asp:Label ID="Label2" runat="server" Text='<%# Eval("qw_height") %>'></asp:Label> X <asp:Label ID="Label3" runat="server" Text='<%# Eval("qw_width") %>'></asp:Label></td>
      
    <td><asp:Label ID="Label4" runat="server" Text='<%# Eval("qw_unit") %>'></asp:Label></td>
          <td><asp:Label ID="lbl_qty" runat="server" Text='<%# Eval("qw_quantity") %>'></asp:Label></td>
       
      <td><asp:Label ID="lbl_rate" runat="server" Text='<%# Eval("qw_rate") %>'></asp:Label></td>
      <td><asp:Label ID="lbl_stotal" runat="server" Text='<%# Eval("qw_stotal") %>'></asp:Label></td>
      
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
                <br/>
                </div>
            <!-- /.col -->

              <div class="col-lg-6 col-md-6 text-right">
              
              <div class="table-responsive">
                <table class="table table-bordered" style=" border: 1px solid #000 !important;">
                  <tbody>
                      
                      <tr>
                    <th style=" border: 1px solid #000 !important;" >Subtotal:</th>
                    <td style="width:20%;border: 1px solid #000 !important; ">₹ <asp:Label ID="lbl_subtotal" runat="server" Text=""></asp:Label></td>
                        <th style=" border: 1px solid #000 !important;" >Transport:</th>
                    <td style="width:20%; border: 1px solid #000 !important;">₹ <asp:Label ID="lbl_shipping" runat="server" Text=""></asp:Label></td>
                          
                  </tr>
                

                      <asp:Panel ID="Panel4" runat="server">
                  
                          <tr style=" border: 1px solid #000 !important;">
                   
                       <th style=" border: 1px solid #000 !important;" >Design Charges:</th>
                    <td style=" border: 1px solid #000 !important;">₹ <asp:Label ID="lbl_design" runat="server" Text=""></asp:Label></td>
                  
                   <th style=" border: 1px solid #000 !important;">Pasting / Framing Charges:</th>
                    <td style="width:20%;border: 1px solid #000 !important;">₹ <asp:Label ID="lbl_pasting" runat="server" Text=""></asp:Label></td>
                        
                  </tr>
                           </asp:Panel>

                          <tr>

                      <asp:Panel ID="Panel5" runat="server">

                 <th style=" border: 1px solid #000 !important;">Fitting / Intallation Charges:</th>
                    <td style="width:20%;border: 1px solid #000 !important;">₹ <asp:Label ID="lbl_fitting" runat="server" Text=""></asp:Label></td>

                               </asp:Panel>
                      <th style=" border: 1px solid #000 !important;">Discount:</th>
                    <td style="width:20% ;border: 1px solid #000 !important;">₹ <asp:Label ID="lbl_discount" runat="server" Text=""></asp:Label></td>
                       
                      </tr>
                 
                     <%--  <tr class="no-print">
                    <th style=" border: 1px solid #000 !important;">Advance:</th>
                    <td style="width:20% ;border: 1px solid #000 !important;">₹ <asp:Label ID="lbl_adjustment" runat="server" Text=""></asp:Label></td>
                      
                           <th style=" border: 1px solid #000 !important;">Payment Method:</th>
                    <td style=" border: 1px solid #000 !important;">₹ <asp:Label ID="lbl_payment_method" runat="server" Text=""></asp:Label></td>
                       </tr>--%>
             
                           <tr>
                                <th style="border: 1px solid #000 !important;">Total:</th>
                    <td style="width:20% ;border: 1px solid #000 !important;">₹ <asp:Label ID="lbl_total" runat="server" Text=""></asp:Label></td>
                    <th style=" border: 1px solid #000 !important;">Balance:</th>
                    <td style="width:20% ;border: 1px solid #000 !important;">₹ <asp:Label ID="lbl_balance" runat="server" Text=""></asp:Label></td>
                    
                  </tr>

                 
                </tbody></table>

              </div>
            </div>

              <div class="col-md-12"><div style="border-top: 1px solid rgba(0,0,0,.1);border-bottom: 1px solid rgba(0,0,0,.1);padding: 5px;">
                  <span style="margin-left:10px;"><b> In Words : </b><asp:Label ID="lbl_word" runat="server" Text=""></asp:Label> RUPEES ONLY</span>
             </div></div>
              
              <div class="col-md-12 m-t-6">
                   <div class="row">
                       <div class="col-md-7"></div>
                       <div class="col-md-3" style="border-bottom:1px solid rgba(0,0,0,.2);"></div>
                       <div class="col-md-2">Provider Sign</div>
                       
                   </div>
                  </div>
            <!-- /.col --> 
          </div>
          <!-- /.row --> 
          <br/>
          
        </section>
           <!-- this row will not appear when printing -->
         
        <!-- /.content --> 
      </div></div></div>
    </section>
        </div>

     <script type="text/javascript">
function ShowModel() {

            $('#myModal').modal('show');
        }
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
</asp:Content>

