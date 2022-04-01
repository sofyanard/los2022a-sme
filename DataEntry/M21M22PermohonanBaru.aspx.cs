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
using Microsoft.VisualBasic;
using Earmarking;

namespace SME.DataEntry
{
	/// <summary>
	/// Summary description for StrucCreditDetail. ARRRRGGGGHHHH! CAPEK!
	/// asdfjslakdfjakls;
	/// </summary>
	public partial class StrucCreditDetail : System.Web.UI.Page
	{
		protected Tools tool = new Tools();
		protected Connection conn;
		protected System.Web.UI.HtmlControls.HtmlInputText btn_ALT_PAY;
		//20070725 add by sofyan for alih debitur
		
		protected void Page_Load(object sender, System.EventArgs e)
		{
			conn = (Connection) Session["Connection"];
			//pipe line
			DatGrd.Visible=false;
			DDL_CL_ID.Visible=false;
			TXT_CL_DESC.Visible=false;
			TXT_LC_PERCENTAGE.Visible=false;
			TXT_LC_VALUE.Visible=false;
			TXT_ENDVALUE.Visible=false;
			calc.Visible=false;
			insert.Visible=false;
			//pipeline
			if(!IsPostBack)
			{
				GlobalTools.fillRefList(DDL_PROJECT_CODE, "select * from VW_RFPROJECT where ACTIVE = '1'", false, conn); 

				DDL_IDC_INTERESTTYPE.Items.Add(new ListItem("- PILIH -", ""));
				DDL_CP_PAYMENTID.Items.Add(new ListItem("- PILIH -", ""));
				conn.QueryString = "select itypeid, itypedesc from rfinteresttype";
				conn.ExecuteQuery();
				for (int i = 0; i < conn.GetRowCount(); i++)
					DDL_IDC_INTERESTTYPE.Items.Add(new ListItem(conn.GetFieldValue(i,1), conn.GetFieldValue(i,0)));
				
				LBL_APPTYPE.Text= Request.QueryString["apptype"];
				LBL_REGNO.Text	= Request.QueryString["regno"];
				LBL_CU_REF.Text = Request.QueryString["curef"];
				LBL_PRODID.Text	= Request.QueryString["prodid"];
				LBL_PROD_SEQ.Text = Request.QueryString["prod_seq"];
				LBL_KET_CODE.Text = Request.QueryString["ket_code"];

				conn.QueryString = "select revolving from rfproduct where productid='" + LBL_PRODID.Text + "'";
				conn.ExecuteQuery();
				if (conn.GetFieldValue(0,0) == "1")
					CHECK_IDC.Enabled = false;

				/* Validate Rekening Koran */
				conn.QueryString = "select calcmethod, confirmkoran from rfproduct where productid='" + LBL_PRODID.Text + "'";
				conn.ExecuteQuery();
				//if (conn.GetFieldValue("calcmethod") != "Daily")
				if ((conn.GetFieldValue("calcmethod") == "Daily") && (conn.GetFieldValue("confirmkoran") == "1"))
					CHK_CP_REVATACCT.Enabled = true;
				else
					CHK_CP_REVATACCT.Enabled = false;

				conn.QueryString = "select paymentid, paymentdesc from rfpaymentfreq where active='1'";
				conn.ExecuteQuery();
				for (int i = 0; i < conn.GetRowCount(); i++)
					DDL_CP_PAYMENTID.Items.Add(new ListItem(conn.GetFieldValue(i,1), conn.GetFieldValue(i,0)));

				conn.QueryString = "select cp_decsta from custproduct where ap_regno='" + Request.QueryString["regno"] + "'";
				conn.ExecuteQuery();
				try
				{
					if (conn.GetFieldValue(0,0) == "")
						LBL_DECSTA.Text = "0";
					else
						LBL_DECSTA.Text = "1";
				}
				catch
				{
					LBL_DECSTA.Text = "0";
				}

				//--- mengisi exchange rate secara otomatis
				viewExchangeRate();		

				isiddl();
				CalculateInstallment();
				viewdata();
	
				//20070725 add by sofyan for alih debitur
				viewdataalihdeb();

				isiGrid();
				CheckIDC();
				cekProductSupportForEbiz();
				viewIDC();
				SecureData();
                RetrievePundiRateOnPostBack();

				insert.Enabled = false;
				calc.Enabled = false;
			}

			if (LBL_DECSTA.Text == "0")
				CalculateInstallment();

			LBL_IDC_TENOR.Text = DDL_CP_TENORCODE.SelectedItem.Text;
			//TXT_CP_LIMIT.Text = tool.MoneyFormat(TXT_CP_LIMIT.Text);
			//TXT_CP_EXLIMITVAL.Text = tool.MoneyFormat(TXT_CP_EXLIMITVAL.Text);
			//update.Attributes.Add("onclick","if(!cek_mandatory(document.Form1)){return false;};");
            update.Attributes.Add("onclick", "if(!cek_mandatory(document.getElementById('Form1'))){return false;};");
			BTN_EBIZCARD.Attributes.Add("onclick", "javascript:PopupPage('eBizCardPola.aspx?regno=" + LBL_REGNO.Text + "&apptype=" + LBL_APPTYPE.Text + "&productid=" + LBL_PRODID.Text + "&prod_seq=" + LBL_PROD_SEQ.Text + "&de=1','1000','320');");

			//--- Define Events
			this.CHECK_IDC.CheckedChanged += new EventHandler(CHECK_IDC_CheckedChanged);
			this.DDL_IDC_INTERESTTYPE.SelectedIndexChanged += new EventHandler(DDL_IDC_INTERESTTYPE_SelectedIndexChanged);
			this.update.Click += new EventHandler(update_Click);
			this.DatGrd.DeleteCommand += new DataGridCommandEventHandler(DatGrd_DeleteCommand);
			this.DatGrd.PageIndexChanged +=new DataGridPageChangedEventHandler(DatGrd_PageIndexChanged);
			this.DDL_CL_ID.SelectedIndexChanged +=new EventHandler(DDL_CL_ID_SelectedIndexChanged);
			this.insert.Click += new EventHandler(insert_Click);
			this.calc.Click += new EventHandler(calc_Click);
			//20070725 add by sofyan for alih debitur
			this.CHK_ALIHDEB.CheckedChanged += new System.EventHandler(this.CHK_ALIHDEB_CheckedChanged);

            //PUNDI
            setDefault();
		}

        private void setDefault()
        {
            TXT_CP_EXRPLIMIT.Text = "1";
            TXT_CP_EXRPLIMIT.Enabled = true;
            TXT_CP_LIMIT.Enabled = true;
        }

		//20070313 add by sofyan for alih debitur
		private void viewdataalihdeb()
		{
			conn.QueryString = "exec DE_ALIHDEB_VIEW '"+ LBL_REGNO.Text +"', '"+ LBL_PRODID.Text +"', '"+LBL_APPTYPE.Text+"', '" + LBL_PROD_SEQ.Text + "'";
			conn.ExecuteQuery();
			
			if (conn.GetFieldValue("CP_ALIHDEBFLAG") == "1")
			{
				CHK_ALIHDEB.Checked = true;
				TR_OLDCIFNO.Visible = true;
				TXT_OLDCIFNO.Text = conn.GetFieldValue("CP_OLDCIFNO");
				TR_OLDACCNO.Visible = true;
				TXT_OLDACCNO.Text = conn.GetFieldValue("CP_OLDACCNO");
			}
			else
			{
				CHK_ALIHDEB.Checked = false;
				TR_OLDCIFNO.Visible = false;
				TR_OLDACCNO.Visible = false;
			}
		}
		
		//20070313 add by sofyan for alih debitur
		private void savealihdeb()
		{
			string alihdeb;
			if (CHK_ALIHDEB.Checked == true)
				alihdeb = "1";
			else
				alihdeb = "0";
			conn.QueryString = "exec DE_ALIHDEBITUR_SAVE '" + 
				LBL_REGNO.Text + "', '" + 
				LBL_PRODID.Text + "', '" +
				LBL_APPTYPE.Text + "', '" + 
				LBL_PROD_SEQ.Text + "', '" +
				alihdeb + "', '" +
				TXT_OLDCIFNO.Text + "', '" +
				TXT_OLDACCNO.Text + "'";
			conn.ExecuteNonQuery();
		}

