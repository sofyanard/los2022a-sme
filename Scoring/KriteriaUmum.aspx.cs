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

namespace SME.Scoring
{
	/// <summary>
	/// Summary description for Main.
	/// </summary>
	public partial class MainKU : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.Label Label2;
		protected System.Web.UI.WebControls.TextBox Textbox6;
		protected System.Web.UI.WebControls.Label Label3;		
		protected System.Web.UI.WebControls.Button barcode;
		protected Connection conn;
		protected Tools tool = new Tools();
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			conn =(Connection) Session["Connection"];
			if (!Logic.AllowAccess(Session["GroupID"].ToString(), Request.QueryString["mc"], conn))
				Response.Redirect("/SME/Restricted.aspx");
			if (!IsPostBack)
			{
				ViewData();
			}
			SecureData();
			ViewMenu();			

			/// Inisialisasi event pada form
			/// 
			initEvents();

			updatestatus.Attributes.Add("onclick", "if(!update()) { return false; };");	
		}
		
		private void initEvents() 
		{
			///	Inisialiasi events pada form
			///	
			///	Hal ini dilakukan manual karena pada form terdapat frame. Form ini tidak bisa dilihat dengan mode
			///	design. Agar bisa dilihat dengan mode design, matikan dulu frame itu. Impactnya, kalau dimatikan
			///	menyebabkan event yang telah dibuat oleh .NET kadang-kadang hilang. Oleh karena itu, event
			///	dibuat secara manual.
			///	Catatan : Kasus ini juga dapat ditemukan di beberapa form yang lain.
			///	
			BTN_SAVE.Click += new EventHandler(BTN_SAVE_Click);
			updatestatus.Click += new EventHandler(updatestatus_Click);
			ImageButton1.Click += new ImageClickEventHandler(ImageButton1_Click);
		}

		private string backLinkLocal(string mc) 
		{
			try 
			{
				conn.QueryString = "select TM_LINKNAME + TM_PARSINGPARAM as BACKLINK from track_menu where menucode = '" + mc + "'";
				conn.ExecuteQuery(); 

				return conn.GetFieldValue("BACKLINK");
			}
			catch (NullReferenceException e) 
			{
				GlobalTools.popMessage(this, "Server Error!");				
				return "Login.aspx?expire=1";
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

		private void SecureData() 
		{
			string scr = Request.QueryString["scr"];

			if (scr == "0")
			{
				TXT_SR_KURISKFACTOR.ReadOnly = true;
				TXT_SR_KUTOTAL.ReadOnly = true;

				BTN_SAVE.Visible = false;
			}
		}

		private void ViewData()
		{
			conn.QueryString = "select isnull(SR_KUTOTAL,0) SR_KUTOTAL , isnull(SR_KURISKFACTOR,'') SR_KURISKFACTOR " + 
				" from SCORERESULT where AP_REGNO='" + Request.QueryString["regno"] + "'";
			conn.ExecuteQuery();
			//this.TXT_SR_KUTOTAL.Text = tool.MoneyFormat(conn.GetFieldValue("SR_KUTOTAL"));			
			this.TXT_SR_KUTOTAL.Text = conn.GetFieldValue("SR_KUTOTAL").Replace(".",",");
			this.TXT_SR_KURISKFACTOR.Text = conn.GetFieldValue("SR_KURISKFACTOR");			
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
						//strtemp = "?regno=" + Request.QueryString["regno"] + "&curef="+Request.QueryString["curef"]+"&mc="+Request.QueryString["mc"]+"&tc="+Request.QueryString["tc"];
						if (conn.GetFieldValue(i,3).IndexOf("mc=") >= 0)
							strtemp = "regno=" + Request.QueryString["regno"] + "&curef="+Request.QueryString["curef"]+"&tc="+Request.QueryString["tc"];
						else	strtemp = "regno=" + Request.QueryString["regno"] + "&curef="+Request.QueryString["curef"]+"&mc="+Request.QueryString["mc"]+"&tc="+Request.QueryString["tc"];
						if (conn.GetFieldValue(i,3).IndexOf("?scr=") < 0 && conn.GetFieldValue(i,3).IndexOf("&scr=") < 0) 
							strtemp += "&"+Request.QueryString["scr"];
						if (conn.GetFieldValue(i,3).IndexOf("?par=") < 0 && conn.GetFieldValue(i,3).IndexOf("&par=") < 0) 
							strtemp += "&"+Request.QueryString["par"];						

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

		private string getNextStepMsg(string regno) 
		{
			string pesan = "";
			string nextTrack = "";
			try 
			{
				/***
				 * Memunculkan pesan next step
				 ***/
				conn.QueryString = "exec TRACKNEXTMSG '" + regno + "'";
				conn.ExecuteQuery();
				nextTrack = conn.GetFieldValue("TRACKNAME");
				pesan = "Application proceeds to " + nextTrack;
				/***********************************/
			} 
			catch 
			{
				throw new Exception();
			}
			return pesan;
		}

		private void updatestatus_Click(object sender, System.EventArgs e)
		{
			DataTable dt;
			conn.QueryString = "select apptype, productid, PROD_SEQ from custproduct where ap_regno='" + Request.QueryString["regno"] +
				"' AND isnull(cp_reject,'0') <> '1' and isnull(cp_cancel,'0') <> '1'";
			conn.ExecuteQuery();
			dt = conn.GetDataTable().Copy();
			for (int i = 0; i < dt.Rows.Count; i++)
			{
				conn.QueryString = "exec TRACKUPDATE '" + Request.QueryString["regno"] + "', '" +
					dt.Rows[i][1].ToString() + "', '" + dt.Rows[i][0].ToString() + "', '" + Session["UserID"].ToString() + "', '" + dt.Rows[i]["PROD_SEQ"].ToString() + "','"+Request.QueryString["tc"].Trim()+"'";
				conn.ExecuteNonQuery();
			}
			// tampilkan pesan next step
			//GlobalTools.popMessage(this, getNextStepMsg(Request.QueryString["regno"]);
			string msg = getNextStepMsg(Request.QueryString["regno"]);
			Response.Redirect("ListScoring.aspx?tc=" + Request.QueryString["tc"] + "&mc=" + Request.QueryString["mc"] + "&msg=" + msg);
		}

		private void ImageButton1_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			if (Request.QueryString["tc"] != "" && 
				Request.QueryString["tc"] != null && 
				Request.QueryString["tc"] != "&nbsp;") 
			{
				Response.Redirect("/SME/" + DMS.CuBESCore.Logic.backLink(Request.QueryString["tc"].ToString(), conn));
			}		
			else 
				Response.Redirect("/SME/" + this.backLinkLocal(Request.QueryString["mc"]));
		}

		private void BTN_SAVE_Click(object sender, System.EventArgs e)
		{
			string query = "exec SR_KRITERIAUMUM '" + 
				Request.QueryString["regno"] + "', '" + 
				GlobalTools.ConvertFloat(this.TXT_SR_KUTOTAL.Text) + "', '" + 
				this.TXT_SR_KURISKFACTOR.Text + "'";
			conn.QueryString = query;
			conn.ExecuteNonQuery();	
		}
	}
}
