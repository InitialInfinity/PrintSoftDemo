<%@ Page Title="" Language="C#" MasterPageFile="~/Roll Purchase/RollPurchase.master" AutoEventWireup="true" CodeFile="roll_purchase.aspx.cs" Inherits="Purchase_roll_purchase" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">

  <style>
        .Txt_hide{
            display:none;
        }
</style>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
  <!-- Content Wrapper. Contains page content -->
  <div class="content-wrapper"> 
    <!-- Content Header (Page header) -->
    <section class="content-header sty-one">
      <h1>Roll Purchase Invoice</h1>
      <ol class="breadcrumb">
        <li><a href="#">Purchase</a></li>
        <li><i class="fa fa-angle-right"></i> Roll Purchase Invoice</li>
      </ol>
    </section>
     <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">

            <ContentTemplate>
                <section class="content">
                    
                    <div class="card">
                        <div class="card-body">
                            <!-- Main content -->
                            <section class="invoice">
                                <!-- title row -->
                                <div class="row">
                                    <div class="col-lg-12 m-b-3">
                                        <h3 class="text-black">INVOICE <span class="pull-right"></span> </h3>
                                    </div>
                                    <!-- /.col -->
                                </div>
                                <!-- info row -->
                                <div class="customer_name  row">
                                    <label class="control-label text-right col-md-3">Vendor Name</label>
                                    <div class="col-md-6">
                                        <asp:DropDownList ID="Dd_customer" class="form-control" runat="server" OnSelectedIndexChanged="Dd_customer_SelectedIndexChanged" AutoPostBack="True" TabIndex="1"></asp:DropDownList>
                                    </div>
                                </div>
                                 <div class="form-group row">
                                    <label class="control-label text-right col-md-3"></label>
                                    <div class="col-md-6">
                                       <asp:LinkButton ID="LinkButton1" data-toggle="modal" data-target="#myModal" class="col-md-4" runat="server">+Add Vendor</asp:LinkButton>
                                    </div>
                                    
                                     

                                </div>
                                <div class="form-group row">
                                    <label class="control-label text-right col-md-3">Invoice#</label>
                                    <div class="col-md-6">
                                        <asp:TextBox ID="Txt_invoice" ReadOnly="true" class="form-control" enabled="true" runat="server" TabIndex="2"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="form-group row">
                                    <label class="control-label text-right col-md-3">Order Number</label>
                                    <div class="col-md-6">
                                        <asp:TextBox ID="Txt_order_no" disabled="true" class="form-control" runat="server" TabIndex="3"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="form-group row">
                                    <label class="control-label text-right col-md-3">Invoice Date</label>
                                    <div class="col-md-3">
                                        <asp:TextBox ID="Txt_invoice_date" class="form-control" runat="server" TextMode="Date" TabIndex="4"></asp:TextBox>
                                    </div>
                                    <label class="control-label text-right col-md-3">Due Date</label>
                                    <div class="col-md-3">
                                        <asp:TextBox ID="Txt_due_date" class="form-control" runat="server" TextMode="Date" TabIndex="5"></asp:TextBox>
                                    </div>
                                </div>
                                <hr />
                                <div class="form-group row">

                                    <div class="col-md-5">
                                        <asp:Label ID="Label1" runat="server" Text="Product"></asp:Label>
                                    </div>
                                     <div class="col-md-6">
                                        <asp:Label ID="Label2" runat="server" Text="Description"></asp:Label>
                                    </div>
                                   

                                </div>


                                <div class="form-group row">

                                    <div class="col-md-5">
                                        <asp:DropDownList ID="Dd_enter_product" class="form-control" runat="server" AutoPostBack="True" OnSelectedIndexChanged="Dd_enter_product_SelectedIndexChanged" TabIndex="6"></asp:DropDownList>
                                   <asp:LinkButton ID="LinkButton2" Class="add_class" data-toggle="modal" data-target="#myModal2" runat="server">+Add Product</asp:LinkButton>
                                          </div>
                                    <div class="col-md-6">
                                        <asp:TextBox ID="Txt_description" rows="2" class="form-control" runat="server" TextMode="MultiLine" TabIndex="7"></asp:TextBox>
                                    </div>
                                   

                                </div>
                                
                                <div class="form-group row">
                                   
                                    <div class="col-md-3">
                                        
                                    </div>
                                    
                                </div>

                                <table class="table">
                                    <thead>
                                        <tr>

                                            <th scope="col">Roll (Feet)</th>
                                            <th scope="col">Roll (Mtr)</th>
                                            <th scope="col">Roll length (Mtr)</th>
                                            <th scope="col">Total Sq. Meter </th>
                                        </tr>
                                    </thead>
                                    <tbody>
                                        <tr>

                                            <td>
                                                
                                                <%--<asp:TextBox ID="Txt_roll_Feet" class="form-control" runat="server"></asp:TextBox>--%>
                                                     <asp:DropDownList ID="drp_feet" class="form-control" runat="server" AutoPostBack="True" OnSelectedIndexChanged="drp_feet_SelectedIndexChanged" TabIndex="8"></asp:DropDownList>
                                            <%--</td>--%> 
                                              
                                            <td>
                                                <asp:TextBox ID="txt_roll_width" onkeyup="Total_sqmtr();rate();" class="form-control" runat="server" TabIndex="9"></asp:TextBox></td>
                                            <td>
                                                <asp:TextBox ID="Txt_roll_height" class="form-control" onkeyup="Total_sqmtr();rate();" onchange="Total_sqmtr(); rate();" runat="server" TabIndex="10"></asp:TextBox></td>
                                            <td>
                                                <asp:TextBox ID="Txt_total_roll" class="form-control" onkeyup="Total_sqmtr();rate();" runat="server" TabIndex="11"></asp:TextBox></td>
                                        </tr>
                                             </tbody>
                                </table>
                                        <table class="table">
                                    <thead>
                                        <tr>

                                            <th scope="col">Total Sq.ft</th>
                                            <th scope="col">Rate</th>
                                            <th scope="col">Amount</th>
                                            <th scope="col">Quantity</th>
                                            <th scope="col">Total</th>
                                        </tr>
                                        </thead>
                                            <tbody>
                                         <tr>

                                           <td>
                                                <asp:TextBox ID="Txt_total_roll_sq" class="form-control" onkeyup="rate();" runat="server" TabIndex="12"></asp:TextBox></td>
                                            <td>
                                                <asp:TextBox ID="Txt_rate" class="form-control" onkeyup="rate();" runat="server" TabIndex="13"></asp:TextBox></td>
                                            <td>
                                                <asp:TextBox ID="txt_amount" class="form-control" runat="server" TabIndex="14"></asp:TextBox></td>
                                            <td>
                                                <asp:TextBox ID="txt_quantity" class="form-control" onkeyup="quan_amount();gst();" onchange="quan_amount();gst();" runat="server" TabIndex="15"></asp:TextBox></td>
                                            <td>
                                                <asp:TextBox ID="txt_total_amt" class="form-control" runat="server" TabIndex="16"></asp:TextBox></td>
                                        </tr>

                                    </tbody>
                                </table>
                                
                                <table class="table">
                                    <thead>
                                        <tr>

                                            <th scope="col">CGST (%)</th>
                                            <th scope="col">SGST (%)</th>
                                            <th scope="col">IGST (%)</th>
                                           
                                            <th scope="col">Final Amount</th>
                                           
                                        </tr>
                                    </thead>
                                    <tbody>
                                        <tr>

                                            <td>
                                                <asp:TextBox ID="txt_cgst" class="form-control" OnkeyUp="rate(); quan_amount(); gst(); " onchange="rate(); quan_amount(); gst(); " runat="server" TabIndex="16"></asp:TextBox></td>
                                            <td>
                                                <asp:TextBox ID="txt_sgst" class="form-control" OnkeyUp="rate(); quan_amount(); gst(); " onchange="rate(); quan_amount(); gst(); " runat="server" TabIndex="17"></asp:TextBox></td>
                                            <td>
                                                <asp:TextBox ID="txt_igst" class="form-control" OnkeyUp="rate(); quan_amount(); gst(); " onchange="rate(); quan_amount(); gst(); "  runat="server" TabIndex="18"></asp:TextBox></td>
                                            <td>
                                                <asp:TextBox ID="txt_final_amt" class="form-control" runat="server" TabIndex="19"></asp:TextBox></td>
                                            <td><asp:Button ID="Btn_cart" class="btn btn-primary pull-right" Style="margin-right: 5px;" runat="server" Text="Add to Cart" OnClick="Btn_cart_Click" /></td>
                                           
                                        </tr>

                                    </tbody>
                                </table>

                                <div class="row ">
                                    <div class="col-xs-12 table-responsive">
                                        <asp:GridView ID="GridView1" class="table table-striped" runat="server" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3" OnDataBound="GridView1_DataBound" OnRowDataBound="GridView1_RowDataBound" OnPageIndexChanging="GridView1_PageIndexChanging" OnRowDeleting="GridView1_RowDeleting">
                                            <Columns>
                                                <asp:ButtonField CommandName="Delete" HeaderText="Action" ShowHeader="True" Text="Delete" />
                                            </Columns>
                                            <FooterStyle BackColor="White" ForeColor="#000066" />
                                            <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" />
                                            <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
                                            <RowStyle ForeColor="#000066" />
                                            <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                                            <SortedAscendingCellStyle BackColor="#F1F1F1" />
                                            <SortedAscendingHeaderStyle BackColor="#007DBB" />
                                            <SortedDescendingCellStyle BackColor="#CAC9C9" />
                                            <SortedDescendingHeaderStyle BackColor="#00547E" />
                                            
                                        </asp:GridView>
                                    </div>
                                </div>

                                <div class="row m-t-3">
                                    <!-- accepted payments column -->
                                    <div class="col-lg-6">
                                        <p class="lead">Total Qty: <asp:Label ID="lbl_totalqty" runat="server" Text=""></asp:Label></p>
                                        
                                        <asp:HiddenField ID="lbl_product_hsn" runat="server" />
                                        <asp:HiddenField ID="lbl_unit" runat="server" />
                                        <asp:HiddenField ID="lbl_total_cgst" runat="server" />
                                        <asp:HiddenField ID="lbl_total_sgst" runat="server" />
                                        <asp:HiddenField ID="lbl_total_igst" runat="server" />
                                        <asp:HiddenField ID="lbl_total_taxable" runat="server" />
                                    </div>
                                    <!-- /.col -->
                                    <div class="col-lg-6">
                                        <p class="lead"></p>
                                        <div class="table-responsive">
                                            <table class="table">
                                                <tbody>
                                                    <tr>
                                                        <th style="width: 50%">Subtotal:</th>
                                                        <td>₹ <asp:Label ID="lbl_subtotal" runat="server" Text=""></asp:Label></td>
                                                        <asp:HiddenField ID="lbl_subtotal2" runat="server" />
                                                    </tr>
                                                    <tr>
                                                        <th>Total GST</th>
                                                        <td>₹ <asp:Label ID="lbl_gst" runat="server" Text=""></asp:Label></td>

                                                    </tr>
                                                    <tr>
                                                        <th>Payment Mode :</th>
                                                        <td>
                                                                <asp:DropDownList ID="Drp_payment_mode" class="form-control" runat="server">
                                                             <asp:ListItem>Cash</asp:ListItem>
                                                       <asp:ListItem>Credit</asp:ListItem>
                                                        <asp:ListItem>Cheque</asp:ListItem>
                                                        <asp:ListItem>Google Pay</asp:ListItem>
                                                        <asp:ListItem>Phone Pay</asp:ListItem>
                                                        <asp:ListItem>Paytm</asp:ListItem>
                                                                     <asp:ListItem>NEFT</asp:ListItem>
                                                            <asp:ListItem>IMPS</asp:ListItem>
                                                        <asp:ListItem>Other</asp:ListItem>
                                                    </asp:DropDownList>
                                                        </td>
                                                    </tr>

                                                    <tr>
                                                        <th>Transport:</th>
                                                        <td>
                                                            <asp:TextBox ID="Txt_shipping" onkeyup="final_total();" onchange="final_total();" class="form-control" runat="server" TextMode="Number"></asp:TextBox></td>
                                                    </tr>
                                                    <tr>
                                                        <th>Advance:</th>
                                                        <td>
                                                            <asp:TextBox ID="Txt_adjustment" onkeyup="final_total();" onchange="final_total();"  class="form-control" runat="server" TextMode="Number"></asp:TextBox></td>
                                                    </tr>
                                                    <tr>
                                                        <th>Discount:</th>
                                                        <td>
                                                            <asp:TextBox ID="Txt_discount" onkeyup="final_total();" onchange="final_total();" class="form-control" runat="server" TextMode="Number"></asp:TextBox></td>
                                                    </tr>
                                                    <tr>
                                                        <th>Total:</th>
                                                        <td class="grand_total">₹ <asp:Label ID="lbl_total" runat="server" Text="" TextMode="Number"></asp:Label></td>
                                                        
                                                    </tr>
                                                    <tr>
                                                        <th></th>
                                                        <td>
                                                            <asp:TextBox Class="Txt_hide" ID="hide_total" runat="server"></asp:TextBox></td>
                                                        
                                                    </tr>

                                                </tbody>
                                            </table>
                                        </div>
                                    </div>
                                    <!-- /.col -->
                                </div>
                                <!-- /.row -->

                                <!-- this row will not appear when printing -->
                                <div class="row no-print">
                                    <div class="col-lg-12">
                                        <asp:Label ID="Lbl_message"  runat="server" Text=""></asp:Label>
                                        <asp:Button ID="Btn_submit_payment" class="btn btn-success pull-right" runat="server" OnClientClick="return JSFunctionValidate();" Text="Save & Close" OnClick="Btn_submit_payment_Click" />
                                        <asp:Button ID="Btn_generate_pdf" class="btn btn-primary pull-right" Style="margin-right: 5px;" runat="server" Text="Save Invoice" OnClientClick="return JSFunctionValidate();" OnClick="Btn_generate_pdf_Click" />


                                    </div>
                                </div>
                            </section>
                            <!-- /.content -->
                        </div>
                    </div>
                </section>
            </ContentTemplate>
        </asp:UpdatePanel>
   </div>
  <!-- /.content-wrapper -->
  <footer class="main-footer">
    <div class="pull-right hidden-xs">Version 1.0</div>
    Copyright © 2018 PrintSoft. All rights reserved.</footer>

      <!-- Modal -->
  <div class="modal fade" id="myModal" role="dialog">
    <div class="modal-dialog">
    
      <!-- Modal content-->
      <div class="modal-content">
        <div class="modal-header">
            <h4 class="modal-title">Add Vendor</h4>
          <button type="button" class="close" data-dismiss="modal">&times;</button>
          
        </div>
        <div class="modal-body">
          <div class="form-body">
                  <div class="form-group row">
                    <label class="control-label text-right col-md-3">Vendor Name<span style="color:red;">*</span></label>
                    <div class="col-md-9">
                      
                      <asp:TextBox ID="Txt_vendor_name" placeholder="Vendor Name" class="form-control" runat="server"></asp:TextBox>
                      </div>
                  </div>
                   
                  <div class="form-group row">
                    <label class="control-label text-right col-md-3">Address</label>
                    <div class="col-md-9">
                     <asp:TextBox ID="Txt_address"  class="form-control" runat="server" TextMode="MultiLine"></asp:TextBox>
                         </div>
                  </div>
                    
                   <div class="form-group row">
                    <label class="control-label text-right col-md-3">Contact no.</label>
                    <div class="col-md-9">
                       <asp:TextBox ID="Txt_contact"  placeholder="Contact no." class="form-control" runat="server"></asp:TextBox>
                      </div>
                  </div>
                    <div class="form-group row">
                    <label class="control-label text-right col-md-3">Alternate Contact no.</label>
                    <div class="col-md-9">
                       <asp:TextBox ID="Txt_contact2" placeholder="Alternate Contact no." class="form-control" runat="server"></asp:TextBox>
                      </div>
                  </div>
                  <div class="form-group row">
                    <label class="control-label text-right col-md-3">GST no.</label>
                    <div class="col-md-9">
                      <asp:TextBox ID="Txt_gst_no" placeholder="GST no." class="form-control" runat="server"></asp:TextBox>
                    </div>
                  </div>
                  <div class="form-group row">
                    <label class="control-label text-right col-md-3">Opening Balance</label>
                    <div class="col-md-9">
                      <asp:TextBox ID="Txt_opening_balance"  placeholder="Opening Balance" class="form-control" runat="server"></asp:TextBox>
                    </div>
                  </div>
                  <div class="form-group row">
                    <label class="control-label text-right col-md-3">Email ID</label>
                    <div class="col-md-9">
                      <asp:TextBox ID="Txt_email" placeholder="Email ID" class="form-control" runat="server"></asp:TextBox>
                    </div>
                  </div>
                  
                </div>
        </div>
          
          <asp:UpdatePanel ID="UpdatePanel3" runat="server">
              <ContentTemplate>
        <div class="modal-footer">
             <asp:Label ID="lbl_msg" Style="color:red;" runat="server" Text=""></asp:Label>
             <asp:Button ID="Button1" class="btn btn-success" runat="server" Text="Submit" OnClientClick="return JSFunctionValidate2();" OnClick="Button1_Click"  />
          <button type="button" class="btn btn-default" data-dismiss="modal">Close</button>
        </div>
                  </ContentTemplate>
              </asp:UpdatePanel>
      </div>
      
    </div>
  </div>
    <!-- Modal -->
  <div class="modal fade" id="myModal2" role="dialog">
    <div class="modal-dialog">
    
      <!-- Modal content-->
      <div class="modal-content">
        <div class="modal-header">
            <h4 class="modal-title">Add Purchase Product</h4>
          <button type="button" class="close" data-dismiss="modal">&times;</button>
          
        </div>
        <div class="modal-body">
        <div class="form-body">
                  <div class="form-group row">
                    <label class="control-label text-right col-md-3">Product Name<span style="color:red;">*</span></label>
                    <div class="col-md-9">
                      
                      <asp:TextBox ID="Txt_product_name" placeholder="Product Name" class="form-control" runat="server"></asp:TextBox>
                      </div>
                  </div>
                 
                    <div class="form-group row">
                    <label class="control-label text-right col-md-3">Unit</label>
                    <div class="col-md-9">
                         <asp:DropDownList ID="Dd_unit" class="form-control" runat="server">
                          
                             <asp:ListItem Value="Mtr">Mtr</asp:ListItem>
                              <asp:ListItem Value="sqft">Sqft</asp:ListItem>
                         </asp:DropDownList>
                      </div>
                  </div>
                  
                   <div class="form-group row">
                    <label class="control-label text-right col-md-3">CGST</label>
                    <div class="col-md-9">
                        <asp:dropdownlist ID="Dd_cgst" class="form-control" runat="server">
                            <asp:ListItem Value="0">0 %</asp:ListItem>
                            <asp:ListItem Value="5">5 %</asp:ListItem>
                            <asp:ListItem Value="6">6 %</asp:ListItem>
                            <asp:ListItem Value="9">9 %</asp:ListItem>
                            <asp:ListItem Value="12">12 %</asp:ListItem>
                            <asp:ListItem Value="18">18 %</asp:ListItem>
                            <asp:ListItem Value="28">28 %</asp:ListItem>

                        </asp:dropdownlist>
                    </div>
                  </div>
                    <div class="form-group row">
                    <label class="control-label text-right col-md-3">SGST</label>
                    <div class="col-md-9">
                       <asp:dropdownlist  ID="Dd_sgst" class="form-control" runat="server">
                           <asp:ListItem Value="0">0 %</asp:ListItem>
                            <asp:ListItem Value="5">5 %</asp:ListItem>
                            <asp:ListItem Value="6">6 %</asp:ListItem>
                            <asp:ListItem Value="9">9 %</asp:ListItem>
                            <asp:ListItem Value="12">12 %</asp:ListItem>
                            <asp:ListItem Value="18">18 %</asp:ListItem>
                            <asp:ListItem Value="28">28 %</asp:ListItem>
                       </asp:dropdownlist>
                      </div>
                  </div>
                    <div class="form-group row">
                    <label class="control-label text-right col-md-3">IGST</label>
                    <div class="col-md-9">
                       <asp:dropdownlist ID="Dd_igst" class="form-control" runat="server">
                          <asp:ListItem Value="0">0 %</asp:ListItem>
                            <asp:ListItem Value="5">5 %</asp:ListItem>
                            <asp:ListItem Value="6">6 %</asp:ListItem>
                            <asp:ListItem Value="9">9 %</asp:ListItem>
                            <asp:ListItem Value="12">12 %</asp:ListItem>
                            <asp:ListItem Value="18">18 %</asp:ListItem>
                            <asp:ListItem Value="28">28 %</asp:ListItem>
                       </asp:dropdownlist>
                      </div>
                  </div>
                     <div class="form-group row">
                    <label class="control-label text-right col-md-3">HSN Code</label>
                    <div class="col-md-9">
                       <asp:TextBox ID="Txt_hsn"  placeholder="HSN Code" class="form-control" runat="server"></asp:TextBox>
                      </div>
                  </div>

                  <div class="form-group row">
                    <label class="control-label text-right col-md-3">Rate (Rs)<span style="color:red;">*</span></label>
                    <div class="col-md-9">
                      <asp:TextBox ID="Txt_ra"  placeholder="Rate" class="form-control" runat="server" ></asp:TextBox>
                    </div>
                  </div>
                  <div class="form-group row">
                    <label class="control-label text-right col-md-3">Description</label>
                    <div class="col-md-9">
                             <asp:TextBox ID="Txt_desc" class="form-control" runat="server" TextMode="MultiLine"></asp:TextBox>
                      </div>
                  </div>
                 
                  
                </div>
        </div>
          <asp:UpdatePanel ID="UpdatePanel4" runat="server">
              <ContentTemplate>
        <div class="modal-footer">
              <asp:Label ID="lbl_msg2" Style="color:red;" runat="server" Text=""></asp:Label>
             <asp:Button ID="Button2" class="btn btn-success" runat="server" OnClientClick="return JSFunctionValidate3();" Text="Submit" OnClick="Button2_Click"  />
          <button type="button" class="btn btn-default" data-dismiss="modal">Close</button>
        </div>
                    </ContentTemplate>
              </asp:UpdatePanel>
      </div>
      
    </div>
  </div>
   



 <script type="text/javascript">


     function Total_sqmtr() {

           var Size_in_Feet = document.getElementById('<%= drp_feet.ClientID %>');
         var roll_widht = document.getElementById('<%= txt_roll_width.ClientID %>');

         var total_roll_in_meter = document.getElementById('<%= Txt_total_roll.ClientID%>');

         var roll_height = document.getElementById('<%= Txt_roll_height.ClientID %>');

         var total_roll_sqrft = document.getElementById('<%= Txt_total_roll_sq.ClientID %>');

         if (roll_widht == null) {
             roll_widht = 0;
         }
         if (roll_height == null) {
             height = 0;
         }

         var Total_sqrmtr = (parseFloat(roll_widht.value) * parseFloat(roll_height.value));

         total_roll_in_meter.value = parseFloat(Total_sqrmtr);
      var  Final_sqrmtr = (parseFloat(Total_sqrmtr));

         var sqrft_formula = 10.764;

         Total_sqrft = (parseFloat(sqrft_formula) * parseFloat(Final_sqrmtr));

         total_roll_sqrft.value = (parseFloat(Total_sqrft)).toFixed(2);




     }

  function rate() {
            var rates = document.getElementById('<%=Txt_rate.ClientID %>');
            var sqrft= document.getElementById('<%=Txt_total_roll_sq.ClientID %>');
            var amount = document.getElementById('<%=txt_amount.ClientID %>');   
            if (rates == null) {
                rates = 0;
            }
            if (sqrft == null) {
                sqrft = 0;
            }
            if (amount == null) {
                amount = 0;
            }
            var rate_amount = (parseFloat(sqrft.value) * parseFloat(rates.value));

      amount.value = rate_amount.toFixed(2);
  }


      function quan_amount() {
           var amt = document.getElementById('<%=txt_amount.ClientID %>');
            var quantity = document.getElementById('<%=txt_quantity.ClientID %>');
           var total = document.getElementById('<%=txt_total_amt.ClientID %>');
            if (amt == null) {
                amt = 0;
            }
            if (quantity == null) {
                quantity = 0;
            }
            if (total == null) {
                total = 0;
            }
            var total_amount = (parseFloat(amt.value) * parseFloat(quantity.value))

          total.value = total_amount.toFixed(2);

      }


      function gst() {
            var cgst = document.getElementById('<%= txt_cgst.ClientID %>');
            var sgst = document.getElementById('<%= txt_sgst.ClientID %>');
            var igst = document.getElementById('<%= txt_igst.ClientID %>');
              var total = document.getElementById('<%= txt_total_amt.ClientID %>');
              if (total == null)
              {
                 
                  total = 0;
              }
              
              
              if (cgst == null) {
                  cgst = 0;
              }
              if (sgst == null) {
                  sgst = 0;
              }
              if (igst == null) {
                  igst = 0;
              }
             

            var total_amount = total.value;

            var rcgst = total_amount * cgst.value / 100;
            var rsgst = total_amount * sgst.value / 100;
            var rigst = total_amount * igst.value / 100;
                 
            var amt = parseFloat(rcgst) + parseFloat(rsgst) + parseFloat(rigst) + parseFloat(total_amount);
                  var amount = document.getElementById('<%= txt_final_amt.ClientID %>');
              amount.value = amt.toFixed(2);
          }
      

        function final_total() {
            var subtotal = document.getElementById('<%=lbl_subtotal2.ClientID %>');
          
            var ship = document.getElementById('<%=Txt_shipping.ClientID %>');
            var adjustment = document.getElementById('<%=Txt_adjustment.ClientID %>');
            var discount = document.getElementById('<%=Txt_discount.ClientID %>');
           
         
            var total_amount = ((parseFloat(subtotal.value) + parseFloat(ship.value) - parseFloat(adjustment.value)) - parseFloat(discount.value));

           
            document.getElementById('<%=lbl_total.ClientID %>').innerHTML = total_amount;
         document.getElementById('<%=hide_total.ClientID %>').value = total_amount;
        }
       


         <%--         function feet()
    {
             var Size_in_Feet = document.getElementById('<%= Txt_roll_Feet.ClientID %>');
                      var roll_height = document.getElementById('<%= Txt_roll_height.ClientID %>');

                      var roll_widht = document.getElementById('<%= Txt_roll_height.ClientID %>');

               if (feet == null)
             {
                feet = 0;
             }
               if (height == null) {
                   height = 0;
             }
           
               var sqrft_total = (parseFloat(feet.value)/39.37);

               height.value = sqrft_total.toFixed(4);

         }
           function totalroll()
    {
               var height = document.getElementById('<%= Txt_roll_height.ClientID %>');
             var rollsize = document.getElementById('<%= Txt_roll_size.ClientID %>');
             var totalroll = document.getElementById('<%= Txt_total_roll.ClientID %>');
               if (height == null)
             {
                   height = 0;
             }
               if (rollsize == null) {
                   rollsize = 0;
             }
               if (totalroll == null) {
                   totalroll = 0;
             }
               var sqrft_total = (parseFloat(height.value) * parseFloat(rollsize.value));

               totalroll.value = sqrft_total.toFixed(4);

           }

          function totalsqft()
    {
             var sqmtr = document.getElementById('<%= Txt_total_roll.ClientID %>');
              var sqft = document.getElementById('<%= Txt_total_roll_sq.ClientID %>');
              if (sqmtr == null)
             {
                  sqmtr = 0;
             }
              if (sqft == null) {
                  sqft = 0;
             }
           
              var sqrft_total = (parseFloat(sqmtr.value) * 10.764);

               sqft.value = sqrft_total.toFixed(4);

         }

        function rate() {
            var rates = document.getElementById('<%=Txt_rate.ClientID %>');
            var sqrft= document.getElementById('<%=Txt_total_roll_sq.ClientID %>');
            var amount = document.getElementById('<%=txt_amount.ClientID %>');   
            if (rates == null) {
                rates = 0;
            }
            if (sqrft == null) {
                sqrft = 0;
            }
            if (amount == null) {
                amount = 0;
            }
            var rate_amount = (parseFloat(sqrft.value) * parseFloat(rates.value));

            amount.value = rate_amount;
        }
         

        function quan_amount() {
           var amt = document.getElementById('<%=txt_amount.ClientID %>');
            var quantity = document.getElementById('<%=txt_quantity.ClientID %>');
           var total = document.getElementById('<%=txt_total_amt.ClientID %>');
            if (amt == null) {
                amt = 0;
            }
            if (quantity == null) {
                quantity = 0;
            }
            if (total == null) {
                total = 0;
            }
            var total_amount = (parseFloat(amt.value) * parseFloat(quantity.value))

            total.value = total_amount.toFixed(4);

        }
       

          function gst() {
            var cgst = document.getElementById('<%= txt_cgst.ClientID %>');
            var sgst = document.getElementById('<%= txt_sgst.ClientID %>');
            var igst = document.getElementById('<%= txt_igst.ClientID %>');
              var total = document.getElementById('<%= txt_total_amt.ClientID %>');
              if (total == null)
              {
                 
                  total = 0;
              }
              
              
              if (cgst == null) {
                  cgst = 0;
              }
              if (sgst == null) {
                  sgst = 0;
              }
              if (igst == null) {
                  igst = 0;
              }
             

            var total_amount = total.value;

            var rcgst = total_amount * cgst.value / 100;
            var rsgst = total_amount * sgst.value / 100;
            var rigst = total_amount * igst.value / 100;
                 
            var amt = parseFloat(rcgst) + parseFloat(rsgst) + parseFloat(rigst) + parseFloat(total_amount);
                  var amount = document.getElementById('<%= txt_final_amt.ClientID %>');
              amount.value = amt.toFixed(4);
          }
      

        function final_total() {
            var subtotal = document.getElementById('<%=lbl_subtotal2.ClientID %>');
          
            var ship = document.getElementById('<%=Txt_shipping.ClientID %>');
            var adjustment = document.getElementById('<%=Txt_adjustment.ClientID %>');
            var discount = document.getElementById('<%=Txt_discount.ClientID %>');
           
         
            var total_amount = ((parseFloat(subtotal.value) + parseFloat(ship.value) + parseFloat(adjustment.value)) - parseFloat(discount.value));

           
            document.getElementById('<%=lbl_total.ClientID %>').innerHTML = total_amount;
         document.getElementById('<%=hide_total.ClientID %>').value = total_amount;
        }--%>

    </script>
     <script>
