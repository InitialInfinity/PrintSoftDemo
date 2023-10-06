<%@ Page Title="" Language="C#" MasterPageFile="~/Orders/Orders.master" AutoEventWireup="true" CodeFile="order.aspx.cs" Inherits="Orders_order" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <meta charset="utf-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />

    <!-- Tell the browser to be responsive to screen width -->
    <meta content="width=device-width, initial-scale=1, maximum-scale=1, user-scalable=no" name="viewport" />

    <!-- v4.0.0 -->
    <link rel="stylesheet" href="../dist/bootstrap/css/bootstrap.min.css" />

    <!-- Favicon -->
    <link rel="icon" type="image/png" sizes="16x16" href="../dist/img/favicon-16x16.png" />

    <!-- Google Font -->
    <link href="https://fonts.googleapis.com/css?family=Poppins:300,400,500,600,700" rel="stylesheet" />

    <!-- Theme style -->
    <link rel="stylesheet" href="../dist/css/style.css" />
    <link rel="stylesheet" href="../dist/css/font-awesome/css/font-awesome.min.css" />
    <link rel="stylesheet" href="../dist/css/et-line-font/et-line-font.css" />
    <link rel="stylesheet" href="../dist/css/themify-icons/themify-icons.css" />
    <link rel="stylesheet" href="../dist/css/simple-lineicon/simple-line-icons.css" />

    <style>
        .Txt_hide{
            display:none;
        }
