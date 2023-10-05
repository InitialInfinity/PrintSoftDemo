<%@ Page Language="C#" AutoEventWireup="true" CodeFile="bill2.aspx.cs" Inherits="Sale_bill2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
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
    <script>
        function Closepopup() {
            $('#myModal').modal('close');
           
        }
    </script>

   
    <style type="text/css">
        @media print 
     {
    @page { /* DIN A4 standard, Europe */
       margin:0;
      }
      
      }

		.table_td td{
			padding:10px 0 10px 5px !important;
			border-bottom: solid 1px #cbcbcb !important;
		}
		.table_header th{
			background: #FDFAC5 !important;
			border-bottom: solid 1px #cbcbcb; border-top: 1px solid #cbcbcb !important;
			padding:10px 0 10px 5px !important;
		}

		.table_bottom{
			font-weight: 600 !important;
			background: #FDFAC5 !important;
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

</head>
<body>
    <form id="form1" runat="server">
  
           
     <div bgcolor='#e4e4e4' text='#ff6633' link='#666666' vlink='#666666' alink='#ff6633' style='margin:0;font-family:Arial,Helvetica,sans-serif;border-bottom:1'>
         
        <table  id="dropHere" background='' bgcolor='#e4e4e4' width='100%' style='padding:20px 0 20px 0' cellspacing='0' border='0' align='center' cellpadding='0'>
            <tbody>
                <tr>
                    <td>
                        <div class="no-print" style="text-align:center;"> <br/><button onclick="printdiv('dropHere');" class="btnprint" ><i class="fa fa-print"></i> Print</button></div>
                        <table  width='900' border='0' align='center' cellpadding='0' cellspacing='0' bgcolor='#FFFFFF' style='border-radius: 0px; '>
                            <tbody>
                                <tr>
                                    <td style="padding:25px 20px 0px 20px">
                                        <table width='900' border='0' cellspacing='0' cellpadding='0'
                                            <tbody>
                                                <tr>
                                                    <td align='left' valign='middle' style='padding:0px 5px 0px 5px'>
                                                        <table height='auto' width='100' border='0' cellpadding='3' cellspacing='3'>

                                                            <tbody>
                                                                <tr>
                                                                    
                                                                    <td width='0' align='center' valign='middle' style='color:#404041;font-size:14px;line-height:16px;padding:3px 5px 3px 5px'>
                                                                      <asp:Image ID="Image1" Width="150%" align='center' runat="server" />
                                                                    </td>
                                                                </tr>

                                                            </tbody>
                                                        </table>
                                                    </td>
                                                    <td align='left' valign='top' style='padding:0px 5px 0px 5px'>
                                                        <table height='auto' width='300' border='0' cellpadding='0' cellspacing='0'>
                                                            <span><h2 style='color: #bf0707; font-family: Libre Franklin, sans-serif; font-weight: 600; font-size: 18px;'><asp:Label ID="lbl_company_name" runat="server" Text=""></asp:Label></h2></span>

                                                            <tbody>
                                                                <tr>
                                                                    <td align='left' valign='top' style='color:#404041;font-size:14px;line-height:16px;padding:5px 0px 3px 0px'>
                                                                        <strong>Phone:</strong>
                                                                    </td>
                                                                    <td width='62' align='left' valign='top' style='color:#404041;font-size:14px;line-height:16px;padding:5px 5px 3px 5px'>
                                                                        <asp:Label ID="lbl_company_contact" runat="server" Text=""></asp:Label>
                                                                    </td>
                                                                </tr>

                                                                <tr>
                                                                    <td align='left' valign='top' style='color:#404041;font-size:14px;line-height:16px;padding:5px 0px 3px 0px'>
                                                                        <strong>GST No:</strong>
                                                                    </td>
                                                                    <td width='62' align='left' valign='top' style='color:#404041;font-size:14px;line-height:16px;padding:5px 5px 3px 5px'>
                                                                        <asp:Label ID="lbl_company_gst" runat="server" Text=""></asp:Label><br/>
                                                                    </td>
                                                                </tr>

                                                                <tr>
                                                                    <td align='left' valign='top' style='color:#404041;font-size:14px;line-height:16px;padding:5px 0px 3px 0px;'>
                                                                        <strong>Email:</strong>
                                                                    </td>
                                                                    <td width='62' align='left' valign='top' style='color:#404041;font-size:14px;line-height:16px;padding:5px 5px 3px 5px;'>
                                                                        <asp:Label ID="lbl_company_email" runat="server" Text=""></asp:Label>
                                                                    </td>
                                                                </tr>
                                                            </tbody>
                                                        </table>
                                                    </td>
                                                    <td align='right' valign='top' style='padding:0px 5px 0px 5px'>
                                                        <table height='auto' width='200' border='0' cellpadding='3' cellspacing='3'>
                                                        	 <span><h2 style='color: #bf0707; font-family: Libre Franklin, sans-serif; font-weight: 600; font-size: 14px; margin-top: 16px; text-align: right;'># <asp:Label ID="lbl_invoice_no"  runat="server" Text=""></asp:Label></h2></span>
                                                            <tbody>
                                                                <tr>
                                                                    <td width='0' align='left' valign='top' style='color:#404041;font-size:14px;line-height:16px;padding:0px 0px 3px 0px'>
                                                                        <strong>Order #:</strong>
                                                          
                                                                    </td>
                                                                    <td width='0' align='right' valign='top' style='color:#404041;font-size:14px;line-height:16px;padding:0px 5px 3px 5px'>
                                                                        <asp:Label ID="lbl_order_no" runat="server" Text=""></asp:Label>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align='left' valign='top' style='color:#404041;font-size:14px;line-height:16px;padding:5px 0px 3px 0px'>
                                                                        <strong>Invoice Date:</strong>
                                                                    </td>
                                                                    <td width='62' align='right' valign='top' style='color:#404041;font-size:14px;line-height:16px;padding:5px 5px 3px 5px'>
                                                                        <asp:Label ID="lbl_invoice_date" runat="server" Text=""></asp:Label>
                                                                    </td>
                                                                </tr>

                                                                <tr>
                                                                    <td align='left' valign='top' style='color:#404041;font-size:14px;line-height:16px;padding:5px 0px 3px 0px;'>
                                                                        <strong>Due Date:</strong>
                                                                    </td>
                                                                    <td width='62' align='right' valign='top' style='color:#404041;font-size:14px;line-height:16px;padding:5px 5px 3px 5px;'>
                                                                        <asp:Label ID="lbl_due_date" runat="server" Text=""></asp:Label>
                                                                    </td>
                                                                </tr>
                                                            </tbody>
                                                        </table>
                                                    </td>
                                                </tr>
                                                <tr>
				                                	<td height="0px"></td>
				                                </tr>
                                            </tbody>
                                        </table>
                                    </td>
                                  
                                </tr>
                               
                                <tr>
                                    <td valign='top' style='color:#bf0707;line-height:16px;padding:0px 20px 0px 20px'>
                                        <p>
                                            <section style='position: relative;clear: both;margin: 5px 0;height: 1px;border-top: 2px solid #bf0707;margin-bottom: 25px;margin-top: 10px;text-align: center;'>
                                                <h3 align='center' style='margin-top: -12px;background-color: #FFF;clear: both;width: 180px;margin-right: auto;margin-left: auto;padding-left: 15px;padding-right: 15px; font-family: arial,sans-serif; font-weight: 600; font-size: 18px;'>
												<span>TAX INVOICE</span>
											</h3>
                                            </section>
                                        </p>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="padding:0px 20px 0px 20px;">
                                        <table width='100%' border='0' cellspacing='0' cellpadding='0' style='border-bottom:solid 2px #bf0707'>
                                            <tbody>
                                                <tr>
                                                    <td align='left' valign='top' style='padding:0px 5px 0px 5px'>
                                                        <table height='auto' width='230' border='0' cellpadding='0' cellspacing='0'>
                                                            <tbody>

                                                                <tr>
                                                                    <td valign='top' style='color:#404041;font-size:14px;padding:5px 5px 0px 20px'>
                                                                       <strong>Customer Name</strong><br>
                                                                       <p>
                                                                            <asp:Label ID="lbl_customer_name" runat="server" Text=""></asp:Label>
                                                                        </p>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td valign='top' style='color:#404041;font-size:14px;padding:5px 5px 0px 20px'>
                                                                       <strong>Company Name</strong><br>
                                                                       <p>
                                                                            <asp:Label ID="lbl_company" runat="server" Text=""></asp:Label>
                                                                        </p>
                                                                    </td>
                                                                </tr>
                                                            </tbody>
                                                        </table>
                                                    </td>
                                                    <td align='center' valign='top' style='padding:0px 5px 0px 70px'>
                                                        <table height='auto' width='300' border='0' cellpadding='3' cellspacing='3'>
                                                            <tbody>
                                                               
                                                                <tr>
                                                                    <td align='left' valign='top' style='color:#404041;font-size:14px;line-height:16px;padding:5px 0px 3px 0px'>
                                                                        <strong>Phone:</strong>
                                                                    </td>
                                                                    <td width='62' align='left' valign='top' style='color:#404041;font-size:14px;line-height:16px;padding:5px 5px 3px 5px'>
                                                                        <asp:Label ID="lbl_customer_contact" runat="server" Text=""></asp:Label>
                                                                    </td>
                                                                </tr>

                                                                <tr>
                                                                    <td align='left' valign='top' style='color:#404041;font-size:14px;line-height:16px;padding:5px 0px 3px 0px'>
                                                                        <strong>GST No:</strong>
                                                                    </td>
                                                                    <td width='62' align='left' valign='top' style='color:#404041;font-size:14px;line-height:16px;padding:5px 5px 3px 5px'>
                                                                        <asp:Label ID="lbl_gst_no" runat="server" Text=""></asp:Label>
                                                                    </td>
                                                                </tr>

                                                                <tr>
                                                                    <td align='left' valign='top' style='color:#404041;font-size:14px;line-height:16px;padding:5px 0px 3px 0px;'>
                                                                        <strong>Email:</strong>
                                                                    </td>
                                                                    <td width='62' align='left' valign='top' style='color:#404041;font-size:14px;line-height:16px;padding:5px 5px 3px 5px;'>
                                                                        <asp:Label ID="lbl_email" runat="server" Text=""></asp:Label>
                                                                    </td>
                                                                </tr>
                                                            </tbody>
                                                        </table>
                                                    </td>
                                                    <td align='left' valign='top' style='padding:0px 5px 0px 0px'>
                                                        <table height='auto' width='100%' border='0' cellpadding='3' cellspacing='3'>
                                                            <tbody>
                                                                <tr>
                                                                    <td height='16' valign='top' align="right" style='color:#404041;font-size:14px;padding:0px 5px 0px 5px'>
                                                                        <strong>Customer Address</strong>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td valign='top' align="right" style='color:#404041;font-size:14px;line-height:16px;padding:0px 5px 0px 5px'>
                                                                        <p>
                                                                           <asp:Label ID="lbl_customer_address" runat="server" Text=""></asp:Label>
                                                                        </p>
                                                                    </td>
                                                                </tr>
                                                            </tbody>
                                                        </table>
                                                    </td>
                                                </tr>
                                            </tbody>
                                        </table>
                                    </td>
                                </tr>

                                <tr>
                                    <td valign='top' align="center" style='color:#404041;font-size:14px;line-height:16px;padding:10px 20px 0px 20px'>
                                        <table class="table" height='auto' align="center" width='100%' border='0' cellpadding='3' cellspacing='0' style="padding: 0px 0px 0px 0px;">
                                <thead>
                                    <tr style="text-align: left;" class="table_header">
                                        <th>Product</th>
                                        <th>HSN</th>
                                        <th>Size</th>
                                        <th>Unit</th>
                                        <th>Qty</th>
                                        <th>Rate</th>
                                        <th>Total</th>
                                        <th>CGST%</th>
                                        <th>SGST%</th>
                                        <th>IGST%</th>
                                        <th>Amount</th>
                                    </tr>
                                </thead>
                                <tbody>
                                   <asp:Repeater ID="Repeater2" runat="server">
                                     <ItemTemplate>
                                    <tr class="table_td">
                                        <td><strong><asp:Label ID="lbl_product" runat="server" Text='<%# Eval("pc_product_name") %>'></asp:Label></strong><br/><asp:Label ID="Label1" runat="server" style="font-size: 12px;" Text='<%# Eval("pc_desc") %>'></asp:Label> </td>
                                        <td><asp:Label ID="lbl_hsn" runat="server" Text='<%# Eval("pc_product_hsn") %>'></asp:Label></td>
                                        <td><asp:Label ID="lbl_height" runat="server" Text='<%# Eval("pc_height") %>'></asp:Label> X <asp:Label ID="lbl_width" runat="server" Text='<%# Eval("pc_width") %>'></asp:Label></td>
                                        <td><asp:Label ID="Label4" runat="server" Text='<%# Eval("pc_unit") %>'></asp:Label></td>
                                        <td><asp:Label ID="lbl_qty" runat="server" Text='<%# Eval("pc_quantity") %>'></asp:Label></td>
                                        <td><asp:Label ID="lbl_rate" runat="server" Text='<%# Eval("pc_rate") %>'></asp:Label></td>
                                        <td><asp:Label ID="lbl_stotal" runat="server" Text='<%# Eval("pc_stotal") %>'></asp:Label></td>
                                        <td><asp:Label ID="lbl_cgst" runat="server" Text='<%# Eval("pc_cgstp") %>'></asp:Label></td>
                                        <td><asp:Label ID="lbl_sgst" runat="server" Text='<%# Eval("pc_sgstp") %>'></asp:Label></td>
                                        <td><asp:Label ID="lbl_igst" runat="server" Text='<%# Eval("pc_igstp") %>'></asp:Label></td>
                                        <td><asp:Label ID="lbl_amount" runat="server" Text='<%# Eval("pc_amount") %>'></asp:Label></td>
                                    </tr>
                                   </ItemTemplate>
                                  </asp:Repeater>
                                </tbody>
                            </table>
                                    </td>
                                </tr>


                                <tr align='left'>

                                    <td style='color:#404041;font-size:14px;line-height:16px;padding:0px 20px 0px 20px'>
                                        <table width='600' border='0' align='left' cellpadding='0' style="padding: 20px 0px 0px 0px;" cellspacing='0'>
                                            <tbody>
                                                 <tr>
                                                    <td align='left' valign='bottom' style='color:#404041;font-size:14px;line-height:16px;padding:5px 20px 3px 0px'>
                                                        <strong>Invoice Total (in words)</strong>
                                                    </td>
                                                    <td width='auto' align='left' valign='bottom' style='color:#339933;font-size:14px;line-height:16px;padding:5px 18px 3px 5px'>
                                                        <strong><asp:Label ID="lbl_word" runat="server" Text=""></asp:Label> RUPEES ONLY</strong>
                                                    </td>
                                                </tr>
                                              <tr>
                                	          <td style="height: 50px;">
                                		
                                	          </td>
                                              </tr>
                                                <tr>
                                                
                                                    <td style='color:#404041;text-align: center; font-size:14px;line-height:16px;border-top: 1px solid #cbdbcd; padding:0px 0px 10px 0px'>
                                                        <p>
                                                            <asp:Label ID="lbl_company_name2" runat="server" Text=""></asp:Label>
                                                            <br>
                                                            <strong>(Authorised Signatory)</strong>
                                                        </p>
                                                    </td>
                                                </tr>

                                           
                                                </tbody>
                                            </table>
                                        <table width='230' border='0' align='right' cellpadding='0' cellspacing='0'>
                                            <tbody>
                                                <tr>
                                                    <td width='0' align='left' valign='top' style='color:#404041;font-size:14px;line-height:16px;padding:15px 0px 5px 0px'>
                                                        <strong>Total Amount</strong>
                                                       
                                                    </td>
                                                    <td width='auto' align='right' valign='top' style='color:#404041;font-size:14px;line-height:16px;padding:15px 5px 5px 5px'>
                                                        ₹ <asp:Label ID="lbl_subtotal" runat="server" Text=""></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align='left' valign='top' style='color:#404041;font-size:14px;line-height:16px;padding:5px 0px 5px 0px'>
                                                        <strong>Total GST</strong>
                                                    </td>
                                                    <td width='auto' align='right' valign='top' style='color:#404041;font-size:14px;line-height:16px;padding:5px 5px 5px 5px'>
                                                        ₹ <asp:Label ID="lbl_total_gst" runat="server" Text=""></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align='left' valign='top' style='color:#404041;font-size:14px;line-height:16px;padding:5px 0px 5px 0px'>
                                                        <strong>Shipping</strong>
                                                    </td>
                                                    <td width='auto' align='right' valign='top' style='color:#404041;font-size:14px;line-height:16px;padding:5px 5px 5px 5px'>
                                                        ₹ <asp:Label ID="lbl_shipping" runat="server" Text=""></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr class="no-print">
                                                    <td align='left' valign='top' style='color:#404041;font-size:14px;line-height:16px;padding:5px 0px 5px 0px'>
                                                        <strong>Adjustment</strong>
                                                    </td>
                                                    <td width='auto' align='right' valign='top' style='color:#404041;font-size:14px;line-height:16px;padding:5px 5px 5px 5px'>
                                                        ₹ <asp:Label ID="lbl_adjustment" runat="server" Text=""></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align='left' valign='top' style='color:#404041;font-size:14px;line-height:16px;padding:5px 0px 5px 0px'>
                                                        <strong>Discount</strong>
                                                    </td>
                                                    <td width='auto' align='right' valign='top' style='color:#404041;font-size:14px;line-height:16px;padding:5px 5px 5px 5px'>
                                                        ₹ <asp:Label ID="lbl_discount" runat="server" Text=""></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align='left' valign='top' style='color:#404041;font-size:14px;line-height:16px;padding:5px 0px 5px 0px'>
                                                        <strong>Balance</strong>
                                                    </td>
                                                    <td width='auto' align='right' valign='top' style='color:#404041;font-size:14px;line-height:16px;padding:5px 5px 5px 5px'>
                                                        ₹ <asp:Label ID="lbl_balance" runat="server" Text=""></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align='left' valign='top' style='color:#404041;font-size:14px;line-height:16px;padding:5px 0px 5px 0px;'>
                                                        <strong>Invoice Total</strong>
                                                    </td>
                                                    <td width='auto' align='right' valign='top' style='color:#404041;font-size:14px;line-height:16px;padding:5px 5px 5px 5px;'>
                                                        ₹ <asp:Label ID="lbl_total" runat="server" onchange="inWords();" Text=""></asp:Label>
                                                    </td>
                                            </tbody>

                                        </table>
                                    </td>
                                </tr>
                                
                                
                                
                                <tr>
                                    <td style="padding:0px 20px 0px 20px;">
                                        <table width='100%' border='0' cellspacing='0' cellpadding='0' style='border-top:solid 2px #bf0707'>
                                            <tbody>
                                                <tr>
                                                    <td align='left' valign='top' style='padding:0px 5px 15px 5px'>
                                                        <table height='auto' width='100%' border='0' cellpadding='3' cellspacing='3'>
                                                            <tbody>

                                                                <tr>
																	<td valign='top' align="center" style='color:#404041;font-size:14px;padding:5px 5px 0px 0px'>
																		<asp:Label ID="lbl_company_address" runat="server" Text=""></asp:Label>
																	</td>
																</tr>
                                                                
                                                            </tbody>
                                                        </table>
                                                    </td>
                                                </tr>
                                            </tbody>
                                        </table>
                                    </td>
                                </tr>
                            </tbody>
                        </table>
                    </td>
                </tr>
            </tbody>
        </table>

    </div>

             


    
    </form>
</body>
</html>
