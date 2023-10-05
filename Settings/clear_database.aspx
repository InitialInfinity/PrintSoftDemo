<%@ Page Title="" Language="C#" MasterPageFile="~/Settings/Settings.master" AutoEventWireup="true" CodeFile="clear_database.aspx.cs" Inherits="Settings_clear_database" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
   
    <script>
    function stage1()
{
   if(document.getElementById('<%=Txt_company_email.ClientID%>').value.length==0)
{
alert("Please Enter Company Email !!!");
return false;
   }
    if(document.getElementById('<%=Txt_comapany_gst.ClientID%>').value.length==0)
{
alert("Please Enter Company GST No.  !!!");
return false;
    }
      
  
return true;
    }
        function stage2()
{
   if(document.getElementById('<%=Txt_email.ClientID%>').value.length==0)
{
alert("Please Enter Admin Email !!!");
return false;
   }
    if(document.getElementById('<%=Txt_password.ClientID%>').value.length==0)
{
alert("Please Enter Admin Password  !!!");
return false;
    }
      
  
return true;
}
        </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
        <!-- Content Wrapper. Contains page content -->
  <div class="content-wrapper"> 
    <!-- Content Header (Page header) -->
    <section class="content-header sty-one">
      <h1>Clear Database</h1>
      <ol class="breadcrumb">
        <li><a href="#">Settings</a></li>
        <li><i class="fa fa-angle-right"></i> Clear Database</li>
      </ol>
    </section>
      <asp:Panel ID="Panel1" runat="server">
         
      <section class="content">

      <div class="row m-t-3">
        <div class="col-lg-12">
          <div class="card">
            <div class="card-header bg-blue">
              <h5 class="m-b-0">Company Verification</h5>
            </div>
            <div class="card-body">
              <div class="form-horizontal form-bordered">
               <div class="form-body">
                  <div class="form-group row">
                    <label class="control-label text-right col-md-3">Company Email<span style="color:red;">*</span></label>
                    <div class="col-md-6">
                      
                      <asp:TextBox ID="Txt_company_email"  class="form-control" runat="server"></asp:TextBox>
                      </div>
                  </div>
                   <div class="form-group row">
                    <label class="control-label text-right col-md-3">Company GST no<span style="color:red;">*</span></label>
                    <div class="col-md-6">
                       <asp:TextBox ID="Txt_comapany_gst"  class="form-control" runat="server"></asp:TextBox>
                      </div>
                  </div>
                  
                    
                </div>
                 <div class="form-actions">
                  <div class="row">
                    <div class="col-md-12">
                      <div class="row">
                        <div class="offset-sm-3 col-md-9">
                          
                          <asp:Button ID="Btn_submit" class="btn btn-success" runat="server" Text="Next" OnClientClick="return stage1()" OnClick="Btn_submit_Click" />
                          
                         

                        <asp:Label ID="lbl_msg" Style="color:red;" runat="server" Text=""></asp:Label>
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
              
          </asp:Panel>
      <asp:Panel ID="Panel2" runat="server">
           
      <section class="content">
         
      <div class="row m-t-3">
        <div class="col-lg-12">
          <div class="card">
            <div class="card-header bg-blue">
              <h5 class="m-b-0">Admin Verification</h5>
            </div>
            <div class="card-body">
              <div class="form-horizontal form-bordered">
               <div class="form-body">
                  <div class="form-group row">
                    <label class="control-label text-right col-md-3">Admin Username<span style="color:red;">*</span></label>
                    <div class="col-md-6">
                      
                      <asp:TextBox ID="Txt_email"  class="form-control" runat="server"></asp:TextBox>
                      </div>
                  </div>
                   <div class="form-group row">
                    <label class="control-label text-right col-md-3">Admin Password<span style="color:red;">*</span></label>
                    <div class="col-md-6">
                       <asp:TextBox ID="Txt_password"  class="form-control" runat="server"></asp:TextBox>
                      </div>
                  </div>
                  
                    
                </div>
                 <div class="form-actions">
                  <div class="row">
                    <div class="col-md-12">
                      <div class="row">
                        <div class="offset-sm-3 col-md-9">
                          
                          <asp:Button ID="Button1" class="btn btn-success" runat="server" Text="Next" OnClientClick="return stage2()" OnClick="Button1_Click" />
                          
                         

                        <asp:Label ID="lbl_msg2" Style="color:red;" runat="server" Text=""></asp:Label>
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
          </asp:Panel>
      <asp:Panel ID="Panel3" runat="server">
           
     <section class="content">
          
      <div class="row m-t-3">
        <div class="col-lg-12">
          <div class="card">
            <div class="card-header bg-blue">
              <h5 class="m-b-0">Clear All Database</h5>
            </div>
            <div class="card-body">
              <div class="form-horizontal form-bordered">
               
                 
                <div class="form-actions">
                  <div class="row">
                    <div class="col-md-12">
                      <div class="row">
                        <div class="offset-sm-4 col-md-8">
                          
                           <asp:Button ID="btn_clear" runat="server" class="btn btn-danger" Text="Clear All Database" OnClientClick="return confirm('Do You Want to Clear All Database? You Will Lost Your All Data!!!');" OnClick="btn_clear_Click" />
                          
                          

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

        
 </section>
                
      </asp:Panel>
   </div>
  <!-- /.content-wrapper -->
  <footer class="main-footer">
    <div class="pull-right hidden-xs">Version 1.0</div>
    Copyright © 2018 PrintSoft. All rights reserved.</footer>

</asp:Content>

