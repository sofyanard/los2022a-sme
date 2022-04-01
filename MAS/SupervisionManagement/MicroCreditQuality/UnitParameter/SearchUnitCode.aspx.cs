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

namespace SME.MAS.SupervisionManagement.MicroCreditQuality.UnitParameter
{
	/// <summary>
	/// Summary description for SearchUnitCode.
	/// </summary>
	public partial class SearchUnitCode : System.Web.UI.Page
	{
		protected Connection conn = new Connection(ConfigurationSettings.AppSettings["conn"]);
		private string theForm, theObj;

		protected void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			
			theForm = Request.QueryString["targetFormID"].Trim();
			theObj = Request.QueryString["targetObjectID"].Trim();

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
			this.DG_List_Unit.ItemCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.DG_List_Unit_ItemCommand);
			this.DG_List_Unit.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.DG_List_Unit_PageIndexChanged);

		}
		#endregion

		private void DG_List_Unit_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			switch (((LinkButton)e.CommandSource).CommandName)
			{
				case "select":
					Response.Write("<script language='JavaScript1.2'>window.opener.document." + 
						theForm + "." + theObj + ".value='" + e.Item.Cells[0].Text.Trim() + "'; " +
						"window.opener.document." + theForm + ".submit(); window.close();</script>");
					break;
			}
		}

		private void PopulateGridUnit()
		{
			conn.QueryString = "select * from rfbranch where branch_name like '%"+ txt_unit.Text +"%' and branch_code not like 'DC%' ";
			conn.ExecuteQuery();
			FillGrid();
		}

		private void FillGrid()
		{
			DataTable dt = new DataTable();
			dt = conn.GetDataTable().Copy();
			DG_List_Unit.DataSource = dt;
			try 
			{
				DG_List_Unit.DataBind();
			} 
			catch 
			{
				DG_List_Unit.CurrentPageIndex = 0;
				DG_List_Unit.DataBind();
			}
		}

		private void DG_List_Unit_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			DG_List_Unit.CurrentPageIndex = e.NewPageIndex;
			FillGrid();
		}

		protected void BTN_cancel_Click(object sender, System.EventArgs e)
		{
			Response.Write("<script language='JavaScript1.2'>window.close();</script>");			
		}

		protected void BTN_SEARCH_Click(object sender, System.EventArgs e)
		{
			PopulateGridUnit();
		}
	}
}
