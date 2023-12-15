using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

public partial class admin_panel_Master_vendor_profile : System.Web.UI.Page
{
    SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["String"].ConnectionString);
    string admin_email, cust_update, gst_no, contact;
    int id;
    protected void Page_Load(object sender, EventArgs e)
    {
        id = Convert.ToInt32(Request.QueryString["id"]);
        if (!IsPostBack)
        {
            if (Session["a_email"] != null)
            {
                try
                {
                    cust_update = (Request.QueryString["cust_update"] ?? "").ToString();
                    if (cust_update == "success")
                    {
                        Panel5.Visible = true;
                    }

                }
                catch (Exception ex)
                { Panel5.Visible = false; }

                Panel1.Visible = true;
                Panel2.Visible = false;

                Panel4.Visible = false;
                FillRepeater();
                FillRepeater3();

                FillRepeater5();
            }
            else
            {
                Response.Redirect("../login.aspx");
            }
        }
    }

    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        Panel1.Visible = true;
        Panel2.Visible = false;

        Panel4.Visible = false;
    }

    protected void LinkButton2_Click(object sender, EventArgs e)
    {
        Panel1.Visible = false;
        Panel2.Visible = true;

        Panel4.Visible = false;
    }


    protected void LinkButton4_Click(object sender, EventArgs e)
    {
        Panel1.Visible = false;
        Panel2.Visible = false;

        Panel4.Visible = true;
    }
    public void FillRepeater()
    {

        SqlCommand cmd = new SqlCommand("select * from tbl_vendor where v_id=" + id + "", conn);
        SqlDataAdapter adapt = new SqlDataAdapter(cmd);
        DataTable dt = new DataTable();

        adapt.Fill(dt);
        if (dt.Rows.Count > 0)
        {
            lbl_name1.Text = dt.Rows[0]["v_name"].ToString();
            lbl_address1.Text = dt.Rows[0]["v_address"].ToString();
            lbl_email1.Text = dt.Rows[0]["v_email"].ToString();
            lbl_phone1.Text = dt.Rows[0]["v_contact"].ToString();

            //summary
            lbl_address2.Text = dt.Rows[0]["v_address"].ToString();
            lbl_contact2.Text = dt.Rows[0]["v_contact"].ToString();
            lbl_contact22.Text = dt.Rows[0]["v_contact2"].ToString();
            lbl_gst_no2.Text = dt.Rows[0]["v_gst_no"].ToString();
            lbl_email2.Text = dt.Rows[0]["v_email"].ToString();
            lbl_opening_balance2.Text = dt.Rows[0]["v_opening_balance"].ToString();

            //edit profile
            Txt_name.Text = dt.Rows[0]["v_name"].ToString();
            Txt_address.Text = dt.Rows[0]["v_address"].ToString();
            Txt_contact.Text = dt.Rows[0]["v_contact"].ToString();
           
            Txt_contact2.Text = dt.Rows[0]["v_contact2"].ToString();
            Txt_gst_no.Text = dt.Rows[0]["v_gst_no"].ToString();
            Txt_email.Text = dt.Rows[0]["v_email"].ToString();
            Txt_opening_balance.Text = dt.Rows[0]["v_opening_balance"].ToString();

            lbl_remaining_balance.Text = Convert.ToString(dt.Compute("Sum(v_opening_balance)", string.Empty));

        }

    }

    public void FillRepeater3()
    {

        SqlCommand cmd = new SqlCommand("select * from tbl_purchase where v_id='" + id + "' order by pu_id desc", conn);
        SqlDataAdapter adapt = new SqlDataAdapter(cmd);
        DataTable dt = new DataTable();

        adapt.Fill(dt);
        if (dt.Rows.Count > 0)
        {
            Repeater2.DataSource = dt;
            Repeater2.DataBind();
            lbl_total_invoice_amount.Text = Convert.ToString(dt.Compute("Sum(pu_total)", string.Empty));
            lbl_total_invoices.Text = Convert.ToString(dt.Compute("count(pu_id)", string.Empty));
        }
        else
        {
            Repeater2.DataSource = null;
            Repeater2.DataBind();
            lbl_total_invoice_amount.Text = "0";
            lbl_total_invoices.Text = "0";
        }

    }

    public void FillRepeater5()
    {

        SqlCommand cmd = new SqlCommand("select * from tbl_purchase_invoice_payment where v_id='" + id + "' order by pi_id desc", conn);
        SqlDataAdapter adapt = new SqlDataAdapter(cmd);
        DataTable dt = new DataTable();

        adapt.Fill(dt);
        if (dt.Rows.Count > 0)
        {
            Repeater4.DataSource = dt;
            Repeater4.DataBind();
            lbl_total_advance.Text = Convert.ToString(dt.Compute("sum(pi_pay)", string.Empty));
        }
        else
        {
            Repeater4.DataSource = null;
            Repeater4.DataBind();
            lbl_total_advance.Text = "0";
        }

    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        SqlCommand cmd1 = new SqlCommand("select * from tbl_admin_login", conn);
        SqlDataAdapter adapt1 = new SqlDataAdapter(cmd1);
        DataTable dt1 = new DataTable();
        adapt1.Fill(dt1);
        if (dt1.Rows.Count > 0)
        {
            admin_email = dt1.Rows[0]["a_email"].ToString();
        }
        if (admin_email.ToString() == Session["a_email"].ToString() || Session["admin_email"] != null)
        {

            try
            {
                SqlCommand cmd2 = new SqlCommand("select * from tbl_vendor where v_id=" + id + "", conn);
                SqlDataAdapter adapt = new SqlDataAdapter(cmd2);
                DataTable dt = new DataTable();

                adapt.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    contact = dt.Rows[0]["v_contact"].ToString();
                    gst_no = dt.Rows[0]["v_gst_no"].ToString();

                }



                SqlCommand cmd = new SqlCommand("UPDATE tbl_vendor SET v_name=@v_name,v_address=@v_address,v_contact=@v_contact,v_gst_no=@v_gst_no,v_opening_balance=@v_opening_balance,v_email=@v_email,v_contact2=@v_contact2 WHERE v_id='" + id + "'", conn);
                cmd.Parameters.AddWithValue("@v_name", Txt_name.Text.ToString());
                cmd.Parameters.AddWithValue("@v_address", Txt_address.Text.ToString());
                cmd.Parameters.AddWithValue("@v_contact", Txt_contact.Text.ToString());
                // cmd.Parameters.AddWithValue("@v_gst_no", Txt_gst_no.Text.ToString());
                if (string.IsNullOrEmpty(Txt_gst_no.Text))
                {

                    Random random = new Random();
                    int randomNumber = random.Next(1000, 9999);
                    Txt_gst_no.Text = "N/A-" + randomNumber.ToString();
                }

                cmd.Parameters.AddWithValue("@v_gst_no", Txt_gst_no.Text.Trim());
                //cmd.Parameters.AddWithValue("@v_gst_no", string.IsNullOrEmpty(Txt_gst_no.Text) ? DBNull.Value : (object)Txt_gst_no.Text);
                if (Txt_opening_balance.Text == "")
                {
                    cmd.Parameters.AddWithValue("@v_opening_balance", 0);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@v_opening_balance", Convert.ToDecimal(Txt_opening_balance.Text));
                }

                cmd.Parameters.AddWithValue("@v_email", Txt_email.Text.ToString());
                cmd.Parameters.AddWithValue("@v_contact2", Txt_contact2.Text.ToString());
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();

                Response.Redirect("vendor_profile.aspx?id=" + id + "&cust_update=success");

                
            }
            catch (SqlException ex)
            {
                if (ex.Number == 2601)
                {
                    // Check if the exception is related to a unique constraint violation
                    if (ex.Message.Contains("IX_UniqueContact"))
                    {
                        // Show an alert indicating that the contact number is a duplicate
                        string script = "alert('This contact number already exists.');";
                        ClientScript.RegisterStartupScript(this.GetType(), "AlertContact", script, true);
                        Txt_contact.Text = contact;
                    }
                    else if (ex.Message.Contains("IX_UniqueGST"))
                    {

                        string script = "alert('This GST number already exists.');";
                        ClientScript.RegisterStartupScript(this.GetType(), "AlertGST", script, true);
                        Txt_gst_no.Text = gst_no;

                    }
                    else
                    {
                        // Handle other SQL errors as needed
                    }
                }
                else
                {
                    // Handle other SQL errors as needed
                }

            }



        }


        else
        {
            Response.Redirect("../access_denied.aspx");

        }
    }
    protected void Repeater2_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
        {
            Label tr = e.Item.FindControl("lbl_status") as Label;


            DataRowView drv = e.Item.DataItem as DataRowView;
            decimal balance = Convert.ToDecimal(drv["pu_balance"]);
            decimal total = Convert.ToDecimal(drv["pu_total"]);

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