<%@ Page Title="" Language="C#" MasterPageFile="~/CustomerRate/Rate.master" AutoEventWireup="true" CodeFile="List_of_Rate.aspx.cs" Inherits="CustomerRate_List_of_Rate" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
       <!-- Content Wrapper. Contains page content -->
   <!-- Content Wrapper. Contains page content -->
  <div class="content-wrapper"> 
    <!-- Content Header (Page header) -->
    <section class="content-header sty-one">
      <h1>Data Tables</h1>
      <ol class="breadcrumb">
        <li><a href="#">Home</a></li>
        <li><i class="fa fa-angle-right"></i> Data Tables</li>
      </ol>
    </section>
    
    <!-- Main content -->
    <section class="content">
      
      <div class="card m-t-3">
      <div class="card-body">
      <h4 class="text-black">List Of Customer Rate</h4>
      <p>Customer Wise Rate System</p>
      <div class="table-responsive">
                  <table id="example1" class="table table-bordered table-striped">
                <thead>
                <tr>
                  <th>#</th>
                  <th>Customer Name</th>
                  <th>Product Name</th>
                  <th>Rate</th>
                  <th>Action</th>
                </tr>
                </thead>
                <tbody>

       <asp:Repeater ID="Repeater1" runat="server" OnItemCommand="Repeater1_ItemCommand">
           <ItemTemplate>
                  <tr>
                  <td>
                      <asp:Label ID="lbl_id" runat="server" Text='<%# Eval("r_id") %>'></asp:Label></td>
                  <td>
                          <asp:Label ID="lbl_Customer_Name" runat="server" Text='<%# Eval("cust_name") %>'></asp:Label>
                  </td>
                  <td> <asp:Label ID="lbl_Pro_name" runat="server" Text='<%# Eval("p_name") %>'></asp:Label></td>
                  <td>  <asp:Label ID="lbl_rate" runat="server" Text='<%# Eval("r_rate") %>'></asp:Label></td>
                  <td> 
                      <asp:LinkButton ID="LinkButton1" runat="server" OnClientClick="return confirm('Do you want to delete this Product?');" OnClick="DeleteProduct"><i  class="fa fa-trash-o"></i></asp:LinkButton>
                       <asp:LinkButton ID="LinkButton3" runat="server" CommandName="editid" CommandArgument='<%# Eval("r_id") %>'><i style="padding-left:10px" class="fa fa-edit"></i></asp:LinkButton>
                      </td>
                </tr>

              
           </ItemTemplate>
       </asp:Repeater>
             
             
                </tbody>
              
              </table>
                  </div>
      </div></div>
    </section>
    <!-- /.content --> 
  </div>

    <!-- Modal -->
  <div class="modal fade" id="myModal2" role="dialog">
    <div class="modal-dialog">
    
      <!-- Modal content-->
      <div class="modal-content">
        <div class="modal-header">
            <h4 class="modal-title">Edit Panel<asp:HiddenField ID="Txt_id" runat="server" /></h4>
          <button type="button" class="close" data-dismiss="modal">&times;</button>
          
        </div>
        <div class="modal-body">
          <table class="table table-hover">
  
  <tbody>
        <tr>
      <th scope="col">Customer Name</th>
      <td><asp:TextBox ID="Txt_cname" class="form-control" runat="server" disabled="true"></asp:TextBox></td>     
    </tr>

       <tr>
      <th scope="col">Product Name</th>
      <td><asp:TextBox ID="Txt_pname" class="form-control" runat="server" disabled="true"></asp:TextBox></td>    
    </tr>

   <%-- <tr>
      <th scope="col">Unit</th>
      <td><asp:DropDownList ID="Dd_unit" class="form-control" runat="server">
                             <asp:ListItem Value="Sqft">Sqft</asp:ListItem>
                             <asp:ListItem Value="Inch">Inch</asp:ListItem>
                             <asp:ListItem Value="Pcs">Pcs</asp:ListItem>
                         </asp:DropDownList></td>  
    </tr>--%>

    <%--   <tr>
      <th scope="col">cgst</th>
      <td><asp:dropdownlist ID="Dd_cgst" class="form-control" runat="server">
                            <asp:ListItem Value="0">0 %</asp:ListItem>
                            <asp:ListItem Value="5">5 %</asp:ListItem>
                            <asp:ListItem Value="6">6 %</asp:ListItem>
                            <asp:ListItem Value="9">9 %</asp:ListItem>
                            <asp:ListItem Value="12">12 %</asp:ListItem>
                            <asp:ListItem Value="18">18 %</asp:ListItem>
                            <asp:ListItem Value="28">28 %</asp:ListItem>
                        </asp:dropdownlist></td>     
    </tr>--%>

     <%--  <tr>
      <th scope="col">sgst</th>
      <td><asp:dropdownlist  ID="Dd_sgst" class="form-control" runat="server">
                           <asp:ListItem Value="0">0 %</asp:ListItem>
                            <asp:ListItem Value="5">5 %</asp:ListItem>
                            <asp:ListItem Value="6">6 %</asp:ListItem>
                            <asp:ListItem Value="9">9 %</asp:ListItem>
                            <asp:ListItem Value="12">12 %</asp:ListItem>
                            <asp:ListItem Value="18">18 %</asp:ListItem>
                            <asp:ListItem Value="28">28 %</asp:ListItem>
                       </asp:dropdownlist></td>  
    </tr>--%>

       <%--<tr>
      <th scope="col">igst</th>
      <td><asp:dropdownlist ID="Dd_igst" class="form-control" runat="server">
                          <asp:ListItem Value="0">0 %</asp:ListItem>
                            <asp:ListItem Value="5">5 %</asp:ListItem>
                            <asp:ListItem Value="6">6 %</asp:ListItem>
                            <asp:ListItem Value="9">9 %</asp:ListItem>
                            <asp:ListItem Value="12">12 %</asp:ListItem>
                            <asp:ListItem Value="18">18 %</asp:ListItem>
                            <asp:ListItem Value="28">28 %</asp:ListItem>
                       </asp:dropdownlist></td> 
    </tr>--%>

    <%--   <tr>
      <th scope="col">HSN Code</th>
      <td><asp:TextBox ID="Txt_hsn" class="form-control" runat="server"></asp:TextBox></td>  
    </tr>--%>

       <tr>
      <th scope="col">Rate</th>
      <td><asp:TextBox ID="Txt_rate"  placeholder="Rate" class="form-control" runat="server"></asp:TextBox></td>   
    </tr>

   <%--<tr>
      <th scope="col">Description</th>
      <td><asp:TextBox ID="Txt_description" class="form-control" runat="server" TextMode="MultiLine"></asp:TextBox></td> 
    </tr>--%>

  </tbody>
</table>
        </div>
        <div class="modal-footer">
             <asp:Label ID="lbl_msg" runat="server" Text=""></asp:Label>
             <asp:Button ID="Button1" class="btn btn-success" OnClientClick="return JSFunctionValidate()" runat="server" Text="Update" OnClick="Button1_Click" />
          <button type="button" class="btn btn-default" data-dismiss="modal">Close</button>
        </div>
      </div>
      
    </div>
  </div>

    <script type="text/javascript">
function ShowModel() {

            $('#myModal').modal('show');
}
function ShowModel2() {

    $('#myModal2').modal('show');
}
function ShowModel3() {

    $('#myModal3').modal('show');
}
function ShowModel4() {

    $('#myModal4').modal('show');
}
</script>

</asp:Content>

