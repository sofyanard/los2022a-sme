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
namespace SME.ITTP
{
	/// <summary>
	/// Summary description for ListReject.
	/// </summary>
	public partial class ListReject : System.Web.UI.Page
	{
		protected Connection conn;
		protected Tools tool = new Tools();

	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			conn = (Connection) Session["Connection"];

			if (!Logic.AllowAccess(Session["GroupID"].ToString(), Request.QueryString["mc"], conn))
				Response.Redirect("/SME/Restricted.aspx");

			if (!IsPostBack)
			{
				ViewData("0");
			}
		}

		private void ViewData(string sta)
		{	
			DataTable dt = new DataTable();
			if (sta == "1")
				conn.QueryString = "select distinct ap_regno, cu_ref, cu_name, ap_signdate from vw_it_list where ap_regno = '"+txt_regno.Text+"' and ap_currtrack='" + Request.QueryString["tc"] + "' and (ap_relmngr='" + Session["UserID"].ToString() + "' or ap_relmngr is null) and ap_reject='1'";
			else
				conn.QueryString = "select distinct ap_regno, cu_ref, cu_name, ap_signdate from vw_it_list where ap_currtrack='" + Request.QueryString["tc"] + "' and (ap_relmngr='" + Session["UserID"].ToString() + "' or ap_relmngr is null) and ap_reject='1'";
			conn.ExecuteQuery();
			dt = conn.GetDataTable().Copy();
			dgListReject.DataSource = dt;
			dgListReject.DataBind();

			for (int i = 0; i < dgListReject.Items.Count; i++)
			{
				dgListReject.Items[i].Cells[3].Text = tool.FormatDate(dgListReject.Items[i].Cells[3].Text, true);
				//dgListReject.Items[i].Cells[5].Text = tool.MoneyFormat(dgListReject.Items[i].Cells[5].Text);
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
			this.dgListReject.ItemCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.dgListReject_ItemCommand);

		}
		#endregion

		private void dgListReject_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			switch (((LinkButton)e.CommandSource).CommandName)
			{
				case "view":
					//Response.Redirect("viewsppk.aspx?regno="+e.Item.Cells[0].Text+"&curef="+e.Item.Cells[1].Text);
					//Response.Redirect("../Letters/RejectLetter.aspx?regno=" + e.Item.Cells[0].Text + "&apptype=" + e.Item.Cells[8].Text + "&prodid=" + e.Item.Cells[9].Text );
					Response.Redirect("../Letters/RejectLetter.aspx?regno=" + e.Item.Cells[0].Text + "&tc=" + Request.QueryString["tc"] + "&mc=" + Request.QueryString["mc"]);
					break;
			}
		}

		protected void btn_cari_Click(object sender, System.EventArgs e)
		{
			ViewData("1");
		}

		protected void Button2_Click(object sender, System.EventArgs e)
		{ //tombol Update Status
			CheckBox chk;

			for (int i = 0; i < dgListReject.Items.Count; i++)
			{
				chk = (CheckBox) dgListReject.Items[i].Cells[4].FindControl("CheckBox1");
				
				if (chk.Checked == true)
				{
					DataTable dt;
					conn.QueryString = "select apptype, productid, PROD_SEQ from custproduct where ap_regno='" + dgListReject.Items[i].Cells[0].Text + "'";
					//	"' AND isnull(cp_reject,'0') = '1' and isnull(cp_cancel,'0') = '1'";
					conn.ExecuteQuery(); 
					dt = conn.GetDataTable().Copy();
			
					bool updateYes = false;
					for (int j = 0; j < dt.Rows.Count; j++)
					{
						conn.QueryString = "exec IT_TRACKUPDATE '" + 
							dgListReject.Items[i].Cells[0].Text + "', '" +
							dt.Rows[j][1].ToString() + "', '" + 
							dt.Rows[j][0].ToString() + "', '" + 
							Session["UserID"].ToString() + "', '" + 
							dt.Rows[j]["PROD_SEQ"].ToString() + "',";//'"+ Request.QueryString["tc"].Trim() +"'";
						conn.ExecuteNonQuery();
						updateYes = true;
					}

					// menampilkan pesan next step - Gatot
					if (updateYes)
					{
						string msg = getNextStepMsg(dgListReject.Items[i].Cells[0].Text);
						GlobalTools.popMessage(this, msg);
					}
				}
			}

			ViewData("0");
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

		protected void btn_BackVA_Click(object sender, System.EventArgs e)
		{
			CheckBox chk;

			for (int i = 0; i < dgListReject.Items.Count; i++)
			{
				chk = (CheckBox) dgListReject.Items[i].Cells[4].FindControl("CheckBox1");
				
				if (chk.Checked == true)
				{
					//////////////////////////////////////////////////////////////////////////////
					/// Mark this application as a-never-been-in-approval-application
					/// 
					/*
					conn.QueryString = "update CUSTPRODUCT set CP_DECSTA = '' " + 
						"where AP_REGNO = '"+dgListReject.Items[i].Cells[0].Text+"'";
					conn.ExecuteQuery();
					*/


					DataTable dt;

					conn.QueryString = "exec IT_SPPK_GETPROD_BACKVA '" + dgListReject.Items[i].Cells[0].Text + "', '" + Request.QueryString["tc"] + "'";
					conn.ExecuteQuery();
					dt = conn.GetDataTable().Copy();
					for (int j = 0; j < dt.Rows.Count; j++)
					{						
						conn.QueryString = "exec IT_TRACKBACK '" + 
							dgListReject.Items[i].Cells[0].Text + "', '" +
							dt.Rows[j][1].ToString() + "', '" + 
							dt.Rows[j][0].ToString() + "', '" + 
							Session["UserID"].ToString() + "', '" + 
							dt.Rows[j]["prod_seq"].ToString() + "'";
						conn.ExecuteNonQuery();
					}
					
					//////////////////////////////////////////////////////////////////////
					/// audit trail
/*					try
					{
						conn.QueryString = "SP_AUDITTRAIL_APP '" + 
							dgListReject.Items[i].Cells[0].Text + "', null, null, null, '" + 
							dt.Rows[0]["CU_REF"].ToString() + "','" + 
							Request.QueryString["tc"] + "','Back to Ver Assignment', " + 
							"null" + ", '" +  
							Session["userid"].ToString() + "',null,null";
						conn.ExecuteNonQuery();
					}
					catch (Exception ex)
					{
						ExceptionHandling.Handler.saveExceptionIntoWindowsLog(ex, Request.Path, dgListReject.Items[i].Cells[0].Text + " Back to VA");
					}			
*/				}
			}

			ViewData("0");

			///////////////////////////////////////////////
			///	Prompt message
			///	
			string msg = "Application is Back to Pending Application";
			GlobalTools.popMessage(this, msg);
		}
	}
}
