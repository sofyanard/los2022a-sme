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
using DMS.CuBESCore;
using Microsoft.VisualBasic;

namespace SME.IDI_BI
{
	/// <summary>
	/// Summary description for Assignment.
	/// </summary>
	public partial class Assignment : System.Web.UI.Page
	{
		protected Connection conn;
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			conn = (Connection) Session["Connection"];
			
			if (!IsPostBack)
			{
				ViewData();

				conn.QueryString = "select * from rfbranch where active='1' order by branch_name" ;
				conn.ExecuteQuery();
				DDL_PIC2.Items.Add(new ListItem("--Pilih--",""));
				DDL_PIC.Items.Add(new ListItem("--Pilih--",""));
				for (int i=0; i < conn.GetRowCount(); i++)
					DDL_PIC2.Items.Add(new ListItem(conn.GetFieldValue(i,1), conn.GetFieldValue(i,0)));	
				
			}
		}

		private void ViewData()
		{
			conn.QueryString = "select * from VW_IDI_PENDING_LIST WHERE IDI_REQ#='" +Request.QueryString["regnum"]+ "'";
			conn.ExecuteQuery();	
			TXT_IDI_REQ.Text = conn.GetFieldValue("IDI_REQ#");
			TXT_TRACK.Text = conn.GetFieldValue("TRACK");
			TXT_OFFICER.Text = conn.GetFieldValue("OFFICER_NAME");
		}

		private void ViewPic()
		{
			DDL_PIC.Items.Clear();
			DDL_PIC.Items.Add(new ListItem("- PILIH -", ""));
			
			conn.QueryString = "select userid, su_fullname from scuser where su_branch='" + DDL_PIC2.SelectedValue + "' and su_active='1' order by su_fullname";
			conn.ExecuteQuery();
			for (int i = 0; i < conn.GetRowCount(); i++)
				DDL_PIC.Items.Add(new ListItem(conn.GetFieldValue(i,1), conn.GetFieldValue(i,0)));
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

		protected void DDL_PIC2_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			ViewPic();
		}

		protected void BTN_BACK_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			Response.Redirect("ListPendingAsg.aspx?tc=" + Request.QueryString["tc"] + "&mc=" + Request.QueryString["mc"] );
		}

		protected void BTN_ASG_Click(object sender, System.EventArgs e)
		{
			conn.QueryString = " exec IDI_ASSIGN '"+
				Request.QueryString["regnum"]+"', '"+				
				DDL_PIC.SelectedValue+"' ";
			conn.ExecuteNonQuery();

			Response.Redirect("ListPendingAsg.aspx?tc=" + Request.QueryString["tc"] + "&mc=" + Request.QueryString["mc"]);	
		}
	}
}
