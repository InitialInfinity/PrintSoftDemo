<%@ Page Title="" Language="C#" MasterPageFile="~/Bank/Bank.master" AutoEventWireup="true" CodeFile="Cheque_transaction.aspx.cs" Inherits="Bank_Cheque_transaction" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
         <meta charset="utf-8"/>
<meta http-equiv="X-UA-Compatible" content="IE=edge"/>

<!-- Tell the browser to be responsive to screen width -->
<meta content="width=device-width, initial-scale=1, maximum-scale=1, user-scalable=no" name="viewport"/>

<!-- v4.0.0 -->
<link rel="stylesheet" href="../dist/bootstrap/css/bootstrap.min.css"/>

<!-- Favicon -->
<link rel="icon" type="image/png" sizes="16x16" href="../dist/img/favicon-16x16.png"/>

<!-- Google Font -->
<link href="https://fonts.googleapis.com/css?family=Poppins:300,400,500,600,700" rel="stylesheet"/>

<!-- Theme style -->
<link rel="stylesheet" href="../dist/css/style.css"/>
<link rel="stylesheet" href="../dist/css/font-awesome/css/font-awesome.min.css"/>
<link rel="stylesheet" href="../dist/css/et-line-font/et-line-font.css"/>
<link rel="stylesheet" href="../dist/css/themify-icons/themify-icons.css"/>
<link rel="stylesheet" href="../dist/css/simple-lineicon/simple-line-icons.css"/>
    
    <script type="text/javascript">
        function ShowModel() {

            $('#myModal').modal('show');
        }
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
      <h1>Cheque Transactions</h1>
      <ol class="breadcrumb">
        <li><a href="#">Bank</a></li>
        <li><i class="fa fa-angle-right"></i> Cheque Transactions</li>
      </ol>
    </section>
     <section class="content">
      
        
        <div class="card m-t-3">
      <div class="card-body">
      <div class="row">
        <div class="col-md-6">
         <h4 class="text-black">Cheque Transactions</h4>
        </div>
        
             <div class="col-md-6 exportbtn">
          
          <button type="button" id="btn_excel" title="Export to Excel" runat="server" class="btn btnsqr btn-primary3 btngap" onserverclick="excel_export"> <i class="fa fa-file-excel-o"></i> Excel</button>
           
        <button type="button" id="btn_print" title="Print" onclick="printdiv('dropHere');" class="btn btnsqr btn-primary btngap"> <i class="fa fa-print"></i> Print</button>
         <button type="button" id="btn_pdf" title="Export to PDF" runat="server"  class="btn btnsqr btn-primary2" onserverclick="pdf_export"> <i class="fa fa-file-pdf-o"></i> PDF</button>
        
      </div>
      </div>
      
      <div id="dropHere" class="table-responsive">
                  <table id="example1" class="table table-bordered table-striped">
                <thead>
                <tr>
                  <th>Sr.No.</th>
                  <th>Date</th>
                  <th>Invoice</th>
                  <th>Customer</th>
                  <th>pay</th>
                  <th>Balance</th>
                  
                  
                  <th class="no-print">Actions</th>
                </tr>
                </thead>
                <tbody>
                   
                <asp:Repeater ID="Repeater1" runat="server" OnItemCommand="Repeater1_ItemCommand">
              <ItemTemplate>
                   <tr>
                  <td>
              <asp:Label ID="lbl_id" runat="server" Text='<%# Eval("si_id") %>'></asp:Label></td>
                  <td>
              <asp:Label ID="lbl_product_name" runat="server" Text='<%# Eval("si_date", "{0:dd/MM/yyyy}") %>'></asp:Label></td>
                  <td><asp:Label ID="lbl_unit" runat="server" Text='<%# Eval("si_invoice") %>'></asp:Label></td>
                  <td><asp:Label ID="lbl_cgst" runat="server" Text='<%# Eval("si_customer_name") %>'></asp:Label></td>
                  <td><asp:Label ID="lbl_sgst" runat="server" Text='<%# Eval("si_pay") %>'></asp:Label></td>
                  <td><asp:Label ID="Label1" runat="server" Text='<%# Eval("si_balance") %>'></asp:Label></td>
 
                  <td class="no-print"> <asp:LinkButton ID="LinkButton1" runat="server" OnClientClick="return confirm('Do you want to delete this Product?');" OnClick="DeleteTransaction"><i  class="fa fa-trash-o"></i></asp:LinkButton>
                  <asp:LinkButton ID="LinkButton2" runat="server"  CommandName="showid" CommandArgument='<%# Eval("si_id") %>'><i style="padding-left:10px" class="fa fa-eye"></i></i></asp:LinkButton>
                  <asp:LinkButton ID="LinkButton3" runat="server" CommandName="editid" CommandArgument='<%# Eval("si_id") %>'><i style="padding-left:10px" class="fa fa-edit"></i></asp:LinkButton>
                      <!--<a href=""></a><a href=""><i style="padding-left:10px" class="fa fa-edit"></i></a><a href="" runat="server" ><i style="padding-left:10px" class="fa fa-trash-o"></i></a>-->
                 </td>
                </tr>
              </ItemTemplate>

          </asp:Repeater>
                <asp:Label ID="Lbl_msg2" Style="color:red" runat="server" Text=""></asp:Label>
                </tbody>
               
              </table>

           <div class="col-md-12 no-print">
                                <div class="container">
                                    <nav aria-label="Page navigation example">
                                      
                                       <ul class="pagination">
                                        
                                            <input id="txtHidden" style="width: 28px" type="hidden" value="0" runat="server" />
                                            <li class="page-item">
                                                <asp:LinkButton ID="lbFirst" runat="server" Font-Underline="False" Font-Bold="True" OnClick="lbFirst_Click"  ><< First </asp:LinkButton></li>
                                            <li class="page-item">
                                                <asp:LinkButton ID="lbPrevious" runat="server" Font-Underline="False" Font-Bold="True" OnClick="lbPrevious_Click"  >< Prev</asp:LinkButton>
                                            </li>
                                            <li class="page-item">
                                                <asp:DataList ID="rptPaging" runat="server"  Visible="False" OnItemCommand="rptPaging_ItemCommand" OnItemDataBound="rptPaging_ItemDataBound">
                                                    <ItemTemplate>
                                                      
                                                            <asp:LinkButton ID="lbPaging" runat="server" CommandArgument='<%# Eval("PageIndex") %>' CommandName="newPage" Text='<%# Eval("PageText") %> ' Width="20px">LinkButton</asp:LinkButton>

                                                    </ItemTemplate>
                                                </asp:DataList></li>


                                            <li class="page-item">
                                                <asp:LinkButton ID="lbNext" runat="server" Font-Underline="False" Font-Bold="True" OnClick="lbNext_Click" >Next ></asp:LinkButton></li>

                                            <li class="page-item">
                                                <asp:LinkButton ID="lbLast" runat="server" Font-Underline="False" Font-Bold="True" OnClick="lbLast_Click" >Last >></asp:LinkButton></li>

                                            <li class="page-item">
                                                <asp:Label ID="lblpage" runat="server" Text=""></asp:Label></li>
                                            
                                      </ul>
                                          
                                    </nav>

                                </div>
                                    </div>
            
                  </div>
      </div></div>
    </section>
    
    </div>

  <!-- /.content-wrapper -->
  <footer class="main-footer">
    <div class="pull-right hidden-xs">Version 1.0</div>
    Copyright © 2018 PrintSoft. All rights reserved.</footer>
    <asp:GridView ID="grdpro" runat="server"></asp:GridView>
