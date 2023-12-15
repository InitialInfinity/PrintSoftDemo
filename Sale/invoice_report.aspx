<%@ Page Title="" Language="C#" MasterPageFile="~/Sale/Sale.master" AutoEventWireup="true" CodeFile="invoice_report.aspx.cs" Inherits="Sale_invoice_report" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <!-- Content Wrapper. Contains page content -->
    <div class="content-wrapper">


        <!-- Content Header (Page header) -->

        <section class="content-header sty-one">
            <h1>Sales Report</h1>
            <ol class="breadcrumb">
                <li><a href="#">Sale</a></li>
                <li><i class="fa fa-angle-right"></i>Sales Report</li>
            </ol>

        </section>



        <section class="content">
            <div class="row">
                <div class="col-lg-4">
                    <div class="tile-progress tile-pink">
                        <div class="tile-header">

                            <h3>
                                <asp:Label ID="lbl_total_invoice" runat="server" Text=""></asp:Label></h3>
                        </div>

                        <div class="tile-footer">
                            <h6>Total Invoice </h6>
                        </div>
                    </div>
                </div>
                <div class="col-lg-4">
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
                <div class="col-lg-4">
                    <div class="tile-progress tile-cyan">
                        <div class="tile-header">

                            <h3>₹
                                <asp:Label ID="Lbl_balance" runat="server" Text=""></asp:Label></h3>
                        </div>

                        <div class="tile-footer">
                            <h6>Balance</h6>
                        </div>
                    </div>
                </div>

            </div>
            <!-- /.row -->
            <asp:Panel ID="Panel2" runat="server">
                <div class="alert alert-success" role="alert">
                    <button type="button" class="close" data-dismiss="alert" aria-label="Close"><span aria-hidden="true">&times;</span></button>
                    <strong>Success!</strong> Invoice successfully created!
                </div>
            </asp:Panel>
            <div class="card">

                <div class="card-body">
                    <div class="row">
                        <div class="col-md-3">
                            <h4 class="text-black">Sales Report</h4>
                        </div>

                        <div class="col-md-9 exportbtn">
                            <asp:TextBox ID="txtdate" runat="server" Visible="false"></asp:TextBox>
                            <a href="sale_invoice.aspx">
                                <button type="button" id="btn_mail" title="Create New Invoice" class="btn btnsqr btn-primary4 btngap"><i class="fa fa-plus"></i>Add Invoice</button></a>
                            <button type="button" id="btn_excel" title="Export to Excel" runat="server" class="btn btnsqr btn-primary3 btngap" onserverclick="excel_export"><i class="fa fa-file-excel-o"></i>Excel</button>

                            <button type="button" id="btn_print" title="Print" onclick="printdiv('dropHere');" class="btn btnsqr btn-primary btngap"><i class="fa fa-print"></i>Print</button>
                            <button type="button" id="btn_pdf" title="Export to PDF" runat="server" class="btn btnsqr btn-primary2" onserverclick="pdf_export"><i class="fa fa-file-pdf-o"></i>PDF</button>


                        </div>
                    </div>
                    <br />
                    <%-- <div class="row " style="margin-left: 78%">
                        <asp:Button ID="btnsearch" Style="background-color: transparent; border: gray" runat="server" OnClick="Btn_search_Click" Text="Search"></asp:Button>&nbsp;<asp:TextBox ID="txtsearch" Width="150px" runat="server" class="form-control"></asp:TextBox>
                    </div>--%>

                    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                        <ContentTemplate>
                            <div id="dropHere" class="table-responsive">
                                <asp:Panel ID="pnlinvoice" runat="server">

                                    <table id="example1" class="table table-bordered table-striped table-hover">
                                        <thead>
                                            <tr>
                                                <th>ID #</th>
                                                <th>Invoice</th>
                                                <th>Invoice Date</th>

                                                <th>Name</th>
                                                <th>Status</th>
                                                <th>Payment</th>
                                                <th>Discount</th>
                                                <th>Advance</th>
                                                <th>Balance</th>
                                                <th>Total</th>

                                                <th class="no-print">Actions</th>
                                            </tr>
                                        </thead>
                                        <tbody>

                                            <asp:Repeater ID="Repeater1" runat="server" OnItemDataBound="Repeater1_ItemDataBound">
                                                <ItemTemplate>
                                                    <tr>
                                                        <td><a href="bill.aspx?invoice=<%# Eval("sl_invoice_no") %>">
                                                            <asp:Label ID="lbl_sr" runat="server" Text='<%# Eval("sl_id") %>'></asp:Label></a>

                                                        </td>
                                                        <td><a href="bill.aspx?invoice=<%# Eval("sl_invoice_no") %>">
                                                            <asp:Label ID="lbl_invoice" runat="server" Text='<%# Eval("sl_invoice_no") %>'></asp:Label></a>

                                                        </td>
                                                        <td><a href="bill.aspx?invoice=<%# Eval("sl_invoice_no") %>">
                                                            <asp:Label ID="lbl_invoice_date" runat="server" Text='<%# Eval("sl_invoice_date" , "{0:dd/MM/yyyy}") %>'></asp:Label></a>

                                                        </td>
                                                        <%-- <td><a href="bill.aspx?invoice=<%# Eval("sl_invoice_no") %>"><asp:Label ID="lbl_date" runat="server" Text='<%# Eval("sl_date", "{0:dd/MM/yyyy}") %>'></asp:Label></a></td>--%>
                                                        <td><a href="bill.aspx?invoice=<%# Eval("sl_invoice_no") %>">
                                                            <asp:Label ID="lbl_cust_name" runat="server" Text='<%# Eval("c_name") %>'></asp:Label></a>

                                                        </td>
                                                        <td><a href="bill.aspx?invoice=<%# Eval("sl_invoice_no") %>">
                                                            <asp:Label ID="lbl_status" runat="server" Text=''></asp:Label></a>

                                                        </td>
                                                        <td><a href="bill.aspx?invoice=<%# Eval("sl_invoice_no") %>">
                                                            <asp:Label ID="lbl_payment" runat="server" Text='<%# Eval("sl_payment_method") %>'></asp:Label></a>

                                                        </td>
                                                        <td><a href="bill.aspx?invoice=<%# Eval("sl_invoice_no") %>">
                                                            <asp:Label ID="lbl_discount" runat="server" Text='<%# Eval("sl_discount") %>'></asp:Label></a>

                                                        </td>
                                                        <td><a href="wgst_bill.aspx?invoice=<%# Eval("sl_invoice_no") %>">
                                                            <asp:Label ID="Label1" runat="server" Text='<%# Eval("sl_adjustment") %>'></asp:Label></a>

                                                        </td>
                                                        <td><a href="bill.aspx?invoice=<%# Eval("sl_invoice_no") %>">
                                                            <asp:Label ID="lbl_balance" runat="server" Text='<%# Eval("sl_balance") %>'></asp:Label></a>

                                                        </td>
                                                        <td><a href="bill.aspx?invoice=<%# Eval("sl_invoice_no") %>">
                                                            <asp:Label ID="lbl_total" runat="server" Text='<%# Eval("sl_total") %>'></asp:Label></a>

                                                        </td>
                                                        <asp:Panel ID="Panel1" runat="server">
                                                            <td class="no-print" id="tbltextbox" runat="server">
                                                                <asp:LinkButton ID="LinkButton1" runat="server" OnClientClick="return confirm('Do you want to delete this Sale Invoice?');" OnClick="DeleteSale"><i  class="fa fa-trash-o"></i></asp:LinkButton>

                                                                <asp:LinkButton ID="LinkButton2" runat="server" PostBackUrl='<%# "edit_bill.aspx?invoice=" + Eval("sl_invoice_no") %>'> <i style="padding-left: 10px" class="fa fa-edit"></i></asp:LinkButton>



                                                            </td>
                                                        </asp:Panel>
                                                    </tr>
                                                </ItemTemplate>

                                            </asp:Repeater>

                                        </tbody>
                                        <tfoot>
                                            <tr>
                                                <th></th>
                                                <th></th>
                                                <th></th>
                                                <th></th>
                                                <th></th>
                                                <th>Total :</th>
                                                <th>
                                                    <asp:Label ID="lbldiscount" runat="server"></asp:Label>
                                                </th>
                                                <th>
                                                    <asp:Label ID="lbl_Advance" runat="server"></asp:Label>
                                                </th>
                                                <th>
                                                    <asp:Label ID="lblTBalance" runat="server"></asp:Label></th>

                                                <th>
                                                    <asp:Label ID="lblTInvoiceAmount" runat="server"></asp:Label></th>

                                                <td class="no-print"></td>
                                            </tr>
                                        </tfoot>
                                    </table>
                                </asp:Panel>



                            </div>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>
            </div>
        </section>


    </div>

    <!-- /.content-wrapper -->
    <footer class="main-footer">
        <div class="pull-right hidden-xs">Version 1.0</div>
        Copyright © 2018 PrintSoft. All rights reserved.
    </footer>

    <asp:GridView ID="GridView1" dispaly="none" runat="server">
        <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
        <RowStyle ForeColor="black" />
    </asp:GridView>





    <script type="text/javascript">
        window.setTimeout(function () {
            $(".alert").fadeTo(500, 0).slideUp(500, function () {
                $(this).remove();
            });
        }, 4000);
    </script>
    <script type="text/javascript">

        function ShowModel() {

            $('#myModal').modal('show');
        }
    </script>
    <script type="text/javascript">

        function printdiv(dropHere) {
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
            @page {
                margin: 0;
            }
        }
    </style>
    <script>
        function edit() {

        }
    </script>
</asp:Content>

