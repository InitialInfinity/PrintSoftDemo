<%@ Page Title="" Language="C#" MasterPageFile="~/Bank/Bank.master" AutoEventWireup="true" CodeFile="list_of_bank.aspx.cs" Inherits="Bank_list_of_bank" %>

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
    <!-- DataTables -->
<link rel="stylesheet" href="../dist/plugins/datatables/css/dataTables.bootstrap.min.css"/>
     <script type="text/javascript">
    window.setTimeout(function() {
    $(".alert").fadeTo(500, 0).slideUp(500, function(){
        $(this).remove(); 
    });
}, 4000);
</script>
     <script>
function JSFunctionValidate()
{
if(document.getElementById('<%=Txt_name.ClientID%>').value.length==0)
{
alert("Please Enter Bank Name !!!");
return false;
}
    if (document.getElementById('<%=Txt_ac_name.ClientID%>').value.length == 0)
{
        alert("Please Enter Account Name !!!");
return false;
}
    if (document.getElementById('<%=Txt_ifsc.ClientID%>').value.length == 0)
{
        alert("Please Enter IFSC Code !!!");
return false;
    }
    
    if (document.getElementById('<%=Txt_ac_no.ClientID%>').value.length == 0)
{
        alert("Please Enter Account Number !!!");
return false;
    }
   
    if (document.getElementById('<%=Txt_opening_balance.ClientID%>').value.length == 0)
{
        alert("Please Enter Opening Balance !!!");
return false;
    }
   

return true;
}
        </script>
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
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
     <!-- Content Wrapper. Contains page content -->
  <div class="content-wrapper"> 
    <!-- Content Header (Page header) -->
    <section class="content-header sty-one">
      <h1>List of Bank</h1>
      <ol class="breadcrumb">
        <li><a href="#">Master</a></li>
        <li><i class="fa fa-angle-right"></i> List of Bank</li>
      </ol>
    </section>
     <section class="content">
           <asp:Panel ID="Panel2" runat="server">
              <div class="alert alert-success" role="alert">
  <button type="button" class="close" data-dismiss="alert" aria-label="Close"><span aria-hidden="true">&times;</span></button>
  <strong>Success!</strong> New Bank successfully added!
</div>     
        </asp:Panel>
         <asp:Panel ID="Panel3" runat="server">
              <div class="alert alert-success" role="alert">
  <button type="button" class="close" data-dismiss="alert" aria-label="Close"><span aria-hidden="true">&times;</span></button>
  <strong>Success!</strong> Bank successfully updated!
