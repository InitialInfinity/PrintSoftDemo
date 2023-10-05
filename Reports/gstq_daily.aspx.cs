using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

public partial class Reports_gstq_daily : System.Web.UI.Page
{
    SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["String"].ConnectionString);
    SqlCommand cmd2, cmd3, cmd14, cmd15;
    SqlDataAdapter adapt2, adapt3, adapt14, adapt15;
    DataTable dt1, dt2, dt14, dt15;
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
        var da = new SqlDataAdapter("Select * From tbl_gst_quotation WHERE qu_date >= CONVERT (DateTime, DATEDIFF(DAY, 0, GETDATE())) Order By qu_id desc", con);
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
        cmd2 = new SqlCommand("select * from tbl_gst_quotation", conn);
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
    protected void DeleteSale(object sender, EventArgs e)
    {
        String invoiceno = ((sender as LinkButton).NamingContainer.FindControl("lbl_invoice") as Label).Text;
        
        
        using (SqlCommand cmd4 = new SqlCommand("DELETE FROM tbl_gst_quotation_details WHERE q_quotation_no = @q_quotation_no", conn))
        {

            cmd4.Parameters.AddWithValue("@q_quotation_no", invoiceno);
            conn.Open();
            cmd4.ExecuteNonQuery();
            conn.Close();
        }
        using (SqlCommand cmd5 = new SqlCommand("DELETE FROM tbl_gst_quotation WHERE qu_invoice_no = @qu_invoice_no", conn))
        {
            cmd5.Parameters.AddWithValue("@qu_invoice_no", invoiceno);
            conn.Open();
            cmd5.ExecuteNonQuery();
            conn.Close();
        }

        this.BindDataIntoRepeater();
    }
    protected void close()
    {

        ScriptManager.RegisterStartupScript(this, GetType(), "Modal", "Closepopup();", true);
    }
    protected void excel_export(object sender, EventArgs e)
    {

        Response.Clear();
        Response.Charset = "";
        Response.Cache.SetCacheability(HttpCacheability.NoCache);
        Response.ContentType = "application/vnd.xls";
        Response.AddHeader("content-disposition", "attachment;filename=" + "GSTQuotationReport.xls");

        System.IO.StringWriter sw = new System.IO.StringWriter();
        HtmlTextWriter htw = new HtmlTextWriter(sw);
        Repeater1.RenderControl(htw);
        System.Text.StringBuilder sb1 = new System.Text.StringBuilder();
        sb1 = sb1.Append("<table cellspacing='0' cellpadding='0' width='100 % ' align='center' border='1'>" + sw.ToString() + "</table>");
        sw = null;
        htw = null;
        Response.Write(sb1.ToString());
        sb1.Remove(0, sb1.Length);
        Response.Flush();
        Response.End();
    }

    protected void pdf_export(object sender, EventArgs e)
    {

    }
}