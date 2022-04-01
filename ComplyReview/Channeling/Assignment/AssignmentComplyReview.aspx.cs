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

namespace SME.ComplyReview.Channeling.Assignment
{
	/// <summary>
	/// Summary description for MainVerificationAssignment.sadfsad
	/// </summary>
	public partial class AssignmentComplyReview : System.Web.UI.Page
	{
		protected Connection conn;
		protected Connection2 conn2;
		protected System.Web.UI.WebControls.ImageButton BTN_BACK;
		protected Tools tool = new Tools();

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
				//ViewDataApplication();		
		
				ViewMenu();
				conn2.QueryString = "EXEC CHANNELING_VIEWDATA_COMPLY_REVIEW_MAINPAGE '" + Request.QueryString["curef"] + "','" + Session["UserID"].ToString() + "','" + Request.QueryString["parentregno"] + "','" + Request.QueryString["aano"] + "','" + Request.QueryString["productid"] + "','" + Request.QueryString["prodseq"] + "'";
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

			//DDL_PETUGAS.Items.Add(new ListItem("9980098721-Victoria", ""));
			GlobalTools.fillRefList(DDL_PETUGAS, "SELECT USERID, SU_FULLNAME FROM SCUSER WHERE USERID = '" + Session["UserID"] + "'", conn);
			GlobalTools.fillRefList(DDL_PETUGAS, "SELECT USERID, SU_FULLNAME FROM SCUSER WHERE SU_TEAMLEADER = '" + Session["UserID"] + "'", conn);
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
							strtemp = "regno=" + Request.QueryString["regno"]+ "&curef="+Request.QueryString["curef"]+"&mc="+Request.QueryString["mc"]+"&tc="+Request.QueryString["tc"]+"&jnsnasabah="+Request.QueryString["jnsnasabah"]+"&programid="+Request.QueryString["programid"]+"&lmsreg="+Request.QueryString["lmsreg"]+"&scr="+Request.QueryString["scr"]+"&parentregno="+Request.QueryString["parentregno"]+"&aano="+Request.QueryString["aano"] + "&productid=" + Request.QueryString["productid"] + "&prodseq=" + Request.QueryString["prodseq"];
						else	
							strtemp = "regno=" + Request.QueryString["regno"]+ "&curef="+Request.QueryString["curef"]+"&mc="+Request.QueryString["mc"]+"&tc="+Request.QueryString["tc"]+"&jnsnasabah="+Request.QueryString["jnsnasabah"]+"&programid="+Request.QueryString["programid"]+"&lmsreg="+Request.QueryString["lmsreg"]+"&scr="+Request.QueryString["scr"]+"&parentregno="+Request.QueryString["parentregno"]+"&aano="+Request.QueryString["aano"] + "&productid=" + Request.QueryString["productid"] + "&prodseq=" + Request.QueryString["prodseq"];
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

		//return to BU
		protected void Button2_Click(object sender, System.EventArgs e)
		{
			conn.QueryString = "EXEC CHANNELING_TRACKUPDATE '" + Request.QueryString["regno"] + "','" + Request.QueryString["productid"] + "','" + Session["userid"] + "','" + Request.QueryString["prodseq"] + "','" + Request.QueryString["aano"] + "','TCHAN2.0'";
			conn.ExecuteQuery();

			conn.QueryString = "EXEC CHANNELING_FREEING_CO_OFFICER '" + Request.QueryString["regno"] + "'";
			conn.ExecuteQuery();

			conn.QueryString = "SELECT SU_FULLNAME FROM SCUSER, APPLICATION WHERE AP_REGNO = '" + Request.QueryString["regno"] + "' AND SCUSER.USERID = APPLICATION.AP_RELMNGR";
			conn.ExecuteQuery();

			Response.Redirect("ListComplyReview.aspx?msg=notok&destination=" + conn.GetFieldValue("SU_FULLNAME"));
		}

		//assign ke officer, update track
		protected void Button1_Click(object sender, System.EventArgs e)
		{
			conn.QueryString = "EXEC CHANNELING_TRACKUPDATE '" + Request.QueryString["regno"] + "','" + Request.QueryString["productid"] + "','" + Session["userid"] + "','" + Request.QueryString["prodseq"] + "','" + Request.QueryString["aano"] + "','TCHAN6.0'";
			conn.ExecuteNonQuery();
			
			conn.QueryString = "EXEC CHANNELING_ASSIGN_TO_CO_OFFICER '" + Request.QueryString["regno"] + "','" + DDL_PETUGAS.SelectedValue.ToString() + "'";
			conn.ExecuteNonQuery();

			/*Response.Redirect("ListComplyReview.aspx");*/

			Tools.popMessage(this, DDL_PETUGAS.SelectedValue.ToString());

			Response.Redirect("ListComplyReview.aspx?msg=ok&destination=" + DDL_PETUGAS.SelectedItem.Text.ToString());
		}
	}
}
