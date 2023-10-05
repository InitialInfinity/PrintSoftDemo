<%@ Page Title="" Language="C#" MasterPageFile="~/Staff/Staff.master" AutoEventWireup="true" CodeFile="salary.aspx.cs" Inherits="Staff_salary" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
 
     
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
   
      <!-- Content Wrapper. Contains page content -->
  <div class="content-wrapper"> 
    <!-- Content Header (Page header) -->
    <section class="content-header sty-one">
      <h1>Salary</h1>
      <ol class="breadcrumb">
        <li><a href="#">Staff</a></li>
        <li><i class="fa fa-angle-right"></i> Salary</li>
      </ol>
    </section>
    <section class="content">
      <div class="row ">
        <div class="col-lg-12">
          <div class="card">
            <div class="card-header bg-blue">
              <h5 class="m-b-0">Salary Entry Form</h5>
            </div>
            <div class="card-body">
              <div class="form-horizontal form-bordered">
                <div class="form-body">
                  <div class="form-group row">
                    <label class="control-label text-right col-md-3">Staff Name<span style="color:red;">*</span></label>
                    <div class="col-md-9">
                      <asp:DropDownList ID="Dd_staff_name" class="form-control" runat="server" OnSelectedIndexChanged="Dd_staff_name_SelectedIndexChanged" AutoPostBack="True"></asp:DropDownList>
                      </div>
                  </div>
                   
                  <div class="form-group row">
                    <label class="control-label text-right col-md-3">Salary</label>
                    <div class="col-md-9">
                     <asp:TextBox ID="Txt_salary"  class="form-control" disabled="true" runat="server" TextMode="Number"></asp:TextBox>
                         </div>
                  </div>
                    <div class="form-group row">
                    <label class="control-label text-right col-md-3">Balance</label>
                    <div class="col-md-9">
                     <asp:TextBox ID="Txt_balance"  class="form-control" disabled="true" runat="server" TextMode="Number"></asp:TextBox>
                         </div>
                  </div>
                    <div class="form-group row">
                    <label class="control-label text-right col-md-3">Pay<span style="color:red;">*</span></label>
                    <div class="col-md-9">
                     <asp:TextBox ID="Txt_pay"  class="form-control" placeholder="Pay" runat="server" TextMode="Number"></asp:TextBox>
                         </div>
                  </div>
                    <div class="form-group row">
                    <label class="control-label text-right col-md-3">Deduction<span style="color:red;">*</span></label>
                    <div class="col-md-9">
                     <asp:TextBox ID="Txt_deduction"  class="form-control" placeholder="Deduction" runat="server" TextMode="Number"></asp:TextBox>
                         </div>
                  </div>
                    <div class="form-group row">
                    <label class="control-label text-right col-md-3">Salary Month<span style="color:red;">*</span></label>
                    <div class="col-md-9">
                     <asp:DropDownList ID="Dd_month" class="form-control" runat="server">
                         <asp:ListItem>January</asp:ListItem>
                         <asp:ListItem>February</asp:ListItem>
                         <asp:ListItem>March</asp:ListItem>
                         <asp:ListItem>April</asp:ListItem>
                         <asp:ListItem>May</asp:ListItem>
                         <asp:ListItem>June</asp:ListItem>
                         <asp:ListItem>July</asp:ListItem>
                         <asp:ListItem>August</asp:ListItem>
                         <asp:ListItem>September</asp:ListItem>
                         <asp:ListItem>October</asp:ListItem>
                         <asp:ListItem>November</asp:ListItem>
                         <asp:ListItem>December</asp:ListItem>
                        </asp:DropDownList>
                         </div>
                  </div>
                    <div class="form-group row">
                    <label class="control-label text-right col-md-3">Date<span style="color:red;">*</span></label>
                    <div class="col-md-9">
                      <asp:TextBox ID="Txt_date"  class="form-control" runat="server" TextMode="Date"></asp:TextBox>
                         </div>
                  </div>
                  <div class="form-group row">
                    <label class="control-label text-right col-md-3">Remark</label>
                    <div class="col-md-9">
                      <asp:TextBox ID="Txt_remark" class="form-control" runat="server" TextMode="MultiLine"></asp:TextBox>
                         </div>
                  </div>
                  
                  
                    
                </div>
                <div class="form-actions">
                  <div class="row">
                    <div class="col-md-12">
                      <div class="row">
                        <div class="offset-sm-3 col-md-9">
                          
                          <asp:Button ID="Btn_submit" class="btn btn-success" runat="server" Text="Submit" OnClientClick="return JSFunctionValidate();" OnClick="Btn_submit_Click" />
                          
                          <asp:Button ID="Btn_cencel" class="btn btn-inverse" runat="server" Text="Cancel" />

                          <asp:Label ID="Lbl_message" runat="server" Text=""></asp:Label>

                          <asp:HiddenField ID="hd_salary" runat="server" />
                          <asp:HiddenField ID="hd_balance" runat="server" />

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

      
    </section>
               
             
    
    </div>
  <!-- /.content-wrapper -->
  <footer class="main-footer">
    <div class="pull-right hidden-xs">Version 1.0</div>
    Copyright © 2018 PrintSoft. All rights reserved.</footer>

     
              
   <script>
function JSFunctionValidate()
{
if(document.getElementById('<%=Dd_staff_name.ClientID%>').selectedIndex == 0)
{
alert("Please Select Staff Member Name");
return false;
}
     if (document.getElementById('<%=Txt_pay.ClientID%>').value.length == 0)
{
        alert("Please Enter Pay !!!");
return false;
     }
    if (document.getElementById('<%=Txt_deduction.ClientID%>').value.length == 0)
{
        alert("Please Enter Deduction !!!");
return false;
     }
     if (document.getElementById('<%=Txt_date.ClientID%>').value.length == 0)
{
        alert("Please Select Date !!!");
return false;
}
return true;
}
        </script>
</asp:Content>

