using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
public partial class Purchase_invoice_payment : System.Web.UI.Page
{
    SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["String"].ConnectionString);    string invoice;
    decimal balance, opening, newbalance;
    protected void Page_Load(object sender, EventArgs e)
    {
        Txt_pay.Focus();
        if (Session["a_email"] != null)
        {
            invoice = Request.QueryString["invoice"].ToString();
            if (Page.IsPostBack) return;
            Txt_date.Text = DateTime.Today.ToString("yyyy-MM-dd");
            fill();
            FillRepeater();

        }
        else
        {
            Response.Redirect("../login.aspx");
        }
    }
    protected void fill()
    {

        SqlCommand cmd = new SqlCommand("select * from tbl_purchase inner join tbl_vendor on tbl_purchase.v_id=tbl_vendor.v_id where pu_invoice_no ='" + invoice + "'", conn);
        SqlDataAdapter adapt = new SqlDataAdapter(cmd);
        DataTable dt = new DataTable();

        adapt.Fill(dt);
        if (dt.Rows.Count > 0)
        {
            Txt_invoice.Text = invoice;
            lbl_id.Value = dt.Rows[0]["v_id"].ToString();
            Txt_customer.Text = dt.Rows[0]["v_name"].ToString();
            Txt_due_amount.Text = dt.Rows[0]["pu_balance"].ToString();


        }

    }
    
    public void FillRepeater()
    {
        SqlCommand cmd = new SqlCommand("select * from tbl_purchase_invoice_payment inner join tbl_vendor on tbl_purchase_invoice_payment.v_id=tbl_vendor.v_id where pi_invoice='" + invoice + "' Order By pi_id desc", conn);
        SqlDataAdapter adapt = new SqlDataAdapter(cmd);
        DataTable dt = new DataTable();
        adapt.Fill(dt);
        if (dt.Rows.Count > 0)
        {
            Repeater1.DataSource = dt;
            Repeater1.DataBind();
        }
    }
    

    protected void Btn_submit_Click(object sender, EventArgs e)
    {

        try
        {
            SqlCommand cmd = new SqlCommand("insert into tbl_purchase_invoice_payment values(@pi_invoice,@v_id,@pi_due,@pi_pay,@pi_mode,@pi_balance,@pi_date)", conn);
            cmd.Parameters.AddWithValue("@pi_invoice", Convert.ToString(Txt_invoice.Text));

            cmd.Parameters.AddWithValue("@v_id", lbl_id.Value);
            cmd.Parameters.AddWithValue("@pi_due", Convert.ToDecimal(Txt_due_amount.Text));
            cmd.Parameters.AddWithValue("@pi_pay", Convert.ToDecimal(Txt_pay.Text));
            cmd.Parameters.AddWithValue("@pi_mode", Convert.ToString(Dd_payment_mode.Text));
            cmd.Parameters.AddWithValue("@pi_balance", Convert.ToDecimal(Lbl_total_balance.Text));
            cmd.Parameters.AddWithValue("@pi_date", Convert.ToDateTime(DateTime.Now.ToShortDateString()).ToString("MM/dd/yyyy"));


            conn.Open();
            cmd.ExecuteNonQuery();

            conn.Close();

            SqlCommand cmd2 = new SqlCommand("update tbl_purchase set pu_balance='" + Lbl_total_balance.Text + "' where pu_invoice_no='" + invoice + "'", conn);


            conn.Open();
            cmd2.ExecuteNonQuery();

            conn.Close();

            SqlCommand cmd3 = new SqlCommand("update tbl_purchase_invoice set pc_balance='" + Lbl_total_balance.Text + "' where pc_invoice_no='" + invoice + "'", conn);


            conn.Open();
            cmd3.ExecuteNonQuery();

            conn.Close();

            balance = Convert.ToDecimal(Txt_pay.Text);
            SqlCommand cmd4 = new SqlCommand("update tbl_vendor set v_opening_balance=v_opening_balance - '" + balance + "' where v_id='" + lbl_id.Value + "'", conn);


            conn.Open();
            cmd4.ExecuteNonQuery();

            conn.Close();
            string redirectScript = " window.location.href = 'bill.aspx?invoice=" + invoice + "';";
            System.Web.UI.ScriptManager.RegisterStartupScript(this, GetType(), "displayalertmessage", "alert('Payment Updated Successfully!!!');" + redirectScript, true);


        }
        catch (Exception ex) { }
    }



}