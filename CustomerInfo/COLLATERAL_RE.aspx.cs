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

namespace SME.CustomerInfo
{
	/// <summary>
	/// Summary description for Jaminan_RealEstate.
	/// </summary>
	public partial class Jaminan_RealEstate : System.Web.UI.Page
	{
		protected Tools tool = new Tools();
		protected System.Web.UI.WebControls.PlaceHolder Placeholder1;
		//protected System.Web.UI.WebControls.TextBox TXT_CL_RESULTVAL;
		//protected System.Web.UI.WebControls.TextBox TXT_CL_MARKETVAL;
		//protected System.Web.UI.WebControls.TextBox TXT_CL_PPAPVAL;
		protected Connection conn;
		
		protected void Page_Load(object sender, System.EventArgs e)
		{
			conn = (Connection) Session["Connection"];

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
				DDL_CL_CERTTYPE1.Items.Add(new ListItem("- PILIH -", ""));
				DDL_CL_CERTTYPE2.Items.Add(new ListItem("- PILIH -", ""));
				DDL_CL_PROPTYPE.Items.Add(new ListItem("- PILIH -", ""));
				DDL_CL_CERTISSUEMONTH.Items.Add(new ListItem("- PILIH -", ""));
				DDL_CL_CERTEXPIREMONTH.Items.Add(new ListItem("- PILIH -", ""));
				DDL_CL_RELATIONSHIP.Items.Add(new ListItem("- PILIH -", ""));
				DDL_CL_DEVELOPER.Items.Add(new ListItem("- PILIH -", ""));
				DDL_CL_COLLOC.Items.Add(new ListItem("- PILIH -", ""));
				DDL_CL_VALACCRDTO.Items.Add(new ListItem("- PILIH -", ""));
				DDL_CL_JNSAGUNAN.Items.Add(new ListItem("- PILIH -", ""));

				for (int i=1 ; i<=12; i++)
				{
					DDL_CL_CERTISSUEMONTH.Items.Add(new ListItem(DateAndTime.MonthName(i, false), i.ToString()));
					DDL_CL_CERTEXPIREMONTH.Items.Add(new ListItem(DateAndTime.MonthName(i, false), i.ToString()));
				}
				
				//--- Mata Uang
				conn.QueryString = "select CURRENCYID, CURRENCYID + ' - ' + CURRENCYDESC as CURRENCYDESC from RFCURRENCY where ACTIVE = '1'";
				conn.ExecuteQuery();
				for (int i=0; i< conn.GetRowCount(); i++)
					DDL_CL_CURRENCY.Items.Add(new ListItem(conn.GetFieldValue(i, 1), conn.GetFieldValue(i, 0)));

				conn.QueryString = "select COLCLASSID, COLCLASSDESC from RFCOLLCLASS where active='1'";
				conn.ExecuteQuery();
				for (int i=0; i< conn.GetRowCount(); i++)
					DDL_CL_COLCLASSIFY.Items.Add(new ListItem(conn.GetFieldValue(i, 1), conn.GetFieldValue(i, 0)));

				conn.QueryString = "select CERTTYPEID, CERTTYPEID + ' - ' + CERTTYPEDESC as CERTTYPEDESC from RFCERTTYPE where COLFLAG='RE' and active = '1' order by CERTTYPEID";
				conn.ExecuteQuery();
				for (int i=0; i< conn.GetRowCount(); i++)
				{
					DDL_CL_CERTTYPE1.Items.Add(new ListItem(conn.GetFieldValue(i, 1), conn.GetFieldValue(i, 0)));
					DDL_CL_CERTTYPE2.Items.Add(new ListItem(conn.GetFieldValue(i, 1), conn.GetFieldValue(i, 0)));
				}

				//--- Property Type
				conn.QueryString = "select PROPTYPEID, PROPTYPEID + ' - ' + PROPTYPEDESC as PROPTYPEDESC from RFPROPTYPE where ACTIVE='1' order by PROPTYPEID";
				conn.ExecuteQuery();
				for (int i=0; i< conn.GetRowCount(); i++)
					DDL_CL_PROPTYPE.Items.Add(new ListItem(conn.GetFieldValue(i, 1), conn.GetFieldValue(i, 0)));

				//--- Hubungan
				conn.QueryString = "select RELTYPEID, RELTYPEID+' - '+RELTYPEDESC from RFRELATIONSHIP where ACTIVE = '1'";
				conn.ExecuteQuery();
				for (int i=0; i< conn.GetRowCount(); i++)
					DDL_CL_RELATIONSHIP.Items.Add(new ListItem(conn.GetFieldValue(i, 1), conn.GetFieldValue(i, 0)));

				conn.QueryString = "select DEVELOPERID, DEVELOPERDESC from RFDEVELOPER where active = '1'";
				conn.ExecuteQuery();
				for (int i=0; i< conn.GetRowCount(); i++)
					DDL_CL_DEVELOPER.Items.Add(new ListItem(conn.GetFieldValue(i, 1), conn.GetFieldValue(i, 0)));

				//--- Lokasi Agunan
				conn.QueryString = "select LOCATIONID, LOCATIONID + ' - ' + LOCATIONDESC as LOCATIONDESC from RFCOLLOCATION where ACTIVE='1' order by LOCATIONID";
				conn.ExecuteQuery();
				for (int i=0; i< conn.GetRowCount(); i++)
					DDL_CL_COLLOC.Items.Add(new ListItem(conn.GetFieldValue(i, 1), conn.GetFieldValue(i, 0)));

				conn.QueryString = "select ACCRDTOID, ACCRDTODESC from RFVALUEACCORDING where ACTIVE = '1'";
				conn.ExecuteQuery();
				for (int i=0; i< conn.GetRowCount(); i++)
					DDL_CL_VALACCRDTO.Items.Add(new ListItem(conn.GetFieldValue(i, 1), conn.GetFieldValue(i, 0)));

				//--- Jenis Agunan
				conn.QueryString = "select AGUNANID, AGUNANID + ' - ' + AGUNANDESC AS AGUNANDESC from RFJENISAGUNAN WHERE ACTIVE = '1' order by AGUNANID";
					//"where COLTYPEID = '"+ CL_TYPE +"'";
				conn.ExecuteQuery();
				for (int i=0; i< conn.GetRowCount(); i++)
					DDL_CL_JNSAGUNAN.Items.Add(new ListItem(conn.GetFieldValue(i, 1), conn.GetFieldValue(i, 0)));
			
				ViewData();

				this.SecureData();
				
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

//				conn.QueryString = "update LISTASSIGNMENT set LA_APPRSTATUS = '3' where AP_REGNO = '" + Request.QueryString["regno"] + "' AND CU_REF = '" + Request.QueryString["curef"] + "' AND CL_SEQ = '" + Request.QueryString["CL_SEQ"] +"'";
//				conn.ExecuteQuery();

				//Response.Write("<script language='javascript'>alert('Collateral status updated!');</script>");				
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
			conn.QueryString = "select * from VW_COLL_RE "+
				"where CUREF ='" + LBL_CUREF.Text + "' and CLSEQ = "+ Convert.ToInt16(LBL_CL_SEQ.Text);
			conn.ExecuteQuery();
			
			TXT_CL_VALUE.Text			= tool.MoneyFormat(conn.GetFieldValue("CL_PROPVALUE"));
			TXT_CL_VALUE2.Text			= tool.MoneyFormat(conn.GetFieldValue("CL_VALUE2"));
			TXT_CL_VALUEINS.Text		= tool.MoneyFormat(conn.GetFieldValue("CL_VALUEINS"));
			TXT_CL_VALUEIKAT.Text		= tool.MoneyFormat(conn.GetFieldValue("CL_VALUEIKAT"));
			TXT_CL_VALUEPPA.Text		= tool.MoneyFormat(conn.GetFieldValue("CL_VALUEPPA"));
			TXT_CL_VALUELIQ.Text		= tool.MoneyFormat(conn.GetFieldValue("CL_VALUELIQ"));
			TXT_CL_DESC.Text			= conn.GetFieldValue("CL_DESC");
			TXT_CL_CERTNO.Text			= conn.GetFieldValue("CL_CERTNO");
			string CL_CERTISSUE			= conn.GetFieldValue("CL_CERTISSUE");
			TXT_CL_CERTISSUEDAY.Text	= tool.FormatDate_Day(CL_CERTISSUE);
			DDL_CL_CERTISSUEMONTH.SelectedValue	= tool.FormatDate_Month(CL_CERTISSUE);
			TXT_CL_CERTISSUEYEAR.Text	= tool.FormatDate_Year(CL_CERTISSUE);
			string CL_CERTEXPIRE		= conn.GetFieldValue("CL_CERTEXPIRE");
			TXT_CL_CERTEXPIREDAY.Text	= tool.FormatDate_Day(CL_CERTEXPIRE);
			DDL_CL_CERTEXPIREMONTH.SelectedValue	= tool.FormatDate_Month(CL_CERTEXPIRE);
			TXT_CL_CERTEXPIREYEAR.Text	= tool.FormatDate_Year(CL_CERTEXPIRE);
			TXT_CL_LANDAREA.Text		= conn.GetFieldValue("CL_LANDAREA");
			TXT_CL_BUILDAREA.Text		= conn.GetFieldValue("CL_BUILDAREA");
			TXT_CL_OWNER.Text			= conn.GetFieldValue("CL_OWNER");
			
			//TXT_CL_RESULTVAL.Text		= tool.MoneyFormat(conn.GetFieldValue("CL_APPRVALUE"));
			//if (TXT_CL_RESULTVAL.Text == "0,00")
			//	TXT_CL_RESULTVAL.Text	= TXT_CL_VALUE.Text;
		
			//TXT_CL_MARKETVAL.Text		= tool.MoneyFormat(conn.GetFieldValue("CL_MARKETVAL"));
			//if (TXT_CL_MARKETVAL.Text == "0,00")
			//	TXT_CL_MARKETVAL.Text	= TXT_CL_VALUE.Text;

			//TXT_CL_PPAPVAL.Text			= tool.MoneyFormat(conn.GetFieldValue("CL_PPAPVAL"));
			//if (TXT_CL_PPAPVAL.Text == "0,00")
			//	TXT_CL_PPAPVAL.Text	= TXT_CL_VALUE.Text;

			TXT_CL_LOCJLN.Text			= conn.GetFieldValue("CL_LOCJLN");
			TXT_CL_LOCRT.Text			= conn.GetFieldValue("CL_LOCRT");
			TXT_CL_LOCRW.Text			= conn.GetFieldValue("CL_LOCRW");
			TXT_CL_LOCKAVNO.Text		= conn.GetFieldValue("CL_LOCKAVNO");
			try{DDL_CL_CURRENCY.SelectedValue		= conn.GetFieldValue("CL_CURRENCY");}
			catch{}
			DDL_CL_COLCLASSIFY.SelectedValue	= conn.GetFieldValue("CL_COLCLASSIFY");
			TXT_SIBS_COLID.Text			= conn.GetFieldValue("SIBS_COLID");
			try{DDL_CL_CERTTYPE1.SelectedValue		= conn.GetFieldValue("CL_CERTTYPE1");}
			catch{}
			try{DDL_CL_CERTTYPE2.SelectedValue		= conn.GetFieldValue("CL_CERTTYPE2");}
			catch{}
			try{DDL_CL_PROPTYPE.SelectedValue		= conn.GetFieldValue("CL_PROPTYPE");}
			catch{}
			DDL_CL_RELATIONSHIP.SelectedValue	= conn.GetFieldValue("CL_RELATIONSHIP");
			DDL_CL_DEVELOPER.SelectedValue		= conn.GetFieldValue("CL_DEVELOPER");
			try{DDL_CL_COLLOC.SelectedValue			= conn.GetFieldValue("CL_COLLOC");}
			catch{}
			DDL_CL_VALACCRDTO.SelectedValue		= conn.GetFieldValue("CL_VALACCRDTO");
			try{DDL_CL_JNSAGUNAN.SelectedValue		= conn.GetFieldValue("CL_JNSAGUNAN");}
			catch{}
		}

