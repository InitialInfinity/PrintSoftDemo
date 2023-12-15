<%@ Page Title="" Language="C#" MasterPageFile="~/Reports/Reports.master" AutoEventWireup="true" CodeFile="out_datewise.aspx.cs" Inherits="Reports_out_datewise" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">


    <!-- Content Wrapper. Contains page content -->
    <div class="content-wrapper">
        <!-- Content Header (Page header) -->
        <section class="content-header sty-one">
            <h1>Outstanding Report - Date wise</h1>
            <ol class="breadcrumb">
                <li><a href="#">Reports</a></li>
                <li><i class="fa fa-angle-right"></i>Outstanding Report - Date wise</li>
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

            <div class="card">
                <div class="card-body">
                    <div class="row">
                        <div class="col-md-5">
                            <h4 class="text-black">Outstanding Report</h4>
                        </div>

                        <div class="col-md-7 exportbtn">


                            <button type="button" id="btn_print" title="Print" onclick="checkDataAndPrint();" class="btn btnsqr btn-primary"><i class="fa fa-print"></i>Print</button>

                        </div>
                    </div>
                    <br />
                    <div class="row no-print" style="background-color: #dee2e6; height: 52px">
                        <div class="col-md-3 padding_3" style="margin-top: 8px">
                            <asp:DropDownList ID="Dd_customer" class="form-control" runat="server"></asp:DropDownList>
                        </div>
                        <div class="col-md-3 padding_3" style="margin-top: 8px">
                            <asp:TextBox ID="Txt_date1" class="form-control" runat="server" TextMode="Date"></asp:TextBox>
                        </div>
                        <div class="col-md-1 padding_10" style="margin-top: 8px">
                            <b>
                                <asp:Label ID="Label1" runat="server" Text="To"></asp:Label></b>
                        </div>
                        <div class="col-md-3 padding_3" style="margin-top: 8px">
                            <asp:TextBox ID="Txt_date2" class="form-control" runat="server" TextMode="Date"></asp:TextBox>
                        </div>
                        <div class="col-md-2" style="margin-top: 5px">
                            <asp:Button ID="Btn_search" class="btn btn-success" runat="server" Text="Search" OnClick="Btn_search_Click" />
                        </div>

                    </div>
                    <br />
                    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                        <ContentTemplate>
                            <div id="dropHere" class="table-responsive">
                                <table id="example1" class="table table-bordered table-striped">
                                    <thead>
                                        <tr>
                                            <th>Sr.No.</th>
                                            <th>Invoice</th>
                                            <th>Date</th>
                                            <th>Name</th>
                                            <th>Status</th>
                                            <th>Balance</th>

                                            <th>Total</th>


                                        </tr>
                                    </thead>
                                    <tbody>

                                        <asp:Repeater ID="Repeater1" runat="server" OnItemDataBound="Repeater1_ItemDataBound">
                                            <ItemTemplate>
                                                <tr>
                                                    <td>
                                                        <asp:Label ID="lbl_sr" runat="server" Text='<%# Eval("sl_id") %>'></asp:Label></td>
                                                    <td>
                                                        <asp:Label ID="lbl_invoice" runat="server" Text='<%# Eval("sl_invoice_no") %>'></asp:Label></td>
                                                    <td>
                                                        <asp:Label ID="lbl_date" runat="server" Text='<%# Eval("sl_date", "{0:dd/MM/yyyy}") %>'></asp:Label></td>
                                                    <td>
                                                        <asp:Label ID="lbl_cust_name" runat="server" Text='<%# Eval("c_name") %>'></asp:Label></td>
                                                    <td>
                                                        <asp:Label ID="lbl_status" runat="server" Text=''></asp:Label></td>
                                                    <td>
                                                        <asp:Label ID="lbl_balance" runat="server" Text='<%# Eval("sl_balance") %>'></asp:Label></td>

                                                    <td>
                                                        <asp:Label ID="lbl_total" runat="server" Text='<%# Eval("sl_total") %>'></asp:Label></td>

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

                                            <asp:Panel ID="Panel1" runat="server">
                                                <th>Total :</th>
                                            </asp:Panel>
                                            <th>
                                                <asp:Label ID="lbl_bal" runat="server"></asp:Label>
                                            </th>
                                            <th>
                                                <asp:Label ID="lbl_Total" runat="server"></asp:Label>
                                            </th>




                                            <td class="no-print"></td>
                                        </tr>
                                    </tfoot>


                                </table>



                            </div>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>
            </div>
        </section>
        <asp:HiddenField ID="lbl_opening_balance" runat="server" />
    </div>

    <!-- /.content-wrapper -->
    <footer class="main-footer">
        <div class="pull-right hidden-xs">Version 1.0</div>
        Copyright © 2018 PrintSoft. All rights reserved.
    </footer>
    <asp:GridView ID="GridView1" display="none" runat="server"></asp:GridView>


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
    <script type="text/javascript">
        function checkDataAndPrint() {
            // Get the grid element
            var table = document.getElementById('example1');

            // Check if there are any rows in the table (excluding the header row)
            if (table.rows.length > 3) {
                printdiv('dropHere');
            } else {
                alert("No data to print");
            }
        }



    </script>

</asp:Content>


