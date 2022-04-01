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

namespace SME.Scoring
{
	/// <summary>
	/// Summary description for Main.sdafsadf
	/// </summary>
	public partial class MainFairIsaac : System.Web.UI.Page
	{
		protected Connection conn;
		protected System.Web.UI.WebControls.CompareValidator SRLIMIT_VALID;
		protected Tools tool = new Tools();
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			conn = (Connection) Session["Connection"];

			if (!Logic.AllowAccess(Session["GroupID"].ToString(), Request.QueryString["mc"], conn))
				Response.Redirect("/SME/Restricted.aspx");

			if (!IsPostBack)
			{
				LBL_USERID.Text = Session["UserID"].ToString();

				fillOverall();
				fillScoreResult();
				fillVisitIndicator();
				fillRuleReason();
				fillFinAnalysis();
				fillManualReview();
				ViewData();				
			}
			ViewMenu();
			updatestatus.Attributes.Add("onclick", "if(!update()) { return false; };");
			BTN_SAVE.Attributes.Add("onclick","if(!cek_mandatory(document.Form1)){return false;};");
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

		private void fillOverall() 
		{
			conn.QueryString = "select * from RFSCRSTRATEGYWARE where ACTIVE = '1'";
			conn.ExecuteQuery();
			if (conn.GetRowCount() > 0) 
			{
				for(int i=0; i<conn.GetRowCount(); i++) 
				{
					DDL_SR_OVERALL.Items.Add(new ListItem(conn.GetFieldValue(i,1), conn.GetFieldValue(i,0)));
				}
			}
		}

		private void fillScoreResult() 
		{
			conn.QueryString = "select * from RFSCRRESULT where ACTIVE = '1'";
			conn.ExecuteQuery();
			if (conn.GetRowCount() > 0) 
			{
				for(int i=0; i<conn.GetRowCount(); i++) 
				{
					DDL_SR_SCORE.Items.Add(new ListItem(conn.GetFieldValue(i,1), conn.GetFieldValue(i,0)));
				}
			}
		}

		private void fillVisitIndicator() 
		{
			conn.QueryString = "select * from RFSCRVISIT where ACTIVE = '1'";
			conn.ExecuteQuery();
			if (conn.GetRowCount() > 0) 
			{
				for(int i=0; i<conn.GetRowCount(); i++) 
				{
					DDL_SR_VISITINDCTR.Items.Add(new ListItem(conn.GetFieldValue(i,1), conn.GetFieldValue(i,0)));
				}
			}
		}

		private void fillRuleReason() 
		{
			conn.QueryString = "select * from RFSCRRULEREASON where ACTIVE = '1'";
			conn.ExecuteQuery();
			if (conn.GetRowCount() > 0) 
			{
				for(int i=0; i<conn.GetRowCount(); i++) 
				{
					DDL_SR_RULECODE.Items.Add(new ListItem(conn.GetFieldValue(i,1), conn.GetFieldValue(i,0)));
				}
			}
		}

		private void fillFinAnalysis() 
		{
			conn.QueryString = "select * from RFSCRFINANALYSIS where ACTIVE = '1'";
			conn.ExecuteQuery();
			if (conn.GetRowCount() > 0) 
			{
				for(int i=0; i<conn.GetRowCount(); i++) 
				{
					DDL_CREDPROP.Items.Add(new ListItem(conn.GetFieldValue(i,1), conn.GetFieldValue(i,0)));
				}
			}
		}

		private void fillManualReview() 
		{
			conn.QueryString = "select * from RFSCRMANUALREVIEW where ACTIVE = '1'";
			conn.ExecuteQuery();
			if (conn.GetRowCount() > 0) 
			{
				for(int i=0; i<conn.GetRowCount(); i++) 
				{
					DDL_SR_MANREVIEW.Items.Add(new ListItem(conn.GetFieldValue(i,1), conn.GetFieldValue(i,0)));
				}
			}
		}

		private void ViewData()
		{
			conn.QueryString = "select * from SCORERESULT where ap_regno='" + Request.QueryString["regno"] + "'";
			conn.ExecuteQuery();

			try 
			{
				this.DDL_SR_OVERALL.SelectedValue = conn.GetFieldValue("SR_OVERALL");
			} 
			catch (Exception) 
			{
				this.DDL_SR_OVERALL.SelectedValue = "";
			}
			try 
			{
				this.DDL_SR_SCORE.SelectedValue = conn.GetFieldValue("SR_SCORE");
			}
			catch (Exception) 
			{
				this.DDL_SR_SCORE.SelectedValue = "";
			}
			try 
			{
				this.DDL_SR_VISITINDCTR.SelectedValue = conn.GetFieldValue("SR_VISITINDCTR");
			} 
			catch (Exception) 
			{
				this.DDL_SR_VISITINDCTR.SelectedValue = "";
			}
			try 
			{
				this.DDL_SR_RULECODE.SelectedValue = conn.GetFieldValue("SR_RULECODE");
			} 
			catch (Exception) 
			{
				this.DDL_SR_RULECODE.SelectedValue = "";
			}
			try 
			{
				this.DDL_CREDPROP.SelectedValue = conn.GetFieldValue("SR_CREDPROPOSAL");
			} 
			catch (Exception) 
			{
				this.DDL_CREDPROP.SelectedValue = "";
			}
			try 
			{
				this.DDL_SR_MANREVIEW.SelectedValue = conn.GetFieldValue("SR_MANREVIEWTYPE");
			} 
			catch (Exception) 
			{
				this.DDL_SR_MANREVIEW.SelectedValue = "";
			}
		}

