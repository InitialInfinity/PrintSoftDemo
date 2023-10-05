<%@ Page Title="" Language="C#" MasterPageFile="~/Staff/Staff.master" AutoEventWireup="true" CodeFile="add_staff.aspx.cs" Inherits="Staff_add_staff" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
      
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
      <!-- Content Wrapper. Contains page content -->
  <div class="content-wrapper"> 
    <!-- Content Header (Page header) -->
    <section class="content-header sty-one">
      <h1>Add Staff</h1>
      <ol class="breadcrumb">
        <li><a href="#">Staff</a></li>
        <li><i class="fa fa-angle-right"></i> Add Staff</li>
      </ol>
    </section>
    <section class="content">
      <div class="row">
        <div class="col-lg-12">
          <div class="card">
            <div class="card-header bg-blue">
              <h5 class="m-b-0">Staff Entry Form</h5>
            </div>
            <div class="card-body">
              <div class="form-horizontal form-bordered">
                <div class="form-body">
                  <div class="form-group row">
                    <label class="control-label text-right col-md-3">Staff Name<span style="color:red;">*</span></label>
                    <div class="col-md-9">
                      
                      <asp:TextBox ID="Txt_staff_name" placeholder="Staff Name" class="form-control" runat="server"></asp:TextBox>
                      </div>
                  </div>
                   
                  <div class="form-group row">
                    <label class="control-label text-right col-md-3">Address<span style="color:red;">*</span></label>
                    <div class="col-md-9">
                     <asp:TextBox ID="Txt_address" class="form-control" placeholder="Address" runat="server" TextMode="MultiLine"></asp:TextBox>
                         </div>
                  </div>
                
                    <div class="form-group row">
                    <label class="control-label text-right col-md-3">Contact no.<span style="color:red;">*</span></label>
                    <div class="col-md-9">
                       <asp:TextBox ID="Txt_contact" placeholder="Contact no." class="form-control" runat="server" TextMode="Number"></asp:TextBox>
                      </div>
                  </div>
                    <div class="form-group row">
                    <label class="control-label text-right col-md-3">DOB<span style="color:red;">*</span></label>
                    <div class="col-md-9">
                      <asp:TextBox ID="Txt_dob"  class="form-control" runat="server" TextMode="Date"></asp:TextBox>
                         </div>
                  </div>
                    <div class="form-group row">
                    <label class="control-label text-right col-md-3">Gender<span style="color:red;">*</span></label>
                    <div class="col-md-9">
                      <asp:DropDownList ID="Dd_gender" class="form-control" runat="server">
                          <asp:ListItem Value="Male"></asp:ListItem>
                          <asp:ListItem Value="Female"></asp:ListItem>
                        </asp:DropDownList>
                          </div>
                  </div>
                 
                  <div class="form-group row">
                    <label class="control-label text-right col-md-3">Designation<span style="color:red;">*</span></label>
                    <div class="col-md-9">
                      <asp:TextBox ID="Txt_designation" placeholder="Designation" class="form-control" runat="server"></asp:TextBox>
                    </div>
                  </div>
                     <div class="form-group row">
                    <label class="control-label text-right col-md-3">Salary<span style="color:red;">*</span></label>
                    <div class="col-md-9">
                      <asp:TextBox ID="Txt_salary"  placeholder="Salary" class="form-control" runat="server" TextMode="Number"></asp:TextBox>
                    </div>
                  </div>
                      <div class="form-group row">
                    <label class="control-label text-right col-md-3">Balance<span style="color:red;">*</span></label>
                    <div class="col-md-9">
                      <asp:TextBox ID="Txt_balance"  placeholder="Balance" class="form-control" runat="server" TextMode="Number"></asp:TextBox>
                    </div>
                  </div>
                  <div class="form-group row">
                    <label class="control-label text-right col-md-3">Joining Date<span style="color:red;">*</span></label>
                    <div class="col-md-9">
                      <asp:TextBox ID="Txt_joining_date" class="form-control" runat="server" TextMode="Date"></asp:TextBox>
                    </div>
                  </div>
                  <div class="form-group row">
                    <label class="control-label text-right col-md-3">Left Date</label>
                    <div class="col-md-9">
                      <asp:TextBox ID="Txt_left_date" class="form-control" runat="server" TextMode="Date"></asp:TextBox>
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

                          <asp:Label ID="Lbl_message" Style="color:red" runat="server" Text=""></asp:Label>
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
    if(document.getElementById('<%=Txt_staff_name.ClientID%>').value.length==0)
{
alert("Please Enter Staff Member Name !!!");
return false;
    }
    if(document.getElementById('<%=Txt_address.ClientID%>').value.length==0)
{
alert("Please Enter Address !!!");
return false;
}

    if(document.getElementById('<%=Txt_contact.ClientID%>').value.length==0)
{
alert("Please Enter Contact Number !!!");
return false;
    }
     if (!(document.getElementById('<%=Txt_contact.ClientID%>').value.length == 10))
{
        alert("Please Enter 10 Digits Contact Number !!!");
return false;
    }
    if(document.getElementById('<%=Txt_dob.ClientID%>').value.length==0)
{
alert("Please Select Date of Birth !!!");
return false;
    }

    if(document.getElementById('<%=Txt_designation.ClientID%>').value.length==0)
{
alert("Please Enter Designation !!!");
return false;
    }
    if(document.getElementById('<%=Txt_salary.ClientID%>').value.length==0)
{
alert("Please Enter Salary !!!");
return false;
    }
    if(document.getElementById('<%=Txt_balance.ClientID%>').value.length==0)
{
alert("Please Enter Balance Amount !!!");
return false;
    }
    if(document.getElementById('<%=Txt_joining_date.ClientID%>').value.length==0)
{
alert("Please Select Joining Date !!!");
return false;
    }
    
return true;
}
        </script>
</asp:Content>

