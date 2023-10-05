using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;


public partial class Quotation_edit_wgst_quat : System.Web.UI.Page
{
    SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["String"].ConnectionString);
    decimal total_amount = 0, final_total = 0;
    decimal dPageTotal, finaltotal;
    decimal totalvalue, totalcgst, totalsgst, totaligst, totalgst, totalqty, totaltaxable, Old_total, old_balance, paid, new_balance, new_total, rem;
    string quot;
    int id;
    string admin_email;

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
                quot = Request.QueryString["quot"].ToString();
                if (!IsPostBack)
                {
                    Panel1.Visible = true;
                    Panel2.Visible = false;

                    RefreshData();
                    this.customer();
                    this.product();
                    GetData();

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
        string query = "select * from tbl_customer";
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
        string query = "select * from tbl_product order by p_name asc";
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

    protected void GetData()
    {

        SqlCommand cmd = new SqlCommand("select * from tbl_without_gst_quotation_details where qw_quotation_no='" + quot + "'", conn);
        SqlDataAdapter adapt = new SqlDataAdapter(cmd);
        DataTable dt = new DataTable();
        adapt.Fill(dt);
        if (dt.Rows.Count > 0)
        {
            id = Convert.ToInt32(dt.Rows[0]["qw_id"]);
            Dd_customer.SelectedValue = dt.Rows[0]["c_id"].ToString();
            Txt_invoice.Text = dt.Rows[0]["qw_quotation_no"].ToString();

            lbl_date.Value = Convert.ToDateTime(dt.Rows[0]["qw_date"]).ToString("MM/dd/yyyy");
            Txt_invoice_date.Text = Convert.ToDateTime(dt.Rows[0]["qw_quotation_date"]).ToString("MM/dd/yyyy");
            Txt_due_date.Text = Convert.ToDateTime(dt.Rows[0]["qw_valid_date"]).ToString("MM/dd/yyyy");
            //lbl_totalqty.Text = dt.Rows[0]["s_total_quantity"].ToString();
            lbl_subtotal.Text = dt.Rows[0]["qw_sub_total"].ToString();
            lbl_subtotal2.Value = dt.Rows[0]["qw_sub_total"].ToString();
            //lbl_gst.Text = dt.Rows[0]["q_total_gst"].ToString();
            Txt_Pasting.Text = dt.Rows[0]["qw_pasting_charges"].ToString();
            Txt_Fitting.Text = dt.Rows[0]["qw_fitting_charges"].ToString();
            drp_payment.Text = dt.Rows[0]["qw_payment_method"].ToString();
            Txt_TransportCharges.Text = dt.Rows[0]["qw_shipping_charges"].ToString();
            Txt_advance.Text = dt.Rows[0]["qw_adjustment"].ToString();
            Txt_discount.Text = dt.Rows[0]["qw_discount"].ToString();
            lbl_total.Text = dt.Rows[0]["qw_total"].ToString();
            hide_total.Text = dt.Rows[0]["qw_total"].ToString();
            lbl_final.Text = dt.Rows[0]["qw_total"].ToString();
            Txt_Dtp_charges.Text = dt.Rows[0]["qw_dtp_charges"].ToString();
            //lbl_balance.Value = dt.Rows[0]["q_balance"].ToString();

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
            SqlCommand cmd = new SqlCommand("delete from tbl_temp_without_gst_quotation_details", conn);
            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();

            if (conn.State != ConnectionState.Closed)
            {
                conn.Close();
            }
            SqlCommand cmd2 = new SqlCommand("insert into tbl_temp_without_gst_quotation_details select qw_quotation_no,qw_date,c_id,qw_quotation_date,qw_valid_date,qw_product_name,qw_quantity,qw_total_quantity,qw_rate,qw_discount,qw_sub_total,qw_shipping_charges,qw_adjustment,qw_total,qw_hsn,qw_unit,qw_stotal,qw_desc,qw_height,qw_width,qw_size,qw_samount from tbl_without_gst_quotation_details where qw_quotation_no='" + quot + "'", conn);
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


            SqlCommand cmd = new SqlCommand("select qw_product_name as Product,qw_hsn as HSN,qw_height as Height,qw_width as Width,qw_size as SQRFT,qw_rate as Rate,qw_samount as Amount,qw_quantity as Qty,qw_stotal as Total,qw_desc as [desc],qw_unit as unit,qw_id as[ID] from tbl_temp_without_gst_quotation_details where qw_quotation_no='" + quot + "'", conn);
            SqlDataAdapter adapt = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapt.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                GridView1.DataSource = dt;
                GridView1.DataBind();
                totalqty = Convert.ToDecimal(dt.Compute("Sum(Qty)", ""));
                totalvalue = Convert.ToDecimal(dt.Compute("Sum(Total)", ""));
                totaltaxable = Convert.ToDecimal(dt.Compute("Sum(Total)", ""));

                

                //Assign the total value to footer label control
                lbl_subtotal.Text = totalvalue.ToString();
                lbl_subtotal2.Value = totalvalue.ToString();

                //Assign the total value to footer label control
              
                lbl_totalqty.Text = totalqty.ToString();
                
                lbl_total_taxable.Value = totaltaxable.ToString();


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
        GetData();
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
      

        
        string desc = Txt_description.Text;




        //new data end

        if (str9 == "Pcs")
        {

           


            try
            {
                SqlCommand cmd = new SqlCommand("insert into tbl_temp_without_gst_quotation_details values(@qw_quotation_no,@qw_date,@c_id,@qw_quotation_date,@qw_valid_date,@qw_product_name,@qw_quantity,@qw_total_quantity,@qw_rate,@qw_discount,@qw_sub_total,@qw_shipping_charges,@qw_adjustment,@qw_total,@qw_hsn,@qw_unit,@qw_stotal,@qw_desc,@qw_height,@qw_width,@qw_size,@qw_samount)", conn);

                cmd.Parameters.AddWithValue("@qw_quotation_no", Convert.ToString(Txt_invoice.Text));
                cmd.Parameters.AddWithValue("@qw_date", DateTime.Now.ToShortDateString());
                cmd.Parameters.AddWithValue("@c_id", Convert.ToString(Dd_customer.SelectedValue));
                cmd.Parameters.AddWithValue("@qw_quotation_date", Convert.ToDateTime(Txt_invoice_date.Text).ToString());
                cmd.Parameters.AddWithValue("@qw_valid_date", Convert.ToDateTime(Txt_due_date.Text).ToString());
                cmd.Parameters.AddWithValue("@qw_product_name", Convert.ToString(Dd_enter_product.SelectedItem.Text));
                cmd.Parameters.AddWithValue("@qw_quantity", Convert.ToDecimal(txt_quantity2.Text));
                cmd.Parameters.AddWithValue("@qw_unit", Convert.ToString(lbl_unit.Value));
                cmd.Parameters.AddWithValue("@qw_total_quantity", Convert.ToDecimal(lbl_totalqty.Text));
                cmd.Parameters.AddWithValue("@qw_rate", Convert.ToDecimal(txt_rate2.Text));
                cmd.Parameters.AddWithValue("@qw_discount", Convert.ToDecimal(Txt_discount.Text));
                cmd.Parameters.AddWithValue("@qw_sub_total", Convert.ToDecimal(lbl_subtotal.Text));
                cmd.Parameters.AddWithValue("@qw_shipping_charges", Convert.ToDecimal(Txt_TransportCharges.Text));
                cmd.Parameters.AddWithValue("@qw_adjustment", Convert.ToDecimal(Txt_advance.Text));
                cmd.Parameters.AddWithValue("@qw_total", Convert.ToDecimal(hide_total.Text));
                cmd.Parameters.AddWithValue("@qw_stotal", Convert.ToDecimal(txt_total_amt2.Text));
                cmd.Parameters.AddWithValue("@qw_hsn", Convert.ToString(lbl_product_hsn.Value));
                cmd.Parameters.AddWithValue("@qw_desc", Convert.ToString(Txt_description.Text));
                cmd.Parameters.AddWithValue("@qw_height", "");
                cmd.Parameters.AddWithValue("@qw_width", "");
                cmd.Parameters.AddWithValue("@qw_size", "");
                cmd.Parameters.AddWithValue("@qw_samount", "");
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
                SqlCommand cmd = new SqlCommand("insert into tbl_temp_without_gst_quotation_details values(@qw_quotation_no,@qw_date,@c_id,@qw_quotation_date,@qw_valid_date,@qw_product_name,@qw_quantity,@qw_total_quantity,@qw_rate,@qw_discount,@qw_sub_total,@qw_shipping_charges,@qw_adjustment,@qw_total,@qw_hsn,@qw_unit,@qw_stotal,@qw_desc,@qw_height,@qw_width,@qw_size,@qw_samount)", conn);

                cmd.Parameters.AddWithValue("@qw_quotation_no", Convert.ToString(Txt_invoice.Text));
                cmd.Parameters.AddWithValue("@qw_date", DateTime.Now.ToShortDateString());
                cmd.Parameters.AddWithValue("@c_id", Convert.ToString(Dd_customer.SelectedValue));

                cmd.Parameters.AddWithValue("@qw_quotation_date", Convert.ToDateTime(Txt_invoice_date.Text).ToString());
                cmd.Parameters.AddWithValue("@qw_valid_date", Convert.ToDateTime(Txt_due_date.Text).ToString());
                cmd.Parameters.AddWithValue("@qw_product_name", Convert.ToString(Dd_enter_product.SelectedItem.Text));
                cmd.Parameters.AddWithValue("@qw_quantity", Convert.ToDecimal(txt_quantity2.Text));
                cmd.Parameters.AddWithValue("@qw_unit", Convert.ToString(lbl_unit.Value));
                cmd.Parameters.AddWithValue("@qw_total_quantity", Convert.ToDecimal(lbl_totalqty.Text));
                cmd.Parameters.AddWithValue("@qw_rate", Convert.ToDecimal(txt_rate2.Text));
                cmd.Parameters.AddWithValue("@qw_discount", Convert.ToDecimal(Txt_discount.Text));
                cmd.Parameters.AddWithValue("@qw_sub_total", Convert.ToDecimal(lbl_subtotal.Text));
                cmd.Parameters.AddWithValue("@qw_shipping_charges", Convert.ToDecimal(Txt_TransportCharges.Text));
                cmd.Parameters.AddWithValue("@qw_adjustment", Convert.ToDecimal(Txt_advance.Text));
                cmd.Parameters.AddWithValue("@qw_total", Convert.ToDecimal(hide_total.Text));
                cmd.Parameters.AddWithValue("@qw_stotal", Convert.ToDecimal(txt_total_amt2.Text));
                cmd.Parameters.AddWithValue("@qw_hsn", Convert.ToString(lbl_product_hsn.Value));
                cmd.Parameters.AddWithValue("@qw_desc", Convert.ToString(Txt_description.Text));
                cmd.Parameters.AddWithValue("@qw_height", "");
                cmd.Parameters.AddWithValue("@qw_width", "");
                cmd.Parameters.AddWithValue("@qw_size", "");
                cmd.Parameters.AddWithValue("@qw_samount", "");
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
                SqlCommand cmd = new SqlCommand("insert into tbl_temp_without_gst_quotation_details values(@qw_quotation_no,@qw_date,@c_id,@qw_quotation_date,@qw_valid_date,@qw_product_name,@qw_quantity,@qw_total_quantity,@qw_rate,@qw_discount,@qw_sub_total,@qw_shipping_charges,@qw_adjustment,@qw_total,@qw_hsn,@qw_unit,@qw_stotal,@qw_desc,@qw_height,@qw_width,@qw_size,@qw_samount)", conn);

                cmd.Parameters.AddWithValue("@qw_quotation_no", Convert.ToString(Txt_invoice.Text));
                cmd.Parameters.AddWithValue("@qw_date", DateTime.Now.ToShortDateString());
                cmd.Parameters.AddWithValue("@c_id", Convert.ToString(Dd_customer.SelectedValue));

                cmd.Parameters.AddWithValue("@qw_quotation_date", Convert.ToDateTime(Txt_invoice_date.Text).ToString());
                cmd.Parameters.AddWithValue("@qw_valid_date", Convert.ToDateTime(Txt_due_date.Text).ToString());
                cmd.Parameters.AddWithValue("@qw_product_name", Convert.ToString(Dd_enter_product.SelectedItem.Text));
                cmd.Parameters.AddWithValue("@qw_quantity", Convert.ToDecimal(txt_quantity.Text));
                cmd.Parameters.AddWithValue("@qw_unit", Convert.ToString(lbl_unit.Value));
                cmd.Parameters.AddWithValue("@qw_total_quantity", Convert.ToDecimal(lbl_totalqty.Text));
                cmd.Parameters.AddWithValue("@qw_rate", Convert.ToDecimal(txt_rate.Text));
                cmd.Parameters.AddWithValue("@qw_discount", Convert.ToDecimal(Txt_discount.Text));
                cmd.Parameters.AddWithValue("@qw_sub_total", Convert.ToDecimal(lbl_subtotal.Text));
                cmd.Parameters.AddWithValue("@qw_shipping_charges", Convert.ToDecimal(Txt_TransportCharges.Text));
                cmd.Parameters.AddWithValue("@qw_adjustment", Convert.ToDecimal(Txt_advance.Text));
                cmd.Parameters.AddWithValue("@qw_total", Convert.ToDecimal(hide_total.Text));
                cmd.Parameters.AddWithValue("@qw_stotal", Convert.ToDecimal(txt_total_amt.Text));
                cmd.Parameters.AddWithValue("@qw_hsn", Convert.ToString(lbl_product_hsn.Value));
                cmd.Parameters.AddWithValue("@qw_desc", Convert.ToString(Txt_description.Text));
                cmd.Parameters.AddWithValue("@qw_height", Convert.ToDecimal(txt_height.Text));
                cmd.Parameters.AddWithValue("@qw_width", Convert.ToDecimal(txt_width.Text));
                cmd.Parameters.AddWithValue("@qw_size", Convert.ToDecimal(txt_sqrft.Text));
                cmd.Parameters.AddWithValue("@qw_samount", Convert.ToDecimal(txt_amount.Text));
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
            
            txt_rate.Text = rate;
            Txt_description.Text = desc;

            lbl_product_hsn.Value = hsn;
            lbl_unit.Value = unit;
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
                SqlCommand cmd4 = new SqlCommand("select * from tbl_without_gst_quotation_details where qw_quotation_no='" + quot + "'", conn);
                SqlDataAdapter adapt4 = new SqlDataAdapter(cmd4);
                DataTable dt4 = new DataTable();
                adapt4.Fill(dt4);
                if (dt4.Rows.Count > 0)
                {
                    Old_total = Convert.ToDecimal(dt4.Rows[0]["qw_total"]);

                    //paid = Old_total - old_balance;
                    new_total = Convert.ToDecimal(hide_total.Text) - Convert.ToDecimal(Txt_discount.Text);
                    new_balance = new_total;
                    rem = new_total;
                }

                SqlCommand cmd5 = new SqlCommand("DELETE FROM tbl_without_gst_quotation_details Where qw_quotation_no='" + quot + "'", conn);
                conn.Open();
                cmd5.ExecuteNonQuery();
                conn.Close();

                int rowscount = GridView1.Rows.Count;
                for (int i = 0; i < rowscount; i++)
                {


                    SqlCommand cmd = new SqlCommand("insert into tbl_without_gst_quotation_details values(@qw_quotation_no,@qw_date,@c_id,@qw_quotation_date,@qw_valid_date,@qw_product_name,@qw_quantity,@qw_total_quantity,@qw_rate,@qw_discount,@qw_sub_total,@qw_shipping_charges,@qw_adjustment,@qw_total,@qw_hsn,@qw_unit,@qw_stotal,@qw_desc,@qw_height,@qw_width,@qw_size,@qw_samount,@qw_balance,@qw_dtp_charges,@qw_fitting_charges,@qw_payment_method,@qw_pasting_charges)", conn);
                    cmd.Parameters.AddWithValue("@qw_quotation_no", Convert.ToString(Txt_invoice.Text));
                    cmd.Parameters.AddWithValue("@qw_date", lbl_date.Value.ToString());
                    cmd.Parameters.AddWithValue("@c_id", Convert.ToString(Dd_customer.SelectedValue));

                    cmd.Parameters.AddWithValue("@qw_quotation_date", Txt_invoice_date.Text);
                    cmd.Parameters.AddWithValue("@qw_valid_date", Txt_due_date.Text);
                    cmd.Parameters.AddWithValue("@qw_product_name", Convert.ToString(GridView1.Rows[i].Cells[0].Text));
                    cmd.Parameters.AddWithValue("@qw_quantity", Convert.ToDecimal(GridView1.Rows[i].Cells[7].Text));
                   
                    cmd.Parameters.AddWithValue("@qw_total_quantity", Convert.ToDecimal(lbl_totalqty.Text));
                    cmd.Parameters.AddWithValue("@qw_rate", Convert.ToDecimal(GridView1.Rows[i].Cells[5].Text));
                    cmd.Parameters.AddWithValue("@qw_discount", Convert.ToDecimal(Txt_discount.Text));
                    cmd.Parameters.AddWithValue("@qw_sub_total", Convert.ToDecimal(lbl_subtotal.Text));
                    cmd.Parameters.AddWithValue("@qw_shipping_charges", Convert.ToDecimal(Txt_TransportCharges.Text));
                    cmd.Parameters.AddWithValue("@qw_adjustment", Convert.ToDecimal(Txt_advance.Text));
                    cmd.Parameters.AddWithValue("@qw_total", Convert.ToDecimal(hide_total.Text));
                    
                    cmd.Parameters.AddWithValue("@qw_unit", Convert.ToString(GridView1.Rows[i].Cells[10].Text));
                    
                   
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
                    cmd.Parameters.AddWithValue("@qw_balance", Convert.ToString(new_balance));
                    cmd.Parameters.AddWithValue("@qw_dtp_charges", Convert.ToDecimal(Txt_Dtp_charges.Text));
                    cmd.Parameters.AddWithValue("@qw_fitting_charges", Convert.ToDecimal(Txt_Fitting.Text));
                    cmd.Parameters.AddWithValue("@qw_payment_method", Convert.ToString(drp_payment.SelectedItem.Text));
                    cmd.Parameters.AddWithValue("@qw_pasting_charges", Convert.ToDecimal(Txt_Pasting.Text));
                    conn.Open();
                    cmd.ExecuteNonQuery();

                    conn.Close();
                }
                SqlCommand cmd2 = new SqlCommand("update tbl_without_gst_quotation SET quw_invoice_no='" + Convert.ToString(Txt_invoice.Text) + "',quw_date='" + Convert.ToDateTime(lbl_date.Value).ToString("MM/dd/yyyy") + "',c_id='" + Convert.ToString(Dd_customer.SelectedValue) + "',quw_invoice_date='" + Convert.ToDateTime(Txt_invoice_date.Text).ToString("MM/dd/yyyy") + "',quw_due_date='" + Convert.ToDateTime(Txt_due_date.Text).ToString("MM/dd/yyyy") + "',quw_total_quantity='" + Convert.ToDecimal(lbl_totalqty.Text) + "',quw_discount='" + Convert.ToDecimal(Txt_discount.Text) + "',quw_sub_total='" + Convert.ToDecimal(lbl_subtotal.Text) + "',quw_shipping_charges='" + Convert.ToDecimal(Txt_TransportCharges.Text) + "',quw_adjustment='" + Convert.ToDecimal(Txt_advance.Text) + "',quw_total='" + Convert.ToDecimal(hide_total.Text) + "' where quw_invoice_no='" + Txt_invoice.Text + "' ", conn);

                conn.Open();
                cmd2.ExecuteNonQuery();
                conn.Close();

                Lbl_message.Text = "" + Dd_customer.Text + " Added Successfully!!!";

                Response.Redirect("report.aspx");



            }
            catch (Exception ex) { }


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
        if (e.CommandName.Equals("Delete"))
        {
            string id = e.CommandArgument.ToString();

        }
        if (e.CommandName.Equals("Edit"))
        {
            string id = e.CommandArgument.ToString();


        }

    }

    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {
        Dd_enter_product.SelectedItem.Text = GridView1.SelectedRow.Cells[0].Text;
        lbl_product_hsn.Value = GridView1.SelectedRow.Cells[1].Text;
        txt_height.Text = GridView1.SelectedRow.Cells[2].Text;
        txt_width.Text = GridView1.SelectedRow.Cells[3].Text;
        txt_sqrft.Text = GridView1.SelectedRow.Cells[4].Text;
        txt_rate.Text = GridView1.SelectedRow.Cells[5].Text;
        txt_amount.Text = GridView1.SelectedRow.Cells[6].Text;
        txt_quantity.Text = GridView1.SelectedRow.Cells[7].Text;
        txt_total_amt.Text = GridView1.SelectedRow.Cells[8].Text;

       
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
           
            SqlCommand cmd = new SqlCommand("update tbl_temp_without_gst_quotation_details set qw_product_name='" + Dd_enter_product.SelectedItem.Text + "',qw_hsn='" + lbl_product_hsn.Value + "',qw_height='" + txt_height2.Text + "',qw_width='" + txt_width2.Text + "',qw_size='" + txt_sqrft2.Text + "',qw_rate='" + txt_rate2.Text + "',qw_samount='" + txt_amount2.Text + "',qw_quantity='" + txt_quantity2.Text + "',qw_stotal='" + txt_total_amt2.Text + "'',qw_desc='" + Txt_description.Text + "',qw_unit='" + lbl_unit.Value + "' WHERE qw_id='" + lbl_id.Value.Trim() + "'", conn);

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
          

            SqlCommand cmd = new SqlCommand("update tbl_temp_without_gst_quotation_details set qw_product_name='" + Dd_enter_product.SelectedItem.Text + "',qw_hsn='" + lbl_product_hsn.Value + "',qw_height='" + txt_height2.Text + "',qw_width='" + txt_width2.Text + "',qw_size='" + txt_sqrft2.Text + "',qw_rate='" + txt_rate2.Text + "',qw_samount='" + txt_amount2.Text + "',qw_quantity='" + txt_quantity2.Text + "',qw_stotal='" + txt_total_amt2.Text + "',qw_desc='" + Txt_description.Text + "',qw_unit='" + lbl_unit.Value + "' WHERE qw_id='" + lbl_id.Value.Trim() + "'", conn);

            conn.Open();
            cmd.ExecuteNonQuery();

            conn.Close();
            FillGRid();
        }
        else
        {
            

            SqlCommand cmd = new SqlCommand("update tbl_temp_without_gst_quotation_details set qw_product_name='" + Dd_enter_product.SelectedItem.Text + "',qw_hsn='" + lbl_product_hsn.Value + "',qw_height='" + txt_height.Text + "',qw_width='" + txt_width.Text + "',qw_size='" + txt_sqrft.Text + "',qw_rate='" + txt_rate.Text + "',qw_samount='" + txt_amount.Text + "',qw_quantity='" + txt_quantity.Text + "',qw_stotal='" + txt_total_amt.Text + "',qw_desc='" + Txt_description.Text + "',qw_unit='" + lbl_unit.Value + "' WHERE qw_id='" + lbl_id.Value.Trim() + "'", conn);

            conn.Open();
            cmd.ExecuteNonQuery();

            conn.Close();
            FillGRid();
        }
    }

    protected void Button2_Click(object sender, EventArgs e)
    {
        int i = Convert.ToInt32(GridView1.SelectedRow.Cells[11].Text);

        SqlCommand cmd = new SqlCommand("Delete from tbl_temp_without_gst_quotation_details where qw_id='" + i + "'", conn);
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
}