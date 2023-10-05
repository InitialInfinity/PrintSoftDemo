<%@ Page Title="" Language="C#" MasterPageFile="~/Company/Company.master" AutoEventWireup="true" CodeFile="company_details.aspx.cs" Inherits="Company_company_details" %>

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
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <!-- Content Wrapper. Contains page content -->
  <div class="content-wrapper"> 
    <!-- Content Header (Page header) -->
    <section class="content-header sty-one">
      <h1>Company Details</h1>
      <%-- <ol class="breadcrumb">
        <li><a href="../Admin/admin_logout.aspx" style="    font-size: 16px; color:red;"><i class="fa fa-power-off"></i>Log-out</a></li>
       
      </ol>--%>
    </section>
     <section class="content">
         <asp:Panel ID="Panel4" runat="server">
<div class="card m-t-3">
      <div class="card-body">
       <div class="row">
        <div class="col-md-4">
         <h4 class="text-black"><i class="fa fa-list-ul" style="color:#0077d3"></i> Company Details</h4>
        </div>
        
             <div class="col-md-8 exportbtn">
          
         
         <button type="button" id="btn_update" title="Update Company Info" runat="server" onserverclick="update_info"  class="btn btnsqr btn-primary5"> <i class="fa fa-pencil-square-o"></i> Update</button>
        
      </div>
      </div>
     
      <div class="table-responsive">
                  <table id="example1" class="table table-bordered table-striped details">
                <thead>
                <tr>
                  <th>Company Name</th>
                 
                 <td>
                    <h5><b><asp:Label ID="lbl_company_name" runat="server" Text="Not Set"></asp:Label></b></h5></td>
                 
                </tr>
                <tr>
                  <th>Sub Company Name</th>
                 
                 <td>
                    <h5><b><asp:Label ID="lbl_company_name2" runat="server" Text="Not Set"></asp:Label></b></h5></td>
                 
                </tr>
                <tr>
                  <th>Owner Name</th>
                 <td>
                    <asp:Label ID="lbl_owner_name" runat="server" Text="Not Set"></asp:Label></td>
                </tr>
                <tr>
                  <th>Address</th>
                 <td>
                    <asp:Label ID="lbl_address" runat="server" Text="Not Set"></asp:Label></td>
                </tr>
                <tr>
                  <th>Contact no.</th>
                 <td>
                    <asp:Label ID="lbl_contact" runat="server" Text="Not Set"></asp:Label></td>
                </tr>
                <tr>
                  <th>GST no.</th>
                 <td>
                    <asp:Label ID="lbl_gst" runat="server" Text="Not Set"></asp:Label></td>
                </tr>
                <tr>
                  <th>Email ID</th>
                 <td>
                    <asp:Label ID="lbl_email" runat="server" Text="Not Set"></asp:Label></td>
                </tr>
                <tr>
                  <th>Website</th>
                 <td>
                   <asp:Label ID="lbl_website" runat="server" Text="Not Set"></asp:Label></td>
                </tr>
                <tr>
                  <th>Company Logo</th>
                 <td>
                  
                    <asp:Label ID="lbl_logo" runat="server" Text="Not Set"></asp:Label>
                   
                        <asp:LinkButton ID="LinkButton1" runat="server" OnClick="LinkButton1_Click"><i class="fa fa-pencil-square-o" aria-hidden="true"></i>Edit</asp:LinkButton>
                    
                 </td>
                </tr>
                    <asp:Panel ID="Panel2" runat="server">
                    <tr>
                  <th>Choose Company Logo</th>
                 <td>
                  
                 <asp:fileupload ID="fu_company_logo" Class="pull-left" runat="server">

                       </asp:fileupload>
                     
                     <asp:Button ID="Button1" Class="btn2 btnsqr btn-primary5 pull-right" OnClick="Logo_Update"  runat="server" Text="Update" />
                        
                 </td>
                </tr>
                   </asp:Panel>
                     <tr>
                  <th>Company SubLogo2</th>
                 <td>
                  
                    <asp:Label ID="lbl_logo2" runat="server" Text="Not Set"></asp:Label>
                   
                        <asp:LinkButton ID="LinkButton2" runat="server" OnClick="LinkButton2_Click"><i class="fa fa-pencil-square-o" aria-hidden="true"></i>Edit</asp:LinkButton>
                    
                 </td>
                </tr>
                    <asp:Panel ID="Panel3" runat="server">
                    <tr>
                  <th>Choose Company Logo2</th>
                 <td>
                  
                 <asp:fileupload ID="fu_company_logo2" Class="pull-left" runat="server">

                       </asp:fileupload>
                     
                     <asp:Button ID="Button2" Class="btn2 btnsqr btn-primary5 pull-right" OnClick="Logo_Update2"  runat="server" Text="Update" />
                        
                 </td>
                </tr>
                   </asp:Panel>
                    <tr>
                  <th>Bank Name</th>
                 <td>
                   <asp:Label ID="lbl_bank_name" runat="server" Text="Not Set"></asp:Label></td>
                </tr>
                    <tr>
                  <th>Branch Name</th>
                 <td>
                   <asp:Label ID="lbl_branch" runat="server" Text="Not Set"></asp:Label></td>
                </tr>
                    <tr>
                  <th>Account Number</th>
                 <td>
                   <asp:Label ID="lbl_ac_no" runat="server" Text="Not Set"></asp:Label></td>
                </tr>
                    <tr>
                  <th>Bank Branch IFSC</th>
                 <td>
                   <asp:Label ID="lbl_ifsc" runat="server" Text="Not Set"></asp:Label></td>
                </tr>
                     <tr>
                  <th>UPI Number</th>
                 <td>
                   <asp:Label ID="lblupino" runat="server" Text="Not Set"></asp:Label></td>
                </tr>
                </thead>
                
              </table>
                  </div>
      </div></div>
             </asp:Panel>


        <asp:Panel ID="Panel1" runat="server">
      <div class="row m-t-3">
        <div class="col-lg-12">
          <div class="card">
            <div class="card-header bg-blue">
              <h5 class="m-b-0"><i class="fa fa-pencil-square-o" aria-hidden="true"></i>Edit Company Details</h5>
            </div>
            <div class="card-body">
              <div class="form-horizontal form-bordered">
                <div class="form-body">
                  <div class="form-group row">
                    <label class="control-label text-right col-md-3">Company Name</label>
                    <div class="col-md-9">
                      
                      <asp:TextBox ID="Txt_company_name" placeholder="Company Name" class="form-control" runat="server"></asp:TextBox>
                      </div>
                  </div>
                  <div class="form-group row">
                    <label class="control-label text-right col-md-3">Sub Company Name</label>
                    <div class="col-md-9">
                      
                      <asp:TextBox ID="Txt_company_name2" placeholder="Sub Company Name" class="form-control" runat="server"></asp:TextBox>
                      </div>
                  </div>
                     <div class="form-group row">
                    <label class="control-label text-right col-md-3">Owner Name</label>
                    <div class="col-md-9">
                       <asp:TextBox ID="Txt_owner_name" placeholder="Owner Name" class="form-control" runat="server"></asp:TextBox>
                      </div>
                  </div>

                  <div class="form-group row">
                    <label class="control-label text-right col-md-3">Address</label>
                    <div class="col-md-9">
                      <asp:TextBox ID="Txt_address" placeholder="Address" class="form-control" runat="server" TextMode="MultiLine"></asp:TextBox>
                    </div>
                  </div>
                 <div class="form-group row">
                    <label class="control-label text-right col-md-3">Contact no.</label>
                    <div class="col-md-9">
                      <asp:TextBox ID="Txt_contact" placeholder="Contact no." class="form-control" runat="server"></asp:TextBox>
                    </div>
                  </div>
                 <div class="form-group row">
                    <label class="control-label text-right col-md-3">GST no.</label>
                    <div class="col-md-9">
                      <asp:TextBox ID="Txt_gst_no" placeholder="GST no." class="form-control" runat="server"></asp:TextBox>
                    </div>
                  </div>
                  <div class="form-group row">
                    <label class="control-label text-right col-md-3">Email Id</label>
                    <div class="col-md-9">
                      <asp:TextBox ID="Txt_email" placeholder="Email Id" class="form-control" runat="server"></asp:TextBox>
                    </div>
                  </div>
                   <div class="form-group row">
                    <label class="control-label text-right col-md-3">Website</label>
                    <div class="col-md-9">
                      <asp:TextBox ID="Txt_website" placeholder="Website" class="form-control" runat="server"></asp:TextBox>
                    </div>
                  </div>
                    <div class="form-group row">
                    <label class="control-label text-right col-md-3">Bank Name</label>
                    <div class="col-md-9">
                      <asp:TextBox ID="Txt_bank_name" placeholder="Bank Name" class="form-control" runat="server"></asp:TextBox>
                    </div>
                  </div>
                    <div class="form-group row">
                    <label class="control-label text-right col-md-3">Branch Name</label>
                    <div class="col-md-9">
                      <asp:TextBox ID="Txt_branch" placeholder="Branch Name" class="form-control" runat="server"></asp:TextBox>
                    </div>
                  </div>
                    <div class="form-group row">
                    <label class="control-label text-right col-md-3">Bank Account Number</label>
                    <div class="col-md-9">
                      <asp:TextBox ID="Txt_acc_no" placeholder="Bank Account Number" class="form-control" runat="server"></asp:TextBox>
                    </div>
                  </div>
                    <div class="form-group row">
                    <label class="control-label text-right col-md-3">Branch IFSC</label>
                    <div class="col-md-9">
                      <asp:TextBox ID="Txt_ifsc" placeholder="Branch IFSC" class="form-control" runat="server"></asp:TextBox>
                    </div>
                  </div>
                    <div class="form-group row">
                    <label class="control-label text-right col-md-3">UPI Number</label>
                    <div class="col-md-9">
                      <asp:TextBox ID="txtupino" placeholder="UPI Number" class="form-control" runat="server"></asp:TextBox>
                    </div>
                  </div>
                   
                </div>
                <div class="form-actions">
                  <div class="row">
                    <div class="col-md-12">
                      <div class="row">
                        <div class="offset-sm-3 col-md-9">
                          
                          <asp:Button ID="Btn_submit" class="btn btn-success" runat="server" Text="Update" OnClick="Btn_submit_Click"/>
                          
                          <asp:Button ID="Btn_cencel" class="btn btn-inverse" runat="server" Text="Cancel"/>

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
        </asp:Panel>
         
 </section>
    </div>
  <!-- /.content-wrapper -->
  <footer class="main-footer">
    <div class="pull-right hidden-xs">Version 1.0</div>
    Copyright © 2018 PrintSoft. All rights reserved.</footer>


   
</asp:Content>

