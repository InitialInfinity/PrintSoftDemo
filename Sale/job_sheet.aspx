<%@ Page Title="" Language="C#" MasterPageFile="~/Sale/Sale.master" AutoEventWireup="true" CodeFile="job_sheet.aspx.cs" Inherits="Sale_job_sheet" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
   
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
       <!-- Content Wrapper. Contains page content -->
    <div class="content-wrapper">
        <!-- Content Header (Page header) -->
        <section class="content-header sty-one">
            <h1>Job Estimation Sheet</h1>
            <ol class="breadcrumb">
                <li><a href="#">Sale</a></li>
                <li><i class="fa fa-angle-right"></i>Job Estimation Sheet</li>
            </ol>
        </section>
        <!-- Main content -->

        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">

            <ContentTemplate>
                <section class="content">
                    
                    <div class="card">
                        <div class="card-body">
                            <!-- Main content -->
                            <div style="text-align:right;"> <br/><a href="print_job.aspx?invoice=<%=invoice %>"><butto class="btnprint" ><i class="fa fa-print"></i> Print</butto></a></div>
                            <br/>
                            <section class="invoice">
                                <!-- title row -->
                                <div class="row">
                                    <div class="col-lg-12 m-b-3" style="background-color:black;">
                                        <h3 class="text-center" style="color:white;margin-top: 5px;"> Job Estimation Sheet </h3>
                                    </div>
                                    <!-- /.col -->
                                </div>

                                <div class="container">
                                <!-- info row -->

                                  
                                <div class="form-group row">
                                    
                                    <label class="control-label col-md-3"><b>Invoice no. : </b></label>
                                    <div class="col-md-3">
                                      <asp:Label ID="lbl_invoice" runat="server" Text=""></asp:Label>
                                    </div>
                                    <label class="control-label col-md-3"><b>Date : </b></label>
                                    <div class="col-md-3">
                                      <asp:Label ID="lbl_date" runat="server" Text=""></asp:Label>
                                    </div>
                                </div>
                                <div class="form-group row">
                                    <label class="control-label col-md-3"><b>Authorised Person : </b></label>
                                    <div class="col-md-3">
                                       <asp:Label ID="lbl_owner" runat="server" Text=""></asp:Label>
                                    </div>
                                    <label class="control-label col-md-3"><b>Contact : </b></label>
                                    <div class="col-md-3">
                                       <asp:Label ID="lbl_contact" runat="server" Text=""></asp:Label>
                                    </div>
                                </div>
                              
                                </div>
                                <hr/>
                                <div class="row ">
                                    <div class="col-xs-12 table-responsive">
                                        <asp:GridView ID="GridView2" class="table table-striped" runat="server" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3" >
                                          
                                          
                                            <FooterStyle BackColor="White" ForeColor="#000066" />
                                            <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
                                            <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
                                            <RowStyle ForeColor="#000066" />
                                            <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                                            <SortedAscendingCellStyle BackColor="#F1F1F1" />
                                            <SortedAscendingHeaderStyle BackColor="#007DBB" />
                                            <SortedDescendingCellStyle BackColor="#CAC9C9" />
                                            <SortedDescendingHeaderStyle BackColor="#00547E" />

                                        </asp:GridView>
                                    </div>
                                </div>
                                <div class="form-group row">
                                    <label class="control-label col-md-3"><b>Income Total : </b></label>
                                    <div class="col-md-3">
                                       <asp:Label ID="lbl_income_total" runat="server" Text=""></asp:Label>
                                    </div>
                                    
                                </div>
                            
                                 <div class="row ">
                                    <div class="col-xs-12 table-responsive">
                                        <asp:GridView ID="GridView1" class="table table-striped" runat="server" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3" OnDataBound="GridView1_DataBound" OnRowDataBound="GridView1_RowDataBound" OnPageIndexChanging="GridView1_PageIndexChanging" OnRowDeleting="GridView1_RowDeleting" OnRowCreated="GridView1_RowCreated" OnRowCommand="GridView1_RowCommand" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" >
                                           <Columns>
                                                <%--<asp:ButtonField CommandName="Delete" HeaderText="Action" ShowHeader="True" Text="Delete" />--%>
                                               
                                                        <asp:CommandField HeaderText="Select" ShowHeader="True" ShowSelectButton="True" />

                                           </Columns>

                                          
                                            <FooterStyle BackColor="White" ForeColor="#000066" />
                                            <HeaderStyle BackColor="black" Font-Bold="True" ForeColor="White" />
                                            <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
                                            <RowStyle ForeColor="#000066" />
                                            <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                                            <SortedAscendingCellStyle BackColor="#F1F1F1" />
                                            <SortedAscendingHeaderStyle BackColor="#007DBB" />
                                            <SortedDescendingCellStyle BackColor="#CAC9C9" />
                                            <SortedDescendingHeaderStyle BackColor="#00547E" />

                                        </asp:GridView>
                                    </div>
                                </div>
                                <div class="form-group row">
                                    <label class="control-label col-md-3"><b>Expense Total : </b></label>
                                    <div class="col-md-3">
                                       <asp:Label ID="lbl_expense_total" runat="server" Text=""></asp:Label>
                                    </div>
                                    
                                </div>
                                 <div class="row">
                                    <label class="control-label col-md-2" style="font-size:20px"><b>Profit : </b></label>
                                    <div class="col-md-3">
                                       <asp:Label ID="lbl_profit" runat="server"  style="font-size:20px" Text=""></asp:Label>
                                    </div>
                                     <div class="col-md-3">
                                   
                                    </div>
                                    <div class="col-md-4 text-right">
                                    <asp:Button ID="Button4" class="btn btn-primary" Style="background-color:red !important;" runat="server" Text="Delete Entry" OnClick="Button2_Click" />    
                                    </div>
                                    
                                    </div>
                                <br/>
                                
                                <table class="table">
                                    <thead>
                                        <tr>

                                            <th scope="col">Expenses Note</th>
                                            <th scope="col">Amount</th>
                                           
                                        </tr>
                                    </thead>
                                    <tbody>
                                        <tr>

                                            <td>
                                                <asp:TextBox ID="txt_expenses" class="form-control" runat="server"></asp:TextBox></td>
                                            <td>
                                                <asp:TextBox ID="txt_amount" class="form-control" runat="server"></asp:TextBox></td>
                                            <td><asp:Button ID="Btn_cart" class="btn btn-primary pull-right" Style="margin-right: 5px;" runat="server" Text="Add" OnClick="Btn_cart_Click" /></td>
                                           
                                        </tr>

                                    </tbody>
                                </table>
                             
                             
                            </section>
                            <!-- /.content -->
                        </div>
                    </div>
                </section>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
    <!-- /.content-wrapper -->
    <footer class="main-footer">
        <div class="pull-right hidden-xs">Version 1.00</div>
        Copyright © 2018 PrintSoft. All rights reserved.
    </footer>
 
     
</asp:Content>

