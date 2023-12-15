<%@ Page Title="" Language="C#" MasterPageFile="~/Main.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
      <meta charset="utf-8"/>
<meta http-equiv="X-UA-Compatible" content="IE=edge"/>

<!-- Tell the browser to be responsive to screen width -->
<meta content="width=device-width, initial-scale=1, maximum-scale=1, user-scalable=no" name="viewport"/>

<!-- v4.0.0 -->
<link rel="stylesheet" href="dist/bootstrap/css/bootstrap.min.css"/>

<!-- Favicon -->
<link rel="icon" type="image/png" sizes="16x16" href="dist/img/favicon-16x16.png"/>

<!-- Google Font -->
<link href="https://fonts.googleapis.com/css?family=Poppins:300,400,500,600,700" rel="stylesheet"/>


<!-- Theme style -->
<link rel="stylesheet" href="dist/css/style.css"/>
<link rel="stylesheet" href="dist/css/font-awesome/css/font-awesome.min.css"/>
<link rel="stylesheet" href="dist/css/et-line-font/et-line-font.css"/>
<link rel="stylesheet" href="dist/css/themify-icons/themify-icons.css"/>
<link rel="stylesheet" href="dist/css/simple-lineicon/simple-line-icons.css"/>
      <link href="dist/plugins/calendar/fullcalendar.min.css" rel="stylesheet" />
     <style>
        hr {
    margin-top: 0rem !important;
    margin-bottom: 0rem !important;
    border: 0;
    border-top: 1px solid rgba(0,0,0,.1);
}
         .btn
        {
           
        }

          .btn1
          {
              background-color:#ce8427;
              padding:25px 35px;
              font-size:17px;
              color:#fff;
          }

          .btn2
          {
              background-color:#462066;
              padding:25px 35px;
              font-size:17px;
              color:#fff;
          }
          .btn3
          {
              background-color:#229081;
              padding:25px 35px;
              font-size:17px;
              color:#fff;
          }
          .btn4
          {
              background-color:#da5737;
              padding:25px 35px;
              font-size:17px;
              color:#fff;
          }
          .btn5
          {
              background-color:#ce8427;
              padding:25px 35px;
              font-size:17px;
              color:#fff;
          }
    </style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
      <!-- Content Wrapper. Contains page content -->
  <div class="content-wrapper"> 
    <!-- Content Header (Page header) -->
    <section class="content-header sty-one">
      <h1>Dashboard</h1>
       <div style="float:right; margin-top:-25px;">
              <asp:ScriptManager ID="ScriptManager1" runat="server">    
</asp:ScriptManager>
<asp:UpdatePanel ID="UpdatePanel1" runat="server">
<ContentTemplate>
     <asp:Label runat="server" Text="TIME:"></asp:Label>&nbsp
