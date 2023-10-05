<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Master.master" AutoEventWireup="true" CodeFile="list_of_customer.aspx.cs" Inherits="Master_list_of_customer" %>

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
      <h1>List of Customer</h1>
      <ol class="breadcrumb">
        <li><a href="#">Master</a></li>
        <li><i class="fa fa-angle-right"></i> List of Customer</li>
      </ol>
    </section>
  

     <section class="content">
      <asp:Panel ID="Panel1" runat="server">
              <div class="alert alert-success" role="alert">
  <button type="button" class="close" data-dismiss="alert" aria-label="Close"><span aria-hidden="true">&times;</span></button>
  <strong>Success!</strong> New Customer successfully added!
</div>     
        </asp:Panel>
        
         <div class="card">
      <div class="card-body">
      <div class="row">
        <div class="col-md-3">
         <h4 class="text-black">List of Customer</h4>
        </div>
        
             <div class="col-md-9 exportbtn">
          <a href="add_customer.aspx"><button type="button" id="btn_mail"  title="Add New Customer" class="btn btn-primary4"> <i class="fa fa-plus"></i>Add Customer</button></a>
          <button type="button" id="btn_excel" title="Export to Excel" runat="server" class="btn btn-primary3" onserverclick="excel_export"> <i class="fa fa-file-excel-o"></i> Excel</button>
           
        <button type="button" id="btn_print" title="Print" onclick="printdiv('dropHere');" class="btn btn-primary"> <i class="fa fa-print"></i> Print</button>
         <button type="button" id="btn_pdf" title="Export to PDF" runat="server"  class="btn btn-primary2" onserverclick="pdf_export"> <i class="fa fa-file-pdf-o"></i> PDF</button>
        
      </div>
      </div>
          <br/>
      <div id="dropHere" class="table-responsive">
                  <table id="example1" class="table table-bordered table-striped table-hover">
                <thead>
              
                <tr>
                  <th>ID #</th>
                  <th>Name</th>
                  <th>Contact</th>
                  <th>Balance</th>
                  <th class="no-print">Action</th>
                </tr>

                </thead>
                <tbody>
                <asp:Repeater ID="Repeater1" runat="server">
                <ItemTemplate>
                 <tr>
                  <td><a href="cust_profile.aspx?id=<%# Eval("c_id") %>"><asp:Label ID="lbl_sr" runat="server" Text='<%# Eval("c_id") %>'></asp:Label></a></td>
                  <td><a href="cust_profile.aspx?id=<%# Eval("c_id") %>">
                   <asp:Label ID="lbl_cust_name" runat="server" Text='<%# Eval("c_name") %>'></asp:Label></a></td>
                  
                  <td><a href="cust_profile.aspx?id=<%# Eval("c_id") %>"><asp:Label ID="lbl_contact" runat="server" Text='<%# Eval("c_contact") %>'></asp:Label></a></td>
                  
                  <td><a href="cust_profile.aspx?id=<%# Eval("c_id") %>"><asp:Label ID="lbl_balance" runat="server" Text='<%# Eval("c_opening_balance") %>'></asp:Label></a></td>
                 
                  
                  <td class="no-print">
                  <asp:LinkButton ID="LinkButton1" runat="server" OnClientClick="return confirm('Do you want to delete this Customer?');" OnClick="DeleteCustomer"><i  class="fa fa-trash-o"></i></asp:LinkButton>
                  <%--<a href="cust_profile.aspx?id=<%# Eval("c_id") %>"><i style="padding-left:10px" class="fa fa-eye"></i></a>--%>
                   
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

    <!--Excel Grid View-->
    <asp:GridView ID="GridView1"  dispaly="none" runat="server">
        <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
        <RowStyle ForeColor="black"/>
    </asp:GridView>
    <!--End Excel Grid View-->
  

    <script type="text/javascript">
    window.setTimeout(function() {
    $(".alert").fadeTo(500, 0).slideUp(500, function(){
        $(this).remove(); 
    });
}, 4000);
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
</asp:Content>

