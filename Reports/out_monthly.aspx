﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Reports/Reports.master" AutoEventWireup="true" CodeFile="out_monthly.aspx.cs" Inherits="Reports_out_monthly" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">


        

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
     

      <!-- Content Wrapper. Contains page content -->
  <div class="content-wrapper"> 
    <!-- Content Header (Page header) -->
    <section class="content-header sty-one">
      <h1>Outstanding Report - Monthly</h1>
      <ol class="breadcrumb">
        <li><a href="#">Reports</a></li>
        <li><i class="fa fa-angle-right"></i>Outstanding Report - Monthly</li>
      </ol>
    </section>
   <section class="content">
      <div class="row">
             <div class="col-lg-4">
          <div class="tile-progress tile-pink">
            <div class="tile-header">
              
              <h3><asp:Label ID="lbl_total_invoice" runat="server" Text=""></asp:Label></h3>
            </div>
            
            <div class="tile-footer">
              <h6>Monthly Invoice </h6>
            </div>
          </div>
        </div>   
            <div class="col-lg-4">
          <div class="tile-progress tile-red">
            <div class="tile-header">
              
              <h3>₹ <asp:Label ID="lbl_total_invoice_amount" runat="server" Text=""></asp:Label></h3>
            </div>
           
            <div class="tile-footer">
              <h6>Monthly Invoice Amt.</h6>
            </div>
          </div>
        </div>
          <div class="col-lg-4">
          <div class="tile-progress tile-cyan">
            <div class="tile-header">
              
              <h3>₹ <asp:Label ID="Lbl_balance" runat="server" Text=""></asp:Label></h3>
            </div>
           
            <div class="tile-footer">
              <h6>Monthly Balance</h6>
            </div>
          </div>
        </div>
               

 </div>
      <!-- /.row -->
        
        <div class="card">
      <div class="card-body">
      <div class="row">
        <div class="col-md-3">
         <h4 class="text-black">Outstanding Report</h4>
        </div>
        
             <div class="col-md-9 exportbtn">
          
          <button type="button" id="btn_excel" title="Export to Excel" runat="server" class="btn btnsqr btn-primary3 btngap" onserverclick="excel_export"> <i class="fa fa-file-excel-o"></i> Excel</button>
           
        <button type="button" id="btn_print" title="Print" onclick="printdiv('dropHere');" class="btn btnsqr btn-primary"> <i class="fa fa-print"></i> Print</button>
         
      </div>
      </div>
          <br/>
     <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
      <div id="dropHere" class="table-responsive">
                  <table id="example1" class="table table-bordered table-striped">
                <thead>
                <tr>
                  <th>Sr.No.</th>
                  <th>Invoice</th>
                  <th>Date</th>
                  <th>Name</th>
                  <th>Status</th>
                   <th>Balance</th>
                  
                    <th>Total</th>
                   
                 
                </tr>
                </thead>
                <tbody>

          <asp:Repeater ID="Repeater1" runat="server" OnItemDataBound="Repeater1_ItemDataBound"  >
              <ItemTemplate>
                   <tr>
                    <td>
              <asp:Label ID="lbl_sr" runat="server" Text='<%# Eval("sl_id") %>'></asp:Label></td>
                  <td>
              <asp:Label ID="lbl_invoice" runat="server" Text='<%# Eval("sl_invoice_no") %>'></asp:Label></td>
                  <td><asp:Label ID="lbl_date" runat="server" Text='<%# Eval("sl_date", "{0:dd/MM/yyyy}") %>'></asp:Label></td>
                <td><asp:Label ID="lbl_cust_name" runat="server" Text='<%# Eval("c_name") %>'></asp:Label></td>
                      <td><asp:Label ID="lbl_status" runat="server" Text=''></asp:Label></td>
                       <td><asp:Label ID="lbl_balance" runat="server" Text='<%# Eval("sl_balance") %>'></asp:Label></td>
                       
                       <td><asp:Label ID="lbl_total" runat="server" Text='<%# Eval("sl_total") %>'></asp:Label></td>
              
                         </tr>
              </ItemTemplate>

          </asp:Repeater>

              
                </tbody>
                        <tfoot>
                  <tr>
                  <th></th>
                  <th></th>
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
                </ContentTemplate>
        </asp:UpdatePanel>
      </div></div>
    </section>
 <asp:HiddenField ID="lbl_opening_balance" runat="server" />
      
  </div>
    
  <!-- /.content-wrapper -->
  <footer class="main-footer">
    <div class="pull-right hidden-xs">Version 1.0</div>
    Copyright © 2018 PrintSoft. All rights reserved.</footer>
                
 <asp:GridView ID="GridView1" display="none" runat="server"></asp:GridView>



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


