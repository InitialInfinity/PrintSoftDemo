﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Reports/Reports.master" AutoEventWireup="true" CodeFile="ven_statement.aspx.cs" Inherits="Reports_ven_statement" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
   
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
      <h1>Vendor Statement</h1>
      <ol class="breadcrumb">
        <li><a href="#">Reports</a></li>
        <li><i class="fa fa-angle-right"></i> Vendor Statement</li>
      </ol>
    </section>
     <section class="content">
      
        
        <div class="card">
      <div class="card-body">
       <div class="row">
        <div class="col-md-5">
         <h4 class="text-black">Vendor Statement</h4>
        </div>
        
             <div class="col-md-7 exportbtn">
          
        
        <button type="button" id="btn_print" title="Print" onclick="printdiv('dropHere');" class="btn btnsqr btn-primary"> <i class="fa fa-print"></i> Print</button>
    
      </div>
      </div>
            <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                    <br/>
      <div class="form-group row">
         <div class="col-md-3">
               <asp:TextBox ID="Date1" class="form-control" runat="server" TextMode="Date"></asp:TextBox>
        </div>
          TO
          <div class="col-md-3">
              <asp:TextBox ID="Date2" class="form-control" runat="server" TextMode="Date"></asp:TextBox>
        </div>

           <div class="col-md-3">
               <asp:DropDownList ID="Dd_customer" class="form-control" runat="server" ></asp:DropDownList>
               <%--AutoPostBack="True" OnSelectedIndexChanged="Dd_customer_SelectedIndexChanged"--%>
        </div>
          
           <div class="col-md-2" >
          <asp:Button ID="Btn_search" class="btn btn-success" runat="server" Text="Search" onclick="Btn_search_Click"/>
          </div>

       </div>
                    
            <asp:Panel ID="Panel1" runat="server">
     <div id="dropHere" class="card"> 
      <div class="card-body">
          <!--  Place a single ASPXToPDF control in the page  -->
        
        <!-- Main content -->
        <section class="invoice"> 
          <!-- title row -->
          <div class="row">
            <div class="col-lg-12 m-b-3">
              <h3 class="text-black">
                 <span class="pull-right">Vendor Statement </span> </h3>
            </div>
            <!-- /.col --> 
          </div>
          <!-- info row -->
          <div class="row">
              <div class="col-sm-6 invoice-col"> 
            
                   <asp:Image ID="Image1" Height="100px" runat="server" /><br/>
          
            </div>

            <div class="col-sm-6 invoice-col text-right"> 
                  
             <h4> <strong> <asp:Label ID="lbl_company_name" runat="server" Text=""></asp:Label></strong></h4>
            
              <asp:Label ID="lbl_company_address" runat="server" Text=""></asp:Label><br/>
              Phone: <asp:Label ID="lbl_company_contact" runat="server" Text=""></asp:Label><br/>
              Email: <asp:Label ID="lbl_company_email" runat="server" Text=""></asp:Label>
              
            </div>
          </div>
            <!-- /.col -->
            <hr/>
             <div class="row">
            <div class="col-sm-6 invoice-col"> To
              <address>
              <strong>
                    <asp:Label ID="lbl_customer_name" runat="server" Text=""></asp:Label></strong><br/>
              <asp:Label ID="lbl_customer_address" runat="server" Text=""></asp:Label><br/>
              Phone: <asp:Label ID="lbl_customer_contact" runat="server" Text=""></asp:Label><br/>
              GST no: <asp:Label ID="lbl_gst_no" runat="server" Text=""></asp:Label>
              </address>
            </div>
            <!-- /.col -->
            <div class="col-sm-6 invoice-col text-right">
                 <div class="table-responsive">
                <table class="table table-bordered">
                  <tbody>
                  
                   <tr>
                    <th style="width:50%">Invoice Amount</th>
                    <td><asp:Label ID="lbl_invoice_amount" runat="server" Text=""></asp:Label></td>
                  </tr>
                  <tr>
                    <th>Amount Paid</th>
                    <td><asp:Label ID="lbl_amount_paid" runat="server" Text=""></asp:Label></td>
                  </tr>
                  
                  <tr>
                    <th>Balance Amount</th>
                    <td><asp:Label ID="lbl_balance_amount" runat="server" Text=""></asp:Label></td>
                  </tr>
                 
                </tbody></table>
              </div>
                
                
               
            </div>  
             </div>
            <!-- /.col --> 
       
              
          <!-- /.row --> 
        
          <!-- Table row   table-striped-->
          <div class="table-responsive">
            <div>
                <br/>
              <table class="table table-bordered">
  <thead style="background-color:white; color:black;">
    <tr>
      <th scope="col">Date</th>
      <th scope="col">Invoice</th>
      <th scope="col">Due</th>
      <th scope="col">Payment</th>
      <th scope="col">Payment Mode</th>
      <th scope="col">Balance</th>
   
    </tr>
  </thead>

  <tbody>
      <asp:Repeater ID="Repeater2" runat="server">
 <ItemTemplate>
    <tr>
      <td>
          <asp:Label ID="lbl_date" runat="server" Text='<%# Eval("pi_date", "{0:MM/dd/yyyy}") %>'></asp:Label></td>
         <td><asp:Label ID="Label1" runat="server" Text='<%# Eval("pi_invoice") %>'></asp:Label></td>
      <td><asp:Label ID="lbl_amount" runat="server" Text='<%# Eval("pi_due") %>'></asp:Label></td>
       <td><asp:Label ID="lbl_payment" runat="server" Text='<%# Eval("pi_pay") %>'></asp:Label></td>
    <td><asp:Label ID="lbl_payment_mode" runat="server" Text='<%# Eval("pi_mode") %>'></asp:Label></td>
          <td><asp:Label ID="lbl_balance" runat="server" Text='<%# Eval("pi_balance") %>'></asp:Label></td>
     
    </tr>
       </ItemTemplate>

          </asp:Repeater>
  </tbody>

</table>
            </div>
            <!-- /.col --> 
          </div>
          <!-- /.row -->
          <br/>
          <div class="row"> 
            <!-- accepted payments column -->
            <div class="col-lg-6 col-md-6">
             
                 </div>
            <!-- /.col -->
            <div class="col-lg-6 col-md-6 text-right">
              
              <div class="table-responsive">
                <table class="table table-bordered">
                  <tbody><tr>
                    <th style="width:50%">Due Balance</th>
                    <td style="color:red;">₹ <asp:Label ID="lbl_due_balance" runat="server" Text=""></asp:Label></td>
                  </tr>
                  
                </tbody></table>
              </div>
            </div>
            <!-- /.col --> 
          </div>
          <!-- /.row --> 
          <br/>
          
        </section>
           <!-- this row will not appear when printing -->
         
        <!-- /.content --> 
      </div></div>
      </asp:Panel>
</ContentTemplate>
                </asp:UpdatePanel>
  </div></div>
    </section>
    
    </div>

  <!-- /.content-wrapper -->
  <footer class="main-footer">
    <div class="pull-right hidden-xs">Version 1.0</div>
    Copyright © 2018 PrintSoft. All rights reserved.</footer>
    <asp:GridView ID="GridView1" runat="server"></asp:GridView>

      <script type="text/javascript">
function ShowModel() {

            $('#myModal').modal('show');
}
function ShowModel2() {

    $('#myModal2').modal('show');
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

</asp:Content>

