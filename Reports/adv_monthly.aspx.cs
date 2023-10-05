using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

public partial class Reports_adv_monthly : System.Web.UI.Page
{
    SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["String"].ConnectionString);

    decimal total_sale, total_est, total_amt, total_pur, total_exp, total_sal;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["a_email"] != null)
        {
            if (Page.IsPostBack) return;
            FillRepeater();
            FillRepeater2();
            FillRepeater3();
            FillRepeater4();
            FillRepeater5();
            FillRepeater6();
            FillRepeater7();


        }
        else
        {
            Response.Redirect("../login.aspx");
        }
    }

    public void FillRepeater()
    {
        SqlCommand cmd = new SqlCommand("Select * From tbl_sale INNER JOIN tbl_customer ON tbl_sale.c_id = tbl_customer.c_id WHERE sl_invoice_date >= DATEADD(MONTH, DATEDIFF(MONTH, 0, GETDATE()), 0) AND sl_invoice_date <  DATEADD(MONTH, DATEDIFF(MONTH, 0, GETDATE()) + 1, 0) Order By sl_id desc", conn);
        SqlDataAdapter adapt = new SqlDataAdapter(cmd);
        DataTable dt = new DataTable();
        adapt.Fill(dt);
        if (dt.Rows.Count > 0)
        {
            Repeater1.DataSource = dt;
            Repeater1.DataBind();

            total_sale = Convert.ToDecimal(dt.Compute("Sum(sl_total)", string.Empty));
            lbl_bal.Text = dt.Compute("Sum(sl_balance)", string.Empty).ToString();
            lbl_Total.Text = dt.Compute("Sum(sl_total)", string.Empty).ToString();
        }
        else
        {
            Panel1.Visible = false;
            total_sale = 0;
        }


    }

    public void FillRepeater2()
    {
        SqlCommand cmd = new SqlCommand("Select * From tbl_estimate INNER JOIN tbl_customer ON tbl_estimate.c_id = tbl_customer.c_id WHERE est_invoice_date >= DATEADD(MONTH, DATEDIFF(MONTH, 0, GETDATE()), 0) AND est_invoice_date <  DATEADD(MONTH, DATEDIFF(MONTH, 0, GETDATE()) + 1, 0) Order By est_id desc", conn);
        SqlDataAdapter adapt = new SqlDataAdapter(cmd);
        DataTable dt = new DataTable();
        adapt.Fill(dt);
        if (dt.Rows.Count > 0)
        {
            Repeater2.DataSource = dt;
            Repeater2.DataBind();

            total_est = Convert.ToDecimal(dt.Compute("Sum(est_total)", string.Empty));

            lblest_bal.Text = dt.Compute("Sum(est_balance)", string.Empty).ToString();
            lblest_total.Text = dt.Compute("Sum(est_total)", string.Empty).ToString();
        }
        else
        {
            Panel2.Visible = false;
            total_est = 0;
        }
    }

    public void FillRepeater3()
    {
        SqlCommand cmd = new SqlCommand("Select * From tbl_purchase  INNER JOIN tbl_vendor ON tbl_purchase.v_id = tbl_vendor.v_id  WHERE pu_invoice_date >= DATEADD(MONTH, DATEDIFF(MONTH, 0, GETDATE()), 0) AND pu_invoice_date <  DATEADD(MONTH, DATEDIFF(MONTH, 0, GETDATE()) + 1, 0) Order By pu_id desc", conn);
        SqlDataAdapter adapt = new SqlDataAdapter(cmd);
        DataTable dt = new DataTable();
        adapt.Fill(dt);
        if (dt.Rows.Count > 0)
        {
            Repeater3.DataSource = dt;
            Repeater3.DataBind();

            total_pur = Convert.ToDecimal(dt.Compute("Sum(pu_total)", string.Empty));
            lbl_total_pur.Text = dt.Compute("Sum(pu_total)", string.Empty).ToString();
            lblpu_bal.Text = dt.Compute("Sum(pu_balance)", string.Empty).ToString();
            lblpu_total.Text = dt.Compute("Sum(pu_total)", string.Empty).ToString();
        }
        else
        {
            Panel3.Visible = false;
            total_pur = 0;
            lbl_total_pur.Text = "0";
        }
    }

    public void FillRepeater4()
    {
        SqlCommand cmd = new SqlCommand("Select * From tbl_expense WHERE e_date >= DATEADD(MONTH, DATEDIFF(MONTH, 0, GETDATE()), 0) AND e_date <  DATEADD(MONTH, DATEDIFF(MONTH, 0, GETDATE()) + 1, 0) Order By e_id desc", conn);
        SqlDataAdapter adapt = new SqlDataAdapter(cmd);
        DataTable dt = new DataTable();
        adapt.Fill(dt);
        if (dt.Rows.Count > 0)
        {
            Repeater4.DataSource = dt;
            Repeater4.DataBind();

            total_exp = Convert.ToDecimal(dt.Compute("Sum(e_amount)", string.Empty));
            lbl_total_exp.Text = dt.Compute("Sum(e_amount)", string.Empty).ToString();
            lbletotal.Text = dt.Compute("Sum(e_amount)", string.Empty).ToString();
        }
        else
        {
            Panel4.Visible = false;
            total_exp = 0;
            lbl_total_exp.Text = "0";
        }
    }

    public void FillRepeater5()
    {
        SqlCommand cmd = new SqlCommand("Select * From tbl_salary INNER JOIN tbl_staff ON tbl_salary.st_id = tbl_staff.st_id WHERE sal_date >= DATEADD(MONTH, DATEDIFF(MONTH, 0, GETDATE()), 0) AND sal_date <  DATEADD(MONTH, DATEDIFF(MONTH, 0, GETDATE()) + 1, 0) Order By sal_id desc", conn);
        SqlDataAdapter adapt = new SqlDataAdapter(cmd);
        DataTable dt = new DataTable();
        adapt.Fill(dt);
        if (dt.Rows.Count > 0)
        {
            Repeater5.DataSource = dt;
            Repeater5.DataBind();

            total_sal = Convert.ToDecimal(dt.Compute("Sum(sal_pay)", string.Empty));
            lbl_total_sal.Text = dt.Compute("Sum(sal_pay)", string.Empty).ToString();

            lblpaysal.Text = dt.Compute("Sum(sal_pay)", string.Empty).ToString();
            lblbalsal.Text = dt.Compute("Sum(sal_deduction)", string.Empty).ToString();
        }
        else
        {
            Panel5.Visible = false;
            total_sal = 0;
            lbl_total_sal.Text = "0";
        }
    }
    public void FillRepeater6()
    {
        SqlCommand cmd = new SqlCommand("Select * From tbl_sale_invoice_payment INNER JOIN tbl_customer ON tbl_sale_invoice_payment.c_id = tbl_customer.c_id WHERE si_date >= DATEADD(MONTH, DATEDIFF(MONTH, 0, GETDATE()), 0) AND si_date <  DATEADD(MONTH, DATEDIFF(MONTH, 0, GETDATE()) + 1, 0) order by si_date desc", conn);
        SqlDataAdapter adapt = new SqlDataAdapter(cmd);
        DataTable dt = new DataTable();
        adapt.Fill(dt);
        if (dt.Rows.Count > 0)
        {
            Repeater6.DataSource = dt;
            Repeater6.DataBind();

            lbl_total_adv.Text = dt.Compute("Sum(si_pay)", string.Empty).ToString();

            lblpayreport.Text = dt.Compute("Sum(si_pay)", string.Empty).ToString();
            lblbalreport.Text = dt.Compute("Sum(si_balance)", string.Empty).ToString();
        }
        else
        {
            Panel6.Visible = false;
            lbl_total_adv.Text = "0";
        }
    }
    public void FillRepeater7()
    {

        lbl_total_amt.Text = (total_sale + total_est).ToString();

        lbl_total_col.Text = (Convert.ToDecimal(lbl_total_adv.Text) - (total_pur + total_exp + total_sal)).ToString();
    }

}