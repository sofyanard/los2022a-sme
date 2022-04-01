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

namespace SME.LMS
{
	/// <summary>
	/// Summary description for KinerjaKeuangan.
	/// </summary>
	public partial class KinerjaKeuangan : System.Web.UI.Page
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
			ViewSubMenu();
		}

		private void ViewData()
		{
			ViewDataApplication();

			////////////////////////////////////////////////////////////////
			/// menaruh programid dan jenisnasabah di session untuk
			/// kebutuhan submenu
			/// 				
			string vjnsnasabah; 
			string vprgid;
					
			conn.QueryString = "select distinct top 1 cu_jnsnasabah from customer where cu_ref in (Select cu_ref from application where ap_regno = '" + regno + "')";
			conn.ExecuteQuery();
			vjnsnasabah = conn.GetFieldValue("cu_jnsnasabah").ToString();
					
			conn.QueryString = "select distinct top 1 programid from rfprogram where programid in (select prog_code from application where ap_regno = '" + regno + "')";
			conn.ExecuteQuery();
			vprgid = conn.GetFieldValue("programid").ToString();
					
			Session.Add("programid", vprgid);
			Session.Add("jnsnasabah", vjnsnasabah);					
			//////////////////////////////////////////////////////////////////
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

		private void ViewSubMenu()
		{
			try 
			{
				string sProgramID,sJnsNasabah;

				conn.QueryString = "select distinct top 1 cu_jnsnasabah from customer where cu_ref in (Select cu_ref from application where ap_regno = '" + regno + "')";
				conn.ExecuteQuery();
				sJnsNasabah = conn.GetFieldValue("cu_jnsnasabah").ToString();
				//------------------------------------------------------------------------------
					
				conn.QueryString = "select distinct top 1 programid from rfprogram where programid in (select prog_code from application where ap_regno = '" + regno + "')";
				conn.ExecuteQuery();
				sProgramID = conn.GetFieldValue("programid").ToString();

				//conn.QueryString = "select * from screensubmenu where lg_code in (select distinct lg_code from rfcafinstatement where programid = '"+Request.QueryString["programid"]+"' and nasabahid = '" +Request.QueryString["jnsnasabah"]+"') and menucode = '" +Request.QueryString["mc"]+ "' and programid = '"+Request.QueryString["programid"]+"'";
				conn.QueryString = "select * from screensubmenu where lg_code in (select distinct lg_code from rfcafinstatement where programid = '"+sProgramID+"' and nasabahid = '" +sJnsNasabah+"') and menucode = '" +Request.QueryString["mc"]+ "' and programid = '"+sProgramID+"'";
				conn.ExecuteQuery();
				for (int i = 0; i < conn.GetRowCount(); i++) 
				{
					HyperLink t = new HyperLink();
					t.Text = conn.GetFieldValue(i, 4);
					string strtemp = "";
					strtemp = "regno=" + regno + 
						"&curef=" + curef +
						"&mc=" + Request.QueryString["mc"] +
						"&jnsnasabah=" + sJnsNasabah +
						"&programid=" + sProgramID +
						"&tc="+Request.QueryString["tc"]+
						"&ca="+Request.QueryString["ca"]+
						"&lmsreg="+Request.QueryString["lmsreg"]+
						"&scr="+Request.QueryString["scr"];
					t.NavigateUrl = conn.GetFieldValue(i, 5)+strtemp;
					SubMenu.Controls.Add(t);
					SubMenu.Controls.Add(new LiteralControl("&nbsp;&nbsp;&nbsp;"));
				}
			} 
			catch (NullReferenceException)
			{
				Tools.popMessage(this, "Connection Error !");
				return;
			}
		}

		private void ViewDataApplication()
		{
			//get LOS application no
			conn.QueryString = "EXEC LMS_KINERJAKEUANGAN_GETLOSAPP '" + Request.QueryString["lmsreg"] + "'";
			conn.ExecuteQuery();

			curef = conn.GetFieldValue("CU_REF");
			regno = conn.GetFieldValue("AP_REGNO");
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
	}
}
