<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Master.master" AutoEventWireup="true" CodeFile="add_product.aspx.cs" Inherits="Master_add_product" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
   
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
      <!-- Content Wrapper. Contains page content -->
  <div class="content-wrapper"> 
    <!-- Content Header (Page header) -->
    <section class="content-header sty-one"> 
      <h1>Add Product</h1>
      <ol class="breadcrumb">
        <li><a href="#">Master</a></li>
        <li><i class="fa fa-angle-right"></i> Add Product</li>
      </ol>
    </section>
     <section class="content">
      <div class="row">
        <div class="col-lg-12">
          <div class="card">
            <div class="card-header bg-blue">
              <h5 class="m-b-0">Product Entry Form</h5>
            </div>
            <div class="card-body">
              <div class="form-horizontal form-bordered">
                <div class="form-body">
                  <div class="form-group row">
                    <label class="control-label text-right col-md-3">Product Name<span style="color:red;">*</span></label>
                    <div class="col-md-9">
                      
                      <asp:TextBox ID="Txt_product_name" placeholder="Product Name" class="form-control" runat="server" TabIndex="1"></asp:TextBox>
                      </div>
                  </div>
                   <div class="form-group row">
                    <label class="control-label text-right col-md-3">Product Category<span style="color:red;">*</span></label>
                    <div class="col-md-9">
                     
                    <div class="row">
                     <div class="col-md-3"><asp:RadioButton ID="Rdo_sale" runat="server" GroupName="category" />&nbsp<asp:Label ID="Label1" runat="server" Text="Sale Product" TabIndex="2"></asp:Label></div>
                     <div class="col-md-3"><asp:RadioButton ID="Rdo_purchase" runat="server" GroupName="category" />&nbsp<asp:Label ID="Label2" runat="server" Text="Purchase Product" TabIndex="3"></asp:Label></div>
                      <div class="col-md-3"><asp:RadioButton ID="Rdo_both" runat="server" GroupName="category" />&nbsp<asp:Label ID="Label3" runat="server" Text="For Both" TabIndex="4"></asp:Label></div>
                       </div>
                          </div>
                  </div>
                    <div class="form-group row">
                    <label class="control-label text-right col-md-3">Unit<span style="color:red;">*</span></label>
                    <div class="col-md-9">
                         <asp:DropDownList ID="Dd_unit" class="form-control" runat="server" TabIndex="5">
                             <asp:ListItem Value="Sqft">Sqft</asp:ListItem>
                             <asp:ListItem Value="Inch">Inch</asp:ListItem>
                             <asp:ListItem Value="Pcs">Pcs</asp:ListItem>
                        
                              <asp:ListItem Value="Packet">Packet</asp:ListItem>
                              <asp:ListItem Value="Copy">Copy</asp:ListItem>
                             <asp:ListItem Value="Ltr">Ltr</asp:ListItem>
                         </asp:DropDownList>
                      </div>
                  </div>
                  
                   <div class="form-group row">
                    <label class="control-label text-right col-md-3">CGST<span style="color:red;">*</span></label>
                    <div class="col-md-9">
                        <asp:dropdownlist ID="Dd_cgst" class="form-control" runat="server" TabIndex="6">
                            <asp:ListItem Value="0">0 %</asp:ListItem>
                            <asp:ListItem Value="5">5 %</asp:ListItem>
                            <asp:ListItem Value="6">6 %</asp:ListItem>
                            <asp:ListItem Value="9">9 %</asp:ListItem>
                            <asp:ListItem Value="12">12 %</asp:ListItem>
                            <asp:ListItem Value="18">18 %</asp:ListItem>
                            <asp:ListItem Value="28">28 %</asp:ListItem>

                        </asp:dropdownlist>
                    </div>
                  </div>
                    <div class="form-group row">
                    <label class="control-label text-right col-md-3">SGST<span style="color:red;">*</span></label>
                    <div class="col-md-9">
                       <asp:dropdownlist  ID="Dd_sgst" class="form-control" runat="server" TabIndex="7">
                           <asp:ListItem Value="0">0 %</asp:ListItem>
                            <asp:ListItem Value="5">5 %</asp:ListItem>
                            <asp:ListItem Value="6">6 %</asp:ListItem>
                            <asp:ListItem Value="9">9 %</asp:ListItem>
                            <asp:ListItem Value="12">12 %</asp:ListItem>
                            <asp:ListItem Value="18">18 %</asp:ListItem>
                            <asp:ListItem Value="28">28 %</asp:ListItem>
                       </asp:dropdownlist>
                      </div>
                  </div>
                    <div class="form-group row">
                    <label class="control-label text-right col-md-3">IGST<span style="color:red;">*</span></label>
                    <div class="col-md-9">
                       <asp:dropdownlist ID="Dd_igst" class="form-control" runat="server" TabIndex="8">
                          <asp:ListItem Value="0">0 %</asp:ListItem>
                            <asp:ListItem Value="5">5 %</asp:ListItem>
                            <asp:ListItem Value="6">6 %</asp:ListItem>
                            <asp:ListItem Value="9">9 %</asp:ListItem>
                            <asp:ListItem Value="12">12 %</asp:ListItem>
                            <asp:ListItem Value="18">18 %</asp:ListItem>
                            <asp:ListItem Value="28">28 %</asp:ListItem>
                       </asp:dropdownlist>
                      </div>
                  </div>
                     <div class="form-group row">
                    <label class="control-label text-right col-md-3">HSN Code</label>
                    <div class="col-md-9">
                       <asp:TextBox ID="Txt_hsn"  placeholder="HSN Code" class="form-control" runat="server" TabIndex="9"></asp:TextBox>
                      </div>
                  </div>

                  <div class="form-group row">
                    <label class="control-label text-right col-md-3">Rate (Rs)<span style="color:red;">*</span></label>
                    <div class="col-md-9">
                      <asp:TextBox ID="Txt_rate"  placeholder="Rate" class="form-control" runat="server" TabIndex="10"></asp:TextBox>
                    </div>
                  </div>
                  <div class="form-group row">
                    <label class="control-label text-right col-md-3">Description</label>
                    <div class="col-md-9">
                             <asp:TextBox ID="Txt_description" class="form-control" runat="server" TextMode="MultiLine" TabIndex="11"></asp:TextBox>
                      </div>
                  </div>
                 
                  
                </div>
                <div class="form-actions">
                  <div class="row">
                    <div class="col-md-12">
                      <div class="row">
                        <div class="offset-sm-3 col-md-9">
                          
                          <asp:Button ID="Btn_submit" class="btn btn-success" runat="server" Text="Submit" OnClientClick="return JSFunctionValidate()" OnClick="Btn_submit_Click" TabIndex="12"/>
                          
                          <asp:Button ID="Btn_cencel" class="btn btn-inverse" runat="server" Text="Cancel" TabIndex="13"/>

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
    
    </div>
  <!-- /.content-wrapper -->
  <footer class="main-footer">
    <div class="pull-right hidden-xs">Version 1.0</div>
    Copyright © 2018 PrintSoft. All rights reserved.</footer>

 
    <script>
function JSFunctionValidate()
{
if(document.getElementById('<%=Txt_product_name.ClientID%>').value.length==0)
{
alert("Please Enter Product Name !!!");
return false;
}
   
    
    if (document.getElementById('<%=Txt_rate.ClientID%>').value.length == 0)
{
        alert("Please Enter Product's Rate  !!!");
return false;
    }
    
 
return true;
}
        </script>
</asp:Content>

