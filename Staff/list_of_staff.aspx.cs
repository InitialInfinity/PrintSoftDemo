using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;


public partial class Staff_list_of_staff : System.Web.UI.Page
{
    SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["String"].ConnectionString);
    string custid, admin_email,insert,update;
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
                try
            {
                insert = (Request.QueryString["insert"]??"").ToString();
                if (insert == "success")
                {
                    Panel1.Visible = true;
                }

            }
            catch (Exception ex)
            { Panel1.Visible = false; }
            try
            {
                update = (Request.QueryString["update"]??"").ToString();
                if (update == "success")
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
        SqlCommand cmd = new SqlCommand("select * from tbl_staff order by st_id desc", conn);
        SqlDataAdapter adapt = new SqlDataAdapter(cmd);
        DataTable dt = new DataTable();
        adapt.Fill(dt);
        if (dt.Rows.Count > 0)
        {
            Repeater1.DataSource = dt;
            Repeater1.DataBind();
        }
    }

 
    protected void Repeater1_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if (e.CommandName.Equals("showid"))
        {
            //get data
            string CarrierName = e.CommandArgument.ToString();
            SqlCommand cmd = new SqlCommand("select * from tbl_staff where st_id='" + CarrierName + "'", conn);
            SqlDataAdapter adapt = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapt.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                lbl_name.Text = dt.Rows[0]["st_staff_name"].ToString();
              
                lbl_address.Text = dt.Rows[0]["st_address"].ToString();
                lbl_contact.Text = dt.Rows[0]["st_contact"].ToString();
                lbl_dob.Text =Convert.ToDateTime(dt.Rows[0]["st_dob"]).ToString("MM/dd/yyyy");
                lbl_gender.Text = dt.Rows[0]["st_gender"].ToString();
                
                lbl_designation.Text = dt.Rows[0]["st_designation"].ToString();
                lbl_salary.Text = dt.Rows[0]["st_salary"].ToString();
                lbl_balance.Text = dt.Rows[0]["st_balance"].ToString();
                lbl_joining_date.Text = Convert.ToDateTime(dt.Rows[0]["st_joining_date"]).ToString("MM/dd/yyyy");
                lbl_left_date.Text = Convert.ToDateTime(dt.Rows[0]["st_left_date"]).ToString("MM/dd/yyyy");

            }
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Modal", "ShowModel();", true);
        }
        if (e.CommandName.Equals("editid"))
        {
            //get data
            string CarrierName = e.CommandArgument.ToString();
            SqlCommand cmd = new SqlCommand("select * from tbl_staff where st_id='" + CarrierName + "'", conn);
            SqlDataAdapter adapt = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapt.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                Txt_id.Value = dt.Rows[0]["st_id"].ToString();
                Txt_name.Text = dt.Rows[0]["st_staff_name"].ToString();
                Txt_address.Text = dt.Rows[0]["st_address"].ToString();
                Txt_contact.Text = dt.Rows[0]["st_contact"].ToString();
                Txt_dob.Text = Convert.ToDateTime(dt.Rows[0]["st_dob"]).ToString("yyyy/MM/dd");
                Dd_gender.SelectedItem.Text = dt.Rows[0]["st_gender"].ToString();
             
                Txt_designation.Text = dt.Rows[0]["st_designation"].ToString();
                Txt_salary.Text = dt.Rows[0]["st_salary"].ToString();
                Txt_balance.Text = dt.Rows[0]["st_balance"].ToString();
                Txt_joining_date.Text = Convert.ToDateTime(dt.Rows[0]["st_joining_date"]).ToString("yyyy/MM/dd");
                Txt_left_date.Text = Convert.ToDateTime(dt.Rows[0]["st_left_date"]).ToString("yyyy/MM/dd");
            }
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Modal", "ShowModel2();", true);
        }
    }
   protected void Button1_Click(object sender, EventArgs e)
    {
        SqlCommand cmd = new SqlCommand("UPDATE tbl_staff SET st_staff_name='" + Txt_name.Text.Trim() + "',st_address='" + Txt_address.Text.Trim() + "',st_contact='" + Txt_contact.Text.Trim() + "',st_dob='" + Txt_dob.Text + "',st_gender='" + Dd_gender.SelectedItem.Text.Trim() + "',st_designation='" + Txt_designation.Text.Trim() + "',st_salary='" + Txt_salary.Text.Trim() + "',st_balance='" + Txt_balance.Text.Trim() + "',st_joining_date='" + Txt_joining_date.Text + "',st_left_date='" + Txt_left_date.Text + "' WHERE st_id='" + Txt_id.Value.Trim() + "'", conn);

        conn.Open();
        cmd.ExecuteNonQuery();
        conn.Close();
     
        Response.Redirect("list_of_staff.aspx?update=success");
    }
    protected void DeleteStaff(object sender, EventArgs e)
    {
        int customerId = int.Parse(((sender as LinkButton).NamingContainer.FindControl("lbl_id") as Label).Text);

        using (SqlCommand cmd = new SqlCommand("DELETE FROM tbl_staff WHERE st_id = @st_id", conn))
        {
            cmd.Parameters.AddWithValue("@st_id", customerId);
            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
        }
        this.FillRepeater();
    }
    
}