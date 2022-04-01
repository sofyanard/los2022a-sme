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
	/// Summary description for ApprDataRequestList.
	/// </summary>
	public partial class ApprDataRequestList : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.ImageButton BTN_BACK;
		protected Tools tools = new Tools();
		protected Connection conn = new Connection(ConfigurationSettings.AppSettings["conn"]);
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			if(!IsPostBack)
			{
				FillDataGrid();
			}
		}

		private void FillDataGrid()
		{
			conn.QueryString = "SELECT * FROM VW_DD_APPROVAL_INITIATION_LIST WHERE REQ_APPROVER = '" + Session["UserID"] + "'";
			conn.ExecuteQuery();

			System.Data.DataTable dt = new System.Data.DataTable();
			dt = conn.GetDataTable().Copy();

			DGR_REQUESTLIST.DataSource = dt;
			try
			{
				DGR_REQUESTLIST.DataBind();
			}
			catch
			{
				DGR_REQUESTLIST.CurrentPageIndex = 0;
				DGR_REQUESTLIST.DataBind();
			}
			for (int i = 0; i < DGR_REQUESTLIST.Items.Count; i++)
			{
				DGR_REQUESTLIST.Items[i].Cells[2].Text = tools.FormatDate(DGR_REQUESTLIST.Items[i].Cells[2].Text, true);
			}
			BindDataRadioButtonList();
		}

		private void BindDataRadioButtonList()
		{
			for(int i=0; i<DGR_REQUESTLIST.Items.Count; i++)
			{
				try
				{
					RadioButton rbA = (RadioButton) DGR_REQUESTLIST.Items[i].FindControl("RDO_APPROVE"),
								rbP = (RadioButton) DGR_REQUESTLIST.Items[i].FindControl("RDO_PENDING"),
								rbR = (RadioButton) DGR_REQUESTLIST.Items[i].FindControl("RDO_REJECT");

					conn.QueryString = "SELECT * FROM VW_DD_APPROVAL_INITIATION_LIST WHERE REQ_NUMBER = '" + DGR_REQUESTLIST.Items[i].Cells[1].Text.Trim() + "'";
					conn.ExecuteQuery();

					switch(conn.GetFieldValue("REQ_APPROVAL").ToString())
					{
						case "0":
							rbP.Checked = true;
							break;
						case "1":
							rbA.Checked = true;
							break;
						case "2":
							rbR.Checked = true;
							break;
					}
				}
				catch{}
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
			this.DGR_REQUESTLIST.ItemCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.DGR_REQUESTLIST_ItemCommand);
			this.DGR_REQUESTLIST.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.DGR_REQUESTLIST_PageIndexChanged);

		}
		#endregion

		private void DGR_REQUESTLIST_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			DGR_REQUESTLIST.CurrentPageIndex = e.NewPageIndex;
			FillDataGrid();
		}

		private void DGR_REQUESTLIST_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			switch(((LinkButton)e.CommandSource).CommandName)
			{
				case "view":
					Response.Redirect("DataInitMain.aspx?sta=exist&mc=" + Request.QueryString["mc"] + "&regno=" + e.Item.Cells[1].Text + "&exist=1");
					break;
			}
		}

		protected void BTN_SUB_Click(object sender, System.EventArgs e)
		{
			RD0Button();
		}

		private void RD0Button()
		{
			for(int i=0; i<DGR_REQUESTLIST.Items.Count; i++)
			{
				try
				{
					RadioButton rbA = (RadioButton) DGR_REQUESTLIST.Items[i].FindControl("RDO_APPROVE"),
								rbP = (RadioButton) DGR_REQUESTLIST.Items[i].FindControl("RDO_PENDING"),
								rbR = (RadioButton) DGR_REQUESTLIST.Items[i].FindControl("RDO_REJECT");
					if(rbA.Checked)
					{
						performRequest(i, "1");
					}
					else if(rbP.Checked)
					{
						performRequest(i, "0");
					}
					else if(rbR.Checked)
					{
						performRequest(i, "2");
					}
				}
				catch{}
			}
			FillDataGrid();
		}

		private void performRequest(int row, string flag)
		{
			try
			{
				string req = DGR_REQUESTLIST.Items[row].Cells[1].Text.Trim();

				conn.QueryString = "UPDATE DD_DATA_REQUEST SET REQ_APPROVAL = '" + flag + "' WHERE REQ_NUMBER = '" + req + "'";
				conn.ExecuteQuery();
			}
			catch{}
		}

		protected void BTN_UPDATE_Click(object sender, System.EventArgs e)
		{
			RD0ButtonTrack();
		}

		private void RD0ButtonTrack()
		{
			for(int i=0; i<DGR_REQUESTLIST.Items.Count; i++)
			{
				try
				{
					RadioButton rbA = (RadioButton) DGR_REQUESTLIST.Items[i].FindControl("RDO_APPROVE"),
								rbR = (RadioButton) DGR_REQUESTLIST.Items[i].FindControl("RDO_REJECT");
					if(rbA.Checked)
					{
						performRequestTrack(i);
					}
					else if(rbR.Checked)
					{
						rejectDataTrack(i);
					}
				}
				catch{}
			}
			FillDataGrid();
		}

		private void performRequestTrack(int row)
		{
			try
			{
				string req = DGR_REQUESTLIST.Items[row].Cells[1].Text.Trim();

				try
				{
					conn.QueryString = "EXEC DD_TRACKUPDATE '0','" +
										Session["UserID"].ToString() + "','" +
										req + "'";
					conn.ExecuteQuery();

					conn.QueryString = "UPDATE DD_DATA_REQUEST SET REQ_APPROVAL = '0' WHERE REQ_NUMBER = '" + req + "'";
					conn.ExecuteQuery();
				}
				catch(Exception ex)
				{
					string errmsg = ex.Message.Replace("'","");
					if (errmsg.IndexOf("Last Query:") > 0)
						errmsg = errmsg.Substring(0, errmsg.IndexOf("Last Query:"));
					GlobalTools.popMessage(this, errmsg);
					return;
				}
			}
			catch{}
		}

		private void rejectDataTrack(int row)
		{
			try
			{
				string req = DGR_REQUESTLIST.Items[row].Cells[1].Text.Trim();

				try
				{
					conn.QueryString = "EXEC DD_TRACKUPDATE '2','" +
										Session["UserID"].ToString() + "','" +
										req + "'";
					conn.ExecuteQuery();

					conn.QueryString = "UPDATE DD_DATA_REQUEST SET REQ_APPROVAL = '0' WHERE REQ_NUMBER = '" + req + "'";
					conn.ExecuteQuery();
				}
				catch(Exception ex)
				{
					string errmsg = ex.Message.Replace("'","");
					if (errmsg.IndexOf("Last Query:") > 0)
						errmsg = errmsg.Substring(0, errmsg.IndexOf("Last Query:"));
					GlobalTools.popMessage(this, errmsg);
					return;
				}
			}
			catch{}
		}
	}
}
