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
	/// Summary description for DataMaintenanceAuditTrail.
	/// </summary>
	public partial class DataMaintenanceAuditTrail : System.Web.UI.Page
	{
		protected Connection conn;
		protected Tools tools = new Tools();
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			conn = (Connection) Session["Connection"];
			if (!IsPostBack)
			{
				FillDates();
				FillJenisRekanan();
				FillJenisData();
				
			}
		}

		private void FillDates()
		{
			DDL_BLN1.Items.Add(new ListItem("-- PILIH --",""));
			DDL_BLN2.Items.Add(new ListItem("-- PILIH --",""));
			for (int i = 1; i <= 12; i++)
			{
				DDL_BLN1.Items.Add(new ListItem(DateAndTime.MonthName(i, false), i.ToString()));
				DDL_BLN2.Items.Add(new ListItem(DateAndTime.MonthName(i, false), i.ToString()));
			}
			TXT_TGL1.Text=DateAndTime.Today.Day.ToString();
			DDL_BLN1.SelectedValue=DateAndTime.Today.Month.ToString();
			TXT_THN1.Text=DateAndTime.Today.Year.ToString();
			TXT_TGL2.Text=DateAndTime.Today.Day.ToString();
			DDL_BLN2.SelectedValue=DateAndTime.Today.Month.ToString();
			TXT_THN2.Text=DateAndTime.Today.Year.ToString();
		}

		private void FillJenisRekanan()
		{
			DDL_JENISREKANAN.Items.Add(new ListItem("--Pilih--",""));
			conn.QueryString = "select rekananid, rekanandesc from rfjenisrekanan where active='1'";
			conn.ExecuteQuery();

			for(int i = 0; i < conn.GetRowCount(); i++)
			{
				DDL_JENISREKANAN.Items.Add(new ListItem(conn.GetFieldValue(i,1), conn.GetFieldValue(i,0)));
			}
		}

		private void FillJenisData()
		{
			DDL_JENISDATA.Items.Add(new ListItem("--Pilih--",""));
			conn.QueryString = "select jnsdataid, data_desc from REKANAN_RFAUDITJNSDATA where active=1";
			conn.ExecuteQuery();

			for(int i = 0; i < conn.GetRowCount(); i++)
			{
				DDL_JENISDATA.Items.Add(new ListItem(conn.GetFieldValue(i,1), conn.GetFieldValue(i,0)));
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

		
		private void LoadReport_Load(string jnsdata, string rekanantype, string namarekan, string tgl1, string tgl2)
		{	
			string ReportAddr="", kriterianya="", tanggal1_k="", tanggal2_k="";
			string tanggal1	= tools.ConvertDate(tgl1);
			string tanggal2	= tools.ConvertDate(tgl2);
			 
			tanggal1		= tanggal1.Replace("'","");
			tanggal2		= tanggal2.Replace("'","");

			conn.QueryString = "select reportaddr from app_parameter";
			conn.ExecuteQuery();
			if (conn.GetRowCount()>0)
				ReportAddr = conn.GetFieldValue(0,0);
			else
				ReportAddr  = "10.123.12.50";
			
			ReportViewer2.ServerUrl = "http://" + ReportAddr + "/ReportServer";
			if (!Information.IsDate(tanggal1))
			{
				tanggal1	= DateTime.Today.ToString();
				tanggal1_k = Tools.toISODate(DateTime.Today.Day.ToString(),DateTime.Today.Month.ToString() ,DateTime.Today.Year.ToString());
			}
			else
			{
				tanggal1_k = Tools.toISODate(DateTime.Parse(tanggal1.ToString()).Day.ToString(),DateTime.Parse(tanggal1.ToString()).Month.ToString(), DateTime.Parse(tanggal1.ToString()).Year.ToString());
			}
			if (!Information.IsDate(tanggal2))
			{
				tanggal2	= DateTime.Today.ToString();
				tanggal2_k = Tools.toISODate(DateTime.Today.Day.ToString(),DateTime.Today.Month.ToString() ,DateTime.Today.Year.ToString());
			}
			else
			{
				tanggal2_k = Tools.toISODate(DateTime.Parse(tanggal2.ToString()).Day.ToString(), DateTime.Parse(tanggal2.ToString()).Month.ToString(), DateTime.Parse(tanggal2.ToString()).Year.ToString());
			}
			kriterianya += "AND (convert(nvarchar, MAINTAINDATE, 112) between " + tanggal1_k + " and " + tanggal2_k + ") ";

			if (!jnsdata.Equals(""))
			{
				kriterianya += "AND (AUD_JNSDATAID = '" + jnsdata + "') ";
			}
			if (!rekanantype.Equals(""))     
			{
				kriterianya += " AND (RFREKANANTYPE = '" + rekanantype + "') ";
			}
			if (!namarekan.Equals(""))
			{
				kriterianya += "and (NAMAREKANAN = '" + namarekan + "') ";
			}
			
			
			ReportViewer2.ReportPath = "/SMEReports/RptRekananAuditTrail&kriterianya=" + kriterianya;
		}

		

		private void BTN_Back_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			Response.Redirect("ReportingListing.aspx?mc=" + Request.QueryString["mc"]);
		}

		protected void BTN_Find_Click(object sender, System.EventArgs e)
		{
			string jnsdata		= DDL_JENISDATA.SelectedValue;
			string rekanantype	= DDL_JENISREKANAN.SelectedValue;
			string namarekan	= TXT_NAMAREKAN.Text;

			string tanggal1 = "";
			string tanggal2 = "";

			if (Tools.isDateValid(this,TXT_TGL1.Text,DDL_BLN1.SelectedValue,TXT_THN1.Text)&&Tools.isDateValid(this, TXT_TGL2.Text,DDL_BLN2.SelectedValue,TXT_THN2.Text))
			{
				tanggal1 = tools.ConvertDate(TXT_TGL1.Text,DDL_BLN1.SelectedValue,TXT_THN1.Text);
				tanggal2 = tools.ConvertDate(TXT_TGL2.Text,DDL_BLN2.SelectedValue,TXT_THN2.Text);

				if (!Information.IsDate(tanggal1) || !Information.IsDate(tanggal2))
				{
					Tools.popMessage(this,"Invalid date");
					if (!Information.IsDate(tanggal1))
						Tools.SetFocus(this,TXT_TGL1);
					else
						Tools.SetFocus(this,TXT_TGL2);
				}
				else
					LoadReport_Load(jnsdata, rekanantype, namarekan, tanggal1, tanggal2);
			}
			else
			{
				Response.Write("<script language='javascript'>alert('Invalid Date !')</script>");
			}
		}

		//		private void BTN_Find_Click_1(object sender, System.EventArgs e)
		//		{
		//			string jnsdata		= DDL_JENISDATA.SelectedValue;
		//			string rekanantype	= DDL_JENISREKANAN.SelectedValue;
		//			string namarekan	= TXT_NAMAREKAN.Text;
		//
		//			string tanggal1 = "";
		//			string tanggal2 = "";
		//
		//			if (Tools.isDateValid(this,TXT_TGL1.Text,DDL_BLN1.SelectedValue,TXT_THN1.Text)&&Tools.isDateValid(this, TXT_TGL2.Text,DDL_BLN2.SelectedValue,TXT_THN2.Text))
		//			{
		//				tanggal1 = tools.ConvertDate(TXT_TGL1.Text,DDL_BLN1.SelectedValue,TXT_THN1.Text);
		//				tanggal2 = tools.ConvertDate(TXT_TGL2.Text,DDL_BLN2.SelectedValue,TXT_THN2.Text);
		//
		//				if (!Information.IsDate(tanggal1) || !Information.IsDate(tanggal2))
		//				{
		//					Tools.popMessage(this,"Invalid date");
		//					if (!Information.IsDate(tanggal1))
		//						Tools.SetFocus(this,TXT_TGL1);
		//					else
		//						Tools.SetFocus(this,TXT_TGL2);
		//				}
		//				else
		//					LoadReport_Load(jnsdata, rekanantype, namarekan, tanggal1, tanggal2);
		//			}
		//			else
		//			{
		//				Response.Write("<script language='javascript'>alert('Invalid Date !')</script>");
		//			}
		//		}

	}
}
