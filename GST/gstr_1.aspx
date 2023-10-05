<%@ Page Title="" Language="C#" MasterPageFile="~/GST/GST.master" AutoEventWireup="true" CodeFile="gstr_1.aspx.cs" Inherits="GST_gstr_1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
     
    <style>
        .card-body {
    padding: 0 !important;
}
    </style>
 
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
      <h1>GSTR 1</h1>
      <ol class="breadcrumb">
        <li><a href="#">GST</a></li>
        <li><i class="fa fa-angle-right"></i>GSTR 1</li>
      </ol>
    </section>
       <section class="content">
      <div class="row m-b-3">
        
        <div class="col-md-12">
          <div class="card">
            
            <!-- Nav tabs -->
            <ul class="nav nav-tabs customtab" role="tablist">
              <li class="nav-item"> <a class="nav-link active" data-toggle="tab" href="#jan" role="tab"><span class="hidden-sm-up"></span> <span class="hidden-xs-down">January</span></a> </li>
              <li class="nav-item"> <a class="nav-link" data-toggle="tab" href="#feb" role="tab"><span class="hidden-sm-up"></span> <span class="hidden-xs-down">February</span></a> </li>
              <li class="nav-item"> <a class="nav-link" data-toggle="tab" href="#march" role="tab"><span class="hidden-sm-up"></span> <span class="hidden-xs-down">March</span></a> </li>
              <li class="nav-item"> <a class="nav-link" data-toggle="tab" href="#april" role="tab"><span class="hidden-sm-up"></span> <span class="hidden-xs-down">April</span></a> </li>
              <li class="nav-item"> <a class="nav-link" data-toggle="tab" href="#may" role="tab"><span class="hidden-sm-up"></span> <span class="hidden-xs-down">May</span></a> </li>
              <li class="nav-item"> <a class="nav-link" data-toggle="tab" href="#june" role="tab"><span class="hidden-sm-up"></span> <span class="hidden-xs-down">June</span></a> </li>
              <li class="nav-item"> <a class="nav-link" data-toggle="tab" href="#july" role="tab"><span class="hidden-sm-up"></span> <span class="hidden-xs-down">July</span></a> </li>
              <li class="nav-item"> <a class="nav-link" data-toggle="tab" href="#aug" role="tab"><span class="hidden-sm-up"></span> <span class="hidden-xs-down">August</span></a> </li>
              <li class="nav-item"> <a class="nav-link" data-toggle="tab" href="#sep" role="tab"><span class="hidden-sm-up"></span> <span class="hidden-xs-down">September</span></a> </li>
              <li class="nav-item"> <a class="nav-link" data-toggle="tab" href="#oct" role="tab"><span class="hidden-sm-up"></span> <span class="hidden-xs-down">October</span></a> </li>
              <li class="nav-item"> <a class="nav-link" data-toggle="tab" href="#nov" role="tab"><span class="hidden-sm-up"></span> <span class="hidden-xs-down">November</span></a> </li>
              <li class="nav-item"> <a class="nav-link" data-toggle="tab" href="#dec" role="tab"><span class="hidden-sm-up"></span> <span class="hidden-xs-down">December</span></a> </li>
            </ul>
            <!-- Tab panes -->
            <div class="tab-content">
              <div class="tab-pane active p-20" id="jan" role="tabpanel">
                <div class="pad-20">
                <div class="card-body">
              <div class="form-horizontal form-bordered">
                  <!-- Nav tabs -->
            <ul class="nav nav-tabs customtab" role="tablist">
              <li class="nav-item"> <a class="nav-link active" data-toggle="tab" href="#b2b" role="tab"><span class="hidden-sm-up"></span> <span class="hidden-xs-down">Business To Business</span></a> </li>
              <li class="nav-item"> <a class="nav-link" data-toggle="tab" href="#b2c" role="tab"><span class="hidden-sm-up"></span> <span class="hidden-xs-down">Business To Customer</span></a> </li>
             
            </ul>
            <!-- Tab panes -->
            <div class="tab-content">
              <div class="tab-pane active p-20" id="b2b" role="tabpanel">
                <div class="pad-20">
                <div class="card-body">
                 <div class="row">
       
        
             <div class="col-md-12 exportbtn">
          
          <button type="button" id="btn_excel" title="Export to Excel" runat="server" class="btn btnsqr btn-primary3 btngap" onserverclick="excel_export"> <i class="fa fa-file-excel-o"></i> Excel</button>
           
        <button type="button" id="btn_print" title="Print" onclick="printdiv('drophere');" class="btn btnsqr btn-primary btngap"> <i class="fa fa-print"></i> Print</button>
       
      </div>
      </div>
              <div id="drophere" class="form-horizontal form-bordered">
               <asp:GridView ID="Grid_b2b" class="table table-striped" runat="server" CellPadding="3" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px">
                   <FooterStyle BackColor="White" ForeColor="#000066" />
                   <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" />
                   <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
                   <RowStyle ForeColor="#000066" />
                   <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                   <SortedAscendingCellStyle BackColor="#F1F1F1" />
                   <SortedAscendingHeaderStyle BackColor="#007DBB" />
                   <SortedDescendingCellStyle BackColor="#CAC9C9" />
                   <SortedDescendingHeaderStyle BackColor="#00547E" />
                  </asp:GridView>


              </div>
            </div>  

                </div>
              </div>



              <div class="tab-pane p-20" id="b2c" role="tabpanel">
                <div class="pad-20">
                <div class="card-body">
                     <div class="row">
       
        
             <div class="col-md-12 exportbtn">
          
          <button type="button" id="btn_excel2" title="Export to Excel" runat="server" class="btn btnsqr btn-primary3 btngap" onserverclick="excel_export2"> <i class="fa fa-file-excel-o"></i> Excel</button>
           
        <button type="button" id="btn_print2" title="Print" onclick="printdiv2('drophere2');" class="btn btnsqr btn-primary btngap"> <i class="fa fa-print"></i> Print</button>
      
      </div>
      </div>
              <div id="drophere2" class="form-horizontal form-bordered">
                <asp:GridView ID="Grid_b2c" class="table table-striped" runat="server" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3">
                     <FooterStyle BackColor="White" ForeColor="#000066" />
                   <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" />
                   <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
                   <RowStyle ForeColor="#000066" />
                   <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                   <SortedAscendingCellStyle BackColor="#F1F1F1" />
                   <SortedAscendingHeaderStyle BackColor="#007DBB" />
                   <SortedDescendingCellStyle BackColor="#CAC9C9" />
                   <SortedDescendingHeaderStyle BackColor="#00547E" />
                </asp:GridView>



              </div>
            </div>  

                </div>
              </div>
              

           

            </div>



              </div>
            </div>  

                </div>
              </div>



              <div class="tab-pane p-20" id="feb" role="tabpanel">
                <div class="pad-20">
                <div class="card-body">
              <div class="form-horizontal form-bordered">
                

                       <!-- Nav tabs -->
            <ul class="nav nav-tabs customtab" role="tablist">
              <li class="nav-item"> <a class="nav-link active" data-toggle="tab" href="#b2b2" role="tab"><span class="hidden-sm-up"></span> <span class="hidden-xs-down">Business To Business</span></a> </li>
              <li class="nav-item"> <a class="nav-link" data-toggle="tab" href="#b2c2" role="tab"><span class="hidden-sm-up"></span> <span class="hidden-xs-down">Business To Customer</span></a> </li>
             
            </ul>
            <!-- Tab panes -->
            <div class="tab-content">
              <div class="tab-pane active p-20" id="b2b2" role="tabpanel">
                <div class="pad-20">
                <div class="card-body">
                 <div class="row">
       
        
             <div class="col-md-12 exportbtn">
          
          <button type="button" id="Button1" title="Export to Excel" runat="server" class="btn btnsqr btn-primary3 btngap" onserverclick="excel_export3"> <i class="fa fa-file-excel-o"></i> Excel</button>
           
        <button type="button" id="btn_print3" title="Print" onclick="printdiv3('drophere3');" class="btn btnsqr btn-primary btngap"> <i class="fa fa-print"></i> Print</button>
      
      </div>
      </div>
              <div id="drophere3" class="form-horizontal form-bordered">
               <asp:GridView ID="Grid_b2b2" class="table table-striped" runat="server" CellPadding="3" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px">
                   <FooterStyle BackColor="White" ForeColor="#000066" />
                   <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" />
                   <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
                   <RowStyle ForeColor="#000066" />
                   <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                   <SortedAscendingCellStyle BackColor="#F1F1F1" />
                   <SortedAscendingHeaderStyle BackColor="#007DBB" />
                   <SortedDescendingCellStyle BackColor="#CAC9C9" />
                   <SortedDescendingHeaderStyle BackColor="#00547E" />
                  </asp:GridView>


              </div>
            </div>  

                </div>
              </div>



              <div class="tab-pane p-20" id="b2c2" role="tabpanel">
                <div class="pad-20">
                <div class="card-body">
                     <div class="row">
       
        
             <div class="col-md-12 exportbtn">
          
          <button type="button" id="Button3" title="Export to Excel" runat="server" class="btn btnsqr btn-primary3 btngap" onserverclick="excel_export4"> <i class="fa fa-file-excel-o"></i> Excel</button>
           
        <button type="button" id="btn_print4" title="Print" onclick="printdiv4('drophere4');" class="btn btnsqr btn-primary btngap"> <i class="fa fa-print"></i> Print</button>
      
      </div>
      </div>
              <div id="drophere4" class="form-horizontal form-bordered">
                <asp:GridView ID="Grid_b2c2" class="table table-striped" runat="server" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3">
                     <FooterStyle BackColor="White" ForeColor="#000066" />
                   <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" />
                   <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
                   <RowStyle ForeColor="#000066" />
                   <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                   <SortedAscendingCellStyle BackColor="#F1F1F1" />
                   <SortedAscendingHeaderStyle BackColor="#007DBB" />
                   <SortedDescendingCellStyle BackColor="#CAC9C9" />
                   <SortedDescendingHeaderStyle BackColor="#00547E" />
                </asp:GridView>



              </div>
            </div>  

                </div>
              </div>
              

           

            </div>



              </div>
            </div>  

                </div>
              </div>
              

           <div class="tab-pane p-20" id="march" role="tabpanel">
                <div class="pad-20">
                <div class="card-body">
              <div class="form-horizontal form-bordered">
             
                       <!-- Nav tabs -->
            <ul class="nav nav-tabs customtab" role="tablist">
              <li class="nav-item"> <a class="nav-link active" data-toggle="tab" href="#b2b3" role="tab"><span class="hidden-sm-up"></span> <span class="hidden-xs-down">Business To Business</span></a> </li>
              <li class="nav-item"> <a class="nav-link" data-toggle="tab" href="#b2c3" role="tab"><span class="hidden-sm-up"></span> <span class="hidden-xs-down">Business To Customer</span></a> </li>
             
            </ul>
            <!-- Tab panes -->
            <div class="tab-content">
              <div class="tab-pane active p-20" id="b2b3" role="tabpanel">
                <div class="pad-20">
                <div class="card-body">
                 <div class="row">
       
        
             <div class="col-md-12 exportbtn">
          
          <button type="button" id="Button5" title="Export to Excel" runat="server" class="btn btnsqr btn-primary3 btngap" onserverclick="excel_export5"> <i class="fa fa-file-excel-o"></i> Excel</button>
           
        <button type="button" id="btn_print5" title="Print" onclick="printdiv5('drophere5');" class="btn btnsqr btn-primary btngap"> <i class="fa fa-print"></i> Print</button>
        
      </div>
      </div>
              <div id="drophere5" class="form-horizontal form-bordered">
               <asp:GridView ID="Grid_b2b3" class="table table-striped" runat="server" CellPadding="3" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px">
                   <FooterStyle BackColor="White" ForeColor="#000066" />
                   <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" />
                   <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
                   <RowStyle ForeColor="#000066" />
                   <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                   <SortedAscendingCellStyle BackColor="#F1F1F1" />
                   <SortedAscendingHeaderStyle BackColor="#007DBB" />
                   <SortedDescendingCellStyle BackColor="#CAC9C9" />
                   <SortedDescendingHeaderStyle BackColor="#00547E" />
                  </asp:GridView>


              </div>
            </div>  

                </div>
              </div>



              <div class="tab-pane p-20" id="b2c3" role="tabpanel">
                <div class="pad-20">
                <div class="card-body">
                     <div class="row">
       
        
             <div class="col-md-12 exportbtn">
          
          <button type="button" id="Button7" title="Export to Excel" runat="server" class="btn btnsqr btn-primary3 btngap" onserverclick="excel_export6"> <i class="fa fa-file-excel-o"></i> Excel</button>
           
        <button type="button" id="btn_print6" title="Print" onclick="printdiv6('drophere6');" class="btn btnsqr btn-primary btngap"> <i class="fa fa-print"></i> Print</button>
     
      </div>
      </div>
              <div id="drophere6" class="form-horizontal form-bordered">
                <asp:GridView ID="Grid_b2c3" class="table table-striped" runat="server" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3">
                     <FooterStyle BackColor="White" ForeColor="#000066" />
                   <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" />
                   <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
                   <RowStyle ForeColor="#000066" />
                   <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                   <SortedAscendingCellStyle BackColor="#F1F1F1" />
                   <SortedAscendingHeaderStyle BackColor="#007DBB" />
                   <SortedDescendingCellStyle BackColor="#CAC9C9" />
                   <SortedDescendingHeaderStyle BackColor="#00547E" />
                </asp:GridView>



              </div>
            </div>  

                </div>
              </div>
              

           

            </div>



              </div>
            </div>  

              
                </div>
              </div>


              <div class="tab-pane p-20" id="april" role="tabpanel">
                <div class="pad-20">
                <div class="card-body">
              <div class="form-horizontal form-bordered">
                   <!-- Nav tabs -->
            <ul class="nav nav-tabs customtab" role="tablist">
              <li class="nav-item"> <a class="nav-link active" data-toggle="tab" href="#b2b4" role="tab"><span class="hidden-sm-up"></span> <span class="hidden-xs-down">Business To Business</span></a> </li>
              <li class="nav-item"> <a class="nav-link" data-toggle="tab" href="#b2c4" role="tab"><span class="hidden-sm-up"></span> <span class="hidden-xs-down">Business To Customer</span></a> </li>
             
            </ul>
            <!-- Tab panes -->
            <div class="tab-content">
              <div class="tab-pane active p-20" id="b2b4" role="tabpanel">
                <div class="pad-20">
                <div class="card-body">
                 <div class="row">
       
        
             <div class="col-md-12 exportbtn">
          
          <button type="button" id="Button9" title="Export to Excel" runat="server" class="btn btnsqr btn-primary3 btngap" onserverclick="excel_export7"> <i class="fa fa-file-excel-o"></i> Excel</button>
           
        <button type="button" id="btn_print7" title="Print" onclick="printdiv7('drophere7');" class="btn btnsqr btn-primary btngap"> <i class="fa fa-print"></i> Print</button>
      
      </div>
      </div>
              <div id="drophere7" class="form-horizontal form-bordered">
               <asp:GridView ID="Grid_b2b4" class="table table-striped" runat="server" CellPadding="3" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px">
                   <FooterStyle BackColor="White" ForeColor="#000066" />
                   <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" />
                   <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
                   <RowStyle ForeColor="#000066" />
                   <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                   <SortedAscendingCellStyle BackColor="#F1F1F1" />
                   <SortedAscendingHeaderStyle BackColor="#007DBB" />
                   <SortedDescendingCellStyle BackColor="#CAC9C9" />
                   <SortedDescendingHeaderStyle BackColor="#00547E" />
                  </asp:GridView>


              </div>
            </div>  

                </div>
              </div>



              <div class="tab-pane p-20" id="b2c4" role="tabpanel">
                <div class="pad-20">
                <div class="card-body">
                     <div class="row">
       
        
             <div class="col-md-12 exportbtn">
          
          <button type="button" id="Button11" title="Export to Excel" runat="server" class="btn btnsqr btn-primary3 btngap" onserverclick="excel_export8"> <i class="fa fa-file-excel-o"></i> Excel</button>
           
        <button type="button" id="btn_print8" title="Print" onclick="printdiv8('drophere8');" class="btn btnsqr btn-primary btngap"> <i class="fa fa-print"></i> Print</button>
         
      </div>
      </div>
              <div id="drophere8" class="form-horizontal form-bordered">
                <asp:GridView ID="Grid_b2c4" class="table table-striped" runat="server" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3">
                     <FooterStyle BackColor="White" ForeColor="#000066" />
                   <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" />
                   <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
                   <RowStyle ForeColor="#000066" />
                   <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                   <SortedAscendingCellStyle BackColor="#F1F1F1" />
                   <SortedAscendingHeaderStyle BackColor="#007DBB" />
                   <SortedDescendingCellStyle BackColor="#CAC9C9" />
                   <SortedDescendingHeaderStyle BackColor="#00547E" />
                </asp:GridView>



              </div>
            </div>  

                </div>
              </div>
              

           

            </div>

              </div>
            </div>  

              
                </div>
              </div>


                  <div class="tab-pane p-20" id="may" role="tabpanel">
                <div class="pad-20">
                <div class="card-body">
              <div class="form-horizontal form-bordered">
             

                       <!-- Nav tabs -->
            <ul class="nav nav-tabs customtab" role="tablist">
              <li class="nav-item"> <a class="nav-link active" data-toggle="tab" href="#b2b5" role="tab"><span class="hidden-sm-up"></span> <span class="hidden-xs-down">Business To Business</span></a> </li>
              <li class="nav-item"> <a class="nav-link" data-toggle="tab" href="#b2c5" role="tab"><span class="hidden-sm-up"></span> <span class="hidden-xs-down">Business To Customer</span></a> </li>
             
            </ul>
            <!-- Tab panes -->
            <div class="tab-content">
              <div class="tab-pane active p-20" id="b2b5" role="tabpanel">
                <div class="pad-20">
                <div class="card-body">
                 <div class="row">
       
        
             <div class="col-md-12 exportbtn">
          
          <button type="button" id="Button13" title="Export to Excel" runat="server" class="btn btnsqr btn-primary3 btngap" onserverclick="excel_export9"> <i class="fa fa-file-excel-o"></i> Excel</button>
           
        <button type="button" id="btn_print9" title="Print" onclick="printdiv9('drophere9');" class="btn btnsqr btn-primary btngap"> <i class="fa fa-print"></i> Print</button>
        
      </div>
      </div>
              <div id="drophere9" class="form-horizontal form-bordered">
               <asp:GridView ID="Grid_b2b5" class="table table-striped" runat="server" CellPadding="3" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px">
                   <FooterStyle BackColor="White" ForeColor="#000066" />
                   <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" />
                   <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
                   <RowStyle ForeColor="#000066" />
                   <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                   <SortedAscendingCellStyle BackColor="#F1F1F1" />
                   <SortedAscendingHeaderStyle BackColor="#007DBB" />
                   <SortedDescendingCellStyle BackColor="#CAC9C9" />
                   <SortedDescendingHeaderStyle BackColor="#00547E" />
                  </asp:GridView>


              </div>
            </div>  

                </div>
              </div>



              <div class="tab-pane p-20" id="b2c5" role="tabpanel">
                <div class="pad-20">
                <div class="card-body">
                     <div class="row">
       
        
             <div class="col-md-12 exportbtn">
          
          <button type="button" id="Button15" title="Export to Excel" runat="server" class="btn btnsqr btn-primary3 btngap" onserverclick="excel_export10"> <i class="fa fa-file-excel-o"></i> Excel</button>
           
        <button type="button" id="btn_print10" title="Print" onclick="printdiv10('drophere10');" class="btn btnsqr btn-primary btngap"> <i class="fa fa-print"></i> Print</button>
        
      </div>
      </div>
              <div id="drophere10" class="form-horizontal form-bordered">
                <asp:GridView ID="Grid_b2c5" class="table table-striped" runat="server" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3">
                     <FooterStyle BackColor="White" ForeColor="#000066" />
                   <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" />
                   <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
                   <RowStyle ForeColor="#000066" />
                   <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                   <SortedAscendingCellStyle BackColor="#F1F1F1" />
                   <SortedAscendingHeaderStyle BackColor="#007DBB" />
                   <SortedDescendingCellStyle BackColor="#CAC9C9" />
                   <SortedDescendingHeaderStyle BackColor="#00547E" />
                </asp:GridView>



              </div>
            </div>  

                </div>
              </div>
              

           

            </div>



              </div>
            </div>  

              
                </div>
              </div>


                  <div class="tab-pane p-20" id="june" role="tabpanel">
                <div class="pad-20">
                <div class="card-body">
              <div class="form-horizontal form-bordered">
             

                       <!-- Nav tabs -->
            <ul class="nav nav-tabs customtab" role="tablist">
              <li class="nav-item"> <a class="nav-link active" data-toggle="tab" href="#b2b6" role="tab"><span class="hidden-sm-up"></span> <span class="hidden-xs-down">Business To Business</span></a> </li>
              <li class="nav-item"> <a class="nav-link" data-toggle="tab" href="#b2c6" role="tab"><span class="hidden-sm-up"></span> <span class="hidden-xs-down">Business To Customer</span></a> </li>
             
            </ul>
            <!-- Tab panes -->
            <div class="tab-content">
              <div class="tab-pane active p-20" id="b2b6" role="tabpanel">
                <div class="pad-20">
                <div class="card-body">
                 <div class="row">
       
        
             <div class="col-md-12 exportbtn">
          
          <button type="button" id="Button17" title="Export to Excel" runat="server" class="btn btnsqr btn-primary3 btngap" onserverclick="excel_export11"> <i class="fa fa-file-excel-o"></i> Excel</button>
           
        <button type="button" id="btn_print11" title="Print" onclick="printdiv11('drophere11');" class="btn btnsqr btn-primary btngap"> <i class="fa fa-print"></i> Print</button>
       
      </div>
      </div>
              <div id="drophere11" class="form-horizontal form-bordered">
               <asp:GridView ID="Grid_b2b6" class="table table-striped" runat="server" CellPadding="3" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px">
                   <FooterStyle BackColor="White" ForeColor="#000066" />
                   <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" />
                   <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
                   <RowStyle ForeColor="#000066" />
                   <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                   <SortedAscendingCellStyle BackColor="#F1F1F1" />
                   <SortedAscendingHeaderStyle BackColor="#007DBB" />
                   <SortedDescendingCellStyle BackColor="#CAC9C9" />
                   <SortedDescendingHeaderStyle BackColor="#00547E" />
                  </asp:GridView>


              </div>
            </div>  

                </div>
              </div>



              <div class="tab-pane p-20" id="b2c6" role="tabpanel">
                <div class="pad-20">
                <div class="card-body">
                     <div class="row">
       
        
             <div class="col-md-12 exportbtn">
          
          <button type="button" id="Button19" title="Export to Excel" runat="server" class="btn btnsqr btn-primary3 btngap" onserverclick="excel_export12"> <i class="fa fa-file-excel-o"></i> Excel</button>
           
        <button type="button" id="btn_print12" title="Print" onclick="printdiv12('drophere12');" class="btn btnsqr btn-primary btngap"> <i class="fa fa-print"></i> Print</button>
     
      </div>
      </div>
              <div id="drophere12" class="form-horizontal form-bordered">
                <asp:GridView ID="Grid_b2c6" class="table table-striped" runat="server" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3">
                     <FooterStyle BackColor="White" ForeColor="#000066" />
                   <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" />
                   <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
                   <RowStyle ForeColor="#000066" />
                   <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                   <SortedAscendingCellStyle BackColor="#F1F1F1" />
                   <SortedAscendingHeaderStyle BackColor="#007DBB" />
                   <SortedDescendingCellStyle BackColor="#CAC9C9" />
                   <SortedDescendingHeaderStyle BackColor="#00547E" />
                </asp:GridView>



              </div>
            </div>  

                </div>
              </div>
              

           

            </div>



              </div>
            </div>  

              
                </div>
              </div>



                  <div class="tab-pane p-20" id="july" role="tabpanel">
                <div class="pad-20">
                <div class="card-body">
              <div class="form-horizontal form-bordered">
                

                       <!-- Nav tabs -->
            <ul class="nav nav-tabs customtab" role="tablist">
              <li class="nav-item"> <a class="nav-link active" data-toggle="tab" href="#b2b7" role="tab"><span class="hidden-sm-up"></span> <span class="hidden-xs-down">Business To Business</span></a> </li>
              <li class="nav-item"> <a class="nav-link" data-toggle="tab" href="#b2c7" role="tab"><span class="hidden-sm-up"></span> <span class="hidden-xs-down">Business To Customer</span></a> </li>
             
            </ul>
            <!-- Tab panes -->
            <div class="tab-content">
              <div class="tab-pane active p-20" id="b2b7" role="tabpanel">
                <div class="pad-20">
                <div class="card-body">
                 <div class="row">
       
        
             <div class="col-md-12 exportbtn">
          
          <button type="button" id="Button21" title="Export to Excel" runat="server" class="btn btnsqr btn-primary3 btngap" onserverclick="excel_export13"> <i class="fa fa-file-excel-o"></i> Excel</button>
           
        <button type="button" id="btn_print13" title="Print" onclick="printdiv13('drophere13');" class="btn btnsqr btn-primary btngap"> <i class="fa fa-print"></i> Print</button>
       
      </div>
      </div>
              <div id="drophere13" class="form-horizontal form-bordered">
               <asp:GridView ID="Grid_b2b7" class="table table-striped" runat="server" CellPadding="3" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px">
                   <FooterStyle BackColor="White" ForeColor="#000066" />
                   <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" />
                   <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
                   <RowStyle ForeColor="#000066" />
                   <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                   <SortedAscendingCellStyle BackColor="#F1F1F1" />
                   <SortedAscendingHeaderStyle BackColor="#007DBB" />
                   <SortedDescendingCellStyle BackColor="#CAC9C9" />
                   <SortedDescendingHeaderStyle BackColor="#00547E" />
                  </asp:GridView>


              </div>
            </div>  

                </div>
              </div>



              <div class="tab-pane p-20" id="b2c7" role="tabpanel">
                <div class="pad-20">
                <div class="card-body">
                     <div class="row">
       
        
             <div class="col-md-12 exportbtn">
          
          <button type="button" id="Button23" title="Export to Excel" runat="server" class="btn btnsqr btn-primary3 btngap" onserverclick="excel_export14"> <i class="fa fa-file-excel-o"></i> Excel</button>
           
        <button type="button" id="btn_print14" title="Print" onclick="printdiv14('drophere14');" class="btn btnsqr btn-primary btngap"> <i class="fa fa-print"></i> Print</button>
 
      </div>
      </div>
              <div id="drophere14" class="form-horizontal form-bordered">
                <asp:GridView ID="Grid_b2c7" class="table table-striped" runat="server" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3">
                     <FooterStyle BackColor="White" ForeColor="#000066" />
                   <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" />
                   <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
                   <RowStyle ForeColor="#000066" />
                   <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                   <SortedAscendingCellStyle BackColor="#F1F1F1" />
                   <SortedAscendingHeaderStyle BackColor="#007DBB" />
                   <SortedDescendingCellStyle BackColor="#CAC9C9" />
                   <SortedDescendingHeaderStyle BackColor="#00547E" />
                </asp:GridView>



              </div>
            </div>  

                </div>
              </div>
              

           

            </div>



              </div>
            </div>  

              
                </div>
              </div>



                  <div class="tab-pane p-20" id="aug" role="tabpanel">
                <div class="pad-20">
                <div class="card-body">
              <div class="form-horizontal form-bordered">
              

                       <!-- Nav tabs -->
            <ul class="nav nav-tabs customtab" role="tablist">
              <li class="nav-item"> <a class="nav-link active" data-toggle="tab" href="#b2b8" role="tab"><span class="hidden-sm-up"></span> <span class="hidden-xs-down">Business To Business</span></a> </li>
              <li class="nav-item"> <a class="nav-link" data-toggle="tab" href="#b2c8" role="tab"><span class="hidden-sm-up"></span> <span class="hidden-xs-down">Business To Customer</span></a> </li>
             
            </ul>
            <!-- Tab panes -->
            <div class="tab-content">
              <div class="tab-pane active p-20" id="b2b8" role="tabpanel">
                <div class="pad-20">
                <div class="card-body">
                 <div class="row">
       
        
             <div class="col-md-12 exportbtn">
          
          <button type="button" id="Button25" title="Export to Excel" runat="server" class="btn btnsqr btn-primary3 btngap" onserverclick="excel_export15"> <i class="fa fa-file-excel-o"></i> Excel</button>
           
        <button type="button" id="btn_print15" title="Print" onclick="printdiv15('drophere15');" class="btn btnsqr btn-primary btngap"> <i class="fa fa-print"></i> Print</button>
     
      </div>
      </div>
              <div id="drophere15" class="form-horizontal form-bordered">
               <asp:GridView ID="Grid_b2b8" class="table table-striped" runat="server" CellPadding="3" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px">
                   <FooterStyle BackColor="White" ForeColor="#000066" />
                   <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" />
                   <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
                   <RowStyle ForeColor="#000066" />
                   <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                   <SortedAscendingCellStyle BackColor="#F1F1F1" />
                   <SortedAscendingHeaderStyle BackColor="#007DBB" />
                   <SortedDescendingCellStyle BackColor="#CAC9C9" />
                   <SortedDescendingHeaderStyle BackColor="#00547E" />
                  </asp:GridView>


              </div>
            </div>  

                </div>
              </div>



              <div class="tab-pane p-20" id="b2c8" role="tabpanel">
                <div class="pad-20">
                <div class="card-body">
                     <div class="row">
       
        
             <div class="col-md-12 exportbtn">
          
          <button type="button" id="Button27" title="Export to Excel" runat="server" class="btn btnsqr btn-primary3 btngap" onserverclick="excel_export16"> <i class="fa fa-file-excel-o"></i> Excel</button>
           
        <button type="button" id="btn_print16" title="Print" onclick="printdiv16('drophere16');" class="btn btnsqr btn-primary btngap"> <i class="fa fa-print"></i> Print</button>
    
      </div>
      </div>
              <div id="drophere16" class="form-horizontal form-bordered">
                <asp:GridView ID="Grid_b2c8" class="table table-striped" runat="server" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3">
                     <FooterStyle BackColor="White" ForeColor="#000066" />
                   <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" />
                   <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
                   <RowStyle ForeColor="#000066" />
                   <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                   <SortedAscendingCellStyle BackColor="#F1F1F1" />
                   <SortedAscendingHeaderStyle BackColor="#007DBB" />
                   <SortedDescendingCellStyle BackColor="#CAC9C9" />
                   <SortedDescendingHeaderStyle BackColor="#00547E" />
                </asp:GridView>



              </div>
            </div>  

                </div>
              </div>
              

           

            </div>



              </div>
            </div>  

              
                </div>
              </div>



                  <div class="tab-pane p-20" id="sep" role="tabpanel">
                <div class="pad-20">
                <div class="card-body">
              <div class="form-horizontal form-bordered">
             

                       <!-- Nav tabs -->
            <ul class="nav nav-tabs customtab" role="tablist">
              <li class="nav-item"> <a class="nav-link active" data-toggle="tab" href="#b2b9" role="tab"><span class="hidden-sm-up"></span> <span class="hidden-xs-down">Business To Business</span></a> </li>
              <li class="nav-item"> <a class="nav-link" data-toggle="tab" href="#b2c9" role="tab"><span class="hidden-sm-up"></span> <span class="hidden-xs-down">Business To Customer</span></a> </li>
             
            </ul>
            <!-- Tab panes -->
            <div class="tab-content">
              <div class="tab-pane active p-20" id="b2b9" role="tabpanel">
                <div class="pad-20">
                <div class="card-body">
                 <div class="row">
       
        
             <div class="col-md-12 exportbtn">
          
          <button type="button" id="Button29" title="Export to Excel" runat="server" class="btn btnsqr btn-primary3 btngap" onserverclick="excel_export17"> <i class="fa fa-file-excel-o"></i> Excel</button>
           
        <button type="button" id="btn_print17" title="Print" onclick="printdiv17('drophere17');" class="btn btnsqr btn-primary btngap"> <i class="fa fa-print"></i> Print</button>
      
      </div>
      </div>
              <div id="drophere17" class="form-horizontal form-bordered">
               <asp:GridView ID="Grid_b2b9" class="table table-striped" runat="server" CellPadding="3" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px">
                   <FooterStyle BackColor="White" ForeColor="#000066" />
                   <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" />
                   <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
                   <RowStyle ForeColor="#000066" />
                   <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                   <SortedAscendingCellStyle BackColor="#F1F1F1" />
                   <SortedAscendingHeaderStyle BackColor="#007DBB" />
                   <SortedDescendingCellStyle BackColor="#CAC9C9" />
                   <SortedDescendingHeaderStyle BackColor="#00547E" />
                  </asp:GridView>


              </div>
            </div>  

                </div>
              </div>



              <div class="tab-pane p-20" id="b2c9" role="tabpanel">
                <div class="pad-20">
                <div class="card-body">
                     <div class="row">
       
        
             <div class="col-md-12 exportbtn">
          
          <button type="button" id="Button31" title="Export to Excel" runat="server" class="btn btnsqr btn-primary3 btngap" onserverclick="excel_export18"> <i class="fa fa-file-excel-o"></i> Excel</button>
           
        <button type="button" id="btn_print18" title="Print" onclick="printdiv18('drophere18');" class="btn btnsqr btn-primary btngap"> <i class="fa fa-print"></i> Print</button>
        
      </div>
      </div>
              <div id="drophere18" class="form-horizontal form-bordered">
                <asp:GridView ID="Grid_b2c9" class="table table-striped" runat="server" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3">
                     <FooterStyle BackColor="White" ForeColor="#000066" />
                   <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" />
                   <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
                   <RowStyle ForeColor="#000066" />
                   <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                   <SortedAscendingCellStyle BackColor="#F1F1F1" />
                   <SortedAscendingHeaderStyle BackColor="#007DBB" />
                   <SortedDescendingCellStyle BackColor="#CAC9C9" />
                   <SortedDescendingHeaderStyle BackColor="#00547E" />
                </asp:GridView>



              </div>
            </div>  

                </div>
              </div>
              

           

            </div>



              </div>
            </div>  

              
                </div>
              </div>



                  <div class="tab-pane p-20" id="oct" role="tabpanel">
                <div class="pad-20">
                <div class="card-body">
              <div class="form-horizontal form-bordered">
               

                       <!-- Nav tabs -->
            <ul class="nav nav-tabs customtab" role="tablist">
              <li class="nav-item"> <a class="nav-link active" data-toggle="tab" href="#b2b10" role="tab"><span class="hidden-sm-up"></span> <span class="hidden-xs-down">Business To Business</span></a> </li>
              <li class="nav-item"> <a class="nav-link" data-toggle="tab" href="#b2c10" role="tab"><span class="hidden-sm-up"></span> <span class="hidden-xs-down">Business To Customer</span></a> </li>
             
            </ul>
            <!-- Tab panes -->
            <div class="tab-content">
              <div class="tab-pane active p-20" id="b2b10" role="tabpanel">
                <div class="pad-20">
                <div class="card-body">
                 <div class="row">
       
        
             <div class="col-md-12 exportbtn">
          
          <button type="button" id="Button33" title="Export to Excel" runat="server" class="btn btnsqr btn-primary3 btngap" onserverclick="excel_export19"> <i class="fa fa-file-excel-o"></i> Excel</button>
           
        <button type="button" id="btn_print19" title="Print" onclick="printdiv19('drophere19');" class="btn btnsqr btn-primary btngap"> <i class="fa fa-print"></i> Print</button>
        
      </div>
      </div>
              <div id="drophere19" class="form-horizontal form-bordered">
               <asp:GridView ID="Grid_b2b10" class="table table-striped" runat="server" CellPadding="3" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px">
                   <FooterStyle BackColor="White" ForeColor="#000066" />
                   <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" />
                   <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
                   <RowStyle ForeColor="#000066" />
                   <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                   <SortedAscendingCellStyle BackColor="#F1F1F1" />
                   <SortedAscendingHeaderStyle BackColor="#007DBB" />
                   <SortedDescendingCellStyle BackColor="#CAC9C9" />
                   <SortedDescendingHeaderStyle BackColor="#00547E" />
                  </asp:GridView>


              </div>
            </div>  

                </div>
              </div>



              <div class="tab-pane p-20" id="b2c10" role="tabpanel">
                <div class="pad-20">
                <div class="card-body">
                     <div class="row">
       
        
             <div class="col-md-12 exportbtn">
          
          <button type="button" id="Button35" title="Export to Excel" runat="server" class="btn btnsqr btn-primary3 btngap" onserverclick="excel_export20"> <i class="fa fa-file-excel-o"></i> Excel</button>
           
        <button type="button" id="btn_print20" title="Print" onclick="printdiv20('drophere20');" class="btn btnsqr btn-primary btngap"> <i class="fa fa-print"></i> Print</button>
        
      </div>
      </div>
              <div id="drophere20" class="form-horizontal form-bordered">
                <asp:GridView ID="Grid_b2c10" class="table table-striped" runat="server" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3">
                     <FooterStyle BackColor="White" ForeColor="#000066" />
                   <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" />
                   <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
                   <RowStyle ForeColor="#000066" />
                   <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                   <SortedAscendingCellStyle BackColor="#F1F1F1" />
                   <SortedAscendingHeaderStyle BackColor="#007DBB" />
                   <SortedDescendingCellStyle BackColor="#CAC9C9" />
                   <SortedDescendingHeaderStyle BackColor="#00547E" />
                </asp:GridView>



              </div>
            </div>  

                </div>
              </div>
              

           

            </div>




              </div>
            </div>  

              
                </div>
              </div>


                  <div class="tab-pane p-20" id="nov" role="tabpanel">
                <div class="pad-20">
                <div class="card-body">
              <div class="form-horizontal form-bordered">
              

                       <!-- Nav tabs -->
            <ul class="nav nav-tabs customtab" role="tablist">
              <li class="nav-item"> <a class="nav-link active" data-toggle="tab" href="#b2b11" role="tab"><span class="hidden-sm-up"></span> <span class="hidden-xs-down">Business To Business</span></a> </li>
              <li class="nav-item"> <a class="nav-link" data-toggle="tab" href="#b2c11" role="tab"><span class="hidden-sm-up"></span> <span class="hidden-xs-down">Business To Customer</span></a> </li>
             
            </ul>
            <!-- Tab panes -->
            <div class="tab-content">
              <div class="tab-pane active p-20" id="b2b11" role="tabpanel">
                <div class="pad-20">
                <div class="card-body">
                 <div class="row">
       
        
             <div class="col-md-12 exportbtn">
          
          <button type="button" id="Button37" title="Export to Excel" runat="server" class="btn btnsqr btn-primary3 btngap" onserverclick="excel_export21"> <i class="fa fa-file-excel-o"></i> Excel</button>
           
        <button type="button" id="btn_print21" title="Print" onclick="printdiv21('drophere21');" class="btn btnsqr btn-primary btngap"> <i class="fa fa-print"></i> Print</button>
       
      </div>
      </div>
              <div id="drophere21" class="form-horizontal form-bordered">
               <asp:GridView ID="Grid_b2b11" class="table table-striped" runat="server" CellPadding="3" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px">
                   <FooterStyle BackColor="White" ForeColor="#000066" />
                   <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" />
                   <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
                   <RowStyle ForeColor="#000066" />
                   <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                   <SortedAscendingCellStyle BackColor="#F1F1F1" />
                   <SortedAscendingHeaderStyle BackColor="#007DBB" />
                   <SortedDescendingCellStyle BackColor="#CAC9C9" />
                   <SortedDescendingHeaderStyle BackColor="#00547E" />
                  </asp:GridView>


              </div>
            </div>  

                </div>
              </div>



              <div class="tab-pane p-20" id="b2c11" role="tabpanel">
                <div class="pad-20">
                <div class="card-body">
                     <div class="row">
       
        
             <div class="col-md-12 exportbtn">
          
          <button type="button" id="Button39" title="Export to Excel" runat="server" class="btn btnsqr btn-primary3 btngap" onserverclick="excel_export22"> <i class="fa fa-file-excel-o"></i> Excel</button>
           
        <button type="button" id="btn_print22" title="Print" onclick="printdiv22('drophere22');" class="btn btnsqr btn-primary btngap"> <i class="fa fa-print"></i> Print</button>
    
      </div>
      </div>
              <div id="drophere22" class="form-horizontal form-bordered">
                <asp:GridView ID="Grid_b2c11" class="table table-striped" runat="server" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3">
                     <FooterStyle BackColor="White" ForeColor="#000066" />
                   <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" />
                   <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
                   <RowStyle ForeColor="#000066" />
                   <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                   <SortedAscendingCellStyle BackColor="#F1F1F1" />
                   <SortedAscendingHeaderStyle BackColor="#007DBB" />
                   <SortedDescendingCellStyle BackColor="#CAC9C9" />
                   <SortedDescendingHeaderStyle BackColor="#00547E" />
                </asp:GridView>



              </div>
            </div>  

                </div>
              </div>
              

           

            </div>




              </div>
            </div>  

              
                </div>
              </div>


                  <div class="tab-pane p-20" id="dec" role="tabpanel">
                <div class="pad-20">
                <div class="card-body">
              <div class="form-horizontal form-bordered">
               

                       <!-- Nav tabs -->
            <ul class="nav nav-tabs customtab" role="tablist">
              <li class="nav-item"> <a class="nav-link active" data-toggle="tab" href="#b2b12" role="tab"><span class="hidden-sm-up"></span> <span class="hidden-xs-down">Business To Business</span></a> </li>
              <li class="nav-item"> <a class="nav-link" data-toggle="tab" href="#b2c12" role="tab"><span class="hidden-sm-up"></span> <span class="hidden-xs-down">Business To Customer</span></a> </li>
             
            </ul>
            <!-- Tab panes -->
            <div class="tab-content">
              <div class="tab-pane active p-20" id="b2b12" role="tabpanel">
                <div class="pad-20">
                <div class="card-body">
                 <div class="row">
       
        
             <div class="col-md-12 exportbtn">
          
          <button type="button" id="Button41" title="Export to Excel" runat="server" class="btn btnsqr btn-primary3 btngap" onserverclick="excel_export23"> <i class="fa fa-file-excel-o"></i> Excel</button>
           
        <button type="button" id="btn_print23" title="Print" onclick="printdiv23('drophere23');" class="btn btnsqr btn-primary btngap"> <i class="fa fa-print"></i> Print</button>
     
      </div>
      </div>
              <div id="drophere23" class="form-horizontal form-bordered">
               <asp:GridView ID="Grid_b2b12" class="table table-striped" runat="server" CellPadding="3" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px">
                   <FooterStyle BackColor="White" ForeColor="#000066" />
                   <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" />
                   <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
                   <RowStyle ForeColor="#000066" />
                   <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                   <SortedAscendingCellStyle BackColor="#F1F1F1" />
                   <SortedAscendingHeaderStyle BackColor="#007DBB" />
                   <SortedDescendingCellStyle BackColor="#CAC9C9" />
                   <SortedDescendingHeaderStyle BackColor="#00547E" />
                  </asp:GridView>


              </div>
            </div>  

                </div>
              </div>



              <div class="tab-pane p-20" id="b2c12" role="tabpanel">
                <div class="pad-20">
                <div class="card-body">
                     <div class="row">
       
        
             <div class="col-md-12 exportbtn">
          
          <button type="button" id="Button43" title="Export to Excel" runat="server" class="btn btnsqr btn-primary3 btngap" onserverclick="excel_export24"> <i class="fa fa-file-excel-o"></i> Excel</button>
           
        <button type="button" id="btn_print24" title="Print" onclick="printdiv24('drophere24');" class="btn btnsqr btn-primary btngap"> <i class="fa fa-print"></i> Print</button>

      </div>
      </div>
              <div id="drophere24" class="form-horizontal form-bordered">
                <asp:GridView ID="Grid_b2c12" class="table table-striped" runat="server" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3">
                     <FooterStyle BackColor="White" ForeColor="#000066" />
                   <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" />
                   <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
                   <RowStyle ForeColor="#000066" />
                   <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                   <SortedAscendingCellStyle BackColor="#F1F1F1" />
                   <SortedAscendingHeaderStyle BackColor="#007DBB" />
                   <SortedDescendingCellStyle BackColor="#CAC9C9" />
                   <SortedDescendingHeaderStyle BackColor="#00547E" />
                </asp:GridView>



              </div>
            </div>  

                </div>
              </div>
              

           

            </div>




              </div>
            </div>  

              
                </div>
              </div>


            </div>
          </div>
        </div>
      </div>
      <!-- row --> 
      
      
      <!-- Main row --> 
    </section>
    
   </div>
  <!-- /.content-wrapper -->
  <footer class="main-footer">
    <div class="pull-right hidden-xs">Version 1.0</div>
    Copyright © 2018 PrintSoft. All rights reserved.</footer>


  
    
       <script type="text/javascript">

        function printdiv(drophere) {
            var printContents = document.getElementById(drophere).innerHTML;
    var originalContents = document.body.innerHTML;

    document.body.innerHTML = printContents;

    window.print();

    document.body.innerHTML = originalContents;
        }

        function printdiv2(drophere2) {
            var printContents = document.getElementById(drophere2).innerHTML;
            var originalContents = document.body.innerHTML;

            document.body.innerHTML = printContents;

            window.print();

            document.body.innerHTML = originalContents;
        }


        function printdiv3(drophere3) {
            var printContents = document.getElementById(drophere3).innerHTML;
            var originalContents = document.body.innerHTML;

            document.body.innerHTML = printContents;

            window.print();

            document.body.innerHTML = originalContents;
        }

        function printdiv4(drophere4) {
            var printContents = document.getElementById(drophere4).innerHTML;
            var originalContents = document.body.innerHTML;

            document.body.innerHTML = printContents;

            window.print();

            document.body.innerHTML = originalContents;
        }

        function printdiv5(drophere5) {
            var printContents = document.getElementById(drophere5).innerHTML;
            var originalContents = document.body.innerHTML;

            document.body.innerHTML = printContents;

            window.print();

            document.body.innerHTML = originalContents;
        }

        function printdiv6(drophere6) {
            var printContents = document.getElementById(drophere6).innerHTML;
            var originalContents = document.body.innerHTML;

            document.body.innerHTML = printContents;

            window.print();

            document.body.innerHTML = originalContents;
        }

        function printdiv7(drophere7) {
            var printContents = document.getElementById(drophere7).innerHTML;
            var originalContents = document.body.innerHTML;

            document.body.innerHTML = printContents;

            window.print();

            document.body.innerHTML = originalContents;
        }

        function printdiv8(drophere8) {
            var printContents = document.getElementById(drophere8).innerHTML;
            var originalContents = document.body.innerHTML;

            document.body.innerHTML = printContents;

            window.print();

            document.body.innerHTML = originalContents;
        }

        function printdiv9(drophere9) {
            var printContents = document.getElementById(drophere9).innerHTML;
            var originalContents = document.body.innerHTML;

            document.body.innerHTML = printContents;

            window.print();

            document.body.innerHTML = originalContents;
        }

        function printdiv10(drophere10) {
            var printContents = document.getElementById(drophere10).innerHTML;
            var originalContents = document.body.innerHTML;

            document.body.innerHTML = printContents;

            window.print();

            document.body.innerHTML = originalContents;
        }

        function printdiv11(drophere11) {
            var printContents = document.getElementById(drophere11).innerHTML;
            var originalContents = document.body.innerHTML;

            document.body.innerHTML = printContents;

            window.print();

            document.body.innerHTML = originalContents;
        }

        function printdiv12(drophere12) {
            var printContents = document.getElementById(drophere12).innerHTML;
            var originalContents = document.body.innerHTML;

            document.body.innerHTML = printContents;

            window.print();

            document.body.innerHTML = originalContents;
        }

        function printdiv13(drophere13) {
            var printContents = document.getElementById(drophere13).innerHTML;
            var originalContents = document.body.innerHTML;

            document.body.innerHTML = printContents;

            window.print();

            document.body.innerHTML = originalContents;
        }

        function printdiv14(drophere14) {
            var printContents = document.getElementById(drophere14).innerHTML;
            var originalContents = document.body.innerHTML;

            document.body.innerHTML = printContents;

            window.print();

            document.body.innerHTML = originalContents;
        }

        function printdiv15(drophere15) {
            var printContents = document.getElementById(drophere15).innerHTML;
            var originalContents = document.body.innerHTML;

            document.body.innerHTML = printContents;

            window.print();

            document.body.innerHTML = originalContents;
        }

        function printdiv16(drophere16) {
            var printContents = document.getElementById(drophere16).innerHTML;
            var originalContents = document.body.innerHTML;

            document.body.innerHTML = printContents;

            window.print();

            document.body.innerHTML = originalContents;
        }

        function printdiv17(drophere17) {
            var printContents = document.getElementById(drophere17).innerHTML;
            var originalContents = document.body.innerHTML;

            document.body.innerHTML = printContents;

            window.print();

            document.body.innerHTML = originalContents;
        }

        function printdiv18(drophere18) {
            var printContents = document.getElementById(drophere18).innerHTML;
            var originalContents = document.body.innerHTML;

            document.body.innerHTML = printContents;

            window.print();

            document.body.innerHTML = originalContents;
        }

        function printdiv19(drophere19) {
            var printContents = document.getElementById(drophere19).innerHTML;
            var originalContents = document.body.innerHTML;

            document.body.innerHTML = printContents;

            window.print();

            document.body.innerHTML = originalContents;
        }

        function printdiv20(drophere20) {
            var printContents = document.getElementById(drophere20).innerHTML;
            var originalContents = document.body.innerHTML;

            document.body.innerHTML = printContents;

            window.print();

            document.body.innerHTML = originalContents;
        }

        function printdiv21(drophere21) {
            var printContents = document.getElementById(drophere21).innerHTML;
            var originalContents = document.body.innerHTML;

            document.body.innerHTML = printContents;

            window.print();

            document.body.innerHTML = originalContents;
        }

        function printdiv22(drophere22) {
            var printContents = document.getElementById(drophere22).innerHTML;
            var originalContents = document.body.innerHTML;

            document.body.innerHTML = printContents;

            window.print();

            document.body.innerHTML = originalContents;
        }

        function printdiv23(drophere23) {
            var printContents = document.getElementById(drophere23).innerHTML;
            var originalContents = document.body.innerHTML;

            document.body.innerHTML = printContents;

            window.print();

            document.body.innerHTML = originalContents;
        }

        function printdiv24(drophere24) {
            var printContents = document.getElementById(drophere24).innerHTML;
            var originalContents = document.body.innerHTML;

            document.body.innerHTML = printContents;

            window.print();

            document.body.innerHTML = originalContents;
        }


</script> 
</asp:Content>

