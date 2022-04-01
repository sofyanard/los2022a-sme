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

namespace SME.InitialDataEntry
{
	/// <summary>
	/// Summary description for CompanyLegal. Asdf Jklm
	/// </summary>
	public partial class InfoPerusahaan : System.Web.UI.Page
	{
		protected Connection conn;
		protected Tools tool = new Tools();
		protected System.Web.UI.WebControls.Button barcode;
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			conn = (Connection) Session["Connection"];

			if (!Logic.AllowAccess(Session["GroupID"].ToString(), Request.QueryString["mc"], conn))
				Response.Redirect("/SME/Restricted.aspx");

			if (!IsPostBack)
			{
				LBL_CUREF.Text = Request.QueryString["curef"];
				LBL_REGNO.Text = Request.QueryString["regno"];
				LBL_TC.Text = Request.QueryString["tc"];				

				DDL_CS_HOMESTA.Items.Add(new ListItem("- PILIH -", ""));
				DDL_CO_COLLECTABILITY.Items.Add(new ListItem("- PILIH -", ""));
				DDL_CS_DOB_MONTH.Items.Add(new ListItem("- PILIH -", ""));
				DDL_CS_EDUCATION.Items.Add(new ListItem("- PILIH -", ""));
				DDL_CS_EXPERIENCE.Items.Add(new ListItem("- PILIH -", ""));
				DDL_CS_JOBTITLE.Items.Add(new ListItem("- PILIH -", ""));
				//DDL_CL_CERTDATEMONTH.Items.Add(new ListItem("- PILIH -", ""));
				DDL_CO_DUEDATEMONTH.Items.Add(new ListItem("- PILIH -", ""));
				DDL_CI_BMGIROMONTH.Items.Add(new ListItem("- PILIH -", ""));
				DDL_CI_BMSAVINGMONTH.Items.Add(new ListItem("- PILIH -", ""));
				DDL_CI_BMDEBITURMONTH.Items.Add(new ListItem("- PILIH -", ""));
				string nm_bln;

				for (int i=1; i<=12; i++)
				{
					nm_bln = DateAndTime.MonthName(i, false);
					DDL_CS_DOB_MONTH.Items.Add(new ListItem(nm_bln, i.ToString()));
					DDL_CO_DUEDATEMONTH.Items.Add(new ListItem(nm_bln, i.ToString()));
					DDL_CI_BMGIROMONTH.Items.Add(new ListItem(nm_bln, i.ToString()));
					DDL_CI_BMSAVINGMONTH.Items.Add(new ListItem(nm_bln, i.ToString()));
					DDL_CI_BMDEBITURMONTH.Items.Add(new ListItem(nm_bln, i.ToString()));

				}

				//Kepemilikan Rumah (RFHOMESTA)
				conn.QueryString = "select * from RFHOMESTA where ACTIVE = '1'";
				conn.ExecuteQuery();
				for (int i = 0; i < conn.GetRowCount(); i++)
					DDL_CS_HOMESTA.Items.Add(new ListItem( conn.GetFieldValue(i,"CD_SIBS") + " - " + conn.GetFieldValue(i,"HM_DESC") , conn.GetFieldValue(i,"HM_CODE")));

				conn.QueryString = "select expid, expdesc from rfexperience where active='1'";
				conn.ExecuteQuery();
				for (int i = 0; i < conn.GetRowCount(); i++)
					DDL_CS_EXPERIENCE.Items.Add(new ListItem(conn.GetFieldValue(i,1), conn.GetFieldValue(i,0)));

				conn.QueryString = "select educationid, educationdesc from rfeducation where active='1'";
				conn.ExecuteQuery();
				for (int i = 0; i < conn.GetRowCount(); i++)
					DDL_CS_EDUCATION.Items.Add(new ListItem(conn.GetFieldValue(i,1), conn.GetFieldValue(i,0)));

				//--- Job Title
				conn.QueryString = "select JOBTITLEID, JOBTITLEID + ' - ' + JOBTITLEDESC as JOBTITLEDESC from RFJOBTITLE where ACTIVE='1' order by JOBTITLEID";
				conn.ExecuteQuery();
				for (int i = 0; i < conn.GetRowCount(); i++)
					DDL_CS_JOBTITLE.Items.Add(new ListItem(conn.GetFieldValue(i,1), conn.GetFieldValue(i,0)));

				//--- Stock Holder Type
				conn.QueryString = "select custtypeid, custtypedesc from rfcustomertype where active='1'";
				conn.ExecuteQuery();
				for (int i = 0; i < conn.GetRowCount(); i++)
					RDO_RFCUSTOMERTYPE.Items.Add(new ListItem(conn.GetFieldValue(i,1), conn.GetFieldValue(i,0)));
				RDO_RFCUSTOMERTYPE.Items.Add(new ListItem("Lain-lain", "03"));	// Lain-lain

				//--- Product (Facility di Rekening Level)
				GlobalTools.fillRefList(DDL_PRODUCT, "select * from RFPRODUCT where ACTIVE = '1'", true, conn);

				//--- Facility (Facility di Facility Level)
				GlobalTools.fillRefList(DDL_AI_FACILITY, "select distinct SIBS_PRODID, SIBS_PRODID from RFPRODUCT where ACTIVE = '1'", false, conn);

				GlobalTools.fillRefList(DDL_CS_SEX, "select sexid, sexdesc from rfsex where active='1'", false, conn);
				GlobalTools.fillRefList(DDL_CS_MARITAL, "select maritalid, maritaldesc from rfmarital where active='1'", false, conn);

				GlobalTools.fillRefList(DDL_CP_LOANPURPOSE, "select LOANPURPID, LOANPURPID + ' - ' + LOANPURPDESC as LOANPURPDESC from RFLOANPURPOSE where ACTIVE='1' order by LOANPURPID", false, conn);

				// periksa apakah customer punya CIF
				conn.QueryString = "select CU_CIF from CUSTOMER";
				conn.QueryString += " WHERE CU_REF = '" + LBL_CUREF.Text + "'";
				conn.ExecuteQuery();
				string CU_CIF = conn.GetFieldValue("CU_CIF");

				//	 mengambil rekening customer kalau ada
				conn.QueryString = "select * from bookedcust where cu_ref = '" + LBL_CUREF.Text + "'";
				conn.ExecuteQuery();

				if (CU_CIF == "" && conn.GetRowCount() == 0)
				{ 
					// kasus customer tidak punya CIF, berarti tabel Customer Loan Info ditiadakan
					TBL_CUST_LOAN_INFO.Visible = false;

					// DEBITUR sejak di-disable
					TXT_CI_BMDEBITURDAY.Enabled = false;
					TXT_CI_BMDEBITURYEAR.Enabled = false;
					DDL_CI_BMDEBITURMONTH.Enabled = false;
				}
				//Response.Write("<script language='javascript'>alert('CIF=" + hasCIF + "')</script>");

				//TODO : Hardoced ?!
				RDO_RFCUSTOMERTYPE.SelectedValue = "02";


				ViewData();		// Company Info
				ViewOB();		// Other Loan
				FillCSGrid();

				AddAccount();
				ViewGrid();

				fillHolderAccountName();
				viewDataHolderAccount();
			}			

			//--- Kalau baru masuk pertama kali ke screen, maka
			//--- screen menu tidak perlu diperlihatkan
			if (Request.QueryString["info"] != "" && Request.QueryString["info"] != null)
				ViewMenu();

			// jika ada flag presco, maka tampilkan menu
			if ((Request.QueryString["presco"] != "" && Request.QueryString["presco"] != null) || 
				(Request.QueryString["tc"] == "" || Request.QueryString["tc"] == null))
				ViewMenu();

			SecureData();

			BTN_STOCKHOLDER.Attributes.Add("onclick","if(!cek_mandatoryColl(document.Form1)){return false;};");
			BTN_UPDATE_NEW.Attributes.Add("onclick","if(!cek_mandatoryColl(document.Form1)){return false;};");
			BTN_NEW.Attributes.Add("onclick", "if(!cek_mandatory(document.Form1)){return false;};");
			BTN_UPDATE.Attributes.Add("onclick","if(!updateMsgA()){return false;};");
		}

		private void setMandatoryFI(string isKeyPerson, string programid) 
		{
			/////////////////////////////////////////////////////
			///	setMandatoryFI(custType, ap_regno)
			/// Men-set field mandatory untuk Fair Isaac (FI)
			/// 

			//////////////////////////////////////////////
			/// TODO : Please don't hard code !!!!
			/// 			
			if (isKeyPerson == "1") 
			{
				if (programid == "15" || 
					programid == "16" || 
					programid == "19") 
				{
					TXT_CS_CHILDREN.CssClass = "mandatoryColl";
					TXT_CS_MULAIMENETAPMM.CssClass = "mandatoryColl";
					TXT_CS_MULAIMENETAPYY.CssClass = "mandatoryColl";				
				}

				if (programid == "16") 
				{
					DDL_CS_HOMESTA.CssClass = "mandatoryColl";
				}
			}
		}

