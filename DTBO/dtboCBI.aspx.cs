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

namespace SME.DTBO
{
	/// <summary>
	/// Summary description for dtbo.
	/// </summary>
	public partial class dtboCBI : System.Web.UI.Page
	{
		//protected Connection conn = new Connection("Data Source=localhost;Initial Catalog=SME;uid=sa;pwd=");
		//protected Connection conn = new Connection("Data Source=10.123.12.30;Initial Catalog=SMEDEV;uid=sa;pwd=");
		protected Tools tool = new Tools();
		protected System.Web.UI.WebControls.Button BTN_SAVE;
		protected Connection conn;

		protected void Page_Load(object sender, System.EventArgs e)
		{
			conn = (Connection) Session["Connection"];

			if (!Logic.AllowAccess(Session["GroupID"].ToString(), Request.QueryString["mc"], conn))
				Response.Redirect("/SME/Restricted.aspx");

			if (!IsPostBack)
			{
				LBL_REGNO.Text = Request.QueryString["regno"];
				LBL_CUREF.Text = Request.QueryString["curef"];
				LBL_TC.Text = Request.QueryString["tc"];
				LBL_DTBO.Text = Request.QueryString["dtbo"];

				conn.QueryString = "select case when CU_JNSNASABAH = 'A' then CU_JNSNASABAH else 'B' end CU_JNSNASABAH from customer where cu_ref = '"+LBL_CUREF.Text+"'";
				conn.ExecuteQuery();
				string jnsnasabah = conn.GetFieldValue("CU_JNSNASABAH");
				conn.QueryString = "exec DTBO_MDTRY '"+ LBL_REGNO.Text +"', '"+ LBL_CUREF.Text +"','"+ jnsnasabah +"' ";
				conn.ExecuteNonQuery();
				ViewData();

				HyperLink h1 = new HyperLink();
				h1.Text = "Dokumen Umum";
				h1.Font.Bold = true;
				h1.NavigateUrl = "DocUmum.aspx?regno="+ LBL_REGNO.Text +"&curef="+ LBL_CUREF.Text +"&tc="+ LBL_TC.Text + "&dtbo=" + LBL_DTBO.Text;
				h1.Target = "IFR_DTBO";

				HyperLink h2 = new HyperLink();
				h2.Text = "Dokumen Fasilitas";
				h2.Font.Bold = true;
				h2.NavigateUrl = "DocFasilitas.aspx?regno="+ LBL_REGNO.Text +"&curef="+ LBL_CUREF.Text +"&tc="+ LBL_TC.Text + "&dtbo=" + LBL_DTBO.Text;
				h2.Target = "IFR_DTBO";

				HyperLink h3 = new HyperLink();
				h3.Text = "Dokumen Jaminan";
				h3.Font.Bold = true;
				h3.NavigateUrl = "DocJaminan.aspx?regno="+ LBL_REGNO.Text +"&curef="+ LBL_CUREF.Text +"&tc="+ LBL_TC.Text + "&dtbo=" + LBL_DTBO.Text;
				h3.Target = "IFR_DTBO";

				PLH_DTBO.Controls.Add(h1);
				PLH_DTBO.Controls.Add(new LiteralControl("&nbsp;&nbsp;"));
				PLH_DTBO.Controls.Add(h2);
				PLH_DTBO.Controls.Add(new LiteralControl("&nbsp;&nbsp;"));
				PLH_DTBO.Controls.Add(h3);
				PLH_DTBO.Controls.Add(new LiteralControl("&nbsp;&nbsp;"));
			}
			secureData();
			ViewMenu();
			ImageButton1.Click += new ImageClickEventHandler(ImageButton1_Click);
			BTN_UPDATESTATUS.Click +=new EventHandler(BTN_UPDATESTATUS_Click);
			BTN_UPDATESTATUS.Attributes.Add("onclick","if(!update()){return false;};");
		}

		private void secureData() 
		{
			conn.QueryString = "select * from VW_DTBO_CEK where TRACKCODE = '" +Request.QueryString["tc"]+ "'";
			conn.ExecuteQuery();

			//if (Request.QueryString["tc"] != "1.3") 
			if (conn.GetFieldValue("ISDTBO") == "0")
			{
				BTN_UPDATESTATUS.Visible = false;
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
						if (conn.GetFieldValue(i,3).IndexOf("?dtbo=") < 0 && conn.GetFieldValue(i,3).IndexOf("&dtbo=") < 0)
							strtemp = strtemp + "&dtbo=" + Request.QueryString["dtbo"];
						//t.ForeColor = Color.MidnightBlue; aaaaa
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

		private void ViewData()
		{
			conn.QueryString = "select * from VW_DTBOCUINFO "+
				"where ap_regno = '"+ LBL_REGNO.Text +"'";
			conn.ExecuteQuery();
			
			TXT_BRANCH_NAME.Text = conn.GetFieldValue("BR_NAME");
			TXT_AP_RELMNGR.Text = conn.GetFieldValue("AP_RELMNGRNM");
			TXT_CU_NAME.Text = conn.GetFieldValue("CU_NAME");
			TXT_SU_FULLNAME.Text = conn.GetFieldValue("AP_TL");
			TXT_BU.Text = conn.GetFieldValue("AP_BU");
			TXT_AP_REGNO.Text = conn.GetFieldValue("AP_REGNO");
			TXT_AP_SIGNDATE.Text = tool.FormatDate_GetDate(conn.GetFieldValue("AP_SIGNDATE"));
			TXT_PROGRAMDESC.Text = conn.GetFieldValue("PROG_DESC");
		}

		private void BTN_UPDATESTATUS_Click(object sender, System.EventArgs e)
		{
			//// added by nyoman for document tracking   ////
			conn.QueryString = "exec DTBO_UPDSTA_DOCTRACK '" + 
				Request.QueryString["regno"] + "', '" +
				Request.QueryString["tc"] + "', '" +
				(string)Session["UserID"] + "'";
			conn.ExecuteNonQuery();
			/////////////////////////////////////////////////

			conn.QueryString = "select apptype, productid, PROD_SEQ from custproduct where ap_regno='" + Request.QueryString["regno"] + "'";
			conn.ExecuteQuery();
			DataTable data = new DataTable();
			data = conn.GetDataTable().Copy();
			
			for (int i = 0; i < data.Rows.Count; i++)
			{
				conn.QueryString = "exec TRACKUPDATE '" + 
					Request.QueryString["regno"] + "', '" +
					data.Rows[i]["productid"].ToString() + "', '" + 
					data.Rows[i]["apptype"].ToString() + "', '" + 
					//(string)Session["UserID"] + "', '" + 
					Session["UserID"].ToString() + "', '" + 
					data.Rows[i]["PROD_SEQ"].ToString() + "','"+Request.QueryString["tc"].Trim()+"'";
				conn.ExecuteNonQuery();
			}

			string msg = getNextStepMsg(LBL_REGNO.Text);
			Response.Redirect("ListDTBO.aspx?tc=" + Request.QueryString["tc"] + "&mc=" + Request.QueryString["mc"] + "&msg=" + msg);
		}

		private void ImageButton1_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			if (Request.QueryString["tc"] != "" && Request.QueryString["tc"] != null)
				Response.Redirect("/SME/" + DMS.CuBESCore.Logic.backLink(Request.QueryString["tc"].ToString(), conn));
			else 
				Response.Write("<script language='javascript'>history.back(-1);</script>");
		}	
	}
}

