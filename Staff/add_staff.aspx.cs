using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

public partial class Staff_add_staff : System.Web.UI.Page
{
    SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["String"].ConnectionString);
    string admin_email;
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
                if (!IsPostBack)
            {
                Txt_joining_date.Text = DateTime.Today.ToString("yyyy-MM-dd");
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

    protected void Btn_submit_Click(object sender, EventArgs e)
    {
        SqlCommand cmd1 = new SqlCommand("Select * from tbl_staff where st_contact='" + Txt_contact.Text.Trim() + "'", conn);

        SqlDataAdapter adapt1 = new SqlDataAdapter(cmd1);
        DataTable dt1 = new DataTable();
        adapt1.Fill(dt1);

        if (dt1.Rows.Count > 0)
        {
            //Lbl_message.Text = "Staff Member Already Exist!!!";
            System.Web.UI.ScriptManager.RegisterStartupScript(this, GetType(), "displayalertmessage", "alert('Staff Already Exist !!!');", true);
        }
        else
        {
            if (Txt_left_date.Text == "")
            {
                Txt_left_date.Text = null;


                SqlCommand cmd = new SqlCommand("insert into tbl_staff values(@st_staff_name,@st_address,@st_contact,@st_dob,@st_gender,@st_designation,@st_salary,@st_balance,@st_joining_date,@st_left_date)", conn);
                cmd.Parameters.AddWithValue("@st_staff_name", Txt_staff_name.Text);
                cmd.Parameters.AddWithValue("@st_address", Txt_address.Text);
                cmd.Parameters.AddWithValue("@st_contact", Txt_contact.Text);
                cmd.Parameters.AddWithValue("@st_dob", Txt_dob.Text);
                cmd.Parameters.AddWithValue("@st_gender", Dd_gender.Text);

                cmd.Parameters.AddWithValue("@st_designation", Txt_designation.Text);
                cmd.Parameters.AddWithValue("@st_salary", Txt_salary.Text);
                cmd.Parameters.AddWithValue("@st_balance", Txt_balance.Text);
                cmd.Parameters.AddWithValue("@st_joining_date", Txt_joining_date.Text);
                //cmd.Parameters.AddWithValue("@st_left_date", Txt_left_date.Text);
                cmd.Parameters.AddWithValue("@st_left_date", DBNull.Value);
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
                Response.Redirect("list_of_staff.aspx?insert=success");
            }
            else
            {
				SqlCommand cmd = new SqlCommand("insert into tbl_staff values(@st_staff_name,@st_address,@st_contact,@st_dob,@st_gender,@st_designation,@st_salary,@st_balance,@st_joining_date,@st_left_date)", conn);
				cmd.Parameters.AddWithValue("@st_staff_name", Txt_staff_name.Text);
				cmd.Parameters.AddWithValue("@st_address", Txt_address.Text);
				cmd.Parameters.AddWithValue("@st_contact", Txt_contact.Text);
				cmd.Parameters.AddWithValue("@st_dob", Txt_dob.Text);
				cmd.Parameters.AddWithValue("@st_gender", Dd_gender.Text);

				cmd.Parameters.AddWithValue("@st_designation", Txt_designation.Text);
				cmd.Parameters.AddWithValue("@st_salary", Txt_salary.Text);
				cmd.Parameters.AddWithValue("@st_balance", Txt_balance.Text);
				cmd.Parameters.AddWithValue("@st_joining_date", Txt_joining_date.Text);
				cmd.Parameters.AddWithValue("@st_left_date", Txt_left_date.Text);
				
				conn.Open();
				cmd.ExecuteNonQuery();
				conn.Close();
				Response.Redirect("list_of_staff.aspx?insert=success");
			}
        }
    }
  
}