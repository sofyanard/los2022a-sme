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
	/// Summary description for 
	/// </summary>
	public partial class M21M22PerubahanLimit : System.Web.UI.Page
	{
		protected Tools tools = new Tools();
		
		protected Connection conn;
		protected Tools tool = new Tools();
			
		protected void Page_Load(object sender, System.EventArgs e)
		{
			conn = (Connection) Session["Connection"];

			if(!IsPostBack)
			{
				LBL_REGNO.Text	= Request.QueryString["regno"];
				LBL_PRODID.Text	= Request.QueryString["prodid"];
				LBL_APPTYPE.Text= Request.QueryString["apptype"];
				LBL_PRODUCT.Text= Request.QueryString["teks"];
				LBL_PROD_SEQ.Text= Request.QueryString["PROD_SEQ"];
				LBL_KET_CODE.Text = Request.QueryString["ket_code"];

				//--- Tujuan Penggunaan
				conn.QueryString = "select LOANPURPID, LOANPURPID + ' - ' +LOANPURPDESC AS LOANPURPDESC from RFLOANPURPOSE where ACTIVE='1' order by LOANPURPID";			
				conn.ExecuteQuery();
				DDL_CP_LOANPURPOSE.Items.Add(new ListItem("-- PILIH --",""));
				for (int i = 0; i<conn.GetRowCount(); i++)
					DDL_CP_LOANPURPOSE.Items.Add(new ListItem(conn.GetFieldValue(i,1),conn.GetFieldValue(i,0)));
				conn.ClearData();
				
				DDL_CP_NOREK.Items.Add(new ListItem("- PILIH -", ""));
				isiddl();
				viewdata();			
				SecureData();
				//viewExchangeRate();
			}
			CalculateInstallment();
			TXT_CP_INSTALLMENT.Text = tool.MoneyFormat(TXT_CP_INSTALLMENT.Text);
			TXT_CP_LIMIT.Text		= tool.MoneyFormat(TXT_CP_LIMIT.Text);
			TXT_CP_EXRPLIMIT.Text	= tool.MoneyFormat(TXT_CP_EXRPLIMIT.Text);
			TXT_CP_EXLIMITVAL.Text	= tool.MoneyFormat(TXT_CP_EXLIMITVAL.Text);
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
				update.Visible	= false;
				TXT_AA_NO.ReadOnly = true;
				TXT_APPTYPE.ReadOnly = true;
				TXT_CP_CUREF.ReadOnly = true;
				TXT_CP_EXLIMITVAL.ReadOnly = true;
				TXT_CP_EXRPLIMIT.ReadOnly = true;
				TXT_CP_INSTALLMENT.ReadOnly  = true;
				TXT_CP_KETERANGAN.ReadOnly = true;
				DDL_CP_NOREK.Enabled = false;
				//DDL_PRODUCTID.Enabled = false;	
				TXT_PRODUCTID.Enabled = false;
				TXT_CP_LIMIT.ReadOnly = true;
				TXT_CP_LIMITCHGTO.ReadOnly = true;
				TXT_PRODUCT.ReadOnly = true;
				DDL_CP_LIMITCHG.Enabled = false;
				DDL_CP_LOANPURPOSE.Enabled = false;

				
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
			if ((conn.GetFieldValue("isinstallment") == "1") /*&& (conn.GetFieldValue("calcmethod") == "Annuity")*/)
			{
				LBL_INSTALLMENT.Text = "Installment";
				result = DMS.CuBESCore.Logic.hitungInstalment(double.Parse(TXT_CP_EXLIMITVAL.Text), int.Parse(TXT_NEWTENOR.Text), double.Parse(LBL_INTEREST.Text), LBL_PRODID.Text, "M", conn);
				TXT_CP_INSTALLMENT.Text = result.ToString();
			}
			else if (conn.GetFieldValue("isinstallment") == "0")
			{
				LBL_INSTALLMENT.Text = "Bunga per bulan";
				result = double.Parse(LBL_INTEREST.Text) / 100 * double.Parse(TXT_CP_EXLIMITVAL.Text) / 12;
				TXT_CP_INSTALLMENT.Text = result.ToString();
				//TXT_CP_INSTALLMENT.Text = "-";
				TXT_NEWTENOR.AutoPostBack = false;
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

		void isiddl()
		{
			conn.QueryString="select cu_ref from application where ap_regno='"+LBL_REGNO.Text+"'";	
            conn.ExecuteQuery();
			TXT_CP_CUREF.Text	= conn.GetFieldValue("cu_ref");
			
			/*
			conn.QueryString = "select b.aa_no+'#'+convert(varchar,b.acc_seq), b.acc_no "+
				"from bookedcust a "+sadf
				"inner join bookedprod b on a.aa_no=b.aa_no and a.productid=b.productid "+
                "where a.cu_ref='"+TXT_CP_CUREF.Text+"' and a.productid='"+LBL_PRODID.Text+"'";
			*/
			conn.QueryString = "select aa_no, acc_seq from custproduct where ap_regno='" +Request.QueryString["regno"] + "' and productid='" + Request.QueryString["prodid"] + "' and apptype='" + Request.QueryString["apptype"] + "' and prod_seq = '" + Request.QueryString["prod_seq"] + "'";
			conn.ExecuteQuery();
			TXT_AA_NO.Text = conn.GetFieldValue(0,0);
			DDL_CP_NOREK.Items.Add(new ListItem(conn.GetFieldValue("acc_seq"), conn.GetFieldValue("acc_seq")));
			DDL_CP_NOREK.SelectedValue = conn.GetFieldValue("acc_seq");

			/*
			conn.QueryString = "select distinct productid from bookedcust where cu_ref='" + TXT_CP_CUREF.Text + "' and aa_no='" + TXT_AA_NO.Text + "'";
			conn.ExecuteQuery();
			for (int i = 0; i < conn.GetRowCount(); i++)
				DDL_PRODUCTID.Items.Add(new ListItem(conn.GetFieldValue(i,0), conn.GetFieldValue(i,0)));

			DDL_PRODUCTID.SelectedValue = LBL_PRODID.Text;
			*/
			TXT_PRODUCTID.Text = LBL_PRODID.Text;
			
			/*
			DDL_CP_NOREK.Items.Add(new ListItem("-- PILIH --",0.ToString()));
			int row = conn.GetRowCount();
			for (int i = 0; i<row; i++)
				DDL_CP_NOREK.Items.Add(new ListItem(conn.GetFieldValue(i,1),conn.GetFieldValue(i,0)));
			conn.ClearData();
			*/

			conn.QueryString = "select LIMIT, TENOR, TENORCODE from bookedprod " +  
				"where aa_no='" + TXT_AA_NO.Text + "' and productid='" + LBL_PRODID.Text + "' and acc_seq='" + DDL_CP_NOREK.SelectedValue + "'";
			conn.ExecuteQuery();
			if (conn.GetRowCount() > 0)
			{
				TXT_CP_LIMITCHGTO.Text = tool.MoneyFormat(conn.GetFieldValue(0, "LIMIT"));
				TXT_NEWTENOR.Text = conn.GetFieldValue(0, "TENOR");
				LBL_NEWTENORCODE.Text = conn.GetFieldValue(0, "TENORCODE");
			}

		}
		/* Test */
		void viewdata()
		{
			conn.QueryString="select APPTYPEDESC, PRODUCTDESC, CP_LOANPURPOSE, "+
				"CP_LIMIT, CP_installment, CP_EXRPLIMIT, CP_EXLIMITVAL, CP_VARCODE, CP_RATENO, CP_VARIANCE, "+
				"CP_KETERANGAN, ACC_SEQ, CP_JANGKAWKT, CP_TENORCODE, REVOLVING, aa_no+'#'+convert(varchar,acc_seq) as seq "+
				", CP_DECSTA, AD_VARCODE, AD_VARIANCE, AD_RATENO, CP_LIMITCHG "+
				"from VW_CUSTPRODUCT "+
				"where ap_regno='"+ LBL_REGNO.Text +"' and productid='"+ LBL_PRODID.Text +"' and apptype='"+LBL_APPTYPE.Text+"' and PROD_SEQ = '" + LBL_PROD_SEQ.Text + "'";
			conn.ExecuteQuery();
			TXT_APPTYPE.Text				= conn.GetFieldValue("APPTYPEDESC");
			TXT_PRODUCT.Text				= conn.GetFieldValue("PRODUCTDESC");
			TXT_CP_LIMIT.Text			= conn.GetFieldValue("CP_LIMIT");
			TXT_CP_INSTALLMENT.Text		= conn.GetFieldValue("CP_installment");
			TXT_CP_EXRPLIMIT.Text		= conn.GetFieldValue("CP_EXRPLIMIT");
			TXT_CP_EXLIMITVAL.Text		= conn.GetFieldValue("CP_EXLIMITVAL");
			TXT_CP_KETERANGAN.Text		= conn.GetFieldValue("CP_KETERANGAN");
			try{DDL_CP_LIMITCHG.SelectedValue = conn.GetFieldValue("CP_LIMITCHG");}
			catch{}
			try{DDL_CP_LOANPURPOSE.SelectedValue = conn.GetFieldValue("CP_LOANPURPOSE");}
			catch{}
			string CP_DECSTA			= conn.GetFieldValue("CP_DECSTA");
			string AD_VARCODE			= conn.GetFieldValue("AD_VARCODE");
			string AD_VARIANCE			= conn.GetFieldValue("AD_VARIANCE");
			string AD_RATENO			= conn.GetFieldValue("AD_RATENO");
			for (int g=0; g<DDL_CP_NOREK.Items.Count; g++)
			{
				if (DDL_CP_NOREK.Items[g].Value.ToString()== conn.GetFieldValue("SEQ").ToString())
					DDL_CP_NOREK.SelectedValue		= conn.GetFieldValue("SEQ");				
			}
			conn.ClearData();

			/*
			conn.QueryString = "select * from vw_floatingrate where productid='" + LBL_PRODID.Text + "'";
			conn.ExecuteQuery();sdafadsf
			LBL_FLOATING.Text = conn.GetFieldValue("rate") + "% " + conn.GetFieldValue("varcode") + " " + conn.GetFieldValue("variance");
			*/

			conn.QueryString = "select interesttype, currency from rfproduct where productid='" + LBL_PRODID.Text + "'";
			conn.ExecuteQuery();
			
			LBL_CURR1.Text = conn.GetFieldValue("currency");
			LBL_CURR2.Text = conn.GetFieldValue("currency");
			LBL_CURR3.Text = conn.GetFieldValue("currency");

			if (conn.GetFieldValue(0,0) == "01")
			{
				LBL_INTERESTTYPE.Text = "Bunga / p.a: Floating";
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
				conn.QueryString = "select isnull(interesttyperate,0) as interesttyperate from rfproduct where productid='" + LBL_PRODID.Text + "'";
				conn.ExecuteQuery();
				LBL_INTEREST.Text = conn.GetFieldValue("interesttyperate");
				LBL_VARIANCE.Visible = false;
				//TXT_CP_INTEREST.Visible = true;
			}
		}

		protected void update_Click(object sender, System.EventArgs e)
		{
			//if (TXT_CP_INSTALLMENT.Text == "-")
			//	TXT_CP_INSTALLMENT.Text = "0";
			try
			{
				conn.QueryString = "exec DE_STRUCCREDIT1 '"+
					LBL_REGNO.Text+"', '"+
					LBL_PRODID.Text + "', '" + 
					LBL_APPTYPE.Text+"', "+
					tools.ConvertFloat(TXT_CP_INSTALLMENT.Text)+", "+
					tools.ConvertNum(TXT_NEWTENOR.Text)+", '"+
					LBL_NEWTENORCODE.Text+"' ,'"+  //asdfasdf
					TXT_CP_KETERANGAN.Text +"', " +
					"0" +","+ 
					"0" +","+ 
					"0" +","+
					"0"+",'"+
					"0"+"', '"+
					DDL_CP_LOANPURPOSE.SelectedValue+"', "+
					tool.ConvertFloat(TXT_CP_EXLIMITVAL.Text)+", "+
					tool.ConvertFloat(TXT_CP_EXRPLIMIT.Text)+", "+
					tool.ConvertFloat(TXT_CP_LIMIT.Text)+", '"+
					TXT_AA_NO.Text+"', "+
					DDL_CP_NOREK.SelectedValue+", "+
					""+tool.ConvertNull(LBL_VARCODE.Text)+", "+
					tool.ConvertNull(LBL_RATENO.Text)+", "+
					tool.ConvertFloat(LBL_VARIANCE.Text)+", "+
					""+tool.ConvertFloat(LBL_INTEREST.Text)+
					", "+
					"null"+", "+
					"null"+", "+
					"0,3, null, null, null, '" + 
					DDL_CP_LIMITCHG.SelectedValue + "', null, null, '" + 
					LBL_PROD_SEQ.Text + "'";
				conn.ExecuteNonQuery();
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

// asdfsadfasdf 
		protected void DDL_CP_NOREK_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			conn.QueryString = "select LIMIT from bookedprod " +  
				"where aa_no='" + TXT_AA_NO.Text + "' and productid='" + LBL_PRODID.Text + "' and acc_seq='" + DDL_CP_NOREK.SelectedValue + "'";
			conn.ExecuteQuery();
			if (conn.GetRowCount() > 0)
			{
				TXT_CP_LIMITCHGTO.Text = tool.MoneyFormat(conn.GetFieldValue(0, "LIMIT"));
			}
		}

		/*
		private void DDL_PRODUCTID_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			DDL_CP_NOREK.Items.Clear();
			DDL_CP_NOREK.Items.Add(new ListItem("- PILIH -", ""));
			conn.QueryString = "select acc_seq from bookedprod where aa_no='" + TXT_AA_NO.Text + "' and productid='" + DDL_PRODUCTID.SelectedValue + "'";
			conn.ExecuteQuery();
			for (int i = 0; i < conn.GetRowCount(); i++)
				//DDL_FACILITYNO.Items.Add(new ListItem(conn.GetFieldValue(i,1), conn.GetFieldValue(i,0)));asdfsadf
				DDL_CP_NOREK.Items.Add(new ListItem(conn.GetFieldValue(i,0), conn.GetFieldValue(i,0)));
			
			conn.QueryString = "select productdesc from rfproduct where productid='" + DDL_PRODUCTID.SelectedValue + "'";
			conn.ExecuteQuery();
			TXT_PRODUCT.Text = conn.GetFieldValue("productdesc");

			TXT_CP_LIMITCHGTO.Text = "";

		}
		*/
	}
}
