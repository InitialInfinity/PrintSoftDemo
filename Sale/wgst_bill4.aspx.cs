using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

public partial class Sale_wgst_bill4 : System.Web.UI.Page
{
    SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["String"].ConnectionString);
    string invoice;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["a_email"] != null)
        {


            //Panel6.Visible = true;
            //Panel5.Visible = true;
            //Panel4.Visible = true;
            //Panel3.Visible = true;
            //Panel2.Visible = true;

            invoice = Request.QueryString["invoice"].ToString();

            if (Page.IsPostBack) return;
            fill();

        }
        else
        {
            Response.Redirect("../login.aspx");
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
            lbl_gst_no.Text = dt.Rows[0]["c_gst_no"].ToString();
            //lbl_email.Text = dt.Rows[0]["c_email"].ToString();
            //lbl_order_no.Text = dt.Rows[0]["s_order_no"].ToString();
            lbl_invoice_date.Text = Convert.ToDateTime(dt.Rows[0]["es_invoice_date"]).ToString("dd/MM/yyyy");
            //lbl_due_date.Text = Convert.ToDateTime(dt.Rows[0]["s_due_date"]).ToString("dd/MM/yyyy");

            //lbl_discount.Text = dt.Rows[0]["s_discount"].ToString();

            //lbl_subtotal.Text = dt.Rows[0]["s_sub_total"].ToString();
            
            //lbl_total_gst.Text = dt.Rows[0]["s_total_gst"].ToString();
            //lbl_transport.Text = dt.Rows[0]["s_shipping_charges"].ToString();
            //lbl_adjustment.Text = dt.Rows[0]["s_adjustment"].ToString();
            lbl_total.Text = dt.Rows[0]["es_total"].ToString();
            lbl_total_amt.Text = dt.Compute("Sum(es_total)", string.Empty).ToString();
            //lbl_word.Text = ConvertNumbertoWords(Convert.ToInt64(dt.Rows[0]["s_total"]));
            lbl_balance.Text = dt.Rows[0]["es_balance"].ToString();
            //lbl_dtp.Text = dt.Rows[0]["s_dtp_charges"].ToString();
            //lbl_fitting.Text = dt.Rows[0]["s_fitting_charges"].ToString();
            //lbl_pasting.Text = dt.Rows[0]["s_pasting_charges"].ToString();
            //lbl_framing.Text = dt.Rows[0]["s_framing_charges"].ToString();
            //lbl_install.Text = dt.Rows[0]["s_installation_charges"].ToString();

            //if (lbl_framing.Text == "0")
            //{
            //    Panel4.Visible = false;
            //}

            //if (lbl_dtp.Text == "0")
            //{
            //    Panel2.Visible = false;
            //}

            //if (lbl_install.Text == "0")
            //{
            //    Panel6.Visible = false;
            //}

            //if (lbl_fitting.Text == "0")
            //{
            //    Panel5.Visible = false;
            //}

            //if (lbl_pasting.Text == "0")
            //{
            //    Panel3.Visible = false;
            //}

        }

        SqlCommand cmd3 = new SqlCommand("select sum(si_pay) from tbl_sale_invoice_payment where si_invoice ='" + invoice + "'", conn);
        SqlDataAdapter adapt3 = new SqlDataAdapter(cmd3);
        DataTable dt3 = new DataTable();
        adapt3.Fill(dt3);
        if (dt3.Rows.Count > 0)
        {
            lbl_adjustment.Text = dt3.Rows[0][0].ToString();
        }

        SqlCommand cmd2 = new SqlCommand("select * from tbl_company_details where com_id = 1", conn);
        SqlDataAdapter adapt2 = new SqlDataAdapter(cmd2);
        DataTable dt2 = new DataTable();
        adapt2.Fill(dt2);
        if (dt2.Rows.Count > 0)
        {
            //lbl_company_name.Text = dt2.Rows[0]["com_company_name"].ToString();
            //lbl_company_name2.Text = dt2.Rows[0]["com_company_name"].ToString();
            //lbl_company_address.Text = dt2.Rows[0]["com_address"].ToString();
            //lbl_company_contact.Text = dt2.Rows[0]["com_contact"].ToString();
            //lbl_company_email.Text = dt2.Rows[0]["com_email"].ToString();
            lbl_company_gst.Text = dt2.Rows[0]["com_gst_no"].ToString();
            //Image1.ImageUrl = "~/Company/Company_Photos/" + dt2.Rows[0]["com_company_logo"].ToString();
            lbl_bank_name.Text = dt2.Rows[0]["com_bank_name"].ToString();
            lbl_branch.Text = dt2.Rows[0]["com_branch"].ToString();
            //lbl_ac.Text = dt2.Rows[0]["com_acc_no"].ToString();
            lbl_ifsc.Text = dt2.Rows[0]["com_ifsc"].ToString();

        }
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