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

namespace TestSME.CreditAnalysis
{
	/// <summary>
	/// Summary description for CA_Aspek_Middle.
	/// </summary>
	public partial class CA_Aspek_Middle : System.Web.UI.Page
	{
		protected Tools tool = new Tools();
		protected System.Web.UI.WebControls.DropDownList DropDownList2;
		protected System.Web.UI.WebControls.DropDownList DropDownList3;
		protected System.Web.UI.WebControls.DropDownList DropDownList4;
		protected Connection conn;
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			conn = (Connection) Session["Connection"];

			if (!Logic.AllowAccess(Session["GroupID"].ToString(), Request.QueryString["mc"], conn))
				Response.Redirect("/SME/Restricted.aspx");

			if(!IsPostBack)
			{
				viewPickList();
			}
			ViewMenu();
			ViewSubMenu();
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
							strtemp = "regno=" + Request.QueryString["regno"] + "&curef="+Request.QueryString["curef"]+"&tc="+Request.QueryString["tc"]+"&jnsnasabah="+Request.QueryString["jnsnasabah"]+"&programid="+Request.QueryString["programid"]+"&lmsreg="+Request.QueryString["lmsreg"];
						else	strtemp = "regno=" + Request.QueryString["regno"] + "&curef="+Request.QueryString["curef"]+"&mc="+Request.QueryString["mc"]+"&tc="+Request.QueryString["tc"]+"&jnsnasabah="+Request.QueryString["jnsnasabah"]+"&programid="+Request.QueryString["programid"]+"&lmsreg="+Request.QueryString["lmsreg"];
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
				//string programid = (string) Session["programid"];
				//string jnsnasabah = (string) Session["jnsnasabah"];

				conn.QueryString = "select distinct top 1 cu_jnsnasabah from customer where cu_ref in (Select cu_ref from application where ap_regno = '"+Request.QueryString["regno"]+ "')";
				conn.ExecuteQuery();
				string jnsnasabah = conn.GetFieldValue("cu_jnsnasabah").ToString();
				
				conn.QueryString = "select distinct top 1 programid from rfprogram where programid in (select prog_code from application where ap_regno = '"+Request.QueryString["regno"]+ "')";
				conn.ExecuteQuery();
				string programid = conn.GetFieldValue("programid").ToString();

				conn.QueryString = "select * from screensubmenu where lg_code in (select distinct lg_code " + 
					"from rfcafinstatement " + 
					"where programid = '" + programid + 
					"' and nasabahid = '" + jnsnasabah + 
					"') and menucode = '" + Request.QueryString["mc"] + 
					"' and programid = '" + programid +"'";
				conn.ExecuteQuery();