		private void ViewMenu()
		{
			Menu.Controls.Clear();
			try 
			{
				conn.QueryString = "select * from SCREENMENU where menucode = '"+Request.QueryString["mc"]+"'";
				conn.ExecuteQuery();

				string mc1 = Request.QueryString["mc"];
				string mc2 = Request.QueryString["mc"];
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

						//---  untuk general info
						if (conn.GetFieldValue(i,3).IndexOf("?exist=") < 0 && conn.GetFieldValue(i,3).IndexOf("&exist=") < 0) 
							strtemp = strtemp + "&exist=" + Request.QueryString["exist"];	

						//--- untuk program yang dipilih
						if (conn.GetFieldValue(i,3).IndexOf("?prog=") < 0 && conn.GetFieldValue(i,3).IndexOf("&prog=") < 0) 
							strtemp = strtemp + "&prog=" + Request.QueryString["prog"];	

						//t.ForeColor = Color.MidnightBlue; 
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
		
		private void ViewData()
		{
			conn.QueryString = "select * from COMPANY_INFO "+
				" where CU_REF = '"+ LBL_CUREF.Text +"' " ;
			conn.ExecuteQuery();

			string CI_BMGIRO			= conn.GetFieldValue("CI_BMGIRO");
			TXT_CI_BMGIRODAY.Text		= tool.FormatDate_Day(CI_BMGIRO);
			DDL_CI_BMGIROMONTH.SelectedValue = tool.FormatDate_Month(CI_BMGIRO);
			TXT_CI_BMGIROYEAR.Text		= tool.FormatDate_Year(CI_BMGIRO);
			string CI_BMSAVING			= conn.GetFieldValue("CI_BMSAVING");
			TXT_CI_BMSAVINGDAY.Text		= tool.FormatDate_Day(CI_BMSAVING);
			DDL_CI_BMSAVINGMONTH.SelectedValue = tool.FormatDate_Month(CI_BMSAVING);
			TXT_CI_BMSAVINGYEAR.Text	= tool.FormatDate_Year(CI_BMSAVING);
			string CI_BMDEBITUR			= conn.GetFieldValue("CI_BMDEBITUR");
			TXT_CI_BMDEBITURDAY.Text	= tool.FormatDate_Day(CI_BMDEBITUR);
			DDL_CI_BMDEBITURMONTH.SelectedValue = tool.FormatDate_Month(CI_BMDEBITUR);
			TXT_CI_BMDEBITURYEAR.Text	= tool.FormatDate_Year(CI_BMDEBITUR);
            TXT_CI_BMSAVINGACCNO.Text = conn.GetFieldValue("CI_BMSAVINGACCNO");
		}

		private void viewDataHolderAccount() 
		{
			conn.QueryString = "select * from VW_IDE_HOLDERACCOUNTLIST where CU_REF = '" + LBL_CUREF.Text + "'";
			conn.ExecuteQuery();
			
			DatGrdAccStockHolder.DataSource = conn.GetDataTable().DefaultView;
			DatGrdAccStockHolder.DataBind();

			for(int i=0 ; i<DatGrdAccStockHolder.Items.Count; i++) 
			{
				if (Request.QueryString["sta"] == "view") 
				{
					LinkButton LNK_EDIT = (LinkButton) DatGrdAccStockHolder.Items[i].FindControl("LNK_EDIT_HOLDERACC");
					LinkButton LNK_DELETE = (LinkButton) DatGrdAccStockHolder.Items[i].FindControl("LNK_DEL_HOLDERACC");

					LNK_EDIT.Visible = false;
					LNK_DELETE.Visible = false;
				}
			}
		}

		private void ViewOB()
		{
			conn.QueryString = "select * from VW_CUSTOTHERLOAN "+
				" where CU_REF = '"+ Request.QueryString["curef"] +"' " ;
			conn.ExecuteQuery();
			DataTable data = new DataTable();
			data = conn.GetDataTable().Copy();
			DGR_OB.DataSource = data;
			DGR_OB.DataBind();
			
			for (int i = 0; i < DGR_OB.Items.Count; i++)
				DGR_OB.Items[i].Cells[8].Text = tool.FormatDate(DGR_OB.Items[i].Cells[8].Text, false);
		}

		private void BTN_OBINSERT_Click(object sender, System.EventArgs e)
		{
			conn.QueryString = "exec DE_CUSTOTHERLOAN '0', '"+ LBL_CUREF.Text +"', 0,  '"+ TXT_CO_CREDTYPE.Text +"', '"+
				TXT_CO_BANKNAME.Text +"', "+ tool.ConvertNum(TXT_CO_LIMIT.Text) +", "+ tool.ConvertNum(TXT_CO_BAKIDEBET.Text) +", "+
				tool.ConvertNum(TXT_CO_TGKPOKOK.Text) +", "+ tool.ConvertNum(TXT_CO_TGKBUNGA.Text) +", "+
				tool.ConvertDate(TXT_CO_DUEDATEDAY.Text, DDL_CO_DUEDATEMONTH.SelectedValue, TXT_CO_DUEDATEYEAR.Text) +", "+
				tool.ConvertNull(DDL_CO_COLLECTABILITY.SelectedValue); 			
			conn.ExecuteQuery();
			ViewOB();
			OB_Clear();
		}

		private void DGR_OB_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			// *** DELETE HUBUNGAN DENGAN BANK LAIN ***
			switch (((LinkButton)e.CommandSource).CommandName)
			{
				case "delete":
					conn.QueryString = "exec DE_CUSTOTHERLOAN '1', '"+ LBL_CUREF.Text +"', "+ e.Item.Cells[1].Text +
						", '', '', 0, 0, 0, 0, '', '' ";
					conn.ExecuteQuery();
					break;
			}
			ViewOB();
		}

		private void OB_Clear()
		{
			TXT_CO_CREDTYPE.Text = "";
			TXT_CO_BANKNAME.Text = "";
			TXT_CO_LIMIT.Text = "";
			TXT_CO_BAKIDEBET.Text = "";
			TXT_CO_TGKPOKOK.Text = "";
			TXT_CO_TGKBUNGA.Text = "";
			TXT_CO_DUEDATEDAY.Text = "";
			DDL_CO_DUEDATEMONTH.SelectedValue  = "";
			TXT_CO_DUEDATEYEAR.Text = "";
			DDL_CO_COLLECTABILITY.SelectedValue = "";
		}

		private void fillHolderAccountName() 
		{
			string query = "select SEQ, CS_FIRSTNAME + ' ' + CS_MIDDLENAME + ' ' + CS_LASTNAME AS HOLDER_NAME " + 
				"from CUST_STOCKHOLDER where CU_REF = '" + LBL_CUREF.Text + "'";
			GlobalTools.fillRefList(DDL_HOLDER_NAME, query, false, conn);
		}

		private void clearHolderAccount() 
		{
			DDL_HOLDER_NAME.SelectedValue = "";
			LBL_IDCARDNUM.Text = "";
			LBL_NPWP.Text = "";
			TXT_HOLD_ACC_NO.Text = "";
			TXT_HOLD_REMARK.Text = "";
			DDL_PRODUCT.SelectedValue = "";

			BTN_UPDATE_HOLDERACC.Visible = false;
			BTN_SAVE_HOLDERACC.Visible = true;
		}

		private void setCustomerTypeMandatory(string customerType) 
		{
			//--- Kalau jenis pemegang saham BADAN USAHA, disable field berikut :
			//    - Key Person
			//    - WNA/WNI
			//    - Job Title
			//    - Pendidikan Akhir
			//    - Pengalaman		
			//	  - Kepemilikan rumah
			//    - Jenis Kelamin
			//    - Status Pernikahan
			//----------------------------------------------------------------

			RDO_RFCUSTOMERTYPE.SelectedValue = customerType;
			
			if (customerType == "01")	//--- company / badan usaha			
			{
				//RDO_KEY_PERSON.Enabled = true;	// company tidak bisa key person !?
				RDO_KEY_PERSON.Enabled = false;	

				RDO_CS_NATSTAT0.Enabled	= false;
				RDO_CS_NATSTAT1.Enabled	= false;
				try {DDL_CS_JOBTITLE.Enabled	= false;}
				catch {}

				try {DDL_CS_EDUCATION.Enabled = false;}
				catch {}

				try {DDL_CS_EXPERIENCE.Enabled = false;}
				catch {}

				try {DDL_CS_SEX.Enabled = false;}
				catch {}

				try {DDL_CS_MARITAL.Enabled = false;}
				catch {}

				TXT_CS_CHILDREN.ReadOnly = true;
				TXT_CS_MULAIMENETAPMM.ReadOnly = true;
				TXT_CS_MULAIMENETAPYY.ReadOnly = true;
				
				try {DDL_CS_HOMESTA.Enabled = false;}
				catch {}

				try{ RDO_KEY_PERSON.SelectedValue = "0";} //by default TIDAK
				catch {}

				try {DDL_CS_JOBTITLE.SelectedIndex = 0;}
				catch {}

				try {DDL_CS_EDUCATION.SelectedIndex = 0;}
				catch {}

				try {DDL_CS_EXPERIENCE.SelectedIndex = 0;}
				catch {}

				try {DDL_CS_SEX.SelectedIndex = 0;}
				catch {}

				try {DDL_CS_MARITAL.SelectedIndex = 0;}
				catch {}

				TXT_CS_CHILDREN.Text = "";
				TXT_CS_MULAIMENETAPMM.Text = "";
				TXT_CS_MULAIMENETAPYY.Text = "";
				try {DDL_CS_HOMESTA.SelectedIndex = 0;}
				catch {}

				// Reset CssClass
				TXT_CS_CHILDREN.CssClass = "";
				TXT_CS_MULAIMENETAPMM.CssClass = "";
				TXT_CS_MULAIMENETAPYY.CssClass = "";
				DDL_CS_HOMESTA.CssClass = "";

//				DDL_CS_JOBTITLE.BackColor		= Color.Gainsboro;
//				DDL_CS_EXPERIENCE.BackColor		= Color.Gainsboro;				

				/**
				TXT_CS_CHILDREN.BackColor		= Color.Gainsboro;
				DDL_CS_SEX.BackColor			= Color.Gainsboro;
				TXT_CS_MULAIMENETAPMM.BackColor = Color.Gainsboro;
				TXT_CS_MULAIMENETAPYY.BackColor = Color.Gainsboro;				
				**/

				//TXT_CS_CHILDREN.CssClass		= "";
				//DDL_CS_SEX.CssClass				= "";
				//TXT_CS_MULAIMENETAPMM.CssClass	= "";
				//TXT_CS_MULAIMENETAPYY.CssClass	= "";
				//TXT_CS_DOB_DAY.CssClass			= "";
				//DDL_CS_DOB_MONTH.CssClass		= "";
				//TXT_CS_DOB_YEAR.CssClass		= "";
			}
			else //--- perorangan / lain-lain
			{
				if (customerType == "02") {
					RDO_KEY_PERSON.Enabled = true;	// hanya perorangan yang bisa jadi key person
				}
				else {	// lain-lain

					RDO_KEY_PERSON.Enabled = false;
					try { RDO_KEY_PERSON.SelectedValue = "0"; } 
					catch {}

					// Reset CssClass
					TXT_CS_CHILDREN.CssClass = "";
					TXT_CS_MULAIMENETAPMM.CssClass = "";
					TXT_CS_MULAIMENETAPYY.CssClass = "";
					DDL_CS_HOMESTA.CssClass = "";					
				}


				RDO_CS_NATSTAT0.Enabled			= true;
				RDO_CS_NATSTAT1.Enabled			= true;

				try {DDL_CS_JOBTITLE.Enabled			= true;}
				catch {}

				try {DDL_CS_EDUCATION.Enabled		= true;}
				catch {}

				try {DDL_CS_EXPERIENCE.Enabled		= true;}
				catch {}

				try {DDL_CS_SEX.Enabled				= true;}
				catch {}

				try {DDL_CS_MARITAL.Enabled			= true;}
				catch {}

				TXT_CS_CHILDREN.ReadOnly		= false;
				TXT_CS_MULAIMENETAPMM.ReadOnly	= false;
				TXT_CS_MULAIMENETAPYY.ReadOnly	= false;
				try {DDL_CS_HOMESTA.Enabled			= true;}
				catch {}

//				DDL_CS_JOBTITLE.BackColor		= Color.White;				
//				DDL_CS_EXPERIENCE.BackColor		= Color.White;

				TXT_CS_CHILDREN.Text			= "";
				TXT_CS_MULAIMENETAPMM.Text		= "";
				TXT_CS_MULAIMENETAPYY.Text		= "";
				try {DDL_CS_HOMESTA.SelectedValue	= "";}
				catch {}

				try {DDL_CS_JOBTITLE.SelectedValue	= "";}
				catch {}

				try {DDL_CS_EDUCATION.SelectedValue	= "";}
				catch {}

				try {DDL_CS_EXPERIENCE.SelectedValue	= "";}
				catch {}

				try {DDL_CS_SEX.SelectedValue		= "";}
				catch {}
				
				try {DDL_CS_MARITAL.SelectedValue	= "";}
				catch {}


				//TXT_CS_CHILDREN.CssClass		= "mandatoryColl";
				//DDL_CS_SEX.CssClass				= "mandatoryColl";
				//TXT_CS_MULAIMENETAPMM.CssClass	= "mandatoryColl";
				//TXT_CS_MULAIMENETAPYY.CssClass	= "mandatoryColl";
				//TXT_CS_DOB_DAY.CssClass			= "mandatoryColl";
				//DDL_CS_DOB_MONTH.CssClass		= "mandatoryColl";
				//TXT_CS_DOB_YEAR.CssClass		= "mandatoryColl";
			}
		}

		private void SecureData() 
		{
			string sta = Request.QueryString["sta"];
			if (sta == "view")
			{
				System.Web.UI.ControlCollection coll = this.Page.Controls;
				int k = 0;
				for(k = 0; k < coll.Count; k++) 
				{
					if (coll[k] is System.Web.UI.HtmlControls.HtmlForm) 
					{
						break;
					}
				}

				for (int i = 0; i < coll[k].Controls.Count; i++) 
				{
					if (coll[k].Controls[i] is TextBox) 
					{
						TextBox txt = (TextBox) coll[k].Controls[i];
						txt.ReadOnly = true;
						//txt.Enabled = false;
					}
					else if (coll[k].Controls[i] is DropDownList) 
					{
						DropDownList ddl = (DropDownList) coll[k].Controls[i];
						ddl.Enabled = false;
					}
					else if (coll[k].Controls[i] is Button)
					{
						Button btn = (Button) coll[k].Controls[i];
						//btn.Enabled = false;
						btn.Visible = false;
					}
					else if (coll[k].Controls[i] is RadioButtonList) 
					{
						RadioButtonList rbl = (RadioButtonList) coll[k].Controls[i];
						rbl.Enabled = false;
					}
					else if (coll[k].Controls[i] is RadioButton) 
					{
						RadioButton rb = (RadioButton) coll[k].Controls[i];
						rb.Enabled = false;
					}
					else if (coll[k].Controls[i] is CheckBox)
					{
						CheckBox cb = (CheckBox) coll[k].Controls[i];
						cb.Enabled = false;
					}					
					else if (coll[k].Controls[i] is DataGrid) 
					{						
						DataGrid dg = (DataGrid) coll[k].Controls[i];						
						dg.Columns[10].Visible = false;
						for (int j = 0; j < dg.Items.Count; j++) 
						{
							//dg.Items[j].Cells[10].Enabled = false;
							dg.Items[j].Cells[10].Visible = false;
						}
					}
					else if (coll[k].Controls[i] is HtmlTableRow) 
					{
						HtmlTableRow htr = (HtmlTableRow) coll[k].Controls[i];
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

		private bool isInputValid() 
		{
			bool isValid = true;

			////////////////////////////////////////////
			/// Validasi Mulai Menetap
			/// 
			int CS_MULAIMENETAPMM = 0, CS_MULAIMENETAPYY = 0;
			if (TXT_CS_MULAIMENETAPMM.Text.Trim() != "" || TXT_CS_MULAIMENETAPYY.Text.Trim() != "") 
			{
				try { CS_MULAIMENETAPMM = Convert.ToInt16(TXT_CS_MULAIMENETAPMM.Text.Trim()); } 
				catch {}
				try { CS_MULAIMENETAPYY = Convert.ToInt16(TXT_CS_MULAIMENETAPYY.Text.Trim()); }
				catch {}

				if ((CS_MULAIMENETAPMM < 1 && CS_MULAIMENETAPMM > 12) || 
					(!GlobalTools.isDateValid(1, CS_MULAIMENETAPMM, CS_MULAIMENETAPYY))) 
				{
					GlobalTools.popMessage(this, "Mulai Menetap tidak valid!");
					isValid = false;
				}
			}
			///////////////////////////////////////////////////

			//--- validasi Tanggal Lahir (DOB)
			Int64 dobDate = 0, now = 0;
			if ((TXT_CS_DOB_DAY.Text != "") && (DDL_CS_DOB_MONTH.SelectedValue != "") && (TXT_CS_DOB_YEAR.Text != ""))
			{
				if (!GlobalTools.isDateValid(TXT_CS_DOB_DAY.Text, DDL_CS_DOB_MONTH.SelectedValue, TXT_CS_DOB_YEAR.Text)) 
				{
					GlobalTools.popMessage(this, "Tanggal Lahir tidak valid !");
					isValid = false;
				}

				try 
				{
					dobDate = Int64.Parse(Tools.toISODate(TXT_CS_DOB_DAY, DDL_CS_DOB_MONTH, TXT_CS_DOB_YEAR));
				} 
				catch (ApplicationException) 
				{
					GlobalTools.popMessage(this, "Tanggal Lahir tidak valid !");
					isValid = false;
				}

				now = Int64.Parse(Tools.toISODate(DateTime.Now.Day.ToString(), DateTime.Now.Month.ToString(), DateTime.Now.Year.ToString()));
				
				if (dobDate > now)
				{
					GlobalTools.popMessage(this, "DOB cannot be greater than current date!");
					isValid = false;
				}
			}
			
			//if (double.Parse(tool.ConvertFloat(TXT_CS_STOCKPERC.Text)) > double.Parse(LBL_TOTPERC.Text))
			//if (float.Parse(TXT_CS_STOCKPERC.Text) > double.Parse(LBL_TOTPERC.Text))
			//if (double.Parse(tool.ConvertFloat(TXT_CS_STOCKPERC.Text)) > double.Parse(tool.ConvertFloat(LBL_TOTPERC.Text)))

			//--- validasi Percentage
			try 
			{
				/********
				 * Logic rebuild ... !
				 * ******
				if (float.Parse(TXT_CS_STOCKPERC.Text) > float.Parse(LBL_TOTPERC.Text))
				{
					TXT_CS_STOCKPERC.Text = "";
					GlobalTools.popMessage(this, "Stock Percentage Over 100% !");
					isValid = false;
				}
				***/

				conn.QueryString = "exec IDE_INFOPERUSAHAAN_CEKSAHAM '" + 
					Request.QueryString["curef"] + "', '" + SEQ.Text + "', '" + 
					tool.ConvertFloat(TXT_CS_STOCKPERC.Text.Trim()) + "'";
				conn.ExecuteQuery();
				double vTOTAL_CS_STOCKPERC = 0.0;
				try { vTOTAL_CS_STOCKPERC = Convert.ToDouble(conn.GetFieldValue("TOTAL_CS_STOCKPERC")); } 
				catch {}
				if (vTOTAL_CS_STOCKPERC > 100.0) 
				{
					GlobalTools.popMessage(this, "Stock Percentage Over 100% !");
					isValid = false;
				}

				if (RDO_RFCUSTOMERTYPE.SelectedValue == "01") //--- badan usaha
				{
					//... stock 0.00 tidak boleh
					if (float.Parse(TXT_CS_STOCKPERC.Text) <= 0.00) 
					{
						TXT_CS_STOCKPERC.Text = "";
						GlobalTools.popMessage(this, "Stock tidak boleh 0.00!");
						isValid = false;
					}
				}
			} 
			catch 
			{
				GlobalTools.popMessage(this, "Nilai Stock tidak valid !");
				isValid = false;
			}

			//--- VALIDASI KEY PERSON ---//

			//    KEY Person harus ORANG (kode : 02)
			if (RDO_KEY_PERSON.SelectedValue == "1" && RDO_RFCUSTOMERTYPE.SelectedValue != "02") //
			{
				GlobalTools.popMessage(this, "Key Person harus Perorangan!");
				isValid = false;
			}

			/***
			 * 
			 * "Berdasarkan kebijaksanaan User", key person bisa lebih dari 1 orang
			 * misal : Dirut dan Dir Keu
			 * TAPI, kata Mr. Cheng, sebaliknya. Yang benar ???
			 * 
			 * */
			// Jumlah Key Person harus 1 orang saja
			try 
			{
				conn.QueryString = "select * from CUST_STOCKHOLDER where CU_REF = '" + LBL_CUREF.Text + 
					"' and CS_KEYPERSON = '1'";
				conn.ExecuteQuery();

				if (conn.GetRowCount() == 1 && RDO_KEY_PERSON.SelectedValue == "1") 
				{
					if(!conn.GetFieldValue("seq").Equals(SEQ.Text))
					{
						GlobalTools.popMessage(this, "Jumlah Key Person hanya boleh 1 orang!");
						isValid = false;
					}
				}


//				conn.QueryString = "select CS_KEYPERSON from CUST_STOCKHOLDER where CU_REF = '" + LBL_CUREF.Text + 
//					"' and CS_KEYPERSON = '1'";
//				conn.ExecuteQuery();
//
//				DataTable dt1=new DataTable();
//				dt1 = conn.GetDataTable().Copy();
//				
//
//				if (dt1.Rows.Count == 1 && RDO_KEY_PERSON.SelectedValue == "1") 
//				{
//					conn.QueryString = "select CS_KEYPERSON from CUST_STOCKHOLDER where CU_REF = '" + LBL_CUREF.Text + "' and CS_KEYPERSON = '1'";
//					conn.ExecuteQuery();
//					if (dt1.Rows.Count == 1 && RDO_KEY_PERSON.SelectedValue == "1") 
//					{
//						GlobalTools.popMessage(this, "Jumlah Key Person hanya boleh 1 orang!");
//						isValid = false;
//					}
//				}

			}
			catch 
			{
				GlobalTools.popMessage(this, "Connection Error!");
				isValid = false;
			}
			//---------------------------------------------------------------------//

			return isValid;
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
			this.DatGrd.ItemCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.DatGrd_ItemCommand);
			this.DatGrdAccStockHolder.ItemCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.DatGrdAccStockHolder_ItemCommand);
			this.DatGridPengurus.ItemCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.DatGridPengurus_ItemCommand);

		}
		#endregion

		private void saveHubunganDenganBM() 
		{	
			//--- validasi tanggal Hubungan Dengan BM
			// TANGGAL GIRO
			if (TXT_CI_BMGIRODAY.Text != "" || DDL_CI_BMGIROMONTH.SelectedValue != "" || TXT_CI_BMGIROYEAR.Text != "") 
			{
				if (!Tools.isDateValid(this, TXT_CI_BMGIRODAY.Text, DDL_CI_BMGIROMONTH.SelectedValue, TXT_CI_BMGIROYEAR.Text))
				{
					GlobalTools.popMessage(this, "Tanggal Giro Sejak tidak valid !");
					return;
				}

				int banding = 0;
				try { banding = Tools.compareDate(DateTime.Now.Day.ToString(), DateTime.Now.Month.ToString(), DateTime.Now.Year.ToString(), TXT_CI_BMGIRODAY.Text, DDL_CI_BMGIROMONTH.SelectedValue, TXT_CI_BMGIROYEAR.Text); } 
				catch {}
				if (banding < 0) 
				{
					GlobalTools.popMessage(this, "Tanggal Giro tidak boleh lebih dari tanggal sekarang!");
					return;
				}
			}

			//TANGGAL TABUNGAN
			if (TXT_CI_BMSAVINGDAY.Text != "" || DDL_CI_BMSAVINGMONTH.SelectedValue != "" || TXT_CI_BMSAVINGYEAR.Text != "") 
			{
				if (!Tools.isDateValid(this, TXT_CI_BMSAVINGDAY.Text, DDL_CI_BMSAVINGMONTH.SelectedValue, TXT_CI_BMSAVINGYEAR.Text))
				{
					GlobalTools.popMessage(this, "Tanggal Tabungan Sejak tidak valid !");
					return;
				}
				int banding = 0;
				try { banding = Tools.compareDate(DateTime.Now.Day.ToString(), DateTime.Now.Month.ToString(), DateTime.Now.Year.ToString(), TXT_CI_BMSAVINGDAY.Text, DDL_CI_BMSAVINGMONTH.SelectedValue, TXT_CI_BMSAVINGYEAR.Text); } 
				catch {}
				if (banding < 0) 
				{
					GlobalTools.popMessage(this, "Tanggal Tabungan tidak boleh lebih dari tanggal sekarang!");
					return;
				}
			}

			//TANGGAL DEBITUR
			if (TXT_CI_BMDEBITURDAY.Text != "" || DDL_CI_BMDEBITURMONTH.SelectedValue != "" || TXT_CI_BMDEBITURYEAR.Text != "") 
			{
				if (!Tools.isDateValid(this, TXT_CI_BMDEBITURDAY.Text, DDL_CI_BMDEBITURMONTH.SelectedValue, TXT_CI_BMDEBITURYEAR.Text))
				{
					GlobalTools.popMessage(this, "Tanggal Debitur Sejak tidak valid !");
					return;
				}
				int banding = 0;
				try { banding = Tools.compareDate(DateTime.Now.Day.ToString(), DateTime.Now.Month.ToString(), DateTime.Now.Year.ToString(), TXT_CI_BMDEBITURDAY.Text, DDL_CI_BMDEBITURMONTH.SelectedValue, TXT_CI_BMDEBITURYEAR.Text); } 
				catch {}
				if (banding < 0) 
				{
					GlobalTools.popMessage(this, "Tanggal Debitur tidak boleh lebih dari tanggal sekarang!");
					return;
				}
			}


			conn.QueryString = "exec IDE_INFOPERUSAHAAN '"+
				LBL_CUREF.Text +"', " + 
				tool.ConvertDate(TXT_CI_BMGIRODAY.Text, DDL_CI_BMGIROMONTH.SelectedValue, TXT_CI_BMGIROYEAR.Text) +", "+
				tool.ConvertDate(TXT_CI_BMSAVINGDAY.Text, DDL_CI_BMSAVINGMONTH.SelectedValue, TXT_CI_BMSAVINGYEAR.Text) +", "+
				tool.ConvertDate(TXT_CI_BMDEBITURDAY.Text, DDL_CI_BMDEBITURMONTH.SelectedValue, TXT_CI_BMDEBITURYEAR.Text) + ", '" +
                TXT_CI_BMSAVINGACCNO.Text + "'";
			conn.ExecuteNonQuery();
		}

		protected void BTN_SAVE_Click(object sender, System.EventArgs e)
		{
			saveHubunganDenganBM();
		}

		protected void BTN_UPDATE_Click(object sender, System.EventArgs e)
		{
			// periksa apakah customer punya CIF
			conn.QueryString = "select CU_CIF from CUSTOMER";
			conn.QueryString += " WHERE CU_REF = '" + LBL_CUREF.Text + "'";
			conn.ExecuteQuery();
			string CU_CIF = conn.GetFieldValue("CU_CIF");

			//	 mengambil rekening customer kalau ada
			conn.QueryString = "select * from bookedcust where cu_ref = '" + LBL_CUREF.Text + "'";
			conn.ExecuteQuery();

			if (CU_CIF != "" && conn.GetRowCount() > 0)
			{ 
				// jika punya CIF atau punya facilities, maka tanggal Debitur Sejak harus dipastikan terisi
                bool valid = GlobalTools.isDateValid(TXT_CI_BMDEBITURDAY.Text,DDL_CI_BMDEBITURMONTH.SelectedValue,TXT_CI_BMDEBITURYEAR.Text);
				GlobalTools.popMessage(this,valid.ToString());
				if (!valid)
				{
					GlobalTools.popMessage(this, "Tanggal \"Debitur Sejak\" harus diisi lengkap");
					return;
				}
			}

			saveHubunganDenganBM();

			conn.QueryString = "select cu_custtypeid from customer where cu_ref='" + Request.QueryString["curef"] + "'";
			conn.ExecuteQuery();
			string cu_custtypeid = conn.GetFieldValue("cu_custtypeid");

			//if (DatGridPengurus.Items.Count > 0)
			if (cu_custtypeid == "01") // Badan Usaha
			{
				// Belum ada pengurus diisi ....
				if (DatGridPengurus.Items.Count == 0) 
				{
					GlobalTools.popMessage(this, "Data Direksi harus diisi!");
					RDO_KEY_PERSON.SelectedValue = "1";	// set default ke YES
					return;
				}

				float totSahamPercentage = 0;
				bool isAdaKeyPerson = false;

				// Memeriksa jumlah persentase saham ...
				for (int i = 0; i < DatGridPengurus.Items.Count; i++)
				{
					//totSahamPercentage += float.Parse(DatGridPengurus.Items[i].Cells[7].Text);
					//--- Modified By Yudi (12-Ags-2004) ---
					if (DatGridPengurus.Items[i].Cells[14].Text != "1")
					{
						totSahamPercentage += float.Parse(float.Parse(DatGridPengurus.Items[i].Cells[7].Text).ToString("##,#0.00"));
					}

					string KEYPERSON = DatGridPengurus.Items[i].Cells[11].Text;
					if (KEYPERSON == "YA") 					
						isAdaKeyPerson = true;					
				}
				
				if (totSahamPercentage  < 99.999 || totSahamPercentage > 100.001)
					GlobalTools.popMessage(this, "Total saham harus 100%!");
				else if (!isAdaKeyPerson) // Badan usaha
				{
					GlobalTools.popMessage(this, "Perusahaan harus punya Key Person, min 1 Orang !");
				}
				else if ((Request.QueryString["presco"] == "") || (Request.QueryString["presco"] == null))
				{ 
					// jika tidak ada flag prescoring maka boleh redirect ke halaman lain
					Response.Redirect("../BlackList/BL_result.aspx?regno=" + 
							Request.QueryString["regno"] + "&curef=" + 
							Request.QueryString["curef"] + "&prog=" + 
							Request.QueryString["prog"] + "&tc=" + 
							Request.QueryString["tc"] + "&mc=" + 
							Request.QueryString["mc"] + "&exist=" + 
							Request.QueryString["exist"]);
				}			
			}
			else	// Perorangan
			{
//				if (cu_custtypeid == "01") // Badan Usaha
//				{
//					GlobalTools.popMessage(this, "Data Direksi harus diisi!");
//					RDO_KEY_PERSON.SelectedValue = "1";	// set default ke YES
//				}
//				else
				Response.Redirect("../BlackList/BL_result.aspx?regno=" + 
					Request.QueryString["regno"] + "&curef=" + 
					Request.QueryString["curef"] + "&prog=" + 
					Request.QueryString["prog"] + "&tc=" + 
					Request.QueryString["tc"] + "&mc=" + 
					Request.QueryString["mc"] + "&exist=" + 
					Request.QueryString["exist"]);	
			}
		}

		private void FillCSGrid()
		{
			float totSaham = 0, temp = 0;
			
			DataTable dt = new DataTable();
			conn.QueryString = "select *, case isnull(CS_NATSTAT,'0') when '0' then 'WNI' when '1' then 'WNA' end as STATUS_DESC, case isnull(CS_KEYPERSON,'0') when '0' then 'TIDAK' when '1' then 'YA' end as CS_KEYPERSON from VW_CUST_STOCKHOLDER where CU_REF ='"+ Request.QueryString["curef"] + "'";
			conn.ExecuteQuery();
			dt = conn.GetDataTable().Copy();
			DatGridPengurus.DataSource = dt;
			DatGridPengurus.DataBind();

			for (int i = 0; i < DatGridPengurus.Items.Count; i++)
			{
				DatGridPengurus.Items[i].Cells[3].Text = tool.FormatDate(DatGridPengurus.Items[i].Cells[3].Text, true);
				DatGridPengurus.Items[i].Cells[7].Text = DatGridPengurus.Items[i].Cells[7].Text.Replace(".", ",");
				temp = float.Parse(DatGridPengurus.Items[i].Cells[7].Text);

				if (!DatGridPengurus.Items[i].Cells[1].Text.Trim().Equals(SEQ.Text.Trim()) && SEQ.Text!="")
				{
					totSaham = totSaham + temp;
				}

				///////////////////////////////////////////
				///	untuk secure data 
				///	
				if (Request.QueryString["sta"] == "view") 
				{
					LinkButton LNK_DELETE = (LinkButton) DatGridPengurus.Items[i].FindControl("LNK_DELETE");
					LinkButton LNK_EDIT = (LinkButton) DatGridPengurus.Items[i].FindControl("LNK_EDIT");

					LNK_DELETE.Visible = false;
					//LNK_EDIT.Visible = false;
					LNK_EDIT.Text = "View";
				}
				////////////////////////////////////////////
			}
			totSaham = 100 - totSaham;
			//LBL_TOTPERC.Text = totSaham.ToString();			
			//TXT_CS_STOCKPERC.Text = totSaham.ToString();

			//------- Modified by Yudi (06-08-2004) --------------
			LBL_TOTPERC.Text = totSaham.ToString("##,#0.00");
			TXT_CS_STOCKPERC.Text = totSaham.ToString("##,#0.00");
		}

		protected void BTN_STOCKHOLDER_Click(object sender, System.EventArgs e)
		{
			SEQ.Text="";
			string status = "0", dbg = Request.QueryString["curef"] ;
			int count = 0;
			Int64 dobDate = 0, now = 0;

			if (!isInputValid()) return;
			
			
			count = DatGridPengurus.Items.Count + 1;
			if (RDO_CS_NATSTAT1.Checked)
				status = "1";

			string removed;
			if (CHK_REMOVED.Checked == true)
				removed = "1";
			else
				removed = "0";

			conn.QueryString = "exec DE_CUST_STOCKHOLDER '" + 
				Request.QueryString["curef"] + "', '" + 
				//count.ToString() + ", '" + 
				TXT_CS_FIRSTNAME.Text + "', '" + 
				TXT_CS_MIDDLENAME.Text + "', '" + 
				TXT_CS_LASTNAME.Text + "', " + 
				tool.ConvertDate(TXT_CS_DOB_DAY.Text, DDL_CS_DOB_MONTH.SelectedValue, TXT_CS_DOB_YEAR.Text) + ", '" + 
				TXT_CS_IDCARDNUM.Text + "', '" + 
				TXT_CS_NPWP.Text + "', " + 
				tool.ConvertNull(DDL_CS_EXPERIENCE.SelectedValue) + ", " + 
				tool.ConvertNull(DDL_CS_EDUCATION.SelectedValue) + ", " + 
				tool.ConvertNull(DDL_CS_JOBTITLE.SelectedValue) + ", " + 
				tool.ConvertFloat(TXT_CS_STOCKPERC.Text) + ", '" + status + "', '" + 
				TXT_CS_ADDR1.Text + "', '" + TXT_CS_ADDR2.Text + "', '" + TXT_CS_ADDR3.Text + "', '" + 
				TXT_CS_ZIPCODE.Text + "', '" + RDO_KEY_PERSON.SelectedValue + "', " + 
				tool.ConvertNull(DDL_CS_SEX.SelectedValue) + ", " +
				tool.ConvertNull(DDL_CS_MARITAL.SelectedValue) + ", " +
				tool.ConvertNull(TXT_CS_CHILDREN.Text.Trim()) + ", " +
				tool.ConvertNull(TXT_CS_MULAIMENETAPMM.Text.Trim()) + ", " +
				tool.ConvertNull(TXT_CS_MULAIMENETAPYY.Text.Trim()) + ", " +
				tool.ConvertNull(DDL_CS_HOMESTA.SelectedValue) + ", '" +
				TXT_CS_REMARK.Text + "', '" + 
				RDO_RFCUSTOMERTYPE.SelectedValue + "', '" +
				TXT_CS_EMAS_CIF.Text  + "', '" +
				removed + "'";
				
			conn.ExecuteNonQuery();
			/*
			conn.QueryString = "insert into cust_stockholder " + 
				"(cu_ref, seq, cs_firstname, cs_middlename, cs_lastname, cs_dob, cs_idcardnum, cs_npwp, cs_experience, cs_education, cs_jobtitle, cs_stockperc, cs_natstat, active, cs_addr1, cs_addr2, cs_addr3, cs_zipcode) " + 
				"values ('" + Request.QueryString["curef"] + "', " + 
				count.ToString() + ", '" + 
				TXT_CS_FIRSTNAME.Text + "', '" + 
				TXT_CS_MIDDLENAME.Text + "', '" + 
				TXT_CS_LASTNAME.Text + "', " + 
				tool.ConvertDate(TXT_CS_DOB_DAY.Text, DDL_CS_DOB_MONTH.SelectedValue, TXT_CS_DOB_YEAR.Text) + ", '" + 
				TXT_CS_IDCARDNUM.Text + "', '" + 
				TXT_CS_NPWP.Text + "', " + 
				tool.ConvertNull(DDL_CS_EXPERIENCE.SelectedValue) + ", " + 
				tool.ConvertNull(DDL_CS_EDUCATION.SelectedValue) + ", " + 
				tool.ConvertNull(DDL_CS_JOBTITLE.SelectedValue) + ", " + 
				TXT_CS_STOCKPERC.Text + ", '" + status + "', '1', '" + 
				TXT_CS_ADDR1.Text + "', '" + TXT_CS_ADDR2.Text + "', '" + TXT_CS_ADDR3.Text + "', '" + 
				TXT_CS_ZIPCODE.Text + "')";
			conn.ExecuteNonQuery();
			*/

			ShowBlank();			
			FillCSGrid();
			//
			// kalau ada penambahan orang, reset nama stockholder account
			//
			fillHolderAccountName();
			DDL_HOLDER_NAME.SelectedValue = "";
		}

		private void ShowBlank()
		{
			TXT_CS_FIRSTNAME.Text = "";
			TXT_CS_MIDDLENAME.Text = "";
			TXT_CS_LASTNAME.Text = "";
			TXT_CS_IDCARDNUM.Text = "";
			TXT_CS_ADDR1.Text = "";
			TXT_CS_ADDR2.Text = "";
			TXT_CS_ADDR3.Text = "";
			TXT_CS_CITY.Text = "";
			TXT_CS_ZIPCODE.Text = "";
			TXT_CS_DOB_DAY.Text = "";
			DDL_CS_DOB_MONTH.SelectedValue = "";
			TXT_CS_DOB_YEAR.Text = "";
			DDL_CS_EDUCATION.SelectedValue = "";
			TXT_CS_NPWP.Text = "";
			DDL_CS_JOBTITLE.SelectedValue = "";
			DDL_CS_EXPERIENCE.SelectedValue = "";
			TXT_CS_STOCKPERC.Text = "0";
			RDO_KEY_PERSON.SelectedValue = "0";
			DDL_CS_SEX.SelectedValue		= "";
			DDL_CS_MARITAL.SelectedValue	= "";
			TXT_CS_CHILDREN.Text			= "";
			TXT_CS_MULAIMENETAPMM.Text		= "";
			TXT_CS_MULAIMENETAPYY.Text		= "";
			DDL_CS_HOMESTA.SelectedValue = "";
			TXT_CS_REMARK.Text = "";
			TXT_CS_EMAS_CIF.Text = "";
			//TXT_CS_MOTHER.Text = "";
			CHK_REMOVED.Checked = false;
		}

		private void DatGridPengurus_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			switch (((LinkButton)e.CommandSource).CommandName)
			{
				case "delete":
					///////////////////////////////
					///	Hapus data stock holder
					conn.QueryString = "delete from cust_stockholder where cu_ref='" + Request.QueryString["curef"] + "' and seq=" + e.Item.Cells[1].Text;
					conn.ExecuteNonQuery();

					//////////////////////////////////////
					///	Hapus data account stock holder
					conn.QueryString = "exec IDE_HOLDERACCOUNT '" + 
						Request.QueryString["curef"] + "', null, null, null, null, '4'";
					conn.ExecuteNonQuery();

					FillCSGrid();
					fillHolderAccountName();
					viewDataHolderAccount();					
					break;

				case "edit":
					SEQ.Text  =  e.Item.Cells[1].Text;
					// This code for link 
					conn.QueryString = "Select * from VW_DE_PENGURUS_PERUSAHAAN where cu_ref='" + 
										Request.QueryString["curef"] + "' and seq=" + Convert.ToInt32(SEQ.Text);
					conn.ExecuteQuery();

					setCustomerTypeMandatory(conn.GetFieldValue("CS_TYPE"));
					
					TXT_CS_FIRSTNAME.Text = conn.GetFieldValue("CS_FIRSTNAME");
					TXT_CS_MIDDLENAME.Text = conn.GetFieldValue("CS_MIDDLENAME");
					TXT_CS_LASTNAME.Text = conn.GetFieldValue("CS_LASTNAME");
					TXT_CS_IDCARDNUM.Text = conn.GetFieldValue("CS_IDCARDNUM");
					TXT_CS_ADDR1.Text = conn.GetFieldValue("CS_ADDR1");
					TXT_CS_ADDR2.Text = conn.GetFieldValue("CS_ADDR2");
					TXT_CS_ADDR3.Text = conn.GetFieldValue("CS_ADDR3");
					TXT_CS_CITY.Text =  conn.GetFieldValue("CS_DESC");
					
					RDO_KEY_PERSON.SelectedValue = conn.GetFieldValue("CS_KEYPERSON");

					string dtm = conn.GetFieldValue("CS_DOB");
					TXT_CS_DOB_DAY.Text = tool.FormatDate_Day(dtm);
					DDL_CS_DOB_MONTH.SelectedValue = tool.FormatDate_Month(dtm);
					TXT_CS_DOB_YEAR.Text = tool.FormatDate_Year(dtm);

					DDL_CS_EDUCATION.SelectedValue = conn.GetFieldValue("CS_EDUCATION");;
					TXT_CS_NPWP.Text = conn.GetFieldValue("CS_NPWP");
					DDL_CS_JOBTITLE.SelectedValue = conn.GetFieldValue("CS_JOBTITLE");
					DDL_CS_EXPERIENCE.SelectedValue = conn.GetFieldValue("CS_EXPERIENCE");
					TXT_CS_ZIPCODE.Text = conn.GetFieldValue("CS_ZIPCODE");
					TXT_CS_STOCKPERC.Text = conn.GetFieldValue("CS_STOCKPERC");
					//Response.Write("Isi persen saham : " + TXT_CS_STOCKPERC.Text);
					
					string CHECK = conn.GetFieldValue("CS_NATSTAT");
					if (CHECK == "0")
					{ 
						RDO_CS_NATSTAT0.Checked = true;
						RDO_CS_NATSTAT1.Checked = false;
					}
					else
					{
						RDO_CS_NATSTAT1.Checked = true;
						RDO_CS_NATSTAT0.Checked = false;
					}
					
					try {DDL_CS_SEX.SelectedValue = conn.GetFieldValue("CS_SEX");}
					catch {}
					try {DDL_CS_MARITAL.SelectedValue = conn.GetFieldValue("CS_MARITAL");}
					catch {}
					TXT_CS_CHILDREN.Text = conn.GetFieldValue("CS_CHILDREN");
					TXT_CS_MULAIMENETAPMM.Text = conn.GetFieldValue("CS_MULAIMENETAPMM");
					TXT_CS_MULAIMENETAPYY.Text = conn.GetFieldValue("CS_MULAIMENETAPYY");
					try {DDL_CS_HOMESTA.SelectedValue = conn.GetFieldValue("CS_HOMESTA");}
					catch {}
					TXT_CS_REMARK.Text = conn.GetFieldValue("CS_REMARK");

					TXT_CS_EMAS_CIF.Text = conn.GetFieldValue("EMAS_CIF");
					//TXT_CS_MOTHER.Text = conn.GetFieldValue("MOTHER");

					string removed = conn.GetFieldValue("REMOVED");
					if (removed == "1")
						CHK_REMOVED.Checked = true;
					else
						CHK_REMOVED.Checked = false;

					if (Request.QueryString["sta"] != "view")
					{
						BTN_STOCKHOLDER.Visible = false;
						BTN_UPDATE_NEW.Visible = true;
						BTN_CANCEL.Visible = true;
					}

					ZIP_CODE();
					break;
			}
		}

		protected void BTN_SEARCHCOMP_Click(object sender, System.EventArgs e)
		{
			//Response.Write("<script language='javascript'>window.open('SearchZipcode.aspx?targetFormID=Form1&targetObjectID=TXT_CS_ZIPCODE','SearchZipcode','status=no,scrollbars=no,width=420,height=200');</script>");
            Response.Write("<script language='javascript'>window.open('SearchZipcode.aspx?targetFormID=Form1&targetObjectID=TXT_CS_ZIPCODE&trgObjID2=TXT_CS_ADDR3&trgObjID3=TXT_CS_CITY&trgObjID4=LBL_CS_CITY','SearchZipcode','status=no,scrollbars=no,width=640,height=480');</script>");
		}

		protected void TXT_CS_ZIPCODE_TextChanged(object sender, System.EventArgs e)
		{
			ZIP_CODE();
		}

		private void ZIP_CODE()
		{
			conn.QueryString = "select cityid, cityname, description from vw_zipcodecity where rtrim(ltrim(zipcode)) = '" + 
				TXT_CS_ZIPCODE.Text.Trim() + "' ";
			conn.ExecuteQuery();
			try
			{
				if (conn.GetRowCount() > 0 && conn.GetFieldValue(0,2) != "")
                {
                    //TXT_CS_CITY.Text = conn.GetFieldValue(0, 2);
                    LBL_CS_CITY.Text = conn.GetFieldValue(0, 0);
                    TXT_CS_CITY.Text = conn.GetFieldValue(0, 1);
                    TXT_CS_ADDR3.Text = conn.GetFieldValue(0, 2);
                }
			}
			catch
			{
				TXT_CS_ZIPCODE.Text = "";
                TXT_CS_CITY.Text = "";
				GlobalTools.popMessage(this, "Invalid Zipcode!");
			}
		}
		protected void BTN_CANCEL_Click(object sender, System.EventArgs e)
		{
			ShowBlank();
			BTN_STOCKHOLDER.Visible = true;
			BTN_UPDATE_NEW.Visible = false;
			BTN_CANCEL.Visible = false;
		}

		protected void BTN_UPDATE_NEW_Click(object sender, System.EventArgs e)
		{
			//
			// kalau ada perubahan orang, reset nama stockholder account
			//
			fillHolderAccountName();
			DDL_HOLDER_NAME.SelectedValue = "";

			if (!UpdateData()) {
				this.setCustomerTypeMandatory(RDO_RFCUSTOMERTYPE.SelectedValue);
				return;  
			}
			FillCSGrid();
			viewDataHolderAccount();

			BTN_STOCKHOLDER.Visible = true;
			BTN_UPDATE_NEW.Visible = false;
			BTN_CANCEL.Visible = false;

			ShowBlank();
		}
		
		private bool UpdateData()
		{
			string status = "0" ;
			int intSeq = 0;
			
			if (DatGridPengurus.Items.Count > 0)
			{

				if (!isInputValid()) return false;

//				////////////////////////////////////////////
//				/// Validasi Mulai Menetap
//				/// 
//				int CS_MULAIMENETAPMM = 0, CS_MULAIMENETAPYY = 0;
//				if (TXT_CS_MULAIMENETAPMM.Text.Trim() != "" || TXT_CS_MULAIMENETAPYY.Text.Trim() != "") 
//				{
//					try { CS_MULAIMENETAPMM = Convert.ToInt16(TXT_CS_MULAIMENETAPMM.Text.Trim()); } 
//					catch {}
//					try { CS_MULAIMENETAPYY = Convert.ToInt16(TXT_CS_MULAIMENETAPYY.Text.Trim()); }
//					catch {}
//
//					if ((CS_MULAIMENETAPMM < 1 && CS_MULAIMENETAPMM > 12) || 
//						(!GlobalTools.isDateValid(1, CS_MULAIMENETAPMM, CS_MULAIMENETAPYY))) 
//					{
//						GlobalTools.popMessage(this, "Mulai Menetap tidak valid!");
//						return false;
//					}
//				}
//				///////////////////////////////////////////////////
//				
//
//				///////////////////////////////////////////////////
//				///--- validasi Tanggal Lahir (DOB)
//				///
//				if ((TXT_CS_DOB_DAY.Text != "") && (DDL_CS_DOB_MONTH.SelectedValue != "") && (TXT_CS_DOB_YEAR.Text != ""))
//				{
//					if (!GlobalTools.isDateValid(TXT_CS_DOB_DAY.Text, DDL_CS_DOB_MONTH.SelectedValue, TXT_CS_DOB_YEAR.Text)) 
//					{
//						GlobalTools.popMessage(this, "Tanggal Lahir tidak valid !");
//						return;
//					}
//
//					try 
//					{
//						dobDate = Int64.Parse(Tools.toISODate(TXT_CS_DOB_DAY, DDL_CS_DOB_MONTH, TXT_CS_DOB_YEAR));
//					} 
//					catch (ApplicationException) 
//					{
//						GlobalTools.popMessage(this, "Tanggal Lahir tidak valid !");
//						return;
//					}
//
//					now = Int64.Parse(Tools.toISODate(DateTime.Now.Day.ToString(), DateTime.Now.Month.ToString(), DateTime.Now.Year.ToString()));
//				
//					if (dobDate > now)
//					{
//						GlobalTools.popMessage(this, "DOB cannot be greater than current date!");
//						return;
//					}
//				}
//				///////////////////////////////////////////////////
//
//
//				float totSahamPercentage = 0;
//				for (int i = 0; i < DatGridPengurus.Items.Count; i++)
//				{
//					intSeq = Convert.ToInt32(DatGridPengurus.Items[i].Cells[1].Text);
//
//					if(Convert.ToInt32(SEQ.Text)==intSeq) continue;
//					
//					totSahamPercentage += float.Parse(float.Parse(DatGridPengurus.Items[i].Cells[7].Text).ToString("##,#0.00"));
//				}
//				if (totSahamPercentage + Convert.ToDouble(TXT_CS_STOCKPERC.Text) > 100)
//				{
//					TXT_CS_STOCKPERC.Text = "0";
//					GlobalTools.popMessage(this, "Stock Percentage Over 100% !");
//					return false;
//				}

			}
			if (RDO_CS_NATSTAT1.Checked)
				status = "1";

			string removed;
			if (CHK_REMOVED.Checked == true)
				removed = "1";
			else
				removed = "0";

			conn.QueryString = "exec DE_PENGURUS_PERUSAHAAN '" + Request.QueryString["curef"] + "', " + Convert.ToInt32(SEQ.Text) + ", '" +
				TXT_CS_FIRSTNAME.Text + "', '" + 
				TXT_CS_MIDDLENAME.Text + "', '" + 
				TXT_CS_LASTNAME.Text + "', " + 
				tool.ConvertDate(TXT_CS_DOB_DAY.Text, DDL_CS_DOB_MONTH.SelectedValue, TXT_CS_DOB_YEAR.Text) + ", '" + 
				TXT_CS_IDCARDNUM.Text + "', '" + 
				TXT_CS_NPWP.Text + "', " + 
				tool.ConvertNull(DDL_CS_EXPERIENCE.SelectedValue) + ", " + 
				tool.ConvertNull(DDL_CS_EDUCATION.SelectedValue) + ", " + 
				tool.ConvertNull(DDL_CS_JOBTITLE.SelectedValue) + ", " + 
				tool.ConvertFloat(TXT_CS_STOCKPERC.Text) + ", '" + status + "', '" + 
				TXT_CS_ADDR1.Text + "', '" + TXT_CS_ADDR2.Text + "', '" + TXT_CS_ADDR3.Text + "', '" + 
				TXT_CS_ZIPCODE.Text + "', '" + RDO_KEY_PERSON.SelectedValue + "', " +
				tool.ConvertNull(DDL_CS_SEX.SelectedValue) + ", " +
				tool.ConvertNull(DDL_CS_MARITAL.SelectedValue) + ", " +
				tool.ConvertNull(TXT_CS_CHILDREN.Text.Trim()) + ", " +
				tool.ConvertNull(TXT_CS_MULAIMENETAPMM.Text.Trim()) + ", " +
				tool.ConvertNull(TXT_CS_MULAIMENETAPYY.Text.Trim()) + ", '" +
				TXT_CS_REMARK.Text +"', "+
				tool.ConvertNull(DDL_CS_HOMESTA.SelectedValue)+",'"+
				TXT_CS_EMAS_CIF.Text  + "', '" +
				removed + "'";

			conn.ExecuteNonQuery();

			return true;
		}

		protected void RDO_RFCUSTOMERTYPE_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			this.setCustomerTypeMandatory(RDO_RFCUSTOMERTYPE.SelectedValue);
		}

