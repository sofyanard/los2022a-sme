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

namespace SME.AccountPlanning.AccountPlanSetup
{
	/// <summary>
	/// Summary description for Main.
	/// </summary>
	public partial class Main : System.Web.UI.Page
	{
		protected Tools tools = new Tools();
		protected Connection conn = new Connection(ConfigurationSettings.AppSettings["conn"]);

	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			ViewMenu();
			ViewData();
			ViewDataSub();
			ViewDataChain();
			ViewDataTeam();
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
					t.NavigateUrl = conn.GetFieldValue(i, 3)+strtemp;
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
			conn.QueryString = "SELECT * FROM AP_ANCHOR_INFO WHERE CIF# ='" + Request.QueryString["cif"] + "'";
			conn.ExecuteQuery();

			TXT_ANCHOR_CIF.Text					= conn.GetFieldValue("CIF#");
			TXT_ANCHOR_NAME.Text				= conn.GetFieldValue("CUSTOMER_GROUP");
			TXT_ANCHOR_ADDRESS.Text				= conn.GetFieldValue("CUST_ADDRESS");
			TXT_ANCHOR_CITY.Text				= conn.GetFieldValue("CUST_CITY");
			TXT_ANCHOR_DATE.Text				= tools.FormatDate(conn.GetFieldValue("CUST_DATE").ToString());
			TXT_ANCHOR_RM.Text					= conn.GetFieldValue("RM_NAME");
			TXT_ANCHOR_GROUP_NAME.Text			= conn.GetFieldValue("GROUP_NAME");
			TXT_ANCHOR_UNIT_NAME.Text			= conn.GetFieldValue("BUC");
			TXT_ANCHOR_RELATIONSHIP.Text		= conn.GetFieldValue("CUST_LENGTH");

		}

		private void ViewDataSub()
		{
			conn.QueryString = "SELECT * FROM VW_AP_ANCHOR_SUB_INFO WHERE CIF_GROUP ='"+ Request.QueryString["cif"] +"'";
			conn.ExecuteQuery();

			DataTable d = new DataTable();
			d			= conn.GetDataTable().Copy();
			DGR_ANCHOR_SUB.DataSource	= d;
			try 
			{
				DGR_ANCHOR_SUB.DataBind();
			} 
			catch 
			{
				DGR_ANCHOR_SUB.CurrentPageIndex = 0;
				DGR_ANCHOR_SUB.DataBind();
			}
		}

		private void ViewDataChain()
		{
			conn.QueryString = "SELECT * FROM VW_AP_ANCHOR_CHAIN_INFO WHERE CIF_GROUP ='"+ Request.QueryString["cif"] +"'";
			conn.ExecuteQuery();

			DataTable d = new DataTable();
			d			= conn.GetDataTable().Copy();
			DGR_ANCHOR_CHAIN.DataSource	= d;
			try 
			{
				DGR_ANCHOR_CHAIN.DataBind();
			} 
			catch 
			{
				DGR_ANCHOR_CHAIN.CurrentPageIndex = 0;
				DGR_ANCHOR_CHAIN.DataBind();
			}
		}

		private void ViewDataTeam()
		{
			conn.QueryString = "SELECT * FROM VW_AP_ANCHOR_CLIENT_TEAM WHERE CIF ='"+ Request.QueryString["cif"] +"'";
			conn.ExecuteQuery();

			DataTable d = new DataTable();
			d			= conn.GetDataTable().Copy();
			DGR_ANCHOR_CLIENT_TEAM.DataSource	= d;
			try 
			{
				DGR_ANCHOR_CLIENT_TEAM.DataBind();
			} 
			catch 
			{
				DGR_ANCHOR_CLIENT_TEAM.CurrentPageIndex = 0;
				DGR_ANCHOR_CLIENT_TEAM.DataBind();
			}
		}

		protected void BTN_BACK_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			Response.Redirect("../ActionPlan/CustomerList.aspx?mc=" + Request.QueryString["mc"]);
		}

	}
}
