using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

public partial class Purchase_roll_purchase : System.Web.UI.Page
{
    SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["String"].ConnectionString);
    decimal total_amount = 0, final_total = 0;
    decimal dPageTotal, totalcgstnew = 0, totalsgstnew = 0, totaligstnew = 0, cgstamtnew, sgstamtnew, igstamtnew;
    decimal totalvalue = 0, totalcgst = 0, totalsgst = 0, totaligst = 0, totalgst = 0, totalqty, totaltaxable = 0;
    string product_name;
    decimal tsqft;
    protected void Page_Load(object sender, EventArgs e)
    {
        Dd_customer.Focus();
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

                //Txt_invoice_date.Text = DateTime.Today.ToString("yyyy-MM-dd");
                //Txt_due_date.Text = DateTime.Today.ToString("yyyy-MM-dd");
                this.invoiceid();
                this.customer();
                this.product();
                this.feet();
                if (ViewState["Details"] == null)
                {

                    DataTable dataTable = new DataTable();
                    dataTable.Columns.Add("Product");
                    dataTable.Columns.Add("HSN");
                    dataTable.Columns.Add("Height(Ft)");
                    dataTable.Columns.Add("Height(Mtr)");
                    dataTable.Columns.Add("Roll Size(Mtr)");
                    dataTable.Columns.Add("Total(Mtr)");
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
        string query = "select * from tbl_purchase_product where p_unit = 'Inch' or p_unit = 'Sqft' Order By p_name asc";
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
        string query = "select * from tbl_feet";
        SqlDataAdapter adapt5 = new SqlDataAdapter(query, conn);
        DataTable dt6 = new DataTable();
        adapt5.Fill(dt6);
        if (dt6.Rows.Count > 0)
        {
            drp_feet.DataSource = dt6;
            drp_feet.DataBind();
            drp_feet.DataTextField = "f_feet";

            drp_feet.DataValueField = "f_id";
            drp_feet.DataBind();
            drp_feet.Items.Insert(0, new ListItem("--Select--", "--Select--"));
            drp_feet.SelectedItem.Selected = false;
            drp_feet.Items.FindByText("--Select--").Selected = true;
        }

    }
    public void order()
    {
        SqlCommand cmd = new SqlCommand("select count(rpu_invoice_no) from tbl_roll_purchase where v_id='" + Dd_customer.SelectedValue + "'", conn);
        SqlDataAdapter adapt = new SqlDataAdapter(cmd);
        DataTable dt = new DataTable();
        adapt.Fill(dt);
        if (dt.Rows.Count > 0)
        {
            decimal order = Convert.ToDecimal(dt.Rows[0][0]) + 1;
            Txt_order_no.Text = order.ToString();
        }
    }
    public void invoiceid()
    {
        try
        {
            conn.Open();

            SqlCommand cmd = new SqlCommand("SELECT TOP 1 rpu_invoice_no FROM tbl_roll_purchase ORDER BY rpu_id DESC", conn);
            string inv;
            int i = 0;
            SqlDataAdapter adapt = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            adapt.Fill(dt);



            if (dt.Rows.Count > 0)
            {
                inv = dt.Rows[0]["rpu_invoice_no"].ToString();

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
                Txt_invoice.Text = "RPO-" + j.ToString();

            }

            else
            {
                Txt_invoice.Text = "RPO-1";
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
        string heightft = drp_feet.SelectedValue;
        string heightmtr = txt_roll_width.Text.Trim();
        string rollsize = Txt_roll_height.Text.Trim();
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




        //new data end




        for (int i = 0; i <= GridView1.Rows.Count; i++)
        {
            total_amount += Convert.ToDecimal(txt_final_amt.Text);

        }
        final_total = total_amount;

       

        decimal cgstamount = Convert.ToDecimal(total) * Convert.ToDecimal(cgst) / 100;
        if (cgst == "0")
        {
            cgstamtnew = 0 ;
        }
        else
        {
             cgstamtnew = Convert.ToDecimal(cgstamount.ToString("#.##"));
        }
        
        decimal sgstamount = Convert.ToDecimal(total) * Convert.ToDecimal(sgst) / 100;
        if (sgst == "0")
        {
            sgstamtnew = 0;
        }
        else
        {
            sgstamtnew = Convert.ToDecimal(sgstamount.ToString("#.##"));
        }
             
        decimal igstamount = Convert.ToDecimal(total) * Convert.ToDecimal(igst) / 100;
        if (igst == "0")
        {
            igstamtnew = 0;
        }
        else
        {
            igstamtnew = Convert.ToDecimal(igstamount.ToString("#.##"));
        }
       
        DataTable dt = (DataTable)ViewState["Details"];
        dt.Rows.Add(str, str10, heightft, heightmtr, rollsize, totalroll, sqrft, rate, amount, quantity, total, cgstamtnew, sgstamtnew, igstamtnew, final, cgst, sgst, igst, desc, str9);
        ViewState["Details"] = dt;
        GridView1.DataSource = dt;
        GridView1.EmptyDataText = "Product";
        GridView1.EmptyDataText = "HSN";
        GridView1.EmptyDataText = "Height(Ft)";
        GridView1.EmptyDataText = "Height(Mtr)";
        GridView1.EmptyDataText = "Roll Size(Mtr)";
        GridView1.EmptyDataText = "Total(Mtr)";
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

            c = c + a; //storing total qty into variable 
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

        }
        //Check if the current row is datarow or not
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            //Add the value of column
            totalvalue += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "FINAL"));
            
            totalcgst += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "CGST"));
            if (totalcgst == 0)
            {
                totalcgstnew = 0;
            }
            else
            {
                totalcgstnew = Convert.ToDecimal(totalcgst.ToString("#.##"));
            }
            
            totalsgst += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "SGST"));
            if (totalsgst == 0)
            {
                totalsgstnew = 0;
            }
            else
            {
                totalsgstnew = Convert.ToDecimal(totalsgst.ToString("#.##"));
            }           

            totaligst += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "IGST"));
            if (totaligst == 0)
            {
                totaligstnew = 0;
            }
            else
            {
                totaligstnew = Convert.ToDecimal(totaligst.ToString("#.##"));
            }            

            totalqty += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "Qty"));
            totaltaxable += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "Total"));

        }
        if (e.Row.RowType == DataControlRowType.Footer)
        {
            totalgst = totalcgstnew + totalsgstnew + totaligstnew;

            //Find the control label in footer 
            Label lblamount = (Label)e.Row.FindControl("lbl_subtotal");
            //Assign the total value to footer label control
            lbl_subtotal.Text = totalvalue.ToString();
            lbl_subtotal2.Value = totalvalue.ToString();

            //Assign the total value to footer label control
            lbl_gst.Text = totalgst.ToString();
            lbl_totalqty.Text = totalqty.ToString();
            lbl_total_cgst.Value = totalcgstnew.ToString();
            lbl_total_sgst.Value = totalsgstnew.ToString();
            lbl_total_igst.Value = totaligstnew.ToString();
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
    protected void Dd_customer_SelectedIndexChanged(object sender, EventArgs e)
    {
        order();
    }

    private bool dataEntry()
    {
        bool isTrue = true;
        try
        {
            if (GridView1.Rows.Count == 0)
            {
                System.Web.UI.ScriptManager.RegisterStartupScript(this, GetType(), "displayalertmessage", "alert('Please Add Products First !!!');", true);
            }
            else
            {

                int rowscount = GridView1.Rows.Count;
                for (int i = 0; i < rowscount; i++)
                {

                    SqlCommand cmd = new SqlCommand("insert into tbl_roll_purchase_invoice values(@rpc_invoice_no,@rpc_date,@v_id,@rpc_order_no,@rpc_invoice_date,@rpc_due_date,@rpc_product_name,@rpc_quantity,@rpc_total_quantity,@rpc_rate,@rpc_discount,@rpc_cgstp,@rpc_cgsta,@rpc_sgstp,@rpc_sgsta,@rpc_igstp,@rpc_igsta,@rpc_amount,@rpc_sub_total,@rpc_total_gst,@rpc_shipping_charges,@rpc_adjustment,@rpc_total,@rpc_stotal,@rpc_hsn,@rpc_unit,@rpc_desc,@rpc_heightft,@rpc_heightmtr,@rpc_roll_size,@rpc_total_size,@rpc_size,@rpc_samount,@rpc_total_cgst,@rpc_total_sgst,@rpc_total_igst,@rpc_total_taxable,@rpc_balance,@rpc_mode)", conn);
                    cmd.Parameters.AddWithValue("@rpc_invoice_no", Convert.ToString(Txt_invoice.Text));
                    cmd.Parameters.AddWithValue("@rpc_date", Convert.ToDateTime(DateTime.Now.ToShortDateString()).ToString("MM/dd/yyyy"));
                    cmd.Parameters.AddWithValue("@v_id", Convert.ToString(Dd_customer.SelectedValue));
                    cmd.Parameters.AddWithValue("@rpc_order_no", Convert.ToString(Txt_order_no.Text));
                    cmd.Parameters.AddWithValue("@rpc_invoice_date", Convert.ToDateTime(Txt_invoice_date.Text).ToString("MM/dd/yyyy"));
                    cmd.Parameters.AddWithValue("@rpc_due_date", Convert.ToDateTime(Txt_due_date.Text).ToString("MM/dd/yyyy"));
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
                    cmd.Parameters.AddWithValue("@rpc_hsn", Convert.ToString(GridView1.Rows[i].Cells[1].Text));
                    cmd.Parameters.AddWithValue("@rpc_desc", Convert.ToString(GridView1.Rows[i].Cells[18].Text));
                    cmd.Parameters.AddWithValue("@rpc_heightft", (GridView1.Rows[i].Cells[2].Text).ToString());
                    cmd.Parameters.AddWithValue("@rpc_heightmtr", Convert.ToDecimal(GridView1.Rows[i].Cells[3].Text));
                    cmd.Parameters.AddWithValue("@rpc_roll_size", Convert.ToDecimal(GridView1.Rows[i].Cells[4].Text));
                    cmd.Parameters.AddWithValue("@rpc_total_size", Convert.ToDecimal(GridView1.Rows[i].Cells[5].Text));
                    cmd.Parameters.AddWithValue("@rpc_size", Convert.ToDecimal(GridView1.Rows[i].Cells[6].Text));
                    cmd.Parameters.AddWithValue("@rpc_samount", Convert.ToDecimal(GridView1.Rows[i].Cells[8].Text));
                    cmd.Parameters.AddWithValue("@rpc_total_cgst", Convert.ToDecimal(lbl_total_cgst.Value));
                    cmd.Parameters.AddWithValue("@rpc_total_sgst", Convert.ToDecimal(lbl_total_sgst.Value));
                    cmd.Parameters.AddWithValue("@rpc_total_igst", Convert.ToDecimal(lbl_total_igst.Value));
                    cmd.Parameters.AddWithValue("@rpc_total_taxable", Convert.ToDecimal(lbl_total_taxable.Value));
                    cmd.Parameters.AddWithValue("@rpc_balance", Convert.ToDecimal(hide_total.Text));
                    cmd.Parameters.AddWithValue("@rpc_mode", Convert.ToString(Drp_payment_mode.SelectedItem.Text));

                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();

                    //decimal tsqft = Convert.ToDecimal(GridView1.Rows[i].Cells[9].Text) * Convert.ToDecimal(GridView1.Rows[i].Cells[6].Text);
                    //SqlCommand cmd3 = new SqlCommand("UPDATE tbl_purchase_product SET p_stock=p_stock+('" + tsqft + "') WHERE p_name='" + Convert.ToString(GridView1.Rows[i].Cells[0].Text) + "'", conn);

                    //conn.Open();
                    //cmd3.ExecuteNonQuery();
                    //conn.Close();



                    //stock start here
                     tsqft = Convert.ToDecimal(GridView1.Rows[i].Cells[9].Text) * Convert.ToDecimal(GridView1.Rows[i].Cells[6].Text);
                    SqlCommand cmd5 = new SqlCommand("UPDATE tbl_purchase_product SET p_stock=p_stock+('" + tsqft + "') WHERE p_name='" + Convert.ToString(GridView1.Rows[i].Cells[0].Text) + "'", conn);

                    conn.Open();
                    cmd5.ExecuteNonQuery();
                    conn.Close();

                    // stock end here
                    product_name = Convert.ToString(GridView1.Rows[i].Cells[0].Text);
                    //SqlCommand cmd77 = new SqlCommand("insert into tbl_used_stock values(@p_name,@date,@sqrft,@quantity)", conn);
                    //cmd77.Parameters.AddWithValue("@p_name", Convert.ToString(GridView1.Rows[i].Cells[0].Text));
                    //cmd77.Parameters.AddWithValue("@date", Convert.ToDateTime(Txt_invoice_date.Text).ToString("MM/dd/yyyy"));
                    //cmd77.Parameters.AddWithValue("@sqrft", Convert.ToDecimal(GridView1.Rows[i].Cells[6].Text));
                    //cmd77.Parameters.AddWithValue("@quantity", Convert.ToDecimal(GridView1.Rows[i].Cells[7].Text));

                    //conn.Open();
                    //cmd77.ExecuteNonQuery();
                    //conn.Close();

                }
                SqlCommand cmd2 = new SqlCommand("insert into tbl_roll_purchase values(@rpu_invoice_no,@rpu_date,@v_id,@rpu_order_no,@rpu_invoice_date,@rpu_due_date,@rpu_total_quantity,@rpu_discount,@rpu_sub_total,@rpu_total_gst,@rpu_shipping_charges,@rpu_adjustment,@rpu_total,@rpu_total_cgst,@rpu_total_sgst,@rpu_total_igst,@rpu_total_taxable,@rpu_balance,@rpu_product_name,@rpu_size)", conn);
                cmd2.Parameters.AddWithValue("@rpu_invoice_no", Convert.ToString(Txt_invoice.Text));
                cmd2.Parameters.AddWithValue("@rpu_date", Convert.ToDateTime(DateTime.Now.ToShortDateString()).ToString("MM/dd/yyyy"));
                cmd2.Parameters.AddWithValue("@v_id", Convert.ToString(Dd_customer.SelectedValue));
                cmd2.Parameters.AddWithValue("@rpu_order_no", Convert.ToString(Txt_order_no.Text));
                cmd2.Parameters.AddWithValue("@rpu_invoice_date", Convert.ToDateTime(Txt_invoice_date.Text).ToString("MM/dd/yyyy"));
                cmd2.Parameters.AddWithValue("@rpu_due_date", Convert.ToDateTime(Txt_due_date.Text).ToString("MM/dd/yyyy"));

                cmd2.Parameters.AddWithValue("@rpu_total_quantity", Convert.ToDecimal(lbl_totalqty.Text));

                cmd2.Parameters.AddWithValue("@rpu_discount", Convert.ToDecimal(Txt_discount.Text));


                cmd2.Parameters.AddWithValue("@rpu_sub_total", Convert.ToDecimal(lbl_subtotal.Text));
                cmd2.Parameters.AddWithValue("@rpu_total_gst", Convert.ToDecimal(lbl_gst.Text));
                cmd2.Parameters.AddWithValue("@rpu_shipping_charges", Convert.ToDecimal(Txt_shipping.Text));
                cmd2.Parameters.AddWithValue("@rpu_adjustment", Convert.ToDecimal(Txt_adjustment.Text));
                cmd2.Parameters.AddWithValue("@rpu_total", Convert.ToDecimal(hide_total.Text));
                cmd2.Parameters.AddWithValue("@rpu_total_cgst", Convert.ToDecimal(lbl_total_cgst.Value));
                cmd2.Parameters.AddWithValue("@rpu_total_sgst", Convert.ToDecimal(lbl_total_sgst.Value));
                cmd2.Parameters.AddWithValue("@rpu_total_igst", Convert.ToDecimal(lbl_total_igst.Value));
                cmd2.Parameters.AddWithValue("@rpu_total_taxable", Convert.ToDecimal(lbl_total_taxable.Value));
                cmd2.Parameters.AddWithValue("@rpu_balance", Convert.ToDecimal(hide_total.Text));
                cmd2.Parameters.AddWithValue("@rpu_product_name", Convert.ToString(product_name));
                cmd2.Parameters.AddWithValue("@rpu_size", tsqft);
                conn.Open();
                cmd2.ExecuteNonQuery();
                conn.Close();


                SqlCommand cmd3 = new SqlCommand("update tbl_vendor set v_opening_balance=v_opening_balance + '" + Convert.ToDecimal(hide_total.Text) + "' where v_id='" + Dd_customer.SelectedValue + "'", conn);
                conn.Open();
                cmd3.ExecuteNonQuery();
                conn.Close();
                isTrue = true;


                

            }
        }
        catch (Exception ex)
        { isTrue = false; }
        return isTrue;
    }
    protected void Btn_generate_pdf_Click(object sender, EventArgs e)
    {
        bool isTrue = dataEntry();
        if (isTrue == true)
        {
            //Response.Redirect("list_of_roll_purchase.aspx?insert=success");
            string redirectScript = " window.location.href = 'list_of_roll_purchase.aspx?insert=success';";
            System.Web.UI.ScriptManager.RegisterStartupScript(this, GetType(), "displayalertmessage", "alert('New Roll Purchase Invoice Added Successfully!!!');" + redirectScript, true);
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
            string redirectScript = " window.location.href = 'roll_bill.aspx?invoice=" + Txt_invoice.Text + "';";
            System.Web.UI.ScriptManager.RegisterStartupScript(this, GetType(), "displayalertmessage", "alert('New Roll Purchase Invoice Added Successfully!!!');" + redirectScript, true);
        }
        else
        {

        }
    }
    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        //GridView1.PageIndex = e.NewPageIndex;

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

        SqlCommand cmd = new SqlCommand("Select * from tbl_vendor where v_name='" + Txt_vendor_name.Text.Trim() + "'", conn);
        SqlDataAdapter adapt = new SqlDataAdapter(cmd);
        DataTable dt = new DataTable();
        adapt.Fill(dt);

        if (dt.Rows.Count > 0)
        {
            lbl_msg.Text = "Vendor Already Exist!!!";
        }
        else
        {
            SqlCommand cmd2 = new SqlCommand("insert into tbl_vendor values(@v_name,@v_address,@v_contact,@v_gst_no,@v_opening_balance,@v_email,@v_contact2)", conn);
            cmd2.Parameters.AddWithValue("@v_name", Txt_vendor_name.Text);
            cmd2.Parameters.AddWithValue("@v_address", Txt_address.Text);
            cmd2.Parameters.AddWithValue("@v_contact", Txt_contact.Text);
            cmd2.Parameters.AddWithValue("@v_contact2", Txt_contact2.Text);
            cmd2.Parameters.AddWithValue("@v_gst_no", Txt_gst_no.Text);
            if (Txt_opening_balance.Text == "")
            {
                cmd2.Parameters.AddWithValue("@v_opening_balance", 0);
            }
            else
            {
                cmd2.Parameters.AddWithValue("@v_opening_balance", Txt_opening_balance.Text);
            }

            cmd2.Parameters.AddWithValue("@v_email", Txt_email.Text);
            conn.Open();
            cmd2.ExecuteNonQuery();
            conn.Close();
            // Lbl_message.Text = "" + Txt_vendor_name.Text + " Added Successfully!!!";
            // Page.Response.Redirect(Page.Request.RawUrl.ToString(), true);
            string redirectScript = " window.location.href = 'roll_purchase.aspx';";
            System.Web.UI.ScriptManager.RegisterStartupScript(this, GetType(), "displayalertmessage", "alert('New Vendor Added Successfully!!!');" + redirectScript, true);

        }
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
        SqlCommand cmd = new SqlCommand("Select * from tbl_purchase_product where p_name='" + Txt_product_name.Text.Trim() + "'", conn);
        //cmd2.Parameters.AddWithValue("@c_name", this.Txt_customer_name.Text);
        SqlDataAdapter adapt = new SqlDataAdapter(cmd);
        DataTable dt = new DataTable();
        adapt.Fill(dt);


        //var result = cmd2.ExecuteScalar();
        if (dt.Rows.Count > 0)
        {
            lbl_msg2.Text = "Product Already Exist!!!";

        }
        else
        {
            SqlCommand cmd2 = new SqlCommand("insert into tbl_purchase_product values(@p_name,@p_unit,@p_cgst,@p_sgst,@p_igst,@p_hsn_code,@p_rate,@p_desc,@p_stock,@p_value)", conn);
            cmd2.Parameters.AddWithValue("@p_name", Txt_product_name.Text);
            cmd2.Parameters.AddWithValue("@p_unit", Dd_unit.SelectedItem.Text);
            cmd2.Parameters.AddWithValue("@p_cgst", Dd_cgst.SelectedValue);
            cmd2.Parameters.AddWithValue("@p_sgst", Dd_sgst.SelectedValue);
            cmd2.Parameters.AddWithValue("@p_igst", Dd_igst.SelectedValue);
            cmd2.Parameters.AddWithValue("@p_hsn_code", hsn);
            cmd2.Parameters.AddWithValue("@p_rate", Txt_ra.Text);
            cmd2.Parameters.AddWithValue("@p_desc", Txt_desc.Text);
            cmd2.Parameters.AddWithValue("@p_stock", 0);
            cmd2.Parameters.AddWithValue("@p_value", 0);
            conn.Open();
            cmd2.ExecuteNonQuery();
            conn.Close();
            // Lbl_message.Text = "" + Txt_product_name.Text + " Added Successfully!!!";
            // Page.Response.Redirect(Page.Request.RawUrl.ToString(), true);
            string redirectScript = " window.location.href = 'roll_purchase.aspx';";
            System.Web.UI.ScriptManager.RegisterStartupScript(this, GetType(), "displayalertmessage", "alert('New Purchase Product Added Successfully!!!');" + redirectScript, true);

        }

    }


    


    protected void drp_feet_SelectedIndexChanged(object sender, EventArgs e)
    {
        string feet;
        SqlCommand cmd = new SqlCommand("select * from tbl_feet where f_id='"+ drp_feet.SelectedValue +"'", conn);
        SqlDataAdapter adapt = new SqlDataAdapter(cmd);
        DataTable dt = new DataTable();
        adapt.Fill(dt);
        if(dt.Rows.Count > 0)
        {
            feet = dt.Rows[0]["f_mtr"].ToString();
            txt_roll_width.Text = feet;
        }
    }
}