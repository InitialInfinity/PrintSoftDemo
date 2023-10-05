<%@ Page Title="" Language="C#" MasterPageFile="~/Purchase/Purchase.master" AutoEventWireup="true" CodeFile="invoice_payment.aspx.cs" Inherits="Purchase_invoice_payment" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
     
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>     <!-- Content Wrapper. Contains page content -->
  <div class="content-wrapper"> 
    <!-- Content Header (Page header) -->
    <section class="content-header sty-one">
      <h1>Invoice Payment</h1>
      <ol class="breadcrumb">
        <li><a href="#">Sale</a></li>
        <li><i class="fa fa-angle-right"></i> Invoice Payment</li>
      </ol>
    </section>
            <section class="content">
                <div class="row">
                    <div class="col-lg-12">
                        <div class="card">
                            <div class="card-header bg-blue">
                                <h5 class="m-b-0">Invoice Payment</h5>
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
                                            <label class="control-label text-right col-md-3">Pay<span style="color:red;">*</span></label>
                                            <div class="col-md-6">
                                                <asp:TextBox ID="Txt_pay" class="form-control" onkeyup="balance();" placeholder="Pay" runat="server" TextMode="SingleLine" TabIndex="1"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="form-body">
                                            <div class="form-group row">
                                                <label class="control-label text-right col-md-3">Payment Mode</label>
                                                <div class="col-md-6">
                                                    <asp:DropDownList ID="Dd_payment_mode" class="form-control" runat="server" TabIndex="2">
                                                        <asp:ListItem>Cash</asp:ListItem>
                                                        <asp:ListItem>Debit Card</asp:ListItem>
                                                        <asp:ListItem>Credit Card</asp:ListItem>
                                                        <asp:ListItem>Cheque</asp:ListItem>
                                                        <asp:ListItem>API</asp:ListItem>
                                                        <asp:ListItem>Other</asp:ListItem>
                                                    </asp:DropDownList>
                                                </div>
                                            </div>
                                            <div class="form-body">
                                                <div class="form-group row">
                                                    <label class="control-label text-right col-md-3">Balance</label>

                                                    <div class="col-md-6">
                                                         <asp:TextBox ID="Lbl_total_balance" disabled="true" class="form-control" runat="server" TextMode="SingleLine" TabIndex="3"></asp:TextBox>
                                                    </div>
                                                </div>
                                               
                                            </div>
                                            <div class="form-body">
                                                <div class="form-group row">
                                                    <label class="control-label text-right col-md-3">Date<span style="color:red;">*</span></label>

                                                    <div class="col-md-6">
                                                         <asp:TextBox ID="Txt_date" class="form-control" placeholder="Advance" runat="server" TextMode="Date" TabIndex="4"></asp:TextBox>
                                                    </div>
                                                </div>

                                            </div>
                                            <div class="form-actions">
                                                <div class="row">
                                                    <div class="col-md-12">
                                                        <div class="row">
                                                            <div class="offset-sm-3 col-md-9">

                                                                <asp:Button ID="Btn_submit" class="btn btn-success" runat="server" Text="Pay" OnClientClick="return JSFunctionValidate()" OnClick="Btn_submit_Click" TabIndex="5"/>

                                                                <asp:Button ID="Btn_cencel" class="btn btn-inverse" runat="server" Text="Cancel" TabIndex="6"/>

                                                                <asp:Label ID="Lbl_message" runat="server" Text=""></asp:Label>

                                                                <asp:HiddenField ID="lbl_id" runat="server" />
                                                            </div>
                                                        </div>
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
                                <h4 class="text-black">Invoice Payment Report</h4>

                                <div class="table-responsive">
                                    <table id="example1" class="table table-bordered table-striped">
                                        <thead>
                                            <tr>
                                                <th>Date</th>
                                                <th>Invoice</th>
                                                <th>Customer</th>
                                                <th>Due Amount</th>
                                                <th>Pay</th>
                                                <th>Mode</th>
                                                <th>Balance</th>
                                            </tr>
                                        </thead>
                                        <tbody>
                                            <asp:Repeater ID="Repeater1" runat="server">
                                                <ItemTemplate>
                                                    <tr>
                                                        <td>
                                                            <asp:Label ID="lbl_date" runat="server" Text='<%# Eval("pi_date", "{0:dd/MM/yyyy}") %>'></asp:Label></td>
                                                        <td>
                                                            <asp:Label ID="lbl_invoice" runat="server" Text='<%# Eval("pi_invoice") %>'></asp:Label></td>
                                                        <td>
                                                            <asp:Label ID="lbl_customer" runat="server" Text='<%# Eval("v_name") %>'></asp:Label></td>
                                                        <td>
                                                            <asp:Label ID="lbl_due" runat="server" Text='<%# Eval("pi_due") %>'></asp:Label></td>
                                                        <td>
                                                            <asp:Label ID="lbl_pay" runat="server" Text='<%# Eval("pi_pay") %>'></asp:Label></td>
                                                        <td>
                                                            <asp:Label ID="lbl_mode" runat="server" Text='<%# Eval("pi_mode") %>'></asp:Label></td>
                                                        <td>
                                                            <asp:Label ID="lbl_balance" runat="server" Text='<%# Eval("pi_balance") %>'></asp:Label></td>

                                                    </tr>
                                                </ItemTemplate>
                                            </asp:Repeater>
                                        </tbody>

                                    </table>
                                 
                                </div>
                            </div>
                        </div>
            </section>
       </div>
        </ContentTemplate>

    </asp:UpdatePanel>

  <!-- /.content-wrapper -->
  <footer class="main-footer">
    <div class="pull-right hidden-xs">Version 1.0</div>
    Copyright © 2018 PrintSoft. All rights reserved.</footer>



      <script>
function JSFunctionValidate()
{
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
         
           
         
            var balance= (parseFloat(due.value) - parseFloat(pay.value));

           
            document.getElementById('<%=Lbl_total_balance.ClientID %>').value = balance;
         
        }

    </script>
</asp:Content>

