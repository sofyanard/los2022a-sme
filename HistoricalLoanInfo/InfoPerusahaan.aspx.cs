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

namespace SME.HistoricalLoanInfo
{
	/// <summary>
	/// Summary description for InfoPerusahaan.
	/// </summary>
	public partial class InfoPerusahaan : System.Web.UI.Page
	{
		protected Connection conn;
		protected Tools tool = new Tools();
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			conn = (Connection) Session["Connection"];

            BTN_BACK.Click += new ImageClickEventHandler(BTN_BACK_Click);

			if (!Logic.AllowAccess(Session["GroupID"].ToString(), Request.QueryString["mc"], conn))
				Response.Redirect("/SME/Restricted.aspx");

			if (!IsPostBack) 
			{
				LBL_CUREF.Text = Request.QueryString["curef"];
				LBL_REGNO.Text = Request.QueryString["regno"];
				LBL_TC.Text = Request.QueryString["tc"];				

				GlobalTools.initDateForm(TXT_CS_DOB_DAY, DDL_CS_DOB_MONTH, TXT_CS_DOB_YEAR);
				GlobalTools.initDateForm(TXT_CI_BMGIRODAY, DDL_CI_BMGIROMONTH, TXT_CI_BMGIROYEAR);
				GlobalTools.initDateForm(TXT_CI_BMSAVINGDAY, DDL_CI_BMSAVINGMONTH, TXT_CI_BMSAVINGYEAR);
				GlobalTools.initDateForm(TXT_CI_BMDEBITURDAY, DDL_CI_BMDEBITURMONTH, TXT_CI_BMDEBITURYEAR);

				GlobalTools.fillRefList(DDL_CS_HOMESTA, "select HM_CODE, CD_SIBS + '-' + HM_DESC as HM_DESC from RFHOMESTA ", false, conn);
				GlobalTools.fillRefList(DDL_CS_EDUCATION, "select educationid, educationdesc from rfeducation ", false, conn);
				GlobalTools.fillRefList(DDL_CS_EXPERIENCE, "select expid, expdesc from rfexperience ", false, conn);
				GlobalTools.fillRefList(DDL_CS_JOBTITLE, "select JOBTITLEID, JOBTITLEDESC from RFJOBTITLE  order by JOBTITLEID", true, conn);

				//--- Stock Holder Type
				conn.QueryString = "select custtypeid, custtypedesc from rfcustomertype";
				conn.ExecuteQuery();
				for (int i = 0; i < conn.GetRowCount(); i++)
					RDO_RFCUSTOMERTYPE.Items.Add(new ListItem(conn.GetFieldValue(i,1), conn.GetFieldValue(i,0)));
				RDO_RFCUSTOMERTYPE.Items.Add(new ListItem("Lain-lain", "03"));	// Lain-lain


				GlobalTools.fillRefList(DDL_CS_SEX, "select sexid, sexdesc from rfsex ", false, conn);
				GlobalTools.fillRefList(DDL_CS_MARITAL, "select maritalid, maritaldesc from rfmarital ", false, conn);

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

				
				viewData();		// Company Info
				viewOB();		// Other Loan
				fillCSGrid();
				viewGrid();
				viewDataHolderAccount();
			}

			ViewMenu();
			viewSubMenu();
		}

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
		private void viewSubMenu() 
		{
			try 
			{
				conn.QueryString = "select * from SCREENSUBMENU where menucode = '"+Request.QueryString["mc"]+"'";
				conn.ExecuteQuery();

				for (int i = 0; i < conn.GetRowCount(); i++) 
				{
					HyperLink t = new HyperLink();
					t.Text = conn.GetFieldValue(i, "SM_MENUDISPLAY");
					t.Font.Bold = true;
					string strtemp = "";
					if (conn.GetFieldValue(i, "SM_LINKNAME").Trim()!= "") 
					{						
						if (conn.GetFieldValue(i,"SM_LINKNAME").IndexOf("mc=") >= 0)
							strtemp = "regno=" + Request.QueryString["regno"] + "&curef="+Request.QueryString["curef"]+"&tc="+Request.QueryString["tc"];
						else	
							strtemp = "regno=" + Request.QueryString["regno"] + "&curef="+Request.QueryString["curef"]+"&mc="+Request.QueryString["mc"]+"&tc="+Request.QueryString["tc"];

						if (conn.GetFieldValue(i,"SM_LINKNAME").IndexOf("?de=") < 0 && conn.GetFieldValue(i, "SM_LINKNAME").IndexOf("&de=") < 0) 
							strtemp = strtemp + "&de=" + Request.QueryString["de"];	

						if (conn.GetFieldValue(i,"SM_LINKNAME").IndexOf("?par=") < 0 && conn.GetFieldValue(i, "SM_LINKNAME").IndexOf("&par=") < 0)  
							strtemp = strtemp + "&par=" + Request.QueryString["par"];
					}
					else 
					{
						strtemp = "";
						t.ForeColor = Color.Red; 
					}
					t.NavigateUrl = conn.GetFieldValue(i, "SM_LINKNAME")+strtemp;					
					PH_SUBMENU.Controls.Add(t);
					PH_SUBMENU.Controls.Add(new LiteralControl("&nbsp;&nbsp;&nbsp;"));
				}
			} 
			catch (Exception ex) 
			{
				string temp = ex.ToString();
			}
		}

