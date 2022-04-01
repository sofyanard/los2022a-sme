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
	/// Summary description for Main.
	/// </summary>
	public partial class FairIsaac : System.Web.UI.Page
	{
		protected Tools tool = new Tools();
		protected System.Web.UI.WebControls.CompareValidator SRLIMIT_VALID;
		protected System.Web.UI.WebControls.ImageButton ImageButton1;
		protected Connection conn;
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			conn = (Connection) Session["Connection"];

			if (!Logic.AllowAccess(Session["GroupID"].ToString(), Request.QueryString["mc"], conn))
				Response.Redirect("/SME/Restricted.aspx");
			if (!IsPostBack)
			{
				fillOverall();
				fillScoreResult();
				fillVisitIndicator();
				fillRuleReason();
				fillFinAnalysis();
				fillManualReview();
				ViewData();				
			}
			SecureData();
			ViewMenu();
			DDL_SR_OVERALL.SelectedIndexChanged +=new EventHandler(DDL_SR_OVERALL_SelectedIndexChanged);
			updatestatus.Click += new EventHandler(updatestatus_Click);
			updatestatus.Attributes.Add("onclick", "if(!cek_mandatory(document.Form1)){return false;}; if(!update()) { return false; };");
			BTN_SAVE.Attributes.Add("onclick","if(!cek_mandatory(document.Form1)){return false;};");
		}
		

		/// <summary>
		/// Back Link jika provide hanya "mc"
		/// </summary>
		/// <param name="mc"></param>
		/// <returns></returns>
		private string backLinkLocal(string mc) 
		{
			try 
			{
				conn.QueryString = "select TM_LINKNAME + TM_PARSINGPARAM as BACKLINK from track_menu where menucode = '" + mc + "'";
				conn.ExecuteQuery(); 

				return conn.GetFieldValue("BACKLINK");
			}
			catch (NullReferenceException e) 
			{
				GlobalTools.popMessage(this, "Server Error!");				
				return "Login.aspx?expire=1";
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

		private void SecureData() 
		{
			string scr = Request.QueryString["scr"];

			if (scr == "0")
			{
				int index = -1;
				System.Web.UI.ControlCollection coll = this.Page.Controls;
				
				for(int j=0; j<coll.Count; j++) 
				{
					if (coll[j] is HtmlForm) 
					{
						index = j;
						break;
					}
				}

				/// kalau ada masalah dengan form, maka secure secara manual
				/// 
				if (index == -1) 
				{
					DDL_CREDPROP.Enabled = false;
					DDL_SR_DECISION.Enabled = false;
					DDL_SR_DECSETBY.Enabled = false;
					DDL_SR_MANREVIEW.Enabled = false;
					DDL_SR_OVERALL.Enabled = false;
					DDL_SR_OVERRIDE.Enabled = false;
					DDL_SR_RULECODE.Enabled = false;
					DDL_SR_SCORE.Enabled = false;
					DDL_SR_SCRRECOMM.Enabled = false;
					DDL_SR_VISITINDCTR.Enabled = false;
					return;
				}

				for (int i = 0; i < coll[index].Controls.Count; i++) 
				{
					if (coll[index].Controls[i] is TextBox) 
					{
						TextBox txt = (TextBox) coll[index].Controls[i];
						txt.ReadOnly = true;
					}
					else if (coll[index].Controls[i] is DropDownList) 
					{
						DropDownList ddl = (DropDownList) coll[index].Controls[i];
						ddl.Enabled = false;
					}
					else if (coll[index].Controls[i] is Button)
					{
						Button btn = (Button) coll[index].Controls[i];
						btn.Visible = false;
					}
					else if (coll[index].Controls[i] is RadioButtonList) 
					{
						RadioButtonList rbl = (RadioButtonList) coll[index].Controls[i];
						rbl.Enabled = false;
					}
					else if (coll[index].Controls[i] is RadioButton) 
					{
						RadioButton rb = (RadioButton) coll[index].Controls[i];
						rb.Enabled = false;
					}
					else if (coll[index].Controls[i] is CheckBox)
					{
						CheckBox cb = (CheckBox) coll[index].Controls[i];
						cb.Enabled = false;
					}					
					else if (coll[index].Controls[i] is HtmlTableRow) 
					{
						HtmlTableRow htr = (HtmlTableRow) coll[index].Controls[i];

						for (int j=0; j < htr.Controls.Count; j++) 
						{							
							for (int jj = 0; jj < htr.Controls[j].Controls.Count; jj++) 
							{
								if (htr.Controls[j].Controls[jj] is TextBox) 
								{
									TextBox txt = (TextBox) htr.Controls[j].Controls[jj];
									txt.ReadOnly = true;
								}
								else if (htr.Controls[j].Controls[jj] is DropDownList) 
								{
									DropDownList ddl = (DropDownList) htr.Controls[j].Controls[jj];
									ddl.Enabled = false;
								}
								else if (htr.Controls[j].Controls[jj] is Button)
								{
									Button btn = (Button) htr.Controls[j].Controls[jj];
									btn.Visible = false;
								}
								else if (htr.Controls[j].Controls[jj] is RadioButtonList) 
								{
									RadioButtonList rbl = (RadioButtonList) htr.Controls[j].Controls[jj];
									rbl.Enabled = false;
								}
								else if (htr.Controls[j].Controls[jj] is RadioButton) 
								{
									RadioButton rb = (RadioButton) htr.Controls[j].Controls[jj];
									rb.Enabled = false;
								}
								else if (htr.Controls[j].Controls[jj] is CheckBox)
								{
									CheckBox cb = (CheckBox) htr.Controls[j].Controls[jj];
									cb.Enabled = false;
								}					
							}
						}
					}
				}
			}
		}

		private void fillOverall() 
		{
		
			if (Request.QueryString["scr"] == "0") conn.QueryString = "select * from RFSCRSTRATEGYWARE";
			else conn.QueryString = "select * from RFSCRSTRATEGYWARE where ACTIVE = '1'";
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
			if (Request.QueryString["scr"] == "0") conn.QueryString = "select * from RFSCRRESULT";
			else conn.QueryString = "select * from RFSCRRESULT where ACTIVE = '1'";
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
			if (Request.QueryString["scr"] == "0") conn.QueryString = "select * from RFSCRVISIT";
			else conn.QueryString = "select * from RFSCRVISIT where ACTIVE = '1'";
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
			if (Request.QueryString["scr"] == "0") conn.QueryString = "select * from RFSCRRULEREASON";
			else conn.QueryString = "select * from RFSCRRULEREASON where ACTIVE = '1'";
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
			if (Request.QueryString["scr"] == "0") conn.QueryString = "select * from RFSCRFINANALYSIS";
			else conn.QueryString = "select * from RFSCRFINANALYSIS where ACTIVE = '1'";
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
			if (Request.QueryString["scr"] == "0") conn.QueryString = "select * from RFSCRMANUALREVIEW";
			else conn.QueryString = "select * from RFSCRMANUALREVIEW where ACTIVE = '1'";
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
			try 
			{
				//conn.QueryString = "select * from SCORERESULT where ap_regno='" + Request.QueryString["regno"] + "'";
				conn.QueryString = "select *, cast(SR_LIMIT as float) SR_LIMIT_FLOAT from SCORERESULT where ap_regno='" + Request.QueryString["regno"] + "'";
				conn.ExecuteQuery();
			} 
			catch 
			{
				conn.QueryString = "select * from SCORERESULT where ap_regno='" + Request.QueryString["regno"] + "'";
				conn.ExecuteQuery();
			}

			try 
			{
				this.DDL_SR_OVERALL.SelectedValue = conn.GetFieldValue("SR_OVERALL");
			} 
			catch 
			{
				this.DDL_SR_OVERALL.SelectedValue = "";
			}
			try 
			{
				this.DDL_SR_SCORE.SelectedValue = conn.GetFieldValue("SR_SCORE");
			}
			catch 
			{
				this.DDL_SR_SCORE.SelectedValue = "";
			}
			try 
			{
				this.DDL_SR_VISITINDCTR.SelectedValue = conn.GetFieldValue("SR_VISITINDCTR");
			} 
			catch 
			{
				this.DDL_SR_VISITINDCTR.SelectedValue = "";
			}
			try 
			{
				this.DDL_SR_RULECODE.SelectedValue = conn.GetFieldValue("SR_RULECODE");
			} 
			catch 
			{
				this.DDL_SR_RULECODE.SelectedValue = "";
			}
			try 
			{
				this.DDL_CREDPROP.SelectedValue = conn.GetFieldValue("SR_CREDPROPOSAL");
			} 
			catch 
			{
				this.DDL_CREDPROP.SelectedValue = "";
			}
			try 
			{
				this.DDL_SR_MANREVIEW.SelectedValue = conn.GetFieldValue("SR_MANREVIEWTYPE");
			} 
			catch 
			{
				this.DDL_SR_MANREVIEW.SelectedValue = "";
			}
			try 
			{
				//TXT_SR_LIMIT.Text = conn.GetFieldValue("SR_LIMIT");
				//TXT_SR_LIMIT.Text = tool.MoneyFormat(conn.GetFieldValue("SR_LIMIT"));
				TXT_SR_LIMIT.Text = tool.MoneyFormat(conn.GetFieldValue("SR_LIMIT_FLOAT"));
			} 
			catch 
			{
				TXT_SR_LIMIT.Text = "";
			}
		}

		private void ViewMenu() 
		{
			try 
			{
				//--- Membuat menu Main FAIRISAAC
				HyperLink hlMain = new HyperLink();
				hlMain.ID = "MAIN";
				hlMain.Text = "Main";
				hlMain.Font.Bold = true;
				hlMain.NavigateUrl = "/SME/Scoring/FairIsaac.aspx?mc=006";

				//--- Membuat menu dari DATABASE
				conn.QueryString = "select * from SCREENMENU where menucode = '" + Request.QueryString["mc"] + "'";
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
						if (conn.GetFieldValue(i,3).IndexOf("?scr=") < 0 && conn.GetFieldValue(i,3).IndexOf("&scr=") < 0) 
							strtemp += "&"+Request.QueryString["scr"];
						if (conn.GetFieldValue(i,3).IndexOf("?par=") < 0 && conn.GetFieldValue(i,3).IndexOf("&par=") < 0) 
							strtemp += "&"+Request.QueryString["par"];
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
				Console.Write(ex.Message);
			}
		}

		private bool isMandatoryFilled() 
		{
			string pesan = "";
			bool ret = false;

			if (DDL_SR_OVERALL.SelectedValue == "") 
			{
				pesan = "Overall STW Decision harus diisi!\n";
				ret = true;
			}
			if (DDL_SR_SCORE.SelectedValue == "") 
			{
				pesan += "Score Result harus diisi!\n";
				ret = true;
			}
			if (ret) Tools.popMessage(this, pesan);

			return ret;
		}

		private void updatestatus_Click(object sender, System.EventArgs e)
		{
			DataTable dt;
			conn.QueryString = "select apptype, productid, PROD_SEQ from custproduct where ap_regno='" + Request.QueryString["regno"] +
				"' AND isnull(cp_reject,'0') <> '1' and isnull(cp_cancel,'0') <> '1'";
			conn.ExecuteQuery();
			dt = conn.GetDataTable().Copy();
			for (int i = 0; i < dt.Rows.Count; i++)
			{
				conn.QueryString = "exec TRACKUPDATE '" + Request.QueryString["regno"] + "', '" +
					dt.Rows[i][1].ToString() + "', '" + dt.Rows[i][0].ToString() + "', '" + Session["UserID"].ToString() + "', '" + dt.Rows[i]["PROD_SEQ"].ToString() + "','"+Request.QueryString["tc"].Trim()+"'";
				conn.ExecuteNonQuery();
			}
			string msg = getNextStepMsg(Request.QueryString["regno"]);
			Response.Redirect("ListScoring.aspx?tc=" + Request.QueryString["tc"] + "&mc=" + Request.QueryString["mc"] + "&msg=" + msg);
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
				"'" + tool.ConvertFloat(this.TXT_SR_LIMIT.Text.Trim()) + "'";
	
			conn.QueryString = query;
			conn.ExecuteNonQuery();	

			updatestatus.Enabled = true;
		}

		protected void TXT_SR_LIMIT_TextChanged(object sender, EventArgs e)
		{
			TXT_SR_LIMIT.Text = tool.MoneyFormat(TXT_SR_LIMIT.Text.Trim());
		}

		protected void BTN_BACK_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			if (Request.QueryString["tc"] != "" && 
				Request.QueryString["tc"] != null && 
				Request.QueryString["tc"] != "&nbsp;") 
			{
				Response.Redirect("/SME/" + DMS.CuBESCore.Logic.backLink(Request.QueryString["tc"].ToString(), conn));
			}		
			else 
				Response.Redirect("/SME/" + this.backLinkLocal(Request.QueryString["mc"]));
		}

		private void DDL_SR_OVERALL_SelectedIndexChanged(object sender, EventArgs e)
		{
			updatestatus.Enabled = false;
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
	}
}
