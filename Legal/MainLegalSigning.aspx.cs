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

namespace SME.Legal
{
	/// <summary>
	/// Summary description for MainLegalSigning. asdfasdfasdasfsf
	/// </summary>
	public partial class MainLegalSigning : System.Web.UI.Page
	{
		//protected Connection conn = new Connection("Data Source=10.123.12.30;Initial Catalog=SME;uid=sa;pwd=");
		protected Connection conn;
		protected Tools tool = new Tools();
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			conn = (Connection) Session["Connection"];

			if (!IsPostBack)
			{
				LBL_REGNO.Text = Request.QueryString["regno"];
				LBL_CUREF.Text = Request.QueryString["curef"];
				LBL_TC.Text = Request.QueryString["tc"];
				
				HyperLink HPL1 = new HyperLink();
				HPL1.Text = "Detail";
				HPL1.Font.Bold = true;
				HPL1.NavigateUrl = "DetailLegalSigning.aspx?regno="+ LBL_REGNO.Text+"&curef="+LBL_CUREF.Text+"&tc="+LBL_TC.Text;
				HPL1.Target = "frm_data";

				HyperLink HPL2 = new HyperLink();
				HPL2.Text = "Structure Credit";
				HPL2.Font.Bold = true;
				HPL2.NavigateUrl = "FasilitasLegalSigning.aspx?regno="+ LBL_REGNO.Text+"&curef="+LBL_CUREF.Text+"&tc="+LBL_TC.Text;
				HPL2.Target = "frm_data";

				HyperLink HPL3 = new HyperLink();
				HPL3.Text = "Collateral";
				HPL3.Font.Bold = true;
				HPL3.NavigateUrl = "CollateralLegalSigning.aspx?regno="+ LBL_REGNO.Text+"&curef="+LBL_CUREF.Text+"&tc="+LBL_TC.Text;
				HPL3.Target = "frm_data";

				HyperLink HPL4 = new HyperLink();
				HPL4.Text = "Notary";
				HPL4.Font.Bold = true;
				HPL4.NavigateUrl = "NotaryLegalSigning.aspx?regno="+ LBL_REGNO.Text+"&curef="+LBL_CUREF.Text+"&tc="+LBL_TC.Text;
				HPL4.Target = "frm_data";

				PlaceHolder1.Controls.Add(HPL1);
				PlaceHolder1.Controls.Add(new LiteralControl("&nbsp;&nbsp;"));
				PlaceHolder1.Controls.Add(HPL2);
				PlaceHolder1.Controls.Add(new LiteralControl("&nbsp;&nbsp;"));
				PlaceHolder1.Controls.Add(HPL3);
				PlaceHolder1.Controls.Add(new LiteralControl("&nbsp;&nbsp;"));
				PlaceHolder1.Controls.Add(HPL4);
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
			this.BTN_UPDATE.Click += new EventHandler(BTN_UPDATE_Click);

		}
		#endregion

		private void BTN_UPDATE_Click(object sender, System.EventArgs e)
		{
			string USER_ID, REGNO;
			USER_ID = Session["UserID"].ToString();
			REGNO = LBL_REGNO.Text;

			conn.QueryString = "select apptype, productid, PROD_SEQ from custproduct where ap_regno='" + REGNO + "'";
			conn.ExecuteQuery();
			for (int i = 0; i < conn.GetRowCount(); i++)
			{
				conn.QueryString = "exec TRACKUPDATE '" + REGNO + "', '" + 
									conn.GetFieldValue(i,1) + "', '" + 
									conn.GetFieldValue(i,0) + "', '" + 
									USER_ID + "', '" + 
									conn.GetFieldValue(i, "PROD_SEQ") + "','"+Request.QueryString["tc"].Trim()+"'";
				conn.ExecuteNonQuery();
			}
			//Response.Write("<script language='javascript'>alert('Track Updated!');</script>");
			string msg = getNextStepMsg(Request.QueryString["regno"]);
			Response.Redirect("ListLegalSigning.aspx?tc="+ LBL_TC.Text + "&mc=" + Request.QueryString["mc"]+ "&msg=" + msg);
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

		protected void BTN_BACK_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			Response.Redirect("/SME/" + DMS.CuBESCore.Logic.backLink(Request.QueryString["tc"].ToString(), conn));
		}
	}
}
