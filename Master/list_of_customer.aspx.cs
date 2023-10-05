using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Drawing;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using System.IO;
using System.Text;
using iTextSharp;
using iTextSharp.text;

using iTextSharp.text.pdf;
using iTextSharp.text.html.simpleparser;
using iTextSharp.text.html;
using iTextSharp.tool.xml;


public partial class Master_list_of_customer : System.Web.UI.Page
{
    SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["String"].ConnectionString);
    string admin_email,custid,insert_cust;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["a_email"] != null)
        {
            if (Page.IsPostBack) return;

            try
            {
				//insert_cust = Request.QueryString["insert_cust"].ToString();
				insert_cust = (Request.QueryString["insert_cust"] ?? "").ToString();
				if (insert_cust == "success")
                {
                    Panel1.Visible = true;
                }
              
            }
            catch (Exception ex)
            { Panel1.Visible = false; }
           

            FillRepeater();
         
            
        }
        else
        {
            Response.Redirect("../login.aspx");
        }
    }
   
   
    public void FillRepeater()
    {
        SqlCommand cmd = new SqlCommand("select * from tbl_customer order by c_id desc", conn);
        SqlDataAdapter adapt = new SqlDataAdapter(cmd);
        DataTable dt = new DataTable();
        adapt.Fill(dt);
        if (dt.Rows.Count > 0)
        {
            Repeater1.DataSource = dt;
            Repeater1.DataBind();
        }
    }

   
    protected void DeleteCustomer(object sender, EventArgs e)
    {
        SqlCommand cmd1 = new SqlCommand("select * from tbl_admin_login", conn);
        SqlDataAdapter adapt1 = new SqlDataAdapter(cmd1);
        DataTable dt1 = new DataTable();
        adapt1.Fill(dt1);
        if (dt1.Rows.Count > 0)
        {
            admin_email = dt1.Rows[0]["a_email"].ToString();
        }
        if (admin_email.ToString() == Session["a_email"].ToString() || Session["admin_email"] != null)
        {
            int customerId = int.Parse(((sender as LinkButton).NamingContainer.FindControl("lbl_sr") as Label).Text);
            
            using (SqlCommand cmd = new SqlCommand("DELETE FROM tbl_customer WHERE c_id = @c_id", conn))
            {
                cmd.Parameters.AddWithValue("@c_id", customerId);
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
            }
            using (SqlCommand cmd2 = new SqlCommand("DELETE FROM tbl_sale_invoice WHERE c_id = @c_id", conn))
            {

                cmd2.Parameters.AddWithValue("@c_id", customerId);
                conn.Open();
                cmd2.ExecuteNonQuery();
                conn.Close();
            }
            using (SqlCommand cmd3 = new SqlCommand("DELETE FROM tbl_sale WHERE c_id = @c_id", conn))
            {
                cmd3.Parameters.AddWithValue("@c_id", customerId);
                conn.Open();
                cmd3.ExecuteNonQuery();
                conn.Close();
            }
            using (SqlCommand cmd4 = new SqlCommand("DELETE FROM tbl_sale_invoice_payment WHERE c_id = @c_id", conn))
            {
                cmd4.Parameters.AddWithValue("@c_id", customerId);
                conn.Open();
                cmd4.ExecuteNonQuery();
                conn.Close();
            }
            using (SqlCommand cmd5 = new SqlCommand("DELETE FROM tbl_estimate_details WHERE c_id = @c_id", conn))
            {

                cmd5.Parameters.AddWithValue("@c_id", customerId);
                conn.Open();
                cmd5.ExecuteNonQuery();
                conn.Close();
            }
            using (SqlCommand cmd6 = new SqlCommand("DELETE FROM tbl_estimate WHERE c_id = @c_id", conn))
            {
                cmd6.Parameters.AddWithValue("@c_id", customerId);
                conn.Open();
                cmd6.ExecuteNonQuery();
                conn.Close();
            }
            using (SqlCommand cmd7 = new SqlCommand("DELETE FROM tbl_gst_quotation_details WHERE c_id = @c_id", conn))
            {

                cmd7.Parameters.AddWithValue("@c_id", customerId);
                conn.Open();
                cmd7.ExecuteNonQuery();
                conn.Close();
            }
            using (SqlCommand cmd8 = new SqlCommand("DELETE FROM tbl_gst_quotation WHERE c_id = @c_id", conn))
            {
                cmd8.Parameters.AddWithValue("@c_id", customerId);
                conn.Open();
                cmd8.ExecuteNonQuery();
                conn.Close();
            }
            using (SqlCommand cmd9 = new SqlCommand("DELETE FROM tbl_without_gst_quotation_details WHERE c_id = @c_id", conn))
            {

                cmd9.Parameters.AddWithValue("@c_id", customerId);
                conn.Open();
                cmd9.ExecuteNonQuery();
                conn.Close();
            }
            using (SqlCommand cmd10 = new SqlCommand("DELETE FROM tbl_without_gst_quotation WHERE c_id = @c_id", conn))
            {
                cmd10.Parameters.AddWithValue("@c_id", customerId);
                conn.Open();
                cmd10.ExecuteNonQuery();
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
        //try
        //{
        try
        {
            
           // Response.Close();
            string date = DateTime.Now.ToString("dd-MM-yyyy--HH-mm");
            var da = new SqlDataAdapter("Select c_id as [ID],c_name as [Customer Name],c_address as [Address],c_contact as [Contact],c_contact2 as [Alt Contact],c_gst_no as [GST no],c_email as [Email],c_opening_balance as [Opening Balance] From tbl_customer Order By c_id desc", conn);
            var dt = new DataTable();
            da.Fill(dt);

            GridView1.DataSource = dt;
            GridView1.DataBind();
            Response.Clear();
            Response.Charset = "";
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.ContentType = "application/vnd.xls";
            Response.AddHeader("content-disposition", "attachment;filename=List of Customer-"+date+".xls");

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
        catch(Exception ex)
        {

        }
    }
   
    protected void pdf_export(object sender, EventArgs e)
    {
        string date = DateTime.Now.ToString("dd-MM-yyyy--HH-mm");
        var da = new SqlDataAdapter("Select c_id as [ID],c_name as [Customer Name],c_contact as [Contact],c_contact2 as [Alt Contact],c_gst_no as [GST no],c_opening_balance as [Opening Balance] From tbl_customer Order By c_id desc", conn);
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
                Response.AddHeader("content-disposition", "attachment;filename=List of Customer-" + date + ".pdf");
                Response.Cache.SetCacheability(HttpCacheability.NoCache);
                Response.Write(pdfDoc);
                Response.End();
            }
        }


    }
}