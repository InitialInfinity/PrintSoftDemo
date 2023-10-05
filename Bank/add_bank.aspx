<%@ Page Title="" Language="C#" MasterPageFile="~/Bank/Bank.master" AutoEventWireup="true" CodeFile="add_bank.aspx.cs" Inherits="Bank_add_bank" %>

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
if(document.getElementById('<%=Txt_bank_name.ClientID%>').value.length==0)
{
alert("Please Enter Bank Name !!!");
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
      <h1>Add Bank</h1>
      <ol class="breadcrumb">
        <li><a href="#">Bank</a></li>
        <li><i class="fa fa-angle-right"></i> Add Bank</li>
      </ol>
    </section>
      
    <section class="content">
      <div class="row m-t-3">
        <div class="col-lg-12">
          <div class="card">
            <div class="card-header bg-blue">
              <h5 class="m-b-0">Bank Entry Form</h5>
            </div>
            <div class="card-body">
              <div class="form-horizontal form-bordered">
                <div class="form-body">
                  <div class="form-group row">
                    <label class="control-label text-right col-md-3">Bank Name / Patasanstha Name<span style="color:red;">*</span></label>
                    <div class="col-md-9">
                      
                      <asp:TextBox ID="Txt_bank_name" placeholder="Bank Name" class="form-control" runat="server" TabIndex="1"></asp:TextBox>
                      </div>
                  </div>
                   <div class="form-group row">
                    <label class="control-label text-right col-md-3">Account Name<span style="color:red;"></span></label>
                    <div class="col-md-9">
                       <asp:TextBox ID="Txt_account_name" placeholder="Account Name" class="form-control" runat="server" TabIndex="2"></asp:TextBox>
                      </div>
                  </div>
                     <div class="form-group row">
                    <label class="control-label text-right col-md-3">IFSC Code<span style="color:red;"></span></label>
                    <div class="col-md-9">
                       <asp:TextBox ID="Txt_ifsc" placeholder="IFSC Code" class="form-control" runat="server" TabIndex="3"></asp:TextBox>
                      </div>
                  </div>

                  <div class="form-group row">
                    <label class="control-label text-right col-md-3">Account no.<span style="color:red;"></span></label>
                    <div class="col-md-9">
                      <asp:TextBox ID="Txt_account_no" placeholder="Account no." class="form-control" runat="server" TextMode="Number" TabIndex="4"></asp:TextBox>
                    </div>
                  </div>
                 <div class="form-group row">
                    <label class="control-label text-right col-md-3">Opening Balance<span style="color:red;"></span></label>
                    <div class="col-md-9">
                      <asp:TextBox ID="Txt_opening_balance" placeholder="Opening Balance" class="form-control" runat="server" TextMode="Number" TabIndex="5"></asp:TextBox>
                    </div>
                  </div>
                  <div class="form-group row">
                    <label class="control-label text-right col-md-3">Description</label>
                    <div class="col-md-9">
                             <asp:TextBox ID="Txt_description" class="form-control" runat="server" TextMode="MultiLine" TabIndex="6"></asp:TextBox>
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
      <h4 class="text-black">Bank List</h4>
     
      <div class="table-responsive">
                  <table id="example1" class="table table-bordered table-striped">
                <thead>
                <tr>
                  <th>Bank Name</th>
                  <th>A/C Name</th>
                  <th>IFSC</th>
                  <th>A/C no. </th>
                  <th>Balance</th>
                  <th>Description</th>
                  
                </tr>
                </thead>
                <tbody>
                 <asp:Repeater ID="Repeater1" runat="server"> 
      <ItemTemplate> 
          <tr>
                  <td>
              <asp:Label ID="lbl_bank_name" runat="server" Text='<%# Eval("b_name") %>'></asp:Label></td>
                  <td><asp:Label ID="lbl_ac_name" runat="server" Text='<%# Eval("b_ac_name") %>'></asp:Label></td>
                  <td><asp:Label ID="lbl_ifsc" runat="server" Text='<%# Eval("b_ifsc") %>'></asp:Label></td>
                  <td><asp:Label ID="lbl_ac_no" runat="server" Text='<%# Eval("b_ac_no") %>'></asp:Label></td>
                  <td><asp:Label ID="lbl_balance" runat="server" Text='<%# Eval("b_opening_balance") %>'></asp:Label></td>
                  <td><asp:Label ID="lbl_desc" runat="server" Text='<%# Eval("b_desc") %>'></asp:Label></td>
                  
                  
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

