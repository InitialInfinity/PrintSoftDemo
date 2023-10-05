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
using iTextSharp;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.tool.xml;
using iTextSharp.text.html.simpleparser;
using iTextSharp.text.html;

public partial class Master_list_of_product : System.Web.UI.Page
{
    SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["String"].ConnectionString);
    string insert_pro,pro_update,admin_email;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["a_email"] != null)
        {

            try
            {
				//insert_pro = Request.QueryString["insert_pro"].ToString();
				insert_pro = (Request.QueryString["insert_pro"] ?? "").ToString();
				if (insert_pro == "success")
                {
                    Panel2.Visible = true;
                }

            }
            catch (Exception ex)
            { Panel2.Visible = false; }
            try
            {
                pro_update = (Request.QueryString["pro_update"]??"").ToString();
                if (pro_update == "success")
                {
                    Panel3.Visible = true;
                }

            }
            catch (Exception ex)
            { Panel3.Visible = false; }

            if (Page.IsPostBack) return;
            this.FillRepeater();
            this.FillRepeater2();
        }
        else
        {
            Response.Redirect("../login.aspx");
        }
    }
   
    public void FillRepeater()
    {
        SqlCommand cmd = new SqlCommand("Select * From tbl_product Order By p_id desc", conn);
        SqlDataAdapter adapt = new SqlDataAdapter(cmd);
        DataTable dt = new DataTable();
        adapt.Fill(dt);
        if (dt.Rows.Count > 0)
        {
            Repeater1.DataSource = dt;
            Repeater1.DataBind();
        }
    }
    public void FillRepeater2()
    {
        SqlCommand cmd = new SqlCommand("Select * From tbl_purchase_product Order By p_id desc", conn);
        SqlDataAdapter adapt = new SqlDataAdapter(cmd);
        DataTable dt = new DataTable();
        adapt.Fill(dt);
        if (dt.Rows.Count > 0)
        {
            Repeater2.DataSource = dt;
            Repeater2.DataBind();
        }
    }

    protected void DeleteProduct(object sender, EventArgs e)
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
            int productId = int.Parse(((sender as LinkButton).NamingContainer.FindControl("lbl_id") as Label).Text);

        using (SqlCommand cmd2 = new SqlCommand("DELETE FROM tbl_product WHERE p_id = @p_id", conn))
        {
            cmd2.Parameters.AddWithValue("@p_id", productId);
            conn.Open();
            cmd2.ExecuteNonQuery();
            conn.Close();
        }
        
        this.FillRepeater();
        }
        else
        {
            Response.Redirect("../access_denied.aspx");

        }
    }
    protected void DeleteProduct2(object sender, EventArgs e)
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
            int productId = int.Parse(((sender as LinkButton).NamingContainer.FindControl("lbl_id2") as Label).Text);

        using (SqlCommand cmd = new SqlCommand("DELETE FROM tbl_purchase_product WHERE p_id = @p_id", conn))
        {
            cmd.Parameters.AddWithValue("@p_id", productId);
            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
        }
        
        this.FillRepeater2();
        }
        else
        {
            Response.Redirect("../access_denied.aspx");

        }
    }

    protected void Repeater1_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if (e.CommandName.Equals("showid"))
        {
            //get data
            string CarrierName = e.CommandArgument.ToString();
            SqlCommand cmd = new SqlCommand("select * from tbl_product where p_id='" + CarrierName + "'", conn);
            SqlDataAdapter adapt = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapt.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                lbl_name.Text = dt.Rows[0]["p_name"].ToString();
                lbl_unit.Text = dt.Rows[0]["p_unit"].ToString();
                lbl_cgst.Text = dt.Rows[0]["p_cgst"].ToString();
                lbl_sgst.Text = dt.Rows[0]["p_sgst"].ToString();
                lbl_igst.Text = dt.Rows[0]["p_igst"].ToString();
                lbl_hsn_code.Text = dt.Rows[0]["p_hsn_code"].ToString();
                lbl_rate.Text = dt.Rows[0]["p_rate"].ToString();
                lbl_desc.Text = dt.Rows[0]["p_desc"].ToString();

            }
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Modal", "ShowModel();", true);
        }
        if (e.CommandName.Equals("editid"))
        { SqlCommand cmd1 = new SqlCommand("select * from tbl_admin_login", conn);
            SqlDataAdapter adapt1 = new SqlDataAdapter(cmd1);
            DataTable dt1 = new DataTable();
            adapt1.Fill(dt1);
            if (dt1.Rows.Count > 0)
            {
                admin_email = dt1.Rows[0]["a_email"].ToString();
            }
            if (admin_email.ToString() == Session["a_email"].ToString() || Session["admin_email"] != null)
            {
                //get data
                string CarrierName = e.CommandArgument.ToString();
                SqlCommand cmd = new SqlCommand("select * from tbl_product where p_id='" + CarrierName + "'", conn);
                SqlDataAdapter adapt = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
            adapt.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                Txt_id.Value = dt.Rows[0]["p_id"].ToString();
                Txt_name.Text = dt.Rows[0]["p_name"].ToString();
                Dd_unit.SelectedItem.Text= dt.Rows[0]["p_unit"].ToString();
                Dd_cgst.SelectedValue = dt.Rows[0]["p_cgst"].ToString();
                Dd_sgst.SelectedValue = dt.Rows[0]["p_sgst"].ToString();
                Dd_igst.SelectedValue = dt.Rows[0]["p_igst"].ToString();
                Txt_hsn.Text = dt.Rows[0]["p_hsn_code"].ToString();
                Txt_rate.Text = dt.Rows[0]["p_rate"].ToString();
                Txt_description.Text = dt.Rows[0]["p_desc"].ToString();

            }

            ScriptManager.RegisterStartupScript(this, this.GetType(), "Modal", "ShowModel2();", true);
            }
            else
            {
                Response.Redirect("../access_denied.aspx");

            }
        }

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        string hsn,desc;
        if (Txt_hsn.Text == string.Empty)
        {
            hsn = "-";
        }
        else
        {
            hsn = Txt_hsn.Text;
        }
        if (Txt_description.Text == string.Empty)
        {
            desc = "-";
        }
        else
        {
            desc = Txt_description.Text;
        }

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
            SqlCommand cmd = new SqlCommand("UPDATE tbl_product SET p_name='" + Txt_name.Text.Trim() + "',p_unit='" + Dd_unit.SelectedItem.Text.Trim() + "',p_cgst='" + Dd_cgst.SelectedValue.Trim() + "',p_sgst='" + Dd_sgst.SelectedValue.Trim() + "',p_igst='" + Dd_igst.SelectedValue.Trim() + "',p_hsn_code='" + hsn + "',p_rate='" + Txt_rate.Text.Trim() + "',p_desc='" + desc + "' WHERE p_id='" + Txt_id.Value.Trim() + "'", conn);

        conn.Open();
        cmd.ExecuteNonQuery();
        conn.Close();
        Response.Redirect("list_of_product.aspx?pro_update=success");
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
            string date = DateTime.Now.ToString("dd-MM-yyyy--HH-mm");
            var da = new SqlDataAdapter("Select p_id as[ID],p_name as[Product Name],p_desc as[Desc],p_hsn_code as[HSN/SAC],p_rate as[Rate],p_unit as[Unit],p_cgst as[CGST],p_sgst as[SGST],p_igst as[IGST] From tbl_product Order By p_id desc", conn);
            var dt = new DataTable();
            da.Fill(dt);
            GridView1.DataSource = dt;
            GridView1.DataBind();
            Response.Clear();
            Response.Charset = "";
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.ContentType = "application/vnd.xls";
            Response.AddHeader("content-disposition", "attachment;filename=List of Sale Product-" + date + ".xls");

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
        finally
        {

        }
    }
    protected void excel_export2(object sender, EventArgs e)
    {

        try
        {
            string date = DateTime.Now.ToString("dd-MM-yyyy--HH-mm");
            var da = new SqlDataAdapter("Select p_id as[ID],p_name as[Product Name],p_desc as[Desc],p_hsn_code as[HSN/SAC],p_rate as[Rate],p_unit as[Unit],p_cgst as[CGST],p_sgst as[SGST],p_igst as[IGST] From tbl_purchase_product Order By p_id desc", conn);
            var dt = new DataTable();
            da.Fill(dt);
            GridView1.DataSource = dt;
            GridView1.DataBind();
            Response.Clear();
            Response.Charset = "";
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.ContentType = "application/vnd.xls";
            Response.AddHeader("content-disposition", "attachment;filename=List of Purchase Product-" + date + ".xls");

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
        finally
        {

        }
    }
    protected void pdf_export(object sender, EventArgs e)
    {
        string date = DateTime.Now.ToString("dd-MM-yyyy--HH-mm");
        var da = new SqlDataAdapter("Select p_id as[ID],p_name as[Product Name],p_desc as[Desc],p_hsn_code as[HSN/SAC],p_rate as[Rate],p_unit as[Unit],p_cgst as[CGST],p_sgst as[SGST],p_igst as[IGST] From tbl_product Order By p_id desc", conn);
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
                Response.AddHeader("content-disposition", "attachment;filename=List of Sale Product-" + date + ".pdf");
                Response.Cache.SetCacheability(HttpCacheability.NoCache);
                Response.Write(pdfDoc);
                Response.End();
            }
        }

    }
    protected void pdf_export2(object sender, EventArgs e)
    {
        string date = DateTime.Now.ToString("dd-MM-yyyy--HH-mm");
        var da = new SqlDataAdapter("Select p_id as[ID],p_name as[Product Name],p_desc as[Desc],p_hsn_code as[HSN/SAC],p_rate as[Rate],p_unit as[Unit],p_cgst as[CGST],p_sgst as[SGST],p_igst as[IGST] From tbl_purchase_product Order By p_id desc", conn);
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
                Response.AddHeader("content-disposition", "attachment;filename=List of Purchase Product-" + date + ".pdf");
                Response.Cache.SetCacheability(HttpCacheability.NoCache);
                Response.Write(pdfDoc);
                Response.End();
            }
        }
    
    }

    
    protected void Repeater2_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if (e.CommandName.Equals("showid"))
        {
            //get data
            string CarrierName = e.CommandArgument.ToString();
            SqlCommand cmd = new SqlCommand("select * from tbl_purchase_product where p_id='" + CarrierName + "'", conn);
            SqlDataAdapter adapt = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapt.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                lbl_name2.Text = dt.Rows[0]["p_name"].ToString();
                lbl_unit2.Text = dt.Rows[0]["p_unit"].ToString();
                lbl_cgst2.Text = dt.Rows[0]["p_cgst"].ToString();
                lbl_sgst2.Text = dt.Rows[0]["p_sgst"].ToString();
                lbl_igst2.Text = dt.Rows[0]["p_igst"].ToString();
                lbl_hsn_code2.Text = dt.Rows[0]["p_hsn_code"].ToString();
                lbl_rate2.Text = dt.Rows[0]["p_rate"].ToString();
                lbl_stock2.Text = dt.Rows[0]["p_stock"].ToString();
                lbl_desc2.Text = dt.Rows[0]["p_desc"].ToString();

            }
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Modal", "ShowModel3();", true);
        }
        if (e.CommandName.Equals("editid"))
        { SqlCommand cmd1 = new SqlCommand("select * from tbl_admin_login", conn);
            SqlDataAdapter adapt1 = new SqlDataAdapter(cmd1);
            DataTable dt1 = new DataTable();
            adapt1.Fill(dt1);
            if (dt1.Rows.Count > 0)
            {
                admin_email = dt1.Rows[0]["a_email"].ToString();
            }
            if (admin_email.ToString() == Session["a_email"].ToString() || Session["admin_email"] != null)
            {
                //get data
                string CarrierName = e.CommandArgument.ToString();
                SqlCommand cmd = new SqlCommand("select * from tbl_purchase_product where p_id='" + CarrierName + "'", conn);
                SqlDataAdapter adapt = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
            adapt.Fill(dt);
            if (dt1.Rows.Count > 0)
            {
                Txt_id2.Value = dt.Rows[0]["p_id"].ToString();
                Txt_name2.Text = dt.Rows[0]["p_name"].ToString();
                Dd_unit2.SelectedItem.Text = dt.Rows[0]["p_unit"].ToString();
                Dd_cgst2.SelectedValue = dt.Rows[0]["p_cgst"].ToString();
                Dd_sgst2.SelectedValue = dt.Rows[0]["p_sgst"].ToString();
                Dd_igst2.SelectedValue = dt.Rows[0]["p_igst"].ToString();
                Txt_hsn2.Text = dt.Rows[0]["p_hsn_code"].ToString();
                Txt_rate2.Text = dt.Rows[0]["p_rate"].ToString();
                Txt_stock2.Text = dt.Rows[0]["p_stock"].ToString();
                Txt_description2.Text = dt.Rows[0]["p_desc"].ToString();

            }

            ScriptManager.RegisterStartupScript(this, this.GetType(), "Modal", "ShowModel4();", true);
            }
            else
            {
                Response.Redirect("../access_denied.aspx");

            }
        }
    }

    protected void Button6_Click(object sender, EventArgs e)
    {
        string hsn2;
        if (Txt_hsn2.Text == string.Empty)
        {
            hsn2 = "-";
        }
        else
        {
            hsn2 = Txt_hsn2.Text;
        }
        string desc2;
        if (Txt_description2.Text == string.Empty)
        {
            desc2 = "-";
        }
        else
        {
            desc2 = Txt_description2.Text;
        }

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
            SqlCommand cmd = new SqlCommand("UPDATE tbl_purchase_product SET p_name='" + Txt_name2.Text.Trim() + "',p_unit='" + Dd_unit2.SelectedItem.Text.Trim() + "',p_cgst='" + Dd_cgst2.SelectedValue.Trim() + "',p_sgst='" + Dd_sgst2.SelectedValue.Trim() + "',p_igst='" + Dd_igst2.SelectedValue.Trim() + "',p_hsn_code='" + hsn2 + "',p_rate='" + Txt_rate2.Text.Trim() + "',p_stock=@p_stock,p_desc='" + desc2 + "' WHERE p_id='" + Txt_id2.Value.Trim() + "'", conn);
            if (Txt_stock2.Text == "")
            {
                cmd.Parameters.AddWithValue("@p_stock", 0);
            }
            else
            {
                cmd.Parameters.AddWithValue("@p_stock", Convert.ToDecimal(Txt_stock2.Text));
            }
            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
            Response.Redirect("list_of_product.aspx?pro_update=success");
        }
        else
        {
            Response.Redirect("../access_denied.aspx");

        }

    }

   
}