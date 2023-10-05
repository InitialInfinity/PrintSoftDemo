<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Master.master" AutoEventWireup="true" CodeFile="list_of_vendor.aspx.cs" Inherits="Master_list_of_vendor" %>

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
      <h1>List of Vendor</h1>
      <ol class="breadcrumb">
        <li><a href="#">Master</a></li>
        <li><i class="fa fa-angle-right"></i> List of Vendor</li>
      </ol>
    </section>
    <section class="content">
      <asp:Panel ID="Panel1" runat="server">
              <div class="alert alert-success" role="alert">
  <button type="button" class="close" data-dismiss="alert" aria-label="Close"><span aria-hidden="true">&times;</span></button>
  <strong>Success!</strong> New Vendor successfully added!
</div>     
        </asp:Panel>
         
       <div class="card">
      <div class="card-body">
      <div class="row">
        <div class="col-md-3">
         <h4 class="text-black">List of Vendor</h4>
        </div>
        
             <div class="col-md-9 exportbtn">
          <a href="../Purchase/purchase_invoice.aspx"><button type="button" id="btn_mail"  title="Add New Customer" class="btn btn-primary4"> <i class="fa fa-plus"></i>Add Purchase</button></a>
          <button type="button" id="btn_excel" title="Export to Excel" runat="server" class="btn btnsqr btn-primary3 btngap" onserverclick="excel_export"> <i class="fa fa-file-excel-o"></i> Excel</button>
           
        <button type="button" id="btn_print" title="Print" onclick="printdiv('dropHere');" class="btn btnsqr btn-primary btngap"> <i class="fa fa-print"></i> Print</button>
         <button type="button" id="btn_pdf" title="Export to PDF" runat="server"  class="btn btnsqr btn-primary2" onserverclick="pdf_export"> <i class="fa fa-file-pdf-o"></i> PDF</button>
        
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
                  <td><a href="vendor_profile.aspx?id=<%# Eval("v_id") %>"><asp:Label ID="lbl_id" runat="server" Text='<%# Eval("v_id") %>'></asp:Label></a></td>
                  <td><a href="vendor_profile.aspx?id=<%# Eval("v_id") %>">
                   <asp:Label ID="lbl_cust_name" runat="server" Text='<%# Eval("v_name") %>'></asp:Label></a></td>
                  
                  <td><a href="vendor_profile.aspx?id=<%# Eval("v_id") %>"><asp:Label ID="lbl_contact" runat="server" Text='<%# Eval("v_contact") %>'></asp:Label></a></td>
                  
                  <td><a href="vendor_profile.aspx?id=<%# Eval("v_id") %>"><asp:Label ID="lbl_balance" runat="server" Text='<%# Eval("v_opening_balance") %>'></asp:Label></a></td>
                 
                  
                  <td class="no-print">
                  <asp:LinkButton ID="LinkButton1" runat="server" OnClientClick="return confirm('Do you want to delete this Vendor?');" OnClick="DeleteVendor"><i  class="fa fa-trash-o"></i></asp:LinkButton>
                  <%--<a href="vendor_profile.aspx?id=<%# Eval("v_id") %>"><i style="padding-left:10px" class="fa fa-eye"></i></a>--%>
                   
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
  <asp:GridView ID="GridView1"  dispaly="none" runat="server">
        <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
        <RowStyle ForeColor="black"/>
    </asp:GridView>


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

