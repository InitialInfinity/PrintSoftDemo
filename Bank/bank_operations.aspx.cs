using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

public partial class Bank_bank_operations : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["String"].ConnectionString);
    string filename1; string otp = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        Dd_bank.Focus();
        if (!IsPostBack)
        {
            bank();
            FillBankOperations();
            Label1.Visible = true;
            Label2.Visible = false;
            Label3.Visible = true;
            Label4.Visible = false;

        }
    }
    public void bank()
    {
        string query = "select * from tbl_bank Order By b_name asc";
        SqlDataAdapter adapt5 = new SqlDataAdapter(query, con);
        DataTable dt6 = new DataTable();
        adapt5.Fill(dt6);
        if (dt6.Rows.Count > 0)
        {
            Dd_bank.DataSource = dt6;
            Dd_bank.DataBind();
            Dd_bank.DataTextField = "b_name";

            Dd_bank.DataValueField = "b_id";
            Dd_bank.DataBind();
            Dd_bank.Items.Insert(0, new ListItem("--Select--", "--Select--"));
            Dd_bank.SelectedItem.Selected = false;
            Dd_bank.Items.FindByText("--Select--").Selected = true;
        }

    }
    public void FillBankOperations()
    {
        SqlCommand cmd = new SqlCommand("select * from tbl_bank_operations order by bo_id desc", con);
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataTable dt = new DataTable();
        da.Fill(dt);
        if (dt.Rows.Count > 0)
        {
            Repeater1.DataSource = dt;
            Repeater1.DataBind();
        }


    }
    protected void Repeater1_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if (e.CommandName == "download")
        {
            string filename = e.CommandArgument.ToString();
            string path = MapPath("~/Invoice Images/" + filename);
            byte[] bts = System.IO.File.ReadAllBytes(path);
            Response.Clear();
            Response.ClearHeaders();
            Response.AddHeader("Content-Type", "Application/octet-stream");
            Response.AddHeader("Content-Length", bts.Length.ToString());
            Response.AddHeader("Content-Disposition", "attachment; filename=" +
            filename);
            Response.BinaryWrite(bts);
            Response.Flush();
        }
      
    }
    protected void Dd_category_SelectedIndexChanged(object sender, EventArgs e)
    {
        
            if (Dd_category.SelectedValue == "Credit")
            {
            Label1.Visible = true;
            Label2.Visible = false;
            Label3.Visible = true;
            Label4.Visible = false;
            }
            else
            {
            Label1.Visible = false;
            Label2.Visible = true;
            Label3.Visible = false;
            Label4.Visible = true;
        }
            
    }
    protected void Btn_submit_Click(object sender, EventArgs e)
    {
        string num = "0123456789";
        int len = num.Length;

        int otpdigit = 5;
        int getindex;
        string finaldigit;
        for (int i = 0; i < otpdigit; i++)
        {
            do
            {
                getindex = new Random().Next(0, len);
                finaldigit = num.ToCharArray()[getindex].ToString();
            } while (otp.IndexOf(finaldigit) != -1);
            otp += finaldigit;
        }
        string strname = otp + FileUpload1.FileName.ToString();
        FileUpload1.PostedFile.SaveAs(Server.MapPath("../Invoice Images/") + strname);

        SqlCommand cmd = new SqlCommand("insert into tbl_bank_operations values (@bo_date,@bo_bank,@bo_name,@bo_amount,@bo_category,@bo_remark,@bo_file)", con);
        cmd.Parameters.AddWithValue("@bo_date", Convert.ToDateTime(DateTime.Now.ToShortDateString()).ToString("MM/dd/yyyy"));
        cmd.Parameters.AddWithValue("@bo_bank", Dd_bank.SelectedItem.Text.ToString());
        cmd.Parameters.AddWithValue("@bo_name",Txt_name.Text.ToString());
        cmd.Parameters.AddWithValue("@bo_amount", Txt_amount.Text.ToString());
        cmd.Parameters.AddWithValue("@bo_category", Dd_category.SelectedItem.Text.ToString());
        cmd.Parameters.AddWithValue("@bo_remark", Txt_remark.Text.ToString());
        cmd.Parameters.AddWithValue("@bo_file", strname.ToString());
        con.Open();
        cmd.ExecuteNonQuery();
        con.Close();
        if (Dd_category.SelectedItem.Text == "Credit")
        {
            SqlCommand cmd2 = new SqlCommand("update tbl_bank set b_opening_balance=b_opening_balance+'" + Txt_amount.Text + "'", con);
            con.Open();
            cmd2.ExecuteNonQuery();
            con.Close();
        }
        else
        {
            SqlCommand cmd2 = new SqlCommand("update tbl_bank set b_opening_balance=b_opening_balance-'" + Txt_amount.Text + "'", con);
            con.Open();
            cmd2.ExecuteNonQuery();
            con.Close();
        }
        
        Response.Redirect(Request.RawUrl);
    }

    protected void lb_Delete_Click(object sender, EventArgs e)
    {
        int ID = int.Parse(((sender as LinkButton).NamingContainer.FindControl("lbl_id") as Label).Text);
        string bank =((sender as LinkButton).NamingContainer.FindControl("lbl_bank") as Label).Text;
        string cat = ((sender as LinkButton).NamingContainer.FindControl("lbl_category") as Label).Text;
        decimal amt = int.Parse(((sender as LinkButton).NamingContainer.FindControl("lbl_amount") as Label).Text);

        if (cat == "Credit")
        {
            SqlCommand cmd2 = new SqlCommand("update tbl_bank set b_opening_balance=b_opening_balance-'" + amt + "'", con);
            con.Open();
            cmd2.ExecuteNonQuery();
            con.Close();
        }
        else
        {
            SqlCommand cmd2 = new SqlCommand("update tbl_bank set b_opening_balance=b_opening_balance+'" + amt + "'", con);
            con.Open();
            cmd2.ExecuteNonQuery();
            con.Close();
        }

        SqlCommand cmd = new SqlCommand("delete from tbl_bank_operations where bo_id=@ID", con);
        cmd.Parameters.AddWithValue("@ID", ID);
        con.Open();
        cmd.ExecuteNonQuery();
        con.Close();
        //FillBankOperations();
        Response.Redirect(Request.RawUrl);
    }
}