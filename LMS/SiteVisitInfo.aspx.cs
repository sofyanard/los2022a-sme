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

namespace SME.LMS
{
	/// <summary>
	/// Summary description for SiteVisitInfo.
	/// </summary>
	public partial class SiteVisitInfo : System.Web.UI.Page
	{
		protected Connection conn;
		private string regno, curef;
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			conn = (Connection) Session["Connection"];

			if (!Logic.AllowAccess(Session["GroupID"].ToString(), Request.QueryString["mc"], conn))
				Response.Redirect("../Restricted.aspx");

			if (!IsPostBack)
			{
				ViewData();
			}

			ViewMenu();
		}

		private void ViewMenu()
		{
			try 
			{
				conn.QueryString = "select * from SCREENMENU where menucode = '"+Request.QueryString["mc"]+"'";
				conn.ExecuteQuery();

				string mc1 = Request.QueryString["mc"];
				string mc2 = Request.QueryString["mc"];
				for (int i = 0; i < conn.GetRowCount(); i++) 
				{
					HyperLink t = new HyperLink();
					t.Text = conn.GetFieldValue(i, 2);
					t.Font.Bold = true;
					string strtemp = "";
					if (conn.GetFieldValue(i, 3).Trim()!= "") 
					{
						if (conn.GetFieldValue(i,3).IndexOf("mc=") >= 0)
							strtemp = "lmsreg="+Request.QueryString["lmsreg"]+"&scr="+Request.QueryString["scr"];
						else	strtemp = "lmsreg="+Request.QueryString["lmsreg"]+"&mc="+Request.QueryString["mc"]+"&scr="+Request.QueryString["scr"];
						//t.ForeColor = Color.MidnightBlue; 
					}
					else 
					{
						strtemp = "";
						t.ForeColor = Color.Red; 
					}
					t.NavigateUrl = conn.GetFieldValue(i, 3)+strtemp;
					Menu.Controls.Add(t);
					Menu.Controls.Add(new LiteralControl("&nbsp;&nbsp;&nbsp;"));
				}
			} 
			catch (Exception ex) 
			{
				string temp = ex.ToString();
			}
		}

		private void ViewData()
		{
			conn.QueryString = "SELECT * FROM VW_LMS_SITEVISITINFO WHERE LMS_REGNO = '" + Request.QueryString["lmsreg"] + "'";
			conn.ExecuteQuery();

			DataTable dt = new DataTable();
			dt = conn.GetDataTable().Copy();
			DG_SITEVISIT.DataSource = dt;
			try 
			{
				DG_SITEVISIT.DataBind();
			}
			catch 
			{
				DG_SITEVISIT.CurrentPageIndex = 0;
				DG_SITEVISIT.DataBind();
			}

			for (int i=0;i<DG_SITEVISIT.Items.Count;i++)
			{
				LinkButton lbdel = (LinkButton)DG_SITEVISIT.Items[i].Cells[6].FindControl("LB_DELETE");
				lbdel.Attributes.Add("onclick","if(!deleteconfirm()){return false;};");
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
			this.DG_SITEVISIT.ItemCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.DG_SITEVISIT_ItemCommand);
			this.DG_SITEVISIT.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.DG_SITEVISIT_PageIndexChanged);

		}
		#endregion

		private void DG_SITEVISIT_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			switch (((LinkButton)e.CommandSource).CommandName)
			{
				case "view":
					string url = e.Item.Cells[5].Text + "&lmsreg=" + Request.QueryString["lmsreg"] + "&mc=" + Request.QueryString["mc"] + "&scr=" + Request.QueryString["scr"] + "&lkkn=" + Request.QueryString["lkkn"];
					Response.Redirect(url);
					break;

				case "delete":
					try
					{
						conn.QueryString = "EXEC LMS_SITEVISITINFO_DELETEVISIT '" +
							e.Item.Cells[0].Text + "'";
						conn.ExecuteNonQuery();

						ViewData();
					}
					catch (Exception ex)
					{
						Response.Write("<!--" + ex.ToString() + "-->");
						string errmsg = ex.Message.Replace("'","");
						if (errmsg.IndexOf("Last Query:") > 0)
							errmsg = errmsg.Substring(0, errmsg.IndexOf("Last Query:"));
						GlobalTools.popMessage(this, errmsg);
						return;
					}
					break;

				default:
					break;
			}
		}

		protected void BTN_BACK_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			string url = "SearchCustomer.aspx?mc=" + Request.QueryString["mc"];
			if (Request.QueryString["tc"] != "")
			{
				url = url + "&tc=" + Request.QueryString["tc"];
			}
			if (Request.QueryString["scr"] != "")
			{
				url = url + "&scr=" + Request.QueryString["scr"];
			}
			Response.Redirect(url);
		}

		protected void BTN_NEW_Click(object sender, System.EventArgs e)
		{
			try
			{
				conn.QueryString = "exec LMS_SITEVISITINFO_NEWVISIT '" + 
					Request.QueryString["lmsreg"] + "', '" +
					Session["UserID"].ToString() + "'";
				conn.ExecuteQuery();

				string url = conn.GetFieldValue(0,0) + "&lmsreg=" + Request.QueryString["lmsreg"] + "&mc=" + Request.QueryString["mc"] + "&scr=" + Request.QueryString["scr"] + "&lkkn=" + Request.QueryString["lkkn"];
				Response.Redirect(url);
			}
			catch (Exception ex)
			{
				Response.Write("<!--" + ex.Message + "-->");
				string errmsg = ex.Message.Replace("'","");
				if (errmsg.IndexOf("Last Query:") > 0)
					errmsg = errmsg.Substring(0, errmsg.IndexOf("Last Query:"));
				GlobalTools.popMessage(this, errmsg);
				return;
			}
		}

		private void DG_SITEVISIT_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			DG_SITEVISIT.CurrentPageIndex = e.NewPageIndex;
			ViewData();
		}
	}
}
