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
using Microsoft.VisualBasic;
using System.Configuration;

namespace SME.Assignment
{
	/// <summary>
	/// Summary description for Assignment
	/// </summary>
	public partial class AssignmentDetail : System.Web.UI.Page
	{

		protected Tools tool = new Tools();
		protected Connection conn;
		
		protected void Page_Load(object sender, System.EventArgs e)
		{			
			//conn = (Connection) Session["Connection"];
			conn = new Connection(ConfigurationSettings.AppSettings["conn"]);	
	
			if (!Logic.AllowAccess(Session["GroupID"].ToString(), Request.QueryString["mc"], conn))
				Response.Redirect("/SME/Restricted.aspx");

			if (!IsPostBack) 
			{
				LBL_AP_REGNO.Text		= Request.QueryString["regno"];
				LBL_CU_REF.Text			= Request.QueryString["curef"];
				LBL_BS_COMPLETE.Text	= Request.QueryString["iscomplete"];
				LBL_BS_BIASSIGN.Text	= Request.QueryString["isassign"];
				LBL_USERID.Text			= (string) Session["UserID"];
				LBL_TC.Text				= Request.QueryString["tc"];				

				fillPetugas();
				fillDepartemen();				
				
				cekAssignAndComplete();
				assignmentCheck();
			}

			ViewMenu();
			viewData();			

			BTN_ASSIGN.Attributes.Add("onclick", "if(!konfirAssign(document.Form1.DDL_PETUGAS)) {return false;};");
			BTN_ASSIGN_TEAM.Attributes.Add("onclick", "if(!konfirAssign(document.Form1.DDL_TEAM)) {return false;};");
			BTN_UPDATESTATUS.Attributes.Add("onclick", "if(!update()){return false;};");			

			if (BTN_RECHECK.Visible) LBL_DEBUG.Text = "Button ReCheck Visible!";
			else LBL_DEBUG.Text = "Button ReCheck NOT Visible!";
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

		}
		#endregion

		private void cekAssignAndComplete() 
		{
			try 
			{
				string query = "";
				if (Request.QueryString["tc"] == "" || Request.QueryString["tc"] == null)
					query = "select * from ASSIGNMENT_VIEW where TRACKCODE is NULL";
				else
					query = "select * from ASSIGNMENT_VIEW where TRACKCODE = '" + Request.QueryString["tc"] + "'";

				conn.QueryString = query;
				conn.ExecuteQuery();

				string ASV_VIEWNAME = conn.GetFieldValue("ASV_VIEWNAME");
				conn.QueryString = ASV_VIEWNAME + " where AP_REGNO = '" + LBL_AP_REGNO.Text + "'";
				conn.ExecuteQuery();

				LBL_BS_BIASSIGN.Text = conn.GetFieldValue("AS_ISASSIGN");
				LBL_BS_COMPLETE.Text = conn.GetFieldValue("ISCOMPLETE");

				if (LBL_BS_COMPLETE.Text == "1")	//--- aplikasi sedang proses			
				{
					BTN_CANCEL.Enabled = false;
				}

				if (LBL_BS_COMPLETE.Text == "2")	//--- aplikasi selesai proses			
				{
					BTN_CANCEL.Enabled			= false;
					BTN_UPDATESTATUS.Visible	= true;
					BTN_RECHECK.Visible			= true;
				}
			}
			catch (NullReferenceException) 
			{
				GlobalTools.popMessage(this, "Connection Error !");
				Response.Redirect("../Login.aspx?expire=1");
			}
		}

		private string getQuery(string tc) 
		{
			try 
			{
				if (tc == "" || tc == null || tc == "'&nbsp;'")
					conn.QueryString = "select ASV_STOREDPROC from ASSIGNMENT_VIEW where TRACKCODE is null";
				else
					conn.QueryString = "select ASV_STOREDPROC from ASSIGNMENT_VIEW where TRACKCODE = '" + tc + "'";
				conn.ExecuteQuery();
			} 
			catch (NullReferenceException) 
			{
				throw new Exception();
			}

			string queryString = conn.GetFieldValue("ASV_STOREDPROC");
			return queryString;
		}