		protected void Button1_Click(object sender, System.EventArgs e)
		{
			TXT_STATUS.Text		= "insert";
			ClearItems();
			ChangeSta(true);
		}

		private string getStatus(bool ISCHANNFACILITY) 
		{
			if (ISCHANNFACILITY) return "1";
			else return "0";
		}

		protected void BTN_NEW_Click(object sender, System.EventArgs e)
		{
			if (RB_ACCOUNT.SelectedValue == "0" && DDL_AI_AA_NO.SelectedValue.Trim()=="")
			{
				GlobalTools.popMessage(this,"AA No. harus dipilih !");
				GlobalTools.SetFocus(this,DDL_AI_AA_NO);
			}
			else if (RB_ACCOUNT.SelectedValue == "1" && TXT_AI_AA_NO.Text.Trim()=="")
			{
				GlobalTools.popMessage(this,"AA No. harus diisi !");
				GlobalTools.SetFocus(this,TXT_AI_AA_NO);
			}
			else if (DDL_AI_FACILITY.SelectedValue.Trim()=="")
			{
				GlobalTools.popMessage(this,"Kode Fasilitas harus diisi !");
				GlobalTools.SetFocus(this,DDL_AI_FACILITY);
			}
			else if (TXT_AI_SEQ.Text.Trim()=="")
			{
				GlobalTools.popMessage(this,"Sequence harus diisi !");
				GlobalTools.SetFocus(this,TXT_AI_SEQ);
			}
			else
			{

				string aa_no;
				if (RB_ACCOUNT.SelectedValue == "0")
					aa_no	= DDL_AI_AA_NO.SelectedValue;
				else
					aa_no	= TXT_AI_AA_NO.Text;

				/// CHECK for existing account (the same AANo, FacilityCode, AccSeq and AccNo)
				/// 
				try 
				{
					/*
					conn.QueryString = "SELECT ACC_NO FROM BOOKEDPROD WHERE CU_REF = '" + LBL_CUREF.Text + 
						"' and PRODUCTID = '" + DDL_AI_FACILITY.SelectedValue + 
						"' AND AA_NO = '" + aa_no + 
						"' AND ACC_SEQ = '" + TXT_AI_SEQ.Text.Trim() + 
						"' AND convert(bigint, ACC_NO) = '" + TXT_AI_NOREK.Text.Trim() + "'";
					*/
					conn.QueryString = "exec CUSTOMER_INFO_CEKBOOKEDPROD '" + 
						LBL_CUREF.Text + "', '" + 
						DDL_AI_FACILITY.SelectedValue + "', '" + 
						aa_no + "', '" + 
						TXT_AI_SEQ.Text.Trim() + "', '" + 
						TXT_AI_NOREK.Text.Trim() + "', '" + 
						getStatus(CHK_ISCHANNFACILITY.Checked) + "', '1'";					
					conn.ExecuteQuery();
				} 
				catch (Exception ex)
				{
					Response.Write("<!-- Error Check Existing Account | Desc: " + ex.ToString() + " -->");

					conn.QueryString = "SELECT ACC_NO FROM BOOKEDPROD WHERE CU_REF = '" + LBL_CUREF.Text + 
						"' and PRODUCTID = '" + DDL_AI_FACILITY.SelectedValue + 
						"' AND AA_NO = '" + aa_no + 
						"' AND ACC_SEQ = '" + TXT_AI_SEQ.Text.Trim() + 
						"' AND ACC_NO = '" + TXT_AI_NOREK.Text.Trim() + "'";
					conn.ExecuteQuery();
				}

				if (conn.GetRowCount() > 0) 
				{
					GlobalTools.popMessage(this, "The specified account already exist!");
					return;
				}

				/*
				conn.QueryString = "select sta = case when cu_ref='"+LBL_CUREF.Text+"' then 'true' else 'false' end "+
					"from bookedcust where aa_no='"+aa_no+"' ";
				*/
				conn.QueryString = "select 'true'";
				conn.ExecuteQuery();
				int row = conn.GetRowCount();
				if (row>0)
				{
					if (conn.GetFieldValue(0,0)=="true")
					{
						if (TXT_STATUS.Text == "insert")
							conn.QueryString = "exec IN_BOOKEDPROD '"+
								aa_no+"', '"+
								DDL_AI_FACILITY.SelectedValue+"', '"+
								TXT_AI_NOREK.Text+"', "+
								tool.ConvertNum(TXT_AI_SEQ.Text)+", "+
								GlobalTools.ConvertFloat(TXT_LIMIT.Text) + ", '"+
								LBL_CUREF.Text+"', " + 
								GlobalTools.ConvertFloat(TXT_LIMIT.Text) + ", " +		// Loan Amount
								GlobalTools.ConvertFloat(TXT_TENOR.Text) + ", '" +		// Tenor
								TXT_TENORCODE.Text + "', " +		// tenor code
								tool.ConvertNull(DDL_PRODUCT.SelectedValue) + ", 0, '" + 
								getStatus(CHK_ISCHANNFACILITY.Checked) + "', " + 
								GlobalTools.ToSQLDate(TXT_MATURITYDATE.Text) + ", '" + 
								TXT_BAKI_DEBET.Text + "', '" + 
								TXT_BANK_PERCENTAGE.Text + "' , '" + 
								TXT_REMAINING_EMAS_LIMIT.Text + "', '" + 
								TXT_PENDING_ACCEPT_LIMIT.Text + "', NULL, '" +
								DDL_CP_LOANPURPOSE.SelectedValue + "'";
						else
							conn.QueryString = "exec IN_BOOKEDPROD '"+
								aa_no+"', '"+
								DDL_AI_FACILITY.SelectedValue+"', '"+
								TXT_AI_NOREK.Text+"', "+
								tool.ConvertNum(TXT_AI_SEQ.Text)+", "+
								GlobalTools.ConvertFloat(TXT_LIMIT.Text) +", '"+
								LBL_CUREF.Text+"', " + 
								GlobalTools.ConvertFloat(TXT_LIMIT.Text) + ", " +		// Loan Amount
								GlobalTools.ConvertFloat(TXT_TENOR.Text) + ", '" +		// Tenor
								TXT_TENORCODE.Text + "', " +		// tenor code
								tool.ConvertNull(DDL_PRODUCT.SelectedValue) + ", 1, '" +
								getStatus(CHK_ISCHANNFACILITY.Checked) + "', " + 
								GlobalTools.ToSQLDate(TXT_MATURITYDATE.Text) + ", '" + 
								TXT_BAKI_DEBET.Text + "', '" + 
								TXT_BANK_PERCENTAGE.Text + "' , '" + 
								TXT_REMAINING_EMAS_LIMIT.Text + "' , '" + 
								TXT_PENDING_ACCEPT_LIMIT.Text + "', '" + 
								TXT_AI_NOREK_OLD.Text.Trim() + "', '" +
								DDL_CP_LOANPURPOSE.SelectedValue + "'";
						conn.ExecuteNonQuery();
						Response.Write("<!-- " + conn.QueryString.ToString() + " -->");

						RB_ACCOUNT.Enabled		= true;
						AddAccount();
						TXT_STATUS.Text			= "insert";
						ClearItems();
						ChangeSta(true);
						ViewGrid();
					}
					else
						GlobalTools.popMessage(this,"AA No. "+aa_no+" already exist with another customer !");
				}
				else
				{
					if (TXT_STATUS.Text == "insert")
						conn.QueryString = "exec IN_BOOKEDPROD '"+
							aa_no+"', '"+
							DDL_AI_FACILITY.SelectedValue+"', '"+
							TXT_AI_NOREK.Text+"', "+
							tool.ConvertNum(TXT_AI_SEQ.Text)+", "+
							GlobalTools.ConvertFloat(TXT_LIMIT.Text) + ", '"+
							LBL_CUREF.Text+"', " + 
							GlobalTools.ConvertFloat(TXT_LIMIT.Text) + ", " +		// Loan Amount
							GlobalTools.ConvertFloat(TXT_TENOR.Text) + ", '" +		// Tenor
							TXT_TENORCODE.Text + "', " +							// tenor code
							tool.ConvertNull(DDL_PRODUCT.SelectedValue) + ", 0, '" + 
							getStatus(CHK_ISCHANNFACILITY.Checked) + "', " + 
							GlobalTools.ToSQLDate(TXT_MATURITYDATE.Text) + ", '" + 
							TXT_BAKI_DEBET.Text + "', '" + 
							TXT_BANK_PERCENTAGE.Text + "' , '" + 
							TXT_REMAINING_EMAS_LIMIT.Text + "', '" + 
							TXT_PENDING_ACCEPT_LIMIT.Text + "', NULL, '" +
							DDL_CP_LOANPURPOSE.SelectedValue + "'";
					else
						conn.QueryString = "exec IN_BOOKEDPROD '"+
							aa_no+"', '"+
							DDL_AI_FACILITY.SelectedValue+"', '"+
							TXT_AI_NOREK.Text+"', "+
							tool.ConvertNum(TXT_AI_SEQ.Text)+", "+
							GlobalTools.ConvertFloat(TXT_LIMIT.Text) +", '"+
							LBL_CUREF.Text+"', " + 
							GlobalTools.ConvertFloat(TXT_LIMIT.Text) + ", " +		// Loan Amount
							GlobalTools.ConvertFloat(TXT_TENOR.Text) + ", '" +		// Tenor
							TXT_TENORCODE.Text + "', " +		// tenor code
							tool.ConvertNull(DDL_PRODUCT.SelectedValue) + ", 1, '" +
							getStatus(CHK_ISCHANNFACILITY.Checked) + "', " + 
							GlobalTools.ToSQLDate(TXT_MATURITYDATE.Text) + ", '" + 
							TXT_BAKI_DEBET.Text + "', '" + 
							TXT_BANK_PERCENTAGE.Text + "', '" + 
							TXT_REMAINING_EMAS_LIMIT.Text + "', '" + 
							TXT_PENDING_ACCEPT_LIMIT.Text + "', '" + 
							TXT_AI_NOREK_OLD.Text.Trim() + "', '" +
							DDL_CP_LOANPURPOSE.SelectedValue + "'";
					conn.ExecuteNonQuery();
					RB_ACCOUNT.Enabled		= true;
					AddAccount();
					TXT_STATUS.Text			= "insert";
					ClearItems();
					ChangeSta(true);
					ViewGrid();
				}
				conn.ClearData();
			}	
		}

