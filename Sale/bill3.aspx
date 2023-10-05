<%@ Page Language="C#" AutoEventWireup="true" CodeFile="bill3.aspx.cs" Inherits="Sale_bill3" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">

<head>
	
<script src="https://use.fontawesome.com/e2d16502eb.js"></script>

<meta http-equiv='Content-Type' content='text/html; charset=UTF-8' />
<style>
     @page { /* DIN A4 standard, Europe */
       margin-top:0;
        margin-bottom:0;
      }
      
#page-wrap { width: 297mm; height:210mm; margin: 0 auto; }
td {
	font-size:12px;
}

@media all {
	.page-break	{ display: none; }
}

@media print {
	.page-break	{ display: block; page-break-before: always; }
}

body{
	
	
    font-family: 'Droid Sans', sans-serif;

}
.btnprint{   
     border-radius: 5px;
    -webkit-box-shadow: none;
    box-shadow: none;
    border: 1px solid transparent;
    font-size: 14px;
    padding: 10px 20px;
    background-color:#0077d3;
    color:white;

}
        @media print
{    
    .no-print, .no-print *
    {
        display: none !important;
    }
}
</style>
     <script type="text/javascript">
function printdiv(dropHere)
{
    var printContents = document.getElementById(dropHere).innerHTML;
    var originalContents = document.body.innerHTML;

    document.body.innerHTML = printContents;

    window.print();

    document.body.innerHTML = originalContents;
}
</script>
  <link href="https://fonts.googleapis.com/css?family=Droid+Sans" rel="stylesheet"/> 
</head>

