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
	public partial class AprvAssignment : System.Web.UI.Page
	{
		protected Connection conn;
		string var_complevel, var_appbranch, var_area, var_cbc, var_aprvnextby, var_aprvuntil;
		string var_small, var_middle, var_inbranch, var_corp;
		double var_limitexp, var_userlimit;
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			conn = (Connection) Session["Connection"];

			if (!Logic.AllowAccess(Session["GroupID"].ToString(), Request.QueryString["mc"], conn))
				Response.Redirect("/SME/Restricted.aspx");

			if (!IsPostBack)
			{					
				viewdata();
//
//				/*ddl_assignto.Items.Add(new ListItem("- PILIH -", ""));
//				conn.QueryString = "select userid, su_fullname from scuser where substring(groupid, 1,2) in ('01', '02') "+
//								   " and (su_aprvlimit is not null and su_aprvlimit > 0)";
//				conn.ExecuteQuery();*/
//				conn.QueryString	= "select * from rfinitial";
//				conn.ExecuteQuery();
//				var_small			= conn.GetFieldValue("in_small");
//				var_middle			= conn.GetFieldValue("in_middle");
//				var_corp			= conn.GetFieldValue("in_corporate");
//				var_inbranch		= conn.GetFieldValue("in_branchpusat");
//
//				conn.QueryString = "select ap_complevel, isnull(limitexposure,0) + sum(cp_limit) as limitexposure, "+
//								   " application.branch_code, application.areaid, cbc_code from application "+
//								   " left join customer on application.cu_ref = customer.cu_ref "+
//								   " left join custproduct on application.ap_regno = custproduct.ap_regno "+
//								   " left join rfbranch on application.branch_code = rfbranch.branch_code "+
//								   " where application.ap_regno = '"+txt_regno.Text+"' "+
//								   " group by ap_complevel, limitexposure, application.branch_code, application.areaid, cbc_code ";
//				conn.ExecuteQuery();
//				var_complevel	= conn.GetFieldValue("ap_complevel");
//				var_limitexp	= Convert.ToDouble(conn.GetFieldValue("limitexposure"));
//				var_appbranch	= conn.GetFieldValue("branch_code");
//				var_area		= conn.GetFieldValue("areaid");
//				var_cbc			= conn.GetFieldValue("cbc_code");
//
//
//				/// Find user in the same group
//				/// ---- starting from here ..... chengkl
//				conn.QueryString = "select * from vw_approvaluser where groupid = '"+Session["GROUPID"].ToString()+"' "+
//								   " and (usercbc = '"+var_cbc+"' or userbranch = '"+var_inbranch+"') "+
//								   " and su_active = '1' ";
//				conn.ExecuteQuery();			
//				
//				for (int i = 0; i < conn.GetRowCount();i++)
//				{
//					ddl_assignto.Items.Add(new ListItem(conn.GetFieldValue(i,2),conn.GetFieldValue(i,0)));
//				}
//				
//
//				//find upliner
//				//string sgmitra, sgup;
//				conn.QueryString = "select * from vw_approvaluser where userid = '"+Session["USERID"].ToString()+"'";
//				conn.ExecuteQuery();
//				var_userlimit = Convert.ToDouble(conn.GetFieldValue("userlimit"));
//				
//				string sgupawal = "'"+Session["GROUPID"].ToString()+"'";
//				string sgup = "(";
//				string koma = "";
//				while (sgupawal != "") 
//				{
//					if (var_complevel == var_small)
//					{
//						conn.QueryString = "select distinct smlupgroup from vw_approvaluser where groupid in ("+sgupawal+")"+
//										   " and (usercbc = '"+var_cbc+"' or userbranch = '"+var_inbranch+"') "+
//										   " and su_active = '1' ";
//						conn.ExecuteQuery();
//	
//						//if (conn.GetRowCount() == 0)
//						sgupawal = "";
//
//						string koma1 = "";
//						for (int i = 0; i < conn.GetRowCount();i++)
//						{
//							if (conn.GetFieldValue(i,"smlupgroup") != "")
//							{
//								sgup = sgup + koma + "'"+conn.GetFieldValue(i,"smlupgroup")+"'";	
//								koma = ",";
//								sgupawal = sgupawal + koma1 + "'"+conn.GetFieldValue(i,"smlupgroup")+"'";	
//								koma1 = ",";
//							}
//							//sgupawal = conn.GetFieldValue(i,"smlupgroup");
//						}
//					}
//					else if (var_complevel == var_middle)
//					{
//						conn.QueryString = "select distinct midupgroup from vw_approvaluser where groupid = ("+sgupawal+")"+
//										   " and (usercbc = '"+var_cbc+"' or userbranch = '"+var_inbranch+"') "+
//										   " and su_active = '1' ";
//						conn.ExecuteQuery();
//	
//						//if (conn.GetRowCount() == 0)
//						sgupawal = "";
//
//						string koma1 = "";
//						for (int i = 0; i < conn.GetRowCount();i++)
//						{
//							if (conn.GetFieldValue(i,"midupgroup") != "")
//							{
//								sgup = sgup + koma + "'"+conn.GetFieldValue(i,"midupgroup")+"'";	
//								koma = ",";
//								sgupawal = sgupawal + koma1 + "'"+conn.GetFieldValue(i,"midupgroup")+"'";	
//								koma1 = ",";
//							}
//							//sgupawal = conn.GetFieldValue(i,"midupgroup");
//						}
//					}
//						/// Corporate
//						/// 
//					else if (var_complevel == var_corp)
//					{
//						conn.QueryString = "select distinct corupgroup from vw_approvaluser where groupid = ("+sgupawal+")"+
//							//" and (usercbc = '"+var_cbc+"' or userbranch = '"+var_inbranch+"') "+
//							" and su_active = '1' ";
//						conn.ExecuteQuery();
//	
//						sgupawal = "";
//
//						string koma1 = "";
//						for (int i = 0; i < conn.GetRowCount();i++)
//						{
//							if (conn.GetFieldValue(i,"corupgroup") != "")
//							{
//								sgup = sgup + koma + "'"+conn.GetFieldValue(i,"corupgroup")+"'";	
//								koma = ",";
//								sgupawal = sgupawal + koma1 + "'"+conn.GetFieldValue(i,"corupgroup")+"'";	
//								koma1 = ",";
//							}
//						}
//					}	
//	
//				}
//				if (sgup == "(")
//					sgup = sgup + "''";
//				sgup = sgup + ")";
//
//				if (var_complevel == var_corp) 
//				{
//					conn.QueryString = "select * from vw_approvaluser where groupid in "+sgup+" "+
//						" and su_active = '1' ";
//				} 
//				else 
//				{
//					conn.QueryString = "select * from vw_approvaluser where groupid in "+sgup+" "+
//						" and (usercbc = '"+var_cbc+"' or userbranch = '"+var_inbranch+"') "+
//						" and su_active = '1' ";
//				}
//				conn.ExecuteQuery();
//
//				for (int i = 0; i < conn.GetRowCount();i++)
//				{
//					ddl_assignto.Items.Add(new ListItem(conn.GetFieldValue(i,2),conn.GetFieldValue(i,0)));
//				}
//				
//				//find downliner
//				string grouptemp = "'"+Session["GROUPID"].ToString()+"'";
//				string sgdown = "(";
//				koma = "";
//				while (grouptemp != "") 
//				{
//					if (var_complevel == var_small)
//					{
//						conn.QueryString = "select distinct groupid from vw_approvaluser where smlupgroup in ("+grouptemp+")"+
//									  	   " and (usercbc = '"+var_cbc+"' or userbranch = '"+var_inbranch+"') "+
//										   " and su_active = '1' ";
//					}
//					else if (var_complevel == var_middle)
//					{
//						conn.QueryString = "select distinct groupid from vw_approvaluser where midupgroup in ("+grouptemp+")"+
//								  		   " and (usercbc = '"+var_cbc+"' or userbranch = '"+var_inbranch+"') "+
//										   " and su_active = '1' ";
//					}
//					else if (var_complevel == var_corp)
//					{
//						conn.QueryString = "select distinct groupid from vw_approvaluser where corupgroup in ("+grouptemp+")"+
//							//" and (usercbc = '"+var_cbc+"' or userbranch = '"+var_inbranch+"') "+
//							" and su_active = '1' ";
//					}
//
//					conn.ExecuteQuery();
//
//					//if (conn.GetRowCount() == 0)
//					grouptemp = "";
//
//					string koma1 = "";
//					for (int i = 0; i < conn.GetRowCount();i++)
//					{
//						if (conn.GetFieldValue(i,"groupid") != "")
//						{
//							sgdown = sgdown + koma + "'"+conn.GetFieldValue(i,"groupid")+"'";	
//							koma = ",";
//							grouptemp = grouptemp + koma1 + "'"+conn.GetFieldValue(i,"groupid")+"'";
//							koma1 = ",";
//						}
//						//grouptemp = conn.GetFieldValue(i,"groupid");				
//					}
//				}
//				if (sgdown == "(")
//					sgdown = sgdown + "''";
//				sgdown = sgdown + ")";
//
//				if (var_complevel == var_corp) 
//				{
//					conn.QueryString = "select * from vw_approvaluser where groupid in "+sgdown+" "+
//						" and su_active = '1' ";
//				}
//				else 
//				{
//					conn.QueryString = "select * from vw_approvaluser where groupid in "+sgdown+" "+
//						" and (usercbc = '"+var_cbc+"' or userbranch = '"+var_inbranch+"') "+
//						" and su_active = '1' ";
//				}
//				conn.ExecuteQuery();
//
//                //--- sampai sini.
//				// passing parameters ---- application + userid
//				// ---- chengkl
				conn.QueryString = "EXEC ASSIGN_APPROVAL '"+Request.QueryString["regno"]+"','"+Session["USERID"].ToString()+"' ";
				conn.ExecuteQuery();

				for (int i = 0; i < conn.GetRowCount();i++)
				{
					ddl_assignto.Items.Add(new ListItem(conn.GetFieldValue(i,0),conn.GetFieldValue(i,1)));
				}	
			}			
		}

		private void viewdata()
		{
			conn.QueryString = "select in_reject from rfinitial";
			conn.ExecuteQuery();
			string var_reject = conn.GetFieldValue("in_reject");
			conn.QueryString = "select distinct application.ap_regno, ap_aprvnextby, su_fullname, ap_aprvuntil, branch_name, ap_currtrack, trackname "+
							   " from application "+
							   " left join rfbranch on application.branch_code = rfbranch.branch_code "+
							   " left join apptrack on application.ap_regno = apptrack.ap_regno "+
							   " left join rftrack on apptrack.ap_currtrack = rftrack.trackcode "+
							   " left join scuser on application.ap_aprvnextby = scuser.userid "+
							   " where application.ap_regno = '"+Request.QueryString["regno"].ToString()+"'"+
							   " and ap_currtrack <> '"+var_reject+"'";
			conn.ExecuteQuery();
			txt_regno.Text		= conn.GetFieldValue("ap_regno");
			txt_branch.Text		= conn.GetFieldValue("branch_name");
			txt_currtrack.Text	= conn.GetFieldValue("trackname");
			txt_trackcode.Text	= conn.GetFieldValue("ap_currtrack");
			txt_currAprv.Text	= conn.GetFieldValue("su_fullname");
			txt_aprvcode.Text	= conn.GetFieldValue("ap_aprvnextby");
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

		protected void btn_assign_Click(object sender, System.EventArgs e)
		{
			string var_userup, var_username, var_groupup, var_trackup, var_reject, var_currtrack;
			conn.QueryString = "select in_reject from rfinitial";
			conn.ExecuteQuery();
			var_reject = conn.GetFieldValue("in_reject");

			conn.QueryString = "select distinct ap_currtrack from apptrack "+
				" where ap_regno = '"+txt_regno.Text+"' and isnull(ap_currtrack,'') <> '"+var_reject+"'";
			conn.ExecuteQuery();
			var_currtrack = conn.GetFieldValue("ap_currtrack");

			conn.QueryString = "select * from vw_approvaluser where userid = '"+ddl_assignto.SelectedValue+"'";
			conn.ExecuteQuery();
			var_userup	 = conn.GetFieldValue("userid");
			var_username = conn.GetFieldValue("userfullnm");
			var_groupup  = conn.GetFieldValue("groupid");
			var_trackup  = conn.GetFieldValue("usertrack");
		
			//update track
			if (var_currtrack != var_trackup)
			{
				conn.QueryString = "select * from vw_currtrack where ap_regno = '"+txt_regno.Text+"'";
				conn.ExecuteQuery();
				DataTable dt_currtrack = new DataTable();
				dt_currtrack = conn.GetDataTable().Copy();

				for (int i = 0; i < dt_currtrack.Rows.Count;i++) 
				{
					string var_apptype		= dt_currtrack.Rows[i]["apptype"].ToString();
					string var_prod			= dt_currtrack.Rows[i]["productid"].ToString();
					string PROD_SEQ 	    = dt_currtrack.Rows[i]["PROD_SEQ"].ToString();
					//string var_currtrack	= dt_currtrack.Rows[i]["ap_currtrack"].ToString();
						
					conn.QueryString = "exec approval_nexttrack '"+txt_regno.Text+"', '"+var_prod+"', '"+var_apptype+"', '"+Session["USERID"].ToString()+"', '"+var_userup+"', '"+var_trackup+"', '1', '"+var_userup+"', '" + PROD_SEQ + "'";
					conn.ExecuteQuery();
				}
			}
			else
			{
				conn.QueryString = "select ap_aprvnextby, ap_aprvuntil from application where ap_regno = '" + txt_regno.Text + "'";
				conn.ExecuteQuery();
				var_aprvnextby	 = conn.GetFieldValue("ap_aprvnextby");
				var_aprvuntil	 = conn.GetFieldValue("ap_aprvuntil");
				if (var_aprvuntil == var_aprvnextby)
				{
					conn.QueryString = "update application set ap_aprvnextby = '"+ddl_assignto.SelectedValue+"', "+
						" ap_aprvuntil = '"+ddl_assignto.SelectedValue+"'"+ 
						" where ap_regno = '"+txt_regno.Text+"'";
					conn.ExecuteQuery();
				}
				else
				{
					conn.QueryString = "update application set ap_aprvnextby = '"+ddl_assignto.SelectedValue+"'"+
						" where ap_regno = '"+txt_regno.Text+"'";
					conn.ExecuteQuery();
				}
				conn.QueryString = "update overall_sla_responsetime set userid = '" + ddl_assignto.SelectedValue + 
					"', ap_currtrack = '" + var_currtrack + "' where ap_regno = '" + txt_regno.Text + "' ";
				conn.ExecuteNonQuery();
				conn.QueryString = "update trackhistory set TH_TRACKNEXTBY = '" + ddl_assignto.SelectedValue +
					"' where ap_regno = '" + txt_regno.Text +
					"' and th_seq = (select max(th_seq) from trackhistory where ap_regno = '" + txt_regno.Text + "') ";
				conn.ExecuteNonQuery();
			}

			string cu_ref;
			try
			{
				conn.QueryString = " select cu_ref from application where ap_regno = '" + txt_regno.Text + "'";
				conn.ExecuteQuery();
				if ( conn.GetRowCount() > 0  ) 
				{
					cu_ref = conn.GetFieldValue("cu_ref");
				}
				else cu_ref = "???";
				
				conn.QueryString = "SP_AUDITTRAIL_APP " + 
					"'"+ txt_regno.Text +"', null, null, null," + 
					"'"+ cu_ref.ToString() +"', null,' Assignment of Approval to "+ ddl_assignto.SelectedItem.Text + " from "+ txt_currAprv.Text +"',"+ 
					"null,"  +  
					"'"+ Session["UserID"].ToString() + "','xxxx',null,null,null";
				conn.ExecuteNonQuery();
			}
			catch 	{ 	}


		}
	}		
}
