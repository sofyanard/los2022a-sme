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
	/// Summary description for BUCDanaAppr.
	/// </summary>
	public partial class BUCDanaAppr : System.Web.UI.Page
	{
		protected Connection conn2 = new Connection(ConfigurationSettings.AppSettings["conn2"]);
		protected Connection conn = new Connection(ConfigurationSettings.AppSettings["conn"]);
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			if(!IsPostBack)
			{
				FillInvalidData();
				FillGridCheckingData();
			}
		}

		private void FillInvalidData()
		{
			conn2.QueryString = "select * from dc_buc_dana where flag='1' and source='I' order by cifno";
			conn2.ExecuteQuery();

			System.Data.DataTable dt = new System.Data.DataTable();
			dt = conn2.GetDataTable().Copy();

			DGR_INVALID_DATA.DataSource = dt;
			try
			{
				DGR_INVALID_DATA.DataBind();
			}
			catch
			{
				DGR_INVALID_DATA.CurrentPageIndex = 0;
				DGR_INVALID_DATA.DataBind();
			}

			//TXT_TGL_DATA_INVALID.Text = tools.FormatDate(conn2.GetFieldValue("TGL_DATA"));

			DropDownList ddl;

			for (int i=0; i < DGR_INVALID_DATA.Items.Count; i++)
			{
				ddl = (DropDownList) DGR_INVALID_DATA.Items[i].FindControl("DDL_UPDATE_DATA_INVALID");
				ddl.Items.Add(new ListItem("--Pilih--",""));
				
				
				conn2.QueryString = "select distinct buc from buc_dana";
				conn2.ExecuteQuery(10000);

				for(int j=0; j < conn2.GetRowCount(); j++)
					ddl.Items.Add(new ListItem(conn2.GetFieldValue(j,0), conn2.GetFieldValue(j,0)));

				conn2.QueryString = "select * from dc_buc_dana where cifno='" + DGR_INVALID_DATA.Items[i].Cells[2].Text + "' and acctno='" + DGR_INVALID_DATA.Items[i].Cells[1].Text + "'";
				conn2.ExecuteQuery();

				if(conn2.GetRowCount() > 0)
				{
					ddl.SelectedValue = conn2.GetFieldValue("BUC_UPDATE");

					if(conn2.GetFieldValue("FLAG")!= "0")
						ddl.Enabled = false;
				}
			}
		}

		private void FillGridCheckingData()
		{
			conn2.QueryString = "select * from dc_buc_dana where flag='1' and source='C' order by cifno";
			conn2.ExecuteQuery();

			System.Data.DataTable dt = new System.Data.DataTable();
			dt = conn2.GetDataTable().Copy();

			DGR_CHECKING_DATA.DataSource = dt;
			try
			{
				DGR_CHECKING_DATA.DataBind();
			}
			catch
			{
				DGR_CHECKING_DATA.CurrentPageIndex = 0;
				DGR_CHECKING_DATA.DataBind();
			}

			//TXT_TGL_DATA_CHECKING.Text = tools.FormatDate(conn2.GetFieldValue("TGL_DATA"));

			DropDownList ddl;

			for (int i=0; i < DGR_CHECKING_DATA.Items.Count; i++)
			{
				ddl = (DropDownList) DGR_CHECKING_DATA.Items[i].FindControl("DDL_UPDATE_DATA_CHECK");
				ddl.Items.Add(new ListItem("--Pilih--",""));
				
				conn2.QueryString = "select distinct buc from buc_dana";
				conn2.ExecuteQuery(10000);

				for(int j=0; j < conn2.GetRowCount(); j++)
					ddl.Items.Add(new ListItem(conn2.GetFieldValue(j,0), conn2.GetFieldValue(j,0)));
		
				conn2.QueryString = "select * from dc_buc_dana where cifno='" + DGR_CHECKING_DATA.Items[i].Cells[2].Text + "' and acctno='" + DGR_CHECKING_DATA.Items[i].Cells[1].Text + "'";
				conn2.ExecuteQuery();

				if(conn2.GetRowCount() > 0)
				{
					ddl.SelectedValue = conn2.GetFieldValue("BUC_UPDATE");

					if(conn2.GetFieldValue("FLAG")!= "0")
						ddl.Enabled = false;
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
			this.DGR_INVALID_DATA.ItemCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.DGR_INVALID_DATA_ItemCommand);
			this.DGR_INVALID_DATA.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.DGR_INVALID_DATA_PageIndexChanged);
			this.DGR_CHECKING_DATA.ItemCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.DGR_CHECKING_DATA_ItemCommand);
			this.DGR_CHECKING_DATA.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.DGR_CHECKING_DATA_PageIndexChanged);

		}
		#endregion

		protected void BTN_SUBMIT_INVALID_DATA_Click(object sender, System.EventArgs e)
		{
			for (int i = 0; i < DGR_INVALID_DATA.Items.Count; i++)
			{
				try	
				{
					RadioButton rbA = (RadioButton) DGR_INVALID_DATA.Items[i].FindControl("RDO_ACCEPT_INVALID_DATA"),
						rbR = (RadioButton) DGR_INVALID_DATA.Items[i].FindControl("RDO_REJECT_INVALID_DATA");
					if (rbA.Checked)
					{
						performRequest(i, "invalid");
					}
					else if (rbR.Checked)
					{
						deleteData(i, "invalid");
					}
				} 
				catch {}
			}
			FillInvalidData();
		}

		protected void BTN_UPDATE_INVALID_DATA_Click(object sender, System.EventArgs e)
		{
		
		}

		private void deleteData(int row, string source)
		{
			if (source == "invalid")
			{
				try 
				{
					string cifno = DGR_INVALID_DATA.Items[row].Cells[2].Text.Trim();
					string acctno = DGR_INVALID_DATA.Items[row].Cells[1].Text.Trim();

					conn2.QueryString = "exec DC_BUC_DANA_INSERT '', '" + 
						acctno + "', '" + cifno + "', '', '', '', '', '', '', '', '4', ''";
					conn2.ExecuteQuery();
				} 
				catch {}
			}
			else if (source == "check")
			{
				try 
				{
					string cifno = DGR_CHECKING_DATA.Items[row].Cells[2].Text.Trim();
					string acctno = DGR_CHECKING_DATA.Items[row].Cells[1].Text.Trim();

					conn2.QueryString = "exec DC_BUC_DANA_INSERT '', '" + 
						acctno + "', '" + cifno + "', '', '', '', '', '', '', '', '4', ''";
					conn2.ExecuteQuery();
				} 
				catch {}
			}
		}

		private void performRequest(int row, string source)
		{
			if(source == "invalid")
			{
				try 
				{
					string cifno = DGR_INVALID_DATA.Items[row].Cells[2].Text.Trim();
					string acctno = DGR_INVALID_DATA.Items[row].Cells[1].Text.Trim();

					conn2.QueryString = "exec DC_BUC_DANA_INSERT '', '" + 
						acctno + "', '" + cifno + "', '', '', '', '', '', '', '', '3', ''";
					conn2.ExecuteQuery();
				} 
				catch {}
			}
			else if(source == "check")
			{
				try 
				{
					string cifno = DGR_CHECKING_DATA.Items[row].Cells[2].Text.Trim();
					string acctno = DGR_CHECKING_DATA.Items[row].Cells[1].Text.Trim();

					conn2.QueryString = "exec DC_BUC_DANA_INSERT '', '" + 
						acctno + "', '" + cifno + "', '', '', '', '', '', '', '', '3', ''";
					conn2.ExecuteQuery();
				} 
				catch {}
			}
		}

		protected void BTN_SUBMIT_CHECK_DATA_Click(object sender, System.EventArgs e)
		{
			for (int i = 0; i < DGR_CHECKING_DATA.Items.Count; i++)
			{
				try	
				{
					RadioButton rbA = (RadioButton) DGR_CHECKING_DATA.Items[i].FindControl("RDO_ACCEPT_CHECK_DATA"),
						rbR = (RadioButton) DGR_CHECKING_DATA.Items[i].FindControl("RDO_REJECT_CHECK_DATA");
					if (rbA.Checked)
					{
						performRequest(i, "check");
					}
					else if (rbR.Checked)
					{
						deleteData(i, "check");
					}
				} 
				catch {}
			}
			FillGridCheckingData();
		}

		protected void BTN_UPDATE_CHECK_DATA_Click(object sender, System.EventArgs e)
		{
		
		}

		private void DGR_INVALID_DATA_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			int i;
			switch(((LinkButton)e.CommandSource).CommandName)
			{
				case "allAccept":
					for (i = 0; i < DGR_INVALID_DATA.PageSize; i++)
					{
						try
						{
							RadioButton rbA = (RadioButton) DGR_INVALID_DATA.Items[i].FindControl("RDO_ACCEPT_INVALID_DATA"),
								rbB = (RadioButton) DGR_INVALID_DATA.Items[i].FindControl("RDO_PENDING_INVALID_DATA"),
								rbC = (RadioButton) DGR_INVALID_DATA.Items[i].FindControl("RDO_REJECT_INVALID_DATA");
							rbA.Checked = true;
							rbB.Checked = false;
							rbC.Checked = false;
						} 
						catch {}
					}
					break;
				case "allPend":
					for (i = 0; i < DGR_INVALID_DATA.PageSize; i++)
					{
						try
						{
							RadioButton rbA = (RadioButton) DGR_INVALID_DATA.Items[i].FindControl("RDO_ACCEPT_INVALID_DATA"),
								rbB = (RadioButton) DGR_INVALID_DATA.Items[i].FindControl("RDO_PENDING_INVALID_DATA"),
								rbC = (RadioButton) DGR_INVALID_DATA.Items[i].FindControl("RDO_REJECT_INVALID_DATA");
							rbA.Checked = false;
							rbB.Checked = true;
							rbC.Checked = false;
						} 
						catch {}
					}
					break;
				case "allReject":
					for (i = 0; i < DGR_INVALID_DATA.PageSize; i++)
					{
						try
						{
							RadioButton rbA = (RadioButton) DGR_INVALID_DATA.Items[i].FindControl("RDO_ACCEPT_INVALID_DATA"),
								rbB = (RadioButton) DGR_INVALID_DATA.Items[i].FindControl("RDO_PENDING_INVALID_DATA"),
								rbC = (RadioButton) DGR_INVALID_DATA.Items[i].FindControl("RDO_REJECT_INVALID_DATA");
							rbA.Checked = false;
							rbB.Checked = false;
							rbC.Checked = true;
						} 
						catch {}
					}
					break;
				default:
					// Do nothing.
					break;
			}
		}

		private void DGR_INVALID_DATA_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			DGR_INVALID_DATA.CurrentPageIndex = e.NewPageIndex;
			FillInvalidData();
		}

		private void DGR_CHECKING_DATA_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			int i;
			switch(((LinkButton)e.CommandSource).CommandName)
			{
				case "allAccept":
					for (i = 0; i < DGR_CHECKING_DATA.PageSize; i++)
					{
						try
						{
							RadioButton rbA = (RadioButton) DGR_CHECKING_DATA.Items[i].FindControl("RDO_ACCEPT_CHECK_DATA"),
								rbB = (RadioButton) DGR_CHECKING_DATA.Items[i].FindControl("RDO_PENDING_CHECK_DATA"),
								rbC = (RadioButton) DGR_CHECKING_DATA.Items[i].FindControl("RDO_REJECT_CHECK_DATA");
							rbA.Checked = true;
							rbB.Checked = false;
							rbC.Checked = false;
						} 
						catch {}
					}
					break;
				case "allPend":
					for (i = 0; i < DGR_CHECKING_DATA.PageSize; i++)
					{
						try
						{
							RadioButton rbA = (RadioButton) DGR_CHECKING_DATA.Items[i].FindControl("RDO_ACCEPT_CHECK_DATA"),
								rbB = (RadioButton) DGR_CHECKING_DATA.Items[i].FindControl("RDO_PENDING_CHECK_DATA"),
								rbC = (RadioButton) DGR_CHECKING_DATA.Items[i].FindControl("RDO_REJECT_CHECK_DATA");
							rbA.Checked = false;
							rbB.Checked = true;
							rbC.Checked = false;
						} 
						catch {}
					}
					break;
				case "allReject":
					for (i = 0; i < DGR_CHECKING_DATA.PageSize; i++)
					{
						try
						{
							RadioButton rbA = (RadioButton) DGR_CHECKING_DATA.Items[i].FindControl("RDO_ACCEPT_CHECK_DATA"),
								rbB = (RadioButton) DGR_CHECKING_DATA.Items[i].FindControl("RDO_PENDING_CHECK_DATA"),
								rbC = (RadioButton) DGR_CHECKING_DATA.Items[i].FindControl("RDO_REJECT_CHECK_DATA");
							rbA.Checked = false;
							rbB.Checked = false;
							rbC.Checked = true;
						} 
						catch {}
					}
					break;
				default:
					// Do nothing.
					break;
			}
		}

		private void DGR_CHECKING_DATA_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			DGR_CHECKING_DATA.CurrentPageIndex = e.NewPageIndex;
			FillGridCheckingData();
		}

		
	}
}
