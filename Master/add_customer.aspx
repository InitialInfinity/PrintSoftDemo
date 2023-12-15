<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Master.master" AutoEventWireup="true" CodeFile="add_customer.aspx.cs" Inherits="Master_add_customer" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
     
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
      <!-- Content Wrapper. Contains page content -->
  <div class="content-wrapper"> 
    <!-- Content Header (Page header) -->
    <section class="content-header sty-one">
        <asp:Panel ID="Panel1" runat="server">
              <div class="alert alert-success" role="alert">
  <button type="button" class="close" data-dismiss="alert" aria-label="Close"><span aria-hidden="true">&times;</span></button>
  <strong>Success!</strong> New Customer successfully added!
</div>     
        </asp:Panel>
      <h1>Add Customer</h1>
      <ol class="breadcrumb">
        <li><a href="#">Master</a></li>
        <li><i class="fa fa-angle-right"></i> Add Customer</li>
      </ol>
    </section>
      
    <section class="content">
       
      <div class="row">
        <div class="col-lg-12">
          <div class="card">
            <div class="card-header bg-blue">
              <h5 class="m-b-0">Customer Entry Form</h5>
            </div>
            <div class="card-body">
              <div class="form-horizontal form-bordered">
                <div class="form-body">
                  <div class="form-group row">
                    <label class="control-label text-right col-md-3">Customer/Company Name<span style="color:red;">*</span></label>
                    <div class="col-md-6">
                      
                      <asp:TextBox ID="Txt_customer_name" placeholder="Customer/Company Name"  class="form-control" runat="server" TabIndex="1"></asp:TextBox>
                      </div>
                  </div>
                  <div class="form-group row">
                    <label class="control-label text-right col-md-3">Address</label>
                    <div class="col-md-6">
                      <asp:TextBox ID="Txt_address" class="form-control"  placeholder="Address" runat="server" TextMode="MultiLine" TabIndex="2"></asp:TextBox>
                         
                    </div>
                  </div>
       
                   <div class="form-group row">
                    <label class="control-label text-right col-md-3">Contact no.<span style="color:red;">*</span></label>
                    <div class="col-md-6">
                       <asp:TextBox ID="Txt_contact"   placeholder="Contact no." class="form-control" MaxLength="10" runat="server" oninput="validateInput(this);" TabIndex="3"></asp:TextBox>
                      </div>
                  </div>
                    <div class="form-group row">
                    <label class="control-label text-right col-md-3">Alternate Contact no.</label>
                    <div class="col-md-6">
                       <asp:TextBox ID="Txt_contact2" placeholder="Alternate Contact no." class="form-control" runat="server" TextMode="Number" TabIndex="4"></asp:TextBox>
                      </div>
                  </div>
                  <div class="form-group row">
                    <label class="control-label text-right col-md-3">GST no.</label>
                    <div class="col-md-6">
                      <asp:TextBox ID="Txt_gst_no" placeholder="GST no." class="form-control" runat="server" TabIndex="5" MaxLength="15"></asp:TextBox>
                    </div>
                  </div>
                  <div class="form-group row">
                    <label class="control-label text-right col-md-3">Opening Balance</label>
                    <div class="col-md-6">
                      <asp:TextBox ID="Txt_opening_balance" placeholder="Opening Balance" class="form-control" runat="server" TextMode="Number" TabIndex="6"></asp:TextBox>
                    </div>
                      </div>
                      
                  
                  <div class="form-group row">
                    <label class="control-label text-right col-md-3">Email ID</label>
                    <div class="col-md-6">
                      <asp:TextBox ID="Txt_email" placeholder="Email ID" class="form-control" runat="server" TextMode="Email" TabIndex="7"></asp:TextBox>
                    </div>
                  </div>

                    <div class="form-group row">
                    <label class="control-label text-right col-md-3">Date Of Birth</label>
                    <div class="col-md-3">
                      <asp:TextBox ID="Txt_dob" placeholder="DOB" class="form-control" runat="server" TextMode="Date" TabIndex="8"></asp:TextBox>
                    </div>
                         <div class="col-md-3">
                      <asp:TextBox ID="Txt_ani" placeholder="Anniversary" class="form-control" runat="server" TextMode="Date" TabIndex="9"></asp:TextBox>
                    </div>
                  </div>

               <%--     <div class="form-group row">
                    <label class="control-label text-right col-md-3">Anniversary Date</label>
                   
                  </div>--%>
                  
                </div>
                <div class="form-actions">
                  <div class="row">
                    <div class="col-md-12">
                      <div class="row">
                        <div class="offset-sm-3 col-md-9">
                          
                          <asp:Button ID="Btn_submit" class="btn btn-success" runat="server" Text="Submit" OnClientClick="return JSFunctionValidate(); " OnClick="Btn_submit_Click" TabIndex="10"/>
                          
                          <asp:Button ID="Btn_cencel" class="btn btn-inverse" runat="server" Text="Cancel" TabIndex="11"/>

                          <asp:Label ID="Lbl_message" style="color:greenyellow" runat="server" Text=""></asp:Label>
                            
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
    <!-- /.content --> 
  </div>
    
  <!-- /.content-wrapper -->
  <footer class="main-footer">
    <div class="pull-right hidden-xs">Version 1.0</div>
    Copyright © 2018 PrintSoft. All rights reserved.</footer>

   
     <script>
function JSFunctionValidate()
{
if(document.getElementById('<%=Txt_customer_name.ClientID%>').value.length==0)
{
alert("Please Enter Customer Name !!!");
return false;
}
  if (!(/^\w+([\.-]?\w+)*@\w+([\.-]?\w+)*(\.\w{2,3})+$/.test(document.getElementById('<%=Txt_email.ClientID%>').value)) && !(document.getElementById('<%=Txt_email.ClientID%>').value.length == 0))
{  
        alert("You Have Entered an Invalid Email Address!");
        return false;
  }
    if (document.getElementById('<%=Txt_contact.ClientID%>').value.length == 0 )
{
        alert("Please Enter Customer's Contact Number !!!");
return false;
    }

    if (document.getElementById('<%=Txt_gst_no.ClientID%>').value.length != 0) {
        //alert("Please Enter Gst Number !!!");
        //return false;
        if (document.getElementById('<%=Txt_gst_no.ClientID%>').value.length != 15) {
            alert("Please Enter Valid Gst Number !!!");
            return false;
        }
    }
   
    

return true;
}
     </script>
    <script type="text/javascript">
        function validateInput(input) {
            input.value = input.value.replace(/\D/g, '').substring(0, 10);
        }
    </script>
</asp:Content>

