<%@ Page Title="" Language="C#" MasterPageFile="~/Reports/Reports.master" AutoEventWireup="true" CodeFile="stock_yearly.aspx.cs" Inherits="Reports_stock_yearly" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

      <!-- Content Wrapper. Contains page content -->
  <div class="content-wrapper"> 
    <!-- Content Header (Page header) -->
    <section class="content-header sty-one">
      <h1>Stock Report - Yearly</h1>
      <ol class="breadcrumb">
        <li><a href="#">Reports</a></li>
        <li><i class="fa fa-angle-right"></i>Stock Report - Yearly</li>
      </ol>
    </section>
  <section class="content">
      <%--<div class="row">
              <div class="col-lg-3">
          <div class="tile-progress tile-pink">
            <div class="tile-header">
              
              <h3>₹ <asp:Label ID="lbl_total_cgst" runat="server" Text=""></asp:Label></h3>
            </div>
            
            <div class="tile-footer">
              <h6>Total CGST</h6>
            </div>
          </div>
        </div>  
              <div class="col-lg-3">
          <div class="tile-progress tile-red">
            <div class="tile-header">
              
              <h3>₹ <asp:Label ID="lbl_total_sgst" runat="server" Text=""></asp:Label></h3>
            </div>
           
            <div class="tile-footer">
              <h6>Total SGST</h6>
            </div>
          </div>
        </div>
          <div class="col-lg-3">
          <div class="tile-progress tile-cyan">
            <div class="tile-header">
              
              <h3>₹ <asp:Label ID="lbl_total_igst" runat="server" Text=""></asp:Label></h3>
            </div>
           
            <div class="tile-footer">
              <h6>Total IGST</h6>
            </div>
          </div>
        </div>
          <div class="col-lg-3">
          <div class="tile-progress tile-aqua">
            <div class="tile-header">
              
              <h3>₹ <asp:Label ID="lbl_total_gst" runat="server" Text=""></asp:Label></h3>
            </div>
            
            <div class="tile-footer">
              <h6>Total GST</h6>
            </div>
          </div>
        </div>

 </div>--%>
      <!-- /.row -->
        
        <div class="card">
      <div class="card-body">
     <div class="row">
        <div class="col-md-3">
         <h4 class="text-black">Stock Report</h4>
        </div>
        
             <div class="col-md-9 exportbtn">
          
          
        <button type="button" id="btn_print" title="Print" onclick="printdiv('dropHere');" class="btn btnsqr btn-primary btngap"> <i class="fa fa-print"></i> Print</button>
       
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
                <%--  <th>Invoice</th>--%>
                  <th>Date</th>
                  <th>Name</th>
                  <%--<th>Status</th>--%>
                   <th>Sqrft</th>
                  
                    <th>Quantity</th>
                   
                </tr>
                </thead>
                <tbody>
             
          <asp:Repeater ID="Repeater1" runat="server"  OnItemDataBound="Repeater1_ItemDataBound" >
              <ItemTemplate>
                   <tr>
                    <td>
              <asp:Label ID="lbl_sr" runat="server" Text='<%# Eval("u_id") %>'></asp:Label></td>
                  <%--<td>
              <asp:Label ID="lbl_invoice" runat="server" Text='<%# Eval("sl_invoice_no") %>'></asp:Label></td>--%>
                  <td><asp:Label ID="lbl_date" runat="server" Text='<%# Eval("date", "{0:dd/MM/yyyy}") %>'></asp:Label></td>
                <td><asp:Label ID="lbl_cust_name" runat="server" Text='<%# Eval("p_name") %>'></asp:Label></td>
                      <%-- <td><asp:Label ID="lbl_status" runat="server" Text=''></asp:Label></td>--%>
                       <td><asp:Label ID="lbl_balance" runat="server" Text='<%# Eval("sqrft") %>'></asp:Label></td>
                       
                       <td><asp:Label ID="lbl_total" runat="server" Text='<%# Eval("quantity") %>'></asp:Label></td>
                  
                   </tr>
              </ItemTemplate>

          </asp:Repeater>
                     <asp:Label ID="Lbl_msg2" Style="color:red" runat="server" Text=""></asp:Label>
              
                </tbody>
                
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

