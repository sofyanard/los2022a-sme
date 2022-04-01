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
using Microsoft.VisualBasic;
using DMS.CuBESCore;
using DMS.DBConnection;
using System.Configuration;

namespace SME.DCM.DataDictionary.ApprovalDataInitiation
{
	/// <summary>
	/// Summary description for DetailDataRequest.
	/// </summary>
	public partial class DetailDataRequest : System.Web.UI.Page
	{
		protected Tools tools = new Tools();
		protected System.Web.UI.WebControls.DataGrid DGR_;
		protected Connection conn = new Connection(ConfigurationSettings.AppSettings["conn"]);
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			ViewMenu();
			if(!IsPostBack)
			{
				
			}

			ViewDataCIF();
			ViewDataDanaPihakTiga();
			ViewPerkreditan();
			ViewAgunan();
			ViewTrade();
			ViewTreasury();
			ViewHistoricalTransaction();
			BindCBWithExistingData();
		}

		/*********************** ALL NEW PROGRAMMING RIGHT HERE *************************/

		public void ViewDataCIF()
		{
			
			BindData("DGR_CIF","SELECT DD_REQUESTED_FIELD_LIST.*, DD_FIELDS_CIF.FIELDSDESCRIPTION FROM DD_REQUESTED_FIELD_LIST, " + 
				"DD_FIELDS_CIF WHERE DD_REQUESTED_FIELD_LIST.AP_REGNO = '" + Request.QueryString["regno"] + "' AND " + 
				"DD_REQUESTED_FIELD_LIST.TABLE_NAME = 'DD_FIELDS_CIF' " + 
				"AND DD_FIELDS_CIF.FIELDSNAME = DD_REQUESTED_FIELD_LIST.FIELDSNAME");
		}

		public void ViewDataDanaPihakTiga()
		{
			//BindData("DGR_DANA","SELECT * FROM DD_REQUESTED_FIELD_LIST WHERE AP_REGNO = '" + Request.QueryString["regno"] + "' AND  TABLE_NAME = 'DD_FIELDS_DANA'");
		
			BindData("DGR_DANA","SELECT DD_REQUESTED_FIELD_LIST.*, DD_FIELDS_DANA.FIELDSDESCRIPTION FROM DD_REQUESTED_FIELD_LIST, " + 
				"DD_FIELDS_DANA WHERE DD_REQUESTED_FIELD_LIST.AP_REGNO = '" + Request.QueryString["regno"] + "' AND " + 
				"DD_REQUESTED_FIELD_LIST.TABLE_NAME = 'DD_FIELDS_DANA' " + 
				"AND DD_FIELDS_DANA.FIELDSNAME = DD_REQUESTED_FIELD_LIST.FIELDSNAME");
		}

		public void ViewPerkreditan()
		{
			//BindData("DGR_PERKREDITAN","SELECT * FROM DD_REQUESTED_FIELD_LIST WHERE AP_REGNO = '" + Request.QueryString["regno"] + "' AND  TABLE_NAME = 'DD_FIELDS_PERKREDITAN'");
		
			BindData("DGR_PERKREDITAN","SELECT DD_REQUESTED_FIELD_LIST.*, DD_FIELDS_PERKREDITAN.FIELDSDESCRIPTION FROM DD_REQUESTED_FIELD_LIST, " + 
				"DD_FIELDS_PERKREDITAN WHERE DD_REQUESTED_FIELD_LIST.AP_REGNO = '" + Request.QueryString["regno"] + "' AND " + 
				"DD_REQUESTED_FIELD_LIST.TABLE_NAME = 'DD_FIELDS_PERKREDITAN' " + 
				"AND DD_FIELDS_PERKREDITAN.FIELDSNAME = DD_REQUESTED_FIELD_LIST.FIELDSNAME");
		}

		public void ViewAgunan()
		{
			//BindData("DGR_AGUNAN","SELECT * FROM DD_REQUESTED_FIELD_LIST WHERE AP_REGNO = '" + Request.QueryString["regno"] + "' AND  TABLE_NAME = 'DD_FIELDS_AGUNAN'");
		
			BindData("DGR_AGUNAN","SELECT DD_REQUESTED_FIELD_LIST.*, DD_FIELDS_AGUNAN.FIELDSDESCRIPTION FROM DD_REQUESTED_FIELD_LIST, " + 
				"DD_FIELDS_AGUNAN WHERE DD_REQUESTED_FIELD_LIST.AP_REGNO = '" + Request.QueryString["regno"] + "' AND " + 
				"DD_REQUESTED_FIELD_LIST.TABLE_NAME = 'DD_FIELDS_AGUNAN' " + 
				"AND DD_FIELDS_AGUNAN.FIELDSNAME = DD_REQUESTED_FIELD_LIST.FIELDSNAME");
		}

