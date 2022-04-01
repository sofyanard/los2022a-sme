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

namespace SME.Approval
{
	/// <summary>
	/// Summary description for AprvBy.
	/// </summary>
	public partial class AprvBy : System.Web.UI.Page
	{
		//protected Connection conn = new Connection("Data Source=10.123.12.30;Initial Catalog=SMEDEV;uid=sa;pwd=");
		protected Connection conn;
		protected Tools tool = new Tools();
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			conn = (Connection) Session["Connection"];

			if (!Logic.AllowAccess(Session["GroupID"].ToString(), Request.QueryString["mc"], conn))
				Response.Redirect("/SME/Restricted.aspx");

			if (!IsPostBack)
			{
				LBL_GROUPID.Text = Session["GROUPID"].ToString();
				viewdata();
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

		private void viewdata()
		{
			conn.QueryString = "select * from scuser "+
								" where groupid = '"+LBL_GROUPID.Text+"' ";
							   //" where groupid = '"+Session["GROUPID"].ToString()+"' ";
			conn.ExecuteQuery();
			
			int row = conn.GetRowCount();
			int rowtemp = row;
			for (int i = 0; i < row; i++)
			{
				cbl_AprvBy.Items.Add(new ListItem(conn.GetFieldValue(i,2), conn.GetFieldValue(i,0)));	
			}
		}

		protected void btn_ok_Click(object sender, System.EventArgs e)
		{
			//insert approval by
			conn.QueryString = "select * from scuser "+
								" where groupid = '"+LBL_GROUPID.Text+"' ";
							   //" where groupid = '"+Session["GROUPID"].ToString()+"' ";
			conn.ExecuteQuery();
			for (int i = 0; i < conn.GetRowCount();i++) 
			{
				if (cbl_AprvBy.Items[i].Selected)
				{
					string var_aprvby = conn.GetFieldValue("userid");
					conn.QueryString = "select max(isnull(AR_SEQ,0))+1 seq from APPROVALPERSON where ap_regno = '"+lbl_regno.Text+"'";
					conn.ExecuteQuery();
					int seq = Convert.ToInt16(conn.GetFieldValue("seq"));

					conn.QueryString = "insert approvalperson (ap_regno, ar_seq, ar_by) values('"+lbl_regno.Text+"', "+seq+", '"+var_aprvby+"')";
					conn.ExecuteQuery();
				}
			}
		}
	}
}
