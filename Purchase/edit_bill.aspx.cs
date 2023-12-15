using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using System.Windows.Forms;

public partial class admin_panel_Purchase_edit_bill : System.Web.UI.Page
{
    SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["String"].ConnectionString);
    decimal total_amount = 0, final_total = 0, quantity1, quantity2, StockQuantity;
    decimal totalvalue, totalcgst, totalsgst, totaligst, totalgst, totalqty, totaltaxable, Old_total, old_balance, paid, new_balance, new_total, rem,shipp,adjust,discount,totalofshipp, final;
    string invoice, Productname, Productname2;
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
                invoice = (Request.QueryString["invoice"]??"").ToString();
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
        string query = "select * from tbl_vendor";
        SqlDataAdapter adapt4 = new SqlDataAdapter(query, conn);
        DataTable dt5 = new DataTable();
        adapt4.Fill(dt5);
        if (dt5.Rows.Count > 0)
        {
            Dd_customer.DataSource = dt5;
            Dd_customer.DataBind();
            Dd_customer.DataTextField = "v_name";
            Dd_customer.DataValueField = "v_id";
            Dd_customer.DataBind();
            Dd_customer.Items.Insert(0, new ListItem("--Select--", "--Select--"));
            Dd_customer.SelectedItem.Selected = false;
            Dd_customer.Items.FindByText("--Select--").Selected = true;
        }

    }
    public void product()
    {
        string query = "select * from tbl_purchase_product order by p_name asc";
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
        SqlCommand cmd = new SqlCommand("select * from tbl_purchase_invoice where pc_invoice_no='" + invoice + "'", conn);
        SqlDataAdapter adapt = new SqlDataAdapter(cmd);
        DataTable dt = new DataTable();
        adapt.Fill(dt);
        if (dt.Rows.Count > 0)
        {
            id = Convert.ToInt32(dt.Rows[0]["pc_id"]);
            Dd_customer.SelectedValue = dt.Rows[0]["v_id"].ToString();
            Txt_invoice.Text = dt.Rows[0]["pc_invoice_no"].ToString();
            Txt_order_no.Text = dt.Rows[0]["pc_order_no"].ToString();
            lbl_date.Value = Convert.ToDateTime(dt.Rows[0]["pc_date"]).ToString("MM/dd/yyyy");
            Txt_invoice_date.Text = Convert.ToDateTime(dt.Rows[0]["pc_invoice_date"]).ToString("MM/dd/yyyy");
            Txt_due_date.Text = Convert.ToDateTime(dt.Rows[0]["pc_due_date"]).ToString("MM/dd/yyyy");
            //lbl_totalqty.Text = dt.Rows[0]["s_total_quantity"].ToString();
            lbl_subtotal.Text = dt.Rows[0]["pc_sub_total"].ToString();
            lbl_subtotal2.Value = dt.Rows[0]["pc_sub_total"].ToString();
            lbl_gst.Text = dt.Rows[0]["pc_total_gst"].ToString();
            Txt_shipping.Text = dt.Rows[0]["pc_shipping_charges"].ToString();
            Txt_adjustment.Text = dt.Rows[0]["pc_adjustable"].ToString();
            Txt_discount.Text = dt.Rows[0]["pc_discount"].ToString();
            lbl_total.Text = dt.Rows[0]["pc_total"].ToString();
            hide_total.Text = dt.Rows[0]["pc_total"].ToString();
            lbl_balance.Value = dt.Rows[0]["pc_balance"].ToString();

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
            SqlCommand cmd = new SqlCommand("delete from tbl_temp_purchase_invoice", conn);
            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();

            if (conn.State != ConnectionState.Closed)
            {
                conn.Close();
            }
            SqlCommand cmd2 = new SqlCommand("insert into tbl_temp_purchase_invoice select pc_invoice_no,pc_date,v_id,pc_order_no,pc_invoice_date,pc_due_date,pc_product_name,pc_quantity,pc_total_quantity,pc_rate,pc_discount,pc_cgstp,pc_cgsta,pc_sgstp,pc_sgsta,pc_igstp,pc_igsta,pc_amount,pc_sub_total,pc_total_gst,pc_shipping_charges,pc_adjustable,pc_total,pc_stotal,pc_product_hsn,pc_unit,pc_desc,pc_height,pc_width,pc_size,pc_samount,pc_total_cgst,pc_total_sgst,pc_total_igst,pc_total_taxable,pc_balance from tbl_purchase_invoice where pc_invoice_no='" + invoice + "'", conn);
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

            SqlCommand cmd = new SqlCommand("select s_product_name as Product,s_product_hsn as HSN,s_height as Height,s_width as Width,s_size as SQRFT,s_rate as Rate,s_samount as Amount,s_quantity as Qty,s_stotal as Total,s_cgsta as CGST,s_sgsta as SGST,s_igsta as IGST,s_amount as FINAL,s_cgstp as cgstp,s_sgstp as sgstp,s_igstp as igstp,s_desc as [desc],s_unit as unit,s_id as[ID] from tbl_temp_purchase_invoice where s_invoice_no='" + invoice + "'", conn);
            SqlDataAdapter adapt = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapt.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                GridView1.DataSource = dt;
                GridView1.DataBind();
                totalqty = Convert.ToDecimal(dt.Compute("Sum(Qty)", ""));
                totalvalue = Convert.ToDecimal(dt.Compute("Sum(FINAL)", ""));
                totalcgst = Convert.ToDecimal(dt.Compute("Sum(CGST)", ""));
                totalsgst = Convert.ToDecimal(dt.Compute("Sum(SGST)", ""));
                totaligst = Convert.ToDecimal(dt.Compute("Sum(IGST)", ""));
                totaltaxable = Convert.ToDecimal(dt.Compute("Sum(Total)", ""));
                
                totalgst = totalcgst + totalsgst + totaligst;

                //Assign the total value to footer label control
                lbl_subtotal.Text = totalvalue.ToString();
                lbl_subtotal2.Value = totalvalue.ToString();

                //Assign the total value to footer label control
                lbl_gst.Text = totalgst.ToString();
                lbl_totalqty.Text = totalqty.ToString();
                lbl_total_cgst.Value = totalcgst.ToString();
                lbl_total_sgst.Value = totalsgst.ToString();
                lbl_total_igst.Value = totaligst.ToString();
                lbl_total_taxable.Value = totaltaxable.ToString();
                shipp = Convert.ToDecimal(Txt_shipping.Text);
                adjust = Convert.ToDecimal(Txt_adjustment.Text);
                discount = Convert.ToDecimal(Txt_discount.Text);
                totalofshipp = shipp + totalvalue;
                final = totalofshipp - adjust - discount;
                lbl_total.Text=final.ToString();
                hide_total.Text= totalofshipp.ToString();

                GridView1.Visible = true;
                product();

                txt_height.Text = "0";
                txt_width.Text = "0";
                txt_sqrft.Text = "0";
                txt_rate.Text = "0";
                txt_rate2.Text = "0";
                txt_height2.Text = "0";
                txt_width2.Text = "0";
                txt_sqrft2.Text = "0";

                txt_amount.Text = "0";
                txt_amount2.Text = "0";
                txt_quantity.Text = "0";
                txt_quantity2.Text = "0";
                txt_total_amt.Text = "0";
                txt_total_amt2.Text = "0";

                txt_cgst.Text = "0";
                txt_igst.Text = "0";
                txt_sgst.Text = "0";
                txt_final_amt.Text = "0";


            }
            else
            {
                GridView1.DataSource = null;
                GridView1.DataBind();
                lbl_total.Text = "0";
                hide_total.Text = "0";
                lbl_subtotal.Text = "0";
                lbl_subtotal2.Value = "0";
                lbl_gst.Text = "0";

                lbl_totalqty.Text = "0";
                //Dd_enter_product.SelectedValue = "--Slect--";
                product();

                GridView1.Visible = false;
                // lbl_product_hsn.Value = "";
                Txt_description.Text = "";
                lbl_unit.Value = "";

                txt_height.Text = "0";
                txt_width.Text = "0";
                txt_sqrft.Text = "0";
                txt_rate.Text = "0";
                txt_rate2.Text = "0";
                txt_height2.Text = "0";
                txt_width2.Text = "0";
                txt_sqrft2.Text = "0";

                txt_amount.Text = "0";
                txt_amount2.Text = "0";
                txt_quantity.Text = "0";
                txt_quantity2.Text = "0";
                txt_total_amt.Text = "0";
                txt_total_amt2.Text = "0";

                txt_cgst.Text = "0";
                txt_igst.Text = "0";
                txt_sgst.Text = "0";
                txt_final_amt.Text = "0";

                Txt_shipping.Text = "0";





                lbl_subtotal.Text = "0";
                lbl_subtotal2.Value = "0";

                Txt_adjustment.Text = "0";
                Txt_discount.Text = "0";

                lbl_gst.Text = "0";

                lbl_total.Text = "0";

                //lbl_final.Text = "0";
                hide_total.Text = "0";
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
        GridView1.Visible = true;
        // GetData();
        string str = Dd_enter_product.SelectedItem.Text;

        string str2 = txt_quantity.Text.Trim();
        string str3 = txt_rate.Text.Trim();

        string str4 = txt_cgst.Text.Trim();
        string str8 = txt_total_amt.Text.Trim();
        string str5 = txt_sgst.Text.Trim();
        string str6 = txt_igst.Text.Trim();
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
        string cgst = txt_cgst.Text.Trim();
        string sgst = txt_sgst.Text.Trim();
        string igst = txt_igst.Text.Trim();

        string final = txt_final_amt.Text;
        string desc = Txt_description.Text;



        if (str9 == "Pcs")
        {

            decimal cgstamount = Convert.ToDecimal(total2) * Convert.ToDecimal(cgst) / 100;
            decimal sgstamount = Convert.ToDecimal(total2) * Convert.ToDecimal(sgst) / 100;
            decimal igstamount = Convert.ToDecimal(total2) * Convert.ToDecimal(igst) / 100;


            try
            {
                SqlCommand cmd = new SqlCommand("insert into tbl_temp_purchase_invoice values(@s_invoice_no,@s_date,@v_id,@s_order_no,@s_invoice_date,@s_due_date,@s_product_name,@s_quantity,@s_total_quantity,@s_rate,@s_discount,@s_cgstp,@s_cgsta,@s_sgstp,@s_sgsta,@s_igstp,@s_igsta,@s_amount,@s_sub_total,@s_total_gst,@s_shipping_charges,@s_adjustment,@s_total,@s_stotal,@s_hsn,@s_unit,@s_desc,@s_height,@s_width,@s_size,@s_samount,@s_total_cgst,@s_total_sgst,@s_total_igst,@s_total_taxable,@s_balance)", conn);

                cmd.Parameters.AddWithValue("@s_invoice_no", Convert.ToString(Txt_invoice.Text));
                cmd.Parameters.AddWithValue("@s_date", DateTime.Now.ToShortDateString());
                cmd.Parameters.AddWithValue("@v_id", Convert.ToString(Dd_customer.SelectedValue));
                cmd.Parameters.AddWithValue("@s_order_no", Convert.ToString(Txt_order_no.Text));
                cmd.Parameters.AddWithValue("@s_invoice_date", Convert.ToDateTime(Txt_invoice_date.Text).ToString());
                cmd.Parameters.AddWithValue("@s_due_date", Convert.ToDateTime(Txt_due_date.Text).ToString());
                cmd.Parameters.AddWithValue("@s_product_name", Convert.ToString(Dd_enter_product.SelectedItem.Text));
                cmd.Parameters.AddWithValue("@s_quantity", Convert.ToDecimal(txt_quantity2.Text));
                cmd.Parameters.AddWithValue("@s_unit", Convert.ToString(lbl_unit.Value));
                cmd.Parameters.AddWithValue("@s_total_quantity", Convert.ToDecimal(lbl_totalqty.Text));
                cmd.Parameters.AddWithValue("@s_rate", Convert.ToDecimal(txt_rate2.Text));
                cmd.Parameters.AddWithValue("@s_discount", Convert.ToDecimal(Txt_discount.Text));
                cmd.Parameters.AddWithValue("@s_cgstp", Convert.ToDecimal(txt_cgst.Text));
                cmd.Parameters.AddWithValue("@s_cgsta", Convert.ToDecimal(cgstamount));
                cmd.Parameters.AddWithValue("@s_sgstp", Convert.ToDecimal(txt_sgst.Text));
                cmd.Parameters.AddWithValue("@s_sgsta", Convert.ToDecimal(sgstamount));
                cmd.Parameters.AddWithValue("@s_igstp", Convert.ToDecimal(txt_igst.Text));
                cmd.Parameters.AddWithValue("@s_igsta", Convert.ToDecimal(igstamount));
                cmd.Parameters.AddWithValue("@s_amount", Convert.ToDecimal(txt_final_amt.Text));
                cmd.Parameters.AddWithValue("@s_sub_total", Convert.ToDecimal(lbl_subtotal.Text));
                cmd.Parameters.AddWithValue("@s_total_gst", Convert.ToDecimal(lbl_gst.Text));
                cmd.Parameters.AddWithValue("@s_shipping_charges", Convert.ToDecimal(Txt_shipping.Text));
                cmd.Parameters.AddWithValue("@s_adjustment", Convert.ToDecimal(Txt_adjustment.Text));
                cmd.Parameters.AddWithValue("@s_total", Convert.ToDecimal(hide_total.Text));
                cmd.Parameters.AddWithValue("@s_stotal", Convert.ToDecimal(txt_total_amt2.Text));
                cmd.Parameters.AddWithValue("@s_hsn", Convert.ToString(lbl_product_hsn.Value));
                cmd.Parameters.AddWithValue("@s_desc", Convert.ToString(Txt_description.Text));
                cmd.Parameters.AddWithValue("@s_height", "");
                cmd.Parameters.AddWithValue("@s_width", "");
                cmd.Parameters.AddWithValue("@s_size", "");
                cmd.Parameters.AddWithValue("@s_samount", "");
                cmd.Parameters.AddWithValue("@s_total_cgst", Convert.ToDecimal(lbl_total_cgst.Value));
                cmd.Parameters.AddWithValue("@s_total_sgst", Convert.ToDecimal(lbl_total_sgst.Value));
                cmd.Parameters.AddWithValue("@s_total_igst", Convert.ToDecimal(lbl_total_igst.Value));
                cmd.Parameters.AddWithValue("@s_total_taxable", Convert.ToDecimal(lbl_total_taxable.Value));
                cmd.Parameters.AddWithValue("@s_balance", Convert.ToDecimal(lbl_balance.Value));
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

            decimal cgstamount = Convert.ToDecimal(total) * Convert.ToDecimal(cgst) / 100;
            decimal sgstamount = Convert.ToDecimal(total) * Convert.ToDecimal(sgst) / 100;
            decimal igstamount = Convert.ToDecimal(total) * Convert.ToDecimal(igst) / 100;


            try
            {
                SqlCommand cmd = new SqlCommand("insert into tbl_temp_purchase_invoice values(@s_invoice_no,@s_date,@v_id,@s_order_no,@s_invoice_date,@s_due_date,@s_product_name,@s_quantity,@s_total_quantity,@s_rate,@s_discount,@s_cgstp,@s_cgsta,@s_sgstp,@s_sgsta,@s_igstp,@s_igsta,@s_amount,@s_sub_total,@s_total_gst,@s_shipping_charges,@s_adjustment,@s_total,@s_stotal,@s_hsn,@s_unit,@s_desc,@s_height,@s_width,@s_size,@s_samount,@s_total_cgst,@s_total_sgst,@s_total_igst,@s_total_taxable,@s_balance)", conn);

                cmd.Parameters.AddWithValue("@s_invoice_no", Convert.ToString(Txt_invoice.Text));
                cmd.Parameters.AddWithValue("@s_date", DateTime.Now.ToShortDateString());
                cmd.Parameters.AddWithValue("@v_id", Convert.ToString(Dd_customer.SelectedValue));
                cmd.Parameters.AddWithValue("@s_order_no", Convert.ToString(Txt_order_no.Text));
                cmd.Parameters.AddWithValue("@s_invoice_date", Convert.ToDateTime(Txt_invoice_date.Text).ToString());
                cmd.Parameters.AddWithValue("@s_due_date", Convert.ToDateTime(Txt_due_date.Text).ToString());
                cmd.Parameters.AddWithValue("@s_product_name", Convert.ToString(Dd_enter_product.SelectedItem.Text));
                cmd.Parameters.AddWithValue("@s_quantity", Convert.ToDecimal(txt_quantity.Text));
                cmd.Parameters.AddWithValue("@s_unit", Convert.ToString(lbl_unit.Value));
                cmd.Parameters.AddWithValue("@s_total_quantity", Convert.ToDecimal(lbl_totalqty.Text));
                cmd.Parameters.AddWithValue("@s_rate", Convert.ToDecimal(txt_rate.Text));
                cmd.Parameters.AddWithValue("@s_discount", Convert.ToDecimal(Txt_discount.Text));
                cmd.Parameters.AddWithValue("@s_cgstp", Convert.ToDecimal(txt_cgst.Text));
                cmd.Parameters.AddWithValue("@s_cgsta", Convert.ToDecimal(cgstamount));
                cmd.Parameters.AddWithValue("@s_sgstp", Convert.ToDecimal(txt_sgst.Text));
                cmd.Parameters.AddWithValue("@s_sgsta", Convert.ToDecimal(sgstamount));
                cmd.Parameters.AddWithValue("@s_igstp", Convert.ToDecimal(txt_igst.Text));
                cmd.Parameters.AddWithValue("@s_igsta", Convert.ToDecimal(igstamount));
                cmd.Parameters.AddWithValue("@s_amount", Convert.ToDecimal(txt_final_amt.Text));
                cmd.Parameters.AddWithValue("@s_sub_total", Convert.ToDecimal(lbl_subtotal.Text));
                cmd.Parameters.AddWithValue("@s_total_gst", Convert.ToDecimal(lbl_gst.Text));
                cmd.Parameters.AddWithValue("@s_shipping_charges", Convert.ToDecimal(Txt_shipping.Text));
                cmd.Parameters.AddWithValue("@s_adjustment", Convert.ToDecimal(Txt_adjustment.Text));
                cmd.Parameters.AddWithValue("@s_total", Convert.ToDecimal(hide_total.Text));
                cmd.Parameters.AddWithValue("@s_stotal", Convert.ToDecimal(txt_total_amt.Text));
                cmd.Parameters.AddWithValue("@s_hsn", Convert.ToString(lbl_product_hsn.Value));
                cmd.Parameters.AddWithValue("@s_desc", Convert.ToString(Txt_description.Text));

                cmd.Parameters.AddWithValue("@s_height", "");
                cmd.Parameters.AddWithValue("@s_width", "");
                cmd.Parameters.AddWithValue("@s_size", "");
                cmd.Parameters.AddWithValue("@s_samount", "");

                //cmd.Parameters.AddWithValue("@s_height", Convert.ToDecimal(txt_height.Text));
                //cmd.Parameters.AddWithValue("@s_width", Convert.ToDecimal(txt_width.Text));
                //cmd.Parameters.AddWithValue("@s_size", Convert.ToDecimal(txt_sqrft.Text));
                //cmd.Parameters.AddWithValue("@s_samount", Convert.ToDecimal(txt_amount.Text));
                cmd.Parameters.AddWithValue("@s_total_cgst", Convert.ToDecimal(lbl_total_cgst.Value));
                cmd.Parameters.AddWithValue("@s_total_sgst", Convert.ToDecimal(lbl_total_sgst.Value));
                cmd.Parameters.AddWithValue("@s_total_igst", Convert.ToDecimal(lbl_total_igst.Value));
                cmd.Parameters.AddWithValue("@s_total_taxable", Convert.ToDecimal(lbl_total_taxable.Value));
                cmd.Parameters.AddWithValue("@s_balance", Convert.ToDecimal(lbl_balance.Value));
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
            e.Row.Cells[13].Visible = false;
            e.Row.Cells[14].Visible = false;
            e.Row.Cells[15].Visible = false;
            e.Row.Cells[16].Visible = false;
            e.Row.Cells[17].Visible = false;
            e.Row.Cells[18].Visible = false;
        }
        
    }

    protected void Dd_enter_product_SelectedIndexChanged(object sender, EventArgs e)
    {
        string pro_name = Dd_enter_product.SelectedItem.Text;
        string rate, cgst, igst, sgst, hsn, unit, desc;
        SqlCommand cmd = new SqlCommand("select * from tbl_purchase_product where p_name ='" + pro_name.ToString() + "'", conn);
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
            //if (unit == "Pcs")
            //{
            //    Panel1.Visible = false;
            //    Panel2.Visible = true;
            //    txt_rate2.Text = rate;
            //}
            //else
            //{
            //    Panel1.Visible = true;
            //    Panel2.Visible = false;
            //    txt_rate.Text = rate;
            //}
            if (unit == "Pcs")
            {
                Panel1.Visible = false;
                Panel2.Visible = true;
                txt_rate2.Text = rate;
                txt_quantity2.Text = "0";
                txt_sqrft2.Text = "0";
            }

            else if (unit == "Running Feet")
            {
                Panel1.Visible = false;
                Panel2.Visible = true;
                txt_rate2.Text = rate;
                txt_quantity2.Text = "0";
                txt_sqrft2.Text = "0";
            }
            else if (unit == "Packet")
            {
                Panel1.Visible = false;
                Panel2.Visible = true;
                txt_rate2.Text = rate;
                txt_quantity2.Text = "0";
                txt_sqrft2.Text = "0";
            }
            else if (unit == "Copy")
            {
                Panel1.Visible = false;
                Panel2.Visible = true;
                txt_rate2.Text = rate;
                txt_quantity2.Text = "0";
                txt_sqrft2.Text = "0";
            }
            else if (unit == "Ltr")
            {
                Panel1.Visible = false;
                Panel2.Visible = true;
                txt_rate2.Text = rate;
                txt_quantity2.Text = "0";
                txt_sqrft2.Text = "0";
            }
            else
            {
                Panel1.Visible = true;
                Panel2.Visible = false;
                txt_rate.Text = rate;
                txt_quantity.Text = "0";

            }
            txt_cgst.Text = cgst;
            txt_sgst.Text = sgst;
            txt_igst.Text = igst;
            txt_rate.Text = rate;
            Txt_description.Text = desc;

            lbl_product_hsn.Value = hsn;
            lbl_unit.Value = unit;
            txt_final_amt.Text = "0";
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
                //SqlCommand cmd4 = new SqlCommand("select * from tbl_purchase_invoice where pc_invoice_no='" + invoice + "'", conn);
                //SqlDataAdapter adapt4 = new SqlDataAdapter(cmd4);
                //DataTable dt4 = new DataTable();
                //adapt4.Fill(dt4);
                //if (dt4.Rows.Count > 0)
                //{
                //    Old_total = Convert.ToDecimal(dt4.Rows[0]["pc_total"]);
                //    old_balance = Convert.ToDecimal(dt4.Rows[0]["pc_balance"]);
                //    paid = Old_total - old_balance;
                //    new_total = Convert.ToDecimal(hide_total.Text);
                //    new_balance = new_total - paid;
                //    rem = new_total - Old_total;
                //}


                SqlCommand cmd55 = new SqlCommand("select * FROM tbl_purchase_invoice Where pc_invoice_no='" + invoice + "'", conn);
                SqlDataAdapter adapt55 = new SqlDataAdapter(cmd55);
                DataTable dt55 = new DataTable();
                adapt55.Fill(dt55);
                int dtRowCount = dt55.Rows.Count;
                int gridRowCount = GridView1.Rows.Count;
                if (dt55.Rows.Count > 0)
                {


                    for (int dtRow = 0; dtRow < dt55.Rows.Count; dtRow++)
                    {
                        string s_quantity = dt55.Rows[dtRow]["pc_quantity"].ToString();
                        quantity1 = Convert.ToDecimal(s_quantity);
                        Productname = dt55.Rows[dtRow]["pc_product_name"].ToString();
                      
                        int rowscount1 = GridView1.Rows.Count;


                        if (dtRow < rowscount1)
                        {
                            Productname2 = Convert.ToString(GridView1.Rows[dtRow].Cells[0].Text);
                            
                            quantity2 = Convert.ToDecimal(GridView1.Rows[dtRow].Cells[7].Text);

                            if ( Productname == Productname2)
                            {
                                if (quantity1 != quantity2)
                                {
                                    if (quantity1 > quantity2)
                                    {
                                        StockQuantity = quantity1 - quantity2;
                                        SqlCommand cmd33 = new SqlCommand("UPDATE tbl_purchase_product SET p_stock=p_stock-('" + StockQuantity + "') WHERE p_name='" + Convert.ToString(GridView1.Rows[dtRow].Cells[0].Text) + "'", conn);

                                        conn.Open();
                                        cmd33.ExecuteNonQuery();
                                        conn.Close();

                                       


                                    }

                                    else if (quantity1 < quantity2)
                                    {
                                        StockQuantity = quantity2 - quantity1;

                                        SqlCommand cmd33 = new SqlCommand("UPDATE tbl_purchase_product SET p_stock=p_stock+('" + StockQuantity + "') WHERE p_name='" + Convert.ToString(GridView1.Rows[dtRow].Cells[0].Text) + "'", conn);

                                        conn.Open();
                                        cmd33.ExecuteNonQuery();
                                        conn.Close();

                                      

                                    }



                                }


                            }

                            if (Productname != Productname2)
                            {
                                SqlCommand cmd33 = new SqlCommand("UPDATE tbl_purchase_product SET p_stock=p_stock-('" + quantity1 + "') WHERE p_name='" + Productname + "'", conn);

                                conn.Open();
                                cmd33.ExecuteNonQuery();
                                conn.Close();


                                SqlCommand cmd34 = new SqlCommand("UPDATE tbl_purchase_product SET p_stock=p_stock+('" + quantity2 + "') WHERE p_name='" + Convert.ToString(GridView1.Rows[dtRow].Cells[0].Text) + "'", conn);

                                conn.Open();
                                cmd34.ExecuteNonQuery();
                                conn.Close();


                            }



                           
                        }





                    }





                }

                final_total = Math.Round(Convert.ToDecimal(hide_total.Text));
                new_balance = final_total - Convert.ToDecimal(Txt_adjustment.Text) - Convert.ToDecimal(Txt_discount.Text);

                SqlCommand cmd5 = new SqlCommand("DELETE FROM tbl_purchase_invoice Where pc_invoice_no='" + invoice + "'", conn);
                conn.Open();
                cmd5.ExecuteNonQuery();
                conn.Close();
           
                int rowscount = GridView1.Rows.Count;
                for (int i = 0; i < rowscount; i++)
                {


                    SqlCommand cmd = new SqlCommand("insert into tbl_purchase_invoice values(@pc_invoice_no,@pc_date,@v_id,@pc_order_no,@pc_invoice_date,@pc_due_date,@pc_product_name,@pc_quantity,@pc_total_quantity,@pc_rate,@pc_discount,@pc_cgstp,@pc_cgsta,@pc_sgstp,@pc_sgsta,@pc_igstp,@pc_igsta,@pc_amount,@pc_sub_total,@pc_total_gst,@pc_shipping_charges,@pc_adjustment,@pc_total,@pc_stotal,@pc_hsn,@pc_unit,@pc_desc,@pc_height,@pc_width,@pc_size,@pc_samount,@pc_total_cgst,@pc_total_sgst,@pc_total_igst,@pc_total_taxable,@pc_balance)", conn);
                    cmd.Parameters.AddWithValue("@pc_invoice_no", Convert.ToString(Txt_invoice.Text));
                    cmd.Parameters.AddWithValue("@pc_date", DateTime.Now.ToShortDateString());
                    cmd.Parameters.AddWithValue("@v_id", Convert.ToString(Dd_customer.SelectedValue));
                    cmd.Parameters.AddWithValue("@pc_order_no", Convert.ToString(Txt_order_no.Text));
                    cmd.Parameters.AddWithValue("@pc_invoice_date", Txt_invoice_date.Text);
                    cmd.Parameters.AddWithValue("@pc_due_date", Txt_due_date.Text);
                    cmd.Parameters.AddWithValue("@pc_product_name", Convert.ToString(GridView1.Rows[i].Cells[0].Text));
                    cmd.Parameters.AddWithValue("@pc_quantity", Convert.ToDecimal(GridView1.Rows[i].Cells[7].Text));
                    cmd.Parameters.AddWithValue("@pc_unit", Convert.ToString(GridView1.Rows[i].Cells[17].Text));
                    cmd.Parameters.AddWithValue("@pc_total_quantity", Convert.ToDecimal(lbl_totalqty.Text));
                    cmd.Parameters.AddWithValue("@pc_rate", Convert.ToDecimal(GridView1.Rows[i].Cells[5].Text));
                    cmd.Parameters.AddWithValue("@pc_discount", Convert.ToDecimal(Txt_discount.Text));
                    cmd.Parameters.AddWithValue("@pc_cgstp", Convert.ToDecimal(GridView1.Rows[i].Cells[13].Text));
                    cmd.Parameters.AddWithValue("@pc_cgsta", Convert.ToDecimal(GridView1.Rows[i].Cells[9].Text));
                    cmd.Parameters.AddWithValue("@pc_sgstp", Convert.ToDecimal(GridView1.Rows[i].Cells[14].Text));
                    cmd.Parameters.AddWithValue("@pc_sgsta", Convert.ToDecimal(GridView1.Rows[i].Cells[10].Text));
                    cmd.Parameters.AddWithValue("@pc_igstp", Convert.ToDecimal(GridView1.Rows[i].Cells[15].Text));
                    cmd.Parameters.AddWithValue("@pc_igsta", Convert.ToDecimal(GridView1.Rows[i].Cells[11].Text));
                    cmd.Parameters.AddWithValue("@pc_amount", Convert.ToDecimal(GridView1.Rows[i].Cells[12].Text));
                    cmd.Parameters.AddWithValue("@pc_sub_total", Convert.ToDecimal(lbl_subtotal.Text));
                    cmd.Parameters.AddWithValue("@pc_total_gst", Convert.ToDecimal(lbl_gst.Text));
                    cmd.Parameters.AddWithValue("@pc_shipping_charges", Convert.ToDecimal(Txt_shipping.Text));
                    cmd.Parameters.AddWithValue("@pc_adjustment", Convert.ToDecimal(Txt_adjustment.Text));
                    cmd.Parameters.AddWithValue("@pc_total", Convert.ToDecimal(hide_total.Text));
                    cmd.Parameters.AddWithValue("@pc_stotal", Convert.ToDecimal(GridView1.Rows[i].Cells[8].Text));
                    if (GridView1.Rows[i].Cells[1].Text.Trim() == "&amp;nbsp;")
                    {
                        cmd.Parameters.AddWithValue("@pc_hsn", "");
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@pc_hsn", Convert.ToString(GridView1.Rows[i].Cells[1].Text.Trim()));
                    }
                    if (GridView1.Rows[i].Cells[16].Text.Trim() == "&amp;nbsp;")
                    {
                        cmd.Parameters.AddWithValue("@pc_desc", "");
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@pc_desc", Convert.ToString(GridView1.Rows[i].Cells[16].Text.Trim()));
                    }
                    cmd.Parameters.AddWithValue("@pc_height", Convert.ToDecimal(GridView1.Rows[i].Cells[2].Text));
                    cmd.Parameters.AddWithValue("@pc_width", Convert.ToDecimal(GridView1.Rows[i].Cells[3].Text));
                    cmd.Parameters.AddWithValue("@pc_size", Convert.ToDecimal(GridView1.Rows[i].Cells[4].Text));
                    cmd.Parameters.AddWithValue("@pc_samount", Convert.ToDecimal(GridView1.Rows[i].Cells[6].Text));
                    cmd.Parameters.AddWithValue("@pc_total_cgst", Convert.ToDecimal(lbl_total_cgst.Value));
                    cmd.Parameters.AddWithValue("@pc_total_sgst", Convert.ToDecimal(lbl_total_sgst.Value));
                    cmd.Parameters.AddWithValue("@pc_total_igst", Convert.ToDecimal(lbl_total_igst.Value));
                    cmd.Parameters.AddWithValue("@pc_total_taxable", Convert.ToDecimal(lbl_total_taxable.Value));
                    cmd.Parameters.AddWithValue("@pc_balance", new_balance);
                    conn.Open();
                    cmd.ExecuteNonQuery();

                    conn.Close();
                }
                SqlCommand cmd2 = new SqlCommand("update tbl_purchase SET pu_invoice_no='" + Convert.ToString(Txt_invoice.Text) + "',pu_date='" + Convert.ToDateTime(lbl_date.Value).ToString("MM/dd/yyyy") + "',v_id='" + Dd_customer.SelectedValue + "',pu_order_no='" + Convert.ToString(Txt_order_no.Text) + "',pu_invoice_date='" + Txt_invoice_date.Text + "',pu_due_date='" + Txt_due_date.Text + "',pu_total_quantity='" + Convert.ToDecimal(lbl_totalqty.Text) + "',pu_discount='" + Convert.ToDecimal(Txt_discount.Text) + "',pu_sub_total='" + Convert.ToDecimal(lbl_subtotal.Text) + "',pu_total_gst='" + Convert.ToDecimal(lbl_gst.Text) + "',pu_shipping_charges='" + Convert.ToDecimal(Txt_shipping.Text) + "',pu_adjustment='" + Convert.ToDecimal(Txt_adjustment.Text) + "',pu_total='" + Convert.ToDecimal(hide_total.Text) + "',pu_total_cgst='" + Convert.ToDecimal(lbl_total_cgst.Value) + "',pu_total_sgst='" + Convert.ToDecimal(lbl_total_sgst.Value) + "',pu_total_igst='" + Convert.ToDecimal(lbl_total_igst.Value) + "',pu_total_taxable='" + Convert.ToDecimal(lbl_total_taxable.Value) + "',pu_balance='" + new_balance + "' where pu_invoice_no='" + Txt_invoice.Text + "' ", conn);
                
                conn.Open();
                cmd2.ExecuteNonQuery();
                conn.Close();

                Lbl_message.Text = "" + Dd_customer.Text + " Added Successfully!!!";

                
                SqlCommand cmd3 = new SqlCommand("update tbl_vendor set v_opening_balance=v_opening_balance + '"+rem+"' where v_id='" + Dd_customer.SelectedValue + "'", conn);
                
                conn.Open();
                cmd3.ExecuteNonQuery();

                conn.Close();

                Response.Redirect("bill.aspx?invoice=" + Txt_invoice.Text + "&bill_update=success",false);
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
        //txt_rate.Text = GridView1.SelectedRow.Cells[5].Text;
        txt_amount.Text = GridView1.SelectedRow.Cells[6].Text;
        //txt_quantity.Text = GridView1.SelectedRow.Cells[7].Text;
        //txt_total_amt.Text = GridView1.SelectedRow.Cells[8].Text;

        txt_final_amt.Text = GridView1.SelectedRow.Cells[12].Text;
        txt_cgst.Text = GridView1.SelectedRow.Cells[13].Text;
        txt_sgst.Text = GridView1.SelectedRow.Cells[14].Text;
        txt_igst.Text = GridView1.SelectedRow.Cells[15].Text;
        Txt_description.Text = GridView1.SelectedRow.Cells[16].Text;
        lbl_unit.Value = GridView1.SelectedRow.Cells[17].Text;
        lbl_id.Value = GridView1.SelectedRow.Cells[18].Text;
        if (lbl_unit.Value == "Pcs")
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
            decimal cgstamount = Convert.ToDecimal(txt_total_amt2.Text) * Convert.ToDecimal(txt_cgst.Text) / 100;
            decimal sgstamount = Convert.ToDecimal(txt_total_amt2.Text) * Convert.ToDecimal(txt_sgst.Text) / 100;
            decimal igstamount = Convert.ToDecimal(txt_total_amt2.Text) * Convert.ToDecimal(txt_igst.Text) / 100;

            SqlCommand cmd = new SqlCommand("update tbl_temp_purchase_invoice set s_product_name='" + Dd_enter_product.SelectedItem.Text + "',s_product_hsn='" + lbl_product_hsn.Value + "',s_height='" + txt_height2.Text + "',s_width='" + txt_width2.Text + "',s_size='" + txt_sqrft2.Text + "',s_rate='" + txt_rate2.Text + "',s_samount='" + txt_amount2.Text + "',s_quantity='" + txt_quantity2.Text + "',s_stotal='" + txt_total_amt2.Text + "',s_cgsta='" + cgstamount + "',s_sgsta='" + sgstamount + "',s_igsta='" + igstamount + "',s_amount='" + txt_final_amt.Text + "',s_cgstp='" + txt_cgst.Text + "',s_sgstp='" + txt_sgst.Text + "',s_igstp='" + txt_igst.Text + "',s_desc='" + Txt_description.Text + "',s_unit='" + lbl_unit.Value + "' WHERE s_id='" + lbl_id.Value.Trim() + "'", conn);

            conn.Open();
            cmd.ExecuteNonQuery();

            conn.Close();
            FillGRid();
        }
        else
        {
            decimal cgstamount = Convert.ToDecimal(txt_total_amt.Text) * Convert.ToDecimal(txt_cgst.Text) / 100;
            decimal sgstamount = Convert.ToDecimal(txt_total_amt.Text) * Convert.ToDecimal(txt_sgst.Text) / 100;
            decimal igstamount = Convert.ToDecimal(txt_total_amt.Text) * Convert.ToDecimal(txt_igst.Text) / 100;

            SqlCommand cmd = new SqlCommand("update tbl_temp_purchase_invoice set s_product_name='" + Dd_enter_product.SelectedItem.Text + "',s_product_hsn='" + lbl_product_hsn.Value + "',s_height='" + txt_height.Text + "',s_width='" + txt_width.Text + "',s_size='" + txt_sqrft.Text + "',s_rate='" + txt_rate.Text + "',s_samount='" + txt_amount.Text + "',s_quantity='" + txt_quantity.Text + "',s_stotal='" + txt_total_amt.Text + "',s_cgsta='" + cgstamount + "',s_sgsta='" + sgstamount + "',s_igsta='" + igstamount + "',s_amount='" + txt_final_amt.Text + "',s_cgstp='" + txt_cgst.Text + "',s_sgstp='" + txt_sgst.Text + "',s_igstp='" + txt_igst.Text + "',s_desc='" + Txt_description.Text + "',s_unit='" + lbl_unit.Value + "' WHERE s_id='" + lbl_id.Value.Trim() + "'", conn);

            conn.Open();
            cmd.ExecuteNonQuery();

            conn.Close();
            FillGRid();
        }
    }

    protected void Button2_Click(object sender, EventArgs e)
    {
        int i = Convert.ToInt32(GridView1.SelectedRow.Cells[18].Text);

        SqlCommand cmd = new SqlCommand("Delete from tbl_temp_purchase_invoice where s_id='" + i + "'", conn);
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

        txt_final_amt.Text = "";
        txt_cgst.Text = "";
        txt_sgst.Text = "";
        txt_igst.Text = "";
        Txt_description.Text = "";
        lbl_unit.Value = "";
        lbl_id.Value = "";
    }
}