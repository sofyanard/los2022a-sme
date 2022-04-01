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
	public partial class WalletSetupTarget : System.Web.UI.Page
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
				FillAllDDL();
			}
		}

		private void FillAllDDL()
		{
			GlobalTools.fillRefList(DDL_GROUP_UNIT, "SELECT BUSSUNITID, BUSSUNITDESC FROM RFBUSINESSUNIT", conn);
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

		protected void BTN_Find_Click(object sender, System.EventArgs e)
		{
			BindData(DatagridWalletMain, "EXEC AP_GET_WALLET_SIZING '" + DDL_COMPANY.SelectedValue.ToString() + "'");
		}

		protected void DDL_GROUP_UNIT_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			GlobalTools.fillRefList(DDL_UNIT, "SELECT BRANCH_CODE, BRANCH_NAME FROM RFBRANCH WHERE BUSSUNITID = '" + DDL_GROUP_UNIT.SelectedValue.ToString() + "'", conn2);
		}

		protected void DDL_UNIT_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			/*GlobalTools.fillRefList(DDL_COMPANY, "SELECT CIF# as CIF_CUST, CUSTOMER_GROUP FROM AP_ANCHOR_INFO WHERE BUC = '" + DDL_GROUP_UNIT.SelectedValue.ToString() + "'" +
				" UNION SELECT CIF_CUST, CUSTOMER_NAME FROM AP_COMPANY_INFO WHERE BUC = '" + DDL_GROUP_UNIT.SelectedValue.ToString() + "'", conn);*/
			string asdasd = "SELECT CODE, CODE_DESCRIPTION FROM AP_RF_INDUSTRY_BCG WHERE AP_RF_INDUSTRY_BCG.CODE in (SELECT DISTINCT(A.INDUSTRY_NAME) as INDUSTRY_NAME FROM (SELECT INDUSTRY_NAME FROM AP_ANCHOR_INFO WHERE BUC = '" + DDL_GROUP_UNIT.SelectedValue.ToString() + "' UNION SELECT INDUSTRY_NAME FROM AP_COMPANY_INFO WHERE BUC = '" + DDL_GROUP_UNIT.SelectedValue.ToString() + "')A)";
			GlobalTools.fillRefList(DDL_INDUSTRY, "SELECT CODE, CODE_DESCRIPTION FROM AP_RF_INDUSTRY_BCG WHERE AP_RF_INDUSTRY_BCG.CODE in (SELECT DISTINCT(A.INDUSTRY_NAME) as INDUSTRY_NAME FROM (SELECT INDUSTRY_NAME FROM AP_ANCHOR_INFO WHERE BUC = '" + DDL_UNIT.SelectedValue.ToString() + "' UNION SELECT INDUSTRY_NAME FROM AP_COMPANY_INFO WHERE BUC = '" + DDL_UNIT.SelectedValue.ToString() + "')A)", conn2);
		}

		protected void DDL_INDUSTRY_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			string asdasd = "SELECT CIF# as CIF_CUST, CUSTOMER_GROUP FROM AP_ANCHOR_INFO WHERE BUC = '" + DDL_GROUP_UNIT.SelectedValue.ToString() + "' AND INDUSTRY_NAME = '" + DDL_INDUSTRY.SelectedValue + "'" +
				" UNION SELECT CIF_CUST, CUSTOMER_NAME FROM AP_COMPANY_INFO WHERE BUC = '" + DDL_UNIT.SelectedValue.ToString() + "' AND INDUSTRY_NAME = '" + DDL_INDUSTRY.SelectedValue + "'";
			/*GlobalTools.fillRefList(DDL_COMPANY, "SELECT CIF# as CIF_CUST, CUSTOMER_GROUP FROM AP_ANCHOR_INFO WHERE BUC = '" + DDL_UNIT.SelectedValue.ToString() + "' AND INDUSTRY_NAME = '" + DDL_INDUSTRY.SelectedValue + "'" +
				" UNION SELECT CIF_CUST, CUSTOMER_NAME FROM AP_COMPANY_INFO WHERE BUC = '" + DDL_UNIT.SelectedValue.ToString() + "' AND INDUSTRY_NAME = '" + DDL_INDUSTRY.SelectedValue + "'", conn2);*/
			GlobalTools.fillRefList(DDL_COMPANY, "SELECT CIF_CUST, CUSTOMER_NAME FROM AP_COMPANY_INFO WHERE BUC = '" + DDL_UNIT.SelectedValue.ToString() + "' AND INDUSTRY_NAME = '" + DDL_INDUSTRY.SelectedValue + "'", conn2);
		}

		protected void Button1_Click(object sender, System.EventArgs e)
		{
			Response.Write("<script language='javascript'>window.open('WalletSizePrint.aspx?mc=" + Request.QueryString["mc"] + "&cif=" + DDL_COMPANY.SelectedValue.ToString() + "','PrintWalletSize');</script>");
		}
	}
}
