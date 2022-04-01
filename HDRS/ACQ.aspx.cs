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

namespace SME.HDRS
{
	/// <summary>
	/// Summary description for ACQ.
	/// </summary>
	public partial class ACQ : System.Web.UI.Page
	{
		private string theForm, theObj;
		
		protected Connection conn;
		protected Tools tool = new Tools();
		protected void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			conn = (Connection) Session["Connection"];

			if (!IsPostBack)
			{
				ViewData();
				ViewBtnSend();
			}

			if (Request.QueryString.Count > 0)
			{	
				theForm = Request.QueryString["theForm"];
				theObj = Request.QueryString["theObj"];
			}	
			
		}

		private void ViewBtnSend()
		{
			conn.QueryString = "select * from VW_HELPDESK_QA_BTN where H_HRS#='"+Request.QueryString["regnum"]+"' ";
			conn.ExecuteQuery();
			string send_to="";
			send_to=Session["UserID"].ToString();
			if (conn.GetFieldValue("TRACK")=="B2" && conn.GetFieldValue("PESAN")!="" && send_to==conn.GetFieldValue("send_to"))
				BTN_SEND.Visible = true;
				BTN_CLOSE.Visible = true;
			if (conn.GetFieldValue("TRACK")=="B1.1" && conn.GetFieldValue("PESAN")!="" && send_to==conn.GetFieldValue("send_to"))
				BTN_SEND.Visible = false;
				BTN_CLOSE.Visible = true;
		}

		private void ViewData()
		{
			conn.QueryString = "select * from VW_HELPDESK_APPTRACK_HISTORY where HTH_HRS#='"+Request.QueryString["regnum"]+"' ";
			conn.ExecuteQuery();					
			if (conn.GetFieldValue("HTH_TRACKCODE")=="B2")
				TRACK.Text = "B1.1";
			if (conn.GetFieldValue("HTH_TRACKCODE")=="B3")	
				TRACK.Text = "B2";
			if (conn.GetFieldValue("HTH_TRACKCODE")=="B1")
				TRACK.Text = "B2";

			conn.QueryString = "select * from VW_HELPDESK_APPTRACK_MASSAGE where H_HRS#='"+Request.QueryString["regnum"]+"' ";
			conn.ExecuteQuery();	
			TXT_MSG.Text = conn.GetFieldValue("PESAN");	
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

		protected void BTN_SEND_Click(object sender, System.EventArgs e)
		{			
			/*if (TRACK.Text == "B1")
			{
				conn.QueryString = "exec HELPDESK_INSERT_MASSAGE '"+
					Request.QueryString["regnum"].ToString() +"', '"+
					Session["UserID"].ToString()+"', '"+
					Request.QueryString["send_by"].ToString() +"', '"+TRACK.Text+"' , '"+
					TXT_MSG.Text +"' ";
				conn.ExecuteNonQuery();

				conn.QueryString = " exec HELPDESK_TRACKUPDATE '" +
					Request.QueryString["regnum"].ToString() +"', '"+TRACK.Text+"', '" + 
					Request.QueryString["send_by"].ToString() +"', '"+
					Session["UserID"].ToString()+" ', 'PENDING' ";	
				conn.ExecuteNonQuery();	
			}*/

			conn.QueryString = "select * from helpdesk_track_history where HTH_HRS#='"+Request.QueryString["regnum"]+"' and hth_trackcode='B2' ";
			conn.ExecuteQuery();
			int jum_B2;
			jum_B2= conn.GetRowCount();
			conn.QueryString = "select * from vw_helpdesk_apptrack_history where HTH_HRS#='"+Request.QueryString["regnum"]+"' ";
			conn.ExecuteQuery();
			string last_track;
			last_track = conn.GetFieldValue("hth_trackcode");
			if (jum_B2 >= 2 && last_track=="B2")
			{
				conn.QueryString = "exec HELPDESK_INSERT_MASSAGE '"+
					Request.QueryString["regnum"].ToString() +"', '"+
					Session["UserID"].ToString()+"', '"+
					Request.QueryString["send_by"].ToString() +"', '"+TRACK.Text+"' , '"+
					TXT_MSG.Text +"' ";
				conn.ExecuteNonQuery();

				conn.QueryString = " exec HELPDESK_TRACKUPDATE '" +
					Request.QueryString["regnum"].ToString() +"', '"+TRACK.Text+"', '" + 
					Request.QueryString["send_by"].ToString() +"', '"+
					Session["UserID"].ToString()+" ', 'PENDING' ";	
				conn.ExecuteNonQuery();	
			}

			else //if (TRACK.Text != "B1")
			{
				conn.QueryString = "exec HELPDESK_INSERT_MASSAGE '"+
					Request.QueryString["regnum"].ToString() +"', '"+
					Session["UserID"].ToString()+"', '"+
					Request.QueryString["send_to"].ToString() +"', '"+TRACK.Text+"' , '"+
					TXT_MSG.Text +"' ";
				conn.ExecuteNonQuery();

				conn.QueryString = " exec HELPDESK_TRACKUPDATE '" +
					Request.QueryString["regnum"].ToString() +"', '"+TRACK.Text+"', '" + 
					Request.QueryString["send_to"].ToString() +"', '"+
					Session["UserID"].ToString()+" ', 'PENDING' ";	
				conn.ExecuteNonQuery();	
			}	
		
			string a = "<script language='JavaScript1.2'>window.opener.document." + theForm + "." + theObj + ".value='EXIT'; ";
			string b = "window.opener.document." + theForm + ".submit(); window.close();</script>" ;
			
			
			Response.Write("<script language='JavaScript1.2'>window.opener.document." + 
				theForm + "." + theObj + ".value='EXIT'; " +
				"window.opener.document." + theForm + ".submit(); window.close();</script>");
		
			//Response.Write("<script language='JavaScript1.2'>window.close();</script>");
			
		}

		protected void BTN_CLOSE_Click(object sender, System.EventArgs e)
		{
			Response.Write("<script language='JavaScript1.2'>window.close();</script>");
		}
	}
}
