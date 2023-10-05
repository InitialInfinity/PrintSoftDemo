using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

public partial class admin_panel_Purchase_bill : System.Web.UI.Page
{
    SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["String"].ConnectionString);
 
    string invoice;
    string bill_update;
    protected void Page_Load(object sender, EventArgs e)
    {
        invoice = Request.QueryString["invoice"].ToString();
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
            { Panel3.Visible = false; }

            if (Page.IsPostBack) return;
            fill();
        }
        else
        {
            Response.Redirect("../login.aspx");
        }
    }
    protected void payment(object sender, EventArgs e)
    {
        Response.Redirect("invoice_payment.aspx?invoice=" + lbl_invoice_no.Text);

    }
    protected void print(object sender, EventArgs e)
    {
        Response.Redirect("bill2.aspx?invoice=" + lbl_invoice_no.Text);

    }
    public void fill()
    {
        SqlCommand cmd = new SqlCommand("select * from tbl_purchase_invoice inner join tbl_vendor on tbl_purchase_invoice.v_id=tbl_vendor.v_id where pc_invoice_no ='" + invoice + "'", conn);
        SqlDataAdapter adapt = new SqlDataAdapter(cmd);
        DataTable dt = new DataTable();
        adapt.Fill(dt);
        if (dt.Rows.Count > 0)
        {
            Repeater2.DataSource = dt;
            Repeater2.DataBind();

            lbl_invoice_no.Text = dt.Rows[0]["pc_invoice_no"].ToString();

            lbl_customer_name.Text = dt.Rows[0]["v_name"].ToString();
            lbl_customer_address.Text = dt.Rows[0]["v_address"].ToString();
            lbl_customer_contact.Text = dt.Rows[0]["v_contact"].ToString();
            lbl_gst_no.Text = dt.Rows[0]["v_gst_no"].ToString();
            lbl_email.Text = dt.Rows[0]["v_email"].ToString();
            lbl_order_no.Text = dt.Rows[0]["pc_order_no"].ToString();
            lbl_invoice_date.Text = Convert.ToDateTime(dt.Rows[0]["pc_invoice_date"]).ToString("dd/MM/yyyy");
            lbl_due_date.Text = Convert.ToDateTime(dt.Rows[0]["pc_due_date"]).ToString("dd/MM/yyyy");

            lbl_discount.Text = dt.Rows[0]["pc_discount"].ToString();

            lbl_subtotal.Text = dt.Rows[0]["pc_sub_total"].ToString();
            lbl_total_gst.Text = dt.Rows[0]["pc_total_gst"].ToString();
            lbl_shipping.Text = dt.Rows[0]["pc_shipping_charges"].ToString();
            lbl_adjustment.Text = dt.Rows[0]["pc_adjustable"].ToString();
            lbl_total.Text = dt.Rows[0]["pc_total"].ToString();
            lbl_word.Text = ConvertNumbertoWords(Convert.ToInt64(dt.Rows[0]["pc_total"]));
            lbl_balance.Text = dt.Rows[0]["pc_balance"].ToString();


            if (Convert.ToDecimal(dt.Rows[0]["pc_balance"]) == Convert.ToDecimal(dt.Rows[0]["pc_total"]))
            {
                lbl_status.CssClass = "label label-danger";
                lbl_status.Text = "Un-Paid";
            }
            if (Convert.ToDecimal(dt.Rows[0]["pc_total"]) > Convert.ToDecimal(dt.Rows[0]["pc_balance"]))
            {
                if (Convert.ToDecimal(dt.Rows[0]["pc_balance"]) > 0)
                {
                    lbl_status.CssClass = "label label-warning";
                    lbl_status.Text = "Partially Paid";
                }
            }
            if (Convert.ToDecimal(dt.Rows[0]["pc_balance"]) <= 0)
            {
                lbl_status.CssClass = "label label-success";
                lbl_status.Text = "Paid";
            }


        }

        //SqlCommand cmd3 = new SqlCommand("select sum(pi_pay) from tbl_purchase_invoice_payment where pi_invoice ='" + invoice + "'", conn);
        //SqlDataAdapter adapt3 = new SqlDataAdapter(cmd3);
        //DataTable dt3 = new DataTable();
        //adapt3.Fill(dt3);
        //if (dt3.Rows.Count > 0)
        //{
        //    lbl_adjustment.Text = dt3.Rows[0][0].ToString();
        //}

        SqlCommand cmd2 = new SqlCommand("select * from tbl_company_details where com_id = 1", conn);
        SqlDataAdapter adapt2 = new SqlDataAdapter(cmd2);
        DataTable dt2 = new DataTable();
        adapt2.Fill(dt2);
        if (dt2.Rows.Count > 0)
        {
            lbl_company_name.Text = dt2.Rows[0]["com_company_name"].ToString();
            lbl_company_address.Text = dt2.Rows[0]["com_address"].ToString();
            lbl_company_contact.Text = dt2.Rows[0]["com_contact"].ToString();
            lbl_company_email.Text = dt2.Rows[0]["com_email"].ToString();
            lbl_company_gst.Text = dt2.Rows[0]["com_gst_no"].ToString();
            Image1.ImageUrl = "~/Company/Company_Photos/" + dt2.Rows[0]["com_company_logo"].ToString();
            lbl_note.Text = dt2.Rows[0]["com_note"].ToString();
        }
    }
    public override void VerifyRenderingInServerForm(Control control)
    {
        /* Verifies that the control is rendered */
    }
    protected void btnPDF_Click(object sender, EventArgs e)
    {
       
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