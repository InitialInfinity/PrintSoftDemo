<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.master" AutoEventWireup="true" CodeFile="change_password.aspx.cs" Inherits="Admin_change_password" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <!-- Content Wrapper. Contains page content -->
    <div class="content-wrapper">
        <!-- Content Header (Page header) -->
        <section class="content-header sty-one">
            <h1>Admin Section</h1>
            <%--<ol class="breadcrumb">
        <li><a href="admin_logout.aspx" style="    font-size: 16px; color:red;"><i class="fa fa-power-off"></i>Log-out</a></li>
       
      </ol>--%>
        </section>

        <section class="content">
            <asp:Panel ID="Panel2" runat="server">
                <div class="alert alert-success" role="alert">
                    <button type="button" class="close" data-dismiss="alert" aria-label="Close"><span aria-hidden="true">&times;</span></button>
                    <strong>Success!</strong> New User successfully added!
                </div>
            </asp:Panel>
            <asp:Panel ID="Panel3" runat="server">
                <div class="alert alert-success" role="alert">
                    <button type="button" class="close" data-dismiss="alert" aria-label="Close"><span aria-hidden="true">&times;</span></button>
                    <strong>Success!</strong> Password successfully updated!
                </div>
            </asp:Panel>
            <asp:Panel ID="Panel4" runat="server">
                <div class="alert alert-success" role="alert">
                    <button type="button" class="close" data-dismiss="alert" aria-label="Close"><span aria-hidden="true">&times;</span></button>
                    <strong>Success!</strong> New Role successfully added!
                </div>
            </asp:Panel>
            <asp:Panel ID="Panel5" runat="server">
                <div class="alert alert-success" role="alert">
                    <button type="button" class="close" data-dismiss="alert" aria-label="Close"><span aria-hidden="true">&times;</span></button>
                    <strong>Success!</strong> User successfully updated!
                </div>
            </asp:Panel>
            <div class="row m-b-3">

                <div class="col-md-12">
                    <div class="card">

                        <!-- Nav tabs -->
                        <ul class="nav nav-tabs customtab" role="tablist">
                            <li class="nav-item"><a class="nav-link active" data-toggle="tab" href="#profile2" role="tab" id="adduser"><span class="hidden-sm-up"></span><span class="hidden-xs-down">Add User</span></a> </li>
                            <li class="nav-item"><a class="nav-link" data-toggle="tab" href="#home2" role="tab" id="changepass"><span class="hidden-sm-up"></span><span class="hidden-xs-down">Change Password</span></a> </li>
                            <li class="nav-item"><a class="nav-link" data-toggle="tab" href="#profile3" role="tab" id="anrole"><span class="hidden-sm-up"></span><span class="hidden-xs-down">Add Role</span></a> </li>
                        </ul>
                        <!-- Tab panes -->
                        <div class="tab-content">

                            <div class="tab-pane" id="home2" role="tabpanel">
                                <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
                                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                    <ContentTemplate>
                                        <div class="pad-20">
                                            <div class="card-body">
                                                <div class="form-horizontal form-bordered">
                                                    <div class="form-body">
                                                        <div class="form-group row">
                                                            <label class="control-label text-right col-md-3">Old Password<span style="color: red;">*</span></label>
                                                            <div class="col-md-9">

                                                                <asp:TextBox ID="Txt_old_password" placeholder="Old Password" class="form-control" runat="server" TextMode="Password"></asp:TextBox>
                                                            </div>
                                                        </div>
                                                        <div class="form-group row">
                                                            <label class="control-label text-right col-md-3">New Password<span style="color: red;">*</span></label>
                                                            <div class="col-md-9">
                                                                <asp:TextBox ID="Txt_new_password" placeholder="New Password" class="form-control" runat="server" TextMode="Password"></asp:TextBox>
                                                            </div>
                                                        </div>
                                                        <div class="form-group row">
                                                            <label class="control-label text-right col-md-3">Confirm Password<span style="color: red;">*</span></label>
                                                            <div class="col-md-9">
                                                                <asp:TextBox ID="Txt_confirm_password" placeholder="Confirm Password" class="form-control" runat="server" TextMode="Password"></asp:TextBox>
                                                            </div>
                                                        </div>



                                                    </div>
                                                    <div class="form-actions">
                                                        <div class="row">
                                                            <div class="col-md-12">
                                                                <div class="row">
                                                                    <div class="offset-sm-3 col-md-9">

                                                                        <asp:Button ID="Btn_submit" class="btn btn-success" OnClientClick="return PassJSFunctionValidate();" runat="server" Text="Submit" OnClick="Btn_submit_Click" />

                                                                        <asp:Button ID="Btn_cencel" class="btn btn-inverse" runat="server" Text="Cancel" />

                                                                        <asp:Label ID="Lbl_message" Style="color: red" runat="server" Text=""></asp:Label>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>




                                        </div>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </div>


                            <div class="tab-pane active p-20" id="profile2" role="tabpanel">
                                <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                    <ContentTemplate>
                                        <div class="pad-20">
                                            <div class="card-body">
                                                <div class="form-horizontal form-bordered">
                                                    <div class="form-body">
                                                        <div class="form-group row">
                                                            <label class="control-label text-right col-md-3">Role<span style="color: red;">*</span></label>
                                                            <div class="col-md-9">
                                                                <asp:DropDownList ID="Dd_role" class="form-control" runat="server"></asp:DropDownList>
                                                            </div>
                                                        </div>

                                                        <div class="form-group row">
                                                            <label class="control-label text-right col-md-3">Full Name<span style="color: red;">*</span></label>
                                                            <div class="col-md-9">
                                                                <asp:TextBox ID="Txt_full_name" placeholder="Full Name" class="form-control" runat="server"></asp:TextBox>
                                                            </div>
                                                        </div>
                                                        <div class="form-group row">
                                                            <label class="control-label text-right col-md-3">Email<span style="color: red;">*</span></label>
                                                            <div class="col-md-9">
                                                                <asp:TextBox ID="Txt_email" placeholder="Email" class="form-control" runat="server" TextMode="SingleLine"></asp:TextBox>
                                                            </div>
                                                        </div>
                                                        <div class="form-group row">
                                                            <label class="control-label text-right col-md-3">Password<span style="color: red;">*</span></label>
                                                            <div class="col-md-9">
                                                                <asp:TextBox ID="Txt_password" placeholder="Password" class="form-control" runat="server" TextMode="Password"></asp:TextBox>
                                                            </div>
                                                        </div>


                                                    </div>
                                                    <div class="form-actions">
                                                        <div class="row">
                                                            <div class="col-md-12">
                                                                <div class="row">
                                                                    <div class="offset-sm-3 col-md-9">

                                                                        <asp:Button ID="Button1" class="btn btn-success" runat="server" Text="Submit" OnClientClick="return JSFunctionValidate();" OnClick="Button1_Click" />

                                                                        <asp:Button ID="Button2" class="btn btn-inverse" runat="server" Text="Cancel" onclick="Button2_Click"/>

                                                                        <asp:Label ID="Lbl_message2" Style="color: red" runat="server" Text=""></asp:Label>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>


                                            <div class="card-body">
                                                <hr />

                                                <div class="table-responsive">
                                                    <table id="example1" class="table table-bordered table-striped">
                                                        <thead>
                                                            <tr>
                                                                <th>Sr.No.</th>
                                                                <th>Role</th>
                                                                <th>Name</th>
                                                                <th>Email</th>
                                                                <th>Action</th>

                                                            </tr>
                                                        </thead>
                                                        <tbody>


                                                            <asp:Repeater ID="Repeater3" runat="server" OnItemCommand="Repeater3_ItemCommand">
                                                                <ItemTemplate>
                                                                    <tr>
                                                                        <td>
                                                                            <asp:Label ID="lbl_id" runat="server" Text='<%# Eval("au_id") %>'></asp:Label></td>
                                                                        <td>
                                                                            <asp:Label ID="lbl_category_name" runat="server" Text='<%# Eval("au_role") %>'></asp:Label></td>
                                                                        <td>
                                                                            <asp:Label ID="lbl_date" runat="server" Text='<%# Eval("au_name") %>'></asp:Label></td>
                                                                        <td>
                                                                            <asp:Label ID="Label1" runat="server" Text='<%# Eval("au_email") %>'></asp:Label></td>
                                                                        <td>
                                                                            <asp:LinkButton ID="LinkButton1" runat="server" OnClientClick="return confirm('Do you want to delete this User?');" OnClick="DeleteUser"><i  class="fa fa-trash-o"></i></asp:LinkButton>
                                                                            <asp:LinkButton ID="LinkButton2" runat="server" CommandName="showid" CommandArgument='<%# Eval("au_id") %>'><i style="padding-left:10px" class="fa fa-eye"></i></i></asp:LinkButton>
                                                                            <asp:LinkButton ID="LinkButton3" runat="server" CommandName="editid" CommandArgument='<%# Eval("au_id") %>'><i style="padding-left:10px" class="fa fa-edit"></i></asp:LinkButton>
                                                                        </td>


                                                                    </tr>
                                                                </ItemTemplate>
                                                            </asp:Repeater>



                                                        </tbody>

                                                    </table>
                                                </div>
                                            </div>


                                        </div>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </div>


                            <div class="tab-pane p-20" id="profile3" role="tabpanel">
                                <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                                    <ContentTemplate>
                                        <div class="pad-20">
                                            <div class="card-body">
                                                <div class="form-horizontal form-bordered">
                                                    <div class="form-body">
                                                        <div class="form-group row">
                                                            <label class="control-label text-right col-md-3">Role Name<span style="color: red;">*</span></label>
                                                            <div class="col-md-9">

                                                                <asp:TextBox ID="Txt_role_name" placeholder="Role Name" class="form-control" runat="server"></asp:TextBox>
                                                            </div>
                                                        </div>

                                                        <div class="form-group row">
                                                            <label class="control-label text-right col-md-3">Date<span style="color: red;">*</span></label>
                                                            <div class="col-md-4">
                                                                <asp:TextBox ID="Txt_date" class="form-control" runat="server" TextMode="Date"></asp:TextBox>
                                                            </div>
                                                        </div>



                                                    </div>
                                                    <div class="form-actions">
                                                        <div class="row">
                                                            <div class="col-md-12">
                                                                <div class="row">
                                                                    <div class="offset-sm-3 col-md-9">

                                                                        <asp:Button ID="Button3" class="btn btn-success" runat="server" Text="Submit" OnClientClick="return RoleJSFunctionValidate();" OnClick="Button3_Click" />

                                                                        <asp:Button ID="Button4" class="btn btn-inverse" runat="server" Text="Cancel" />

                                                                        <asp:Label ID="Lbl_message1" Style="color: red" runat="server"></asp:Label>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>


                                            <div class="card-body">
                                                <hr />

                                                <div class="table-responsive">
                                                    <table id="example2" class="table table-bordered table-striped">
                                                        <thead>
                                                            <tr>
                                                                <th>Sr.No.</th>
                                                                <th>Role</th>
                                                                <th>Date</th>
                                                                <th>Action</th>

                                                            </tr>
                                                        </thead>
                                                        <tbody>


                                                            <asp:Repeater ID="Repeater1" runat="server">
                                                                <ItemTemplate>
                                                                    <tr>
                                                                        <td>
                                                                            <asp:Label ID="lbl_id" runat="server" Text='<%# Eval("ar_id") %>'></asp:Label></td>
                                                                        <td>
                                                                            <asp:Label ID="lbl_category_name" runat="server" Text='<%# Eval("ar_name") %>'></asp:Label></td>
                                                                        <td>
                                                                            <asp:Label ID="lbl_date" runat="server" Text='<%# Eval("ar_date","{0:MM/dd/yyyy}") %>'></asp:Label></td>
                                                                        <td>
                                                                            <asp:LinkButton ID="LinkButton1" runat="server" OnClientClick="return confirm('Do you want to delete this Role?');" OnClick="DeleteRole"><i style="padding-left:10px" class="fa fa-trash-o"></i></asp:LinkButton></td>

                                                                    </tr>
                                                                </ItemTemplate>
                                                            </asp:Repeater>



                                                        </tbody>

                                                    </table>
                                                </div>
                                            </div>


                                        </div>
                                    </ContentTemplate>
                                </asp:UpdatePanel>

                            </div>

                        </div>
                    </div>
                </div>
            </div>
            <!-- row -->


            <!-- Main row -->
        </section>
    </div>
    <!-- /.content-wrapper -->
    <footer class="main-footer">
        <div class="pull-right hidden-xs">Version 1.0</div>
        Copyright © 2018 PrintSoft. All rights reserved.
    </footer>

    <!-- Modal -->
    <div class="modal fade" id="myModal" role="dialog">
        <div class="modal-dialog">

            <!-- Modal content-->
            <div class="modal-content">
                <div class="modal-header">
                    <h4 class="modal-title">
                        <asp:Label ID="lbl_user" runat="server" Text=""></asp:Label></h4>
                    <button type="button" class="close" data-dismiss="modal">&times;</button>

                </div>
                <div class="modal-body">
                    <table class="table table-hover">

                        <tbody>
                            <tr>
                                <th scope="col">Role</th>
                                <td>
                                    <asp:Label ID="lbl_role" runat="server" Text=""></asp:Label></td>

                            </tr>
                            <tr>
                                <th scope="col">Email</th>
                                <td>
                                    <asp:Label ID="lbl_email" runat="server" Text=""></asp:Label></td>

                            </tr>
                            <tr>
                                <th scope="col">Password</th>
                                <td>
                                    <asp:Label ID="lbl_password" type="password" runat="server" Text=""></asp:Label></td>

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
                    <h4 class="modal-title">Edit Panel<asp:HiddenField ID="Txt_id" runat="server" />
                    </h4>
                    <button type="button" class="close" data-dismiss="modal">&times;</button>

                </div>
                <div class="modal-body">
                    <table class="table table-hover">

                        <tbody>
                            <tr>
                                <th scope="col">Full Name<span style="color: red;">*</span></th>
                                <td>
                                    <asp:TextBox ID="Txt_user2" CssClass="form-control" runat="server"></asp:TextBox></td>

                            </tr>
                            <tr>
                                <th scope="col">Role<span style="color: red;">*</span></th>
                                <td>
                                    <asp:DropDownList ID="Dd_role2" class="form-control" runat="server"></asp:DropDownList></td>

                            </tr>
                            <tr>
                                <th scope="col">Email<span style="color: red;">*</span></th>
                                <td>
                                    <asp:TextBox ID="Txt_email2" CssClass="form-control" runat="server"></asp:TextBox></td>

                            </tr>
                            <tr>
                                <th scope="col">Password<span style="color: red;">*</span></th>
                                <td>
                                    <asp:TextBox ID="Txt_password2" type="password" CssClass="form-control" runat="server"></asp:TextBox></td>

                            </tr>


                        </tbody>
                    </table>
                </div>
                <div class="modal-footer">
                    <asp:Button ID="Button5" class="btn btn-success" runat="server" Text="Update" OnClientClick="return JSFunctionValidate2();" OnClick="Button5_Click" />
                    <button type="button" class="btn btn-default" data-dismiss="modal">Close</button>
                </div>
            </div>

        </div>
    </div>



    <script type="text/javascript">
        window.setTimeout(function () {
            $(".alert").fadeTo(500, 0).slideUp(500, function () {
                $(this).remove();
            });
        }, 4000);
    </script>
    <script>
        function JSFunctionValidate() {
            if (document.getElementById('<%=Dd_role.ClientID%>').value == "--Select--") {
        alert("Please Select Role !!");
        return false;
    }
    if (document.getElementById('<%=Txt_full_name.ClientID%>').value.length == 0) {
        alert("Please Enter Full Name(User Name)");
        return false;
    }
    if (document.getElementById('<%=Txt_email.ClientID%>').value.length == 0) {
        alert("Please Enter Email");
        return false;
    }
    if (!(/^\w+([\.-]?\w+)*@\w+([\.-]?\w+)*(\.\w{2,3})+$/.test(document.getElementById('<%=Txt_email.ClientID%>').value))) {
        alert("You Have Entered an Invalid Email Address!");
        return false;
    }
    if (document.getElementById('<%=Txt_password.ClientID%>').value.length == 0) {
                alert("Please Enter Password");
                return false;
            }
            return true;
        }
        function JSFunctionValidate2() {

            if (document.getElementById('<%=Txt_user2.ClientID%>').value.length == 0) {
                    alert("Please Enter User Name");
                    return false;
                }
                if (document.getElementById('<%=Txt_email2.ClientID%>').value.length == 0) {
                    alert("Please Enter Email");
                    return false;
                }
                if (!(/^\w+([\.-]?\w+)*@\w+([\.-]?\w+)*(\.\w{2,3})+$/.test(document.getElementById('<%=Txt_email2.ClientID%>').value))) {
                    alert("You Have Entered an Invalid Email Address!");
                    return false;
                }
                if (document.getElementById('<%=Txt_password2.ClientID%>').value.length == 0) {
                alert("Please Enter Password");
                return false;
            }
            return true;
        }
        function RoleJSFunctionValidate() {

            if (document.getElementById('<%=Txt_role_name.ClientID%>').value.length == 0) {
                 alert("Please Enter Role Name");
                 return false;
             }
             if (document.getElementById('<%=Txt_date.ClientID%>').value.length == 0) {
                alert("Please Select Date");
                return false;
            }

            return true;
        }
        function PassJSFunctionValidate() {

            if (document.getElementById('<%=Txt_old_password.ClientID%>').value.length == 0) {
                    alert("Please Enter Old Password !!!");
                    return false;
                }
                if (document.getElementById('<%=Txt_new_password.ClientID%>').value.length == 0) {
                    alert("Please Enter New Password !!!");
                    return false;
                }
                if (document.getElementById('<%=Txt_confirm_password.ClientID%>').value.length == 0) {
                    alert("Please Enter Confirm Password !!!");
                    return false;
                }
                if (document.getElementById('<%=Txt_confirm_password.ClientID%>').value != document.getElementById('<%=Txt_new_password.ClientID%>').value) {
                    document.getElementById('<%=Lbl_message.ClientID%>').innerHTML = "Your New And Confirm Password Didn't Match !!!";

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

        function showrole() {
            $("#anrole").click();
        }
        function showpass() {
            $("#changepass").click();
        }
</script>
</asp:Content>

