<%@ Page Title="" Language="C#" MasterPageFile="~/Bank/Bank.master" AutoEventWireup="true" CodeFile="bank_operations.aspx.cs" Inherits="Bank_bank_operations" %>

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
    <script>
function JSFunctionValidate()
{
if(document.getElementById('<%=Txt_name.ClientID%>').value.length==0)
{
alert("Please Enter Name !!!");
return false;
}
    if (document.getElementById('<%=Txt_amount.ClientID%>').value.length == 0)
{
        alert("Please Enter Amount !!!");
return false;
}
    if (document.getElementById('<%=Dd_category.ClientID%>').value.length == 0)
{
        alert("Please Select Credit or Debit !!!");
return false;
    }
    
   

return true;
}
        </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
       <!-- Content Wrapper. Contains page content -->
  <div class="content-wrapper"> 
    <!-- Content Header (Page header) -->
    <section class="content-header sty-one">
      <h1>Bank Operations</h1>
      <ol class="breadcrumb">
        <li><a href="#">Bank Operations</a></li>
        <li><i class="fa fa-angle-right"></i> Add Bank Operations</li>
      </ol>
    </section>
      
    <section class="content">
      <div class="row m-t-3">
        <div class="col-lg-12">
          <div class="card">
            <div class="card-header bg-blue">
              <h5 class="m-b-0">Bank Operations Form</h5>
            </div>
            <div class="card-body">
              <div class="form-horizontal form-bordered">
                <div class="form-body">
                    <div class="form-group row">
                    <label class="control-label text-right col-md-3">Bank Name<span style="color:red;">*</span></label>
                     <div class="col-md-9">
                      
                       <asp:DropDownList ID="Dd_bank" class="form-control" runat="server" TabIndex="1">
                       </asp:DropDownList>
                      </div>
                  </div>
                    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
      <asp:UpdatePanel ID="UpdatePanel1" runat="server"><ContentTemplate>
                     <div class="form-group row">
                    <label class="control-label text-right col-md-3">Status<span style="color:red;">*</span></label>
                     <div class="col-md-9">
                      
                       <asp:DropDownList ID="Dd_category" class="form-control" runat="server"  OnSelectedIndexChanged="Dd_category_SelectedIndexChanged" AutoPostBack="True" TabIndex="2">
                           <asp:ListItem>Credit</asp:ListItem>
                           <asp:ListItem>Debit</asp:ListItem>
                       </asp:DropDownList>
                      </div>
                  </div>
                  <div class="form-group row">
                    <asp:Label ID="Label1" runat="server" class="control-label text-right col-md-3" Text="">Creditor Name<span style="color:red;">*</span></asp:Label>
                    <asp:Label ID="Label2" runat="server" class="control-label text-right col-md-3" Text="">Debitor Name<span style="color:red;">*</span></asp:Label>
                      
                    <div class="col-md-9">
                      
                      <asp:TextBox ID="Txt_name" placeholder="Name" class="form-control" runat="server" TabIndex="3"></asp:TextBox>
                      </div>
                  </div>
                   <div class="form-group row">
                    <asp:Label ID="Label3" runat="server" class="control-label text-right col-md-3" Text="">Credit Amount<span style="color:red;">*</span></asp:Label>
                    <asp:Label ID="Label4" runat="server" class="control-label text-right col-md-3" Text="">Debit Amount<span style="color:red;">*</span></asp:Label>

                    <div class="col-md-9">
                       <asp:TextBox ID="Txt_amount" placeholder="Amount" class="form-control" runat="server" TextMode="Number" TabIndex="4"></asp:TextBox>
                      </div>
                  </div>
                    </ContentTemplate></asp:UpdatePanel>

                  <div class="form-group row">
                    <label class="control-label text-right col-md-3">Remark</label>
                    <div class="col-md-9">
                             <asp:TextBox ID="Txt_remark" class="form-control" runat="server" TextMode="MultiLine" TabIndex="5"></asp:TextBox>
                      </div>
                  </div>
                 <div class="form-group row">
                    <label class="control-label text-right col-md-3">Browse File</label>
                    <div class="col-md-9">
                        <asp:FileUpload ID="FileUpload1" runat="server" TabIndex="6"/>
                      </div>
                  </div>
                  
                </div>
                <div class="form-actions">
                  <div class="row">
                    <div class="col-md-12">
                      <div class="row">
                        <div class="offset-sm-3 col-md-9">
                          
                          <asp:Button ID="Btn_submit" class="btn btn-success" runat="server" Text="Submit" OnClientClick="return JSFunctionValidate();" OnClick="Btn_submit_Click" TabIndex="7"/>
                          
                          <asp:Button ID="Btn_cencel" class="btn btn-inverse" runat="server" Text="Cancel" TabIndex="8"/>

                           <asp:Label ID="Lbl_message" runat="server" Text=""></asp:Label>
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

         <div class="card m-t-3">
      <div class="card-body">
      <h4 class="text-black">Bank Operations List</h4>
     
      <div class="table-responsive">
                  <table id="example1" class="table table-bordered table-striped">
                <thead>
                <tr>
                  <th>ID #</th>
                  <th>Date</th>
                    <th>Bank</th>
                  <th>Name</th>
                  <th>Amount</th>
                  <th>Status</th>
                  <th>Remark</th>
                  <th>Action</th>
                  
                </tr>
                </thead>
                <tbody>
                 <asp:Repeater ID="Repeater1" runat="server" OnItemCommand="Repeater1_ItemCommand"> 
      <ItemTemplate> 
          <tr>
                  <td>
              <asp:Label ID="lbl_id" runat="server" Text='<%# Eval("bo_id") %>'></asp:Label></td>
                  <td><asp:Label ID="lbl_date" runat="server" Text='<%# Eval("bo_date", "{0:dd/MM/yyyy}") %>'></asp:Label></td>
              <td><asp:Label ID="lbl_bank" runat="server" Text='<%# Eval("bo_bank") %>'></asp:Label></td>
                  <td><asp:Label ID="lbl_name" runat="server" Text='<%# Eval("bo_name") %>'></asp:Label></td>
                  <td><asp:Label ID="lbl_amount" runat="server" Text='<%# Eval("bo_amount") %>'></asp:Label></td>
                  <td><asp:Label ID="lbl_category" runat="server" Text='<%# Eval("bo_category") %>'></asp:Label></td>
                  <td><asp:Label ID="lbl_remark" runat="server" Text='<%# Eval("bo_remark") %>'></asp:Label></td>
                  <asp:Panel ID="Panel1" runat="server">
                     
                        <td class="no-print" id="tbltextbox" runat="server">
                  <asp:LinkButton ID="lb_Delete" runat="server" OnClientClick="return confirm('Do you want to delete this Bank Operation?');" OnClick="lb_Delete_Click"><i  class="fa fa-trash-o"></i></asp:LinkButton>
                  <asp:LinkButton ID="lb_download" runat="server" CommandArgument='<%# Eval("bo_file") %>' CommandName="download"><i  class="fa fa-download"></i></asp:LinkButton>
                     
                  </td>
                      </asp:Panel>
                </tr>
      </ItemTemplate>
     </asp:Repeater>
                
                </tbody>
               
              </table>
                  </div>
      </div></div>
 </section>
          
    </div>
  <!-- /.content-wrapper -->
  <footer class="main-footer">
    <div class="pull-right hidden-xs">Version 1.0</div>
    Copyright © 2018 PrintSoft. All rights reserved.</footer>
 
  

</asp:Content>

