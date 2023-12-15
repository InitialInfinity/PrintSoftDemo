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

public partial class Purchase_list_of_roll_purchase : System.Web.UI.Page
{
    SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["String"].ConnectionString);
    decimal balance, bal, tsqft;
    int del_inv, v_id;
    string insert;
    string admin_email, product_name;
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
        SqlCommand cmd = new SqlCommand("select * from tbl_roll_purchase inner join tbl_vendor on tbl_roll_purchase.v_id=tbl_vendor.v_id order by rpu_id desc", conn);
        SqlDataAdapter adapt = new SqlDataAdapter(cmd);
        DataTable dt = new DataTable();
        adapt.Fill(dt);
        if (dt.Rows.Count > 0)
        {
            Repeater1.DataSource = dt;
            Repeater1.DataBind();
            lbl_total_invoice_amount.Text = dt.Compute("Sum(rpu_total)", string.Empty).ToString();
            lbl_total_invoice.Text = dt.Compute("count(rpu_id)", string.Empty).ToString();
            Lbl_balance.Text = dt.Compute("Sum(rpu_balance)", string.Empty).ToString();
        }
        else
        {
            lbl_total_invoice.Text = "0";
            lbl_total_invoice_amount.Text = "0";
            Lbl_balance.Text = "0";
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

            using (SqlCommand cmd2 = new SqlCommand("select * from tbl_roll_purchase where rpu_invoice_no='" + invoiceno + "'", conn))
            {
                SqlDataAdapter adapt2 = new SqlDataAdapter(cmd2);
                DataTable dt2 = new DataTable();
                adapt2.Fill(dt2);
                if (dt2.Rows.Count > 0)
                {
                    foreach (DataRow row in dt2.Rows)
                    {

                        bal = Convert.ToDecimal(row["rpu_balance"]);
                        v_id = Convert.ToInt32(row["v_id"]);
                        tsqft = Convert.ToDecimal(row["rpu_size"]);
                        product_name = Convert.ToString(row["rpu_product_name"]);


                        //stock start here
                        //SqlCommand cmd33 = new SqlCommand("UPDATE tbl_purchase_product SET p_stock=p_stock-('" + tsqft + "') WHERE p_name='" + Convert.ToString(product_name) + "'", conn);
                        SqlCommand cmd33 = new SqlCommand("UPDATE tbl_purchase_product SET p_stock = p_stock - @Quantity WHERE p_name = @ProductName AND p_id = (SELECT TOP 1 p_id FROM tbl_purchase_product WHERE p_name = @ProductName)", conn);


                        cmd33.Parameters.AddWithValue("@Quantity", tsqft);
                        cmd33.Parameters.AddWithValue("@ProductName", Convert.ToString(product_name));


                        conn.Open();
                        cmd33.ExecuteNonQuery();
                        conn.Close();
                        //stock end here
                    }


                }
            }
            using (SqlCommand cmd3 = new SqlCommand("update tbl_vendor set v_opening_balance=v_opening_balance - '" + bal + "' where v_id='" + v_id + "'", conn))
            {
                conn.Open();
                cmd3.ExecuteNonQuery();

                conn.Close();
            }
           
            using (SqlCommand cmd4 = new SqlCommand("DELETE FROM tbl_roll_purchase_invoice WHERE rpc_invoice_no = @pc_invoice_no", conn))
            {

                cmd4.Parameters.AddWithValue("@pc_invoice_no", invoiceno);
                conn.Open();
                cmd4.ExecuteNonQuery();
                conn.Close();
            }
            using (SqlCommand cmd5 = new SqlCommand("DELETE FROM tbl_roll_purchase WHERE rpu_invoice_no = @pu_invoice_no", conn))
            {
                cmd5.Parameters.AddWithValue("@pu_invoice_no", invoiceno);
                conn.Open();
                cmd5.ExecuteNonQuery();
                conn.Close();
            }
            using (SqlCommand cmd6 = new SqlCommand("DELETE FROM tbl_roll_purchase_invoice_payment WHERE rpi_invoice = @sl_invoice_no", conn))
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
    protected void close()
    {

        ScriptManager.RegisterStartupScript(this, GetType(), "Modal", "Closepopup();", true);
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
            var da = new SqlDataAdapter("Select tbl_roll_purchase.rpu_invoice_no as [Invoice],CONVERT(VARCHAR(10), tbl_roll_purchase.rpu_date, 103) as [Date],tbl_vendor.v_name as [Vendor Name],tbl_vendor.v_contact as [Contact],tbl_roll_purchase.rpu_order_no as [Order No],CONVERT(VARCHAR(10), tbl_roll_purchase.rpu_invoice_date, 103) as [Invoice Date],CONVERT(VARCHAR(10), tbl_roll_purchase.rpu_due_date, 103) as [Due Date],tbl_roll_purchase.rpu_total_quantity as [Total Qty],tbl_roll_purchase.rpu_sub_total as [Sub-Total],tbl_roll_purchase.rpu_total_gst as [Total GST],tbl_roll_purchase.rpu_shipping_charges as [Shipping Charges],tbl_roll_purchase.rpu_discount as [Discount],tbl_roll_purchase.rpu_adjustment as [Adjustment],tbl_roll_purchase.rpu_total as [Total Amount] From tbl_roll_purchase inner join tbl_vendor on tbl_roll_purchase.v_id=tbl_vendor.v_id Order By rpu_id desc", conn);
            var dt = new DataTable();
            da.Fill(dt);

            GridView1.DataSource = dt;
            GridView1.DataBind();
            Response.Clear();
            Response.Charset = "";
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.ContentType = "application/vnd.xls";
            Response.AddHeader("content-disposition", "attachment;filename=List of Roll Purchase Invoice-" + date + ".xls");

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
        var da = new SqlDataAdapter("Select tbl_roll_purchase.rpu_invoice_no as [Invoice],tbl_vendor.v_name as [Vendor Name],CONVERT(VARCHAR(10), tbl_roll_purchase.rpu_invoice_date, 103) as [Invoice Date],CONVERT(VARCHAR(10), tbl_roll_purchase.rpu_due_date, 103) as [Due Date],tbl_roll_purchase.rpu_total_quantity as [Total Qty],tbl_roll_purchase.rpu_sub_total as [Sub-Total],tbl_roll_purchase.rpu_total_gst as [Total GST],tbl_roll_purchase.rpu_total as [Total Amount] From tbl_roll_purchase inner join tbl_vendor on tbl_roll_purchase.v_id=tbl_vendor.v_id Order By rpu_id desc", conn);
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
                Response.AddHeader("content-disposition", "attachment;filename=List of Roll Purchase Invoice-" + date + ".pdf");
                Response.Cache.SetCacheability(HttpCacheability.NoCache);
                Response.Write(pdfDoc);
                Response.End();
            }
        }

    }

    protected void Repeater1_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        SqlCommand cmd16 = new SqlCommand("select * from tbl_feature", conn);
        SqlDataAdapter adapt16 = new SqlDataAdapter(cmd16);
        DataTable dt16 = new DataTable();
        adapt16.Fill(dt16);
        if (dt16.Rows.Count > 0)
        {

            del_inv = Convert.ToInt32(dt16.Rows[0]["fe_del"]);
        }

        if (e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
        {
            Label tr = e.Item.FindControl("lbl_status") as Label;

            if (del_inv == 0)
            {
                e.Item.FindControl("LinkButton1").Visible = false;
            }
            else
            {
                e.Item.FindControl("LinkButton1").Visible = true;
            }

            DataRowView drv = e.Item.DataItem as DataRowView;
            decimal balance = Convert.ToDecimal(drv["rpu_balance"]);
            decimal total = Convert.ToDecimal(drv["rpu_total"]);

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