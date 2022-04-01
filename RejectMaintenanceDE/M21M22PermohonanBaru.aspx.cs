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

namespace SME.RejectMaintenanceDE
{
	/// <summary>
	/// Summary description for StrucCreditDetail. 
	/// </summary>
	public partial class StrucCreditDetail : System.Web.UI.Page
	{
		protected Tools tool = new Tools();
		protected Connection conn;
		
		protected void Page_Load(object sender, System.EventArgs e)
		{
			conn = (Connection) Session["Connection"];

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
				//LBL_CU_REF.Text = Request.QueryString["curef"];
				LBL_PRODID.Text	= Request.QueryString["prodid"];
				LBL_PROD_SEQ.Text	= Request.QueryString["prod_seq"];

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

				isiddl();
				CalculateInstallment();
				viewdata();	
				isiGrid();
				CheckIDC();

				//20070725 add by sofyan for alih debitur
				viewdataalihdeb();
			}
			if (LBL_DECSTA.Text == "0")
				CalculateInstallment();

			LBL_IDC_TENOR.Text = DDL_CP_TENORCODE.SelectedItem.Text;
			TXT_CP_LIMIT.Text = tool.MoneyFormat(TXT_CP_LIMIT.Text);
			TXT_CP_EXLIMITVAL.Text = tool.MoneyFormat(TXT_CP_EXLIMITVAL.Text);
		}

