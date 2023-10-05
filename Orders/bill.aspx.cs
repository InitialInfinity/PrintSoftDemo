using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using System.Drawing;
using iTextSharp.text;
using System.IO;
using iTextSharp.text.html.simpleparser;
using iTextSharp.text.pdf;
using System.Net;
using System.Text;
using System.Net.Mail;
using iTextSharp.tool.xml;

public partial class Orders_bill : System.Web.UI.Page
{
    SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["String"].ConnectionString);
    SqlCommand cmd2, cmd3, cmd4, cmd5;
    SqlDataAdapter adapt2, adapt3, adapt4, adapt5;
    DataTable dt1, dt2, dt3, dt4, dt5;
    string invoice,invno;
    string otp = string.Empty;
    string filename1, key, country, senderid, route, email, password, port, subject, smtp;
    string bill_update;
    decimal opbal, newbal;
    protected void Page_Load(object sender, EventArgs e)
    {

        if (Session["a_email"] != null)
        {
            try
            {
                bill_update = Request.QueryString["bill_update"].ToString();
                if (bill_update == "success")
                {
                    Panel3.Visible = true;
                }

            }
            catch (Exception ex)
            { Panel3.Visible = false; }

            invoice = Request.QueryString["invoice"].ToString();
          
            if (Page.IsPostBack) return;
            fill();
        

        }
        else
        {
            Response.Redirect("../login.aspx");
        }
    }
    public void invoiceid()
    {
        try
        {

            conn.Open();
            //SqlCommand cmd = new SqlCommand("SELECT MAX(sl_id) FROM tbl_sale", conn);
            SqlCommand cmd = new SqlCommand("SELECT TOP 1 sl_invoice_no FROM tbl_sale ORDER BY sl_id DESC", conn);
            string inv;
            int i = 0;
            SqlDataAdapter adapt = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            adapt.Fill(dt);
            

            if (dt.Rows.Count > 0)
            {
                inv = dt.Rows[0]["sl_invoice_no"].ToString();

            }
            else
            {
                inv = "0";
            }


            string letters = string.Empty;
            string numbers = string.Empty;

            foreach (char c in inv)
            {
                if (Char.IsNumber(c))
                {
                    numbers += c;
                }
            }
            i = Convert.ToInt32(numbers);
            if (i > 0)
            {
                int j = i + 1;
                invno = "INV-" + j.ToString();

            }

            else
            {
                invno = "INV-1";
            }


        }

        catch (Exception ex)
        {
            Response.Write(ex.Message.ToString());
        }
        finally
        {
            conn.Close();
        }


    }

    public void fill()
    {
        cmd2 = new SqlCommand("select * from tbl_order_invoice where s_invoice_no ='" + invoice + "'", conn);
        adapt2 = new SqlDataAdapter(cmd2);
        dt1 = new DataTable();
        adapt2.Fill(dt1);
        if (dt1.Rows.Count > 0)
        {
            Repeater2.DataSource = dt1;
            Repeater2.DataBind();

            lbl_invoice_no.Text = dt1.Rows[0]["s_invoice_no"].ToString();

            lbl_customer_name.Text = dt1.Rows[0]["s_customer_name"].ToString();
            lbl_customer_contact.Text = dt1.Rows[0]["s_customer_contact"].ToString();
            lbl_customer_address.Text = dt1.Rows[0]["s_customer_address"].ToString();
        //    lbl_gst_no.Text = dt1.Rows[0]["s_customer_gst_no"].ToString();
            lbl_email.Text = dt1.Rows[0]["s_customer_email"].ToString();
            lbl_order_no.Text = dt1.Rows[0]["s_designer"].ToString();
            lbl_invoice_date.Text = Convert.ToDateTime(dt1.Rows[0]["s_invoice_date"]).ToString("dd/MM/yyyy");
            lbl_due_date.Text = Convert.ToDateTime(dt1.Rows[0]["s_due_date"]).ToString("dd/MM/yyyy");

            lbl_discount.Text = dt1.Rows[0]["s_discount"].ToString();
            lbl_shipping.Text = dt1.Rows[0]["s_shipping_charges"].ToString();
            lbl_subtotal.Text = dt1.Rows[0]["s_sub_total"].ToString();
        //    lbl_total_gst.Text = dt1.Rows[0]["s_total_gst"].ToString();
            //lbl_shipping.Text = dt1.Rows[0]["s_shipping_charges"].ToString();
            lbl_adjustment.Text = dt1.Rows[0]["s_adjustment"].ToString();
            lbl_total.Text = dt1.Rows[0]["s_total"].ToString();
            lbl_word.Text = ConvertNumbertoWords(Convert.ToInt64(dt1.Rows[0]["s_total"]));
            lbl_balance.Text = dt1.Rows[0]["s_balance"].ToString();


            lbl_design.Text = dt1.Rows[0]["est_dtp_charges"].ToString();
            lbl_fitting_framing.Text = dt1.Rows[0]["est_fitting_framing"].ToString();
            lbl_payment_method.Text = dt1.Rows[0]["est_payment_method"].ToString();


        }


        SqlCommand cmd5 = new SqlCommand("select * from tbl_company_details where com_id = 1", conn);
        SqlDataAdapter adapt5 = new SqlDataAdapter(cmd5);
        DataTable dt5 = new DataTable();
        adapt5.Fill(dt5);
        if (dt5.Rows.Count > 0)
        {
            lbl_company_name.Text = dt5.Rows[0]["com_company_name"].ToString();
            lbl_company_address.Text = dt5.Rows[0]["com_address"].ToString();
            lbl_company_contact.Text = dt5.Rows[0]["com_contact"].ToString();
            lbl_company_email.Text = dt5.Rows[0]["com_email"].ToString();
            lbl_company_gst.Text = dt5.Rows[0]["com_gst_no"].ToString();
            Image1.ImageUrl = "~/Company/Company_Photos/" + dt5.Rows[0]["com_company_logo"].ToString();
            lbl_bank_name.Text = dt5.Rows[0]["com_bank_name"].ToString();
            lbl_branch.Text = dt5.Rows[0]["com_branch"].ToString();
            lbl_ac.Text = dt5.Rows[0]["com_acc_no"].ToString();
            lbl_ifsc.Text = dt5.Rows[0]["com_ifsc"].ToString();
        }
    }

    public override void VerifyRenderingInServerForm(Control control)
    {
        /* Verifies that the control is rendered */
    }
    protected void btn_pdfs_Click(object sender, EventArgs e)
    {
        //Response.ContentType = "application/pdf";
        //Response.AddHeader("content-disposition", "attachment;filename=Panel.pdf");
        //Response.Cache.SetCacheability(HttpCacheability.NoCache);
        //StringWriter sw = new StringWriter();
        //HtmlTextWriter hw = new HtmlTextWriter(sw);
        //Panel1.RenderControl(hw);
        //StringReader sr = new StringReader(sw.ToString());
        //Document pdfDoc = new Document(PageSize.A4, 10f, 10f, 100f, 0f);
        //HTMLWorker htmlparser = new HTMLWorker(pdfDoc);
        //PdfWriter.GetInstance(pdfDoc, Response.OutputStream);
        //pdfDoc.Open();
        //htmlparser.Parse(sr);
        //pdfDoc.Close();
        //Response.Write(pdfDoc);
        //Response.End();





        //using (StringWriter sw = new StringWriter())
        //{
        //    using (HtmlTextWriter hw = new HtmlTextWriter(sw))
        //    {
        //        dropHere.RenderControl(hw);
        //        StringReader sr = new StringReader(sw.ToString());
        //        Document pdfDoc = new Document(PageSize.A4, 10f, 10f, 10f, 0f);
        //        PdfWriter writer = PdfWriter.GetInstance(pdfDoc, Response.OutputStream);
        //        pdfDoc.Open();

        //        XMLWorkerHelper.GetInstance().ParseXHtml(writer, pdfDoc, sr);
        //        pdfDoc.Close();
        //        Response.ContentType = "application/pdf";
        //        Response.AddHeader("content-disposition", "attachment;filename=List of Customer.pdf");
        //        Response.Cache.SetCacheability(HttpCacheability.NoCache);
        //        Response.Write(pdfDoc);
        //        Response.End();
        //    }
        //}



    }
   

    public string ConvertNumbertoWords(long number)
    {
        if (number == 0) return "ZERO";
        if (number < 0) return "minus " + ConvertNumbertoWords(Math.Abs(number));
        string words = "";
        if ((number / 1000000) > 0)
        {
            words += ConvertNumbertoWords(number / 100000) + " LAKH ";
            number %= 1000000;
        }
        if ((number / 1000) > 0)
        {
            words += ConvertNumbertoWords(number / 1000) + " THOUSAND ";
            number %= 1000;
        }
        if ((number / 100) > 0)
        {
            words += ConvertNumbertoWords(number / 100) + " HUNDRED ";
            number %= 100;
        }
        //if ((number / 10) > 0)  
        //{  
        // words += ConvertNumbertoWords(number / 10) + " RUPEES ";  
        // number %= 10;  
        //}  
        if (number > 0)
        {
            if (words != "") words += "AND ";
            var unitsMap = new[]
            {
            "ZERO", "ONE", "TWO", "THREE", "FOUR", "FIVE", "SIX", "SEVEN", "EIGHT", "NINE", "TEN", "ELEVEN", "TWELVE", "THIRTEEN", "FOURTEEN", "FIFTEEN", "SIXTEEN", "SEVENTEEN", "EIGHTEEN", "NINETEEN"
        };
            var tensMap = new[]
            {
            "ZERO", "TEN", "TWENTY", "THIRTY", "FORTY", "FIFTY", "SIXTY", "SEVENTY", "EIGHTY", "NINETY"
        };
            if (number < 20) words += unitsMap[number];
            else
            {
                words += tensMap[number / 10];
                if ((number % 10) > 0) words += " " + unitsMap[number % 10];
            }
        }

        return words;
    }

    protected void btn_convert_Click(object sender, EventArgs e)
    {
        try
        {
            invoiceid();
            fill();
            SqlCommand cmd9 = new SqlCommand("select * from tbl_customer where c_name ='" + lbl_customer_name.Text + "'", conn);
            SqlDataAdapter adapt9 = new SqlDataAdapter(cmd9);
            DataTable dt9 = new DataTable();
            adapt9.Fill(dt9);
            if (dt9.Rows.Count > 0)
            {
                opbal = Convert.ToDecimal(dt9.Rows[0]["c_opening_balance"]);
            }

            SqlCommand cmd6 = new SqlCommand("DELETE FROM tbl_order_invoice Where s_invoice_no='" + invoice + "'", conn);
            SqlCommand cmd7 = new SqlCommand("DELETE FROM tbl_order Where sl_invoice_no='" + invoice + "'", conn);
            conn.Open();
            cmd6.ExecuteNonQuery();
            cmd7.ExecuteNonQuery();
            conn.Close();

            int rowscount = dt1.Rows.Count;
            for (int i = 0; i < rowscount; i++)
            {


                SqlCommand cmd = new SqlCommand("insert into tbl_sale_invoice values(@s_invoice_no,@s_date,@s_customer_name,@s_customer_contact,@s_customer_address,@s_customer_gst_no,@s_customer_email,@s_order_no,@s_invoice_date,@s_due_date,@s_product_name,@s_quantity,@s_total_quantity,@s_rate,@s_discount,@s_cgstp,@s_cgsta,@s_sgstp,@s_sgsta,@s_igstp,@s_igsta,@s_amount,@s_sub_total,@s_total_gst,@s_shipping_charges,@s_adjustment,@s_total,@s_stotal,@s_product_hsn,@s_unit,@s_desc,@s_height,@s_width,@s_size,@s_samount,@s_total_cgst,@s_total_sgst,@s_total_igst,@s_total_taxable,@s_balance)", conn);
                cmd.Parameters.AddWithValue("@s_invoice_no", Convert.ToString(invno));
                cmd.Parameters.AddWithValue("@s_date", Convert.ToDateTime(dt1.Rows[i]["s_date"].ToString()).ToString("MM/dd/yyyy"));
                cmd.Parameters.AddWithValue("@s_customer_name", Convert.ToString(dt1.Rows[i]["s_customer_name"]));
                cmd.Parameters.AddWithValue("@s_customer_contact", Convert.ToString(dt1.Rows[i]["s_customer_contact"]));
                cmd.Parameters.AddWithValue("@s_customer_address", Convert.ToString(dt1.Rows[i]["s_customer_address"]));
                cmd.Parameters.AddWithValue("@s_customer_gst_no", Convert.ToString(dt1.Rows[i]["s_customer_gst_no"]));
                cmd.Parameters.AddWithValue("@s_customer_email", Convert.ToString(dt1.Rows[i]["s_customer_email"]));
                cmd.Parameters.AddWithValue("@s_order_no", Convert.ToString(dt1.Rows[i]["s_invoice_no"]));
                cmd.Parameters.AddWithValue("@s_invoice_date", Convert.ToDateTime(dt1.Rows[i]["s_invoice_date"]).ToString("MM/dd/yyyy"));
                cmd.Parameters.AddWithValue("@s_due_date", Convert.ToDateTime(dt1.Rows[i]["s_due_date"]).ToString("MM/dd/yyyy"));
                cmd.Parameters.AddWithValue("@s_product_name", Convert.ToString(dt1.Rows[i]["s_product_name"]));
                cmd.Parameters.AddWithValue("@s_quantity", Convert.ToDecimal(dt1.Rows[i]["s_quantity"]));
                cmd.Parameters.AddWithValue("@s_unit", Convert.ToString(dt1.Rows[i]["s_unit"]));
                cmd.Parameters.AddWithValue("@s_total_quantity", Convert.ToDecimal(dt1.Rows[i]["s_total_quantity"]));
                cmd.Parameters.AddWithValue("@s_rate", Convert.ToDecimal(dt1.Rows[i]["s_rate"]));
                cmd.Parameters.AddWithValue("@s_discount", Convert.ToDecimal(dt1.Rows[i]["s_discount"]));
                cmd.Parameters.AddWithValue("@s_cgstp", Convert.ToDecimal(dt1.Rows[i]["s_cgstp"]));
                cmd.Parameters.AddWithValue("@s_cgsta", Convert.ToDecimal(dt1.Rows[i]["s_cgsta"]));
                cmd.Parameters.AddWithValue("@s_sgstp", Convert.ToDecimal(dt1.Rows[i]["s_sgstp"]));
                cmd.Parameters.AddWithValue("@s_sgsta", Convert.ToDecimal(dt1.Rows[i]["s_sgsta"]));
                cmd.Parameters.AddWithValue("@s_igstp", Convert.ToDecimal(dt1.Rows[i]["s_igstp"]));
                cmd.Parameters.AddWithValue("@s_igsta", Convert.ToDecimal(dt1.Rows[i]["s_igsta"]));
                cmd.Parameters.AddWithValue("@s_amount", Convert.ToDecimal(dt1.Rows[i]["s_amount"]));
                cmd.Parameters.AddWithValue("@s_sub_total", Convert.ToDecimal(dt1.Rows[i]["s_sub_total"]));
                cmd.Parameters.AddWithValue("@s_total_gst", Convert.ToDecimal(dt1.Rows[i]["s_total_gst"]));
                cmd.Parameters.AddWithValue("@s_shipping_charges", dt1.Rows[i]["s_shipping_charges"]);
                cmd.Parameters.AddWithValue("@s_adjustment", Convert.ToDecimal(dt1.Rows[i]["s_adjustment"]));
                cmd.Parameters.AddWithValue("@s_total", Convert.ToDecimal(dt1.Rows[i]["s_total"]));
                cmd.Parameters.AddWithValue("@s_stotal", Convert.ToDecimal(dt1.Rows[i]["s_stotal"]));
                cmd.Parameters.AddWithValue("@s_product_hsn", Convert.ToString(dt1.Rows[i]["s_product_hsn"]));
                cmd.Parameters.AddWithValue("@s_desc", Convert.ToString(dt1.Rows[i]["s_desc"]));
                cmd.Parameters.AddWithValue("@s_height", Convert.ToDecimal(dt1.Rows[i]["s_height"]));
                cmd.Parameters.AddWithValue("@s_width", Convert.ToDecimal(dt1.Rows[i]["s_width"]));
                cmd.Parameters.AddWithValue("@s_size", Convert.ToDecimal(dt1.Rows[i]["s_size"]));
                cmd.Parameters.AddWithValue("@s_samount", Convert.ToDecimal(dt1.Rows[i]["s_samount"]));
                cmd.Parameters.AddWithValue("@s_total_cgst", Convert.ToDecimal(dt1.Rows[i]["s_total_cgst"]));
                cmd.Parameters.AddWithValue("@s_total_sgst", Convert.ToDecimal(dt1.Rows[i]["s_total_sgst"]));
                cmd.Parameters.AddWithValue("@s_total_igst", Convert.ToDecimal(dt1.Rows[i]["s_total_igst"]));
                cmd.Parameters.AddWithValue("@s_total_taxable", Convert.ToDecimal(dt1.Rows[i]["s_total_taxable"]));
                cmd.Parameters.AddWithValue("@s_balance", Convert.ToDecimal(dt1.Rows[i]["s_balance"]));
                conn.Open();
                cmd.ExecuteNonQuery();

                conn.Close();
            }

            SqlCommand cmd2 = new SqlCommand("insert into tbl_sale values(@sl_invoice_no,@sl_date,@sl_customer_name,@sl_customer_contact,@sl_customer_address,@sl_customer_gst_no,@sl_customer_email,@sl_order_no,@sl_invoice_date,@sl_due_date,@sl_total_quantity,@sl_discount,@sl_sub_total,@sl_total_gst,@sl_shipping_charges,@sl_adjustment,@sl_total,@sl_total_cgst,@sl_total_sgst,@sl_total_igst,@sl_total_taxable,@sl_balance)", conn);
            cmd2.Parameters.AddWithValue("@sl_invoice_no", Convert.ToString(invno));
            cmd2.Parameters.AddWithValue("@sl_date", Convert.ToDateTime(dt1.Rows[0]["s_date"]).ToString("MM/dd/yyyy"));
            cmd2.Parameters.AddWithValue("@sl_customer_name", Convert.ToString(dt1.Rows[0]["s_customer_name"]));
            cmd2.Parameters.AddWithValue("@sl_customer_contact", Convert.ToString(dt1.Rows[0]["s_customer_contact"]));
            cmd2.Parameters.AddWithValue("@sl_customer_address", Convert.ToString(dt1.Rows[0]["s_customer_address"]));
            cmd2.Parameters.AddWithValue("@sl_customer_gst_no", Convert.ToString(dt1.Rows[0]["s_customer_gst_no"]));
            cmd2.Parameters.AddWithValue("@sl_customer_email", Convert.ToString(dt1.Rows[0]["s_customer_email"]));
            cmd2.Parameters.AddWithValue("@sl_order_no", Convert.ToString(dt1.Rows[0]["s_invoice_no"]));
            cmd2.Parameters.AddWithValue("@sl_invoice_date", Convert.ToDateTime(dt1.Rows[0]["s_invoice_date"]).ToString("MM/dd/yyyy"));
            cmd2.Parameters.AddWithValue("@sl_due_date", Convert.ToDateTime(dt1.Rows[0]["s_due_date"]).ToString("MM/dd/yyyy"));

            cmd2.Parameters.AddWithValue("@sl_total_quantity", Convert.ToDecimal(dt1.Rows[0]["s_total_quantity"]));

            cmd2.Parameters.AddWithValue("@sl_discount", Convert.ToDecimal(dt1.Rows[0]["s_discount"]));


            cmd2.Parameters.AddWithValue("@sl_sub_total", Convert.ToDecimal(dt1.Rows[0]["s_sub_total"]));
            cmd2.Parameters.AddWithValue("@sl_total_gst", Convert.ToDecimal(dt1.Rows[0]["s_total_gst"]));
            cmd2.Parameters.AddWithValue("@sl_shipping_charges", Convert.ToDecimal(dt1.Rows[0]["s_shipping_charges"]));
            cmd2.Parameters.AddWithValue("@sl_adjustment", Convert.ToDecimal(dt1.Rows[0]["s_adjustment"]));
            cmd2.Parameters.AddWithValue("@sl_total", Convert.ToDecimal(dt1.Rows[0]["s_total"]));
            cmd2.Parameters.AddWithValue("@sl_total_cgst", Convert.ToDecimal(dt1.Rows[0]["s_total_cgst"]));
            cmd2.Parameters.AddWithValue("@sl_total_sgst", Convert.ToDecimal(dt1.Rows[0]["s_total_sgst"]));
            cmd2.Parameters.AddWithValue("@sl_total_igst", Convert.ToDecimal(dt1.Rows[0]["s_total_igst"]));
            cmd2.Parameters.AddWithValue("@sl_total_taxable", Convert.ToDecimal(dt1.Rows[0]["s_total_taxable"]));
            cmd2.Parameters.AddWithValue("@sl_balance", Convert.ToDecimal(dt1.Rows[0]["s_balance"]));

            conn.Open();
            cmd2.ExecuteNonQuery();
            conn.Close();

            newbal = Convert.ToDecimal(dt1.Rows[0]["s_balance"]);

            SqlCommand cmd8 = new SqlCommand("update tbl_customer set c_opening_balance= @balance where c_name='" + lbl_customer_name.Text + "'", conn);
            decimal balance;
            balance =  opbal + newbal;
            cmd8.Parameters.Add("@balance", SqlDbType.Decimal).Value = balance;
            conn.Open();
            cmd8.ExecuteNonQuery();
            conn.Close();

            string redirectScript = " window.location.href = '../Sale/bill.aspx?invoice=" + invno + "';";
            System.Web.UI.ScriptManager.RegisterStartupScript(this, GetType(), "displayalertmessage", "alert('New Sale Invoice Added Successfully!!!');" + redirectScript, true);

        }
        catch (Exception ex)
        {

        }
    }
}