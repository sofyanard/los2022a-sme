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
using DMS.DBConnection;
using DMS.CuBESCore;

namespace SME.CBI
{
	/// <summary>
	/// Summary description for ScoringLinkDummy.
	/// </summary>
	public partial class ScoringLinkDummy : System.Web.UI.Page
	{
		protected Connection conn;
		protected Tools tool = new Tools();
		protected string userid;

		protected void Page_Load(object sender, System.EventArgs e)
		{
			conn = (Connection) Session["Connection"];

			conn.QueryString = "SELECT CU_RM FROM CUSTOMER WHERE CU_REF = '" + Request.QueryString["curef"] + "'";
			conn.ExecuteQuery();
			userid = conn.GetFieldValue("CU_RM");

			if (!Logic.AllowAccess(Session["GroupID"].ToString(), Request.QueryString["mc"], conn))
				Response.Redirect("/SME/Restricted.aspx");

			if (!IsPostBack) 
			{
				TXT_CU_REF.Text = Request.QueryString["curef"];
				TXT_AP_REGNO.Text = Request.QueryString["regno"];
				
				FillDDLBusinessUnit();
				FillDDLProgram();
				ViewRegno();
				ViewDataProgram();
			}

			BTN_SAVE.Attributes.Add("onclick","if(!cek_mandatory(document.Form1)){return false;};");
			ViewMenu();
		}

		private void FillDDLBusinessUnit()
		{
			conn.QueryString = "select su_upliner, su_midupliner, su_corupliner, su_crgupliner, su_mcrupliner from scuser where userid='" + userid + "'";
			conn.ExecuteQuery();

			string upliner = conn.GetFieldValue(0, "SU_UPLINER");
			string midupliner = conn.GetFieldValue(0, "SU_MIDUPLINER");
			string corupliner = conn.GetFieldValue(0, "SU_CORUPLINER");
			string crgupliner = conn.GetFieldValue(0, "SU_CRGUPLINER");
			string mcrupliner = conn.GetFieldValue(0, "SU_MCRUPLINER");

			if (upliner != "")	DDL_AP_BUSINESSUNIT.Items.Add(new ListItem("Small Business Group", "SM100"));
			if (midupliner != "") DDL_AP_BUSINESSUNIT.Items.Add(new ListItem("Middle Business Group", "MD100"));
			if (corupliner != "") DDL_AP_BUSINESSUNIT.Items.Add(new ListItem("Corporate", "CB100"));
			if (crgupliner != "") DDL_AP_BUSINESSUNIT.Items.Add(new ListItem("Credit Recovery", "CR100"));
			if (mcrupliner != "") DDL_AP_BUSINESSUNIT.Items.Add(new ListItem("Micro Banking", "MB100"));
		}

		private void FillDDLProgram()
		{
			DDL_PROG_CODE.Items.Clear();
			DDL_PROG_CODE.Items.Add(new ListItem("- PILIH -", ""));
			conn.QueryString = "select programid, programdesc from rfprogram where areaid='" + Session["AreaID"].ToString() + 
				"' and active='1' and businessunit='" + DDL_AP_BUSINESSUNIT.SelectedValue + "'";
			conn.ExecuteQuery();
			for (int i = 0; i < conn.GetRowCount(); i++)
				DDL_PROG_CODE.Items.Add(new ListItem(conn.GetFieldValue(i,1), conn.GetFieldValue(i,0)));
		}

		private void ViewDataProgram()
		{
			conn.QueryString = "select * from VW_CUSTINFORATING_VIEWPROGRAM where AP_REGNO = '" + TXT_AP_REGNO.Text + "'";
			conn.ExecuteQuery();
			
			if (conn.GetRowCount() > 0)
			{
				try {DDL_AP_BUSINESSUNIT.SelectedValue = conn.GetFieldValue("AP_BUSINESSUNIT");}
				catch {}
				try {DDL_PROG_CODE.SelectedValue = conn.GetFieldValue("PROG_CODE");}
				catch {}
			}
		}

