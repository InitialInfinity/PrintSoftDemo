using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

public partial class Reports_ven_statement : System.Web.UI.Page
{
    SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["String"].ConnectionString);
    decimal amount, paid, balance;
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
        string query = "select * from tbl_vendor Order By v_name asc";
        SqlDataAdapter adapt4 = new SqlDataAdapter(query, conn);
        DataTable dt5 = new DataTable();
        adapt4.Fill(dt5);
        if (dt5.Rows.Count > 0)
        {
            Dd_customer.DataSource = dt5;
            Dd_customer.DataBind();
            Dd_customer.DataTextField = "v_name";
            Dd_customer.DataValueField = "v_id";
            Dd_customer.DataBind();
            Dd_customer.Items.Insert(0, new ListItem("--Select--", "--Select--"));
            Dd_customer.SelectedItem.Selected = false;
            Dd_customer.Items.FindByText("--Select--").Selected = true;
        }

    }
    //protected void Dd_customer_SelectedIndexChanged(object sender, EventArgs e)
    //{
    //    Repeater2.DataSource = null;
    //    Repeater2.DataBind();

    //    if (Date1.Text == "" || Date2.Text == "")
    //    {
    //        Panel1.Visible = true;
    //        SqlCommand cmd = new SqlCommand("select * from tbl_purchase_invoice_payment inner join tbl_vendor on tbl_purchase_invoice_payment.v_id=tbl_vendor.v_id where tbl_purchase_invoice_payment.v_id ='" + Dd_customer.SelectedValue + "'", conn);
    //        SqlDataAdapter adapt = new SqlDataAdapter(cmd);
    //        DataTable dt = new DataTable();
    //        adapt.Fill(dt);
    //        if (dt.Rows.Count > 0)
    //        {
    //            Repeater2.DataSource = dt;
    //            Repeater2.DataBind();

    //            lbl_customer_name.Text = dt.Rows[0]["v_name"].ToString();
    //            lbl_customer_contact.Text = dt.Rows[0]["v_contact"].ToString();
    //            lbl_customer_address.Text = dt.Rows[0]["v_address"].ToString();
    //            lbl_gst_no.Text = dt.Rows[0]["v_gst_no"].ToString();

    //        }

    //        SqlCommand cmd2 = new SqlCommand("select * from tbl_company_details where com_id = 1", conn);
    //        SqlDataAdapter adapt2 = new SqlDataAdapter(cmd2);
    //        DataTable dt2 = new DataTable();
    //        adapt2.Fill(dt2);
    //        if (dt2.Rows.Count > 0)
    //        {
    //            lbl_company_name.Text = dt2.Rows[0]["com_company_name"].ToString();
    //            lbl_company_address.Text = dt2.Rows[0]["com_address"].ToString();
    //            lbl_company_contact.Text = dt2.Rows[0]["com_contact"].ToString();
    //            lbl_company_email.Text = dt2.Rows[0]["com_email"].ToString();
    //            Image1.ImageUrl = "~/Company/Company_Photos/" + dt2.Rows[0]["com_company_logo"].ToString();
    //        }


    //        SqlCommand cmd3 = new SqlCommand("select sum(pu_total) from tbl_purchase inner join tbl_vendor on tbl_purchase.v_id=tbl_vendor.v_id where tbl_purchase.v_id='" + Dd_customer.SelectedValue + "'", conn);
    //        SqlDataAdapter adapt3 = new SqlDataAdapter(cmd3);
    //        DataTable dt3 = new DataTable();
    //        adapt3.Fill(dt3);
    //        if (dt3.Rows.Count > 0)
    //        {
    //            lbl_invoice_amount.Text = dt3.Rows[0][0].ToString();
    //            if (dt3.Rows[0][0] == System.DBNull.Value)
    //            {
    //                amount = 0;
    //            }
    //            else
    //            {
    //                amount = Convert.ToDecimal(dt3.Rows[0][0]);
    //            }

    //        }

    //        SqlCommand cmd4 = new SqlCommand("select sum(pi_pay) from tbl_purchase_invoice_payment inner join tbl_vendor on tbl_purchase_invoice_payment.v_id=tbl_vendor.v_id where tbl_purchase_invoice_payment.v_id='" + Dd_customer.SelectedValue + "'", conn);
    //        SqlDataAdapter adapt4 = new SqlDataAdapter(cmd4);
    //        DataTable dt4 = new DataTable();

    //        adapt4.Fill(dt4);
    //        if (dt4.Rows.Count > 0)
    //        {
    //            lbl_amount_paid.Text = dt4.Rows[0][0].ToString();
    //            if (dt4.Rows[0][0] == System.DBNull.Value)
    //            {
    //                paid = 0;
    //            }
    //            else
    //            {
    //                paid = Convert.ToDecimal(dt4.Rows[0][0]);
    //            }


    //            balance = amount - paid;
    //            lbl_balance_amount.Text = balance.ToString();
    //            lbl_due_balance.Text = balance.ToString();
                

    //        }
    //    }
    //    else
    //    {
    //        Panel1.Visible = true;
    //        SqlCommand cmd = new SqlCommand("select * from tbl_purchase_invoice_payment inner join tbl_vendor on tbl_purchase_invoice_payment.v_id=tbl_vendor.v_id where tbl_purchase_invoice_payment.v_id ='" + Dd_customer.SelectedValue + "' AND pi_date between '" + Date1.Text + "' AND '" + Date2.Text + "'", conn);
    //        SqlDataAdapter adapt = new SqlDataAdapter(cmd);
    //        DataTable dt = new DataTable();
    //        adapt.Fill(dt);
    //        if (dt.Rows.Count > 0)
    //        {
    //            Repeater2.DataSource = dt;
    //            Repeater2.DataBind();

    //            lbl_customer_name.Text = dt.Rows[0]["v_name"].ToString();
    //            lbl_customer_contact.Text = dt.Rows[0]["v_contact"].ToString();
    //            lbl_customer_address.Text = dt.Rows[0]["v_address"].ToString();
    //            lbl_gst_no.Text = dt.Rows[0]["v_gst_no"].ToString();

    //        }

    //        SqlCommand cmd2 = new SqlCommand("select * from tbl_company_details where com_id = 1", conn);
    //        SqlDataAdapter adapt2 = new SqlDataAdapter(cmd2);
    //        DataTable dt2 = new DataTable();
    //        adapt2.Fill(dt2);
    //        if (dt2.Rows.Count > 0)
    //        {
    //            lbl_company_name.Text = dt2.Rows[0]["com_company_name"].ToString();
    //            lbl_company_address.Text = dt2.Rows[0]["com_address"].ToString();
    //            lbl_company_contact.Text = dt2.Rows[0]["com_contact"].ToString();
    //            lbl_company_email.Text = dt2.Rows[0]["com_email"].ToString();
    //            Image1.ImageUrl = "~/Company/Company_Photos/" + dt2.Rows[0]["com_company_logo"].ToString();
    //        }



    //        SqlCommand cmd3 = new SqlCommand("select sum(pu_total) from tbl_purchase inner join tbl_vendor on tbl_purchase.v_id=tbl_vendor.v_id where tbl_purchase.v_id='" + Dd_customer.SelectedValue + "' AND pu_invoice_date between '" + Date1.Text + "' AND '" + Date2.Text + "' ", conn);
    //        SqlDataAdapter adapt3 = new SqlDataAdapter(cmd3);
    //        DataTable dt3 = new DataTable();
    //        adapt3.Fill(dt3);
    //        if (dt3.Rows.Count > 0)
    //        {
    //            lbl_invoice_amount.Text = dt3.Rows[0][0].ToString();
    //            if (dt3.Rows[0][0] == System.DBNull.Value)
    //            {
    //                amount = 0;
    //            }
    //            else
    //            {
    //                amount = Convert.ToDecimal(dt3.Rows[0][0]);
    //            }

    //        }

    //        SqlCommand cmd4 = new SqlCommand("select sum(pi_pay) from tbl_purchase_invoice_payment inner join tbl_vendor on tbl_purchase_invoice_payment.v_id=tbl_vendor.v_id where tbl_purchase_invoice_payment.v_id='" + Dd_customer.SelectedValue + "' AND pi_date between '" + Date1.Text + "' AND '" + Date2.Text + "'", conn);
    //        SqlDataAdapter adapt4 = new SqlDataAdapter(cmd4);
    //        DataTable dt4 = new DataTable();

    //        adapt4.Fill(dt4);
    //        if (dt4.Rows.Count > 0)
    //        {
    //            lbl_amount_paid.Text = dt4.Rows[0][0].ToString();
    //            if (dt4.Rows[0][0] == System.DBNull.Value)
    //            {
    //                paid = 0;
    //            }
    //            else
    //            {
    //                paid = Convert.ToDecimal(dt4.Rows[0][0]);
    //            }


    //            balance = amount - paid;
    //            lbl_balance_amount.Text = balance.ToString();
    //            lbl_due_balance.Text = balance.ToString();
    //            lbl_due_balance.Text = balance.ToString();


    //        }
    //    }

    //}

	protected void Btn_search_Click(object sender, EventArgs e)
	{
		Repeater2.DataSource = null;
		Repeater2.DataBind();

		if (Date1.Text == "" || Date2.Text == "" && Dd_customer.SelectedValue!="--Select--")
		{
			Panel1.Visible = true;
			SqlCommand cmd = new SqlCommand("select * from tbl_purchase_invoice_payment inner join tbl_vendor on tbl_purchase_invoice_payment.v_id=tbl_vendor.v_id where tbl_purchase_invoice_payment.v_id ='" + Dd_customer.SelectedValue + "'", conn);
			SqlDataAdapter adapt = new SqlDataAdapter(cmd);
			DataTable dt = new DataTable();
			adapt.Fill(dt);
			if (dt.Rows.Count > 0)
			{
				Repeater2.DataSource = dt;
				Repeater2.DataBind();

				lbl_customer_name.Text = dt.Rows[0]["v_name"].ToString();
				lbl_customer_contact.Text = dt.Rows[0]["v_contact"].ToString();
				lbl_customer_address.Text = dt.Rows[0]["v_address"].ToString();
				lbl_gst_no.Text = dt.Rows[0]["v_gst_no"].ToString();

			}

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
				Image1.ImageUrl = "~/Company/Company_Photos/" + dt2.Rows[0]["com_company_logo"].ToString();
			}


			SqlCommand cmd3 = new SqlCommand("select sum(pu_total) from tbl_purchase inner join tbl_vendor on tbl_purchase.v_id=tbl_vendor.v_id where tbl_purchase.v_id='" + Dd_customer.SelectedValue + "'", conn);
			SqlDataAdapter adapt3 = new SqlDataAdapter(cmd3);
			DataTable dt3 = new DataTable();
			adapt3.Fill(dt3);
			if (dt3.Rows.Count > 0)
			{
				lbl_invoice_amount.Text = dt3.Rows[0][0].ToString();
				if (dt3.Rows[0][0] == System.DBNull.Value)
				{
					amount = 0;
				}
				else
				{
					amount = Convert.ToDecimal(dt3.Rows[0][0]);
				}

			}

			SqlCommand cmd4 = new SqlCommand("select sum(pi_pay) from tbl_purchase_invoice_payment inner join tbl_vendor on tbl_purchase_invoice_payment.v_id=tbl_vendor.v_id where tbl_purchase_invoice_payment.v_id='" + Dd_customer.SelectedValue + "'", conn);
			SqlDataAdapter adapt4 = new SqlDataAdapter(cmd4);
			DataTable dt4 = new DataTable();

			adapt4.Fill(dt4);
			if (dt4.Rows.Count > 0)
			{
				lbl_amount_paid.Text = dt4.Rows[0][0].ToString();
				if (dt4.Rows[0][0] == System.DBNull.Value)
				{
					paid = 0;
				}
				else
				{
					paid = Convert.ToDecimal(dt4.Rows[0][0]);
				}


				balance = amount - paid;
				lbl_balance_amount.Text = balance.ToString();
				lbl_due_balance.Text = balance.ToString();


			}
		}
		else if (Date1.Text != "" || Date2.Text != "" && Dd_customer.SelectedValue!="--Select--")
		{
			Panel1.Visible = true;
			SqlCommand cmd = new SqlCommand("select * from tbl_purchase_invoice_payment inner join tbl_vendor on tbl_purchase_invoice_payment.v_id=tbl_vendor.v_id where tbl_purchase_invoice_payment.v_id ='" + Dd_customer.SelectedValue + "' AND pi_date between '" + Date1.Text + "' AND '" + Date2.Text + "'", conn);
			SqlDataAdapter adapt = new SqlDataAdapter(cmd);
			DataTable dt = new DataTable();
			adapt.Fill(dt);
			if (dt.Rows.Count > 0)
			{
				Repeater2.DataSource = dt;
				Repeater2.DataBind();

				lbl_customer_name.Text = dt.Rows[0]["v_name"].ToString();
				lbl_customer_contact.Text = dt.Rows[0]["v_contact"].ToString();
				lbl_customer_address.Text = dt.Rows[0]["v_address"].ToString();
				lbl_gst_no.Text = dt.Rows[0]["v_gst_no"].ToString();

			}

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
				Image1.ImageUrl = "~/Company/Company_Photos/" + dt2.Rows[0]["com_company_logo"].ToString();
			}



			SqlCommand cmd3 = new SqlCommand("select sum(pu_total) from tbl_purchase inner join tbl_vendor on tbl_purchase.v_id=tbl_vendor.v_id where tbl_purchase.v_id='" + Dd_customer.SelectedValue + "' AND pu_invoice_date between '" + Date1.Text + "' AND '" + Date2.Text + "' ", conn);
			SqlDataAdapter adapt3 = new SqlDataAdapter(cmd3);
			DataTable dt3 = new DataTable();
			adapt3.Fill(dt3);
			if (dt3.Rows.Count > 0)
			{
				lbl_invoice_amount.Text = dt3.Rows[0][0].ToString();
				if (dt3.Rows[0][0] == System.DBNull.Value)
				{
					amount = 0;
				}
				else
				{
					amount = Convert.ToDecimal(dt3.Rows[0][0]);
				}

			}

			SqlCommand cmd4 = new SqlCommand("select sum(pi_pay) from tbl_purchase_invoice_payment inner join tbl_vendor on tbl_purchase_invoice_payment.v_id=tbl_vendor.v_id where tbl_purchase_invoice_payment.v_id='" + Dd_customer.SelectedValue + "' AND pi_date between '" + Date1.Text + "' AND '" + Date2.Text + "'", conn);
			SqlDataAdapter adapt4 = new SqlDataAdapter(cmd4);
			DataTable dt4 = new DataTable();

			adapt4.Fill(dt4);
			if (dt4.Rows.Count > 0)
			{
				lbl_amount_paid.Text = dt4.Rows[0][0].ToString();
				if (dt4.Rows[0][0] == System.DBNull.Value)
				{
					paid = 0;
				}
				else
				{
					paid = Convert.ToDecimal(dt4.Rows[0][0]);
				}


				balance = amount - paid;
				lbl_balance_amount.Text = balance.ToString();
				lbl_due_balance.Text = balance.ToString();
				lbl_due_balance.Text = balance.ToString();


			}
		}


		else
		{ 
			Panel1.Visible = true;
			SqlCommand cmd = new SqlCommand("select * from tbl_purchase_invoice_payment inner join tbl_vendor on tbl_purchase_invoice_payment.v_id=tbl_vendor.v_id ", conn);
			SqlDataAdapter adapt = new SqlDataAdapter(cmd);
			DataTable dt = new DataTable();
			adapt.Fill(dt);
			if (dt.Rows.Count > 0)
			{
				Repeater2.DataSource = dt;
				Repeater2.DataBind();

				lbl_customer_name.Text = dt.Rows[0]["v_name"].ToString();
				lbl_customer_contact.Text = dt.Rows[0]["v_contact"].ToString();
				lbl_customer_address.Text = dt.Rows[0]["v_address"].ToString();
				lbl_gst_no.Text = dt.Rows[0]["v_gst_no"].ToString();

			}

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
				Image1.ImageUrl = "~/Company/Company_Photos/" + dt2.Rows[0]["com_company_logo"].ToString();
			}



			SqlCommand cmd3 = new SqlCommand("select sum(pu_total) from tbl_purchase inner join tbl_vendor on tbl_purchase.v_id=tbl_vendor.v_id where pu_invoice_date between '" + Date1.Text + "' AND '" + Date2.Text + "' ", conn);
			SqlDataAdapter adapt3 = new SqlDataAdapter(cmd3);
			DataTable dt3 = new DataTable();
			adapt3.Fill(dt3);
			if (dt3.Rows.Count > 0)
			{
				lbl_invoice_amount.Text = dt3.Rows[0][0].ToString();
				if (dt3.Rows[0][0] == System.DBNull.Value)
				{
					amount = 0;
				}
				else
				{
					amount = Convert.ToDecimal(dt3.Rows[0][0]);
				}

			}

			SqlCommand cmd4 = new SqlCommand("select sum(pi_pay) from tbl_purchase_invoice_payment inner join tbl_vendor on tbl_purchase_invoice_payment.v_id=tbl_vendor.v_id where  pi_date between '" + Date1.Text + "' AND '" + Date2.Text + "'", conn);
			SqlDataAdapter adapt4 = new SqlDataAdapter(cmd4);
			DataTable dt4 = new DataTable();

			adapt4.Fill(dt4);
			if (dt4.Rows.Count > 0)
			{
				lbl_amount_paid.Text = dt4.Rows[0][0].ToString();
				if (dt4.Rows[0][0] == System.DBNull.Value)
				{
					paid = 0;
				}
				else
				{
					paid = Convert.ToDecimal(dt4.Rows[0][0]);
				}


				balance = amount - paid;
				lbl_balance_amount.Text = balance.ToString();
				lbl_due_balance.Text = balance.ToString();
				lbl_due_balance.Text = balance.ToString();


			}
		}
	}
}