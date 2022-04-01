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
using DMS.CuBESCore;
using DMS.DBConnection;
using Microsoft.VisualBasic;
using System.Configuration;

namespace SME.DCM
{
	/// <summary>
	/// Summary description for TreasuryDataComplet.
	/// </summary>
	public partial class TreasuryDataComplet : System.Web.UI.Page
	{
		protected Connection conn2 = new Connection(ConfigurationSettings.AppSettings["conn2"]);
		protected Connection conn = new Connection(ConfigurationSettings.AppSettings["conn"]);
		protected Tools tools = new Tools();
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			if(!IsPostBack)
			{
				conn2.QueryString = "SELECT TOP 1 DATA_DATE FROM INTERIM WHERE SOURCE_APPLICATION='03'";
				conn2.ExecuteQuery();

				TXT_TGL_DATA.Text = tools.FormatDate(conn2.GetFieldValue("DATA_DATE"),true);

				conn.QueryString = "select branch_code, branch_code + ' - ' + branch_name unit_kerja from rfbranch";
				conn.ExecuteQuery();

				DDL_UNIT_KERJA.Items.Add(new ListItem("--Pilih--", ""));

				for (int i = 0; i < conn.GetRowCount(); i++)
				{
					DDL_UNIT_KERJA.Items.Add(new ListItem(conn.GetFieldValue(i,1), conn.GetFieldValue(i,0)));
				}

				ViewData();

				if(Request.QueryString["msg"] != "" && Request.QueryString["msg"] != null)
				{
					GlobalTools.popMessage(this, Request.QueryString["msg"]);
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
			this.DGR_INTERIM.ItemCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.DGR_INTERIM_ItemCommand);
			this.DGR_INTERIM.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.DGR_INTERIM_PageIndexChanged);

		}
		#endregion

		private void ViewData()
		{
			if(DDL_UNIT_KERJA.SelectedValue == "")
				conn2.QueryString = "SELECT * FROM VW_DATA_INTERIM WHERE SOURCE_APPLICATION='03'";
			else
				conn2.QueryString = "SELECT * FROM VW_DATA_INTERIM WHERE SOURCE_APPLICATION='03' AND FAC_BRANCH='" + DDL_UNIT_KERJA.SelectedValue + "'";

			conn2.ExecuteQuery();
			FillGrid();
		}

		private void FillGrid()
		{
			DataTable dt = new DataTable();
			dt = conn2.GetDataTable().Copy();
			DGR_INTERIM.DataSource = dt;
			try 
			{
				DGR_INTERIM.DataBind();
			} 
			catch 
			{
				DGR_INTERIM.CurrentPageIndex = 0;
				DGR_INTERIM.DataBind();
			}
		}

		private void DGR_INTERIM_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			switch (((LinkButton)e.CommandSource).CommandName)
			{
				case "view_data":
					if(e.Item.Cells[3].Text.Trim() == "Tagihan")
						Response.Redirect("DataTagihanSpot.aspx?cif_no=" + e.Item.Cells[1].Text.Trim());
					else if (e.Item.Cells[3].Text.Trim() == "Kewajiban")
						Response.Redirect("DataKewajibanSpot.aspx?cif_no=" + e.Item.Cells[1].Text.Trim());
					else if (e.Item.Cells[3].Text.Trim() == "Transaksi")
						Response.Redirect("DataTransaksiSpot.aspx?cif_no=" + e.Item.Cells[1].Text.Trim());
					break;
			}
		}

		private void DGR_INTERIM_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			DGR_INTERIM.CurrentPageIndex = e.NewPageIndex;
			ViewData();
		}

		protected void DDL_UNIT_KERJA_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if(DDL_UNIT_KERJA.SelectedValue == "")
				conn2.QueryString = "SELECT * FROM VW_DATA_INTERIM WHERE SOURCE_APPLICATION='03'";
			else
				conn2.QueryString = "SELECT * FROM VW_DATA_INTERIM WHERE SOURCE_APPLICATION='03' AND FAC_BRANCH='" + DDL_UNIT_KERJA.SelectedValue + "'";

			conn2.ExecuteQuery();
			FillGrid();
		}
	}
}
