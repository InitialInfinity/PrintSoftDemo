<%@ Page Title="" Language="C#" MasterPageFile="~/Reports/Reports.master" AutoEventWireup="true" CodeFile="cust_bal.aspx.cs" Inherits="Reports_cust_bal" %>

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
      <h1>List of Customer Balance</h1>
      <ol class="breadcrumb">
        <li><a href="#">Report</a></li>
        <li><i class="fa fa-angle-right"></i> List of Customer Balance</li>
      </ol>
    </section>
  

     <section class="content">
    
        <div class="card">
      <div class="card-body">
      <div class="row">
        <div class="col-md-3">
         <h4 class="text-black">Customer List</h4>
        </div>
        
             <div class="col-md-9 exportbtn">
          
          <button type="button" id="btn_excel" title="Export to Excel" runat="server" class="btn btnsqr btn-primary3 btngap" onserverclick="excel_export"> <i class="fa fa-file-excel-o"></i> Excel</button>
           
        <button type="button" id="btn_print" title="Print" onclick="printdiv('dropHere');" class="btn btnsqr btn-primary btngap"> <i class="fa fa-print"></i> Print</button>
         <button type="button" id="btn_pdf" title="Export to PDF" runat="server"  class="btn btnsqr btn-primary2" onserverclick="pdf_export"> <i class="fa fa-file-pdf-o"></i> PDF</button>
        
      </div>
      </div>
          <br/>
      <div id="dropHere" class="table-responsive">
        
         
         
                  <table id="example1" class="table table-bordered table-striped" >
                <thead>
                <tr>
                  <th>Sr.No.</th>
                  <th>Customer</th>
                  
                  <th>Balance</th>
               
                </tr>
                </thead>
                <tbody>
                  
          <asp:Repeater ID="Repeater1" runat="server" >
              <ItemTemplate>
                  
                   <tr>
                       
                    <td>
              <asp:Label ID="lbl_sr" runat="server" Text='<%# Eval("c_id") %>'></asp:Label></td>
                  <td>
              <asp:Label ID="lbl_cust_name" runat="server" Text='<%# Eval("c_name") %>'></asp:Label> </td>
                  
                  <td><strong style="color:red;"><asp:Label ID="lbl_balance" runat="server" Text='<%# Eval("c_opening_balance") %>'></asp:Label></strong></td>
                 
                  
                           
                </tr>
              
              </ItemTemplate>

          </asp:Repeater>
                    <asp:Label ID="Lbl_msg2" Style="color:red" runat="server" Text=""></asp:Label>
              
                </tbody>
                        <tfoot>
                  <tr>
                 
                  <th></th>
                  
                  
                      <asp:Panel ID="Panel1" runat="server">
                  <th>Total :</th>
                          </asp:Panel>
                  
                   <th>   <asp:Label ID="lbl_bal" runat="server" ></asp:Label> </th>    
             
                </tr>
              </tfoot>
                
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
</asp:Content>


