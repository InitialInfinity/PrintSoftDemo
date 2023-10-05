using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

public partial class Company_company_details : System.Web.UI.Page
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
                cmd2 = new SqlCommand("select * from tbl_company_details", conn);
                adapt2 = new SqlDataAdapter(cmd2);
                dt2 = new DataTable();
                adapt2.Fill(dt2);

                if (dt2.Rows.Count > 0)
                {
                    lbl_company_name.Text = dt2.Rows[0]["com_company_name"].ToString();
                    lbl_company_name2.Text = dt2.Rows[0]["com_company_name2"].ToString();
                    lbl_owner_name.Text = dt2.Rows[0]["com_owner_name"].ToString();
                    lbl_address.Text = dt2.Rows[0]["com_address"].ToString();
                    lbl_contact.Text = dt2.Rows[0]["com_contact"].ToString();
                    lbl_gst.Text = dt2.Rows[0]["com_gst_no"].ToString();
                    lbl_email.Text = dt2.Rows[0]["com_email"].ToString();
                    lbl_website.Text = dt2.Rows[0]["com_website"].ToString();
                    lbl_logo.Text = dt2.Rows[0]["com_company_logo"].ToString();
                    lbl_logo2.Text = dt2.Rows[0]["com_company_logo2"].ToString();
                    lbl_bank_name.Text = dt2.Rows[0]["com_bank_name"].ToString();
                    lbl_branch.Text = dt2.Rows[0]["com_branch"].ToString();
                    lbl_ac_no.Text = dt2.Rows[0]["com_acc_no"].ToString();
                    lbl_ifsc.Text = dt2.Rows[0]["com_ifsc"].ToString();
                    lblupino.Text = dt2.Rows[0]["com_upino"].ToString();
                    Panel1.Visible = false;
                    Panel2.Visible = false;
                    Panel3.Visible = false;
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

        SqlCommand cmd = new SqlCommand("UPDATE tbl_company_details SET com_company_name='" + Txt_company_name.Text + "',com_company_name2='" + Txt_company_name2.Text + "',com_owner_name='" + Txt_owner_name.Text + "',com_address='" + Txt_address.Text + "',com_contact='" + Txt_contact.Text + "',com_gst_no='" + Txt_gst_no.Text + "',com_email='" + Txt_email.Text + "',com_website='" + Txt_website.Text + "',com_bank_name='" + Txt_bank_name.Text + "',com_branch='" + Txt_branch.Text + "',com_acc_no='" + Txt_acc_no.Text + "',com_ifsc='" + Txt_ifsc.Text + "',com_upino='" + txtupino.Text + "' where com_id=1", conn);

        conn.Open();
        cmd.ExecuteNonQuery();
        conn.Close();
        string redirectScript = " window.location.href = 'company_details.aspx';";
        System.Web.UI.ScriptManager.RegisterStartupScript(this, GetType(), "displayalertmessage", "alert('Company Details Updated Successfully!!!');" + redirectScript, true);

    }
    protected void update_info(object sender, EventArgs e)
    {
        Panel1.Visible = true;
        Panel4.Visible = false;

        cmd3 = new SqlCommand("select * from tbl_company_details where com_email='" + Session["a_email"] + "'", conn);
        adapt3 = new SqlDataAdapter(cmd3);
        dt3 = new DataTable();
        adapt2.Fill(dt3);

        if (dt3.Rows.Count > 0)
        {
            Txt_company_name.Text = dt2.Rows[0]["com_company_name"].ToString();
            Txt_company_name2.Text = dt2.Rows[0]["com_company_name2"].ToString();
            Txt_owner_name.Text = dt2.Rows[0]["com_owner_name"].ToString();
            Txt_address.Text = dt2.Rows[0]["com_address"].ToString();
            Txt_contact.Text = dt2.Rows[0]["com_contact"].ToString();
            Txt_gst_no.Text = dt2.Rows[0]["com_gst_no"].ToString();
            Txt_email.Text = dt2.Rows[0]["com_email"].ToString();
            Txt_website.Text = dt2.Rows[0]["com_website"].ToString();
            Txt_bank_name.Text = dt2.Rows[0]["com_bank_name"].ToString();
            Txt_branch.Text = dt2.Rows[0]["com_branch"].ToString();
            Txt_acc_no.Text = dt2.Rows[0]["com_acc_no"].ToString();
            Txt_ifsc.Text = dt2.Rows[0]["com_ifsc"].ToString();
            txtupino.Text = dt2.Rows[0]["com_upino"].ToString();


            Panel2.Visible = false;
            Panel3.Visible = false;
        }
    }

    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        Panel2.Visible = true;
    }
    protected void LinkButton2_Click(object sender, EventArgs e)
    {
        Panel3.Visible = true;
    }
    protected void Logo_Update(object sender, EventArgs e)
    {
        string strname = fu_company_logo.FileName.ToString();
        fu_company_logo.PostedFile.SaveAs(Server.MapPath("Company_Photos/") + strname);
        SqlCommand cmd = new SqlCommand("UPDATE tbl_company_details SET com_company_logo='" + strname.ToString() + "' where com_id=1", conn);

        conn.Open();
        cmd.ExecuteNonQuery();
        conn.Close();
        string redirectScript = " window.location.href = 'company_details.aspx';";
        System.Web.UI.ScriptManager.RegisterStartupScript(this, GetType(), "displayalertmessage", "alert('Company Logo Updated Successfully!!!');" + redirectScript, true);

    }
    protected void Logo_Update2(object sender, EventArgs e)
    {
        string strname = fu_company_logo2.FileName.ToString();
        fu_company_logo2.PostedFile.SaveAs(Server.MapPath("Company_Photos/") + strname);
        SqlCommand cmd = new SqlCommand("UPDATE tbl_company_details SET com_company_logo2='" + strname.ToString() + "' where com_id=1", conn);

        conn.Open();
        cmd.ExecuteNonQuery();
        conn.Close();
        string redirectScript = " window.location.href = 'company_details.aspx';";
        System.Web.UI.ScriptManager.RegisterStartupScript(this, GetType(), "displayalertmessage", "alert('Company Logo Updated Successfully!!!');" + redirectScript, true);

    }
}