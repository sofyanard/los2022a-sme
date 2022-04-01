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
using DMS.CuBESCore;
using DMS.DBConnection;
using Microsoft.VisualBasic;

namespace SME.IPPS.Process.ReviewAssignmentValidation
{
	/// <summary>
	/// Summary description for AssignmentToPIC.
	/// </summary>
	public partial class AssignmentToPIC : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.TextBox TXT_TGL_RECEIVED;
		protected System.Web.UI.WebControls.DropDownList DDL_BLN_RECEIVED;
		protected System.Web.UI.WebControls.TextBox TXT_THN_RECEIVED;
		protected Connection conn = new Connection(ConfigurationSettings.AppSettings["conn"]);
		protected Tools tools = new Tools();
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			ViewMenu();
			if(!IsPostBack)
			{
				fillField();
			}
		}

		private void fillField()
		{
			TXT_unit.Text=Request.QueryString["unit"];
			TXT_reference.Text=Request.QueryString["regno"];
			TXT_request_date.Text=Request.QueryString["initdate"];
			conn.QueryString="select last_update from ipps_application where ipps_regno='" +Request.QueryString["regno"]+"'";
			conn.ExecuteQuery();

			string name=(string)(Session["FullName"]);
			string userid=(string)(Session["UserID"]);
			

			txt_received_date.Text=tools.FormatDate(conn.GetFieldValue("last_update"),true);
			DDL_DEPTHEAD.Items.Add(new ListItem(name,userid));
				
			DDL_PIC.Items.Add(new ListItem("--Pilih--",""));

			conn.QueryString="select * from scuser where su_upliner='" +Session["UserID"] +"' and groupid='"+Session["GroupID"] +"'";
			conn.ExecuteQuery();

			for (int i = 0; i < conn.GetRowCount(); i++)
				DDL_PIC.Items.Add(new ListItem(conn.GetFieldValue("su_fullname"),conn.GetFieldValue("userid")));


		}

		private void ViewMenu()
		{
			try 
			{
				conn.QueryString = "select * from SCREENMENU where menucode ='" + Request.QueryString["mc"] + "'";
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
			if (DDL_PIC.SelectedValue!="")
			{
				conn.QueryString="exec IPPS_Review_Assignment_Validation 'assign','"+ 
					TXT_reference.Text +"','','','"+ 
					DDL_PIC.SelectedValue +"','','"+ Session["UserID"]+"'";
				conn.ExecuteQuery();
				Response.Redirect("ReviewRequestList.aspx");
			}			

		}

		protected void BTN_CANCEL_Click(object sender, System.EventArgs e)
		{
			Response.Redirect("ReviewRequestList.aspx");
		}
	}
}
