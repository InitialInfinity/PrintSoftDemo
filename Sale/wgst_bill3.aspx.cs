﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using System.Drawing;
using iTextSharp.text;
using System.IO;
using iTextSharp.text.html.simpleparser;
using iTextSharp.text.pdf;
using System.Net;
using System.Text;
using System.Net.Mail;
using iTextSharp.tool.xml;

public partial class Sale_wgst_bill3 : System.Web.UI.Page
{
    SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["String"].ConnectionString);
    SqlCommand cmd2, cmd3, cmd4, cmd5, cmd6;
    SqlDataAdapter adapt2, adapt3, adapt4, adapt5, adapt6;
    DataTable dt1, dt2, dt3, dt4, dt5, dt6;
    string invoice;
    string otp = string.Empty;
    string filename1, key, country, senderid, route, email, password, port, subject, smtp;
    int count = 1;
    protected void Page_Load(object sender, EventArgs e)
    {

        if (Session["a_email"] != null)
        {
            Panel6.Visible = true;
            Panel5.Visible = true;
            Panel4.Visible = true;
            Panel3.Visible = true;
            Panel2.Visible = true;

            //    Panel2.Visible = false;
            invoice = Request.QueryString["invoice"].ToString();
            //Txt_invoice.Text = invoice.ToString();
            if (Page.IsPostBack) return;
            fill();
            //FillRepeater();

        }
        else
        {
            Response.Redirect("../login.aspx");
        }
    }
    public void fill()
    {
        cmd2 = new SqlCommand("select * from tbl_estimate_details inner join tbl_customer on tbl_estimate_details.c_id=tbl_customer.c_id where es_invoice_no ='" + invoice + "'", conn);
        adapt2 = new SqlDataAdapter(cmd2);
        dt1 = new DataTable();
        adapt2.Fill(dt1);
        if (dt1.Rows.Count > 0)
        {
            Repeater1.DataSource = dt1;
            Repeater1.DataBind();



            lbl_invoice_no.Text = dt1.Rows[0]["es_invoice_no"].ToString();

            lbl_customer_name.Text = dt1.Rows[0]["c_name"].ToString();
            lbl_customer_contact.Text = dt1.Rows[0]["c_contact"].ToString();
            lbl_customer_address.Text = dt1.Rows[0]["c_address"].ToString();
            lbl_gst_no.Text = dt1.Rows[0]["c_gst_no"].ToString();
            lbl_email.Text = dt1.Rows[0]["c_email"].ToString();
            lbl_invoice_date.Text = Convert.ToDateTime(dt1.Rows[0]["es_invoice_date"]).ToString("dd/MM/yyyy");


            //lbl_total_qty.Text = dt1.Rows[0]["es_total_quantity"].ToString();
            lbl_subtotal.Text = dt1.Rows[0]["es_sub_total"].ToString();





            lbl_discount.Text = dt1.Rows[0]["es_discount"].ToString();
            lbl_transport.Text = dt1.Rows[0]["es_shipping_charges"].ToString();
            lbl_adjustment.Text = dt1.Rows[0]["es_adjustment"].ToString();

            lbl_total.Text = dt1.Rows[0]["es_total"].ToString();
            lbl_word.Text = ConvertNumbertoWords(Convert.ToInt64(dt1.Rows[0]["es_total"]));
            lbl_balance.Text = dt1.Rows[0]["es_balance"].ToString();
            lbl_dtp.Text = dt1.Rows[0]["es_dtp_charges"].ToString();
            lbl_fitting.Text = dt1.Rows[0]["es_fitting_charges"].ToString();
            lbl_pasting.Text = dt1.Rows[0]["es_pasting_charges"].ToString();
            lbl_framing.Text = dt1.Rows[0]["es_framing_charges"].ToString();
            lbl_install.Text = dt1.Rows[0]["es_installation_charges"].ToString();

            if (lbl_framing.Text == "0")
            {
                Panel4.Visible = false;
            }

            if (lbl_dtp.Text == "0")
            {
                Panel2.Visible = false;
            }

            if (lbl_install.Text == "0")
            {
                Panel6.Visible = false;
            }

            if (lbl_fitting.Text == "0")
            {
                Panel5.Visible = false;
            }

            if (lbl_pasting.Text == "0")
            {
                Panel3.Visible = false;
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
        cmd3 = new SqlCommand("select sum(es_stotal) from tbl_estimate_details where es_invoice_no ='" + invoice + "'", conn);
        adapt3 = new SqlDataAdapter(cmd3);
        dt3 = new DataTable();
        adapt3.Fill(dt3);
        if (dt3.Rows.Count > 0)
        {
            //lbl_total_taxable.Text = dt3.Rows[0][0].ToString();
            //lbl_total_taxable2.Text = dt3.Rows[0][0].ToString();

        }

        SqlCommand cmd5 = new SqlCommand("select * from tbl_company_details where com_id = 1", conn);
        SqlDataAdapter adapt5 = new SqlDataAdapter(cmd5);
        DataTable dt5 = new DataTable();
        adapt5.Fill(dt5);
        if (dt5.Rows.Count > 0)
        {
            lbl_company_name.Text = dt5.Rows[0]["com_company_name2"].ToString();
            lbl_company_name2.Text = dt5.Rows[0]["com_company_name"].ToString();
            //lbl_company_owner.Text = dt5.Rows[0]["com_owner_name"].ToString();
            lbl_company_contact.Text = dt5.Rows[0]["com_contact"].ToString();
            lbl_company_email.Text = dt5.Rows[0]["com_email"].ToString();
            lbl_company_gst.Text = dt5.Rows[0]["com_gst_no"].ToString();
            //lbl_bank_name.Text = dt5.Rows[0]["com_bank_name"].ToString();
            //lbl_branch_name.Text = dt5.Rows[0]["com_branch"].ToString();
            //lbl_ac_no.Text = dt5.Rows[0]["com_acc_no"].ToString();
            //lbl_ifsc.Text = dt5.Rows[0]["com_ifsc"].ToString();
            Image1.ImageUrl = "~/Company/Company_Photos/" + dt5.Rows[0]["com_company_logo2"].ToString();
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


    protected void Repeater1_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
        {
            DataRowView drv = e.Item.DataItem as DataRowView;
            decimal h = Convert.ToDecimal(drv["es_height"]);
            decimal w = Convert.ToDecimal(drv["es_width"]);
            Label lh = e.Item.FindControl("lbl_h") as Label;
            Label lw = e.Item.FindControl("lbl_w") as Label;
            if (h == 0 && w == 0)
            {
                lh.Text = "-";
                lw.Text = "-";
            }
            Label lbl = e.Item.FindControl("lbl_sr") as Label;
            lbl.Text = count.ToString();
            count++;
        }

    }
}