		private void cekProductSupportForEbiz() 
		{
			try 
			{
				conn.QueryString = "select SUPPORTEBIZ from RFPRODUCT where PRODUCTID = '" + LBL_PRODID.Text + "'";
				conn.ExecuteQuery();

				if (conn.GetFieldValue("SUPPORTEBIZ") == "1") 
					BTN_EBIZCARD.Disabled = false;
				else
					BTN_EBIZCARD.Disabled = true;				
			} 
			catch (NullReferenceException) 
			{
				GlobalTools.popMessage(this, "Connection Error!");
				Response.Redirect("../Login.aspx?expire=1");
			}
		}

		private void viewExchangeRate() 
		{
			try 
			{
				conn.QueryString = "select PRODUCTID, CURRENCY, C.CURRENCYRATE " +
					"from RFPRODUCT p " +
					"left join RFCURRENCY c on P.CURRENCY = C.CURRENCYID " +
					"where C.ACTIVE = '1' and P.ACTIVE = '1' and PRODUCTID = '" + LBL_PRODID.Text + "'";
				conn.ExecuteQuery();

				TXT_CP_EXRPLIMIT.Text = conn.GetFieldValue("CURRENCYRATE");
			} 
			catch (NullReferenceException) 
			{
				Tools.popMessage(this, "Connection Error !");
				return;
			}
		}


		private void CheckIDC()
		{
			conn.QueryString = "select idc_flag, IDC_INTERESTTYPE from custproduct where ap_regno='" + LBL_REGNO.Text + "' and apptype='" + LBL_APPTYPE.Text + "' and productid='" + LBL_PRODID.Text + "' and prod_seq = '" + LBL_PROD_SEQ.Text + "'";
			conn.ExecuteQuery();

			if (conn.GetFieldValue(0,0) == "1")
			//if ((TXT_IDC_RATIO.Text != "") || (TXT_IDC_JWAKTU.Text != "") || (TXT_IDC_CAPRATIO.Text != "") || (TXT_IDC_CAPAMNT.Text != ""))
			{
				CHECK_IDC.Checked				= true;
				TR_IDC.Visible					= true;
				TXT_IDC_RATIO.CssClass			= "mandatory";
				TXT_IDC_JWAKTU.CssClass			= "mandatory";
				//TXT_IDC_CAPRATIO.CssClass		= "mandatory";
				//TXT_IDC_CAPRATIO.CssClass		= "mandatoryColor";
				TXT_IDC_CAPAMNT.CssClass		= "mandatory";
				TXT_IDC_PRIMEVARCODE.CssClass	= "mandatory";
				DDL_IDC_INTERESTTYPE.CssClass	= "mandatory";
				
				if (!conn.GetFieldValue("IDC_INTERESTTYPE").Equals(""))
				{
					DDL_IDC_INTERESTTYPE.SelectedValue = conn.GetFieldValue("IDC_INTERESTTYPE");
					if (conn.GetFieldValue("IDC_INTERESTTYPE") == "01")
					{
						TXT_IDC_PRIMEVARCODE.ReadOnly = true;
						DDL_IDC_VARCODE.Visible = true;
						TXT_IDC_VARIANCE.Visible = true;
					}
					else
					{
						TXT_IDC_PRIMEVARCODE.ReadOnly = false;
						DDL_IDC_VARCODE.Visible = false;
						TXT_IDC_VARIANCE.Visible = false;
					}
				}
				//viewIDC();
			}
		}

