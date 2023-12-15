using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using System.IO;
using iTextSharp.text;
using iTextSharp.text.html.simpleparser;
using iTextSharp.text.pdf;
using iTextSharp.tool.xml;

public partial class Quotation_report : System.Web.UI.Page
{
    SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["String"].ConnectionString);
    string insert;
    string admin_email;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["a_email"] != null)
        {
            if (Page.IsPostBack) return;
      
            try
            {
                insert = (Request.QueryString["insert"]??"").ToString();
                if (insert == "success")
                {
                    Panel2.Visible = true;
                }
                else
                {
                    Panel2.Visible = false;
                }
            }
            catch (Exception ex)
            { Panel2.Visible = false; }
            this.FillRepeater();

        }
        else
        {
            Response.Redirect("../login.aspx");
        }
    }
  
   
    public void FillRepeater()
    {
        SqlCommand cmd = new SqlCommand("select * from tbl_gst_quotation inner join tbl_customer on tbl_gst_quotation.c_id=tbl_customer.c_id order by qu_id desc", conn);
        SqlDataAdapter adapt = new SqlDataAdapter(cmd);
        DataTable dt = new DataTable();
        adapt.Fill(dt);
        if (dt.Rows.Count > 0)
        {
            Repeater1.DataSource = dt;
            Repeater1.DataBind();
        }
    }


    protected void DeleteSale(object sender, EventArgs e)
    {
        SqlCommand cmd = new SqlCommand("select * from tbl_admin_login", conn);
        SqlDataAdapter adapt = new SqlDataAdapter(cmd);
        DataTable dt = new DataTable();
        adapt.Fill(dt);
        if (dt.Rows.Count > 0)
        {
            admin_email = dt.Rows[0]["a_email"].ToString();
        }
        if (admin_email.ToString() == Session["a_email"].ToString() || Session["admin_email"] != null)
        {
            String invoiceno = ((sender as LinkButton).NamingContainer.FindControl("lbl_invoice") as Label).Text;


        using (SqlCommand cmd2 = new SqlCommand("DELETE FROM tbl_gst_quotation_details WHERE q_quotation_no = @q_quotation_no", conn))
        {

            cmd2.Parameters.AddWithValue("@q_quotation_no", invoiceno);
            conn.Open();
            cmd2.ExecuteNonQuery();
            conn.Close();
        }
        using (SqlCommand cmd3 = new SqlCommand("DELETE FROM tbl_gst_quotation WHERE qu_invoice_no = @qu_invoice_no", conn))
        {
            cmd3.Parameters.AddWithValue("@qu_invoice_no", invoiceno);
            conn.Open();
            cmd3.ExecuteNonQuery();
            conn.Close();
        }

        this.FillRepeater();
        }
        else
        {
            Response.Redirect("../access_denied.aspx");

        }
    }
    
    public override void VerifyRenderingInServerForm(Control control)
    {
        /* Verifies that the control is rendered */
    }
    protected void excel_export(object sender, EventArgs e)
    {
        try
        {

            // Response.Close();
            string date = DateTime.Now.ToString("dd-MM-yyyy--HH-mm");
            var da = new SqlDataAdapter("Select tbl_gst_quotation.qu_invoice_no as [Quotation],CONVERT(VARCHAR(10), tbl_gst_quotation.qu_date, 103) as [Date],tbl_customer.c_name as [Customer Name],tbl_customer.c_contact as [Contact],CONVERT(VARCHAR(10), tbl_gst_quotation.qu_invoice_date, 103) as [Quotation Date],CONVERT(VARCHAR(10), tbl_gst_quotation.qu_due_date, 103) as [Valid Date],tbl_gst_quotation.qu_total_quantity as [Total Qty],tbl_gst_quotation.qu_sub_total as [Sub-Total],tbl_gst_quotation.qu_total_gst as [Total GST],tbl_gst_quotation.qu_shipping_charges as [Shipping Charges],tbl_gst_quotation.qu_discount as [Discount],tbl_gst_quotation.qu_adjustment as [Adjustment],tbl_gst_quotation.qu_total as [Total Amount] From tbl_gst_quotation inner join tbl_customer on tbl_gst_quotation.c_id=tbl_customer.c_id Order By qu_id desc", conn);
            var dt = new DataTable();
            da.Fill(dt);

            GridView1.DataSource = dt;
            GridView1.DataBind();
            Response.Clear();
            Response.Charset = "";
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.ContentType = "application/vnd.xls";
            Response.AddHeader("content-disposition", "attachment;filename=List of GST Quotation-" + date + ".xls");

            System.IO.StringWriter sw = new System.IO.StringWriter();
            HtmlTextWriter htw = new HtmlTextWriter(sw);
            GridView1.RenderControl(htw);
            System.Text.StringBuilder sb1 = new System.Text.StringBuilder();
            sb1 = sb1.Append("<table cellspacing='0' cellpadding='0' width='100 % ' align='center' border='1'>" + sw.ToString() + "</table>");
            sw = null;
            htw = null;
            Response.Write(sb1.ToString());
            sb1.Remove(0, sb1.Length);
            Response.Flush();
            Response.End();
        }
        catch (Exception ex)
        {

        }
    }

    protected void pdf_export(object sender, EventArgs e)
    {
        string date = DateTime.Now.ToString("dd-MM-yyyy--HH-mm");
        var da = new SqlDataAdapter("Select tbl_gst_quotation.qu_invoice_no as [Quotation],tbl_customer.c_name as [Customer Name],CONVERT(VARCHAR(10), tbl_gst_quotation.qu_invoice_date, 103) as [Quotation Date],CONVERT(VARCHAR(10), tbl_gst_quotation.qu_due_date, 103) as [Valid Date],tbl_gst_quotation.qu_total_quantity as [Total Qty],tbl_gst_quotation.qu_sub_total as [Sub-Total],tbl_gst_quotation.qu_total_gst as [Total GST],tbl_gst_quotation.qu_total as [Total Amount] From tbl_gst_quotation inner join tbl_customer on tbl_gst_quotation.c_id=tbl_customer.c_id Order By qu_id desc", conn);
        var dt = new DataTable();
        da.Fill(dt);


        GridView1.DataSource = dt;
        GridView1.DataBind();

        
        using (StringWriter sw = new StringWriter())
        {
            using (HtmlTextWriter hw = new HtmlTextWriter(sw))
            {
                GridView1.RenderControl(hw);
                StringReader sr = new StringReader(sw.ToString());
                Document pdfDoc = new Document(PageSize.A4, 10f, 10f, 10f, 0f);
                PdfWriter writer = PdfWriter.GetInstance(pdfDoc, Response.OutputStream);
                pdfDoc.Open();

                XMLWorkerHelper.GetInstance().ParseXHtml(writer, pdfDoc, sr);
                pdfDoc.Close();
                Response.ContentType = "application/pdf";
                Response.AddHeader("content-disposition", "attachment;filename=List of GST Quotation-" + date + ".pdf");
                Response.Cache.SetCacheability(HttpCacheability.NoCache);
                Response.Write(pdfDoc);
                Response.End();
            }
        }

    }


}