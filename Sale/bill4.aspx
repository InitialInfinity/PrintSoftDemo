<%@ Page Language="C#" AutoEventWireup="true" CodeFile="bill4.aspx.cs" Inherits="Sale_bill4" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset='UTF-8'>
<title>Editable Invoice</title>
<link rel="stylesheet" href="paper.css">

<style type="text/css">
    @page { size: A4 }


    * {
    margin: 0;
    padding: 0;
}
@media print
{
    @page
    {
         size: 8in 10in; 
    }
}
body {
    font: 14px/1.4 Georgia,serif;
}

#page-wrap {
    width: 900px;
    margin: 0 auto;
}
 {
    border: 0;
    font: 14px Georgia,Serif;
    overflow: hidden;
    resize: none;
}

table {
    border-collapse: collapse;
}

table td,table th {
    border: 1px solid #000;
    /* padding: 5px; */
}



/*container*/



.wrapper {
  width: 100%;
  border: 1px solid #000;
  margin: 10px 0;
}
.wrapper .row {
  border-bottom: 1px solid #000;
}
.wrapper .row .border-right {
  border-right: 1px solid #000;
  padding-left: 15px;
}
.wrapper .no-border {
  border-bottom: 0;
}

.margin-0 {
  margin: 0;
}

.padding-0 {
  padding: 0;
}

img {
  height: 30px;
}

.table {
  width: 100%;
  margin: 0;
}
.table > tbody > tr > td {
  border: 1px solid #000;
  padding: 5px 0 5px 10px;
  width: 40%;
}
.table > tbody > tr .first {
  border-top: 1px solid;
}
.table > tbody > tr .last {
  border-bottom: 0;
}
.table > tbody > tr b {
  display: block;
}
.table > tbody > tr span {
  font-size: 12px;
}

.invoice-bill {
  width: 100%;
  font-size: 12px;
}
.invoice-bill td {
  border: 1px solid #000;
  padding: 5px;
  border-top: none;
}
.invoice-bill .serial-no {
  width: 70px;
}
.invoice-bill .particulars {
  width: 500px;
}
.invoice-bill .amount {
  width: 150px;
}
.invoice-bill .particular-items {
  padding: 5px 10px;
}
.invoice-bill .amount-items {
  padding: 5px 0;
}

.entry-id {
  margin: 35px 0;
}

.bank-details {
  margin-top: 30px;
}

.authorised-sign-wrapper {
  width: 300px;
  border: 1px solid #000;
  padding: 5px 20px;
}

.top-head{
    text-align: center;
    padding: 5px;
}

.logo_box b{
    font-size: 24px;
    margin-top: -4rem;
}

.s2_head table td {
    padding: 5px;
    width: 50%;
    text-align: center;
    border: none;
}

.s3_head .s3_head_1{
    margin-top: -60px;
}
.s3_head_2{
    margin-top: 0rem;
}

.customer_details .table > tbody > tr .first {
    border-top: none;
    border: none;
}

.table_main_head td{
    border-bottom:none;
    text-align: center;
}
.table_sub_head td{
    border-top:none;
}
.gst1{
    border: 1px solid #000 !important;
}

.total_section{
    padding: 0px !important;
}
.total_section table{
    width: 100%;
}

.total_section table tr td{
    border-left: none;
    border-right: none;
}

.total_section .last_chaild td{
    border-bottom: none;
}

.last_row td{width: 430px;border-bottom: none;height: 150px;text-align: center;}

.product_deatils_table{
    height: 335px;
    text-align: center;
}
.cta-group a {
    display: inline-block;
    padding: 7px;
    border-radius: 4px;
    background: rgb(196, 57, 10);
    margin-right: 10px;
    min-width: 100px;
    text-align: center;
    color: #fff;
    font-size: 0.75em;
}
.cta-group .btn-primary {
    background: #00a63f;
}
.cta-group.mobile-btn-group {
    display: none;
}
.cta-group {
        text-align: center;
    }
    .cta-group.mobile-btn-group {
        display: block;
        margin-bottom: 20px;
    }


    @media print{
        .print {
            display:block;
        }
        .no-print{
            display:none;
        }
    }
/*..........*/
</style>
</head>

