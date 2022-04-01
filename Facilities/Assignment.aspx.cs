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

namespace SME.Facilities
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
				Response.Redirect("/SME/Restricted.aspx");

			if (!IsPostBack)
			{
				GlobalTools.fillRefList(DDL_BRANCH_CODE, "exec ASSIGN_GETBRANCH '" + (string)Session["UserID"] + "' ", conn);
				GlobalTools.fillRefList(DDL_USERID, "exec ASSIGN_GETBRANCHUSERS '" + (string)Session["UserID"] + "', '" + DDL_BRANCH_CODE.SelectedValue + "' ", conn);
				GlobalTools.fillRefList(DDL_AP_RM, "exec ASSIGN_GETLISTRM '" + (string)Session["UserID"] + "' ", conn);
				GlobalTools.fillRefList(DDL_AP_CO, "exec ASSIGN_GETLISTCO '" + (string)Session["UserID"] + "' ", conn);
				GlobalTools.fillRefList(DDL_AP_CA, "exec ASSIGN_GETLISTCA '" + (string)Session["UserID"] + "' ", conn);
				GlobalTools.fillRefList(DDL_PRRK, "exec ASSIGN_GETLISTPRRK '" + (string)Session["UserID"] + "' ", conn);
				GlobalTools.fillRefList(DDL_AP_APRVCOMMITEE, "exec ASSIGN_GETLISTAPRVCOMMITEE '" + (string)Session["UserID"] + "' ", conn);
				GlobalTools.fillRefList(DDL_AP_REGNO, "exec ASSIGN_GETCUSTAPP '" + (string)Session["UserID"] + "', '" + Request.QueryString["curef"] + "'", conn);
				//20070806 add by sofyan for CCO Branch
				GlobalTools.fillRefList(DDL_AP_CCOBRANCH, "exec ASSIGN_GETLISTCCOBRANCH '" + (string)Session["UserID"] + "' ", conn);

				try { DDL_AP_REGNO.SelectedValue = Request.QueryString["regno"]; } catch {}
				DDL_AP_REGNO_SelectedIndexChanged(sender, e);
				
				/*DDL_BRANCH_CODE.Items.Add(new ListItem("- PILIH -", ""));
				DDL_USERID.Items.Add(new ListItem("- PILIH -", ""));
				DDL_AP_RM.Items.Add(new ListItem("- PILIH -", ""));
				DDL_AP_CO.Items.Add(new ListItem("- PILIH -", ""));
				DDL_AP_CA.Items.Add(new ListItem("- PILIH -", ""));
				DDL_AP_REGNO.Items.Add(new ListItem("- PILIH -", ""));
				DDL_PRRK.Items.Add(new ListItem("- PILIH -", ""));
				*/

				//conn.QueryString = "select branch_code, branch_name from rfbranch where active ='1' order by branch_name ";
				/*conn.QueryString = "exec ASSIGN_GETBRANCH '" + (string)Session["UserID"] + "' ";
				conn.ExecuteQuery();
				for (int i = 0; i < conn.GetRowCount(); i++)
					DDL_BRANCH_CODE.Items.Add(new ListItem(conn.GetFieldValue(i,1), conn.GetFieldValue(i,0)));
					*/

				conn.QueryString = "select nama, su_fullname, branch_name from vw_findcustomer where cu_ref='" + Request.QueryString["curef"] + "'";
				conn.ExecuteQuery();
				TXT_FULLNAME.Text = conn.GetFieldValue(0,"nama");
				TXT_CU_RM.Text = conn.GetFieldValue(0, "su_fullname");
				TXT_CU_BRANCHNAME.Text = conn.GetFieldValue(0, "branch_name");

				//conn.QueryString = "select ap_regno from application where cu_ref='" + Request.QueryString["curef"] + "'";
				/*conn.QueryString = "exec ASSIGN_GETCUSTAPP '" + (string)Session["UserID"] + "', '" + Request.QueryString["curef"] + "'";
				conn.ExecuteQuery();
				for (int i = 0; i < conn.GetRowCount(); i++)
					// Text = Regno, Value = Branch 
					DDL_AP_REGNO.Items.Add(new ListItem(conn.GetFieldValue(i,0), conn.GetFieldValue(i,0)));
				*/
				/*conn.QueryString = "select in_branchpusat from rfinitial";
				conn.ExecuteQuery();
				CheckUserLoggedIn(conn.GetFieldValue("in_branchpusat"));
				*/
				CheckUserLoggedIn();
				Button2.Attributes.Add("onclick","if(!cek_mandatory(document.Form1)){return false;};");
				Button1.Attributes.Add("onclick", "if(!cek_mandatory2(document.Form1)){return false;};");

			}
		}

		private void CheckUserLoggedIn()
		{
			disableDDL();
			conn.QueryString = "EXEC ASSIGN_GETUSERTYPE '" + (string) Session["UserID"] + "' ";
			conn.ExecuteQuery();
			string busunit = conn.GetFieldValue(0,"BUSUNIT"), 
				coFlag = conn.GetFieldValue(0,"CO"), 
				caFlag = conn.GetFieldValue(0,"CA"), 
				rmFlag = conn.GetFieldValue(0,"RM"), 
				curmFlag = conn.GetFieldValue(0,"CU_RM"), 
				prrkFlag = conn.GetFieldValue(0,"PRRK"),
				aprvcommFlag = conn.GetFieldValue(0,"APRVCOMMITEE");

			if (coFlag == "1")
				setCOMode(true);
			if (caFlag == "1")
				setCAMode(true);
			if (rmFlag == "1")
				setRMMode(true);
			if (curmFlag == "1")
				setCuRMMode(true);
			if (prrkFlag == "1")
				setPRRKMode(true);
			if (aprvcommFlag == "1")
				setAPRVCOMMITEEMode(true);
		}

		private void CheckUserLoggedIn(string in_branchpusat)
		{
			conn.QueryString = "select grp_co from app_parameter";
			conn.ExecuteQuery();
			string grpCO = conn.GetFieldValue("grp_co");

			conn.QueryString = "select sg_grpunit from scgroup where groupid = '" + Session["GroupID"] + "'";
			conn.ExecuteQuery();
			string vSG_GRPUNIT = conn.GetFieldValue("sg_grpunit");

			// If orang pusat
			if (in_branchpusat == Session["BranchID"].ToString())
			{
				DDL_PRRK.Enabled = true;
			}
			// If Group CO
			//else if (grpCO == Session["GroupID"].ToString())
			else if (vSG_GRPUNIT == "CO")
			{
				DDL_AP_CA.Enabled = false;
				DisableRM();
			}
			// If grouop PRRK
			else if (Session["GroupID"].ToString().Substring(0,2) == "02")
			{
				DisableRM();
				//DDL_PRRK.Enabled = true;
				DDL_AP_CA.Enabled = false;
				DDL_AP_CO.Enabled = false;
			}
			// If Other
			else //if (Session["GroupID"].ToString().Substring(0,2) == "01")
			{
				DDL_AP_CO.Enabled = false;
			}
		}

		private void setCOMode(bool mode)
		{
			DDL_AP_REGNO.Enabled = mode;
			DDL_AP_CO.Enabled = mode;
		}

		private void setCAMode(bool mode)
		{
			DDL_AP_REGNO.Enabled = mode;
			DDL_AP_CA.Enabled = mode;
		}

		private void setRMMode(bool mode)
		{
			//DDL_BRANCH_CODE.Enabled = mode;
			//DDL_USERID.Enabled = mode;
			DDL_AP_REGNO.Enabled = mode;
			DDL_AP_RM.Enabled = mode;
			DDL_AP_CCOBRANCH.Enabled = mode;
			//DDL_AP_CA.Enabled = mode;
		}

		private void setCuRMMode(bool mode)
		{
			DDL_BRANCH_CODE.Enabled = mode;
			DDL_USERID.Enabled = mode;
			//DDL_AP_REGNO.Enabled = mode;
			//DDL_AP_RM.Enabled = mode;
			//DDL_AP_CA.Enabled = mode;
		}

		private void setPRRKMode(bool mode)
		{
			DDL_AP_REGNO.Enabled = mode;
			DDL_PRRK.Enabled = mode;
		}

		private void setAPRVCOMMITEEMode(bool mode)
		{
			DDL_AP_REGNO.Enabled = mode;
			DDL_AP_APRVCOMMITEE.Enabled = mode;
		}

		private void disableDDL()
		{
			DDL_BRANCH_CODE.Enabled = false;
			DDL_USERID.Enabled = false;
			DDL_AP_REGNO.Enabled = false;
			DDL_AP_RM.Enabled = false;
			DDL_AP_CO.Enabled = false;
			DDL_AP_CA.Enabled = false;
			DDL_PRRK.Enabled = false;
			DDL_AP_APRVCOMMITEE.Enabled = false;
			//20070806 add by sofyan for CCO Branch
			DDL_AP_CCOBRANCH.Enabled = false;
		}

		private void DisableRM()
		{
			DDL_BRANCH_CODE.Enabled = false;
			DDL_USERID.Enabled = false;
		}

		private void DisableCOCA()
		{
			DDL_AP_REGNO.Enabled = false;
			DDL_AP_CO.Enabled = false;
			DDL_AP_CA.Enabled = false;
		}

		private void loadAppData()
		{
			conn.QueryString = "select * from vw_assignment_app where ap_regno='" + DDL_AP_REGNO.SelectedValue + "'";
			conn.ExecuteQuery();
			if (conn.GetRowCount() <= 0)
				return;

			string branchName = conn.GetFieldValue(0,"branch_name"), 
				ca_fullname = conn.GetFieldValue(0,"ca_fullname"),
				co_fullname = conn.GetFieldValue(0,"co_fullname"),
				rm_fullname = conn.GetFieldValue(0,"rm_fullname"),
				pic_fullname = conn.GetFieldValue(0,"ap_aprvcommiteename"),
				ap_ca = conn.GetFieldValue(0,"ap_ca"),
				ap_co = conn.GetFieldValue(0,"ap_co"),
				ap_rm = conn.GetFieldValue(0,"ap_relmngr"),
				ap_pic = conn.GetFieldValue(0,"ap_aprvcommitee"),
				ap_currtrack = conn.GetFieldValue(0,"ap_currtrack"),
				trackname = conn.GetFieldValue(0,"trackname"),
				ap_currtrack_code = conn.GetFieldValue(0,"ap_currtrack"),
				CCOBranch = conn.GetFieldValue(0,"br_ccobranch"),
				branchCode = conn.GetFieldValue(0,"branch_code"),
				CBCCode = conn.GetFieldValue(0,"CBC_CODE");
				
			Label1.Text = conn.GetFieldValue(0,"ap_currtrack");
				
			TXT_PRRK.Text = conn.GetFieldValue(0,"AP_PRRKBYNAME");
			try
			{
				DDL_PRRK.SelectedIndex = 0;
				DDL_PRRK.SelectedValue = conn.GetFieldValue(0,"AP_PRRKBY");
			}
			catch {}

			TXT_BRANCH_NAME.Text = branchName;
			TXT_CUR_CA.Text = ca_fullname;
			TXT_CUR_CO.Text = co_fullname;
			TXT_CUR_RM.Text = rm_fullname;
			TXT_AP_APRVCOMMITEE.Text = pic_fullname;
			try
			{
				DDL_AP_RM.SelectedIndex = 0;
				DDL_AP_RM.SelectedValue = ap_rm;
			}
			catch {}
			try
			{
				DDL_AP_CO.SelectedIndex = 0;
				DDL_AP_CO.SelectedValue = ap_co;
			}
			catch {}
			try
			{
				DDL_AP_CA.SelectedIndex = 0;
				DDL_AP_CA.SelectedValue = ap_ca;
			}
			catch {}
			try
			{
				DDL_AP_APRVCOMMITEE.SelectedIndex = 0;
				DDL_AP_APRVCOMMITEE.SelectedValue = ap_pic;
			}
			catch {}
			TXT_TRACK.Text = ap_currtrack + " - " + trackname;

			//20070806 add by sofyan, for CCO Branch
			try
			{
				DDL_AP_CCOBRANCH.SelectedIndex = 0;
				DDL_AP_CCOBRANCH.SelectedValue = CCOBranch;
			}
			catch {}
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

		protected void DDL_BRANCH_CODE_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			GlobalTools.fillRefList(DDL_USERID, "exec ASSIGN_GETBRANCHUSERS '" + (string)Session["UserID"] + "', '" + DDL_BRANCH_CODE.SelectedValue + "' ", conn);
			/*DDL_USERID.Items.Clear();
			DDL_USERID.Items.Add(new ListItem("- PILIH -", ""));
			if (DDL_BRANCH_CODE.SelectedValue == (string) Session["BranchID"])
			{
				//conn.QueryString = "select userid, su_fullname from scuser where su_branch = '" + DDL_BRANCH_CODE.SelectedValue + "' order by su_fullname";
				conn.QueryString = "exec ASSIGN_GETBRANCHUSERS '" + (string)Session["UserID"] + "', '" + DDL_BRANCH_CODE.SelectedValue + "' ";
				conn.ExecuteQuery();
				for (int i = 0; i < conn.GetRowCount(); i++)
					DDL_USERID.Items.Add(new ListItem(conn.GetFieldValue(i,1), conn.GetFieldValue(i,0)));
			}
			*/
		}

		protected void DDL_AP_REGNO_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			/*
			DDL_PRRK.Items.Clear();
			DDL_PRRK.Items.Add(new ListItem("- PILIH -", ""));
			DDL_AP_RM.Items.Clear();
			DDL_AP_RM.Items.Add(new ListItem("- PILIH -", ""));
			DDL_AP_CO.Items.Clear();
			DDL_AP_CO.Items.Add(new ListItem("- PILIH -", ""));
			DDL_AP_CA.Items.Clear();
			DDL_AP_CA.Items.Add(new ListItem("- PILIH -", ""));
			*/
			if (DDL_AP_REGNO.SelectedValue.Trim() != "")
			{
				loadAppData();
				/*
				conn.QueryString	= "select * from rfinitial";
				conn.ExecuteQuery();
				string var_small			= conn.GetFieldValue("in_small");
				string var_middle			= conn.GetFieldValue("in_middle");
				string var_corp				= conn.GetFieldValue("in_corporate");
				string var_inbranch			= conn.GetFieldValue("in_branchpusat");
				string in_prrk				= conn.GetFieldValue("in_prrk");
				string in_sgprrk			= conn.GetFieldValue("in_sgprrk");

				conn.QueryString = "select ap_complevel, isnull(limitexposure,0) + sum(cp_limit) as limitexposure, "+
					" application.branch_code, application.areaid, cbc_code from application "+
					" left join customer on application.cu_ref = customer.cu_ref "+
					" left join custproduct on application.ap_regno = custproduct.ap_regno "+
					" left join rfbranch on application.branch_code = rfbranch.branch_code "+
					" where application.ap_regno = '"+DDL_AP_REGNO.SelectedValue+"' "+
					" group by ap_complevel, limitexposure, application.branch_code, application.areaid, cbc_code ";
				conn.ExecuteQuery();
				string var_complevel	= conn.GetFieldValue("ap_complevel");
				//double var_limitexp	= Convert.ToDouble(conn.GetFieldValue("limitexposure"));
				string var_appbranch	= conn.GetFieldValue("branch_code");
				string var_area		= conn.GetFieldValue("areaid");
				string var_cbc			= conn.GetFieldValue("cbc_code");

				if (Session["BranchID"].ToString() == var_inbranch)
				{
					conn.QueryString = "select * from vw_approvaluser where substring(groupid,1,2) = '02' order by userfullnm";
					conn.ExecuteQuery();
					for (int i = 0; i < conn.GetRowCount(); i++)
						DDL_PRRK.Items.Add(new ListItem(conn.GetFieldValue(i,2),conn.GetFieldValue(i,0)));
				}
				else
				{
					//find user in the same group
					conn.QueryString = "select * from vw_approvaluser where groupid = '"+Session["GROUPID"].ToString()+"' "+
						" and (usercbc = '"+var_cbc+"' or userbranch = '"+var_inbranch+"') "+
						" and su_active = '1' order by userfullnm";
					conn.ExecuteQuery();			
					for (int i = 0; i < conn.GetRowCount();i++)
						DDL_PRRK.Items.Add(new ListItem(conn.GetFieldValue(i,2),conn.GetFieldValue(i,0)));

				
					// Group PRRK
					conn.QueryString = "select * from vw_approvaluser where groupid = '"+in_sgprrk+"' "+
						" and (usercbc = '"+var_cbc+"' or userbranch = '"+var_inbranch+"') "+
						" and su_active = '1' order by userfullnm";
					conn.ExecuteQuery();			
					for (int i = 0; i < conn.GetRowCount();i++)
						DDL_PRRK.Items.Add(new ListItem(conn.GetFieldValue(i,2),conn.GetFieldValue(i,0)));
				
					//find upliner
					//string sgmitra, sgup;
					conn.QueryString = "select * from vw_approvaluser where userid = '"+Session["USERID"].ToString()+"'";
					conn.ExecuteQuery();
					double var_userlimit = Convert.ToDouble(conn.GetFieldValue("userlimit"));
					
					string sgupawal = Session["GROUPID"].ToString();
					string sgup = "(";
					string koma = "";
					while (sgupawal != "") 
					{
						if (var_complevel == var_small)
						{
							conn.QueryString = "select distinct smlupgroup from vw_approvaluser where groupid = '"+sgupawal+"'"+
								" and (usercbc = '"+var_cbc+"' or userbranch = '"+var_inbranch+"') "+
								" and su_active = '1' ";
							conn.ExecuteQuery();
		
							if (conn.GetRowCount() == 0)
								sgupawal = "";

							for (int i = 0; i < conn.GetRowCount();i++)
							{
								if (conn.GetFieldValue(i,"smlupgroup") != "")
								{
									sgup = sgup + koma + "'"+conn.GetFieldValue(i,"smlupgroup")+"'";	
									koma = ",";
								}
								sgupawal = conn.GetFieldValue(i,"smlupgroup");
							}
						}
						else if (var_complevel == var_middle)
						{
							conn.QueryString = "select distinct midupgroup from vw_approvaluser where groupid = '"+sgupawal+"'"+
								" and (usercbc = '"+var_cbc+"' or userbranch = '"+var_inbranch+"') "+
								" and su_active = '1' ";
							conn.ExecuteQuery();
		
							if (conn.GetRowCount() == 0)
								sgupawal = "";

							for (int i = 0; i < conn.GetRowCount();i++)
							{
								if (conn.GetFieldValue(i,"midupgroup") != "")
								{
									sgup = sgup + koma + "'"+conn.GetFieldValue(i,"midupgroup")+"'";	
									koma = ",";
								}
								sgupawal = conn.GetFieldValue(i,"midupgroup");
							}
						}	
						else if (var_complevel == var_corp)
						{
							conn.QueryString = "select distinct corupgroup from vw_approvaluser where groupid = '"+sgupawal+"'"+
								" and (usercbc = '"+var_cbc+"' or userbranch = '"+var_inbranch+"') "+
								" and su_active = '1' ";
							conn.ExecuteQuery();
		
							if (conn.GetRowCount() == 0)
								sgupawal = "";

							for (int i = 0; i < conn.GetRowCount();i++)
							{
								if (conn.GetFieldValue(i,"corupgroup") != "")
								{
									sgup = sgup + koma + "'"+conn.GetFieldValue(i,"corupgroup")+"'";	
									koma = ",";
								}
								sgupawal = conn.GetFieldValue(i,"corupgroup");
							}
						}	
					}
					if (sgup == "(")
						sgup = sgup + "''";
					sgup = sgup + ")";

					conn.QueryString = "select * from vw_approvaluser where groupid in "+sgup+" "+
						" and (usercbc = '"+var_cbc+"' or userbranch = '"+var_inbranch+"') "+
						" and su_active = '1' ";
					conn.ExecuteQuery();

					for (int i = 0; i < conn.GetRowCount();i++)
						DDL_PRRK.Items.Add(new ListItem(conn.GetFieldValue(i,2),conn.GetFieldValue(i,0)));
				
					//find downliner
					string grouptemp = Session["GroupID"].ToString();
					string sgdown = "(";
					koma = "";
					while (grouptemp != "") 
					{
						if (var_complevel == var_small)
						{
							conn.QueryString = "select distinct groupid from vw_approvaluser where smlupgroup = '"+grouptemp+"'"+
								" and (usercbc = '"+var_cbc+"' or userbranch = '"+var_inbranch+"') "+
								" and su_active = '1' ";
						}
						else if (var_complevel == var_middle)
						{
							conn.QueryString = "select distinct groupid from vw_approvaluser where midupgroup = '"+grouptemp+"'"+
								" and (usercbc = '"+var_cbc+"' or userbranch = '"+var_inbranch+"') "+
								" and su_active = '1' ";
						}
						conn.ExecuteQuery();

						if (conn.GetRowCount() == 0)
							grouptemp = "";

						for (int i = 0; i < conn.GetRowCount();i++)
						{
							if (conn.GetFieldValue(i,"groupid") != "")
							{
								sgdown = sgdown + koma + "'"+conn.GetFieldValue(i,"groupid")+"'";	
								koma = ",";
							}
							grouptemp = conn.GetFieldValue(i,"groupid");				
						}
					}
					if (sgdown == "(")
						sgdown = sgdown + "''";
					sgdown = sgdown + ")";

					conn.QueryString = "select * from vw_approvaluser where groupid in "+sgdown+" "+
						" and (usercbc = '"+var_cbc+"' or userbranch = '"+var_inbranch+"') "+
						" and su_active = '1' order by userfullnm";
					conn.ExecuteQuery();

					for (int i = 0; i < conn.GetRowCount();i++)
						DDL_PRRK.Items.Add(new ListItem(conn.GetFieldValue(i,2),conn.GetFieldValue(i,0)));
				}
				

				conn.QueryString = "select * from vw_assignment_app where ap_regno='" + DDL_AP_REGNO.SelectedValue + "'";
				conn.ExecuteQuery();
				string branchName = conn.GetFieldValue("branch_name"), 
					ca_fullname = conn.GetFieldValue("ca_fullname"),
					co_fullname = conn.GetFieldValue("co_fullname"),
					rm_fullname = conn.GetFieldValue("rm_fullname"),
					ap_ca = conn.GetFieldValue("ap_ca"),
					ap_co = conn.GetFieldValue("ap_co"),
					ap_rm = conn.GetFieldValue("ap_relmngr"),
					ap_currtrack = conn.GetFieldValue("ap_currtrack"),
					trackname = conn.GetFieldValue("trackname"),
					ap_currtrack_code = conn.GetFieldValue("ap_currtrack"),
					CCOBranch = conn.GetFieldValue("br_ccobranch"),
					branchCode = conn.GetFieldValue("branch_code"),
					CBCCode = conn.GetFieldValue("CBC_CODE");
				
				Label1.Text = conn.GetFieldValue("ap_currtrack");
				
				TXT_PRRK.Text = conn.GetFieldValue("AP_PRRKBYNAME");
				try
				{
					DDL_PRRK.SelectedValue = conn.GetFieldValue("AP_PRRKBY");
				}
				catch
				{
				}

				/*
				conn.QueryString = "select grp_co, grp_cooff from app_parameter";
				conn.ExecuteQuery(); 
				string grp_co = conn.GetFieldValue("grp_co"), grp_cooff = conn.GetFieldValue("grp_cooff");

				// mengisi DDL_AP_RM
				conn.QueryString = "select userid, su_fullname from scuser where groupid in ('010101010101010101','010101010101010102','01010101010101020101','01010101010101020102', '01010101010101020105', '010101010101010401', '0101010101010105', '0101010101010106') order by su_fullname ";
				conn.ExecuteQuery();
				for (int i = 0 ; i < conn.GetRowCount(); i++)
					DDL_AP_RM.Items.Add(new ListItem(conn.GetFieldValue(i,1), conn.GetFieldValue(i,0)));

				//conn.QueryString = "select userid, su_fullname from scuser where groupid in adalah group CO and su_branch='" + CCOBranch + "' order by su_fullname";
				conn.QueryString = "select userid, su_fullname from scuser u left join scgroup g on u.groupid = g.groupid where sg_grpunit = 'CO' and su_branch='" + CCOBranch + "' order by su_fullname";
				conn.ExecuteQuery();
				for (int i = 0 ; i < conn.GetRowCount(); i++)
					DDL_AP_CO.Items.Add(new ListItem(conn.GetFieldValue(i,1), conn.GetFieldValue(i,0)));

				//conn.QueryString = "select userid, su_fullname from vw_usercbc where cbc_code = '" + CBCCode// Session["CBC"].ToString() 
				//+ "' order by su_fullname";
				//conn.QueryString = "select userid, su_fullname from vw_usercbc where cbc_code = '" + CBCCode// Session["CBC"].ToString() 
				//+ "' and groupid not in ('" + grp_co + "', '" + grp_cooff + "') and substring(groupid,1,2) <> '02' order by su_fullname";
				conn.QueryString = "select userid, su_fullname from vw_usercbc v " +
					" left join scgroup g on v.groupid = g.groupid " +
					" where cbc_code = 'cbc1' and sg_grpunit = 'CO' and substring(v.groupid,1,2) <> '02' order by su_fullname";
				conn.ExecuteQuery();
				for (int i = 0 ; i < conn.GetRowCount(); i++)
				{
					DDL_AP_CA.Items.Add(new ListItem(conn.GetFieldValue(i,1), conn.GetFieldValue(i,0)));
				}
				

				TXT_BRANCH_NAME.Text = branchName;
				TXT_CUR_CA.Text = ca_fullname;
				TXT_CUR_CO.Text = co_fullname;
				TXT_CUR_RM.Text = rm_fullname;
				try
				{
					DDL_AP_RM.SelectedIndex = 0;
					DDL_AP_RM.SelectedValue = ap_rm;
				}
				catch {}
				try
				{
					DDL_AP_CO.SelectedIndex = 0;
					DDL_AP_CO.SelectedValue = ap_co;
				}
				catch {}
				try
				{
					DDL_AP_CA.SelectedIndex = 0;
					DDL_AP_CA.SelectedValue = ap_ca;
				}
				catch {}
				try
				{
					DDL_PRRK.SelectedIndex = 0;
				}
				catch {}
				TXT_TRACK.Text = ap_currtrack + " - " + trackname;
				//if (((Session["GroupID"].ToString().Substring(0,2) == "02") || (Session["GroupID"].ToString().Substring(0,2) == "01")) && (in_prrk == Label1.Text))
				//	DDL_PRRK.Enabled = true;
				*/
			}
			else
			{
				TXT_BRANCH_NAME.Text	= "";
				TXT_TRACK.Text			= "";
				TXT_CUR_RM.Text			= "";
				TXT_CUR_CO.Text			= "";
				TXT_CUR_CA.Text			= "";
				TXT_PRRK.Text			= "";
				try
				{
					DDL_AP_RM.SelectedIndex = 0;
				}
				catch {}
				try
				{
					DDL_AP_CO.SelectedIndex = 0;
				}
				catch {}
				try
				{
					DDL_AP_CA.SelectedIndex = 0;
				}
				catch {}
				try
				{
					DDL_PRRK.SelectedIndex = 0;
				}
				catch {}

				//20070806 add by sofyan, for CCO Branch
				try
				{
					DDL_AP_CCOBRANCH.SelectedIndex = 0;
				}
				catch {}
			}
		}

		protected void Button1_Click(object sender, System.EventArgs e)
		{
			/////////////////////////////////////////////////////////////////////////////////////////////
			/// ASSIGN CUSTOMER TO NEW RM
			/// 

			conn.QueryString = "exec ASSIGN_APPLICATION null, '" + 
				Request.QueryString["curef"] + "', null, null, null, '" + 
				DDL_USERID.SelectedValue + "', '0', null, null, null";
			conn.ExecuteNonQuery();
			TXT_CU_RM.Text = DDL_USERID.SelectedItem.Text;
			TXT_CU_BRANCHNAME.Text = DDL_BRANCH_CODE.SelectedItem.Text;

			string cu_ref = Request.QueryString["curef"];
			try
			{
				/*** // cu_ref bisa didapet dari querystring
				 * 
				conn.QueryString = " select cu_ref from application where ap_regno = '" + DDL_AP_REGNO.SelectedValue + "'";
				conn.ExecuteQuery();
				if ( conn.GetRowCount() > 0  ) 
				{
					cu_ref = conn.GetFieldValue("cu_ref");
				}
				else cu_ref = Request.QueryString["curef"];
				*/

				string _userid = "";
				if (DDL_USERID.SelectedValue != "") _userid = DDL_USERID.SelectedItem.Text;

				conn.QueryString = "exec SP_AUDITTRAIL_APP " + 
					"null, null, null, null," + 
					"'"+ cu_ref.ToString() +"', null, 'Assignment of Customer - "+ TXT_FULLNAME.Text.Replace("'","") + " to "+ _userid.Replace("'","") + "',"+ 
					"null,"  +  
					"'"+ Session["UserID"].ToString() + "','xxxx',null,null,null";
				conn.ExecuteNonQuery();
			}
			catch (Exception ex)
			{
				try { ExceptionHandling.Handler.saveExceptionIntoWindowsLog(ex, Request.Path, "Assignment Customer"); } 
				catch {}
			}

		}

		protected void Button2_Click(object sender, System.EventArgs e)
		{
			//////////////////////////////////////////////////////////////////////////////////////////////////
			/// ASSIGN APPLICATION TO NEW RM/CA/CO
			/// 

			////////////////////////////////////////////////////////////////
			/// VALIDASI RM
			///		
			/*if (DDL_AP_RM.Enabled == true && DDL_AP_RM.SelectedValue == "") 
			{
				GlobalTools.popMessage(this, "RM tidak boleh kosong!");
				return;
			}
			*/

			//conn.QueryString = "exec ASSIGN_APPLICATION '" + DDL_AP_REGNO.SelectedItem.Text + "', null, '" + DDL_AP_CO.SelectedValue + "', '" + DDL_AP_CA.SelectedValue + "', null, '1', '" + DDL_PRRK.SelectedValue + "'";
			conn.QueryString = "exec ASSIGN_APPLICATION '" + 
				DDL_AP_REGNO.SelectedItem.Text + "', null, '" + 
				DDL_AP_RM.SelectedValue + "', '" + 
				DDL_AP_CO.SelectedValue + "', '" + 
				DDL_AP_CA.SelectedValue + "', null, '1', '" + 
				DDL_PRRK.SelectedValue + "', '" + 
				DDL_AP_APRVCOMMITEE.SelectedValue + "', '" + 
				DDL_AP_CCOBRANCH.SelectedValue + "'";
			conn.ExecuteNonQuery();

			loadAppData();

			string cu_ref = Request.QueryString["curef"];

			try
			{
				/**	// curef bisa didapet dari querystring
				 * 
				conn.QueryString = " select cu_ref from application where ap_regno = '" + DDL_AP_REGNO.SelectedValue + "'";
				conn.ExecuteQuery();
				if ( conn.GetRowCount() > 0  ) 
				{
					cu_ref = conn.GetFieldValue("curef");
				}
				else cu_ref = Request.QueryString["curef"];
				**/
				string text_rm = "(none)", text_ca = "(none)", text_co = "(none)", 
					   text_pic = "(none)", text_ps = "(none)";

				if (DDL_AP_RM.SelectedValue != "") text_rm = DDL_AP_RM.SelectedItem.Text.Replace("'","");
				if (DDL_AP_CA.SelectedValue != "") text_ca = DDL_AP_CA.SelectedItem.Text.Replace("'","");
				if (DDL_AP_CO.SelectedValue != "") text_co = DDL_AP_CO.SelectedItem.Text.Replace("'","");
				if (DDL_AP_APRVCOMMITEE.SelectedValue != "") text_pic = DDL_AP_APRVCOMMITEE.SelectedItem.Text.Replace("'","");
				if (DDL_PRRK.SelectedValue != "") text_ps = DDL_PRRK.SelectedItem.Text.Replace("'","");

				
				conn.QueryString = "exec SP_AUDITTRAIL_APP '" + 
					DDL_AP_REGNO.SelectedValue + "', null, null, null, " + 
					"'"+ cu_ref.ToString() +"', null, 'Assignment RM - " + text_rm + 
                    ";CA - " + text_ca + ";CO - " + text_co + ";Approval Committee PIC - "  + 
					text_pic + ";PS - " + text_ps + "',"+ 
					"null,"  +  
					"'"+ Session["UserID"].ToString() + "','xxxx',null,null,null";
				conn.ExecuteNonQuery();
			}
			catch 	(Exception ex)
			{ 	
				try { ExceptionHandling.Handler.saveExceptionIntoWindowsLog(ex, Request.Path, "Assignment RM/CA/CO:" + DDL_AP_REGNO.SelectedValue ); } 
				catch {}
			}
			
			/*
			try
			{
				TXT_CUR_RM.Text = DDL_AP_RM.SelectedItem.Text;
			}
			catch
			{
			}
			try
			{
				TXT_CUR_CA.Text = DDL_AP_CA.SelectedItem.Text;
			}
			catch
			{
			}
			try
			{
				TXT_CUR_CO.Text = DDL_AP_CO.SelectedItem.Text;
			}
			catch
			{
			}
			try
			{
				TXT_PRRK.Text = DDL_PRRK.SelectedItem.Text;
			}
			catch
			{
			}
			*/
		}
	}
}
