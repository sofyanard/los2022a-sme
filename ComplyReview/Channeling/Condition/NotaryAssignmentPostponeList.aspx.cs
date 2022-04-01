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

namespace SME.ComplyReview.Channeling.Condition
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
			BindData("DataGrid1","SELECT * FROM VW_NOTARYASSIGN_POSTPONELIST_CHANNELING");

			for (int i=0;i<DataGrid1.Items.Count;i++)
			{
				LinkButton lb_cont = (LinkButton)DataGrid1.Items[i].Cells[7].FindControl("LB_CONTINUE");
				lb_cont.Attributes.Add("onclick","if(!continueconfirm()){return false;};");
			}
		}

		private void BindData(string dataGridName, string strconn)
		{
			if(strconn != "")
			{
				conn.QueryString = strconn;
				conn.ExecuteQuery();
			}

			System.Data.DataTable dt = new System.Data.DataTable();
			dt = conn.GetDataTable().Copy();

			System.Web.UI.WebControls.DataGrid dg = (System.Web.UI.WebControls.DataGrid)Page.FindControl(dataGridName);

			dg.DataSource = dt;				

			try
			{
				dg.DataBind();
			}
			catch 
			{
				dg.CurrentPageIndex = dg.PageCount - 1;
				dg.DataBind();
			}

			conn.ClearData();
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
						/*conn.QueryString  = "EXEC NOTARYASSIGN_CONTINUEPOSTPONE '" + e.Item.Cells[0].Text + "', '" + 
							e.Item.Cells[1].Text + "', '" + 
							e.Item.Cells[2].Text + "', '" + 
							e.Item.Cells[3].Text + "', '" + 
							Session["UserID"].ToString() + "'";
						conn.ExecuteNonQuery();*/

						conn.QueryString = "EXEC CHANNELING_TRACKUPDATE_PERENDUSER '" + e.Item.Cells[0].Text + "','" + Session["UserID"] + "','TCHAN7.0'";
						conn.ExecuteNonQuery();

						conn.QueryString = "EXEC CHANNELING_TRACKUPDATE_PERENDUSER '" + e.Item.Cells[2].Text + "','" + Session["UserID"] + "','TCHAN7.0'";
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

		protected void btn_Find_Click(object sender, System.EventArgs e)
		{
		
		}
	}
}
