<%@ Page Title="" Language="C#" MasterPageFile="~/Stock/Stock.master" AutoEventWireup="true" CodeFile="Available_Stock.aspx.cs" Inherits="Stock_Available_Stock" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
   
     <!-- Content Wrapper. Contains page content -->
  <div class="content-wrapper"> 
    <!-- Content Header (Page header) -->
    <section class="content-header sty-one">
      <h1>Stock Management</h1>
      <ol class="breadcrumb">
        <li><a href="#">Master</a></li>
        <li><i class="fa fa-angle-right"></i> Stock Management</li>
      </ol>
    </section>
     <section class="content">
       <asp:Panel ID="Panel2" runat="server">
              <div class="alert alert-success" role="alert">
  <button type="button" class="close" data-dismiss="alert" aria-label="Close"><span aria-hidden="true">&times;</span></button>
  <strong>Success!</strong> New Product successfully added!
</div>     
        </asp:Panel>
         <asp:Panel ID="Panel3" runat="server">
              <div class="alert alert-success" role="alert">
  <button type="button" class="close" data-dismiss="alert" aria-label="Close"><span aria-hidden="true">&times;</span></button>
  <strong>Success!</strong> Product successfully updated!
</div>     
        </asp:Panel>
          <div class="row m-b-3">
        
        <div class="col-md-12">
          <div class="card">
            
            <!-- Nav tabs -->
          <%--  <ul class="nav nav-tabs customtab" role="tablist">
              <li class="nav-item"> <a class="nav-link active" data-toggle="tab" href="#sale" role="tab"><span class="hidden-sm-up"></span> <span class="hidden-xs-down">Sale</span></a> </li>
              <li class="nav-item"> <a class="nav-link" data-toggle="tab" href="#purchase" role="tab"><span class="hidden-sm-up"></span> <span class="hidden-xs-down">Purchase</span></a> </li>
             
            </ul>--%>
            <!-- Tab panes -->
            <div class="tab-content">
              <div class="tab-pane active" id="sale" role="tabpanel">
                  <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
                    <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                    <ContentTemplate>
                <div class="pad-20">
                <div class="card-body">
              <div class="form-horizontal form-bordered">
                <div class="row">
        <div class="col-md-4">
         <h4 class="text-black">Stock Management</h4>
        </div>
        
             <div class="col-md-8 exportbtn">
        <%--  <a href="roll_purchase.aspx"><button type="button" id="btn_mail"  title="Add New Customer" class="btn btn-primary4"> <i class="fa fa-plus"></i>Add Roll Puschase</button></a>--%>
         <%-- <button type="button" id="btn_excel" title="Export to Excel" runat="server" class="btn btnsqr btn-primary3 btngap" onserverclick="excel_export2"> <i class="fa fa-file-excel-o"></i> Excel</button>--%>
           
        <button type="button" id="btn_print" title="Print" onclick="printdiv('dropHere');" class="btn btnsqr btn-primary btngap"> <i class="fa fa-print"></i> Print</button>
     <%--    <button type="button" id="btn_pdf" title="Export to PDF" runat="server"  class="btn btnsqr btn-primary2" onserverclick="pdf_export"> <i class="fa fa-file-pdf-o"></i> PDF</button>--%>
        
      </div>
      </div>
      <br/>
      <div id="dropHere" class="table-responsive">
                  <table id="example1" class="table table-bordered table-striped">
                <thead>
                <tr>
                  <th>ID #</th>
                  <th>Product</th>
                  <th>Stock</th>
                  <th>Unit</th>
                  <%--<th>Stock Value</th>--%>
                  <th>CGST</th>
                  <th>SGST</th>
                  <th>IGST</th>
                  <th>HSN</th>
                  <th>Rate</th>
                  
                  <th class="no-print">Actions</th>
                </tr>
                </thead>
                <tbody>
                     
                <asp:Repeater ID="Repeater1" runat="server" OnItemCommand="Repeater1_ItemCommand">
              <ItemTemplate>
                   <tr>
                  <td>
              <asp:Label ID="lbl_id" runat="server" Text='<%# Eval("p_id") %>'></asp:Label></td>
                  <td>
              <asp:Label ID="lbl_product_name" runat="server" Text='<%# Eval("p_name") %>'></asp:Label></td>
                  <td><strong><asp:Label ID="Label1" runat="server" Text='<%# Eval("p_stock") %>'></asp:Label><strong/></td>
                  <td><asp:Label ID="lbl_unit" runat="server" Text='<%# Eval("p_unit") %>'></asp:Label></td>
                  <%--<td><strong><asp:Label ID="Label2" runat="server" Text='<%# Eval("p_value") %>'></asp:Label><strong/></td>--%>
                  <td><asp:Label ID="lbl_cgst" runat="server" Text='<%# Eval("p_cgst") %>'></asp:Label></td>
                  <td><asp:Label ID="lbl_sgst" runat="server" Text='<%# Eval("p_sgst") %>'></asp:Label></td>
                  <td><asp:Label ID="lbl_igst" runat="server" Text='<%# Eval("p_igst") %>'></asp:Label></td>
                  <td><asp:Label ID="lbl_hsn" runat="server" Text='<%# Eval("p_hsn_code") %>'></asp:Label></td>
                  <td><asp:Label ID="lbl_rate" runat="server" Text='<%# Eval("p_rate") %>'></asp:Label></td>
 
                  <td class="no-print"> <asp:LinkButton ID="LinkButton1" runat="server" OnClientClick="return confirm('Do you want to delete this Product?');" OnClick="DeleteProduct"><i  class="fa fa-trash-o"></i></asp:LinkButton>
                  <asp:LinkButton ID="LinkButton2" runat="server"  CommandName="showid" CommandArgument='<%# Eval("p_id") %>'><i style="padding-left:10px" class="fa fa-eye"></i></i></asp:LinkButton>
                  <asp:LinkButton ID="LinkButton3" runat="server" CommandName="editid" CommandArgument='<%# Eval("p_id") %>'><i style="padding-left:10px" class="fa fa-edit"></i></asp:LinkButton>
                      <!--<a href=""></a><a href=""><i style="padding-left:10px" class="fa fa-edit"></i></a><a href="" runat="server" ><i style="padding-left:10px" class="fa fa-trash-o"></i></a>-->
                 </td>
                </tr>
              </ItemTemplate>

          </asp:Repeater>
                <asp:Label ID="Lbl_msg2" Style="color:red" runat="server" Text=""></asp:Label>
                </tbody>
               
              </table>

                  </div>
              </div>
            </div>  

              
                </div>
                         </ContentTemplate>
          </asp:UpdatePanel>  
              </div>

               
              <div class="tab-pane p-20" id="purchase" role="tabpanel">
                  
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                <div class="pad-20">
                <div class="card-body">
              <div class="form-horizontal form-bordered">
                  
                <div class="row">
        <div class="col-md-4">
         <h4 class="text-black">Stock Management</h4>
        </div>
        
             <div class="col-md-8 exportbtn">
           <a href="add_product.aspx"><button type="button" title="Add New Customer" class="btn btn-primary4"> <i class="fa fa-plus"></i>Add Product</button></a>
          <button type="button" id="Button3" title="Export to Excel" runat="server" class="btn btnsqr btn-primary3 btngap" onserverclick="excel_export2"> <i class="fa fa-file-excel-o"></i> Excel</button>
           
        <button type="button" id="btn_print2" title="Print" onclick="printdiv2('dropHere2');" class="btn btnsqr btn-primary btngap"> <i class="fa fa-print"></i> Print</button>
         <button type="button" id="Button4" title="Export to PDF" runat="server"  class="btn btnsqr btn-primary2" onserverclick="pdf_export2"> <i class="fa fa-file-pdf-o"></i> PDF</button>
        
      </div>
      </div>
      <br/>
      <div id="dropHere2" class="table-responsive">
                  <table id="example2" class="table table-bordered table-striped">
                <thead>
                <tr>
                  <th>ID #</th>
                  <th>Product</th>
                  <th>Stock</th>
                  <th>Unit</th>
                  <th>CGST</th>
                  <th>SGST</th>
                  <th>IGST</th>
                  <th>HSN</th>
                  <th>Rate</th>
                  
                  <th class="no-print">Actions</th>
                </tr>
                </thead>
                <tbody>
                   
                <asp:Repeater ID="Repeater2" runat="server" OnItemCommand="Repeater2_ItemCommand">
              <ItemTemplate>
                   <tr>
                  <td>
              <asp:Label ID="lbl_id2" runat="server" Text='<%# Eval("p_id") %>'></asp:Label></td>
                  <td>
              <asp:Label ID="lbl_product_name2" runat="server" Text='<%# Eval("p_name") %>'></asp:Label></td>
                  <td><strong><asp:Label ID="Label1" runat="server" Text='<%# Eval("p_stock") %>'></asp:Label><strong/></td>
                  <td><asp:Label ID="lbl_unit2" runat="server" Text='<%# Eval("p_unit") %>'></asp:Label></td>
                  <td><asp:Label ID="lbl_cgst2" runat="server" Text='<%# Eval("p_cgst") %>'></asp:Label></td>
                  <td><asp:Label ID="lbl_sgst2" runat="server" Text='<%# Eval("p_sgst") %>'></asp:Label></td>
                  <td><asp:Label ID="lbl_igst2" runat="server" Text='<%# Eval("p_igst") %>'></asp:Label></td>
                  <td><asp:Label ID="lbl_hsn2" runat="server" Text='<%# Eval("p_hsn_code") %>'></asp:Label></td>
                  <td><asp:Label ID="lbl_rate2" runat="server" Text='<%# Eval("p_rate") %>'></asp:Label></td>
 
                  <td class="no-print"> <asp:LinkButton ID="LinkButton1" runat="server" OnClientClick="return confirm('Do you want to delete this Product?');" OnClick="DeleteProduct2"><i  class="fa fa-trash-o"></i></asp:LinkButton>
                  <asp:LinkButton ID="LinkButton2" runat="server"  CommandName="showid" CommandArgument='<%# Eval("p_id") %>'><i style="padding-left:10px" class="fa fa-eye"></i></i></asp:LinkButton>
                  <asp:LinkButton ID="LinkButton3" runat="server" CommandName="editid" CommandArgument='<%# Eval("p_id") %>'><i style="padding-left:10px" class="fa fa-edit"></i></asp:LinkButton>
                      <!--<a href=""></a><a href=""><i style="padding-left:10px" class="fa fa-edit"></i></a><a href="" runat="server" ><i style="padding-left:10px" class="fa fa-trash-o"></i></a>-->
                 </td>
                </tr>
              </ItemTemplate>

          </asp:Repeater>
                <asp:Label ID="Lbl_msg3" Style="color:red" runat="server" Text=""></asp:Label>
                </tbody>
               
              </table>

           
            
                  </div>
                            
              </div>
            </div>  


                </div>
              </div>
                 </ContentTemplate>
          </asp:UpdatePanel>    
            </div>
          </div>
        </div>
      </div>
      <!-- row --> 
      </div>
      
      <!-- Main row --> 
        
    </section>
    
    </div>

  <!-- /.content-wrapper -->
  <footer class="main-footer">
    <div class="pull-right hidden-xs">Version 1.0</div>
    Copyright © 2018 PrintSoft. All rights reserved.</footer>
    
    <asp:GridView ID="GridView1"  dispaly="none" runat="server">
        <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
        <RowStyle ForeColor="black"/>
    </asp:GridView>
