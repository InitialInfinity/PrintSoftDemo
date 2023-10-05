using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

public partial class Staff_salary_report : System.Web.UI.Page
{
    SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["String"].ConnectionString);
    string admin_email;
    decimal balance, newbalance;
    string insert;
    protected void Page_Load(object sender, EventArgs e)
    {

        if (Session["a_email"] != null || Session["admin_email"] != null)
        {

            SqlCommand cmd4 = new SqlCommand("select * from tbl_admin_login", conn);
            SqlDataAdapter adapt4 = new SqlDataAdapter(cmd4);
            DataTable dt4 = new DataTable();
            adapt4.Fill(dt4);
            if (dt4.Rows.Count > 0)
            {
                admin_email = dt4.Rows[0]["a_email"].ToString();
            }
            if (admin_email.ToString() == Session["a_email"].ToString() || Session["admin_email"] != null)
            {
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
           
            if (Page.IsPostBack) return;
        
                this.FillRepeater();
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
  
    public void FillRepeater()
    {
        SqlCommand cmd = new SqlCommand("select * from tbl_salary inner join tbl_staff on tbl_salary.st_id=tbl_staff.st_id order by tbl_salary.st_id desc", conn);
        SqlDataAdapter adapt = new SqlDataAdapter(cmd);
        DataTable dt = new DataTable();
        adapt.Fill(dt);
        if (dt.Rows.Count > 0)
        {
            Repeater1.DataSource = dt;
            Repeater1.DataBind();
        }
    }
    
    protected void DeleteSalary(object sender, EventArgs e)
    {
        int customerId = int.Parse(((sender as LinkButton).NamingContainer.FindControl("lbl_id") as Label).Text);
        String staff_name = Convert.ToString(((sender as LinkButton).NamingContainer.FindControl("lbl_staff_name") as Label).Text);
        Decimal salary = Convert.ToDecimal(((sender as LinkButton).NamingContainer.FindControl("lbl_salary") as Label).Text);
        Decimal pay = Convert.ToDecimal(((sender as LinkButton).NamingContainer.FindControl("lbl_pay") as Label).Text);
        Decimal deduction = Convert.ToDecimal(((sender as LinkButton).NamingContainer.FindControl("lbl_deduction") as Label).Text);

        SqlCommand cmd6 = new SqlCommand("select * from tbl_staff where st_staff_name='" + staff_name + "'", conn);
        SqlDataAdapter adapt6 = new SqlDataAdapter(cmd6);
        DataTable dt6 = new DataTable();
        adapt6.Fill(dt6);
        if (dt6.Rows.Count > 0)
        {
            balance = Convert.ToDecimal(dt6.Rows[0]["st_balance"]);

        }
        
        using (SqlCommand cmd7 = new SqlCommand("update tbl_staff set st_balance= @balance where st_staff_name='" + staff_name + "'", conn))
        {

            newbalance = Convert.ToDecimal(balance) - (Convert.ToDecimal(salary)- Convert.ToDecimal(pay)- Convert.ToDecimal(deduction));
            cmd7.Parameters.Add("@balance", SqlDbType.Decimal).Value = newbalance;
            conn.Open();
            cmd7.ExecuteNonQuery();

            conn.Close();
        }

        using (SqlCommand cmd4 = new SqlCommand("DELETE FROM tbl_salary WHERE sal_id = @sal_id", conn))
        {
            cmd4.Parameters.AddWithValue("@sal_id", customerId);
            conn.Open();
            cmd4.ExecuteNonQuery();
            conn.Close();
        }


        this.FillRepeater();
    }
 
}