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

public partial class Daily_Cash_Order_Create_Order : System.Web.UI.Page
{
    SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["String"].ConnectionString);
    decimal total_amount = 0, final_total = 0;
    decimal totalvalue = 0, totalcgst = 0, totalsgst = 0, totaligst = 0, totalgst = 0, totalqty, finaltotal;
    string key, country, senderid, route, email, password, port, subject, smtp, com_email;
    int sms, mail2;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["a_email"] != null)
        {
            if (!IsPostBack)
            {

                Panel1.Visible = true;
                Panel2.Visible = false;
                this.invoiceid();
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

  
    public void product()
    {
        string query = "select * from tbl_product ORDER BY p_name asc";
        SqlDataAdapter adapt = new SqlDataAdapter(query, conn);
        DataTable dt = new DataTable();
        adapt.Fill(dt);
        if (dt.Rows.Count > 0)
        {
            Dd_enter_product.DataSource = dt;
            Dd_enter_product.DataBind();
            Dd_enter_product.DataTextField = "p_name";

            Dd_enter_product.DataValueField = "p_id";
            Dd_enter_product.DataBind();
            Dd_enter_product.Items.Insert(0, new ListItem("--Select--", "--Select--"));
            Dd_enter_product.SelectedItem.Selected = false;
            Dd_enter_product.Items.FindByText("--Select--").Selected = true;
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
            DataTable dt = (DataTable)ViewState["Details"];
            dt.Rows.Add(str, str10, height2, width2, sqrft2, rate2, amount2, quantity2, total2, desc, str9);
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


        else if (str9 == "Ltr")
        {
            DataTable dt = (DataTable)ViewState["Details"];
            dt.Rows.Add(str, str10, height2, width2, sqrft2, rate2, amount2, quantity2, total2, desc, str9);
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

        //Packet
        else if (str9 == "Packet")
        {
            DataTable dt = (DataTable)ViewState["Details"];
            dt.Rows.Add(str, str10, height2, width2, sqrft2, rate2, amount2, quantity2, total2, desc, str9);
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

        //copy 
        else if (str9 == "Copy")
        {
            DataTable dt = (DataTable)ViewState["Details"];
            dt.Rows.Add(str, str10, height2, width2, sqrft2, rate2, amount2, quantity2, total2, desc, str9);
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
            DataTable dt = (DataTable)ViewState["Details"];
            dt.Rows.Add(str, str10, height, width, sqrft, rate, amount, quantity, total, desc, str9);
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
            e.Row.Cells[9].Visible = false;
            e.Row.Cells[10].Visible = false;

        }
        //Check if the current row is datarow or not
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            //Add the value of column
            totalqty += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "Qty"));
            totalvalue += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "Total"));


        }
        if (e.Row.RowType == DataControlRowType.Footer)
        {

            //Find the control label in footer 
            Label lblamount = (Label)e.Row.FindControl("lbl_subtotal");
            //Assign the total value to footer label control
            lbl_subtotal.Text = totalvalue.ToString();
            lbl_subtotal2.Value = totalvalue.ToString();

            //Assign the total value to footer label control

            lbl_totalqty.Text = totalqty.ToString();
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
            //customer wise rate system code here 
     

            //end hrere

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
            //packet
            else if (unit == "Packet")
            {
                Panel1.Visible = false;
                Panel2.Visible = true;
                txt_rate2.Text = rate;
                
            }
            //copy
            else if (unit == "Copy")
            {
                Panel1.Visible = false;
                Panel2.Visible = true;
                txt_rate2.Text = rate;
                txt_width2.Text = "0";

                txt_height2.Text = "0";
            }


            else
            {
                Panel1.Visible = true;
                Panel2.Visible = false;
                txt_rate.Text = rate;
                txt_width.Text = "0";
                txt_height.Text = "0";
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
    public void invoiceid()
    {

        try
        {
            conn.Open();

            SqlCommand cmd = new SqlCommand("SELECT TOP 1 quw_no FROM tbl_order ORDER BY quw_id DESC", conn);
            string inv;
            int i = 0;
            SqlDataAdapter adapt = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            adapt.Fill(dt);



            if (dt.Rows.Count > 0)
            {
                inv = dt.Rows[0]["quw_no"].ToString();

            }
            else
            {
                inv = "0";
            }


            string letters = string.Empty;
            string numbers = string.Empty;

            foreach (char c in inv)
            {
                if (Char.IsNumber(c))
                {
                    numbers += c;
                }
            }
            i = Convert.ToInt32(numbers);
            if (i > 0)
            {
                int j = i + 1;
                Hid_inv_id.Value = "CASH-" + j.ToString();

            }

            else
            {
                Hid_inv_id.Value = "CASH-1";
            }




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


    private bool dataEntry()
    {
        System.Threading.Thread.Sleep(5000);
        bool isTrue = true;
        try
        {
            decimal new_balance;
            finaltotal = Math.Round(Convert.ToDecimal(hide_total.Text));
            new_balance = finaltotal - Convert.ToDecimal(Txt_advance.Text) - Convert.ToDecimal(Txt_discount.Text); 
            if (GridView1.Rows.Count == 0)
            {
                System.Web.UI.ScriptManager.RegisterStartupScript(this, GetType(), "displayalertmessage", "alert('Please Add Products First !!!');", true);
            }
            else
            {


                int rowscount = GridView1.Rows.Count;
                for (int i = 0; i < rowscount; i++)
                {
                    if (GridView1.Rows[i].Cells[2].Text == "&nbsp;")
                    {
                        SqlCommand cmd = new SqlCommand("insert into tbl_order_details values(@quw_no,@qw_date,@qw_product_name,@qw_quantity,@qw_total_quantity,@qw_rate,@qw_discount,@qw_sub_total,@qw_shipping_charges,@qw_adjustment,@qw_total,@qw_hsn,@qw_unit,@qw_stotal,@qw_desc,@qw_height,@qw_width,@qw_size,@qw_samount,@qw_name,@qw_phone,@qw_balance,@qw_dtp_charges,@qw_fitting_charges,@qw_payment_method,@qw_pasting_charges)", conn);
                        cmd.Parameters.AddWithValue("@quw_no", Convert.ToString(Hid_inv_id.Value));
                        cmd.Parameters.AddWithValue("@qw_date", Convert.ToDateTime(DateTime.Now.ToShortDateString()).ToString("MM/dd/yyyy"));
                   //     cmd.Parameters.AddWithValue("@c_id", Convert.ToString(Dd_customer.SelectedValue));
                   //     cmd.Parameters.AddWithValue("@qw_order_no", Convert.ToString(Txt_order_no.Text));
                     //   cmd.Parameters.AddWithValue("@qw_quotation_date", Convert.ToDateTime(Txt_invoice_date.Text).ToString("MM/dd/yyyy"));
                   //     cmd.Parameters.AddWithValue("@qw_valid_date", Convert.ToDateTime(Txt_due_date.Text).ToString("MM/dd/yyyy"));
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
                            cmd.Parameters.AddWithValue("@qw_shipping_charges", Convert.ToDecimal(Txt_TransportCharges.Text));
                        }

                        
                        cmd.Parameters.AddWithValue("@qw_adjustment", Txt_advance.Text);
                        cmd.Parameters.AddWithValue("@qw_total", Convert.ToDecimal(hide_total.Text));
                        cmd.Parameters.AddWithValue("@qw_stotal", Convert.ToDecimal(GridView1.Rows[i].Cells[8].Text));
                        cmd.Parameters.AddWithValue("@qw_hsn", Convert.ToString(GridView1.Rows[i].Cells[1].Text));
                        cmd.Parameters.AddWithValue("@qw_desc", Convert.ToString(GridView1.Rows[i].Cells[9].Text));
                        cmd.Parameters.AddWithValue("@qw_height", "");
                        cmd.Parameters.AddWithValue("@qw_width", "");
                        cmd.Parameters.AddWithValue("@qw_size", "");
                        cmd.Parameters.AddWithValue("@qw_samount", "");
                        cmd.Parameters.AddWithValue("@qw_name", Txt_name.Text);
                        cmd.Parameters.AddWithValue("@qw_phone", Txt_phone.Text);
                        cmd.Parameters.AddWithValue("@qw_balance", Convert.ToDecimal(new_balance));

                        if (Txt_Dtp_charges.Text == "")
                        {
                            cmd.Parameters.AddWithValue("@qw_dtp_charges", "0");
                        }
                        else
                        {
                            cmd.Parameters.AddWithValue("@qw_dtp_charges", Convert.ToDecimal(Txt_Dtp_charges.Text));
                        }

                        if (Txt_Fitting.Text == "")
                        {
                            cmd.Parameters.AddWithValue("@qw_fitting_charges", "0");
                        }
                        else
                        {
                            cmd.Parameters.AddWithValue("@qw_fitting_charges", Convert.ToDecimal(Txt_Fitting.Text));
                        }

                
                        cmd.Parameters.AddWithValue("@qw_payment_method", Convert.ToString(drp_payment.SelectedItem.Text));                                    
                       

                        if (Txt_Pasting.Text == "")
                        {
                            cmd.Parameters.AddWithValue("@qw_pasting_charges", "0");
                        }
                        else
                        {
                            cmd.Parameters.AddWithValue("@qw_pasting_charges", Convert.ToDecimal(Txt_Pasting.Text));
                        }

                        conn.Open();
                        cmd.ExecuteNonQuery();

                        conn.Close();
                    }
                    else
                    {

                        SqlCommand cmd = new SqlCommand("insert into tbl_order_details values(@quw_no,@qw_date,@qw_product_name,@qw_quantity,@qw_total_quantity,@qw_rate,@qw_discount,@qw_sub_total,@qw_shipping_charges,@qw_adjustment,@qw_total,@qw_hsn,@qw_unit,@qw_stotal,@qw_desc,@qw_height,@qw_width,@qw_size,@qw_samount,@qw_name,@qw_phone,@qw_balance,@qw_dtp_charges,@qw_fitting_charges,@qw_payment_method,@qw_pasting_charges)", conn);
                        cmd.Parameters.AddWithValue("@quw_no", Convert.ToString(Hid_inv_id.Value));
                        cmd.Parameters.AddWithValue("@qw_date", Convert.ToDateTime(DateTime.Now.ToShortDateString()).ToString("MM/dd/yyyy"));
                   //     cmd.Parameters.AddWithValue("@c_id", Convert.ToString(Dd_customer.SelectedValue));
                  //      cmd.Parameters.AddWithValue("@qw_order_no", Convert.ToString(Txt_order_no.Text));
                 //       cmd.Parameters.AddWithValue("@qw_quotation_date", Convert.ToDateTime(Txt_invoice_date.Text).ToString("MM/dd/yyyy"));
                 //       cmd.Parameters.AddWithValue("@qw_valid_date", Convert.ToDateTime(Txt_due_date.Text).ToString("MM/dd/yyyy"));
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
                            cmd.Parameters.AddWithValue("@qw_shipping_charges", Convert.ToDecimal(Txt_TransportCharges.Text));
                        }

                        cmd.Parameters.AddWithValue("@qw_adjustment", Txt_advance.Text);
                        cmd.Parameters.AddWithValue("@qw_total", Convert.ToDecimal(hide_total.Text));
                        cmd.Parameters.AddWithValue("@qw_stotal", Convert.ToDecimal(GridView1.Rows[i].Cells[8].Text));
                        cmd.Parameters.AddWithValue("@qw_hsn", Convert.ToString(GridView1.Rows[i].Cells[1].Text));
                        cmd.Parameters.AddWithValue("@qw_desc", Convert.ToString(GridView1.Rows[i].Cells[9].Text));
                        cmd.Parameters.AddWithValue("@qw_height", Convert.ToDecimal(GridView1.Rows[i].Cells[2].Text));
                        cmd.Parameters.AddWithValue("@qw_width", Convert.ToDecimal(GridView1.Rows[i].Cells[3].Text));
                        cmd.Parameters.AddWithValue("@qw_size", Convert.ToDecimal(GridView1.Rows[i].Cells[4].Text));
                        cmd.Parameters.AddWithValue("@qw_samount", Convert.ToDecimal(GridView1.Rows[i].Cells[6].Text));
                        cmd.Parameters.AddWithValue("@qw_name", Txt_name.Text);
                        cmd.Parameters.AddWithValue("@qw_phone", Txt_phone.Text);
                        cmd.Parameters.AddWithValue("@qw_balance", Convert.ToDecimal(new_balance));

                        if (Txt_Dtp_charges.Text == "")
                        {
                            cmd.Parameters.AddWithValue("@qw_dtp_charges", "0");
                        }
                        else
                        {
                            cmd.Parameters.AddWithValue("@qw_dtp_charges", Convert.ToDecimal(Txt_Dtp_charges.Text));
                        }

                        if (Txt_Fitting.Text == "")
                        {
                            cmd.Parameters.AddWithValue("@qw_fitting_charges", "0");
                        }
                        else
                        {
                            cmd.Parameters.AddWithValue("@qw_fitting_charges", Convert.ToDecimal(Txt_Fitting.Text));
                        }

                        cmd.Parameters.AddWithValue("@qw_payment_method", Convert.ToString(drp_payment.SelectedItem.Text));

                        if (Txt_Pasting.Text == "")
                        {
                            cmd.Parameters.AddWithValue("@qw_pasting_charges", "0");
                        }
                        else
                        {
                            cmd.Parameters.AddWithValue("@qw_pasting_charges", Convert.ToDecimal(Txt_Pasting.Text));
                        }

                        conn.Open();
                        cmd.ExecuteNonQuery();
                        conn.Close();
                    }
                }
                SqlCommand cmd2 = new SqlCommand("insert into tbl_order values(@quw_no,@quw_date,@quw_total_quantity,@quw_discount,@quw_sub_total,@quw_shipping_charges,@quw_adjustment,@quw_total,@quw_name,@quw_phone,@quw_balance,@quw_dtp_charges,@quw_fitting_charges,@quw_payment_method,@quw_pasting_charges)", conn);
                cmd2.Parameters.AddWithValue("@quw_no", Convert.ToString(Hid_inv_id.Value));
                cmd2.Parameters.AddWithValue("@quw_date", Convert.ToDateTime(DateTime.Now.ToShortDateString()).ToString("MM/dd/yyyy"));
       //         cmd2.Parameters.AddWithValue("@c_id", Convert.ToString(Dd_customer.SelectedValue));
       //         cmd2.Parameters.AddWithValue("@quw_order_no", Convert.ToString(Txt_order_no.Text));
       //         cmd2.Parameters.AddWithValue("@quw_invoice_date", Convert.ToDateTime(Txt_invoice_date.Text).ToString("MM/dd/yyyy"));
        //        cmd2.Parameters.AddWithValue("@quw_due_date", Convert.ToDateTime(Txt_due_date.Text).ToString("MM/dd/yyyy"));

                cmd2.Parameters.AddWithValue("@quw_total_quantity", Convert.ToDecimal(lbl_totalqty.Text));

                cmd2.Parameters.AddWithValue("@quw_discount", Convert.ToDecimal(Txt_discount.Text));


                cmd2.Parameters.AddWithValue("@quw_sub_total", Convert.ToDecimal(lbl_subtotal.Text));

                if (Txt_TransportCharges.Text == "")
                {
                    cmd2.Parameters.AddWithValue("@quw_shipping_charges", "0");
                }
                else
                {
                    cmd2.Parameters.AddWithValue("@quw_shipping_charges", Convert.ToDecimal(Txt_TransportCharges.Text));
                }

               
                cmd2.Parameters.AddWithValue("@quw_adjustment", Txt_advance.Text);
                cmd2.Parameters.AddWithValue("@quw_total", Convert.ToDecimal(hide_total.Text));
                cmd2.Parameters.AddWithValue("@quw_name", Txt_name.Text);
                cmd2.Parameters.AddWithValue("@quw_phone", Txt_phone.Text);
                cmd2.Parameters.AddWithValue("@quw_balance", Convert.ToDecimal(new_balance));

                if (Txt_Dtp_charges.Text == "")
                {
                    cmd2.Parameters.AddWithValue("@quw_dtp_charges", "0");
                }
                else
                {
                    cmd2.Parameters.AddWithValue("@quw_dtp_charges", Convert.ToDecimal(Txt_Dtp_charges.Text));
                }

                if (Txt_Fitting.Text == "")
                {
                    cmd2.Parameters.AddWithValue("@quw_fitting_charges", "0");
                }
                else
                {
                    cmd2.Parameters.AddWithValue("@quw_fitting_charges", Convert.ToDecimal(Txt_Fitting.Text));
                }

               
                
                cmd2.Parameters.AddWithValue("@quw_payment_method", Convert.ToString(drp_payment.SelectedItem.Text));
                

                if (Txt_Pasting.Text == "")
                {
                    cmd2.Parameters.AddWithValue("@quw_pasting_charges", "0");
                }
                else
                {
                    cmd2.Parameters.AddWithValue("@quw_pasting_charges", Convert.ToDecimal(Txt_Pasting.Text));
                }

                conn.Open();
                cmd2.ExecuteNonQuery();
                conn.Close();

      
                isTrue = true;
            }
        }
        catch (Exception ex)
        {
            isTrue = false;
        }
        return isTrue;
    }


    protected void Btn_generate_pdf_Click(object sender, EventArgs e)
    {
        bool isTrue = dataEntry();
        if (isTrue == true)
        {
            //Response.Redirect("List_Of_Orders.aspx?insert=success");
            string redirectScript = " window.location.href = 'List_Of_Orders.aspx?insert=success';";
            System.Web.UI.ScriptManager.RegisterStartupScript(this, GetType(), "displayalertmessage", "alert('New Order Added Successfully!!!');" + redirectScript, true);
        }
        else
        {

        }
    }
    protected void Btn_submit_payment_Click(object sender, EventArgs e)
    {
        bool isTrue = dataEntry();
        if (isTrue == true)
        {
            string redirectScript = " window.location.href = List_Of_Orders.aspx";
            System.Web.UI.ScriptManager.RegisterStartupScript(this, GetType(), "displayalertmessage", "alert('New Order Added Successfully!!!');" + redirectScript, true);

        }
        else
        {

        }

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


 

    protected void Button2_Click(object sender, EventArgs e)
    {
        string hsn;
        if (Txt_hsn.Text == string.Empty)
        {
            hsn = "-";
        }
        else
        {
            hsn = Txt_hsn.Text;
        }

        SqlCommand cmd = new SqlCommand("Select * from tbl_product where p_name='" + Txt_product_name.Text.Trim() + "'", conn);

        SqlDataAdapter adapt = new SqlDataAdapter(cmd);
        DataTable dt = new DataTable();
        adapt.Fill(dt);

        if (dt.Rows.Count > 0)
        {
            lbl_msg2.ForeColor = System.Drawing.Color.Red;
            lbl_msg2.Text = "Product Already Exist!!!";

        }
        else
        {
            SqlCommand cmd2 = new SqlCommand("insert into tbl_product values(@p_name,@p_unit,@p_cgst,@p_sgst,@p_igst,@p_hsn_code,@p_rate,@p_desc)", conn);
            cmd2.Parameters.AddWithValue("@p_name", Txt_product_name.Text);
            cmd2.Parameters.AddWithValue("@p_unit", Dd_unit.SelectedItem.Text);
            cmd2.Parameters.AddWithValue("@p_cgst", "0");
            cmd2.Parameters.AddWithValue("@p_sgst", "0");
            cmd2.Parameters.AddWithValue("@p_igst", "0");
            cmd2.Parameters.AddWithValue("@p_hsn_code", hsn);
            cmd2.Parameters.AddWithValue("@p_rate", Txt_ra.Text);
            cmd2.Parameters.AddWithValue("@p_desc", Txt_desc.Text);
            conn.Open();
            cmd2.ExecuteNonQuery();
            conn.Close();
            product();
            lbl_msg2.ForeColor = System.Drawing.Color.Green;
            lbl_msg2.Text = "Product Added Successfully!!!";

            //string redirectScript = " window.location.href = 'sale_invoice.aspx';";
            //System.Web.UI.ScriptManager.RegisterStartupScript(this, GetType(), "displayalertmessage", "alert('New Sale Product Added Successfully!!!');" + redirectScript, true);


        }
    }
}