<!-- Modal -->
  <div class="modal fade" id="myModal" role="dialog">
    <div class="modal-dialog">
    
      <!-- Modal content-->
      <div class="modal-content">
        <div class="modal-header">
            <h4 class="modal-title"><asp:Label ID="lbl_name" runat="server" Text=""></asp:Label></h4>
          <button type="button" class="close" data-dismiss="modal">&times;</button>
          
        </div>
        <div class="modal-body">
          <table class="table table-hover">
  
  <tbody>
    <tr>
      <th scope="col">Unit</th>
      <td><asp:Label ID="lbl_unit" runat="server" Text=""></asp:Label></td>
     
    </tr>
       <tr>
      <th scope="col">cgst</th>
      <td><asp:Label ID="lbl_cgst" runat="server" Text=""></asp:Label></td>
     
    </tr>
       <tr>
      <th scope="col">sgst</th>
      <td><asp:Label ID="lbl_sgst" runat="server" Text=""></asp:Label></td>
     
    </tr>
       <tr>
      <th scope="col">igst</th>
      <td><asp:Label ID="lbl_igst" runat="server" Text=""></asp:Label></td>
     
    </tr>
       <tr>
      <th scope="col">HSN Code</th>
      <td><asp:Label ID="lbl_hsn_code" runat="server" Text=""></asp:Label></td>
     
    </tr>
       <tr>
      <th scope="col">Rate</th>
      <td><asp:Label ID="lbl_rate" runat="server" Text=""></asp:Label></td>
     
    </tr>
       <tr>
      <th scope="col">Stock</th>
      <td><asp:Label ID="lbl_stock1" runat="server" Text=""></asp:Label></td>
     
    </tr>
      <%--<tr>
      <th scope="col">Value</th>
      <td><asp:Label ID="lbl_value1" runat="server" Text=""></asp:Label></td>
     
    </tr>--%>
   <tr>
      <th scope="col">Description</th>
      <td><asp:Label ID="lbl_desc" runat="server" Text=""></asp:Label></td>
     
    </tr>
  </tbody>
