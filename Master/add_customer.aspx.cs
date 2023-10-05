using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
public partial class Master_add_customer : System.Web.UI.Page
{
    SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["String"].ConnectionString);
    protected void Page_Load(object sender, EventArgs e)
    {
        Txt_customer_name.Focus();
        if (!IsPostBack)
        {
            if (Session["a_email"] != null)
            {
                Panel1.Visible = false;
			}
            else
            {
                Response.Redirect("../login.aspx");
            }
        }
    }
    
    protected void Btn_submit_Click(object sender, EventArgs e)
    {
        SqlCommand cmd2 = new SqlCommand("Select * from tbl_customer where c_contact='" + Txt_contact.Text.Trim() + "' OR c_contact2='" + Txt_contact.Text.Trim() + "'", conn);

        SqlDataAdapter adapt2 = new SqlDataAdapter(cmd2);
        DataTable dt2 = new DataTable();
        adapt2.Fill(dt2);
        
        if (dt2.Rows.Count > 0)
        {
            Lbl_message.Text = "Customer Already Exist!!!";
        }
        else
        {
            SqlCommand cmd = new SqlCommand("insert into tbl_customer values(@c_name,@c_address,@c_contact,@c_contact2,@c_gst_no,@c_opening_balance,@c_email,@c_dob,@c_anidate)", conn);
            cmd.Parameters.AddWithValue("@c_name", Txt_customer_name.Text);
            cmd.Parameters.AddWithValue("@c_address", Txt_address.Text);
            cmd.Parameters.AddWithValue("@c_contact", Txt_contact.Text);
            cmd.Parameters.AddWithValue("@c_contact2", Txt_contact2.Text);
            cmd.Parameters.AddWithValue("@c_gst_no", Txt_gst_no.Text);
            if(Txt_opening_balance.Text=="")
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

            Response.Redirect("list_of_customer.aspx?insert_cust=success");
           
        }
    }
}