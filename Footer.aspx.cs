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
using System.Configuration;
using DMS.DBConnection;

namespace SME
{
	/// <summary>
	/// Summary description for Footer.
	/// </summary>
	public partial class Footer : System.Web.UI.Page
	{
		protected Connection conn;
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			if (!IsPostBack)
			{
				//conn = new Connection(Session["ConnectionString"].ToString());
				conn = (Connection) Session["Connection"];

				Label2.Text = Session["FullName"].ToString();
				Label1.Text = System.DateTime.Now.ToShortTimeString() + " - " + System.DateTime.Now.ToLongDateString();
			
				try 
				{
					//conn.QueryString = "select sg_grpname from scallgroup where groupid = '" + Session["GroupID"].ToString() + "'";
					conn.QueryString = "exec SP_SCGROUP_NAME '" + Session["GroupID"].ToString() + "'";
					conn.ExecuteQuery();
					if (conn.GetRowCount() > 0)
						Label5.Text = "( " + conn.GetFieldValue(0, "sg_grpname") + " )";
				} 
				catch {}

				//ViewState["inf"] = "&name=" + Label2.Text + "&group=" + Label5.Text + "&time=" + Label1.Text;
				ViewState["userid"] = Session["UserID"].ToString();
			}
			/* *** */
/*			try 
			{
				Connection conn2 = new Connection(ConfigurationSettings.AppSettings["eSecurityConnectString"]);
				conn2.QueryString = "exec SU_MONITORACTIVITY '" + Session["UserID"] + "', '" + Request.UserHostAddress + "'";
				conn2.ExecuteQuery();
				// force logout if activity invalid
				if (conn2.GetFieldValue(0,0)=="0")
					post_cnt.Value = "18";
			}	catch { }
*/			/* */
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
	}
}
