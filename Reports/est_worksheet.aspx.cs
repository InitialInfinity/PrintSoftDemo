using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

public partial class Reports_est_monthly_worksheet : System.Web.UI.Page
{

    SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["String"].ConnectionString);
    SqlCommand cmd2, cmd3, cmd4, cmd7, cmd8, cmd9;
    SqlDataAdapter adapt2, adapt3, adapt7, adapt8, adapt9;
    DataTable dt1, dt2, dt7, dt8, dt9;
    decimal amount, amount2, paid, balance, total;
    protected void Page_Load(object sender, EventArgs e)
    {

        if (Session["a_email"] != null)
        {
            Panel1.Visible = false;
            if (Page.IsPostBack) return;
            Date1.Text = DateTime.Today.ToString("yyyy-MM-dd");
            Date2.Text = DateTime.Today.ToString("yyyy-MM-dd");
            customer();

        }
        else
        {
            Response.Redirect("../login.aspx");
        }
    }
    public void customer()
    {
        string query = "select * from tbl_customer Order By c_name asc";
        SqlDataAdapter adapt4 = new SqlDataAdapter(query, conn);
        DataTable dt5 = new DataTable();
        adapt4.Fill(dt5);
        if (dt5.Rows.Count > 0)
        {
            Dd_customer.DataSource = dt5;
            Dd_customer.DataBind();
            Dd_customer.DataTextField = "c_name";
            Dd_customer.DataValueField = "c_id";
            Dd_customer.DataBind();
            Dd_customer.Items.Insert(0, new ListItem("--Select--", "--Select--"));
            Dd_customer.SelectedItem.Selected = false;
            Dd_customer.Items.FindByText("--Select--").Selected = true;
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

        //    // Response.Close();
        //    string date = DateTime.Now.ToString("dd-MM-yyyy--HH-mm");
        //    var da = new SqlDataAdapter("Select cp_id as [ID],cp_customer_name as [Customer Name],cp_balance as [Balance],cp_advance as [Advance],cp_mode as [Payment Mode],cp_total_balance as [Total Balance] From tbl_customer_payment Order By cp_id desc", conn);
        //    var dt = new DataTable();
        //    da.Fill(dt);


        //    GridView1.DataSource = dt;
        //    GridView1.DataBind();
        //    Response.Clear();
        //    Response.Charset = "";
        //    Response.Cache.SetCacheability(HttpCacheability.NoCache);
        //    Response.ContentType = "application/vnd.xls";
        //    Response.AddHeader("content-disposition", "attachment;filename=Customer Payment-" + date + ".xls");

        //    System.IO.StringWriter sw = new System.IO.StringWriter();
        //    HtmlTextWriter htw = new HtmlTextWriter(sw);
        //    GridView1.RenderControl(htw);
        //    System.Text.StringBuilder sb1 = new System.Text.StringBuilder();
        //    sb1 = sb1.Append("<table cellspacing='0' cellpadding='0' width='100 % ' align='center' border='1'>" + sw.ToString() + "</table>");
        //    sw = null;
        //    htw = null;
        //    Response.Write(sb1.ToString());
        //    sb1.Remove(0, sb1.Length);
        //    Response.Flush();
        //    Response.End();
        //}
        //catch (Exception ex)
        //{

        //}
    }
    protected void pdf_export(object sender, EventArgs e)
    {

    }

    protected void Dd_customer_SelectedIndexChanged(object sender, EventArgs e)
    {



      

        
    }

    protected void btn_search_Click(object sender, EventArgs e)
    {
        if (Date1.Text == "" || Date2.Text == "")
        {
            Panel1.Visible = true;
            cmd2 = new SqlCommand("select * from tbl_estimate_details where c_id ='" + Dd_customer.SelectedItem.Value + "'", conn);
            adapt2 = new SqlDataAdapter(cmd2);
            dt1 = new DataTable();
            adapt2.Fill(dt1);
            if (dt1.Rows.Count > 0)
            {
                Repeater2.DataSource = dt1;
                Repeater2.DataBind();

                lbl_invoice_amount.Text = dt1.Compute("Sum(es_stotal)", string.Empty).ToString();

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
                Image1.ImageUrl = "~/Company/Company_Photos/" + dt5.Rows[0]["com_company_logo"].ToString();
            }

            SqlCommand cmd6 = new SqlCommand("select * from tbl_customer where c_name = '" + Dd_customer.SelectedItem.Text + "'", conn);
            SqlDataAdapter adapt6 = new SqlDataAdapter(cmd6);
            DataTable dt6 = new DataTable();
            adapt6.Fill(dt6);
            if (dt6.Rows.Count > 0)
            {
                lbl_customer_name.Text = dt6.Rows[0]["c_name"].ToString();
                lbl_customer_contact.Text = dt6.Rows[0]["c_contact"].ToString();
                lbl_customer_address.Text = dt6.Rows[0]["c_address"].ToString();
                lbl_gst_no.Text = dt6.Rows[0]["c_gst_no"].ToString();


            }

            cmd7 = new SqlCommand("select sum(est_balance) from tbl_estimate where c_id='" + Dd_customer.SelectedItem.Value + "'", conn);
            adapt7 = new SqlDataAdapter(cmd7);
            dt7 = new DataTable();
            adapt7.Fill(dt7);
            if (dt7.Rows.Count > 0)
            {


                if (dt7.Rows[0][0] == System.DBNull.Value)
                {
                    lbl_balance_amount.Text = "0";
                    //   lbl_due_balance.Text = "0";
                }
                else
                {
                    lbl_balance_amount.Text = dt7.Rows[0][0].ToString();
                    //   lbl_due_balance.Text = dt7.Rows[0][0].ToString();
                }
            }


        }
        else
        {
            Panel1.Visible = true;
            cmd2 = new SqlCommand("select * from tbl_estimate_details where c_id ='" + Dd_customer.SelectedItem.Value + "' AND es_date between '" + Date1.Text + "' AND '" + Date2.Text + "'", conn);
            adapt2 = new SqlDataAdapter(cmd2);
            dt1 = new DataTable();
            adapt2.Fill(dt1);
            if (dt1.Rows.Count > 0)
            {
                Repeater2.DataSource = dt1;
                Repeater2.DataBind();
                lbl_invoice_amount.Text = dt1.Compute("Sum(es_stotal)", string.Empty).ToString();
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
                Image1.ImageUrl = "~/Company/Company_Photos/" + dt5.Rows[0]["com_company_logo"].ToString();
            }

            SqlCommand cmd6 = new SqlCommand("select * from tbl_customer where c_name = '" + Dd_customer.SelectedItem.Text + "'", conn);
            SqlDataAdapter adapt6 = new SqlDataAdapter(cmd6);
            DataTable dt6 = new DataTable();
            adapt6.Fill(dt6);
            if (dt6.Rows.Count > 0)
            {
                lbl_customer_name.Text = dt6.Rows[0]["c_name"].ToString();
                lbl_customer_contact.Text = dt6.Rows[0]["c_contact"].ToString();
                lbl_customer_address.Text = dt6.Rows[0]["c_address"].ToString();
                lbl_gst_no.Text = dt6.Rows[0]["c_gst_no"].ToString();


            }

            cmd7 = new SqlCommand("select sum(est_balance) from tbl_estimate where c_id='" + Dd_customer.SelectedItem.Value + "' AND est_date between '" + Date1.Text + "' AND '" + Date2.Text + "' ", conn);
            adapt7 = new SqlDataAdapter(cmd7);
            dt7 = new DataTable();
            adapt7.Fill(dt7);
            if (dt7.Rows.Count > 0)
            {
                if (dt7.Rows[0][0] == System.DBNull.Value)
                {
                    lbl_balance_amount.Text = "0";
                   // lbl_due_balance.Text = "0";
                }
                else
                {
                    lbl_balance_amount.Text = dt7.Rows[0][0].ToString();
                  //  lbl_due_balance.Text = dt7.Rows[0][0].ToString();
                }

            }
        }
        }
    }