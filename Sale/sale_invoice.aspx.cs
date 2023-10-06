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
using System.IO;

public partial class Sale_sale_invoice : System.Web.UI.Page
{
    SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["String"].ConnectionString);
    decimal total_amount = 0, final_total = 0;
    decimal totalvalue = 0, totalcgst = 0, totalsgst = 0, totaligst = 0, totalgst = 0, totalqty, totaltaxable = 0,finaltotal;
    string key, country, senderid, route,email,password,port,subject,smtp, com_email;
    int sms,mail2;
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

                Panel1.Visible = true;
                Panel2.Visible = false;
                upinoheading.Visible = false;
                upinotxt.Visible = false;
                //Txt_invoice_date.Text = DateTime.Today.ToString("yyyy-MM-dd"); 
                //Txt_due_date.Text = DateTime.Today.ToString("yyyy-MM-dd");
                this.invoiceid();
                this.customer();
                this.product();
                this.Order_reference();
                order();
                material();


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
                    dataTable.Columns.Add("material");

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
        SqlDataAdapter adapt = new SqlDataAdapter(query, conn);
        DataTable dt = new DataTable();
        adapt.Fill(dt);
        if (dt.Rows.Count > 0)
        {
            Dd_customer.DataSource = dt;
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
    public void order()
    {
        SqlCommand cmd = new SqlCommand("select count(sl_invoice_no) from tbl_sale where sl_invoice_date='" +DateTime.Now.ToShortDateString()+"'", conn);
        SqlDataAdapter adapt = new SqlDataAdapter(cmd);
        DataTable dt = new DataTable();
        adapt.Fill(dt);
        if (dt.Rows.Count > 0)
        {
            decimal order = Convert.ToDecimal(dt.Rows[0][0]) + 1;
            Txt_order_no.Text = order.ToString();
        }
    }
    //order reference no.
    public void Order_reference()
    {
        string query = "select * from tbl_staff order by st_id desc";
        SqlDataAdapter adapt = new SqlDataAdapter(query, conn);
        DataTable dt = new DataTable();
        adapt.Fill(dt);




        if (dt.Rows.Count > 0)
        {

            //  string total_amount = dt.Rows[0]["sl_total"].ToString();
            //string value = dt.Rows[0][0].ToString();

            //foreach (DataRow dtRow in dt.Rows)
            //{

            //    string query2 = "select * from tbl_estimate where est_order_ref='" + value + "'";
            //    SqlDataAdapter adapt2 = new SqlDataAdapter(query, conn);
            //    DataTable dt2 = new DataTable();
            //    adapt.Fill(dt2);


            //    // On all tables' columns
            //    foreach (DataColumn dc in dt2.Columns)
            //    {
            //        var field1 = dtRow[dc].ToString();
            //    }
            //}



            drp_designer.DataSource = dt;
            drp_designer.DataBind();
            drp_designer.DataTextField = "st_staff_name";
            drp_designer.DataValueField = "st_id";
            drp_designer.DataBind();
            drp_designer.Items.Insert(0, new ListItem("--Show Designer--", "--Show Designer--"));
            drp_designer.SelectedItem.Selected = false;
            drp_designer.Items.FindByText("--Show Designer--").Selected = true;
        }

    }




    public void invoiceid()
    {
        try
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand("SELECT TOP 1 sl_invoice_no FROM tbl_sale ORDER BY sl_id DESC", conn);
            string inv;
            int i = 0;
            SqlDataAdapter adapt = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            adapt.Fill(dt);
      
                if (dt.Rows.Count > 0)
                {
                inv = dt.Rows[0]["sl_invoice_no"].ToString();
                
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
                    Txt_invoice.Text = "INV-" + j.ToString();

                }

                else
                {
                    Txt_invoice.Text = "INV-1";
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

        string material = Dd_material.SelectedValue;




        //new data end
        for (int i = 0; i <= GridView1.Rows.Count; i++)
        {
            total_amount += Convert.ToDecimal(txt_final_amt.Text);

        }
        final_total = total_amount;


        // pcs wise data 
        if (str9 == "Pcs")
        {
            
            decimal cgstamount = Convert.ToDecimal(total2) * Convert.ToDecimal(cgst) / 100;
            decimal sgstamount = Convert.ToDecimal(total2) * Convert.ToDecimal(sgst) / 100;
            decimal igstamount = Convert.ToDecimal(total2) * Convert.ToDecimal(igst) / 100;

            DataTable dt = (DataTable)ViewState["Details"];
            dt.Rows.Add(str, str10, height2, width2, sqrft2, rate2, amount2, quantity2, total2, cgstamount, sgstamount, igstamount, final, cgst, sgst, igst, desc, str9, material);
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
            GridView1.EmptyDataText = "Material";


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
            dt.Rows.Add(str, str10, height2, width2, sqrft2, rate2, amount2, quantity2, total2, cgstamount, sgstamount, igstamount, final, cgst, sgst, igst, desc, str9, material);
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
            GridView1.EmptyDataText = "Material";


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
            dt.Rows.Add(str, str10, height2, width2, sqrft2, rate2, amount2, quantity2, total2, cgstamount, sgstamount, igstamount, final, cgst, sgst, igst, desc, str9, material);
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
            GridView1.EmptyDataText = "Material";


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

            decimal cgstamount = Convert.ToDecimal(total2) * Convert.ToDecimal(cgst) / 100;
            decimal sgstamount = Convert.ToDecimal(total2) * Convert.ToDecimal(sgst) / 100;
            decimal igstamount = Convert.ToDecimal(total2) * Convert.ToDecimal(igst) / 100;

            DataTable dt = (DataTable)ViewState["Details"];
            dt.Rows.Add(str, str10, height2, width2, sqrft2, rate2, amount2, quantity2, total2, cgstamount, sgstamount, igstamount, final, cgst, sgst, igst, desc, str9, material);
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
            GridView1.EmptyDataText = "Material";


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
            dt.Rows.Add(str, str10, height, width, sqrft, rate, amount, quantity, total, cgstamount, sgstamount, igstamount, final, cgst, sgst, igst, desc, str9, material);
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
            GridView1.EmptyDataText = "Material";

            GridView1.DataBind();
            

            decimal a = 0, b = 0, c = 0;

            for (int i = 0; i < (GridView1.Rows.Count); i++)
            {
                // a = Convert.ToDecimal(GridView1.Rows[i].Cells[6].Text.ToString());
                c = c + a; //storing total qty into variable 
            }
            this.clear();
        }
    }

    protected void clear()
    {
        //Dd_enter_product.SelectedIndex = 0;
        //Dd_material.SelectedIndex = 0;
        Txt_description.Text = "";
        txt_width.Text = "";
        txt_height.Text = "";
        txt_sqrft.Text = "";
        txt_rate.Text = "";
        txt_amount.Text = "";
        txt_width.Text = "";
        txt_quantity.Text = "";
        txt_total_amt.Text = "";
        txt_height2.Text = "";
        txt_width2.Text = "";
        txt_sqrft2.Text = "";
        txt_rate2.Text = "";
        txt_amount2.Text = "";
        txt_quantity2.Text = "";
        txt_total_amt2.Text = "";
        txt_cgst.Text = "";
        txt_sgst.Text = "";
        txt_igst.Text = "";
        txt_final_amt.Text = "";
    }

    protected void GridView1_DataBound(object sender, EventArgs e)
    {
     
    }
    int total = 0, indexofcolumn=1;
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
            lbl_subtotal.Text = totaltaxable.ToString();
            lbl_subtotal2.Value = totaltaxable.ToString();

            //Assign the total value to footer label control
            lbl_gst.Text = totalgst.ToString();
            lbl_gst2.Value = totalgst.ToString();
            lbl_totalqty.Text = totalqty.ToString();
            lbl_total_cgst.Value = totalcgst.ToString();
            lbl_total_sgst.Value = totalsgst.ToString();
            lbl_total_igst.Value = totaligst.ToString();
            lbl_total_taxable.Value = totaltaxable.ToString();
        }
        
    }

    protected void Dd_enter_product_SelectedIndexChanged(object sender, EventArgs e)
    {
        
        string rate, cgst, igst, sgst,hsn,unit,desc;
        SqlCommand cmd = new SqlCommand("select * from tbl_product where p_id ='"+Dd_enter_product.SelectedValue+"'", conn);
        SqlDataAdapter adapt = new SqlDataAdapter(cmd);
        DataTable dt = new DataTable();

        adapt.Fill(dt);
        if (dt.Rows.Count > 0)
        {
            //customer wise rate system code here 
            SqlCommand cmd3 = new SqlCommand("select * from tbl_rate where p_name='"+Dd_enter_product.SelectedItem.Text+"' AND cust_name='"+Dd_customer.SelectedItem.Text+"'",conn);
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
            
            Txt_description.Text = desc;

            lbl_product_hsn.Value = hsn;
            lbl_unit.Value = unit;

         
        }
       

    }

    public void material()
    {
        string query = "select * from tbl_purchase_product Order By p_name asc";
        SqlDataAdapter adapt5 = new SqlDataAdapter(query, conn);
        DataTable dt6 = new DataTable();
        adapt5.Fill(dt6);
        if (dt6.Rows.Count > 0)
        {
            Dd_material.DataSource = dt6;
            Dd_material.DataBind();
            Dd_material.DataTextField = "p_name";

            Dd_material.DataValueField = "p_id";
            Dd_material.DataBind();
            Dd_material.Items.Insert(0, new ListItem("--Select--", "--Select--"));
            Dd_material.SelectedItem.Selected = false;
            Dd_material.Items.FindByText("--Select--").Selected = true;
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

    private bool dataEntry()
    {
        
        bool isTrue=true;
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
                        SqlCommand cmd = new SqlCommand("insert into tbl_sale_invoice values(@s_invoice_no,@s_date,@c_id,@s_order_no,@s_invoice_date,@s_due_date,@s_product_name,@s_quantity,@s_total_quantity,@s_rate,@s_discount,@s_cgstp,@s_cgsta,@s_sgstp,@s_sgsta,@s_igstp,@s_igsta,@s_amount,@s_sub_total,@s_total_gst,@s_shipping_charges,@s_adjustment,@s_total,@s_stotal,@s_hsn,@s_unit,@s_desc,@s_height,@s_width,@s_size,@s_samount,@s_total_cgst,@s_total_sgst,@s_total_igst,@s_total_taxable,@s_balance,@s_dtp_charges,@s_fitting_charges,@s_payment_method,@drp_designer,@s_transaction_type,@s_cess,@s_material,@s_pasting_charges,@s_framing_charges,@s_installation_charges,@s_upichqno)", conn);
                        cmd.Parameters.AddWithValue("@s_invoice_no", Convert.ToString(Txt_invoice.Text));
                        cmd.Parameters.AddWithValue("@s_date", Convert.ToDateTime(DateTime.Now.ToShortDateString()).ToString("MM/dd/yyyy"));
                        cmd.Parameters.AddWithValue("@c_id", Convert.ToString(Dd_customer.SelectedValue));
                        cmd.Parameters.AddWithValue("@s_order_no", Convert.ToString(Txt_order_no.Text));
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
                        cmd.Parameters.AddWithValue("@s_hsn", Convert.ToString(GridView1.Rows[i].Cells[1].Text));
                        cmd.Parameters.AddWithValue("@s_desc", Convert.ToString(GridView1.Rows[i].Cells[16].Text));
                        cmd.Parameters.AddWithValue("@s_height", "");
                        cmd.Parameters.AddWithValue("@s_width", "");
                        cmd.Parameters.AddWithValue("@s_size", "");
                        cmd.Parameters.AddWithValue("@s_samount", "");
                        cmd.Parameters.AddWithValue("@s_total_cgst", Convert.ToDecimal(lbl_total_cgst.Value));
                        cmd.Parameters.AddWithValue("@s_total_sgst", Convert.ToDecimal(lbl_total_sgst.Value));
                        cmd.Parameters.AddWithValue("@s_total_igst", Convert.ToDecimal(lbl_total_igst.Value));
                        cmd.Parameters.AddWithValue("@s_total_taxable", Convert.ToDecimal(lbl_total_taxable.Value));
                        cmd.Parameters.AddWithValue("@s_balance", Convert.ToDecimal(new_balance));

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

                        if (GridView1.Rows[i].Cells[18].Text == "--Select--" || GridView1.Rows[i].Cells[18].Text == "")
                        {
                            cmd.Parameters.AddWithValue("@s_material", "0");
                        }
                        else
                        {
                            cmd.Parameters.AddWithValue("@s_material", Convert.ToDecimal(GridView1.Rows[i].Cells[18].Text));
                        }
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

                        //material stock
                        //string sqrft = Convert.ToString(GridView1.Rows[i].Cells[4].Text);

                        //if ((sqrft) == string.Empty || sqrft == "&nbsp;")
                        //{

                        //}

                        decimal Qty_total = Convert.ToDecimal(GridView1.Rows[i].Cells[7].Text);

                        SqlCommand cmd33 = new SqlCommand("UPDATE tbl_purchase_product SET p_stock=p_stock-('" + Qty_total + "') WHERE p_id='" + Convert.ToString(GridView1.Rows[i].Cells[18].Text) + "'", conn);

                        conn.Open();
                        cmd33.ExecuteNonQuery();
                        conn.Close();

                        //customer rate
                        string ProductName, CustomerName;
                        decimal ProductRate;
                        ProductName = Convert.ToString(GridView1.Rows[i].Cells[0].Text);
                        CustomerName = Convert.ToString(Dd_customer.SelectedItem.Text);
                        ProductRate = Convert.ToDecimal(GridView1.Rows[i].Cells[5].Text);

                        SqlCommand cmd8 = new SqlCommand("select * from tbl_rate where p_name='" + ProductName + "' and cust_name='" + CustomerName + "'", conn);
                        SqlDataAdapter adapt8 = new SqlDataAdapter(cmd8);
                        DataTable dt8 = new DataTable();
                        adapt8.Fill(dt8);
                        if (dt8.Rows.Count > 0)
                        {

                        }

                        else
                        {
                            SqlCommand cmd9 = new SqlCommand("insert into tbl_rate values(@cust_name,@p_name,@r_rate,@c_id)", conn);
                            cmd9.Parameters.AddWithValue("@cust_name", Convert.ToString(Dd_customer.SelectedItem.Text));
                            cmd9.Parameters.AddWithValue("@p_name", Convert.ToString(GridView1.Rows[i].Cells[0].Text));
                            cmd9.Parameters.AddWithValue("@r_rate", Convert.ToDecimal(GridView1.Rows[i].Cells[5].Text));
                            cmd9.Parameters.AddWithValue("@c_id", Convert.ToString(Dd_customer.SelectedValue));

                            conn.Open();
                            cmd9.ExecuteNonQuery();
                            conn.Close();
                        }
                    }
                    else
                    {
                        SqlCommand cmd = new SqlCommand("insert into tbl_sale_invoice values(@s_invoice_no,@s_date,@c_id,@s_order_no,@s_invoice_date,@s_due_date,@s_product_name,@s_quantity,@s_total_quantity,@s_rate,@s_discount,@s_cgstp,@s_cgsta,@s_sgstp,@s_sgsta,@s_igstp,@s_igsta,@s_amount,@s_sub_total,@s_total_gst,@s_shipping_charges,@s_adjustment,@s_total,@s_stotal,@s_hsn,@s_unit,@s_desc,@s_height,@s_width,@s_size,@s_samount,@s_total_cgst,@s_total_sgst,@s_total_igst,@s_total_taxable,@s_balance,@s_dtp_charges,@s_fitting_charges,@s_payment_method,@drp_designer,@s_transaction_type,@s_cess,@s_material,@s_pasting_charges,@s_framing_charges,@s_installation_charges,@s_upichqno)", conn);
                        cmd.Parameters.AddWithValue("@s_invoice_no", Convert.ToString(Txt_invoice.Text));
                        cmd.Parameters.AddWithValue("@s_date", Convert.ToDateTime(DateTime.Now.ToShortDateString()).ToString("MM/dd/yyyy"));
                        cmd.Parameters.AddWithValue("@c_id", Convert.ToString(Dd_customer.SelectedValue));
                        cmd.Parameters.AddWithValue("@s_order_no", Convert.ToString(Txt_order_no.Text));
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
                        cmd.Parameters.AddWithValue("@s_hsn", Convert.ToString(GridView1.Rows[i].Cells[1].Text));
                        cmd.Parameters.AddWithValue("@s_desc", Convert.ToString(GridView1.Rows[i].Cells[16].Text));
                        cmd.Parameters.AddWithValue("@s_height", Convert.ToDecimal(GridView1.Rows[i].Cells[2].Text));
                        cmd.Parameters.AddWithValue("@s_width", Convert.ToDecimal(GridView1.Rows[i].Cells[3].Text));
                        cmd.Parameters.AddWithValue("@s_size", Convert.ToDecimal(GridView1.Rows[i].Cells[4].Text));
                        cmd.Parameters.AddWithValue("@s_samount", Convert.ToDecimal(GridView1.Rows[i].Cells[6].Text));
                        cmd.Parameters.AddWithValue("@s_total_cgst", Convert.ToDecimal(lbl_total_cgst.Value));
                        cmd.Parameters.AddWithValue("@s_total_sgst", Convert.ToDecimal(lbl_total_sgst.Value));
                        cmd.Parameters.AddWithValue("@s_total_igst", Convert.ToDecimal(lbl_total_igst.Value));
                        cmd.Parameters.AddWithValue("@s_total_taxable", Convert.ToDecimal(lbl_total_taxable.Value));
                        cmd.Parameters.AddWithValue("@s_balance", Convert.ToDecimal(new_balance));

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

                        if (GridView1.Rows[i].Cells[18].Text == "--Select--" || GridView1.Rows[i].Cells[18].Text == "")
                        {
                            cmd.Parameters.AddWithValue("@s_material", "0");
                        }
                        else
                        {
                            cmd.Parameters.AddWithValue("@s_material", Convert.ToDecimal(GridView1.Rows[i].Cells[18].Text));
                        }

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

                        //material stock
                        string sqrft = Convert.ToString(GridView1.Rows[i].Cells[4].Text);

                        if ((sqrft) == string.Empty || sqrft == "&nbsp;")
                        {

                        }

                        if (GridView1.Rows[i].Cells[18].Text == "--Select--" || GridView1.Rows[i].Cells[18].Text == "")
                        {
                            GridView1.Rows[i].Cells[18].Text = "0";
                        }
                        else
                        {

                        }

                        decimal Sqrft_total = Convert.ToDecimal(GridView1.Rows[i].Cells[4].Text) * Convert.ToDecimal(GridView1.Rows[i].Cells[7].Text);

                        SqlCommand cmd33 = new SqlCommand("UPDATE tbl_purchase_product SET p_stock=p_stock-('" + Sqrft_total + "') WHERE p_id='" + Convert.ToString(GridView1.Rows[i].Cells[18].Text) + "'", conn);

                        conn.Open();
                        cmd33.ExecuteNonQuery();
                        conn.Close();

                        //used stock material

                        SqlCommand cmd44 = new SqlCommand("insert into tbl_used_stock values(@p_name,@date,@sqrft,@quantity)", conn);
                        cmd44.Parameters.AddWithValue("@p_name", Convert.ToString(GridView1.Rows[i].Cells[0].Text));
                        cmd44.Parameters.AddWithValue("@date", Convert.ToDateTime(Txt_invoice_date.Text).ToString("MM/dd/yyyy"));
                        cmd44.Parameters.AddWithValue("@sqrft", Sqrft_total);
                        cmd44.Parameters.AddWithValue("@quantity", Convert.ToDecimal(GridView1.Rows[i].Cells[7].Text));

                        conn.Open();
                        cmd44.ExecuteNonQuery();
                        conn.Close();

                        //customer rate
                        string ProductName, CustomerName;
                        decimal ProductRate;
                        ProductName = Convert.ToString(GridView1.Rows[i].Cells[0].Text);
                        CustomerName = Convert.ToString(Dd_customer.SelectedItem.Text);
                        ProductRate = Convert.ToDecimal(GridView1.Rows[i].Cells[5].Text);

                        SqlCommand cmd8 = new SqlCommand("select * from tbl_rate where p_name='" + ProductName + "' and cust_name='" + CustomerName + "'", conn);
                        SqlDataAdapter adapt8 = new SqlDataAdapter(cmd8);
                        DataTable dt8 = new DataTable();
                        adapt8.Fill(dt8);
                        if (dt8.Rows.Count > 0)
                        {

                        }

                        else
                        {
                            SqlCommand cmd9 = new SqlCommand("insert into tbl_rate values(@cust_name,@p_name,@r_rate,@c_id)", conn);
                            cmd9.Parameters.AddWithValue("@cust_name", Convert.ToString(Dd_customer.SelectedItem.Text));
                            cmd9.Parameters.AddWithValue("@p_name", Convert.ToString(GridView1.Rows[i].Cells[0].Text));
                            cmd9.Parameters.AddWithValue("@r_rate", Convert.ToDecimal(GridView1.Rows[i].Cells[5].Text));
                            cmd9.Parameters.AddWithValue("@c_id", Convert.ToString(Dd_customer.SelectedValue));

                            conn.Open();
                            cmd9.ExecuteNonQuery();
                            conn.Close();
                        }
                    }
                }
                SqlCommand cmd2 = new SqlCommand("insert into tbl_sale values(@sl_invoice_no,@sl_date,@c_id,@sl_order_no,@sl_invoice_date,@sl_due_date,@sl_total_quantity,@sl_discount,@sl_sub_total,@sl_total_gst,@sl_shipping_charges,@sl_adjustment,@sl_total,@sl_total_cgst,@sl_total_sgst,@sl_total_igst,@sl_total_taxable,@sl_balance,@sl_dtp_charges,@sl_fitting_charges,@sl_payment_method,@drp_designer,@sl_transaction_type,@sl_cess,@sl_pasting_charges,@sl_framing_charges,@sl_installation_charges,@sl_upichqno)", conn);
                cmd2.Parameters.AddWithValue("@sl_invoice_no", Convert.ToString(Txt_invoice.Text));
                cmd2.Parameters.AddWithValue("@sl_date", Convert.ToDateTime(DateTime.Now.ToShortDateString()).ToString("MM/dd/yyyy"));
                cmd2.Parameters.AddWithValue("@c_id", Convert.ToString(Dd_customer.SelectedValue));
                cmd2.Parameters.AddWithValue("@sl_order_no", Convert.ToString(Txt_order_no.Text));
                cmd2.Parameters.AddWithValue("@sl_invoice_date", Convert.ToDateTime(Txt_invoice_date.Text).ToString("MM/dd/yyyy"));
                cmd2.Parameters.AddWithValue("@sl_due_date", Convert.ToDateTime(Txt_due_date.Text).ToString("MM/dd/yyyy"));

                cmd2.Parameters.AddWithValue("@sl_total_quantity", Convert.ToDecimal(lbl_totalqty.Text));

                cmd2.Parameters.AddWithValue("@sl_discount", Convert.ToDecimal(Txt_discount.Text));


                cmd2.Parameters.AddWithValue("@sl_sub_total", Convert.ToDecimal(lbl_subtotal.Text));
                cmd2.Parameters.AddWithValue("@sl_total_gst", Convert.ToDecimal(lbl_gst.Text));

                if (Txt_TransportCharges.Text == "")
                {
                    cmd2.Parameters.AddWithValue("@sl_shipping_charges", "0");
                }
                else
                {
                    cmd2.Parameters.AddWithValue("@sl_shipping_charges", Convert.ToDecimal(Txt_TransportCharges.Text));
                }

                
                cmd2.Parameters.AddWithValue("@sl_adjustment", Convert.ToDecimal(Txt_advance.Text));
                cmd2.Parameters.AddWithValue("@sl_total", Convert.ToDecimal(hide_total.Text));
                cmd2.Parameters.AddWithValue("@sl_total_cgst", Convert.ToDecimal(lbl_total_cgst.Value));
                cmd2.Parameters.AddWithValue("@sl_total_sgst", Convert.ToDecimal(lbl_total_sgst.Value));
                cmd2.Parameters.AddWithValue("@sl_total_igst", Convert.ToDecimal(lbl_total_igst.Value));
                cmd2.Parameters.AddWithValue("@sl_total_taxable", Convert.ToDecimal(lbl_total_taxable.Value));
                cmd2.Parameters.AddWithValue("@sl_balance", Convert.ToDecimal(new_balance));

                if (Txt_Dtp_charges.Text == "")
                {
                    cmd2.Parameters.AddWithValue("@sl_dtp_charges", "0");
                }
                else
                {
                    cmd2.Parameters.AddWithValue("@sl_dtp_charges", Convert.ToDecimal(Txt_Dtp_charges.Text));
                }

                if (Txt_Fitting.Text == "")
                {
                    cmd2.Parameters.AddWithValue("@sl_fitting_charges", "0");
                }
                else
                {
                    cmd2.Parameters.AddWithValue("@sl_fitting_charges", Convert.ToDecimal(Txt_Fitting.Text));
                }

               
              
                cmd2.Parameters.AddWithValue("@sl_payment_method", Convert.ToString(drp_payment.SelectedItem.Text));
                cmd2.Parameters.AddWithValue("@drp_designer", Convert.ToString(drp_designer.SelectedItem.Text));
                cmd2.Parameters.AddWithValue("@sl_transaction_type", "Sale");
                cmd2.Parameters.AddWithValue("@sl_cess", "0");
                

                if (Txt_Pasting.Text == "")
                {
                    cmd2.Parameters.AddWithValue("@sl_pasting_charges", "0");
                }
                else
                {
                    cmd2.Parameters.AddWithValue("@sl_pasting_charges", Convert.ToDecimal(Txt_Pasting.Text));
                }

                if (Txt_Framing.Text == "")
                {
                    cmd2.Parameters.AddWithValue("@sl_framing_charges", "0");
                }
                else
                {
                    cmd2.Parameters.AddWithValue("@sl_framing_charges", Convert.ToDecimal(Txt_Framing.Text));
                }

                if (Txt_install.Text == "")
                {
                    cmd2.Parameters.AddWithValue("@sl_installation_charges", "0");
                }
                else
                {
                    cmd2.Parameters.AddWithValue("@sl_installation_charges", Convert.ToDecimal(Txt_install.Text));
                }

                if (txt_UPIno.Text == "")
                {
                    cmd2.Parameters.AddWithValue("@sl_upichqno", "");
                }
                else
                {
                    cmd2.Parameters.AddWithValue("@sl_upichqno", txt_UPIno.Text);
                }

                conn.Open();
                cmd2.ExecuteNonQuery();
                conn.Close();

                SqlCommand cmd3 = new SqlCommand("update tbl_customer set c_opening_balance=c_opening_balance + '" + new_balance + "' where c_id='" + Dd_customer.SelectedValue + "'", conn);

                conn.Open();
                cmd3.ExecuteNonQuery();
                conn.Close();

                SqlCommand cmd4 = new SqlCommand("insert into tbl_sale_invoice_payment values(@si_invoice,@c_id,@si_due,@si_discount,@si_pay,@si_mode,@si_chno,@si_balance,@si_date,@si_upichqno)", conn);
                cmd4.Parameters.AddWithValue("@si_invoice", Convert.ToString(Txt_invoice.Text));
                cmd4.Parameters.AddWithValue("@c_id", Convert.ToString(Dd_customer.SelectedValue));
                cmd4.Parameters.AddWithValue("@si_due", Convert.ToDecimal(hide_total.Text));
                cmd4.Parameters.AddWithValue("@si_discount", Convert.ToDecimal(Txt_discount.Text));
                cmd4.Parameters.AddWithValue("@si_pay", Convert.ToDecimal(Txt_advance.Text));
                cmd4.Parameters.AddWithValue("@si_mode", "Cash");
                cmd4.Parameters.AddWithValue("@si_chno", "");
                cmd4.Parameters.AddWithValue("@si_balance", Convert.ToDecimal(new_balance));
                cmd4.Parameters.AddWithValue("@si_date", Convert.ToDateTime(DateTime.Now.ToShortDateString()).ToString("MM/dd/yyyy"));
                if (txt_UPIno.Text == "")
                {
                    cmd4.Parameters.AddWithValue("@si_upichqno", "");
                }
                else
                {
                    cmd4.Parameters.AddWithValue("@si_upichqno", txt_UPIno.Text);
                }
                conn.Open();
                cmd4.ExecuteNonQuery();
                conn.Close();

                try
                {
                    SqlCommand cmd5 = new SqlCommand("select * from tbl_company_details ", conn);
                    SqlDataAdapter adapt5 = new SqlDataAdapter(cmd5);
                    DataTable dt5 = new DataTable();
                    adapt5.Fill(dt5);
                    if (dt5.Rows.Count > 0)
                    {
                        com_email = dt5.Rows[0]["com_company_name"].ToString();

                    }

                    SqlCommand cmd6 = new SqlCommand("select * from tbl_feature", conn);
                    SqlDataAdapter adapt6 = new SqlDataAdapter(cmd6);
                    DataTable dt6 = new DataTable();
                    adapt6.Fill(dt6);
                    if (dt6.Rows.Count > 0)
                    {
                        sms = Convert.ToInt32(dt6.Rows[0]["fe_sms"]);
                        mail2 = Convert.ToInt32(dt6.Rows[0]["fe_mail"]);

                        if (sms == 1)
                        {

                            SqlCommand cmd7 = new SqlCommand("select * from tbl_sms_config ", conn);
                            SqlDataAdapter adapt7 = new SqlDataAdapter(cmd7);
                            DataTable dt7 = new DataTable();
                            adapt7.Fill(dt7);
                            if (dt7.Rows.Count > 0)
                            {
                                key = dt7.Rows[0]["sc_key"].ToString();
                                country = dt7.Rows[0]["sc_country"].ToString();

                                senderid = dt7.Rows[0]["sc_sender"].ToString();
                                route = dt7.Rows[0]["sc_route"].ToString();

                            }

                        //    decimal mob = Convert.ToDecimal(lbl_cutomer_contact.Value);
                        //    WebClient client = new WebClient();
                        //    string to;
                        //    Int64 temp_id = 1234567890123456788;
                        //    string msgRecepient = mob.ToString();
                        //    string msgText = "Welcome to " + com_email + ", Your invoice " + Txt_invoice.Text.ToString() + " has been created. Your Invoice Amount is " + finaltotal.ToString() + ".";

                        //    to = mob.ToString();
                        //    string baseURL = "http://sms.hitechsms.com/app/smsapi/index.php?" +

                        //    "key=" + key +
                        //       "&campaign=" + "0" +
                        //       "&routeid=" + route +
                        //       "&type=" + "text" +
                        //       "&contacts=" + msgRecepient +
                        //       "&senderid=" + senderid +
                        //       "&msg=" + System.Web.HttpUtility.UrlEncode(msgText, Encoding.GetEncoding("ISO-8859-1")) +
                        //       "&template_id=" + temp_id;


                        //    // client.OpenRead(baseURL);

                        //StringBuilder sbPostData = new StringBuilder();
                        //    sbPostData.AppendFormat("key={0}", key);
                        //    sbPostData.AppendFormat("&campaign={0}", "0");
                        //    sbPostData.AppendFormat("&routeid={0}", route);
                        //    sbPostData.AppendFormat("&type={0}", "text");
                        //    sbPostData.AppendFormat("&contacts={0}", msgRecepient);
                        //    sbPostData.AppendFormat("&senderid={0}", senderid);
                        //    sbPostData.AppendFormat("&msg={0}", System.Web.HttpUtility.UrlEncode(msgText, Encoding.GetEncoding("ISO-8859-1")));
                        //    sbPostData.AppendFormat("&template_id={0}", temp_id);


                        //    //Create HTTPWebrequest
                        //    HttpWebRequest httpWReq = (HttpWebRequest)WebRequest.Create(baseURL);
                        //    //Prepare and Add URL Encoded data
                        //    UTF8Encoding encoding = new UTF8Encoding();
                        //    byte[] data = encoding.GetBytes(sbPostData.ToString());
                        //    //Specify post method
                        //    httpWReq.Method = "POST";
                        //    httpWReq.ContentType = "application/x-www-form-urlencoded";
                        //    httpWReq.ContentLength = data.Length;
                        //    using (Stream stream = httpWReq.GetRequestStream())
                        //    {
                        //        stream.Write(data, 0, data.Length);
                        //    }
                        //    //Get the response
                        //    HttpWebResponse response = (HttpWebResponse)httpWReq.GetResponse();
                        //    StreamReader reader = new StreamReader(response.GetResponseStream());
                        //    string responseString = reader.ReadToEnd();
                            
                        //    //Close the response
                        //    reader.Close();
                        //    response.Close();

                        }
                        if (mail2 == 1)
                        {
                            try
                            {
                                if (lbl_cutomer_email.Value.ToString() != "")
                                {
                                    SqlCommand cmd8 = new SqlCommand("select * from tbl_email_config ", conn);
                                    SqlDataAdapter adapt8 = new SqlDataAdapter(cmd8);
                                    DataTable dt8 = new DataTable();
                                    adapt8.Fill(dt8);
                                    if (dt8.Rows.Count > 0)
                                    {
                                        email = dt8.Rows[0]["ec_email"].ToString();
                                        password = dt8.Rows[0]["ec_password"].ToString();

                                        port = dt8.Rows[0]["ec_port"].ToString();
                                        subject = dt8.Rows[0]["ec_subject"].ToString();
                                        smtp = dt8.Rows[0]["ec_smtp"].ToString();
                                    }

                                    MailMessage mail = new MailMessage();
                                    SmtpClient SmtpServer = new SmtpClient(smtp);

                                    mail.From = new MailAddress(email);
                                    mail.To.Add(lbl_cutomer_email.Value.ToString());
                                    mail.Subject = "Invoice Created";
                                    mail.Body = "Welcome to " + com_email + ", Your invoice " + Txt_invoice.Text.ToString() + " has been created. Your Invoice Amount is " + finaltotal.ToString() + ".";

                                    SmtpServer.Port = Convert.ToInt32(port);
                                    SmtpServer.Credentials = new System.Net.NetworkCredential(email, password);
                                    SmtpServer.EnableSsl = true;

                                    SmtpServer.Send(mail);
                                }
                            }
                            catch (Exception ex)
                            { }
                        }
                    }
                }
                catch (Exception exp)
                { }

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
        //System.Threading.Thread.Sleep(5000);
        bool isTrue = dataEntry();
        if(isTrue==true)
        {
           
            //Response.Redirect("invoice_report.aspx?insert=success");
            string redirectScript = " window.location.href = 'invoice_report.aspx?insert=success';";
            System.Web.UI.ScriptManager.RegisterStartupScript(this, GetType(), "displayalertmessage", "alert('New Sale Invoice Added Successfully!!!');" + redirectScript, true);
        }
        else
        {
            Btn_generate_pdf.Enabled = true;
        }
    }

    protected void Btn_submit_payment_Click(object sender, EventArgs e)
    {
        bool isTrue = dataEntry();
        if (isTrue == true)
        {
            string redirectScript = " window.location.href = 'bill.aspx?invoice=" + Txt_invoice.Text + "';";
            System.Web.UI.ScriptManager.RegisterStartupScript(this, GetType(), "displayalertmessage", "alert('New Sale Invoice Added Successfully!!!');" + redirectScript, true);

        }
        else
        {

        }
    }

    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        //GridView1.PageIndex = e.NewPageIndex;
      
    }



    protected void Dd_customer_SelectedIndexChanged(object sender, EventArgs e)
    {
        SqlCommand cmd = new SqlCommand("select * from tbl_customer where c_id ='" + Dd_customer.SelectedValue + "'", conn);
        SqlDataAdapter adapt = new SqlDataAdapter(cmd);
        DataTable dt = new DataTable();

        adapt.Fill(dt);
        if (dt.Rows.Count > 0)
        {
            lbl_cutomer_contact.Value = dt.Rows[0]["c_contact"].ToString();
            lbl_cutomer_email.Value = dt.Rows[0]["c_email"].ToString();
            lbl_total_remaining.Text= dt.Rows[0]["c_opening_balance"].ToString();

            order();
            this.Order_reference();
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
        SqlCommand cmd = new SqlCommand("Select * from tbl_customer where c_name='" + Txt_customer_name.Text.Trim() + "' ", conn);

        SqlDataAdapter adapt = new SqlDataAdapter(cmd);
        DataTable dt = new DataTable();
        adapt.Fill(dt);


        //var result = cmd2.ExecuteScalar();
        if (dt.Rows.Count > 0)
        {

            lbl_msg.ForeColor = System.Drawing.Color.Red;
            lbl_msg.Text = "Customer Already Exist!!!";
        }
        else
        {
            SqlCommand cmd2 = new SqlCommand("insert into tbl_customer values(@c_name,@c_address,@c_contact,@c_contact2,@c_gst_no,@c_opening_balance,@c_email,@c_dob,@c_anidate)", conn);
            cmd2.Parameters.AddWithValue("@c_name", Txt_customer_name.Text);
            if (Txt_address.Text == "")
            {
                cmd2.Parameters.AddWithValue("@c_address", "-");
            }
            else
            {
                cmd2.Parameters.AddWithValue("@c_address", Txt_address.Text);
            }
            if (Txt_contact.Text == "")
            {
                cmd2.Parameters.AddWithValue("@c_contact", "-");
            }
            else
            {
                cmd2.Parameters.AddWithValue("@c_contact", Txt_contact.Text);
            }

            if (Txt_contact2.Text == "")
            {
                cmd2.Parameters.AddWithValue("@c_contact2", "-");
            }
            else
            {
                cmd2.Parameters.AddWithValue("@c_contact2", Txt_contact2.Text);
            }
            if (Txt_gst_no.Text == "")
            {
                cmd2.Parameters.AddWithValue("@c_gst_no", "-");
            }
            else
            {
                cmd2.Parameters.AddWithValue("@c_gst_no", Txt_gst_no.Text);
            }
            if (Txt_opening_balance.Text == "")
            {
                cmd2.Parameters.AddWithValue("@c_opening_balance", 0);
            }
            else
            {
                cmd2.Parameters.AddWithValue("@c_opening_balance", Txt_opening_balance.Text);
            }

            if (Txt_email.Text == "")
            {
                cmd2.Parameters.AddWithValue("@c_email", "");
            }
            else
            {
                cmd2.Parameters.AddWithValue("@c_email", Txt_email.Text);
            }

            if (Txt_dob.Text == "")
            {
                cmd2.Parameters.AddWithValue("@c_dob", "");
            }
            else
            {
                cmd2.Parameters.AddWithValue("@c_dob", Txt_dob.Text);
            }

            if (Txt_ani.Text == "")
            {
                cmd2.Parameters.AddWithValue("@c_anidate", "");
            }
            else
            {
                cmd2.Parameters.AddWithValue("@c_anidate", Txt_ani.Text);
            }
            conn.Open();
            cmd2.ExecuteNonQuery();
            conn.Close();
            customer();
            lbl_msg.ForeColor = System.Drawing.Color.Green;
            lbl_msg.Text = "Customer Added Successfully!!!";
            //string redirectScript = " window.location.href = 'sale_invoice.aspx';";
            //System.Web.UI.ScriptManager.RegisterStartupScript(this, GetType(), "displayalertmessage", "alert('New Customer Added Successfully!!!');" + redirectScript, true);

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

            //string redirectScript = " window.location.href = 'sale_invoice.aspx';";
            //System.Web.UI.ScriptManager.RegisterStartupScript(this, GetType(), "displayalertmessage", "alert('New Sale Product Added Successfully!!!');" + redirectScript, true);


        }
    }



    protected void drp_order_ref_SelectedIndexChanged(object sender, EventArgs e)
    {
       // order_ref_total();
    }

    protected void drp_payment_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (drp_payment.SelectedItem.Text == "Cash" || drp_payment.SelectedItem.Text == "Credit")
        {
            upinoheading.Visible = false;
            upinotxt.Visible = false;
        }
        else
        {
            upinoheading.Visible = true;
            upinotxt.Visible = true;
        }


    }
}