		private void ViewGrid()
		{
			conn.QueryString = "select aa_no, productid, acc_no, acc_seq, limit, BC_LOANAMOUNT, convert(varchar,bc_tenor)+' '+tenordesc as tenor, bc_tenor, bc_tenorcode  "+
				"from VW_BOOKEDPROD a Left Join rftenorcode b on a.bc_tenorcode=b.tenorcode where cu_ref='"+LBL_CUREF.Text+"'";																					  
			conn.ExecuteQuery();
			DataTable d = new DataTable();
			d			= conn.GetDataTable().Copy();
			DatGrd.DataSource	= d;
			try 
			{
				DatGrd.DataBind();
			} 
			catch 
			{
				DatGrd.CurrentPageIndex = 0;
				DatGrd.DataBind();
			}
		}
		private void ClearItems()
		{
			RB_ACCOUNT.SelectedValue		= "0";
			TXT_AI_AA_NO.Visible			= false;
			DDL_AI_AA_NO.Visible			= true;
			TXT_AI_AA_NO.Text				= "";
			DDL_AI_AA_NO.SelectedValue		= "";
			DDL_AI_FACILITY.SelectedValue	= "";
			TXT_AI_NOREK.Text				= "";
			TXT_AI_NOREK.ReadOnly			= false;
			TXT_AI_NOREK.Enabled			= true;
			TXT_AI_SEQ.Text					= "";
			CHK_ISCHANNFACILITY.Checked		= false;
			DDL_PRODUCT.SelectedValue		= "";
			TXT_LIMIT.Text					= "";
			TXT_TENOR.Text					= "";
			TXT_TENORCODE.Text				= "";
			TXT_MATURITYDATE.Text			= "";
			TXT_BAKI_DEBET.Text				= "";
			TXT_BANK_PERCENTAGE.Text		= "";
			TXT_REMAINING_EMAS_LIMIT.Text	= "";
			TXT_PENDING_ACCEPT_LIMIT.Text   = "";
		}