<asp:Timer ID="Timer1" runat="server" Interval="1000">
</asp:Timer>
<asp:Label ID="lblcurrenttime" runat="server" Text=""></asp:Label>
</ContentTemplate>
</asp:UpdatePanel>
        </div>
    </section>
      <asp:Panel ID="Panel1" runat="server">
    <!-- Main content -->
    <section class="content">
     
      
      <div class="row">
        <div class="col-lg-3">
          <div class="tile-progress tile-pink">
            <div class="tile-header">
              
              <h3>₹ <asp:Label ID="Lbl_monthlysale" runat="server" Text=""></asp:Label></h3>
            </div>
            <div class="tile-progressbar"> <span data-fill="65.5%" style="width: 65.5%;"></span> </div>
            <div class="tile-footer">
              <a href="Sale/invoice_report.aspx"><h6 style="color:white;">Monthly Sales</h6></a>
            </div>
          </div>
        </div>
        <div class="col-lg-3">
          <div class="tile-progress tile-red">
            <div class="tile-header">
              
              <h3>₹ <asp:Label ID="Lbl_monthlypurchase" runat="server" Text=""></asp:Label></h3>
            </div>
            <div class="tile-progressbar"> <span data-fill="70%" style="width: 70%;"></span> </div>
            <div class="tile-footer">
              <a href="Purchase/list_of_purchase.aspx"><h6 style="color:white;">Monthly Roll & Purchase</h6></a>
            </div>
          </div>
        </div>
          <div class="col-lg-3">
          <div class="tile-progress tile-cyan">
            <div class="tile-header">
              
              <h3>₹ <asp:Label ID="Lbl_monthlyexpense" runat="server" Text=""></asp:Label></h3>
            </div>
            <div class="tile-progressbar"> <span data-fill="75.5%" style="width: 75.5%;"></span> </div>
            <div class="tile-footer">
            <a href="Expense/expense.aspx"><h6 style="color:white;">Monthly Expense</h6></a>
            </div>
          </div>
        </div>
        <div class="col-lg-3">
          <div class="tile-progress tile-aqua">
            <div class="tile-header">
              
              <h3>₹ <asp:Label ID="Lbl_monthlyprofit" runat="server" Text=""></asp:Label></h3>
            </div>
            <div class="tile-progressbar"> <span data-fill="50%" style="width: 50%;"></span> </div>
            <div class="tile-footer">
              <h6>Monthly Profits</h6>
            </div>
          </div>
        </div>
        
      </div>
      <!-- /.row -->

        <div class="row" style="margin-bottom:15px;">
      <div class="col-lg-2 col-md-3 col-sm-12" style="margin-left: 73px;">
        <%--  <a href="add_customer.aspx"><asp:Button ID="Button1" runat="server" Text="New Product" class="btn btn-primary"/></a>--%>
          <asp:LinkButton ID="LinkButton1" runat="server" href="Master/add_product.aspx" class="btn btn-lg btn1">New Product</asp:LinkButton>
      </div>
          <div class="col-lg-2 col-md-2 col-sm-12" style="margin-left:20px;">
              <asp:LinkButton ID="LinkButton2" runat="server" href="Master/add_customer.aspx" class="btn btn-lg btn2">New Customers</asp:LinkButton>
          </div>
           <div class="col-lg-2 col-md-2 col-sm-12" style="margin-left:47px;">
              <asp:LinkButton ID="LinkButton3" runat="server" href="Expense/expense.aspx" class="btn btn-lg btn3">New Expense</asp:LinkButton>
          </div>
          <%-- <div class="col-lg-2 col-md-2 col-sm-12" style="margin-left:-30px;">
              <asp:LinkButton ID="LinkButton4" runat="server" href="Bank/add_bank.aspx" class="btn btn-success btn-lg">Bank Account</asp:LinkButton>
          </div>--%>
           <div class="col-lg-2 col-md-2 col-sm-12" style="margin-left:23px;">
              <asp:LinkButton ID="LinkButton5" runat="server" href="Sale/sale_invoice.aspx" class="btn btn-lg btn4">Create Invoice</asp:LinkButton>
          </div>
          <div class="col-lg-2 col-md-2 col-sm-12" style="margin-left:37px;">
              <asp:LinkButton ID="LinkButton6" runat="server" href="Sale/estimate.aspx" class="btn btn-lg btn5">Create Estimate</asp:LinkButton>
          </div>
      </div>
      
      <div class="row">
        <div class="col-lg-12">
          <div class="info-box">
            <div class="col-12">
              <div class="d-flex flex-wrap">
                <div>
                  <h5>Yearly Earning</h5>
                </div>
                <div class="ml-auto">
                  <ul class="list-inline">
                    <li class="text-green"> <i class="fa fa-circle"></i> Purchase</li>
                    <li class="text-blue"> <i class="fa fa-circle"></i> Sale</li>
                  </ul>
                </div>
              </div>
            </div>
            <div class="row">
              <div class="col-lg-9 m-b-3">
                <div id="earning"></div>
              </div>
              <div class="col-lg-3 m-t-5">
                <div class="m-b-5 text-center"> <i class="icon-bargraph f-40 m-b-2 text-blue"></i>
                  <h6 class="f-14">Sale (₹)</h6>
                  <h4 id="salesTotalLable"></h4>
                </div>
                <div class="m-b-5 text-center"> <i class="icon-strategy f-40 m-b-2 text-blue"></i>
                  <h6 class="f-14">Purchase (₹)</h6>
                  <h4 id="earningTotalLable">
                     <%-- <asp:HiddenField ID="earningTotalLable" runat="server" />
                      <asp:Label ID="pttotal" runat="server" Text=""></asp:Label>--%>
                  </h4>
                </div>
              </div>
            </div>
          </div>
        </div>
       
      </div>
      <!-- /.row -->


         <div class="row">
        <div class="col-lg-3">
          <div class="tile-progress tile-light-green">
            <div class="tile-header">
              
              <h3>₹ <asp:Label ID="lbl_daily_sales" runat="server" Text=""></asp:Label></h3>
            </div>
            <div class="tile-progressbar"> <span data-fill="65.5%" style="width: 65.5%;"></span> </div>
            <div class="tile-footer"><h6 style="color:white;">Daily Sales</h6>
            </div>
          </div>
        </div>
        <div class="col-lg-3">
          <div class="tile-progress tile-dark-purple">
            <div class="tile-header">
              
              <h3>₹ <asp:Label ID="lbl_daily_advance" runat="server" Text=""></asp:Label></h3>
            </div>
            <div class="tile-progressbar"> <span data-fill="70%" style="width: 70%;"></span> </div>
            <div class="tile-footer"><h6 style="color:white;">Daily Advance</h6>
            </div>
          </div>
        </div>
             <div class="col-lg-3">
          <div class="tile-progress tile-light-purple">
            <div class="tile-header">              
              <h3>₹ <asp:Label ID="lbl_daily_expense" runat="server" Text=""></asp:Label></h3>
            </div>
            <div class="tile-progressbar"> <span data-fill="75.5%" style="width: 75.5%;"></span> </div>
            <div class="tile-footer"><h6 style="color:white;">Daily Expense</h6>
            </div>
          </div>
        </div>
          <div class="col-lg-3">
          <div class="tile-progress tile-light-pink">
            <div class="tile-header">            
              <h3>₹ <asp:Label ID="lbl_daily_balance" runat="server" Text=""></asp:Label></h3>
            </div>
            <div class="tile-progressbar"> <span data-fill="75.5%" style="width: 75.5%;"></span> </div>
            <div class="tile-footer"><h6 style="color:white;">Daily Balance</h6>
            </div>
          </div>
        </div>
          
        <%-- <div class="col-lg-3" >
          <div class="tile-progress tile-aqua" style="height:110px;">
            <div class="tile-header">
              
              <h3><asp:Label ID="lbl_daily_sqft" runat="server" Text=""></asp:Label></h3>
            </div>
            <div class="tile-progressbar"> <span data-fill="50%" style="width: 50%;"></span> </div>
            <div class="tile-footer">
              <h6>Daily SQFT</h6>
            </div>
          </div>
        </div>--%>
        
      </div>
      <!-- /.row -->

      
        <div class="card m-b-3">
          <div class="card-body">
            <div class="row">
              <div class="col-lg-3 col-sm-6 col-xs-12">
                <div> 
                  <div class="info-box-content">
                    <h4 class="text-blue text-center">Vendors</h4>
                    <h1 class="f-25 text-black text-center">
            <asp:Label ID="lbl_total_vendor" runat="server" Text=""></asp:Label></h1> <hr/> </div>
                   
                  <div class="text-center"><a href="Master/add_vendor.aspx"><i class="fa fa-plus text-blue" ></i> Add Vendor</a></div>
                </div>
                <!-- /.info-box --> 
              </div>
              <div class="col-lg-3 col-sm-6 col-xs-12">
                <div> 
                  <div class="info-box-content">
                      <h4 class="text-danger text-center">Products</h4>
                    <h1 class="f-25 text-black text-center"><asp:Label ID="lbl_total_products" runat="server" Text=""></asp:Label></h1><hr/>
                     </div>
                  
                     <div class="text-center"><a href="Master/add_product.aspx"><i class="fa fa-plus text-danger" ></i> Add Product</a></div>
                  </div >
                
                <!-- /.info-box --> 
              </div>
              <div class="col-lg-3 col-sm-6 col-xs-12">
                <div> 
                  <div class="info-box-content">
                      <h4 class="text-info text-center">Invoices</h4>
                    <h1 class="f-25 text-black text-center"><asp:Label ID="lbl_total_invoice" runat="server" Text=""></asp:Label></h1> <hr/></div>
                   
                    <div class="text-center"><a href="Sale/sale_invoice.aspx"><i class="fa fa-plus text-info" ></i> Add Sale</a></div>
                    <div class="text-center"><a href="Sale/estimate.aspx"><i class="fa fa-plus text-info" ></i> Add Estimate</a></div>
                  </div>
               
                <!-- /.info-box --> 
              </div>
              <div class="col-lg-3 col-sm-6 col-xs-12">
                <div> 
                  <div class="info-box-content">
                      <h4 class="text-green text-center">Quotations</h4>
                    <h1 class="f-25 text-black text-center"><asp:Label ID="lbl_total_quotation" runat="server" Text=""></asp:Label></h1>  <hr/></div>
                   
                    <div class="text-center"><a href="Quotation/gst_quotation.aspx"><i class="fa fa-plus text-green" ></i> Add Quotation</a></div>
                  </div>
               
                <!-- /.info-box --> 
              </div>
                           <%--<div class="col-lg-3 col-sm-6 col-xs-12">
                <div> 
                  <div class="info-box-content">
                      <h4 class="text-blue text-center">Daily Machine Counter</h4>
                    <h1 class="f-25 text-black text-center"><asp:Label ID="lbl_exp_count" runat="server" Text=""></asp:Label></h1>  <hr/></div>
                   
                    <div class="text-center"><a href="Expense/expense.aspx"><i class="fa fa-plus text-green" ></i> Add Expense</a></div>
                  </div>
               
                 /.info-box  
              </div>--%>
            </div>
          </div>
      </div>




        <div class="row m-b-2" >
                    <div class="col-12">

                        <div class="card">
                            <div class="card-body">
                                <div class="row">
                                 
                                    <div class="col-lg-12">
                                        <div id="calendar"></div>
                                    </div> <!-- end col -->

                                </div>  <!-- end row -->
                            </div> <!-- end card body-->
                        </div> <!-- end card -->

                     
                        
                    </div>
                    <!-- end col-12 -->
                </div> <!-- end row --> 







        <div class="row">
          <div class="col-xl-12">
         <div class="tile-progress tile-cyan">
            <div class="tile-header">
             
              <h5>Turnover</h5>
              <h5>Total Amount : ₹ <asp:Label ID="lbl_total_amt" runat="server" Text=""></asp:Label> | Total Advance : ₹ <asp:Label ID="lbl_total_adv" runat="server" Text=""></asp:Label></h5>
              <br/>
              <h5>Expense</h5>
              <h5>Total Purchase : ₹ <asp:Label ID="lbl_total_pur" runat="server" Text=""></asp:Label> | Total Expense : ₹ <asp:Label ID="lbl_total_exp" runat="server" Text=""></asp:Label> | Total Salary : ₹ <asp:Label ID="lbl_total_sal" runat="server" Text=""></asp:Label></h5>
              <br/>
              <h5>Business</h5>
              <h5>Total Profit : ₹ <asp:Label ID="lbl_total_col" runat="server" Text=""></asp:Label></h5>
            </div>
            
            <div class="tile-footer">
              <a href="Reports/adv_monthly.aspx"><h5 style="color:white;">Monthly Total Business Details</h5></a>
            </div>
          </div>
         </div>
      </div>
      <!-- /.row -->

      <div class="row">
        <div class="col-xl-8">
          <div class="info-box">
            <div class="card-header">
              <h5 class="card-title">Recent Sales <a href="Sale/invoice_report.aspx" class="btn btn-sm btn-primary pull-right text-white">View all</a></h5>
            </div>
            <div class="table-responsive">
              <table class="table table-hover">
                <thead>
                  <tr>
                    <th>Invoice</th>
                    <th>Date</th>
                    <th>Customer</th>
                    <th>Status</th>
                    <th>Amount</th>
                  </tr>
                </thead>
                <tbody>
                    <asp:Repeater ID="Repeater1" runat="server" OnItemDataBound="Repeater1_ItemDataBound">
                        <ItemTemplate>
                  <tr>
                    <td onclick="window.location.href ='Sale/bill.aspx?invoice=<%# Eval("sl_invoice_no") %>'"><asp:Label ID="lbl_invoice" runat="server" Text='<%# Eval("sl_invoice_no") %>'></asp:Label></td>
                    <td onclick="window.location.href ='Sale/bill.aspx?invoice=<%# Eval("sl_invoice_no") %>'"><asp:Label ID="lbl_date" runat="server" Text='<%# Eval("sl_date", "{0:dd/MM/yyyy}") %>'></asp:Label></td>
                    <td onclick="window.location.href ='Sale/bill.aspx?invoice=<%# Eval("sl_invoice_no") %>'"><asp:Label ID="lbl_customer" runat="server" Text='<%# Eval("c_name") %>'></asp:Label></td>
                    <td onclick="window.location.href ='Sale/bill.aspx?invoice=<%# Eval("sl_invoice_no") %>'"><asp:Label ID="lbl_status" runat="server" Text=''></asp:Label></td>
                    <td onclick="window.location.href ='Sale/bill.aspx?invoice=<%# Eval("sl_invoice_no") %>'"><asp:Label ID="lbl_amount" runat="server" Text='<%# Eval("sl_total") %>'></asp:Label></td>
                  </tr>
                            </ItemTemplate>
                 </asp:Repeater>
                </tbody>
              </table>
            </div>
          </div>
        </div>
         <div class="col-xl-4 m-b-3">
          <div class="info-box">
            <div class="col-12">
              <div class="d-flex flex-wrap">
                <div>
                  <h5 class="m-b-15">Statistics</h5>
                </div>
              </div>
            </div>
            <div class="col-lg-10 m-auto m-top-40 m-bot-10">
              <div id="donut"></div>
            </div>
            <div class="row">
     <%--         <div class="col-xl-4 m-b-2 text-center">
                <h6 class="f-14">sale qty.</h6>
                <h4 id="Donut1"></h4>
              </div>
              <div class="col-xl-4 m-b-2 text-center">
                <h6 class="f-14">Paid salary</h6>
                <h4 id="Donut2"></h4>
              </div>
              <div class="col-xl-4 m-b-2 text-center">
                <h6 class="f-14">Total exp.</h6>
                <h4 id="Donut3"></h4>
              </div>--%>
            </div>
          </div>
        </div>
      </div>
      <!-- /.row -->
      
      
    </section>
    <!-- /.content --> 
          </asp:Panel>
  </div>
  
  <!-- /.content-wrapper -->
  <footer class="main-footer">
    <div class="pull-right hidden-xs">Version 1.0</div>
    Copyright © 2018 PrintSoft. All rights reserved.</footer>

     
    <!-- Calendar -->


     <!-- Add New Event MODAL -->
                        <div id="myModal" class="modal fade" role="dialog">
                            <div class="modal-dialog">
                                <div class="modal-content">
                                    <div class="modal-header">
                                        <h4 class="modal-title"><span id="eventTitle"></span></h4>
                                        <button type="button" class="close" data-dismiss="modal">&times;</button>
                                    </div>
                                    <div class="modal-body">
                                        
                                        <p id="pDetails"></p>
                                    </div>
                                    <div class="modal-footer">
                                        <input type="button" class="btn btn-light " data-dismiss="modal" value="Close" />
                                       <button type="button" id="btnDelete" class="btn btn-danger">Delete</button>
                                        <button type="button" id="btnEdit" class="btn btn-success">Edit</button>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <!-- end modal-->
                        <div id="myModalSave" class="modal fade" role="dialog">
                            <div class="modal-dialog">
                                <div class="modal-content">
                                    <div class="modal-header">
                                        <h4 class="modal-title">Save Event</h4>
                                        <button type="button" class="close" data-dismiss="modal">&times;</button>
                                        
                                    </div>
                                    <div class="modal-body">
                                        <div class="form-horizontal">
                                            <input type="hidden" id="hdEventID" value="0" />
                                            <div class="form-group">
                                                <label>Subject <span style="color:red;">*</span></label>
                                                <input type="text" id="txtSubject" class="form-control" />
                                            </div>
                                            <div class="form-group">
                                                <label>Start <span style="color:red;">*</span></label>
                                                <div class="input-group date" id="dtp1">
                                                    <input type="date" id="txtStart"  class="form-control"/>
                                                    <%--<asp:TextBox ID="txtStart"  class="form-control" TextMode="Date" runat="server"></asp:TextBox>--%>
                                                    <span class="input-group-addon">
                                                        <span class="glyphicon glyphicon-calendar"></span>
                                                    </span>
                                                </div>
                                            </div>
                                           
                                            <div class="form-group" id="divEndDate" >
                                                <label>End <span style="color:red;">*</span></label>
                                                <div class="input-group date" id="dtp2">
                                                    <input type="date" id="txtEnd" class="form-control" />
                                                    <span class="input-group-addon">
                                                        <span class="glyphicon glyphicon-calendar"></span>
                                                    </span>
                                                </div>
                                            </div>
                                            <div class="form-group">
                                                <label>Description</label>
                                                <textarea id="txtDescription" rows="3" class="form-control"></textarea>
                                            </div>
                                            <div class="form-group">
                                                <label>Theme Color</label>
                                                <select id="ddThemeColor" class="form-control">
                                                    <option value="">Default</option>
                                                    <option value="red">Red</option>
                                                    <option value="blue">Blue</option>
                                                    <option value="black">Black</option>
                                                    <option value="green">Green</option>
                                                </select>
                                            </div>
                                            <button type="button" id="btnSave" class="btn btn-success" style="margin-left:150px">Save</button>
                                            <button type="button" class="btn btn-default" data-dismiss="modal"  style="background-color:#92c4d7;">Close</button>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>

      <script src="//ajax.googleapis.com/ajax/libs/jquery/1.9.1/jquery.min.js"></script>


    <script>
        $(document).ready(function () {
            /* initialize the external events
            -----------------------------------------------------------------*/

            $('#external-events .fc-event').each(function () {

                // store data so the calendar knows to render an event upon drop
                $(this).data('event', {
                    title: $.trim($(this).text()), // use the element's text as the event title
                    stick: true // maintain when user navigates (see docs on the renderEvent method)
                });

                // make the event draggable using jQuery UI
                $(this).draggable({
                    zIndex: 999,
                    revert: true,      // will cause the event to go back to its
                    revertDuration: 0  //  original position after the drag
                });

            });

            FetchEventAndRenderCalendar();

            
            $('#btnEdit').click(function () {
                //Open modal dialog for edit event
                openAddEditForm();
            })
            $('#btnDelete').click(function () {
                if (selectedEvent != null && confirm('Are you sure want to delete event ?')) {
                    $.ajax({
                        type: 'POST',
                        async: false,
                        contentType: "application/json; charset=utf-8",
                        dataType: "json",
                        url: '<%=ResolveUrl("~/Default.aspx/DeletEvent")%>',
                        data: JSON.stringify({ 'eventID': selectedEvent.eventID }),
                        success: function (data) {
                            if (data.d.status) {
                                //Refresh the calender
                                FetchEventAndRenderCalendar();
                                $('#myModal').modal('hide');
                            }
                        },
                        error: function (ex) {
                            alert('Failed');
                        }
                    })
                }
            })
            
            //$('#chkIsFullDay').change(function () {
            //    if ($(this).is(':checked')) {
            //        $('#divEndDate').hide();
            //    }
            //    else {
            //        $('#divEndDate').show();
            //    }
            //});
            
            $('#btnSave').click(function () {
                //Validation/
                if ($('#txtSubject').val().trim() == "") {
                    alert('Please enter Subject');
                    return;
                }
                if ($('#txtStart').val().trim() == "") {
                    alert('Start date required');
                    return;
                }
                if ( $('#txtEnd').val().trim() == "") {
                    alert('End date required');
                    return;
                }
                else {
                    var startDate = moment($('#txtStart').val(), "DD-MMM-YYYY HH:mm a").toDate();
                    var endDate = moment($('#txtEnd').val(), "DD-MMM-YYYY HH:mm a").toDate();
                    if (startDate > endDate) {
                        alert('Invalid end date');
                        return;
                    }
                }
                var data = {
                    EventID: $('#hdEventID').val(),
                    Subject: $('#txtSubject').val().trim(),
                    Start:$('#txtStart').val().trim(),
                    End: $('#txtEnd').val().trim(),
                    Description: $('#txtDescription').val(),
                    ThemeColor: $('#ddThemeColor').val(),
                    IsFullDay: $('#chkIsFullDay').is(':checked')
                }
                SaveEvent(data);

                // call function for submit data to the server 
            })
           
            $('#dtp1,#dtp2').datetimepicker({
                format: 'DD-MMM-YYYY HH:mm a'
            });

        });

        function openAddEditForm() {
            if (selectedEvent != null) {
                $('#hdEventID').val(selectedEvent.eventID);
                $('#txtSubject').val(selectedEvent.title);
                $('#txtStart').val(selectedEvent.start.format("DD-MMM-YYYY HH:mm a"));
                $('#txtEnd').val(selectedEvent.end != null ? selectedEvent.end.format("DD-MMM-YYYY HH:mm a") : '');
                $('#txtDescription').val(selectedEvent.description);
                $('#ddThemeColor').val(selectedEvent.color);
            }
            $('#myModal').modal('hide');
            $('#myModalSave').modal();
        }
         function SaveEvent(data) {
                var d ={f:data}
                $.ajax({
                    type: 'POST',
                    async: false,
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    url: '<%=ResolveUrl("~/Default.aspx/SaveEvent")%>',
                    data: JSON.stringify(d),
                    success: function (data) {
                        if (data.d.status) {
                            //Refresh the calender
                            FetchEventAndRenderCalendar();
                            $('#myModalSave').modal('hide');
                        }
                    },
                    error: function (ex) {
                        alert('Failed');
                    }
                })
            }

        function FetchEventAndRenderCalendar() {

            // if you want to empty events already in calendar.
            $('#calendar').fullCalendar('destroy');

                var events;
                //  alert("dvdv");
                $.ajax({
                    url: '<%=ResolveUrl("~/Default.aspx/getEvents")%>',
                    type: 'POST',
                    async: false,
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    //data: { Id: 1 },
                    success: function (data) {
                        events = JSON.stringify(data.d);
                        //  alert(obj);
                        // return obj;
                    },
                    error: function (xhr, err) {
                        alert("readyState: " + xhr.readyState + "\nstatus: " + xhr.status);
                        alert("responseText: " + xhr.responseText);
                    }
                });



                /* initialize the calendar
                -----------------------------------------------------------------*/
                var selctedEvent = null;
                $('#calendar').fullCalendar({

                    header: {
                        left: 'prev,next today',
                        center: 'title',
                        right: 'month,agendaWeek,agendaDay'
                    },
                    editable: true,
                    droppable: true, // this allows things to be dropped onto the calendar
                    dragRevertDuration: 0,
                    drop: function () {
                        // is the "remove after drop" checkbox checked?
                        if ($('#drop-remove').is(':checked')) {
                            // if so, remove the element from the "Draggable Events" list
                            $(this).remove();
                        }
                    },
                    eventLimit: true,
                    eventColor: '#378006',
                    events: JSON.parse(events),
                    eventClick: function (calEvent, jsEvent, view) {
                        selectedEvent = calEvent;
                        $('#myModal #eventTitle').text(calEvent.title);
                        var $description = $('<div/>');
                        $description.append($('<p/>').html('<b>Start: </b>' + calEvent.start.format("DD-MMM-YYYY HH:mm a")));
                        if (calEvent.end != null) {
                            $description.append($('<p/>').html('<b>End: </b>' + calEvent.end.format("DD-MMM-YYYY HH:mm a")));
                        }
                        $description.append($('<p/>').html('<b>Description: </b>' + calEvent.description));
                        $('#myModal #pDetails').empty().html($description);

                        $('#myModal').modal();
                    },
                    selectable: true,
                    select: function (start, end) {
                        selectedEvent = {
                            eventID: 0,
                            title: '',
                            description: '',
                            start: start,
                            end: end,
                            allDay: false,
                            color: ''
                        };
                        openAddEditForm();
                        $('#calendar').fullCalendar('unselect');
                    },
                    editable: true,
                    eventDrop: function (event) {
                        var data = {
                            EventID: event.eventID,
                            Subject: event.title,
                            Start: event.start.format("DD-MMM-YYYY HH:mm a"),
                            End: event.end != null ? event.end.format("DD-MMM-YYYY HH:mm a") : null,
                            Description:  event.description,
                            ThemeColor: event.color,
                            IsFullDay: event.allDay
                        };
                        SaveEvent(data);
                    }
                    //eventDragStop: function (event, jsEvent, ui, view) {

                    //    if (isEventOverDiv(jsEvent.clientX, jsEvent.clientY)) {
                    //        $('#calendar').fullCalendar('removeEvents', event._id);
                    //        var el = $("<div class='fc-event'>").appendTo('#external-events-listing').text(event.title);
                    //        el.draggable({
                    //            zIndex: 999,
                    //            revert: true,
                    //            revertDuration: 0
                    //        });
                    //        el.data('event', { title: event.title, id: event.id, stick: true });
                    //    }
                    //}
                });

            }
    </script>

    <script language="javascript" type="text/javascript">
    history.forward();
</script>


   
</asp:Content>

