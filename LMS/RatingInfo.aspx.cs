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

namespace SME.LMS
{
	/// <summary>
	/// Summary description for RatingInfo.
	/// </summary>
	public partial class RatingInfo : System.Web.UI.Page
	{
		protected Connection conn;
		private string regno, curef;
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			conn = (Connection) Session["Connection"];

			if (!Logic.AllowAccess(Session["GroupID"].ToString(), Request.QueryString["mc"], conn))
				Response.Redirect("../Restricted.aspx");

			if (!IsPostBack)
			{
				ViewData();
			}
			ViewMenu();
		}

		private void ViewMenu()
		{
			try 
			{
				conn.QueryString = "select * from SCREENMENU where menucode = '"+Request.QueryString["mc"]+"'";
				conn.ExecuteQuery();

				string mc1 = Request.QueryString["mc"];
				string mc2 = Request.QueryString["mc"];
				for (int i = 0; i < conn.GetRowCount(); i++) 
				{
					HyperLink t = new HyperLink();
					t.Text = conn.GetFieldValue(i, 2);
					t.Font.Bold = true;
					string strtemp = "";
					if (conn.GetFieldValue(i, 3).Trim()!= "") 
					{
						if (conn.GetFieldValue(i,3).IndexOf("mc=") >= 0)
							strtemp = "lmsreg="+Request.QueryString["lmsreg"]+"&scr="+Request.QueryString["scr"];
						else	strtemp = "lmsreg="+Request.QueryString["lmsreg"]+"&mc="+Request.QueryString["mc"]+"&scr="+Request.QueryString["scr"];
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

		private void ViewData()
		{
			curef = "";
			regno = "";
			ViewDataApplication();
			if (curef != "" && regno != "")
			{
				ViewRatingHistory();
				ViewRatingLink();
			}
		}

		private void ViewDataApplication()
		{
			//get LOS application no
			conn.QueryString = "EXEC LMS_RATINGINFO_GETLOSAPP '" + Request.QueryString["lmsreg"] + "'";
			conn.ExecuteQuery();

			curef = conn.GetFieldValue("CU_REF");
			regno = conn.GetFieldValue("AP_REGNO");
		}

		private void ViewRatingLink() 
		{
			HyperLink byCustomer = new HyperLink();
			byCustomer.Text = "Customer";
			byCustomer.Font.Bold = true;
			byCustomer.NavigateUrl = "../Scoring/BCG_Customer.aspx?regno=" + regno + "&curef=" + curef + "&tc=" + /*Request.QueryString["tc"] +*/ "&mc=" + Request.QueryString["mc"]+"&scr=0" ;//+Request.QueryString["scr"];
			byCustomer.Target = "if";

			HyperLink byFacility = new HyperLink();
			byFacility.Text = "Facility";
			byFacility.Font.Bold = true;
			byFacility.NavigateUrl = "../Scoring/BCG_Facility.aspx?regno=" + regno + "&curef=" + curef + "&tc=" + /*Request.QueryString["tc"] +*/ "&mc=" + Request.QueryString["mc"]+"&scr=0" ;//+Request.QueryString["scr"];
			byFacility.Target = "if";

			this.PH_BY.Controls.Add(byCustomer);
			this.PH_BY.Controls.Add(new LiteralControl("&nbsp;&nbsp;"));
			this.PH_BY.Controls.Add(byFacility);			
		}

		private void ViewRatingHistory()
		{
			string seq = "";
			conn.QueryString = "SELECT TOP 1 AP_REGNO, SEQ, RATEDATE, A1003CUST_FINAL_RISKCLASS " +
				"FROM VW_SCOREBCG_RESULTCUSTRATING where CU_REF = '" + curef + "' order by RATEDATE desc";
			conn.ExecuteQuery();
			if (conn.GetRowCount() > 0)
			{
				seq = conn.GetFieldValue(0, "SEQ");
				LBL_RATING.Text = conn.GetFieldValue(0, "A1003CUST_FINAL_RISKCLASS");
				LBL_RATINGDATE.Text = GlobalTools.FormatDate(conn.GetFieldValue(0, "RATEDATE"));
			}
			if (seq != "")
			{
				conn.QueryString = "SELECT TOP 1 RATIO_PERIOD, RATIO_TYPE " +
					"FROM VW_SCOREBCG_INPUTCUSTRATING where CU_REF = '" + curef + "' and SEQ = " + seq;
				conn.ExecuteQuery();
			}
			if (conn.GetRowCount() > 0)
			{
				LBL_RATIO_PERIOD.Text = GlobalTools.FormatDate(conn.GetFieldValue(0, "RATIO_PERIOD"));
				LBL_RATIO_TYPE.Text = conn.GetFieldValue(0, "RATIO_TYPE");
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

		protected void BTN_BACK_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			string url = "SearchCustomer.aspx?mc=" + Request.QueryString["mc"];
			if (Request.QueryString["tc"] != "")
			{
				url = url + "&tc=" + Request.QueryString["tc"];
			}
			if (Request.QueryString["scr"] != "")
			{
				url = url + "&scr=" + Request.QueryString["scr"];
			}
			Response.Redirect(url);
		}
	}
}
