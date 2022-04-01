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
using Earmarking;


namespace SME.SPPK
{
	/// <summary>
	/// Summary description for ListSPPKConfirm.
	/// </summary>
	public partial class ListSPPKConfirm : System.Web.UI.Page
	{
		protected Connection conn;
		protected Tools tool = new Tools();

		protected void Page_Load(object sender, System.EventArgs e)
		{
			conn = (Connection) Session["Connection"];

			if (!Logic.AllowAccess(Session["GroupID"].ToString(), Request.QueryString["mc"], conn))
				Response.Redirect("/SME/Restricted.aspx");
			
			/// Munculkan pesan next step
			/// Format #1
			if (LBL_AP_REGNO.Text != "")  
			{
				GlobalTools.popMessage(this, LBL_AP_REGNO.Text);
				LBL_AP_REGNO.Text = "";
			}

			/// Format #2
			if (Request.QueryString["msg"] != "" && Request.QueryString["msg"] != null)  
			{
				GlobalTools.popMessage(this, Request.QueryString["msg"]);				
			}



			if (!IsPostBack)
			{
				ViewData("0");
			}

			btn_Appeal.Attributes.Add("onclick","if(!update('appeal')) { return false; };");
			btn_Update.Attributes.Add("onclick","if(!update('update')) { return false; };");
			btn_BackVA.Attributes.Add("onclick","if(!update('back to Verification Assiggment')) { return false; };");
		}

		private void ViewData(string sta)
		{	
			DataTable dt = new DataTable();
			if (sta == "1")
				conn.QueryString = "select * from vw_listsppk where ap_regno = '"+txt_regno.Text+"' and ap_currtrack='" + Request.QueryString["tc"] + "' and (ap_relmngr='" + Session["UserID"].ToString() + "' or ap_relmngr is null)";
			else
				conn.QueryString = "select * from vw_listsppk where ap_currtrack='" + Request.QueryString["tc"] + "' and (ap_relmngr='" + Session["UserID"].ToString() + "' or ap_relmngr is null)";
			conn.ExecuteQuery();
			dt = conn.GetDataTable().Copy();
			dgListSPPK.DataSource = dt;
			dgListSPPK.DataBind();

			for (int i = 0; i < dgListSPPK.Items.Count; i++)
			{
				dgListSPPK.Items[i].Cells[5].Text = tool.FormatDate(dgListSPPK.Items[i].Cells[5].Text, true);
			}
		}

		#region Web Form Designer generated code
		override protected void OnInit(EventArgs e)
		{
			//
			// CODEGEN: This call is required by the ASP.NET Web Form Designer.
			//
			base.OnInit(e);
            if (!this.DesignMode)
            {
                InitializeComponent();
            }
		}
		
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{    
			this.dgListSPPK.ItemCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.dgListSPPK_ItemCommand);

		}
		#endregion

