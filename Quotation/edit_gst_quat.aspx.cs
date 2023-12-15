using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using System.Activities.Statements;
using System.Security.Cryptography.Xml;
using System.Windows.Forms;

public partial class Quotation_edit_gst_quat : System.Web.UI.Page
{
    SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["String"].ConnectionString);
    decimal total_amount = 0, final_total = 0;
    decimal dPageTotal, finaltotal;
    decimal totalvalue, totalcgst, totalsgst, totaligst, totalgst, totalqty, totaltaxable, Old_total, old_balance, paid, new_balance, new_total, rem, design, advanced, discount, pasting, fitting, transport;
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
                    Btn_cart.Visible= false;
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

        SqlCommand cmd = new SqlCommand("select * from tbl_gst_quotation_details where q_quotation_no='" + quot + "'", conn);
        SqlDataAdapter adapt = new SqlDataAdapter(cmd);
        DataTable dt = new DataTable();
        adapt.Fill(dt);
        if (dt.Rows.Count > 0)
        {
            id = Convert.ToInt32(dt.Rows[0]["q_id"]);
            Dd_customer.SelectedValue = dt.Rows[0]["c_id"].ToString();
            Txt_invoice.Text = dt.Rows[0]["q_quotation_no"].ToString();
            
            lbl_date.Value = Convert.ToDateTime(dt.Rows[0]["q_date"]).ToString("MM/dd/yyyy");
            Txt_invoice_date.Text = Convert.ToDateTime(dt.Rows[0]["q_quotation_date"]).ToString("MM/dd/yyyy");
            Txt_due_date.Text = Convert.ToDateTime(dt.Rows[0]["q_valid_date"]).ToString("MM/dd/yyyy");
            //lbl_totalqty.Text = dt.Rows[0]["s_total_quantity"].ToString();
            lbl_subtotal.Text = dt.Rows[0]["q_sub_total"].ToString();
            lbl_subtotal2.Value = dt.Rows[0]["q_sub_total"].ToString();
            lbl_gst.Text = dt.Rows[0]["q_total_gst"].ToString();
            Txt_TransportCharges.Text = dt.Rows[0]["q_shipping_charges"].ToString();
            Txt_Dtp_charges.Text = dt.Rows[0]["q_dtp_charges"].ToString();
            Txt_Fitting.Text = dt.Rows[0]["q_fitting_charges"].ToString();
            Txt_Pasting.Text = dt.Rows[0]["q_pasting_charges"].ToString();
            drp_payment.Text = dt.Rows[0]["q_payment_method"].ToString();
            Txt_advance.Text = dt.Rows[0]["q_adjustment"].ToString();
            Txt_discount.Text = dt.Rows[0]["q_discount"].ToString();
            lbl_total.Text = dt.Rows[0]["q_total"].ToString();
            hide_total.Text = dt.Rows[0]["q_total"].ToString();
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
            SqlCommand cmd = new SqlCommand("delete from tbl_temp_gst_quotation_details", conn);
            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();

            if (conn.State != ConnectionState.Closed)
            {
                conn.Close();
            }
            SqlCommand cmd2 = new SqlCommand("insert into tbl_temp_gst_quotation_details select q_quotation_no,q_date,c_id,q_quotation_date,q_valid_date,q_product_name,q_quantity,q_total_quantity,q_rate,q_discount,q_cgstp,q_cgsta,q_sgstp,q_sgsta,q_igstp,q_igsta,q_amount,q_sub_total,q_total_gst,q_shipping_charges,q_adjustment,q_total,q_stotal,q_hsn,q_unit,q_desc,q_height,q_width,q_size,q_samount from tbl_gst_quotation_details where q_quotation_no='" + quot + "'", conn);
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


            SqlCommand cmd = new SqlCommand("select q_product_name as Product,q_hsn as HSN,q_height as Height,q_width as Width,q_size as SQRFT,q_rate as Rate,q_samount as Amount,q_quantity as Qty,q_stotal as Total,q_cgsta as CGST,q_sgsta as SGST,q_igsta as IGST,q_amount as FINAL,q_cgstp as cgstp,q_sgstp as sgstp,q_igstp as igstp,q_desc as [desc],q_unit as unit,q_id as[ID] from tbl_temp_gst_quotation_details where q_quotation_no='" + quot + "'", conn);
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


                pasting = Convert.ToDecimal(Txt_Pasting.Text);
                transport = Convert.ToDecimal(Txt_TransportCharges.Text);
                design = Convert.ToDecimal(Txt_Dtp_charges.Text);
                fitting = Convert.ToDecimal(Txt_Fitting.Text);
                discount = Convert.ToDecimal(Txt_discount.Text);

                decimal total1 = (totalvalue + pasting + transport + design + fitting - discount);
                decimal final = (totalvalue + pasting + transport + design + fitting);
                lbl_final.Text = final.ToString();
                lbl_total.Text = total1.ToString();
                hide_total.Text = final.ToString();
                product();
                //txt_height.Text = "0";
                //txt_height2.Text = "0";
                //txt_width.Text = "0";
                //txt_width2.Text = "0";
                //txt_sqrft.Text = "0";
                //txt_sqrft2.Text = "0";
                //txt_rate2.Text = "0";
                //txt_rate.Text = "0";
                //txt_amount.Text = "0";
                //txt_amount2.Text = "0";
                //txt_quantity.Text = "0";
                //txt_quantity2.Text = "0";
                //txt_total_amt.Text = "0";
                //txt_total_amt2.Text = "0";
                //txt_cgst.Text = "0";
                //txt_igst.Text = "0";
                //txt_sgst.Text = "0";
                //Txt_description.Text = "";
                //txt_final_amt.Text = "0";
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
               
                GridView1.Visible = true;
            }
            else
            {
                GridView1.DataSource = null;
                GridView1.DataBind();

                //lbl_total.Text = "0";
                //hide_total.Text = "0";
                //lbl_subtotal.Text = "0";
                //lbl_subtotal2.Value = "0";
                //lbl_gst.Text = "0";
                //Txt_Pasting.Text = "0";
                //Txt_Fitting.Text = "0";
                //Txt_discount.Text = "0";
                //lbl_final.Text = "0";
                //Txt_TransportCharges.Text = "0";
                //Txt_advance.Text = "0";






                //lbl_total.Text = "0";
                //hide_total.Text = "0";
                //lbl_subtotal.Text = "0";
                //lbl_subtotal2.Value = "0";
                //lbl_gst.Text = "0";

                //lbl_totalqty.Text = "0";
                ////Dd_enter_product.SelectedValue = "--Slect--";
                //// product();

                //// lbl_product_hsn.Value = "";

                //txt_amount.Text = "0";
                //txt_quantity.Text = "0";

                //txt_total_amt.Text = "0";


                //txt_final_amt.Text = "0";
                //hide_total.Text = "0";
                //Txt_description.Text = "";
                //lbl_unit.Value = "";

                //Txt_discount.Text = "0";

                //txt_cgst.Text = "0";
                //txt_igst.Text = "0";
                //txt_sgst.Text = "0";
                //Txt_Dtp_charges.Text = "0";
                //Txt_Pasting.Text = "0";
                //Txt_Fitting.Text = "0";
                //Txt_discount.Text = "0";
                //lbl_final.Text = "0";
                //Txt_TransportCharges.Text = "0";
                //txt_quantity2.Text = "0";
                //txt_amount.Text = "0";
                //txt_quantity.Text = "0";
                //txt_total_amt.Text = "0";
                //txt_height.Text = "0";
                //txt_height2.Text = "0";
                //txt_width.Text = "0";
                //txt_width2.Text = "0";
                //txt_sqrft.Text = "0";
                //txt_sqrft2.Text = "0";
                //txt_rate2.Text = "0";
                //txt_rate.Text = "0";
                //Txt_description.Text = "";
                GridView1.Visible = false;
                lbl_total.Text = "0";
                hide_total.Text = "0";
                lbl_subtotal.Text = "0";
                lbl_subtotal2.Value = "0";
                lbl_gst.Text = "0";

                lbl_totalqty.Text = "0";
                //Dd_enter_product.SelectedValue = "--Slect--";
                product();
               
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
        //GetData();
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
                SqlCommand cmd = new SqlCommand("insert into tbl_temp_gst_quotation_details values(@q_quotation_no,@q_date,@c_id,@q_quotation_date,@q_valid_date,@q_product_name,@q_quantity,@q_total_quantity,@q_rate,@q_discount,@q_cgstp,@q_cgsta,@q_sgstp,@q_sgsta,@q_igstp,@q_igsta,@q_amount,@q_sub_total,@q_total_gst,@q_shipping_charges,@q_adjustment,@q_total,@q_stotal,@q_hsn,@q_unit,@q_desc,@q_height,@q_width,@q_size,@q_samount)", conn);

                cmd.Parameters.AddWithValue("@q_quotation_no", Convert.ToString(Txt_invoice.Text));
                cmd.Parameters.AddWithValue("@q_date", DateTime.Now.ToShortDateString());
                cmd.Parameters.AddWithValue("@c_id", Convert.ToString(Dd_customer.SelectedValue));
                cmd.Parameters.AddWithValue("@q_quotation_date", Convert.ToDateTime(Txt_invoice_date.Text).ToString());
                cmd.Parameters.AddWithValue("@q_valid_date", Convert.ToDateTime(Txt_due_date.Text).ToString());
                cmd.Parameters.AddWithValue("@q_product_name", Convert.ToString(Dd_enter_product.SelectedItem.Text));
                cmd.Parameters.AddWithValue("@q_quantity", Convert.ToDecimal(txt_quantity2.Text));
                cmd.Parameters.AddWithValue("@q_unit", Convert.ToString(lbl_unit.Value));
                cmd.Parameters.AddWithValue("@q_total_quantity", Convert.ToDecimal(lbl_totalqty.Text));
                cmd.Parameters.AddWithValue("@q_rate", Convert.ToDecimal(txt_rate2.Text));
                cmd.Parameters.AddWithValue("@q_discount", Convert.ToDecimal(Txt_discount.Text));
                cmd.Parameters.AddWithValue("@q_cgstp", Convert.ToDecimal(txt_cgst.Text));
                cmd.Parameters.AddWithValue("@q_cgsta", Convert.ToDecimal(cgstamount));
                cmd.Parameters.AddWithValue("@q_sgstp", Convert.ToDecimal(txt_sgst.Text));
                cmd.Parameters.AddWithValue("@q_sgsta", Convert.ToDecimal(sgstamount));
                cmd.Parameters.AddWithValue("@q_igstp", Convert.ToDecimal(txt_igst.Text));
                cmd.Parameters.AddWithValue("@q_igsta", Convert.ToDecimal(igstamount));
                cmd.Parameters.AddWithValue("@q_amount", Convert.ToDecimal(txt_final_amt.Text));
                cmd.Parameters.AddWithValue("@q_sub_total", Convert.ToDecimal(lbl_subtotal.Text));
                cmd.Parameters.AddWithValue("@q_total_gst", Convert.ToDecimal(lbl_gst.Text));
                cmd.Parameters.AddWithValue("@q_shipping_charges", Convert.ToDecimal(Txt_TransportCharges.Text));
                cmd.Parameters.AddWithValue("@q_adjustment", Convert.ToDecimal(Txt_advance.Text));
                cmd.Parameters.AddWithValue("@q_total", Convert.ToDecimal(hide_total.Text));
                cmd.Parameters.AddWithValue("@q_stotal", Convert.ToDecimal(txt_total_amt2.Text));
                cmd.Parameters.AddWithValue("@q_hsn", Convert.ToString(lbl_product_hsn.Value));
                cmd.Parameters.AddWithValue("@q_desc", Convert.ToString(Txt_description.Text));
                cmd.Parameters.AddWithValue("@q_height", "");
                cmd.Parameters.AddWithValue("@q_width", "");
                cmd.Parameters.AddWithValue("@q_size", "");
                cmd.Parameters.AddWithValue("@q_samount", "");
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
                SqlCommand cmd = new SqlCommand("insert into tbl_temp_gst_quotation_details values(@q_quotation_no,@q_date,@c_id,@q_quotation_date,@q_valid_date,@q_product_name,@q_quantity,@q_total_quantity,@q_rate,@q_discount,@q_cgstp,@q_cgsta,@q_sgstp,@q_sgsta,@q_igstp,@q_igsta,@q_amount,@q_sub_total,@q_total_gst,@q_shipping_charges,@q_adjustment,@q_total,@q_stotal,@q_hsn,@q_unit,@q_desc,@q_height,@q_width,@q_size,@q_samount)", conn);

                cmd.Parameters.AddWithValue("@q_quotation_no", Convert.ToString(Txt_invoice.Text));
                cmd.Parameters.AddWithValue("@q_date", DateTime.Now.ToShortDateString());
                cmd.Parameters.AddWithValue("@c_id", Convert.ToString(Dd_customer.SelectedValue));
                
                cmd.Parameters.AddWithValue("@q_quotation_date", Convert.ToDateTime(Txt_invoice_date.Text).ToString());
                cmd.Parameters.AddWithValue("@q_valid_date", Convert.ToDateTime(Txt_due_date.Text).ToString());
                cmd.Parameters.AddWithValue("@q_product_name", Convert.ToString(Dd_enter_product.SelectedItem.Text));
                cmd.Parameters.AddWithValue("@q_quantity", Convert.ToDecimal(txt_quantity2.Text));
                cmd.Parameters.AddWithValue("@q_unit", Convert.ToString(lbl_unit.Value));
                cmd.Parameters.AddWithValue("@q_total_quantity", Convert.ToDecimal(lbl_totalqty.Text));
                cmd.Parameters.AddWithValue("@q_rate", Convert.ToDecimal(txt_rate2.Text));
                cmd.Parameters.AddWithValue("@q_discount", Convert.ToDecimal(Txt_discount.Text));
                cmd.Parameters.AddWithValue("@q_cgstp", Convert.ToDecimal(txt_cgst.Text));
                cmd.Parameters.AddWithValue("@q_cgsta", Convert.ToDecimal(cgstamount));
                cmd.Parameters.AddWithValue("@q_sgstp", Convert.ToDecimal(txt_sgst.Text));
                cmd.Parameters.AddWithValue("@q_sgsta", Convert.ToDecimal(sgstamount));
                cmd.Parameters.AddWithValue("@q_igstp", Convert.ToDecimal(txt_igst.Text));
                cmd.Parameters.AddWithValue("@q_igsta", Convert.ToDecimal(igstamount));
                cmd.Parameters.AddWithValue("@q_amount", Convert.ToDecimal(txt_final_amt.Text));
                cmd.Parameters.AddWithValue("@q_sub_total", Convert.ToDecimal(lbl_subtotal.Text));
                cmd.Parameters.AddWithValue("@q_total_gst", Convert.ToDecimal(lbl_gst.Text));
                cmd.Parameters.AddWithValue("@q_shipping_charges", Convert.ToDecimal(Txt_TransportCharges.Text));
                cmd.Parameters.AddWithValue("@q_adjustment", Convert.ToDecimal(Txt_advance.Text));
                cmd.Parameters.AddWithValue("@q_total", Convert.ToDecimal(hide_total.Text));
                cmd.Parameters.AddWithValue("@q_stotal", Convert.ToDecimal(txt_total_amt2.Text));
                cmd.Parameters.AddWithValue("@q_hsn", Convert.ToString(lbl_product_hsn.Value));
                cmd.Parameters.AddWithValue("@q_desc", Convert.ToString(Txt_description.Text));
                cmd.Parameters.AddWithValue("@q_height", "");
                cmd.Parameters.AddWithValue("@q_width", "");
                cmd.Parameters.AddWithValue("@q_size", "");
                cmd.Parameters.AddWithValue("@q_samount", "");
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
                SqlCommand cmd = new SqlCommand("insert into tbl_temp_gst_quotation_details values(@q_quotation_no,@q_date,@c_id,@q_quotation_date,@q_valid_date,@q_product_name,@q_quantity,@q_total_quantity,@q_rate,@q_discount,@q_cgstp,@q_cgsta,@q_sgstp,@q_sgsta,@q_igstp,@q_igsta,@q_amount,@q_sub_total,@q_total_gst,@q_shipping_charges,@q_adjustment,@q_total,@q_stotal,@q_hsn,@q_unit,@q_desc,@q_height,@q_width,@q_size,@q_samount)", conn);

                cmd.Parameters.AddWithValue("@q_quotation_no", Convert.ToString(Txt_invoice.Text));
                cmd.Parameters.AddWithValue("@q_date", DateTime.Now.ToShortDateString());
                cmd.Parameters.AddWithValue("@c_id", Convert.ToString(Dd_customer.SelectedValue));
               
                cmd.Parameters.AddWithValue("@q_quotation_date", Convert.ToDateTime(Txt_invoice_date.Text).ToString());
                cmd.Parameters.AddWithValue("@q_valid_date", Convert.ToDateTime(Txt_due_date.Text).ToString());
                cmd.Parameters.AddWithValue("@q_product_name", Convert.ToString(Dd_enter_product.SelectedItem.Text));
                cmd.Parameters.AddWithValue("@q_quantity", Convert.ToDecimal(txt_quantity.Text));
                cmd.Parameters.AddWithValue("@q_unit", Convert.ToString(lbl_unit.Value));
                cmd.Parameters.AddWithValue("@q_total_quantity", Convert.ToDecimal(lbl_totalqty.Text));
                cmd.Parameters.AddWithValue("@q_rate", Convert.ToDecimal(txt_rate.Text));
                cmd.Parameters.AddWithValue("@q_discount", Convert.ToDecimal(Txt_discount.Text));
                cmd.Parameters.AddWithValue("@q_cgstp", Convert.ToDecimal(txt_cgst.Text));
                cmd.Parameters.AddWithValue("@q_cgsta", Convert.ToDecimal(cgstamount));
                cmd.Parameters.AddWithValue("@q_sgstp", Convert.ToDecimal(txt_sgst.Text));
                cmd.Parameters.AddWithValue("@q_sgsta", Convert.ToDecimal(sgstamount));
                cmd.Parameters.AddWithValue("@q_igstp", Convert.ToDecimal(txt_igst.Text));
                cmd.Parameters.AddWithValue("@q_igsta", Convert.ToDecimal(igstamount));
                cmd.Parameters.AddWithValue("@q_amount", Convert.ToDecimal(txt_final_amt.Text));
                cmd.Parameters.AddWithValue("@q_sub_total", Convert.ToDecimal(lbl_subtotal.Text));
                cmd.Parameters.AddWithValue("@q_total_gst", Convert.ToDecimal(lbl_gst.Text));
                cmd.Parameters.AddWithValue("@q_shipping_charges", Convert.ToDecimal(Txt_TransportCharges.Text));
                cmd.Parameters.AddWithValue("@q_adjustment", Convert.ToDecimal(Txt_advance.Text));
                cmd.Parameters.AddWithValue("@q_total", Convert.ToDecimal(hide_total.Text));
                cmd.Parameters.AddWithValue("@q_stotal", Convert.ToDecimal(txt_total_amt.Text));
                cmd.Parameters.AddWithValue("@q_hsn", Convert.ToString(lbl_product_hsn.Value));
                cmd.Parameters.AddWithValue("@q_desc", Convert.ToString(Txt_description.Text));
                cmd.Parameters.AddWithValue("@q_height", Convert.ToDecimal(txt_height.Text));
                cmd.Parameters.AddWithValue("@q_width", Convert.ToDecimal(txt_width.Text));
                cmd.Parameters.AddWithValue("@q_size", Convert.ToDecimal(txt_sqrft.Text));
                cmd.Parameters.AddWithValue("@q_samount", Convert.ToDecimal(txt_amount.Text));
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
                txt_width2.Text = "0";

                txt_height2.Text = "0";
                txt_quantity2.Text = "0";
                txt_sqrft2.Text = "0";
            }


            else
            {
                Panel1.Visible = true;
                Panel2.Visible = false;
                txt_rate.Text = rate;
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
            txt_cgst.Text = "0";
            txt_sgst.Text = "0";
            txt_igst.Text = "0";
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
                //SqlCommand cmd4 = new SqlCommand("select * from tbl_gst_quotation_details where q_quotation_no='" + quot + "'", conn);
                //SqlDataAdapter adapt4 = new SqlDataAdapter(cmd4);
                //DataTable dt4 = new DataTable();
                //adapt4.Fill(dt4);
                //if (dt4.Rows.Count > 0)
                //{
                //    Old_total = Convert.ToDecimal(dt4.Rows[0]["q_total"]);

                //    //paid = Old_total - old_balance;
                //    new_total = Convert.ToDecimal(hide_total.Text) - Convert.ToDecimal(Txt_discount.Text);
                //    new_balance = new_total;
                //    rem = new_total;
                //}
                decimal new_balance;
                finaltotal = Math.Round(Convert.ToDecimal(hide_total.Text));
                new_balance = finaltotal - Convert.ToDecimal(Txt_discount.Text);  


                SqlCommand cmd5 = new SqlCommand("DELETE FROM tbl_gst_quotation_details Where q_quotation_no='" + quot + "'", conn);
                conn.Open();
                cmd5.ExecuteNonQuery();
                conn.Close();

                int rowscount = GridView1.Rows.Count;
                for (int i = 0; i < rowscount; i++)
                {


                    SqlCommand cmd = new SqlCommand("insert into tbl_gst_quotation_details values(@q_quotation_no,@q_date,@c_id,@q_quotation_date,@q_valid_date,@q_product_name,@q_quantity,@q_total_quantity,@q_rate,@q_discount,@q_cgstp,@q_cgsta,@q_sgstp,@q_sgsta,@q_igstp,@q_igsta,@q_amount,@q_sub_total,@q_total_gst,@q_shipping_charges,@q_adjustment,@q_total,@q_stotal,@q_hsn,@q_unit,@q_desc,@q_height,@q_width,@q_size,@q_samount,@q_balance,@q_dtp_charges,@q_fitting_charges,@q_payment_method,@q_pasting_charges)", conn);
                    cmd.Parameters.AddWithValue("@q_quotation_no", Convert.ToString(Txt_invoice.Text));
                    cmd.Parameters.AddWithValue("@q_date", lbl_date.Value.ToString());
                    cmd.Parameters.AddWithValue("@c_id", Convert.ToString(Dd_customer.SelectedValue));

                    cmd.Parameters.AddWithValue("@q_quotation_date", Txt_invoice_date.Text);
                    cmd.Parameters.AddWithValue("@q_valid_date", Txt_due_date.Text);
                    cmd.Parameters.AddWithValue("@q_product_name", Convert.ToString(GridView1.Rows[i].Cells[0].Text));
                    cmd.Parameters.AddWithValue("@q_quantity", Convert.ToDecimal(GridView1.Rows[i].Cells[7].Text));
                    cmd.Parameters.AddWithValue("@q_unit", Convert.ToString(GridView1.Rows[i].Cells[17].Text));
                    cmd.Parameters.AddWithValue("@q_total_quantity", Convert.ToDecimal(lbl_totalqty.Text));
                    cmd.Parameters.AddWithValue("@q_rate", Convert.ToDecimal(GridView1.Rows[i].Cells[5].Text));
                    cmd.Parameters.AddWithValue("@q_discount", Convert.ToDecimal(Txt_discount.Text));
                    cmd.Parameters.AddWithValue("@q_cgstp", Convert.ToDecimal(GridView1.Rows[i].Cells[13].Text));
                    cmd.Parameters.AddWithValue("@q_cgsta", Convert.ToDecimal(GridView1.Rows[i].Cells[9].Text));
                    cmd.Parameters.AddWithValue("@q_sgstp", Convert.ToDecimal(GridView1.Rows[i].Cells[14].Text));
                    cmd.Parameters.AddWithValue("@q_sgsta", Convert.ToDecimal(GridView1.Rows[i].Cells[10].Text));
                    cmd.Parameters.AddWithValue("@q_igstp", Convert.ToDecimal(GridView1.Rows[i].Cells[15].Text));
                    cmd.Parameters.AddWithValue("@q_igsta", Convert.ToDecimal(GridView1.Rows[i].Cells[11].Text));
                    cmd.Parameters.AddWithValue("@q_amount", Convert.ToDecimal(GridView1.Rows[i].Cells[12].Text));
                    cmd.Parameters.AddWithValue("@q_sub_total", Convert.ToDecimal(lbl_subtotal.Text));
                    cmd.Parameters.AddWithValue("@q_total_gst", Convert.ToDecimal(lbl_gst.Text));
                    cmd.Parameters.AddWithValue("@q_shipping_charges", Convert.ToDecimal(Txt_TransportCharges.Text));
                    cmd.Parameters.AddWithValue("@q_adjustment", Convert.ToDecimal(Txt_advance.Text));
                    cmd.Parameters.AddWithValue("@q_total", Convert.ToDecimal(hide_total.Text));
                    cmd.Parameters.AddWithValue("@q_stotal", Convert.ToDecimal(GridView1.Rows[i].Cells[8].Text));
                    if (GridView1.Rows[i].Cells[1].Text.Trim() == "&amp;nbsp;")
                    {
                        cmd.Parameters.AddWithValue("@q_hsn", "");
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@q_hsn", Convert.ToString(GridView1.Rows[i].Cells[1].Text.Trim()));
                    }
                    if (GridView1.Rows[i].Cells[16].Text.Trim() == "&amp;nbsp;")
                    {
                        cmd.Parameters.AddWithValue("@q_desc", "");
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@q_desc", Convert.ToString(GridView1.Rows[i].Cells[16].Text.Trim()));
                    }
                    cmd.Parameters.AddWithValue("@q_height", Convert.ToDecimal(GridView1.Rows[i].Cells[2].Text));
                    cmd.Parameters.AddWithValue("@q_width", Convert.ToDecimal(GridView1.Rows[i].Cells[3].Text));
                    cmd.Parameters.AddWithValue("@q_size", Convert.ToDecimal(GridView1.Rows[i].Cells[4].Text));
                    cmd.Parameters.AddWithValue("@q_samount", Convert.ToDecimal(GridView1.Rows[i].Cells[6].Text));
                    cmd.Parameters.AddWithValue("@q_balance", Convert.ToDecimal(new_balance));
                    cmd.Parameters.AddWithValue("@q_dtp_charges", Convert.ToDecimal(Txt_Dtp_charges.Text));
                    cmd.Parameters.AddWithValue("@q_fitting_charges", Convert.ToDecimal(Txt_Fitting.Text));
                    cmd.Parameters.AddWithValue("@q_payment_method", Convert.ToString(drp_payment.SelectedItem.Text));
                    cmd.Parameters.AddWithValue("@q_pasting_charges", Convert.ToDecimal(Txt_Pasting.Text));
                    conn.Open();
                    cmd.ExecuteNonQuery();

                    conn.Close();
                }
                SqlCommand cmd2 = new SqlCommand("update tbl_gst_quotation SET qu_invoice_no='" + Convert.ToString(Txt_invoice.Text) + "',qu_date='" + Convert.ToDateTime(lbl_date.Value).ToString("MM/dd/yyyy") + "',c_id='" + Convert.ToString(Dd_customer.SelectedValue) + "',qu_invoice_date='" + Convert.ToDateTime(Txt_invoice_date.Text).ToString("MM/dd/yyyy")  + "',qu_due_date='" + Convert.ToDateTime(Txt_due_date.Text).ToString("MM/dd/yyyy")  + "',qu_total_quantity='" + Convert.ToDecimal(lbl_totalqty.Text) + "',qu_discount='" + Convert.ToDecimal(Txt_discount.Text) + "',qu_sub_total='" + Convert.ToDecimal(lbl_subtotal.Text) + "',qu_total_gst='" + Convert.ToDecimal(lbl_gst.Text) + "',qu_adjustment='" + Convert.ToDecimal(Txt_advance.Text) + "',qu_total='" + Convert.ToDecimal(hide_total.Text) + "' where qu_invoice_no='" + Txt_invoice.Text + "' ", conn);

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

            SqlCommand cmd = new SqlCommand("update tbl_temp_gst_quotation_details set q_product_name='" + Dd_enter_product.SelectedItem.Text + "',q_hsn='" + lbl_product_hsn.Value + "',q_height='" + txt_height2.Text + "',q_width='" + txt_width2.Text + "',q_size='" + txt_sqrft2.Text + "',q_rate='" + txt_rate2.Text + "',q_samount='" + txt_amount2.Text + "',q_quantity='" + txt_quantity2.Text + "',q_stotal='" + txt_total_amt2.Text + "',q_cgsta='" + cgstamount + "',q_sgsta='" + sgstamount + "',q_igsta='" + igstamount + "',q_amount='" + txt_final_amt.Text + "',q_cgstp='" + txt_cgst.Text + "',q_sgstp='" + txt_sgst.Text + "',q_igstp='" + txt_igst.Text + "',q_desc='" + Txt_description.Text + "',q_unit='" + lbl_unit.Value + "' WHERE q_id='" + lbl_id.Value.Trim() + "'", conn);

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

            SqlCommand cmd = new SqlCommand("update tbl_temp_gst_quotation_details set q_product_name='" + Dd_enter_product.SelectedItem.Text + "',q_hsn='" + lbl_product_hsn.Value + "',q_height='" + txt_height2.Text + "',q_width='" + txt_width2.Text + "',q_size='" + txt_sqrft2.Text + "',q_rate='" + txt_rate2.Text + "',q_samount='" + txt_amount2.Text + "',q_quantity='" + txt_quantity2.Text + "',q_stotal='" + txt_total_amt2.Text + "',q_cgsta='" + cgstamount + "',q_sgsta='" + sgstamount + "',q_igsta='" + igstamount + "',q_amount='" + txt_final_amt.Text + "',q_cgstp='" + txt_cgst.Text + "',q_sgstp='" + txt_sgst.Text + "',q_igstp='" + txt_igst.Text + "',q_desc='" + Txt_description.Text + "',q_unit='" + lbl_unit.Value + "' WHERE q_id='" + lbl_id.Value.Trim() + "'", conn);

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

            SqlCommand cmd = new SqlCommand("update tbl_temp_gst_quotation_details set q_product_name='" + Dd_enter_product.SelectedItem.Text + "',q_hsn='" + lbl_product_hsn.Value + "',q_height='" + txt_height.Text + "',q_width='" + txt_width.Text + "',q_size='" + txt_sqrft.Text + "',q_rate='" + txt_rate.Text + "',q_samount='" + txt_amount.Text + "',q_quantity='" + txt_quantity.Text + "',q_stotal='" + txt_total_amt.Text + "',q_cgsta='" + cgstamount + "',q_sgsta='" + sgstamount + "',q_igsta='" + igstamount + "',q_amount='" + txt_final_amt.Text + "',q_cgstp='" + txt_cgst.Text + "',q_sgstp='" + txt_sgst.Text + "',q_igstp='" + txt_igst.Text + "',q_desc='" + Txt_description.Text + "',q_unit='" + lbl_unit.Value + "' WHERE q_id='" + lbl_id.Value.Trim() + "'", conn);

            conn.Open();
            cmd.ExecuteNonQuery();

            conn.Close();
            FillGRid();
        }
    }

    protected void Button2_Click(object sender, EventArgs e)
    {
        int i = Convert.ToInt32(GridView1.SelectedRow.Cells[18].Text);

        SqlCommand cmd = new SqlCommand("Delete from tbl_temp_gst_quotation_details where q_id='" + i + "'", conn);
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