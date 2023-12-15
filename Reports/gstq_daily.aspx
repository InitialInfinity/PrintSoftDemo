<%@ Page Title="" Language="C#" MasterPageFile="~/Reports/Reports.master" AutoEventWireup="true" CodeFile="gstq_daily.aspx.cs" Inherits="Reports_gstq_daily" %>

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
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
      <!-- Content Wrapper. Contains page content -->
  <div class="content-wrapper"> 
    <!-- Content Header (Page header) -->
    <section class="content-header sty-one">
      <h1>GST Quotation Report - Daily</h1>
      <ol class="breadcrumb">
        <li><a href="#">Reports</a></li>
        <li><i class="fa fa-angle-right"></i>GST Quotation Report - Daily</li>
      </ol>
    </section>
    <section class="content">
      
        
        <div class="card m-t-3">
      <div class="card-body">
       <div class="row">
        <div class="col-md-3">
         <h4 class="text-black">GST Quotation Report</h4>
        </div>
        
             <div class="col-md-9 exportbtn">
          
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
                  <th>Invoice</th>
                  <th>Date</th>
                  <th>Name</th>
                  <th>Contact</th>
                  <th>Address</th>
                  <th>GST</th>
                  
                    <th>Total</th>
                   
                  <th class="no-print">Actions</th>
                </tr>
                </thead>
                <tbody>

          <asp:Repeater ID="Repeater1" runat="server" >
              <ItemTemplate>
                   <tr>
                    <td>
              <asp:Label ID="lbl_sr" runat="server" Text='<%# Eval("qu_id") %>'></asp:Label></td>
                  <td>
              <asp:Label ID="lbl_invoice" runat="server" Text='<%# Eval("qu_invoice_no") %>'></asp:Label></td>
                  <td><asp:Label ID="lbl_date" runat="server" Text='<%# Eval("qu_date", "{0:dd/MM/yyyy}") %>'></asp:Label></td>
                <td><asp:Label ID="lbl_cust_name" runat="server" Text='<%# Eval("qu_customer_name") %>'></asp:Label></td>
                       <td><asp:Label ID="lbl_cust_contact" runat="server" Text='<%# Eval("qu_customer_contact") %>'></asp:Label></td>
                       <td><asp:Label ID="lbl_cust_address" runat="server" Text='<%# Eval("qu_customer_address") %>'></asp:Label></td>
                       <td><asp:Label ID="lbl_cust_gst_no" runat="server" Text='<%# Eval("qu_customer_gst_no") %>'></asp:Label></td>
                       
                       <td><asp:Label ID="lbl_total" runat="server" Text='<%# Eval("qu_total") %>'></asp:Label></td>
                 <td class="no-print">
                  <asp:LinkButton ID="LinkButton1" runat="server" OnClientClick="return confirm('Do you want to delete this Sale Invoice?');" OnClick="DeleteSale" style="display:none"><i  class="fa fa-trash-o"></i></asp:LinkButton>
                 <a href="../Quotation/gst_bill.aspx?invoice=<%# Eval("qu_invoice_no") %>"><i style="padding-left:10px" class="fa fa-eye"></i></i></a>
                  <asp:LinkButton ID="LinkButton3" runat="server" style="display:none"><i style="padding-left:10px" class="fa fa-edit" ></i></asp:LinkButton>
                     
                  </td>
                        </tr>
              </ItemTemplate>

          </asp:Repeater>

              
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
                                                <asp:LinkButton ID="lbPrevious" runat="server" Font-Underline="False" Font-Bold="True" OnClick="lbPrevious_Click" >< Prev</asp:LinkButton>
                                            </li>
                                            <li class="page-item">
                                                <asp:DataList ID="rptPaging" runat="server"  Visible="False" OnItemCommand="rptPaging_ItemCommand" OnItemDataBound="rptPaging_ItemDataBound" >
                                                    <ItemTemplate>
                                                      
                                                            <asp:LinkButton ID="lbPaging" runat="server" CommandArgument='<%# Eval("PageIndex") %>' CommandName="newPage" Text='<%# Eval("PageText") %> ' Width="20px">LinkButton</asp:LinkButton>

                                                    </ItemTemplate>
                                                </asp:DataList></li>


                                            <li class="page-item">
                                                <asp:LinkButton ID="lbNext" runat="server" Font-Underline="False" Font-Bold="True" OnClick="lbNext_Click"  >Next ></asp:LinkButton></li>

                                            <li class="page-item">
                                                <asp:LinkButton ID="lbLast" runat="server" Font-Underline="False" Font-Bold="True" OnClick="lbLast_Click"  >Last >></asp:LinkButton></li>

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
</asp:Content>

