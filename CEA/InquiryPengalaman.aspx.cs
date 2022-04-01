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
using Microsoft.VisualBasic;
using DMS.CuBESCore;

namespace SME.CEA
{
	/// <summary>
	/// Summary description for InquiryPengalaman.
	/// </summary>
	public partial class InquiryPengalaman : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.ImageButton BTN_Back;
		protected Connection conn;
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			conn = (Connection) Session["Connection"];
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

		protected void BTN_FIND_Click(object sender, System.EventArgs e)
		{
			LoadSql();
		}

		private void LoadSql()
		{
			string kriterianya = "";
			string nama = TXT_NAMA.Text;
			string JNS_EXP = TXT_EXP.Text;
			string NoReg = TXT_REGNUM.Text;
			
			if(!nama.Equals(""))
			{
				kriterianya += " and namerekanan like '%" + nama + "%'";
			}
			if(!JNS_EXP.Equals(""))
			{
				kriterianya += " and jns_bu like '%" + JNS_EXP + "%'";
			}
			if(!NoReg.Equals(""))
			{
				kriterianya += " and rekanan_ref='" + NoReg + "'";
			}
			
			Load_ReportViewer(kriterianya);
		}

		private void BTN_Back_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			Response.Redirect("Body.aspx?mc=" + Request.QueryString["mc"]);
		}

		private void Load_ReportViewer(string kriteria)
		{
			string ReportAddr;

			conn.QueryString = "select reportaddr from app_parameter";
			conn.ExecuteQuery();
			if (conn.GetRowCount()>0)
				ReportAddr = conn.GetFieldValue(0,0);
			else
				ReportAddr  = "10.123.12.50";
			ReportViewer2.ServerUrl = "http://" + ReportAddr + "/ReportServer";
			ReportViewer2.ReportPath = "/SMEReports/RptRekananPengalaman&sql_kondisi=" + kriteria;
		}
	}
}
