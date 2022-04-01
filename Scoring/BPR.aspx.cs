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
	public partial class MainBPR : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.TextBox TXT_AP_RELMNGR;
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.Label Label2;
		protected System.Web.UI.WebControls.TextBox Textbox6;
		protected System.Web.UI.WebControls.Label Label3;
		protected System.Web.UI.WebControls.TextBox txt_AP_REGNO;
		protected System.Web.UI.WebControls.TextBox txt_PROGRAMDESC;
		protected System.Web.UI.WebControls.TextBox txt_BRANCH_NAME;
		protected System.Web.UI.WebControls.TextBox txt_AP_SALESAGENCY;
		protected System.Web.UI.WebControls.TextBox txt_AP_SALESSUPERV;
		protected System.Web.UI.WebControls.TextBox txt_AP_SALESEXEC;
		protected System.Web.UI.WebControls.TextBox txt_AP_SRCCODE;
		protected System.Web.UI.WebControls.Button barcode;
		//protected Connection conn = new Connection("Data Source=10.123.12.30;Initial Catalog=SMEDEV;uid=sa;pwd=");
		protected Connection conn;
		protected System.Web.UI.WebControls.DataGrid DatGrd;
		protected System.Web.UI.WebControls.DropDownList ddl_PRODUCTID;
		protected System.Web.UI.WebControls.DropDownList ddl_APPTYPE;
		protected System.Web.UI.WebControls.Button BTN_INSERT;
		protected System.Web.UI.WebControls.TextBox TXT_AP_DATALNGKP_DAY;
		protected System.Web.UI.WebControls.DropDownList DDL_AP_DATALNGKP_MONTH;
		protected System.Web.UI.WebControls.TextBox TXT_AP_DATALNGKP_YEAR;
		protected System.Web.UI.WebControls.TextBox TXT_AP_RECVDATE_DAY;
		protected System.Web.UI.WebControls.DropDownList DDL_AP_RECVDATE_MONTH;
		protected System.Web.UI.WebControls.TextBox TXT_AP_RECVDATE_YEAR;
		protected System.Web.UI.WebControls.CompareValidator BPRTOTAL_VALID;
		protected System.Web.UI.WebControls.RequiredFieldValidator BPRBMRATING_VALID;
		protected System.Web.UI.WebControls.ValidationSummary VALID_SUMMARY;
		protected Tools tool = new Tools();
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			conn = (Connection) Session["Connection"];
			if (!Logic.AllowAccess(Session["GroupID"].ToString(), Request.QueryString["mc"], conn))
				Response.Redirect("/SME/Restricted.aspx");
			if (!IsPostBack)
			{
				this.fillDropDown();
				ViewData();
			}
			SecureData();
			ViewMenu();
			updatestatus.Attributes.Add("onclick", "if(!update()) { return false; };");
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
			this.updatestatus.Click += new EventHandler(updatestatus_Click);
			this.BTN_SAVE.Click +=new EventHandler(BTN_SAVE_Click);
		}
		#endregion

		private void fillDropDown() 
		{
			this.DDL_SR_BPRBMRATING.Items.Add(new ListItem("- PILIH -", ""));
			conn.QueryString = "select * from RFKONDISI where ACTIVE = '1'";
			conn.ExecuteQuery();

			for(int i=0; i<conn.GetRowCount(); i++) 
			{
				DDL_SR_BPRBMRATING.Items.Add(new ListItem(conn.GetFieldValue(i,1), conn.GetFieldValue(i,0)));
			}
		}

		private void SecureData() 
		{
			string scr = Request.QueryString["scr"];

			if (scr == "0")
			{
				TXT_SR_BPRTOTAL.ReadOnly	= true;
				DDL_SR_BPRBMRATING.Enabled	= false;
				BTN_SAVE.Visible			= false;
			}
		}

		private void ViewData()
		{
			this.conn.QueryString = "select * from SCORERESULT where ap_regno='" + Request.QueryString["regno"] + "'";
			this.conn.ExecuteQuery();

			try 
			{
				this.TXT_SR_BPRTOTAL.Text = conn.GetFieldValue("SR_BPRTOTAL");		
			}
			catch (System.ArgumentOutOfRangeException e) 
			{				
				this.TXT_SR_BPRTOTAL.Text = "";
			}
			try 
			{
				this.DDL_SR_BPRBMRATING.SelectedValue = conn.GetFieldValue("SR_BPRBMRATING");			
			}
			catch (System.ArgumentOutOfRangeException e) 
			{
				this.DDL_SR_BPRBMRATING.SelectedValue = "PILIH";
			}
		}

		private void BTN_SAVE_Click(object sender, System.EventArgs e)
		{			
			string query = "exec SR_BPR '" + Request.QueryString["regno"] + "', " +
				"'" + this.TXT_SR_BPRTOTAL.Text + "', " +
				"'" + this.DDL_SR_BPRBMRATING.SelectedValue + "'";
			conn.QueryString = query;
			conn.ExecuteNonQuery();							
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
				Console.Write(ex.Message);
			}
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
			string msg = getNextStepMsg(Request.QueryString["regno"]);
			Response.Redirect("ListScoring.aspx?tc=" + Request.QueryString["tc"] + "&mc=" + Request.QueryString["mc"] + "&msg=" + msg);
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

		protected void ImageButton1_Click(object sender, System.Web.UI.ImageClickEventArgs e)
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
	}
}
