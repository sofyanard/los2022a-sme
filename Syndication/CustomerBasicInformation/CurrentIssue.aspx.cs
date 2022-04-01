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
using DMS.CuBESCore;
using DMS.DBConnection;
using Microsoft.VisualBasic;

namespace SME.Syndication.CustomerBasicInformation
{
	/// <summary>
	/// Summary description for CurrentIssue.
	/// </summary>
	public partial class CurrentIssue : System.Web.UI.Page
	{
		protected Tools tools = new Tools();
		protected Connection conn = new Connection(ConfigurationSettings.AppSettings["conn"]);
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			ViewMenu();

			if(!IsPostBack)
			{
				FillDDLIssue();

				DDL_INFORMATION_MONTH.Items.Add(new ListItem("--Select--",""));
				DDL_TARGET_MONTH.Items.Add(new ListItem("--Select--",""));
				for (int i = 1; i <= 12; i++)
				{
					DDL_INFORMATION_MONTH.Items.Add(new ListItem(DateAndTime.MonthName(i, false), i.ToString()));
					DDL_TARGET_MONTH.Items.Add(new ListItem(DateAndTime.MonthName(i, false), i.ToString()));
				}
			}
			FillDataGrid();
		}

		private void ViewMenu()
		{
			Menu.Controls.Clear();
			try 
			{
				conn.QueryString = "SELECT * FROM SCREENMENU WHERE MENUCODE = '" + Request.QueryString["mc"] + "'";
				conn.ExecuteQuery();
				
				for (int i = 0; i < conn.GetRowCount(); i++) 
				{
					HyperLink t = new HyperLink();
					t.Text = conn.GetFieldValue(i, 2);
					t.Font.Bold = true;
					string strtemp = "";
					if (conn.GetFieldValue(i, 3).Trim()!= "") 
					{
						if (conn.GetFieldValue(i,3).IndexOf("mc=") >= 0)
							strtemp = "&curef=" + Request.QueryString["curef"] + "&cif=" + Request.QueryString["cif"] + "&exist=" + Request.QueryString["exist"];
						else	
							strtemp = "&mc=" + Request.QueryString["mc"]+ "&curef=" + Request.QueryString["curef"] + "&cif=" + Request.QueryString["cif"] + "&exist=" + Request.QueryString["exist"];
					}
					else 
					{
						strtemp = ""; 
					}
					t.NavigateUrl = conn.GetFieldValue(i, 3)+strtemp;
					Menu.Controls.Add(t);
					Menu.Controls.Add(new LiteralControl("&nbsp;&nbsp;&nbsp;"));
				}
			} 
			catch (Exception ex) 
			{
				string temp = ex.ToString();
			}
		}

		private void FillDDLIssue()
		{
			DDL_ISSUE_TYPE.Items.Clear();
			DDL_ISSUE_TYPE.Items.Add(new ListItem("--Select--", ""));

			conn.QueryString = "SELECT CODE, [DESC] FROM RF_ISSUE_TYPE WHERE ACTIVE = '1'";
			conn.ExecuteQuery();
			for(int i=0; i < conn.GetRowCount(); i++)
			{
				DDL_ISSUE_TYPE.Items.Add(new ListItem(conn.GetFieldValue(i,1), conn.GetFieldValue(i,0)));
			}
		}

		private void FillDataGrid()
		{
			conn.QueryString = "SELECT A.*, B.[DESC] AS ISSUE_DESC FROM SDC_ISSUE_INFO A LEFT OUTER JOIN RF_ISSUE_TYPE B ON A.ISSUE_TYPE = B.CODE WHERE CU_REF = '" + Request.QueryString["curef"] + "'";
			BindData(DATA_GRID.ID.ToString(), conn.QueryString);
		}

