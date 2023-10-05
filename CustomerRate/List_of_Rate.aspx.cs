using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Drawing;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using System.IO;
using System.Text;
using iTextSharp;
using iTextSharp.text;

using iTextSharp.text.pdf;
using iTextSharp.text.html.simpleparser;
using iTextSharp.text.html;
using iTextSharp.tool.xml;

public partial class CustomerRate_List_of_Rate : System.Web.UI.Page
{
    SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["String"].ConnectionString);
    string admin_email, custid, insert_cust;
    protected void Page_Load(object sender, EventArgs e)
    {

        if (!IsPostBack)
        {
            if (Session["a_email"] != null)
            {
                FillRepeater();
            }
            else
            {
                Response.Redirect("../login.aspx");
            }
        }
    }



    public void FillRepeater()
    {
        SqlCommand cmd = new SqlCommand("select * from tbl_rate order by r_id desc", conn);
        SqlDataAdapter adapt = new SqlDataAdapter(cmd);
        DataTable dt = new DataTable();
        adapt.Fill(dt);
        if (dt.Rows.Count > 0)
        {
            Repeater1.DataSource = dt;
           Repeater1.DataBind();
        }
    }


    protected void DeleteProduct(object sender, EventArgs e)
    {
        SqlCommand cmd1 = new SqlCommand("select * from tbl_admin_login", conn);
        SqlDataAdapter adapt1 = new SqlDataAdapter(cmd1);
        DataTable dt1 = new DataTable();
        adapt1.Fill(dt1);
        if (dt1.Rows.Count > 0)
        {
            admin_email = dt1.Rows[0]["a_email"].ToString();
        }
        if (admin_email.ToString() == Session["a_email"].ToString() || Session["admin_email"] != null)
        {
            int rate_id = int.Parse(((sender as LinkButton).NamingContainer.FindControl("lbl_id") as Label).Text);

            using (SqlCommand cmd2 = new SqlCommand("DELETE FROM tbl_rate WHERE r_id = @r_id", conn))
            {
                cmd2.Parameters.AddWithValue("@r_id", rate_id);
                conn.Open();
                cmd2.ExecuteNonQuery();
                conn.Close();
            }

            this.FillRepeater();
        }
        else
        {
            Response.Redirect("../access_denied.aspx");

        }
    }


    protected void Repeater1_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if (e.CommandName.Equals("editid"))
        {
            SqlCommand cmd1 = new SqlCommand("select * from tbl_admin_login", conn);
            SqlDataAdapter adapt1 = new SqlDataAdapter(cmd1);
            DataTable dt1 = new DataTable();
            adapt1.Fill(dt1);
            if (dt1.Rows.Count > 0)
            {
                admin_email = dt1.Rows[0]["a_email"].ToString();
            }
            if (admin_email.ToString() == Session["a_email"].ToString() || Session["admin_email"] != null)
            {
                //get data
                string CarrierName = e.CommandArgument.ToString();
                SqlCommand cmd = new SqlCommand("select * from tbl_rate where r_id='" + CarrierName + "'", conn);
                SqlDataAdapter adapt = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adapt.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    Txt_id.Value = dt.Rows[0]["r_id"].ToString();
                    Txt_cname.Text = dt.Rows[0]["cust_name"].ToString();
                    Txt_pname.Text = dt.Rows[0]["p_name"].ToString();
                    //Dd_unit.SelectedItem.Text = dt.Rows[0]["p_unit"].ToString();
                    //Dd_cgst.SelectedValue = dt.Rows[0]["p_cgst"].ToString();
                    //Dd_sgst.SelectedValue = dt.Rows[0]["p_sgst"].ToString();
                    //Dd_igst.SelectedValue = dt.Rows[0]["p_igst"].ToString();
                    //Txt_hsn.Text = dt.Rows[0]["p_hsn_code"].ToString();
                    Txt_rate.Text = dt.Rows[0]["r_rate"].ToString();
                    //Txt_description.Text = dt.Rows[0]["p_desc"].ToString();

                }

                ScriptManager.RegisterStartupScript(this, this.GetType(), "Modal", "ShowModel2();", true);
            }
            else
            {
                Response.Redirect("../access_denied.aspx");

            }
        }
    }

         protected void Button1_Click(object sender, EventArgs e)
    {
        SqlCommand cmd = new SqlCommand("UPDATE tbl_rate SET r_rate='" + Txt_rate.Text + "' WHERE r_id='" + Txt_id.Value + "'", conn);
        conn.Open();
        cmd.ExecuteNonQuery();
        conn.Close();
        Response.Redirect("List_of_Rate.aspx");
    }
 }