		private void SaveDataProgram()
		{
			try
			{
				conn.QueryString = "exec CUSTINFORATING_SAVEPROGRAM '" + TXT_AP_REGNO.Text + "', '" + 
					DDL_AP_BUSINESSUNIT.SelectedValue.Trim() + "', '" + DDL_PROG_CODE.SelectedValue.Trim() + "'";
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
		}
		
		private void ViewRegno()
		{
			try
			{
				//conn.QueryString = "exec CUSTINFORATING_VIEWREGNO '" + TXT_CU_REF.Text + "', '" + Session["BranchID"].ToString()+ "'";
				conn.QueryString = "exec CUSTINFORATING_VIEWREGNO '" + TXT_CU_REF.Text + "', '" + TXT_AP_REGNO.Text + "'";
				conn.ExecuteQuery();
			
				if (conn.GetRowCount() > 0)
				{
					string vAP_REGNO = conn.GetFieldValue("AP_REGNO");
					string scrtype = conn.GetFieldValue("SCRID");
					//if scoring link found, direct to scoring screen
					if (scrtype != "") 
					{
						if (scrtype == "0") 
						{
							Tools.popMessage(this, "Sub Segmen Program yang dipilih termasuk dalam kategori No Scoring");
							Response.Write("<script language='javascript'>history.back(-1);</script>");
						}
						//only rating is allowed, scoring is temporarily not allowed
						else if (scrtype == "6") 
						{
							string link = conn.GetFieldValue("SCR_LINK");
							Tools.popMessage(this,link);
							
							Response.Redirect(link + "&regno=" + vAP_REGNO + "&curef="+Request.QueryString["curef"]+"&tc="+Request.QueryString["tc"]+"&mc="+Request.QueryString["mc"]+"&scr="+Request.QueryString["scr"]+"&mode=" + Request.QueryString["mode"]);
						}
						else
						{
							/* 20090616 by sofyan, di-direct ke screen rating aja
							 * 
							//Tools.popMessage(this, "Sorry, can not perform this type of scoring!");
							Tools.popMessage(this, "Customer tidak termasuk dalam kategori Rating");
							Response.Write("<script language='javascript'>history.back(-1);</script>");
							*/

							TXT_AP_REGNO.Text = vAP_REGNO;
						}
					}
					else
					{
						TXT_AP_REGNO.Text = vAP_REGNO;
					}
				}
			}
			catch (Exception ex)
			{
				string errmsg = ex.Message.Replace("'","");
				if (errmsg.IndexOf("Last Query:") > 0)
					errmsg = errmsg.Substring(0, errmsg.IndexOf("Last Query:"));
				GlobalTools.popMessage(this, errmsg);
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

		protected void DDL_AP_BUSINESSUNIT_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			FillDDLProgram();
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
						if (conn.GetFieldValue(i,3).IndexOf("?de=") < 0 && conn.GetFieldValue(i,3).IndexOf("&de=") < 0) 
							strtemp = strtemp + "&de=" + Request.QueryString["de"];
						if (conn.GetFieldValue(i,3).IndexOf("?par=") < 0 && conn.GetFieldValue(i,3).IndexOf("&par=") < 0)  
							strtemp = strtemp + "&par=" + Request.QueryString["par"];
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

		protected void BTN_SAVE_Click(object sender, System.EventArgs e)
		{
			try
			{
				SaveDataProgram();
				
				conn.QueryString = "EXEC CUSTINFORATING_PERFORMRATING '" + TXT_AP_REGNO.Text + "', '" + TXT_CU_REF.Text + "'";
				conn.ExecuteQuery();

				string vAP_REGNO = conn.GetFieldValue("AP_REGNO");
				string scrtype = conn.GetFieldValue("SCRID");
				if (conn.GetRowCount() > 0) 
				{
					if (scrtype == "0") 
					{
						Tools.popMessage(this, "Sub Segmen Program yang dipilih termasuk dalam kategori No Scoring");
						Response.Write("<script language='javascript'>history.back(-1);</script>");
					}
					//only rating is allowed, scoring is temporarily not allowed
					else if (scrtype == "6") 
					{
						string link = conn.GetFieldValue("SCR_LINK");
						Tools.popMessage(this,link);

						Response.Redirect(link + "&regno=" + vAP_REGNO + "&curef="+Request.QueryString["curef"]+"&tc="+Request.QueryString["tc"]+"&mc="+Request.QueryString["mc"]+"&scr="+Request.QueryString["scr"]+"&mode=" + Request.QueryString["mode"]);
					}
					else
					{
						//Tools.popMessage(this, "Sorry, can not perform this type of scoring!");
						Tools.popMessage(this, "Customer tidak termasuk dalam kategori Rating");
						Response.Write("<script language='javascript'>history.back(-1);</script>");
					}
				}
				else 
				{
					Tools.popMessage(this, "Scoring type cannot be defined!");
					Response.Write("<script language='javascript'>history.back(-1);</script>");
				}
			}
			catch (Exception ex)
			{
				string errmsg = ex.Message.Replace("'","");
				if (errmsg.IndexOf("Last Query:") > 0)
					errmsg = errmsg.Substring(0, errmsg.IndexOf("Last Query:"));
				GlobalTools.popMessage(this, errmsg);
				return;
			}
		}
	}
}
