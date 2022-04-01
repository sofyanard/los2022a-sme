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
using System.Configuration;
using DMS.CuBESCore;
using DMS.DBConnection;
using Microsoft.VisualBasic;

namespace SME.AccountPlanning.Dashboard
{
	/// <summary>
	/// Summary description for WalletSizeTargets.
	/// </summary>
	public partial class WalletSizeTargets : System.Web.UI.Page
	{
		protected Tools tools = new Tools();
		protected Connection conn = new Connection(ConfigurationSettings.AppSettings["conn"]);
		protected Connection conn2 = new Connection(ConfigurationSettings.AppSettings["conn"]);
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			if(!IsPostBack)
			{
				Session.Add("grid", "");
				FillDDLSegment();
				FillDDLUnit();
				ViewData();
				TR_TITLE.Visible = false;
				TR_GRID.Visible = false;
				TR_WS_COMPANY.Visible = false;
			}

			//if session not empty
			if(Session["grid"].ToString() != "")
			{
				ViewCompany();
			}
		}

		private void FillDDLSegment()
		{
			DDL_SEGMENT.Items.Clear();
			DDL_SEGMENT.Items.Add(new ListItem("--Select--", ""));

			conn.QueryString = "SELECT BUSSUNITID, BUSSUNITDESC FROM RFBUSINESSUNIT WHERE ACTIVE='1' ORDER BY BUSSUNITID";
			conn.ExecuteQuery();
			
			for(int i=0; i < conn.GetRowCount(); i++)
			{
				DDL_SEGMENT.Items.Add(new ListItem(conn.GetFieldValue(i,1), conn.GetFieldValue(i,0)));
			}
		}

		private void FillDDLUnit()
		{
			DDL_UNIT .Items.Clear();
			DDL_UNIT.Items.Add(new ListItem("--Select--", ""));

			conn.QueryString = "SELECT BRANCH_CODE, BRANCH_NAME FROM RFBRANCH WHERE ACTIVE='1'";
			conn.ExecuteQuery();
			
			for(int i=0; i < conn.GetRowCount(); i++)
			{
				DDL_UNIT.Items.Add(new ListItem(conn.GetFieldValue(i,1), conn.GetFieldValue(i,0)));
			}
		}

