using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

public partial class Purchase_edit_roll_bill : System.Web.UI.Page
{
    SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["String"].ConnectionString);
    decimal total_amount = 0, final_total = 0;
    decimal dPageTotal;
    decimal totalvalue, totalcgst, totalsgst, totaligst, totalgst, totalqty, totaltaxable, Old_total, old_balance, paid, new_balance, new_total, rem;
    string invoice;
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
                invoice = Request.QueryString["invoice"].ToString();
                if (!IsPostBack)
                {

                    RefreshData();
                    this.customer();
                    this.product();
                    GetData();
                    feet();
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
        string query = "select * from tbl_vendor Order By v_name asc";
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
        string query = "select * from tbl_purchase_product where p_unit='Mtr' order by p_name asc";
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
    public void feet()
    {
        string query = "select * from tbl_feet ORDER BY f_feet ASC";
        SqlDataAdapter adapt4 = new SqlDataAdapter(query, conn);
        DataTable dt5 = new DataTable();
        adapt4.Fill(dt5);
        if (dt5.Rows.Count > 0)
        {
            Dd_feet.DataSource = dt5;
            Dd_feet.DataBind();
            Dd_feet.DataTextField = "f_feet";
            Dd_feet.DataValueField = "f_feet";
            Dd_feet.DataBind();
            Dd_feet.Items.Insert(0, new ListItem("--Select--", "--Select--"));

            Dd_feet.SelectedItem.Selected = false;
            Dd_feet.Items.FindByText("--Select--").Selected = true;
        }

    }
    protected void GetData()
    {
        SqlCommand cmd = new SqlCommand("select * from tbl_roll_purchase_invoice where rpc_invoice_no='" + invoice + "'", conn);
        SqlDataAdapter adapt = new SqlDataAdapter(cmd);
        DataTable dt = new DataTable();
        adapt.Fill(dt);
        if (dt.Rows.Count > 0)
        {
            id = Convert.ToInt32(dt.Rows[0]["rpc_id"]);
            Dd_customer.SelectedValue = dt.Rows[0]["v_id"].ToString();
            Txt_invoice.Text = dt.Rows[0]["rpc_invoice_no"].ToString();
            Txt_order_no.Text = dt.Rows[0]["rpc_order_no"].ToString();
            lbl_date.Value = Convert.ToDateTime(dt.Rows[0]["rpc_date"]).ToString("MM/dd/yyyy");
            Txt_invoice_date.Text = Convert.ToDateTime(dt.Rows[0]["rpc_invoice_date"]).ToString("MM/dd/yyyy");
            Txt_due_date.Text = Convert.ToDateTime(dt.Rows[0]["rpc_due_date"]).ToString("MM/dd/yyyy");
            //lbl_totalqty.Text = dt7.Rows[0]["s_total_quantity"].ToString();
            lbl_subtotal.Text = dt.Rows[0]["rpc_sub_total"].ToString();
            lbl_subtotal2.Value = dt.Rows[0]["rpc_sub_total"].ToString();
            lbl_gst.Text = dt.Rows[0]["rpc_total_gst"].ToString();
            Txt_shipping.Text = dt.Rows[0]["rpc_shipping_charges"].ToString();
            Txt_adjustment.Text = dt.Rows[0]["rpc_adjustable"].ToString();
            Txt_discount.Text = dt.Rows[0]["rpc_discount"].ToString();
            lbl_total.Text = dt.Rows[0]["rpc_total"].ToString();
            hide_total.Text = dt.Rows[0]["rpc_total"].ToString();
            lbl_balance.Value = dt.Rows[0]["rpc_balance"].ToString();

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
            SqlCommand cmd998 = new SqlCommand("delete from tbl_temp_roll_purchase_invoice", conn);
            conn.Open();
            cmd998.ExecuteNonQuery();
            conn.Close();

            if (conn.State != ConnectionState.Closed)
            {
                conn.Close();
            }
            SqlCommand cmd99 = new SqlCommand("insert into tbl_temp_roll_purchase_invoice select rpc_invoice_no,rpc_date,v_id,rpc_order_no,rpc_invoice_date,rpc_due_date,rpc_product_name,rpc_quantity,rpc_total_quantity,rpc_rate,rpc_discount,rpc_cgstp,rpc_cgsta,rpc_sgstp,rpc_sgsta,rpc_igstp,rpc_igsta,rpc_amount,rpc_sub_total,rpc_total_gst,rpc_shipping_charges,rpc_adjustable,rpc_total,rpc_stotal,rpc_product_hsn,rpc_unit,rpc_desc,rpc_heightft,rpc_heightmtr,rpc_roll_size,rpc_total_size,rpc_size,rpc_samount,rpc_total_cgst,rpc_total_sgst,rpc_total_igst,rpc_total_taxable,rpc_balance from tbl_roll_purchase_invoice where rpc_invoice_no='" + invoice + "'", conn);
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


            SqlCommand cmd88 = new SqlCommand("select rpc_product_name as Product,rpc_product_hsn as HSN,rpc_heightft as [Height Ft],rpc_heightmtr as [Height Mtr],rpc_roll_size as [Roll Size Mtr],rpc_total_size as [Total Mtr],rpc_size as SQRFT,rpc_rate as Rate,rpc_samount as Amount,rpc_quantity as Qty,rpc_stotal as Total,rpc_cgsta as CGST,rpc_sgsta as SGST,rpc_igsta as IGST,rpc_amount as FINAL,rpc_cgstp as cgstp,rpc_sgstp as sgstp,rpc_igstp as igstp,rpc_desc as [desc],rpc_unit as unit,rpc_id as[ID] from tbl_temp_roll_purchase_invoice where rpc_invoice_no='" + invoice + "'", conn);
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
        string str3 = Txt_rate.Text.Trim();

        string str4 = txt_cgst.Text.Trim();
        string str8 = txt_total_amt.Text.Trim();
        string str5 = txt_sgst.Text.Trim();
        string str6 = txt_igst.Text.Trim();
        string str7 = txt_amount.Text.Trim();
        string str9 = lbl_unit.Value.Trim();
        string str10 = lbl_product_hsn.Value.Trim();

        //new data 
        string heightft = Dd_feet.SelectedValue;
        string heightmtr = Txt_roll_height.Text.Trim();
        string rollsize = Txt_roll_size.Text.Trim();
        string totalroll = Txt_total_roll.Text.Trim();
        string sqrft = Txt_total_roll_sq.Text.Trim();
        string rate = Txt_rate.Text.Trim();
        string amount = txt_amount.Text.Trim();


        string quantity = txt_quantity.Text.Trim();
        string total = txt_total_amt.Text.Trim();
        string cgst = txt_cgst.Text.Trim();
        string sgst = txt_sgst.Text.Trim();
        string igst = txt_igst.Text.Trim();

        string final = txt_final_amt.Text;
        string desc = Txt_description.Text;




            decimal cgstamount = Convert.ToDecimal(total) * Convert.ToDecimal(cgst) / 100;
            decimal sgstamount = Convert.ToDecimal(total) * Convert.ToDecimal(sgst) / 100;
            decimal igstamount = Convert.ToDecimal(total) * Convert.ToDecimal(igst) / 100;


            try
            {
                SqlCommand cmd = new SqlCommand("insert into tbl_temp_roll_purchase_invoice values(@s_invoice_no,@s_date,@v_id,@s_order_no,@s_invoice_date,@s_due_date,@s_product_name,@s_quantity,@s_total_quantity,@s_rate,@s_discount,@s_cgstp,@s_cgsta,@s_sgstp,@s_sgsta,@s_igstp,@s_igsta,@s_amount,@s_sub_total,@s_total_gst,@s_shipping_charges,@s_adjustment,@s_total,@s_stotal,@s_hsn,@s_unit,@s_desc,@s_heightft,@s_heightmtr,@s_roll_size,@s_total_size,@s_size,@s_samount,@s_total_cgst,@s_total_sgst,@s_total_igst,@s_total_taxable,@s_balance)", conn);

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
                cmd.Parameters.AddWithValue("@s_rate", Convert.ToDecimal(Txt_rate.Text));
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
                cmd.Parameters.AddWithValue("@s_heightft", Convert.ToDecimal(Dd_feet.SelectedValue));
                cmd.Parameters.AddWithValue("@s_heightmtr", Convert.ToDecimal(Txt_roll_height.Text));
                cmd.Parameters.AddWithValue("@s_roll_size", Convert.ToDecimal(Txt_roll_size.Text));
                cmd.Parameters.AddWithValue("@s_total_size", Convert.ToDecimal(Txt_total_roll.Text));
                cmd.Parameters.AddWithValue("@s_size", Convert.ToDecimal(Txt_total_roll_sq.Text));
                cmd.Parameters.AddWithValue("@s_samount", Convert.ToDecimal(txt_amount.Text));
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
    protected void GridView1_DataBound(object sender, EventArgs e)
    {

    }
    int total = 0, indexofcolumn = 1;
    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {

        if (e.Row.Cells.Count > indexofcolumn)
        {
            e.Row.Cells[1].Visible = false;
            e.Row.Cells[2].Visible = false;
            e.Row.Cells[3].Visible = false;
            e.Row.Cells[4].Visible = false;
            e.Row.Cells[5].Visible = false;
            e.Row.Cells[15].Visible = false;
            e.Row.Cells[16].Visible = false;
            e.Row.Cells[17].Visible = false;
            e.Row.Cells[18].Visible = false;
            e.Row.Cells[19].Visible = false;
            e.Row.Cells[20].Visible = false;
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
            
            txt_cgst.Text = cgst;
            txt_sgst.Text = sgst;
            txt_igst.Text = igst;
            Txt_rate.Text = rate;
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
                SqlCommand cmd4 = new SqlCommand("select * from tbl_roll_purchase_invoice where rpc_invoice_no='" + invoice + "'", conn);
                SqlDataAdapter adapt4 = new SqlDataAdapter(cmd4);
                DataTable dt4 = new DataTable();
                adapt4.Fill(dt4);
                if (dt4.Rows.Count > 0)
                {
                    Old_total = Convert.ToDecimal(dt4.Rows[0]["rpc_total"]);
                    old_balance = Convert.ToDecimal(dt4.Rows[0]["rpc_balance"]);
                    paid = Old_total - old_balance;
                    new_total = Convert.ToDecimal(hide_total.Text);
                    new_balance = new_total - paid;
                    rem = new_total - Old_total;
                }

                //SqlCommand cmd33 = new SqlCommand("DELETE FROM tbl_purchase Where pu_invoice_no='" + invoice + "'", conn);
                //conn.Open();
                //cmd33.ExecuteNonQuery();
                //conn.Close();

                SqlCommand cmd44 = new SqlCommand("DELETE FROM tbl_roll_purchase_invoice Where rpc_invoice_no='" + invoice + "'", conn);
                conn.Open();
                cmd44.ExecuteNonQuery();
                conn.Close();
           
                int rowscount = GridView1.Rows.Count;
                for (int i = 0; i < rowscount; i++)
                {


                    SqlCommand cmd = new SqlCommand("insert into tbl_roll_purchase_invoice values(@rpc_invoice_no,@rpc_date,@v_id,@rpc_order_no,@rpc_invoice_date,@rpc_due_date,@rpc_product_name,@rpc_quantity,@rpc_total_quantity,@rpc_rate,@rpc_discount,@rpc_cgstp,@rpc_cgsta,@rpc_sgstp,@rpc_sgsta,@rpc_igstp,@rpc_igsta,@rpc_amount,@rpc_sub_total,@rpc_total_gst,@rpc_shipping_charges,@rpc_adjustment,@rpc_total,@rpc_stotal,@rpc_hsn,@rpc_unit,@rpc_desc,@rpc_heightft,@rpc_heightmtr,@rpc_roll_size,@rpc_total_size,@rpc_size,@rpc_samount,@rpc_total_cgst,@rpc_total_sgst,@rpc_total_igst,@rpc_total_taxable,@rpc_balance)", conn);
                    cmd.Parameters.AddWithValue("@rpc_invoice_no", Convert.ToString(Txt_invoice.Text));
                    cmd.Parameters.AddWithValue("@rpc_date", DateTime.Now.ToShortDateString());
                    cmd.Parameters.AddWithValue("@v_id", Convert.ToString(Dd_customer.SelectedValue));

                    cmd.Parameters.AddWithValue("@rpc_order_no", Convert.ToString(Txt_order_no.Text));
                    cmd.Parameters.AddWithValue("@rpc_invoice_date", Txt_invoice_date.Text);
                    cmd.Parameters.AddWithValue("@rpc_due_date", Txt_due_date.Text);
                    cmd.Parameters.AddWithValue("@rpc_product_name", Convert.ToString(GridView1.Rows[i].Cells[0].Text));
                    cmd.Parameters.AddWithValue("@rpc_quantity", Convert.ToDecimal(GridView1.Rows[i].Cells[9].Text));
                    cmd.Parameters.AddWithValue("@rpc_unit", Convert.ToString(GridView1.Rows[i].Cells[19].Text));
                    cmd.Parameters.AddWithValue("@rpc_total_quantity", Convert.ToDecimal(lbl_totalqty.Text));
                    cmd.Parameters.AddWithValue("@rpc_rate", Convert.ToDecimal(GridView1.Rows[i].Cells[7].Text));
                    cmd.Parameters.AddWithValue("@rpc_discount", Convert.ToDecimal(Txt_discount.Text));
                    cmd.Parameters.AddWithValue("@rpc_cgstp", Convert.ToDecimal(GridView1.Rows[i].Cells[15].Text));
                    cmd.Parameters.AddWithValue("@rpc_cgsta", Convert.ToDecimal(GridView1.Rows[i].Cells[11].Text));
                    cmd.Parameters.AddWithValue("@rpc_sgstp", Convert.ToDecimal(GridView1.Rows[i].Cells[16].Text));
                    cmd.Parameters.AddWithValue("@rpc_sgsta", Convert.ToDecimal(GridView1.Rows[i].Cells[12].Text));
                    cmd.Parameters.AddWithValue("@rpc_igstp", Convert.ToDecimal(GridView1.Rows[i].Cells[17].Text));
                    cmd.Parameters.AddWithValue("@rpc_igsta", Convert.ToDecimal(GridView1.Rows[i].Cells[13].Text));
                    cmd.Parameters.AddWithValue("@rpc_amount", Convert.ToDecimal(GridView1.Rows[i].Cells[14].Text));
                    cmd.Parameters.AddWithValue("@rpc_sub_total", Convert.ToDecimal(lbl_subtotal.Text));
                    cmd.Parameters.AddWithValue("@rpc_total_gst", Convert.ToDecimal(lbl_gst.Text));
                    cmd.Parameters.AddWithValue("@rpc_shipping_charges", Convert.ToDecimal(Txt_shipping.Text));
                    cmd.Parameters.AddWithValue("@rpc_adjustment", Convert.ToDecimal(Txt_adjustment.Text));
                    cmd.Parameters.AddWithValue("@rpc_total", Convert.ToDecimal(hide_total.Text));
                    cmd.Parameters.AddWithValue("@rpc_stotal", Convert.ToDecimal(GridView1.Rows[i].Cells[10].Text));
                    if (GridView1.Rows[i].Cells[1].Text.Trim() == "&amp;nbsp;")
                    {
                        cmd.Parameters.AddWithValue("@rpc_hsn", "");
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@rpc_hsn", Convert.ToString(GridView1.Rows[i].Cells[1].Text.Trim()));
                    }
                    if (GridView1.Rows[i].Cells[18].Text.Trim() == "&amp;nbsp;")
                    {
                        cmd.Parameters.AddWithValue("@rpc_desc", "");
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@rpc_desc", Convert.ToString(GridView1.Rows[i].Cells[18].Text.Trim()));
                    }
                    cmd.Parameters.AddWithValue("@rpc_heightft", Convert.ToDecimal(GridView1.Rows[i].Cells[2].Text));
                    cmd.Parameters.AddWithValue("@rpc_heightmtr", Convert.ToDecimal(GridView1.Rows[i].Cells[3].Text));
                    cmd.Parameters.AddWithValue("@rpc_roll_size", Convert.ToDecimal(GridView1.Rows[i].Cells[4].Text));
                    cmd.Parameters.AddWithValue("@rpc_total_size", Convert.ToDecimal(GridView1.Rows[i].Cells[5].Text));
                    cmd.Parameters.AddWithValue("@rpc_size", Convert.ToDecimal(GridView1.Rows[i].Cells[6].Text));
                    cmd.Parameters.AddWithValue("@rpc_samount", Convert.ToDecimal(GridView1.Rows[i].Cells[8].Text));
                    cmd.Parameters.AddWithValue("@rpc_total_cgst", Convert.ToDecimal(lbl_total_cgst.Value));
                    cmd.Parameters.AddWithValue("@rpc_total_sgst", Convert.ToDecimal(lbl_total_sgst.Value));
                    cmd.Parameters.AddWithValue("@rpc_total_igst", Convert.ToDecimal(lbl_total_igst.Value));
                    cmd.Parameters.AddWithValue("@rpc_total_taxable", Convert.ToDecimal(lbl_total_taxable.Value));
                    cmd.Parameters.AddWithValue("@rpc_balance", new_balance);
                    conn.Open();
                    cmd.ExecuteNonQuery();

                    conn.Close();
                }
                SqlCommand cmd2 = new SqlCommand("update tbl_roll_purchase SET rpu_invoice_no='" + Convert.ToString(Txt_invoice.Text) + "',rpu_date='" + Convert.ToDateTime(lbl_date.Value).ToString("MM/dd/yyyy") + "',v_id='" + Dd_customer.SelectedValue + "',rpu_order_no='" + Convert.ToString(Txt_order_no.Text) + "',rpu_invoice_date='" + Txt_invoice_date.Text + "',rpu_due_date='" + Txt_due_date.Text + "',rpu_total_quantity='" + Convert.ToDecimal(lbl_totalqty.Text) + "',rpu_discount='" + Convert.ToDecimal(Txt_discount.Text) + "',rpu_sub_total='" + Convert.ToDecimal(lbl_subtotal.Text) + "',rpu_total_gst='" + Convert.ToDecimal(lbl_gst.Text) + "',rpu_shipping_charges='" + Convert.ToDecimal(Txt_shipping.Text) + "',rpu_adjustment='" + Convert.ToDecimal(Txt_adjustment.Text) + "',rpu_total='" + Convert.ToDecimal(hide_total.Text) + "',rpu_total_cgst='" + Convert.ToDecimal(lbl_total_cgst.Value) + "',rpu_total_sgst='" + Convert.ToDecimal(lbl_total_sgst.Value) + "',rpu_total_igst='" + Convert.ToDecimal(lbl_total_igst.Value) + "',rpu_total_taxable='" + Convert.ToDecimal(lbl_total_taxable.Value) + "',rpu_balance='" + new_balance + "' where rpu_invoice_no='" + Txt_invoice.Text + "' ", conn);
                //cmd2.Parameters.AddWithValue("@pu_invoice_no", Convert.ToString(Txt_invoice.Text));
                //cmd2.Parameters.AddWithValue("@pu_date", Convert.ToDateTime(lbl_date.Value).ToString("MM/dd/yyyy"));
                //cmd2.Parameters.AddWithValue("@pu_customer_name", Convert.ToString(Dd_customer.SelectedItem.Text));
                //cmd2.Parameters.AddWithValue("@pu_customer_contact", Convert.ToString(lbl_cutomer_contact.Value));
                //cmd2.Parameters.AddWithValue("@pu_customer_address", Convert.ToString(lbl_cutomer_address.Value));
                //cmd2.Parameters.AddWithValue("@pu_customer_gst_no", Convert.ToString(lbl_cutomer_gst_no.Value));

                //cmd2.Parameters.AddWithValue("@pu_order_no", Convert.ToString(Txt_order_no.Text));
                //cmd2.Parameters.AddWithValue("@pu_invoice_date", Txt_invoice_date.Text);
                //cmd2.Parameters.AddWithValue("@pu_due_date", Txt_due_date.Text);

                //cmd2.Parameters.AddWithValue("@pu_total_quantity", Convert.ToDecimal(lbl_totalqty.Text));

                //cmd2.Parameters.AddWithValue("@pu_discount", Convert.ToDecimal(Txt_discount.Text));


                //cmd2.Parameters.AddWithValue("@pu_sub_total", Convert.ToDecimal(lbl_subtotal.Text));
                //cmd2.Parameters.AddWithValue("@pu_total_gst", Convert.ToDecimal(lbl_gst.Text));
                //cmd2.Parameters.AddWithValue("@pu_shipping_charges", Convert.ToDecimal(Txt_shipping.Text));
                //cmd2.Parameters.AddWithValue("@pu_adjustment", Convert.ToDecimal(Txt_adjustment.Text));
                //cmd2.Parameters.AddWithValue("@pu_total", Convert.ToDecimal(hide_total.Text));
                //cmd2.Parameters.AddWithValue("@pu_total_cgst", Convert.ToDecimal(lbl_total_cgst.Value));
                //cmd2.Parameters.AddWithValue("@pu_total_sgst", Convert.ToDecimal(lbl_total_sgst.Value));
                //cmd2.Parameters.AddWithValue("@pu_total_igst", Convert.ToDecimal(lbl_total_igst.Value));
                //cmd2.Parameters.AddWithValue("@pu_total_taxable", Convert.ToDecimal(lbl_total_taxable.Value));
                //cmd2.Parameters.AddWithValue("@pu_balance", new_balance);
                conn.Open();
                cmd2.ExecuteNonQuery();
                conn.Close();

                Lbl_message.Text = "" + Dd_customer.Text + " Added Successfully!!!";


                SqlCommand cmd3 = new SqlCommand("update tbl_vendor set v_opening_balance=v_opening_balance + '" + rem + "' where v_id='" + Dd_customer.SelectedValue + "'", conn);

                conn.Open();
                cmd3.ExecuteNonQuery();

                conn.Close();
                Response.Redirect("roll_bill.aspx?invoice=" + Txt_invoice.Text + "&bill_update=success");
            }
            catch (Exception ex) { }
            
            //string redirectScript = " window.location.href = 'bill.aspx?invoice=" + Txt_invoice.Text + "';";
            //System.Web.UI.ScriptManager.RegisterStartupScript(this, GetType(), "displayalertmessage", "alert('Purchase Invoice Updated Successfully!!!');" + redirectScript, true);

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
        Dd_feet.SelectedValue = GridView1.SelectedRow.Cells[2].Text;
        Txt_roll_height.Text = GridView1.SelectedRow.Cells[3].Text;
        Txt_roll_size.Text = GridView1.SelectedRow.Cells[4].Text;
        Txt_total_roll.Text = GridView1.SelectedRow.Cells[5].Text;
        Txt_total_roll_sq.Text = GridView1.SelectedRow.Cells[6].Text;
        //txt_rate.Text = GridView1.SelectedRow.Cells[7].Text;
        txt_amount.Text = GridView1.SelectedRow.Cells[8].Text;
        //txt_quantity.Text = GridView1.SelectedRow.Cells[9].Text;
        //txt_total_amt.Text = GridView1.SelectedRow.Cells[10].Text;

        txt_final_amt.Text = GridView1.SelectedRow.Cells[14].Text;
        txt_cgst.Text = GridView1.SelectedRow.Cells[15].Text;
        txt_sgst.Text = GridView1.SelectedRow.Cells[16].Text;
        txt_igst.Text = GridView1.SelectedRow.Cells[17].Text;
        Txt_description.Text = GridView1.SelectedRow.Cells[18].Text;
        lbl_unit.Value = GridView1.SelectedRow.Cells[19].Text;
        lbl_id.Value = GridView1.SelectedRow.Cells[20].Text;
        
            Txt_rate.Text = GridView1.SelectedRow.Cells[7].Text;
            txt_quantity.Text = GridView1.SelectedRow.Cells[9].Text;
            txt_total_amt.Text = GridView1.SelectedRow.Cells[10].Text;
        

    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        
            decimal cgstamount = Convert.ToDecimal(txt_total_amt.Text) * Convert.ToDecimal(txt_cgst.Text) / 100;
            decimal sgstamount = Convert.ToDecimal(txt_total_amt.Text) * Convert.ToDecimal(txt_sgst.Text) / 100;
            decimal igstamount = Convert.ToDecimal(txt_total_amt.Text) * Convert.ToDecimal(txt_igst.Text) / 100;

            SqlCommand cmd6 = new SqlCommand("update tbl_temp_roll_purchase_invoice set rpc_product_name='" + Dd_enter_product.SelectedItem.Text + "',rpc_product_hsn='" + lbl_product_hsn.Value + "',rpc_heightft='" + Dd_feet.SelectedValue + "',rpc_heightmtr='" + Txt_roll_height.Text + "',rpc_roll_size='" + Txt_roll_size.Text + "',rpc_total_size='" + Txt_total_roll.Text + "',rpc_size='" + Txt_total_roll_sq.Text + "',rpc_rate='" + Txt_rate.Text + "',rpc_samount='" + txt_amount.Text + "',rpc_quantity='" + txt_quantity.Text + "',rpc_stotal='" + txt_total_amt.Text + "',rpc_cgsta='" + cgstamount + "',rpc_sgsta='" + sgstamount + "',rpc_igsta='" + igstamount + "',rpc_amount='" + txt_final_amt.Text + "',rpc_cgstp='" + txt_cgst.Text + "',rpc_sgstp='" + txt_sgst.Text + "',rpc_igstp='" + txt_igst.Text + "',rpc_desc='" + Txt_description.Text + "',rpc_unit='" + lbl_unit.Value + "' WHERE rpc_id='" + lbl_id.Value.Trim() + "'", conn);

            conn.Open();
            cmd6.ExecuteNonQuery();

            conn.Close();
            FillGRid();
        
    }

    protected void Button2_Click(object sender, EventArgs e)
    {
        int i = Convert.ToInt32(GridView1.SelectedRow.Cells[18].Text);

        SqlCommand cmd = new SqlCommand("Delete from tbl_temp_roll_purchase_invoice where rpc_id='" + i + "'", conn);
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
        Dd_feet.SelectedValue = "--Select---";
        Txt_roll_height.Text = "";
        Txt_roll_size.Text = "";
        Txt_total_roll.Text = "";
        Txt_total_roll_sq.Text = "";
        Txt_rate.Text = "";
        txt_amount.Text = "";
        txt_quantity.Text = "";
        txt_total_amt.Text = "";

        txt_final_amt.Text = "";
        txt_cgst.Text = "";
        txt_sgst.Text = "";
        txt_igst.Text = "";
        Txt_description.Text = "";
        lbl_unit.Value = "";
        lbl_id.Value = "";
    }
}