</table>
        </div>
        <div class="modal-footer">
          <button type="button" class="btn btn-default" data-dismiss="modal">Close</button>
        </div>
      </div>
      
    </div>
  </div>

<!-- Modal -->
  <div class="modal fade" id="myModal2" role="dialog">
    <div class="modal-dialog">
    
    <%--   Modal content--%>
      <div class="modal-content">
        <div class="modal-header">
            <h4 class="modal-title">Edit Panel<asp:HiddenField ID="Txt_id" runat="server" /></h4>
          <button type="button" class="close" data-dismiss="modal">&times;</button>
          
        </div>
        <div class="modal-body">
          <table class="table table-hover">
  
  <tbody>
       <tr>
      <th scope="col">Product Name</th>
      <td><asp:TextBox ID="Txt_name" class="form-control" runat="server"></asp:TextBox></td>
     
    </tr>
    <tr>
      <th scope="col">Unit</th>
      <td><asp:DropDownList ID="Dd_unit" class="form-control" runat="server" disabled="true">
                             <asp:ListItem Value="Sqft">Sqft</asp:ListItem>
                             <asp:ListItem Value="Inch">Inch</asp:ListItem>
                             <asp:ListItem Value="Pcs">Pcs</asp:ListItem>
                         </asp:DropDownList></td>
     
    </tr>
       <tr>
      <th scope="col">cgst</th>
      <td><asp:dropdownlist ID="Dd_cgst" class="form-control" runat="server" disabled="true">
                            <asp:ListItem Value="0">0 %</asp:ListItem>
                            <asp:ListItem Value="5">5 %</asp:ListItem>
                            <asp:ListItem Value="6">6 %</asp:ListItem>
                            <asp:ListItem Value="9">9 %</asp:ListItem>
                            <asp:ListItem Value="12">12 %</asp:ListItem>
                            <asp:ListItem Value="18">18 %</asp:ListItem>
                            <asp:ListItem Value="28">28 %</asp:ListItem>

                        </asp:dropdownlist></td>
     
    </tr>
       <tr>
      <th scope="col">sgst</th>
      <td><asp:dropdownlist  ID="Dd_sgst" class="form-control" runat="server" disabled="true">
                           <asp:ListItem Value="0">0 %</asp:ListItem>
                            <asp:ListItem Value="5">5 %</asp:ListItem>
                            <asp:ListItem Value="6">6 %</asp:ListItem>
                            <asp:ListItem Value="9">9 %</asp:ListItem>
                            <asp:ListItem Value="12">12 %</asp:ListItem>
                            <asp:ListItem Value="18">18 %</asp:ListItem>
                            <asp:ListItem Value="28">28 %</asp:ListItem>
                       </asp:dropdownlist></td>
     
    </tr>
       <tr>
      <th scope="col">igst</th>
      <td><asp:dropdownlist ID="Dd_igst" class="form-control" runat="server" disabled="true">
                          <asp:ListItem Value="0">0 %</asp:ListItem>
                            <asp:ListItem Value="5">5 %</asp:ListItem>
                            <asp:ListItem Value="6">6 %</asp:ListItem>
                            <asp:ListItem Value="9">9 %</asp:ListItem>
                            <asp:ListItem Value="12">12 %</asp:ListItem>
                            <asp:ListItem Value="18">18 %</asp:ListItem>
                            <asp:ListItem Value="28">28 %</asp:ListItem>
                       </asp:dropdownlist></td>
     
    </tr>
       <tr>
      <th scope="col">HSN Code</th>
      <td><asp:TextBox ID="Txt_hsn" class="form-control" runat="server" disabled="true"></asp:TextBox></td>
     
    </tr>
       <tr>
      <th scope="col">Rate</th>
      <td><asp:TextBox ID="Txt_rate"  placeholder="Rate" class="form-control" runat="server" disabled="true"></asp:TextBox></td>
     
    </tr>
      <tr>
      <th scope="col">Stock</th>
      <td><asp:TextBox ID="Txt_stock" class="form-control" runat="server" placeholder="Stock"></asp:TextBox></td>
     
    </tr>
      <%-- <tr>
      <th scope="col">Value</th>
      <td><asp:TextBox ID="Txt_value" class="form-control" runat="server" placeholder="Value"></asp:TextBox></td>
     
    </tr>--%>
   <tr>
      <th scope="col">Description</th>
      <td><asp:TextBox ID="Txt_description" class="form-control" runat="server" TextMode="MultiLine"></asp:TextBox></td>
     
    </tr>
  </tbody>
