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
namespace SME.HDRS
{
	/// <summary>
	/// Summary description for PicAssignment.
	/// </summary>
	public partial class PicAssignment : System.Web.UI.Page
	{
		protected Connection conn;
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			conn = (Connection) Session["Connection"];
			if (!Logic.AllowAccess(Session["GroupID"].ToString(), Request.QueryString["mc"], conn))
				Response.Redirect("/SME/Restricted.aspx");

			if (!IsPostBack)
			{
				ViewData();

				conn.QueryString = "select a.groupid, b.sg_grpname from grpaccessmenu a left join scgroup b on a.groupid=b.groupid where a.menucode like 'b02'" ;
				conn.ExecuteQuery();
				DDL_PIC2.Items.Add(new ListItem("--Pilih--",""));
				DDL_PIC.Items.Add(new ListItem("--Pilih--",""));
				for (int i=0; i < conn.GetRowCount(); i++)
					DDL_PIC2.Items.Add(new ListItem(conn.GetFieldValue(i,1), conn.GetFieldValue(i,0)));	
				
			}
		}

		private void ViewData()
		{
			conn.QueryString = "select * from VW_HELPDESK_PIC_ASSIGNMENT WHERE H_HRS#='" +Request.QueryString["regnum"]+ "'";
			conn.ExecuteQuery();	
			TXT_HRS.Text = conn.GetFieldValue("H_HRS#");
			TXT_TRACK.Text = conn.GetFieldValue("CUR_TRACK");
			TXT_PIC.Text = conn.GetFieldValue("SU_FULLNAME");
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

		protected void BTN_ASG_Click(object sender, System.EventArgs e)
		{
			conn.QueryString = " exec HELPDESK_UPDATE_SEND_TO '"+
				Request.QueryString["regnum"]+"', '"+
				DDL_PIC2.SelectedValue+"', '"+
				DDL_PIC.SelectedValue+"' ";
			conn.ExecuteNonQuery();

			conn.QueryString = " exec HELPDESK_INSERT_PIC_ASSIGN '"+
				Request.QueryString["regnum"]+"', '"+				
				DDL_PIC.SelectedValue+"' ";
			conn.ExecuteNonQuery();

			Response.Redirect("PendingList.aspx?tc=" + Request.QueryString["tc"] + "&mc=" + Request.QueryString["mc"]);		
		}

		private void ViewPic()
		{
			DDL_PIC.Items.Clear();
			DDL_PIC.Items.Add(new ListItem("- PILIH -", ""));
			
			conn.QueryString = "select userid, su_fullname from scuser where groupid='" + DDL_PIC2.SelectedValue + "' and su_active='1' order by su_fullname";
			conn.ExecuteQuery();
			for (int i = 0; i < conn.GetRowCount(); i++)
				DDL_PIC.Items.Add(new ListItem(conn.GetFieldValue(i,1), conn.GetFieldValue(i,0)));
		}

		protected void DDL_PIC2_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			ViewPic();
		}

		protected void BTN_BACK_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			Response.Redirect("PendingList.aspx?tc=" + Request.QueryString["tc"] + "&mc=" + Request.QueryString["mc"] );
		}
	}
}
