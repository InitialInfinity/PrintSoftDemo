<%@ Page Title="" Language="C#" MasterPageFile="~/Expense/Expense.master" AutoEventWireup="true" CodeFile="expense.aspx.cs" Inherits="Expense_expense" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    
     
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
      <!-- Content Wrapper. Contains page content -->
  <div class="content-wrapper"> 
    <!-- Content Header (Page header) -->
    <section class="content-header sty-one">
      <h1>Expense</h1>
      <ol class="breadcrumb">
        <li><a href="#">Expense</a></li>
        <li><i class="fa fa-angle-right"></i> Expense</li>
      </ol>
    </section>
    <section class="content">
         <asp:Panel ID="Panel2" runat="server">
              <div class="alert alert-success" role="alert">
  <button type="button" class="close" data-dismiss="alert" aria-label="Close"><span aria-hidden="true">&times;</span></button>
  <strong>Success!</strong> Expense successfully added!
</div>     
        </asp:Panel>
        <asp:Panel ID="Panel3" runat="server">
              <div class="alert alert-success" role="alert">
  <button type="button" class="close" data-dismiss="alert" aria-label="Close"><span aria-hidden="true">&times;</span></button>
  <strong>Success!</strong> Category successfully added!
</div>     
        </asp:Panel>
        <asp:Panel ID="Panel4" runat="server">
              <div class="alert alert-success" role="alert">
  <button type="button" class="close" data-dismiss="alert" aria-label="Close"><span aria-hidden="true">&times;</span></button>
  <strong>Success!</strong> User successfully added!
