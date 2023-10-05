<%@ Page Language="C#" AutoEventWireup="true" CodeFile="register.aspx.cs" Inherits="register" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Register Now</title>
    <meta charset="utf-8"/>
<meta http-equiv="X-UA-Compatible" content="IE=edge"/>

<!-- Tell the browser to be responsive to screen width -->
<meta content="width=device-width, initial-scale=1, maximum-scale=1, user-scalable=no" name="viewport"/>

<!-- v4.0.0 -->
<link rel="stylesheet" href="dist/bootstrap/css/bootstrap.min.css"/>

<!-- Favicon -->
<link rel="icon" type="image/png" sizes="16x16" href="dist/img/favicon-16x16.png"/>

<!-- Google Font -->
<link href="https://fonts.googleapis.com/css?family=Poppins:300,400,500,600,700" rel="stylesheet"/>

<!-- Theme style -->
<link rel="stylesheet" href="dist/css/style.css"/>
<link rel="stylesheet" href="dist/css/font-awesome/css/font-awesome.min.css"/>
<link rel="stylesheet" href="dist/css/et-line-font/et-line-font.css"/>
<link rel="stylesheet" href="dist/css/themify-icons/themify-icons.css"/>
<link rel="stylesheet" href="dist/css/simple-lineicon/simple-line-icons.css"/>
    <script>
        function ShowError() {

            $('#ErrorShow').modal('show');
        }

function JSFunctionValidate()
{

    
    if (document.getElementById('<%=Txt_email.ClientID%>').value.length == 0)
{
alert("Please Enter Email");
return false;
    }
    if (document.getElementById('<%=Txt_password.ClientID%>').value.length == 0)
{
alert("Please Enter Password");
return false;
}
return true;
}
       
            </script>
</head>
<body class="hold-transition login-page sty1">
<div class="login-box sty1">
  <div class="login-box-body sty1">
  <div class="login-logo">
    <a href="Default.aspx"><img src="dist/img/logo.png" height="100%" width="100%" alt=""></a>
  </div>
    <p class="login-box-msg">Register Yourself on PrintGSTSoft</p>
    <form runat="server" method="post">
<asp:Panel ID="Panel1" runat="server">
         <div class="form-group has-feedback">
     <%--   <asp:TextBox ID="Txt_id" class="form-control sty1" placeholder="Company Name" runat="server" ></asp:TextBox>--%>
<asp:Label ID="lbl_id" runat="server" Text="" class="form-control sty1"></asp:Label>
      </div>
        </asp:Panel>
        <div class="form-group has-feedback">
        <asp:TextBox ID="Txt_company_name" class="form-control sty1" placeholder="Company Name" runat="server" ></asp:TextBox>
      </div>
        <div class="form-group has-feedback">
        <asp:TextBox ID="Txt_owner_name" class="form-control sty1" placeholder="Owner Name" runat="server" ></asp:TextBox>
      </div>
        <div class="form-group has-feedback">
        <asp:TextBox ID="Txt_contact" class="form-control sty1" placeholder="Contact" runat="server" ></asp:TextBox>
      </div>
        <div class="form-group has-feedback">
        <asp:TextBox ID="Txt_address" class="form-control sty1" placeholder="Address" runat="server" ></asp:TextBox>
      </div>
        <div class="form-group has-feedback">
        <asp:TextBox ID="Txt_gst" class="form-control sty1" placeholder="Gst no" runat="server" ></asp:TextBox>
      </div>
         <div class="form-group has-feedback">
        <asp:TextBox ID="Txt_website" class="form-control sty1" placeholder="Website" runat="server" ></asp:TextBox>
      </div>
        <div class="form-group has-feedback">
        <asp:TextBox ID="Txt_email" class="form-control sty1" placeholder="Email" runat="server" ></asp:TextBox>
      </div>
       
      <div class="form-group has-feedback">
        <asp:TextBox ID="Txt_password" class="form-control sty1" placeholder="Password" runat="server" TextMode="Password"></asp:TextBox>
      </div>
    
        <div class="col-xs-8">
          <div class="checkbox icheck">
            
            <!--<a href="#" class="pull-right"><i class="fa fa-lock"></i> Forgot pwd?</a> </div>-->
        </div>
        <!-- /.col -->
        <div class="col-xs-4 m-t-1">
          
          <asp:Button ID="Btn_sign_in" class="btn btn-primary btn-block btn-flat" runat="server" Text="Register Now" OnClientClick="return JSFunctionValidate();" OnClick="Btn_sign_in_Click" />
          <br>
            <p style="color:red"><asp:Label ID="Lbl_message" runat="server" Text=""></asp:Label></p>
        </div>
        <!-- /.col --> 
      </div>

        <!-- Modal -->
  <div class="modal fade" id="ErrorShow" role="dialog">
    <div class="modal-dialog">
    
      <!-- Modal content-->
      <div class="modal-content">
        <div class="modal-header">
          <button type="button" class="close" data-dismiss="modal">&times;</button>
          <h4 class="modal-title">Error</h4>
        </div>
        <div class="modal-body">
          <p><asp:Label ID="lbl_error" runat="server" Text=""></asp:Label></p>
        </div>
        <div class="modal-footer">
          <button type="button" class="btn btn-default" data-dismiss="modal">Close</button>
        </div>
      </div>
      
    </div>
  </div>
    </form>
    
    
    
  </div>
  <!-- /.login-box-body --> 
</div>
<!-- /.login-box --> 

 <!-- jQuery 3 --> 
<script src="dist/js/jquery.min.js"></script> 

<!-- v4.0.0-alpha.6 --> 
<script src="dist/bootstrap/js/bootstrap.min.js"></script> 

<!-- template --> 
<script src="dist/js/niche.html"></script>
</body>
</html>
