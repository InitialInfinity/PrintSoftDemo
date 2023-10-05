using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using System.IO;

public partial class GST_gstr_1 : System.Web.UI.Page
{
    SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["String"].ConnectionString);
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["a_email"] != null)
        {
            b2b();
            b2c();
            b2b2();
            b2c2();
            b2b3();
            b2c3();
            b2b4();
            b2c4();
            b2b5();
            b2c5();
            b2b6();
            b2c6();
            b2b7();
            b2c7();
            b2b8();
            b2c8();
            b2b9();
            b2c9();
            b2b10();
            b2c10();
            b2b11();
            b2c11();
            b2b12();
            b2c12();
          
        }
        else
        {
            Response.Redirect("../login.aspx");
        }
    }

    protected void b2b()
    {
        SqlCommand cmd1 = new SqlCommand("select sl_invoice_no as [Invoice ID],sl_invoice_date as [Invoice Date],c_name as [Customer Name],c_gst_no as [GST No],sl_total_taxable as [Taxable Value],sl_total_cgst as [CGST],sl_total_sgst as [SGST],sl_total_igst as [IGST],sl_total as [Total Amount] from tbl_sale inner join tbl_customer on tbl_sale.c_id=tbl_customer.c_id where c_gst_no != '" + string.Empty+ "' AND sl_invoice_date between '"+DateTime.Now.Year.ToString()+"-01-01' and '"+DateTime.Now.Year.ToString()+"-01-31' order by sl_id desc ", conn);
        SqlDataAdapter adapt1 = new SqlDataAdapter(cmd1);
        DataTable dt1 = new DataTable();
        adapt1.Fill(dt1);
        if (dt1.Rows.Count > 0)
        {
            Grid_b2b.DataSource = dt1;
            Grid_b2b.DataBind();
        }
      
    }
    protected void b2c()
    {
        SqlCommand cmd2 = new SqlCommand("select sl_invoice_no as [Invoice ID],sl_invoice_date as [Invoice Date],c_name as [Customer Name],sl_total_taxable as [Taxable Value],sl_total_cgst as [CGST],sl_total_sgst as [SGST],sl_total_igst as [IGST],sl_total as [Total Amount] from tbl_sale inner join tbl_customer on tbl_sale.c_id=tbl_customer.c_id where c_gst_no = '" + string.Empty + "' AND sl_invoice_date between '"+DateTime.Now.Year.ToString()+"-01-01' and '"+DateTime.Now.Year.ToString()+"-01-31' order by sl_id desc ", conn);
        SqlDataAdapter adapt2 = new SqlDataAdapter(cmd2);
        DataTable dt2 = new DataTable();
        adapt2.Fill(dt2);
        if (dt2.Rows.Count > 0)
        {
            Grid_b2c.DataSource = dt2;
            Grid_b2c.DataBind();
        }

    }
    protected void b2b2()
    {
        SqlCommand cmd3 = new SqlCommand("select sl_invoice_no as [Invoice ID],sl_invoice_date as [Invoice Date],c_name as [Customer Name],c_gst_no as [GST No],sl_total_taxable as [Taxable Value],sl_total_cgst as [CGST],sl_total_sgst as [SGST],sl_total_igst as [IGST],sl_total as [Total Amount] from tbl_sale inner join tbl_customer on tbl_sale.c_id=tbl_customer.c_id where c_gst_no != '" + string.Empty + "' AND sl_invoice_date between '" + DateTime.Now.Year.ToString()+"-02-01' and '"+DateTime.Now.Year.ToString()+"-02-28' order by sl_id desc ", conn);
        SqlDataAdapter adapt3 = new SqlDataAdapter(cmd3);
        DataTable dt3 = new DataTable();
        adapt3.Fill(dt3);
        if (dt3.Rows.Count > 0)
        {
            Grid_b2b2.DataSource = dt3;
            Grid_b2b2.DataBind();
        }

    }
    protected void b2c2()
    {
        SqlCommand cmd4 = new SqlCommand("select sl_invoice_no as [Invoice ID],sl_invoice_date as [Invoice Date],c_name as [Customer Name],sl_total_taxable as [Taxable Value],sl_total_cgst as [CGST],sl_total_sgst as [SGST],sl_total_igst as [IGST],sl_total as [Total Amount] from tbl_sale inner join tbl_customer on tbl_sale.c_id=tbl_customer.c_id where c_gst_no = '" + string.Empty + "' AND sl_invoice_date between '" + DateTime.Now.Year.ToString()+"-02-01' and '"+DateTime.Now.Year.ToString()+"-02-28' order by sl_id desc ", conn);
        SqlDataAdapter adapt4 = new SqlDataAdapter(cmd4);
        DataTable dt4 = new DataTable();
        adapt4.Fill(dt4);
        if (dt4.Rows.Count > 0)
        {
            Grid_b2c2.DataSource = dt4;
            Grid_b2c2.DataBind();
        }

    }
    protected void b2b3()
    {
        SqlCommand cmd5 = new SqlCommand("select sl_invoice_no as [Invoice ID],sl_invoice_date as [Invoice Date],c_name as [Customer Name],c_gst_no as [GST No],sl_total_taxable as [Taxable Value],sl_total_cgst as [CGST],sl_total_sgst as [SGST],sl_total_igst as [IGST],sl_total as [Total Amount] from tbl_sale inner join tbl_customer on tbl_sale.c_id=tbl_customer.c_id where c_gst_no != '" + string.Empty + "' AND sl_invoice_date between '" + DateTime.Now.Year.ToString()+"-03-01' and '"+DateTime.Now.Year.ToString()+"-03-31' order by sl_id desc ", conn);
        SqlDataAdapter adapt5 = new SqlDataAdapter(cmd5);
        DataTable dt5 = new DataTable();
        adapt5.Fill(dt5);
        if (dt5.Rows.Count > 0)
        {
            Grid_b2b3.DataSource = dt5;
            Grid_b2b3.DataBind();
        }

    }
    protected void b2c3()
    {
        SqlCommand cmd6 = new SqlCommand("select sl_invoice_no as [Invoice ID],sl_invoice_date as [Invoice Date],c_name as [Customer Name],sl_total_taxable as [Taxable Value],sl_total_cgst as [CGST],sl_total_sgst as [SGST],sl_total_igst as [IGST],sl_total as [Total Amount] from tbl_sale inner join tbl_customer on tbl_sale.c_id=tbl_customer.c_id where c_gst_no = '" + string.Empty + "' AND sl_invoice_date between '" + DateTime.Now.Year.ToString()+"-03-01' and '"+DateTime.Now.Year.ToString()+"-03-31' order by sl_id desc ", conn);
        SqlDataAdapter adapt6 = new SqlDataAdapter(cmd6);
        DataTable dt6 = new DataTable();
        adapt6.Fill(dt6);
        if (dt6.Rows.Count > 0)
        {
            Grid_b2c3.DataSource = dt6;
            Grid_b2c3.DataBind();
        }

    }
    protected void b2b4()
    {
        SqlCommand cmd7 = new SqlCommand("select sl_invoice_no as [Invoice ID],sl_invoice_date as [Invoice Date],c_name as [Customer Name],c_gst_no as [GST No],sl_total_taxable as [Taxable Value],sl_total_cgst as [CGST],sl_total_sgst as [SGST],sl_total_igst as [IGST],sl_total as [Total Amount] from tbl_sale inner join tbl_customer on tbl_sale.c_id=tbl_customer.c_id where c_gst_no != '" + string.Empty + "' AND sl_invoice_date between '" + DateTime.Now.Year.ToString()+"-04-01' and '"+DateTime.Now.Year.ToString()+"-04-30' order by sl_id desc ", conn);
        SqlDataAdapter adapt7 = new SqlDataAdapter(cmd7);
        DataTable dt7 = new DataTable();
        adapt7.Fill(dt7);
        if (dt7.Rows.Count > 0)
        {
            Grid_b2b4.DataSource = dt7;
            Grid_b2b4.DataBind();
        }

    }
    protected void b2c4()
    {
        SqlCommand cmd8 = new SqlCommand("select sl_invoice_no as [Invoice ID],sl_invoice_date as [Invoice Date],c_name as [Customer Name],sl_total_taxable as [Taxable Value],sl_total_cgst as [CGST],sl_total_sgst as [SGST],sl_total_igst as [IGST],sl_total as [Total Amount] from tbl_sale inner join tbl_customer on tbl_sale.c_id=tbl_customer.c_id where c_gst_no = '" + string.Empty + "' AND sl_invoice_date between '" + DateTime.Now.Year.ToString()+"-04-01' and '"+DateTime.Now.Year.ToString()+"-04-30' order by sl_id desc ", conn);
        SqlDataAdapter adapt8 = new SqlDataAdapter(cmd8);
        DataTable dt8 = new DataTable();
        adapt8.Fill(dt8);
        if (dt8.Rows.Count > 0)
        {
            Grid_b2c4.DataSource = dt8;
            Grid_b2c4.DataBind();
        }

    }
    protected void b2b5()
    {
        SqlCommand cmd9 = new SqlCommand("select sl_invoice_no as [Invoice ID],sl_invoice_date as [Invoice Date],c_name as [Customer Name],c_gst_no as [GST No],sl_total_taxable as [Taxable Value],sl_total_cgst as [CGST],sl_total_sgst as [SGST],sl_total_igst as [IGST],sl_total as [Total Amount] from tbl_sale inner join tbl_customer on tbl_sale.c_id=tbl_customer.c_id where c_gst_no != '" + string.Empty + "' AND sl_invoice_date between '" + DateTime.Now.Year.ToString()+"-05-01' and '"+DateTime.Now.Year.ToString()+"-05-31' order by sl_id desc ", conn);
        SqlDataAdapter adapt9 = new SqlDataAdapter(cmd9);
        DataTable dt9 = new DataTable();
        adapt9.Fill(dt9);
        if (dt9.Rows.Count > 0)
        {
            Grid_b2b5.DataSource = dt9;
            Grid_b2b5.DataBind();
        }

    }
    protected void b2c5()
    {
        SqlCommand cmd10 = new SqlCommand("select sl_invoice_no as [Invoice ID],sl_invoice_date as [Invoice Date],c_name as [Customer Name],sl_total_taxable as [Taxable Value],sl_total_cgst as [CGST],sl_total_sgst as [SGST],sl_total_igst as [IGST],sl_total as [Total Amount] from tbl_sale inner join tbl_customer on tbl_sale.c_id=tbl_customer.c_id where c_gst_no = '" + string.Empty + "' AND sl_invoice_date between '" + DateTime.Now.Year.ToString()+"-05-01' and '"+DateTime.Now.Year.ToString()+"-05-31' order by sl_id desc ", conn);
        SqlDataAdapter adapt10 = new SqlDataAdapter(cmd10);
        DataTable dt10 = new DataTable();
        adapt10.Fill(dt10);
        if (dt10.Rows.Count > 0)
        {
            Grid_b2c5.DataSource = dt10;
            Grid_b2c5.DataBind();
        }

    }
    protected void b2b6()
    {
        SqlCommand cmd11 = new SqlCommand("select sl_invoice_no as [Invoice ID],sl_invoice_date as [Invoice Date],c_name as [Customer Name],c_gst_no as [GST No],sl_total_taxable as [Taxable Value],sl_total_cgst as [CGST],sl_total_sgst as [SGST],sl_total_igst as [IGST],sl_total as [Total Amount] from tbl_sale inner join tbl_customer on tbl_sale.c_id=tbl_customer.c_id where c_gst_no != '" + string.Empty + "' AND sl_invoice_date between '" + DateTime.Now.Year.ToString()+"-06-01' and '"+DateTime.Now.Year.ToString()+"-06-30' order by sl_id desc ", conn);
        SqlDataAdapter adapt11 = new SqlDataAdapter(cmd11);
        DataTable dt11 = new DataTable();
        adapt11.Fill(dt11);
        if (dt11.Rows.Count > 0)
        {
            Grid_b2b6.DataSource = dt11;
            Grid_b2b6.DataBind();
        }

    }
    protected void b2c6()
    {
        SqlCommand cmd12 = new SqlCommand("select sl_invoice_no as [Invoice ID],sl_invoice_date as [Invoice Date],c_name as [Customer Name],sl_total_taxable as [Taxable Value],sl_total_cgst as [CGST],sl_total_sgst as [SGST],sl_total_igst as [IGST],sl_total as [Total Amount] from tbl_sale inner join tbl_customer on tbl_sale.c_id=tbl_customer.c_id where c_gst_no = '" + string.Empty + "' AND sl_invoice_date between '" + DateTime.Now.Year.ToString()+"-06-01' and '"+DateTime.Now.Year.ToString()+"-06-30' order by sl_id desc ", conn);
        SqlDataAdapter adapt12 = new SqlDataAdapter(cmd12);
        DataTable dt12 = new DataTable();
        adapt12.Fill(dt12);
        if (dt12.Rows.Count > 0)
        {
            Grid_b2c6.DataSource = dt12;
            Grid_b2c6.DataBind();
        }

    }
    protected void b2b7()
    {
        SqlCommand cmd13 = new SqlCommand("select sl_invoice_no as [Invoice ID],sl_invoice_date as [Invoice Date],c_name as [Customer Name],c_gst_no as [GST No],sl_total_taxable as [Taxable Value],sl_total_cgst as [CGST],sl_total_sgst as [SGST],sl_total_igst as [IGST],sl_total as [Total Amount] from tbl_sale inner join tbl_customer on tbl_sale.c_id=tbl_customer.c_id where c_gst_no != '" + string.Empty + "' AND sl_invoice_date between '" + DateTime.Now.Year.ToString()+"-07-01' and '"+DateTime.Now.Year.ToString()+"-07-31' order by sl_id desc ", conn);
        SqlDataAdapter adapt13 = new SqlDataAdapter(cmd13);
        DataTable dt13 = new DataTable();
        adapt13.Fill(dt13);
        if (dt13.Rows.Count > 0)
        {
            Grid_b2b7.DataSource = dt13;
            Grid_b2b7.DataBind();
        }

    }
    protected void b2c7()
    {
        SqlCommand cmd14 = new SqlCommand("select sl_invoice_no as [Invoice ID],sl_invoice_date as [Invoice Date],c_name as [Customer Name],sl_total_taxable as [Taxable Value],sl_total_cgst as [CGST],sl_total_sgst as [SGST],sl_total_igst as [IGST],sl_total as [Total Amount] from tbl_sale inner join tbl_customer on tbl_sale.c_id=tbl_customer.c_id where c_gst_no = '" + string.Empty + "' AND sl_invoice_date between '" + DateTime.Now.Year.ToString()+"-07-01' and '"+DateTime.Now.Year.ToString()+"-07-31' order by sl_id desc ", conn);
        SqlDataAdapter adapt14 = new SqlDataAdapter(cmd14);
        DataTable dt14 = new DataTable();
        adapt14.Fill(dt14);
        if (dt14.Rows.Count > 0)
        {
            Grid_b2c7.DataSource = dt14;
            Grid_b2c7.DataBind();
        }

    }
    protected void b2b8()
    {
        SqlCommand cmd15 = new SqlCommand("select sl_invoice_no as [Invoice ID],sl_invoice_date as [Invoice Date],c_name as [Customer Name],c_gst_no as [GST No],sl_total_taxable as [Taxable Value],sl_total_cgst as [CGST],sl_total_sgst as [SGST],sl_total_igst as [IGST],sl_total as [Total Amount] from tbl_sale inner join tbl_customer on tbl_sale.c_id=tbl_customer.c_id where c_gst_no != '" + string.Empty + "' AND sl_invoice_date between '" + DateTime.Now.Year.ToString()+"-08-01' and '"+DateTime.Now.Year.ToString()+"-08-31' order by sl_id desc ", conn);
        SqlDataAdapter adapt15 = new SqlDataAdapter(cmd15);
        DataTable dt15 = new DataTable();
        adapt15.Fill(dt15);
        if (dt15.Rows.Count > 0)
        {
            Grid_b2b8.DataSource = dt15;
            Grid_b2b8.DataBind();
        }

    }
    protected void b2c8()
    {
        SqlCommand cmd16 = new SqlCommand("select sl_invoice_no as [Invoice ID],sl_invoice_date as [Invoice Date],c_name as [Customer Name],sl_total_taxable as [Taxable Value],sl_total_cgst as [CGST],sl_total_sgst as [SGST],sl_total_igst as [IGST],sl_total as [Total Amount] from tbl_sale inner join tbl_customer on tbl_sale.c_id=tbl_customer.c_id where c_gst_no = '" + string.Empty + "' AND sl_invoice_date between '" + DateTime.Now.Year.ToString()+"-08-01' and '"+DateTime.Now.Year.ToString()+"-08-31' order by sl_id desc ", conn);
        SqlDataAdapter adapt16 = new SqlDataAdapter(cmd16);
        DataTable dt16 = new DataTable();
        adapt16.Fill(dt16);
        if (dt16.Rows.Count > 0)
        {
            Grid_b2c8.DataSource = dt16;
            Grid_b2c8.DataBind();
        }

    }
    protected void b2b9()
    {
        SqlCommand cmd17 = new SqlCommand("select sl_invoice_no as [Invoice ID],sl_invoice_date as [Invoice Date],c_name as [Customer Name],c_gst_no as [GST No],sl_total_taxable as [Taxable Value],sl_total_cgst as [CGST],sl_total_sgst as [SGST],sl_total_igst as [IGST],sl_total as [Total Amount] from tbl_sale inner join tbl_customer on tbl_sale.c_id=tbl_customer.c_id where c_gst_no != '" + string.Empty + "' AND sl_invoice_date between '" + DateTime.Now.Year.ToString()+"-09-01' and '"+DateTime.Now.Year.ToString()+"-09-30' order by sl_id desc ", conn);
        SqlDataAdapter adapt17 = new SqlDataAdapter(cmd17);
        DataTable dt17 = new DataTable();
        adapt17.Fill(dt17);
        if (dt17.Rows.Count > 0)
        {
            Grid_b2b9.DataSource = dt17;
            Grid_b2b9.DataBind();
        }

    }
    protected void b2c9()
    {
        SqlCommand cmd18 = new SqlCommand("select sl_invoice_no as [Invoice ID],sl_invoice_date as [Invoice Date],c_name as [Customer Name],sl_total_taxable as [Taxable Value],sl_total_cgst as [CGST],sl_total_sgst as [SGST],sl_total_igst as [IGST],sl_total as [Total Amount] from tbl_sale inner join tbl_customer on tbl_sale.c_id=tbl_customer.c_id where c_gst_no = '" + string.Empty + "' AND sl_invoice_date between '" + DateTime.Now.Year.ToString()+"-09-01' and '"+DateTime.Now.Year.ToString()+"-09-30' order by sl_id desc ", conn);
        SqlDataAdapter adapt18 = new SqlDataAdapter(cmd18);
        DataTable dt18 = new DataTable();
        adapt18.Fill(dt18);
        if (dt18.Rows.Count > 0)
        {
            Grid_b2c9.DataSource = dt18;
            Grid_b2c9.DataBind();
        }

    }
    protected void b2b10()
    {
        SqlCommand cmd19 = new SqlCommand("select sl_invoice_no as [Invoice ID],sl_invoice_date as [Invoice Date],c_name as [Customer Name],c_gst_no as [GST No],sl_total_taxable as [Taxable Value],sl_total_cgst as [CGST],sl_total_sgst as [SGST],sl_total_igst as [IGST],sl_total as [Total Amount] from tbl_sale inner join tbl_customer on tbl_sale.c_id=tbl_customer.c_id where c_gst_no != '" + string.Empty + "' AND sl_invoice_date between '" + DateTime.Now.Year.ToString()+"-10-01' and '"+DateTime.Now.Year.ToString()+"-10-31' order by sl_id desc ", conn);
        SqlDataAdapter adapt19 = new SqlDataAdapter(cmd19);
        DataTable dt19 = new DataTable();
        adapt19.Fill(dt19);
        if (dt19.Rows.Count > 0)
        {
            Grid_b2b10.DataSource = dt19;
            Grid_b2b10.DataBind();
        }

    }
    protected void b2c10()
    {
        SqlCommand cmd20 = new SqlCommand("select sl_invoice_no as [Invoice ID],sl_invoice_date as [Invoice Date],c_name as [Customer Name],sl_total_taxable as [Taxable Value],sl_total_cgst as [CGST],sl_total_sgst as [SGST],sl_total_igst as [IGST],sl_total as [Total Amount] from tbl_sale inner join tbl_customer on tbl_sale.c_id=tbl_customer.c_id where c_gst_no = '" + string.Empty + "' AND sl_invoice_date between '" + DateTime.Now.Year.ToString()+"-10-01' and '"+DateTime.Now.Year.ToString()+"-10-31' order by sl_id desc ", conn);
        SqlDataAdapter adapt20 = new SqlDataAdapter(cmd20);
        DataTable dt20 = new DataTable();
        adapt20.Fill(dt20);
        if (dt20.Rows.Count > 0)
        {
            Grid_b2c10.DataSource = dt20;
            Grid_b2c10.DataBind();
        }

    }
    protected void b2b11()
    {
        SqlCommand cmd21 = new SqlCommand("select sl_invoice_no as [Invoice ID],sl_invoice_date as [Invoice Date],c_name as [Customer Name],c_gst_no as [GST No],sl_total_taxable as [Taxable Value],sl_total_cgst as [CGST],sl_total_sgst as [SGST],sl_total_igst as [IGST],sl_total as [Total Amount] from tbl_sale inner join tbl_customer on tbl_sale.c_id=tbl_customer.c_id where c_gst_no != '" + string.Empty + "' AND sl_invoice_date between '" + DateTime.Now.Year.ToString()+"-11-01' and '"+DateTime.Now.Year.ToString()+"-11-30' order by sl_id desc ", conn);
        SqlDataAdapter adapt21 = new SqlDataAdapter(cmd21);
        DataTable dt21 = new DataTable();
        adapt21.Fill(dt21);
        if (dt21.Rows.Count > 0)
        {
            Grid_b2b11.DataSource = dt21;
            Grid_b2b11.DataBind();
        }

    }
    protected void b2c11()
    {
        SqlCommand cmd22 = new SqlCommand("select sl_invoice_no as [Invoice ID],sl_invoice_date as [Invoice Date],c_name as [Customer Name],sl_total_taxable as [Taxable Value],sl_total_cgst as [CGST],sl_total_sgst as [SGST],sl_total_igst as [IGST],sl_total as [Total Amount] from tbl_sale inner join tbl_customer on tbl_sale.c_id=tbl_customer.c_id where c_gst_no = '" + string.Empty + "' AND sl_invoice_date between '" + DateTime.Now.Year.ToString()+"-11-01' and '"+DateTime.Now.Year.ToString()+"-11-30' order by sl_id desc ", conn);
        SqlDataAdapter adapt22 = new SqlDataAdapter(cmd22);
        DataTable dt22 = new DataTable();
        adapt22.Fill(dt22);
        if (dt22.Rows.Count > 0)
        {
            Grid_b2c11.DataSource = dt22;
            Grid_b2c11.DataBind();
        }

    }
    protected void b2b12()
    {
        SqlCommand cmd23 = new SqlCommand("select sl_invoice_no as [Invoice ID],sl_invoice_date as [Invoice Date],c_name as [Customer Name],c_gst_no as [GST No],sl_total_taxable as [Taxable Value],sl_total_cgst as [CGST],sl_total_sgst as [SGST],sl_total_igst as [IGST],sl_total as [Total Amount] from tbl_sale inner join tbl_customer on tbl_sale.c_id=tbl_customer.c_id where c_gst_no != '" + string.Empty + "' AND sl_invoice_date between '" + DateTime.Now.Year.ToString()+"-12-01' and '"+DateTime.Now.Year.ToString()+"-12-31' order by sl_id desc ", conn);
        SqlDataAdapter adapt23 = new SqlDataAdapter(cmd23);
        DataTable dt23 = new DataTable();
        adapt23.Fill(dt23);
        if (dt23.Rows.Count > 0)
        {
            Grid_b2b12.DataSource = dt23;
            Grid_b2b12.DataBind();
        }

    }
    protected void b2c12()
    {
        SqlCommand cmd24 = new SqlCommand("select sl_invoice_no as [Invoice ID],sl_invoice_date as [Invoice Date],c_name as [Customer Name],sl_total_taxable as [Taxable Value],sl_total_cgst as [CGST],sl_total_sgst as [SGST],sl_total_igst as [IGST],sl_total as [Total Amount] from tbl_sale inner join tbl_customer on tbl_sale.c_id=tbl_customer.c_id where c_gst_no = '" + string.Empty + "' AND sl_invoice_date between '" + DateTime.Now.Year.ToString()+"-12-01' and '"+DateTime.Now.Year.ToString()+"-12-31' order by sl_id desc ", conn);
        SqlDataAdapter adapt24 = new SqlDataAdapter(cmd24);
        DataTable dt24 = new DataTable();
        adapt24.Fill(dt24);
        if (dt24.Rows.Count > 0)
        {
            Grid_b2c12.DataSource = dt24;
            Grid_b2c12.DataBind();
        }

    }
    protected void excel_export(object sender, EventArgs e)
    {
        try
        {

            // Response.Close();
            string date = DateTime.Now.ToString("dd-MM-yyyy--HH-mm");
            var da = new SqlDataAdapter("select c_gst_no as [GST No],c_name as [Customer Name],sl_transaction_type as [Transaction Type],sl_invoice_no as [Invoice ID],sl_invoice_date as [Invoice Date],sl_total as [Total Amount],sl_cess as [Cess],sl_total_taxable as [Taxable Value],sl_total_igst as [IGST],sl_total_cgst as [CGST],sl_total_sgst as [SGST] from tbl_sale inner join tbl_customer on tbl_sale.c_id=tbl_customer.c_id where c_gst_no != '" + string.Empty + "' AND sl_invoice_date between '" + DateTime.Now.Year.ToString()+"-01-01' and '"+DateTime.Now.Year.ToString()+"-01-31' order by sl_id desc ", conn);
            var dt = new DataTable();
            da.Fill(dt);

            Grid_b2b.DataSource = dt;
            Grid_b2b.DataBind();
            Response.Clear();
            Response.Charset = "";
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.ContentType = "application/vnd.xls";
            Response.AddHeader("content-disposition", "attachment;filename=GSTR1 B2B Jan-" + date + ".xls");

            System.IO.StringWriter sw = new System.IO.StringWriter();
            HtmlTextWriter htw = new HtmlTextWriter(sw);
            Grid_b2b.RenderControl(htw);
            System.Text.StringBuilder sb1 = new System.Text.StringBuilder();
            sb1 = sb1.Append("<table cellspacing='0' cellpadding='0' width='100 % ' align='center' border='1'>" + sw.ToString() + "</table>");
            sw = null;
            htw = null;
            Response.Write(sb1.ToString());
            sb1.Remove(0, sb1.Length);
            Response.Flush();
            Response.End();
        }
        catch (Exception ex)
        {

        }
    }
    protected void excel_export2(object sender, EventArgs e)
    {
        try
        {

            // Response.Close();
            string date = DateTime.Now.ToString("dd-MM-yyyy--HH-mm");
            var da = new SqlDataAdapter("select c_gst_no as [GST No],c_name as [Customer Name],sl_transaction_type as [Transaction Type],sl_invoice_no as [Invoice ID],sl_invoice_date as [Invoice Date],sl_total as [Total Amount],sl_cess as [Cess],sl_total_taxable as [Taxable Value],sl_total_igst as [IGST],sl_total_cgst as [CGST],sl_total_sgst as [SGST] from tbl_sale inner join tbl_customer on tbl_sale.c_id=tbl_customer.c_id where c_gst_no = '" + string.Empty + "' AND sl_invoice_date between '" + DateTime.Now.Year.ToString()+"-01-01' and '"+DateTime.Now.Year.ToString()+"-01-31' order by sl_id desc ", conn);
            var dt = new DataTable();
            da.Fill(dt);

            Grid_b2b.DataSource = dt;
            Grid_b2b.DataBind();
            Response.Clear();
            Response.Charset = "";
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.ContentType = "application/vnd.xls";
            Response.AddHeader("content-disposition", "attachment;filename=GSTR1 B2C Jan-" + date + ".xls");

            System.IO.StringWriter sw = new System.IO.StringWriter();
            HtmlTextWriter htw = new HtmlTextWriter(sw);
            Grid_b2b.RenderControl(htw);
            System.Text.StringBuilder sb1 = new System.Text.StringBuilder();
            sb1 = sb1.Append("<table cellspacing='0' cellpadding='0' width='100 % ' align='center' border='1'>" + sw.ToString() + "</table>");
            sw = null;
            htw = null;
            Response.Write(sb1.ToString());
            sb1.Remove(0, sb1.Length);
            Response.Flush();
            Response.End();
        }
        catch (Exception ex)
        {

        }
    }
    protected void excel_export3(object sender, EventArgs e)
    {
        try
        {

            // Response.Close();
            string date = DateTime.Now.ToString("dd-MM-yyyy--HH-mm");
            var da = new SqlDataAdapter("select c_gst_no as [GST No],c_name as [Customer Name],sl_transaction_type as [Transaction Type],sl_invoice_no as [Invoice ID],sl_invoice_date as [Invoice Date],sl_total as [Total Amount],sl_cess as [Cess],sl_total_taxable as [Taxable Value],sl_total_igst as [IGST],sl_total_cgst as [CGST],sl_total_sgst as [SGST] from tbl_sale inner join tbl_customer on tbl_sale.c_id=tbl_customer.c_id where c_gst_no != '" + string.Empty + "' AND sl_invoice_date between '" + DateTime.Now.Year.ToString()+"-02-01' and '"+DateTime.Now.Year.ToString()+"-02-28' order by sl_id desc ", conn);
            var dt = new DataTable();
            da.Fill(dt);

            Grid_b2b.DataSource = dt;
            Grid_b2b.DataBind();
            Response.Clear();
            Response.Charset = "";
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.ContentType = "application/vnd.xls";
            Response.AddHeader("content-disposition", "attachment;filename=GSTR1 B2B Feb-" + date + ".xls");

            System.IO.StringWriter sw = new System.IO.StringWriter();
            HtmlTextWriter htw = new HtmlTextWriter(sw);
            Grid_b2b.RenderControl(htw);
            System.Text.StringBuilder sb1 = new System.Text.StringBuilder();
            sb1 = sb1.Append("<table cellspacing='0' cellpadding='0' width='100 % ' align='center' border='1'>" + sw.ToString() + "</table>");
            sw = null;
            htw = null;
            Response.Write(sb1.ToString());
            sb1.Remove(0, sb1.Length);
            Response.Flush();
            Response.End();
        }
        catch (Exception ex)
        {

        }
    }
    protected void excel_export4(object sender, EventArgs e)
    {
        try
        {

            // Response.Close();
            string date = DateTime.Now.ToString("dd-MM-yyyy--HH-mm");
            var da = new SqlDataAdapter("select c_gst_no as [GST No],c_name as [Customer Name],sl_transaction_type as [Transaction Type],sl_invoice_no as [Invoice ID],sl_invoice_date as [Invoice Date],sl_total as [Total Amount],sl_cess as [Cess],sl_total_taxable as [Taxable Value],sl_total_igst as [IGST],sl_total_cgst as [CGST],sl_total_sgst as [SGST] from tbl_sale inner join tbl_customer on tbl_sale.c_id=tbl_customer.c_id where c_gst_no = '" + string.Empty + "' AND sl_invoice_date between '" + DateTime.Now.Year.ToString()+"-02-01' and '"+DateTime.Now.Year.ToString()+"-02-28' order by sl_id desc ", conn);
            var dt = new DataTable();
            da.Fill(dt);

            Grid_b2b.DataSource = dt;
            Grid_b2b.DataBind();
            Response.Clear();
            Response.Charset = "";
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.ContentType = "application/vnd.xls";
            Response.AddHeader("content-disposition", "attachment;filename=GSTR1 B2C Feb-" + date + ".xls");

            System.IO.StringWriter sw = new System.IO.StringWriter();
            HtmlTextWriter htw = new HtmlTextWriter(sw);
            Grid_b2b.RenderControl(htw);
            System.Text.StringBuilder sb1 = new System.Text.StringBuilder();
            sb1 = sb1.Append("<table cellspacing='0' cellpadding='0' width='100 % ' align='center' border='1'>" + sw.ToString() + "</table>");
            sw = null;
            htw = null;
            Response.Write(sb1.ToString());
            sb1.Remove(0, sb1.Length);
            Response.Flush();
            Response.End();
        }
        catch (Exception ex)
        {

        }
    }
    protected void excel_export5(object sender, EventArgs e)
    {
        try
        {

            // Response.Close();
            string date = DateTime.Now.ToString("dd-MM-yyyy--HH-mm");
            var da = new SqlDataAdapter("select c_gst_no as [GST No],c_name as [Customer Name],sl_transaction_type as [Transaction Type],sl_invoice_no as [Invoice ID],sl_invoice_date as [Invoice Date],sl_total as [Total Amount],sl_cess as [Cess],sl_total_taxable as [Taxable Value],sl_total_igst as [IGST],sl_total_cgst as [CGST],sl_total_sgst as [SGST] from tbl_sale inner join tbl_customer on tbl_sale.c_id=tbl_customer.c_id where c_gst_no != '" + string.Empty + "' AND sl_invoice_date between '" + DateTime.Now.Year.ToString()+"-03-01' and '"+DateTime.Now.Year.ToString()+"-03-31' order by sl_id desc ", conn);
            var dt = new DataTable();
            da.Fill(dt);

            Grid_b2b.DataSource = dt;
            Grid_b2b.DataBind();
            Response.Clear();
            Response.Charset = "";
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.ContentType = "application/vnd.xls";
            Response.AddHeader("content-disposition", "attachment;filename=GSTR1 B2B Mar-" + date + ".xls");

            System.IO.StringWriter sw = new System.IO.StringWriter();
            HtmlTextWriter htw = new HtmlTextWriter(sw);
            Grid_b2b.RenderControl(htw);
            System.Text.StringBuilder sb1 = new System.Text.StringBuilder();
            sb1 = sb1.Append("<table cellspacing='0' cellpadding='0' width='100 % ' align='center' border='1'>" + sw.ToString() + "</table>");
            sw = null;
            htw = null;
            Response.Write(sb1.ToString());
            sb1.Remove(0, sb1.Length);
            Response.Flush();
            Response.End();
        }
        catch (Exception ex)
        {

        }
    }
    protected void excel_export6(object sender, EventArgs e)
    {
        try
        {

            // Response.Close();
            string date = DateTime.Now.ToString("dd-MM-yyyy--HH-mm");
            var da = new SqlDataAdapter("select c_gst_no as [GST No],c_name as [Customer Name],sl_transaction_type as [Transaction Type],sl_invoice_no as [Invoice ID],sl_invoice_date as [Invoice Date],sl_total as [Total Amount],sl_cess as [Cess],sl_total_taxable as [Taxable Value],sl_total_igst as [IGST],sl_total_cgst as [CGST],sl_total_sgst as [SGST] from tbl_sale inner join tbl_customer on tbl_sale.c_id=tbl_customer.c_id where c_gst_no = '" + string.Empty + "' AND sl_invoice_date between '" + DateTime.Now.Year.ToString()+"-03-01' and '"+DateTime.Now.Year.ToString()+"-03-31' order by sl_id desc ", conn);
            var dt = new DataTable();
            da.Fill(dt);

            Grid_b2b.DataSource = dt;
            Grid_b2b.DataBind();
            Response.Clear();
            Response.Charset = "";
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.ContentType = "application/vnd.xls";
            Response.AddHeader("content-disposition", "attachment;filename=GSTR1 B2C Mar-" + date + ".xls");

            System.IO.StringWriter sw = new System.IO.StringWriter();
            HtmlTextWriter htw = new HtmlTextWriter(sw);
            Grid_b2b.RenderControl(htw);
            System.Text.StringBuilder sb1 = new System.Text.StringBuilder();
            sb1 = sb1.Append("<table cellspacing='0' cellpadding='0' width='100 % ' align='center' border='1'>" + sw.ToString() + "</table>");
            sw = null;
            htw = null;
            Response.Write(sb1.ToString());
            sb1.Remove(0, sb1.Length);
            Response.Flush();
            Response.End();
        }
        catch (Exception ex)
        {

        }
    }
    protected void excel_export7(object sender, EventArgs e)
    {
        try
        {

            // Response.Close();
            string date = DateTime.Now.ToString("dd-MM-yyyy--HH-mm");
            var da = new SqlDataAdapter("select c_gst_no as [GST No], c_name as [Customer Name], sl_transaction_type as [Transaction Type], sl_invoice_no as [Invoice ID], sl_invoice_date as [Invoice Date], sl_total as [Total Amount], sl_cess as [Cess], sl_total_taxable as [Taxable Value], sl_total_igst as [IGST], sl_total_cgst as [CGST], sl_total_sgst as [SGST] from tbl_sale inner join tbl_customer on tbl_sale.c_id=tbl_customer.c_id where c_gst_no != '" + string.Empty + "' AND sl_invoice_date between '" + DateTime.Now.Year.ToString()+"-04-01' and '"+DateTime.Now.Year.ToString()+"-04-30' order by sl_id desc ", conn);
            var dt = new DataTable();
            da.Fill(dt);

            Grid_b2b.DataSource = dt;
            Grid_b2b.DataBind();
            Response.Clear();
            Response.Charset = "";
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.ContentType = "application/vnd.xls";
            Response.AddHeader("content-disposition", "attachment;filename=GSTR1 B2B Apr-" + date + ".xls");

            System.IO.StringWriter sw = new System.IO.StringWriter();
            HtmlTextWriter htw = new HtmlTextWriter(sw);
            Grid_b2b.RenderControl(htw);
            System.Text.StringBuilder sb1 = new System.Text.StringBuilder();
            sb1 = sb1.Append("<table cellspacing='0' cellpadding='0' width='100 % ' align='center' border='1'>" + sw.ToString() + "</table>");
            sw = null;
            htw = null;
            Response.Write(sb1.ToString());
            sb1.Remove(0, sb1.Length);
            Response.Flush();
            Response.End();
        }
        catch (Exception ex)
        {

        }
    }
    protected void excel_export8(object sender, EventArgs e)
    {
        try
        {

            // Response.Close();
            string date = DateTime.Now.ToString("dd-MM-yyyy--HH-mm");
            var da = new SqlDataAdapter("select c_gst_no as [GST No],c_name as [Customer Name],sl_transaction_type as [Transaction Type],sl_invoice_no as [Invoice ID],sl_invoice_date as [Invoice Date],sl_total as [Total Amount],sl_cess as [Cess],sl_total_taxable as [Taxable Value],sl_total_igst as [IGST],sl_total_cgst as [CGST],sl_total_sgst as [SGST] from tbl_sale inner join tbl_customer on tbl_sale.c_id=tbl_customer.c_id where c_gst_no = '" + string.Empty + "' AND sl_invoice_date between '" + DateTime.Now.Year.ToString()+"-04-01' and '"+DateTime.Now.Year.ToString()+"-04-30' order by sl_id desc ", conn);
            var dt = new DataTable();
            da.Fill(dt);

            Grid_b2b.DataSource = dt;
            Grid_b2b.DataBind();
            Response.Clear();
            Response.Charset = "";
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.ContentType = "application/vnd.xls";
            Response.AddHeader("content-disposition", "attachment;filename=GSTR1 B2C Apr-" + date + ".xls");

            System.IO.StringWriter sw = new System.IO.StringWriter();
            HtmlTextWriter htw = new HtmlTextWriter(sw);
            Grid_b2b.RenderControl(htw);
            System.Text.StringBuilder sb1 = new System.Text.StringBuilder();
            sb1 = sb1.Append("<table cellspacing='0' cellpadding='0' width='100 % ' align='center' border='1'>" + sw.ToString() + "</table>");
            sw = null;
            htw = null;
            Response.Write(sb1.ToString());
            sb1.Remove(0, sb1.Length);
            Response.Flush();
            Response.End();
        }
        catch (Exception ex)
        {

        }
    }
    protected void excel_export9(object sender, EventArgs e)
    {
        try
        {

            // Response.Close();
            string date = DateTime.Now.ToString("dd-MM-yyyy--HH-mm");
            var da = new SqlDataAdapter("select c_gst_no as [GST No],c_name as [Customer Name],sl_transaction_type as [Transaction Type],sl_invoice_no as [Invoice ID],sl_invoice_date as [Invoice Date],sl_total as [Total Amount],sl_cess as [Cess],sl_total_taxable as [Taxable Value],sl_total_igst as [IGST],sl_total_cgst as [CGST],sl_total_sgst as [SGST] from tbl_sale inner join tbl_customer on tbl_sale.c_id=tbl_customer.c_id where c_gst_no != '" + string.Empty + "' AND sl_invoice_date between '" + DateTime.Now.Year.ToString()+"-05-01' and '"+DateTime.Now.Year.ToString()+"-05-31' order by sl_id desc ", conn);
            var dt = new DataTable();
            da.Fill(dt);

            Grid_b2b.DataSource = dt;
            Grid_b2b.DataBind();
            Response.Clear();
            Response.Charset = "";
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.ContentType = "application/vnd.xls";
            Response.AddHeader("content-disposition", "attachment;filename=GSTR1 B2B May-" + date + ".xls");

            System.IO.StringWriter sw = new System.IO.StringWriter();
            HtmlTextWriter htw = new HtmlTextWriter(sw);
            Grid_b2b.RenderControl(htw);
            System.Text.StringBuilder sb1 = new System.Text.StringBuilder();
            sb1 = sb1.Append("<table cellspacing='0' cellpadding='0' width='100 % ' align='center' border='1'>" + sw.ToString() + "</table>");
            sw = null;
            htw = null;
            Response.Write(sb1.ToString());
            sb1.Remove(0, sb1.Length);
            Response.Flush();
            Response.End();
        }
        catch (Exception ex)
        {

        }
    }
    protected void excel_export10(object sender, EventArgs e)
    {
        try
        {

            // Response.Close();
            string date = DateTime.Now.ToString("dd-MM-yyyy--HH-mm");
            var da = new SqlDataAdapter("select c_gst_no as [GST No],c_name as [Customer Name],sl_transaction_type as [Transaction Type],sl_invoice_no as [Invoice ID],sl_invoice_date as [Invoice Date],sl_total as [Total Amount],sl_cess as [Cess],sl_total_taxable as [Taxable Value],sl_total_igst as [IGST],sl_total_cgst as [CGST],sl_total_sgst as [SGST] from tbl_sale inner join tbl_customer on tbl_sale.c_id=tbl_customer.c_id where c_gst_no = '" + string.Empty + "' AND sl_invoice_date between '" + DateTime.Now.Year.ToString()+"-05-01' and '"+DateTime.Now.Year.ToString()+"-05-31' order by sl_id desc ", conn);
            var dt = new DataTable();
            da.Fill(dt);

            Grid_b2b.DataSource = dt;
            Grid_b2b.DataBind();
            Response.Clear();
            Response.Charset = "";
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.ContentType = "application/vnd.xls";
            Response.AddHeader("content-disposition", "attachment;filename=GSTR1 B2C May-" + date + ".xls");

            System.IO.StringWriter sw = new System.IO.StringWriter();
            HtmlTextWriter htw = new HtmlTextWriter(sw);
            Grid_b2b.RenderControl(htw);
            System.Text.StringBuilder sb1 = new System.Text.StringBuilder();
            sb1 = sb1.Append("<table cellspacing='0' cellpadding='0' width='100 % ' align='center' border='1'>" + sw.ToString() + "</table>");
            sw = null;
            htw = null;
            Response.Write(sb1.ToString());
            sb1.Remove(0, sb1.Length);
            Response.Flush();
            Response.End();
        }
        catch (Exception ex)
        {

        }
    }
    protected void excel_export11(object sender, EventArgs e)
    {
        try
        {

            // Response.Close();
            string date = DateTime.Now.ToString("dd-MM-yyyy--HH-mm");
            var da = new SqlDataAdapter("select c_gst_no as [GST No],c_name as [Customer Name],sl_transaction_type as [Transaction Type],sl_invoice_no as [Invoice ID],sl_invoice_date as [Invoice Date],sl_total as [Total Amount],sl_cess as [Cess],sl_total_taxable as [Taxable Value],sl_total_igst as [IGST],sl_total_cgst as [CGST],sl_total_sgst as [SGST] from tbl_sale inner join tbl_customer on tbl_sale.c_id=tbl_customer.c_id where c_gst_no != '" + string.Empty + "' AND sl_invoice_date between '" + DateTime.Now.Year.ToString()+"-06-01' and '"+DateTime.Now.Year.ToString()+"-06-30' order by sl_id desc ", conn);
            var dt = new DataTable();
            da.Fill(dt);

            Grid_b2b.DataSource = dt;
            Grid_b2b.DataBind();
            Response.Clear();
            Response.Charset = "";
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.ContentType = "application/vnd.xls";
            Response.AddHeader("content-disposition", "attachment;filename=GSTR1 B2B Jun-" + date + ".xls");

            System.IO.StringWriter sw = new System.IO.StringWriter();
            HtmlTextWriter htw = new HtmlTextWriter(sw);
            Grid_b2b.RenderControl(htw);
            System.Text.StringBuilder sb1 = new System.Text.StringBuilder();
            sb1 = sb1.Append("<table cellspacing='0' cellpadding='0' width='100 % ' align='center' border='1'>" + sw.ToString() + "</table>");
            sw = null;
            htw = null;
            Response.Write(sb1.ToString());
            sb1.Remove(0, sb1.Length);
            Response.Flush();
            Response.End();
        }
        catch (Exception ex)
        {

        }
    }
    protected void excel_export12(object sender, EventArgs e)
    {
        try
        {

            // Response.Close();
            string date = DateTime.Now.ToString("dd-MM-yyyy--HH-mm");
            var da = new SqlDataAdapter("select c_gst_no as [GST No],c_name as [Customer Name],sl_transaction_type as [Transaction Type],sl_invoice_no as [Invoice ID],sl_invoice_date as [Invoice Date],sl_total as [Total Amount],sl_cess as [Cess],sl_total_taxable as [Taxable Value],sl_total_igst as [IGST],sl_total_cgst as [CGST],sl_total_sgst as [SGST] from tbl_sale inner join tbl_customer on tbl_sale.c_id=tbl_customer.c_id where c_gst_no = '" + string.Empty + "' AND sl_invoice_date between '" + DateTime.Now.Year.ToString()+"-06-01' and '"+DateTime.Now.Year.ToString()+"-06-30' order by sl_id desc ", conn);
            var dt = new DataTable();
            da.Fill(dt);

            Grid_b2b.DataSource = dt;
            Grid_b2b.DataBind();
            Response.Clear();
            Response.Charset = "";
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.ContentType = "application/vnd.xls";
            Response.AddHeader("content-disposition", "attachment;filename=GSTR1 B2C Jun-" + date + ".xls");

            System.IO.StringWriter sw = new System.IO.StringWriter();
            HtmlTextWriter htw = new HtmlTextWriter(sw);
            Grid_b2b.RenderControl(htw);
            System.Text.StringBuilder sb1 = new System.Text.StringBuilder();
            sb1 = sb1.Append("<table cellspacing='0' cellpadding='0' width='100 % ' align='center' border='1'>" + sw.ToString() + "</table>");
            sw = null;
            htw = null;
            Response.Write(sb1.ToString());
            sb1.Remove(0, sb1.Length);
            Response.Flush();
            Response.End();
        }
        catch (Exception ex)
        {

        }
    }
    protected void excel_export13(object sender, EventArgs e)
    {
        try
        {

            // Response.Close();
            string date = DateTime.Now.ToString("dd-MM-yyyy--HH-mm");
            var da = new SqlDataAdapter("select c_gst_no as [GST No],c_name as [Customer Name],sl_transaction_type as [Transaction Type],sl_invoice_no as [Invoice ID],sl_invoice_date as [Invoice Date],sl_total as [Total Amount],sl_cess as [Cess],sl_total_taxable as [Taxable Value],sl_total_igst as [IGST],sl_total_cgst as [CGST],sl_total_sgst as [SGST] from tbl_sale inner join tbl_customer on tbl_sale.c_id=tbl_customer.c_id where c_gst_no != '" + string.Empty + "' AND sl_invoice_date between '" + DateTime.Now.Year.ToString()+"-07-01' and '"+DateTime.Now.Year.ToString()+"-07-31' order by sl_id desc ", conn);
            var dt = new DataTable();
            da.Fill(dt);

            Grid_b2b.DataSource = dt;
            Grid_b2b.DataBind();
            Response.Clear();
            Response.Charset = "";
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.ContentType = "application/vnd.xls";
            Response.AddHeader("content-disposition", "attachment;filename=GSTR1 B2B Jul-" + date + ".xls");

            System.IO.StringWriter sw = new System.IO.StringWriter();
            HtmlTextWriter htw = new HtmlTextWriter(sw);
            Grid_b2b.RenderControl(htw);
            System.Text.StringBuilder sb1 = new System.Text.StringBuilder();
            sb1 = sb1.Append("<table cellspacing='0' cellpadding='0' width='100 % ' align='center' border='1'>" + sw.ToString() + "</table>");
            sw = null;
            htw = null;
            Response.Write(sb1.ToString());
            sb1.Remove(0, sb1.Length);
            Response.Flush();
            Response.End();
        }
        catch (Exception ex)
        {

        }
    }
    protected void excel_export14(object sender, EventArgs e)
    {
        try
        {

            // Response.Close();
            string date = DateTime.Now.ToString("dd-MM-yyyy--HH-mm");
            var da = new SqlDataAdapter("select c_gst_no as [GST No],c_name as [Customer Name],sl_transaction_type as [Transaction Type],sl_invoice_no as [Invoice ID],sl_invoice_date as [Invoice Date],sl_total as [Total Amount],sl_cess as [Cess],sl_total_taxable as [Taxable Value],sl_total_igst as [IGST],sl_total_cgst as [CGST],sl_total_sgst as [SGST] from tbl_sale inner join tbl_customer on tbl_sale.c_id=tbl_customer.c_id where c_gst_no = '" + string.Empty + "' AND sl_invoice_date between '" + DateTime.Now.Year.ToString()+"-07-01' and '"+DateTime.Now.Year.ToString()+"-07-31' order by sl_id desc ", conn);
            var dt = new DataTable();
            da.Fill(dt);

            Grid_b2b.DataSource = dt;
            Grid_b2b.DataBind();
            Response.Clear();
            Response.Charset = "";
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.ContentType = "application/vnd.xls";
            Response.AddHeader("content-disposition", "attachment;filename=GSTR1 B2C Jul-" + date + ".xls");

            System.IO.StringWriter sw = new System.IO.StringWriter();
            HtmlTextWriter htw = new HtmlTextWriter(sw);
            Grid_b2b.RenderControl(htw);
            System.Text.StringBuilder sb1 = new System.Text.StringBuilder();
            sb1 = sb1.Append("<table cellspacing='0' cellpadding='0' width='100 % ' align='center' border='1'>" + sw.ToString() + "</table>");
            sw = null;
            htw = null;
            Response.Write(sb1.ToString());
            sb1.Remove(0, sb1.Length);
            Response.Flush();
            Response.End();
        }
        catch (Exception ex)
        {

        }
    }
    protected void excel_export15(object sender, EventArgs e)
    {
        try
        {

            // Response.Close();
            string date = DateTime.Now.ToString("dd-MM-yyyy--HH-mm");
            var da = new SqlDataAdapter("select c_gst_no as [GST No],c_name as [Customer Name],sl_transaction_type as [Transaction Type],sl_invoice_no as [Invoice ID],sl_invoice_date as [Invoice Date],sl_total as [Total Amount],sl_cess as [Cess],sl_total_taxable as [Taxable Value],sl_total_igst as [IGST],sl_total_cgst as [CGST],sl_total_sgst as [SGST] from tbl_sale inner join tbl_customer on tbl_sale.c_id=tbl_customer.c_id where c_gst_no != '" + string.Empty + "' AND sl_invoice_date between '" + DateTime.Now.Year.ToString()+"-08-01' and '"+DateTime.Now.Year.ToString()+"-08-31' order by sl_id desc ", conn);
            var dt = new DataTable();
            da.Fill(dt);

            Grid_b2b.DataSource = dt;
            Grid_b2b.DataBind();
            Response.Clear();
            Response.Charset = "";
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.ContentType = "application/vnd.xls";
            Response.AddHeader("content-disposition", "attachment;filename=GSTR1 B2B Aug-" + date + ".xls");

            System.IO.StringWriter sw = new System.IO.StringWriter();
            HtmlTextWriter htw = new HtmlTextWriter(sw);
            Grid_b2b.RenderControl(htw);
            System.Text.StringBuilder sb1 = new System.Text.StringBuilder();
            sb1 = sb1.Append("<table cellspacing='0' cellpadding='0' width='100 % ' align='center' border='1'>" + sw.ToString() + "</table>");
            sw = null;
            htw = null;
            Response.Write(sb1.ToString());
            sb1.Remove(0, sb1.Length);
            Response.Flush();
            Response.End();
        }
        catch (Exception ex)
        {

        }
    }
    protected void excel_export16(object sender, EventArgs e)
    {
        try
        {

            // Response.Close();
            string date = DateTime.Now.ToString("dd-MM-yyyy--HH-mm");
            var da = new SqlDataAdapter("select c_gst_no as [GST No],c_name as [Customer Name],sl_transaction_type as [Transaction Type],sl_invoice_no as [Invoice ID],sl_invoice_date as [Invoice Date],sl_total as [Total Amount],sl_cess as [Cess],sl_total_taxable as [Taxable Value],sl_total_igst as [IGST],sl_total_cgst as [CGST],sl_total_sgst as [SGST] from tbl_sale inner join tbl_customer on tbl_sale.c_id=tbl_customer.c_id where c_gst_no = '" + string.Empty + "' AND sl_invoice_date between '" + DateTime.Now.Year.ToString()+"-08-01' and '"+DateTime.Now.Year.ToString()+"-08-31' order by sl_id desc ", conn);
            var dt = new DataTable();
            da.Fill(dt);

            Grid_b2b.DataSource = dt;
            Grid_b2b.DataBind();
            Response.Clear();
            Response.Charset = "";
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.ContentType = "application/vnd.xls";
            Response.AddHeader("content-disposition", "attachment;filename=GSTR1 B2C Aug-" + date + ".xls");

            System.IO.StringWriter sw = new System.IO.StringWriter();
            HtmlTextWriter htw = new HtmlTextWriter(sw);
            Grid_b2b.RenderControl(htw);
            System.Text.StringBuilder sb1 = new System.Text.StringBuilder();
            sb1 = sb1.Append("<table cellspacing='0' cellpadding='0' width='100 % ' align='center' border='1'>" + sw.ToString() + "</table>");
            sw = null;
            htw = null;
            Response.Write(sb1.ToString());
            sb1.Remove(0, sb1.Length);
            Response.Flush();
            Response.End();
        }
        catch (Exception ex)
        {

        }
    }
    protected void excel_export17(object sender, EventArgs e)
    {
        try
        {

            // Response.Close();
            string date = DateTime.Now.ToString("dd-MM-yyyy--HH-mm");
            var da = new SqlDataAdapter("select c_gst_no as [GST No],c_name as [Customer Name],sl_transaction_type as [Transaction Type],sl_invoice_no as [Invoice ID],sl_invoice_date as [Invoice Date],sl_total as [Total Amount],sl_cess as [Cess],sl_total_taxable as [Taxable Value],sl_total_igst as [IGST],sl_total_cgst as [CGST],sl_total_sgst as [SGST] from tbl_sale inner join tbl_customer on tbl_sale.c_id=tbl_customer.c_id where c_gst_no != '" + string.Empty + "' AND sl_invoice_date between '" + DateTime.Now.Year.ToString()+"-09-01' and '"+DateTime.Now.Year.ToString()+"-09-30' order by sl_id desc ", conn);
            var dt = new DataTable();
            da.Fill(dt);

            Grid_b2b.DataSource = dt;
            Grid_b2b.DataBind();
            Response.Clear();
            Response.Charset = "";
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.ContentType = "application/vnd.xls";
            Response.AddHeader("content-disposition", "attachment;filename=GSTR1 B2B Sep-" + date + ".xls");

            System.IO.StringWriter sw = new System.IO.StringWriter();
            HtmlTextWriter htw = new HtmlTextWriter(sw);
            Grid_b2b.RenderControl(htw);
            System.Text.StringBuilder sb1 = new System.Text.StringBuilder();
            sb1 = sb1.Append("<table cellspacing='0' cellpadding='0' width='100 % ' align='center' border='1'>" + sw.ToString() + "</table>");
            sw = null;
            htw = null;
            Response.Write(sb1.ToString());
            sb1.Remove(0, sb1.Length);
            Response.Flush();
            Response.End();
        }
        catch (Exception ex)
        {

        }
    }
    protected void excel_export18(object sender, EventArgs e)
    {
        try
        {

            // Response.Close();
            string date = DateTime.Now.ToString("dd-MM-yyyy--HH-mm");
            var da = new SqlDataAdapter("select c_gst_no as [GST No],c_name as [Customer Name],sl_transaction_type as [Transaction Type],sl_invoice_no as [Invoice ID],sl_invoice_date as [Invoice Date],sl_total as [Total Amount],sl_cess as [Cess],sl_total_taxable as [Taxable Value],sl_total_igst as [IGST],sl_total_cgst as [CGST],sl_total_sgst as [SGST] from tbl_sale inner join tbl_customer on tbl_sale.c_id=tbl_customer.c_id where c_gst_no = '" + string.Empty + "' AND sl_invoice_date between '" + DateTime.Now.Year.ToString()+"-09-01' and '"+DateTime.Now.Year.ToString()+"-09-30' order by sl_id desc ", conn);
            var dt = new DataTable();
            da.Fill(dt);

            Grid_b2b.DataSource = dt;
            Grid_b2b.DataBind();
            Response.Clear();
            Response.Charset = "";
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.ContentType = "application/vnd.xls";
            Response.AddHeader("content-disposition", "attachment;filename=GSTR1 B2C Sep-" + date + ".xls");

            System.IO.StringWriter sw = new System.IO.StringWriter();
            HtmlTextWriter htw = new HtmlTextWriter(sw);
            Grid_b2b.RenderControl(htw);
            System.Text.StringBuilder sb1 = new System.Text.StringBuilder();
            sb1 = sb1.Append("<table cellspacing='0' cellpadding='0' width='100 % ' align='center' border='1'>" + sw.ToString() + "</table>");
            sw = null;
            htw = null;
            Response.Write(sb1.ToString());
            sb1.Remove(0, sb1.Length);
            Response.Flush();
            Response.End();
        }
        catch (Exception ex)
        {

        }
    }
    protected void excel_export19(object sender, EventArgs e)
    {
        try
        {

            // Response.Close();
            string date = DateTime.Now.ToString("dd-MM-yyyy--HH-mm");
            var da = new SqlDataAdapter("select c_gst_no as [GST No],c_name as [Customer Name],sl_transaction_type as [Transaction Type],sl_invoice_no as [Invoice ID],sl_invoice_date as [Invoice Date],sl_total as [Total Amount],sl_cess as [Cess],sl_total_taxable as [Taxable Value],sl_total_igst as [IGST],sl_total_cgst as [CGST],sl_total_sgst as [SGST] from tbl_sale inner join tbl_customer on tbl_sale.c_id=tbl_customer.c_id where c_gst_no != '" + string.Empty + "' AND sl_invoice_date between '" + DateTime.Now.Year.ToString()+"-10-01' and '"+DateTime.Now.Year.ToString()+"-10-31' order by sl_id desc ", conn);
            var dt = new DataTable();
            da.Fill(dt);

            Grid_b2b.DataSource = dt;
            Grid_b2b.DataBind();
            Response.Clear();
            Response.Charset = "";
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.ContentType = "application/vnd.xls";
            Response.AddHeader("content-disposition", "attachment;filename=GSTR1 B2B Oct-" + date + ".xls");

            System.IO.StringWriter sw = new System.IO.StringWriter();
            HtmlTextWriter htw = new HtmlTextWriter(sw);
            Grid_b2b.RenderControl(htw);
            System.Text.StringBuilder sb1 = new System.Text.StringBuilder();
            sb1 = sb1.Append("<table cellspacing='0' cellpadding='0' width='100 % ' align='center' border='1'>" + sw.ToString() + "</table>");
            sw = null;
            htw = null;
            Response.Write(sb1.ToString());
            sb1.Remove(0, sb1.Length);
            Response.Flush();
            Response.End();
        }
        catch (Exception ex)
        {

        }
    }
    protected void excel_export20(object sender, EventArgs e)
    {
        try
        {

            // Response.Close();
            string date = DateTime.Now.ToString("dd-MM-yyyy--HH-mm");
            var da = new SqlDataAdapter("select c_gst_no as [GST No],c_name as [Customer Name],sl_transaction_type as [Transaction Type],sl_invoice_no as [Invoice ID],sl_invoice_date as [Invoice Date],sl_total as [Total Amount],sl_cess as [Cess],sl_total_taxable as [Taxable Value],sl_total_igst as [IGST],sl_total_cgst as [CGST],sl_total_sgst as [SGST] from tbl_sale inner join tbl_customer on tbl_sale.c_id=tbl_customer.c_id where c_gst_no = '" + string.Empty + "' AND sl_invoice_date between '" + DateTime.Now.Year.ToString()+"-10-01' and '"+DateTime.Now.Year.ToString()+"-10-31' order by sl_id desc ", conn);
            var dt = new DataTable();
            da.Fill(dt);

            Grid_b2b.DataSource = dt;
            Grid_b2b.DataBind();
            Response.Clear();
            Response.Charset = "";
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.ContentType = "application/vnd.xls";
            Response.AddHeader("content-disposition", "attachment;filename=GSTR1 B2C Oct-" + date + ".xls");

            System.IO.StringWriter sw = new System.IO.StringWriter();
            HtmlTextWriter htw = new HtmlTextWriter(sw);
            Grid_b2b.RenderControl(htw);
            System.Text.StringBuilder sb1 = new System.Text.StringBuilder();
            sb1 = sb1.Append("<table cellspacing='0' cellpadding='0' width='100 % ' align='center' border='1'>" + sw.ToString() + "</table>");
            sw = null;
            htw = null;
            Response.Write(sb1.ToString());
            sb1.Remove(0, sb1.Length);
            Response.Flush();
            Response.End();
        }
        catch (Exception ex)
        {

        }
    }
    protected void excel_export21(object sender, EventArgs e)
    {
        try
        {

            // Response.Close();
            string date = DateTime.Now.ToString("dd-MM-yyyy--HH-mm");
            var da = new SqlDataAdapter("select c_gst_no as [GST No],c_name as [Customer Name],sl_transaction_type as [Transaction Type],sl_invoice_no as [Invoice ID],sl_invoice_date as [Invoice Date],sl_total as [Total Amount],sl_cess as [Cess],sl_total_taxable as [Taxable Value],sl_total_igst as [IGST],sl_total_cgst as [CGST],sl_total_sgst as [SGST] from tbl_sale inner join tbl_customer on tbl_sale.c_id=tbl_customer.c_id where c_gst_no != '" + string.Empty + "' AND sl_invoice_date between '" + DateTime.Now.Year.ToString()+"-11-01' and '"+DateTime.Now.Year.ToString()+"-11-30' order by sl_id desc ", conn);
            var dt = new DataTable();
            da.Fill(dt);

            Grid_b2b.DataSource = dt;
            Grid_b2b.DataBind();
            Response.Clear();
            Response.Charset = "";
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.ContentType = "application/vnd.xls";
            Response.AddHeader("content-disposition", "attachment;filename=GSTR1 B2B Nov-" + date + ".xls");

            System.IO.StringWriter sw = new System.IO.StringWriter();
            HtmlTextWriter htw = new HtmlTextWriter(sw);
            Grid_b2b.RenderControl(htw);
            System.Text.StringBuilder sb1 = new System.Text.StringBuilder();
            sb1 = sb1.Append("<table cellspacing='0' cellpadding='0' width='100 % ' align='center' border='1'>" + sw.ToString() + "</table>");
            sw = null;
            htw = null;
            Response.Write(sb1.ToString());
            sb1.Remove(0, sb1.Length);
            Response.Flush();
            Response.End();
        }
        catch (Exception ex)
        {

        }
    }
    protected void excel_export22(object sender, EventArgs e)
    {
        try
        {

            // Response.Close();
            string date = DateTime.Now.ToString("dd-MM-yyyy--HH-mm");
            var da = new SqlDataAdapter("select c_gst_no as [GST No],c_name as [Customer Name],sl_transaction_type as [Transaction Type],sl_invoice_no as [Invoice ID],sl_invoice_date as [Invoice Date],sl_total as [Total Amount],sl_cess as [Cess],sl_total_taxable as [Taxable Value],sl_total_igst as [IGST],sl_total_cgst as [CGST],sl_total_sgst as [SGST] from tbl_sale inner join tbl_customer on tbl_sale.c_id=tbl_customer.c_id where c_gst_no = '" + string.Empty + "' AND sl_invoice_date between '" + DateTime.Now.Year.ToString()+"-11-01' and '"+DateTime.Now.Year.ToString()+"-11-30' order by sl_id desc ", conn);
            var dt = new DataTable();
            da.Fill(dt);

            Grid_b2b.DataSource = dt;
            Grid_b2b.DataBind();
            Response.Clear();
            Response.Charset = "";
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.ContentType = "application/vnd.xls";
            Response.AddHeader("content-disposition", "attachment;filename=GSTR1 B2C Nov-" + date + ".xls");

            System.IO.StringWriter sw = new System.IO.StringWriter();
            HtmlTextWriter htw = new HtmlTextWriter(sw);
            Grid_b2b.RenderControl(htw);
            System.Text.StringBuilder sb1 = new System.Text.StringBuilder();
            sb1 = sb1.Append("<table cellspacing='0' cellpadding='0' width='100 % ' align='center' border='1'>" + sw.ToString() + "</table>");
            sw = null;
            htw = null;
            Response.Write(sb1.ToString());
            sb1.Remove(0, sb1.Length);
            Response.Flush();
            Response.End();
        }
        catch (Exception ex)
        {

        }
    }
    protected void excel_export23(object sender, EventArgs e)
    {
        try
        {

            // Response.Close();
            string date = DateTime.Now.ToString("dd-MM-yyyy--HH-mm");
            var da = new SqlDataAdapter("select c_gst_no as [GST No],c_name as [Customer Name],sl_transaction_type as [Transaction Type],sl_invoice_no as [Invoice ID],sl_invoice_date as [Invoice Date],sl_total as [Total Amount],sl_cess as [Cess],sl_total_taxable as [Taxable Value],sl_total_igst as [IGST],sl_total_cgst as [CGST],sl_total_sgst as [SGST] from tbl_sale inner join tbl_customer on tbl_sale.c_id=tbl_customer.c_id where c_gst_no != '" + string.Empty + "' AND sl_invoice_date between '" + DateTime.Now.Year.ToString()+"-12-01' and '"+DateTime.Now.Year.ToString()+"-12-31' order by sl_id desc ", conn);
            var dt = new DataTable();
            da.Fill(dt);

            Grid_b2b.DataSource = dt;
            Grid_b2b.DataBind();
            Response.Clear();
            Response.Charset = "";
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.ContentType = "application/vnd.xls";
            Response.AddHeader("content-disposition", "attachment;filename=GSTR1 B2B Dec-" + date + ".xls");

            System.IO.StringWriter sw = new System.IO.StringWriter();
            HtmlTextWriter htw = new HtmlTextWriter(sw);
            Grid_b2b.RenderControl(htw);
            System.Text.StringBuilder sb1 = new System.Text.StringBuilder();
            sb1 = sb1.Append("<table cellspacing='0' cellpadding='0' width='100 % ' align='center' border='1'>" + sw.ToString() + "</table>");
            sw = null;
            htw = null;
            Response.Write(sb1.ToString());
            sb1.Remove(0, sb1.Length);
            Response.Flush();
            Response.End();
        }
        catch (Exception ex)
        {

        }
    }
    protected void excel_export24(object sender, EventArgs e)
    {
        try
        {

            // Response.Close();
            string date = DateTime.Now.ToString("dd-MM-yyyy--HH-mm");
            var da = new SqlDataAdapter("select c_gst_no as [GST No],c_name as [Customer Name],sl_transaction_type as [Transaction Type],sl_invoice_no as [Invoice ID],sl_invoice_date as [Invoice Date],sl_total as [Total Amount],sl_cess as [Cess],sl_total_taxable as [Taxable Value],sl_total_igst as [IGST],sl_total_cgst as [CGST],sl_total_sgst as [SGST] from tbl_sale inner join tbl_customer on tbl_sale.c_id=tbl_customer.c_id where c_gst_no = '" + string.Empty + "' AND sl_invoice_date between '" + DateTime.Now.Year.ToString()+"-12-01' and '"+DateTime.Now.Year.ToString()+"-12-31' order by sl_id desc ", conn);
            var dt = new DataTable();
            da.Fill(dt);

            Grid_b2b.DataSource = dt;
            Grid_b2b.DataBind();
            Response.Clear();
            Response.Charset = "";
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.ContentType = "application/vnd.xls";
            Response.AddHeader("content-disposition", "attachment;filename=GSTR1 B2C Dec-" + date + ".xls");

            System.IO.StringWriter sw = new System.IO.StringWriter();
            HtmlTextWriter htw = new HtmlTextWriter(sw);
            Grid_b2b.RenderControl(htw);
            System.Text.StringBuilder sb1 = new System.Text.StringBuilder();
            sb1 = sb1.Append("<table cellspacing='0' cellpadding='0' width='100 % ' align='center' border='1'>" + sw.ToString() + "</table>");
            sw = null;
            htw = null;
            Response.Write(sb1.ToString());
            sb1.Remove(0, sb1.Length);
            Response.Flush();
            Response.End();
        }
        catch (Exception ex)
        {

        }
    }



    public override void VerifyRenderingInServerForm(Control control)
    {
        /* Verifies that the control is rendered */
    }
}