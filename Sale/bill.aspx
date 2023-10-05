<%@ Page Title="" Language="C#" MasterPageFile="~/Sale/Sale.master" AutoEventWireup="true" CodeFile="bill.aspx.cs" Inherits="admin_panel_Sale_bill" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style>
        table td{
            border: 0.1em solid #dedcdc !important;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="content-wrapper"> 
    <!-- Content Header (Page header) -->
    <section class="content-header sty-one">
      <h1>Invoice Details</h1>
      <ol class="breadcrumb">
        <li><a href="#">Sale</a></li>
        <li><i class="fa fa-angle-right"></i> Invoice Details</li>
      </ol>
    </section>
     <section  class="content">
         <asp:Panel ID="Panel3" runat="server">
              <div class="alert alert-success" role="alert">
  <button type="button" class="close" data-dismiss="alert" aria-label="Close"><span aria-hidden="true">&times;</span></button>
  <strong>Success!</strong> Sale Invoice successfully updated!
</div>     
        </asp:Panel>
      <div class="card m-t-3">
      <div class="exportbtn">
          <button type="button" id="Button3" title="Job Estimation Sheet" runat="server" onserverclick="sheet" class="btn btnsqr btn-primary2 btngap"> <i class="fa fa-clipboard"></i> Job Est Sheet</button>
     <button type="button" id="btn_payment" title="Make Payment" runat="server" onserverclick="payment" class="btn btnsqr btn-primary7 btngap"> <i class="fa fa-dollar"></i> Payment</button>
           <button type="button" id="Button1" title="Add Image" data-toggle="modal" data-target="#myModal" runat="server" class="btn btnsqr btn-primary8 btngap"> <i class="fa fa-paperclip"></i> Add Image</button>
           <%--<button type="button" id="btn_mail" runat="server" onserverclick="btn_mail_Click" title="Mail for Payment Reminder"   class="btn btnsqr btn-primary4 btngap"> <i class="fa fa-envelope"></i> Mail</button>--%>
           
          <button type="button" id="btn_sms" runat="server" onserverclick="btn_sms_Click" title="SMS for Payment Reminder"  class="btn btnsqr btn-primary3 btngap"> <i class="fa fa-envelope"></i> SMS</button>
           <button type="button" id="Button2" onclick="printdiv('dropHere');" title="Print" class="btn btnsqr btn-primary6 btngap"> <i class="fa fa-print"></i> Print</button>
         <button type="button" id="btn_print2" runat="server" title="Print Format-2" onserverclick="print2" class="btn btnsqr btn-primary"> <i class="fa fa-print"></i> Format-1</button>
         <button type="button" id="btn_print3" runat="server" title="Print Format-3" onserverclick="print3" class="btn btnsqr btn-success"> <i class="fa fa-print"></i> Format-3</button>
           <button type="button" id="btn_print4" runat="server" title="Print Format-4" onserverclick="print4" class="btn btnsqr btn-primary4"> <i class="fa fa-print"></i> Format-2</button>
        
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
                
              <h3 class="text-black"> <asp:Label CssClass="pay_status" Style="margin-left:10px; background-color: #0e0e0e !important; font-weight:bold;" ID="lbl_status" runat="server" Text=""></asp:Label>
                 </h3>
            </div>

            <!-- /.col --> 
          </div>
          <!-- info row -->
          <div class="row">
              <div class="col-sm-4 invoice-col"> 
            
                   <asp:Image ID="Image1" Height="90px" width="120px" runat="server" />
          
            </div>
              <div class="col-sm-4 invoice-col"> 
            
             <h3>    <b class="text-center" style="text-align: center;">TAX INVOICE </b> </h3>
          
            </div>
               <div class="col-sm-4"> 
            
                 <h3 > <span class="pull-right"># <asp:Label ID="lbl_invoice_no"  runat="server" Text=""></asp:Label></span></h3> 
          
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
                    <th style="width:50%;border: 1px solid #000 !important;">Order #</th>
                    <td style=" border: 1px solid #000 !important;"><asp:Label ID="lbl_order_no" runat="server" Text=""></asp:Label></td>
                  </tr>
                <tr>
                    <th style="width:50%;border: 1px solid #000 !important;">Designer</th>
                    <td style=" border: 1px solid #000 !important;"><asp:Label ID="lbl_ref_no" runat="server" Text=""></asp:Label></td>
                  </tr>
                  <tr>
                    <th style=" border: 1px solid #000 !important;">Invoice Date:</th>
                    <td style=" border: 1px solid #000 !important;"><asp:Label ID="lbl_invoice_date" runat="server" Text=""></asp:Label></td>
                  </tr>
                  <tr>
                    <th style=" border: 1px solid #000 !important;">Due Date:</th>
                    <td style=" border: 1px solid #000 !important;"><asp:Label ID="lbl_due_date" runat="server" Text=""></asp:Label></td>
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
      <th scope="col" style=" border: 1px solid #000 !important;">Product</th>
      <th scope="col" style=" border: 1px solid #000 !important;">HSN</th>
      <th scope="col" style=" border: 1px solid #000 !important;">Size</th>
      
      <th scope="col" style=" border: 1px solid #000 !important;">Unit</th>
      <th scope="col" style=" border: 1px solid #000 !important;">Qty</th>
      <th scope="col" style=" border: 1px solid #000 !important;">Rate</th>
      <th scope="col" style=" border: 1px solid #000 !important;">Total</th>
      <th scope="col" style=" border: 1px solid #000 !important;">CGST</th>
      <th scope="col" style=" border: 1px solid #000 !important;">SGST</th>
      <th scope="col" style=" border: 1px solid #000 !important;">IGST</th>
      
     
      <th scope="col"style=" border: 1px solid #000 !important;">Amount</th>
    </tr>
  </thead>

  <tbody>
      <asp:Repeater ID="Repeater2" runat="server">
 <ItemTemplate>
    <tr>
      <td style=" border: 1px solid #000 !important;">
          <b><asp:Label ID="lbl_product" runat="server" Text='<%# Eval("s_product_name") %>'></asp:Label></b><br/>
           <asp:Label ID="Label1" runat="server" style="font-size: 12px;" Text='<%# Eval("s_desc") %>'></asp:Label> 
      </td>
      <td style=" border: 1px solid #000 !important;"><asp:Label ID="lbl_hsn" runat="server" Text='<%# Eval("s_product_hsn") %>'></asp:Label></td>
        <td style=" border: 1px solid #000 !important;"><asp:Label ID="lbl_height" runat="server" Text='<%# Eval("s_height") %>'></asp:Label> X <asp:Label ID="lbl_width" runat="server" Text='<%# Eval("s_width") %>'></asp:Label></td>
     
      
    <td style=" border: 1px solid #000 !important;"><asp:Label ID="Label4" runat="server" Text='<%# Eval("s_unit") %>'></asp:Label></td>
          <td style=" border: 1px solid #000 !important;"><asp:Label ID="lbl_qty" runat="server" Text='<%# Eval("s_quantity") %>'></asp:Label></td>
       
      <td style=" border: 1px solid #000 !important;"><asp:Label ID="lbl_rate" runat="server" Text='<%# Eval("s_rate") %>'></asp:Label></td>
      <td style=" border: 1px solid #000 !important;" ><asp:Label ID="lbl_stotal" runat="server" Text='<%# Eval("s_stotal") %>'></asp:Label></td>
      <td style=" border: 1px solid #000 !important;"><asp:Label ID="lbl_cgst" runat="server" Text='<%# Eval("s_cgsta") %>'></asp:Label></td>

      <td style=" border: 1px solid #000 !important;"><asp:Label ID="lbl_sgst" runat="server" Text='<%# Eval("s_sgsta") %>'></asp:Label></td>
      <td style=" border: 1px solid #000 !important;"><asp:Label ID="lbl_igst" runat="server" Text='<%# Eval("s_igsta") %>'></asp:Label></td>

    <td style=" border: 1px solid #000 !important;"><asp:Label ID="lbl_amount" runat="server" Text='<%# Eval("s_amount") %>'></asp:Label></td>
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
              <div class="col-lg-5 col-md-5">
              <p class="lead" style="font-size:16px">Note :</p>
              <asp:Label ID="lbl_note" runat="server" Text=""></asp:Label>
           <asp:HiddenField ID="lbl_opening_balance" runat="server" />
                <hr/>
                <p class="lead" style="font-size:16px">Bank Details :</p>
                <p class="text-muted" style="font-size: 13px;"><b>Bank Name : </b>&nbsp&nbsp<asp:Label ID="lbl_bank_name" runat="server" Text=""></asp:Label></p>
                 <p class="text-muted" style="font-size: 13px;"><b>Branch : </b>&nbsp&nbsp<asp:Label ID="lbl_branch" runat="server" Text=""></asp:Label></p>
                 <p class="text-muted" style="font-size: 13px;"><b>Bank A/C No : </b>&nbsp&nbsp<asp:Label ID="lbl_ac" runat="server" Text=""></asp:Label></p>
                 <p class="text-muted" style="font-size: 13px;"><b>Bank Branch IFSC : </b>&nbsp&nbsp<asp:Label ID="lbl_ifsc" runat="server" Text=""></asp:Label></p>
                  <p class="text-muted" style="font-size: 13px;"><b>UPI Number : </b>&nbsp&nbsp<asp:Label ID="lbl_upino" runat="server" Text=""></asp:Label></p>
              </div>
            <!-- /.col -->
            <div class="col-lg-7 col-md-7 text-right">
              
              <div class="table-responsive">
                <table class="table table-bordered">
                    
                  <tbody>
                                           
                      <tr>
                           <th style=" border: 1px solid #000 !important;">Total Before GST:</th>
                    <td style="width:20%;border: 1px solid #000 !important;">₹ <asp:Label ID="lbl_subtotal" runat="server" Text=""></asp:Label></td>

                                                    
                                                   <th style=" border: 1px solid #000 !important;">CGST:</th>
                    <td style="width:20%;border: 1px solid #000 !important;">₹ <asp:Label ID="lbl_cgst1" runat="server" Text=""></asp:Label></td>
                          

                      </tr>

                               
                        <tr>

                    <th style=" border: 1px solid #000 !important;">SGST:</th>
                    <td style="width:20%;border: 1px solid #000 !important;">₹ <asp:Label ID="lbl_sgst1" runat="server" Text=""></asp:Label></td>

                             <th style=" border: 1px solid #000 !important;">Transport:</th>
                    <td style="width:20%;border: 1px solid #000 !important;">₹ <asp:Label ID="lbl_tranport" runat="server" Text=""></asp:Label></td>
                    
                  </tr>

                    
                      
                      <tr>
                            <asp:Panel ID="Panel4" runat="server">
                    <th style=" border: 1px solid #000 !important;">Design Charges:</th>
                             <td style=" border: 1px solid #000 !important;">₹ <asp:Label ID="lbl_dtp" runat="server" Text=""></asp:Label></td>
                                 </asp:Panel>

                           <asp:Panel ID="Panel7" runat="server">
                 <th style=" border: 1px solid #000 !important;">Pasting Charges:</th>
                    <td style="width:20%;border: 1px solid #000 !important;">₹ <asp:Label ID="lbl_pasting" runat="server" Text=""></asp:Label></td>
                </asp:Panel>
                       
                            </tr>
                 
                     
                      
                      
                      <tr>
                          <asp:Panel ID="Panel6" runat="server">
                    <th style=" border: 1px solid #000 !important;">Framing Charges:</th>
                             <td style=" border: 1px solid #000 !important;">₹ <asp:Label ID="lbl_framing" runat="server" Text=""></asp:Label></td>
                               </asp:Panel>

                          <asp:Panel ID="Panel8" runat="server">
                 <th style=" border: 1px solid #000 !important;">Fitting Charges:</th>
                    <td style="width:20%;border: 1px solid #000 !important;">₹ <asp:Label ID="lbl_fitting" runat="server" Text=""></asp:Label></td>
                </asp:Panel>
                       
                            </tr>
                 
                     
                      
                      <tr>

                    <%--<th style=" border: 1px solid #000 !important;">Design Charges:</th>
                             <td style=" border: 1px solid #000 !important;">₹ <asp:Label ID="Label2" runat="server" Text=""></asp:Label></td>--%>

                           <asp:Panel ID="Panel5" runat="server">

                 <th style=" border: 1px solid #000 !important;">Intallation Charges:</th>
                    <td style="width:20%;border: 1px solid #000 !important;">₹ <asp:Label ID="lbl_install" runat="server" Text=""></asp:Label></td>

                               </asp:Panel>

                                 <th style=" border: 1px solid #000 !important;">Payment Method:</th>
                    <td style=" border: 1px solid #000 !important;">
                        <asp:Label ID="lbl_payment_method" runat="server" Text=""></asp:Label>
                    </td>
                
                       
                            </tr>
                 
                      
                      
                       <tr>
                  
         <th style=" border: 1px solid #000 !important;">Advance:</th>
                    <td style="width:20%;border: 1px solid #000 !important;">₹ <asp:Label ID="lbl_adjustment" runat="server" Text=""></asp:Label></td>

                      <th style=" border: 1px solid #000 !important;">Discount:</th>
                    <td style="width:20%;border: 1px solid #000 !important;">₹ <asp:Label ID="lbl_discount" runat="server" Text=""></asp:Label></td>
                  </tr>
                       
                      
             
                      <tr>

                                             <th style=" border: 1px solid #000 !important;">Total:</th>
                    <td style="width:20%;border: 1px solid #000 !important;">₹ <asp:Label ID="lbl_total" runat="server" onchange="inWords();" Text=""></asp:Label></td>
                 

                                <th style=" border: 1px solid #000 !important;">Balance:</th>
                    <td style="width:20%;border: 1px solid #000 !important;">₹ <asp:Label ID="lbl_balance" runat="server" Text=""></asp:Label></td>

                        
                  </tr>
                       <tr>
                          <asp:Panel id="chequeupi" runat="server">
                              
                           <th style=" border: 1px solid #000 !important;">Cheque / UPI No:</th>
                    <td style="width:20%;border: 1px solid #000 !important;"> <asp:Label ID="lblupicheque" runat="server" Text=""></asp:Label></td>
                      </asp:Panel>
                              </tr>

                    <%--  <tr>
                          <td style=" border: 1px solid #000 !important;" ></td>
         <td style=" border: 1px solid #000 !important;"></td>

                          
                          <td style=" border: 1px solid #000 !important;" ></td>
                           <td style=" border: 1px solid #000 !important;"></td>       
                      </tr>--%>

                 <%-- <tr>
                    <th>Shipping:</th>
                    <td>₹ <asp:Label ID="lbl_shipping" runat="server" Text=""></asp:Label></td>
                  </tr>--%>
                  <tr class="no-print">
                    
                  </tr>
                  <tr>
                    
                  </tr>
                           <tr>
                    
                    
                  </tr>
                  <tr>
                    
                    
                  </tr>
                    
                </tbody>
                    

                </table>
                  
                   
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
                                        <h5 style="margin-left:40px;">
                                            (<asp:Label ID="lbl_sign" runat="server" Text='<%# Eval("com_company_name") %>'></asp:Label>)</h5>
                                    <h5>Authorised Signatory</h5>
                           </div>

                       
                   </div>
                  </div>
            <!-- /.col --> 
          </div>
          <!-- /.row --> 
          <br/>
           <asp:Panel ID="Panel2" runat="server">
      <div class="card-body">
      <h4 class="text-black">Image List</h4>
                  
      <div class="table-responsive">
                  <table id="example1" class="table table-bordered table-striped">
                <thead>
                    
                <tr>
                  
                  <th>Image</th>
                  <th>Remark</th>
                  <th>Action</th>
                </tr>
                </thead>
                <tbody>
                 <asp:Repeater ID="Repeater1" runat="server" > 
      <ItemTemplate> 
          <tr>
               
                  <td><img src="../Invoice Images/<%# Eval("im_image") %>" height="200" width="200">
                  </td>
                 <td><asp:Label ID="lbl_id" runat="server" visible="false" Text='<%# Eval("im_id") %>'></asp:Label>
              <asp:Label ID="lbl_remark" runat="server" Text='<%# Eval("im_desc") %>'></asp:Label></td>
                  <td><asp:LinkButton ID="LinkButton1" runat="server" OnClientClick="return confirm('Do you want to delete this Image?');" OnClick="DeleteAppointment"><i  class="fa fa-trash-o"></i></asp:LinkButton>
                
                    
                 </td>
                </tr>
      </ItemTemplate>
     </asp:Repeater>
                
                </tbody>
                
              </table>


                  </div>
      </div>
               </asp:Panel>
        </section>
           <!-- this row will not appear when printing -->
         
        <!-- /.content --> 
      </div></div>
            </asp:Panel> 
             </div>
    </section>
        </div>

      <!-- Modal -->
  <div class="modal fade" id="myModal" role="dialog">
    <div class="modal-dialog">
    
      <!-- Modal content-->
      <div class="modal-content">
        <div class="modal-header">
            <h4 class="modal-title"><asp:Label ID="lbl_name" runat="server" Text="Add Image"></asp:Label></h4>
          <button type="button" class="close" data-dismiss="modal">&times;</button>
          
        </div>
        <div class="modal-body">
         
            <div class="form-horizontal form-bordered">
                
                <div class="form-group row">
                    <label class="control-label text-right col-md-3">Remark</label>
                    <div class="col-md-9">
                      
                        <asp:TextBox ID="Txt_desc" class="form-control" runat="server" TextMode="MultiLine"></asp:TextBox>
                       
                      </div>
                  </div>
                   <div class="form-group row">
                    <label class="control-label text-right col-md-3">Upload Image</label>
                    <div class="col-md-9">
                       <asp:fileupload ID="fu_image" class="form-control" runat="server">

                       </asp:fileupload>
                      </div>
                  </div>
                </div>
                <div class="form-actions">
                  <div class="row">
                    <div class="col-md-12">
                      <div class="row">
                        <div class="offset-sm-3 col-md-9">
                          
                          <asp:Button ID="Btn_submit" class="btn btn-success" runat="server" OnClientClick="return JSFunctionValidate();" Text="Submit" OnClick="Btn_submit_Click" />
                          
                          <asp:Button ID="Btn_cencel" class="btn btn-inverse" runat="server" Text="Cancel"/>

                           <asp:Label ID="Lbl_message" runat="server" Text=""></asp:Label>
                        </div>
                      </div>
                    </div>
                  </div>
                </div>
        </div>
        <div class="modal-footer">
          <button type="button" class="btn btn-default" data-dismiss="modal">Close</button>
        </div>
      </div>
      
    </div>
  </div>
    


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

