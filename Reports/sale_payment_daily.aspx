﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Reports/Reports.master" AutoEventWireup="true" CodeFile="sale_payment_daily.aspx.cs" Inherits="Reports_sale_payment_daily" %>

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
      <h1>Sales Payment Report - Daily</h1>
      <ol class="breadcrumb">
        <li><a href="#">Reports</a></li>
        <li><i class="fa fa-angle-right"></i>Sales Payment Report - Daily</li>
      </ol>
    </section>
    <section class="content">
       <div class="row">
          <%--<div class="col-lg-4">
          <div class="tile-progress tile-pink">
            <div class="tile-header">
              
              <h3><asp:Label ID="lbl_total_invoice" runat="server" Text=""></asp:Label></h3>
            </div>
            
            <div class="tile-footer">
              <h6>Daily Invoice </h6>
            </div>
          </div>
        </div>   --%>
            <div class="col-lg-4">
          <div class="tile-progress tile-aqua">
            <div class="tile-header">
              
              <h3>₹ <asp:Label ID="lbl_payed" runat="server" Text=""></asp:Label></h3>
            </div>
           
            <div class="tile-footer">
              <h6>Daily Payed Amt.</h6>
            </div>
          </div>
        </div>
        <%--  <div class="col-lg-4">
          <div class="tile-progress tile-cyan">
            <div class="tile-header">
              
              <h3>₹ <asp:Label ID="Lbl_balance" runat="server" Text=""></asp:Label></h3>
            </div>
           
            <div class="tile-footer">
              <h6>Daily Balance</h6>
            </div>
          </div>
        </div>--%>
         <%-- <div class="col-lg-3">
          <div class="tile-progress tile-aqua">
            <div class="tile-header">
              
              <h3>₹ <asp:Label ID="Lbl_dailyadvace" runat="server" Text=""></asp:Label></h3>
            </div>
            
            <div class="tile-footer">
              <h6>Daily Advance</h6>
            </div>
          </div>
        </div>--%>
 </div>
      <!-- /.row -->
        
        <div class="card">
      <div class="card-body">
       <div class="row">
        <div class="col-md-4">
         <h4 class="text-black">Sales Payment Report</h4>
        </div>
        
             <div class="col-md-8 exportbtn">
          
       <%--   <button type="button" id="btn_excel" title="Export to Excel" runat="server" class="btn btnsqr btn-primary3 btngap" onserverclick="excel_export"> <i class="fa fa-file-excel-o"></i> Excel</button>--%>
           
        <button type="button" id="btn_print" title="Print" onclick="printdiv('dropHere');" class="btn btnsqr btn-primary"> <i class="fa fa-print"></i> Print</button>
<%--       <button type="button" id="btn_pdf" title="Export to PDF" runat="server"  class="btn btnsqr btn-primary2" onserverclick="pdf_export"> <i class="fa fa-file-pdf-o"></i> PDF</button>--%>
       
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

                  <th>ID #</th>
                  <th>Invoice</th>
                  <th>Date</th>
                  <th>Name</th>
                  <th>Due</th>
                  <th>Discount</th>
                  <th>Payment</th>
                  <th>Payment Mode</th>
                  <th>Balance</th>
                                  
                </tr>
                </thead>
                <tbody>

          <asp:Repeater ID="Repeater1" runat="server" OnItemDataBound="Repeater1_ItemDataBound" >
              <ItemTemplate>
                   <tr>

               <td><a href="#"><asp:Label ID="lbl_sr" runat="server" Text='<%# Eval("si_id") %>'></asp:Label></a></td>
               <td><a href="#"><asp:Label ID="lbl_invoice" runat="server" Text='<%# Eval("si_invoice") %>'></asp:Label></a></td>
               <td><a href="#"><asp:Label ID="lbl_date" runat="server" Text='<%# Eval("si_date", "{0:dd/MM/yyyy}") %>'></asp:Label></a></td>
               <td><a href="#"><asp:Label ID="lbl_cust_name" runat="server" Text='<%# Eval("c_name") %>'></asp:Label></a></td>
               <td><a href="#"><asp:Label ID="lbl_due" runat="server" Text='<%# Eval("si_due") %>'></asp:Label></a></td>
               <td><a href="#"><asp:Label ID="Label1" runat="server" Text='<%# Eval("si_discount") %>'></asp:Label></a></td>
               <td><a href="#"><asp:Label ID="lbl_balance" runat="server" Text='<%# Eval("si_pay") %>'></asp:Label></a></td>
               <td><a href="#"><asp:Label ID="lbl_total" runat="server" Text='<%# Eval("si_mode") %>'></asp:Label></a></td>
               <td><a href="#"><asp:Label ID="Label2" runat="server" Text='<%# Eval("si_balance") %>'></asp:Label></a></td>

                  </tr>
              </ItemTemplate>

          </asp:Repeater>

              
                </tbody>
                 <tfoot>
                  <tr>
                  <th></th>
                  <th></th>
                  <th></th>
                
                      <asp:Panel ID="Panel1" runat="server">
                  <th id="thtotal">Total :</th>
                          </asp:Panel>
                       <th>   <asp:Label ID="lblTdue" runat="server" ></asp:Label> </th>
                   <th>   <asp:Label ID="lbl_Advance" runat="server" ></asp:Label> </th>
                   <th><asp:Label ID="lblTBalance" runat="server"></asp:Label></th>
                  <th></th>
                    <th><asp:Label ID="lblTInvoiceAmount" runat="server" ></asp:Label></th>
                   
                  <td class="no-print"></td>
                </tr>
              </tfoot>
              </table>



       
                  </div>
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

