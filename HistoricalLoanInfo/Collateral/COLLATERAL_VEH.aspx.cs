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

namespace SME.HistoricalLoanInfo.Collateral
{
	/// <summary>
	/// Summary description for Jaminan_VEH.
	/// </summary>
	public partial class Jaminan_VEH : System.Web.UI.Page
	{
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
				DDL_CL_DEALER.Items.Add(new ListItem("- PILIH -", ""));
				DDL_CL_CARTYPE.Items.Add(new ListItem("- PILIH -", ""));
				DDL_CL_RELATIONSHIP.Items.Add(new ListItem("- PILIH -", ""));
				DDL_CL_ISSUEDDATEMONTH.Items.Add(new ListItem("- PILIH -", ""));
				DDL_CL_COLLOC.Items.Add(new ListItem("- PILIH -", ""));
				DDL_CL_VALACCRDTO.Items.Add(new ListItem("- PILIH -", ""));
				DDL_CL_JNSAGUNAN.Items.Add(new ListItem("- PILIH -", ""));

				for (int i=1; i<=12; i++)
					DDL_CL_ISSUEDDATEMONTH.Items.Add(new ListItem(DateAndTime.MonthName(i, false), i.ToString()));
				
				//--- Mata Uang
				conn.QueryString = "select CURRENCYID, CURRENCYID + ' - ' + CURRENCYDESC as CURRENCYDESC from RFCURRENCY where ACTIVE = '1' order by currencyid";
				conn.ExecuteQuery();
				for (int i=0; i< conn.GetRowCount(); i++)
					DDL_CL_CURRENCY.Items.Add(new ListItem(conn.GetFieldValue(i, 1), conn.GetFieldValue(i, 0)));
				
				conn.QueryString = "select COLCLASSID, COLCLASSDESC from RFCOLLCLASS where active='1'";
				conn.ExecuteQuery();
				for (int i=0; i< conn.GetRowCount(); i++)
					DDL_CL_COLCLASSIFY.Items.Add(new ListItem(conn.GetFieldValue(i, 1), conn.GetFieldValue(i, 0)));

				//conn.QueryString = "select DEALERID, DEALERDESC from RFDEALER where active='1'";
				conn.QueryString = "select DEALERID,DEALERID + ' - ' + DEALERDESC as DEALERDESC from RFDEALER  where active='1'";
				conn.ExecuteQuery();
				for (int i=0; i< conn.GetRowCount(); i++)
					DDL_CL_DEALER.Items.Add(new ListItem(conn.GetFieldValue(i, 1), conn.GetFieldValue(i, 0)));

				conn.QueryString = "select CARTYPEID, CARTYPEDESC from RFCARTYPE where active='1'";
				conn.ExecuteQuery();
				for (int i=0; i< conn.GetRowCount(); i++)
					DDL_CL_CARTYPE.Items.Add(new ListItem(conn.GetFieldValue(i, 1), conn.GetFieldValue(i, 0)));

				//--- Hubungan
				conn.QueryString = "select RELTYPEID, RELTYPEID+' - '+RELTYPEDESC from RFRELATIONSHIP where active='1'";
				conn.ExecuteQuery();
				for (int i=0; i< conn.GetRowCount(); i++)
					DDL_CL_RELATIONSHIP.Items.Add(new ListItem(conn.GetFieldValue(i, 1), conn.GetFieldValue(i, 0)));

				//--- Lokasi Agunan
				conn.QueryString = "select LOCATIONID, LOCATIONID + ' - ' + LOCATIONDESC AS LOCATIONDESC from RFCOLLOCATION where active='1' order by LOCATIONID";
				conn.ExecuteQuery();
				for (int i=0; i< conn.GetRowCount(); i++)
					DDL_CL_COLLOC.Items.Add(new ListItem(conn.GetFieldValue(i, 1), conn.GetFieldValue(i, 0)));

				conn.QueryString = "select ACCRDTOID, ACCRDTODESC from RFVALUEACCORDING where active='1'";
				conn.ExecuteQuery();
				for (int i=0; i< conn.GetRowCount(); i++)
					DDL_CL_VALACCRDTO.Items.Add(new ListItem(conn.GetFieldValue(i, 1), conn.GetFieldValue(i, 0)));

