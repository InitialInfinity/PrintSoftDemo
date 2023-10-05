<%@ Page Title="" Language="C#" MasterPageFile="~/Staff/Staff.master" AutoEventWireup="true" CodeFile="salary_slip.aspx.cs" Inherits="Staff_salary_slip" %>

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
      <h1>Salary Slip</h1>
      <ol class="breadcrumb">
        <li><a href="#">Staff</a></li>
        <li><i class="fa fa-angle-right"></i> Salary Slip</li>
      </ol>
    </section>
     <section class="content">
      
        
        <div class="card m-t-3">
      <div class="card-body">
       <div class="row">
        <div class="col-md-3">
       
        </div>
        
             <div class="col-md-9 exportbtn">
    
        <button type="button" id="btn_print" title="Print" onclick="printdiv('dropHere');" class="btn btnsqr btn-primary btngap"> <i class="fa fa-print"></i> Print</button>
      
      </div>
      </div>
           
            
      
                    
           
     <div id="dropHere" class="card"> 
      <div class="card-body">
          <!--  Place a single ASPXToPDF control in the page  -->
        
        <!-- Main content -->
        <section class="invoice"> 
          <!-- title row -->
          <div class="row">
            <div class="col-lg-12">
              <h3 class="text-black">
                 <span class="pull-right">Salary Slip </span> </h3>
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
             
              </address>
            </div>
            <!-- /.col -->
            <div class="col-sm-6 invoice-col text-right">
                 <div class="table-responsive">
                <table class="table table-bordered">
                  <tbody>
                  
                   <tr>
                    <th style="width:50%">Date</th>
                    <td><asp:Label ID="lbl_date" runat="server" Text=""></asp:Label></td>
                  </tr>
                  <tr>
                    <th>Pay Slip of Month</th>
                    <td><asp:Label ID="lbl_month" runat="server" Text=""></asp:Label></td>
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
      <th scope="col">Salary</th>
      <th scope="col">Paid</th>
      <th scope="col">Deduction</th>
      <th scope="col">Remark</th>
   
    </tr>
  </thead>

  <tbody>
      <asp:Repeater ID="Repeater2" runat="server">
 <ItemTemplate>
    <tr>
      <td>
          <asp:Label ID="lbl_salary" runat="server" Text='<%# Eval("sal_salary") %>'></asp:Label></td>
      <td><asp:Label ID="lbl_paid" runat="server" Text='<%# Eval("sal_pay") %>'></asp:Label></td>
       <td><asp:Label ID="lbl_deduction" runat="server" Text='<%# Eval("sal_deduction") %>'></asp:Label></td>
       <td><asp:Label ID="lbl_remark" runat="server" Text='<%# Eval("sal_remark") %>'></asp:Label></td>
 
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
                    <th style="width:50%">Balance</th>
                    <td style="color:red;">₹ <asp:Label ID="lbl_balance" runat="server" Text=""></asp:Label></td>
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


  </div></div>
    </section>
    
    </div>

  <!-- /.content-wrapper -->
  <footer class="main-footer">
    <div class="pull-right hidden-xs">Version 1.0</div>
    Copyright © 2018 PrintSoft. All rights reserved.</footer>
    <asp:GridView ID="GridView1" runat="server"></asp:GridView>

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

