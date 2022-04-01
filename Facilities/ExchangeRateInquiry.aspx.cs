using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using DMS.DBConnection;
using DMS.CuBESCore;

namespace SME.Facilities
{
	/// <summary>
	/// Summary description for FindCustomer.fs
	/// Author: Gatot Wahyudi
	/// Created: 30 October 2004
	/// </summary>
	public partial class ExchangeRateInquiry : System.Web.UI.Page
	{
		protected Connection conn;
		protected Tools tool = new Tools();
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			conn = (Connection) Session["Connection"];

			if (!Logic.AllowAccess(Session["GroupID"].ToString(), Request.QueryString["mc"], conn))
				Response.Redirect("/SME/Restricted.aspx");

			string tc = "";
			try 
			{
				tc = Request.QueryString["tc"];
			} 
			catch {}
			
			if (!IsPostBack)
			{
				bindData(); // tampilkan data
			}
			DTG_EXCHRATEINQ.PageIndexChanged += new DataGridPageChangedEventHandler(this.Grid_Change);
		}		

		void Grid_Change(Object sender, DataGridPageChangedEventArgs e) 
		{
			// For the DataGrid control to navigate to the correct page when paging is
			// allowed, the CurrentPageIndex property must be programmatically updated.
			// This process is usually accomplished in the event-handling method for the
			// PageIndexChanged event.
			DTG_EXCHRATEINQ.CurrentPageIndex = e.NewPageIndex; // Set CurrentPageIndex to the page the user clicked.
			bindData();	// Re-bind the data to refresh the DataGrid control. 
		}

		private void bindData()
		{
			string sqlCON = "AND (";
			string sqlJOIN = RDB_COND.SelectedValue; // kondsi AND atau OR sesuai pilihan user

			if (TXT_CURRENCYID.Text.Trim() != "") // kondisi CurrencyID diisi
				sqlCON += " CURRENCYID LIKE '%" + TXT_CURRENCYID.Text.Trim() + "%' " + sqlJOIN; // memasukkan syarat TXT_CURRENCYID
			if (TXT_CURRENCYDESC.Text.Trim() != "") // kondisi CurrencyDesc diisi
				sqlCON += " CURRENCYDESC LIKE '%" + TXT_CURRENCYDESC.Text.Trim() + "%' " + sqlJOIN; // syarat TXT_CURRENCYDESC
			if (TXT_TOPRATE.Text.Trim() != "") // syarat Top Currency diisi
			{
				try
				{
					string toprate = tool.ConvertFloat(TXT_TOPRATE.Text.Trim());
					string bottomrate = tool.ConvertFloat("0");
					if (TXT_BOTTOMRATE.Text.Trim() != "")
					{ // syarat bottom rate diisi
						bottomrate = tool.ConvertFloat(TXT_BOTTOMRATE.Text.Trim());					
					} 
					sqlCON += " (CURRENCYRATE BETWEEN " + bottomrate;
					sqlCON += " and " + toprate + ") " + sqlJOIN; // syarat currency between
				}
				catch (Exception) {}
			} 
			else // syarat TopCurrency tidak diisi
			{
				if (TXT_BOTTOMRATE.Text.Trim() != "")
				{ // jika syarat bottomrate diisi
					try 
					{
						string bottomrate = tool.ConvertFloat(TXT_BOTTOMRATE.Text.Trim());
						sqlCON += " CURRENCYRATE = " + bottomrate + sqlJOIN;
						//Double.Parse(TXT_BOTTOMRATE.Text.Trim, System.Globalization.NumberStyles.Float);
					} 
					catch(Exception) {}
				}
			}

			if (sqlCON == "AND (") 
				sqlCON = ""; // kasus tidak terdapat kondisi apapun
			else
			{ // jika terdapat where maka kondisi "AND" atau "OR" paling belakang dihilangkan
				sqlCON = sqlCON.Substring(0,sqlCON.Length - sqlJOIN.Length);
				sqlCON += ")";
			}
		
			// query dasar untuk mendapatkan data
			conn.QueryString = "SELECT CURRENCYID,CURRENCYDESC,CURRENCYRATE";
			conn.QueryString += " FROM RFCURRENCY";
			conn.QueryString += " WHERE ACTIVE = 1";
			
			// proses pencarian dengan kondisi
			conn.QueryString += " " + sqlCON + " ORDER BY " + LBL_SORTEXP.Text + " " + LBL_SORTTYPE.Text;

			try 
			{ // mencoba mengeksekusi query
				conn.ExecuteQuery();
			} 
			catch (NullReferenceException) 
			{
				GlobalTools.popMessage(this, "Connection Error !");
				return;
			}

			/* jika kolom database sesuai benar dengan kolom data grid:*/
			DataTable data = new DataTable();
			data = conn.GetDataTable().Copy();
			DTG_EXCHRATEINQ.DataSource = data;
			try 
			{
				DTG_EXCHRATEINQ.DataBind(); // mengikat data ke datagrid yang disediakan
			} 
			catch 
			{
				DTG_EXCHRATEINQ.CurrentPageIndex = 0;
				DTG_EXCHRATEINQ.DataBind();
			}			
		}

		#region Web Form Designer generated code
		override protected void OnInit(EventArgs e)
		{
			//
			// CODEGEN: This call is required by the ASP.NET Web Form Designer.
			//
			InitializeComponent();
			base.OnInit(e);
		}
		
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{    
			this.DTG_EXCHRATEINQ.SortCommand += new System.Web.UI.WebControls.DataGridSortCommandEventHandler(this.DTG_EXCHRATEINQ_SortCommand);

		}
		#endregion


		private void DTG_EXCHRATEINQ_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			switch(((LinkButton)e.CommandSource).CommandName)
			{
				case "View":
					Response.Redirect("RFProductDetail.aspx?productid="+ e.Item.Cells[0].Text +"&tc=" + Request.QueryString["tc"]);
					break;
				default:
					// Do nothing.
					break;
			}
		}

		private void DTG_EXCHRATEINQ_SortCommand(object source, System.Web.UI.WebControls.DataGridSortCommandEventArgs e)
		{
			if (LBL_SORTTYPE.Text == "ASC")
				LBL_SORTTYPE.Text = "DESC";
			else
				LBL_SORTTYPE.Text = "ASC";
			LBL_SORTEXP.Text = e.SortExpression;
			
			bindData();
		}
		protected void BTN_FIND_Click(object sender, System.EventArgs e)
		{
			bindData();
		}

	}
}
