using System;
using System.IO;
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

namespace SME.Scoring.Version01
{
	/// <summary>
	/// Summary description for MainPRRK.
	/// </summary>
	public partial class MainBCG : System.Web.UI.Page
	{
		protected Tools tool = new Tools();
		protected Connection conn;

		protected void Page_Load(object sender, System.EventArgs e)
		{
			conn = (Connection) Session["Connection"];

			if (!Logic.AllowAccess(Session["GroupID"].ToString(), Request.QueryString["mc"], conn))
				Response.Redirect("/SME/Restricted.aspx");

			if (!IsPostBack)
			{
				ViewData();
			}
			this.ViewMenu();

			this.ImageButton1.Click += new System.Web.UI.ImageClickEventHandler(this.ImageButton1_Click);
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

		private void ViewData() 
		{
//			this.LBL_AP_REGNO.Text = Request.QueryString["regno"];
			this.LBL_CU_REF.Text = Request.QueryString["curef"];

			HyperLink byCustomer = new HyperLink();
			byCustomer.Text = "Customer";
			byCustomer.Font.Bold = true;
			byCustomer.NavigateUrl = "BCG_Customer.aspx?regno=" + Request.QueryString["regno"] + "&curef=" + Request.QueryString["curef"] + "&tc=" + Request.QueryString["tc"] + "&mc=" + Request.QueryString["mc"]+"&scr="+Request.QueryString["scr"];
			byCustomer.Target = "if";

			HyperLink byFacility = new HyperLink();
			byFacility.Text = "Facility";
			byFacility.Font.Bold = true;
			byFacility.NavigateUrl = "BCG_Facility.aspx?regno=" + Request.QueryString["regno"] + "&curef=" + Request.QueryString["curef"] + "&tc=" + Request.QueryString["tc"] + "&mc=" + Request.QueryString["mc"]+"&scr="+Request.QueryString["scr"];
			byFacility.Target = "if";

			this.PH_BY.Controls.Add(byCustomer);
			this.PH_BY.Controls.Add(new LiteralControl("&nbsp;&nbsp;"));
			this.PH_BY.Controls.Add(byFacility);			
		}

		private void updatestatus_Click(object sender, System.EventArgs e)
		{
			DataTable dt;
			conn.QueryString = "select apptype, productid from custproduct where ap_regno='" + Request.QueryString["regno"] +
				"' AND isnull(cp_reject,'0') <> '1' and isnull(cp_cancel,'0') <> '1'";
			conn.ExecuteQuery();
			dt = conn.GetDataTable().Copy();
			for (int i = 0; i < dt.Rows.Count; i++)
			{
				conn.QueryString = "exec TRACKUPDATE '" + Request.QueryString["regno"] + "', '" +
					dt.Rows[i][1].ToString() + "', '" + dt.Rows[i][0].ToString() + "', '" + Session["UserID"].ToString() + "','"+Request.QueryString["tc"].Trim()+"'";
				conn.ExecuteNonQuery();
			}
			Response.Redirect("ListPRRK.aspx");
		}

		private void ViewMenu() 
		{
			try 
			{
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
						
						else strtemp = "regno=" + Request.QueryString["regno"] + "&curef="+Request.QueryString["curef"]+"&mc="+Request.QueryString["mc"]+"&tc="+Request.QueryString["tc"];
						if (conn.GetFieldValue(i,3).IndexOf("?scr=") < 0 && conn.GetFieldValue(i,3).IndexOf("&scr=") < 0) 
							strtemp += "&"+Request.QueryString["scr"];
						if (conn.GetFieldValue(i,3).IndexOf("?par=") < 0 && conn.GetFieldValue(i,3).IndexOf("&par=") < 0) 
							strtemp += "&"+Request.QueryString["par"];
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
				Console.Write(ex.Message);
			}
		}

		private void btnSave_Click(object sender, System.EventArgs e)
		{			
//			this.saveScoreResult(this.TBL_SATU.Rows[0].Cells[0].Text);
//			this.saveOriginalFacilityRating();			
//
//			this.makeTableSatu(this.TBL_SATU.Rows[0].Cells[0].Text);
//			this.makeTableDua();
		}

		private void saveScoreResult(string tipe) 
		{			
//			string query = "exec SR_BCG '" + Request.QueryString["regno"] + "', " +
//				"'" + this.TXT_SR_BCGFINRATING.Text + "'," +
//				"'" + this.TXT_SR_BCGPROBDEF.Text + "'," +
//				"'" + this.TXT_SR_BCGYRAVG.Text + "'";
//			conn.QueryString = query;
//			conn.ExecuteNonQuery();	
		}

		private void saveOriginalFacilityRating() 
		{
//			string query = "exec SB_BCG '" + Request.QueryString["regno"] + "', " +
//							"'" + this.DDL_PRODUCTID.SelectedValue + "', " +
//							"'" + this.TXT_SB_AVGCOLL.Text + "', " +
//							"'" + this.TXT_SB_AVGLGD.Text + "', " +
//							"'" + this.TXT_SB_EXPOSURE.Text + "', " +
//							"'" + this.TXT_SB_EXPLOSS.Text + "', " +
//							"'" + this.TXT_SB_FACRATING.Text + "'";
//			conn.QueryString = query;
//			conn.ExecuteNonQuery();	
		}

		private void viewScoreResult() 
		{
//			conn.QueryString = "select * from SCORERESULT " +
//				"where " + 
//				"AP_REGNO = '" + Request.QueryString["regno"] + "'";
//			conn.ExecuteQuery();
//
//			this.TXT_SR_BCGFINRATING.Text = conn.GetFieldValue("SR_BCGFINRATING");
//			this.TXT_SR_BCGPROBDEF.Text = conn.GetFieldValue("SR_BCGPROBDEF");
//			this.TXT_SR_BCGYRAVG.Text = conn.GetFieldValue("SR_BCGYRAVG");
		}

		private void viewOriginalFacilityRating() 
		{
//			conn.QueryString = "select * from SCOREBCGRATING " +
//				"where " + 
//				"PRODUCTID = '" + this.DDL_PRODUCTID.SelectedValue + "'" +
//				"AND AP_REGNO = '" + Request.QueryString["regno"] + "'";
//			conn.ExecuteQuery();
//			
//			this.TXT_SB_AVGCOLL.Text =  conn.GetFieldValue("SB_AVGCOLL");
//			this.TXT_SB_AVGLGD.Text = conn.GetFieldValue("SB_AVGLGD");
//			this.TXT_SB_EXPOSURE.Text = conn.GetFieldValue("SB_EXPOSURE");
//			this.TXT_SB_EXPLOSS.Text = conn.GetFieldValue("SB_EXPLOSS");			
//			this.TXT_SB_FACRATING.Text = conn.GetFieldValue("SB_FACRATING");
		}

		private void LB_BY_CUSTOMER_Click(object sender, System.EventArgs e)
		{							
//			this.DDL_PRODUCTID.Visible = false;
//			this.BTN_LIHAT.Visible = false;
//
//			this.makeTableSatu("CUSTOMER");
//			this.TBL_SATU.Visible = true;
//			this.TBL_SATU.Rows[0].Cells[0].Text = "CUSTOMER";
//
//			this.TBL_DUA.Visible = false;
//
//			this.viewScoreResult();

		}

		private void LB_BY_FACILITY_Click(object sender, System.EventArgs e)
		{
//			this.DDL_PRODUCTID.Visible = true;
//			this.BTN_LIHAT.Visible = true;
//
//			this.TBL_SATU.Visible = false;
//			this.TBL_DUA.Visible = false;
		}

		private void makeTableSatu(string tipe) 
		{			
//			this.TBL_SATU.Rows[1].Cells[2].Controls.Add(this.TXT_SR_BCGFINRATING);
//			this.TBL_SATU.Rows[2].Cells[2].Controls.Add(this.TXT_SR_BCGPROBDEF);						
//
//			if (tipe == "FACILITY") 
//			{
//				this.TBL_SATU.Rows[3].Visible = true;
//				this.TBL_SATU.Rows[3].Cells[2].Controls.Add(this.TXT_SR_BCGYRAVG);
//			}
//			else if(tipe == "CUSTOMER") 
//			{
//				this.TBL_SATU.Rows[3].Visible = false;
//			}				 
		}

		private void makeTableDua() 
		{
//			this.TBL_DUA.Rows[1].Cells[2].Controls.Add(this.TXT_SB_AVGCOLL);
//			this.TBL_DUA.Rows[2].Cells[2].Controls.Add(this.TXT_SB_AVGLGD);
//			this.TBL_DUA.Rows[3].Cells[2].Controls.Add(this.TXT_SB_EXPOSURE);
//			this.TBL_DUA.Rows[4].Cells[2].Controls.Add(this.TXT_SB_EXPLOSS);
//			this.TBL_DUA.Rows[5].Cells[2].Controls.Add(this.TXT_SB_FACRATING);
		}

		private void BTN_LIHAT_Click(object sender, System.EventArgs e)
		{
//			this.makeTableSatu("FACILITY");
//			this.TBL_SATU.Visible = true;
//			this.TBL_SATU.Rows[0].Cells[0].Text = "FACILITY";
//
//			this.makeTableDua();
//			this.TBL_DUA.Visible = true;				
//
//			this.viewScoreResult();
//			this.viewOriginalFacilityRating();
		}

		private void ImageButton1_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
//			conn.QueryString = "select * from TRACK_MENU where TRACKCODE = '" + Request.QueryString["tc"] + "'";
//			conn.ExecuteQuery();
//
//			Response.Redirect("/SME/" + conn.GetFieldValue("TM_LINKNAME") + conn.GetFieldValue("TM_PARSINGPARAM"));

			Response.Redirect("/SME/" + DMS.CuBESCore.Logic.backLink(Request.QueryString["tc"].ToString(), conn));
		}
	}
}
