<%@ Page Title="" Language="C#" MasterPageFile="~/Roll Purchase/RollPurchase.master" AutoEventWireup="true" CodeFile="list_of_roll_purchase.aspx.cs" Inherits="Purchase_list_of_roll_purchase" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
     <meta charset="utf-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />

    <!-- Tell the browser to be responsive to screen width -->
    <meta content="width=device-width, initial-scale=1, maximum-scale=1, user-scalable=no" name="viewport" />

    <!-- v4.0.0 -->
    <link rel="stylesheet" href="../dist/bootstrap/css/bootstrap.min.css" />

    <!-- Favicon -->
    <link rel="icon" type="image/png" sizes="16x16" href="../dist/img/favicon-16x16.png" />

    <!-- Google Font -->
    <link href="https://fonts.googleapis.com/css?family=Poppins:300,400,500,600,700" rel="stylesheet" />

    <!-- Theme style -->
    <link rel="stylesheet" href="../dist/css/style.css" />
    <link rel="stylesheet" href="../dist/css/font-awesome/css/font-awesome.min.css" />
    <link rel="stylesheet" href="../dist/css/et-line-font/et-line-font.css" />
    <link rel="stylesheet" href="../dist/css/themify-icons/themify-icons.css" />
    <link rel="stylesheet" href="../dist/css/simple-lineicon/simple-line-icons.css" />
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
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    
    <!-- Content Wrapper. Contains page content -->
  <div class="content-wrapper">
        

    <!-- Content Header (Page header) -->

    <section class="content-header sty-one">
      <h1>Roll Purchase Report</h1>
      <ol class="breadcrumb">
        <li><a href="#">Purchase</a></li>
        <li><i class="fa fa-angle-right"></i>Roll Purchase Report</li>
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
          <div class="col-lg-4">
          <div class="tile-progress tile-cyan">
            <div class="tile-header">
              
              <h3>₹ <asp:Label ID="Lbl_balance" runat="server" Text=""></asp:Label></h3>
            </div>
           
            <div class="tile-footer">
              <h6>Balance</h6>
            </div>
          </div>
        </div>
          <%--<div class="col-lg-3">
          <div class="tile-progress tile-aqua">
            <div class="tile-header">
              
              <h3>₹ <asp:Label ID="Lbl_advace" runat="server" Text=""></asp:Label></h3>
            </div>
            
            <div class="tile-footer">
              <h6>Advance</h6>
            </div>
          </div>
        </div>   --%>

 </div>
      <!-- /.row -->
        <asp:Panel ID="Panel2" runat="server">
              <div class="alert alert-success" role="alert">
  <button type="button" class="close" data-dismiss="alert" aria-label="Close"><span aria-hidden="true">&times;</span></button>
  <strong>Success!</strong> Invoice successfully created!
</div>     
        </asp:Panel>
        <div class="card">

      <div class="card-body">
      <div class="row">
        <div class="col-md-4">
         <h4 class="text-black">Roll  Purchase Report</h4>
        </div>
        
             <div class="col-md-8 exportbtn">
          <a href="roll_purchase.aspx"><button type="button" id="btn_mail"  title="Create New Roll Purchase" class="btn btnsqr btn-primary4 btngap"> <i class="fa fa-plus"></i>Add Roll Purchase</button></a>
        <%--  <a href="list_of_purchase.aspx"><button type="button" id="btn_roll"  title="List of Purchase" class="btn btnsqr btn-primary6 btngap"> <i class="fa fa-list"></i> Purchase List</button></a>--%>
                 <button type="button" id="btn_excel" title="Export to Excel" runat="server" class="btn btnsqr btn-primary3 btngap" onserverclick="excel_export"> <i class="fa fa-file-excel-o"></i> Excel</button>
           
        <button type="button" id="btn_print" title="Print" onclick="printdiv('dropHere');" class="btn btnsqr btn-primary btngap"> <i class="fa fa-print"></i> Print</button>
         <button type="button" id="btn_pdf" title="Export to PDF" runat="server"  class="btn btnsqr btn-primary2" onserverclick="pdf_export"> <i class="fa fa-file-pdf-o"></i> PDF</button>
        
      </div>
      </div>
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
                  <th>Contact</th>
                   
                  <th>Status</th>
                   <th>Balance</th>
                   <th>Total</th>
                   
                  <th class="no-print">Actions</th>
                </tr>
                </thead>
                <tbody>
          <asp:Repeater ID="Repeater1" runat="server"  OnItemDataBound="Repeater1_ItemDataBound">
              <ItemTemplate>
                   <tr>
                    <td>
                        <a href="roll_bill.aspx?invoice=<%# Eval("rpu_invoice_no") %>">
              <asp:Label ID="lbl_sr" runat="server" Text='<%# Eval("rpu_id") %>'></asp:Label></a></td>
                  <td>
                      <a href="roll_bill.aspx?invoice=<%# Eval("rpu_invoice_no") %>">
              <asp:Label ID="lbl_invoice" runat="server" Text='<%# Eval("rpu_invoice_no") %>'></asp:Label></a></td>
                  <td><a href="roll_bill.aspx?invoice=<%# Eval("rpu_invoice_no") %>"><asp:Label ID="lbl_date" runat="server" Text='<%# Eval("rpu_date", "{0:dd/MM/yyyy}") %>'></asp:Label></a></td>
                <td><a href="roll_bill.aspx?invoice=<%# Eval("rpu_invoice_no") %>"><asp:Label ID="lbl_cust_name" runat="server" Text='<%# Eval("v_name") %>'></asp:Label></a></td>
                       <td><a href="roll_bill.aspx?invoice=<%# Eval("rpu_invoice_no") %>"><asp:Label ID="lbl_cust_contact" runat="server" Text='<%# Eval("v_contact") %>'></asp:Label></a></td>
                      
                     
                       <td><asp:Label ID="lbl_status" runat="server" Text=''></asp:Label></td>
                       <td><asp:Label ID="lbl_balance" runat="server" Text='<%# Eval("rpu_balance") %>'></asp:Label></td>
                       <td><asp:Label ID="lbl_total" runat="server" Text='<%# Eval("rpu_total") %>'></asp:Label></td>
                   <td class="no-print">
                  <asp:LinkButton ID="LinkButton1" runat="server" OnClientClick="return confirm('Do you want to delete this Purchase Invoice?');" OnClick="DeleteSale"><i  class="fa fa-trash-o"></i></asp:LinkButton>
                 <a href="roll_bill.aspx?invoice=<%# Eval("rpu_invoice_no") %>"><i style="padding-left:10px" class="fa fa-eye"></i></i></a>
                  <a href="edit_roll_bill.aspx?invoice=<%# Eval("rpu_invoice_no") %>"> <i style="padding-left:10px" class="fa fa-edit"></i></a>
                     
                  </td>
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
      <asp:GridView ID="GridView1"  dispaly="none" runat="server">
        <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
        <RowStyle ForeColor="black"/>
    </asp:GridView>
</asp:Content>