		private void viewData() 
		{
			conn.QueryString = "select * from BACKUP_COMPANY_INFO "+
				" where ap_regno = '"+ LBL_REGNO.Text +"' " ;
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

		private void viewOB() 
		{
//			conn.QueryString = "select * from VW_CUSTOTHERLOAN_HISTORY "+
//				" where CU_REF = '" + Request.QueryString["curef"] + "' " ;
//			conn.ExecuteQuery();
//			DataTable data = new DataTable();
//			data = conn.GetDataTable().Copy();
//			DGR_OB.DataSource = data;
//			DGR_OB.DataBind();
		}

		private void fillCSGrid() 
		{
			float totSaham = 0, temp = 0;
			
			DataTable dt = new DataTable();
			conn.QueryString = "select *, case isnull(CS_NATSTAT,'0') when '0' then 'WNI' when '1' then 'WNA' end as STATUS_DESC, case isnull(CS_KEYPERSON,'0') when '0' then 'TIDAK' when '1' then 'YA' end as CS_KEYPERSON from VW_CUST_STOCKHOLDER_HISTORY where ap_regno ='"+ LBL_REGNO.Text  + "'";
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
			LBL_TOTPERC.Text = totSaham.ToString("##,#0.00");
			TXT_CS_STOCKPERC.Text = totSaham.ToString("##,#0.00");
		}

		private void viewGrid() 
		{
			conn.QueryString = "select aa_no, productid, acc_no, acc_seq, limit, BC_LOANAMOUNT, convert(varchar,bc_tenor)+' '+tenordesc as tenor, bc_tenor, bc_tenorcode  "+
				"from VW_BOOKEDPROD_HISTORY a Left Join rftenorcode b on a.bc_tenorcode=b.tenorcode where cu_ref ='"+ LBL_CUREF.Text  +"'";																					  
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

		private void viewDataHolderAccount() 
		{
			conn.QueryString = "select * from VW_IDE_HOLDERACCOUNTLIST_HISTORY where AP_REGNO = '" + LBL_REGNO.Text + "'";
			conn.ExecuteQuery();
			
			DatGrdAccStockHolder.DataSource = conn.GetDataTable().DefaultView;
			try 
			{
				DatGrdAccStockHolder.DataBind();
			} 
			catch 
			{
				DatGrdAccStockHolder.CurrentPageIndex = 0;
				DatGrdAccStockHolder.DataBind();
			}
		}

		private void ZIP_CODE()
		{
			conn.QueryString = "select cityid, cityname, description from vw_zipcodecity where rtrim(ltrim(zipcode)) = '" + 
				TXT_CS_ZIPCODE.Text.Trim() + "' ";
			conn.ExecuteQuery();
			try
			{
				if (conn.GetRowCount() > 0 && conn.GetFieldValue(0,2) != "")
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

		}
		#endregion

		private void DatGridPengurus_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			switch (e.CommandName.ToString()) 
			{
				case "view":
					SEQ.Text  =  e.Item.Cells[1].Text;
					// This code for link 
					conn.QueryString = "Select * from VW_DE_PENGURUS_PERUSAHAAN_HISTORY where ap_regno='" + LBL_REGNO.Text  + 
						"' and SEQ = '" + SEQ.Text + "'";
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

					ZIP_CODE();
					break;
			}
		}

		protected void BTN_BACK_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			Response.Redirect("/SME/" + DMS.CuBESCore.Logic.backLink("", Request.QueryString["mc"], conn));
		}
	}
}
