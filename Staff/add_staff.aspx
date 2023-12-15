<%@ Page Title="" Language="C#" MasterPageFile="~/Staff/Staff.master" AutoEventWireup="true" CodeFile="add_staff.aspx.cs" Inherits="Staff_add_staff" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <!-- Content Wrapper. Contains page content -->
    <div class="content-wrapper">
        <!-- Content Header (Page header) -->
        <section class="content-header sty-one">
            <h1>Add Staff</h1>
            <ol class="breadcrumb">
                <li><a href="#">Staff</a></li>
                <li><i class="fa fa-angle-right"></i>Add Staff</li>
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
                                        <label class="control-label text-right col-md-3">Staff Name<span style="color: red;">*</span></label>
                                        <div class="col-md-9">

                                            <asp:TextBox ID="Txt_staff_name" placeholder="Staff Name" class="form-control" runat="server"></asp:TextBox>
                                        </div>
                                    </div>

                                    <div class="form-group row">
                                        <label class="control-label text-right col-md-3">Address<span style="color: red;">*</span></label>
                                        <div class="col-md-9">
                                            <asp:TextBox ID="Txt_address" class="form-control" placeholder="Address" runat="server" TextMode="MultiLine"></asp:TextBox>
                                        </div>
                                    </div>

                                    <div class="form-group row">
                                        <label class="control-label text-right col-md-3">Contact no.<span style="color: red;">*</span></label>
                                        <div class="col-md-9">
                                            <asp:TextBox ID="Txt_contact" placeholder="Contact no." class="form-control" runat="server" TextMode="Number"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="form-group row">
                                        <label class="control-label text-right col-md-3">DOB<span style="color: red;">*</span></label>
                                        <div class="col-md-9">
                                            <asp:TextBox ID="Txt_dob" class="form-control" runat="server" TextMode="Date" onblur="validateBirthdate(this.value)"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="form-group row">
                                        <label class="control-label text-right col-md-3">Gender<span style="color: red;">*</span></label>
                                        <div class="col-md-9">
                                            <asp:DropDownList ID="Dd_gender" class="form-control" runat="server">
                                                <asp:ListItem Value="Male"></asp:ListItem>
                                                <asp:ListItem Value="Female"></asp:ListItem>
                                            </asp:DropDownList>
                                        </div>
                                    </div>

                                    <div class="form-group row">
                                        <label class="control-label text-right col-md-3">Designation<span style="color: red;">*</span></label>
                                        <div class="col-md-9">
                                            <asp:TextBox ID="Txt_designation" placeholder="Designation" class="form-control" runat="server"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="form-group row">
                                        <label class="control-label text-right col-md-3">Salary<span style="color: red;">*</span></label>
                                        <div class="col-md-9">
                                            <asp:TextBox ID="Txt_salary" placeholder="Salary" class="form-control" runat="server" TextMode="Number"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="form-group row">
                                        <label class="control-label text-right col-md-3">Balance<span style="color: red;">*</span></label>
                                        <div class="col-md-9">
                                            <asp:TextBox ID="Txt_balance" placeholder="Balance" class="form-control" runat="server" TextMode="Number"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="form-group row">
                                        <label class="control-label text-right col-md-3">Joining Date<span style="color: red;">*</span></label>
                                        <div class="col-md-9">
                                            <asp:TextBox ID="Txt_joining_date" class="form-control" runat="server" onblur="check(this.value)" TextMode="Date"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="form-group row">
                                        <label class="control-label text-right col-md-3">Left Date</label>
                                        <div class="col-md-9">
                                            <asp:TextBox ID="Txt_left_date" class="form-control" onblur="checkLeftDate(this.value)" runat="server" TextMode="Date"></asp:TextBox>
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

                                                    <asp:Label ID="Lbl_message" Style="color: red" runat="server" Text=""></asp:Label>
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
        Copyright © 2018 PrintSoft. All rights reserved.
    </footer>
    <script>

        function validateBirthdate(dateString) {
            var dateParts = dateString.split('-');
            var day = parseInt(dateParts[2]);
            var month = parseInt(dateParts[1]) - 1; // Months are zero-based
            var year = parseInt(dateParts[0]);

            var inputDate = new Date(year, month, day);
            var today = new Date();


            // Check if the birthdate is a future date

            // Calculate the age based on the birthdate
            var age = today.getFullYear() - inputDate.getFullYear();
            var monthDiff = today.getMonth() - inputDate.getMonth();
            if (monthDiff < 0 || (monthDiff === 0 && today.getDate() < inputDate.getDate())) {
                age--;
            }

            if (age < 18) {
                alert("Please select valid date!");
                /*$("#txtDOB").val('');*/
                document.getElementById('<%=Txt_dob.ClientID%>').value = ""; 
            }

            return true;
        }
        </script>


    <script>
        function JSFunctionValidate() {
            if (document.getElementById('<%=Txt_staff_name.ClientID%>').value.length == 0) {
                alert("Please Enter Staff Member Name !!!");
                return false;
            }
            if (document.getElementById('<%=Txt_address.ClientID%>').value.length == 0) {
                alert("Please Enter Address !!!");
                return false;
            }

            if (document.getElementById('<%=Txt_contact.ClientID%>').value.length == 0) {
                alert(" Enter Valid Contact Number !!!");
                return false;
            }
            if (!(document.getElementById('<%=Txt_contact.ClientID%>').value.length == 10)) {
                alert("Please Enter 10 Digits Contact Number !!!");
                return false;
            }
            if (document.getElementById('<%=Txt_dob.ClientID%>').value.length == 0) {
                alert("Please Select Date of Birth !!!");
                return false;
            }

            if (document.getElementById('<%=Txt_designation.ClientID%>').value.length == 0) {
                alert("Please Enter Designation !!!");
                return false;
            }
            if (document.getElementById('<%=Txt_salary.ClientID%>').value.length == 0) {
                alert("Please Enter Salary !!!");
                return false;
            }
            if (document.getElementById('<%=Txt_balance.ClientID%>').value.length == 0) {
        alert("Please Enter Balance Amount !!!");
        return false;
    }
    if (document.getElementById('<%=Txt_joining_date.ClientID%>').value.length == 0) {
                alert("Please Select Joining Date !!!");
                return false;
            }

            return true;
        }
