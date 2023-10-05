using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using System.Text;
using System.Net;
using System.Net.Mail;

public partial class admin_panel_Settings_emails : System.Web.UI.Page
{
    SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["String"].ConnectionString);
    SqlCommand cmd,cmd2, cmd3, cmd4;
    SqlDataAdapter adapt, adapt2, adapt3, adapt4;
    DataTable dt, dt1, dt2, dt3, dt4;
    string key, country, senderid, route, email, password, port, subject, smtp, com_email;
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
                if (!IsPostBack)
            {
                FillRepeater();

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
        cmd = new SqlCommand("select c_name as [Customer Name],c_email as [Email] from tbl_customer", conn);
        adapt = new SqlDataAdapter(cmd);
        dt = new DataTable();
        adapt.Fill(dt);
        if (dt.Rows.Count > 0)
        {
            GridView1.DataSource = dt;
            GridView1.DataBind();
        }
    }
    protected void RowDataBound(object sender, GridViewRowEventArgs e)

    {

        if (e.Row.RowType == DataControlRowType.DataRow)

        {

            e.Row.Attributes.Add("onmouseover", "MouseEvents(this, event)");

            e.Row.Attributes.Add("onmouseout", "MouseEvents(this, event)");

        }

    }



    protected void Btn_submit_Click(object sender, EventArgs e)
    {
        foreach (GridViewRow row in GridView1.Rows)
        {
            string toemail;

            if (row.RowType == DataControlRowType.DataRow)
            {
                CheckBox chkRow = (row.Cells[0].FindControl("CheckBox1") as CheckBox);
                if (chkRow.Checked)
                {
                    toemail = (row.Cells[3].Text);

                    if (toemail != "&nbsp;")
                    {
                        SqlCommand cmd6 = new SqlCommand("select * from tbl_email_config ", conn);
                        SqlDataAdapter adapt6 = new SqlDataAdapter(cmd6);
                        DataTable dt6 = new DataTable();
                        adapt6.Fill(dt6);
                        if (dt6.Rows.Count > 0)
                        {
                            email = dt6.Rows[0]["ec_email"].ToString();
                            password = dt6.Rows[0]["ec_password"].ToString();

                            port = dt6.Rows[0]["ec_port"].ToString();
                            subject = dt6.Rows[0]["ec_subject"].ToString();
                            smtp = dt6.Rows[0]["ec_smtp"].ToString();
                        }

                        MailMessage mail = new MailMessage();
                        SmtpClient SmtpServer = new SmtpClient(smtp);

                        mail.From = new MailAddress(email);
                        mail.To.Add(toemail.ToString());
                        mail.Subject = Txt_subject.Text.ToString();
                        mail.Body = "" + Txt_message.Text.ToString() + "";

                        SmtpServer.Port = Convert.ToInt32(port);
                        SmtpServer.Credentials = new System.Net.NetworkCredential(email, password);
                        SmtpServer.EnableSsl = true;

                        SmtpServer.Send(mail);
                    }

                }


            }

        }
        System.Web.UI.ScriptManager.RegisterStartupScript(this, GetType(), "displayalertmessage", "alert('Mail has been Sent Successfully!!!');", true);

    }
}