		private DataRow getData() 
		{
			try 
			{				
				if (LBL_TC.Text == "" || LBL_TC.Text == null || LBL_TC.Text == "'&nbsp;'")
					conn.QueryString = "select ASV_OFF_FIELD, ASV_OFF_TABLE, ASV_NEEDVALID " + 
						"from ASSIGNMENT_VIEW where TRACKCODE is null";
				else
					conn.QueryString = "select ASV_OFF_FIELD, ASV_OFF_TABLE, ASV_NEEDVALID " + 
						"from ASSIGNMENT_VIEW where TRACKCODE = '" + LBL_TC.Text + "'";
				
				conn.ExecuteQuery();			
			} 
			catch (NullReferenceException) 
			{
				Tools.popMessage(this, "Connection Error !");
				return null;
			}

			return conn.GetDataTable().Rows[0];
		}

		private DataRow getDataDept() 
		{
			try 
			{				
				if (LBL_TC.Text == "" || LBL_TC.Text == null || LBL_TC.Text == "'&nbsp;'")
					conn.QueryString = "select ASV_DEPT_FIELD, ASV_DEPT_TABLE, ASV_NEEDVALID " + 
						"from ASSIGNMENT_VIEW where TRACKCODE is null";
				else
					conn.QueryString = "select ASV_DEPT_FIELD, ASV_DEPT_TABLE, ASV_NEEDVALID " + 
						"from ASSIGNMENT_VIEW where TRACKCODE = '" + LBL_TC.Text + "'";
				
				conn.ExecuteQuery();			
			} 
			catch (NullReferenceException) 
			{
				Tools.popMessage(this, "Connection Error !");
				return null;
			}

			return conn.GetDataTable().Rows[0];
		}


		private void assignmentCheck() 
		{
			if (LBL_BS_BIASSIGN.Text == "0" || LBL_BS_BIASSIGN.Text == "" || LBL_BS_BIASSIGN.Text == "'&nbsp'") 
			{
				setOfficerStatus(false);
				assignmentTeamCheck();
			}
			else 
			{
				//--- kalau petugas sudah diassign, departemen tidak perlu assignment
				DDL_TEAM.Enabled = false;
				BTN_ASSIGN_TEAM.Enabled = false;

				try 
				{
					DataRow dr = getData();					
					conn.QueryString = "select " + dr["ASV_OFF_FIELD"].ToString() + 
						" from " + dr["ASV_OFF_TABLE"].ToString() + 
						" where AP_REGNO = '" + LBL_AP_REGNO.Text + "'";
					conn.ExecuteQuery();

					if (conn.GetFieldValue(dr["ASV_OFF_FIELD"].ToString()) != "") 
					{
					
						try { DDL_PETUGAS.SelectedValue = conn.GetFieldValue(dr["ASV_OFF_FIELD"].ToString()); } 
						catch 
						{ 
							/// Yudi: kalau tidak ada petugas terdefinisi dan status masih dalam process
							/// (karena deleted atau beda co manager), 
							/// biarkan co manager utk cancel assignment
							/// 
							if (LBL_BS_COMPLETE.Text == "1") BTN_CANCEL.Enabled = true; 
						}  

						if (dr["ASV_NEEDVALID"].ToString() == "1")	//--- yang butuh validasi: BI Checking
						{
							if (LBL_BS_BIASSIGN.Text == "0" || LBL_BS_BIASSIGN.Text == "" || LBL_BS_BIASSIGN.Text == "'&nbsp'") 
								setOfficerStatus(false);							
							else 
								setOfficerStatus(true);
						}
						else 
						{
							DDL_PETUGAS.Enabled = false;
							BTN_ASSIGN.Enabled = false;
						}
					}
				} 
				catch (NullReferenceException) 
				{
					GlobalTools.popMessage(this, "Connection Error !");
					Response.Redirect("../Login.aspx?expire=1");
				}
			}
			
		}

