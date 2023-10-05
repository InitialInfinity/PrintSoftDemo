<%@ Page Title="" Language="C#" MasterPageFile="~/Settings/Settings.master" AutoEventWireup="true" CodeFile="general_settings.aspx.cs" validateRequest="false" Inherits="admin_panel_Settings_general_settings" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
       
    <style>
.switch {
  position: relative;
  display: inline-block;
  width: 60px;
  height: 34px;
}

.switch input {display:none;}

.slider {
  position: absolute;
  cursor: pointer;
  top: 0;
  left: 0;
  right: 0;
  bottom: 0;
  background-color: #ccc;
  -webkit-transition: .4s;
  transition: .4s;
}

.slider:before {
  position: absolute;
  content: "";
  height: 26px;
  width: 26px;
  left: 4px;
  bottom: 4px;
  background-color: white;
  -webkit-transition: .4s;
  transition: .4s;
}

input:checked + .slider {
  background-color: #2196F3;
}

input:focus + .slider {
  box-shadow: 0 0 1px #2196F3;
}

input:checked + .slider:before {
  -webkit-transform: translateX(26px);
  -ms-transform: translateX(26px);
  transform: translateX(26px);
}

/* Rounded sliders */
.slider.round {
  border-radius: 34px;
}

.slider.round:before {
  border-radius: 50%;
}
</style>
<script>
    function UserJSFunctionValidate()
{
   if(document.getElementById('<%=Txt_authentication_Key.ClientID%>').value.length==0)
{
alert("Please Enter Authentication Key !!!");
return false;
   }
    if(document.getElementById('<%=Txt_country.ClientID%>').value.length==0)
{
alert("Please Enter Country Code  !!!");
return false;
    }
        if(document.getElementById('<%=Txt_sender_id.ClientID%>').value.length==0)
{
alert("Please Enter Sender ID  !!!");
return false;
        }
         if(document.getElementById('<%=Txt_route.ClientID%>').value.length==0)
{
alert("Please Enter Route  !!!");
return false;
         }
         if (!(document.getElementById('<%=Txt_sender_id.ClientID%>').value.length == 6))
{
        alert("Please Enter 6 Character Sender ID !!!");
return false;
    }
return true;
    }
    function UserJSFunctionValidate2()
{
   if(document.getElementById('<%=Txt_email.ClientID%>').value.length==0)
{
alert("Please Enter Email ID !!!");
return false;
   }
   if (!(/^\w+([\.-]?\w+)*@\w+([\.-]?\w+)*(\.\w{2,3})+$/.test(document.getElementById('<%=Txt_email.ClientID%>').value)))
{  
        alert("You Have Entered an Invalid Email Address!");
        return false;
    }
    if(document.getElementById('<%=Txt_password.ClientID%>').value.length==0)
{
alert("Please Enter Password !!!");
return false;
    }
        if(document.getElementById('<%=Txt_port.ClientID%>').value.length==0)
{
alert("Please Enter Port  !!!");
return false;
        }
         if(document.getElementById('<%=Txt_subject.ClientID%>').value.length==0)
{
alert("Please Enter Subject  !!!");
return false;
         }
         if(document.getElementById('<%=Txt_smtp.ClientID%>').value.length==0)
{
alert("Please Enter SMTP  !!!");
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
      <h1>General Settings</h1>
      <ol class="breadcrumb">
        <li><a href="#">Settings</a></li>
        <li><i class="fa fa-angle-right"></i> General Settings</li>
      </ol>
    </section>
    <section class="content">
      <div class="row m-b-3">
        
        <div class="col-md-12">
          <div class="card">
            
            <!-- Nav tabs -->
            <ul class="nav nav-tabs customtab" role="tablist">
              <li class="nav-item"> <a class="nav-link active" data-toggle="tab" href="#feature" role="tab"><span class="hidden-sm-up"></span> <span class="hidden-xs-down">Feature</span></a> </li>
              <li class="nav-item"> <a class="nav-link" data-toggle="tab" href="#sms" role="tab"><span class="hidden-sm-up"></span> <span class="hidden-xs-down">SMS Configuration</span></a> </li>
             <%-- <li class="nav-item"> <a class="nav-link" data-toggle="tab" href="#email" role="tab"><span class="hidden-sm-up"></span> <span class="hidden-xs-down">Email Configuration</span></a> </li>--%>
              <li class="nav-item"> <a class="nav-link" data-toggle="tab" href="#note" role="tab"><span class="hidden-sm-up"></span> <span class="hidden-xs-down">Term & Conditions</span></a> </li>
              <li class="nav-item"> <a class="nav-link" data-toggle="tab" href="#otp" role="tab"><span class="hidden-sm-up"></span> <span class="hidden-xs-down">OTP</span></a> </li>
            </ul>
            <!-- Tab panes -->
            <div class="tab-content">
              <div class="tab-pane active p-20" id="feature" role="tabpanel">
                <div class="pad-20">
                      <div class="card-body">
              <div class="form-horizontal form-bordered">
                  <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
                  <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                      <ContentTemplate>
                <div class="form-body">
                    <div class="form-group row">
                    <label class="control-label text-right col-md-3">Sale Invoice Created SMS</label>
                    <div class="col-md-9">
                       
                    <label class="switch">
                         <asp:CheckBox ID="CheckBox1" checked="true" runat="server" AutoPostBack="True" OnCheckedChanged="CheckBox1_CheckedChanged" />
                         <span class="slider round"></span>
                    </label>
                      </div>
                  </div>
                    <hr/>
                   <%-- <div class="form-group row">
                    <label class="control-label text-right col-md-3">Sale Invoice Created Mail</label>
                    <div class="col-md-9">
                       
                    <label class="switch">
                         <asp:CheckBox ID="CheckBox2" checked="true" runat="server" AutoPostBack="True" OnCheckedChanged="CheckBox2_CheckedChanged" />
                         <span class="slider round"></span>
                    </label>
                      </div>
                  </div>--%>
                    <hr/>
                     <div class="form-group row">
                    <label class="control-label text-right col-md-3">Delete Option (For Invoices)</label>
                    <div class="col-md-9">
                       
                    <label class="switch">
                         <asp:CheckBox ID="CheckBox3" checked="true" runat="server" AutoPostBack="True" OnCheckedChanged="CheckBox3_CheckedChanged" />
                         <span class="slider round"></span>
                    </label>
                      </div>
                  </div>
                    <hr/>
                  <div class="form-group row">
                    <label class="control-label text-right col-md-3">OTP (For Login)</label>
                    <div class="col-md-9">
                       
                    <label class="switch">
                         <asp:CheckBox ID="CheckBox4" checked="true" runat="server" AutoPostBack="True" OnCheckedChanged="CheckBox4_CheckedChanged" />
                         <span class="slider round"></span>
                    </label>
                      </div>
                  </div>
                    <hr/>

                    
                </div>
                   </ContentTemplate>
                </asp:UpdatePanel>
              </div>
            </div>  
                    
      


                </div>
              </div>
              <div class="tab-pane p-20" id="sms" role="tabpanel">
                <div class="pad-20">
                
                      <div class="card-body">
              <div class="form-horizontal form-bordered">
                <div class="form-body">
                  <div class="form-group row">
                    <label class="control-label text-right col-md-3">Authentication Key<span style="color:red;">*</span></label>
                    <div class="col-md-9">
                      
                      <asp:TextBox ID="Txt_authentication_Key" readonly="true" class="form-control" runat="server"></asp:TextBox>
                      </div>
                  </div>
                   <div class="form-group row">
                    <label class="control-label text-right col-md-3">Country Code<span style="color:red;">*</span></label>
                    <div class="col-md-9">
                       <asp:TextBox ID="Txt_country" readonly="true" class="form-control" runat="server"></asp:TextBox>
                      </div>
                  </div>
                    <div class="form-group row">
                    <label class="control-label text-right col-md-3">Sender Id<span style="color:red;">*</span></label>
                    <div class="col-md-9">
                       <asp:TextBox ID="Txt_sender_id" readonly="true" class="form-control" runat="server" maxlength="6"></asp:TextBox>
                      </div>
                  </div>
                  <div class="form-group row">
                    <label class="control-label text-right col-md-3">Route<span style="color:red;">*</span></label>
                    <div class="col-md-9">
                     <asp:TextBox ID="Txt_route" readonly="true" class="form-control" runat="server"></asp:TextBox>
                         </div>
                  </div>
                    
                   
                    
                </div>
                <div class="form-actions">
                  <div class="row">
                    <div class="col-md-12">
                      <div class="row">
                        <div class="offset-sm-3 col-md-9">
                          
                          <asp:Button ID="Btn_submit" class="btn btn-success" runat="server" Text="Update" OnClientClick="return UserJSFunctionValidate()" OnClick="Btn_submit_Click"  />
                          
                          <asp:Button ID="Btn_cencel" class="btn btn-inverse" runat="server" Text="Cancel" />

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
              <div class="tab-pane  p-20" id="email" role="tabpanel">
                <div class="pad-20">
               
                    <div class="card-body">
              <div class="form-horizontal form-bordered">
                <div class="form-body">
                  <div class="form-group row">
                    <label class="control-label text-right col-md-3">Email Id<span style="color:red;">*</span></label>
                    <div class="col-md-9">
                      
                      <asp:TextBox ID="Txt_email"  class="form-control" runat="server"></asp:TextBox>
                      </div>
                  </div>
                   <div class="form-group row">
                    <label class="control-label text-right col-md-3">Password<span style="color:red;">*</span></label>
                    <div class="col-md-9">
                       <asp:TextBox ID="Txt_password"  class="form-control" runat="server" type="password"></asp:TextBox>
                      </div>
                  </div>
                    <div class="form-group row">
                    <label class="control-label text-right col-md-3">Port<span style="color:red;">*</span></label>
                    <div class="col-md-9">
                       <asp:TextBox ID="Txt_port"  class="form-control" runat="server"></asp:TextBox>
                      </div>
                  </div>
                  <div class="form-group row">
                    <label class="control-label text-right col-md-3">Subject<span style="color:red;">*</span></label>
                    <div class="col-md-9">
                     <asp:TextBox ID="Txt_subject"  class="form-control" runat="server"></asp:TextBox>
                         </div>
                  </div>
                    <div class="form-group row">
                    <label class="control-label text-right col-md-3">SMTP Server<span style="color:red;">*</span></label>
                    <div class="col-md-9">
                     <asp:TextBox ID="Txt_smtp"  class="form-control" runat="server"></asp:TextBox>
                         </div>
                  </div>
                    
                   
                    
                </div>
                <div class="form-actions">
                  <div class="row">
                    <div class="col-md-12">
                      <div class="row">
                        <div class="offset-sm-3 col-md-9">
                          
                          <asp:Button ID="Button1" class="btn btn-success" runat="server" Text="Update" OnClientClick="return UserJSFunctionValidate2()" OnClick="Button1_Click"  />
                          
                          <asp:Button ID="Button2" class="btn btn-inverse" runat="server" Text="Cancel" />

                        <asp:Label ID="Label1" runat="server" Text=""></asp:Label>
                        </div>
                      </div>
                    </div>
                  </div>
                </div>
              </div>
            </div>  
                    
      


                </div>
              </div>
                <div class="tab-pane  p-20" id="note" role="tabpanel">
                <div class="pad-20">
               
                    <div class="card-body">
              <div class="form-horizontal form-bordered">
                <div class="form-body">
                  <div class="form-group row">
                    <label class="control-label col-md-2" style="padding-right:8px">Term & Conditions<span style="color:red;">*</span></label>
                    <div class="col-md-10">
                      
                      <asp:TextBox ID="Txt_note"  class="summernote" runat="server" TextMode="MultiLine"></asp:TextBox>
                      </div>
                  </div>
                    
                   
                    
                </div>
                <div class="form-actions">
                  <div class="row">
                    <div class="col-md-12">
                      <div class="row">
                        <div class="offset-sm-3 col-md-9">
                          
                          <asp:Button ID="Button3" class="btn btn-success" runat="server" Text="Update"  OnClick="Button3_Click"  />
                          
                          <asp:Button ID="Button4" class="btn btn-inverse" runat="server" Text="Cancel" />

                        <asp:Label ID="Label2" runat="server" Text=""></asp:Label>
                        </div>
                      </div>
                    </div>
                  </div>
                </div>
              </div>
            </div>  
                    
                </div>
              </div>


                <div class="tab-pane  p-20" id="otp" role="tabpanel">
                <div class="pad-20">
                    <asp:UpdatePanel ID="UpdatePanel2" runat="server"><ContentTemplate>
                    <div class="card-body">
              <div class="form-horizontal form-bordered">
                <div class="form-body">
                  <div class="form-group row">
                    <label class="control-label text-right col-md-3">Contact no.<span style="color:red;">*</span></label>
                    <div class="col-md-6">
                      
                      <asp:TextBox ID="Txt_otpno" readonly="true" class="form-control" runat="server"></asp:TextBox>
                      </div>
                       <asp:Button ID="Button7" class="btn btn-warning" runat="server" Text="Send OTP"  OnClick="Button7_Click"  />
                  </div>
                    <div class="form-group row">
                    <label class="control-label text-right col-md-3">Enter OTP<span style="color:red;">*</span></label>
                    <div class="col-md-6">
                      <asp:TextBox ID="Txt_entotp" readonly="true" class="form-control" runat="server"></asp:TextBox>
                      </div>
                  </div>
                   
                    
                </div>
                <div class="form-actions">
                  <div class="row">
                    <div class="col-md-12">
                      <div class="row">
                        <div class="offset-sm-3 col-md-9">
                          
                          <asp:Button ID="Button5" class="btn btn-success" runat="server" Text="Verify & Update"  OnClick="Button5_Click"  />
                          

                        <asp:Label ID="lbl_alert" style="color:red;" runat="server" Text=""></asp:Label>
                            <asp:HiddenField ID="lbl_otp" runat="server"></asp:HiddenField>
                        </div>
                      </div>
                    </div>
                  </div>
                </div>
              </div>
            </div>  
                    </ContentTemplate></asp:UpdatePanel>
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
  

   
</asp:Content>