<body class="A4">
    <form id="form1" runat="server">
    <div id="page-wrap" class="sheet padding-10mm">
    <div class="container print">
  <div class="wrapper">
    <div class="row margin-0">
      <div class="col-sm-5">
        <p class="top-head"><b>GST TAX INVOICE</b></p>
      </div>
      <div class="col-sm-7 padding-0">
        <table class="table" cellspacing="0" cellpadding="10">
          <tbody>
          <tr>
            <td class="first logo_box">
              <b>SWAPNIL GRAPHICS</b>
              <span>Digital Flex Printing Lab</span>
            </td>
            <td class="first s2_head">
              <table>
                  <tbody>
                      <tr>
                          <td>Stickers</td>
                          <td>Wedding cards</td>
                      </tr>
                      <tr>
                          <td>Stickers</td>
                          <td>Wedding cards</td>
                      </tr>
                      <tr>
                          <td>Stickers</td>
                          <td>Wedding cards</td>
                      </tr>
                      <tr>
                          <td>Stickers</td>
                          <td>Wedding cards</td>
                      </tr>
                  </tbody>
              </table>
            </td>
            <td class="first s3_head">
              <b class="s3_head_1">Bill No: <asp:Label ID="lbl_invoice_no" runat="server" Text=""></asp:Label></b>
              <b class="s3_head_2">Date: <asp:Label ID="lbl_invoice_date" runat="server" Text=""></asp:Label></b>
            </td>
          </tr>
          </tbody>
        </table>
      </div>
    </div>
    <div class="row margin-0">
      <div class="col-sm-5 border-right customer_details">
        <table class="table">
          <tr>
            <td class="first b-left">
              <b>M/s / Customer Name:</b>
              <span><asp:Label ID="lbl_customer_name" runat="server" Text=""></asp:Label></span>
            </td>
          </tr>
          <tr>
            <td class="first b-left">
              <b>Contact No:</b>
              <span><asp:Label ID="lbl_customer_contact" runat="server" Text=""></asp:Label></span>
            </td>
            <td class="first">
              <b>Address:</b>
              <span><asp:Label ID="lbl_customer_address" runat="server" Text=""></asp:Label></span>
            </td>
          </tr>
          <tr>
            <td class="first b-left">
              <b>GST No:</b>
              <span><asp:Label ID="lbl_gst_no" runat="server" Text=""></asp:Label></span>
            </td>
          </tr>
          <tr>
            <td class="first b-left">
              <b>Job Name:</b>
              <span><asp:Label ID="Label5" runat="server" Text="Label"></asp:Label></span>
            </td>
          </tr>
        </table>
      </div>

    </div>
    <div class="row margin-0">
      <div class="col-sm-12 padding-0">
        <table class="invoice-bill">
          <tr class="table_main_head">
            <td class="serial-no">
              <b>SL. No.</b>
            </td>
            <td class="particulars">
              <b>Description of goods</b>
            </td>
            <td class="amount">
              <b>HSN/SAC</b>
            </td>
            <td class="amount">
              <b>Size</b>
            </td>
            <td class="amount">
              <b>Sq.ft</b>
            </td>
            <td class="amount">
              <b>Rate</b>
            </td>
            <td class="amount">
              <b>Quantity</b>
            </td>
            <td class="amount">
              <b>Amount</b>
            </td>
            <td class="gst1" colspan="2">
              <b>CGST</b>
            </td>
            <td class="gst1" colspan="2">
              <b>SGST</b>
            </td>
          </tr>
          <tr class="table_sub_head">
            <td class="serial-no">
              
            </td>
            <td>
              
            </td>
            <td>
             
            </td>
            <td>
              
            </td>
            <td>
              
            </td>
            <td>
              
            </td>
            <td>
              
            </td>
            <td>
              
            </td>
            <td>
              <b>Rate</b>
            </td>
            <td>
              <b>Amount</b>
            </td>
            <td>
              <b>Rate</b>
            </td>
            <td>
              <b>Amount</b>
            </td>
          </tr>
            <asp:Repeater ID="Repeater2" runat="server">
              <ItemTemplate>
          <tr class="product_deatils_table">
            <td>
              <asp:Label ID="lbl_id" runat="server" Text='<%# Eval("s_id") %>'></asp:Label>
            </td>
            <td>
              <p>
                <strong><asp:Label ID="lbl_product" runat="server" Text='<%# Eval("s_product_name") %>'></asp:Label></strong><br/><asp:Label ID="Label1" runat="server" style="font-size: 12px;" Text='<%# Eval("s_desc") %>'></asp:Label> 
              </p>
            </td>
            <td>
              <p><asp:Label ID="lbl_hsn" runat="server" Text='<%# Eval("s_product_hsn") %>'></asp:Label></p>
            </td>
            <td>
              <p>
                <asp:Label ID="lbl_height" runat="server" Text='<%# Eval("s_height") %>'></asp:Label> X <asp:Label ID="lbl_width" runat="server" Text='<%# Eval("s_width") %>'></asp:Label>
              </p>
            </td>
            <td>
              <p>
                <asp:Label ID="Label4" runat="server" Text='<%# Eval("s_size") %>'></asp:Label>
              </p>
            </td>
            <td>
              <p>
               <asp:Label ID="lbl_rate" runat="server" Text='<%# Eval("s_rate") %>'></asp:Label>
              </p>
            </td>
            <td>
              <p>
                <asp:Label ID="lbl_qty" runat="server" Text='<%# Eval("s_quantity") %>'></asp:Label>
              </p>
            </td>
            <td>
              <p>
                <asp:Label ID="lbl_amount" runat="server" Text='<%# Eval("s_amount") %>'></asp:Label>
              </p>
            </td>
            <td>
              <p>
                <asp:Label ID="Label2" runat="server" Text='<%# Eval("s_cgsta") %>'></asp:Label>
              </p>
            </td>
            <td>
              <p>
                <asp:Label ID="lbl_cgst" runat="server" Text='<%# Eval("s_cgstp") %>'></asp:Label>
              </p>
            </td>
            <td>
              <p>
                <asp:Label ID="Label3" runat="server" Text='<%# Eval("s_sgsta") %>'></asp:Label>
              </p>
            </td>
            <td>
              <p>
                <asp:Label ID="lbl_sgst" runat="server" Text='<%# Eval("s_sgstp") %>'></asp:Label>
              </p>
            </td>
          </tr>
             </ItemTemplate>
             </asp:Repeater>
          <tr>
            <td colspan="5"></td>
            <td colspan="2">
              <b>Total</b>
            </td>
            <td>₹ <asp:Label ID="lbl_total_amt" runat="server" Text=""></asp:Label></td>
            <td colspan="2">₹ <asp:Label ID="lbl_total_cgst" runat="server" Text=""></asp:Label></td>
            <td colspan="2">₹ <asp:Label ID="lbl_total_sgst" runat="server" Text=""></asp:Label></td>
          </tr>


          <tr>
            <td colspan="7">
                <b>Note:</b>
                <div class="particular-items">
               <p>
                  1. Setup Fees
                </p>
                <p>
                  2. POC Fees
                </p>
              </div>
            </td>
            <td colspan="3">
              <div class="particular-items">
               
                <p>
                 Setup Fees
                </p>
                <p>
                  POC Fees
                </p>
                <p>
                 Setup Fees
                </p>
                <p>
                  POC Fees
                </p>
                <p>
                  POC Fees
                </p>
              </div>
            </td>
            <td colspan="2">
                <div class="particular-items amount-items">
                <p>₹39</p>
                <p>₹19</p>
                <p>₹29</p>
                <p>₹49</p>
                <p>₹99</p>
              </div>
            </td>
            
            
          </tr>

                    <tr>
            <td colspan="7">
                <div class="particular-items">
               <p>
                  Company GST No: <asp:Label ID="lbl_company_gst" runat="server" Text=""></asp:Label>
                </p>
                <p>
                  Bank Details: <asp:Label ID="lbl_bank_name" runat="server" Text=""></asp:Label>
                </p>
                <p>
                  IFSC CODE: <asp:Label ID="lbl_ifsc" runat="server" Text=""></asp:Label>
                </p>
                <p>
                  Branch: <asp:Label ID="lbl_branch" runat="server" Text=""></asp:Label>
                </p>
              </div>
            </td>
            <td colspan="3" class="total_section">
              <table>
                  <tbody>
                      <tr>
                          <td>Total Amount: <b>Rs.</b></td>
                      </tr>
                      <tr>
                          <td>Advance </td>
                      </tr>
                      <tr class="last_chaild">
                          <td>Balance </td>
                      </tr>
                  </tbody>
              </table>
            </td>
            <td colspan="2" class="total_section">
                <table>
                  <tbody>
                      <tr>
                          <td>₹ <asp:Label ID="lbl_total" runat="server" onchange="inWords();" Text=""></asp:Label></td>
                      </tr>
                      <tr>
                          <td> ₹ <asp:Label ID="lbl_adjustment" runat="server" Text=""></asp:Label></td>
                      </tr>
                      <tr class="last_chaild">
                          <td> ₹ <asp:Label ID="lbl_balance" runat="server" Text=""></asp:Label></td>
                      </tr>
                  </tbody>
              </table>
            </td>
            
            
          </tr>
        </table>
        <table>
            <tbody>
                <tr class="last_row">
                      <td>Recivers Stamp & Signature</td>
                      <td><b>For Swapnil Graphics</b></td>
                </tr>
            </tbody>
        </table>
      </div>
    </div>
  </div>
</div>

        <div class="cta-group no-print">
        <a href="javascript:void(0);" type="button" class="btn-primary" onclick="jsPrintAll()">Print</a>
 </div> 

        <tr class="blank-space"></tr>



    </div>

        <script>
var jsPrintAll = function () {
setTimeout(function () {
window.print();
}, 500);
}
</script>
    </form>
</body>
</html>