</style>
    <script>
        function JSFunctionValidate() {


            if (document.getElementById('<%=Dd_customer.ClientID%>').selectedIndex == 0) {
        alert("Please Select Customer !!!");
        return false;
    }

    if (document.getElementById('<%=Txt_invoice_date.ClientID%>').value.length == 0) {
        alert("Please Select Order Date !!!");
        return false;
    }
    if (document.getElementById('<%=Txt_due_date.ClientID%>').value.length == 0) {
        alert("Please Select Due Date !!!");
        return false;
    }
   <%-- if(document.getElementById('<%=Txt_shipping.ClientID%>').value.length==0)
{
alert("Please Enter Shipping Charges !!!");
return false;
    }--%>
    if (document.getElementById('<%=Txt_advance.ClientID%>').value.length == 0) {
        alert("Please Enter Advance !!!");
        return false;
    }
    if (document.getElementById('<%=Txt_discount.ClientID%>').value.length == 0) {
                alert("Please Enter Discount !!!");
                return false;
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
        alert("Please Enter Customer's Contact Number !!!");
        return false;
    }
    if (!(document.getElementById('<%=Txt_contact.ClientID%>').value.length == 10)) {
        alert("Please Enter 10 Digits Contact Number !!!");
        return false;
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

            total.value = total_amount;

        }
        function quan_amount2() {
            var rate = document.getElementById('<%=txt_rate2.ClientID %>');
            var quantity = document.getElementById('<%=txt_quantity2.ClientID %>');
           var total = document.getElementById('<%=txt_total_amt2.ClientID %>');

            var total_amount = (parseFloat(rate.value) * parseFloat(quantity.value))

            total.value = total_amount;

        }

          function gst() {
            var cgst = document.getElementById('<%= txt_cgst.ClientID %>');
            var sgst = document.getElementById('<%= txt_sgst.ClientID %>');
            var igst = document.getElementById('<%= txt_igst.ClientID %>');
            var total = document.getElementById('<%= txt_total_amt.ClientID %>');

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
          
           
            var discount = document.getElementById('<%=Txt_discount.ClientID %>');


               var transport_charges = document.getElementById('<%=Txt_shipping.ClientID %>');

            var transport_value = parseFloat(transport_charges.value);

            var dtp_charges = document.getElementById('<%=Txt_dtp_charges.ClientID %>');

            var dtp_charges_value = parseFloat(dtp_charges.value);


                    var Fitting_Framing = document.getElementById('<%=Txt_Fitting_Framing.ClientID %>');

            var Fitting_Framing_Value = parseFloat(Fitting_Framing.value);


            var total_dtp_transport = parseFloat(transport_value) + parseFloat(dtp_charges_value) + parseFloat(Fitting_Framing_Value);






           
            var advance = document.getElementById('<%=Txt_advance.ClientID %>');
            var total_amount = (parseFloat(subtotal.value) + parseFloat(total_dtp_transport) - parseFloat(discount.value));

           
            var balance = (parseFloat(total_amount) - parseFloat(advance.value));

            document.getElementById('<%=lbl_total.ClientID %>').innerHTML = balance;
         document.getElementById('<%=hide_total.ClientID %>').value = total_amount;
        }

    </script>




</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <!-- Content Wrapper. Contains page content -->
    <div class="content-wrapper">
        <!-- Content Header (Page header) -->
        <section class="content-header sty-one">
            <h1>Sale Invoice</h1>
            <ol class="breadcrumb">
                <li><a href="#">Sale</a></li>
                <li><i class="fa fa-angle-right"></i>Sale Invoice</li>
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
                                        <h3 class="text-black">ORDER <span class="pull-right"></span> </h3>
                                    </div>
                                    <!-- /.col -->
                                </div>

                                <div class="container">
                                <!-- info row -->

                                <div class="customer_name row">
                                    <label class="control-label text-right col-md-3">Customer Name</label>
                                    <div class="col-md-6">
                                        <asp:DropDownList ID="Dd_customer" class="form-control" runat="server" OnSelectedIndexChanged="Dd_customer_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                                    </div>
                                   
                                     

                                </div>
                                    <div class="form-group row">
                                    <label class="control-label text-right col-md-3"></label>
                                    <div class="col-md-6">
                                       <asp:LinkButton ID="LinkButton1" data-toggle="modal" data-target="#myModal" class="col-md-4" runat="server">+Add Customer</asp:LinkButton>
                                    </div>
                                    
                                     

                                </div>
                                    
                                <div class="form-group row">
                                    <label class="control-label text-right col-md-3">Order#</label>
                                    <div class="col-md-6">
                                        <asp:TextBox ID="Txt_invoice" class="form-control" runat="server"></asp:TextBox>
                                  
                                    </div>
                                </div>

                                <div class="form-group row">
                                    <label class="control-label text-right col-md-3">Designer</label>
                                    <div class="col-md-6">
                                        <asp:DropDownList ID="Dd_staff" class="form-control" runat="server"></asp:DropDownList>
                                    </div>
                                </div>
                                <div class="form-group row">
                                    <label class="control-label text-right col-md-3">Order Date</label>
                                    <div class="col-md-3">
                                        <asp:TextBox ID="Txt_invoice_date" class="form-control" runat="server" TextMode="Date"></asp:TextBox>

                                    </div>
                                    <label class="control-label text-right col-md-3">Due Date</label>
                                    <div class="col-md-3">
                                        <asp:TextBox ID="Txt_due_date" class="form-control" runat="server" TextMode="Date"></asp:TextBox>
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
                                    <asp:LinkButton ID="LinkButton2" Class="add_class" data-toggle="modal" data-target="#myModal2" runat="server">+Add Product</asp:LinkButton>
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

                                            <th scope="col">Height</th>
                                            <th scope="col">Width</th>
                                            <th scope="col">Size</th>
                                            <th scope="col">Rate</th>
                                            <th scope="col">Amount</th>
                                            <th scope="col">Quantity</th>
                                            <th scope="col">Total</th>
                                        </tr>
                                    </thead>
                                    <tbody>
                                        <tr>

                                            <td>
                                                <asp:TextBox ID="txt_height" OnkeyUp="sqrft(); rate();quan_amount(); gst();" class="form-control" runat="server"></asp:TextBox></td>   
                                            <td>
                                                <asp:TextBox ID="txt_width" OnkeyUp="sqrft(); rate();quan_amount(); gst();" class="form-control" runat="server"></asp:TextBox></td>
                                            <td>
                                                <asp:TextBox ID="txt_sqrft" OnkeyUp="sqrft(); rate();quan_amount(); gst();" class="form-control" runat="server"></asp:TextBox></td>
                                            <td>
                                                <asp:TextBox ID="txt_rate" Onkeyup="sqrft(); rate();quan_amount(); gst();" class="form-control" runat="server"></asp:TextBox></td>
                                            <td>
                                                <asp:TextBox ID="txt_amount" class="form-control" runat="server"></asp:TextBox></td>
                                            <td>
                                                <asp:TextBox ID="txt_quantity" OnkeyUp="sqrft(); rate();quan_amount(); gst();" class="form-control" runat="server"></asp:TextBox></td>
                                            <td>
                                                <asp:TextBox ID="txt_total_amt" onkeyup="gst();" class="form-control" runat="server"></asp:TextBox></td>
                                        </tr>

                                    </tbody>
                                    </asp:Panel>
                                    <asp:Panel ID="Panel2" runat="server">
                                    <thead>
                                        <tr>

                                            <th scope="col">Height</th>
                                            <th scope="col">Width</th>
                                            <th scope="col">Size</th>
                                            <th scope="col">Rate</th>
                                            <th scope="col">Amount</th>
                                            <th scope="col">Quantity</th>
                                            <th scope="col">Total</th>
                                        </tr>
                                    </thead>
                                    <tbody>
                                        <tr>

                                            <td>
                                                <asp:TextBox ID="txt_height2"  disabled="true" class="form-control" runat="server"></asp:TextBox></td>   
                                            <td>
                                                <asp:TextBox ID="txt_width2" disabled="true" class="form-control" runat="server"></asp:TextBox></td>
                                            <td>
                                                <asp:TextBox ID="txt_sqrft2" disabled="true"  class="form-control" runat="server"></asp:TextBox></td>
                                            <td>
                                                <asp:TextBox ID="txt_rate2" Onkeyup="quan_amount2(); gst2();" class="form-control" runat="server"></asp:TextBox></td>
                                            <td>
                                                <asp:TextBox ID="txt_amount2" disabled="true" class="form-control" runat="server"></asp:TextBox></td>
                                            <td>
                                                <asp:TextBox ID="txt_quantity2" OnkeyUp="quan_amount2(); gst2();" class="form-control" runat="server"></asp:TextBox></td>
                                            <td>
                                                <asp:TextBox ID="txt_total_amt2" onkeyup="gst2();" class="form-control" runat="server"></asp:TextBox></td>
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
                                                <asp:TextBox ID="txt_cgst" class="form-control" runat="server"></asp:TextBox></td>
                                            <td>
                                                <asp:TextBox ID="txt_sgst" class="form-control" runat="server"></asp:TextBox></td>
                                            <td>
                                                <asp:TextBox ID="txt_igst" class="form-control" runat="server"></asp:TextBox></td>
                                            <td>
                                                <asp:TextBox ID="txt_final_amt" class="form-control" runat="server"></asp:TextBox></td>
                                            <td><asp:Button ID="Btn_cart" class="btn btn-primary pull-right" Style="margin-right: 5px;" runat="server" Text="Add to Cart" OnClick="Btn_cart_Click" /></td>
                                           
                                        </tr>

                                    </tbody>
                                </table>
                             
                                <div class="row ">
                                    <div class="col-xs-12 table-responsive">
                                        <asp:GridView ID="GridView1" class="table table-striped" runat="server" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3" OnDataBound="GridView1_DataBound" OnRowDataBound="GridView1_RowDataBound" OnPageIndexChanging="GridView1_PageIndexChanging" OnRowDeleting="GridView1_RowDeleting" >
                                          
                                            
                                          
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
                                                        <th>Design Charges:</th>
                                                        <td>
                                                            <asp:TextBox ID="Txt_dtp_charges" onkeyup="final_total();" class="form-control" runat="server" ></asp:TextBox></td>
                                                    </tr>
                                                  <tr>
                                                        <th>Transport:</th>
                                                        <td>
                                                            <asp:TextBox ID="Txt_shipping" onkeyup="final_total();" class="form-control" runat="server" ></asp:TextBox></td>
                                                    </tr>

                                                         <tr>
                                                        <th>Pasting  / Fitting / Framing Charges:</th>
                                                        <td>
                                                            <asp:TextBox ID="Txt_Fitting_Framing" onkeyup="final_total();" class="form-control" runat="server" ></asp:TextBox></td>
                                                    </tr>


                                                    <tr>
                                                        <th>Advance:</th>
                                                        <td>
                                                            <asp:TextBox ID="Txt_advance" onkeyup="final_total();" class="form-control" runat="server"></asp:TextBox></td>
                                                    </tr>
                                                    <tr>
                                                        <th>Discount:</th>
                                                        <td>
                                                            <asp:TextBox ID="Txt_discount" onkeyup="final_total();" class="form-control" runat="server"></asp:TextBox></td>
                                                    </tr>

                                                    
                                                      <tr>
                                                        <th>Payment Method:</th>
                                                        <td>
                                                            <asp:DropDownList ID="drp_payment"  class="form-control"  runat="server">

                                                                <asp:ListItem Selected="True">Cash</asp:ListItem>
                                                                <asp:ListItem>Cheque</asp:ListItem>
                                                                <asp:ListItem>Paytm</asp:ListItem>
                                                                <asp:ListItem>Google Pay</asp:ListItem>
                                                                <asp:ListItem>Phone Pay</asp:ListItem>
                                                            </asp:DropDownList>

                                                        </td>
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
                                    </div>
                                    <!-- /.col -->
                                </div>
                                <!-- /.row -->

                                <!-- this row will not appear when printing -->
                                <div class="row no-print">
                                    <div class="col-lg-12">
                                        <asp:Label ID="Lbl_message"  runat="server" Text=""></asp:Label>
                                        <asp:Button ID="Btn_submit_payment" class="btn btn-success pull-right" runat="server" Text="Save & Close" OnClientClick="return JSFunctionValidate();" OnClick="Btn_submit_payment_Click" />
                                        <asp:Button ID="Btn_generate_pdf" class="btn btn-primary pull-right" Style="margin-right: 5px;" runat="server" Text="Save Order" OnClientClick="return JSFunctionValidate();" OnClick="Btn_generate_pdf_Click" />
                                        

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
                    <label class="control-label text-right col-md-3">Customer Name<span style="color:red;">*</span></label>
                    <div class="col-md-9">
                      
                      <asp:TextBox ID="Txt_customer_name" placeholder="Customer Name"  class="form-control" runat="server"></asp:TextBox>
                      </div>
                  </div>
             
                  <div class="form-group row">
                    <label class="control-label text-right col-md-3">Address</label>
                    <div class="col-md-9">
                      <asp:TextBox ID="Txt_address" class="form-control"  placeholder="Address" runat="server" TextMode="MultiLine"></asp:TextBox>
                         
                    </div>
                  </div>
         

          <asp:UpdatePanel ID="UpdatePanel2" runat="server">
              <ContentTemplate>
         
                  </ContentTemplate>
              </asp:UpdatePanel>
                   <div class="form-group row">
                    <label class="control-label text-right col-md-3">Contact no.<span style="color:red;">*</span></label>
                    <div class="col-md-9">
                       <asp:TextBox ID="Txt_contact"   placeholder="Contact no." class="form-control" runat="server"></asp:TextBox>
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
                  
                </div>
        </div>
          
          <asp:UpdatePanel ID="UpdatePanel3" runat="server">
              <ContentTemplate>
        <div class="modal-footer">
             <asp:Label ID="lbl_msg" Style="color:red;" runat="server" Text=""></asp:Label>
             <asp:Button ID="Button1" class="btn btn-success" runat="server" Text="Submit" OnClientClick="JSFunctionValidate2();" OnClick="Button1_Click"  />
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
                    <label class="control-label text-right col-md-3">Product Name<span style="color:red;">*</span></label>
                    <div class="col-md-9">
                      
                      <asp:TextBox ID="Txt_product_name" placeholder="Product Name" class="form-control" runat="server"></asp:TextBox>
                      </div>
                  </div>
                 
                    <div class="form-group row">
                    <label class="control-label text-right col-md-3">Unit<span style="color:red;">*</span></label>
                    <div class="col-md-9">
                         <asp:DropDownList ID="Dd_unit" class="form-control" runat="server">
                             <asp:ListItem Value="Sqft">Sqft</asp:ListItem>
                             <asp:ListItem Value="Inch">Inch</asp:ListItem>
                             <asp:ListItem Value="Pcs">Pcs</asp:ListItem>
                         </asp:DropDownList>
                      </div>
                  </div>
                  
                   <div class="form-group row">
                    <label class="control-label text-right col-md-3">CGST<span style="color:red;">*</span></label>
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
                    <label class="control-label text-right col-md-3">SGST<span style="color:red;">*</span></label>
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
                    <label class="control-label text-right col-md-3">IGST<span style="color:red;">*</span></label>
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
                      <asp:TextBox ID="Txt_ra"  placeholder="Rate" class="form-control" runat="server"></asp:TextBox>
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
             <asp:Button ID="Button2" class="btn btn-success" runat="server" OnClientClick="JSFunctionValidate3();" Text="Submit" OnClick="Button2_Click"  />
          <button type="button" class="btn btn-default" data-dismiss="modal">Close</button>
        </div>
                    </ContentTemplate>
              </asp:UpdatePanel>
      </div>
      
    </div>
  </div>


</asp:Content>

