<%@ Page Title="" Language="C#" MasterPageFile="~/Purchase/Purchase.master" AutoEventWireup="true" CodeFile="edit_bill.aspx.cs" Inherits="admin_panel_Purchase_edit_bill" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
      
    <style>
        .Txt_hide{
            display:none;
        }
</style>
     <script type="text/javascript">

         var isSubmitted = false;

         function preventMultipleSubmissions() {

             if (!isSubmitted) {

                 $('#<%=Btn_generate_pdf.ClientID %>').val('Submitting.. Plz Wait..');

                 isSubmitted = true;

                 return true;

             }

             else {

                 return false;

             }

         }





     </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
        <!-- Content Wrapper. Contains page content -->
  <div class="content-wrapper"> 
    <!-- Content Header (Page header) -->
    <section class="content-header sty-one">
      <h1>Purchase Invoice</h1>
      <ol class="breadcrumb">
        <li><a href="#">Purchase</a></li>
        <li><i class="fa fa-angle-right"></i> Purchase Invoice</li>
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

                                <div class="container">
                                <!-- info row -->

                                <div class="form-group row">
                                    <label class="control-label text-right col-md-3">Customer Name</label>
                                    <div class="col-md-6">
                                        <asp:DropDownList ID="Dd_customer" class="form-control" runat="server" disabled="true"></asp:DropDownList>
                                    </div>




                                </div>
                                <div class="form-group row">
                                    <label class="control-label text-right col-md-3">Invoice#</label>
                                    <div class="col-md-6">
                                        <asp:TextBox ID="Txt_invoice" disabled="true" class="form-control" runat="server"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="form-group row">
                                    <label class="control-label text-right col-md-3">Order Number</label>
                                    <div class="col-md-6">
                                        <asp:TextBox ID="Txt_order_no" disabled="true" class="form-control" runat="server"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="form-group row">
                                    <label class="control-label text-right col-md-3">Invoice Date</label>
                                    <div class="col-md-2">
                                        <asp:TextBox ID="Txt_invoice_date" class="form-control" runat="server" TextMode="SingleLine"></asp:TextBox>
                                    </div>
                                    <label class="control-label text-right col-md-2">Due Date</label>
                                    <div class="col-md-2">
                                        <asp:TextBox ID="Txt_due_date" class="form-control" runat="server" TextMode="SingleLine"></asp:TextBox>
                                    </div>
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
                                        <asp:DropDownList ID="Dd_enter_product" class="form-control" runat="server" AutoPostBack="True" OnSelectedIndexChanged="Dd_enter_product_SelectedIndexChanged"></asp:DropDownList>
                                    </div>
                                    <div class="col-md-6">
                                        <asp:TextBox ID="Txt_description" rows="2" class="form-control" runat="server" TextMode="MultiLine"></asp:TextBox>
                                    </div>
                                   

                                </div>
                                
                                <div class="form-group row">
                                   
                                    <div class="col-md-3">
                                        
                                    </div>
                                    
                                </div>

                                <table class="table">
                                    <%--<asp:Panel ID="Panel1" runat="server">
                                    <thead>
                                        <tr>

                                            <th scope="col">Height<span style="color:red;">*</span></th>
                                            <th scope="col">Length<span style="color:red;">*</span></th>
                                            <th scope="col">Size</th>
                                            <th scope="col">Rate</th>
                                            <th scope="col">Amount</th>
                                            <th scope="col">Quantity<span style="color:red;">*</span></th>
                                            <th scope="col">Total</th>
                                        </tr>
                                    </thead>
                                    <tbody>
                                        <tr>

                                            <td>
                                                <asp:TextBox ID="txt_height" OnkeyUp="sqrft(); rate();quan_amount(); gst();" onchange="sqrft(); rate();quan_amount(); gst();" class="form-control" runat="server" TextMode="Number"></asp:TextBox></td>   
                                            <td>
                                                <asp:TextBox ID="txt_width" OnkeyUp="sqrft(); rate();quan_amount(); gst();" onchange="sqrft(); rate();quan_amount(); gst();" class="form-control" runat="server" TextMode="Number"></asp:TextBox></td>
                                            <td>
                                                <asp:TextBox ID="txt_sqrft" OnkeyUp="sqrft(); rate();quan_amount(); gst();" onchange="sqrft(); rate();quan_amount(); gst();" class="form-control" runat="server" TextMode="Number"></asp:TextBox></td>
                                            <td>
                                                <asp:TextBox ID="txt_rate" Onkeyup="sqrft(); rate();quan_amount(); gst();" onchange="sqrft(); rate();quan_amount(); gst();" class="form-control" runat="server" TextMode="Number"></asp:TextBox></td>
                                            <td>
                                                <asp:TextBox ID="txt_amount" class="form-control" runat="server"></asp:TextBox></td>
                                            <td>
                                                <asp:TextBox ID="txt_quantity" OnkeyUp="sqrft(); rate();quan_amount(); gst();" onchange="sqrft(); rate();quan_amount(); gst();" class="form-control" runat="server" TextMode="Number"></asp:TextBox></td>
                                            <td>
                                                <asp:TextBox ID="txt_total_amt" onkeyup="gst();" onchange="gst();" class="form-control" runat="server"></asp:TextBox></td>
                                        </tr>

                                    </tbody>
                                    </asp:Panel>
                                    <asp:Panel ID="Panel2" runat="server">
                                    <thead>
                                        <tr>

                                            <th scope="col">Height<span style="color:red;">*</span></th>
                                            <th scope="col">Length<span style="color:red;">*</span></th>
                                            <th scope="col">Size</th>
                                            <th scope="col">Rate</th>
                                            <th scope="col">Amount</th>
                                            <th scope="col">Quantity<span style="color:red;">*</span></th>
                                            <th scope="col">Total</th>
                                        </tr>
                                    </thead>
                                    <tbody>
                                        <tr>

                                            <td>
                                                <asp:TextBox ID="txt_height2"  disabled="true" class="form-control" runat="server" TextMode="Number"></asp:TextBox></td>   
                                            <td>
                                                <asp:TextBox ID="txt_width2" disabled="true" class="form-control" runat="server" TextMode="Number"></asp:TextBox></td>
                                            <td>
                                                <asp:TextBox ID="txt_sqrft2" disabled="true"  class="form-control" runat="server" TextMode="Number"></asp:TextBox></td>
                                            <td>
                                                <asp:TextBox ID="txt_rate2" Onkeyup="quan_amount2(); gst();" onchange="quan_amount2(); gst();" class="form-control" runat="server" TextMode="Number"></asp:TextBox></td>
                                            <td>
                                                <asp:TextBox ID="txt_amount2" disabled="true" class="form-control" runat="server" TextMode="Number"></asp:TextBox></td>
                                            <td>
                                                <asp:TextBox ID="txt_quantity2" OnkeyUp="quan_amount2(); gst();" onchange="quan_amount2(); gst();" class="form-control" runat="server" TextMode="Number"></asp:TextBox></td>
                                            <td>
                                                <asp:TextBox ID="txt_total_amt2" onkeyup="gst();" onchange="gst();" class="form-control" runat="server" TextMode="Number"></asp:TextBox></td>
                                        </tr>

                                    </tbody>
                                    </asp:Panel>--%>
                                     <asp:Panel ID="Panel1" runat="server">
                                    <thead>
                                            <tr>

                                                 <th scope="col"  style="display:none">Height</th>
                                            <th scope="col"  style="display:none">Width</th>
                                            <th scope="col"  style="display:none">Size</th>
                                                <th scope="col">Rate</th>
                                                <th scope="col"  style="display:none">Amount</th>
                                                <th scope="col">Quantity<span style="color:red;">*</span></th>
                                                <th scope="col">Total</th>
                                            </tr>
                                        </thead>
                                        <tbody>
                                            <tr>

                                                  <td style="display:none">
                                                <asp:TextBox ID="txt_height" OnkeyUp="sqrft(); rate();quan_amount(); gst();" onchange="sqrft(); rate();quan_amount(); gst();" class="form-control" runat="server" TextMode="Number"   min="0" TabIndex="6"></asp:TextBox></td>   
                                            <td  style="display:none">
                                                <asp:TextBox ID="txt_width" OnkeyUp="sqrft(); rate();quan_amount(); gst();" onchange="sqrft(); rate();quan_amount(); gst();" class="form-control" runat="server" TextMode="Number"  min="0" TabIndex="7"></asp:TextBox></td>
                                            <td  style="display:none">
                                                <asp:TextBox ID="txt_sqrft" onkeydown="javascript:return false" OnkeyUp="sqrft(); rate();quan_amount(); gst();" onchange="sqrft(); rate();quan_amount(); gst();" class="form-control" runat="server" TextMode="Number" TabIndex="8"></asp:TextBox></td>
                                                <td>
                                                    <asp:TextBox ID="txt_rate" Onkeyup="sqrft(); rate();quan_amount(); gst();" onchange="sqrft(); rate();quan_amount(); gst();" class="form-control" runat="server" TabIndex="9"></asp:TextBox></td>
                                                 <td  style="display:none">
                                                <asp:TextBox ID="txt_amount" class="form-control" runat="server" TextMode="Number" TabIndex="10"></asp:TextBox></td>
                                                <td>
                                                    <asp:TextBox ID="txt_quantity"    OnkeyUp="sqrft(); rate();quan_amount(); gst();" onchange="sqrft(); rate();quan_amount(); gst();"  min="0" class="form-control" runat="server" TextMode="Number" TabIndex="11"></asp:TextBox></td>
                                                <td>
                                                    <asp:TextBox ID="txt_total_amt" onkeydown="javascript:return false" onkeyup="gst();" onchange="gst();" class="form-control" runat="server"  TabIndex="11"></asp:TextBox></td>
                                            </tr>

                                        </tbody>
                                    </asp:Panel>
                                    <asp:Panel ID="Panel2" runat="server">
                                     <thead>
                                            <tr>

                                                <th scope="col"  style="display:none">Height</th>
                                                <th scope="col"  style="display:none">Width</th>
                                                <th scope="col" style="display:none">Size</th>
                                                <th scope="col">Rate</th>
                                                <th scope="col" style="display:none">Amount</th>
                                                <th scope="col">Quantity<span style="color:red;">*</span></th>
                                                <th scope="col">Total</th>
                                            </tr>
                                        </thead>
                                        <tbody>
                                            <tr>
                                                  <td>
                                                    <asp:TextBox ID="txt_rate2" Onkeyup="quan_amount2(); gst();" onchange="quan_amount2(); gst();" class="form-control" runat="server" ></asp:TextBox>

                                                  </td>
                                                 <td>
                                                    <asp:TextBox ID="txt_quantity2"   OnkeyUp="quan_amount2(); gst();" onchange="quan_amount2(); gst();" class="form-control" runat="server" TextMode="Number"  min="0"></asp:TextBox>

                                                 </td>
                                                 <td>
                                                    <asp:TextBox ID="txt_total_amt2" onkeydown="javascript:return false" onkeyup="gst();" onchange="gst();" class="form-control" runat="server" ></asp:TextBox>

                                                 </td>
                                                <td>
                                                    <asp:TextBox ID="txt_height2" style="display:none" class="form-control" runat="server" TextMode="Number"  min="0"></asp:TextBox></td>
                                                <td>
                                                    <asp:TextBox ID="txt_width2" style="display:none" class="form-control" runat="server" TextMode="Number"  min="0"></asp:TextBox></td>
                                                <td>
                                                    <asp:TextBox ID="txt_sqrft2" onkeydown="javascript:return false" style="display:none" class="form-control" runat="server" TextMode="Number"></asp:TextBox></td>
                                              
                                                <td>
                                                    <asp:TextBox ID="txt_amount2" onkeydown="javascript:return false" style="display:none" class="form-control" runat="server" ></asp:TextBox></td>
                                               
                                               
                                            </tr>

                                        </tbody>
                                    </asp:Panel>

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
                                                <asp:TextBox ID="txt_cgst" class="form-control" OnkeyUp="quan_amount2(); sqrft(); rate(); quan_amount(); gst(); " onchange="quan_amount2(); sqrft(); rate(); quan_amount(); gst();" runat="server" TextMode="Number"  min="0"></asp:TextBox></td>
                                            <td>
                                                <asp:TextBox ID="txt_sgst" class="form-control" OnkeyUp="quan_amount2(); sqrft(); rate(); quan_amount(); gst(); " onchange="quan_amount2(); sqrft(); rate(); quan_amount(); gst();" runat="server" TextMode="Number"  min="0"></asp:TextBox></td>
                                            <td>
                                                <asp:TextBox ID="txt_igst" class="form-control" OnkeyUp="quan_amount2(); sqrft(); rate(); quan_amount(); gst(); " onchange="quan_amount2(); sqrft(); rate(); quan_amount(); gst();" runat="server" TextMode="Number"  min="0"></asp:TextBox></td>
                                            <td>
                                                <asp:TextBox ID="txt_final_amt"  onkeydown="javascript:return false" class="form-control" runat="server"></asp:TextBox></td>
                                            <td><asp:Button ID="Btn_cart" class="btn btn-primary pull-right" Style="margin-right: 5px;" runat="server" OnClientClick="return JSFunctionValidate4();" Text="Add to Cart" OnClick="Btn_cart_Click" /></td>
                                           
                                        </tr>

                                    </tbody>
                                </table>
                                <div class="row">
                                    <div class="col-md-4">
                                    <asp:Button ID="Button3" class="btn btn-primary" Style="margin-right: 5px; background-color:gray !important;" runat="server" Text="Cancel" OnClick="Button3_Click"/>    
                                    </div>
                                    
                                    <div class="col-md-4">
                                    <asp:Button ID="Button2" class="btn btn-primary" Style="margin-right: 5px; background-color:red !important;" runat="server" Text="Delete Entry" OnClick="Button2_Click" />    
                                    </div>
                                    <div class="col-md-4">
                                    <asp:Button ID="Button1" class="btn btn-primary" Style="margin-right: 5px; background-color:green !important;" runat="server" Text="Edit / Update" OnClick="Button1_Click" />    
                                    </div>
                                    </div>
                                <br/>
                                <div class="row ">
                                    <div class="col-xs-12 table-responsive">
                                        <asp:GridView ID="GridView1" class="table table-striped" runat="server" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3" OnDataBound="GridView1_DataBound" OnRowDataBound="GridView1_RowDataBound" OnPageIndexChanging="GridView1_PageIndexChanging" OnRowDeleting="GridView1_RowDeleting" OnRowCreated="GridView1_RowCreated" OnRowCommand="GridView1_RowCommand" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" >
                                          
                                            <Columns>
                                                <%--<asp:ButtonField CommandName="Delete" HeaderText="Action" ShowHeader="True" Text="Delete" />--%>
                                               
                                                        <asp:CommandField HeaderText="Select" ShowHeader="True" ShowSelectButton="True" />
                                                   
                                               
                                               
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
                                        <asp:HiddenField ID="lbl_balance" runat="server" />
                                        <asp:HiddenField ID="lbl_id" runat="server" />
                                        <asp:HiddenField ID="lbl_date" runat="server" />
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
                                                        <th>Shipping:</th>
                                                        <td>
                                                            <asp:TextBox ID="Txt_shipping" onkeyup="final_total();" onchange="final_total();" class="form-control" runat="server"  TextMode="Number"  min="0"></asp:TextBox></td>
                                                    </tr>
                                                    <tr>
                                                        <th>Adjustment:</th>
                                                        <td>
                                                            <asp:TextBox ID="Txt_adjustment" onkeyup="final_total();" onchange="final_total();"  class="form-control" runat="server" TextMode="Number"  min="0"></asp:TextBox></td>
                                                    </tr>
                                                    <tr>
                                                        <th>Discount:</th>
                                                        <td>
                                                            <asp:TextBox ID="Txt_discount" onkeyup="final_total();" onchange="final_total();"  class="form-control" runat="server" TextMode="Number"  min="0"></asp:TextBox></td>
                                                    </tr>
                                                    <tr>
                                                        <th>Total:</th>
                                                        <td class="grand_total">₹ <asp:Label ID="lbl_total" runat="server" Text=""></asp:Label></td>
                                                        
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
                                    <div class="col-lg-10 py-2 ml-5">
                                        <asp:Label ID="Lbl_message"  runat="server" Text=""></asp:Label>
                                        
                                        <asp:Button ID="Btn_generate_pdf" OnClientClick="return JSFunctionValidate();" class="btn btn-primary pull-right" Style="margin-right: 5px;" runat="server" Text="Update Invoice" OnClick="Btn_generate_pdf_Click" />
                                        

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



     <script type="text/javascript">
          function sqrft()
    {
        var first = document.getElementById('<%= txt_height.ClientID %>');
             var second = document.getElementById('<%= txt_width.ClientID %>');
             var sqrft = document.getElementById('<%= txt_sqrft.ClientID %>');
             if (first == null)
             {
                 first = 0;
             }
             if (second == null) {
                 second = 0;
             }
             if (sqrft == null) {
                 sqrft = 0;
             }
             var sqrft_total = (parseFloat(first.value) * parseFloat(second.value));

             sqrft.value = sqrft_total;

         }

        function rate() {
            var rates = document.getElementById('<%=txt_rate.ClientID %>');
            var sqrft= document.getElementById('<%=txt_sqrft.ClientID %>');
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
            //var amt = document.getElementById('<%=txt_amount.ClientID %>');
            var rate = document.getElementById('<%=txt_rate.ClientID %>');
            var quantity = document.getElementById('<%=txt_quantity.ClientID %>');
           var total = document.getElementById('<%=txt_total_amt.ClientID %>');
            //if (amt == null) {
            //    amt = 0;
            //}
            if (rate == null) {
                rate = 0;
            }
            if (quantity == null) {
                quantity = 0;
            }
            if (total == null) {
                total = 0;
            }
            var total_amount = (parseFloat(rate.value) * parseFloat(quantity.value))

            total.value = total_amount;

        }
        function quan_amount2() {

            var rate = document.getElementById('<%=txt_rate2.ClientID %>');
            var quantity = document.getElementById('<%=txt_quantity2.ClientID %>');
           var total = document.getElementById('<%=txt_total_amt2.ClientID %>');
            if (rate == null) {
                rate = 0;
            }
            if (quantity == null) {
                quantity = 0;
            }
            if (total == null) {
                total = 0;
            }
            var total_amount = (parseFloat(rate.value) * parseFloat(quantity.value))

            total.value = total_amount;

        }

          function gst() {
            var cgst = document.getElementById('<%= txt_cgst.ClientID %>');
            var sgst = document.getElementById('<%= txt_sgst.ClientID %>');
            var igst = document.getElementById('<%= txt_igst.ClientID %>');
              var total;
              if (document.getElementById('<%= txt_total_amt.ClientID %>') == null)
              {
                  total = document.getElementById('<%= txt_total_amt2.ClientID %>');
              }
              else if (document.getElementById('<%= txt_total_amt2.ClientID %>') == null)
              {
                  total = document.getElementById('<%= txt_total_amt.ClientID %>');
              }
              else {
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
                 
            // var amt = total.value + rcgst.value + rsgst.value + rigst.value;
            var amt = parseFloat(rcgst) + parseFloat(rsgst) + parseFloat(rigst) + parseFloat(total_amount);
                  var amount = document.getElementById('<%= txt_final_amt.ClientID %>');
                  amount.value = amt;
          }
         function gst2() {
            var cgst = document.getElementById('<%= txt_cgst.ClientID %>');
            var sgst = document.getElementById('<%= txt_sgst.ClientID %>');
            var igst = document.getElementById('<%= txt_igst.ClientID %>');
            var total = document.getElementById('<%= txt_total_amt2.ClientID %>');
             if (cgst == null) {
                 cgst = 0;
             }
             if (sgst == null) {
                 sgst = 0;
             }
             if (igst == null) {
                 igst = 0;
             }
             if (total == null) {
                 total = 0;
             }
            var total_amount = total.value;

            var rcgst = total_amount * cgst.value / 100;
            var rsgst = total_amount * sgst.value / 100;
            var rigst = total_amount * igst.value / 100;
                 
            // var amt = total.value + rcgst.value + rsgst.value + rigst.value;
            var amt = parseFloat(rcgst) + parseFloat(rsgst) + parseFloat(rigst) + parseFloat(total_amount);
                  var amount = document.getElementById('<%= txt_final_amt.ClientID %>');
                  amount.value = amt;
          }


        function final_total() {
            var subtotal = document.getElementById('<%=lbl_subtotal2.ClientID %>');
          
            var ship = document.getElementById('<%=Txt_shipping.ClientID %>');
            var adjustment = document.getElementById('<%=Txt_adjustment.ClientID %>');
            var discount = document.getElementById('<%=Txt_discount.ClientID %>');

            var hideamount = (parseFloat(subtotal.value) + parseFloat(ship.value));
         
            var total_amount = ((parseFloat(subtotal.value) + parseFloat(ship.value) - parseFloat(adjustment.value)) - parseFloat(discount.value));

           
            document.getElementById('<%=lbl_total.ClientID %>').innerHTML = total_amount;
            document.getElementById('<%=hide_total.ClientID %>').value = hideamount;
        }

     </script>
     <script>
         function JSFunctionValidate() {


             if (document.getElementById('<%=Dd_customer.ClientID%>').selectedIndex == 0) {
        alert("Please Select  Vendor !!!");
        return false;
    }
    if (document.getElementById('<%=Txt_order_no.ClientID%>').value.length == 0) {
        alert("Please Enter Order no. !!!");
        return false;
    }
    if (document.getElementById('<%=Txt_invoice_date.ClientID%>').value.length == 0) {
        alert("Please Select Invoice Date !!!");
        return false;
    }
    if (document.getElementById('<%=Txt_due_date.ClientID%>').value.length==0)
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
    if(document.getElementById('<%=Txt_discount.ClientID%>').value.length == 0) {
                 alert("Please Enter Discount !!!");
                 return false;
             }


             preventMultipleSubmissions();

             return true;
         }

         function JSFunctionValidate4() {

             var quant2 = document.getElementById('<%=txt_quantity2.ClientID %>');
              var quant = document.getElementById('<%=txt_quantity.ClientID %>');

              var height2 = document.getElementById('<%=txt_height2.ClientID %>');

              var width2 = document.getElementById('<%=txt_width2.ClientID %>');
            <%--if (document.getElementById('<%=txt_height.ClientID%>').value == "0") {
                alert("Height should not be 0  !!!");
                return false;
            }
            if (document.getElementById('<%=txt_width.ClientID%>').value == "0") {
                alert("Length should  not be 0 !!!");
                return false;
            }
            if (document.getElementById('<%=txt_height2.ClientID%>').value == "0") {
                alert("Height should not be 0  !!!");
                return false;
            }
            if (document.getElementById('<%=txt_width2.ClientID%>').value == "0") {
                alert("Length should  not be 0 !!!");
                return false;
            }--%>



            //if (height2 != null) {
            //    if (height2.value == "0") {
            //        alert("Height Should NOT BE 0 !!!");
            //        return false;
            //    }
            //}

            //if (width2 != null) {
            //    if (height2.value == "0") {
            //        alert("Length should  not be 0 !!!");
            //        return false;
            //    }
            //}
            if (document.getElementById('<%=Dd_customer.ClientID%>').value == "--Select--") {
                alert("Please Select Vendor !!!");
                return false;
            }
              if (document.getElementById('<%=Dd_enter_product.ClientID%>').value == "--Select--") {
                  alert("Please Select Product !!!");
                  return false;
              }

              if (quant2 != null) {
                  if (quant2.value == "0") {
                      alert("Please Enter Quantity !!!");
                      return false;
                  }
              }
              if (quant != null) {
                  if (quant.value == "0") {
                      alert("Please Enter Quantity !!!");
                      return false;
                  }
              }



              return true;
          }
     </script>


</asp:Content>

