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
using System.IO;

public partial class Sale_estimate : System.Web.UI.Page
{
    SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["String"].ConnectionString);
    decimal total_amount = 0, final_total = 0;
    decimal totalvalue = 0, totalcgst = 0, totalsgst = 0, totaligst = 0, totalgst = 0, totalqty, finaltotal, design, advanced, discount, pasting, fitting, transport,framing,installation;
    string key, country, senderid, route, email, password, port, subject, smtp, com_email;
    int sms, mail2;
    protected void Page_Load(object sender, EventArgs e)
    {  //hide_total.Visible = false;
        Dd_customer.Focus();
        Btn_generate_pdf.Attributes.Add("onclick", " this.disabled = true; " + ClientScript.GetPostBackEventReference(Btn_generate_pdf, null) + ";");

        //Btn_submit_payment.Attributes.Add("onclick", "this.style.display='none';");

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

                    dataTable.Columns.Add("desc");
                    dataTable.Columns.Add("unit");
                    dataTable.Columns.Add("material");

                    ViewState["Details"] = dataTable;
                }
                Txt_Pasting.Text = "0";
                Txt_TransportCharges.Text = "0";
                Txt_Dtp_charges.Text = "0";
                Txt_Fitting.Text = "0";
                Txt_Framing.Text = "0";
                Txt_install.Text = "0";
                Txt_discount.Text = "0";
                Txt_advance.Text = "0";
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


    public void Order_reference()
    {
        string query = "select * from tbl_staff order by st_id desc";
        SqlDataAdapter adapt = new SqlDataAdapter(query, conn);
        DataTable dt = new DataTable();
        adapt.Fill(dt);
      

        if (dt.Rows.Count > 0)
        {

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
    public void order()
    {
        SqlCommand cmd = new SqlCommand("select count(est_invoice_no) from tbl_estimate where est_invoice_date='" + DateTime.Now.ToShortDateString()  + "'", conn);
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

            SqlCommand cmd = new SqlCommand("SELECT TOP 1 est_invoice_no FROM tbl_estimate ORDER BY est_id DESC", conn);
            string inv;
            int i = 0;
            SqlDataAdapter adapt = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            adapt.Fill(dt);



            if (dt.Rows.Count > 0)
            {
                inv = dt.Rows[0]["est_invoice_no"].ToString();

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
                Txt_invoice.Text = "Bill-" + j.ToString();

            }

            else
            {
                Txt_invoice.Text = "Bill-1";
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

        string material = Dd_material.SelectedValue;



		//for (int i = 0; i <= GridView1.Rows.Count; i++)
		//{
		//	total_amount += Convert.ToDecimal(txt_final_amt.Text);

		//}
		//final_total = total_amount;



		if (str9 == "Pcs")
        {
            DataTable dt = (DataTable)ViewState["Details"];
            dt.Rows.Add(str, str10, height2, width2, sqrft2, rate2, amount2, quantity2, total2, desc, str9, material);
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
            DataTable dt = (DataTable)ViewState["Details"];
            dt.Rows.Add(str, str10, height2, width2, sqrft2, rate2, amount2, quantity2, total2, desc, str9, material);
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
            GridView1.EmptyDataText = "Material";


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
            dt.Rows.Add(str, str10, height2, width2, sqrft2, rate2, amount2, quantity2, total2, desc, str9, material);
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
            DataTable dt = (DataTable)ViewState["Details"];
            dt.Rows.Add(str, str10, height2, width2, sqrft2, rate2, amount2, quantity2, total2, desc, str9, material);
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
            DataTable dt = (DataTable)ViewState["Details"];
            dt.Rows.Add(str, str10, height, width, sqrft, rate, amount, quantity, total, desc, str9, material);
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
		product();
		material1();
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

		
		lbl_available.Text = "";
		GridView1.Visible = true;
	}

	protected void clear()
	{
		//Dd_enter_product.SelectedIndex = 0;
		//Dd_material.SelectedIndex = 0;
		Txt_description.Text = "";
		txt_width.Text = "";
		txt_height.Text = "";
		txt_sqrft.Text = "";

		txt_amount.Text = "";
		txt_width.Text = "";
		txt_quantity.Text = "";
		txt_total_amt.Text = "";
		txt_height2.Text = "";
		txt_width2.Text = "";
		txt_sqrft2.Text = "";

		txt_amount2.Text = "";
		txt_quantity2.Text = "";
		txt_total_amt2.Text = "";
		
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
            e.Row.Cells[11].Visible = false;

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

            if (Txt_advance.Text != "" && Txt_Pasting.Text != "" && Txt_Fitting.Text != "" && Txt_TransportCharges.Text != "" && Txt_Dtp_charges.Text != "" && Txt_Framing.Text != "" && Txt_install.Text != "")
            {

                pasting = Convert.ToDecimal(Txt_Pasting.Text);
                transport = Convert.ToDecimal(Txt_TransportCharges.Text);
                design = Convert.ToDecimal(Txt_Dtp_charges.Text);
                fitting = Convert.ToDecimal(Txt_Fitting.Text);
                framing = Convert.ToDecimal(Txt_Framing.Text);
                installation = Convert.ToDecimal(Txt_install.Text);

                discount = Convert.ToDecimal(Txt_discount.Text);
                advanced = Convert.ToDecimal(Txt_advance.Text);
                
                decimal total1 = (totalvalue + pasting + transport + design + fitting+framing+installation - discount - advanced);
                decimal final = (totalvalue + pasting + transport + design + fitting + framing + installation);
                lbl_final.Text = final.ToString();
                lbl_total.Text = total1.ToString();
                hide_total.Text = final.ToString();
            }
            else
            {
                fitting = 0;
                discount = 0;
                advanced = 0;
                pasting = 0;
                transport = 0;
                design = 0;
                framing = 0;
                installation = 0;
                decimal total1 = (totalvalue + pasting + transport + design + fitting + framing + installation - discount - advanced);
                decimal final = (totalvalue + pasting + transport + design + fitting + framing + installation);
                lbl_final.Text = final.ToString();
                lbl_total.Text = total1.ToString();
                hide_total.Text = final.ToString();
            }





            //Assign the total value to footer label control
            //lbl_total.Text = totalvalue.ToString();
            //lbl_final.Text = totalvalue.ToString();
            //hide_total.Text = totalvalue.ToString();
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
            //Dd_enter_cgst.Text = cgst;
            //Dd_enter_igst.Text = igst;
            //Dd_enter_sgst.Text = sgst;

            txt_rate.Text = rate;
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

	public void material1()
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
        System.Threading.Thread.Sleep(50);
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
                SqlCommand cmd22 = new SqlCommand("Select * from tbl_estimate where est_invoice_no=@est_invoice_no", conn);
                cmd22.Parameters.AddWithValue("@est_invoice_no", Convert.ToString(Txt_invoice.Text));
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
                            SqlCommand cmd = new SqlCommand("insert into tbl_estimate_details values(@es_invoice_no,@es_date,@c_id,@es_order_no,@es_invoice_date,@es_due_date,@es_product_name,@es_quantity,@es_total_quantity,@es_rate,@es_discount,@es_sub_total,@es_shipping_charges,@es_adjustment,@es_total,@es_hsn,@es_unit,@es_stotal,@es_desc,@es_height,@es_width,@es_size,@es_samount,@es_balance,@es_dtp_charges,@es_fitting_charges,@es_payment_method,@es_order_ref,@es_material,@es_pasting_charges,@es_framing_charges,@es_installation_charges)", conn);
                            cmd.Parameters.AddWithValue("@es_invoice_no", Convert.ToString(Txt_invoice.Text));
                            cmd.Parameters.AddWithValue("@es_date", Convert.ToDateTime(DateTime.Now.ToShortDateString()).ToString("MM/dd/yyyy"));
                            cmd.Parameters.AddWithValue("@c_id", Convert.ToString(Dd_customer.SelectedValue));
                            cmd.Parameters.AddWithValue("@es_order_no", Convert.ToString(Txt_order_no.Text));
                            cmd.Parameters.AddWithValue("@es_invoice_date", Convert.ToDateTime(Txt_invoice_date.Text).ToString("MM/dd/yyyy"));
                            cmd.Parameters.AddWithValue("@es_due_date", Convert.ToDateTime(Txt_due_date.Text).ToString("MM/dd/yyyy"));
                            cmd.Parameters.AddWithValue("@es_product_name", Convert.ToString(GridView1.Rows[i].Cells[0].Text));
                            cmd.Parameters.AddWithValue("@es_quantity", Convert.ToDecimal(GridView1.Rows[i].Cells[7].Text));
                            cmd.Parameters.AddWithValue("@es_unit", Convert.ToString(GridView1.Rows[i].Cells[10].Text));
                            cmd.Parameters.AddWithValue("@es_total_quantity", Convert.ToDecimal(lbl_totalqty.Text));
                            cmd.Parameters.AddWithValue("@es_rate", Convert.ToDecimal(GridView1.Rows[i].Cells[5].Text));
                            cmd.Parameters.AddWithValue("@es_discount", Convert.ToDecimal(Txt_discount.Text));


                            cmd.Parameters.AddWithValue("@es_sub_total", Convert.ToDecimal(lbl_subtotal.Text));


                            if (Txt_TransportCharges.Text == "")
                            {
                                cmd.Parameters.AddWithValue("@es_shipping_charges", "0");
                            }
                            else
                            {
                                cmd.Parameters.AddWithValue("@es_shipping_charges", Txt_TransportCharges.Text);
                            }


                            cmd.Parameters.AddWithValue("@es_adjustment", Convert.ToDecimal(Txt_advance.Text));
                            cmd.Parameters.AddWithValue("@es_total", Convert.ToDecimal(hide_total.Text));
                            cmd.Parameters.AddWithValue("@es_stotal", Convert.ToDecimal(GridView1.Rows[i].Cells[8].Text));
                            cmd.Parameters.AddWithValue("@es_hsn", Convert.ToString(GridView1.Rows[i].Cells[1].Text));
                            cmd.Parameters.AddWithValue("@es_desc", Convert.ToString(GridView1.Rows[i].Cells[9].Text));
                            cmd.Parameters.AddWithValue("@es_height", "");
                            cmd.Parameters.AddWithValue("@es_width", "");
                            cmd.Parameters.AddWithValue("@es_size", "");
                            cmd.Parameters.AddWithValue("@es_samount", "");
                            cmd.Parameters.AddWithValue("@es_balance", Convert.ToDecimal(new_balance));

                            if (Txt_Dtp_charges.Text == "")
                            {
                                cmd.Parameters.AddWithValue("@es_dtp_charges", "0");
                            }
                            else
                            {
                                cmd.Parameters.AddWithValue("@es_dtp_charges", Convert.ToDecimal(Txt_Dtp_charges.Text));
                            }

                            if (Txt_Fitting.Text == "")
                            {
                                cmd.Parameters.AddWithValue("@es_fitting_charges", "0");
                            }
                            else
                            {
                                cmd.Parameters.AddWithValue("@es_fitting_charges", Convert.ToDecimal(Txt_Fitting.Text));
                            }

                            cmd.Parameters.AddWithValue("@es_payment_method", Convert.ToString(drp_payment.SelectedItem.Text));
                            cmd.Parameters.AddWithValue("@es_order_ref", Convert.ToString(drp_designer.SelectedItem.Text));

                            if (GridView1.Rows[i].Cells[11].Text == "--Select--" || GridView1.Rows[i].Cells[11].Text == "")
                            {
                                cmd.Parameters.AddWithValue("@es_material", "0");
                            }
                            else
                            {
                                cmd.Parameters.AddWithValue("@es_material", Convert.ToDecimal(GridView1.Rows[i].Cells[11].Text));
                            }


                            if (Txt_Pasting.Text == "")
                            {
                                cmd.Parameters.AddWithValue("@es_pasting_charges", "0");
                            }
                            else
                            {
                                cmd.Parameters.AddWithValue("@es_pasting_charges", Convert.ToDecimal(Txt_Pasting.Text));
                            }

                            if (Txt_Framing.Text == "")
                            {
                                cmd.Parameters.AddWithValue("@es_framing_charges", "0");
                            }
                            else
                            {
                                cmd.Parameters.AddWithValue("@es_framing_charges", Convert.ToDecimal(Txt_Framing.Text));
                            }

                            if (Txt_install.Text == "")
                            {
                                cmd.Parameters.AddWithValue("@es_installation_charges", "0");
                            }
                            else
                            {
                                cmd.Parameters.AddWithValue("@es_installation_charges", Convert.ToDecimal(Txt_install.Text));
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

                            SqlCommand cmd33 = new SqlCommand("UPDATE tbl_purchase_product SET p_stock=p_stock-('" + Qty_total + "') WHERE p_id='" + Convert.ToString(GridView1.Rows[i].Cells[11].Text) + "'", conn);

                            conn.Open();
                            cmd33.ExecuteNonQuery();
                            conn.Close();



                            SqlCommand cmd66 = new SqlCommand("insert into tbl_used_stock values(@p_name,@date,@sqrft,@quantity)", conn);
                            cmd66.Parameters.AddWithValue("@p_name", Convert.ToString(GridView1.Rows[i].Cells[0].Text));
                            cmd66.Parameters.AddWithValue("@date", Convert.ToDateTime(Txt_invoice_date.Text).ToString("MM/dd/yyyy"));
                            cmd66.Parameters.AddWithValue("@sqrft", Qty_total);
                            cmd66.Parameters.AddWithValue("@quantity", Convert.ToDecimal(GridView1.Rows[i].Cells[7].Text));

                            //used stock material

                            //SqlCommand cmd66 = new SqlCommand("insert into tbl_used_stock values(@p_name,@date,@sqrft,@quantity)", conn);
                            //cmd66.Parameters.AddWithValue("@p_name", Convert.ToString(GridView1.Rows[i].Cells[0].Text));
                            //cmd66.Parameters.AddWithValue("@date", Convert.ToDateTime(Txt_invoice_date.Text).ToString("MM/dd/yyyy"));
                            //cmd66.Parameters.AddWithValue("@sqrft", Sqrft_total);
                            //cmd66.Parameters.AddWithValue("@quantity", Convert.ToDecimal(GridView1.Rows[i].Cells[7].Text));

                            //conn.Open();
                            //cmd66.ExecuteNonQuery();
                            //conn.Close();

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

                            SqlCommand cmd = new SqlCommand("insert into tbl_estimate_details values(@es_invoice_no,@es_date,@c_id,@es_order_no,@es_invoice_date,@es_due_date,@es_product_name," +
                                "@es_quantity,@es_total_quantity,@es_rate,@es_discount,@es_sub_total,@es_shipping_charges,@es_adjustment,@es_total,@es_hsn,@es_unit,@es_stotal," +
                                "@es_desc,@es_height,@es_width,@es_size,@es_samount,@es_balance,@es_dtp_charges,@es_fitting_charges,@es_payment_method,@es_order_ref,@es_material," +
                                "@es_pasting_charges,@es_framing_charges,@es_installation_charges)", conn);
                            cmd.Parameters.AddWithValue("@es_invoice_no", Convert.ToString(Txt_invoice.Text));
                            cmd.Parameters.AddWithValue("@es_date", Convert.ToDateTime(DateTime.Now.ToShortDateString()).ToString("MM/dd/yyyy"));
                            cmd.Parameters.AddWithValue("@c_id", Convert.ToString(Dd_customer.SelectedValue));
                            cmd.Parameters.AddWithValue("@es_order_no", Convert.ToString(Txt_order_no.Text));
                            cmd.Parameters.AddWithValue("@es_invoice_date", Convert.ToDateTime(Txt_invoice_date.Text).ToString("MM/dd/yyyy"));
                            cmd.Parameters.AddWithValue("@es_due_date", Convert.ToDateTime(Txt_due_date.Text).ToString("MM/dd/yyyy"));
                            cmd.Parameters.AddWithValue("@es_product_name", Convert.ToString(GridView1.Rows[i].Cells[0].Text));
                            cmd.Parameters.AddWithValue("@es_quantity", Convert.ToDecimal(GridView1.Rows[i].Cells[7].Text));
                            cmd.Parameters.AddWithValue("@es_unit", Convert.ToString(GridView1.Rows[i].Cells[10].Text));
                            cmd.Parameters.AddWithValue("@es_total_quantity", Convert.ToDecimal(lbl_totalqty.Text));
                            cmd.Parameters.AddWithValue("@es_rate", Convert.ToDecimal(GridView1.Rows[i].Cells[5].Text));
                            cmd.Parameters.AddWithValue("@es_discount", Convert.ToDecimal(Txt_discount.Text));


                            cmd.Parameters.AddWithValue("@es_sub_total", Convert.ToDecimal(lbl_subtotal.Text));

                            if (Txt_TransportCharges.Text == "")
                            {
                                cmd.Parameters.AddWithValue("@es_shipping_charges", "0");
                            }
                            else
                            {
                                cmd.Parameters.AddWithValue("@es_shipping_charges", Txt_TransportCharges.Text);
                            }

                            cmd.Parameters.AddWithValue("@es_adjustment", Convert.ToDecimal(Txt_advance.Text));
                            cmd.Parameters.AddWithValue("@es_total", Convert.ToDecimal(hide_total.Text));
                            cmd.Parameters.AddWithValue("@es_stotal", Convert.ToDecimal(GridView1.Rows[i].Cells[8].Text));
                            cmd.Parameters.AddWithValue("@es_hsn", Convert.ToString(GridView1.Rows[i].Cells[1].Text));
                            cmd.Parameters.AddWithValue("@es_desc", Convert.ToString(GridView1.Rows[i].Cells[9].Text));
                            cmd.Parameters.AddWithValue("@es_height", Convert.ToDecimal(GridView1.Rows[i].Cells[2].Text));
                            cmd.Parameters.AddWithValue("@es_width", Convert.ToDecimal(GridView1.Rows[i].Cells[3].Text));
                            cmd.Parameters.AddWithValue("@es_size", Convert.ToDecimal(GridView1.Rows[i].Cells[4].Text));


                            if (GridView1.Rows[i].Cells[6].Text == "&nbsp;")
                            {
                                cmd.Parameters.AddWithValue("@es_samount", "0");
                            }
                            else
                            {
                                cmd.Parameters.AddWithValue("@es_samount", Convert.ToDecimal(GridView1.Rows[i].Cells[6].Text));
                            }


                           
                            cmd.Parameters.AddWithValue("@es_balance", Convert.ToDecimal(new_balance));

                            if (Txt_Dtp_charges.Text == "")
                            {
                                cmd.Parameters.AddWithValue("@es_dtp_charges", "0");
                            }
                            else
                            {
                                cmd.Parameters.AddWithValue("@es_dtp_charges", Convert.ToDecimal(Txt_Dtp_charges.Text));
                            }

                            if (Txt_Fitting.Text == "")
                            {
                                cmd.Parameters.AddWithValue("@es_fitting_charges", "0");
                            }
                            else
                            {
                                cmd.Parameters.AddWithValue("@es_fitting_charges", Convert.ToDecimal(Txt_Fitting.Text));
                            }

                            cmd.Parameters.AddWithValue("@es_payment_method", Convert.ToString(drp_payment.SelectedItem.Text));
                            cmd.Parameters.AddWithValue("@es_order_ref", Convert.ToString(drp_designer.SelectedItem.Text));


                            if (GridView1.Rows[i].Cells[11].Text == "--Select--" || GridView1.Rows[i].Cells[11].Text == "")
                            {
                                cmd.Parameters.AddWithValue("@es_material", "0");
                            }
                            else
                            {
                                cmd.Parameters.AddWithValue("@es_material", Convert.ToDecimal(GridView1.Rows[i].Cells[11].Text));
                            }

                            if (Txt_Pasting.Text == "")
                            {
                                cmd.Parameters.AddWithValue("@es_pasting_charges", "0");
                            }
                            else
                            {
                                cmd.Parameters.AddWithValue("@es_pasting_charges", Convert.ToDecimal(Txt_Pasting.Text));
                            }

                            if (Txt_Framing.Text == "")
                            {
                                cmd.Parameters.AddWithValue("@es_framing_charges", "0");
                            }
                            else
                            {
                                cmd.Parameters.AddWithValue("@es_framing_charges", Convert.ToDecimal(Txt_Framing.Text));
                            }

                            if (Txt_install.Text == "")
                            {
                                cmd.Parameters.AddWithValue("@es_installation_charges", "0");
                            }
                            else
                            {
                                cmd.Parameters.AddWithValue("@es_installation_charges", Convert.ToDecimal(Txt_install.Text));
                            }

                            conn.Open();
                            cmd.ExecuteNonQuery();

                            conn.Close();

                            //material stock
                            string sqrft = Convert.ToString(GridView1.Rows[i].Cells[4].Text);

                            if ((sqrft) == string.Empty || sqrft == "&nbsp;")
                            {

                            }

                            if (GridView1.Rows[i].Cells[11].Text == "--Select--" || GridView1.Rows[i].Cells[11].Text == "")
                            {
                                GridView1.Rows[i].Cells[11].Text = "0";
                            }
                            else
                            {

                            }

                           

                            decimal Sqrft_total = Convert.ToDecimal(GridView1.Rows[i].Cells[4].Text) * Convert.ToDecimal(GridView1.Rows[i].Cells[7].Text);
                            decimal quantity1 = Convert.ToDecimal(GridView1.Rows[i].Cells[7].Text);

                            SqlCommand cmd33 = new SqlCommand("UPDATE tbl_purchase_product SET p_stock=p_stock-('" + quantity1 + "') WHERE p_id='" + Convert.ToString(GridView1.Rows[i].Cells[11].Text) + "'", conn);

                            conn.Open();
                            cmd33.ExecuteNonQuery();
                            conn.Close();

                            //used stock material

                            SqlCommand cmd66 = new SqlCommand("insert into tbl_used_stock values(@p_name,@date,@sqrft,@quantity)", conn);
                            cmd66.Parameters.AddWithValue("@p_name", Convert.ToString(GridView1.Rows[i].Cells[0].Text));
                            cmd66.Parameters.AddWithValue("@date", Convert.ToDateTime(Txt_invoice_date.Text).ToString("MM/dd/yyyy"));
                            cmd66.Parameters.AddWithValue("@sqrft", Sqrft_total);
                            cmd66.Parameters.AddWithValue("@quantity", Convert.ToDecimal(GridView1.Rows[i].Cells[7].Text));

                            conn.Open();
                            cmd66.ExecuteNonQuery();
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
                    SqlCommand cmd2 = new SqlCommand("insert into tbl_estimate values(@est_invoice_no,@est_date,@c_id,@est_order_no,@est_invoice_date,@est_due_date,@est_total_quantity,@est_discount,@est_sub_total,@est_shipping_charges,@est_adjustment,@est_total,@est_balance,@est_dtp_charges,@est_fitting_charges,@est_payment_method,@est_order_ref,@est_pasting_charges,@est_framing_charges,@est_installation_charges)", conn);
                    cmd2.Parameters.AddWithValue("@est_invoice_no", Convert.ToString(Txt_invoice.Text));
                    cmd2.Parameters.AddWithValue("@est_date", Convert.ToDateTime(DateTime.Now.ToShortDateString()).ToString("MM/dd/yyyy"));
                    cmd2.Parameters.AddWithValue("@c_id", Convert.ToString(Dd_customer.SelectedValue));
                    cmd2.Parameters.AddWithValue("@est_order_no", Convert.ToString(Txt_order_no.Text));
                    cmd2.Parameters.AddWithValue("@est_invoice_date", Convert.ToDateTime(Txt_invoice_date.Text).ToString("MM/dd/yyyy"));
                    cmd2.Parameters.AddWithValue("@est_due_date", Convert.ToDateTime(Txt_due_date.Text).ToString("MM/dd/yyyy"));

                    cmd2.Parameters.AddWithValue("@est_total_quantity", Convert.ToDecimal(lbl_totalqty.Text));

                    cmd2.Parameters.AddWithValue("@est_discount", Convert.ToDecimal(Txt_discount.Text));


                    cmd2.Parameters.AddWithValue("@est_sub_total", Convert.ToDecimal(lbl_subtotal.Text));

                    if (Txt_TransportCharges.Text == "")
                    {
                        cmd2.Parameters.AddWithValue("@est_shipping_charges", "0");
                    }
                    else
                    {
                        cmd2.Parameters.AddWithValue("@est_shipping_charges", Convert.ToString(Txt_TransportCharges.Text));
                    }


                    cmd2.Parameters.AddWithValue("@est_adjustment", Convert.ToDecimal(Txt_advance.Text));
                    cmd2.Parameters.AddWithValue("@est_total", Convert.ToDecimal(hide_total.Text));
                    cmd2.Parameters.AddWithValue("@est_balance", Convert.ToDecimal(new_balance));

                    if (Txt_Dtp_charges.Text == "")
                    {
                        cmd2.Parameters.AddWithValue("@est_dtp_charges", "0");
                    }
                    else
                    {
                        cmd2.Parameters.AddWithValue("@est_dtp_charges", Convert.ToDecimal(Txt_Dtp_charges.Text));
                    }

                    if (Txt_Fitting.Text == "")
                    {
                        cmd2.Parameters.AddWithValue("@est_fitting_charges", "0");
                    }
                    else
                    {
                        cmd2.Parameters.AddWithValue("@est_fitting_charges", Convert.ToDecimal(Txt_Fitting.Text));
                    }

                    cmd2.Parameters.AddWithValue("@est_payment_method", Convert.ToString(drp_payment.SelectedItem.Text));
                    cmd2.Parameters.AddWithValue("@est_order_ref", Convert.ToString(drp_designer.SelectedItem.Text));


                    if (Txt_Pasting.Text == "")
                    {
                        cmd2.Parameters.AddWithValue("@est_pasting_charges", "0");
                    }
                    else
                    {
                        cmd2.Parameters.AddWithValue("@est_pasting_charges", Convert.ToDecimal(Txt_Pasting.Text));
                    }

                    if (Txt_Framing.Text == "")
                    {
                        cmd2.Parameters.AddWithValue("@est_framing_charges", "0");
                    }
                    else
                    {
                        cmd2.Parameters.AddWithValue("@est_framing_charges", Convert.ToDecimal(Txt_Framing.Text));
                    }

                    if (Txt_install.Text == "")
                    {
                        cmd2.Parameters.AddWithValue("@est_installation_charges", "0");
                    }
                    else
                    {
                        cmd2.Parameters.AddWithValue("@est_installation_charges", Convert.ToDecimal(Txt_install.Text));
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
                    cmd4.Parameters.AddWithValue("@si_mode", Convert.ToString(drp_payment.SelectedItem.Text));
                    cmd4.Parameters.AddWithValue("@si_chno", "");
                    cmd4.Parameters.AddWithValue("@si_balance", Convert.ToDecimal(new_balance));
                    cmd4.Parameters.AddWithValue("@si_date", Convert.ToDateTime(DateTime.Now.ToShortDateString()).ToString("MM/dd/yyyy"));
                    //if (txt_UPIno.Text == "")
                    //{
                    //    cmd4.Parameters.AddWithValue("@si_upichqno", "");
                    //}
                    //else
                    //{
                    cmd4.Parameters.AddWithValue("@si_upichqno", "");
                    //}
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

                                decimal mob = Convert.ToDecimal(lbl_cutomer_contact.Value);
                                WebClient client = new WebClient();
                                string to;
                                Int64 temp_id = 1234567890123456788;
                                string msgRecepient = mob.ToString();
                                string msgText = "Welcome to " + com_email + ", Your invoice " + Txt_invoice.Text.ToString() + " has been created. Your Invoice Amount is " + finaltotal.ToString() + ".";

                                to = mob.ToString();
                                string baseURL = "http://sms.hitechsms.com/app/smsapi/index.php?" +

                                "key=" + key +
                                   "&campaign=" + "0" +
                                   "&routeid=" + route +
                                   "&type=" + "text" +
                                   "&contacts=" + msgRecepient +
                                   "&senderid=" + senderid +
                                   "&msg=" + System.Web.HttpUtility.UrlEncode(msgText, Encoding.GetEncoding("ISO-8859-1")) +
                                   "&template_id=" + temp_id;


                                // client.OpenRead(baseURL);

                                StringBuilder sbPostData = new StringBuilder();
                                sbPostData.AppendFormat("key={0}", key);
                                sbPostData.AppendFormat("&campaign={0}", "0");
                                sbPostData.AppendFormat("&routeid={0}", route);
                                sbPostData.AppendFormat("&type={0}", "text");
                                sbPostData.AppendFormat("&contacts={0}", msgRecepient);
                                sbPostData.AppendFormat("&senderid={0}", senderid);
                                sbPostData.AppendFormat("&msg={0}", System.Web.HttpUtility.UrlEncode(msgText, Encoding.GetEncoding("ISO-8859-1")));
                                sbPostData.AppendFormat("&template_id={0}", temp_id);


                                //Create HTTPWebrequest
                                HttpWebRequest httpWReq = (HttpWebRequest)WebRequest.Create(baseURL);
                                //Prepare and Add URL Encoded data
                                UTF8Encoding encoding = new UTF8Encoding();
                                byte[] data = encoding.GetBytes(sbPostData.ToString());
                                //Specify post method
                                httpWReq.Method = "POST";
                                httpWReq.ContentType = "application/x-www-form-urlencoded";
                                httpWReq.ContentLength = data.Length;
                                using (Stream stream = httpWReq.GetRequestStream())
                                {
                                    stream.Write(data, 0, data.Length);
                                }
                                //Get the response
                                HttpWebResponse response = (HttpWebResponse)httpWReq.GetResponse();
                                StreamReader reader = new StreamReader(response.GetResponseStream());
                                string responseString = reader.ReadToEnd();

                                //Close the response
                                reader.Close();
                                response.Close();
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
                                        mail.Subject = subject;
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
                    string redirectScript = " window.location.href = 'estimate_report.aspx?insert=success';";
                    System.Web.UI.ScriptManager.RegisterStartupScript(this, GetType(), "displayalertmessage", "alert('New Estimate Added Successfully!!!');" + redirectScript, true);
                }

                else
                {
                    string redirectScript = " window.location.href = 'estimate_report.aspx?insert=success';";
                    System.Web.UI.ScriptManager.RegisterStartupScript(this, GetType(), "displayalertmessage", "alert('New Estimate Added Successfully!!!');" + redirectScript, true);
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
        else
        {
            bool isTrue = dataEntry();
            if (isTrue == true)
            {
                //Response.Redirect("estimate_report.aspx?insert=success");
                string redirectScript = " window.location.href = 'estimate_report.aspx?insert=success';";
                System.Web.UI.ScriptManager.RegisterStartupScript(this, GetType(), "displayalertmessage", "alert('New Estimate Added Successfully!!!');" + redirectScript, true);
            }
            else
            {
				Btn_generate_pdf.Enabled = true;
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
            bool isTrue = dataEntry();
            if (isTrue == true)
            {
                string redirectScript = " window.location.href = 'wgst_bill.aspx?invoice=" + Txt_invoice.Text + "'";
                System.Web.UI.ScriptManager.RegisterStartupScript(this, GetType(), "displayalertmessage", "alert('New Estimate Added Successfully!!!');" + redirectScript, true);

            }
            else
            {

            }
        }

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
            lbl_total_remaining.Text = dt.Rows[0]["c_opening_balance"].ToString();
            order();
            this.Order_reference();

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


        }
        else
        {
            GridView1.DataSource = null;
            GridView1.DataBind();
            lbl_total.Text = "0";
            hide_total.Text = "0";
            lbl_subtotal.Text = "0";
            lbl_subtotal2.Value = "0";

            lbl_totalqty.Text = "0";
            //Dd_enter_product.SelectedValue = "--Slect--";
            product();
            material();
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


            lbl_total.Text = "0";

            lbl_final.Text = "0";
            hide_total.Text = "0";








        }

		}


		protected void Button1_Click(object sender, EventArgs e)
    {
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

    protected void drp_order_ref_SelectedIndexChanged(object sender, EventArgs e)
    {
       // order_ref_total();
    }
}