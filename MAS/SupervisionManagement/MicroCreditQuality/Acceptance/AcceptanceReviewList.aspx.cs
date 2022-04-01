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
using System.IO;
using System.Diagnostics;


namespace SME.MAS.SupervisionManagement.MicroCreditQuality.Acceptance
{
	/// <summary>
	/// Summary description for AcceptanceReviewList.
	/// </summary>
	public partial class AcceptanceReviewList : System.Web.UI.Page
	{
		protected Connection conn = new Connection(ConfigurationSettings.AppSettings["conn"]);
		protected Tools tool = new Tools();
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			if(!IsPostBack)
			{
				conn.QueryString = "select * from VW_MAS_UNIT_REVIEW where track_statusby= '"+ Session["UserID"].ToString() +"' ";
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

		private void SearchData()
		{
			if (TXT_UNIT.Text!= "")
			{
				conn.QueryString = "select * from VW_MAS_UNIT_REVIEW where track_statusby= '"+ Session["UserID"].ToString() +"' and unit like '%"+ TXT_UNIT.Text +"%' ";
				conn.ExecuteQuery();
			}
			else
			{
				conn.QueryString = "select * from VW_MAS_UNIT_REVIEW where track_statusby= '"+ Session["UserID"].ToString() +"' ";
				conn.ExecuteQuery();
			}
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
			this.DatGrd.ItemCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.DatGrd_ItemCommand);
			this.DatGrd.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.DatGrd_PageIndexChanged);

		}
		#endregion

		protected void BTN_FIND_Click(object sender, System.EventArgs e)
		{
			SearchData();
		}

		private void DatGrd_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			switch (((LinkButton)e.CommandSource).CommandName)
			{
				case "View":
					conn.QueryString = "select * from MAS_CREDIT_QUALITY_TRACK_HISTORY where seq_unit=" + e.Item.Cells[6].Text + " ";
					conn.ExecuteQuery();
					Response.Redirect("ReviewUnitAccept1.aspx?sta=exist&seq_unit=" + e.Item.Cells[6].Text + 
						"&tc=" + Request.QueryString["tc"] + "&mc=" + Request.QueryString["mc"]);
					
					/*if (conn.GetRowCount() == 1)
					{
						Response.Redirect("ReviewUnitAccept1.aspx?sta=exist&seq_unit=" + e.Item.Cells[6].Text + 
							"&tc=" + Request.QueryString["tc"] + "&mc=" + Request.QueryString["mc"]);
					}
					if (conn.GetRowCount() == 2)
					{
						Response.Redirect("ReviewUnitAccept2.aspx?sta=exist&seq_unit=" + e.Item.Cells[6].Text + 
							"&tc=" + Request.QueryString["tc"] + "&mc=" + Request.QueryString["mc"]);
					}*/
												
					break;
			}
		}

		private void DatGrd_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			DatGrd.CurrentPageIndex = e.NewPageIndex;
			SearchData();			
		}

		protected void DatGrd_SelectedIndexChanged(object sender, System.EventArgs e)
		{
		
		}
	}
}
