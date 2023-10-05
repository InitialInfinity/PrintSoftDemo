using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

public partial class Settings_clear_database : System.Web.UI.Page
{
    SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["String"].ConnectionString);
    SqlCommand cmd2, cmd3, cmd4;
    SqlDataAdapter adapt2, adapt3, adapt4;
    DataTable dt1, dt2, dt3, dt4;
    string admin_email;
    string email, gst,username,password;
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
                if (!IsPostBack)
                {
                    Panel1.Visible = true;
                    Panel2.Visible = false;
                    Panel3.Visible = false;

                }
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

    protected void btn_clear_Click(object sender, EventArgs e)
    {
        
    }
    
    protected void Btn_submit_Click(object sender, EventArgs e)
    {

        SqlCommand cmd = new SqlCommand("select * from tbl_company_details where com_id=1", conn);
        SqlDataAdapter adapt = new SqlDataAdapter(cmd);
        DataTable dt = new DataTable();
        adapt.Fill(dt);
        if (dt.Rows.Count > 0)
        {
           email = dt.Rows[0]["com_email"].ToString();
           gst = dt.Rows[0]["com_gst_no"].ToString();

        }
        if (email==Txt_company_email.Text.ToString() && gst == Txt_comapany_gst.Text.ToString())
        {
            Panel1.Visible = false;
            Panel2.Visible = true;
            Panel3.Visible = false;
        }
        else
        {
            lbl_msg.Text = "Email and GST is Wrong !!! ";
        }

    }

    protected void Button1_Click(object sender, EventArgs e)
    {

        SqlCommand cmd = new SqlCommand("select * from tbl_admin_login", conn);
        SqlDataAdapter adapt = new SqlDataAdapter(cmd);
        DataTable dt = new DataTable();
        adapt.Fill(dt);
        if (dt.Rows.Count > 0)
        {
            username = dt.Rows[0]["a_email"].ToString();
            password = dt.Rows[0]["a_password"].ToString();

        }
        if (username == Txt_email.Text.ToString() && password == Txt_password.Text.ToString())
        {
            Panel1.Visible = false;
        Panel2.Visible = false;
        Panel3.Visible = true;
        }
        else
        {
            lbl_msg2.Text = "Admin Email and Password is Wrong !!! ";
        }
    }
}