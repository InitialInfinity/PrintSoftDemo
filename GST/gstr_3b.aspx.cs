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

public partial class GST_gstr_3b : System.Web.UI.Page
{
    SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["String"].ConnectionString);
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["a_email"] != null)
        {
            jan();
            feb();
            march();
            april();
            may();
            june();
            july();
            aug();
            sep();
            oct();
            nov();
            dec();
        }
        else
        {
            Response.Redirect("../login.aspx");
        }
    }

    protected void jan()
    {
        SqlCommand cmd1 = new SqlCommand("select sum(s_stotal),sum(s_igsta),sum(s_cgsta),sum(s_sgsta) from tbl_sale_invoice where s_invoice_date between '"+DateTime.Now.Year.ToString()+"-01-01' and '"+DateTime.Now.Year.ToString()+"-01-31'", conn);
        SqlDataAdapter adapt1 = new SqlDataAdapter(cmd1);
        DataTable dt1 = new DataTable();
        adapt1.Fill(dt1);
        if(dt1.Rows.Count>0)
        {
            lbl_s_total_taxable.Text = dt1.Rows[0][0].ToString();
            lbl_s_igst.Text = dt1.Rows[0][1].ToString();
            lbl_s_cgst.Text = dt1.Rows[0][2].ToString();
            lbl_s_sgst.Text = dt1.Rows[0][3].ToString();
        }
        if (lbl_s_total_taxable.Text == string.Empty)
        {
            lbl_s_total_taxable.Text = "0";
            
        }
        if (lbl_s_igst.Text == string.Empty)
        {
            lbl_s_igst.Text = "0";

        }
        if (lbl_s_cgst.Text == string.Empty)
        {
            lbl_s_cgst.Text = "0";

        }
        if (lbl_s_sgst.Text == string.Empty)
        {
            lbl_s_sgst.Text = "0";

        }


        SqlCommand cmd2 = new SqlCommand("select sum(pc_stotal),sum(pc_igsta),sum(pc_cgsta),sum(pc_sgsta) from tbl_purchase_invoice where pc_invoice_date between '"+DateTime.Now.Year.ToString()+"-01-01' and '"+DateTime.Now.Year.ToString()+"-01-31'", conn);
        SqlDataAdapter adapt2 = new SqlDataAdapter(cmd2);
        DataTable dt2 = new DataTable();
        adapt2.Fill(dt2);
        if (dt2.Rows.Count > 0)
        {
            
            lbl_p_igst.Text = dt2.Rows[0][1].ToString();
            lbl_p_cgst.Text = dt2.Rows[0][2].ToString();
            lbl_p_sgst.Text = dt2.Rows[0][3].ToString();
        }
        if (lbl_p_igst.Text == string.Empty)
        {
            lbl_p_igst.Text = "0";

        }
        if (lbl_p_cgst.Text == string.Empty)
        {
            lbl_p_cgst.Text = "0";

        }
        if (lbl_p_sgst.Text == string.Empty)
        {
            lbl_p_sgst.Text = "0";

        }

    }

    protected void feb()
    {
        SqlCommand cmd3 = new SqlCommand("select sum(s_stotal),sum(s_igsta),sum(s_cgsta),sum(s_sgsta) from tbl_sale_invoice where s_invoice_date between '"+DateTime.Now.Year.ToString()+"-02-01' and '"+DateTime.Now.Year.ToString()+"-02-28'", conn);
        SqlDataAdapter adapt3 = new SqlDataAdapter(cmd3);
        DataTable dt3 = new DataTable();
        adapt3.Fill(dt3);
        if (dt3.Rows.Count > 0)
        {
            lbl_s2_total_taxable.Text = dt3.Rows[0][0].ToString();
            lbl_s2_igst.Text = dt3.Rows[0][1].ToString();
            lbl_s2_cgst.Text = dt3.Rows[0][2].ToString();
            lbl_s2_sgst.Text = dt3.Rows[0][3].ToString();
        }
        if (lbl_s2_total_taxable.Text == string.Empty)
        {
            lbl_s2_total_taxable.Text = "0";

        }
        if (lbl_s2_igst.Text == string.Empty)
        {
            lbl_s2_igst.Text = "0";

        }
        if (lbl_s2_cgst.Text == string.Empty)
        {
            lbl_s2_cgst.Text = "0";

        }
        if (lbl_s2_sgst.Text == string.Empty)
        {
            lbl_s2_sgst.Text = "0";

        }


        SqlCommand cmd4 = new SqlCommand("select sum(pc_stotal),sum(pc_igsta),sum(pc_cgsta),sum(pc_sgsta) from tbl_purchase_invoice where pc_invoice_date between '"+DateTime.Now.Year.ToString()+"-02-01' and '"+DateTime.Now.Year.ToString()+"-02-28'", conn);
        SqlDataAdapter adapt4 = new SqlDataAdapter(cmd4);
        DataTable dt4 = new DataTable();
        adapt4.Fill(dt4);
        if (dt4.Rows.Count > 0)
        {

            lbl_p2_igst.Text = dt4.Rows[0][1].ToString();
            lbl_p2_cgst.Text = dt4.Rows[0][2].ToString();
            lbl_p2_sgst.Text = dt4.Rows[0][3].ToString();
        }
        if (lbl_p2_igst.Text == string.Empty)
        {
            lbl_p2_igst.Text = "0";

        }
        if (lbl_p2_cgst.Text == string.Empty)
        {
            lbl_p2_cgst.Text = "0";

        }
        if (lbl_p2_sgst.Text == string.Empty)
        {
            lbl_p2_sgst.Text = "0";

        }
    }

    protected void march()
    {
        SqlCommand cmd5 = new SqlCommand("select sum(s_stotal),sum(s_igsta),sum(s_cgsta),sum(s_sgsta) from tbl_sale_invoice where s_invoice_date between '"+DateTime.Now.Year.ToString()+"-03-01' and '"+DateTime.Now.Year.ToString()+"-03-31'", conn);
        SqlDataAdapter adapt5 = new SqlDataAdapter(cmd5);
        DataTable dt5 = new DataTable();
        adapt5.Fill(dt5);
        if (dt5.Rows.Count > 0)
        {
            lbl_s3_total_taxable.Text = dt5.Rows[0][0].ToString();
            lbl_s3_igst.Text = dt5.Rows[0][1].ToString();
            lbl_s3_cgst.Text = dt5.Rows[0][2].ToString();
            lbl_s3_sgst.Text = dt5.Rows[0][3].ToString();
        }
        if (lbl_s3_total_taxable.Text == string.Empty)
        {
            lbl_s3_total_taxable.Text = "0";

        }
        if (lbl_s3_igst.Text == string.Empty)
        {
            lbl_s3_igst.Text = "0";

        }
        if (lbl_s3_cgst.Text == string.Empty)
        {
            lbl_s3_cgst.Text = "0";

        }
        if (lbl_s3_sgst.Text == string.Empty)
        {
            lbl_s3_sgst.Text = "0";

        }


        SqlCommand cmd6 = new SqlCommand("select sum(pc_stotal),sum(pc_igsta),sum(pc_cgsta),sum(pc_sgsta) from tbl_purchase_invoice where pc_invoice_date between '"+DateTime.Now.Year.ToString()+"-03-01' and '"+DateTime.Now.Year.ToString()+"-03-31'", conn);
        SqlDataAdapter adapt6 = new SqlDataAdapter(cmd6);
        DataTable dt6 = new DataTable();
        adapt6.Fill(dt6);
        if (dt6.Rows.Count > 0)
        {

            lbl_p3_igst.Text = dt6.Rows[0][1].ToString();
            lbl_p3_cgst.Text = dt6.Rows[0][2].ToString();
            lbl_p3_sgst.Text = dt6.Rows[0][3].ToString();
        }
        if (lbl_p3_igst.Text == string.Empty)
        {
            lbl_p3_igst.Text = "0";

        }
        if (lbl_p3_cgst.Text == string.Empty)
        {
            lbl_p3_cgst.Text = "0";

        }
        if (lbl_p3_sgst.Text == string.Empty)
        {
            lbl_p3_sgst.Text = "0";

        }
    }

    protected void april()
    {
        SqlCommand cmd7 = new SqlCommand("select sum(s_stotal),sum(s_igsta),sum(s_cgsta),sum(s_sgsta) from tbl_sale_invoice where s_invoice_date between '"+DateTime.Now.Year.ToString()+"-04-01' and '"+DateTime.Now.Year.ToString()+"-04-30'", conn);
        SqlDataAdapter adapt7 = new SqlDataAdapter(cmd7);
        DataTable dt7 = new DataTable();
        adapt7.Fill(dt7);
        if (dt7.Rows.Count > 0)
        {
            lbl_s4_total_taxable.Text = dt7.Rows[0][0].ToString();
            lbl_s4_igst.Text = dt7.Rows[0][1].ToString();
            lbl_s4_cgst.Text = dt7.Rows[0][2].ToString();
            lbl_s4_sgst.Text = dt7.Rows[0][3].ToString();
        }
        if (lbl_s4_total_taxable.Text == string.Empty)
        {
            lbl_s4_total_taxable.Text = "0";

        }
        if (lbl_s4_igst.Text == string.Empty)
        {
            lbl_s4_igst.Text = "0";

        }
        if (lbl_s4_cgst.Text == string.Empty)
        {
            lbl_s4_cgst.Text = "0";

        }
        if (lbl_s4_sgst.Text == string.Empty)
        {
            lbl_s4_sgst.Text = "0";

        }


        SqlCommand cmd8 = new SqlCommand("select sum(pc_stotal),sum(pc_igsta),sum(pc_cgsta),sum(pc_sgsta) from tbl_purchase_invoice where pc_invoice_date between '"+DateTime.Now.Year.ToString()+"-04-01' and '"+DateTime.Now.Year.ToString()+"-04-30'", conn);
        SqlDataAdapter adapt8 = new SqlDataAdapter(cmd8);
        DataTable dt8 = new DataTable();
        adapt8.Fill(dt8);
        if (dt8.Rows.Count > 0)
        {

            lbl_p4_igst.Text = dt8.Rows[0][1].ToString();
            lbl_p4_cgst.Text = dt8.Rows[0][2].ToString();
            lbl_p4_sgst.Text = dt8.Rows[0][3].ToString();
        }
        if (lbl_p4_igst.Text == string.Empty)
        {
            lbl_p4_igst.Text = "0";

        }
        if (lbl_p4_cgst.Text == string.Empty)
        {
            lbl_p4_cgst.Text = "0";

        }
        if (lbl_p4_sgst.Text == string.Empty)
        {
            lbl_p4_sgst.Text = "0";

        }
    }

    protected void may()
    {
        SqlCommand cmd9 = new SqlCommand("select sum(s_stotal),sum(s_igsta),sum(s_cgsta),sum(s_sgsta) from tbl_sale_invoice where s_invoice_date between '"+DateTime.Now.Year.ToString()+"-05-01' and '"+DateTime.Now.Year.ToString()+"-05-31'", conn);
        SqlDataAdapter adapt9 = new SqlDataAdapter(cmd9);
        DataTable dt9 = new DataTable();
        adapt9.Fill(dt9);
        if (dt9.Rows.Count > 0)
        {
            lbl_s5_total_taxable.Text = dt9.Rows[0][0].ToString();
            lbl_s5_igst.Text = dt9.Rows[0][1].ToString();
            lbl_s5_cgst.Text = dt9.Rows[0][2].ToString();
            lbl_s5_sgst.Text = dt9.Rows[0][3].ToString();
        }
        if (lbl_s5_total_taxable.Text == string.Empty)
        {
            lbl_s5_total_taxable.Text = "0";

        }
        if (lbl_s5_igst.Text == string.Empty)
        {
            lbl_s5_igst.Text = "0";

        }
        if (lbl_s5_cgst.Text == string.Empty)
        {
            lbl_s5_cgst.Text = "0";

        }
        if (lbl_s5_sgst.Text == string.Empty)
        {
            lbl_s5_sgst.Text = "0";

        }


        SqlCommand cmd10 = new SqlCommand("select sum(pc_stotal),sum(pc_igsta),sum(pc_cgsta),sum(pc_sgsta) from tbl_purchase_invoice where pc_invoice_date between '"+DateTime.Now.Year.ToString()+"-05-01' and '"+DateTime.Now.Year.ToString()+"-05-31'", conn);
        SqlDataAdapter adapt10 = new SqlDataAdapter(cmd10);
        DataTable dt10 = new DataTable();
        adapt10.Fill(dt10);
        if (dt10.Rows.Count > 0)
        {

            lbl_p5_igst.Text = dt10.Rows[0][1].ToString();
            lbl_p5_cgst.Text = dt10.Rows[0][2].ToString();
            lbl_p5_sgst.Text = dt10.Rows[0][3].ToString();
        }
        if (lbl_p5_igst.Text == string.Empty)
        {
            lbl_p5_igst.Text = "0";

        }
        if (lbl_p5_cgst.Text == string.Empty)
        {
            lbl_p5_cgst.Text = "0";

        }
        if (lbl_p5_sgst.Text == string.Empty)
        {
            lbl_p5_sgst.Text = "0";

        }
    }

    protected void june()
    {
        SqlCommand cmd11 = new SqlCommand("select sum(s_stotal),sum(s_igsta),sum(s_cgsta),sum(s_sgsta) from tbl_sale_invoice where s_invoice_date between '"+DateTime.Now.Year.ToString()+"-06-01' and '"+DateTime.Now.Year.ToString()+"-06-30'", conn);
        SqlDataAdapter adapt11 = new SqlDataAdapter(cmd11);
        DataTable dt11 = new DataTable();
        adapt11.Fill(dt11);
        if (dt11.Rows.Count > 0)
        {
            lbl_s6_total_taxable.Text = dt11.Rows[0][0].ToString();
            lbl_s6_igst.Text = dt11.Rows[0][1].ToString();
            lbl_s6_cgst.Text = dt11.Rows[0][2].ToString();
            lbl_s6_sgst.Text = dt11.Rows[0][3].ToString();
        }
        if (lbl_s6_total_taxable.Text == string.Empty)
        {
            lbl_s6_total_taxable.Text = "0";

        }
        if (lbl_s6_igst.Text == string.Empty)
        {
            lbl_s6_igst.Text = "0";

        }
        if (lbl_s6_cgst.Text == string.Empty)
        {
            lbl_s6_cgst.Text = "0";

        }
        if (lbl_s6_sgst.Text == string.Empty)
        {
            lbl_s6_sgst.Text = "0";

        }


        SqlCommand cmd12 = new SqlCommand("select sum(pc_stotal),sum(pc_igsta),sum(pc_cgsta),sum(pc_sgsta) from tbl_purchase_invoice where pc_invoice_date between '"+DateTime.Now.Year.ToString()+"-06-01' and '"+DateTime.Now.Year.ToString()+"-06-30'", conn);
        SqlDataAdapter adapt12 = new SqlDataAdapter(cmd12);
        DataTable dt12 = new DataTable();
        adapt12.Fill(dt12);
        if (dt12.Rows.Count > 0)
        {

            lbl_p6_igst.Text = dt12.Rows[0][1].ToString();
            lbl_p6_cgst.Text = dt12.Rows[0][2].ToString();
            lbl_p6_sgst.Text = dt12.Rows[0][3].ToString();
        }
        if (lbl_p6_igst.Text == string.Empty)
        {
            lbl_p6_igst.Text = "0";

        }
        if (lbl_p6_cgst.Text == string.Empty)
        {
            lbl_p6_cgst.Text = "0";

        }
        if (lbl_p6_sgst.Text == string.Empty)
        {
            lbl_p6_sgst.Text = "0";

        }
    }

    protected void july()
    {
        SqlCommand cmd13 = new SqlCommand("select sum(s_stotal),sum(s_igsta),sum(s_cgsta),sum(s_sgsta) from tbl_sale_invoice where s_invoice_date between '"+DateTime.Now.Year.ToString()+"-07-01' and '"+DateTime.Now.Year.ToString()+"-07-31'", conn);
        SqlDataAdapter adapt13 = new SqlDataAdapter(cmd13);
        DataTable dt13 = new DataTable();
        adapt13.Fill(dt13);
        if (dt13.Rows.Count > 0)
        {
            lbl_s7_total_taxable.Text = dt13.Rows[0][0].ToString();
            lbl_s7_igst.Text = dt13.Rows[0][1].ToString();
            lbl_s7_cgst.Text = dt13.Rows[0][2].ToString();
            lbl_s7_sgst.Text = dt13.Rows[0][3].ToString();
        }
        if (lbl_s7_total_taxable.Text == string.Empty)
        {
            lbl_s7_total_taxable.Text = "0";

        }
        if (lbl_s7_igst.Text == string.Empty)
        {
            lbl_s7_igst.Text = "0";

        }
        if (lbl_s7_cgst.Text == string.Empty)
        {
            lbl_s7_cgst.Text = "0";

        }
        if (lbl_s7_sgst.Text == string.Empty)
        {
            lbl_s7_sgst.Text = "0";

        }


        SqlCommand cmd14 = new SqlCommand("select sum(pc_stotal),sum(pc_igsta),sum(pc_cgsta),sum(pc_sgsta) from tbl_purchase_invoice where pc_invoice_date between '"+DateTime.Now.Year.ToString()+"-07-01' and '"+DateTime.Now.Year.ToString()+"-07-31'", conn);
        SqlDataAdapter adapt14 = new SqlDataAdapter(cmd14);
        DataTable dt14 = new DataTable();
        adapt14.Fill(dt14);
        if (dt14.Rows.Count > 0)
        {

            lbl_p7_igst.Text = dt14.Rows[0][1].ToString();
            lbl_p7_cgst.Text = dt14.Rows[0][2].ToString();
            lbl_p7_sgst.Text = dt14.Rows[0][3].ToString();
        }
        if (lbl_p7_igst.Text == string.Empty)
        {
            lbl_p7_igst.Text = "0";

        }
        if (lbl_p7_cgst.Text == string.Empty)
        {
            lbl_p7_cgst.Text = "0";

        }
        if (lbl_p7_sgst.Text == string.Empty)
        {
            lbl_p7_sgst.Text = "0";

        }
    }

    protected void aug()
    {
        SqlCommand cmd15 = new SqlCommand("select sum(s_stotal),sum(s_igsta),sum(s_cgsta),sum(s_sgsta) from tbl_sale_invoice where s_invoice_date between '"+DateTime.Now.Year.ToString()+"-08-01' and '"+DateTime.Now.Year.ToString()+"-08-31'", conn);
        SqlDataAdapter adapt15 = new SqlDataAdapter(cmd15);
        DataTable dt15 = new DataTable();
        adapt15.Fill(dt15);
        if (dt15.Rows.Count > 0)
        {
            lbl_s8_total_taxable.Text = dt15.Rows[0][0].ToString();
            lbl_s8_igst.Text = dt15.Rows[0][1].ToString();
            lbl_s8_cgst.Text = dt15.Rows[0][2].ToString();
            lbl_s8_sgst.Text = dt15.Rows[0][3].ToString();
        }
        if (lbl_s8_total_taxable.Text == string.Empty)
        {
            lbl_s8_total_taxable.Text = "0";

        }
        if (lbl_s8_igst.Text == string.Empty)
        {
            lbl_s8_igst.Text = "0";

        }
        if (lbl_s8_cgst.Text == string.Empty)
        {
            lbl_s8_cgst.Text = "0";

        }
        if (lbl_s8_sgst.Text == string.Empty)
        {
            lbl_s8_sgst.Text = "0";

        }


        SqlCommand cmd16 = new SqlCommand("select sum(pc_stotal),sum(pc_igsta),sum(pc_cgsta),sum(pc_sgsta) from tbl_purchase_invoice where pc_invoice_date between '"+DateTime.Now.Year.ToString()+"-08-01' and '"+DateTime.Now.Year.ToString()+"-08-31'", conn);
        SqlDataAdapter adapt16 = new SqlDataAdapter(cmd16);
        DataTable dt16 = new DataTable();
        adapt16.Fill(dt16);
        if (dt16.Rows.Count > 0)
        {

            lbl_p8_igst.Text = dt16.Rows[0][1].ToString();
            lbl_p8_cgst.Text = dt16.Rows[0][2].ToString();
            lbl_p8_sgst.Text = dt16.Rows[0][3].ToString();
        }
        if (lbl_p8_igst.Text == string.Empty)
        {
            lbl_p8_igst.Text = "0";

        }
        if (lbl_p8_cgst.Text == string.Empty)
        {
            lbl_p8_cgst.Text = "0";

        }
        if (lbl_p8_sgst.Text == string.Empty)
        {
            lbl_p8_sgst.Text = "0";

        }
    }

    protected void sep()
    {
        SqlCommand cmd17 = new SqlCommand("select sum(s_stotal),sum(s_igsta),sum(s_cgsta),sum(s_sgsta) from tbl_sale_invoice where s_invoice_date between '"+DateTime.Now.Year.ToString()+"-09-01' and '"+DateTime.Now.Year.ToString()+"-09-30'", conn);
        SqlDataAdapter adapt17 = new SqlDataAdapter(cmd17);
        DataTable dt17 = new DataTable();
        adapt17.Fill(dt17);
        if (dt17.Rows.Count > 0)
        {
            lbl_s9_total_taxable.Text = dt17.Rows[0][0].ToString();
            lbl_s9_igst.Text = dt17.Rows[0][1].ToString();
            lbl_s9_cgst.Text = dt17.Rows[0][2].ToString();
            lbl_s9_sgst.Text = dt17.Rows[0][3].ToString();
        }
        if (lbl_s9_total_taxable.Text == string.Empty)
        {
            lbl_s9_total_taxable.Text = "0";

        }
        if (lbl_s9_igst.Text == string.Empty)
        {
            lbl_s9_igst.Text = "0";

        }
        if (lbl_s9_cgst.Text == string.Empty)
        {
            lbl_s9_cgst.Text = "0";

        }
        if (lbl_s9_sgst.Text == string.Empty)
        {
            lbl_s9_sgst.Text = "0";

        }


        SqlCommand cmd18 = new SqlCommand("select sum(pc_stotal),sum(pc_igsta),sum(pc_cgsta),sum(pc_sgsta) from tbl_purchase_invoice where pc_invoice_date between '"+DateTime.Now.Year.ToString()+"-09-01' and '"+DateTime.Now.Year.ToString()+"-09-30'", conn);
        SqlDataAdapter adapt18 = new SqlDataAdapter(cmd18);
        DataTable dt18 = new DataTable();
        adapt18.Fill(dt18);
        if (dt18.Rows.Count > 0)
        {

            lbl_p9_igst.Text = dt18.Rows[0][1].ToString();
            lbl_p9_cgst.Text = dt18.Rows[0][2].ToString();
            lbl_p9_sgst.Text = dt18.Rows[0][3].ToString();
        }
        if (lbl_p9_igst.Text == string.Empty)
        {
            lbl_p9_igst.Text = "0";

        }
        if (lbl_p9_cgst.Text == string.Empty)
        {
            lbl_p9_cgst.Text = "0";

        }
        if (lbl_p9_sgst.Text == string.Empty)
        {
            lbl_p9_sgst.Text = "0";

        }
    }

    protected void oct()
    {
        SqlCommand cmd19 = new SqlCommand("select sum(s_stotal),sum(s_igsta),sum(s_cgsta),sum(s_sgsta) from tbl_sale_invoice where s_invoice_date between '"+DateTime.Now.Year.ToString()+"-10-01' and '"+DateTime.Now.Year.ToString()+"-10-31'", conn);
        SqlDataAdapter adapt19 = new SqlDataAdapter(cmd19);
        DataTable dt19 = new DataTable();
        adapt19.Fill(dt19);
        if (dt19.Rows.Count > 0)
        {
            lbl_s10_total_taxable.Text = dt19.Rows[0][0].ToString();
            lbl_s10_igst.Text = dt19.Rows[0][1].ToString();
            lbl_s10_cgst.Text = dt19.Rows[0][2].ToString();
            lbl_s10_sgst.Text = dt19.Rows[0][3].ToString();
        }
        if (lbl_s10_total_taxable.Text == string.Empty)
        {
            lbl_s10_total_taxable.Text = "0";

        }
        if (lbl_s10_igst.Text == string.Empty)
        {
            lbl_s10_igst.Text = "0";

        }
        if (lbl_s10_cgst.Text == string.Empty)
        {
            lbl_s10_cgst.Text = "0";

        }
        if (lbl_s10_sgst.Text == string.Empty)
        {
            lbl_s10_sgst.Text = "0";

        }


        SqlCommand cmd20 = new SqlCommand("select sum(pc_stotal),sum(pc_igsta),sum(pc_cgsta),sum(pc_sgsta) from tbl_purchase_invoice where pc_invoice_date between '"+DateTime.Now.Year.ToString()+"-10-01' and '"+DateTime.Now.Year.ToString()+"-10-31'", conn);
        SqlDataAdapter adapt20 = new SqlDataAdapter(cmd20);
        DataTable dt20 = new DataTable();
        adapt20.Fill(dt20);
        if (dt20.Rows.Count > 0)
        {

            lbl_p10_igst.Text = dt20.Rows[0][1].ToString();
            lbl_p10_cgst.Text = dt20.Rows[0][2].ToString();
            lbl_p10_sgst.Text = dt20.Rows[0][3].ToString();
        }
        if (lbl_p10_igst.Text == string.Empty)
        {
            lbl_p10_igst.Text = "0";

        }
        if (lbl_p10_cgst.Text == string.Empty)
        {
            lbl_p10_cgst.Text = "0";

        }
        if (lbl_p10_sgst.Text == string.Empty)
        {
            lbl_p10_sgst.Text = "0";

        }
    }

    protected void nov()
    {
        SqlCommand cmd21 = new SqlCommand("select sum(s_stotal),sum(s_igsta),sum(s_cgsta),sum(s_sgsta) from tbl_sale_invoice where s_invoice_date between '"+DateTime.Now.Year.ToString()+"-11-01' and '"+DateTime.Now.Year.ToString()+"-11-30'", conn);
        SqlDataAdapter adapt21 = new SqlDataAdapter(cmd21);
        DataTable dt21 = new DataTable();
        adapt21.Fill(dt21);
        if (dt21.Rows.Count > 0)
        {
            lbl_s11_total_taxable.Text = dt21.Rows[0][0].ToString();
            lbl_s11_igst.Text = dt21.Rows[0][1].ToString();
            lbl_s11_cgst.Text = dt21.Rows[0][2].ToString();
            lbl_s11_sgst.Text = dt21.Rows[0][3].ToString();
        }
        if (lbl_s11_total_taxable.Text == string.Empty)
        {
            lbl_s11_total_taxable.Text = "0";

        }
        if (lbl_s11_igst.Text == string.Empty)
        {
            lbl_s11_igst.Text = "0";

        }
        if (lbl_s11_cgst.Text == string.Empty)
        {
            lbl_s11_cgst.Text = "0";

        }
        if (lbl_s11_sgst.Text == string.Empty)
        {
            lbl_s11_sgst.Text = "0";

        }


        SqlCommand cmd22 = new SqlCommand("select sum(pc_stotal),sum(pc_igsta),sum(pc_cgsta),sum(pc_sgsta) from tbl_purchase_invoice where pc_invoice_date between '"+DateTime.Now.Year.ToString()+"-11-01' and '"+DateTime.Now.Year.ToString()+"-11-30'", conn);
        SqlDataAdapter adapt22 = new SqlDataAdapter(cmd22);
        DataTable dt22 = new DataTable();
        adapt22.Fill(dt22);
        if (dt22.Rows.Count > 0)
        {

            lbl_p11_igst.Text = dt22.Rows[0][1].ToString();
            lbl_p11_cgst.Text = dt22.Rows[0][2].ToString();
            lbl_p11_sgst.Text = dt22.Rows[0][3].ToString();
        }
        if (lbl_p11_igst.Text == string.Empty)
        {
            lbl_p11_igst.Text = "0";

        }
        if (lbl_p11_cgst.Text == string.Empty)
        {
            lbl_p11_cgst.Text = "0";

        }
        if (lbl_p11_sgst.Text == string.Empty)
        {
            lbl_p11_sgst.Text = "0";

        }
    }

    protected void dec()
    {
        SqlCommand cmd23 = new SqlCommand("select sum(s_stotal),sum(s_igsta),sum(s_cgsta),sum(s_sgsta) from tbl_sale_invoice where s_invoice_date between '"+DateTime.Now.Year.ToString()+"-12-01' and '"+DateTime.Now.Year.ToString()+"-12-31'", conn);
        SqlDataAdapter adapt23 = new SqlDataAdapter(cmd23);
        DataTable dt23 = new DataTable();
        adapt23.Fill(dt23);
        if (dt23.Rows.Count > 0)
        {
            lbl_s12_total_taxable.Text = dt23.Rows[0][0].ToString();
            lbl_s12_igst.Text = dt23.Rows[0][1].ToString();
            lbl_s12_cgst.Text = dt23.Rows[0][2].ToString();
            lbl_s12_sgst.Text = dt23.Rows[0][3].ToString();
        }
        if (lbl_s12_total_taxable.Text == string.Empty)
        {
            lbl_s12_total_taxable.Text = "0";

        }
        if (lbl_s12_igst.Text == string.Empty)
        {
            lbl_s12_igst.Text = "0";

        }
        if (lbl_s12_cgst.Text == string.Empty)
        {
            lbl_s12_cgst.Text = "0";

        }
        if (lbl_s12_sgst.Text == string.Empty)
        {
            lbl_s12_sgst.Text = "0";

        }


        SqlCommand cmd24 = new SqlCommand("select sum(pc_stotal),sum(pc_igsta),sum(pc_cgsta),sum(pc_sgsta) from tbl_purchase_invoice where pc_invoice_date between '"+DateTime.Now.Year.ToString()+"-12-01' and '"+DateTime.Now.Year.ToString()+"-12-31'", conn);
        SqlDataAdapter adapt24 = new SqlDataAdapter(cmd24);
        DataTable dt24 = new DataTable();
        adapt24.Fill(dt24);
        if (dt24.Rows.Count > 0)
        {

            lbl_p12_igst.Text = dt24.Rows[0][1].ToString();
            lbl_p12_cgst.Text = dt24.Rows[0][2].ToString();
            lbl_p12_sgst.Text = dt24.Rows[0][3].ToString();
        }
        if (lbl_p12_igst.Text == string.Empty)
        {
            lbl_p12_igst.Text = "0";

        }
        if (lbl_p12_cgst.Text == string.Empty)
        {
            lbl_p12_cgst.Text = "0";

        }
        if (lbl_p12_sgst.Text == string.Empty)
        {
            lbl_p12_sgst.Text = "0";

        }
    }
}