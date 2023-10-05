using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

public partial class Admin_change_password : System.Web.UI.Page
{
    SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["String"].ConnectionString);
    string admin_email,insert, update,insert_role, update_user;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["a_email"] != null || Session["admin_email"] != null)
        {
            Txt_date.Text = DateTime.Today.ToString("yyyy-MM-dd");
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
            try
            {
                update = Request.QueryString["update"].ToString();
                if (update == "success")
                {
                    Panel3.Visible = true;
                }

            }
            catch (Exception ex)
            { Panel3.Visible = false; }
            try
            {
                insert_role = Request.QueryString["insert_role"].ToString();
                if (insert_role == "success")
                {
                    Panel4.Visible = true;
                }

            }
            catch (Exception ex)
            { Panel4.Visible = false; }
            try
            {
                update_user = Request.QueryString["update_user"].ToString();
                if (update_user == "success")
                {
                    Panel5.Visible = true;
                }

            }
            catch (Exception ex)
            { Panel5.Visible = false; }

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
                    this.FillRepeater();
                    this.FillRepeater2();
                    this.role();
                    this.role2();
                }
            }
            else {
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
        SqlCommand cmd = new SqlCommand("select * from tbl_admin_role order by ar_id desc", conn);
        SqlDataAdapter adapt = new SqlDataAdapter(cmd);
        DataTable dt = new DataTable();
        adapt.Fill(dt);
        if (dt.Rows.Count > 0)
        {
            Repeater1.DataSource = dt;
            Repeater1.DataBind();
        }
    }
    public void FillRepeater2()
    {
        SqlCommand cmd = new SqlCommand("select * from tbl_admin_user order by au_id desc", conn);
        SqlDataAdapter adapt = new SqlDataAdapter(cmd);
        DataTable dt = new DataTable();        adapt.Fill(dt);
        if (dt.Rows.Count > 0)
        {
            Repeater3.DataSource = dt;
            Repeater3.DataBind();
        }
    }
    public void role()
    {
        string query = "select * from tbl_admin_role";
        SqlDataAdapter adapt3 = new SqlDataAdapter(query, conn);
        DataTable dt3 = new DataTable();
        adapt3.Fill(dt3);
        if (dt3.Rows.Count > 0)
        {
            Dd_role.DataSource = dt3;
            Dd_role.DataBind();
            Dd_role.DataTextField = "ar_name";
            Dd_role.DataValueField = "ar_id";
            Dd_role.DataBind();
            Dd_role.Items.Insert(0, new ListItem("--Select--", "--Select--"));
            Dd_role.SelectedItem.Selected = false;
            Dd_role.Items.FindByText("--Select--").Selected = true;
        }

    }
    public void role2()
    {
        string query = "select * from tbl_admin_role";
        SqlDataAdapter adapt3 = new SqlDataAdapter(query, conn);
        DataTable dt3 = new DataTable();
        adapt3.Fill(dt3);
        if (dt3.Rows.Count > 0)
        {
            Dd_role2.DataSource = dt3;
            Dd_role2.DataBind();
            Dd_role2.DataTextField = "ar_name";
            Dd_role2.DataValueField = "ar_id";
            Dd_role2.DataBind();
            Dd_role2.Items.Insert(0, new ListItem("--Select--", "--Select--"));
            Dd_role2.SelectedItem.Selected = false;
            Dd_role2.Items.FindByText("--Select--").Selected = true;
        }

    }
    protected void Button3_Click(object sender, EventArgs e)
    {
        SqlCommand cmd1 = new SqlCommand("Select * from tbl_admin_role where ar_name='" + Txt_role_name.Text.Trim() + "' ", conn);
        //cmd2.Parameters.AddWithValue("@c_name", this.Txt_customer_name.Text);
        SqlDataAdapter adapt1 = new SqlDataAdapter(cmd1);
        DataTable dt1 = new DataTable();
        adapt1.Fill(dt1);
        
        if (dt1.Rows.Count > 0)
        {
            Lbl_message1.Text = "Role Already Exist!!!";
        }
        else
        {
            SqlCommand cmd = new SqlCommand("insert into tbl_admin_role values(@ar_name,@ar_date)", conn);
            cmd.Parameters.AddWithValue("@ar_name", Txt_role_name.Text);
            cmd.Parameters.AddWithValue("@ar_date", Txt_date.Text);

            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
            Response.Redirect("change_password.aspx?insert_role=success");
            
        }
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        string role;
        role = Dd_role.SelectedItem.Text;
        SqlCommand cmd1 = new SqlCommand("Select * from tbl_admin_login where a_email='" + Txt_email.Text.Trim() + "' ", conn);
        SqlDataAdapter adapt1 = new SqlDataAdapter(cmd1);
        DataTable dt1 = new DataTable();
        adapt1.Fill(dt1);
        
        if (dt1.Rows.Count > 0)
        {
            Lbl_message2.Text = "User Already Exist!!!";
        }
        else
        {
            SqlCommand cmd2 = new SqlCommand("Select * from tbl_admin_user where au_name='" + Txt_full_name.Text.Trim() + "' OR au_email='" + Txt_email.Text.Trim() + "' ", conn);
            SqlDataAdapter adapt2 = new SqlDataAdapter(cmd2);
            DataTable dt2 = new DataTable();
            adapt2.Fill(dt2);
            
            if (dt2.Rows.Count > 0)
            {
                Lbl_message2.Text = "User Already Exist!!!";
            }
            else
            {
                SqlCommand cmd = new SqlCommand("insert into tbl_admin_user values(@au_role,@au_name,@au_email,@au_password)", conn);
                cmd.Parameters.AddWithValue("@au_role", role.ToString());
                cmd.Parameters.AddWithValue("@au_name", Txt_full_name.Text);
                cmd.Parameters.AddWithValue("@au_email", Txt_email.Text);
                cmd.Parameters.AddWithValue("@au_password", Txt_password.Text);
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
                Response.Redirect("change_password.aspx?insert=success");
                
            }
        }
    }

    protected void Btn_submit_Click(object sender, EventArgs e)
    {

        SqlCommand cmd1 = new SqlCommand("Select * from tbl_admin_login where a_password='" + Txt_old_password.Text.Trim() + "' ", conn);
        //cmd2.Parameters.AddWithValue("@c_name", this.Txt_customer_name.Text);
        SqlDataAdapter adapt1 = new SqlDataAdapter(cmd1);
        DataTable dt1 = new DataTable();
        adapt1.Fill(dt1);
        
        if (dt1.Rows.Count <= 0)
        {
            Lbl_message.Text = "Wrong Password!!!";
        }
        else
        {
            SqlCommand cmd = new SqlCommand("UPDATE tbl_admin_login SET a_password='" + Txt_new_password.Text.Trim() + "'", conn);
            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
            Response.Redirect("change_password.aspx?update=success");
        }
    }

    protected void Repeater3_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if (e.CommandName.Equals("showid"))
        {
            //get data
            string CarrierName = e.CommandArgument.ToString();
            SqlCommand cmd = new SqlCommand("select * from tbl_admin_user where au_id='" + CarrierName + "'", conn);
            SqlDataAdapter adapt = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapt.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                lbl_user.Text = dt.Rows[0]["au_name"].ToString();
                lbl_role.Text = dt.Rows[0]["au_role"].ToString();
                lbl_email.Text = dt.Rows[0]["au_email"].ToString();
                lbl_password.Text = dt.Rows[0]["au_password"].ToString();
               
            }
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Modal", "ShowModel();", true);
        }
        if (e.CommandName.Equals("editid"))
        {
            //get data
            string CarrierName = e.CommandArgument.ToString();
            SqlCommand cmd = new SqlCommand("select * from tbl_admin_user where au_id='" + CarrierName + "'", conn);
            SqlDataAdapter adapt = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapt.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                Txt_id.Value = dt.Rows[0]["au_id"].ToString();
                Txt_user2.Text = dt.Rows[0]["au_name"].ToString();
                Dd_role2.SelectedItem.Text = dt.Rows[0]["au_role"].ToString();
                Txt_email2.Text = dt.Rows[0]["au_email"].ToString();
                Txt_password2.Text = dt.Rows[0]["au_password"].ToString();
               
            }
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Modal", "ShowModel2();", true);
        }
    }

    protected void DeleteUser(object sender, EventArgs e)
    {
        int bankId = int.Parse(((sender as LinkButton).NamingContainer.FindControl("lbl_id") as Label).Text);

        using (SqlCommand cmd = new SqlCommand("DELETE FROM tbl_admin_user WHERE au_id = @b_id", conn))
        {
            cmd.Parameters.AddWithValue("@b_id", bankId);
            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
        
        }
       this.FillRepeater2();
    }
    protected void DeleteRole(object sender, EventArgs e)
    {
        int bankId = int.Parse(((sender as LinkButton).NamingContainer.FindControl("lbl_id") as Label).Text);

        using (SqlCommand cmd = new SqlCommand("DELETE FROM tbl_admin_role WHERE ar_id = @b_id", conn))
        {
            cmd.Parameters.AddWithValue("@b_id", bankId);
            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
        }


        this.FillRepeater();
    }

    protected void Button5_Click(object sender, EventArgs e)
    {
        try
        {
            SqlCommand cmd = new SqlCommand("UPDATE tbl_admin_user SET au_name='" + Txt_user2.Text.Trim() + "',au_role='" + Dd_role2.SelectedItem.Text.Trim() + "',au_email='" + Txt_email2.Text.Trim() + "',au_password='" + Txt_password2.Text.Trim() + "' WHERE au_id='" + Txt_id.Value.Trim() + "'", conn);

            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
            Response.Redirect("change_password.aspx?update_user=success");
        }
        catch (Exception ex)
        {

        }

    }
}