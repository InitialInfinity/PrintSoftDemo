<%@ Page Title="" Language="C#" MasterPageFile="~/Reports/Reports.master" AutoEventWireup="true" CodeFile="estimate_customerwise.aspx.cs" Inherits="Reports_estimate_customerwise" %>

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
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
       <!-- Content Wrapper. Contains page content -->
  <div class="content-wrapper"> 
    <!-- Content Header (Page header) -->
    <section class="content-header sty-one">
      <h1>Estimate Details - Customer wise</h1>
      <ol class="breadcrumb">
        <li><a href="#">Reports</a></li>
        <li><i class="fa fa-angle-right"></i>Estimate Details - Customer wise</li>
      </ol>
    </section>
  <section class="content">
      
        
        <div class="card m-t-3">
      <div class="card-body">
      <h4 class="text-black">Estimate Report</h4>
     
      <div class="table-responsive">
                  <table id="example1" class="table table-bordered table-striped">
                <thead>
                <tr>
                  <th>Sr.No.</th>
                  <th>Invoice ID</th>
                  <th>Date</th>
                  <th>Name</th>
                  <th>Contact</th>
                  <th>Address</th>
                  <th>GST</th>
                  
                    <th>Total</th>
                   
                  <th>Actions</th>
                </tr>
                </thead>
                <tbody>

          <asp:Repeater ID="Repeater1" runat="server">
              <ItemTemplate>
                   <tr>
                    <td>
              <asp:Label ID="lbl_sr" runat="server" Text='<%# Eval("est_id") %>'></asp:Label></td>
                  <td>
              <asp:Label ID="lbl_invoice" runat="server" Text='<%# Eval("est_invoice_no") %>'></asp:Label></td>
                  <td><asp:Label ID="lbl_date" runat="server" Text='<%# Eval("est_date") %>'></asp:Label></td>
                <td><asp:Label ID="lbl_cust_name" runat="server" Text='<%# Eval("est_customer_name") %>'></asp:Label></td>
                       <td><asp:Label ID="lbl_cust_contact" runat="server" Text='<%# Eval("est_customer_contact") %>'></asp:Label></td>
                       <td><asp:Label ID="lbl_cust_address" runat="server" Text='<%# Eval("est_customer_address") %>'></asp:Label></td>
                       <td><asp:Label ID="lbl_cust_gst_no" runat="server" Text='<%# Eval("est_customer_gst_no") %>'></asp:Label></td>
                       
                       <td><asp:Label ID="lbl_total" runat="server" Text='<%# Eval("est_total") %>'></asp:Label></td>
                  <td><a title="View" href=""><i style="padding-left:10px" class="fa fa-eye"></i></a><a title="Edit" href=""><i style="padding-left:10px" class="fa fa-edit"></i></a><a title="Delete" href=""><i style="padding-left:10px" class="fa fa-trash-o"></i></a></td>
                </tr>
              </ItemTemplate>

          </asp:Repeater>

              
                </tbody>
                
              </table>



          <div class="col-md-12">
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