		private void dgListSPPK_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			switch (((LinkButton)e.CommandSource).CommandName)
			{
				case "view":
					//----------- edited by Yudi -------------
					//Response.Redirect("SPPKConfirm.aspx?regno="+e.Item.Cells[0].Text+"&curef="+e.Item.Cells[1].Text+"&mc=" + Request.QueryString["mc"]);
					if (e.Item.Cells[8].Text == "&nbsp;")
					{
						conn.QueryString = "update application set ap_relmngr='" + Session["UserID"].ToString() + "' where ap_regno='" + e.Item.Cells[0].Text + "'";
						conn.ExecuteNonQuery();
					}
					Response.Redirect("SPPKConfirm.aspx?regno="+e.Item.Cells[0].Text+"&curef="+e.Item.Cells[1].Text+"&mc=" + Request.QueryString["mc"]+"&tc="+Request.QueryString["tc"]);
					//----------------------------------------
					break;
			}
		}

		protected void btn_cari_Click(object sender, System.EventArgs e)
		{
			ViewData("1");	
		}

		protected void btn_Update_Click(object sender, System.EventArgs e)
		{ // Tombol Update Status
			CheckBox chk;

			bool ok = false; // flag untuk tampilkan pesan
			string regno = "";
			for (int i = 0; i < dgListSPPK.Items.Count; i++)
			{
				chk = (CheckBox) dgListSPPK.Items[i].Cells[6].FindControl("CheckBox1");
				
				if (chk.Checked == true)
				{
					//conn.QueryString = "select apptype, productid from cust_product where ap_regno='" + dgListSPPK.Items[i].Cells[0].Text + "'"; soiafjoaisfhisulfhsufsfd
					DataTable dt;
					conn.QueryString = "select apptype, productid, prod_seq from custproduct where ap_regno='" + dgListSPPK.Items[i].Cells[0].Text +
						"' AND isnull(cp_reject,'0') <> '1' and isnull(cp_cancel,'0') <> '1'";
					conn.ExecuteQuery();
					dt = conn.GetDataTable().Copy();
					for (int j = 0; j < dt.Rows.Count; j++)
					{
						conn.QueryString = "exec TRACKUPDATE '" +		
							dgListSPPK.Items[i].Cells[0].Text + "', '" +// AP_REGNO
							dt.Rows[j][1].ToString() + "', '" + 
							dt.Rows[j][0].ToString() + "', '" + 
							Session["UserID"].ToString() + "', '" + 
							dt.Rows[j]["prod_seq"].ToString() + "','"+ Request.QueryString["tc"].Trim() +"'";
						conn.ExecuteNonQuery();

					}

					////////////////////////////////////////////////////
					/// mengupdate track next by
					/// 
					conn.QueryString = "exec TRACKNEXTBY_SET '" + dgListSPPK.Items[i].Cells[0].Text + "'";
					conn.ExecuteNonQuery();

					
					conn.QueryString = "update sppk set ts_sppkreturndate=getdate() where ap_regno='" + dgListSPPK.Items[i].Cells[0].Text + "'";
					conn.ExecuteNonQuery();
					
					conn.QueryString = "select * from ketentuan_kredit where ap_regno = '" + dgListSPPK.Items[i].Cells[0].Text + "'";
					conn.ExecuteQuery();
					DataTable dtk = conn.GetDataTable().Copy();

					//////////////////////////////////////////////////////////////////////////////////
					/// For the sake of safety, check first whether it needs
					/// earmarking or not
					/// 
					for(int k=0; k < dtk.Rows.Count; k++) 
					{
						conn.QueryString = "exec EARMARK_CEK '" + 
							dgListSPPK.Items[i].Cells[0].Text + "', '" + 
							dtk.Rows[k]["ket_code"].ToString() + "'";
						conn.ExecuteQuery();
						if (conn.GetFieldValue("NEED_EARMARK") == "1") 
						{
							/// Reverse Earmark
							/// 
							try 
							{
								Earmarking.Earmarking.reverseEarmark(dgListSPPK.Items[i].Cells[0].Text, dtk.Rows[k]["ket_code"].ToString(), conn);

								conn.ExecTran_Commit();
							} 
							catch (Exception ex)
							{
								if (conn != null) conn.ExecTran_Rollback();
								ExceptionHandling.Handler.saveExceptionIntoWindowsLog(ex, Request.Path, dgListSPPK.Items[i].Cells[0].Text);
							}
						}
					}
					/////////////////////////////////////////////////////////////////////////////////
					
					
					//////////////////////////////////////////////////////////////////////
					/// audit trail
					/// 
					/** // sudah dilakukan di stored proc TRACKUPDATE
					try
					{
						conn.QueryString = "SP_AUDITTRAIL_APP '" + 
							dgListSPPK.Items[i].Cells[0].Text + "',null,null,null,'" + 
							dgListSPPK.Items[i].Cells[1].Text + "','" + 
							Request.QueryString["tc"] + "','Update status SPPK Confirm',"+ 
							"null" + ",'" +  
							Session["userid"].ToString() + "',null,null";
						conn.ExecuteNonQuery();
					}
					catch (Exception ex)
					{
						ExceptionHandling.Handler.saveExceptionIntoWindowsLog(ex, Request.Path, "AP_REGNO: " + dgListSPPK.Items[i].Cells[0].Text);
					}
					**/

					if (i == 0) regno = dgListSPPK.Items[i].Cells[0].Text; //set nilai ap_regno
					ok = true; 

					/*sd
					conn.QueryString = "select cp.apptype, cp.productid, cp.cp_reject, cp.cp_cancel from cust_product cp left join " + 
						"application ap on ap.ap_regno=cp.ap_regno where ap.ap_regno='" + dgListSPPK.Items[i].Cells[0].Text + "' and " + 
						"(isnull(cp.cp_reject, '0') <> '1' or isnull(cp.cp_cancel, '0')<> '1')";
					conn.ExecuteQuery();
					for (int j = 0; j < conn.GetRowCount(); j++)
					{
						conn.QueryString = "exec TRACK_UPDATE '" + dgListSPPK.Items[i].Cells[0].Text + "', '" +
							conn.GetFieldValue(j,1) + "', '" + conn.GetFieldValue(j,0) + "', '" + Session["UserID"].ToString() + "'";
						conn.ExecuteNonQuery();
					}
					*/
					/*
					conn.QueryString = "exec TRACK_UPDATE '" + dgListSPPK.Items[i].Cells[0].Text + "', '" +
						dgListSPPK.Items[i].Cells[10].Text + "', '" + dgListSPPK.Items[i].Cells[11].Text + "', '" + Session["UserID"].ToString() + "'";
					conn.ExecuteNonQuery();
					*/

					LBL_AP_REGNO.Text = getNextStepMsg(dgListSPPK.Items[i].Cells[0].Text, Request.QueryString["tc"]);
				}
			}
			if (ok)	GlobalTools.popMessage(this, getNextStepMsg(regno, Request.QueryString["tc"]));

			
			ViewData("0");			
		}

		// mengambil informasi next track dari track yang sekarang
		private string getNextStepMsg(string regno, string tc) 
		{
			string pesan = "";
			string nextTrack = "";
			try 
			{
				/***
				 * Memunculkan pesan next step
				 ***/
				conn.QueryString  = "exec TRACKNEXTMSG1 null, '" + tc + "'";
				conn.ExecuteQuery();
				
				nextTrack = conn.GetFieldValue("TRACKNAME");
				pesan = "Application proceeds to " + nextTrack;
				/***********************************/
			} 
			catch 
			{
				throw new Exception();
			}

			return pesan;
		}

		private string getPrevStepMsg(string regno, string tc)
		{
			string pesan = "";
			string nextTrack = "";
			string area = (string) Session["AreaID"];

			try 
			{
				/***
				 * Memunculkan pesan prev step: Gatot
				 ***/
				conn.QueryString = "exec TRACKPREVMSG '" + regno + "', '" + tc + "'";
				conn.ExecuteQuery();
				nextTrack = conn.GetFieldValue("TRACKNAME");
				pesan = "Application proceeds to " + nextTrack;
				/***********************************/
			} 
			catch 
			{
				throw new Exception();
			}
			return pesan;
		}

		protected void btn_Appeal_Click(object sender, System.EventArgs e)
		{
			CheckBox chk;
			DataTable dt;

			bool ok = false;
			string regno = "";
			for (int i = 0; i < dgListSPPK.Items.Count; i++)
			{
				chk = (CheckBox) dgListSPPK.Items[i].Cells[6].FindControl("CheckBox1");
				
				if (chk.Checked == true)
				{	
					conn.QueryString = "update CUSTPRODUCT set CP_DECSTA = '' " + 
						"where AP_REGNO = '"+dgListSPPK.Items[i].Cells[0].Text+"'";
					conn.ExecuteQuery();

					conn.QueryString = "select apptype, productid, PROD_SEQ from custproduct where ap_regno='" + dgListSPPK.Items[i].Cells[0].Text + "'";
					conn.ExecuteQuery();
					dt = conn.GetDataTable().Copy();
					for (int j = 0; j < dt.Rows.Count; j++)
					{
						conn.QueryString = "exec TRACKBACK '" + 
							dgListSPPK.Items[i].Cells[0].Text + "', '" +
							conn.GetFieldValue(j,1) + "', '" + 
							conn.GetFieldValue(j,0) + "', '" + 
							Session["UserID"].ToString() + "', '" + 
							conn.GetFieldValue(j, "PROD_SEQ") + "'";
						conn.ExecuteNonQuery();	
					}

					////////////////////////////////////////////////////////////////
					///	set flag appeal, appeal_date, appeal_user
					///	
					conn.QueryString = "update application set ap_isappeal = '1', ap_isappealdate = getdate(), ap_isappealby = '" + Session["UserID"] + "' where ap_regno='" + dgListSPPK.Items[i].Cells[0].Text + "'";
					conn.ExecuteNonQuery();
					////////////////////////////////////////////////////////////////

					//////////////////////////////////////////////////////////////////////
					/// audit trail
					try
					{
						conn.QueryString = "SP_AUDITTRAIL_APP '" + 
							dgListSPPK.Items[i].Cells[0].Text + "',null,null,null,'" + 
							dgListSPPK.Items[i].Cells[1].Text + "','" + 
							Request.QueryString["tc"] + "','Appeal SPPK Confirm',"+ 
							"null" + ",'" +  
							Session["userid"].ToString() + "',null,null";
						conn.ExecuteNonQuery();
					}
					catch (Exception ex)
					{
						ExceptionHandling.Handler.saveExceptionIntoWindowsLog(ex, Request.Path, "AP_REGNO: " + dgListSPPK.Items[i].Cells[0].Text);
					}

					if (i==0) regno = dgListSPPK.Items[i].Cells[0].Text; // set value regno
					ok = true;

					//DataTable dt;
					//conn.QueryString = "select CP.APPTYPE, CP.PRODUCTID, CP.CP_REJECT, CP.CP_CANCEL from CUST_PRODUCT CP left join " + 
					//	"APPLICATION AP on AP.AP_REGNO=CP.AP_REGNO where AP.AP_REGNo='" + dgListSPPK.Items[i].Cells[0].Text + "'"; /* and " + 
					//	"(isnull(CP.CP_REJECT, '0') <> '1' or isnull(CP.CP_CANCEL, '0')<> '1')";*/
					//conn.ExecuteQuery();

					//dt = conn.GetDataTable().Copy();

					/*
					for (int j = 0; j < dt.Rows.Count; j++)
					{
						string apptype		= dt.Rows[j][0].ToString().Trim();
						string productid	= dt.Rows[j][1].ToString().Trim();

						conn.QueryString = "update CUST_PRODUCT set CP_DECSTA = '' " + 
											"where AP_REGNO = '"+dgListSPPK.Items[i].Cells[0].Text+"' "+
											" and PRODUCTID = '"+productid+
											"' and APPTYPE = '"+apptype+"' ";
						conn.ExecuteQuery();
	
						conn.QueryString = "exec TRACKBACK '" + 
												dgListSPPK.Items[i].Cells[0].Text + "', '" +
												productid + "', '" + 
												apptype + "', '" + 
												Session["UserID"].ToString() + "'";
						conn.ExecuteNonQuery();	

						conn.QueryString = "update application set ap_isappeal = '1' where ap_regno='" + dgListSPPK.Items[i].Cells[0].Text + "'";
						conn.ExecuteNonQuery();
					}
					*/
				}
			}

			if (ok) GlobalTools.popMessage(this, getPrevStepMsg(regno, Request.QueryString["tc"]));
	
			ViewData("0");
		}

		protected void BTN_PROJECTLIST_Click(object sender, System.EventArgs e)
		{
			//Response.Write("<script language='javascript'>window.open('../ProjectInfo.aspx?regno=" + LBL_REGNO.Text + "&curef=" + LBL_CUREF.Text + "&sta=view','ProjectInfo','status=no,scrollbars=yes,width=800,height=600');</script>");
		}

		protected void btn_BackVA_Click(object sender, System.EventArgs e)
		{
			CheckBox chk;
			DataTable dt;

			bool ok = false;
			string regno = "";
			for (int i = 0; i < dgListSPPK.Items.Count; i++)
			{
				chk = (CheckBox) dgListSPPK.Items[i].Cells[6].FindControl("CheckBox1");
				
				if (chk.Checked == true)
				{	
					//////////////////////////////////////////////////////////////////////////////
					/// Mark this application as a-never-been-in-approval-application
					/// 
					/*
					conn.QueryString = "update CUSTPRODUCT set CP_DECSTA = '' " + 
						"where AP_REGNO = '"+dgListSPPK.Items[i].Cells[0].Text+"'";
					conn.ExecuteQuery();
					*/

					//conn.QueryString = "select apptype, productid, PROD_SEQ from custproduct where ap_regno='" + dgListSPPK.Items[i].Cells[0].Text + "'";

					conn.QueryString = "exec SPPK_GETPROD_BACKVA '" + dgListSPPK.Items[i].Cells[0].Text + "', '" + Request.QueryString["tc"] + "'";					
					conn.ExecuteQuery();
					dt = conn.GetDataTable().Copy();
					for (int j = 0; j < dt.Rows.Count; j++)
					{						
						conn.QueryString = "exec TRACKBACK '" + 
							dgListSPPK.Items[i].Cells[0].Text + "', '" +
							dt.Rows[j][1].ToString() + "', '" + 
							dt.Rows[j][0].ToString() + "', '" + 
							Session["UserID"].ToString() + "', '" + 
							dt.Rows[j]["prod_seq"].ToString() + "'";
						conn.ExecuteNonQuery();
					}


					if (i==0) regno = dgListSPPK.Items[i].Cells[0].Text; // set value regno
					ok = true;


					//////////////////////////////////////////////////////////////////////
					/// audit trail
					try
					{
						conn.QueryString = "SP_AUDITTRAIL_APP '" + 
							dgListSPPK.Items[i].Cells[0].Text + "', null, null, null, '" + 
							dt.Rows[0]["CU_REF"].ToString() + "','" + 
							Request.QueryString["tc"] + "','Back to Ver Assignment', " + 
							"null" + ", '" +  
							Session["userid"].ToString() + "',null,null";
						conn.ExecuteNonQuery();
					}
					catch (Exception ex)
					{
						ExceptionHandling.Handler.saveExceptionIntoWindowsLog(ex, Request.Path, dgListSPPK.Items[i].Cells[0].Text + " Back to VA");
					}

					//DataTable dt;
					//conn.QueryString = "select CP.APPTYPE, CP.PRODUCTID, CP.CP_REJECT, CP.CP_CANCEL from CUST_PRODUCT CP left join " + 
					//	"APPLICATION AP on AP.AP_REGNO=CP.AP_REGNO where AP.AP_REGNo='" + dgListSPPK.Items[i].Cells[0].Text + "'"; /* and " + 
					//	"(isnull(CP.CP_REJECT, '0') <> '1' or isnull(CP.CP_CANCEL, '0')<> '1')";*/
					//conn.ExecuteQuery();

					//dt = conn.GetDataTable().Copy();

					/*
					for (int j = 0; j < dt.Rows.Count; j++)
					{
						string apptype		= dt.Rows[j][0].ToString().Trim();
						string productid	= dt.Rows[j][1].ToString().Trim();

						conn.QueryString = "update CUST_PRODUCT set CP_DECSTA = '' " + 
											"where AP_REGNO = '"+dgListSPPK.Items[i].Cells[0].Text+"' "+
											" and PRODUCTID = '"+productid+
											"' and APPTYPE = '"+apptype+"' ";
						conn.ExecuteQuery();
	
						conn.QueryString = "exec TRACKBACK '" + 
												dgListSPPK.Items[i].Cells[0].Text + "', '" +
												productid + "', '" + 
												apptype + "', '" + 
												Session["UserID"].ToString() + "'";
						conn.ExecuteNonQuery();	

						conn.QueryString = "update application set ap_isappeal = '1' where ap_regno='" + dgListSPPK.Items[i].Cells[0].Text + "'";
						conn.ExecuteNonQuery();
					}
					*/
				}
			}

			ViewData("0");			


			///////////////////////////////////////////////
			///	Prompt message
			///	
			// if (ok) GlobalTools.popMessage(this, getPrevStepMsg(regno, Request.QueryString["tc"]));
			string msg = "Application is Back to Verification Assignment";
			GlobalTools.popMessage(this, msg);
		}
	}
}