		private void CheckIDC()
		{
			conn.QueryString = "select idc_flag, IDC_INTERESTTYPE from custproduct where ap_regno='" + LBL_REGNO.Text + 
								"' and apptype='" + LBL_APPTYPE.Text + 
								"' and productid='" + LBL_PRODID.Text + 
								"' and PROD_SEQ = '" + LBL_PROD_SEQ.Text + "'";
			conn.ExecuteQuery();

			if (conn.GetFieldValue(0,0) == "1")
			//if ((TXT_IDC_RATIO.Text != "") || (TXT_IDC_JWAKTU.Text != "") || (TXT_IDC_CAPRATIO.Text != "") || (TXT_IDC_CAPAMNT.Text != ""))
			{
				CHECK_IDC.Checked = true;
				TR_IDC.Visible = true;
				
				if (!conn.GetFieldValue("IDC_INTERESTTYPE").Equals(""))
				{
					try { DDL_IDC_INTERESTTYPE.SelectedValue = conn.GetFieldValue("IDC_INTERESTTYPE"); } catch {}
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
				viewIDC();
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
					result = DMS.CuBESCore.Logic.hitungInstalment(double.Parse(TXT_CP_EXLIMITVAL.Text), int.Parse(TXT_CP_JANGKAWKT.Text), double.Parse(TXT_INTEREST.Text), LBL_PRODID.Text, DDL_CP_TENORCODE.SelectedValue, conn);
					TXT_CP_INSTALLMENT.Text = tool.MoneyFormat(result.ToString());
				}
					/*
					{
						result = DMS.CuBESCore.Logic.hitungSkalaAngsuran(double.Parse(tool.ConvertNum(TXT_CP_LIMIT.Text)), int.Parse(TXT_CP_JANGKAWKT.Text), 1, double.Parse(TXT_INTEREST.Text));
						TXT_CP_INSTALLMENT.Text = tool.MoneyFormat(result.ToString());
					}
					else if ((conn.GetFieldValue("isinstallment") == "1") && (conn.GetFieldValue("calcmethod") == "Daily"))
					{
						result = DMS.CuBESCore.Logic.hitungSkalaAngsuran(double.Parse(tool.ConvertNum(TXT_CP_LIMIT.Text)), int.Parse(TXT_CP_JANGKAWKT.Text), double.Parse(TXT_INTEREST.Text), 1);
						TXT_CP_INSTALLMENT.Text = tool.MoneyFormat(result.ToString());
					}
					*/
				else if (conn.GetFieldValue("isinstallment") == "0")
				{
					LBL_INSTALLMENT.Text = "Bunga per bulan";
					//result = double.Parse(TXT_INTEREST.Text) / 100 * double.Parse(TXT_CP_EXLIMITVAL.Text) / 12;
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
			conn.QueryString="select LOANPURPID, LOANPURPID+' - '+LOANPURPDESC as LOANPURPDESC from RFLOANPURPOSE where ACTIVE='1' order by LOANPURPID";			
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
				"WHERE a.cu_ref='"+LBL_CU_REF.Text+"' and (a.CL_SEQ NOT IN (SELECT b.cl_seq FROM list-collateral b "+
				"WHERE a.cl_seq = b.cl_seq and b.ap_regno='"+LBL_REGNO.Text+"' and b.productid='"+LBL_PRODID.Text+"'))";
			conn.ExecuteQuery();
			*/
			conn.QueryString = "select DISTINCT cl.CL_SEQ, cl.CL_TYPE, ct.COLTYPEDESC, ct.COLLINKTABLE, cl.CL_DESC, "+
				"case isnull(lc.AP_REGNO,'') when '' then ca.AP_REGNO else lc.AP_REGNO end as AP_REGNO "+
				"from COLLATERAL cl join RFCOLLATERALTYPE ct on cl.CL_TYPE = ct.COLTYPESEQ "+
				"left join LISTCOLLATERAL lc on lc.CU_REF = cl.CU_REF and lc.CL_SEQ = cl.CL_SEQ "+
				"left join COLLATERAL_ADDDE ca on ca.CU_REF = cl.CU_REF and ca.CL_SEQ = cl.CL_SEQ "+
				"where (lc.AP_REGNO = '" + Request.QueryString["regno"] + "' or ca.AP_REGNO = '" + Request.QueryString["regno"] + "') " + 
				"and cl.cl_seq not in (select endi.cl_seq from listcollateral endi where ap_regno='" + Request.QueryString["regno"] + 
				"' and productid='" + LBL_PRODID.Text + "' and PROD_SEQ = '" + LBL_PROD_SEQ.Text + "')";
			conn.ExecuteQuery(600);
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
				  "and cl.cl_seq not in (select endi.cl_seq from listcollateral endi where ap_regno='" + Request.QueryString["regno"] + 
				  "' and productid='" + LBL_PRODID.Text + "' and prod_seq = '" + LBL_PROD_SEQ.Text + "')";
			
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
			conn.QueryString="select APPTYPEDESC, PRODUCTDESC, CP_LOANPURPOSE, CP_LIMIT, "+
				"CP_installment, CP_EXRPLIMIT, CP_EXLIMITVAL, CP_LIMITAWAL,CP_EXRPCOLL, "+
				"CP_EXCOLLVAL, CP_KETERANGAN, CP_JANGKAWKT, CP_TENORCODE, REVOLVING, "+
				"CP_VARCODE, CP_RATENO, CP_VARIANCE, PROJECT_CODE, "+
				"CP_DECSTA, AD_VARCODE, AD_VARIANCE, AD_RATENO, CP_REVATACCT, CP_GRACEPERIOD, CP_PAYMENTID "+
				"from VW_CUSTPRODUCT where ap_regno='"+ LBL_REGNO.Text +"' and productid='"+ LBL_PRODID.Text +"' and apptype='"+LBL_APPTYPE.Text+"' and PROD_SEQ = '" + LBL_PROD_SEQ.Text + "'";
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
			
			TXT_CP_EXLIMIT_AWAL.Text	= tool.MoneyFormat(conn.GetFieldValue("CP_LIMITAWAL"));
			TXT_CP_EXLIMITVAL.Text		= tool.MoneyFormat(conn.GetFieldValue("CP_EXLIMITVAL"));
			TXT_CP_KETERANGAN.Text		= conn.GetFieldValue("CP_KETERANGAN");
			TXT_CP_JANGKAWKT.Text		= conn.GetFieldValue("CP_JANGKAWKT");
			try { DDL_CP_TENORCODE.SelectedValue = conn.GetFieldValue("CP_TENORCODE"); } 
			catch {}
			TXT_REVOLVING.Text			= conn.GetFieldValue("REVOLVING");
			TXT_CP_GRACEPERIOD.Text		= conn.GetFieldValue("CP_GRACEPERIOD");
			try { DDL_CP_PAYMENTID.SelectedValue = conn.GetFieldValue("CP_PAYMENTID"); } 
			catch {}
			string CP_DECSTA			= conn.GetFieldValue("CP_DECSTA");
			string AD_VARCODE			= conn.GetFieldValue("AD_VARCODE");
			string AD_VARIANCE			= conn.GetFieldValue("AD_VARIANCE");
			string AD_RATENO			= conn.GetFieldValue("AD_RATENO");
			try 
			{
				if (!conn.GetFieldValue("CP_LOANPURPOSE").Equals(""))
					DDL_CP_LOANPURPOSE.SelectedValue = conn.GetFieldValue("CP_LOANPURPOSE");
			} 
			catch {}
			try {DDL_PROJECT_CODE.SelectedValue = conn.GetFieldValue("PROJECT_CODE");}
			catch {}

			conn.ClearData();
			TXT_LC_VALUE.Text		= "0";
			TXT_LC_PERCENTAGE.Text	= "0";
			TXT_ENDVALUE.Text		= "0";
			TR_IDC.Visible			= false;
			LBL_PRODUCT.Text		= Request.QueryString["teks"];
			/*
			conn.QueryString = "select sum(a.cp_limit) as tot_limit, exposure = case when c.LIMITEXPOSURE is null or c.LIMITEXPOSURE='' then sum(a.cp_limit) else "+
				"sum(a.cp_limit)+c.LIMITEXPOSURE end "+sdffsd
				"from cust_product a "+
				"inner join application b on a.ap_regno=b.ap_regno "+
				"inner join customer c on c.cu_ref=b.cu_ref "+
				"where a.ap_regno='"+LBL_REGNO.Text+"' group by a.ap_regno, c.LIMITEXPOSURE";
			*/
			conn.QueryString = "DE_TOTALEXPOSURE '" + LBL_REGNO.Text + "'";
			conn.ExecuteQuery(300);
			TXT_LIMITEXPOSURE.Text	= tool.MoneyFormat(conn.GetFieldValue("exposure"));
			TXT_SUMLIMIT.Text		= tool.MoneyFormat(conn.GetFieldValue("tot_limit"));
			conn.ClearData();				

			conn.QueryString = "select interesttype from rfproduct where productid='" + LBL_PRODID.Text + "'";
			conn.ExecuteQuery();
			string interestType = conn.GetFieldValue(0,0);
			if (interestType == "01" || interestType == "03")
			{
				try { DDL_IDC_INTERESTTYPE.SelectedValue = interestType; } 
				catch {}
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
				TXT_INTEREST.Text	= conn.GetFieldValue("rate");  
				//LBL_RATENO.Text = conn.GetFieldValue("rateno");  
				if (CP_DECSTA == "")
				{
					TXT_VARCODE.Text	= conn.GetFieldValue("varcode");  
					TXT_VARIANCE.Text	= conn.GetFieldValue("variance");
					LBL_RATENO.Text		= conn.GetFieldValue("rateno");  
				}
				else
				{
					TXT_VARCODE.Text	= AD_VARCODE;
					TXT_VARIANCE.Text	= AD_VARIANCE;
					LBL_RATENO.Text		= AD_RATENO;
				}
				LBL_INTERESTTYPE.Text = "Bunga / p.a: Floating";
			}
			else
			{
				try { DDL_IDC_INTERESTTYPE.SelectedValue = interestType; } 
				catch {}
				TXT_IDC_PRIMEVARCODE.ReadOnly = false;
				DDL_IDC_VARCODE.Visible = false;
				TXT_IDC_VARIANCE.Visible = false;
				LBL_INTERESTTYPE.Text = "Bunga / p.a: Fix";
				conn.QueryString = "select interesttyperate from rfproduct where productid='" + LBL_PRODID.Text + "'";
				conn.ExecuteQuery();
				TXT_INTEREST.Text = conn.GetFieldValue("interesttyperate");
				TXT_VARIANCE.Visible = false;
				TXT_VARCODE.Visible = false;
				//TXT_CP_INTEREST.Visible = true;
			}
		}
		
		private void viewIDC()
		{
			conn.QueryString="select IDC_CAPAMNT, IDC_CAPRATIO, IDC_JWAKTU, "+
				"IDC_PRIMEVARCODE, IDC_RATIO, IDC_VARCODE, IDC_VARIANCE, IDC_FLAG, IDC_INTEREST, IDC_INTERESTTYPE from vw_custproduct_idc "+
				"where ap_regno='"+ LBL_REGNO.Text +"' and productid='"+ LBL_PRODID.Text +"' and apptype='"+LBL_APPTYPE.Text+"' and PROD_SEQ = '" + LBL_PROD_SEQ.Text + "'";
			conn.ExecuteQuery();
			TXT_IDC_CAPAMNT.Text		= conn.GetFieldValue("IDC_CAPAMNT");
			TXT_IDC_CAPRATIO.Text		= conn.GetFieldValue("IDC_CAPRATIO");
			TXT_IDC_JWAKTU.Text			= conn.GetFieldValue("IDC_JWAKTU");
			TXT_IDC_PRIMEVARCODE.Text   = TXT_INTEREST.Text;

			if (!conn.GetFieldValue("IDC_INTEREST").Equals(""))
				TXT_IDC_PRIMEVARCODE.Text = conn.GetFieldValue("IDC_INTEREST");
			

			//TXT_IDC_PRIMEVARCODE.Text	= conn.GetFieldValue("IDC_PRIMEVARCODE");
			//if (TXT_IDC_PRIMEVARCODE.Text.Trim() == "")
 
			if (!conn.GetFieldValue("IDC_VARCODE").Equals(""))
				try { DDL_IDC_VARCODE.SelectedValue	= conn.GetFieldValue("IDC_VARCODE"); } 
				catch {}

			if (DDL_IDC_VARCODE.SelectedValue.Trim() == "")
				try { DDL_IDC_VARCODE.SelectedValue	= TXT_VARCODE.Text; } 
				catch {}
			
			TXT_IDC_VARIANCE.Text		= conn.GetFieldValue("IDC_VARIANCE");
			if (TXT_IDC_VARIANCE.Text.Trim() == "")
				TXT_IDC_VARIANCE.Text	= TXT_VARIANCE.Text;

			TXT_IDC_RATIO.Text			= conn.GetFieldValue("IDC_RATIO");
			conn.ClearData();
		}

		private void isiGrid()
		{
			DataTable dt = new DataTable();
			conn.QueryString="select a.ap_regno, a.cl_seq, a.productid,c.coltypedesc, a.lc_percentage, b.cl_value, lc_value, b.cl_desc from listcollateral a inner join collateral b on " +
				"a.cl_seq = b.cl_seq inner join rfcollateraltype c on b.cl_type = c.coltypeseq " +
				"inner join application d on a.ap_regno = d.ap_regno and b.cu_ref=d.cu_ref "+
				"where a.ap_regno = '"+LBL_REGNO.Text+"' and a.productid='"+ LBL_PRODID.Text+
				"' and a.PROD_SEQ = '" + LBL_PROD_SEQ.Text + "'";
			conn.ExecuteQuery();
			dt = conn.GetDataTable().Copy();
			DatGrd.DataSource = dt;
			DatGrd.DataBind();
			for (int i = 0; i < DatGrd.Items.Count; i++)
			{
				DatGrd.Items[i].Cells[4].Text = tool.MoneyFormat(DatGrd.Items[i].Cells[4].Text);
				DatGrd.Items[i].Cells[5].Text = tool.MoneyFormat(DatGrd.Items[i].Cells[5].Text);
			}
		}

		//20070725 add by sofyan for alih debitur
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

		//20070725 add by sofyan for alih debitur
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
			this.DatGrd.ItemCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.DatGrd_DeleteCommand);
			this.DatGrd.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.DatGrd_PageIndexChanged);

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