		private void Update()
		{
			conn.QueryString = "exec DE_COLL_RE '"+ LBL_CUREF.Text +"', "+ LBL_CL_SEQ.Text +", 0, "+
				tool.ConvertFloat(TXT_CL_VALUE.Text) +", "+ 
				tool.ConvertFloat(TXT_CL_VALUE2.Text) +", "+ tool.ConvertFloat(TXT_CL_VALUEINS.Text) +", "+ tool.ConvertFloat(TXT_CL_VALUEIKAT.Text) +", "+ tool.ConvertFloat(TXT_CL_VALUEPPA.Text) +", "+ tool.ConvertFloat(TXT_CL_VALUELIQ.Text) +", '"+ 
				TXT_CL_DESC.Text +"', "+ tool.ConvertNull(DDL_CL_CURRENCY.SelectedValue) +", "+ 
				tool.ConvertNull(DDL_CL_COLCLASSIFY.SelectedValue) +", '"+ TXT_SIBS_COLID.Text +"', "+ tool.ConvertNull(DDL_CL_CERTTYPE1.SelectedValue) +", "+
				tool.ConvertNull(DDL_CL_CERTTYPE2.SelectedValue) +", "+ tool.ConvertNull(DDL_CL_PROPTYPE.SelectedValue) +", '"+ TXT_CL_CERTNO.Text +"', "+ 
				tool.ConvertDate(TXT_CL_CERTISSUEDAY.Text, DDL_CL_CERTISSUEMONTH.SelectedValue, TXT_CL_CERTISSUEYEAR.Text) +", "+
				tool.ConvertDate(TXT_CL_CERTEXPIREDAY.Text, DDL_CL_CERTEXPIREMONTH.SelectedValue, TXT_CL_CERTEXPIREYEAR.Text) +", "+ 
				tool.ConvertNum(TXT_CL_LANDAREA.Text) +", "+ tool.ConvertNum(TXT_CL_BUILDAREA.Text) +", '"+ 
				TXT_CL_OWNER.Text +"', "+ tool.ConvertNull(DDL_CL_RELATIONSHIP.SelectedValue) +", "+ /*tool.ConvertFloat(TXT_CL_RESULTVAL.Text)*/tool.ConvertFloat(TXT_CL_VALUE.Text) +", "+
				/*tool.ConvertFloat(TXT_CL_MARKETVAL.Text)*/tool.ConvertFloat(TXT_CL_VALUE2.Text) +", "+ /*tool.ConvertFloat(TXT_CL_PPAPVAL.Text)*/tool.ConvertFloat(TXT_CL_VALUEPPA.Text) +", "+ tool.ConvertNull(DDL_CL_DEVELOPER.SelectedValue) +", '"+
				TXT_CL_LOCJLN.Text +"', '"+ TXT_CL_LOCRT.Text +"', '"+ TXT_CL_LOCRW.Text +"', '"+
				TXT_CL_LOCKAVNO.Text +"', "+ tool.ConvertNull(DDL_CL_COLLOC.SelectedValue) +", "+
				tool.ConvertNull(DDL_CL_VALACCRDTO.SelectedValue) +", "+ tool.ConvertNull(DDL_CL_JNSAGUNAN.SelectedValue);
			conn.ExecuteNonQuery();
			ViewData();
			Response.Write("<script language='JavaScript'>window.parent.document.getElementById('scola').src='InfoCollateral.aspx?sta="+Request.QueryString["sta"]+"&curef="+Request.QueryString["curef"]+"&tc="+Request.QueryString["tc"]+"&mc="+Request.QueryString["mc"]+"';</script>");
			Response.Write("<script language='JavaScript'>window.parent.document.getElementById('scol').src='Collateral_List.aspx?sta="+Request.QueryString["sta"]+"&curef="+Request.QueryString["curef"]+"&tc="+Request.QueryString["tc"]+"&mc="+Request.QueryString["mc"]+"';</script>");
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
