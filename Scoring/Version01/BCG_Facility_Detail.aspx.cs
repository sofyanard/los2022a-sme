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
	public partial class BCG_Facility_Detail : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.PlaceHolder Menu;
		protected Tools tool = new Tools();
		protected Connection conn;
		//protected Connection conn = new Connection("Data Source=10.123.12.30;Initial Catalog=SMEDEV;uid=sa;pwd=");
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			conn = (Connection) Session["Connection"];
			if (!Logic.AllowAccess(Session["GroupID"].ToString(), Request.QueryString["mc"], conn))
				Response.Redirect("/SME/Restricted.aspx");

			if (!IsPostBack)
			{
				this.ViewData();
			}
			SecureData();
			btnUpdateStatus.Attributes.Add("onclick", "if(!update()) { return false; };");
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
				System.Web.UI.ControlCollection coll = this.Page.Controls;
				for (int i = 0; i < coll[3].Controls.Count; i++) 
				{
					if (coll[3].Controls[i] is TextBox) 
					{
						TextBox txt = (TextBox) coll[3].Controls[i];
						txt.ReadOnly = true;
					}
					else if (coll[3].Controls[i] is DropDownList) 
					{
						DropDownList ddl = (DropDownList) coll[3].Controls[i];
						ddl.Enabled = false;
					}
					else if (coll[3].Controls[i] is Button)
					{
						Button btn = (Button) coll[3].Controls[i];
						btn.Visible = false;
					}
					else if (coll[3].Controls[i] is RadioButtonList) 
					{
						RadioButtonList rbl = (RadioButtonList) coll[3].Controls[i];
						rbl.Enabled = false;
					}
					else if (coll[3].Controls[i] is RadioButton) 
					{
						RadioButton rb = (RadioButton) coll[3].Controls[i];
						rb.Enabled = false;
					}
					else if (coll[3].Controls[i] is CheckBox)
					{
						CheckBox cb = (CheckBox) coll[3].Controls[i];
						cb.Enabled = false;
					}					
					else if (coll[3].Controls[i] is HtmlTableRow) 
					{
						HtmlTableRow htr = (HtmlTableRow) coll[3].Controls[i];

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

			DDL_APPTYPE.Enabled = true;		//--- User masih tetap bisa memilih jenis app
		}

		private void ViewData() 
		{
			this.LBL_AP_REGNO.Text  = Request.QueryString["regno"];
			this.LBL_CU_REF.Text    = Request.QueryString["curef"];
			this.LBL_PRODUCTID.Text = Request.QueryString["productid"];

			//---- POPULATE DDL_FINRATING dan DDL_SB_FACRATING ------------------------
			conn.QueryString = "select * from RFCOMPRATING order by cast(RATINGCODE as int)";
			conn.ExecuteQuery();
			if (conn.GetRowCount() > 0) 
			{
				DataTable dt = conn.GetDataTable();
				this.DDL_SB_FACRATING.Items.Add(new ListItem("- SELECT -", ""));
				this.DDL_BCGFINRATING.Items.Add(new ListItem("- SELECT -", ""));

				foreach(DataRow dr in dt.Rows) 
				{
					this.DDL_BCGFINRATING.Items.Add(new ListItem(dr["RATINGDESC"].ToString(), dr["RATINGCODE"].ToString()));
					this.DDL_SB_FACRATING.Items.Add(new ListItem(dr["RATINGDESC"].ToString(), dr["RATINGCODE"].ToString()));
				}
			}
			//----------------------------------------------

			conn.QueryString = "select AP_REGNO, APPTYPE, APPTYPEDESC, PRODUCTID " + 
							   "from CUSTPRODUCT, rfapplicationtype " +
							   "where AP_REGNO = '" + this.LBL_AP_REGNO.Text + "' and APPTYPE = APPTYPEID and productid = '" + this.LBL_PRODUCTID.Text + "'";
			conn.ExecuteQuery();
			
			if (conn.GetRowCount() > 0) 
			{
				this.DDL_APPTYPE.Items.Clear();
				this.DDL_APPTYPE.Items.Add(new ListItem("- SELECT -",""));
				foreach (DataRow dr in conn.GetDataTable().Rows) 
				{
					this.DDL_APPTYPE.Items.Add(new ListItem(dr["APPTYPEDESC"].ToString(),dr["APPTYPE"].ToString()));				
				}
			}
		}

		private void BTN_LIHAT_Click(object sender, System.EventArgs e)
		{
			this.viewScoreResult();
			this.viewOriginalFacilityRating();
		}

		private void viewScoreResult() 
		{
			conn.QueryString = "select CP.*, SR.*, RISKDESC " + 
							   "from SCORERESULT SR, RFCOMPRATING cp, RFRISKTYPE rt " +
							   "where " + 
									"SR_BCGFINRATING = RATINGCODE " +
									"AND cp.RISKCODE = rt.RISKCODE " +
									"AND AP_REGNO = '" + Request.QueryString["regno"] + "'";
			conn.ExecuteQuery();

			if (conn.GetRowCount() > 0) 
			{
				this.DDL_BCGFINRATING.SelectedValue = conn.GetFieldValue("RATINGCODE");
				this.TXT_SR_BCGPROBDEF.Text = conn.GetFieldValue("SR_BCGPROBDEF");
				this.TXT_SR_BCGYRAVG.Text = conn.GetFieldValue("SR_BCGYRAVG");
				this.TXT_CUSTRISKTYPE.Text = conn.GetFieldValue("RISKDESC");				
				this.LBL_SR_BCGRISKGRADE.Text = conn.GetFieldValue("SR_BCGRISKGRADE");
			}
		}

		private void viewOriginalFacilityRating() 
		{
			conn.QueryString = "select CP.*, SR.*, RISKDESC " + 
							   "from SCOREBCGRATING SR, RFCOMPRATING CP, RFRISKTYPE RT " +
							"where " + 
							"SB_FACRATING = RATINGCODE " + 
							"and CP.RISKCODE = RT.RISKCODE " +
							"and PRODUCTID = '" + this.LBL_PRODUCTID.Text + "'" +
							"and APPTYPE = '" + this.DDL_APPTYPE.SelectedValue + "'" + 
							"and AP_REGNO = '" + Request.QueryString["regno"] + "'";
			conn.ExecuteQuery();
			
			if (conn.GetRowCount() > 0) 
			{
				this.TXT_SB_AVGCOLL.Text =  conn.GetFieldValue("SB_AVGCOLL");
				this.TXT_SB_AVGLGD.Text = conn.GetFieldValue("SB_AVGLGD");
				this.TXT_SB_EXPOSURE.Text = conn.GetFieldValue("SB_EXPOSURE");
				this.TXT_SB_EXPLOSS.Text = conn.GetFieldValue("SB_EXPLOSS");			
				this.DDL_SB_FACRATING.SelectedValue = conn.GetFieldValue("RATINGCODE");
				this.TXT_FACRISKTYPE.Text = conn.GetFieldValue("RISKDESC");				
			}
			else 
			{
				this.clearOriginalFacilityRating();
			}
		}

		protected void btnSave_Click(object sender, System.EventArgs e)
		{
			this.saveScoreResult();
			this.saveOriginalFacilityRating();
		}

		private void saveScoreResult() 
		{			
			string query = "exec SR_BCG '" + Request.QueryString["regno"] + "', " +
				"'" + this.LBL_CU_REF.Text + "'," +
				"'" + this.DDL_BCGFINRATING.SelectedValue + "'," +
				"'" + this.TXT_SR_BCGPROBDEF.Text + "'," +
				"'" + this.TXT_SR_BCGYRAVG.Text + "'," +
				"'" + this.LBL_SR_BCGRISKGRADE.Text + "'";
			conn.QueryString = query;
			conn.ExecuteNonQuery();	
		}

		private void saveOriginalFacilityRating() 
		{
			string query = "exec SB_BCG '" + Request.QueryString["regno"] + "', " +
							"'" + this.LBL_PRODUCTID.Text + "', " +
							"'" + this.DDL_APPTYPE.SelectedValue + "', " +
							"'" + this.TXT_SB_AVGCOLL.Text + "', " +
							"'" + this.TXT_SB_AVGLGD.Text + "', " +
							"'" + this.TXT_SB_EXPOSURE.Text + "', " +
							"'" + this.TXT_SB_EXPLOSS.Text + "', " +
							"'" + this.DDL_SB_FACRATING.SelectedValue.ToString() + "'";
			conn.QueryString = query;
			conn.ExecuteNonQuery();	
		}

		protected void btnUpdateStatus_Click(object sender, System.EventArgs e)
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

						
			this.backToList();
		}

		private void backToList() 
		{
			Session.Add("tc", Request.QueryString["tc"]);
			Session.Add("mc", Request.QueryString["mc"]);
			
			string link = "/SME/Scoring/ListScoring.aspx?tc=" + Request.QueryString["tc"] + "&mc=" + Request.QueryString["mc"];
			Response.Write("<form name='Form2' action='"+link+"' target='main'");
			Response.Write("");
			Response.Write("</form>");
			Response.Write("<script language='javascript'>alert('Track Update Successful!');</script>");
			Response.Write("<script language='JavaScript'>document.Form2.submit();</script>");			
			
			//Server.Transfer("ListScoring.aspx?tc=" + Request.QueryString["tc"] + "&mc=" + Request.QueryString["mc"]);				
			Server.Transfer("ListScoring.aspx");						
		}

		private void clearFields() 
		{
			this.DDL_BCGFINRATING.SelectedValue = "";
			this.TXT_SR_BCGPROBDEF.Text = "";
			this.TXT_SR_BCGYRAVG.Text = "";		
			this.TXT_CUSTRISKTYPE.Text = "";			

			clearStrukturKredit();
			clearOriginalFacilityRating();
		}

		private void clearStrukturKredit() 
		{
			TXT_ACC_NO.Text = "";
			TXT_APPTYPE.Text = "";
			TXT_PRODUCTDESC.Text = "";
			TXT_REVOLVING.Text = "";
			TXT_LOANPURPOSEDESC.Text = "";
			TXT_CP_LIMIT.Text = "";
		}

		private void clearOriginalFacilityRating() 
		{
			this.TXT_SB_AVGCOLL.Text = "";
			this.TXT_SB_AVGLGD.Text = "";
			this.TXT_SB_EXPOSURE.Text = "";
			this.TXT_SB_EXPLOSS.Text = "";
			this.DDL_SB_FACRATING.SelectedValue = "";
			this.TXT_FACRISKTYPE.Text = "";
		}

		private void viewStrukturKredit() 
		{
			conn.QueryString = "select * from VW_CUSTPRODUCT " + 
								"where AP_REGNO = '" + LBL_AP_REGNO.Text.Trim() + 
									"' and PRODUCTID = '" + LBL_PRODUCTID.Text.Trim() + 
									"' and APPTYPE = '" + DDL_APPTYPE.SelectedValue + "'";
			conn.ExecuteQuery();

			if (conn.GetRowCount() > 0) 
			{
				TXT_ACC_NO.Text = conn.GetFieldValue("ACC_NO");
				TXT_APPTYPE.Text = DDL_APPTYPE.SelectedItem.Text;
				TXT_PRODUCTDESC.Text = conn.GetFieldValue("PRODUCTDESC");
				TXT_REVOLVING.Text = conn.GetFieldValue("REVOLVING");
				TXT_LOANPURPOSEDESC.Text = conn.GetFieldValue("LOANPURPDESC");
				TXT_CP_LIMIT.Text = tool.MoneyFormat(conn.GetFieldValue("CP_LIMIT").ToString());
			}
	}

		protected void DDL_APPTYPE_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if (this.DDL_APPTYPE.SelectedValue != "") 
			{
				viewScoreResult();
				viewStrukturKredit();
				viewOriginalFacilityRating();
			}
			else 
			{
				this.clearFields();
			}
		}

		protected void DDL_BCGFINRATING_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			string rating = this.DDL_BCGFINRATING.SelectedValue;

			conn.QueryString = "select RATINGDESC, RISKDESC from RFRISKTYPE RT, RFCOMPRATING CP where " +
				"RT.RISKCODE = CP.RISKCODE and RATINGCODE = '" + rating + "' " +
				"order by RT.RISKCODE";
			conn.ExecuteQuery();

			this.TXT_CUSTRISKTYPE.Text = conn.GetFieldValue("RISKDESC");
		}

		protected void DDL_SB_FACRATING_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			string rating = this.DDL_SB_FACRATING.SelectedValue;

			conn.QueryString = "select RATINGDESC, RISKDESC from RFRISKTYPE RT, RFCOMPRATING CP where " +
				"RT.RISKCODE = CP.RISKCODE and RATINGCODE = '" + rating + "' " +
				"order by RT.RISKCODE";
			conn.ExecuteQuery();

			this.TXT_FACRISKTYPE.Text = conn.GetFieldValue("RISKDESC");
		}
	}
}
