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
using System.Net;
using System.Text;

public partial class Daily_Cash_Order_cash_payment : System.Web.UI.Page
{
    SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["String"].ConnectionString);
    string invoice;
    decimal balance, opening, newbalance;
    string filename1, key, country, senderid, route;
    string company;
    protected void Page_Load(object sender, EventArgs e)
    {
        Txt_discount.Focus();
        if (Session["a_email"] != null)
        {
            invoice = Request.QueryString["invoice"].ToString();
            if (Page.IsPostBack) return;
            Txt_date.Text = DateTime.Today.ToString("yyyy-MM-dd");
            Panel3.Visible = false;
            //customer();
            fill();
            FillRepeater();
            Txt_pay.Text = "0";
            Txt_discount.Text = "0";
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

    //public void customer()
    //{
    //    string query = "select * from tbl_customer Order By c_name asc";
    //    SqlDataAdapter adapt4 = new SqlDataAdapter(query, conn);
    //    DataTable dt5 = new DataTable();
    //    adapt4.Fill(dt5);
    //    if (dt5.Rows.Count > 0)
    //    {
    //        Dd_customer.DataSource = dt5;
    //        Dd_customer.DataBind();
    //        Dd_customer.DataTextField = "c_name";
    //        Dd_customer.DataValueField = "c_id";
    //        Dd_customer.DataBind();
    //        Dd_customer.Items.Insert(0, new ListItem("--Select--", "--Select--"));
    //        Dd_customer.SelectedItem.Selected = false;
    //        Dd_customer.Items.FindByText("--Select--").Selected = true;
    //    }

    //}
    protected void fill()
    {

        SqlCommand cmd = new SqlCommand("select * from tbl_order where quw_no='" + invoice + "'", conn);
        SqlDataAdapter adapt = new SqlDataAdapter(cmd);
        DataTable dt = new DataTable();

        adapt.Fill(dt);
        if (dt.Rows.Count > 0)
        {
            Txt_invoice.Text = invoice;
            Txt_customer.Text = dt.Rows[0]["quw_name"].ToString();
            lbl_customer.Value = dt.Rows[0]["quw_id"].ToString();
            Txt_due_amount.Text = dt.Rows[0]["quw_balance"].ToString();
            //lbl_contact.Value = dt.Rows[0]["c_contact"].ToString();
            lbl_balance.Value = dt.Rows[0]["quw_balance"].ToString();

            //Panel1.Visible = true;
            Panel2.Visible = true;



        }
        if (dt.Rows.Count == 0)
        {
            //SqlCommand cmd2 = new SqlCommand("select * from tbl_estimate inner join tbl_customer on tbl_estimate.c_id=tbl_customer.c_id where est_invoice_no ='" + invoice + "'", conn);
            //SqlDataAdapter adapt2 = new SqlDataAdapter(cmd2);
            //DataTable dt2 = new DataTable();

            //adapt2.Fill(dt2);
            //if (dt2.Rows.Count > 0)
            //{
            //    Txt_invoice.Text = invoice;
            //    Dd_customer.SelectedValue = dt2.Rows[0]["c_id"].ToString();
            //    lbl_customer.Value = dt2.Rows[0]["c_id"].ToString();
            //    Txt_due_amount.Text = dt2.Rows[0]["est_balance"].ToString();
            //    lbl_contact.Value = dt2.Rows[0]["c_contact"].ToString();
            //    lbl_balance.Value = dt2.Rows[0]["est_balance"].ToString();

            //    Panel1.Visible = false;
            //    Panel2.Visible = true;

            //}
        }

    }

    protected void Repeater1_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if (e.CommandName.Equals("showid"))
        {
            //get data
            string CarrierName = e.CommandArgument.ToString();
            SqlCommand cmd = new SqlCommand("select * from tbl_order_invoice_payment where si_id='" + CarrierName + "'", conn);
            SqlDataAdapter adapt = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapt.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                //lbl_id.Text = dt.Rows[0]["si_id"].ToString();
                lbl_invoice.Text = dt.Rows[0]["si_invoice"].ToString();
                lbl_date.Text = Convert.ToDateTime(dt.Rows[0]["si_date"]).ToString("dd/MM/yyyy");
                lbl_due.Text = dt.Rows[0]["si_due"].ToString();
                lbl_discount.Text = dt.Rows[0]["si_discount"].ToString();
                lbl_pay.Text = dt.Rows[0]["si_pay"].ToString();
                lbl_mode2.Text = dt.Rows[0]["si_mode"].ToString();
                lbl_chno.Text = dt.Rows[0]["si_chno"].ToString();
                lbl_balance1.Text = dt.Rows[0]["si_balance"].ToString();
            }
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Modal", "ShowModel();", true);

          

        }



        else
        {
            Response.Redirect("../access_denied.aspx");

        }


    }
    public void FillRepeater()
    {
        SqlCommand cmd = new SqlCommand("select * from tbl_order_invoice_payment where si_invoice='" + invoice + "'", conn);
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
        decimal total_advance_amount = 0;
        decimal Advance_payment = 0;

        try
        {
            SqlCommand cmd = new SqlCommand("insert into tbl_order_invoice_payment values(@si_invoice,@o_id,@si_due,@si_discount,@si_pay,@si_mode,@si_chno,@si_balance,@si_date)", conn);
            cmd.Parameters.AddWithValue("@si_invoice", Convert.ToString(Txt_invoice.Text));

            cmd.Parameters.AddWithValue("@o_id", Convert.ToString(lbl_customer.Value));
            cmd.Parameters.AddWithValue("@si_due", Convert.ToDecimal(Txt_due_amount.Text));
            cmd.Parameters.AddWithValue("@si_discount", Convert.ToDecimal(Txt_discount.Text));
            cmd.Parameters.AddWithValue("@si_pay", Convert.ToDecimal(Txt_pay.Text));
            cmd.Parameters.AddWithValue("@si_mode", Convert.ToString(Dd_payment_mode.Text));
            cmd.Parameters.AddWithValue("@si_chno", Convert.ToString(Txt_ch_no.Text));
            cmd.Parameters.AddWithValue("@si_balance", Convert.ToDecimal(Lbl_total_balance.Text));
            cmd.Parameters.AddWithValue("@si_date", Convert.ToDateTime(DateTime.Now.ToShortDateString()).ToString("MM/dd/yyyy"));


            conn.Open();
            cmd.ExecuteNonQuery();

            conn.Close();

            SqlCommand cmd2 = new SqlCommand("update tbl_order set quw_balance='" + Lbl_total_balance.Text + "' where quw_no='" + invoice + "'", conn);


            conn.Open();
            cmd2.ExecuteNonQuery();

            conn.Close();

            SqlCommand cmd3 = new SqlCommand("update tbl_order_details set qw_balance='" + Lbl_total_balance.Text + "' where quw_no='" + invoice + "'", conn);


            conn.Open();
            cmd3.ExecuteNonQuery();

            conn.Close();


            //SqlCommand cmd4 = new SqlCommand("select * from tbl_customer where c_id ='" + lbl_customer.Value + "'", conn);
            //SqlDataAdapter adapt4 = new SqlDataAdapter(cmd4);
            //DataTable dt4 = new DataTable();

            //adapt4.Fill(dt4);
            //if (dt4.Rows.Count > 0)
            //{

            //    opening = Convert.ToDecimal(dt4.Rows[0]["c_opening_balance"]);
            //    balance = Convert.ToDecimal(Txt_pay.Text);
            //    newbalance = opening - balance;

            //}

            //SqlCommand cmd5 = new SqlCommand("update tbl_customer set c_opening_balance='" + newbalance + "' where c_id='" + lbl_customer.Value + "'", conn);


            //conn.Open();
            //cmd5.ExecuteNonQuery();

            //conn.Close();




            ///my quries 
            SqlCommand cmd33 = new SqlCommand("select quw_adjustment from tbl_order where quw_no='" + Txt_invoice.Text + "'", conn);

            SqlDataAdapter adapt33 = new SqlDataAdapter(cmd33);
            DataTable dt33 = new DataTable();

            adapt33.Fill(dt33);
            if (dt33.Rows.Count > 0)
            {
                Advance_payment = Convert.ToDecimal(dt33.Rows[0]["quw_adjustment"]);

                total_advance_amount = Advance_payment + balance;

                SqlCommand cmd22 = new SqlCommand("update tbl_order set quw_adjustment ='" + total_advance_amount + "' where quw_no='" + Txt_invoice.Text + "'", conn);

                conn.Open();

                cmd22.ExecuteNonQuery();
                conn.Close();

            }


            //end ehre


            try
            {

                SqlCommand cmd6 = new SqlCommand("select * from tbl_company_details where com_id = 1", conn);
                SqlDataAdapter adapt6 = new SqlDataAdapter(cmd6);
                DataTable dt6 = new DataTable();
                adapt6.Fill(dt6);
                if (dt6.Rows.Count > 0)
                {
                    company = dt6.Rows[0]["com_company_name"].ToString();

                }


                SqlCommand cmd7 = new SqlCommand("select * from tbl_sms_config ", conn);
                SqlDataAdapter adapt7 = new SqlDataAdapter(cmd7);
                DataTable dt7 = new DataTable();
                adapt7.Fill(dt7);
                if (dt7.Rows.Count > 0)
                {
                    key = dt7.Rows[0]["sc_key"].ToString();
                    country = dt7.Rows[0]["sc_country"].ToString();

                    senderid = dt7.Rows[0]["sc_sender"].ToString();
                    route = dt7.Rows[0]["sc_route"].ToString();

                }

                decimal mob = Convert.ToDecimal(lbl_contact.Value);
                WebClient client = new WebClient();
                string to;
                string msgRecepient = mob.ToString();
                //  string msgText = "Thank You for choosing Kalaratna Graphics For any Support Services related assistance,please feel free to call 9822228163 your Billing amount is'" + txtGfinaltotal.Text + "'and advance payment is'" + txtGAdvanceAmt.Text + "'and your balance amount is '" + txtPrevoiusOutstanding.Text + "'Thank You For Visiting Kalaratna Graphics";
                string msgText = "Welcome to " + company + ", We have received " + Txt_pay.Text + " amount for invoice " + invoice + ". Your Due Amount is " + Lbl_total_balance.Text.ToString() + ".";

                to = mob.ToString();

                string baseURL = "http://dndsms.dit.asia/api/sendhttp.php?" +

                   "authkey=" + key +
                   "&mobiles=" + msgRecepient +
                   "&message=" + System.Web.HttpUtility.UrlEncode(msgText, Encoding.GetEncoding("ISO-8859-1")) +
                   "&sender=" + senderid +
                   "&route=" + route +
                   "&country=" + country;



                client.OpenRead(baseURL);
                //MessageBox.Show("Successfully sent message");


            }
            catch (Exception exp)
            {
                //MessageBox.Show(exp.ToString());
            }


            string redirectScript = " window.location.href = 'wgst_bill.aspx?invoice=" + invoice + "';";
            System.Web.UI.ScriptManager.RegisterStartupScript(this, GetType(), "displayalertmessage", "alert('Payment Updated Successfully!!!');" + redirectScript, true);

        }
        catch (Exception ex) { }


    }

    protected void Btn_submit2_Click(object sender, EventArgs e)
    {
        decimal total_advance_amount = 0;
        decimal Advance_payment = 0;

        try
        {
            SqlCommand cmd = new SqlCommand("insert into tbl_order_invoice_payment values(@si_invoice,@o_id,@si_due,@si_discount,@si_pay,@si_mode,@si_chno,@si_balance,@si_date)", conn);
            cmd.Parameters.AddWithValue("@si_invoice", Convert.ToString(Txt_invoice.Text));

            cmd.Parameters.AddWithValue("@o_id", Convert.ToString(lbl_customer.Value));
            cmd.Parameters.AddWithValue("@si_due", Convert.ToDecimal(Txt_due_amount.Text));
            cmd.Parameters.AddWithValue("@si_discount", Convert.ToDecimal(Txt_discount.Text));
            cmd.Parameters.AddWithValue("@si_pay", Convert.ToDecimal(Txt_pay.Text));
            cmd.Parameters.AddWithValue("@si_mode", Convert.ToString(Dd_payment_mode.Text));
            cmd.Parameters.AddWithValue("@si_chno", Convert.ToString(Txt_ch_no.Text));
            cmd.Parameters.AddWithValue("@si_balance", Convert.ToDecimal(Lbl_total_balance.Text));
            cmd.Parameters.AddWithValue("@si_date", Convert.ToDateTime(DateTime.Now.ToShortDateString()).ToString("MM/dd/yyyy"));


            conn.Open();
            cmd.ExecuteNonQuery();

            conn.Close();



            SqlCommand cmd2 = new SqlCommand("update tbl_order set quw_balance='" + Lbl_total_balance.Text + "' where quw_no='" + invoice + "'", conn);


            conn.Open();
            cmd2.ExecuteNonQuery();

            conn.Close();

            SqlCommand cmd3 = new SqlCommand("update tbl_order_details set qw_balance='" + Lbl_total_balance.Text + "' where quw_no='" + invoice + "'", conn);


            conn.Open();
            cmd3.ExecuteNonQuery();

            conn.Close();


            //SqlCommand cmd4 = new SqlCommand("select * from tbl_customer where c_id ='" + lbl_customer.Value + "'", conn);
            //SqlDataAdapter adapt4 = new SqlDataAdapter(cmd4);
            //DataTable dt4 = new DataTable();

            //adapt4.Fill(dt4);
            //if (dt4.Rows.Count > 0)
            //{

            //    opening = Convert.ToDecimal(dt4.Rows[0]["c_opening_balance"]);
            //    balance = Convert.ToDecimal(Txt_pay.Text);
            //    newbalance = opening - balance;

            //}



            //SqlCommand cmd5 = new SqlCommand("update tbl_customer set c_opening_balance='" + newbalance + "' where c_id='" + lbl_customer.Value + "'", conn);


            //conn.Open();
            //cmd5.ExecuteNonQuery();

            //conn.Close();


            ///my quries 
            SqlCommand cmd33 = new SqlCommand("select quw_adjustment from tbl_order where quw_no='" + Txt_invoice.Text + "'", conn);

            SqlDataAdapter adapt33 = new SqlDataAdapter(cmd33);
            DataTable dt33 = new DataTable();

            adapt33.Fill(dt33);
            if (dt33.Rows.Count > 0)
            {
                Advance_payment = Convert.ToDecimal(dt33.Rows[0]["quw_adjustment"]);

                total_advance_amount = Advance_payment + balance;

                SqlCommand cmd22 = new SqlCommand("update tbl_order set quw_adjustment ='" + total_advance_amount + "' where quw_no='" + Txt_invoice.Text + "'", conn);

                conn.Open();

                cmd22.ExecuteNonQuery();
                conn.Close();

            }


            //end ehre


            try
            {

                SqlCommand cmd6 = new SqlCommand("select * from tbl_company_details where com_id = 1", conn);
                SqlDataAdapter adapt6 = new SqlDataAdapter(cmd6);
                DataTable dt6 = new DataTable();
                adapt6.Fill(dt6);
                if (dt6.Rows.Count > 0)
                {
                    company = dt6.Rows[0]["com_company_name"].ToString();

                }


                SqlCommand cmd7 = new SqlCommand("select * from tbl_sms_config ", conn);
                SqlDataAdapter adapt7 = new SqlDataAdapter(cmd7);
                DataTable dt7 = new DataTable();
                adapt7.Fill(dt7);
                if (dt7.Rows.Count > 0)
                {
                    key = dt7.Rows[0]["sc_key"].ToString();
                    country = dt7.Rows[0]["sc_country"].ToString();

                    senderid = dt7.Rows[0]["sc_sender"].ToString();
                    route = dt7.Rows[0]["sc_route"].ToString();

                }

                decimal mob = Convert.ToDecimal(lbl_contact.Value);
                WebClient client = new WebClient();
                string to;
                string msgRecepient = mob.ToString();
                //  string msgText = "Thank You for choosing Kalaratna Graphics For any Support Services related assistance,please feel free to call 9822228163 your Billing amount is'" + txtGfinaltotal.Text + "'and advance payment is'" + txtGAdvanceAmt.Text + "'and your balance amount is '" + txtPrevoiusOutstanding.Text + "'Thank You For Visiting Kalaratna Graphics";
                string msgText = "Welcome to " + company + ", We have received " + Txt_pay.Text + " amount for invoice " + invoice + ". Your Due Amount is " + Lbl_total_balance.Text.ToString() + ".";

                to = mob.ToString();

                string baseURL = "http://dndsms.dit.asia/api/sendhttp.php?" +

                   "authkey=" + key +
                   "&mobiles=" + msgRecepient +
                   "&message=" + System.Web.HttpUtility.UrlEncode(msgText, Encoding.GetEncoding("ISO-8859-1")) +
                   "&sender=" + senderid +
                   "&route=" + route +
                   "&country=" + country;



                client.OpenRead(baseURL);
                //MessageBox.Show("Successfully sent message");


            }
            catch (Exception exp)
            {
                //MessageBox.Show(exp.ToString());
            }

            string redirectScript = " window.location.href = 'wgst_bill.aspx?invoice=" + invoice + "';";
            System.Web.UI.ScriptManager.RegisterStartupScript(this, GetType(), "displayalertmessage", "alert('Payment Updated Successfully!!!');" + redirectScript, true);


        }
        catch (Exception ex) { }

    }


    protected void DeletePayment(object sender, EventArgs e)
    {
        String id = ((sender as LinkButton).NamingContainer.FindControl("lbl_id") as HiddenField).Value;
        //String invoiceno = ((sender as LinkButton).NamingContainer.FindControl("lbl_invoice") as Label).Text;
        //decimal discount = Convert.ToDecimal(((sender as LinkButton).NamingContainer.FindControl("lbl_discount") as Label).Text);
        //decimal pay = Convert.ToDecimal(((sender as LinkButton).NamingContainer.FindControl("lbl_pay") as Label).Text);
        //decimal inbalnce = Convert.ToDecimal(lbl_balance.Value);
        //decimal inbal, custbal;

        //inbal = inbalnce + discount + pay;
        //custbal = discount + pay;
        //if (Panel1.Visible == true)
        //{

        //    using (SqlCommand cmd = new SqlCommand("update tbl_customer set c_opening_balance= c_opening_balance + '" + custbal + "' where c_id='" + lbl_customer.Value + "'", conn))
        //    {
        //        conn.Open();
        //        cmd.ExecuteNonQuery();

        //        conn.Close();
        //    }

        //    SqlCommand cmd2 = new SqlCommand("update tbl_sale set sl_balance='" + inbal + "' where sl_invoice_no='" + invoice + "'", conn);


        //    conn.Open();
        //    cmd2.ExecuteNonQuery();

        //    conn.Close();

        //    SqlCommand cmd3 = new SqlCommand("update tbl_sale_invoice set s_balance='" + inbal + "' where s_invoice_no='" + invoice + "'", conn);


        //    conn.Open();
        //    cmd3.ExecuteNonQuery();

        //    conn.Close();

        //}
        //else
        //{

        //    using (SqlCommand cmd = new SqlCommand("update tbl_customer set c_opening_balance= c_opening_balance + '" + custbal + "' where c_id='" + lbl_customer.Value + "'", conn))
        //    {
        //        conn.Open();
        //        cmd.ExecuteNonQuery();

        //        conn.Close();
        //    }
        //    SqlCommand cmd2 = new SqlCommand("update tbl_estimate set est_balance='" + inbal + "' where est_invoice_no='" + invoice + "'", conn);


        //    conn.Open();
        //    cmd2.ExecuteNonQuery();

        //    conn.Close();

        //    SqlCommand cmd3 = new SqlCommand("update tbl_estimate_details set es_balance='" + inbal + "' where es_invoice_no='" + invoice + "'", conn);


        //    conn.Open();
        //    cmd3.ExecuteNonQuery();

        //    conn.Close();

        //}

        using (SqlCommand cmd = new SqlCommand("DELETE FROM tbl_order_invoice_payment WHERE si_id = @si_id", conn))
        {
            cmd.Parameters.AddWithValue("@si_id", id);
            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
        }

        Response.Redirect(Request.RawUrl);
    }

    protected void Dd_payment_mode_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (Dd_payment_mode.SelectedValue == "Cheque")
        {
            Txt_date.ReadOnly = false;
            Panel3.Visible = true;
        }
        else
        {
            Txt_date.ReadOnly = true;
            Panel3.Visible = false;
        }
    }
}