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
using System.IO;
using DMS.CuBESCore;
using DMS.DBConnection;
using System.Data.SqlClient; 

namespace SME.Synchronization
{
	/// <summary>
	/// Summary description for Maintenance.
	/// </summary>
	public partial class Maintenance : System.Web.UI.Page
	{
		protected Connection conn;
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			conn = (Connection) Session["Connection"];

			if (!Logic.AllowAccess(Session["GroupID"].ToString(), Request.QueryString["mc"], conn))
				Response.Redirect("../Restricted.aspx");

			if (!IsPostBack)
			{
				ViewResult();
			}
		}

		private void ViewResult()
		{
			conn.QueryString = "SELECT * FROM VW_EMASSYNC_VIEWSYNCRESULT";
			conn.ExecuteQuery();
			
			DataTable dt = new DataTable();
			dt = conn.GetDataTable().Copy();
			DataGrid1.DataSource = dt;
			try 
			{
				DataGrid1.DataBind();
			} 
			catch 
			{
				DataGrid1.CurrentPageIndex = 0;
				DataGrid1.DataBind();
			}

			string fullname = "";
			for(int i = 0; i < DataGrid1.Items.Count; i++)
			{
				fullname = conn.GetFieldValue(i,"FL_LOC");
				if (File.Exists(fullname))
				{
					DataGrid1.Items[i].Cells[2].Text = "OK!";
					HyperLink HpDownload = (HyperLink) DataGrid1.Items[i].Cells[3].FindControl("FL_DOWNLOAD");
					HpDownload.NavigateUrl = DataGrid1.Items[i].Cells[4].Text.Trim();
				}
				else
				{
					DataGrid1.Items[i].Cells[2].Text = "Not Found!";
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

		}
		#endregion
	}
}
