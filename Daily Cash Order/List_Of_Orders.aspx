<%@ Page Title="" Language="C#" MasterPageFile="~/Daily Cash Order/Cash.master" AutoEventWireup="true" CodeFile="List_Of_Orders.aspx.cs" Inherits="Daily_Cash_Order_List_Of_Orders" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
      <!-- Content Wrapper. Contains page content -->
  <div class="content-wrapper">
        

    <!-- Content Header (Page header) -->

    <section class="content-header sty-one">
      <h1>Cash Report</h1>
      <ol class="breadcrumb">
        <li><a href="#">Sale</a></li>
        <li><i class="fa fa-angle-right"></i>Cash Report</li>
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
              <h6>Total Invoice </h6>
            </div>
          </div>
        </div>   
            <div class="col-lg-4">
          <div class="tile-progress tile-red">
            <div class="tile-header">
              
              <h3>₹ <asp:Label ID="lbl_total_invoice_amount" runat="server" Text=""></asp:Label></h3>
            </div>
           
            <div class="tile-footer">
              <h6>Total Invoice Amt.</h6>
            </div>
          </div>
        </div>


 </div>
      <!-- /.row -->
         <asp:Panel ID="Panel2" runat="server">
              <div class="alert alert-success" role="alert">
  <button type="button" class="close" data-dismiss="alert" aria-label="Close"><span aria-hidden="true">&times;</span></button>
  <strong>Success!</strong> Estimate successfully created!
</div>     
        </asp:Panel>          
        
        <div class="card">

      <div class="card-body">
      <div class="row">
        <div class="col-md-3">
         <h4 class="text-black">Cash Report</h4>
        </div>
        
             <div class="col-md-9 exportbtn">
                   <asp:TextBox ID="txtdate" runat="server" visible="false"></asp:TextBox>
           <a href="Create_Order.aspx"><button type="button" id="btn_mail"  title="Create New Estimate" class="btn btnsqr btn-primary4 btngap"> <i class="fa fa-plus"></i>Add Order</button></a>
          <%--<button type="button" id="btn_excel" title="Export to Excel" runat="server" class="btn btnsqr btn-primary3 btngap" onserverclick="excel_export"> <i class="fa fa-file-excel-o"></i> Excel</button>--%>
           
        <button type="button" id="btn_print" title="Print" onclick="printdiv('dropHere');" class="btn btnsqr btn-primary btngap"> <i class="fa fa-print"></i> Print</button>
         <%--<button type="button" id="btn_pdf" title="Export to PDF" runat="server"  class="btn btnsqr btn-primary2" onserverclick="pdf_export"> <i class="fa fa-file-pdf-o"></i> PDF</button>--%>
       
        
      </div>
      </div>
          <br/>
     <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
       <div id="dropHere" class="table-responsive">
            <asp:Panel ID="pnlinvoice" runat="server">
                  <table id="example1" class="table table-bordered table-striped table-hover">
                <thead>
                <tr>
                  <th>ID #</th>
                  <th>Order No</th>
                  <th>Date</th>
                  <th>Name</th>
                  <th>Phone</th>
                  <th>Total</th>
                  <th>Advance</th>                                  
                   <th>Balance</th>
                   
                   
                  <th class="no-print">Actions</th>
                </tr>
                </thead>
                <tbody>
                
          <asp:Repeater ID="Repeater1" runat="server"  >
              <ItemTemplate>
                   <tr>
                    <td><a href="wgst_bill.aspx?invoice=<%# Eval("quw_no") %>">
              <asp:Label ID="lbl_sr" runat="server" Text='<%# Eval("quw_id") %>'></asp:Label></a></td>
                 <td><a href="wgst_bill.aspx?invoice=<%# Eval("quw_no") %>">
              <asp:Label ID="lbl_invoice_no" runat="server" Text='<%# Eval("quw_no") %>'></asp:Label></a></td>
                  <td><a href="wgst_bill.aspx?invoice=<%# Eval("quw_no") %>"><asp:Label ID="lbl_date" runat="server" Text='<%# Eval("quw_date", "{0:dd/MM/yyyy}") %>'></asp:Label></a></td>
                          <td><a href="wgst_bill.aspx?invoice=<%# Eval("quw_no") %>">
              <asp:Label ID="lbl_invoice" runat="server" Text='<%# Eval("quw_name") %>'></asp:Label></a></td>
                       <td><a href="wgst_bill.aspx?invoice=<%# Eval("quw_no") %>">
              <asp:Label ID="Label4" runat="server" Text='<%# Eval("quw_phone") %>'></asp:Label></a></td>
                                   <td><a href="wgst_bill.aspx?invoice=<%# Eval("quw_no") %>"><asp:Label ID="lbl_total" runat="server" Text='<%# Eval("quw_total") %>'></asp:Label></a></td>
                        <td><a href="wgst_bill.aspx?invoice=<%# Eval("quw_no") %>"><asp:Label ID="Label3" runat="server" Text='<%# Eval("quw_adjustment") %>'></asp:Label></a></td>
                        <%--   <td><a href="wgst_bill.aspx?invoice=<%# Eval("quw_no") %>"><asp:Label ID="Label1" runat="server" Text='<%# Eval("quw_discount") %>'></asp:Label></a></td>--%>
                           <td><a href="wgst_bill.aspx?invoice=<%# Eval("quw_no") %>"><asp:Label ID="Label2" runat="server" Text='<%# Eval("quw_balance") %>'></asp:Label></a></td>
                  <asp:Panel ID="Panel1" runat="server">
                     
                        <td class="no-print" id="tbltextbox" runat="server">
                  <asp:LinkButton ID="LinkButton1" runat="server" OnClientClick="return confirm('Do you want to delete this daily report?');" OnClick="DeleteSale"><i  class="fa fa-trash-o"></i></asp:LinkButton>
                 <%--<a href="wgst_bill.aspx?invoice=<%# Eval("est_invoice_no") %>"><i style="padding-left:10px" class="fa fa-eye"></i></a>--%>
               
                     
                  </td>
                      </asp:Panel>
                   </tr>
              </ItemTemplate>

          </asp:Repeater>
                      <asp:Label ID="Lbl_msg2" Style="color:red" runat="server" Text=""></asp:Label>
              
                </tbody>
                
              </table>
           </asp:Panel>


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
     <style>
   @media print {
    @page { margin: 0; }
  }
    </style>
</asp:Content>

