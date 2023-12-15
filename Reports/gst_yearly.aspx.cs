using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

public partial class Reports_gst_yearly : System.Web.UI.Page
{
    SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["String"].ConnectionString);
    
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["a_email"] != null)
        {
            if (Page.IsPostBack) return;
            this.FillRepeater();
     
        }
        else
        {
            Response.Redirect("../login.aspx");
        }
    }
  
    public void FillRepeater()
    {
        SqlCommand cmd = new SqlCommand("Select * From tbl_sale inner join tbl_customer on tbl_sale.c_id=tbl_customer.c_id WHERE sl_invoice_date >= DATEADD(YEAR, DATEDIFF(YEAR, 0, GETDATE()), 0) AND sl_invoice_date <  DATEADD(YEAR, DATEDIFF(YEAR, 0, GETDATE()) + 1, 0) Order By sl_id desc", conn);
        SqlDataAdapter adapt = new SqlDataAdapter(cmd);
        DataTable dt = new DataTable();
        adapt.Fill(dt);
        if (dt.Rows.Count > 0)
        {
            Repeater1.DataSource = dt;
            Repeater1.DataBind();

            lbl_total_cgst.Text = dt.Compute("Sum(sl_total_cgst)", string.Empty).ToString();
            lbl_total_sgst.Text = dt.Compute("Sum(sl_total_sgst)", string.Empty).ToString();
            lbl_total_igst.Text = dt.Compute("Sum(sl_total_igst)", string.Empty).ToString();
            lbl_total_gst.Text = dt.Compute("Sum(sl_total_gst)", string.Empty).ToString();

            lbl_bal.Text = dt.Compute("Sum(sl_balance)", string.Empty).ToString();
            lbl_Total.Text = dt.Compute("Sum(sl_total)", string.Empty).ToString();
        }
        else
        {
            Panel1.Visible = false;
            lbl_total_cgst.Text = "0";
            lbl_total_sgst.Text = "0";
            lbl_total_igst.Text = "0";
            lbl_total_gst.Text = "0";
        }
    }

   
   
   
    protected void Repeater1_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {


        if (e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
        {
            Label tr = e.Item.FindControl("lbl_status") as Label;


            DataRowView drv = e.Item.DataItem as DataRowView;
            decimal balance = Convert.ToDecimal(drv["sl_balance"]);
            decimal total = Convert.ToDecimal(drv["sl_total"]);
            if (balance == 0)
            {
                tr.Text = "Paid";
                tr.Attributes.Add("class", "label label-success");
            }
            else if (balance == total)
            {
                tr.Text = "UnPaid";
                tr.Attributes.Add("class", "label label-danger");
            }
            else
            {
                tr.Text = "Partially";
                tr.Attributes.Add("class", "label label-warning");
            }

        }

    }

}