				//--- Jenis Agunan
				conn.QueryString = "select AGUNANID, AGUNANID + ' - ' + AGUNANDESC AS AGUNANDESC from RFJENISAGUNAN where ACTIVE='1' order by AGUNANID";
					//"where COLTYPEID = '"+ CL_TYPE +"'";
				conn.ExecuteQuery();
				for (int i=0; i< conn.GetRowCount(); i++)
					DDL_CL_JNSAGUNAN.Items.Add(new ListItem(conn.GetFieldValue(i, 1), conn.GetFieldValue(i, 0)));
				
				string CL_SEQ = LBL_CL_SEQ.Text;
				if (CL_SEQ != "")
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
			conn.QueryString = "select * from VW_BACKUP_COLL_VEH "+
				"where CUREF ='" + LBL_CUREF.Text + "' and CLSEQ = "+ LBL_CL_SEQ.Text;
			conn.ExecuteQuery();

			TXT_CL_VALUE.Text			= tool.MoneyFormat(conn.GetFieldValue("CL_PROPVALUE"));
			TXT_CL_DESC.Text			= conn.GetFieldValue("CL_DESC");
			TXT_CL_MACHINENO.Text		= conn.GetFieldValue("CL_MACHINENO");
			TXT_CL_NOOFUNITS.Text		= conn.GetFieldValue("CL_NOOFUNITS");
			TXT_CL_MANUFACTUREYY.Text	= conn.GetFieldValue("CL_MANUFACTUREYY");
			TXT_CL_CHASISNO.Text		= conn.GetFieldValue("CL_CHASISNO");
			string CL_ISSUEDDATE			= conn.GetFieldValue("CL_ISSUEDDATE");
			TXT_CL_ISSUEDDATEDAY.Text	= tool.FormatDate_Day(CL_ISSUEDDATE);
			TXT_CL_ISSUEDDATEYEAR.Text	= tool.FormatDate_Year(CL_ISSUEDDATE);
			TXT_CL_OWNER.Text			= conn.GetFieldValue("CL_OWNER");
			TXT_CL_BPKBNO.Text			= conn.GetFieldValue("CL_BPKBNO");
			TXT_CL_PLATEID.Text			= conn.GetFieldValue("CL_PLATEID");
			TXT_CL_APPRBY.Text			= conn.GetFieldValue("CL_APPRBY");
			
			TXT_CL_APPRVAL.Text			= tool.MoneyFormat(conn.GetFieldValue("CL_APPRVALUE"));
			if (TXT_CL_APPRVAL.Text == "0,00")
				TXT_CL_APPRVAL.Text = TXT_CL_VALUE.Text;

			TXT_CL_MARKETVAL.Text		= tool.MoneyFormat(conn.GetFieldValue("CL_MARKETVAL"));
			if (TXT_CL_MARKETVAL.Text == "0,00")
				TXT_CL_MARKETVAL.Text = TXT_CL_VALUE.Text;

			TXT_CL_PPAPVAL.Text			= tool.MoneyFormat(conn.GetFieldValue("CL_PPAPVAL"));
			if (TXT_CL_PPAPVAL.Text == "0,00")
				TXT_CL_PPAPVAL.Text = TXT_CL_VALUE.Text;

			try{DDL_CL_CURRENCY.SelectedValue		= conn.GetFieldValue("CL_CURRENCY");}
			catch{}
			DDL_CL_COLCLASSIFY.SelectedValue	= conn.GetFieldValue("CL_COLCLASSIFY");
			TXT_SIBS_COLID.Text			= conn.GetFieldValue("SIBS_COLID");
			DDL_CL_CARTYPE.SelectedValue		= conn.GetFieldValue("CL_CARTYPE");
			TXT_CL_CARBRAND.Text		= conn.GetFieldValue("CL_CARBRAND");
			DDL_CL_RELATIONSHIP.SelectedValue	= conn.GetFieldValue("CL_RELATIONSHIP");
			DDL_CL_ISSUEDDATEMONTH.SelectedValue= tool.FormatDate_Month(CL_ISSUEDDATE);
			try{DDL_CL_COLLOC.SelectedValue	= conn.GetFieldValue("CL_COLLOC");}
			catch{}
			//DDL_CL_VALACCRDTO.SelectedValue		= conn.GetFieldValue("CL_VALACCRDTO");
			try{DDL_CL_JNSAGUNAN.SelectedValue		= conn.GetFieldValue("CL_JNSAGUNAN");}
			catch{}
			try{DDL_CL_DEALER.SelectedValue	= conn.GetFieldValue("CL_DEALER");}
			catch{}
			TXT_CL_JNSMOBIL.Text		= conn.GetFieldValue("CL_JNSMOBIL");

