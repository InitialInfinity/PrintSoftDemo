<%@ Page Title="" Language="C#" MasterPageFile="~/Staff/Staff.master" AutoEventWireup="true" CodeFile="salary_report.aspx.cs" Inherits="Staff_salary_report" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
 
    <style>
        .hide {
            display:none;
        }
        </style>
        
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
      <h1>Salary Report</h1>
      <ol class="breadcrumb">
        <li><a href="#">Staff</a></li>
        <li><i class="fa fa-angle-right"></i> Salary Report</li>
      </ol>
    </section>
     <section class="content">
           <asp:Panel ID="Panel2" runat="server">
              <div class="alert alert-success" role="alert">
  <button type="button" class="close" data-dismiss="alert" aria-label="Close"><span aria-hidden="true">&times;</span></button>
  <strong>Success!</strong> New Salary successfully added!
</div>     
        </asp:Panel>
       
        
        <div class="card m-t-3">
      <div class="card-body">
      <div class="row">
        <div class="col-md-3">
         <h4 class="text-black">Salary Report</h4>
        </div>
        
             <div class="col-md-9 exportbtn">
           <a href="salary.aspx"><button type="button" id="btn_mail"  title="Add Salary" class="btn btnsqr btn-primary4 btngap"> <i class="fa fa-plus"></i> Add Salary</button></a>
           
        <button type="button" id="btn_print" title="Print" onclick="printdiv('dropHere');" class="btn btnsqr btn-primary btngap"> <i class="fa fa-print"></i> Print</button>
      
        
      </div>
      </div>
      <br/>
      <div id="dropHere" class="table-responsive">
                  <table id="example1" class="table table-bordered table-striped">
                <thead>
                <tr>
                  <th>ID #</th>
                  <th>Staff Name</th>
                  <th>Salary</th>
                
                  <th>Pay</th>
                  <th>Deduction</th>
                  <th>Date</th>
                  <th>Balance</th>
                  <th>Remark</th>
                  <th class="no-print">Actions</th>
                </tr>
                </thead>
                <tbody>
               <asp:Repeater ID="Repeater1" runat="server">
              <ItemTemplate>
                   <tr>
                   <td>
              <asp:Label ID="lbl_id" runat="server" Text='<%# Eval("sal_id") %>'></asp:Label></td>
                  <td>
              <asp:Label ID="lbl_staff_name" runat="server" Text='<%# Eval("st_staff_name") %>'></asp:Label></td>
                   
                  <td><asp:Label ID="lbl_salary" runat="server" Text='<%# Eval("sal_salary") %>'></asp:Label></td>
                  
                  <td><asp:Label ID="lbl_pay" runat="server" Text='<%# Eval("sal_pay") %>'></asp:Label></td>
                  <td><asp:Label ID="lbl_deduction" runat="server" Text='<%# Eval("sal_deduction") %>'></asp:Label></td>
                  <td><asp:Label ID="lbl_date" runat="server" Text='<%# Eval("sal_date","{0:MM/dd/yyyy}") %>'></asp:Label></td>
                  <td><asp:Label ID="lbl_balance" runat="server" Text='<%# Eval("sal_balance") %>'></asp:Label></td>
                 <td><asp:Label ID="lbl_remark" runat="server" Text='<%# Eval("sal_remark") %>'></asp:Label></td>
                   <td  class="no-print">
                  <asp:LinkButton ID="LinkButton1" runat="server" OnClientClick="return confirm('Do you want to delete this Salary?');" OnClick="DeleteSalary"><i  class="fa fa-trash-o"></i></asp:LinkButton>
                 <a href="salary_slip.aspx?id=<%# Eval("sal_id") %>"><i style="padding-left:10px" class="fa fa-eye"></i></a>
                  
                  </td>
                </tr>
              </ItemTemplate>

          </asp:Repeater>
                
                </tbody>
                
              </table>


                  </div>
      </div></div>
    </section>
   </div>
  <!-- /.content-wrapper -->
  <footer class="main-footer">
    <div class="pull-right hidden-xs">Version 1.0</div>
    Copyright © 2018 PrintSoft. All rights reserved.</footer>
  
    <script type="text/javascript">
    window.setTimeout(function() {
    $(".alert").fadeTo(500, 0).slideUp(500, function(){
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
</asp:Content>

