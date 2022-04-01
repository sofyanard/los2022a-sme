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

namespace SME.IPPS.Process.ICAssignValidation
{
	/// <summary>
	/// Summary description for AssignmentToPIC.
	/// </summary>
	public partial class AssignmentToPIC : System.Web.UI.Page
	{
		protected Connection conn;
		protected Tools tool = new Tools();
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			conn = (Connection) Session["Connection"];

			if (!Logic.AllowAccess(Session["GroupID"].ToString(), Request.QueryString["mc"], conn))
				Response.Redirect("../../SME/Restricted.aspx");

			ViewMenu();

			if(!IsPostBack)
			{
				ViewGeneralInfo();
				ViewAssignInfo();
				FillDDLPIC();
			}
		}

		private void ViewGeneralInfo()
		{
			conn.QueryString = "SELECT * FROM VW_IPPS_ICASSIGN_VIEWGENERALINFO WHERE IPPS_REGNO = '" + Request.QueryString["regno"] + "'";
			conn.ExecuteQuery();

			if (conn.GetRowCount() > 0)
			{
				TXT_REFERENCE.Text = conn.GetFieldValue("IPPS_REGNO");
				TXT_UNIT.Text = conn.GetFieldValue("BRANCH_NAME");
				TXT_REQUEST_DATE.Text = conn.GetFieldValue("INIT_DATE");
			}
		}

		private void ViewAssignInfo()
		{
			conn.QueryString = "SELECT * FROM VW_IPPS_ICASSIGN_VIEWASSIGNINFO WHERE IPPS_REGNO = '" + Request.QueryString["regno"] + "'";
			conn.ExecuteQuery();

			if (conn.GetRowCount() > 0)
			{
				TXT_RECEIVED_DATE.Text = conn.GetFieldValue("RECEIVED_DATE");
				TXT_DEPTHEAD.Text = conn.GetFieldValue("DEPTHEAD");
				try { DDL_PIC.SelectedValue = conn.GetFieldValue("PIC"); }
				catch { DDL_PIC.SelectedValue = ""; }
			}
		}

		private void FillDDLPIC()
		{
			DDL_PIC.Items.Add(new ListItem("- SELECT -", ""));
			conn.QueryString = "EXEC IPPS_ICASSIGN_FILLDDLPIC '" + Request.QueryString["regno"] + "', '" + Session["UserID"].ToString() + "'";
			conn.ExecuteQuery();
			for (int i = 0; i < conn.GetRowCount(); i++)
			{
				DDL_PIC.Items.Add(new ListItem(conn.GetFieldValue(i,1), conn.GetFieldValue(i,0)));
			}
		}

		private void ViewMenu()
		{
			try 
			{
				conn.QueryString = "select * from SCREENMENU where menucode = '" + Request.QueryString["mc"] + "'";
				conn.ExecuteQuery();
				
				for (int i = 0; i < conn.GetRowCount(); i++) 
				{
					HyperLink t = new HyperLink();
					t.Text = conn.GetFieldValue(i, 2);
					t.Font.Bold = true;
					string strtemp = "";
					if (conn.GetFieldValue(i, 3).Trim()!= "") 
					{
						if (conn.GetFieldValue(i,3).IndexOf("mc=") >= 0)
							strtemp = "regno=" + Request.QueryString["regno"] +  "&tc=" + Request.QueryString["tc"] ;
						else	
							strtemp = "regno=" + Request.QueryString["regno"] +  "&mc=" + Request.QueryString["mc"]+"&tc="+Request.QueryString["tc"];
						//t.ForeColor = Color.MidnightBlue; 
					}
					else 
					{
						strtemp = "";
						t.ForeColor = Color.Red; 
					}
					t.NavigateUrl = conn.GetFieldValue(i,3)+strtemp;
					Menu.Controls.Add(t);
					Menu.Controls.Add(new LiteralControl("&nbsp;&nbsp;&nbsp;"));
				}
			} 
			catch (Exception ex) 
			{
				string temp = ex.ToString();
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

		protected void BTN_ASSIGN_Click(object sender, System.EventArgs e)
		{
			try
			{
				conn.QueryString = "exec IPPS_ICASSIGN_PROCESSASSIGN '" +
					Request.QueryString["regno"] + "', '" +
					DDL_PIC.SelectedValue + "', '" +
					Session["UserID"].ToString() + "'";
				conn.ExecuteNonQuery();

				Response.Redirect("ReviewICList.aspx?tc=" + Request.QueryString["tc"] + "&mc=" + Request.QueryString["mc"]);
			}
			catch (Exception ex)
			{
				string errmsg = ex.Message.Replace("'","");
				if (errmsg.IndexOf("Last Query:") > 0)
					errmsg = errmsg.Substring(0, errmsg.IndexOf("Last Query:"));
				GlobalTools.popMessage(this, errmsg);
				return;
			}
		}

		protected void BTN_CANCEL_Click(object sender, System.EventArgs e)
		{
			try
			{
				conn.QueryString = "exec IPPS_ICASSIGN_CANCELASSIGN '" +
					Request.QueryString["regno"] + "', '" +
					DDL_PIC.SelectedValue + "', '" +
					Session["UserID"].ToString() + "'";
				conn.ExecuteNonQuery();

				Response.Redirect("ReviewICList.aspx?tc=" + Request.QueryString["tc"] + "&mc=" + Request.QueryString["mc"]);
			}
			catch (Exception ex)
			{
				string errmsg = ex.Message.Replace("'","");
				if (errmsg.IndexOf("Last Query:") > 0)
					errmsg = errmsg.Substring(0, errmsg.IndexOf("Last Query:"));
				GlobalTools.popMessage(this, errmsg);
				return;
			}
		}
	}
}
