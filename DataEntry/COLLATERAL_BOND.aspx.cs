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

namespace SME.DataEntry
{
	/// <summary>
	/// Summary description for COLLATERAL_BOND.
	/// </summary>
	public partial class COLLATERAL_BOND : System.Web.UI.Page
	{
		//protected Connection conn = new Connection("Data Source=10.123.12.30;Initial Catalog=SMEDEV;uid=sa;pwd=");
		protected Tools tool = new Tools();
		//protected System.Web.UI.WebControls.TextBox TXT_CL_MARKETVALUE;
		protected Connection conn;
		
		protected void Page_Load(object sender, System.EventArgs e)
		{
			conn = (Connection) Session["Connection"];

            //BPMCAO -- BPSMAO
            conn.QueryString = "SELECT SCGROUP.GROUPID FROM SCUSER, SCGROUP WHERE SCUSER.GROUPID = SCGROUP.GROUPID AND SCUSER.USERID = '" + Session["UserID"] + "'";
            conn.ExecuteQuery();

            if (conn.GetFieldValue(0, 0) == "BPSMAO" || conn.GetFieldValue(0, 0) == "BPMCAO")
            {
                TR_NILAI_ASURANSI.Visible = false;
                TR_NILAI_BANK.Visible = false;
                TR_NILAI_LIKUIDASI.Visible = false;
                TR_NILAI_PASAR.Visible = false;
                TR_NILAI_PENGIKATAN.Visible = false;
                TR_NILAI_PENGURANG_PPA.Visible = false;
            }

			if (!IsPostBack)
			{
				LBL_REGNO.Text	= Request.QueryString["regno"];
				LBL_CUREF.Text	= Request.QueryString["curef"];
				LBL_TC.Text		= Request.QueryString["tc"];
				LBL_CL_SEQ.Text	= Request.QueryString["CL_SEQ"];
				int CL_TYPE	= Convert.ToInt16(Request.QueryString["coltypeid"]);

				DDL_CL_CURRENCY.Items.Add(new ListItem("- PILIH -", ""));
				DDL_CL_COLCLASSIFY.Items.Add(new ListItem("- PILIH -", ""));
				DDL_CL_BONDTYPE.Items.Add(new ListItem("- PILIH -", ""));
				DDL_CL_RELATIONSHIP.Items.Add(new ListItem("- PILIH -", ""));
				DDL_CL_REGDATEMONTH.Items.Add(new ListItem("- PILIH -", ""));
				DDL_CL_ISSUEDDATEMONTH.Items.Add(new ListItem("- PILIH -", ""));
				DDL_CL_DUEDATEMONTH.Items.Add(new ListItem("- PILIH -", ""));
				DDL_CL_IKATTYPE.Items.Add(new ListItem("- PILIH -", ""));
				DDL_CL_VALACCRDTO.Items.Add(new ListItem("- PILIH -", ""));
				DDL_CL_PERINGKAT.Items.Add(new ListItem("- PILIH -", ""));
				DDL_CL_JNSAGUNAN.Items.Add(new ListItem("- PILIH -", ""));

				for (int i=1; i<=12; i++)
				{
					DDL_CL_REGDATEMONTH.Items.Add(new ListItem(DateAndTime.MonthName(i, false), i.ToString()));
					DDL_CL_ISSUEDDATEMONTH.Items.Add(new ListItem(DateAndTime.MonthName(i, false), i.ToString()));
					DDL_CL_DUEDATEMONTH.Items.Add(new ListItem(DateAndTime.MonthName(i, false), i.ToString()));
				}
				
				string de = Request.QueryString["de"];
				
				//--- Mata Uang
				if (de != "1")  conn.QueryString = "select CURRENCYID, CURRENCYID + ' - ' + CURRENCYDESC as CURRENCYDESC from RFCURRENCY  order by CURRENCYID";
				else conn.QueryString = "select CURRENCYID, CURRENCYID + ' - ' + CURRENCYDESC as CURRENCYDESC from RFCURRENCY where ACTIVE = '1' order by CURRENCYID";
				conn.ExecuteQuery();
				for (int i=0; i< conn.GetRowCount(); i++)
					DDL_CL_CURRENCY.Items.Add(new ListItem(conn.GetFieldValue(i, 1), conn.GetFieldValue(i, 0)));

				if (de != "1") conn.QueryString = "select COLCLASSID, COLCLASSDESC from RFCOLLCLASS ";
				else conn.QueryString = "select COLCLASSID, COLCLASSDESC from RFCOLLCLASS where active='1'";
				conn.ExecuteQuery();
				for (int i=0; i< conn.GetRowCount(); i++)
					DDL_CL_COLCLASSIFY.Items.Add(new ListItem(conn.GetFieldValue(i, 1), conn.GetFieldValue(i, 0)));

				//--- Hubungan
				if (de != "1") conn.QueryString = "select RELTYPEID, RELTYPEID+' - '+RELTYPEDESC from RFRELATIONSHIP ";
				else conn.QueryString = "select RELTYPEID, RELTYPEID+' - '+RELTYPEDESC from RFRELATIONSHIP where active='1'";
				conn.ExecuteQuery();
				for (int i=0; i< conn.GetRowCount(); i++)
					DDL_CL_RELATIONSHIP.Items.Add(new ListItem(conn.GetFieldValue(i, 1), conn.GetFieldValue(i, 0)));

				//--- Jenis Pengikatan
				if (de != "1") conn.QueryString = "select IKATID, IKATID + ' - ' + IKATDESC AS IKATDESC from RFIKAT  order by IKATID";
				else conn.QueryString = "select IKATID, IKATID + ' - ' + IKATDESC AS IKATDESC from RFIKAT where active = '1' order by IKATID";
				conn.ExecuteQuery();
				for (int i=0; i< conn.GetRowCount(); i++)
					DDL_CL_IKATTYPE.Items.Add(new ListItem(conn.GetFieldValue(i, 1), conn.GetFieldValue(i, 0)));
				
				if (de != "1") conn.QueryString = "select ACCRDTOID, ACCRDTODESC from RFVALUEACCORDING ";
				else conn.QueryString = "select ACCRDTOID, ACCRDTODESC from RFVALUEACCORDING where active='1'";
				conn.ExecuteQuery();
				for (int i=0; i< conn.GetRowCount(); i++)
					DDL_CL_VALACCRDTO.Items.Add(new ListItem(conn.GetFieldValue(i, 1), conn.GetFieldValue(i, 0)));

				//--- Jenis Agunan
				if (de != "1") conn.QueryString = "select AGUNANID, AGUNANID + ' - ' + AGUNANDESC AS AGUNANDESC from RFJENISAGUNAN  order by AGUNANID";
				else conn.QueryString = "select AGUNANID, AGUNANID + ' - ' + AGUNANDESC AS AGUNANDESC from RFJENISAGUNAN WHERE ACTIVE ='1' order by AGUNANID";
					//"where COLTYPEID = '"+ CL_TYPE +"'";
				conn.ExecuteQuery();
				for (int i=0; i< conn.GetRowCount(); i++)
					DDL_CL_JNSAGUNAN.Items.Add(new ListItem(conn.GetFieldValue(i, 1), conn.GetFieldValue(i, 0)));

				//--- Peringkat Surat Berharga
				if (de != "1")  conn.QueryString = "select PSBID, PSBID + ' - ' + PSBDESC AS PSBDESC from RFPERINGKATSRTHRG  order by PSBID";
				else conn.QueryString = "select PSBID, PSBID + ' - ' + PSBDESC AS PSBDESC from RFPERINGKATSRTHRG where ACTIVE='1' order by PSBID";
				conn.ExecuteQuery();
				for (int i = 0; i < conn.GetRowCount(); i++)
					DDL_CL_PERINGKAT.Items.Add(new ListItem(conn.GetFieldValue(i,1), conn.GetFieldValue(i,0)));

				if (de != "1") conn.QueryString = "select * from RFBONDTYPE ";
				else conn.QueryString = "select * from RFBONDTYPE where active='1'";
				conn.ExecuteQuery();
				for (int i = 0; i < conn.GetRowCount(); i++)
					DDL_CL_BONDTYPE.Items.Add(new ListItem(conn.GetFieldValue(i,1), conn.GetFieldValue(i,0)));

				ViewData();

				//this.SecureData();
			}
			else
			{
				Update();
				this.updateCollStatus();		
			}
		}

