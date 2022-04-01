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

namespace SME.DCM.DataDictionary.Facilities.AssignmentAnalysisDataRequested
{
	/// <summary>
	/// Summary description for AssignmentProcess.
	/// </summary>
	public partial class AssignmentProcess : System.Web.UI.Page
	{
		protected Tools tools = new Tools();
		protected Connection conn = new Connection(ConfigurationSettings.AppSettings["conn"]);
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			if(!IsPostBack)
			{
				FillDDLPicReq();
				FillDDLPicDso();
				FillDDLApprReq();
				FillDDLApprDso();

				ViewData();
			}
		}

		private void FillDDLPicReq()
		{
			DDL_PIC_REQ.Items.Clear();
			DDL_PIC_REQ.Items.Add(new ListItem("--Select--", ""));

			conn.QueryString = "SELECT * FROM VW_SDC_FACILITIES_ASSIGN_PIC_REQUEST_LIST";
			conn.ExecuteQuery();
			for(int i=0; i < conn.GetRowCount(); i++)
			{
				DDL_PIC_REQ.Items.Add(new ListItem(conn.GetFieldValue(i,1), conn.GetFieldValue(i,0)));
			}
		}

		private void FillDDLPicDso()
		{
			DDL_PIC_DSO.Items.Clear();
			DDL_PIC_DSO.Items.Add(new ListItem("--Select--", ""));

			conn.QueryString = "SELECT * FROM VW_SDC_FACILITIES_ASSIGN_PIC_DSO_LIST";
			conn.ExecuteQuery();
			for(int i=0; i < conn.GetRowCount(); i++)
			{
				DDL_PIC_DSO.Items.Add(new ListItem(conn.GetFieldValue(i,1), conn.GetFieldValue(i,0)));
			}
		}

		private void FillDDLApprReq()
		{
			DDL_APPR_REQ.Items.Clear();
			DDL_APPR_REQ.Items.Add(new ListItem("--Select--", ""));

			conn.QueryString = "SELECT * FROM VW_SDC_FACILITIES_APPROVAL_PIC_REQUEST_LIST";
			conn.ExecuteQuery();
			for(int i=0; i < conn.GetRowCount(); i++)
			{
				DDL_APPR_REQ.Items.Add(new ListItem(conn.GetFieldValue(i,1), conn.GetFieldValue(i,0)));
			}
		}

		private void FillDDLApprDso()
		{
			DDL_APPR_DSO.Items.Clear();
			DDL_APPR_DSO.Items.Add(new ListItem("--Select--", ""));

			conn.QueryString = "SELECT * FROM VW_SDC_FACILITIES_APPROVAL_PIC_DSO_LIST";
			conn.ExecuteQuery();
			for(int i=0; i < conn.GetRowCount(); i++)
			{
				DDL_APPR_DSO.Items.Add(new ListItem(conn.GetFieldValue(i,1), conn.GetFieldValue(i,0)));
			}
		}

		private void ViewData()
		{
			conn.QueryString = "SELECT * FROM VW_SDC_FACILITIES_ASSIGNMENT_PROCESS WHERE REQ_NUMBER = '" + Request.QueryString["regno"] + "'";
			conn.ExecuteQuery();

			LBL_SEQ.Text		= conn.GetFieldValue("SEQ").ToString();
			TXT_REQ.Text		= conn.GetFieldValue("REQ_NUMBER").ToString();
			TXT_CURRTRACK.Text	= conn.GetFieldValue("TRACK_ID").ToString();
			TXT_TRACK_BY.Text	= conn.GetFieldValue("TRACK_BY").ToString();

			DDL_PIC_REQ.SelectedValue = conn.GetFieldValue("REQ_PIC").ToString();
			DDL_PIC_DSO.SelectedValue = conn.GetFieldValue("DSO_PIC").ToString();
			DDL_APPR_REQ.SelectedValue = conn.GetFieldValue("REQ_APPROVER").ToString();
			DDL_APPR_DSO.SelectedValue = conn.GetFieldValue("DSO_APPROVER").ToString();
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

		}
		#endregion

		protected void BTN_ASSIGN_Click(object sender, System.EventArgs e)
		{
			try
			{
				conn.QueryString = "EXEC SDC_FACILITIES_ASSIGN_PROCESS '" +
									TXT_REQ.Text + "','" +
									DDL_PIC_REQ.SelectedValue + "','" +
									DDL_PIC_DSO.SelectedValue + "','" +
									DDL_APPR_REQ.SelectedValue + "','" +
									DDL_APPR_DSO.SelectedValue + "'";
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

		protected void BTN_BACK_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			Response.Redirect("AssignmentList.aspx?mc=" + Request.QueryString["mc"]);
		}
	}
}
