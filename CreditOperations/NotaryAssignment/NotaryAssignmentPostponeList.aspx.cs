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

namespace SME.CreditOperations.NotaryAssignment
{
	/// <summary>
	/// Summary description for NotaryAssignmentPostponeList.
	/// </summary>
	public partial class NotaryAssignmentPostponeList : System.Web.UI.Page
	{
		protected Connection conn;
		protected Tools tools = new Tools();
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			conn = (Connection) Session["Connection"];

			if (!Logic.AllowAccess(Session["GroupID"].ToString(), Request.QueryString["mc"], conn))
				Response.Redirect("/SME/Restricted.aspx");

			if (!IsPostBack)
			{
				Tools.initDateForm(TXT_STARTDATE_DAY, DDL_STARTDATE_MONTH, TXT_STARTDATE_YEAR, true);
				TXT_STARTDATE_DAY.Text = "";
				TXT_STARTDATE_YEAR.Text = "";
				Tools.initDateForm(TXT_ENDDATE_DAY, DDL_ENDDATE_MONTH, TXT_ENDDATE_YEAR, true);
				TXT_ENDDATE_DAY.Text = "";
				TXT_ENDDATE_YEAR.Text = "";

				ViewData();
			}
		}

		private void ViewData()
		{
			string qry = "SELECT * FROM VW_NOTARYASSIGN_POSTPONELIST WHERE AP_CURRTRACK = '" + Request.QueryString["tc"] + 
							"' AND (AP_CO = '" + Session["UserID"].ToString() + "' OR AP_CO IS NULL)";

			if (TXT_AP_REGNO.Text != "")
				qry = qry + "AND AP_REGNO = '" + TXT_AP_REGNO.Text.Trim() + "' ";
			if (TXT_CU_NAME.Text != "")
				qry = qry + "AND CU_NAME LIKE '%" + TXT_CU_NAME.Text.Trim() + "%' ";
			if (TXT_IDCARD.Text != "")
				qry = qry + "AND CU_IDNO = '" + TXT_IDCARD.Text.Trim() + "' ";
			if (TXT_NPWP.Text != "")
				qry = qry + "AND CU_NPWP = '" + TXT_NPWP.Text.Trim() + "' ";
			if (TXT_STARTDATE_DAY.Text != "" && DDL_STARTDATE_MONTH.SelectedValue != "" && TXT_STARTDATE_YEAR.Text != "" &&
					TXT_ENDDATE_DAY.Text != "" && DDL_ENDDATE_MONTH.SelectedValue != "" && TXT_ENDDATE_YEAR.Text != "")
				qry = qry + "AND AP_RECVDATE BETWEEN = " + Tools.toSQLDate(TXT_STARTDATE_DAY, DDL_STARTDATE_MONTH, TXT_STARTDATE_YEAR) + " AND " +
					Tools.toSQLDate(TXT_ENDDATE_DAY, DDL_ENDDATE_MONTH, TXT_ENDDATE_YEAR) + " ";
			
			conn.QueryString = qry;
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

			for (int i=0;i<DataGrid1.Items.Count;i++)
			{
				LinkButton lb_cont = (LinkButton)DataGrid1.Items[i].Cells[9].FindControl("LB_CONTINUE");
				lb_cont.Attributes.Add("onclick","if(!continueconfirm()){return false;};");
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
			this.DataGrid1.ItemCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.DataGrid1_ItemCommand);
			this.DataGrid1.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.DataGrid1_PageIndexChanged);

		}
		#endregion

		private void DataGrid1_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			DataGrid1.CurrentPageIndex = e.NewPageIndex;
			ViewData();
		}

		private void DataGrid1_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			switch (((LinkButton)e.CommandSource).CommandName)
			{
				case "Continue":
					try
					{
						conn.QueryString  = "EXEC NOTARYASSIGN_CONTINUEPOSTPONE '" + e.Item.Cells[0].Text + "', '" + 
							e.Item.Cells[1].Text + "', '" + 
							e.Item.Cells[2].Text + "', '" + 
							e.Item.Cells[3].Text + "', '" + 
							Session["UserID"].ToString() + "'";
						conn.ExecuteNonQuery();

						ViewData();
					}
					catch (Exception ex)
					{
						string errmsg = ex.Message.Replace("'","");
						if (errmsg.IndexOf("Last Query:") > 0)
							errmsg = errmsg.Substring(0, errmsg.IndexOf("Last Query:"));
						GlobalTools.popMessage(this, errmsg);
						return;
					}
					break;
			}
		}
	}
}