		private void ChangeSta(bool sta)
		{
			DDL_AI_AA_NO.Enabled	= sta;
			DDL_AI_FACILITY.Enabled	= sta;
			TXT_AI_SEQ.Enabled		= sta;
			RB_ACCOUNT.Enabled		= sta;			
			CHK_ISCHANNFACILITY.Enabled = sta;
		}

		private void AddAccount()
		{
			DDL_AI_AA_NO.Items.Clear();

			GlobalTools.fillRefList(DDL_AI_AA_NO, "select distinct aa_no, aa_no from BOOKEDCUST where cu_ref='"+LBL_CUREF.Text+"'", false, conn);

			conn.ClearData();
		}

		private void DatGrd_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			//cari LOSPRODUCT dulu
			conn.QueryString = "select * from BOOKEDPROD ";
			conn.QueryString += "where AA_NO = '" + e.Item.Cells[0].Text + "' and ";
			conn.QueryString += "PRODUCTID = '" + e.Item.Cells[1].Text + "' and ";
			conn.QueryString += "ACC_SEQ = " + tool.ConvertNum(e.Item.Cells[5].Text) + " and ";
			conn.QueryString += "ACC_NO = '" + e.Item.Cells[4].Text + "' and CU_REF = '" + LBL_CUREF.Text + "'";
			conn.ExecuteQuery();
			string losproductid			= conn.GetFieldValue("LOSPRODUCTID");
			TXT_LIMIT.Text				= conn.GetFieldValue("LIMIT");
			TXT_TENOR.Text				= conn.GetFieldValue("TENOR");
			TXT_TENORCODE.Text			= conn.GetFieldValue("TENORCODE");			
			CHK_ISCHANNFACILITY.Checked = (conn.GetFieldValue("ISCHANNFACILITY")=="1"?true:false);
			TXT_MATURITYDATE.Text		= conn.GetFieldValue("MATURITYDATE");
			TXT_BAKI_DEBET.Text			= conn.GetFieldValue("BAKI_DEBET");
			TXT_BANK_PERCENTAGE.Text	= conn.GetFieldValue("BANK_PERCENTAGE");
			TXT_REMAINING_EMAS_LIMIT.Text	= conn.GetFieldValue("REMAINING_EMAS_LIMIT");
			TXT_PENDING_ACCEPT_LIMIT.Text	= conn.GetFieldValue("PENDING_ACCEPT_LIMIT");

