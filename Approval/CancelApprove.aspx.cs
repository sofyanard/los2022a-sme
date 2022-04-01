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

namespace SME.Approval
{
	/// <summary>
	/// Summary description for CancelApprove.
	/// </summary>
	public partial class CancelApprove : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.TextBox txt_regno;
		protected System.Web.UI.WebControls.Button btn_cari;
		protected System.Web.UI.WebControls.Label lbl_prod;
		protected System.Web.UI.WebControls.Label lbl_apptype;
		protected Connection conn;
		protected Tools tool = new Tools();
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			conn = (Connection) Session["Connection"];

			if (!Logic.AllowAccess(Session["GroupID"].ToString(), Request.QueryString["mc"], conn))
				Response.Redirect("/SME/Restricted.aspx");

			if (!IsPostBack)
			{
				viewdata();
			}
		}

		private void viewdata()
		{
			lbl_dari.Text		= Request.QueryString["dari"]; 
			lbl_groupid.Text	= Session["GROUPID"].ToString(); 
			lbl_userid.Text		= Session["USERID"].ToString(); 
			conn.QueryString	= "select sg_aprvtrack from scgroup where groupid = '"+lbl_groupid.Text+"'";
			conn.ExecuteQuery();
			if (lbl_dari.Text == "crep") 
				lbl_track.Text  = Request.QueryString["tc"]; 
			else if (lbl_dari.Text == "aprv") 
				lbl_track.Text  = conn.GetFieldValue("sg_aprvtrack"); 
			
			conn.QueryString = "select distinct vw_cancelapprove.ap_regno, cu_ref, cu_name, ap_signdate, ap_currtrackby from vw_cancelapprove "+
							   " left join trackhistory on vw_cancelapprove.ap_regno = trackhistory.ap_regno "+
							   " where ap_currtrackby = '"+lbl_userid.Text+"' "+
							   " and th_seq = (select max(th_seq)-1 from trackhistory th where trackhistory.ap_regno = th.ap_regno and trackcode = '"+lbl_track.Text+"') ";
			conn.ExecuteQuery();
			DataTable dt = new DataTable();
			dt = conn.GetDataTable().Copy();

			dgCancelAss.DataSource = dt;
			try 
			{
				dgCancelAss.DataBind();
			} 
			catch 
			{
				dgCancelAss.CurrentPageIndex = 0;
				dgCancelAss.DataBind();
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

		}
		#endregion

		protected void btn_cancel_Click(object sender, System.EventArgs e)
		{
			string var_apptype, var_prod, var_currtrack, var_currtrackdate, var_currtrackby, PROD_SEQ;

			CheckBox chk;
			for (int i = 0; i < dgCancelAss.Items.Count; i++)
			{
				chk = (CheckBox) dgCancelAss.Items[i].Cells[3].FindControl("CheckBox1");
				
				if (chk.Checked == true)
				{
					if (lbl_dari.Text == "crep") 
					{
						conn.QueryString = "update application set ap_aprvnextby = '' where ap_regno = '"+dgCancelAss.Items[i].Cells[0].Text+"' ";
						conn.ExecuteQuery();
					}
					else if (lbl_dari.Text == "aprv") 
					{
						conn.QueryString = "update application set ap_aprvnextby = '"+lbl_userid.Text+"', ap_aprvuntil = '"+lbl_userid.Text+"'  where ap_regno = '"+dgCancelAss.Items[i].Cells[0].Text+"' ";
						conn.ExecuteQuery();

						conn.QueryString = "delete from reject_cancel where ap_regno = '"+dgCancelAss.Items[i].Cells[0].Text+"' and rcancelby = '"+lbl_userid.Text+"'";
						conn.ExecuteQuery();
					}
					
					conn.QueryString = "delete from trackhistory where ap_regno = '"+dgCancelAss.Items[i].Cells[0].Text+"' "+
									   " and th_seq = (select max(th_seq) from trackhistory th where trackhistory.ap_regno = th.ap_regno) ";
					conn.ExecuteQuery();
					
					conn.QueryString = "select * from trackhistory where ap_regno = '"+dgCancelAss.Items[i].Cells[0].Text+"' "+
									   " and th_seq = (select max(th_seq) from trackhistory th where trackhistory.ap_regno = th.ap_regno) ";
					conn.ExecuteQuery();
					DataTable dt_track = new DataTable();
					dt_track		   = conn.GetDataTable().Copy();
					for (int j = 0; j < dt_track.Rows.Count; j++)
					{
						var_apptype			= dt_track.Rows[j]["apptype"].ToString();
						var_prod			= dt_track.Rows[j]["productid"].ToString();
						var_currtrack		= dt_track.Rows[j]["trackcode"].ToString();
						var_currtrackdate	= dt_track.Rows[j]["th_trackdate"].ToString();
						var_currtrackby		= dt_track.Rows[j]["th_trackby"].ToString();
						PROD_SEQ			= dt_track.Rows[j]["PROD_SEQ"].ToString();
						
						if (conn.GetFieldValue("th_trackby") != "")
						{
							conn.QueryString = "update apptrack set ap_currtrack = '"+var_currtrack+"', "+
								" ap_currtrackdate = "+tool.ConvertDate(var_currtrackdate)+", ap_currtrackby = '"+var_currtrackby+"' "+
								" where ap_regno = '"+dgCancelAss.Items[i].Cells[0].Text+"' "+
								" and apptype = '"+var_apptype+"' "+
								" and productid = '"+var_prod+"' " +
								" and PROD_SEQ = '" + PROD_SEQ + "'";
						}
						else
						{
							conn.QueryString = "update apptrack set ap_currtrack = '"+var_currtrack+"', "+
								" ap_currtrackdate = "+tool.ConvertDate(var_currtrackdate)+", ap_currtrackby = null "+
								" where ap_regno = '"+dgCancelAss.Items[i].Cells[0].Text+"' "+
								" and apptype = '"+var_apptype+"' "+
								" and productid = '"+var_prod+"' " +
								" and PROD_SEQ = '" + PROD_SEQ + "'";										
						}
						conn.ExecuteQuery();
					}	
				}
			}
			viewdata();
		}
	}
}
