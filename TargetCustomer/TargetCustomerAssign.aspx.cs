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
using DMS.DBConnection;
using DMS.CuBESCore;

namespace SME.TargetCustomer
{
	/// <summary>
	/// Summary description for TargetCustomerAssign.
	/// </summary>
	public partial class TargetCustomerAssign : System.Web.UI.Page
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

				GlobalTools.fillRefList(DDL_TARGETUNIT, "SELECT TARGETUNIT_CODE, TARGETUNIT_DESC, ACTIVE FROM VW_TARGETCUST_REFTARGETUNIT WHERE ACTIVE = '1' ORDER BY TARGETUNIT_CODE", false, conn);
				GlobalTools.fillRefList(DDL_CURRUSER, "SELECT CURRUSER_CODE, CURRUSER_DESC, ACTIVE FROM VW_TARGETCUST_REFCURRENTUSER WHERE ACTIVE = '1' ORDER BY CURRUSER_DESC", false, conn);

				TR_APP.Visible = true;
				TR_TRACK.Visible = false;
			}
		}

		private void SearchData()
		{
			string qry = "SELECT * FROM VW_TARGETCUST_INQUIRYSEARCH WHERE 1=1 ";

			if (TXT_TRG_CU_REF.Text != "")
				qry = qry + "AND TRG_CU_REF = '" + TXT_TRG_CU_REF.Text.Trim() + "' ";

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

			if (conn.GetRowCount() == 1)
			{
				string trgcuref = conn.GetFieldValue("TRG_CU_REF");
				ViewTrack(trgcuref);
			}
			else
			{
				DataTable dt = new DataTable();
				dt = conn.GetDataTable().Copy();
				DG_APP.DataSource = dt;
				try 
				{
					DG_APP.DataBind();
				} 
				catch 
				{
					DG_APP.CurrentPageIndex = 0;
					DG_APP.DataBind();
				}
			}
		}

		private void ViewTrack(string trgcuref)
		{
			LBL_TRG_CU_REF.Text = trgcuref;
			TR_APP.Visible = false;
			TR_TRACK.Visible = true;

			conn.QueryString = "SELECT * FROM VW_TARGETCUST_ASSIGNCURRENTDATA WHERE TRG_CU_REF = '" + trgcuref + "'";
			conn.ExecuteQuery();

			if (conn.GetRowCount() > 0)
			{
				TXT_CURRTRACK.Text = conn.GetFieldValue("CURRTRACK");
				TXT_CURRUSER.Text = conn.GetFieldValue("CURRTRACKBY");
				TXT_TARGETUNIT.Text = conn.GetFieldValue("TARGETUNIT");
				TXT_TARGETUSER.Text = conn.GetFieldValue("TARGETUSER");
			}
		}

		private void ClearEntry()
		{
			TXT_TRG_CU_REF.Text = "";
			TXT_NAME.Text = "";
			TXT_ADDR.Text = "";
			TXT_IDNO.Text = "";
			TXT_TARGETDATE_START_DD.Text = "";
			try {DDL_TARGETDATE_START_MM.SelectedValue = "";}
			catch {}
			TXT_TARGETDATE_START_YY.Text = "";
			TXT_TARGETDATE_END_DD.Text = "";
			try {DDL_TARGETDATE_END_MM.SelectedValue = "";}
			catch {}
			TXT_TARGETDATE_END_YY.Text = "";
			LBL_TRG_CU_REF.Text = "";

			TR_APP.Visible = true;
			TR_TRACK.Visible = false;
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
			this.DG_APP.ItemCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.DG_APP_ItemCommand);
			this.DG_APP.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.DG_APP_PageIndexChanged);

		}
		#endregion

		protected void BTN_FIND_Click(object sender, System.EventArgs e)
		{
			SearchData();
		}

		protected void BTN_CLEAR_Click(object sender, System.EventArgs e)
		{
			ClearEntry();
		}

		private void DG_APP_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			DG_APP.CurrentPageIndex = e.NewPageIndex;
			SearchData();
		}

		private void DG_APP_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			switch(((LinkButton)e.CommandSource).CommandName)
			{
				case "View":
					ViewTrack(e.Item.Cells[0].Text);
					break;
			}
		}

		protected void DDL_TARGETUNIT_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			GlobalTools.fillRefList(DDL_TARGETUSER, "SELECT TARGETUSER_CODE, TARGETUSER_DESC, TARGETUNIT_CODE, ACTIVE FROM VW_TARGETCUST_REFTARGETUSER WHERE ACTIVE = '1' AND TARGETUNIT_CODE = '" + DDL_TARGETUNIT.SelectedValue + "' ORDER BY TARGETUSER_DESC", false, conn);
		}

		protected void BTN_TARGETUNIT_Click(object sender, System.EventArgs e)
		{
			try
			{
				conn.QueryString  = "EXEC TARGETCUST_ASSIGNTARGETUNIT '" + 
					LBL_TRG_CU_REF.Text + "', '" + 
					DDL_TARGETUNIT.SelectedValue + "', '" +
					Session["UserID"].ToString() + "'";
				conn.ExecuteNonQuery();

				ViewTrack(LBL_TRG_CU_REF.Text);
			}
			catch (Exception ex)
			{
				string errmsg = ex.Message.Replace("'","");
				if (errmsg.IndexOf("Last Query:") > 0)
					errmsg = errmsg.Substring(0, errmsg.IndexOf("Last Query:"));
				GlobalTools.popMessage(this, errmsg);
				return;
			}
		}

		protected void BTN_TARGETUSER_Click(object sender, System.EventArgs e)
		{
			try
			{
				conn.QueryString  = "EXEC TARGETCUST_ASSIGNTARGETUSER '" + 
					LBL_TRG_CU_REF.Text + "', '" + 
					DDL_TARGETUSER.SelectedValue + "', '" +
					Session["UserID"].ToString() + "'";
				conn.ExecuteNonQuery();

				ViewTrack(LBL_TRG_CU_REF.Text);
			}
			catch (Exception ex)
			{
				string errmsg = ex.Message.Replace("'","");
				if (errmsg.IndexOf("Last Query:") > 0)
					errmsg = errmsg.Substring(0, errmsg.IndexOf("Last Query:"));
				GlobalTools.popMessage(this, errmsg);
				return;
			}
		}

		protected void BTN_CURRUSER_Click(object sender, System.EventArgs e)
		{
			try
			{
				conn.QueryString  = "EXEC TARGETCUST_ASSIGNCURRENTUSER '" + 
					LBL_TRG_CU_REF.Text + "', '" + 
					DDL_CURRUSER.SelectedValue + "', '" +
					Session["UserID"].ToString() + "'";
				conn.ExecuteNonQuery();

				ViewTrack(LBL_TRG_CU_REF.Text);
			}
			catch (Exception ex)
			{
				string errmsg = ex.Message.Replace("'","");
				if (errmsg.IndexOf("Last Query:") > 0)
					errmsg = errmsg.Substring(0, errmsg.IndexOf("Last Query:"));
				GlobalTools.popMessage(this, errmsg);
				return;
			}
		}
	}
}