		private void fillDepartemen() 
		{
			string userID, fullName, branchID, groupID;

			userID		= (string) Session["UserID"];
			fullName	= (string) Session["FullName"];
			branchID	= (string) Session["BranchID"];
			groupID		= (string) Session["GroupID"];

			DDL_TEAM.Items.Add(new ListItem(fullName, userID));
			//GlobalTools.fillRefList(DDL_TEAM, "select USERID, SU_FULLNAME from SCUSER where SU_BRANCH = '" + branchID + "' and GROUPID = '" + groupID + "'", false, conn);
			GlobalTools.fillRefList(DDL_TEAM, "exec ASSIGN_TEAMDEPARTEMEN '" + branchID + "', '" + userID + "'", false, conn);
		}

		private void fillPetugas() 
		{
			string userID, fullName, groupid;
			userID = (string) Session["UserID"];
			fullName = (string) Session["FullName"];
			groupid = (string) Session["GroupID"];

			//GlobalTools.fillRefList(DDL_PETUGAS, "select * from VW_ASSIGNMENT_USER where (SU_UPLINER = '" + LBL_USERID.Text + "' OR SU_MIDUPLINER = '" + LBL_USERID.Text + "')", false, conn);
			//DDL_PETUGAS.Items.Add(new ListItem(fullName, userID));			

			string op = "= '" + LBL_TC.Text + "'";
			if (LBL_TC.Text == "" || LBL_TC.Text== null || LBL_TC.Text== "'&nbsp;'") 
			{
				op = "is null";
			}

			GlobalTools.fillRefList(DDL_PETUGAS, "select * from VW_ASSIGNMENT_USER where (SU_UPLINER = '" + userID + "' OR SU_MIDUPLINER = '" + userID + "' OR SU_CORUPLINER = '" + userID + "') " + 
				"and GROUPID in (select distinct GROUPID from GRPACCESSMENU where MENUCODE in ( " +
				"select MENUCODE from TRACK_MENU where TRACKCODE " + op + " )) " +
				"union select '" + userID + "' as userid, '" + fullName + "' as su_fullname, null as su_upliner, null as su_midupliner, null as su_corupliner, '" + groupid + "' as groupid " +
				"order by GROUPID ", false, conn);			
		}

		private void viewData() 
		{
			conn.QueryString = "select VW_INFOUMUM.*, bi.BS_BIDATAAVAIL "+
				"from VW_INFOUMUM left join bi_status bi on VW_INFOUMUM.ap_regno = bi.ap_regno "+
				"where VW_INFOUMUM.AP_REGNO = '"+ Request.QueryString["regno"].Trim() +"' ";
			conn.ExecuteQuery();
			TXT_AP_REGNO.Text = conn.GetFieldValue("AP_REGNO");
			TXT_CU_REF.Text = conn.GetFieldValue("CU_REF");
			string AP_SIGNDATE = conn.GetFieldValue("AP_SIGNDATE");
			TXT_AP_SIGNDATE.Text = tool.FormatDate(AP_SIGNDATE);
			TXT_PROGRAMDESC.Text = conn.GetFieldValue("PROGRAMDESC");
			TXT_BRANCH_NAME.Text = conn.GetFieldValue("BRANCH_NAME");
			TXT_AP_TMLDRNM.Text = conn.GetFieldValue("AP_TMLDRNM");
			TXT_AP_RMNM.Text = conn.GetFieldValue("AP_RMNM");
			TXT_BU_DESC.Text = conn.GetFieldValue("BU_DESC");
			TXT_CU_NAME.Text = conn.GetFieldValue("CU_NAME");
			TXT_CU_ADDR1.Text = conn.GetFieldValue("CU_ADDR1");
			TXT_CU_ADDR2.Text = conn.GetFieldValue("CU_ADDR2");
			TXT_CU_ADDR3.Text = conn.GetFieldValue("CU_ADDR3");
			TXT_CU_CITYNM.Text = conn.GetFieldValue("CU_CITYNM");
			TXT_CU_PHN.Text = conn.GetFieldValue("CU_PHN");
			TXT_BUSSTYPEDESC.Text = conn.GetFieldValue("BUSSTYPEDESC");
		}

