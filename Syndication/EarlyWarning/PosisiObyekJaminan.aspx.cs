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
using Microsoft.VisualBasic;
using System.Configuration;

namespace SME.Syndication.EarlyWarning
{
	/// <summary>
	/// Summary description for PosisiObyekJaminan.
	/// </summary>
	public partial class PosisiObyekJaminan : System.Web.UI.Page
	{
		protected Tools tools = new Tools();
		protected Connection conn = new Connection(ConfigurationSettings.AppSettings["conn"]);
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			if(!IsPostBack)
			{
				DDL_BLN1.Items.Add(new ListItem("-- Pilih --",""));
				DDL_BLN2.Items.Add(new ListItem("-- Pilih --",""));
				for (int i = 1; i <= 12; i++)
				{
					DDL_BLN1.Items.Add(new ListItem(DateAndTime.MonthName(i, false), i.ToString()));
					DDL_BLN2.Items.Add(new ListItem(DateAndTime.MonthName(i, false), i.ToString()));
				}
				FillDDLCust();
				FillDDLBank();
			}
		}

		private void FillDDLCust()
		{
			DDL_CUSTOMER_NM.Items.Clear();
			DDL_CUSTOMER_NM.Items.Add(new ListItem("--Select--", ""));

			conn.QueryString = "SELECT CU_REF, CUST_NAME FROM SDC_CUSTOMER_INFO";
			conn.ExecuteQuery();
			for(int i=0; i < conn.GetRowCount(); i++)
			{
				DDL_CUSTOMER_NM.Items.Add(new ListItem(conn.GetFieldValue(i,1), conn.GetFieldValue(i,0)));
			}
		}

		private void FillDDLBank()
		{
			DDL_BANK_NM.Items.Clear();
			DDL_BANK_NM.Items.Add(new ListItem("--Select--", ""));

			conn.QueryString = "SELECT BANKID, BANKNAME FROM RFBANK WHERE ACTIVE = '1'";
			conn.ExecuteQuery();
			for(int i=0; i < conn.GetRowCount(); i++)
			{
				DDL_BANK_NM.Items.Add(new ListItem(conn.GetFieldValue(i,1), conn.GetFieldValue(i,0)));
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

		protected void BTN_FIND_Click(object sender, System.EventArgs e)
		{
			string tanggal1		= "";
			string tanggal2		= "";
			string cust			= DDL_CUSTOMER_NM.SelectedValue;
			string bank			= DDL_BANK_NM.SelectedValue;

			if (TXT_TGL1.Text == "" && DDL_BLN1.SelectedValue == "" && TXT_THN1.Text == "" && TXT_TGL2.Text == "" && DDL_BLN2.SelectedValue == "" && TXT_THN2.Text == "")
			{
				LoadReport_Load(tanggal1, tanggal2, cust, bank);
			}

			else
			{
				if (Tools.isDateValid(this, TXT_TGL1.Text, DDL_BLN1.SelectedValue, TXT_THN1.Text) && Tools.isDateValid(this, TXT_TGL2.Text, DDL_BLN2.SelectedValue, TXT_THN2.Text))
				{
					tanggal1 = tools.ConvertDate(TXT_TGL1.Text, DDL_BLN1.SelectedValue, TXT_THN1.Text);
					tanggal2 = tools.ConvertDate(TXT_TGL2.Text, DDL_BLN2.SelectedValue, TXT_THN2.Text);

					if (!Information.IsDate(tanggal1) || !Information.IsDate(tanggal2))
					{
						Tools.popMessage(this,"Invalid date");
						if (!Information.IsDate(tanggal1))
							Tools.SetFocus(this, TXT_TGL1);
						else
							Tools.SetFocus(this, TXT_TGL2);
					}
					else
					{
						tanggal1		= tanggal1.Replace("'","");
						tanggal2		= tanggal2.Replace("'","");

						LoadReport_Load(tanggal1, tanggal2, cust, bank);
					}
				}
				else
				{
					Response.Write("<script language='javascript'>alert('Invalid Date !')</script>");
				}
			}
		}

		private void LoadReport_Load(string tanggal1, string tanggal2, string cust, string bank)
		{	
			string ReportAddr	= "";
			conn.QueryString	= "SELECT REPORTADDR FROM APP_PARAMETER";
			conn.ExecuteQuery();
			if (conn.GetRowCount()>0)
			{
				ReportAddr		= conn.GetFieldValue(0,0);
			}
			else
			{
				ReportAddr		= "10.123.12.50";
			}
			
			ReportViewer1.ServerUrl = "http://" + ReportAddr + "/ReportServer";

			ReportViewer1.ReportPath = "/SMEReports/RptSdcPosisiJaminan&date1=" + tanggal1 + "&date2=" + tanggal2 + "&cust=" + cust + "&bank=" + bank;
		}

		protected void BTN_CANCEL_Click(object sender, System.EventArgs e)
		{
			ClearData();
		}

		private void ClearData()
		{
			TXT_TGL1.Text					= "";
			DDL_BLN1.SelectedValue			= "";
			TXT_THN1.Text					= "";
			TXT_TGL2.Text					= "";
			DDL_BLN2.SelectedValue			= "";
			TXT_THN2.Text					= "";
			DDL_CUSTOMER_NM.SelectedValue	= "";
			DDL_BANK_NM.SelectedValue		= "";
		}

		protected void BTN_BACK_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			Response.Redirect("EarlyWarningReporting.aspx?mc=" + Request.QueryString["mc"]);
		}
	}
}
