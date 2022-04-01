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
using DMS.CuBESCore;
using DMS.DBConnection;
using Microsoft.VisualBasic;

namespace SME.AccountPlanning.Parameter.Maker
{
	/// <summary>
	/// Summary description for AP_VARIABLE.
	/// </summary>
	public partial class AP_VARIABLE : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.TextBox _txt_CASH_PROCESSING_FEE_DAY;
		protected Connection conn = new Connection(ConfigurationSettings.AppSettings["conn"]);
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			TBL_MAKER_REQUEST.Visible = false;
			BindData(DatGrd, "SELECT *, (CASE ISACTIVE WHEN '1' THEN 'Active' ELSE 'Not Active' END) AS DSTATUS FROM AP_VARIABLE");
			FillAllTheDDL();
		}

		private void FillAllTheDDL()
		{
			//_ddl_benchmark
			//_ddl_uploaded_data

			GlobalTools.fillRefList(_ddl_benchmark, "SELECT ID_AP_BENCHMARK, DESCRIPTION FROM AP_BENCHMARK", conn);
			GlobalTools.fillRefList(_ddl_uploaded_data, "SELECT ID_AP_UPLOADED_DATA, DESCRIPTION FROM AP_UPLOADED_DATA", conn);
		}

		private void BindData(DataGrid dgrN, string strconn)
		{
			if(strconn != "")
			{
				conn.QueryString = strconn;
				conn.ExecuteQuery();

				System.Data.DataTable dt = new System.Data.DataTable();
				dt = conn.GetDataTable().Copy();

				System.Web.UI.WebControls.DataGrid dg = dgrN;
				dg.DataSource = dt;

				try
				{
					dg.DataBind();
				}
				catch
				{
					dg.CurrentPageIndex = dg.PageCount - 1;
					dg.DataBind();
				}

				conn.ClearData();
			}
		}

		public void RetrieveData(Connection conn)
		{
			/*
			 *	DATE
				ISRANGE
				STATUS
				PRODUCT_LINK_ID
				ID_AP_BENCHMARK
				ID_AP_UPLOADED_DATA
				ISACTIVE
			 * */
			_txt_ID.Text = conn.GetFieldValue("ID_AP_VARIABLE");
			_txt_DESC.Text = conn.GetFieldValue("DESCRIPTION");
			_txt_CPFD.Text = conn.GetFieldValue("CASH_PROCESSING_FEE_DAY");
			_txt_CASH_IN_SHIFT_DAY.Text = conn.GetFieldValue("CASH_IN_SHIFT_DAY");
			_txt_CASH_IN_TRANSIT_COST_DAY.Text = conn.GetFieldValue("CASH_IN_TRANSIT_COST_DAY");
			_txt_H2HDEVELOPMENT_FEE_USD.Text = conn.GetFieldValue("H2HDEVELOPMENT_FEE_USD");
			_txt_COLLECTION_FEE_DAY.Text = conn.GetFieldValue("COLLECTION_FEE_DAY");
			_txt_COMMITMENT_FEE.Text = conn.GetFieldValue("COMMITMENT_FEE");
			_txt_CORRESPONDENT_COST_USD.Text = conn.GetFieldValue("CORRESPONDENT_COST_USD");
			_txt_CORRESPONDENT_FEE_USD.Text = conn.GetFieldValue("CORRESPONDENT_FEE_USD");
			_txt_DIRECT_IT_COST_PER_MILLION_UNIT.Text = conn.GetFieldValue("DIRECT_IT_COST_PER_MILLION_UNIT");
			_txt_FEE_TRANSACTION.Text = conn.GetFieldValue("FEE_TRANSACTION");
			_txt_NON_H2H_DEV_FEE.Text = conn.GetFieldValue("NON_H2H_DEV_FEE");
			_txt_INDIRECT_COST_TRANSACTION.Text = conn.GetFieldValue("INDIRECT_COST_TRANSACTION");
			_txt_MONTHLY_MINIMUM_TRANSACTION.Text = conn.GetFieldValue("MONTHLY_MINIMUM_TRANSACTION");
			_txt_PROVISI_FASILITAS_QUARTAL_PERCENT.Text = conn.GetFieldValue("PROVISI_FASILITAS_QUARTAL_PERCENT");
			_txt_PROVISI_GIRO_JAMINAN_USD.Text = conn.GetFieldValue("PROVISI_GIRO_JAMINAN_USD");
			_txt_UNIT_COST_PER_MILLION_UNIT.Text = conn.GetFieldValue("UNIT_COST_PER_MILLION_UNIT");
			_txt_PROVISI_BLOKIR_PERQUARTAL_PERCENT.Text = conn.GetFieldValue("PROVISI_BLOKIR_PERQUARTAL_PERCENT");
			_txt_INTEREST_RATE_PERCENT.Text = conn.GetFieldValue("INTEREST_RATE_PERCENT");
			_txt_IT_COST_TRANSACTION.Text = conn.GetFieldValue("IT_COST_TRANSACTION");
			_txt_JOINING_FEE.Text = conn.GetFieldValue("JOINING_FEE");
			_txt_MAXIMUM_PROVISION_USD.Text = conn.GetFieldValue("MAXIMUM_PROVISION_USD");
			_txt_MINIMUM_FEE_PER_PROCESS.Text = conn.GetFieldValue("MINIMUM_FEE_PER_PROCESS");
			_txt_MINIMUM_PROVISION_USD.Text = conn.GetFieldValue("MINIMUM_PROVISION_USD");
			_txt_PROVISION_PERCENT.Text = conn.GetFieldValue("PROVISION_PERCENT");
			_txt_RATE_PER_EMPLOYEE.Text = conn.GetFieldValue("RATE_PER_EMPLOYEE");
			_txt_REFERRAL_FEE_INCOME_PERCENT.Text = conn.GetFieldValue("REFERRAL_FEE_INCOME_PERCENT");
			_txt_SERVICE_COST.Text = conn.GetFieldValue("SERVICE_COST");
			_txt_SERVICE_FEE_PERCENT.Text = conn.GetFieldValue("SERVICE_FEE_PERCENT");
			_txt_TRANSACT_FEE.Text = conn.GetFieldValue("TRANSACTION_FEE");
			_txt_SWIFT_FEE_PERCENT.Text = conn.GetFieldValue("SWIFT_FEE_PERCENT");
			_txt_SYNDICATION_FEE_PERCENT.Text = conn.GetFieldValue("SYNDICATION_FEE_PERCENT");
			_txt_USAGE_COMMISION_FEE_PERCENT.Text = conn.GetFieldValue("USAGE_COMMISION_FEE_PERCENT");
			_txt_ADMIN_FEE_PERCENT.Text = conn.GetFieldValue("ADMIN_FEE_PERCENT");
			_txt_ANNUAL_FEE.Text = conn.GetFieldValue("ANNUAL_FEE");
			_txt_BI_COST.Text = conn.GetFieldValue("BI_COST");
			_txt_CABLE_COST_USD.Text = conn.GetFieldValue("CABLE_COST_USD");
			_txt_CABLE_FEE_USD.Text = conn.GetFieldValue("CABLE_FEE_USD");
			_txt_FIXED_FEE.Text = conn.GetFieldValue("FIXED_FEE");
			_txt_FTP_CKPN_PERCENT.Text = conn.GetFieldValue("FTP_CKPN_PERCENT");
			_txt_FTP_COST_PERCENT.Text = conn.GetFieldValue("FTP_COST_PERCENT");
			_txt_FTP_GWM_PERCENT.Text = conn.GetFieldValue("FTP_GWM_PERCENT");
			_txt_FTP_INCOME_PERCENT.Text = conn.GetFieldValue("FTP_INCOME_PERCENT");
			_txt_OTHER_COST_PERCENT.Text = conn.GetFieldValue("OTHER_COST_PERCENT");
			_txt_PENALTY_FEE_PERCENT.Text = conn.GetFieldValue("PENALTY_FEE_PERCENT");
			_txt_CKPN_PERCENT.Text = conn.GetFieldValue("CKPN_PERCENT");
			_txt_GWM_PERCENT.Text = conn.GetFieldValue("GWM_PERCENT");
			_txt_SPREAD_PERCENT.Text = conn.GetFieldValue("SPREAD_PERCENT");
			//_txt_REQUEST.Text = conn.GetFieldValue("REQUEST");
			_txt_PREMIUM_FOR_LPS_PERCENT.Text = conn.GetFieldValue("PREMIUM_FOR_LPS_PERCENT");

			if(conn.GetFieldValue("ISACTIVE") == "" || conn.GetFieldValue("ISACTIVE") == null || conn.GetFieldValue("ISACTIVE") == "0")
			{
				CB_ACTIVE.Checked = false;
			}
			else
			{
				CB_ACTIVE.Checked = true;
			}

			_btnEditedUpdate.Text = "Update Parameter";
		}

		private void DatGrd_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			switch(((LinkButton)e.CommandSource).CommandName)
			{
				case "Edit":
					conn.QueryString = "SELECT * FROM AP_VARIABLE WHERE ID_AP_VARIABLE = '" + e.Item.Cells[0].Text.Trim() + "'";
					conn.ExecuteQuery();
					RetrieveData(conn);
					break;
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
			this.DatGrd.ItemCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.DatGrd_ItemCommand);

		}
		#endregion

		protected void _btnEditedUpdate_Click(object sender, System.EventArgs e)
		{
			if(_btnEditedUpdate.Text == "Insert Parameter")
			{
				conn.QueryString = "";
				conn.ExecuteQuery();

				Tools.popMessage(this, "The data has been inserted !");
			}
			else if(_btnEditedUpdate.Text == "Update Parameter")
			{	
				conn.QueryString = "";
				conn.ExecuteQuery();

				Tools.popMessage(this, "The data has been updated !");
			}	
		}
	}
}
