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
	/// Summary description for BankRelation.
	/// </summary>
	public partial class BankRelation : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.TextBox TXT_CG_OGHERS;
		protected System.Web.UI.HtmlControls.HtmlTable T;
		protected System.Web.UI.WebControls.LinkButton LNK_SALDO_RATA2;
		

		protected Tools tool = new Tools();
		protected Connection conn;
		string APREGNO, CUREF;

	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			conn = (Connection) Session["Connection"];

			APREGNO = Request.QueryString["regno"];
			CUREF = Request.QueryString["curef"];


			if (Request.QueryString["de"] == "1")
				if (!Logic.AllowAccess(Session["GroupID"].ToString(), Request.QueryString["mc"], conn))
					Response.Redirect("/SME/Restricted.aspx");

			if (!IsPostBack)
			{

				
				GlobalTools.initDateForm(this.txt_TempDD, this.ddl_MR_M1_BLN_mm, this.txt_MR_M1_BLN_yy);
				GlobalTools.initDateForm(this.txt_TempDD, this.ddl_MR_M2_BLN_mm, this.txt_MR_M2_BLN_yy);
				GlobalTools.initDateForm(this.txt_TempDD, this.ddl_MR_M3_BLN_mm, this.txt_MR_M3_BLN_yy);
				GlobalTools.initDateForm(this.txt_TempDD, this.ddl_MR_M4_BLN_mm, this.txt_MR_M4_BLN_yy);
				GlobalTools.initDateForm(this.txt_TempDD, this.ddl_MR_M5_BLN_mm, this.txt_MR_M5_BLN_yy);
				GlobalTools.initDateForm(this.txt_TempDD, this.ddl_MR_M6_BLN_mm, this.txt_MR_M6_BLN_yy);

				GlobalTools.initDateForm(this.txt_TempDD, this.ddl_MO_M1_BLN_mm, this.txt_MO_M1_BLN_yy);
				GlobalTools.initDateForm(this.txt_TempDD, this.ddl_MO_M2_BLN_mm, this.txt_MO_M2_BLN_yy);
				GlobalTools.initDateForm(this.txt_TempDD, this.ddl_MO_M3_BLN_mm, this.txt_MO_M3_BLN_yy);
				GlobalTools.initDateForm(this.txt_TempDD, this.ddl_MO_M4_BLN_mm, this.txt_MO_M4_BLN_yy);
				GlobalTools.initDateForm(this.txt_TempDD, this.ddl_MO_M5_BLN_mm, this.txt_MO_M5_BLN_yy);
				GlobalTools.initDateForm(this.txt_TempDD, this.ddl_MO_M6_BLN_mm, this.txt_MO_M6_BLN_yy);


				ViewSaldoRata();
				try {HitungSaldo();} 
				catch {}

				ViewSaldoRataOB();
				try {HitungSaldoOB();} 
				catch {}

				
				DDL_CM_CREDITTYPE.Items.Add(new ListItem("- PILIH -", ""));
				DDL_CM_DUEDATE_MONTH.Items.Add(new ListItem("- PILIH -", ""));
				DDL_CM_COLLECTABILITY.Items.Add(new ListItem("- PILIH -", ""));
				DDL_CO_DUEDATE_MONTH.Items.Add(new ListItem("- PILIH -", ""));
				DDL_CO_COLLECTABILITY.Items.Add(new ListItem("- PILIH -", ""));
				DDL_CI_BMDEBITUR_MONTH.Items.Add(new ListItem("- PILIH -", ""));
				DDL_CI_BMGIRO_MONTH.Items.Add(new ListItem("- PILIH -", ""));
				DDL_CI_BMSAVING_MONTH.Items.Add(new ListItem("- PILIH -", ""));
				//DDL_CA_DATESALDO_MONTH.Items.Add(new ListItem("- SELECT -", ""));
				//DDL_CA_CURRENCY.Items.Add(new ListItem("- SELECT -", ""));
				DDL_CO_BANKNAME.Items.Add(new ListItem("- PILIH -", ""));
				DDL_CO_TGLPOSISI_M.Items.Add(new ListItem("- PILIH -", ""));
				DDL_CM_TGLPOSISI_M.Items.Add(new ListItem("- PILIH -", ""));
				DDL_CO_TGLDEBITUR_M.Items.Add(new ListItem("- PILIH -", ""));

				for (int i = 1; i <= 12; i++)
				{
					DDL_CM_DUEDATE_MONTH.Items.Add(new ListItem(DateAndTime.MonthName(i, false), i.ToString()));
					DDL_CO_DUEDATE_MONTH.Items.Add(new ListItem(DateAndTime.MonthName(i, false), i.ToString()));
					DDL_CI_BMDEBITUR_MONTH.Items.Add(new ListItem(DateAndTime.MonthName(i, false), i.ToString()));
					DDL_CI_BMGIRO_MONTH.Items.Add(new ListItem(DateAndTime.MonthName(i, false), i.ToString()));
					DDL_CI_BMSAVING_MONTH.Items.Add(new ListItem(DateAndTime.MonthName(i, false), i.ToString()));
					//DDL_CA_DATESALDO_MONTH.Items.Add(new ListItem(DateAndTime.MonthName(i, false), i.ToString()));
					DDL_CO_TGLPOSISI_M.Items.Add(new ListItem(DateAndTime.MonthName(i, false), i.ToString()));
					DDL_CM_TGLPOSISI_M.Items.Add(new ListItem(DateAndTime.MonthName(i, false), i.ToString()));
					DDL_CO_TGLDEBITUR_M.Items.Add(new ListItem(DateAndTime.MonthName(i, false), i.ToString()));
				}

				/*
				conn.QueryString = "select * from RFLOANTYPE where ACTIVE = '1'";dasfssfafds
				conn.ExecuteQuery();
				*/
				conn.QueryString = "select productid, productdesc from rfproduct where active='1'";
				conn.ExecuteQuery();
				for (int i = 0; i < conn.GetRowCount(); i++)
				{
					DDL_CM_CREDITTYPE.Items.Add(new ListItem(conn.GetFieldValue(i,0) + " - " + conn.GetFieldValue(i,1), conn.GetFieldValue(i,0)));
				}

				// collectability fasilitas di bank Mandiri
				conn.QueryString = "select * from RFCOLLECTABILITY1 where ACTIVE = '1'";
				conn.ExecuteQuery();
				for (int i = 0; i < conn.GetRowCount(); i++)
				{
					DDL_CM_COLLECTABILITY.Items.Add(new ListItem(conn.GetFieldValue(i,1), conn.GetFieldValue(i,0)));
				}

				// collectability fasilitas di bank lain
				conn.QueryString = "select * from RFCOLLECTABILITY where ACTIVE = '1'";
				conn.ExecuteQuery();
				for (int i = 0; i < conn.GetRowCount(); i++)
				{
					DDL_CO_COLLECTABILITY.Items.Add(new ListItem(conn.GetFieldValue(i,1), conn.GetFieldValue(i,0)));
				}

				//--- Bank
				conn.QueryString = "select bankid, bankid+' - '+bankname as bankname from rfbank where active='1' order by bankid";
				conn.ExecuteQuery();
				for (int i = 0; i < conn.GetRowCount(); i++)
					DDL_CO_BANKNAME.Items.Add(new ListItem(conn.GetFieldValue(i,1), conn.GetFieldValue(i,0)));

				//--- Jenis Product di Hubungan Dengan Bank Lain (RFJENISPRODUCT)
				GlobalTools.fillRefList(DDL_RFJENISPRODUCT, "select * from RFJENISPRODUCT where ACTIVE = '1'", false, conn);
			
				/*
				conn.QueryString = "select * from RFCURRENCY where ACTIVE = '1'";
				conn.ExecuteQuery();
				for (int i = 0; i < conn.GetRowCount(); i++)
				{
					DDL_CA_CURRENCY.Items.Add(new ListItem(conn.GetFieldValue(i,1), conn.GetFieldValue(i,0)));
				}
				*/

				try
				{
					//----------- edited by Yudi --------------
					//HPL_ATASNAMA0.NavigateUrl = "BankRelation.aspx?regno="+Request.QueryString["regno"]+"&curef="+Request.QueryString["curef"]+"&code=0"+"&mc="+Request.QueryString["mc"];
					//HPL_ATASNAMA1.NavigateUrl = "BankRelation.aspx?regno="+Request.QueryString["regno"]+"&curef="+Request.QueryString["curef"]+"&code=1"+"&mc="+Request.QueryString["mc"];
					HPL_ATASNAMA0.NavigateUrl = "BankRelation.aspx?regno="+Request.QueryString["regno"]+"&curef="+Request.QueryString["curef"]+"&code=0"+"&mc="+Request.QueryString["mc"] + "&de=" + Request.QueryString["de"]+"&tc="+Request.QueryString["tc"]+"&par="+Request.QueryString["par"];
					HPL_ATASNAMA1.NavigateUrl = "BankRelation.aspx?regno="+Request.QueryString["regno"]+"&curef="+Request.QueryString["curef"]+"&code=1"+"&mc="+Request.QueryString["mc"] + "&de=" + Request.QueryString["de"]+"&tc="+Request.QueryString["tc"]+"&par="+Request.QueryString["par"];
					//-----------------------------------------
					//HPL_ATASNAMA2.NavigateUrl = "BankRelation.aspx?regno="+Request.QueryString["regno"]+"&curef="+Request.QueryString["curef"]+"&code=2";

					HPL_SALDORATA.NavigateUrl = "BankRelation.aspx?regno="+Request.QueryString["regno"]+"&curef="+Request.QueryString["curef"]+"&code=2"+"&mc="+Request.QueryString["mc"] + "&de=" + Request.QueryString["de"]+"&tc="+Request.QueryString["tc"]+"&par="+Request.QueryString["par"];
				}
				catch
				{
				}
				
				ViewData();
				//ViewSaldo();
				ViewMandiriLoan();
				ViewOtherLoan();


				conn.QueryString = "select * from cust_grpmandirifac where cu_ref='" + Request.QueryString["curef"] + "'";
				conn.ExecuteQuery();
				if (conn.GetRowCount() > 0)
				{
					TXT_CG_CASHLOAN.Text		= conn.GetFieldValue(0, "cg_cashloan");
					TXT_CG_NONCASHLOAN.Text		= conn.GetFieldValue(0, "cg_noncashloan");
					TXT_CG_OTHERS.Text			= conn.GetFieldValue(0, "cg_others");
					TXT_CG_TOTAL.Text			= conn.GetFieldValue(0, "cg_total");
					TXT_CG_COMMITTED.Text		= conn.GetFieldValue(0, "CG_COMMITTED");
					TXT_CG_UNCOMMITTED.Text		= conn.GetFieldValue(0, "CG_UNCOMMITTED");
				}

				TBL_SALDO_RATA.Visible = false;	//By Default, table Saldo Rata-rata hidden
			}
			try 
			{
				if (Request.QueryString["code"] == "" )
					LBL_CM_ATASNAMA.Text = "";
				else
					LBL_CM_ATASNAMA.Text = Request.QueryString["code"];
			}
			catch 
			{
			}
			
			LBL_PAR.Text = Request.QueryString["par"];			
			
			if (Request.QueryString["code"] == "1")				
				TRGroup.Visible = true;
			else
				TRGroup.Visible = false;

			CheckNama();
			ViewMandiriLoan();
			ViewMenu();
			SecureData();



			TXT_CG_CASHLOAN.Text = tool.MoneyFormat(TXT_CG_CASHLOAN.Text);
			TXT_CG_NONCASHLOAN.Text = tool.MoneyFormat(TXT_CG_NONCASHLOAN.Text);
			TXT_CG_OTHERS.Text = tool.MoneyFormat(TXT_CG_OTHERS.Text);
			TXT_CG_TOTAL.Text = tool.MoneyFormat(TXT_CG_TOTAL.Text);
			TXT_CG_COMMITTED.Text = tool.MoneyFormat(TXT_CG_COMMITTED.Text);
			TXT_CG_UNCOMMITTED.Text = tool.MoneyFormat(TXT_CG_UNCOMMITTED.Text);

			BTN_SAVEGRP.Attributes.Add("onclick","if(!cek_mandatory(document.Form1)){return false;};");
			BTN_SAVE.Attributes.Add("onclick","if(!cek_mandatory(document.Form1)){return false;};");
			BTN_INSERT.Attributes.Add("onclick","if(!cek_mandatoryColl(document.Form1)){return false;};");

			this.BTN_BACK.Click +=new ImageClickEventHandler(BTN_BACK_Click);
			this.BTN_SAVEGRP.Click += new EventHandler(BTN_SAVEGRP_Click);
			this.btn_SaveSaldo.Click += new EventHandler(btn_SaveSaldo_Click);
			this.btn_CalcOB.Click += new EventHandler(btn_CalcOB_Click);
			this.btn_SaveSaldoOB.Click += new EventHandler(btn_SaveSaldoOB_Click);
			this.DatGridMandiriLoan.ItemCommand += new DataGridCommandEventHandler(DatGridMandiriLoan_ItemCommand);
			this.BTN_INSERT.Click += new EventHandler(BTN_INSERT_Click);
			this.DatGridOtherLoan.ItemCommand += new DataGridCommandEventHandler(DatGridOtherLoan_ItemCommand);
			this.BtnInsert1.Click += new EventHandler(BtnInsert1_Click);
			this.BTN_SAVE.Click += new EventHandler(BTN_SAVE_Click);
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

		private void secureSaldoRataRata() 
		{
			/////////////////////////////////////////////////////////////////////////////////////
			/// protect bank mandiri
			/// 
			ddl_MR_M1_BLN_mm.Enabled = false;
			txt_MR_M1_BLN_yy.ReadOnly = true;
			txt_MR_M1_SLDRATA.ReadOnly = true;
			txt_MR_M1_DEBET.ReadOnly = true;
			txt_MR_M1_DEBETF.ReadOnly = true;
			txt_MR_M1_KREDIT.ReadOnly = true;
			txt_MR_M1_KREDITF.ReadOnly = true;

			ddl_MR_M2_BLN_mm.Enabled = false;
			txt_MR_M2_BLN_yy.ReadOnly = true;
			txt_MR_M2_SLDRATA.ReadOnly = true;
			txt_MR_M2_DEBET.ReadOnly = true;
			txt_MR_M2_DEBETF.ReadOnly = true;
			txt_MR_M2_KREDIT.ReadOnly = true;
			txt_MR_M2_KREDITF.ReadOnly = true;

			ddl_MR_M3_BLN_mm.Enabled = false;
			txt_MR_M3_BLN_yy.ReadOnly = true;
			txt_MR_M3_SLDRATA.ReadOnly = true;
			txt_MR_M3_DEBET.ReadOnly = true;
			txt_MR_M3_DEBETF.ReadOnly = true;
			txt_MR_M3_KREDIT.ReadOnly = true;
			txt_MR_M3_KREDITF.ReadOnly = true;

			ddl_MR_M4_BLN_mm.Enabled = false;
			txt_MR_M4_BLN_yy.ReadOnly = true;
			txt_MR_M4_SLDRATA.ReadOnly = true;
			txt_MR_M4_DEBET.ReadOnly = true;
			txt_MR_M4_DEBETF.ReadOnly = true;
			txt_MR_M4_KREDIT.ReadOnly = true;
			txt_MR_M4_KREDITF.ReadOnly = true;

			ddl_MR_M5_BLN_mm.Enabled = false;
			txt_MR_M5_BLN_yy.ReadOnly = true;
			txt_MR_M5_SLDRATA.ReadOnly = true;
			txt_MR_M5_DEBET.ReadOnly = true;
			txt_MR_M5_DEBETF.ReadOnly = true;
			txt_MR_M5_KREDIT.ReadOnly = true;
			txt_MR_M5_KREDITF.ReadOnly = true;

			ddl_MR_M6_BLN_mm.Enabled = false;
			txt_MR_M6_BLN_yy.ReadOnly = true;
			txt_MR_M6_SLDRATA.ReadOnly = true;
			txt_MR_M6_DEBET.ReadOnly = true;
			txt_MR_M6_DEBETF.ReadOnly = true;
			txt_MR_M6_KREDIT.ReadOnly = true;
			txt_MR_M6_KREDITF.ReadOnly = true;

			txt_MR_LIMITKREDIT.ReadOnly = true;
			txt_MR_M1_SALDO.ReadOnly = true;
			txt_MR_CATATAN.ReadOnly = true;

			btn_Calc.Enabled = false;
			btn_SaveSaldo.Enabled = false;

			/////////////////////////////////////////////////////////////////////////////////////
			/// protect bank lain
			/// 
			ddl_MO_M1_BLN_mm.Enabled = false;
			txt_MO_M1_BLN_yy.ReadOnly = true;
			txt_MO_M1_SLDRATA.ReadOnly = true;
			txt_MO_M1_DEBET.ReadOnly = true;
			txt_MO_M1_DEBETF.ReadOnly = true;
			txt_MO_M1_KREDIT.ReadOnly = true;
			txt_MO_M1_KREDITF.ReadOnly = true;

			ddl_MO_M2_BLN_mm.Enabled = false;
			txt_MO_M2_BLN_yy.ReadOnly = true;
			txt_MO_M2_SLDRATA.ReadOnly = true;
			txt_MO_M2_DEBET.ReadOnly = true;
			txt_MO_M2_DEBETF.ReadOnly = true;
			txt_MO_M2_KREDIT.ReadOnly = true;
			txt_MO_M2_KREDITF.ReadOnly = true;

			ddl_MO_M3_BLN_mm.Enabled = false;
			txt_MO_M3_BLN_yy.ReadOnly = true;
			txt_MO_M3_SLDRATA.ReadOnly = true;
			txt_MO_M3_DEBET.ReadOnly = true;
			txt_MO_M3_DEBETF.ReadOnly = true;
			txt_MO_M3_KREDIT.ReadOnly = true;
			txt_MO_M3_KREDITF.ReadOnly = true;

			ddl_MO_M4_BLN_mm.Enabled = false;
			txt_MO_M4_BLN_yy.ReadOnly = true;
			txt_MO_M4_SLDRATA.ReadOnly = true;
			txt_MO_M4_DEBET.ReadOnly = true;
			txt_MO_M4_DEBETF.ReadOnly = true;
			txt_MO_M4_KREDIT.ReadOnly = true;
			txt_MO_M4_KREDITF.ReadOnly = true;

			ddl_MO_M5_BLN_mm.Enabled = false;
			txt_MO_M5_BLN_yy.ReadOnly = true;
			txt_MO_M5_SLDRATA.ReadOnly = true;
			txt_MO_M5_DEBET.ReadOnly = true;
			txt_MO_M5_DEBETF.ReadOnly = true;
			txt_MO_M5_KREDIT.ReadOnly = true;
			txt_MO_M5_KREDITF.ReadOnly = true;

			ddl_MO_M6_BLN_mm.Enabled = false;
			txt_MO_M6_BLN_yy.ReadOnly = true;
			txt_MO_M6_SLDRATA.ReadOnly = true;
			txt_MO_M6_DEBET.ReadOnly = true;
			txt_MO_M6_DEBETF.ReadOnly = true;
			txt_MO_M6_KREDIT.ReadOnly = true;
			txt_MO_M6_KREDITF.ReadOnly = true;

			txt_MO_LIMITKREDIT.ReadOnly = true;
			txt_MO_M1_SALDO.ReadOnly = true;
			txt_MO_CATATAN.ReadOnly = true;

			btn_CalcOB.Enabled = false;
			btn_SaveSaldoOB.Enabled = false;
		}


		private void SecureData() 
		{
			string de = Request.QueryString["de"];

			if (de != "1") TXT_CG_OTHERS.ReadOnly = true;

			// Jika yang memanggil bukan dalam scope DataEntry, maka disable semua control input
			// Flag :
			//		Nama  = de
			//		Value ==  1 --> Parent DataEntry
			//			  !=  1 --> Parent non-DataEntry
			
			if (de != "1") 
			{
				secureSaldoRataRata();

				int kk = 0, index = -1;
				System.Web.UI.ControlCollection coll = this.Page.Controls;
				for (kk = 0; kk < coll.Count; kk++) 
				{
					if (coll[kk] is System.Web.UI.HtmlControls.HtmlForm) 
					{
						index = kk;
						break;
					}
				}

				if (index == -1) return;
				if (kk == coll.Count) return;

				for (int i = 0; i < coll[index].Controls.Count; i++) 
				{
					if (coll[index].Controls[i] is TextBox) 
					{
						TextBox txt = (TextBox) coll[index].Controls[i];
						txt.ReadOnly = true;
					}
					else if (coll[index].Controls[i] is DropDownList) 
					{
						DropDownList ddl = (DropDownList) coll[index].Controls[i];
						ddl.Enabled = false;
					}
					else if (coll[index].Controls[i] is Button)
					{
						Button btn = (Button) coll[index].Controls[i];
						btn.Visible = false;
					}
					else if (coll[index].Controls[i] is RadioButtonList) 
					{
						RadioButtonList rbl = (RadioButtonList) coll[index].Controls[i];
						rbl.Enabled = false;
					}
					else if (coll[index].Controls[i] is RadioButton) 
					{
						RadioButton rb = (RadioButton) coll[index].Controls[i];
						rb.Enabled = false;
					}
					else if (coll[index].Controls[i] is CheckBox)
					{
						CheckBox cb = (CheckBox) coll[index].Controls[i];
						cb.Enabled = false;
					}					
					else if (coll[index].Controls[i] is HtmlTableRow) 
					{
						HtmlTableRow htr = (HtmlTableRow) coll[index].Controls[i];

						for (int j=0; j < htr.Controls.Count; j++) 
						{							
							for (int jj = 0; jj < htr.Controls[j].Controls.Count; jj++) 
							{
								if (htr.Controls[j].Controls[jj] is TextBox) 
								{
									TextBox txt = (TextBox) htr.Controls[j].Controls[jj];
									txt.ReadOnly = true;
								}
								else if (htr.Controls[j].Controls[jj] is DropDownList) 
								{
									DropDownList ddl = (DropDownList) htr.Controls[j].Controls[jj];
									ddl.Enabled = false;
								}
								else if (htr.Controls[j].Controls[jj] is Button)
								{
									Button btn = (Button) htr.Controls[j].Controls[jj];
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
			conn.QueryString = "select * from VW_DE_HUBUNGANBANK where CU_REF = '" +Request.QueryString["curef"]+ "'";
			conn.ExecuteQuery();
			TXT_CI_BMGIRO_DAY.Text					= tool.FormatDate_Day(conn.GetFieldValue("CI_BMGIRO"));
			DDL_CI_BMGIRO_MONTH.SelectedValue		= tool.FormatDate_Month(conn.GetFieldValue("CI_BMGIRO"));
			TXT_CI_BMGIRO_YEAR.Text					= tool.FormatDate_Year(conn.GetFieldValue("CI_BMGIRO"));
			TXT_CI_BMSAVING_DAY.Text				= tool.FormatDate_Day(conn.GetFieldValue("CI_BMSAVING"));
			DDL_CI_BMSAVING_MONTH.SelectedValue		= tool.FormatDate_Month(conn.GetFieldValue("CI_BMSAVING"));
			TXT_CI_BMSAVING_YEAR.Text				= tool.FormatDate_Year(conn.GetFieldValue("CI_BMSAVING"));
			TXT_CI_BMDEBITUR_DAY.Text				= tool.FormatDate_Day(conn.GetFieldValue("CI_BMDEBITUR"));
			DDL_CI_BMDEBITUR_MONTH.SelectedValue	= tool.FormatDate_Month(conn.GetFieldValue("CI_BMDEBITUR"));
			TXT_CI_BMDEBITUR_YEAR.Text				= tool.FormatDate_Year(conn.GetFieldValue("CI_BMDEBITUR"));
			TXT_CA_NOTE.Text						= conn.GetFieldValue("CA_NOTE");
			/*
			TXT_CA_OVERDRAFT.Text					= tool.MoneyFormat(conn.GetFieldValue("CA_OVERDRAFT"));
			TXT_CA_PGUARANTEE.Text					= tool.MoneyFormat(conn.GetFieldValue("CA_PGUARANTEE"));
			TXT_CA_KETOTHER.Text					= conn.GetFieldValue("CA_KETOTHER");
			TXT_CA_OTHER.Text						= tool.MoneyFormat(conn.GetFieldValue("CA_OTHER"));
			
			if (conn.GetFieldValue("CA_KETHUTANG") == "1")
				RDO_CA_KETHUTANG1.Checked = true;
			else
				RDO_CA_KETHUTANG0.Checked = true;
			if (conn.GetFieldValue("CA_KETOVERDRAFT") == "1")
				RDO_CA_KETOVERDRAFT1.Checked = true;
			else
				RDO_CA_KETOVERDRAFT0.Checked = true;
			*/
			if (conn.GetFieldValue("CA_ACCOUNTSTATUS") == "1")
				RDO_CA_ACCOUNTSTATUS1.Checked = true;
			else
				RDO_CA_ACCOUNTSTATUS0.Checked = true;

            TXT_CI_BMSAVINGACCNO.Text = conn.GetFieldValue("CI_BMSAVINGACCNO");
		}

		private void CheckNama()
		{
			string CM_ATASNAMA;

			if (LBL_CM_ATASNAMA.Text == "1")		// Atas Nama Group
			{
				LBL_ATASNAMA.Text	= "Atas Nama Group";
				CM_ATASNAMA	= LBL_CM_ATASNAMA.Text;
				namaPerusahaan.Visible = true;
				DatGridMandiriLoan.Columns[1].Visible = true;
				this.TBL_SALDO_RATA.Visible = false;
				this.TBL_SALDO_RATA_OB.Visible = false;

				this.br00.Visible = true;
				this.br01.Visible = true;
				this.br02.Visible = true;
				this.br03.Visible = true;
				this.br04.Visible = true;
				this.br05.Visible = true;
				this.br06.Visible = true;
				this.br07.Visible = true;
				this.br08.Visible = true;
				this.br09.Visible = true;
				this.br10.Visible = true;
				this.br11.Visible = true;
				this.brtombol.Visible = true;

			}
			else if (LBL_CM_ATASNAMA.Text == "2")	// Saldo Rata-rata
			{
				
				LBL_ATASNAMA.Text	= "Saldo Rata-Rata";
				CM_ATASNAMA	= LBL_CM_ATASNAMA.Text;
				namaPerusahaan.Visible = false;
				DatGridMandiriLoan.Columns[1].Visible = false;
				this.TBL_SALDO_RATA.Visible = true;
				this.TBL_SALDO_RATA_OB.Visible = true;

				this.br00.Visible = false;
				this.br01.Visible = false;
				this.br02.Visible = false;
				this.br03.Visible = false;
				this.br04.Visible = false;
				this.br05.Visible = false;
				this.br06.Visible = false;
				this.br07.Visible = false;
				this.br08.Visible = false;
				this.br09.Visible = false;
				this.br10.Visible = false;
				this.br11.Visible = false;
				this.brtombol.Visible = false;


			}
			else if (LBL_CM_ATASNAMA.Text == "0")	// Atas Nama Nasabah
			{
				LBL_ATASNAMA.Text	= "Atas Nama Nasabah";
				LBL_CM_ATASNAMA.Text = "0";
				CM_ATASNAMA	= "0";
				namaPerusahaan.Visible = false;
				DatGridMandiriLoan.Columns[1].Visible = false;
				this.TBL_SALDO_RATA.Visible = false;
				this.TBL_SALDO_RATA_OB.Visible = false;

				this.br00.Visible = true;
				this.br01.Visible = true;
				this.br02.Visible = true;
				this.br03.Visible = true;
				this.br04.Visible = true;
				this.br05.Visible = true;
				this.br06.Visible = true;
				this.br07.Visible = true;
				this.br08.Visible = true;
				this.br09.Visible = true;
				this.br10.Visible = true;
				this.br11.Visible = true;
				this.brtombol.Visible = true;

			}
			else 
			{
				LBL_ATASNAMA.Text	= "Atas Nama -";
				LBL_CM_ATASNAMA.Text = "";
				CM_ATASNAMA	= "";
			}
			//pipeline FOR CORPORATE

			conn.QueryString = "SELECT sg_BUSSUNITid FROM scgroup WHERE groupid = '" + Session["GroupID"].ToString() + "'";
			conn.ExecuteQuery();
			
			if (conn.GetFieldValue("sg_BUSSUNITid") == "CB100")
			{
				br08.Visible = false;
				br09.Visible = false;
				br10.Visible = false;
				br11.Visible = false;
			}


		}

		private void ViewMandiriLoan()
		{
			string CM_ATASNAMA = LBL_CM_ATASNAMA.Text;
			double TotLimit = 0, bakiDebet = 0, TotSub=0;
			double Total = 0,limitkredit = 0, bakikredit = 0, tgkpokok = 0,tgkbunga = 0;

			DataTable dt = new DataTable();
			conn.QueryString = "select * from VW_CUSTMANDIRILOAN where CU_REF ='"+ Request.QueryString["curef"] + "' and CM_ATASNAMA = '" +CM_ATASNAMA+ "'";
			conn.ExecuteQuery();
			dt = conn.GetDataTable().Copy();
			DatGridMandiriLoan.DataSource = dt;
			DatGridMandiriLoan.DataBind();
			for (int i = 0; i < DatGridMandiriLoan.Items.Count; i++)
			{	
				///// dewi
				/* MENGAMBIL CURRENCY RATE DARI PRODUCT YANG BERSANGKUTAN */ 
				conn.QueryString = "select currencyrate from rfproduct p left join rfcurrency c "+
									"on p.currency = c.currencyid where p.productid = '"+DatGridMandiriLoan.Items[i].Cells[2].Text+"'";
				conn.ExecuteQuery();

				try { limitkredit = double.Parse(GlobalTools.ConvertFloat( DatGridMandiriLoan.Items[i].Cells[4].Text)); }  
				catch {}
				limitkredit = limitkredit * double.Parse(conn.GetFieldValue("currencyrate"));

				try { bakikredit = double.Parse(GlobalTools.ConvertFloat( DatGridMandiriLoan.Items[i].Cells[5].Text)); }  
				catch {}
				bakikredit = bakikredit * double.Parse(conn.GetFieldValue("currencyrate"));

				try { tgkpokok = double.Parse(GlobalTools.ConvertFloat( DatGridMandiriLoan.Items[i].Cells[6].Text)); }  
				catch {}
				tgkpokok = tgkpokok * double.Parse(conn.GetFieldValue("currencyrate"));

				try { tgkbunga = double.Parse(GlobalTools.ConvertFloat( DatGridMandiriLoan.Items[i].Cells[7].Text)); }  
				catch {}
				tgkbunga = tgkbunga * double.Parse(conn.GetFieldValue("currencyrate"));
				
				DatGridMandiriLoan.Items[i].Cells[4].Text = tool.MoneyFormat(limitkredit.ToString());
				DatGridMandiriLoan.Items[i].Cells[5].Text = tool.MoneyFormat(bakikredit.ToString());
				DatGridMandiriLoan.Items[i].Cells[6].Text = tool.MoneyFormat(tgkpokok.ToString());
				DatGridMandiriLoan.Items[i].Cells[7].Text = tool.MoneyFormat(tgkbunga.ToString());
				
				//////////////////////////
				
				/*
				DatGridMandiriLoan.Items[i].Cells[4].Text = tool.MoneyFormat(DatGridMandiriLoan.Items[i].Cells[4].Text);
				DatGridMandiriLoan.Items[i].Cells[5].Text = tool.MoneyFormat(DatGridMandiriLoan.Items[i].Cells[5].Text);
				DatGridMandiriLoan.Items[i].Cells[6].Text = tool.MoneyFormat(DatGridMandiriLoan.Items[i].Cells[6].Text);
				DatGridMandiriLoan.Items[i].Cells[7].Text = tool.MoneyFormat(DatGridMandiriLoan.Items[i].Cells[7].Text);
				*/

				TotLimit = TotLimit + double.Parse(DatGridMandiriLoan.Items[i].Cells[4].Text);
				bakiDebet = bakiDebet + double.Parse(DatGridMandiriLoan.Items[i].Cells[5].Text);
				// endi 
				if (DatGridMandiriLoan.Items[i].Cells[5].Text != "0,00")
					Total = Total + double.Parse(DatGridMandiriLoan.Items[i].Cells[5].Text);
				else
					Total = Total + double.Parse(DatGridMandiriLoan.Items[i].Cells[4].Text);

				//---------- Protection Screen -----------------------------dsafaf
				if (Request.QueryString["de"] != "1") 
				{
					LinkButton LNK_DELETE	= (LinkButton) DatGridMandiriLoan.Items[i].FindControl("LinkButton1");
					LNK_DELETE.Visible		= false;
					//DatGridMandiriLoan.Items[i].Cells[14].Text = "Delete";
					//DatGridMandiriLoan.Items[i].Cells[14].Enabled = false;
				}
				//---------- Protection Screen -----------------------------
			}
			//TotLimit = TotLimit + bakiDebet;
			//LBL_SUBTOTAL.Text	= "Sum of Limit Kredit " + " Above";//+ LBL_ATASNAMA.Text;sadfsda
			
			///////////////////////////////////
			/// Atas Nama Group
			///
//			if (Request.QueryString["code"] == "1")			
//			{
//				try { TotSub = double.Parse(GlobalTools.ConvertFloat( TXT_CG_TOTAL.Text)); }  
//				catch {}
//				TotLimit = TotLimit + TotSub;
//			}
//
//			TXT_SUBTOTAL.Text   = tool.MoneyFormat(TotLimit.ToString());	// aslinya
			//TXT_SUBTOTAL.Text	= tool.MoneyFormat(TotSub.ToString());						

			///////////////////////////////////
			/// Atas Nama Group
			///
			if (Request.QueryString["code"] == "1")	
			{
				conn.QueryString = "select ISNULL(cg_total,0) cg_total from cust_grpmandirifac where cu_ref = '" + Request.QueryString["curef"] + "'";
				conn.ExecuteQuery();

				try { TotSub = double.Parse(conn.GetFieldValue("cg_total")); }  
				catch {}
						
				TotLimit = TotLimit + TotSub ;
				LBL_SUBTOTAL.Text ="Total Limit Group (Rp.) ";
			}
			//added by rene
			//TXT_SUBTOTAL.Text	= tool.MoneyFormat(TotLimit.ToString());
			TXT_SUBTOTAL.Text	= tool.MoneyFormat(TXT_CG_TOTAL.Text);
			
			/*
			conn.QueryString = "select cg_cashloan, cg_noncashloan, cg_others, cg_total from cust_grpmandirifac where cu_ref='" + Request.QueryString["curef"] + "'";
			conn.ExecuteQuery();
			if (conn.GetRowCount() > 0)
			{
				TXT_CG_CASHLOAN.Text = conn.GetFieldValue(0, "cg_cashloan");
				TXT_CG_NONCASHLOAN.Text = conn.GetFieldValue(0, "cg_noncashloan");
				TXT_CG_OTHERS.Text = conn.GetFieldValue(0, "cg_others");
				TXT_CG_TOTAL.Text = conn.GetFieldValue(0, "cg_total");
			}sdafs
			*/
			
			//conn.QueryString = "select isnull(sum(CM_LIMIT),0) from CUSTMANDIRILOAN where CU_REF = '" +Request.QueryString["curef"]+ "' and cm_atasnama='0'";
			//conn.ExecuteQuery();
			//TXT_TOTAL.Text   = tool.MoneyFormat(conn.GetFieldValue(0,0));sdfsdf

			/**
			conn.QueryString = "exec DE_TOTALEXPOSURE '" + Request.QueryString["regno"] + "'";
			conn.ExecuteQuery();
			TXT_TOTAL.Text = tool.MoneyFormat(conn.GetFieldValue(0,0));
			**/

			conn.QueryString = "exec DE_CALCULATE_TOTALEXPOSURE '" + Request.QueryString["regno"] + "', '" + Request.QueryString["curef"] + "'";
			conn.ExecuteQuery(300);
			TXT_TOTAL.Text = tool.MoneyFormat(conn.GetFieldValue(0,"GROUP_EXPOSURE"));

			/*
			if (conn.GetRowCount() > 0)
				atasNamaNasabah = conn.GetFieldValue(0,0);
			double totalSemua = double.Parse(cg_total) + double.Parse(atasNamaNasabah);
			TXT_TOTAL.Text = totalSemua.ToString();
			*/
		}

		private void BTN_INSERT_Click(object sender, System.EventArgs e)
		{
			//
			// Validasi Tanggal
			//
			if (TXT_CM_DUEDATE_DAY.Text.Trim() != "" || DDL_CM_DUEDATE_MONTH.SelectedValue != "" || TXT_CM_DUEDATE_YEAR.Text.Trim() != "") 
			{
				if (!GlobalTools.isDateValid(TXT_CM_DUEDATE_DAY.Text, DDL_CM_DUEDATE_MONTH.SelectedValue, TXT_CM_DUEDATE_YEAR.Text)) 
				{
					GlobalTools.popMessage(this, "Masa Berlaku s/d tidak valid!");
					return;
				}
			}

			if (TXT_CM_TGLPOSISI_D.Text.Trim() != "" || DDL_CM_TGLPOSISI_M.SelectedValue != "" || TXT_CM_TGLPOSISI_Y.Text.Trim() != "") 
			{
				if (!GlobalTools.isDateValid(TXT_CM_TGLPOSISI_D.Text, DDL_CM_TGLPOSISI_M.SelectedValue, TXT_CM_TGLPOSISI_Y.Text)) 
				{
					GlobalTools.popMessage(this, "Posisi Tanggal tidak valid!");
					return;
				}
			}


			//
			// Cek dulu apakah key sudah ada yang sama
			//
			

			try 
			{
				conn.QueryString = "exec SP_CUSTMANDIRILOAN '"+ 
					Request.QueryString["curef"] +"', '" +
					DDL_CM_CREDITTYPE.SelectedValue+ "', '" +
					LBL_CM_ATASNAMA.Text+ "', " +
					tool.ConvertFloat(TXT_CM_LIMIT.Text)+ ", " +
					tool.ConvertFloat(TXT_CM_OUTSTANDING.Text)+ ", " +
					tool.ConvertFloat(TXT_CM_TGKPOKOK.Text)+ ", " +
					tool.ConvertFloat(TXT_CM_TGKBUNGA.Text)+ ", " +
					tool.ConvertNum(TXT_CM_LAMATGK.Text)+", " +
					tool.ConvertDate(TXT_CM_DUEDATE_DAY.Text,DDL_CM_DUEDATE_MONTH.SelectedValue,TXT_CM_DUEDATE_YEAR.Text)+ ", " +
					tool.ConvertNull(DDL_CM_COLLECTABILITY.SelectedValue)+ ",'1'," +
					tool.ConvertDate(TXT_CM_TGLPOSISI_D.Text, DDL_CM_TGLPOSISI_M.SelectedValue, TXT_CM_TGLPOSISI_Y.Text) + ", '" +
					TXT_CM_COMPNAME.Text + "', null, '" + 
					TXT_CM_ACCNO.Text + "'";
				conn.ExecuteQuery();
			} 
			catch (NullReferenceException)
			{
				GlobalTools.popMessage(this, "Connection Error!");
				Response.Redirect("../Login.aspx?expire=1");
			}

			ViewMandiriLoan();
			ClearDataMandiriLoan();
		}

		private void ClearDataMandiriLoan()
		{
			DDL_CM_CREDITTYPE.SelectedValue = "";
			TXT_CM_LIMIT.Text				= "";
			TXT_CM_OUTSTANDING.Text			= "";
			TXT_CM_TGKPOKOK.Text			= "";
			TXT_CM_TGKBUNGA.Text			= "";
			TXT_CM_LAMATGK.Text				= "";
			TXT_CM_DUEDATE_DAY.Text			= "";
			DDL_CM_DUEDATE_MONTH.SelectedValue	= "";
			TXT_CM_DUEDATE_YEAR.Text		= "";
			DDL_CM_COLLECTABILITY.SelectedValue	= "";
			TXT_CM_TGLPOSISI_D.Text = "";
			DDL_CM_TGLPOSISI_M.SelectedValue = "";
			TXT_CM_TGLPOSISI_Y.Text = "";
			TXT_CM_ACCNO.Text = "";
		}

		private void DatGridMandiriLoan_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			switch (((LinkButton)e.CommandSource).CommandName)
			{
				case "delete":
					conn.QueryString = "exec SP_CUSTMANDIRILOAN '" +e.Item.Cells[0].Text+ "', '"+e.Item.Cells[2].Text+"','" +LBL_CM_ATASNAMA.Text+
										"','','','','','','','','2', null, null, '" + e.Item.Cells[14].Text + "', '" + e.Item.Cells[12].Text + "'";
					conn.ExecuteNonQuery();
					ViewMandiriLoan();
				break;
			}
		}

		/*
		private void ViewSaldo()
		{
			DataTable dt = new DataTable();
			conn.QueryString = "select * from VW_CUSTLISTACC where CU_REF ='"+ Request.QueryString["curef"]+"'";
			conn.ExecuteQuery();
			dt = conn.GetDataTable().Copy();
			DatGridSaldo.DataSource = dt;
			DatGridSaldo.DataBind();
			for (int i = 0; i < DatGridSaldo.Items.Count; i++)
			{
				DatGridSaldo.Items[i].Cells[2].Text = tool.FormatDate_MonthName(DatGridSaldo.Items[i].Cells[2].Text)+" "+tool.FormatDate_Year(DatGridSaldo.Items[i].Cells[2].Text);
				DatGridSaldo.Items[i].Cells[4].Text = tool.MoneyFormat(DatGridSaldo.Items[i].Cells[4].Text);
				DatGridSaldo.Items[i].Cells[5].Text = tool.MoneyFormat(DatGridSaldo.Items[i].Cells[5].Text);
				DatGridSaldo.Items[i].Cells[7].Text = tool.MoneyFormat(DatGridSaldo.Items[i].Cells[7].Text);
			}
		}
		*/

		private void ViewOtherLoan()
		{
			DataTable dt = new DataTable();
			conn.QueryString = "select * from VW_CUSTOTHERLOAN where CU_REF ='"+ Request.QueryString["curef"]+"'";
			conn.ExecuteQuery();
			dt = conn.GetDataTable().Copy();
			DatGridOtherLoan.DataSource = dt;
			DatGridOtherLoan.DataBind();
			for (int i = 0; i < DatGridOtherLoan.Items.Count; i++)
			{
				DatGridOtherLoan.Items[i].Cells[4].Text = tool.MoneyFormat(DatGridOtherLoan.Items[i].Cells[4].Text);
				DatGridOtherLoan.Items[i].Cells[5].Text = tool.MoneyFormat(DatGridOtherLoan.Items[i].Cells[5].Text);
				DatGridOtherLoan.Items[i].Cells[6].Text = tool.MoneyFormat(DatGridOtherLoan.Items[i].Cells[6].Text);
				DatGridOtherLoan.Items[i].Cells[7].Text = tool.MoneyFormat(DatGridOtherLoan.Items[i].Cells[7].Text);
				//DatGridOtherLoan.Items[i].Cells[10].Text = DatGrid

				//---------- Protection Screen -----------------------------//
				if (Request.QueryString["de"] != "1") 
				{
					LinkButton LNK_DELETE	= (LinkButton) DatGridOtherLoan.Items[i].FindControl("LNK_DELETE");
					LNK_DELETE.Visible		= false;
					//DatGridOtherLoan.Items[i].Cells[12].Text = "Delete";
					//DatGridOtherLoan.Items[i].Cells[12].Enabled = false;
				}
				//---------- Protection Screen -----------------------------//
			}
		}

		private void BtnInsert1_Click(object sender, System.EventArgs e)
		{
			// Validasi Tanggal =======================================

			//--- Tanggal Due Date
			if (TXT_CO_DUEDATE_DAY.Text.Trim() != "" || DDL_CO_DUEDATE_MONTH.SelectedValue != "" || TXT_CO_DUEDATE_YEAR.Text.Trim() != "") 
			{
				if (!Tools.isDateValid(this, TXT_CO_DUEDATE_DAY.Text, DDL_CO_DUEDATE_MONTH.SelectedValue, TXT_CO_DUEDATE_YEAR.Text)) 
				{
					GlobalTools.popMessage(this, "Tanggal Due Date tidak valid!");
					return;
				}
			}

			//--- Tanggal Posisi
			if (TXT_CO_TGLPOSISI_D.Text.Trim() != "" || DDL_CO_TGLPOSISI_M.SelectedValue != "" || TXT_CO_TGLPOSISI_Y.Text.Trim() != "") 
			{
				if (!Tools.isDateValid(this, TXT_CO_TGLPOSISI_D.Text, DDL_CO_TGLPOSISI_M.SelectedValue, TXT_CO_TGLPOSISI_Y.Text)) 
				{
					GlobalTools.popMessage(this, "Tanggal Posisi tidak valid!");
					return;
				}
			}

			//--- Tanggal Debitur Sejak
			if (TXT_CO_TGLDEBITUR_D.Text.Trim() != "" || DDL_CO_TGLDEBITUR_M.SelectedValue != "" || TXT_CO_TGLDEBITUR_Y.Text.Trim() != "") 
			{
				if (!Tools.isDateValid(this, TXT_CO_TGLDEBITUR_D.Text, DDL_CO_TGLDEBITUR_M.SelectedValue, TXT_CO_TGLDEBITUR_Y.Text)) 
				{
					GlobalTools.popMessage(this, "Tanggal Debitur Sejak tidak valid!");
					return;
				}
			}
			//==========================================================
		

			try 
			{
				conn.QueryString = "exec DE_CUSTOTHERLOAN '0','" + Request.QueryString["curef"] +"', '','" +TXT_CO_CREDTYPE.Text+ "', " + tool.ConvertNull(DDL_CO_BANKNAME.SelectedValue)/* TXT_CO_BANKNAME.Text */+ ", " +
					tool.ConvertFloat(TXT_CO_LIMIT.Text)+ ", " +tool.ConvertFloat(TXT_CO_BAKIDEBET.Text)+ ", " +tool.ConvertFloat(TXT_CO_TGKPOKOK.Text)+ ", " +tool.ConvertFloat(TXT_CO_TGKBUNGA.Text)+ ", " +
					tool.ConvertDate(TXT_CO_DUEDATE_DAY.Text,DDL_CO_DUEDATE_MONTH.SelectedValue,TXT_CO_DUEDATE_YEAR.Text)+ ", " +tool.ConvertNull(DDL_CO_COLLECTABILITY.SelectedValue) + ", " + 
					tool.ConvertDate(TXT_CO_TGLPOSISI_D.Text, DDL_CO_TGLPOSISI_M.SelectedValue, TXT_CO_TGLPOSISI_Y.Text) + ", " + 
					tool.ConvertNull(DDL_RFJENISPRODUCT.SelectedValue) + ", " + 
					tool.ConvertDate(TXT_CO_TGLDEBITUR_D.Text, DDL_CO_TGLDEBITUR_M.SelectedValue, TXT_CO_TGLDEBITUR_Y.Text);
				conn.ExecuteQuery();				
			} 
			catch (NullReferenceException)
			{
				GlobalTools.popMessage(this, "Connection Error!");
				Response.Redirect("../Login.aspx?expire=1");
			}
			ViewOtherLoan();
			ClearDataOtherLoan();

			GlobalTools.SetFocus(this, TXT_CO_CREDTYPE);
		}

		private void ClearDataOtherLoan()
		{
			TXT_CO_CREDTYPE.Text		= "";
			DDL_CO_BANKNAME.SelectedValue = "";
			//TXT_CO_BANKNAME.Text		= "";
			TXT_CO_LIMIT.Text			= "";
			TXT_CO_BAKIDEBET.Text		= "";
			TXT_CO_TGKPOKOK.Text		= "";
			TXT_CO_TGKBUNGA.Text		= "";
			TXT_CO_TGLPOSISI_D.Text		= "";
			DDL_CO_TGLPOSISI_M.SelectedValue = "";
			TXT_CO_TGLPOSISI_Y.Text		= "";
			TXT_CO_DUEDATE_DAY.Text		= "";
			DDL_CO_DUEDATE_MONTH.SelectedValue	= "";
			TXT_CO_DUEDATE_YEAR.Text			= "";
			DDL_CO_COLLECTABILITY.SelectedValue	= "";
			DDL_RFJENISPRODUCT.SelectedValue = "";
			TXT_CO_TGLDEBITUR_D.Text		= "";
			DDL_CO_TGLDEBITUR_M.SelectedValue = "";
			TXT_CO_TGLDEBITUR_Y.Text		= "";
		}

		private void DatGridOtherLoan_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			switch (((LinkButton)e.CommandSource).CommandName)
			{
				case "delete":
					string vCO_SEQ = e.Item.Cells[1].Text;
					conn.QueryString = "exec SP_CUSTOTHERLOAN '1','"+ e.Item.Cells[0].Text +"', " +e.Item.Cells[1].Text+ ",'', '', 0,0,0,0,'','', '" + vCO_SEQ + "'";
					conn.ExecuteNonQuery();
					ViewOtherLoan();
				break;
			}
		}

		private void BTN_SAVE_Click(object sender, System.EventArgs e)
		{
			/*
			string CA_KETHUTANG, CA_KETOVERDRAFT;
            CA_KETHUTANG = "0";
			CA_KETOVERDRAFT = "0";
			
			if (RDO_CA_KETHUTANG1.Checked)
				CA_KETHUTANG = "1";
			if (RDO_CA_KETOVERDRAFT1.Checked)
				CA_KETOVERDRAFT = "1";
			
		
			conn.QueryString = "exec DE_HUBUNGANBANK '" +Request.QueryString["curef"]+ "', " +tool.ConvertDate(TXT_CI_BMGIRO_DAY.Text,DDL_CI_BMGIRO_MONTH.SelectedValue,TXT_CI_BMGIRO_YEAR.Text)+ ", "+
								tool.ConvertDate(TXT_CI_BMSAVING_DAY.Text,DDL_CI_BMSAVING_MONTH.SelectedValue,TXT_CI_BMSAVING_YEAR.Text)+", '" +TXT_CI_BMSAVINGACCNO.Text+ "', " +tool.ConvertDate(TXT_CI_BMDEBITUR_DAY.Text,DDL_CI_BMDEBITUR_MONTH.SelectedValue,TXT_CI_BMDEBITUR_YEAR.Text)+
								", "+tool.ConvertDate(TXT_CI_BMFACDATE_DAY.Text,DDL_CI_BMFACDATE_MONTH.SelectedValue,TXT_CI_BMFACDATE_YEAR.Text)+", '" +TXT_CA_NOTE.Text+ "', " +tool.ConvertNum(TXT_CA_OVERDRAFT.Text)+ ", " +tool.ConvertNum(TXT_CA_PGUARANTEE.Text)+ ", '" +TXT_CA_KETOTHER.Text+ "', "+
								tool.ConvertNum(TXT_CA_OTHER.Text)+", '" +CA_KETHUTANG+ "', '" +CA_KETOVERDRAFT+ "'";
			*/
			string CA_ACCOUNTSTATUS;
			CA_ACCOUNTSTATUS = "0";
			
			if (RDO_CA_ACCOUNTSTATUS1.Checked)
				CA_ACCOUNTSTATUS = "1";

			conn.QueryString = "exec DE_HUBUNGANBANK '" +Request.QueryString["curef"]+ "', " +tool.ConvertDate(TXT_CI_BMGIRO_DAY.Text,DDL_CI_BMGIRO_MONTH.SelectedValue,TXT_CI_BMGIRO_YEAR.Text)+ ", "+
				tool.ConvertDate(TXT_CI_BMSAVING_DAY.Text,DDL_CI_BMSAVING_MONTH.SelectedValue,TXT_CI_BMSAVING_YEAR.Text)+", " +tool.ConvertDate(TXT_CI_BMDEBITUR_DAY.Text,DDL_CI_BMDEBITUR_MONTH.SelectedValue,TXT_CI_BMDEBITUR_YEAR.Text)+
                ", '" + TXT_CA_NOTE.Text + "', null, null, null, null, null, null,'" + CA_ACCOUNTSTATUS + "', '" + TXT_CI_BMSAVINGACCNO.Text + "'";

			conn.ExecuteNonQuery();
			ViewData();
		}

		/*
		private void BTN_INSERTAVG_Click(object sender, System.EventArgs e)
		{
			conn.QueryString = "exec SP_CUSTLISTACC '" +Request.QueryString["curef"]+ "', '', " +tool.ConvertDate("1",DDL_CA_DATESALDO_MONTH.SelectedValue,TXT_CA_DATESALDO_YEAR.Text)+ ", '" +DDL_CA_CURRENCY.SelectedValue+ "', "+
								tool.ConvertNum(TXT_CA_AVGSALDO.Text)+", " +tool.ConvertNum(TXT_CA_DEBET.Text)+ ", " +tool.ConvertNum(TXT_CA_FREKDEB.Text)+ ", " +tool.ConvertNum(TXT_CA_CREDIT.Text)+ ", "+tool.ConvertNum(TXT_CA_FREKCRED.Text)+ ",'1'";
			conn.ExecuteNonQuery();
			ViewSaldo();
			ClearDataSaldo();
		}

		
		private void ClearDataSaldo()
		{
			DDL_CA_CURRENCY.SelectedValue			= "";
			DDL_CA_DATESALDO_MONTH.SelectedValue	= "";
			TXT_CA_AVGSALDO.Text					= "";
			TXT_CA_CREDIT.Text						= "";
			TXT_CA_DATESALDO_YEAR.Text				= "";
			TXT_CA_DEBET.Text						= "";
			TXT_CA_FREKCRED.Text					= "";
			TXT_CA_FREKDEB.Text						= "";
		}
		

		private void DatGridSaldo_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			conn.QueryString = "exec SP_CUSTLISTACC '" +e.Item.Cells[0].Text+ "', " +e.Item.Cells[1].Text+ ",'','','','','','','', '2'";
			conn.ExecuteNonQuery();
			ViewSaldo();
		}
		*/

		private void ViewMenu()
		{
			try 
			{
				conn.QueryString = "select * from SCREENMENU where menucode = '"+Request.QueryString["mc"]+"'";
				conn.ExecuteQuery();
				for (int i = 0; i < conn.GetRowCount(); i++) 
				{
					HyperLink t = new HyperLink();
					t.Text = conn.GetFieldValue(i, 2);
					t.Font.Bold = true;
					string strtemp = "";
					if (conn.GetFieldValue(i, 3).Trim()!= "") 
					{
						if (conn.GetFieldValue(i,3).IndexOf("mc=") >= 0)
							strtemp = "regno=" + Request.QueryString["regno"] + "&curef="+Request.QueryString["curef"]+"&tc="+Request.QueryString["tc"];
						else	strtemp = "regno=" + Request.QueryString["regno"] + "&curef="+Request.QueryString["curef"]+"&mc="+Request.QueryString["mc"]+"&tc="+Request.QueryString["tc"];
						//t.ForeColor = Color.MidnightBlue; 
						 if (conn.GetFieldValue(i,3).IndexOf("?de=") < 0 && conn.GetFieldValue(i,3).IndexOf("&de=") < 0) 
							strtemp = strtemp + "&de=" + Request.QueryString["de"];
						if (conn.GetFieldValue(i,3).IndexOf("?par=") < 0 && conn.GetFieldValue(i,3).IndexOf("&par=") < 0)  
							strtemp = strtemp + "&par=" + Request.QueryString["par"];
					}
					else 
					{
						strtemp = "";
						t.ForeColor = Color.Red; 
					}
					t.NavigateUrl = conn.GetFieldValue(i, 3)+strtemp;
					Menu.Controls.Add(t);
					Menu.Controls.Add(new LiteralControl("&nbsp;&nbsp;&nbsp;"));
				}
			} 
			catch (Exception ex) 
			{
				string temp = ex.ToString();
			}
		}

		private void BTN_BACK_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			if (Request.QueryString["par"] != null && Request.QueryString["par"] != "") 
				Response.Redirect(Request.QueryString["par"] + "&regno=" + Request.QueryString["regno"] + "&curef=" + Request.QueryString["curef"] + "&tc=" + Request.QueryString["tc"]);
			else
				Response.Redirect("/SME/" + DMS.CuBESCore.Logic.backLink(Request.QueryString["tc"].ToString(), conn));

		}

		private void BTN_SAVEGRP_Click(object sender, System.EventArgs e)
		{
			double CG_COMMITTED, CG_UNCOMMITTED, CG_CASHLOAN;
			double TotLimit = 0, bakiDebet = 0, TotSub=0;

			//ahmad: begin ######################################################################

			///
			/// nilai cash loan, non cash loan, other, commited, uncomited, tidak boleh negatif
			/// 

			if ( Double.Parse(TXT_CG_CASHLOAN.Text) < 0 )
			{
				Response.Write("<script language='javascript'>alert('Cash Loan tidak boleh negatif');</script>");
				Tools.SetFocus(this, TXT_CG_CASHLOAN);
				return;
			}
			else if ( Double.Parse(TXT_CG_NONCASHLOAN.Text) < 0 )
			{
				Response.Write("<script language='javascript'>alert('Non Cash Loan tidak boleh negatif');</script>");
				Tools.SetFocus(this, TXT_CG_NONCASHLOAN);
				return;
			}
			else if ( Double.Parse(TXT_CG_OTHERS.Text) < 0 )
			{
				Response.Write("<script language='javascript'>alert('Others tidak boleh negatif');</script>");
				Tools.SetFocus(this, TXT_CG_OTHERS);
				return;
			}
			else if ( Double.Parse(TXT_CG_COMMITTED.Text) < 0 )
			{
				Response.Write("<script language='javascript'>alert('Commited tidak boleh negatif');</script>");
				Tools.SetFocus(this, TXT_CG_COMMITTED);
				return;
			}
			else if ( Double.Parse(TXT_CG_UNCOMMITTED.Text) < 0 )
			{
				Response.Write("<script language='javascript'>alert('Uncommited tidak boleh negatif');</script>");
				Tools.SetFocus(this, TXT_CG_UNCOMMITTED);
				return;
			}
			//ahmad: end ########################################################################

			try {CG_COMMITTED = Convert.ToDouble(tool.ConvertFloat(TXT_CG_COMMITTED.Text));}
			catch {CG_COMMITTED = 0.00;}

			try {CG_UNCOMMITTED = Convert.ToDouble(tool.ConvertFloat(TXT_CG_UNCOMMITTED.Text));}
			catch {CG_UNCOMMITTED = 0.00;}

			try {CG_CASHLOAN = Convert.ToDouble(tool.ConvertFloat(TXT_CG_CASHLOAN.Text));}
			catch {CG_CASHLOAN = 0.00;}

			if (CG_COMMITTED + CG_UNCOMMITTED != CG_CASHLOAN) 
			{
				GlobalTools.popMessage(this, "Jumlah nilai Committed dan nilai UnCommitted harus sama dengan nilai Cash Loan");
				Tools.SetFocus(this, TXT_CG_COMMITTED);
				return;
			}

			conn.QueryString = "exec DE_CUST_GRPMANDIRIFAC '" + 
						Request.QueryString["curef"] + "', " + 
						tool.ConvertFloat(TXT_CG_CASHLOAN.Text) + ", " + 
						tool.ConvertFloat(TXT_CG_NONCASHLOAN.Text) + ", " + 
						tool.ConvertFloat(TXT_CG_OTHERS.Text) + ", " + 
						tool.ConvertFloat(TXT_CG_TOTAL.Text) + ", " +
						tool.ConvertFloat(TXT_CG_COMMITTED.Text) + "," +
						tool.ConvertFloat(TXT_CG_UNCOMMITTED.Text);
			conn.ExecuteNonQuery();

			conn.QueryString = "exec DE_CALCULATE_TOTALEXPOSURE '" + Request.QueryString["regno"] + "', '" + Request.QueryString["curef"] + "'";
			conn.ExecuteQuery(300);
			//TXT_TOTAL.Text = tool.MoneyFormat(conn.GetFieldValue(0,0));

			// aak coba
			TXT_TOTAL.Text = tool.MoneyFormat(conn.GetFieldValue(0,"GROUP_EXPOSURE"));


			for (int i = 0; i < DatGridMandiriLoan.Items.Count; i++)
			{
				double nilai = 0;
				try { nilai = double.Parse(DatGridMandiriLoan.Items[i].Cells[4].Text); } catch {}
				TotLimit = TotLimit + nilai;
			}
			
			
			TotSub = TotLimit+double.Parse(TXT_CG_TOTAL.Text);
			//added by rene
			//TXT_SUBTOTAL.Text	= tool.MoneyFormat(TotSub.ToString());
			TXT_SUBTOTAL.Text	= tool.MoneyFormat(TXT_CG_TOTAL.Text);
		}

		private void LNK_SALDO_RATA2_Click(object sender, System.EventArgs e)
		{
			Response.Write("<script for=window event=onload language='javascript'>PopupPage('arMutasiRekening.aspx','800','400');</script>");
		}

		private void ViewSaldoRata()
		{ 
			conn.QueryString = "select * from VW_MUTASI_REKENING where AP_REGNO = '" + Request.QueryString["regno"] + "' and CU_REF = '" + Request.QueryString["curef"] + "';";
			conn.ExecuteQuery();

			if(conn.GetRowCount() == 0)
			{
				conn.QueryString = "select * from VW_MUTASI_REKENING where AP_REGNO = '" + Request.QueryString["curef"] + "C" + "' and CU_REF = '" + Request.QueryString["curef"] + "';";
				conn.ExecuteQuery();
			}

			try
			{
				try {Tools.fromSQLDate(conn.GetFieldValue("MR_M1_BLN"), this.txt_TempDD, this.ddl_MR_M1_BLN_mm, this.txt_MR_M1_BLN_yy);}
				catch {}
				this.txt_MR_M1_SLDRATA.Text = tool.MoneyFormat(conn.GetFieldValue("MR_M1_SLDRATA"));
				this.txt_MR_M1_DEBET.Text = tool.MoneyFormat(conn.GetFieldValue("MR_M1_DEBET"));
				this.txt_MR_M1_DEBETF.Text = conn.GetFieldValue("MR_M1_DEBETF");
				this.txt_MR_M1_KREDIT.Text = tool.MoneyFormat(conn.GetFieldValue("MR_M1_KREDIT"));
				this.txt_MR_M1_KREDITF.Text = conn.GetFieldValue("MR_M1_KREDITF");
 
				try {Tools.fromSQLDate(conn.GetFieldValue("MR_M2_BLN"), this.txt_TempDD, this.ddl_MR_M2_BLN_mm, this.txt_MR_M2_BLN_yy);}
				catch {}
				this.txt_MR_M2_SLDRATA.Text = tool.MoneyFormat(conn.GetFieldValue("MR_M2_SLDRATA"));
				this.txt_MR_M2_DEBET.Text = tool.MoneyFormat(conn.GetFieldValue("MR_M2_DEBET"));
				this.txt_MR_M2_DEBETF.Text = conn.GetFieldValue("MR_M2_DEBETF");
				this.txt_MR_M2_KREDIT.Text = tool.MoneyFormat(conn.GetFieldValue("MR_M2_KREDIT"));
				this.txt_MR_M2_KREDITF.Text = conn.GetFieldValue("MR_M2_KREDITF");

				try {Tools.fromSQLDate(conn.GetFieldValue("MR_M3_BLN"), this.txt_TempDD, this.ddl_MR_M3_BLN_mm, this.txt_MR_M3_BLN_yy);}
				catch {}
				this.txt_MR_M3_SLDRATA.Text = tool.MoneyFormat(conn.GetFieldValue("MR_M3_SLDRATA"));
				this.txt_MR_M3_DEBET.Text = tool.MoneyFormat(conn.GetFieldValue("MR_M3_DEBET"));
				this.txt_MR_M3_DEBETF.Text = conn.GetFieldValue("MR_M3_DEBETF");
				this.txt_MR_M3_KREDIT.Text = tool.MoneyFormat(conn.GetFieldValue("MR_M3_KREDIT"));
				this.txt_MR_M3_KREDITF.Text = conn.GetFieldValue("MR_M3_KREDITF");

				try {Tools.fromSQLDate(conn.GetFieldValue("MR_M4_BLN"), this.txt_TempDD, this.ddl_MR_M4_BLN_mm, this.txt_MR_M4_BLN_yy);}
				catch {}
				this.txt_MR_M4_SLDRATA.Text = tool.MoneyFormat(conn.GetFieldValue("MR_M4_SLDRATA"));
				this.txt_MR_M4_DEBET.Text = tool.MoneyFormat(conn.GetFieldValue("MR_M4_DEBET"));
				this.txt_MR_M4_DEBETF.Text = conn.GetFieldValue("MR_M4_DEBETF");
				this.txt_MR_M4_KREDIT.Text = tool.MoneyFormat(conn.GetFieldValue("MR_M4_KREDIT"));
				this.txt_MR_M4_KREDITF.Text = conn.GetFieldValue("MR_M4_KREDITF");

				try {Tools.fromSQLDate(conn.GetFieldValue("MR_M5_BLN"), this.txt_TempDD, this.ddl_MR_M5_BLN_mm, this.txt_MR_M5_BLN_yy);}
				catch {}
				this.txt_MR_M5_SLDRATA.Text = tool.MoneyFormat(conn.GetFieldValue("MR_M5_SLDRATA"));
				this.txt_MR_M5_DEBET.Text = tool.MoneyFormat(conn.GetFieldValue("MR_M5_DEBET"));
				this.txt_MR_M5_DEBETF.Text = conn.GetFieldValue("MR_M5_DEBETF");
				this.txt_MR_M5_KREDIT.Text = tool.MoneyFormat(conn.GetFieldValue("MR_M5_KREDIT"));
				this.txt_MR_M5_KREDITF.Text = conn.GetFieldValue("MR_M5_KREDITF");

				try {Tools.fromSQLDate(conn.GetFieldValue("MR_M6_BLN"), this.txt_TempDD, this.ddl_MR_M6_BLN_mm, this.txt_MR_M6_BLN_yy);}
				catch {}
				this.txt_MR_M6_SLDRATA.Text = tool.MoneyFormat(conn.GetFieldValue("MR_M6_SLDRATA"));
				this.txt_MR_M6_DEBET.Text = tool.MoneyFormat(conn.GetFieldValue("MR_M6_DEBET"));
				this.txt_MR_M6_DEBETF.Text = conn.GetFieldValue("MR_M6_DEBETF");
				this.txt_MR_M6_KREDIT.Text = tool.MoneyFormat(conn.GetFieldValue("MR_M6_KREDIT"));
				this.txt_MR_M6_KREDITF.Text = conn.GetFieldValue("MR_M6_KREDITF");
				
				this.txt_MR_M1_SALDO.Text = tool.MoneyFormat(conn.GetFieldValue("MR_M1_SALDO"));
				this.txt_MR_LIMITKREDIT.Text = tool.MoneyFormat(conn.GetFieldValue("MR_LIMITKREDIT"));
				this.txt_MR_PRSNSALDO.Text = conn.GetFieldValue("MR_PRSNSALDO");
				this.txt_MR_CATATAN.Text = conn.GetFieldValue("MR_CATATAN");
			}
			catch {}
		}


		private bool CekTanggal()
		{
			try
			{
				if (!GlobalTools.isDateValid(this,1,Convert.ToInt16(ddl_MR_M1_BLN_mm.SelectedValue),Convert.ToInt16(txt_MR_M1_BLN_yy.Text)))
					return false;
			}
			catch {}

			try
			{
				if (!GlobalTools.isDateValid(this,1,Convert.ToInt16(ddl_MR_M2_BLN_mm.SelectedValue),Convert.ToInt16(txt_MR_M2_BLN_yy.Text)))
					return false;
			}
			catch {}

			try
			{
				if (!GlobalTools.isDateValid(this,1,Convert.ToInt16(ddl_MR_M3_BLN_mm.SelectedValue),Convert.ToInt16(txt_MR_M3_BLN_yy.Text)))
					return false;
			}
			catch {}

			try
			{
				if (!GlobalTools.isDateValid(this,1,Convert.ToInt16(ddl_MR_M4_BLN_mm.SelectedValue),Convert.ToInt16(txt_MR_M4_BLN_yy.Text)))
					return false;
			}
			catch {}

			try
			{
				if (!GlobalTools.isDateValid(this,1,Convert.ToInt16(ddl_MR_M5_BLN_mm.SelectedValue),Convert.ToInt16(txt_MR_M5_BLN_yy.Text)))
					return false;
			}
			catch {}

			try
			{
				if (!GlobalTools.isDateValid(this,1,Convert.ToInt16(ddl_MR_M6_BLN_mm.SelectedValue),Convert.ToInt16(txt_MR_M6_BLN_yy.Text)))
					return false;
			}
			catch {}

			return true;
		}

		private void btn_SaveSaldo_Click(object sender, System.EventArgs e)
		{
			if (CekTanggal())
			{
				conn.QueryString = "SP_TMP_MUTASI_REKENING 'Delete','',0,0,0,0,0,0";
				conn.ExecuteQuery();

				conn.QueryString = "SP_TMP_MUTASI_REKENING 'Save'," + 
					GlobalTools.ToSQLDate("1",this.ddl_MR_M1_BLN_mm.SelectedValue,this.txt_MR_M1_BLN_yy.Text) +","+
					tool.ConvertFloat(this.txt_MR_M1_SLDRATA.Text) +","+ 
					tool.ConvertFloat(this.txt_MR_M1_SALDO.Text) +","+ 
					tool.ConvertFloat(this.txt_MR_M1_DEBET.Text) +","+ 
					tool.ConvertFloat(this.txt_MR_M1_DEBETF.Text) +","+ 
					tool.ConvertFloat(this.txt_MR_M1_KREDIT.Text) +","+ 
					tool.ConvertFloat(this.txt_MR_M1_KREDITF.Text);
				conn.ExecuteQuery();

				conn.QueryString = "SP_TMP_MUTASI_REKENING 'Save'," + 
					GlobalTools.ToSQLDate("1",this.ddl_MR_M2_BLN_mm.SelectedValue,this.txt_MR_M2_BLN_yy.Text) +","+
					tool.ConvertFloat(this.txt_MR_M2_SLDRATA.Text) +","+ 
					tool.ConvertFloat(this.txt_MR_M1_SALDO.Text) +","+ 
					tool.ConvertFloat(this.txt_MR_M2_DEBET.Text) +","+ 
					tool.ConvertFloat(this.txt_MR_M2_DEBETF.Text) +","+ 
					tool.ConvertFloat(this.txt_MR_M2_KREDIT.Text) +","+ 
					tool.ConvertFloat(this.txt_MR_M2_KREDITF.Text);
				conn.ExecuteQuery();

				conn.QueryString = "SP_TMP_MUTASI_REKENING 'Save'," + 
					GlobalTools.ToSQLDate("1",this.ddl_MR_M3_BLN_mm.SelectedValue,this.txt_MR_M3_BLN_yy.Text) +","+
					tool.ConvertFloat(this.txt_MR_M3_SLDRATA.Text) +","+ 
					tool.ConvertFloat(this.txt_MR_M1_SALDO.Text) +","+ 
					tool.ConvertFloat(this.txt_MR_M3_DEBET.Text) +","+ 
					tool.ConvertFloat(this.txt_MR_M3_DEBETF.Text) +","+ 
					tool.ConvertFloat(this.txt_MR_M3_KREDIT.Text) +","+ 
					tool.ConvertFloat(this.txt_MR_M3_KREDITF.Text);
				conn.ExecuteQuery();

				conn.QueryString = "SP_TMP_MUTASI_REKENING 'Save'," + 
					GlobalTools.ToSQLDate("1",this.ddl_MR_M4_BLN_mm.SelectedValue,this.txt_MR_M4_BLN_yy.Text) +","+
					tool.ConvertFloat(this.txt_MR_M4_SLDRATA.Text) +","+ 
					tool.ConvertFloat(this.txt_MR_M1_SALDO.Text) +","+ 
					tool.ConvertFloat(this.txt_MR_M4_DEBET.Text) +","+ 
					tool.ConvertFloat(this.txt_MR_M4_DEBETF.Text) +","+ 
					tool.ConvertFloat(this.txt_MR_M4_KREDIT.Text) +","+ 
					tool.ConvertFloat(this.txt_MR_M4_KREDITF.Text);
				conn.ExecuteQuery();

				conn.QueryString = "SP_TMP_MUTASI_REKENING 'Save'," + 
					GlobalTools.ToSQLDate("1",this.ddl_MR_M5_BLN_mm.SelectedValue,this.txt_MR_M5_BLN_yy.Text) +","+
					tool.ConvertFloat(this.txt_MR_M5_SLDRATA.Text) +","+ 
					tool.ConvertFloat(this.txt_MR_M1_SALDO.Text) +","+ 
					tool.ConvertFloat(this.txt_MR_M5_DEBET.Text) +","+ 
					tool.ConvertFloat(this.txt_MR_M5_DEBETF.Text) +","+ 
					tool.ConvertFloat(this.txt_MR_M5_KREDIT.Text) +","+ 
					tool.ConvertFloat(this.txt_MR_M5_KREDITF.Text);
				conn.ExecuteQuery();

				conn.QueryString = "SP_TMP_MUTASI_REKENING 'Save'," + 
					GlobalTools.ToSQLDate("1",this.ddl_MR_M6_BLN_mm.SelectedValue,this.txt_MR_M6_BLN_yy.Text) +","+
					tool.ConvertFloat(this.txt_MR_M6_SLDRATA.Text) +","+ 
					tool.ConvertFloat(this.txt_MR_M1_SALDO.Text) +","+ 
					tool.ConvertFloat(this.txt_MR_M6_DEBET.Text) +","+ 
					tool.ConvertFloat(this.txt_MR_M6_DEBETF.Text) +","+ 
					tool.ConvertFloat(this.txt_MR_M6_KREDIT.Text) +","+ 
					tool.ConvertFloat(this.txt_MR_M6_KREDITF.Text);
				conn.ExecuteQuery();


				conn.QueryString = "select * from TMP_MUTASI_REKENING where TM_BLN is not null order by TM_BLN asc";
				conn.ExecuteQuery();
				System.Data.DataTable dtMR = new System.Data.DataTable();
				dtMR = conn.GetDataTable().Copy();

				string[] aBulan = new string[6];
				string[] aSaldoRata = new string[6];
				string[] aSaldo = new string[6];
				string[] aDebet = new string[6];
				string[] aDebetF = new string[6];
				string[] aKredit = new string[6];
				string[] aKreditF = new string[6];
			
				for (int i = 0; i <= 5; i++)
				{
					if (i < dtMR.Rows.Count)
					{
						aBulan[i] = "'"+Strings.Format(DateTime.Parse(dtMR.Rows[i]["TM_BLN"].ToString()),"yyyy-MM-dd")+"'";
						aSaldoRata[i] = tool.ConvertFloat(dtMR.Rows[i]["TM_SLDRATA"].ToString());
						aSaldo[i] = tool.ConvertFloat(dtMR.Rows[i]["TM_SALDO"].ToString());
						aDebet[i] = tool.ConvertFloat(dtMR.Rows[i]["TM_DEBET"].ToString());
						aDebetF[i] = tool.ConvertFloat(dtMR.Rows[i]["TM_DEBETF"].ToString());
						aKredit[i] = tool.ConvertFloat(dtMR.Rows[i]["TM_KREDIT"].ToString());
						aKreditF[i] = tool.ConvertFloat(dtMR.Rows[i]["TM_KREDITF"].ToString());
					}
					else
					{
						aBulan[i] = "null";
						aSaldoRata[i] = "0";
						aSaldo[i] = "0";
						aDebet[i] = "0";
						aDebetF[i] = "0";
						aKredit[i] = "0";
						aKreditF[i] = "0";
					}
				}

				string _MR_LIMITKREDIT = GlobalTools.ConvertFloat(this.txt_MR_LIMITKREDIT.Text);
				string _MR_PRSNSALDO = GlobalTools.ConvertFloat(this.txt_MR_PRSNSALDO.Text);
				conn.QueryString = "exec SP_MUTASI_REKENING 'Save','" + Request.QueryString["regno"] + "','" + Request.QueryString["curef"] + "'," +
					aBulan[0] + "," +
					aSaldoRata[0] + "," +
					aSaldo[0] + "," +
					aDebet[0] + "," +
					aDebetF[0] + "," +
					aKredit[0] + "," +
					aKreditF[0] + "," +
					//----------------------------------------
					aBulan[1] + "," +
					aSaldoRata[1] + "," +
					aDebet[1] + "," +
					aDebetF[1] + "," +
					aKredit[1] + "," +
					aKreditF[1] + "," +
					//----------------------------------------
					aBulan[2] + "," +
					aSaldoRata[2] + "," +
					aDebet[2] + "," +
					aDebetF[2] + "," +
					aKredit[2] + "," +
					aKreditF[2] + "," +
					//----------------------------------------
					aBulan[3] + "," +
					aSaldoRata[3] + "," +
					aDebet[3] + "," +
					aDebetF[3] + "," +
					aKredit[3] + "," +
					aKreditF[3] + "," +
					//----------------------------------------
					aBulan[4] + "," +
					aSaldoRata[4] + "," +
					aDebet[4] + "," +
					aDebetF[4] + "," +
					aKredit[4] + "," +
					aKreditF[4] + "," +
					//----------------------------------------
					aBulan[5] + "," +
					aSaldoRata[5] + "," +
					aDebet[5] + "," +
					aDebetF[5] + "," +
					aKredit[5] + "," +
					aKreditF[5] + ", '" +
					_MR_LIMITKREDIT + "', '" +
					_MR_PRSNSALDO + "' ,'" +
					//tool.ConvertFloat(tool.ConvertFloat(this.txt_MR_LIMITKREDIT.Text)) + "," +
					//tool.ConvertFloat(tool.ConvertFloat(this.txt_MR_PRSNSALDO.Text)) + ",'" +
					this.txt_MR_CATATAN.Text + "'";

				try
				{
					conn.ExecuteQuery();
				}
				catch
				{
					Response.Write("<script language='javascript'>alert('Ada masalah waktu penyimpanan data');</script>");
				}
			}
		}

		private bool CekTanggalOB()
		{
			try
			{
				if (!GlobalTools.isDateValid(this,1,Convert.ToInt16(ddl_MO_M1_BLN_mm.SelectedValue),Convert.ToInt16(txt_MO_M1_BLN_yy.Text)))
					return false;
			}
			catch {}

			try
			{
				if (!GlobalTools.isDateValid(this,1,Convert.ToInt16(ddl_MO_M2_BLN_mm.SelectedValue),Convert.ToInt16(txt_MO_M2_BLN_yy.Text)))
					return false;
			}
			catch {}

			try
			{
				if (!GlobalTools.isDateValid(this,1,Convert.ToInt16(ddl_MO_M3_BLN_mm.SelectedValue),Convert.ToInt16(txt_MO_M3_BLN_yy.Text)))
					return false;
			}
			catch {}

			try
			{
				if (!GlobalTools.isDateValid(this,1,Convert.ToInt16(ddl_MO_M4_BLN_mm.SelectedValue),Convert.ToInt16(txt_MO_M4_BLN_yy.Text)))
					return false;
			}
			catch {}

			try
			{
				if (!GlobalTools.isDateValid(this,1,Convert.ToInt16(ddl_MO_M5_BLN_mm.SelectedValue),Convert.ToInt16(txt_MO_M5_BLN_yy.Text)))
					return false;
			}
			catch {}

			try
			{
				if (!GlobalTools.isDateValid(this,1,Convert.ToInt16(ddl_MO_M6_BLN_mm.SelectedValue),Convert.ToInt16(txt_MO_M6_BLN_yy.Text)))
					return false;
			}
			catch {}

			return true;
		}

		private void btn_SaveSaldoOB_Click(object sender, System.EventArgs e)
		{
			if (CekTanggalOB())
			{
				conn.QueryString = "SP_TMP_MUTASI_REKENING 'Delete','',0,0,0,0,0,0";
				conn.ExecuteQuery();

				conn.QueryString = "SP_TMP_MUTASI_REKENING 'Save'," + 
					GlobalTools.ToSQLDate("1",this.ddl_MO_M1_BLN_mm.SelectedValue,this.txt_MO_M1_BLN_yy.Text) +","+
					tool.ConvertFloat(this.txt_MO_M1_SLDRATA.Text) +","+ 
					tool.ConvertFloat(this.txt_MO_M1_SALDO.Text) +","+ 
					tool.ConvertFloat(this.txt_MO_M1_DEBET.Text) +","+ 
					tool.ConvertFloat(this.txt_MO_M1_DEBETF.Text) +","+ 
					tool.ConvertFloat(this.txt_MO_M1_KREDIT.Text) +","+ 
					tool.ConvertFloat(this.txt_MO_M1_KREDITF.Text);
				conn.ExecuteQuery();

				conn.QueryString = "SP_TMP_MUTASI_REKENING 'Save'," + 
					GlobalTools.ToSQLDate("1",this.ddl_MO_M2_BLN_mm.SelectedValue,this.txt_MO_M2_BLN_yy.Text) +","+
					tool.ConvertFloat(this.txt_MO_M2_SLDRATA.Text) +","+ 
					tool.ConvertFloat(this.txt_MO_M1_SALDO.Text) +","+ 
					tool.ConvertFloat(this.txt_MO_M2_DEBET.Text) +","+ 
					tool.ConvertFloat(this.txt_MO_M2_DEBETF.Text) +","+ 
					tool.ConvertFloat(this.txt_MO_M2_KREDIT.Text) +","+ 
					tool.ConvertFloat(this.txt_MO_M2_KREDITF.Text);
				conn.ExecuteQuery();

				conn.QueryString = "SP_TMP_MUTASI_REKENING 'Save'," + 
					GlobalTools.ToSQLDate("1",this.ddl_MO_M3_BLN_mm.SelectedValue,this.txt_MO_M3_BLN_yy.Text) +","+
					tool.ConvertFloat(this.txt_MO_M3_SLDRATA.Text) +","+ 
					tool.ConvertFloat(this.txt_MO_M1_SALDO.Text) +","+ 
					tool.ConvertFloat(this.txt_MO_M3_DEBET.Text) +","+ 
					tool.ConvertFloat(this.txt_MO_M3_DEBETF.Text) +","+ 
					tool.ConvertFloat(this.txt_MO_M3_KREDIT.Text) +","+ 
					tool.ConvertFloat(this.txt_MO_M3_KREDITF.Text);
				conn.ExecuteQuery();

				conn.QueryString = "SP_TMP_MUTASI_REKENING 'Save'," + 
					GlobalTools.ToSQLDate("1",this.ddl_MO_M4_BLN_mm.SelectedValue,this.txt_MO_M4_BLN_yy.Text) +","+
					tool.ConvertFloat(this.txt_MO_M4_SLDRATA.Text) +","+ 
					tool.ConvertFloat(this.txt_MO_M1_SALDO.Text) +","+ 
					tool.ConvertFloat(this.txt_MO_M4_DEBET.Text) +","+ 
					tool.ConvertFloat(this.txt_MO_M4_DEBETF.Text) +","+ 
					tool.ConvertFloat(this.txt_MO_M4_KREDIT.Text) +","+ 
					tool.ConvertFloat(this.txt_MO_M4_KREDITF.Text);
				conn.ExecuteQuery();

				conn.QueryString = "SP_TMP_MUTASI_REKENING 'Save'," + 
					GlobalTools.ToSQLDate("1",this.ddl_MO_M5_BLN_mm.SelectedValue,this.txt_MO_M5_BLN_yy.Text) +","+
					tool.ConvertFloat(this.txt_MO_M5_SLDRATA.Text) +","+ 
					tool.ConvertFloat(this.txt_MO_M1_SALDO.Text) +","+ 
					tool.ConvertFloat(this.txt_MO_M5_DEBET.Text) +","+ 
					tool.ConvertFloat(this.txt_MO_M5_DEBETF.Text) +","+ 
					tool.ConvertFloat(this.txt_MO_M5_KREDIT.Text) +","+ 
					tool.ConvertFloat(this.txt_MO_M5_KREDITF.Text);
				conn.ExecuteQuery();

				conn.QueryString = "SP_TMP_MUTASI_REKENING 'Save'," + 
					GlobalTools.ToSQLDate("1",this.ddl_MO_M6_BLN_mm.SelectedValue,this.txt_MO_M6_BLN_yy.Text) +","+
					tool.ConvertFloat(this.txt_MO_M6_SLDRATA.Text) +","+ 
					tool.ConvertFloat(this.txt_MO_M1_SALDO.Text) +","+ 
					tool.ConvertFloat(this.txt_MO_M6_DEBET.Text) +","+ 
					tool.ConvertFloat(this.txt_MO_M6_DEBETF.Text) +","+ 
					tool.ConvertFloat(this.txt_MO_M6_KREDIT.Text) +","+ 
					tool.ConvertFloat(this.txt_MO_M6_KREDITF.Text);
				conn.ExecuteQuery();

				conn.QueryString = "select * from TMP_MUTASI_REKENING where TM_BLN is not null order by TM_BLN asc";
				conn.ExecuteQuery();
				System.Data.DataTable dtMR = new System.Data.DataTable();
				dtMR = conn.GetDataTable().Copy();

				string[] aBulan = new string[6];
				string[] aSaldoRata = new string[6];
				string[] aSaldo = new string[6];
				string[] aDebet = new string[6];
				string[] aDebetF = new string[6];
				string[] aKredit = new string[6];
				string[] aKreditF = new string[6];
			
				for (int i = 0; i <= 5; i++)
				{
					if (i < dtMR.Rows.Count)
					{
						aBulan[i] = "'"+Strings.Format(DateTime.Parse(dtMR.Rows[i]["TM_BLN"].ToString()),"yyyy-MM-dd")+"'";
						aSaldoRata[i] = tool.ConvertFloat(dtMR.Rows[i]["TM_SLDRATA"].ToString());
						aSaldo[i] = tool.ConvertFloat(dtMR.Rows[i]["TM_SALDO"].ToString());
						aDebet[i] = tool.ConvertFloat(dtMR.Rows[i]["TM_DEBET"].ToString());
						aDebetF[i] = tool.ConvertFloat(dtMR.Rows[i]["TM_DEBETF"].ToString());
						aKredit[i] = tool.ConvertFloat(dtMR.Rows[i]["TM_KREDIT"].ToString());
						aKreditF[i] = tool.ConvertFloat(dtMR.Rows[i]["TM_KREDITF"].ToString());
					}
					else
					{
						aBulan[i] = "null";
						aSaldoRata[i] = "0";
						aSaldo[i] = "0";
						aDebet[i] = "0";
						aDebetF[i] = "0";
						aKredit[i] = "0";
						aKreditF[i] = "0";
					}
				}

				string _MO_LIMITKREDIT = GlobalTools.ConvertFloat(this.txt_MO_LIMITKREDIT.Text);
				string _MO_PRSNSALDO = GlobalTools.ConvertFloat(this.txt_MO_PRSNSALDO.Text);
				conn.QueryString = "exec SP_MUTASI_REKENING_OTHER_BANK 'Save','" + Request.QueryString["regno"] + "','" + Request.QueryString["curef"] + "'," +
					aBulan[0] + "," +
					aSaldoRata[0] + "," +
					aSaldo[0] + "," +
					aDebet[0] + "," +
					aDebetF[0] + "," +
					aKredit[0] + "," +
					aKreditF[0] + "," +
					//----------------------------------------
					aBulan[1] + "," +
					aSaldoRata[1] + "," +
					aDebet[1] + "," +
					aDebetF[1] + "," +
					aKredit[1] + "," +
					aKreditF[1] + "," +
					//----------------------------------------
					aBulan[2] + "," +
					aSaldoRata[2] + "," +
					aDebet[2] + "," +
					aDebetF[2] + "," +
					aKredit[2] + "," +
					aKreditF[2] + "," +
					//----------------------------------------
					aBulan[3] + "," +
					aSaldoRata[3] + "," +
					aDebet[3] + "," +
					aDebetF[3] + "," +
					aKredit[3] + "," +
					aKreditF[3] + "," +
					//----------------------------------------
					aBulan[4] + "," +
					aSaldoRata[4] + "," +
					aDebet[4] + "," +
					aDebetF[4] + "," +
					aKredit[4] + "," +
					aKreditF[4] + "," +
					//----------------------------------------
					aBulan[5] + "," +
					aSaldoRata[5] + "," +
					aDebet[5] + "," +
					aDebetF[5] + "," +
					aKredit[5] + "," +
					aKreditF[5] + ", '" +
					_MO_LIMITKREDIT + "', '" +
					_MO_PRSNSALDO + "', '" +
					//tool.ConvertFloat(tool.ConvertFloat(this.txt_MO_LIMITKREDIT.Text)) + "," +
					//tool.ConvertFloat(tool.ConvertFloat(this.txt_MO_PRSNSALDO.Text)) + ",'" +
					this.txt_MO_CATATAN.Text + "'";

				try
				{
					conn.ExecuteQuery();
				}
				catch
				{
					Response.Write("<script language='javascript'>alert('Ada masalah waktu penyimpanan data');</script>");
				}
			}
		}




		private void ViewSaldoRataOB()
		{ 
			conn.QueryString = "select * from VW_MUTASI_REKENING_OTHER_BANK where AP_REGNO = '" + Request.QueryString["regno"] + "' and CU_REF = '" + Request.QueryString["curef"] + "';";
			conn.ExecuteQuery();

			if(conn.GetRowCount() == 0)
			{
				conn.QueryString = "select * from VW_MUTASI_REKENING_OTHER_BANK where AP_REGNO = '" + Request.QueryString["curef"] + "C" + "' and CU_REF = '" + Request.QueryString["curef"] + "';";
				conn.ExecuteQuery();
			}

			try
			{

				try {GlobalTools.fillDateForm(this.txt_TempDD, this.ddl_MO_M1_BLN_mm, this.txt_MO_M1_BLN_yy, Convert.ToDateTime(conn.GetFieldValue("MO_M1_BLN")));}
				catch {}
				this.txt_MO_M1_SLDRATA.Text = tool.MoneyFormat(conn.GetFieldValue("MO_M1_SLDRATA"));
				this.txt_MO_M1_DEBET.Text = tool.MoneyFormat(conn.GetFieldValue("MO_M1_DEBET"));
				this.txt_MO_M1_DEBETF.Text = conn.GetFieldValue("MO_M1_DEBETF");
				this.txt_MO_M1_KREDIT.Text = tool.MoneyFormat(conn.GetFieldValue("MO_M1_KREDIT"));
				this.txt_MO_M1_KREDITF.Text = conn.GetFieldValue("MO_M1_KREDITF");
 
				try {GlobalTools.fillDateForm(this.txt_TempDD, this.ddl_MO_M2_BLN_mm, this.txt_MO_M2_BLN_yy, Convert.ToDateTime(conn.GetFieldValue("MO_M2_BLN")));}
				catch {}
				this.txt_MO_M2_SLDRATA.Text = tool.MoneyFormat(conn.GetFieldValue("MO_M2_SLDRATA"));
				this.txt_MO_M2_DEBET.Text = tool.MoneyFormat(conn.GetFieldValue("MO_M2_DEBET"));
				this.txt_MO_M2_DEBETF.Text = conn.GetFieldValue("MO_M2_DEBETF");
				this.txt_MO_M2_KREDIT.Text = tool.MoneyFormat(conn.GetFieldValue("MO_M2_KREDIT"));
				this.txt_MO_M2_KREDITF.Text = conn.GetFieldValue("MO_M2_KREDITF");

				try {GlobalTools.fillDateForm(this.txt_TempDD, this.ddl_MO_M3_BLN_mm, this.txt_MO_M3_BLN_yy, Convert.ToDateTime(conn.GetFieldValue("MO_M3_BLN")));}
				catch {}
				this.txt_MO_M3_SLDRATA.Text = tool.MoneyFormat(conn.GetFieldValue("MO_M3_SLDRATA"));
				this.txt_MO_M3_DEBET.Text = tool.MoneyFormat(conn.GetFieldValue("MO_M3_DEBET"));
				this.txt_MO_M3_DEBETF.Text = conn.GetFieldValue("MO_M3_DEBETF");
				this.txt_MO_M3_KREDIT.Text = tool.MoneyFormat(conn.GetFieldValue("MO_M3_KREDIT"));
				this.txt_MO_M3_KREDITF.Text = conn.GetFieldValue("MO_M3_KREDITF");

				try {GlobalTools.fillDateForm(this.txt_TempDD, this.ddl_MO_M4_BLN_mm, this.txt_MO_M4_BLN_yy, Convert.ToDateTime(conn.GetFieldValue("MO_M4_BLN")));}
				catch {}
				this.txt_MO_M4_SLDRATA.Text = tool.MoneyFormat(conn.GetFieldValue("MO_M4_SLDRATA"));
				this.txt_MO_M4_DEBET.Text = tool.MoneyFormat(conn.GetFieldValue("MO_M4_DEBET"));
				this.txt_MO_M4_DEBETF.Text = conn.GetFieldValue("MO_M4_DEBETF");
				this.txt_MO_M4_KREDIT.Text = tool.MoneyFormat(conn.GetFieldValue("MO_M4_KREDIT"));
				this.txt_MO_M4_KREDITF.Text = conn.GetFieldValue("MO_M4_KREDITF");

				try {GlobalTools.fillDateForm(this.txt_TempDD, this.ddl_MO_M5_BLN_mm, this.txt_MO_M5_BLN_yy, Convert.ToDateTime(conn.GetFieldValue("MO_M5_BLN")));}
				catch {}
				this.txt_MO_M5_SLDRATA.Text = tool.MoneyFormat(conn.GetFieldValue("MO_M5_SLDRATA"));
				this.txt_MO_M5_DEBET.Text = tool.MoneyFormat(conn.GetFieldValue("MO_M5_DEBET"));
				this.txt_MO_M5_DEBETF.Text = conn.GetFieldValue("MO_M5_DEBETF");
				this.txt_MO_M5_KREDIT.Text = tool.MoneyFormat(conn.GetFieldValue("MO_M5_KREDIT"));
				this.txt_MO_M5_KREDITF.Text = conn.GetFieldValue("MO_M5_KREDITF");

				try {GlobalTools.fillDateForm(this.txt_TempDD, this.ddl_MO_M6_BLN_mm, this.txt_MO_M6_BLN_yy, Convert.ToDateTime(conn.GetFieldValue("MO_M6_BLN")));}
				catch {}
				this.txt_MO_M6_SLDRATA.Text = tool.MoneyFormat(conn.GetFieldValue("MO_M6_SLDRATA"));
				this.txt_MO_M6_DEBET.Text = tool.MoneyFormat(conn.GetFieldValue("MO_M6_DEBET"));
				this.txt_MO_M6_DEBETF.Text = conn.GetFieldValue("MO_M6_DEBETF");
				this.txt_MO_M6_KREDIT.Text = tool.MoneyFormat(conn.GetFieldValue("MO_M6_KREDIT"));
				this.txt_MO_M6_KREDITF.Text = conn.GetFieldValue("MO_M6_KREDITF");

				this.txt_MO_M1_SALDO.Text = tool.MoneyFormat(conn.GetFieldValue("MO_M1_SALDO"));
				this.txt_MO_LIMITKREDIT.Text = tool.MoneyFormat(conn.GetFieldValue("MO_LIMITKREDIT"));
				this.txt_MO_PRSNSALDO.Text = conn.GetFieldValue("MO_PRSNSALDO");
				this.txt_MO_CATATAN.Text = conn.GetFieldValue("MO_CATATAN");
			}
			catch {}
		}

		protected void btn_Calc_Click(object sender, System.EventArgs e)
		{
			HitungSaldo();
		}

		private void btn_CalcOB_Click(object sender, System.EventArgs e)
		{
			HitungSaldoOB();
		}

		private void HitungSaldo()
		{
			
			double TotSaldo, TotDebet, TotDebetF, TotKredit, TotKreditF,
				_MR_M1_SLDRATA, _MR_M2_SLDRATA, _MR_M3_SLDRATA, _MR_M4_SLDRATA, _MR_M5_SLDRATA, _MR_M6_SLDRATA,
				_MR_M1_DEBET, _MR_M2_DEBET, _MR_M3_DEBET, _MR_M4_DEBET, _MR_M5_DEBET, _MR_M6_DEBET,
				_MR_M1_DEBETF, _MR_M2_DEBETF, _MR_M3_DEBETF, _MR_M4_DEBETF, _MR_M5_DEBETF, _MR_M6_DEBETF,
				_MR_M1_KREDIT, _MR_M2_KREDIT, _MR_M3_KREDIT, _MR_M4_KREDIT, _MR_M5_KREDIT, _MR_M6_KREDIT,
				_MR_M1_KREDITF, _MR_M2_KREDITF, _MR_M3_KREDITF, _MR_M4_KREDITF, _MR_M5_KREDITF, _MR_M6_KREDITF, 
				BagiSaldo, BagiDebet, BagiDebetF, BagiKredit, BagiKreditF, RataSaldo, _MR_LIMITKREDIT;

			BagiSaldo = 0;
			BagiDebet = 0;
			BagiDebetF = 0;
			BagiKredit = 0;
			BagiKreditF = 0;

			//-----------------------------------------------------------------saldo rata-rata
			try {_MR_M1_SLDRATA = Double.Parse(this.txt_MR_M1_SLDRATA.Text);} 
			catch {_MR_M1_SLDRATA = 0;}
			if (_MR_M1_SLDRATA != 0) BagiSaldo++;

			try {_MR_M2_SLDRATA = Double.Parse(this.txt_MR_M2_SLDRATA.Text);} 
			catch {_MR_M2_SLDRATA = 0;}
			if (_MR_M2_SLDRATA != 0) BagiSaldo++;

			try {_MR_M3_SLDRATA = Double.Parse(this.txt_MR_M3_SLDRATA.Text);} 
			catch {_MR_M3_SLDRATA = 0;}
			if (_MR_M3_SLDRATA != 0) BagiSaldo++;

			try {_MR_M4_SLDRATA = Double.Parse(this.txt_MR_M4_SLDRATA.Text);} 
			catch {_MR_M4_SLDRATA = 0;}
			if (_MR_M4_SLDRATA != 0) BagiSaldo++;

			try {_MR_M5_SLDRATA = Double.Parse(this.txt_MR_M5_SLDRATA.Text);} 
			catch {_MR_M5_SLDRATA = 0;}
			if (_MR_M5_SLDRATA != 0) BagiSaldo++;

			try {_MR_M6_SLDRATA = Double.Parse(this.txt_MR_M6_SLDRATA.Text);} 
			catch {_MR_M6_SLDRATA = 0;}
			if (_MR_M6_SLDRATA != 0) BagiSaldo++;

			//-----------------------------------------------------------------debet
			try {_MR_M1_DEBET = Double.Parse(this.txt_MR_M1_DEBET.Text);} 
			catch {_MR_M1_DEBET = 0;}
			if (_MR_M1_DEBET != 0) BagiDebet++;

			try {_MR_M2_DEBET = Double.Parse(this.txt_MR_M2_DEBET.Text);} 
			catch {_MR_M2_DEBET = 0;}
			if (_MR_M2_DEBET != 0) BagiDebet++;

			try {_MR_M3_DEBET = Double.Parse(this.txt_MR_M3_DEBET.Text);} 
			catch {_MR_M3_DEBET = 0;}
			if (_MR_M3_DEBET != 0) BagiDebet++;

			try {_MR_M4_DEBET = Double.Parse(this.txt_MR_M4_DEBET.Text);} 
			catch {_MR_M4_DEBET = 0;}
			if (_MR_M4_DEBET != 0) BagiDebet++;

			try {_MR_M5_DEBET = Double.Parse(this.txt_MR_M5_DEBET.Text);} 
			catch {_MR_M5_DEBET = 0;}
			if (_MR_M5_DEBET != 0) BagiDebet++;

			try {_MR_M6_DEBET = Double.Parse(this.txt_MR_M6_DEBET.Text);} 
			catch {_MR_M6_DEBET = 0;}
			if (_MR_M6_DEBET != 0) BagiDebet++;

			//-----------------------------------------------------------------frekuensi debet
			try {_MR_M1_DEBETF = Double.Parse(this.txt_MR_M1_DEBETF.Text);} 
			catch {_MR_M1_DEBETF = 0;}
			if (_MR_M1_DEBETF != 0) BagiDebetF++;

			try {_MR_M2_DEBETF = Double.Parse(this.txt_MR_M2_DEBETF.Text);} 
			catch {_MR_M2_DEBETF = 0;}
			if (_MR_M2_DEBETF != 0) BagiDebetF++;

			try {_MR_M3_DEBETF = Double.Parse(this.txt_MR_M3_DEBETF.Text);} 
			catch {_MR_M3_DEBETF = 0;}
			if (_MR_M3_DEBETF != 0) BagiDebetF++;

			try {_MR_M4_DEBETF = Double.Parse(this.txt_MR_M4_DEBETF.Text);} 
			catch {_MR_M4_DEBETF = 0;}
			if (_MR_M4_DEBETF != 0) BagiDebetF++;

			try {_MR_M5_DEBETF = Double.Parse(this.txt_MR_M5_DEBETF.Text);} 
			catch {_MR_M5_DEBETF = 0;}
			if (_MR_M5_DEBETF != 0) BagiDebetF++;

			try {_MR_M6_DEBETF = Double.Parse(this.txt_MR_M6_DEBETF.Text);} 
			catch {_MR_M6_DEBETF = 0;}
			if (_MR_M6_DEBETF != 0) BagiDebetF++;

			//-----------------------------------------------------------------kredit
			try {_MR_M1_KREDIT = Double.Parse(this.txt_MR_M1_KREDIT.Text);} 
			catch {_MR_M1_KREDIT = 0;}
			if (_MR_M1_KREDIT != 0) BagiKredit++;

			try {_MR_M2_KREDIT = Double.Parse(this.txt_MR_M2_KREDIT.Text);} 
			catch {_MR_M2_KREDIT = 0;}
			if (_MR_M2_KREDIT != 0) BagiKredit++;

			try {_MR_M3_KREDIT = Double.Parse(this.txt_MR_M3_KREDIT.Text);} 
			catch {_MR_M3_KREDIT = 0;}
			if (_MR_M3_KREDIT != 0) BagiKredit++;

			try {_MR_M4_KREDIT = Double.Parse(this.txt_MR_M4_KREDIT.Text);} 
			catch {_MR_M4_KREDIT = 0;}
			if (_MR_M4_KREDIT != 0) BagiKredit++;

			try {_MR_M5_KREDIT = Double.Parse(this.txt_MR_M5_KREDIT.Text);} 
			catch {_MR_M5_KREDIT = 0;}
			if (_MR_M5_KREDIT != 0) BagiKredit++;

			try {_MR_M6_KREDIT = Double.Parse(this.txt_MR_M6_KREDIT.Text);} 
			catch {_MR_M6_KREDIT = 0;}
			if (_MR_M6_KREDIT != 0) BagiKredit++;

			//-----------------------------------------------------------------frekuensi kredit
			try {_MR_M1_KREDITF = Double.Parse(this.txt_MR_M1_KREDITF.Text);} 
			catch {_MR_M1_KREDITF = 0;}
			if (_MR_M1_KREDITF != 0) BagiKreditF++;

			try {_MR_M2_KREDITF = Double.Parse(this.txt_MR_M2_KREDITF.Text);} 
			catch {_MR_M2_KREDITF = 0;}
			if (_MR_M2_KREDITF != 0) BagiKreditF++;

			try {_MR_M3_KREDITF = Double.Parse(this.txt_MR_M3_KREDITF.Text);} 
			catch {_MR_M3_KREDITF = 0;}
			if (_MR_M3_KREDITF != 0) BagiKreditF++;

			try {_MR_M4_KREDITF = Double.Parse(this.txt_MR_M4_KREDITF.Text);} 
			catch {_MR_M4_KREDITF = 0;}
			if (_MR_M4_KREDITF != 0) BagiKreditF++;

			try {_MR_M5_KREDITF = Double.Parse(this.txt_MR_M5_KREDITF.Text);} 
			catch {_MR_M5_KREDITF = 0;}
			if (_MR_M5_KREDITF != 0) BagiKreditF++;

			try {_MR_M6_KREDITF = Double.Parse(this.txt_MR_M6_KREDITF.Text);} 
			catch {_MR_M6_KREDITF = 0;}
			if (_MR_M6_KREDITF != 0) BagiKreditF++;

			try {_MR_LIMITKREDIT  = Double.Parse(this.txt_MR_LIMITKREDIT .Text);} 
			catch {_MR_LIMITKREDIT  = 0;}


			//-----------------------------------------------------------------
			TotSaldo = _MR_M1_SLDRATA + _MR_M2_SLDRATA + _MR_M3_SLDRATA + _MR_M4_SLDRATA + _MR_M5_SLDRATA + _MR_M6_SLDRATA;

			TotDebet = _MR_M1_DEBET + _MR_M2_DEBET + _MR_M3_DEBET + _MR_M4_DEBET + _MR_M5_DEBET + _MR_M6_DEBET;

			TotDebetF = _MR_M1_DEBETF + _MR_M2_DEBETF + _MR_M3_DEBETF + _MR_M4_DEBETF + _MR_M5_DEBETF + _MR_M6_DEBETF;

			TotKredit = _MR_M1_KREDIT + _MR_M2_KREDIT + _MR_M3_KREDIT + _MR_M4_KREDIT + _MR_M5_KREDIT + _MR_M6_KREDIT;

			TotKreditF = _MR_M1_KREDITF + _MR_M2_KREDITF + _MR_M3_KREDITF + _MR_M4_KREDITF + _MR_M5_KREDITF + _MR_M6_KREDITF;

			this.txt_TotSaldo.Text = tool.MoneyFormat(Convert.ToString(TotSaldo));
			this.txt_TotDebet.Text = tool.MoneyFormat(Convert.ToString(TotDebet));
			this.txt_TotDebetF.Text = Convert.ToString(TotDebetF);
			this.txt_TotKredit.Text = tool.MoneyFormat(Convert.ToString(TotKredit));
			this.txt_TotKreditF.Text = Convert.ToString(TotKreditF);

			
			RataSaldo = TotSaldo / (BagiSaldo == 0 ? 1 : BagiSaldo);
			this.txt_RataSaldo.Text = tool.MoneyFormat(Convert.ToString(RataSaldo));
			this.txt_RataDebet.Text = tool.MoneyFormat(Convert.ToString(TotDebet / (BagiDebet == 0 ? 1 : BagiDebet)));
			this.txt_RataDebetF.Text = tool.MoneyFormat(Convert.ToString(TotDebetF /(BagiDebetF == 0 ? 1 : BagiDebetF)));
			this.txt_RataKredit.Text = tool.MoneyFormat(Convert.ToString(TotKredit /(BagiKredit == 0 ? 1 : BagiKredit)));
			this.txt_RataKreditF.Text = tool.MoneyFormat(Convert.ToString(TotKreditF /(BagiKreditF == 0 ? 1 : BagiKreditF)));

			/*
			if (RataSaldo == 0)
				this.txt_MR_PRSNSALDO.Text = "0";
			else
				this.txt_MR_PRSNSALDO.Text = tool.MoneyFormat(Convert.ToString(_MR_LIMITKREDIT / RataSaldo));
			*/
			if (_MR_LIMITKREDIT == 0)
				this.txt_MR_PRSNSALDO.Text = "0";
			else
				this.txt_MR_PRSNSALDO.Text = tool.MoneyFormat(Convert.ToString((RataSaldo / _MR_LIMITKREDIT) * 100 ));
		}

		private void HitungSaldoOB()
		{
			double TotSaldo, TotDebet, TotDebetF, TotKredit, TotKreditF,
				_MO_M1_SLDRATA, _MO_M2_SLDRATA, _MO_M3_SLDRATA, _MO_M4_SLDRATA, _MO_M5_SLDRATA, _MO_M6_SLDRATA,
				_MO_M1_DEBET, _MO_M2_DEBET, _MO_M3_DEBET, _MO_M4_DEBET, _MO_M5_DEBET, _MO_M6_DEBET,
				_MO_M1_DEBETF, _MO_M2_DEBETF, _MO_M3_DEBETF, _MO_M4_DEBETF, _MO_M5_DEBETF, _MO_M6_DEBETF,
				_MO_M1_KREDIT, _MO_M2_KREDIT, _MO_M3_KREDIT, _MO_M4_KREDIT, _MO_M5_KREDIT, _MO_M6_KREDIT,
				_MO_M1_KREDITF, _MO_M2_KREDITF, _MO_M3_KREDITF, _MO_M4_KREDITF, _MO_M5_KREDITF, _MO_M6_KREDITF, 
				BagiSaldo, BagiDebet, BagiDebetF, BagiKredit, BagiKreditF, RataSaldo, _MO_LIMITKREDIT;

			BagiSaldo = 0;
			BagiDebet = 0;
			BagiDebetF = 0;
			BagiKredit = 0;
			BagiKreditF = 0;

			//-----------------------------------------------------------------saldo rata-rata
			try {_MO_M1_SLDRATA = Double.Parse(this.txt_MO_M1_SLDRATA.Text);} 
			catch {_MO_M1_SLDRATA = 0;}
			if (_MO_M1_SLDRATA != 0) BagiSaldo++;

			try {_MO_M2_SLDRATA = Double.Parse(this.txt_MO_M2_SLDRATA.Text);} 
			catch {_MO_M2_SLDRATA = 0;}
			if (_MO_M2_SLDRATA != 0) BagiSaldo++;

			try {_MO_M3_SLDRATA = Double.Parse(this.txt_MO_M3_SLDRATA.Text);} 
			catch {_MO_M3_SLDRATA = 0;}
			if (_MO_M3_SLDRATA != 0) BagiSaldo++;

			try {_MO_M4_SLDRATA = Double.Parse(this.txt_MO_M4_SLDRATA.Text);} 
			catch {_MO_M4_SLDRATA = 0;}
			if (_MO_M4_SLDRATA != 0) BagiSaldo++;

			try {_MO_M5_SLDRATA = Double.Parse(this.txt_MO_M5_SLDRATA.Text);} 
			catch {_MO_M5_SLDRATA = 0;}
			if (_MO_M5_SLDRATA != 0) BagiSaldo++;

			try {_MO_M6_SLDRATA = Double.Parse(this.txt_MO_M6_SLDRATA.Text);} 
			catch {_MO_M6_SLDRATA = 0;}
			if (_MO_M6_SLDRATA != 0) BagiSaldo++;

			//-----------------------------------------------------------------debet
			try {_MO_M1_DEBET = Double.Parse(this.txt_MO_M1_DEBET.Text);} 
			catch {_MO_M1_DEBET = 0;}
			if (_MO_M1_DEBET != 0) BagiDebet++;

			try {_MO_M2_DEBET = Double.Parse(this.txt_MO_M2_DEBET.Text);} 
			catch {_MO_M2_DEBET = 0;}
			if (_MO_M2_DEBET != 0) BagiDebet++;

			try {_MO_M3_DEBET = Double.Parse(this.txt_MO_M3_DEBET.Text);} 
			catch {_MO_M3_DEBET = 0;}
			if (_MO_M3_DEBET != 0) BagiDebet++;

			try {_MO_M4_DEBET = Double.Parse(this.txt_MO_M4_DEBET.Text);} 
			catch {_MO_M4_DEBET = 0;}
			if (_MO_M4_DEBET != 0) BagiDebet++;

			try {_MO_M5_DEBET = Double.Parse(this.txt_MO_M5_DEBET.Text);} 
			catch {_MO_M5_DEBET = 0;}
			if (_MO_M5_DEBET != 0) BagiDebet++;

			try {_MO_M6_DEBET = Double.Parse(this.txt_MO_M6_DEBET.Text);} 
			catch {_MO_M6_DEBET = 0;}
			if (_MO_M6_DEBET != 0) BagiDebet++;

			//-----------------------------------------------------------------frekuensi debet
			try {_MO_M1_DEBETF = Double.Parse(this.txt_MO_M1_DEBETF.Text);} 
			catch {_MO_M1_DEBETF = 0;}
			if (_MO_M1_DEBETF != 0) BagiDebetF++;

			try {_MO_M2_DEBETF = Double.Parse(this.txt_MO_M2_DEBETF.Text);} 
			catch {_MO_M2_DEBETF = 0;}
			if (_MO_M2_DEBETF != 0) BagiDebetF++;

			try {_MO_M3_DEBETF = Double.Parse(this.txt_MO_M3_DEBETF.Text);} 
			catch {_MO_M3_DEBETF = 0;}
			if (_MO_M3_DEBETF != 0) BagiDebetF++;

			try {_MO_M4_DEBETF = Double.Parse(this.txt_MO_M4_DEBETF.Text);} 
			catch {_MO_M4_DEBETF = 0;}
			if (_MO_M4_DEBETF != 0) BagiDebetF++;

			try {_MO_M5_DEBETF = Double.Parse(this.txt_MO_M5_DEBETF.Text);} 
			catch {_MO_M5_DEBETF = 0;}
			if (_MO_M5_DEBETF != 0) BagiDebetF++;

			try {_MO_M6_DEBETF = Double.Parse(this.txt_MO_M6_DEBETF.Text);} 
			catch {_MO_M6_DEBETF = 0;}
			if (_MO_M6_DEBETF != 0) BagiDebetF++;

			//-----------------------------------------------------------------kredit
			try {_MO_M1_KREDIT = Double.Parse(this.txt_MO_M1_KREDIT.Text);} 
			catch {_MO_M1_KREDIT = 0;}
			if (_MO_M1_KREDIT != 0) BagiKredit++;

			try {_MO_M2_KREDIT = Double.Parse(this.txt_MO_M2_KREDIT.Text);} 
			catch {_MO_M2_KREDIT = 0;}
			if (_MO_M2_KREDIT != 0) BagiKredit++;

			try {_MO_M3_KREDIT = Double.Parse(this.txt_MO_M3_KREDIT.Text);} 
			catch {_MO_M3_KREDIT = 0;}
			if (_MO_M3_KREDIT != 0) BagiKredit++;

			try {_MO_M4_KREDIT = Double.Parse(this.txt_MO_M4_KREDIT.Text);} 
			catch {_MO_M4_KREDIT = 0;}
			if (_MO_M4_KREDIT != 0) BagiKredit++;

			try {_MO_M5_KREDIT = Double.Parse(this.txt_MO_M5_KREDIT.Text);} 
			catch {_MO_M5_KREDIT = 0;}
			if (_MO_M5_KREDIT != 0) BagiKredit++;

			try {_MO_M6_KREDIT = Double.Parse(this.txt_MO_M6_KREDIT.Text);} 
			catch {_MO_M6_KREDIT = 0;}
			if (_MO_M6_KREDIT != 0) BagiKredit++;

			//-----------------------------------------------------------------frekuensi kredit
			try {_MO_M1_KREDITF = Double.Parse(this.txt_MO_M1_KREDITF.Text);} 
			catch {_MO_M1_KREDITF = 0;}
			if (_MO_M1_KREDITF != 0) BagiKreditF++;

			try {_MO_M2_KREDITF = Double.Parse(this.txt_MO_M2_KREDITF.Text);} 
			catch {_MO_M2_KREDITF = 0;}
			if (_MO_M2_KREDITF != 0) BagiKreditF++;

			try {_MO_M3_KREDITF = Double.Parse(this.txt_MO_M3_KREDITF.Text);} 
			catch {_MO_M3_KREDITF = 0;}
			if (_MO_M3_KREDITF != 0) BagiKreditF++;

			try {_MO_M4_KREDITF = Double.Parse(this.txt_MO_M4_KREDITF.Text);} 
			catch {_MO_M4_KREDITF = 0;}
			if (_MO_M4_KREDITF != 0) BagiKreditF++;

			try {_MO_M5_KREDITF = Double.Parse(this.txt_MO_M5_KREDITF.Text);} 
			catch {_MO_M5_KREDITF = 0;}
			if (_MO_M5_KREDITF != 0) BagiKreditF++;

			try {_MO_M6_KREDITF = Double.Parse(this.txt_MO_M6_KREDITF.Text);} 
			catch {_MO_M6_KREDITF = 0;}
			if (_MO_M6_KREDITF != 0) BagiKreditF++;

			try {_MO_LIMITKREDIT  = Double.Parse(this.txt_MO_LIMITKREDIT.Text);} 
			catch {_MO_LIMITKREDIT  = 0;}


			//-----------------------------------------------------------------
			TotSaldo = _MO_M1_SLDRATA + _MO_M2_SLDRATA + _MO_M3_SLDRATA + _MO_M4_SLDRATA + _MO_M5_SLDRATA + _MO_M6_SLDRATA;

			TotDebet = _MO_M1_DEBET + _MO_M2_DEBET + _MO_M3_DEBET + _MO_M4_DEBET + _MO_M5_DEBET + _MO_M6_DEBET;

			TotDebetF = _MO_M1_DEBETF + _MO_M2_DEBETF + _MO_M3_DEBETF + _MO_M4_DEBETF + _MO_M5_DEBETF + _MO_M6_DEBETF;

			TotKredit = _MO_M1_KREDIT + _MO_M2_KREDIT + _MO_M3_KREDIT + _MO_M4_KREDIT + _MO_M5_KREDIT + _MO_M6_KREDIT;

			TotKreditF = _MO_M1_KREDITF + _MO_M2_KREDITF + _MO_M3_KREDITF + _MO_M4_KREDITF + _MO_M5_KREDITF + _MO_M6_KREDITF;

			this.txt_TotSaldoOB.Text = tool.MoneyFormat(Convert.ToString(TotSaldo));
			this.txt_TotDebetOB.Text = tool.MoneyFormat(Convert.ToString(TotDebet));
			this.txt_TotDebetFOB.Text = Convert.ToString(TotDebetF);
			this.txt_TotKreditOB.Text = tool.MoneyFormat(Convert.ToString(TotKredit));
			this.txt_TotKreditFOB.Text = Convert.ToString(TotKreditF);


			RataSaldo = TotSaldo / (BagiSaldo == 0 ? 1 : BagiSaldo);
			this.txt_RataSaldoOB.Text = tool.MoneyFormat(Convert.ToString(RataSaldo));
			this.txt_RataDebetOB.Text = tool.MoneyFormat(Convert.ToString(TotDebet / (BagiDebet == 0 ? 1 : BagiDebet)));
			this.txt_RataDebetFOB.Text = tool.MoneyFormat(Convert.ToString(TotDebetF /(BagiDebetF == 0 ? 1 : BagiDebetF)));
			this.txt_RataKreditOB.Text = tool.MoneyFormat(Convert.ToString(TotKredit /(BagiKredit == 0 ? 1 : BagiKredit)));
			this.txt_RataKreditFOB.Text = tool.MoneyFormat(Convert.ToString(TotKreditF /(BagiKreditF == 0 ? 1 : BagiKreditF)));

			/*
			if (RataSaldo == 0)
				this.txt_MO_PRSNSALDO.Text = "0";
			else
				this.txt_MO_PRSNSALDO.Text = tool.MoneyFormat(Convert.ToString(_MO_LIMITKREDIT / RataSaldo));
			*/
			if (_MO_LIMITKREDIT == 0)
				this.txt_MO_PRSNSALDO.Text = "0";
			else
				this.txt_MO_PRSNSALDO.Text = tool.MoneyFormat(Convert.ToString((RataSaldo / _MO_LIMITKREDIT) * 100));
		}

		protected void btn_Hitung_Click(object sender, System.EventArgs e)
		{
			HitungSaldo();
		}

	}
}