		public void ViewTrade()
		{
			//BindData("DGR_TRADE","SELECT * FROM DD_REQUESTED_FIELD_LIST WHERE AP_REGNO = '" + Request.QueryString["regno"] + "' AND  TABLE_NAME = 'DD_FIELDS_TRADE'");
		
			BindData("DGR_TRADE","SELECT DD_REQUESTED_FIELD_LIST.*, DD_FIELDS_TRADE.FIELDSDESCRIPTION FROM DD_REQUESTED_FIELD_LIST, " + 
				"DD_FIELDS_TRADE WHERE DD_REQUESTED_FIELD_LIST.AP_REGNO = '" + Request.QueryString["regno"] + "' AND " + 
				"DD_REQUESTED_FIELD_LIST.TABLE_NAME = 'DD_FIELDS_TRADE' " + 
				"AND DD_FIELDS_TRADE.FIELDSNAME = DD_REQUESTED_FIELD_LIST.FIELDSNAME");
		}

		public void ViewTreasury()
		{
			//BindData("DGR_TREASURY","SELECT * FROM DD_REQUESTED_FIELD_LIST WHERE AP_REGNO = '" + Request.QueryString["regno"] + "' AND TABLE_NAME = 'DD_FIELDS_TREASURY'");
		
			BindData("DGR_TREASURY","SELECT DD_REQUESTED_FIELD_LIST.*, DD_FIELDS_TREASURY.FIELDSDESCRIPTION FROM DD_REQUESTED_FIELD_LIST, " + 
				"DD_FIELDS_TREASURY WHERE DD_REQUESTED_FIELD_LIST.AP_REGNO = '" + Request.QueryString["regno"] + "' AND " + 
				"DD_REQUESTED_FIELD_LIST.TABLE_NAME = 'DD_FIELDS_TREASURY' " + 
				"AND DD_FIELDS_TREASURY.FIELDSNAME = DD_REQUESTED_FIELD_LIST.FIELDSNAME");
		}