			try {DDL_CP_LOANPURPOSE.SelectedValue = conn.GetFieldValue("LOANPURPID");}
			catch {}

			if (CHK_ISCHANNFACILITY.Checked) TXT_AI_NOREK.Enabled = false;

			switch (((LinkButton)e.CommandSource).CommandName)
			{
				case "Delete":					
					//
					// Sebelum hapus, cek dulu relationship table dengan tabel lain
					//

					// Relationship dengan table Ketentuan_Kredit //
					try 
					{
						conn.QueryString = "select * from KETENTUAN_KREDIT A left join APPLICATION B" +
							" on A.AP_REGNO = B.AP_REGNO where A.AA_NO = '" + e.Item.Cells[0].Text + 
							"' and A.PRODUCTID = '" + e.Item.Cells[1].Text + 
							"' and A.ACC_SEQ = '" + e.Item.Cells[5].Text + 
							"' and A.ACC_NO = '" + e.Item.Cells[4].Text.Replace("&nbsp;","") + 
							"' and B.CU_REF <> '" + LBL_CUREF.Text + "'";
						conn.ExecuteQuery();
					} 
					catch (NullReferenceException) 
					{
						GlobalTools.popMessage(this, "Connection Error!");
						Response.Redirect("../Login.aspx?expire=1");
					}
					if (conn.GetRowCount() > 0) 
					{
						GlobalTools.popMessage(this, "Account tidak bisa dihapus karena sudah terpakai!");
						return;
					}

					// Relationship dengan table Channeling //
					try 
					{
						conn.QueryString = "select * from CHANNELING  where CH_AA_NO = '" + e.Item.Cells[0].Text + 
							"' and CH_PRODUCTID = '" + e.Item.Cells[1].Text + 
							"' and CH_ACC_SEQ = '" + e.Item.Cells[5].Text + "'";
						conn.ExecuteQuery();
					} 
					catch (NullReferenceException) 
					{
						GlobalTools.popMessage(this, "Connection Error!");
						Response.Redirect("../Login.aspx?expire=1");
					}
					if (conn.GetRowCount() > 0) 
					{
						GlobalTools.popMessage(this, "Account tidak bisa dihapus karena sudah terpakai!");
						return;
					}

					conn.QueryString = "exec IN_BOOKEDPROD '" + 
						e.Item.Cells[0].Text + "', '" + // AA_NO
						e.Item.Cells[1].Text + "', '" + // PRODID
						e.Item.Cells[4].Text+"', " +	// ACC_NO
						tool.ConvertNum(e.Item.Cells[5].Text) + ", " +	// ACC_SEQ
						tool.ConvertFloat(e.Item.Cells[6].Text)+", '" + // LIMIT
						LBL_CUREF.Text + "', " + // CUREF
						GlobalTools.ConvertFloat(TXT_LIMIT.Text) + ", " +		// Loan Amount
						GlobalTools.ConvertFloat(TXT_TENOR.Text) + ", '" +		// Tenor
						TXT_TENORCODE.Text.Trim() + "', '" +		// tenor code
						losproductid + "', " + // LOSPRODUCTID
						"2, '" +	// tipe
						getStatus(CHK_ISCHANNFACILITY.Checked) + "', '" +		// ischanneling facility
						TXT_MATURITYDATE.Text + "', '" +	// maturitydate
						TXT_BAKI_DEBET.Text + "', '" +	// baki_debet
						TXT_BANK_PERCENTAGE.Text + "', '" +		// bank_percentage
						TXT_REMAINING_EMAS_LIMIT.Text + "', '" +	// remaining eMas limit	
						TXT_PENDING_ACCEPT_LIMIT.Text + "', null, null";
					conn.ExecuteNonQuery();
					AddAccount();
					int index = DatGrd.Items.Count;			
					int jml = (index % 3)-1;
					if (jml == 0)
						DatGrd.CurrentPageIndex = index/3;
					ViewGrid();
					ClearItems();
					break;

				case "Edit":
					RB_ACCOUNT.SelectedValue		= "0";
					string loan						= e.Item.Cells[2].Text;
					if (loan=="&nbsp;")
						loan	= "0";
					string tenorcode				= e.Item.Cells[10].Text;
					if (tenorcode=="&nbsp;")
						tenorcode	= "";
					string norek				= e.Item.Cells[4].Text;
					if (norek=="&nbsp;")
						norek	= "";
					
					DDL_AI_AA_NO.SelectedValue		= e.Item.Cells[0].Text.Trim();
					DDL_AI_FACILITY.SelectedValue	= e.Item.Cells[1].Text;
					
					TXT_AI_NOREK.Text				= norek;
					TXT_AI_NOREK_OLD.Text			= norek;
					TXT_AI_SEQ.Text					= e.Item.Cells[5].Text;

					try {DDL_PRODUCT.SelectedValue = losproductid;}
					catch {}
					
					TXT_STATUS.Text					= "edit";
					DDL_AI_AA_NO.Visible			= true;
					TXT_AI_AA_NO.Visible			= false;
					RB_ACCOUNT.Enabled				= false;
					ChangeSta(false);
					break;
			}
		}

		protected void RB_ACCOUNT_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if (RB_ACCOUNT.SelectedValue == "0")
			{
				DDL_AI_AA_NO.Visible	= true;
				TXT_AI_AA_NO.Visible	= false;
			}
			else
			{
				DDL_AI_AA_NO.Visible	= false;
				TXT_AI_AA_NO.Visible	= true;
			}
		}

		protected void DDL_AI_AA_NO_SelectedIndexChanged(object sender, System.EventArgs e)
		{
		
		}

		protected void BTN_SAVE_HOLDERACC_Click(object sender, System.EventArgs e)
		{
			//
			// mandatory field :
			// - nama
			// - no rekening
			//

			// --- validasi nama --- //
			if (DDL_HOLDER_NAME.SelectedValue == "") 
			{
				GlobalTools.popMessage(this, "Nama Pemegang Saham tidak boleh kosong!");
				return;
			}

			// --- validasi no rekening --- //
			if (TXT_HOLD_ACC_NO.Text.Trim() == "") 
			{
				GlobalTools.popMessage(this, "No Rekening tidak boleh kosong!");
				return;
			}

			// save /insert ke database
			try 
			{
				conn.QueryString = "exec IDE_HOLDERACCOUNT '" + 
					LBL_CUREF.Text + "', '" + 
					DDL_HOLDER_NAME.SelectedValue + "', " + 
					"null, '" + 
					TXT_HOLD_ACC_NO.Text.Trim() + "', " + 
					tool.ConvertNull(TXT_HOLD_REMARK.Text.Trim()) + ", " + 
					"'1'";
				conn.ExecuteNonQuery();

				viewDataHolderAccount();
				clearHolderAccount();
			} 
			catch (NullReferenceException) 
			{
			}
		}

		protected void DDL_HOLDER_NAME_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			conn.QueryString = "select * from VW_IDE_HOLDERACCOUNTENTRY where CU_REF = '" + LBL_CUREF.Text + 
				"' and SEQ = '" + DDL_HOLDER_NAME.SelectedValue + "'";
			conn.ExecuteQuery();

			LBL_IDCARDNUM.Text				= conn.GetFieldValue("CS_IDCARDNUM");
			LBL_NPWP.Text					= conn.GetFieldValue("CS_NPWP");
			try
			{
				RDO_KEY_PERSON_2.SelectedValue	= conn.GetFieldValue("CS_KEYPERSON");
			}
			catch
			{
			}
		}

		private void DatGrdAccStockHolder_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			string SEQ = e.Item.Cells[0].Text;
			string HOLD_ACC_SEQ = e.Item.Cells[1].Text;

			switch (e.CommandName.ToString()) 
			{
				case "Edit":
					LBL_HOLD_ACC_SEQ.Text			= HOLD_ACC_SEQ;
					BTN_SAVE_HOLDERACC.Visible		= false;
					BTN_UPDATE_HOLDERACC.Visible	= true;

					conn.QueryString = "select * from VW_IDE_HOLDERACCOUNTENTRY2 where CU_REF = '" + LBL_CUREF.Text + 
						"' and SEQ = '" + SEQ + 
						"' and HOLD_ACC_SEQ = '" + HOLD_ACC_SEQ + "'";
					conn.ExecuteQuery();

					try {DDL_HOLDER_NAME.SelectedValue = conn.GetFieldValue("SEQ");}
					catch {}
					LBL_IDCARDNUM.Text		= conn.GetFieldValue("CS_IDCARDNUM");
					LBL_NPWP.Text			= conn.GetFieldValue("CS_NPWP");
					TXT_HOLD_ACC_NO.Text	= conn.GetFieldValue("HOLD_ACC_NO");
					TXT_HOLD_REMARK.Text	= conn.GetFieldValue("HOLD_REMARK");
					break;

				case "Delete":
					conn.QueryString = "exec IDE_HOLDERACCOUNT '" + 
						LBL_CUREF.Text + "', '" + 
						SEQ + "', '" + 
						HOLD_ACC_SEQ + "', null, null, '3'";
					conn.ExecuteNonQuery();

					viewDataHolderAccount();
					break;
			}
		}

		protected void BTN_CANCEL_HOLDERACC_Click(object sender, System.EventArgs e)
		{
			clearHolderAccount();
		}

		protected void BTN_UPDATE_HOLDERACC_Click(object sender, System.EventArgs e)
		{		
			conn.QueryString = "exec IDE_HOLDERACCOUNT '" + 
				LBL_CUREF.Text + "', '" + 
				DDL_HOLDER_NAME.SelectedValue + "', '" + 
				LBL_HOLD_ACC_SEQ.Text + "', '" + 
				TXT_HOLD_ACC_NO.Text.Trim() + "', " + 
				tool.ConvertNull(TXT_HOLD_REMARK.Text.Trim()) + ", " + 
				"'2'";
			conn.ExecuteNonQuery();

			viewDataHolderAccount();
			clearHolderAccount();
		}

		protected void RDO_KEY_PERSON_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			TXT_CS_CHILDREN.CssClass = "";
			TXT_CS_MULAIMENETAPMM.CssClass = "";
			TXT_CS_MULAIMENETAPYY.CssClass = "";
			DDL_CS_HOMESTA.CssClass = "";			

			setMandatoryFI(RDO_KEY_PERSON.SelectedValue, Request.QueryString["prog"]);

			Tools.SetFocus(this, RDO_KEY_PERSON);
		}
	}
}
