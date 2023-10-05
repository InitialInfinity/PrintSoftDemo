<%@ Page Title="" Language="C#" MasterPageFile="~/Daily Cash Order/Cash.master" AutoEventWireup="true" CodeFile="cash_payment.aspx.cs" Inherits="Daily_Cash_Order_cash_payment" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>     <!-- Content Wrapper. Contains page content -->
  <div class="content-wrapper"> 
    <!-- Content Header (Page header) -->
    <section class="content-header sty-one">
      <h1>Cash Payment</h1>
      <ol class="breadcrumb">
        <li><a href="#">Cash Order</a></li>
        <li><i class="fa fa-angle-right"></i> Cash Payment</li>
      </ol>
    </section>
            <section class="content">
                <div class="row">
                    <div class="col-lg-12">
                        <div class="card">
                            <div class="card-header bg-blue">
                                <h5 class="m-b-0">Cash Payment</h5>
                            </div>
                            <div class="card-body">
                                <div class="form-horizontal form-bordered">
                                    <div class="form-body">
                                        
                                        <div class="form-group row">
                                            <label class="control-label text-right col-md-3">Invoice</label>
                                            <div class="col-md-6">
                                                <asp:TextBox ID="Txt_invoice" disabled="true" class="form-control" runat="server" TextMode="SingleLine"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="form-group row">
                                            <label class="control-label text-right col-md-3">Customer Name</label>
                                            <div class="col-md-6">
                                               <%-- <asp:DropDownList ID="Dd_customer" class="form-control" runat="server" disabled="true"></asp:DropDownList>--%>
                                                <asp:TextBox ID="Txt_customer" disabled="true" class="form-control" runat="server" TextMode="SingleLine"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="form-group row">
                                            <label class="control-label text-right col-md-3">Due Amount</label>
                                            <div class="col-md-6">
                                                <asp:TextBox ID="Txt_due_amount" disabled="true" class="form-control" runat="server" TextMode="SingleLine"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="form-group row">
                                            <label class="control-label text-right col-md-3">Discount<span style="color:red;">*</span></label>
                                            <div class="col-md-6">
                                                <asp:TextBox ID="Txt_discount" class="form-control" onkeyup="balance();" placeholder="Discount" runat="server" TextMode="SingleLine" TabIndex="1"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="form-group row">
                                            <label class="control-label text-right col-md-3">Pay<span style="color:red;">*</span></label>
                                            <div class="col-md-6">
                                                <asp:TextBox ID="Txt_pay" class="form-control" onkeyup="balance();" placeholder="Pay" runat="server" TextMode="SingleLine" TabIndex="2"></asp:TextBox>
                                            </div>
                                        </div>
                                            <div class="form-group row">
                                                <label class="control-label text-right col-md-3">Payment Mode</label>
                                                <div class="col-md-6">
                                                    <asp:DropDownList ID="Dd_payment_mode" class="form-control" runat="server" OnSelectedIndexChanged="Dd_payment_mode_SelectedIndexChanged" AutoPostBack="true" TabIndex="3">
                                                        <asp:ListItem>Cash</asp:ListItem>
                                                        <asp:ListItem>Credit</asp:ListItem>
                                                        <asp:ListItem>Cheque</asp:ListItem>
                                                        <asp:ListItem>Google Pay</asp:ListItem>
                                                        <asp:ListItem>Phone Pay</asp:ListItem>
                                                        <asp:ListItem>Paytm</asp:ListItem>
                                                        <asp:ListItem>NEFT/RTGS</asp:ListItem>
                                                        <asp:ListItem>Other</asp:ListItem>
                                                    </asp:DropDownList>
                                                </div>
                                            </div>
                                             <asp:Panel ID="Panel3" runat="server">
                                               <div class="form-group row">
                                                    <label class="control-label text-right col-md-3">Cheque No.</label>

                                                    <div class="col-md-6">
                                                         <asp:TextBox ID="Txt_ch_no"  class="form-control" runat="server" TextMode="SingleLine" TabIndex="4"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </asp:Panel>
                                                <div class="form-group row">
                                                    <label class="control-label text-right col-md-3">Balance</label>

                                                    <div class="col-md-6">
                                                         <asp:TextBox ID="Lbl_total_balance" disabled="true" class="form-control" runat="server" TextMode="SingleLine"></asp:TextBox>
                                                    </div>
                                                </div>
                                               
                                                <div class="form-group row">
                                                    <label class="control-label text-right col-md-3">Date<span style="color:red;">*</span></label>

                                                    <div class="col-md-6">
                                                         <asp:TextBox ID="Txt_date" class="form-control" placeholder="Advance" runat="server" TextMode="Date" TabIndex="5"></asp:TextBox>
                                                    </div>
                                                </div>

                                            </div>
                                            <div class="form-actions">
                                                <div class="row">
                                                    <div class="col-md-12">
                                                        <div class="row">
                                                            <div class="offset-sm-3 col-md-9">

                                                               <%-- <asp:Panel ID="Panel1" runat="server">
                                                                <asp:Button ID="Btn_submit" class="btn btn-success" runat="server" Text="Pay" OnClientClick="return JSFunctionValidate()" OnClick="Btn_submit_Click" TabIndex="6"/>
                                                                <asp:Button ID="Btn_cencel" class="btn btn-inverse" runat="server" Text="Cancel" TabIndex="7"/>

                                                                <asp:Label ID="Lbl_message" runat="server" Text=""></asp:Label>
                                                                </asp:Panel>--%>
                                                                <asp:Panel ID="Panel2" runat="server">
                                                                <asp:Button ID="Btn_submit2" class="btn btn-success" runat="server" Text="Pay" OnClientClick="return JSFunctionValidate()" OnClick="Btn_submit2_Click"  />
                                                                <asp:Button ID="Btn_cencel2" class="btn btn-inverse" runat="server" Text="Cancel" />

                                                                <asp:Label ID="Lbl_message2" runat="server" Text=""></asp:Label>
                                                                    <asp:HiddenField ID="lbl_contact" runat="server" />
                                                                    <asp:HiddenField ID="lbl_opening_balance" runat="server" />
                                                                    <asp:HiddenField ID="lbl_balance" runat="server" />
                                                                    <asp:HiddenField ID="lbl_customer" runat="server" />
                                                                </asp:Panel>

                                                                
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                       
                                    </div>
                                </div>
                            </div>
                        



                        <div class="card m-t-3">
                            <div class="card-body">
                                <h4 class="text-black">Payment Report</h4>

                                <div class="table-responsive">
                                    <table id="example1" class="table table-bordered table-striped">
                                        <thead>
                                            <tr>
                                                <th>Date</th>
                                                <th>Invoice</th>
                                               <%-- <th>Customer</th>--%>
                                                <th>Due Amount</th>
                                                <th>Discount</th>
                                                <th>Pay</th>
                                                <th>Mode</th>
                                                <th>Balance</th>
                                                <th>Action</th>
                                            </tr>
                                        </thead>
                                        <tbody>
                                            <asp:Repeater ID="Repeater1" runat="server" OnItemCommand="Repeater1_ItemCommand">
                                                <ItemTemplate>
                                                    <tr>
                                                        <td>
                                                            <asp:HiddenField ID="lbl_id" Value='<%# Eval("si_id") %>' runat="server" />
                                                            <asp:Label ID="lbl_date" runat="server" Text='<%# Eval("si_date", "{0:dd/MM/yyyy}") %>'></asp:Label></td>
                                                        <td>
                                                            <asp:Label ID="lbl_invoice" runat="server" Text='<%# Eval("si_invoice") %>'></asp:Label></td>
                                                        <%--<td>
                                                            <asp:Label ID="lbl_customer" runat="server" Text='<%# Eval("quw_name") %>'></asp:Label></td>--%>
                                                        <td>
                                                            <asp:Label ID="lbl_due" runat="server" Text='<%# Eval("si_due") %>'></asp:Label></td>
                                                        <td>
                                                            <asp:Label ID="lbl_discount" runat="server" Text='<%# Eval("si_discount") %>'></asp:Label></td>
                                                        <td>
                                                            <asp:Label ID="lbl_pay" runat="server" Text='<%# Eval("si_pay") %>'></asp:Label></td>
                                                        <td>
                                                            <asp:Label ID="lbl_mode" runat="server" Text='<%# Eval("si_mode") %>'></asp:Label></td>
                                                        <td>
                                                            <asp:Label ID="lbl_balance" runat="server" Text='<%# Eval("si_balance") %>'></asp:Label></td>
                                                        <td><asp:LinkButton ID="LinkButton1" runat="server" OnClientClick="return confirm('Do you want to delete this Payment?');" OnClick="DeletePayment"><i  class="fa fa-trash-o"></i></asp:LinkButton>
                                                            <asp:LinkButton ID="LinkButton2" runat="server"  CommandName="showid" CommandArgument='<%# Eval("si_id") %>'><i style="padding-left:10px" class="fa fa-eye"></i></i></asp:LinkButton>
                                                        </td>
                                                    </tr>
                                                </ItemTemplate>
                                            </asp:Repeater>
                                        </tbody>

                                    </table>
                                 
                                </div>
                            </div>
                        </div>
                        </div>
                    </div>
            </section>
       </div>
        </ContentTemplate>

    </asp:UpdatePanel>
    <!-- Modal -->
  <div class="modal fade" id="myModal" role="dialog">
    <div class="modal-dialog">
    
      <!-- Modal content-->
      <div class="modal-content">
        <div class="modal-header">
            <h4 class="modal-title"><%--<asp:Label ID="lbl_id" runat="server" Text="View"></asp:Label>--%>View</h4>
          <button type="button" class="close" data-dismiss="modal">&times;</button>
          
        </div>
        <div class="modal-body">
          <table class="table table-hover">
  
  <tbody>
    <tr>
      <th scope="col">Invoice No.</th>
      <td><asp:Label ID="lbl_invoice" runat="server" Text=""></asp:Label></td>
     
    </tr>
       <tr>
      <th scope="col">Date</th>
      <td><asp:Label ID="lbl_date" runat="server" Text=""></asp:Label></td>
     
    </tr>
       <tr>
      <th scope="col">Due Amount</th>
      <td><asp:Label ID="lbl_due" runat="server" Text=""></asp:Label></td>
     
    </tr>
       <tr>
      <th scope="col">Discount</th>
      <td><asp:Label ID="lbl_discount" runat="server" Text=""></asp:Label></td>
     
    </tr>
       <tr>
      <th scope="col">Pay</th>
      <td><asp:Label ID="lbl_pay" runat="server" Text=""></asp:Label></td>
     
    </tr>
       <tr>
      <th scope="col">Mode</th>
      <td><asp:Label ID="lbl_mode2" runat="server" Text=""></asp:Label></td>
     
    </tr>
       <tr>
      <th scope="col">Cheque No</th>
      <td><asp:Label ID="lbl_chno" runat="server" Text=""></asp:Label></td>
     
    </tr>
   <tr>
      <th scope="col">Balance</th>
      <td><asp:Label ID="lbl_balance1" runat="server" Text=""></asp:Label></td>
     
    </tr>
  </tbody>