		private void ViewData()
		{
			conn.QueryString = "SELECT * FROM VW_AP_ANCHOR_INFORMATION WHERE 0=1";
			BindData(DGR_ANCHOR_INFO, conn.QueryString);
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
			this.DGR_ANCHOR_INFO.ItemCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.DGR_ANCHOR_INFO_ItemCommand);
			this.DGR_ANCHOR_INFO.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.DGR_ANCHOR_INFO_PageIndexChanged);
			this.DGR_CONSOLIDATED.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.DGR_CONSOLIDATED_PageIndexChanged);

		}
		#endregion

		protected void BTN_FIND_Click(object sender, System.EventArgs e)
		{
			TXT_CIF.Text = ""; TXT_CUST_NAME.Text = ""; TXT_ADDRESS.Text = ""; TXT_KOTA.Text = ""; TXT_CUST_DATE.Text = "";
			TXT_RELATIONSHIP.Text = ""; TXT_RM.Text = ""; TXT_GROUP_NAME.Text = ""; TXT_UNIT_NAME.Text = "";

			DGR_ANCHOR_INFO.CurrentPageIndex = 0;
			SearchData();
		}

		private void SearchData()
		{
			string query = "";

			if(DDL_SEGMENT.SelectedValue != "")
			{
				query += "AND BUSSUNITID = '" + DDL_SEGMENT.SelectedValue + "' ";
			}
			if(DDL_UNIT.SelectedValue != "")
			{
				query += "AND BUC = '" + DDL_UNIT.SelectedValue + "' ";
			}

			if(query != "")
			{
				conn.QueryString = "SELECT * FROM VW_AP_ANCHOR_INFORMATION WHERE 1=1 " + query;
				BindData(DGR_ANCHOR_INFO, conn.QueryString);
			}

			else
			{
				conn.QueryString = "SELECT * FROM VW_AP_ANCHOR_INFORMATION";
				BindData(DGR_ANCHOR_INFO, conn.QueryString);
			}
			
			if(conn.GetRowCount() <= 0)
			{
				TR_TITLE.Visible = false;
				TR_GRID.Visible = false;
				TR_WS_COMPANY.Visible = false;

				Session["grid"] = "";
			}

			else if(conn.GetRowCount() > 0)
			{
				return;
			}
		}

		private void FillDataGrid()
		{
			conn.QueryString = "EXEC AP_CONSOLIDATED_WALLETSIZE '" + TXT_CIF.Text + "'";
			BindData(DGR_CONSOLIDATED, conn.QueryString);
		}

		private void BindData(DataGrid theGrid, string strconn)
		{
			if(strconn != "")
			{
				conn.QueryString = strconn;
				conn.ExecuteQuery();
			}

			System.Data.DataTable dt = new System.Data.DataTable();
			dt = conn.GetDataTable().Copy();

			System.Web.UI.WebControls.DataGrid dg = theGrid;

			dg.DataSource = dt;				

			try
			{
				dg.DataBind();
			}
			catch 
			{
				dg.CurrentPageIndex = dg.PageCount - 1;
				dg.DataBind();
			}
			conn.ClearData();
		}

		private void DGR_ANCHOR_INFO_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			DGR_ANCHOR_INFO.CurrentPageIndex = e.NewPageIndex;
			SearchData();
		}

		private void DGR_ANCHOR_INFO_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			switch(((Button)e.CommandSource).CommandName)
			{
				case "view":
					TR_TITLE.Visible = true;
					TR_GRID.Visible = true;
					TR_WS_COMPANY.Visible = true;

					TXT_CIF.Text = e.Item.Cells[0].Text.Trim();

					conn.QueryString = "SELECT * FROM VW_AP_ANCHOR_INFORMATION WHERE CIF# = '" + TXT_CIF.Text + "'";
					conn.ExecuteQuery();

					TXT_CUST_NAME.Text = conn.GetFieldValue("CUSTOMER_GROUP");
					TXT_ADDRESS.Text = conn.GetFieldValue("CUST_ADDRESS");
					TXT_KOTA.Text = conn.GetFieldValue("CUST_CITY");
					TXT_CUST_DATE.Text = tools.FormatDate(conn.GetFieldValue("CUST_DATE").ToString());
					TXT_RELATIONSHIP.Text = conn.GetFieldValue("CUST_LENGTH");
					TXT_RM.Text = conn.GetFieldValue("RM_NAME");
					TXT_GROUP_NAME.Text = conn.GetFieldValue("BUC_NAME");
					TXT_UNIT_NAME.Text = conn.GetFieldValue("BUSSUNITDESC");

					FillDataGrid();
					ViewCompany();

					Session["grid"] = "1";
					break;
			}
		}

		private void DGR_CONSOLIDATED_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			DGR_CONSOLIDATED.CurrentPageIndex = e.NewPageIndex;
			FillDataGrid();
		}

		private void ViewCompany()
		{
			conn2.QueryString = "SELECT * FROM AP_COMPANY_INFO WHERE CIF_GROUP = '" + TXT_CIF.Text + "'";
			conn2.ExecuteQuery();

			for(int i = 0; i < conn2.GetRowCount(); i++)
			{
				CreateContent(conn2.GetFieldValue(i,"CIF_CUST"), conn2.GetFieldValue(i,"CUSTOMER_NAME"));
			}
		}

		private void CreateContent(string ID_CIF, string CUST_NAME)
		{
			System.Web.UI.WebControls.DataGrid DATA_GRID;
			System.Web.UI.WebControls.TextBox TXT_BOX;

			System.Web.UI.HtmlControls.HtmlTableRow TR;
			System.Web.UI.HtmlControls.HtmlTableCell TD;
			System.Web.UI.WebControls.Label LBL_LABEL;

			/************************* Membuat TD untuk Field Text *****************************/
			//label
			TR = new HtmlTableRow();
			TD = new HtmlTableCell();
			LBL_LABEL = new Label();
			LBL_LABEL.Text = "Company Name :";
			TD.Controls.Add(LBL_LABEL);
			TD.Attributes["width"] = "25%";
			TD.Attributes["class"] = "TDBGColor1";
			TD.Attributes["align"] = "right";
			TR.Controls.Add(TD);
						
			//txt
			TD = new HtmlTableCell();
			TXT_BOX = new TextBox();
			TXT_BOX.Width = 350;
			TXT_BOX.ID = "TXT_COMPANYNAME_" + ID_CIF;
			TXT_BOX.Text = CUST_NAME;
			TD.Controls.Add(TXT_BOX);
			TR.Controls.Add(TD);

			TBL_COMPANY.Controls.Add(TR);

			/***************************** Membuat Data Grid *******************************/

			TR = new HtmlTableRow();
			TD = new HtmlTableCell();
			TD.Attributes["colspan"] = "2";

			DATA_GRID = new DataGrid();
			DATA_GRID.ID = "GRID_" + ID_CIF;
			DATA_GRID.AllowPaging = true;
			DATA_GRID.CellPadding = 1;
			DATA_GRID.AutoGenerateColumns = false;
			DATA_GRID.Width = Unit.Percentage(100.0);
			DATA_GRID.AlternatingItemStyle.CssClass = "TblAlternating";
			DATA_GRID.PagerStyle.Mode = PagerMode.NumericPages;
			//DATA_GRID.ItemCommand += new DataGridCommandEventHandler(DATA_GRID_ItemCommand);

			/**************** Membuat Field pada Data Grid *****************/
			conn.QueryString = "SELECT * FROM VW_AP_WALLETSIZE_COMPANY_FIELD_DATA_GRID ORDER BY CONVERT(INT,FIELDID) ASC";
			conn.ExecuteQuery();
	
			BoundColumn columns = new BoundColumn();

			for(int i = 0; i < conn.GetRowCount(); i++)
			{
				columns = new BoundColumn();
				columns.HeaderText = conn.GetFieldValue(i,1).ToString();
				columns.DataField = conn.GetFieldValue(i,2).ToString();
				columns.HeaderStyle.CssClass = "tdSmallHeader";
				columns.Visible = true;
				columns.ItemStyle.HorizontalAlign = HorizontalAlign.Center;
				DATA_GRID.Columns.Add(columns);
			}

			/*********************** BIND DATA ****************************/
			conn.QueryString = "EXEC AP_WALLETSIZE_COMPANY_FIELD_DATA_GRID '" + ID_CIF + "'";
			BindData(DATA_GRID, conn.QueryString);

			TD.Controls.Add(DATA_GRID);
			DATA_GRID.PageIndexChanged += new DataGridPageChangedEventHandler(DATA_GRID_PageIndexChanged);
			TR.Controls.Add(TD);

			TBL_COMPANY.Controls.Add(TR);
		}

		private void DATA_GRID_PageIndexChanged(object source, DataGridPageChangedEventArgs e)
		{
			string ID_CIF = "";
			((DataGrid)source).CurrentPageIndex = e.NewPageIndex;

			ID_CIF = ((DataGrid)source).ID.Remove(0,5);

			conn.QueryString = "EXEC AP_WALLETSIZE_COMPANY_FIELD_DATA_GRID '" + ID_CIF.ToString() + "'";
			BindData(((DataGrid)source), conn.QueryString);
		}

		protected void BTN_BACK_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			Response.Redirect("AccountPlanBoard.aspx?mc=AP03");
		}
	}
}