		private void SecureData() 
		{
			// Jika yang memanggil bukan dalam scope DataEntry, maka disable semua control input
			// Flag :asdfasd
			//		Nama  = de
			//		Value ==  1 --> Parent DataEntry
			//			  !=  1 --> Parent non-DataEntry

			

			string de = Request.QueryString["de"];
			if (de != "1") 
			{
				TXT_CP_EXLIMITVAL.ReadOnly		= true;
				TXT_CP_EXRPLIMIT.ReadOnly		= true;
				TXT_CP_INSTALLMENT.ReadOnly		= true;
				TXT_CP_JANGKAWKT.ReadOnly		= true;
				DDL_PROJECT_CODE.Enabled		= false;
				DDL_IDC_INTERESTTYPE.Enabled	= false;

				update.Visible					= false;
                BTN_Instalment.Visible          = false;
				DDL_CL_ID.Enabled				= false;
				DDL_CP_LOANPURPOSE.Enabled		= false;
				DDL_CP_TENORCODE.Enabled		= false;
				DDL_IDC_VARCODE.Enabled			= false;
				TXT_CP_KETERANGAN.ReadOnly		= true;
				insert.Visible					= false;
				CHECK_IDC.Enabled				= false;
				CHK_CP_REVATACCT.Enabled		= false;
				
				TXT_IDC_CAPAMNT.ReadOnly		= true;
				TXT_IDC_CAPRATIO.ReadOnly		= true;
				TXT_IDC_JWAKTU.ReadOnly			= true;
				TXT_IDC_PRIMEVARCODE.ReadOnly	= true;
				TXT_IDC_RATIO.ReadOnly			= true;
				TXT_IDC_VARIANCE.ReadOnly		= true;

				TXT_CP_GRACEPERIOD.ReadOnly = true;
				DDL_CP_PAYMENTID.Enabled = false;

				System.Web.UI.ControlCollection coll = this.Page.Controls;
				for (int i = 0; i < coll[3].Controls.Count; i++) 
				{
					if (coll[3].Controls[i] is TextBox) 
					{
						TextBox txt = (TextBox) coll[3].Controls[i];
						txt.ReadOnly = true;
					}
					else if (coll[3].Controls[i] is DropDownList) 
					{
						DropDownList ddl = (DropDownList) coll[3].Controls[i];
						ddl.Enabled = false;
					}
					else if (coll[3].Controls[i] is Button)
					{
						Button btn = (Button) coll[3].Controls[i];
						btn.Visible = false;
					}
					else if (coll[3].Controls[i] is RadioButtonList) 
					{
						RadioButtonList rbl = (RadioButtonList) coll[3].Controls[i];
						rbl.Enabled = false;
					}
					else if (coll[3].Controls[i] is RadioButton) 
					{
						RadioButton rb = (RadioButton) coll[3].Controls[i];
						rb.Enabled = false;
					}
					else if (coll[3].Controls[i] is CheckBox)
					{
						CheckBox cb = (CheckBox) coll[3].Controls[i];
						cb.Enabled = false;
					}					
					else if (coll[3].Controls[i] is DataGrid) 
					{						
						DataGrid dg = (DataGrid) coll[3].Controls[i];						
						//dg.Columns[6].Visible = false;
						for (int j = 0; j < dg.Items.Count; j++) 
						{
							dg.Items[j].Cells[6].Enabled = false;							
							dg.Items[j].Cells[6].Text = "Delete";
						}
					}
					else if (coll[3].Controls[i] is HtmlTableRow) 
					{
						HtmlTableRow htr = (HtmlTableRow) coll[3].Controls[i];

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

		private void CalculateInstallment()
		{
			double result = 0;

			conn.QueryString = "select calcmethod, isinstallment from rfproduct where productid='" + LBL_PRODID.Text + "'";
			conn.ExecuteQuery();
			try
			{
				if ((conn.GetFieldValue("isinstallment") == "1") /*&& (conn.GetFieldValue("calcmethod") == "Annuity")*/)
				{
					LBL_INSTALLMENT.Text = "Installment";
					result = DMS.CuBESCore.Logic.hitungInstalment(double.Parse(TXT_CP_EXLIMITVAL.Text), int.Parse(TXT_CP_JANGKAWKT.Text), double.Parse(LBL_INTEREST.Text), LBL_PRODID.Text, DDL_CP_TENORCODE.SelectedValue, conn);
					TXT_CP_INSTALLMENT.Text = tool.MoneyFormat(result.ToString());
				}
					/*
					{
						result = DMS.CuBESCore.Logic.hitungSkalaAngsuran(double.Parse(tool.ConvertNum(TXT_CP_LIMIT.Text)), int.Parse(TXT_CP_JANGKAWKT.Text), 1, double.Parse(LBL_INTEREST.Text));
						TXT_CP_INSTALLMENT.Text = tool.MoneyFormat(result.ToString());
					}
					else if ((conn.GetFieldValue("isinstallment") == "1") && (conn.GetFieldValue("calcmethod") == "Daily"))
					{
						result = DMS.CuBESCore.Logic.hitungSkalaAngsuran(double.Parse(tool.ConvertNum(TXT_CP_LIMIT.Text)), int.Parse(TXT_CP_JANGKAWKT.Text), double.Parse(LBL_INTEREST.Text), 1);
						TXT_CP_INSTALLMENT.Text = tool.MoneyFormat(result.ToString());
					}
					*/
				else if (conn.GetFieldValue("isinstallment") == "0")
				{
					LBL_INSTALLMENT.Text = "Bunga per bulan";
					//result = double.Parse(LBL_INTEREST.Text) / 100 * double.Parse(TXT_CP_EXLIMITVAL.Text) / 12;
					//TXT_CP_INSTALLMENT.Text = tool.MoneyFormat(result.ToString());
					TXT_CP_INSTALLMENT.Text = "-";
					TXT_CP_JANGKAWKT.AutoPostBack = false;
				}
			}
			catch
			{
			}
		}

		private void isiddl()
		{
			conn.QueryString = "select cu_ref from application where ap_regno='"+LBL_REGNO.Text+"'";
			conn.ExecuteQuery();
			LBL_CU_REF.Text	= conn.GetFieldValue("cu_ref");
			conn.ClearData();

			//--- Tujuan Penggunaan
			conn.QueryString="select LOANPURPID, LOANPURPID+ ' - ' +LOANPURPDESC as LOANPURPDESC from RFLOANPURPOSE where ACTIVE='1' order by LOANPURPID";			
			conn.ExecuteQuery();
			int row = conn.GetRowCount();
			DDL_CP_LOANPURPOSE.Items.Add(new ListItem("-- PILIH --",""));
			for (int i = 0; i<row; i++)
				DDL_CP_LOANPURPOSE.Items.Add(new ListItem(conn.GetFieldValue(i,1),conn.GetFieldValue(i,0)));
			conn.ClearData();
			
			SelectColl();

			DDL_CP_TENORCODE.Items.Add(new ListItem("- PILIH -", ""));
			conn.QueryString = "select tenorcode, tenordesc from rftenorcode where active='1'";
			conn.ExecuteQuery();
			for (int i = 0; i < conn.GetRowCount(); i++)
				DDL_CP_TENORCODE.Items.Add(new ListItem(conn.GetFieldValue(i,1), conn.GetFieldValue(i,0)));
		}

		private void SelectColl()
		{
			DDL_CL_ID.Items.Clear();
			/*
			conn.QueryString = "SELECT a.CL_SEQ, isnull(a.cl_desc,'')+' ('+a.COLTYPEDESC+')' as cl_desc FROM  VW_COLLATERAL1 a "+
				"WHERE a.cu_ref='"+LBL_CU_REF.Text+"' and (a.CL_SEQ NOT IN (SELECT b.cl_seq FROM listcollateral b "+
				"WHERE a.cl_seq = b.cl_seq and b.ap_regno='"+LBL_REGNO.Text+"' and b.productid='"+LBL_PRODID.Text+"'))";
			conn.ExecuteQuery();
			*/
			//20070117 changed by sofyan, replace with stored procedure below
			//utk mengatasi jika ada satu aplikasi yg productid-nya sama
			//conn.QueryString = "select DISTINCT cl.CL_SEQ, cl.CL_TYPE, ct.COLTYPEDESC, ct.COLLINKTABLE, cl.CL_DESC, "+
			//	"case isnull(lc.AP_REGNO,'') when '' then ca.AP_REGNO else lc.AP_REGNO end as AP_REGNO "+
			//	"from COLLATERAL cl join RFCOLLATERALTYPE ct on cl.CL_TYPE = ct.COLTYPESEQ "+
			//	"left join LISTCOLLATERAL lc on lc.CU_REF = cl.CU_REF and lc.CL_SEQ = cl.CL_SEQ "+
			//	"left join COLLATERAL_ADDDE ca on ca.CU_REF = cl.CU_REF and ca.CL_SEQ = cl.CL_SEQ "+
			//	"where (lc.AP_REGNO = '" + Request.QueryString["regno"] + "' or ca.AP_REGNO = '" + Request.QueryString["regno"] + "') " + 
			//	"and cl.cl_seq not in (select endi.cl_seq from listcollateral endi where ap_regno='" + Request.QueryString["regno"] + "' and productid='" + LBL_PRODID.Text + "')";
			conn.QueryString = "exec OBTAIN_EXISTING_COLLATERAL_LIST '" + LBL_CU_REF.Text + "', '" + LBL_REGNO.Text + "', '" + LBL_PRODID.Text + "', '" + LBL_KET_CODE.Text + "'";
			conn.ExecuteQuery();
			int row = conn.GetRowCount();
			DDL_CL_ID.Items.Add(new ListItem("- PILIH -", ""));
			string CLFILTER = "", KOMA = "";
			for (int i = 0;i < row;i++)
			{
				DDL_CL_ID.Items.Add(new ListItem(conn.GetFieldValue(i, "CL_DESC") + " (" + conn.GetFieldValue(i,2) + ")", conn.GetFieldValue(i,0)));
				if (conn.GetFieldValue(i,0).ToString().Trim() != "")
				{
					CLFILTER = CLFILTER + KOMA + conn.GetFieldValue(i,0).ToString().Trim();
					KOMA = ",";
				}
				//DDL_CL_ID.Items.Add(new ListItem(conn.GetFieldValue(i, 1), conn.GetFieldValue(i, 0)));dfd
			}
			string QuL = "";
			QuL	= "select CL_SEQ, CL_DESC, COLTYPEDESC from COLLATERAL cl "+
				  "left join RFCOLLATERALTYPE rf on cl.CL_TYPE = rf.COLTYPESEQ where isnull(SIBS_COLID,'') <> '' and CU_REF = (select CU_REF from APPLICATION where AP_REGNO = '"+Request.QueryString["regno"]+"') "+
				  "and cl.cl_seq not in (select endi.cl_seq from listcollateral endi where ap_regno='" + Request.QueryString["regno"] + "' and productid='" + LBL_PRODID.Text + "')";
			
			if (CLFILTER.Trim() != "")
			{
				CLFILTER = "(" +CLFILTER+")";
				QuL	= QuL	+ " and cl.cl_seq not in "+CLFILTER;
			}
			conn.QueryString = QuL;
			conn.ExecuteQuery();
			row = conn.GetRowCount();
			for (int i = 0;i < row;i++)
				DDL_CL_ID.Items.Add(new ListItem(conn.GetFieldValue(i, "CL_DESC") + " (" + conn.GetFieldValue(i,"COLTYPEDESC") + ")", conn.GetFieldValue(i,"CL_SEQ")));
			//conn.ClearData();
		}

		private void viewdata()
		{
			conn.QueryString="select * from VW_CUSTPRODUCT where ap_regno='"+ LBL_REGNO.Text +"' and productid='"+ LBL_PRODID.Text +"' and apptype='"+LBL_APPTYPE.Text+"' and PROD_SEQ = '" + LBL_PROD_SEQ.Text + "'";
			conn.ExecuteQuery();
			if (conn.GetFieldValue("CP_REVATACCT") == "1")
					CHK_CP_REVATACCT.Checked = true;
			else	CHK_CP_REVATACCT.Checked = false;
			TXT_APPTYPE.Text			= conn.GetFieldValue("APPTYPEDESC");
			TXT_PRODUCT.Text			= conn.GetFieldValue("PRODUCTDESC");
			TXT_CP_LIMIT.Text			= tool.MoneyFormat(conn.GetFieldValue("CP_LIMIT"));
			TXT_CP_INSTALLMENT.Text		= tool.MoneyFormat(conn.GetFieldValue("CP_installment"));
			if (TXT_CP_INSTALLMENT.Text == "0" || TXT_CP_INSTALLMENT.Text == "0,00")
				TXT_CP_INSTALLMENT.Text = "-";
			TXT_CP_EXRPLIMIT.Text		= tool.MoneyFormat(conn.GetFieldValue("CP_EXRPLIMIT"));
			TXT_CP_EXLIMITVAL.Text		= tool.MoneyFormat(conn.GetFieldValue("CP_EXLIMITVAL"));
			TXT_CP_KETERANGAN.Text		= conn.GetFieldValue("CP_KETERANGAN");
			TXT_CP_JANGKAWKT.Text		= conn.GetFieldValue("CP_JANGKAWKT");
			DDL_CP_TENORCODE.SelectedValue = conn.GetFieldValue("CP_TENORCODE");
			TXT_REVOLVING.Text			= conn.GetFieldValue("REVOLVING");
			TXT_CP_GRACEPERIOD.Text		= conn.GetFieldValue("CP_GRACEPERIOD");
			DDL_CP_PAYMENTID.SelectedValue = conn.GetFieldValue("CP_PAYMENTID");
			string CP_DECSTA			= conn.GetFieldValue("CP_DECSTA");
			string AD_VARCODE			= conn.GetFieldValue("AD_VARCODE");
			string AD_VARIANCE			= conn.GetFieldValue("AD_VARIANCE");
			string AD_RATENO			= conn.GetFieldValue("AD_RATENO");
			if (!conn.GetFieldValue("CP_LOANPURPOSE").Equals(""))
			{
				try{DDL_CP_LOANPURPOSE.SelectedValue = conn.GetFieldValue("CP_LOANPURPOSE");}
				catch{}
			}
			TXT_LC_VALUE.Text		= "0";
			TXT_LC_PERCENTAGE.Text	= "0";
			TXT_ENDVALUE.Text		= "0";
			TR_IDC.Visible			= false;
			LBL_PRODUCT.Text		= Request.QueryString["teks"];
			LBL_CP_LIMITAWAL.Text   = tool.MoneyFormat(conn.GetFieldValue("CP_LIMITAWAL"));
			try {DDL_PROJECT_CODE.SelectedValue = conn.GetFieldValue("PROJECT_CODE");}
			catch {DDL_PROJECT_CODE.SelectedValue = "";}

			conn.ClearData();

			/*
			conn.QueryString = "select sum(a.cp_limit) as tot_limit, exposure = case when c.LIMITEXPOSURE is null or c.LIMITEXPOSURE='' then sum(a.cp_limit) else "+
				"sum(a.cp_limit)+c.LIMITEXPOSURE end "+sdffsd
				"from cust_product a "+
				"inner join application b on a.ap_regno=b.ap_regno "+
				"inner join customer c on c.cu_ref=b.cu_ref "+
				"where a.ap_regno='"+LBL_REGNO.Text+"' group by a.ap_regno, c.LIMITEXPOSURE";
			*/
			/*
			conn.QueryString = "DE_TOTALEXPOSURE '" + LBL_REGNO.Text + "'";
			conn.ExecuteQuery();
			TXT_LIMITEXPOSURE.Text	= tool.MoneyFormat(conn.GetFieldValue("exposure"));
			TXT_SUMLIMIT.Text		= tool.MoneyFormat(conn.GetFieldValue("tot_limit"));
			*/

			conn.QueryString = "exec DE_CALCULATE_TOTALEXPOSURE '" + Request.QueryString["regno"] + "', '" + Request.QueryString["curef"] + "'";
			conn.ExecuteQuery(300);
			TXT_LIMITEXPOSURE.Text = tool.MoneyFormat(conn.GetFieldValue("GROUP_EXPOSURE"));
			TXT_SUMLIMIT.Text = tool.MoneyFormat(conn.GetFieldValue("tot_limit"));

			conn.ClearData();				

			conn.QueryString = "select interesttype from rfproduct where productid='" + LBL_PRODID.Text + "'";
			conn.ExecuteQuery();
			string interestType = conn.GetFieldValue(0,0);
			if (interestType == "01" || interestType == "03")
			{
				DDL_IDC_INTERESTTYPE.SelectedValue = interestType;
				TXT_IDC_PRIMEVARCODE.ReadOnly = true;
				DDL_IDC_VARCODE.Visible = true;
				TXT_IDC_VARIANCE.Visible = true;

				if (interestType == "03") 
				{
					LBL_INTERESTTYPE.Text = "Bunga / p.a: Floating (Alt Rate)";
				}
				else 
				{
					LBL_INTERESTTYPE.Text = "Bunga / p.a: Floating";
				}				
				conn.QueryString = "select * from vw_floatingrate where productid='" + LBL_PRODID.Text + "'";
				conn.ExecuteQuery();
				LBL_INTEREST.Text	= conn.GetFieldValue("rate");  
				//LBL_RATENO.Text = conn.GetFieldValue("rateno");  
				if (CP_DECSTA == "")
				{
					LBL_VARCODE.Text	= conn.GetFieldValue("varcode");  
					LBL_VARIANCE.Text	= conn.GetFieldValue("variance");
					LBL_RATENO.Text		= conn.GetFieldValue("rateno");  
				}
				else
				{
					LBL_VARCODE.Text	= AD_VARCODE;
					LBL_VARIANCE.Text	= AD_VARIANCE;
					LBL_RATENO.Text		= AD_RATENO;
				}
			}
			else
			{
				DDL_IDC_INTERESTTYPE.SelectedValue = interestType;
				TXT_IDC_PRIMEVARCODE.ReadOnly = false;
				DDL_IDC_VARCODE.Visible = false;
				TXT_IDC_VARIANCE.Visible = false;
				LBL_INTERESTTYPE.Text = "Bunga / p.a: Fix";
				conn.QueryString = "select interesttyperate from rfproduct where productid='" + LBL_PRODID.Text + "'";
				conn.ExecuteQuery();
				LBL_INTEREST.Text = conn.GetFieldValue("interesttyperate");
				LBL_VARIANCE.Visible = false;
				//TXT_CP_INTEREST.Visible = true;
			}
		}
		
		private void viewIDC()
		{
			conn.QueryString="select IDC_CAPAMNT, IDC_CAPRATIO, IDC_JWAKTU, "+
				"IDC_PRIMEVARCODE, IDC_RATIO, IDC_VARCODE, IDC_VARIANCE, IDC_FLAG, IDC_INTEREST, IDC_INTERESTTYPE from vw_custproduct_idc "+
				"where ap_regno='"+ LBL_REGNO.Text +"' and productid='"+ LBL_PRODID.Text +"' and apptype='"+LBL_APPTYPE.Text+"' and PROD_SEQ = '" + LBL_PROD_SEQ.Text + "'";
			conn.ExecuteQuery();
			TXT_IDC_CAPAMNT.Text		= GlobalTools.MoneyFormat(conn.GetFieldValue("IDC_CAPAMNT"));
			TXT_IDC_CAPRATIO.Text		= conn.GetFieldValue("IDC_CAPRATIO");
			TXT_IDC_JWAKTU.Text			= conn.GetFieldValue("IDC_JWAKTU");
			TXT_IDC_PRIMEVARCODE.Text   = LBL_INTEREST.Text;

			if (!conn.GetFieldValue("IDC_INTEREST").Equals(""))
				TXT_IDC_PRIMEVARCODE.Text = conn.GetFieldValue("IDC_INTEREST");
			

			//TXT_IDC_PRIMEVARCODE.Text	= conn.GetFieldValue("IDC_PRIMEVARCODE");
			//if (TXT_IDC_PRIMEVARCODE.Text.Trim() == "")
 
			if (!conn.GetFieldValue("IDC_VARCODE").Equals(""))
				DDL_IDC_VARCODE.SelectedValue	= conn.GetFieldValue("IDC_VARCODE");

			if (DDL_IDC_VARCODE.SelectedValue.Trim() == "")
				DDL_IDC_VARCODE.SelectedValue	= LBL_VARCODE.Text;
			
			TXT_IDC_VARIANCE.Text		= conn.GetFieldValue("IDC_VARIANCE");
			if (TXT_IDC_VARIANCE.Text.Trim() == "")
				TXT_IDC_VARIANCE.Text	= LBL_VARIANCE.Text;

			TXT_IDC_RATIO.Text			= conn.GetFieldValue("IDC_RATIO");
			conn.ClearData();
		}

		private void isiGrid()
		{
			DataTable dt = new DataTable();
			conn.QueryString="select a.ap_regno, a.cl_seq, a.productid,c.coltypedesc, a.lc_percentage, b.cl_value, lc_value, b.cl_desc, a.prod_seq " + 
				" from listcollateral a inner join collateral b on " +
				"a.cl_seq = b.cl_seq inner join rfcollateraltype c on b.cl_type = c.coltypeseq " +
				"inner join application d on a.ap_regno = d.ap_regno and b.cu_ref=d.cu_ref "+
				"where a.ap_regno = '" + LBL_REGNO.Text + 
				"' and a.productid='" + LBL_PRODID.Text + 
				"' and a.prod_seq = '" + LBL_PROD_SEQ.Text + "'";
			conn.ExecuteQuery();
			dt = conn.GetDataTable().Copy();
			DatGrd.DataSource = dt;
			try 
			{
				DatGrd.DataBind();
			} 
			catch 
			{
				DatGrd.CurrentPageIndex = 0;
				DatGrd.DataBind();
			}
			for (int i = 0; i < DatGrd.Items.Count; i++)
			{
				DatGrd.Items[i].Cells[4].Text = tool.MoneyFormat(DatGrd.Items[i].Cells[4].Text);
				DatGrd.Items[i].Cells[5].Text = tool.MoneyFormat(DatGrd.Items[i].Cells[5].Text);

				//-------- Screen Protection ----------------------sdfsad
				if (Request.QueryString["de"] != "1") 
				{
					DatGrd.Items[i].Cells[6].Text = "Delete";
					DatGrd.Items[i].Cells[6].Enabled = false;
				}
				//--------------------------------------------------
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
            if (!this.DesignMode)
            {
                //code here
            }
		}
		
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{    

		}
		#endregion

		private bool CheckIDCValidity()
		{
			string temp = "", temp2 = "";
			temp = tool.ConvertFloat(TXT_IDC_RATIO.Text);
			temp = temp.Replace(".", ",");
			if (TXT_IDC_JWAKTU.Text.Trim() == "")
				TXT_IDC_JWAKTU.Text = "0";
			if (float.Parse(temp) > 100)
			{
				Response.Write("<script language='javascript'>alert('Percentage over 100%');</script>");
				return false;
			}

			//
			// IDC a/c % Kapitalis mandatory, tidak boleh kosong, tapi boleh 0 (nol)
			//
			if (TXT_IDC_CAPRATIO.Text.Trim() == "") 
			{
				Response.Write("<script language='javascript'>alert('IDC a/c - % Kapitalis tidak boleh kosong!');</script>");
				return false;
			}

			temp = tool.ConvertFloat(TXT_IDC_CAPRATIO.Text);
			temp = temp.Replace(".", ",");
			if (float.Parse(temp) > 100)
			{
				Response.Write("<script language='javascript'>alert('Percentage over 100%');</script>");
				return false;
			}
			temp = tool.ConvertFloat(TXT_IDC_CAPAMNT.Text);
			temp = temp.Replace(".", ",");
			temp2 = tool.ConvertFloat(TXT_CP_EXLIMITVAL.Text);
			temp2 = temp2.Replace(".", ",");
			if (double.Parse(temp) > double.Parse(temp2))
			{
				Response.Write("<script language='javascript'>alert('IDC Plafond cannot be more than Main Plafond!');</script>");
				return false;
			}
			if (int.Parse(TXT_IDC_JWAKTU.Text) > int.Parse(TXT_CP_JANGKAWKT.Text))
			{
				Response.Write("<script language='javascript'>alert('IDC Loan Term cannot be more than Requested Loan Term!');</script>");
				return false;
			}
			return true;
		}

		private void update_Click(object sender, System.EventArgs e)
		{
			try
			{
				string revAtAcct = "0";
				if (CHK_CP_REVATACCT.Checked == true)
					revAtAcct = "1";
				if (CHECK_IDC.Checked==true)
				{	
					if (!CheckIDCValidity())
						return;

					if (TXT_CP_INSTALLMENT.Text == "-")
						TXT_CP_INSTALLMENT.Text = "0";

					conn.QueryString = "exec DE_STRUCCREDIT1 '"+LBL_REGNO.Text+"', '"+
						LBL_PRODID.Text+"', '"+LBL_APPTYPE.Text+"', "+
						tool.ConvertFloat(TXT_CP_INSTALLMENT.Text)+", "+tool.ConvertNum(TXT_CP_JANGKAWKT.Text)+", '"+
						DDL_CP_TENORCODE.SelectedValue+"' ,'"+ TXT_CP_KETERANGAN.Text +"', " +
						tool.ConvertFloat(TXT_IDC_RATIO.Text) +","+ tool.ConvertNum(TXT_IDC_JWAKTU.Text) +","+ 
						tool.ConvertFloat(TXT_IDC_CAPAMNT.Text)+","+tool.ConvertFloat(TXT_IDC_CAPRATIO.Text)+",'"+
						LBL_VARCODE.Text+"', "+tool.ConvertNull(DDL_CP_LOANPURPOSE.SelectedValue)+", "+
						tool.ConvertFloat(TXT_CP_EXLIMITVAL.Text)+", "+tool.ConvertFloat(TXT_CP_EXRPLIMIT.Text)+", "+
						tool.ConvertFloat(TXT_CP_LIMIT.Text)+", '', 0, "+
						""+tool.ConvertNull(LBL_VARCODE.Text)+", "+tool.ConvertNull(LBL_RATENO.Text)+", "+tool.ConvertFloat(LBL_VARIANCE.Text)+", "+
						""+tool.ConvertFloat(LBL_INTEREST.Text)+", "+tool.ConvertNull(DDL_IDC_VARCODE.SelectedValue)+", "+tool.ConvertFloat(TXT_IDC_VARIANCE.Text)+", "+
						//"1,0," + tool.ConvertFloat(TXT_IDC_PRIMEVARCODE.Text) + ", '" + DDL_IDC_INTERESTTYPE.SelectedValue + "', '" + revAtAcct + "'";dsdf
						"1,0," + tool.ConvertFloat(TXT_IDC_PRIMEVARCODE.Text) + ", '" + 
						DDL_IDC_INTERESTTYPE.SelectedValue + "', '" + 
						revAtAcct + "', null, " + 
						tool.ConvertNum(TXT_CP_GRACEPERIOD.Text) + ", " + 
						tool.ConvertNull(DDL_CP_PAYMENTID.SelectedValue) + ", '" + 
						LBL_PROD_SEQ.Text + "', " + 
						tool.ConvertNull(DDL_PROJECT_CODE.SelectedValue) + "";
					conn.ExecuteNonQuery();
				}
				else
				{
					conn.QueryString = "exec DE_STRUCCREDIT1 '"+LBL_REGNO.Text+"', '"+
						LBL_PRODID.Text+"', '"+LBL_APPTYPE.Text+"', "+
						tool.ConvertFloat(TXT_CP_INSTALLMENT.Text)+", "+tool.ConvertNum(TXT_CP_JANGKAWKT.Text)+", '"+
						DDL_CP_TENORCODE.SelectedValue+"' ,'"+ TXT_CP_KETERANGAN.Text +"', null, null, null, null,'"+
						LBL_VARCODE.Text+"', "+tool.ConvertNull(DDL_CP_LOANPURPOSE.SelectedValue)+", "+
						tool.ConvertFloat(TXT_CP_EXLIMITVAL.Text)+", "+tool.ConvertFloat(TXT_CP_EXRPLIMIT.Text)+", "+
						tool.ConvertFloat(TXT_CP_LIMIT.Text)+", '', 0, "+
						""+tool.ConvertNull(LBL_VARCODE.Text)+", "+tool.ConvertNull(LBL_RATENO.Text)+", "+tool.ConvertFloat(LBL_VARIANCE.Text)+", "+
						""+tool.ConvertFloat(LBL_INTEREST.Text)+", "+tool.ConvertNull(DDL_IDC_VARCODE.SelectedValue)+", "+tool.ConvertFloat(TXT_IDC_VARIANCE.Text)+", "+
						"0,0," + tool.ConvertFloat(TXT_IDC_PRIMEVARCODE.Text) + ", '" + 
						DDL_IDC_INTERESTTYPE.SelectedValue + "', '" + 
						revAtAcct + "', null, " + 
						tool.ConvertNum(TXT_CP_GRACEPERIOD.Text) + ", " + 
						tool.ConvertNull(DDL_CP_PAYMENTID.SelectedValue) + ", '" + 
						LBL_PROD_SEQ.Text + "', " + 
						tool.ConvertNull(DDL_PROJECT_CODE.SelectedValue) + "";
					conn.ExecuteNonQuery();
				}

				//20070725 add by sofyan for alih debitur
				savealihdeb();

				/////////////////////////////////////////////////////////
				///	Menghitung ulang Total Application Value dan
				///	Total Limit Exposure
				///	
				conn.QueryString = "DE_TOTALEXPOSURE '" + LBL_REGNO.Text + "'";
				conn.ExecuteQuery(300);
				TXT_LIMITEXPOSURE.Text	= tool.MoneyFormat(conn.GetFieldValue("exposure"));
				TXT_SUMLIMIT.Text		= tool.MoneyFormat(conn.GetFieldValue("tot_limit"));
				conn.ClearData();				

				updatePresetAlternateRate(); // method untuk mengecek validitas alternate rate hasil generation
				TR_STATUS.Visible = false;
			}
			catch (Exception ex)
			{
				string errmsg = ex.Message.Replace("'","");
				if (errmsg.IndexOf("Last Query:") > 0)
					errmsg = errmsg.Substring(0, errmsg.IndexOf("Last Query:"));
				labelStatus.Text = errmsg;
				TR_STATUS.Visible = true;
				return;
			}

            //CalculateRate();
		}

		/*
		 * Method ini memeriksa apakah terjadi perubahan tenor yang disimpan
		 * jika tenor diperbarui maka alternate rate yang digenerate harus dihapus
		 * dan selanjutnya akan digenerate ulang agar sesuai dengan tenor yang diperbarui
		 * Proses generate alternate rate terjadi ketika Ketentuan Link Ketentuan Kredit dimunculkan 
		 * */
		private void updatePresetAlternateRate()
		{
			try
			{
				//cek dulu syarat punya preset: ISNEGORATE == 0 dan INTERESTTYPE == 03
				conn.QueryString  = "select INTERESTTYPE, ISNEGORATE from RFPRODUCT ";
				conn.QueryString += "where PRODUCTID = '" + LBL_PRODID.Text.Trim() +"'";
				conn.ExecuteQuery();
				if (conn.GetRowCount() < 1) return; //jika tidak ada langsung break

				string interesttype	= conn.GetFieldValue("INTERESTTYPE");
				string isnegorate	= conn.GetFieldValue("ISNEGORATE");
				if (!((interesttype == "03") && (isnegorate == "0"))) return; // jika tidak memenuhi syarat preset rate, keluar

				// cek total tenor di tabel alternaterate
				conn.QueryString = "select sum(TENOR) as SUMTENOR from ALTERNATERATE where PRODUCTID = '" + LBL_PRODID.Text.Trim() + "'";
				conn.ExecuteQuery();
				int sumtenor = int.Parse(conn.GetFieldValue("SUMTENOR"));
				// cek tenor produk yang sekarang untuk dibandingkan
				int tenorproduk = int.Parse(TXT_CP_JANGKAWKT.Text.Trim());
				if (sumtenor == tenorproduk) return; // jika nilainya sama, tidak perlu ubah preset alt rate
				
				// jika ada perubahan nilai tenor/jangka waktu
				// hapus alternate rate yang digenerate sebelumnya
				// alternate rate akan digenerate ulang ketika menu struktur kredit dipilih
				conn.QueryString = "exec DE_ALTERNATE_RATE " +
					"'" + LBL_REGNO.Text.Trim() + 
					"', '" + LBL_PRODID.Text.Trim() + 
					"', " + LBL_PROD_SEQ.Text.Trim() + 
					", '0', 0, 0, 0, 0, '', 0, 0, '4'";
				conn.ExecuteNonQuery();
			} 
			catch {}
		}

		private void insert_Click(object sender, System.EventArgs e)
		{
			if(DDL_CL_ID.SelectedValue != "")
			{
				calc_Click(sender, e);

				float persen = 0;
				try { persen = float.Parse(TXT_LC_PERCENTAGE.Text); }
				catch {}
				if ( persen>0 && (persen<100 || persen == 100))
				{
					conn.QueryString = "exec SP_LISTCOLLPROCESS '"+LBL_REGNO.Text+"', '"+ LBL_APPTYPE.Text +"','"+ LBL_CU_REF.Text +"', '"+LBL_PRODID.Text+"', "+tool.ConvertNum(DDL_CL_ID.SelectedValue)+", "+tool.ConvertFloat(TXT_LC_PERCENTAGE.Text)+", "+tool.ConvertFloat(TXT_ENDVALUE.Text)+", '1', '" + LBL_PROD_SEQ.Text + "'";
					conn.ExecuteNonQuery();
				}
			}
			SelectColl();
			isiGrid();
			tidakisiCollateral();
			DDL_CL_ID.SelectedValue	= "";
			//Server.Transfer("M21M22PermohonanBaru.aspx?regno="+LBL_REGNO.Text+"&apptype="+LBL_APPTYPE.Text+"&prodid="+LBL_PRODID.Text+"&teks="+LBL_PRODUCT.Text+"de='1'");
		}

		private void DDL_CL_ID_SelectedIndexChanged(object sender, System.EventArgs e)
		{  
			

			conn.QueryString = "SELECT a.CL_VALUE, a.COLTYPEDESC FROM  VW_COLLATERAL1 a "+
				"WHERE a.cl_seq = '"+DDL_CL_ID.SelectedValue+"' and a.cu_ref='"+LBL_CU_REF.Text+"' and (a.CL_SEQ NOT IN (SELECT b.cl_seq FROM listcollateral b "+
				"WHERE a.cl_seq = b.cl_seq and b.ap_regno='"+LBL_REGNO.Text+"' and b.productid='"+LBL_PRODID.Text+"'))";
			conn.ExecuteQuery();
			int row = conn.GetRowCount();
			if (row > 0) 
			{
				TXT_LC_VALUE.Text	= tool.MoneyFormat(conn.GetFieldValue("CL_VALUE"));
				TXT_CL_DESC.Text	= conn.GetFieldValue("COLTYPEDESC"); 
				isiCollateral();
			}
			else
				tidakisiCollateral();
			conn.ClearData();
		}

		private void calc_Click(object sender, System.EventArgs e)
		{
			//conn.QueryString = "select persen from VW_PERCENTAGE_COL where cu_ref='"+LBL_CU_REF.Text+"' and cl_seq="+DDL_CL_ID.SelectedValue+"";
			conn.QueryString = "select persen from VW_PERCENTAGE_COL where ap_regno='" + LBL_REGNO.Text + "' and cl_seq="+DDL_CL_ID.SelectedValue+"";
			conn.ExecuteQuery();
			float batas		= float.Parse(conn.GetFieldValue("persen"));
			float persen	= float.Parse(TXT_LC_PERCENTAGE.Text);
			float hasil		= 0;
			if ((batas+persen)>100)
			{
				Tools.popMessage(this,"Penggunaan Collateral ini melebihi 100%");
				TXT_LC_PERCENTAGE.Text	= "0";
				Tools.SetFocus(this,TXT_LC_PERCENTAGE);
				TXT_LC_VALUE.Text	= tool.MoneyFormat(tool.ConvertFloat(TXT_LC_VALUE.Text));
			}
			else
			{
				string temp			= tool.ConvertFloat(TXT_LC_VALUE.Text);
				temp				= temp.Replace(".", ",");
				//float nilai			= tool.ConvertFloat(TXT_LC_VALUE.Text);
				float nilai			= float.Parse(temp);
				hasil				= (nilai * persen) / 100;
			}
			TXT_ENDVALUE.Text	= tool.MoneyFormat(hasil.ToString());
		}

		private void CHECK_IDC_CheckedChanged(object sender, System.EventArgs e)
		{
			if (CHECK_IDC.Checked ==true)
			{
				TR_IDC.Visible = true;
				//viewIDC();
				TXT_IDC_RATIO.CssClass			= "mandatory";
				TXT_IDC_JWAKTU.CssClass			= "mandatory";
				//TXT_IDC_CAPRATIO.CssClass		= "mandatory";
				//TXT_IDC_CAPRATIO.CssClass		= "mandatoryColor";
				TXT_IDC_CAPAMNT.CssClass		= "mandatory";
				TXT_IDC_PRIMEVARCODE.CssClass	= "mandatory";
				DDL_IDC_INTERESTTYPE.CssClass	= "mandatory";
			}
			else
			{
				TR_IDC.Visible = false;
				TXT_IDC_RATIO.CssClass = "";
				TXT_IDC_JWAKTU.CssClass = "";
				//TXT_IDC_CAPRATIO.CssClass = "";
				TXT_IDC_CAPAMNT.CssClass = "";
				TXT_IDC_PRIMEVARCODE.CssClass = "";
				DDL_IDC_INTERESTTYPE.CssClass = "";
			}

			// Kalau pilih Check IDC, default kosongkan semua field
			TXT_IDC_RATIO.Text					= "";
			TXT_IDC_JWAKTU.Text					= "";
			TXT_IDC_CAPRATIO.Text				= "";
			TXT_IDC_CAPAMNT.Text				= "";
			TXT_IDC_PRIMEVARCODE.Text			= "";
			DDL_IDC_INTERESTTYPE.SelectedValue	= "";
		}

		void isiCollateral()
		{
			TXT_LC_PERCENTAGE.ReadOnly	= false;
			TXT_LC_PERCENTAGE.Text		= "0";
			TXT_ENDVALUE.Text			= "0";
			insert.Enabled = true;
			calc.Enabled = true;
		}

		void tidakisiCollateral()
		{
			TXT_LC_VALUE.Text			= "0";
			TXT_LC_PERCENTAGE.Text		= "0";
			TXT_LC_PERCENTAGE.ReadOnly	= true;
			TXT_ENDVALUE.Text			= "0";
			TXT_CL_DESC.Text			= "";

			calc.Enabled = false;
			insert.Enabled = false;
		}

		private void DatGrd_DeleteCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			switch(((LinkButton)e.CommandSource).CommandName)
			{
				case "Delete":							
					/***
					 * Sebelum menghapus collateral, cek dulu apakah collateral itu sudah diassign atau belum
					 * Kalau sudah diassign, collateral tersebut tidak boleh dihapus
					 * */

					//-- added by YUDI
					//TODO : CHANGE THIS QUERY INTO STORED PROCEDURE
					/// LA_APPRSTATUS :
					/// 0 : Not Assign
					/// 4 : Appraisal done
					/// 6 & 7 : Incomplete Documents
					/// 
					conn.QueryString = "select count(*) as JUMLAH from LISTASSIGNMENT where AP_REGNO = '" + LBL_REGNO.Text + "'";
					conn.ExecuteQuery();

					if (conn.GetFieldValue("JUMLAH") != "0") 
					{
						/*
						conn.QueryString = "select count(*) as JUMLAH from LISTASSIGNMENT where AP_REGNO='"+ LBL_REGNO.Text +
							"' and cl_seq = " + int.Parse(e.Item.Cells[0].Text)+
							"  and (LA_APPRSTATUS ('0', '4', '6', '7'))";	//-- artinya not assigned yet
						//"  and LA_APPRSTATUS <> '3'";	//-- artinya sedang diappraised
						*/
						conn.QueryString = "exec DE_COLL_COUNTAPPRAISAL '" + LBL_REGNO.Text + "', '" + e.Item.Cells[0].Text + "'";
						conn.ExecuteQuery();
						//---

						if (Convert.ToInt16(conn.GetFieldValue("JUMLAH")) > 0) 
						{							
							conn.QueryString = "exec LISTCOLLATERAL_DELETE '" + 
								LBL_REGNO.Text + "', '" + 
								LBL_PRODID.Text + "', '" + 
								LBL_PROD_SEQ.Text + "', '" + 
								int.Parse(e.Item.Cells[0].Text) + "'";
							conn.ExecuteNonQuery();
						}
						else 
						{
							Tools.popMessage(this, "Collateral sedang di-appraise!");
						}
					}
					else 
					{
						conn.QueryString = "exec LISTCOLLATERAL_DELETE '" + 
							LBL_REGNO.Text + "', '" + 
							LBL_PRODID.Text + "', '" + 
							LBL_PROD_SEQ.Text + "', '" + 
							int.Parse(e.Item.Cells[0].Text) + "'";
						conn.ExecuteNonQuery();
					}

					break;
			}
			int index = DatGrd.Items.Count;
			
			int jml = (index % 3)-1;
			if (jml == 0)
				DatGrd.CurrentPageIndex = index/3;

			isiGrid();
			SelectColl();
			tidakisiCollateral();			
		}

		private void DatGrd_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			DatGrd.CurrentPageIndex = e.NewPageIndex;
			isiGrid();
		}

		private void DDL_IDC_INTERESTTYPE_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if (DDL_IDC_INTERESTTYPE.SelectedValue == "01")
			{
				TXT_IDC_PRIMEVARCODE.Text = LBL_INTEREST.Text;
				TXT_IDC_PRIMEVARCODE.ReadOnly = true;
				DDL_IDC_VARCODE.Visible = true;
				TXT_IDC_VARIANCE.Visible = true;
			}
			else
			{
				TXT_IDC_PRIMEVARCODE.ReadOnly = false;
				DDL_IDC_VARCODE.Visible = false;
				TXT_IDC_VARIANCE.Visible = false;
			}
		}

		//20070313 add by sofyan for alih debitur
		private void CHK_ALIHDEB_CheckedChanged(object sender, System.EventArgs e)
		{
			if (CHK_ALIHDEB.Checked == true)
			{
				TR_OLDCIFNO.Visible = true;
				TR_OLDACCNO.Visible = true;
			}
			else
			{
				TR_OLDCIFNO.Visible = false;
				TR_OLDACCNO.Visible = false;
			}
		}

        public void RetrievePundiRateOnPostBack()
        {
            TR_ANUITY_ISNTALMENT.Visible = false;

            /****************************************************************** RATE ************************************************************************/
            conn.QueryString = "SELECT RATE FROM RFRATENUMBER, RFPRODUCT WHERE RFPRODUCT.PRODUCTID = '" + LBL_PRODID.Text + "' AND RFPRODUCT.RATENO = RFRATENUMBER.RATENO";
            conn.ExecuteQuery();

            if (TXT_RATE.Text == "0" || TXT_RATE.Text == "" || TXT_RATE.Text == "0,00")
            {
                TXT_RATE.Text = (float.Parse(conn.GetFieldValue(0, 0))).ToString();
            }

            conn.QueryString = "SELECT CP_RATE, CP_FLAT_INSTALMENT, CP_ANUITY_INSTALMENT, CP_RATE_ANUITY FROM CUSTPRODUCT WHERE AP_REGNO = '" + LBL_REGNO.Text + "' AND APPTYPE = '" + LBL_APPTYPE.Text + "' AND PRODUCTID = '" + LBL_PRODID.Text + "' AND PROD_SEQ = '" + LBL_PROD_SEQ.Text + "'";
            conn.ExecuteQuery();

            try
            {
                float rate_chg = 0;
                if (FlatRate.Text == "0" || FlatRate.Text == "" || FlatRate.Text == "0,00")
                {
                    //20170515//FlatRate.Text = ((float.Parse(conn.GetFieldValue(0, 0)) * 100) / 12).ToString();
                    FlatRate.Text = ((float.Parse(conn.GetFieldValue(0, 0)) * 100)).ToString();
                }

                if (TXT_RATE_CHG.Text == "" || TXT_RATE_CHG.Text == "0" || TXT_RATE_CHG.Text == "0,00")
                {
                    if ((float.Parse(conn.GetFieldValue(0, 0)) * 100) > float.Parse(TXT_RATE.Text))
                    {
                        rate_chg = (float.Parse(conn.GetFieldValue(0, 0)) * 100) - float.Parse(TXT_RATE.Text);
                        DDL_Operator.SelectedValue = "+";
                    }
                    else
                    {
                        rate_chg = float.Parse(TXT_RATE.Text) - (float.Parse(conn.GetFieldValue(0, 0)) * 100);
                        DDL_Operator.SelectedValue = "-";
                    }
                    TXT_RATE_CHG.Text = rate_chg.ToString();
                }
            }
            catch
            {
                TXT_RATE_CHG.Text = "0";
            }

            try
            {
                if (TXT_ANN_INSTALMENT.Text == "" || TXT_ANN_INSTALMENT.Text == "0" || TXT_ANN_INSTALMENT.Text == "0,00")
                {
                    TXT_ANN_INSTALMENT.Text = (float.Parse(conn.GetFieldValue(0, 3)) * 100).ToString();
                }
            }
            catch
            {
                TXT_ANN_INSTALMENT.Text = "0";
            }
            /****************************************************************** END ************************************************************************/

            //jumlah angsuran
            if (TXT_FLAT_INSTALMENT.Text == "" || TXT_FLAT_INSTALMENT.Text == "0,00" || TXT_FLAT_INSTALMENT.Text == "0")
            {
                TXT_FLAT_INSTALMENT.Text = tool.MoneyFormat(conn.GetFieldValue(0, 1));
            }

            if (TXT_ANUITY_INSTALMENT.Text == "" || TXT_ANUITY_INSTALMENT.Text == "0,00" || TXT_ANUITY_INSTALMENT.Text == "0")
            {
                TXT_ANUITY_INSTALMENT.Text = tool.MoneyFormat(conn.GetFieldValue(0, 2));
            }
        }

        public void RetrievePundiRate()
        {
            TR_ANUITY_ISNTALMENT.Visible = false;

            /****************************************************************** RATE ************************************************************************/
            conn.QueryString = "SELECT RATE FROM RFRATENUMBER, RFPRODUCT WHERE RFPRODUCT.PRODUCTID = '" + LBL_PRODID.Text + "' AND RFPRODUCT.RATENO = RFRATENUMBER.RATENO";
            conn.ExecuteQuery();

            TXT_RATE.Text = (float.Parse(conn.GetFieldValue(0, 0))).ToString();

            conn.QueryString = "SELECT CP_RATE, CP_FLAT_INSTALMENT, CP_ANUITY_INSTALMENT, CP_RATE_ANUITY FROM CUSTPRODUCT WHERE AP_REGNO = '" + LBL_REGNO.Text + "' AND APPTYPE = '" + LBL_APPTYPE.Text + "' AND PRODUCTID = '" + LBL_PRODID.Text + "' AND PROD_SEQ = '" + LBL_PROD_SEQ.Text + "'";
            conn.ExecuteQuery();

            try
            {
                float rate_chg = 0;
                //20170515//FlatRate.Text = ((float.Parse(conn.GetFieldValue(0, 0)) * 100) / 12).ToString();
                FlatRate.Text = ((float.Parse(conn.GetFieldValue(0, 0)) * 100)).ToString();
                
                if ((float.Parse(conn.GetFieldValue(0, 0)) * 100) > float.Parse(TXT_RATE.Text))
                {
                    rate_chg = (float.Parse(conn.GetFieldValue(0, 0)) * 100) - float.Parse(TXT_RATE.Text);
                    DDL_Operator.SelectedValue = "+";
                }
                else
                {
                    rate_chg = float.Parse(TXT_RATE.Text) - (float.Parse(conn.GetFieldValue(0, 0)) * 100);
                    DDL_Operator.SelectedValue = "-";
                }
                TXT_RATE_CHG.Text = rate_chg.ToString();
            }
            catch
            {
                TXT_RATE_CHG.Text = "0";
            }

            try
            {
                TXT_ANN_INSTALMENT.Text = (float.Parse(conn.GetFieldValue(0, 3)) * 100).ToString();
            }
            catch
            {
                TXT_ANN_INSTALMENT.Text = "0";
            }
            /****************************************************************** END ************************************************************************/

            //jumlah angsuran
            TXT_FLAT_INSTALMENT.Text = tool.MoneyFormat(conn.GetFieldValue(0, 1));
            TXT_ANUITY_INSTALMENT.Text = tool.MoneyFormat(conn.GetFieldValue(0, 2));
        }

        private void CalculateRate()
        {
            try
            {

                //konversi yg dimasukin cuman FLAT RATE
                //20170515//float flatrate = float.Parse(FlatRate.Text) * 12;
                float flatrate = float.Parse(FlatRate.Text) / 100;
                //20170515//float hiddenTXT_RATE = float.Parse(TXT_RATE.Text);
                float hiddenTXT_RATE = float.Parse(TXT_RATE.Text);

                if (flatrate >= hiddenTXT_RATE)
                {
                    float selisih = flatrate - hiddenTXT_RATE;
                    //TXT_RATE.Text
                    //TXT_RATE_CHG.Text
                    //DDL_Operator.SelectedValue

                    DDL_Operator.SelectedValue = "+";
                    TXT_RATE_CHG.Text = selisih.ToString();
                }
                else
                {
                    float selisih = hiddenTXT_RATE - flatrate;

                    DDL_Operator.SelectedValue = "-";
                    TXT_RATE_CHG.Text = selisih.ToString();
                }

                //supaya selalu berhasil
                /*
                if ((float.Parse(TXT_RATE_CHG.Text) % 0.5) == 0)
                {
                    TXT_RATE_CHG.Text = (float.Parse(TXT_RATE_CHG.Text) + float.Parse("0,0001")).ToString();
                }
                */

                float tenor = 0;

                if (DDL_CP_TENORCODE.SelectedValue == "M")
                {
                    tenor = float.Parse(TXT_CP_JANGKAWKT.Text);
                }
                else if (DDL_CP_TENORCODE.SelectedValue == "D")
                {
                    tenor = float.Parse(TXT_CP_JANGKAWKT.Text) / 30;
                    tenor = float.Parse(Math.Round(tenor).ToString());
                }

                float TotalRate = 0;

                if (DDL_Operator.SelectedValue == "+")
                {
                    TotalRate = float.Parse(TXT_RATE.Text) + float.Parse(TXT_RATE_CHG.Text);
                }
                else
                {
                    float rate1 = float.Parse(TXT_RATE.Text);
                    float rate2 = float.Parse(TXT_RATE_CHG.Text);
                    TotalRate = rate1 - rate2;
                }
                //20170515//TotalRate = TotalRate / 100;
                TotalRate = TotalRate;

                //TotalRate dimasukin langsung ke field FlatRate

                float AngsuranPokok = float.Parse(TXT_CP_LIMIT.Text) / tenor;
                float AngsuranBunga = (float.Parse(TXT_CP_LIMIT.Text) * TotalRate) / tenor;
                float flat_installment = 0;

                flat_installment = (((float.Parse(TXT_CP_LIMIT.Text) * TotalRate) * (tenor / 12)) + float.Parse(TXT_CP_LIMIT.Text)) / tenor;

                //20170515//double ann_installment = -1 * Financial.Pmt(System.Convert.ToDouble(TotalRate / 12), System.Convert.ToDouble(tenor), System.Convert.ToDouble(TXT_CP_LIMIT.Text), 0, DueDate.EndOfPeriod);
                double ann_installment = -1 * Financial.Pmt(System.Convert.ToDouble(TotalRate), System.Convert.ToDouble(tenor), System.Convert.ToDouble(TXT_CP_LIMIT.Text), 0, DueDate.EndOfPeriod);

                TXT_FLAT_INSTALMENT.Text = tool.MoneyFormat(flat_installment.ToString());
                TXT_ANUITY_INSTALMENT.Text = tool.MoneyFormat(ann_installment.ToString());

                //konversi dari flat rate ke annuity rate
                //TXT_ANN_INSTALMENT

                double param1 = System.Convert.ToDouble(tenor);
                double param2 = System.Convert.ToDouble(TXT_FLAT_INSTALMENT.Text);
                double param3 = System.Convert.ToDouble(TXT_CP_LIMIT.Text);

                double rate = Financial.Rate(param1, -param2, param3);
                rate = (rate * 100) * 12;

                /*double usagePanels = 3.0;
                double rate = 3.17;

                double annRate = (Math.Pow((1 + rate / 100), usagePanels) * ((1 + rate / 100) - 1) / (Math.Pow(1 + rate / 100, (usagePanels)) - 1)) * 100;*/

                TXT_ANN_INSTALMENT.Text = rate.ToString();

                /*
                    CP_RATE
                    CP_FLAT_INSTALMENT
                    CP_ANUITY_INSTALMENT
                    CP_RATE_ANUITY
                 */

                string TotalRateString = "";
                string rateString = "";
                string TXT_FLAT_INSTALMENT_String = "";
                string TXT_ANN_INSTALMENT_String = "";

                if (TotalRate.ToString().EndsWith(",00"))
                {
                    TotalRate = TotalRate * 100;
                    TotalRateString = TotalRate.ToString().Remove(TotalRate.ToString().Length - 3).Replace(".", "");
                }
                else
                {
                    TotalRateString = TotalRate.ToString().Replace(".", "");
                }

                if (rate.ToString().EndsWith(",00"))
                {
                    rateString = (rate / 100).ToString().Remove(rate.ToString().Length - 3).Replace(".", "");
                }
                else
                {
                    rateString = (rate / 100).ToString().Replace(".", "");
                }

                if (TXT_FLAT_INSTALMENT.Text.ToString().EndsWith(",00"))
                {
                    TXT_FLAT_INSTALMENT_String = TXT_FLAT_INSTALMENT.Text.ToString().Remove(TXT_FLAT_INSTALMENT.Text.ToString().Length - 3).Replace(".", "");
                }
                else
                {
                    TXT_FLAT_INSTALMENT_String = TXT_FLAT_INSTALMENT.Text.ToString().Replace(".", "");
                }

                if (TXT_ANN_INSTALMENT.Text.ToString().EndsWith(",00"))
                {
                    TXT_ANN_INSTALMENT_String = TXT_ANUITY_INSTALMENT.Text.ToString().Remove(TXT_ANUITY_INSTALMENT.Text.ToString().Length - 3).Replace(".", "");
                }
                else
                {
                    TXT_ANN_INSTALMENT_String = TXT_ANUITY_INSTALMENT.Text.ToString().Replace(".", "");
                }

                conn.QueryString = "UPDATE CUSTPRODUCT SET CP_RATE = " + TotalRateString.Replace(",", ".") + ", CP_RATE_ANUITY = " + rateString.Replace(",", ".") + ", CP_FLAT_INSTALMENT = " + TXT_FLAT_INSTALMENT_String.Replace(",", ".") + ", CP_ANUITY_INSTALMENT = " + TXT_ANN_INSTALMENT_String.ToString().Replace(",", ".") + " WHERE AP_REGNO = '" + LBL_REGNO.Text + "' AND APPTYPE = '" + LBL_APPTYPE.Text + "' AND PRODUCTID = '" + LBL_PRODID.Text + "' AND PROD_SEQ = '" + LBL_PROD_SEQ.Text + "'";
                conn.ExecuteQuery();

                RetrievePundiRate();

                GlobalTools.popMessage(this, "Kalkulasi Berhasil !");
            }
            catch
            {
                Tools.popMessage(this, "Inputan tidak valid !");
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            CalculateRate();
        }
	}
}