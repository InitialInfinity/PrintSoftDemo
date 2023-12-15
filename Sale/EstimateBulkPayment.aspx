<%@ Page Title="" Language="C#" MasterPageFile="~/Sale/Sale.master" AutoEventWireup="true" CodeFile="EstimateBulkPayment.aspx.cs" Inherits="Sale_EstimateBulkPayment" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
     <div class="content-wrapper">


        <!-- Content Header (Page header) -->

        <section class="content-header sty-one">
            <h1>Estimate Bulk Payment</h1>
            <ol class="breadcrumb">
                <li><a href="#">Sale</a></li>
                <li><i class="fa fa-angle-right"></i>Estimate Bulk Payment</li>
            </ol>

        </section>



        <section class="content">
            <%--   <div class="row">
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

            </div>--%>
            <!-- /.row -->
            <%-- <asp:Panel ID="Panel2" runat="server">
                <div class="alert alert-success" role="alert">
                    <button type="button" class="close" data-dismiss="alert" aria-label="Close"><span aria-hidden="true">&times;</span></button>
                    <strong>Success!</strong> Invoice successfully created!
                </div>
            </asp:Panel>--%>
            <div class="card">

                <div class="card-body">
                    <div class="row">
                        <div class="col-md-3">
                            <h4 class="text-black">Estimate Bulk Payment</h4>
                        </div>

                        <div class="col-md-9 exportbtn">
                            <asp:TextBox ID="txtdate" runat="server" Visible="false"></asp:TextBox>
                            <%--<a href="sale_invoice.aspx">
                                <button type="button" id="btn_mail" title="Create New Invoice" class="btn btnsqr btn-primary4 btngap"><i class="fa fa-plus"></i>Add Invoice</button></a>
                            <button type="button" id="btn_excel" title="Export to Excel" runat="server" class="btn btnsqr btn-primary3 btngap" onserverclick="excel_export"><i class="fa fa-file-excel-o"></i>Excel</button>

                            <button type="button" id="btn_print" title="Print" onclick="printdiv('dropHere');" class="btn btnsqr btn-primary btngap"><i class="fa fa-print"></i>Print</button>
                            <button type="button" id="btn_pdf" title="Export to PDF" runat="server" class="btn btnsqr btn-primary2" onserverclick="pdf_export"><i class="fa fa-file-pdf-o"></i>PDF</button>--%>
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
                                                <th>Sr.No</th>
                                                <th style="display: none">Customer Id</th>
                                                <th>Customer Name</th>
                                                <th style="display: none">Total Amount</th>
                                                <th>Due Amount</th>
                                                <th>Total Invoice</th>
                                                <th>Last Payment Date</th>

                                                <th class="no-print">Actions</th>
                                            </tr>
                                        </thead>
                                        <tbody>

                                            <asp:Repeater ID="Repeater1" runat="server" OnItemDataBound="Repeater1_ItemDataBound">
                                                <ItemTemplate>
                                                    <tr>
                                                        <td>
                                                            <asp:Label ID="lbl_sr" runat="server" Text='<%# Eval("SRNO") %>'></asp:Label>

                                                        </td>
                                                        <td style="display: none">
                                                            <asp:Label ID="Label1" runat="server" Text='<%# Eval("c_id") %>'></asp:Label>
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lbl_custname" runat="server" Text='<%# Eval("c_name") %>'></asp:Label>

                                                        </td>
                                                        <td style="display: none">
                                                            <asp:Label ID="Label2" runat="server" Text='<%# Eval("Total") %>'></asp:Label>

                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lbl_pendingamt" runat="server" Text='<%# Eval("Balance") %>'></asp:Label>

                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lbl_totalamt" runat="server" Text='<%# Eval("Total_invoice") %>'></asp:Label>

                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lbl_lastpaymentdate" runat="server" Text='<%# Eval("Latest_Payment_Date") %>'></asp:Label>

                                                        </td>
                                                        <td>
                                                            <asp:LinkButton ID="btn_add" runat="server" OnClick="btn_add_Click" CommandArgument='<%# Eval("c_id") %>' OnClientClick="return Clear()"><i style="font-size: 24px" class="fa">&#xf040;</i></asp:LinkButton>
                                                        </td>
                                                    </tr>
                                                </ItemTemplate>

                                            </asp:Repeater>

                                        </tbody>

                                    </table>
                                </asp:Panel>

                                <div class="modal fade" id="myModal2" role="dialog" data-backdrop="static" data-keyboard="false">
                                    <div class="modal-dialog custom-modal-width" style="max-width: 800px; width: 100%; margin: 87px auto;">

                                        <!-- Modal content-->
                                        <div class="modal-content">
                                            <div class="modal-header">
                                                <h4 class="modal-title">Estimate Bulk Payment<asp:HiddenField ID="Txt_id" runat="server" />
                                                </h4>
                                                <button type="button" class="close" data-dismiss="modal">&times;</button>

                                            </div>
                                            <div class="modal-body">
                                                <table class="table table-hover">

                                                    <tbody>
                                                        <tr style="display: none">
                                                            <th scope="col" style="display: none">Id</th>
                                                            <td>
                                                                <asp:TextBox ID="txt_cid" class="form-control" runat="server" Style="display: none"></asp:TextBox></td>

                                                        </tr>
                                                        <tr scope="row">
                                                            <th scope="col">Customer Name</th>
                                                            <td>
                                                                <asp:TextBox ID="txt_customername" class="form-control" runat="server" ReadOnly="true"></asp:TextBox></td>


                                                        </tr>
                                                        <tr scope="row">
                                                            <th scope="col">Total Amount</th>
                                                            <td>
                                                                <asp:TextBox ID="txt_totalamount" class="form-control" runat="server" ReadOnly="true"></asp:TextBox></td>


                                                        </tr>
                                                        <tr scope="row">
                                                            <th scope="col">
                                                                Due Amount
                                                            </th>
                                                            <td>
                                                                <asp:TextBox ID="txt_dueamount" class="form-control" runat="server" ReadOnly="true"></asp:TextBox>
                                                                <asp:TextBox ID="txt_dueamount1" class="form-control" runat="server" style="display:none"></asp:TextBox>
                                                            </td>
                                                        </tr>

                                                        <tr>
                                                            <th scope="col">Pay <span style="color:red;">*</span></th>
                                                            <td>
                                                                <asp:TextBox ID="txt_pay" class="form-control" onkeyup="balance();" runat="server" /></td>


                                                        </tr>

                                                        <tr>
                                                            <th scope="col">Payment Mode </th>
                                                            <td>
                                                                <asp:DropDownList ID="Dd_payment_mode" class="form-control" runat="server" TabIndex="3" Onchange="paymentmode();">
                                                                    <asp:ListItem>Cash</asp:ListItem>

                                                                    <asp:ListItem>Cheque</asp:ListItem>
                                                                    <asp:ListItem>Google Pay</asp:ListItem>
                                                                    <asp:ListItem>Phone Pay</asp:ListItem>
                                                                    <asp:ListItem>Paytm</asp:ListItem>
                                                                    <asp:ListItem>Other</asp:ListItem>
                                                                </asp:DropDownList>
                                                        </tr>
                                                        <tr>
                                                            <asp:Panel ID="panel3" runat="server">
                                                                <th>Cheque No <span style="color:red;">*</span></th>
                                                                <td>
                                                                    <asp:TextBox ID="txt_chq" class="form-control" runat="server" ReadOnly="true"/></td>
                                                                </td>
                                                            </asp:Panel>

                                                        </tr>

                                                        <tr>
                                                            <th scope="col">Date</th>
                                                            <td>
                                                                <asp:TextBox ID="txt_date" class="form-control" runat="server" TextMode="Date" TabIndex="5"></asp:TextBox>

                                                            </td>
                                                        </tr>

                                                    </tbody>
                                                </table>
                                            </div>
                                            <div class="modal-footer col-md-8">
                                                <asp:Label ID="lbl_msg" runat="server" Text=""></asp:Label>
                                                <asp:Button ID="Button1" class="btn btn-success " runat="server" Text="Save" OnClick="Button1_Click" OnClientClick="return JSFunctionValidate()"/>
                                                <button type="button" class="btn btn-default" data-dismiss="modal">Close</button>
                                            </div>


                                        </div>




                                    </div>

                                </div>

                            </div>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>
            </div>
        </section>


    </div>
    <script type="text/javascript">
        Sys.WebForms.PageRequestManager.getInstance().add_beginRequest(BeginRequestHandler);
        function BeginRequestHandler(sender, args) { var oControl = args.get_postBackElement(); oControl.disabled = true; }

        function Clear() {
            var dropdown = document.getElementById('<%= Dd_payment_mode.ClientID %>');
            dropdown.value = "Cash";
            document.getElementById('<%= txt_pay.ClientID %>').value = '';
            document.getElementById('<%= txt_dueamount.ClientID %>').value = '';
            document.getElementById('<%= txt_dueamount1.ClientID %>').value = '';
            document.getElementById('<%= txt_chq.ClientID %>').value = '';

            return true;
        }

        function hideModalBackdrop() {
            $('.modal-backdrop').modal('show');
        }
        function ShowModel2() {
            $('.modal-backdrop').hide();
            $('#myModal2').modal('show');

        }
        function ShowModel3() {
            $('.modal-backdrop').remove();
            $('.modal-backdrop').hide();
            $('#myModal2').modal('hide');

        }
        function JSFunctionValidate() {
            if (document.getElementById('<%=txt_pay.ClientID%>').value == 0) {
                alert("Please Enter Pay !!!");
                return false;
            }
            var payment = document.getElementById('<%=Dd_payment_mode.ClientID %>');

            if (payment.value == 'Cheque') {
                if (document.getElementById('<%=txt_chq.ClientID%>').value.length == 0) {
                    alert("Please enter cheque No !!!");
                    return false;
                }
            }
            return true;
        }
        function balance() {
           
            var pay = document.getElementById('<%=txt_pay.ClientID %>');
           var due= document.getElementById('<%=txt_dueamount.ClientID %>');
            var due1 = document.getElementById('<%=txt_dueamount1.ClientID %>');

            var payValue = parseFloat(pay.value);
            var due1Value = parseFloat(due1.value);

            
            if (pay.value == "" || pay.value == null)
                pay.value = 0;

            if (payValue > due1Value) {
                alert("Payment amount cannot be greater than due  amount!");
                pay.value = 0;
            }

            var inputValue = pay.value.trim();

            // Remove non-numeric characters using a regular expression
            inputValue = inputValue.replace(/[^0-9.]/g, '');

            // Update the input field with the cleaned value
            pay.value = inputValue;

            // You can also check if the cleaned value is a valid number
            var payValue = parseFloat(inputValue);
            if (isNaN(payValue)) {
                alert("Please enter a valid numeric value in the Pay field.");
                pay.value = 0;
            }

            var remainingamt = parseFloat(due1.value) - parseFloat(pay.value);

            document.getElementById('<%=txt_dueamount.ClientID %>').value = remainingamt;
        }
        function paymentmode() {

            var payment = document.getElementById('<%=Dd_payment_mode.ClientID %>');
            var cheque = document.getElementById('<%=txt_chq.ClientID %>');
            var txtDate = document.getElementById('<%=txt_date.ClientID %>');

            if (payment.value == 'Cheque') {
                $('#ContentPlaceHolder1_txt_chq').removeAttr('readonly');
                txtDate.readOnly = true;
            } else {
                $('#ContentPlaceHolder1_txt_chq').attr('readonly', 'true');
                txtDate.readOnly = false;
            }
        }

    </script>
</asp:Content>

