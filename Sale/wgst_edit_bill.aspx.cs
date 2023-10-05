using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

public partial class Sale_wgst_edit_bill : System.Web.UI.Page
{
    SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["String"].ConnectionString);
    decimal total_amount = 0, final_total = 0;
    decimal totalvalue, totalcgst, totalsgst, totaligst, totalgst, totalqty, totaltaxable, Old_total, old_balance, paid, new_balance, new_total, rem;
    string invoice;
    int id;
    string admin_email;

    string order_reference;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["a_email"] != null || Session["admin_email"] != null)
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
                invoice = Request.QueryString["invoice"].ToString();
            if (!IsPostBack)
            {
                Panel1.Visible = true;
                Panel2.Visible = false;

                RefreshData();
                this.customer();
                this.product();
                GetData();
                Order_reference();
                    material();

                    if (ViewState["Details"] == null)
                {

                }
            }
            }
            else
            {
                Response.Redirect("../access_denied.aspx");

            }

        }
        else
        {
            Response.Redirect("../login.aspx");
        }
    }
    public void customer()
    {
        string query = "select * from tbl_customer ORDER BY c_name asc";
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
    public void product()
    {
        string query = "select * from tbl_product ORDER BY p_name asc";
        SqlDataAdapter adapt5 = new SqlDataAdapter(query, conn);
        DataTable dt6 = new DataTable();
        adapt5.Fill(dt6);
        if (dt6.Rows.Count > 0)
        {
            Dd_enter_product.DataSource = dt6;
            Dd_enter_product.DataBind();
            Dd_enter_product.DataTextField = "p_name";

            Dd_enter_product.DataValueField = "p_id";
            Dd_enter_product.DataBind();
            Dd_enter_product.Items.Insert(0, new ListItem("--Select--", "--Select--"));
            Dd_enter_product.SelectedItem.Selected = false;
            Dd_enter_product.Items.FindByText("--Select--").Selected = true;
        }

    }

    public void Order_reference()
    {
        string query = "select * from tbl_staff order by st_id desc";
        SqlDataAdapter adapt = new SqlDataAdapter(query, conn);
        DataTable dt = new DataTable();
        adapt.Fill(dt);

        if (dt.Rows.Count > 0)
        {
            drp_designer.DataSource = dt;
            drp_designer.DataBind();
            drp_designer.DataTextField = "st_staff_name";
            drp_designer.DataValueField = "st_id";
            drp_designer.DataBind();
            drp_designer.Items.Insert(0, new ListItem("--Select Designer--", "--Select Designer--"));
            drp_designer.SelectedItem.Selected = false;
            drp_designer.Items.FindByText("--Select Designer--").Selected = true;
        }
    }

    protected void GetData()
    {


        SqlCommand cmd = new SqlCommand("select * from tbl_estimate_details where es_invoice_no='" + invoice + "'", conn);
        SqlDataAdapter adapt = new SqlDataAdapter(cmd);
        DataTable dt = new DataTable();
        adapt.Fill(dt);
        if (dt.Rows.Count > 0)
        {
            id = Convert.ToInt32(dt.Rows[0]["es_id"]);
            Dd_customer.SelectedValue = dt.Rows[0]["c_id"].ToString();
            Txt_invoice.Text = dt.Rows[0]["es_invoice_no"].ToString();
            Txt_order_no.Text = dt.Rows[0]["es_order_no"].ToString();
            lbl_date.Value = Convert.ToDateTime(dt.Rows[0]["es_date"]).ToString("MM/dd/yyyy");
            Txt_invoice_date.Text = Convert.ToDateTime(dt.Rows[0]["es_invoice_date"]).ToString("MM/dd/yyyy");
            Txt_due_date.Text = Convert.ToDateTime(dt.Rows[0]["es_due_date"]).ToString("MM/dd/yyyy");
            //lbl_totalqty.Text = dt.Rows[0]["s_total_quantity"].ToString();
            lbl_subtotal.Text = dt.Rows[0]["es_sub_total"].ToString();
            lbl_subtotal2.Value = dt.Rows[0]["es_sub_total"].ToString();
            
           
            Txt_advance.Text = dt.Rows[0]["es_adjustment"].ToString();
            Txt_discount.Text = dt.Rows[0]["es_discount"].ToString();
            lbl_total.Text = dt.Rows[0]["es_total"].ToString();
            hide_total.Text = dt.Rows[0]["es_total"].ToString();
            lbl_balance.Value = dt.Rows[0]["es_balance"].ToString();


            //additional parameters 

            drp_payment.SelectedItem.Text = dt.Rows[0]["es_payment_method"].ToString();
            Txt_Fitting.Text  = dt.Rows[0]["es_fitting_charges"].ToString();
            Txt_Pasting.Text = dt.Rows[0]["es_pasting_charges"].ToString();
            Txt_TransportCharges.Text = dt.Rows[0]["es_shipping_charges"].ToString();
            Txt_Dtp_charges.Text = dt.Rows[0]["es_dtp_charges"].ToString();
            Txt_Framing.Text = dt.Rows[0]["es_framing_charges"].ToString();
            Txt_install.Text = dt.Rows[0]["es_installation_charges"].ToString();

            lbl_final.Text = dt.Rows[0]["es_balance"].ToString();

            //order_reference = dt.Rows[0]["es_order_ref"].ToString();
            //Txt_reference.Text = order_reference.ToString();


            FillGRid();
        }




    }

    protected void RefreshData()
    {
        try
        {
            if (conn.State != ConnectionState.Closed)
            {
                conn.Close();
            }
            SqlCommand cmd = new SqlCommand("delete from tbl_temp_estimate_details", conn);
            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();

            if (conn.State != ConnectionState.Closed)
            {
                conn.Close();
            }
            SqlCommand cmd2 = new SqlCommand("insert into tbl_temp_estimate_details select es_invoice_no,es_date,c_id,es_order_no,es_invoice_date,es_due_date,es_product_name,es_quantity,es_total_quantity,es_rate,es_discount,es_sub_total,es_shipping_charges,es_adjustment,es_total,es_hsn,es_unit,es_stotal,es_desc,es_height,es_width,es_size,es_samount,es_balance from tbl_estimate_details where es_invoice_no='" + invoice + "'", conn);
            conn.Open();
            cmd2.ExecuteNonQuery();
            conn.Close();
            if (conn.State != ConnectionState.Closed)
            {
                conn.Close();
            }
        }
        catch (Exception ex)
        {

        }
        finally
        {
            if (conn.State != ConnectionState.Closed)
            {
                conn.Close();
            }
        }

    }
    protected void FillGRid()
    {
        try
        {


            SqlCommand cmd = new SqlCommand("select es_product_name as Product,es_hsn as HSN,es_height as Height,es_width as Width,es_size as SQRFT,es_rate as Rate,es_samount as Amount,es_quantity as Qty,es_stotal as Total,es_desc as [desc],es_unit as unit,es_id as[ID] from tbl_temp_estimate_details where es_invoice_no='" + invoice + "'", conn);
            SqlDataAdapter adapt = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapt.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                GridView1.DataSource = dt;
                GridView1.DataBind();
                totalqty = Convert.ToDecimal(dt.Compute("Sum(Qty)", ""));
                totalvalue = Convert.ToDecimal(dt.Compute("Sum(Total)", ""));
                
                //Assign the total value to footer label control
                lbl_subtotal.Text = totalvalue.ToString();
                lbl_subtotal2.Value = totalvalue.ToString();

                //Assign the total value to footer label control
                
                lbl_totalqty.Text = totalqty.ToString();
                


            }
            else
            {
                GridView1.DataSource = null;
                GridView1.DataBind();
            }
        }
        catch (Exception ex)
        {
            ex.Message.ToString();
        }
        finally
        {
            if (conn.State != ConnectionState.Closed)
            {
                conn.Close();
            }
        }
    }

    protected void Btn_cart_Click(object sender, EventArgs e)
    {

        string str = Dd_enter_product.SelectedItem.Text;

        string str2 = txt_quantity.Text.Trim();
        string str3 = txt_rate.Text.Trim();


        string str8 = txt_total_amt.Text.Trim();


        string str7 = txt_amount.Text.Trim();
        string str9 = lbl_unit.Value.Trim();
        string str10 = lbl_product_hsn.Value.Trim();

        //new data 
        string height = txt_height.Text.Trim();
        string width = txt_width.Text.Trim();
        string sqrft = txt_sqrft.Text.Trim();
        string rate = txt_rate.Text.Trim();
        string amount = txt_amount.Text.Trim();

        string height2 = txt_height2.Text.Trim();
        string width2 = txt_width2.Text.Trim();
        string sqrft2 = txt_sqrft2.Text.Trim();
        string rate2 = txt_rate2.Text.Trim();
        string amount2 = txt_amount2.Text.Trim();


        string quantity = txt_quantity.Text.Trim();
        string quantity2 = txt_quantity2.Text.Trim();
        string total = txt_total_amt.Text.Trim();
        string total2 = txt_total_amt2.Text.Trim();


        //string final = txt_final_amt.Text;
        string desc = Txt_description.Text;
        


        if (str9 == "Pcs")
        {
            try
            {
                SqlCommand cmd = new SqlCommand("insert into tbl_temp_estimate_details values(@es_invoice_no,@es_date,@c_id,@es_order_no,@es_invoice_date,@es_due_date,@es_product_name,@es_quantity,@es_total_quantity,@es_rate,@es_discount,@es_sub_total,@es_shipping_charges,@es_adjustment,@es_total,@es_hsn,@es_unit,@es_stotal,@es_desc,@es_height,@es_width,@es_size,@es_samount,@es_balance)", conn);

                cmd.Parameters.AddWithValue("@es_invoice_no", Convert.ToString(Txt_invoice.Text));
                cmd.Parameters.AddWithValue("@es_date", DateTime.Now.ToShortDateString());
                cmd.Parameters.AddWithValue("@c_id", Convert.ToString(Dd_customer.SelectedValue));
                cmd.Parameters.AddWithValue("@es_order_no", Convert.ToString(Txt_order_no.Text));
                cmd.Parameters.AddWithValue("@es_invoice_date", Convert.ToDateTime(Txt_invoice_date.Text).ToString());
                cmd.Parameters.AddWithValue("@es_due_date", Convert.ToDateTime(Txt_due_date.Text).ToString());
                cmd.Parameters.AddWithValue("@es_product_name", Convert.ToString(Dd_enter_product.SelectedItem.Text));
                cmd.Parameters.AddWithValue("@es_quantity", Convert.ToDecimal(txt_quantity2.Text));
                cmd.Parameters.AddWithValue("@es_unit", Convert.ToString(lbl_unit.Value));
                cmd.Parameters.AddWithValue("@es_total_quantity", Convert.ToDecimal(lbl_totalqty.Text));
                cmd.Parameters.AddWithValue("@es_rate", Convert.ToDecimal(txt_rate2.Text));
                cmd.Parameters.AddWithValue("@es_discount", Convert.ToDecimal(Txt_discount.Text));
                
                cmd.Parameters.AddWithValue("@es_sub_total", Convert.ToDecimal(lbl_subtotal.Text));
              
                cmd.Parameters.AddWithValue("@es_shipping_charges", "");
                cmd.Parameters.AddWithValue("@es_adjustment", Convert.ToDecimal(Txt_advance.Text));
                cmd.Parameters.AddWithValue("@es_total", Convert.ToDecimal(hide_total.Text));
                cmd.Parameters.AddWithValue("@es_stotal", Convert.ToDecimal(txt_total_amt2.Text));
                cmd.Parameters.AddWithValue("@es_hsn", Convert.ToString(lbl_product_hsn.Value));
                cmd.Parameters.AddWithValue("@es_desc", Convert.ToString(Txt_description.Text));
                cmd.Parameters.AddWithValue("@es_height", "");
                cmd.Parameters.AddWithValue("@es_width", "");
                cmd.Parameters.AddWithValue("@es_size", "");
                cmd.Parameters.AddWithValue("@es_samount", "");
               
                cmd.Parameters.AddWithValue("@es_balance", Convert.ToDecimal(lbl_balance.Value));
                conn.Open();
                cmd.ExecuteNonQuery();

                conn.Close();
                FillGRid();

            }
            catch (Exception ex)
            {

            }
        }
       else if (str9 == "Ltr")
        {
            try
            {
                SqlCommand cmd = new SqlCommand("insert into tbl_temp_estimate_details values(@es_invoice_no,@es_date,@c_id,@es_order_no,@es_invoice_date,@es_due_date,@es_product_name,@es_quantity,@es_total_quantity,@es_rate,@es_discount,@es_sub_total,@es_shipping_charges,@es_adjustment,@es_total,@es_hsn,@es_unit,@es_stotal,@es_desc,@es_height,@es_width,@es_size,@es_samount,@es_balance)", conn);

                cmd.Parameters.AddWithValue("@es_invoice_no", Convert.ToString(Txt_invoice.Text));
                cmd.Parameters.AddWithValue("@es_date", DateTime.Now.ToShortDateString());
                cmd.Parameters.AddWithValue("@c_id", Convert.ToString(Dd_customer.SelectedValue));
                cmd.Parameters.AddWithValue("@es_order_no", Convert.ToString(Txt_order_no.Text));
                cmd.Parameters.AddWithValue("@es_invoice_date", Convert.ToDateTime(Txt_invoice_date.Text).ToString());
                cmd.Parameters.AddWithValue("@es_due_date", Convert.ToDateTime(Txt_due_date.Text).ToString());
                cmd.Parameters.AddWithValue("@es_product_name", Convert.ToString(Dd_enter_product.SelectedItem.Text));
                cmd.Parameters.AddWithValue("@es_quantity", Convert.ToDecimal(txt_quantity2.Text));
                cmd.Parameters.AddWithValue("@es_unit", Convert.ToString(lbl_unit.Value));
                cmd.Parameters.AddWithValue("@es_total_quantity", Convert.ToDecimal(lbl_totalqty.Text));
                cmd.Parameters.AddWithValue("@es_rate", Convert.ToDecimal(txt_rate2.Text));
                cmd.Parameters.AddWithValue("@es_discount", Convert.ToDecimal(Txt_discount.Text));

                cmd.Parameters.AddWithValue("@es_sub_total", Convert.ToDecimal(lbl_subtotal.Text));

                cmd.Parameters.AddWithValue("@es_shipping_charges", "");
                cmd.Parameters.AddWithValue("@es_adjustment", Convert.ToDecimal(Txt_advance.Text));
                cmd.Parameters.AddWithValue("@es_total", Convert.ToDecimal(hide_total.Text));
                cmd.Parameters.AddWithValue("@es_stotal", Convert.ToDecimal(txt_total_amt2.Text));
                cmd.Parameters.AddWithValue("@es_hsn", Convert.ToString(lbl_product_hsn.Value));
                cmd.Parameters.AddWithValue("@es_desc", Convert.ToString(Txt_description.Text));
                cmd.Parameters.AddWithValue("@es_height", "");
                cmd.Parameters.AddWithValue("@es_width", "");
                cmd.Parameters.AddWithValue("@es_size", "");
                cmd.Parameters.AddWithValue("@es_samount", "");

                cmd.Parameters.AddWithValue("@es_balance", Convert.ToDecimal(lbl_balance.Value));
                conn.Open();
                cmd.ExecuteNonQuery();

                conn.Close();
                FillGRid();

            }
            catch (Exception ex)
            {

            }
        }
        else
        {


            try
            {
                SqlCommand cmd = new SqlCommand("insert into tbl_temp_estimate_details values(@es_invoice_no,@es_date,@c_id,@es_order_no,@es_invoice_date,@es_due_date,@es_product_name,@es_quantity,@es_total_quantity,@es_rate,@es_discount,@es_sub_total,@es_shipping_charges,@es_adjustment,@es_total,@es_hsn,@es_unit,@es_stotal,@es_desc,@es_height,@es_width,@es_size,@es_samount,@es_balance)", conn);

                cmd.Parameters.AddWithValue("@es_invoice_no", Convert.ToString(Txt_invoice.Text));
                cmd.Parameters.AddWithValue("@es_date", DateTime.Now.ToShortDateString());
                cmd.Parameters.AddWithValue("@c_id", Convert.ToString(Dd_customer.SelectedValue));
                cmd.Parameters.AddWithValue("@es_order_no", Convert.ToString(Txt_order_no.Text));
                cmd.Parameters.AddWithValue("@es_invoice_date", Convert.ToDateTime(Txt_invoice_date.Text).ToString());
                cmd.Parameters.AddWithValue("@es_due_date", Convert.ToDateTime(Txt_due_date.Text).ToString());
                cmd.Parameters.AddWithValue("@es_product_name", Convert.ToString(Dd_enter_product.SelectedItem.Text));
                cmd.Parameters.AddWithValue("@es_quantity", Convert.ToDecimal(txt_quantity.Text));
                cmd.Parameters.AddWithValue("@es_unit", Convert.ToString(lbl_unit.Value));
                cmd.Parameters.AddWithValue("@es_total_quantity", Convert.ToDecimal(lbl_totalqty.Text));
                cmd.Parameters.AddWithValue("@es_rate", Convert.ToDecimal(txt_rate.Text));
                cmd.Parameters.AddWithValue("@es_discount", Convert.ToDecimal(Txt_discount.Text));

                cmd.Parameters.AddWithValue("@es_sub_total", Convert.ToDecimal(lbl_subtotal.Text));

                cmd.Parameters.AddWithValue("@es_shipping_charges", "");
                cmd.Parameters.AddWithValue("@es_adjustment", Convert.ToDecimal(Txt_advance.Text));
                cmd.Parameters.AddWithValue("@es_total", Convert.ToDecimal(hide_total.Text));
                cmd.Parameters.AddWithValue("@es_stotal", Convert.ToDecimal(txt_total_amt.Text));
                cmd.Parameters.AddWithValue("@es_hsn", Convert.ToString(lbl_product_hsn.Value));
                cmd.Parameters.AddWithValue("@es_desc", Convert.ToString(Txt_description.Text));
                cmd.Parameters.AddWithValue("@es_height", Convert.ToDecimal(txt_height.Text));
                cmd.Parameters.AddWithValue("@es_width", Convert.ToDecimal(txt_width.Text));
                cmd.Parameters.AddWithValue("@es_size", Convert.ToDecimal(txt_sqrft.Text));
                cmd.Parameters.AddWithValue("@es_samount", Convert.ToDecimal(txt_amount.Text));

                cmd.Parameters.AddWithValue("@es_balance", Convert.ToDecimal(lbl_balance.Value));
                conn.Open();
                cmd.ExecuteNonQuery();

                conn.Close();
                FillGRid();

            }
            catch (Exception ex)
            {

            }
        }
    }
    protected void GridView1_DataBound(object sender, EventArgs e)
    {

    }
    int total = 0, indexofcolumn = 1;
    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.Cells.Count > indexofcolumn)
        {
            e.Row.Cells[2].Visible = false;
            e.Row.Cells[3].Visible = false;
            e.Row.Cells[9].Visible = false;
            e.Row.Cells[10].Visible = false;
            e.Row.Cells[11].Visible = false;
        

        }
       
    }

    protected void Dd_enter_product_SelectedIndexChanged(object sender, EventArgs e)
    {
        string pro_name = Dd_enter_product.SelectedItem.Text;
        string rate, cgst, igst, sgst, hsn, unit, desc;
        SqlCommand cmd = new SqlCommand("select * from tbl_product where p_name ='" + pro_name.ToString() + "'", conn);
        SqlDataAdapter adapt = new SqlDataAdapter(cmd);
        DataTable dt = new DataTable();

        adapt.Fill(dt);
        if (dt.Rows.Count > 0)
        {
            rate = dt.Rows[0]["p_rate"].ToString();
            cgst = dt.Rows[0]["p_cgst"].ToString();
            sgst = dt.Rows[0]["p_sgst"].ToString();
            igst = dt.Rows[0]["p_igst"].ToString();
            hsn = dt.Rows[0]["p_hsn_code"].ToString();
            unit = dt.Rows[0]["p_unit"].ToString();
            desc = dt.Rows[0]["p_desc"].ToString();
            // cgst = Dd_enter_cgst.Text;

            if (unit == "Pcs")
            {
                Panel1.Visible = false;
                Panel2.Visible = true;
                txt_rate2.Text = rate;
            }
           else if (unit == "Ltr")
            {
                Panel1.Visible = false;
                Panel2.Visible = true;
                txt_rate2.Text = rate;
            }
            else
            {
                Panel1.Visible = true;
                Panel2.Visible = false;
                txt_rate.Text = rate;
            }
            //Dd_enter_cgst.Text = cgst;
            //Dd_enter_igst.Text = igst;
            //Dd_enter_sgst.Text = sgst;

            txt_rate.Text = rate;
            Txt_description.Text = desc;

            lbl_product_hsn.Value = hsn;
            lbl_unit.Value = unit;
        }
    }


    public void material()
    {
        string query = "select * from tbl_purchase_product Order By p_name asc";
        SqlDataAdapter adapt5 = new SqlDataAdapter(query, conn);
        DataTable dt6 = new DataTable();
        adapt5.Fill(dt6);
        if (dt6.Rows.Count > 0)
        {
            Dd_material.DataSource = dt6;
            Dd_material.DataBind();
            Dd_material.DataTextField = "p_name";

            Dd_material.DataValueField = "p_id";
            Dd_material.DataBind();
            Dd_material.Items.Insert(0, new ListItem("--Select--", "--Select--"));
            Dd_material.SelectedItem.Selected = false;
            Dd_material.Items.FindByText("--Select--").Selected = true;
        }

    }

    protected void Dd_material_SelectedIndexChanged(object sender, EventArgs e)
    {

        string pro_name = Dd_material.SelectedValue;
        SqlCommand cmd4 = new SqlCommand("select * from tbl_purchase_product where p_id ='" + pro_name.ToString() + "'", conn);
        SqlDataAdapter adapt4 = new SqlDataAdapter(cmd4);
        DataTable dt4 = new DataTable();

        adapt4.Fill(dt4);
        if (dt4.Rows.Count > 0)
        {
            lbl_available.Text = dt4.Rows[0]["p_stock"].ToString();


        }

    }

    protected void Btn_generate_pdf_Click(object sender, EventArgs e)
    {

        if (GridView1.Rows.Count == 0)
        {
            System.Web.UI.ScriptManager.RegisterStartupScript(this, GetType(), "displayalertmessage", "alert('Please Add Products First !!!');", true);
        }
        else
        {
            try
            {
                SqlCommand cmd4 = new SqlCommand("select * from tbl_estimate_details where es_invoice_no='" + invoice + "'", conn);
                SqlDataAdapter adapt4 = new SqlDataAdapter(cmd4);
                DataTable dt4 = new DataTable();
                adapt4.Fill(dt4);
                if (dt4.Rows.Count > 0)
                {
                    Old_total = Convert.ToDecimal(dt4.Rows[0]["es_total"]);
                    old_balance = Convert.ToDecimal(dt4.Rows[0]["es_balance"]);
                    paid = Old_total - old_balance;
                    new_total = Convert.ToDecimal(hide_total.Text);
                    new_balance = new_total - paid;
                    rem = new_total - Old_total;
                }

                SqlCommand cmd5 = new SqlCommand("DELETE FROM tbl_estimate_details Where es_invoice_no='" + invoice + "'", conn);
                conn.Open();
                cmd5.ExecuteNonQuery();
                conn.Close();
            
                int rowscount = GridView1.Rows.Count;
                for (int i = 0; i < rowscount; i++)
                {
                   

                        SqlCommand cmd = new SqlCommand("insert into tbl_estimate_details values(@qw_quotation_no,@qw_date,@c_id,@qw_order_no,@qw_quotation_date,@qw_valid_date,@qw_product_name,@qw_quantity,@qw_total_quantity,@qw_rate,@qw_discount,@qw_sub_total,@qw_shipping_charges,@qw_adjustment,@qw_total,@qw_hsn,@qw_unit,@qw_stotal,@qw_desc,@qw_height,@qw_width,@qw_size,@qw_samount,@qw_balance,@es_dtp_charges,@es_fitting_charges,@est_payment_method,@est_order_ref,@est_material,@es_pasting_charges,@es_framing_charges,@es_installation_charges)", conn);
                        cmd.Parameters.AddWithValue("@qw_quotation_no", Convert.ToString(Txt_invoice.Text));
                        cmd.Parameters.AddWithValue("@qw_date", Convert.ToDateTime(DateTime.Now.ToShortDateString()).ToString("MM/dd/yyyy"));
                        cmd.Parameters.AddWithValue("@c_id", Convert.ToString(Dd_customer.SelectedValue));
                        cmd.Parameters.AddWithValue("@qw_order_no", Convert.ToString(Txt_order_no.Text));
                        cmd.Parameters.AddWithValue("@qw_quotation_date", Convert.ToDateTime(Txt_invoice_date.Text).ToString("MM/dd/yyyy"));
                        cmd.Parameters.AddWithValue("@qw_valid_date", Convert.ToDateTime(Txt_due_date.Text).ToString("MM/dd/yyyy"));
                        cmd.Parameters.AddWithValue("@qw_product_name", Convert.ToString(GridView1.Rows[i].Cells[0].Text));
                        cmd.Parameters.AddWithValue("@qw_quantity", Convert.ToDecimal(GridView1.Rows[i].Cells[7].Text));
                        cmd.Parameters.AddWithValue("@qw_unit", Convert.ToString(GridView1.Rows[i].Cells[10].Text));
                        cmd.Parameters.AddWithValue("@qw_total_quantity", Convert.ToDecimal(lbl_totalqty.Text));
                        cmd.Parameters.AddWithValue("@qw_rate", Convert.ToDecimal(GridView1.Rows[i].Cells[5].Text));
                        cmd.Parameters.AddWithValue("@qw_discount", Convert.ToDecimal(Txt_discount.Text));

                        cmd.Parameters.AddWithValue("@qw_sub_total", Convert.ToDecimal(lbl_subtotal.Text));

                    if (Txt_TransportCharges.Text == "")
                    {
                        cmd.Parameters.AddWithValue("@qw_shipping_charges", "0");
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@qw_shipping_charges", Txt_TransportCharges.Text);
                    }

                        cmd.Parameters.AddWithValue("@qw_adjustment", Convert.ToDecimal(Txt_advance.Text));
                        cmd.Parameters.AddWithValue("@qw_total", Convert.ToDecimal(hide_total.Text));
                        cmd.Parameters.AddWithValue("@qw_stotal", Convert.ToDecimal(GridView1.Rows[i].Cells[8].Text));
                    if (GridView1.Rows[i].Cells[1].Text.Trim() == "&amp;nbsp;")
                    {
                        cmd.Parameters.AddWithValue("@qw_hsn", "");
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@qw_hsn", Convert.ToString(GridView1.Rows[i].Cells[1].Text.Trim()));
                    }
                    if (GridView1.Rows[i].Cells[9].Text.Trim() == "&amp;nbsp;")
                    {
                        cmd.Parameters.AddWithValue("@qw_desc", "");
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@qw_desc", Convert.ToString(GridView1.Rows[i].Cells[9].Text.Trim()));
                    }
                        cmd.Parameters.AddWithValue("@qw_height", Convert.ToDecimal(GridView1.Rows[i].Cells[2].Text));
                        cmd.Parameters.AddWithValue("@qw_width", Convert.ToDecimal(GridView1.Rows[i].Cells[3].Text));
                        cmd.Parameters.AddWithValue("@qw_size", Convert.ToDecimal(GridView1.Rows[i].Cells[4].Text));
                        cmd.Parameters.AddWithValue("@qw_samount", Convert.ToDecimal(GridView1.Rows[i].Cells[6].Text));

                    //new variable 

                    if (Txt_Dtp_charges.Text == "")
                    {
                        cmd.Parameters.AddWithValue("@es_dtp_charges", "0");
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@es_dtp_charges", Convert.ToDecimal(Txt_Dtp_charges.Text));
                    }

                    if (Txt_Fitting.Text == "")
                    {
                        cmd.Parameters.AddWithValue("@es_fitting_charges", "0");
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@es_fitting_charges", Convert.ToDecimal(Txt_Fitting.Text));
                    }

                    cmd.Parameters.AddWithValue("@est_payment_method", drp_payment.SelectedItem.Text);

                    //end new varialb


                    cmd.Parameters.AddWithValue("@qw_balance", new_balance);
                    cmd.Parameters.AddWithValue("@est_order_ref", drp_designer.Text);
                    cmd.Parameters.AddWithValue("@est_material", Convert.ToDecimal(GridView1.Rows[i].Cells[11].Text));

                    if (Txt_Pasting.Text == "")
                    {
                        cmd.Parameters.AddWithValue("@es_pasting_charges", "0");
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@es_pasting_charges", Convert.ToDecimal(Txt_Pasting.Text));
                    }

                    if (Txt_Framing.Text == "")
                    {
                        cmd.Parameters.AddWithValue("@es_framing_charges", "0");
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@es_framing_charges", Convert.ToDecimal(Txt_Framing.Text));
                    }

                    if (Txt_install.Text == "")
                    {
                        cmd.Parameters.AddWithValue("@es_installation_charges", "0");
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@es_installation_charges", Convert.ToDecimal(Txt_install.Text));
                    }

                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();
                    }
                
                SqlCommand cmd2 = new SqlCommand("update tbl_estimate SET est_invoice_no='"+ Convert.ToString(Txt_invoice.Text) + "',est_date='" + Convert.ToDateTime(lbl_date.Value).ToString("MM/dd/yyyy") + "',c_id='" + Dd_customer.SelectedValue + "',est_order_no='" + Convert.ToString(Txt_order_no.Text) + "',est_invoice_date='" + Convert.ToDateTime(Txt_invoice_date.Text).ToString("MM/dd/yyyy") + "',est_due_date='" + Convert.ToDateTime(Txt_due_date.Text).ToString("MM/dd/yyyy") + "',est_total_quantity='" + Convert.ToDecimal(lbl_totalqty.Text) + "',est_discount='" + Convert.ToDecimal(Txt_discount.Text) + "',est_sub_total='" + Convert.ToDecimal(lbl_subtotal.Text) + "',est_adjustment='" + Convert.ToDecimal(Txt_advance.Text) + "',est_total='" + Convert.ToDecimal(hide_total.Text) + "',est_balance='" + new_balance + "',est_dtp_charges='"+Txt_Dtp_charges.Text+ "',est_fitting_charges='"+Txt_Fitting.Text+ "',est_shipping_charges='"+Txt_TransportCharges.Text+"' where est_invoice_no='" + Convert.ToString(Txt_invoice.Text) + "'", conn);
               
                conn.Open();
                cmd2.ExecuteNonQuery();
                conn.Close();

                SqlCommand cmd3 = new SqlCommand("update tbl_customer set c_opening_balance= c_opening_balance + '" + rem + "' where c_id='" + Dd_customer.SelectedValue + "'", conn);

                conn.Open();
                cmd3.ExecuteNonQuery();

                conn.Close();

                Response.Redirect("wgst_bill.aspx?invoice=" + Txt_invoice.Text + "&bill_update=success");
            }
            catch (Exception ex)
            { }

            
        
        }
    }
    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        //GridView1.PageIndex = e.NewPageIndex;


    }

  
    protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {


    }

    protected void GridView1_RowCreated(object sender, GridViewRowEventArgs e)
    {
        GridViewRow row = e.Row;
        TableCell cell = e.Row.Cells[0];
        e.Row.Cells.RemoveAt(0);
        e.Row.Cells.Add(cell);
    }

    

    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
       

    }

    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {
        Dd_enter_product.SelectedItem.Text = GridView1.SelectedRow.Cells[0].Text;
        lbl_product_hsn.Value = GridView1.SelectedRow.Cells[1].Text;
        txt_height.Text = GridView1.SelectedRow.Cells[2].Text;
        txt_width.Text = GridView1.SelectedRow.Cells[3].Text;
        txt_sqrft.Text = GridView1.SelectedRow.Cells[4].Text;
        //txt_rate.Text = GridView1.SelectedRow.Cells[5].Text;
        txt_amount.Text = GridView1.SelectedRow.Cells[6].Text;
        //txt_quantity.Text = GridView1.SelectedRow.Cells[7].Text;
        //txt_total_amt.Text = GridView1.SelectedRow.Cells[8].Text;
        
        Txt_description.Text = GridView1.SelectedRow.Cells[9].Text;
        lbl_unit.Value = GridView1.SelectedRow.Cells[10].Text;
        lbl_id.Value = GridView1.SelectedRow.Cells[11].Text;
        if (lbl_unit.Value == "Pcs")
        {
            Panel1.Visible = false;
            Panel2.Visible = true;
            txt_rate2.Text = GridView1.SelectedRow.Cells[5].Text;
            txt_quantity2.Text = GridView1.SelectedRow.Cells[7].Text;
            txt_total_amt2.Text = GridView1.SelectedRow.Cells[8].Text;
        }
       else if (lbl_unit.Value == "Ltr")
        {
            Panel1.Visible = false;
            Panel2.Visible = true;
            txt_rate2.Text = GridView1.SelectedRow.Cells[5].Text;
            txt_quantity2.Text = GridView1.SelectedRow.Cells[7].Text;
            txt_total_amt2.Text = GridView1.SelectedRow.Cells[8].Text;
        }
        else
        {
            Panel1.Visible = true;
            Panel2.Visible = false;
            txt_rate.Text = GridView1.SelectedRow.Cells[5].Text;
            txt_quantity.Text = GridView1.SelectedRow.Cells[7].Text;
            txt_total_amt.Text = GridView1.SelectedRow.Cells[8].Text;
        }

    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        if (lbl_unit.Value == "Pcs")
        {
            txt_height2.Text = "0";
            txt_width2.Text = "0";
            txt_sqrft2.Text = "0";
           
            SqlCommand cmd = new SqlCommand("update tbl_temp_estimate_details set es_product_name='" + Dd_enter_product.SelectedItem.Text + "',es_hsn='" + lbl_product_hsn.Value + "',es_height='" + txt_height2.Text + "',es_width='" + txt_width2.Text + "',es_size='" + txt_sqrft2.Text + "',es_rate='" + txt_rate2.Text + "',es_samount='" + txt_amount2.Text + "',es_quantity='" + txt_quantity2.Text + "',es_stotal='" + txt_total_amt2.Text + "',es_desc='" + Txt_description.Text + "',es_unit='" + lbl_unit.Value + "' WHERE es_id='" + lbl_id.Value.Trim() + "'", conn);

            conn.Open();
            cmd.ExecuteNonQuery();

            conn.Close();
            FillGRid();
        }
       else if (lbl_unit.Value == "Ltr")
        {
            txt_height2.Text = "0";
            txt_width2.Text = "0";
            txt_sqrft2.Text = "0";

            SqlCommand cmd = new SqlCommand("update tbl_temp_estimate_details set es_product_name='" + Dd_enter_product.SelectedItem.Text + "',es_hsn='" + lbl_product_hsn.Value + "',es_height='" + txt_height2.Text + "',es_width='" + txt_width2.Text + "',es_size='" + txt_sqrft2.Text + "',es_rate='" + txt_rate2.Text + "',es_samount='" + txt_amount2.Text + "',es_quantity='" + txt_quantity2.Text + "',es_stotal='" + txt_total_amt2.Text + "',es_desc='" + Txt_description.Text + "',es_unit='" + lbl_unit.Value + "' WHERE es_id='" + lbl_id.Value.Trim() + "'", conn);

            conn.Open();
            cmd.ExecuteNonQuery();

            conn.Close();
            FillGRid();
        }
        else
        {
             SqlCommand cmd = new SqlCommand("update tbl_temp_estimate_details set es_product_name='" + Dd_enter_product.SelectedItem.Text + "',es_hsn='" + lbl_product_hsn.Value + "',es_height='" + txt_height.Text + "',es_width='" + txt_width.Text + "',es_size='" + txt_sqrft.Text + "',es_rate='" + txt_rate.Text + "',es_samount='" + txt_amount.Text + "',es_quantity='" + txt_quantity.Text + "',es_stotal='" + txt_total_amt.Text + "',es_desc='" + Txt_description.Text + "',es_unit='" + lbl_unit.Value + "' WHERE es_id='" + lbl_id.Value.Trim() + "'", conn);

            conn.Open();
            cmd.ExecuteNonQuery();

            conn.Close();
            FillGRid();
        }
    }

    protected void Button2_Click(object sender, EventArgs e)
    {
        int i = Convert.ToInt32(GridView1.SelectedRow.Cells[11].Text);

        SqlCommand cmd = new SqlCommand("Delete from tbl_temp_estimate_details where es_id='" + i + "'", conn);
        conn.Open();
        cmd.ExecuteNonQuery();
        conn.Close();
        FillGRid();

    }

    protected void Button3_Click(object sender, EventArgs e)
    {
        GridView1.SelectedIndex = -1;
        Dd_enter_product.SelectedItem.Text = "--Select---";
        lbl_product_hsn.Value = "";
        txt_height.Text = "";
        txt_width.Text = "";
        txt_sqrft.Text = "";
        txt_rate.Text = "";
        txt_rate2.Text = "";
        txt_amount.Text = "";
        txt_quantity.Text = "";
        txt_quantity2.Text = "";
        txt_total_amt.Text = "";
        txt_total_amt2.Text = "";
        Txt_description.Text = "";
        lbl_unit.Value = "";
        lbl_id.Value = "";
    }

    protected void drp_order_ref_SelectedIndexChanged(object sender, EventArgs e)
    {
        // order_ref_total();
    }
}