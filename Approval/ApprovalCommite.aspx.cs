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
using Microsoft.VisualBasic;
using DMS.CuBESCore;
using DMS.DBConnection;

namespace SME.Approval
{
	/// <summary>
	/// Summary description for ApprovalCommite. 
	/// 
	/// 
	/// </summary>
	public partial class ApprovalCommite : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Button updatestatus;
		protected Tools tool = new Tools();
		protected Connection conn;
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			conn = (Connection) Session["Connection"];

			if (!IsPostBack)
			{
				LBL_REGNO.Text	= Request.QueryString["regno"];
				LBL_CUREF.Text	= Request.QueryString["curef"];
				LBL_TC.Text		= Request.QueryString["tc"];
				LBL_MC.Text		= Request.QueryString["mc"];				

				//--- initialization picklist ----------------------//
				fillCommitee();
				fillNonCommiteeApprv();
				fillLastApproval();
				//--------------------------------------------------//

				viewData();

				////////////////////////////////////////////////////////
				///	men-set current approval dengan next approval
				///	
				conn.QueryString = "select top 1 ADC_NEXTAPRV from APPROVAL_DECISION_COMMITEE where AP_REGNO = '" + LBL_REGNO.Text + "' order by ADC_SEQ desc";
				conn.ExecuteQuery();

				try {DDL_CURR_APRV.SelectedValue = conn.GetFieldValue("ADC_NEXTAPRV"); }
				catch {}
				//////////////////////////////////////////////////////////

				if (LBL_TC.Text == "" || LBL_TC.Text == null) 
				{
					TBL_ENTRY.Visible	= false;
					TR_BUTTONS.Visible	= false;
				}
			}

			ViewMenu();
			initEvents();

