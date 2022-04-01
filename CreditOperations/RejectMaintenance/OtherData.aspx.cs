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

namespace SME.CreditOperations.RejectMaintenance
{
	/// <summary>
	/// Summary description for OtherData.
	/// </summary>
	public partial class OtherData : System.Web.UI.Page
	{
		protected Connection conn;
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.Label Label2;
		protected Tools tool = new Tools();

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
				LBL_PRODUCTID.Text = Request.QueryString["productid"];
				LBL_APPTYPE.Text = Request.QueryString["apptype"];
				LBL_PROD_SEQ.Text = Request.QueryString["prod_seq"];

				//init rflegalstatus
				conn.QueryString = "select LEGALSTAID, LEGALSTADESC from RFLEGALSTATUS where active = '1' ";
				conn.ExecuteQuery();
				RBL_LEGALSTAPROD.Items.Clear();
				for (int i=0; i<conn.GetRowCount(); i++)
					RBL_LEGALSTAPROD.Items.Add(new ListItem(conn.GetFieldValue(i, 1), conn.GetFieldValue(i, 0)));

				for (int i = 1; i <= 12; i++)
				{
					DDL_CP_PKDATEMONTH.Items.Add(new ListItem(DateAndTime.MonthName(i, false), i.ToString()));
					DDL_CP_PKDATEADDMONTH.Items.Add(new ListItem(DateAndTime.MonthName(i, false), i.ToString()));
				}

				GlobalTools.initDateForm(TXT_AD_DATE_BU_DAY, DDL_AD_DATE_BU_MONTH, TXT_AD_DATE_BU_YEAR, true);
				GlobalTools.initDateForm(TXT_AD_DATE_CRM_DAY, DDL_AD_DATE_CRM_MONTH, TXT_AD_DATE_BU_YEAR, true);
				GlobalTools.initDateForm(TXT_KIRIM_AD_DAY, DDL_KIRIM_AD_MONTH, TXT_KIRIM_AD_YEAR, true);

