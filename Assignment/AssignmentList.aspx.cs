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
using DMS.CuBESCore;
using DMS.DBConnection;
using System.Configuration;

namespace SME.Assignment
{
	/// <summary>
	/// Summary description for General Assignment List for :
	/// - Detal Data Entry			(tc = 1.4)
	/// - BI Checking				(tc = null)
	/// - Legal Signing Condition	(tc = 4.7)
	/// </summary>
	public partial class AssignmentList : System.Web.UI.Page
	{

		
		protected Connection conn;
		protected Tools tool = new Tools();
		protected string groupUnit;
		
		protected void Page_Load(object sender, System.EventArgs e)
		{
			//conn = (Connection) Session["Connection"];		
			conn = new Connection(ConfigurationSettings.AppSettings["conn"]);

			if (!Logic.AllowAccess(Session["GroupID"].ToString(), Request.QueryString["mc"], conn))
				Response.Redirect("/SME/Restricted.aspx");

			// check & assign BU or CO checking ....
			groupUnit = getGroupUnit((string) Session["GroupID"]);

			if (!IsPostBack) 
			{
				LBL_BR_CCOBRANCH.Text = getCCOBranch((string) Session["BranchID"]);
				LBL_TC.Text = Request.QueryString["tc"];
				setTitle(Request.QueryString["mc"]);
				viewAllData();
				fillFindKriteria();
			}
		}

		private string getGroupUnit(string groupid) 
		{
			string groupUnit = "CO";
			try 
			{
				conn.QueryString = "select SG_GRPUNIT from SCGROUP where groupid = '" + groupid + "'";
				conn.ExecuteQuery();
			
				groupUnit = conn.GetFieldValue("SG_GRPUNIT");
			} 
			catch 
			{
			}

			return groupUnit;
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
			this.DataGrid1.SortCommand += new System.Web.UI.WebControls.DataGridSortCommandEventHandler(this.DataGrid1_SortCommand);

		}
		#endregion

		private string getCCOBranch(string BRANCH_ID) 
		{
			try 
			{
				string tc = Request.QueryString["tc"];

				conn.QueryString = "select BR_CCOBRANCH, CBC_CODE from RFBRANCH where BRANCH_CODE = '" + BRANCH_ID + "'";
				conn.ExecuteQuery();
				
				/// Filtering untuk branch dilakukan saat BI Checking saja, karena BI Checking dapat dilakukan 
				/// oleh 2 (dua) unit, yaitu BU dan CO
				/// 
				if (tc=="" || tc==null || tc=="&nbsp;")  
				{
					if (groupUnit == "BU")
						return conn.GetFieldValue("CBC_CODE");
					else
						return conn.GetFieldValue("BR_CCOBRANCH");
				}
				else 
					return conn.GetFieldValue("BR_CCOBRANCH");
			}
			catch (NullReferenceException) 
			{
				GlobalTools.popMessage(this, "Connection Error !");
				return null;
			}
		}

		private void setTitle(string MENUCODE) 
		{
			try 
			{
				conn.QueryString = "select MENUDISPLAY from RFMENU where MENUCODE = '" + MENUCODE + "'";
				conn.ExecuteQuery();

				LBL_TITLE.Text = conn.GetFieldValue("MENUDISPLAY");
			} 
			catch (NullReferenceException) 
			{
				Tools.popMessage(this, "Connection Error !");
				return;
			}
		}

		private void fillFindKriteria() 
		{
			for(int i=0; i<DataGrid1.Columns.Count; i++) 
			{
				if (DataGrid1.Columns[i].Visible == true && DataGrid1.Columns[i].SortExpression != "") 
				{
					DDL_FIND_KRITERIA.Items.Add(new ListItem(DataGrid1.Columns[i].HeaderText, DataGrid1.Columns[i].SortExpression));
				}
			}
		}

