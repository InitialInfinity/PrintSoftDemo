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

public partial class admin_panel_Settings_general_settings : System.Web.UI.Page
{
    SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["String"].ConnectionString);
    int sms, mail,del_inv, feotp;
    string admin_email;
    string key, country, senderid, route;
    string otp = string.Empty;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["a_email"] != null || Session["admin_email"] != null)
        {

            SqlCommand cmd5 = new SqlCommand("select * from tbl_admin_login", conn);
            SqlDataAdapter adapt5 = new SqlDataAdapter(cmd5);
            DataTable dt5 = new DataTable();
            adapt5.Fill(dt5);
            if (dt5.Rows.Count > 0)
            {
                admin_email = dt5.Rows[0]["a_email"].ToString();
            }
            if (admin_email.ToString() == Session["a_email"].ToString() || Session["admin_email"] != null)
            {
                if (!IsPostBack)
            {
               
                SqlCommand cmd2 = new SqlCommand("select * from tbl_sms_config", conn);
                SqlDataAdapter adapt2 = new SqlDataAdapter(cmd2);
                DataTable dt2 = new DataTable();
                adapt2.Fill(dt2);
                if (dt2.Rows.Count > 0)
                {
                    Txt_authentication_Key.Text = dt2.Rows[0]["sc_key"].ToString();
                    Txt_country.Text = dt2.Rows[0]["sc_country"].ToString();
                    Txt_sender_id.Text = dt2.Rows[0]["sc_sender"].ToString();
                    Txt_route.Text = dt2.Rows[0]["sc_route"].ToString();
                        
                }

                SqlCommand cmd3 = new SqlCommand("select * from tbl_email_config", conn);
                SqlDataAdapter adapt3 = new SqlDataAdapter(cmd3);
                DataTable dt3 = new DataTable();
                adapt3.Fill(dt3);
                if (dt3.Rows.Count > 0)
                {
                    Txt_email.Text = dt3.Rows[0]["ec_email"].ToString();
                    Txt_password.Text = dt3.Rows[0]["ec_password"].ToString();
                    Txt_port.Text = dt3.Rows[0]["ec_port"].ToString();
                    Txt_subject.Text = dt3.Rows[0]["ec_subject"].ToString();
                    Txt_smtp.Text = dt3.Rows[0]["ec_smtp"].ToString();

                }

                SqlCommand cmd4 = new SqlCommand("select * from tbl_feature", conn);
                SqlDataAdapter adapt4 = new SqlDataAdapter(cmd4);
                DataTable dt4 = new DataTable();
                adapt4.Fill(dt4);
                if (dt4.Rows.Count > 0)
                {
                     sms = Convert.ToInt32(dt4.Rows[0]["fe_sms"]);
                    mail = Convert.ToInt32(dt4.Rows[0]["fe_mail"]);
                    del_inv = Convert.ToInt32(dt4.Rows[0]["fe_del"]);
                    feotp = Convert.ToInt32(dt4.Rows[0]["fe_otp"]);

                        if (sms == 1)
                    {
                        CheckBox1.Checked = true;
                    }
                    else
                    {
                        CheckBox1.Checked = false;
                    }
                    //if (mail == 1)
                    //{
                    //    CheckBox2.Checked = true;
                    //}
                    //else
                    //{
                    //    CheckBox2.Checked = false;
                    //}
                    if (del_inv == 1)
                    {
                        CheckBox3.Checked = true;
                    }
                    else
                    {
                        CheckBox3.Checked = false;
                    }
                        if (feotp == 1)
                        {
                            CheckBox4.Checked = true;
                        }
                        else
                        {
                            CheckBox4.Checked = false;
                        }


                    }

                    SqlCommand cmd6 = new SqlCommand("select * from tbl_company_details where com_id=1", conn);
                    SqlDataAdapter adapt6 = new SqlDataAdapter(cmd6);
                    DataTable dt6 = new DataTable();
                    adapt6.Fill(dt6);
                    if (dt6.Rows.Count > 0)
                    {
                        Txt_note.Text = dt6.Rows[0]["com_note"].ToString();
                        Txt_otpno.Text = dt6.Rows[0]["com_otpno"].ToString();

                    }
                    

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
        try
        {
            SqlCommand cmd = new SqlCommand("UPDATE tbl_sms_config SET sc_key='" + Txt_authentication_Key.Text.Trim() + "',sc_country='" + Txt_country.Text.Trim() + "',sc_sender='" + Txt_sender_id.Text.Trim() + "',sc_route='" + Txt_route.Text.Trim() + "' ", conn);

            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
            //Lbl_message.Text = "" + Txt_customer_name.Text + " Added Successfully!!!";
            // Page.Response.Redirect(Page.Request.RawUrl.ToString(), true);
            string redirectScript = " window.location.href = 'general_settings.aspx';";
            System.Web.UI.ScriptManager.RegisterStartupScript(this, GetType(), "displayalertmessage", "alert('SMS Configuration Updated Successfully!!!');" + redirectScript, true);
        }
        catch (Exception ex)
        {

        }
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        try
        {
            SqlCommand cmd = new SqlCommand("UPDATE tbl_email_config SET ec_email='" + Txt_email.Text.Trim() + "',ec_password='" + Txt_password.Text.Trim() + "',ec_port='" + Txt_port.Text.Trim() + "',ec_subject='" + Txt_subject.Text.Trim() + "',ec_smtp='" + Txt_smtp.Text.Trim() + "' ", conn);

            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
            //Lbl_message.Text = "" + Txt_customer_name.Text + " Added Successfully!!!";
            // Page.Response.Redirect(Page.Request.RawUrl.ToString(), true);
            string redirectScript = " window.location.href = 'general_settings.aspx';";
            System.Web.UI.ScriptManager.RegisterStartupScript(this, GetType(), "displayalertmessage", "alert('Mail Configuration Updated Successfully!!!');" + redirectScript, true);
        }
        catch (Exception ex)
        {

        }
    }

    protected void CheckBox1_CheckedChanged(object sender, EventArgs e)
    {
        try
        {
            if (CheckBox1.Checked)
            {
                SqlCommand cmd = new SqlCommand("UPDATE tbl_feature SET fe_sms=1", conn);

                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
            }
            if(!CheckBox1.Checked)
            {
                SqlCommand cmd = new SqlCommand("UPDATE tbl_feature SET fe_sms=0", conn);

                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();

            }
         }
        catch (Exception ex)
        {

        }
    }

    protected void CheckBox2_CheckedChanged(object sender, EventArgs e)
    {

        try
        {
            //if (CheckBox2.Checked)
            //{
            //    SqlCommand cmd = new SqlCommand("UPDATE tbl_feature SET fe_mail=1", conn);

            //    conn.Open();
            //    cmd.ExecuteNonQuery();
            //    conn.Close();
            //}
            //if (!CheckBox2.Checked)
            //{
            //    SqlCommand cmd = new SqlCommand("UPDATE tbl_feature SET fe_mail=0", conn);

            //    conn.Open();
            //    cmd.ExecuteNonQuery();
            //    conn.Close();

            //}
        }
        catch (Exception ex)
        {

        }
    }

    protected void CheckBox3_CheckedChanged(object sender, EventArgs e)
    {

        try
        {
            if (CheckBox3.Checked)
            {
                SqlCommand cmd = new SqlCommand("UPDATE tbl_feature SET fe_del=1", conn);

                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
            }
            if (!CheckBox3.Checked)
            {
                SqlCommand cmd = new SqlCommand("UPDATE tbl_feature SET fe_del=0", conn);

                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();

            }
        }
        catch (Exception ex)
        {

        }
    }
    protected void CheckBox4_CheckedChanged(object sender, EventArgs e)
    {

        try
        {
            if (CheckBox4.Checked)
            {
                SqlCommand cmd2 = new SqlCommand("select * from tbl_company_details where com_id=1", conn);
                SqlDataAdapter adapt2 = new SqlDataAdapter(cmd2);
                DataTable dt2 = new DataTable();
                adapt2.Fill(dt2);
                if (dt2.Rows.Count > 0)
                {
                   if( dt2.Rows[0]["com_otpno"].ToString()!="")
                    {
                        SqlCommand cmd = new SqlCommand("UPDATE tbl_feature SET fe_otp=1", conn);
                        conn.Open();
                        cmd.ExecuteNonQuery();
                        conn.Close();
                    }
                    else
                    {

                    }

                }
               
            }
            if (!CheckBox4.Checked)
            {
                SqlCommand cmd = new SqlCommand("UPDATE tbl_feature SET fe_otp=0", conn);

                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();

            }
        }
        catch (Exception ex)
        {

        }
    }

    protected void Button3_Click(object sender, EventArgs e)
    {
        try
        {
            SqlCommand cmd = new SqlCommand("UPDATE tbl_company_details SET com_note=@com_note where com_id=1 ", conn);
            cmd.Parameters.AddWithValue("@com_note", Txt_note.Text.ToString());
            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
            string redirectScript = " window.location.href = 'general_settings.aspx';";
            System.Web.UI.ScriptManager.RegisterStartupScript(this, GetType(), "displayalertmessage", "alert('Note Updated Successfully!!!');" + redirectScript, true);
        }
        catch (Exception ex)
        {

        }
    }
    protected void Button5_Click(object sender, EventArgs e)
    {
        try
        {
            if (lbl_otp.Value != "")
            {
                if (lbl_otp.Value == Txt_entotp.Text)
                {
                    SqlCommand cmd = new SqlCommand("UPDATE tbl_company_details SET com_otpno=@com_otpno where com_id=1 ", conn);
                    cmd.Parameters.AddWithValue("@com_otpno", Txt_otpno.Text.ToString());
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();
                    string redirectScript = " window.location.href = 'general_settings.aspx';";
                    System.Web.UI.ScriptManager.RegisterStartupScript(this, GetType(), "displayalertmessage", "alert('OTP Contact no. Updated Successfully!!!');" + redirectScript, true);

                }
                else
                {
                    lbl_alert.Text = "OTP is not Correct !!!";
                }
            }
        }
        catch (Exception ex)
        {

        }
    }
    protected void Button7_Click(object sender, EventArgs e)
    {
        key = Txt_authentication_Key.Text;
        country = Txt_country.Text;
        senderid = Txt_sender_id.Text;
        route = Txt_route.Text;

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
        lbl_otp.Value = otp;
        decimal mob = Convert.ToDecimal(Txt_otpno.Text);
        WebClient client = new WebClient();
        string to;
        string msgRecepient = mob.ToString();
        string msgText = "Your OTP is " + otp + ".";

        to = mob.ToString();
        string baseURL = "http://dndsms.dit.asia/api/sendhttp.php?" +

           "authkey=" + key +
           "&mobiles=" + msgRecepient +
           "&message=" + System.Web.HttpUtility.UrlEncode(msgText, Encoding.GetEncoding("ISO-8859-1")) +
           "&sender=" + senderid +
           "&route=" + route +
           "&country=" + country;

        client.OpenRead(baseURL);
    }
}