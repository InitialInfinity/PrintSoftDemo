﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Daily Cash Order/Cash.master" AutoEventWireup="true" CodeFile="Create_Order.aspx.cs" Inherits="Daily_Cash_Order_Create_Order" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link href="../dist/css/select2.css" rel="stylesheet" />
    <script src="../dist/js/select2.js"></script>

    <script type="text/javascript">

        $(document).ready(function () {

            product();

        });


        function product() {

            $("#<%=Dd_enter_product.ClientID%>").select2({

                placeholder: "Select Item",

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
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <!-- Content Wrapper. Contains page content -->
    <div class="content-wrapper">
        <!-- Content Header (Page header) -->
        <section class="content-header sty-one">
            <h1>Daily Order</h1>
            <ol class="breadcrumb">
                <li><a href="#">Cash</a></li>
                <li><i class="fa fa-angle-right"></i>Daily Order</li>
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
                                        <h3 class="text-black">Daily Order<span class="pull-right"></span> </h3>
                                    </div>
                                    <!-- /.col -->
                                </div>
                                <!-- info row -->

                                <asp:HiddenField ID="Hid_inv_id" runat="server" />
                                <hr />

                                <div class="form-group row">
                                    <label class="control-label text-right col-md-3">Name<span style="color: red;">*</span></label>
                                    <div class="col-md-6">
                                        <asp:TextBox ID="Txt_name" class="form-control" runat="server" TabIndex="2"></asp:TextBox>

                                    </div>
                                </div>

                                <div class="form-group row">
                                    <label class="control-label text-right col-md-3">Phone<span style="color: red;">*</span></label>
                                    <div class="col-md-6">
                                        <asp:TextBox ID="Txt_phone" class="form-control" runat="server" TabIndex="2"></asp:TextBox>

                                    </div>
                                </div>

                                <div class="form-group row">

                                    <div class="col-md-5">
                                        <asp:Label ID="Label1" runat="server">Product<span style="color:red;">*</span></asp:Label>
                                    </div>
                                    <div class="col-md-6">
                                        <asp:Label ID="Label2" runat="server" Text="Description"></asp:Label>
                                    </div>


                                </div>


                                <div class="form-group row">

                                    <div class="col-md-5">

                                        <script>
                                            Sys.Application.add_load(product);
                                        </script>

                                        <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                            <ContentTemplate>
                                                <asp:DropDownList ID="Dd_enter_product" class="form-control" runat="server" AutoPostBack="True" OnSelectedIndexChanged="Dd_enter_product_SelectedIndexChanged"></asp:DropDownList>

                                            </ContentTemplate>
                                        </asp:UpdatePanel>



                                        <asp:LinkButton ID="LinkButton2" Class="add_class" data-toggle="modal" data-target="#myModal2" runat="server">+Add Product</asp:LinkButton>
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
                                                    <asp:TextBox ID="txt_width" OnkeyUp="sqrft(); rate();quan_amount(); " onchange="sqrft(); rate();quan_amount();" class="form-control" runat="server" TextMode="Number" min="0"></asp:TextBox></td>
                                                <td>
                                                    <asp:TextBox ID="txt_height" OnkeyUp="sqrft(); rate();quan_amount(); " onchange="sqrft(); rate();quan_amount(); " class="form-control" runat="server" TextMode="Number" min="0"></asp:TextBox></td>
                                                <td>
                                                    <asp:TextBox ID="txt_sqrft" onkeydown="javascript:return false" OnkeyUp="sqrft(); rate();quan_amount(); " onchange="sqrft(); rate();quan_amount();" class="form-control" runat="server" TextMode="Number" min="0"></asp:TextBox></td>
                                                <td>
                                                    <asp:TextBox ID="txt_rate" Onkeyup="sqrft(); rate();quan_amount(); " onchange="sqrft(); rate();quan_amount(); " class="form-control" runat="server" TextMode="Number"></asp:TextBox></td>
                                                <td>
                                                    <asp:TextBox ID="txt_amount" class="form-control" runat="server" onkeydown="javascript:return false" TextMode="Number"></asp:TextBox></td>
                                                <td>
                                                    <asp:TextBox ID="txt_quantity" OnkeyUp="sqrft(); rate();quan_amount(); " onchange="sqrft(); rate();quan_amount(); " class="form-control" runat="server" TextMode="Number" min="0"></asp:TextBox></td>

                                                <td>
                                                    <asp:TextBox ID="txt_total_amt" onkeydown="javascript:return false" onchange=" " class="form-control" runat="server" TextMode="Number"></asp:TextBox></td>
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
                                                    <asp:TextBox ID="txt_rate2" Onkeyup="quan_amount2();" onchange="quan_amount2(); " class="form-control" runat="server" TextMode="Number"></asp:TextBox></td>
                                                <td>
                                                    <asp:TextBox ID="txt_amount2" disabled="true" onkeydown="javascript:return false" class="form-control" runat="server" TextMode="Number"></asp:TextBox></td>
                                                <td>
                                                    <asp:TextBox ID="txt_quantity2" OnkeyUp="quan_amount2(); " onchange="quan_amount2();" class="form-control" runat="server" TextMode="Number" min="0"></asp:TextBox></td>
                                                <td>
                                                    <asp:TextBox ID="txt_total_amt2" onkeydown="javascript:return false" class="form-control" runat="server" TextMode="Number"></asp:TextBox></td>
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
                                                <asp:LinkButton ID="Btn_cart" Style="margin-right: 5px;" OnClientClick="return JSFunctionValidate4();" OnClick="Btn_cart_Click" runat="server"><i style="padding-left:10px; font-size:40px;" class="fa fa-plus-circle"></i></asp:LinkButton>
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
                                        <%-- <p class="lead" >Total Remaining Balance: ₹ <asp:Label ID="lbl_total_remaining"  style="font-size:20px; color:#ed0505;" runat="server" Text=""></asp:Label></p>--%>

                                        <asp:HiddenField ID="lbl_cutomer_contact" runat="server" />
                                        <asp:HiddenField ID="lbl_cutomer_email" runat="server" />
                                        <asp:HiddenField ID="lbl_product_hsn" runat="server" />
                                        <asp:HiddenField ID="lbl_unit" runat="server" />
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
                                                            <asp:TextBox ID="Txt_shipping" onkeyup="final_total();" class="form-control" runat="server" ></asp:TextBox></td>
                                                    </tr>
                                                    <tr>
                                                        <th>Advance:</th>
                                                        <td>
                                                            <asp:TextBox ID="Txt_advance" onkeyup="final_total();" onchange="final_total();"  class="form-control" runat="server" TextMode="Number"></asp:TextBox></td>
                                                    </tr>
                                                    <tr>
                                                        <th>Advance:</th>
                                                        <td>
                                                            <asp:TextBox ID="Txt_advance" onkeyup="final_total();" onchange="final_total();" class="form-control" runat="server" TextMode="Number" TabIndex="24"></asp:TextBox>
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidatorAdvance" runat="server" ErrorMessage="Please Enter Advance.." ControlToValidate="Txt_advance" Display="Dynamic" ValidationGroup="g1"></asp:RequiredFieldValidator>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <th>Discount:</th>
                                                        <td>
                                                            <asp:TextBox ID="Txt_discount" onkeyup="final_total();" onchange="final_total();"  class="form-control" runat="server" TextMode="Number"></asp:TextBox></td>
                                                    </tr>
                                                    <tr>
                                                        <th>Payment Method:</th>
                                                        <td>
                                                            <asp:DropDownList ID="drp_payment"  class="form-control"  runat="server" TabIndex="26">

                                                                <asp:ListItem Selected="True">Cash</asp:ListItem>
                                                                <asp:ListItem>Cheque</asp:ListItem>
                                                                <asp:ListItem>Paytm</asp:ListItem>
                                                                <asp:ListItem>Google Pay</asp:ListItem>
                                                                <asp:ListItem>Phone Pay</asp:ListItem>
                                                            </asp:DropDownList>

                                                        </td>
                                                    </tr>
                                                     <tr>
                                                        <th>Final Amount:</th>
                                                        <td class="grand_total">₹ <asp:Label ID="lbl_final" runat="server" Text=""></asp:Label></td>
                                                        
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
                                                    Pasting &nbsp<asp:CheckBox ID="Chk_framing" runat="server" />
                                                    Framing <%--<asp:CheckBox ID="CheckBox7" runat="server" />--%> Charges:</th>



                                                <th scope="col">
                                                    <asp:CheckBox ID="Chk_fitting" runat="server" />
                                                    Fitting &nbsp<asp:CheckBox ID="Chk_install" runat="server" />
                                                    Installation <%--<asp:CheckBox ID="CheckBox5" runat="server" />--%> Charges:</th>


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
                                                    <asp:TextBox ID="Txt_Fitting" onkeyup="final_total();" class="form-control" runat="server" TabIndex="22" TextMode="Number" min="0"></asp:TextBox></td>


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

                                                <th scope="col">
                                                    <asp:CheckBox ID="Chk_trans" runat="server" />
                                                    Transport charges:</th>
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
                                                    <asp:TextBox ID="Txt_TransportCharges" onkeyup="final_total();" class="form-control" runat="server" TabIndex="23" TextMode="Number" min="0"></asp:TextBox></td>
                                                <td>
                                                    <asp:TextBox ID="Txt_advance" onkeyup="final_total();" onchange="final_total();" class="form-control" runat="server" TextMode="Number" TabIndex="24" min="0"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidatorAdvance" runat="server" ErrorMessage="Please Enter Advance.." ControlToValidate="Txt_advance" Display="Dynamic" ValidationGroup="g1"></asp:RequiredFieldValidator>
                                                </td>

                                                <td>
                                                    <asp:TextBox ID="Txt_discount" onkeyup="final_total();" onchange="final_total();" class="form-control" runat="server" TextMode="Number" TabIndex="25" min="0"></asp:TextBox>
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
                                                <%-- <th scope="col">Total GST:</th>--%>
                                                <th scope="col">Final Amount:</th>
                                                <th scope="col">Balance Amount:</th>


                                            </tr>
                                        </thead>
                                        <tbody>

                                            <tr>
                                                <td>₹
                                                    <asp:Label ID="lbl_subtotal" runat="server" Text=""></asp:Label></td>
                                                <asp:HiddenField ID="lbl_subtotal2" runat="server" />
                                                <%--<td>
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
                                    <div class="col-lg-11 py-2">
                                        <asp:Label ID="Lbl_message" runat="server" Text=""></asp:Label>
                                        <asp:Button ID="Btn_submit_payment" class="btn btn-success pull-right" runat="server" Text="Save & Close" OnClientClick="return JSFunctionValidate00();" OnClick="Btn_submit_payment_Click" />
                                        <asp:Button ID="Btn_generate_pdf" class="btn btn-primary pull-right" Style="margin-right: 5px;" runat="server" Text="Save Order" OnClientClick="return JSFunctionValidate();" OnClick="Btn_generate_pdf_Click" TabIndex="1" />


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

    <!-- Modal -->
    <div class="modal fade" id="myModal2" role="dialog">
        <div class="modal-dialog">

            <!-- Modal content-->
            <div class="modal-content">
                <div class="modal-header">
                    <h4 class="modal-title">Add Sale Product</h4>
                    <button type="button" class="close" data-dismiss="modal">&times;</button>

                </div>
                 <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                            <ContentTemplate>
                <div class="modal-body">

                    <div class="form-body">

                       <%-- <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                            <ContentTemplate>--%>
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
                                        <asp:TextBox ID="Txt_ra" placeholder="Rate" class="form-control" runat="server" TextMode="Number"></asp:TextBox>
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
        function sqrft() {
            var first = document.getElementById('<%= txt_height.ClientID %>');
            var second = document.getElementById('<%= txt_width.ClientID %>');
            var sqrft = document.getElementById('<%= txt_sqrft.ClientID %>');
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

            var pasting = document.getElementById('<%=Txt_Pasting.ClientID%>');
            var pasting_value = parseFloat(pasting.value);


            if (document.getElementById('<%=Txt_Dtp_charges.ClientID %>').value == '' && document.getElementById('<%=Txt_Fitting.ClientID%>').value == '' && document.getElementById('<%=Txt_Pasting.ClientID%>').value == '' && document.getElementById('<%=Txt_TransportCharges.ClientID %>').value == '') {
                //dtpvar = "0";
                //fittingvar = "0";
                //pastingvar = "0";
                dtp_value = "0";
                fitting_value = "0";
                pasting_value = "0";
                transport_value = "0";
            }

            else if (document.getElementById('<%=Txt_Dtp_charges.ClientID %>').value != '' && document.getElementById('<%=Txt_Fitting.ClientID%>').value == '' && document.getElementById('<%=Txt_Pasting.ClientID%>').value == '' && document.getElementById('<%=Txt_TransportCharges.ClientID %>').value == '') {
                //dtpvar = "0";
                //fittingvar = "0";
                //pastingvar = "0";
                fitting_value = "0";
                pasting_value = "0";
                transport_value = "0";
            }

            else if (document.getElementById('<%=Txt_Dtp_charges.ClientID %>').value == '' && document.getElementById('<%=Txt_Fitting.ClientID%>').value == '' && document.getElementById('<%=Txt_Pasting.ClientID%>').value != '' && document.getElementById('<%=Txt_TransportCharges.ClientID %>').value == '') {
                //dtpvar = "0";
                //fittingvar = "0";
                //pastingvar = "0";
                fitting_value = "0";
                dtp_value = "0";
                transport_value = "0";
            }

            else if (document.getElementById('<%=Txt_Dtp_charges.ClientID %>').value == '' && document.getElementById('<%=Txt_Fitting.ClientID%>').value != '' && document.getElementById('<%=Txt_Pasting.ClientID%>').value == '' && document.getElementById('<%=Txt_TransportCharges.ClientID %>').value == '') {
                //dtpvar = "0";
                //fittingvar = "0";
                //pastingvar = "0";
                dtp_value = "0";
                pasting_value = "0";
                transport_value = "0";
            }

            else if (document.getElementById('<%=Txt_Dtp_charges.ClientID %>').value == '' && document.getElementById('<%=Txt_Fitting.ClientID%>').value == '' && document.getElementById('<%=Txt_Pasting.ClientID%>').value == '' && document.getElementById('<%=Txt_TransportCharges.ClientID %>').value != '') {
                //dtpvar = "0";
                //fittingvar = "0";
                //pastingvar = "0";
                dtp_value = "0";
                pasting_value = "0";
                fitting_value = "0";
            }

            else if (document.getElementById('<%=Txt_Dtp_charges.ClientID %>').value != '' && document.getElementById('<%=Txt_Fitting.ClientID%>').value == '' && document.getElementById('<%=Txt_Pasting.ClientID%>').value != '' && document.getElementById('<%=Txt_TransportCharges.ClientID %>').value == '') {
                //dtpvar = "0";
                //fittingvar = "0";
                //pastingvar = "0";
                transport_value = "0";
                fitting_value = "0";
            }

            else if (document.getElementById('<%=Txt_Dtp_charges.ClientID %>').value != '' && document.getElementById('<%=Txt_Fitting.ClientID%>').value != '' && document.getElementById('<%=Txt_Pasting.ClientID%>').value == '' && document.getElementById('<%=Txt_TransportCharges.ClientID %>').value == '') {
                //dtpvar = "0";
                //fittingvar = "0";
                //pastingvar = "0";
                transport_value = "0";
                pasting_value = "0";
            }

            else if (document.getElementById('<%=Txt_Dtp_charges.ClientID %>').value != '' && document.getElementById('<%=Txt_Fitting.ClientID%>').value == '' && document.getElementById('<%=Txt_Pasting.ClientID%>').value == '' && document.getElementById('<%=Txt_TransportCharges.ClientID %>').value != '') {
                //dtpvar = "0";
                //fittingvar = "0";
                //pastingvar = "0";
                fitting_value = "0";
                pasting_value = "0";
            }

            else if (document.getElementById('<%=Txt_Dtp_charges.ClientID %>').value == '' && document.getElementById('<%=Txt_Fitting.ClientID%>').value != '' && document.getElementById('<%=Txt_Pasting.ClientID%>').value != '' && document.getElementById('<%=Txt_TransportCharges.ClientID %>').value == '') {
                //dtpvar = "0";
                //fittingvar = "0";
                //pastingvar = "0";
                dtp_value = "0";
                transport_value = "0";
            }

            else if (document.getElementById('<%=Txt_Dtp_charges.ClientID %>').value == '' && document.getElementById('<%=Txt_Fitting.ClientID%>').value == '' && document.getElementById('<%=Txt_Pasting.ClientID%>').value != '' && document.getElementById('<%=Txt_TransportCharges.ClientID %>').value != '') {
                //dtpvar = "0";
                //fittingvar = "0";
                //pastingvar = "0";
                dtp_value = "0";
                fitting_value = "0";

            }

            else if (document.getElementById('<%=Txt_Dtp_charges.ClientID %>').value == '' && document.getElementById('<%=Txt_Fitting.ClientID%>').value != '' && document.getElementById('<%=Txt_Pasting.ClientID%>').value == '' && document.getElementById('<%=Txt_TransportCharges.ClientID %>').value != '') {
                //dtpvar = "0";
                //fittingvar = "0";
                //pastingvar = "0";
                dtp_value = "0";
                pasting_value = "0";

            }

            else if (document.getElementById('<%=Txt_Dtp_charges.ClientID %>').value != '' && document.getElementById('<%=Txt_Fitting.ClientID%>').value != '' && document.getElementById('<%=Txt_Pasting.ClientID%>').value != '' && document.getElementById('<%=Txt_TransportCharges.ClientID %>').value == '') {
                //dtpvar = "0";
                //fittingvar = "0";
                //pastingvar = "0";
                transport_value = "0";

            }

            else if (document.getElementById('<%=Txt_Dtp_charges.ClientID %>').value != '' && document.getElementById('<%=Txt_Fitting.ClientID%>').value != '' && document.getElementById('<%=Txt_Pasting.ClientID%>').value == '' && document.getElementById('<%=Txt_TransportCharges.ClientID %>').value != '') {
                //dtpvar = "0";
                //fittingvar = "0";
                //pastingvar = "0";
                pasting_value = "0";

            }

            else if (document.getElementById('<%=Txt_Dtp_charges.ClientID %>').value != '' && document.getElementById('<%=Txt_Fitting.ClientID%>').value == '' && document.getElementById('<%=Txt_Pasting.ClientID%>').value != '' && document.getElementById('<%=Txt_TransportCharges.ClientID %>').value != '') {
                //dtpvar = "0";
                //fittingvar = "0";
                //pastingvar = "0";
                fitting_value = "0";

            }

            else if (document.getElementById('<%=Txt_Dtp_charges.ClientID %>').value == '' && document.getElementById('<%=Txt_Fitting.ClientID%>').value != '' && document.getElementById('<%=Txt_Pasting.ClientID%>').value != '' && document.getElementById('<%=Txt_TransportCharges.ClientID %>').value != '') {
                //dtpvar = "0";
                //fittingvar = "0";
                //pastingvar = "0";

                dtp_value = "0";

            }

            if (document.getElementById('<%=Txt_Dtp_charges.ClientID %>').value != '' && document.getElementById('<%=Txt_Fitting.ClientID%>').value != '' && document.getElementById('<%=Txt_Pasting.ClientID%>').value != '' && document.getElementById('<%=Txt_TransportCharges.ClientID %>').value != '') {

            }

            var total_dtp_transport = (parseFloat(transport_value) + parseFloat(dtp_value));



            var total_amount = (parseFloat(subtotal.value) + parseFloat(total_dtp_transport) + parseFloat(fitting_value) + parseFloat(pasting_value));






            //var balance = (parseFloat(total_amount) - parseFloat(advance.value) - parseFloat(discount.value));
            //var roundoff = Math.round(balance);


           <%-- if (advance.value == "0") {
                var balance = (parseFloat(total_amount))
                var roundoff = Math.round(balance);
                document.getElementById('<%=lbl_total.ClientID %>').innerHTML = roundoff
            }

            else if (discount == "0") {
                var balance = (parseFloat(total_amount))
                var roundoff = Math.round(balance);
                document.getElementById('<%=lbl_total.ClientID %>').innerHTML = roundoff
            }--%>
            if (advance.value == "0" && discount == "0") {
                var balance = (parseFloat(total_amount))
                var roundoff = Math.round(balance);
                document.getElementById('<%=lbl_total.ClientID %>').innerHTML = roundoff

             }
           <%-- else if (advance.value != "0") {
                var balance = (parseFloat(total_amount) - parseFloat(advance.value))
                var roundoff = Math.round(balance);
                document.getElementById('<%=lbl_total.ClientID %>').innerHTML = roundoff
            }--%>

            <%--else if (discount != "0") {
                var balance = (parseFloat(total_amount)- parseFloat(discount.value))
                var roundoff = Math.round(balance);
                document.getElementById('<%=lbl_total.ClientID %>').innerHTML = roundoff
            }--%>
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
    <script>
        function JSFunctionValidate() {



            if (document.getElementById('<%=Txt_name.ClientID%>').value.length == 0) {
                alert("Please Enter Name !!!");
                return false;
            }
            if (document.getElementById('<%=Txt_phone.ClientID%>').value.length == 0) {
                alert("Please Enter Contact No !!!");
                return false;
            }
            <%--if (document.getElementById('<%=txt_height.ClientID%>') != null) {
                if (document.getElementById('<%=txt_height.ClientID%>').value == "0") {
                    alert("Height should not be 0  !!!");
                    return false;
                }
            }
            if (document.getElementById('<%=txt_width.ClientID%>') != null) {
                if (document.getElementById('<%=txt_width.ClientID%>').value == "0") {
                    alert("Length should  not be 0 !!!");
                    return false;
                }
            }
            if (document.getElementById('<%=txt_quantity.ClientID%>') != null) {
                if (document.getElementById('<%=txt_quantity.ClientID%>').value == "0") {
                    alert("Please Enter Quantity !!!");
                    return false;
                }
            }
            if (document.getElementById('<%=txt_quantity2.ClientID%>') != null)
            {
                if (document.getElementById('<%=txt_quantity2.ClientID%>').value == "0") {
                    alert("Please Enter Quantity !!!");
                    return false;
                }
            }--%>
           <%-- if (document.getElementById('<%=Dd_enter_product.ClientID%>').value == "--Select--") {
                alert("Please Select Product !!!");
                return false;
            }--%>
            if (document.getElementById('<%=Txt_discount.ClientID%>').value.length == 0) {
                alert("Please Enter Discount !!!");
                return false;
            }
            preventMultipleSubmissions();
            return true;
        }
        function JSFunctionValidate00() {



            if (document.getElementById('<%=Txt_name.ClientID%>').value.length == 0) {
                alert("Please Enter Name !!!");
                return false;
            }
            if (document.getElementById('<%=Txt_phone.ClientID%>').value.length == 0) {
                alert("Please Enter Contact No !!!");
                return false;
            }
            <%--if (document.getElementById('<%=txt_height.ClientID%>') != null) {
                if (document.getElementById('<%=txt_height.ClientID%>').value == "0") {
                    alert("Height should not be 0  !!!");
                    return false;
                }
            }
            if (document.getElementById('<%=txt_width.ClientID%>') != null) {
                if (document.getElementById('<%=txt_width.ClientID%>').value == "0") {
                    alert("Length should  not be 0 !!!");
                    return false;
                }
            }
            if (document.getElementById('<%=txt_quantity.ClientID%>') != null) {
                if (document.getElementById('<%=txt_quantity.ClientID%>').value == "0") {
                    alert("Please Enter Quantity !!!");
                    return false;
                }
            }
            if (document.getElementById('<%=txt_quantity2.ClientID%>') != null)
            {
                if (document.getElementById('<%=txt_quantity2.ClientID%>').value == "0") {
                    alert("Please Enter Quantity !!!");
                    return false;
                }
            }--%>
            <%--if (document.getElementById('<%=Dd_enter_product.ClientID%>').value == "--Select--") {
                alert("Please Select Product !!!");
                return false;
            }--%>
            if (document.getElementById('<%=Txt_discount.ClientID%>').value.length == 0) {
                alert("Please Enter Discount !!!");
                return false;
            }
            preventMultipleSubmissions1();
            return true;
        }
        function JSFunctionValidate4() {

            var quant2 = document.getElementById('<%=txt_quantity2.ClientID %>');
            var quant = document.getElementById('<%=txt_quantity.ClientID %>');
            var height = document.getElementById('<%=txt_height.ClientID %>');
            var height2 = document.getElementById('<%=txt_height2.ClientID %>');
            var width = document.getElementById('<%=txt_width.ClientID %>');
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

            if (document.getElementById('<%=Txt_name.ClientID%>').value.length == 0) {
                alert("Please Enter Name !!!");
                return false;
            }
            if (document.getElementById('<%=Txt_phone.ClientID%>').value.length == 0) {
                alert("Please Enter Contact No !!!");
                return false;
            }
            if (document.getElementById('<%=Dd_enter_product.ClientID%>').value == "--Select--") {
                alert("Please Select Product !!!");
                return false;
            }

            //if (height2 != null) {
            //    if (height2.value == "0") {
            //        alert("Height Should NOT BE 0 !!!");
            //        return false;
            //    }
            //}
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

    <script type="text/javascript">

        function disableTextBox() {
            document.getElementById('<%=Txt_Dtp_charges.ClientID%>').disabled = true;
            document.getElementById('<%=Txt_Pasting.ClientID%>').disabled = true;
            document.getElementById('<%=Txt_Fitting.ClientID%>').disabled = true;
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
                    document.getElementById('<%=Txt_Pasting.ClientID%>').disabled = false;
                }
                if (checkbox.id == "<%=Chk_fitting.ClientID%>") {
                    document.getElementById('<%=Txt_Fitting.ClientID%>').disabled = false;
                }
                if (checkbox.id == "<%=Chk_install.ClientID%>") {
                    document.getElementById('<%=Txt_Fitting.ClientID%>').disabled = false;
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
                    document.getElementById('<%=Txt_Pasting.ClientID%>').disabled = true;
                    document.getElementById('<%=Txt_Pasting.ClientID%>').value = "0";
                    final_total();
                }
                if (checkbox.id == "<%=Chk_fitting.ClientID%>") {
                    document.getElementById('<%=Txt_Fitting.ClientID%>').disabled = true;
                    document.getElementById('<%=Txt_Fitting.ClientID%>').value = "0";
                    final_total();
                }
                if (checkbox.id == "<%=Chk_install.ClientID%>") {
                    document.getElementById('<%=Txt_Fitting.ClientID%>').disabled = true;
                    document.getElementById('<%=Txt_Fitting.ClientID%>').value = "0";
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
    </div>
</asp:Content>