		private string getQueryString(string tc) 
		{
			try 
			{
				//Asumsi : Kalau tc kosong, berarti berasal dari BI Checking
				if (tc=="" || tc==null || tc=="&nbsp;")
					conn.QueryString = "select * from ASSIGNMENT_VIEW where (TRACKCODE is null or TRACKCODE = '' or TRACKCODE = '&nbsp;')";
				else
					conn.QueryString = "select * from ASSIGNMENT_VIEW where TRACKCODE = '" + tc + "'";
				conn.ExecuteQuery();
			} 
			catch (NullReferenceException)
			{
				Tools.popMessage(this, "Connection Error !");
				return null;
			}

			string VIEWNAME = conn.GetFieldValue("ASV_VIEWNAME");
			string queryString;
			string userID = (string) Session["UserID"];

			if (tc=="" || tc==null || tc=="&nbsp;") 
			{
				queryString = VIEWNAME + " where (BR_CCOBRANCH = '" + LBL_BR_CCOBRANCH.Text + "' or BR_CCOBRANCH is NULL or BR_CCOBRANCH = '') " +
								" and AP_CHECKBIGROUP = (SELECT SG_GRPUNIT FROM SCGROUP WHERE GROUPID = '" + Session["GroupID"] + "') " +
								" and (AS_OFFICER is null OR AS_OFFICER = '' OR AS_OFFICER = '" + userID + 
								"' OR AS_OFFICER in (select USERID from VW_ASSIGNMENT_USER where (SU_UPLINER = '" + 
								userID + "' OR SU_MIDUPLINER = '" + 
								userID + "' OR SU_CORUPLINER = '" + 
								userID + "'))) ";
			}
			else
				queryString = VIEWNAME + " where (BR_CCOBRANCH = '" + LBL_BR_CCOBRANCH.Text + "' or BR_CCOBRANCH is NULL or BR_CCOBRANCH = '') " +
										" and AP_CURRTRACK = '" + tc + 
										"' and ((AS_OFFICER is NULL " + 
											"  or AS_OFFICER = '" + userID + 
											"' or AS_OFFICER = '' " + 
											"  or AS_OFFICER = '&nbsp;' " + 
											"  or AS_OFFICER in (select USERID from VW_ASSIGNMENT_USER where (SU_UPLINER = '" + userID + "' OR SU_MIDUPLINER = '" + userID + "' OR SU_CORUPLINER = '" + userID + "'))) " +
										"  and (LEADER is null OR LEADER = '' OR LEADER = '&nbsp' OR LEADER = '" + userID +
										"')) ";
			
			return queryString;
		}