</table>
        </div>
        <div class="modal-footer">
          <button type="button" class="btn btn-default" data-dismiss="modal">Close</button>
        </div>
      </div>
      
    </div>
  </div>
  <!-- /.content-wrapper -->
  <footer class="main-footer">
    <div class="pull-right hidden-xs">Version 1.0</div>
    Copyright © 2018 PrintSoft. All rights reserved.</footer>

    <script type="text/javascript">
function ShowModel() {

            $('#myModal').modal('show');
}

</script>
    <script>
function JSFunctionValidate()
{
    if (document.getElementById('<%=Txt_discount.ClientID%>').value.length == 0)
{
alert("Please Enter Discount !!!");
return false;
}

    if (document.getElementById('<%=Txt_pay.ClientID%>').value.length == 0)
{
alert("Please Enter Pay !!!");
return false;
}
   
    if (document.getElementById('<%=Txt_date.ClientID%>').value.length == 0)
{
        alert("Please Select Date !!!");
return false;
    }
   
 
return true;
}
        </script>
    
    <script>
       function balance() {
            var due = document.getElementById('<%=Txt_due_amount.ClientID %>');
          
            var pay = document.getElementById('<%=Txt_pay.ClientID %>');
         
           var discount = document.getElementById('<%=Txt_discount.ClientID %>');
         
           var balance = (parseFloat(due.value) - parseFloat(discount.value) - parseFloat(pay.value));

           
            document.getElementById('<%=Lbl_total_balance.ClientID %>').value = balance;
         
        }

    </script>
        <script type="text/javascript">
function printdiv(dropHere)
{
    var printContents = document.getElementById(dropHere).innerHTML;
    var originalContents = document.body.innerHTML;

    document.body.innerHTML = printContents;

    window.print();

    document.body.innerHTML = originalContents;
}
</script>

</asp:Content>

