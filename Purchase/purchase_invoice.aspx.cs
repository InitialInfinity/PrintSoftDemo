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

public partial class Purchase_purchase_invoice : System.Web.UI.Page
{
    SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["String"].ConnectionString);
    decimal total_amount = 0, final_total = 0, totalcgstnew = 0, totalsgstnew = 0, totaligstnew = 0, cgstamtnew, sgstamtnew, igstamtnew, shipping, adjustment, discount;
    decimal totalvalue = 0, totalcgst = 0, totalsgst = 0, totaligst = 0, totalgst = 0, totalqty, totaltaxable = 0;
    string product_name;
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
                Txt_shipping.Text = "0";
                Txt_adjustment.Text = "0";
                Txt_discount.Text = "0";
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
        string query = "select * from tbl_purchase_product Order By p_name asc";
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
    public void order()
    {
        SqlCommand cmd10 = new SqlCommand("select count(pu_invoice_no) from tbl_purchase where v_id='" + Dd_customer.SelectedValue + "'", conn);
        SqlDataAdapter adapt10 = new SqlDataAdapter(cmd10);
        DataTable dt10 = new DataTable();
        adapt10.Fill(dt10);
        if (dt10.Rows.Count > 0)
        {
            decimal order = Convert.ToDecimal(dt10.Rows[0][0]) + 1;
            Txt_order_no.Text = order.ToString();
        }
    }
    public void invoiceid()
    {
        try
        {
            conn.Open();

            SqlCommand cmd = new SqlCommand("SELECT TOP 1 pu_invoice_no FROM tbl_purchase ORDER BY pu_id DESC", conn);
            string inv;
            int i = 0;
            SqlDataAdapter adapt = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            adapt.Fill(dt);



            if (dt.Rows.Count > 0)
            {
                inv = dt.Rows[0]["pu_invoice_no"].ToString();

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
                Txt_invoice.Text = "PO-" + j.ToString();

            }

            else
            {
                Txt_invoice.Text = "PO-1";
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
    protected void Dd_customer_SelectedIndexChanged(object sender, EventArgs e)
    {
        order();
    }
    protected void Btn_cart_Click(object sender, EventArgs e)
    {
        GridView1.Visible = true;
        //Txt_adjustment.Text = "0";
        //Txt_discount.Text = "0";
        //Txt_shipping.Text = "0";
        string str = Dd_enter_product.SelectedItem.Text;

        string str2 = txt_quantity.Text.Trim();
        string str3 = txt_rate.Text.Trim();

        string str4 = txt_cgst.Text.Trim();
        string str8 = txt_total_amt.Text.Trim();
        string str5 = txt_sgst.Text.Trim();
        string str6 = txt_igst.Text.Trim();
        string str7 = "0";
        string str9 = lbl_unit.Value.Trim();
        string str10 = lbl_product_hsn.Value.Trim();

        //new data 
        string height = "0";
        string width = "0";
        string sqrft = "0";
        string rate = txt_rate.Text.Trim();
        string amount = "0";

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
            if (cgst == "0")
            {
                cgstamtnew = 0;
            }
            else
            {
                cgstamtnew = Convert.ToDecimal(cgstamount.ToString("#.##"));
            }

            decimal sgstamount = Convert.ToDecimal(total2) * Convert.ToDecimal(sgst) / 100;
            if (sgst == "0")
            {
                sgstamtnew = 0;
            }
            else
            {
                sgstamtnew = Convert.ToDecimal(sgstamount.ToString("#.##"));
            }

            decimal igstamount = Convert.ToDecimal(total2) * Convert.ToDecimal(igst) / 100;
            if (igst == "0")
            {
                igstamtnew = 0;
            }
            else
            {
                igstamtnew = Convert.ToDecimal(igstamount.ToString("#.##"));
            }

            DataTable dt = (DataTable)ViewState["Details"];
            dt.Rows.Add(str, str10, height2, width2, sqrft2, rate2, amount2, quantity2, total2, cgstamtnew, sgstamtnew, igstamtnew, final, cgst, sgst, igst, desc, str9);
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

        else if (str9 == "Running Feet")
        {



            decimal cgstamount = Convert.ToDecimal(total2) * Convert.ToDecimal(cgst) / 100;
            if (cgst == "0")
            {
                cgstamtnew = 0;
            }
            else
            {
                cgstamtnew = Convert.ToDecimal(cgstamount.ToString("#.##"));
            }

            decimal sgstamount = Convert.ToDecimal(total2) * Convert.ToDecimal(sgst) / 100;
            if (sgst == "0")
            {
                sgstamtnew = 0;
            }
            else
            {
                sgstamtnew = Convert.ToDecimal(sgstamount.ToString("#.##"));
            }

            decimal igstamount = Convert.ToDecimal(total2) * Convert.ToDecimal(igst) / 100;
            if (igst == "0")
            {
                igstamtnew = 0;
            }
            else
            {
                igstamtnew = Convert.ToDecimal(igstamount.ToString("#.##"));
            }

            DataTable dt = (DataTable)ViewState["Details"];
            dt.Rows.Add(str, str10, height2, width2, sqrft2, rate2, amount2, quantity2, total2, cgstamtnew, sgstamtnew, igstamtnew, final, cgst, sgst, igst, desc, str9);
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

        else if (str9 == "Packet")
        {



            decimal cgstamount = Convert.ToDecimal(total2) * Convert.ToDecimal(cgst) / 100;
            if (cgst == "0")
            {
                cgstamtnew = 0;
            }
            else
            {
                cgstamtnew = Convert.ToDecimal(cgstamount.ToString("#.##"));
            }

            decimal sgstamount = Convert.ToDecimal(total2) * Convert.ToDecimal(sgst) / 100;
            if (sgst == "0")
            {
                sgstamtnew = 0;
            }
            else
            {
                sgstamtnew = Convert.ToDecimal(sgstamount.ToString("#.##"));
            }

            decimal igstamount = Convert.ToDecimal(total2) * Convert.ToDecimal(igst) / 100;
            if (igst == "0")
            {
                igstamtnew = 0;
            }
            else
            {
                igstamtnew = Convert.ToDecimal(igstamount.ToString("#.##"));
            }

            DataTable dt = (DataTable)ViewState["Details"];
            dt.Rows.Add(str, str10, height2, width2, sqrft2, rate2, amount2, quantity2, total2, cgstamtnew, sgstamtnew, igstamtnew, final, cgst, sgst, igst, desc, str9);
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

        else if (str9 == "Copy")
        {



            decimal cgstamount = Convert.ToDecimal(total2) * Convert.ToDecimal(cgst) / 100;
            if (cgst == "0")
            {
                cgstamtnew = 0;
            }
            else
            {
                cgstamtnew = Convert.ToDecimal(cgstamount.ToString("#.##"));
            }

            decimal sgstamount = Convert.ToDecimal(total2) * Convert.ToDecimal(sgst) / 100;
            if (sgst == "0")
            {
                sgstamtnew = 0;
            }
            else
            {
                sgstamtnew = Convert.ToDecimal(sgstamount.ToString("#.##"));
            }

            decimal igstamount = Convert.ToDecimal(total2) * Convert.ToDecimal(igst) / 100;
            if (igst == "0")
            {
                igstamtnew = 0;
            }
            else
            {
                igstamtnew = Convert.ToDecimal(igstamount.ToString("#.##"));
            }

            DataTable dt = (DataTable)ViewState["Details"];
            dt.Rows.Add(str, str10, height2, width2, sqrft2, rate2, amount2, quantity2, total2, cgstamtnew, sgstamtnew, igstamtnew, final, cgst, sgst, igst, desc, str9);
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

        else if (str9 == "Ltr")
        {



            decimal cgstamount = Convert.ToDecimal(total2) * Convert.ToDecimal(cgst) / 100;
            if (cgst == "0")
            {
                cgstamtnew = 0;
            }
            else
            {
                cgstamtnew = Convert.ToDecimal(cgstamount.ToString("#.##"));
            }

            decimal sgstamount = Convert.ToDecimal(total2) * Convert.ToDecimal(sgst) / 100;
            if (sgst == "0")
            {
                sgstamtnew = 0;
            }
            else
            {
                sgstamtnew = Convert.ToDecimal(sgstamount.ToString("#.##"));
            }

            decimal igstamount = Convert.ToDecimal(total2) * Convert.ToDecimal(igst) / 100;
            if (igst == "0")
            {
                igstamtnew = 0;
            }
            else
            {
                igstamtnew = Convert.ToDecimal(igstamount.ToString("#.##"));
            }

            DataTable dt = (DataTable)ViewState["Details"];
            dt.Rows.Add(str, str10, height2, width2, sqrft2, rate2, amount2, quantity2, total2, cgstamtnew, sgstamtnew, igstamtnew, final, cgst, sgst, igst, desc, str9);
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
            if (cgst == "0")
            {
                cgstamtnew = 0;
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
            dt.Rows.Add(str, str10, height, width, sqrft, rate, amount, quantity, total, cgstamtnew, sgstamtnew, igstamtnew, final, cgst, sgst, igst, desc, str9);
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
        product();

        Txt_description.Text = "";


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
           // Label lblamount = (Label)e.Row.FindControl("lbl_subtotal");
            //Assign the total value to footer label control
            lbl_subtotal.Text = totalvalue.ToString();
            lbl_subtotal2.Value = totalvalue.ToString();
            if (Txt_shipping.Text != "" && Txt_adjustment.Text != "" && Txt_discount.Text != "")
            {
                shipping = Convert.ToDecimal(Txt_shipping.Text);
                adjustment = Convert.ToDecimal(Txt_adjustment.Text);
                discount = Convert.ToDecimal(Txt_discount.Text);
                decimal final = (totalvalue + shipping);
                decimal total1 = (totalvalue + shipping - discount - adjustment);
                lbl_total.Text = total1.ToString();
                hide_total.Text = final.ToString();
            }
            else
            {
                shipping = 0;
                discount = 0;
                adjustment = 0;
                decimal final = (totalvalue + shipping);
                decimal total1 = (totalvalue + shipping - discount - adjustment);
                lbl_total.Text = total1.ToString();
                hide_total.Text = final.ToString();
            }




            //lbl_total.Text = totalvalue.ToString();
            // hide_total.Text= totalvalue.ToString();

            //Assign the total value to footer label control
            lbl_gst.Text = totalgst.ToString();
            lbl_totalqty.Text = totalqty.ToString();
            lbl_total_cgst.Value = totalcgst.ToString();
            lbl_total_sgst.Value = totalsgst.ToString();
            lbl_total_igst.Value = totaligst.ToString();
            lbl_total_taxable.Value = totaltaxable.ToString();
        }

    }

    protected void Dd_enter_product_SelectedIndexChanged(object sender, EventArgs e)
    {
        string pro_name = Dd_enter_product.SelectedValue;
        string rate, cgst, igst, sgst, hsn, unit, desc;
        SqlCommand cmd = new SqlCommand("select * from tbl_purchase_product where p_id ='" + pro_name.ToString() + "'", conn);
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
            // cgst = Dd_enter_cgst.Text;

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
        }
    }


    private bool dataEntry()
    {
        bool isTrue = true;
        try
        {
            decimal new_balance;
            final_total = Math.Round(Convert.ToDecimal(hide_total.Text));
            new_balance = final_total - Convert.ToDecimal(Txt_adjustment.Text) - Convert.ToDecimal(Txt_discount.Text);

            if (GridView1.Rows.Count == 0)
            {
                System.Web.UI.ScriptManager.RegisterStartupScript(this, GetType(), "displayalertmessage", "alert('Please Add Products First !!!');", true);
            }
            else
            {
                SqlCommand cmd22 = new SqlCommand("Select * from tbl_purchase where pu_invoice_no=@pu_invoice_no", conn);
                cmd22.Parameters.AddWithValue("@pu_invoice_no", Convert.ToString(Txt_invoice.Text));
                SqlDataAdapter adapt22 = new SqlDataAdapter(cmd22);
                DataTable dt22 = new DataTable();
                adapt22.Fill(dt22);

                if (dt22.Rows.Count == 0)
                {
                    int rowscount = GridView1.Rows.Count;
                    for (int i = 0; i < rowscount; i++)
                    {

                        if (GridView1.Rows[i].Cells[2].Text == "&nbsp;")
                        {
                            SqlCommand cmd = new SqlCommand("insert into tbl_purchase_invoice values(@pc_invoice_no,@pc_date,@v_id,@pc_order_no,@pc_invoice_date,@pc_due_date,@pc_product_name,@pc_quantity,@pc_total_quantity,@pc_rate,@pc_discount,@pc_cgstp,@pc_cgsta,@pc_sgstp,@pc_sgsta,@pc_igstp,@pc_igsta,@pc_amount,@pc_sub_total,@pc_total_gst,@pc_shipping_charges,@pc_adjustment,@pc_total,@pc_stotal,@pc_hsn,@pc_unit,@pc_desc,@pc_height,@pc_width,@pc_size,@pc_samount,@pc_total_cgst,@pc_total_sgst,@pc_total_igst,@pc_total_taxable,@pc_balance)", conn);
                            cmd.Parameters.AddWithValue("@pc_invoice_no", Convert.ToString(Txt_invoice.Text));
                            cmd.Parameters.AddWithValue("@pc_date", Convert.ToDateTime(DateTime.Now.ToShortDateString()).ToString("MM/dd/yyyy"));
                            cmd.Parameters.AddWithValue("@v_id", Convert.ToString(Dd_customer.SelectedValue));
                            cmd.Parameters.AddWithValue("@pc_order_no", Convert.ToString(Txt_order_no.Text));
                            cmd.Parameters.AddWithValue("@pc_invoice_date", Convert.ToDateTime(Txt_invoice_date.Text).ToString("MM/dd/yyyy"));
                            cmd.Parameters.AddWithValue("@pc_due_date", Convert.ToDateTime(Txt_due_date.Text).ToString("MM/dd/yyyy"));
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
                            cmd.Parameters.AddWithValue("@pc_hsn", Convert.ToString(GridView1.Rows[i].Cells[1].Text));
                            cmd.Parameters.AddWithValue("@pc_desc", Convert.ToString(GridView1.Rows[i].Cells[16].Text));
                            cmd.Parameters.AddWithValue("@pc_height", "");
                            cmd.Parameters.AddWithValue("@pc_width", "");
                            cmd.Parameters.AddWithValue("@pc_size", "");
                            cmd.Parameters.AddWithValue("@pc_samount", "");
                            cmd.Parameters.AddWithValue("@pc_total_cgst", Convert.ToDecimal(lbl_total_cgst.Value));
                            cmd.Parameters.AddWithValue("@pc_total_sgst", Convert.ToDecimal(lbl_total_sgst.Value));
                            cmd.Parameters.AddWithValue("@pc_total_igst", Convert.ToDecimal(lbl_total_igst.Value));
                            cmd.Parameters.AddWithValue("@pc_total_taxable", Convert.ToDecimal(lbl_total_taxable.Value));
                            cmd.Parameters.AddWithValue("@pc_balance", Convert.ToDecimal(new_balance));
                            conn.Open();
                            cmd.ExecuteNonQuery();

                            conn.Close();


                            //stock start here
                            decimal Qty_total = Convert.ToDecimal(GridView1.Rows[i].Cells[7].Text);

                            SqlCommand cmd33 = new SqlCommand("UPDATE tbl_purchase_product SET p_stock=p_stock+('" + Qty_total + "') WHERE p_name='" + Convert.ToString(GridView1.Rows[i].Cells[0].Text) + "'", conn);

                            conn.Open();
                            cmd33.ExecuteNonQuery();
                            conn.Close();

                            //stock end here

                            product_name = Convert.ToString(GridView1.Rows[i].Cells[0].Text);
                        }
                        else
                        {
                            SqlCommand cmd = new SqlCommand("insert into tbl_purchase_invoice values(@pc_invoice_no,@pc_date,@v_id,@pc_order_no,@pc_invoice_date,@pc_due_date,@pc_product_name,@pc_quantity,@pc_total_quantity,@pc_rate,@pc_discount,@pc_cgstp,@pc_cgsta,@pc_sgstp,@pc_sgsta,@pc_igstp,@pc_igsta,@pc_amount,@pc_sub_total,@pc_total_gst,@pc_shipping_charges,@pc_adjustment,@pc_total,@pc_stotal,@pc_hsn,@pc_unit,@pc_desc,@pc_height,@pc_width,@pc_size,@pc_samount,@pc_total_cgst,@pc_total_sgst,@pc_total_igst,@pc_total_taxable,@pc_balance)", conn);
                            cmd.Parameters.AddWithValue("@pc_invoice_no", Convert.ToString(Txt_invoice.Text));
                            cmd.Parameters.AddWithValue("@pc_date", Convert.ToDateTime(DateTime.Now.ToShortDateString()).ToString("MM/dd/yyyy"));
                            cmd.Parameters.AddWithValue("@v_id", Convert.ToString(Dd_customer.SelectedValue));
                            cmd.Parameters.AddWithValue("@pc_order_no", Convert.ToString(Txt_order_no.Text));
                            cmd.Parameters.AddWithValue("@pc_invoice_date", Convert.ToDateTime(Txt_invoice_date.Text).ToString("MM/dd/yyyy"));
                            cmd.Parameters.AddWithValue("@pc_due_date", Convert.ToDateTime(Txt_due_date.Text).ToString("MM/dd/yyyy"));
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
                            cmd.Parameters.AddWithValue("@pc_hsn", Convert.ToString(GridView1.Rows[i].Cells[1].Text));
                            cmd.Parameters.AddWithValue("@pc_desc", Convert.ToString(GridView1.Rows[i].Cells[16].Text));
                            cmd.Parameters.AddWithValue("@pc_height", Convert.ToDecimal(GridView1.Rows[i].Cells[2].Text));
                            cmd.Parameters.AddWithValue("@pc_width", Convert.ToDecimal(GridView1.Rows[i].Cells[3].Text));
                            cmd.Parameters.AddWithValue("@pc_size", Convert.ToDecimal(GridView1.Rows[i].Cells[4].Text));
                            cmd.Parameters.AddWithValue("@pc_samount", Convert.ToDecimal(GridView1.Rows[i].Cells[6].Text));
                            cmd.Parameters.AddWithValue("@pc_total_cgst", Convert.ToDecimal(lbl_total_cgst.Value));
                            cmd.Parameters.AddWithValue("@pc_total_sgst", Convert.ToDecimal(lbl_total_sgst.Value));
                            cmd.Parameters.AddWithValue("@pc_total_igst", Convert.ToDecimal(lbl_total_igst.Value));
                            cmd.Parameters.AddWithValue("@pc_total_taxable", Convert.ToDecimal(lbl_total_taxable.Value));
                            cmd.Parameters.AddWithValue("@pc_balance", Convert.ToDecimal(new_balance));
                            conn.Open();
                            cmd.ExecuteNonQuery();

                            conn.Close();


                            //stock start here
                            decimal tsqft = Convert.ToDecimal(GridView1.Rows[i].Cells[7].Text);
                            SqlCommand cmd5 = new SqlCommand("UPDATE tbl_purchase_product SET p_stock=p_stock+('" + tsqft + "') WHERE p_name='" + Convert.ToString(GridView1.Rows[i].Cells[0].Text) + "'", conn);

                            conn.Open();
                            cmd5.ExecuteNonQuery();
                            conn.Close();

                            //stock end here

                            product_name = Convert.ToString(GridView1.Rows[i].Cells[0].Text);
                        }
                    }
                    SqlCommand cmd2 = new SqlCommand("insert into tbl_purchase values(@pu_invoice_no,@pu_date,@v_id,@pu_order_no,@pu_invoice_date,@pu_due_date,@pu_total_quantity,@pu_discount,@pu_sub_total,@pu_total_gst,@pu_shipping_charges,@pu_adjustment,@pu_total,@pu_total_cgst,@pu_total_sgst,@pu_total_igst,@pu_total_taxable,@pu_balance,@pu_product_name)", conn);
                    cmd2.Parameters.AddWithValue("@pu_invoice_no", Convert.ToString(Txt_invoice.Text));
                    cmd2.Parameters.AddWithValue("@pu_date", Convert.ToDateTime(DateTime.Now.ToShortDateString()).ToString("MM/dd/yyyy"));
                    cmd2.Parameters.AddWithValue("@v_id", Convert.ToString(Dd_customer.SelectedValue));
                    cmd2.Parameters.AddWithValue("@pu_order_no", Convert.ToString(Txt_order_no.Text));
                    cmd2.Parameters.AddWithValue("@pu_invoice_date", Convert.ToDateTime(Txt_invoice_date.Text).ToString("MM/dd/yyyy"));
                    cmd2.Parameters.AddWithValue("@pu_due_date", Convert.ToDateTime(Txt_due_date.Text).ToString("MM/dd/yyyy"));

                    cmd2.Parameters.AddWithValue("@pu_total_quantity", Convert.ToDecimal(lbl_totalqty.Text));

                    cmd2.Parameters.AddWithValue("@pu_discount", Convert.ToDecimal(Txt_discount.Text));


                    cmd2.Parameters.AddWithValue("@pu_sub_total", Convert.ToDecimal(lbl_subtotal.Text));
                    cmd2.Parameters.AddWithValue("@pu_total_gst", Convert.ToDecimal(lbl_gst.Text));
                    cmd2.Parameters.AddWithValue("@pu_shipping_charges", Convert.ToDecimal(Txt_shipping.Text));
                    cmd2.Parameters.AddWithValue("@pu_adjustment", Convert.ToDecimal(Txt_adjustment.Text));
                    cmd2.Parameters.AddWithValue("@pu_total", Convert.ToDecimal(hide_total.Text));
                    cmd2.Parameters.AddWithValue("@pu_total_cgst", Convert.ToDecimal(lbl_total_cgst.Value));
                    cmd2.Parameters.AddWithValue("@pu_total_sgst", Convert.ToDecimal(lbl_total_sgst.Value));
                    cmd2.Parameters.AddWithValue("@pu_total_igst", Convert.ToDecimal(lbl_total_igst.Value));
                    cmd2.Parameters.AddWithValue("@pu_total_taxable", Convert.ToDecimal(lbl_total_taxable.Value));
                    cmd2.Parameters.AddWithValue("@pu_balance", Convert.ToDecimal(new_balance));
                    cmd2.Parameters.AddWithValue("@pu_product_name", Convert.ToString(product_name));
                    conn.Open();
                    cmd2.ExecuteNonQuery();
                    conn.Close();


                    SqlCommand cmd3 = new SqlCommand("update tbl_vendor set v_opening_balance=v_opening_balance + '" + Convert.ToDecimal(new_balance) + "' where v_id='" + Dd_customer.SelectedValue + "'", conn);
                    conn.Open();
                    cmd3.ExecuteNonQuery();
                    conn.Close();

                    isTrue = true;
                    string redirectScript = " window.location.href = 'list_of_purchase.aspx?insert=success';";
                    System.Web.UI.ScriptManager.RegisterStartupScript(this, GetType(), "displayalertmessage", "alert('New Purchase Invoice Added Successfully!!!');" + redirectScript, true);
                }

                else
                {
                    string redirectScript = " window.location.href = 'list_of_purchase.aspx?insert=success';";
                    System.Web.UI.ScriptManager.RegisterStartupScript(this, GetType(), "displayalertmessage", "alert('New Purchase Invoice Added Successfully!!!');" + redirectScript, true);
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
        // Btn_generate_pdf.Enabled = false;

        if (GridView1.Rows.Count == 0)
        {
            System.Web.UI.ScriptManager.RegisterStartupScript(this, GetType(), "displayalertmessage", "alert('Please Add Products First !!!');", true);
        }
        else
        {
            bool isTrue = dataEntry();
            if (isTrue == true)
            {
                //Response.Redirect("list_of_purchase.aspx?insert=success");
                string redirectScript = " window.location.href = 'list_of_purchase.aspx?insert=success';";
                System.Web.UI.ScriptManager.RegisterStartupScript(this, GetType(), "displayalertmessage", "alert('New Purchase Invoice Added Successfully!!!');" + redirectScript, true);
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
        else
        {
            //Btn_submit_payment.Enabled = false;
            bool isTrue = dataEntry();
            if (isTrue == true)
            {
                string redirectScript = " window.location.href = 'bill.aspx?invoice=" + Txt_invoice.Text + "';";
                System.Web.UI.ScriptManager.RegisterStartupScript(this, GetType(), "displayalertmessage", "alert('New Purchase Invoice Added Successfully!!!');" + redirectScript, true);
            }
            else
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
            // lbl_total.Text = "0";
            // hide_total.Text = "0";
            // lbl_subtotal.Text = "0";
            // lbl_subtotal2.Value = "0";
            // lbl_gst.Text = "0";
            // Txt_shipping.Text = "0";
            // lbl_totalqty.Text = "0";
            // //Dd_enter_product.SelectedValue = "--Slect--";
            // product();
            //lbl_product_hsn.Value = "";
            // txt_height.Text = "0";
            // txt_width.Text = "0";
            // txt_sqrft.Text = "0";
            // txt_rate.Text = "0";
            // txt_rate2.Text = "0";
            // txt_amount.Text = "0";
            // txt_quantity.Text = "0";
            // txt_quantity2.Text = "0";
            // txt_total_amt.Text = "0";
            // txt_total_amt2.Text = "0";

            // txt_final_amt.Text = "0";
            // hide_total.Text="0";
            // Txt_description.Text = "";
            // lbl_unit.Value = "";
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
    protected void Button1_Click(object sender, EventArgs e)
    {
        lbl_msg.Text = "";
        try
        {
            SqlCommand cmd = new SqlCommand("insert into tbl_vendor values(@v_name,@v_address,@v_contact,@v_gst_no,@v_opening_balance,@v_email,@v_contact2)", conn);
            cmd.Parameters.AddWithValue("@v_name", Txt_vendor_name.Text);
            cmd.Parameters.AddWithValue("@v_address", Txt_address.Text);
            cmd.Parameters.AddWithValue("@v_contact", Txt_contact.Text);
            cmd.Parameters.AddWithValue("@v_contact2", Txt_contact2.Text);
            // cmd.Parameters.AddWithValue("@v_gst_no", string.IsNullOrEmpty(Txt_gst_no.Text) ? DBNull.Value : (object)Txt_gst_no.Text);
            if (string.IsNullOrEmpty(Txt_gst_no.Text))
            {

                Random random = new Random();
                int randomNumber = random.Next(1000, 9999);
                Txt_gst_no.Text = "N/A-" + randomNumber.ToString();
            }

            cmd.Parameters.AddWithValue("@v_gst_no", Txt_gst_no.Text.Trim());
            if (Txt_opening_balance.Text == "")
            {
                cmd.Parameters.AddWithValue("@v_opening_balance", 0);
            }
            else
            {
                cmd.Parameters.AddWithValue("@v_opening_balance", Txt_opening_balance.Text);
            }

            cmd.Parameters.AddWithValue("@v_email", Txt_email.Text);
            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();

            customer();
            lbl_msg.ForeColor = System.Drawing.Color.Green;
            lbl_msg.Text = "Vendor Added Successfully!!!";
        }
        catch (SqlException ex)
        {
            if (ex.Number == 2601)
            {
                // Check if the exception is related to a unique constraint violation
                if (ex.Message.Contains("IX_UniqueContact"))
                {
                    // Show an alert indicating that the contact number is a duplicate
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
                    // Handle other SQL errors as needed
                }
            }
            else
            {
                // Handle other SQL errors as needed
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
            Txt_vendor_name.Text = "";
            Txt_address.Text = "";
            Txt_gst_no.Text = "";
            Txt_contact2.Text = "";
            Txt_address.Text = "";
            Txt_contact.Text = "";
            Txt_opening_balance.Text = "";
            Txt_email.Text = "";

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
        SqlCommand cmd = new SqlCommand("Select * from tbl_purchase_product where p_name='" + Txt_product_name.Text.Trim() + "'", conn);
        //cmd2.Parameters.AddWithValue("@c_name", this.Txt_customer_name.Text);
        SqlDataAdapter adapt = new SqlDataAdapter(cmd);
        DataTable dt = new DataTable();
        adapt.Fill(dt);


        //var result = cmd2.ExecuteScalar();
        if (dt.Rows.Count > 0)
        {
            lbl_msg2.ForeColor = System.Drawing.Color.Red;
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




            //Dd_unit.SelectedItem.Value = "Sqft";
            //if (lbl_msg2.Text == "Product Added Successfully!!!")
            //{
            //    lbl_msg2.Text = "";

            //}

        }

    }


}