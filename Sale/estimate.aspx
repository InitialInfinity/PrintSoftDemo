<%@ Page Title="" Language="C#" MasterPageFile="~/Sale/Sale.master" AutoEventWireup="true" CodeFile="estimate.aspx.cs" Inherits="Sale_estimate" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link href="../dist/css/select2.css" rel="stylesheet" />
    <script src="../dist/js/select2.js"></script>


    <script type="text/javascript">

        $(document).ready(function () {

            call();
            Product();

        });


        function call() {

            $("#<%=Dd_customer.ClientID%>").select2({

                placeholder: "Select Item",

                allowClear: true

            });

        }

        function Product() {

            $("#<%=Dd_enter_product.ClientID%>").select2({

                placeholder: "Select Product",

                allowClear: true

            });


        }

    </script>

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

        function preventMultipleSubmissions1() {


            if (!isSubmitted) {

                $('#<%=Btn_submit_payment.ClientID %>').val('Submitting.. Plz Wait..');

                isSubmitted = true;

                return true;

            }
            else {

                return false;

            }

        }



    </script>
    <!--script to disable the submit button -->
    <%--<script src="https://ajax.googleapis.com/ajax/libs/jquery/1.7.2/jquery.min.js">  
</script>
<script type="text/javascript">

$(document).ready(function () {
    $(".submitBtn").click(function () {
        $(".submitBtn").attr("disabled", true);
        return true;
    });
});

