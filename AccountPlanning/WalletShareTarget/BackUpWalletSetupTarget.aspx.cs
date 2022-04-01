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
	/// Summary description for WalletSetupTarget.
	/// </summary>
	public partial class BackUpWalletSetupTarget : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Label LBL_PT;
		protected System.Web.UI.WebControls.DataGrid DGR_WALLETSIZE;
		protected System.Web.UI.WebControls.Label LBL_TXT_CUST_DATE;
		protected System.Web.UI.WebControls.TextBox TXT_CUST_DATE;
		protected System.Web.UI.WebControls.Label LBL_TXT_RM;
		protected System.Web.UI.WebControls.TextBox TXT_RM;
		protected System.Web.UI.WebControls.Label LBL_TXT_GROUP_NAME;
		protected System.Web.UI.WebControls.TextBox TXT_GROUP_NAME;
		protected System.Web.UI.WebControls.Label LBL_TXT_UNIT_NAME;
		protected System.Web.UI.WebControls.TextBox TXT_UNIT_NAME;
		protected System.Web.UI.WebControls.Label LBL_TXT_RELATIONSHIP;
		protected System.Web.UI.WebControls.TextBox TXT_RELATIONSHIP;
		protected System.Web.UI.WebControls.Label LBL_TXT_CATEGORY_PRODUCT;
		protected System.Web.UI.WebControls.Label LBL_TXT_PRODUCT ;
		protected System.Web.UI.WebControls.DropDownList DDL_CATEGORY_PRODUCT;
		protected System.Web.UI.WebControls.Label LBL_TXT_PRODUCT_LINK;
		protected System.Web.UI.WebControls.DropDownList DDL_PRODUCT_LINK;
		protected System.Web.UI.WebControls.Label LBL_TXT_PRIORITY;
		protected System.Web.UI.WebControls.TextBox TXT_PRIORITY;
		protected System.Web.UI.WebControls.Label LBL_TXT_UNIT_VOLUME;
		protected System.Web.UI.WebControls.TextBox TXT_UNIT_VOLUME;
		protected System.Web.UI.WebControls.Label LBL_TXT_WALLET_SIZE_VOL;
		protected System.Web.UI.WebControls.TextBox TXT_WALLET_SIZE_VOL;
		protected System.Web.UI.WebControls.Label LBL_TXT_WALLET_SIZE_INC;
		protected System.Web.UI.WebControls.TextBox TXT_WALLET_SIZE_INC;
		protected System.Web.UI.WebControls.Label LBL_TXT_WALLET_ADJ_VOL;
		protected System.Web.UI.WebControls.TextBox TXT_WALLET_ADJ_VOL;
		protected System.Web.UI.WebControls.Label LBL_TXT_WALLET_ADJ_INC;
		protected System.Web.UI.WebControls.TextBox TXT_WALLET_ADJ_INC;
		protected System.Web.UI.WebControls.Label LBL_TXT_CURRENT_VOL;
		protected System.Web.UI.WebControls.TextBox TXT_CURRENT_VOL;
		protected System.Web.UI.WebControls.Label LBL_TXT_CURRENT_HOME;
		protected System.Web.UI.WebControls.TextBox TXT_CURRENT_HOME;
		protected System.Web.UI.WebControls.Label LBL_TXT_CURRENT_WALLET;
		protected System.Web.UI.WebControls.TextBox TXT_CURRENT_WALLET;
		protected System.Web.UI.WebControls.Label LBL_TXT_TARGET_VOL;
		protected System.Web.UI.WebControls.TextBox TXT_TARGET_VOL;
		protected System.Web.UI.WebControls.Label LBL_TXT_TARGET_INC;
		protected System.Web.UI.WebControls.TextBox TXT_TARGET_INC;
		protected System.Web.UI.WebControls.Label LBL_TXT_TARGET_SHARE;
		protected System.Web.UI.WebControls.TextBox TXT_TARGET_SHARE;
		protected System.Web.UI.WebControls.Label LBL_TXT_KEY_COMPETITOR;
		protected System.Web.UI.WebControls.TextBox TXT_KEY_COMPETITOR;
		protected System.Web.UI.WebControls.Label LBL_TXT_BESTBANK_SHARE;
		protected System.Web.UI.WebControls.TextBox TXT_BESTBANK_SHARE;
		protected System.Web.UI.WebControls.Label LBL_TXT_POTENTIAL_ISSUES;
		protected System.Web.UI.WebControls.TextBox TXT_POTENTIAL_ISSUES;
		protected System.Web.UI.WebControls.Button BTN_Find;
		protected System.Web.UI.WebControls.Label LBL_TXT_DAYS;
		protected Tools tools = new Tools();
		protected Connection conn = new Connection(ConfigurationSettings.AppSettings["conn"]);
		protected Connection conn2 = new Connection(ConfigurationSettings.AppSettings["conn"]);
		protected Connection conn3 = new Connection(ConfigurationSettings.AppSettings["conn"]);
		protected Connection conn4 = new Connection(ConfigurationSettings.AppSettings["conn"]);
		protected Connection conn10 = new Connection(ConfigurationSettings.AppSettings["conn"]);
		protected Connection conn5 = new Connection(ConfigurationSettings.AppSettings["conn"]);
		protected string procedure = "";
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			ViewMenu();
			if(!IsPostBack)
			{
				/*FillDataGrid();

				conn.QueryString = "SELECT DISTINCT * FROM VW_AP_CUSTOMER_LIST WHERE CIF#='" + Request.QueryString["cif"] + "' AND BUSSUNITID='" +
									Request.QueryString["bs"] + "' AND BUC='" + Request.QueryString["bc"] + "' AND (RM_ID='" + Request.QueryString["rd"] + "' OR CST_ID='" + Request.QueryString["cd"] + "')";
				conn.ExecuteQuery();

				LBL_PT.Text = conn.GetFieldValue("CUSTOMER_NAME");*/
			}

			/*conn3.QueryString = "SELECT * FROM AP_COMPANY_INFO WHERE CIF_GROUP = '" + Request.QueryString["cif"] + "'";
			conn3.ExecuteQuery();*/

			conn10.QueryString = "SELECT * FROM AP_COMPANY_INFO WHERE CIF_GROUP = '" + Request.QueryString["cif"] + "'";
			conn10.ExecuteQuery();

			/*conn3.QueryString = "SELECT * FROM AP_COMPANY_INFO WHERE CIF_GROUP = '1001565207'";
			conn3.ExecuteQuery();*/

			for(int i=0; i< conn10.GetRowCount() ; i++)
			{
				calculate(conn10.GetFieldValue(i, "CIF_CUST"));
			}
			
			for(int i=0; i< conn10.GetRowCount() ; i++)
			{
				CreatePageComponent(conn10.GetFieldValue(i, "CIF_CUST"));
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

		}
		#endregion

		private void ViewMenu()
		{
			Menu.Controls.Clear();
			try 
			{
				conn.QueryString = "SELECT * FROM SCREENMENU WHERE MENUCODE = '" + Request.QueryString["mc"] + "'";
				conn.ExecuteQuery();
				
				for (int i = 0; i < conn.GetRowCount(); i++) 
				{
					HyperLink t = new HyperLink();
					t.Text = conn.GetFieldValue(i, 2);
					t.Font.Bold = true;
					string strtemp = "";
					if (conn.GetFieldValue(i, 3).Trim()!= "") 
					{
						if (conn.GetFieldValue(i,3).IndexOf("mc=") >= 0)
							strtemp = "cif=" + Request.QueryString["cif"] + "&bs=" + Request.QueryString["bs"] + "&bc=" + Request.QueryString["bc"] + "&rd=" + Request.QueryString["rd"] + "&cd=" + Request.QueryString["cd"];
						else	
							strtemp = "&mc=" + Request.QueryString["mc"]+ "&cif=" + Request.QueryString["cif"] + "&bs=" + Request.QueryString["bs"] + "&bc=" + Request.QueryString["bc"] + "&rd=" + Request.QueryString["rd"] + "&cd=" + Request.QueryString["cd"];
					}
					else 
					{
						strtemp = ""; 
					}
					t.NavigateUrl = conn.GetFieldValue(i,3) + strtemp;
					Menu.Controls.Add(t);
					Menu.Controls.Add(new LiteralControl("&nbsp;&nbsp;&nbsp;"));
				}
			} 
			catch (Exception ex) 
			{
				string temp = ex.ToString();
			}
		}

		private void BindData(DataGrid theGrid, string strconn)
		{
			if(strconn != "")
			{
				conn2.QueryString = strconn;
				conn2.ExecuteQuery();
			}

			System.Data.DataTable dt = new System.Data.DataTable();
			dt = conn2.GetDataTable().Copy();

			System.Web.UI.WebControls.DataGrid dg = theGrid;

			dg.DataSource = dt;				

			try
			{
				try
				{
					dg.DataBind();
				}
				catch 
				{
					dg.CurrentPageIndex = dg.PageCount - 1;
					dg.DataBind();
				}
			}
			catch (Exception c)
			{
				string ab = c.Message.ToString();
				string cd = c.Message.ToString();
			}
			
			if(!IsPostBack)
			{

			}
			conn2.ClearData();
		}

		protected void BTN_BACK_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			Response.Redirect("../CustomerList.aspx?mc=" + Request.QueryString["mc"]);
		}
		
		private void RetreiveData(string IDAP, string theCIF)
		{
			conn.QueryString = "SELECT * FROM AP_WALLET_SIZE_RESULT WHERE ID_AP_WALLET_SIZE_CATEGORY_TO_AP_MODEL = '" + IDAP + "' AND CU_CIF = '" + theCIF + "'";
			conn.ExecuteQuery();

			conn2.QueryString = "SELECT * FROM AP_WALLET_SIZE_CATEGORY_TO_AP_MODEL WHERE ID_AP_WALLET_SIZE_CATEGORY_TO_AP_MODEL = '" + conn.GetFieldValue("ID_AP_WALLET_SIZE_CATEGORY_TO_AP_MODEL") + "'";
			conn2.ExecuteQuery();

			string CATEGORY = conn2.GetFieldValue("ID_AP_WALLET_SIZE_CATEGORY");
			string PRODUCT = conn2.GetFieldValue("ID_AP_VARIABLE");

			DropDownList DDL_CATEGORY_PRODUCT = (DropDownList)this.FindControl("DDL_CATEGORY_PRODUCT_" + theCIF);
			DropDownList DDL_PRODUCT_LINK = (DropDownList)this.FindControl("DDL_PRODUCT_LINK_" + theCIF);
			TextBox TXT_PRIORITY = (TextBox)this.FindControl("TXT_PRIORITY_" + theCIF);
			TextBox TXT_UNIT_FOR_VOLUME = (TextBox)this.FindControl("TXT_UNIT_FOR_VOLUME_" + theCIF);
			TextBox TXT_WALLET_SIZE_MODEL_VOLUME = (TextBox)this.FindControl("TXT_WALLET_SIZE_MODEL_VOLUME_" + theCIF);
			TextBox TXT_WALLET_SIZE_MODEL_INCOME = (TextBox)this.FindControl("TXT_WALLET_SIZE_MODEL_INCOME_" + theCIF);
			TextBox TXT_WALLET_SIZE_ADJ_VOLUME = (TextBox)this.FindControl("TXT_WALLET_SIZE_ADJ_VOLUME_" + theCIF);
			TextBox TXT_WALLET_SIZE_ADJ_INCOME = (TextBox)this.FindControl("TXT_WALLET_SIZE_ADJ_INCOME_" + theCIF);
			TextBox TXT_CURRENT_VOLUME = (TextBox)this.FindControl("TXT_CURRENT_VOLUME_" + theCIF);
			TextBox TXT_CURRENT_INCOME = (TextBox)this.FindControl("TXT_CURRENT_INCOME_" + theCIF);
			TextBox TXT_CURRENT_W_SHARE = (TextBox)this.FindControl("TXT_CURRENT_W_SHARE_" + theCIF);
			TextBox TXT_TARGET_VOLUME = (TextBox)this.FindControl("TXT_TARGET_VOLUME_" + theCIF);
			TextBox TXT_TARGET_INCOME = (TextBox)this.FindControl("TXT_TARGET_INCOME_" + theCIF);
			TextBox TXT_TARGET_W_SHARE = (TextBox)this.FindControl("TXT_TARGET_W_SHARE_" + theCIF);
			TextBox TXT_KEY_COMPETITOR = (TextBox)this.FindControl("TXT_KEY_COMPETITOR_" + theCIF);
			TextBox TXT_BEST_BANK_W_SHARE = (TextBox)this.FindControl("TXT_BEST_BANK_W_SHARE_" + theCIF);
			TextBox TXT_POTENTIAL_ISSUES = (TextBox)this.FindControl("TXT_POTENTIAL_ISSUES_" + theCIF);
			TextBox TXT_IDAP = (TextBox)this.FindControl("TXT_IDAP_" + theCIF);

			DDL_CATEGORY_PRODUCT.SelectedValue = CATEGORY;
			DDL_PRODUCT_LINK.SelectedValue = PRODUCT;
			TXT_PRIORITY.Text = conn.GetFieldValue("PRIORITY");
			TXT_UNIT_FOR_VOLUME.Text = conn.GetFieldValue("UNIT_FOR_VOLUME");
			TXT_WALLET_SIZE_MODEL_VOLUME.Text = conn.GetFieldValue("WALLET_SIZE_MODEL_VOLUME");
			TXT_WALLET_SIZE_MODEL_INCOME.Text = conn.GetFieldValue("WALLET_SIZE_MODEL_INCOME");
			TXT_WALLET_SIZE_ADJ_VOLUME.Text = conn.GetFieldValue("WALLET_SIZE_ADJUSTED_VOLUME");
			TXT_WALLET_SIZE_ADJ_INCOME.Text = conn.GetFieldValue("WALLET_SIZE_ADJUSTED_INCOME");
			TXT_CURRENT_VOLUME.Text = conn.GetFieldValue("MANDIRI_CURRENT_VOLUME");
			TXT_CURRENT_INCOME.Text = conn.GetFieldValue("MANDIRI_CURRENT_INCOME");
			TXT_CURRENT_W_SHARE.Text = conn.GetFieldValue("MANDIRI_CURRENT_WALLET_SHARE_PERCENT");
			TXT_TARGET_VOLUME.Text = conn.GetFieldValue("TARGET_VOLUME");
			TXT_TARGET_INCOME.Text = conn.GetFieldValue("TARGET_INCOME");
			TXT_TARGET_W_SHARE.Text = conn.GetFieldValue("TARGET_WALLET_SHARE_PERCENT");
			TXT_KEY_COMPETITOR.Text = conn.GetFieldValue("REMARKS_KEY_COMPETITORS");
			TXT_BEST_BANK_W_SHARE.Text = conn.GetFieldValue("REMARKS_BEST_BANK_WALLET_SHARED");
			TXT_POTENTIAL_ISSUES.Text = conn.GetFieldValue("REMARKS_POTENTIAL_ISSUES");
			TXT_IDAP.Text = conn.GetFieldValue("ID_AP_WALLET_SIZE_CATEGORY_TO_AP_MODEL");
		}

		private void DeleteResult(string IDAP, string theCIF)
		{
			conn.QueryString = "DELETE AP_WALLET_SIZE_RESULT WHERE CU_CIF = '" + theCIF + "' AND ID_AP_WALLET_SIZE_CATEGORY_TO_AP_MODEL = '" + IDAP + "'";
			conn.ExecuteQuery();
		}

		private void CreatePageComponent(string CIF)
		{
			System.Web.UI.WebControls.Button BTN;
			System.Web.UI.WebControls.TextBox TXT_BOX;
			System.Web.UI.HtmlControls.HtmlTable TBL;
			System.Web.UI.WebControls.DataGrid THE_GRID;
			System.Web.UI.WebControls.DropDownList DDL;
			System.Web.UI.HtmlControls.HtmlTableRow TR;
			System.Web.UI.HtmlControls.HtmlTableRow TRMain;
			System.Web.UI.HtmlControls.HtmlTableCell TD;
			System.Web.UI.WebControls.Label LBL_LABEL;
			LinkButtonTemplate LBT;

			TR = new HtmlTableRow();
			TD = new HtmlTableCell();
			LBL_LABEL = new Label();
			LBL_LABEL.Text = " ";
			TD.Controls.Add(LBL_LABEL);
			TR.Controls.Add(TD);
			MAIN_TABLE.Controls.Add(TR);

			TR = new HtmlTableRow();
			TD = new HtmlTableCell();
			LBL_LABEL = new Label();
 
			conn.QueryString = "SELECT * FROM AP_COMPANY_INFO WHERE CIF_CUST = '" + CIF + "'";
			conn.ExecuteQuery();

			LBL_LABEL.Text = conn.GetFieldValue("CUSTOMER_NAME");
			TD.Controls.Add(LBL_LABEL);
			TD.Attributes["class"] = "tdHeader1";
			TD.Attributes["colspan"] = "2";
			TR.Controls.Add(TD);
			MAIN_TABLE.Controls.Add(TR);

			/*********************** GRID DIBAWAH MAIN LABEL *******************************/
			THE_GRID = new DataGrid();
			THE_GRID.ID = "GRID_" + CIF;
			THE_GRID.AllowPaging = true;
			THE_GRID.ShowFooter = true;
			THE_GRID.PageSize = 10;
			THE_GRID.CellPadding = 1;
			THE_GRID.AutoGenerateColumns = false;
			THE_GRID.Width = Unit.Percentage(100.0);
			//THE_GRID.Width = Unit.Pixel(1024);
			THE_GRID.AlternatingItemStyle.CssClass = "TblAlternating";
			THE_GRID.PagerStyle.Mode = PagerMode.NumericPages;
			THE_GRID.ItemCommand += new DataGridCommandEventHandler(THE_GRID_ItemCommand);
			THE_GRID.PageIndexChanged += new DataGridPageChangedEventHandler(THE_GRID_PageIndexChanged);
			
			BoundColumn columns = new BoundColumn();
			columns.HeaderText = "IDAP";
			columns.DataField = "ID_AP_WALLET_SIZE_CATEGORY_TO_AP_MODEL";
			columns.HeaderStyle.CssClass = "tdSmallHeader";
			columns.HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
			columns.HeaderStyle.Width = Unit.Percentage(5.0);
			columns.ItemStyle.Width = Unit.Percentage(5.0);
			columns.Visible = false;
			THE_GRID.Columns.Add(columns);
			

			columns = new BoundColumn();
			columns.HeaderText = "Wholesale/Alliance Product Group";
			columns.DataField = "Group";
			columns.HeaderStyle.CssClass = "tdSmallHeader";
			columns.HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
			columns.HeaderStyle.Width = Unit.Percentage(5.0);
			columns.ItemStyle.Width = Unit.Percentage(5.0);
			THE_GRID.Columns.Add(columns);

			columns = new BoundColumn();
			columns.HeaderText = "Product Group";
			columns.DataField = "Category";
			columns.HeaderStyle.CssClass = "tdSmallHeader";
			columns.ItemStyle.HorizontalAlign = HorizontalAlign.Center;
			columns.ItemStyle.Width = Unit.Percentage(10.0);
			THE_GRID.Columns.Add(columns);

			/*TemplateColumn columnsz = new TemplateColumn();
			columnsz.HeaderText = "Sub-Group";
			columnsz.HeaderStyle.CssClass = "tdSmallHeader";
			columnsz.ItemStyle.HorizontalAlign = HorizontalAlign.Center;
			columnsz.ItemStyle.Width = Unit.Percentage(10.0);
			LBT = new LinkButtonTemplate("LBT_" + CIF);
			columnsz.ItemTemplate = LBT;
			THE_GRID.Columns.Add(columnsz);*/

			columns = new BoundColumn();
			columns.HeaderText = "Current Income";
			columns.DataField = "CURRENT_INCOME";
			columns.HeaderStyle.CssClass = "tdSmallHeader";
			columns.ItemStyle.HorizontalAlign = HorizontalAlign.Center;
			columns.ItemStyle.Width = Unit.Percentage(10.0);
			THE_GRID.Columns.Add(columns);

			columns = new BoundColumn();
			columns.HeaderText = "Potential Income";
			columns.DataField = "POTENTIAL_INCOME";
			columns.HeaderStyle.CssClass = "tdSmallHeader";
			columns.ItemStyle.HorizontalAlign = HorizontalAlign.Center;
			columns.ItemStyle.Width = Unit.Percentage(10.0);
			THE_GRID.Columns.Add(columns);

			columns = new BoundColumn();
			columns.HeaderText = "Current Volume";
			columns.DataField = "CURRENT_VOLUME";
			columns.HeaderStyle.CssClass = "tdSmallHeader";
			columns.ItemStyle.HorizontalAlign = HorizontalAlign.Center;
			columns.ItemStyle.Width = Unit.Percentage(10.0);
			THE_GRID.Columns.Add(columns);

			columns = new BoundColumn();
			columns.HeaderText = "Potential Volume";
			columns.DataField = "POTENTIAL_VOLUME";
			columns.HeaderStyle.CssClass = "tdSmallHeader";
			columns.ItemStyle.HorizontalAlign = HorizontalAlign.Center;
			columns.ItemStyle.Width = Unit.Percentage(10.0);
			THE_GRID.Columns.Add(columns);

			/*columns = new BoundColumn();
			columns.HeaderText = "ID_AP_WALLET_SIZE_RESULT";
			columns.DataField = "ID_AP_WALLET_SIZE_RESULT";
			columns.HeaderStyle.CssClass = "tdSmallHeader";
			columns.Visible = false;
			columns.ItemStyle.HorizontalAlign = HorizontalAlign.Center;
			columns.ItemStyle.Width = Unit.Percentage(10.0);
			THE_GRID.Columns.Add(columns);*/

			conn2.QueryString = "EXEC AP_RECAP_WALLET_SIZE '" + CIF + "','ANCHORONLY'";
			BindData(THE_GRID, conn2.QueryString);

			TR = new HtmlTableRow();
			TD = new HtmlTableCell();
			TD.Attributes["colspan"] = "2";
			TD.Controls.Add(THE_GRID);
			TR.Controls.Add(TD);

			MAIN_TABLE.Controls.Add(TR);
			/*DUA KOLOM DIBAWAH MAIN LABEL*/

			TR = new HtmlTableRow();
			TD = new HtmlTableCell();
			LBL_LABEL = new Label();
			LBL_LABEL.Text = " ";
			TD.Controls.Add(LBL_LABEL);
			TR.Controls.Add(TD);
			MAIN_TABLE.Controls.Add(TR);

			/*************************************************************************************/
			/*************************************************************************************/
			/*TBL = new HtmlTable();
			TBL.Attributes["width"] = "100%";
			TBL.Attributes["cellSpacing"] = "0";
			TBL.Attributes["cellPadding"] = "0";
			TR = new HtmlTableRow();
			TR.Attributes["width"] = "100%";

			TD = new HtmlTableCell();
			LBL_LABEL = new Label();
			LBL_LABEL.Text = "Category Product :";
			TD.Controls.Add(LBL_LABEL);
			TD.Attributes["class"] = "TDBGColor1";
			TD.Attributes["width"] = "35%";
			TR.Controls.Add(TD);

			TD = new HtmlTableCell();
			DDL = new DropDownList();
			DDL.ID = "DDL_CATEGORY_PRODUCT_" + CIF;
			DDL.Width = Unit.Percentage(100.0);
			DDL.BackColor = System.Drawing.Color.LightGray;
			DDL.ForeColor = System.Drawing.Color.Black;
			DDL.Enabled = false;
			GlobalTools.fillRefList(DDL, "SELECT DISTINCT ID_AP_WALLET_SIZE_CATEGORY, DESCRIPTION FROM AP_WALLET_SIZE_CATEGORY", conn);
			TD.Attributes["class"] = "TDBGColorValue";
			TD.Controls.Add(DDL);
			TR.Controls.Add(TD);
			
			TBL.Controls.Add(TR); */
			/**************************************************************************************/
			/*TBL.Attributes["width"] = "100%";
			TR = new HtmlTableRow();
			TR.Attributes["width"] = "100%";

			TD = new HtmlTableCell();
			LBL_LABEL = new Label();
			LBL_LABEL.Text = "Product Link :";
			TD.Controls.Add(LBL_LABEL);
			TD.Attributes["class"] = "TDBGColor1";
			TD.Attributes["width"] = "35%";
			TR.Controls.Add(TD);

			TD = new HtmlTableCell();
			DDL = new DropDownList();
			DDL.ID = "DDL_PRODUCT_LINK_" + CIF;
			DDL.Width = Unit.Percentage(100.0);
			DDL.BackColor = System.Drawing.Color.LightGray;
			DDL.ForeColor = System.Drawing.Color.Black;
			DDL.Enabled = false;
			GlobalTools.fillRefList(DDL, "SELECT ID_AP_VARIABLE, DESCRIPTION FROM AP_VARIABLE", conn);
			TD.Attributes["class"] = "TDBGColorValue";
			TD.Controls.Add(DDL);
			TR.Controls.Add(TD);
			
			TBL.Controls.Add(TR); */
			/**************************************************************************************/
			/*TBL.Attributes["width"] = "100%";
			TR = new HtmlTableRow();
			TR.Attributes["width"] = "100%";

			TD = new HtmlTableCell();
			LBL_LABEL = new Label();
			LBL_LABEL.Text = "Priority :";
			TD.Controls.Add(LBL_LABEL);
			TD.Attributes["class"] = "TDBGColor1";
			TD.Attributes["width"] = "35%";
			TR.Controls.Add(TD);

			TD = new HtmlTableCell();
			TXT_BOX = new TextBox();
			TXT_BOX.ID = "TXT_PRIORITY_" + CIF;
			TXT_BOX.Width = Unit.Percentage(100.0);
			TXT_BOX.Enabled = false;
			TXT_BOX.BackColor = System.Drawing.Color.LightGray;
			TD.Attributes["class"] = "TDBGColorValue";
			TD.Controls.Add(TXT_BOX);
			TR.Controls.Add(TD);
			
			TBL.Controls.Add(TR); 
			TRMain = new HtmlTableRow();
			TD = new HtmlTableCell();
			TD.Attributes["class"] = "td";
			TD.Controls.Add(TBL);
			TRMain.Controls.Add(TD);*/

			/*TR = new HtmlTableRow();
			TD = new HtmlTableCell();
			TD.Attributes["class"] = "TDBGColor2";
			TD.Attributes["align"] = "center";
			TD.Attributes["width"] = "100%";
			TD.Attributes["colSpan"] = "2";
			BTN = new Button();
			BTN.Attributes["class"] = "button1";
			BTN.Text = "   Update   ";
			BTN.ID = "BTNUPDATE_" + CIF.ToString();
			// EVENT UNTUK SAVE
			BTN.Click += new EventHandler(BTN_Click);
			TD.Controls.Add(BTN);
			TR.Controls.Add(TD);

			MAIN_TABLE.Controls.Add(TR);*/
		}

		private void CreatePageComponent2(string CIF)
		{
			System.Web.UI.WebControls.Button BTN;
			System.Web.UI.WebControls.TextBox TXT_BOX;
			System.Web.UI.HtmlControls.HtmlTable TBL;
			System.Web.UI.WebControls.DataGrid THE_GRID;
			System.Web.UI.WebControls.DropDownList DDL;
			System.Web.UI.HtmlControls.HtmlTableRow TR;
			System.Web.UI.HtmlControls.HtmlTableRow TRMain;
			System.Web.UI.HtmlControls.HtmlTableCell TD;
			System.Web.UI.WebControls.Label LBL_LABEL;
			LinkButtonTemplate LBT;

			TR = new HtmlTableRow();
			TD = new HtmlTableCell();
			LBL_LABEL = new Label();
			LBL_LABEL.Text = " ";
			TD.Controls.Add(LBL_LABEL);
			TR.Controls.Add(TD);
			MAIN_TABLE.Controls.Add(TR);

			TR = new HtmlTableRow();
			TD = new HtmlTableCell();
			LBL_LABEL = new Label();
 
			conn.QueryString = "SELECT * FROM AP_COMPANY_INFO WHERE CIF_CUST = '" + CIF + "'";
			conn.ExecuteQuery();

			LBL_LABEL.Text = conn.GetFieldValue("CUSTOMER_NAME");
			TD.Controls.Add(LBL_LABEL);
			TD.Attributes["class"] = "tdHeader1";
			TD.Attributes["colspan"] = "2";
			TR.Controls.Add(TD);
			MAIN_TABLE.Controls.Add(TR);

			/*********************** GRID DIBAWAH MAIN LABEL *******************************/
			THE_GRID = new DataGrid();
			THE_GRID.ID = "GRID_" + CIF;
			THE_GRID.AllowPaging = true;
			THE_GRID.ShowFooter = true;
			THE_GRID.PageSize = 10;
			THE_GRID.CellPadding = 1;
			THE_GRID.AutoGenerateColumns = false;
			THE_GRID.Width = Unit.Percentage(100.0);
			//THE_GRID.Width = Unit.Pixel(1024);
			THE_GRID.AlternatingItemStyle.CssClass = "TblAlternating";
			THE_GRID.PagerStyle.Mode = PagerMode.NumericPages;
			THE_GRID.ItemCommand += new DataGridCommandEventHandler(THE_GRID_ItemCommand);
			THE_GRID.PageIndexChanged += new DataGridPageChangedEventHandler(THE_GRID_PageIndexChanged);
			
			BoundColumn columns = new BoundColumn();
			columns.HeaderText = "IDAP";
			columns.DataField = "ID_AP_WALLET_SIZE_CATEGORY_TO_AP_MODEL";
			columns.HeaderStyle.CssClass = "tdSmallHeader";
			columns.HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
			columns.HeaderStyle.Width = Unit.Percentage(5.0);
			columns.ItemStyle.Width = Unit.Percentage(5.0);
			columns.Visible = false;
			THE_GRID.Columns.Add(columns);
			

			columns = new BoundColumn();
			columns.HeaderText = "Category";
			columns.DataField = "Category";
			columns.HeaderStyle.CssClass = "tdSmallHeader";
			columns.HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
			columns.HeaderStyle.Width = Unit.Percentage(5.0);
			columns.ItemStyle.Width = Unit.Percentage(5.0);
			THE_GRID.Columns.Add(columns);

			columns = new BoundColumn();
			columns.HeaderText = "Product";
			columns.DataField = "Product";
			columns.HeaderStyle.CssClass = "tdSmallHeader";
			columns.ItemStyle.HorizontalAlign = HorizontalAlign.Center;
			columns.ItemStyle.Width = Unit.Percentage(10.0);
			THE_GRID.Columns.Add(columns);

			TemplateColumn columnsz = new TemplateColumn();
			columnsz.HeaderText = "Setup Target";
			columnsz.HeaderStyle.CssClass = "tdSmallHeader";
			columnsz.ItemStyle.HorizontalAlign = HorizontalAlign.Center;
			columnsz.ItemStyle.Width = Unit.Percentage(10.0);
			LBT = new LinkButtonTemplate("LBT_" + CIF);
			columnsz.ItemTemplate = LBT;
			THE_GRID.Columns.Add(columnsz);

			columns = new BoundColumn();
			columns.HeaderText = "Priority";
			columns.DataField = "Priority";
			columns.HeaderStyle.CssClass = "tdSmallHeader";
			columns.ItemStyle.HorizontalAlign = HorizontalAlign.Center;
			columns.ItemStyle.Width = Unit.Percentage(10.0);
			THE_GRID.Columns.Add(columns);

			columns = new BoundColumn();
			columns.HeaderText = "Unit for Volume";
			columns.DataField = "UnitForVolume";
			columns.HeaderStyle.CssClass = "tdSmallHeader";
			columns.ItemStyle.HorizontalAlign = HorizontalAlign.Center;
			columns.ItemStyle.Width = Unit.Percentage(10.0);
			THE_GRID.Columns.Add(columns);

			columns = new BoundColumn();
			columns.HeaderText = "Wallet size (model) - Volume";
			columns.DataField = "WalletSizeModelVolume";
			columns.HeaderStyle.CssClass = "tdSmallHeader";
			columns.ItemStyle.HorizontalAlign = HorizontalAlign.Center;
			columns.ItemStyle.Width = Unit.Percentage(10.0);
			THE_GRID.Columns.Add(columns);

			columns = new BoundColumn();
			columns.HeaderText = "Wallet size (model) - Income";
			columns.DataField = "WalletSizeModelIncome";
			columns.HeaderStyle.CssClass = "tdSmallHeader";
			columns.ItemStyle.HorizontalAlign = HorizontalAlign.Center;
			columns.ItemStyle.Width = Unit.Percentage(10.0);
			THE_GRID.Columns.Add(columns);
			
			columns = new BoundColumn();
			columns.HeaderText = "Wallet size (adjusted) - Volume";
			columns.DataField = "WalletSizeAdjustedVolume";
			columns.HeaderStyle.CssClass = "tdSmallHeader";
			columns.ItemStyle.HorizontalAlign = HorizontalAlign.Center;
			columns.ItemStyle.Width = Unit.Percentage(10.0);
			THE_GRID.Columns.Add(columns);

			columns = new BoundColumn();
			columns.HeaderText = "Wallet size (adjusted) - Income";
			columns.DataField = "WalletSizeAdjustedIncome";
			columns.HeaderStyle.CssClass = "tdSmallHeader";
			columns.ItemStyle.HorizontalAlign = HorizontalAlign.Center;
			columns.ItemStyle.Width = Unit.Percentage(10.0);
			THE_GRID.Columns.Add(columns);

			columns = new BoundColumn();
			columns.HeaderText = "Mandiri Current Condition - Volume";
			columns.DataField = "MandiriCurrentVolume";
			columns.HeaderStyle.CssClass = "tdSmallHeader";
			columns.ItemStyle.HorizontalAlign = HorizontalAlign.Center;
			columns.ItemStyle.Width = Unit.Percentage(10.0);
			THE_GRID.Columns.Add(columns);

			columns = new BoundColumn();
			columns.HeaderText = "Mandiri Current Condition - Income";
			columns.DataField = "MandiriCurrentIncome";
			columns.HeaderStyle.CssClass = "tdSmallHeader";
			columns.ItemStyle.HorizontalAlign = HorizontalAlign.Center;
			columns.ItemStyle.Width = Unit.Percentage(10.0);
			THE_GRID.Columns.Add(columns);

			columns = new BoundColumn();
			columns.HeaderText = "Mandiri Current Condition - W.Share(%)";
			columns.DataField = "MandiriCurrentWalletShare";
			columns.HeaderStyle.CssClass = "tdSmallHeader";
			columns.ItemStyle.HorizontalAlign = HorizontalAlign.Center;
			columns.ItemStyle.Width = Unit.Percentage(10.0);
			THE_GRID.Columns.Add(columns);

			columns = new BoundColumn();
			columns.HeaderText = "Mandiri Current Condition - W.Share(%)";
			columns.DataField = "MandiriCurrentWalletShare";
			columns.HeaderStyle.CssClass = "tdSmallHeader";
			columns.ItemStyle.HorizontalAlign = HorizontalAlign.Center;
			columns.ItemStyle.Width = Unit.Percentage(10.0);
			THE_GRID.Columns.Add(columns);

			columns = new BoundColumn();
			columns.HeaderText = "Remarks - Key Competitors";
			columns.DataField = "RemarksKeyCompetitors";
			columns.HeaderStyle.CssClass = "tdSmallHeader";
			columns.ItemStyle.HorizontalAlign = HorizontalAlign.Center;
			columns.ItemStyle.Width = Unit.Percentage(10.0);
			THE_GRID.Columns.Add(columns);

			columns = new BoundColumn();
			columns.HeaderText = "Remarks - Best Bank W.Share(%)";
			columns.DataField = "RemarksBestBankWallet";
			columns.HeaderStyle.CssClass = "tdSmallHeader";
			columns.ItemStyle.HorizontalAlign = HorizontalAlign.Center;
			columns.ItemStyle.Width = Unit.Percentage(10.0);
			THE_GRID.Columns.Add(columns);

			columns = new BoundColumn();
			columns.HeaderText = "Remarks - Potential Issues";
			columns.DataField = "RemarksPotentialIssues";
			columns.HeaderStyle.CssClass = "tdSmallHeader";
			columns.ItemStyle.HorizontalAlign = HorizontalAlign.Center;
			columns.ItemStyle.Width = Unit.Percentage(10.0);
			THE_GRID.Columns.Add(columns);

			/*columns = new BoundColumn();
			columns.HeaderText = "ID_AP_WALLET_SIZE_RESULT";
			columns.DataField = "ID_AP_WALLET_SIZE_RESULT";
			columns.HeaderStyle.CssClass = "tdSmallHeader";
			columns.Visible = false;
			columns.ItemStyle.HorizontalAlign = HorizontalAlign.Center;
			columns.ItemStyle.Width = Unit.Percentage(10.0);
			THE_GRID.Columns.Add(columns);*/

			conn2.QueryString = "EXEC AP_RECAP_WALLET_SIZE '" + CIF + "','ANCHORONLY'";
			BindData(THE_GRID, conn2.QueryString);

			TR = new HtmlTableRow();
			TD = new HtmlTableCell();
			TD.Attributes["colspan"] = "2";
			TD.Controls.Add(THE_GRID);
			TR.Controls.Add(TD);

			MAIN_TABLE.Controls.Add(TR);
			/*DUA KOLOM DIBAWAH MAIN LABEL*/

			TR = new HtmlTableRow();
			TD = new HtmlTableCell();
			LBL_LABEL = new Label();
			LBL_LABEL.Text = " ";
			TD.Controls.Add(LBL_LABEL);
			TR.Controls.Add(TD);
			MAIN_TABLE.Controls.Add(TR);

			/**************************************************************************************/
			/*TBL.Attributes["width"] = "100%";
			TR = new HtmlTableRow();
			TR.Attributes["width"] = "100%";

			TD = new HtmlTableCell();
			TD.Attributes["class"] = "TDBGColor1";
			TD.Attributes["width"] = "35%";
			TR.Controls.Add(TD);

			TD = new HtmlTableCell();
			TXT_BOX = new TextBox();
			TXT_BOX.ID = "TXT_IDAP_" + CIF;
			TXT_BOX.Width = Unit.Percentage(100.0);
			TXT_BOX.Visible = false;
			TD.Attributes["class"] = "TDBGColorValue";
			TD.Controls.Add(TXT_BOX);
			TR.Controls.Add(TD);

			TBL.Controls.Add(TR); 
			TR = new HtmlTableRow();
			TD = new HtmlTableCell();
			TD.Attributes["class"] = "td";
			TD.Controls.Add(TBL);
			TRMain.Controls.Add(TD);
			MAIN_TABLE.Controls.Add(TRMain);*/

			/*************************************************************************************/
			/*************************************************************************************/

			//MAIN_TABLE.Controls.Add(TR);
		}

		private class LinkButtonTemplate : ITemplate
		{
			string id = "";
			public LinkButtonTemplate(string id)
			{
				this.id = id;
			}

			public void InstantiateIn(System.Web.UI.Control container)
			{    
				LinkButton lb = new LinkButton();
				lb.ID = "LNK_EDIT_REQ_" + id;
				lb.Text = "Edit";
				lb.CommandName = "edit_req";
				container.Controls.Add(lb);

				Label lbl = new Label();
				lbl.Text = "    ";
				container.Controls.Add(lbl);

				lb = new LinkButton();
				lb.ID = "LNK_DELETE_REQ" + id;
				lb.Text = "Delete";
				lb.CommandName = "delete_req";
				container.Controls.Add(lb);
			}
		}

		private void BTN_Click(object sender, EventArgs e)
		{
			string theCIF = ((Button)sender).ID.Substring(10);
			//Tools.popMessage(this, theCIF);

			DropDownList DDL_CATEGORY_PRODUCT = (DropDownList)this.FindControl("DDL_CATEGORY_PRODUCT_" + theCIF);
			DropDownList DDL_PRODUCT_LINK = (DropDownList)this.FindControl("DDL_PRODUCT_LINK_" + theCIF);
			TextBox TXT_PRIORITY = (TextBox)this.FindControl("TXT_PRIORITY_" + theCIF);
			TextBox TXT_UNIT_FOR_VOLUME = (TextBox)this.FindControl("TXT_UNIT_FOR_VOLUME_" + theCIF);
			TextBox TXT_WALLET_SIZE_MODEL_VOLUME = (TextBox)this.FindControl("TXT_WALLET_SIZE_MODEL_VOLUME_" + theCIF);
			TextBox TXT_WALLET_SIZE_MODEL_INCOME = (TextBox)this.FindControl("TXT_WALLET_SIZE_MODEL_INCOME_" + theCIF);
			TextBox TXT_WALLET_SIZE_ADJ_VOLUME = (TextBox)this.FindControl("TXT_WALLET_SIZE_ADJ_VOLUME_" + theCIF);
			TextBox TXT_WALLET_SIZE_ADJ_INCOME = (TextBox)this.FindControl("TXT_WALLET_SIZE_ADJ_INCOME_" + theCIF);
			TextBox TXT_CURRENT_VOLUME = (TextBox)this.FindControl("TXT_CURRENT_VOLUME_" + theCIF);
			TextBox TXT_CURRENT_INCOME = (TextBox)this.FindControl("TXT_CURRENT_INCOME_" + theCIF);
			TextBox TXT_CURRENT_W_SHARE = (TextBox)this.FindControl("TXT_CURRENT_W_SHARE_" + theCIF);
			TextBox TXT_TARGET_VOLUME = (TextBox)this.FindControl("TXT_TARGET_VOLUME_" + theCIF);
			TextBox TXT_TARGET_INCOME = (TextBox)this.FindControl("TXT_TARGET_INCOME_" + theCIF);
			TextBox TXT_TARGET_W_SHARE = (TextBox)this.FindControl("TXT_TARGET_W_SHARE_" + theCIF);
			TextBox TXT_KEY_COMPETITOR = (TextBox)this.FindControl("TXT_KEY_COMPETITOR_" + theCIF);
			TextBox TXT_BEST_BANK_W_SHARE = (TextBox)this.FindControl("TXT_BEST_BANK_W_SHARE_" + theCIF);
			TextBox TXT_POTENTIAL_ISSUES = (TextBox)this.FindControl("TXT_POTENTIAL_ISSUES_" + theCIF);
			TextBox TXT_IDAP = (TextBox)this.FindControl("TXT_IDAP_" + theCIF);

			long ID_AP_WALLET_SIZE_RESULT = 0;
			string ID_AP_WALLET_SIZE_CATEGORY_TO_AP_MODEL = TXT_IDAP.Text.ToString();

			/**************** get ID_AP_WALLET_SIZE_CATEGORY_TO_AP_MODEL ********************/
			/*conn.QueryString = "SELECT ";
			conn.ExecuteQuery();*/
			/********************************************************************************/

			string CU_CIF = theCIF;
			string UNIT_FOR_VOLUME = TXT_UNIT_FOR_VOLUME.Text.ToString();
			string WALLET_SIZE_MODEL_VOLUME = TXT_WALLET_SIZE_MODEL_VOLUME.Text.ToString();
			string WALLET_SIZE_MODEL_INCOME = TXT_WALLET_SIZE_MODEL_INCOME.Text.ToString();
			string WALLET_SIZE_ADJUSTED_VOLUME = TXT_WALLET_SIZE_ADJ_VOLUME.Text.ToString();
			string WALLET_SIZE_ADJUSTED_INCOME = TXT_WALLET_SIZE_ADJ_INCOME.Text.ToString();
			string MANDIRI_CURRENT_VOLUME = TXT_CURRENT_VOLUME.Text.ToString();
			string MANDIRI_CURRENT_INCOME = TXT_CURRENT_INCOME.Text.ToString();
			string MANDIRI_CURRENT_WALLET_SHARE_PERCENT = TXT_CURRENT_W_SHARE.Text.ToString();
			string TARGET_VOLUME = TXT_TARGET_VOLUME.Text.ToString();
			string TARGET_INCOME = TXT_TARGET_INCOME.Text.ToString();
			string TARGET_WALLET_SHARE_PERCENT = TXT_TARGET_W_SHARE.Text.ToString();
			string PRIORITY = TXT_PRIORITY.Text.ToString();
			string REMARKS_KEY_COMPETITORS = TXT_KEY_COMPETITOR.Text.ToString();
 			string REMARKS_BEST_BANK_WALLET_SHARED = TXT_BEST_BANK_W_SHARE.Text.ToString();
			string REMARKS_POTENTIAL_ISSUES = TXT_POTENTIAL_ISSUES.Text.ToString();

			conn.QueryString = "EXEC AP_UPDATE_WALLET_SIZE_RESULT '" +
				ID_AP_WALLET_SIZE_CATEGORY_TO_AP_MODEL + "','" +
				CU_CIF + "','" + 
				UNIT_FOR_VOLUME + "','" +
				WALLET_SIZE_MODEL_VOLUME + "','" +
				WALLET_SIZE_MODEL_INCOME + "','" +
				WALLET_SIZE_ADJUSTED_VOLUME + "','" +
				WALLET_SIZE_ADJUSTED_INCOME + "','" +
				MANDIRI_CURRENT_VOLUME + "','" +
				MANDIRI_CURRENT_INCOME + "','" +
				MANDIRI_CURRENT_WALLET_SHARE_PERCENT + "','" +
				TARGET_VOLUME + "','" + 
				TARGET_INCOME + "','" +
				TARGET_WALLET_SHARE_PERCENT + "','" +
				PRIORITY + "','" +
				REMARKS_KEY_COMPETITORS + "','" +
				REMARKS_BEST_BANK_WALLET_SHARED + "','" +
				REMARKS_POTENTIAL_ISSUES + "'";
			conn.ExecuteQuery();

			DataGrid THE_GRID =  (DataGrid)this.FindControl("GRID_" + CU_CIF);
			conn2.QueryString = "EXEC AP_RECAP_WALLET_SIZE '" + CU_CIF + "','ANCHORONLY'";
			BindData(THE_GRID, conn2.QueryString);
		}

		private void THE_GRID_ItemCommand(object source, DataGridCommandEventArgs e)
		{
			string IDAP = "";
			string theCIF = "";
			switch (((LinkButton)e.CommandSource).CommandName)
			{
				case "edit_req":
					IDAP = e.Item.Cells[0].Text.Trim();
					theCIF = ((DataGrid)source).ID.Remove(0,5);
					RetreiveData(IDAP, theCIF);
					break;
				case "delete_req":
					IDAP = e.Item.Cells[0].Text.Trim();
					theCIF = ((DataGrid)source).ID.Remove(0,5);
					DeleteResult(IDAP, theCIF);
					break;
			}
		}

		private void THE_GRID_PageIndexChanged(object source, DataGridPageChangedEventArgs e)
		{
			DataGrid dGrid = (DataGrid)source;
			string CIF = dGrid.ID.Remove(0,5);
			/*.ID = "GRID_" + CIF;*/
			if(dGrid.CurrentPageIndex >= 0 && dGrid.CurrentPageIndex < dGrid.PageCount)
			{
				dGrid.CurrentPageIndex = e.NewPageIndex;
				conn2.QueryString = "EXEC AP_RECAP_WALLET_SIZE '" + CIF + "','ANCHORONLY'";
				BindData(dGrid, conn2.QueryString);
			}
		}

		private void calculate(string cu_cif)
		{
			conn.QueryString = "SELECT * FROM AP_WALLET_SIZE_RESULT WHERE CU_CIF = '" + cu_cif + "'";
			conn.ExecuteQuery();

			string status = "";
			if(conn.GetRowCount() == 0)
			{
				status = "INSERT";
			}
			else
			{
				status = "UPDATE";
			}

			/*
			 *	ID_AP_WALLET_SIZE_RESULT
				ID_AP_WALLET_SIZE_CATEGORY_TO_AP_MODEL
				CU_CIF
				CURRENT_INCOME
				POTENTIAL_INCOME
				CURRENT_VOLUME
				POTENTIAL_VOLUME
			 * */

			string CURRENT_INCOME = "";
			string POTENTIAL_INCOME = "";
			string CURRENT_VOLUME = "";
			string POTENTIAL_VOLUME = "";

			/*
			 *	ID_AP_WALLET_SIZE_CATEGORY
				ID_AP_VARIABLE
				ID_AP_WALLET_SIZE_CATEGORY_TO_AP_MODEL
				ID_AP_WHOLESALE_ALLIANCE_CATEGORY
				ID_AP_BENCHMARK
			 *
			 * */

			string ID_AP_WHOLESALE_ALLIANCE_CATEGORY = "";
			string ID_AP_WALLET_SIZE_CATEGORY = "";
			string ID_AP_VARIABLE = "";
			string ID_AP_WALLET_SIZE_CATEGORY_TO_AP_MODEL = ""; 
			string ID_AP_BENCHMARK = "";

			string QUERY = "";
			string CI_COLUMN = "";
			string CV_COLUMN = "";
			string PI_COLUMN = "";
			string PV_COLUMN = "";
			string COLTYPE = "";
			string BENCHMARK_VALUE = "";

			conn.QueryString = "SELECT ID_AP_WHOLESALE_ALLIANCE_CATEGORY FROM AP_WHOLESALE_ALLIANCE_CATEGORY";
			conn.ExecuteQuery();

			for(int z = 0; z<conn.GetRowCount(); z++)
			{
				ID_AP_WHOLESALE_ALLIANCE_CATEGORY = conn.GetFieldValue(z, "ID_AP_WHOLESALE_ALLIANCE_CATEGORY");

				conn2.QueryString = "SELECT ID_AP_WALLET_SIZE_CATEGORY FROM AP_WALLET_SIZE_CATEGORY";
				conn2.ExecuteQuery();

				for(int i = 0; i<conn2.GetRowCount(); i++)
				{
					ID_AP_WALLET_SIZE_CATEGORY = conn2.GetFieldValue(i, "ID_AP_WALLET_SIZE_CATEGORY");

					conn3.QueryString = "SELECT ID_AP_VARIABLE FROM AP_VARIABLE";
					conn3.ExecuteQuery();

					for(int j = 0; j<conn3.GetRowCount(); j++)
					{
						ID_AP_VARIABLE = conn3.GetFieldValue(j, "ID_AP_VARIABLE");

						conn4.QueryString = "SELECT ID_AP_WALLET_SIZE_CATEGORY_TO_AP_MODEL, ID_AP_BENCHMARK FROM " +
							"AP_WALLET_SIZE_CATEGORY_TO_AP_MODEL WHERE " +
							"ID_AP_WHOLESALE_ALLIANCE_CATEGORY = '" + ID_AP_WHOLESALE_ALLIANCE_CATEGORY + "' AND " +
							"ID_AP_VARIABLE = '" + ID_AP_VARIABLE + "' AND " +
							"ID_AP_WALLET_SIZE_CATEGORY = '" + ID_AP_WALLET_SIZE_CATEGORY + "'";
						conn4.ExecuteQuery();

						for(int k = 0; k<conn4.GetRowCount(); k++)
						{
							ID_AP_WALLET_SIZE_CATEGORY_TO_AP_MODEL = conn4.GetFieldValue(k, "ID_AP_WALLET_SIZE_CATEGORY_TO_AP_MODEL");
							ID_AP_BENCHMARK = conn4.GetFieldValue(k, "ID_AP_BENCHMARK");
							
							conn5.QueryString = "SELECT QUERY, CI_COLUMN, PI_COLUMN, CV_COLUMN, PV_COLUMN, COLTYPE FROM AP_VARIABLE WHERE ID_AP_VARIABLE = '" + ID_AP_VARIABLE + "'";
							conn5.ExecuteQuery();

							if(conn5.GetFieldValue("QUERY") == "" || conn5.GetFieldValue("QUERY") == null)
							{
								continue;
							}

							QUERY = conn5.GetFieldValue("QUERY");
							COLTYPE = conn5.GetFieldValue("COLTYPE");
							CI_COLUMN = conn5.GetFieldValue("CI_COLUMN");
							CV_COLUMN = conn5.GetFieldValue("CV_COLUMN");
							PI_COLUMN = conn5.GetFieldValue("PI_COLUMN");
							PV_COLUMN = conn5.GetFieldValue("PV_COLUMN");

							conn5.QueryString = "SELECT [VALUES] FROM AP_BENCHMARK WHERE ID_AP_BENCHMARK = '" + ID_AP_BENCHMARK + "'";
							conn5.ExecuteQuery();
							BENCHMARK_VALUE = conn5.GetFieldValue("VALUES").ToString();

							//dari sini lakukan calculate
							CURRENT_INCOME = "";
							if(COLTYPE == "PROCEDURE")
							{
								conn5.QueryString = "EXEC " + QUERY + " '" + cu_cif + "'";
								conn5.ExecuteQuery();
							}

							else if(COLTYPE == "TABLE")
							{	
								conn5.QueryString = "SELECT * FROM " + QUERY + " WHERE CU_CIF = '" + cu_cif + "'";
								conn5.ExecuteQuery();
							}

							CURRENT_INCOME = conn5.GetFieldValue(CI_COLUMN).ToString();
			
							if(CURRENT_INCOME == "" || CURRENT_INCOME == null)
							{
								CURRENT_INCOME = "0.0";
							}

							POTENTIAL_VOLUME = conn5.GetFieldValue(PV_COLUMN).ToString();

							if(POTENTIAL_VOLUME == "" || POTENTIAL_VOLUME == null)
							{
								POTENTIAL_VOLUME = ((double)(MyConnection.ConvertToDouble2(CURRENT_INCOME) * MyConnection.ConvertToDouble2(BENCHMARK_VALUE))).ToString();
							}

							POTENTIAL_INCOME = conn5.GetFieldValue(PI_COLUMN).ToString();

							if(POTENTIAL_INCOME == "" || POTENTIAL_INCOME == null)
							{
								POTENTIAL_INCOME = ((double)(MyConnection.ConvertToDouble2(POTENTIAL_VOLUME) * MyConnection.ConvertToDouble2(BENCHMARK_VALUE))).ToString();
							}

							CURRENT_VOLUME = conn5.GetFieldValue(CV_COLUMN).ToString();

							if(CURRENT_VOLUME == "" || CURRENT_VOLUME == null)
							{
								CURRENT_VOLUME = "0.0";
							}

							//done wallet size result
							conn5.QueryString = "SELECT * FROM AP_WALLET_SIZE_RESULT WHERE ID_AP_WALLET_SIZE_CATEGORY_TO_AP_MODEL = '" + ID_AP_WALLET_SIZE_CATEGORY_TO_AP_MODEL + "' AND " +
								"CU_CIF = '" + cu_cif + "'";
							conn5.ExecuteQuery();

							if(conn5.GetRowCount() == 0)
							{
								conn5.QueryString = "INSERT INTO AP_WALLET_SIZE_RESULT " +
									"(ID_AP_WALLET_SIZE_CATEGORY_TO_AP_MODEL," +
									"CU_CIF," +
									"CURRENT_INCOME," +
									"POTENTIAL_INCOME," +
									"CURRENT_VOLUME," +
									"POTENTIAL_VOLUME) " +
									"VALUES (" + 
									ID_AP_WALLET_SIZE_CATEGORY_TO_AP_MODEL + ",'" +
									cu_cif + "','" +
									CURRENT_INCOME + "','" +
									POTENTIAL_INCOME + "','" +
									CURRENT_VOLUME + "','" +
									POTENTIAL_VOLUME + "')";
								conn5.ExecuteQuery();
							}
							else
							{
								conn5.QueryString = "UPDATE AP_WALLET_SIZE_RESULT " +
									"SET CURRENT_INCOME = '" + CURRENT_INCOME + "'," +
									"POTENTIAL_INCOME = '" + POTENTIAL_INCOME + "'," +
									"CURRENT_VOLUME = '" + CURRENT_VOLUME + "'," +
									"POTENTIAL_VOLUME = '" + POTENTIAL_VOLUME + "' " +
									"WHERE ID_AP_WALLET_SIZE_CATEGORY_TO_AP_MODEL = " +  ID_AP_WALLET_SIZE_CATEGORY_TO_AP_MODEL + " AND " +
									"CU_CIF = '" + cu_cif + "'";
								conn5.ExecuteQuery();
							}
						}
					}
				}
			}
		}

		private void calculateBackup(string cu_cif)
		{
			conn.QueryString = "SELECT * FROM AP_WALLET_SIZE_RESULT WHERE CU_CIF = '" + cu_cif + "'";
			conn.ExecuteQuery();

			string status = "";
			if(conn.GetRowCount() == 0)
			{
				status = "INSERT";
			}
			else
			{
				status = "UPDATE";
			}

			string ID_AP_WALLET_SIZE_CATEGORY_TO_AP_MODEL = ""; 
			string CATEGORY = ""; //wholesale lending
			string VARIABLE = ""; // investment loan
			string NILAIUPLOAD = "";
			string PARAMETERVALUE = "";
			string RESULT = "";

			//insert value satu satu based on category ke wallet size result
			conn.QueryString = "SELECT ID_AP_WALLET_SIZE_CATEGORY FROM AP_WALLET_SIZE_CATEGORY";
			conn.ExecuteQuery();

			for(int i = 0; i<conn.GetRowCount(); i++)
			{
				CATEGORY = conn.GetFieldValue(i, "ID_AP_WALLET_SIZE_CATEGORY");

				conn2.QueryString = "SELECT ID_AP_VARIABLE, ID_AP_WALLET_SIZE_CATEGORY_TO_AP_MODEL  FROM AP_WALLET_SIZE_CATEGORY_TO_AP_MODEL WHERE ID_AP_WALLET_SIZE_CATEGORY = '" + CATEGORY + "'";
				conn2.ExecuteQuery();

				ID_AP_WALLET_SIZE_CATEGORY_TO_AP_MODEL = conn2.GetFieldValue("ID_AP_WALLET_SIZE_CATEGORY_TO_AP_MODEL");
				VARIABLE = conn2.GetFieldValue("ID_AP_VARIABLE");

				//dapetin semua variable
				string IDBENCHMARK = "";
				string IDRELATIONTOTABLEUPLOAD = "";

				for(int k = 0; k<conn2.GetRowCount(); k++)
				{
					#region INSERT EACH RESULT PERCATEGORY

					conn3.QueryString = "SELECT * FROM AP_VARIABLE WHERE ID_AP_VARIABLE = '" + VARIABLE + "'";
					conn3.ExecuteQuery();

					VARIABLE = conn3.GetFieldValue("ID_AP_VARIABLE");
					IDBENCHMARK = conn3.GetFieldValue("ID_AP_BENCHMARK");
					IDRELATIONTOTABLEUPLOAD = conn3.GetFieldValue("ID_AP_UPLOADED_DATA");
					double RESULTDOUBLE = 1.0;

					//masing masing variable punya formula sendiri lo

					conn3.QueryString = "SELECT * FROM AP_ITEM WHERE ID_AP_VARIABLE = '" + VARIABLE + "'";
					conn3.ExecuteQuery();

					//hitung dari sini, dilooping dikalikan
					#region INSERT EACH RESULT PERITEM
					for(int l = 0; l<conn3.GetRowCount(); l++)
					{
						//1.Ambil variable dari hasil upload
						/********************* ambil nilai upload ***********************/
						string QUERY = "";
						string QUERYFIELD = "";
						string ISRANGE = "";
						string ID_AP_ITEM = "";
						string NERACAVALUE = "";
						
						QUERY = conn3.GetFieldValue(l,"QUERY");
						QUERYFIELD = conn3.GetFieldValue(l,"FIELD");
						ISRANGE = conn3.GetFieldValue(l,"ISRANGE");
						ID_AP_ITEM = conn3.GetFieldValue(l,"ID_AP_ITEM");

						string TABLE = "";
						string FIELD = "";

						conn4.QueryString = "SELECT TABLE, FIELD FROM AP_UPLOADED_DATA WHERE ID_AP_UPLOADED_DATA = '" + IDRELATIONTOTABLEUPLOAD + "'";
						conn4.ExecuteQuery();

						TABLE  = conn4.GetFieldValue("TABLE");
						FIELD = conn4.GetFieldValue("FIELD");

						conn4.QueryString = "SELECT " + TABLE + " FROM " + FIELD + " WHERE CU_CIF = '" + cu_cif + "'";
						conn4.ExecuteQuery();

						try
						{
							/***************** SET-UP NILAI UPLOAD ******************/
							/*****/ NILAIUPLOAD = conn3.GetFieldValue(TABLE); /******/
							/********************************************************/
						}
						catch
						{
							/***************** SET-UP NILAI UPLOAD ******************/
							/*****************/ NILAIUPLOAD = ""; /******************/
							/********************************************************/
						}
						/***************************************************************/
						//kalau di upload g ada, langsung ambil dari benchmark
						if(NILAIUPLOAD == "")
						{
							//ambil dari benchmark
							conn4.QueryString = "SELECT VALUES FROM AP_BENCHMARK WHERE ID_AP_BENCHMARK = '" + IDBENCHMARK + "'";
							/***************** SET-UP NILAI BENCHMARK ******************/
							/*****/ NILAIUPLOAD = conn4.GetFieldValue("VALUES"); /******/
							/***********************************************************/
						}

						//2.Nilai Upload / Benchmark uda didapat sekarang ambil nilai di laporan keuangan
						/********************* ambil dari neraca keuangan ***********************/
						conn4.QueryString = "EXEC " + QUERY + " '" + cu_cif + "'";
						conn4.ExecuteQuery();

						/***************** SET-UP NILAI DARI NERACA ********************/ 
						try
						{
							NERACAVALUE = conn4.GetFieldValue(QUERYFIELD); 
						}
						catch
						{
							NERACAVALUE = "";
						}
						/***************************************************************/

						//3.Nilai dari neraca bandingin ama parameter
						if(NERACAVALUE != "")
						{
							/********************* ambil nilai dari parameter **********************/
							if(ISRANGE == "0")
							{
								conn4.QueryString = "SELECT SCORE, VALUES FROM AP_ITEM_NON_RANGE WHERE ID_AP_ITEM = '" + ID_AP_ITEM + "'";
								conn4.ExecuteQuery();

								//dapat value, dicompare ama NERACA VALUE

								for(int m = 0; m<conn4.GetRowCount(); m++)
								{
									if(decimal.Parse(conn4.GetFieldValue(m, "SCORE")) == decimal.Parse(NERACAVALUE))
									{
										/***************** SET-UP NILAI DARI PARAMETER ********************/
										/******/ PARAMETERVALUE = conn4.GetFieldValue(m, "VALUES"); /******/
										/******************************************************************/
										break;
									}
								}
							}
							else if(ISRANGE == "1")
							{
								conn4.QueryString = "SELECT LOWEST, HIGHEST, VALUES FROM AP_ITEM_RANGE WHERE ID_AP_ITEM = '" + VARIABLE + "'";
								conn4.ExecuteQuery();

								for(int m = 0; m<conn4.GetRowCount(); m++)
								{
									if(conn4.GetFieldValue(m, "LOWEST") == "LOWEST")
									{
										if(decimal.Parse(NERACAVALUE) <= decimal.Parse(conn4.GetFieldValue(m, "HIGHEST")))
										{
											/***************** SET-UP NILAI DARI PARAMETER ********************/
											/******/ PARAMETERVALUE = conn4.GetFieldValue(m, "VALUES"); /******/
											/******************************************************************/
											break;
										}
									}
									else if(conn4.GetFieldValue(m, "HIGHEST") == "HIGHEST")
									{
										if(decimal.Parse(NERACAVALUE) >= decimal.Parse(conn4.GetFieldValue(m, "HIGHEST")))
										{
											/***************** SET-UP NILAI DARI PARAMETER ********************/
											/******/ PARAMETERVALUE = conn4.GetFieldValue(m, "VALUES"); /******/
											/******************************************************************/
											break;
										}
									}
									else
									{
										if((decimal.Parse(NERACAVALUE) >= decimal.Parse(conn4.GetFieldValue(m, "LOWEST")))
											&& (decimal.Parse(NERACAVALUE) <= decimal.Parse(conn4.GetFieldValue(m, "HIGHEST"))))
										{
											/***************** SET-UP NILAI DARI PARAMETER ********************/
											/******/ PARAMETERVALUE = conn4.GetFieldValue(m, "VALUES"); /******/
											/******************************************************************/
											break;
										}
									}
								}
							}
						}
						else
						{
							//ambil dari benchmark
							conn4.QueryString = "SELECT VALUES FROM AP_BENCHMARK WHERE ID_AP_BENCHMARK = '" + IDBENCHMARK + "'";
							conn4.ExecuteQuery();
							/***************** SET-UP NILAI BENCHMARK ******************/
							/*****/ PARAMETERVALUE = conn4.GetFieldValue("VALUES"); /******/
							/***********************************************************/
						}
						//4.Nilai dari hasil mapping parameter dioperasikan dengan hasil upload sesuai dengan jenis operator
						double DoubleResult = 0.0d;
						string OPERATOR = "";

						try
						{
							OPERATOR = conn3.GetFieldValue(l,"OPERATOR");
						}
						catch
						{
							OPERATOR = "";
						}

						if(OPERATOR == "*")
						{
							DoubleResult = MyConnection.ConvertToDouble(NERACAVALUE) * MyConnection.ConvertToDouble(PARAMETERVALUE);
						}
						else if(OPERATOR == ":")
						{
							DoubleResult = MyConnection.ConvertToDouble(NERACAVALUE) / MyConnection.ConvertToDouble(PARAMETERVALUE);
						}
						else if(OPERATOR == "+")
						{
							DoubleResult = MyConnection.ConvertToDouble(NERACAVALUE) + MyConnection.ConvertToDouble(PARAMETERVALUE);
						}
						else if(OPERATOR == "-")
						{
							DoubleResult = MyConnection.ConvertToDouble(NERACAVALUE) - MyConnection.ConvertToDouble(PARAMETERVALUE);
						}

						//RESULT = DoubleResult.ToString();
						RESULTDOUBLE *= DoubleResult;
						string teswes = "";
						//dikalkulasi disini
						//Result double adalah hasil kalkulasi per category
						#endregion
					}
					RESULTDOUBLE = 1.0;
					ID_AP_WALLET_SIZE_CATEGORY_TO_AP_MODEL = conn2.GetFieldValue(k, "ID_AP_WALLET_SIZE_CATEGORY_TO_AP_MODEL");

					string UNIT_FOR_VOLUME = "";
					string WALLET_SIZE_MODEL_VOLUME = "";
					string WALLET_SIZE_MODEL_INCOME = "";
					string WALLET_SIZE_ADJUSTED_VOLUME = "";
					string WALLET_SIZE_ADJUSTED_INCOME = "";
					string MANDIRI_CURRENT_VOLUME = "";
					string MANDIRI_CURRENT_INCOME = "";
					string MANDIRI_CURRENT_WALLET_SHARE_PERCENT = "";
					string TARGET_VOLUME = "";
					string TARGET_INCOME = "";
					string TARGET_WALLET_SHARE_PERCENT = "";
					string PRIORITY = "";
					string REMARKS_KEY_COMPETITORS = "";
					string REMARKS_BEST_BANK_WALLET_SHARED = "";
					string REMARKS_POTENTIAL_ISSUES = "";

					if(status == "INSERT")
					{
						conn3.QueryString = "INSERT INTO AP_WALLET_SIZE_RESULT (ID_AP_WALLET_SIZE_CATEGORY_TO_AP_MODEL, " + 
							"CU_CIF, " +
							"UNIT_FOR_VOLUME, " + 
							"WALLET_SIZE_MODEL_VOLUME, " +
							"WALLET_SIZE_MODEL_INCOME, " + 
							"WALLET_SIZE_ADJUSTED_VOLUME, " +
							"WALLET_SIZE_ADJUSTED_INCOME, " + 
							"MANDIRI_CURRENT_VOLUME, " +
							"MANDIRI_CURRENT_INCOME, " + 
							"MANDIRI_CURRENT_WALLET_SHARE_PERCENT, " +
							"TARGET_VOLUME, " +
							"TARGET_INCOME, " +
							"TARGET_WALLET_SHARE_PERCENT, " + 
							"PRIORITY, " +
							"REMARKS_KEY_COMPETITORS, " +
							"REMARKS_BEST_BANK_WALLET_SHARED, " +
							"REMARKS_POTENTIAL_ISSUES) VALUES (" + 
							ID_AP_WALLET_SIZE_CATEGORY_TO_AP_MODEL + ",'" +
							cu_cif + "','" +
							UNIT_FOR_VOLUME + "','" +   
							WALLET_SIZE_MODEL_VOLUME + "','" +
							WALLET_SIZE_MODEL_INCOME + "','" +
							WALLET_SIZE_ADJUSTED_VOLUME + "','" +
							WALLET_SIZE_ADJUSTED_INCOME + "','" +
							MANDIRI_CURRENT_VOLUME + "','" +
							MANDIRI_CURRENT_INCOME + "','" +
							MANDIRI_CURRENT_WALLET_SHARE_PERCENT + "','" +
							TARGET_VOLUME + "','" +
							TARGET_INCOME + "','" +
							TARGET_WALLET_SHARE_PERCENT + "','" +
							PRIORITY + "','" +
							REMARKS_KEY_COMPETITORS + "','" +
							REMARKS_BEST_BANK_WALLET_SHARED + "','" +
							REMARKS_POTENTIAL_ISSUES + "')";
						conn3.ExecuteQuery();
					}
					/*else if(status == "UPDATE")
					{
						conn3.QueryString = "UPDATE AP_WALLET_SIZE_RESULT " + 
							"SET " +
							"UNIT_FOR_VOLUME = '" + UNIT_FOR_VOLUME + "'," +  
							"WALLET_SIZE_MODEL_VOLUME = '" + WALLET_SIZE_MODEL_VOLUME + "'," +
							"WALLET_SIZE_MODEL_INCOME = '" + WALLET_SIZE_MODEL_INCOME + "'," +
							"WALLET_SIZE_ADJUSTED_VOLUME = '" + WALLET_SIZE_ADJUSTED_VOLUME + "'," +
							"WALLET_SIZE_ADJUSTED_INCOME = '" + WALLET_SIZE_ADJUSTED_INCOME + "'," +
							"MANDIRI_CURRENT_VOLUME = '" + MANDIRI_CURRENT_VOLUME + "'," +
							"MANDIRI_CURRENT_INCOME = '" + MANDIRI_CURRENT_INCOME + "'," +
							"MANDIRI_CURRENT_WALLET_SHARE_PERCENT = '" + MANDIRI_CURRENT_WALLET_SHARE_PERCENT + "'," +
							"TARGET_VOLUME = '" + TARGET_VOLUME + "'," +
							"TARGET_INCOME = '" + TARGET_INCOME + "'," +
							"TARGET_WALLET_SHARE_PERCENT = '" + TARGET_WALLET_SHARE_PERCENT + "'," +
							"PRIORITY = '" + PRIORITY + "'," +
							"REMARKS_KEY_COMPETITORS = '" + REMARKS_KEY_COMPETITORS + "'," +
							"REMARKS_BEST_BANK_WALLET_SHARED = '" + REMARKS_BEST_BANK_WALLET_SHARED + "'," +
							"REMARKS_POTENTIAL_ISSUES = '" + REMARKS_POTENTIAL_ISSUES + "' " +
							"WHERE CU_CIF = '" + cu_cif + "'";
						conn3.ExecuteQuery();
					}*/

					#endregion
				}
			}
		}
	}
}
