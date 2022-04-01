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
using DMS.DBConnection;
using DMS.CuBESCore;

namespace SME.DataEntry
{
	/// <summary>
	/// Summary description for jaminan_detail.
	/// </summary>
	public partial class jaminan_detail : System.Web.UI.Page
	{
		protected Connection conn;
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			conn = (Connection) Session["Connection"];

			if (Request.QueryString["de"] == "1")
				if (!Logic.AllowAccess(Session["GroupID"].ToString(), Request.QueryString["mc"], conn))
					Response.Redirect("/SME/Restricted.aspx");


			ViewMenu();
			if (Request.QueryString["tc"] == "" || 
				Request.QueryString["tc"] == null || 
				Request.QueryString["tc"] == "&nbsp;") 
			{
				TR_SUBMENU.Visible = true;
				viewSubMenu();
			}
			else
				TR_SUBMENU.Visible = false;

			initEvents();
		}

		private void initEvents() 
		{
			BTN_BACK.Click += new ImageClickEventHandler(BTN_BACK_Click);
		}

		private void viewSubMenu() 
		{
			try 
			{
				conn.QueryString = "select * from SCREENSUBMENU where menucode = '"+Request.QueryString["mc"]+"'";
				conn.ExecuteQuery();

				for (int i = 0; i < conn.GetRowCount(); i++) 
				{
					HyperLink t = new HyperLink();
					t.Text = conn.GetFieldValue(i, "SM_MENUDISPLAY");
					t.Font.Bold = true;
					string strtemp = "";
					if (conn.GetFieldValue(i, "SM_LINKNAME").Trim()!= "") 
					{						
						if (conn.GetFieldValue(i,"SM_LINKNAME").IndexOf("mc=") >= 0)
							strtemp = "regno=" + Request.QueryString["regno"] + "&curef="+Request.QueryString["curef"]+"&tc="+Request.QueryString["tc"];
						else	
							strtemp = "regno=" + Request.QueryString["regno"] + "&curef="+Request.QueryString["curef"]+"&mc="+Request.QueryString["mc"]+"&tc="+Request.QueryString["tc"];

						if (conn.GetFieldValue(i,"SM_LINKNAME").IndexOf("?de=") < 0 && conn.GetFieldValue(i, "SM_LINKNAME").IndexOf("&de=") < 0) 
							strtemp = strtemp + "&de=" + Request.QueryString["de"];	

						if (conn.GetFieldValue(i,"SM_LINKNAME").IndexOf("?par=") < 0 && conn.GetFieldValue(i, "SM_LINKNAME").IndexOf("&par=") < 0)  
							strtemp = strtemp + "&par=" + Request.QueryString["par"];

						if (conn.GetFieldValue(i,"SM_LINKNAME").IndexOf("?new=") < 0 && conn.GetFieldValue(i, "SM_LINKNAME").IndexOf("&new=") < 0) 
							strtemp = strtemp + "&new=" + Request.QueryString["new"];
					}
					else 
					{
						strtemp = "";
						t.ForeColor = Color.Red; 
					}
					t.NavigateUrl = conn.GetFieldValue(i, "SM_LINKNAME")+strtemp;					
					PH_SUBMENU.Controls.Add(t);
					PH_SUBMENU.Controls.Add(new LiteralControl("&nbsp;&nbsp;&nbsp;"));
				}
			} 
			catch (Exception ex) 
			{
				string temp = ex.ToString();
			}
		}

		private void ViewMenu()
		{
			try 
			{
				conn.QueryString = "select * from SCREENMENU where menucode = '"+Request.QueryString["mc"]+"'";
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
							strtemp = "regno=" + Request.QueryString["regno"] + "&curef="+Request.QueryString["curef"]+"&tc="+Request.QueryString["tc"];
						else	strtemp = "regno=" + Request.QueryString["regno"] + "&curef="+Request.QueryString["curef"]+"&mc="+Request.QueryString["mc"]+"&tc="+Request.QueryString["tc"];
						if (conn.GetFieldValue(i,3).IndexOf("?de=") < 0 && conn.GetFieldValue(i,3).IndexOf("&de=") < 0) 
							strtemp = strtemp + "&de=" + Request.QueryString["de"];	
						if (conn.GetFieldValue(i,3).IndexOf("?par=") < 0 && conn.GetFieldValue(i,3).IndexOf("&par=") < 0)  
							strtemp = strtemp + "&par=" + Request.QueryString["par"];

						//t.ForeColor = Color.MidnightBlue; 
						/*
						if (conn.GetFieldValue(i,3).IndexOf("de=") < 0) strtemp = strtemp + "&de=" + Request.QueryString["de"];
						strtemp = strtemp + "&par=" + Request.QueryString["par"];
						*/
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

		private void BTN_BACK_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			string backlink = DMS.CuBESCore.Logic.backLink(Request.QueryString["tc"].ToString(), Request.QueryString["mc"].ToString(), conn);

			if (Request.QueryString["par"] != null && Request.QueryString["par"] != "") 
				Response.Redirect(Request.QueryString["par"] + "&regno=" + Request.QueryString["regno"] + "&curef=" + Request.QueryString["curef"] + "&tc=" + Request.QueryString["tc"]);
			else
				Response.Redirect("/SME/" + backlink);							
		}
	}
}
