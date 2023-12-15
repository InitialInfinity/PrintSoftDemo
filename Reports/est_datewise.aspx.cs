using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

public partial class Reports_est_datewise : System.Web.UI.Page
{
    SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["String"].ConnectionString);
    decimal balance, bal;
    int del_inv, c_id;
    string insert;
    string admin_email;
    protected void Page_Load(object sender, EventArgs e)
    {

        if (Session["a_email"] != null)
        {
            if (Page.IsPostBack) return;
            this.FillRepeater();
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
            Dd_customer.Items.Insert(0, new System.Web.UI.WebControls.ListItem("--Select--", "--Select--"));
            Dd_customer.SelectedItem.Selected = false;
            Dd_customer.Items.FindByText("--Select--").Selected = true;
        }

    }
    public void FillRepeater()
    {
        SqlCommand cmd = new SqlCommand("select * from tbl_estimate inner join tbl_customer on tbl_estimate.c_id=tbl_customer.c_id order by est_id desc", conn);
        SqlDataAdapter adapt = new SqlDataAdapter(cmd);
        DataTable dt = new DataTable();
        adapt.Fill(dt);
        if (dt.Rows.Count > 0)
        {
            Repeater1.DataSource = dt;
            Repeater1.DataBind();

            lbl_total_invoice_amount.Text = dt.Compute("Sum(est_total)", string.Empty).ToString();
            lbl_total_invoice.Text = dt.Compute("count(est_id)", string.Empty).ToString();
            Lbl_balance.Text = dt.Compute("Sum(est_balance)", string.Empty).ToString();

            lbl_Advance.Text = dt.Compute("Sum(est_adjustment)", string.Empty).ToString();
            lblTBalance.Text = dt.Compute("Sum(est_balance)", string.Empty).ToString();
            lblTInvoiceAmount.Text = dt.Compute("Sum(est_total)", string.Empty).ToString();
        }
        else
        {
            Panel1.Visible = false;
            lbl_total_invoice.Text = "0";
            lbl_total_invoice_amount.Text = "0";
            Lbl_balance.Text = "0";
        }

        //SqlCommand cmd2 = new SqlCommand("select sum(si_pay) from tbl_sale_invoice_payment  order by si_id desc", conn);
        //SqlDataAdapter adapt2 = new SqlDataAdapter(cmd2);
        //DataTable dt2 = new DataTable();
        //adapt.Fill(dt2);
        //if (dt2.Rows.Count > 0)
        //{
        //    if (dt2.Rows[0][0] == System.DBNull.Value)
        //    {
        //        Lbl_advace.Text = "0";
        //    }
        //    else
        //    {
        //        Lbl_advace.Text = dt2.Rows[0][0].ToString();
        //    }
        //}
    }




    protected void DeleteSale(object sender, EventArgs e)
    {
        SqlCommand cmd = new SqlCommand("select * from tbl_admin_login", conn);
        SqlDataAdapter adapt = new SqlDataAdapter(cmd);
        DataTable dt = new DataTable();
        adapt.Fill(dt);
        if (dt.Rows.Count > 0)
        {
            admin_email = dt.Rows[0]["a_email"].ToString();
        }
        if (admin_email.ToString() == Session["a_email"].ToString() || Session["admin_email"] != null)
        {
            String invoiceno = ((sender as LinkButton).NamingContainer.FindControl("lbl_invoice") as Label).Text;

            using (SqlCommand cmd2 = new SqlCommand("select * from tbl_estimate where est_invoice_no='" + invoiceno + "'", conn))
            {

                SqlDataAdapter adapt2 = new SqlDataAdapter(cmd2);
                DataTable dt2 = new DataTable();
                adapt2.Fill(dt2);
                if (dt2.Rows.Count > 0)
                {
                    bal = Convert.ToDecimal(dt2.Rows[0]["est_balance"]);
                    c_id = Convert.ToInt32(dt2.Rows[0]["c_id"]);

                }
            }
            using (SqlCommand cmd3 = new SqlCommand("update tbl_customer set c_opening_balance=c_opening_balance- '" + bal + "' where c_id='" + c_id + "'", conn))
            {
                conn.Open();
                cmd3.ExecuteNonQuery();
                conn.Close();
            }
            using (SqlCommand cmd4 = new SqlCommand("DELETE FROM tbl_estimate_details WHERE es_invoice_no = @s_invoice_no", conn))
            {

                cmd4.Parameters.AddWithValue("@s_invoice_no", invoiceno);
                conn.Open();
                cmd4.ExecuteNonQuery();
                conn.Close();
            }
            using (SqlCommand cmd5 = new SqlCommand("DELETE FROM tbl_estimate WHERE est_invoice_no = @sl_invoice_no", conn))
            {
                cmd5.Parameters.AddWithValue("@sl_invoice_no", invoiceno);
                conn.Open();
                cmd5.ExecuteNonQuery();
                conn.Close();
            }
            using (SqlCommand cmd6 = new SqlCommand("DELETE FROM tbl_sale_invoice_payment WHERE si_invoice = @sl_invoice_no", conn))
            {
                cmd6.Parameters.AddWithValue("@sl_invoice_no", invoiceno);
                conn.Open();
                cmd6.ExecuteNonQuery();
                conn.Close();
            }

            Response.Redirect(Request.RawUrl);
        }
        else
        {
            Response.Redirect("../access_denied.aspx");

        }
    }
    

    protected void Btn_search_Click(object sender, EventArgs e)
    {
        if (Txt_date1.Text == "" || Txt_date2.Text == "" && Dd_customer.SelectedValue != "--Select--")
        {
            SqlCommand cmd = new SqlCommand("select * from tbl_estimate inner join tbl_customer on tbl_estimate.c_id=tbl_customer.c_id where tbl_estimate.c_id =  '" + Dd_customer.SelectedValue + "' Order By est_id desc", conn);
            SqlDataAdapter adapt = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapt.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                Repeater1.DataSource = dt;
                Repeater1.DataBind();

                lbl_total_invoice_amount.Text = dt.Compute("Sum(est_total)", string.Empty).ToString();
                lbl_total_invoice.Text = dt.Compute("count(est_id)", string.Empty).ToString();
                Lbl_balance.Text = dt.Compute("Sum(est_balance)", string.Empty).ToString();

                lbl_Advance.Text = dt.Compute("Sum(est_adjustment)", string.Empty).ToString();
                lblTBalance.Text = dt.Compute("Sum(est_balance)", string.Empty).ToString();
                lblTInvoiceAmount.Text = dt.Compute("Sum(est_total)", string.Empty).ToString();
            }
            else
            {
                Panel1.Visible = false;
                Panel2.Visible = false;
                Repeater1.DataSource = null;
                Repeater1.DataBind();
                lbl_total_invoice.Text = "0";
                lbl_total_invoice_amount.Text = "0";
                Lbl_balance.Text = "0";
            }
        }
        else if (Txt_date1.Text != "" && Txt_date2.Text != "" && Dd_customer.SelectedValue == "--Select--")
        {
            SqlCommand cmd = new SqlCommand("select * from tbl_estimate inner join tbl_customer on tbl_estimate.c_id=tbl_customer.c_id where est_invoice_date Between '" + Txt_date1.Text + "' and '" + Txt_date2.Text + "' Order By est_id desc", conn);
            SqlDataAdapter adapt = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapt.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                Repeater1.DataSource = dt;
                Repeater1.DataBind();

                lbl_total_invoice_amount.Text = dt.Compute("Sum(est_total)", string.Empty).ToString();
                lbl_total_invoice.Text = dt.Compute("count(est_id)", string.Empty).ToString();
                Lbl_balance.Text = dt.Compute("Sum(est_balance)", string.Empty).ToString();

                lbl_Advance.Text = dt.Compute("Sum(est_adjustment)", string.Empty).ToString();
                lblTBalance.Text = dt.Compute("Sum(est_balance)", string.Empty).ToString();
                lblTInvoiceAmount.Text = dt.Compute("Sum(est_total)", string.Empty).ToString();
            }
            else
            {
                Panel1.Visible = false;
                Repeater1.DataSource = null;
                Repeater1.DataBind();
                lbl_total_invoice.Text = "0";
                lbl_total_invoice_amount.Text = "0";
                Lbl_balance.Text = "0";
            }
        }
        else if (Txt_date1.Text != "" && Txt_date2.Text != "" && Dd_customer.SelectedValue != "--Select--")
        {
            SqlCommand cmd = new SqlCommand("select * from tbl_estimate inner join tbl_customer on tbl_estimate.c_id=tbl_customer.c_id where tbl_estimate.c_id='" + Dd_customer.SelectedValue + "' AND est_invoice_date Between '" + Txt_date1.Text + "' and '" + Txt_date2.Text + "'  Order By est_id desc", conn);
            SqlDataAdapter adapt = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapt.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                Repeater1.DataSource = dt;
                Repeater1.DataBind();

                lbl_total_invoice_amount.Text = dt.Compute("Sum(est_total)", string.Empty).ToString();
                lbl_total_invoice.Text = dt.Compute("count(est_id)", string.Empty).ToString();
                Lbl_balance.Text = dt.Compute("Sum(est_balance)", string.Empty).ToString();

                lbl_Advance.Text = dt.Compute("Sum(est_adjustment)", string.Empty).ToString();
                lblTBalance.Text = dt.Compute("Sum(est_balance)", string.Empty).ToString();
                lblTInvoiceAmount.Text = dt.Compute("Sum(est_total)", string.Empty).ToString();
            }
            else
            {
                Panel1.Visible = false;
                Repeater1.DataSource = null;
                Repeater1.DataBind();
                lbl_total_invoice.Text = "0";
                lbl_total_invoice_amount.Text = "0";
                Lbl_balance.Text = "0";
            }
        }
        else if (Txt_date1.Text == "" && Txt_date2.Text == "" || Dd_customer.SelectedValue != "--Select--")
        {
            SqlCommand cmd = new SqlCommand("select * from tbl_estimate inner join tbl_customer on tbl_estimate.c_id=tbl_customer.c_id where tbl_estimate.c_id='" + Dd_customer.SelectedValue + "' AND est_invoice_date Between '" + Txt_date1.Text + "' and '" + Txt_date2.Text + "'  Order By est_id desc", conn);
            SqlDataAdapter adapt = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapt.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                Repeater1.DataSource = dt;
                Repeater1.DataBind();

                lbl_total_invoice_amount.Text = dt.Compute("Sum(est_total)", string.Empty).ToString();
                lbl_total_invoice.Text = dt.Compute("count(est_id)", string.Empty).ToString();
                Lbl_balance.Text = dt.Compute("Sum(est_balance)", string.Empty).ToString();

                lbl_Advance.Text = dt.Compute("Sum(est_adjustment)", string.Empty).ToString();
                lblTBalance.Text = dt.Compute("Sum(est_balance)", string.Empty).ToString();
                lblTInvoiceAmount.Text = dt.Compute("Sum(est_total)", string.Empty).ToString();
            }
            else
            {
                Panel1.Visible = false;
                Repeater1.DataSource = null;
                Repeater1.DataBind();
                lbl_total_invoice.Text = "0";
                lbl_total_invoice_amount.Text = "0";
                Lbl_balance.Text = "0";
            }
        }


    }
  

    protected void Repeater1_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {

        SqlCommand cmd = new SqlCommand("select * from tbl_feature", conn);
        SqlDataAdapter adapt = new SqlDataAdapter(cmd);
        DataTable dt = new DataTable();
        adapt.Fill(dt);
        if (dt.Rows.Count > 0)
        {

            del_inv = Convert.ToInt32(dt.Rows[0]["fe_del"]);
        }

        if (e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
        {
            Label tr = e.Item.FindControl("lbl_status") as Label;

            if (del_inv == 0)
            {
                e.Item.FindControl("LinkButton1").Visible = false;
            }
            else
            {
                e.Item.FindControl("LinkButton1").Visible = true;
            }

            DataRowView drv = e.Item.DataItem as DataRowView;
            decimal balance = Convert.ToDecimal(drv["est_balance"]);
            decimal total = Convert.ToDecimal(drv["est_total"]);

            if (balance == 0)
            {
                tr.Text = "Paid";
                tr.Attributes.Add("class", "label label-success");
            }
            else if (balance == total)
            {
                tr.Text = "UnPaid";
                tr.Attributes.Add("class", "label label-danger");
            }
            else
            {
                tr.Text = "Partially";
                tr.Attributes.Add("class", "label label-warning");
            }

        }

    }

}
