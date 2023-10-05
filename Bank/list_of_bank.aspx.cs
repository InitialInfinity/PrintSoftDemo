using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

public partial class Bank_list_of_bank : System.Web.UI.Page
{
    SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["String"].ConnectionString);
    SqlCommand cmd2, cmd3, cmd4;
    SqlDataAdapter adapt2, adapt3, adapt4;
    DataTable dt1, dt2, dt4;
    string admin_email;
    readonly PagedDataSource _pgsource = new PagedDataSource();
    int _firstIndex, _lastIndex;
    private int _pageSize = 25;
    string insert, update;
    protected void Page_Load(object sender, EventArgs e)
    {

        if (Session["a_email"] != null || Session["admin_email"] != null)
        {

            cmd4 = new SqlCommand("select * from tbl_admin_login", conn);
            adapt4 = new SqlDataAdapter(cmd4);
            DataTable dt4 = new DataTable();
            adapt4.Fill(dt4);
            if (dt4.Rows.Count > 0)
            {
                admin_email = dt4.Rows[0]["a_email"].ToString();
            }
            if (admin_email.ToString() == Session["a_email"].ToString() || Session["admin_email"] != null)
            {
                FillRepeater();
                if (Page.IsPostBack) return;
            try
            {
                insert = Request.QueryString["insert"].ToString();
                if (insert == "success")
                {
                    Panel2.Visible = true;
                }

            }
            catch (Exception ex)
            { Panel2.Visible = false; }
            try
            {
                update = Request.QueryString["update"].ToString();
                if (update == "success")
                {
                    Panel3.Visible = true;
                }

            }
            catch (Exception ex)
            { Panel3.Visible = false; }
                //this.FillRepeater();

            }
            else
            {
                Response.Redirect("../access_denied.aspx");

            }

        }
        else
        {
            Response.Redirect("../login.aspx");
        }

    }
    
    static DataTable GetDataFromDb()
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["String"].ConnectionString);
        con.Open();
        var da = new SqlDataAdapter("Select * From tbl_bank Order By b_id asc", con);
        var dt = new DataTable();
        da.Fill(dt);
        con.Close();
        return dt;
    }

    // Bind PagedDataSource into Repeater
    
    
    public void FillRepeater()
    {
        cmd2 = new SqlCommand("select * from tbl_bank", conn);
        adapt2 = new SqlDataAdapter(cmd2);
        dt1 = new DataTable();
        adapt2.Fill(dt1);
        if (dt1.Rows.Count > 0)
        {
            Repeater1.DataSource = dt1;
            Repeater1.DataBind();
        }
    }

   
   

   


 

    protected void DeleteBank(object sender, EventArgs e)
    {
        int bankId = int.Parse(((sender as LinkButton).NamingContainer.FindControl("lbl_id") as Label).Text);

        using (SqlCommand cmd4 = new SqlCommand("DELETE FROM tbl_bank WHERE b_id = @b_id", conn))
        {
            cmd4.Parameters.AddWithValue("@b_id", bankId);
            conn.Open();
            cmd4.ExecuteNonQuery();
            conn.Close();
        }
        
    }

    protected void Repeater1_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if (e.CommandName.Equals("showid"))
        {
            //get data
            string CarrierName = e.CommandArgument.ToString();
            cmd2 = new SqlCommand("select * from tbl_bank where b_id='" + CarrierName + "'", conn);
            adapt2 = new SqlDataAdapter(cmd2);
            dt1 = new DataTable();
            adapt2.Fill(dt1);
            if (dt1.Rows.Count > 0)
            {
                lbl_name.Text = dt1.Rows[0]["b_name"].ToString();
                lbl_ac_name.Text = dt1.Rows[0]["b_ac_name"].ToString();
                lbl_ifsc.Text = dt1.Rows[0]["b_ifsc"].ToString();
                lbl_ac_no.Text = dt1.Rows[0]["b_ac_no"].ToString();
                lbl_balance.Text = dt1.Rows[0]["b_opening_balance"].ToString();
                lbl_desc.Text = dt1.Rows[0]["b_desc"].ToString();

            }
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Modal", "ShowModel();", true);
        }
        if (e.CommandName.Equals("editid"))
        {
            //get data
            string CarrierName = e.CommandArgument.ToString();
            cmd2 = new SqlCommand("select * from tbl_bank where b_id='" + CarrierName + "'", conn);
            adapt2 = new SqlDataAdapter(cmd2);
            dt1 = new DataTable();
            adapt2.Fill(dt1);
            if (dt1.Rows.Count > 0)
            {
                Txt_id.Value = dt1.Rows[0]["b_id"].ToString();
                Txt_name.Text = dt1.Rows[0]["b_name"].ToString();
                Txt_ac_name.Text = dt1.Rows[0]["b_ac_name"].ToString();
                Txt_ifsc.Text = dt1.Rows[0]["b_ifsc"].ToString();
                Txt_ac_no.Text = dt1.Rows[0]["b_ac_no"].ToString();
                Txt_opening_balance.Text = dt1.Rows[0]["b_opening_balance"].ToString();
                Txt_desc.Text = dt1.Rows[0]["b_desc"].ToString();

            }
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Modal", "ShowModel2();", true);
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
            var da = new SqlDataAdapter("Select b_id as [Sr. No.],b_name as [Bank Name],b_ac_name as [A/C Name],b_ifsc as [IFSC],b_ac_no as [A/C No.],b_opening_balance as [Opening Balance],b_desc as [Description] From tbl_Bank Order By b_id desc", conn);
            var dt = new DataTable();
            da.Fill(dt);

            GridView1.DataSource = dt;
            GridView1.DataBind();
            Response.Clear();
            Response.Charset = "";
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.ContentType = "application/vnd.xls";
            Response.AddHeader("content-disposition", "attachment;filename=List of Bank-" + date + ".xls");

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
        //tbltextbox.Visible = false;

        //Panel1.visible = false;
        //Response.ContentType = "application/pdf";
        //Response.AddHeader("content-disposition", "attachment;filename=Panel.pdf");
        //Response.Cache.SetCacheability(HttpCacheability.NoCache);
        //StringWriter sw = new StringWriter();
        //HtmlTextWriter hw = new HtmlTextWriter(sw);
        //pnlinvoice.RenderControl(hw);
        //StringReader sr = new StringReader(sw.ToString());
        //Document pdfDoc = new Document(PageSize.A4, 10f, 10f, 100f, 0f);
        //HTMLWorker htmlparser = new HTMLWorker(pdfDoc);
        //PdfWriter.GetInstance(pdfDoc, Response.OutputStream);
        //pdfDoc.Open();
        //htmlparser.Parse(sr);
        //pdfDoc.Close();
        //Response.Write(pdfDoc);
        //Response.End();
    }

    protected void Btn_submit_Click(object sender, EventArgs e)
    {
        try
        {
            SqlCommand cmd7 = new SqlCommand("UPDATE tbl_bank SET b_name='" + Txt_name.Text.Trim() + "',b_ac_name='" + Txt_ac_name.Text.Trim() + "',b_ifsc='" + Txt_ifsc.Text.Trim() + "',b_ac_no='" + Txt_ac_no.Text.Trim() + "',b_opening_balance='" + Txt_opening_balance.Text.Trim() + "',b_desc='" + Txt_desc.Text.Trim() + "' WHERE b_id='" + Txt_id.Value.Trim() + "'", conn);

            conn.Open();
            cmd7.ExecuteNonQuery();
            conn.Close();
            //Lbl_message.Text = "" + Txt_customer_name.Text + " Added Successfully!!!";
            // Page.Response.Redirect(Page.Request.RawUrl.ToString(), true);
            Response.Redirect("list_of_bank.aspx?update=success");
            //string redirectScript = " window.location.href = 'list_of_bank.aspx';";
            //System.Web.UI.ScriptManager.RegisterStartupScript(this, GetType(), "displayalertmessage", "alert('Bank Updated Successfully!!!');" + redirectScript, true);
        }
        catch (Exception ex)
        {

        }


    }
}