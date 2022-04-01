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

namespace SME.IPPS.Process.ReviewEntry
{
	/// <summary>
	/// Summary description for GeneralInfo.
	/// </summary>
	public partial class GeneralInfo : System.Web.UI.Page
	{
		protected Connection conn = new Connection(ConfigurationSettings.AppSettings["conn"]);
		protected Tools tools = new Tools();
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			ViewMenu();
			
			if(!IsPostBack)
			{	
				fillData();
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

		private void fillData()
		{
			TXT_unit.Text = Request.QueryString["unit"];
			TXT_reference.Text = Request.QueryString["regno"];
			TXT_request_date.Text = Request.QueryString["initdate"];
			
			conn.QueryString="select * from IPPS_REVIEW where IPPS_REGNO='" + Request.QueryString["regno"]
								+ "' AND REQ_SEQ='" + Request.QueryString["reqseq"] 
								+ "' AND REV_SEQ='" + Request.QueryString["revseq"] + "'" ;
			conn.ExecuteQuery();

			txt_received_date.Text= tools.FormatDate(conn.GetFieldValue("ASSIGN_TOOFFICER_DATE"),true);
			
			string name=(string)(Session["FullName"]);
			string userid=(string)(Session["UserID"]);
			ddl_pic.Items.Add(new ListItem(name,userid));

			conn.QueryString="select su_upliner from scuser where userid='" + userid + "' and groupid='"+ Session["GroupID"].ToString() +"'";
			conn.ExecuteQuery();
			string dh = conn.GetFieldValue("su_upliner");

			conn.QueryString="select * from scuser where userid='" + dh +"'";
			conn.ExecuteQuery();
			string namaDH= conn.GetFieldValue("su_fullname");
			
			ddl_pic.Items.Add(new ListItem(namaDH,dh));

			conn.QueryString="select ACQINFO from IPPS_APPLICATION where IPPS_REGNO='" + Request.QueryString["regno"]+ "'";
			conn.ExecuteQuery();
			TXT_REMARK.Text = conn.GetFieldValue("ACQINFO");

			cekTombol();

		}

		private void cekTombol()
		{
			 conn.QueryString= "select count(cnt_seq) as total from ipps_review_contain where IPPS_REGNO='" + Request.QueryString["regno"]
								+ "' AND REQ_SEQ='" + Request.QueryString["reqseq"] 
								+ "' AND REV_SEQ='" + Request.QueryString["revseq"] 
								+ "' AND (REV_CONTAIN='' or REV_CONTAIN is null)";
			conn.ExecuteQuery();
			if (conn.GetFieldValue("total")=="0")
				btn_update.Enabled = true;
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

		protected void btn_update_Click(object sender, System.EventArgs e)
		{
			conn.QueryString="EXEC IPPS_REVIEW_DONE '" + Request.QueryString["regno"]
								+ "', '" + Request.QueryString["reqseq"] 
								+ "', '" + Request.QueryString["revseq"] + "'" ;
			conn.ExecuteQuery();
		}
	}
}
