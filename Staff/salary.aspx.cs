using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

public partial class Staff_salary : System.Web.UI.Page
{
    SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["String"].ConnectionString);
     string admin_email; 
    protected void Page_Load(object sender, EventArgs e)
    {

        if (Session["a_email"] != null || Session["admin_email"] != null)
        {

            SqlCommand cmd = new SqlCommand("select * from tbl_admin_login", conn);
            SqlDataAdapter adapt = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapt.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                admin_email = dt.Rows[0]["a_email"].ToString();
            }
            if (admin_email.ToString() == Session["a_email"].ToString() || Session["admin_email"] != null)
            {

                if (!IsPostBack)
               {
                Txt_date.Text = DateTime.Today.ToString("yyyy-MM-dd");
          
                this.staff();
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
 
    public void staff()
    {
        string query = "select * from tbl_staff";
        SqlDataAdapter adapt4 = new SqlDataAdapter(query, conn);
        DataTable dt5 = new DataTable();
        adapt4.Fill(dt5);
        if (dt5.Rows.Count > 0)
        {
            Dd_staff_name.DataSource = dt5;
            Dd_staff_name.DataBind();
            Dd_staff_name.DataTextField = "st_staff_name";
            Dd_staff_name.DataValueField = "st_id";
            Dd_staff_name.DataBind();
            Dd_staff_name.Items.Insert(0, new ListItem("--Select--", "--Select--"));
            Dd_staff_name.SelectedItem.Selected = false;
            Dd_staff_name.Items.FindByText("--Select--").Selected = true;
        }

    }

    protected void Btn_submit_Click(object sender, EventArgs e)
    {
        decimal newbalance;
        newbalance = (((Convert.ToDecimal(hd_salary.Value) + Convert.ToDecimal(hd_balance.Value))-Convert.ToDecimal(Txt_deduction.Text)) - Convert.ToDecimal(Txt_pay.Text));

        SqlCommand cmd1 = new SqlCommand("UPDATE tbl_staff SET st_balance='"+newbalance+ "' WHERE st_id='" + Dd_staff_name.SelectedValue + "'", conn);

        conn.Open();
        cmd1.ExecuteNonQuery();
        conn.Close();
       
     
        SqlCommand cmd = new SqlCommand("insert into tbl_salary values(@st_id,@sal_salary,@sal_pay,@sal_deduction,@sal_balance,@sal_month,@sal_date,@sal_remark)", conn);
        cmd.Parameters.AddWithValue("@st_id", Dd_staff_name.SelectedValue);
        cmd.Parameters.AddWithValue("@sal_salary", hd_salary.Value);
        cmd.Parameters.AddWithValue("@sal_pay", Txt_pay.Text);
        cmd.Parameters.AddWithValue("@sal_deduction", Txt_deduction.Text);
        cmd.Parameters.AddWithValue("@sal_balance", newbalance);
        cmd.Parameters.AddWithValue("@sal_month", Dd_month.SelectedItem.Text);
        cmd.Parameters.AddWithValue("@sal_date", Txt_date.Text);
        cmd.Parameters.AddWithValue("@sal_remark", Txt_remark.Text);
        conn.Open();
        cmd.ExecuteNonQuery();
        conn.Close();
        Response.Redirect("salary_report.aspx?insert=success");
 
    }
    protected void Dd_staff_name_SelectedIndexChanged(object sender, EventArgs e)
    {

        SqlCommand cmd = new SqlCommand("select * from tbl_staff where st_id ='" + Dd_staff_name.SelectedValue + "'", conn);
        SqlDataAdapter adapt = new SqlDataAdapter(cmd);
        DataTable dt = new DataTable();

        adapt.Fill(dt);
        if (dt.Rows.Count > 0)
        {
            Txt_salary.Text = dt.Rows[0]["st_salary"].ToString();
            Txt_balance.Text = dt.Rows[0]["st_balance"].ToString();
            hd_salary.Value = dt.Rows[0]["st_salary"].ToString();
            hd_balance.Value = dt.Rows[0]["st_balance"].ToString();

        }
    }
}
