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

namespace SME.RejectMaintenanceDE
{
	/// <summary>
	/// Summary description for COLLATERAL_PNCHQ.
	/// </summary>
	public partial class COLLATERAL_PNCHQ : System.Web.UI.Page
	{
		//protected Connection conn = new Connection("Data Source=10.123.12.30;Initial Catalog=SMEDEV;uid=sa;pwd=");
		protected Tools tool = new Tools();
		protected Connection conn;
		
		protected void Page_Load(object sender, System.EventArgs e)
		{
			conn = (Connection) Session["Connection"];

			if (!IsPostBack)
			{
				
				LBL_REGNO.Text	= Request.QueryString["regno"];
				LBL_CUREF.Text	= Request.QueryString["curef"];
				LBL_TC.Text		= Request.QueryString["tc"];
				LBL_CL_SEQ.Text	= Request.QueryString["CL_SEQ"];
				string CL_TYPE	= Request.QueryString["coltypeid"];
							
				DDL_CL_CURRENCY.Items.Add(new ListItem("- PILIH -", ""));
				DDL_CL_COLCLASSIFY.Items.Add(new ListItem("- PILIH -", ""));
				DDL_CL_CHECKDATEMONTH.Items.Add(new ListItem("- PILIH -", ""));
				
				for (int i=1; i<=12; i++)
					DDL_CL_CHECKDATEMONTH.Items.Add(new ListItem(DateAndTime.MonthName(i, false), i.ToString()));
				
				//--- Mata Uang
				conn.QueryString = "select CURRENCYID, CURRENCYID + ' - ' + CURRENCYDESC as CURRENCYDESC from RFCURRENCY where ACTIVE = '1' ";
				conn.ExecuteQuery();
				for (int i=0; i< conn.GetRowCount(); i++)
					DDL_CL_CURRENCY.Items.Add(new ListItem(conn.GetFieldValue(i, 1), conn.GetFieldValue(i, 0)));
				
				conn.QueryString = "select COLCLASSID, COLCLASSDESC from RFCOLLCLASS where active='1'";
				conn.ExecuteQuery();
				for (int i=0; i< conn.GetRowCount(); i++)
					DDL_CL_COLCLASSIFY.Items.Add(new ListItem(conn.GetFieldValue(i, 1), conn.GetFieldValue(i, 0)));

				string CL_SEQ = LBL_CL_SEQ.Text;
				if (CL_SEQ != "")
					ViewData();
			}
			else
			{
				Update();
			}
		}

		private void ViewData()
		{
			conn.QueryString = "select * from VW_COLL_PNCHQ "+
				"where CUREF ='" + LBL_CUREF.Text + "' and CLSEQ = "+ Convert.ToInt16(LBL_CL_SEQ.Text);
			conn.ExecuteQuery();

			TXT_CL_VALUE.Text			= tool.MoneyFormat(conn.GetFieldValue("CL_PROPVALUE"));
			TXT_CL_VALUE2.Text			= tool.MoneyFormat(conn.GetFieldValue("CL_VALUE2"));
			TXT_CL_VALUEINS.Text		= tool.MoneyFormat(conn.GetFieldValue("CL_VALUEINS"));
			TXT_CL_VALUEIKAT.Text		= tool.MoneyFormat(conn.GetFieldValue("CL_VALUEIKAT"));
			TXT_CL_VALUEPPA.Text		= tool.MoneyFormat(conn.GetFieldValue("CL_VALUEPPA"));
			TXT_CL_VALUELIQ.Text		= tool.MoneyFormat(conn.GetFieldValue("CL_VALUELIQ"));
			TXT_CL_DESC.Text			= conn.GetFieldValue("CL_DESC");
			try 
			{
				DDL_CL_CURRENCY.SelectedValue	= conn.GetFieldValue("CL_CURRENCY");
			} 
			catch {}
			try 
			{
				DDL_CL_COLCLASSIFY.SelectedValue	= conn.GetFieldValue("CL_COLCLASSIFY");
			} 
			catch {}
			TXT_SIBS_COLID.Text			= conn.GetFieldValue("SIBS_COLID");
			TXT_CL_CHECKNO.Text = conn.GetFieldValue("CL_CHECKNO");
			string CL_CHECKDATE		= conn.GetFieldValue("CL_CHECKDATE");
			TXT_CL_CHECKDATEDAY.Text	= tool.FormatDate_Day(CL_CHECKDATE);
			TXT_CL_CHECKDATEYEAR.Text	= tool.FormatDate_Year(CL_CHECKDATE);
			try 
			{
				DDL_CL_CHECKDATEMONTH.SelectedValue	= tool.FormatDate_Month(CL_CHECKDATE);
			} 
			catch {}
			TXT_CL_AMOUNT.Text = tool.MoneyFormat(conn.GetFieldValue("CL_AMOUNT"));
			TXT_CL_CASHEDBY.Text = conn.GetFieldValue("CL_CASHEDBY");
			TXT_CL_ENDORSERS.Text = conn.GetFieldValue("CL_ENDORSERS");
			TXT_CL_PAYEE.Text = conn.GetFieldValue("CL_PAYEE");
			if (conn.GetFieldValue("CL_ISCASHEDVALUE") == "1")
				CHB_CL_ISCASHEDVALUE.Checked = true;
		}

		private void Update()
		{
			if (CHB_CL_ISCASHEDVALUE.Checked && (TXT_CL_AMOUNT.Text.Trim() == "" || TXT_CL_AMOUNT.Text.Trim() == "0,00"))
				Tools.popMessage(this,"Jumlah tidak boleh kosong !!");
			else
			{
				conn.QueryString = "exec DE_COLL_PNCHQ '"+ LBL_CUREF.Text +"', "+ LBL_CL_SEQ.Text +", 0, "+
					tool.ConvertFloat(TXT_CL_VALUE.Text) +", "+ 
					tool.ConvertFloat(TXT_CL_VALUE2.Text) +", "+ tool.ConvertFloat(TXT_CL_VALUEINS.Text) +", "+ tool.ConvertFloat(TXT_CL_VALUEIKAT.Text) +", "+ tool.ConvertFloat(TXT_CL_VALUEPPA.Text) +", "+ tool.ConvertFloat(TXT_CL_VALUELIQ.Text) +", '"+ 
					TXT_CL_DESC.Text +"', "+ DDL_CL_CURRENCY.SelectedValue +", "+
					tool.ConvertNull(DDL_CL_COLCLASSIFY.SelectedValue) +", '"+ TXT_SIBS_COLID.Text +"', '"+ TXT_CL_CHECKNO.Text +"', "+ 
					tool.ConvertDate(TXT_CL_CHECKDATEDAY.Text, DDL_CL_CHECKDATEMONTH.SelectedValue, TXT_CL_CHECKDATEYEAR.Text) +", "+
					tool.ConvertFloat(TXT_CL_AMOUNT.Text) +", '"+ TXT_CL_CASHEDBY.Text +"', '"+ TXT_CL_ENDORSERS.Text +"', '"+ 
					TXT_CL_PAYEE.Text +"', '"+ tool.ConvertFlag(CHB_CL_ISCASHEDVALUE.Checked) +"', '"+LBL_REGNO.Text+ "'";
				conn.ExecuteNonQuery();
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

		protected void Button1_ServerClick(object sender, System.EventArgs e)
		{
		
		}
	}
}
