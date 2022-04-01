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
using Microsoft.VisualBasic;


namespace SME.ITTP
{
	/// <summary>
	/// Summary description for InitiationMain.
	/// </summary>
	public partial class InitiationMain : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Label temp_branchcode;
		protected Tools tool = new Tools();


		protected Connection conn;
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			
			conn = (Connection) Session["Connection"];


			if (!Logic.AllowAccess(Session["GroupID"].ToString(), Request.QueryString["mc"], conn))
				Response.Redirect("/SME/Restricted.aspx");

			if (!IsPostBack)
			{
				conn.QueryString = "SELECT sg_BUSSUNITid,sg_grpunit FROM scgroup WHERE groupid = '" + Session["GroupID"].ToString() + "'";
				conn.ExecuteQuery();
				temp_grpunit.Text = conn.GetFieldValue("sg_grpunit");
				temp_areaid.Visible=false;
				temp_userid.Visible=false;
				temp_ccobranch.Visible=false;
				temp_grpunit.Visible=false;

				TXT_AREAID.Text = Session["AreaName"].ToString();

				temp_ccobranch.Text = Session["BranchID"].ToString();
				temp_areaid.Text = Session["AreaID"].ToString();
				temp_userid.Text = Session["UserID"].ToString();

				DDL_AP_SIGNDATE_MONTH.Items.Add(new ListItem("- PILIH -", ""));
				DDL_CCOBRANCH.Items.Add(new ListItem("- PILIH -", ""));
				DDL_PROG_CODE.Items.Add(new ListItem("- PILIH -", ""));			

				conn.QueryString = "select branch_code, branch_name from rfbranch where active='1'";
				conn.ExecuteQuery();
				for (int i = 0; i < conn.GetRowCount(); i++)
					DDL_CCOBRANCH.Items.Add(new ListItem(conn.GetFieldValue(i,1), conn.GetFieldValue(i,0)));

				//business unit
				conn.QueryString = "select su_upliner, su_midupliner, su_corupliner, su_crgupliner from scuser where userid='" + Session["UserID"].ToString() + "'";
				conn.ExecuteQuery();

				string upliner = conn.GetFieldValue(0,0);
				string midupliner = conn.GetFieldValue(0,1);
				string corupliner = conn.GetFieldValue(0, "SU_CORUPLINER");
				string crgupliner = conn.GetFieldValue(0, "SU_CRGUPLINER");


				if (upliner != "")	DDL_AP_BUSINESSUNIT.Items.Add(new ListItem("Small Business Group", "SM100"));
				if (midupliner != "") DDL_AP_BUSINESSUNIT.Items.Add(new ListItem("Middle Business Group", "MD100"));
				if (corupliner != "") DDL_AP_BUSINESSUNIT.Items.Add(new ListItem("Corporate", "CB100"));
				if (crgupliner != "") DDL_AP_BUSINESSUNIT.Items.Add(new ListItem("Mandiri Prioritas", "BPM100"));
				//if (crgupliner != "") DDL_AP_BUSINESSUNIT.Items.Add(new ListItem("Credit Recovery", "CR100"));


				conn.QueryString = "SELECT PROGRAMID, PROGRAMDESC FROM RFPROGRAM WHERE AREAID = '" + Session["AreaID"] + "' AND ACTIVE = '1' AND PROGRAMID like '%0000%' AND BUSINESSUNIT = '" + DDL_AP_BUSINESSUNIT.SelectedValue + "'";
				conn.ExecuteQuery();
				for (int i = 0; i < conn.GetRowCount(); i++)
					DDL_PROG_CODE.Items.Add(new ListItem(conn.GetFieldValue(i,1), conn.GetFieldValue(i,0)));

				conn.QueryString = "select top 1 * from rfarea where areaid= '" + temp_areaid.Text + "'";
				conn.ExecuteQuery();
				TXT_AREAID.Text = conn.GetFieldValue("areaname");

			

				//Disable item app
				TXT_AREAID.Enabled=false;

				BTN_SAVE.Attributes.Add("onclick","if(!cek_mandatory(document.Form1)){return false;};");

				for (int i = 1; i <= 12; i++)
				{
					DDL_AP_SIGNDATE_MONTH.Items.Add(new ListItem(DateAndTime.MonthName(i, false), i.ToString()));
				}

				Tools.initDateForm(TXT_AP_SIGNDATE_DAY, DDL_AP_SIGNDATE_MONTH, TXT_AP_SIGNDATE_YEAR, false);

				fillAcquireInformation();
			}