		private void viewAllData() 
		{
			try 
			{
				conn.QueryString = getQueryString(LBL_TC.Text);
				conn.QueryString = conn.QueryString + " order by " + LBL_SORTEXP.Text + " " + LBL_SORTTYPE.Text;
				conn.ExecuteQuery();
			} 
			catch (NullReferenceException) 
			{
				Tools.popMessage(this, "Connection Error !");
				return;
			}

			DataTable dt = new DataTable();
			DataRow dr;
			dt.Columns.Add(new DataColumn("AP_REGNO"));
			dt.Columns.Add(new DataColumn("CU_REF"));
			dt.Columns.Add(new DataColumn("NAME"));
			dt.Columns.Add(new DataColumn("AP_SIGNDATE"));
			dt.Columns.Add(new DataColumn("AP_RELMNGR"));
			dt.Columns.Add(new DataColumn("BS_BIASSIGN"));
			dt.Columns.Add(new DataColumn("BS_COMPLETE"));

			//--- get data from database
			for (int i = 0; i < conn.GetRowCount(); i++) 
			{
				dr = dt.NewRow();
				//for (int j = 0; j < conn.GetColumnCount(); j++)
				for (int j = 0; j < 7; j++)
				{
					dr[j] = conn.GetFieldValue(i,j);
				}
				dt.Rows.Add(dr);
			}

			//--- bind data to datagrid
			DataGrid1.DataSource = new DataView(dt);
			try 
			{
				DataGrid1.DataBind();
			} 
			catch 
			{
				DataGrid1.CurrentPageIndex = 0;
				DataGrid1.DataBind();
			}

			//--- format date of datagrid
			bool isComplete = false;
			for (int i = 0; i < DataGrid1.Items.Count; i++) 
			{
				//mencari label pada page
				Label LBL_BS_ASSIGN = (Label) DataGrid1.Items[i].FindControl("LBL_BS_ASSIGN");
				Label LBL_BS_COMPLETE = (Label) DataGrid1.Items[i].FindControl("LBL_BS_COMPLETE");

				System.Web.UI.WebControls.Image IMG_BS_ASSIGN	= (System.Web.UI.WebControls.Image) DataGrid1.Items[i].FindControl("IMG_BS_ASSIGN"); 
				System.Web.UI.WebControls.Image IMG_BS_COMPLETE	= (System.Web.UI.WebControls.Image) DataGrid1.Items[i].FindControl("IMG_BS_COMPLETE"); 

				//menampilkan data tanggal dan menampilkannya ke DataGrid
				DataGrid1.Items[i].Cells[3].Text = tool.FormatDate(DataGrid1.Items[i].Cells[3].Text, true);

				isComplete = false;
				//--- Status Assignment Officer
				if (DataGrid1.Items[i].Cells[5].Text == "" || DataGrid1.Items[i].Cells[5].Text == "&nbsp;" || DataGrid1.Items[i].Cells[5].Text == "0") 
				{
					LBL_BS_ASSIGN.Text = "No";
					IMG_BS_ASSIGN.ImageUrl = "../image/UnComplete.gif";
				}
				else
				{
					LBL_BS_ASSIGN.Text = "Yes";
					IMG_BS_ASSIGN.ImageUrl = "../image/Complete.gif";

					if (DataGrid1.Items[i].Cells[5].Text == "2" && DataGrid1.Items[i].Cells[6].Text == "1") 
					{
						LBL_BS_COMPLETE.Text = "Yes";
						IMG_BS_COMPLETE.ImageUrl = "../image/Complete.gif";
						//isComplete = true;
					}
				}

				if (LBL_TC.Text == "") //--- dengan asumsi kalau TC kosong berarti status di BI Checking			
					DataGrid1.Columns[8].Visible = true;
				
				if (!isComplete) 
				{
					//--- Status Completion after assignment
					if (DataGrid1.Items[i].Cells[6].Text == "2") 
					{
						LBL_BS_COMPLETE.Text = "Yes";
						IMG_BS_COMPLETE.ImageUrl = "../image/Complete.gif";
					}
					else if (DataGrid1.Items[i].Cells[6].Text == "1") 
					{
						LBL_BS_COMPLETE.Text = "In Process";
						IMG_BS_COMPLETE.ImageUrl = "../image/UnComplete.gif";
					}
					else 
					{
						LBL_BS_COMPLETE.Text = "No";
						IMG_BS_COMPLETE.ImageUrl = "../image/UnComplete.gif";
					}
				}
			}
		}
		private void viewData() 
		{
			try 
			{
				conn.QueryString = getQueryString(LBL_TC.Text);
				conn.QueryString = conn.QueryString + " and " + DDL_FIND_KRITERIA.SelectedValue + " LIKE '%" + TXT_FIND_KRITERIA.Text.Trim() + "%' ";
				conn.QueryString = conn.QueryString + " order by " + LBL_SORTEXP.Text + " " + LBL_SORTTYPE.Text;
				conn.ExecuteQuery();
			} 
			catch (NullReferenceException) 
			{
				Tools.popMessage(this, "Connection Error !");
				return;
			}

			DataTable dt = new DataTable();
			DataRow dr;
			dt.Columns.Add(new DataColumn("AP_REGNO"));
			dt.Columns.Add(new DataColumn("CU_REF"));
			dt.Columns.Add(new DataColumn("NAME"));
			dt.Columns.Add(new DataColumn("AP_SIGNDATE"));
			dt.Columns.Add(new DataColumn("AP_RELMNGR"));
			dt.Columns.Add(new DataColumn("BS_BIASSIGN"));
			dt.Columns.Add(new DataColumn("BS_COMPLETE"));

			//--- get data from database
			for (int i = 0; i < conn.GetRowCount(); i++) 
			{
				dr = dt.NewRow();
				//for (int j = 0; j < conn.GetColumnCount(); j++)
				for (int j = 0; j < 7; j++)
				{
					dr[j] = conn.GetFieldValue(i,j);
				}
				dt.Rows.Add(dr);
			}

			//--- bind data to datagrid
			DataGrid1.DataSource = new DataView(dt);
			try 
			{
				DataGrid1.DataBind();
			} 
			catch 
			{
				DataGrid1.CurrentPageIndex = 0;
				DataGrid1.DataBind();
			}

			//--- format date of datagrid
			bool isComplete = false;
			for (int i = 0; i < DataGrid1.Items.Count; i++) 
			{
				Label LBL_BS_ASSIGN = (Label) DataGrid1.Items[i].FindControl("LBL_BS_ASSIGN");
				Label LBL_BS_COMPLETE = (Label) DataGrid1.Items[i].FindControl("LBL_BS_COMPLETE");

				System.Web.UI.WebControls.Image IMG_BS_ASSIGN	= (System.Web.UI.WebControls.Image) DataGrid1.Items[i].FindControl("IMG_BS_ASSIGN"); 
				System.Web.UI.WebControls.Image IMG_BS_COMPLETE	= (System.Web.UI.WebControls.Image) DataGrid1.Items[i].FindControl("IMG_BS_COMPLETE"); 

				DataGrid1.Items[i].Cells[3].Text = tool.FormatDate(DataGrid1.Items[i].Cells[3].Text, true);

				isComplete = false;
				//--- Status Assignment Officer
				if (DataGrid1.Items[i].Cells[5].Text == "" || DataGrid1.Items[i].Cells[5].Text == "&nbsp;" || DataGrid1.Items[i].Cells[5].Text == "0") 
				{
					LBL_BS_ASSIGN.Text = "No";
					IMG_BS_ASSIGN.ImageUrl = "../image/UnComplete.gif";
				}
				else
				{
					LBL_BS_ASSIGN.Text = "Yes";
					IMG_BS_ASSIGN.ImageUrl = "../image/Complete.gif";

					if (DataGrid1.Items[i].Cells[5].Text == "2" && DataGrid1.Items[i].Cells[6].Text == "1") 
					{
						LBL_BS_COMPLETE.Text = "Yes";
						IMG_BS_COMPLETE.ImageUrl = "../image/Complete.gif";
						isComplete = true;
					}
				}

				if (!isComplete) 
				{
					//--- Status Completion after assignment
					if (DataGrid1.Items[i].Cells[6].Text == "2") 
					{
						LBL_BS_COMPLETE.Text = "Yes";
						IMG_BS_COMPLETE.ImageUrl = "../image/Complete.gif";
					}
					else if (DataGrid1.Items[i].Cells[6].Text == "1") 
					{
						LBL_BS_COMPLETE.Text = "In Process";
						IMG_BS_COMPLETE.ImageUrl = "../image/UnComplete.gif";
					}
					else 
					{
						LBL_BS_COMPLETE.Text = "No";
						IMG_BS_COMPLETE.ImageUrl = "../image/UnComplete.gif";
					}
				}
			}
		}

