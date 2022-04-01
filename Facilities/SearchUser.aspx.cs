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
using DMS.DBConnection;
using DMS.CuBESCore;

namespace SME.Facilities
{
	/// <summary>
	/// Summary description for SearchUser.
	/// </summary>
	public partial class SearchUser : System.Web.UI.Page
	{
		protected Connection conn;
		private string theForm, theObj, theObjVal;
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			conn = (Connection) Session["Connection"];

			theForm = Request.QueryString["ufrm"].Trim();
			theObj = Request.QueryString["uobj"].Trim();

			if (!IsPostBack)
			{
				FillGroup();
				FillUnit();
				FillUser();
			}
		}

		private void FillGroup()
		{
			DDL_GROUP.Items.Clear();
			DDL_GROUP.Items.Add(new ListItem("- PILIH -", ""));
			conn.QueryString = "SELECT GROUPID, GROUPNAME FROM VW_SEARCHUSER_GROUP ORDER BY GROUPNAME";
			conn.ExecuteQuery();
			for (int i = 0; i < conn.GetRowCount(); i++)
				DDL_GROUP.Items.Add(new ListItem(conn.GetFieldValue(i,1), conn.GetFieldValue(i,0)));
		}

		private void FillUnit()
		{
			DDL_UNIT.Items.Clear();
			DDL_UNIT.Items.Add(new ListItem("- PILIH -", ""));
			conn.QueryString = "SELECT UNITID, UNITNAME FROM VW_SEARCHUSER_UNIT ORDER BY UNITNAME";
			conn.ExecuteQuery();
			for (int i = 0; i < conn.GetRowCount(); i++)
				DDL_UNIT.Items.Add(new ListItem(conn.GetFieldValue(i,1), conn.GetFieldValue(i,0)));
		}

		private void FillUser()
		{
			DDL_USER.Items.Clear();
			DDL_USER.Items.Add(new ListItem("- PILIH -", ""));

			string uqry = "SELECT USERID, USERNAME FROM VW_SEARCHUSER_USER WHERE 1=1 ";

			if ((DDL_GROUP.SelectedValue != "") || (DDL_UNIT.SelectedValue != ""))
			{
				if (DDL_GROUP.SelectedValue != "")
					uqry = uqry + "AND GROUPID = '" + DDL_GROUP.SelectedValue + "' ";

				if (DDL_UNIT.SelectedValue != "")
					uqry = uqry + "AND UNITID = '" + DDL_UNIT.SelectedValue + "' ";
			}
			else
				uqry = uqry + "AND 1=2 ";

			conn.QueryString = uqry + "ORDER BY USERNAME";
			conn.ExecuteQuery();
			for (int i = 0; i < conn.GetRowCount(); i++)
				DDL_USER.Items.Add(new ListItem(conn.GetFieldValue(i,1), conn.GetFieldValue(i,0)));
		}

		private void ViewData()
		{
			string qry = "SELECT * FROM VW_SEARCHUSER_DATA WHERE 1=1 ";

			if (TXT_GROUP.Text != "")
				qry = qry + "AND GROUPNAME LIKE '%" + TXT_GROUP.Text.Trim() + "%' ";

			if (TXT_UNIT.Text != "")
				qry = qry + "AND UNITNAME LIKE '%" + TXT_UNIT.Text.Trim() + "%' ";

			if (TXT_USER.Text != "")
				qry = qry + "AND USERNAME LIKE '%" + TXT_USER.Text.Trim() + "%' ";

			if (DDL_GROUP.SelectedValue != "")
				qry = qry + "AND GROUPID = '" + DDL_GROUP.SelectedValue + "' ";

			if (DDL_UNIT.SelectedValue != "")
				qry = qry + "AND UNITID = '" + DDL_UNIT.SelectedValue + "' ";

			if (DDL_USER.SelectedValue != "")
				qry = qry + "AND USERID = '" + DDL_USER.SelectedValue + "' ";

			conn.QueryString = qry;
			conn.ExecuteQuery();
			
			DataTable dt = new DataTable();
			dt = conn.GetDataTable().Copy();
			DG_RESULT.DataSource = dt;
			try 
			{
				DG_RESULT.DataBind();
			} 
			catch 
			{
				DG_RESULT.CurrentPageIndex = 0;
				DG_RESULT.DataBind();
			}

			/*
            string urlForm	= "window.opener.document." + theForm.Trim();
			string urlObj	= "window.opener.document." + theForm.Trim() + "." + theObj.Trim();
            */

            string urlForm = "window.opener.document.getElementById('" + theForm.Trim() + "')";
            string urlObj = "window.opener.document.getElementById('" + theObj.Trim() + "')";

			for (int i = 0; i < DG_RESULT.Items.Count; i++)
			{
				HyperLink hlSelect = (HyperLink) DG_RESULT.Items[i].FindControl("HL_SELECT");
				string varUrl = urlForm + ", " + urlObj + ", '" + DG_RESULT.Items[i].Cells[0].Text.Trim() + "'";
				hlSelect.NavigateUrl = "javascript:UserSelect("+ varUrl +")";
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
			this.DG_RESULT.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.DG_RESULT_PageIndexChanged);

		}
		#endregion

		protected void DDL_GROUP_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			FillUser();
			TXT_GROUP.Text = "";
		}

		protected void DDL_UNIT_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			FillUser();
			TXT_UNIT.Text = "";
		}

		protected void BTN_CLEAR_Click(object sender, System.EventArgs e)
		{
			try {DDL_GROUP.SelectedValue = "";} 
			catch {}
			try {DDL_UNIT.SelectedValue = "";} 
			catch {}
			try {DDL_USER.SelectedValue = "";} 
			catch {}

			TXT_GROUP.Text = "";
			TXT_UNIT.Text = "";
			TXT_USER.Text = "";

			FillGroup();
			FillUnit();
			FillUser();

			DataTable dt = new DataTable();
			dt = conn.GetDataTable().Copy();
			DG_RESULT.DataSource = dt;
			try 
			{
				DG_RESULT.DataBind();
			} 
			catch 
			{
				DG_RESULT.CurrentPageIndex = 0;
				DG_RESULT.DataBind();
			}
		}

		protected void BTN_SEARCH_Click(object sender, System.EventArgs e)
		{
			ViewData();
		}

		private void DG_RESULT_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			DG_RESULT.CurrentPageIndex = e.NewPageIndex;
			ViewData();
		}
	}
}
