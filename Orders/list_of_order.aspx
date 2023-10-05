<%@ Page Title="" Language="C#" MasterPageFile="~/Orders/Orders.master" AutoEventWireup="true" CodeFile="list_of_order.aspx.cs" Inherits="Orders_list_of_order" %>

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
      <h1>List of Orders</h1>
      <ol class="breadcrumb">
        <li><a href="#">Orders</a></li>
        <li><i class="fa fa-angle-right"></i>List of Orders</li>
      </ol>

    </section>
     
       
     
     <section class="content">
      <div class="row">
          <div class="col-lg-3">
          <div class="tile-progress tile-pink">
            <div class="tile-header">
              
              <h3><asp:Label ID="lbl_total_invoice" runat="server" Text=""></asp:Label></h3>
            </div>
            
            <div class="tile-footer">
              <h6>Total Invoice </h6>
            </div>
          </div>
        </div>   
            <div class="col-lg-3">
          <div class="tile-progress tile-red">
            <div class="tile-header">
              
              <h3>₹ <asp:Label ID="lbl_total_invoice_amount" runat="server" Text=""></asp:Label></h3>
            </div>
           
            <div class="tile-footer">
              <h6>Total Invoice Amt.</h6>
            </div>
          </div>
        </div>

           <div class="col-lg-4" >
          <div class="tile-progress tile-red" style="background-color:#800000">
            <div class="tile-header">
              
              <h3>₹ <asp:Label ID="lbl_total_discount" runat="server" Text=""></asp:Label></h3>
            </div>
           
            <div class="tile-footer">
              <h6>Discount</h6>
            </div>
          </div>
        </div>

          <div class="col-lg-3">
          <div class="tile-progress tile-cyan">
            <div class="tile-header">
              
              <h3>₹ <asp:Label ID="Lbl_balance" runat="server" Text=""></asp:Label></h3>
            </div>
           
            <div class="tile-footer">
              <h6>Balance</h6>
            </div>
          </div>
        </div>
          <div class="col-lg-3">
          <div class="tile-progress tile-aqua">
            <div class="tile-header">
              
              <h3>₹ <asp:Label ID="Lbl_advace" runat="server" Text=""></asp:Label></h3>
            </div>
            
            <div class="tile-footer">
              <h6>Advance</h6>
            </div>
          </div>
        </div>   

 </div>
      <!-- /.row -->
        <asp:Panel ID="Panel2" runat="server">
              <div class="alert alert-success" role="alert">
  <button type="button" class="close" data-dismiss="alert" aria-label="Close"><span aria-hidden="true">&times;</span></button>
  <strong>Success!</strong> Order successfully created!
</div>     
        </asp:Panel>
        <div class="card">

      <div class="card-body">
      <div class="row">
        <div class="col-md-3">
         <h4 class="text-black">Order List</h4>
        </div>
        
             <div class="col-md-9 exportbtn">
           <a href="order.aspx"><button type="button" id="btn_mail"  title="Create New Order" class="btn btnsqr btn-primary4 btngap"> <i class="fa fa-plus"></i>Add Order</button></a>
         
        <button type="button" id="btn_print" title="Print" onclick="printdiv('dropHere');" class="btn btnsqr btn-primary "> <i class="fa fa-print"></i> Print</button>
      
        
      </div>
      </div>
     <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
       <div id="dropHere" class="table-responsive">
            <asp:Panel ID="pnlinvoice" runat="server">
                  <table id="example1" class="table table-bordered table-striped">
                <thead>
                <tr>
                  <th>Sr.No.</th>
                  <th>Invoice</th>
                  <th>Date</th>
                  <th>Name</th>
                  <th>Contact</th>
                  <th>Pending</th>
                  <th>Total</th>
                   
                  <th class="no-print">Actions</th>
                </tr>
                </thead>
                <tbody>
                    <tr class="no-print" id="tbltextbox" runat="server">
                        
                        <td></td>
                        <td><asp:TextBox ID="Txt_sr_invoice" Class="form-control" placeholder="Invoice ID" runat="server"  AutoPostBack="True" OnTextChanged="Txt_sr_invoice_TextChanged" ></asp:TextBox></td>
                        <td><asp:TextBox ID="Txt_sr_date" Class="form-control" placeholder="Date" runat="server" OnTextChanged="Txt_sr_date_TextChanged" ></asp:TextBox></td>
                        <td><asp:TextBox ID="Txt_sr_name" Class="form-control" placeholder="Customer" runat="server" OnTextChanged="Txt_sr_name_TextChanged" ></asp:TextBox></td>
                        <td><asp:TextBox ID="Txt_sr_contact" Class="form-control" placeholder="Contact" runat="server" OnTextChanged="Txt_sr_contact_TextChanged" ></asp:TextBox></td>
                        <td></td>
                        <td></td>
                    
                        <td><asp:Button ID="Button2" class="btn btn-success pull-right glyphicon glyphicon-search" runat="server" Text="Search"/></td>
                    </tr>
          <asp:Repeater ID="Repeater1" runat="server" OnItemCommand="Repeater1_ItemCommand" OnItemDataBound="Repeater1_ItemDataBound" >
              <ItemTemplate>
                   <tr>
                    <td>
              <asp:Label ID="lbl_sr" runat="server" Text='<%# Eval("sl_id") %>'></asp:Label></td>
                  <td>
              <asp:Label ID="lbl_invoice" runat="server" Text='<%# Eval("sl_invoice_no") %>'></asp:Label></td>
                  <td><asp:Label ID="lbl_date" runat="server" Text='<%# Eval("sl_date", "{0:dd/MM/yyyy}") %>'></asp:Label></td>
                <td><asp:Label ID="lbl_cust_name" runat="server" Text='<%# Eval("sl_customer_name") %>'></asp:Label></td>
                       <td><asp:Label ID="lbl_cust_contact" runat="server" Text='<%# Eval("sl_customer_contact") %>'></asp:Label></td>
                      
                     
                        <td><asp:Label ID="lbl_pending" runat="server" Text=''></asp:Label></td>
                       <td><asp:Label ID="lbl_total" runat="server" Text='<%# Eval("sl_total") %>'></asp:Label></td>
                  <asp:Panel ID="Panel1" runat="server">
                     
                        <td class="no-print" id="tbltextbox" runat="server">
                  <asp:LinkButton ID="LinkButton1" runat="server" OnClientClick="return confirm('Do you want to delete this Sale Invoice?');" OnClick="DeleteSale"><i  class="fa fa-trash-o"></i></asp:LinkButton>
                 <a href="bill.aspx?invoice=<%# Eval("sl_invoice_no") %>"><i style="padding-left:10px" class="fa fa-eye"></i></a>
                 <a href="edit_bill.aspx?invoice=<%# Eval("sl_invoice_no") %>"> <i style="padding-left:10px" class="fa fa-edit"></i></a>
                     
                  </td>
                      </asp:Panel>
                   </tr>
              </ItemTemplate>

          </asp:Repeater>
                      <asp:Label ID="Lbl_msg2" Style="color:red" runat="server" Text=""></asp:Label>
              
                </tbody>
                
              </table>
           </asp:Panel>


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

