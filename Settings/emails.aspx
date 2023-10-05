<%@ Page Title="" Language="C#" MasterPageFile="~/Settings/Settings.master" AutoEventWireup="true" CodeFile="emails.aspx.cs" Inherits="admin_panel_Settings_emails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
   
     <script>
function JSFunctionValidate()
{
if(document.getElementById('<%=Txt_subject.ClientID%>').value.length==0)
{
alert("Please Enter Subject !!!");
return false;
}
if(document.getElementById('<%=Txt_message.ClientID%>').value.length==0)
{
alert("Please Enter Offer Message !!!");
return false;
}
    
   

return true;
}
        </script>
     <script type = "text/javascript">

function Check_Click(objRef)

{

    //Get the Row based on checkbox

    var row = objRef.parentNode.parentNode;

    if(objRef.checked)

    {

        //If checked change color to Aqua

        row.style.backgroundColor = "#669999";

    }
    else {

        //If not checked change back to original color

        //if (row.rowIndex % 2 == 0) {

        //    //Alternating Row Color

        //    row.style.backgroundColor = "#C2D69B";

        //}

        //else {

            row.style.backgroundColor = "white";

        //}

    }

   

   

    //Get the reference of GridView

    var GridView = row.parentNode;

   

    //Get all input elements in Gridview

    var inputList = GridView.getElementsByTagName("input");

   

    for (var i=0;i<inputList.length;i++)

    {

        //The First element is the Header Checkbox

        var headerCheckBox = inputList[0];

       

        //Based on all or none checkboxes

        //are checked check/uncheck Header Checkbox

        var checked = true;

        if(inputList[i].type == "checkbox" && inputList[i] != headerCheckBox)

        {

            if(!inputList[i].checked)

            {

                checked = false;

                break;

            }

        }

    }

    headerCheckBox.checked = checked;

   

}

</script>
    <script type = "text/javascript">

function checkAll(objRef)

{

    var GridView = objRef.parentNode.parentNode.parentNode;

    var inputList = GridView.getElementsByTagName("input");

    for (var i=0;i<inputList.length;i++)

    {

        //Get the Cell To find out ColumnIndex

        var row = inputList[i].parentNode.parentNode;

        if(inputList[i].type == "checkbox"  && objRef != inputList[i])

        {

            if (objRef.checked)

            {

                //If the header checkbox is checked

                //check all checkboxes

                //and highlight all rows

                row.style.backgroundColor = "#669999";

                inputList[i].checked=true;

            }

            else

            {

                //If the header checkbox is checked

                //uncheck all checkboxes

                //and change rowcolor back to original

                //if(row.rowIndex % 2 == 0)

                //{

                //   //Alternating Row Color

                //   row.style.backgroundColor = "#C2D69B";

                //}

                //else

                //{

                  row.style.backgroundColor = "white";

                //}

                inputList[i].checked=false;

            }

        }

    }

}

</script> 
    <script type = "text/javascript">

function MouseEvents(objRef, evt)

{

    var checkbox = objRef.getElementsByTagName("input")[0];

   if (evt.type == "mouseover")

   {

       objRef.style.backgroundColor = "#dddddd";

   }

   else

   {

        if (checkbox.checked)

        {

            objRef.style.backgroundColor = "#669999";

        }

        else if(evt.type == "mouseout")

        {

            //if(objRef.rowIndex % 2 == 0)

            //{

            //   //Alternating Row Color

            //   objRef.style.backgroundColor = "#C2D69B";

            //}

            //else

            //{

               objRef.style.backgroundColor = "white";

            //}

        }

   }

}

</script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
      <!-- Content Wrapper. Contains page content -->
  <div class="content-wrapper"> 
    <!-- Content Header (Page header) -->
    <section class="content-header sty-one">
      <h1>Emails</h1>
      <ol class="breadcrumb">
        <li><a href="#">Settings</a></li>
        <li><i class="fa fa-angle-right"></i> Emails</li>
      </ol>
    </section>
     <section class="content">
      <div class="row">
        <div class="col-lg-12">
          <div class="card">
            <div class="card-header bg-blue">
              <h5 class="m-b-0">Email</h5>
            </div>
            <div class="card-body">
              <div class="form-horizontal form-bordered">
                <div class="form-body">
                     <div class="form-group row">
                    <label class="control-label text-right col-md-3">Subject<span style="color:red;">*</span></label>
                    <div class="col-md-9">
                      
                      <asp:TextBox ID="Txt_subject" placeholder="Enter Subject"  class="form-control" runat="server" TextMode="SingleLine"></asp:TextBox>
                      </div>
                  </div>
                  <div class="form-group row">
                    <label class="control-label text-right col-md-3">Message<span style="color:red;">*</span></label>
                    <div class="col-md-9">
                      
                      <asp:TextBox ID="Txt_message" placeholder="Enter Message" rows="4"  class="form-control" runat="server" TextMode="MultiLine"></asp:TextBox>
                      </div>
                  </div>
                    
                  
                </div>
                <div class="form-actions">
                  <div class="row">
                    <div class="col-md-12">
                      <div class="row">
                        <div class="offset-sm-3 col-md-9">
                          
                          <asp:Button ID="Btn_submit" class="btn btn-success" runat="server" Text="Send" OnClientClick="return JSFunctionValidate(); " OnClick="Btn_submit_Click" />
                          
                          <asp:Button ID="Btn_cencel" class="btn btn-inverse" runat="server" Text="Cancel" />

                          <asp:Label ID="Lbl_message" style="color:red" runat="server" Text=""></asp:Label>
                            
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
      <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
           <asp:UpdatePanel ID="UpdatePanel3" runat="server">
            <ContentTemplate>
        <div class="card m-t-3">
      <div class="card-body">
      <h4 class="text-black">Customer List</h4>
      
      <div class="form-horizontal form-bordered">
               <asp:GridView ID="GridView1" class="table table-striped" runat="server" CellPadding="3" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" OnRowDataBound = "RowDataBound">
                   <Columns>

                   <asp:TemplateField>
                       <HeaderTemplate>
                      <asp:CheckBox ID="checkAll" runat="server" onclick = "checkAll(this);" />
                      </HeaderTemplate>
                      <ItemTemplate>
                      <asp:CheckBox ID="CheckBox1" runat="server" onclick = "Check_Click(this)" />
                      </ItemTemplate>
                     </asp:TemplateField>
                      </Columns>
                   <FooterStyle BackColor="White" ForeColor="#000066" />
                   <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" />
                   <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
                   <RowStyle ForeColor="#000066" />
                   <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                   <SortedAscendingCellStyle BackColor="#F1F1F1" />
                   <SortedAscendingHeaderStyle BackColor="#007DBB" />
                   <SortedDescendingCellStyle BackColor="#CAC9C9" />
                   <SortedDescendingHeaderStyle BackColor="#00547E" />
                  </asp:GridView>


              </div>
         
      </div></div>
                </ContentTemplate>
        </asp:UpdatePanel>
   
    </section>
   </div>
  <!-- /.content-wrapper -->
  <footer class="main-footer">
    <div class="pull-right hidden-xs">Version 1.0</div>
    Copyright © 2018 PrintSoft. All rights reserved.</footer>


   
</asp:Content>

