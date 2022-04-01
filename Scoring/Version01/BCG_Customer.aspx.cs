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
	public partial class BCG_Customer : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.PlaceHolder Menu;
		protected System.Web.UI.WebControls.TextBox Textbox1;
		protected System.Web.UI.WebControls.TextBox Textbox2;
		protected Tools tool = new Tools();		
		//protected Connection conn = new Connection("Data Source=10.123.12.30;Initial Catalog=SMEDEV;uid=sa;pwd=");
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
		}

		private void setDropDownRating() 
		{
			//---- POPULATE RATING ---------------------
			conn.QueryString = "select * from RFCOMPRATING order by cast(RATINGCODE as int)";
			conn.ExecuteQuery();
			if (conn.GetRowCount() > 0) 
			{
				DataTable dt = conn.GetDataTable();

				this.DDL_BCGFINRATING.Items.Add(new ListItem("- SELECT -",""));
				this.DDL_SR_RISKGRADE.Items.Add(new ListItem("- SELECT -",""));
				this.DDL_SR_CLSGRADE.Items.Add(new ListItem("- SELECT -",""));
				foreach(DataRow dr in dt.Rows) 
				{
					this.DDL_BCGFINRATING.Items.Add(new ListItem(dr["RATINGDESC"].ToString(), dr["RATINGCODE"].ToString()));
					this.DDL_SR_RISKGRADE.Items.Add(new ListItem(dr["RATINGDESC"].ToString(), dr["RATINGCODE"].ToString()));
					this.DDL_SR_CLSGRADE.Items.Add(new ListItem(dr["RATINGDESC"].ToString(), dr["RATINGCODE"].ToString()));
				}
			}
			//----------------------------------------------

		}

		private void ViewData() 
		{
			this.LBL_CU_REF.Text = Request.QueryString["curef"];

			this.setDropDownRating();

			conn.QueryString = "select CP.*, SR.*, RT.RISKDESC " + 
							   "from SCORERESULT SR, RFCOMPRATING cp, RFRISKTYPE RT " +
							   "where " + 
								"SR_BCGFINRATING = RATINGCODE " + 
								"AND RT.RISKCODE = CP.RISKCODE " +
								"AND AP_REGNO = '" + Request.QueryString["regno"] + "'";
			conn.ExecuteQuery();

			if (conn.GetRowCount() > 0) 
			{
				this.DDL_SR_RISKGRADE.SelectedValue = conn.GetFieldValue("SR_BCGRISKGRADE");
				this.DDL_SR_CLSGRADE.SelectedValue = conn.GetFieldValue("SR_BCGCLASS");
				this.DDL_BCGFINRATING.SelectedValue = conn.GetFieldValue("RATINGCODE");
				this.TXT_SR_BCGPROBDEF.Text = conn.GetFieldValue("SR_BCGPROBDEF");
				this.LBL_SR_BCGYRAVG.Text = conn.GetFieldValue("SR_BCGYRAVG");
				this.TXT_RISKTYPE.Text = conn.GetFieldValue("RISKDESC");

				//--- menampilkan RISKGRADE --------
				conn.QueryString = "select RISKDESC from RFRISKTYPE RT, RFCOMPRATING CR where RT.RISKCODE = CR.RISKCODE and RATINGCODE = '"+this.DDL_SR_RISKGRADE.SelectedValue+"'";
				conn.ExecuteQuery();
				this.TXT_RISKGRADE.Text = conn.GetFieldValue("RISKDESC");

				//--- menampilkan CLASSGRADE
				conn.QueryString = "select RISKDESC from RFRISKTYPE RT, RFCOMPRATING CR where RT.RISKCODE = CR.RISKCODE and RATINGCODE = '"+this.DDL_SR_CLSGRADE.SelectedValue+"'";
				conn.ExecuteQuery();
				this.TXT_CLSGRADE.Text = conn.GetFieldValue("RISKDESC");
			}
		}

		protected void btnSave_Click(object sender, System.EventArgs e)
		{
			string query = "exec SR_BCG '" + Request.QueryString["regno"] + "', " +
				"'" + this.LBL_CU_REF.Text + "'," +
				"'" + this.DDL_BCGFINRATING.SelectedValue.ToString() + "'," +				
				"'" + this.TXT_SR_BCGPROBDEF.Text + "'," +
				"'" + this.LBL_SR_BCGYRAVG.Text + "'," +
				"'" + this.DDL_SR_RISKGRADE.SelectedValue.ToString() + "', " +
				"'" + this.DDL_SR_CLSGRADE.SelectedValue.ToString() + "'";

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

		protected void DDL_BCGFINRATING_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			string rating = this.DDL_BCGFINRATING.SelectedValue;

			conn.QueryString = "select RATINGDESC, RISKDESC from RFRISKTYPE RT, RFCOMPRATING CP where " +
							   "RT.RISKCODE = CP.RISKCODE and RATINGCODE = '" + rating + "' " +
							   "order by RT.RISKCODE";
			conn.ExecuteQuery();

			this.TXT_RISKTYPE.Text = conn.GetFieldValue("RISKDESC");
		}

		protected void DDL_SR_RISKGRADE_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			string rating = this.DDL_SR_RISKGRADE.SelectedValue;

			conn.QueryString = "select RATINGDESC, RISKDESC from RFRISKTYPE RT, RFCOMPRATING CP where " +
				"RT.RISKCODE = CP.RISKCODE and RATINGCODE = '" + rating + "' " +
				"order by RT.RISKCODE";
			conn.ExecuteQuery();
			
			this.TXT_RISKGRADE.Text = conn.GetFieldValue("RISKDESC");
		}

		protected void DDL_SR_CLSGRADE_SelectedIndexChanged(object sender, System.EventArgs e) 
		{
			string rating = this.DDL_SR_CLSGRADE.SelectedValue;

			conn.QueryString = "select RATINGDESC, RISKDESC from RFRISKTYPE RT, RFCOMPRATING CP where " +
				"RT.RISKCODE = CP.RISKCODE and RATINGCODE = '" + rating + "' " +
				"order by RT.RISKCODE";
			conn.ExecuteQuery();
					
			
			this.TXT_CLSGRADE.Text = conn.GetFieldValue("RISKDESC");
		}
	}
}
