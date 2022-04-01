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

namespace SME.Legal
{
	/// <summary>
	/// Summary description for NotaryLegalSigning.
	/// </summary>
	public partial class NotaryLegalSigning : System.Web.UI.Page
	{
		//protected Connection conn = new Connection("Data Source=10.123.12.30;Initial Catalog=SME;uid=sa;pwd=");
		protected Connection conn;
		protected Tools tool = new Tools();
		
		protected void Page_Load(object sender, System.EventArgs e)
		{
			conn = (Connection) Session["Connection"];

			if (!IsPostBack)
			{
				LBL_REGNO.Text = Request.QueryString["regno"];
				LBL_CUREF.Text = Request.QueryString["curef"];
				LBL_TC.Text = Request.QueryString["tc"];
				
				DDL_NTID.Items.Add(new ListItem("-- Pilih --", ""));
				DDL_NA_APPNTDATETIMEMONTH.Items.Add(new ListItem("-- Pilih --", ""));
				string nm_bln;
				for (int i=1; i<=12; i++)
				{
					nm_bln = DateAndTime.MonthName(i, false);
					DDL_NA_APPNTDATETIMEMONTH.Items.Add(new ListItem(nm_bln, i.ToString()));
				}

				int jml_row;
				conn.QueryString = "select NTID, NTID + ' - ' + NT_NAME as NT_NAME "+
					"from RFNOTARY where ACTIVE = '1' order by NTID";
				conn.ExecuteQuery();
				jml_row = conn.GetRowCount();
				for (int i=0; i<jml_row; i++)
					DDL_NTID.Items.Add(new ListItem(conn.GetFieldValue(i, 1), conn.GetFieldValue(i, 0)));

				ViewData();
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

		private void ViewData()
		{
			conn.QueryString = "select NTID, NA_APPNTDATETIME, NA_REMARKS "+
				"from NOTARYASSIGN "+
				"where AP_REGNO = '"+ LBL_REGNO.Text +"' and SEQ = 1 ";
			conn.ExecuteQuery();
			try{DDL_NTID.SelectedValue = conn.GetFieldValue("NTID");}
			catch{}
			string NA_APPNTDATETIME = conn.GetFieldValue("NA_APPNTDATETIME");
			TXT_NA_APPNTDATETIMEDAY.Text = tool.FormatDate_Day(NA_APPNTDATETIME);
			DDL_NA_APPNTDATETIMEMONTH.SelectedValue = tool.FormatDate_Month(NA_APPNTDATETIME);
			TXT_NA_APPNTDATETIMEYEAR.Text = tool.FormatDate_Year(NA_APPNTDATETIME);
			TXT_NA_APPNTDATETIMEHOUR.Text = tool.FormatDate_Hour(NA_APPNTDATETIME);
			TXT_NA_APPNTDATETIMEMINUTE.Text = tool.FormatDate_Minute(NA_APPNTDATETIME);
			TXT_NA_REMARKS.Text = conn.GetFieldValue("NA_REMARKS");
			CH_NTID();
		}

		protected void CH_NTID(object sender, System.EventArgs e)
		{
			conn.QueryString = "select * from RFNOTARY "+
				"where NTID = '"+ DDL_NTID.SelectedValue +"' ";
			conn.ExecuteQuery();
			TXT_NT_ADDR1.Text = conn.GetFieldValue("NT_ADDR1");
			TXT_NT_ADDR2.Text = conn.GetFieldValue("NT_ADDR2");
			TXT_NT_ADDR3.Text = conn.GetFieldValue("NT_ADDR3");
			TXT_NT_CITY.Text = conn.GetFieldValue("NT_CITY");
			TXT_NT_EMAIL.Text = conn.GetFieldValue("NT_EMAIL");
			TXT_NT_PHNAREA.Text = conn.GetFieldValue("NT_PHNAREA");
			TXT_NT_PHNNUM.Text = conn.GetFieldValue("NT_PHNNUM");
			TXT_NT_PHNEXT.Text = conn.GetFieldValue("NT_PHNEXT");
			TXT_NT_FAXAREA.Text = conn.GetFieldValue("NT_FAXAREA");
			TXT_NT_FAXNUM.Text = conn.GetFieldValue("NT_FAXNUM");
			TXT_NT_ZIPCODE.Text = conn.GetFieldValue("NT_ZIPCODE");
		}

		protected void BTN_SAVE_Click(object sender, System.EventArgs e)
		{
			conn.QueryString = "exec LGL_NTASSIGN '"+ LBL_REGNO.Text +"', 1, '"+
				tool.ConvertNull(DDL_NTID.SelectedValue) +"', "+
				tool.ConvertDate(TXT_NA_APPNTDATETIMEDAY.Text, DDL_NA_APPNTDATETIMEMONTH.SelectedValue, TXT_NA_APPNTDATETIMEYEAR.Text,  TXT_NA_APPNTDATETIMEHOUR.Text,  TXT_NA_APPNTDATETIMEMINUTE.Text) +", '"+
				TXT_NA_REMARKS.Text +"' ";
			conn.ExecuteNonQuery();
			ViewData();				
		}

		protected void CH_NTID()
		{
		
		}
	}
}
