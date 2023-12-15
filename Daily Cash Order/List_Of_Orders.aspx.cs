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
using System.Text;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.tool.xml;

public partial class Daily_Cash_Order_List_Of_Orders : System.Web.UI.Page
{

    SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["String"].ConnectionString);
    decimal balance, bal, qty;
    int del_inv, c_id;
    string insert;
    string admin_email, product_name;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["a_email"] != null)
        {
            if (Page.IsPostBack) return;
            DateTime serverTime = DateTime.Now; // gives you current Time in server timeZone
            DateTime utcTime = serverTime.ToUniversalTime(); // convert it to Utc using timezone setting of server computer

            TimeZoneInfo tzi = TimeZoneInfo.FindSystemTimeZoneById("India Standard Time");
            DateTime localTime = TimeZoneInfo.ConvertTimeFromUtc(utcTime, tzi); // convert from utc to local

            txtdate.Text = localTime.ToString("yyyy-MM-dd");
            try
            {
                insert = (Request.QueryString["insert"]??"").ToString();
                if (insert == "success")
                {
                    Panel2.Visible = true;
                }
                else
                {
                    Panel2.Visible = false;
                }
            }
            catch (Exception ex)
            { Panel2.Visible = false; }
            this.FillRepeater();

        }
        else
        {
            Response.Redirect("../login.aspx");
        }
    }


    public void FillRepeater()
    {
        SqlCommand cmd = new SqlCommand("select * from tbl_order order by quw_id desc", conn);
        SqlDataAdapter adapt = new SqlDataAdapter(cmd);
        DataTable dt = new DataTable();
        adapt.Fill(dt);
        if (dt.Rows.Count > 0)
        {
            Repeater1.DataSource = dt;
            Repeater1.DataBind();
            lbl_total_invoice_amount.Text = dt.Compute("Sum(quw_total)", string.Empty).ToString();
            lbl_total_invoice.Text = dt.Compute("count(quw_id)", string.Empty).ToString();
            lbl_total_invoice_amount.Text = dt.Compute("Sum(quw_total)", string.Empty).ToString();
        
        }
        else
        {
            lbl_total_invoice.Text = "0";
          
        }

        //SqlCommand cmd2 = new SqlCommand("select sum(si_pay) from tbl_sale_invoice_payment  order by si_id desc", conn);
        //SqlDataAdapter adapt2 = new SqlDataAdapter(cmd2);
        //DataTable dt2 = new DataTable();
        //adapt.Fill(dt2);
        //if (dt2.Rows.Count > 0)
        //{
        //    if (dt2.Rows[0][0] == System.DBNull.Value)
        //    {
        //        Lbl_advace.Text = "0";
        //    }
        //    else
        //    {
        //        Lbl_advace.Text = dt2.Rows[0][0].ToString();
        //    }
        //}
    }


    protected void DeleteSale(object sender, EventArgs e)
    {
        SqlCommand cmd = new SqlCommand("select * from tbl_admin_login", conn);
        SqlDataAdapter adapt = new SqlDataAdapter(cmd);
        DataTable dt = new DataTable();
        adapt.Fill(dt);
        if (dt.Rows.Count > 0)
        {
            admin_email = dt.Rows[0]["a_email"].ToString();
        }
        if (admin_email.ToString() == Session["a_email"].ToString() || Session["admin_email"] != null)
        {
            string invoiceno = (((sender as LinkButton).NamingContainer.FindControl("lbl_invoice_no") as Label).Text);



            using (SqlCommand cmd2 = new SqlCommand("select * from tbl_order_details where quw_no='" + invoiceno + "'", conn))
            {
                SqlDataAdapter adapt2 = new SqlDataAdapter(cmd2);
                DataTable dt2 = new DataTable();
                adapt2.Fill(dt2);
                if (dt2.Rows.Count > 0)
                {

                    foreach (DataRow row in dt2.Rows)
                    {

                        bal = Convert.ToDecimal(row["qw_balance"]);
                        //c_id = Convert.ToInt32(row["c_id"]);
                        qty = Convert.ToDecimal(row["qw_quantity"]);
                        product_name = Convert.ToString(row["qw_product_name"]);
                      



                        SqlCommand cmd33 = new SqlCommand("UPDATE tbl_purchase_product SET p_stock = p_stock + @Quantity WHERE p_name = @ProductName AND p_id = (SELECT TOP 1 p_id FROM tbl_purchase_product WHERE p_name = @ProductName)", conn);
                        cmd33.Parameters.AddWithValue("@Quantity", qty);
                        cmd33.Parameters.AddWithValue("@ProductName", Convert.ToString(product_name));
                      


                        conn.Open();
                        cmd33.ExecuteNonQuery();
                        conn.Close();

                        decimal QuantityUsedStock = -qty;
                        //SqlCommand cmd34 = new SqlCommand("UPDATE tbl_used_stock SET quanity=quanity+('" + qty + "') WHERE p_name='" + Convert.ToString(product_name) + "'", conn);

                        //conn.Open();
                        //cmd34.ExecuteNonQuery();
                        //conn.Close();
                        SqlCommand cmd44 = new SqlCommand("insert into tbl_used_stock values(@p_name,@date,@sqrft,@quantity)", conn);
                        cmd44.Parameters.AddWithValue("@p_name", Convert.ToString(product_name));
                        cmd44.Parameters.AddWithValue("@date", Convert.ToDateTime(txtdate.Text).ToString("MM/dd/yyyy"));
                        cmd44.Parameters.AddWithValue("@sqrft", qty);
                        cmd44.Parameters.AddWithValue("@quantity", QuantityUsedStock);

                        conn.Open();
                        cmd44.ExecuteNonQuery();
                        conn.Close();

                    }


                }
            }





            using (SqlCommand cmd5 = new SqlCommand("DELETE FROM tbl_order_details WHERE quw_no = @quw_no", conn))
            {
                cmd5.Parameters.AddWithValue("@quw_no", invoiceno);
                conn.Open();
                cmd5.ExecuteNonQuery();
                conn.Close();
            }

            using (SqlCommand cmd6 = new SqlCommand("DELETE FROM tbl_order WHERE quw_no = @quw_no", conn))
            {
                cmd6.Parameters.AddWithValue("@quw_no", invoiceno);
                conn.Open();
                cmd6.ExecuteNonQuery();
                conn.Close();
            }



            Response.Redirect(Request.RawUrl);
        }
        else
        {
            Response.Redirect("../access_denied.aspx");

        }
    }

    public override void VerifyRenderingInServerForm(Control control)
    {
        /* Verifies that the control is rendered */
    }
   
       
  
}