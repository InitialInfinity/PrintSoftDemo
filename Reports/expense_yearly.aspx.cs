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

public partial class Reports_expense_yearly : System.Web.UI.Page
{
    SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["String"].ConnectionString);
   
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["a_email"] != null)
        {
            if (Page.IsPostBack) return;
            this.Fill();
            this.user();
            this.category();
            
        }
        else
        {
            Response.Redirect("../login.aspx");
        }
    }
    public void Fill()
    {
        SqlCommand cmd = new SqlCommand("Select * From tbl_expense WHERE e_date >= DATEADD(YEAR, DATEDIFF(YEAR, 0, GETDATE()), 0) AND e_date <  DATEADD(YEAR, DATEDIFF(YEAR, 0, GETDATE()) + 1, 0) Order By e_id desc", conn);
        SqlDataAdapter adapt = new SqlDataAdapter(cmd);
        DataTable dt = new DataTable();
        adapt.Fill(dt);
        if (dt.Rows.Count > 0)
        {
            Repeater1.DataSource = dt;
            Repeater1.DataBind();
            lbl_total_expense.Text = dt.Compute("Sum(e_amount)", string.Empty).ToString();

            lbl_Total.Text = dt.Compute("Sum(e_amount)", string.Empty).ToString();
        }
        else
        {
            Panel1.Visible = false;
            lbl_total_expense.Text = "0";
        }
    }
    public void user()
    {
        string query = "select * from tbl_expense_user order by u_user_name asc";
        SqlDataAdapter adapt4 = new SqlDataAdapter(query, conn);
        DataTable dt4 = new DataTable();
        adapt4.Fill(dt4);
        if (dt4.Rows.Count > 0)
        {
            Dd_user.DataSource = dt4;
            Dd_user.DataBind();
            Dd_user.DataTextField = "u_user_name";
            Dd_user.DataValueField = "u_id";
            Dd_user.DataBind();
            Dd_user.Items.Insert(0, new System.Web.UI.WebControls.ListItem("--Select--", "--Select--"));
            Dd_user.SelectedItem.Selected = false;
            Dd_user.Items.FindByText("--Select--").Selected = true;
        }

    }
  
    public void category()
    {
        string query = "select * from tbl_expense_category order by cat_category_name asc";
        SqlDataAdapter adapt5 = new SqlDataAdapter(query, conn);
        DataTable dt5 = new DataTable();
        adapt5.Fill(dt5);
        if (dt5.Rows.Count > 0)
        {
            Dd_category.DataSource = dt5;
            Dd_category.DataBind();
            Dd_category.DataTextField = "cat_category_name";
            Dd_category.DataValueField = "cat_id";
            Dd_category.DataBind();
            Dd_category.Items.Insert(0, new System.Web.UI.WebControls.ListItem("--Select--", "--Select--"));
            Dd_category.SelectedItem.Selected = false;
            Dd_category.Items.FindByText("--Select--").Selected = true;
        }

    }
   
  
    protected void DeleteSale(object sender, EventArgs e)
    {
        String id = ((sender as LinkButton).NamingContainer.FindControl("lbl_sr") as Label).Text;


        using (SqlCommand cmd = new SqlCommand("DELETE FROM tbl_expense WHERE e_id = @e_id", conn))
        {

            cmd.Parameters.AddWithValue("@e_id", id);
            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
        }


        this.Fill();
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
            var da = new SqlDataAdapter("Select CONVERT(VARCHAR(10),e_date, 103) as [Date],e_user_name as [User],e_category_name as [Category],e_amount as [Amount],e_desc as [Description] From tbl_expense WHERE e_date >= DATEADD(YEAR, DATEDIFF(YEAR, 0, GETDATE()), 0) AND e_date <  DATEADD(YEAR, DATEDIFF(YEAR, 0, GETDATE()) + 1, 0)  Order By e_id desc", conn);
            var dt = new DataTable();
            da.Fill(dt);

            GridView1.DataSource = dt;
            GridView1.DataBind();
            Response.Clear();
            Response.Charset = "";
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.ContentType = "application/vnd.xls";
            Response.AddHeader("content-disposition", "attachment;filename=List of Yearly Expense-" + date + ".xls");

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
        var da = new SqlDataAdapter("Select CONVERT(VARCHAR(10),e_date, 103) as [Date],e_user_name as [User],e_category_name as [Category],e_amount as [Amount],e_desc as [Description] From tbl_expense WHERE e_date >= DATEADD(YEAR, DATEDIFF(YEAR, 0, GETDATE()), 0) AND e_date <  DATEADD(YEAR, DATEDIFF(YEAR, 0, GETDATE()) + 1, 0) Order By e_id desc", conn);
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
                Response.AddHeader("content-disposition", "attachment;filename=List of Yearly Expense-" + date + ".pdf");
                Response.Cache.SetCacheability(HttpCacheability.NoCache);
                Response.Write(pdfDoc);
                Response.End();
            }
        }

    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        SqlCommand cmd = new SqlCommand("UPDATE tbl_expense SET e_category_name='" + Dd_category.SelectedItem.Text.Trim() + "',e_user_name='" + Dd_user.SelectedItem.Text.Trim() + "',e_amount='" + Txt_amount.Text.Trim() + "',e_date='" + Txt_date.Text.Trim() + "',e_desc='" + Txt_desc.Text.Trim() + "' WHERE e_id='" + Txt_id.Value.Trim() + "'", conn);

        conn.Open();
        cmd.ExecuteNonQuery();
        conn.Close();
        string redirectScript = " window.location.href = 'expense_yearly.aspx';";
        System.Web.UI.ScriptManager.RegisterStartupScript(this, GetType(), "displayalertmessage", "alert('Expense Updated Successfully!!!');" + redirectScript, true);


    }
    protected void Repeater1_ItemCommand(object source, RepeaterCommandEventArgs e)
    {

        if (e.CommandName.Equals("showid"))
        {
            //get data
            string CarrierName = e.CommandArgument.ToString();
            SqlCommand cmd = new SqlCommand("select * from tbl_expense where e_id='" + CarrierName + "'", conn);
            SqlDataAdapter adapt = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapt.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                lbl_category.Text = dt.Rows[0]["e_category_name"].ToString();
                lbl_user.Text = dt.Rows[0]["e_user_name"].ToString();
                lbl_amount.Text = dt.Rows[0]["e_amount"].ToString();
                lbl_desc.Text = dt.Rows[0]["e_desc"].ToString();
                lbl_date.Text = Convert.ToDateTime(dt.Rows[0]["e_date"]).ToString("dd/MM/yyyy");


            }
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Modal", "ShowModel();", true);
        }
        if (e.CommandName.Equals("editid"))
        {
            //get data
            string CarrierName = e.CommandArgument.ToString();
            SqlCommand cmd = new SqlCommand("select * from tbl_expense where e_id='" + CarrierName + "'", conn);
            SqlDataAdapter adapt = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapt.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                Txt_id.Value = dt.Rows[0]["e_id"].ToString();

                Dd_category.SelectedItem.Text = dt.Rows[0]["e_category_name"].ToString();
                Dd_user.SelectedItem.Text = dt.Rows[0]["e_user_name"].ToString();

                Txt_amount.Text = dt.Rows[0]["e_amount"].ToString();
                Txt_desc.Text = dt.Rows[0]["e_desc"].ToString();
                Txt_date.Text = Convert.ToDateTime(dt.Rows[0]["e_date"]).ToString("yyyy-MM-dd");


            }

            ScriptManager.RegisterStartupScript(this, this.GetType(), "Modal", "ShowModel2();", true);
        }
    }

   
}