		protected void update_Click(object sender, System.EventArgs e)
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

				conn.QueryString = "exec DE_STRUCCREDIT1_AD '"+LBL_REGNO.Text+"', '"+
					LBL_PRODID.Text+"', '"+LBL_APPTYPE.Text+"', "+
					tool.ConvertFloat(TXT_CP_INSTALLMENT.Text)+", "+tool.ConvertNum(TXT_CP_JANGKAWKT.Text)+", '"+
					DDL_CP_TENORCODE.SelectedValue+"' ,'"+ TXT_CP_KETERANGAN.Text +"', " +
					tool.ConvertFloat(TXT_IDC_RATIO.Text) +","+ tool.ConvertNum(TXT_IDC_JWAKTU.Text) +","+ 
					tool.ConvertFloat(TXT_IDC_CAPAMNT.Text)+","+tool.ConvertFloat(TXT_IDC_CAPRATIO.Text)+",'"+
					TXT_VARCODE.Text+"', "+tool.ConvertNull(DDL_CP_LOANPURPOSE.SelectedValue)+", "+
					tool.ConvertFloat(TXT_CP_EXLIMITVAL.Text)+", "+tool.ConvertFloat(TXT_CP_EXRPLIMIT.Text)+", "+
					tool.ConvertFloat(TXT_CP_LIMIT.Text)+", '', 0, "+
					""+tool.ConvertNull(TXT_VARCODE.Text)+", "+tool.ConvertNull(LBL_RATENO.Text)+", "+tool.ConvertFloat(TXT_VARIANCE.Text)+", "+
					""+tool.ConvertFloat(TXT_INTEREST.Text)+", "+tool.ConvertNull(DDL_IDC_VARCODE.SelectedValue)+", "+tool.ConvertFloat(TXT_IDC_VARIANCE.Text)+", "+
					//"1,0," + tool.ConvertFloat(TXT_IDC_PRIMEVARCODE.Text) + ", '" + DDL_IDC_INTERESTTYPE.SelectedValue + "', '" + revAtAcct + "'";dsdf
					"1,0," + tool.ConvertFloat(TXT_IDC_PRIMEVARCODE.Text) + ", '" + DDL_IDC_INTERESTTYPE.SelectedValue + "', '" + revAtAcct + "', null, " +
					tool.ConvertNum(TXT_CP_GRACEPERIOD.Text) + ", " + tool.ConvertNull(DDL_CP_PAYMENTID.SelectedValue) + ", '" + 
					LBL_PROD_SEQ.Text + "', " + 
					tool.ConvertNull(DDL_PROJECT_CODE.SelectedValue) + "";
				conn.ExecuteNonQuery();
			}
			else
			{
				conn.QueryString = "exec DE_STRUCCREDIT1_AD '"+LBL_REGNO.Text+"', '"+
					LBL_PRODID.Text+"', '"+LBL_APPTYPE.Text+"', "+
					tool.ConvertFloat(TXT_CP_INSTALLMENT.Text)+", "+tool.ConvertNum(TXT_CP_JANGKAWKT.Text)+", '"+
					DDL_CP_TENORCODE.SelectedValue+"' ,'"+ TXT_CP_KETERANGAN.Text +"', " +
					tool.ConvertFloat(TXT_IDC_RATIO.Text) +","+ tool.ConvertNum(TXT_IDC_JWAKTU.Text) +","+ 
					tool.ConvertFloat(TXT_IDC_CAPAMNT.Text)+","+tool.ConvertFloat(TXT_IDC_CAPRATIO.Text)+",'"+
					TXT_VARCODE.Text+"', "+tool.ConvertNull(DDL_CP_LOANPURPOSE.SelectedValue)+", "+
					tool.ConvertFloat(TXT_CP_EXLIMITVAL.Text)+", "+tool.ConvertFloat(TXT_CP_EXRPLIMIT.Text)+", "+
					tool.ConvertFloat(TXT_CP_LIMIT.Text)+", '', 0, "+
					""+tool.ConvertNull(TXT_VARCODE.Text)+", "+tool.ConvertNull(LBL_RATENO.Text)+", "+tool.ConvertFloat(TXT_VARIANCE.Text)+", "+
					""+tool.ConvertFloat(TXT_INTEREST.Text)+", "+tool.ConvertNull(DDL_IDC_VARCODE.SelectedValue)+", "+tool.ConvertFloat(TXT_IDC_VARIANCE.Text)+", "+
					//"0,0," + tool.ConvertFloat(TXT_IDC_PRIMEVARCODE.Text) + ", '" + DDL_IDC_INTERESTTYPE.SelectedValue + "', '" + revAtAcct + "'";df
					"0,0," + tool.ConvertFloat(TXT_IDC_PRIMEVARCODE.Text) + ", '" + DDL_IDC_INTERESTTYPE.SelectedValue + "', '" + revAtAcct + "', null, " +
					tool.ConvertNum(TXT_CP_GRACEPERIOD.Text) + ", " + tool.ConvertNull(DDL_CP_PAYMENTID.SelectedValue) + ", '" + 
					LBL_PROD_SEQ.Text + "', " + 
					tool.ConvertNull(DDL_PROJECT_CODE.SelectedValue) + "";
				conn.ExecuteNonQuery();
			}			

			/////////////////////////////////////////////////////////
			///	Menghitung ulang Total Application Value dan
			///	Total Limit Exposure
			///	
			conn.QueryString = "DE_TOTALEXPOSURE '" + LBL_REGNO.Text + "'";
			conn.ExecuteQuery(300);
			TXT_LIMITEXPOSURE.Text	= tool.MoneyFormat(conn.GetFieldValue("exposure"));
			TXT_SUMLIMIT.Text		= tool.MoneyFormat(conn.GetFieldValue("tot_limit"));
			conn.ClearData();

			//20070725 add by sofyan for alih debitur
			savealihdeb();
		}

		protected void insert_Click(object sender, System.EventArgs e)
		{
			if(DDL_CL_ID.SelectedValue != "")
			{
				float persen = float.Parse(TXT_LC_PERCENTAGE.Text);
				if ( persen>0 && (persen<100 || persen == 100))
				{
					conn.QueryString = "exec SP_LISTCOLLPROCESS '"+LBL_REGNO.Text+"', '"+ LBL_APPTYPE.Text +"','"+ LBL_CU_REF.Text +"', '"+LBL_PRODID.Text+"', "+tool.ConvertNum(DDL_CL_ID.SelectedValue)+", "+TXT_LC_PERCENTAGE.Text+", "+tool.ConvertFloat(TXT_ENDVALUE.Text)+", '1', '" + LBL_PROD_SEQ.Text + "'";
					conn.ExecuteNonQuery();
				}
			}
			SelectColl();
			isiGrid();
			tidakisiCollateral();
			DDL_CL_ID.SelectedValue	= "";
			//Server.Transfer("M21M22PermohonanBaru.aspx?regno="+LBL_REGNO.Text+"&apptype="+LBL_APPTYPE.Text+"&prodid="+LBL_PRODID.Text+"&teks="+LBL_PRODUCT.Text+"de='1'");
		}

		protected void DDL_CL_ID_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			conn.QueryString = "SELECT a.CL_VALUE, a.COLTYPEDESC FROM  VW_COLLATERAL1 a "+
				"WHERE a.cl_seq = "+DDL_CL_ID.SelectedValue+" and a.cu_ref='"+LBL_CU_REF.Text+"' and (a.CL_SEQ NOT IN (SELECT b.cl_seq FROM listcollateral b "+
				"WHERE a.cl_seq = b.cl_seq and b.ap_regno='"+LBL_REGNO.Text+"' and b.productid='"+LBL_PRODID.Text+
				"' and b.PROD_SEQ = '" + LBL_PROD_SEQ.Text + "'))";
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

		protected void TXT_LC_PERCENTAGE_TextChanged(object sender, System.EventArgs e)
		{
			conn.QueryString = "select persen from VW_PERCENTAGE_COL where cu_ref='"+LBL_CU_REF.Text+"' and cl_seq="+DDL_CL_ID.SelectedValue+"";
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

		protected void CHECK_IDC_CheckedChanged(object sender, System.EventArgs e)
		{
			if (CHECK_IDC.Checked ==true)
			{
				TR_IDC.Visible = true;
				viewIDC();
				TXT_IDC_RATIO.CssClass = "mandatory";
				TXT_IDC_JWAKTU.CssClass = "mandatory";
				TXT_IDC_CAPRATIO.CssClass = "mandatory";
				TXT_IDC_CAPAMNT.CssClass = "mandatory";
				TXT_IDC_PRIMEVARCODE.CssClass = "mandatory";
				DDL_IDC_INTERESTTYPE.CssClass = "mandatory";
			}
			else
			{
				TR_IDC.Visible = false;
				TXT_IDC_RATIO.CssClass = "";
				TXT_IDC_JWAKTU.CssClass = "";
				TXT_IDC_CAPRATIO.CssClass = "";
				TXT_IDC_CAPAMNT.CssClass = "";
				TXT_IDC_PRIMEVARCODE.CssClass = "";
				DDL_IDC_INTERESTTYPE.CssClass = "";
			}
		}

		void isiCollateral()
		{
			TXT_LC_PERCENTAGE.ReadOnly	= false;
			TXT_LC_PERCENTAGE.Text		= "0";
			TXT_ENDVALUE.Text			= "0";
		}

		void tidakisiCollateral()
		{
			TXT_LC_VALUE.Text			= "0";
			TXT_LC_PERCENTAGE.Text		= "0";
			TXT_LC_PERCENTAGE.ReadOnly	= true;
			TXT_ENDVALUE.Text			= "0";
			TXT_CL_DESC.Text			= "";
		}

		private void DatGrd_DeleteCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			switch(((LinkButton)e.CommandSource).CommandName)
			{
				case "Delete":								
					conn.QueryString="delete from listcollateral where ap_regno='"+ LBL_REGNO.Text +
									"' and productid='"+ LBL_PRODID.Text +
									"' and PROD_SEQ = '" + LBL_PROD_SEQ.Text + "' "+
									" and cl_seq ="+int.Parse(e.Item.Cells[0].Text)+" ";
					conn.ExecuteNonQuery();
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

		protected void DDL_IDC_INTERESTTYPE_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if (DDL_IDC_INTERESTTYPE.SelectedValue == "01")
			{
				TXT_IDC_PRIMEVARCODE.Text = TXT_INTEREST.Text;
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

		//20070725 add by sofyan for alih debitur
		protected void CHK_ALIHDEB_CheckedChanged(object sender, System.EventArgs e)
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
	}
}