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
using DMS.DBConnection;
using DMS.CuBESCore;
using Microsoft.VisualBasic;

namespace SME.DataEntry
{
	/// <summary>
	/// Summary description for M21M22Pembaharuan.
	/// </summary>
	public partial class M21M22Pembaharuan : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.DataGrid DatGrd;
		protected System.Web.UI.WebControls.DropDownList DDL_CL_ID;
		protected System.Web.UI.WebControls.TextBox TXT_LC_PERCENTAGE;
		protected System.Web.UI.WebControls.TextBox TXT_LC_VALUE;
		protected System.Web.UI.WebControls.TextBox TXT_ENDVALUE;
		protected System.Web.UI.WebControls.Button insert;
		protected System.Web.UI.WebControls.TextBox TXT_CL_DESC;
		protected Tools tools = new Tools();
        protected Tools tool = new Tools();
		
		protected Connection conn;
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			conn = (Connection) Session["Connection"];

			if(!IsPostBack)
			{
				LBL_REGNO.Text	= Request.QueryString["regno"];
				LBL_PRODID.Text	= Request.QueryString["prodid"];
				LBL_APPTYPE.Text = Request.QueryString["apptype"];
				LBL_PROD_SEQ.Text = Request.QueryString["prod_seq"];

				isiddl();
				viewdata();	
				cekProductSupportForEbiz();
				SecureData();
			}

			BTN_EBIZCARD.Attributes.Add("onclick", "javascript:PopupPage('eBizCardPola.aspx?regno=" + LBL_REGNO.Text + "&apptype=" + LBL_APPTYPE.Text + "&productid=" + LBL_PRODID.Text + "&prod_seq=" + LBL_PROD_SEQ.Text + "&de=" + Request.QueryString["de"] + "','1000','320');");

			//--- Define Events
			this.RDO_TENORTYPE.SelectedIndexChanged += new EventHandler(RDO_TENORTYPE_SelectedIndexChanged);
			this.CHECK_IDC.CheckedChanged += new EventHandler(CHECK_IDC_CheckedChanged);
			this.update.Click += new EventHandler(update_Click);

