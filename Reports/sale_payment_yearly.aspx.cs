using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data;
using System.IO;
using System.Text;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.tool.xml;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;

public partial class Reports_sale_payment_yearly : System.Web.UI.Page
{
    SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["String"].ConnectionString);
    decimal balance, bal;
    int del_inv, c_id;
    string insert, admin_email;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["a_email"] != null)
        {
            if (Page.IsPostBack) return;
            this.FillRepeater();
        }
        else
        {
            Response.Redirect("../login.aspx");
        }
    }

    public void FillRepeater()
    {
        SqlCommand cmd = new SqlCommand("Select * From tbl_sale_invoice_payment inner join tbl_customer on tbl_sale_invoice_payment.c_id=tbl_customer.c_id WHERE si_date >= DATEADD(YEAR, DATEDIFF(YEAR, 0, GETDATE()), 0) AND si_date <  DATEADD(YEAR, DATEDIFF(YEAR, 0, GETDATE()) + 1, 0) Order By si_id desc", conn);
        SqlDataAdapter adapt = new SqlDataAdapter(cmd);
        DataTable dt = new DataTable();
        adapt.Fill(dt);
        if (dt.Rows.Count > 0)
        {
            Repeater1.DataSource = dt;
            Repeater1.DataBind();

            lbl_payed.Text = dt.Compute("Sum(si_pay)", string.Empty).ToString();
            //lbl_total_invoice.Text = dt.Compute("count(sl_id)", string.Empty).ToString();
            //Lbl_balance.Text = dt.Compute("Sum(si_balance)", string.Empty).ToString();

            lbl_Advance.Text = dt.Compute("Sum(si_discount)", string.Empty).ToString();
            lblTBalance.Text = dt.Compute("Sum(si_pay)", string.Empty).ToString();
            lblTInvoiceAmount.Text = dt.Compute("Sum(si_balance)", string.Empty).ToString();
            lblTdue.Text = dt.Compute("Sum(si_due)", string.Empty).ToString();
        }
        else
        {
            Panel1.Visible = false;
            lbl_payed.Text = "0";
            //lbl_total_invoice_amount.Text = "0";
            //Lbl_balance.Text = "0";
        }


    }




    public override void VerifyRenderingInServerForm(Control control)
    {
        /* Verifies that the control is rendered */
    }

    //protected void excel_export(object sender, EventArgs e)
    //{
    //    try
    //    {

    //        // Response.Close();
    //        string date = DateTime.Now.ToString("dd-MM-yyyy--HH-mm");
    //        var da = new SqlDataAdapter("Select tbl_sale.sl_invoice_no as [Invoice],CONVERT(VARCHAR(10), tbl_sale.sl_date, 103) as [Date],tbl_customer.c_name as [Customer Name],tbl_customer.c_contact as [Contact],tbl_sale.sl_order_no as [Order No],CONVERT(VARCHAR(10), tbl_sale.sl_invoice_date, 103) as [Invoice Date],CONVERT(VARCHAR(10), tbl_sale.sl_due_date, 103) as [Due Date],tbl_sale.sl_total_quantity as [Total Qty],tbl_sale.sl_sub_total as [Sub-Total],tbl_sale.sl_total_gst as [Total GST],tbl_sale.sl_discount as [Discount],tbl_sale.sl_adjustment as [Advance],tbl_sale.sl_total as [Total Amount] From tbl_sale inner join tbl_customer on tbl_sale.c_id=tbl_customer.c_id WHERE sl_invoice_date >= DATEADD(DAY, DATEDIFF(DAY, 0, GETDATE()), 0) AND sl_invoice_date <  DATEADD(DAY, DATEDIFF(DAY, 0, GETDATE()) + 1, 0) Order By sl_id desc", conn);
    //        var dt = new DataTable();
    //        da.Fill(dt);

    //        GridView1.DataSource = dt;
    //        GridView1.DataBind();
    //        Response.Clear();
    //        Response.Charset = "";
    //        Response.Cache.SetCacheability(HttpCacheability.NoCache);
    //        Response.ContentType = "application/vnd.xls";
    //        Response.AddHeader("content-disposition", "attachment;filename=List of Daily Sale Invoice-" + date + ".xls");

    //        System.IO.StringWriter sw = new System.IO.StringWriter();
    //        HtmlTextWriter htw = new HtmlTextWriter(sw);
    //        GridView1.RenderControl(htw);
    //        System.Text.StringBuilder sb1 = new System.Text.StringBuilder();
    //        sb1 = sb1.Append("<table cellspacing='0' cellpadding='0' width='100 % ' align='center' border='1'>" + sw.ToString() + "</table>");
    //        sw = null;
    //        htw = null;
    //        Response.Write(sb1.ToString());
    //        sb1.Remove(0, sb1.Length);
    //        Response.Flush();
    //        Response.End();
    //    }
    //    catch (Exception ex)
    //    {

    //    }
    //}


    //protected void pdf_export(object sender, EventArgs e)
    //{
    //    string date = DateTime.Now.ToString("dd-MM-yyyy--HH-mm");
    //    var da = new SqlDataAdapter("Select tbl_sale.sl_invoice_no as [Invoice],tbl_customer.c_name as [Customer Name],CONVERT(VARCHAR(10), tbl_sale.sl_invoice_date, 103) as [Invoice Date],CONVERT(VARCHAR(10), tbl_sale.sl_due_date, 103) as [Due Date],tbl_sale.sl_total_quantity as [Total Qty],tbl_sale.sl_sub_total as [Sub-Total],tbl_sale.sl_total_gst as [Total GST],tbl_sale.sl_total as [Total Amount] From tbl_sale inner join tbl_customer on tbl_sale.c_id=tbl_customer.c_id WHERE sl_invoice_date >= DATEADD(DAY, DATEDIFF(DAY, 0, GETDATE()), 0) AND sl_invoice_date <  DATEADD(DAY, DATEDIFF(DAY, 0, GETDATE()) + 1, 0) Order By sl_id desc", conn);
    //    var dt = new DataTable();
    //    da.Fill(dt);


    //    GridView1.DataSource = dt;
    //    GridView1.DataBind();


    //    using (StringWriter sw = new StringWriter())
    //    {
    //        using (HtmlTextWriter hw = new HtmlTextWriter(sw))
    //        {
    //            GridView1.RenderControl(hw);
    //            StringReader sr = new StringReader(sw.ToString());
    //            Document pdfDoc = new Document(PageSize.A4, 10f, 10f, 10f, 0f);
    //            PdfWriter writer = PdfWriter.GetInstance(pdfDoc, Response.OutputStream);
    //            pdfDoc.Open();

    //            XMLWorkerHelper.GetInstance().ParseXHtml(writer, pdfDoc, sr);
    //            pdfDoc.Close();
    //            Response.ContentType = "application/pdf";
    //            Response.AddHeader("content-disposition", "attachment;filename=List of Daily Sale Invoice-" + date + ".pdf");
    //            Response.Cache.SetCacheability(HttpCacheability.NoCache);
    //            Response.Write(pdfDoc);
    //            Response.End();
    //        }
    //    }

    //}

    protected void Repeater1_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {



    }
}