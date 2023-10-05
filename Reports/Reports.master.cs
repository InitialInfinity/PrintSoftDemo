using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

public partial class Reports_Reports : System.Web.UI.MasterPage
{
    SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["String"].ConnectionString);
    SqlCommand cmd2, cmd3, cmd4;
    SqlDataAdapter adapt2, adapt3;
    DataTable dt1, dt2;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["a_email"] != null)
        {
            cmd2 = new SqlCommand("select * from tbl_company_details where com_id=1", conn);
            adapt2 = new SqlDataAdapter(cmd2);
            dt2 = new DataTable();
            adapt2.Fill(dt2);
            if (dt2.Rows.Count > 0)
            {
                string image = dt2.Rows[0]["com_company_logo"].ToString();
                Image1.ImageUrl = "~/Company/Company_Photos/" + image;
                Image2.ImageUrl = "~/Company/Company_Photos/" + image;
                lbl_name1.Text = dt2.Rows[0]["com_company_name"].ToString();
                lbl_name2.Text = dt2.Rows[0]["com_company_name"].ToString();
                lbl_email.Text = dt2.Rows[0]["com_email"].ToString();

            }
        }
        else
        {
            Response.Redirect("login.aspx");
        }
    }
}
