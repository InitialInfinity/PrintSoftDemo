using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using System.Web.Services;
using System.Globalization;

[System.Web.Script.Services.ScriptService]
public partial class _Default : System.Web.UI.Page
{
	SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["String"].ConnectionString);
	decimal a, b, c, d, e, f, g, h, i, j, k, l, m, n, o, p, q, r, s, t;
	string admin_email;
	decimal total_sale, total_est, total_amt, total_pur, total_exp, total_sal, putotal, rputotal, ptotal;
	decimal damsale, damest, dbalsale, dbalest, dsqsale, dsqest;
	CultureInfo inr = new CultureInfo("hi-IN");
	protected void Page_Load(object sender, EventArgs e)
	{
		if (Session["a_email"] != null || Session["admin_email"] != null)
		{
			//date time 
			DateTime serverTime = DateTime.Now; // gives you current Time in server timeZone
			DateTime utcTime = serverTime.ToUniversalTime(); // convert it to Utc using timezone setting of server computer

			TimeZoneInfo tzi = TimeZoneInfo.FindSystemTimeZoneById("India Standard Time");
			DateTime localTime = TimeZoneInfo.ConvertTimeFromUtc(utcTime, tzi); // convert from utc to local

			System.Threading.Thread.Sleep(100);
			string currenttime = localTime.ToLongTimeString();
			lblcurrenttime.Text = currenttime;

			//end

			SqlCommand cmd4 = new SqlCommand("select * from tbl_admin_login", conn);
			SqlDataAdapter adapt4 = new SqlDataAdapter(cmd4);
			DataTable dt4 = new DataTable();
			adapt4.Fill(dt4);
			if (dt4.Rows.Count > 0)
			{
				admin_email = dt4.Rows[0]["a_email"].ToString();
			}
			if (admin_email.ToString() == Session["a_email"].ToString() || Session["admin_email"] != null)
			{
				FillDaily();
				DailyExpense();
				Expense();
				MonthlyProfit();
				FillRepeater();
				TotalVendors();
				TotalInvoice();
				TotalProduct();
				TotalQuote();
				TotalExpense();
				FillRepeater0();
				FillRepeater2();
				FillRepeater3();
				FillRepeater4();
				FillRepeater5();
				FillRepeater6();
				FillRepeater7();
				Panel1.Visible = true;

			}
			else
			{
				Panel1.Visible = false;

			}

		}
		else
		{
			Response.Redirect("login.aspx");
		}
	}

	public void FillRepeater0()
	{
		SqlCommand cmd = new SqlCommand("Select * From tbl_sale INNER JOIN tbl_customer ON tbl_sale.c_id = tbl_customer.c_id WHERE sl_invoice_date >= DATEADD(MONTH, DATEDIFF(MONTH, 0, GETDATE()), 0) AND sl_invoice_date <  DATEADD(MONTH, DATEDIFF(MONTH, 0, GETDATE()) + 1, 0) Order By sl_id desc", conn);
		SqlDataAdapter adapt = new SqlDataAdapter(cmd);
		DataTable dt = new DataTable();
		adapt.Fill(dt);
		if (dt.Rows.Count > 0)
		{

			total_sale = Convert.ToDecimal(dt.Compute("Sum(sl_total)", string.Empty));
		}
		else
		{
			total_sale = 0;
		}


	}

	public void FillRepeater2()
	{
		SqlCommand cmd = new SqlCommand("Select * From tbl_estimate INNER JOIN tbl_customer ON tbl_estimate.c_id = tbl_customer.c_id WHERE est_invoice_date >= DATEADD(MONTH, DATEDIFF(MONTH, 0, GETDATE()), 0) AND est_invoice_date <  DATEADD(MONTH, DATEDIFF(MONTH, 0, GETDATE()) + 1, 0) Order By est_id desc", conn);
		SqlDataAdapter adapt = new SqlDataAdapter(cmd);
		DataTable dt = new DataTable();
		adapt.Fill(dt);
		if (dt.Rows.Count > 0)
		{

			total_est = Convert.ToDecimal(dt.Compute("Sum(est_total)", string.Empty));
		}
		else
		{
			total_est = 0;
		}
	}

	public void FillRepeater3()
	{
		SqlCommand cmd = new SqlCommand("Select * From tbl_purchase  INNER JOIN tbl_vendor ON tbl_purchase.v_id = tbl_vendor.v_id  WHERE pu_invoice_date >= DATEADD(MONTH, DATEDIFF(MONTH, 0, GETDATE()), 0) AND pu_invoice_date <  DATEADD(MONTH, DATEDIFF(MONTH, 0, GETDATE()) + 1, 0) Order By pu_id desc", conn);
		SqlDataAdapter adapt = new SqlDataAdapter(cmd);
		DataTable dt = new DataTable();
		adapt.Fill(dt);
		if (dt.Rows.Count > 0)
		{

			total_pur = Convert.ToDecimal(dt.Compute("Sum(pu_total)", string.Empty));
			lbl_total_pur.Text = dt.Compute("Sum(pu_total)", string.Empty).ToString();
		}
		else
		{
			total_pur = 0;
			lbl_total_pur.Text = "0";
		}
	}

	public void FillRepeater4()
	{
		SqlCommand cmd = new SqlCommand("Select * From tbl_expense WHERE e_date >= DATEADD(MONTH, DATEDIFF(MONTH, 0, GETDATE()), 0) AND e_date <  DATEADD(MONTH, DATEDIFF(MONTH, 0, GETDATE()) + 1, 0) Order By e_id desc", conn);
		SqlDataAdapter adapt = new SqlDataAdapter(cmd);
		DataTable dt = new DataTable();
		adapt.Fill(dt);
		if (dt.Rows.Count > 0)
		{

			total_exp = Convert.ToDecimal(dt.Compute("Sum(e_amount)", string.Empty));
			lbl_total_exp.Text = dt.Compute("Sum(e_amount)", string.Empty).ToString();
		}
		else
		{
			total_exp = 0;
			lbl_total_exp.Text = "0";
		}
	}

	public void FillRepeater5()
	{
		SqlCommand cmd = new SqlCommand("Select * From tbl_salary WHERE sal_date >= DATEADD(MONTH, DATEDIFF(MONTH, 0, GETDATE()), 0) AND sal_date <  DATEADD(MONTH, DATEDIFF(MONTH, 0, GETDATE()) + 1, 0) Order By sal_id desc", conn);
		SqlDataAdapter adapt = new SqlDataAdapter(cmd);
		DataTable dt = new DataTable();
		adapt.Fill(dt);
		if (dt.Rows.Count > 0)
		{

			total_sal = Convert.ToDecimal(dt.Compute("Sum(sal_pay)", string.Empty));
			lbl_total_sal.Text = dt.Compute("Sum(sal_pay)", string.Empty).ToString();
		}
		else
		{
			total_sal = 0;
			lbl_total_sal.Text = "0";
		}
	}
	public void FillRepeater6()
	{
		SqlCommand cmd = new SqlCommand("Select * From tbl_sale_invoice_payment INNER JOIN tbl_customer ON tbl_sale_invoice_payment.c_id = tbl_customer.c_id WHERE si_date >= DATEADD(MONTH, DATEDIFF(MONTH, 0, GETDATE()), 0) AND si_date <  DATEADD(MONTH, DATEDIFF(MONTH, 0, GETDATE()) + 1, 0) order by si_date desc", conn);
		SqlDataAdapter adapt = new SqlDataAdapter(cmd);
		DataTable dt = new DataTable();
		adapt.Fill(dt);
		if (dt.Rows.Count > 0)
		{

			lbl_total_adv.Text = dt.Compute("Sum(si_pay)", string.Empty).ToString();


		}
		else
		{
			lbl_total_adv.Text = "0";
		}
	}
	public void FillRepeater7()
	{

		lbl_total_amt.Text = (total_sale + total_est).ToString();

		lbl_total_col.Text = (Convert.ToDecimal(lbl_total_adv.Text) - (total_pur + total_exp + total_sal)).ToString();
	}
	protected void MonthlyProfit()
	{
		SqlCommand cmd1 = new SqlCommand("select SUM(sl_total) from tbl_sale WHERE sl_invoice_date >= DATEADD(MONTH, DATEDIFF(MONTH, 0, GETDATE()), 0) AND sl_invoice_date <  DATEADD(MONTH, DATEDIFF(MONTH, 0, GETDATE()) + 1, 0)", conn);
		SqlDataAdapter adapt1 = new SqlDataAdapter(cmd1);
		DataTable dt1 = new DataTable();
		adapt1.Fill(dt1);
		SqlCommand cmd3 = new SqlCommand("select SUM(est_total) from tbl_estimate WHERE est_invoice_date >= DATEADD(MONTH, DATEDIFF(MONTH, 0, GETDATE()), 0) AND est_invoice_date <  DATEADD(MONTH, DATEDIFF(MONTH, 0, GETDATE()) + 1, 0)", conn);
		SqlDataAdapter adapt3 = new SqlDataAdapter(cmd3);
		DataTable dt3 = new DataTable();
		adapt3.Fill(dt3);

		if (dt1.Rows.Count > 0 && dt3.Rows.Count > 0)
		{

			if (dt3.Rows[0][0] == System.DBNull.Value)
			{
				b = 0;
			}
			if (dt1.Rows[0][0] == System.DBNull.Value)
			{
				a = 0;
			}
			if (dt3.Rows[0][0] != System.DBNull.Value)
			{

				b = Convert.ToDecimal(dt3.Rows[0][0]);
			}
			if (dt1.Rows[0][0] != System.DBNull.Value)
			{
				a = Convert.ToDecimal(dt1.Rows[0][0]);

			}
			c = a + b;
			decimal i = Convert.ToDecimal(c.ToString());
			Lbl_monthlysale.Text = i.ToString("N", inr);
		}


		SqlCommand cmd2 = new SqlCommand("select SUM(pu_total) from tbl_purchase WHERE pu_invoice_date >= DATEADD(MONTH, DATEDIFF(MONTH, 0, GETDATE()), 0) AND pu_invoice_date <  DATEADD(MONTH, DATEDIFF(MONTH, 0, GETDATE()) + 1, 0)", conn);
		SqlDataAdapter adapt2 = new SqlDataAdapter(cmd2);
		DataTable dt2 = new DataTable();
		adapt2.Fill(dt2);
		SqlCommand cmd22 = new SqlCommand("select SUM(rpu_total) from tbl_roll_purchase WHERE rpu_invoice_date >= DATEADD(MONTH, DATEDIFF(MONTH, 0, GETDATE()), 0) AND rpu_invoice_date <  DATEADD(MONTH, DATEDIFF(MONTH, 0, GETDATE()) + 1, 0)", conn);
		SqlDataAdapter adapt22 = new SqlDataAdapter(cmd22);
		DataTable dt22 = new DataTable();
		adapt22.Fill(dt22);

		if (dt2.Rows.Count > 0 && dt22.Rows.Count > 0)
		{

			if (dt22.Rows[0][0] == System.DBNull.Value)
			{
				s = 0;
			}
			if (dt2.Rows[0][0] == System.DBNull.Value)
			{
				r = 0;
			}
			if (dt22.Rows[0][0] != System.DBNull.Value)
			{

				s = Convert.ToDecimal(dt22.Rows[0][0]);
			}
			if (dt2.Rows[0][0] != System.DBNull.Value)
			{
				r = Convert.ToDecimal(dt2.Rows[0][0]);

			}
			t = r + s;
			//t = Convert.ToDecimal(s.ToString());
			Lbl_monthlypurchase.Text = t.ToString("N", inr);
		}

		//string query001 = "select pu_invoice_date,pu_total from tbl_purchase where pu_invoice_date = '" + DateTime.Now.Year.ToString() + "' and pu_invoice_date = '" + DateTime.Now.Year.ToString() + "'";
		//SqlCommand cmd001 = new SqlCommand(query001, conn);
		//SqlDataAdapter adapt001 = new SqlDataAdapter(cmd001);
		//DataTable dt001 = new DataTable();
		//adapt001.Fill(dt001);
		//if (dt001.Rows.Count > 0)
		//{
		//    putotal = Convert.ToDecimal(dt001.Rows[0][0]);
		//}
		//string query002 = "select rpu_invoice_date,rpu_total from tbl_roll_purchase where rpu_invoice_date = '" + DateTime.Now.Year.ToString() + "' and rpu_invoice_date = '" + DateTime.Now.Year.ToString() + "'";
		//SqlCommand cmd002 = new SqlCommand(query002, conn);
		//SqlDataAdapter adapt002 = new SqlDataAdapter(cmd002);
		//DataTable dt002 = new DataTable();
		//adapt002.Fill(dt002);
		//if (dt002.Rows.Count > 0)
		//{
		//    rputotal = Convert.ToDecimal(dt002.Rows[0][0]);
		//}
		//ptotal = putotal + rputotal;
		//pttotal.Text = ptotal.ToString();
		//if (dt2.Rows.Count > 0)
		//{
		//    Lbl_monthlypurchase.Text = dt2.Rows[0][0].ToString();
		//}
		//if (Lbl_monthlypurchase.Text == string.Empty)
		//{
		//    Lbl_monthlypurchase.Text = "0";
		//}
		decimal sale, purchase, expense;
		sale = Convert.ToDecimal(Lbl_monthlysale.Text);
		purchase = Convert.ToDecimal(Lbl_monthlypurchase.Text);
		expense = Convert.ToDecimal(Lbl_monthlyexpense.Text);
		decimal profit = Convert.ToDecimal(sale) - ((Convert.ToDecimal(purchase) + Convert.ToDecimal(expense)));
		//decimal profit = Convert.ToDecimal(sale) - Convert.ToDecimal(purchase) - Convert.ToDecimal(expense);
		decimal v = Convert.ToDecimal(profit.ToString());
		Lbl_monthlyprofit.Text = v.ToString("N", inr);
	}

	protected void FillDaily()
	{
		SqlCommand cmd = new SqlCommand("Select * From tbl_sale WHERE sl_invoice_date >= DATEADD(DAY, DATEDIFF(DAY, 0, GETDATE()), 0) AND sl_invoice_date <  DATEADD(DAY, DATEDIFF(DAY, 0, GETDATE()) + 1, 0) Order By sl_id desc", conn);
		SqlDataAdapter adapt = new SqlDataAdapter(cmd);
		DataTable dt = new DataTable();
		adapt.Fill(dt);
		if (dt.Rows.Count > 0)
		{

			damsale = Convert.ToDecimal(dt.Compute("Sum(sl_total)", string.Empty));
			dbalsale = Convert.ToDecimal(dt.Compute("Sum(sl_balance)", string.Empty));
		}
		else
		{
			damsale = 0;
			dbalsale = 0;
		}
		SqlCommand cmd2 = new SqlCommand("Select * From tbl_estimate WHERE est_invoice_date >= DATEADD(DAY, DATEDIFF(DAY, 0, GETDATE()), 0) AND est_invoice_date <  DATEADD(DAY, DATEDIFF(DAY, 0, GETDATE()) + 1, 0) Order By est_id desc", conn);
		SqlDataAdapter adapt2 = new SqlDataAdapter(cmd2);
		DataTable dt2 = new DataTable();
		adapt2.Fill(dt2);
		if (dt2.Rows.Count > 0)
		{

			damest = Convert.ToDecimal(dt2.Compute("Sum(est_total)", string.Empty));
			dbalest = Convert.ToDecimal(dt2.Compute("Sum(est_balance)", string.Empty));
		}
		else
		{
			damest = 0;
			dbalest = 0;
		}
		decimal at = Convert.ToDecimal((damsale + damest).ToString());
		lbl_daily_sales.Text = at.ToString("N", inr);

		decimal ayt = Convert.ToDecimal((dbalsale + dbalest).ToString());
		lbl_daily_sales.Text = ayt.ToString("N", inr);
		lbl_daily_balance.Text = (dbalsale + dbalest).ToString("N", inr);

		SqlCommand cmd3 = new SqlCommand("Select * From tbl_sale_invoice_payment WHERE si_date >= DATEADD(DAY, DATEDIFF(DAY, 0, GETDATE()), 0) AND si_date <  DATEADD(DAY, DATEDIFF(DAY, 0, GETDATE()) + 1, 0) Order By si_id desc", conn);
		SqlDataAdapter adapt3 = new SqlDataAdapter(cmd3);
		DataTable dt3 = new DataTable();
		adapt3.Fill(dt3);
		if (dt3.Rows.Count > 0)
		{

			decimal mat = Convert.ToDecimal(dt3.Compute("Sum(si_pay)", string.Empty).ToString());
			lbl_daily_advance.Text = mat.ToString("N", inr);
		}
		else
		{
			lbl_daily_advance.Text = "0";
		}
	}


	protected void Expense()
	{
		SqlCommand cmd4 = new SqlCommand("select Sum(e_amount) from tbl_expense WHERE e_date >= DATEADD(MONTH, DATEDIFF(MONTH, 0, GETDATE()), 0) AND e_date <  DATEADD(MONTH, DATEDIFF(MONTH, 0, GETDATE()) + 1, 0)", conn);
		SqlDataAdapter adapt4 = new SqlDataAdapter(cmd4);
		DataTable dt4 = new DataTable();
		adapt4.Fill(dt4);
		if (dt4.Rows.Count > 0)
		{

			if (dt4.Rows[0][0] == System.DBNull.Value)
			{
				d = 0;
			}
			else
			{

				d = Convert.ToDecimal(dt4.Rows[0][0]);
			}
		}

		//SqlCommand cmd5 = new SqlCommand("select Sum(sal_pay) from tbl_salary WHERE sal_date >= DATEADD(MONTH, DATEDIFF(MONTH, 0, GETDATE()), 0) AND sal_date <  DATEADD(MONTH, DATEDIFF(MONTH, 0, GETDATE()) + 1, 0)", conn);
		//SqlDataAdapter adapt5 = new SqlDataAdapter(cmd5);
		//DataTable dt5 = new DataTable();
		//adapt5.Fill(dt5);
		//if (dt5.Rows.Count > 0)
		//{

		//    if (dt5.Rows[0][0] == System.DBNull.Value)
		//    {
		//        e = 0;
		//    }
		//    else
		//    {

		//        e = Convert.ToDecimal(dt5.Rows[0][0]);
		//    }
		//}
		//f = d + e;
		f = d;
		decimal u = Convert.ToDecimal(f.ToString());
		Lbl_monthlyexpense.Text = u.ToString("N", inr);

	}

	protected void DailyExpense()
	{
		SqlCommand cmd4 = new SqlCommand("select Sum(e_amount) from tbl_expense WHERE e_date >= DATEADD(DAY, DATEDIFF(DAY, 0, GETDATE()), 0) AND e_date <  DATEADD(DAY, DATEDIFF(DAY, 0, GETDATE()) + 1, 0)", conn);
		SqlDataAdapter adapt4 = new SqlDataAdapter(cmd4);
		DataTable dt4 = new DataTable();
		adapt4.Fill(dt4);
		if (dt4.Rows.Count > 0)
		{

			if (dt4.Rows[0][0] == System.DBNull.Value)
			{
				i = 0;
			}
			else
			{

				i = Convert.ToDecimal(dt4.Rows[0][0]);
			}
		}

		SqlCommand cmd5 = new SqlCommand("select Sum(sal_pay) from tbl_salary WHERE sal_date >= DATEADD(DAY, DATEDIFF(DAY, 0, GETDATE()), 0) AND sal_date <  DATEADD(DAY, DATEDIFF(DAY, 0, GETDATE()) + 1, 0)", conn);
		SqlDataAdapter adapt5 = new SqlDataAdapter(cmd5);
		DataTable dt5 = new DataTable();
		adapt5.Fill(dt5);
		if (dt5.Rows.Count > 0)
		{

			if (dt5.Rows[0][0] == System.DBNull.Value)
			{
				j = 0;
			}
			else
			{

				j = Convert.ToDecimal(dt5.Rows[0][0]);
			}
		}

		k = i + j;
		decimal put = Convert.ToDecimal(k.ToString());
		lbl_daily_expense.Text = put.ToString("N", inr);

	}
	public void FillRepeater()
	{
		SqlCommand cmd3 = new SqlCommand("select top 6 * from tbl_sale inner join tbl_customer on tbl_sale.c_id=tbl_customer.c_id order by sl_id desc", conn);
		SqlDataAdapter adapt3 = new SqlDataAdapter(cmd3);
		DataTable dt3 = new DataTable();
		adapt3.Fill(dt3);
		if (dt3.Rows.Count > 0)
		{
			Repeater1.DataSource = dt3;
			Repeater1.DataBind();
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
	protected void TotalVendors()
	{
		SqlCommand cmd5 = new SqlCommand("select Count(v_id) from tbl_vendor", conn);
		SqlDataAdapter adapt5 = new SqlDataAdapter(cmd5);
		DataTable dt5 = new DataTable();
		adapt5.Fill(dt5);
		if (dt5.Rows.Count > 0)
		{
			lbl_total_vendor.Text = dt5.Rows[0][0].ToString();
		}
		else
		{
			lbl_total_vendor.Text = "0";
		}
	}
	protected void TotalInvoice()
	{
		decimal a, b, c;

		SqlCommand cmd1 = new SqlCommand("select count(sl_id) from tbl_sale", conn);
		SqlDataAdapter adapt1 = new SqlDataAdapter(cmd1);
		DataTable dt1 = new DataTable();
		adapt1.Fill(dt1);
		if (dt1.Rows.Count > 0)
		{
			a = Convert.ToInt32(dt1.Rows[0][0]);
		}
		else
		{
			a = 0;
		}
		SqlCommand cmd2 = new SqlCommand("select count(est_id) from tbl_estimate", conn);
		SqlDataAdapter adapt2 = new SqlDataAdapter(cmd2);
		DataTable dt2 = new DataTable();
		adapt2.Fill(dt2);
		if (dt2.Rows.Count > 0)
		{

			b = Convert.ToInt32(dt2.Rows[0][0]);
		}
		else
		{
			b = 0;
		}
		c = a + b;
		lbl_total_invoice.Text = c.ToString();
	}
	protected void TotalProduct()
	{
		decimal a, b, c;

		SqlCommand cmd1 = new SqlCommand("select count(p_id) from tbl_product", conn);
		SqlDataAdapter adapt1 = new SqlDataAdapter(cmd1);
		DataTable dt1 = new DataTable();
		adapt1.Fill(dt1);
		if (dt1.Rows.Count > 0)
		{
			a = Convert.ToInt32(dt1.Rows[0][0]);
		}
		else
		{
			a = 0;
		}
		SqlCommand cmd2 = new SqlCommand("select count(p_id) from tbl_purchase_product", conn);
		SqlDataAdapter adapt2 = new SqlDataAdapter(cmd2);
		DataTable dt2 = new DataTable();
		adapt2.Fill(dt2);
		if (dt2.Rows.Count > 0)
		{

			b = Convert.ToInt32(dt2.Rows[0][0]);
		}
		else
		{
			b = 0;
		}
		c = a + b;
		lbl_total_products.Text = c.ToString();
	}
	protected void TotalQuote()
	{
		decimal a, b, c;

		SqlCommand cmd1 = new SqlCommand("select count(qu_id) from tbl_gst_quotation", conn);
		SqlDataAdapter adapt1 = new SqlDataAdapter(cmd1);
		DataTable dt1 = new DataTable();
		adapt1.Fill(dt1);
		if (dt1.Rows.Count > 0)
		{
			a = Convert.ToInt32(dt1.Rows[0][0]);
		}
		else
		{
			a = 0;
		}
		SqlCommand cmd2 = new SqlCommand("select count(quw_id) from tbl_without_gst_quotation", conn);
		SqlDataAdapter adapt2 = new SqlDataAdapter(cmd2);
		DataTable dt2 = new DataTable();
		adapt2.Fill(dt2);
		if (dt2.Rows.Count > 0)
		{

			b = Convert.ToInt32(dt2.Rows[0][0]);
		}
		else
		{
			b = 0;
		}
		c = a + b;
		lbl_total_quotation.Text = c.ToString();
	}

	protected void TotalExpense()
	{
		int exp = 0;

		SqlCommand cmd1 = new SqlCommand("select sum(e_count) from tbl_expense", conn);
		SqlDataAdapter adapt1 = new SqlDataAdapter(cmd1);
		DataTable dt1 = new DataTable();
		adapt1.Fill(dt1);
		if ((dt1.Rows.Count > 0))
		{
			if (!string.IsNullOrEmpty(dt1.Rows[0][0].ToString()))
				exp = Convert.ToInt32(dt1.Rows[0][0].ToString());
		}
		else
		{
			exp = 0;
		}
		//lbl_exp_count.Text = exp.ToString();

	}
	//[System.Web.Services.WebMethod]
	//public static List<yearlyGraph> getGraphData()
	//{
	//    quickbillEntities DbModel = new quickbillEntities();
	//    List<yearlyGraph> GraphData = new List<yearlyGraph>();

	//    var lDayOfYear = new DateTime(DateTime.Now.Year, 12, 31);
	//    var fDayOfYear  = new DateTime(DateTime.Now.Year, 1, 1);
	//    List<int> monthNolist = new List<int>() { 01, 02, 03, 04, 05, 06, 07, 08, 09, 10, 11, 12 };
	//    string[] monthArr = new string[13];
	//    // Get all month abbrivated name
	//    for (int i = 0; i < 13; i++)
	//    {
	//        monthArr[i] = (new System.Globalization.CultureInfo("en-US")).DateTimeFormat.GetAbbreviatedMonthName(i + 1);
	//    }
	//    // get sales data
	//    var sTableData = (from d in DbModel.tbl_sale
	//                      where d.sl_invoice_date > fDayOfYear  && 
	//                      d.sl_invoice_date < lDayOfYear
	//                      select new
	//                      {
	//                          date = d.sl_invoice_date,
	//                          totat = d.sl_total,
	//                          qty = d.sl_total_quantity
	//                      }).ToList();

	//    // get earning data
	//    var eTableData = (from d in DbModel.tbl_purchase
	//                      where d.pu_invoice_date>fDayOfYear &&
	//                      d.pu_invoice_date < lDayOfYear
	//                      select new
	//                      {
	//                          date = d.pu_invoice_date,
	//                          totat = d.pu_total,
	//                      }).ToList();


	//    decimal[] salesallTotals = new decimal[13];
	//    decimal[] earningsallTotals = new decimal[13];

	//    decimal salesQty = 0;
	//    // calculate all sales total
	//    foreach (var item in sTableData)
	//    {
	//        int month = item.date.Value.Month;
	//        decimal total = Convert.ToDecimal(item.totat.ToString());
	//        for (int i = 0; i < monthNolist.Count; i++)
	//        {
	//            if (item.date.Value.Month == monthNolist[i])
	//            {

	//                salesallTotals[i] += total;
	//            }
	//        }
	//        salesQty += Convert.ToDecimal(item.qty.ToString());
	//    }

	//    // calculate all Earning total
	//    foreach (var item in eTableData)
	//    {
	//        int month = item.date.Value.Month;
	//        decimal total = Convert.ToDecimal(item.totat.ToString());
	//        for (int i = 0; i < monthNolist.Count; i++)
	//        {
	//            if (item.date.Value.Month == monthNolist[i])
	//            {

	//                earningsallTotals[i] += total;
	//            }
	//        }
	//    }




	//    // get expence total from databse table
	//    var expence = (from d in DbModel.tbl_expense
	//                   where d.e_date >fDayOfYear && d.e_date<lDayOfYear
	//                   group d by d.e_amount into g
	//                      select new
	//                      {
	//                          amount = g.Sum(p=> p.e_amount)
	//                      }).ToList();

	//    // get expence total from databse table
	//    var salryPayTotal = (from d in DbModel.tbl_salary
	//                         where d.sal_date >fDayOfYear && d.sal_date <lDayOfYear
	//                   group d by d.sal_pay into g
	//                   select new
	//                   {
	//                       salPay = g.Sum(p=> p.sal_pay)
	//                   }).ToList();

	//    var piChartValue = new piChartValues { salary = salryPayTotal[0].salPay.ToString() == "" ? "0" : salryPayTotal[0].salPay.ToString(),
	//                                            qty = salesQty.ToString(),
	//                                            exp = expence[0].ToString()==""?"0" : expence[0].amount.ToString()};

	//    for (int i = 0; i < monthArr.Length; i++)
	//    {
	//        if (i == monthArr.Length - 1)
	//        {
	//            GraphData.Add(new yearlyGraph { month = monthArr[i], stotal = salesallTotals[i].ToString(), etotal = earningsallTotals[i].ToString(),piChart=piChartValue });
	//        }
	//        else
	//        {
	//            GraphData.Add(new yearlyGraph { month = monthArr[i], stotal = salesallTotals[i].ToString(), etotal = earningsallTotals[i].ToString() });
	//        }
	//    }
	//    return GraphData;
	//}


	[System.Web.Services.WebMethod]
	public static List<yearlyGraph> getGraphData()
	{
		// quickbillEntities DbModel = new quickbillEntities();
		List<yearlyGraph> GraphData = new List<yearlyGraph>();
		SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["String"].ConnectionString);

		var lDayOfYear = new DateTime(DateTime.Now.Year, 12, 31);
		var fDayOfYear = new DateTime(DateTime.Now.Year, 1, 1);
		List<int> monthNolist = new List<int>() { 01, 02, 03, 04, 05, 06, 07, 08, 09, 10, 11, 12 };
		string[] monthArr = new string[13];
		// Get all month abbrivated name
		for (int i = 0; i < 13; i++)
		{
			monthArr[i] = (new System.Globalization.CultureInfo("en-US")).DateTimeFormat.GetAbbreviatedMonthName(i + 1);
		}

		// get sales data
		string query = "select sl_invoice_date,sl_total,sl_total_quantity from tbl_sale where sl_invoice_date > '" + fDayOfYear + "' and sl_invoice_date < '" + lDayOfYear + "'";
		SqlCommand cmd3 = new SqlCommand(query, conn);
		SqlDataAdapter adapt3 = new SqlDataAdapter(cmd3);
		DataTable dt3 = new DataTable();
		adapt3.Fill(dt3);
		List<sData> sTableData = new List<sData>();
		for (int i = 0; i < dt3.Rows.Count; i++)
		{
			sData temp = new sData();
			temp.date = Convert.ToDateTime(dt3.Rows[i][0].ToString());
			temp.total = dt3.Rows[i][1].ToString();
			temp.qty = dt3.Rows[i][2].ToString();
			sTableData.Add(temp);
		}


		// get earning data      

		string query1 = "select pu_invoice_date,pu_total from tbl_purchase where pu_invoice_date > '" + fDayOfYear + "' and pu_invoice_date < '" + lDayOfYear + "'";
		SqlCommand cmd1 = new SqlCommand(query1, conn);
		SqlDataAdapter adapt1 = new SqlDataAdapter(cmd1);
		DataTable dt1 = new DataTable();
		adapt1.Fill(dt1);
		List<eData> eTableData = new List<eData>();
		for (int i = 0; i < dt1.Rows.Count; i++)
		{
			eData temp = new eData();
			temp.date = Convert.ToDateTime(dt1.Rows[i][0].ToString());
			temp.total = dt1.Rows[i][1].ToString();
			eTableData.Add(temp);
		}


		decimal[] salesallTotals = new decimal[13];
		decimal[] earningsallTotals = new decimal[13];

		decimal salesQty = 0;
		// calculate all sales total
		foreach (var item in sTableData)
		{
			int month = item.date.Month;
			decimal total = Convert.ToDecimal(item.total.ToString());
			for (int i = 0; i < monthNolist.Count; i++)
			{
				if (item.date.Month == monthNolist[i])
				{

					salesallTotals[i] += total;
				}
			}
			salesQty += Convert.ToDecimal(item.qty.ToString());
		}

		// calculate all Earning total
		foreach (var item in eTableData)
		{
			int month = item.date.Month;
			decimal total = Convert.ToDecimal(item.total.ToString());
			for (int i = 0; i < monthNolist.Count; i++)
			{
				if (item.date.Month == monthNolist[i])
				{
					earningsallTotals[i] += total;
				}
			}
		}

		string expense_cat_query = "select cat_category_name from tbl_expense_category";
		SqlCommand exCatCmd = new SqlCommand(expense_cat_query, conn);
		SqlDataAdapter AdexCat = new SqlDataAdapter(exCatCmd);
		DataTable dtExCat = new DataTable();

		AdexCat.Fill(dtExCat);

		List<string> categoryList = new List<string>();

		for (int i = 0; i < dtExCat.Rows.Count; i++)
		{
			if (dtExCat.Rows[i][0] != null)
				categoryList.Add(dtExCat.Rows[i][0].ToString());
		}
		decimal amount = 0;
		List<expenseData> expenceData = new List<expenseData>();
		foreach (var item in categoryList)

		{
			// get expense total from databse table
			string query2 = "select e_amount from tbl_expense where e_date > '" + fDayOfYear + "' and e_date < '" + lDayOfYear + "' and e_category_name='" + item + "'";
			SqlCommand cmd2 = new SqlCommand(query2, conn);
			SqlDataAdapter adapt2 = new SqlDataAdapter(cmd2);
			DataTable dt2 = new DataTable();
			adapt2.Fill(dt2);
			decimal amount1 = 0;
			for (int i = 0; i < dt2.Rows.Count; i++)
			{
				if (dt2.Rows[i][0] != null)
					amount1 += Convert.ToDecimal(dt2.Rows[i][0].ToString());

			}
			expenceData.Add(new expenseData { lable = item, value = amount1.ToString() });
		}


		// get salary paid total from databse table


		string query4 = "select sal_pay from tbl_salary where sal_date > '" + fDayOfYear + "' and sal_date < '" + lDayOfYear + "'";
		SqlCommand cmd4 = new SqlCommand(query4, conn);
		SqlDataAdapter adapt4 = new SqlDataAdapter(cmd4);
		DataTable dt4 = new DataTable();
		adapt4.Fill(dt4);
		decimal salPay = 0;
		for (int i = 0; i < dt4.Rows.Count; i++)
		{
			if (dt4.Rows[i][0] != null)
			{
				if (dt4.Rows[i][0].ToString() == "")
				{
					salPay += 0;
				}
				else
				{
					salPay += Convert.ToDecimal(dt4.Rows[i][0].ToString());
				}
			}

		}


		var piChartValue = new piChartValues
		{
			salary = salPay.ToString(),
			qty = salesQty.ToString(),
			exp = amount.ToString()
		};

		for (int i = 0; i < monthArr.Length; i++)
		{
			if (i == monthArr.Length - 1)
			{
				GraphData.Add(new yearlyGraph { month = monthArr[i], stotal = salesallTotals[i].ToString(), etotal = earningsallTotals[i].ToString(), piChart = piChartValue, expenseData = expenceData });
			}
			else
			{
				GraphData.Add(new yearlyGraph { month = monthArr[i], stotal = salesallTotals[i].ToString(), etotal = earningsallTotals[i].ToString() });
			}
		}
		return GraphData;
	}

	//calender code here
	[WebMethod]
	public static List<object> getEvents()
	{
		SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["String"].ConnectionString);
		List<object> allEvents = new List<object>();
		SqlCommand cmd2 = new SqlCommand("select * from tbl_Calendar", conn);
		SqlDataAdapter adapt2 = new SqlDataAdapter(cmd2);
		DataTable dt2 = new DataTable();
		adapt2.Fill(dt2);

		for (int i = 0; i < dt2.Rows.Count; i++)
		{
			allEvents.Add(new
			{
				eventID = dt2.Rows[i][0].ToString(),
				title = dt2.Rows[i][1].ToString(),
				start = dt2.Rows[i][2].ToString(),
				end = dt2.Rows[i][3].ToString(),
				color = dt2.Rows[i][4] == null ? "" : dt2.Rows[i][4].ToString(),
				description = dt2.Rows[i][5] == null ? "" : dt2.Rows[i][5].ToString(),
				allDay = dt2.Rows[i][6]
			});
		}

		return allEvents;
	}


	[WebMethod]
	public static List<object> insertEvent(string title, string start, string end)
	{
		SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["String"].ConnectionString);
		SqlCommand cmd3 = new SqlCommand("insert into tbl_Calendar values(@title,@startDate,@endDate)", conn);

		cmd3.Parameters.AddWithValue("@title", title);
		cmd3.Parameters.AddWithValue("@startDate", DateTime.Parse(start));
		cmd3.Parameters.AddWithValue("@endDate", DateTime.Parse(end));
		cmd3.ExecuteNonQuery();


		List<object> allEvents = new List<object>();
		SqlCommand cmd2 = new SqlCommand("select * from tbl_Calendar", conn);
		SqlDataAdapter adapt2 = new SqlDataAdapter(cmd2);
		DataTable dt2 = new DataTable();
		adapt2.Fill(dt2);

		for (int i = 0; i < dt2.Rows.Count; i++)
		{
			allEvents.Add(new { id = dt2.Rows[i][0].ToString(), title = dt2.Rows[i][1].ToString(), start = dt2.Rows[i][2].ToString(), end = dt2.Rows[i][3].ToString() });
		}

		return allEvents;
	}


	[WebMethod]
	public static object SaveEvent(Event f)
	{
		bool status = false;
		SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["String"].ConnectionString);
		SqlCommand cmd2 = new SqlCommand("select * from tbl_Calendar where Id=" + f.EventID, conn);
		SqlDataAdapter adapt2 = new SqlDataAdapter(cmd2);
		DataTable dt2 = new DataTable();
		adapt2.Fill(dt2);


		if (f.EventID != 0)
		{

			var sql = "UPDATE tbl_Calendar SET title = @title, startDate = @startDate, endDate = @endDate,color=@color,Description=@desc where Id=" + f.EventID;// repeat for all variables
			try
			{
				using (var command = new SqlCommand(sql, conn))
				{
					command.Parameters.AddWithValue("@title", f.Subject);
					command.Parameters.AddWithValue("@startDate", f.Start);
					command.Parameters.AddWithValue("@endDate", f.End);
					command.Parameters.AddWithValue("@color", f.ThemeColor);
					command.Parameters.AddWithValue("@desc", f.Description);
					conn.Open();
					command.ExecuteNonQuery();
					conn.Close();
					status = true;
				}

			}
			catch (Exception e)
			{
				throw e;
			}
		}
		else
		{

			SqlCommand cmd3 = new SqlCommand("insert into tbl_Calendar(title,startDate,endDate,color,Description)"
				+ "values(@title,@startDate,@endDate,@color,@desc)", conn);

			cmd3.Parameters.AddWithValue("@title", f.Subject);
			cmd3.Parameters.AddWithValue("@startDate", f.Start);
			cmd3.Parameters.AddWithValue("@endDate", f.End);
			cmd3.Parameters.AddWithValue("@color", f.ThemeColor);
			cmd3.Parameters.AddWithValue("@desc", f.Description);
			conn.Open();
			cmd3.ExecuteNonQuery();
			conn.Close();
			status = true;
		}


		return new { status = status };
	}

	[WebMethod]
	public static object DeletEvent(int eventID)
	{
		SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["String"].ConnectionString);
		var status = false;
		try
		{

			conn.Open();
			using (SqlCommand command = new SqlCommand("DELETE FROM tbl_Calendar WHERE id = '" + eventID + "'", conn))
			{
				command.ExecuteNonQuery();
			}
			conn.Close();
			status = true;
		}
		catch (SystemException ex)
		{
			throw ex;
		}
		return new { status = status };
	}


	// calendar code end herer
}
class sData
{
	public DateTime date { get; set; }
	public string total { get; set; }
	public string qty { get; set; }
}

class eData
{
	public DateTime date { get; set; }
	public string total { get; set; }
}
public class yearlyGraph
{

	public string month { get; set; }
	public string stotal { get; set; }
	public string etotal { get; set; }
	public piChartValues piChart { get; set; }

	public List<expenseData> expenseData { get; set; }
}

public class piChartValues
{
	public string salary { get; set; }
	public string exp { get; set; }
	public string qty { get; set; }
}

public class expenseData
{
	public string lable { get; set; }

	public string value { get; set; }

}


public partial class Event
{
	public int EventID { get; set; }
	public string Subject { get; set; }
	public string Description { get; set; }
	public System.DateTime Start { get; set; }
	public Nullable<System.DateTime> End { get; set; }
	public string ThemeColor { get; set; }
	public bool IsFullDay { get; set; }
}