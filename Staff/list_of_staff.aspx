<%@ Page Title="" Language="C#" MasterPageFile="~/Staff/Staff.master" AutoEventWireup="true" CodeFile="list_of_staff.aspx.cs" Inherits="Staff_list_of_staff" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    
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
      <h1>List of Staff</h1>
      <ol class="breadcrumb">
        <li><a href="#">Master</a></li>
        <li><i class="fa fa-angle-right"></i> List of Staff</li>
      </ol>
    </section>
     <section class="content">
       <asp:Panel ID="Panel1" runat="server">
              <div class="alert alert-success" role="alert">
  <button type="button" class="close" data-dismiss="alert" aria-label="Close"><span aria-hidden="true">&times;</span></button>
  <strong>Success!</strong> New Staff successfully added!
</div>     
        </asp:Panel>
         <asp:Panel ID="Panel2" runat="server">
              <div class="alert alert-success" role="alert">
  <button type="button" class="close" data-dismiss="alert" aria-label="Close"><span aria-hidden="true">&times;</span></button>
  <strong>Success!</strong> Staff successfully updated!
</div>     
        </asp:Panel>
        
        <div class="card">
      <div class="card-body">
      <div class="row">
        <div class="col-md-3">
         <h4 class="text-black">List of Staff</h4>
        </div>
        
             <div class="col-md-9 exportbtn">
           <a href="add_staff.aspx"><button type="button" id="btn_mail"  title="Create New Invoice" class="btn btnsqr btn-primary4 btngap"> <i class="fa fa-plus"></i>Add Staff</button></a>
          
        <button type="button" id="btn_print" title="Print" onclick="printdiv('dropHere');" class="btn btnsqr btn-primary btngap"> <i class="fa fa-print"></i> Print</button>
        
        
      </div>
      </div>
      <br/>
      <div id="dropHere" class="table-responsive">
                  <table id="example1" class="table table-bordered table-striped">
                <thead>
                <tr>
                  <th>Sr.No.</th>
                  <th>Staff Name</th>
                  <th>Address</th>
                  <th>Contact no.</th>
                  
                  <th>Designation</th>
                  <th>Salary</th>
                  
                  <th class="no-print">Actions</th>
                </tr>
                </thead>
                <tbody>
                
                         <asp:Repeater ID="Repeater1" runat="server" OnItemCommand="Repeater1_ItemCommand"> 
      <ItemTemplate> 
          <tr>
               <td>
              <asp:Label ID="lbl_id" runat="server" Text='<%# Eval("st_id") %>'></asp:Label></td>
                  <td>
              <asp:Label ID="lbl_staff_name" runat="server" Text='<%# Eval("st_staff_name") %>'></asp:Label></td>
                  <td><asp:Label ID="lbl_address" runat="server" Text='<%# Eval("st_address") %>'></asp:Label></td>
                  <td><asp:Label ID="lbl_contact" runat="server" Text='<%# Eval("st_contact") %>'></asp:Label></td>
                  
                  <td><asp:Label ID="lbl_designation" runat="server" Text='<%# Eval("st_designation") %>'></asp:Label></td>
                  <td><asp:Label ID="lbl_salary" runat="server" Text='<%# Eval("st_salary") %>'></asp:Label></td>
                  <td  class="no-print">
                  <asp:LinkButton ID="LinkButton1" runat="server" OnClientClick="return confirm('Do you want to delete this Staff member?');" OnClick="DeleteStaff"><i  class="fa fa-trash-o"></i></asp:LinkButton>
                  <asp:LinkButton ID="LinkButton2" runat="server" CommandName="showid" CommandArgument='<%# Eval("st_id") %>' ><i style="padding-left:10px" class="fa fa-eye"></i></i></asp:LinkButton>
                  <asp:LinkButton ID="LinkButton3" runat="server" CommandName="editid" CommandArgument='<%# Eval("st_id") %>'><i style="padding-left:10px" class="fa fa-edit"></i></asp:LinkButton>
                      <!--<a href=""></a><a href=""><i style="padding-left:10px" class="fa fa-edit"></i></a><a href="" runat="server" ><i style="padding-left:10px" class="fa fa-trash-o"></i></a>-->
                  </td>
          </tr>
      </ItemTemplate>
     </asp:Repeater>
                 <asp:Label ID="Lbl_msg2" Style="color:red" runat="server" Text=""></asp:Label>
                </tbody>
                
              </table>


                  </div>
      </div></div>
    </section>
    
    </div>
    <footer class="main-footer">
    <div class="pull-right hidden-xs">Version 1.0</div>
    Copyright © 2018 PrintSoft. All rights reserved.</footer>
    
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
      <th scope="col">Address</th>
      <td><asp:Label ID="lbl_address" runat="server" Text=""></asp:Label></td>
     
    </tr>
    
       <tr>
      <th scope="col">Contact</th>
      <td><asp:Label ID="lbl_contact" runat="server" Text=""></asp:Label></td>
     
    </tr>
       <tr>
      <th scope="col">DOB</th>
      <td><asp:Label ID="lbl_dob" runat="server" Text=""></asp:Label></td>
     
    </tr>
       <tr>
      <th scope="col">Gender</th>
      <td><asp:Label ID="lbl_gender" runat="server" Text=""></asp:Label></td>
     
    </tr>
      
      <tr>
      <th scope="col">Designation</th>
      <td><asp:Label ID="lbl_designation" runat="server" Text=""></asp:Label></td>
     
    </tr>
      <tr>
      <th scope="col">Salary</th>
      <td><asp:Label ID="lbl_salary" runat="server" Text=""></asp:Label></td>
     
    </tr>
      <tr>
      <th scope="col">Balance</th>
      <td><asp:Label ID="lbl_balance" runat="server" Text=""></asp:Label></td>
     
    </tr>
      <tr>
      <th scope="col">Joining Date</th>
      <td><asp:Label ID="lbl_joining_date" runat="server" Text=""></asp:Label></td>
     
    </tr>
      <tr>
      <th scope="col">Left Date</th>
      <td><asp:Label ID="lbl_left_date" runat="server" Text=""></asp:Label></td>
     
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
      <th scope="col">Staff Name<span style="color:red;">*</span></th>
      <td><asp:TextBox ID="Txt_name" class="form-control" runat="server"></asp:TextBox></td>
     
    </tr>
    <tr>
      <th scope="col">Address<span style="color:red;">*</span></th>
      <td><asp:TextBox ID="Txt_address" class="form-control" runat="server"></asp:TextBox></td>
     
    </tr>
      
      <tr>
      <th scope="col">Contact<span style="color:red;">*</span></th>
      <td><asp:TextBox ID="Txt_contact" class="form-control" runat="server"></asp:TextBox></td>
     
    </tr>
       <tr>
      <th scope="col">DOB<span style="color:red;">*</span></th>
      <td><asp:TextBox ID="Txt_dob" class="form-control" runat="server" TextMode="Date"></asp:TextBox></td>
     
    </tr>
       <tr>
      <th scope="col">Gender<span style="color:red;">*</span></th>
      <td><asp:DropDownList ID="Dd_gender" class="form-control" runat="server">
                          <asp:ListItem Value="Male"></asp:ListItem>
                          <asp:ListItem Value="Female"></asp:ListItem>
                        </asp:DropDownList></td>
     
    </tr>
     
   <tr>
      <th scope="col">Designation<span style="color:red;">*</span></th>
      <td><asp:TextBox ID="Txt_designation" class="form-control" runat="server" TextMode="SingleLine"></asp:TextBox></td>
     
    </tr>
      <tr>
      <th scope="col">Salary<span style="color:red;">*</span></th>
      <td><asp:TextBox ID="Txt_salary" class="form-control" runat="server" TextMode="SingleLine"></asp:TextBox></td>
     
    </tr>
       <tr>
      <th scope="col">Balance<span style="color:red;">*</span></th>
      <td><asp:TextBox ID="Txt_balance" class="form-control" runat="server" TextMode="SingleLine"></asp:TextBox></td>
     
    </tr>
      <tr>
      <th scope="col">Joining Date<span style="color:red;">*</span></th>
      <td><asp:TextBox ID="Txt_joining_date" class="form-control" runat="server" TextMode="Date"></asp:TextBox></td>
     
    </tr>
      <tr>
      <th scope="col">Left Date</th>
      <td><asp:TextBox ID="Txt_left_date" class="form-control" runat="server" TextMode="Date"></asp:TextBox></td>
     
    </tr>
      
  </tbody>
</table>
        </div>
        <div class="modal-footer">
             <asp:Label ID="lbl_msg" runat="server" Text=""></asp:Label>
             <asp:Button ID="Button1" class="btn btn-success" runat="server" OnClientClick="return JSFunctionValidate();" Text="Update" OnClick="Button1_Click" />
          <button type="button" class="btn btn-default" data-dismiss="modal">Close</button>
        </div>
      </div>
      
    </div>
  </div>


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
function ShowModel2() {

    $('#myModal2').modal('show');
}
</script>
      <script>
function JSFunctionValidate()
{
    if(document.getElementById('<%=Txt_name.ClientID%>').value.length==0)
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
</asp:Content>