			string CL_VALACCRDTO = conn.GetFieldValue("CL_VALACCRDTO");
			conn.QueryString = "select isnull(LA_APPRTYPE,'0'), isnull(LA_APPRSTATUS,'0') from LISTASSIGNMENT where AP_REGNO = '"+Request.QueryString["regno"]+
				"' and CU_REF = '" +Request.QueryString["curef"]+ "' and CL_SEQ = "+Convert.ToInt16(LBL_CL_SEQ.Text);
			conn.ExecuteQuery();
			if (conn.GetRowCount() != 0)
			{
				if (conn.GetFieldValue(0,0) == "1")
					CL_VALACCRDTO = "2";
				else if (conn.GetFieldValue(0,0) == "0" || conn.GetFieldValue(0,0) == "2")
					CL_VALACCRDTO = "1";

				//--cek appraisal
				if (conn.GetFieldValue(0,0) != "2" && conn.GetFieldValue(0,1) == "3")
					MatikanNilai();
			}
			DDL_CL_VALACCRDTO.SelectedValue	= CL_VALACCRDTO.ToString().Trim();
		}

		private void MatikanNilai()
		{
			TXT_CL_VALUE.ReadOnly		= true;
			TXT_CL_APPRVAL.ReadOnly		= true;
			TXT_CL_MARKETVAL.ReadOnly	= true;
			TXT_CL_PPAPVAL.ReadOnly		= true;
		}

		private void Update()
		{
			double CL_MARKETVAL = double.Parse(TXT_CL_MARKETVAL.Text), 
				CL_PPAPVAL	= double.Parse(TXT_CL_PPAPVAL.Text);

			if (DDL_CL_RELATIONSHIP.SelectedValue.Trim() != "" && TXT_CL_OWNER.Text.Trim() == "")
				Tools.popMessage(this,"Owner / Nama BPKB Tidak Boleh Kosong !!");
			else if (CL_MARKETVAL < CL_PPAPVAL)
				Tools.popMessage(this,"Nilai Agunan  Untuk PPAV tidak boleh lebih besar dari Nilai Pasar!!");
			else
			{
				try 
				{
					conn.QueryString = "exec DE_COLL_VEH '"+ LBL_CUREF.Text +"', "+ LBL_CL_SEQ.Text +", 0, "+
						tool.ConvertFloat(TXT_CL_VALUE.Text) +", '"+ TXT_CL_DESC.Text +"', "+ tool.ConvertNull(DDL_CL_CURRENCY.SelectedValue) +", "+
						tool.ConvertNull(DDL_CL_COLCLASSIFY.SelectedValue) +", '"+ TXT_SIBS_COLID.Text +"', "+ tool.ConvertNull(DDL_CL_DEALER.SelectedValue) + 
						", '"+ TXT_CL_MACHINENO.Text +"', "+ tool.ConvertNum(TXT_CL_NOOFUNITS.Text) +", '"+ TXT_CL_MANUFACTUREYY.Text +"', '"+
						TXT_CL_CHASISNO.Text +"', "+ tool.ConvertNull(DDL_CL_CARTYPE.SelectedValue) +", '"+ TXT_CL_CARBRAND.Text +"', '"+
						TXT_CL_OWNER.Text +"', "+ tool.ConvertNull(DDL_CL_RELATIONSHIP.SelectedValue) +", '"+
						TXT_CL_BPKBNO.Text +"', '"+ TXT_CL_PLATEID.Text +"', '"+ TXT_CL_APPRBY.Text +"', "+
						tool.ConvertDate(TXT_CL_ISSUEDDATEDAY.Text, DDL_CL_ISSUEDDATEMONTH.SelectedValue, TXT_CL_ISSUEDDATEYEAR.Text) +", "+
						tool.ConvertFloat(TXT_CL_APPRVAL.Text) +", "+ tool.ConvertFloat(TXT_CL_MARKETVAL.Text) +", "+ 
						tool.ConvertNull(DDL_CL_COLLOC.SelectedValue) +", "+ tool.ConvertNull(DDL_CL_VALACCRDTO.SelectedValue) +
						", "+ tool.ConvertNull(DDL_CL_JNSAGUNAN.SelectedValue) +", '"+ TXT_CL_JNSMOBIL.Text +"', "+tool.ConvertFloat(TXT_CL_PPAPVAL.Text)+", '"+LBL_REGNO.Text+ "'";
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
