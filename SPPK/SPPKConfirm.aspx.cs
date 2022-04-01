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
using Earmarking;

namespace SME.SPPK
{
	/// <summary>
	/// Summary description for SPPKConfirm.
	/// </summary>
	public partial class SPPKConfirm : System.Web.UI.Page
	{
		protected Connection conn;
		protected Tools tool = new Tools();	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			conn = (Connection) Session["Connection"];

			if (!Logic.AllowAccess(Session["GroupID"].ToString(), Request.QueryString["mc"], conn))
				Response.Redirect("/SME/Restricted.aspx");
			
			if (!IsPostBack)
			{
				ViewData();
			}
			ViewMenu();

			//chk_cancel.Attributes.Add("onclick", "cancelStatus();");
			btn_cancel.Attributes.Add("onclick", "if(!cek_mandatory(document.Form1)){return false;};");
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
			lbl_regno.Text		= Request.QueryString["regno"];
			lbl_curef.Text		= Request.QueryString["curef"];
			lbl_prod.Text		= Request.QueryString["prod"];
			lbl_track.Text		= Request.QueryString["tc"];
			lbl_userid.Text		= Session["USERID"].ToString();

			ddl_reason.Items.Add(new ListItem("-- Pilih --",""));
			conn.QueryString = "select * from RFREASON where REASONTYPE = '1' and active = '1'";
			conn.ExecuteQuery();
			for (int i = 0; i < conn.GetRowCount();i++)
				ddl_reason.Items.Add(new ListItem(conn.GetFieldValue(i,2),conn.GetFieldValue(i,0)));

			conn.QueryString = "select ISNULL(AP_ACQINFOBY,'') as AP_ACQINFOBY, AP_COMPLEVEL from APPLICATION where AP_REGNO = '"+Request.QueryString["regno"]+"'";
			conn.ExecuteQuery();
			string ISACQINFO = conn.GetFieldValue(0,0).ToString().Trim();
			if (ISACQINFO != "")
			{
				tbl_acqinfo.Visible = true;
			}
			else
			{
				tbl_acqinfo.Visible = false;
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

		protected void btn_cancel_Click(object sender, System.EventArgs e)
		{
			if (ddl_reason.SelectedValue == "") 
			{
				GlobalTools.popMessage(this, "Cancel Reason tidak boleh kosong!");
				return;
			}

			/// Cancel Application and track the status
			/// 
			conn.QueryString = "exec cancel_updexp '"+lbl_regno.Text+"', '"+ddl_reason.SelectedValue+"', '"+lbl_userid.Text+"'";
			conn.ExecuteQuery();

			conn.QueryString = "select * from ketentuan_kredit where ap_regno = '" + lbl_regno.Text + "'";
			conn.ExecuteQuery();
			DataTable dtk = conn.GetDataTable().Copy();

			////////////////////////////////////////////////////////////////////////////////////////////////
			/// For the sake of safety, check first whether it needs
			/// earmarking or not
			/// 
			for(int i=0; i<dtk.Rows.Count; i++) 
			{
				conn.QueryString = "exec EARMARK_CEK '" + 
					lbl_regno.Text + "', '" + 
					dtk.Rows[i]["ket_code"].ToString() + "'";
				conn.ExecuteQuery();
				if (conn.GetFieldValue("NEED_EARMARK") == "1") 
				{
					try 
					{
						/// Reverse Earmark
						/// 
						Earmarking.Earmarking.reverseEarmark(lbl_regno.Text, dtk.Rows[i]["ket_code"].ToString(), conn);			

						conn.ExecTran_Commit();
					} 
					catch (Exception ex) 
					{
						if (conn != null) conn.ExecTran_Rollback();
						ExceptionHandling.Handler.saveExceptionIntoWindowsLog(ex, Request.Path, lbl_regno.Text);
					}
				}
			}
			//////////////////////////////////////////////////////////////////////////////////


			ViewData();	

			string msg = "Application is cancelled";
			Response.Redirect("ListSPPKConfirm.aspx?tc=" + lbl_track.Text + "&mc=" + Request.QueryString["mc"] + "&msg=" + msg);
		}

		protected void BTN_BACK_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			Response.Redirect("/SME/" + DMS.CuBESCore.Logic.backLink(Request.QueryString["tc"].ToString(), Request.QueryString["mc"].ToString(), conn));
		}
	}
}
