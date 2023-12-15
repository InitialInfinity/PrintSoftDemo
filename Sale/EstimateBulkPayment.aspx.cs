using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Net;
using System.Text;
using System.Web.Routing;
using iTextSharp.tool.xml.css.parser.state;

public partial class Sale_EstimateBulkPayment : System.Web.UI.Page
{
    SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["String"].ConnectionString);
    string invoiceno;
    decimal balance, calculate, pay1, balances;
    decimal opening, newbalance, paycalculate,advance;
    protected void Page_Load(object sender, EventArgs e)
    {
        //if (!IsPostBack)
        //{
        this.FillRepeater();
		//    ScriptManager.RegisterStartupScript(this, GetType(), "HideModalBackdrop", "hideModalBackdrop();", true);
		//}


		DateTime serverTime = DateTime.UtcNow; // gets current time in server's time zone (UTC)
		TimeZoneInfo serverTimeZone = TimeZoneInfo.Utc; // assuming the server's time zone is UTC
		DateTime localTime = TimeZoneInfo.ConvertTime(serverTime, serverTimeZone, TimeZoneInfo.FindSystemTimeZoneById("India Standard Time")); // convert to custom local time zone

		txt_date.Text = localTime.ToString("yyyy-MM-dd");


	}
	public void FillRepeater()

    {
        SqlCommand cmd = new SqlCommand("select ROW_NUMBER() OVER (ORDER BY a.c_id) AS SrNo, sum(total) as Total,c_id,c_name,sum(balance) as Balance,sum(total_invoice)AS Total_invoice,max(Latest_Payment_Date)AS Latest_Payment_Date   from (select sum(e.est_total) as Total,c.c_id,c.c_name,sum(e.est_balance) as Balance,COUNT(e.est_invoice_no) AS Total_invoice,(select CONVERT(VARCHAR, MAX(si_date), 105) from tbl_sale_invoice_payment where si_invoice =e.est_invoice_no ) AS Latest_Payment_Date  from tbl_estimate e join tbl_customer c on e.c_id=c.c_id  where e.est_balance >'0' GROUP BY c.c_id, c.c_name,e.est_invoice_no)a group by c_id,c_name", conn);
        SqlDataAdapter adapt = new SqlDataAdapter(cmd);
        DataTable dt = new DataTable();
        adapt.Fill(dt);
        if (dt.Rows.Count > 0)
        {
            Repeater1.DataSource = dt;
            Repeater1.DataBind();


        }
    }


    protected void Repeater1_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {




    }

    protected void btn_add_Click(object sender, EventArgs e)
    {
        LinkButton btn = (LinkButton)sender;
        string cid = btn.CommandArgument;
        SqlCommand cmd2 = new SqlCommand("select ROW_NUMBER() OVER (ORDER BY a.c_id) AS SrNo, sum(total) as Total,c_id,c_name,sum(balance) as Balance,sum(total_invoice)AS Total_invoice,max(Latest_Payment_Date)AS Latest_Payment_Date   from (select sum(e.est_total) as Total,c.c_id,c.c_name,sum(e.est_balance) as Balance,COUNT(e.est_invoice_no) AS Total_invoice,(select CONVERT(VARCHAR, MAX(si_date), 105) from tbl_sale_invoice_payment where si_invoice =e.est_invoice_no ) AS Latest_Payment_Date  from tbl_estimate e join tbl_customer c on e.c_id=c.c_id  where e.est_balance >'0' and c.c_id=@c_id GROUP BY c.c_id, c.c_name,e.est_invoice_no)a group by c_id,c_name\r\n", conn);
        cmd2.Parameters.AddWithValue("@c_id", cid);
        SqlDataAdapter adapt = new SqlDataAdapter(cmd2);
        DataTable dt = new DataTable();
        adapt.Fill(dt);
        if (dt.Rows.Count > 0)
        {
            txt_cid.Text = dt.Rows[0]["c_id"].ToString();
            txt_customername.Text = dt.Rows[0]["c_name"].ToString();
            txt_totalamount.Text = dt.Rows[0]["Total"].ToString();
            txt_dueamount.Text = dt.Rows[0]["Balance"].ToString();
            txt_dueamount1.Text = dt.Rows[0]["Balance"].ToString();
        }
        ScriptManager.RegisterStartupScript(this, this.GetType(), "Modal", "ShowModel2();", true);
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        if (txt_chq.Text == "")
        {
            txt_chq.Text = "0";
        }

        SqlCommand cmd = new SqlCommand("insert into tbl_sale_bulk_payment (c_id,sp_mode,sp_totalpayment,sp_due,sp_pendingamt,sp_pay,sp_date,sp_upichqno)values(@c_id,@sp_mode,@sp_totalpayment,@sp_due,@sp_pendingamt,@sp_pay,@sp_date,@sp_upichqno);SELECT SCOPE_IDENTITY();", conn);
        cmd.Parameters.AddWithValue("@c_id", txt_cid.Text);
        cmd.Parameters.AddWithValue("@sp_mode", Dd_payment_mode.Text);
        cmd.Parameters.AddWithValue("@sp_totalpayment", txt_totalamount.Text);
        cmd.Parameters.AddWithValue("@sp_due", txt_dueamount.Text);
        decimal total = Convert.ToDecimal(txt_dueamount.Text) - Convert.ToDecimal(txt_pay.Text);

        cmd.Parameters.AddWithValue("@sp_pendingamt", total);
        cmd.Parameters.AddWithValue("@sp_pay", txt_pay.Text);
        cmd.Parameters.AddWithValue("@sp_date", txt_date.Text);
        cmd.Parameters.AddWithValue("@sp_upichqno", txt_chq.Text);
        conn.Open();
        int lastInsertedID = Convert.ToInt32(cmd.ExecuteScalar());
        cmd.ExecuteNonQuery();

        conn.Close();
        ScriptManager.RegisterStartupScript(this, this.GetType(), "Modal", "ShowModel3();", true);

        decimal pay = Convert.ToDecimal(txt_pay.Text);
        SqlCommand cmd1 = new SqlCommand("select est_invoice_no,est_balance from tbl_estimate where est_balance>'0' and c_id='" + txt_cid.Text + "'", conn);
        SqlDataAdapter adapt = new SqlDataAdapter(cmd1);
        DataTable dt = new DataTable();
        adapt.Fill(dt);
        if (dt.Rows.Count > 0)
        {
            int success = 0, fail=0;
            try
            {
               
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    if (pay == 0)
                        break;
                    success++;
                    invoiceno = dt.Rows[i]["est_invoice_no"].ToString();
                    balance = Convert.ToDecimal(dt.Rows[i]["est_balance"]);
                    paycalculate = pay;
                    if (balance <= pay)
                    {
                        advance = balance;
                        balances = balance;
                        pay1 = 0;
                        balance = 0;
                        calculate = 0;



                        SqlCommand cmd2 = new SqlCommand("insert into tbl_sale_invoice_payment values(@si_invoice,@c_id,@si_due,@si_discount,@si_pay,@si_mode,@si_chno,@si_balance,@si_date,@si_upichqno)", conn);
                        cmd2.Parameters.AddWithValue("@si_invoice", Convert.ToString(invoiceno));
                        cmd2.Parameters.AddWithValue("@c_id", Convert.ToString(txt_cid.Text));
                        cmd2.Parameters.AddWithValue("@si_due", Convert.ToDecimal(balance));
                        cmd2.Parameters.AddWithValue("@si_discount", Convert.ToDecimal(0));
                        cmd2.Parameters.AddWithValue("@si_pay", Convert.ToDecimal(pay1));
                        cmd2.Parameters.AddWithValue("@si_mode", Convert.ToString(Dd_payment_mode.Text));
                        cmd2.Parameters.AddWithValue("@si_chno", Convert.ToString(txt_chq.Text));
                        cmd2.Parameters.AddWithValue("@si_balance", Convert.ToDecimal(calculate));
                        cmd2.Parameters.AddWithValue("@si_date", Convert.ToDateTime(DateTime.Now.ToShortDateString()).ToString("MM/dd/yyyy"));
                        cmd2.Parameters.AddWithValue("@si_upichqno", "");
                        conn.Open();
                        cmd2.ExecuteNonQuery();
                        conn.Close();

                        SqlCommand cmd3 = new SqlCommand("update tbl_estimate set est_balance='" + calculate + "' where est_invoice_no='" + invoiceno + "'", conn);
                        conn.Open();
                        cmd3.ExecuteNonQuery();
                        conn.Close();


                        SqlCommand cmd4 = new SqlCommand("update tbl_estimate_details set es_balance='" + calculate + "' where es_invoice_no='" + invoiceno + "'", conn);
                        conn.Open();
                        cmd4.ExecuteNonQuery();
                        conn.Close();

                        SqlCommand cmd5 = new SqlCommand("select * from tbl_customer where c_id ='" + txt_cid.Text + "'", conn);
                        SqlDataAdapter adapt4 = new SqlDataAdapter(cmd5);
                        DataTable dt4 = new DataTable();

                        adapt4.Fill(dt4);
                        if (dt4.Rows.Count > 0)
                        {

                            opening = Convert.ToDecimal(dt4.Rows[0]["c_opening_balance"]);
                            balance = Convert.ToDecimal(pay1);
                            newbalance = opening - balance;

                        }

                        SqlCommand cmd6 = new SqlCommand("update tbl_customer set c_opening_balance='" + newbalance + "' where c_id='" + txt_cid.Text + "'", conn);
                        conn.Open();
                        cmd6.ExecuteNonQuery();
                        conn.Close();

                        decimal total_advance_amount = 0;
                        decimal Advance_payment = 0;

                        SqlCommand cmd33 = new SqlCommand("select est_adjustment from tbl_estimate where est_invoice_no='" + invoiceno + "'", conn);

                        SqlDataAdapter adapt33 = new SqlDataAdapter(cmd33);
                        DataTable dt33 = new DataTable();

                        adapt33.Fill(dt33);
                        if (dt33.Rows.Count > 0)
                        {
                            Advance_payment = Convert.ToDecimal(dt33.Rows[0]["est_adjustment"]);

							if (balance == 0)
							{
								total_advance_amount = Advance_payment + advance;
							}
							else
							{
								total_advance_amount = Advance_payment + balance;
							}

							SqlCommand cmd22 = new SqlCommand("update tbl_estimate set est_adjustment ='" + total_advance_amount + "' where est_invoice_no='" + invoiceno + "'", conn);

                            conn.Open();

                            cmd22.ExecuteNonQuery();
                            conn.Close();

                        }

                        pay = pay - balances;

                    }
                    else
                    {
                        invoiceno = dt.Rows[i]["est_invoice_no"].ToString();
                        balance = Convert.ToDecimal(dt.Rows[i]["est_balance"]);
                        if (balance > paycalculate)
                        {
							advance = balance;
							calculate = balance - pay;

                            SqlCommand cmd2 = new SqlCommand("insert into tbl_sale_invoice_payment values(@si_invoice,@c_id,@si_due,@si_discount,@si_pay,@si_mode,@si_chno,@si_balance,@si_date,@si_upichqno)", conn);
                            cmd2.Parameters.AddWithValue("@si_invoice", Convert.ToString(invoiceno));
                            cmd2.Parameters.AddWithValue("@c_id", Convert.ToString(txt_cid.Text));
                            cmd2.Parameters.AddWithValue("@si_due", Convert.ToDecimal(balance));
                            cmd2.Parameters.AddWithValue("@si_discount", Convert.ToDecimal(0));
                            cmd2.Parameters.AddWithValue("@si_pay", Convert.ToDecimal(pay));
                            cmd2.Parameters.AddWithValue("@si_mode", Convert.ToString(Dd_payment_mode.Text));
                            cmd2.Parameters.AddWithValue("@si_chno", Convert.ToString(txt_chq.Text));
                            cmd2.Parameters.AddWithValue("@si_balance", Convert.ToDecimal(calculate));
                            cmd2.Parameters.AddWithValue("@si_date", Convert.ToDateTime(DateTime.Now.ToShortDateString()).ToString("MM/dd/yyyy"));
                            cmd2.Parameters.AddWithValue("@si_upichqno", "");
                            conn.Open();
                            cmd2.ExecuteNonQuery();
                            conn.Close();

                            SqlCommand cmd3 = new SqlCommand("update tbl_estimate set est_balance='" + calculate + "' where est_invoice_no='" + invoiceno + "'", conn);
                            conn.Open();
                            cmd3.ExecuteNonQuery();
                            conn.Close();


                            SqlCommand cmd4 = new SqlCommand("update tbl_estimate_details set es_balance='" + calculate + "' where es_invoice_no='" + invoiceno + "'", conn);
                            conn.Open();
                            cmd4.ExecuteNonQuery();
                            conn.Close();

                            SqlCommand cmd5 = new SqlCommand("select * from tbl_customer where c_id ='" + txt_cid.Text + "'", conn);
                            SqlDataAdapter adapt4 = new SqlDataAdapter(cmd5);
                            DataTable dt4 = new DataTable();

                            adapt4.Fill(dt4);
                            if (dt4.Rows.Count > 0)
                            {

                                opening = Convert.ToDecimal(dt4.Rows[0]["c_opening_balance"]);
                                balance = Convert.ToDecimal(pay);
                                newbalance = opening - balance;

                            }

                            SqlCommand cmd6 = new SqlCommand("update tbl_customer set c_opening_balance='" + newbalance + "' where c_id='" + txt_cid.Text + "'", conn);
                            conn.Open();
                            cmd6.ExecuteNonQuery();
                            conn.Close();

                            decimal total_advance_amount = 0;
                            decimal Advance_payment = 0;

                            SqlCommand cmd33 = new SqlCommand("select est_adjustment from tbl_estimate where est_invoice_no='" + invoiceno + "'", conn);

                            SqlDataAdapter adapt33 = new SqlDataAdapter(cmd33);
                            DataTable dt33 = new DataTable();

                            adapt33.Fill(dt33);
                            if (dt33.Rows.Count > 0)
                            {
                                Advance_payment = Convert.ToDecimal(dt33.Rows[0]["est_adjustment"]);

								if (balance == 0)
								{
									total_advance_amount = Advance_payment + advance;
								}
								else
								{
									total_advance_amount = Advance_payment + balance;
								}

								SqlCommand cmd22 = new SqlCommand("update tbl_estimate set est_adjustment ='" + total_advance_amount + "' where est_invoice_no='" + invoiceno + "'", conn);

                                conn.Open();

                                cmd22.ExecuteNonQuery();
                                conn.Close();

                            }
                            pay = 0;
                        }
                    }

                }

                SqlCommand cmd222 = new SqlCommand("update tbl_sale_bulk_payment set sp_success='" + success + "' where sp_id='" + lastInsertedID + "'", conn);
                conn.Open();
                cmd222.ExecuteNonQuery();
                conn.Close();

               
            }
            catch 
            {
                fail ++;
                SqlCommand cmd22 = new SqlCommand("update tbl_sale_bulk_payment set sp_fail='" + fail + "' where sp_id='" + lastInsertedID + "'", conn);
                conn.Open();
                cmd22.ExecuteNonQuery();
                conn.Close();
            }

            int successfulInvoices = success;
            int x = dt.Rows.Count;
            int failedInvoices = fail;

            string alertMessage = string.Format("Payment Updated Successfully !!! \\n Out of {0} invoices: {1} are success and {2} are failed", x, successfulInvoices, failedInvoices);

            string redirectScript = "window.location.href = 'EstimateBulkPayment.aspx';";
            System.Web.UI.ScriptManager.RegisterStartupScript(this, GetType(), "displayalertmessage", "alert('" + alertMessage + "');" + redirectScript, true);
        }
    }
}