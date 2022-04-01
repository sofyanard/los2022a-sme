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
using Microsoft.VisualBasic;

namespace SME.Facilities
{
	/// <summary>
	/// Summary description for PerformanceAccountList.
	/// </summary>
	public partial class PerformanceAccountList : System.Web.UI.Page
	{
		protected Connection conn;
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			conn = (Connection) Session["Connection"];

			if (!Logic.AllowAccess(Session["GroupID"].ToString(), Request.QueryString["mc"], conn))
				Response.Redirect("../Restricted.aspx");

			if (!IsPostBack)
			{
				DDL_CU_DOB_MM.Items.Add(new ListItem("- SELECT -", ""));
				for (int i = 1; i <= 12; i++)
					DDL_CU_DOB_MM.Items.Add(new ListItem(DateAndTime.MonthName(i, false), i.ToString()));
			}
		}

		private void ClearEntry()
		{
			TXT_CU_CIF.Text = "";
			TXT_CU_NAME.Text = "";
			TXT_CU_KTPNO.Text = "";
			TXT_CU_NPWPNO.Text = "";
			TXT_CU_DOB_DD.Text = "";
			try {DDL_CU_DOB_MM.SelectedValue = "";}
			catch {}
			TXT_CU_DOB_YY.Text = "";
		}

		private void ViewData()
		{
			string qry = "SELECT * FROM VW_PERFORMANCEACCOUNTLIST_FINDCUST WHERE 1=1 ";

			if (TXT_CU_CIF.Text != "")
				qry = qry + "AND CU_CIF = '" + TXT_CU_CIF.Text.Trim() + "' ";

			if (TXT_CU_NAME.Text != "")
				qry = qry + "AND CU_NAME LIKE '%" + TXT_CU_NAME.Text.Trim() + "%' ";

			if (TXT_CU_KTPNO.Text != "")
				qry = qry + "AND CU_KTPNO = '" + TXT_CU_KTPNO.Text.Trim() + "' ";

			if (TXT_CU_NPWPNO.Text != "")
				qry = qry + "AND CU_NPWPNO = '" + TXT_CU_NPWPNO.Text.Trim() + "' ";

			if (TXT_CU_DOB_DD.Text != "" && DDL_CU_DOB_MM.SelectedValue != "" && TXT_CU_DOB_YY.Text != "")
				if (Tools.isDateValid(this,TXT_CU_DOB_DD.Text, DDL_CU_DOB_MM.SelectedValue, TXT_CU_DOB_YY.Text))
				{
					qry = qry + "AND CU_BORNDATE = '" + Tools.toSQLDate(TXT_CU_DOB_DD, DDL_CU_DOB_MM, TXT_CU_DOB_YY ) + "' ";
				}

			conn.QueryString = qry;
			conn.ExecuteQuery();
			
			DataTable dt = new DataTable();
			dt = conn.GetDataTable().Copy();
			DatGrd.DataSource = dt;
			try 
			{
				DatGrd.DataBind();
			} 
			catch 
			{
				DatGrd.CurrentPageIndex = 0;
				DatGrd.DataBind();
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
			this.DatGrd.ItemCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.DatGrd_ItemCommand);
			this.DatGrd.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.DatGrd_PageIndexChanged);

		}
		#endregion

		protected void BTN_FIND_Click(object sender, System.EventArgs e)
		{
			DatGrd.CurrentPageIndex = 0;
			ViewData();
		}

		protected void BTN_CLEAR_Click(object sender, System.EventArgs e)
		{
			ClearEntry();
		}

		private void DatGrd_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			switch (((LinkButton)e.CommandSource).CommandName)
			{
				case "View":
					string url = e.Item.Cells[5].Text;
					Response.Redirect(url);
					break;					
			}
		}

		private void DatGrd_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			DatGrd.CurrentPageIndex = e.NewPageIndex;
			ViewData();
		}
	}
}
