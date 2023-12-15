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
using iTextSharp.text.pdf;
using iTextSharp.tool.xml;

public partial class Reports_purchase_daily : System.Web.UI.Page
{
    SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["String"].ConnectionString);
    decimal balance, bal;
    int del_inv, v_id;
    string insert;
    string admin_email;
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
        SqlCommand cmd = new SqlCommand("Select tbl_purchase.pu_id,tbl_purchase.pu_invoice_no,CONVERT( varchar, tbl_purchase.pu_date, 105)as pu_date,tbl_purchase.v_id,tbl_purchase.pu_order_no,tbl_purchase.pu_invoice_date,tbl_purchase.pu_due_date,tbl_purchase.pu_total_quantity,tbl_purchase.pu_discount,tbl_purchase.pu_sub_total,tbl_purchase.pu_total_gst,tbl_purchase.pu_shipping_charges,tbl_purchase.pu_adjustment,tbl_purchase.pu_total,tbl_purchase.pu_total_cgst,tbl_purchase.pu_total_sgst,tbl_purchase.pu_total_igst,tbl_purchase.pu_total_taxable,tbl_purchase.pu_balance,tbl_purchase.pu_product_name,tbl_vendor.v_id,tbl_vendor.v_name,tbl_vendor.v_address,tbl_vendor.v_contact,tbl_vendor.v_gst_no,tbl_vendor.v_opening_balance,tbl_vendor.v_email,tbl_vendor.v_contact2 From tbl_purchase inner join tbl_vendor on tbl_purchase.v_id=tbl_vendor.v_id WHERE pu_invoice_date >= DATEADD(DAY, DATEDIFF(DAY, 0, GETDATE()), 0) AND pu_invoice_date <  DATEADD(DAY, DATEDIFF(DAY, 0, GETDATE()) + 1, 0) Order By pu_id desc", conn);
        //SqlCommand cmd = new SqlCommand("Select * From tbl_purchase inner join tbl_vendor on tbl_purchase.v_id=tbl_vendor.v_id WHERE pu_invoice_date >= DATEADD(DAY, DATEDIFF(DAY, 0, GETDATE()), 0) AND pu_invoice_date <  DATEADD(DAY, DATEDIFF(DAY, 0, GETDATE()) + 1, 0) Order By pu_id desc", conn);
        SqlDataAdapter adapt = new SqlDataAdapter(cmd);
        DataTable dt = new DataTable();
        adapt.Fill(dt);
        if (dt.Rows.Count > 0)
        {
            Repeater1.DataSource = dt;
            Repeater1.DataBind();

            lbl_total_invoice_amount.Text = dt.Compute("Sum(pu_total)", string.Empty).ToString();
            lbl_total_invoice.Text = dt.Compute("count(pu_id)", string.Empty).ToString();
            Lbl_balance.Text = dt.Compute("Sum(pu_balance)", string.Empty).ToString();

           // lbl_Advance.Text = dt.Compute("Sum(sl_adjustment)", string.Empty).ToString();
            lblTBalance.Text = dt.Compute("Sum(pu_balance)", string.Empty).ToString();
            lblTInvoiceAmount.Text = dt.Compute("Sum(pu_total)", string.Empty).ToString();
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

            using (SqlCommand cmd2 = new SqlCommand("select * from tbl_purchase where pu_invoice_no='" + invoiceno + "'", conn))
            {
                SqlDataAdapter adapt2 = new SqlDataAdapter(cmd2);
                DataTable dt2 = new DataTable();
                adapt2.Fill(dt2);
                if (dt2.Rows.Count > 0)
                {
                    bal = Convert.ToDecimal(dt2.Rows[0]["pu_balance"]);
                    v_id = Convert.ToInt32(dt2.Rows[0]["v_id"]);

                }
            }
            using (SqlCommand cmd3 = new SqlCommand("update tbl_vendor set v_opening_balance=v_opening_balance - '" + bal + "' where v_id='" + v_id + "'", conn))
            {
                conn.Open();
                cmd3.ExecuteNonQuery();

                conn.Close();
            }
            using (SqlCommand cmd4 = new SqlCommand("DELETE FROM tbl_purchase_invoice WHERE pc_invoice_no = @pc_invoice_no", conn))
            {

                cmd4.Parameters.AddWithValue("@pc_invoice_no", invoiceno);
                conn.Open();
                cmd4.ExecuteNonQuery();
                conn.Close();
            }
            using (SqlCommand cmd5 = new SqlCommand("DELETE FROM tbl_purchase WHERE pu_invoice_no = @pu_invoice_no", conn))
            {
                cmd5.Parameters.AddWithValue("@pu_invoice_no", invoiceno);
                conn.Open();
                cmd5.ExecuteNonQuery();
                conn.Close();
            }
            using (SqlCommand cmd6 = new SqlCommand("DELETE FROM tbl_purchase_invoice_payment WHERE pi_invoice = @sl_invoice_no", conn))
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
            var da = new SqlDataAdapter("Select tbl_purchase.pu_invoice_no as [Invoice],CONVERT(VARCHAR(10), tbl_purchase.pu_date, 103) as [Date],tbl_vendor.v_name as [Vendor Name],tbl_vendor.v_contact as [Contact],tbl_purchase.pu_order_no as [Order No],CONVERT(VARCHAR(10), tbl_purchase.pu_invoice_date, 103) as [Invoice Date],CONVERT(VARCHAR(10), tbl_purchase.pu_due_date, 103) as [Due Date],tbl_purchase.pu_total_quantity as [Total Qty],tbl_purchase.pu_sub_total as [Sub-Total],tbl_purchase.pu_total_gst as [Total GST],tbl_purchase.pu_shipping_charges as [Shipping Charges],tbl_purchase.pu_discount as [Discount],tbl_purchase.pu_adjustment as [Adjustment],tbl_purchase.pu_total as [Total Amount] From tbl_purchase inner join tbl_vendor on tbl_purchase.v_id=tbl_vendor.v_id WHERE pu_invoice_date >= DATEADD(DAY, DATEDIFF(DAY, 0, GETDATE()), 0) AND pu_invoice_date <  DATEADD(DAY, DATEDIFF(DAY, 0, GETDATE()) + 1, 0) Order By pu_id desc", conn);
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
            Response.AddHeader("content-disposition", "attachment;filename=List of Daily Purchase Invoice-" + date + ".xls");

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
        var da = new SqlDataAdapter("Select tbl_purchase.pu_invoice_no as [Invoice],tbl_vendor.v_name as [Vendor Name],CONVERT(VARCHAR(10), tbl_purchase.pu_invoice_date, 103) as [Invoice Date],CONVERT(VARCHAR(10), tbl_purchase.pu_due_date, 103) as [Due Date],tbl_purchase.pu_total_quantity as [Total Qty],tbl_purchase.pu_sub_total as [Sub-Total],tbl_purchase.pu_total_gst as [Total GST],tbl_purchase.pu_total as [Total Amount] From tbl_purchase inner join tbl_vendor on tbl_purchase.v_id=tbl_vendor.v_id WHERE pu_invoice_date >= DATEADD(DAY, DATEDIFF(DAY, 0, GETDATE()), 0) AND pu_invoice_date <  DATEADD(DAY, DATEDIFF(DAY, 0, GETDATE()) + 1, 0) Order By pu_id desc", conn);
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
                    Response.AddHeader("content-disposition", "attachment;filename=List of Daily Purchase Invoice-" + date + ".pdf");
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
            decimal balance = Convert.ToDecimal(drv["pu_balance"]);
            decimal total = Convert.ToDecimal(drv["pu_total"]);

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