<!-- Modal -->
  <div class="modal fade" id="myModal" role="dialog">
    <div class="modal-dialog">
    
      <!-- Modal content-->
      <div class="modal-content">
        <div class="modal-header">
            <h4 class="modal-title"><asp:Label ID="lbl_name" runat="server" Text=""></asp:Label> - <asp:Label ID="lbl_date" runat="server" Text=""></asp:Label></h4>
          <button type="button" class="close" data-dismiss="modal">&times;</button>
          
        </div>
        <div class="modal-body">
          <table class="table table-hover">
  
  <tbody>
      <tr>
      <th scope="col">Invoice</th>
      <td><asp:Label ID="lbl_invoice" runat="server" Text=""></asp:Label></td>
     
    </tr>
    <tr>
      <th scope="col">Balance</th>
      <td><asp:Label ID="lbl_balance" runat="server" Text=""></asp:Label></td>
     
    </tr>
       <tr>
      <th scope="col">Advance</th>
      <td><asp:Label ID="lbl_advance" runat="server" Text=""></asp:Label></td>
     
    </tr>
      <tr>
      <th scope="col">Payment Mode</th>
      <td><asp:Label ID="lbl_payment_mode" runat="server" Text=""></asp:Label></td>
     
    </tr>
       <tr>
      <th scope="col">Total Balance</th>
      <td><asp:Label ID="lbl_total_balance" runat="server" Text=""></asp:Label></td>
     
    </tr>
      
  </tbody>
