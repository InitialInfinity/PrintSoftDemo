using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using System.Drawing;

public partial class Purchase_roll_payment : System.Web.UI.Page
{
    SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["String"].ConnectionString);
    SqlCommand cmd2, cmd3, cmd4, cmd5;
    SqlDataAdapter adapt2, adapt3, adapt4, adapt5;
    DataTable dt, dt1, dt2, dt3, dt4, dt5;
    readonly PagedDataSource _pgsource = new PagedDataSource();
    int _firstIndex, _lastIndex;
    private int _pageSize = 10;
    string invoice;
    decimal balance, opening, newbalance;
    protected void Page_Load(object sender, EventArgs e)
    {

        if (Session["a_email"] != null)
        {
            invoice = Request.QueryString["invoice"].ToString();
            if (Page.IsPostBack) return;
            Txt_date.Text = DateTime.Today.ToString("yyyy-MM-dd");
            fill();
            FillRepeater();
            Txt_pay.Text = "0";
            

        }
        else
        {
            Response.Redirect("../login.aspx");
        }
        if (Dd_payment_mode.SelectedValue != "Cheque")
        {
            // Txt_date.Text = DateTime.Today.ToString("yyyy-MM-dd");
            Txt_date.ReadOnly = true;
        }
        else
        {
            // Txt_date.Text = DateTime.Today.ToString("yyyy-MM-dd");
            Txt_date.ReadOnly = false;

        }
    }
    protected void fill()
    {

        cmd5 = new SqlCommand("select * from tbl_roll_purchase inner join tbl_vendor on tbl_roll_purchase.v_id=tbl_vendor.v_id where rpu_invoice_no ='" + invoice + "'", conn);
        adapt5 = new SqlDataAdapter(cmd5);
        dt5 = new DataTable();

        adapt5.Fill(dt5);
        if (dt5.Rows.Count > 0)
        {
            Txt_invoice.Text = invoice;
            lbl_id.Value = dt5.Rows[0]["v_id"].ToString();
            Txt_customer.Text = dt5.Rows[0]["v_name"].ToString();
            Txt_due_amount.Text = dt5.Rows[0]["rpu_balance"].ToString();


        }

    }





    public void FillRepeater()
    {
        cmd2 = new SqlCommand("select * from tbl_roll_purchase_invoice_payment inner join tbl_vendor on tbl_roll_purchase_invoice_payment.v_id=tbl_vendor.v_id where rpi_invoice='" + invoice + "' Order By rpi_id desc", conn);
        adapt2 = new SqlDataAdapter(cmd2);
        dt1 = new DataTable();
        adapt2.Fill(dt1);
        if (dt1.Rows.Count > 0)
        {
            Repeater1.DataSource = dt1;
            Repeater1.DataBind();
        }
    }




    protected void Btn_submit_Click(object sender, EventArgs e)
    {

        try
        {
            SqlCommand cmd = new SqlCommand("insert into tbl_roll_purchase_invoice_payment values(@rpi_invoice,@v_id,@rpi_due,@rpi_pay,@rpi_mode,@rpi_balance,@rpi_date)", conn);
            cmd.Parameters.AddWithValue("@rpi_invoice", Convert.ToString(Txt_invoice.Text));

            cmd.Parameters.AddWithValue("@v_id", Convert.ToString(lbl_id.Value));
            cmd.Parameters.AddWithValue("@rpi_due", Convert.ToDecimal(Txt_due_amount.Text));
            cmd.Parameters.AddWithValue("@rpi_pay", Convert.ToDecimal(Txt_pay.Text));
            cmd.Parameters.AddWithValue("@rpi_mode", Convert.ToString(Dd_payment_mode.Text));
            cmd.Parameters.AddWithValue("@rpi_balance", Convert.ToDecimal(Lbl_total_balance.Text));
            cmd.Parameters.AddWithValue("@rpi_date", Convert.ToDateTime(DateTime.Now.ToShortDateString()).ToString("MM/dd/yyyy"));


            conn.Open();
            cmd.ExecuteNonQuery();

            conn.Close();

        }
        catch (Exception ex) { }


        try
        {
            SqlCommand cmd2 = new SqlCommand("update tbl_roll_purchase set rpu_balance='" + Lbl_total_balance.Text + "' where rpu_invoice_no='" + invoice + "'", conn);


            conn.Open();
            cmd2.ExecuteNonQuery();

            conn.Close();

            SqlCommand cmd3 = new SqlCommand("update tbl_roll_purchase_invoice set rpc_balance='" + Lbl_total_balance.Text + "' where rpc_invoice_no='" + invoice + "'", conn);


            conn.Open();
            cmd3.ExecuteNonQuery();

            conn.Close();

            balance = Convert.ToDecimal(Txt_pay.Text);
            SqlCommand cmd4 = new SqlCommand("update tbl_vendor set v_opening_balance=v_opening_balance - '" + balance + "' where v_id='" + lbl_id.Value + "'", conn);
            
            conn.Open();
            cmd4.ExecuteNonQuery();

            conn.Close();
            string redirectScript = " window.location.href = 'roll_bill.aspx?invoice=" + invoice + "';";
            System.Web.UI.ScriptManager.RegisterStartupScript(this, GetType(), "displayalertmessage", "alert('Payment Updated Successfully!!!');" + redirectScript, true);


        }
        catch (Exception ex) { }
    }




    protected void Dd_payment_mode_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (Dd_payment_mode.SelectedValue == "Cheque")
        {
            Txt_date.ReadOnly = false;

        }
        else
        {
            Txt_date.ReadOnly = true;

        }
    }
}