			TXT_CU_REF.Text = Request.QueryString["curef"];
			TXT_AP_REGNO.Text = Request.QueryString["regno"];

			//Enabling update button
			conn.QueryString = "exec IT_UPDATE '"+TXT_AP_REGNO.Text+"'";
			conn.ExecuteQuery();
			LBL_UPDATE.Text = conn.GetFieldValue("update_status");
			if (LBL_UPDATE.Text =="1")
			{
				BTN_UPDATE_STATUS.Enabled = true;
			}
			else
			{
				BTN_UPDATE_STATUS.Enabled = false;
			}


			/*
			if (Request.QueryString["exist"] == "1")
			{
				if(conn.GetRowCount() != 0) 
				{
					TXT_AP_SIGNDATE_DAY.Text			= GlobalTools.FormatDate_Day(conn.GetFieldValue("PRE_APPENTRYDATE"));   
					DDL_AP_SIGNDATE_MONTH.SelectedValue = GlobalTools.FormatDate_Month(conn.GetFieldValue("PRE_APPENTRYDATE"));   
					TXT_AP_SIGNDATE_YEAR.Text			= GlobalTools.FormatDate_Year(conn.GetFieldValue("PRE_APPENTRYDATE")); 
				}
			}
			*/
			ViewMenu();
			ViewDataVisited();
		}

		private void fillAcquireInformation() 
		{			
			try 
			{
				conn.QueryString = "select AP_ACQINFO, isnull(AP_ACQINFOBY,'') as AP_ACQINFOBY from APPLICATION where AP_REGNO = '" + Request.QueryString["regno"] + "'";
				conn.ExecuteQuery();

				txt_acqinfo.Text = conn.GetFieldValue("ap_acqinfo");
				
				if (conn.GetFieldValue("AP_ACQINFOBY") != "") 
				{
					txt_acqinfo.Visible = true;
				}
			} 
			catch (NullReferenceException) 
			{
				GlobalTools.popMessage(this, "Connection Error!");
				Response.Redirect("../Login.aspx?expire=1");
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

						//---  untuk general info
						if (conn.GetFieldValue(i,3).IndexOf("?exist=") < 0 && conn.GetFieldValue(i,3).IndexOf("&exist=") < 0) 
							strtemp = strtemp + "&exist=" + Request.QueryString["exist"];	

						//--- untuk program yang dipilih
						if (conn.GetFieldValue(i,3).IndexOf("?prog=") < 0 && conn.GetFieldValue(i,3).IndexOf("&prog=") < 0) 
							strtemp = strtemp + "&prog=" + Request.QueryString["prog"];	

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

		private void ViewDataVisited()
		{
			try 
			{
				conn.QueryString = "select * from APPLICATION where AP_REGNO = '" + TXT_AP_REGNO.Text + "'";
				conn.ExecuteQuery();


				if (conn.GetRowCount() > 0)
				{
					DateTime dt = Convert.ToDateTime(conn.GetFieldValue("AP_SIGNDATE"));
					GlobalTools.fillDateForm(TXT_AP_SIGNDATE_DAY, DDL_AP_SIGNDATE_MONTH, TXT_AP_SIGNDATE_YEAR, dt);
					TXT_AP_SIGNDATE_DAY.ReadOnly = true;
					DDL_AP_SIGNDATE_MONTH.Enabled = false;
					TXT_AP_SIGNDATE_YEAR.ReadOnly = true;
					DDL_AP_BUSINESSUNIT.SelectedValue = (conn.GetFieldValue("AP_BUSINESSUNIT"));
					DDL_PROG_CODE.SelectedValue = (conn.GetFieldValue("PROG_CODE"));
					DDL_CCOBRANCH.SelectedValue = (conn.GetFieldValue("AP_CCOBRANCH"));
				}

			} 
			catch (NullReferenceException) 
			{
				GlobalTools.popMessage(this, "Connection Error !");
				return;
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

		protected void BTN_SAVE_Click(object sender, System.EventArgs e)
		{
			string curef = TXT_CU_REF.Text;
			
			Int64 signDate = Int64.Parse(Tools.toISODate(TXT_AP_SIGNDATE_DAY, DDL_AP_SIGNDATE_MONTH, TXT_AP_SIGNDATE_YEAR)),
				now = Int64.Parse(Tools.toISODate(DateTime.Now.Day.ToString(), DateTime.Now.Month.ToString(), DateTime.Now.Year.ToString()));
			
			if (signDate > now)
			{
				GlobalTools.popMessage(this, "Sign Date cannot be greater than current date!");
				return;
			}
			try
			{
				conn.QueryString = "exec IT_IDE_GENINFO_INSERT '" + 
					Request.QueryString["regno"] + "', '" + 
					TXT_CU_REF.Text + "', '" +
					temp_areaid.Text + "', '" +
					DDL_PROG_CODE.SelectedValue + "', '" +
					DDL_CCOBRANCH.SelectedValue + "', " + 
					tool.ConvertDate(TXT_AP_SIGNDATE_DAY.Text, DDL_AP_SIGNDATE_MONTH.SelectedValue, TXT_AP_SIGNDATE_YEAR.Text) + ", '" +
					temp_userid.Text + "', '" + 
					DDL_AP_BUSINESSUNIT.SelectedValue + "'";
				conn.ExecuteNonQuery();
			}

			catch (Exception ex)
			{
				string errmsg = ex.Message.Replace("'","");
				if (errmsg.IndexOf("Last Query:") > 0)
					errmsg = errmsg.Substring(0, errmsg.IndexOf("Last Query:"));
				GlobalTools.popMessage(this, errmsg);
				return;
			}

			Session["curef"]	= Request.QueryString ["curef"];
			Session["tc"]		= Request.QueryString ["tc"];
			Session["mc"]		= Request.QueryString ["mc"];

			Response.Redirect("CustomerInfo.aspx?regno=" + Request.QueryString["regno"] + "&curef=" + Request.QueryString["curef"] + "&tc=" + Request.QueryString["tc"] + "&mc=" + Request.QueryString["mc"] + "&Prog=" + DDL_PROG_CODE.SelectedValue + "&exist=" + Request.QueryString["exist"]);

		}

			protected void BTN_UPDATE_STATUS_Click(object sender, System.EventArgs e)
			{
				try 
				{
					/***
					 * ------------------------------------------------
					 * --- BI Checking setelah IDE atau Pre-Scoring ---
					 * ------------------------------------------------		
					***/
					//cekBIChecking();

					DataTable dt;
					conn.QueryString = "select apptype, productid, PROD_SEQ from custproduct where ap_regno='" + Request.QueryString["regno"] +
						"' AND isnull(cp_reject,'0') <> '1' and isnull(cp_cancel,'0') <> '1'";
					conn.ExecuteQuery();
					dt = conn.GetDataTable().Copy();
					for (int i = 0; i < dt.Rows.Count; i++)
					{
						// tracupdate execution

						conn.QueryString = "exec IT_TRACKUPDATE '" + 
							TXT_AP_REGNO.Text + "', '" +	// AP_REGNO
							dt.Rows[i][1].ToString() + "', '" +		// PRODUCTID
							dt.Rows[i][0].ToString() + "', '" +		// APPTYPE
							Session["UserID"].ToString() + "', '" +				// USERID
							dt.Rows[i]["PROD_SEQ"].ToString() + "'";
							//,"+ // PROD_SEQ "'"+Request.QueryString["tc"].Trim()+"'";// PAGE TRACK
						conn.ExecuteNonQuery();
					}
				Response.Redirect("SearchCustomer.aspx?&mc=" + Request.QueryString["mc"]);
			} 
				catch (NullReferenceException) 
				{
					GlobalTools.popMessage(this, "Connection Error !");
					Response.Redirect("../Login.aspx?expire=1");
				}

				// mengirimkan strng pesan
				//string msg = getNextStepMsg(LBL_AP_REGNO.Text);
				//Response.Redirect("FindCustomer.aspx?tc=" + Request.QueryString["tc"] + "&mc=" + Request.QueryString["mc"] + "&msg=" + msg);
			}



	}
}