		public void ViewHistoricalTransaction()
		{
			//BindData("DGR_TREASURY","SELECT * FROM DD_FIELDS_TREASURY");

			string loanhist = "SELECT * FROM DD_FIELDS_LOANTRANSACTION";
			loanhist = "SELECT DD_REQUESTED_FIELD_LIST.*, DD_FIELDS_LOANTRANSACTION.FIELDSDESCRIPTION, 'LOAN ACCOUNT' as TYPE FROM DD_REQUESTED_FIELD_LIST, " + 
				"DD_FIELDS_LOANTRANSACTION WHERE DD_REQUESTED_FIELD_LIST.AP_REGNO = '" + Request.QueryString["regno"] + "' AND " + 
				"DD_REQUESTED_FIELD_LIST.TABLE_NAME = 'DD_FIELDS_LOANTRANSACTION' " + 
				"AND DD_FIELDS_LOANTRANSACTION.FIELDSNAME = DD_REQUESTED_FIELD_LIST.FIELDSNAME";

			string savinggiro = "SELECT * FROM DD_FIELDS_SAVINGGIROTRANSACTION";
			savinggiro = "SELECT DD_REQUESTED_FIELD_LIST.*, DD_FIELDS_SAVINGGIROTRANSACTION.FIELDSDESCRIPTION, 'SAVING & GIRO ACCOUNT' as TYPE FROM DD_REQUESTED_FIELD_LIST, " + 
				"DD_FIELDS_SAVINGGIROTRANSACTION WHERE DD_REQUESTED_FIELD_LIST.AP_REGNO = '" + Request.QueryString["regno"] + "' AND " + 
				"DD_REQUESTED_FIELD_LIST.TABLE_NAME = 'DD_FIELDS_SAVINGGIROTRANSACTION' " + 
				"AND DD_FIELDS_SAVINGGIROTRANSACTION.FIELDSNAME = DD_REQUESTED_FIELD_LIST.FIELDSNAME";

			string timedeposit = "SELECT * FROM DD_FIELDS_TIMEDEPOSITTRANSACTION";
			timedeposit = "SELECT DD_REQUESTED_FIELD_LIST.*, DD_FIELDS_TIMEDEPOSITTRANSACTION.FIELDSDESCRIPTION, 'TIME DEPOSIT ACCOUNT' as TYPE FROM DD_REQUESTED_FIELD_LIST, " + 
				"DD_FIELDS_TIMEDEPOSITTRANSACTION WHERE DD_REQUESTED_FIELD_LIST.AP_REGNO = '" + Request.QueryString["regno"] + "' AND " + 
				"DD_REQUESTED_FIELD_LIST.TABLE_NAME = 'DD_FIELDS_TIMEDEPOSITTRANSACTION' " + 
				"AND DD_FIELDS_TIMEDEPOSITTRANSACTION.FIELDSNAME = DD_REQUESTED_FIELD_LIST.FIELDSNAME";

			string trade = "SELECT * FROM DD_FIELDS_TRADETRANSACTION";
			trade = "SELECT DD_REQUESTED_FIELD_LIST.*, DD_FIELDS_TRADETRANSACTION.FIELDSDESCRIPTION, 'TRADE' as TYPE FROM DD_REQUESTED_FIELD_LIST, " + 
				"DD_FIELDS_TRADETRANSACTION WHERE DD_REQUESTED_FIELD_LIST.AP_REGNO = '" + Request.QueryString["regno"] + "' AND " + 
				"DD_REQUESTED_FIELD_LIST.TABLE_NAME = 'DD_FIELDS_TRADETRANSACTION' " + 
				"AND DD_FIELDS_TRADETRANSACTION.FIELDSNAME = DD_REQUESTED_FIELD_LIST.FIELDSNAME";

			string treasury = "SELECT * FROM DD_FIELDS_TREASURYTRANSACTION";
			treasury = "SELECT DD_REQUESTED_FIELD_LIST.*, DD_FIELDS_TREASURYTRANSACTION.FIELDSDESCRIPTION, 'TREASURY' as TYPE  FROM DD_REQUESTED_FIELD_LIST, " + 
				"DD_FIELDS_TREASURYTRANSACTION WHERE DD_REQUESTED_FIELD_LIST.AP_REGNO = '" + Request.QueryString["regno"] + "' AND " + 
				"DD_REQUESTED_FIELD_LIST.TABLE_NAME = 'DD_FIELDS_TREASURYTRANSACTION' " + 
				"AND DD_FIELDS_TREASURYTRANSACTION.FIELDSNAME = DD_REQUESTED_FIELD_LIST.FIELDSNAME";

			string gabungan = loanhist + " UNION " + savinggiro + " UNION " + timedeposit + " UNION " + trade + " UNION " + treasury;

			BindData("DGR_HISTORICAL_TRANSACTION",gabungan);
		}