		private void ViewMenu()
		{
			try 
			{			
				conn.QueryString = "select * from SCREENMENU where menucode = '"+Request.QueryString["mc"]+"'";
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
							strtemp = "regno=" + Request.QueryString["regno"] + "&curef="+Request.QueryString["curef"]+"&tc="+Request.QueryString["tc"].ToString().Trim();
						else	strtemp = "regno=" + Request.QueryString["regno"] + "&curef="+Request.QueryString["curef"]+ "&tc="+Request.QueryString["tc"].ToString().Trim() + "&mc="+Request.QueryString["mc"];
						//t.ForeColor = Color.MidnightBlue; 

						if (conn.GetFieldValue(i,3).IndexOf("?iscomplete=") < 0 && conn.GetFieldValue(i,3).IndexOf("&iscomplete=") < 0)
							strtemp = strtemp + "&iscomplete=" + Request.QueryString["iscomplete"];

						if (conn.GetFieldValue(i,3).IndexOf("?isassign=") < 0 && conn.GetFieldValue(i,3).IndexOf("&isassign=") < 0)
							strtemp = strtemp + "&isassign=" + Request.QueryString["isassign"];
					}
					else 
					{
						strtemp = "";
						t.ForeColor = Color.Red; 
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

		protected void BTN_ASSIGN_Click(object sender, System.EventArgs e)
		{
			if (DDL_PETUGAS.SelectedValue == "") 
			{
				GlobalTools.popMessage(this, "Officer tidak boleh kosong!");
				return;
			}

			setOfficerStatus(true);

			//--- Assign petugas
			conn.QueryString = getQuery(LBL_TC.Text) + " '" + TXT_AP_REGNO.Text+"','"+TXT_CU_REF.Text+"', '" + DDL_PETUGAS.SelectedValue + "', '1'";
			conn.ExecuteNonQuery();


			// ------------ Start AUDIT TRAIL ---------------------
			string trackcode = "";
			string trackname = "";
			string approvalflag = "N";

			// mengambil trackcode/trackname
			if (LBL_TC.Text == "" || LBL_TC.Text == null || LBL_TC.Text == "'&nbsp;'") 
			{
				trackcode = "";
				trackname = "BI Checking";
			}
			else 
			{
				trackcode = LBL_TC.Text;
				conn.QueryString = "select TRACKNAME from RFTRACK where TRACKCODE = '" + trackcode + "'";
				conn.ExecuteQuery();
				if (conn.GetRowCount() > 0) trackname = conn.GetFieldValue("TRACKNAME");
			}

			// mengambil approval flag
			conn.QueryString = "select FLAG from VW_APPROVAL_ISAPPRVTRACK where trackcode = '" + LBL_TC.Text + "'";
			conn.ExecuteQuery();
			if (conn.GetRowCount() > 0) approvalflag = conn.GetFieldValue("FLAG");

			// insert into database
			string team = "";
			try { team = (DDL_TEAM.SelectedValue == ""?"(empty)":DDL_TEAM.SelectedItem.Text); } 
			catch {}

			conn.QueryString = "exec SP_AUDITTRAIL_APP '" + 
				TXT_AP_REGNO.Text + "', " + 
				" NULL, NULL, NULL, '" + 
				TXT_CU_REF.Text + "', " + 
				GlobalTools.ConvertNull(trackcode) + ", '" + trackname + TXT_AUDITDESC.Text + DDL_PETUGAS.SelectedItem.Text +", Team Leader/Department Manager - " + team + "', '" + 
				DDL_PETUGAS.SelectedItem.Text + "', '" + 
				LBL_USERID.Text + "', NULL, '" + 
				approvalflag + "', '" + 
				trackname + "'";			
			conn.ExecuteNonQuery();		
			// ------------ end AUDIT TRAIL ---------------------
			

			//--- setelah meng-assign petugas, kembali ke list
			Response.Redirect("AssignmentList.aspx?mc=" + Request.QueryString["mc"] + "&tc=" + LBL_TC.Text);
		}

		protected void BTN_CANCEL_Click(object sender, System.EventArgs e)
		{
			setOfficerStatus(false);

			/***
			conn.QueryString = "exec CO_BIASSIGN '"+TXT_AP_REGNO.Text+"','"+TXT_CU_REF.Text+"', '" + DDL_PETUGAS.SelectedValue + "', null";
			conn.ExecuteNonQuery();
			***/

			//--- modif by Yudi
			conn.QueryString = getQuery(LBL_TC.Text) + " '" + TXT_AP_REGNO.Text+"','"+TXT_CU_REF.Text+"', '" + DDL_PETUGAS.SelectedValue + "', '0'";
			conn.ExecuteNonQuery();
		}	

		private void setOfficerStatus(bool isAssigned) 
		{
			if (isAssigned) 
			{
				DDL_PETUGAS.Enabled = false;
				BTN_ASSIGN.Enabled = false;
				BTN_CANCEL.Visible = true;
			}
			else 
			{
				DDL_PETUGAS.Enabled			= true;
				BTN_ASSIGN.Enabled			= true;
				BTN_CANCEL.Visible			= false;
				//BTN_UPDATESTATUS.Visible	= false;
				//BTN_RECHECK.Visible			= false;
			}
		}

		private void assignmentTeamCheck() 
		{
			try 
			{
				DataRow dr = getDataDept();					
				conn.QueryString = "select isnull(" + dr["ASV_DEPT_FIELD"].ToString() + ",'') as " + dr["ASV_DEPT_FIELD"].ToString() +
					" from " + dr["ASV_DEPT_TABLE"].ToString() + 
					" where AP_REGNO = '" + LBL_AP_REGNO.Text + "'";
				conn.ExecuteQuery();

				if (conn.GetFieldValue(dr["ASV_DEPT_FIELD"].ToString()) != "")									
					DDL_TEAM.SelectedValue = conn.GetFieldValue(dr["ASV_DEPT_FIELD"].ToString());				
			} 
			catch (NullReferenceException) 
			{
				GlobalTools.popMessage(this, "Connection Error !");
				Response.Redirect("../Login.aspx?expire=1");
			}
		}

		private void setDeptStatus(bool isAssigned) 
		{
			if (isAssigned) 
			{
				DDL_TEAM.Enabled = false;
				BTN_ASSIGN_TEAM.Enabled = false;				
			}
			else 
			{
				DDL_TEAM.Enabled = true;
				BTN_ASSIGN_TEAM.Enabled = true;
			}
		}


		protected void BTN_UPDATESTATUS_Click(object sender, System.EventArgs e)
		{
			/***
			conn.QueryString = "update BI_STATUS set BS_COOFFICER='" + Session["UserID"].ToString() +
				"', BS_COMPLETE='2', BS_VALIDDATE = getdate() where AP_REGNO='" + Request.QueryString["regno"] + "'";
			conn.ExecuteNonQuery();
			***/

			
			try 
			{
				conn.QueryString = "update BI_STATUS set BS_COOFFICER='" + Session["UserID"].ToString() +
					"', BS_COMPLETE='2', BS_VALIDDATE = getdate() where AP_REGNO='" + Request.QueryString["regno"] + "'";
				conn.ExecuteNonQuery();
			} 
			catch (NullReferenceException) 
			{
				GlobalTools.popMessage(this, "Connection Error !");
				Response.Redirect("../Login.aspx?expire=1");
			}

			Response.Redirect("AssignmentList.aspx?mc=" + Request.QueryString["mc"] + "&tc=" + LBL_TC.Text);
		}

		protected void BTN_BACK_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			Response.Redirect("/SME/Assignment/AssignmentList.aspx?tc=" + Request.QueryString["tc"] + "&mc=" + Request.QueryString["mc"]);
			//Response.Redirect("/SME/" + DMS.CuBESCore.Logic.backLink(Request.QueryString["tc"].ToString(), conn));

		}

		protected void BTN_ASSIGN_TEAM_Click(object sender, System.EventArgs e)
		{
			if (DDL_TEAM.SelectedValue == "") 
			{
				GlobalTools.popMessage(this, "Team/Department tidak boleh kosong!");
				return;
			}

			try 
			{
				//--- Assign team/departemen
				conn.QueryString = getQuery(LBL_TC.Text) + " '" + TXT_AP_REGNO.Text+"','"+TXT_CU_REF.Text+"', '" + DDL_TEAM.SelectedValue + "', '2'";
				conn.ExecuteNonQuery();
			} 
			catch (NullReferenceException) 
			{
				GlobalTools.popMessage(this, "Connection Error !");
				Response.Redirect("../Login.aspx?expire=1");				
			}

			try 
			{
				// ------------ Start AUDIT TRAIL ---------------------
				string trackcode = "";
				string trackname = "";
				string approvalflag = "N";

				// mengambil trackcode/trackname
				if (LBL_TC.Text == "" || LBL_TC.Text == null || LBL_TC.Text == "'&nbsp;'") 
				{
					trackcode = "";
					trackname = "BI Checking";
				}
				else 
				{
					trackcode = LBL_TC.Text;
					conn.QueryString = "select TRACKNAME from RFTRACK where TRACKCODE = '" + trackcode + "'";
					conn.ExecuteQuery();
					if (conn.GetRowCount() > 0) trackname = conn.GetFieldValue("TRACKNAME");
				}

				// mengambil approval flag
				conn.QueryString = "select FLAG from VW_APPROVAL_ISAPPRVTRACK where trackcode = '" + LBL_TC.Text + "'";
				conn.ExecuteQuery();
				if (conn.GetRowCount() > 0) approvalflag = conn.GetFieldValue("FLAG");

				// insert into database
				string officer = (DDL_PETUGAS.SelectedValue == ""?"(empty)":DDL_PETUGAS.SelectedItem.Text);

				conn.QueryString = "exec SP_AUDITTRAIL_APP '" + 
					TXT_AP_REGNO.Text + "', " + 
					" NULL, NULL, NULL, '" + 
					TXT_CU_REF.Text + "', " + 
					GlobalTools.ConvertNull(trackcode) + ", '" + trackname + TXT_AUDITDESC.Text + officer +", Team Leader/Department Manager - " + DDL_TEAM.SelectedItem.Text + "', '" + 
					DDL_PETUGAS.SelectedItem.Text + "', '" + 
					LBL_USERID.Text + "', NULL, '" + 
					approvalflag + "', '" + 
					trackname + "'";			
				conn.ExecuteNonQuery();		
				// ------------ end AUDIT TRAIL ---------------------
			} 
			catch (Exception ex)
			{
				Response.Write("<!-- AuditTrail Error: " + ex.Message + " -->");
			}

			//--- setelah meng-assign petugas, kembali ke list
			Response.Redirect("AssignmentList.aspx?mc=" + Request.QueryString["mc"] + "&tc=" + LBL_TC.Text);			
		}

		protected void BTN_RECHECK_Click(object sender, System.EventArgs e)
		{
			try 
			{
				conn.QueryString = "update BI_STATUS set BS_COMPLETE='1' where AP_REGNO = '" + LBL_AP_REGNO.Text + "'";
				conn.ExecuteNonQuery();
			} 
			catch (NullReferenceException) 
			{
				GlobalTools.popMessage(this, "Connection Error !");
				Response.Redirect("../Login.aspx?expire=1");
			}

			//--- setelah meng-assign petugas, kembali ke list
			Response.Redirect("AssignmentList.aspx?mc=" + Request.QueryString["mc"] + "&tc=" + LBL_TC.Text);			
		}
	}
}
