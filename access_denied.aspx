<%@ Page Title="" Language="C#" MasterPageFile="~/Main.master" AutoEventWireup="true" CodeFile="access_denied.aspx.cs" Inherits="access_denied" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
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
  <style>
      .content-wrapper {
    min-height: 100%;
    background-color: white;
    z-index: 800;
}
      </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="content-wrapper"> 
    <!-- Content Header (Page header) -->
    <section class="content-header">
<div>
  <div class="error-page text-center">
    <h2 class="headline text-red"><i class="fa fa-lock"></i></h2>
    <div>
      <h3><i class="fa fa-warning text-red"></i> Permission Denied!</h3>
      <p> You do not have permission to access this page or perform this operation, please refer to your software administrator.</p>
      
    </div>
    <!-- /.error-content --> 
  </div>
  
</div>
        </section>
        </div>
    <footer class="main-footer">
    <div class="pull-right hidden-xs">Version 1.0</div>
    Copyright © 2018 PrintSoft. All rights reserved.</footer>
</asp:Content>

