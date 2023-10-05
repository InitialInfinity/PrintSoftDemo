<%@ Page Title="" Language="C#" MasterPageFile="~/CustomerRate/Rate.master" AutoEventWireup="true" CodeFile="Create_rate.aspx.cs" Inherits="CustomerRate_Create_rate" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
       <!-- Content Wrapper. Contains page content -->
  <div class="content-wrapper"> 
    <!-- Content Header (Page header) -->
    <section class="content-header sty-one">
      <h1>Add Customer Rate</h1>
      <ol class="breadcrumb">
        <li><a href="#">Customer Rate</a></li>
        <li><i class="fa fa-angle-right"></i> Add Customer Rate</li>
      </ol>
    </section>
      
    <section class="content">
       
      <div class="row">
        <div class="col-lg-12">
          <div class="card">
            <div class="card-header bg-blue">
              <h5 class="m-b-0">Customer Rate Form</h5>
            </div>
            <div class="card-body">
              <div class="form-horizontal form-bordered">
                <div class="form-body">
                  <div class="form-group row">
                    <label class="control-label text-right col-md-3">Customer/Company Name<span style="color:red;">*</span></label>
                    <div class="col-md-9">
                      
                    <%--<asp:TextBox ID="Txt_customer_name" placeholder="Customer/Company Name"  class="form-control" runat="server"></asp:TextBox>--%>
                        <asp:DropDownList ID="drp_Customer" runat="server" class="form-control"></asp:DropDownList>
                      </div>

                       
                  </div>
            <div class="form-group row">
                    <label class="control-label text-right col-md-3">Product Name<span style="color:red;">*</span></label>
                    <div class="col-md-9">
                     
                          <asp:DropDownList ID="drp_product" runat="server" class="form-control"></asp:DropDownList>
                      </div>
                  </div>
       
                   <div class="form-group row">
                    <label class="control-label text-right col-md-3">Customer Rate<span style="color:red;">*</span></label>
                    <div class="col-md-9">
                       <asp:TextBox ID="Txt_Rate"   placeholder="Customre Rate." class="form-control" runat="server" ></asp:TextBox>
                      </div>
                  </div>
        
          
                  
                </div>
                <div class="form-actions">
                  <div class="row">
                    <div class="col-md-12">
                      <div class="row">
                        <div class="offset-sm-3 col-md-9">
                          
                          <asp:Button ID="Btn_submit" class="btn btn-success" runat="server" Text="Submit" OnClick="Btn_submit_Click" OnClientClick="return JSFunctionValidate(); "/>
                          
                          <asp:Button ID="Btn_cencel" class="btn btn-inverse" runat="server" Text="Cancel" />

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
if(document.getElementById('<%=drp_Customer.ClientID%>').value=="--Select--")
{
alert("Please select Customer/Company Name !!!");
return false;
    }
    if (document.getElementById('<%=drp_product.ClientID%>').value == "--Select--") {
        alert("Please select Product !!!");
        return false;
    }
    if (document.getElementById('<%=Txt_Rate.ClientID%>').value.length== 0) {
        alert("Please enter rate !!!");
        return false;
    }

return true;
}
    </script>
</asp:Content>

