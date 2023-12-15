<%@ Page Title="" Language="C#" MasterPageFile="~/Quotation/Quotation.master" AutoEventWireup="true" CodeFile="edit_wgst_quat.aspx.cs" Inherits="Quotation_edit_wgst_quat" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <!-- Content Wrapper. Contains page content -->
    <div class="content-wrapper">
        <!-- Content Header (Page header) -->
        <section class="content-header sty-one">
            <h1>Quotation</h1>
            <ol class="breadcrumb">
                <li><a href="#">Quotation</a></li>
                <li><i class="fa fa-angle-right"></i>Edit Quotation</li>
            </ol>
        </section>
        <!-- Main content -->

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
                                        <h3 class="text-black">QUOTATION <span class="pull-right"></span> </h3>
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
                                    <label class="control-label text-right col-md-3">Quotation#</label>
                                    <div class="col-md-6">
                                        <asp:TextBox ID="Txt_invoice" disabled="true" class="form-control" runat="server"></asp:TextBox>
                                    </div>
                                </div>
                               
                                <div class="form-group row">
                                    <label class="control-label text-right col-md-3">Invoice Date</label>
                                    <div class="col-md-3">
                                        <asp:TextBox ID="Txt_invoice_date" class="form-control" runat="server" TextMode="SingleLine"></asp:TextBox>
                                    </div>
                                    <label class="control-label text-right col-md-3">Due Date</label>
                                    <div class="col-md-3">
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
                                    <asp:Panel ID="Panel1" runat="server">
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
                                                <asp:TextBox ID="txt_amount" class="form-control" runat="server" TextMode="Number"></asp:TextBox></td>
                                            <td>
                                                <asp:TextBox ID="txt_quantity" OnkeyUp="sqrft(); rate();quan_amount(); gst();" onchange="sqrft(); rate();quan_amount(); gst();" class="form-control" runat="server" TextMode="Number"></asp:TextBox></td>
                                            <td>
                                                <asp:TextBox ID="txt_total_amt" onkeyup="gst();" onchange="gst();" class="form-control" runat="server" TextMode="Number"></asp:TextBox></td>
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
                                    </asp:Panel>
                                </table>
                                
                                <table class="table">
                                    <thead>
                                        <tr>

                                           <th scope="col"></th>
                                            <th scope="col"></th>
                                            <th scope="col"></th>
                                            <th scope="col"></th>
                                           <th scope="col" style="text-align:right;"><asp:LinkButton ID="Btn_cart" Style="margin-right: 5px;" OnClick="Btn_cart_Click" runat="server"><i style="padding-left:10px; font-size:40px;" class="fa fa-plus-circle"></i></asp:LinkButton></th>
                                        </tr>
                                    </thead>
                                    
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
                                        <p class="lead">Payment Methods:</p>
                                        <img src="../dist/img/mastercard.png" alt="Visa">
                                        <img src="../dist/img/mastercard.png" alt="Mastercard">
                                        <img src="../dist/img/american-express.png" alt="American Express">
                                        <img src="../dist/img/paypal2.png" alt="Paypal">
                                        <p class="text-muted well well-sm no-shadow" style="margin-top: 10px;">
                                           
                                        </p>
                                         
                                        <asp:HiddenField ID="lbl_product_hsn" runat="server" />
                                        <asp:HiddenField ID="lbl_unit" runat="server" />
                                         <asp:HiddenField ID="lbl_total_cgst" runat="server" />
                                        <asp:HiddenField ID="lbl_total_sgst" runat="server" />
                                        <asp:HiddenField ID="lbl_total_igst" runat="server" />
                                        <asp:HiddenField ID="lbl_total_taxable" runat="server" />
                                       
                                        <asp:HiddenField ID="lbl_id" runat="server" />
                                        <asp:HiddenField ID="lbl_date" runat="server" />
                                    </div>
                                    <!-- /.col -->
                                    <%--<div class="col-lg-6">
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
                                                        <th>Shipping:</th>
                                                        <td>
                                                            <asp:TextBox ID="Txt_shipping" onkeyup="final_total();" onchange="final_total();" class="form-control" runat="server"  TextMode="Number"></asp:TextBox></td>
                                                    </tr>
                                                    <tr>
                                                        <th>Advance:</th>
                                                        <td>
                                                            <asp:TextBox ID="Txt_advance"  onkeyup="final_total();" onchange="final_total();"  class="form-control" runat="server" TextMode="Number"></asp:TextBox></td>
                                                    </tr>
                                                    <tr>
                                                        <th>Discount:</th>
                                                        <td>
                                                            <asp:TextBox ID="Txt_discount" onkeyup="final_total();" onchange="final_total();" class="form-control" runat="server" TextMode="Number"></asp:TextBox></td>
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
                                    </div>--%>
                                    <!-- /.col -->

                                             <table class="table">
                                    <thead>
                                        <tr>

                                           
                                            <th scope="col"> <asp:CheckBox ID="CheckBox1" runat="server" />Design charges:</th>
                                           
                                            <th scope="col">Pasting <asp:CheckBox ID="CheckBox2" runat="server" />  Framing <asp:CheckBox ID="CheckBox7" runat="server" /> Charges:</th>

                                            

                                            <th scope="col">Fitting <asp:CheckBox ID="CheckBox4" runat="server" /> Installation <asp:CheckBox ID="CheckBox5" runat="server" /> Charges:</th>

                                            
                                           <%-- <th scope="col">Advance:</th>
                                            <th scope="col">Discount:</th>--%>
                                           
                                        </tr>
                                    </thead>
                                    <tbody>
                                        <tr>

                                            
                                            <td>
                                                <asp:TextBox ID="Txt_Dtp_charges" onkeyup="final_total();" class="form-control" runat="server" TabIndex="21" disabled="true"></asp:TextBox></td>
                                            <td>
                                                <asp:TextBox ID="Txt_Pasting" onkeyup="final_total();" class="form-control" runat="server" TabIndex="22" disabled="true"></asp:TextBox></td>
                                             <td>
                                                <asp:TextBox ID="Txt_Fitting" onkeyup="final_total();" class="form-control" runat="server" TabIndex="22" disabled="true"></asp:TextBox></td>
                                             
                                             
                                            <%--<td>
                                                 <asp:TextBox ID="Txt_advance" onkeyup="final_total();" onchange="final_total();" class="form-control" runat="server" TextMode="Number" TabIndex="24"></asp:TextBox>
                                                 <asp:RequiredFieldValidator ID="RequiredFieldValidatorAdvance" runat="server" ErrorMessage="Please Enter Advance.." ControlToValidate="Txt_advance" Display="Dynamic" ValidationGroup="g1"></asp:RequiredFieldValidator></td>
                                            <td>
                                                <asp:TextBox ID="Txt_discount" onkeyup="final_total();" onchange="final_total();" class="form-control" runat="server" TextMode="Number" TabIndex="25"></asp:TextBox>
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidatorDiscount" runat="server" ErrorMessage="Please Enter Discount.." ControlToValidate="Txt_discount" Display="Dynamic" ValidationGroup="g1"></asp:RequiredFieldValidator></td>--%>
                                            
                                           
                                        </tr>

                                    </tbody>
                                </table>

                                        <table class="table">
                                    <thead>
                                        <tr>
                                            
                                            <th scope="col">transport charges:</th>
                                            <th scope="col">Advance:</th>
                                            <th scope="col">Discount:</th>
                                            <th scope="col">Payment Method:</th>
                                            
                                             <%--<th scope="col">Subtotal:</th>
                                            <th scope="col">Total GST:</th>
                                            <th scope="col">Final Amount:</th>
                                           <th scope="col">Balance Amount:</th>--%>
                                          
                                           
                                        </tr>
                                    </thead>
                                    <tbody>
                                        <tr>

                                            <%--<td>
                                                ₹ <asp:Label ID="lbl_subtotal" runat="server" Text=""></asp:Label></td>
                                                 <asp:HiddenField ID="lbl_subtotal2" runat="server" />
                                            <td>
                                               ₹ <asp:Label ID="lbl_gst" runat="server" Text=""></asp:Label></td>
                                            <td class="grand_total">₹ <asp:Label ID="lbl_final" runat="server" Text=""></asp:Label></td>
                                            
                                            <td class="grand_total">₹ <asp:Label ID="lbl_total" runat="server" Text=""></asp:Label></td>--%>
                                           
                                           
                                            <td>
                                                 <asp:TextBox ID="Txt_TransportCharges" onkeyup="final_total();" class="form-control" runat="server" TabIndex="23" disabled="true"></asp:TextBox></td>
                                            <td>
                                           <asp:TextBox ID="Txt_advance" onkeyup="final_total();" onchange="final_total();" class="form-control" runat="server" TextMode="Number" TabIndex="24" disabled="true"></asp:TextBox>
                                                 <asp:RequiredFieldValidator ID="RequiredFieldValidatorAdvance" runat="server" ErrorMessage="Please Enter Advance.." ControlToValidate="Txt_advance" Display="Dynamic" ValidationGroup="g1"></asp:RequiredFieldValidator>
                                           </td>

                                            <td>
                                                <asp:TextBox ID="Txt_discount" onkeyup="final_total();" onchange="final_total();" class="form-control" runat="server" TextMode="Number" TabIndex="25"></asp:TextBox>
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidatorDiscount" runat="server" ErrorMessage="Please Enter Discount.." ControlToValidate="Txt_discount" Display="Dynamic" ValidationGroup="g1"></asp:RequiredFieldValidator></td>
                                            <td>
                                                <asp:DropDownList ID="drp_payment"  class="form-control"  runat="server" TabIndex="26" disabled="true">

                                                                <asp:ListItem Selected="True">Cash</asp:ListItem>
                                                                <asp:ListItem>Credit</asp:ListItem>
                                                                <asp:ListItem>Cheque</asp:ListItem>
                                                                <asp:ListItem>Paytm</asp:ListItem>
                                                                <asp:ListItem>Google Pay</asp:ListItem>
                                                                <asp:ListItem>Phone Pay</asp:ListItem>
                                                            </asp:DropDownList>

                                            </td>
                                            
                                            <%-- <td>
                                                <asp:TextBox Class="Txt_hide" ID="hide_total" runat="server"></asp:TextBox></td></td>
                                            <td>--%>
                                           
                                           
                                        </tr>

                                    </tbody>
                                </table>

                                               <table class="table">
                                    <thead>
                                        <tr>
                                            
                                            <th scope="col">Subtotal:</th>
                                            <%--<th scope="col">Total GST:</th>--%>
                                            <th scope="col">Final Amount:</th>
                                           <th scope="col">Balance Amount:</th>
                                            
                                           
                                        </tr>
                                    </thead>
                                    <tbody>

                                        <tr>
                                          <td>
                                                ₹ <asp:Label ID="lbl_subtotal" runat="server" Text=""></asp:Label></td>
                                                 <asp:HiddenField ID="lbl_subtotal2" runat="server" />
                                           <%-- <td>
                                               ₹ <asp:Label ID="lbl_gst" runat="server" Text=""></asp:Label></td>--%>
                                            <td class="grand_total">₹ <asp:Label ID="lbl_final" runat="server" Text=""></asp:Label></td>
                                            
                                            <td class="grand_total">₹ <asp:Label ID="lbl_total" runat="server" Text=""></asp:Label></td>
                                            <td>
                                                <asp:TextBox Class="Txt_hide" ID="hide_total" runat="server"></asp:TextBox></td></td>
                                            
                                      </tr>

                                    </tbody>
                                </table>

                                </div>
                                <!-- /.row -->

                                <!-- this row will not appear when printing -->
                                <div class="row no-print">
                                    <div class="col-lg-12">
                                        <asp:Label ID="Lbl_message"  runat="server" Text=""></asp:Label>
                                        
                                       <asp:Button ID="Btn_generate_pdf" class="btn btn-primary pull-right" Style="margin-right: 5px;" runat="server" Text="Update Invoice" OnClick="Btn_generate_pdf_Click" />
                                        

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
        <div class="pull-right hidden-xs">Version 1.00</div>
        Copyright © 2018 PrintSoft. All rights reserved.
    </footer>
    



 <style>
        .Txt_hide{
            display:none;
        }