</div>     
        </asp:Panel>
        
        <div class="card m-t-3">
      <div class="card-body">
        <div class="row">
        <div class="col-md-3">
         <h4 class="text-black">List of Bank</h4>
        </div>
        
             <div class="col-md-9 exportbtn">
           <a href="add_bank.aspx"><button type="button" id="btn_mail"  title="Add New Bank" class="btn btnsqr btn-primary4 btngap"> <i class="fa fa-plus"></i>Add New Bank</button></a>
          <button type="button" id="btn_excel" title="Export to Excel" runat="server" class="btn btnsqr btn-primary3 btngap" onserverclick="excel_export"> <i class="fa fa-file-excel-o"></i> Excel</button>
           
        <button type="button" id="btn_print" title="Print" onclick="printdiv('dropHere');" class="btn btnsqr btn-primary btngap"> <i class="fa fa-print"></i> Print</button>
         <button type="button" id="btn_pdf" title="Export to PDF" runat="server"  class="btn btnsqr btn-primary2" onserverclick="pdf_export"> <i class="fa fa-file-pdf-o"></i> PDF</button>
       
        
      </div>
      </div><br/>
      <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
      <div id="dropHere" class="table-responsive">
                    <table id="example1" class="table table-bordered table-striped table-hover">
                <thead>
                <tr>
                  <th>Sr.No.</th>
                  <th>Bank Name</th>
                  <th>Account Name</th>
                  <th>IFC Code</th>
                  <th>Account no.</th>
                  <th>Balance</th>
                  <th>Description</th>
                  <th class="no-print">Actions</th>
                </tr>
                </thead>
                <tbody>
                 <asp:Repeater ID="Repeater1" runat="server" OnItemCommand="Repeater1_ItemCommand"> 
      <ItemTemplate> 
          <tr>
              <td>
              <asp:Label ID="lbl_id" runat="server" Text='<%# Eval("b_id") %>'></asp:Label></td>
                  <td>
              <asp:Label ID="lbl_bank_name" runat="server" Text='<%# Eval("b_name") %>'></asp:Label></td>
                  <td><asp:Label ID="lbl_ac_name" runat="server" Text='<%# Eval("b_ac_name") %>'></asp:Label></td>
                  <td><asp:Label ID="lbl_ifsc" runat="server" Text='<%# Eval("b_ifsc") %>'></asp:Label></td>
                  <td><asp:Label ID="lbl_ac_no" runat="server" Text='<%# Eval("b_ac_no") %>'></asp:Label></td>
                  <td><asp:Label ID="lbl_balance" runat="server" Text='<%# Eval("b_opening_balance") %>'></asp:Label></td>
                  <td><asp:Label ID="lbl_desc" runat="server" Text='<%# Eval("b_desc") %>'></asp:Label></td>
                  <td class="no-print"><asp:LinkButton ID="LinkButton1" runat="server" OnClientClick="return confirm('Do you want to delete this Bank?');" OnClick="DeleteBank"><i  class="fa fa-trash-o"></i></asp:LinkButton>
                  <asp:LinkButton ID="LinkButton2" runat="server" CommandName="showid" CommandArgument='<%# Eval("b_id") %>'><i style="padding-left:10px" class="fa fa-eye"></i></i></asp:LinkButton>
                  <asp:LinkButton ID="LinkButton3" runat="server" CommandName="editid" CommandArgument='<%# Eval("b_id") %>' ><i style="padding-left:10px" class="fa fa-edit"></i></asp:LinkButton>
                      <!--<a href=""></a><a href=""><i style="padding-left:10px" class="fa fa-edit"></i></a><a href="" runat="server" ><i style="padding-left:10px" class="fa fa-trash-o"></i></a>-->
                 </td>
                  
                </tr>
      </ItemTemplate>
     </asp:Repeater>
                
                </tbody>
                
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
            <h4 class="modal-title"><asp:Label ID="lbl_name" runat="server" Text=""></asp:Label></h4>
          <button type="button" class="close" data-dismiss="modal">&times;</button>
          
        </div>
        <div class="modal-body">
          <table class="table table-hover">
  
  <tbody>
    <tr>
      <th scope="col">A/C Name</th>
      <td><asp:Label ID="lbl_ac_name" runat="server" Text=""></asp:Label></td>
     
    </tr>
       <tr>
      <th scope="col">IFSC Code</th>
      <td><asp:Label ID="lbl_ifsc" runat="server" Text=""></asp:Label></td>
     
    </tr>
       <tr>
      <th scope="col">A/C no</th>
      <td><asp:Label ID="lbl_ac_no" runat="server" Text=""></asp:Label></td>
     
    </tr>
       <tr>
      <th scope="col">Opening Balance</th>
      <td><asp:Label ID="lbl_balance" runat="server" Text=""></asp:Label></td>
     
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
      <th scope="col">Bank Name<span style="color:red;">*</span></th>
      <td>
          <asp:TextBox ID="Txt_name" CssClass="form-control" runat="server"></asp:TextBox></td>
     
    </tr>
    <tr>
      <th scope="col">A/C Name<span style="color:red;">*</span></th>
      <td><asp:TextBox ID="Txt_ac_name" CssClass="form-control" runat="server"></asp:TextBox></td>
     
    </tr>
       <tr>
      <th scope="col">IFSC Code<span style="color:red;">*</span></th>
      <td><asp:TextBox ID="Txt_ifsc" CssClass="form-control" runat="server"></asp:TextBox></td>
     
    </tr>
       <tr>
      <th scope="col">A/C no<span style="color:red;">*</span></th>
      <td><asp:TextBox ID="Txt_ac_no" CssClass="form-control" runat="server"></asp:TextBox></td>
     
    </tr>
       <tr>
      <th scope="col">Opening Balance<span style="color:red;">*</span></th>
      <td><asp:TextBox ID="Txt_opening_balance" CssClass="form-control" runat="server"></asp:TextBox></td>
     
    </tr>
       <tr>
      <th scope="col">Description</th>
      <td><asp:TextBox ID="Txt_desc" CssClass="form-control" runat="server"></asp:TextBox></td>
     
    </tr>
    
     
  
  </tbody>
</table>
        </div>
        <div class="modal-footer">
             <asp:Button ID="Btn_submit" class="btn btn-success" runat="server" Text="Update" OnClientClick="return JSFunctionValidate();" OnClick="Btn_submit_Click"  />
          <button type="button" class="btn btn-default" data-dismiss="modal">Close</button>
        </div>
      </div>
      
    </div>
  </div>
    
</asp:Content>

