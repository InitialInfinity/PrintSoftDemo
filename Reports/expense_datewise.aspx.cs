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


public partial class Reports_expense_datewise : System.Web.UI.Page
{
    SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["String"].ConnectionString);
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["a_email"] != null)
        {
           
            if (Page.IsPostBack) return;
            this.user();
            this.category();
            this.category2();
            this.Fill();
        }
        else
        {
            Response.Redirect("../login.aspx");
        }
    }
    public void user()
    {
        string query = "select * from tbl_expense_user order by u_user_name asc";
        SqlDataAdapter adapt4 = new SqlDataAdapter(query, conn);
        DataTable dt4 = new DataTable();
        adapt4.Fill(dt4);
        if (dt4.Rows.Count > 0)
        {
            Dd_user.DataSource = dt4;
            Dd_user.DataBind();
            Dd_user.DataTextField = "u_user_name";
            Dd_user.DataValueField = "u_id";
            Dd_user.DataBind();
            Dd_user.Items.Insert(0, new System.Web.UI.WebControls.ListItem("--Select--", "--Select--"));
            Dd_user.SelectedItem.Selected = false;
            Dd_user.Items.FindByText("--Select--").Selected = true;
        }

    }
    public void category()
    {
        string query = "select * from tbl_expense_category order by cat_category_name asc";
        SqlDataAdapter adapt5 = new SqlDataAdapter(query, conn);
        DataTable dt5 = new DataTable();
        adapt5.Fill(dt5);
        if (dt5.Rows.Count > 0)
        {
            Dd_category.DataSource = dt5;
            Dd_category.DataBind();
            Dd_category.DataTextField = "cat_category_name";
            Dd_category.DataValueField = "cat_id";
            Dd_category.DataBind();
            Dd_category.Items.Insert(0, new System.Web.UI.WebControls.ListItem("--Select--", "--Select--"));
            Dd_category.SelectedItem.Selected = false;
            Dd_category.Items.FindByText("--Select--").Selected = true;
        }

    }
    public void category2()
    {
        string query2 = "select * from tbl_expense_category order by cat_category_name asc";
        SqlDataAdapter adapt6 = new SqlDataAdapter(query2, conn);
        DataTable dt6 = new DataTable();
        adapt6.Fill(dt6);
        if (dt6.Rows.Count > 0)
        {
            Dd_category2.DataSource = dt6;
            Dd_category2.DataBind();
            Dd_category2.DataTextField = "cat_category_name";
            Dd_category2.DataValueField = "cat_id";
            Dd_category2.DataBind();
            Dd_category2.Items.Insert(0, new System.Web.UI.WebControls.ListItem("--Select Category--", "--Select Category--"));
            Dd_category2.SelectedItem.Selected = false;
            Dd_category2.Items.FindByText("--Select Category--").Selected = true;
        }

    }

    public void Fill()
    {
        SqlCommand cmd = new SqlCommand("Select * From tbl_expense Order By e_id desc", conn);
        SqlDataAdapter adapt = new SqlDataAdapter(cmd);
        DataTable dt = new DataTable();
        adapt.Fill(dt);
        if (dt.Rows.Count > 0)
        {
            Repeater1.DataSource = dt;
            Repeater1.DataBind();
            lbl_total_expense.Text = dt.Compute("Sum(e_amount)", string.Empty).ToString();

            lbl_Total.Text = dt.Compute("Sum(e_amount)", string.Empty).ToString();
        }
        else
        {
            Panel1.Visible = false;
            Repeater1.DataSource = null;
            Repeater1.DataBind();
            lbl_total_expense.Text = "0";
        }

    }
    private int CurrentPage
    {
        get
        {
            if (ViewState["CurrentPage"] == null)
            {
                return 0;
            }
            return ((int)ViewState["CurrentPage"]);
        }
        set
        {
            ViewState["CurrentPage"] = value;
        }
    }

   
    protected void DeleteSale(object sender, EventArgs e)
    {
        String id = ((sender as LinkButton).NamingContainer.FindControl("lbl_sr") as Label).Text;


        using (SqlCommand cmd = new SqlCommand("DELETE FROM tbl_expense WHERE e_id = @e_id", conn))
        {

            cmd.Parameters.AddWithValue("@e_id", id);
            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
        }


        this.Fill();
    }
   
    protected void Repeater1_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if (e.CommandName.Equals("showid"))
        {
            //get data
            string CarrierName = e.CommandArgument.ToString();
            SqlCommand cmd = new SqlCommand("select * from tbl_expense where e_id='" + CarrierName + "'", conn);
            SqlDataAdapter adapt = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapt.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                lbl_category.Text = dt.Rows[0]["e_category_name"].ToString();
                lbl_user.Text = dt.Rows[0]["e_user_name"].ToString();
                lbl_amount.Text = dt.Rows[0]["e_amount"].ToString();
                lbl_desc.Text = dt.Rows[0]["e_desc"].ToString();
                lbl_date.Text = Convert.ToDateTime(dt.Rows[0]["e_date"]).ToString("dd/MM/yyyy");


            }
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Modal", "ShowModel();", true);
        }
        if (e.CommandName.Equals("editid"))
        {
            //get data
            string CarrierName = e.CommandArgument.ToString();
            SqlCommand cmd = new SqlCommand("select * from tbl_expense where e_id='" + CarrierName + "'", conn);
            SqlDataAdapter adapt = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapt.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                Txt_id.Value = dt.Rows[0]["e_id"].ToString();

                Dd_category.SelectedItem.Text = dt.Rows[0]["e_category_name"].ToString();
                Dd_user.SelectedItem.Text = dt.Rows[0]["e_user_name"].ToString();

                Txt_amount.Text = dt.Rows[0]["e_amount"].ToString();
                Txt_desc.Text = dt.Rows[0]["e_desc"].ToString();
                Txt_date.Text = Convert.ToDateTime(dt.Rows[0]["e_date"]).ToString("yyyy-MM-dd");


            }

            ScriptManager.RegisterStartupScript(this, this.GetType(), "Modal", "ShowModel2();", true);
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        SqlCommand cmd = new SqlCommand("UPDATE tbl_expense SET e_category_name='" + Dd_category.SelectedItem.Text.Trim() + "',e_user_name='" + Dd_user.SelectedItem.Text.Trim() + "',e_amount='" + Txt_amount.Text.Trim() + "',e_date='" + Txt_date.Text.Trim() + "',e_desc='" + Txt_desc.Text.Trim() + "' WHERE e_id='" + Txt_id.Value.Trim() + "'", conn);

        conn.Open();
        cmd.ExecuteNonQuery();
        conn.Close();
        string redirectScript = " window.location.href = 'expense_datewise.aspx';";
        System.Web.UI.ScriptManager.RegisterStartupScript(this, GetType(), "displayalertmessage", "alert('Expense Updated Successfully!!!');" + redirectScript, true);


    }
    protected void Btn_search_Click(object sender, EventArgs e)
    {
        if (Txt_date1.Text == "" || Txt_date1.Text == "" && Dd_category2.SelectedItem.Text != "--Select Category--")
        {
            SqlCommand cmd = new SqlCommand("select * from tbl_expense where e_category_name like '%" + Dd_category2.SelectedItem.Text + "%' Order By e_id desc", conn);
            SqlDataAdapter adapt = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapt.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                Repeater1.DataSource = dt;
                Repeater1.DataBind();
                lbl_total_expense.Text = dt.Compute("Sum(e_amount)", string.Empty).ToString();

                lbl_Total.Text = dt.Compute("Sum(e_amount)", string.Empty).ToString();
            }
            else
            {
                Panel1.Visible = false;
                Repeater1.DataSource = null;
                Repeater1.DataBind();
                lbl_total_expense.Text = "0";
            }
        }
        else if (Txt_date1.Text != "" && Txt_date1.Text != "" && Dd_category2.SelectedItem.Text == "--Select Category--")
        {
            SqlCommand cmd = new SqlCommand("select * from tbl_expense where e_date Between '" + Txt_date1.Text + "' and '" + Txt_date2.Text + "' Order By e_id desc", conn);
            SqlDataAdapter adapt = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapt.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                Repeater1.DataSource = dt;
                Repeater1.DataBind();
                lbl_total_expense.Text = dt.Compute("Sum(e_amount)", string.Empty).ToString();

                lbl_Total.Text = dt.Compute("Sum(e_amount)", string.Empty).ToString();
            }
            else
            {
                Panel1.Visible = false;
                Repeater1.DataSource = null;
                Repeater1.DataBind();
                lbl_total_expense.Text = "0";
            }
        }
        else if (Txt_date1.Text != "" && Txt_date1.Text != "" && Dd_category2.SelectedItem.Text != "--Select Category--")
        {
            SqlCommand cmd = new SqlCommand("select * from tbl_expense where e_category_name like '%" + Dd_category2.SelectedItem.Text + "%' AND e_date Between '" + Txt_date1.Text + "' and '" + Txt_date2.Text + "'  Order By e_id desc", conn);
            SqlDataAdapter adapt = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapt.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                Repeater1.DataSource = dt;
                Repeater1.DataBind();
                lbl_total_expense.Text = dt.Compute("Sum(e_amount)", string.Empty).ToString();

                lbl_Total.Text = dt.Compute("Sum(e_amount)", string.Empty).ToString();
            }
            else
            {
                Panel1.Visible = false;
                Repeater1.DataSource = null;
                Repeater1.DataBind();
                lbl_total_expense.Text = "0";
            }
        }


    }
  
}