		private void DataGrid1_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			string regno, curef, BS_COMPLETE, BS_BIASSIGN;
			switch(((LinkButton)e.CommandSource).CommandName)
			{
				case "View":
					regno = e.Item.Cells[0].Text.Trim();
					curef = e.Item.Cells[1].Text.Trim();
					BS_BIASSIGN = e.Item.Cells[5].Text.Trim();
					BS_COMPLETE = e.Item.Cells[6].Text.Trim();
					Response.Redirect("AssignmentDetail.aspx?regno=" + regno + "&curef="+curef + "&tc=" + Request.QueryString["tc"] + "&mc=" + Request.QueryString["mc"] + "&isassign=" + BS_BIASSIGN + "&iscomplete=" + BS_COMPLETE);
					break;
			}
		}

		private void DataGrid1_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			DataGrid1.CurrentPageIndex = e.NewPageIndex;
			viewData();
		}

		private void DataGrid1_SortCommand(object source, System.Web.UI.WebControls.DataGridSortCommandEventArgs e)
		{
			if (LBL_SORTTYPE.Text == "ASC")
				LBL_SORTTYPE.Text = "DESC";
			else
				LBL_SORTTYPE.Text = "ASC";
			LBL_SORTEXP.Text = e.SortExpression;
			viewData();
		}

		protected void BTN_FIND_Click(object sender, System.EventArgs e)
		{
			viewData();

			if (LBL_TC.Text == "") //--- dengan asumsi kalau TC kosong berarti status di BI Checking			
				DataGrid1.Columns[8].Visible = true;
		}
	}
}
