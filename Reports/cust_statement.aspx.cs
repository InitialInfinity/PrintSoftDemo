using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

public partial class Reports_cust_statement : System.Web.UI.Page
{
    SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["String"].ConnectionString);
    decimal amount,amount2, paid, balance,total;
    SqlCommand cmd2, cmd3, cmd4, cmd7, cmd8, cmd9;
    SqlDataAdapter adapt2, adapt3, adapt7, adapt8, adapt9;
    DataTable dt1, dt2, dt7, dt8, dt9;
    protected void Page_Load(object sender, EventArgs e)
    {

        if (Session["a_email"] != null)
        {
            Panel1.Visible = false;
            if (Page.IsPostBack) return;
            Date1.Text = DateTime.Today.ToString("yyyy-MM-dd");
            Date2.Text = DateTime.Today.ToString("yyyy-MM-dd");
            customer();
           
        }
        else
        {
            Response.Redirect("../login.aspx");
        }
    }
    public void customer()
    {
        string query = "select * from tbl_customer Order By c_name asc";
        SqlDataAdapter adapt4 = new SqlDataAdapter(query, conn);
        DataTable dt5 = new DataTable();
        adapt4.Fill(dt5);
        if (dt5.Rows.Count > 0)
        {
            Dd_customer.DataSource = dt5;
            Dd_customer.DataBind();
            Dd_customer.DataTextField = "c_name";
            Dd_customer.DataValueField = "c_id";
            Dd_customer.DataBind();
            Dd_customer.Items.Insert(0, new ListItem("--Select--", "--Select--"));
            Dd_customer.SelectedItem.Selected = false;
            Dd_customer.Items.FindByText("--Select--").Selected = true;
        }

    }
  
    protected void Dd_customer_SelectedIndexChanged(object sender, EventArgs e)
    {
        //if (Date1.Text == "" || Date2.Text == "")
        //{
        //    Panel1.Visible = true;
        //    SqlCommand cmd = new SqlCommand("select * from tbl_sale_invoice_payment where c_id ='" + Dd_customer.SelectedValue + "'", conn);
        //    SqlDataAdapter adapt = new SqlDataAdapter(cmd);
        //    DataTable dt = new DataTable();
        //    adapt.Fill(dt);
        //    if (dt.Rows.Count > 0)
        //    {
        //        Repeater2.DataSource = dt;
        //        Repeater2.DataBind();

        //    }

        //    SqlCommand cmd2 = new SqlCommand("select * from tbl_company_details where com_id = 1", conn);
        //    SqlDataAdapter adapt2 = new SqlDataAdapter(cmd2);
        //    DataTable dt2 = new DataTable();
        //    adapt2.Fill(dt2);
        //    if (dt2.Rows.Count > 0)
        //    {
        //        lbl_company_name.Text = dt2.Rows[0]["com_company_name"].ToString();
        //        lbl_company_address.Text = dt2.Rows[0]["com_address"].ToString();
        //        lbl_company_contact.Text = dt2.Rows[0]["com_contact"].ToString();
        //        lbl_company_email.Text = dt2.Rows[0]["com_email"].ToString();
        //        Image1.ImageUrl = "~/Company/Company_Photos/" + dt2.Rows[0]["com_company_logo"].ToString();
        //    }

        //    SqlCommand cmd3 = new SqlCommand("select * from tbl_customer where c_id = '" + Dd_customer.SelectedValue + "'", conn);
        //    SqlDataAdapter adapt3 = new SqlDataAdapter(cmd3);
        //    DataTable dt3 = new DataTable();
        //    adapt3.Fill(dt3);
        //    if (dt3.Rows.Count > 0)
        //    {
        //        lbl_customer_name.Text = dt3.Rows[0]["c_name"].ToString();
        //        lbl_customer_contact.Text = dt3.Rows[0]["c_contact"].ToString();
        //        lbl_customer_address.Text = dt3.Rows[0]["c_address"].ToString();
        //        lbl_gst_no.Text = dt3.Rows[0]["c_gst_no"].ToString();
                

        //    }

        //    SqlCommand cmd4 = new SqlCommand("select sum(sl_total) from tbl_sale where c_id='" + Dd_customer.SelectedValue + "'", conn);
        //    SqlDataAdapter adapt4 = new SqlDataAdapter(cmd4);
        //    DataTable dt4 = new DataTable();
        //    adapt4.Fill(dt4);
        //    if (dt4.Rows.Count > 0)
        //    {
             
        //        if (dt4.Rows[0][0] == System.DBNull.Value)
        //        {
        //            amount = 0;
        //        }
        //        else
        //        {
        //            amount = Convert.ToDecimal(dt4.Rows[0][0]);
        //        }
        //    }
        //    SqlCommand cmd5 = new SqlCommand("select sum(est_total) from tbl_estimate where c_id='" + Dd_customer.SelectedValue + "'", conn);
        //    SqlDataAdapter adapt5 = new SqlDataAdapter(cmd5);
        //    DataTable dt5 = new DataTable();
        //    adapt5.Fill(dt5);
        //    if (dt5.Rows.Count > 0)
        //    {

        //        if (dt5.Rows[0][0] == System.DBNull.Value)
        //        {
        //            amount2 = 0;
        //        }
        //        else
        //        {
        //            amount2 = Convert.ToDecimal(dt5.Rows[0][0]);
        //        }
        //    }

        //    SqlCommand cmd6 = new SqlCommand("select sum(si_pay) from tbl_sale_invoice_payment where c_id='" + Dd_customer.SelectedValue + "'", conn);
        //    SqlDataAdapter adapt6 = new SqlDataAdapter(cmd6);
        //    DataTable dt6 = new DataTable();

        //    adapt6.Fill(dt6);
        //    if (dt6.Rows.Count > 0)
        //    {
        //        lbl_amount_paid.Text = dt6.Rows[0][0].ToString();
        //        if (dt6.Rows[0][0] == System.DBNull.Value)
        //        {
        //            paid = 0;
        //        }
        //        else
        //        {
        //            paid = Convert.ToDecimal(dt6.Rows[0][0]);
        //        }

        //        total = amount + amount2;
        //        balance = total - paid;
        //        lbl_balance_amount.Text = balance.ToString();
        //        lbl_due_balance.Text = balance.ToString();
        //        lbl_invoice_amount.Text = total.ToString();
                

        //    }

        //}
        //else
        //{
        //    Panel1.Visible = true;
        //    SqlCommand cmd = new SqlCommand("select * from tbl_sale_invoice_payment where c_id ='" + Dd_customer.SelectedValue + "' AND si_date between '" + Date1.Text+ "' AND '" + Date2.Text + "'", conn);
        //    SqlDataAdapter adapt = new SqlDataAdapter(cmd);
        //    DataTable dt = new DataTable();
        //    adapt.Fill(dt);
        //    if (dt.Rows.Count > 0)
        //    {
        //        Repeater2.DataSource = dt;
        //        Repeater2.DataBind();

        //    }

        //    SqlCommand cmd2 = new SqlCommand("select * from tbl_company_details where com_id = 1", conn);
        //    SqlDataAdapter adapt2 = new SqlDataAdapter(cmd2);
        //    DataTable dt2 = new DataTable();
        //    adapt2.Fill(dt2);
        //    if (dt2.Rows.Count > 0)
        //    {
        //        lbl_company_name.Text = dt2.Rows[0]["com_company_name"].ToString();
        //        lbl_company_address.Text = dt2.Rows[0]["com_address"].ToString();
        //        lbl_company_contact.Text = dt2.Rows[0]["com_contact"].ToString();
        //        lbl_company_email.Text = dt2.Rows[0]["com_email"].ToString();
        //        Image1.ImageUrl = "~/Company/Company_Photos/" + dt2.Rows[0]["com_company_logo"].ToString();
        //    }

        //    SqlCommand cmd3 = new SqlCommand("select * from tbl_customer where c_id = '" + Dd_customer.SelectedValue + "'", conn);
        //    SqlDataAdapter adapt3 = new SqlDataAdapter(cmd3);
        //    DataTable dt3 = new DataTable();
        //    adapt3.Fill(dt3);
        //    if (dt3.Rows.Count > 0)
        //    {
        //        lbl_customer_name.Text = dt3.Rows[0]["c_name"].ToString();
        //        lbl_customer_contact.Text = dt3.Rows[0]["c_contact"].ToString();
        //        lbl_customer_address.Text = dt3.Rows[0]["c_address"].ToString();
        //        lbl_gst_no.Text = dt3.Rows[0]["c_gst_no"].ToString();
               

        //    }

        //    SqlCommand cmd4 = new SqlCommand("select sum(sl_total) from tbl_sale where c_id='" + Dd_customer.SelectedValue + "' AND sl_date between '" + Date1.Text + "' AND '" + Date2.Text + "' ", conn);
        //    SqlDataAdapter adapt4 = new SqlDataAdapter(cmd4);
        //    DataTable dt4 = new DataTable();
        //    adapt4.Fill(dt4);
        //    if (dt4.Rows.Count > 0)
        //    {
           
        //        if (dt4.Rows[0][0] == System.DBNull.Value)
        //        {
        //            amount = 0;
        //        }
        //        else
        //        {
        //            amount = Convert.ToDecimal(dt4.Rows[0][0]);
        //        }

        //    }
        //    SqlCommand cmd5 = new SqlCommand("select sum(est_total) from tbl_estimate where c_id='" + Dd_customer.SelectedValue + "' AND est_date between '" + Date1.Text + "' AND '" + Date2.Text + "' ", conn);
        //    SqlDataAdapter adapt5 = new SqlDataAdapter(cmd5);
        //    DataTable dt5 = new DataTable();
        //    adapt5.Fill(dt5);
        //    if (dt5.Rows.Count > 0)
        //    {

        //        if (dt5.Rows[0][0] == System.DBNull.Value)
        //        {
        //            amount2 = 0;
        //        }
        //        else
        //        {
        //            amount2 = Convert.ToDecimal(dt5.Rows[0][0]);
        //        }

        //    }


        //    SqlCommand cmd6 = new SqlCommand("select sum(si_pay) from tbl_sale_invoice_payment where c_id='" + Dd_customer.SelectedValue + "' AND si_date between '" + Date1.Text + "' AND '" + Date2.Text + "'", conn);
        //    SqlDataAdapter adapt6 = new SqlDataAdapter(cmd6);
        //    DataTable dt6 = new DataTable();

        //    adapt6.Fill(dt6);
        //    if (dt6.Rows.Count > 0)
        //    {
        //        lbl_amount_paid.Text = dt6.Rows[0][0].ToString();
        //        if (dt6.Rows[0][0] == System.DBNull.Value)
        //        {
        //            paid = 0;
        //        }
        //        else
        //        {
        //            paid = Convert.ToDecimal(dt6.Rows[0][0]);
        //        }

        //        total = amount + amount2;
        //        balance = total - paid;
        //        lbl_balance_amount.Text = balance.ToString();
        //        lbl_due_balance.Text = balance.ToString();
        //        lbl_invoice_amount.Text = total.ToString();



        //    }
        //}
    }

    protected void Btn_Search_Click(object sender, EventArgs e)
    {


        if (Date1.Text == "" || Date2.Text == "")
        {

            Panel1.Visible = true;
            cmd2 = new SqlCommand("select * from tbl_sale_invoice_payment where c_id='" + Dd_customer.SelectedValue + "'", conn);
            adapt2 = new SqlDataAdapter(cmd2);
            dt1 = new DataTable();
            adapt2.Fill(dt1);
            if (dt1.Rows.Count > 0)
            {
                Repeater2.DataSource = dt1;
                Repeater2.DataBind();

            }

            SqlCommand cmd5 = new SqlCommand("select * from tbl_company_details where com_id = 1", conn);
            SqlDataAdapter adapt5 = new SqlDataAdapter(cmd5);
            DataTable dt5 = new DataTable();
            adapt5.Fill(dt5);
            if (dt5.Rows.Count > 0)
            {
                lbl_company_name.Text = dt5.Rows[0]["com_company_name"].ToString();
                lbl_company_address.Text = dt5.Rows[0]["com_address"].ToString();
                lbl_company_contact.Text = dt5.Rows[0]["com_contact"].ToString();
                lbl_company_email.Text = dt5.Rows[0]["com_email"].ToString();
                Image1.ImageUrl = "~/Company/Company_Photos/" + dt5.Rows[0]["com_company_logo"].ToString();
            }

            SqlCommand cmd6 = new SqlCommand("select * from tbl_customer where c_id = '" + Dd_customer.SelectedValue + "'", conn);
            SqlDataAdapter adapt6 = new SqlDataAdapter(cmd6);
            DataTable dt6 = new DataTable();
            adapt6.Fill(dt6);
            if (dt6.Rows.Count > 0)
            {
                lbl_customer_name.Text = dt6.Rows[0]["c_name"].ToString();
                lbl_customer_contact.Text = dt6.Rows[0]["c_contact"].ToString();
                lbl_customer_address.Text = dt6.Rows[0]["c_address"].ToString();
                lbl_gst_no.Text = dt6.Rows[0]["c_gst_no"].ToString();


            }

            cmd7 = new SqlCommand("select sum(sl_total) from tbl_sale where c_id='" + Dd_customer.SelectedValue + "' AND sl_date between '" + Date1.Text + "' AND '" + Date2.Text + "'", conn);
            adapt7 = new SqlDataAdapter(cmd7);
            dt7 = new DataTable();
            adapt7.Fill(dt7);
            if (dt7.Rows.Count > 0)
            {

                if (dt7.Rows[0][0] == System.DBNull.Value)
                {
                    amount = 0;
                }
                else
                {
                    amount = Convert.ToDecimal(dt7.Rows[0][0]);
                }
            }
            cmd9 = new SqlCommand("select sum(est_total) from tbl_estimate where c_id='" + Dd_customer.SelectedValue + "'", conn);
            adapt9 = new SqlDataAdapter(cmd9);
            dt9 = new DataTable();
            adapt9.Fill(dt9);
            if (dt9.Rows.Count > 0)
            {

                if (dt9.Rows[0][0] == System.DBNull.Value)
                {
                    amount2 = 0;
                }
                else
                {
                    amount2 = Convert.ToDecimal(dt9.Rows[0][0]);
                }
            }

            cmd8 = new SqlCommand("select sum(si_pay) from tbl_sale_invoice_payment where c_id='" + Dd_customer.SelectedValue + "'", conn);
            adapt8 = new SqlDataAdapter(cmd8);
            dt8 = new DataTable();

            adapt8.Fill(dt8);
            if (dt8.Rows.Count > 0)
            {
                lbl_amount_paid.Text = dt8.Rows[0][0].ToString();
                if (dt8.Rows[0][0] == System.DBNull.Value)
                {
                    paid = 0;
                }
                else
                {
                    paid = Convert.ToDecimal(dt8.Rows[0][0]);
                }

                total = amount + amount2;
                balance = total - paid;
                lbl_balance_amount.Text = balance.ToString();
                lbl_due_balance.Text = balance.ToString();
                lbl_invoice_amount.Text = total.ToString();




            }

        }
        else if (Date1.Text != "" && Date2.Text != "" && Dd_customer.SelectedValue == "--Select--")
        {
            Panel1.Visible = true;
            cmd2 = new SqlCommand("select * from tbl_sale_invoice_payment where si_date between '" + Date1.Text + "' AND '" + Date2.Text + "'", conn);
            adapt2 = new SqlDataAdapter(cmd2);
            dt1 = new DataTable();
            adapt2.Fill(dt1);
            if (dt1.Rows.Count > 0)
            {
                Repeater2.DataSource = dt1;
                Repeater2.DataBind();

            }

            SqlCommand cmd5 = new SqlCommand("select * from tbl_company_details where com_id = 1", conn);
            SqlDataAdapter adapt5 = new SqlDataAdapter(cmd5);
            DataTable dt5 = new DataTable();
            adapt5.Fill(dt5);
            if (dt5.Rows.Count > 0)
            {
                lbl_company_name.Text = dt5.Rows[0]["com_company_name"].ToString();
                lbl_company_address.Text = dt5.Rows[0]["com_address"].ToString();
                lbl_company_contact.Text = dt5.Rows[0]["com_contact"].ToString();
                lbl_company_email.Text = dt5.Rows[0]["com_email"].ToString();
                Image1.ImageUrl = "~/Company/Company_Photos/" + dt5.Rows[0]["com_company_logo"].ToString();
            }

            SqlCommand cmd6 = new SqlCommand("select * from tbl_customer where c_name = '" + Dd_customer.SelectedValue + "'", conn);
            SqlDataAdapter adapt6 = new SqlDataAdapter(cmd6);
            DataTable dt6 = new DataTable();
            adapt6.Fill(dt6);
            if (dt6.Rows.Count > 0)
            {
                lbl_customer_name.Text = dt6.Rows[0]["c_name"].ToString();
                lbl_customer_contact.Text = dt6.Rows[0]["c_contact"].ToString();
                lbl_customer_address.Text = dt6.Rows[0]["c_address"].ToString();
                lbl_gst_no.Text = dt6.Rows[0]["c_gst_no"].ToString();


            }

            cmd7 = new SqlCommand("select sum(sl_total) from tbl_sale where sl_date between '" + Date1.Text + "' AND '" + Date2.Text + "'", conn);
            adapt7 = new SqlDataAdapter(cmd7);
            dt7 = new DataTable();
            adapt7.Fill(dt7);
            if (dt7.Rows.Count > 0)
            {

                if (dt7.Rows[0][0] == System.DBNull.Value)
                {
                    amount = 0;
                }
                else
                {
                    amount = Convert.ToDecimal(dt7.Rows[0][0]);
                }
            }
            cmd9 = new SqlCommand("select sum(est_total) from tbl_estimate where est_date between '" + Date1.Text + "' AND '" + Date2.Text + "'", conn);
            adapt9 = new SqlDataAdapter(cmd9);
            dt9 = new DataTable();
            adapt9.Fill(dt9);
            if (dt9.Rows.Count > 0)
            {

                if (dt9.Rows[0][0] == System.DBNull.Value)
                {
                    amount2 = 0;
                }
                else
                {
                    amount2 = Convert.ToDecimal(dt9.Rows[0][0]);
                }
            }

            cmd8 = new SqlCommand("select sum(si_pay) from tbl_sale_invoice_payment where si_date between '" + Date1.Text + "' AND '" + Date2.Text + "'", conn);
            adapt8 = new SqlDataAdapter(cmd8);
            dt8 = new DataTable();

            adapt8.Fill(dt8);
            if (dt8.Rows.Count > 0)
            {
                lbl_amount_paid.Text = dt8.Rows[0][0].ToString();
                if (dt8.Rows[0][0] == System.DBNull.Value)
                {
                    paid = 0;
                }
                else
                {
                    paid = Convert.ToDecimal(dt8.Rows[0][0]);
                }

                total = amount + amount2;
                balance = total - paid;
                lbl_balance_amount.Text = balance.ToString();
                lbl_due_balance.Text = balance.ToString();
                lbl_invoice_amount.Text = total.ToString();




            }

        }
        else
        {
            Panel1.Visible = true;
            cmd2 = new SqlCommand("select * from tbl_sale_invoice_payment where c_id ='" + Dd_customer.SelectedValue + "' AND si_date between '" + Date1.Text + "' AND '" + Date2.Text + "'", conn);
            adapt2 = new SqlDataAdapter(cmd2);
            dt1 = new DataTable();
            adapt2.Fill(dt1);
            if (dt1.Rows.Count > 0)
            {
                Repeater2.DataSource = dt1;
                Repeater2.DataBind();

            }

            SqlCommand cmd5 = new SqlCommand("select * from tbl_company_details where com_id = 1", conn);
            SqlDataAdapter adapt5 = new SqlDataAdapter(cmd5);
            DataTable dt5 = new DataTable();
            adapt5.Fill(dt5);
            if (dt5.Rows.Count > 0)
            {
                lbl_company_name.Text = dt5.Rows[0]["com_company_name"].ToString();
                lbl_company_address.Text = dt5.Rows[0]["com_address"].ToString();
                lbl_company_contact.Text = dt5.Rows[0]["com_contact"].ToString();
                lbl_company_email.Text = dt5.Rows[0]["com_email"].ToString();
                Image1.ImageUrl = "~/Company/Company_Photos/" + dt5.Rows[0]["com_company_logo"].ToString();
            }

            SqlCommand cmd6 = new SqlCommand("select * from tbl_customer where c_name = '" + Dd_customer.SelectedItem.Text + "'", conn);
            SqlDataAdapter adapt6 = new SqlDataAdapter(cmd6);
            DataTable dt6 = new DataTable();
            adapt6.Fill(dt6);
            if (dt6.Rows.Count > 0)
            {
                lbl_customer_name.Text = dt6.Rows[0]["c_name"].ToString();
                lbl_customer_contact.Text = dt6.Rows[0]["c_contact"].ToString();
                lbl_customer_address.Text = dt6.Rows[0]["c_address"].ToString();
                lbl_gst_no.Text = dt6.Rows[0]["c_gst_no"].ToString();


            }

            cmd7 = new SqlCommand("select sum(sl_total) from tbl_sale where c_id ='" + Dd_customer.SelectedValue + "' AND sl_date between '" + Date1.Text + "' AND '" + Date2.Text + "'", conn);
            adapt7 = new SqlDataAdapter(cmd7);
            dt7 = new DataTable();
            adapt7.Fill(dt7);
            if (dt7.Rows.Count > 0)
            {

                if (dt7.Rows[0][0] == System.DBNull.Value)
                {
                    amount = 0;
                }
                else
                {
                    amount = Convert.ToDecimal(dt7.Rows[0][0]);
                }

            }
            cmd9 = new SqlCommand("select sum(est_total) from tbl_estimate where c_id ='" + Dd_customer.SelectedValue + "' AND est_date between '" + Date1.Text + "' AND '" + Date2.Text + "'", conn);
            adapt9 = new SqlDataAdapter(cmd9);
            dt9 = new DataTable();
            adapt9.Fill(dt9);
            if (dt9.Rows.Count > 0)
            {

                if (dt9.Rows[0][0] == System.DBNull.Value)
                {
                    amount2 = 0;
                }
                else
                {
                    amount2 = Convert.ToDecimal(dt9.Rows[0][0]);
                }

            }


            cmd8 = new SqlCommand("select sum(si_pay) from tbl_sale_invoice_payment where c_id ='" + Dd_customer.SelectedValue + "' AND si_date between '" + Date1.Text + "' AND '" + Date2.Text + "'", conn);
            adapt8 = new SqlDataAdapter(cmd8);
            dt8 = new DataTable();

            adapt8.Fill(dt8);
            if (dt8.Rows.Count > 0)
            {
                lbl_amount_paid.Text = dt8.Rows[0][0].ToString();
                if (dt8.Rows[0][0] == System.DBNull.Value)
                {
                    paid = 0;
                }
                else
                {
                    paid = Convert.ToDecimal(dt8.Rows[0][0]);
                }

                total = amount + amount2;
                balance = total - paid;
                lbl_balance_amount.Text = balance.ToString();
                lbl_due_balance.Text = balance.ToString();
                lbl_invoice_amount.Text = total.ToString();

            }
        }
    }
}