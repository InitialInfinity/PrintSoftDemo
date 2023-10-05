﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;


public partial class Sale_job_sheet : System.Web.UI.Page
{
    SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["String"].ConnectionString);
   
    decimal totalincome;
  
    public string invoice;
    protected void Page_Load(object sender, EventArgs e)
    {
        //hide_total.Visible = false;

        if (Session["a_email"] != null)
        {
            invoice = Request.QueryString["invoice"].ToString();
            if (!IsPostBack)
            {

                
                FillGRid();
                FillGRid2();
                this.customer();

                if (ViewState["Details"] == null)
                {

                }

            }
        }
        else
        {
            Response.Redirect("../login.aspx");
        }
    }
    protected void FillGRid()
    {
        try
        {


            SqlCommand cmd = new SqlCommand("select s_product_name as [Income Note],s_stotal as Amount from tbl_sale_invoice where s_invoice_no='" + invoice + "'", conn);
            SqlDataAdapter adapt = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapt.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                GridView2.DataSource = dt;
                GridView2.DataBind();
                lbl_income_total.Text = Convert.ToString(dt.Compute("Sum(Amount)", ""));
                

            }
            else
            {
                GridView2.DataSource = null;
                GridView2.DataBind();
                lbl_income_total.Text = "0";
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
    protected void FillGRid2()
    {
        try
        {


            SqlCommand cmd = new SqlCommand("select js_expense as [Expense Note],js_amount as Amount,js_id as [ID] from tbl_job_sheet where s_invoice_no='" + invoice + "'", conn);
            SqlDataAdapter adapt = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapt.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                GridView1.DataSource = dt;
                GridView1.DataBind();
                lbl_expense_total.Text = Convert.ToString(dt.Compute("Sum(Amount)", ""));
                Button4.Visible = true;
            }
            else
            {
                GridView1.DataSource = null;
                GridView1.DataBind();
                lbl_expense_total.Text = "0";
                Button4.Visible = false;
            }
            cal();
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

    protected void cal()
    {
        decimal a = Convert.ToDecimal(lbl_income_total.Text);
        decimal b = Convert.ToDecimal(lbl_expense_total.Text);
        decimal c = a - b;
        if(c >= 0 )
        {
           lbl_profit.Text = c.ToString();
           lbl_profit.ForeColor = System.Drawing.Color.Green;
        }
        else
        {
            lbl_profit.Text = c.ToString();
            lbl_profit.ForeColor = System.Drawing.Color.Red;
        }
    }


    public void customer()
    {
        string query = "select * from tbl_sale_invoice inner join tbl_customer on tbl_sale_invoice.c_id=tbl_customer.c_id where s_invoice_no='" + invoice + "'";
        SqlDataAdapter adapt = new SqlDataAdapter(query, conn);
        DataTable dt = new DataTable();
        adapt.Fill(dt);
        if (dt.Rows.Count > 0)
        {
            lbl_invoice.Text = invoice;
            lbl_owner.Text = dt.Rows[0]["c_name"].ToString();
            lbl_contact.Text = dt.Rows[0]["c_contact"].ToString();
            lbl_date.Text = Convert.ToDateTime(dt.Rows[0]["s_invoice_date"]).ToString("dd/MM/yyyy");
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
        

    }

    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {
        

    }
    protected void Btn_cart_Click(object sender, EventArgs e)
    {
        string str = txt_expenses.Text;

        string str2 = txt_amount.Text;
      
       
            try
            {
                SqlCommand cmd = new SqlCommand("insert into tbl_job_sheet values(@s_invoice_no,@js_expense,@js_amount)", conn);

                cmd.Parameters.AddWithValue("@s_invoice_no", invoice);
                cmd.Parameters.AddWithValue("@js_expense", str);
                cmd.Parameters.AddWithValue("@js_amount", str2);
               
                
                conn.Open();
                cmd.ExecuteNonQuery();

                conn.Close();
                FillGRid2();

            }
            catch (Exception ex)
            {

            }
      

    }
    
    protected void Button2_Click(object sender, EventArgs e)
    {
        try
        {
            int i = Convert.ToInt32(GridView1.SelectedRow.Cells[2].Text);

            SqlCommand cmd = new SqlCommand("Delete from tbl_job_sheet where js_id='" + i + "'", conn);
            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
            FillGRid2();
        }
        catch(Exception ex)
        {

        }

    }


}