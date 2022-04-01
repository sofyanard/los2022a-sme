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

namespace SME.Assignment.Channeling
{
	/// <summary>
	/// Summary description for MainVerificationAssignment.sadfsad
	/// </summary>
	public partial class AssignmentComplyReview : System.Web.UI.Page
	{
		protected Connection conn;
		protected Tools tool = new Tools();
		protected Connection2 conn2;

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

		protected void Page_Load(object sender, System.EventArgs e)
		{
			conn = (Connection) Session["Connection"];
			conn2 = new Connection2();

			//if (!Logic.AllowAccess(Session["GroupID"].ToString(), Request.QueryString["mc"], conn))
			//	Response.Redirect("/SME/Restricted.aspx");

			if (!IsPostBack)
			{
				ViewMenu();
				conn2.QueryString = "EXEC CHANNELING_VIEWDATA_INITIATIONMAINPAGE '" + Request.QueryString["curef"] + "','" + Session["UserID"].ToString() + "','" + Request.QueryString["regno"] + "'";
				conn2.ExecuteQuery();

				FillDropDownListDateAndApplicationNumber();
			}
		}

		private void FillDropDownListDateAndApplicationNumber()
		{
			IsiTanggal();

			conn.QueryString = "select branch_name, branch_code from rfbranch where active='1' order by branch_code";
			conn.ExecuteQuery();
			for (int i = 0; i < conn.GetRowCount(); i++)
				DDL_AP_BOOKINGBRANCH.Items.Add(new ListItem(conn.GetFieldValue(i,1) + " - " + conn.GetFieldValue(i,0), conn.GetFieldValue(i,1)));
			//set default booking branch
			DDL_AP_BOOKINGBRANCH.SelectedValue = conn2.GetFieldValue("SU_BRANCH");

			conn.QueryString = "select branch_name, branch_code from vw_ccobranch order by branch_code";
			conn.ExecuteQuery();
			for (int i = 0; i < conn.GetRowCount(); i++)
				DDL_AP_CCOBRANCH.Items.Add(new ListItem(conn.GetFieldValue(i,1) + " - " + conn.GetFieldValue(i,0), conn.GetFieldValue(i,1)));
			//set default cco branch
			conn.QueryString = "select br_ccobranch from rfbranch where branch_code = '" + Session["BranchID"].ToString() + "'";
			conn.ExecuteQuery();
			DDL_AP_CCOBRANCH.SelectedValue = conn.GetFieldValue("br_ccobranch");

			//isi default tanggal
			txt_DD_B.Text = conn2.GetFieldValue("dy");
			ddl_MM_B.SelectedValue = conn2.GetFieldValue("mth");
			txt_YY_B.Text = conn2.GetFieldValue("yr");

			LBL_PLAFOND_OWNER.Text = conn2.GetFieldValue("CU_NAME");
			LBL_REMAINING_EMAS.Text = GlobalTools.MoneyFormat(conn2.GetFieldValue("REMAINING_EMAS_LIMIT"));
			LBL_PENDING_LIMIT.Text = GlobalTools.MoneyFormat(conn2.GetFieldValue("PENDING_LIMIT"));
			LBL_AVAILBALE_LIMIT.Text = GlobalTools.MoneyFormat(conn2.GetFieldValue("AVAILABLE_LIMIT"));
			TXT_APPLICATION.Text = conn2.GetFieldValue("APREGNO");
		}

		private void ViewMenu()
		{
			try 
			{
				conn.QueryString = "select SM_ID,MENUCODE,SM_MENUDISPLAY,SM_LINKNAME from SCREENMENU where menucode = '"+Request.QueryString["mc"]+"'";
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
							strtemp = "regno=" + Request.QueryString["regno"]+ "&curef="+Request.QueryString["curef"]+"&tc="+Request.QueryString["tc"]+"&jnsnasabah="+Request.QueryString["jnsnasabah"]+"&programid="+Request.QueryString["programid"]+"&lmsreg="+Request.QueryString["lmsreg"]+"&scr="+Request.QueryString["scr"];
						else	
							strtemp = "regno=" + Request.QueryString["regno"]+ "&curef="+Request.QueryString["curef"]+"&mc="+Request.QueryString["mc"]+"&tc="+Request.QueryString["tc"]+"&jnsnasabah="+Request.QueryString["jnsnasabah"]+"&programid="+Request.QueryString["programid"]+"&lmsreg="+Request.QueryString["lmsreg"]+"&scr="+Request.QueryString["scr"];
						//t.ForeColor = Color.MidnightBlue; 
					}
					else 
					{
						strtemp = "";
						t.ForeColor = Color.Red; 
					}
					t.NavigateUrl = "../" + conn.GetFieldValue(i, 3)+strtemp;
					Menu.Controls.Add(t);
					Menu.Controls.Add(new LiteralControl("&nbsp;&nbsp;&nbsp;"));
				}
			} 
			catch (Exception ex) 
			{
				string temp = ex.ToString();
			}
		}

		private void IsiTanggal()
		{
			GlobalTools.initDateFormINA(txt_DD_B, ddl_MM_B, txt_YY_B, true);
		}
	}
}