</table>
        </div>
        <div class="modal-footer">
          <button type="button" class="btn btn-default" data-dismiss="modal">Close</button>
        </div>
      </div>
      
    </div>
  </div>
   
<!-- Modal -->
  <div class="modal fade" id="myModal2" role="dialog">
    <div class="modal-dialog">
    
      <!-- Modal content-->
      <div class="modal-content">
        <div class="modal-header">
            <h4 class="modal-title">Edit Panel<asp:HiddenField ID="Txt_id" runat="server" /></h4>
          <button type="button" class="close" data-dismiss="modal">&times;</button>
          
        </div>
        <div class="modal-body">
            <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
          <table class="table table-hover">
  
  <tbody>
       
    <tr>
         
      <th scope="col">Customer Name</th>
      <td>
          <asp:TextBox ID="Txt_name" disabled="true" class="form-control" runat="server"></asp:TextBox>
      </td>
      
    </tr>
   <tr>
      <th scope="col">Balance</th>
      <td><asp:TextBox ID="Txt_balance" disabled="true" class="form-control" runat="server"></asp:TextBox></td>
     
    </tr>
      
       <tr>
      <th scope="col">Advance</th>
      <td><asp:TextBox ID="Txt_advance" class="form-control" runat="server"></asp:TextBox></td>
     
    </tr>
       <tr>
      <th scope="col">Payment Mode</th>
      <td><asp:DropDownList ID="Dd_payment_mode" class="form-control" runat="server">
                                                        <asp:ListItem>Cash</asp:ListItem>
                                                        <asp:ListItem>Debit Card</asp:ListItem>
                                                        <asp:ListItem>Credit Card</asp:ListItem>
                                                        <asp:ListItem>Cheque</asp:ListItem>
                                                        <asp:ListItem>API</asp:ListItem>
                                                        <asp:ListItem>Other</asp:ListItem>
                                                    </asp:DropDownList></td>
     
    </tr>
   <tr>
      <th scope="col">total Balance</th>
      <td><asp:TextBox ID="Txt_total_balance" class="form-control" runat="server" TextMode="SingleLine"></asp:TextBox></td>
     
    </tr>
  </tbody>
</table>
            </ContentTemplate>
        </asp:UpdatePanel> 
        </div>
        <div class="modal-footer">
             <asp:Label ID="lbl_msg" runat="server" Text=""></asp:Label>
             <asp:Button ID="Button1" class="btn btn-success" runat="server" Text="Update" OnClick="Button1_Click" />
          <button type="button" class="btn btn-default" data-dismiss="modal">Close</button>
        </div>
      </div>
      
    </div>
  </div>
           
</asp:Content>

