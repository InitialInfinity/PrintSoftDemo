﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Reports/Reports.master" AutoEventWireup="true" CodeFile="expense_datewise.aspx.cs" Inherits="Reports_expense_datewise" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
   
      
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
       <!-- Content Wrapper. Contains page content -->
  <div class="content-wrapper"> 
    <!-- Content Header (Page header) -->
    <section class="content-header sty-one">
      <h1>Expense Report - Date wise</h1>
      <ol class="breadcrumb">
        <li><a href="#">Reports</a></li>
        <li><i class="fa fa-angle-right"></i>Expense Report - Date wise</li>
      </ol>
    </section>
  <section class="content">
        <div class="row">
            <div class="col-lg-4">
          <div class="tile-progress tile-pink">
            <div class="tile-header">
              
              <h3>₹ <asp:Label ID="lbl_total_expense" runat="server" Text=""></asp:Label></h3>
            </div>
           
            <div class="tile-footer">
              <h6>Total Expense</h6>
            </div>
          </div>
        </div>
           

 </div>
      <!-- /.row -->
        
        <div class="card">
      <div class="card-body">
       <div class="row">
        <div class="col-md-3">
         <h4 class="text-black">Expense Report</h4>
        </div>
        
             <div class="col-md-9 exportbtn">
          
        <button type="button" id="btn_print" title="Print" onclick="checkDataAndPrint();" class="btn btnsqr btn-primary"> <i class="fa fa-print"></i> Print</button>
       
      </div>
      </div>
     <br/>
      <div class="row no-print" style="background-color:#dee2e6; height:52px">
          <div class="col-md-3 padding_3" style="margin-top:8px;" >
           <asp:DropDownList ID="Dd_category2" class="form-control" runat="server"></asp:DropDownList>
          </div>
           <div class="col-md-1 padding_10 d-flex align-items-center justify-content-end">
              <b><asp:Label ID="Label2"  runat="server" Text="From"></asp:Label></b>
          </div>
          <div class="col-md-3 padding_3" style="margin-top:8px;">
            <asp:TextBox ID="Txt_date1" class="form-control" runat="server" TextMode="Date"></asp:TextBox>
          </div>
           <div class="col-md-1 padding_10 d-flex align-items-center justify-content-end">
              <b><asp:Label ID="Label1"  runat="server" Text="To"></asp:Label></b>
          </div>
           <div class="col-md-3 padding_3" style="margin-top:8px;">
            <asp:TextBox ID="Txt_date2" class="form-control" runat="server" TextMode="Date"></asp:TextBox>
          </div>
          <div class="col-md-1" style="margin-top:5px;">
          <asp:Button ID="Btn_search" class="btn btn-success" runat="server" Text="Search" OnClick="Btn_search_Click"/>
          </div>

      </div>
          <br/>
           <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
      <div id="dropHere" class="table-responsive">
               <table id="example1" class="table table-bordered table-striped">
                <thead>
                <tr>
                  <th>ID #</th>
                    <th>Date</th>
                  <th>Category</th>
                  <th>User</th>
                  <th>Amount</th>
                  <th>Machine Counter</th>
                  <th class="no-print">Actions</th>
                </tr>
                </thead>
                <tbody>

          <asp:Repeater ID="Repeater1" runat="server" OnItemCommand="Repeater1_ItemCommand">
              <ItemTemplate>
                   <tr>
                    <td>
              <asp:Label ID="lbl_sr" runat="server" Text='<%# Eval("e_id") %>'></asp:Label></td>
                  
                      <td><asp:Label ID="lbl_da" runat="server" Text='<%# Eval("e_date","{0:dd/MM/yyyy}") %>'></asp:Label></td>
              <td><asp:Label ID="lbl_cat" runat="server" Text='<%# Eval("e_category_name") %>'></asp:Label></td>
                  <td><asp:Label ID="lbl_use" runat="server" Text='<%# Eval("e_user_name") %>'></asp:Label></td>
                  <td><asp:Label ID="lbl_amt" runat="server" Text='<%# Eval("e_amount") %>'></asp:Label></td>
                    <td><asp:Label ID="lbl_count" runat="server" Text='<%# Eval("e_count") %>'></asp:Label></td>
                 
                  <td class="no-print">
                  <asp:LinkButton ID="LinkButton1" runat="server" style="display:none" OnClientClick="return confirm('Do you want to delete this Expense Invoice?');" OnClick="DeleteSale"><i  class="fa fa-trash-o"></i></asp:LinkButton>
                 <asp:LinkButton ID="LinkButton2" runat="server"  CommandName="showid" CommandArgument='<%# Eval("e_id") %>'><i style="padding-left:10px" class="fa fa-eye"></i></asp:LinkButton>
                  <asp:LinkButton ID="LinkButton3" runat="server" style="display:none" CommandName="editid" CommandArgument='<%# Eval("e_id") %>'><i style="padding-left:10px" class="fa fa-edit"></i></asp:LinkButton>
                     
                  </td>

                   </tr>
              </ItemTemplate>

          </asp:Repeater>

              
                </tbody>

                    <tfoot>
                  <tr>
                  <th></th>
                  <th></th>
                  <th></th>
                
                  
                      <asp:Panel ID="Panel1" runat="server">
                  <th >Total :</th>
                          
                   <th>   <asp:Label ID="lbl_Total" runat="server" ></asp:Label> </th>
                  </asp:Panel>
                  
                  
                   
                  <td class="no-print"></td>
                </tr>
              </tfoot>
                
              </table>


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
    <!-- Modal -->
  <div class="modal fade" id="myModal" role="dialog">
    <div class="modal-dialog">
    
      <!-- Modal content-->
      <div class="modal-content">
        <div class="modal-header">
            <h4 class="modal-title">Details</h4>
          <button type="button" class="close" data-dismiss="modal">&times;</button>
          
        </div>
        <div class="modal-body">
          <table class="table table-hover">
  
  <tbody>
      <tr>
      <th scope="col">Date</th>
      <td><asp:Label ID="lbl_date" runat="server" Text=""></asp:Label></td>
     
    </tr>
      <tr>
      <th scope="col">Category</th>
      <td><asp:Label ID="lbl_category" runat="server" Text=""></asp:Label></td>
     
    </tr>
    <tr>
      <th scope="col">User</th>
      <td><asp:Label ID="lbl_user" runat="server" Text=""></asp:Label></td>
     
    </tr>
       <tr>
      <th scope="col">Amount</th>
      <td><asp:Label ID="lbl_amount" runat="server" Text=""></asp:Label></td>
     
    </tr>
      <tr>
      <th scope="col">Description</th>
      <td><asp:Label ID="lbl_desc" runat="server" Text=""></asp:Label></td>
     
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
          <table class="table table-hover">
  
  <tbody>
      <tr>
      <th scope="col">Date</th>
      <td><asp:TextBox ID="Txt_date"  class="form-control" runat="server" TextMode="Date"></asp:TextBox></td>
     
    </tr>
    <tr>
      <th scope="col">Category</th>
      <td><asp:DropDownList ID="Dd_category" class="form-control" runat="server">
                 
                         </asp:DropDownList></td>
     
    </tr>
       <tr>
      <th scope="col">User</th>
      <td><asp:dropdownlist ID="Dd_user" class="form-control" runat="server">
                        

                        </asp:dropdownlist></td>
     
    </tr>
   
       <tr>
      <th scope="col">Amount</th>
      <td><asp:TextBox ID="Txt_amount" class="form-control" runat="server"></asp:TextBox></td>
     
    </tr>
       <tr>
      <th scope="col">Description</th>
      <td><asp:TextBox ID="Txt_desc" class="form-control" TextMode="MultiLine" runat="server"></asp:TextBox></td>
     
    </tr>
  
  </tbody>
</table>
        </div>
        <div class="modal-footer">
             <asp:Label ID="lbl_msg" runat="server" Text=""></asp:Label>
             <asp:Button ID="Button1" class="btn btn-success" runat="server" Text="Update" OnClick="Button1_Click" />
          <button type="button" class="btn btn-default" data-dismiss="modal">Close</button>
        </div>
      </div>
      
    </div>
  </div>


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

     <script type="text/javascript">
         function checkDataAndPrint() {
             // Get the grid element
             var table = document.getElementById('example1');

             // Check if there are any rows in the table (excluding the header row)
             if (table.rows.length > 3) {
                 printdiv('dropHere');
             } else {
                 alert("No data to print");
             }
         }
     </script>

</asp:Content>