</div>     
        </asp:Panel>
        
      <div class="row m-b-3">
        
        <div class="col-md-12">
          <div class="card">
            
            <!-- Nav tabs -->
            <ul class="nav nav-tabs customtab" role="tablist">
              <li class="nav-item"> <a class="nav-link active" data-toggle="tab" href="#messages2" role="tab" id="exp"><span class="hidden-sm-up"></span> <span class="hidden-xs-down">Expense</span></a> </li>
              <li class="nav-item"> <a class="nav-link" data-toggle="tab" href="#profile2" role="tab" id="addcat"><span class="hidden-sm-up"></span> <span class="hidden-xs-down">Add Category</span></a> </li>
              <li class="nav-item"> <a class="nav-link" data-toggle="tab" href="#home2" role="tab" id="addusr"><span class="hidden-sm-up"></span> <span class="hidden-xs-down">Add User</span></a> </li>
            </ul>
            <!-- Tab panes -->
            <div class="tab-content">
              <div class="tab-pane" id="home2" role="tabpanel">
                <div class="pad-20">
                <div class="card-body">
              <div class="form-horizontal form-bordered">
                <div class="form-body">
                  <div class="form-group row">
                    <label class="control-label text-right col-md-3">User Name<span style="color:red;">*</span></label>
                    <div class="col-md-9">
                      
                      <asp:TextBox ID="Txt_user_name"  placeholder="User Name" class="form-control" runat="server" TabIndex="1"></asp:TextBox>
                      </div>
                  </div>
                   <div class="form-group row">
                    <label class="control-label text-right col-md-3">Contact no.</label>
                    <div class="col-md-9">
                       <asp:TextBox ID="Txt_contact"  placeholder="Contact no." class="form-control" runat="server" TabIndex="2"></asp:TextBox>
                      </div>
                  </div>
                  <div class="form-group row">
                    <label class="control-label text-right col-md-3">Description</label>
                    <div class="col-md-9">
                     <asp:TextBox ID="Txt_desc"  placeholder="Description" class="form-control" runat="server" TextMode="MultiLine" TabIndex="3"></asp:TextBox>
                         </div>
                  </div>
                    
                   
                    
                </div>
                <div class="form-actions">
                  <div class="row">
                    <div class="col-md-12">
                      <div class="row">
                        <div class="offset-sm-3 col-md-9">
                          
                          <asp:Button ID="Btn_submit" class="btn btn-success" runat="server" Text="Submit" OnClientClick="return UserJSFunctionValidate()" OnClick="Btn_submit_Click" TabIndex="4"/>
                          
                          <asp:Button ID="Btn_cencel" class="btn btn-inverse" runat="server" Text="Cancel" TabIndex="5"/>

                        <asp:Label ID="Lbl_message" runat="server" Text="" Style="color: red"></asp:Label>
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
                  <th>User Name</th>
                  <th>Contact</th>
                  <th>Description</th>
                  
                  <th class="no-print">Actions</th>
                </tr>
                </thead>
                <tbody>
               

     <asp:Repeater ID="Repeater1" runat="server"> 
      <ItemTemplate> 
          <tr>
                  <td>
                      <asp:HiddenField ID="lbl_sr" runat="server" Value='<%# Eval("u_id") %>' />
              <asp:Label ID="lbl_user_name" runat="server" Text='<%# Eval("u_user_name") %>'></asp:Label></td>
                  <td><asp:Label ID="lbl_user_contact" runat="server" Text='<%# Eval("u_contact") %>'></asp:Label></td>
                  <td><asp:Label ID="lbl_user_desc" runat="server" Text='<%# Eval("u_desc") %>'></asp:Label></td>
                  <td class="no-print">
                  <asp:LinkButton ID="LinkButton1" runat="server" OnClientClick="return confirm('Do you want to delete this User?');" OnClick="DeleteUser"><i  class="fa fa-trash-o"></i></asp:LinkButton>
                  </td>
                </tr>
      </ItemTemplate>
     </asp:Repeater>
                


                </tbody>
                
              </table>
                  </div>
      </div>



                </div>
              </div>
              <div class="tab-pane p-20" id="profile2" role="tabpanel">
                <div class="pad-20">
                <div class="card-body">
              <div class="form-horizontal form-bordered">
                <div class="form-body">
                  <div class="form-group row">
                    <label class="control-label text-right col-md-3">Category Name<span style="color:red;">*</span></label>
                    <div class="col-md-9">
                      
                      <asp:TextBox ID="Txt_category_name" placeholder="Category Name" class="form-control" runat="server" TabIndex="6"></asp:TextBox>
                      </div>
                  </div>
                   
                  <div class="form-group row">
                    <label class="control-label text-right col-md-3">Date<span style="color:red;">*</span></label>
                    <div class="col-md-4">
                     <asp:TextBox ID="Txt_date" class="form-control" runat="server" TextMode="Date" TabIndex="7"></asp:TextBox>
                         </div>
                  </div>
                    
                   
                    
                </div>
                <div class="form-actions">
                  <div class="row">
                    <div class="col-md-12">
                      <div class="row">
                        <div class="offset-sm-3 col-md-9">
                          
                          <asp:Button ID="Button1" class="btn btn-success" runat="server" Text="Submit" OnClientClick="return CatJSFunctionValidate()" OnClick="Button1_Click" TabIndex="8"/>
                          
                          <asp:Button ID="Button2" class="btn btn-inverse" runat="server" Text="Cancel" TabIndex="9" />

                          <asp:Label ID="Lbl_message2" runat="server" Text="" Style="color: red"></asp:Label>
                        </div>
                      </div>
                    </div>
                  </div>
                </div>
              </div>
            </div>  

                    
      <div class="card-body">
     <hr/>
     
      <div class="table-responsive">
                  <table id="example2" class="table table-bordered table-striped">
                <thead>
                <tr>
                  <th>Category Name</th>
                  <th>Date</th>
                  
                  <th class="no-print">Actions</th>
                </tr>
                </thead>
                <tbody>
               

     <asp:Repeater ID="Repeater3" runat="server"> 
      <ItemTemplate> 
          <tr>
                  <td><asp:HiddenField ID="lbl_sr" runat="server" Value='<%# Eval("cat_id") %>' />
              <asp:Label ID="lbl_category_name" runat="server" Text='<%# Eval("cat_category_name") %>'></asp:Label></td>
                  <td><asp:Label ID="lbl_date" runat="server" Text='<%# Eval("cat_date", "{0:dd/MM/yyyy}") %>'></asp:Label></td>
                 <td class="no-print">
                  <asp:LinkButton ID="LinkButton1" runat="server" OnClientClick="return confirm('Do you want to delete this Category?');" OnClick="DeleteCategory"><i  class="fa fa-trash-o"></i></asp:LinkButton>
                  </td>
                  
                </tr>
      </ItemTemplate>
     </asp:Repeater>
                


                </tbody>
                
              </table>

          


                  </div>
      </div>


                </div>
              </div>
              <div class="tab-pane active p-20" id="messages2" role="tabpanel">
                <div class="pad-20">
                  <div class="card-body">
              <div class="form-horizontal form-bordered">
                <div class="form-body">
                  <div class="form-group row">
                    <label class="control-label text-right col-md-3">Category Name<span style="color:red;">*</span></label>
                    <div class="col-md-9">
                      
                       <asp:DropDownList ID="Dd_category" class="form-control" runat="server" TabIndex="10"></asp:DropDownList>
                      </div>
                  </div>
                   <div class="form-group row">
                    <label class="control-label text-right col-md-3">User Name<span style="color:red;">*</span></label>
                    <div class="col-md-9">
                       <asp:DropDownList ID="Dd_user" class="form-control" runat="server" TabIndex="11"></asp:DropDownList>
                      </div>
                  </div>
                 <div class="form-group row">
                    <label class="control-label text-right col-md-3">Amount<span style="color:red;">*</span></label>
                    <div class="col-md-9">
                       <asp:TextBox ID="Txt_amount" placeholder="Amount" class="form-control" runat="server" TabIndex="12"></asp:TextBox>
                      </div>
                  </div>

                     


                  <div class="form-group row">
                    <label class="control-label text-right col-md-3">Date<span style="color:red;">*</span></label>
                    <div class="col-md-9">
                       <asp:TextBox ID="Txt_expense_date"  class="form-control" runat="server" TextMode="Date" TabIndex="13"  onblur="checkDate(this.value)"></asp:TextBox>
                      </div>
                  </div>  
                   <div class="form-group row">
                    <label class="control-label text-right col-md-3">Description</label>
                    <div class="col-md-9">
                     <asp:TextBox ID="Txt_ex_desc"  placeholder="Description" class="form-control" runat="server" TextMode="MultiLine" TabIndex="14"></asp:TextBox>
                         </div>
                  </div>
                    
                </div>
                <div class="form-actions">
                  <div class="row">
                    <div class="col-md-12">
                      <div class="row">
                        <div class="offset-sm-3 col-md-9">
                          
                          <asp:Button ID="Button3" class="btn btn-success" runat="server" Text="Submit" OnClientClick="return JSFunctionValidate();" OnClick="Button3_Click" TabIndex="15"/>
                          
                          <asp:Button ID="Button4" class="btn btn-inverse" runat="server" Text="Cancel" TabIndex="16" OnClick="Button4_Click"/>

                          <asp:Label ID="Lbl_message3" runat="server" Text=""></asp:Label>
                        </div>
                      </div>
                    </div>
                  </div>
                </div>
              </div>
            </div>

                                  <br/>
           <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
<asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
      <div id="dropHere" class="table-responsive">
               <table id="example3" class="table table-bordered table-striped">
                <thead>
                <tr>
                  <th>ID #</th>
                    <th>Date</th>
                  <th>Category</th>
                  <th>User</th>
                  <th>Amount</th>
                   <%-- <th>Machine Counter</th>--%>
                  
                  <th class="no-print">Actions</th>
                </tr>
                </thead>
                <tbody>

          <asp:Repeater ID="Repeater2" runat="server">
              <ItemTemplate>
                   <tr>
                    <td>
              <asp:Label ID="lbl_sr" runat="server" Text='<%# Eval("e_id") %>'></asp:Label></td>
                  
                      <td><asp:Label ID="lbl_da" runat="server" Text='<%# Eval("e_date","{0:dd/MM/yyyy}") %>'></asp:Label></td>
              <td><asp:Label ID="lbl_cat" runat="server" Text='<%# Eval("e_category_name") %>'></asp:Label></td>
                  <td><asp:Label ID="lbl_use" runat="server" Text='<%# Eval("e_user_name") %>'></asp:Label></td>
                  <td><asp:Label ID="lbl_amt" runat="server" Text='<%# Eval("e_amount") %>'></asp:Label></td>
                     <%-- <td><b><asp:Label ID="lbl_count" runat="server" Text='<%# Eval("e_count") %>'></asp:Label></b></td>--%>
                 <td class="no-print">
                  <asp:LinkButton ID="LinkButton1" runat="server" OnClientClick="return confirm('Do you want to delete this Expense?');" OnClick="DeleteSale"><i  class="fa fa-trash-o"></i></asp:LinkButton>
                 
                  </td>
              

                   </tr>
              </ItemTemplate>

          </asp:Repeater>

              
                </tbody>
                
              </table>


                  </div>
                </ContentTemplate>
        </asp:UpdatePanel>
     

                </div>
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
    Copyright © 2018 PrintSoft. All rights reserved.</footer>


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
    if (document.getElementById('<%=Dd_category.ClientID%>').selectedIndex == 0)
{
alert("Please Select Category");
return false;
}
if(document.getElementById('<%=Dd_user.ClientID%>').selectedIndex == 0)
{
alert("Please Select User");
return false;
}
    if(document.getElementById('<%=Txt_amount.ClientID%>').value.length==0)
{
alert("Please Enter Amount !!!");
return false;
    }
     if(document.getElementById('<%=Txt_expense_date.ClientID%>').value.length==0)
{
alert("Please Select Date !!!");
return false;
    }
 
return true;
}

function CatJSFunctionValidate()
{
   if(document.getElementById('<%=Txt_category_name.ClientID%>').value.length==0)
{
alert("Please Enter Category Name !!!");
return false;
   }
     if(document.getElementById('<%=Txt_date.ClientID%>').value.length==0)
{
alert("Please Select Date !!!");
return false;
    }
    
    
return true;
}

function UserJSFunctionValidate()
{
   if(document.getElementById('<%=Txt_user_name.ClientID%>').value.length==0)
{
alert("Please Enter User's Name !!!");
return false;
   }

return true;
          }

        
          function checkDate(dateString) {
             // var txtExpenseDate = document.getElementById('<%=Txt_expense_date.ClientID%>');
              var expenseDate = new Date(dateString); // Parse the input as a Date object
                 var currentDate = new Date();

                 if (expenseDate > currentDate) {
                     alert('Expense date cannot be a future date');
                     txtExpenseDate.value = ''; // Clear the input field
                 }
             }
    

      </script>
    <script type="text/javascript">
        // Check if the category creation flag is set
        var categoryCreated = '<%= Session["CategoryCreated"] %>';

        // Function to switch to the "profile2" tab
        function switchToProfile2Tab() {
            $('#myTab a[href="#profile2"]').tab('show');
        }

        // Check if the category was created and redirect to the tab if necessary
        if (categoryCreated) {
            switchToProfile2Tab();
        }
        function showcat() {
            $("#addcat").click();
        }
        function showusr() {
            $("#addusr").click();
        }
    </script>
</asp:Content>

