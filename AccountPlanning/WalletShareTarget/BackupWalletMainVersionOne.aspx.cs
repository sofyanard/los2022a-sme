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
	/// Summary description for WalletMain.
	/// </summary>
	public partial class BackupWalletMainVersionOne : System.Web.UI.Page
	{
		protected Tools tools = new Tools();
		protected Connection conn = new Connection(ConfigurationSettings.AppSettings["conn"]);
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			if(!IsPostBack)
			{
				
			}

			ViewMenu();
			ViewData();
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
			this.DGR_WALLETSIZE.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.DGR_WALLETSIZE_PageIndexChanged);

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

		private void ViewData()
		{
			/*conn.QueryString = "SELECT DISTINCT CIF#,CUSTOMER_GROUP,CUST_ADDRESS,CUST_CITY,CUST_DATE,RM_NAME,GROUP_NAME,BRANCH_NAME,CUST_LENGTH FROM VW_AP_CUSTOMER_LIST" +
				" WHERE CIF#='" + Request.QueryString["cif"] + "' AND BUSSUNITID='" + Request.QueryString["bs"] + "' AND BUC='" + Request.QueryString["bc"] +
				"' AND (RM_ID='" + Request.QueryString["rd"] + "' OR CST_ID='" + Request.QueryString["cd"] + "')";*/
			conn.QueryString = "SELECT * FROM VW_AP_CUSTOMER_LIST WHERE CIF#='" + Request.QueryString["cif"] + "' ORDER BY CONVERT(INT, CIF#)";
			conn.ExecuteQuery();

			TXT_CIF.Text = conn.GetFieldValue("CIF#").ToString();
			TXT_CUST_NAME.Text = conn.GetFieldValue("CUSTOMER_GROUP").ToString();
			TXT_ADDRESS.Text = conn.GetFieldValue("CUST_ADDRESS").ToString();
			TXT_KOTA.Text = conn.GetFieldValue("CUST_CITY").ToString();
			TXT_CUST_DATE.Text = tools.FormatDate(conn.GetFieldValue("CUST_DATE").ToString());
			TXT_RM.Text = conn.GetFieldValue("RM_NAME").ToString();
			TXT_GROUP_NAME.Text = conn.GetFieldValue("GROUP_NAME").ToString();
			TXT_UNIT_NAME.Text = conn.GetFieldValue("BRANCH_NAME").ToString();
			TXT_RELATIONSHIP.Text = conn.GetFieldValue("CUST_LENGTH").ToString();

			FillDataGrid();
		}

		private void FillDataGrid()
		{
			conn.QueryString = "EXEC AP_RECAP_WALLET_SIZE '" + Request.QueryString["cif"] + "','ANCHORONLY'";
			BindData(DGR_WALLETSIZE.ID.ToString(), conn.QueryString);
		}

		private void BindData(string dataGridName, string strconn)
		{
			if(strconn != "")
			{
				conn.QueryString = strconn;
				conn.ExecuteQuery();

				System.Data.DataTable dt = new System.Data.DataTable();
				dt = conn.GetDataTable().Copy();

				System.Web.UI.WebControls.DataGrid dg = (System.Web.UI.WebControls.DataGrid)Page.FindControl(dataGridName);
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
		}

		protected void BTN_BACK_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			Response.Redirect("../CustomerList.aspx?mc=" + Request.QueryString["mc"]);
		}

		private void DGR_WALLETSIZE_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			if(DGR_WALLETSIZE.CurrentPageIndex >= 0 && DGR_WALLETSIZE.CurrentPageIndex < DGR_WALLETSIZE.PageCount)
			{
				DGR_WALLETSIZE.CurrentPageIndex = e.NewPageIndex;
				//conn2.QueryString = "EXEC AP_RECAP_WALLET_SIZE '" + CIF + "','ANCHORONLY'";
				conn.QueryString = "EXEC AP_RECAP_WALLET_SIZE '" + Request.QueryString["cif"] + "','ANCHORONLY'";
				BindData(DGR_WALLETSIZE.ID.ToString(), conn.QueryString);
			}
		}
	}
}