</table>
        </div>
        <div class="modal-footer">
             <asp:Label ID="lbl_msg" runat="server" Text=""></asp:Label>
             <asp:Button ID="Button1" class="btn btn-success" OnClientClick="return JSFunctionValidate()" runat="server" Text="Update" OnClick="Button6_Click" />
          <button type="button" class="btn btn-default" data-dismiss="modal">Close</button>
        </div>
      </div>
      
    </div>
  </div>


    <!-- Modal -->
  <div class="modal fade" id="myModal3" role="dialog">
    <div class="modal-dialog">
    
      <!-- Modal content-->
     <%-- <div class="modal-content">
        <div class="modal-header">
            <h4 class="modal-title"><asp:Label ID="lbl_name2" runat="server" Text=""></asp:Label></h4>
          <button type="button" class="close" data-dismiss="modal">&times;</button>
          
        </div>
        <div class="modal-body">
          <table class="table table-hover">
  
  <tbody>
    <tr>
      <th scope="col">Unit</th>
      <td><asp:Label ID="lbl_unit2" runat="server" Text=""></asp:Label></td>
     
    </tr>
       <tr>
      <th scope="col">cgst</th>
      <td><asp:Label ID="lbl_cgst2" runat="server" Text=""></asp:Label></td>
     
    </tr>
       <tr>
      <th scope="col">sgst</th>
      <td><asp:Label ID="lbl_sgst2" runat="server" Text=""></asp:Label></td>
     
    </tr>
       <tr>
      <th scope="col">igst</th>
      <td><asp:Label ID="lbl_igst2" runat="server" Text=""></asp:Label></td>
     
    </tr>
       <tr>
      <th scope="col">HSN Code</th>
      <td><asp:Label ID="lbl_hsn_code2" runat="server" Text=""></asp:Label></td>
     
    </tr>
       <tr>
      <th scope="col">Rate</th>
      <td><asp:Label ID="lbl_rate2" runat="server" Text=""></asp:Label></td>
     
    </tr>
       <tr>
      <th scope="col">Stock</th>
      <td><asp:Label ID="lbl_stock2" runat="server" Text=""></asp:Label></td>
     
    </tr>
   <tr>
      <th scope="col">Description</th>
      <td><asp:Label ID="lbl_desc2" runat="server" Text=""></asp:Label></td>
     
    </tr>
  </tbody>