		protected void BTN_SAVE_Click(object sender, System.EventArgs e)
		{
			string query = "exec SR_FAIR_ISAAC " + 
				"'" + Request.QueryString["regno"] + "', " +
				"'" + this.DDL_SR_OVERALL.SelectedValue + "', " +
				"'" + this.DDL_SR_SCORE.SelectedValue + "'," + 
				"'" + this.DDL_SR_VISITINDCTR.SelectedValue + "'," + 
				"'" + this.DDL_SR_RULECODE.SelectedValue + "'," +
				"'" + this.DDL_CREDPROP.SelectedValue + "'," +
				"'" + this.DDL_SR_MANREVIEW.SelectedValue + "'," +
				"'" + tool.ConvertFloat(this.TXT_SR_RESULT.Text) + "'";
	
			conn.QueryString = query;
			conn.ExecuteNonQuery();	

			Button1.Visible = true;
			updatestatus.Visible = true;

			if (DDL_SR_OVERALL.SelectedValue == "1")
				Button1.Text = "Print AIP Letter";
			else if (DDL_SR_OVERALL.SelectedValue == "3")
				Button1.Text = "Print Reject Letter";
			else if (DDL_SR_OVERALL.SelectedValue == "2")	//--- Grey Zone
			{
				Button1.Text = "Print Reject Letter";
				/*
				if (isLowLine()) 
				{
					Button1.Text = "Print Reject Letter";
				}
				else 
				{
					Button1.Text = "Print AIP Letter";
				}
				*/
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
						strtemp = "?regno=" + Request.QueryString["regno"] + "&curef="+Request.QueryString["curef"]+"&mc="+Request.QueryString["mc"]+"&tc="+Request.QueryString["tc"];
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

		protected void updatestatus_Click(object sender, System.EventArgs e)
		{

			if (DDL_SR_OVERALL.SelectedValue == "1")			//--- ACCEPT
			{
				trackUpdate();
			}
			else if (DDL_SR_OVERALL.SelectedValue == "3")		//--- DECLINE
			{
				trackFail();
			}
			else if (DDL_SR_OVERALL.SelectedValue == "2")		//--- GREY ZONE
			{
				trackFail();
				/*
				//--- Periksa dulu Program yang dipilih
				//--- Apakah LOW-LINE / HIGH-LINE ?
				//--- Kalau LOW-LINE, reject ....
				//--- Kalau HIGH-LINE, lanjutkan ...
				if (isLowLine()) 
				{
					trackFail();
				}
				else //HIGH-LINE
				{
					trackUpdate();
				}
				*/
			}
		}

		private bool isLowLine() 
		{
			bool ret = true;

			//---- Memeriksa LOW-LINE atau HIGH-LINE
			conn.QueryString = "select * from VW_SR_GREYZONE_CEK where AP_REGNO = '"+Request.QueryString["regno"]+"'";
			conn.ExecuteQuery();
		
			if (conn.GetFieldValue("ISLOWLINE") == "0") ret = false;

			return ret;
		}

		private void trackUpdate() 
		{
			DataTable dt;
			conn.QueryString = "select checkbi from customer where cu_ref='" + Request.QueryString["curef"] + "'";
			conn.ExecuteQuery();
			if (conn.GetRowCount() > 0)
			{
				if (conn.GetFieldValue(0,0) == "1")
				{
					conn.QueryString = "insert into bi_status (ap_regno, cu_ref, bs_reqdate, bs_recvdate, bs_bidataavail, bs_complete) " + 
						"values ('" + Request.QueryString["regno"] + "', '" + Request.QueryString["curef"] + "', getdate(), null, null, '0')";
					conn.ExecuteQuery();
				}
			}
			
			conn.QueryString = "select apptype, productid, PROD_SEQ from custproduct where ap_regno='" + Request.QueryString["regno"] +
				"' AND isnull(cp_reject,'0') <> '1' and isnull(cp_cancel,'0') <> '1'";
			conn.ExecuteQuery();
			dt = conn.GetDataTable().Copy();
			for (int i = 0; i < dt.Rows.Count; i++)
			{
				conn.QueryString = "exec TRACKUPDATE '" + 
									Request.QueryString["regno"] + "', '" +
									dt.Rows[i][1].ToString() + "', '" + 
									dt.Rows[i][0].ToString() + "', '" + 
									LBL_USERID.Text + "', '" + 
									dt.Rows[i]["PROD_SEQ"].ToString() + "','"+
									Request.QueryString["tc"].Trim()+"'";
					//dt.Rows[i][1].ToString() + "', '" + dt.Rows[i][0].ToString() + "', '" + Session["UserID"].ToString() + "'";
				conn.ExecuteNonQuery();
			}

			string msg = getNextStepMsg(Request.QueryString["regno"]);
			Response.Redirect("FindCustomer.aspx?tc=" + Request.QueryString["tc"] + "&mc=" + Request.QueryString["mc"] + "&msg=" + msg);

		}

		private void trackFail() 
		{
			string sql = "update application set AP_REJECT = '1' where ap_regno = '"+Request.QueryString["regno"]+"' ";
			conn.QueryString = sql;
			conn.ExecuteNonQuery();
			
			conn.QueryString = "exec RJ_CHECKREJECT '" + Request.QueryString["regno"] + "', '" + Request.QueryString["curef"] + "'";
			conn.ExecuteNonQuery();

			DataTable dt;
			conn.QueryString = "select apptype, productid, prod_seq from custproduct where ap_regno='" + Request.QueryString["regno"] + "'";
			conn.ExecuteQuery();
			dt = conn.GetDataTable().Copy();
			for (int i = 0; i < dt.Rows.Count; i++)
			{
				conn.QueryString = "exec TRACKFAIL '" + Request.QueryString["regno"] + "', '" +
									dt.Rows[i][1].ToString() + "', '" + 
									dt.Rows[i][0].ToString() + "', '" + 
									LBL_USERID.Text + "', '" + 
									dt.Rows[i]["prod_seq"].ToString() + "','"+ Request.QueryString["tc"] +"'";
				conn.ExecuteNonQuery();
			}
			Response.Redirect("FindCustomer.aspx?tc=" + Request.QueryString["tc"] + "&mc=" + Request.QueryString["mc"]);
		}

		/*
		private void BTN_UPDATE_Click(object sender, System.EventArgs e)
		{
			conn.QueryString = "select apptype, productid from cust_product where ap_regno='" + Request.QueryString["regno"] + "'";
			conn.ExecuteQuery();
			for (int i = 0; i < conn.GetRowCount(); i++)
			{
				conn.QueryString = "exec TRACKUPDATE '" + Request.QueryString["regno"] + "', '" +
					conn.GetFieldValue(i,1) + "', '" + conn.GetFieldValue(i,0) + "', '" + Session["UserID"].ToString() + "'";
				conn.ExecuteNonQuery();
			}
			Response.Redirect("FindCustomer.aspx?tc=" + Request.QueryString["tc"] + "&mc=" + Request.QueryString["mc"]);
		}
		*/

		protected void Button1_Click(object sender, System.EventArgs e)
		{
			if (DDL_SR_OVERALL.SelectedValue == "DL" || DDL_SR_OVERALL.SelectedValue == "3")
				Response.Write("<script language='javascript'>window.open('/SME/Letters/RejectLetter.aspx?regno=" + Request.QueryString["regno"] + "','RejectLetter','status=no,scrollbars=yes,width=800,height=600');</script>");
			else if (DDL_SR_OVERALL.SelectedValue == "AC" || DDL_SR_OVERALL.SelectedValue == "1")
			{
				conn.QueryString = "select cu_custtypeid from customer where cu_ref='" + Request.QueryString["curef"] + "'";
				conn.ExecuteQuery();
				if (conn.GetFieldValue(0,0) == "01")
					Response.Write("<script language='javascript'>window.open('/SME/Letters/AIP1.aspx?regno=" + Request.QueryString["regno"] + "&apptype=01','AIPLetter','status=no,scrollbars=yes,width=800,height=600');</script>");
				else
					Response.Write("<script language='javascript'>window.open('/SME/Letters/AIP2.aspx?regno=" + Request.QueryString["regno"] + "&apptype=01','AIPLetter','status=no,scrollbars=yes,width=800,height=600');</script>");
			}
			else 
			{
				string TEXT = Button1.Text;
				if (TEXT.IndexOf("AIP") >= 0) 
				{
					conn.QueryString = "select cu_custtypeid from customer where cu_ref='" + Request.QueryString["curef"] + "'";
				conn.ExecuteQuery();
				if (conn.GetFieldValue(0,0) == "01")
					Response.Write("<script language='javascript'>window.open('/SME/Letters/AIP1.aspx?regno=" + Request.QueryString["regno"] + "&apptype=01','AIPLetter','status=no,scrollbars=yes,width=800,height=600');</script>");
				else
					Response.Write("<script language='javascript'>window.open('/SME/Letters/AIP2.aspx?regno=" + Request.QueryString["regno"] + "&apptype=01','AIPLetter','status=no,scrollbars=yes,width=800,height=600');</script>");

				}
				else 
				{
					Response.Write("<script language='javascript'>window.open('/SME/Letters/RejectLetter.aspx?regno=" + Request.QueryString["regno"] + "','RejectLetter','status=no,scrollbars=yes,width=800,height=600');</script>");
				}
			}
		}
	}
}
