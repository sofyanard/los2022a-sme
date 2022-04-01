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
	/// Summary description for PermohonanBaruNonCash.
	/// </summary>
	public partial class PermohonanBaruNonCash : System.Web.UI.Page
	{
		protected Connection conn;
		protected Tools tool = new Tools();
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			conn = (Connection) Session["Connection"];

			if(!IsPostBack)
			{
				LBL_APPTYPE.Text	= Request.QueryString["apptype"];
				LBL_REGNO.Text		= Request.QueryString["regno"];
				LBL_PRODID.Text		= Request.QueryString["prodid"];
				LBL_PROD_SEQ.Text	= Request.QueryString["prod_seq"];
				LBL_KET_CODE.Text	= Request.QueryString["ket_code"];

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
				//cekProductSupportForEbiz();
				//viewIDC();
			}

			TXT_CP_EXLIMITVAL.Text = tool.MoneyFormat(TXT_CP_EXLIMITVAL.Text);
			TXT_CP_EXRPLIMIT.Text = tool.MoneyFormat(TXT_CP_EXRPLIMIT.Text);
			TXT_CP_LIMIT.Text = tool.MoneyFormat(TXT_CP_LIMIT.Text);

			if (LBL_DECSTA.Text == "0")
				CalculateInstallment();
		}

		private void CheckIDC()
		{
			conn.QueryString = "select idc_flag from custproduct where ap_regno='" + LBL_REGNO.Text + "' and apptype='" + LBL_APPTYPE.Text + "' and productid='" + LBL_PRODID.Text + "'";
			conn.ExecuteQuery();

			if (conn.GetFieldValue(0,0) == "1")
				//if ((TXT_IDC_RATIO.Text != "") || (TXT_IDC_JWAKTU.Text != "") || (TXT_IDC_CAPRATIO.Text != "") || (TXT_IDC_CAPAMNT.Text != ""))
			{
				CHECK_IDC.Checked = true;
				TR_IDC.Visible = true;
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
				if ((conn.GetFieldValue("isinstallment") == "1")/* && (conn.GetFieldValue("calcmethod") == "Annuity")*/)
				{
					//result = DMS.CuBESCore.Logic.hitungSkalaAngsuran(double.Parse(TXT_CP_LIMIT.Text), int.Parse(TXT_CP_JANGKAWKT.Text), 1, double.Parse(LBL_INTEREST.Text));
					result = DMS.CuBESCore.Logic.hitungInstalment(double.Parse(TXT_CP_LIMIT.Text), int.Parse(TXT_CP_JANGKAWKT.Text), double.Parse(LBL_INTEREST.Text), LBL_PRODID.Text, DDL_CP_TENORCODE.SelectedValue, conn);
					TXT_CP_INSTALLMENT.Text = tool.MoneyFormat(result.ToString());
				}
					/*sadf
					else if ((conn.GetFieldValue("isinstallment") == "1") && (conn.GetFieldValue("calcmethod") == "Daily"))
					{
						//result = DMS.CuBESCore.Logic.hitungSkalaAngsuran(double.Parse(TXT_CP_LIMIT.Text), int.Parse(TXT_CP_JANGKAWKT.Text), double.Parse(LBL_INTEREST.Text), 1);
						result = DMS.CuBESCore.Logic.hitungInstalment(double.Parse(TXT_CP_LIMIT.Text), int.Parse(TXT_CP_JANGKAWKT.Text), double.Parse(LBL_INTEREST.Text), LBL_PRODID.Text, DDL_CP_TENORCODE.SelectedValue, conn);
						TXT_CP_INSTALLMENT.Text = tool.MoneyFormat(result.ToString());
					}assa
					*/
				else if (conn.GetFieldValue("isinstallment") == "0")
				{
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
			GlobalTools.fillRefList(DDL_PROJECT_CODE, "select * from VW_RFPROJECT where ACTIVE = '1'", false, conn); 

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

			DDL_CP_ISSUEDATE_MM.Items.Add(new ListItem("- PILIH -", ""));
			DDL_CP_DUEDATE_MM.Items.Add(new ListItem("- PILIH -", ""));
			DDL_CP_BANKCORR.Items.Add(new ListItem("- PILIH -", ""));
			DDL_CP_BANKCORRCITY.Items.Add(new ListItem("- PILIH -", ""));
			string nm_bln;
			for (int i=1; i<=12; i++)
			{
				nm_bln = DateAndTime.MonthName(i, false);
				DDL_CP_ISSUEDATE_MM.Items.Add(new ListItem(nm_bln, i.ToString()));
				DDL_CP_DUEDATE_MM.Items.Add(new ListItem(nm_bln, i.ToString()));
			}

			//--- Bank
			conn.QueryString = "select bankid, bankid+' - '+bankname as bankname from rfbank where active='1' order by bankid";
			conn.ExecuteQuery();
			for (int i = 0; i < conn.GetRowCount(); i++)
				DDL_CP_BANKCORR.Items.Add(new ListItem(conn.GetFieldValue(i,1), conn.GetFieldValue(i,0)));
		}

		private void SelectColl()
		{
			DDL_CL_ID.Items.Clear();
			/*sdfs
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
			conn.ExecuteQuery();
			int row = conn.GetRowCount();
			DDL_CL_ID.Items.Add(new ListItem("-- PILIH --", ""));

			string CLFILTER = "", KOMA = "";
			for (int i = 0;i < row;i++)
			{
				DDL_CL_ID.Items.Add(new ListItem(conn.GetFieldValue(i, "CL_DESC") + " (" + conn.GetFieldValue(i,2) + ")", conn.GetFieldValue(i,0)));
				if (conn.GetFieldValue(i,0).ToString().Trim() != "")
				{
					CLFILTER = CLFILTER + KOMA + conn.GetFieldValue(i,0).ToString().Trim();
					KOMA = ",";
				}
				//DDL_CL_ID.Items.Add(new ListItem(conn.GetFieldValue(i, 1), conn.GetFieldValue(i, 0)));
			}
			string QuL = "";
			QuL	= "select CL_SEQ, CL_DESC, COLTYPEDESC from COLLATERAL cl "+
				"left join RFCOLLATERALTYPE rf on cl.CL_TYPE = rf.COLTYPESEQ where isnull(SIBS_COLID,'') <> '' and CU_REF = (select CU_REF from APPLICATION where AP_REGNO = '"+Request.QueryString["regno"]+"') "+
				"and cl.cl_seq not in (select endi.cl_seq from listcollateral endi where ap_regno='" + Request.QueryString["regno"] + 
				"' and productid='" + LBL_PRODID.Text + "' and PROD_SEQ = '" + LBL_PROD_SEQ.Text + "')";
			
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
				"CP_installment, CP_EXRPLIMIT, CP_EXLIMITVAL, CP_EXRPCOLL, "+
				"CP_EXCOLLVAL, CP_KETERANGAN, CP_JANGKAWKT, CP_TENORCODE, REVOLVING, "+
				"CP_VARCODE, CP_RATENO, CP_VARIANCE "+
				", CP_DECSTA, AD_VARCODE, AD_VARIANCE, AD_RATENO "+
				", CP_ISSUEDATE, CP_DUEDATE, CP_REQUEST, CP_ISSUETO, CP_ISSUEADDR1, CP_ISSUEADDR2, CP_ISSUEADDR3 "+
				", CP_COMMODITYNAME, CP_COMMODITYAMNT, CP_VALUE, CP_BANKCORR, CP_BANKCORRCITY"+
				", CP_BANKADDR1, CP_BANKADDR2, CP_BANKADDR3, CP_LIMITAWAL, PROJECT_CODE "+
				"from VW_CUSTPRODUCT where ap_regno='"+ LBL_REGNO.Text +"' and productid='"+ LBL_PRODID.Text +"' and apptype='"+LBL_APPTYPE.Text+"' and PROD_SEQ = '" + LBL_PROD_SEQ.Text + "'";
			conn.ExecuteQuery();
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
			string CP_DECSTA			= conn.GetFieldValue("CP_DECSTA");
			string AD_VARCODE			= conn.GetFieldValue("AD_VARCODE");
			string AD_VARIANCE			= conn.GetFieldValue("AD_VARIANCE");
			string AD_RATENO			= conn.GetFieldValue("AD_RATENO");
			string CP_ISSUEDATE			= conn.GetFieldValue("CP_ISSUEDATE");
			TXT_CP_ISSUEDATE_DD.Text	= tool.FormatDate_Day(CP_ISSUEDATE);
			DDL_CP_ISSUEDATE_MM.SelectedValue = tool.FormatDate_Month(CP_ISSUEDATE);
			TXT_CP_ISSUEDATE_YY.Text	= tool.FormatDate_Year(CP_ISSUEDATE);
			string CP_DUEDATE			= conn.GetFieldValue("CP_DUEDATE");
			TXT_CP_DUEDATE_DD.Text		= tool.FormatDate_Day(CP_DUEDATE);
			DDL_CP_DUEDATE_MM.SelectedValue = tool.FormatDate_Month(CP_DUEDATE);
			TXT_CP_DUEDATE_YY.Text		= tool.FormatDate_Year(CP_DUEDATE);
			TXT_CP_REQUEST.Text			= conn.GetFieldValue("CP_REQUEST");
			TXT_CP_ISSUETO.Text			= conn.GetFieldValue("CP_ISSUETO");
			TXT_CP_ISSUEADDR1.Text		= conn.GetFieldValue("CP_ISSUEADDR1");
			TXT_CP_ISSUEADDR2.Text		= conn.GetFieldValue("CP_ISSUEADDR2");
			TXT_CP_ISSUEADDR3.Text		= conn.GetFieldValue("CP_ISSUEADDR3");
			TXT_CP_COMMODITYNAME.Text	= conn.GetFieldValue("CP_COMMODITYNAME");
			TXT_CP_COMMODITYAMNT.Text	= conn.GetFieldValue("CP_COMMODITYAMNT");
			TXT_CP_VALUE.Text			= tool.ConvertCurr(conn.GetFieldValue("CP_VALUE"));
			DDL_CP_BANKCORR.SelectedValue		= conn.GetFieldValue("CP_BANKCORR");
			DDL_CP_BANKCORRCITY.SelectedValue	= conn.GetFieldValue("CP_BANKCORRCITY");
			TXT_CP_BANKADDR1.Text		= conn.GetFieldValue("CP_BANKADDR1");
			TXT_CP_BANKADDR2.Text		= conn.GetFieldValue("CP_BANKADDR2");
			TXT_CP_BANKADDR3.Text		= conn.GetFieldValue("CP_BANKADDR3");
			LBL_CP_LIMITAWAL.Text		= tool.MoneyFormat(conn.GetFieldValue("CP_LIMITAWAL"));
			try {DDL_PROJECT_CODE.SelectedValue = conn.GetFieldValue("PROJECT_CODE");}
			catch {}

			if (!conn.GetFieldValue("CP_LOANPURPOSE").Equals(""))
				DDL_CP_LOANPURPOSE.SelectedValue = conn.GetFieldValue("CP_LOANPURPOSE");
			conn.ClearData();
			TXT_LC_VALUE.Text		= "0";
			TXT_LC_PERCENTAGE.Text	= "0";
			TXT_ENDVALUE.Text		= "0";
			TR_IDC.Visible			= false;
			LBL_PRODUCT.Text		= Request.QueryString["teks"];
			/*
			conn.QueryString = "select sum(a.cp_limit) as tot_limit, exposure = case when c.LIMITEXPOSURE is null or c.LIMITEXPOSURE='' then sum(a.cp_limit) else "+
				"sum(a.cp_limit)+c.LIMITEXPOSURE end "+
				"from cust_product a "+
				"inner join application b on a.ap_regno=b.ap_regno "+
				"inner join customer c on c.cu_ref=b.cu_ref "+
				"where a.ap_regno='"+LBL_REGNO.Text+"' group by a.ap_regno, c.LIMITEXPOSURE";
			*/
			conn.QueryString = "exec DE_CALCULATE_TOTALEXPOSURE '" + Request.QueryString["regno"] + "', '" + Request.QueryString["curef"] + "'";
			conn.ExecuteQuery(300);
			TXT_LIMITEXPOSURE.Text = tool.MoneyFormat(conn.GetFieldValue("GROUP_EXPOSURE"));
			TXT_SUMLIMIT.Text		= tool.MoneyFormat(conn.GetFieldValue("tot_limit"));

			/******
			 * This part is commented because exposure calculation is incorrect
			 * ****
			conn.QueryString = "DE_TOTALEXPOSURE '" + LBL_REGNO.Text + "'";
			conn.ExecuteQuery();
			TXT_LIMITEXPOSURE.Text	= tool.MoneyFormat(conn.GetFieldValue("exposure"));
			TXT_SUMLIMIT.Text		= tool.MoneyFormat(conn.GetFieldValue("tot_limit"));
			***/
			conn.ClearData();				

			conn.QueryString = "select interesttype from rfproduct where productid='" + LBL_PRODID.Text + "'";
			conn.ExecuteQuery();
			if (conn.GetFieldValue(0,0) == "01")
			{
				LBL_INTERESTTYPE.Text = "Bunga / p.a: Floating";
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
				"IDC_PRIMEVARCODE, IDC_RATIO, IDC_VARCODE, IDC_VARIANCE from vw_custproduct_idc "+
				"where ap_regno='"+ LBL_REGNO.Text +"' and productid='"+ LBL_PRODID.Text +"' and apptype='"+LBL_APPTYPE.Text+"' and PROD_SEQ = '" + LBL_PROD_SEQ.Text + "'";
			conn.ExecuteQuery();
			TXT_IDC_CAPAMNT.Text		= conn.GetFieldValue("IDC_CAPAMNT");
			TXT_IDC_CAPRATIO.Text		= conn.GetFieldValue("IDC_CAPRATIO");
			TXT_IDC_JWAKTU.Text			= conn.GetFieldValue("IDC_JWAKTU");

			//TXT_IDC_PRIMEVARCODE.Text	= conn.GetFieldValue("IDC_PRIMEVARCODE");
			//if (TXT_IDC_PRIMEVARCODE.Text.Trim() == "")
			TXT_IDC_PRIMEVARCODE.Text = LBL_INTEREST.Text;
 
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
			conn.QueryString="select a.ap_regno, a.cl_seq, a.productid,c.coltypedesc, a.lc_percentage, b.cl_value, lc_value, b.cl_desc from listcollateral a inner join collateral b on " +
				"a.cl_seq = b.cl_seq inner join rfcollateraltype c on b.cl_type = c.coltypeseq " +
				"inner join application d on a.ap_regno = d.ap_regno and b.cu_ref=d.cu_ref "+
				"where a.ap_regno = '" + LBL_REGNO.Text + 
				"' and a.productid='" + LBL_PRODID.Text +
				"' and a.PROD_SEQ = '" + LBL_PROD_SEQ.Text + "'";
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

				//-------- Screen Protection ----------------------
				if (Request.QueryString["de"] != "1") 
				{
					DatGrd.Items[i].Cells[6].Text = "Delete";
					DatGrd.Items[i].Cells[6].Enabled = false;
				}
				//--------------------------------------------------
			}
		}

		private bool CheckIDCValidity()
		{
			string temp = "", temp2 = "";
			temp = tool.ConvertFloat(TXT_IDC_RATIO.Text);
			temp = temp.Replace(",", ".");
			if (float.Parse(temp) > 100)
			{
				Response.Write("<script language='javascript'>alert('Percentage over 100%');</script>");
				return false;
			}
			temp = tool.ConvertFloat(TXT_IDC_CAPRATIO.Text);
			temp = temp.Replace(",", ".");
			if (float.Parse(temp) > 100)
			{
				Response.Write("<script language='javascript'>alert('Percentage over 100%');</script>");
				return false;
			}
			temp = tool.ConvertFloat(TXT_IDC_CAPAMNT.Text);
			temp = temp.Replace(",", ".");
			temp2 = tool.ConvertFloat(TXT_CP_EXLIMITVAL.Text);
			temp2 = temp2.Replace(",", ".");
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
			TXT_CL_DESC.Text = "";

			calc.Enabled = false;
			insert.Enabled = false;
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
			this.DatGrd.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.DatGrd_PageIndexChanged);
			this.DatGrd.DeleteCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.DatGrd_DeleteCommand);

		}
		#endregion

		protected void update_Click(object sender, System.EventArgs e)
		{
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
					tool.ConvertFloat(TXT_IDC_RATIO.Text) +","+ tool.ConvertFloat(TXT_IDC_JWAKTU.Text) +","+ 
					tool.ConvertFloat(TXT_IDC_CAPAMNT.Text)+","+tool.ConvertFloat(TXT_IDC_CAPRATIO.Text)+",'"+
					LBL_RATENO.Text+"', "+tool.ConvertNull(DDL_CP_LOANPURPOSE.SelectedValue)+", "+
					tool.ConvertFloat(TXT_CP_EXLIMITVAL.Text)+", "+tool.ConvertFloat(TXT_CP_EXRPLIMIT.Text)+", "+
					tool.ConvertFloat(TXT_CP_LIMIT.Text)+", '', 0, "+
					""+tool.ConvertNull(LBL_VARCODE.Text)+", "+tool.ConvertNull(LBL_RATENO.Text)+", "+tool.ConvertFloat(LBL_VARIANCE.Text)+", "+
					""+tool.ConvertFloat(LBL_INTEREST.Text)+", "+tool.ConvertNull(DDL_IDC_VARCODE.SelectedValue)+", "+tool.ConvertFloat(TXT_IDC_VARIANCE.Text)+", "+
					"1,0, null, null, null, null, null, null, '" + LBL_PROD_SEQ.Text + "', " + 
					tool.ConvertNull(DDL_PROJECT_CODE.SelectedValue) + "";
				conn.ExecuteNonQuery();

			}
			else
			{
				conn.QueryString = "exec DE_STRUCCREDIT1 '"+LBL_REGNO.Text+"', '"+
					LBL_PRODID.Text+"', '"+LBL_APPTYPE.Text+"', "+
					tool.ConvertFloat(TXT_CP_INSTALLMENT.Text)+", "+tool.ConvertNum(TXT_CP_JANGKAWKT.Text)+", '"+
					DDL_CP_TENORCODE.SelectedValue+"' ,'"+ TXT_CP_KETERANGAN.Text +"', null, null, null, null, '"+
					LBL_RATENO.Text+"', "+tool.ConvertNull(DDL_CP_LOANPURPOSE.SelectedValue)+", "+
					tool.ConvertFloat(TXT_CP_EXLIMITVAL.Text)+", "+tool.ConvertFloat(TXT_CP_EXRPLIMIT.Text)+", "+
					tool.ConvertFloat(TXT_CP_LIMIT.Text)+", '', 0, "+
					tool.ConvertNull(LBL_VARCODE.Text)+", "+tool.ConvertNull(LBL_RATENO.Text)+", "+tool.ConvertFloat(LBL_VARIANCE.Text)+", "+
					tool.ConvertFloat(LBL_INTEREST.Text)+", "+tool.ConvertNull(DDL_IDC_VARCODE.SelectedValue)+", "+tool.ConvertFloat(TXT_IDC_VARIANCE.Text)+", "+
					"0,0, null, null, null, null, null, null, '" + LBL_PROD_SEQ.Text + "', " + 
					tool.ConvertNull(DDL_PROJECT_CODE.SelectedValue) + "";
				conn.ExecuteNonQuery();
			}
			
			conn.QueryString = "exec DE_PERMBARUNONCASH '" + LBL_REGNO.Text + "', '" + 
				LBL_APPTYPE.Text + "', '" + LBL_PRODID.Text + "', " + 
				tool.ConvertDate(TXT_CP_ISSUEDATE_DD.Text, DDL_CP_ISSUEDATE_MM.SelectedValue, TXT_CP_ISSUEDATE_YY.Text) + ", " +
				tool.ConvertDate(TXT_CP_DUEDATE_DD.Text, DDL_CP_DUEDATE_MM.SelectedValue, TXT_CP_DUEDATE_YY.Text) + ", '" +
				TXT_CP_REQUEST.Text + "', '" + TXT_CP_ISSUETO.Text + "', '" + 
				TXT_CP_ISSUEADDR1.Text + "', '" + TXT_CP_ISSUEADDR2.Text + "', '" + 
				TXT_CP_ISSUEADDR3.Text + "', '" + TXT_CP_COMMODITYNAME.Text + "', "+ 
				tool.ConvertNum(TXT_CP_COMMODITYAMNT.Text) + ", "+ tool.ConvertFloat(TXT_CP_VALUE.Text) + ", " + 
				tool.ConvertNull(DDL_CP_BANKCORR.SelectedValue) + ", "+ tool.ConvertNull(DDL_CP_BANKCORRCITY.SelectedValue) + ", '" + 
				TXT_CP_BANKADDR1.Text + "', '" + TXT_CP_BANKADDR2.Text + "', '" + 
				TXT_CP_BANKADDR3.Text + "' ,'" + LBL_PROD_SEQ.Text + "'";
			conn.ExecuteNonQuery();

			/////////////////////////////////////////////////////////
			///	Menghitung ulang Total Application Value dan
			///	Total Limit Exposure
			///	
			conn.QueryString = "DE_TOTALEXPOSURE '" + LBL_REGNO.Text + "'";
			conn.ExecuteQuery(300);
			TXT_LIMITEXPOSURE.Text	= tool.MoneyFormat(conn.GetFieldValue("exposure"));
			TXT_SUMLIMIT.Text		= tool.MoneyFormat(conn.GetFieldValue("tot_limit"));
			conn.ClearData();
		}

		protected void insert_Click(object sender, System.EventArgs e)
		{
			if(DDL_CL_ID.SelectedValue != "")
			{
				//calc_Click(sender, e);

				float persen = 0;
				try { persen = float.Parse(TXT_LC_PERCENTAGE.Text); }
				catch {}
				if ( persen>0 && (persen<100 || persen == 100))
				{
					conn.QueryString = "exec SP_LISTCOLLPROCESS '" + 
						LBL_REGNO.Text+"', '" + 
						LBL_APPTYPE.Text + "','" + 
						LBL_CU_REF.Text + "', '" + 
						LBL_PRODID.Text + "', " + 
						tool.ConvertNum(DDL_CL_ID.SelectedValue) + ", " + 
						tool.ConvertFloat(TXT_LC_PERCENTAGE.Text) + ", " + 
						tool.ConvertFloat(TXT_ENDVALUE.Text)+ ", '1', '" + 
						LBL_PROD_SEQ.Text + "'";
					conn.ExecuteNonQuery();
				}
			}
			
			SelectColl();
			isiGrid();
			tidakisiCollateral();
			DDL_CL_ID.SelectedValue	= "";
		}

		protected void DDL_CL_ID_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			conn.QueryString = "SELECT a.CL_VALUE, a.COLTYPEDESC FROM  VW_COLLATERAL1 a "+
				"WHERE a.cl_seq = '"+tool.ConvertNum(DDL_CL_ID.SelectedValue)+"' and a.cu_ref='"+LBL_CU_REF.Text+"' and (a.CL_SEQ NOT IN (SELECT b.cl_seq FROM listcollateral b "+
				"WHERE a.cl_seq = b.cl_seq and b.ap_regno='"+LBL_REGNO.Text+"' and b.productid='"+LBL_PRODID.Text+"' and b.PROD_SEQ = '" + LBL_PROD_SEQ.Text + "'))";
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

		protected void CHECK_IDC_CheckedChanged(object sender, System.EventArgs e)
		{
			if (CHECK_IDC.Checked ==true)
			{
				TR_IDC.Visible = true;
				//viewIDC();
				TXT_IDC_RATIO.CssClass			= "mandatory";
				TXT_IDC_JWAKTU.CssClass			= "mandatory";
				//TXT_IDC_CAPRATIO.CssClass		= "mandatory";
				TXT_IDC_CAPAMNT.CssClass		= "mandatory";
				TXT_IDC_PRIMEVARCODE.CssClass	= "mandatory";
			}
			else
			{
				TR_IDC.Visible = false;
				TXT_IDC_RATIO.CssClass = "";
				TXT_IDC_JWAKTU.CssClass = "";
				//TXT_IDC_CAPRATIO.CssClass = "";
				TXT_IDC_CAPAMNT.CssClass = "";
				TXT_IDC_PRIMEVARCODE.CssClass = "";
			}

			// Kalau pilih Check IDC, default kosongkan semua field
			TXT_IDC_RATIO.Text					= "";
			TXT_IDC_JWAKTU.Text					= "";
			TXT_IDC_CAPRATIO.Text				= "";
			TXT_IDC_CAPAMNT.Text				= "";
			TXT_IDC_PRIMEVARCODE.Text			= "";
			TXT_IDC_PRIMEVARCODE.Text			= "";
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
	}
}
