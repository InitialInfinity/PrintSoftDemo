<%@ Page Title="" Language="C#" MasterPageFile="~/Roll Purchase/RollPurchase.master" AutoEventWireup="true" CodeFile="edit_roll_bill.aspx.cs" Inherits="Purchase_edit_roll_bill" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">

    <style>
        .Txt_hide {
            display: none;
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
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <!-- Content Wrapper. Contains page content -->
    <div class="content-wrapper">
        <!-- Content Header (Page header) -->
        <section class="content-header sty-one">
            <h1>Roll Purchase Invoice</h1>
            <ol class="breadcrumb">
                <li><a href="#">Purchase</a></li>
                <li><i class="fa fa-angle-right"></i>Roll Purchase Invoice</li>
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
                                        <h3 class="text-black">INVOICE <span class="pull-right"></span></h3>
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
                                        <asp:Label ID="Label1" runat="server" >Product<span style="color:red;">*</span></asp:Label>
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
                                        <asp:TextBox ID="Txt_description" Rows="2" class="form-control" runat="server" TextMode="MultiLine"></asp:TextBox>
                                    </div>


                                </div>

                                <div class="form-group row">

                                    <div class="col-md-3">
                                    </div>

                                </div>

                                <table class="table">
                                    <thead>
                                        <tr>

                                            <th scope="col">Height (Feet)
                                               </th>
                                            <th scope="col">Roll Height (Mtr)</th>
                                            <th scope="col">Roll Size (Mtr)<span style="color:red;">*</span></th>
                                            <th scope="col">Total Size (Mtr)</th>
                                        </tr>
                                    </thead>
                                    <tbody>
                                        <tr>

                                            <td>
                                                <asp:DropDownList ID="Dd_feet" class="form-control" runat="server" onchange="feet();"></asp:DropDownList></td>
                                            <td>
                                                <asp:TextBox ID="Txt_roll_height" onkeydown="javascript:return false" class="form-control" runat="server" ></asp:TextBox></td>
                                            <td>
                                                <asp:TextBox ID="Txt_roll_size" class="form-control" onkeyup="totalroll();totalsqft();rate();"  TextMode="Number" min="0" onchange="totalroll();totalsqft();rate();" runat="server" ></asp:TextBox></td>
                                            <td>
                                                <asp:TextBox ID="Txt_total_roll" class="form-control" runat="server" onkeydown="javascript:return false" ></asp:TextBox></td>
                                        </tr>
                                    </tbody>
                                </table>
                                <table class="table">
                                    <thead>
                                        <tr>

                                            <th scope="col">Total Sq.ft</th>
                                            <th scope="col">Rate</th>
                                            <th scope="col">Amount</th>
                                            <th scope="col">Quantity<span style="color:red;">*</span></th>
                                            <th scope="col">Total</th>
                                        </tr>
                                    </thead>
                                    <tbody>
                                        <tr>

                                            <td>
                                                <asp:TextBox ID="Txt_total_roll_sq" class="form-control" runat="server" onkeydown="javascript:return false"></asp:TextBox></td>
                                            <td>
                                                <asp:TextBox ID="Txt_rate" class="form-control" onkeydown="javascript:return false" runat="server" ></asp:TextBox></td>
                                            <td>
                                                <asp:TextBox ID="txt_amount" onkeydown="javascript:return false" class="form-control" runat="server" ></asp:TextBox></td>
                                            <td>
                                                <asp:TextBox ID="txt_quantity" class="form-control" onkeyup="quan_amount();gst();" onchange="quan_amount();gst();" runat="server" TextMode="Number" min="0"></asp:TextBox></td>
                                            <td>
                                                <asp:TextBox ID="txt_total_amt" onkeydown="javascript:return false" class="form-control" runat="server" ></asp:TextBox></td>
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
                                                <asp:TextBox ID="txt_cgst" class="form-control" OnkeyUp="quan_amount2(); sqrft(); rate(); quan_amount(); gst(); " onchange="quan_amount2(); sqrft(); rate(); quan_amount(); gst();" runat="server" TextMode="Number"></asp:TextBox></td>
                                            <td>
                                                <asp:TextBox ID="txt_sgst" class="form-control" OnkeyUp="quan_amount2(); sqrft(); rate(); quan_amount(); gst(); " onchange="quan_amount2(); sqrft(); rate(); quan_amount(); gst();" runat="server" TextMode="Number"></asp:TextBox></td>
                                            <td>
                                                <asp:TextBox ID="txt_igst" class="form-control" OnkeyUp="quan_amount2(); sqrft(); rate(); quan_amount(); gst(); " onchange="quan_amount2(); sqrft(); rate(); quan_amount(); gst();" runat="server" TextMode="Number"></asp:TextBox></td>
                                            <td>
                                                <asp:TextBox ID="txt_final_amt" onkeydown="javascript:return false" class="form-control" runat="server"></asp:TextBox></td>
                                            <td>
                                                <asp:Button ID="Btn_cart" class="btn btn-primary pull-right" Style="margin-right: 5px;" runat="server" Text="Add to Cart" OnClientClick="return JSFunctionValidate4();" OnClick="Btn_cart_Click" /></td>

                                        </tr>

                                    </tbody>
                                </table>
                                <div class="row">
                                    <div class="col-md-4">
                                        <asp:Button ID="Button3" class="btn btn-primary" Style="margin-right: 5px; background-color: gray !important;" runat="server" Text="Cancel" OnClick="Button3_Click" />
                                    </div>

                                    <div class="col-md-4">
                                        <asp:Button ID="Button2" class="btn btn-primary" Style="margin-right: 5px; background-color: red !important;" runat="server" Text="Delete Entry" OnClick="Button2_Click" />
                                    </div>
                                    <div class="col-md-4">
                                        <asp:Button ID="Button1" class="btn btn-primary" Style="margin-right: 5px; background-color: green !important;" runat="server" Text="Edit / Update" OnClientClick="return JSFunctionValidate4();" OnClick="Button1_Click" />
                                    </div>
                                </div>
                                <br />
                                <div class="row ">
                                    <div class="col-xs-12 table-responsive">
                                        <asp:GridView ID="GridView1" class="table table-striped" runat="server" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3" OnDataBound="GridView1_DataBound" OnRowDataBound="GridView1_RowDataBound" OnPageIndexChanging="GridView1_PageIndexChanging" OnRowDeleting="GridView1_RowDeleting" OnRowCreated="GridView1_RowCreated" OnRowCommand="GridView1_RowCommand" OnSelectedIndexChanged="GridView1_SelectedIndexChanged">

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
                                        <p class="lead">Total Qty:
                                            <asp:Label ID="lbl_totalqty" runat="server" Text=""></asp:Label></p>
                                        <p class="lead">Payment Methods:</p>
                                        <img src="../dist/img/mastercard.png" alt="Visa">
                                        <img src="../dist/img/mastercard.png" alt="Mastercard">
                                        <img src="../dist/img/american-express.png" alt="American Express">
                                        <img src="../dist/img/paypal2.png" alt="Paypal">
                                        <p class="text-muted well well-sm no-shadow" style="margin-top: 10px;">
                                        </p>
                                        <asp:HiddenField ID="lbl_cutomer_contact" runat="server" />
                                        <asp:HiddenField ID="lbl_cutomer_address" runat="server" />
                                        <asp:HiddenField ID="lbl_cutomer_gst_no" runat="server" />
                                        <asp:HiddenField ID="lbl_cutomer_email" runat="server" />
                                        <asp:HiddenField ID="lbl_opening_balance" runat="server" />
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
                                                        <td>₹
                                                            <asp:Label ID="lbl_subtotal" runat="server" Text=""></asp:Label></td>
                                                        <asp:HiddenField ID="lbl_subtotal2" runat="server" />
                                                    </tr>
                                                    <tr>
                                                        <th>Total GST</th>
                                                        <td>₹
                                                            <asp:Label ID="lbl_gst" runat="server" Text=""></asp:Label></td>

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
                                                        <th>Shipping:</th>
                                                        <td>
                                                            <asp:TextBox ID="Txt_shipping" onkeyup="final_total();" onchange="final_total();" class="form-control" runat="server" TextMode="Number"></asp:TextBox></td>
                                                    </tr>
                                                    <tr>
                                                        <th>Adjustment:</th>
                                                        <td>
                                                            <asp:TextBox ID="Txt_adjustment" onkeyup="final_total();" onchange="final_total();" class="form-control" runat="server" TextMode="Number"></asp:TextBox></td>
                                                    </tr>
                                                    <tr>
                                                        <th>Discount:</th>
                                                        <td>
                                                            <asp:TextBox ID="Txt_discount" onkeyup="final_total();" onchange="final_total();" class="form-control" runat="server" TextMode="Number"></asp:TextBox></td>
                                                    </tr>
                                                    <tr>
                                                        <th>Total:</th>
                                                        <td class="grand_total">₹
                                                            <asp:Label ID="lbl_total" runat="server" Text=""></asp:Label></td>

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
                                        <asp:Label ID="Lbl_message" runat="server" Text=""></asp:Label>

                                        <asp:Button ID="Btn_generate_pdf" class="btn btn-primary pull-right" Style="margin-right: 5px;" OnClientClick="return JSFunctionValidate();" runat="server" Text="Update Invoice" OnClick="Btn_generate_pdf_Click" />


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
        Copyright © 2018 PrintSoft. All rights reserved.
    </footer>


    <script type="text/javascript">
        function feet() {
            var feet = document.getElementById('<%= Dd_feet.ClientID %>');
                      var height = document.getElementById('<%= Txt_roll_height.ClientID %>');
            if (feet == null) {
                feet = 0;
            }
            if (height == null) {
                height = 0;
            }

            var sqrft_total = (parseFloat(feet.value) / 39.37);

            height.value = sqrft_total.toFixed(4);

        }
        function totalroll() {
            var height = document.getElementById('<%= Txt_roll_height.ClientID %>');
               var rollsize = document.getElementById('<%= Txt_roll_size.ClientID %>');
               var totalroll = document.getElementById('<%= Txt_total_roll.ClientID %>');
            if (height == null) {
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

        function totalsqft() {
            var sqmtr = document.getElementById('<%= Txt_total_roll.ClientID %>');
              var sqft = document.getElementById('<%= Txt_total_roll_sq.ClientID %>');
            if (sqmtr == null) {
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
            var sqrft = document.getElementById('<%=Txt_total_roll_sq.ClientID %>');
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
              if (total == null) {

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

            var hideamount = (parseFloat(subtotal.value) + parseFloat(ship.value));
                var total_amount = ((parseFloat(subtotal.value) + parseFloat(ship.value) - parseFloat(adjustment.value)) - parseFloat(discount.value));

                document.getElementById('<%=lbl_total.ClientID %>').innerHTML = total_amount;
            document.getElementById('<%=hide_total.ClientID %>').value = hideamount;
            

            


           
        }

    </script>
    <script>
        function JSFunctionValidate4() {


            var quant = document.getElementById('<%=txt_quantity.ClientID %>');
             var rollheight = document.getElementById('<%=Txt_roll_height.ClientID %>');
             var rollsize = document.getElementById('<%=Txt_roll_size.ClientID %>');

           <%-- if (document.getElementById('<%=Dd_enter_product.ClientID%>').value == "--Select--") {
                alert("Please Select Product !!!");
                return false;
            }

             if (document.getElementById('<%=Dd_feet.ClientID%>').value == "--Select--") {
                alert("Please Select Roll Feet !!!");
                return false;
            }--%>

            //if (rollheight != null) {
            //    if (rollheight.value == "0") {
            //        alert("Please Enter Roll Length !!!");
            //        return false;
            //    }
            //}
            if (rollsize != null) {
                if (rollsize.value == "0") {
                    alert("Please Enter Roll Size !!!");
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
        function JSFunctionValidate() {

            <%-- if (document.getElementById('<%=Txt_shipping.ClientID%>').value.length == 0) {
                 alert("Please Enter Shipping Charges !!!");
                 return false;
             }--%>
            if (document.getElementById('<%=Txt_invoice_date.ClientID%>').value.length == 0) {
                alert("Please Select Invoice Date !!!");
                return false;
            }
            if (document.getElementById('<%=Txt_due_date.ClientID%>').value.length == 0) {
                alert("Please Select Due Date !!!");
                return false;
            }
            if (document.getElementById('<%=Txt_shipping.ClientID%>').value.length == 0) {
                alert("Please Enter Transport Charges !!!");
                return false;
            }
             if (document.getElementById('<%=Txt_adjustment.ClientID%>').value.length == 0) {
                 alert("Please Enter Advance Amount !!!");
                 return false;
             }
             if (document.getElementById('<%=Txt_discount.ClientID%>').value.length == 0) {
                 alert("Please Enter Discount Amount !!!");
                return false;
            }


            preventMultipleSubmissions();

            return true;
        }
    </script>

</asp:Content>


