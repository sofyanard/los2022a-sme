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
	/// Summary description for COLLATERAL_AR.sadfsadfsdas
	/// </summary>
	public partial class COLLATERAL_AR : System.Web.UI.Page
	{
		protected Tools tool = new Tools();
		protected System.Web.UI.WebControls.TextBox Textbox1;
		protected System.Web.UI.WebControls.TextBox TXTCL_COLLNAME;
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
				string CL_TYPE	= Request.QueryString["coltypeid"];
							
				DDL_CL_CURRENCY.Items.Add(new ListItem("- PILIH -", ""));
				DDL_CL_COLCLASSIFY.Items.Add(new ListItem("- PILIH -", ""));
				DDL_CL_ISSUEDATEMONTH.Items.Add(new ListItem("- PILIH -", ""));
				DDL_CL_REVIEWDATEMONTH.Items.Add(new ListItem("- PILIH -", ""));
				DDL_CL_EXPDATEMONTH.Items.Add(new ListItem("- PILIH -", ""));

				for (int i=1; i<=12; i++)
				{
					DDL_CL_ISSUEDATEMONTH.Items.Add(new ListItem(DateAndTime.MonthName(i, false), i.ToString()));
					DDL_CL_REVIEWDATEMONTH.Items.Add(new ListItem(DateAndTime.MonthName(i, false), i.ToString()));
					DDL_CL_EXPDATEMONTH.Items.Add(new ListItem(DateAndTime.MonthName(i, false), i.ToString()));
				}

				string de = Request.QueryString["de"];
				
				//--- Mata  Uang
				if (de != "1") conn.QueryString = "select CURRENCYID, CURRENCYID + ' - ' + CURRENCYDESC as CURRENCYDESC from RFCURRENCY order by CURRENCYID";
				else conn.QueryString = "select CURRENCYID, CURRENCYID + ' - ' + CURRENCYDESC as CURRENCYDESC from RFCURRENCY where ACTIVE = '1' order by CURRENCYID";
				conn.ExecuteQuery();
				for (int i=0; i< conn.GetRowCount(); i++)
					DDL_CL_CURRENCY.Items.Add(new ListItem(conn.GetFieldValue(i, 1), conn.GetFieldValue(i, 0)));
				
				if (de != "1") conn.QueryString = "select COLCLASSID, COLCLASSDESC from RFCOLLCLASS ";
				else conn.QueryString = "select COLCLASSID, COLCLASSDESC from RFCOLLCLASS where active='1'";
				conn.ExecuteQuery();
				for (int i=0; i< conn.GetRowCount(); i++)
					DDL_CL_COLCLASSIFY.Items.Add(new ListItem(conn.GetFieldValue(i, 1), conn.GetFieldValue(i, 0)));

				string CL_SEQ = LBL_CL_SEQ.Text;
				if (CL_SEQ != "")
					ViewData();
				//his.SecureData();
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
			conn.QueryString = "select * from VW_COLL_AR "+
				"where CUREF ='" + LBL_CUREF.Text + 
					//"' and AP_REGNO = '"+LBL_REGNO.Text+
					"' and CLSEQ = "+ Convert.ToInt16(LBL_CL_SEQ.Text);
			conn.ExecuteQuery();

			TXT_CL_VALUE.Text					= tool.MoneyFormat(conn.GetFieldValue("CL_PROPVALUE"));
			TXT_CL_VALUE2.Text					= tool.MoneyFormat(conn.GetFieldValue("CL_VALUE2"));
			TXT_CL_VALUEINS.Text				= tool.MoneyFormat(conn.GetFieldValue("CL_VALUEINS"));
			TXT_CL_VALUEIKAT.Text				= tool.MoneyFormat(conn.GetFieldValue("CL_VALUEIKAT"));
			TXT_CL_VALUEPPA.Text				= tool.MoneyFormat(conn.GetFieldValue("CL_VALUEPPA"));
			TXT_CL_VALUELIQ.Text				= tool.MoneyFormat(conn.GetFieldValue("CL_VALUELIQ"));
			TXT_CL_DESC.Text					= conn.GetFieldValue("CL_DESC");
			try{DDL_CL_CURRENCY.SelectedValue		= conn.GetFieldValue("CL_CURRENCY");}
			catch{}
			try{DDL_CL_COLCLASSIFY.SelectedValue	= conn.GetFieldValue("CL_COLCLASSIFY");}
			catch{}

			TXT_SIBS_COLID.Text			= conn.GetFieldValue("SIBS_COLID");
			TXT_CL_COLLNAME.Text				= conn.GetFieldValue("CL_COLLNAME");
			string CL_ISSUEDATE					= conn.GetFieldValue("CL_ISSUEDATE");
			TXT_CL_ISSUEDATEDAY.Text			= tool.FormatDate_Day(CL_ISSUEDATE);
			TXT_CL_ISSUEDATEYEAR.Text			= tool.FormatDate_Year(CL_ISSUEDATE);
			try{DDL_CL_ISSUEDATEMONTH.SelectedValue	= tool.FormatDate_Month(CL_ISSUEDATE);}
			catch{}
			string CL_REVIEWDATE				= conn.GetFieldValue("CL_REVIEWDATE");
			TXT_CL_REVIEWDATEDAY.Text			= tool.FormatDate_Day(CL_REVIEWDATE);
			TXT_CL_REVIEWDATEYEAR.Text			= tool.FormatDate_Year(CL_REVIEWDATE);
			try{DDL_CL_REVIEWDATEMONTH.SelectedValue	= tool.FormatDate_Month(CL_REVIEWDATE);}
			catch{}
			TXT_CL_AGINGAMNT.Text				= tool.MoneyFormat(conn.GetFieldValue("CL_AGINGAMNT"));
			string CL_EXPDATE					= conn.GetFieldValue("CL_EXPDATE");
			TXT_CL_EXPDATEDAY.Text				= tool.FormatDate_Day(CL_EXPDATE);
			TXT_CL_EXPDATEYEAR.Text				= tool.FormatDate_Year(CL_EXPDATE);
			try{DDL_CL_EXPDATEMONTH.SelectedValue	= tool.FormatDate_Month(CL_EXPDATE);}
			catch{}
		}

		private void Update()
		{
			try 
			{
				conn.QueryString = "exec DE_COLL_AR '"+ LBL_CUREF.Text +"', "+ LBL_CL_SEQ.Text +", 0, "+
					tool.ConvertFloat(TXT_CL_VALUE.Text) +", "+ 
					tool.ConvertFloat(TXT_CL_VALUE2.Text) +", "+ tool.ConvertFloat(TXT_CL_VALUEINS.Text) +", "+ tool.ConvertFloat(TXT_CL_VALUEIKAT.Text) +", "+ tool.ConvertFloat(TXT_CL_VALUEPPA.Text) +", "+ tool.ConvertFloat(TXT_CL_VALUELIQ.Text) +", '"+ 
					TXT_CL_DESC.Text +"', "+ DDL_CL_CURRENCY.SelectedValue +", "+
					tool.ConvertNull(DDL_CL_COLCLASSIFY.SelectedValue) +", '"+ TXT_SIBS_COLID.Text +"', '"+ TXT_CL_COLLNAME.Text +"', "+ 
					tool.ConvertDate(TXT_CL_ISSUEDATEDAY.Text, DDL_CL_ISSUEDATEMONTH.SelectedValue, TXT_CL_ISSUEDATEYEAR.Text) +", "+
					tool.ConvertDate(TXT_CL_REVIEWDATEDAY.Text, DDL_CL_REVIEWDATEMONTH.SelectedValue, TXT_CL_REVIEWDATEYEAR.Text) +", "+
					tool.ConvertFloat(TXT_CL_AGINGAMNT.Text) +", "+ 
					tool.ConvertDate(TXT_CL_EXPDATEDAY.Text, DDL_CL_EXPDATEMONTH.SelectedValue, TXT_CL_EXPDATEYEAR.Text)+", '"+LBL_REGNO.Text+ "'";		
				conn.ExecuteNonQuery();
			} 
			catch 
			{
				Tools.popMessage(this, "Input tidak valid !");
				return;
			}
			ViewData();
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