		private void BindCBWithExistingData()
		{
			for (int i = 0; i < DGR_CIF.Items.Count; i++)
			{
				conn.QueryString = "SELECT * FROM DD_REQUESTED_FIELD_LIST WHERE AP_REGNO = '" + Request.QueryString["regno"] + "' AND FIELDSNAME = '" + DGR_CIF.Items[i].Cells[0].Text.ToString() + "' AND TABLE_NAME = 'DD_FIELDS_CIF'";
				conn.ExecuteQuery();

				CheckBox CHK_DATA = (CheckBox) DGR_CIF.Items[i].Cells[2].FindControl("CHK_DATA_CIF");
				if(conn.GetRowCount() > 0)
				{
		
					CHK_DATA.Checked = true;
				}
				else
				{	
					CHK_DATA.Checked = false;
				}
				CHK_DATA.Enabled = false;
			}

			for (int i = 0; i < DGR_DANA.Items.Count; i++)
			{
				conn.QueryString = "SELECT * FROM DD_REQUESTED_FIELD_LIST WHERE AP_REGNO = '" + Request.QueryString["regno"] + "' AND FIELDSNAME = '" + DGR_DANA.Items[i].Cells[0].Text.ToString() + "' AND TABLE_NAME = 'DD_FIELDS_DANA'";
				conn.ExecuteQuery();

				CheckBox CHK_DATA = (CheckBox) DGR_DANA.Items[i].Cells[2].FindControl("CHK_DATA_DANA");
				if(conn.GetRowCount() > 0)
				{
					
					CHK_DATA.Checked = true;
				}
				else
				{	
					CHK_DATA.Checked = false;
				}
				CHK_DATA.Enabled = false;
			}

			for (int i = 0; i < DGR_PERKREDITAN.Items.Count; i++)
			{
				conn.QueryString = "SELECT * FROM DD_REQUESTED_FIELD_LIST WHERE AP_REGNO = '" + Request.QueryString["regno"] + "' AND FIELDSNAME = '" + DGR_PERKREDITAN.Items[i].Cells[0].Text.ToString() + "' AND TABLE_NAME = 'DD_FIELDS_PERKREDITAN'";
				conn.ExecuteQuery();

				CheckBox CHK_DATA = (CheckBox) DGR_PERKREDITAN.Items[i].Cells[2].FindControl("CHK_DATA_KREDIT");
				if(conn.GetRowCount() > 0)
				{
					
					CHK_DATA.Checked = true;
				}
				else
				{	
					CHK_DATA.Checked = false;
				}
				CHK_DATA.Enabled = false;
			}

			for (int i = 0; i < DGR_AGUNAN.Items.Count; i++)
			{
				conn.QueryString = "SELECT * FROM DD_REQUESTED_FIELD_LIST WHERE AP_REGNO = '" + Request.QueryString["regno"] + "' AND FIELDSNAME = '" + DGR_AGUNAN.Items[i].Cells[0].Text.ToString() + "' AND TABLE_NAME = 'DD_FIELDS_AGUNAN'";
				conn.ExecuteQuery();

				CheckBox CHK_DATA = (CheckBox) DGR_AGUNAN.Items[i].Cells[2].FindControl("CHK_DATA_AGUNAN");
				if(conn.GetRowCount() > 0)
				{
					
					CHK_DATA.Checked = true;
				}
				else
				{	
					CHK_DATA.Checked = false;
				}
				CHK_DATA.Enabled = false;
			}

			for (int i = 0; i < DGR_TRADE.Items.Count; i++)
			{
				conn.QueryString = "SELECT * FROM DD_REQUESTED_FIELD_LIST WHERE AP_REGNO = '" + Request.QueryString["regno"] + "' AND FIELDSNAME = '" + DGR_TRADE.Items[i].Cells[0].Text.ToString() + "' AND TABLE_NAME = 'DD_FIELDS_TRADE'";
				conn.ExecuteQuery();

				CheckBox CHK_DATA = (CheckBox) DGR_TRADE.Items[i].Cells[2].FindControl("CHK_DATA_TRADE");
				if(conn.GetRowCount() > 0)
				{
					
					CHK_DATA.Checked = true;
				}
				else
				{	
					CHK_DATA.Checked = false;
				}
				CHK_DATA.Enabled = false;
			}

			for (int i = 0; i < DGR_TREASURY.Items.Count; i++)
			{
				conn.QueryString = "SELECT * FROM DD_REQUESTED_FIELD_LIST WHERE AP_REGNO = '" + Request.QueryString["regno"] + "' AND FIELDSNAME = '" + DGR_TREASURY.Items[i].Cells[0].Text.ToString() + "' AND TABLE_NAME = 'DD_FIELDS_TREASURY'";
				conn.ExecuteQuery();

				CheckBox CHK_DATA = (CheckBox) DGR_TREASURY.Items[i].Cells[2].FindControl("CHK_DATA_TREASURY");
				if(conn.GetRowCount() > 0)
				{
					
					CHK_DATA.Checked = true;
				}
				else
				{	
					CHK_DATA.Checked = false;
				}
				CHK_DATA.Enabled = false;
			}

			for (int i = 0; i < DGR_HISTORICAL_TRANSACTION.Items.Count; i++)
			{
				conn.QueryString = "SELECT * FROM DD_REQUESTED_FIELD_LIST WHERE AP_REGNO = '" + Request.QueryString["regno"] + "' AND FIELDSNAME = '" + DGR_HISTORICAL_TRANSACTION.Items[i].Cells[1].Text.ToString() + "' AND TABLE_NAME = 'DD_FIELDS_LOANTRANSACTION'";
				conn.ExecuteQuery();

				if(conn.GetRowCount() == 0)
				{
					conn.QueryString = "SELECT * FROM DD_REQUESTED_FIELD_LIST WHERE AP_REGNO = '" + Request.QueryString["regno"] + "' AND FIELDSNAME = '" + DGR_HISTORICAL_TRANSACTION.Items[i].Cells[1].Text.ToString() + "' AND TABLE_NAME = 'DD_FIELDS_SAVINGGIROTRANSACTION'";
					conn.ExecuteQuery();

					if(conn.GetRowCount() == 0)
					{
						conn.QueryString = "SELECT * FROM DD_REQUESTED_FIELD_LIST WHERE AP_REGNO = '" + Request.QueryString["regno"] + "' AND FIELDSNAME = '" + DGR_HISTORICAL_TRANSACTION.Items[i].Cells[1].Text.ToString() + "' AND TABLE_NAME = 'DD_FIELDS_TIMEDEPOSITTRANSACTION'";
						conn.ExecuteQuery();

						if(conn.GetRowCount() == 0)
						{
							conn.QueryString = "SELECT * FROM DD_REQUESTED_FIELD_LIST WHERE AP_REGNO = '" + Request.QueryString["regno"] + "' AND FIELDSNAME = '" + DGR_HISTORICAL_TRANSACTION.Items[i].Cells[1].Text.ToString() + "' AND TABLE_NAME = 'DD_FIELDS_TRADETRANSACTION'";
							conn.ExecuteQuery();

							if(conn.GetRowCount() == 0)
							{
								conn.QueryString = "SELECT * FROM DD_REQUESTED_FIELD_LIST WHERE AP_REGNO = '" + Request.QueryString["regno"] + "' AND FIELDSNAME = '" + DGR_HISTORICAL_TRANSACTION.Items[i].Cells[1].Text.ToString() + "' AND TABLE_NAME = 'DD_FIELDS_TREASURYTRANSACTION'";
								conn.ExecuteQuery();
							}
						}
					}
				}

				CheckBox CHK_DATA = (CheckBox) DGR_HISTORICAL_TRANSACTION.Items[i].Cells[3].FindControl("CHK_DATA_HISTORICAL_TRANSACTION");
				if(conn.GetRowCount() > 0)
				{
		
					CHK_DATA.Checked = true;
				}
				else
				{	
					CHK_DATA.Checked = false;
				}
				CHK_DATA.Enabled = false;
			}
		}

