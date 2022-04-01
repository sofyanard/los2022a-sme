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

namespace SME.AccountPlanning.WalletShareTarget
{
	/// <summary>
	/// Summary description for WalletSizePrint.
	/// </summary>
	public partial class WalletSizePrint : System.Web.UI.Page
	{
		protected Tools tools = new Tools();
		protected Connection conn = new Connection(ConfigurationSettings.AppSettings["conn"]);
		protected Connection conn2 = new Connection(ConfigurationSettings.AppSettings["conn"]);
		protected Connection conn3 = new Connection(ConfigurationSettings.AppSettings["conn"]);
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			ViewData();
		}

		private void ViewData()
		{
			conn2.QueryString = "EXEC AP_GET_WALLET_SIZING_DATA '" + Request.QueryString["cif"] + "'";
			conn2.ExecuteQuery();

			for(int i = 0; i < conn2.GetRowCount(); i++)
			{
				CreateContent(conn2.GetFieldValue(i,"CIF"), conn2.GetFieldValue(i,"CUSTOMER"));
			}
		}

		private void CreateContent(string ID_CIF, string CUST_NAME)
		{
			System.Web.UI.HtmlControls.HtmlTableRow TR;
			System.Web.UI.HtmlControls.HtmlTableCell TD;
			System.Web.UI.HtmlControls.HtmlTableRow TR2;
			System.Web.UI.HtmlControls.HtmlTableCell TD2;
			System.Web.UI.HtmlControls.HtmlTableCell TD3;
			System.Web.UI.HtmlControls.HtmlTable Table6;
			System.Web.UI.HtmlControls.HtmlTable Table7;
			System.Web.UI.WebControls.Label LBL_LABEL;
			System.Web.UI.WebControls.Label LBL_FIELD;
			System.Web.UI.WebControls.DataGrid DATA_GRID;

			/*************************************** MEMBUAT TR & TD *****************************************/
			conn.QueryString = "SELECT [TEXT], FIELD FROM VW_AP_PRINT_WALLET_SIZE_FIELD ORDER BY CONVERT(INT, [ID])";
			conn.ExecuteQuery();

			TR2 = new HtmlTableRow();
			TD2 = new HtmlTableCell();
			TD3 = new HtmlTableCell();

			for(int i = 0; i < conn.GetRowCount(); i++)
			{
				Table6 = new HtmlTable();
				Table7 = new HtmlTable();

				//label-kiri
				TR = new HtmlTableRow();
				TD = new HtmlTableCell();
				LBL_LABEL = new Label();
				LBL_LABEL.Text = conn.GetFieldValue(i,0).ToString() + " : ";
				TD.Controls.Add(LBL_LABEL);
				TD.Attributes["class"] = "TDBGColor1";
				TD.Attributes["width"] = "50%";
				TR.Controls.Add(TD);

				//label result-kiri
				LBL_FIELD = new Label();
				LBL_FIELD.Text = conn.GetFieldValue(i,1).ToString();
				conn3.QueryString = "SELECT " + LBL_FIELD.Text + " FROM VW_AP_GET_WALLET_SIZING_DATA WHERE CIF = '" + ID_CIF + "'";
				conn3.ExecuteQuery();

				TD = new HtmlTableCell();
				LBL_LABEL = new Label();
				LBL_LABEL.Text = conn3.GetFieldValue(LBL_FIELD.Text);
				TD.Controls.Add(LBL_LABEL);
				TD.Attributes["class"] = "TDBGColorValue";
				TD.Attributes["width"] = "50%";
				TR.Controls.Add(TD);

				Table6.Controls.Add(TR);
				Table6.Width = "100%";
				
				i++; //increment

				//label-kanan
				if(i < conn.GetRowCount())
				{
					TR = new HtmlTableRow();

					TD = new HtmlTableCell();
					LBL_LABEL = new Label();
					LBL_LABEL.Text = conn.GetFieldValue(i,0).ToString() + " : ";
					TD.Controls.Add(LBL_LABEL);
					TD.Attributes["class"] = "TDBGColor1";
					TD.Attributes["width"] = "50%";
					TR.Controls.Add(TD);
						
					//label result-kanan
					LBL_FIELD = new Label();
					LBL_FIELD.Text = conn.GetFieldValue(i,1).ToString();
					conn3.QueryString = "SELECT " + LBL_FIELD.Text + " FROM VW_AP_GET_WALLET_SIZING_DATA WHERE CIF = '" + ID_CIF + "'";
					conn3.ExecuteQuery();

					TD = new HtmlTableCell();
					LBL_LABEL = new Label();
					LBL_LABEL.Text = conn3.GetFieldValue(LBL_FIELD.Text);
					TD.Controls.Add(LBL_LABEL);
					TD.Attributes["class"] = "TDBGColorValue";
					TD.Attributes["width"] = "50%";
					TR.Controls.Add(TD);

					Table7.Controls.Add(TR);
					Table7.Width = "100%";
				}
				else
				{
					TR = new HtmlTableRow();

					TD = new HtmlTableCell();
					LBL_LABEL = new Label();
					LBL_LABEL.Text = "";
					TD.Controls.Add(LBL_LABEL);
					TD.Attributes["class"] = "TDBGColor1";
					TD.Attributes["width"] = "50%";
					TR.Controls.Add(TD);

					TD = new HtmlTableCell();
					LBL_LABEL = new Label();
					LBL_LABEL.Text = conn3.GetFieldValue(LBL_FIELD.Text);
					TD.Controls.Add(LBL_LABEL);
					TD.Attributes["class"] = "TDBGColorValue";
					TD.Attributes["width"] = "50%";
					TR.Controls.Add(TD);

					Table7.Controls.Add(TR);
					Table7.Width = "100%";
				}
				
				TD2.Controls.Add(Table6);
				TD2.Attributes["class"] = "td";
				TD2.Width = "50%";

				TD3.Controls.Add(Table7);
				TD2.Attributes["class"] = "td";
				TD3.Width = "50%";

				TR2.Controls.Add(TD2);
				TR2.Controls.Add(TD3);

				TBL_SCENARIO.Controls.Add(TR2);
			}

			/******************************** MEMBUAT TITLE PAGE - WHOLESALE *****************************************/
			TR = new HtmlTableRow();
			TD = new HtmlTableCell();
			LBL_LABEL = new Label();
			LBL_LABEL.Text = "1. WHOLESALE PRODUCT";
			LBL_LABEL.Font.Bold	= true;
			LBL_LABEL.Font.Size = 12;
			
			TD.Controls.Add(LBL_LABEL);
			TD.Attributes["align"] = "left";
			TD.Attributes["colspan"] = "2";
			TR.Controls.Add(TD);

			TBL_SCENARIO.Controls.Add(TR);

			/******************************** MEMBUAT DATAGRID WHOLESALE *****************************************/
			TR = new HtmlTableRow();
			TD = new HtmlTableCell();
			TD.Attributes["colspan"] = "2";

			DATA_GRID = new DataGrid();
			DATA_GRID.ID = "GRID_WHOLESALE_" + ID_CIF;
			DATA_GRID.CellPadding = 1;
			DATA_GRID.AutoGenerateColumns = false;
			DATA_GRID.Width = Unit.Percentage(100.0);
			DATA_GRID.AlternatingItemStyle.CssClass = "TblAlternating";
			//DATA_GRID.AllowPaging = true;
			//DATA_GRID.PagerStyle.Mode = PagerMode.NumericPages;
			//DATA_GRID.ItemCommand += new DataGridCommandEventHandler(DATA_GRID_ItemCommand);
			//DATA_GRID.PageIndexChanged += new DataGridPageChangedEventHandler(DATA_GRID_PageIndexChanged);

			/******************************** MEMBUAT FIELD DATAGRID *******************************************/
			conn.QueryString = "SELECT FIELDTEXT, DATAFIELD FROM VW_AP_PRINT_WALLET_SIZE_DATA_GRID ORDER BY CONVERT(INT, FIELDID) ASC";
			conn.ExecuteQuery();
	
			BoundColumn columns = new BoundColumn();
			
			for(int i = 0; i < conn.GetRowCount(); i++)
			{
				columns = new BoundColumn();
				columns.HeaderText = conn.GetFieldValue(i,0).ToString();
				columns.DataField = conn.GetFieldValue(i,1).ToString();
				columns.HeaderStyle.CssClass = "tdSmallHeader";
				columns.Visible = true;
				columns.ItemStyle.HorizontalAlign = HorizontalAlign.Center;
				DATA_GRID.Columns.Add(columns);
			}

			/*TemplateColumn columnsz = new TemplateColumn();
			columnsz = new TemplateColumn();
			columnsz.HeaderText = "Function";
			columnsz.HeaderStyle.CssClass = "tdSmallHeader";
			columnsz.ItemStyle.HorizontalAlign = HorizontalAlign.Center;
			LBT = new LinkButtonTemplate("LBT_" + ID_CIF);
			columnsz.ItemTemplate = LBT;
			DATA_GRID.Columns.Add(columnsz);*/

			//BindData
			conn.QueryString = "EXEC AP_GET_WALLET_SIZING_WHOLESALE '" + ID_CIF + "','1'";
			BindData(DATA_GRID, conn.QueryString);

			TD.Controls.Add(DATA_GRID);
			TR.Controls.Add(TD);

			TBL_SCENARIO.Controls.Add(TR);

			/******************************** MEMBUAT TITLE PAGE - ALLIANCE *****************************************/
			TR = new HtmlTableRow();
			TD = new HtmlTableCell();
			LBL_LABEL = new Label();
			LBL_LABEL.Text = "2. ALLIANCE PRODUCT";
			LBL_LABEL.Font.Bold	= true;
			LBL_LABEL.Font.Size = 12;
			
			TD.Controls.Add(LBL_LABEL);
			TD.Attributes["align"] = "left";
			TD.Attributes["colspan"] = "2";
			TR.Controls.Add(TD);

			TBL_SCENARIO.Controls.Add(TR);

			/******************************** MEMBUAT DATAGRID WHOLESALE *****************************************/
			TR = new HtmlTableRow();
			TD = new HtmlTableCell();
			TD.Attributes["colspan"] = "2";

			DATA_GRID = new DataGrid();
			DATA_GRID.ID = "GRID_ALLIANCE_" + ID_CIF;
			DATA_GRID.CellPadding = 1;
			DATA_GRID.AutoGenerateColumns = false;
			DATA_GRID.Width = Unit.Percentage(100.0);
			DATA_GRID.AlternatingItemStyle.CssClass = "TblAlternating";
			//DATA_GRID.AllowPaging = true;
			//DATA_GRID.PagerStyle.Mode = PagerMode.NumericPages;
			//DATA_GRID.ItemCommand += new DataGridCommandEventHandler(DATA_GRID_ItemCommand);
			//DATA_GRID.PageIndexChanged += new DataGridPageChangedEventHandler(DATA_GRID_PageIndexChanged);

			/******************************** MEMBUAT FIELD DATAGRID *******************************************/
			conn.QueryString = "SELECT FIELDTEXT, DATAFIELD FROM VW_AP_PRINT_WALLET_SIZE_DATA_GRID ORDER BY CONVERT(INT, FIELDID) ASC";
			conn.ExecuteQuery();
		
			for(int i = 0; i < conn.GetRowCount(); i++)
			{
				columns = new BoundColumn();
				columns.HeaderText = conn.GetFieldValue(i,0).ToString();
				columns.DataField = conn.GetFieldValue(i,1).ToString();
				columns.HeaderStyle.CssClass = "tdSmallHeader";
				columns.Visible = true;
				columns.ItemStyle.HorizontalAlign = HorizontalAlign.Center;
				DATA_GRID.Columns.Add(columns);
			}

			/*TemplateColumn columnsz = new TemplateColumn();
			columnsz = new TemplateColumn();
			columnsz.HeaderText = "Function";
			columnsz.HeaderStyle.CssClass = "tdSmallHeader";
			columnsz.ItemStyle.HorizontalAlign = HorizontalAlign.Center;
			LBT = new LinkButtonTemplate("LBT_" + ID_CIF);
			columnsz.ItemTemplate = LBT;
			DATA_GRID.Columns.Add(columnsz);*/

			//BindData
			conn.QueryString = "EXEC AP_GET_WALLET_SIZING_WHOLESALE '" + ID_CIF + "','2'";
			BindData(DATA_GRID, conn.QueryString);

			TD.Controls.Add(DATA_GRID);
			TR.Controls.Add(TD);

			TBL_SCENARIO.Controls.Add(TR);
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

		}
		#endregion
	}
}
