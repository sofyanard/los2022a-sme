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

namespace SME.DCM.DataCompleteness.Treasury
{
	/// <summary>
	/// Summary description for TradeDataCompleteList.
	/// </summary>
	public partial class TreasuryDataCompleteList : System.Web.UI.Page
	{
		protected Tools tools = new Tools();
		protected Connection conn2 = new Connection(ConfigurationSettings.AppSettings["conn2"]);
		protected Connection conn = new Connection(ConfigurationSettings.AppSettings["conn"]);
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			if(!IsPostBack)
			{
				conn2.QueryString = "SELECT TOP 1 DATA_DATE FROM INTERIM WHERE SOURCE_APPLICATION='02'";
				conn2.ExecuteQuery();

				TXT_CIF.Text = tools.FormatDate(conn2.GetFieldValue("DATA_DATE"),true);

				conn.QueryString = "SELECT BRANCH_CODE, BRANCH_CODE + ' - ' + BRANCH_NAME UNIT_KERJA FROM RFBRANCH";
				conn.ExecuteQuery();

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
			conn2.QueryString = "SELECT DISTINCT * FROM VW_DCM_DATACOMPLETENESS_TREASURY_TREASURYDATACOMPLETELIST";
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
				case "edit_data":
					if(e.Item.Cells[3].Text.Trim() == "Tagihan")
						Response.Redirect("TagihanSpotDerivDataComplet.aspx?cif_no=" + e.Item.Cells[1].Text.Trim());
					else if (e.Item.Cells[3].Text.Trim() == "Kewajiban")
						Response.Redirect("KewajibanSpotDerivDataComplet.aspx?cif_no=" + e.Item.Cells[1].Text.Trim());
					else if (e.Item.Cells[3].Text.Trim() == "Transaksi")
						Response.Redirect("TransaksiSpotDerivDataComplet.aspx?cif_no=" + e.Item.Cells[1].Text.Trim());
					break;
			}
		}

		private void DGR_INTERIM_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			DGR_INTERIM.CurrentPageIndex = e.NewPageIndex;
			ViewData();
		}

		protected void BTN_FIND_Click(object sender, System.EventArgs e)
		{
			DGR_INTERIM.CurrentPageIndex = 0;
			SearchData();
		}

		private void SearchData()
		{
			string query = "";

			if(TXT_CIF.Text != "")
			{
				query += "AND CIF#='" + TXT_CIF.Text + "'";
			}
			if(TXT_REFERENCE.Text != "")
			{
				query += "AND REFERENCE='" + TXT_REFERENCE.Text + "'";
			}
			if(TXT_CUSTNAME.Text != "")
			{
				query += "AND CUSTOMER LIKE '%" + TXT_CUSTNAME.Text + "%'";
			}

			if(query != "")
			{
				conn2.QueryString = "SELECT DISTINCT * FROM VW_DCM_DATACOMPLETENESS_TREASURY_TREASURYDATACOMPLETELIST WHERE 1=1 " + query;
				conn2.ExecuteQuery();
				ViewData();
			}
			else
			{
				conn2.QueryString = "SELECT DISTINCT * FROM VW_DCM_DATACOMPLETENESS_TREASURY_TREASURYDATACOMPLETELIST";
				conn2.ExecuteQuery();
				ViewData();
			}
		}

		protected void BTN_CLEAR_Click(object sender, System.EventArgs e)
		{
			TXT_CIF.Text = "";
			TXT_REFERENCE.Text = "";
			TXT_CUSTNAME.Text = "";
		}

	}
}
