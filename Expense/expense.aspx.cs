using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

public partial class Expense_expense : System.Web.UI.Page
{
    SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["String"].ConnectionString);
    string admin_email,insert, insert_cat, insert_user;
    protected void Page_Load(object sender, EventArgs e)
    {
        Txt_user_name.Focus();
        Txt_category_name.Focus();
        Dd_category.Focus();
        if (Session["a_email"] != null)
        {
            Panel2.Visible = false;
            Panel3.Visible = false;
            Panel4.Visible = false;
            if (!IsPostBack)
            {
                try
                {
                    insert = (Request.QueryString["insert"]??"").ToString();
                    if (insert == "success")
                    {
                        Panel2.Visible = true;
                    }
                  
                }
                catch (Exception ex)
                { Panel2.Visible = false; }
                try
                {
                    insert_cat = (Request.QueryString["insert_cat"]??"").ToString();
                    if (insert_cat == "success")
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "toggle", "showcat();", true);
                        Panel3.Visible = true;
                    }

                }
                catch (Exception ex)
                { Panel3.Visible = false; }
                try
                {
                    insert_user = (Request.QueryString["insert_user"]??"").ToString();
                    if (insert_user == "success")
                    {
                        Panel4.Visible = true;
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "toggle", "showusr();", true);
                    }

                }
                catch (Exception ex)
                { Panel4.Visible = false; }

                //date time 
                DateTime serverTime = DateTime.Now; // gives you current Time in server timeZone
                DateTime utcTime = serverTime.ToUniversalTime(); // convert it to Utc using timezone setting of server computer

                TimeZoneInfo tzi = TimeZoneInfo.FindSystemTimeZoneById("India Standard Time");
                DateTime localTime = TimeZoneInfo.ConvertTimeFromUtc(utcTime, tzi); // convert from utc to local

                Txt_date.Text = DateTime.Today.ToString("yyyy-MM-dd");
                Txt_expense_date.Text = DateTime.Today.ToString("yyyy-MM-dd");
                //end

                //Txt_date.Text = DateTime.Today.ToString("yyyy-MM-dd");
                //Txt_expense_date.Text = DateTime.Today.ToString("yyyy-MM-dd");

                this.FillRepeater();

                this.FillRepeater3();
                this.user();
                this.category();
                this.Fill();
            }
        }
        else
        {
            Response.Redirect("../login.aspx");
        }
    }
    public void Fill()
    {
        SqlCommand cmd = new SqlCommand("Select * From tbl_expense Order By e_id desc", conn);
        SqlDataAdapter adapt = new SqlDataAdapter(cmd);
        DataTable dt = new DataTable();
        adapt.Fill(dt);
        if (dt.Rows.Count > 0)
        {
            Repeater2.DataSource = dt;
            Repeater2.DataBind();
           
        }
        else
        {
            Repeater2.DataSource = null;
            Repeater2.DataBind();
        
        }

    }
    public void FillRepeater()
    {
        SqlCommand cmd = new SqlCommand("select * from tbl_expense_user order by u_id desc", conn);
        SqlDataAdapter adapt = new SqlDataAdapter(cmd);
        DataTable dt = new DataTable();
        adapt.Fill(dt);
        if (dt.Rows.Count > 0)
        {
            Repeater1.DataSource = dt;
            Repeater1.DataBind();
        }
    }
    public void FillRepeater3()
    {
        SqlCommand cmd = new SqlCommand("select * from tbl_expense_category order by cat_id desc", conn);
        SqlDataAdapter adapt = new SqlDataAdapter(cmd);
        DataTable dt = new DataTable();
        adapt.Fill(dt);
        if (dt.Rows.Count > 0)
        {
            Repeater3.DataSource = dt;
            Repeater3.DataBind();
        }
    }
  
    public void user()
    {
        string query = "select * from tbl_expense_user order by u_user_name asc";
        SqlDataAdapter adapt4 = new SqlDataAdapter(query, conn);
        DataTable dt4 = new DataTable();
        adapt4.Fill(dt4);
        if (dt4.Rows.Count > 0)
        {
            Dd_user.DataSource = dt4;
            Dd_user.DataBind();
            Dd_user.DataTextField = "u_user_name";
            Dd_user.DataValueField = "u_id";
            Dd_user.DataBind();
            Dd_user.Items.Insert(0, new ListItem("--Select--", "--Select--"));
            Dd_user.SelectedItem.Selected = false;
            Dd_user.Items.FindByText("--Select--").Selected = true;
        }

    }
    public void category()
    {
        string query = "select * from tbl_expense_category order by cat_category_name asc";
        SqlDataAdapter adapt5 = new SqlDataAdapter(query, conn);
        DataTable dt5 = new DataTable();
        adapt5.Fill(dt5);
        if (dt5.Rows.Count > 0)
        {
            Dd_category.DataSource = dt5;
            Dd_category.DataBind();
            Dd_category.DataTextField = "cat_category_name";
            Dd_category.DataValueField = "cat_id";
            Dd_category.DataBind();
            Dd_category.Items.Insert(0, new ListItem("--Select--", "--Select--"));
            Dd_category.SelectedItem.Selected = false;
            Dd_category.Items.FindByText("--Select--").Selected = true;
        }

    }
    protected void Btn_submit_Click(object sender, EventArgs e)
    {
        SqlCommand cmd1 = new SqlCommand("select * from tbl_expense_user where u_contact=@u_contact", conn);
        cmd1.Parameters.AddWithValue("@u_contact", Txt_contact.Text);
        SqlDataAdapter adapt5 = new SqlDataAdapter(cmd1);
        DataTable dt5 = new DataTable();
        adapt5.Fill(dt5);
        if (dt5.Rows.Count > 0)
        {
            Lbl_message.Text = "user already exist";

        }
        else
        {

            SqlCommand cmd = new SqlCommand("insert into tbl_expense_user values(@u_user_name,@u_contact,@u_desc)", conn);
            cmd.Parameters.AddWithValue("@u_user_name", Txt_user_name.Text);
            cmd.Parameters.AddWithValue("@u_contact", Txt_contact.Text);
            cmd.Parameters.AddWithValue("@u_desc", Txt_desc.Text);
            conn.Open();
            cmd.ExecuteNonQuery();

            conn.Close();
            Response.Redirect("expense.aspx?insert_user=success");
        }
   
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        SqlCommand cmd1 = new SqlCommand ("select * from tbl_expense_category where cat_category_name=@cat_category_name",conn);
        cmd1.Parameters.AddWithValue("@cat_category_name", Txt_category_name.Text);
        SqlDataAdapter adapt5 = new SqlDataAdapter(cmd1);
        DataTable dt5 = new DataTable();
        adapt5.Fill(dt5);
        if (dt5.Rows.Count > 0)
        {
            Lbl_message2.Text = "Category already exist";
            // Response.Redirect("expense.aspx?insert_cat=success");

            //Session["CategoryCreated"] = true;
            string script = "<script type='text/javascript'>SwitchToTab('profile2');</script>";
            ClientScript.RegisterStartupScript(this.GetType(), "SwitchToTabScript", script);
            //Txt_category_name.Focus();
        }
        else
        {
            SqlCommand cmd = new SqlCommand("insert into tbl_expense_category values(@cat_category_name,@cat_date)", conn);
            cmd.Parameters.AddWithValue("@cat_category_name", Txt_category_name.Text);
            cmd.Parameters.AddWithValue("@cat_date", Txt_date.Text);

            conn.Open();
            cmd.ExecuteNonQuery();

            conn.Close();
            Response.Redirect("expense.aspx?insert_cat=success");
        }

          

      
    }
    protected void DeleteSale(object sender, EventArgs e)
    {
        String id = ((sender as LinkButton).NamingContainer.FindControl("lbl_sr") as Label).Text;


        using (SqlCommand cmd = new SqlCommand("DELETE FROM tbl_expense WHERE e_id = @e_id", conn))
        {

            cmd.Parameters.AddWithValue("@e_id", id);
            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
        }


        this.Fill();
    }
    protected void Button3_Click(object sender, EventArgs e)
    {
        try
        {
            string category, user;
            category = Dd_category.SelectedItem.Text;
            user = Dd_user.SelectedItem.Text;

            SqlCommand cmd = new SqlCommand("insert into tbl_expense values(@e_category_name,@e_user_name,@e_amount,@e_count,@e_date,@e_desc)", conn);
            cmd.Parameters.AddWithValue("@e_category_name", category.ToString());
            cmd.Parameters.AddWithValue("@e_user_name", user.ToString());
            cmd.Parameters.AddWithValue("@e_amount", Txt_amount.Text);
            cmd.Parameters.AddWithValue("@e_count", "0");
            cmd.Parameters.AddWithValue("@e_date", Convert.ToDateTime(Txt_expense_date.Text).ToString("MM/dd/yyyy"));
            cmd.Parameters.AddWithValue("@e_desc", Txt_ex_desc.Text);
            conn.Open();
            cmd.ExecuteNonQuery();

            conn.Close();
            Response.Redirect("expense.aspx?insert=success");
        }
        catch(Exception ex)
        {
            ex.Message.ToString();
        }
    }
    protected void DeleteUser(object sender, EventArgs e)
    {
        SqlCommand cmd1 = new SqlCommand("select * from tbl_admin_login", conn);
        SqlDataAdapter adapt1 = new SqlDataAdapter(cmd1);
        DataTable dt1 = new DataTable();
        adapt1.Fill(dt1);
        if (dt1.Rows.Count > 0)
        {
            admin_email = dt1.Rows[0]["a_email"].ToString();
        }
        if (admin_email.ToString() == Session["a_email"].ToString() || Session["admin_email"] != null)
        {
            int customerId = int.Parse(((sender as LinkButton).NamingContainer.FindControl("lbl_sr") as HiddenField).Value);

            using (SqlCommand cmd = new SqlCommand("DELETE FROM tbl_expense_user WHERE u_id = @c_id", conn))
            {
                cmd.Parameters.AddWithValue("@c_id", customerId);
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
            }
            
            Response.Redirect(Request.RawUrl);
        }
        else
        {
            Response.Redirect("../access_denied.aspx");

        }
    }
    protected void DeleteCategory(object sender, EventArgs e)
    {
        SqlCommand cmd1 = new SqlCommand("select * from tbl_admin_login", conn);
        SqlDataAdapter adapt1 = new SqlDataAdapter(cmd1);
        DataTable dt1 = new DataTable();
        adapt1.Fill(dt1);
        if (dt1.Rows.Count > 0)
        {
            admin_email = dt1.Rows[0]["a_email"].ToString();
        }
        if (admin_email.ToString() == Session["a_email"].ToString() || Session["admin_email"] != null)
        {
            int customerId = int.Parse(((sender as LinkButton).NamingContainer.FindControl("lbl_sr") as HiddenField).Value);

            using (SqlCommand cmd = new SqlCommand("DELETE FROM tbl_expense_category WHERE cat_id = @c_id", conn))
            {
                cmd.Parameters.AddWithValue("@c_id", customerId);
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
            }

            Response.Redirect(Request.RawUrl);
        }
        else
        {
            Response.Redirect("../access_denied.aspx");

        }
        

    }



    protected void Button2_Click(object sender, EventArgs e)
    {

    }

    protected void Button4_Click(object sender, EventArgs e)
    {
        category();
        user();
        Txt_amount.Text = "";
        DateTime serverTime = DateTime.Now; // gives you current Time in server timeZone
        DateTime utcTime = serverTime.ToUniversalTime(); // convert it to Utc using timezone setting of server computer

        TimeZoneInfo tzi = TimeZoneInfo.FindSystemTimeZoneById("India Standard Time");
        DateTime localTime = TimeZoneInfo.ConvertTimeFromUtc(utcTime, tzi); // convert from utc to local

        Txt_date.Text = DateTime.Today.ToString("yyyy-MM-dd");
        Txt_ex_desc.Text = "";

    }
}

 