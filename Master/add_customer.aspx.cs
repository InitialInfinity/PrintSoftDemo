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
            Response.Redirect("list_of_customer.aspx?insert_cust=success");



        }
        catch (SqlException ex)
        {
            if (ex.Number == 2601)
            {

                if (ex.Message.Contains("IX_UniqueContact"))
                {
                    string script = "alert(' This contact number already exists.');";
                    ClientScript.RegisterStartupScript(this.GetType(), "AlertContact", script, true);
                }
                else if (ex.Message.Contains("IX_UniqueGST"))
                {
                    string script = "alert('This GST number already exists.');";
                    ClientScript.RegisterStartupScript(this.GetType(), "AlertGST", script, true);

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
}