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
using Microsoft.VisualBasic;


namespace SME.IDI_BI
{
	/// <summary>
	/// Summary description for ListPendingAsg.
	/// </summary>
	public partial class ListPendingAsg : System.Web.UI.Page
	{
		protected Connection conn;
		protected Tools tool = new Tools();
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			conn = (Connection) Session["Connection"];

			if (!IsPostBack)
			{				
				conn.QueryString = "select * from VW_IDI_PENDING_LIST order by idi_reqdate desc";
				conn.ExecuteQuery();
				FillGrid();
			}
		}

		private void FillGrid()
		{
			DataTable dt = new DataTable();
			dt = conn.GetDataTable().Copy();
			DGR_PENDING.DataSource = dt;
			try 
			{
				DGR_PENDING.DataBind();
			} 
			catch 
			{
				DGR_PENDING.CurrentPageIndex = 0;
				DGR_PENDING.DataBind();
			}
		}

		private void SearchData()
		{
			string query1=""; 
			
			if(TXT_CUST_NAME.Text!="")
			{
				query1 += "and IDI_CUSTNAME LIKE '%" + TXT_CUST_NAME.Text + "%' ";				
			}
			if(TXT_IDI_REQ.Text!="")
			{
				query1 += "and IDI_REQ#='" + TXT_IDI_REQ.Text + "' ";				
			}
			if(TXT_NPWP.Text!="")
			{
				query1 += "and IDI_NPWP# LIKE '%" + TXT_NPWP.Text + "%' ";				
			}
			if(TXT_KTP.Text!="")
			{
				query1 += "and IDI_KTP# LIKE '%" + TXT_KTP.Text + "%' ";				
			}
			if(TXT_DIN.Text!="")
			{
				query1 += "and IDI_DIN# LIKE '%" + TXT_DIN.Text + "%' ";				
			}

			conn.QueryString = "select * from VW_IDI_PENDING_LIST where 1=1 " + query1 + "order by idi_reqdate desc";
			conn.ExecuteQuery();
			FillGrid();
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
			this.DGR_PENDING.ItemCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.DGR_PENDING_ItemCommand);
			this.DGR_PENDING.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.DGR_PENDING_PageIndexChanged);

		}
		#endregion

		protected void btn_Find_Click(object sender, System.EventArgs e)
		{
			DGR_PENDING.CurrentPageIndex = 0;
			SearchData();
		}

		private void DGR_PENDING_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			DGR_PENDING.CurrentPageIndex = e.NewPageIndex;
			SearchData();
		}

		private void DGR_PENDING_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			switch (((LinkButton)e.CommandSource).CommandName)
			{
				case "View":					
					Response.Redirect("Assignment.aspx?sta=exist&regnum=" + e.Item.Cells[1].Text + "&tc=" + Request.QueryString["tc"] + "&mc=" + Request.QueryString["mc"]);
									
					break;
			}
		}
	}
}