		private void updateCollStatus() 
		{
			//------ Jika ingin melakukan appraisal ----------
			//------ status collateral ubah jadi '3' --------
			if (Request.QueryString["appr"] == "1") 
			{
				conn.QueryString = "exec VA_APPR_COLL_STATUS '" + Request.QueryString["regno"] + "','" + Request.QueryString["curef"] + "','" + Request.QueryString["CL_SEQ"] + "'";
				conn.ExecuteNonQuery();
			}
			//------------------------------------------------
		}

		private void SecureData() 
		{
			// Jika yang memanggil bukan dalam scope DataEntry, maka disable semua control input
			// Flag :
			//		Nama  = de
			//		Value ==  1 --> Parent DataEntry
			//			  !=  1 --> Parent non-DataEntry
			string de = Request.QueryString["de"];
			if (de != "1") 
			{
				System.Web.UI.ControlCollection coll = this.Page.Controls;
				for (int i = 0; i < coll[4].Controls.Count; i++) 
				{
					if (coll[4].Controls[i] is TextBox) 
					{
						TextBox txt = (TextBox) coll[4].Controls[i];
						txt.ReadOnly = true;
						//txt.Enabled = false;
					}
					else if (coll[4].Controls[i] is DropDownList) 
					{
						DropDownList ddl = (DropDownList) coll[4].Controls[i];
						ddl.Enabled = false;
					}
					else if (coll[4].Controls[i] is Button)
					{
						Button btn = (Button) coll[4].Controls[i];
						//btn.Enabled = false;
						btn.Visible = false;
					}
					else if (coll[4].Controls[i] is RadioButtonList) 
					{
						RadioButtonList rbl = (RadioButtonList) coll[4].Controls[i];
						rbl.Enabled = false;
					}
					else if (coll[4].Controls[i] is RadioButton) 
					{
						RadioButton rb = (RadioButton) coll[4].Controls[i];
						rb.Enabled = false;
					}
					else if (coll[4].Controls[i] is CheckBox)
					{
						CheckBox cb = (CheckBox) coll[4].Controls[i];
						cb.Enabled = false;
					}					
					else if (coll[4].Controls[i] is DataGrid) 
					{						
						DataGrid dg = (DataGrid) coll[4].Controls[i];						
						/*
						try 
						{
							for(int j=0; j < dg.Items.Count; j++) 
							{
								dg.Items[i].Enabled	= false;
							}
						}
						catch (ArgumentOutOfRangeException ex) 
						{
							// ignore...
						}
						*/
					}
					else if (coll[4].Controls[i] is HtmlTableRow) 
					{
						HtmlTableRow htr = (HtmlTableRow) coll[4].Controls[i];
						//htr.Disabled = true;	

						for (int j=0; j < htr.Controls.Count; j++) 
						{							
							for (int jj = 0; jj < htr.Controls[j].Controls.Count; jj++) 
							{
								if (htr.Controls[j].Controls[jj] is TextBox) 
								{
									TextBox txt = (TextBox) htr.Controls[j].Controls[jj];
									txt.ReadOnly = true;
									//txt.Enabled = false;
								}
								else if (htr.Controls[j].Controls[jj] is DropDownList) 
								{
									DropDownList ddl = (DropDownList) htr.Controls[j].Controls[jj];
									ddl.Enabled = false;
								}
								else if (htr.Controls[j].Controls[jj] is Button)
								{
									Button btn = (Button) htr.Controls[j].Controls[jj];
									//btn.Enabled = false;
									btn.Visible = false;
								}
								else if (htr.Controls[j].Controls[jj] is RadioButtonList) 
								{
									RadioButtonList rbl = (RadioButtonList) htr.Controls[j].Controls[jj];
									rbl.Enabled = false;
								}
								else if (htr.Controls[j].Controls[jj] is RadioButton) 
								{
									RadioButton rb = (RadioButton) htr.Controls[j].Controls[jj];
									rb.Enabled = false;
								}
								else if (htr.Controls[j].Controls[jj] is CheckBox)
								{
									CheckBox cb = (CheckBox) htr.Controls[j].Controls[jj];
									cb.Enabled = false;
								}					
							}
						}
					}
				}
			}
		}
		private void ViewData()
		{
			conn.QueryString = "select * from VW_COLL_BOND "+
				"where CUREF ='" + LBL_CUREF.Text + "' and CLSEQ = "+ Convert.ToInt16(LBL_CL_SEQ.Text);
			conn.ExecuteQuery();

			TXT_CL_VALUE.Text			= tool.MoneyFormat(conn.GetFieldValue("CL_PROPVALUE"));
			TXT_CL_VALUE2.Text			= tool.MoneyFormat(conn.GetFieldValue("CL_VALUE2"));
			TXT_CL_VALUEINS.Text			= tool.MoneyFormat(conn.GetFieldValue("CL_VALUEINS"));
			TXT_CL_VALUEIKAT.Text			= tool.MoneyFormat(conn.GetFieldValue("CL_VALUEIKAT"));
			TXT_CL_VALUEPPA.Text			= tool.MoneyFormat(conn.GetFieldValue("CL_VALUEPPA"));
			TXT_CL_VALUELIQ.Text			= tool.MoneyFormat(conn.GetFieldValue("CL_VALUELIQ"));
			TXT_CL_DESC.Text			= conn.GetFieldValue("CL_DESC");
			TXT_CL_OWNER.Text			= conn.GetFieldValue("CL_OWNER");
			try{DDL_CL_CURRENCY.SelectedValue		= conn.GetFieldValue("CL_CURRENCY");}
			catch{}
			try{DDL_CL_COLCLASSIFY.SelectedValue	= conn.GetFieldValue("CL_COLCLASSIFY");}
			catch{}
			TXT_SIBS_COLID.Text			= conn.GetFieldValue("SIBS_COLID");
			try{DDL_CL_RELATIONSHIP.SelectedValue	= conn.GetFieldValue("CL_RELATIONSHIP");}
			catch{}
			try{DDL_CL_BONDTYPE.SelectedValue		= conn.GetFieldValue("CL_BONDTYPE");}
			catch{}
			
			if (conn.GetFieldValue("CL_ISCASHEDVALUE") == "1")
				CHB_CL_ISCASHEDVALUE.Checked = true;
			TXT_CL_REGNO.Text			= conn.GetFieldValue("CL_REGNO");
			TXT_CL_SECURITYNO.Text		= conn.GetFieldValue("CL_SECURITYNO");

			//TXT_CL_MARKETVALUE.Text		= tool.MoneyFormat(conn.GetFieldValue("CL_MARKETVALUE"));
			//if (TXT_CL_MARKETVALUE.Text == "0,00")
			//	TXT_CL_MARKETVALUE.Text = TXT_CL_VALUE.Text;
			
			string CL_REGDATE			= conn.GetFieldValue("CL_REGDATE");
			TXT_CL_REGDATEDAY.Text		= tool.FormatDate_Day(CL_REGDATE);
			try{DDL_CL_REGDATEMONTH.SelectedValue	= tool.FormatDate_Month(CL_REGDATE);}
			catch{}
			TXT_CL_REGDATEYEAR.Text		= tool.FormatDate_Year(CL_REGDATE);
			TXT_CL_ISSUEDBY.Text		= conn.GetFieldValue("CL_ISSUEDBY");
			string CL_ISSUEDDATE		= conn.GetFieldValue("CL_ISSUEDDATE");
			TXT_CL_ISSUEDDATEDAY.Text	= tool.FormatDate_Day(CL_ISSUEDDATE);
			try{DDL_CL_ISSUEDDATEMONTH.SelectedValue	= tool.FormatDate_Month(CL_ISSUEDDATE);}
			catch{}
			TXT_CL_ISSUEDDATEYEAR.Text	= tool.FormatDate_Year(CL_ISSUEDDATE);
			string CL_DUEDATE			= conn.GetFieldValue("CL_DUEDATE");
			TXT_CL_DUEDATEDAY.Text		= tool.FormatDate_Day(CL_DUEDATE);
			try{DDL_CL_DUEDATEMONTH.SelectedValue	= tool.FormatDate_Month(CL_DUEDATE);}
			catch{}
			TXT_CL_DUEDATEYEAR.Text		= tool.FormatDate_Year(CL_DUEDATE);
			TXT_CL_CONDITION.Text		= conn.GetFieldValue("CL_CONDITION");
			TXT_CL_COLLAMOUNT.Text		= tool.MoneyFormat(conn.GetFieldValue("CL_COLLAMOUNT"));
			try{DDL_CL_IKATTYPE.SelectedValue	= conn.GetFieldValue("CL_IKATTYPE");}
			catch{}
			try{DDL_CL_PERINGKAT.SelectedValue	= conn.GetFieldValue("CL_PERINGKAT");}
			catch{}
			try{DDL_CL_JNSAGUNAN.SelectedValue	= conn.GetFieldValue("CL_JNSAGUNAN");}
			catch{}
			
			string CL_VALACCRDTO = conn.GetFieldValue("CL_VALACCRDTO");
			conn.QueryString = "select isnull(LA_APPRTYPE,'0') from LISTASSIGNMENT where AP_REGNO = '"+Request.QueryString["regno"]+
							"' and CU_REF = '" +Request.QueryString["curef"]+ "' and CL_SEQ = "+Convert.ToInt16(LBL_CL_SEQ.Text);
			conn.ExecuteQuery();
			if (conn.GetRowCount() != 0)
			{
					if (conn.GetFieldValue(0,0) == "1")
				 CL_VALACCRDTO = "2";
			 else if (conn.GetFieldValue(0,0) == "0" || conn.GetFieldValue(0,0) == "2")
				 CL_VALACCRDTO = "1";
			}
			try{DDL_CL_VALACCRDTO.SelectedValue	= CL_VALACCRDTO.ToString().Trim();}
			catch{}
		}

