<%@ Page Title="" Language="C#" MasterPageFile="~/Purchase/Purchase.master" AutoEventWireup="true" CodeFile="bill.aspx.cs" Inherits="admin_panel_Purchase_bill" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    
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
      <h1>Invoice Details</h1>
      <ol class="breadcrumb">
        <li><a href="#">Purchase</a></li>
        <li><i class="fa fa-angle-right"></i> Invoice Details</li>
      </ol>
    </section>
     <section  class="content">
         <asp:Panel ID="Panel3" runat="server">
              <div class="alert alert-success" role="alert">
  <button type="button" class="close" data-dismiss="alert" aria-label="Close"><span aria-hidden="true">&times;</span></button>
  <strong>Success!</strong> Purchase Invoice successfully updated!
</div>     
        </asp:Panel>
      <div class="card">
      <div class="exportbtn">
          <button type="button" id="btn_payment" title="Make Payment" runat="server" onserverclick="payment" class="btn btnsqr btn-primary7 btngap"> <i class="fa fa-dollar"></i> Payment</button>
         <button type="button" id="Button1" onclick="printdiv('dropHere');" title="Print Format-1" class="btn btnsqr btn-primary6 btngap"> <i class="fa fa-print"></i> Print Format-1</button>
       <button type="button" id="btn_print" runat="server" onserverclick="print" title="Print Format-2" class="btn btnsqr btn-primary"> <i class="fa fa-print"></i> Print Format-2</button>
         <%--<button type="button" id="btn_pdf" runat="server"  title="Export PDF" class="btn btnsqr btn-primary2"> <i class="fa fa-file-pdf-o"></i> PDF</button>--%>
        
      </div>
      <div id="dropHere" class="card"> 
      <div class="card-body">
        <!-- Main content -->
        <section class="invoice"> 
          <!-- title row -->
           <div class="row">
              
            <div class="col-lg-12 m-b-3">
                
              <h3 class="text-black"> <asp:Label CssClass="pay_status" Style="margin-left:10px;" ID="lbl_status" runat="server" Text=""></asp:Label>
                 </h3>
            </div>

            <!-- /.col --> 
          </div>
          <!-- info row -->
          <div class="row">
              <div class="col-sm-4 invoice-col"> 
            
                   <asp:Image ID="Image1" Height="70px" width="170px" runat="server" />
          
            </div>
              <div class="col-sm-4 invoice-col"> 
            
                  
          
            </div>
               <div class="col-sm-4"> 
            
                 <h3><b>TAX INVOICE </b> <span class="pull-right"># <asp:Label ID="lbl_invoice_no"  runat="server" Text=""></asp:Label></span></h3> 
          
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
              GST no: <asp:Label ID="lbl_gst_no" runat="server" Text=""></asp:Label><br/>
             Email: <asp:Label ID="lbl_email" runat="server" Text=""></asp:Label>
              </address>
            </div>

               
            <!-- /.col -->
            <div class="col-sm-4 invoice-col text-right">
                 <div class="table-responsive" >
                <table class="table table-bordered">
                  <tbody>
                   <tr>
                    <th style="width:50%">Due Amount</th>
                    <td><asp:Label ID="lbl_balance" runat="server" Text=""></asp:Label></td>
                  </tr>
                      <tr>
                    <th style="width:50%">Order #</th>
                    <td><asp:Label ID="lbl_order_no" runat="server" Text=""></asp:Label></td>
                  </tr>
               
                  <tr>
                    <th>Invoice Date:</th>
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
          <div class="table-responsive">
            <div>
                <br/>
              <table class="table table-bordered">
   <thead style="background-color:white; color:black;">
    <tr>
      <th scope="col">Product</th>
      <th scope="col">HSN</th>
      <th scope="col">Size</th>
     
      <th scope="col">Unit</th>
      <th scope="col">Qty</th>
      
      <th scope="col">Rate</th>
      <th scope="col">STotal</th>
      <th scope="col">CGST</th>
      
      <th scope="col">SGST</th>
      <th scope="col">IGST</th>
      
     
      <th scope="col">Amount</th>
    </tr>
  </thead>

  <tbody>
      <asp:Repeater ID="Repeater2" runat="server">
 <ItemTemplate>
    <tr>
      <td>
          <asp:Label ID="lbl_product" runat="server" Text='<%# Eval("pc_product_name") %>'></asp:Label></td>
      <td><asp:Label ID="lbl_hsn" runat="server" Text='<%# Eval("pc_product_hsn") %>'></asp:Label></td>
        <td><asp:Label ID="lbl_igst" runat="server" Text='<%# Eval("pc_height") %>'></asp:Label> X <asp:Label ID="Label2" runat="server" Text='<%# Eval("pc_width") %>'></asp:Label></td>
    
    <td><asp:Label ID="Label4" runat="server" Text='<%# Eval("pc_unit") %>'></asp:Label></td>
          <td><asp:Label ID="lbl_qty" runat="server" Text='<%# Eval("pc_quantity") %>'></asp:Label></td>
       
      <td><asp:Label ID="lbl_rate" runat="server" Text='<%# Eval("pc_rate") %>'></asp:Label></td>
      <td><asp:Label ID="lbl_stotal" runat="server" Text='<%# Eval("pc_stotal") %>'></asp:Label></td>
      <td><asp:Label ID="lbl_cgst" runat="server" Text='<%# Eval("pc_cgsta") %>'></asp:Label></td>

      <td><asp:Label ID="lbl_sgst" runat="server" Text='<%# Eval("pc_sgsta") %>'></asp:Label></td>
        <td><asp:Label ID="Label3" runat="server" Text='<%# Eval("pc_igsta") %>'></asp:Label></td>
      

    <td><asp:Label ID="lbl_amount" runat="server" Text='<%# Eval("pc_amount") %>'></asp:Label></td>
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
             
             <asp:Label ID="lbl_note" runat="server" Text=""></asp:Label>
           <asp:HiddenField ID="lbl_opening_balance" runat="server" />
                 </div>
            <!-- /.col -->
            <div class="col-lg-6 col-md-6 text-right">
              
              <div class="table-responsive">
                <table class="table table-bordered">
                  <tbody><tr>
                    <th style="width:50%">Subtotal:</th>
                    <td>₹ <asp:Label ID="lbl_subtotal" runat="server" Text=""></asp:Label></td>
                  </tr>
                  <tr>
                    <th>Total GST</th>
                    <td>₹ <asp:Label ID="lbl_total_gst" runat="server" Text=""></asp:Label></td>
                  </tr>
                  <tr>
                    <th>Shipping:</th>
                    <td>₹ <asp:Label ID="lbl_shipping" runat="server" Text=""></asp:Label></td>
                  </tr>
                  <tr>
                    <th>Advance:</th>
                    <td>₹ <asp:Label ID="lbl_adjustment" runat="server" Text=""></asp:Label></td>
                  </tr>
                  <tr>
                    <th>Discount:</th>
                    <td>₹ <asp:Label ID="lbl_discount" runat="server" Text=""></asp:Label></td>
                  </tr>
                  <tr>
                    <th>Total:</th>
                    <td>₹ <asp:Label ID="lbl_total" runat="server" Text=""></asp:Label></td>
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
    window.setTimeout(function() {
    $(".alert").fadeTo(500, 0).slideUp(500, function(){
        $(this).remove(); 
    });
}, 4000);
</script>
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
</asp:Content>

