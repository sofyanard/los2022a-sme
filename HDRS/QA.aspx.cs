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
using DMS.BlackList;
using Microsoft.VisualBasic;
using System.IO;
using System.Diagnostics;

namespace SME.HDRS
{
	/// <summary>
	/// Summary description for QA.
	/// </summary>
	public partial class QA : System.Web.UI.Page
	{
		protected Connection conn;
		protected Connection conn2;
		protected Connection conn3;
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			conn = (Connection) Session["Connection"];
			conn2 = (Connection) Session["Connection"];


			if (!Logic.AllowAccess(Session["GroupID"].ToString(), Request.QueryString["mc"], conn))
				Response.Redirect("/SME/Restricted.aspx");

			if (!IsPostBack)
			{
				DDL_PROBLEM.Items.Add(new ListItem("--Pilih--",""));
				conn.QueryString="select * from rfproblem where active='1'";
				conn.ExecuteQuery();
				for (int i = 0; i < conn.GetRowCount(); i++)
					DDL_PROBLEM.Items.Add(new ListItem(conn.GetFieldValue(i,1), conn.GetFieldValue(i,0)));

				conn.QueryString = "select * from helpdesk where active='1' ";
				conn.ExecuteQuery();
				FillGrid();
			}
		}

		private void FillGrid()
		{				
			System.Data.DataTable dt = new System.Data.DataTable();
			dt = conn.GetDataTable().Copy();
			DATA_EXPORT.DataSource = dt;
			try 
			{
				DATA_EXPORT.DataBind();
			} 
			catch 
			{
				DATA_EXPORT.CurrentPageIndex = 0;
				DATA_EXPORT.DataBind();
			}				

			for (int i = 1; i <= DATA_EXPORT.Items.Count; i++)
			{
				HyperLink HpDownload2 = (HyperLink) DATA_EXPORT.Items[i-1].Cells[5].FindControl("UPL_DOWNLOAD_ANSWER");				
				HpDownload2.NavigateUrl = "/SME/HelpdeskUpload/" + conn.GetFieldValue("H_RESPON_FILE_EXPORT");	
				HyperLink HpDownload = (HyperLink) DATA_EXPORT.Items[i-1].Cells[2].FindControl("UPL_DOWNLOAD_QUESTION");				
				HpDownload.NavigateUrl = "/SME/HelpdeskUpload/" + conn.GetFieldValue("H_PROBLEM_FILE_EXPORT");				
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
			this.DATA_EXPORT.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.DATA_EXPORT_PageIndexChanged);

		}
		#endregion

		protected void BTN_FIND_Click(object sender, System.EventArgs e)
		{
			DATA_EXPORT.CurrentPageIndex = 0;
			SearchData();
		}

		private void SearchData()
		{
			//conn.QueryString = "select * from helpdesk where active='1' and H_PROBLEM_TYPE='"+ DDL_PROBLEM.SelectedValue +"' ";
			//conn.ExecuteQuery();
			string prob;
			prob=DDL_PROBLEM.SelectedValue;
			if (prob=="")
			{
				conn.QueryString = " select * from helpdesk where active='1'";
				conn.ExecuteQuery();
			}
			if (prob!="")
			{
				conn.QueryString = "select * from helpdesk where active='1' and H_PROBLEM_TYPE='"+ prob +"' ";
				conn.ExecuteQuery();
			}
			FillGrid();
		}

		private void DATA_EXPORT_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			DATA_EXPORT.CurrentPageIndex = e.NewPageIndex;
			string prob;
			prob=DDL_PROBLEM.SelectedValue;
			if (prob=="")
			{
				conn.QueryString = " select * from helpdesk where active='1'";
				conn.ExecuteQuery();
			}
			if (prob!="")
			{
				conn.QueryString = "select * from helpdesk where active='1' and H_PROBLEM_TYPE='"+ prob +"' ";
				conn.ExecuteQuery();
			}
			FillGrid();
		}

		protected void BTN_PRINT_Click(object sender, System.EventArgs e)
		{
			Response.Redirect("/SME/HDRS/TrackList.aspx?problem_type=" + DDL_PROBLEM.SelectedValue + "&tc=" + Request.QueryString["tc"] + "&mc=" + Request.QueryString["mc"] + "&regnum=" + Request.QueryString["regnum"]);
		}
	}
}
