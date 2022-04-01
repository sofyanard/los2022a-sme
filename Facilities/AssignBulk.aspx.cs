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

namespace SME.Facilities
{
	/// <summary>
	/// Summary description for AssignBulk.
	/// </summary>
	public partial class AssignBulk : System.Web.UI.Page
	{
		protected Connection conn;
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			conn = (Connection) Session["Connection"];

			if (!Logic.AllowAccess(Session["GroupID"].ToString(), Request.QueryString["mc"], conn))
				Response.Redirect("../Restricted.aspx");

			if (!IsPostBack)
			{
				ViewData();
				ViewMenu();
			}
		}

		private void ViewData()
		{
			conn.QueryString = "SELECT * FROM VW_ASSIGNMENTBULK_USERDATA WHERE USERID = '" + Request.QueryString["uid"] + "'";
			conn.ExecuteQuery();
			TXT_USERID.Text = conn.GetFieldValue("USERID");
			TXT_USERNAME.Text = conn.GetFieldValue("USERNAME");
			TXT_GROUPNAME.Text = conn.GetFieldValue("GROUPNAME");
			TXT_BRANCHNAME.Text = conn.GetFieldValue("BRANCHNAME");
			conn.ClearData();
		}

		private void ViewMenu()
		{
			//Current Customer
			HyperLink h1 = new HyperLink();
			h1.Text = "Current Customer";
			h1.Font.Bold = true;
			h1.NavigateUrl = "AssignBulkCust.aspx?uid=" + Request.QueryString["uid"] + "&mc=" + Request.QueryString["mc"];
			h1.Target = "if2";

			//Pending Application (BU)
			HyperLink h2 = new HyperLink();
			h2.Text = "Pending Application (BU)";
			h2.Font.Bold = true;
			h2.NavigateUrl = "AssignBulkBU.aspx?uid=" + Request.QueryString["uid"] + "&mc=" + Request.QueryString["mc"];
			h2.Target = "if2";

			//Pending Approval
			HyperLink h3 = new HyperLink();
			h3.Text = "Pending Approval";
			h3.Font.Bold = true;
			h3.NavigateUrl = "AssignBulkAppr.aspx?uid=" + Request.QueryString["uid"] + "&mc=" + Request.QueryString["mc"];
			h3.Target = "if2";

			//Pending Application (CO)
			HyperLink h4 = new HyperLink();
			h4.Text = "Pending Application (CO)";
			h4.Font.Bold = true;
			h4.NavigateUrl = "AssignBulkCO.aspx?uid=" + Request.QueryString["uid"] + "&mc=" + Request.QueryString["mc"];
			h4.Target = "if2";

			PlaceHolder1.Controls.Add(h1);
			PlaceHolder1.Controls.Add(new LiteralControl("&nbsp;&nbsp;&nbsp;"));

			PlaceHolder1.Controls.Add(h2);
			PlaceHolder1.Controls.Add(new LiteralControl("&nbsp;&nbsp;&nbsp;"));

			PlaceHolder1.Controls.Add(h3);
			PlaceHolder1.Controls.Add(new LiteralControl("&nbsp;&nbsp;&nbsp;"));

			PlaceHolder1.Controls.Add(h4);
			PlaceHolder1.Controls.Add(new LiteralControl("&nbsp;&nbsp;&nbsp;"));
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
