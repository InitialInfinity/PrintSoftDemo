<%@ Page Title="" Language="C#" MasterPageFile="~/Sale/Sale.master" AutoEventWireup="true" CodeFile="print_job.aspx.cs" Inherits="Sale_print_job" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
         <!-- Content Wrapper. Contains page content -->
    <div class="content-wrapper">
        <!-- Content Header (Page header) -->
        <section class="content-header sty-one">
            <h1>Job Estimation Sheet</h1>
            <ol class="breadcrumb">
                <li><a href="#">Sale</a></li>
                <li><i class="fa fa-angle-right"></i>Job Estimation Sheet</li>
            </ol>
        </section>
        <!-- Main content -->

        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">

            <ContentTemplate>
                <section class="content" id="dropHere">
                    
                    <div class="card">
                        <div class="card-body">
                            <div class="no-print" style="text-align:center;"> <br/><button onclick="printdiv('dropHere');" class="btn btn-primary" ><i class="fa fa-print"></i> Print</button></div>
                           <br/>
                             <!-- Main content -->
                            <section class="invoice"">
                                 
                                <!-- title row -->
                                <div class="row">
                                    <div class="col-lg-12 m-b-3" style="background-color:black;">
                                        <h3 class="text-center" style="color:white;margin-top: 5px;"> Job Estimation Sheet </h3>
                                    </div>
                                    <!-- /.col -->
                                </div>

                                <div class="container">
                                <!-- info row -->

                                  
                               <div class="form-group row">
                                    
                                    <label class="control-label col-md-3"><b>Invoice no. : </b></label>
                                    <div class="col-md-3">
                                      <asp:Label ID="lbl_invoice" runat="server" Text=""></asp:Label>
                                    </div>
                                    <label class="control-label col-md-3"><b>Date : </b></label>
                                    <div class="col-md-3">
                                      <asp:Label ID="lbl_date" runat="server" Text=""></asp:Label>
                                    </div>
                                </div>
                                <div class="form-group row">
                                    <label class="control-label col-md-3"><b>Authorised Person : </b></label>
                                    <div class="col-md-3">
                                       <asp:Label ID="lbl_owner" runat="server" Text=""></asp:Label>
                                    </div>
                                    <label class="control-label col-md-3"><b>Contact : </b></label>
                                    <div class="col-md-3">
                                       <asp:Label ID="lbl_contact" runat="server" Text=""></asp:Label>
                                    </div>
                                </div>

                                </div>
                               
                                <div class="row ">
                                    <div class="table-responsive">
                                          <table class="table table-bordered">
 <thead id="ths" runat="server" style="color:black;background-color:white;">
    <tr>
      <th scope="col">Income Note</th>
     
      <th scope="col">Amount</th>
    </tr>
  </thead>

  <tbody>
      <asp:Repeater ID="Repeater1" runat="server">
 <ItemTemplate>
    <tr>
      <td>
          <asp:Label ID="lbl_product" runat="server" Text='<%# Eval("s_product_name") %>'></asp:Label></td>
      <td><asp:Label ID="lbl_hsn" runat="server" Text='<%# Eval("s_stotal") %>'></asp:Label></td>
       
    </tr>
       </ItemTemplate>

          </asp:Repeater>
  </tbody>

</table>
                                    </div>
                                </div>
                                <div class="form-group row">
                                    <label class="control-label col-md-3"><b>Income Total : </b></label>
                                    <div class="col-md-3">
                                       <asp:Label ID="lbl_income_total" runat="server" Text=""></asp:Label>
                                    </div>
                                    
                                </div>
                            
                                 <div class="row ">
                                    <div class="col-xs-12 table-responsive">
                                          <table class="table table-bordered">
 <thead id="Thead1" runat="server" style="color:black;background-color:white;">
    <tr>
      <th scope="col">Expense Note</th>
     
      <th scope="col">Amount</th>
    </tr>
  </thead>

  <tbody>
      <asp:Repeater ID="Repeater2" runat="server">
 <ItemTemplate>
    <tr>
      <td>
          <asp:Label ID="lbl_product" runat="server" Text='<%# Eval("js_expense") %>'></asp:Label></td>
      <td><asp:Label ID="lbl_hsn" runat="server" Text='<%# Eval("js_amount") %>'></asp:Label></td>
       
    </tr>
       </ItemTemplate>

          </asp:Repeater>
  </tbody>

</table>
                                    </div>
                                </div>
                                <div class="form-group row">
                                    <label class="control-label col-md-3"><b>Expense Total : </b></label>
                                    <div class="col-md-3">
                                       <asp:Label ID="lbl_expense_total" runat="server" Text=""></asp:Label>
                                    </div>
                                    
                                </div>
                                 <div class="row">
                                    <label class="control-label col-md-2" style="font-size:20px"><b>Profit : </b></label>
                                    <div class="col-md-3">
                                       <asp:Label ID="lbl_profit" runat="server"  style="font-size:20px" Text=""></asp:Label>
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

