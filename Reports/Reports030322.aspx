<%@ Page Title="" Language="C#" MasterPageFile="~/Reports/Reports.master" AutoEventWireup="true" CodeFile="Reports.aspx.cs" Inherits="Reports_Reports" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
  

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
     <!-- Content Wrapper. Contains page content -->
  <div class="content-wrapper"> 
    <!-- Content Header (Page header) -->
    <section class="content-header sty-one">
      <h1>Reports</h1>
      <ol class="breadcrumb">
        <li><a href="#">Reports</a></li>
        <li><i class="fa fa-angle-right"></i>Reports</li>
      </ol>
    </section>
    <section class="content"> 
      <!-- Small boxes (Stat box) -->
      <div class="row">
        <div class="col-lg-4 m-b-4">
          <div class="card">
          <div class="card-body">
            <div class="row">
              
              <div class="col-lg-12">
                <div class="mail-contnet">
                  <h4 class="text-black m-b-0">Sales Report</h4>
                  <ul>
                      <li><a href="sale_daily.aspx">Daily</a></li>
                      <li><a href="sale_monthly.aspx">Monthly</a></li>
                      <li><a href="sale_yearly.aspx">Yearly</a></li>
                      <li><a href="sale_datewise.aspx">Date wise</a></li>
                      
                                        <li><b><a href="sale_worksheet.aspx">Sale Worksheet</a></b></li>
                      <%--<li><a href="customer_statement.aspx">Customer Payment Report</a></li>--%>
                         <li><a href="cust_statement.aspx">Customer Statement</a></li>
                  </ul>
                </div>
              </div>
            </div>
          </div></div>
        </div>

          
           <div class="col-lg-4 m-b-4">
          <div class="card">
          <div class="card-body">
            <div class="row">
              
              <div class="col-lg-12">
                <div class="mail-contnet">
                  <h4 class="text-black m-b-0">Estimate Report</h4>
                  <ul>
                      <li><a href="est_daily.aspx">Daily</a></li>
                      <li><a href="est_monthly.aspx">Monthly</a></li>
                      <li><a href="est_yearly.aspx">Yearly</a></li>
                      <li><a href="est_datewise.aspx">Date wise</a></li>
                      
                        <li><b><a href="est_worksheet.aspx">Estimate Worksheet</a></b></li>
                      <%--<li><a href="customer_statement.aspx">Customer Payment Report</a></li>--%>
                         <li><a href="cust_statement.aspx">Customer Statement</a></li>
                  </ul>
                </div>
              </div>
            </div>
          </div></div>
        </div>

            <div class="col-lg-4 m-b-4">
          <div class="card">
          <div class="card-body">
            <div class="row">
              
              <div class="col-lg-12">
                <div class="mail-contnet">
                  <h4 class="text-black m-b-0">Sales Payment Report</h4>
                  <ul>
                      <li><a href="sale_payment_daily.aspx">Daily</a></li>
                      <li><a href="sale_payment_monthly.aspx">Monthly</a></li>
                      <li><a href="sale_payment_yearly.aspx">Yearly</a></li>
                    
                  </ul>
                </div>
              </div>
            </div>
          </div></div>
        </div>


          <%--  <div class="col-lg-4 m-b-4">
          <div class="card">
          <div class="card-body">
            <div class="row">
              
              <div class="col-lg-12">
                <div class="mail-contnet">
                  <h4 class="text-black m-b-0">Challan Report</h4>
                  <ul>

                      <li><a href="chl_daily.aspx">Daily</a></li>
                      <li><a href="chl_monthly.aspx">Monthly</a></li>
                      <li><a href="chl_yearly.aspx">Yearly</a></li>
                    
                      
                      
                  </ul>
                </div>
              </div>
            </div>
          </div></div>
        </div>--%>
        <div class="col-lg-4 m-b-4">
          <div class="card">
          <div class="card-body">
            <div class="row">
              
              <div class="col-lg-12">
                <div class="mail-contnet">
                  <h4 class="text-black m-b-0">Purchase Report</h4>
                  <ul>
                      <li><a href="purchase_daily.aspx">Daily</a></li>
                      <li><a href="purchase_monthly.aspx">Monthly</a></li>
                      <li><a href="purchase_yearly.aspx">Yearly</a></li>
                      <li><a href="purchase_datewise.aspx">Date wise</a></li>
                    
                     <%-- <li><a href="vendor_statement.aspx">Vendor Payment Report</a></li>--%>
                      <li><a href="ven_statement.aspx">Vendor Statement</a></li>
                  </ul>
                </div>
              </div>
            </div>
          </div></div>
        </div>
        <div class="col-lg-4 m-b-4">
          <div class="card">
          <div class="card-body">
            <div class="row">
              
              <div class="col-lg-12">
                <div class="mail-contnet">
                  <h4 class="text-black m-b-0">Quotation Reports</h4>
                  <ul>
                      <li><a href="gstq_report.aspx">GST Quotation</a></li>
                      <li><a href="wgstq_report.aspx">Without GST Quotation</a></li>
                     
                     
                  </ul>
                </div>
              </div>
            </div>
          </div></div>
        </div>
     
        <div class="col-lg-4 m-b-4">
          <div class="card">
          <div class="card-body">
            <div class="row">
              
              <div class="col-lg-12">
                <div class="mail-contnet">
                  <h4 class="text-black m-b-0">Expense Report</h4>
                  <ul>
                      <li><a href="expense_daily.aspx">Daily</a></li>
                      <li><a href="expense_monthly.aspx">Monthly</a></li>
                      <li><a href="expense_yearly.aspx">Yearly</a></li>
                      <li><a href="expense_datewise.aspx">Date wise</a></li>
                      
                  </ul>
                </div>
              </div>
            </div>
          </div></div>
        </div>
       <div class="col-lg-4 m-b-4">
          <div class="card">
          <div class="card-body">
            <div class="row">
              
              <div class="col-lg-12">
                <div class="mail-contnet">
                  <h4 class="text-black m-b-0">Outstanding Report</h4>
                  <ul>
                 
                      <li><a href="out_daily.aspx">Daily</a></li>
                      <li><a href="out_monthly.aspx">Monthly</a></li>
                      <li><a href="out_datewise.aspx">Datewise</a></li>
                  </ul>
                </div>
              </div>
            </div>
          </div></div>
        </div>

          <div class="col-lg-4 m-b-4">
          <div class="card">
          <div class="card-body">
            <div class="row">
              
              <div class="col-lg-12">
                <div class="mail-contnet">
                  <h4 class="text-black m-b-0">GST Report</h4>
                  <ul>
                      <li><a href="gst_daily.aspx">Daily</a></li>
                      <li><a href="gst_monthly.aspx">Monthly</a></li>
                      <li><a href="gst_yearly.aspx">Yearly</a></li>
                      <li><a href="gst_datewise.aspx">Date wise</a></li>
                      
                  </ul>
                </div>
              </div>
            </div>
          </div></div>
        </div>
          <div class="col-lg-4 m-b-4">
          <div class="card">
          <div class="card-body">
            <div class="row">
              
              <div class="col-lg-12">
                <div class="mail-contnet">
                  <h4 class="text-black m-b-0">Balance Sheet</h4>
                  <ul>
                      <li><a href="cust_bal.aspx">Customer Balance</a></li>
                      
                  </ul>
                </div>
              </div>
            </div>
          </div>
          </div>
        </div>
           <div class="col-lg-4 m-b-4">
          <div class="card">
          <div class="card-body">
            <div class="row">
              
              <div class="col-lg-12">
                <div class="mail-contnet">
                  <h4 class="text-black m-b-0">Advance Report</h4>
                  <ul>
                      
                      <li><a href="adv_daily.aspx">Daily</a></li>
                      <li><a href="adv_monthly.aspx">Monthly</a></li>
                      <li><a href="adv_yearly.aspx">Yearly</a></li>
                  </ul>
                </div>
              </div>
            </div>
          </div></div>
        </div>

       <%--  <div class="col-lg-4 m-b-4">
          <div class="card">
          <div class="card-body">
            <div class="row">
              
              <div class="col-lg-12">
                <div class="mail-contnet">
                  <h4 class="text-black m-b-0">Estimate Details</h4>
                  <ul>
                      
                      <li><a href="estimate_customerwise.aspx">Customer wise</a></li>
                  </ul>
                </div>
              </div>
            </div>
          </div></div>
        </div>--%>
        
        
      </div>
      <!-- Main row --> 
    </section>
 
      
  </div>
    
  <!-- /.content-wrapper -->
  <footer class="main-footer">
    <div class="pull-right hidden-xs">Version 1.0</div>
    Copyright © 2018 PrintSoft. All rights reserved.</footer>


</asp:Content>

