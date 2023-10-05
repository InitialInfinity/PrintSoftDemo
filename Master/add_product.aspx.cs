using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

public partial class Master_add_product : System.Web.UI.Page
{
    SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["String"].ConnectionString);
    protected void Page_Load(object sender, EventArgs e)
    {
        Txt_product_name.Focus();
        if (Session["a_email"] != null)
        {
            Rdo_both.Checked = true;
        }
        else
        {
            Response.Redirect("../login.aspx");
        }
    }
  
    protected void Btn_submit_Click(object sender, EventArgs e)
    {
        string hsn,desc;
        if (Txt_hsn.Text == string.Empty)
        {
            hsn = "-";
        }
        else
        {
            hsn = Txt_hsn.Text;
        }
        if (Txt_description.Text == string.Empty)
        {
            desc = "-";
        }
        else
        {
            desc = Txt_description.Text;
        }
        if (Rdo_sale.Checked)
        {
            SqlCommand cmd2 = new SqlCommand("Select * from tbl_product where p_name='" + Txt_product_name.Text.Trim() + "'", conn);
            SqlDataAdapter adapt2 = new SqlDataAdapter(cmd2);
            DataTable dt2 = new DataTable();
            adapt2.Fill(dt2);
            if (dt2.Rows.Count > 0)
            {
                Lbl_message.Text = "Product Already Exist!!!";

            }
            else
            {
                SqlCommand cmd = new SqlCommand("insert into tbl_product values(@p_name,@p_unit,@p_cgst,@p_sgst,@p_igst,@p_hsn_code,@p_rate,@p_desc)", conn);
                cmd.Parameters.AddWithValue("@p_name", Txt_product_name.Text);
                cmd.Parameters.AddWithValue("@p_unit", Dd_unit.SelectedItem.Text);
                cmd.Parameters.AddWithValue("@p_cgst", Dd_cgst.SelectedValue);
                cmd.Parameters.AddWithValue("@p_sgst", Dd_sgst.SelectedValue);
                cmd.Parameters.AddWithValue("@p_igst", Dd_igst.SelectedValue);
                cmd.Parameters.AddWithValue("@p_hsn_code", hsn);
                cmd.Parameters.AddWithValue("@p_rate", Txt_rate.Text);
                cmd.Parameters.AddWithValue("@p_desc", desc);

                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
                
                Response.Redirect("list_of_product.aspx?insert_pro=success");
              

            }
        }
    else if(Rdo_purchase.Checked)
        {
            SqlCommand cmd2 = new SqlCommand("Select * from tbl_purchase_product where p_name='" + Txt_product_name.Text.Trim() + "'", conn);

            SqlDataAdapter adapt2 = new SqlDataAdapter(cmd2);
            DataTable dt2 = new DataTable();
            adapt2.Fill(dt2);
            
            if (dt2.Rows.Count > 0)
            {
                Lbl_message.Text = "Product Already Exist!!!";

            }
            else
            {
                SqlCommand cmd = new SqlCommand("insert into tbl_purchase_product values(@p_name,@p_unit,@p_cgst,@p_sgst,@p_igst,@p_hsn_code,@p_rate,@p_desc,@p_stock,@p_value)", conn);
                cmd.Parameters.AddWithValue("@p_name", Txt_product_name.Text);
                cmd.Parameters.AddWithValue("@p_unit", Dd_unit.SelectedItem.Text);
                cmd.Parameters.AddWithValue("@p_cgst", Dd_cgst.SelectedValue);
                cmd.Parameters.AddWithValue("@p_sgst", Dd_sgst.SelectedValue);
                cmd.Parameters.AddWithValue("@p_igst", Dd_igst.SelectedValue);
                cmd.Parameters.AddWithValue("@p_hsn_code", hsn);
                cmd.Parameters.AddWithValue("@p_rate", Txt_rate.Text);
                cmd.Parameters.AddWithValue("@p_desc", desc);
                cmd.Parameters.AddWithValue("@p_stock", 0);
                cmd.Parameters.AddWithValue("@p_value", 0);
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
                Response.Redirect("list_of_product.aspx?insert_pro=success");
             
            }

        }
        else if (Rdo_both.Checked)
        {
            SqlCommand cmd = new SqlCommand("Select * from tbl_product where p_name='" + Txt_product_name.Text.Trim() + "'", conn);
            SqlDataAdapter adapt = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapt.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                Lbl_message.Text = "Product Already Exist!!!";

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
                cmd2.Parameters.AddWithValue("@p_rate", Txt_rate.Text);
                cmd2.Parameters.AddWithValue("@p_desc", desc);
                conn.Open();
                cmd2.ExecuteNonQuery();
                conn.Close();



            }

            SqlCommand cmd3 = new SqlCommand("Select * from tbl_purchase_product where p_name='" + Txt_product_name.Text.Trim() + "'", conn);

            SqlDataAdapter adapt3 = new SqlDataAdapter(cmd3);
            DataTable dt3 = new DataTable();
            adapt3.Fill(dt3);

            if (dt3.Rows.Count > 0)
            {
                Lbl_message.Text = "Product Already Exist!!!";

            }
            else
            {
                SqlCommand cmd4 = new SqlCommand("insert into tbl_purchase_product values(@p_name,@p_unit,@p_cgst,@p_sgst,@p_igst,@p_hsn_code,@p_rate,@p_desc,@p_stock,@p_value)", conn);
                cmd4.Parameters.AddWithValue("@p_name", Txt_product_name.Text);
                cmd4.Parameters.AddWithValue("@p_unit", Dd_unit.SelectedItem.Text);
                cmd4.Parameters.AddWithValue("@p_cgst", Dd_cgst.SelectedValue);
                cmd4.Parameters.AddWithValue("@p_sgst", Dd_sgst.SelectedValue);
                cmd4.Parameters.AddWithValue("@p_igst", Dd_igst.SelectedValue);
                cmd4.Parameters.AddWithValue("@p_hsn_code", hsn);
                cmd4.Parameters.AddWithValue("@p_rate", Txt_rate.Text);
                cmd4.Parameters.AddWithValue("@p_desc", desc);
                cmd4.Parameters.AddWithValue("@p_stock", 0);
                cmd4.Parameters.AddWithValue("@p_value", 0);
                conn.Open();
                cmd4.ExecuteNonQuery();
                conn.Close();
                Response.Redirect("list_of_product.aspx?insert_pro=success");

            }

        }
        else
        {
            System.Web.UI.ScriptManager.RegisterStartupScript(this, GetType(), "displayalertmessage", "alert('Please Select Product Category First!!!');", true);
        }
}

}