				for (int i = 0; i < conn.GetRowCount(); i++) 
				{
					HyperLink t = new HyperLink();
					t.Text = conn.GetFieldValue(i, 4);
					string strtemp = "";
					//strtemp = "regno=" + Request.QueryString["regno"] + "&mc="+Request.QueryString["mc"]+"&jnsnasabah="+Request.QueryString["jnsnasabah"]+"&programid="+Request.QueryString["programid"];
					strtemp = "regno=" + Request.QueryString["regno"]+ "&curef="+Request.QueryString["curef"]+"&mc="+Request.QueryString["mc"]+"&jnsnasabah="+Request.QueryString["jnsnasabah"]+"&programid="+Request.QueryString["programid"]+"&lmsreg="+Request.QueryString["lmsreg"];
					t.NavigateUrl = conn.GetFieldValue(i, 5)+strtemp;
					SubMenu.Controls.Add(t);
					SubMenu.Controls.Add(new LiteralControl("&nbsp;&nbsp;&nbsp;"));
				}
			} 
			catch (Exception ex) 
			{
				string temp = ex.ToString();
			}
		}

		private void viewPickList()
		{
			DDL_MQUALITY.Items.Add(new ListItem("- PILIH -", ""));
			conn.QueryString = "select (bmr_code+cast(bmr2_code as char(1))+bmr3_code) as a, left(bmr3_desc,120),bmr3_desc from rfbmrating_III where bmr_code = 'B' and bmr2_code = '1' and bmr3_active = '1'";
			conn.ExecuteQuery();
			for (int i = 0; i < conn.GetRowCount(); i++)
				DDL_MQUALITY.Items.Add(new ListItem(conn.GetFieldValue(i,1), conn.GetFieldValue(i,0)));

			/* ------------------------------------- */
			DDL_INFDISCLOSURE.Items.Add(new ListItem("- PILIH -", ""));
			conn.QueryString = "select (bmr_code+cast(bmr2_code as char(1))+bmr3_code) as a, left(bmr3_desc,120),bmr3_desc from rfbmrating_III where bmr_code = 'B' and bmr2_code = '2' and bmr3_active = '1'";
			conn.ExecuteQuery();
			for (int i = 0; i < conn.GetRowCount(); i++)
				DDL_INFDISCLOSURE.Items.Add(new ListItem(conn.GetFieldValue(i,1), conn.GetFieldValue(i,0)));
			
			/* ------------------------------------- */
			DDL_COMPGROUP.Items.Add(new ListItem("- PILIH -", ""));
			conn.QueryString = "select (bmr_code+cast(bmr2_code as char(1))+bmr3_code) as a, left(bmr3_desc,120),bmr3_desc from rfbmrating_III where bmr_code = 'B' and bmr2_code = '3' and bmr3_active = '1'";
			conn.ExecuteQuery();
			for (int i = 0; i < conn.GetRowCount(); i++)
				DDL_COMPGROUP.Items.Add(new ListItem(conn.GetFieldValue(i,1), conn.GetFieldValue(i,0)));	
			
			/* ------------------------------------- */
			DDL_CAPSUPPORT.Items.Add(new ListItem("- PILIH -", ""));
			conn.QueryString = "select (bmr_code+cast(bmr2_code as char(1))+bmr3_code) as a, left(bmr3_desc,120),bmr3_desc from rfbmrating_III where bmr_code = 'B' and bmr2_code = '4' and bmr3_active = '1'";
			conn.ExecuteQuery();
			for (int i = 0; i < conn.GetRowCount(); i++)
				DDL_CAPSUPPORT.Items.Add(new ListItem(conn.GetFieldValue(i,1), conn.GetFieldValue(i,0)));	
			
			/* ------------------------------------- */
			DDL_MARKETSHR.Items.Add(new ListItem("- PILIH -", ""));
			conn.QueryString = "select (bmr_code+cast(bmr2_code as char(1))+bmr3_code) as a, left(bmr3_desc,120),bmr3_desc from rfbmrating_III where bmr_code = 'C' and bmr2_code = '1' and bmr3_active = '1'";
			conn.ExecuteQuery();
			for (int i = 0; i < conn.GetRowCount(); i++)
				DDL_MARKETSHR.Items.Add(new ListItem(conn.GetFieldValue(i,1), conn.GetFieldValue(i,0)));	
			
			/* ------------------------------------- */
			DDL_PRODCOMPTIVE.Items.Add(new ListItem("- PILIH -", ""));
			conn.QueryString = "select (bmr_code+cast(bmr2_code as char(1))+bmr3_code) as a, left(bmr3_desc,120),bmr3_desc from rfbmrating_III where bmr_code = 'C' and bmr2_code = '2' and bmr3_active = '1'";
			conn.ExecuteQuery();
			for (int i = 0; i < conn.GetRowCount(); i++)
				DDL_PRODCOMPTIVE.Items.Add(new ListItem(conn.GetFieldValue(i,1), conn.GetFieldValue(i,0)));	

			/* ------------------------------------- */
			DDL_COSTEFF.Items.Add(new ListItem("- PILIH -", ""));
			conn.QueryString = "select (bmr_code+cast(bmr2_code as char(1))+bmr3_code) as a, left(bmr3_desc,120),bmr3_desc from rfbmrating_III where bmr_code = 'C' and bmr2_code = '3' and bmr3_active = '1'";
			conn.ExecuteQuery();
			for (int i = 0; i < conn.GetRowCount(); i++)
				DDL_COSTEFF.Items.Add(new ListItem(conn.GetFieldValue(i,1), conn.GetFieldValue(i,0)));	

			/* ------------------------------------- */
			DDL_3RDPARTY.Items.Add(new ListItem("- PILIH -", ""));
			conn.QueryString = "select (bmr_code+cast(bmr2_code as char(1))+bmr3_code) as a, left(bmr3_desc,120),bmr3_desc from rfbmrating_III where bmr_code = 'C' and bmr2_code = '4' and bmr3_active = '1'";
			conn.ExecuteQuery();
			for (int i = 0; i < conn.GetRowCount(); i++)
				DDL_3RDPARTY.Items.Add(new ListItem(conn.GetFieldValue(i,1), conn.GetFieldValue(i,0)));	
			
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

		protected void DDL_MQUALITY_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			conn.QueryString = "Select bmr3_desc from rfbmrating_III where bmr_code = '" + DDL_MQUALITY.SelectedItem.Value.Substring(0,1) + "' and bmr2_code = '" + DDL_MQUALITY.SelectedItem.Value.Substring(1,1) + "' and bmr3_code = '" + DDL_MQUALITY.SelectedItem.Value.Substring(2,1) + "'";
			conn.ExecuteQuery();
			TXT_MQUALITY.Text = conn.GetFieldValue("bmr3_desc").ToString();
		}

		protected void DDL_INFDISCLOSURE_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			conn.QueryString = "Select bmr3_desc from rfbmrating_III where bmr_code = '" + DDL_INFDISCLOSURE.SelectedItem.Value.Substring(0,1) + "' and bmr2_code = '" + DDL_INFDISCLOSURE.SelectedItem.Value.Substring(1,1) + "' and bmr3_code = '" + DDL_INFDISCLOSURE.SelectedItem.Value.Substring(2,1) + "'";
			conn.ExecuteQuery();
			TXT_INFDISCLOSURE.Text = conn.GetFieldValue("bmr3_desc").ToString();
		}

		protected void DDL_COMPGROUP_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			conn.QueryString = "Select bmr3_desc from rfbmrating_III where bmr_code = '" + DDL_COMPGROUP.SelectedItem.Value.Substring(0,1) + "' and bmr2_code = '" + DDL_COMPGROUP.SelectedItem.Value.Substring(1,1) + "' and bmr3_code = '" + DDL_COMPGROUP.SelectedItem.Value.Substring(2,1) + "'";
			conn.ExecuteQuery();
			TXT_COMPGROUP.Text = conn.GetFieldValue("bmr3_desc").ToString();
		}

		protected void DDL_CAPSUPPORT_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			conn.QueryString = "Select bmr3_desc from rfbmrating_III where bmr_code = '" + DDL_CAPSUPPORT.SelectedItem.Value.Substring(0,1) + "' and bmr2_code = '" + DDL_CAPSUPPORT.SelectedItem.Value.Substring(1,1) + "' and bmr3_code = '" + DDL_CAPSUPPORT.SelectedItem.Value.Substring(2,1) + "'";
			conn.ExecuteQuery();
			TXT_CAPSUPPORT.Text = conn.GetFieldValue("bmr3_desc").ToString();
		}

		protected void DDL_MARKETSHR_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			conn.QueryString = "Select bmr3_desc from rfbmrating_III where bmr_code = '" + DDL_MARKETSHR.SelectedItem.Value.Substring(0,1) + "' and bmr2_code = '" + DDL_MARKETSHR.SelectedItem.Value.Substring(1,1) + "' and bmr3_code = '" + DDL_MARKETSHR.SelectedItem.Value.Substring(2,1) + "'";
			conn.ExecuteQuery();
			TXT_MARKETSHR.Text = conn.GetFieldValue("bmr3_desc").ToString();
		}

		protected void DDL_PRODCOMPTIVE_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			conn.QueryString = "Select bmr3_desc from rfbmrating_III where bmr_code = '" + DDL_PRODCOMPTIVE.SelectedItem.Value.Substring(0,1) + "' and bmr2_code = '" + DDL_PRODCOMPTIVE.SelectedItem.Value.Substring(1,1) + "' and bmr3_code = '" + DDL_PRODCOMPTIVE.SelectedItem.Value.Substring(2,1) + "'";
			conn.ExecuteQuery();
			TXT_PRODCOMPTIVE.Text = conn.GetFieldValue("bmr3_desc").ToString();
		}

		protected void DDL_COSTEFF_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			conn.QueryString = "Select bmr3_desc from rfbmrating_III where bmr_code = '" + DDL_COSTEFF.SelectedItem.Value.Substring(0,1) + "' and bmr2_code = '" + DDL_COSTEFF.SelectedItem.Value.Substring(1,1) + "' and bmr3_code = '" + DDL_COSTEFF.SelectedItem.Value.Substring(2,1) + "'";
			conn.ExecuteQuery();
			TXT_COSTEFF.Text = conn.GetFieldValue("bmr3_desc").ToString();
		}

		protected void DDL_3RDPARTY_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			conn.QueryString = "Select bmr3_desc from rfbmrating_III where bmr_code = '" + DDL_3RDPARTY.SelectedItem.Value.Substring(0,1) + "' and bmr2_code = '" + DDL_3RDPARTY.SelectedItem.Value.Substring(1,1) + "' and bmr3_code = '" + DDL_3RDPARTY.SelectedItem.Value.Substring(2,1) + "'";
			conn.ExecuteQuery();
			TXT_3RDPARTY.Text = conn.GetFieldValue("bmr3_desc").ToString();
		}

		
	}
}