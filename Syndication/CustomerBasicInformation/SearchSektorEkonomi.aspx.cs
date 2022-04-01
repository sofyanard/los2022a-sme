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

namespace SME.Syndication.CustomerBasicInformation
{
	/// <summary>
	/// Summary description for SearchSektorEkonomi.
	/// </summary>
	public partial class SearchSektorEkonomi : System.Web.UI.Page
	{
		protected Connection conn;
		private string theForm, theObj, theObjCity;
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			conn = (Connection) Session["Connection"];

			theForm = Request.QueryString["bifrm"].Trim();
			theObj = Request.QueryString["biobj"].Trim();

			if (!IsPostBack)
			{
				FillDDLBI1();
				FillDDLBI2();
				FillDDLBI3();
				FillDDLBI4();
			}
		}

		private void FillDDLBI1()
		{
			DDL_BI1.Items.Clear();
			DDL_BI1.Items.Add(new ListItem("--Select--", ""));
			conn.QueryString = "SELECT DISTINCT BI1_CODE, BI1_DESC FROM VW_SEARCHSEKTOREKONOMI_BI1 ORDER BY BI1_CODE";
			conn.ExecuteQuery();
			for (int i = 0; i < conn.GetRowCount(); i++)
				DDL_BI1.Items.Add(new ListItem(conn.GetFieldValue(i,1), conn.GetFieldValue(i,0)));
		}

		private void FillDDLBI2()
		{
			DDL_BI2.Items.Clear();
			DDL_BI2.Items.Add(new ListItem("--Select--", ""));
			conn.QueryString = "SELECT DISTINCT BI2_CODE, BI2_DESC FROM VW_SEARCHSEKTOREKONOMI_BI2 WHERE BI1_CODE = '" + DDL_BI1.SelectedValue + "' ORDER BY BI2_CODE";
			conn.ExecuteQuery();
			for (int i = 0; i < conn.GetRowCount(); i++)
				DDL_BI2.Items.Add(new ListItem(conn.GetFieldValue(i,1), conn.GetFieldValue(i,0)));
		}

		private void FillDDLBI3()
		{
			DDL_BI3.Items.Clear();
			DDL_BI3.Items.Add(new ListItem("--Select--", ""));
			conn.QueryString = "SELECT DISTINCT BI3_CODE, BI3_DESC FROM VW_SEARCHSEKTOREKONOMI_BI3 WHERE BI2_CODE = '" + DDL_BI2.SelectedValue + "' ORDER BY BI3_CODE";
			conn.ExecuteQuery();
			for (int i = 0; i < conn.GetRowCount(); i++)
				DDL_BI3.Items.Add(new ListItem(conn.GetFieldValue(i,1), conn.GetFieldValue(i,0)));
		}

		private void FillDDLBI4()
		{
			DDL_BI4.Items.Clear();
			DDL_BI4.Items.Add(new ListItem("--Select--", ""));
			conn.QueryString = "SELECT DISTINCT BI4_CODE, BI4_DESC FROM VW_SEARCHSEKTOREKONOMI_BI4 WHERE BI3_CODE = '" + DDL_BI3.SelectedValue + "' ORDER BY BI4_CODE";
			conn.ExecuteQuery();
			for (int i = 0; i < conn.GetRowCount(); i++)
				DDL_BI4.Items.Add(new ListItem(conn.GetFieldValue(i,1), conn.GetFieldValue(i,0)));
		}

		private void ViewData()
		{
			string qry = "SELECT * FROM VW_SEARCHSEKTOREKONOMI_DATA WHERE 1=1 ";

			if (TXT_BI1.Text != "")
				qry = qry + "AND BI1_DESC LIKE '%" + TXT_BI1.Text.Trim() + "%' ";

			if (TXT_BI2.Text != "")
				qry = qry + "AND BI2_DESC LIKE '%" + TXT_BI2.Text.Trim() + "%' ";

			if (TXT_BI3.Text != "")
				qry = qry + "AND BI3_DESC LIKE '%" + TXT_BI3.Text.Trim() + "%' ";

			if (TXT_BI4.Text != "")
				qry = qry + "AND BI4_DESC LIKE '%" + TXT_BI4.Text.Trim() + "%' ";

			if (DDL_BI1.SelectedValue != "")
				qry = qry + "AND BI1_CODE = '" + DDL_BI1.SelectedValue + "' ";

			if (DDL_BI2.SelectedValue != "")
				qry = qry + "AND BI2_CODE = '" + DDL_BI2.SelectedValue + "' ";

			if (DDL_BI3.SelectedValue != "")
				qry = qry + "AND BI3_CODE = '" + DDL_BI3.SelectedValue + "' ";

			if (DDL_BI4.SelectedValue != "")
				qry = qry + "AND BI4_CODE = '" + DDL_BI4.SelectedValue + "' ";

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

			string pform	= "window.opener.document." + theForm.Trim();
			string frmObj	= "window.opener.document." + theForm.Trim() + "." + theObj.Trim();

			for (int i = 0; i < DG_RESULT.Items.Count; i++)
			{
				HyperLink hlSelect = (HyperLink) DG_RESULT.Items[i].FindControl("HL_SELECT");
				string varUrl = pform + ", " + frmObj + ", '" + DG_RESULT.Items[i].Cells[0].Text.Trim()+ "|" +
					DG_RESULT.Items[i].Cells[1].Text.Trim()+ "|" +
					DG_RESULT.Items[i].Cells[2].Text.Trim()+ "|" +
					DG_RESULT.Items[i].Cells[3].Text.Trim()+ "'";
				hlSelect.NavigateUrl = "javascript:SektorEkonomiSelect("+ varUrl +")";
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

		protected void DDL_BI1_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			FillDDLBI2();
			FillDDLBI3();
			FillDDLBI4();

			TXT_BI1.Text = "";
		}

		protected void DDL_BI2_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			FillDDLBI3();
			FillDDLBI4();

			TXT_BI2.Text = "";
		}

		protected void DDL_BI3_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			FillDDLBI4();

			TXT_BI3.Text = "";
		}

		protected void DDL_BI4_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			TXT_BI4.Text = "";
		}

		protected void BTN_CLEAR_Click(object sender, System.EventArgs e)
		{
			try {DDL_BI1.SelectedValue = "";} 
			catch {}
			try {DDL_BI2.SelectedValue = "";} 
			catch {}
			try {DDL_BI3.SelectedValue = "";} 
			catch {}
			try {DDL_BI4.SelectedValue = "";} 
			catch {}

			TXT_BI1.Text = "";
			TXT_BI2.Text = "";
			TXT_BI3.Text = "";
			TXT_BI4.Text = "";

			FillDDLBI1();
			FillDDLBI2();
			FillDDLBI3();
			FillDDLBI4();

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
