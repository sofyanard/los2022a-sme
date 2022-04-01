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

namespace SME.DCM.DataDictionary.DataInitiation.RejectInitiation
{
	/// <summary>
	/// Summary description for DataTransactionHistory.
	/// </summary>
	public partial class DataTransactionHistory : System.Web.UI.Page
	{
		protected Tools tool = new Tools();
		protected Connection conn = new Connection(ConfigurationSettings.AppSettings["conn"]);
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			ViewMenu();
			ViewDataLoan();
			ViewDataSavingGiro();
			ViewTimeDeposit();
			ViewTrade();
			ViewTreasury();
			if(!IsPostBack)
			{
				
			}
		}

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
							strtemp = "&regno=" + Request.QueryString["regno"] + "&view=1";
						else
							strtemp = "&mc=" + Request.QueryString["mc"]+ "&regno=" + Request.QueryString["regno"] + "&view=1";
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
			this.DGR_LOAN.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.DGR_LOAN_PageIndexChanged);
			this.DGR_SAVING_GIRO.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.DGR_SAVING_GIRO_PageIndexChanged);
			this.DGR_TIME_DEPOSIT.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.DGR_TIME_DEPOSIT_PageIndexChanged);
			this.DGR_TRADE.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.DGR_TRADE_PageIndexChanged);
			this.DGR_TREASURY.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.DGR_TREASURY_PageIndexChanged);

		}
		#endregion

		protected void BTN_BACK_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			Response.Redirect("DataRejectInitList.aspx?mc=" + Request.QueryString["mc"]);
		}

		//1. LOAN ACCOUNT
		protected void RDO_LOAN_ACCOUNT_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			ViewDataLoan();
		}

		private void DGR_LOAN_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			DGR_LOAN.CurrentPageIndex = e.NewPageIndex;
			ViewDataLoan();
		}
		
		#region ViewDataLoan

		private void ViewDataLoan()
		{
			BindData("DGR_LOAN","SELECT * FROM DD_FIELDS_LOANTRANSACTION");
			setUpeventhandlerCBLoan();
			BindCBWithExistingDataLoan();
		}

		private void BindCBWithExistingDataLoan()
		{
			for (int i = 0; i < DGR_LOAN.Items.Count; i++)
			{
				conn.QueryString = "SELECT * FROM DD_REQUESTED_FIELD_LIST WHERE AP_REGNO = '" + Request.QueryString["regno"] + "' AND FIELDSNAME = '" + DGR_LOAN.Items[i].Cells[0].Text.ToString() + "' AND TABLE_NAME = 'DD_FIELDS_LOANTRANSACTION'";
				conn.ExecuteQuery();

				CheckBox CHK_DATA = (CheckBox) DGR_LOAN.Items[i].Cells[2].FindControl("CHK_LOAN." + DGR_LOAN.Items[i].Cells[0].Text.ToString());
				if(conn.GetRowCount() > 0)
				{
					CHK_DATA.Checked = true;
				}
				else
				{	
					CHK_DATA.Checked = false;
				}
			}
		}

		private void setUpeventhandlerCBLoan()
		{
			for (int i = 0; i < DGR_LOAN.Items.Count; i++)
			{
				/*** Button Process ***/
				CheckBox CHK_DATA = (CheckBox) DGR_LOAN.Items[i].Cells[2].FindControl("CHK_LOAN");
				if(CHK_DATA != null)
				{
					CHK_DATA.ID = "CHK_LOAN." + DGR_LOAN.Items[i].Cells[0].Text.ToString();
					CHK_DATA.CheckedChanged += new EventHandler(CB_STATUS_CheckedChangedLoan);
					CHK_DATA.AutoPostBack = true;
				}
			}
		}

		private void CB_STATUS_CheckedChangedLoan(object sender, EventArgs e)
		{
			CheckBox b = (CheckBox) sender;
			string idx = b.ID.Replace("CHK_LOAN.","");

			if(b.Checked == true)
			{
				conn.QueryString = "EXEC DD_INSERT_REQUESTED_FIELD_LIST '" + Request.QueryString["regno"] + "','" + Session["UserID"] + "','DD_FIELDS_LOANTRANSACTION','" + idx + "','INSERT'" ;
			}
			else
			{
				conn.QueryString = "EXEC DD_INSERT_REQUESTED_FIELD_LIST '" + Request.QueryString["regno"] + "','" + Session["UserID"] + "','DD_FIELDS_LOANTRANSACTION','" + idx + "','DELETE'" ;
			}
			conn.ExecuteQuery();
		}
		#endregion

		//2. SAVING & GIRO ACCOUNT
		protected void RDO_SAVING_GIRO_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			ViewDataSavingGiro();
		}

		private void DGR_SAVING_GIRO_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			DGR_SAVING_GIRO.CurrentPageIndex = e.NewPageIndex;
			ViewDataSavingGiro();
		}

		#region ViewDataSaving

		private void ViewDataSavingGiro()
		{
			BindData("DGR_SAVING_GIRO","SELECT * FROM DD_FIELDS_SAVINGGIROTRANSACTION");
			setUpeventhandlerCBSavingGiro();
			BindCBWithExistingDataSavingGiro();
		}

		private void BindCBWithExistingDataSavingGiro()
		{
			for (int i = 0; i < DGR_SAVING_GIRO.Items.Count; i++)
			{
				conn.QueryString = "SELECT * FROM DD_REQUESTED_FIELD_LIST WHERE AP_REGNO = '" + Request.QueryString["regno"] + "' AND FIELDSNAME = '" + DGR_SAVING_GIRO.Items[i].Cells[0].Text.ToString() + "' AND TABLE_NAME = 'DD_FIELDS_SAVINGGIROTRANSACTION'";
				conn.ExecuteQuery();

				CheckBox CHK_DATA = (CheckBox) DGR_SAVING_GIRO.Items[i].Cells[2].FindControl("CHK_SAVING_GIRO." + DGR_SAVING_GIRO.Items[i].Cells[0].Text.ToString());
				if(conn.GetRowCount() > 0)
				{
					CHK_DATA.Checked = true;
				}
				else
				{	
					CHK_DATA.Checked = false;
				}
			}
		}

		private void setUpeventhandlerCBSavingGiro()
		{
			for (int i = 0; i < DGR_SAVING_GIRO.Items.Count; i++)
			{
				/*** Button Process ***/
				CheckBox CHK_DATA = (CheckBox) DGR_SAVING_GIRO.Items[i].Cells[2].FindControl("CHK_SAVING_GIRO");
				if(CHK_DATA != null)
				{
					CHK_DATA.ID = "CHK_SAVING_GIRO." + DGR_SAVING_GIRO.Items[i].Cells[0].Text.ToString();
					CHK_DATA.CheckedChanged += new EventHandler(CB_STATUS_CheckedChangedSavingGiro);
					CHK_DATA.AutoPostBack = true;
				}
			}
		}

		private void CB_STATUS_CheckedChangedSavingGiro(object sender, EventArgs e)
		{
			CheckBox b = (CheckBox) sender;
			string idx = b.ID.Replace("CHK_SAVING_GIRO.","");

			if(b.Checked == true)
			{
				conn.QueryString = "EXEC DD_INSERT_REQUESTED_FIELD_LIST '" + Request.QueryString["regno"] + "','" + Session["UserID"] + "','DD_FIELDS_SAVINGGIROTRANSACTION','" + idx + "','INSERT'" ;
			}
			else
			{
				conn.QueryString = "EXEC DD_INSERT_REQUESTED_FIELD_LIST '" + Request.QueryString["regno"] + "','" + Session["UserID"] + "','DD_FIELDS_SAVINGGIROTRANSACTION','" + idx + "','DELETE'" ;
			}
			conn.ExecuteQuery();
		}
		#endregion

		//3. TIME DEPOSITE ACCOUNT
		protected void RDO_TIME_DEPOSIT_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			ViewTimeDeposit();
		}

		private void DGR_TIME_DEPOSIT_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			DGR_TIME_DEPOSIT.CurrentPageIndex = e.NewPageIndex;
			ViewTimeDeposit();
		}

		#region ViewTimeDeposit

		private void ViewTimeDeposit()
		{
			BindData("DGR_TIME_DEPOSIT","SELECT * FROM DD_FIELDS_TIMEDEPOSITTRANSACTION");
			setUpeventhandlerCBTimeDeposit();
			BindCBWithExistingDataTimeDeposit();
		}

		private void BindCBWithExistingDataTimeDeposit()
		{
			for (int i = 0; i < DGR_TIME_DEPOSIT.Items.Count; i++)
			{
				conn.QueryString = "SELECT * FROM DD_REQUESTED_FIELD_LIST WHERE AP_REGNO = '" + Request.QueryString["regno"] + "' AND FIELDSNAME = '" + DGR_TIME_DEPOSIT.Items[i].Cells[0].Text.ToString() + "' AND TABLE_NAME = 'DD_FIELDS_TIMEDEPOSITTRANSACTION'";
				conn.ExecuteQuery();

				CheckBox CHK_DATA = (CheckBox) DGR_TIME_DEPOSIT.Items[i].Cells[2].FindControl("CHK_TIMEDEPOSIT." + DGR_TIME_DEPOSIT.Items[i].Cells[0].Text.ToString());
				if(conn.GetRowCount() > 0)
				{
					
					CHK_DATA.Checked = true;
				}
				else
				{	
					CHK_DATA.Checked = false;
				}
			}
		}

		private void setUpeventhandlerCBTimeDeposit()
		{
			for (int i = 0; i < DGR_TIME_DEPOSIT.Items.Count; i++)
			{
				/*** Button Process ***/
				CheckBox CHK_DATA = (CheckBox) DGR_TIME_DEPOSIT.Items[i].Cells[2].FindControl("CHK_TIMEDEPOSIT");
				if(CHK_DATA != null)
				{
					CHK_DATA.ID = "CHK_TIMEDEPOSIT." + DGR_TIME_DEPOSIT.Items[i].Cells[0].Text.ToString();
					CHK_DATA.CheckedChanged += new EventHandler(CB_STATUS_CheckedChangedTimeDeposit);
					CHK_DATA.AutoPostBack = true;
				}
			}
		}

		private void CB_STATUS_CheckedChangedTimeDeposit(object sender, EventArgs e)
		{
			CheckBox b = (CheckBox) sender;
			string idx = b.ID.Replace("CHK_TIMEDEPOSIT.","");

			if(b.Checked == true)
			{
				conn.QueryString = "EXEC DD_INSERT_REQUESTED_FIELD_LIST '" + Request.QueryString["regno"] + "','" + Session["UserID"] + "','DD_FIELDS_TIMEDEPOSITTRANSACTION','" + idx + "','INSERT'" ;
			}
			else
			{
				conn.QueryString = "EXEC DD_INSERT_REQUESTED_FIELD_LIST '" + Request.QueryString["regno"] + "','" + Session["UserID"] + "','DD_FIELDS_TIMEDEPOSITTRANSACTION','" + idx + "','DELETE'" ;
			}
			conn.ExecuteQuery();
		}
		#endregion

		//4. TRADE
		protected void RDO_TRADE_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			ViewTrade();
		}

		private void DGR_TRADE_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			DGR_TRADE.CurrentPageIndex = e.NewPageIndex;
			ViewTrade();
		}

		#region ViewTrade

		private void ViewTrade()
		{
			BindData("DGR_TRADE","SELECT * FROM DD_FIELDS_TRADETRANSACTION");
			setUpeventhandlerCBTimeDeposit();
			BindCBWithExistingDataTimeDeposit();
		}

		private void BindCBWithExistingDataTradeTransaction()
		{
			for (int i = 0; i < DGR_TRADE.Items.Count; i++)
			{
				conn.QueryString = "SELECT * FROM DD_REQUESTED_FIELD_LIST WHERE AP_REGNO = '" + Request.QueryString["regno"] + "' AND FIELDSNAME = '" + DGR_TRADE.Items[i].Cells[0].Text.ToString() + "' AND TABLE_NAME = 'DD_FIELDS_TRADETRANSACTION'";
				conn.ExecuteQuery();

				CheckBox CHK_DATA = (CheckBox) DGR_TRADE.Items[i].Cells[2].FindControl("CHK_TRADETRANSACTION." + DGR_TRADE.Items[i].Cells[0].Text.ToString());
				if(conn.GetRowCount() > 0)
				{
					
					CHK_DATA.Checked = true;
				}
				else
				{	
					CHK_DATA.Checked = false;
				}
			}
		}

		private void setUpeventhandlerTradeTransaction()
		{
			for (int i = 0; i < DGR_TRADE.Items.Count; i++)
			{
				/*** Button Process ***/
				CheckBox CHK_DATA = (CheckBox) DGR_TRADE.Items[i].Cells[2].FindControl("CHK_TRADETRANSACTION");
				if(CHK_DATA != null)
				{
					CHK_DATA.ID = "CHK_TRADETRANSACTION." + DGR_TRADE.Items[i].Cells[0].Text.ToString();
					CHK_DATA.CheckedChanged += new EventHandler(CB_STATUS_CheckedChangedTradeTransaction);
					CHK_DATA.AutoPostBack = true;
				}
			}
		}

		private void CB_STATUS_CheckedChangedTradeTransaction(object sender, EventArgs e)
		{
			CheckBox b = (CheckBox) sender;
			string idx = b.ID.Replace("CHK_TRADETRANSACTION.","");

			if(b.Checked == true)
			{
				conn.QueryString = "EXEC DD_INSERT_REQUESTED_FIELD_LIST '" + Request.QueryString["regno"] + "','" + Session["UserID"] + "','DD_FIELDS_TRADETRANSACTION','" + idx + "','INSERT'" ;
			}
			else
			{
				conn.QueryString = "EXEC DD_INSERT_REQUESTED_FIELD_LIST '" + Request.QueryString["regno"] + "','" + Session["UserID"] + "','DD_FIELDS_TRADETRANSACTION','" + idx + "','DELETE'" ;
			}
			conn.ExecuteQuery();
		}
		#endregion

		//5. TREASURY
		protected void RDO_TREASURY_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			ViewTreasury();
		}

		private void DGR_TREASURY_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			DGR_TREASURY.CurrentPageIndex = e.NewPageIndex;
			ViewTreasury();
		}

		#region ViewTreasury

		private void ViewTreasury()
		{
			BindData("DGR_TREASURY","SELECT * FROM DD_FIELDS_TREASURYTRANSACTION");
			setUpeventhandlerCBTreasury();
			BindCBWithExistingDataTreasury();
		}

		private void BindCBWithExistingDataTreasury()
		{
			for (int i = 0; i < DGR_TREASURY.Items.Count; i++)
			{
				conn.QueryString = "SELECT * FROM DD_REQUESTED_FIELD_LIST WHERE AP_REGNO = '" + Request.QueryString["regno"] + "' AND FIELDSNAME = '" + DGR_TREASURY.Items[i].Cells[0].Text.ToString() + "' AND TABLE_NAME = 'DD_FIELDS_TREASURYTRANSACTION'";
				conn.ExecuteQuery();

				CheckBox CHK_DATA = (CheckBox) DGR_TREASURY.Items[i].Cells[2].FindControl("CHK_TREASURY." + DGR_TREASURY.Items[i].Cells[0].Text.ToString());
				if(conn.GetRowCount() > 0)
				{
					
					CHK_DATA.Checked = true;
				}
				else
				{	
					CHK_DATA.Checked = false;
				}
			}
		}

		private void setUpeventhandlerCBTreasury()
		{
			for (int i = 0; i < DGR_TREASURY.Items.Count; i++)
			{
				/*** Button Process ***/
				CheckBox CHK_DATA = (CheckBox) DGR_TREASURY.Items[i].Cells[2].FindControl("CHK_TREASURY");
				if(CHK_DATA != null)
				{
					CHK_DATA.ID = "CHK_TREASURY." + DGR_TREASURY.Items[i].Cells[0].Text.ToString();
					CHK_DATA.CheckedChanged += new EventHandler(CB_STATUS_CheckedChangedTreasury);
					CHK_DATA.AutoPostBack = true;
				}
			}
		}

		private void CB_STATUS_CheckedChangedTreasury(object sender, EventArgs e)
		{
			CheckBox b = (CheckBox) sender;
			string idx = b.ID.Replace("CHK_TREASURY.","");

			if(b.Checked == true)
			{
				conn.QueryString = "EXEC DD_INSERT_REQUESTED_FIELD_LIST '" + Request.QueryString["regno"] + "','" + Session["UserID"] + "','DD_FIELDS_TREASURYTRANSACTION','" + idx + "','INSERT'" ;
			}
			else
			{
				conn.QueryString = "EXEC DD_INSERT_REQUESTED_FIELD_LIST '" + Request.QueryString["regno"] + "','" + Session["UserID"] + "','DD_FIELDS_TREASURYTRANSACTION','" + idx + "','DELETE'" ;
			}
			conn.ExecuteQuery();
		}
		#endregion

		private void BindData(string dataGridName, string strconn)
		{
			if(strconn != "")
			{
				conn.QueryString = strconn;
				conn.ExecuteQuery();

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
		}
	}
}
