<%@ Page Title="" Language="C#" MasterPageFile="~/Reports/Reports.master" AutoEventWireup="true" CodeFile="est_yearly.aspx.cs" Inherits="Reports_est_yearly" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
   
  
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
      

      <!-- Content Wrapper. Contains page content -->
  <div class="content-wrapper"> 
    <!-- Content Header (Page header) -->
    <section class="content-header sty-one">
      <h1>Estimae Report - Yearly</h1>
      <ol class="breadcrumb">
        <li><a href="#">Reports</a></li>
        <li><i class="fa fa-angle-right"></i>Estimae Report - Yearly</li>
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
              <h6>Yearly Invoice </h6>
            </div>
          </div>
        </div>  
              <div class="col-lg-4">
          <div class="tile-progress tile-red">
            <div class="tile-header">
              
              <h3>₹ <asp:Label ID="lbl_total_invoice_amount" runat="server" Text=""></asp:Label></h3>
            </div>
           
            <div class="tile-footer">
              <h6>Yearly Invoice Amt.</h6>
            </div>
          </div>
        </div>
          <div class="col-lg-4">
          <div class="tile-progress tile-cyan">
            <div class="tile-header">
              
              <h3>₹ <asp:Label ID="Lbl_balance" runat="server" Text=""></asp:Label></h3>
            </div>
           
            <div class="tile-footer">
              <h6>Yearly Balance</h6>
            </div>
          </div>
        </div>
          <%--<div class="col-lg-3">
          <div class="tile-progress tile-aqua">
            <div class="tile-header">
              
              <h3>₹ <asp:Label ID="Lbl_yearlyadvace" runat="server" Text=""></asp:Label></h3>
            </div>
            
            <div class="tile-footer">
              <h6>Yearly Advance</h6>
            </div>
          </div>
        </div>--%>

 </div>
      <!-- /.row -->
        
        <div class="card">
      <div class="card-body">
     <div class="row">
        <div class="col-md-3">
         <h4 class="text-black">Estimae Report</h4>
        </div>
        
             <div class="col-md-9 exportbtn">
 
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
                  <th>Estimae</th>
                  <th>Date</th>
                  <th>Name</th>
                  <th>Status</th>
                    <th>Advance</th>
                   <th>Balance</th>
                  
                    <th>Total</th>
                   
                  <th class="no-print">Actions</th>
                </tr>
                </thead>
                <tbody>
               
          <asp:Repeater ID="Repeater1" runat="server"  OnItemDataBound="Repeater1_ItemDataBound" >
              <ItemTemplate>
                   <tr>
                    <td>
              <asp:Label ID="lbl_sr" runat="server" Text='<%# Eval("est_id") %>'></asp:Label></td>
                  <td>
              <asp:Label ID="lbl_invoice" runat="server" Text='<%# Eval("est_invoice_no") %>'></asp:Label></td>
                  <td><asp:Label ID="lbl_date" runat="server" Text='<%# Eval("est_date", "{0:dd/MM/yyyy}") %>'></asp:Label></td>
                <td><asp:Label ID="lbl_cust_name" runat="server" Text='<%# Eval("c_name") %>'></asp:Label></td>
                       <td><asp:Label ID="lbl_status" runat="server" Text=''></asp:Label></td>
                        <td><asp:Label ID="Label1" runat="server" Text='<%# Eval("est_adjustment") %>'></asp:Label></td>
                       <td><asp:Label ID="lbl_balance" runat="server" Text='<%# Eval("est_balance") %>'></asp:Label></td>
                       
                       <td><asp:Label ID="lbl_total" runat="server" Text='<%# Eval("est_total") %>'></asp:Label></td>
                   <td class="no-print">
                  <asp:LinkButton ID="LinkButton1" runat="server" OnClientClick="return confirm('Do you want to delete this Estimate Invoice?');" OnClick="DeleteSale" style="display:none"><i  class="fa fa-trash-o"></i></asp:LinkButton>
                 <a href="../Sale/wgst_bill.aspx?invoice=<%# Eval("est_invoice_no") %>"><i style="padding-left:10px" class="fa fa-eye"></i></i></a>
                  <a href="../Sale/wgst_edit_bill.aspx?invoice=<%# Eval("est_invoice_no") %>" style="display:none"> <i style="padding-left:10px" class="fa fa-edit"></i></a>
                     
                  </td>
                   </tr>
              </ItemTemplate>

          </asp:Repeater>
                     <asp:Label ID="Lbl_msg2" Style="color:red" runat="server" Text=""></asp:Label>
              
                </tbody>
                       <tfoot>
                  <tr>
                  <th></th>
                  <th></th>
                  <th></th>
                  <th></th>  
                      <asp:Panel ID="Panel1" runat="server">
                  <th id="thtotal">Total :</th>
                          </asp:Panel>
                   <th>   <asp:Label ID="lbl_Advance" runat="server" ></asp:Label> </th>
                   <th><asp:Label ID="lblTBalance" runat="server"></asp:Label></th>
                  
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

