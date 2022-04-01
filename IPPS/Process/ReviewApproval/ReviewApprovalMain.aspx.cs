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


namespace SME.IPPS.Process.ReviewApproval
{
	/// <summary>
	/// Summary description for ReviewApprovalMain.
	/// </summary>
	public partial class ReviewApprovalMain : System.Web.UI.Page
	{
		protected Tools tools = new Tools();
		protected Connection conn = new Connection(ConfigurationSettings.AppSettings["conn"]);
	
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			ViewMenu();
			if(!IsPostBack)
			{
				fillField();
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

		private void fillField()
		{
			//&reqseq,revseq, initdate, unit, reviewer, validator, codate
			TXT_unit.Text = Request.QueryString["unit"];
			TXT_reference.Text = Request.QueryString["regno"];
			TXT_request_date.Text = Request.QueryString["initdate"];
			txt_received_date.Text = Request.QueryString["codate"];
			
			conn.QueryString = "select su_fullname from scuser where userid='" + Request.QueryString["validator"] + "'";
			conn.ExecuteQuery();

			ddl_dep_head.Items.Add(new ListItem(conn.GetFieldValue("su_fullname"), Request.QueryString["validator"]));
		
			conn.QueryString = "select su_fullname from scuser where userid='" + Request.QueryString["reviewer"] + "'";
			conn.ExecuteQuery();

			ddl_pic.Items.Add(new ListItem(conn.GetFieldValue("su_fullname"), Request.QueryString["reviewer"]));
			
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

		protected void BTN_SAVE_Click(object sender, System.EventArgs e)
		{
			try
			{
				conn.QueryString="EXEC IPPS_REVIEW_APPROVE 'approved', " +
					"'" + Request.QueryString["regno"]
					+ "','" + Request.QueryString["reqseq"] 
					+ "','" + Request.QueryString["revseq"] 
					+ "','"+ Session["UserID"].ToString() 
					+ "','" + TXT_DECISION.Text + "'" ;
				conn.ExecuteQuery();
				
			}
			catch(Exception ex)
			{
				string errmsg = ex.Message.Replace("'","");
				if (errmsg.IndexOf("Last Query:") > 0)
					errmsg = errmsg.Substring(0, errmsg.IndexOf("Last Query:"));
				GlobalTools.popMessage(this, errmsg);
				return;
			}
		}

		protected void BTN_CLEAR_Click(object sender, System.EventArgs e)
		{
			TXT_DECISION.Text="";
		}

		protected void BTN_BACKREVIEW_Click(object sender, System.EventArgs e)
		{
			try
			{
				conn.QueryString="EXEC IPPS_REVIEW_APPROVE 'backtrack', " +
					"'" + Request.QueryString["regno"]
					+ "','" + Request.QueryString["reqseq"] 
					+ "','" + Request.QueryString["revseq"] 
					+ "','"+ Session["UserID"].ToString() 
					+ "','" + TXT_DECISION.Text + "'" ;
				conn.ExecuteQuery();
			}
			catch(Exception ex)
			{
				string errmsg = ex.Message.Replace("'","");
				if (errmsg.IndexOf("Last Query:") > 0)
					errmsg = errmsg.Substring(0, errmsg.IndexOf("Last Query:"));
				GlobalTools.popMessage(this, errmsg);
				return;
			}
		}

		protected void btn_update_Click(object sender, System.EventArgs e)
		{
			if(TXT_DECISION.Text=="")
			{
				GlobalTools.popMessage(this, "Decision belum diisi!");
				return;
			}

			else
			{
				try
				{
					conn.QueryString= " EXEC IPPS_UPDATE_TRACK '" + Request.QueryString["regno"] + "', '"
										+ "PP6.0" + "', '" + Session["UserID"].ToString() + "', ''";
					conn.ExecuteQuery();
				}
				catch(Exception ex)
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
}
