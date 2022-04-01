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

namespace SME.IPPS.Process.ReviewCompiling
{
	/// <summary>
	/// Summary description for ReviewEntryRetrieved.
	/// </summary>
	public partial class ReviewEntryRetrieved : System.Web.UI.Page
	{
	
		protected Connection conn = new Connection(ConfigurationSettings.AppSettings["conn"]);
		protected Tools tools = new Tools();
		protected void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			ViewMenu();
			if(!IsPostBack)
			{
				viewData();
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

		private void viewData()
		{
			conn.QueryString="select * from ipps_request where ipps_regno='"+ Request.QueryString["regno"] +"' AND REQ_SEQ='" + Request.QueryString["reqseq"] + "'";
			conn.ExecuteQuery();
            
			System.Data.DataTable dt = new System.Data.DataTable();
			dt = conn.GetDataTable().Copy();

			DGR_DRAFTINFO.DataSource = dt;

			try
			{
				DGR_DRAFTINFO.DataBind();
			}
			catch
			{
				DGR_DRAFTINFO.CurrentPageIndex = DGR_DRAFTINFO.PageCount - 1;
				DGR_DRAFTINFO.DataBind();
			}

			conn.ClearData();

			fillField(Request.QueryString["reqseq"]);
		}

		private void fillField(string req_seq)
		{
			conn.QueryString="select * from ipps_drafting where ipps_regno='"+ Request.QueryString["regno"] +"' and req_seq='"+ req_seq +"'";
			conn.ExecuteQuery();

			TXT_EDISI.Text=conn.GetFieldValue("draft_edition");
			TXT_NAME.Text=conn.GetFieldValue("draft_name");
			TXT_REVISI.Text=conn.GetFieldValue("draft_revision"); 
			TXT_TGL_BERLAKU.Text=tools.FormatDate(conn.GetFieldValue("new_date"),true);
			TXT_TGL_DIGANTI.Text=tools.FormatDate(conn.GetFieldValue("old_date"),true); 
			populateGridOutline1(req_seq);
			lbl_reqseq.Text=req_seq;
		}

		private void populateGridOutline1(string req_seq)
		{
			conn.QueryString="select * from ipps_outline where ipps_regno='"+ Request.QueryString["regno"] +"' and req_seq='"+ req_seq +"'";
			conn.ExecuteQuery();


			TXT_OUTLINENEW.Text=conn.GetFieldValue("new_outline"); 

			TXT_EXISTING.Text=conn.GetFieldValue("old_outline"); 
			TXT_REVISE.Text=conn.GetFieldValue("new_outline"); 

			if (conn.GetFieldValue("old_outline")=="")
			{
				TR_COINTAIN_NEW.Visible=true;
				TR_CONTAIN_UPDATE.Visible=false;
				TR_OUTLINE_NEW.Visible=true;
				TR_OUTLINE_UPDATE.Visible=false;
			}

			else
			{
				TR_COINTAIN_NEW.Visible=false;
				TR_CONTAIN_UPDATE.Visible=true;
				TR_OUTLINE_NEW.Visible=false;
				TR_OUTLINE_UPDATE.Visible=true;
			}

			conn.QueryString="exec IPPS_REVIEW_ONCONTAIN '" + Request.QueryString["regno"] + "', '"
								+ req_seq + "', '" + Request.QueryString["revseq"] + "'";
			conn.ExecuteQuery();

			System.Data.DataTable dt = new System.Data.DataTable();
			dt = conn.GetDataTable().Copy();

			DGR_COINTAINNEW.DataSource = dt;

			try
			{
				DGR_COINTAINNEW.DataBind();
			}
			catch
			{
				DGR_COINTAINNEW.CurrentPageIndex = DGR_COINTAINNEW.PageCount - 1;
				DGR_COINTAINNEW.DataBind();
			}


			DGR_CONTAINUPD.DataSource = dt;

			try
			{
				DGR_CONTAINUPD.DataBind();
			}
			catch
			{
				DGR_CONTAINUPD.CurrentPageIndex = DGR_CONTAINUPD.PageCount - 1;
				DGR_CONTAINUPD.DataBind();
			}

			conn.ClearData();
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
