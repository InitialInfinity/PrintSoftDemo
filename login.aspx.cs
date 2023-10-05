using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using System.Net;
using System.Text;

public partial class login : System.Web.UI.Page
{
    SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["String"].ConnectionString);
    string otp = "";
    string phone;
    string key, country, senderid, route;
    int feotp;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack==true)
        {
            //DateTime date = DateTime.Now.AddYears(1);

            SqlCommand cmd = new SqlCommand("select * from tbl_company_details", conn);
            DataTable dt = new DataTable();
            SqlDataAdapter adapt = new SqlDataAdapter(cmd);
             adapt.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                Panel1.Visible = true;
                Panel2.Visible = false;

                SqlCommand cmd2 = new SqlCommand("select * from tbl_feature", conn);
                SqlDataAdapter adapt2 = new SqlDataAdapter(cmd2);
                DataTable dt2 = new DataTable();
                adapt2.Fill(dt2);
                if (dt2.Rows.Count > 0)
                {
                    feotp = Convert.ToInt32(dt2.Rows[0]["fe_otp"]);
                    if (feotp == 1)
                    {
                       
                        Btn_sign_in.Visible = true;
                        Btn_sign_in2.Visible = false;
                    }
                    else
                    {

                        Btn_sign_in.Visible = false;
                        Btn_sign_in2.Visible = true;
                    }
                }
                else
                {

                }
            }
            else
            {
                Response.Redirect("register.aspx");

            }
        }
    }

    protected void Btn_sign_in_Click(object sender, EventArgs e)
    {
        try
        {
            string email = Txt_email.Text;
            string password = Txt_password.Text;


            SqlCommand cmd = new SqlCommand("select * from tbl_admin_login where a_email='" + email + "' and a_password='" + password + "'", conn);
            DataTable dt = new DataTable();
            SqlDataAdapter adapt = new SqlDataAdapter(cmd);
            adapt.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                try
                {
                    SqlCommand cmd3 = new SqlCommand("select * from tbl_company_details", conn);
                    DataTable dt3 = new DataTable();
                    SqlDataAdapter adapt3 = new SqlDataAdapter(cmd3);
                    adapt3.Fill(dt3);
                    if (dt3.Rows.Count > 0)
                    {
                        phone = dt3.Rows[0]["com_otpno"].ToString();
                    }
                    string num = "0123456789";
                    int len = num.Length;

                    int otpdigit = 5;
                    int getindex;
                    string finaldigit;
                    for (int i = 0; i < otpdigit; i++)
                    {
                        do
                        {
                            getindex = new Random().Next(0, len);
                            finaldigit = num.ToCharArray()[getindex].ToString();
                        } while (otp.IndexOf(finaldigit) != -1);
                        otp += finaldigit;
                    }
                    Session["otp"] = otp;

                    WebClient client = new WebClient();
                    string msgRecepient = phone.ToString();
                    string msgText = "Your OTP is " + otp + ".";

                    string baseURL = "http://dndsms.dit.asia/api/sendhttp.php?" +

                       "authkey=" + key +
                       "&mobiles=" + msgRecepient +
                       "&message=" + System.Web.HttpUtility.UrlEncode(msgText, Encoding.GetEncoding("ISO-8859-1")) +
                       "&sender=" + senderid +
                       "&route=" + route +
                       "&country=" + country;

                    client.OpenRead(baseURL);


                    Panel1.Visible = false;
                    Panel2.Visible = true;
                }
                catch(Exception ex)
                {

                }
            }
            else
            {
                SqlCommand cmd2 = new SqlCommand("select * from tbl_admin_user where au_email='" + email + "' and au_password='" + password + "'", conn);
                DataTable dt2 = new DataTable();
                SqlDataAdapter adapt2 = new SqlDataAdapter(cmd2);
                adapt2.Fill(dt2);
                if (dt2.Rows.Count > 0)
                {
                    try
                    {
                        SqlCommand cmd3 = new SqlCommand("select * from tbl_company_details", conn);
                        DataTable dt3 = new DataTable();
                        SqlDataAdapter adapt3 = new SqlDataAdapter(cmd3);
                        adapt3.Fill(dt3);
                        if (dt3.Rows.Count > 0)
                        {
                            phone = dt3.Rows[0]["com_otpno"].ToString();
                        }
                        string num = "0123456789";
                        int len = num.Length;

                        int otpdigit = 5;
                        int getindex;
                        string finaldigit;
                        for (int i = 0; i < otpdigit; i++)
                        {
                            do
                            {
                                getindex = new Random().Next(0, len);
                                finaldigit = num.ToCharArray()[getindex].ToString();
                            } while (otp.IndexOf(finaldigit) != -1);
                            otp += finaldigit;
                        }
                        Session["otp"] = otp;

                        WebClient client = new WebClient();
                        string msgRecepient = phone.ToString();
                        string msgText = "Your OTP is " + otp + ".";

                        string baseURL = "http://dndsms.dit.asia/api/sendhttp.php?" +

                           "authkey=" + key +
                           "&mobiles=" + msgRecepient +
                           "&message=" + System.Web.HttpUtility.UrlEncode(msgText, Encoding.GetEncoding("ISO-8859-1")) +
                           "&sender=" + senderid +
                           "&route=" + route +
                           "&country=" + country;

                        client.OpenRead(baseURL);


                        Panel1.Visible = false;
                        Panel2.Visible = true;
                    }
                    catch (Exception ex)
                    {

                    }
                }
                else
                {
                    Lbl_message.Text = "Invalid Email and Password!!!";
                }

            }
        }
        catch(Exception ex)
        {
            Response.Write(ex.Message.ToString());
        }
        finally
        {
            if (conn.State != ConnectionState.Closed)
            {
                conn.Close();
            }
        }
    }
    protected void Btn_sign_in2_Click(object sender, EventArgs e)
    {
        try
        {
            string email = Txt_email.Text;
            string password = Txt_password.Text;


            SqlCommand cmd = new SqlCommand("select * from tbl_admin_login where a_email='" + email + "' and a_password='" + password + "'", conn);
            DataTable dt = new DataTable();
            SqlDataAdapter adapt = new SqlDataAdapter(cmd);
            adapt.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                Session["a_email"] = Txt_email.Text;
                Response.Redirect("Default.aspx");
            }
            else
            {
                SqlCommand cmd2 = new SqlCommand("select * from tbl_admin_user where au_email='" + email + "' and au_password='" + password + "'", conn);
                DataTable dt2 = new DataTable();
                SqlDataAdapter adapt2 = new SqlDataAdapter(cmd2);
                adapt2.Fill(dt2);
                if (dt2.Rows.Count > 0)
                {
                    Session["a_email"] = Txt_email.Text;
                    Response.Redirect("Default.aspx");
                }
                else
                {
                    Lbl_message.Text = "Invalid Email and Password!!!";
                }

            }
        }
        catch (Exception ex)
        {
            Response.Write(ex.Message.ToString());
        }
        finally
        {
            if (conn.State != ConnectionState.Closed)
            {
                conn.Close();
            }
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        try
        {
            string otp2 = Session["otp"].ToString();
            if (Txt_otp.Text == otp2)
            {
                Session["a_email"] = Txt_email.Text;
                Response.Redirect("Default.aspx");
            }
            else
            {
                lbl_msg.Text = "Invalid OTP !!!";
            }
        }
        catch (Exception ex)
        {

        }
    }
}