using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

public partial class Bank_Cheque_transaction : System.Web.UI.Page
{
    SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["String"].ConnectionString);
    SqlCommand cmd2, cmd3, cmd4, cmd8, cmd9, cmd10, cmd11, cmd12, cmd13, cmd14, cmd16;
    SqlDataAdapter adapt2, adapt3, adapt8, adapt9, adapt10, adapt11, adapt12, adapt13, adapt14, adapt16;
    DataTable dt1, dt2, dt8, dt9, dt10, dt11, dt12, dt13, dt14, dt16;
    readonly PagedDataSource _pgsource = new PagedDataSource();
    int _firstIndex, _lastIndex;
    private int _pageSize = 25;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["a_email"] != null)
        {
            if (Page.IsPostBack) return;
            BindDataIntoRepeater();
            //this.FillRepeater();
        
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
        var da = new SqlDataAdapter("Select * From tbl_sale_invoice_payment where si_mode='Cheque' Order By si_id desc", con);
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
        cmd2 = new SqlCommand("Select * From tbl_customer_payment where cp_mode='Cheque' Order By cp_id desc", conn);
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
    protected void DeleteTransaction(object sender, EventArgs e)
    {
        int TransactionId = int.Parse(((sender as LinkButton).NamingContainer.FindControl("lbl_id") as Label).Text);

        using (SqlCommand cmd4 = new SqlCommand("DELETE FROM tbl_customer_payment WHERE cp_id = @cp_id", conn))
        {
            cmd4.Parameters.AddWithValue("@cp_id", TransactionId);
            conn.Open();
            cmd4.ExecuteNonQuery();
            conn.Close();
        }


        this.BindDataIntoRepeater();
    }

    protected void Repeater1_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if (e.CommandName.Equals("showid"))
        {
            //get data
            string CarrierName = e.CommandArgument.ToString();
            cmd2 = new SqlCommand("select * from tbl_customer_payment where cp_id='" + CarrierName + "'", conn);
            adapt2 = new SqlDataAdapter(cmd2);
            dt1 = new DataTable();
            adapt2.Fill(dt1);
            if (dt1.Rows.Count > 0)
            {
                lbl_name.Text = dt1.Rows[0]["cp_customer_name"].ToString();
                lbl_balance.Text = dt1.Rows[0]["cp_balance"].ToString();
                lbl_advance.Text = dt1.Rows[0]["cp_advance"].ToString();
                lbl_payment_mode.Text = dt1.Rows[0]["cp_mode"].ToString();
                lbl_total_balance.Text = dt1.Rows[0]["cp_total_balance"].ToString();
               

            }
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Modal", "ShowModel();", true);
        }
        if (e.CommandName.Equals("editid"))
        {
            //get data
            string CarrierName = e.CommandArgument.ToString();
            cmd2 = new SqlCommand("select * from tbl_customer_payment where cp_id='" + CarrierName + "'", conn);
            adapt2 = new SqlDataAdapter(cmd2);
            dt1 = new DataTable();
            adapt2.Fill(dt1);
            if (dt1.Rows.Count > 0)
            {
                Txt_id.Value = dt1.Rows[0]["cp_id"].ToString();
                Txt_name.Text = dt1.Rows[0]["cp_customer_name"].ToString();
               
                Txt_balance.Text = dt1.Rows[0]["cp_balance"].ToString();
                Txt_advance.Text = dt1.Rows[0]["cp_advance"].ToString();
                Dd_payment_mode.SelectedItem.Text = dt1.Rows[0]["cp_mode"].ToString();
                Txt_total_balance.Text = dt1.Rows[0]["cp_total_balance"].ToString();




            }

            ScriptManager.RegisterStartupScript(this, this.GetType(), "Modal", "ShowModel2();", true);
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        SqlCommand cmd7 = new SqlCommand("UPDATE tbl_customer_payment SET cp_customer_name='" + Txt_name.Text.Trim() + "',cp_balance='" + Txt_balance.Text.Trim() + "',cp_advance='" + Txt_advance.Text.Trim() + "',cp_mode='" + Dd_payment_mode.SelectedItem.Text.Trim() + "',cp_total_balance='" + Txt_total_balance.Text.Trim() + "' WHERE cp_id='" + Txt_id.Value.Trim() + "'", conn);

        conn.Open();
        cmd7.ExecuteNonQuery();
        conn.Close();
        //Lbl_message.Text = "" + Txt_customer_name.Text + " Added Successfully!!!";
        // Page.Response.Redirect(Page.Request.RawUrl.ToString(), true);
        string redirectScript = " window.location.href = 'cheque_transaction.aspx';";
        System.Web.UI.ScriptManager.RegisterStartupScript(this, GetType(), "displayalertmessage", "alert('Cheque Transaction Updated Successfully!!!');" + redirectScript, true);


    }

   
    public override void VerifyRenderingInServerForm(Control control)
    {
        /* Verifies that the control is rendered */
    }
    protected void excel_export(object sender, EventArgs e)
    {

        try
        {
            string date = DateTime.Now.ToString("dd-MM-yyyy--HH-mm");
            var da = new SqlDataAdapter("Select cp_id as [ID],cp_date as [Date],cp_customer_name as [Customer Name],cp_balance as [Balance],cp_advance as [Payment],cp_total_balance as [Total Balance] From tbl_customer_payment where cp_mode='Cheque' Order By cp_id desc", conn);
            var dt = new DataTable();
            da.Fill(dt);
            grdpro.DataSource = dt;
            grdpro.DataBind();


            Response.Clear();
            Response.Charset = "";
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.ContentType = "application/vnd.xls";
            Response.AddHeader("content-disposition", "attachment;filename=Cheque Transaction-" + date + ".xls");

            System.IO.StringWriter sw = new System.IO.StringWriter();
            HtmlTextWriter htw = new HtmlTextWriter(sw);
            grdpro.RenderControl(htw);
            System.Text.StringBuilder sb1 = new System.Text.StringBuilder();
            sb1 = sb1.Append("<table cellspacing='0' cellpadding='0' width='100 % ' align='center' border='1'>" + sw.ToString() + "</table>");
            sw = null;
            htw = null;
            Response.Write(sb1.ToString());
            sb1.Remove(0, sb1.Length);
            Response.Flush();
            Response.End();
        }
        catch (Exception ex)
        {

        }
        finally
        {

        }
    }

    protected void pdf_export(object sender, EventArgs e)
    {

    }

    
}