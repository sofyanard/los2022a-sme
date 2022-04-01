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
using DMS.CuBESCore;
using DMS.DBConnection;

namespace SME.DataEntry
{
	/// <summary>
	/// Summary description for IDE_InfoPerusahaan.
	/// </summary>
	public partial class IDE_InfoPerusahaan : System.Web.UI.Page
	{

		#region " Variable "

		private Connection conn;
		private Tools tool =new Tools();
		private string mainregno, maincuref, regno, curef, tc, mc, mainprod_seq, mainproductid;

		#endregion

		protected void Page_Load(object sender, System.EventArgs e)
		{
			conn = (Connection) Session["Connection"];

			mainregno		= Request.QueryString["mainregno"];
			mainprod_seq	= Request.QueryString["mainprod_seq"];
			mainproductid	= Request.QueryString["mainproductid"];
			maincuref		= Request.QueryString["maincuref"];
			regno			= Request.QueryString["regno"];
			curef			= Request.QueryString["curef"];
			tc				= Request.QueryString["tc"];
			mc				= Request.QueryString["mc"];

			if (!IsPostBack)
			{
				GlobalTools.fillRefList(DDL_CS_HOMESTA, "select * from rfhomesta where active = '1'", false, conn);
				GlobalTools.fillRefList(DDL_CS_EDUCATION, "select educationid, educationdesc from rfeducation where active='1'", false, conn);
				GlobalTools.fillRefList(DDL_CS_EXPERIENCE, "select expid, expdesc from rfexperience where active='1'", false, conn);
				GlobalTools.fillRefList(DDL_CS_JOBTITLE, "select JOBTITLEID, JOBTITLEDESC from RFJOBTITLE where ACTIVE='1' order by JOBTITLEID", false, conn);
				GlobalTools.initDateForm(TXT_CS_DOB_DAY, DDL_CS_DOB_MONTH, TXT_CS_DOB_YEAR);
				GlobalTools.initDateForm(TXT_CI_BMDEBITURDAY, DDL_CI_BMDEBITURMONTH, TXT_CI_BMDEBITURYEAR);
				GlobalTools.initDateForm(TXT_CI_BMSAVINGDAY, DDL_CI_BMSAVINGMONTH, TXT_CI_BMSAVINGYEAR);
				GlobalTools.initDateForm(TXT_CI_BMGIRODAY, DDL_CI_BMGIROMONTH, TXT_CI_BMGIROYEAR);
				GlobalTools.initDateForm(TXT_CS_DOB_DAY, DDL_CS_DOB_MONTH, TXT_CS_DOB_YEAR);
				GlobalTools.fillRefList(DDL_CS_SEX, "select sexid, sexdesc from rfsex where active='1'", false, conn);
				GlobalTools.fillRefList(DDL_CS_MARITAL, "select maritalid, maritaldesc from rfmarital where active='1'", false, conn);

				//--- Customer Type
				conn.QueryString = "select custtypeid, custtypedesc from rfcustomertype where active='1'";
				conn.ExecuteQuery();
				for (int i = 0; i < conn.GetRowCount(); i++)
					RDO_RFCUSTOMERTYPE.Items.Add(new ListItem(conn.GetFieldValue(i,1), conn.GetFieldValue(i,0)));
				//TODO : Hardoced ?!
				RDO_RFCUSTOMERTYPE.SelectedValue = "02";

				//--- Product (Facility di Rekening Level)
				GlobalTools.fillRefList(DDL_PRODUCT, "select * from RFPRODUCT where ACTIVE = '1'", true, conn);

				//--- Facility (Facility di Facility Level)
				GlobalTools.fillRefList(DDL_AI_FACILITY, "select SIBS_PRODID, SIBS_PRODID from RFPRODUCT where ACTIVE = '1'", false, conn);

				// periksa apakah customer punya CIF
				conn.QueryString = "select CU_CIF from CUSTOMER";
				conn.QueryString += " WHERE CU_REF = '" + Request.QueryString["curef"] + "'";
				conn.ExecuteQuery();

				//Response.Write("<script language='javascript'>alert('" + conn.GetFieldValue("CU_CIF") + "')</script>");
				if (conn.GetFieldValue("CU_CIF") == "")
				{ // kasus customer tidak punya CIF, berarti tabel Customer Loan Info tidak ditampilkan
					TBL_CUST_LOAN_INFO.Visible = false;
					// DEBITUR sejak di-disable
					TXT_CI_BMDEBITURDAY.Enabled = false;
					TXT_CI_BMDEBITURYEAR.Enabled = false;
					DDL_CI_BMDEBITURMONTH.Enabled = false;
				}

				ViewData();		//menampilkan data company info
				//ViewOB();
				FillCSGrid();	

				AddAccount();
				ViewGrid();
			}			

			BTN_STOCKHOLDER.Attributes.Add("onclick","if(!cek_mandatoryColl(document.Form1)){return false;};");
			BTN_UPDATE_NEW.Attributes.Add("onclick","if(!cek_mandatoryColl(document.Form1)){return false;};");
		}

