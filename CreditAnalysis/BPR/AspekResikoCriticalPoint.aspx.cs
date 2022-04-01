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

namespace SME.CreditAnalysis.BPR
{
	/// <summary>
	/// Summary description for AspekResikoCriticalPoint.
	/// </summary>
	public partial class AspekResikoCriticalPoint : System.Web.UI.Page
	{
	
		//protected Connection conn = new Connection("Data Source=192.168.1.200;Initial Catalog=SME;uid=sa;pwd=");
		protected Connection conn;
		protected Tools tool = new Tools();
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			conn = (Connection) Session["Connection"];
			if (!IsPostBack)
			{
				LoadData();
			}
		}

		private void LoadData()
		{
			conn.QueryString = "select CA_RESIKO from creditanalysis where ap_regno='" + Request.QueryString["regno"] + "'";
			conn.ExecuteQuery();
			TXT_CA_RESIKO.Text = conn.GetFieldValue("CA_RESIKO");
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
			conn.QueryString = "select count (*) from creditanalysis where ap_regno='" + Request.QueryString["regno"] + "'";
			conn.ExecuteQuery();
			if (conn.GetFieldValue(0,0) == "0")
			{
				conn.QueryString = "insert into creditanalysis (AP_REGNO, CA_RESIKO) VALUES ('" + 
					Request.QueryString["regno"].Trim() + "', '" + TXT_CA_RESIKO.Text.Trim() + "') ";
			}
			else
			{
				conn.QueryString = "update creditanalysis set CA_RESIKO = '" + TXT_CA_RESIKO.Text.Trim() + "' "+
					" where ap_regno='" + Request.QueryString["regno"] + "'";
			}
			conn.ExecuteQuery();
		}
	}
}