<body>
    <form id="form1" runat="server">
	<div id="page-wrap" >
	<div class="no-print" style="text-align:center;"> <br/><button onclick="printdiv('page-wrap');" class="btnprint" ><i class="fa fa-print"></i> Print</button></div><br/>
        
	<table width="100%;" style="border:1px solid;" cellspacing="0" cellpadding="0">
	
	<tr>
	<td style="height:30px; border-bottom:1px solid;" valign="top">
	<h1 style="text-align:center; font-weight:bolder; text-transform:uppercase; margin-top:3px; margin-bottom:3px;"><b>Tax Invoice</b></h1>	
	</td>
	</tr>
	
	<tr>
	<td style="height:60px;" valign="top">
	
	<table width="100%" cellspacing="0" cellpadding="0">
	<tr>
	<td width="50%" style="height:60px; text-align:center; border-right:1px solid;">
		<asp:Image ID="Image1" style="height:70px; text-align:center;" align='center' runat="server" />
	</td>
	<td width="50%" style="height:60px;" valign="top">
        <br/>
	<p style="text-align:center; font-weight:bold; margin-bottom:0px; margin-top:4px;"><asp:Label ID="lbl_company_name" runat="server" Text=""></asp:Label></p>
	<p style="text-align:center; font-weight:bold; margin-bottom:0px; margin-top:4px;"><i class="fa fa-phone" aria-hidden="true"></i><asp:Label ID="lbl_company_contact" runat="server" Text=""></asp:Label></p>
	<p style="text-align:center; font-weight:bold;  margin-top:4px; margin-bottom:4px;"><i class="fa fa-envelope-o" aria-hidden="true"></i> <asp:Label ID="lbl_company_email" runat="server" Text=""></asp:Label></p>
        <br/>	
	</td>
	</tr>
	</table>
	
	
	
	
	</td>
	</tr>
	
	<tr>
	<td width="100%">
	<table width="100%" cellspacing="0" cellpadding="0">
	<tr>
	<td width="50%" style="border-top:1px solid; height:100px; border-right:1px solid; padding-left:10px;" valign="top">
	<!-- Invoice Details -->
	<table>
	<tr>
	<td style="height:25px;">GST Number </td>
	<td>: <asp:Label ID="lbl_company_gst" runat="server" Text=""></asp:Label></td>
	</tr>
	<tr>
	<td style="height:25px;">Invoice Number </td>
	<td>: # <asp:Label ID="lbl_invoice_no"  runat="server" Text=""></asp:Label></td>
	</tr>
	<tr>
	<td style="height:25px;">Invoice Date</td>
	<td>: <asp:Label ID="lbl_invoice_date" runat="server" Text=""></asp:Label></td>
	</tr>
	</table>
	<!-- Invoice Details -->
	</td>
	<td width="25%" style="border-top:1px solid; padding-left:10px;" valign="top">
	<!-- Invoice Other Details -->
	<table >
	<tr>
	<td style="height:25px;">Customer Name</td>
	<td>: <asp:Label ID="lbl_customer_name" runat="server" Text=""></asp:Label></td>
	</tr>
	<tr>
	<td style="height:25px;">Company Name</td>
	<td>: <asp:Label ID="lbl_company" runat="server" Text=""></asp:Label></td>
	</tr>
	<tr>
	<td style="height:25px;">GST Number</td>
	<td>: <asp:Label ID="lbl_gst_no" runat="server" Text=""></asp:Label></td>
	</tr>
	
	<tr>
	
	</tr>
	</table>
	<!-- Invoice Other Details -->

	</td>
        <td width="25%" style="border-top:1px solid; padding-left:10px;" valign="top">
	<!-- Invoice Other Details -->
	<table >
	<tr>
	<td style="height:25px;">Phone</td>
	<td>: <asp:Label ID="lbl_customer_contact" runat="server" Text=""></asp:Label></td>
	</tr>
	<tr>
	<td style="height:25px;">Email</td>
	<td>: <asp:Label ID="lbl_email" runat="server" Text=""></asp:Label></td>
	</tr>
	
	<tr>
	<td style="height:25px;">Address</td>
	<td>: <asp:Label ID="lbl_customer_address" runat="server" Text=""></asp:Label></td>
	</tr>
	</table>
	<!-- Invoice Other Details -->

	</td>
	</tr>
	</table>
	</td>
	</tr>
	
	
	
	<tr>
	<td width="100%">
	</td>
	</tr>
	
	
	<tr>
	<td width="100%">
	<table cellspacing="0" cellpadding="0" width="100%">
	<tr>
	<td width="24%" style="border-top:1px solid; border-right:1px solid; text-align:center; height:25px;"><br/>Product</td>
	<td width="7%" style="border-top:1px solid; border-right:1px solid; text-align:center; height:25px;"><br/>HSN Code</td>
	<td width="9%" style="border-top:1px solid; border-right:1px solid; text-align:center; height:25px;"><br/>Size</td>
	<td width="8%" style="border-top:1px solid; border-right:1px solid; text-align:center; height:25px;"><br/>Unit</td>
	<td width="8%" style="border-top:1px solid; border-right:1px solid; text-align:center; height:25px;"><br/>Qty</td>
	<td width="8%" style="border-top:1px solid; border-right:1px solid; text-align:center; height:25px;"><br/>Rate</td>
    <td width="10%" style="border-top:1px solid; border-right:1px solid; text-align:center; height:25px;"><br/>Total</td>
    <td width="6%" style="border-top:1px solid; border-right:1px solid; text-align:center; height:25px;"><br/>CGST%</td>
    <td width="6%" style="border-top:1px solid; border-right:1px solid; text-align:center; height:25px;"><br/>SGST%</td>
    <td width="6%" style="border-top:1px solid; border-right:1px solid; text-align:center; height:25px;"><br/>IGST%</td>
	<td width="8%" style="border-top:1px solid; border-left:1px solid; text-align:center; height:25px;"><br/>Amount</td>
	</tr>
	</table>
	</td>
	</tr>
	
	
	<tr>
	<td width="100%">
	<table cellspacing="0" cellpadding="0" width="100%">
        <asp:Repeater ID="Repeater2" runat="server">
                                     <ItemTemplate>
	<tr>
	<td width="24%" style="border-top:1px solid; border-right:1px solid; text-align:center; height:20px;"><br/><strong><asp:Label ID="lbl_product" runat="server" Text='<%# Eval("s_product_name") %>'></asp:Label></strong><br/><asp:Label ID="Label1" runat="server" style="font-size: 12px;" Text='<%# Eval("s_desc") %>'></asp:Label> </td>
	<td width="7%" style="border-top:1px solid; border-right:1px solid; text-align:center; height:20px;"><asp:Label ID="lbl_hsn" runat="server" Text='<%# Eval("s_product_hsn") %>'></asp:Label></td>
	<td width="9%" style="border-top:1px solid; border-right:1px solid; text-align:center; height:20px;"><asp:Label ID="lbl_height" runat="server" Text='<%# Eval("s_height") %>'></asp:Label> X <asp:Label ID="lbl_width" runat="server" Text='<%# Eval("s_width") %>'></asp:Label></td>
	<td width="8%" style="border-top:1px solid; border-right:1px solid; text-align:center; height:20px;"><asp:Label ID="Label4" runat="server" Text='<%# Eval("s_unit") %>'></asp:Label></td>
	<td width="8%" style="border-top:1px solid; border-right:1px solid; text-align:center; height:20px;"><asp:Label ID="lbl_qty" runat="server" Text='<%# Eval("s_quantity") %>'></asp:Label></td>
	<td width="8%" style="border-top:1px solid; border-right:1px solid; text-align:center; height:20px;"><asp:Label ID="lbl_rate" runat="server" Text='<%# Eval("s_rate") %>'></asp:Label></td>
    <td width="10%" style="border-top:1px solid; border-right:1px solid; text-align:center; height:20px;"><asp:Label ID="lbl_stotal" runat="server" Text='<%# Eval("s_stotal") %>'></asp:Label></td>
    <td width="6%" style="border-top:1px solid; border-right:1px solid; text-align:center; height:20px;"><asp:Label ID="lbl_cgst" runat="server" Text='<%# Eval("s_cgstp") %>'></asp:Label></td>
    <td width="6%" style="border-top:1px solid; border-right:1px solid; text-align:center; height:20px;"><asp:Label ID="lbl_sgst" runat="server" Text='<%# Eval("s_sgstp") %>'></asp:Label></td>
    <td width="6%" style="border-top:1px solid; border-right:1px solid; text-align:center; height:20px;"><asp:Label ID="lbl_igst" runat="server" Text='<%# Eval("s_igstp") %>'></asp:Label></td>
	<td width="8%" style="border-top:1px solid; border-left:1px solid; text-align:center; height:20px;"><asp:Label ID="lbl_amount" runat="server" Text='<%# Eval("s_amount") %>'></asp:Label></td>
	</tr>
                                           </ItemTemplate>
                                  </asp:Repeater>
	</table>
	</td>
	</tr>
	
	
	<tr>
	<td width="100%">
	<table cellspacing="0" cellpadding="0" width="100%">
	<tr>
	<td style="border-top:1px solid; height:35px;" width="100%"><strong style=" margin-left:10px; ">Invoice Total (in words) : </strong>  <strong><asp:Label ID="lbl_word" runat="server" Text=""></asp:Label> RUPEES ONLY</strong></td>
	
	</tr>
	</table>
	</td>
	</tr>
	
	<tr>
	<td width="100%">
	<table cellspacing="0" cellpadding="0" width="100%">
	<tr>
	<td style="border-top:1px solid; text-align:center; border-right:1px solid;  height:35px; padding-left:10px;" width="50%">
	<p><br/><br/><br/><br/>
                                                            <asp:Label ID="lbl_company_name2" runat="server" Text=""></asp:Label>
                                                            <br/>
                                                            <strong>(Authorised Signatory)</strong>
                                                        </p>
	</td>
	
        <td width="20%" style="border-top:1px solid; text-align:left;  height:20px;">
	</td>
	<td width="30%" style="border-top:1px solid; text-align:left;  height:20px;">
     <table>

	<tr>
	<td style="height:25px;"><strong>Total Amount</strong></td>
	<td>: ₹ <asp:Label ID="lbl_subtotal" runat="server" Text=""></asp:Label></td>
	</tr>
    <tr>
	<td style="height:25px;"><strong>Total GST</strong></td>
	<td>: ₹ <asp:Label ID="lbl_total_gst" runat="server" Text=""></asp:Label></td>
	</tr>
         <tr>
	<td style="height:25px;"><strong>Transport</strong></td>
	<td>: ₹ <asp:Label ID="lbl_transport" runat="server" Text=""></asp:Label></td>
	</tr>
         <asp:Panel ID="Panel2" runat="server">
         <tr>
	<td style="height:25px;"><strong>Design Charges</strong></td>
	<td>: ₹ <asp:Label ID="lbl_dtp" runat="server" Text=""></asp:Label></td>
	</tr>
              </asp:Panel>
         <asp:Panel ID="Panel3" runat="server">
         <tr>
	<td style="height:25px;"><strong>Pasting Charges</strong></td>
	<td>: ₹ <asp:Label ID="lbl_pasting" runat="server" Text=""></asp:Label></td>

	</tr>
             </asp:Panel>
           <asp:Panel ID="Panel4" runat="server">
         <tr>
	<td style="height:25px;"><strong>Framing Charges</strong></td>
	<td>: ₹ <asp:Label ID="lbl_framing" runat="server" Text=""></asp:Label></td>
	</tr>
                </asp:Panel>
           <asp:Panel ID="Panel5" runat="server">
         <tr>
	<td style="height:25px;"><strong>Fitting Charges</strong></td>
	<td>: ₹ <asp:Label ID="lbl_fitting" runat="server" Text=""></asp:Label></td>
	</tr>
               </asp:Panel>
          <asp:Panel ID="Panel6" runat="server">
         <tr>
	<td style="height:25px;"><strong>Intallation Charges</strong></td>
	<td>: ₹ <asp:Label ID="lbl_install" runat="server" Text=""></asp:Label></td>
	</tr>
               </asp:Panel>
         <tr>
	<td style="height:25px;"><strong>Advance</strong></td>
	<td>: ₹ <asp:Label ID="lbl_adjustment" runat="server" Text=""></asp:Label></td>
	</tr>
         <tr>
	<td style="height:25px;"><strong>Discount</strong></td>
	<td>: ₹ <asp:Label ID="lbl_discount" runat="server" Text=""></asp:Label></td>
	</tr>
         <tr>
	<td style="height:25px;"><strong>Balance</strong></td>
	<td>: ₹ <asp:Label ID="lbl_balance" runat="server" Text=""></asp:Label></td>
	</tr>
         <tr>
	<td style="height:25px;"><strong>Invoice Total</strong></td>
	<td>: ₹ <asp:Label ID="lbl_total" runat="server" onchange="inWords();" Text=""></asp:Label></td>
	</tr>

      </table>
	</td>
	</tr>
	
	
	</table> 
	</td>

	</tr>
        </table>
            
	</div>
	</form>
</body>

</html>

