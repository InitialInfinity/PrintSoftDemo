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

public partial class Daily_Cash_Order_wgst_bill : System.Web.UI.Page
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
                bill_update = Request.QueryString["bill_update"].ToString();
                if (bill_update == "success")
                {
                    Panel3.Visible = true;
                }

            }
            catch (Exception ex)
            {
                Panel3.Visible = false;
            }

            Panel6.Visible = true;
            Panel5.Visible = true;
            Panel4.Visible = true;
            Panel2.Visible = false;
            invoice = Request.QueryString["invoice"].ToString();
            if (Page.IsPostBack) return;
            fill();
            FillRepeater();
        }
        else
        {
            Response.Redirect("../login.aspx");
        }
    }

    protected void payment(object sender, EventArgs e)
    {
        Response.Redirect("cash_payment.aspx?invoice=" + invoice.ToString());

    }



    public void fill()
    {
        try
        {
       SqlCommand cmd = new SqlCommand("select * from tbl_order_details where quw_no='" + invoice + "'", conn);
        SqlDataAdapter adapt = new SqlDataAdapter(cmd);
        DataTable dt = new DataTable();
        adapt.Fill(dt);
        if (dt.Rows.Count > 0)
        {
            Repeater2.DataSource = dt;
            Repeater2.DataBind();

            lbl_invoice_no.Text = dt.Rows[0]["quw_no"].ToString();
            lbl_customer_name.Text = dt.Rows[0]["qw_name"].ToString();
            lbl_customer_contact.Text = dt.Rows[0]["qw_phone"].ToString();

            lbl_shipping.Text = dt.Rows[0]["qw_shipping_charges"].ToString();
            lbl_discount.Text = dt.Rows[0]["qw_discount"].ToString();
            lbl_adjustment.Text = dt.Rows[0]["qw_adjustment"].ToString();

            lbl_design.Text = dt.Rows[0]["qw_dtp_charges"].ToString();
            lbl_subtotal.Text = dt.Rows[0]["qw_sub_total"].ToString();

            lbl_pasting.Text = dt.Rows[0]["qw_pasting_charges"].ToString();
            lbl_fitting.Text = dt.Rows[0]["qw_fitting_charges"].ToString();
            lbl_payment_method.Text = dt.Rows[0]["qw_payment_method"].ToString();
            lbl_total.Text = dt.Rows[0]["qw_total"].ToString();
            lbl_balance.Text = dt.Rows[0]["qw_balance"].ToString();
            lbl_word.Text = ConvertNumbertoWords(Convert.ToInt64(dt.Rows[0]["qw_stotal"]));

                if (lbl_fitting.Text == "0")
                {
                    Panel5.Visible = false;
                }

                if (lbl_design.Text == "0")
                {
                    Panel4.Visible = false;
                }

                if (lbl_pasting.Text == "0")
                {
                    Panel6.Visible = false;
                }

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
            lbl_company_gst.Text = dt2.Rows[0]["com_gst_no"].ToString();
            Image1.ImageUrl = "~/Company/Company_Photos/" + dt2.Rows[0]["com_company_logo2"].ToString();
            lbl_note.Text = dt2.Rows[0]["com_note"].ToString();
            lbl_bank_name.Text = dt2.Rows[0]["com_bank_name"].ToString();
            lbl_branch.Text = dt2.Rows[0]["com_branch"].ToString();
            lbl_ac.Text = dt2.Rows[0]["com_acc_no"].ToString();
            lbl_ifsc.Text = dt2.Rows[0]["com_ifsc"].ToString();
            }
        }

        catch(Exception ex)
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