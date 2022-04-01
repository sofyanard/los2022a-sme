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
	/// Summary description for LoanListDataApprovalBU.
	/// </summary>
	public partial class LoanListDataApprovalBU : System.Web.UI.Page
	{
		protected Connection conn2 = new Connection(ConfigurationSettings.AppSettings["conn2"]);
		protected Connection conn = new Connection(ConfigurationSettings.AppSettings["conn"]);
		protected Tools tools = new Tools();
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			if(!IsPostBack)
			{
				if(Request.QueryString["msg"]!="" && Request.QueryString["msg"] != null)
				{
					GlobalTools.popMessage(this, Request.QueryString["msg"]);
				}

				FillLoanBUAppr();
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
			this.DGR_LOANBU_APPR.ItemCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.DGR_LOANBU_APPR_ItemCommand);
			this.DGR_LOANBU_APPR.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.DGR_LOANBU_APPR_PageIndexChanged);

		}
		#endregion

		private void FillLoanBUAppr()
		{
			conn2.QueryString = "select * from VW_LOANBU_DATA_APPR order by nama";
			conn2.ExecuteQuery();

			System.Data.DataTable dt = new System.Data.DataTable();
			dt = conn2.GetDataTable().Copy();

			DGR_LOANBU_APPR.DataSource = dt;
			try
			{
				DGR_LOANBU_APPR.DataBind();
			}
			catch
			{
				DGR_LOANBU_APPR.CurrentPageIndex = 0;
				DGR_LOANBU_APPR.DataBind();
			}
		}

		private void DGR_LOANBU_APPR_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			int i;
			switch(((LinkButton)e.CommandSource).CommandName)
			{
				case "allAccept":
					for (i = 0; i < DGR_LOANBU_APPR.PageSize; i++)
					{
						try
						{
							RadioButton rbA = (RadioButton) DGR_LOANBU_APPR.Items[i].FindControl("RDO_ACCEPT"),
								rbB = (RadioButton) DGR_LOANBU_APPR.Items[i].FindControl("RDO_PENDING"),
								rbC = (RadioButton) DGR_LOANBU_APPR.Items[i].FindControl("RDO_REJECT");
							rbA.Checked = true;
							rbB.Checked = false;
							rbC.Checked = false;
						} 
						catch {}
					}
					break;
				case "allPend":
					for (i = 0; i < DGR_LOANBU_APPR.PageSize; i++)
					{
						try
						{
							RadioButton rbA = (RadioButton) DGR_LOANBU_APPR.Items[i].FindControl("RDO_ACCEPT"),
								rbB = (RadioButton) DGR_LOANBU_APPR.Items[i].FindControl("RDO_PENDING"),
								rbC = (RadioButton) DGR_LOANBU_APPR.Items[i].FindControl("RDO_REJECT");
							rbA.Checked = false;
							rbB.Checked = true;
							rbC.Checked = false;
						} 
						catch {}
					}
					break;
				case "allReject":
					for (i = 0; i < DGR_LOANBU_APPR.PageSize; i++)
					{
						try
						{
							RadioButton rbA = (RadioButton) DGR_LOANBU_APPR.Items[i].FindControl("RDO_ACCEPT"),
								rbB = (RadioButton) DGR_LOANBU_APPR.Items[i].FindControl("RDO_PENDING"),
								rbC = (RadioButton) DGR_LOANBU_APPR.Items[i].FindControl("RDO_REJECT");
							rbA.Checked = false;
							rbB.Checked = false;
							rbC.Checked = true;
						} 
						catch {}
					}
					break;
				case "View":
					Response.Redirect("LoanDetailDataBU.aspx?acc=" + e.Item.Cells[0].Text + "&from_appr=1");
					break;
				default:
					// Do nothing.
					break;
			}
		}

		private void DGR_LOANBU_APPR_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			DGR_LOANBU_APPR.CurrentPageIndex = e.NewPageIndex;
			FillLoanBUAppr();
		}

		protected void BTN_SAVE_Click(object sender, System.EventArgs e)
		{
			for (int i = 0; i < DGR_LOANBU_APPR.Items.Count; i++)
			{
				try	
				{
					RadioButton rbA = (RadioButton) DGR_LOANBU_APPR.Items[i].FindControl("RDO_ACCEPT"),
						rbR = (RadioButton) DGR_LOANBU_APPR.Items[i].FindControl("RDO_REJECT");
					if (rbA.Checked)
					{
						performRequest(i);
					}
					else if (rbR.Checked)
					{
						deleteData(i);
					}
				} 
				catch {}
			}
			FillLoanBUAppr();
		}

		private void deleteData(int row)
		{
			try 
			{
				string accno = DGR_LOANBU_APPR.Items[row].Cells[0].Text.Trim();

				conn2.QueryString = "exec DQM_LOAN_BU_INSERT2 '" + 
					accno + "', '0'";
				conn2.ExecuteQuery();
			} 
			catch {}
		}

		private void performRequest(int row)
		{
			try 
			{
				string accno = DGR_LOANBU_APPR.Items[row].Cells[0].Text.Trim();

				conn2.QueryString = "exec DQM_LOAN_BU_INSERT2 '" + 
					accno + "', '1'";
				conn2.ExecuteQuery();
			} 
			catch {}
		}
	}
}
