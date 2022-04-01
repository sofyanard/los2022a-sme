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
	/// Summary description for ListReqPreData.
	/// </summary>
	public partial class ListReqPreData : System.Web.UI.Page
	{
		protected Connection conn = new Connection();
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			conn = (Connection) Session["Connection"];

			conn.QueryString = "select * from idi_request where idi_status='0' order by idi_reqdate desc";
			conn.ExecuteQuery();
			FillGrid();

			if (!IsPostBack)
			{	
				conn.QueryString = "select * from idi_request where idi_status='0' order by idi_reqdate desc";
				conn.ExecuteQuery();
				FillGrid();
				
				for (int i = 0; i < DGR_LIST_REQUEST.Items.Count; i++)
				{
					//Button BtnBlock, BtnUnblock;
					//CheckBox checkbox = (CheckBox)DGR_RESULT.Items[i].Cells[8].FindControl("check");
					//BtnBlock = (Button)DGR_LIST_REQUEST.FindControl("BTN_BLOCK");
					//BtnUnblock = (Button)DGR_LIST_REQUEST.FindControl("BTN_UNBLOCK");
					Button btnblock = (Button)DGR_LIST_REQUEST.Items[i].Cells[9].FindControl("BTN_BLOCK");
					Button btnunblock = (Button)DGR_LIST_REQUEST.Items[i].Cells[9].FindControl("BTN_UNBLOCK");
					//btnblock.Visible = true;
					//btnunblock.Visible = false;
					btnblock.Visible = false;
					btnunblock.Visible = true;	
				}			
				
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
			this.DGR_LIST_REQUEST.ItemCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.DGR_LIST_REQUEST_ItemCommand);
			this.DGR_LIST_REQUEST.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.DGR_LIST_REQUEST_PageIndexChanged);

		}
		#endregion

		private void FillGrid()
		{
			DataTable dt = new DataTable();
			dt = conn.GetDataTable().Copy();
			DGR_LIST_REQUEST.DataSource = dt;
			try 
			{
				DGR_LIST_REQUEST.DataBind();
			} 
			catch 
			{
				DGR_LIST_REQUEST.CurrentPageIndex = 0;
				DGR_LIST_REQUEST.DataBind();
			}
		}

		private void DGR_LIST_REQUEST_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			Button BtnBlock, BtnUnblock;

			BtnBlock = (Button)e.Item.Cells[10].FindControl("BTN_BLOCK");
			BtnUnblock = (Button)e.Item.Cells[10].FindControl("BTN_UNBLOCK");

			try
			{
				switch(((Button)e.CommandSource).CommandName)
				{
					case "block":
						conn.QueryString = "update idi_request set idi_status='1' where idi_req#='" + e.Item.Cells[2].Text + "'";
						conn.ExecuteQuery();

						BtnBlock.Visible = false;
						BtnUnblock.Visible = true;
						break;
					case "unblock":
						conn.QueryString = "update idi_request set idi_status='2' where idi_req#='" + e.Item.Cells[2].Text + "'";
						conn.ExecuteQuery();

						BtnBlock.Visible = true;
						BtnUnblock.Visible = false;
						break;
					default:
						break;
				}
			}
			catch{}
		}

		private void DGR_LIST_REQUEST_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			DGR_LIST_REQUEST.CurrentPageIndex = 0;
		}
	}
}
