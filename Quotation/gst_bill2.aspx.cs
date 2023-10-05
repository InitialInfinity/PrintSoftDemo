using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

public partial class Sale_bill2 : System.Web.UI.Page
{
    SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["String"].ConnectionString);
    string invoice;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["a_email"] != null)
        {
           
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
        SqlCommand cmd = new SqlCommand("select * from tbl_gst_quotation_details inner join tbl_customer on tbl_gst_quotation_details.c_id=tbl_customer.c_id where q_quotation_no ='" + invoice + "'", conn);
        SqlDataAdapter adapt = new SqlDataAdapter(cmd);
        DataTable dt = new DataTable();
        adapt.Fill(dt);
        if (dt.Rows.Count > 0)
        {
            Repeater2.DataSource = dt;
            Repeater2.DataBind();

            lbl_invoice_no.Text = dt.Rows[0]["q_quotation_no"].ToString();

            lbl_customer_name.Text = dt.Rows[0]["c_name"].ToString();
            lbl_customer_contact.Text = dt.Rows[0]["c_contact"].ToString();
            lbl_customer_address.Text = dt.Rows[0]["c_address"].ToString();
            lbl_gst_no.Text = dt.Rows[0]["c_gst_no"].ToString();
            lbl_email.Text = dt.Rows[0]["c_email"].ToString();
            //lbl_order_no.Text = dt.Rows[0]["q_order_no"].ToString();
            lbl_invoice_date.Text = Convert.ToDateTime(dt.Rows[0]["q_quotation_date"]).ToString("dd/MM/yyyy");
            lbl_due_date.Text = Convert.ToDateTime(dt.Rows[0]["q_valid_date"]).ToString("dd/MM/yyyy");

            lbl_discount.Text = dt.Rows[0]["q_discount"].ToString();

            lbl_subtotal.Text = dt.Rows[0]["q_sub_total"].ToString();
            lbl_total_gst.Text = dt.Rows[0]["q_total_gst"].ToString();
            lbl_shipping.Text = dt.Rows[0]["q_shipping_charges"].ToString();
            lbl_adjustment.Text = dt.Rows[0]["q_adjustment"].ToString();
            lbl_total.Text = dt.Rows[0]["q_total"].ToString();
            lbl_word.Text = ConvertNumbertoWords(Convert.ToInt64(dt.Rows[0]["q_total"]));
            //lbl_balance.Text = dt.Rows[0]["q_balance"].ToString();



        }


        SqlCommand cmd2 = new SqlCommand("select * from tbl_company_details where com_id = 1", conn);
        SqlDataAdapter adapt2 = new SqlDataAdapter(cmd2);
        DataTable dt2 = new DataTable();
        adapt2.Fill(dt2);
        if (dt2.Rows.Count > 0)
        {
            lbl_company_name.Text = dt2.Rows[0]["com_company_name"].ToString();
            lbl_company_name2.Text = dt2.Rows[0]["com_company_name"].ToString();
            lbl_company_address.Text = dt2.Rows[0]["com_address"].ToString();
            lbl_company_contact.Text = dt2.Rows[0]["com_contact"].ToString();
            lbl_company_email.Text = dt2.Rows[0]["com_email"].ToString();
            lbl_company_gst.Text = dt2.Rows[0]["com_gst_no"].ToString();
            Image1.ImageUrl = "~/Company/Company_Photos/" + dt2.Rows[0]["com_company_logo"].ToString();

        }
    }


    public string ConvertNumbertoWords(long number)
    {
        if (number == 0) return "ZERO";
        if (number < 0) return "minus " + ConvertNumbertoWords(Math.Abs(number));
        string words = "";
        if ((number / 1000000) > 0)
        {
            words += ConvertNumbertoWords(number / 100000) + " LAKH ";
            number %= 1000000;
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