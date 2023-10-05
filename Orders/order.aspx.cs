using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using System.Net;
using System.Text;
using System.Net.Mail;
using System.Text.RegularExpressions;

public partial class Orders_order : System.Web.UI.Page
{

    SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["String"].ConnectionString);
    SqlCommand cmd2, cmd3, cmd4, cmd5, cmd6, cmd7, cmd8, cmd9, cmd10;
    SqlDataAdapter adapt2, adapt3, adapt4, adapt5, adapt6, adapt7, adapt8, adapt9, adapt10;
    DataTable dt, dt1, dt2, dt3, dt4, dt5, dt6, dt7, dt8, dt9, dt10;
    decimal total_amount = 0, final_total = 0;
    decimal dPageTotal;
    decimal totalvalue = 0, totalcgst = 0, totalsgst = 0, totaligst = 0, totalgst = 0, totalqty, totaltaxable = 0, finaltotal;
    string key, country, senderid, route, email, password, port, subject, smtp, com_email;
    int sms, mail2;
    protected void Page_Load(object sender, EventArgs e)
    {
        //hide_total.Visible = false;

        if (Session["a_email"] != null)
        {

            if (!IsPostBack)
            {
                Panel1.Visible = true;
                Panel2.Visible = false;
                Txt_invoice_date.Text = DateTime.Today.ToString("yyyy-MM-dd");
                Txt_due_date.Text = DateTime.Today.ToString("yyyy-MM-dd");
                this.invoiceid();
                this.customer();
                Designer();
                this.product();
             


                if (ViewState["Details"] == null)
                {
                    DataTable dataTable = new DataTable();
                    dataTable.Columns.Add("Product");
                    dataTable.Columns.Add("HSN");
                    dataTable.Columns.Add("Height");
                    dataTable.Columns.Add("Width");
                    dataTable.Columns.Add("SQRFT");
                    dataTable.Columns.Add("Rate");
                    dataTable.Columns.Add("Amount");
                    dataTable.Columns.Add("Qty");
                    dataTable.Columns.Add("Total");
                    dataTable.Columns.Add("CGST");
                    dataTable.Columns.Add("SGST");
                    dataTable.Columns.Add("IGST");
                    dataTable.Columns.Add("Final");
                    dataTable.Columns.Add("cgstp");
                    dataTable.Columns.Add("sgstp");
                    dataTable.Columns.Add("igstp");
                    dataTable.Columns.Add("desc");
                    dataTable.Columns.Add("unit");

                    ViewState["Details"] = dataTable;
                }
            }
        }
        else
        {
            Response.Redirect("../login.aspx");
        }
    }

    public void customer()
    {
        string query = "select * from tbl_customer Order By c_name asc";
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
        string query = "select * from tbl_product Order By p_name asc";
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

    public void invoiceid()
    {
        try
        {

            conn.Open();
            SqlCommand cmd = new SqlCommand("SELECT TOP 1 sl_id FROM tbl_order ORDER BY sl_id DESC", conn);
            string inv;
            int i = 0;
            SqlDataAdapter adapt = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            adapt.Fill(dt);

           
            if (dt.Rows.Count > 0)
            {
                inv = (Convert.ToDecimal(dt.Rows[0]["sl_id"])+1).ToString();

            }
            else
            {
                inv = "1";
            }

             Txt_invoice.Text = "ORD-" + inv.ToString();

           
        }

        catch (Exception ex)
        {
            Response.Write(ex.Message.ToString());
        }
        finally
        {
            conn.Close();
        }


    }




    protected void Btn_cart_Click(object sender, EventArgs e)
    {
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
        for (int i = 0; i <= GridView1.Rows.Count; i++)
        {
            total_amount += Convert.ToDecimal(txt_final_amt.Text);

        }
        final_total = total_amount;

        if (str9 == "Pcs")
        {



            decimal cgstamount = Convert.ToDecimal(total2) * Convert.ToDecimal(cgst) / 100;
            decimal sgstamount = Convert.ToDecimal(total2) * Convert.ToDecimal(sgst) / 100;
            decimal igstamount = Convert.ToDecimal(total2) * Convert.ToDecimal(igst) / 100;

            dt = (DataTable)ViewState["Details"];
            dt.Rows.Add(str, str10, height2, width2, sqrft2, rate2, amount2, quantity2, total2, cgstamount, sgstamount, igstamount, final, cgst, sgst, igst, desc, str9);
            ViewState["Details"] = dt;
            GridView1.DataSource = dt;
            GridView1.EmptyDataText = "Product";
            GridView1.EmptyDataText = "HSN";
            GridView1.EmptyDataText = "Height";
            GridView1.EmptyDataText = "Width";
            GridView1.EmptyDataText = "SQRFT";
            GridView1.EmptyDataText = "Rate";
            GridView1.EmptyDataText = "Amount";
            GridView1.EmptyDataText = "Qty";
            GridView1.EmptyDataText = "Total";
            GridView1.EmptyDataText = "CGST";
            GridView1.EmptyDataText = "SGST";
            GridView1.EmptyDataText = "IGST";
            GridView1.EmptyDataText = "FINAL";
            GridView1.EmptyDataText = "CGSTP";
            GridView1.EmptyDataText = "SGSTP";
            GridView1.EmptyDataText = "IGSTP";
            GridView1.EmptyDataText = "DESC";
            GridView1.EmptyDataText = "Unit";


            GridView1.DataBind();




            decimal a = 0, b = 0, c = 0;

            for (int i = 0; i < (GridView1.Rows.Count); i++)
            {
                // a = Convert.ToDecimal(GridView1.Rows[i].Cells[6].Text.ToString());
                c = c + a; //storing total qty into variable 
            }
        }
        else
        {

            decimal cgstamount = Convert.ToDecimal(total) * Convert.ToDecimal(cgst) / 100;
            decimal sgstamount = Convert.ToDecimal(total) * Convert.ToDecimal(sgst) / 100;
            decimal igstamount = Convert.ToDecimal(total) * Convert.ToDecimal(igst) / 100;

            dt = (DataTable)ViewState["Details"];
            dt.Rows.Add(str, str10, height, width, sqrft, rate, amount, quantity, total, cgstamount, sgstamount, igstamount, final, cgst, sgst, igst, desc, str9);
            ViewState["Details"] = dt;
            GridView1.DataSource = dt;
            GridView1.EmptyDataText = "Product";
            GridView1.EmptyDataText = "HSN";
            GridView1.EmptyDataText = "Height";
            GridView1.EmptyDataText = "Width";
            GridView1.EmptyDataText = "SQRFT";
            GridView1.EmptyDataText = "Rate";
            GridView1.EmptyDataText = "Amount";
            GridView1.EmptyDataText = "Qty";
            GridView1.EmptyDataText = "Total";
            GridView1.EmptyDataText = "CGST";
            GridView1.EmptyDataText = "SGST";
            GridView1.EmptyDataText = "IGST";
            GridView1.EmptyDataText = "FINAL";
            GridView1.EmptyDataText = "CGSTP";
            GridView1.EmptyDataText = "SGSTP";
            GridView1.EmptyDataText = "IGSTP";
            GridView1.EmptyDataText = "DESC";
            GridView1.EmptyDataText = "Unit";


            GridView1.DataBind();




            decimal a = 0, b = 0, c = 0;

            for (int i = 0; i < (GridView1.Rows.Count); i++)
            {
                // a = Convert.ToDecimal(GridView1.Rows[i].Cells[6].Text.ToString());
                c = c + a; //storing total qty into variable 
            }
        }
    }

    protected void GridView1_DataBound(object sender, EventArgs e)
    {

    }
    int total = 0, indexofcolumn = 1;
    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        TableCell cell = e.Row.Cells[0];
        e.Row.Cells.RemoveAt(0);
        e.Row.Cells.Add(cell);
        if (e.Row.Cells.Count > indexofcolumn)
        {
            e.Row.Cells[2].Visible = false;
            e.Row.Cells[3].Visible = false;
            e.Row.Cells[13].Visible = false;
            e.Row.Cells[14].Visible = false;
            e.Row.Cells[15].Visible = false;
            e.Row.Cells[16].Visible = false;
            e.Row.Cells[17].Visible = false;

        }
        //Check if the current row is datarow or not
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            //Add the value of column
            totalvalue += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "FINAL"));
            totalcgst += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "CGST"));
            totalsgst += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "SGST"));
            totaligst += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "IGST"));
            totalqty += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "Qty"));
            totaltaxable += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "Total"));

        }
        if (e.Row.RowType == DataControlRowType.Footer)
        {
            totalgst = totalcgst + totalsgst + totaligst;
            //Find the control label in footer 
            Label lblamount = (Label)e.Row.FindControl("lbl_subtotal");
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


        // GET THE RUNNING TOTAL OF PRICE FOR EACH PAGE.
        // if (e.Row.RowType == DataControlRowType.DataRow)
        {
            //total += Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "Amount"));
        }
        //  if (e.Row.RowType == DataControlRowType.Footer)
        {
            //  Label lbl_total = (Label)e.Row.FindControl("lbl_total");
            //  lbl_total.Text = total.ToString();
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
            // cgst = Dd_enter_cgst.Text;

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

            //Dd_enter_cgst.Text = cgst;
            //Dd_enter_igst.Text = igst;
            //Dd_enter_sgst.Text = sgst;
            txt_cgst.Text = cgst;
            txt_sgst.Text = sgst;
            txt_igst.Text = igst;

            Txt_description.Text = desc;

            lbl_product_hsn.Value = hsn;
            lbl_unit.Value = unit;


        }

    }



    protected void Btn_generate_pdf_Click(object sender, EventArgs e)
    {
        decimal new_balance;
        finaltotal = Math.Round(Convert.ToDecimal(hide_total.Text));
        new_balance = finaltotal - Convert.ToDecimal(Txt_advance.Text);
        if (GridView1.Rows.Count == 0)
        {
            System.Web.UI.ScriptManager.RegisterStartupScript(this, GetType(), "displayalertmessage", "alert('Please Add Products First !!!');", true);
        }
        else
        {
            try
            {



                int rowscount = GridView1.Rows.Count;

                for (int i = 0; i < rowscount; i++)
                {
                    if (GridView1.Rows[i].Cells[2].Text == "&nbsp;")
                    {
                        SqlCommand cmd = new SqlCommand("insert into tbl_order_invoice values(@s_invoice_no,@s_date,@s_customer_name,@s_customer_contact,@s_customer_address,@s_customer_gst_no,@s_customer_email,@s_designer,@s_invoice_date,@s_due_date,@s_product_name,@s_quantity,@s_total_quantity,@s_rate,@s_discount,@s_cgstp,@s_cgsta,@s_sgstp,@s_sgsta,@s_igstp,@s_igsta,@s_amount,@s_sub_total,@s_total_gst,@s_shipping_charges,@s_adjustment,@s_total,@s_stotal,@s_hsn,@s_unit,@s_desc,@s_height,@s_width,@s_size,@s_samount,@s_status,@s_total_cgst,@s_total_sgst,@s_total_igst,@s_total_taxable,@s_balance,@est_dtp_charges,@est_fitting_framing,@est_payment_method)", conn);
                        cmd.Parameters.AddWithValue("@s_invoice_no", Convert.ToString(Txt_invoice.Text));
                        cmd.Parameters.AddWithValue("@s_date", Convert.ToDateTime(DateTime.Now.ToShortDateString()).ToString("MM/dd/yyyy"));
                        cmd.Parameters.AddWithValue("@s_customer_name", Convert.ToString(Dd_customer.SelectedItem.Text));
                        cmd.Parameters.AddWithValue("@s_customer_contact", Convert.ToString(lbl_cutomer_contact.Value));
                        cmd.Parameters.AddWithValue("@s_customer_address", Convert.ToString(lbl_cutomer_address.Value));
                        cmd.Parameters.AddWithValue("@s_customer_gst_no", Convert.ToString(lbl_cutomer_gst_no.Value));
                        cmd.Parameters.AddWithValue("@s_customer_email", Convert.ToString(lbl_cutomer_email.Value));
                        cmd.Parameters.AddWithValue("@s_designer", Convert.ToString(Dd_staff.SelectedItem.Text));
                        cmd.Parameters.AddWithValue("@s_invoice_date", Convert.ToDateTime(Txt_invoice_date.Text).ToString("MM/dd/yyyy"));
                        cmd.Parameters.AddWithValue("@s_due_date", Convert.ToDateTime(Txt_due_date.Text).ToString("MM/dd/yyyy"));
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
                        cmd.Parameters.AddWithValue("@s_shipping_charges",Convert.ToDecimal(Txt_shipping.Text));
                        cmd.Parameters.AddWithValue("@s_adjustment", Convert.ToDecimal(Txt_advance.Text));
                        cmd.Parameters.AddWithValue("@s_total", Convert.ToDecimal(hide_total.Text));
                        cmd.Parameters.AddWithValue("@s_stotal", Convert.ToDecimal(GridView1.Rows[i].Cells[8].Text));
                        cmd.Parameters.AddWithValue("@s_hsn", Convert.ToString(GridView1.Rows[i].Cells[1].Text));
                        cmd.Parameters.AddWithValue("@s_desc", Convert.ToString(GridView1.Rows[i].Cells[16].Text));
                        cmd.Parameters.AddWithValue("@s_height", "");
                        cmd.Parameters.AddWithValue("@s_width", "");
                        cmd.Parameters.AddWithValue("@s_size", "");
                        cmd.Parameters.AddWithValue("@s_samount", "");
                        cmd.Parameters.AddWithValue("@s_status", "Pending");
                        cmd.Parameters.AddWithValue("@s_total_cgst", Convert.ToDecimal(lbl_total_cgst.Value));
                        cmd.Parameters.AddWithValue("@s_total_sgst", Convert.ToDecimal(lbl_total_sgst.Value));
                        cmd.Parameters.AddWithValue("@s_total_igst", Convert.ToDecimal(lbl_total_igst.Value));
                        cmd.Parameters.AddWithValue("@s_total_taxable", Convert.ToDecimal(lbl_total_taxable.Value));
                        cmd.Parameters.AddWithValue("@s_balance", Convert.ToDecimal(new_balance));

                        //extra field charges
                        cmd.Parameters.AddWithValue("@est_dtp_charges", Convert.ToDecimal(Txt_dtp_charges.Text));
                        cmd.Parameters.AddWithValue("@est_fitting_framing", Convert.ToDecimal(Txt_Fitting_Framing.Text));
                        cmd.Parameters.AddWithValue("@est_payment_method", Convert.ToString(drp_payment.SelectedItem.Text));
                        //extra field charges


                        conn.Open();
                        cmd.ExecuteNonQuery();

                        conn.Close();
                    }
                    else
                    {
                        SqlCommand cmd = new SqlCommand("insert into tbl_order_invoice values(@s_invoice_no,@s_date,@s_customer_name,@s_customer_contact,@s_customer_address,@s_customer_gst_no,@s_customer_email,@s_designer,@s_invoice_date,@s_due_date,@s_product_name,@s_quantity,@s_total_quantity,@s_rate,@s_discount,@s_cgstp,@s_cgsta,@s_sgstp,@s_sgsta,@s_igstp,@s_igsta,@s_amount,@s_sub_total,@s_total_gst,@s_shipping_charges,@s_adjustment,@s_total,@s_stotal,@s_hsn,@s_unit,@s_desc,@s_height,@s_width,@s_size,@s_samount,@s_status,@s_total_cgst,@s_total_sgst,@s_total_igst,@s_total_taxable,@s_balance,@est_dtp_charges,@est_fitting_framing,@est_payment_method)", conn);
                        cmd.Parameters.AddWithValue("@s_invoice_no", Convert.ToString(Txt_invoice.Text));
                        cmd.Parameters.AddWithValue("@s_date", Convert.ToDateTime(DateTime.Now.ToShortDateString()).ToString("MM/dd/yyyy"));
                        cmd.Parameters.AddWithValue("@s_customer_name", Convert.ToString(Dd_customer.SelectedItem.Text));
                        cmd.Parameters.AddWithValue("@s_customer_contact", Convert.ToString(lbl_cutomer_contact.Value));
                        cmd.Parameters.AddWithValue("@s_customer_address", Convert.ToString(lbl_cutomer_address.Value));
                        cmd.Parameters.AddWithValue("@s_customer_gst_no", Convert.ToString(lbl_cutomer_gst_no.Value));
                        cmd.Parameters.AddWithValue("@s_customer_email", Convert.ToString(lbl_cutomer_email.Value));
                        cmd.Parameters.AddWithValue("@s_designer", Convert.ToString(Dd_staff.SelectedItem.Text));
                        cmd.Parameters.AddWithValue("@s_invoice_date", Convert.ToDateTime(Txt_invoice_date.Text).ToString("MM/dd/yyyy"));
                        cmd.Parameters.AddWithValue("@s_due_date", Convert.ToDateTime(Txt_due_date.Text).ToString("MM/dd/yyyy"));
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
                        cmd.Parameters.AddWithValue("@s_shipping_charges",Convert.ToString(Txt_shipping.Text));
                        cmd.Parameters.AddWithValue("@s_adjustment", Convert.ToDecimal(Txt_advance.Text));
                        cmd.Parameters.AddWithValue("@s_total", Convert.ToDecimal(hide_total.Text));
                        cmd.Parameters.AddWithValue("@s_stotal", Convert.ToDecimal(GridView1.Rows[i].Cells[8].Text));
                        cmd.Parameters.AddWithValue("@s_hsn", Convert.ToString(GridView1.Rows[i].Cells[1].Text));
                        cmd.Parameters.AddWithValue("@s_desc", Convert.ToString(GridView1.Rows[i].Cells[16].Text));
                        cmd.Parameters.AddWithValue("@s_height", Convert.ToDecimal(GridView1.Rows[i].Cells[2].Text));
                        cmd.Parameters.AddWithValue("@s_width", Convert.ToDecimal(GridView1.Rows[i].Cells[3].Text));
                        cmd.Parameters.AddWithValue("@s_size", Convert.ToDecimal(GridView1.Rows[i].Cells[4].Text));
                        cmd.Parameters.AddWithValue("@s_samount", Convert.ToDecimal(GridView1.Rows[i].Cells[6].Text));
                        cmd.Parameters.AddWithValue("@s_status", "Pending");
                        cmd.Parameters.AddWithValue("@s_total_cgst", Convert.ToDecimal(lbl_total_cgst.Value));
                        cmd.Parameters.AddWithValue("@s_total_sgst", Convert.ToDecimal(lbl_total_sgst.Value));
                        cmd.Parameters.AddWithValue("@s_total_igst", Convert.ToDecimal(lbl_total_igst.Value));
                        cmd.Parameters.AddWithValue("@s_total_taxable", Convert.ToDecimal(lbl_total_taxable.Value));
                        cmd.Parameters.AddWithValue("@s_balance", Convert.ToDecimal(new_balance));

                        //extra field charges
                        cmd.Parameters.AddWithValue("@est_dtp_charges", Convert.ToDecimal(Txt_dtp_charges.Text));
                        cmd.Parameters.AddWithValue("@est_fitting_framing", Convert.ToDecimal(Txt_Fitting_Framing.Text));
                        cmd.Parameters.AddWithValue("@est_payment_method", Convert.ToString(drp_payment.SelectedItem.Text));
                        //extra field charges
                        conn.Open();
                        cmd.ExecuteNonQuery();

                        conn.Close();
                    }
                }
                SqlCommand cmd2 = new SqlCommand("insert into tbl_order values(@sl_invoice_no,@sl_date,@sl_customer_name,@sl_customer_contact,@sl_customer_address,@sl_customer_gst_no,@sl_customer_email,@sl_designer,@sl_invoice_date,@sl_due_date,@sl_total_quantity,@sl_discount,@sl_sub_total,@sl_total_gst,@sl_shipping_charges,@sl_adjustment,@sl_total,@sl_total_cgst,@sl_total_sgst,@sl_total_igst,@sl_total_taxable,@sl_balance,@est_dtp_charges,@est_fitting_framing,@est_payment_method)", conn);
                cmd2.Parameters.AddWithValue("@sl_invoice_no", Convert.ToString(Txt_invoice.Text));
                cmd2.Parameters.AddWithValue("@sl_date", Convert.ToDateTime(DateTime.Now.ToShortDateString()).ToString("MM/dd/yyyy"));
                cmd2.Parameters.AddWithValue("@sl_customer_name", Convert.ToString(Dd_customer.SelectedItem.Text));
                cmd2.Parameters.AddWithValue("@sl_customer_contact", Convert.ToString(lbl_cutomer_contact.Value));
                cmd2.Parameters.AddWithValue("@sl_customer_address", Convert.ToString(lbl_cutomer_address.Value));
                cmd2.Parameters.AddWithValue("@sl_customer_gst_no", Convert.ToString(lbl_cutomer_gst_no.Value));
                cmd2.Parameters.AddWithValue("@sl_customer_email", Convert.ToString(lbl_cutomer_email.Value));
                cmd2.Parameters.AddWithValue("@sl_designer", Convert.ToString(Dd_staff.SelectedItem.Text));
                cmd2.Parameters.AddWithValue("@sl_invoice_date", Convert.ToDateTime(Txt_invoice_date.Text).ToString("MM/dd/yyyy"));
                cmd2.Parameters.AddWithValue("@sl_due_date", Convert.ToDateTime(Txt_due_date.Text).ToString("MM/dd/yyyy"));

                cmd2.Parameters.AddWithValue("@sl_total_quantity", Convert.ToDecimal(lbl_totalqty.Text));

                cmd2.Parameters.AddWithValue("@sl_discount", Convert.ToDecimal(Txt_discount.Text));


                cmd2.Parameters.AddWithValue("@sl_sub_total", Convert.ToDecimal(lbl_subtotal.Text));
                cmd2.Parameters.AddWithValue("@sl_total_gst", Convert.ToDecimal(lbl_gst.Text));
                cmd2.Parameters.AddWithValue("@sl_shipping_charges", Convert.ToString(Txt_shipping.Text));
                cmd2.Parameters.AddWithValue("@sl_adjustment", Convert.ToDecimal(Txt_advance.Text));
                cmd2.Parameters.AddWithValue("@sl_total", Convert.ToDecimal(hide_total.Text));
                cmd2.Parameters.AddWithValue("@sl_total_cgst", Convert.ToDecimal(lbl_total_cgst.Value));
                cmd2.Parameters.AddWithValue("@sl_total_sgst", Convert.ToDecimal(lbl_total_sgst.Value));
                cmd2.Parameters.AddWithValue("@sl_total_igst", Convert.ToDecimal(lbl_total_igst.Value));
                cmd2.Parameters.AddWithValue("@sl_total_taxable", Convert.ToDecimal(lbl_total_taxable.Value));
                cmd2.Parameters.AddWithValue("@sl_balance", Convert.ToDecimal(new_balance));


                //extra field charges
                cmd2.Parameters.AddWithValue("@est_dtp_charges", Convert.ToDecimal(Txt_dtp_charges.Text));
                cmd2.Parameters.AddWithValue("@est_fitting_framing", Convert.ToDecimal(Txt_Fitting_Framing.Text));
                cmd2.Parameters.AddWithValue("@est_payment_method", Convert.ToString(drp_payment.SelectedItem.Text));
                //extra field charges

                conn.Open();
                cmd2.ExecuteNonQuery();
                conn.Close();




                //SqlCommand cmd6 = new SqlCommand("update tbl_customer set c_opening_balance= @balance where c_name='" + Dd_customer.SelectedItem.Text + "'", conn);
                //decimal balance;
                //balance = Convert.ToDecimal(lbl_opening_balance.Value) + Convert.ToDecimal(new_balance);
                //cmd6.Parameters.Add("@balance", SqlDbType.Decimal).Value = balance;
                //conn.Open();
                //cmd6.ExecuteNonQuery();

                //conn.Close();

                Response.Redirect("list_of_order.aspx?insert=success");
            }
            catch (Exception ex)
            {

            }
            

        }
    }

    protected void Btn_submit_payment_Click(object sender, EventArgs e)
    {
        decimal new_balance;
        finaltotal = Math.Round(Convert.ToDecimal(hide_total.Text));
        new_balance = finaltotal - Convert.ToDecimal(Txt_advance.Text);

        if (GridView1.Rows.Count == 0)
        {
            System.Web.UI.ScriptManager.RegisterStartupScript(this, GetType(), "displayalertmessage", "alert('Please Add Products First !!!');", true);
        }
        else
        {
            try
            {

                finaltotal = Math.Round(Convert.ToDecimal(hide_total.Text));
                int rowscount = GridView1.Rows.Count;

                for (int i = 0; i < rowscount; i++)
                {
                    if (GridView1.Rows[i].Cells[2].Text == "&nbsp;")
                    {
                        SqlCommand cmd = new SqlCommand("insert into tbl_order_invoice values(@s_invoice_no,@s_date,@s_customer_name,@s_customer_contact,@s_customer_address,@s_customer_gst_no,@s_customer_email,@s_designer,@s_invoice_date,@s_due_date,@s_product_name,@s_quantity,@s_total_quantity,@s_rate,@s_discount,@s_cgstp,@s_cgsta,@s_sgstp,@s_sgsta,@s_igstp,@s_igsta,@s_amount,@s_sub_total,@s_total_gst,@s_shipping_charges,@s_adjustment,@s_total,@s_stotal,@s_hsn,@s_unit,@s_desc,@s_height,@s_width,@s_size,@s_samount,@s_status,@s_total_cgst,@s_total_sgst,@s_total_igst,@s_total_taxable,@s_balance,@est_dtp_charges,@est_fitting_framing,@est_payment_method)", conn);
                        cmd.Parameters.AddWithValue("@s_invoice_no", Convert.ToString(Txt_invoice.Text));
                        cmd.Parameters.AddWithValue("@s_date", Convert.ToDateTime(DateTime.Now.ToShortDateString()).ToString("MM/dd/yyyy"));
                        cmd.Parameters.AddWithValue("@s_customer_name", Convert.ToString(Dd_customer.SelectedItem.Text));
                        cmd.Parameters.AddWithValue("@s_customer_contact", Convert.ToString(lbl_cutomer_contact.Value));
                        cmd.Parameters.AddWithValue("@s_customer_address", Convert.ToString(lbl_cutomer_address.Value));
                        cmd.Parameters.AddWithValue("@s_customer_gst_no", Convert.ToString(lbl_cutomer_gst_no.Value));
                        cmd.Parameters.AddWithValue("@s_customer_email", Convert.ToString(lbl_cutomer_email.Value));
                        cmd.Parameters.AddWithValue("@s_designer", Convert.ToString(Dd_staff.SelectedItem.Text));
                        cmd.Parameters.AddWithValue("@s_invoice_date", Convert.ToDateTime(Txt_invoice_date.Text).ToString("MM/dd/yyyy"));
                        cmd.Parameters.AddWithValue("@s_due_date", Convert.ToDateTime(Txt_due_date.Text).ToString("MM/dd/yyyy"));
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
                        cmd.Parameters.AddWithValue("@s_shipping_charges",Convert.ToString(Txt_shipping.Text));
                        cmd.Parameters.AddWithValue("@s_adjustment", Convert.ToDecimal(Txt_advance.Text));
                        cmd.Parameters.AddWithValue("@s_total", Convert.ToDecimal(hide_total.Text));
                        cmd.Parameters.AddWithValue("@s_stotal", Convert.ToDecimal(GridView1.Rows[i].Cells[8].Text));
                        cmd.Parameters.AddWithValue("@s_hsn", Convert.ToString(GridView1.Rows[i].Cells[1].Text));
                        cmd.Parameters.AddWithValue("@s_desc", Convert.ToString(GridView1.Rows[i].Cells[16].Text));
                        cmd.Parameters.AddWithValue("@s_height", "");
                        cmd.Parameters.AddWithValue("@s_width", "");
                        cmd.Parameters.AddWithValue("@s_size", "");
                        cmd.Parameters.AddWithValue("@s_samount", "");
                        cmd.Parameters.AddWithValue("@s_status", "Pending");
                        cmd.Parameters.AddWithValue("@s_total_cgst", Convert.ToDecimal(lbl_total_cgst.Value));
                        cmd.Parameters.AddWithValue("@s_total_sgst", Convert.ToDecimal(lbl_total_sgst.Value));
                        cmd.Parameters.AddWithValue("@s_total_igst", Convert.ToDecimal(lbl_total_igst.Value));
                        cmd.Parameters.AddWithValue("@s_total_taxable", Convert.ToDecimal(lbl_total_taxable.Value));
                        cmd.Parameters.AddWithValue("@s_balance", Convert.ToDecimal(new_balance));

                        //extra field charges
                        cmd.Parameters.AddWithValue("@est_dtp_charges", Convert.ToDecimal(Txt_dtp_charges.Text));
                        cmd.Parameters.AddWithValue("@est_fitting_framing", Convert.ToDecimal(Txt_Fitting_Framing.Text));
                        cmd.Parameters.AddWithValue("@est_payment_method", Convert.ToString(drp_payment.SelectedItem.Text));
                        //extra field charges

                        conn.Open();
                        cmd.ExecuteNonQuery();

                        conn.Close();
                    }
                    else
                    {
                        SqlCommand cmd = new SqlCommand("insert into tbl_order_invoice values(@s_invoice_no,@s_date,@s_customer_name,@s_customer_contact,@s_customer_address,@s_customer_gst_no,@s_customer_email,@s_designer,@s_invoice_date,@s_due_date,@s_product_name,@s_quantity,@s_total_quantity,@s_rate,@s_discount,@s_cgstp,@s_cgsta,@s_sgstp,@s_sgsta,@s_igstp,@s_igsta,@s_amount,@s_sub_total,@s_total_gst,@s_shipping_charges,@s_adjustment,@s_total,@s_stotal,@s_hsn,@s_unit,@s_desc,@s_height,@s_width,@s_size,@s_samount,@s_status,@s_total_cgst,@s_total_sgst,@s_total_igst,@s_total_taxable,@s_balance,@est_dtp_charges,@est_fitting_framing,@est_payment_method)", conn);
                        cmd.Parameters.AddWithValue("@s_invoice_no", Convert.ToString(Txt_invoice.Text));
                        cmd.Parameters.AddWithValue("@s_date", Convert.ToDateTime(DateTime.Now.ToShortDateString()).ToString("MM/dd/yyyy"));
                        cmd.Parameters.AddWithValue("@s_customer_name", Convert.ToString(Dd_customer.SelectedItem.Text));
                        cmd.Parameters.AddWithValue("@s_customer_contact", Convert.ToString(lbl_cutomer_contact.Value));
                        cmd.Parameters.AddWithValue("@s_customer_address", Convert.ToString(lbl_cutomer_address.Value));
                        cmd.Parameters.AddWithValue("@s_customer_gst_no", Convert.ToString(lbl_cutomer_gst_no.Value));
                        cmd.Parameters.AddWithValue("@s_customer_email", Convert.ToString(lbl_cutomer_email.Value));
                        cmd.Parameters.AddWithValue("@s_designer", Convert.ToString(Dd_staff.SelectedItem.Text));
                        cmd.Parameters.AddWithValue("@s_invoice_date", Convert.ToDateTime(Txt_invoice_date.Text).ToString("MM/dd/yyyy"));
                        cmd.Parameters.AddWithValue("@s_due_date", Convert.ToDateTime(Txt_due_date.Text).ToString("MM/dd/yyyy"));
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
                        cmd.Parameters.AddWithValue("@s_status", "Pending");
                        cmd.Parameters.AddWithValue("@s_total_cgst", Convert.ToDecimal(lbl_total_cgst.Value));
                        cmd.Parameters.AddWithValue("@s_total_sgst", Convert.ToDecimal(lbl_total_sgst.Value));
                        cmd.Parameters.AddWithValue("@s_total_igst", Convert.ToDecimal(lbl_total_igst.Value));
                        cmd.Parameters.AddWithValue("@s_total_taxable", Convert.ToDecimal(lbl_total_taxable.Value));
                        cmd.Parameters.AddWithValue("@s_balance", Convert.ToDecimal(new_balance));

                        //extra field charges
                        cmd.Parameters.AddWithValue("@est_dtp_charges", Convert.ToDecimal(Txt_dtp_charges.Text));
                        cmd.Parameters.AddWithValue("@est_fitting_framing", Convert.ToDecimal(Txt_Fitting_Framing.Text));
                        cmd.Parameters.AddWithValue("@est_payment_method", Convert.ToString(drp_payment.SelectedItem.Text));
                        //extra field charges

                        conn.Open();
                        cmd.ExecuteNonQuery();

                        conn.Close();
                    }
                }
                SqlCommand cmd2 = new SqlCommand("insert into tbl_order values(@sl_invoice_no,@sl_date,@sl_customer_name,@sl_customer_contact,@sl_customer_address,@sl_customer_gst_no,@sl_customer_email,@sl_designer,@sl_invoice_date,@sl_due_date,@sl_total_quantity,@sl_discount,@sl_sub_total,@sl_total_gst,@sl_shipping_charges,@sl_adjustment,@sl_total,@sl_total_cgst,@sl_total_sgst,@sl_total_igst,@sl_total_taxable,@sl_balance,,@est_dtp_charges,@est_fitting_framing,@est_payment_method)", conn);
                cmd2.Parameters.AddWithValue("@sl_invoice_no", Convert.ToString(Txt_invoice.Text));
                cmd2.Parameters.AddWithValue("@sl_date", Convert.ToDateTime(DateTime.Now.ToShortDateString()).ToString("MM/dd/yyyy"));
                cmd2.Parameters.AddWithValue("@sl_customer_name", Convert.ToString(Dd_customer.SelectedItem.Text));
                cmd2.Parameters.AddWithValue("@sl_customer_contact", Convert.ToString(lbl_cutomer_contact.Value));
                cmd2.Parameters.AddWithValue("@sl_customer_address", Convert.ToString(lbl_cutomer_address.Value));
                cmd2.Parameters.AddWithValue("@sl_customer_gst_no", Convert.ToString(lbl_cutomer_gst_no.Value));
                cmd2.Parameters.AddWithValue("@sl_customer_email", Convert.ToString(lbl_cutomer_email.Value));
                cmd2.Parameters.AddWithValue("@sl_designer", Convert.ToString(Dd_staff.SelectedItem.Text));
                cmd2.Parameters.AddWithValue("@sl_invoice_date", Convert.ToDateTime(Txt_invoice_date.Text).ToString("MM/dd/yyyy"));
                cmd2.Parameters.AddWithValue("@sl_due_date", Convert.ToDateTime(Txt_due_date.Text).ToString("MM/dd/yyyy"));

                cmd2.Parameters.AddWithValue("@sl_total_quantity", Convert.ToDecimal(lbl_totalqty.Text));

                cmd2.Parameters.AddWithValue("@sl_discount", Convert.ToDecimal(Txt_discount.Text));


                cmd2.Parameters.AddWithValue("@sl_sub_total", Convert.ToDecimal(lbl_subtotal.Text));
                cmd2.Parameters.AddWithValue("@sl_total_gst", Convert.ToDecimal(lbl_gst.Text));
                cmd2.Parameters.AddWithValue("@sl_shipping_charges", "");
                cmd2.Parameters.AddWithValue("@sl_adjustment", Convert.ToDecimal(Txt_advance.Text));
                cmd2.Parameters.AddWithValue("@sl_total", Convert.ToDecimal(hide_total.Text));
                cmd2.Parameters.AddWithValue("@sl_total_cgst", Convert.ToDecimal(lbl_total_cgst.Value));
                cmd2.Parameters.AddWithValue("@sl_total_sgst", Convert.ToDecimal(lbl_total_sgst.Value));
                cmd2.Parameters.AddWithValue("@sl_total_igst", Convert.ToDecimal(lbl_total_igst.Value));
                cmd2.Parameters.AddWithValue("@sl_total_taxable", Convert.ToDecimal(lbl_total_taxable.Value));
                cmd2.Parameters.AddWithValue("@sl_balance", Convert.ToDecimal(new_balance));

                //extra field charges
                cmd2.Parameters.AddWithValue("@est_dtp_charges", Convert.ToDecimal(Txt_dtp_charges.Text));
                cmd2.Parameters.AddWithValue("@est_fitting_framing", Convert.ToDecimal(Txt_Fitting_Framing.Text));
                cmd2.Parameters.AddWithValue("@est_payment_method", Convert.ToString(drp_payment.SelectedItem.Text));
                //extra field charges

                conn.Open();
                cmd2.ExecuteNonQuery();
                conn.Close();




                //SqlCommand cmd6 = new SqlCommand("update tbl_customer set c_opening_balance= @balance where c_name='" + Dd_customer.SelectedItem.Text + "'", conn);
                //decimal balance;
                //balance = Convert.ToDecimal(lbl_opening_balance.Value) + Convert.ToDecimal(new_balance);
                //cmd6.Parameters.Add("@balance", SqlDbType.Decimal).Value = balance;
                //conn.Open();
                //cmd6.ExecuteNonQuery();

                //conn.Close();

                string redirectScript = " window.location.href = 'bill.aspx?invoice=" + Txt_invoice.Text + "';";
                System.Web.UI.ScriptManager.RegisterStartupScript(this, GetType(), "displayalertmessage", "alert('New Order Added Successfully!!!');" + redirectScript, true);

            }
            catch (Exception ex) { }

           
                
           
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

            // cgst = Dd_enter_cgst.Text;
            lbl_cutomer_contact.Value = contact;
            lbl_cutomer_address.Value = address;
            lbl_cutomer_gst_no.Value = gst;
            lbl_opening_balance.Value = balance;
            lbl_cutomer_email.Value = email;

            
        }
    }








    protected void GridView1_RowDeleted(object sender, GridViewDeletedEventArgs e)
    {

    }

    protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        int index = Convert.ToInt32(e.RowIndex);
        DataTable dt = ViewState["Details"] as DataTable;
        dt.Rows[index].Delete();
        ViewState["Details"] = dt;
        GridView1.DataSource = dt;
        GridView1.DataBind();
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        SqlCommand cmd6 = new SqlCommand("Select * from tbl_customer where c_name='" + Txt_customer_name.Text.Trim() + "' OR c_contact='" + Txt_contact.Text.Trim() + "' ", conn);
        //cmd2.Parameters.AddWithValue("@c_name", this.Txt_customer_name.Text);
        adapt6 = new SqlDataAdapter(cmd6);
        dt6 = new DataTable();
        adapt6.Fill(dt6);


        //var result = cmd2.ExecuteScalar();
        if (dt6.Rows.Count > 0)
        {
            lbl_msg.Text = "Customer Already Exist!!!";
        }
        else
        {
            SqlCommand cmd7 = new SqlCommand("insert into tbl_customer values(@c_name,@c_address,@c_contact,@c_contact2,@c_gst_no,@c_opening_balance,@c_email)", conn);
            cmd7.Parameters.AddWithValue("@c_name", Txt_customer_name.Text);
   
            cmd7.Parameters.AddWithValue("@c_address", Txt_address.Text);
        //    cmd7.Parameters.AddWithValue("@c_city", Dd_city.SelectedItem.Text);
            cmd7.Parameters.AddWithValue("@c_contact", Txt_contact.Text);
            cmd7.Parameters.AddWithValue("@c_contact2", "0");
            cmd7.Parameters.AddWithValue("@c_gst_no", "0");

            if (Txt_opening_balance.Text == string.Empty)
            {
                cmd7.Parameters.AddWithValue("@c_opening_balance", 0);
            }
            else
            {
                cmd7.Parameters.AddWithValue("@c_opening_balance", Txt_opening_balance.Text);
            }

            cmd7.Parameters.AddWithValue("@c_email", Txt_email.Text);
            conn.Open();
            cmd7.ExecuteNonQuery();
            conn.Close();
            //Lbl_message.Text = "" + Txt_customer_name.Text + " Added Successfully!!!";
            // Page.Response.Redirect(Page.Request.RawUrl.ToString(), true);
            string redirectScript = " window.location.href = 'order.aspx';";
            System.Web.UI.ScriptManager.RegisterStartupScript(this, GetType(), "displayalertmessage", "alert('New Customer Added Successfully!!!');" + redirectScript, true);

        }
    }

    protected void Button2_Click(object sender, EventArgs e)
    {

        SqlCommand cmd8 = new SqlCommand("Select * from tbl_product where p_name='" + Txt_product_name.Text.Trim() + "'", conn);
        //cmd2.Parameters.AddWithValue("@c_name", this.Txt_customer_name.Text);
        adapt8 = new SqlDataAdapter(cmd8);
        DataTable dt8 = new DataTable();
        adapt8.Fill(dt8);


        //var result = cmd2.ExecuteScalar();
        if (dt8.Rows.Count > 0)
        {
            lbl_msg2.Text = "Product Already Exist!!!";

        }
        else
        {
            SqlCommand cmd9 = new SqlCommand("insert into tbl_product values(@p_name,@p_unit,@p_cgst,@p_sgst,@p_igst,@p_hsn_code,@p_rate,@p_desc)", conn);
            cmd9.Parameters.AddWithValue("@p_name", Txt_product_name.Text);
            cmd9.Parameters.AddWithValue("@p_unit", Dd_unit.SelectedItem.Text);
            cmd9.Parameters.AddWithValue("@p_cgst", Dd_cgst.SelectedValue);
            cmd9.Parameters.AddWithValue("@p_sgst", Dd_sgst.SelectedValue);
            cmd9.Parameters.AddWithValue("@p_igst", Dd_igst.SelectedValue);
            cmd9.Parameters.AddWithValue("@p_hsn_code", Txt_hsn.Text);
            cmd9.Parameters.AddWithValue("@p_rate", Txt_ra.Text);
            cmd9.Parameters.AddWithValue("@p_desc", Txt_desc.Text);
            conn.Open();
            cmd9.ExecuteNonQuery();
            conn.Close();
            // Lbl_message.Text = "" + Txt_product_name.Text + " Added Successfully!!!";
            // Page.Response.Redirect(Page.Request.RawUrl.ToString(), true);
            string redirectScript = " window.location.href = 'order.aspx';";
            System.Web.UI.ScriptManager.RegisterStartupScript(this, GetType(), "displayalertmessage", "alert('New Sale Product Added Successfully!!!');" + redirectScript, true);


        }
    }



}