</table>
        </div>
        <div class="modal-footer">
          <button type="button" class="btn btn-default" data-dismiss="modal">Close</button>
        </div>
      </div>
      
    </div>
  </div>--%>

<!-- Modal -->
 <%-- <div class="modal fade" id="myModal4" role="dialog">
    <div class="modal-dialog">
    
      <!-- Modal content-->
      <div class="modal-content">
        <div class="modal-header">
            <h4 class="modal-title">Edit Panel<asp:HiddenField ID="Txt_id2" runat="server" /></h4>
          <button type="button" class="close" data-dismiss="modal">&times;</button>
          
        </div>
        <div class="modal-body">
          <table class="table table-hover">
  
  <tbody>
       <tr>
      <th scope="col">Product Name</th>
      <td><asp:TextBox ID="Txt_name2" class="form-control" runat="server"></asp:TextBox></td>
     
    </tr>
    <tr>
      <th scope="col">Unit</th>
      <td><asp:DropDownList ID="Dd_unit2" class="form-control" runat="server">
                             <asp:ListItem Value="Sqft">Sqft</asp:ListItem>
                             <asp:ListItem Value="Inch">Inch</asp:ListItem>
                             <asp:ListItem Value="Pcs">Pcs</asp:ListItem>
                         </asp:DropDownList></td>
     
    </tr>
       <tr>
      <th scope="col">cgst</th>
      <td><asp:dropdownlist ID="Dd_cgst2" class="form-control" runat="server">
                            <asp:ListItem Value="0">0 %</asp:ListItem>
                            <asp:ListItem Value="5">5 %</asp:ListItem>
                            <asp:ListItem Value="6">6 %</asp:ListItem>
                            <asp:ListItem Value="9">9 %</asp:ListItem>
                            <asp:ListItem Value="12">12 %</asp:ListItem>
                            <asp:ListItem Value="18">18 %</asp:ListItem>
                            <asp:ListItem Value="28">28 %</asp:ListItem>

                        </asp:dropdownlist></td>
     
    </tr>
       <tr>
      <th scope="col">sgst</th>
      <td><asp:dropdownlist  ID="Dd_sgst2" class="form-control" runat="server">
                           <asp:ListItem Value="0">0 %</asp:ListItem>
                            <asp:ListItem Value="5">5 %</asp:ListItem>
                            <asp:ListItem Value="6">6 %</asp:ListItem>
                            <asp:ListItem Value="9">9 %</asp:ListItem>
                            <asp:ListItem Value="12">12 %</asp:ListItem>
                            <asp:ListItem Value="18">18 %</asp:ListItem>
                            <asp:ListItem Value="28">28 %</asp:ListItem>
                       </asp:dropdownlist></td>
     
    </tr>
       <tr>
      <th scope="col">igst</th>
      <td><asp:dropdownlist ID="Dd_igst2" class="form-control" runat="server">
                          <asp:ListItem Value="0">0 %</asp:ListItem>
                            <asp:ListItem Value="5">5 %</asp:ListItem>
                            <asp:ListItem Value="6">6 %</asp:ListItem>
                            <asp:ListItem Value="9">9 %</asp:ListItem>
                            <asp:ListItem Value="12">12 %</asp:ListItem>
                            <asp:ListItem Value="18">18 %</asp:ListItem>
                            <asp:ListItem Value="28">28 %</asp:ListItem>
                       </asp:dropdownlist></td>
     
    </tr>
       <tr>
      <th scope="col">HSN Code</th>
      <td><asp:TextBox ID="Txt_hsn2" class="form-control" runat="server"></asp:TextBox></td>
     
    </tr>
       <tr>
      <th scope="col">Rate</th>
      <td><asp:TextBox ID="Txt_rate2"  placeholder="Rate" class="form-control" runat="server"></asp:TextBox></td>
     
    </tr>
      <tr>
      <th scope="col">Stock</th>
      <td><asp:TextBox ID="Txt_stock2" class="form-control" runat="server" ></asp:TextBox></td>
     
    </tr>
   <tr>
      <th scope="col">Description</th>
      <td><asp:TextBox ID="Txt_description2" class="form-control" runat="server" TextMode="MultiLine"></asp:TextBox></td>
     
    </tr>
  </tbody>
