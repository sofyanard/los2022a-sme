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
using System.Configuration;
using DMS.CuBESCore;
using DMS.DBConnection;
using Microsoft.VisualBasic;

namespace SME.MAS.CollateralAdministration.DetailCollateral
{
	/// <summary>
	/// Summary description for Collateral_Lsagr.
	/// </summary>
	public partial class Collateral_Lsagr : System.Web.UI.Page
	{
		protected Tools tool = new Tools();
		protected Connection conn = new Connection(ConfigurationSettings.AppSettings["conn"]);
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			//conn = (Connection) Session["Connection"];

			if (!IsPostBack)
			{
				DLLAll();
				btn_save.Attributes.Add("onClick","return cek_mandatory(document.Form1);");
				TXT_SIBS_COLID.Text=Request.QueryString["collateral_id"];
				LBL_REGNO.Text=Request.QueryString["acc_number"];
				FillField();
			}
		}

		private void FillField()
		{
			DLLAll();

			conn.QueryString = "exec MAS_CHANGE_COL_VALUE 'get'," +
				"'"+ Request.QueryString["acc_number"] +"','"+ Request.QueryString["collateral_id"] +"'," +
				"'','','','','','','','','','','',''";
			conn.ExecuteQuery();

			TXT_CL_VALUE.Text			= tool.MoneyFormat(conn.GetFieldValue("CL_VALUE"));
			TXT_CL_VALUE2.Text			= tool.MoneyFormat(conn.GetFieldValue("CL_VALUE2"));
			TXT_CL_VALUEINS.Text		= tool.MoneyFormat(conn.GetFieldValue("CL_VALUEINS"));
			TXT_CL_VALUEIKAT.Text		= tool.MoneyFormat(conn.GetFieldValue("CL_VALUEIKAT"));
			TXT_CL_VALUEPPA.Text		= tool.MoneyFormat(conn.GetFieldValue("CL_VALUEPPA"));
			TXT_CL_VALUELIQ.Text		= tool.MoneyFormat(conn.GetFieldValue("CL_VALUELIQ"));
			TXT_CL_DESC.Text			= conn.GetFieldValue("CL_DESC");
			try{DDL_CL_CURRENCY.SelectedValue	= conn.GetFieldValue("CL_CURRENCY");}
			catch{}
			try{DDL_CL_COLCLASSIFY.SelectedValue	= conn.GetFieldValue("CL_COLCLASSIFY");}
			catch{}
			
			
			conn.QueryString = "exec MAS_CHANGE_COL_Lsagr 'get'," +
				"'"+ Request.QueryString["acc_number"] +"','"+ Request.QueryString["collateral_id"] +"','"+ Request.QueryString["type"]+"'," +
				"'','','','','','','','','','',"+ 
				"'','','','','','','','','','',"+ 
				"'','','','','','','','','','',''" ;
			conn.ExecuteQuery();

			TXT_CL_COMPNAME.Text = conn.GetFieldValue("CL_COMPNAME");
			TXT_CL_BUILDOWN.Text = conn.GetFieldValue("CL_BUILDOWN");
			try{DDL_CL_PROPTYPE.SelectedValue	= conn.GetFieldValue("CL_PROPTYPE");}
			catch{}
			string CL_ISSUEDATE		= conn.GetFieldValue("CL_ISSUEDATE");
			TXT_CL_ISSUEDATEDAY.Text	= tool.FormatDate_Day(CL_ISSUEDATE);
			TXT_CL_ISSUEDATEYEAR.Text	= tool.FormatDate_Year(CL_ISSUEDATE);
			try{DDL_CL_ISSUEDATEMONTH.SelectedValue	= tool.FormatDate_Month(CL_ISSUEDATE);}
			catch{}
			string CL_EXPDATE		= conn.GetFieldValue("CL_EXPDATE");
			TXT_CL_EXPDATEDAY.Text	= tool.FormatDate_Day(CL_EXPDATE);
			TXT_CL_EXPDATEYEAR.Text	= tool.FormatDate_Year(CL_EXPDATE);
			try{DDL_CL_EXPDATEMONTH.SelectedValue	= tool.FormatDate_Month(CL_EXPDATE);}
			catch{}
			string CL_APPRDATE		= conn.GetFieldValue("CL_APPRDATE");
			TXT_CL_APPRDATEDAY.Text	= tool.FormatDate_Day(CL_APPRDATE);
			TXT_CL_APPRDATEYEAR.Text	= tool.FormatDate_Year(CL_APPRDATE);
			try{DDL_CL_APPRDATEMONTH.SelectedValue	= tool.FormatDate_Month(CL_APPRDATE);}
			catch{}
			//TXT_CL_APPRVAL.Text = tool.MoneyFormat(conn.GetFieldValue("CL_APPRVALUE"));
			//if (TXT_CL_APPRVAL.Text == "0,00")
			//	TXT_CL_APPRVAL.Text	= TXT_CL_VALUE.Text;

			TXT_CL_APPRBY.Text = conn.GetFieldValue("CL_APPRBY");
			TXT_CL_GUARANTEEVAL.Text = tool.MoneyFormat(conn.GetFieldValue("CL_GUARANTEEVAL"));
			TXT_CL_EXCHGRATE.Text = tool.MoneyFormat(conn.GetFieldValue("CL_EXCHGRATE"));
			TXT_CL_ADDR1.Text = conn.GetFieldValue("CL_ADDR1");
			TXT_CL_ADDR2.Text = conn.GetFieldValue("CL_ADDR2");
			TXT_CL_ADDR3.Text = conn.GetFieldValue("CL_ADDR3");
			TXT_CL_HMNUM.Text = conn.GetFieldValue("CL_HMNUM");		

			conn.QueryString = "select * from mas_collateral where acc_number='" + LBL_REGNO.Text + "' and collateral_id='" + TXT_SIBS_COLID.Text + "'";
			conn.ExecuteQuery();

			TXT_BAST_KE_CA.Text=conn.GetFieldValue("bast_ke_ca");
			TXT_BAST_DARI_CA.Text=conn.GetFieldValue("bast_dari_ca");
			ddl_posisi.SelectedValue=conn.GetFieldValue("posisi_agunan");

			if (ddl_posisi.SelectedValue=="1")
			{
				BTN_FINISH.Enabled=true;
			}
		}
		private void DLLAll()
		{
			DDL_CL_CURRENCY.Items.Add(new ListItem("- PILIH -", ""));
			DDL_CL_COLCLASSIFY.Items.Add(new ListItem("- PILIH -", ""));
			DDL_CL_PROPTYPE.Items.Add(new ListItem("- PILIH -", ""));
			DDL_CL_ISSUEDATEMONTH.Items.Add(new ListItem("- PILIH -", ""));
			DDL_CL_EXPDATEMONTH.Items.Add(new ListItem("- PILIH -", ""));
			DDL_CL_APPRDATEMONTH.Items.Add(new ListItem("- PILIH -", ""));

			ddl_posisi.Items.Add(new ListItem("- PILIH -", ""));
			DDL_CAO_NAME.Items.Add(new ListItem("--Pilih--",""));

			conn.QueryString = "select userid, su_fullname from scuser where su_active='1' and userid!='"+ Session["UserID"].ToString()+
				"' and groupid='83' and su_branch=(select su_branch from scuser where userid = '"+ Session["UserID"].ToString() +"')" ;
			conn.ExecuteQuery();
			for (int i = 0; i < conn.GetRowCount(); i++)
				DDL_CAO_NAME.Items.Add(new ListItem(conn.GetFieldValue(i,1),conn.GetFieldValue(i,0)));

			
			conn.QueryString = "select * from MAS_RF_POSISI_AGUNAN where status='1'";
			conn.ExecuteQuery();
			for (int i = 0; i < conn.GetRowCount(); i++)
				ddl_posisi.Items.Add(new ListItem(conn.GetFieldValue(i,1),conn.GetFieldValue(i,0)));

			for (int i=1; i<=12; i++)
			{
				DDL_CL_ISSUEDATEMONTH.Items.Add(new ListItem(DateAndTime.MonthName(i, false), i.ToString()));
				DDL_CL_EXPDATEMONTH.Items.Add(new ListItem(DateAndTime.MonthName(i, false), i.ToString()));
				DDL_CL_APPRDATEMONTH.Items.Add(new ListItem(DateAndTime.MonthName(i, false), i.ToString()));
			}

			//--- Mata Uang
			////////////////////////////////////////////////////////////////////
			conn.QueryString = "select CURRENCYID, CURRENCYID + ' - ' + CURRENCYDESC as CURRENCYDESC from RFCURRENCY where ACTIVE = '1' order by CURRENCYID";
			conn.ExecuteQuery();
			for (int i=0; i< conn.GetRowCount(); i++)
				DDL_CL_CURRENCY.Items.Add(new ListItem(conn.GetFieldValue(i, 1), conn.GetFieldValue(i, 0)));
				
			////////////////////////////////////////////////////////////////////
			conn.QueryString = "select COLCLASSID, COLCLASSDESC from RFCOLLCLASS where active='1'";
			conn.ExecuteQuery();
			for (int i=0; i< conn.GetRowCount(); i++)
				DDL_CL_COLCLASSIFY.Items.Add(new ListItem(conn.GetFieldValue(i, 1), conn.GetFieldValue(i, 0)));

			////////////////////////////////////////////////////////////////////
			conn.QueryString = "select PROPTYPEID, PROPTYPEDESC from RFPROPTYPE where active='1'";
			conn.ExecuteQuery();
			for (int i=0; i< conn.GetRowCount(); i++)
				DDL_CL_PROPTYPE.Items.Add(new ListItem(conn.GetFieldValue(i, 1), conn.GetFieldValue(i, 0)));

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

		protected void btn_save_Click(object sender, System.EventArgs e)
		{
			if (ddl_posisi.SelectedValue=="1")
			{
				BTN_FINISH.Enabled=true ;
			}
			if (TXT_CL_DESC.Text!="" &&
				DDL_CL_CURRENCY.SelectedValue!="" &&
				DDL_CL_COLCLASSIFY.SelectedValue!="" &&
				ddl_posisi.SelectedValue!="" &&
				TXT_CL_VALUE.Text!="" &&
				TXT_CL_COMPNAME.Text!="" &&
				DDL_CL_PROPTYPE.SelectedValue!="" &&
				TXT_CL_VALUE2.Text!="")
			{
				SaveData();
			}
		}

		private void SaveData()
		{
			conn.QueryString = "exec MAS_CHANGE_COL_Lsagr 'get'," +
				"'"+ Request.QueryString["acc_number"] +"','"+ Request.QueryString["collateral_id"] +"','"+ Request.QueryString["type"]+"'," +
				"'"+ TXT_CL_COMPNAME.Text +"','"+ TXT_CL_BUILDOWN.Text +"','"+ DDL_CL_PROPTYPE.SelectedValue +
				"',"+ tool.ConvertDate(TXT_CL_ISSUEDATEDAY.Text, DDL_CL_ISSUEDATEMONTH.SelectedValue, TXT_CL_ISSUEDATEYEAR.Text) +
				","+ tool.ConvertDate(TXT_CL_EXPDATEDAY.Text, DDL_CL_EXPDATEMONTH.SelectedValue, TXT_CL_EXPDATEYEAR.Text) +
				","+ tool.ConvertDate(TXT_CL_APPRDATEDAY.Text, DDL_CL_APPRDATEMONTH.SelectedValue, TXT_CL_APPRDATEYEAR.Text) +
				"'"+TXT_CL_VALUE2.Text+"','"+ TXT_CL_APPRBY.Text +"','"+TXT_CL_GUARANTEEVAL.Text +
				"','"+TXT_CL_EXCHGRATE.Text+"','"+ TXT_CL_ADDR1.Text  +"','"+ TXT_CL_ADDR2.Text  +
				"','"+ TXT_CL_ADDR3.Text  +"','"+ TXT_CL_HMNUM.Text +"',NULL,NULL,"+
				tool.ConvertFloat(TXT_CL_VALUE.Text) + "," +
				tool.ConvertFloat(TXT_CL_VALUE2.Text) + "," +
				tool.ConvertFloat(TXT_CL_VALUEINS.Text) + "," +
				tool.ConvertFloat(TXT_CL_VALUEIKAT.Text) + "," +
				tool.ConvertFloat(TXT_CL_VALUEPPA.Text) + "," +
				tool.ConvertFloat(TXT_CL_VALUELIQ.Text) + "," +
				"'" + TXT_CL_DESC.Text + "'," +
				"'" + DDL_CL_CURRENCY.SelectedValue + "'," +
				"NULL,NULL," +
				"'" + DDL_CL_COLCLASSIFY.SelectedValue + "'," +
				"'" + Session["userID"] + "','" + TXT_BAST_KE_CA.Text + "','" + TXT_BAST_DARI_CA.Text + "','" + ddl_posisi.SelectedValue + "'";
			conn.ExecuteQuery();

		}

		protected void BTN_FINISH_Click(object sender, System.EventArgs e)
		{
			
			if (TXT_CL_DESC.Text!="" &&
				DDL_CL_CURRENCY.SelectedValue!="" &&
				DDL_CL_COLCLASSIFY.SelectedValue!="" &&
				ddl_posisi.SelectedValue!="" &&
				TXT_CL_VALUE.Text!="" &&
				TXT_CL_COMPNAME.Text!="" &&
				DDL_CL_PROPTYPE.SelectedValue!="" &&
				TXT_CL_VALUE2.Text!="")
			{
				SaveData();
				conn.QueryString = "exec MAS_COLLATERAL_TRACKUPDATE '" +
					LBL_REGNO.Text + "' , '" + 
					TXT_SIBS_COLID.Text + "' , 'M1.8' , '" + 
					Session["UserID"].ToString() + "' , '', '6', '" + Request.QueryString["status"] +"'";
				conn.ExecuteQuery();
			}
			
		}

		protected void BTN_SEND_Click(object sender, System.EventArgs e)
		{
			if (DDL_CAO_NAME.SelectedValue == "")
			{
				GlobalTools.popMessage(this, "CAO Name tidak boleh kosong!");
				return;	
			}

			/*conn.QueryString = "update MAS_COLLATERAL set posisi_agunan='4' where ACC_NUMBER ='" +Request.QueryString["acc_number"]+ "' and collateral_id = '" +Request.QueryString["collateral_id"]+ "'";
			conn.ExecuteQuery();*/

			conn.QueryString = "update MAS_COLLATERAL set CAO_NAME = '" + DDL_CAO_NAME.SelectedValue.ToString() + "'," +
				" SEND_CAO_DATE = '" + DateAndTime.Now.ToString() + "'" +
				" where ACC_NUMBER ='" +LBL_REGNO.Text + "' and collateral_id = '" + TXT_SIBS_COLID.Text + "'";
			conn.ExecuteQuery();

			conn.QueryString = "exec MAS_COLLATERAL_TRACKUPDATE '" +
				LBL_REGNO.Text + "' , '" + 
				TXT_SIBS_COLID.Text + "' , 'M1.3' , '" + 
				Session["UserID"].ToString() + "' , '', '4', '" + Request.QueryString["status"] +"'";
			conn.ExecuteQuery();
		}
	}
}
