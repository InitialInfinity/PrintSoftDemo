using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

public partial class CustomerRate_Create_rate : System.Web.UI.Page
{
    SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["String"].ConnectionString);
    SqlCommand cmd;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Session["a_email"] != null)
            {
                customer();
                product();
            }
            else
            {
                Response.Redirect("../login.aspx");
            }
        }
    }


    public void customer()
    {
        string query = "select * from tbl_customer Order By c_name asc";
        SqlDataAdapter adapt = new SqlDataAdapter(query, conn);
        DataTable dt = new DataTable();
        adapt.Fill(dt);
        if (dt.Rows.Count > 0)
        {
            drp_Customer.DataSource = dt;
            drp_Customer.DataBind();
            drp_Customer.DataTextField = "c_name";
            drp_Customer.DataValueField = "c_id";
            drp_Customer.DataBind();
            drp_Customer.Items.Insert(0, new ListItem("--Select--", "--Select--"));
            drp_Customer.SelectedItem.Selected = false;
            drp_Customer.Items.FindByText("--Select--").Selected = true;

    
        }

    }

    public void product()
    {
        string query = "select * from tbl_product Order By p_name asc";
        SqlDataAdapter adapt = new SqlDataAdapter(query, conn);
        DataTable dt = new DataTable();
        adapt.Fill(dt);
        if (dt.Rows.Count > 0)
        {
            drp_product.DataSource = dt;
            drp_product.DataBind();
            drp_product.DataTextField = "p_name";

            drp_product.DataValueField = "p_id";
            drp_product.DataBind();
            drp_product.Items.Insert(0, new ListItem("--Select--", "--Select--"));
            drp_product.SelectedItem.Selected = false;
            drp_product.Items.FindByText("--Select--").Selected = true;
        }

    }


    protected void Btn_submit_Click(object sender, EventArgs e)
    {
        if (Session["a_email"] != null)
        {
            string pro_name = drp_product.SelectedItem.Text;
            string cust_name = drp_Customer.SelectedItem.Text;
            string cust_id = drp_Customer.SelectedValue;

            SqlCommand cmd2 = new SqlCommand("select * from tbl_rate where cust_name='" + cust_name + "' and p_name='" + pro_name + "'", conn);
            SqlDataAdapter adapt = new SqlDataAdapter(cmd2);
            DataTable dt2 = new DataTable();


            adapt.Fill(dt2);
            if (dt2.Rows.Count > 0)
            {
                Lbl_message.Text =   "customer name already Exist";
            }
            else
            {


                cmd = new SqlCommand("insert into tbl_rate values(@cust_name,@p_name,@r_rate,@c_id)", conn);
                cmd.Parameters.AddWithValue("@cust_name",cust_name);
                cmd.Parameters.AddWithValue("@p_name",pro_name);
                cmd.Parameters.AddWithValue("@r_rate",Txt_Rate.Text);
                cmd.Parameters.AddWithValue("@c_id", cust_id);


                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();

                Lbl_message.Text = "'" + drp_product.SelectedItem.Text + "'  Rate Added Succesfully";
               
            }
           
        }

        }
}