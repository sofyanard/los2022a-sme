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
	/// Summary description for Collateral_Pg.
	/// </summary>
	public partial class Collateral_Pg : System.Web.UI.Page
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

				conn.QueryString = "select coltypedesc from rfcollateraltype where coltypeseq='"+ Request.QueryString["type"] + "'" ;
				conn.ExecuteQuery();			

				lbl_pg.Text=conn.GetFieldValue("coltypedesc");
			}
		}

		private void FillField()
		{
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
			
			conn.QueryString = "exec MAS_CHANGE_COL_pg 'get'," +
				"'"+ Request.QueryString["acc_number"] +"','"+ Request.QueryString["collateral_id"] +"','"+ Request.QueryString["type"]+"'," +
				"'','','','','','','','','','',"+ 
				"'','','','','','','','','','',"+ 
				"'','','','','','','',''" ;
			conn.ExecuteQuery();


			try{DDL_CL_RELATIONSHIP.SelectedValue	= conn.GetFieldValue("CL_RELATIONSHIP");}
			catch{}
			string CL_CONTRACTDATE		= conn.GetFieldValue("CL_CONTRACTDATE");
			TXT_CL_CONTRACTDATEDAY.Text	= tool.FormatDate_Day(CL_CONTRACTDATE);
			TXT_CL_CONTRACTDATEYEAR.Text= tool.FormatDate_Year(CL_CONTRACTDATE);
			try{DDL_CL_CONTRACTDATEMONTH.SelectedValue	= tool.FormatDate_Month(CL_CONTRACTDATE);}
			catch{}
			string CL_DUEDATE		= conn.GetFieldValue("CL_DUEDATE");
			TXT_CL_DUEDATEDAY.Text	= tool.FormatDate_Day(CL_DUEDATE);
			TXT_CL_DUEDATEYEAR.Text	= tool.FormatDate_Year(CL_DUEDATE);
			try{DDL_CL_DUEDATEMONTH.SelectedValue	= tool.FormatDate_Month(CL_DUEDATE);}
			catch{}
			TXT_CL_LOGBOOKNO.Text	= conn.GetFieldValue("CL_LOGBOOKNO");
			TXT_CL_GUARANTEEVAL.Text	= tool.MoneyFormat(conn.GetFieldValue("CL_GUARANTEEVAL"));
			TXT_CL_GUARANTEENAME.Text	= conn.GetFieldValue("CL_GUARANTEENAME");
			//DDL_CL_VALACCRDTO.SelectedValue	= conn.GetFieldValue("CL_VALACCRDTO");
			try{DDL_CL_JNSAGUNAN.SelectedValue	= conn.GetFieldValue("CL_JNSAGUNAN");}
			catch{}
			try{DDL_CL_VALACCRDTO.SelectedValue	= conn.GetFieldValue("CL_VALACCRDTO");}
			catch{}

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
			DDL_CL_RELATIONSHIP.Items.Add(new ListItem("- PILIH -", ""));
			DDL_CL_CONTRACTDATEMONTH.Items.Add(new ListItem("- PILIH -", ""));
			DDL_CL_DUEDATEMONTH.Items.Add(new ListItem("- PILIH -", ""));
			DDL_CL_VALACCRDTO.Items.Add(new ListItem("- PILIH -", ""));
			DDL_CL_JNSAGUNAN.Items.Add(new ListItem("- PILIH -", ""));

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
				DDL_CL_CONTRACTDATEMONTH.Items.Add(new ListItem(DateAndTime.MonthName(i, false), i.ToString()));
				DDL_CL_DUEDATEMONTH.Items.Add(new ListItem(DateAndTime.MonthName(i, false), i.ToString()));
			}

			//--- Mata Uang
			////////////////////////////////////////////////////////////////////
			conn.QueryString = "select CURRENCYID, CURRENCYID + ' - ' + CURRENCYDESC as CURRENCYDESC from RFCURRENCY where ACTIVE = '1' order by CURRENCYID";
			conn.ExecuteQuery();
			for (int i=0; i< conn.GetRowCount(); i++)
				DDL_CL_CURRENCY.Items.Add(new ListItem(conn.GetFieldValue(i, 1), conn.GetFieldValue(i, 0)));
				
			////////////////////////////////////////////////////////////////////
			conn.QueryString = "select COLCLASSID, COLCLASSDESC from RFCOLLCLASS where  active='1'";
			conn.ExecuteQuery();
			for (int i=0; i< conn.GetRowCount(); i++)
				DDL_CL_COLCLASSIFY.Items.Add(new ListItem(conn.GetFieldValue(i, 1), conn.GetFieldValue(i, 0)));

			//--- Hubungan
			////////////////////////////////////////////////////////////////////
			conn.QueryString = "select RELTYPEID, RELTYPEID+' - '+RELTYPEDESC from RFRELATIONSHIP where active='1'";
			conn.ExecuteQuery();
			for (int i=0; i< conn.GetRowCount(); i++)
				DDL_CL_RELATIONSHIP.Items.Add(new ListItem(conn.GetFieldValue(i, 1), conn.GetFieldValue(i, 0)));

			////////////////////////////////////////////////////////////////////
			conn.QueryString = "select ACCRDTOID, ACCRDTODESC from RFVALUEACCORDING where active='1'";
			conn.ExecuteQuery();
			for (int i=0; i< conn.GetRowCount(); i++)
				DDL_CL_VALACCRDTO.Items.Add(new ListItem(conn.GetFieldValue(i, 1), conn.GetFieldValue(i, 0)));

			//--- Jenis Agunan
			////////////////////////////////////////////////////////////////////
			conn.QueryString = "select AGUNANID, AGUNANID + ' - ' + AGUNANDESC AS AGUNANDESC from RFJENISAGUNAN WHERE ACTIVE='1' order by AGUNANID";
			//"where COLTYPEID = '"+ CL_TYPE +"'";
			conn.ExecuteQuery();
			for (int i=0; i< conn.GetRowCount(); i++)
				DDL_CL_JNSAGUNAN.Items.Add(new ListItem(conn.GetFieldValue(i, 1), conn.GetFieldValue(i, 0)));
				
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
			if (TXT_CL_DESC.Text!="" &&
				DDL_CL_CURRENCY.SelectedValue!="" &&				
				DDL_CL_COLCLASSIFY.SelectedValue!="" &&
				DDL_CL_JNSAGUNAN.SelectedValue!="" &&
				DDL_CL_VALACCRDTO.SelectedValue!="" &&
				ddl_posisi.SelectedValue!="" &&
				TXT_CL_GUARANTEEVAL.Text!="" &&
				TXT_CL_GUARANTEENAME.Text!="" &&
				TXT_CL_CONTRACTDATEDAY.Text!="" &&
				TXT_CL_CONTRACTDATEYEAR.Text!="" &&
				TXT_CL_VALUE.Text!="" &&
				TXT_CL_VALUE2.Text!="")
			{
				SaveData();
			}
		}

		private void SaveData()
		{
			
			conn.QueryString = "exec MAS_CHANGE_COL_pg 'save'," +
				"'"+ Request.QueryString["acc_number"] +"','"+ Request.QueryString["collateral_id"] +"','"+ Request.QueryString["type"]+"'," +
				"'" + DDL_CL_RELATIONSHIP.SelectedValue + "','" + TXT_CL_LOGBOOKNO.Text +"'," + tool.ConvertFloat(TXT_CL_GUARANTEEVAL.Text) + "," +
				tool.ConvertDate(TXT_CL_CONTRACTDATEDAY.Text, DDL_CL_CONTRACTDATEMONTH.SelectedValue, TXT_CL_CONTRACTDATEYEAR.Text) + "," +
				tool.ConvertDate(TXT_CL_DUEDATEDAY.Text, DDL_CL_DUEDATEMONTH.SelectedValue, TXT_CL_DUEDATEYEAR.Text) + "," +
				"'" + DDL_CL_VALACCRDTO.SelectedValue + "','" + TXT_CL_GUARANTEENAME.Text +"',"+
				"'"+ DDL_CL_JNSAGUNAN.SelectedValue +"',NULL,NULL,'','',"+
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
				"'" + Session["userID"] + "','" + TXT_BAST_KE_CA.Text + "','" + TXT_BAST_DARI_CA.Text + "','" + ddl_posisi.SelectedValue + "','" + lbl_pg.Text +"'";
			conn.ExecuteQuery();
		}
	
		protected void BTN_FINISH_Click(object sender, System.EventArgs e)
		{
			conn.QueryString = "exec MAS_COLLATERAL_TRACKUPDATE '" +
				LBL_REGNO.Text + "' , '" + 
				TXT_SIBS_COLID.Text + "' , 'M1.8' , '" + 
				Session["UserID"].ToString() + "' , '', '6', '" + Request.QueryString["status"] +"'";
			conn.ExecuteQuery();
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
