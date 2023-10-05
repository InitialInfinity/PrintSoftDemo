using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

public partial class admin_panel_Master_cust_profile : System.Web.UI.Page
{
    SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["String"].ConnectionString);
    decimal a, b, c,d,e,f,g,h,i,j;
    int id;
    string admin_email,cust_update;
    protected void Page_Load(object sender, EventArgs e)
    {
        id = Convert.ToInt32(Request.QueryString["id"]);
        if (!IsPostBack)
        {
            if (Session["a_email"] != null)
            {
                try
                {
                    cust_update = Request.QueryString["cust_update"].ToString();
                    if (cust_update == "success")
                    {
                        Panel5.Visible = true;
                    }

                }
                catch (Exception ex)
                { Panel5.Visible = false; }


                Panel1.Visible = true;
                Panel2.Visible = false;
                Panel3.Visible = false;
                Panel4.Visible = false;
                Panel6.Visible = false;
              
                FillRepeater();
                FillRepeater2();
                FillRepeater3();
                FillRepeater4();
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
        Panel3.Visible = false;
        Panel4.Visible = false;
        Panel6.Visible = false;
    }

    protected void LinkButton2_Click(object sender, EventArgs e)
    {
        Panel1.Visible = false;
        Panel2.Visible = true;
        Panel3.Visible = false;
        Panel4.Visible = false;
        Panel6.Visible = false;
    }

    protected void LinkButton3_Click(object sender, EventArgs e)
    {
        Panel1.Visible = false;
        Panel2.Visible = false;
        Panel3.Visible = true;
        Panel4.Visible = false;
        Panel6.Visible = false;
    }

    protected void LinkButton4_Click(object sender, EventArgs e)
    {
        Panel1.Visible = false;
        Panel2.Visible = false;
        Panel3.Visible = false;
        Panel4.Visible = true;
        Panel6.Visible = false;
    }
    protected void LinkButton5_Click(object sender, EventArgs e)
    {
        Panel1.Visible = false;
        Panel2.Visible = false;
        Panel3.Visible = false;
        Panel4.Visible = false;
        Panel6.Visible = true;
    }
    public void FillRepeater()
    {

        SqlCommand cmd = new SqlCommand("select * from tbl_customer where c_id="+id+"", conn);
        SqlDataAdapter adapt = new SqlDataAdapter(cmd);
        DataTable dt = new DataTable();

        adapt.Fill(dt);
        if (dt.Rows.Count > 0)
        {
            lbl_name1.Text=dt.Rows[0]["c_name"].ToString();
            lbl_address1.Text = dt.Rows[0]["c_address"].ToString();
            lbl_email1.Text = dt.Rows[0]["c_email"].ToString();
            lbl_phone1.Text = dt.Rows[0]["c_contact"].ToString();

            //summary
            lbl_address2.Text = dt.Rows[0]["c_address"].ToString();
            lbl_contact2.Text = dt.Rows[0]["c_contact"].ToString();
            lbl_contact22.Text = dt.Rows[0]["c_contact2"].ToString();
            lbl_gst_no2.Text = dt.Rows[0]["c_gst_no"].ToString();
            lbl_email2.Text = dt.Rows[0]["c_email"].ToString();
            lbl_opening_balance2.Text = dt.Rows[0]["c_opening_balance"].ToString();

            //edit profile
            Txt_name.Text = dt.Rows[0]["c_name"].ToString();
            Txt_address.Text = dt.Rows[0]["c_address"].ToString();
            Txt_contact.Text = dt.Rows[0]["c_contact"].ToString();
            Txt_contact2.Text = dt.Rows[0]["c_contact2"].ToString();
            Txt_gst_no.Text = dt.Rows[0]["c_gst_no"].ToString();
            Txt_email.Text = dt.Rows[0]["c_email"].ToString();
            Txt_opening_balance.Text = dt.Rows[0]["c_opening_balance"].ToString();

            lbl_remaining_balance.Text = dt.Rows[0]["c_opening_balance"].ToString();

        }
        
    }

    public void FillRepeater2()
    {
        SqlCommand cmd = new SqlCommand("select * from tbl_sale where c_id='" + id + "' order by sl_id desc", conn);
        SqlDataAdapter adapt = new SqlDataAdapter(cmd);
        DataTable dt = new DataTable();
        adapt.Fill(dt);
        if (dt.Rows.Count > 0)
        {
            Repeater1.DataSource = dt;
            Repeater1.DataBind();
            a= Convert.ToDecimal(dt.Compute("Sum(sl_total)", string.Empty));
            d = Convert.ToDecimal(dt.Compute("count(sl_id)", string.Empty));

        }
        else
        {
            Repeater1.DataSource = null;
            Repeater1.DataBind();
            a = 0;
            d = 0;
        }

    }
    public void FillRepeater3()
    {
        SqlCommand cmd = new SqlCommand("select * from tbl_estimate where c_id='" + id + "' order by est_id desc", conn);
        SqlDataAdapter adapt = new SqlDataAdapter(cmd);
        DataTable dt = new DataTable();
        adapt.Fill(dt);
        if (dt.Rows.Count > 0)
        {
            Repeater2.DataSource = dt;
            Repeater2.DataBind();
            b = Convert.ToDecimal(dt.Compute("Sum(est_total)", string.Empty));
            e = Convert.ToDecimal(dt.Compute("count(est_id)", string.Empty));
        }
        else
        {
            Repeater2.DataSource = null;
            Repeater2.DataBind();
            b = 0;
            e = 0;
        }

        c = a + b;
        lbl_total_invoice_amount.Text = c.ToString();
        f = d + e;
        lbl_total_invoices.Text = f.ToString();
    }
    
    public void FillRepeater4()
    {
        SqlCommand cmd = new SqlCommand("select * from tbl_gst_quotation where c_id='" + id + "' order by qu_id desc", conn);
        SqlDataAdapter adapt = new SqlDataAdapter(cmd);
        DataTable dt = new DataTable();

        adapt.Fill(dt);
        if (dt.Rows.Count > 0)
        {
            Repeater3.DataSource = dt;
            Repeater3.DataBind();
        }

    }
    public void FillRepeater5()
    {

        SqlCommand cmd = new SqlCommand("select * from tbl_sale_invoice_payment where c_id='" + id + "' order by si_id desc", conn);
        SqlDataAdapter adapt = new SqlDataAdapter(cmd);
        DataTable dt = new DataTable();

        adapt.Fill(dt);
        if (dt.Rows.Count > 0)
        {
            Repeater4.DataSource = dt;
            Repeater4.DataBind();

            lbl_total_advance.Text = dt.Compute("Sum(si_pay)", string.Empty).ToString();
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
        SqlCommand cmd2 = new SqlCommand("select * from tbl_admin_login", conn);
        SqlDataAdapter adapt2 = new SqlDataAdapter(cmd2);
        DataTable dt2 = new DataTable();
        adapt2.Fill(dt2);
        if (dt2.Rows.Count > 0)
        {
            admin_email = dt2.Rows[0]["a_email"].ToString();
        }
        if (admin_email.ToString() == Session["a_email"].ToString() || Session["admin_email"] != null)
        {
            SqlCommand cmd = new SqlCommand("UPDATE tbl_customer SET c_name=@c_name,c_address=@c_address,c_contact=@c_contact,c_gst_no=@c_gst_no,c_opening_balance=@c_opening_balance,c_email=@c_email,c_contact2=@c_contact2 WHERE c_id='" + id + "'", conn);
            cmd.Parameters.AddWithValue("@c_name", Txt_name.Text.ToString());
            cmd.Parameters.AddWithValue("@c_address", Txt_address.Text.ToString());
            cmd.Parameters.AddWithValue("@c_contact", Txt_contact.Text.ToString());
            cmd.Parameters.AddWithValue("@c_gst_no", Txt_gst_no.Text.ToString());
            if(Txt_opening_balance.Text=="")
            {
                cmd.Parameters.AddWithValue("@c_opening_balance", 0);
            }
            else
            {
                cmd.Parameters.AddWithValue("@c_opening_balance", Convert.ToDecimal(Txt_opening_balance.Text));
            }
            
            cmd.Parameters.AddWithValue("@c_email", Txt_email.Text.ToString());
            cmd.Parameters.AddWithValue("@c_contact2", Txt_contact2.Text.ToString());
            conn.Open();
        cmd.ExecuteNonQuery();
        conn.Close();
       
        Response.Redirect("cust_profile.aspx?id=" + id + "&cust_update=success");
        }
        else
        {
            Response.Redirect("../access_denied.aspx");

        }

    }
    
    protected void Repeater1_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
        {
            Label tr = e.Item.FindControl("lbl_status") as Label;

         
            DataRowView drv = e.Item.DataItem as DataRowView;
            decimal balance = Convert.ToDecimal(drv["sl_balance"]);
            decimal total = Convert.ToDecimal(drv["sl_total"]);

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

    protected void Repeater2_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
        {
            Label tr = e.Item.FindControl("lbl_status") as Label;


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