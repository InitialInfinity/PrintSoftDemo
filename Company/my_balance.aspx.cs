using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

public partial class Company_my_balance : System.Web.UI.Page
{
    SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["String"].ConnectionString);
    SqlCommand cmd2, cmd3, cmd4;
    SqlDataAdapter adapt2, adapt3, adapt4;
    DataTable dt1, dt2, dt3, dt4;
    string admin_email;
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



            }
            else
            {
                Response.Redirect("Admin_access2.aspx");

            }

        }
        else
        {
            Response.Redirect("../login.aspx");
        }
    }
}