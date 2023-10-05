<%@ Page Title="" Language="C#" MasterPageFile="~/Reports/Reports.master" AutoEventWireup="true" CodeFile="gstq_report.aspx.cs" Inherits="admin_panel_Reports_gstq_report" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    
      
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
      
    <!-- Content Wrapper. Contains page content -->
  <div class="content-wrapper">
        

    <!-- Content Header (Page header) -->

    <section class="content-header sty-one">
      <h1>GST Quotation Report</h1>
      <ol class="breadcrumb">
        <li><a href="#">Quotation</a></li>
        <li><i class="fa fa-angle-right"></i>GST Quotation Report</li>
      </ol>

    </section>
     
       
     
     <section class="content">
     
        <div class="card">

      <div class="card-body">
      <div class="row">
        <div class="col-md-4">
         <h4 class="text-black">GST Quotation Report</h4>
        </div>
        
             <div class="col-md-8 exportbtn">
           <a href="../Quotation/gst_quotation.aspx"><button type="button" id="btn_mail"  title="Create New Invoice" class="btn btnsqr btn-primary4 btngap"> <i class="fa fa-plus"></i>Add Quote</button></a>
          <button type="button" id="btn_excel" title="Export to Excel" runat="server" class="btn btnsqr btn-primary3 btngap" onserverclick="excel_export"> <i class="fa fa-file-excel-o"></i> Excel</button>
           
        <button type="button" id="btn_print" title="Print" onclick="printdiv('dropHere');" class="btn btnsqr btn-primary"> <i class="fa fa-print"></i> Print</button>
        <button type="button" id="btn_pdf" title="Export to PDF" runat="server"  class="btn btnsqr btn-primary2" onserverclick="pdf_export"> <i class="fa fa-file-pdf-o"></i> PDF</button>
       
        
      </div>
      </div>
          <br/>
<asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                    
       <div id="dropHere" class="table-responsive">
            <asp:Panel ID="pnlinvoice" runat="server">
                  <table id="example1" class="table table-bordered table-striped">
                <thead>
                <tr>
                  <th>Sr.No.</th>
                  <th>Quotation</th>
                  <th>Date</th>
                  <th>Name</th>
                  
                    <th>Total</th>
                   
                  <th class="no-print">Actions</th>
                </tr>
                </thead>
                <tbody>
            
          <asp:Repeater ID="Repeater1" runat="server">
              <ItemTemplate>
                   <tr>
                    <td>
              <asp:Label ID="lbl_sr" runat="server" Text='<%# Eval("qu_id") %>'></asp:Label></td>
                  <td>
              <asp:Label ID="lbl_invoice" runat="server" Text='<%# Eval("qu_invoice_no") %>'></asp:Label></td>
                  <td><asp:Label ID="lbl_date" runat="server" Text='<%# Eval("qu_date", "{0:dd/MM/yyyy}") %>'></asp:Label></td>
                <td><asp:Label ID="lbl_cust_name" runat="server" Text='<%# Eval("c_name") %>'></asp:Label></td>
                       
                       <td><asp:Label ID="lbl_total" runat="server" Text='<%# Eval("qu_total") %>'></asp:Label></td>
                  <asp:Panel ID="Panel1" runat="server">
                     
                        <td class="no-print" id="tbltextbox" runat="server">
                  <asp:LinkButton ID="LinkButton1" runat="server" OnClientClick="return confirm('Do you want to delete this GST Quotation?');" OnClick="DeleteSale"><i  class="fa fa-trash-o"></i></asp:LinkButton>
                 <a href="../Quotation/gst_bill.aspx?invoice=<%# Eval("qu_invoice_no") %>"><i style="padding-left:10px" class="fa fa-eye"></i></i></a>
                 <a href=""> <i style="padding-left:10px" class="fa fa-edit"></i></a>
                     
                  </td>
                      </asp:Panel>
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
                  
                      <asp:Panel ID="Panel1" runat="server">
                  <th id="thtotal">Total :</th>
                          </asp:Panel>
                   <th>   <asp:Label ID="lbl_Total" runat="server" ></asp:Label> </th>
             
               
                   
                  <td class="no-print"></td>
                </tr>
              </tfoot>
                
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
     <style>
   @media print {
    @page { margin: 0; }
  }
    </style>
</asp:Content>

