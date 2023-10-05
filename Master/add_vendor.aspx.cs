using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
public partial class Master_add_vendor : System.Web.UI.Page
{
    SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["String"].ConnectionString);
    protected void Page_Load(object sender, EventArgs e)
    {
        Txt_vendor_name.Focus();
        if (!IsPostBack)
        {
        if (Session["a_email"] != null)
        {
        }
        else
        {
            Response.Redirect("../login.aspx");
        }
            }
    }
 
    protected void Btn_submit_Click(object sender, EventArgs e)
    {
        SqlCommand cmd2 = new SqlCommand("Select * from tbl_vendor where v_name='" + Txt_vendor_name.Text.Trim() + "'", conn);

        SqlDataAdapter adapt2 = new SqlDataAdapter(cmd2);
        DataTable dt2 = new DataTable();
        adapt2.Fill(dt2);
        if (dt2.Rows.Count > 0)
        {
            Lbl_message.Text = "Vendor Already Exist!!!";
        }
        else
        {
            SqlCommand cmd = new SqlCommand("insert into tbl_vendor values(@v_name,@v_address,@v_contact,@v_gst_no,@v_opening_balance,@v_email,@v_contact2)", conn);
            cmd.Parameters.AddWithValue("@v_name", Txt_vendor_name.Text);
            cmd.Parameters.AddWithValue("@v_address", Txt_address.Text);
            cmd.Parameters.AddWithValue("@v_contact", Txt_contact.Text);
            cmd.Parameters.AddWithValue("@v_contact2", Txt_contact2.Text);
            cmd.Parameters.AddWithValue("@v_gst_no", Txt_gst_no.Text);
            if(Txt_opening_balance.Text=="")
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
          
            Response.Redirect("list_of_vendor.aspx?insert_cust=success");
     
        }
    }


   

}