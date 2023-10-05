<%@ Page Title="" Language="C#" MasterPageFile="~/Settings/Settings.master" AutoEventWireup="true" CodeFile="Database_Backup.aspx.cs" Inherits="admin_panel_Settings_Database_Backup" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
         
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
              <li class="nav-item"> <a class="nav-link active" data-toggle="tab" href="#sms" role="tab"><span class="hidden-sm-up"></span> <span class="hidden-xs-down">Backup Database</span></a> </li>
              <li class="nav-item"> <a class="nav-link" data-toggle="tab" href="#email" role="tab"><span class="hidden-sm-up"></span> <span class="hidden-xs-down">Restore Database</span></a> </li>
        
            </ul>
            <!-- Tab panes -->
            <div class="tab-content">
            
              <div class="tab-pane active p-20" id="sms" role="tabpanel">
                <div class="pad-20">
                    <div class="col-md-12">
                      <div class="row">
                        <div class="offset-sm-3 col-md-9">
                          
                    
                            <asp:Button ID="btn_backup" runat="server" class="btn btn-success" Text="Backup Your Database" OnClick="btn_backup_Click" />
                      

                          <span id="ContentPlaceHolder1_Lbl_message2"></span>
                        </div>
                      </div>
                    </div>

                    
      


                </div>
              </div>
              <div class="tab-pane  p-20" id="email" role="tabpanel">
                <div class="pad-20">
               

                    
      


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