		/********************************************************************************/

		private void ViewMenu()
		{
			Menu.Controls.Clear();
			try 
			{
				conn.QueryString = "SELECT * FROM SCREENMENU WHERE MENUCODE = '" + Request.QueryString["mc"] + "'";
				conn.ExecuteQuery();
				
				for (int i = 0; i < conn.GetRowCount(); i++) 
				{
					HyperLink t = new HyperLink();
					t.Text = conn.GetFieldValue(i, 2);
					t.Font.Bold = true;
					string strtemp = "";
					if (conn.GetFieldValue(i, 3).Trim()!= "") 
					{
						if (conn.GetFieldValue(i,3).IndexOf("mc=") >= 0)
							strtemp = "&regno=" + Request.QueryString["regno"] + "&exist=1";
						else
							strtemp = "&mc=" + Request.QueryString["mc"]+ "&regno=" + Request.QueryString["regno"] + "&exist=1";
					}
					else 
					{
						strtemp = ""; 
					}
					t.NavigateUrl = conn.GetFieldValue(i, 3)+strtemp;
					Menu.Controls.Add(t);
					Menu.Controls.Add(new LiteralControl("&nbsp;&nbsp;&nbsp;"));
				}
			} 
			catch (Exception ex) 
			{
				string temp = ex.ToString();
			}
		}

		private void FillGrid1()
		{
			conn.QueryString = "SELECT * FROM VW_DD_APPROVAL_INITIATION_DETAILDATAREQUEST1";
			//BindData(DGR_CIF.ID.ToString(), conn.QueryString);
		}

		private void FillGrid2()
		{
			conn.QueryString = "SELECT * FROM VW_DD_APPROVAL_INITIATION_DETAILDATAREQUEST2";
			//BindData(DGR_LOAN.ID.ToString(), conn.QueryString);
		}

		private void BindData(string dataGridName, string strconn)
		{
			if(strconn != "")
			{
				conn.QueryString = strconn;
				conn.ExecuteQuery();
			}

			System.Data.DataTable dt = new System.Data.DataTable();
			dt = conn.GetDataTable().Copy();

			System.Web.UI.WebControls.DataGrid dg = (System.Web.UI.WebControls.DataGrid)Page.FindControl(dataGridName);
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
			this.DGR_CIF.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.DGR_CIF_PageIndexChanged);

		}
		#endregion

		private void DGR_CIF_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			DGR_CIF.CurrentPageIndex = e.NewPageIndex;
			FillGrid1();
		}

		private void DGR_LOAN_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			//DGR_LOAN.CurrentPageIndex = e.NewPageIndex;
			FillGrid2();
		}

		protected void BTN_BACK_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			Response.Redirect("ApprDataRequestList.aspx?mc=" + Request.QueryString["mc"]);
		}
	}
}
