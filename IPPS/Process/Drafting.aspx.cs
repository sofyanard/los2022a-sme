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
using Microsoft.VisualBasic;
using DMS.CuBESCore;
using DMS.DBConnection;

namespace SME.IPPS.Process
{
	/// <summary>
	/// Summary description for Drafting.
	/// </summary>
	public partial class Drafting : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.DataGrid Datagrid1;
		protected System.Web.UI.WebControls.TextBox txt_Impl_Target_Date;
		protected System.Web.UI.WebControls.Panel Panel1;
		protected System.Web.UI.WebControls.DropDownList ddl_jmlh_bab;
		protected System.Web.UI.WebControls.Button btn_insert_jmlh_bab;
		protected System.Web.UI.WebControls.Panel pnl_outline;
		protected System.Web.UI.WebControls.DataGrid DGR_bab_contain;
		protected System.Web.UI.WebControls.Panel pnl_contain;
		protected System.Web.UI.WebControls.DataGrid DGR_bab_contain2;
		protected System.Web.UI.WebControls.Panel pnl_contain2;
		protected System.Web.UI.WebControls.TextBox TXT_DRAFT_NAME;
		protected System.Web.UI.WebControls.TextBox TXT_DRAFT_EDITION;
		protected System.Web.UI.WebControls.TextBox TXT_DRAFT_REVISION;
		protected System.Web.UI.WebControls.TextBox TXT_OLD_DATE_DAY;
		protected System.Web.UI.WebControls.DropDownList DDL_OLD_DATE_MONTH;
		protected System.Web.UI.WebControls.TextBox TXT_OLD_DATE_YEAR;
		protected System.Web.UI.WebControls.TextBox TXT_NEW_DATE_DAY;
		protected System.Web.UI.WebControls.DropDownList DDL_NEW_DATE_MONTH;
		protected System.Web.UI.WebControls.TextBox TXT_NEW_DATE_YEAR;
		protected System.Web.UI.WebControls.Button BTN_SAVE_DRAFT;
		protected System.Web.UI.WebControls.Button BTN_CLEAR_DRAFT;
		protected System.Web.UI.WebControls.TextBox TXT_OLD_OUTLINE;
		protected System.Web.UI.WebControls.TextBox TXT_NEW_OUTLINE;
		protected System.Web.UI.WebControls.Button BTN_SAVE_OUTLINE;
		protected System.Web.UI.WebControls.Button BTN_CLEAR_OUTLINE;
		protected System.Web.UI.WebControls.Label LBL_REQ_SEQ;

		protected Tools tool = new Tools();
		protected Connection conn;
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			conn = (Connection) Session["Connection"];
			
			if (!Logic.AllowAccess(Session["GroupID"].ToString(), Request.QueryString["mc"], conn))
				Response.Redirect("../Restricted.aspx");

			ViewMenu();

			if (!IsPostBack)
			{
				ViewRequestList();
			}
		}

		private void ViewMenu()
		{
			try 
			{
				conn.QueryString = "select * from SCREENMENU where menucode = '" + Request.QueryString["mc"] + "'";
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
							strtemp = "regno=" + Request.QueryString["regno"] +  "&tc=" + Request.QueryString["tc"] ;
						else	
							strtemp = "regno=" + Request.QueryString["regno"] +  "&mc=" + Request.QueryString["mc"]+"&tc="+Request.QueryString["tc"];
						//t.ForeColor = Color.MidnightBlue; 
					}
					else 
					{
						strtemp = "";
						t.ForeColor = Color.Red; 
					}
					t.NavigateUrl = conn.GetFieldValue(i,3)+strtemp;
					Menu.Controls.Add(t);
					Menu.Controls.Add(new LiteralControl("&nbsp;&nbsp;&nbsp;"));
				}
			} 
			catch (Exception ex) 
			{
				string temp = ex.ToString();
			}
		}

		private void ViewRequestList()
		{
			conn.QueryString = "SELECT * FROM VW_IPPS_DRAFTING_VIEWREQUESTLIST WHERE IPPS_REGNO = '" + Request.QueryString["regno"] + "'";
			conn.ExecuteQuery();

			DataTable dt = new DataTable();
			dt = conn.GetDataTable().Copy();

			int nreq = dt.Rows.Count;

			for (int i = 0; i < nreq; i++)
			{
				HyperLink hreq	 = new HyperLink();

				hreq.Text			= dt.Rows[i]["DISP"].ToString();
				hreq.CssClass		= "TDBGColor1";
				hreq.Font.Bold		= true;
				hreq.NavigateUrl	= dt.Rows[i]["LINK"].ToString();
				hreq.Target			= "IFR_REQ";
				
				TBL_REQ.Rows.Add(new TableRow());
				TBL_REQ.Rows[i].Cells.Add(new TableCell());
				TBL_REQ.Rows[i].Cells[0].Controls.Add(hreq);
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

		private void BTN_SAVE_DRAFT_Click(object sender, System.EventArgs e)
		{
			
		}
	}
}
