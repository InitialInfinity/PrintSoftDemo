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
using System.Net.Mail;
using System.IO;

public partial class Sale_wgst_bill : System.Web.UI.Page
{
    SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["String"].ConnectionString);
    string invoice;
    string otp = string.Empty;
    string filename1, key, country, senderid, route, email, password, port, subject, smtp;
    string bill_update;
    protected void Page_Load(object sender, EventArgs e)
    {

        if (Session["a_email"] != null)
        {
            try
            {
                bill_update = (Request.QueryString["bill_update"]??"").ToString();
                if (bill_update == "success")
                {
                    Panel3.Visible = true;
                }

            }
            catch (Exception ex)
            {
                Panel3.Visible = false;
            }

            Panel8.Visible = true;
            Panel7.Visible = true;
            Panel6.Visible = true;
            Panel5.Visible = true;
            Panel4.Visible = true;
            Panel2.Visible = false;
            invoice = Request.QueryString["invoice"].ToString();
            if (Page.IsPostBack) return;
            fill();
            FillRepeater();
            fillsign();
        }
        else
        {
            Response.Redirect("../login.aspx");
        }
    }
    protected void payment(object sender, EventArgs e)
    {
        
		
			if (lbl_balance.Text != "0")
			{
			Response.Redirect("invoice_payment.aspx?invoice=" + invoice.ToString());

		}
			else
			{

				System.Web.UI.ScriptManager.RegisterStartupScript(this, GetType(), "displayalertmessage", "alert('Payment is alredy done!!!');", true);
			}

		

	}
    protected void print2(object sender, EventArgs e)
    {
        Response.Redirect("wgst_bill2.aspx?invoice=" + invoice.ToString());

    }
    //protected void print3(object sender, EventArgs e)
    //{
    //    Response.Redirect("wgst_bill3.aspx?invoice=" + invoice.ToString());

    //}
    protected void print4(object sender, EventArgs e)
    {
        Response.Redirect("wgst_bill5.aspx?invoice=" + invoice.ToString());
    }

    public void fillsign()
    {
        SqlCommand cmd1 = new SqlCommand("select * from tbl_company_details", conn);
        SqlDataAdapter adapt1 = new SqlDataAdapter(cmd1);
        DataTable dt1 = new DataTable();
        adapt1.Fill(dt1);
        if (dt1.Rows.Count > 0)
        {
            lbl_sign.Text = dt1.Rows[0]["com_company_name"].ToString();
        }
    }
    public void fill()
    {
        SqlCommand cmd = new SqlCommand("select * from tbl_estimate_details inner join tbl_customer on tbl_estimate_details.c_id=tbl_customer.c_id where es_invoice_no ='" + invoice + "'", conn);
        SqlDataAdapter adapt = new SqlDataAdapter(cmd);
        DataTable dt = new DataTable();
        adapt.Fill(dt);
        if (dt.Rows.Count > 0)
        {
            Repeater2.DataSource = dt;
            Repeater2.DataBind();

            lbl_invoice_no.Text = dt.Rows[0]["es_invoice_no"].ToString();
           
            lbl_customer_name.Text = dt.Rows[0]["c_name"].ToString();
            lbl_customer_contact.Text = dt.Rows[0]["c_contact"].ToString();
            lbl_customer_address.Text = dt.Rows[0]["c_address"].ToString();
         //   lbl_gst_no.Text = dt.Rows[0]["c_gst_no"].ToString();
            lbl_email.Text = dt.Rows[0]["c_email"].ToString();
            lbl_order_no.Text = dt.Rows[0]["es_order_no"].ToString();
            lbl_invoice_date.Text = Convert.ToDateTime(dt.Rows[0]["es_invoice_date"]).ToString("dd/MM/yyyy");
            lbl_due_date.Text = Convert.ToDateTime(dt.Rows[0]["es_due_date"]).ToString("dd/MM/yyyy");

            //lbl_discount.Text = dt.Rows[0]["es_discount"].ToString();

            lbl_subtotal.Text = dt.Rows[0]["es_sub_total"].ToString();

            lbl_shipping.Text = dt.Rows[0]["es_shipping_charges"].ToString();
            //lbl_adjustment.Text = dt.Rows[0]["es_adjustment"].ToString();
            lbl_total.Text = dt.Rows[0]["es_total"].ToString();
            lbl_word.Text = ConvertNumbertoWords(Convert.ToInt64(dt.Rows[0]["es_total"]));
            lbl_balance.Text = dt.Rows[0]["es_balance"].ToString();

            lbl_design.Text = dt.Rows[0]["es_dtp_charges"].ToString();
            lbl_fitting.Text = dt.Rows[0]["es_fitting_charges"].ToString();
            lbl_pasting.Text = dt.Rows[0]["es_pasting_charges"].ToString();
            lbl_payment_method.Text = dt.Rows[0]["es_payment_method"].ToString();
            lbl_order_ref.Text = dt.Rows[0]["es_order_ref"].ToString();
            lbl_framing.Text = dt.Rows[0]["es_framing_charges"].ToString();
            lbl_install.Text = dt.Rows[0]["es_installation_charges"].ToString();
            

            if (Convert.ToDecimal(dt.Rows[0]["es_balance"]) == Convert.ToDecimal(dt.Rows[0]["es_total"]))
            {
                lbl_status.CssClass = "label label-danger";
                lbl_status.Text = "Un-Paid";
                Pnl_Cash_Credit.Visible = true;
                Pnl_Cash_Memo.Visible = false;

            }
            if (Convert.ToDecimal(dt.Rows[0]["es_total"]) > Convert.ToDecimal(dt.Rows[0]["es_balance"]))
            {
                if (Convert.ToDecimal(dt.Rows[0]["es_balance"]) > 0)
                {
                    lbl_status.CssClass = "label label-warning";
                    lbl_status.Text = "Partially Paid";
                    Pnl_Cash_Credit.Visible = true;
                    Pnl_Cash_Memo.Visible = false;
                }
            }
            if (Convert.ToDecimal(dt.Rows[0]["es_balance"]) <= 0)
            {
                lbl_status.CssClass = "label label-success";
                lbl_status.Text = "Paid";

                Pnl_Cash_Credit.Visible = false;
                Pnl_Cash_Memo.Visible = true;

            }


            if (lbl_framing.Text == "0")
            {
                Panel6.Visible = false;
            }

            if (lbl_design.Text == "0")
            {
                Panel4.Visible = false;
            }

            if (lbl_install.Text == "0")
            {
                Panel5.Visible = false;
            }

            if (lbl_fitting.Text == "0")
            {
                Panel8.Visible = false;
            }

            if (lbl_pasting.Text == "0")
            {
                Panel7.Visible = false;
            }


        }

        SqlCommand cmd3 = new SqlCommand("select sum(si_pay) from tbl_sale_invoice_payment where si_invoice ='" + invoice + "'", conn);
        SqlDataAdapter adapt3 = new SqlDataAdapter(cmd3);
        DataTable dt3 = new DataTable();
        adapt3.Fill(dt3);
        if (dt3.Rows.Count > 0)
        {
            lbl_adjustment.Text = dt3.Rows[0][0].ToString();
        }

        SqlCommand cmd33 = new SqlCommand("select sum(si_discount) from tbl_sale_invoice_payment where si_invoice ='" + invoice + "'", conn);
        SqlDataAdapter adapt33 = new SqlDataAdapter(cmd33);
        DataTable dt33 = new DataTable();
        adapt33.Fill(dt33);
        if (dt33.Rows.Count > 0)
        {
            lbl_discount.Text = dt33.Rows[0][0].ToString();
        }

        SqlCommand cmd2 = new SqlCommand("select * from tbl_company_details where com_id = 1", conn);
        SqlDataAdapter adapt2 = new SqlDataAdapter(cmd2);
        DataTable dt2 = new DataTable();
        adapt2.Fill(dt2);
        if (dt2.Rows.Count > 0)
        {
            lbl_company_name.Text = dt2.Rows[0]["com_company_name2"].ToString();
            lbl_company_address.Text = dt2.Rows[0]["com_address"].ToString();
            lbl_company_contact.Text = dt2.Rows[0]["com_contact"].ToString();
            lbl_company_email.Text = dt2.Rows[0]["com_email"].ToString();
         //   lbl_company_gst.Text = dt2.Rows[0]["com_gst_no"].ToString();
            Image1.ImageUrl = "~/Company/Company_Photos/" + dt2.Rows[0]["com_company_logo2"].ToString();
            lbl_bank_name.Text = dt2.Rows[0]["com_bank_name"].ToString();
            lbl_branch.Text = dt2.Rows[0]["com_branch"].ToString();
            lbl_ac.Text = dt2.Rows[0]["com_acc_no"].ToString();
            lbl_ifsc.Text = dt2.Rows[0]["com_ifsc"].ToString();
            lbl_note.Text = dt2.Rows[0]["com_note"].ToString();
            lbl_upino.Text = dt2.Rows[0]["com_upino"].ToString();
        }
    }

    protected void btn_sms_Click(object sender, EventArgs e)
    {
        try
        {
            SqlCommand cmd = new SqlCommand("select * from tbl_sms_config ", conn);
            SqlDataAdapter adapt = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapt.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                key = dt.Rows[0]["sc_key"].ToString();
                country = dt.Rows[0]["sc_country"].ToString();

                senderid = dt.Rows[0]["sc_sender"].ToString();
                route = dt.Rows[0]["sc_route"].ToString();

            }

            decimal mob = Convert.ToDecimal(lbl_customer_contact.Text);
            WebClient client = new WebClient();
            string to;
            Int64 temp_id = 1234567890123456789;
            string msgRecepient = mob.ToString();
            string msgText = "Welcome to " + lbl_company_name.Text + ", We have not received payment for invoice " + invoice + ". Your Due Amount is " + lbl_balance.Text.ToString() + ".";

            to = mob.ToString();

            string baseURL = "http://sms.hitechsms.com/app/smsapi/index.php?" +

                "key=" + key +
                               "&campaign=" + "0" +
                               "&routeid=" + route +
                               "&type=" + "text" +
                               "&contacts=" + msgRecepient +
                               "&senderid=" + senderid +
                               "&msg=" + System.Web.HttpUtility.UrlEncode(msgText, Encoding.GetEncoding("ISO-8859-1")) +
                               "&template_id=" + temp_id;

            StringBuilder sbPostData = new StringBuilder();
            sbPostData.AppendFormat("key={0}", key);
            sbPostData.AppendFormat("&campaign={0}", "0");
            sbPostData.AppendFormat("&routeid={0}", route);
            sbPostData.AppendFormat("&type={0}", "text");
            sbPostData.AppendFormat("&contacts={0}", msgRecepient);
            sbPostData.AppendFormat("&senderid={0}", senderid);
            sbPostData.AppendFormat("&msg={0}", System.Web.HttpUtility.UrlEncode(msgText, Encoding.GetEncoding("ISO-8859-1")));
            sbPostData.AppendFormat("&template_id={0}", temp_id);

            //Create HTTPWebrequest
            HttpWebRequest httpWReq = (HttpWebRequest)WebRequest.Create(baseURL);
            //Prepare and Add URL Encoded data
            UTF8Encoding encoding = new UTF8Encoding();
            byte[] data = encoding.GetBytes(sbPostData.ToString());
            //Specify post method
            httpWReq.Method = "POST";
            httpWReq.ContentType = "application/x-www-form-urlencoded";
            httpWReq.ContentLength = data.Length;
            using (Stream stream = httpWReq.GetRequestStream())
            {
                stream.Write(data, 0, data.Length);
            }
            //Get the response
            HttpWebResponse response = (HttpWebResponse)httpWReq.GetResponse();
            StreamReader reader = new StreamReader(response.GetResponseStream());
            string responseString = reader.ReadToEnd();
            //Close the response
            reader.Close();
            response.Close();
            //MessageBox.Show("Successfully sent message");
            System.Web.UI.ScriptManager.RegisterStartupScript(this, GetType(), "displayalertmessage", "alert('Payment Reminder SMS Sent Successfully!!!');", true);


        }
        catch (Exception exp)
        {
            //MessageBox.Show(exp.ToString());
        }
    }
    protected void btn_mail_Click(object sender, EventArgs e)
    {
        try
        {
            SqlCommand cmd = new SqlCommand("select * from tbl_email_config ", conn);
            SqlDataAdapter adapt = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapt.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                email = dt.Rows[0]["ec_email"].ToString();
                password = dt.Rows[0]["ec_password"].ToString();

                port = dt.Rows[0]["ec_port"].ToString();
                subject = dt.Rows[0]["ec_subject"].ToString();
                smtp = dt.Rows[0]["ec_smtp"].ToString();

            }

            MailMessage mail = new MailMessage();
            SmtpClient SmtpServer = new SmtpClient(smtp);

            mail.From = new MailAddress(email);
            mail.To.Add(lbl_email.Text.ToString());
            mail.Subject = subject;
            mail.Body = "Welcome to " + lbl_company_name.Text + ", We have not received payment for invoice " + lbl_invoice_no.Text.ToString() + ". Your Due Amount is " + lbl_balance.Text.ToString() + ".";

            SmtpServer.Port = Convert.ToInt32(port);
            SmtpServer.Credentials = new System.Net.NetworkCredential(email, password);
            SmtpServer.EnableSsl = true;

            SmtpServer.Send(mail);
            System.Web.UI.ScriptManager.RegisterStartupScript(this, GetType(), "displayalertmessage", "alert('Payment Reminder Email Sent Successfully!!!');", true);

        }
        catch (Exception ex)
        {
        }

    }

    protected void Btn_submit_Click(object sender, EventArgs e)
    {

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
        string strname = otp + fu_image.FileName.ToString();


        fu_image.PostedFile.SaveAs(Server.MapPath("../Invoice Images/") + strname);
        SqlCommand cmd = new SqlCommand("insert into tbl_invoice_image values(@im_invoice,@im_desc,@im_image)", conn);
        cmd.Parameters.AddWithValue("@im_invoice", invoice.ToString());
        cmd.Parameters.AddWithValue("@im_desc", Txt_desc.Text.ToString());
        cmd.Parameters.AddWithValue("@im_image", strname.ToString());
        conn.Open();
        cmd.ExecuteNonQuery();

        // Page.Response.Redirect(Page.Request.RawUrl.ToString(), true);
        conn.Close();

        System.Web.UI.ScriptManager.RegisterStartupScript(this, GetType(), "displayalertmessage", "alert('New Image Added to Invoice Successfully!!!');", true);
        Response.Redirect(Request.RawUrl);
    }
    public void FillRepeater()
    {
        SqlCommand cmd = new SqlCommand("Select * From tbl_invoice_image where im_invoice_no='" + invoice + "' Order By im_id desc", conn);
        SqlDataAdapter adapt = new SqlDataAdapter(cmd);
        DataTable dt = new DataTable();
        adapt.Fill(dt);
        if (dt.Rows.Count > 0)
        {
            Panel2.Visible = true;
            Repeater1.DataSource = dt;
            Repeater1.DataBind();
        }
    }
    protected void DeleteAppointment(object sender, EventArgs e)
    {
        int appointId = int.Parse(((sender as LinkButton).NamingContainer.FindControl("lbl_id") as Label).Text);

        using (SqlCommand cmd = new SqlCommand("DELETE FROM tbl_invoice_image WHERE im_id = @im_id", conn))
        {
            cmd.Parameters.AddWithValue("@im_id", appointId);
            SqlCommand cmd2 = new SqlCommand("select * from tbl_invoice_image where im_id=@bp_id", conn);
            cmd2.Parameters.AddWithValue("@bp_id", appointId);
            SqlDataAdapter adapt2 = new SqlDataAdapter(cmd2);
            DataTable dt2 = new DataTable();
            adapt2.Fill(dt2);

            if (dt2.Rows.Count > 0)
            {
                filename1 = dt2.Rows[0]["im_image"].ToString();

            }

            string filepath = Server.MapPath("../Invoice Images/" + filename1);
            if (System.IO.File.Exists(filepath))
            {
                System.IO.File.Delete(filepath);

            }
            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();

        }

        this.FillRepeater();
        Response.Redirect(Request.RawUrl);

    }
    public string ConvertNumbertoWords(long number)
    {
        if (number == 0) return "ZERO";
        if (number < 0) return "minus " + ConvertNumbertoWords(Math.Abs(number));
        string words = "";
        if ((number / 100000) > 0)
        {
            words += ConvertNumbertoWords(number / 100000) + " LAKH ";
            number %= 100000;
        }
        if ((number / 1000) > 0)
        {
            words += ConvertNumbertoWords(number / 1000) + " THOUSAND ";
            number %= 1000;
        }
        if ((number / 100) > 0)
        {
            words += ConvertNumbertoWords(number / 100) + " HUNDRED ";
            number %= 100;
        }
        //if ((number / 10) > 0)  
        //{  
        // words += ConvertNumbertoWords(number / 10) + " RUPEES ";  
        // number %= 10;  
        //}  
        if (number > 0)
        {
            if (words != "") words += "AND ";
            var unitsMap = new[]
            {
            "ZERO", "ONE", "TWO", "THREE", "FOUR", "FIVE", "SIX", "SEVEN", "EIGHT", "NINE", "TEN", "ELEVEN", "TWELVE", "THIRTEEN", "FOURTEEN", "FIFTEEN", "SIXTEEN", "SEVENTEEN", "EIGHTEEN", "NINETEEN"
        };
            var tensMap = new[]
            {
            "ZERO", "TEN", "TWENTY", "THIRTY", "FORTY", "FIFTY", "SIXTY", "SEVENTY", "EIGHTY", "NINETY"
        };
            if (number < 20) words += unitsMap[number];
            else
            {
                words += tensMap[number / 10];
                if ((number % 10) > 0) words += " " + unitsMap[number % 10];
            }
        }

        return words;
    }
}