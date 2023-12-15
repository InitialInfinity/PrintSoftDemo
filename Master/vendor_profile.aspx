<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Master.master" AutoEventWireup="true" CodeFile="vendor_profile.aspx.cs" Inherits="admin_panel_Master_vendor_profile" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <!-- Content Wrapper. Contains page content -->
    <div class="content-wrapper">
        <!-- Content Header (Page header) -->
        <section class="content-header sty-one">
            <h1>Vendor Profile</h1>
            <ol class="breadcrumb">
                <li><a href="#">Vendor</a></li>
                <li><i class="fa fa-angle-right"></i>Vendor Profile</li>
            </ol>
        </section>

        <!-- Main content -->
        <section class="content">
            <asp:Panel ID="Panel5" runat="server">
                <div class="alert alert-success" role="alert">
                    <button type="button" class="close" data-dismiss="alert" aria-label="Close"><span aria-hidden="true">&times;</span></button>
                    <strong>Success!</strong> Vendor successfully updated!
                </div>
            </asp:Panel>
            <div class="row">
                <div class="col-lg-3">
                    <div class="user-profile-box m-b-3">
                        <div class="box-profile text-white">
                            <img class="profile-user-img img-responsive img-circle m-b-2" src="user.png" alt="User">
                            <h3 class="profile-username text-center">
                                <asp:Label ID="lbl_name1" runat="server" Text=""></asp:Label></h3>

                        </div>
                    </div>
                    <div class="card m-b-3">
                        <div class="card-body">
                            <div class="box-body">

                                <strong><i class="fa fa-map-marker margin-r-5"></i>Address</strong>
                                <p class="text-muted">
                                    <asp:Label ID="lbl_address1" runat="server" Text=""></asp:Label>
                                </p>
                                <hr>
                                <strong><i class="fa fa-envelope margin-r-5"></i>Email </strong>
                                <p class="text-muted">
                                    <asp:Label ID="lbl_email1" runat="server" Text=""></asp:Label>
                                </p>
                                <hr>
                                <strong><i class="fa fa-phone margin-r-5"></i>Phone</strong>
                                <p>
                                    <asp:Label ID="lbl_phone1" runat="server" Text=""></asp:Label>
                                </p>

                            </div>
                            <!-- /.box-body -->
                        </div>
                    </div>
                    <div class="card m-b-3">
                        <div class="card-body">
                            <div class="box-body">

                                <strong>
                                    <asp:LinkButton ID="LinkButton1" runat="server" OnClick="LinkButton1_Click">Summary</asp:LinkButton></strong>

                                <hr>
                                <strong>
                                    <asp:LinkButton ID="LinkButton2" runat="server" OnClick="LinkButton2_Click">Invoices</asp:LinkButton></strong>

                                <hr>
                                <strong>
                                    <asp:LinkButton ID="LinkButton4" runat="server" OnClick="LinkButton4_Click">Transactions</asp:LinkButton></strong>


                            </div>
                            <!-- /.box-body -->
                        </div>
                    </div>

                </div>


                <div id="Panel1" runat="server" class="col-lg-9">
                    <div class="info-box">
                        <div class="card tab-style1">
                            <!-- Nav tabs -->
                            <ul class="nav nav-tabs profile-tab" role="tablist">
                                <li class="nav-item"><a class="nav-link active" data-toggle="tab" href="#home" role="tab" aria-expanded="true">Summary</a> </li>

                                <li class="nav-item"><a class="nav-link" data-toggle="tab" href="#profile" role="tab">Profile</a> </li>
                            </ul>
                            <!-- Tab panes -->
                            <div class="tab-content">
                                <div class="tab-pane active" id="home" role="tabpanel" aria-expanded="true">
                                    <div class="card-body">
                                        <table class="table table-hover">

                                            <tbody>

                                                <tr>
                                                    <th scope="col">Address</th>
                                                    <td>
                                                        <asp:Label ID="lbl_address2" runat="server" Text=""></asp:Label></td>

                                                </tr>

                                                <tr>
                                                    <th scope="col">Contact</th>
                                                    <td>
                                                        <asp:Label ID="lbl_contact2" runat="server" Text=""></asp:Label></td>

                                                </tr>
                                                <tr>
                                                    <th scope="col">Alternate Contact</th>
                                                    <td>
                                                        <asp:Label ID="lbl_contact22" runat="server" Text=""></asp:Label></td>

                                                </tr>
                                                <tr>
                                                    <th scope="col">GST no</th>
                                                    <td>
                                                        <asp:Label ID="lbl_gst_no2" runat="server" Text=""></asp:Label></td>

                                                </tr>
                                                <tr>
                                                    <th scope="col">Email</th>
                                                    <td>
                                                        <asp:Label ID="lbl_email2" runat="server" Text=""></asp:Label></td>

                                                </tr>
                                                <tr>
                                                    <th scope="col">Opening Balance</th>
                                                    <td>
                                                        <asp:Label ID="lbl_opening_balance2" runat="server" Text=""></asp:Label></td>

                                                </tr>

                                            </tbody>
                                        </table>
                                        <%--<hr/>
                      <a href="../Purchase/vendor_payment.aspx"> <button type="button" id="btn_excel" title="Customer Payment" runat="server" class="btn btnsqr btn-primary3 btngap" > <i class="fa fa-plus"></i> Vendor Payment</button></a>
                      <hr/>--%>
                                        <div class="row m-t-3">
                                            <div class="col-lg-6">
                                                <div class="tile-progress tile-pink">
                                                    <div class="tile-header">

                                                        <h3>
                                                            <asp:Label ID="lbl_total_invoices" runat="server" Text=""></asp:Label></h3>
                                                    </div>

                                                    <div class="tile-footer">
                                                        <h6>Total Invoices</h6>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-lg-6">
                                                <div class="tile-progress tile-red">
                                                    <div class="tile-header">

                                                        <h3>₹
                                                            <asp:Label ID="lbl_total_invoice_amount" runat="server" Text=""></asp:Label></h3>
                                                    </div>

                                                    <div class="tile-footer">
                                                        <h6>Total Invoice Amt.</h6>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-lg-6">
                                                <div class="tile-progress tile-cyan">
                                                    <div class="tile-header">

                                                        <h3>₹
                                                            <asp:Label ID="lbl_total_advance" runat="server" Text=""></asp:Label></h3>
                                                    </div>

                                                    <div class="tile-footer">
                                                        <h6>Total Paid </h6>
                                                    </div>
                                                </div>
                                            </div>

                                            <div class="col-lg-6">
                                                <div class="tile-progress tile-aqua">
                                                    <div class="tile-header">

                                                        <h3>₹
                                                            <asp:Label ID="lbl_remaining_balance" runat="server" Text=""></asp:Label></h3>
                                                    </div>

                                                    <div class="tile-footer">
                                                        <h6>Balance </h6>
                                                    </div>
                                                </div>
                                            </div>

                                            <!-- /.row -->




                                            <!-- /.row -->
                                        </div>

                                    </div>
                                </div>
                                <!--second tab-->

                                <div class="tab-pane" id="profile" role="tabpanel">
                                    <div class="card-body">

                                        <table class="table table-hover">

                                            <tbody>
                                                <tr>
                                                    <th scope="col">Name</th>
                                                    <td>
                                                        <asp:TextBox ID="Txt_name" CssClass="form-control" runat="server"></asp:TextBox></td>

                                                </tr>

                                                <tr>
                                                    <th scope="col">Address</th>
                                                    <td>
                                                        <asp:TextBox ID="Txt_address" CssClass="form-control" runat="server"></asp:TextBox></td>

                                                </tr>
                                                <tr>
                                                    <th scope="col">Contact</th>
                                                    <td>
                                                        <asp:TextBox ID="Txt_contact" CssClass="form-control" runat="server" MaxLength="10" oninput="validateInput(this);"></asp:TextBox></td>

                                                </tr>
                                                <tr>
                                                    <th scope="col">Alternate Contact</th>
                                                    <td>
                                                        <asp:TextBox ID="Txt_contact2" CssClass="form-control" runat="server" TextMode="number"></asp:TextBox></td>

                                                </tr>
                                                <tr>
                                                    <th scope="col">GST no</th>
                                                    <td>
                                                        <asp:TextBox ID="Txt_gst_no" CssClass="form-control" runat="server" MaxLength="15"></asp:TextBox></td>

                                                </tr>
                                                <tr>
                                                    <th scope="col">Email</th>
                                                    <td>
                                                        <asp:TextBox ID="Txt_email" CssClass="form-control" runat="server"></asp:TextBox></td>

                                                </tr>
                                                <tr>
                                                    <th scope="col">Opening Balance</th>
                                                    <td>
                                                        <asp:TextBox ID="Txt_opening_balance" CssClass="form-control" runat="server" TextMode="number"></asp:TextBox></td>

                                                </tr>

                                            </tbody>
                                        </table>
                                        <div class="form-group">
                                            <div class="col-sm-12">
                                                <asp:Button ID="Button1" OnClientClick="return JSFunctionValidate();" class="btn btn-success" runat="server" Text="Update Profile" OnClick="Button1_Click" />

                                            </div>
                                        </div>

                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>

                <div id="Panel2" runat="server" class="col-lg-9">
                    <div class="info-box">
                        <h4 class="text-black">Purchase Report</h4>

                        <div class="table-responsive">
                            <table id="example1" class="table table-bordered table-striped">
                                <thead>
                                    <tr>
                                        <th>Sr.No.</th>
                                        <th>Invoice ID</th>
                                        <th>Date</th>

                                        <th>Status</th>
                                        <th>Balance</th>

                                        <th>Total</th>
                                        <th>Action</th>

                                    </tr>
                                </thead>
                                <tbody>

                                    <asp:Repeater ID="Repeater2" runat="server" OnItemDataBound="Repeater2_ItemDataBound">
                                        <ItemTemplate>
                                            <tr>
                                                <td>
                                                    <asp:Label ID="lbl_sr" runat="server" Text='<%# Eval("pu_id") %>'></asp:Label></td>
                                                <td>
                                                    <asp:Label ID="lbl_invoice" runat="server" Text='<%# Eval("pu_invoice_no") %>'></asp:Label></td>
                                                <td>
                                                    <asp:Label ID="lbl_date" runat="server" Text='<%# Eval("pu_invoice_date", "{0:dd/MM/yyyy}") %>'></asp:Label></td>
                                                <td>
                                                    <asp:Label ID="lbl_status" runat="server" Text=''></asp:Label></td>
                                                <td>
                                                    <asp:Label ID="lbl_balance" runat="server" Text='<%# Eval("pu_balance") %>'></asp:Label></td>

                                                <td>
                                                    <asp:Label ID="lbl_total" runat="server" Text='<%# Eval("pu_total") %>'></asp:Label></td>
                                                <td><a href="../Purchase/bill.aspx?invoice=<%# Eval("pu_invoice_no") %>"><i style="padding-left: 10px" class="fa fa-eye"></i></i></a></td>
                                            </tr>
                                        </ItemTemplate>

                                    </asp:Repeater>


                                </tbody>

                            </table>



                        </div>
                    </div>
                </div>


                <div id="Panel4" runat="server" class="col-lg-9">
                    <div class="info-box">
                        <h4 class="text-black">Transaction Report</h4>

                        <div class="table-responsive">
                            <table id="example1" class="table table-bordered table-striped">
                                <thead>
                                    <tr>
                                        <th>Sr.No.</th>
                                        <th>Due</th>
                                        <th>Paid</th>
                                        <th>Mode</th>
                                        <th>Balance</th>


                                    </tr>
                                </thead>
                                <tbody>

                                    <asp:Repeater ID="Repeater4" runat="server">
                                        <ItemTemplate>
                                            <tr>
                                                <td>
                                                    <asp:Label ID="lbl_id" runat="server" Text='<%# Eval("pi_id") %>'></asp:Label></td>
                                                <td>
                                                    <asp:Label ID="lbl_balance" runat="server" Text='<%# Eval("pi_due") %>'></asp:Label></td>
                                                <td>
                                                    <asp:Label ID="lbl_advance" runat="server" Text='<%# Eval("pi_pay") %>'></asp:Label></td>
                                                <td>
                                                    <asp:Label ID="lbl_mode" runat="server" Text='<%# Eval("pi_mode") %>'></asp:Label></td>
                                                <td>
                                                    <asp:Label ID="lbl_total" runat="server" Text='<%# Eval("pi_balance") %>'></asp:Label></td>

                                            </tr>
                                        </ItemTemplate>

                                    </asp:Repeater>


                                </tbody>

                            </table>

                        </div>
                    </div>
                </div>
                <!-- Main row -->
        </section>
        <!-- /.content -->
    </div>
    <!-- /.content-wrapper -->
    <footer class="main-footer">
        <div class="pull-right hidden-xs">Version 1.0</div>
        Copyright © 2018 Yourdomian. All rights reserved.
    </footer>

    <script type="text/javascript">
        window.setTimeout(function () {
            $(".alert").fadeTo(500, 0).slideUp(500, function () {
                $(this).remove();
            });
        }, 4000);
    </script>
    <script>
        function JSFunctionValidate() {
            if (document.getElementById('<%=Txt_name.ClientID%>').value.length == 0) {
                alert("Please Enter Vendor's Name !!!");
                return false;
            }
            if (document.getElementById('<%=Txt_contact.ClientID%>').value.length == 0) {
                alert("Please Enter Vendor's Contact Number !!!");
                return false;
            }
            if (document.getElementById('<%=Txt_contact.ClientID%>').value.length != 10) {
                alert("Please Enter valid Contact Number !!!");
                return false;
            }
            <%--if (document.getElementById('<%=Txt_gst_no.ClientID%>').value.length != 15) {
                alert("Please Enter valid GST Number !!!");
                return false;
            }--%>
            if (document.getElementById('<%=Txt_gst_no.ClientID%>').value.length != 0) {
        //alert("Please Enter Gst Number !!!");
        //return false;
                if (document.getElementById('<%=Txt_gst_no.ClientID%>').value.length != 15) {
                    alert("Please Enter Valid Gst Number !!!");
                    return false;
                }
            }
            return true;
        }
    </script>
    <script type="text/javascript">
        function validateInput(input) {
            input.value = input.value.replace(/\D/g, '').substring(0, 10);
        }
    </script>

</asp:Content>

