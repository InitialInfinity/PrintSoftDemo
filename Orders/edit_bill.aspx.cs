using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;


public partial class Orders_edit_bill : System.Web.UI.Page
{

    SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["String"].ConnectionString);
    SqlCommand cmd2, cmd3, cmd4, cmd5, cmd7, cmd8;
    SqlDataAdapter adapt2, adapt3, adapt4, adapt5, adapt7, adapt8;
    DataTable dt, dt1, dt2, dt3, dt4, dt5, dt7, dt8;
    decimal total_amount = 0, final_total = 0;
    decimal dPageTotal, finaltotal;
    decimal totalvalue, totalcgst, totalsgst, totaligst, totalgst, totalqty, totaltaxable, Old_total, old_balance, paid, new_balance, new_total, rem;
    string invoice;
    int id;
    string admin_email;

    protected void Page_Load(object sender, EventArgs e)
    {


        if (Session["a_email"] != null || Session["admin_email"] != null)
        {

            cmd4 = new SqlCommand("select * from tbl_admin_login", conn);
            adapt4 = new SqlDataAdapter(cmd4);
            DataTable dt4 = new DataTable();
            adapt4.Fill(dt4);
            if (dt4.Rows.Count > 0)
            {
                admin_email = dt4.Rows[0]["a_email"].ToString();
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
                    Designer();
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
    public void Designer()
    {
        string query = "select * from tbl_staff Order By st_staff_name asc";
        SqlDataAdapter adapt4 = new SqlDataAdapter(query, conn);
        DataTable dt5 = new DataTable();
        adapt4.Fill(dt5);
        if (dt5.Rows.Count > 0)
        {
            Dd_staff.DataSource = dt5;
            Dd_staff.DataBind();
            Dd_staff.DataTextField = "st_staff_name";
            Dd_staff.DataValueField = "st_id";
            Dd_staff.DataBind();
            Dd_staff.Items.Insert(0, new ListItem("--Select--", "--Select--"));
            Dd_staff.SelectedItem.Selected = false;
            Dd_staff.Items.FindByText("--Select--").Selected = true;
        }
    }

    protected void GetData()
    {


        cmd7 = new SqlCommand("select * from tbl_order_invoice where s_invoice_no='" + invoice + "'", conn);
        adapt7 = new SqlDataAdapter(cmd7);
        dt7 = new DataTable();
        adapt7.Fill(dt7);
        if (dt7.Rows.Count > 0)
        {
            id = Convert.ToInt32(dt7.Rows[0]["s_id"]);
            Dd_customer.SelectedItem.Text = dt7.Rows[0]["s_customer_name"].ToString();
            lbl_cutomer_contact.Value = dt7.Rows[0]["s_customer_contact"].ToString();
            lbl_cutomer_address.Value = dt7.Rows[0]["s_customer_address"].ToString();
            lbl_cutomer_gst_no.Value = dt7.Rows[0]["s_customer_gst_no"].ToString();
            lbl_cutomer_email.Value = dt7.Rows[0]["s_customer_email"].ToString();
            Txt_invoice.Text = dt7.Rows[0]["s_invoice_no"].ToString();
            Dd_staff.SelectedItem.Text = dt7.Rows[0]["s_designer"].ToString();
            lbl_date.Value = Convert.ToDateTime(dt7.Rows[0]["s_date"]).ToString("MM/dd/yyyy");
            Txt_invoice_date.Text = Convert.ToDateTime(dt7.Rows[0]["s_invoice_date"]).ToString("MM/dd/yyyy");
            Txt_due_date.Text = Convert.ToDateTime(dt7.Rows[0]["s_due_date"]).ToString("MM/dd/yyyy");
            //lbl_totalqty.Text = dt7.Rows[0]["s_total_quantity"].ToString();
            lbl_subtotal.Text = dt7.Rows[0]["s_sub_total"].ToString();
            lbl_subtotal2.Value = dt7.Rows[0]["s_sub_total"].ToString();
            lbl_gst.Text = dt7.Rows[0]["s_total_gst"].ToString();
            //Txt_shipping.Text = dt7.Rows[0]["s_shipping_charges"].ToString();
            Txt_advance.Text = dt7.Rows[0]["s_adjustment"].ToString();
            Txt_discount.Text = dt7.Rows[0]["s_discount"].ToString();
            lbl_total.Text = dt7.Rows[0]["s_total"].ToString();
            hide_total.Text = dt7.Rows[0]["s_total"].ToString();
            lbl_balance.Value = dt7.Rows[0]["s_balance"].ToString();

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
            SqlCommand cmd998 = new SqlCommand("delete from tbl_temp_order_invoice", conn);
            conn.Open();
            cmd998.ExecuteNonQuery();
            conn.Close();

            if (conn.State != ConnectionState.Closed)
            {
                conn.Close();
            }
            SqlCommand cmd99 = new SqlCommand("insert into tbl_temp_order_invoice select s_invoice_no,s_date,s_customer_name,s_customer_contact,s_customer_address,s_customer_gst_no,s_customer_email,s_designer,s_invoice_date,s_due_date,s_product_name,s_quantity,s_total_quantity,s_rate,s_discount,s_cgstp,s_cgsta,s_sgstp,s_sgsta,s_igstp,s_igsta,s_amount,s_sub_total,s_total_gst,s_shipping_charges,s_adjustment,s_total,s_stotal,s_product_hsn,s_unit,s_desc,s_height,s_width,s_size,s_samount,s_status,s_total_cgst,s_total_sgst,s_total_igst,s_total_taxable,s_balance from tbl_order_invoice where s_invoice_no='" + invoice + "'", conn);
            conn.Open();
            cmd99.ExecuteNonQuery();
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


            SqlCommand cmd88 = new SqlCommand("select s_product_name as Product,s_product_hsn as HSN,s_height as Height,s_width as Width,s_size as SQRFT,s_rate as Rate,s_samount as Amount,s_quantity as Qty,s_stotal as Total,s_cgsta as CGST,s_sgsta as SGST,s_igsta as IGST,s_amount as FINAL,s_cgstp as cgstp,s_sgstp as sgstp,s_igstp as igstp,s_desc as [desc],s_unit as unit,s_id as[ID],s_status as [Status] from tbl_temp_order_invoice where s_invoice_no='" + invoice + "'", conn);
            SqlDataAdapter adapt25 = new SqlDataAdapter(cmd88);
            DataTable dt22 = new DataTable();
            adapt25.Fill(dt22);
            if (dt22.Rows.Count > 0)
            {
                GridView1.DataSource = dt22;
                GridView1.DataBind();
                totalqty = Convert.ToDecimal(dt22.Compute("Sum(Qty)", ""));
                totalvalue = Convert.ToDecimal(dt22.Compute("Sum(FINAL)", ""));
                totalcgst = Convert.ToDecimal(dt22.Compute("Sum(CGST)", ""));
                totalsgst = Convert.ToDecimal(dt22.Compute("Sum(SGST)", ""));
                totaligst = Convert.ToDecimal(dt22.Compute("Sum(IGST)", ""));
                totaltaxable = Convert.ToDecimal(dt22.Compute("Sum(Total)", ""));





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




        //new data end

        if (str9 == "Pcs")
        {

            decimal cgstamount = Convert.ToDecimal(total2) * Convert.ToDecimal(cgst) / 100;
            decimal sgstamount = Convert.ToDecimal(total2) * Convert.ToDecimal(sgst) / 100;
            decimal igstamount = Convert.ToDecimal(total2) * Convert.ToDecimal(igst) / 100;


            try
            {
                SqlCommand cmd = new SqlCommand("insert into tbl_temp_order_invoice values(@s_invoice_no,@s_date,@s_customer_name,@s_customer_contact,@s_customer_address,@s_customer_gst_no,@s_customer_email,@s_designer,@s_invoice_date,@s_due_date,@s_product_name,@s_quantity,@s_total_quantity,@s_rate,@s_discount,@s_cgstp,@s_cgsta,@s_sgstp,@s_sgsta,@s_igstp,@s_igsta,@s_amount,@s_sub_total,@s_total_gst,@s_shipping_charges,@s_adjustment,@s_total,@s_stotal,@s_hsn,@s_unit,@s_desc,@s_height,@s_width,@s_size,@s_samount,@s_status,@s_total_cgst,@s_total_sgst,@s_total_igst,@s_total_taxable,@s_balance)", conn);

                cmd.Parameters.AddWithValue("@s_invoice_no", Convert.ToString(Txt_invoice.Text));
                cmd.Parameters.AddWithValue("@s_date", DateTime.Now.ToShortDateString());
                cmd.Parameters.AddWithValue("@s_customer_name", Convert.ToString(Dd_customer.SelectedItem.Text));
                cmd.Parameters.AddWithValue("@s_customer_contact", Convert.ToString(lbl_cutomer_contact.Value));
                cmd.Parameters.AddWithValue("@s_customer_address", Convert.ToString(lbl_cutomer_address.Value));
                cmd.Parameters.AddWithValue("@s_customer_gst_no", Convert.ToString(lbl_cutomer_gst_no.Value));
                cmd.Parameters.AddWithValue("@s_customer_email", Convert.ToString(lbl_cutomer_email.Value));
                cmd.Parameters.AddWithValue("@s_designer", Convert.ToString(Dd_staff.SelectedItem.Text));
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
                cmd.Parameters.AddWithValue("@s_shipping_charges", "");
                cmd.Parameters.AddWithValue("@s_adjustment", Convert.ToDecimal(Txt_advance.Text));
                cmd.Parameters.AddWithValue("@s_total", Convert.ToDecimal(hide_total.Text));
                cmd.Parameters.AddWithValue("@s_stotal", Convert.ToDecimal(txt_total_amt2.Text));
                cmd.Parameters.AddWithValue("@s_hsn", Convert.ToString(lbl_product_hsn.Value));
                cmd.Parameters.AddWithValue("@s_desc", Convert.ToString(Txt_description.Text));
                cmd.Parameters.AddWithValue("@s_height", "");
                cmd.Parameters.AddWithValue("@s_width", "");
                cmd.Parameters.AddWithValue("@s_size", "");
                cmd.Parameters.AddWithValue("@s_samount", "");
                cmd.Parameters.AddWithValue("@s_status", Convert.ToString(Dd_status.SelectedValue));
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
                SqlCommand cmd = new SqlCommand("insert into tbl_temp_sale_invoice values(@s_invoice_no,@s_date,@s_customer_name,@s_customer_contact,@s_customer_address,@s_customer_gst_no,@s_customer_email,@s_designer,@s_invoice_date,@s_due_date,@s_product_name,@s_quantity,@s_total_quantity,@s_rate,@s_discount,@s_cgstp,@s_cgsta,@s_sgstp,@s_sgsta,@s_igstp,@s_igsta,@s_amount,@s_sub_total,@s_total_gst,@s_shipping_charges,@s_adjustment,@s_total,@s_stotal,@s_hsn,@s_unit,@s_desc,@s_height,@s_width,@s_size,@s_samount,@s_status,@s_total_cgst,@s_total_sgst,@s_total_igst,@s_total_taxable,@s_balance)", conn);

                cmd.Parameters.AddWithValue("@s_invoice_no", Convert.ToString(Txt_invoice.Text));
                cmd.Parameters.AddWithValue("@s_date", DateTime.Now.ToShortDateString());
                cmd.Parameters.AddWithValue("@s_customer_name", Convert.ToString(Dd_customer.SelectedItem.Text));
                cmd.Parameters.AddWithValue("@s_customer_contact", Convert.ToString(lbl_cutomer_contact.Value));
                cmd.Parameters.AddWithValue("@s_customer_address", Convert.ToString(lbl_cutomer_address.Value));
                cmd.Parameters.AddWithValue("@s_customer_gst_no", Convert.ToString(lbl_cutomer_gst_no.Value));
                cmd.Parameters.AddWithValue("@s_customer_email", Convert.ToString(lbl_cutomer_email.Value));
                cmd.Parameters.AddWithValue("@s_designer", Convert.ToString(Dd_staff.SelectedItem.Text));
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
                cmd.Parameters.AddWithValue("@s_shipping_charges", "");
                cmd.Parameters.AddWithValue("@s_adjustment", Convert.ToDecimal(Txt_advance.Text));
                cmd.Parameters.AddWithValue("@s_total", Convert.ToDecimal(hide_total.Text));
                cmd.Parameters.AddWithValue("@s_stotal", Convert.ToDecimal(txt_total_amt.Text));
                cmd.Parameters.AddWithValue("@s_hsn", Convert.ToString(lbl_product_hsn.Value));
                cmd.Parameters.AddWithValue("@s_desc", Convert.ToString(Txt_description.Text));
                cmd.Parameters.AddWithValue("@s_height", Convert.ToDecimal(txt_height.Text));
                cmd.Parameters.AddWithValue("@s_width", Convert.ToDecimal(txt_width.Text));
                cmd.Parameters.AddWithValue("@s_size", Convert.ToDecimal(txt_sqrft.Text));
                cmd.Parameters.AddWithValue("@s_samount", Convert.ToDecimal(txt_amount.Text));
                cmd.Parameters.AddWithValue("@s_status", Convert.ToString(Dd_status.SelectedValue));
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
        cmd4 = new SqlCommand("select * from tbl_product where p_name ='" + pro_name.ToString() + "'", conn);
        adapt4 = new SqlDataAdapter(cmd4);
        dt4 = new DataTable();

        adapt4.Fill(dt4);
        if (dt4.Rows.Count > 0)
        {
            rate = dt4.Rows[0]["p_rate"].ToString();
            cgst = dt4.Rows[0]["p_cgst"].ToString();
            sgst = dt4.Rows[0]["p_sgst"].ToString();
            igst = dt4.Rows[0]["p_igst"].ToString();
            hsn = dt4.Rows[0]["p_hsn_code"].ToString();
            unit = dt4.Rows[0]["p_unit"].ToString();
            desc = dt4.Rows[0]["p_desc"].ToString();
            if (unit == "Pcs")
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
            txt_cgst.Text = cgst;
            txt_sgst.Text = sgst;
            txt_igst.Text = igst;
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
               
                SqlCommand cmd44 = new SqlCommand("DELETE FROM tbl_order_invoice Where s_invoice_no='" + invoice + "'", conn);
                conn.Open();
                cmd44.ExecuteNonQuery();
                conn.Close();
            }
            catch (Exception ex)
            {

            }

            try
            {
                int rowscount = GridView1.Rows.Count;
                for (int i = 0; i < rowscount; i++)
                {


                    SqlCommand cmd = new SqlCommand("insert into tbl_order_invoice values(@s_invoice_no,@s_date,@s_customer_name,@s_customer_contact,@s_customer_address,@s_customer_gst_no,@s_customer_email,@s_designer,@s_invoice_date,@s_due_date,@s_product_name,@s_quantity,@s_total_quantity,@s_rate,@s_discount,@s_cgstp,@s_cgsta,@s_sgstp,@s_sgsta,@s_igstp,@s_igsta,@s_amount,@s_sub_total,@s_total_gst,@s_shipping_charges,@s_adjustment,@s_total,@s_stotal,@s_hsn,@s_unit,@s_desc,@s_height,@s_width,@s_size,@s_samount,@s_status,@s_total_cgst,@s_total_sgst,@s_total_igst,@s_total_taxable,@s_balance)", conn);
                    cmd.Parameters.AddWithValue("@s_invoice_no", Convert.ToString(Txt_invoice.Text));
                    cmd.Parameters.AddWithValue("@s_date", lbl_date.Value.ToString());
                    cmd.Parameters.AddWithValue("@s_customer_name", Convert.ToString(Dd_customer.SelectedItem.Text));
                    cmd.Parameters.AddWithValue("@s_customer_contact", Convert.ToString(lbl_cutomer_contact.Value));
                    cmd.Parameters.AddWithValue("@s_customer_address", Convert.ToString(lbl_cutomer_address.Value));
                    cmd.Parameters.AddWithValue("@s_customer_gst_no", Convert.ToString(lbl_cutomer_gst_no.Value));
                    cmd.Parameters.AddWithValue("@s_customer_email", Convert.ToString(lbl_cutomer_email.Value));
                    cmd.Parameters.AddWithValue("@s_designer", Convert.ToString(Dd_staff.SelectedItem.Text));
                    cmd.Parameters.AddWithValue("@s_invoice_date", Txt_invoice_date.Text);
                    cmd.Parameters.AddWithValue("@s_due_date", Txt_due_date.Text);
                    cmd.Parameters.AddWithValue("@s_product_name", Convert.ToString(GridView1.Rows[i].Cells[0].Text));
                    cmd.Parameters.AddWithValue("@s_quantity", Convert.ToDecimal(GridView1.Rows[i].Cells[7].Text));
                    cmd.Parameters.AddWithValue("@s_unit", Convert.ToString(GridView1.Rows[i].Cells[17].Text));
                    cmd.Parameters.AddWithValue("@s_total_quantity", Convert.ToDecimal(lbl_totalqty.Text));
                    cmd.Parameters.AddWithValue("@s_rate", Convert.ToDecimal(GridView1.Rows[i].Cells[5].Text));
                    cmd.Parameters.AddWithValue("@s_discount", Convert.ToDecimal(Txt_discount.Text));
                    cmd.Parameters.AddWithValue("@s_cgstp", Convert.ToDecimal(GridView1.Rows[i].Cells[13].Text));
                    cmd.Parameters.AddWithValue("@s_cgsta", Convert.ToDecimal(GridView1.Rows[i].Cells[9].Text));
                    cmd.Parameters.AddWithValue("@s_sgstp", Convert.ToDecimal(GridView1.Rows[i].Cells[14].Text));
                    cmd.Parameters.AddWithValue("@s_sgsta", Convert.ToDecimal(GridView1.Rows[i].Cells[10].Text));
                    cmd.Parameters.AddWithValue("@s_igstp", Convert.ToDecimal(GridView1.Rows[i].Cells[15].Text));
                    cmd.Parameters.AddWithValue("@s_igsta", Convert.ToDecimal(GridView1.Rows[i].Cells[11].Text));
                    cmd.Parameters.AddWithValue("@s_amount", Convert.ToDecimal(GridView1.Rows[i].Cells[12].Text));
                    cmd.Parameters.AddWithValue("@s_sub_total", Convert.ToDecimal(lbl_subtotal.Text));
                    cmd.Parameters.AddWithValue("@s_total_gst", Convert.ToDecimal(lbl_gst.Text));
                    cmd.Parameters.AddWithValue("@s_shipping_charges", "");
                    cmd.Parameters.AddWithValue("@s_adjustment", Convert.ToDecimal(Txt_advance.Text));
                    cmd.Parameters.AddWithValue("@s_total", Convert.ToDecimal(hide_total.Text));
                    cmd.Parameters.AddWithValue("@s_stotal", Convert.ToDecimal(GridView1.Rows[i].Cells[8].Text));
                    cmd.Parameters.AddWithValue("@s_hsn", Convert.ToString(GridView1.Rows[i].Cells[1].Text));
                    cmd.Parameters.AddWithValue("@s_desc", Convert.ToString(GridView1.Rows[i].Cells[16].Text));
                    cmd.Parameters.AddWithValue("@s_height", Convert.ToDecimal(GridView1.Rows[i].Cells[2].Text));
                    cmd.Parameters.AddWithValue("@s_width", Convert.ToDecimal(GridView1.Rows[i].Cells[3].Text));
                    cmd.Parameters.AddWithValue("@s_size", Convert.ToDecimal(GridView1.Rows[i].Cells[4].Text));
                    cmd.Parameters.AddWithValue("@s_samount", Convert.ToDecimal(GridView1.Rows[i].Cells[6].Text));
                    cmd.Parameters.AddWithValue("@s_status", Convert.ToString(Dd_status.SelectedValue));
                    cmd.Parameters.AddWithValue("@s_total_cgst", Convert.ToDecimal(lbl_total_cgst.Value));
                    cmd.Parameters.AddWithValue("@s_total_sgst", Convert.ToDecimal(lbl_total_sgst.Value));
                    cmd.Parameters.AddWithValue("@s_total_igst", Convert.ToDecimal(lbl_total_igst.Value));
                    cmd.Parameters.AddWithValue("@s_total_taxable", Convert.ToDecimal(lbl_total_taxable.Value));
                    cmd.Parameters.AddWithValue("@s_balance", new_balance);
                    conn.Open();
                    cmd.ExecuteNonQuery();

                    conn.Close();
                }
                SqlCommand cmd2 = new SqlCommand("update tbl_order SET sl_invoice_no='" + Convert.ToString(Txt_invoice.Text) + "',sl_date='" + Convert.ToDateTime(lbl_date.Value).ToString("MM/dd/yyyy") + "',sl_customer_name='" + Convert.ToString(Dd_customer.SelectedItem.Text) + "',sl_customer_contact='" + Convert.ToString(lbl_cutomer_contact.Value) + "',sl_customer_address='" + Convert.ToString(lbl_cutomer_address.Value) + "',sl_customer_gst_no='" + Convert.ToString(lbl_cutomer_gst_no.Value) + "',sl_customer_email='" + Convert.ToString(lbl_cutomer_email.Value) + "',sl_designer='" + Convert.ToString(Dd_staff.SelectedItem.Text) + "',sl_invoice_date='" + Txt_invoice_date.Text + "',sl_due_date='" + Txt_due_date.Text + "',sl_total_quantity='" + Convert.ToDecimal(lbl_totalqty.Text) + "',sl_discount='" + Convert.ToDecimal(Txt_discount.Text) + "',sl_sub_total='" + Convert.ToDecimal(lbl_subtotal.Text) + "',sl_total_gst='" + Convert.ToDecimal(lbl_gst.Text) + "',sl_adjustment='" + Convert.ToDecimal(Txt_advance.Text) + "',sl_total='" + Convert.ToDecimal(hide_total.Text) + "',sl_total_cgst='" + Convert.ToDecimal(lbl_total_cgst.Value) + "',sl_total_sgst='" + Convert.ToDecimal(lbl_total_sgst.Value) + "',sl_total_igst='" + Convert.ToDecimal(lbl_total_igst.Value) + "',sl_total_taxable='" + Convert.ToDecimal(lbl_total_taxable.Value) + "',sl_balance='" + new_balance + "' where sl_invoice_no='" + Txt_invoice.Text + "' ", conn);
                //cmd2.Parameters.AddWithValue("@sl_invoice_no", Convert.ToString(Txt_invoice.Text));
                //cmd2.Parameters.AddWithValue("@sl_date", DateTime.Now.ToShortDateString());
                //cmd2.Parameters.AddWithValue("@sl_customer_name", Convert.ToString(Dd_customer.SelectedItem.Text));
                //cmd2.Parameters.AddWithValue("@sl_customer_contact", Convert.ToString(lbl_cutomer_contact.Value));
                //cmd2.Parameters.AddWithValue("@sl_customer_address", Convert.ToString(lbl_cutomer_address.Value));
                //cmd2.Parameters.AddWithValue("@sl_customer_gst_no", Convert.ToString(lbl_cutomer_gst_no.Value));
                //cmd2.Parameters.AddWithValue("@sl_customer_email", Convert.ToString(lbl_cutomer_email.Value));
                //cmd2.Parameters.AddWithValue("@sl_order_no", Convert.ToString(Txt_order_no.Text));
                //cmd2.Parameters.AddWithValue("@sl_invoice_date", Txt_invoice_date.Text);
                //cmd2.Parameters.AddWithValue("@sl_due_date", Txt_due_date.Text);

                //cmd2.Parameters.AddWithValue("@sl_total_quantity", Convert.ToDecimal(lbl_totalqty.Text));

                //cmd2.Parameters.AddWithValue("@sl_discount", Convert.ToDecimal(Txt_discount.Text));


                //cmd2.Parameters.AddWithValue("@sl_sub_total", Convert.ToDecimal(lbl_subtotal.Text));
                //cmd2.Parameters.AddWithValue("@sl_total_gst", Convert.ToDecimal(lbl_gst.Text));
                //cmd2.Parameters.AddWithValue("@sl_shipping_charges", Convert.ToDecimal(Txt_shipping.Text));
                //cmd2.Parameters.AddWithValue("@sl_adjustment", Convert.ToDecimal(Txt_adjustment.Text));
                //cmd2.Parameters.AddWithValue("@sl_total", Convert.ToDecimal(hide_total.Text));
                //cmd2.Parameters.AddWithValue("@sl_total_cgst", Convert.ToDecimal(lbl_total_cgst.Value));
                //cmd2.Parameters.AddWithValue("@sl_total_sgst", Convert.ToDecimal(lbl_total_sgst.Value));
                //cmd2.Parameters.AddWithValue("@sl_total_igst", Convert.ToDecimal(lbl_total_igst.Value));
                //cmd2.Parameters.AddWithValue("@sl_total_taxable", Convert.ToDecimal(lbl_total_taxable.Value));
                //cmd2.Parameters.AddWithValue("@sl_balance", new_balance);
                conn.Open();
                cmd2.ExecuteNonQuery();
                conn.Close();

                Lbl_message.Text = "" + Dd_customer.Text + " Added Successfully!!!";


            }
            catch (Exception ex)
            { }
          
            Response.Redirect("bill.aspx?invoice=" + Txt_invoice.Text + "&bill_update=success");
            //string redirectScript = " window.location.href = 'bill.aspx?invoice=" + Txt_invoice.Text + "';";
            //System.Web.UI.ScriptManager.RegisterStartupScript(this, GetType(), "displayalertmessage", "alert('Sale Invoice Updated Successfully!!!');" + redirectScript, true);

        }
    }



    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        //GridView1.PageIndex = e.NewPageIndex;


    }



    protected void Dd_customer_SelectedIndexChanged(object sender, EventArgs e)
    {
        string cust_name = Dd_customer.SelectedItem.Text;
        string contact, address, gst, balance, email;
        cmd5 = new SqlCommand("select * from tbl_customer where c_name ='" + cust_name.ToString() + "'", conn);
        adapt5 = new SqlDataAdapter(cmd5);
        dt5 = new DataTable();

        adapt5.Fill(dt5);
        if (dt5.Rows.Count > 0)
        {
            contact = dt5.Rows[0]["c_contact"].ToString();
            address = dt5.Rows[0]["c_address"].ToString();
            gst = dt5.Rows[0]["c_gst_no"].ToString();
            balance = dt5.Rows[0]["c_opening_balance"].ToString();
            email = dt5.Rows[0]["c_email"].ToString();


            lbl_cutomer_contact.Value = contact;
            lbl_cutomer_address.Value = address;
            lbl_cutomer_gst_no.Value = gst;
            lbl_opening_balance.Value = balance;
            lbl_cutomer_email.Value = email;


        }
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

            //SqlCommand cmd33 = new SqlCommand("DELETE FROM tbl_temp_sale_invoice Where s_id=@ID", conn);
            //cmd33.Parameters.AddWithValue("@ID",id);
            //conn.Open();
            //cmd33.ExecuteNonQuery();
            //conn.Close();

            //FillGRid();
        }
        if (e.CommandName.Equals("Edit"))
        {
            string id = e.CommandArgument.ToString();

            //SqlCommand cmd33 = new SqlCommand("DELETE FROM tbl_temp_sale_invoice Where s_id=@ID", conn);
            //cmd33.Parameters.AddWithValue("@ID",id);
            //conn.Open();
            //cmd33.ExecuteNonQuery();
            //conn.Close();

            //FillGRid();
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
        Dd_status.SelectedValue = GridView1.SelectedRow.Cells[19].Text;
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

            SqlCommand cmd6 = new SqlCommand("update tbl_temp_order_invoice set s_product_name='" + Dd_enter_product.SelectedItem.Text + "',s_product_hsn='" + lbl_product_hsn.Value + "',s_height='" + txt_height2.Text + "',s_width='" + txt_width2.Text + "',s_size='" + txt_sqrft2.Text + "',s_rate='" + txt_rate2.Text + "',s_samount='" + txt_amount2.Text + "',s_quantity='" + txt_quantity2.Text + "',s_stotal='" + txt_total_amt2.Text + "',s_cgsta='" + cgstamount + "',s_sgsta='" + sgstamount + "',s_igsta='" + igstamount + "',s_amount='" + txt_final_amt.Text + "',s_cgstp='" + txt_cgst.Text + "',s_sgstp='" + txt_sgst.Text + "',s_igstp='" + txt_igst.Text + "',s_desc='" + Txt_description.Text + "',s_unit='" + lbl_unit.Value + "',s_status='" + Dd_status.SelectedValue + "' WHERE s_id='" + lbl_id.Value.Trim() + "'", conn);

            conn.Open();
            cmd6.ExecuteNonQuery();

            conn.Close();
            FillGRid();
        }
        else
        {
            decimal cgstamount = Convert.ToDecimal(txt_total_amt.Text) * Convert.ToDecimal(txt_cgst.Text) / 100;
            decimal sgstamount = Convert.ToDecimal(txt_total_amt.Text) * Convert.ToDecimal(txt_sgst.Text) / 100;
            decimal igstamount = Convert.ToDecimal(txt_total_amt.Text) * Convert.ToDecimal(txt_igst.Text) / 100;

            SqlCommand cmd6 = new SqlCommand("update tbl_temp_order_invoice set s_product_name='" + Dd_enter_product.SelectedItem.Text + "',s_product_hsn='" + lbl_product_hsn.Value + "',s_height='" + txt_height.Text + "',s_width='" + txt_width.Text + "',s_size='" + txt_sqrft.Text + "',s_rate='" + txt_rate.Text + "',s_samount='" + txt_amount.Text + "',s_quantity='" + txt_quantity.Text + "',s_stotal='" + txt_total_amt.Text + "',s_cgsta='" + cgstamount + "',s_sgsta='" + sgstamount + "',s_igsta='" + igstamount + "',s_amount='" + txt_final_amt.Text + "',s_cgstp='" + txt_cgst.Text + "',s_sgstp='" + txt_sgst.Text + "',s_igstp='" + txt_igst.Text + "',s_desc='" + Txt_description.Text + "',s_unit='" + lbl_unit.Value + "',s_status='" + Dd_status.SelectedValue + "' WHERE s_id='" + lbl_id.Value.Trim() + "'", conn);

            conn.Open();
            cmd6.ExecuteNonQuery();

            conn.Close();
            FillGRid();
        }
    }

    protected void Button2_Click(object sender, EventArgs e)
    {
        int i = Convert.ToInt32(GridView1.SelectedRow.Cells[18].Text);

        SqlCommand cmd = new SqlCommand("Delete from tbl_temp_order_invoice where s_id='" + i + "'", conn);
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