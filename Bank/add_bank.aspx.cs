using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

public partial class Bank_add_bank : System.Web.UI.Page
{
    SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["String"].ConnectionString);
    SqlCommand cmd2, cmd3, cmd4;
    SqlDataAdapter adapt2, adapt3, adapt4;
    DataTable dt1, dt2, dt3, dt4;
    string admin_email;
    protected void Page_Load(object sender, EventArgs e)
    {
        Txt_bank_name.Focus();
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
                    this.FillRepeater();
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
    public void FillRepeater()
    {
        cmd2 = new SqlCommand("select * from tbl_bank", conn);
        adapt2 = new SqlDataAdapter(cmd2);
        DataTable dt = new DataTable();
        adapt2.Fill(dt);
        if (dt.Rows.Count > 0)
        {
            Repeater1.DataSource = dt;
            Repeater1.DataBind();
        }
    }
    protected void Btn_submit_Click(object sender, EventArgs e)
    {
        SqlCommand cmd = new SqlCommand("insert into tbl_bank values(@b_name,@b_ac_name,@b_ifsc,@b_ac_no,@b_opening_balance,@b_desc)", conn);
        cmd.Parameters.AddWithValue("@b_name", Txt_bank_name.Text);
        cmd.Parameters.AddWithValue("@b_ac_name", Txt_account_name.Text);
        cmd.Parameters.AddWithValue("@b_ifsc", Txt_ifsc.Text);
        cmd.Parameters.AddWithValue("@b_ac_no", Txt_account_no.Text);
        cmd.Parameters.AddWithValue("@b_opening_balance", Txt_opening_balance.Text);
        cmd.Parameters.AddWithValue("@b_desc", Txt_description.Text);
        
        conn.Open();
        cmd.ExecuteNonQuery();
        //Lbl_message.Text = "" + Txt_bank_name.Text + " Added Successfully!!!";
        //Page.Response.Redirect(Page.Request.RawUrl.ToString(), true);
        conn.Close();
        Response.Redirect("list_of_bank.aspx?insert=success");
        //string redirectScript = " window.location.href = 'add_bank.aspx';";
        //System.Web.UI.ScriptManager.RegisterStartupScript(this, GetType(), "displayalertmessage", "alert('New Bank Added Successfully!!!');" + redirectScript, true);

    }
}