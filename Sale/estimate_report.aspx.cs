﻿using System;
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

public partial class Sale_estimate_report : System.Web.UI.Page
{
    SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["String"].ConnectionString);
    decimal balance, bal, qty;
    int del_inv,c_id, materialId;
    string insert;
    string admin_email, product_name;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["a_email"] != null)
        {
            if (Page.IsPostBack) return;
            DateTime serverTime = DateTime.Now; // gives you current Time in server timeZone
            DateTime utcTime = serverTime.ToUniversalTime(); // convert it to Utc using timezone setting of server computer

            TimeZoneInfo tzi = TimeZoneInfo.FindSystemTimeZoneById("India Standard Time");
            DateTime localTime = TimeZoneInfo.ConvertTimeFromUtc(utcTime, tzi); // convert from utc to local

            txtdate.Text = localTime.ToString("yyyy-MM-dd");
            
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
        SqlCommand cmd = new SqlCommand("select * from tbl_estimate inner join tbl_customer on tbl_estimate.c_id=tbl_customer.c_id order by est_id desc", conn);
        SqlDataAdapter adapt = new SqlDataAdapter(cmd);
        DataTable dt = new DataTable();
        adapt.Fill(dt);
        if (dt.Rows.Count > 0)
        {
            Repeater1.DataSource = dt;
            Repeater1.DataBind();

            lbl_total_discount.Text = dt.Compute("Sum(est_discount)", string.Empty).ToString();
            lbl_total_invoice_amount.Text = dt.Compute("Sum(est_total)", string.Empty).ToString();
            lbl_total_invoice.Text = dt.Compute("count(est_id)", string.Empty).ToString();
            Lbl_balance.Text = dt.Compute("Sum(est_balance)", string.Empty).ToString();

            lbl_Advance.Text = dt.Compute("Sum(est_adjustment)", string.Empty).ToString();
            lblTBalance.Text = dt.Compute("Sum(est_balance)", string.Empty).ToString();
            lblTInvoiceAmount.Text = dt.Compute("Sum(est_total)", string.Empty).ToString();
        }
        else
        {
            lbl_total_invoice.Text = "0";
            lbl_total_invoice_amount.Text = "0";
            Lbl_balance.Text = "0";
            lbl_total_discount.Text = "0";
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
     
        //using (SqlCommand cmd2 = new SqlCommand("select * from tbl_estimate where est_invoice_no='" + invoiceno + "'", conn))
        //{

        //    SqlDataAdapter adapt2 = new SqlDataAdapter(cmd2);
        //    DataTable dt2 = new DataTable();
        //    adapt2.Fill(dt2);
        //    if (dt2.Rows.Count > 0)
        //    {
        //        bal =Convert.ToDecimal(dt2.Rows[0]["est_balance"]);
        //        c_id = Convert.ToInt32(dt2.Rows[0]["c_id"]);

        //    }
        //}




            using (SqlCommand cmd2 = new SqlCommand("select * from tbl_estimate_details where es_invoice_no='" + invoiceno + "'", conn))
            {
                SqlDataAdapter adapt2 = new SqlDataAdapter(cmd2);
                DataTable dt2 = new DataTable();
                adapt2.Fill(dt2);
                if (dt2.Rows.Count > 0)
                {

                    foreach (DataRow row in dt2.Rows)
                    {

                        bal = Convert.ToDecimal(row["es_balance"]);
                        c_id = Convert.ToInt32(row["c_id"]);
                        qty = Convert.ToDecimal(row["es_quantity"]);
                        product_name = Convert.ToString(row["es_product_name"]);
                        materialId = Convert.ToInt32(row["es_material"]);



                        SqlCommand cmd33 = new SqlCommand("UPDATE tbl_purchase_product SET p_stock = p_stock + @Quantity WHERE p_id = @materialId AND p_id = (SELECT TOP 1 p_id FROM tbl_purchase_product WHERE p_id = @materialId)", conn);
                        cmd33.Parameters.AddWithValue("@Quantity", qty);
                        cmd33.Parameters.AddWithValue("@ProductName", Convert.ToString(product_name));
                        cmd33.Parameters.AddWithValue("@materialId", Convert.ToString(materialId));


                        conn.Open();
                        cmd33.ExecuteNonQuery();
                        conn.Close();

                        decimal QuantityUsedStock = -qty;
                        //SqlCommand cmd34 = new SqlCommand("UPDATE tbl_used_stock SET quanity=quanity+('" + qty + "') WHERE p_name='" + Convert.ToString(product_name) + "'", conn);

                        //conn.Open();
                        //cmd34.ExecuteNonQuery();
                        //conn.Close();
                        SqlCommand cmd44 = new SqlCommand("insert into tbl_used_stock values(@p_name,@date,@sqrft,@quantity)", conn);
                        cmd44.Parameters.AddWithValue("@p_name", Convert.ToString(product_name));
                        cmd44.Parameters.AddWithValue("@date", Convert.ToDateTime(txtdate.Text).ToString("MM/dd/yyyy"));
                        cmd44.Parameters.AddWithValue("@sqrft", qty);
                        cmd44.Parameters.AddWithValue("@quantity", QuantityUsedStock);

                        conn.Open();
                        cmd44.ExecuteNonQuery();
                        conn.Close();

                    }


                }
            }




            using (SqlCommand cmd3 = new SqlCommand("update tbl_customer set c_opening_balance=c_opening_balance- '" + bal + "' where c_id='" + c_id + "'", conn))
            {
                conn.Open();
                cmd3.ExecuteNonQuery();
                conn.Close();
            }
            using (SqlCommand cmd4 = new SqlCommand("DELETE FROM tbl_estimate_details WHERE es_invoice_no = @s_invoice_no", conn))
        {

            cmd4.Parameters.AddWithValue("@s_invoice_no", invoiceno);
            conn.Open();
            cmd4.ExecuteNonQuery();
            conn.Close();
        }
        using (SqlCommand cmd5 = new SqlCommand("DELETE FROM tbl_estimate WHERE est_invoice_no = @sl_invoice_no", conn))
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
            var da = new SqlDataAdapter("Select tbl_estimate.est_invoice_no as [Invoice],CONVERT(VARCHAR(10),tbl_estimate.est_date, 103) as [Date],tbl_customer.c_name as [Customer Name],tbl_customer.c_contact as [Contact],tbl_estimate.est_order_no as [Order No],CONVERT(VARCHAR(10),tbl_estimate.est_invoice_date, 103) as [Invoice Date],CONVERT(VARCHAR(10),tbl_estimate.est_due_date, 103) as [Due Date],tbl_estimate.est_total_quantity as [Total Qty],tbl_estimate.est_sub_total as [Sub-Total],tbl_estimate.est_discount as [Discount],tbl_estimate.est_adjustment as [Advance],tbl_estimate.est_total as [Total Amount] From tbl_estimate inner join tbl_customer on tbl_estimate.c_id=tbl_customer.c_id Order By est_id desc", conn);
            var dt = new DataTable();
            da.Fill(dt);

            GridView1.DataSource = dt;
            GridView1.DataBind();
            Response.Clear();
            Response.Charset = "";
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.ContentType = "application/vnd.xls";
            Response.AddHeader("content-disposition", "attachment;filename=List of Estimate Invoice-" + date + ".xls");

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
        var da = new SqlDataAdapter("Select tbl_estimate.est_invoice_no as [Invoice],tbl_customer.c_name as [Customer Name],CONVERT(VARCHAR(10),tbl_estimate.est_invoice_date, 103) as [Invoice Date],CONVERT(VARCHAR(10),tbl_estimate.est_due_date, 103) as [Due Date],tbl_estimate.est_total_quantity as [Total Qty],tbl_estimate.est_sub_total as [Sub-Total],tbl_estimate.est_total as [Total Amount] From tbl_estimate inner join tbl_customer on tbl_estimate.c_id=tbl_customer.c_id Order By est_id desc", conn);
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
                Response.AddHeader("content-disposition", "attachment;filename=List of Estimate-" + date + ".pdf");
                Response.Cache.SetCacheability(HttpCacheability.NoCache);
                Response.Write(pdfDoc);
                Response.End();
            }
        }

    }

  
    protected void Repeater1_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        SqlCommand cmd = new SqlCommand("select * from tbl_feature", conn);
        SqlDataAdapter adapt = new SqlDataAdapter(cmd);
        DataTable dt = new DataTable();
        adapt.Fill(dt);
        if (dt.Rows.Count > 0)
        {

            del_inv = Convert.ToInt32(dt.Rows[0]["fe_del"]);
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
            decimal balance = Convert.ToDecimal(drv["est_balance"]);
            decimal total = Convert.ToDecimal(drv["est_total"]);

            if (balance == 0)
            {
                tr.Text = "Paid";
                tr.Attributes.Add("class", "label label-success");
				e.Item.FindControl("LinkButton2").Visible = false;
			}
            else if (balance == total)
            {
                tr.Text = "UnPaid";
                tr.Attributes.Add("class", "label label-danger");
				e.Item.FindControl("LinkButton2").Visible = true;
			}
            else
            {
                tr.Text = "Partially";
                tr.Attributes.Add("class", "label label-warning");
				e.Item.FindControl("LinkButton2").Visible = false;
			}

        }

    }

}