</table>
        </div>
        <div class="modal-footer">
             <asp:Label ID="lbl_msg4" runat="server" Text=""></asp:Label>
             <asp:Button ID="Button6" class="btn btn-success" OnClientClick="return JSFunctionValidate2()" runat="server" Text="Update" OnClick="Button6_Click"  />
          <button type="button" class="btn btn-default" data-dismiss="modal">Close</button>
        </div>
      </div>
      
    </div>
  </div>--%>



        <script type="text/javascript">
    window.setTimeout(function() {
    $(".alert").fadeTo(500, 0).slideUp(500, function(){
        $(this).remove(); 
    });
}, 4000);
</script>
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
    <script>
function JSFunctionValidate()
{
if(document.getElementById('<%=Txt_name.ClientID%>').value.length==0)
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

        function JSFunctionValidate2()
{
if(document.getElementById('<%=Txt_name.ClientID%>').value.length==0)
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
    <script type="text/javascript">

function printdiv(dropHere) {
    var printContents = document.getElementById(dropHere).innerHTML;
    var originalContents = document.body.innerHTML;

    document.body.innerHTML = printContents;

    window.print();

    document.body.innerHTML = originalContents;
}

function printdiv2(dropHere2) {
    var printContents = document.getElementById(dropHere2).innerHTML;
    var originalContents = document.body.innerHTML;

    document.body.innerHTML = printContents;

    window.print();

    document.body.innerHTML = originalContents;
}
</script>
</asp:Content>