				ViewDataKredit();
				ViewDataOfficer();
				ViewDataInsurance();
			}
			else
			{
				TXT_CP_BEAADM.Text = tool.MoneyFormat(TXT_CP_BEAADM.Text);
				TXT_CP_BEAIKAT.Text = tool.MoneyFormat(TXT_CP_BEAIKAT.Text);
				TXT_CP_BEAMATERAI.Text = tool.MoneyFormat(TXT_CP_BEAMATERAI.Text);
				TXT_CP_BEANOTARIS.Text = tool.MoneyFormat(TXT_CP_BEANOTARIS.Text);
				TXT_CP_BEAPROVISI.Text = tool.MoneyFormat(TXT_CP_BEAPROVISI.Text);
				TXT_ALI_PREMI.Text = tool.MoneyFormat(TXT_ALI_PREMI.Text);
			}
		}

		private void ViewDataKredit()
		{
			conn.QueryString = "select APL_BEAADM , APL_BEAPROVISI , APL_BEANOTARIS , APL_BEAIKAT , " +
				"APL_BEAMATERAI , APL_LEGALSTATUS , APL_PKNO, APL_PKNOADD, APL_PKDATE, APL_PKDATEADD, APL_BEAPROVISI_PCT " +
				"FROM VW_CREOPR_NOTARYASSIGN_CREDSTRUCT "+
				"where AP_REGNO = '"+ LBL_REGNO.Text + "' and APPTYPE = '" + LBL_APPTYPE.Text + 
				"' and PRODUCTID = '" + LBL_PRODUCTID.Text + "' AND PROD_SEQ = '" + LBL_PROD_SEQ.Text + "'" ;
			conn.ExecuteQuery();

			if (conn.GetRowCount() == 0)
				return;

			TXT_CP_PKNO.Text = conn.GetFieldValue(0, "APL_PKNO");
			TXT_CP_PKNOADD.Text = conn.GetFieldValue(0, "APL_PKNOADD");
			try
			{
				string CP_PKDATE = conn.GetFieldValue("APL_PKDATE");
				TXT_CP_PKDATEDAY.Text = tool.FormatDate_Day(CP_PKDATE);
				DDL_CP_PKDATEMONTH.SelectedValue = tool.FormatDate_Month(CP_PKDATE);
				TXT_CP_PKDATEYEAR.Text = tool.FormatDate_Year(CP_PKDATE);
				string CP_PKDATEADD = conn.GetFieldValue("APL_PKDATEADD");
				TXT_CP_PKDATEADDDAY.Text = tool.FormatDate_Day(CP_PKDATEADD);
				DDL_CP_PKDATEADDMONTH.SelectedValue = tool.FormatDate_Month(CP_PKDATEADD);
				TXT_CP_PKDATEADDYEAR.Text = tool.FormatDate_Year(CP_PKDATEADD);
			} 
			catch {}

			TXT_CP_BEAADM.Text = tool.MoneyFormat(conn.GetFieldValue(0, "APL_BEAADM"));
			TXT_CP_BEAPROVISI.Text = tool.MoneyFormat(conn.GetFieldValue(0, "APL_BEAPROVISI"));
			TXT_CP_BEANOTARIS.Text = tool.MoneyFormat(conn.GetFieldValue(0, "APL_BEANOTARIS"));
			TXT_CP_BEAIKAT.Text = tool.MoneyFormat(conn.GetFieldValue(0, "APL_BEAIKAT"));
			TXT_CP_BEAMATERAI.Text = tool.MoneyFormat(conn.GetFieldValue(0, "APL_BEAMATERAI"));
			try
			{
				RBL_LEGALSTAPROD.SelectedValue = conn.GetFieldValue(0, "APL_LEGALSTATUS").Trim();
			} 
			catch {}

		}

		private void ViewDataOfficer()
		{
			///////////////////////////////////////////////////////
			/// Mengambil approval user (BU dan CRM)
			/// 
			conn.QueryString = "select BU_USERID , BU_OFFICER_CODE , '(' + BU_USERID + ' - ' + BU_FULLNAME + ')' BU_FULLNAME , " +
				"CRM_USERID , CRM_OFFICER_CODE , '(' + CRM_USERID + ' - ' + CRM_FULLNAME + ')' CRM_FULLNAME, BU_AD_DATE, CRM_AD_DATE " +
				"FROM VW_INFOUMUM_APPROVAL "+
				"where AP_REGNO = '"+ LBL_REGNO.Text + "' and APPTYPE = '" + LBL_APPTYPE.Text + 
				"' and PRODUCTID = '" + LBL_PRODUCTID.Text + "' and PROD_SEQ = '" + LBL_PROD_SEQ.Text + "'" ;
			conn.ExecuteQuery();

			if (conn.GetRowCount() > 0)
			{
				LBL_BUUSERID.Text = conn.GetFieldValue(0, "BU_USERID");
				LBL_BUOFFICERCODE.Text = conn.GetFieldValue(0, "BU_FULLNAME");
				TXT_BUOFFICERCODE.Text = conn.GetFieldValue(0, "BU_OFFICER_CODE");
				LBL_CCRAUSERID.Text = conn.GetFieldValue(0, "CRM_USERID");
				LBL_CCRAOFFICERCODE.Text = conn.GetFieldValue(0, "CRM_FULLNAME");
				TXT_CCRAOFFICERCODE.Text = conn.GetFieldValue(0, "CRM_OFFICER_CODE");

				//////////////////////////////////////////////////
				///	Mengambil tanggal approval (BU dan CRM)
				///	
				GlobalTools.fillDateForm(TXT_AD_DATE_BU_DAY, DDL_AD_DATE_BU_MONTH, TXT_AD_DATE_BU_YEAR, Convert.ToDateTime(conn.GetFieldValue(0,"BU_AD_DATE")));
				GlobalTools.fillDateForm(TXT_AD_DATE_CRM_DAY, DDL_AD_DATE_CRM_MONTH, TXT_AD_DATE_CRM_YEAR, Convert.ToDateTime(conn.GetFieldValue(0,"CRM_AD_DATE")));
			}
			
			///////////////////////////////////////////////////
			/// Mengambil kirim ke Decision Center
			/// 
			conn.QueryString = "select TH_TRACKDATE from TRACKHISTORY where AP_REGNO = '" + LBL_REGNO.Text + "' and TRACKCODE = '1.9'";
			conn.ExecuteQuery();

			if(conn.GetRowCount()>0)
			{
				GlobalTools.fillDateForm(TXT_KIRIM_AD_DAY, DDL_KIRIM_AD_MONTH, TXT_KIRIM_AD_YEAR, Convert.ToDateTime(conn.GetFieldValue(0,"TH_TRACKDATE")));
			}

			///////////////////////////////////////////////////////
			/// Mengambil RM user 
			/// 
			conn.QueryString = "select AP_RELMNGR , OFFICER_CODE , '(' + AP_RELMNGR + ' - ' + SU_FULLNAME + ')' RM_FULLNAME " +
                "FROM application a left join scuser sc on sc.userid = a.AP_RELMNGR " +
				"where AP_REGNO = '"+ LBL_REGNO.Text + "' " ;
			conn.ExecuteQuery();
			if(conn.GetRowCount()>0)
			{
				LBL_RMUSERID.Text = conn.GetFieldValue(0, "AP_RELMNGR");
				LBL_RMOFFICERCODE.Text = conn.GetFieldValue(0, "RM_FULLNAME");
				TXT_RMOFFICERCODE.Text = conn.GetFieldValue(0, "OFFICER_CODE");
			}
		}

		private void ViewDataInsurance()
		{
			conn.QueryString = "select IC_ID, IC_DESC, ALI_PREMI  from VW_REJECTMAIN_INSR " +
				"where AP_REGNO = '"+ LBL_REGNO.Text + "' " ;
			conn.ExecuteQuery();
			if(conn.GetRowCount()>0)
			{
				TXT_IC_ID.Text = conn.GetFieldValue(0, "IC_ID");
				LBL_IC_DESC.Text = conn.GetFieldValue(0, "IC_DESC");
				TXT_ALI_PREMI.Text = tool.MoneyFormat(conn.GetFieldValue(0, "ALI_PREMI"));
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

		protected void BTN_SAVE_KREDIT_Click(object sender, System.EventArgs e)
		{
			string pk = RBL_LEGALSTAPROD.SelectedValue.Trim();
			conn.QueryString = "exec LGL_SCREDIT '"+ LBL_REGNO.Text +"', '"+ LBL_APPTYPE.Text +"', '"+ LBL_PRODUCTID.Text +"', "+
				tool.ConvertFloat(TXT_CP_BEAADM.Text) +", "+ tool.ConvertFloat(TXT_CP_BEAPROVISI.Text) +", "+
				tool.ConvertFloat(TXT_CP_BEANOTARIS.Text) +", "+ tool.ConvertFloat(TXT_CP_BEAIKAT.Text) +", "+
				tool.ConvertFloat(TXT_CP_BEAMATERAI.Text) +", '" + pk + "', '" + TXT_CP_PKNO.Text.Trim() + "', '" + TXT_CP_PKNOADD.Text.Trim() +
				"', " + tool.ConvertDate(TXT_CP_PKDATEDAY.Text, DDL_CP_PKDATEMONTH.SelectedValue, TXT_CP_PKDATEYEAR.Text) + 
				", " + tool.ConvertDate(TXT_CP_PKDATEADDDAY.Text, DDL_CP_PKDATEADDMONTH.SelectedValue, TXT_CP_PKDATEADDYEAR.Text) + 
				", '" + LBL_PROD_SEQ.Text + "'";
			conn.ExecuteNonQuery();
			ViewDataKredit();
		}

		protected void BTN_SAVE_OTHER_Click(object sender, System.EventArgs e)
		{
			/**
			conn.QueryString = "UPDATE SCUSER SET OFFICER_CODE = '" + TXT_BUOFFICERCODE.Text.Trim() +
				"' WHERE USERID = '" + LBL_BUUSERID.Text.Trim() + "' ";
			conn.ExecuteNonQuery();
			conn.QueryString = "UPDATE SCUSER SET OFFICER_CODE = '" + TXT_CCRAOFFICERCODE.Text.Trim() +
				"' WHERE USERID = '" + LBL_CCRAUSERID.Text.Trim() + "' ";
			conn.ExecuteNonQuery();
			**/

			conn.QueryString = "exec REJECTMAIN_OTHER '" + 
				TXT_BUOFFICERCODE.Text + "', '" + 
				TXT_CCRAOFFICERCODE.Text + "', '" + 
				TXT_RMOFFICERCODE.Text + "', '" + 
				LBL_REGNO.Text + "'";
			conn.ExecuteNonQuery();

			ViewDataOfficer();
		}

		protected void BTN_SAVE_ASURANSI_Click(object sender, System.EventArgs e)
		{
			double dbl;
			try
			{
				dbl = double.Parse(TXT_ALI_PREMI.Text);
			}
			catch
			{
				TXT_ALI_PREMI.Text = "0";
			}
			conn.QueryString = "exec REJECTMAIN_INSR '" + 
				LBL_REGNO.Text + "', " + 
				GlobalTools.ConvertNull(TXT_IC_ID.Text) + ", " + 
				GlobalTools.ConvertFloat(TXT_ALI_PREMI.Text);
			conn.ExecuteNonQuery();

			ViewDataInsurance();
		}
	}
}
