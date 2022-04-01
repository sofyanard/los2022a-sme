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

namespace SME.HDRS
{
	/// <summary>
	/// Summary description for InquiryByStatus.
	/// </summary>
	public partial class InquiryByStatus : System.Web.UI.Page
	{
		protected Tools tool = new Tools();
		protected Connection conn;
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here		
			PegeLoad();
		}

		private void PegeLoad()
		{
			conn = (Connection) Session["Connection"];
			if (!Logic.AllowAccess(Session["GroupID"].ToString(), Request.QueryString["mc"], conn))
				Response.Redirect("/SME/Restricted.aspx");

			if (!IsPostBack)
			{		
				/*conn.QueryString = "SELECT * FROM VW_HELPDESK_INQUIRY_CUR";
				conn.ExecuteQuery();
				FillGridCur();
				DGR_CUR.Visible = true;
				DGR_LIST.Visible = false;*/				
			}
		
			/*conn.QueryString = "SELECT * FROM VW_HELPDESK_INQUIRY_CUR order by h_received_date desc";
			conn.ExecuteQuery();
			FillGridCur();
			DGR_CUR.Visible = false;
			DGR_LIST.Visible = false;*/

			DGR_CUR.Visible = false;
			DGR_LIST.Visible = false;
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
			this.DGR_CUR.ItemCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.DGR_CUR_ItemCommand);
			this.DGR_CUR.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.DGR_CUR_PageIndexChanged);
			this.DGR_LIST.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.DGR_LIST_PageIndexChanged);

		}
		#endregion

		protected void btn_Find_Click(object sender, System.EventArgs e)
		{
			DGR_CUR.CurrentPageIndex = 0;
			SearchData();
			/*DGR_CUR.Visible = true;
			DGR_LIST.Visible = false;*/
		}

		protected void btn_Clear_Click(object sender, System.EventArgs e)
		{
			TXT_HRS.Text = "";
			TXT_AP.Text = "";
			TXT_CUST.Text = "";
		}

		private void FillGridCur()
		{			
			DataTable dt = new DataTable();
			dt = conn.GetDataTable().Copy();
			DGR_CUR.DataSource = dt;
			try 
			{
				DGR_CUR.DataBind();
			} 
			catch 
			{
				DGR_CUR.CurrentPageIndex = 0;
				DGR_CUR.DataBind();
			}

			for (int i = 0; i < DGR_CUR.Items.Count; i++)
			{
				DGR_CUR.Items[i].Cells[1].Text = tool.FormatDate(DGR_CUR.Items[i].Cells[1].Text, true);				
			}
		}

		private void FillGridList()
		{
			DataTable dt = new DataTable();
			dt = conn.GetDataTable().Copy();
			DGR_LIST.DataSource = dt;
			try 
			{
				DGR_LIST.DataBind();
			} 
			catch 
			{
				DGR_LIST.CurrentPageIndex = 0;
				DGR_LIST.DataBind();
			}
			for (int i = 0; i < DGR_LIST.Items.Count; i++)
			{
				DGR_LIST.Items[i].Cells[1].Text = tool.FormatDate(DGR_LIST.Items[i].Cells[1].Text, true);
				//DGR_LIST.Items[i].Cells[3].Text = tool.FormatDate(DGR_LIST.Items[i].Cells[3].Text, true);
			}
		}

		private void DGR_CUR_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			DGR_CUR.CurrentPageIndex = e.NewPageIndex;
			SearchData();
		}

		private void DGR_CUR_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			switch (((LinkButton)e.CommandSource).CommandName)
			{
				case "View":	
					DGR_CUR.Visible=false;
					DGR_LIST.Visible=true;

					conn.QueryString = "SELECT * FROM VW_HELPDESK_INQUIRY_LIST where HTH_HRS#='" + e.Item.Cells[0].Text + "' order by hth_trackdate desc";
					conn.ExecuteQuery();					
					FillGridList();
					break;				
			}
		}

		private void DGR_LIST_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			DGR_LIST.CurrentPageIndex = e.NewPageIndex;
		}

		private void SearchData()
		{
			string query1=""; 
			
			if(TXT_HRS.Text!="")
			{
				query1 += "and HTH_HRS# like '%" + TXT_HRS.Text + "%' ";	
				conn.QueryString = "SELECT * FROM VW_HELPDESK_INQUIRY_LIST where 1=1 "  + query1 + "order by hth_trackdate desc";
				conn.ExecuteQuery();					
				FillGridList();
				DGR_LIST.Visible = true;
			}

			else
			{
				if(TXT_AP.Text!="")
				{
					query1 += "and H_APP# like '%" + TXT_AP.Text + "%' ";				
				}
				if(TXT_CUST.Text!="")
				{
					query1 += "and H_CUSTOMER like '%" + TXT_CUST.Text + "%' ";				
				}

				conn.QueryString = "SELECT * FROM VW_HELPDESK_INQUIRY_CUR where 1=1 " + query1 + "order by h_received_date desc";
				conn.ExecuteQuery();
				FillGridCur();
				DGR_CUR.Visible = true;				
			}
			
		}

		protected void BTN_BACK_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			PegeLoad();
		}
	}
}
