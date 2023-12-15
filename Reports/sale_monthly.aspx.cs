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
using System.Text;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.tool.xml;
using System.Web.UI.HtmlControls;

public partial class Reports_sale_monthly : System.Web.UI.Page
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
        SqlCommand cmd = new SqlCommand("Select * From tbl_sale inner join tbl_customer on tbl_sale.c_id=tbl_customer.c_id WHERE sl_invoice_date >= DATEADD(MONTH, DATEDIFF(MONTH, 0, GETDATE()), 0) AND sl_invoice_date <  DATEADD(MONTH, DATEDIFF(MONTH, 0, GETDATE()) + 1, 0) Order By sl_id desc", conn);
        SqlDataAdapter adapt = new SqlDataAdapter(cmd);
        DataTable dt = new DataTable();
        adapt.Fill(dt);
        if (dt.Rows.Count > 0)
        {
            Repeater1.DataSource = dt;
            Repeater1.DataBind();

            lbl_total_invoice_amount.Text = dt.Compute("Sum(sl_total)", string.Empty).ToString();
            lbl_total_invoice.Text = dt.Compute("count(sl_id)", string.Empty).ToString();
            Lbl_balance.Text = dt.Compute("Sum(sl_balance)", string.Empty).ToString();

            lbl_Advance.Text = dt.Compute("Sum(sl_adjustment)", string.Empty).ToString();
            lblTBalance.Text = dt.Compute("Sum(sl_balance)", string.Empty).ToString();
            lblTInvoiceAmount.Text = dt.Compute("Sum(sl_total)", string.Empty).ToString();
        }
        else
        {
            Panel1.Visible = false;
            lbl_total_invoice.Text = "0";
            lbl_total_invoice_amount.Text = "0";
            Lbl_balance.Text = "0";
        }

        //SqlCommand cmd2 = new SqlCommand("select sum(si_pay) from tbl_sale_invoice_payment  order by si_id desc", conn);
        //SqlDataAdapter adapt2 = new SqlDataAdapter(cmd2);
        //DataTable dt2 = new DataTable();
        //adapt.Fill(dt2);
        //if (dt2.Rows.Count > 0)
        //{
        //    if (dt2.Rows[0][0] == System.DBNull.Value)
        //    {
        //        Lbl_advace.Text = "0";
        //    }
        //    else
        //    {
        //        Lbl_advace.Text = dt2.Rows[0][0].ToString();
        //    }
        //}
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

            using (SqlCommand cmd2 = new SqlCommand("select * from tbl_sale inner join tbl_customer on tbl_sale.c_id=tbl_customer.c_id where sl_invoice_no='" + invoiceno + "'", conn))
            {
                SqlDataAdapter adapt2 = new SqlDataAdapter(cmd2);
                DataTable dt2 = new DataTable();
                adapt2.Fill(dt2);
                if (dt2.Rows.Count > 0)
                {
                    bal = Convert.ToDecimal(dt2.Rows[0]["sl_balance"]);
                    c_id = Convert.ToInt32(dt2.Rows[0]["c_id"]);
                }
            }
            using (SqlCommand cmd3 = new SqlCommand("update tbl_customer set c_opening_balance=c_opening_balance- '" + bal + "' where c_id='" + c_id + "'", conn))
            {
                conn.Open();
                cmd3.ExecuteNonQuery();
                conn.Close();
            }
            using (SqlCommand cmd4 = new SqlCommand("DELETE FROM tbl_sale_invoice WHERE s_invoice_no = @s_invoice_no", conn))
            {

                cmd4.Parameters.AddWithValue("@s_invoice_no", invoiceno);
                conn.Open();
                cmd4.ExecuteNonQuery();
                conn.Close();
            }
            using (SqlCommand cmd5 = new SqlCommand("DELETE FROM tbl_sale WHERE sl_invoice_no = @sl_invoice_no", conn))
            {
                cmd5.Parameters.AddWithValue("@sl_invoice_no", invoiceno);
                conn.Open();
                cmd5.ExecuteNonQuery();
                conn.Close();
            }
            using (SqlCommand cmd6 = new SqlCommand("DELETE FROM tbl_sale_invoice_payment WHERE si_invoice = @sl_invoice_no", conn))
            {
                cmd6.Parameters.AddWithValue("@sl_invoice_no", invoiceno);
                conn.Open();
                cmd6.ExecuteNonQuery();
                conn.Close();
            }

            Response.Redirect(Request.RawUrl);
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
            var da = new SqlDataAdapter("Select tbl_sale.sl_invoice_no as [Invoice],CONVERT(VARCHAR(10), tbl_sale.sl_date, 103) as [Date],tbl_customer.c_name as [Customer Name],tbl_customer.c_contact as [Contact],tbl_sale.sl_order_no as [Order No],CONVERT(VARCHAR(10), tbl_sale.sl_invoice_date, 103) as [Invoice Date],CONVERT(VARCHAR(10), tbl_sale.sl_due_date, 103) as [Due Date],tbl_sale.sl_total_quantity as [Total Qty],tbl_sale.sl_sub_total as [Sub-Total],tbl_sale.sl_total_gst as [Total GST],tbl_sale.sl_discount as [Discount],tbl_sale.sl_adjustment as [Advance],tbl_sale.sl_total as [Total Amount] From tbl_sale inner join tbl_customer on tbl_sale.c_id=tbl_customer.c_id WHERE sl_invoice_date >= DATEADD(MONTH, DATEDIFF(MONTH, 0, GETDATE()), 0) AND sl_invoice_date <  DATEADD(MONTH, DATEDIFF(MONTH, 0, GETDATE()) + 1, 0) Order By sl_id desc", conn);
            var dt = new DataTable();
            da.Fill(dt);

            if (dt.Rows.Count == 0)
            {
                System.Web.UI.ScriptManager.RegisterStartupScript(this, GetType(), "displayalertmessage", "alert('No data to export');", true);
            }

            else
            {



                GridView1.DataSource = dt;
                GridView1.DataBind();
                Response.Clear();
                Response.Charset = "";
                Response.Cache.SetCacheability(HttpCacheability.NoCache);
                Response.ContentType = "application/vnd.xls";
                Response.AddHeader("content-disposition", "attachment;filename=List of Monthly Sale Invoice-" + date + ".xls");

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
        }
        catch (Exception ex)
        {

        }
    }


    protected void pdf_export(object sender, EventArgs e)
    {
        string date = DateTime.Now.ToString("dd-MM-yyyy--HH-mm");
        var da = new SqlDataAdapter("Select tbl_sale.sl_invoice_no as [Invoice],tbl_customer.c_name as [Customer Name],CONVERT(VARCHAR(10), tbl_sale.sl_invoice_date, 103) as [Invoice Date],CONVERT(VARCHAR(10), tbl_sale.sl_due_date, 103) as [Due Date],tbl_sale.sl_total_quantity as [Total Qty],tbl_sale.sl_sub_total as [Sub-Total],tbl_sale.sl_total_gst as [Total GST],tbl_sale.sl_total as [Total Amount] From tbl_sale inner join tbl_customer on tbl_sale.c_id=tbl_customer.c_id WHERE sl_invoice_date >= DATEADD(MONTH, DATEDIFF(MONTH, 0, GETDATE()), 0) AND sl_invoice_date <  DATEADD(MONTH, DATEDIFF(MONTH, 0, GETDATE()) + 1, 0) Order By sl_id desc", conn);
        var dt = new DataTable();
        da.Fill(dt);

        if (dt.Rows.Count == 0)
        {
            System.Web.UI.ScriptManager.RegisterStartupScript(this, GetType(), "displayalertmessage", "alert('No data to export');", true);
        }

        else
        {

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
                    Response.AddHeader("content-disposition", "attachment;filename=List of Monthly Sale Invoice-" + date + ".pdf");
                    Response.Cache.SetCacheability(HttpCacheability.NoCache);
                    Response.Write(pdfDoc);
                    Response.End();
                }
            }
        }

    }
  
    protected void Repeater1_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        

        if (e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
        {
            Label tr = e.Item.FindControl("lbl_status") as Label;


            DataRowView drv = e.Item.DataItem as DataRowView;
            decimal balance = Convert.ToDecimal(drv["sl_balance"]);
            decimal total = Convert.ToDecimal(drv["sl_total"]);

            if (balance == 0)
            {
                tr.Text = "Paid";
                tr.Attributes.Add("class", "label label-success");
            }
            else if (balance == total)
            {
                tr.Text = "UnPaid";
                tr.Attributes.Add("class", "label label-danger");
            }
            else
            {
                tr.Text = "Partially";
                tr.Attributes.Add("class", "label label-warning");
            }


        }

    }

}