﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using System.Data.Common.CommandTrees.ExpressionBuilder;
using System.Activities.Statements;

public partial class admin_panel_Sale_edit_bill : System.Web.UI.Page
{
    SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["String"].ConnectionString);
    decimal total_amount = 0, final_total = 0;
    decimal dPageTotal, finaltotal, quantity1, quantity2, StockQuantity;
    decimal totalvalue, totalcgst, totalsgst, totaligst, totalgst, totalqty, totaltaxable, Old_total, old_balance, paid, new_balance, new_total, rem, design, advanced, discount, pasting, fitting, transport, framing, installation;
    string invoice, Productname, Productname2;
    int id;
    string admin_email, order = "", material2 = "", materialId, materialId2;

    string EditQuantity;

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
                    this.GetData();
                    this.Order_reference1(order);
                    //this.material1(material2);
                    this.material();

                    Btn_cart.Visible = false;
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

    public void Order_reference()
    {
        string query = "select st_staff_name as s_order_ref ,st_id from tbl_staff order by st_id desc";
        SqlDataAdapter adapt = new SqlDataAdapter(query, conn);
        DataTable dt = new DataTable();
        adapt.Fill(dt);
        if (dt.Rows.Count > 0)
        {
            drp_designer.DataSource = dt;

            drp_designer.DataTextField = "s_order_ref";
            drp_designer.DataValueField = "st_id";
            drp_designer.DataBind();
            drp_designer.Items.Insert(0, new ListItem("--Select Designer--", "--Select Designer--"));
            drp_designer.SelectedItem.Selected = false;
            drp_designer.Items.FindByText("--Select Designer--").Selected = true;
        }

    }
    public void Order_reference1(string st_staff_name)
    {
        if (st_staff_name == "")
        {
            Order_reference();
        }
        else
        {
            SqlCommand cmd = new SqlCommand("select st_staff_name as s_order_ref,st_id from tbl_staff where st_staff_name !=@st_staff_name", conn);
            cmd.Parameters.Add("@st_staff_name", st_staff_name);
            SqlDataAdapter adapt = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapt.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                drp_designer.DataTextField = "s_order_ref";
                drp_designer.DataValueField = "st_id";
                drp_designer.DataSource = dt;

                drp_designer.DataBind();



                drp_designer.SelectedItem.Text = st_staff_name;
            }
        }

    }
    public void material()
    {
        string query = "select p_name ,p_id  as s_material from tbl_purchase_product Order By p_name asc";


        SqlDataAdapter adapt5 = new SqlDataAdapter(query, conn);
        DataTable dt6 = new DataTable();
        adapt5.Fill(dt6);
        if (dt6.Rows.Count > 0)
        {
            Dd_material.DataSource = dt6;

            Dd_material.DataTextField = "p_name";

            Dd_material.DataValueField = "s_material";
            Dd_material.DataBind();
            Dd_material.Items.Insert(0, new ListItem("--Select--", "--Select--"));
            Dd_material.SelectedItem.Selected = false;
            Dd_material.Items.FindByText("--Select--").Selected = true;
        }

    }
    //public void material1(string material3)
    //{
    //    if (material3 == "")
    //    {
    //        material();
    //    }
    //    else
    //    {

    //        SqlCommand cmd = new SqlCommand("select p_name ,p_id  as s_material from tbl_purchase_product where p_id!=@s_material", conn);

    //        cmd.Parameters.Add("@s_material", material3);
    //        SqlDataAdapter adapt5 = new SqlDataAdapter(cmd);
    //        DataTable dt6 = new DataTable();
    //        adapt5.Fill(dt6);
    //        if (dt6.Rows.Count > 0)
    //        {

    //            Dd_material.DataSource = dt6;
    //            Dd_material.DataBind();
    //            Dd_material.DataTextField = "p_name";

    //            Dd_material.DataValueField = "s_material";
    //            Dd_material.SelectedItem.Value = material3;
    //            // Dd_material.SelectedItem.Text = p_name;
    //            SqlCommand cmd2 = new SqlCommand("select p_name ,p_id  as s_material from tbl_purchase_product where p_id=@s_material", conn);

    //            cmd2.Parameters.Add("@s_material", material3);
    //            SqlDataAdapter adapt6 = new SqlDataAdapter(cmd2);
    //            DataTable dt7 = new DataTable();
    //            adapt6.Fill(dt7);
    //            if (dt7.Rows.Count > 0)
    //            {
    //                Dd_material.SelectedItem.Text = dt7.Rows[0]["p_name"].ToString();

    //            }
    //                //Dd_material.Items.Insert(0, new ListItem("--Select--", "--Select--"));
    //                //Dd_material.SelectedItem.Selected = false;
    //                //Dd_material.Items.FindByText("--Select--").Selected = true;

    //            }
    //        }

    //}

    protected void GetData()
    {

        SqlCommand cmd = new SqlCommand("select * from tbl_sale_invoice where s_invoice_no='" + invoice + "'", conn);
        SqlDataAdapter adapt = new SqlDataAdapter(cmd);
        DataTable dt = new DataTable();
        adapt.Fill(dt);
        if (dt.Rows.Count > 0)
        {
            id = Convert.ToInt32(dt.Rows[0]["s_id"]);
            Dd_customer.SelectedValue = dt.Rows[0]["c_id"].ToString();
            Txt_invoice.Text = dt.Rows[0]["s_invoice_no"].ToString();
            Txt_order_no.Text = dt.Rows[0]["s_order_no"].ToString();
            material2 = dt.Rows[0]["s_material"].ToString();
            lbl_date.Value = Convert.ToDateTime(dt.Rows[0]["s_date"]).ToString("MM/dd/yyyy");
            Txt_invoice_date.Text = Convert.ToDateTime(dt.Rows[0]["s_invoice_date"]).ToString("MM/dd/yyyy");
            Txt_due_date.Text = Convert.ToDateTime(dt.Rows[0]["s_due_date"]).ToString("MM/dd/yyyy");
            //lbl_totalqty.Text = dt.Rows[0]["s_total_quantity"].ToString();

            order = dt.Rows[0]["s_order_ref"].ToString();
            //Order_reference();
            // 
            //drp_designer.SelectedItem.Text = dt.Rows[0]["s_order_ref"].ToString();
            Order_reference1(order);
            //material1(material2);
            lbl_subtotal.Text = dt.Rows[0]["s_sub_total"].ToString();
            lbl_subtotal2.Value = dt.Rows[0]["s_sub_total"].ToString();
            lbl_gst.Text = dt.Rows[0]["s_total_gst"].ToString();
            Txt_TransportCharges.Text = dt.Rows[0]["s_shipping_charges"].ToString();
            Txt_advance.Text = dt.Rows[0]["s_adjustment"].ToString();
            Txt_discount.Text = dt.Rows[0]["s_discount"].ToString();
            txt_UPIno.Text = dt.Rows[0]["s_upichqno"].ToString();

            lbl_total.Text = dt.Rows[0]["s_total"].ToString();
            hide_total.Text = dt.Rows[0]["s_total"].ToString();
            lbl_balance.Value = dt.Rows[0]["s_balance"].ToString();
            Txt_Dtp_charges.Text = dt.Rows[0]["s_dtp_charges"].ToString();
            Txt_Fitting.Text = dt.Rows[0]["s_fitting_charges"].ToString();
            Txt_Pasting.Text = dt.Rows[0]["s_pasting_charges"].ToString();
            drp_payment.SelectedValue = dt.Rows[0]["s_payment_method"].ToString();
            lbl_final.Text = dt.Rows[0]["s_total"].ToString();
            Txt_Framing.Text = dt.Rows[0]["s_framing_charges"].ToString();
            Txt_install.Text = dt.Rows[0]["s_installation_charges"].ToString();

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
            SqlCommand cmd = new SqlCommand("delete from tbl_temp_sale_invoice", conn);
            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();

            if (conn.State != ConnectionState.Closed)
            {
                conn.Close();
            }
            SqlCommand cmd2 = new SqlCommand("insert into tbl_temp_sale_invoice select s_invoice_no,s_date,c_id,s_order_no,s_invoice_date,s_due_date,s_product_name,s_quantity,s_total_quantity,s_rate,s_discount,s_cgstp,s_cgsta,s_sgstp,s_sgsta,s_igstp,s_igsta,s_amount,s_sub_total,s_total_gst,s_shipping_charges,s_adjustment,s_total,s_stotal,s_product_hsn,s_unit,s_desc,s_height,s_width,s_size,s_samount,s_total_cgst,s_total_sgst,s_total_igst,s_total_taxable,s_balance,s_material from tbl_sale_invoice where s_invoice_no='" + invoice + "'", conn);
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








            SqlCommand cmd = new SqlCommand("select s_product_name as Product,s_product_hsn as HSN,s_height as Height,s_width as Width,s_size as SQRFT,s_rate as Rate,s_samount as Amount,s_quantity as Qty,s_stotal as Total,s_cgsta as CGST,s_sgsta as SGST,s_igsta as IGST,s_amount as FINAL,s_cgstp as cgstp,s_sgstp as sgstp,s_igstp as igstp,s_desc as [desc],s_unit as unit,s_id as[ID],s_material as[MaterialId] from tbl_temp_sale_invoice where s_invoice_no='" + invoice + "'", conn);
            SqlDataAdapter adapt = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapt.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                GridView1.Visible = true;
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


                pasting = Convert.ToDecimal(Txt_Pasting.Text);
                transport = Convert.ToDecimal(Txt_TransportCharges.Text);
                design = Convert.ToDecimal(Txt_Dtp_charges.Text);
                fitting = Convert.ToDecimal(Txt_Fitting.Text);
                framing = Convert.ToDecimal(Txt_Framing.Text);
                installation = Convert.ToDecimal(Txt_install.Text);

                discount = Convert.ToDecimal(Txt_discount.Text);
                advanced = Convert.ToDecimal(Txt_advance.Text);

                decimal total1 = (totalvalue + pasting + transport + design + fitting + framing + installation - discount - advanced);
                decimal final = (totalvalue + pasting + transport + design + fitting + framing + installation);
                lbl_final.Text = final.ToString();
                lbl_total.Text = total1.ToString();
                hide_total.Text = final.ToString();
                //Assign the total value to footer label control
                lbl_gst.Text = totalgst.ToString();
                lbl_totalqty.Text = totalqty.ToString();
                lbl_total_cgst.Value = totalcgst.ToString();
                lbl_total_sgst.Value = totalsgst.ToString();
                lbl_total_igst.Value = totaligst.ToString();
                lbl_total_taxable.Value = totaltaxable.ToString();

                product();
                material();
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
                lbl_available.Text = "";
                GridView1.Visible = true;

            }
            else
            {
                GridView1.DataSource = null;
                GridView1.DataBind();
                GridView1.Visible = false;
                lbl_total.Text = "0";
                hide_total.Text = "0";
                lbl_subtotal.Text = "0";
                lbl_subtotal2.Value = "0";
                lbl_gst.Text = "0";

                lbl_totalqty.Text = "0";
                //Dd_enter_product.SelectedValue = "--Slect--";
                product();
                material();
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

                Txt_Dtp_charges.Text = "0";
                Txt_Fitting.Text = "0";
                Txt_Framing.Text = "0";
                Txt_install.Text = "0";
                Txt_Pasting.Text = "0";
                Txt_TransportCharges.Text = "0";



                lbl_subtotal.Text = "0";
                lbl_subtotal2.Value = "0";

                Txt_advance.Text = "0";
                Txt_discount.Text = "0";

                lbl_gst.Text = "0";
                // lbl_gst2.Value = "0";
                lbl_total.Text = "0";

                lbl_final.Text = "0";
                hide_total.Text = "0";
                lbl_available.Text = "";
                GridView1.Visible = false;
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
        // GetData();
        GridView1.Visible = true;
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
                SqlCommand cmd = new SqlCommand("insert into tbl_temp_sale_invoice values(@s_invoice_no,@s_date,@c_id,@s_order_no,@s_invoice_date,@s_due_date,@s_product_name,@s_quantity,@s_total_quantity,@s_rate,@s_discount,@s_cgstp,@s_cgsta,@s_sgstp,@s_sgsta,@s_igstp,@s_igsta,@s_amount,@s_sub_total,@s_total_gst,@s_shipping_charges,@s_adjustment,@s_total,@s_stotal,@s_hsn,@s_unit,@s_desc,@s_height,@s_width,@s_size,@s_samount,@s_total_cgst,@s_total_sgst,@s_total_igst,@s_total_taxable,@s_balance,@s_material)", conn);

                cmd.Parameters.AddWithValue("@s_invoice_no", Convert.ToString(Txt_invoice.Text));
                cmd.Parameters.AddWithValue("@s_date", DateTime.Now.ToShortDateString());
                cmd.Parameters.AddWithValue("@c_id", Convert.ToString(Dd_customer.SelectedValue));
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
                cmd.Parameters.AddWithValue("@s_total_cgst", Convert.ToDecimal(lbl_total_cgst.Value));
                cmd.Parameters.AddWithValue("@s_total_sgst", Convert.ToDecimal(lbl_total_sgst.Value));
                cmd.Parameters.AddWithValue("@s_total_igst", Convert.ToDecimal(lbl_total_igst.Value));
                cmd.Parameters.AddWithValue("@s_total_taxable", Convert.ToDecimal(lbl_total_taxable.Value));
                cmd.Parameters.AddWithValue("@s_balance", Convert.ToDecimal(lbl_balance.Value));
                cmd.Parameters.AddWithValue("@s_material", Convert.ToString(Dd_material.SelectedValue));

                //if (Txt_Dtp_charges.Text == "")
                //{
                //    cmd.Parameters.AddWithValue("@s_dtp_charges", "0");
                //}
                //else
                //{
                //    cmd.Parameters.AddWithValue("@s_dtp_charges", Convert.ToDecimal(Txt_Dtp_charges.Text));
                //}
                //if (Txt_Fitting.Text == "")
                //{
                //    cmd.Parameters.AddWithValue("@s_fitting_charges", "0");
                //}
                //else
                //{
                //    cmd.Parameters.AddWithValue("@s_fitting_charges", Convert.ToDecimal(Txt_Fitting.Text));
                //}
                //cmd.Parameters.AddWithValue("@drp_designer", Convert.ToString(drp_designer.SelectedItem.Text));
                //cmd.Parameters.AddWithValue("@s_payment_method", Convert.ToString(drp_payment.SelectedItem.Text));
                //if (Txt_Framing.Text == "")
                //{
                //    cmd.Parameters.AddWithValue("@s_fitting_framing_charges", "0");
                //}
                //else
                //{
                //    cmd.Parameters.AddWithValue("@s_fitting_framing_charges", Convert.ToDecimal(Txt_Framing.Text));
                //}
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

            decimal cgstamount = Convert.ToDecimal(total2) * Convert.ToDecimal(cgst) / 100;
            decimal sgstamount = Convert.ToDecimal(total2) * Convert.ToDecimal(sgst) / 100;
            decimal igstamount = Convert.ToDecimal(total2) * Convert.ToDecimal(igst) / 100;


            try
            {
                SqlCommand cmd = new SqlCommand("insert into tbl_temp_sale_invoice values(@s_invoice_no,@s_date,@c_id,@s_order_no,@s_invoice_date,@s_due_date,@s_product_name,@s_quantity,@s_total_quantity,@s_rate,@s_discount,@s_cgstp,@s_cgsta,@s_sgstp,@s_sgsta,@s_igstp,@s_igsta,@s_amount,@s_sub_total,@s_total_gst,@s_shipping_charges,@s_adjustment,@s_total,@s_stotal,@s_hsn,@s_unit,@s_desc,@s_height,@s_width,@s_size,@s_samount,@s_total_cgst,@s_total_sgst,@s_total_igst,@s_total_taxable,@s_balance,@s_material)", conn);

                cmd.Parameters.AddWithValue("@s_invoice_no", Convert.ToString(Txt_invoice.Text));
                cmd.Parameters.AddWithValue("@s_date", DateTime.Now.ToShortDateString());
                cmd.Parameters.AddWithValue("@c_id", Convert.ToString(Dd_customer.SelectedValue));
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
                cmd.Parameters.AddWithValue("@s_total_cgst", Convert.ToDecimal(lbl_total_cgst.Value));
                cmd.Parameters.AddWithValue("@s_total_sgst", Convert.ToDecimal(lbl_total_sgst.Value));
                cmd.Parameters.AddWithValue("@s_total_igst", Convert.ToDecimal(lbl_total_igst.Value));
                cmd.Parameters.AddWithValue("@s_total_taxable", Convert.ToDecimal(lbl_total_taxable.Value));
                cmd.Parameters.AddWithValue("@s_balance", Convert.ToDecimal(lbl_balance.Value));
                cmd.Parameters.AddWithValue("@s_material", Convert.ToString(Dd_material.SelectedValue));
                //if (Txt_Dtp_charges.Text == "")
                //{
                //    cmd.Parameters.AddWithValue("@s_dtp_charges", "0");
                //}
                //else
                //{
                //    cmd.Parameters.AddWithValue("@s_dtp_charges", Convert.ToDecimal(Txt_Dtp_charges.Text));
                //}
                //if (Txt_Fitting.Text == "")
                //{
                //    cmd.Parameters.AddWithValue("@s_fitting_charges", "0");
                //}
                //else
                //{
                //    cmd.Parameters.AddWithValue("@s_fitting_charges", Convert.ToDecimal(Txt_Fitting.Text));
                //}
                //if (Txt_Framing.Text == "")
                //{
                //    cmd.Parameters.AddWithValue("@s_fitting_framing_charges", "0");
                //}
                //else
                //{
                //    cmd.Parameters.AddWithValue("@s_fitting_framing_charges", Convert.ToDecimal(Txt_Framing.Text));
                //}
                //cmd.Parameters.AddWithValue("@drp_designer", Convert.ToString(drp_designer.SelectedItem.Text));
                //cmd.Parameters.AddWithValue("@s_payment_method", Convert.ToString(drp_payment.SelectedItem.Text));
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
                SqlCommand cmd = new SqlCommand("insert into tbl_temp_sale_invoice values(@s_invoice_no,@s_date,@c_id,@s_order_no,@s_invoice_date,@s_due_date,@s_product_name,@s_quantity,@s_total_quantity,@s_rate,@s_discount,@s_cgstp,@s_cgsta,@s_sgstp,@s_sgsta,@s_igstp,@s_igsta,@s_amount,@s_sub_total,@s_total_gst,@s_shipping_charges,@s_adjustment,@s_total,@s_stotal,@s_hsn,@s_unit,@s_desc,@s_height,@s_width,@s_size,@s_samount,@s_total_cgst,@s_total_sgst,@s_total_igst,@s_total_taxable,@s_balance,@s_material)", conn);

                cmd.Parameters.AddWithValue("@s_invoice_no", Convert.ToString(Txt_invoice.Text));
                cmd.Parameters.AddWithValue("@s_date", DateTime.Now.ToShortDateString());
                cmd.Parameters.AddWithValue("@c_id", Convert.ToString(Dd_customer.SelectedValue));
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
                cmd.Parameters.AddWithValue("@s_shipping_charges", Convert.ToDecimal(Txt_TransportCharges.Text));
                cmd.Parameters.AddWithValue("@s_adjustment", Convert.ToDecimal(Txt_advance.Text));
                cmd.Parameters.AddWithValue("@s_total", Convert.ToDecimal(hide_total.Text));
                cmd.Parameters.AddWithValue("@s_stotal", Convert.ToDecimal(txt_total_amt.Text));
                cmd.Parameters.AddWithValue("@s_hsn", Convert.ToString(lbl_product_hsn.Value));
                cmd.Parameters.AddWithValue("@s_desc", Convert.ToString(Txt_description.Text));
                cmd.Parameters.AddWithValue("@s_height", Convert.ToDecimal(txt_height.Text));
                cmd.Parameters.AddWithValue("@s_width", Convert.ToDecimal(txt_width.Text));
                cmd.Parameters.AddWithValue("@s_size", Convert.ToDecimal(txt_sqrft.Text));
                cmd.Parameters.AddWithValue("@s_samount", Convert.ToDecimal(txt_amount.Text));
                cmd.Parameters.AddWithValue("@s_total_cgst", Convert.ToDecimal(lbl_total_cgst.Value));
                cmd.Parameters.AddWithValue("@s_total_sgst", Convert.ToDecimal(lbl_total_sgst.Value));
                cmd.Parameters.AddWithValue("@s_total_igst", Convert.ToDecimal(lbl_total_igst.Value));
                cmd.Parameters.AddWithValue("@s_total_taxable", Convert.ToDecimal(lbl_total_taxable.Value));
                cmd.Parameters.AddWithValue("@s_balance", Convert.ToDecimal(lbl_balance.Value));
                cmd.Parameters.AddWithValue("@s_material", Convert.ToString(Dd_material.SelectedValue));
                //if (Txt_Dtp_charges.Text == "")
                //{
                //    cmd.Parameters.AddWithValue("@s_dtp_charges", "0");
                //}
                //else
                //{
                //    cmd.Parameters.AddWithValue("@s_dtp_charges", Convert.ToDecimal(Txt_Dtp_charges.Text));
                //}
                //if (Txt_Fitting.Text == "")
                //{
                //    cmd.Parameters.AddWithValue("@s_fitting_charges", "0");
                //}
                //else
                //{
                //    cmd.Parameters.AddWithValue("@s_fitting_charges", Convert.ToDecimal(Txt_Fitting.Text));
                //}
                //if (Txt_Framing.Text == "")
                //{
                //    cmd.Parameters.AddWithValue("@s_fitting_framing_charges", "0");
                //}
                //else
                //{
                //    cmd.Parameters.AddWithValue("@s_fitting_framing_charges", Convert.ToDecimal(Txt_Framing.Text));
                //}
                //cmd.Parameters.AddWithValue("@drp_designer", Convert.ToString(drp_designer.SelectedItem.Text));
                //cmd.Parameters.AddWithValue("@s_payment_method", Convert.ToString(drp_payment.SelectedItem.Text));

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
            e.Row.Cells[19].Visible = false;
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
                txt_quantity2.Text = "0";
                txt_sqrft2.Text = "0";
                txt_width2.Text = "0";

                txt_height2.Text = "0";
            }
            else if (unit == "Ltr")
            {
                Panel1.Visible = false;
                Panel2.Visible = true;
                txt_rate2.Text = rate;
                txt_quantity2.Text = "0";
                txt_sqrft2.Text = "0";
                txt_width2.Text = "0";

                txt_height2.Text = "0";
            }
            //packet
            else if (unit == "Packet")
            {
                Panel1.Visible = false;
                Panel2.Visible = true;
                txt_rate2.Text = rate;
                txt_quantity2.Text = "0";
                txt_sqrft2.Text = "0";
                txt_width2.Text = "0";

                txt_height2.Text = "0";
            }
            //copy
            else if (unit == "Copy")
            {
                Panel1.Visible = false;
                Panel2.Visible = true;
                txt_rate2.Text = rate;
                txt_quantity2.Text = "0";
                txt_sqrft2.Text = "0";
                txt_width2.Text = "0";

                txt_height2.Text = "0";
            }


            else
            {
                Panel1.Visible = true;
                Panel2.Visible = false;
                txt_rate.Text = rate;
                txt_quantity.Text = "0";
                txt_width.Text = "0";
                txt_height.Text = "0";
                txt_quantity.Text = "0";
                txt_sqrft.Text = "0";
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
                //SqlCommand cmd4 = new SqlCommand("select * from tbl_sale_invoice where s_invoice_no='" + invoice + "'", conn);
                //SqlDataAdapter adapt4 = new SqlDataAdapter(cmd4);
                //DataTable dt4 = new DataTable();
                //adapt4.Fill(dt4);
                //if (dt4.Rows.Count > 0)
                //{
                //    Old_total = Convert.ToDecimal(dt4.Rows[0]["s_total"]);
                //    old_balance = Convert.ToDecimal(dt4.Rows[0]["s_balance"]);
                //    paid = Old_total - old_balance;
                //    new_total = Convert.ToDecimal(hide_total.Text);
                //    new_balance = new_total - paid;
                //    rem = new_total - Old_total;
                //}
                //int k= 0;




                SqlCommand cmd55 = new SqlCommand("select * FROM tbl_sale_invoice Where s_invoice_no='" + invoice + "'", conn);
                SqlDataAdapter adapt55 = new SqlDataAdapter(cmd55);
                DataTable dt55 = new DataTable();
                adapt55.Fill(dt55);
                int dtRowCount = dt55.Rows.Count;
                int gridRowCount = GridView1.Rows.Count;
                if (dt55.Rows.Count > 0)
                {


                    for (int dtRow = 0; dtRow < dt55.Rows.Count; dtRow++)
                    {
                        string s_quantity = dt55.Rows[dtRow]["s_quantity"].ToString();
                        quantity1 = Convert.ToDecimal(s_quantity);
                        Productname = dt55.Rows[dtRow]["s_product_name"].ToString();
                        materialId = dt55.Rows[dtRow]["s_material"].ToString();
                        int rowscount1 = GridView1.Rows.Count;


                        if (dtRow < rowscount1)
                        {
                            Productname2 = Convert.ToString(GridView1.Rows[dtRow].Cells[0].Text);
                            materialId2 = Convert.ToString(GridView1.Rows[dtRow].Cells[19].Text);
                            quantity2 = Convert.ToDecimal(GridView1.Rows[dtRow].Cells[7].Text);

                            if (materialId == materialId2 && Productname == Productname2)
                            {
                                if (quantity1 != quantity2)
                                {
                                    if (quantity1 > quantity2)
                                    {
                                        StockQuantity = quantity1 - quantity2;
                                        SqlCommand cmd33 = new SqlCommand("UPDATE tbl_purchase_product SET p_stock=p_stock+('" + StockQuantity + "') WHERE p_id='" + Convert.ToString(GridView1.Rows[dtRow].Cells[19].Text) + "'", conn);

                                        conn.Open();
                                        cmd33.ExecuteNonQuery();
                                        conn.Close();

                                        SqlCommand cmd45 = new SqlCommand("insert into tbl_used_stock values(@p_name,@date,@sqrft,@quantity)", conn);
                                        cmd45.Parameters.AddWithValue("@p_name", Convert.ToString(GridView1.Rows[dtRow].Cells[0].Text));
                                        cmd45.Parameters.AddWithValue("@date", Convert.ToDateTime(Txt_invoice_date.Text).ToString("MM/dd/yyyy"));
                                        cmd45.Parameters.AddWithValue("@sqrft", StockQuantity);
                                        cmd45.Parameters.AddWithValue("@quantity", StockQuantity);

                                        conn.Open();
                                        cmd45.ExecuteNonQuery();
                                        conn.Close();


                                    }

                                    else if (quantity1 < quantity2)
                                    {
                                        StockQuantity = quantity2 - quantity1;

                                        SqlCommand cmd33 = new SqlCommand("UPDATE tbl_purchase_product SET p_stock=p_stock-('" + StockQuantity + "') WHERE p_id='" + Convert.ToString(GridView1.Rows[dtRow].Cells[19].Text) + "'", conn);

                                        conn.Open();
                                        cmd33.ExecuteNonQuery();
                                        conn.Close();

                                        decimal QuantityUsedStock = -StockQuantity;
                                        SqlCommand cmd45 = new SqlCommand("insert into tbl_used_stock values(@p_name,@date,@sqrft,@quantity)", conn);
                                        cmd45.Parameters.AddWithValue("@p_name", Convert.ToString(GridView1.Rows[dtRow].Cells[0].Text));
                                        cmd45.Parameters.AddWithValue("@date", Convert.ToDateTime(Txt_invoice_date.Text).ToString("MM/dd/yyyy"));
                                        cmd45.Parameters.AddWithValue("@sqrft", quantity2);
                                        cmd45.Parameters.AddWithValue("@quantity", StockQuantity);

                                        conn.Open();
                                        cmd45.ExecuteNonQuery();
                                        conn.Close();

                                    }



                                }


                            }

                            if (materialId == materialId2 && Productname != Productname2)
                            {


                                decimal QuantityUsedStock = -quantity1;

                                SqlCommand cmd45 = new SqlCommand("insert into tbl_used_stock values(@p_name,@date,@sqrft,@quantity)", conn);
                                cmd45.Parameters.AddWithValue("@p_name", Productname);
                                cmd45.Parameters.AddWithValue("@date", Convert.ToDateTime(Txt_invoice_date.Text).ToString("MM/dd/yyyy"));
                                cmd45.Parameters.AddWithValue("@sqrft", StockQuantity);
                                cmd45.Parameters.AddWithValue("@quantity", QuantityUsedStock);

                                conn.Open();
                                cmd45.ExecuteNonQuery();
                                conn.Close();


                                SqlCommand cmd46 = new SqlCommand("insert into tbl_used_stock values(@p_name,@date,@sqrft,@quantity)", conn);
                                cmd46.Parameters.AddWithValue("@p_name", Productname2);
                                cmd46.Parameters.AddWithValue("@date", Convert.ToDateTime(Txt_invoice_date.Text).ToString("MM/dd/yyyy"));
                                cmd46.Parameters.AddWithValue("@sqrft", StockQuantity);
                                cmd46.Parameters.AddWithValue("@quantity", quantity2);

                                conn.Open();
                                cmd46.ExecuteNonQuery();
                                conn.Close();


                                


                            }

                            if (materialId != materialId2 && Productname == Productname2)
                            {

                                SqlCommand cmd33 = new SqlCommand("UPDATE tbl_purchase_product SET p_stock=p_stock+('" + quantity1 + "') WHERE p_id='" + materialId + "'", conn);

                                conn.Open();
                                cmd33.ExecuteNonQuery();
                                conn.Close();


                                SqlCommand cmd34 = new SqlCommand("UPDATE tbl_purchase_product SET p_stock=p_stock-('" + quantity2 + "') WHERE p_id='" + Convert.ToString(GridView1.Rows[dtRow].Cells[19].Text) + "'", conn);

                                conn.Open();
                                cmd34.ExecuteNonQuery();
                                conn.Close();

                            }

                            if (materialId != materialId2 && Productname != Productname2)
                            {


                                SqlCommand cmd33 = new SqlCommand("UPDATE tbl_purchase_product SET p_stock=p_stock+('" + quantity1 + "') WHERE p_id='" + materialId + "'", conn);

                                conn.Open();
                                cmd33.ExecuteNonQuery();
                                conn.Close();


                                SqlCommand cmd34 = new SqlCommand("UPDATE tbl_purchase_product SET p_stock=p_stock-('" + quantity2 + "') WHERE p_id='" + Convert.ToString(GridView1.Rows[dtRow].Cells[19].Text) + "'", conn);

                                conn.Open();
                                cmd34.ExecuteNonQuery();
                                conn.Close();

                                decimal QuantityUsedStock = -quantity1;

                                SqlCommand cmd45 = new SqlCommand("insert into tbl_used_stock values(@p_name,@date,@sqrft,@quantity)", conn);
                                cmd45.Parameters.AddWithValue("@p_name", Productname);
                                cmd45.Parameters.AddWithValue("@date", Convert.ToDateTime(Txt_invoice_date.Text).ToString("MM/dd/yyyy"));
                                cmd45.Parameters.AddWithValue("@sqrft", StockQuantity);
                                cmd45.Parameters.AddWithValue("@quantity", QuantityUsedStock);

                                conn.Open();
                                cmd45.ExecuteNonQuery();
                                conn.Close();


                                SqlCommand cmd46 = new SqlCommand("insert into tbl_used_stock values(@p_name,@date,@sqrft,@quantity)", conn);
                                cmd46.Parameters.AddWithValue("@p_name", Productname2);
                                cmd46.Parameters.AddWithValue("@date", Convert.ToDateTime(Txt_invoice_date.Text).ToString("MM/dd/yyyy"));
                                cmd46.Parameters.AddWithValue("@sqrft", StockQuantity);
                                cmd46.Parameters.AddWithValue("@quantity", quantity2);

                                conn.Open();
                                cmd46.ExecuteNonQuery();
                                conn.Close();








                            }

                            //else 
                            //{


                            //    SqlCommand cmd33 = new SqlCommand("UPDATE tbl_purchase_product SET p_stock=p_stock-('" + quantity2 + "') WHERE p_id='" + Convert.ToString(GridView1.Rows[dtRow].Cells[19].Text) + "'", conn);

                            //    conn.Open();
                            //    cmd33.ExecuteNonQuery();
                            //    conn.Close();


                            //    SqlCommand cmd44 = new SqlCommand("insert into tbl_used_stock values(@p_name,@date,@sqrft,@quantity)", conn);
                            //    cmd44.Parameters.AddWithValue("@p_name", Convert.ToString(GridView1.Rows[dtRow].Cells[0].Text));
                            //    cmd44.Parameters.AddWithValue("@date", Convert.ToDateTime(Txt_invoice_date.Text).ToString("MM/dd/yyyy"));
                            //    cmd44.Parameters.AddWithValue("@sqrft", quantity2);
                            //    cmd44.Parameters.AddWithValue("@quantity", quantity2);

                            //    conn.Open();
                            //    cmd44.ExecuteNonQuery();
                            //    conn.Close();

                            //}
                        }





                    }





                }



                finaltotal = Math.Round(Convert.ToDecimal(hide_total.Text));
                new_balance = finaltotal - Convert.ToDecimal(Txt_advance.Text) - Convert.ToDecimal(Txt_discount.Text);


                SqlCommand cmd5 = new SqlCommand("DELETE FROM tbl_sale_invoice Where s_invoice_no='" + invoice + "'", conn);
                conn.Open();
                cmd5.ExecuteNonQuery();
                conn.Close();

                int rowscount = GridView1.Rows.Count;
                for (int i = 0; i < rowscount; i++)
                {


                    SqlCommand cmd = new SqlCommand("insert into tbl_sale_invoice values(@s_invoice_no,@s_date,@c_id,@s_order_no,@s_invoice_date,@s_due_date,@s_product_name,@s_quantity,@s_total_quantity,@s_rate,@s_discount,@s_cgstp,@s_cgsta,@s_sgstp,@s_sgsta,@s_igstp,@s_igsta,@s_amount,@s_sub_total,@s_total_gst,@s_shipping_charges,@s_adjustment,@s_total,@s_stotal,@s_hsn,@s_unit,@s_desc,@s_height,@s_width,@s_size,@s_samount,@s_total_cgst,@s_total_sgst,@s_total_igst,@s_total_taxable,@s_balance,@s_dtp_charges,@s_fitting_charges,@s_payment_method,@drp_designer,@s_transaction_type,@s_cess,@s_material,@s_pasting_charges,@s_framing_charges,@s_installation_charges,@s_upichqno)", conn);
                    cmd.Parameters.AddWithValue("@s_invoice_no", Convert.ToString(Txt_invoice.Text));
                    cmd.Parameters.AddWithValue("@s_date", lbl_date.Value.ToString());
                    cmd.Parameters.AddWithValue("@c_id", Convert.ToString(Dd_customer.SelectedValue));
                    cmd.Parameters.AddWithValue("@s_order_no", Convert.ToString(Txt_order_no.Text));
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

                    if (Txt_TransportCharges.Text == "")
                    {
                        cmd.Parameters.AddWithValue("@s_shipping_charges", "0");
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@s_shipping_charges", Convert.ToDecimal(Txt_TransportCharges.Text));
                    }

                    cmd.Parameters.AddWithValue("@s_adjustment", Convert.ToDecimal(Txt_advance.Text));
                    cmd.Parameters.AddWithValue("@s_total", Convert.ToDecimal(hide_total.Text));
                    cmd.Parameters.AddWithValue("@s_stotal", Convert.ToDecimal(GridView1.Rows[i].Cells[8].Text));
                    if (GridView1.Rows[i].Cells[1].Text.Trim() == "&amp;nbsp;")
                    {
                        cmd.Parameters.AddWithValue("@s_hsn", "");
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@s_hsn", Convert.ToString(GridView1.Rows[i].Cells[1].Text.Trim()));
                    }
                    if (GridView1.Rows[i].Cells[16].Text.Trim() == "&amp;nbsp;")
                    {
                        cmd.Parameters.AddWithValue("@s_desc", "");
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@s_desc", Convert.ToString(GridView1.Rows[i].Cells[16].Text.Trim()));
                    }
                    cmd.Parameters.AddWithValue("@s_height", Convert.ToDecimal(GridView1.Rows[i].Cells[2].Text));
                    cmd.Parameters.AddWithValue("@s_width", Convert.ToDecimal(GridView1.Rows[i].Cells[3].Text));
                    cmd.Parameters.AddWithValue("@s_size", Convert.ToDecimal(GridView1.Rows[i].Cells[4].Text));
                    cmd.Parameters.AddWithValue("@s_samount", Convert.ToDecimal(GridView1.Rows[i].Cells[6].Text));
                    cmd.Parameters.AddWithValue("@s_total_cgst", Convert.ToDecimal(lbl_total_cgst.Value));
                    cmd.Parameters.AddWithValue("@s_total_sgst", Convert.ToDecimal(lbl_total_sgst.Value));
                    cmd.Parameters.AddWithValue("@s_total_igst", Convert.ToDecimal(lbl_total_igst.Value));
                    cmd.Parameters.AddWithValue("@s_total_taxable", Convert.ToDecimal(lbl_total_taxable.Value));
                    cmd.Parameters.AddWithValue("@s_balance", new_balance);

                    if (Txt_Dtp_charges.Text == "")
                    {
                        cmd.Parameters.AddWithValue("@s_dtp_charges", "0");
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@s_dtp_charges", Convert.ToDecimal(Txt_Dtp_charges.Text));
                    }

                    if (Txt_Fitting.Text == "")
                    {
                        cmd.Parameters.AddWithValue("@s_fitting_charges", "0");
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@s_fitting_charges", Convert.ToDecimal(Txt_Fitting.Text));
                    }

                    cmd.Parameters.AddWithValue("@s_payment_method", Convert.ToString(drp_payment.SelectedItem.Text));
                    cmd.Parameters.AddWithValue("@drp_designer", Convert.ToString(drp_designer.SelectedItem.Text));
                    cmd.Parameters.AddWithValue("@s_transaction_type", "Sale");
                    cmd.Parameters.AddWithValue("@s_cess", "0");
                    cmd.Parameters.AddWithValue("@s_material", Convert.ToDecimal(GridView1.Rows[i].Cells[19].Text));

                    if (Txt_Pasting.Text == "")
                    {
                        cmd.Parameters.AddWithValue("@s_pasting_charges", "0");
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@s_pasting_charges", Convert.ToDecimal(Txt_Pasting.Text));
                    }

                    if (Txt_Framing.Text == "")
                    {
                        cmd.Parameters.AddWithValue("@s_framing_charges", "0");
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@s_framing_charges", Convert.ToDecimal(Txt_Framing.Text));
                    }

                    if (Txt_install.Text == "")
                    {
                        cmd.Parameters.AddWithValue("@s_installation_charges", "0");
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@s_installation_charges", Convert.ToDecimal(Txt_install.Text));
                    }

                    if (txt_UPIno.Text == "")
                    {
                        cmd.Parameters.AddWithValue("@s_upichqno", "");
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@s_upichqno", txt_UPIno.Text);
                    }

                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
                SqlCommand cmd2 = new SqlCommand("update tbl_sale SET sl_invoice_no='" + Convert.ToString(Txt_invoice.Text) + "',sl_date='" + Convert.ToDateTime(lbl_date.Value).ToString("MM/dd/yyyy") + "',c_id='" + Convert.ToString(Dd_customer.SelectedValue) + "',sl_order_no='" + Convert.ToString(Txt_order_no.Text) + "',sl_invoice_date='" + Txt_invoice_date.Text + "',sl_due_date='" + Txt_due_date.Text + "',sl_total_quantity='" + Convert.ToDecimal(lbl_totalqty.Text) + "',sl_discount='" + Convert.ToDecimal(Txt_discount.Text) + "',sl_sub_total='" + Convert.ToDecimal(lbl_subtotal.Text) + "',sl_total_gst='" + Convert.ToDecimal(lbl_gst.Text) + "',sl_adjustment='" + Convert.ToDecimal(Txt_advance.Text) + "',sl_total='" + Convert.ToDecimal(hide_total.Text) + "',sl_total_cgst='" + Convert.ToDecimal(lbl_total_cgst.Value) + "',sl_total_sgst='" + Convert.ToDecimal(lbl_total_sgst.Value) + "',sl_total_igst='" + Convert.ToDecimal(lbl_total_igst.Value) + "',sl_total_taxable='" + Convert.ToDecimal(lbl_total_taxable.Value) + "',sl_balance='" + new_balance + "' where sl_invoice_no='" + Txt_invoice.Text + "' ", conn);

                conn.Open();
                cmd2.ExecuteNonQuery();
                conn.Close();

                Lbl_message.Text = "" + Dd_customer.Text + " Added Successfully!!!";



                SqlCommand cmd3 = new SqlCommand("update tbl_customer set c_opening_balance= c_opening_balance + '" + rem + "' where c_id='" + Dd_customer.SelectedValue + "'", conn);

                conn.Open();
                cmd3.ExecuteNonQuery();

                conn.Close();

                Response.Redirect("bill.aspx?invoice=" + Txt_invoice.Text + "&bill_update=success", false);
            }
            catch (Exception ex)
            {

            }


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
        Dd_material.SelectedValue = GridView1.SelectedRow.Cells[19].Text;
        //material2 = GridView1.SelectedRow.Cells[18].Text;

        //material1(material2);
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
            decimal cgstamount = Convert.ToDecimal(txt_total_amt2.Text) * Convert.ToDecimal(txt_cgst.Text) / 100;
            decimal sgstamount = Convert.ToDecimal(txt_total_amt2.Text) * Convert.ToDecimal(txt_sgst.Text) / 100;
            decimal igstamount = Convert.ToDecimal(txt_total_amt2.Text) * Convert.ToDecimal(txt_igst.Text) / 100;

            SqlCommand cmd = new SqlCommand("update tbl_temp_sale_invoice set s_product_name='" + Dd_enter_product.SelectedItem.Text + "',s_product_hsn='" + lbl_product_hsn.Value + "',s_height='" + txt_height2.Text + "',s_width='" + txt_width2.Text + "',s_size='" + txt_sqrft2.Text + "',s_rate='" + txt_rate2.Text + "',s_samount='" + txt_amount2.Text + "',s_quantity='" + txt_quantity2.Text + "',s_stotal='" + txt_total_amt2.Text + "',s_cgsta='" + cgstamount + "',s_sgsta='" + sgstamount + "',s_igsta='" + igstamount + "',s_amount='" + txt_final_amt.Text + "',s_cgstp='" + txt_cgst.Text + "',s_sgstp='" + txt_sgst.Text + "',s_igstp='" + txt_igst.Text + "',s_desc='" + Txt_description.Text + "',s_unit='" + lbl_unit.Value + "',s_material='" + Dd_material.SelectedValue + "' WHERE s_id='" + lbl_id.Value.Trim() + "'", conn);

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
            decimal cgstamount = Convert.ToDecimal(txt_total_amt2.Text) * Convert.ToDecimal(txt_cgst.Text) / 100;
            decimal sgstamount = Convert.ToDecimal(txt_total_amt2.Text) * Convert.ToDecimal(txt_sgst.Text) / 100;
            decimal igstamount = Convert.ToDecimal(txt_total_amt2.Text) * Convert.ToDecimal(txt_igst.Text) / 100;

            SqlCommand cmd = new SqlCommand("update tbl_temp_sale_invoice set s_product_name='" + Dd_enter_product.SelectedItem.Text + "',s_product_hsn='" + lbl_product_hsn.Value + "',s_height='" + txt_height2.Text + "',s_width='" + txt_width2.Text + "',s_size='" + txt_sqrft2.Text + "',s_rate='" + txt_rate2.Text + "',s_samount='" + txt_amount2.Text + "',s_quantity='" + txt_quantity2.Text + "',s_stotal='" + txt_total_amt2.Text + "',s_cgsta='" + cgstamount + "',s_sgsta='" + sgstamount + "',s_igsta='" + igstamount + "',s_amount='" + txt_final_amt.Text + "',s_cgstp='" + txt_cgst.Text + "',s_sgstp='" + txt_sgst.Text + "',s_igstp='" + txt_igst.Text + "',s_desc='" + Txt_description.Text + "',s_unit='" + lbl_unit.Value + "',s_material='" + Dd_material.SelectedValue + "' WHERE s_id='" + lbl_id.Value.Trim() + "'", conn);

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

            SqlCommand cmd = new SqlCommand("update tbl_temp_sale_invoice set s_product_name='" + Dd_enter_product.SelectedItem.Text + "',s_product_hsn='" + lbl_product_hsn.Value + "',s_height='" + txt_height.Text + "',s_width='" + txt_width.Text + "',s_size='" + txt_sqrft.Text + "',s_rate='" + txt_rate.Text + "',s_samount='" + txt_amount.Text + "',s_quantity='" + txt_quantity.Text + "',s_stotal='" + txt_total_amt.Text + "',s_cgsta='" + cgstamount + "',s_sgsta='" + sgstamount + "',s_igsta='" + igstamount + "',s_amount='" + txt_final_amt.Text + "',s_cgstp='" + txt_cgst.Text + "',s_sgstp='" + txt_sgst.Text + "',s_igstp='" + txt_igst.Text + "',s_desc='" + Txt_description.Text + "',s_unit='" + lbl_unit.Value + "',s_material='" + Dd_material.SelectedValue + "' WHERE s_id='" + lbl_id.Value.Trim() + "'", conn);

            conn.Open();
            cmd.ExecuteNonQuery();

            conn.Close();
            FillGRid();
        }
    }

    protected void Button2_Click(object sender, EventArgs e)
    {
        int i = Convert.ToInt32(GridView1.SelectedRow.Cells[18].Text);

        SqlCommand cmd = new SqlCommand("Delete from tbl_temp_sale_invoice where s_id='" + i + "'", conn);
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

    protected void drp_order_ref_SelectedIndexChanged(object sender, EventArgs e)
    {
        // order_ref_total();
    }
}