</script>
    <script>
        function check(joiningDateText) {
            var dobText = document.getElementById('<%=Txt_dob.ClientID%>').value;

           if (dobText !== "" && joiningDateText !== "") {
               var dob = new Date(dobText);
               var joiningDate = new Date(joiningDateText);
               var currentDate = new Date(); // Get the current date

          
               if (joiningDate <= currentDate && joiningDate > dob) {
                   var ageDifference = (currentDate - dob) / (1000 * 60 * 60 * 24 * 365.25);

                   if (ageDifference >= 18) {
                       return true;
                   } else {
                       alert("The person should be at least 18 years old.");
                       document.getElementById('<%=Txt_joining_date.ClientID%>').value = "";
                return false;
            }
        } else {
            alert("Joining Date must be greater than DOB and should not be a future date.");
                    document.getElementById('<%=Txt_joining_date.ClientID%>').value = "";
                    return false;
                }
            }
        }







    </script>
      <script>
          function checkLeftDate(LeftDateText) {
              var dobText = document.getElementById('<%=Txt_dob.ClientID%>').value;
              var joiningDateText = document.getElementById('<%=Txt_joining_date.ClientID%>').value;

              if (dobText !== "" && joiningDateText !== "" && LeftDateText!="") {

                var dob = new Date(dobText);
                  var LeftDate = new Date(LeftDateText);


                  var ageDifference = (LeftDate - dob) / (1000 * 60 * 60 * 24 * 365.25);


                  if (LeftDate > dob && ageDifference >= 18 && LeftDateText > joiningDateText) {

                    return true;
                } else {

                      alert("Left Date must be greater than DOB and greater than joining date.");
                    document.getElementById('<%=Txt_left_date.ClientID%>').value = ""; // Clear the Joining Date field
                      return false;
                  }
              }

          }
      </script>
</asp:Content>

