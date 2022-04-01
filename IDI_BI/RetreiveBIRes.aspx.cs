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
	/// Summary description for RetreiveBIRes.
	/// </summary>
	public partial class RetreiveBIRes : System.Web.UI.Page
	{
		protected Tools tool = new Tools();
		protected Connection conn;
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			conn = (Connection) Session["Connection"];	

			if (!IsPostBack)
			{			
				conn.QueryString = "select * from VW_IDI_BI_REQUEST_TRACK_LIST where idi_officer='"+Session["UserID"].ToString()+"' and idi_trackcode='BI.4' and idi_choose='1' order by idi_reqdate desc";
				conn.ExecuteQuery();
				FillGrid();

				for (int i = 0; i < DGR_PENDING.Items.Count; i++)
				{			
					conn.QueryString = "select * from VW_IDI_BI_REQUEST_TRACK_LIST where idi_req#='" + DGR_PENDING.Items[i].Cells[2].Text.Trim() + "' and idi_surat_seq#='" + DGR_PENDING.Items[i].Cells[10].Text.Trim() + "' order by idi_reqdate";
					conn.ExecuteQuery();
					string idi_status;
					idi_status = conn.GetFieldValue("idi_status");

					Button retrieve = (Button)DGR_PENDING.Items[i].Cells[9].FindControl("BTN_RETV");
					if (idi_status == "0")
					{
						retrieve.Enabled = false;
					}
					if (idi_status == "1")
					{
						retrieve.Enabled = true;
					}
					
				}

				//string idi_status;
				//idi_status = conn.GetFieldValue("idi_status");

				/*for (int i = 0; i < DGR_PENDING.Items.Count; i++)
				{					
					int kredit, agunan, lc, garansi;
					Button btnretrieve = (Button)DGR_PENDING.Items[i].Cells[8].FindControl("BTN_RETV");	
					conn.QueryString = "SELECT * FROM [10.210.1.90].[LOSSID_SME].dbo.APPSID_KREDIT where ap_regno='" + DGR_PENDING.Items[i].Cells[3].Text.Trim() + "' and dpt_nosurat='" + DGR_PENDING.Items[i].Cells[0].Text.Trim() + "' ";
					conn.ExecuteQuery();
					kredit = conn.GetRowCount();
					
					conn.QueryString = "SELECT * FROM [10.210.1.90].[LOSSID_SME].dbo.APPSID_AGUNAN where ap_regno='" + DGR_PENDING.Items[i].Cells[3].Text.Trim() + "' and dpt_nosurat='" + DGR_PENDING.Items[i].Cells[0].Text.Trim() + "' ";
					conn.ExecuteQuery();
					agunan = conn.GetRowCount();

					conn.QueryString = "SELECT * FROM [10.210.1.90].[LOSSID_SME].dbo.APPSID_IRREVOCABLELC where ap_regno='" + DGR_PENDING.Items[i].Cells[3].Text.Trim() + "' and dpt_nosurat='" + DGR_PENDING.Items[i].Cells[0].Text.Trim() + "' ";
					conn.ExecuteQuery();
					lc = conn.GetRowCount();

					conn.QueryString = "SELECT * FROM [10.210.1.90].[LOSSID_SME].dbo.APPSID_GARANSIBANK where ap_regno='" + DGR_PENDING.Items[i].Cells[3].Text.Trim() + "' and dpt_nosurat='" + DGR_PENDING.Items[i].Cells[0].Text.Trim() + "' ";
					conn.ExecuteQuery();
					garansi = conn.GetRowCount();

					if (kredit > 0 || agunan>0 || lc>0 || garansi>0)
					{
						btnretrieve.Visible = true;						
					}
					else
					{
						btnretrieve.Visible = false;						
					}
					
				}*/	
			}
			
		}

		private void ButtonView()
		{
			for (int i = 0; i < DGR_PENDING.Items.Count; i++)
			{			
				conn.QueryString = "select * from VW_IDI_BI_REQUEST_TRACK_LIST where idi_req#='" + DGR_PENDING.Items[i].Cells[2].Text.Trim() + "' and idi_surat_seq#='" + DGR_PENDING.Items[i].Cells[10].Text.Trim() + "' order by idi_reqdate";
				conn.ExecuteQuery();
				string idi_status;
				idi_status = conn.GetFieldValue("idi_status");

				Button retrieve = (Button)DGR_PENDING.Items[i].Cells[9].FindControl("BTN_RETV");
				if (idi_status == "0")
				{
					retrieve.Enabled = false;
				}
				if (idi_status == "1")
				{
					retrieve.Enabled = true;
				}
					
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

		private void DGR_PENDING_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			//Button BtnRetrieve;
			//BtnRetrieve = (Button)e.Item.Cells[8].FindControl("BTN_RETV");
			

			try
			{
				switch(((Button)e.CommandSource).CommandName)
				{
					case "retrieve":
						Response.Redirect("FullBIRes.aspx?sta=exist&regnum=" + e.Item.Cells[2].Text + "&tc=" + Request.QueryString["tc"] + "&mc=" + Request.QueryString["mc"] + "&no_surat=" + e.Item.Cells[0].Text + "/" + e.Item.Cells[10].Text + "&no_din=" + e.Item.Cells[7].Text);						
						break;
					
					default:
						break;
				}
			}
			catch{}
		}

		private void SearchData()
		{
			string query=""; 
			
			if(TXT_CUST_NAME.Text!="")
			{
				query += "and IDI_CUSTNAME LIKE '%" + TXT_CUST_NAME.Text + "%' ";
			}
			if(TXT_IDI_REQ.Text!="")
			{
				query += "and IDI_REQ#='" + TXT_IDI_REQ.Text + "' ";
			}			
			if(TXT_IDI_SURAT.Text!="")
			{
				query += "and IDI_SURAT#='" + TXT_IDI_SURAT.Text + "' ";
			}			

			if(query!="")
			{				
				conn.QueryString="select * from VW_IDI_BI_REQUEST_TRACK_LIST where idi_officer='"+Session["UserID"].ToString()+"' and idi_trackcode='BI.4' and idi_choose='1'" + query + "order by idi_reqdate desc";
				conn.ExecuteQuery();				
				FillGrid();	

				for (int i = 0; i < DGR_PENDING.Items.Count; i++)
				{			
					conn.QueryString = "select * from VW_IDI_BI_REQUEST_TRACK_LIST where idi_req#='" + DGR_PENDING.Items[i].Cells[2].Text.Trim() + "' and idi_surat_seq#='" + DGR_PENDING.Items[i].Cells[10].Text.Trim() + "' order by idi_reqdate";
					conn.ExecuteQuery();
					string idi_status;
					idi_status = conn.GetFieldValue("idi_status");

					Button retrieve = (Button)DGR_PENDING.Items[i].Cells[9].FindControl("BTN_RETV");
					if (idi_status == "0")
					{
						retrieve.Enabled = false;
					}
					if (idi_status == "1")
					{
						retrieve.Enabled = true;
					}					
				}
			}
			else
			{				
				conn.QueryString="select * from VW_IDI_BI_REQUEST_TRACK_LIST where idi_officer='"+Session["UserID"].ToString()+"' and idi_trackcode='BI.4' and idi_choose='1' order by idi_reqdate desc";
				conn.ExecuteQuery();				
				FillGrid();
				for (int i = 0; i < DGR_PENDING.Items.Count; i++)
				{			
					conn.QueryString = "select * from VW_IDI_BI_REQUEST_TRACK_LIST where idi_req#='" + DGR_PENDING.Items[i].Cells[2].Text.Trim() + "' and idi_surat_seq#='" + DGR_PENDING.Items[i].Cells[10].Text.Trim() + "' order by idi_reqdate";
					conn.ExecuteQuery();
					string idi_status;
					idi_status = conn.GetFieldValue("idi_status");

					Button retrieve = (Button)DGR_PENDING.Items[i].Cells[9].FindControl("BTN_RETV");
					if (idi_status == "0")
					{
						retrieve.Enabled = false;
					}
					if (idi_status == "1")
					{
						retrieve.Enabled = true;
					}					
				}
			}
		}

		private void DGR_PENDING_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			DGR_PENDING.CurrentPageIndex = e.NewPageIndex;
			SearchData();
		}

		protected void BTN_FIND_Click(object sender, System.EventArgs e)
		{
			DGR_PENDING.CurrentPageIndex = 0;
			SearchData();
		}
	}
}
