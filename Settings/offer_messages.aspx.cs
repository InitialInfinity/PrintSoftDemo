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

public partial class admin_panel_Settings_offer_messages : System.Web.UI.Page
{
    SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["String"].ConnectionString);
    SqlCommand cmd, cmd2, cmd3, cmd4;
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
        cmd = new SqlCommand("select c_name as [Customer Name],c_contact as [Contact] from tbl_customer", conn);
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
            string no;

            if (row.RowType == DataControlRowType.DataRow)
            {
                CheckBox chkRow = (row.Cells[0].FindControl("CheckBox1") as CheckBox);
                if (chkRow.Checked)
                {
                    no = (row.Cells[2].Text);

                    SqlCommand cmd5 = new SqlCommand("select * from tbl_sms_config ", conn);
                    SqlDataAdapter adapt5 = new SqlDataAdapter(cmd5);
                    DataTable dt5 = new DataTable();
                    adapt5.Fill(dt5);
                    if (dt5.Rows.Count > 0)
                    {
                        key = dt5.Rows[0]["sc_key"].ToString();
                        country = dt5.Rows[0]["sc_country"].ToString();

                        senderid = dt5.Rows[0]["sc_sender"].ToString();
                        route = dt5.Rows[0]["sc_route"].ToString();

                    }

                    decimal mob = Convert.ToDecimal(no);
                    WebClient client = new WebClient();
                    string to;
                    string msgRecepient = mob.ToString();
                    //  string msgText = "Thank You for choosing Kalaratna Graphics For any Support Services related assistance,please feel free to call 9822228163 your Billing amount is'" + txtGfinaltotal.Text + "'and advance payment is'" + txtGAdvanceAmt.Text + "'and your balance amount is '" + txtPrevoiusOutstanding.Text + "'Thank You For Visiting Kalaratna Graphics";
                    string msgText = "" + Txt_message.Text.ToString() +"" ;

                    to = mob.ToString();

                    //      message = "Thank you For Visiting Universal Enterprises your total amount is'" + txtGfinaltotal.Text + "'and advance payment is'" + txtGAdvanceAmt.Text + "'and your balance amount is '" + txtPrevoiusOutstanding.Text + "'";
                    //string baseURL = "http://api.clickatell.com/http/sendmsg?user=zisan94268&password=OYeNLVUHTNIHbD&api_id=3528011&to='" + to + "'&text='" + message + "'";
                    //string baseURL = "http://dndsms.dit.asia/api/sendhttp.php?authkey=5267AqYrwzHDq5982bf51&mobiles='" + to + "'&message='" + message + "'&sender=SMILED&route=1&country=91";
                    //string baseURL = "http://dndsms.dit.asia/api/sendhttp.php?authkey=5267AqYrwzHDq5982bf5&user=lacewingtech&password=838213&&sender=SMILED&route=1&country=91&mobiles=to&message='" + message + "''";

                    //string baseURL = "http://dndsms.dit.asia/api/sendhttp.php?authkey=5267AqYrwzHDq5982bf5&message=test+%26+new&sender=ABCDEF&route=4&mobiles=8286538225";

                    string baseURL = "http://dndsms.dit.asia/api/sendhttp.php?" +

                       "authkey=" + key +
                       "&mobiles=" + msgRecepient +
                       "&message=" + System.Web.HttpUtility.UrlEncode(msgText, Encoding.GetEncoding("ISO-8859-1")) +
                       "&sender=" + senderid +
                       "&route=" + route +
                       "&country=" + country;



                    client.OpenRead(baseURL);
                    //MessageBox.Show("Successfully sent message");
                    //Page.Response.Redirect(Page.Request.RawUrl.ToString(), true);

                   

                }

                
            }

        }
        System.Web.UI.ScriptManager.RegisterStartupScript(this, GetType(), "displayalertmessage", "alert('Offer Message has been Sent Successfully!!!');", true);

    }
}