</style>

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

         
         

        function final_total() {
            var subtotal = document.getElementById('<%=lbl_subtotal2.ClientID %>');
          
           
            var discount = document.getElementById('<%=Txt_discount.ClientID %>');
           
            var dtpcharges = document.getElementById('<%=Txt_Dtp_charges.ClientID %>');
            var dtp_value = parseFloat(dtpcharges.value);

            var transport_charges = document.getElementById('<%=Txt_TransportCharges.ClientID %>');
            var transport_value = parseFloat(transport_charges.value);

            var total_dtp_transport = (parseFloat(transport_value) + parseFloat(dtp_value));

            var advance = document.getElementById('<%=Txt_advance.ClientID %>');

            var fitting = document.getElementById('<%=Txt_Fitting.ClientID%>')

            var pasting = document.getElementById('<%=Txt_Pasting.ClientID%>')

            var total_amount = (parseFloat(subtotal.value) + parseFloat(total_dtp_transport) + parseFloat(fitting.value) + parseFloat(pasting.value));

            var balance = (parseFloat(total_amount) - parseFloat(advance.value) - parseFloat(discount.value));
            var roundoff = Math.round(balance);

            document.getElementById('<%=lbl_total.ClientID %>').innerHTML = roundoff;
            document.getElementById('<%=hide_total.ClientID %>').value = total_amount;
            document.getElementById('<%=lbl_final.ClientID %>').innerHTML = roundoff;
        }

    </script>
</asp:Content>