			BTN_UPDATESTATUS.Attributes.Add("onclick", "if(!cek_mandatory(document.Form1)){return false;}; if(!update()){return false;};");
			BTN_SAVE.Attributes.Add("onclick","if(!cek_mandatory(document.Form1)){return false;};");
		}

		private void initEvents() 
		{
			BTN_UPDATESTATUS.Click += new EventHandler(BTN_UPDATESTATUS_Click);
			BTN_SAVE.Click += new EventHandler(BTN_SAVE_Click);
			BTN_BACK.Click += new ImageClickEventHandler(BTN_BACK_Click);
		}

		private void fillCommitee() 
		{
			//--- Ambil user yang tidak punya upliner
			GlobalTools.fillRefList(DDL_CURR_APRV, "exec SP_APPROVALCOMMITEE '" + LBL_REGNO.Text + "'", false, conn);
			GlobalTools.fillRefList(DDL_NEXT_APRV, "exec SP_APPROVALCOMMITEE '" + LBL_REGNO.Text + "'", false, conn);
		}

		private void fillLastApproval() 
		{
			try 
			{				
				GlobalTools.fillRefList(DDL_FIRSTAPPRV, "select * from VW_APPROVALUSER1_PUSAT", false, conn);	
				GlobalTools.fillRefList(DDL_SECONDAPPRV, "select * from VW_APPROVALUSER2_PUSAT", false, conn);	
			}
			catch (NullReferenceException) 
			{
				GlobalTools.popMessage(this, "Connection Error!");
				Response.Redirect("../Login.aspx?expire=1");
			}
		}

		private void fillNonCommiteeApprv() 
		{
			try 
			{
				//////////////////////////////////////////////
				///	mengambil BU Approval
				///	
				conn.QueryString = "exec SP_APPROVAL_NONCOMMITEEAPRV '" + LBL_REGNO.Text + "', '1'";
				conn.ExecuteQuery();
			} 
			catch (NullReferenceException) 
			{
				GlobalTools.popMessage(this, "Connection Error!");
				Response.Redirect("../Login.aspx?expire=1");
			}

			LBL_BU_APPROVAL.Text = conn.GetFieldValue("SU_FULLNAME");

			try 
			{
				///////////////////////////////////////////////////
				///	mengambil CRM Approval
				///	
				conn.QueryString = "exec SP_APPROVAL_NONCOMMITEEAPRV '" + LBL_REGNO.Text + "', '2'";
				conn.ExecuteQuery();
			}
			catch (NullReferenceException) 
			{
				GlobalTools.popMessage(this, "Connection Error!");
				Response.Redirect("../Login.aspx?expire=1");
			}
			LBL_CRM_APPROVAL.Text = conn.GetFieldValue("SU_FULLNAME");			
		}

		private void viewData() 
		{
			try 
			{
				conn.QueryString = "select * from VW_APPROVALCOMMITEE_LIST where AP_REGNO = '" + LBL_REGNO.Text + "'";
				conn.ExecuteQuery();
			} 
			catch (NullReferenceException) 
			{
				GlobalTools.popMessage(this, "Connection Error!");
				Response.Redirect("../Login.aspx?expire=1");
			}

			DGR_APRVCOMMITEE.DataSource = conn.GetDataTable().Copy();
			DGR_APRVCOMMITEE.DataBind();
		}

		private void saveToApprovalDecision() 
		{
			//////////////////////////////////////////////////////////
			///	menyimpan 1st approval dan 2nd approval
			///	ke table APPROVAL_DECISION
			///	untuk kebutuhan hosting ke eMAS
			///	
			conn.QueryString = "exec SP_APPROVAL_IN_COMMITEE2 '" + 
				DDL_FIRSTAPPRV.SelectedValue + "', '" + 
				DDL_SECONDAPPRV.SelectedValue + "', '" + 
				LBL_REGNO.Text + "'";
			conn.ExecuteNonQuery();
		}

		private void saveToDatabase(string mode) 
		{
			try 
			{
				conn.QueryString	= "select * from rfinitial";
				conn.ExecuteQuery();
			} 
			catch (NullReferenceException) 
			{
				GlobalTools.popMessage(this, "Connection Error!");
				Response.Redirect("../Login.aspx?expire=1");
			}
			string var_reject = conn.GetFieldValue("in_reject");

			try 
			{
				conn.QueryString = "select * from vw_currtrack where ap_regno = '"+ LBL_REGNO.Text + 
					"' and isnull(cp_decsta,'') <> '" + var_reject + "'";
				conn.ExecuteQuery();
			}
			catch (NullReferenceException) 
			{
				GlobalTools.popMessage(this, "Connection Error!");
				Response.Redirect("../Login.aspx?expire=1");
			}

			DataTable dt_currtrack = new DataTable();
			dt_currtrack = conn.GetDataTable().Copy();
			
			for (int cnt = 0; cnt < dt_currtrack.Rows.Count;cnt++) 
			{
				conn.QueryString = "exec SP_APPROVAL_IN_COMMITEE '" + 
					LBL_REGNO.Text + "', '" + 
					dt_currtrack.Rows[cnt]["apptype"].ToString() + "', '" + 
					dt_currtrack.Rows[cnt]["productid"].ToString() + "', '" + 
					dt_currtrack.Rows[cnt]["PROD_SEQ"].ToString() + "', " + 
					tool.ConvertNull(DDL_DEC_FINAL.SelectedValue) + ", '" + 
					DDL_CURR_APRV.SelectedValue + "', '" + 
					DDL_DEC_CURR.SelectedValue + "', '" + 
					DDL_NEXT_APRV.SelectedValue + "', '" + mode + "'";
				conn.ExecuteNonQuery();				
			}			
		}

		private void clearFields() 
		{
			DDL_CURR_APRV.SelectedValue		= "";
			DDL_DEC_CURR.SelectedValue		= "-";
			DDL_NEXT_APRV.SelectedValue		= "";
			DDL_DEC_FINAL.SelectedValue		= "-";

//			BTN_SAVE.Enabled = false;
//
//			DDL_CURR_APRV.Enabled	= false;
//			DDL_DEC_CURR.Enabled	= false;
//			DDL_NEXT_APRV.Enabled	= false;
//			DDL_DEC_FINAL.Enabled	= false;
//
//			DDL_CURR_APRV.CssClass = "";
//			DDL_DEC_CURR.CssClass = "";

		}

		private void trackUpdate() 
		{
			try 
			{
				conn.QueryString	= "select * from rfinitial";
				conn.ExecuteQuery();
			} 
			catch (NullReferenceException) 
			{
				GlobalTools.popMessage(this, "Connection Error!");
				Response.Redirect("../Login.aspx?expire=1");
			}
			string var_reject = conn.GetFieldValue("in_reject");

			try 
			{
				conn.QueryString = "select * from vw_currtrack where ap_regno = '"+ LBL_REGNO.Text + 
					"' and isnull(cp_decsta,'') <> '" + var_reject + "'";
				conn.ExecuteQuery();
			}
			catch (NullReferenceException) 
			{
				GlobalTools.popMessage(this, "Connection Error!");
				Response.Redirect("../Login.aspx?expire=1");
			}

			DataTable dt_currtrack = new DataTable();
			dt_currtrack = conn.GetDataTable().Copy();
			
			for (int cnt = 0; cnt < dt_currtrack.Rows.Count;cnt++) 
			{
				conn.QueryString = "exec SP_APPROVAL_COMMITEE_TRACKUPDATE '" + 
					LBL_REGNO.Text + "', '" + 
					dt_currtrack.Rows[cnt]["apptype"].ToString() + "', '" + 
					dt_currtrack.Rows[cnt]["productid"].ToString() + "', '" + 
					dt_currtrack.Rows[cnt]["PROD_SEQ"].ToString() + "'";
				conn.ExecuteNonQuery();				
			}	
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
							strtemp = "regno=" + Request.QueryString["regno"] + "&curef="+Request.QueryString["curef"]+"&tc="+Request.QueryString["tc"];
						else	strtemp = "regno=" + Request.QueryString["regno"] + "&curef="+Request.QueryString["curef"]+"&mc="+Request.QueryString["mc"]+"&tc="+Request.QueryString["tc"];
						//t.ForeColor = Color.MidnightBlue; 
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


		private string getNextStepMsg(string regno) 
		{
			string pesan = "";
			string nextTrack = "";
			try 
			{
				/***
				 * Memunculkan pesan next step
				 ***/
				conn.QueryString = "exec TRACKNEXTMSG '" + regno + "'";
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

		private void BTN_SAVE_Click(object sender, System.EventArgs e)
		{
			if (DDL_DEC_FINAL.SelectedValue == "-" && DDL_NEXT_APRV.SelectedValue == "") 
			{
				GlobalTools.popMessage(this, "Next Approval tidak boleh kosong!");
				return;
			}

			saveToDatabase("1");
			clearFields();
			viewData();			

			////////////////////////////////////////////////////////
			///	men-set current approval dengan next approval
			///	
			conn.QueryString = "select top 1 ADC_NEXTAPRV from APPROVAL_DECISION_COMMITEE where AP_REGNO = '" + LBL_REGNO.Text + "' order by ADC_SEQ desc";
			conn.ExecuteQuery();

			try {DDL_CURR_APRV.SelectedValue = conn.GetFieldValue("ADC_NEXTAPRV"); }
			catch {}
			//////////////////////////////////////////////////////////
		}

		protected void BTN_UPDATESTATUS_Click(object sender, System.EventArgs e)
		{
			//////////////////////////////////////////////////////////////
			///	1st approval dan 2nd approval tidak boleh sama
			///	
			if (DDL_FIRSTAPPRV.SelectedValue == DDL_SECONDAPPRV.SelectedValue) 
			{
				GlobalTools.popMessage(this, "1st Approval tidak boleh sama dengan 2nd Approval!");
				return;
			}

			//
			// Kalau final Decision terisi, update status aplikasi ke SPPK
			// kalau tidak, lanjut ke tahap berikutnya
			//
			if (DDL_DEC_FINAL.SelectedValue != "-") 
			{
				// lanjut ke SPPK
				// Flag : 4 --> Save dan Update Status
				saveToDatabase("4");
				saveToApprovalDecision();
			}

			//string msg = getNextStepMsg(Request.QueryString["regno"]);
			string msg = "Application is " + DDL_DEC_FINAL.SelectedItem.Text;
			Response.Redirect("ListApprovalCommitee.aspx?msg="+msg+"&tc="+Request.QueryString["tc"]+"&mc="+Request.QueryString["mc"]);
		}

		protected void DDL_DEC_FINAL_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if (DDL_DEC_FINAL.SelectedValue != "-") 
			{
				BTN_SAVE.Enabled = false;
				BTN_UPDATESTATUS.Enabled = true;
				DDL_FIRSTAPPRV.Enabled = true;
				DDL_SECONDAPPRV.Enabled = true;
				
				DDL_FIRSTAPPRV.CssClass = "mandatory";
				DDL_SECONDAPPRV.CssClass = "mandatory";
			}
			else 
			{
				BTN_SAVE.Enabled = true;
				BTN_UPDATESTATUS.Enabled = false;
				DDL_FIRSTAPPRV.Enabled = false;
				DDL_SECONDAPPRV.Enabled = false;

				DDL_FIRSTAPPRV.CssClass = "";
				DDL_SECONDAPPRV.CssClass = "";
			}
		}

		protected void BTN_BACK_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			Response.Redirect("ListApprovalCommitee.aspx?tc="+Request.QueryString["tc"]+"&mc="+Request.QueryString["mc"]);
		}

		protected void BTN_ACQINFO_Click(object sender, System.EventArgs e)
		{

//			//
//			// mengambil status appeal
//			//
//			conn.QueryString = "select isnull(ap_isappeal,0) ap_isappeal from application where ap_regno = '" + LBL_REGNO.Text + "'";
//			conn.ExecuteQuery();
//			string var_fromsta = conn.GetFieldValue("ap_isappeal");
//
//
//			conn.QueryString = "select * from vw_currtrack where ap_regno = '" + LBL_REGNO.Text + "'";
//			conn.ExecuteQuery();
//			int cnttrack = conn.GetRowCount();
//
//			conn.QueryString = "select * from approval_decision where ap_regno = '" + LBL_REGNO.Text + "' "+
//				" and userid = '" + lbl_user + "' and ad_fromsta = '"+var_fromsta+"'";
//			conn.ExecuteQuery();
//			int cntad = conn.GetRowCount();
//
//			if (cnttrack != cntad)
//			{
//				GlobalTools.popMessage(this, "Check Approval Structure Credit First!");
//				return;
//			}

			Response.Write("<script for=window event=onload language='javascript'>PopupPage('AcqInfo.aspx?regno=" + LBL_REGNO.Text + "&curef=" + LBL_CUREF.Text + "&aprv=CRM&theForm=Form1&theObj=TXT_TEMP', '800','300');</script>");

		}

		protected void TXT_TEMP_TextChanged(object sender, System.EventArgs e)
		{
			if (TXT_TEMP.Text != "") 
			{
				string msg = "";
				msg = "Application acquire information from " + TXT_TEMP.Text + " !";
				Response.Redirect("ListApprovalCommitee.aspx?mc="+Request.QueryString["mc"]+"&tc=" + Request.QueryString["tc"]+"&msg="+msg);
			}
		}
	}
}