            RetrievePundiRate();
		}

		#region Web Form Designer generated code
		override protected void OnInit(EventArgs e)
		{
				
				 //CODEGEN: This call is required by the ASP.NET Web Form Designer.
				
				InitializeComponent();
				base.OnInit(e);
		}
		
		///<summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{    

		}
		#endregion

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
				int index = -1;
				System.Web.UI.ControlCollection coll = this.Page.Controls;
				for(int j=0; j<coll.Count; j++) 
				{
					if (coll[j] is HtmlForm) 
					{
						index = j;
						break;
					}
				}

				if (index == -1) 
				{
					RDO_TENORTYPE.Enabled = false;
					TXT_NEWTENOR_DAY.ReadOnly = true;
					DDL_NEWTENOR.Enabled = false;
					TXT_NEWTENOR_YEAR.ReadOnly = true;					
					return;
				}

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
					else if (coll[index].Controls[i] is DataGrid) 
					{						
						DataGrid dg = (DataGrid) coll[index].Controls[i];						
						//dg.Columns[6].Visible = false;sadff
						for (int j = 0; j < dg.Items.Count; j++) 
						{
							dg.Items[j].Cells[6].Enabled = false;							
							dg.Items[j].Cells[6].Text = "Delete";
						}
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

		private void isiddl()
		{
			conn.QueryString = "select aa_no, cu_ref from application where ap_regno='"+LBL_REGNO.Text+"'";
			conn.ExecuteQuery();
			string aa_no		= conn.GetFieldValue("aa_no");
			TXT_CP_CUREF.Text	= conn.GetFieldValue("cu_ref");
			conn.ClearData();

			conn.QueryString = "select acc_seq, acc_no from BOOKEDPROD where productid='"+LBL_PRODID.Text+"' and aa_no='"+aa_no+"'";
			conn.ExecuteQuery();
			int row = conn.GetRowCount();
			DDL_CP_NOREK.Items.Add(new ListItem("-- PILIH --","0"));
			for (int i = 0; i<row; i++)
				DDL_CP_NOREK.Items.Add(new ListItem(conn.GetFieldValue(i,1),conn.GetFieldValue(i,0)));
			conn.ClearData();

			//--- Tujuan Penggunaan
			conn.QueryString = "select LOANPURPID, LOANPURPID + ' - ' +LOANPURPDESC AS LOANPURPDESC from RFLOANPURPOSE where ACTIVE='1' order by LOANPURPID";			
			conn.ExecuteQuery();
			row = conn.GetRowCount();
			DDL_CP_LOANPURPOSE.Items.Add(new ListItem("-- PILIH --",""));
			for (int i = 0; i<row; i++)
				DDL_CP_LOANPURPOSE.Items.Add(new ListItem(conn.GetFieldValue(i,1),conn.GetFieldValue(i,0)));
			conn.ClearData();
			
			DDL_NEWTENOR.Items.Add(new ListItem("-- PILIH --", ""));
			conn.QueryString = "select tenorcode, tenordesc from rftenorcode where active='1'";
			conn.ExecuteQuery();
			for (int i = 0; i < conn.GetRowCount(); i++)
				DDL_NEWTENOR.Items.Add(new ListItem(conn.GetFieldValue(i,1), conn.GetFieldValue(i,0)));

			//--- Maturity Date
			GlobalTools.initDateForm(TXT_NEWTENOR_DAY, DDL_NEWTENOR_MONTH, TXT_NEWTENOR_YEAR, true);

			//--- Project
			GlobalTools.fillRefList(DDL_PRJ_NAME, "select PRJ_CODE, PRJ_NAME from RFPROJECT where ACTIVE = '1'", false, conn);
		}

		private void viewdata()
		{
			conn.QueryString="select APPTYPEDESC, PRODUCTDESC, CP_LOANPURPOSE, "+
				"CP_LIMIT, CP_installment, AA_NO, ACC_SEQ, "+
				"CP_KETERANGAN, ACC_NO, CP_VARCODE, CP_RATENO, CP_VARIANCE, "+
				"REVOLVING, CURRENCY, NEWVALUE, NEWCODE, OLDVALUE, OLDCODE, b.tenordesc "+
				", CP_DECSTA, AD_VARCODE, AD_VARIANCE, AD_RATENO, CP_MATURITYDATE "+
				"from VW_CUSTPRODUCT a "+
				"left join RFTENORCODE B on B.TENORCODE=A.OLDCODE "+
				"where AP_REGNO='"+ LBL_REGNO.Text +"' and PRODUCTID='"+ LBL_PRODID.Text +"' and APPTYPE='"+ LBL_APPTYPE.Text +"' and PROD_SEQ = '" + LBL_PROD_SEQ.Text + "'";
			conn.ExecuteQuery();
			TXT_APPTYPE.Text		= conn.GetFieldValue("APPTYPEDESC");
			TXT_PRODUCT.Text		= conn.GetFieldValue("PRODUCTDESC");
			TXT_CP_INSTALLMENT.Text	= conn.GetFieldValue("CP_INSTALLMENT");
			TXT_CP_KETERANGAN.Text	= conn.GetFieldValue("CP_KETERANGAN");
			TXT_REVOLVING.Text		= conn.GetFieldValue("REVOLVING");
			LBL_CURRENCY.Text		= conn.GetFieldValue("CURRENCY");
			TXT_OLDTENOR.Text		= conn.GetFieldValue("OLDVALUE");
			TXT_NEWTENOR.Text		= conn.GetFieldValue("NEWVALUE");
			LBL_OLDTENOR.Text		= conn.GetFieldValue("TENORDESC");
			TXT_CP_NOREK.Text		= conn.GetFieldValue("ACC_NO");
			string CP_DECSTA		= conn.GetFieldValue("CP_DECSTA");
			string AD_VARCODE		= conn.GetFieldValue("AD_VARCODE");
			string AD_VARIANCE		= conn.GetFieldValue("AD_VARIANCE");
			string AD_RATENO		= conn.GetFieldValue("AD_RATENO");

			if (!conn.GetFieldValue("NEWCODE").Equals("")) DDL_NEWTENOR.SelectedValue	= conn.GetFieldValue("NEWCODE");
			if (!conn.GetFieldValue("CP_LOANPURPOSE").Equals("")) 
			{
				try{DDL_CP_LOANPURPOSE.SelectedValue = conn.GetFieldValue("CP_LOANPURPOSE");}
				catch{}
			}
			string seq = conn.GetFieldValue("ACC_SEQ");
			for (int g=0; g<DDL_CP_NOREK.Items.Count; g++) {
				if (DDL_CP_NOREK.Items[g].Value.ToString()== seq.ToString()) DDL_CP_NOREK.SelectedValue = seq;				
			}
			string AA_NO	= conn.GetFieldValue("AA_NO");
			string ACC_SEQ	= conn.GetFieldValue("ACC_SEQ");
			//jika loan berdasarkan maturity date ...
			if (!conn.GetFieldValue("CP_MATURITYDATE").Equals("")) 
			{
				//isi maturity date
				GlobalTools.fromSQLDate(conn.GetFieldValue("CP_MATURITYDATE"), TXT_NEWTENOR_DAY, DDL_NEWTENOR_MONTH, TXT_NEWTENOR_YEAR);
				RDO_TENORTYPE.SelectedValue = "0";

				//tentukan maturity date sebagai mandatory
				TXT_NEWTENOR_DAY.CssClass	= "mandatory";
				DDL_NEWTENOR_MONTH.CssClass = "mandatory";
				TXT_NEWTENOR_YEAR.CssClass	= "mandatory";
				TXT_NEWTENOR_DAY.Visible	= true;
				DDL_NEWTENOR_MONTH.Visible	= true;
				TXT_NEWTENOR_YEAR.Visible	= true;

				//hide tenor
				TXT_NEWTENOR.CssClass = "";
				DDL_NEWTENOR.CssClass = "";
				TXT_NEWTENOR.Visible	= false;
				DDL_NEWTENOR.Visible	= false;
			}
			conn.ClearData();

			//--- Mengambil project
			conn.QueryString = "select PROJECT_CODE from CUSTPRODUCT where AP_REGNO = '" + LBL_REGNO.Text + 
								"' and APPTYPE = '" + LBL_APPTYPE.Text + 
								"' and PRODUCTID = '" + LBL_PRODID.Text + 
								"' and PROD_SEQ = '" + LBL_PROD_SEQ.Text + "'";
			conn.ExecuteQuery();

			try {DDL_PRJ_NAME.SelectedValue = conn.GetFieldValue("PROJECT_CODE");} 
			catch {DDL_PRJ_NAME.SelectedValue = "";}

			//--- Mengambil limit
			conn.QueryString = "SELECT LIMIT FROM BOOKEDPROD WHERE AA_NO='"+AA_NO+"' AND ACC_SEQ="+tools.ConvertNum(ACC_SEQ)+" AND PRODUCTID='"+LBL_PRODID.Text+"'";
			conn.ExecuteQuery();
			TXT_CP_LIMIT.Text				= tools.MoneyFormat(conn.GetFieldValue("LIMIT"));
			TR_IDC.Visible					= false;
			LBL_PRODUCT.Text				= Request.QueryString["teks"];

			conn.ClearData();

			conn.QueryString = "select interesttype from rfproduct where productid='" + LBL_PRODID.Text + "'";
			conn.ExecuteQuery();
			if (conn.GetFieldValue(0,0) == "01" || conn.GetFieldValue(0,0) == "03")
			{
				if (conn.GetFieldValue(0,0) == "03") 
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
				LBL_INTERESTTYPE.Text = "Bunga / p.a: Fix";
				conn.QueryString = "select interesttyperate from rfproduct where productid='" + LBL_PRODID.Text + "'";
				conn.ExecuteQuery();
				LBL_INTEREST.Text = conn.GetFieldValue("interesttyperate");
				LBL_VARIANCE.Visible = false;
			}
		}

		private void CHECK_IDC_CheckedChanged(object sender, System.EventArgs e)
		{
			if (CHECK_IDC.Checked ==true)
			{
				TR_IDC.Visible = true;
				viewIDC();
			}
			else
				TR_IDC.Visible = false;
		}

		void viewIDC()
		{
			conn.QueryString="select IDC_CAPAMNT, IDC_CAPRATIO, IDC_JWAKTU, "+
				"IDC_PRIMEVARCODE, IDC_RATIO, IDC_VARCODE, IDC_VARIANCE from vw_custproduct_idc "+
				"where ap_regno='"+ LBL_REGNO.Text +"' and productid='"+ LBL_PRODID.Text +"' and apptype='"+LBL_APPTYPE.Text+"' and PROD_SEQ = '" + LBL_PROD_SEQ.Text + "'";
			conn.ExecuteQuery();
			TXT_IDC_CAPAMNT.Text		= conn.GetFieldValue("IDC_CAPAMNT");
			TXT_IDC_CAPRATIO.Text		= conn.GetFieldValue("IDC_CAPRATIO");
			TXT_IDC_JWAKTU.Text			= conn.GetFieldValue("IDC_JWAKTU");
			TXT_IDC_PRIMEVARCODE.Text	= conn.GetFieldValue("IDC_PRIMEVARCODE");
			if (!conn.GetFieldValue("IDC_VARCODE").Equals(""))
				DDL_IDC_VARCODE.SelectedValue	= conn.GetFieldValue("IDC_VARCODE");
			TXT_IDC_VARIANCE.Text		= conn.GetFieldValue("IDC_VARIANCE");
			TXT_IDC_RATIO.Text			= conn.GetFieldValue("IDC_RATIO");
			conn.ClearData();
		}

		private void update_Click(object sender, System.EventArgs e)
		{
			//--- validasi Maturity Date ---//
			if (RDO_TENORTYPE.SelectedValue != "1") 
			{
				try 
				{		
					conn.QueryString = "select " + 
						"nilai = case " + 
						"when convert(varchar, getdate(), 103) > " + GlobalTools.ToSQLDate(TXT_NEWTENOR_DAY.Text.Trim(), DDL_NEWTENOR_MONTH.SelectedValue, TXT_NEWTENOR_YEAR.Text.Trim()) + " " + 
						"then 'past' else 'future' end";
					conn.ExecuteQuery();

					if (conn.GetFieldValue("nilai") == "past") 
					{
						GlobalTools.popMessage(this, "Tanggal Maturity tidak boleh lebih dari Tanggal sekarang");
						return;
					}
				} 
				catch 
				{
					GlobalTools.popMessage(this, "Connection Error!");
					return;
				}
			}
			//------------------------------//


			try
			{
				if (CHECK_IDC.Checked==true)
				{
					if (RDO_TENORTYPE.SelectedValue == "1")	 // tenor
						conn.QueryString = "exec DE_STRUCCREDIT1 '"+LBL_REGNO.Text+"', '"+
							LBL_PRODID.Text+"', '"+LBL_APPTYPE.Text+"', "+
							tools.ConvertNum(TXT_CP_INSTALLMENT.Text)+", "+tools.ConvertNum(TXT_NEWTENOR.Text)+", '"+
							DDL_NEWTENOR.SelectedValue+"' ,'"+ TXT_CP_KETERANGAN.Text +"', " +
							tools.ConvertNum(TXT_IDC_RATIO.Text) +","+ tools.ConvertNum(TXT_IDC_JWAKTU.Text) +","+ 
							tools.ConvertNum(TXT_IDC_CAPAMNT.Text)+","+tools.ConvertNum(TXT_IDC_CAPRATIO.Text)+",'"+
							TXT_IDC_PRIMEVARCODE.Text+"', '" + DDL_CP_LOANPURPOSE.SelectedValue + "', 0, 0, 0, '', 0,"+
							""+tools.ConvertNull(LBL_VARCODE.Text)+", "+tools.ConvertNull(LBL_RATENO.Text)+", "+tools.ConvertFloat(LBL_VARIANCE.Text)+", "+
							""+tools.ConvertFloat(LBL_INTEREST.Text)+", "+tools.ConvertNull(DDL_IDC_VARCODE.SelectedValue)+", "+tools.ConvertNum(TXT_IDC_VARIANCE.Text)+", "+
							"1,4, null, null, null, null, null, null, '" + LBL_PROD_SEQ.Text + "'";
					else
						conn.QueryString = "exec DE_STRUCCREDIT2 '"+LBL_REGNO.Text+"', '"+
							LBL_PRODID.Text+"', '"+LBL_APPTYPE.Text+"', "+
							tools.ConvertNum(TXT_CP_INSTALLMENT.Text)+", "+						
							GlobalTools.ToSQLDate(TXT_NEWTENOR_DAY.Text.Trim(), DDL_NEWTENOR_MONTH.SelectedValue, TXT_NEWTENOR_YEAR.Text.Trim()) + ", '" +
							TXT_CP_KETERANGAN.Text +"', " +
							tools.ConvertNum(TXT_IDC_RATIO.Text) +","+ tools.ConvertNum(TXT_IDC_JWAKTU.Text) +","+ 
							tools.ConvertNum(TXT_IDC_CAPAMNT.Text)+","+tools.ConvertNum(TXT_IDC_CAPRATIO.Text)+",'"+
							TXT_IDC_PRIMEVARCODE.Text+"', '" + DDL_CP_LOANPURPOSE.SelectedValue + "', 0, 0, 0, '', 0,"+
							""+tools.ConvertNull(LBL_VARCODE.Text)+", "+tools.ConvertNull(LBL_RATENO.Text)+", "+tools.ConvertFloat(LBL_VARIANCE.Text)+", "+
							""+tools.ConvertFloat(LBL_INTEREST.Text)+", "+tools.ConvertNull(DDL_IDC_VARCODE.SelectedValue)+", "+tools.ConvertNum(TXT_IDC_VARIANCE.Text)+", "+
							"1,4, null, null, null, null, null, null, '" + LBL_PROD_SEQ.Text + "'";

					conn.ExecuteNonQuery();
				}
				else
				{
					if (RDO_TENORTYPE.SelectedValue == "1") // tenor
						conn.QueryString = "exec DE_STRUCCREDIT1 '"+LBL_REGNO.Text+"', '"+
							LBL_PRODID.Text+"', '"+LBL_APPTYPE.Text+"', "+
							tools.ConvertNum(TXT_CP_INSTALLMENT.Text)+", "+tools.ConvertNum(TXT_NEWTENOR.Text)+", '"+
							DDL_NEWTENOR.SelectedValue+"' ,'"+ TXT_CP_KETERANGAN.Text +"', " +
							tools.ConvertNum(TXT_IDC_RATIO.Text) +","+ tools.ConvertNum(TXT_IDC_JWAKTU.Text) +","+ 
							tools.ConvertNum(TXT_IDC_CAPAMNT.Text)+","+tools.ConvertNum(TXT_IDC_CAPRATIO.Text)+",'"+
							TXT_IDC_PRIMEVARCODE.Text+"', '" + DDL_CP_LOANPURPOSE.SelectedValue + "', 0, 0, 0, '', 0,"+
							""+tools.ConvertNull(LBL_VARCODE.Text)+", "+tools.ConvertNull(LBL_RATENO.Text)+", "+tools.ConvertFloat(LBL_VARIANCE.Text)+", "+
							""+tools.ConvertFloat(LBL_INTEREST.Text)+", "+tools.ConvertNull(DDL_IDC_VARCODE.SelectedValue)+", "+tools.ConvertNum(TXT_IDC_VARIANCE.Text)+", "+
							"0,4 , null, null, null, null, null, null, '" + LBL_PROD_SEQ.Text + "'";
					else
						conn.QueryString = "exec DE_STRUCCREDIT2 '"+LBL_REGNO.Text+"', '"+
							LBL_PRODID.Text+"', '"+LBL_APPTYPE.Text+"', "+
							tools.ConvertNum(TXT_CP_INSTALLMENT.Text)+", "+						
							GlobalTools.ToSQLDate(TXT_NEWTENOR_DAY.Text.Trim(), DDL_NEWTENOR_MONTH.SelectedValue, TXT_NEWTENOR_YEAR.Text.Trim()) + ", '" +
							TXT_CP_KETERANGAN.Text +"', " +
							tools.ConvertNum(TXT_IDC_RATIO.Text) +","+ tools.ConvertNum(TXT_IDC_JWAKTU.Text) +","+ 
							tools.ConvertNum(TXT_IDC_CAPAMNT.Text)+","+tools.ConvertNum(TXT_IDC_CAPRATIO.Text)+",'"+
							TXT_IDC_PRIMEVARCODE.Text+"', '" + DDL_CP_LOANPURPOSE.SelectedValue + "', 0, 0, 0, '', 0,"+
							""+tools.ConvertNull(LBL_VARCODE.Text)+", "+tools.ConvertNull(LBL_RATENO.Text)+", "+tools.ConvertFloat(LBL_VARIANCE.Text)+", "+
							""+tools.ConvertFloat(LBL_INTEREST.Text)+", "+tools.ConvertNull(DDL_IDC_VARCODE.SelectedValue)+", "+tools.ConvertNum(TXT_IDC_VARIANCE.Text)+", "+
							"0,4, null, null, null, null, null, null, '" + LBL_PROD_SEQ.Text + "'";
					conn.ExecuteNonQuery();
				}
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
		}

		private void RDO_TENORTYPE_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			TXT_NEWTENOR.Visible = false;
			DDL_NEWTENOR.Visible = false;
			TXT_NEWTENOR_DAY.Visible = false;
			DDL_NEWTENOR_MONTH.Visible = false;
			TXT_NEWTENOR_YEAR.Visible = false;

			TXT_NEWTENOR.CssClass = "";
			DDL_NEWTENOR.CssClass = "";
			TXT_NEWTENOR_DAY.CssClass = "";
			DDL_NEWTENOR_MONTH.CssClass = "";
			TXT_NEWTENOR_YEAR.CssClass = "";

			if (RDO_TENORTYPE.SelectedValue == "1")		// Days/Month
			{
				TXT_NEWTENOR.Visible = true;
				DDL_NEWTENOR.Visible = true;

				TXT_NEWTENOR.CssClass = "mandatory";
				DDL_NEWTENOR.CssClass = "mandatory";
			}
			else //Maturity Date
			{
				TXT_NEWTENOR_DAY.Visible = true;
				DDL_NEWTENOR_MONTH.Visible = true;
				TXT_NEWTENOR_YEAR.Visible = true;

				TXT_NEWTENOR_DAY.CssClass = "mandatory";
				DDL_NEWTENOR_MONTH.CssClass = "mandatory";
				TXT_NEWTENOR_YEAR.CssClass = "mandatory";
			}
		}

        public void RetrievePundiRate()
        {
            TR_ANUITY_ISNTALMENT.Visible = false;

            /****************************************************************** RATE ************************************************************************/
            conn.QueryString = "SELECT RATE FROM RFRATENUMBER, RFPRODUCT WHERE RFPRODUCT.PRODUCTID = '" + LBL_PRODID.Text + "' AND RFPRODUCT.RATENO = RFRATENUMBER.RATENO";
            conn.ExecuteQuery();

            TXT_RATE.Text = (float.Parse(conn.GetFieldValue(0, 0)) * 100).ToString();

            conn.QueryString = "SELECT CP_RATE, CP_FLAT_INSTALMENT, CP_ANUITY_INSTALMENT, CP_RATE_ANUITY FROM CUSTPRODUCT WHERE AP_REGNO = '" + LBL_REGNO.Text + "' AND APPTYPE = '" + LBL_APPTYPE.Text + "' AND PRODUCTID = '" + LBL_PRODID.Text + "' AND PROD_SEQ = '" + LBL_PROD_SEQ.Text + "'";
            conn.ExecuteQuery();

            try
            {
                float rate_chg = 0;

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
                FlatRate.Text = ((float.Parse(conn.GetFieldValue(0, 0)) * 100) / 12).ToString();
            }
            catch
            {
                FlatRate.Text = "0";
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
                float flatrate = float.Parse(FlatRate.Text) * 12;
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
                if ((float.Parse(TXT_RATE_CHG.Text) % 0.5) == 0)
                {
                    TXT_RATE_CHG.Text = (float.Parse(TXT_RATE_CHG.Text) + float.Parse("0,0001")).ToString();
                }

                float tenor = 0;

                if (DDL_NEWTENOR.SelectedValue == "M")
                {
                    tenor = float.Parse(TXT_NEWTENOR.Text);
                }
                else if (DDL_NEWTENOR.SelectedValue == "D")
                {
                    tenor = float.Parse(TXT_NEWTENOR.Text) / 30;
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
                TotalRate = TotalRate / 100;

                //TotalRate dimasukin langsung ke field FlatRate

                float AngsuranPokok = float.Parse(TXT_CP_LIMIT.Text) / tenor;
                float AngsuranBunga = (float.Parse(TXT_CP_LIMIT.Text) * TotalRate) / tenor;
                float flat_installment = 0;

                flat_installment = (((float.Parse(TXT_CP_LIMIT.Text) * TotalRate) * (tenor / 12)) + float.Parse(TXT_CP_LIMIT.Text)) / tenor;

                double ann_installment = -1 * Financial.Pmt(System.Convert.ToDouble(TotalRate / 12), System.Convert.ToDouble(tenor), System.Convert.ToDouble(TXT_CP_LIMIT.Text));

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