</script>--%>
    <!--script ends here-->
    <%--<script type="text/javascript" src="//ajax.googleapis.com/ajax/libs/jquery/1.11.2/jquery.min.js"></script>--%>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <!-- Content Wrapper. Contains page content -->
    <div class="content-wrapper">
        <!-- Content Header (Page header) -->
        <section class="content-header sty-one">
            <h1>Estimate</h1>
            <ol class="breadcrumb">
                <li><a href="#">Sale</a></li>
                <li><i class="fa fa-angle-right"></i>Estimate</li>
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
                                        <h3 class="text-black">Estimate <span class="pull-right"></span></h3>
                                    </div>
                                    <!-- /.col -->
                                </div>
                                <!-- info row -->
                                <div class="customer_name row">
                                    <label class="control-label text-right col-md-3">Customer Name<span style="color: red;">*</span></label>
                                    <div class="col-md-6">

                                        <script>
                                            Sys.Application.add_load(call);
                                        </script>
                                        <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                            <ContentTemplate>
                                                <asp:DropDownList ID="Dd_customer" class="form-control" runat="server" OnSelectedIndexChanged="Dd_customer_SelectedIndexChanged" AutoPostBack="True" TabIndex="1"></asp:DropDownList>
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                    </div>



                                </div>
                                <div class="form-group row">
                                    <label class="control-label text-right col-md-3"></label>
                                    <div class="col-md-6">
                                        <asp:LinkButton ID="LinkButton1" data-toggle="modal" data-target="#myModal" class="col-md-4" runat="server">+Add Customer</asp:LinkButton>
                                    </div>



                                </div>
                                <div class="form-group row">
                                    <label class="control-label text-right col-md-3">Cash Memo#</label>
                                    <div class="col-md-6">
                                        <asp:TextBox ID="Txt_invoice" ReadOnly="true" class="form-control" runat="server" TabIndex="2"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="form-group row">
                                    <label class="control-label text-right col-md-3">Order Number</label>
                                    <div class="col-md-6">
                                        <asp:TextBox ID="Txt_order_no" disabled="true" class="form-control" runat="server" TabIndex="3"></asp:TextBox>
                                    </div>
                                </div>

                                <div class="form-group row">
                                    <label class="control-label text-right col-md-3">Designer# <span style="color: red;">*</span></label>
                                    <div class="col-md-6">

                                        <asp:DropDownList ID="drp_designer" class="form-control" runat="server" OnSelectedIndexChanged="drp_order_ref_SelectedIndexChanged" AutoPostBack="true" TabIndex="4"></asp:DropDownList>
                                        <%--    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="drp_designer" ForeColor="red" ErrorMessage="Select Designer!" InitialValue="--Show Designer--"></asp:RequiredFieldValidator>--%>
                                        <%--<h5>Amount :-<asp:Label ID="lbl_order_total" runat="server" Text=""></asp:Label> </h5>--%>
                                    </div>
                                </div>



                                <div class="form-group row">
                                    <label class="control-label text-right col-md-3">Invoice Date</label>
                                    <div class="col-md-2">
                                        <asp:TextBox ID="Txt_invoice_date" class="form-control" runat="server" TextMode="Date" TabIndex="5"></asp:TextBox>
                                    </div>
                                    <label class="control-label text-right col-md-1">Due Date</label>
                                    <div class="col-md-2">
                                        <asp:TextBox ID="Txt_due_date" class="form-control" runat="server" TextMode="Date" TabIndex="6"></asp:TextBox>
                                    </div>
                                </div>
                                <hr />

                                <div class="form-group row">

                                    <div class="col-md-4">
                                        <asp:Label ID="Label1" runat="server" Text="Product"></asp:Label><span style="color: red;">*</span>
                                    </div>

                                    <div class="col-md-4">
                                        <asp:Label ID="Label3" runat="server" Text="Material"></asp:Label><span style="color: red;">*</span>
                                    </div>

                                    <div class="col-md-4">
                                        <asp:Label ID="Label2" runat="server" Text="Description"></asp:Label>
                                    </div>


                                </div>


                                <div class="form-group row">

                                    <div class="col-md-4">
                                        <script>
                                            Sys.Application.add_load(Product);
                                        </script>
                                        <asp:DropDownList ID="Dd_enter_product" class="form-control" runat="server" AutoPostBack="True" OnSelectedIndexChanged="Dd_enter_product_SelectedIndexChanged"></asp:DropDownList>
                                        <%--  <asp:LinkButton ID="LinkButton2" Class="add_class" data-toggle="modal" data-target="#myModal2" runat="server">+Add Product</asp:LinkButton>--%>
                                    </div>

                                    <div class="col-md-4">
                                        <asp:DropDownList ID="Dd_material" class="form-control" runat="server" AutoPostBack="True" OnSelectedIndexChanged="Dd_material_SelectedIndexChanged"></asp:DropDownList>
                                        <%--   <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="Dd_material" ForeColor="red" ErrorMessage="Select Material " InitialValue="--Select--"></asp:RequiredFieldValidator>&nbsp;--%>
                                        Available : <b>
                                            <asp:Label ID="lbl_available" runat="server" Text=""></asp:Label></b>
                                    </div>

                                    <div class="col-md-4">
                                        <asp:TextBox ID="Txt_description" Rows="2" class="form-control" runat="server" TextMode="MultiLine"></asp:TextBox>
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

                                                <th scope="col">Length<span style="color: red;">*</span></th>
                                                <th scope="col">Height<span style="color: red;">*</span></th>
                                                <th scope="col">Size</th>
                                                <th scope="col">Rate</th>
                                                <th scope="col">Amount</th>
                                                <th scope="col">Quantity<span style="color: red;">*</span></th>
                                                <th scope="col">Total</th>
                                            </tr>
                                        </thead>
                                        <tbody>
                                            <tr>
                                                <td>
                                                    <asp:TextBox ID="txt_width" OnkeyUp="sqrft(); rate();quan_amount(); " onchange="sqrft(); rate(); quan_amount(); " class="form-control" runat="server" TextMode="Number" min="0" TabIndex="9"></asp:TextBox></td>
                                                <td>
                                                    <asp:TextBox ID="txt_height" OnkeyUp=" sqrft(); rate();quan_amount();" onchange="sqrft(); rate(); quan_amount(); " class="form-control" runat="server" TextMode="Number" min="0" TabIndex="10"></asp:TextBox></td>
                                                <td>
                                                    <asp:TextBox ID="txt_sqrft" onkeydown="javascript:return false" OnkeyUp="sqrft(); rate(); quan_amount(); " onchange="sqrft(); rate(); quan_amount(); " class="form-control" runat="server" TextMode="Number" TabIndex="11"></asp:TextBox></td>
                                                <td>
                                                    <asp:TextBox ID="txt_rate" Onkeyup="sqrft(); rate();quan_amount(); " onchange="sqrft(); rate();quan_amount(); " class="form-control" runat="server" TextMode="Number" TabIndex="12"></asp:TextBox></td>
                                                <td>
                                                    <asp:TextBox ID="txt_amount" onkeydown="javascript:return false" class="form-control" runat="server" TextMode="Number" TabIndex="13"></asp:TextBox></td>
                                                <td>
                                                    <asp:TextBox ID="txt_quantity" OnkeyUp="sqrft(); rate();quan_amount();" onchange="sqrft(); rate(); quan_amount(); " class="form-control" runat="server" TextMode="Number" min="0" TabIndex="14"></asp:TextBox></td>
                                                <td>
                                                    <asp:TextBox ID="txt_total_amt" onkeydown="javascript:return false" onchange=" " class="form-control" runat="server" TextMode="Number" TabIndex="15"></asp:TextBox></td>
                                            </tr>

                                        </tbody>
                                    </asp:Panel>
                                    <asp:Panel ID="Panel2" runat="server">
                                        <thead>
                                            <tr>

                                                <th scope="col">Height<span style="color: red;">*</span></th>
                                                <th scope="col">Length<span style="color: red;">*</span></th>
                                                <th scope="col">Size</th>
                                                <th scope="col">Rate</th>
                                                <th scope="col">Amount</th>
                                                <th scope="col">Quantity<span style="color: red;">*</span></th>
                                                <th scope="col">Total</th>
                                            </tr>
                                        </thead>
                                        <tbody>
                                            <tr>

                                                <td>
                                                    <asp:TextBox ID="txt_height2" disabled="true" class="form-control" runat="server" TextMode="Number" min="0"></asp:TextBox></td>
                                                <td>
                                                    <asp:TextBox ID="txt_width2" disabled="true" class="form-control" runat="server" TextMode="Number" min="0"></asp:TextBox></td>
                                                <td>
                                                    <asp:TextBox ID="txt_sqrft2" onkeydown="javascript:return false" disabled="true" class="form-control" runat="server" TextMode="Number"></asp:TextBox></td>
                                                <td>
                                                    <asp:TextBox ID="txt_rate2" Onkeyup="quan_amount2(); gst2();" onchange="quan_amount2(); gst2();" class="form-control" runat="server" TextMode="Number"></asp:TextBox></td>
                                                <td>
                                                    <asp:TextBox ID="txt_amount2" onkeydown="javascript:return false" disabled="true" class="form-control" runat="server" TextMode="Number"></asp:TextBox></td>
                                                <td>
                                                    <asp:TextBox ID="txt_quantity2" OnkeyUp="quan_amount2(); gst2();" onchange="quan_amount2(); gst2();" class="form-control" runat="server" min="0" TextMode="Number"></asp:TextBox></td>
                                                <td>
                                                    <asp:TextBox ID="txt_total_amt2" onkeydown="javascript:return false" onkeyup="gst2();" onchange="gst2();" class="form-control" runat="server" TextMode="Number"></asp:TextBox></td>
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
                                            <th scope="col" style="text-align: right;">
                                                <asp:LinkButton ID="Btn_cart" Style="margin-right: 5px;" OnClientClick="return JSFunctionValidate5();" OnClick="Btn_cart_Click" runat="server"><i style="padding-left:10px; font-size:40px;" class="fa fa-plus-circle" tabindex="15"></i></asp:LinkButton>
                                            </th>

                                        </tr>
                                    </thead>

                                </table>

                                <div class="row ">
                                    <div class="col-xs-12 table-responsive">
                                        <asp:GridView ID="GridView1" class="table table-striped" runat="server" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3" OnDataBound="GridView1_DataBound" OnRowDataBound="GridView1_RowDataBound" OnRowDeleting="GridView1_RowDeleting">



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

                                <div class="row">
                                    <!-- accepted payments column -->
                                    <div class="col-lg-6">
                                        <p class="lead" style="display: none;">
                                            Total Qty:
                                            <asp:Label ID="lbl_totalqty" runat="server" Text=""></asp:Label>
                                        </p>
                                        <p class="lead">
                                            Total Remaining Balance: ₹
                                            <asp:Label ID="lbl_total_remaining" Style="font-size: 20px; color: #ed0505;" runat="server" Text=""></asp:Label>
                                        </p>

                                        <asp:HiddenField ID="lbl_cutomer_contact" runat="server" />
                                        <asp:HiddenField ID="lbl_cutomer_email" runat="server" />
                                        <asp:HiddenField ID="lbl_product_hsn" runat="server" />
                                        <asp:HiddenField ID="lbl_unit" runat="server" />
                                    </div>
                                    <!-- /.col -->
                                    <%--               <div class="col-lg-6">
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
                                                        <th>Design Charges:</th>
                                                        <td>
                                                            <asp:TextBox ID="Txt_dtp_charges" onkeyup="final_total();" class="form-control" runat="server" TabIndex="16"></asp:TextBox></td>
                                                    </tr>
                                                  <tr>
                                                        <th>Transport:</th>
                                                        <td>
                                                            <asp:TextBox ID="Txt_shipping" onkeyup="final_total();" class="form-control" runat="server" TabIndex="17"></asp:TextBox></td>
                                                    </tr>

                                                         <tr>
                                                        <th>Pasting  / Fitting / Framing Charges:</th>
                                                        <td>
                                                            <asp:TextBox ID="Txt_Fitting_Framing" onkeyup="final_total();" class="form-control" runat="server" TabIndex="18"></asp:TextBox></td>
                                                    </tr>


                                                    <tr>
                                                        <th>Advance:</th>
                                                        <td>
                                                            <asp:TextBox ID="Txt_advance" onkeyup="final_total();" onchange="final_total();"  class="form-control" runat="server" TextMode="Number" TabIndex="19"></asp:TextBox></td>
                                                    </tr>
                                                    <tr>
                                                        <th>Discount:</th>
                                                        <td>
                                                            <asp:TextBox ID="Txt_discount" onkeyup="final_total();" onchange="final_total();"  class="form-control" runat="server" TextMode="Number" TabIndex="20"></asp:TextBox></td>
                                                    </tr>

                                                      <tr>
                                                        <th>Payment Method:</th>
                                                        <td>
                                                            <asp:DropDownList ID="drp_payment"  class="form-control"  runat="server" TabIndex="21">

                                                                <asp:ListItem Selected="True">Cash</asp:ListItem>
                                                                <asp:ListItem>Credit</asp:ListItem>
                                                                <asp:ListItem>Cheque</asp:ListItem>
                                                                <asp:ListItem>Paytm</asp:ListItem>
                                                                <asp:ListItem>Google Pay</asp:ListItem>
                                                                <asp:ListItem>Phone Pay</asp:ListItem>
                                                            </asp:DropDownList>

                                                        </td>
                                                    </tr>

                                                     <tr>
                                                        <th>Total:</th>
                                                        <td class="grand_total">₹ <asp:Label ID="lbl_Final_Balance" runat="server" Text=""></asp:Label></td>
                                                        
                                                    </tr>

                                                    <tr>
                                                        <th>Balance Amount:</th>
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

                                                <th scope="col">
                                                    <asp:CheckBox ID="Chk_dtp" runat="server" />
                                                    Design charges:</th>

                                                <th scope="col">
                                                    <asp:CheckBox ID="Chk_pasting" runat="server" />
                                                    Pasting Charges:</th>

                                                <th scope="col">
                                                    <asp:CheckBox ID="Chk_framing" runat="server" />
                                                    Framing Charges:</th>

                                                <th scope="col">
                                                    <asp:CheckBox ID="Chk_fitting" runat="server" />
                                                    Fitting Charges:</th>

                                                <th scope="col">
                                                    <asp:CheckBox ID="Chk_install" runat="server" />
                                                    Installation Charges:</th>

                                                <th scope="col">
                                                    <asp:CheckBox ID="Chk_trans" runat="server" />
                                                    Transport charges:</th>
                                                <%-- <th scope="col">Advance:</th>
                                            <th scope="col">Discount:</th>--%>
                                            </tr>
                                        </thead>
                                        <tbody>
                                            <tr>


                                                <td>
                                                    <asp:TextBox ID="Txt_Dtp_charges" onkeyup="final_total();" class="form-control" runat="server" TabIndex="21" TextMode="Number" min="0"></asp:TextBox></td>
                                                <td>
                                                    <asp:TextBox ID="Txt_Pasting" onkeyup="final_total();" class="form-control" runat="server" TabIndex="22" TextMode="Number" min="0"></asp:TextBox></td>
                                                <td>
                                                    <asp:TextBox ID="Txt_Framing" onkeyup="final_total();" class="form-control" runat="server" TabIndex="22" TextMode="Number" min="0"></asp:TextBox></td>
                                                <td>
                                                    <asp:TextBox ID="Txt_Fitting" onkeyup="final_total();" class="form-control" runat="server" TabIndex="22" TextMode="Number" min="0"></asp:TextBox></td>
                                                <td>
                                                    <asp:TextBox ID="Txt_install" onkeyup="final_total();" class="form-control" runat="server" TabIndex="22" TextMode="Number" min="0"></asp:TextBox></td>
                                                <td>
                                                    <asp:TextBox ID="Txt_TransportCharges" onkeyup="final_total();" class="form-control" runat="server" TabIndex="23" TextMode="Number" min="0"></asp:TextBox></td>

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


                                                <th scope="col">Advance<span style="color: red;">*</span>:</th>
                                                <th scope="col">Discount<span style="color: red;">*</span>:</th>
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
                                                    <asp:TextBox ID="Txt_advance" onkeyup="final_total();" onchange="final_total();" class="form-control" runat="server" TextMode="Number" min="0" TabIndex="24"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidatorAdvance" runat="server" ErrorMessage="Please Enter Advance.." ControlToValidate="Txt_advance" Display="Dynamic" ValidationGroup="g1"></asp:RequiredFieldValidator>
                                                </td>

                                                <td>
                                                    <asp:TextBox ID="Txt_discount" onkeyup="final_total();" onchange="final_total();" class="form-control" runat="server" TextMode="Number" min="0" TabIndex="25"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidatorDiscount" runat="server" ErrorMessage="Please Enter Discount.." ControlToValidate="Txt_discount" Display="Dynamic" ValidationGroup="g1"></asp:RequiredFieldValidator></td>
                                                <td>
                                                    <asp:DropDownList ID="drp_payment" class="form-control" runat="server" TabIndex="26">

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
                                                <%--  <th scope="col">Total GST:</th>--%>
                                                <th scope="col">Final Amount:</th>
                                                <th scope="col">Balance Amount:</th>


                                            </tr>
                                        </thead>
                                        <tbody>
                                            <tr>


                                                <td>₹
                                                    <asp:Label ID="lbl_subtotal" runat="server" Text=""></asp:Label></td>
                                                <asp:HiddenField ID="lbl_subtotal2" runat="server" />
                                                <%--  <td>
                                               ₹ <asp:Label ID="lbl_gst" runat="server" Text=""></asp:Label></td>--%>
                                                <td class="grand_total">₹
                                                    <asp:Label ID="lbl_final" runat="server" Text=""></asp:Label></td>

                                                <td class="grand_total">₹
                                                    <asp:Label ID="lbl_total" runat="server" Text=""></asp:Label></td>
                                                <td>
                                                    <asp:TextBox Class="Txt_hide" ID="hide_total" runat="server"></asp:TextBox></td>
                                                </td>
                                            
                                            
                                           
                                            </tr>

                                        </tbody>
                                    </table>

                                </div>
                                <!-- /.row -->

                                <!-- this row will not appear when printing -->
                                <div class="row no-print">
                                    <div class="col-lg-11 py-2 ml-4">
                                        <asp:Label ID="Lbl_message" runat="server" Text=""></asp:Label>
                                        <asp:Button ID="Btn_submit_payment" class="btn btn-success pull-right submitBtn" runat="server" Text="Save & Close" OnClick="Btn_submit_payment_Click" TabIndex="23" OnClientClick="return  JSFunctionValidate4();" />
                                        <asp:Button ID="Btn_generate_pdf" class="btn btn-primary pull-right" Style="margin-right: 5px;" runat="server" Text="Save Cash Memo" OnClientClick="return  JSFunctionValidate();" OnClick="Btn_generate_pdf_Click" TabIndex="22" />


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
    <!-- Modal -->
    <div class="modal fade" id="myModal" role="dialog">
        <div class="modal-dialog">

            <!-- Modal content-->
            <div class="modal-content">
                <div class="modal-header">
                    <h4 class="modal-title">Add Customer</h4>
                    <button type="button" class="close" data-dismiss="modal">&times;</button>

                </div>
                <div class="modal-body">
                    <div class="form-body">
                        <div class="form-group row">
                            <label class="control-label text-right col-md-3">Customer Name<span style="color: red;">*</span></label>
                            <div class="col-md-9">

                                <asp:TextBox ID="Txt_customer_name" placeholder="Customer Name" class="form-control" runat="server"></asp:TextBox>
                            </div>
                        </div>

                        <div class="form-group row">
                            <label class="control-label text-right col-md-3">Address</label>
                            <div class="col-md-9">
                                <asp:TextBox ID="Txt_address" class="form-control" placeholder="Address" runat="server" TextMode="MultiLine"></asp:TextBox>

                            </div>
                        </div>

                        <div class="form-group row">
                            <label class="control-label text-right col-md-3">Contact no. <span style="color: red;">*</span></label>
                            <div class="col-md-9">
                                <asp:TextBox ID="Txt_contact" placeholder="Contact no." class="form-control" runat="server" Maxlength="10" oninput="validateInput(this);"></asp:TextBox>
                            </div>
                        </div>
                        <div class="form-group row">
                            <label class="control-label text-right col-md-3">Alternate Contact no.</label>
                            <div class="col-md-9">
                                <asp:TextBox ID="Txt_contact2" placeholder="Alternate Contact no." class="form-control" runat="server" TextMode="Number"></asp:TextBox>
                            </div>
                        </div>
                        <div class="form-group row">
                            <label class="control-label text-right col-md-3">GST no.</label>
                            <div class="col-md-9">
                                <asp:TextBox ID="Txt_gst_no" placeholder="GST no." class="form-control" runat="server" MaxLength="15"></asp:TextBox>
                            </div>
                        </div>
                        <div class="form-group row">
                            <label class="control-label text-right col-md-3">Opening Balance</label>
                            <div class="col-md-9">
                                <asp:TextBox ID="Txt_opening_balance" placeholder="Opening Balance" class="form-control" runat="server"></asp:TextBox>
                            </div>
                        </div>


                        <div class="form-group row">
                            <label class="control-label text-right col-md-3">Email ID</label>
                            <div class="col-md-9">
                                <asp:TextBox ID="Txt_email" placeholder="Email ID" class="form-control" runat="server"></asp:TextBox>
                            </div>
                        </div>

                        <div class="form-group row">
                            <label class="control-label text-right col-md-3">Date Of Birth</label>
                            <div class="col-md-9">
                                <asp:TextBox ID="Txt_dob" placeholder="DOB" class="form-control" runat="server" TextMode="Date" TabIndex="8"></asp:TextBox>
                            </div>
                        </div>

                        <div class="form-group row">
                            <label class="control-label text-right col-md-3">Anniversary Date</label>
                            <div class="col-md-9">
                                <asp:TextBox ID="Txt_ani" placeholder="Anniversary" class="form-control" runat="server" TextMode="Date" TabIndex="9"></asp:TextBox>
                            </div>
                        </div>

                    </div>
                </div>

                <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                    <ContentTemplate>
                        <div class="modal-footer">
                            <asp:Label ID="lbl_msg" runat="server" Text=""></asp:Label>
                            <asp:Button ID="Button1" class="btn btn-success" runat="server" Text="Submit" OnClientClick="return JSFunctionValidate2();" OnClick="Button1_Click" />
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
                    <h4 class="modal-title">Add Sale Product</h4>
                    <button type="button" class="close" data-dismiss="modal">&times;</button>

                </div>
                <div class="modal-body">
                    <div class="form-body">
                        <div class="form-group row">
                            <label class="control-label text-right col-md-3">Product Name<span style="color: red;">*</span></label>
                            <div class="col-md-9">

                                <asp:TextBox ID="Txt_product_name" placeholder="Product Name" class="form-control" runat="server"></asp:TextBox>
                            </div>
                        </div>

                        <div class="form-group row">
                            <label class="control-label text-right col-md-3">Unit</label>
                            <div class="col-md-9">
                                <asp:DropDownList ID="Dd_unit" class="form-control" runat="server">
                                    <asp:ListItem Value="Sqft">Sqft</asp:ListItem>
                                    <asp:ListItem Value="Inch">Inch</asp:ListItem>
                                    <asp:ListItem Value="Pcs">Pcs</asp:ListItem>
                                    <asp:ListItem Value="Ltr">Ltr</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                        </div>

                        <div class="form-group row">
                            <label class="control-label text-right col-md-3">HSN Code</label>
                            <div class="col-md-9">
                                <asp:TextBox ID="Txt_hsn" placeholder="HSN Code" class="form-control" runat="server"></asp:TextBox>
                            </div>
                        </div>

                        <div class="form-group row">
                            <label class="control-label text-right col-md-3">Rate (Rs)<span style="color: red;">*</span></label>
                            <div class="col-md-9">
                                <asp:TextBox ID="Txt_ra" placeholder="Rate" class="form-control" runat="server"></asp:TextBox>
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
                            <asp:Label ID="lbl_msg2" runat="server" Text=""></asp:Label>
                            <asp:Button ID="Button2" class="btn btn-success" runat="server" OnClientClick="return JSFunctionValidate3();" Text="Submit" OnClick="Button2_Click" />
                            <button type="button" class="btn btn-default" data-dismiss="modal">Close</button>
                        </div>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>

        </div>
    </div>

    <!-- /.content-wrapper -->
    <footer class="main-footer">
        <div class="pull-right hidden-xs">Version 1.0</div>
        Copyright © 2018 PrintSoft. All rights reserved.
    </footer>


    <style>
        .Txt_hide {
            display: none;
        }
    </style>

    <script type="text/javascript">
        function validateInput(input) {
            input.value = input.value.replace(/\D/g, '').substring(0, 10);
        }
    </script>



    <script>
        function JSFunctionValidate() {
            if (document.getElementById('<%=Dd_customer.ClientID%>').value == "--Select--") {
                alert("Please Select Customer Name !!!");
                return false;
            }
            if (document.getElementById('<%=drp_designer.ClientID%>').value == "--Show Designer--") {
                alert("Please Select Designer Name !!!");
                return false;
            }
           <%-- if (document.getElementById('<%=Dd_enter_product.ClientID%>').value == "--Select--") {
                alert("Please Select Product !!!");
                return false;
            }
            if (document.getElementById('<%=Dd_material.ClientID%>').value == "--Select--") {
                alert("Please Select Material !!!");
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

            if (document.getElementById('<%=Txt_advance.ClientID%>').value.length == 0) {
                alert("Please Enter Advance !!!");
                return false;
            }
            if (document.getElementById('<%=Txt_discount.ClientID%>').value.length == 0) {
                alert("Please Enter Discount !!!");
                return false;
            }
            preventMultipleSubmissions();
            return true;
        }

   </script>

    <script>






        function JSFunctionValidate4() {
            if (document.getElementById('<%=Dd_customer.ClientID%>').value == "--Select--") {
                alert("Please Select Customer Name !!!");
                return false;
            }
            if (document.getElementById('<%=drp_designer.ClientID%>').value == "--Show Designer--") {
                alert("Please Select Designer Name !!!");
                return false;
            }
          <%--  if (document.getElementById('<%=Dd_enter_product.ClientID%>').value == "--Select--") {
                alert("Please Select Product !!!");
                return false;
            }
            if (document.getElementById('<%=Dd_material.ClientID%>').value == "--Select--") {
                alert("Please Select Material !!!");
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

            if (document.getElementById('<%=Txt_advance.ClientID%>').value.length == 0) {
                alert("Please Enter Advance !!!");
                return false;
            }
            if (document.getElementById('<%=Txt_discount.ClientID%>').value.length == 0) {
                alert("Please Enter Discount !!!");
                return false;
            }
            preventMultipleSubmissions1();

            return true;
        }


        function JSFunctionValidate5() {

            var quant2 = document.getElementById('<%=txt_quantity2.ClientID %>');
            var quant = document.getElementById('<%=txt_quantity.ClientID %>');
            var height = document.getElementById('<%=txt_height.ClientID %>');
            var height2 = document.getElementById('<%=txt_height2.ClientID %>');
            var width = document.getElementById('<%=txt_width.ClientID %>');
            var width2 = document.getElementById('<%=txt_width2.ClientID %>');

            if (document.getElementById('<%=Dd_customer.ClientID%>').value == "--Select--") {
                alert("Please Select Customer Name !!!");
                return false;
            }
            if (document.getElementById('<%=drp_designer.ClientID%>').value == "--Show Designer--") {
                alert("Please Select Designer Name !!!");
                return false;
            }
            if (document.getElementById('<%=Dd_enter_product.ClientID%>').value == "--Select--") {
                alert("Please Select Product !!!");
                return false;
            }
            if (document.getElementById('<%=Dd_material.ClientID%>').value == "--Select--") {
                alert("Please Select Material !!!");
                return false;
            }

            if (width != null) {
                if (width.value == "0") {
                    alert("Length should  not be 0 !!!");
                    return false;
                }
            }
            if (height != null) {
                if (height.value == "0") {
                    alert("Height should not be 0  !!!");
                    return false;
                }
            }
            //if (width2 != null) {
            //    if (height2.value == "0") {
            //        alert("Length should  not be 0 !!!");
            //        return false;
            //    }
            //}
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
    <script>
        function JSFunctionValidate2() {
            if (document.getElementById('<%=Txt_customer_name.ClientID%>').value.length == 0) {
                alert("Please Enter Customer's Name !!!");
                return false;
            }
            if (document.getElementById('<%=Txt_contact.ClientID%>').value.length == 0) {
                alert("Please Enter Contact No !!!");
                return false;
            }
            if (document.getElementById('<%=Txt_gst_no.ClientID%>').value.length != 0) {
                //alert("Please Enter Gst Number !!!");
                //return false;
                if (document.getElementById('<%=Txt_gst_no.ClientID%>').value.length != 15) {
                    alert("Please Enter Valid Gst Number !!!");
                    return false;
                }
            }

            if (!(/^\w+([\.-]?\w+)*@\w+([\.-]?\w+)*(\.\w{2,3})+$/.test(document.getElementById('<%=Txt_email.ClientID%>').value)) && !(document.getElementById('<%=Txt_email.ClientID%>').value.length == 0)) {
                alert("You Have Entered an Invalid Email Address!");
                return false;
            }
            return true;
        }
    </script>
    <script>
        function JSFunctionValidate3() {
            if (document.getElementById('<%=Txt_product_name.ClientID%>').value.length == 0) {
                alert("Please Enter Product Name !!!");
                return false;
            }


            if (document.getElementById('<%=Txt_ra.ClientID%>').value.length == 0) {
                alert("Please Enter Product's Rate  !!!");
                return false;
            }


            return true;
        }

    </script>

















    <%-- <script>
        function JSFunctionValidate2() {
            if (document.getElementById('<%=Txt_customer_name.ClientID%>').value.length == 0) {
                alert("Please Enter Customer's Name !!!");
                return false;
            }
            if (document.getElementById('<%=Txt_contact.ClientID%>').value.length == 0) {
                alert("Please Enter Contact No !!!");
                return false;
            }
            if (document.getElementById('<%=Txt_gst_no.ClientID%>').value.length != 0) {
        //alert("Please Enter Gst Number !!!");
        //return false;
                if (document.getElementById('<%=Txt_gst_no.ClientID%>').value.length != 15) {
                    alert("Please Enter Valid Gst Number !!!");
                    return false;
                }
            }


            if (!(/^\w+([\.-]?\w+)*@\w+([\.-]?\w+)*(\.\w{2,3})+$/.test(document.getElementById('<%=Txt_email.ClientID%>').value)) && !(document.getElementById('<%=Txt_email.ClientID%>').value.length == 0)) {
                alert("You Have Entered an Invalid Email Address!");
                return false;
            }

            return true;
        }
    </script>--%>
    <script type="text/javascript">
        function sqrft() {
            var first = document.getElementById('<%= txt_height.ClientID %>');
            var second = document.getElementById('<%= txt_width.ClientID %>');
            var sqrft = document.getElementById('<%= txt_sqrft.ClientID %>');
            if (first == null) {
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
            var sqrft = document.getElementById('<%=txt_sqrft.ClientID %>');
            var amount = document.getElementById('<%=txt_amount.ClientID %>');

            var rate_amount = (parseFloat(sqrft.value) * parseFloat(rates.value));

            amount.value = rate_amount;
        }


        function quan_amount() {
            var amt = document.getElementById('<%=txt_amount.ClientID %>');
            var quantity = document.getElementById('<%=txt_quantity.ClientID %>');
            var total = document.getElementById('<%=txt_total_amt.ClientID %>');

            var total_amount = (parseFloat(amt.value) * parseFloat(quantity.value))

            total.value = total_amount.toFixed(2);

        }
        function quan_amount2() {
            var rate = document.getElementById('<%=txt_rate2.ClientID %>');
            var quantity = document.getElementById('<%=txt_quantity2.ClientID %>');
            var total = document.getElementById('<%=txt_total_amt2.ClientID %>');

            var total_amount = (parseFloat(rate.value) * parseFloat(quantity.value))

            total.value = total_amount.toFixed(2);

        }


        function final_total() {
            var subtotal = document.getElementById('<%=lbl_subtotal2.ClientID %>');


            var discount = document.getElementById('<%=Txt_discount.ClientID %>');

            var dtpcharges = document.getElementById('<%=Txt_Dtp_charges.ClientID %>');
            var dtp_value = parseFloat(dtpcharges.value);

            var transport_charges = document.getElementById('<%=Txt_TransportCharges.ClientID %>');
            var transport_value = parseFloat(transport_charges.value);

            var advance = document.getElementById('<%=Txt_advance.ClientID %>');

            var fitting = document.getElementById('<%=Txt_Fitting.ClientID%>');
            var fitting_value = parseFloat(fitting.value);

            var install = document.getElementById('<%=Txt_install.ClientID%>');
            var install_value = parseFloat(install.value);

            var pasting = document.getElementById('<%=Txt_Pasting.ClientID%>');
            var pasting_value = parseFloat(pasting.value);

            var framing = document.getElementById('<%=Txt_Framing.ClientID%>');
            var framing_value = parseFloat(framing.value);

            if (document.getElementById('<%=Txt_Dtp_charges.ClientID %>').value == '' && document.getElementById('<%=Txt_Fitting.ClientID%>').value == '' && document.getElementById('<%=Txt_Pasting.ClientID%>').value == '' && document.getElementById('<%=Txt_TransportCharges.ClientID %>').value == '' && document.getElementById('<%=Txt_install.ClientID%>').value == '' && document.getElementById('<%=Txt_Framing.ClientID%>').value == '') {
                //dtpvar = "0";
                //fittingvar = "0";
                //pastingvar = "0";
                dtp_value = "0";
                fitting_value = "0";
                pasting_value = "0";
                transport_value = "0";
                install_value = "0";
                framing_value = "0";
            }

            //1 column
            else if (document.getElementById('<%=Txt_Dtp_charges.ClientID %>').value != '' && document.getElementById('<%=Txt_Fitting.ClientID%>').value == '' && document.getElementById('<%=Txt_Pasting.ClientID%>').value == '' && document.getElementById('<%=Txt_TransportCharges.ClientID %>').value == '' && document.getElementById('<%=Txt_install.ClientID%>').value == '' && document.getElementById('<%=Txt_Framing.ClientID%>').value == '') {
                //dtpvar = "0";
                //fittingvar = "0";
                //pastingvar = "0";
                fitting_value = "0";
                pasting_value = "0";
                transport_value = "0";
                framing_value = "0";
                install_value = "0";
            }

            else if (document.getElementById('<%=Txt_Dtp_charges.ClientID %>').value == '' && document.getElementById('<%=Txt_Fitting.ClientID%>').value == '' && document.getElementById('<%=Txt_Pasting.ClientID%>').value != '' && document.getElementById('<%=Txt_TransportCharges.ClientID %>').value == '' && document.getElementById('<%=Txt_install.ClientID%>').value == '' && document.getElementById('<%=Txt_Framing.ClientID%>').value == '') {
                //dtpvar = "0";
                //fittingvar = "0";
                //pastingvar = "0";
                fitting_value = "0";
                dtp_value = "0";
                transport_value = "0";
                framing_value = "0";
                install_value = "0";
            }

            else if (document.getElementById('<%=Txt_Dtp_charges.ClientID %>').value == '' && document.getElementById('<%=Txt_Fitting.ClientID%>').value != '' && document.getElementById('<%=Txt_Pasting.ClientID%>').value == '' && document.getElementById('<%=Txt_TransportCharges.ClientID %>').value == '' && document.getElementById('<%=Txt_install.ClientID%>').value == '' && document.getElementById('<%=Txt_Framing.ClientID%>').value == '') {
                //dtpvar = "0";
                //fittingvar = "0";
                //pastingvar = "0";
                dtp_value = "0";
                pasting_value = "0";
                transport_value = "0";
                framing_value = "0";
                install_value = "0";
            }

            else if (document.getElementById('<%=Txt_Dtp_charges.ClientID %>').value == '' && document.getElementById('<%=Txt_Fitting.ClientID%>').value == '' && document.getElementById('<%=Txt_Pasting.ClientID%>').value == '' && document.getElementById('<%=Txt_TransportCharges.ClientID %>').value != '' && document.getElementById('<%=Txt_install.ClientID%>').value == '' && document.getElementById('<%=Txt_Framing.ClientID%>').value == '') {
                //dtpvar = "0";
                //fittingvar = "0";
                //pastingvar = "0";
                dtp_value = "0";
                pasting_value = "0";
                fitting_value = "0";
                framing_value = "0";
                install_value = "0";
            }

            else if (document.getElementById('<%=Txt_Dtp_charges.ClientID %>').value == '' && document.getElementById('<%=Txt_Fitting.ClientID%>').value == '' && document.getElementById('<%=Txt_Pasting.ClientID%>').value == '' && document.getElementById('<%=Txt_TransportCharges.ClientID %>').value == '' && document.getElementById('<%=Txt_install.ClientID%>').value == '' && document.getElementById('<%=Txt_Framing.ClientID%>').value != '') {
                //dtpvar = "0";
                //fittingvar = "0";
                //pastingvar = "0";
                dtp_value = "0";
                pasting_value = "0";
                fitting_value = "0";
                transport_value = "0";
                install_value = "0";
            }

            else if (document.getElementById('<%=Txt_Dtp_charges.ClientID %>').value == '' && document.getElementById('<%=Txt_Fitting.ClientID%>').value == '' && document.getElementById('<%=Txt_Pasting.ClientID%>').value == '' && document.getElementById('<%=Txt_TransportCharges.ClientID %>').value == '' && document.getElementById('<%=Txt_install.ClientID%>').value != '' && document.getElementById('<%=Txt_Framing.ClientID%>').value == '') {
                //dtpvar = "0";
                //fittingvar = "0";
                //pastingvar = "0";
                dtp_value = "0";
                pasting_value = "0";
                fitting_value = "0";
                framing_value = "0";
                transport_value = "0";
            }

            //2 column
            else if (document.getElementById('<%=Txt_Dtp_charges.ClientID %>').value != '' && document.getElementById('<%=Txt_Fitting.ClientID%>').value == '' && document.getElementById('<%=Txt_Pasting.ClientID%>').value != '' && document.getElementById('<%=Txt_TransportCharges.ClientID %>').value == '' && document.getElementById('<%=Txt_install.ClientID%>').value == '' && document.getElementById('<%=Txt_Framing.ClientID%>').value == '') {
                //dtpvar = "0";
                //fittingvar = "0";
                //pastingvar = "0";
                transport_value = "0";
                fitting_value = "0";
                framing_value = "0";
                install_value = "0";
            }

            else if (document.getElementById('<%=Txt_Dtp_charges.ClientID %>').value != '' && document.getElementById('<%=Txt_Fitting.ClientID%>').value != '' && document.getElementById('<%=Txt_Pasting.ClientID%>').value == '' && document.getElementById('<%=Txt_TransportCharges.ClientID %>').value == '' && document.getElementById('<%=Txt_install.ClientID%>').value == '' && document.getElementById('<%=Txt_Framing.ClientID%>').value == '') {
                //dtpvar = "0";
                //fittingvar = "0";
                //pastingvar = "0";
                transport_value = "0";
                pasting_value = "0";
                framing_value = "0";
                install_value = "0";
            }

            else if (document.getElementById('<%=Txt_Dtp_charges.ClientID %>').value != '' && document.getElementById('<%=Txt_Fitting.ClientID%>').value == '' && document.getElementById('<%=Txt_Pasting.ClientID%>').value == '' && document.getElementById('<%=Txt_TransportCharges.ClientID %>').value != '' && document.getElementById('<%=Txt_install.ClientID%>').value == '' && document.getElementById('<%=Txt_Framing.ClientID%>').value == '') {
                //dtpvar = "0";
                //fittingvar = "0";
                //pastingvar = "0";
                fitting_value = "0";
                pasting_value = "0";
                framing_value = "0";
                install_value = "0";
            }

            else if (document.getElementById('<%=Txt_Dtp_charges.ClientID %>').value != '' && document.getElementById('<%=Txt_Fitting.ClientID%>').value == '' && document.getElementById('<%=Txt_Pasting.ClientID%>').value == '' && document.getElementById('<%=Txt_TransportCharges.ClientID %>').value == '' && document.getElementById('<%=Txt_install.ClientID%>').value == '' && document.getElementById('<%=Txt_Framing.ClientID%>').value != '') {
                //dtpvar = "0";
                //fittingvar = "0";
                //pastingvar = "0";
                fitting_value = "0";
                pasting_value = "0";
                transport_value = "0";
                install_value = "0";
            }

            else if (document.getElementById('<%=Txt_Dtp_charges.ClientID %>').value != '' && document.getElementById('<%=Txt_Fitting.ClientID%>').value == '' && document.getElementById('<%=Txt_Pasting.ClientID%>').value == '' && document.getElementById('<%=Txt_TransportCharges.ClientID %>').value == '' && document.getElementById('<%=Txt_install.ClientID%>').value != '' && document.getElementById('<%=Txt_Framing.ClientID%>').value == '') {
                //dtpvar = "0";
                //fittingvar = "0";
                //pastingvar = "0";
                fitting_value = "0";
                pasting_value = "0";
                transport_value = "0";
                framing_value = "0";
            }

            else if (document.getElementById('<%=Txt_Dtp_charges.ClientID %>').value == '' && document.getElementById('<%=Txt_Fitting.ClientID%>').value != '' && document.getElementById('<%=Txt_Pasting.ClientID%>').value != '' && document.getElementById('<%=Txt_TransportCharges.ClientID %>').value == '' && document.getElementById('<%=Txt_install.ClientID%>').value == '' && document.getElementById('<%=Txt_Framing.ClientID%>').value == '') {
                //dtpvar = "0";
                //fittingvar = "0";
                //pastingvar = "0";
                dtp_value = "0";
                transport_value = "0";
                framing_value = "0";
                install_value = "0";
            }

            else if (document.getElementById('<%=Txt_Dtp_charges.ClientID %>').value == '' && document.getElementById('<%=Txt_Fitting.ClientID%>').value == '' && document.getElementById('<%=Txt_Pasting.ClientID%>').value != '' && document.getElementById('<%=Txt_TransportCharges.ClientID %>').value != '' && document.getElementById('<%=Txt_install.ClientID%>').value == '' && document.getElementById('<%=Txt_Framing.ClientID%>').value == '') {
                //dtpvar = "0";
                //fittingvar = "0";
                //pastingvar = "0";
                dtp_value = "0";
                fitting_value = "0";
                framing_value = "0";
                install_value = "0";

            }

            else if (document.getElementById('<%=Txt_Dtp_charges.ClientID %>').value == '' && document.getElementById('<%=Txt_Fitting.ClientID%>').value == '' && document.getElementById('<%=Txt_Pasting.ClientID%>').value != '' && document.getElementById('<%=Txt_TransportCharges.ClientID %>').value != '' && document.getElementById('<%=Txt_install.ClientID%>').value == '' && document.getElementById('<%=Txt_Framing.ClientID%>').value != '') {
                //dtpvar = "0";
                //fittingvar = "0";
                //pastingvar = "0";
                dtp_value = "0";
                transport_value = "0";
                fitting_value = "0";
                install_value = "0";
            }

            else if (document.getElementById('<%=Txt_Dtp_charges.ClientID %>').value == '' && document.getElementById('<%=Txt_Fitting.ClientID%>').value == '' && document.getElementById('<%=Txt_Pasting.ClientID%>').value != '' && document.getElementById('<%=Txt_TransportCharges.ClientID %>').value == '' && document.getElementById('<%=Txt_install.ClientID%>').value != '' && document.getElementById('<%=Txt_Framing.ClientID%>').value == '') {
                //dtpvar = "0";
                //fittingvar = "0";
                //pastingvar = "0";
                dtp_value = "0";
                fitting_value = "0";
                transport_value = "0";
                fitting_value = "0";
            }

            else if (document.getElementById('<%=Txt_Dtp_charges.ClientID %>').value == '' && document.getElementById('<%=Txt_Fitting.ClientID%>').value != '' && document.getElementById('<%=Txt_Pasting.ClientID%>').value == '' && document.getElementById('<%=Txt_TransportCharges.ClientID %>').value != '' && document.getElementById('<%=Txt_install.ClientID%>').value == '' && document.getElementById('<%=Txt_Framing.ClientID%>').value == '') {
                //dtpvar = "0";
                //fittingvar = "0";
                //pastingvar = "0";
                dtp_value = "0";
                fitting_value = "0";
                pasting_value = "0";
                framing_value = "0";
            }

            else if (document.getElementById('<%=Txt_Dtp_charges.ClientID %>').value == '' && document.getElementById('<%=Txt_Fitting.ClientID%>').value != '' && document.getElementById('<%=Txt_Pasting.ClientID%>').value == '' && document.getElementById('<%=Txt_TransportCharges.ClientID %>').value != '' && document.getElementById('<%=Txt_install.ClientID%>').value == '' && document.getElementById('<%=Txt_Framing.ClientID%>').value == '') {
                //dtpvar = "0";
                //fittingvar = "0";
                //pastingvar = "0";
                dtp_value = "0";
                install_value = "0";
                pasting_value = "0";
                framing_value = "0";
            }

            else if (document.getElementById('<%=Txt_Dtp_charges.ClientID %>').value == '' && document.getElementById('<%=Txt_Fitting.ClientID%>').value != '' && document.getElementById('<%=Txt_Pasting.ClientID%>').value == '' && document.getElementById('<%=Txt_TransportCharges.ClientID %>').value == '' && document.getElementById('<%=Txt_install.ClientID%>').value == '' && document.getElementById('<%=Txt_Framing.ClientID%>').value != '') {
                //dtpvar = "0";
                //fittingvar = "0";
                //pastingvar = "0";
                dtp_value = "0";
                install_value = "0";
                pasting_value = "0";
                transport_value = "0";
            }

            else if (document.getElementById('<%=Txt_Dtp_charges.ClientID %>').value == '' && document.getElementById('<%=Txt_Fitting.ClientID%>').value != '' && document.getElementById('<%=Txt_Pasting.ClientID%>').value == '' && document.getElementById('<%=Txt_TransportCharges.ClientID %>').value == '' && document.getElementById('<%=Txt_install.ClientID%>').value != '' && document.getElementById('<%=Txt_Framing.ClientID%>').value == '') {
                //dtpvar = "0";
                //fittingvar = "0";
                //pastingvar = "0";
                dtp_value = "0";
                framing_value = "0";
                pasting_value = "0";
                transport_value = "0";
            }

            else if (document.getElementById('<%=Txt_Dtp_charges.ClientID %>').value == '' && document.getElementById('<%=Txt_Fitting.ClientID%>').value == '' && document.getElementById('<%=Txt_Pasting.ClientID%>').value == '' && document.getElementById('<%=Txt_TransportCharges.ClientID %>').value != '' && document.getElementById('<%=Txt_install.ClientID%>').value == '' && document.getElementById('<%=Txt_Framing.ClientID%>').value != '') {
                //dtpvar = "0";
                //fittingvar = "0";
                //pastingvar = "0";
                dtp_value = "0";
                fitting_value = "0";
                pasting_value = "0";
                install_value = "0";
            }

            else if (document.getElementById('<%=Txt_Dtp_charges.ClientID %>').value == '' && document.getElementById('<%=Txt_Fitting.ClientID%>').value == '' && document.getElementById('<%=Txt_Pasting.ClientID%>').value == '' && document.getElementById('<%=Txt_TransportCharges.ClientID %>').value != '' && document.getElementById('<%=Txt_install.ClientID%>').value != '' && document.getElementById('<%=Txt_Framing.ClientID%>').value == '') {
                //dtpvar = "0";
                //fittingvar = "0";
                //pastingvar = "0";
                dtp_value = "0";
                framing_value = "0";
                pasting_value = "0";
                fitting_value = "0";
            }

            else if (document.getElementById('<%=Txt_Dtp_charges.ClientID %>').value == '' && document.getElementById('<%=Txt_Fitting.ClientID%>').value == '' && document.getElementById('<%=Txt_Pasting.ClientID%>').value == '' && document.getElementById('<%=Txt_TransportCharges.ClientID %>').value == '' && document.getElementById('<%=Txt_install.ClientID%>').value != '' && document.getElementById('<%=Txt_Framing.ClientID%>').value != '') {
                //dtpvar = "0";
                //fittingvar = "0";
                //pastingvar = "0";
                dtp_value = "0";
                transport_value = "0";
                pasting_value = "0";
                fitting_value = "0";
            }

            //3 column
            else if (document.getElementById('<%=Txt_Dtp_charges.ClientID %>').value != '' && document.getElementById('<%=Txt_Fitting.ClientID%>').value != '' && document.getElementById('<%=Txt_Pasting.ClientID%>').value != '' && document.getElementById('<%=Txt_TransportCharges.ClientID %>').value == '' && document.getElementById('<%=Txt_install.ClientID%>').value == '' && document.getElementById('<%=Txt_Framing.ClientID%>').value == '') {
                //dtpvar = "0";
                //fittingvar = "0";
                //pastingvar = "0";
                transport_value = "0";
                framing_value = "0";
                install_value = "0";
            }

            else if (document.getElementById('<%=Txt_Dtp_charges.ClientID %>').value != '' && document.getElementById('<%=Txt_Fitting.ClientID%>').value == '' && document.getElementById('<%=Txt_Pasting.ClientID%>').value != '' && document.getElementById('<%=Txt_TransportCharges.ClientID %>').value != '' && document.getElementById('<%=Txt_install.ClientID%>').value == '' && document.getElementById('<%=Txt_Framing.ClientID%>').value == '') {
                //dtpvar = "0";
                //fittingvar = "0";
                //pastingvar = "0";
                fitting_value = "0";
                framing_value = "0";
                install_value = "0";
            }

            else if (document.getElementById('<%=Txt_Dtp_charges.ClientID %>').value != '' && document.getElementById('<%=Txt_Fitting.ClientID%>').value == '' && document.getElementById('<%=Txt_Pasting.ClientID%>').value != '' && document.getElementById('<%=Txt_TransportCharges.ClientID %>').value == '' && document.getElementById('<%=Txt_install.ClientID%>').value == '' && document.getElementById('<%=Txt_Framing.ClientID%>').value != '') {
                //dtpvar = "0";
                //fittingvar = "0";
                //pastingvar = "0";
                fitting_value = "0";
                transport_value = "0";
                install_value = "0";
            }

            else if (document.getElementById('<%=Txt_Dtp_charges.ClientID %>').value != '' && document.getElementById('<%=Txt_Fitting.ClientID%>').value == '' && document.getElementById('<%=Txt_Pasting.ClientID%>').value != '' && document.getElementById('<%=Txt_TransportCharges.ClientID %>').value == '' && document.getElementById('<%=Txt_install.ClientID%>').value != '' && document.getElementById('<%=Txt_Framing.ClientID%>').value == '') {
                //dtpvar = "0";
                //fittingvar = "0";
                //pastingvar = "0";
                transport_value = "0";
                framing_value = "0";
                install_value = "0";
            }

            else if (document.getElementById('<%=Txt_Dtp_charges.ClientID %>').value != '' && document.getElementById('<%=Txt_Fitting.ClientID%>').value != '' && document.getElementById('<%=Txt_Pasting.ClientID%>').value == '' && document.getElementById('<%=Txt_TransportCharges.ClientID %>').value != '' && document.getElementById('<%=Txt_install.ClientID%>').value == '' && document.getElementById('<%=Txt_Framing.ClientID%>').value == '') {
                //dtpvar = "0";
                //fittingvar = "0";
                //pastingvar = "0";
                pasting_value = "0";
                framing_value = "0";
                install_value = "0";
            }

            else if (document.getElementById('<%=Txt_Dtp_charges.ClientID %>').value != '' && document.getElementById('<%=Txt_Fitting.ClientID%>').value != '' && document.getElementById('<%=Txt_Pasting.ClientID%>').value == '' && document.getElementById('<%=Txt_TransportCharges.ClientID %>').value == '' && document.getElementById('<%=Txt_install.ClientID%>').value == '' && document.getElementById('<%=Txt_Framing.ClientID%>').value == '') {
                //dtpvar = "0";
                //fittingvar = "0";
                //pastingvar = "0";
                pasting_value = "0";
                transport_value = "0";
                install_value = "0";
            }

            else if (document.getElementById('<%=Txt_Dtp_charges.ClientID %>').value != '' && document.getElementById('<%=Txt_Fitting.ClientID%>').value == '' && document.getElementById('<%=Txt_Pasting.ClientID%>').value == '' && document.getElementById('<%=Txt_TransportCharges.ClientID %>').value == '' && document.getElementById('<%=Txt_install.ClientID%>').value != '' && document.getElementById('<%=Txt_Framing.ClientID%>').value != '') {
                //dtpvar = "0";
                //fittingvar = "0";
                //pastingvar = "0";
                pasting_value = "0";
                transport_value = "0";
                framing_value = "0";
            }

            else if (document.getElementById('<%=Txt_Dtp_charges.ClientID %>').value != '' && document.getElementById('<%=Txt_Fitting.ClientID%>').value == '' && document.getElementById('<%=Txt_Pasting.ClientID%>').value == '' && document.getElementById('<%=Txt_TransportCharges.ClientID %>').value != '' && document.getElementById('<%=Txt_install.ClientID%>').value == '' && document.getElementById('<%=Txt_Framing.ClientID%>').value != '') {
                //dtpvar = "0";
                //fittingvar = "0";
                //pastingvar = "0";
                pasting_value = "0";
                fitting_value = "0";
                install_value = "0";
            }

            else if (document.getElementById('<%=Txt_Dtp_charges.ClientID %>').value != '' && document.getElementById('<%=Txt_Fitting.ClientID%>').value == '' && document.getElementById('<%=Txt_Pasting.ClientID%>').value == '' && document.getElementById('<%=Txt_TransportCharges.ClientID %>').value == '' && document.getElementById('<%=Txt_install.ClientID%>').value != '' && document.getElementById('<%=Txt_Framing.ClientID%>').value != '') {
                //dtpvar = "0";
                //fittingvar = "0";
                //pastingvar = "0";
                pasting_value = "0";
                fitting_value = "0";
                transport_value = "0";
            }

            else if (document.getElementById('<%=Txt_Dtp_charges.ClientID %>').value == '' && document.getElementById('<%=Txt_Fitting.ClientID%>').value != '' && document.getElementById('<%=Txt_Pasting.ClientID%>').value != '' && document.getElementById('<%=Txt_TransportCharges.ClientID %>').value != '' && document.getElementById('<%=Txt_install.ClientID%>').value == '' && document.getElementById('<%=Txt_Framing.ClientID%>').value == '') {
                //dtpvar = "0";
                //fittingvar = "0";
                //pastingvar = "0";
                dtp_value = "0";
                framing_value = "0";
                install_value = "0";
            }

            else if (document.getElementById('<%=Txt_Dtp_charges.ClientID %>').value == '' && document.getElementById('<%=Txt_Fitting.ClientID%>').value != '' && document.getElementById('<%=Txt_Pasting.ClientID%>').value != '' && document.getElementById('<%=Txt_TransportCharges.ClientID %>').value == '' && document.getElementById('<%=Txt_install.ClientID%>').value == '' && document.getElementById('<%=Txt_Framing.ClientID%>').value != '') {
                //dtpvar = "0";
                //fittingvar = "0";
                //pastingvar = "0";
                dtp_value = "0";
                transport_value = "0";
                install_value = "0";
            }

            else if (document.getElementById('<%=Txt_Dtp_charges.ClientID %>').value == '' && document.getElementById('<%=Txt_Fitting.ClientID%>').value != '' && document.getElementById('<%=Txt_Pasting.ClientID%>').value != '' && document.getElementById('<%=Txt_TransportCharges.ClientID %>').value == '' && document.getElementById('<%=Txt_install.ClientID%>').value != '' && document.getElementById('<%=Txt_Framing.ClientID%>').value == '') {
                //dtpvar = "0";
                //fittingvar = "0";
                //pastingvar = "0";
                dtp_value = "0";
                transport_value = "0";
                framing_value = "0";
            }

            else if (document.getElementById('<%=Txt_Dtp_charges.ClientID %>').value == '' && document.getElementById('<%=Txt_Fitting.ClientID%>').value == '' && document.getElementById('<%=Txt_Pasting.ClientID%>').value != '' && document.getElementById('<%=Txt_TransportCharges.ClientID %>').value != '' && document.getElementById('<%=Txt_install.ClientID%>').value == '' && document.getElementById('<%=Txt_Framing.ClientID%>').value != '') {
                //dtpvar = "0";
                //fittingvar = "0";
                //pastingvar = "0";
                dtp_value = "0";
                install_value = "0";
                fitting_value = "0";
            }

            else if (document.getElementById('<%=Txt_Dtp_charges.ClientID %>').value == '' && document.getElementById('<%=Txt_Fitting.ClientID%>').value == '' && document.getElementById('<%=Txt_Pasting.ClientID%>').value != '' && document.getElementById('<%=Txt_TransportCharges.ClientID %>').value != '' && document.getElementById('<%=Txt_install.ClientID%>').value != '' && document.getElementById('<%=Txt_Framing.ClientID%>').value == '') {
                //dtpvar = "0";
                //fittingvar = "0";
                //pastingvar = "0";
                dtp_value = "0";
                fitting_value = "0";
                framing_value = "0";
            }

            else if (document.getElementById('<%=Txt_Dtp_charges.ClientID %>').value == '' && document.getElementById('<%=Txt_Fitting.ClientID%>').value == '' && document.getElementById('<%=Txt_Pasting.ClientID%>').value != '' && document.getElementById('<%=Txt_TransportCharges.ClientID %>').value == '' && document.getElementById('<%=Txt_install.ClientID%>').value != '' && document.getElementById('<%=Txt_Framing.ClientID%>').value != '') {
                //dtpvar = "0";
                //fittingvar = "0";
                //pastingvar = "0";
                dtp_value = "0";
                fitting_value = "0";
                transport_value = "0";
            }

            else if (document.getElementById('<%=Txt_Dtp_charges.ClientID %>').value == '' && document.getElementById('<%=Txt_Fitting.ClientID%>').value != '' && document.getElementById('<%=Txt_Pasting.ClientID%>').value == '' && document.getElementById('<%=Txt_TransportCharges.ClientID %>').value != '' && document.getElementById('<%=Txt_install.ClientID%>').value == '' && document.getElementById('<%=Txt_Framing.ClientID%>').value != '') {
                //dtpvar = "0";
                //fittingvar = "0";
                //pastingvar = "0";
                dtp_value = "0";
                install_value = "0";
                pasting_value = "0";
            }

            else if (document.getElementById('<%=Txt_Dtp_charges.ClientID %>').value == '' && document.getElementById('<%=Txt_Fitting.ClientID%>').value != '' && document.getElementById('<%=Txt_Pasting.ClientID%>').value == '' && document.getElementById('<%=Txt_TransportCharges.ClientID %>').value != '' && document.getElementById('<%=Txt_install.ClientID%>').value != '' && document.getElementById('<%=Txt_Framing.ClientID%>').value == '') {
                //dtpvar = "0";
                //fittingvar = "0";
                //pastingvar = "0";
                dtp_value = "0";
                framing_value = "0";
                pasting_value = "0";
            }

            else if (document.getElementById('<%=Txt_Dtp_charges.ClientID %>').value == '' && document.getElementById('<%=Txt_Fitting.ClientID%>').value == '' && document.getElementById('<%=Txt_Pasting.ClientID%>').value == '' && document.getElementById('<%=Txt_TransportCharges.ClientID %>').value != '' && document.getElementById('<%=Txt_install.ClientID%>').value != '' && document.getElementById('<%=Txt_Framing.ClientID%>').value != '') {
                //dtpvar = "0";
                //fittingvar = "0";
                //pastingvar = "0";
                dtp_value = "0";
                fitting_value = "0";
                pasting_value = "0";
            }

            //4 column

            else if (document.getElementById('<%=Txt_Dtp_charges.ClientID %>').value != '' && document.getElementById('<%=Txt_Fitting.ClientID%>').value != '' && document.getElementById('<%=Txt_Pasting.ClientID%>').value != '' && document.getElementById('<%=Txt_TransportCharges.ClientID %>').value != '' && document.getElementById('<%=Txt_install.ClientID%>').value == '' && document.getElementById('<%=Txt_Framing.ClientID%>').value == '') {
                //dtpvar = "0";
                //fittingvar = "0";
                //pastingvar = "0";
                framing_value = "0";
                install_value = "0";
            }

            else if (document.getElementById('<%=Txt_Dtp_charges.ClientID %>').value != '' && document.getElementById('<%=Txt_Fitting.ClientID%>').value != '' && document.getElementById('<%=Txt_Pasting.ClientID%>').value != '' && document.getElementById('<%=Txt_TransportCharges.ClientID %>').value == '' && document.getElementById('<%=Txt_install.ClientID%>').value == '' && document.getElementById('<%=Txt_Framing.ClientID%>').value != '') {
                //dtpvar = "0";
                //fittingvar = "0";
                //pastingvar = "0";
                transport_value = "0";
                install_value = "0";
            }

            else if (document.getElementById('<%=Txt_Dtp_charges.ClientID %>').value != '' && document.getElementById('<%=Txt_Fitting.ClientID%>').value != '' && document.getElementById('<%=Txt_Pasting.ClientID%>').value != '' && document.getElementById('<%=Txt_TransportCharges.ClientID %>').value == '' && document.getElementById('<%=Txt_install.ClientID%>').value != '' && document.getElementById('<%=Txt_Framing.ClientID%>').value != '') {
                //dtpvar = "0";
                //fittingvar = "0";
                //pastingvar = "0";
                transport_value = "0";
                framing_value = "0";
            }

            else if (document.getElementById('<%=Txt_Dtp_charges.ClientID %>').value != '' && document.getElementById('<%=Txt_Fitting.ClientID%>').value != '' && document.getElementById('<%=Txt_Pasting.ClientID%>').value == '' && document.getElementById('<%=Txt_TransportCharges.ClientID %>').value == '' && document.getElementById('<%=Txt_install.ClientID%>').value == '' && document.getElementById('<%=Txt_Framing.ClientID%>').value == '') {
                //dtpvar = "0";
                //fittingvar = "0";
                //pastingvar = "0";
                install_value = "0";
                pasting_value = "0";
            }

            else if (document.getElementById('<%=Txt_Dtp_charges.ClientID %>').value != '' && document.getElementById('<%=Txt_Fitting.ClientID%>').value != '' && document.getElementById('<%=Txt_Pasting.ClientID%>').value == '' && document.getElementById('<%=Txt_TransportCharges.ClientID %>').value != '' && document.getElementById('<%=Txt_install.ClientID%>').value != '' && document.getElementById('<%=Txt_Framing.ClientID%>').value == '') {
                //dtpvar = "0";
                //fittingvar = "0";
                //pastingvar = "0";
                framing_value = "0";
                pasting_value = "0";
            }

            else if (document.getElementById('<%=Txt_Dtp_charges.ClientID %>').value != '' && document.getElementById('<%=Txt_Fitting.ClientID%>').value == '' && document.getElementById('<%=Txt_Pasting.ClientID%>').value == '' && document.getElementById('<%=Txt_TransportCharges.ClientID %>').value != '' && document.getElementById('<%=Txt_install.ClientID%>').value != '' && document.getElementById('<%=Txt_Framing.ClientID%>').value != '') {
                //dtpvar = "0";
                //fittingvar = "0";
                //pastingvar = "0";
                fitting_value = "0";
                pasting_value = "0";
            }

            else if (document.getElementById('<%=Txt_Dtp_charges.ClientID %>').value == '' && document.getElementById('<%=Txt_Fitting.ClientID%>').value != '' && document.getElementById('<%=Txt_Pasting.ClientID%>').value != '' && document.getElementById('<%=Txt_TransportCharges.ClientID %>').value != '' && document.getElementById('<%=Txt_install.ClientID%>').value == '' && document.getElementById('<%=Txt_Framing.ClientID%>').value != '') {
                //dtpvar = "0";
                //fittingvar = "0";
                //pastingvar = "0";
                dtp_value = "0";
                install_value = "0";
            }

            else if (document.getElementById('<%=Txt_Dtp_charges.ClientID %>').value == '' && document.getElementById('<%=Txt_Fitting.ClientID%>').value != '' && document.getElementById('<%=Txt_Pasting.ClientID%>').value != '' && document.getElementById('<%=Txt_TransportCharges.ClientID %>').value == '' && document.getElementById('<%=Txt_install.ClientID%>').value != '' && document.getElementById('<%=Txt_Framing.ClientID%>').value == '') {
                //dtpvar = "0";
                //fittingvar = "0";
                //pastingvar = "0";
                dtp_value = "0";
                framing_value = "0";
            }

            else if (document.getElementById('<%=Txt_Dtp_charges.ClientID %>').value == '' && document.getElementById('<%=Txt_Fitting.ClientID%>').value != '' && document.getElementById('<%=Txt_Pasting.ClientID%>').value == '' && document.getElementById('<%=Txt_TransportCharges.ClientID %>').value != '' && document.getElementById('<%=Txt_install.ClientID%>').value != '' && document.getElementById('<%=Txt_Framing.ClientID%>').value != '') {
                //dtpvar = "0";
                //fittingvar = "0";
                //pastingvar = "0";
                dtp_value = "0";
                pasting_value = "0";
            }

            //5 column

            else if (document.getElementById('<%=Txt_Dtp_charges.ClientID %>').value != '' && document.getElementById('<%=Txt_Fitting.ClientID%>').value != '' && document.getElementById('<%=Txt_Pasting.ClientID%>').value != '' && document.getElementById('<%=Txt_TransportCharges.ClientID %>').value != '' && document.getElementById('<%=Txt_install.ClientID%>').value == '' && document.getElementById('<%=Txt_Framing.ClientID%>').value != '') {
                //dtpvar = "0";
                //fittingvar = "0";
                //pastingvar = "0";
                install_value = "0";
            }

            else if (document.getElementById('<%=Txt_Dtp_charges.ClientID %>').value != '' && document.getElementById('<%=Txt_Fitting.ClientID%>').value != '' && document.getElementById('<%=Txt_Pasting.ClientID%>').value != '' && document.getElementById('<%=Txt_TransportCharges.ClientID %>').value != '' && document.getElementById('<%=Txt_install.ClientID%>').value != '' && document.getElementById('<%=Txt_Framing.ClientID%>').value == '') {
                //dtpvar = "0";
                //fittingvar = "0";
                //pastingvar = "0";
                framing_value = "0";
            }

            else if (document.getElementById('<%=Txt_Dtp_charges.ClientID %>').value != '' && document.getElementById('<%=Txt_Fitting.ClientID%>').value != '' && document.getElementById('<%=Txt_Pasting.ClientID%>').value == '' && document.getElementById('<%=Txt_TransportCharges.ClientID %>').value != '' && document.getElementById('<%=Txt_install.ClientID%>').value != '' && document.getElementById('<%=Txt_Framing.ClientID%>').value != '') {
                //dtpvar = "0";
                //fittingvar = "0";
                //pastingvar = "0";
                pasting_value = "0";
            }

            else if (document.getElementById('<%=Txt_Dtp_charges.ClientID %>').value == '' && document.getElementById('<%=Txt_Fitting.ClientID%>').value != '' && document.getElementById('<%=Txt_Pasting.ClientID%>').value != '' && document.getElementById('<%=Txt_TransportCharges.ClientID %>').value != '' && document.getElementById('<%=Txt_install.ClientID%>').value != '' && document.getElementById('<%=Txt_Framing.ClientID%>').value != '') {
                //dtpvar = "0";
                //fittingvar = "0";
                //pastingvar = "0";
                dtp_value = "0";
            }

            ////////////////////////
            if (document.getElementById('<%=Txt_Dtp_charges.ClientID %>').value != '' && document.getElementById('<%=Txt_Fitting.ClientID%>').value != '' && document.getElementById('<%=Txt_Pasting.ClientID%>').value != '' && document.getElementById('<%=Txt_TransportCharges.ClientID %>').value != '' && document.getElementById('<%=Txt_install.ClientID%>').value != '' && document.getElementById('<%=Txt_Framing.ClientID%>').value != '') {

            }

            var total_dtp_transport = (parseFloat(transport_value) + parseFloat(dtp_value));

            var total_amount = (parseFloat(subtotal.value) + parseFloat(total_dtp_transport) + parseFloat(fitting_value) + parseFloat(pasting_value) + parseFloat(framing_value) + parseFloat(install_value));

           <%-- var balance = (parseFloat(total_amount) - parseFloat(advance.value) - parseFloat(discount.value));
            var roundoff = Math.round(balance);

            document.getElementById('<%=lbl_total.ClientID %>').innerHTML = roundoff;
            document.getElementById('<%=hide_total.ClientID %>').value = total_amount;
            document.getElementById('<%=lbl_final.ClientID %>').innerHTML = total_amount;--%>
            if (advance.value == "0" && discount == "0") {
                var balance = (parseFloat(total_amount))
                var roundoff = Math.round(balance);
                document.getElementById('<%=lbl_total.ClientID %>').innerHTML = roundoff

            }

            else if (advance.value != "0" || discount != "0") {
                var balance = (parseFloat(total_amount) - parseFloat(advance.value) - parseFloat(discount.value));
                var roundoff = Math.round(balance);

                document.getElementById('<%=lbl_total.ClientID %>').innerHTML = roundoff

            }
           // document.getElementById('<%=lbl_total.ClientID %>').innerHTML = roundoff;
            document.getElementById('<%=hide_total.ClientID %>').value = total_amount;
            document.getElementById('<%=lbl_final.ClientID %>').innerHTML = total_amount;
        }

    </script>

    <%--<script>
        function JSFunctionValidate3() {
            if (document.getElementById('<%=Txt_product_name.ClientID%>').value.length == 0) {
                alert("Please Enter Product Name !!!");
                return false;
            }


            if (document.getElementById('<%=Txt_ra.ClientID%>').value.length == 0) {
                alert("Please Enter Product's Rate  !!!");
                return false;
            }


            return true;
        }
    </script>--%>
    <script>
        function JSFunctionValidate() {


            if (document.getElementById('<%=Dd_customer.ClientID%>').value == "--Select--") {
                alert("Please Select Customer !!!");
                return false;
            }
            if (document.getElementById('<%=drp_designer.ClientID%>').value == "--Show Designer--") {
                alert("Please Select Designer Name !!!");
                return false;
            }
           <%-- if (document.getElementById('<%=Dd_enter_product.ClientID%>').value == "--Select--") {
                alert("Please Select Product !!!");
                return false;
            }
            if (document.getElementById('<%=Dd_material.ClientID%>').value == "--Select--") {
                alert("Please Select Material !!!");
                return false;
            }--%>
            if (document.getElementById('<%=Txt_invoice_date.ClientID%>').value.length == 0) {
                alert("Please Select Invoice Date !!!");
                return false;
            }
            if (document.getElementById('<%=Txt_due_date.ClientID%>').value.length == 0) {
                alert("Please Select Due Date !!!");
                return false;

                if (document.getElementById('<%=Txt_advance.ClientID%>').value.length == 0) {
                    alert("Please Enter Advance !!!");
                    return false;
                }
                if (document.getElementById('<%=Txt_discount.ClientID%>').value.length == 0) {
                    alert("Please Enter Discount !!!");
                    return false;
                }

                preventMultipleSubmissions();
                return true;
            }

    </script>
    <%-- <script>

            function JSFunctionValidate00() {


                if (document.getElementById('<%=Dd_customer.ClientID%>').value == "--Select--") {
                 alert("Please Select Customer !!!");
                 return false;
             }
             if (document.getElementById('<%=drp_designer.ClientID%>').value == "--Show Designer--") {
                 alert("Please Select Designer Name !!!");
                 return false;
             }
             if (document.getElementById('<%=Dd_enter_product.ClientID%>').value == "--Select--") {
                 alert("Please Select Product !!!");
                 return false;
             }
             if (document.getElementById('<%=Dd_material.ClientID%>').value == "--Select--") {
                alert("Please Select Material !!!");
                return false;
            }
            if (document.getElementById('<%=Txt_invoice_date.ClientID%>').value.length == 0) {
                alert("Please Select Invoice Date !!!");
                return false;
            }
            if (document.getElementById('<%=Txt_due_date.ClientID%>').value.length == 0) {
                alert("Please Select Due Date !!!");
                return false;
   
            if (document.getElementById('<%=Txt_advance.ClientID%>').value.length == 0) {
                alert("Please Enter Advance !!!");
                return false;
            }
                if (document.getElementById('<%=Txt_discount.ClientID%>').value.length == 0) {
                    alert("Please Enter Discount !!!");
                    return false;
                }

                preventMultipleSubmissions1();
                return true;
            }
        function JSFunctionValidate4() {


            if (document.getElementById('<%=Dd_customer.ClientID%>').selectedIndex == 0) {
                alert("Please Select Customer !!!");
                return false;
            }
            if (document.getElementById('<%=drp_designer.ClientID%>').value == "--Show Designer--") {
                alert("Please Select Designer Name !!!");
                return false;
            }
            if (document.getElementById('<%=Dd_enter_product.ClientID%>').value == "--Select--") {
                alert("Please Select Product !!!");
                return false;
            }
            if (document.getElementById('<%=Dd_material.ClientID%>').value == "--Select--") {
                alert("Please Select Material !!!");
                return false;
            }

            return true;
            var quant2 = document.getElementById('<%=txt_quantity2.ClientID %>');
            var quant = document.getElementById('<%=txt_quantity.ClientID %>');
            var height = document.getElementById('<%=txt_height.ClientID %>');
            var height2 = document.getElementById('<%=txt_height2.ClientID %>');
            var width = document.getElementById('<%=txt_width.ClientID %>');
            var width2 = document.getElementById('<%=txt_width2.ClientID %>');
           
            if (width != null) {
                if (width.value == "0") { 
                    alert("Length should  not be 0 !!!");
                    return false;
                }
        }
        if (height != null) {
            if (height.value == "0") {
                alert("Height should not be 0  !!!");
                return false;
            }
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
    </script>--%>
    <script>
</script>

    <script type="text/javascript">

            function disableTextBox() {
                document.getElementById('<%=Txt_Dtp_charges.ClientID%>').disabled = true;
                document.getElementById('<%=Txt_Pasting.ClientID%>').disabled = true;
                document.getElementById('<%=Txt_Framing.ClientID%>').disabled = true;
                document.getElementById('<%=Txt_Fitting.ClientID%>').disabled = true;
                document.getElementById('<%=Txt_install.ClientID%>').disabled = true;
                document.getElementById('<%=Txt_TransportCharges.ClientID%>').disabled = true;
                addListeners();
            }

            function toggleTextBox(e) {
                checkbox = e.target;

                if (checkbox.checked == true) {
                    if (checkbox.id == "<%=Chk_dtp.ClientID%>") {
                        document.getElementById('<%=Txt_Dtp_charges.ClientID%>').disabled = false;
                    }
                    if (checkbox.id == "<%=Chk_pasting.ClientID%>") {
                        document.getElementById('<%=Txt_Pasting.ClientID%>').disabled = false;
                    }
                    if (checkbox.id == "<%=Chk_framing.ClientID%>") {
                        document.getElementById('<%=Txt_Framing.ClientID%>').disabled = false;
                    }
                    if (checkbox.id == "<%=Chk_fitting.ClientID%>") {
                        document.getElementById('<%=Txt_Fitting.ClientID%>').disabled = false;
                    }
                    if (checkbox.id == "<%=Chk_install.ClientID%>") {
                        document.getElementById('<%=Txt_install.ClientID%>').disabled = false;
                    }
                    if (checkbox.id == "<%=Chk_trans.ClientID%>") {
                        document.getElementById('<%=Txt_TransportCharges.ClientID%>').disabled = false;
                    }
                }
                else {
               <%-- document.getElementById('<%=Txt_Dtp_charges.ClientID%>').disabled = true;
                document.getElementById('<%=Txt_Pasting.ClientID%>').disabled = true;
                document.getElementById('<%=Txt_Fitting.ClientID%>').disabled = true;
                document.getElementById('<%=Txt_TransportCharges.ClientID%>').disabled = true;--%>
                    if (checkbox.id == "<%=Chk_dtp.ClientID%>") {
                        document.getElementById('<%=Txt_Dtp_charges.ClientID%>').disabled = true;
                        document.getElementById('<%=Txt_Dtp_charges.ClientID%>').value = "0";
                        final_total();
                    }
                    if (checkbox.id == "<%=Chk_pasting.ClientID%>") {
                        document.getElementById('<%=Txt_Pasting.ClientID%>').disabled = true;
                        document.getElementById('<%=Txt_Pasting.ClientID%>').value = "0";
                        final_total();
                    }
                    if (checkbox.id == "<%=Chk_framing.ClientID%>") {
                        document.getElementById('<%=Txt_Framing.ClientID%>').disabled = true;
                        document.getElementById('<%=Txt_Framing.ClientID%>').value = "0";
                        final_total();
                    }
                    if (checkbox.id == "<%=Chk_fitting.ClientID%>") {
                        document.getElementById('<%=Txt_Fitting.ClientID%>').disabled = true;
                        document.getElementById('<%=Txt_Fitting.ClientID%>').value = "0";
                        final_total();
                    }
                    if (checkbox.id == "<%=Chk_install.ClientID%>") {
                        document.getElementById('<%=Txt_install.ClientID%>').disabled = true;
                        document.getElementById('<%=Txt_install.ClientID%>').value = "0";
                        final_total();
                    }
                    if (checkbox.id == "<%=Chk_trans.ClientID%>") {
                        document.getElementById('<%=Txt_TransportCharges.ClientID%>').disabled = true;
                        document.getElementById('<%=Txt_TransportCharges.ClientID%>').value = "0";
                        final_total();
                    }


                }
            }

            function addListeners() {
                check1 = document.getElementById('<%=Chk_dtp.ClientID%>');
                check2 = document.getElementById('<%=Chk_pasting.ClientID%>');
                check3 = document.getElementById('<%=Chk_fitting.ClientID%>');
                check4 = document.getElementById('<%=Chk_trans.ClientID%>');
                check5 = document.getElementById('<%=Chk_framing.ClientID%>');
                check6 = document.getElementById('<%=Chk_install.ClientID%>');

                check1.addEventListener('click', toggleTextBox, false);
                check2.addEventListener('click', toggleTextBox, false);
                check3.addEventListener('click', toggleTextBox, false);
                check4.addEventListener('click', toggleTextBox, false);
                check5.addEventListener('click', toggleTextBox, false);
                check6.addEventListener('click', toggleTextBox, false);

            }
            window.onload = disableTextBox;
            window.onscroll = disableTextBox;

    </script>

</asp:Content>

