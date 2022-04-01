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

namespace SME.TargetCustomer
{
	/// <summary>
	/// Summary description for TargetCustomerAprvList.
	/// </summary>
	public partial class TargetCustomerAprvList : System.Web.UI.Page
	{
		protected Connection conn;
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			conn = (Connection) Session["Connection"];

			if (!Logic.AllowAccess(Session["GroupID"].ToString(), Request.QueryString["mc"], conn))
				Response.Redirect("/SME/Restricted.aspx");

			if (!IsPostBack)
			{
				for (int i = 1; i <= 12; i++)
				{
					DDL_TARGETDATE_START_MM.Items.Add(new ListItem(DateAndTime.MonthName(i, false), i.ToString()));
					DDL_TARGETDATE_END_MM.Items.Add(new ListItem(DateAndTime.MonthName(i, false), i.ToString()));
				}

				ViewData();

				//Next Step Message
				if (Request.QueryString["msg"] != "" && Request.QueryString["msg"] != null) 
				{
					GlobalTools.popMessage(this, Request.QueryString["msg"]);
				}
			}
		}

		private void ViewData()
		{
			string qry = "SELECT * FROM VW_TARGETCUST_APPROVALLIST WHERE CURRTRACK = '" + Request.QueryString["tc"] + 
				"' AND CURRTRACKBY = '" + Session["UserID"].ToString() + "'";

			if (TXT_NAME.Text != "")
				qry = qry + "AND CU_NAME LIKE '%" + TXT_NAME.Text.Trim() + "%' ";

			if (TXT_ADDR.Text != "")
				qry = qry + "AND CU_ADDR LIKE '%" + TXT_ADDR.Text.Trim() + "%' ";

			if (TXT_IDNO.Text != "")
				qry = qry + "AND CU_IDNO LIKE '%" + TXT_IDNO.Text.Trim() + "%' ";

			if (TXT_TARGETDATE_START_DD.Text != "" && DDL_TARGETDATE_START_MM.SelectedValue != "" && TXT_TARGETDATE_START_YY.Text != "")
				if (Tools.isDateValid(this,TXT_TARGETDATE_START_DD.Text, DDL_TARGETDATE_START_MM.SelectedValue, TXT_TARGETDATE_START_YY.Text))
				{
					qry = qry + "AND TARGETDATE >= '" + Tools.toSQLDate(TXT_TARGETDATE_START_DD, DDL_TARGETDATE_START_MM, TXT_TARGETDATE_START_YY ) + "' ";
				}

			if (TXT_TARGETDATE_END_DD.Text != "" && DDL_TARGETDATE_END_MM.SelectedValue != "" && TXT_TARGETDATE_END_YY.Text != "")
				if (Tools.isDateValid(this,TXT_TARGETDATE_END_DD.Text, DDL_TARGETDATE_END_MM.SelectedValue, TXT_TARGETDATE_END_YY.Text))
				{
					qry = qry + "AND TARGETDATE <= '" + Tools.toSQLDate(TXT_TARGETDATE_END_DD, DDL_TARGETDATE_END_MM, TXT_TARGETDATE_END_YY ) + "' ";
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
			ViewData();
		}

		private void DatGrd_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			switch (((LinkButton)e.CommandSource).CommandName)
			{
				case "View":
					string url = e.Item.Cells[5].Text;

					if (Request.QueryString["tc"] != null && Request.QueryString["tc"] != "")
						url = url + "&tc=" + Request.QueryString["tc"];

					if (Request.QueryString["mc"] != null && Request.QueryString["mc"] != "")
						url = url + "&mc=" + Request.QueryString["mc"];

					if (Request.QueryString["trg"] != null && Request.QueryString["trg"] != "")
						url = url + "&trg=" + Request.QueryString["trg"];

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
