<%@ Page Title="" Language="C#" MasterPageFile="~/Purchase/Purchase.master" AutoEventWireup="true" CodeFile="purchase_invoice.aspx.cs" Inherits="Purchase_purchase_invoice" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">

    <script type="text/javascript">

        var isSubmitted = false;

        function preventMultipleSubmissions() {

            if (!isSubmitted) {

                $('#<%=Btn_generate_pdf.ClientID %>').val('Submitting.. Plz Wait..');

                isSubmitted = true;

                return true;

            }
           <%--else if (!isSubmitted) {

                $('#<%=Btn_submit_payment.ClientID %>').val('Submitting.. Plz Wait..');

                  isSubmitted = true;

                  return true;

              }--%>
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
            <h1>Purchase Invoice</h1>
            <ol class="breadcrumb">
                <li><a href="#">Purchase</a></li>
                <li><i class="fa fa-angle-right"></i>Purchase Invoice</li>
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
                                <!-- info row -->
                                <div class="customer_name  row">
                                    <label class="control-label text-right col-md-3">Vendor Name<span style="color: red;">*</span></label>
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
                                        <asp:TextBox ID="Txt_invoice" class="form-control" disabled="true" runat="server"></asp:TextBox>
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
                                        <asp:TextBox ID="Txt_invoice_date" class="form-control" runat="server" TextMode="Date" TabIndex="2"></asp:TextBox>
                                    </div>
                                    <label class="control-label text-right col-md-1">Due Date</label>
                                    <div class="col-md-2">
                                        <asp:TextBox ID="Txt_due_date" class="form-control" runat="server" TextMode="Date" TabIndex="3"></asp:TextBox>
                                    </div>
                                </div>
                                <hr />
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
                                        <asp:DropDownList ID="Dd_enter_product" class="form-control" runat="server" AutoPostBack="True" OnSelectedIndexChanged="Dd_enter_product_SelectedIndexChanged" TabIndex="4"></asp:DropDownList>
                                        <asp:LinkButton ID="LinkButton2" Class="add_class" data-toggle="modal" data-target="#myModal2" runat="server">+Add Product</asp:LinkButton>
                                    </div>
                                    <div class="col-md-6">
                                        <asp:TextBox ID="Txt_description" Rows="2" class="form-control" runat="server" TextMode="MultiLine" TabIndex="5"></asp:TextBox>
                                    </div>


                                </div>

                                <div class="form-group row">

                                    <div class="col-md-3">
                                    </div>

                                </div>

                                <table class="table">
                                    <%--   <asp:Panel ID="Panel1" runat="server">
                                    <thead>
                                        <tr>

                                          
                                            <th scope="col">Rate</th>
                                           
                                            <th scope="col">Quantity<span style="color:red;">*</span></th>
                                            <th scope="col">Total</th>
                                        </tr>
                                    </thead>
                                    <tbody>
                                        <tr>

                                            <td>
                                                <asp:TextBox ID="txt_rate" Onkeyup="sqrft(); rate();quan_amount(); gst();" onchange="sqrft(); rate();quan_amount(); gst();" class="form-control" runat="server" TextMode="Number" TabIndex="9"></asp:TextBox></td>
                                                                                     <td>
                                                <asp:TextBox ID="txt_quantity" OnkeyUp="sqrft(); rate();quan_amount(); gst();" onchange="sqrft(); rate();quan_amount(); gst();" class="form-control" runat="server" TextMode="Number" TabIndex="11"></asp:TextBox></td>
                                            <td>
                                                <asp:TextBox ID="txt_total_amt" onkeyup="gst();" onchange="gst();" class="form-control" runat="server" TextMode="Number" TabIndex="11"></asp:TextBox></td>
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

                                                <th scope="col" style="display: none">Height</th>
                                                <th scope="col" style="display: none">Width</th>
                                                <th scope="col" style="display: none">Size</th>
                                                <th scope="col">Rate</th>
                                                <th scope="col" style="display: none">Amount</th>
                                                <th scope="col">Quantity<span style="color: red;">*</span></th>
                                                <th scope="col">Total</th>
                                            </tr>
                                        </thead>
                                        <tbody>
                                            <tr>

                                                <td style="display: none">
                                                    <asp:TextBox ID="txt_height" OnkeyUp="sqrft(); rate();quan_amount(); gst();" onchange="sqrft(); rate();quan_amount(); gst();" class="form-control" runat="server" TextMode="Number" min="0" TabIndex="6"></asp:TextBox></td>
                                                <td style="display: none">
                                                    <asp:TextBox ID="txt_width" OnkeyUp="sqrft(); rate();quan_amount(); gst();" onchange="sqrft(); rate();quan_amount(); gst();" class="form-control" runat="server" TextMode="Number" TabIndex="7" min="0"></asp:TextBox></td>
                                                <td style="display: none">
                                                    <asp:TextBox ID="txt_sqrft" onkeydown="javascript:return false" OnkeyUp="sqrft(); rate();quan_amount(); gst();" onchange="sqrft(); rate();quan_amount(); gst();" class="form-control" runat="server" TextMode="Number" TabIndex="8"></asp:TextBox></td>
                                                <td>
                                                    <asp:TextBox ID="txt_rate" Onkeyup="sqrft(); rate();quan_amount(); gst();" onchange="sqrft(); rate();quan_amount(); gst();" class="form-control" runat="server" TabIndex="9"></asp:TextBox></td>
                                                <td style="display: none">
                                                    <asp:TextBox ID="txt_amount" onkeydown="javascript:return false" class="form-control" runat="server" TextMode="Number" TabIndex="10"></asp:TextBox></td>
                                                <td>
                                                    <asp:TextBox ID="txt_quantity" OnkeyUp="sqrft(); rate();quan_amount(); gst();" onchange="sqrft(); rate();quan_amount(); gst();" class="form-control" runat="server" TextMode="Number" min="0" TabIndex="11"></asp:TextBox></td>
                                                <td>
                                                    <asp:TextBox ID="txt_total_amt" onkeydown="javascript:return false" onkeyup="gst();" onchange="gst();" class="form-control" runat="server" TabIndex="11"></asp:TextBox></td>
                                            </tr>

                                        </tbody>
                                    </asp:Panel>
                                    <asp:Panel ID="Panel2" runat="server">
                                        <thead>
                                            <tr>

                                                <th scope="col" style="display: none">Height</th>
                                                <th scope="col" style="display: none">Width</th>
                                                <th scope="col" style="display: none">Size</th>
                                                <th scope="col">Rate</th>
                                                <th scope="col" style="display: none">Amount</th>
                                                <th scope="col">Quantity<span style="color: red;">*</span></th>
                                                <th scope="col">Total</th>
                                            </tr>
                                        </thead>
                                        <tbody>
                                            <tr>
                                                <td>
                                                    <asp:TextBox ID="txt_rate2" Onkeyup="quan_amount2(); gst();" onchange="quan_amount2(); gst();" class="form-control" runat="server"></asp:TextBox>

                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txt_quantity2" OnkeyUp="quan_amount2(); gst();" onchange="quan_amount2(); gst();" class="form-control" runat="server" min="0" TextMode="Number"></asp:TextBox>

                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txt_total_amt2" onkeydown="javascript:return false" onkeyup="gst();" onchange="gst();" class="form-control" runat="server"></asp:TextBox>

                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txt_height2" Style="display: none" class="form-control" runat="server" TextMode="Number" min="0"></asp:TextBox></td>
                                                <td>
                                                    <asp:TextBox ID="txt_width2" Style="display: none" class="form-control" runat="server" TextMode="Number" min="0"></asp:TextBox></td>
                                                <td>
                                                    <asp:TextBox ID="txt_sqrft2" onkeydown="javascript:return false" Style="display: none" class="form-control" runat="server" TextMode="Number"></asp:TextBox></td>

                                                <td>
                                                    <asp:TextBox ID="txt_amount2" onkeydown="javascript:return false" Style="display: none" class="form-control" runat="server"></asp:TextBox></td>


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
                                                <asp:TextBox ID="txt_cgst" class="form-control" OnkeyUp="quan_amount2(); sqrft(); rate(); quan_amount(); gst(); " onchange="quan_amount2(); sqrft(); rate(); quan_amount(); gst();" runat="server" TextMode="Number" min="0" TabIndex="12"></asp:TextBox></td>
                                            <td>
                                                <asp:TextBox ID="txt_sgst" class="form-control" OnkeyUp="quan_amount2(); sqrft(); rate(); quan_amount(); gst(); " onchange="quan_amount2(); sqrft(); rate(); quan_amount(); gst();" runat="server" TextMode="Number" min="0" TabIndex="13"></asp:TextBox></td>
                                            <td>
                                                <asp:TextBox ID="txt_igst" class="form-control" OnkeyUp="quan_amount2(); sqrft(); rate(); quan_amount(); gst(); " onchange="quan_amount2(); sqrft(); rate(); quan_amount(); gst();" runat="server" TextMode="Number" min="0" TabIndex="15"></asp:TextBox></td>
                                            <td>
                                                <asp:TextBox ID="txt_final_amt" onkeydown="javascript:return false" class="form-control" runat="server" TabIndex="16"></asp:TextBox></td>
                                            <td>
                                                <asp:LinkButton ID="Btn_cart" Style="margin-right: 5px;" OnClientClick="return JSFunctionValidate4();" OnClick="Btn_cart_Click" runat="server"><i style="padding-left:10px; font-size:40px;" class="fa fa-plus-circle" tabindex="17"></i></asp:LinkButton>
                                            </td>

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
                                        <p class="lead">
                                            Total Qty:
                                            <asp:Label ID="lbl_totalqty" runat="server" Text=""></asp:Label>
                                        </p>


                                        </p>
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
                                                        <th>Shipping:</th>
                                                        <td>
                                                            <asp:TextBox ID="Txt_shipping" onkeyup="final_total();" onchange="final_total();" class="form-control" runat="server" TextMode="Number" min="0" TabIndex="18"></asp:TextBox></td>
                                                    </tr>
                                                    <tr>
                                                        <th>Advance:</th>
                                                        <td>
                                                            <asp:TextBox ID="Txt_adjustment" onkeyup="final_total();" onchange="final_total();" class="form-control" runat="server" TextMode="Number" min="0" TabIndex="19"></asp:TextBox></td>
                                                    </tr>
                                                    <tr>
                                                        <th>Discount:</th>
                                                        <td>
                                                            <asp:TextBox ID="Txt_discount" onkeyup="final_total();" onchange="final_total();" class="form-control" runat="server" TextMode="Number" min="0" TabIndex="20"></asp:TextBox></td>
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
                                    <div class="col-lg-11 py-2 ml-4">
                                        <asp:Label ID="Lbl_message" runat="server" Text=""></asp:Label>
                                        <asp:Button ID="Btn_submit_payment" class="btn btn-success pull-right" runat="server" OnClientClick="return JSFunctionValidate00();" Text="Save & Close" OnClick="Btn_submit_payment_Click" TabIndex="22" />
                                        <asp:Button ID="Btn_generate_pdf" class="btn btn-primary pull-right" Style="margin-right: 5px;" runat="server" Text="Save Invoice" OnClientClick="return JSFunctionValidate();" OnClick="Btn_generate_pdf_Click" TabIndex="1" />


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

    <!-- Modal -->
    <div class="modal fade" id="myModal" role="dialog">
        <div class="modal-dialog">

            <!-- Modal content-->
            <div class="modal-content">
                <div class="modal-header">
                    <h4 class="modal-title">Add Vendor</h4>
                    <button type="button" class="close" data-dismiss="modal">&times;</button>

                </div>
                <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                    <ContentTemplate>
                <div class="modal-body">
                    <div class="form-body">
                        <div class="form-group row">
                            <label class="control-label text-right col-md-3">Vendor Name<span style="color: red;">*</span></label>
                            <div class="col-md-9">

                                <asp:TextBox ID="Txt_vendor_name" placeholder="Vendor Name" class="form-control" runat="server"></asp:TextBox>
                            </div>
                        </div>

                        <div class="form-group row">
                            <label class="control-label text-right col-md-3">Address</label>
                            <div class="col-md-9">
                                <asp:TextBox ID="Txt_address" class="form-control" runat="server" TextMode="MultiLine"></asp:TextBox>
                            </div>
                        </div>

                        <div class="form-group row">
                            <label class="control-label text-right col-md-3">Contact no.<span style="color: red;">*</span></label>
                            <div class="col-md-9">
                                <asp:TextBox ID="Txt_contact" placeholder="Contact no." class="form-control" runat="server" TextMode="Number"></asp:TextBox>
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
                                <asp:TextBox ID="Txt_opening_balance" placeholder="Opening Balance" class="form-control" runat="server" TextMode="Number"></asp:TextBox>
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
                    <h4 class="modal-title">Add Purchase Product</h4>
                    <button type="button" class="close" data-dismiss="modal">&times;</button>

                </div>
                 <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                            <ContentTemplate>
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
                            <label class="control-label text-right col-md-3">CGST</label>
                            <div class="col-md-9">
                                <asp:DropDownList ID="Dd_cgst" class="form-control" runat="server">
                                    <asp:ListItem Value="0">0 %</asp:ListItem>
                                    <asp:ListItem Value="5">5 %</asp:ListItem>
                                    <asp:ListItem Value="6">6 %</asp:ListItem>
                                    <asp:ListItem Value="9">9 %</asp:ListItem>
                                    <asp:ListItem Value="12">12 %</asp:ListItem>
                                    <asp:ListItem Value="18">18 %</asp:ListItem>
                                    <asp:ListItem Value="28">28 %</asp:ListItem>

                                </asp:DropDownList>
                            </div>
                        </div>
                        <div class="form-group row">
                            <label class="control-label text-right col-md-3">SGST</label>
                            <div class="col-md-9">
                                <asp:DropDownList ID="Dd_sgst" class="form-control" runat="server">
                                    <asp:ListItem Value="0">0 %</asp:ListItem>
                                    <asp:ListItem Value="5">5 %</asp:ListItem>
                                    <asp:ListItem Value="6">6 %</asp:ListItem>
                                    <asp:ListItem Value="9">9 %</asp:ListItem>
                                    <asp:ListItem Value="12">12 %</asp:ListItem>
                                    <asp:ListItem Value="18">18 %</asp:ListItem>
                                    <asp:ListItem Value="28">28 %</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                        </div>
                        <div class="form-group row">
                            <label class="control-label text-right col-md-3">IGST</label>
                            <div class="col-md-9">
                                <asp:DropDownList ID="Dd_igst" class="form-control" runat="server">
                                    <asp:ListItem Value="0">0 %</asp:ListItem>
                                    <asp:ListItem Value="5">5 %</asp:ListItem>
                                    <asp:ListItem Value="6">6 %</asp:ListItem>
                                    <asp:ListItem Value="9">9 %</asp:ListItem>
                                    <asp:ListItem Value="12">12 %</asp:ListItem>
                                    <asp:ListItem Value="18">18 %</asp:ListItem>
                                    <asp:ListItem Value="28">28 %</asp:ListItem>
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
                                <asp:TextBox ID="Txt_ra" placeholder="Rate" class="form-control" runat="server" TextMode="Number" min="0"></asp:TextBox>
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
              <%--  <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                    <ContentTemplate>--%>
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




    <style>
        .Txt_hide {
            display: none;
        }
    </style>

    <script type="text/javascript">
        function sqrft() {
       <%-- var first = document.getElementById('<%= txt_height.ClientID %>');
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

             sqrft.value = sqrft_total;--%>

        }

        function rate() {
          <%--  var rates = document.getElementById('<%=txt_rate.ClientID %>');
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

            amount.value = rate_amount;--%>
        }


        function quan_amount() {
            var rates = document.getElementById('<%=txt_rate.ClientID %>');
            var quantity = document.getElementById('<%=txt_quantity.ClientID %>');
            var total = document.getElementById('<%=txt_total_amt.ClientID %>');
            if (rates == null) {
                rates = 0;
            }
            if (quantity == null) {
                quantity = 0;
            }
            if (total == null) {
                total = 0;
            }
            var total_amount = (parseFloat(rates.value) * parseFloat(quantity.value))

            total.value = total_amount.toFixed(2);

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

            total.value = total_amount.toFixed(2);

        }

        function gst() {
            var cgst = document.getElementById('<%= txt_cgst.ClientID %>');
            var sgst = document.getElementById('<%= txt_sgst.ClientID %>');
            var igst = document.getElementById('<%= txt_igst.ClientID %>');
            var total;
            if (document.getElementById('<%= txt_total_amt.ClientID %>') == null) {
                total = document.getElementById('<%= txt_total_amt2.ClientID %>');
              }
              else if (document.getElementById('<%= txt_total_amt2.ClientID %>') == null) {
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
            amount.value = amt.toFixed(2);
        }


        function final_total() {
            var subtotal = document.getElementById('<%=lbl_subtotal2.ClientID %>');
           <%--+ (parseFloat(gst.value)   var gst = document.getElementById('<%=lbl_gst.ClientID %>');--%>

            var ship = document.getElementById('<%=Txt_shipping.ClientID %>');
            var adjustment = document.getElementById('<%=Txt_adjustment.ClientID %>');
            var discount = document.getElementById('<%=Txt_discount.ClientID %>');
            var hideamount = (parseFloat(subtotal.value) + parseFloat(ship.value));


            var total_amount = ((parseFloat(subtotal.value) + parseFloat(ship.value)) - (parseFloat(discount.value)) - parseFloat(adjustment.value));


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
            if (document.getElementById('<%=Txt_due_date.ClientID%>').value.length == 0) {
                alert("Please Select Due Date !!!");
                return false;
            }

           <%-- if (document.getElementById('<%=Dd_enter_product.ClientID%>').value == "--Select--") {
                alert("Please Select Product !!!");
                return false;
            }--%>
            if (document.getElementById('<%=Txt_shipping.ClientID%>').value.length == 0) {
                alert("Please Enter Shipping Charges !!!");
                return false;
            }
            if (document.getElementById('<%=Txt_adjustment.ClientID%>').value.length == 0) {
                alert("Please Enter Adjustment !!!");
                return false;
            }
            if (document.getElementById('<%=Txt_discount.ClientID%>').value.length == 0) {
                alert("Please Enter Discount !!!");
                return false;
            }


            preventMultipleSubmissions();

            return true;
        }
        function JSFunctionValidate00() {


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
            if (document.getElementById('<%=Txt_due_date.ClientID%>').value.length == 0) {
                alert("Please Select Due Date !!!");
                return false;
            }

            <%--if (document.getElementById('<%=Dd_enter_product.ClientID%>').value == "--Select--") {
                alert("Please Select Product !!!");
                return false;
            }--%>
            if (document.getElementById('<%=Txt_shipping.ClientID%>').value.length == 0) {
                alert("Please Enter Shipping Charges !!!");
                return false;
            }
            if (document.getElementById('<%=Txt_adjustment.ClientID%>').value.length == 0) {
                alert("Please Enter Adjustment !!!");
                return false;
            }
            if (document.getElementById('<%=Txt_discount.ClientID%>').value.length == 0) {
                alert("Please Enter Discount !!!");
                return false;
            }


            preventMultipleSubmissions1();

            return true;
        }
    </script>
    <script>
        function JSFunctionValidate2() {
            if (document.getElementById('<%=Txt_vendor_name.ClientID%>').value.length == 0) {
                alert("Please Enter Vendor's Name !!!");
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
                    alert("Please Enter valid GST Number !!!");
                    return false;
                }
            }

            if (!(/^\w+([\.-]?\w+)*@\w+([\.-]?\w+)*(\.\w{2,3})+$/.test(document.getElementById('<%=Txt_email.ClientID%>').value)) && !(document.getElementById('<%=Txt_email.ClientID%>').value.length == 0)) {
                alert("You Have Entered an Invalid Email Address!");
                return false;
            }
            return true;
        }

        function JSFunctionValidate4() {

            var quant2 = document.getElementById('<%=txt_quantity2.ClientID %>');
            var quant = document.getElementById('<%=txt_quantity.ClientID %>');

            var height2 = document.getElementById('<%=txt_height2.ClientID %>');

            var width2 = document.getElementById('<%=txt_width2.ClientID %>');
           
           
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

</asp:Content>