		private void ZIP_CODE()
		{
			conn.QueryString = "select cityid, cityname, description from vw_zipcodecity where rtrim(ltrim(zipcode)) = '" + 
				TXT_CS_ZIPCODE.Text.Trim() + "' ";
			conn.ExecuteQuery();
			try
			{
				//LBL_CU_CITY.Text = conn.GetFieldValue(0,0);gfgf
				TXT_CS_CITY.Text = conn.GetFieldValue(0,2);
			}
			catch
			{
				TXT_CS_ZIPCODE.Text = "";
				GlobalTools.popMessage(this, "Invalid Zipcode!");
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
			this.DatGridPengurus.ItemCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.DatGridPengurus_ItemCommand);
			this.DatGrd.ItemCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.DatGrd_ItemCommand);

		}
		#endregion

		#region " Defined Methods "

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
				totSaham = totSaham + temp;
			}
			totSaham = 100 - totSaham;
			//LBL_TOTPERC.Text = totSaham.ToString();			
			//TXT_CS_STOCKPERC.Text = totSaham.ToString();

			//------- Modified by Yudi (06-08-2004) --------------
			LBL_TOTPERC.Text = totSaham.ToString("##,#0.00");
			TXT_CS_STOCKPERC.Text = totSaham.ToString("##,#0.00");
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
		}

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
			}

			//TANGGAL TABUNGAN
			if (TXT_CI_BMSAVINGDAY.Text != "" || DDL_CI_BMSAVINGMONTH.SelectedValue != "" || TXT_CI_BMSAVINGYEAR.Text != "") 
			{
				if (!Tools.isDateValid(this, TXT_CI_BMSAVINGDAY.Text, DDL_CI_BMSAVINGMONTH.SelectedValue, TXT_CI_BMSAVINGYEAR.Text))
				{
					GlobalTools.popMessage(this, "Tanggal Tabungan Sejak tidak valid !");
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
			}


			conn.QueryString = "exec IDE_INFOPERUSAHAAN '"+
				LBL_CUREF.Text +"', " + 
				tool.ConvertDate(TXT_CI_BMGIRODAY.Text, DDL_CI_BMGIROMONTH.SelectedValue, TXT_CI_BMGIROYEAR.Text) +", "+
				tool.ConvertDate(TXT_CI_BMSAVINGDAY.Text, DDL_CI_BMSAVINGMONTH.SelectedValue, TXT_CI_BMSAVINGYEAR.Text) +", "+
				tool.ConvertDate(TXT_CI_BMDEBITURDAY.Text, DDL_CI_BMDEBITURMONTH.SelectedValue, TXT_CI_BMDEBITURYEAR.Text);
			conn.ExecuteNonQuery();
		}

		private void UpdateData()
		{
			string status = "0" ;
			int intSeq = 0;
			
			/**
			if (DatGridPengurus.Items.Count > 0)
			{
				float totSahamPercentage = 0;

				for (int i = 0; i < DatGridPengurus.Items.Count; i++)
				{
					intSeq = Convert.ToInt32(DatGridPengurus.Items[i].Cells[1].Text);

					if(Convert.ToInt32(SEQ.Text)==intSeq) continue;
					
					totSahamPercentage += float.Parse(float.Parse(DatGridPengurus.Items[i].Cells[7].Text).ToString("##,#0.00"));
				}
				if (totSahamPercentage + Convert.ToDouble(TXT_CS_STOCKPERC.Text) > 100)
				{
					TXT_CS_STOCKPERC.Text = "0";
					Response.Write("<script language='javascript'>alert('Stock Percentage Over 100%');</script>");
					return;
				}
			}
			**/
			/// Logic Reloaded 
			/// 
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
				return;
			}


			if (RDO_CS_NATSTAT1.Checked)
				status = "1";


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
				tool.ConvertNull(DDL_CS_HOMESTA.SelectedValue);

			conn.ExecuteNonQuery();
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
		}

		private void AddAccount()
		{
			DDL_AI_AA_NO.Items.Clear();

			GlobalTools.fillRefList(DDL_AI_AA_NO, "select distinct aa_no, aa_no from BOOKEDCUST where cu_ref='"+LBL_CUREF.Text+"'", false, conn);

			conn.ClearData();
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
			TXT_AI_SEQ.Text					= "";
		}
		private void ChangeSta(bool sta)
		{
			DDL_AI_AA_NO.Enabled	= sta;
			DDL_AI_FACILITY.Enabled	= sta;
			TXT_AI_SEQ.Enabled		= sta;
			RB_ACCOUNT.Enabled		= sta;
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

		#endregion

		protected void BTN_STOCKHOLDER_Click(object sender, System.EventArgs e)
		{
			string status = "0", dbg = Request.QueryString["curef"] ;
			int count = 0;
			Int64 dobDate = 0, now = 0;

			//--- validasi Tanggal Lahir (DOB)
			if ((TXT_CS_DOB_DAY.Text != "") && (DDL_CS_DOB_MONTH.SelectedValue != "") && (TXT_CS_DOB_YEAR.Text != ""))
			{
				try 
				{
					dobDate = Int64.Parse(Tools.toISODate(TXT_CS_DOB_DAY, DDL_CS_DOB_MONTH, TXT_CS_DOB_YEAR));
				} 
				catch (ApplicationException) 
				{
					GlobalTools.popMessage(this, "Tanggal Lahir tidak valid !");
					return;
				}

				now = Int64.Parse(Tools.toISODate(DateTime.Now.Day.ToString(), DateTime.Now.Month.ToString(), DateTime.Now.Year.ToString()));
				
				if (dobDate > now)
				{
					GlobalTools.popMessage(this, "DOB cannot be greater than current date!");
					return;
				}
			}
			
			//--- validasi Percentage
			try 
			{
				if (float.Parse(TXT_CS_STOCKPERC.Text) > float.Parse(LBL_TOTPERC.Text))
				{
					TXT_CS_STOCKPERC.Text = "";
					GlobalTools.popMessage(this, "Stock Percentage Over 100% !");
					return;
				}

				if (RDO_RFCUSTOMERTYPE.SelectedValue == "01") //--- badan usaha
				{
					//... stock 0.00 tidak boleh
					if (float.Parse(TXT_CS_STOCKPERC.Text) <= 0.00) 
					{
						TXT_CS_STOCKPERC.Text = "";
						GlobalTools.popMessage(this, "Stock tidak boleh 0.00!");
						return;
					}
				}
			} 
			catch 
			{
				GlobalTools.popMessage(this, "Nilai Stock tidak valid !");
				return;
			}

			//--- Validasi KEY PERSON
			//    KEY Person harus ORANG
			if (RDO_KEY_PERSON.SelectedValue == "1" && RDO_RFCUSTOMERTYPE.SelectedValue == "01") // Ya & Badan usaha
			{
				GlobalTools.popMessage(this, "Key Person harus Perorangan !");
				return;
			}
			
			count = DatGridPengurus.Items.Count + 1;
			if (RDO_CS_NATSTAT1.Checked)
				status = "1";

			conn.QueryString = "exec DE_CUST_STOCKHOLDER '" + 
				curef + "', '" + 
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
				TXT_CS_REMARK.Text + "','" + 
				RDO_RFCUSTOMERTYPE.SelectedValue + "'";			

			conn.ExecuteNonQuery();			

			ShowBlank();
				
			FillCSGrid();			
		}

		protected void BTN_UPDATE_NEW_Click(object sender, System.EventArgs e)
		{
			UpdateData();
			FillCSGrid();

			BTN_STOCKHOLDER.Visible = true;
			BTN_UPDATE_NEW.Visible = false;
			BTN_CANCEL.Visible = false;

			ShowBlank();
		}

		protected void BTN_CANCEL_Click(object sender, System.EventArgs e)
		{
			ShowBlank();
			BTN_STOCKHOLDER.Visible = true;
			BTN_UPDATE_NEW.Visible = false;
			BTN_CANCEL.Visible = false;
		}

		protected void BTN_SAVE_Click(object sender, System.EventArgs e)
		{
			saveHubunganDenganBM();
		}

		protected void BTN_UPDATE_Click(object sender, System.EventArgs e)
		{
			saveHubunganDenganBM();

			if (DatGridPengurus.Items.Count > 0)
			{
				float totSahamPercentage = 0;

				bool isAdaKeyPerson = false;
				for (int i = 0; i < DatGridPengurus.Items.Count; i++)
				{
					//totSahamPercentage += float.Parse(DatGridPengurus.Items[i].Cells[7].Text);
					//--- Modified By Yudi (12-Ags-2004) ---
					totSahamPercentage += float.Parse(float.Parse(DatGridPengurus.Items[i].Cells[7].Text).ToString("##,#0.00"));

					string KEYPERSON = DatGridPengurus.Items[i].Cells[11].Text;
					if (KEYPERSON == "YA") 					
						isAdaKeyPerson = true;					
				}
				
				if (totSahamPercentage  < 100.0 || totSahamPercentage > 100.0)
					GlobalTools.popMessage(this, "Total saham harus 100%!");
				else if (!isAdaKeyPerson) 
				{
					GlobalTools.popMessage(this, "Perusahaan harus punya Key Person, min 1 Orang !");
				}
				else
				{
					Response.Redirect("../BlackList/BL_result.aspx?" + 
						"mainregno=" + Request.QueryString["mainregno"] +
						"&mainprod_seq=" + mainprod_seq +
						"&mainproductid=" + mainproductid +
						"&regno=" + Request.QueryString["regno"] + 
						"&curef=" + Request.QueryString["curef"] + 
						"&prog=" + Request.QueryString["prog"] + 
						"&tc=" + Request.QueryString["tc"] + 
						"&mc=" + Request.QueryString["mc"] + 
						"&exist=" + Request.QueryString["exist"]);
				}			
			}
			else
			{
				conn.QueryString = "select cu_custtypeid from customer where cu_ref='" + Request.QueryString["curef"] + "'";
				conn.ExecuteQuery();
				if (conn.GetFieldValue(0,0) == "01")
					GlobalTools.popMessage(this, "Data Direksi harus diisi!");
				else
					Response.Redirect("../BlackList/BL_result.aspx?" + 
						"mainregno=" + Request.QueryString["mainregno"] + 
						"&mainprod_seq=" + mainprod_seq +
						"&mainproductid=" + mainproductid +
						"&regno=" + Request.QueryString["regno"] + 
						"&curef=" + Request.QueryString["curef"] + 
						"&prog=" + Request.QueryString["prog"] + 
						"&tc=" + Request.QueryString["tc"] + 
						"&mc=" + Request.QueryString["mc"] + 
						"&exist=" + Request.QueryString["exist"]);
			}			
		}

		private void DatGridPengurus_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			switch (((LinkButton)e.CommandSource).CommandName)
			{
				case "delete":
					conn.QueryString = "delete from cust_stockholder where cu_ref='" + Request.QueryString["curef"] + "' and seq=" + e.Item.Cells[1].Text;
					conn.ExecuteNonQuery();
					FillCSGrid();

					break;
				case "edit":
					SEQ.Text  =  e.Item.Cells[1].Text;
					// This code for link 
					conn.QueryString = "Select * from VW_DE_PENGURUS_PERUSAHAAN where cu_ref='" + 
						Request.QueryString["curef"] + "' and seq=" + Convert.ToInt32(SEQ.Text);
					conn.ExecuteQuery();
					
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

					BTN_STOCKHOLDER.Visible = false;
					BTN_UPDATE_NEW.Visible = true;
					BTN_CANCEL.Visible = true;

					ZIP_CODE();

					BTN_STOCKHOLDER.Visible = false;
					BTN_UPDATE_NEW.Visible = true;
					BTN_CANCEL.Visible = true;
					break;
			}
		}

		protected void RDO_RFCUSTOMERTYPE_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			//--- Kalau Jenis Customer Badan Usaha, disable field berikut :
			//    - Key Person
			//    - WNA/WNI
			//    - Job Title
			//    - Pendidikan Akhir
			//    - Pengalaman			
			//----------------------------------------------------------------

			if (RDO_RFCUSTOMERTYPE.SelectedValue == "01")	//--- company / badan usaha
			{
				RDO_KEY_PERSON.Enabled			= false;
				RDO_KEY_PERSON.SelectedValue	= "0";	//by default TIDAK
				RDO_CS_NATSTAT0.Enabled			= false;
				RDO_CS_NATSTAT1.Enabled			= false;
				DDL_CS_JOBTITLE.Enabled			= false;
				DDL_CS_EDUCATION.Enabled		= false;
				DDL_CS_EXPERIENCE.Enabled		= false;	
				DDL_CS_HOMESTA.Enabled			= false;
			}
			else //--- perorangan
			{
				RDO_KEY_PERSON.Enabled		= true;
				RDO_CS_NATSTAT0.Enabled		= true;
				RDO_CS_NATSTAT1.Enabled		= true;
				DDL_CS_JOBTITLE.Enabled		= true;
				DDL_CS_EDUCATION.Enabled	= true;
				DDL_CS_EXPERIENCE.Enabled	= true;
				DDL_CS_HOMESTA.Enabled		= true;
			}
		}

		protected void TXT_CS_ZIPCODE_TextChanged(object sender, System.EventArgs e)
		{
			conn.QueryString = "select cityid, cityname, description from vw_zipcodecity where rtrim(ltrim(zipcode)) = '" + 
				TXT_CS_ZIPCODE.Text.Trim() + "' ";
			conn.ExecuteQuery();
			try
			{
				//LBL_CU_CITY.Text = conn.GetFieldValue(0,0);gfgf
				TXT_CS_CITY.Text = conn.GetFieldValue(0,2);
			}
			catch
			{
				TXT_CS_ZIPCODE.Text = "";
				GlobalTools.popMessage(this, "Invalid Zipcode!");
			}
		}

		protected void BTN_SEARCHCOMP_Click(object sender, System.EventArgs e)
		{
			Response.Write("<script language='javascript'>window.open('../InitialDataEntry/SearchZipcode.aspx?targetFormID=Form1&targetObjectID=TXT_CS_ZIPCODE','SearchZipcode','status=no,scrollbars=no,width=420,height=200');</script>");
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

		private void DatGrd_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
		
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
				conn.QueryString = "select sta = case when cu_ref='"+LBL_CUREF.Text+"' then 'true' else 'false' end "+
					"from bookedcust where aa_no='"+aa_no+"' ";
				conn.ExecuteQuery();
				int row = conn.GetRowCount();
				if (row>0)
				{
					if (conn.GetFieldValue(0,0)=="true")
					{
						if (TXT_STATUS.Text == "insert")
							conn.QueryString = "exec IN_BOOKEDPROD '"+aa_no+"', '"+
												DDL_AI_FACILITY.SelectedValue+"', '"+
												TXT_AI_NOREK.Text+"', "+
												tool.ConvertNum(TXT_AI_SEQ.Text)+", "+
												tool.ConvertFloat("00")+", '"+
												LBL_CUREF.Text+"', null, null, null, null, 0, null, null";
						else
							conn.QueryString = "exec IN_BOOKEDPROD '"+aa_no+"', '"+
												DDL_AI_FACILITY.SelectedValue+"', '"+
												TXT_AI_NOREK.Text+"', "+
												tool.ConvertNum(TXT_AI_SEQ.Text)+", "+
												tool.ConvertFloat("0")+", '"+
												LBL_CUREF.Text+"', null, null, null, null, 1, null, null";
						conn.ExecuteNonQuery();
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
						conn.QueryString = "exec IN_BOOKEDPROD '"+aa_no+"', '"+DDL_AI_FACILITY.SelectedValue+"', '"+TXT_AI_NOREK.Text+"', "+tool.ConvertNum(TXT_AI_SEQ.Text)+", "+tool.ConvertFloat("00")+", '"+LBL_CUREF.Text+"', null, null, null, null, 0, null, null";
					else
						conn.QueryString = "exec IN_BOOKEDPROD '"+aa_no+"', '"+DDL_AI_FACILITY.SelectedValue+"', '"+TXT_AI_NOREK.Text+"', "+tool.ConvertNum(TXT_AI_SEQ.Text)+", "+tool.ConvertFloat("0")+", '"+LBL_CUREF.Text+"', null, null, null, null, 1, null, null";
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


		protected void Button1_Click(object sender, System.EventArgs e)
		{
			TXT_STATUS.Text		= "insert";
			ClearItems();
			ChangeSta(true);
		}

		/***
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
		***/
	}
}
