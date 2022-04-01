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
using DMS.DBConnection;
using DMS.CuBESCore;
using DMS.BlackList;
using Microsoft.VisualBasic;
using System.IO;
using System.Diagnostics;

namespace SME.LMS.PortfolioWatchlistChecking
{
	/// <summary>
	/// Summary description for PorSearchCustomer2.
	/// </summary>
	public class PorSearchCustomer2 : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Button BTN_NEW;
		protected System.Web.UI.WebControls.DataGrid DatGrd;
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.Button btn_Find;
		protected System.Web.UI.WebControls.Button BTN_FIND;
		protected Tools tool = new Tools();
		protected System.Web.UI.WebControls.TextBox TXT_NOTA;
		protected System.Web.UI.WebControls.TextBox TXT_LMS;
		protected Connection conn;
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			conn = (Connection) Session["Connection"];
			if (!Logic.AllowAccess(Session["GroupID"].ToString(), Request.QueryString["mc"], conn))
				Response.Redirect("/SME/Restricted.aspx");
			

			if (!IsPostBack)
			{	
				/*conn.QueryString = "select * from VW_PORTFOLIO_WC_USER_HISTORY where por_trackby is null or por_trackby='P1'";	
				conn.ExecuteQuery();
				if (conn.GetRowCount() > 0)
				{
					conn.QueryString = "(select * from VW_PORTFOLIO_WC_USER_HISTORY where por_trackby is null)"
						+ "union (select * from VW_PORTFOLIO_WC_USER_HISTORY where por_tracknextby='" + Session["UserID"].ToString() +"')";
					conn.ExecuteQuery();
				}
				else
				{
					conn.QueryString = "select * from VW_PORTFOLIO_WC_USER_HISTORY where por_tracknextby='" + Session["UserID"].ToString() +"' ";
					conn.ExecuteQuery();
				}*/
				//conn.QueryString ="(select * from VW_PORTFOLIO_WC_USER_HISTORY where por_trackby is null and por_tracknextby='" + Session["UserID"].ToString() +"')"
				//		+ "union (select * from VW_PORTFOLIO_WC_USER_HISTORY where trackcode='P1' and por_tracknextby='" + Session["UserID"].ToString() +"')";
				
				conn.QueryString ="select * from VW_PORTFOLIO_WC_USER_HISTORY where trackcode='P1' and analyst_userid='" + Session["UserID"].ToString() +"'";					
				conn.ExecuteQuery();
				FillGrid();				
			}
			
		}

		private void FillGrid()
		{
			DataTable dt = new DataTable();
			dt = conn.GetDataTable().Copy();
			DatGrd.DataSource = dt;
			try 
			{
				DatGrd.DataBind();
			} 
			catch 
			{
				DatGrd.CurrentPageIndex = 0;
				DatGrd.DataBind();
			}
			for (int i = 0; i < DatGrd.Items.Count; i++)
			{
				DatGrd.Items[i].Cells[3].Text = tool.FormatDate(DatGrd.Items[i].Cells[3].Text, true);
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
			this.BTN_NEW.Click += new System.EventHandler(this.BTN_NEW_Click);
			this.btn_Find.Click += new System.EventHandler(this.btn_Find_Click);
			this.DatGrd.ItemCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.DatGrd_ItemCommand);
			this.DatGrd.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.DatGrd_PageIndexChanged);
			this.DatGrd.SelectedIndexChanged += new System.EventHandler(this.DatGrd_SelectedIndexChanged);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void btn_Find_Click(object sender, System.EventArgs e)
		{
			DatGrd.CurrentPageIndex = 0;
			SearchData();
		}

		private void SearchData()
		{
			string query=""; 
			
			if(TXT_NOTA.Text!="")
			{
				query += "and no_nota LIKE '%" + TXT_NOTA.Text + "%' ";
			}
			if(TXT_LMS.Text!="")
			{
				query += "and porlms_regno='" + TXT_LMS.Text + "' ";
			}				

			if(query!="")
			{
				//conn.QueryString="select * from PORTFOLIO_WC where analyst_userid='" + Session["UserID"].ToString() + "' " + query;
				conn.QueryString ="select * from VW_PORTFOLIO_WC_USER_HISTORY where trackcode='P1' and analyst_userid='" + Session["UserID"].ToString() +"' " + query;					
				conn.ExecuteQuery();
				FillGrid();
			}
			else
			{
				//conn.QueryString="select * from PORTFOLIO_WC where analyst_userid='" + Session["UserID"].ToString() + "' ";
				conn.QueryString ="select * from VW_PORTFOLIO_WC_USER_HISTORY where trackcode='P1' and analyst_userid='" + Session["UserID"].ToString() +"'";					
				conn.ExecuteQuery();
				FillGrid();
			}
		}

		private void DatGrd_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			
		}

		private void DatGrd_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			DatGrd.CurrentPageIndex = e.NewPageIndex;
			SearchData();
		}

		private void DatGrd_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			switch (((LinkButton)e.CommandSource).CommandName)
			{
				case "View":	
					conn.QueryString = "select * from VW_PORTFOLIO_WC_APPTRACK_HISTORY where no_lms='" + e.Item.Cells[2].Text + "'";
					conn.ExecuteQuery();
					
					if(conn.GetFieldValue("trackcode")=="P2")
					{
						Response.Redirect("GenInfoWatchlist2.aspx?sta=exist&porlmsregno=" + e.Item.Cells[2].Text + "&tc=" + Request.QueryString["tc"] + "&mc=" + Request.QueryString["mc"] + "&flag=1");
					}
					if(conn.GetFieldValue("trackcode")=="P3")
					{
						Response.Redirect("GenInfoWatchlist3.aspx?sta=exist&porlmsregno=" + e.Item.Cells[2].Text + "&tc=" + Request.QueryString["tc"] + "&mc=" + Request.QueryString["mc"] + "&flag=1");
					}
					if(conn.GetFieldValue("trackcode")=="P4")
					{
						Response.Redirect("GenInfoWatchlist4.aspx?sta=exist&porlmsregno=" + e.Item.Cells[2].Text + "&tc=" + Request.QueryString["tc"] + "&mc=" + Request.QueryString["mc"] + "&flag=1");
					}	
					if(conn.GetFieldValue("trackcode")=="P3.1")
					{
						Response.Redirect("GenInfoWatchlist3-1.aspx?sta=exist&porlmsregno=" + e.Item.Cells[2].Text + "&tc=" + Request.QueryString["tc"] + "&mc=" + Request.QueryString["mc"] + "&flag=1");
					}					
					if(conn.GetFieldValue("trackcode")=="P4")
					{
						Response.Redirect("GenInfoWatchlist4.aspx?sta=exist&porlmsregno=" + e.Item.Cells[2].Text + "&tc=" + Request.QueryString["tc"] + "&mc=" + Request.QueryString["mc"] + "&flag=1");
					}
					else
					{
						Response.Redirect("GenInfoWatchlist1.aspx?sta=exist&porlmsregno=" + e.Item.Cells[2].Text + "&tc=" + Request.QueryString["tc"] + "&mc=" + Request.QueryString["mc"] + "&flag=1");
					}
								
					break;
			}
		}

		private void BTN_NEW_Click(object sender, System.EventArgs e)
		{	
			conn.QueryString = "exec LMS_GENERATE_ID ";
			conn.ExecuteQuery();
			Response.Redirect("GenInfoWatchlist1.aspx?porlmsregno=" + conn.GetFieldValue(0,0) + "&tc=" + Request.QueryString["tc"] + "&mc=" + Request.QueryString["mc"] + "&exist=0" + "&flag=0");
			//Response.Redirect("GenInfoWatchlist1.aspx?tc=" + Request.QueryString["tc"] + "&mc=" + Request.QueryString["mc"] + "&exist=0");
		}
	}
}
