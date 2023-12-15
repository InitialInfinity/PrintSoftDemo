using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
public partial class Quotation_gst_quotation : System.Web.UI.Page
{
    SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["String"].ConnectionString);
    decimal total_amount = 0, final_total = 0;
    decimal totalvalue = 0, totalcgst = 0, totalsgst = 0, totaligst = 0, totalgst = 0, totalqty, totaltaxable = 0, finaltotal, design, advanced, discount, pasting, fitting, transport;

    protected void Page_Load(object sender, EventArgs e)
    {//hide_total.Visible = false;

        if (Session["a_email"] != null)
        {
            if (!IsPostBack)
            {
                //date time 
                DateTime serverTime = DateTime.Now; // gives you current Time in server timeZone
                DateTime utcTime = serverTime.ToUniversalTime(); // convert it to Utc using timezone setting of server computer

                TimeZoneInfo tzi = TimeZoneInfo.FindSystemTimeZoneById("India Standard Time");
                DateTime localTime = TimeZoneInfo.ConvertTimeFromUtc(utcTime, tzi); // convert from utc to local

                Txt_invoice_date.Text = localTime.ToString("yyyy-MM-dd");
                Txt_due_date.Text = localTime.ToString("yyyy-MM-dd");
                //end

                Panel1.Visible = true;
                Panel2.Visible = false;
                //Txt_invoice_date.Text = DateTime.Today.ToString("yyyy-MM-dd");
                //Txt_due_date.Text = DateTime.Today.ToString("yyyy-MM-dd");
                this.invoiceid();
                this.customer();
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
                Txt_Pasting.Text = "0";
                Txt_TransportCharges.Text = "0";
                Txt_Dtp_charges.Text = "0";
                Txt_Fitting.Text = "0";
                Txt_discount.Text = "0";
               
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
    public void invoiceid()
    {
        try
        {

            conn.Open();
            SqlCommand cmd = new SqlCommand("SELECT MAX(qu_id) FROM tbl_gst_quotation", conn);
            int i = 0;
            SqlDataReader dr;

            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                if (dr[0] == System.DBNull.Value)
                {
                    i = 0;
                }
                else
                {
                    i = Convert.ToInt32(dr[0]);
                }
                if (i > 0)
                {
                    int j = i + 1;
                    Txt_invoice.Text = "QT-" + j.ToString();

                }

                else
                {
                    Txt_invoice.Text = "QT-1";
                }

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

    protected void Btn_cart_Click(object sender, EventArgs e)
    {
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




        for (int i = 0; i <= GridView1.Rows.Count; i++)
        {
            total_amount += Convert.ToDecimal(txt_final_amt.Text);

        }
        final_total = total_amount;

        final_total = total_amount;

        //pcs wise data
        if (str9 == "Pcs")
        {



            decimal cgstamount = Convert.ToDecimal(total2) * Convert.ToDecimal(cgst) / 100;
            decimal sgstamount = Convert.ToDecimal(total2) * Convert.ToDecimal(sgst) / 100;
            decimal igstamount = Convert.ToDecimal(total2) * Convert.ToDecimal(igst) / 100;

            DataTable dt = (DataTable)ViewState["Details"];
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


        // litre wise data
       else if (str9 == "Ltr")
        {



            decimal cgstamount = Convert.ToDecimal(total2) * Convert.ToDecimal(cgst) / 100;
            decimal sgstamount = Convert.ToDecimal(total2) * Convert.ToDecimal(sgst) / 100;
            decimal igstamount = Convert.ToDecimal(total2) * Convert.ToDecimal(igst) / 100;

            DataTable dt = (DataTable)ViewState["Details"];
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


        //packet wise data
        else if (str9 == "Packet")
        {



            decimal cgstamount = Convert.ToDecimal(total2) * Convert.ToDecimal(cgst) / 100;
            decimal sgstamount = Convert.ToDecimal(total2) * Convert.ToDecimal(sgst) / 100;
            decimal igstamount = Convert.ToDecimal(total2) * Convert.ToDecimal(igst) / 100;

            DataTable dt = (DataTable)ViewState["Details"];
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

        //copy 
        else if (str9 == "Copy")
        {



            decimal cgstamount = Convert.ToDecimal(total2) * Convert.ToDecimal(cgst) / 100;
            decimal sgstamount = Convert.ToDecimal(total2) * Convert.ToDecimal(sgst) / 100;
            decimal igstamount = Convert.ToDecimal(total2) * Convert.ToDecimal(igst) / 100;

            DataTable dt = (DataTable)ViewState["Details"];
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

            DataTable dt = (DataTable)ViewState["Details"];
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
          
            GridView1.Visible = true;
            Txt_description.Text = "";

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

        }
        if (e.Row.RowType == DataControlRowType.Footer)
        {
            totalgst = totalcgst + totalsgst + totaligst;
            //Find the control label in footer 
            Label lblamount = (Label)e.Row.FindControl("lbl_subtotal");
            //Assign the total value to footer label control
            lbl_subtotal.Text = totalvalue.ToString();
            lbl_subtotal2.Value = totalvalue.ToString();
            if ( Txt_Pasting.Text != "" && Txt_Fitting.Text != "" && Txt_TransportCharges.Text != "" && Txt_Dtp_charges.Text != "")
            {

                pasting = Convert.ToDecimal(Txt_Pasting.Text);
                transport = Convert.ToDecimal(Txt_TransportCharges.Text);
                design = Convert.ToDecimal(Txt_Dtp_charges.Text);
                fitting = Convert.ToDecimal(Txt_Fitting.Text);
                discount = Convert.ToDecimal(Txt_discount.Text);
                
                decimal total1 = (totalvalue + pasting + transport + design + fitting - discount );
                decimal final = (totalvalue + pasting + transport + design + fitting);
                lbl_final.Text = final.ToString();
                lbl_total.Text = total1.ToString();
                hide_total.Text = final.ToString();
            }
            else
            {
                fitting = 0;
                discount = 0;
                
                pasting = 0;
                transport = 0;
                design = 0;
                decimal total1 = (totalvalue + pasting + transport + design + fitting - discount);
                decimal final = (totalvalue + pasting + transport + design + fitting);
                lbl_final.Text = final.ToString();
                lbl_total.Text = total1.ToString();
                hide_total.Text = final.ToString();
            }
            //Assign the total value to footer label control
            lbl_gst.Text = totalgst.ToString();
            lbl_gst2.Value = totalgst.ToString();
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
            SqlCommand cmd3 = new SqlCommand("select * from tbl_rate where p_name='" + Dd_enter_product.SelectedItem.Text + "' AND cust_name='" + Dd_customer.SelectedItem.Text + "'", conn);
            SqlDataAdapter adapt3 = new SqlDataAdapter(cmd3);
            DataTable dt3 = new DataTable();

            adapt3.Fill(dt3);
            if (dt3.Rows.Count > 0)
            {
                rate = dt3.Rows[0]["r_rate"].ToString();
            }
            else
            {
                rate = dt.Rows[0]["p_rate"].ToString();
            }

            //end hrere




            //  rate = dt.Rows[0]["p_rate"].ToString();
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
            //Dd_enter_cgst.Text = cgst;
            //Dd_enter_igst.Text = igst;
            //Dd_enter_sgst.Text = sgst;
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

    private bool dataEntry()
    {
        bool isTrue = true;
        try
        {
            decimal new_balance;
            finaltotal = Math.Round(Convert.ToDecimal(hide_total.Text));
            new_balance = finaltotal - Convert.ToDecimal(Txt_discount.Text);

            if (GridView1.Rows.Count == 0)
        {
            System.Web.UI.ScriptManager.RegisterStartupScript(this, GetType(), "displayalertmessage", "alert('Please Add Products First !!!');", true);
        }
        else
        {
                SqlCommand cmd22 = new SqlCommand("Select * from tbl_gst_quotation where qu_invoice_no=@qu_invoice_no", conn);
                cmd22.Parameters.AddWithValue("@qu_invoice_no", Convert.ToString(Txt_invoice.Text));
                SqlDataAdapter adapt22 = new SqlDataAdapter(cmd22);
                DataTable dt22 = new DataTable();
                adapt22.Fill(dt22);

                if (dt22.Rows.Count ==0)
                {
                    int rowscount = GridView1.Rows.Count;
                    for (int i = 0; i < rowscount; i++)
                    {
                        if (GridView1.Rows[i].Cells[2].Text == "&nbsp;")
                        {
                            SqlCommand cmd = new SqlCommand("insert into tbl_gst_quotation_details values(@q_quotation_no,@q_date,@c_id,@q_quotation_date,@q_valid_date,@q_product_name,@q_quantity,@q_total_quantity,@q_rate,@q_discount,@q_cgstp,@q_cgsta,@q_sgstp,@q_sgsta,@q_igstp,@q_igsta,@q_amount,@q_sub_total,@q_total_gst,@q_shipping_charges,@q_adjustment,@q_total,@q_stotal,@q_hsn,@q_unit,@q_desc,@q_height,@q_width,@q_size,@q_samount,@q_balance,@q_dtp_charges,@q_fitting_charges,@q_payment_method,@q_pasting_charges)", conn);
                            cmd.Parameters.AddWithValue("@q_quotation_no", Convert.ToString(Txt_invoice.Text));
                            cmd.Parameters.AddWithValue("@q_date", Convert.ToDateTime(DateTime.Now.ToShortDateString()).ToString("MM/dd/yyyy"));
                            cmd.Parameters.AddWithValue("@c_id", Convert.ToString(Dd_customer.SelectedValue));

                            cmd.Parameters.AddWithValue("@q_quotation_date", Convert.ToDateTime(Txt_invoice_date.Text).ToString("MM/dd/yyyy"));
                            cmd.Parameters.AddWithValue("@q_valid_date", Convert.ToDateTime(Txt_due_date.Text).ToString("MM/dd/yyyy"));
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

                            if (Txt_TransportCharges.Text == "")
                            {
                                cmd.Parameters.AddWithValue("@q_shipping_charges", "0");
                            }
                            else
                            {
                                cmd.Parameters.AddWithValue("@q_shipping_charges", Convert.ToDecimal(Txt_TransportCharges.Text));
                            }


                            cmd.Parameters.AddWithValue("@q_adjustment", "0");
                            cmd.Parameters.AddWithValue("@q_total", Convert.ToDecimal(hide_total.Text));
                            cmd.Parameters.AddWithValue("@q_stotal", Convert.ToDecimal(GridView1.Rows[i].Cells[8].Text));
                            cmd.Parameters.AddWithValue("@q_hsn", Convert.ToString(GridView1.Rows[i].Cells[1].Text));
                            cmd.Parameters.AddWithValue("@q_desc", Convert.ToString(GridView1.Rows[i].Cells[16].Text));
                            cmd.Parameters.AddWithValue("@q_height", "");
                            cmd.Parameters.AddWithValue("@q_width", "");
                            cmd.Parameters.AddWithValue("@q_size", "");
                            cmd.Parameters.AddWithValue("@q_samount", "");
                            cmd.Parameters.AddWithValue("@q_balance", Convert.ToDecimal(new_balance));

                            if (Txt_Dtp_charges.Text == "")
                            {
                                cmd.Parameters.AddWithValue("@q_dtp_charges", "0");
                            }
                            else
                            {
                                cmd.Parameters.AddWithValue("@q_dtp_charges", Convert.ToDecimal(Txt_Dtp_charges.Text));
                            }

                            if (Txt_Fitting.Text == "")
                            {
                                cmd.Parameters.AddWithValue("@q_fitting_charges", "0");
                            }
                            else
                            {
                                cmd.Parameters.AddWithValue("@q_fitting_charges", Convert.ToDecimal(Txt_Fitting.Text));
                            }

                            cmd.Parameters.AddWithValue("@q_payment_method", "0");


                            if (Txt_Pasting.Text == "")
                            {
                                cmd.Parameters.AddWithValue("@q_pasting_charges", "0");
                            }
                            else
                            {
                                cmd.Parameters.AddWithValue("@q_pasting_charges", Convert.ToDecimal(Txt_Pasting.Text));
                            }

                            conn.Open();
                            cmd.ExecuteNonQuery();

                            conn.Close();
                        }
                        else
                        {

                            SqlCommand cmd = new SqlCommand("insert into tbl_gst_quotation_details values(@q_quotation_no,@q_date,@c_id,@q_quotation_date,@q_valid_date,@q_product_name,@q_quantity,@q_total_quantity,@q_rate,@q_discount,@q_cgstp,@q_cgsta,@q_sgstp,@q_sgsta,@q_igstp,@q_igsta,@q_amount,@q_sub_total,@q_total_gst,@q_shipping_charges,@q_adjustment,@q_total,@q_stotal,@q_hsn,@q_unit,@q_desc,@q_height,@q_width,@q_size,@q_samount,@q_balance,@q_dtp_charges,@q_fitting_charges,@q_payment_method,@q_pasting_charges)", conn);
                            cmd.Parameters.AddWithValue("@q_quotation_no", Convert.ToString(Txt_invoice.Text));
                            cmd.Parameters.AddWithValue("@q_date", Convert.ToDateTime(DateTime.Now.ToShortDateString()).ToString("MM/dd/yyyy"));
                            cmd.Parameters.AddWithValue("@c_id", Convert.ToString(Dd_customer.SelectedValue));

                            cmd.Parameters.AddWithValue("@q_quotation_date", Convert.ToDateTime(Txt_invoice_date.Text).ToString("MM/dd/yyyy"));
                            cmd.Parameters.AddWithValue("@q_valid_date", Convert.ToDateTime(Txt_due_date.Text).ToString("MM/dd/yyyy"));
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

                            if (Txt_TransportCharges.Text == "")
                            {
                                cmd.Parameters.AddWithValue("@q_shipping_charges", "0");
                            }
                            else
                            {
                                cmd.Parameters.AddWithValue("@q_shipping_charges", Convert.ToDecimal(Txt_TransportCharges.Text));
                            }

                            cmd.Parameters.AddWithValue("@q_adjustment", "0");
                            cmd.Parameters.AddWithValue("@q_total", Convert.ToDecimal(hide_total.Text));
                            cmd.Parameters.AddWithValue("@q_stotal", Convert.ToDecimal(GridView1.Rows[i].Cells[8].Text));
                            cmd.Parameters.AddWithValue("@q_hsn", Convert.ToString(GridView1.Rows[i].Cells[1].Text));
                            cmd.Parameters.AddWithValue("@q_desc", Convert.ToString(GridView1.Rows[i].Cells[16].Text));
                            cmd.Parameters.AddWithValue("@q_height", Convert.ToDecimal(GridView1.Rows[i].Cells[2].Text));
                            cmd.Parameters.AddWithValue("@q_width", Convert.ToDecimal(GridView1.Rows[i].Cells[3].Text));
                            cmd.Parameters.AddWithValue("@q_size", Convert.ToDecimal(GridView1.Rows[i].Cells[4].Text));
                            if (GridView1.Rows[i].Cells[6].Text == "&nbsp;")
                            {
                                cmd.Parameters.AddWithValue("@q_samount", "0");
                            }
                            else
                            {
                                cmd.Parameters.AddWithValue("@q_samount", Convert.ToDecimal(GridView1.Rows[i].Cells[6].Text));
                            }


                            cmd.Parameters.AddWithValue("@q_balance", Convert.ToDecimal(new_balance));

                            if (Txt_Dtp_charges.Text == "")
                            {
                                cmd.Parameters.AddWithValue("@q_dtp_charges", "0");
                            }
                            else
                            {
                                cmd.Parameters.AddWithValue("@q_dtp_charges", Convert.ToDecimal(Txt_Dtp_charges.Text));
                            }

                            if (Txt_Fitting.Text == "")
                            {
                                cmd.Parameters.AddWithValue("@q_fitting_charges", "0");
                            }
                            else
                            {
                                cmd.Parameters.AddWithValue("@q_fitting_charges", Convert.ToDecimal(Txt_Fitting.Text));
                            }

                            cmd.Parameters.AddWithValue("@q_payment_method", "0");

                            if (Txt_Pasting.Text == "")
                            {
                                cmd.Parameters.AddWithValue("@q_pasting_charges", "0");
                            }
                            else
                            {
                                cmd.Parameters.AddWithValue("@q_pasting_charges", Convert.ToDecimal(Txt_Pasting.Text));
                            }

                            conn.Open();
                            cmd.ExecuteNonQuery();
                            conn.Close();
                        }
                    }
                    SqlCommand cmd2 = new SqlCommand("insert into tbl_gst_quotation values(@qu_invoice_no,@qu_date,@c_id,@qu_invoice_date,@qu_due_date,@qu_total_quantity,@qu_discount,@qu_sub_total,@qu_total_gst,@qu_shipping_charges,@qu_adjustment,@qu_total,@qu_balance,@qu_dtp_charges,@qu_fitting_charges,@qu_payment_method,@qu_pasting_charges)", conn);
                    cmd2.Parameters.AddWithValue("@qu_invoice_no", Convert.ToString(Txt_invoice.Text));
                    cmd2.Parameters.AddWithValue("@qu_date", Convert.ToDateTime(DateTime.Now.ToShortDateString()).ToString("MM/dd/yyyy"));
                    cmd2.Parameters.AddWithValue("@c_id", Convert.ToString(Dd_customer.SelectedValue));

                    cmd2.Parameters.AddWithValue("@qu_invoice_date", Convert.ToDateTime(Txt_invoice_date.Text).ToString("MM/dd/yyyy"));
                    cmd2.Parameters.AddWithValue("@qu_due_date", Convert.ToDateTime(Txt_due_date.Text).ToString("MM/dd/yyyy"));

                    cmd2.Parameters.AddWithValue("@qu_total_quantity", Convert.ToDecimal(lbl_totalqty.Text));

                    cmd2.Parameters.AddWithValue("@qu_discount", Convert.ToDecimal(Txt_discount.Text));

                    cmd2.Parameters.AddWithValue("@qu_sub_total", Convert.ToDecimal(lbl_subtotal.Text));
                    cmd2.Parameters.AddWithValue("@qu_total_gst", Convert.ToDecimal(lbl_gst.Text));

                    if (Txt_TransportCharges.Text == "")
                    {
                        cmd2.Parameters.AddWithValue("@qu_shipping_charges", "0");
                    }
                    else
                    {
                        cmd2.Parameters.AddWithValue("@qu_shipping_charges", Convert.ToDecimal(Txt_TransportCharges.Text));
                    }

                    cmd2.Parameters.AddWithValue("@qu_adjustment", "0");
                    cmd2.Parameters.AddWithValue("@qu_total", Convert.ToDecimal(hide_total.Text));
                    cmd2.Parameters.AddWithValue("@qu_balance", Convert.ToDecimal(new_balance));

                    if (Txt_Dtp_charges.Text == "")
                    {
                        cmd2.Parameters.AddWithValue("@qu_dtp_charges", "0");
                    }
                    else
                    {
                        cmd2.Parameters.AddWithValue("@qu_dtp_charges", Convert.ToDecimal(Txt_Dtp_charges.Text));
                    }

                    if (Txt_Fitting.Text == "")
                    {
                        cmd2.Parameters.AddWithValue("@qu_fitting_charges", "0");
                    }
                    else
                    {
                        cmd2.Parameters.AddWithValue("@qu_fitting_charges", Convert.ToDecimal(Txt_Fitting.Text));
                    }


                    cmd2.Parameters.AddWithValue("@qu_payment_method", "0");



                    if (Txt_Pasting.Text == "")
                    {
                        cmd2.Parameters.AddWithValue("@qu_pasting_charges", "0");
                    }
                    else
                    {
                        cmd2.Parameters.AddWithValue("@qu_pasting_charges", Convert.ToDecimal(Txt_Pasting.Text));
                    }

                    conn.Open();
                    cmd2.ExecuteNonQuery();
                    conn.Close();

                    isTrue = true;
                    string redirectScript = " window.location.href = 'report.aspx?insert=success';";
                    System.Web.UI.ScriptManager.RegisterStartupScript(this, GetType(), "displayalertmessage", "alert('New Quotation Added Successfully!!!');" + redirectScript, true);

                }

                else
                {
                   // System.Web.UI.ScriptManager.RegisterStartupScript(this, GetType(), "displayalertmessage", "alert(' !!!');", true);
                    string redirectScript = " window.location.href = 'report.aspx?insert=success';";
                    System.Web.UI.ScriptManager.RegisterStartupScript(this, GetType(), "displayalertmessage", "alert('New Quotation Added Successfully!!!');" + redirectScript, true);
                }
               
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

        if (GridView1.Rows.Count == 0)
        {
            System.Web.UI.ScriptManager.RegisterStartupScript(this, GetType(), "displayalertmessage", "alert('Please Add Products First !!!');", true);
        }
        //System.Threading.Thread.Sleep(5000);
        //Btn_generate_pdf.Enabled = false;
        else
        {
            bool isTrue = dataEntry();
            if (isTrue == true)
            {
                //Response.Redirect("report.aspx?insert=success");
                string redirectScript = " window.location.href = 'report.aspx?insert=success';";
                System.Web.UI.ScriptManager.RegisterStartupScript(this, GetType(), "displayalertmessage", "alert('New Quotation Added Successfully!!!');" + redirectScript, true);
            }
            else
            {

            }
        }
    }
    protected void Btn_submit_payment_Click(object sender, EventArgs e)
    {
        if (GridView1.Rows.Count == 0)
        {
            System.Web.UI.ScriptManager.RegisterStartupScript(this, GetType(), "displayalertmessage", "alert('Please Add Products First !!!');", true);
        }
        //System.Threading.Thread.Sleep(5000);
        //Btn_generate_pdf.Enabled = false;
        else
        {
            bool isTrue = dataEntry();
            if (isTrue == true)
            {
                string redirectScript = " window.location.href = 'gst_bill.aspx?invoice=" + Txt_invoice.Text + "';";
                System.Web.UI.ScriptManager.RegisterStartupScript(this, GetType(), "displayalertmessage", "alert('New Quotation Added Successfully!!!');" + redirectScript, true);

            }
            else
            {

            }
        }
    }

    protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        int index = Convert.ToInt32(e.RowIndex);
        DataTable dt = ViewState["Details"] as DataTable;
        dt.Rows[index].Delete();
        ViewState["Details"] = dt;
        if (dt.Rows.Count > 0)
        {
            GridView1.DataSource = dt;
            GridView1.DataBind();

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

            Txt_Dtp_charges.Text = "0";
            Txt_Fitting.Text = "0";
           
            Txt_Pasting.Text = "0";
            Txt_TransportCharges.Text = "0";



            lbl_subtotal.Text = "0";
            lbl_subtotal2.Value = "0";

           
            Txt_discount.Text = "0";

            lbl_gst.Text = "0";
            lbl_gst2.Value = "0";
            lbl_total.Text = "0";

            lbl_final.Text = "0";
            hide_total.Text = "0";
        }

    }


    protected void Button1_Click(object sender, EventArgs e)
    {
        lbl_msg.Text = "";
        try
        {
            SqlCommand cmd = new SqlCommand("INSERT INTO tbl_customer (c_name, c_address, c_contact, c_contact2, c_gst_no, c_opening_balance, c_email, c_dob, c_anidate) VALUES (@c_name, @c_address, @c_contact, @c_contact2, @c_gst_no, @c_opening_balance, @c_email, @c_dob, @c_anidate)", conn);

            cmd.Parameters.AddWithValue("@c_name", Txt_customer_name.Text);
            cmd.Parameters.AddWithValue("@c_address", Txt_address.Text);
            cmd.Parameters.AddWithValue("@c_contact", Txt_contact.Text);
            cmd.Parameters.AddWithValue("@c_contact2", Txt_contact2.Text);

            if (string.IsNullOrEmpty(Txt_gst_no.Text))
            {

                Random random = new Random();
                int randomNumber = random.Next(1000, 9999);
                Txt_gst_no.Text = "N/A-" + randomNumber.ToString();
            }

            cmd.Parameters.AddWithValue("@c_gst_no", Txt_gst_no.Text.Trim());

            if (string.IsNullOrEmpty(Txt_opening_balance.Text))
            {
                cmd.Parameters.AddWithValue("@c_opening_balance", 0);
            }
            else
            {
                cmd.Parameters.AddWithValue("@c_opening_balance", Txt_opening_balance.Text);
            }

            cmd.Parameters.AddWithValue("@c_email", Txt_email.Text);
            cmd.Parameters.AddWithValue("@c_dob", Txt_dob.Text);
            cmd.Parameters.AddWithValue("@c_anidate", Txt_ani.Text);

            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();

            customer();
            lbl_msg.ForeColor = System.Drawing.Color.Green;
            lbl_msg.Text = "Customer Added Successfully!!!";


        }
        catch (SqlException ex)
        {
            if (ex.Number == 2601)
            {

                if (ex.Message.Contains("IX_UniqueContact"))
                {
                    lbl_msg.ForeColor = System.Drawing.Color.Red;
                    lbl_msg.Text = "This contact number already exists!!!";
                }
                else if (ex.Message.Contains("IX_UniqueGST"))
                {

                    lbl_msg.ForeColor = System.Drawing.Color.Red;
                    lbl_msg.Text = "This GST number already exists!!!";

                }
                else
                {

                }
            }
            else
            {

            }

        }
        if (lbl_msg.Text == "This GST number already exists!!!")
        {
            Txt_gst_no.Text = "";

        }
        else if (lbl_msg.Text == "This contact number already exists!!!")
        {
            Txt_contact.Text = "";
        }
        else
        {
            Txt_customer_name.Text = "";
            Txt_address.Text = "";
            Txt_gst_no.Text = "";
            Txt_contact2.Text = "";
            Txt_address.Text = "";
            Txt_contact.Text = "";
            Txt_opening_balance.Text = "";
            Txt_email.Text = "";
            Txt_dob.Text = "";
            Txt_ani.Text = "";

        }
    }

    protected void Button2_Click(object sender, EventArgs e)
    {
        lbl_msg2.Text = "";
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
            cmd2.Parameters.AddWithValue("@p_cgst", Dd_cgst.SelectedValue);
            cmd2.Parameters.AddWithValue("@p_sgst", Dd_sgst.SelectedValue);
            cmd2.Parameters.AddWithValue("@p_igst", Dd_igst.SelectedValue);
            cmd2.Parameters.AddWithValue("@p_hsn_code", hsn);
            cmd2.Parameters.AddWithValue("@p_rate", Txt_ra.Text);
            cmd2.Parameters.AddWithValue("@p_desc", Txt_desc.Text);
            conn.Open();
            cmd2.ExecuteNonQuery();
            conn.Close();
            product();
            lbl_msg2.ForeColor = System.Drawing.Color.Green;
            lbl_msg2.Text = "Product Added Successfully!!!";


            Dd_unit.SelectedItem.Text = "Sqft";
            Txt_product_name.Text = "";
            //string redirectScript = " window.location.href = 'purchase_invoice.aspx';";
            //System.Web.UI.ScriptManager.RegisterStartupScript(this, GetType(), "displayalertmessage", "alert('New Purchase Product Added Successfully!!!');" + redirectScript, true);
            //Txt_product_name.Text = "";
            Txt_hsn.Text = "";
            Txt_ra.Text = "";
            Txt_desc.Text = "";
            Dd_igst.SelectedItem.Text = "0 %";
            Dd_sgst.SelectedItem.Text = "0 %";
            Dd_cgst.SelectedItem.Text = "0 %";



            //string redirectScript = " window.location.href = 'sale_invoice.aspx';";
            //System.Web.UI.ScriptManager.RegisterStartupScript(this, GetType(), "displayalertmessage", "alert('New Sale Product Added Successfully!!!');" + redirectScript, true);


        }
    }
}