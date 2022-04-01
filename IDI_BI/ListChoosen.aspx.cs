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
	/// Summary description for ListChoosen.
	/// </summary>
	public partial class ListChoosen : System.Web.UI.Page
	{		
		protected Connection conn = new Connection();
		protected Tools tool = new Tools();
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			conn = (Connection) Session["Connection"];

			//conn.QueryString = "select * from VW_IDI_BI_REQUEST_TRACK_LIST where idi_req#='" + Request.QueryString["regnum"] + "' and idi_trackcode='BI.4' order by idi_reqdate";
			//conn.ExecuteQuery();
			//FillGrid();

			if (!IsPostBack)
			{
				conn.QueryString = "select * from VW_IDI_BI_REQUEST_TRACK_LIST where idi_req#='" + Request.QueryString["regnum"] + "' and idi_trackcode='BI.4' order by idi_reqdate";
				conn.ExecuteQuery();
				FillGrid();					
				
				for (int i = 0; i < DGR_RESULT.Items.Count; i++)
				{			
					conn.QueryString = "select * from VW_IDI_BI_REQUEST_TRACK_LIST where idi_req#='" + DGR_RESULT.Items[i].Cells[6].Text.Trim() + "' and idi_surat_seq#='" + DGR_RESULT.Items[i].Cells[7].Text.Trim() + "' order by idi_reqdate";
					conn.ExecuteQuery();

					string idi_choose, idi_status;
					idi_choose = conn.GetFieldValue("idi_choose");
					idi_status = conn.GetFieldValue("idi_status");

					CheckBox checkbox = (CheckBox)DGR_RESULT.Items[i].Cells[4].FindControl("check");
					if (idi_choose == "0")
					{
						checkbox.Checked = false;
					}
					else
					{
						checkbox.Checked = true;
					}	
				
					Button btnblock = (Button)DGR_RESULT.Items[i].Cells[5].FindControl("BTN_BLOCK");
					Button btnunblock = (Button)DGR_RESULT.Items[i].Cells[5].FindControl("BTN_UNBLOCK");
					
					if (idi_status == "0")
					{
						btnblock.Visible = true;
						btnunblock.Visible = false;	
					}
					if (idi_status == "1")
					{
						btnblock.Visible = false;
						btnunblock.Visible = true;	
					}
				}	
				
			}
		}

		private void FillGrid()
		{
			DataTable dt = new DataTable();
			dt = conn.GetDataTable().Copy();
			DGR_RESULT.DataSource = dt;
			try 
			{
				DGR_RESULT.DataBind();
			} 
			catch 
			{
				DGR_RESULT.CurrentPageIndex = 0;
				DGR_RESULT.DataBind();
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
			this.DGR_RESULT.ItemCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.DGR_RESULT_ItemCommand);
			this.DGR_RESULT.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.DGR_RESULT_PageIndexChanged);

		}
		#endregion

		private void DGR_RESULT_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			Button BtnBlock, BtnUnblock;

			BtnBlock = (Button)e.Item.Cells[5].FindControl("BTN_BLOCK");
			BtnUnblock = (Button)e.Item.Cells[5].FindControl("BTN_UNBLOCK");

			try
			{
				switch(((Button)e.CommandSource).CommandName)
				{
					case "unblock":
						conn.QueryString = "update bi_request set idi_status='0' where idi_req#='" + e.Item.Cells[6].Text + "' " + 
							"and idi_surat_seq#='" + e.Item.Cells[7].Text + "' ";
						conn.ExecuteQuery();

						conn.QueryString = "EXEC IDI_BI_BLOCK_UPDATE '" + e.Item.Cells[6].Text 
							+ "', '" + e.Item.Cells[7].Text	+ "', '0' ";
						conn.ExecuteNonQuery();

						BtnBlock.Visible = true;
						BtnUnblock.Visible = false;
						break;
					case "block":
						conn.QueryString = "update bi_request set idi_status='1' where idi_req#='" + e.Item.Cells[6].Text + "' "+
							"and idi_surat_seq#='" + e.Item.Cells[7].Text + "' ";
						conn.ExecuteQuery();

						conn.QueryString = "EXEC IDI_BI_BLOCK_UPDATE '" + e.Item.Cells[6].Text 
							+ "', '" + e.Item.Cells[7].Text	+ "', '1' ";
						conn.ExecuteNonQuery();

						BtnBlock.Visible = false;
						BtnUnblock.Visible = true;
						break;
					default:
						break;
				}
			}
			catch{}
		}

		private void DGR_RESULT_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			DGR_RESULT.CurrentPageIndex = 0;
			conn.QueryString = "select * from VW_IDI_BI_REQUEST_TRACK_LIST where idi_req#='" + Request.QueryString["regnum"] + "' and idi_trackcode='BI.4' order by idi_reqdate";
			conn.ExecuteQuery();
			FillGrid();	
		}
	}
}