function JSFunctionValidate()
{


    if(document.getElementById('<%=Dd_customer.ClientID%>').selectedIndex == 0)
{
        alert("Please Select Customer !!!");
return false;
    }
    if(document.getElementById('<%=Txt_order_no.ClientID%>').value.length==0)
{
alert("Please Enter Order no. !!!");
return false;
}
  if(document.getElementById('<%=Txt_invoice_date.ClientID%>').value.length==0)
{
alert("Please Select Invoice Date !!!");
return false;
  }
    if(document.getElementById('<%=Txt_due_date.ClientID%>').value.length==0)
{
alert("Please Select Due Date !!!");
return false;
    }
    if(document.getElementById('<%=Txt_shipping.ClientID%>').value.length==0)
{
alert("Please Enter Shipping Charges !!!");
return false;
    }
    if(document.getElementById('<%=Txt_adjustment.ClientID%>').value.length==0)
{
alert("Please Enter Adjustment !!!");
return false;
    }
    if(document.getElementById('<%=Txt_discount.ClientID%>').value.length==0)
{
alert("Please Enter Discount !!!");
return false;
}
     
  
    
  
return true;
}
        </script>
      <script>
function JSFunctionValidate2()
{
if(document.getElementById('<%=Txt_vendor_name.ClientID%>').value.length==0)
{
alert("Please Enter Vendor's Name !!!");
return false;
}

    if (document.getElementById('<%=Txt_contact.ClientID%>').value.length == 0)
{
        alert("Please Enter Vendor's Contact Number !!!");
return false;
    }
    if (!(document.getElementById('<%=Txt_contact.ClientID%>').value.length == 10))
{
        alert("Please Enter 10 Digits Contact Number !!!");
return false;
    }
     
   
    if (document.getElementById('<%=Txt_opening_balance.ClientID%>').value.length == 0)
{
        alert("Please Enter Opening Balance !!!");
return false;
    }
    
    
  if (!(/^\w+([\.-]?\w+)*@\w+([\.-]?\w+)*(\.\w{2,3})+$/.test(document.getElementById('<%=Txt_email.ClientID%>').value)) && !(document.getElementById('<%=Txt_email.ClientID%>').value.length == 0))
{  
        alert("You Have Entered an Invalid Email Address!");
        return false;
    }
return true;
}
        </script>
     <script>
function JSFunctionValidate3()
{
if(document.getElementById('<%=Txt_product_name.ClientID%>').value.length==0)
{
alert("Please Enter Product Name !!!");
return false;
}
   
  
    if (document.getElementById('<%=Txt_ra.ClientID%>').value.length == 0)
{
        alert("Please Enter Product's Rate  !!!");
return false;
    }
 
return true;
}
        </script>


</asp:Content>

