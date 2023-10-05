using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

public partial class Staff_salary_slip : System.Web.UI.Page
{
    SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["String"].ConnectionString);
    int id;
    protected void Page_Load(object sender, EventArgs e)
    {

        if (Session["a_email"] != null)
        {
            id = Convert.ToInt32(Request.QueryString["id"]);
            if (Page.IsPostBack) return;
            fill();
       

        }
        else
        {
            Response.Redirect("../login.aspx");
        }
    }
    public void fill()
    {
        SqlCommand cmd = new SqlCommand("select * from tbl_salary inner join tbl_staff on tbl_salary.st_id=tbl_staff.st_id where sal_id ='" + id + "'", conn);
        SqlDataAdapter adapt = new SqlDataAdapter(cmd);
        DataTable dt = new DataTable();
        adapt.Fill(dt);
        if (dt.Rows.Count > 0)
        {
            lbl_customer_name.Text = dt.Rows[0]["st_staff_name"].ToString();
            lbl_customer_contact.Text = dt.Rows[0]["st_contact"].ToString();
            lbl_customer_address.Text = dt.Rows[0]["st_address"].ToString();
            lbl_date.Text =Convert.ToDateTime(dt.Rows[0]["sal_date"]).ToString("MM/dd/yyyy");
            lbl_month.Text = dt.Rows[0]["sal_month"].ToString();
            lbl_balance.Text = dt.Rows[0]["sal_balance"].ToString();
            Repeater2.DataSource = dt;
            Repeater2.DataBind();
            
        }

        SqlCommand cmd2 = new SqlCommand("select * from tbl_company_details where com_id = 1", conn);
        SqlDataAdapter adapt2 = new SqlDataAdapter(cmd2);
        DataTable dt2 = new DataTable();
        adapt2.Fill(dt2);
        if (dt2.Rows.Count > 0)
        {
            lbl_company_name.Text = dt2.Rows[0]["com_company_name"].ToString();
            lbl_company_address.Text = dt2.Rows[0]["com_address"].ToString();
            lbl_company_contact.Text = dt2.Rows[0]["com_contact"].ToString();
            lbl_company_email.Text = dt2.Rows[0]["com_email"].ToString();
            Image1.ImageUrl = "~/Company/Company_Photos/" + dt2.Rows[0]["com_company_logo"].ToString();
        }
    }

}