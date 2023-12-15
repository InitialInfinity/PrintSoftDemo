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
        try
        {
            SqlCommand cmd = new SqlCommand("insert into tbl_vendor values(@v_name,@v_address,@v_contact,@v_gst_no,@v_opening_balance,@v_email,@v_contact2)", conn);
            cmd.Parameters.AddWithValue("@v_name", Txt_vendor_name.Text);
            cmd.Parameters.AddWithValue("@v_address", Txt_address.Text);
            cmd.Parameters.AddWithValue("@v_contact", Txt_contact.Text);
            cmd.Parameters.AddWithValue("@v_contact2", Txt_contact2.Text);


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

            Response.Redirect("list_of_vendor.aspx?insert_cust=success");
        }
        catch (SqlException ex)
        {
            if (ex.Number == 2601)
            {
                // Check if the exception is related to a unique constraint violation
                if (ex.Message.Contains("IX_UniqueContact"))
                {
                    // Show an alert indicating that the contact number is a duplicate
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
                    // Handle other SQL errors as needed
                }
            }
            else
            {
                // Handle other SQL errors as needed
            }

        }

    }


   

}