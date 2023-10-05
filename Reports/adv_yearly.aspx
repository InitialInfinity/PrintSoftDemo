<%@ Page Title="" Language="C#" MasterPageFile="~/Reports/Reports.master" AutoEventWireup="true" CodeFile="adv_yearly.aspx.cs" Inherits="Reports_adv_yearly" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
     <meta charset="utf-8"/>
<meta http-equiv="X-UA-Compatible" content="IE=edge"/>

<!-- Tell the browser to be responsive to screen width -->
<meta content="width=device-width, initial-scale=1, maximum-scale=1, user-scalable=no" name="viewport"/>

<!-- v4.0.0 -->
<link rel="stylesheet" href="../dist/bootstrap/css/bootstrap.min.css"/>

<!-- Favicon -->
<link rel="icon" type="image/png" sizes="16x16" href="../dist/img/favicon-16x16.png"/>

<!-- Google Font -->
<link href="https://fonts.googleapis.com/css?family=Poppins:300,400,500,600,700" rel="stylesheet"/>

<!-- Theme style -->
<link rel="stylesheet" href="../dist/css/style.css"/>
<link rel="stylesheet" href="../dist/css/font-awesome/css/font-awesome.min.css"/>
<link rel="stylesheet" href="../dist/css/et-line-font/et-line-font.css"/>
<link rel="stylesheet" href="../dist/css/themify-icons/themify-icons.css"/>
<link rel="stylesheet" href="../dist/css/simple-lineicon/simple-line-icons.css"/>
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
    @page { margin: 0; }
  }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    

      <!-- Content Wrapper. Contains page content -->
  <div class="content-wrapper"> 
    <!-- Content Header (Page header) -->
    <section class="content-header sty-one">
      <h1>Advance Report - Yearly</h1>
      <ol class="breadcrumb">
        <li><a href="#">Reports</a></li>
        <li><i class="fa fa-angle-right"></i>Advance Report - Yearly</li>
      </ol>
    </section>
    <section class="content">
        
      <div class="row">
          <div class="col-xl-12">
         <div class="tile-progress tile-cyan">
            <div class="tile-header">
             
              <h5>Turnover</h5>
              <h5>Total Amount : ₹ <asp:Label ID="lbl_total_amt" runat="server" Text=""></asp:Label> | Total Advance : ₹ <asp:Label ID="lbl_total_adv" runat="server" Text=""></asp:Label></h5>
              <br/>
              <h5>Expense</h5>
              <h5>Total Purchase : ₹ <asp:Label ID="lbl_total_pur" runat="server" Text=""></asp:Label> | Total Expense : ₹ <asp:Label ID="lbl_total_exp" runat="server" Text=""></asp:Label> | Total Salary : ₹ <asp:Label ID="lbl_total_sal" runat="server" Text=""></asp:Label></h5>
              <br/>
              <h5>Business</h5>
              <h5>Total Profit : ₹ <asp:Label ID="lbl_total_col" runat="server" Text=""></asp:Label></h5>
            </div>
            
            <div class="tile-footer">
              <h5>Yearly Total Business Details</h5>
            </div>
          </div>
         </div>
      </div>
      <!-- /.row -->


       <div class="row">
        <div class="col-xl-6">
          <div class="info-box">
            <div class="card-header">
              <h5 class="card-title">Yearly Sales Report</h5>
            </div>
            <div class="table-responsive" style="height:250px;">
              <table class="table table-hover">
                <thead>
                  <tr>
                    <th>Invoice</th>
                    <th>Date</th>
                    <th>Customer</th>
                    <th>Balance</th>
                    <th>Total</th>
                  </tr>
                </thead>
                <tbody>
                    <asp:Repeater ID="Repeater1" runat="server">
                        <ItemTemplate>
                  <tr>
                    <td><a href="../sale/bill.aspx?invoice=<%# Eval("sl_invoice_no") %>"><asp:Label ID="lbl_invoice" runat="server" Text='<%# Eval("sl_invoice_no") %>'></asp:Label></a></td>
                    <td><a href="../sale/bill.aspx?invoice=<%# Eval("sl_invoice_no") %>"><asp:Label ID="lbl_date" runat="server" Text='<%# Eval("sl_date", "{0:dd/MM/yyyy}") %>'></asp:Label></a></td>
                    <td><a href="../sale/bill.aspx?invoice=<%# Eval("sl_invoice_no") %>"><asp:Label ID="lbl_customer" runat="server" Text='<%# Eval("c_name") %>'></asp:Label></a></td>
                    <td><a href="../sale/bill.aspx?invoice=<%# Eval("sl_invoice_no") %>"><asp:Label ID="lbl_status" runat="server" Text='<%# Eval("sl_balance") %>'></asp:Label></a></td>
                    <td><a href="../sale/bill.aspx?invoice=<%# Eval("sl_invoice_no") %>"><asp:Label ID="lbl_amount" runat="server" Text='<%# Eval("sl_total") %>'></asp:Label></a></td>
                  </tr>
                            </ItemTemplate>
                 </asp:Repeater>
                </tbody>
                  <tfoot>
                  <tr>
                  <th></th>
                  <th></th>
                      <asp:Panel ID="Panel1" runat="server">
                  <th>Total :</th>
                          </asp:Panel>
                   <th>   <asp:Label ID="lbl_bal" runat="server" ></asp:Label> </th>
                   <th>   <asp:Label ID="lbl_Total" runat="server" ></asp:Label> </th>  
                </tr>
              </tfoot>
              </table>
            </div>
          </div>
        </div>
         <div class="col-xl-6">
          <div class="info-box">
            <div class="card-header">
              <h5 class="card-title">Yearly Estimate Report</h5>
            </div>
            <div class="table-responsive" style="height:250px;">
              <table class="table table-hover">
                <thead>
                  <tr>
                    <th>Invoice</th>
                    <th>Date</th>
                    <th>Customer</th>
                    <th>Balance</th>
                    <th>Total</th>
                  </tr>
                </thead>
                <tbody>
                    <asp:Repeater ID="Repeater2" runat="server">
                        <ItemTemplate>
                   <tr>
                    <td><a href="../sale/wgst_bill.aspx?invoice=<%# Eval("est_invoice_no") %>"><asp:Label ID="lbl_invoice" runat="server" Text='<%# Eval("est_invoice_no") %>'></asp:Label></a></td>
                    <td><a href="../sale/wgst_bill.aspx?invoice=<%# Eval("est_invoice_no") %>"><asp:Label ID="lbl_date" runat="server" Text='<%# Eval("est_date", "{0:dd/MM/yyyy}") %>'></asp:Label></a></td>
                    <td><a href="../sale/wgst_bill.aspx?invoice=<%# Eval("est_invoice_no") %>"><asp:Label ID="lbl_customer" runat="server" Text='<%# Eval("c_name") %>'></asp:Label></a></td>
                    <td><a href="../sale/wgst_bill.aspx?invoice=<%# Eval("est_invoice_no") %>"><asp:Label ID="lbl_status" runat="server" Text='<%# Eval("est_balance") %>'></asp:Label></a></td>
                    <td><a href="../sale/wgst_bill.aspx?invoice=<%# Eval("est_invoice_no") %>"><asp:Label ID="lbl_amount" runat="server" Text='<%# Eval("est_total") %>'></asp:Label></a></td>
                  </tr>
                            </ItemTemplate>
                 </asp:Repeater>
                </tbody>
                  <tfoot>
                  <tr>
                  <th></th>
                  <th></th>
                      <asp:Panel ID="Panel2" runat="server">
                  <th>Total :</th>
                          </asp:Panel>
                   <th>   <asp:Label ID="lblest_bal" runat="server" ></asp:Label> </th>
                   <th>   <asp:Label ID="lblest_total" runat="server" ></asp:Label> </th>  
                </tr>
              </tfoot>
              </table>
            </div>
          </div>
        </div>
      </div>
      <!-- /.row -->
       
         <div class="row">
        <div class="col-xl-6">
          <div class="info-box">
            <div class="card-header">
              <h5 class="card-title">Yearly Purchase Report</h5>
            </div>
            <div class="table-responsive" style="height:250px;">
              <table class="table table-hover">
                <thead>
                  <tr>
                    <th>Invoice</th>
                    <th>Date</th>
                    <th>Vendor</th>
                    <th>Balance</th>
                    <th>Total</th>
                  </tr>
                </thead>
                <tbody>
                    <asp:Repeater ID="Repeater3" runat="server">
                        <ItemTemplate>
                   <tr>
                    <td><a href="../purchase/bill.aspx?invoice=<%# Eval("pu_invoice_no") %>"><asp:Label ID="lbl_invoice" runat="server" Text='<%# Eval("pu_invoice_no") %>'></asp:Label></a></td>
                    <td><a href="../purchase/bill.aspx?invoice=<%# Eval("pu_invoice_no") %>"><asp:Label ID="lbl_date" runat="server" Text='<%# Eval("pu_date", "{0:dd/MM/yyyy}") %>'></asp:Label></a></td>
                    <td><a href="../purchase/bill.aspx?invoice=<%# Eval("pu_invoice_no") %>"><asp:Label ID="lbl_customer" runat="server" Text='<%# Eval("v_name") %>'></asp:Label></a></td>
                    <td><a href="../purchase/bill.aspx?invoice=<%# Eval("pu_invoice_no") %>"><asp:Label ID="lbl_status" runat="server" Text='<%# Eval("pu_balance") %>'></asp:Label></a></td>
                    <td><a href="../purchase/bill.aspx?invoice=<%# Eval("pu_invoice_no") %>"><asp:Label ID="lbl_amount" runat="server" Text='<%# Eval("pu_total") %>'></asp:Label></a></td>
                  </tr>
                            </ItemTemplate>
                 </asp:Repeater>
                </tbody>
                  <tfoot>
                  <tr>
                  <th></th>
                  <th></th>
                      <asp:Panel ID="Panel3" runat="server">
                  <th>Total :</th>
                          </asp:Panel>
                   <th>   <asp:Label ID="lblpu_bal" runat="server" ></asp:Label> </th>
                   <th>   <asp:Label ID="lblpu_total" runat="server" ></asp:Label> </th>  
                </tr>
              </tfoot>
              </table>
            </div>
          </div>
        </div>
         <div class="col-xl-6">
          <div class="info-box">
            <div class="card-header">
              <h5 class="card-title">Yearly Expense Report</h5>
            </div>
            <div class="table-responsive" style="height:250px;">
              <table class="table table-hover">
                <thead>
                  <tr>
                    <th>ID#</th>
                  <th>Date</th>
                  <th>Category</th>
                  <th>User</th>
                  <th>Amount</th>
                  </tr>
                </thead>
                <tbody>
                    <asp:Repeater ID="Repeater4" runat="server">
                        <ItemTemplate>
                  <tr>
                      <td><asp:Label ID="lbl_sr" runat="server" Text='<%# Eval("e_id") %>'></asp:Label></td>
                   <td><asp:Label ID="lbl_date" runat="server" Text='<%# Eval("e_date", "{0:dd/MM/yyyy}") %>'></asp:Label></td>
                   
                  <td> <asp:Label ID="lbl_category" runat="server" Text='<%# Eval("e_category_name") %>'></asp:Label></td>
                  <td><asp:Label ID="lbl_user" runat="server" Text='<%# Eval("e_user_name") %>'></asp:Label></td>
                  <td><asp:Label ID="lbl_amount" runat="server" Text='<%# Eval("e_amount") %>'></asp:Label></td>
                   
                  </tr>
                            </ItemTemplate>
                 </asp:Repeater>
                </tbody>
                   <tfoot>
                  <tr>
                  <th></th>
                  <th></th>
                  <th></th>
                      <asp:Panel ID="Panel4" runat="server">
                  <th>Total :</th>
                          </asp:Panel>
                   <th>   <asp:Label ID="lbletotal" runat="server" ></asp:Label> </th>
                  
                </tr>
              </tfoot>
              </table>
            </div>
          </div>
        </div>
      </div>
      <!-- /.row -->

         <div class="row">
        <div class="col-xl-6">
          <div class="info-box">
            <div class="card-header">
              <h5 class="card-title">Yearly Salary Report</h5>
            </div>
            <div class="table-responsive" style="height:250px;">
              <table class="table table-hover">
                <thead>
                  <tr>
                   <th>Date</th>
                  <th>Staff Name</th>
                  <th>Salary</th>
                  <th>Paid</th>
                  <th>Deduction</th>
                  
                  </tr>
                </thead>
                <tbody>
                    <asp:Repeater ID="Repeater5" runat="server">
                        <ItemTemplate>
                  <tr>
                    <td><a href="../staff/salary_slip.aspx?id=<%# Eval("sal_id") %>"><asp:Label ID="lbl_date" runat="server" Text='<%# Eval("sal_date","{0:dd/MM/yyyy}") %>'></asp:Label></a></td>
                  <td><a href="../staff/salary_slip.aspx?id=<%# Eval("sal_id") %>">
              <asp:Label ID="lbl_staff_name" runat="server" Text='<%# Eval("st_staff_name") %>'></asp:Label></a></td>
                   
                  <td><a href="../staff/salary_slip.aspx?id=<%# Eval("sal_id") %>"><asp:Label ID="lbl_salary" runat="server" Text='<%# Eval("sal_salary") %>'></asp:Label></a></td>
                  
                  <td><a href="../staff/salary_slip.aspx?id=<%# Eval("sal_id") %>"><asp:Label ID="lbl_pay" runat="server" Text='<%# Eval("sal_pay") %>'></asp:Label></a></td>
                  <td><a href="../staff/salary_slip.aspx?id=<%# Eval("sal_id") %>"><asp:Label ID="lbl_deduction" runat="server" Text='<%# Eval("sal_deduction") %>'></asp:Label></a></td>
                  
                  </tr>
                            </ItemTemplate>
                 </asp:Repeater>
                </tbody>
                   <tfoot>
                  <tr>
                  <th></th>
                  <th></th>
                      <asp:Panel ID="Panel5" runat="server">
                  <th>Total :</th>
                          </asp:Panel>
                   <th>   <asp:Label ID="lblpaysal" runat="server" ></asp:Label> </th>
                   <th>   <asp:Label ID="lblbalsal" runat="server" ></asp:Label> </th> 
                </tr>
              </tfoot>
              </table>
            </div>
          </div>
        </div>
         <div class="col-xl-6">
           <div class="info-box">
            <div class="card-header">
              <h5 class="card-title">Yearly Payment Report</h5>
            </div>
            <div class="table-responsive" style="height:250px;">
              <table class="table table-hover">
                <thead>
                  <tr>
                   <th>Date</th>
                  <th>Invoice</th>
                  <th>Name</th>
                  <th>Paid</th>
                  <th>Balance</th>
                  
                  </tr>
                </thead>
                <tbody>
                    <asp:Repeater ID="Repeater6" runat="server">
                        <ItemTemplate>
                 <tr>
                    <td><asp:Label ID="lbl_date" runat="server" Text='<%# Eval("si_date","{0:MM/dd/yyyy}") %>'></asp:Label></td>
                  <td>
              <asp:Label ID="lbl_staff_name" runat="server" Text='<%# Eval("si_invoice") %>'></asp:Label></td>
                   
                  <td><asp:Label ID="lbl_salary" runat="server" Text='<%# Eval("c_name") %>'></asp:Label></td>
                  
                  <td><asp:Label ID="lbl_pay" runat="server" Text='<%# Eval("si_pay") %>'></asp:Label></td>
                  <td><asp:Label ID="lbl_deduction" runat="server" Text='<%# Eval("si_balance") %>'></asp:Label></td>
                  
                  </tr>
                            </ItemTemplate>
                 </asp:Repeater>
                </tbody>
                   <tfoot>
                  <tr>
                  <th></th>
                  <th></th>
                      <asp:Panel ID="Panel6" runat="server">
                  <th>Total :</th>
                          </asp:Panel>
                   <th>   <asp:Label ID="lblpayreport" runat="server" ></asp:Label> </th>
                   <th>   <asp:Label ID="lblbalreport" runat="server" ></asp:Label> </th>  
                </tr>
              </tfoot>
              </table>
            </div>
          </div>
          
        </div>
      </div>
      <!-- /.row -->
    </section>
      
  </div>
    
  <!-- /.content-wrapper -->
  <footer class="main-footer">
    <div class="pull-right hidden-xs">Version 1.0</div>
    Copyright © 2018 PrintSoft. All rights reserved.</footer>

</asp:Content>