		private void Update()
		{
			if (DDL_CL_RELATIONSHIP.SelectedValue.Trim() != "" && TXT_CL_OWNER.Text.Trim() == "")
				Tools.popMessage(this,"Nama Pemilik Tidak Boleh Kosong !!");
			else
			{
				try 
				{
					conn.QueryString = "exec DE_COLL_BOND '"+ LBL_CUREF.Text +"', "+ LBL_CL_SEQ.Text +", 0, "+
						tool.ConvertFloat(TXT_CL_VALUE.Text) +", "+ 
						tool.ConvertFloat(TXT_CL_VALUE2.Text) +", "+ tool.ConvertFloat(TXT_CL_VALUEINS.Text) +", "+ tool.ConvertFloat(TXT_CL_VALUEIKAT.Text) +", "+ tool.ConvertFloat(TXT_CL_VALUEPPA.Text) +", "+ tool.ConvertFloat(TXT_CL_VALUELIQ.Text) +", '"+ 
						TXT_CL_DESC.Text +"', "+ tool.ConvertNull(DDL_CL_CURRENCY.SelectedValue) +", "+ 
						tool.ConvertNull(DDL_CL_COLCLASSIFY.SelectedValue) +", '"+ TXT_SIBS_COLID.Text +"', '"+ DDL_CL_BONDTYPE.SelectedValue +"', '"+
						tool.ConvertFlag(CHB_CL_ISCASHEDVALUE.Checked) +"', '"+ TXT_CL_REGNO.Text +"', '"+ TXT_CL_SECURITYNO.Text +"', "+
						/*tool.ConvertFloat(TXT_CL_MARKETVALUE.Text)*/tool.ConvertFloat(TXT_CL_VALUE2.Text) +", "+
						tool.ConvertDate(TXT_CL_REGDATEDAY.Text, DDL_CL_REGDATEMONTH.SelectedValue, TXT_CL_REGDATEYEAR.Text) +", '"+
						TXT_CL_ISSUEDBY.Text +"', "+
						tool.ConvertDate(TXT_CL_ISSUEDDATEDAY.Text, DDL_CL_ISSUEDDATEMONTH.SelectedValue, TXT_CL_ISSUEDDATEYEAR.Text) +", "+
						tool.ConvertDate(TXT_CL_DUEDATEDAY.Text, DDL_CL_DUEDATEMONTH.SelectedValue, TXT_CL_DUEDATEYEAR.Text) +", '"+
						TXT_CL_CONDITION.Text +"', '"+ TXT_CL_OWNER.Text +"', "+ tool.ConvertNull(DDL_CL_RELATIONSHIP.SelectedValue) +", "+ 
						tool.ConvertFloat(TXT_CL_COLLAMOUNT.Text) +", "+ tool.ConvertNull(DDL_CL_IKATTYPE.SelectedValue) +", "+
						tool.ConvertNull(DDL_CL_VALACCRDTO.SelectedValue) +", "+ tool.ConvertNull(DDL_CL_PERINGKAT.SelectedValue) +", "+
						tool.ConvertNull(DDL_CL_JNSAGUNAN.SelectedValue)+", '"+LBL_REGNO.Text+ "'";
					conn.ExecuteNonQuery();
				} 
				catch 
				{
					Tools.popMessage(this, "Input tidak valid !");
					return;
				}
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
	}
}
