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
using System.Web.UI.HtmlControls;

public partial class Orders_list_of_order : System.Web.UI.Page
{
    SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["String"].ConnectionString);
    SqlCommand cmd2, cmd3, cmd8, cmd9, cmd10, cmd11, cmd12, cmd13, cmd14, cmd15, cmd16;
    SqlDataAdapter adapt2, adapt3, adapt8, adapt9, adapt10, adapt11, adapt12, adapt13, adapt14, adapt15, adapt16;
    DataTable dt1, dt2, dt8, dt9, dt10, dt11, dt12, dt13, dt14, dt15, dt16;
    readonly PagedDataSource _pgsource = new PagedDataSource();
    int _firstIndex, _lastIndex;
    private int _pageSize = 25;
    decimal balance, bal;
    int del_inv;
    string insert;
    string admin_email;
    protected void Page_Load(object sender, EventArgs e)
    {

        if (Session["a_email"] != null)
        {
            if (Page.IsPostBack) return;
            try
            {
                insert = Request.QueryString["insert"].ToString();
                if (insert == "success")
                {
                    Panel2.Visible = true;
                }
                else
                {
                    Panel2.Visible = false;
                }
            }
            catch (Exception ex)
            { Panel2.Visible = false; }

            BindDataIntoRepeater();
            //this.FillRepeater();
            FillRepeater6();
            FillRepeater7();


        }
        else
        {
            Response.Redirect("../login.aspx");
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

    //database
    static DataTable GetDataFromDb()
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["String"].ConnectionString);
        con.Open();
        var da = new SqlDataAdapter("Select * From tbl_order Order By sl_id desc", con);
        var dt = new DataTable();
        da.Fill(dt);

        con.Close();
        return dt;
    }

    // Bind PagedDataSource into Repeater
    private void BindDataIntoRepeater()
    {
        var dt = GetDataFromDb();
        _pgsource.DataSource = dt.DefaultView;
        _pgsource.AllowPaging = true;
        // Number of items to be displayed in the Repeater
        _pgsource.PageSize = _pageSize;
        _pgsource.CurrentPageIndex = CurrentPage;
        // Keep the Total pages in View State
        ViewState["TotalPages"] = _pgsource.PageCount;
        // Example: "Page 1 of 10"
        lblpage.Text = "Page " + (CurrentPage + 1) + " of " + _pgsource.PageCount;
        // Enable First, Last, Previous, Next buttons
        lbPrevious.Enabled = !_pgsource.IsFirstPage;
        lbNext.Enabled = !_pgsource.IsLastPage;
        lbFirst.Enabled = !_pgsource.IsFirstPage;
        lbLast.Enabled = !_pgsource.IsLastPage;

        // Bind data into repeater
        Repeater1.DataSource = _pgsource;
        Repeater1.DataBind();

        // Call the function to do paging
        HandlePaging();
    }

    private void HandlePaging()
    {
        var dt = new DataTable();
        dt.Columns.Add("PageIndex"); //Start from 0
        dt.Columns.Add("PageText"); //Start from 1

        _firstIndex = CurrentPage - 5;
        if (CurrentPage > 5)
            _lastIndex = CurrentPage + 5;
        else
            _lastIndex = 10;

        // Check last page is greater than total page then reduced it 
        // to total no. of page is last index
        if (_lastIndex > Convert.ToInt32(ViewState["TotalPages"]))
        {
            _lastIndex = Convert.ToInt32(ViewState["TotalPages"]);
            _firstIndex = _lastIndex - 10;
        }

        if (_firstIndex < 0)
            _firstIndex = 0;

        // Now creating page number based on above first and last page index
        for (var i = _firstIndex; i < _lastIndex; i++)
        {
            var dr = dt.NewRow();
            dr[0] = i;
            dr[1] = i + 1;
            dt.Rows.Add(dr);
        }

        rptPaging.DataSource = dt;
        rptPaging.DataBind();
    }
    public void FillRepeater()
    {
        cmd2 = new SqlCommand("select * from tbl_sale", conn);
        adapt2 = new SqlDataAdapter(cmd2);
        dt1 = new DataTable();
        adapt2.Fill(dt1);
        if (dt1.Rows.Count > 0)
        {
            Repeater1.DataSource = dt1;
            Repeater1.DataBind();
        }
    }

    protected void lbFirst_Click(object sender, EventArgs e)
    {
        CurrentPage = 0;
        BindDataIntoRepeater();
    }

    protected void lbPrevious_Click(object sender, EventArgs e)
    {
        CurrentPage -= 1;
        BindDataIntoRepeater();
    }

    protected void lbNext_Click(object sender, EventArgs e)
    {
        CurrentPage += 1;
        BindDataIntoRepeater();
    }

    protected void lbLast_Click(object sender, EventArgs e)
    {
        CurrentPage = (Convert.ToInt32(ViewState["TotalPages"]) - 1);
        BindDataIntoRepeater();
    }

    protected void rptPaging_ItemCommand(object source, DataListCommandEventArgs e)
    {
        if (!e.CommandName.Equals("newPage")) return;
        CurrentPage = Convert.ToInt32(e.CommandArgument.ToString());
        BindDataIntoRepeater();
    }

    protected void rptPaging_ItemDataBound(object sender, DataListItemEventArgs e)
    {
        var lnkPage = (LinkButton)e.Item.FindControl("lbPaging");
        if (lnkPage.CommandArgument != CurrentPage.ToString()) return;
        lnkPage.Enabled = false;
        //  lnkPage.BackColor = Color.FromName("#00FF00");
    }

    protected void Repeater1_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        //if (e.CommandName.Equals("showid"))
        //{

        //    string CarrierName = e.CommandArgument.ToString();
        //    cmd2 = new SqlCommand("select * from tbl_sale_invoice where s_invoice_no ='" + CarrierName + "'", conn);
        //    adapt2 = new SqlDataAdapter(cmd2);
        //    dt1 = new DataTable();
        //    adapt2.Fill(dt1);
        //    if (dt1.Rows.Count > 0)
        //    {
        //        Repeater2.DataSource = dt1;
        //        Repeater2.DataBind();

        //        lbl_invoice_no.Text = dt1.Rows[0]["s_invoice_no"].ToString();
        //        lbl_date.Text = dt1.Rows[0]["s_date"].ToString();
        //        lbl_customer_name.Text = dt1.Rows[0]["s_customer_name"].ToString();
        //        lbl_customer_contact.Text = dt1.Rows[0]["s_customer_contact"].ToString();
        //        lbl_customer_address.Text = dt1.Rows[0]["s_customer_address"].ToString();
        //        lbl_gst_no.Text = dt1.Rows[0]["s_customer_gst_no"].ToString();
        //        lbl_order_no.Text = dt1.Rows[0]["s_order_no"].ToString();
        //        lbl_invoice_date.Text = dt1.Rows[0]["s_invoice_date"].ToString();
        //        lbl_due_date.Text = dt1.Rows[0]["s_due_date"].ToString();

        //        lbl_discount.Text = dt1.Rows[0]["s_discount"].ToString();

        //        lbl_subtotal.Text = dt1.Rows[0]["s_sub_total"].ToString();
        //        lbl_total_gst.Text = dt1.Rows[0]["s_total_gst"].ToString();
        //        lbl_shipping.Text = dt1.Rows[0]["s_shipping_charges"].ToString();
        //        lbl_adjustment.Text = dt1.Rows[0]["s_adjustment"].ToString();
        //        lbl_total.Text = dt1.Rows[0]["s_total"].ToString();


        //    }

        //    SqlCommand cmd5 = new SqlCommand("select * from tbl_company_details where com_id = 2", conn);
        //    SqlDataAdapter adapt5 = new SqlDataAdapter(cmd5);
        //    DataTable dt5 = new DataTable();
        //    adapt5.Fill(dt5);
        //    if (dt5.Rows.Count > 0)
        //    {
        //        lbl_company_name.Text = dt5.Rows[0]["com_company_name"].ToString();
        //        lbl_company_address.Text = dt5.Rows[0]["com_address"].ToString();
        //        lbl_company_contact.Text = dt5.Rows[0]["com_contact"].ToString();
        //        lbl_company_email.Text = dt5.Rows[0]["com_email"].ToString();

        //    }
        //    ScriptManager.RegisterStartupScript(this, this.GetType(), "Modal", "ShowModel();", true);
        //}
    }
    protected void DeleteSale(object sender, EventArgs e)
    {
        SqlCommand cmd10 = new SqlCommand("select * from tbl_admin_login", conn);
        SqlDataAdapter adapt10 = new SqlDataAdapter(cmd10);
        DataTable dt10 = new DataTable();
        adapt10.Fill(dt10);
        if (dt10.Rows.Count > 0)
        {
            admin_email = dt10.Rows[0]["a_email"].ToString();
        }
        if (admin_email.ToString() == Session["a_email"].ToString() || Session["admin_email"] != null)
        {
            String invoiceno = ((sender as LinkButton).NamingContainer.FindControl("lbl_invoice") as Label).Text;
            String custname = ((sender as LinkButton).NamingContainer.FindControl("lbl_cust_name") as Label).Text;
            String total = ((sender as LinkButton).NamingContainer.FindControl("lbl_total") as Label).Text;

           
            using (SqlCommand cmd4 = new SqlCommand("DELETE FROM tbl_order_invoice WHERE s_invoice_no = @s_invoice_no", conn))
            {

                cmd4.Parameters.AddWithValue("@s_invoice_no", invoiceno);
                conn.Open();
                cmd4.ExecuteNonQuery();
                conn.Close();
            }
            using (SqlCommand cmd5 = new SqlCommand("DELETE FROM tbl_order WHERE sl_invoice_no = @sl_invoice_no", conn))
            {
                cmd5.Parameters.AddWithValue("@sl_invoice_no", invoiceno);
                conn.Open();
                cmd5.ExecuteNonQuery();
                conn.Close();
            }
           

            this.BindDataIntoRepeater();
        }
        else
        {
            Response.Redirect("../access_denied.aspx");

        }
    }
    protected void close()
    {

        ScriptManager.RegisterStartupScript(this, GetType(), "Modal", "Closepopup();", true);
    }




    protected void Txt_sr_invoice_TextChanged(object sender, EventArgs e)
    {
        cmd8 = new SqlCommand("select * from tbl_order where sl_invoice_no like '%" + Txt_sr_invoice.Text + "%' Order By sl_id desc", conn);
        adapt8 = new SqlDataAdapter(cmd8);
        DataTable dt8 = new DataTable();
        adapt8.Fill(dt8);
        if (dt8.Rows.Count > 0)
        {
            Repeater1.DataSource = dt8;
            Repeater1.DataBind();
            Lbl_msg2.Text = "";
        }
        else
        {
            Repeater1.DataSource = null;
            Repeater1.DataBind();
            Lbl_msg2.Text = "No Item Found !!!";
        }
    }

    protected void Txt_sr_date_TextChanged(object sender, EventArgs e)
    {
        cmd9 = new SqlCommand("select * from tbl_order where sl_date like '%" + Txt_sr_date.Text + "%' Order By sl_id desc", conn);
        adapt9 = new SqlDataAdapter(cmd9);
        DataTable dt9 = new DataTable();
        adapt9.Fill(dt9);
        if (dt9.Rows.Count > 0)
        {
            Repeater1.DataSource = dt9;
            Repeater1.DataBind();
            Lbl_msg2.Text = "";
        }
        else
        {
            Repeater1.DataSource = null;
            Repeater1.DataBind();
            Lbl_msg2.Text = "No Item Found !!!";
        }
    }

    protected void Txt_sr_name_TextChanged(object sender, EventArgs e)
    {
        cmd10 = new SqlCommand("select * from tbl_order where sl_customer_name like '%" + Txt_sr_name.Text + "%' Order By sl_id desc", conn);
        adapt10 = new SqlDataAdapter(cmd10);
        DataTable dt10 = new DataTable();
        adapt10.Fill(dt10);
        if (dt10.Rows.Count > 0)
        {
            Repeater1.DataSource = dt10;
            Repeater1.DataBind();
            Lbl_msg2.Text = "";
        }
        else
        {
            Repeater1.DataSource = null;
            Repeater1.DataBind();
            Lbl_msg2.Text = "No Item Found !!!";
        }
    }

    protected void Txt_sr_contact_TextChanged(object sender, EventArgs e)
    {
        cmd11 = new SqlCommand("select * from tbl_order where sl_customer_contact like '%" + Txt_sr_contact.Text + "%' Order By sl_id desc", conn);
        adapt11 = new SqlDataAdapter(cmd11);
        DataTable dt11 = new DataTable();
        adapt11.Fill(dt11);
        if (dt11.Rows.Count > 0)
        {
            Repeater1.DataSource = dt11;
            Repeater1.DataBind();
            Lbl_msg2.Text = "";
        }
        else
        {
            Repeater1.DataSource = null;
            Repeater1.DataBind();
            Lbl_msg2.Text = "No Item Found !!!";
        }
    }



    public override void VerifyRenderingInServerForm(Control control)
    {
        /* Verifies that the control is rendered */
    }
   

    public void FillRepeater6()
    {

        cmd14 = new SqlCommand("select *  from tbl_order", conn);
        adapt14 = new SqlDataAdapter(cmd14);
        dt14 = new DataTable();
        adapt14.Fill(dt14);
        if (dt14.Rows.Count > 0)
        {
            if (dt14.Rows[0][0] == System.DBNull.Value)
            {
                lbl_total_invoice_amount.Text = "0";
            }
            else
            {
                lbl_total_invoice_amount.Text = dt14.Compute("sum(sl_total)", string.Empty).ToString(); //dt14.Rows[0][0].ToString();
            }
        }


    }

    public void FillRepeater7()
    {

        cmd15 = new SqlCommand("select count(sl_id) from tbl_order", conn);
        adapt15 = new SqlDataAdapter(cmd15);
        dt15 = new DataTable();

        adapt15.Fill(dt15);
        if (dt15.Rows.Count > 0)
        {
            if (dt15.Rows[0][0] == System.DBNull.Value)
            {
                lbl_total_invoice.Text = "0";
            }
            else
            {
                lbl_total_invoice.Text = dt15.Rows[0][0].ToString(); ;

            }


        }

    }


    protected void Repeater1_ItemCreated(object sender, RepeaterItemEventArgs e)
    {

    }
   
    protected void Repeater1_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        SqlCommand cmd16 = new SqlCommand("select * from tbl_feature", conn);
        SqlDataAdapter adapt16 = new SqlDataAdapter(cmd16);
        DataTable dt16 = new DataTable();
        adapt16.Fill(dt16);
        if (dt16.Rows.Count > 0)
        {
            del_inv = Convert.ToInt32(dt16.Rows[0]["fe_del"]);
        }

        if (e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
        {
            Label tr = e.Item.FindControl("lbl_pending") as Label;

            if (del_inv == 0)
            {
                e.Item.FindControl("LinkButton1").Visible = false;
            }
            else
            {
                e.Item.FindControl("LinkButton1").Visible = true;
            }

            DataRowView drv = e.Item.DataItem as DataRowView;


            String inv = drv["sl_invoice_no"].ToString();

            SqlCommand cmd = new SqlCommand("select count(s_id) from tbl_order_invoice where s_invoice_no='" + inv + "' AND s_status='Pending'", conn);
            SqlDataAdapter adapt = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapt.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                tr.Text = dt.Rows[0][0].ToString();
            }
            

        }

    }
}