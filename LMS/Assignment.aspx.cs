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

namespace SME.LMS
{
	/// <summary>
	/// Summary description for Assignment.
	/// </summary>
	public partial class Assignment : System.Web.UI.Page
	{
		protected Connection conn;
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			conn = (Connection) Session["Connection"];

			if (!Logic.AllowAccess(Session["GroupID"].ToString(), Request.QueryString["mc"], conn))
				Response.Redirect("../Restricted.aspx");

			if (!IsPostBack)
			{
				DDL_CU_DOB_MM.Items.Add(new ListItem("-- Select --",""));
				for (int i = 1; i <= 12; i++)
					DDL_CU_DOB_MM.Items.Add(new ListItem(DateAndTime.MonthName(i, false), i.ToString()));
				FillDDLRM();
				FillDDLNextby();

				TR_LIST.Visible = true;
				TR_DETAIL.Visible = false;
			}

		}

		private void FillDDLRM()
		{
			conn.QueryString = "exec LMS_ASSIGNMENT_FILLDDLRM '" + LBL_APREGNO.Text + "', '" + Session["UserID"].ToString() + "'";
			conn.ExecuteQuery();

			DDL_RM.Items.Add(new ListItem("-- Select --",""));
			for (int i = 0; i < conn.GetRowCount(); i++)
			{
				DDL_RM.Items.Add(new ListItem(conn.GetFieldValue(i,"USERNAME"),conn.GetFieldValue(i,"USERID")));
			}
		}

		private void FillDDLNextby()
		{
			conn.QueryString = "exec LMS_ASSIGNMENT_FILLDDLNEXTTRBY '" + LBL_APREGNO.Text + "', '" + Session["UserID"].ToString() + "'";
			conn.ExecuteQuery();

			DDL_NEXTTR.Items.Add(new ListItem("-- Select --",""));
			for (int i = 0; i < conn.GetRowCount(); i++)
			{
				DDL_NEXTTR.Items.Add(new ListItem(conn.GetFieldValue(i,"USERNAME"),conn.GetFieldValue(i,"USERID")));
			}
		}

		private void SearchApp()
		{
			string borndate = "";
			if (TXT_CU_DOB_DD.Text != "" && DDL_CU_DOB_MM.SelectedValue != "" && TXT_CU_DOB_YY.Text != "")
				if (Tools.isDateValid(this,TXT_CU_DOB_DD.Text, DDL_CU_DOB_MM.SelectedValue, TXT_CU_DOB_YY.Text))
				{
					borndate = Tools.toSQLDate(TXT_CU_DOB_DD, DDL_CU_DOB_MM, TXT_CU_DOB_YY);
				}
				else
				{
					GlobalTools.popMessage(this, "Tanggal tidak valid!");
					return;
				}
			conn.QueryString = "EXEC LMS_ASSIGNMENT_SEARCHAPP '" +
				TXT_LMSREG.Text + "', '" +
				Session["UserID"].ToString() + "', '" +
				TXT_CU_CIF.Text + "', '" +
				txt_Name.Text + "', '" +
				txt_IdCard.Text + "', '" +
				borndate + "', '" +
				txt_NPWP.Text + "'";
			conn.ExecuteQuery();
			
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

		private void DetailApp(string lmsreg)
		{
			conn.QueryString = "EXEC LMS_ASSIGNMENT_DETAILAPP '" + lmsreg + "'";
			conn.ExecuteQuery();

			if (conn.GetRowCount() > 0)
			{
				try { DDL_RM.SelectedValue = conn.GetFieldValue("RM"); }
				catch { DDL_RM.SelectedValue = ""; }
				try { DDL_NEXTTR.SelectedValue = conn.GetFieldValue("NEXTTRBY"); }
				catch { DDL_NEXTTR.SelectedValue = ""; }
			}
		}

		private void ClearEntry()
		{
			TXT_LMSREG.Text = "";
			TXT_CU_CIF.Text = "";
			txt_Name.Text = "";
			txt_IdCard.Text = "";
			TXT_CU_DOB_DD.Text = "";
			DDL_CU_DOB_MM.SelectedValue = "";
			TXT_CU_DOB_YY.Text = "";
			txt_NPWP.Text = "";
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

		protected void btn_Find_Click(object sender, System.EventArgs e)
		{
			SearchApp();
			TR_LIST.Visible = true;
			TR_DETAIL.Visible = false;
			LBL_APREGNO.Text = "";
			LBL_APREGNO.Visible = false;
		}

		protected void btn_clear_Click(object sender, System.EventArgs e)
		{
			ClearEntry();
		}

		private void DG_APP_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			DG_APP.CurrentPageIndex = e.NewPageIndex;
			SearchApp();
		}

		private void DG_APP_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			switch(((LinkButton)e.CommandSource).CommandName)
			{
				case "View":
					DetailApp(e.Item.Cells[0].Text.Trim());
					TR_LIST.Visible = false;
					TR_DETAIL.Visible = true;
					LBL_APREGNO.Visible = true;
					LBL_APREGNO.Text = e.Item.Cells[0].Text.Trim();
					break;
			}
		}

		protected void BTN_ASSIGNRM_Click(object sender, System.EventArgs e)
		{
			try
			{
				conn.QueryString = "exec LMS_ASSIGNMENT_ASSIGNRM '" + 
					LBL_APREGNO.Text + "', '" +
					Session["UserID"].ToString() + "', '" +
					DDL_RM.SelectedValue + "'";
				conn.ExecuteQuery();
			}
			catch (Exception ex)
			{
				Response.Write("<!--" + ex.Message + "-->");
			}
		}

		protected void BTN_ASSIGNNEXTTR_Click(object sender, System.EventArgs e)
		{
			try
			{
				conn.QueryString = "exec LMS_ASSIGNMENT_ASSIGNNEXTTR '" + 
					LBL_APREGNO.Text + "', '" +
					Session["UserID"].ToString() + "', '" +
					DDL_NEXTTR.SelectedValue + "'";
				conn.ExecuteQuery();
			}
			catch (Exception ex)
			{
				Response.Write("<!--" + ex.Message + "-->");
			}
		}
	}
}
