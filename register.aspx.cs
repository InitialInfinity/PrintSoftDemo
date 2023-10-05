using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using System.Windows.Forms;

public partial class register : System.Web.UI.Page
{
    SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["String"].ConnectionString);
   // SqlConnection Lacewingconn = new SqlConnection(ConfigurationManager.ConnectionStrings["LacewingString"].ConnectionString);
    SqlCommand cmd2, cmd3, cmd4, cmd5;
    SqlDataAdapter adapt2, adapt3, adapt4, adapt5;
    DataTable dt1, dt2, dt3, dt4, dt5;
    protected void Page_Load(object sender, EventArgs e)
    {
        Panel1.Visible = false;
        clientid();
    }

    public void clientid()
    {

       
//     try
//        {
//            conn.Open();

//            SqlCommand cmd = new SqlCommand("SELECT TOP 1 client_id FROM Tbl_Client_Register ORDER BY client_id DESC", Lacewingconn);
//    string inv;
//    int i = 0;
//    SqlDataAdapter adapt = new SqlDataAdapter(cmd);
//    DataTable dt = new DataTable();

//    adapt.Fill(dt);

//            if (dt.Rows.Count > 0)
//            {
//                inv = dt.Rows[0]["client_id"].ToString();

//}
//            else
//            {
//                inv = "0";
//            }


//            string letters = string.Empty;
//string numbers = string.Empty;

//            foreach (char c in inv)
//            {
//                if (Char.IsNumber(c))
//                {
//                    numbers += c;
//                }
//            }
//            i = Convert.ToInt32(numbers);
//            if (i > 0)
//            {
//                int j = i + 1;
//lbl_id.Text = "" + j.ToString();

//            }

//            else
//            {
//                lbl_id.Text = "1";
//            }

//        }

//        catch (Exception ex)
//        {
//            Response.Write(ex.Message.ToString());
//        }
//        finally
//        {
//            conn.Close();
//        }

    }

    protected void Btn_sign_in_Click(object sender, EventArgs e)
    {
        try
        {
            cmd2 = new SqlCommand("Select * from tbl_admin_login where a_email='" + Txt_email.Text.Trim() + "'", conn);
            adapt2 = new SqlDataAdapter(cmd2);
            dt2 = new DataTable();
            adapt2.Fill(dt2);

            if (dt2.Rows.Count > 0)
            {
                Lbl_message.Text = "" + Txt_email.Text + " Already Exist!!!";
            }
            else
            {


                SqlCommand cmd3 = new SqlCommand("insert into tbl_company_details values(@com_company_name,@com_company_name2,@com_owner_name,@com_address,@com_contact,@com_gst_no,@com_email,@com_website,@com_company_logo,@com_bank_name,@com_branch,@com_acc_no,@com_ifsc,@com_company_logo2,@com_note,@com_otpno,@com_created_date,@client_id)", conn);

                cmd3.Parameters.AddWithValue("@com_company_name", Txt_company_name.Text);
                cmd3.Parameters.AddWithValue("@com_company_name2", Txt_company_name.Text);
                cmd3.Parameters.AddWithValue("@com_owner_name", Txt_owner_name.Text);
                cmd3.Parameters.AddWithValue("@com_address", Txt_address.Text);
                cmd3.Parameters.AddWithValue("@com_contact", Txt_contact.Text);
                cmd3.Parameters.AddWithValue("@com_gst_no", Txt_gst.Text);
                cmd3.Parameters.AddWithValue("@com_email", Txt_email.Text);
                cmd3.Parameters.AddWithValue("@com_website", Txt_website.Text);
                cmd3.Parameters.AddWithValue("@com_company_logo", "download.png");
                cmd3.Parameters.AddWithValue("@com_bank_name", "");
                cmd3.Parameters.AddWithValue("@com_branch", "");
                cmd3.Parameters.AddWithValue("@com_acc_no", "");
                cmd3.Parameters.AddWithValue("@com_ifsc", "");
                cmd3.Parameters.AddWithValue("@com_company_logo2", "download.png");
                cmd3.Parameters.AddWithValue("@com_note", "");
                cmd3.Parameters.AddWithValue("@com_otpno", "");
                cmd3.Parameters.AddWithValue("@com_created_date", Convert.ToDateTime(DateTime.Now.ToShortDateString()).ToString("MM/dd/yyyy"));
                cmd3.Parameters.AddWithValue("@client_id", lbl_id.Text);
                conn.Open();
                cmd3.ExecuteNonQuery();
                conn.Close();

                SqlCommand cmd = new SqlCommand("insert into tbl_admin_login values(@a_email,@a_password)", conn);

                cmd.Parameters.AddWithValue("@a_email", Txt_email.Text);
                cmd.Parameters.AddWithValue("@a_password", Txt_password.Text);
               // cmd.Parameters.AddWithValue("@com_created_date", Convert.ToDateTime(DateTime.Now.ToShortDateString()).ToString("MM/dd/yyyy"));
                //cmd.Parameters.AddWithValue("@client_id", lbl_id.Text);
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();

                //query dal yaha pe 
                   //SqlCommand cmd33 = new SqlCommand("insert into Tbl_Client_Register values(@client_company_name,@client_company_name2,@client_owner_name,@client_address,@client_contact,@client_gst_no,@client_email,@client_website,@client_software_type,@client_reg_date,@client_expiry_date,@client_access_date,@client_soft_status,@client_renewal_amt,@client_invoice_amt,@client_invoice_no,@client_password,@client_username,@client_advance,@client_balance)", Lacewingconn);
    //cmd33.Parameters.AddWithValue("@client_company_name", Txt_company_name.Text);
    //            cmd33.Parameters.AddWithValue("@client_company_name2", Txt_company_name.Text);
    //            cmd33.Parameters.AddWithValue("@client_owner_name", Txt_owner_name.Text);
    //            cmd33.Parameters.AddWithValue("@client_address", Txt_address.Text);
    //            cmd33.Parameters.AddWithValue("@client_contact", Txt_contact.Text);
    //            cmd33.Parameters.AddWithValue("@client_gst_no", Txt_gst.Text);
    //            cmd33.Parameters.AddWithValue("@client_email", Txt_email.Text);
    //            cmd33.Parameters.AddWithValue("@client_website", Txt_website.Text);
    //            cmd33.Parameters.AddWithValue("@client_software_type", "Flex Billing Software");
    //            cmd33.Parameters.AddWithValue("@client_reg_date", Convert.ToDateTime(DateTime.Now.ToShortDateString()).ToString("MM/dd/yyyy"));
    //            cmd33.Parameters.AddWithValue("@client_expiry_date", Convert.ToDateTime(DateTime.Now.AddYears(1)).ToString("MM/dd/yyyy"));
    //            cmd33.Parameters.AddWithValue("@client_access_date", Convert.ToDateTime(DateTime.Now.ToShortDateString()).ToString("MM/dd/yyyy"));
    //            cmd33.Parameters.AddWithValue("@client_soft_status", "True");
    //            cmd33.Parameters.AddWithValue("@client_renewal_amt", "");
    //            cmd33.Parameters.AddWithValue("@client_invoice_amt", "");
    //            cmd33.Parameters.AddWithValue("@client_invoice_no", "");
    //            cmd33.Parameters.AddWithValue("@client_password", Txt_password.Text);
    //            cmd33.Parameters.AddWithValue("@client_username", Txt_email.Text);
    //            cmd33.Parameters.AddWithValue("@client_advance", 0);
    //            cmd33.Parameters.AddWithValue("@client_balance", 0);

    //            Lacewingconn.Open();
    //            cmd33.ExecuteNonQuery();
    //            Lacewingconn.Close();

                SqlCommand cmd4 = new SqlCommand("insert into tbl_email_config values(@ec_id,@ec_email,@ec_password,@ec_port,@ec_subject,@ec_smtp)", conn);

                cmd4.Parameters.AddWithValue("@ec_id", 1);
                cmd4.Parameters.AddWithValue("@ec_email", "Not Set");
                cmd4.Parameters.AddWithValue("@ec_password", "Not Set");
                cmd4.Parameters.AddWithValue("@ec_port", "Not Set");
                cmd4.Parameters.AddWithValue("@ec_subject", "Not Set");
                cmd4.Parameters.AddWithValue("@ec_smtp", "Not Set");
                conn.Open();
                cmd4.ExecuteNonQuery();
                conn.Close();

                SqlCommand cmd5 = new SqlCommand("insert into tbl_feature values(@fe_id,@fe_sms,@fe_mail,@fe_del,@fe_otp)", conn);

                cmd5.Parameters.AddWithValue("@fe_id", 1);
                cmd5.Parameters.AddWithValue("@fe_sms", 0);
                cmd5.Parameters.AddWithValue("@fe_mail", 0);
                cmd5.Parameters.AddWithValue("@fe_del", 1);
                cmd5.Parameters.AddWithValue("@fe_otp", 0);
                conn.Open();
                cmd5.ExecuteNonQuery();
                conn.Close();

                SqlCommand cmd6 = new SqlCommand("insert into tbl_sms_config values(@sc_id,@sc_key,@sc_country,@sc_sender,@sc_route)", conn);

                cmd6.Parameters.AddWithValue("@sc_id", 1);
                cmd6.Parameters.AddWithValue("@sc_key", "Not Set");
                cmd6.Parameters.AddWithValue("@sc_country", 91);
                cmd6.Parameters.AddWithValue("@sc_sender", "Not Set");
                cmd6.Parameters.AddWithValue("@sc_route", "Not Set");
                conn.Open();
                cmd6.ExecuteNonQuery();
                conn.Close();

                Session["a_email"] = Txt_email.Text;
                Response.Redirect("Default.aspx");

            }



        }
        catch (Exception ex)
        {

        }
        finally
        {
            if (conn.State != ConnectionState.Closed)
            {
                conn.Close();
            }

        }

    }
}