		private void BindData(string dataGridName, string strconn)
		{
			if(strconn != "")
			{
				conn.QueryString = strconn;
				conn.ExecuteQuery();

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

				for (int i = 0; i < dg.Items.Count; i++)
				{
					dg.Items[i].Cells[1].Text = tools.FormatDate(dg.Items[i].Cells[1].Text, true);
				} 

				conn.ClearData();
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
			this.DATA_GRID.ItemCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.DATA_GRID_ItemCommand);
			this.DATA_GRID.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.DATA_GRID_PageIndexChanged);

		}
		#endregion

		protected void BTN_SAVE_Click(object sender, System.EventArgs e)
		{
			if (TXT_INFORMATION_DAY.Text != "" && DDL_INFORMATION_MONTH.SelectedValue != "" && TXT_INFORMATION_YEAR.Text != "") 
			{
				if (!GlobalTools.isDateValid(TXT_INFORMATION_DAY.Text, DDL_INFORMATION_MONTH.SelectedValue, TXT_INFORMATION_YEAR.Text)) 
				{
					GlobalTools.popMessage(this, "Tanggal Informasi Tidak Valid!");
					return;
				}
			}

			if (TXT_TARGET_DAY.Text != "" && DDL_TARGET_MONTH.SelectedValue != "" && TXT_TARGET_YEAR.Text != "") 
			{
				if (!GlobalTools.isDateValid(TXT_TARGET_DAY.Text, DDL_TARGET_MONTH.SelectedValue, TXT_TARGET_YEAR.Text)) 
				{
					GlobalTools.popMessage(this, "Tanggal Target Penyelesaian Tidak Valid!");
					return;
				}
			}

			try
			{
				conn.QueryString = "EXEC SDC_ISSUE_INFO_INSERT '" +
									LBL_SEQ.Text + "','" +
									Session["UserID"].ToString() + "','" +
									Request.QueryString["curef"] + "','" +
									Request.QueryString["cif"] + "'," +
									tools.ConvertDate(TXT_INFORMATION_DAY.Text, DDL_INFORMATION_MONTH.SelectedValue, TXT_INFORMATION_YEAR.Text) + ",'" +
									DDL_ISSUE_TYPE.SelectedValue + "'," +
									tools.ConvertDate(TXT_TARGET_DAY.Text, DDL_TARGET_MONTH.SelectedValue, TXT_TARGET_YEAR.Text) + ",'" +
									TXT_DESC.Text + "'";
				conn.ExecuteQuery();

				ClearData();
				FillDataGrid();
			}

			catch(Exception ex)
			{
				string errmsg = ex.Message.Replace("'","");
				if (errmsg.IndexOf("Last Query:") > 0)
					errmsg = errmsg.Substring(0, errmsg.IndexOf("Last Query:"));
				GlobalTools.popMessage(this, errmsg);
				return;
			}
		}

		protected void BTN_CLEAR_Click(object sender, System.EventArgs e)
		{
			ClearData();
		}

		private void ClearData()
		{
			LBL_SEQ.Text						= "";
			TXT_INFORMATION_DAY.Text			= "";
			DDL_INFORMATION_MONTH.SelectedValue	= "";
			TXT_INFORMATION_YEAR.Text			= "";
			DDL_ISSUE_TYPE.SelectedValue		= "";
			TXT_TARGET_DAY.Text					= "";
			DDL_TARGET_MONTH.SelectedValue		= "";
			TXT_TARGET_YEAR.Text				= "";
			TXT_DESC.Text						= "";
		}

		private void DATA_GRID_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			DATA_GRID.CurrentPageIndex = e.NewPageIndex;
			FillDataGrid();
		}

		private void DATA_GRID_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			switch(((LinkButton)e.CommandSource).CommandName)
			{
				case "edit":
					conn.QueryString = "SELECT * FROM SDC_ISSUE_INFO WHERE SEQ = '" + e.Item.Cells[0].Text.ToString() + "' AND CU_REF = '" + Request.QueryString["curef"] + "'";
					conn.ExecuteQuery();

					LBL_SEQ.Text						= conn.GetFieldValue("SEQ").ToString().Replace("&nbsp;","");
					TXT_INFORMATION_DAY.Text			= tools.FormatDate_Day(conn.GetFieldValue("INFO_DATE").ToString());
					DDL_INFORMATION_MONTH.SelectedValue	= tools.FormatDate_Month(conn.GetFieldValue("INFO_DATE").ToString());
					TXT_INFORMATION_YEAR.Text			= tools.FormatDate_Year(conn.GetFieldValue("INFO_DATE").ToString());
					DDL_ISSUE_TYPE.SelectedValue		= conn.GetFieldValue("ISSUE_TYPE").ToString();
					TXT_TARGET_DAY.Text					= tools.FormatDate_Day(conn.GetFieldValue("TARGET_DATE").ToString());
					DDL_TARGET_MONTH.SelectedValue		= tools.FormatDate_Month(conn.GetFieldValue("TARGET_DATE").ToString());
					TXT_TARGET_YEAR.Text				= tools.FormatDate_Year(conn.GetFieldValue("TARGET_DATE").ToString());
					TXT_DESC.Text						= conn.GetFieldValue("DESC").ToString().Replace("&nbsp;","");
					break;

				case "delete":
					conn.QueryString = "DELETE SDC_ISSUE_INFO WHERE SEQ = '" + e.Item.Cells[0].Text.ToString() + "' AND CU_REF = '" + Request.QueryString["curef"] + "'";
					conn.ExecuteQuery();

					FillDataGrid();
					break;
			}
		}

		protected void BTN_BACK_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			Response.Redirect("../CustomerList.aspx?mc=" + Request.QueryString["mc"]);
		}
	}
}
