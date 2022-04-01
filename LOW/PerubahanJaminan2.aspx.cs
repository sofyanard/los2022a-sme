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

namespace SME.LOW
{
	/// <summary>
	/// Summary description for PerubahanJaminan2.
	/// </summary>
	public partial class PerubahanJaminan2 : System.Web.UI.Page
	{

		#region " Variables "

		protected Tools tool = new Tools();
		protected Connection conn;
		protected DataTable dtColl;
		//protected string mainregno, mainprod_seq, mainproductid;

		#endregion

	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			conn					= (Connection) Session["Connection"];
			LBL_MAINREGNO.Text		= Request.QueryString["mainregno"];
			LBL_MAINPROD_SEQ.Text	= Request.QueryString["mainprod_seq"];
			LBL_MAINPRODUCTID.Text	= Request.QueryString["mainproductid"];

			/////////////////////////////////
			///	security purpose !
			///	
			if (!Logic.AllowAccess(Session["GroupID"].ToString(), Request.QueryString["mc"], conn))
				Response.Redirect("/SME/Restricted.aspx");

			/////////////////////////////////
			///	read-only purpose !
			///	
			cekIsView(Request.QueryString["view"]);

			if (!IsPostBack)
			{
				LBL_USERID.Text = Session["UserID"].ToString();

				//init APPType
				conn.QueryString = "select apptypeid, apptypedesc from rfapplicationtype where active='1'";
				conn.ExecuteQuery();
				DDL_APPTYPE.Items.Add(new ListItem("- PILIH -", ""));
				for (int i = 0; i < conn.GetRowCount(); i++)
					DDL_APPTYPE.Items.Add(new ListItem(conn.GetFieldValue(i,1), conn.GetFieldValue(i,0)));

				DDL_APPTYPE.SelectedValue = Request.QueryString["app"];

				//init CLType / Jenis Jaminan
				conn.QueryString = "select COLTYPESEQ, COLTYPEID + ' - ' + COLTYPEDESC as COLTYPEDESC from RFCOLLATERALTYPE where ACTIVE='1' order by COLTYPEID";
				conn.ExecuteQuery();
				DDL_CL_TYPE.Items.Add(new ListItem("- PILIH -", ""));
				for (int i = 0; i < conn.GetRowCount(); i++)
					DDL_CL_TYPE.Items.Add(new ListItem(conn.GetFieldValue(i,1), conn.GetFieldValue(i,0)));

				//init CL_CURRENCY
				//--- Mata Uang				
				GlobalTools.fillRefList(DDL_CL_CURRENCY, "select CURRENCYID, CURRENCYDESC from RFCURRENCY where ACTIVE='1' order by CURRENCYID", true, conn);
				try
				{
					DDL_CL_CURRENCY.SelectedValue = "IDR";
				}
				catch{}

				//init CL_COLCLASSIFY
				conn.QueryString = "select colclassid, colclassdesc from rfcollclass where active='1'";
				conn.ExecuteQuery();
				DDL_CL_COLCLASSIFY.Items.Add(new ListItem("- PILIH -", ""));
				for (int i = 0; i < conn.GetRowCount(); i++)
					DDL_CL_COLCLASSIFY.Items.Add(new ListItem(conn.GetFieldValue(i,1), conn.GetFieldValue(i,0)));

				//--- Tujuan Penggunaan
				conn.QueryString = "select LOANPURPID, LOANPURPID + ' - ' + LOANPURPDESC as LOANPURPDESC from RFLOANPURPOSE where ACTIVE='1' order by LOANPURPID";
				conn.ExecuteQuery();
				DDL_CP_LOANPURPOSE.Items.Add(new ListItem("- PILIH -", ""));
				for (int i = 0; i < conn.GetRowCount(); i++)
					DDL_CP_LOANPURPOSE.Items.Add(new ListItem(conn.GetFieldValue(i,1), conn.GetFieldValue(i,0)));

				//--- Bukti Kepemilikan
				DDL_BUKTI_KEPEMILIKAN.Items.Add(new ListItem("- PILIH -", ""));
				conn.QueryString = "SELECT CERTTYPEID, CERTTYPEDESC FROM RFCERTTYPE WHERE ACTIVE = '1' ORDER BY CERTTYPEDESC";
				conn.ExecuteQuery();
				for (int i = 0; i < conn.GetRowCount(); i++)
					DDL_BUKTI_KEPEMILIKAN.Items.Add(new ListItem(conn.GetFieldValue(i,1), conn.GetFieldValue(i,0)));

				//--- Bentuk Pengikatan
				DDL_BENTUK_PENGIKATAN.Items.Add(new ListItem("- PILIH -", ""));
				conn.QueryString = "SELECT IKATID, IKATDESC FROM RFIKAT WHERE ACTIVE = '1' ORDER BY IKATID";
				conn.ExecuteQuery();
				for (int i = 0; i < conn.GetRowCount(); i++)
					DDL_BENTUK_PENGIKATAN.Items.Add(new ListItem(conn.GetFieldValue(i,1), conn.GetFieldValue(i,0)));

				//--- Tanggal Penilaian
				DDL_TGLPENILAIAN_MONTH.Items.Add(new ListItem("- PILIH -", ""));
				for (int i = 1; i <= 12; i++)
				{
					DDL_TGLPENILAIAN_MONTH.Items.Add(new ListItem(DateAndTime.MonthName(i, false), i.ToString()));
				}

				//--- Penilaian Oleh
				DDL_PENILAI_OLEH.Items.Add(new ListItem("- PILIH -", ""));
				conn.QueryString = "select ACCRDTOID, ACCRDTODESC from RFVALUEACCORDING where active='1'";
				conn.ExecuteQuery();
				for (int i = 0; i < conn.GetRowCount(); i++)
					DDL_PENILAI_OLEH.Items.Add(new ListItem(conn.GetFieldValue(i,1), conn.GetFieldValue(i,0)));

				fillAANo();

				dtColl = new DataTable();
				dtColl.Columns.Add(new DataColumn("CL_SEQ"));
				dtColl.Columns.Add(new DataColumn("COLTYPEID"));
				dtColl.Columns.Add(new DataColumn("COLTYPEDESC"));
				dtColl.Columns.Add(new DataColumn("CL_DESC"));
				dtColl.Columns.Add(new DataColumn("CL_CERTTYPE1"));
				dtColl.Columns.Add(new DataColumn("CL_CERTTYPE1DESC"));
				dtColl.Columns.Add(new DataColumn("CL_IKATID"));
				dtColl.Columns.Add(new DataColumn("CL_IKATIDDESC"));
				dtColl.Columns.Add(new DataColumn("CL_FOREIGNVAL2"));
				dtColl.Columns.Add(new DataColumn("CL_VALUE2"));
				dtColl.Columns.Add(new DataColumn("CL_FOREIGNVAL"));
				dtColl.Columns.Add(new DataColumn("CL_VALUE"));
				dtColl.Columns.Add(new DataColumn("CL_FOREIGNVALINS"));
				dtColl.Columns.Add(new DataColumn("CL_VALUEINS"));
				dtColl.Columns.Add(new DataColumn("CL_FOREIGNVALIKAT"));
				dtColl.Columns.Add(new DataColumn("CL_VALUEIKAT"));
				dtColl.Columns.Add(new DataColumn("CL_FOREIGNVALPPA"));
				dtColl.Columns.Add(new DataColumn("CL_VALUEPPA"));
				dtColl.Columns.Add(new DataColumn("CL_FOREIGNVALLIQ"));
				dtColl.Columns.Add(new DataColumn("CL_VALUELIQ"));
				dtColl.Columns.Add(new DataColumn("LC_PERCENTAGE"));
				dtColl.Columns.Add(new DataColumn("ISNEW"));
				dtColl.Columns.Add(new DataColumn("CL_CURRENCY"));
				dtColl.Columns.Add(new DataColumn("CL_COLCLASSIFY"));
				dtColl.Columns.Add(new DataColumn("CL_EXCHANGERATE"));
				dtColl.Columns.Add(new DataColumn("CL_PENILAIANDATE"));
				dtColl.Columns.Add(new DataColumn("CL_PENILAIANBY"));
				dtColl.Columns.Add(new DataColumn("LC_ACTION"));
				dtColl.Columns.Add(new DataColumn("LC_ACTIONDESC"));
				Session.Add("dataTable", dtColl);

				conn.QueryString = "select isnull(max(cl_seq),0) from collateral where cu_ref='" + Request.QueryString["curef"] + "'";
				conn.ExecuteQuery();
				LBL_SEQ.Text = conn.GetFieldValue(0,0);

				ViewCollateral();
				ViewApplications();
				fillAction(true);

				/// If program allows withdrawal ( from his own facility and account ), then
				/// customer is allowed to choose withdrawal
				///  
				conn.QueryString = "select withdrawl from rfprogram where programid='" + Request.QueryString["prog"] + "'";
				conn.ExecuteQuery();
				if (conn.GetFieldValue(0,0) == "0")
					DDL_APPTYPE.Items.Remove(DDL_APPTYPE.Items.FindByValue("06"));

				viewData();
			
				//	mengisi daftar existing collateral
				bindData();
			}
			else
			{
				TXT_LIMIT.Text = tool.MoneyFormat(TXT_LIMIT.Text);
				TXT_CL_EXCHANGERATE.Text = tool.MoneyFormat(TXT_CL_EXCHANGERATE.Text);
				TXT_CL_FOREIGNVAL.Text = tool.MoneyFormat(TXT_CL_FOREIGNVAL.Text);
				TXT_CL_VALUE.Text = tool.MoneyFormat(TXT_CL_VALUE.Text);
			}

			ViewMenu();

			BTN_INSCOLL.Attributes.Add("onclick","if(!cek_mandatoryColl(document.Form1)){return false;};");
			//BTN_SAVE.Attributes.Add("onclick","if(!cek_mandatory(document.Form1)){return false;};");
			BTN_SAVE.Attributes.Add("onclick","if(!cek_mandatory(document.Form1)){return false;};if(!SaveMsg()){return false;};");
		}

		private void fillAANo()
		{
			if (Request.QueryString["curefchann"] == "" || Request.QueryString["curefchann"] == null) 
				conn.QueryString = "select distinct aa_no from bookedcust where cu_ref='" + Request.QueryString["curef"] + "'";
			else 
				conn.QueryString = "select distinct aa_no from bookedcust where cu_ref='" + Request.QueryString["curefchann"] + "'";
			conn.ExecuteQuery();
			DDL_AA_NO.Items.Clear();
			DDL_AA_NO.Items.Add(new ListItem("- PILIH -", ""));
			for (int i = 0; i < conn.GetRowCount(); i++)
				DDL_AA_NO.Items.Add(new ListItem(conn.GetFieldValue(i,0), conn.GetFieldValue(i,0)));
			fillProductID();
		}

		private void fillProductID()
		{

			DataTable dt = new DataTable();
			dt.Columns.Add(new DataColumn("CL_SEQ"));
			dt.Columns.Add(new DataColumn("COLTYPEID"));
			dt.Columns.Add(new DataColumn("COLTYPEDESC"));
			dt.Columns.Add(new DataColumn("CL_DESC"));
			dt.Columns.Add(new DataColumn("CL_CERTTYPE1"));
			dt.Columns.Add(new DataColumn("CL_CERTTYPE1DESC"));
			dt.Columns.Add(new DataColumn("CL_IKATID"));
			dt.Columns.Add(new DataColumn("CL_IKATIDDESC"));
			dt.Columns.Add(new DataColumn("CL_FOREIGNVAL2"));
			dt.Columns.Add(new DataColumn("CL_VALUE2"));
			dt.Columns.Add(new DataColumn("CL_FOREIGNVAL"));
			dt.Columns.Add(new DataColumn("CL_VALUE"));
			dt.Columns.Add(new DataColumn("CL_FOREIGNVALINS"));
			dt.Columns.Add(new DataColumn("CL_VALUEINS"));
			dt.Columns.Add(new DataColumn("CL_FOREIGNVALIKAT"));
			dt.Columns.Add(new DataColumn("CL_VALUEIKAT"));
			dt.Columns.Add(new DataColumn("CL_FOREIGNVALPPA"));
			dt.Columns.Add(new DataColumn("CL_VALUEPPA"));
			dt.Columns.Add(new DataColumn("CL_FOREIGNVALLIQ"));
			dt.Columns.Add(new DataColumn("CL_VALUELIQ"));
			dt.Columns.Add(new DataColumn("CL_PERCENT"));
			dt.Columns.Add(new DataColumn("ISNEW"));
			dt.Columns.Add(new DataColumn("CL_CURRENCY"));
			dt.Columns.Add(new DataColumn("CL_COLCLASSIFY"));
			dt.Columns.Add(new DataColumn("CL_EXCHANGERATE"));
			dt.Columns.Add(new DataColumn("CL_PENILAIANDATE"));
			dt.Columns.Add(new DataColumn("CL_PENILAIANBY"));
			dt.Columns.Add(new DataColumn("SIBS_COLID"));
			DatGrdOld.DataSource = dt;
			DatGrdOld.DataBind();

			DDL_PRODUCTID.Items.Clear();
			if (DDL_AA_NO.SelectedValue == "") return;
			conn.QueryString = "select productid from bookedcust where cu_ref='" + Request.QueryString["curef"] + "' and aa_no='" + DDL_AA_NO.SelectedValue + "'";
			conn.ExecuteQuery();
			DDL_PRODUCTID.Items.Add(new ListItem("- PILIH -", ""));
			for (int i = 0; i < conn.GetRowCount(); i++)
				DDL_PRODUCTID.Items.Add(new ListItem(conn.GetFieldValue(i,0), conn.GetFieldValue(i,0)));
			fillFasilitasNo();
		}

		private void fillFasilitasNo()
		{
			DDL_FACILITYNO.Items.Clear();
			if (DDL_PRODUCTID.SelectedValue == "") return;

			conn.QueryString = "select acc_seq, acc_no from bookedprod where aa_no='" + DDL_AA_NO.SelectedValue +
				"' and productid='" + DDL_PRODUCTID.SelectedValue + "'";
			conn.ExecuteQuery();
			DDL_FACILITYNO.Items.Add(new ListItem("- PILIH -", ""));
			for (int i = 0; i < conn.GetRowCount(); i++)
				DDL_FACILITYNO.Items.Add(new ListItem(conn.GetFieldValue(i,0), conn.GetFieldValue(i,0)));
			
			conn.QueryString = "select productdesc from rfproduct where productid='" + DDL_PRODUCTID.SelectedValue + "'";
			conn.ExecuteQuery();
			TXT_PRODUCTDESC.Text = conn.GetFieldValue("productdesc");
			updateLimit();
		}

		private void updateLimit()
		{
			TXT_LIMIT.Text = "";
			TXT_TENORDESC.Text = "";
			conn.QueryString = "select bp.LIMIT, convert(varchar,bp.TENOR) + isnull('  ' + rt.TENORDESC, '') TENORDESC " +
				"from bookedprod bp left join rftenorcode rt on bp.tenorcode=rt.tenorcode " + 
				"where bp.aa_no='" + DDL_AA_NO.SelectedValue + "' and bp.productid='" +
				DDL_PRODUCTID.SelectedValue + "' and bp.acc_seq='" + DDL_FACILITYNO.SelectedValue + "'";
			conn.ExecuteQuery();
			if (conn.GetRowCount() > 0)
			{
				TXT_LIMIT.Text = tool.MoneyFormat(conn.GetFieldValue(0, "LIMIT"));
				TXT_TENORDESC.Text = conn.GetFieldValue(0, "TENORDESC");
			}
		}

		private void ViewCollateral()
		{
			double nilaiAkhir = 0;

			dtColl = (DataTable) Session["dataTable"];
			DatGrd.DataSource = dtColl;
			try
			{
				DatGrd.DataBind();
			} 
			catch 
			{
				DatGrd.CurrentPageIndex = DatGrd.PageCount - 1;
				DatGrd.DataBind();
			}

			for (int i = 0; i < DatGrd.Items.Count; i++)
			{
				try 
				{
					nilaiAkhir = double.Parse(DatGrd.Items[i].Cells[11].Text) *
						(double.Parse(DatGrd.Items[i].Cells[20].Text) / 100);
					DatGrd.Items[i].Cells[21].Text = tool.MoneyFormat(nilaiAkhir.ToString());
				} 
				catch {}
			}
		}

		private void ViewApplications()
		{		
			DataTable dt1 = new DataTable();
			conn.QueryString = "select * from vw_ide_listapplication where ap_regno='" + Request.QueryString["regno"] + "' and KET_CODE = '" + Request.QueryString["ket_code"] + "'";
			conn.ExecuteQuery();
			dt1 = conn.GetDataTable().Copy();
			DATAGRID1.DataSource = dt1;
			DATAGRID1.DataBind();

			for (int i = 0; i < DATAGRID1.Items.Count; i++)
			{
				if (DATAGRID1.Items[i].Cells[5].Text != "&nbsp;")
					DATAGRID1.Items[i].Cells[5].Text = tool.MoneyFormat(DATAGRID1.Items[i].Cells[5].Text);
				if (DATAGRID1.Items[i].Cells[6].Text != "&nbsp;")
					DATAGRID1.Items[i].Cells[6].Text = tool.MoneyFormat(DATAGRID1.Items[i].Cells[6].Text);
			}
		}

		private void fillAction()
		{
			fillAction(false);
		}

		private void fillAction(bool addOnly)
		{
			rdoAction.Items.Clear();
			rdoAction.Items.Add(new ListItem("Add", "1"));
			if (!addOnly)
			{
				rdoAction.Items.Add(new ListItem("Remove", "2"));
				rdoAction.Items.Add(new ListItem("Re-Appraise", "3"));
			}
			rdoAction.Items[0].Selected = true;
		}

		private void cekIsView(string view) 
		{
			if(view == "1") 
			{
				TR_JENISPENGAJUAN.Visible = false;
				TR_BUTTONCOLL.Visible = false;
				TR_BUTTONS.Visible = false;
				TR_COLL.Visible = false;
				TR_COLL2.Visible = false;
				TR_COLLENTRY.Visible = false;				
			}
		}

		private void viewData() 
		{
			//-- Yudi
			//Untuk kebutuhan KETENTUAN KREDIT, kalau permohonan baru dalam satu ketentuan kredit
			//tidak bisa bergabung dengan jenis pengajuan lain.				
			DDL_APPTYPE.Items.Remove(DDL_APPTYPE.Items.FindByValue("01"));

			conn.QueryString = "select * from KETENTUAN_KREDIT where KET_CODE ='" + Request.QueryString["ket_code"] + "'";
			conn.ExecuteQuery();

			DDL_AA_NO.SelectedValue = conn.GetFieldValue("AA_NO");

			DDL_PRODUCTID.Items.Add(new ListItem("- PILIH -",""));
			DDL_FACILITYNO.Items.Add(new ListItem("- PILIH -",""));
			DDL_PRODUCTID.Items.Add(new ListItem(conn.GetFieldValue("PRODUCTID"), conn.GetFieldValue("PRODUCTID")));
			DDL_FACILITYNO.Items.Add(new ListItem(conn.GetFieldValue("ACC_SEQ"), conn.GetFieldValue("ACC_SEQ")));

			DDL_FACILITYNO.SelectedValue = conn.GetFieldValue("ACC_SEQ");
			DDL_PRODUCTID.SelectedValue = conn.GetFieldValue("PRODUCTID");
			LBL_PRODUCTID.Text = conn.GetFieldValue("PRODUCTID");


			DDL_AA_NO.Enabled = false;
			DDL_PRODUCTID.Enabled = false;
			DDL_FACILITYNO.Enabled = false;	

			TXT_LIMIT.Text = "";
			TXT_TENORDESC.Text = "";

			/// get account number
			string _accno = conn.GetFieldValue("ACC_NO");
			if (_accno == null) _accno = "";
			try { _accno = _accno.Trim(); } 
			catch {}

			conn.QueryString = "select bp.LIMIT, convert(varchar,bp.TENOR) + isnull('  ' + rt.TENORDESC, '') TENORDESC, PRODUCTDESC, LOANPURPID " +
				"from bookedprod bp " + 
				"left join rftenorcode rt on bp.tenorcode=rt.tenorcode " + 
				"inner join rfproduct rp on bp.productid=rp.productid " +					
				"where bp.aa_no = '" + DDL_AA_NO.SelectedValue + 
				"' and bp.productid = '" + DDL_PRODUCTID.SelectedValue + 
				"' and bp.acc_seq = '" + DDL_FACILITYNO.SelectedValue + "' " + 
				" and bp.acc_no = '" + _accno + "'";
			conn.ExecuteQuery();
			if (conn.GetRowCount() > 0)
			{
				TXT_LIMIT.Text = tool.MoneyFormat(conn.GetFieldValue(0, "LIMIT"));
				TXT_TENORDESC.Text = conn.GetFieldValue(0, "TENORDESC");
				TXT_PRODUCTDESC.Text = conn.GetFieldValue(0, "productdesc");
				try {DDL_CP_LOANPURPOSE.SelectedValue = conn.GetFieldValue(0, "LOANPURPID");}
				catch {}
			}
		}

		private void bindData()
		{
			double nilaiAkhir = 0;
			DataTable dt = new DataTable();
			conn.QueryString = "select *, CL_DESC + ' (' + SIBS_COLID + ') ' MYDESC " +
				"from vw_bookedcollateral where aa_no='" + DDL_AA_NO.SelectedValue + "' and " +
				"productid='" + DDL_PRODUCTID.SelectedValue + "' and acc_seq=" + DDL_FACILITYNO.SelectedValue;
			conn.ExecuteQuery();
			dt = conn.GetDataTable().Copy();
			DatGrdOld.DataSource = dt;
			try 
			{
				DatGrdOld.DataBind();
			}
			catch 
			{
				DatGrdOld.CurrentPageIndex = DatGrdOld.PageCount - 1;
				DatGrdOld.DataBind();
			}
			for (int i = 0; i < DatGrdOld.Items.Count; i++)
			{
				nilaiAkhir = double.Parse(DatGrdOld.Items[i].Cells[11].Text) * (double.Parse(DatGrdOld.Items[i].Cells[20].Text) / 100);
				DatGrdOld.Items[i].Cells[21].Text = tool.MoneyFormat(nilaiAkhir.ToString());
				DatGrdOld.Items[i].Cells[11].Text = tool.MoneyFormat(DatGrdOld.Items[i].Cells[11].Text);
			}
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

		private void fillExisting()
		{
			conn.QueryString = "select CL_SEQ, CL_DESC, CL_UTILIZATION, CL_APPRVALUE, SIBS_COLID " + 
				"from COLLATERAL where CU_REF='" + Request.QueryString["curef"] + "' " +
				"and ((SIBS_COLID is not null and SIBS_COLID <> '') or CL_SEQ in (select CL_SEQ from " + 
				"LISTCOLLATERAL where AP_REGNO = '" + Request.QueryString["regno"] + "'))";
			conn.ExecuteQuery();
			DDL_CL_TYPE_EXISTING.Items.Clear();
			DDL_CL_TYPE_EXISTING.Items.Add(new ListItem("- PILIH -", ""));
			for (int i = 0; i < conn.GetRowCount(); i++)
				DDL_CL_TYPE_EXISTING.Items.Add(new ListItem(conn.GetFieldValue(i,1) + " [" + conn.GetFieldValue(i, "sibs_colid") + "]", conn.GetFieldValue(i,0)));
		}

		private bool isSeqBooked(string seq)
		{
			try
			{
				conn.QueryString = "select CL_SEQ " +
					"from vw_bookedcollateral where aa_no = '" + DDL_AA_NO.SelectedValue + "' and " +
					"productid = '" + DDL_PRODUCTID.SelectedValue + "' and acc_seq = " +
					DDL_FACILITYNO.SelectedValue + " and cl_seq = " + seq;
				conn.ExecuteQuery();
				return (conn.GetRowCount() > 0);
			} 
			catch {}
			return false;
		}

		private double usedUtilization(string seq)
		{
			double nilaiAkhir = 0;

			for (int i = 0; i < DatGrd.Items.Count; i++)
			{
				try 
				{
					if (DatGrd.Items[i].Cells[0].Text.Trim() == seq)
					{
						nilaiAkhir = nilaiAkhir + double.Parse(DatGrd.Items[i].Cells[20].Text);
					}
				} 
				catch {}
			}
			return nilaiAkhir;
		}

		private void Clear()
		{
			Clear(false);
		}

		private void Clear(bool flagColDataOnly)
		{
			if (!flagColDataOnly)
			{
				DDL_APPTYPE.SelectedValue ="";
				TXT_LIMIT.Text = "";
				TXT_TENORDESC.Text = "";
				TXT_CP_NOTES.Text = "";
			
				dtColl = (DataTable) Session["dataTable"];
				int count = dtColl.Rows.Count;
				for (int i = 0; i < count; i++)
					dtColl.Rows[0].Delete();
			
				DatGrd.DataSource = dtColl;
				DatGrd.DataBind();
			}
			try{DDL_CL_TYPE.SelectedValue = "";}
			catch{}
			DDL_CL_TYPE_EXISTING.SelectedValue = "";
			DDL_CL_COLCLASSIFY.SelectedValue = "";
			DDL_CL_CURRENCY.SelectedValue = "";
			TXT_CL_FOREIGNVAL.Text = "";
			TXT_CL_EXCHANGERATE.Text = "1";
			TXT_CL_VALUE.Text = "";
			TXT_LC_PERCENTAGE.Text = "100";

			try{DDL_BUKTI_KEPEMILIKAN.SelectedValue = "";}
			catch{}
			try{DDL_BENTUK_PENGIKATAN.SelectedValue = "";}
			catch{}
			TXT_CL_FOREIGNVAL2.Text = "";
			TXT_CL_VALUE2.Text = "";
			TXT_CL_FOREIGNVALINS.Text = "";
			TXT_CL_VALUEINS.Text = "";
			TXT_CL_FOREIGNVALIKAT.Text = "";
			TXT_CL_VALUEIKAT.Text = "";
			TXT_CL_FOREIGNVALPPA.Text = "";
			TXT_CL_VALUEPPA.Text = "";
			TXT_CL_FOREIGNVALLIQ.Text = "";
			TXT_CL_VALUELIQ.Text = "";
			TXT_TGLPENILAIAN_DAY.Text = "";
			try{DDL_TGLPENILAIAN_MONTH.SelectedValue = "";}
			catch{}
			TXT_TGLPENILAIAN_YEAR.Text = "";
			try{DDL_PENILAI_OLEH.SelectedValue = "";}
			catch{}
		}

		private string getNextStepMsg(string regno) 
		{
			string pesan = "";
			string nextTrack = "";
			try 
			{
				/***
				 * Memunculkan pesan next step
				 ***/
				conn.QueryString = "exec TRACKNEXTMSG '" + regno + "'";
				conn.ExecuteQuery();
				nextTrack = conn.GetFieldValue("TRACKNAME");
				pesan = "Application proceeds to " + nextTrack;
				/***********************************/
			} 
			catch 
			{
				throw new Exception();
			}

			return pesan;
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
			this.DatGrdOld.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.DatGrdOld_PageIndexChanged);
			this.DatGrd.ItemCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.DatGrd_ItemCommand);
			this.DatGrd.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.DatGrd_PageIndexChanged);
			this.DATAGRID1.ItemCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.DATAGRID1_ItemCommand);

		}
		#endregion

		protected void DDL_APPTYPE_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			// 20080727, add by sofyan for pipeline corporate
			string dflt = "1";
			conn.QueryString = "SELECT AP_BUSINESSUNIT FROM VW_APPBUSINESSUNIT WHERE AP_REGNO = '" + Request.QueryString["regno"] + "'";
			conn.ExecuteQuery();
			if (conn.GetRowCount() > 0)
				if ((conn.GetFieldValue("AP_BUSINESSUNIT") == "CB100") ||
					(conn.GetFieldValue("AP_BUSINESSUNIT") == "MD100") ||
					(conn.GetFieldValue("AP_BUSINESSUNIT") == "SM100") ||
					(conn.GetFieldValue("AP_BUSINESSUNIT") == "CR100") ||
					(conn.GetFieldValue("AP_BUSINESSUNIT") == "MB100"))
					dflt = "2";
			
			///////////////////////////////////////////////////////////////////////////////////////////
			/// Note: if there are changes on the links below (regno, curef, prog, etc), impact to 
			///		  other pages also apply
			/// 
			if (DDL_APPTYPE.SelectedValue != "")
			{
				//conn.QueryString = "select screenlink from apptypelink where apptypeid='" + DDL_APPTYPE.SelectedValue + "' and fungsiid='IDE' and [default]='1'";
				conn.QueryString = "select screenlink from apptypelink where apptypeid='" + DDL_APPTYPE.SelectedValue + "' and fungsiid='IDE' and [default]='" + dflt + "'";
				conn.ExecuteQuery();
				string link = conn.GetFieldValue(0,0) + "?app=" + DDL_APPTYPE.SelectedValue;
				Response.Redirect(link + 
					"&regno=" + Request.QueryString["regno"] + 
					"&curef=" + Request.QueryString["curef"] + 
					"&prog=" + Request.QueryString["prog"] + 
					"&tc=" + Request.QueryString["tc"] + 
					"&mc=" + Request.QueryString["mc"] + 
					"&ket_code=" + Request.QueryString["ket_code"] +
					"&mainregno=" + LBL_MAINREGNO.Text + 
					"&mainprod_seq=" + LBL_MAINPROD_SEQ.Text + 
					"&mainproductid=" + LBL_MAINPRODUCTID.Text + 
					"&curefchann=" + Request.QueryString["curefchann"]);
			}
		}

		private void DATAGRID1_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			switch (((LinkButton)e.CommandSource).CommandName)
			{
				case "delete":
					/****************************************************************************************
					 * Kalau delete dari selain IDE, tidak bisa dilakukan jika tinggal 1 jenis pengajuan
					 *****************************************************************************************/
					conn.QueryString = "select * from scgroup_init2 where gr_key like '%IDE%' and groupid = '" + Request.QueryString["tc"] + "'";
					conn.ExecuteQuery();
					if (conn.GetRowCount() == 0 && DATAGRID1.Items.Count == 1) 
					{
						GlobalTools.popMessage(this, "Jenis Pengajuan tidak bisa dihapus karena aplikasi akan tidak memiliki kredit !");
						return;
					}
					/****************************************************************************************/

					try 
					{ 
						conn.QueryString = "exec IDE_LOANINFO_DELETE '" + 
							Request.QueryString["regno"] + "', '" + 
							e.Item.Cells[1].Text + "', '" + // apptype
							e.Item.Cells[3].Text + "', '" + // productid
							e.Item.Cells[9].Text + "'";		// prod_seq
						conn.ExecTrans();
						conn.ExecTran_Commit();
					} 
					catch (Exception ex)
					{
						if (conn != null)
							conn.ExecTran_Rollback();
						ExceptionHandling.Handler.saveExceptionIntoWindowsLog(ex, Request.Path, "ERROR DELETE : " + Request.QueryString["regno"]);
					}

					break;
			}
			ViewApplications();
		}

		protected void DDL_AA_NO_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			fillProductID();
		}

		protected void DDL_PRODUCTID_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			fillFasilitasNo();
		}

		protected void DDL_FACILITYNO_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			updateLimit();
			bindData();
		}

		protected void BTN_INSCOLL_Click(object sender, System.EventArgs e)
		{
			//
			// Validasi jenis jaminan
			//
			if (DDL_CL_COLCLASSIFY.SelectedValue == "") 
			{
				GlobalTools.popMessage(this, "Jenis Jaminan tidak boleh kosong!");
				return;
			}

			if(!GlobalTools.isDateValid(this, TXT_TGLPENILAIAN_DAY.Text, DDL_TGLPENILAIAN_MONTH.SelectedValue, TXT_TGLPENILAIAN_YEAR.Text))
			{
				GlobalTools.popMessage(this, "Tanggal Penilaian tidak valid!");
				GlobalTools.SetFocus(this, TXT_TGLPENILAIAN_DAY);
				return;
			}

			double pct=0, sisautil=0;
			try
			{
				sisautil = double.Parse(LBL_SISAUTILIZATION.Text);
				pct = double.Parse(TXT_LC_PERCENTAGE.Text);
			}
			catch {}
			dtColl = (DataTable) Session["dataTable"];
			DataRow dr = dtColl.NewRow();
			int seq = int.Parse(LBL_SEQ.Text) + 1;

			int count = DatGrd.Items.Count;
	
			//--- New Collateral ---//
			if (RDO_COLLATERAL.SelectedValue == "1")
			{
				//validate input
				if ((TXT_CL_DESC.Text.Trim() == "") || 
					(DDL_CL_TYPE.SelectedValue.Trim() == "") ||
					(TXT_CL_VALUE.Text.Trim() == ""))
				{
					GlobalTools.popMessage(this,"Data tidak lengkap!");
					return;
				}
				seq++;
				dr[0] = seq.ToString();
				dr[1] = DDL_CL_TYPE.SelectedValue;
				dr[2] = DDL_CL_TYPE.SelectedItem.Text;
				dr[3] = TXT_CL_DESC.Text;
				dr[4] = DDL_BUKTI_KEPEMILIKAN.SelectedValue;
				dr[5] = DDL_BUKTI_KEPEMILIKAN.SelectedItem.Text;
				dr[6] = DDL_BENTUK_PENGIKATAN.SelectedValue;
				dr[7] = DDL_BENTUK_PENGIKATAN.SelectedItem.Text;
				dr[8] = TXT_CL_FOREIGNVAL2.Text;
				dr[9] = TXT_CL_VALUE2.Text;
				dr[10] = TXT_CL_FOREIGNVAL.Text;
				dr[11] = TXT_CL_VALUE.Text;
				dr[12] = TXT_CL_FOREIGNVALINS.Text;
				dr[13] = TXT_CL_VALUEINS.Text;
				dr[14] = TXT_CL_FOREIGNVALIKAT.Text;
				dr[15] = TXT_CL_VALUEIKAT.Text;
				dr[16] = TXT_CL_FOREIGNVALPPA.Text;
				dr[17] = TXT_CL_VALUEPPA.Text;
				dr[18] = TXT_CL_FOREIGNVALLIQ.Text;
				dr[19] = TXT_CL_VALUELIQ.Text;
				dr[20] = TXT_LC_PERCENTAGE.Text;
				dr[21] = "1";
				dr[22] = DDL_CL_CURRENCY.SelectedValue;
				dr[23] = DDL_CL_COLCLASSIFY.SelectedValue;
				dr[24] = TXT_CL_EXCHANGERATE.Text;
				dr[25] = tool.ConvertDate(TXT_TGLPENILAIAN_DAY.Text,DDL_TGLPENILAIAN_MONTH.SelectedValue,TXT_TGLPENILAIAN_YEAR.Text);
				dr[26] = DDL_PENILAI_OLEH.SelectedValue;
				dr[27] = rdoAction.SelectedValue.Trim();
				dr[28] = rdoAction.SelectedItem.Text.Trim();
				//dtColl.Rows.Add(dr);
			}			
			else
			{
				//--- Existing Collateral ---//
				if (DDL_CL_TYPE_EXISTING.SelectedIndex == 0)
				{
					GlobalTools.popMessage(this, "Jaminan harus dipilih! ");
					return;
				}

				if (rdoAction.SelectedValue.Trim() == "1") //--- add ---//
				{
					if (isSeqBooked(DDL_CL_TYPE_EXISTING.SelectedValue.Trim()))
					{
						GlobalTools.popMessage(this, "Item sudah ada di daftar Existing Collateral!");
						return;
					}
					if (pct > sisautil)
					{
						GlobalTools.popMessage(this, "Utilization Melebihi Limit!");
						return;
					}
					sisautil = sisautil - pct;
					LBL_SISAUTILIZATION.Text = tool.MoneyFormat(sisautil.ToString());
				}
				else if ((rdoAction.SelectedValue.Trim() == "2")||(rdoAction.SelectedValue.Trim() == "3"))	//--- remove atau re-appraise ---//
				{
					if (!isSeqBooked(DDL_CL_TYPE_EXISTING.SelectedValue.Trim()))
					{
						GlobalTools.popMessage(this, "Item tidak ada di daftar Existing Collateral!");
						return;
					}
				}
				dr[0] = DDL_CL_TYPE_EXISTING.SelectedValue;
				dr[1] = DDL_CL_TYPE_EXISTING.SelectedItem.Text;
				//dr[2] = DDL_CL_TYPE.SelectedValue;
				dr[3] = TXT_CL_COLTYPEDESC.Text;
				dr[4] = DDL_BUKTI_KEPEMILIKAN.SelectedValue;
				dr[5] = DDL_BUKTI_KEPEMILIKAN.SelectedItem.Text;
				dr[6] = DDL_BENTUK_PENGIKATAN.SelectedValue;
				dr[7] = DDL_BENTUK_PENGIKATAN.SelectedItem.Text;
				dr[8] = TXT_CL_FOREIGNVAL2.Text;
				dr[9] = TXT_CL_VALUE2.Text;
				dr[10] = TXT_CL_FOREIGNVAL.Text;
				dr[11] = TXT_CL_VALUE.Text;
				dr[12] = TXT_CL_FOREIGNVALINS.Text;
				dr[13] = TXT_CL_VALUEINS.Text;
				dr[14] = TXT_CL_FOREIGNVALIKAT.Text;
				dr[15] = TXT_CL_VALUEIKAT.Text;
				dr[16] = TXT_CL_FOREIGNVALPPA.Text;
				dr[17] = TXT_CL_VALUEPPA.Text;
				dr[18] = TXT_CL_FOREIGNVALLIQ.Text;
				dr[19] = TXT_CL_VALUELIQ.Text;
				dr[20] = TXT_LC_PERCENTAGE.Text;
				dr[21] = "0";
				dr[22] = DDL_CL_CURRENCY.SelectedValue;
				dr[23] = DDL_CL_COLCLASSIFY.SelectedValue;
				dr[24] = TXT_CL_EXCHANGERATE.Text;
				dr[25] = tool.ConvertDate(TXT_TGLPENILAIAN_DAY.Text,DDL_TGLPENILAIAN_MONTH.SelectedValue,TXT_TGLPENILAIAN_YEAR.Text);
				dr[26] = DDL_PENILAI_OLEH.SelectedValue;
				dr[27] = rdoAction.SelectedValue.Trim();
				dr[28] = rdoAction.SelectedItem.Text.Trim();
			}
	
			for (int i = 0; i < dtColl.Rows.Count; i++)
			{
				if (dr[0].ToString().Trim() == dtColl.Rows[i][0].ToString())
				{
					GlobalTools.popMessage(this, "Item sudah ada di daftar Requested Collateral!");
					return;
				}
			}
			
			dtColl.Rows.Add(dr);

			Session.Remove("dataTable");
			Session.Add("dataTable", dtColl);
	
			ViewCollateral();
			
			LBL_SEQ.Text = seq.ToString();
				
			TXT_CL_DESC.Text = "";
			try{DDL_CL_TYPE.SelectedValue = "";}
			catch{}
			DDL_CL_TYPE_EXISTING.SelectedValue = "";
			DDL_CL_COLCLASSIFY.SelectedValue = "";
			TXT_CL_COLTYPEDESC.Text	= "";
			DDL_CL_CURRENCY.SelectedValue = "";
			TXT_CL_FOREIGNVAL.Text = "";
			TXT_CL_EXCHANGERATE.Text = "1";
			TXT_CL_VALUE.Text = "";
			TXT_LC_PERCENTAGE.Text = "100";
			rdoAction.SelectedIndex = 0;

			TXT_CL_VALUE2.Text = "";
			TXT_CL_FOREIGNVAL2.Text = "";
			TXT_CL_VALUEINS.Text = "";
			TXT_CL_FOREIGNVALINS.Text = "";
			TXT_CL_VALUEIKAT.Text = "";
			TXT_CL_FOREIGNVALIKAT.Text = "";
			TXT_CL_VALUEPPA.Text = "";
			TXT_CL_FOREIGNVALPPA.Text = "";
			TXT_CL_VALUELIQ.Text = "";
			TXT_CL_FOREIGNVALLIQ.Text = "";
			TXT_COL_ID.Text = "";
			try{DDL_BUKTI_KEPEMILIKAN.SelectedValue = "";}
			catch{}
			try{DDL_BENTUK_PENGIKATAN.SelectedValue = "";}
			catch{}
			TXT_TGLPENILAIAN_DAY.Text = "";
			try{DDL_TGLPENILAIAN_MONTH.SelectedValue = "";}
			catch{}
			TXT_TGLPENILAIAN_YEAR.Text = "";
			try{DDL_PENILAI_OLEH.SelectedValue = "";}
			catch{}
		}

		protected void BTN_SAVE_Click(object sender, System.EventArgs e)
		{
			string 	regno, curef, cl_desc, cl_type, cl_value, cl_seq, productid, 
				lc_percentage, lc_value, cl_currency, cl_colclassify, cl_foreignval, 
				cl_exchangerate, lc_action, apptype, tc, user, aano, accseq, ket,
				cl_value2, cl_valueins, cl_valueikat, cl_valueppa, cl_valueliq, 
				cl_foreignval2, cl_foreignvalins, cl_foreignvalikat, cl_foreignvalppa, cl_foreignvalliq, col_id,
				bukti_milik, bentuk_ikat, tgl_nilai, nilai_oleh, loanpurpid;

			regno		= Request.QueryString["regno"].Trim(); 
			curef		= Request.QueryString["curef"].Trim(); 
			tc			= Request.QueryString["tc"].Trim();
			productid	= DDL_PRODUCTID.SelectedValue.Trim(); 
			user		= Session["UserID"].ToString().Trim();
			apptype		= DDL_APPTYPE.SelectedValue.Trim();
			aano		= DDL_AA_NO.SelectedValue.Trim();
			accseq		= DDL_FACILITYNO.SelectedValue.Trim();
			ket			= TXT_CP_NOTES.Text.Trim();
			loanpurpid	= DDL_CP_LOANPURPOSE.SelectedValue.Trim();

			//cek apakah sudah pernah disimpan di custproduct apa belum
			//jika untuk application type dan kode kredit yang sama sudah ada maka jangan diinsert lagi
			bool isNewApp = true;
			string ket_code = Request.QueryString["ket_code"];

			try
			{
				if (ket_code == "" || ket_code == null || ket_code == "&nbsp;") 
				{
					conn.QueryString  = "select KET_CODE from KETENTUAN_KREDIT where ";
					conn.QueryString += "AP_REGNO = '" + Request.QueryString["regno"] + "'";
					conn.ExecuteQuery();
					ket_code = conn.GetFieldValue("KET_CODE");				
				}

				conn.QueryString  = "select APPTYPE from CUSTPRODUCT where ";
				conn.QueryString += "AP_REGNO = '" + Request.QueryString["regno"] + "' and ";
				conn.QueryString += "KET_CODE = '" + ket_code + "' and ";
				conn.QueryString += "APPTYPE = '" + DDL_APPTYPE.SelectedValue + "'";
				conn.ExecuteQuery();

				//jika sudah pernah ada, flag application type baru = false
				if (conn.GetRowCount() > 0) isNewApp = false;
			}
			catch(Exception)
			{
				GlobalTools.popMessage(this, "Server error");
			}
			
			string vPROD_SEQ = "0";
			if (isNewApp) //belum ada ketentuan kredit untuk aplikasi yang dipilih
			{
				try
				{
					conn.QueryString = "exec IDE_LOANINFO_PJAMINAN '" + 
						regno + "', '" + 
						apptype + "', '" + 
						productid + "', '" + 
						aano + "', '" + 
						accseq + "', '" + 
						ket + "', '" + 
						ket_code + "', '" +
						loanpurpid + "'";
					//conn.ExecuteNonQuery();
					conn.ExecuteQuery();
				}
				catch (Exception ex)
				{
					string errmsg = ex.Message.Replace("'","");
					if (errmsg.IndexOf("Last Query:") > 0)
						errmsg = errmsg.Substring(0, errmsg.IndexOf("Last Query:"));
					GlobalTools.popMessage(this, errmsg);
					return;
				}

				vPROD_SEQ = conn.GetFieldValue("PROD_SEQ");

				//--- menyimpan data parent application untuk jika sub application --//
				if (LBL_MAINREGNO.Text != "" && LBL_MAINREGNO.Text != null) 
				{
					try 
					{
						conn.QueryString = "exec IDE_LOANINFO_SUBAPP '" + 
							Request.QueryString["regno"] + "', '" + 
							DDL_APPTYPE.SelectedValue + "', '" + 
							DDL_PRODUCTID.SelectedValue + "', '" + 
							LBL_MAINREGNO.Text + "', '" +
							LBL_PRODUCTID.Text + "', '" + 
							LBL_MAINPROD_SEQ.Text + "'";
						conn.ExecuteNonQuery();					
					} 
					catch (NullReferenceException) 
					{
						GlobalTools.popMessage(this, "Connection Error!");
						return;
					}
				}

				conn.QueryString = "exec IDE_LOANINFO_GENERAL '" + 
					Request.QueryString["regno"] + "', '" + 
					DDL_APPTYPE.SelectedValue + "', '" + 
					LBL_PRODUCTID.Text + "', '" + 
					Request.QueryString["tc"] + "', '" + 
					LBL_USERID.Text + "'";
				conn.ExecuteNonQuery();

				dtColl = (DataTable) Session["dataTable"];

				for (int i = 0; i < dtColl.Rows.Count; i++)
				{
					cl_desc = dtColl.Rows[i][3].ToString();
					cl_type = dtColl.Rows[i][1].ToString();
					cl_value = tool.ConvertFloat(dtColl.Rows[i][11].ToString());
					cl_value2 = tool.ConvertFloat(dtColl.Rows[i][9].ToString());
					cl_valueins = tool.ConvertFloat(dtColl.Rows[i][13].ToString());
					cl_valueikat = tool.ConvertFloat(dtColl.Rows[i][15].ToString());
					cl_valueppa = tool.ConvertFloat(dtColl.Rows[i][17].ToString());
					cl_valueliq = tool.ConvertFloat(dtColl.Rows[i][19].ToString());
					cl_seq = dtColl.Rows[i][0].ToString();
					lc_percentage = dtColl.Rows[i][20].ToString();
					try
					{
						double val = double.Parse(dtColl.Rows[i][11].ToString()) * double.Parse(lc_percentage) / 100;
						lc_value = tool.ConvertFloat(val.ToString());
					} 
					catch {lc_value = "0";}
					cl_currency = dtColl.Rows[i][22].ToString();
					cl_colclassify = dtColl.Rows[i][23].ToString();
					cl_foreignval = tool.ConvertFloat(dtColl.Rows[i][10].ToString());
					cl_foreignval2 = tool.ConvertFloat(dtColl.Rows[i][8].ToString());
					cl_foreignvalins = tool.ConvertFloat(dtColl.Rows[i][12].ToString());
					cl_foreignvalikat = tool.ConvertFloat(dtColl.Rows[i][14].ToString());
					cl_foreignvalppa = tool.ConvertFloat(dtColl.Rows[i][16].ToString());
					cl_foreignvalliq = tool.ConvertFloat(dtColl.Rows[i][18].ToString());
					cl_exchangerate = tool.ConvertFloat(dtColl.Rows[i][24].ToString());
					lc_action = dtColl.Rows[i][27].ToString();
					bukti_milik = dtColl.Rows[i][4].ToString();
					bentuk_ikat = dtColl.Rows[i][6].ToString();
					tgl_nilai = dtColl.Rows[i][25].ToString();
					nilai_oleh = dtColl.Rows[i][26].ToString();

					if ((cl_value == "") || (cl_value == "&nbsp;"))  cl_value = "0";
					if ((cl_value2 == "") || (cl_value2 == "&nbsp;"))  cl_value2 = "0";
					if ((cl_valueins == "") || (cl_valueins == "&nbsp;"))  cl_valueins = "0";
					if ((cl_valueikat == "") || (cl_valueikat == "&nbsp;"))  cl_valueikat = "0";
					if ((cl_valueppa == "") || (cl_valueppa == "&nbsp;"))  cl_valueppa = "0";
					if ((cl_valueliq == "") || (cl_valueliq == "&nbsp;"))  cl_valueliq = "0";
					if ((cl_seq == "") || (cl_seq == "&nbsp;"))  cl_seq = "0";
					if ((lc_percentage == "") || (lc_percentage == "&nbsp;"))  lc_percentage = "0";
					if ((lc_value == "") || (lc_value == "&nbsp;"))  lc_value = "0";
					if ((cl_foreignval == "") || (cl_foreignval == "&nbsp;"))  cl_foreignval = "0";
					if ((cl_foreignval2 == "") || (cl_foreignval2 == "&nbsp;"))  cl_foreignval2 = "0";
					if ((cl_foreignvalins == "") || (cl_foreignvalins == "&nbsp;"))  cl_foreignvalins = "0";
					if ((cl_foreignvalikat == "") || (cl_foreignvalikat == "&nbsp;"))  cl_foreignvalikat = "0";
					if ((cl_foreignvalppa == "") || (cl_foreignvalppa == "&nbsp;"))  cl_foreignvalppa = "0";
					if ((cl_foreignvalliq == "") || (cl_foreignvalliq == "&nbsp;"))  cl_foreignvalliq = "0";
					if ((cl_exchangerate == "") || (cl_exchangerate == "&nbsp;"))  cl_exchangerate = "0";
					if (dtColl.Rows[i][21].ToString() == "1")
					{
						conn.QueryString = "exec IDE_LOANINFO_COLL2 '" + regno + "', '" + curef + "', '" +
							cl_desc + "', '" + cl_type + "', " + cl_value + ", " + cl_seq + ", '" + 
							productid + "', " + lc_percentage + ", " + lc_value + ", '1', '" + 
							cl_currency + "', '" + cl_colclassify + "', " + cl_foreignval + ", " + 
							cl_exchangerate + ", '" + lc_action + "', " + vPROD_SEQ + ", " +
							cl_value2 + ", " + cl_foreignval2 + ", " + cl_valueins + ", " + cl_foreignvalins + ", " + 
							cl_valueikat + ", " + cl_foreignvalikat + ", " + cl_valueppa + ", " + cl_foreignvalppa + ", " + cl_valueliq + ", " + cl_foreignvalliq + ", '" +
							bukti_milik + "', '" + bentuk_ikat + "', " + tgl_nilai + ", '" + nilai_oleh + "'";
						conn.ExecuteNonQuery();
					}
					else if (dtColl.Rows[i][21].ToString() == "0")
					{
						conn.QueryString = "exec IDE_LOANINFO_COLL2 '" + regno + "', '" + curef + "', "+
							"NULL, NULL, " + cl_value + ", " + cl_seq + ", '" + 
							productid + "', " + lc_percentage + ", " + lc_value + ", '2', '" + 
							cl_currency + "', '" + cl_colclassify + "', " + cl_foreignval + ", " + 
							cl_exchangerate + ", '" + lc_action + "', " + vPROD_SEQ + ", " +
							cl_value2 + ", " + cl_foreignval2 + ", " + cl_valueins + ", " + cl_foreignvalins + ", " +
							cl_valueikat + ", " + cl_foreignvalikat + ", " + cl_valueppa + ", " + cl_foreignvalppa + ", " + cl_valueliq + ", " + cl_foreignvalliq + ", '" +
							bukti_milik + "', '" + bentuk_ikat + "', " + tgl_nilai + ", '" + nilai_oleh + "'";
						conn.ExecuteNonQuery();
					}
				}
				//Clear();
				ViewApplications();
			} 
			else
			{
				GlobalTools.popMessage(this, "Jenis pengajuan pinjaman yang diminta sudah ada!");
			}


			Button1.Enabled = true;
			Button2.Enabled = true;
		}

		protected void Button2_Click(object sender, System.EventArgs e)
		{
			try
			{
				Session.Remove("dataTable");
			} 
			catch {}
			Response.Redirect("FairIsaac.aspx?regno=" + Request.QueryString["regno"] + "&curef=" + Request.QueryString["curef"] + "&prog=" + Request.QueryString["prog"] + "&tc=" + Request.QueryString["tc"] + "&mc=" + Request.QueryString["mc"]);
		}

		private void DatGrd_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			string seq = null;

			switch (((LinkButton)e.CommandSource).CommandName)
			{
				case "delete":
					seq = e.Item.Cells[0].Text;
					dtColl = (DataTable) Session["dataTable"];
					
					for (int i = 0; i < dtColl.Rows.Count; i++)
						if (dtColl.Rows[i]["CL_SEQ"].ToString() == seq)
							dtColl.Rows[i].Delete();
					
					Session.Remove("dataTable");
					Session.Add("dataTable", dtColl);

					//DatGrd.DataSource = new DataView(dtColl);
					//DatGrd.DataBind();

					/*
					conn.QueryString = "exec IDE_LOANINFOCOLL '" + Request.QueryString["curef"] + "', '', null, " + 
						e.Item.Cells[0].Text + ", '2'";
					conn.ExecuteNonQuery();
					*/
					break;
			}
			ViewCollateral();
		}

		protected void RDO_COLLATERAL_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if (RDO_COLLATERAL.SelectedValue == "1")
			{
				DDL_CL_TYPE.Visible				= true;
				DDL_CL_TYPE_EXISTING.Visible	= false;
				TXT_CL_DESC.Visible				= true;
				TXT_CL_COLTYPEDESC.Visible		= false;
				DDL_CL_CURRENCY.Enabled			= true;
				LBL_SISAUTILIZATION.Text		= "100";
				fillAction(true);
			}
			else 
			{
				DDL_CL_TYPE.Visible				= false;
				DDL_CL_TYPE_EXISTING.Visible	= true;
				TXT_CL_DESC.Visible				= false;
				TXT_CL_COLTYPEDESC.Visible		= true;
				TXT_CL_COLTYPEDESC.Text			= "";
				DDL_CL_CURRENCY.Enabled			= false;
				fillAction(false);
				fillExisting();
			}
			Clear(true);
		}

		protected void DDL_CL_TYPE_EXISTING_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			try 
			{
				double sisa=0;
				LBL_SISAUTILIZATION.Text = "100";
				conn.QueryString = "select coltypedesc, cl_value , cl_colclassify, cl_currency, cl_exchangerate, cl_foreignval, sisautilization, sibs_colid, " +
					"cl_value2, cl_foreignval2, cl_valueins, cl_foreignvalins, cl_valueikat, cl_foreignvalikat, cl_valueppa, cl_foreignvalppa, cl_valueliq, cl_foreignvalliq, " +
					"cl_certtype1, cl_certtype1desc, cl_ikatid, ikatdesc, cl_penilaiandate, cl_penilaianby, cl_penilaianbydesc " +
					"from vw_collateral_ubahjaminan2 where cu_ref='" + Request.QueryString["curef"] + 
					"' and cl_seq='" + DDL_CL_TYPE_EXISTING.SelectedValue + "'";
				conn.ExecuteQuery();
				TXT_CL_COLTYPEDESC.Text = conn.GetFieldValue(0, "coltypedesc");
				TXT_CL_VALUE.Text = tool.MoneyFormat(conn.GetFieldValue(0, "cl_value"));
				if (conn.GetFieldValue(0, "cl_foreignval") != "")
					TXT_CL_FOREIGNVAL.Text = tool.MoneyFormat(conn.GetFieldValue(0, "cl_foreignval"));
				else
					TXT_CL_FOREIGNVAL.Text = tool.MoneyFormat(conn.GetFieldValue(0, "cl_value"));
				if (conn.GetFieldValue(0, "cl_exchangerate") != "")
					TXT_CL_EXCHANGERATE.Text = tool.MoneyFormat(conn.GetFieldValue(0, "cl_exchangerate"));
				else
					TXT_CL_EXCHANGERATE.Text = tool.MoneyFormat("1");
				try {DDL_CL_COLCLASSIFY.SelectedValue = conn.GetFieldValue(0, "cl_colclassify");}
				catch {}
				try{DDL_CL_CURRENCY.SelectedValue = conn.GetFieldValue(0, "cl_currency");} 
				catch {}
				try{DDL_BUKTI_KEPEMILIKAN.SelectedValue = conn.GetFieldValue(0, "cl_certtype1");}
				catch {}
				try{DDL_BENTUK_PENGIKATAN.SelectedValue = conn.GetFieldValue(0, "cl_ikatid");}
				catch {}
				TXT_CL_VALUE2.Text = tool.MoneyFormat(conn.GetFieldValue(0, "cl_value2"));
				TXT_CL_VALUEINS.Text = tool.MoneyFormat(conn.GetFieldValue(0, "cl_valueins"));
				TXT_CL_VALUEIKAT.Text = tool.MoneyFormat(conn.GetFieldValue(0, "cl_valueikat"));
				TXT_CL_VALUEPPA.Text = tool.MoneyFormat(conn.GetFieldValue(0, "cl_valueppa"));
				TXT_CL_VALUELIQ.Text = tool.MoneyFormat(conn.GetFieldValue(0, "cl_valueliq"));
				if (conn.GetFieldValue(0, "cl_foreignval2") != "")
					TXT_CL_FOREIGNVAL2.Text = tool.MoneyFormat(conn.GetFieldValue(0, "cl_foreignval2"));
				else
					TXT_CL_FOREIGNVAL2.Text = tool.MoneyFormat(conn.GetFieldValue(0, "cl_value2"));
				if (conn.GetFieldValue(0, "cl_foreignvalins") != "")
					TXT_CL_FOREIGNVALINS.Text = tool.MoneyFormat(conn.GetFieldValue(0, "cl_foreignvalins"));
				else
					TXT_CL_FOREIGNVALINS.Text = tool.MoneyFormat(conn.GetFieldValue(0, "cl_valueins"));
				if (conn.GetFieldValue(0, "cl_foreignvalikat") != "")
					TXT_CL_FOREIGNVALIKAT.Text = tool.MoneyFormat(conn.GetFieldValue(0, "cl_foreignvalikat"));
				else
					TXT_CL_FOREIGNVALIKAT.Text = tool.MoneyFormat(conn.GetFieldValue(0, "cl_valueikat"));
				if (conn.GetFieldValue(0, "cl_foreignvalppa") != "")
					TXT_CL_FOREIGNVALPPA.Text = tool.MoneyFormat(conn.GetFieldValue(0, "cl_foreignvalppa"));
				else
					TXT_CL_FOREIGNVALPPA.Text = tool.MoneyFormat(conn.GetFieldValue(0, "cl_valueppa"));
				if (conn.GetFieldValue(0, "cl_foreignvalliq") != "")
					TXT_CL_FOREIGNVALLIQ.Text = tool.MoneyFormat(conn.GetFieldValue(0, "cl_foreignvalliq"));
				else
					TXT_CL_FOREIGNVALLIQ.Text = tool.MoneyFormat(conn.GetFieldValue(0, "cl_valueliq"));
				TXT_TGLPENILAIAN_DAY.Text = tool.FormatDate_Day(conn.GetFieldValue("cl_penilaiandate"));
				try {DDL_TGLPENILAIAN_MONTH.SelectedValue	= tool.FormatDate_Month(conn.GetFieldValue("cl_penilaiandate"));}
				catch {}
				TXT_TGLPENILAIAN_YEAR.Text = tool.FormatDate_Year(conn.GetFieldValue("cl_penilaiandate"));
				try {DDL_PENILAI_OLEH.SelectedValue = conn.GetFieldValue("cl_penilaianby");}
				catch {}

				conn.QueryString = "select sisautilization " +
					"from vw_collateral_ubahjaminan2 where ap_regno='" + Request.QueryString["regno"] + 
					"' and cl_seq='" + DDL_CL_TYPE_EXISTING.SelectedValue + "'";
				conn.ExecuteQuery();
				try
				{
					LBL_SISAUTILIZATION.Text = tool.MoneyFormat(conn.GetFieldValue(0, "sisautilization"));
				} 
				catch {}
				//if (conn.GetFieldValue(0, "sibs_colid") != "") LBL_SISAUTILIZATION.Text = "100";
				sisa = double.Parse(LBL_SISAUTILIZATION.Text) - usedUtilization(DDL_CL_TYPE_EXISTING.SelectedValue.Trim());
				LBL_SISAUTILIZATION.Text = tool.MoneyFormat(sisa.ToString());
			}
			catch {}
		}

		private void DatGrd_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			DatGrd.CurrentPageIndex = e.NewPageIndex;
			ViewCollateral();
		}

		protected void Button1_Click(object sender, System.EventArgs e)
		{
			//conn.QueryString = "select checkbi from customer where cu_ref='" + Request.QueryString["curef"] + "'";
			conn.QueryString = "select ap_checkbi from application where ap_regno='" + Request.QueryString["regno"] + "'";
			conn.ExecuteQuery();
			if (conn.GetRowCount() > 0)
			{
				if (conn.GetFieldValue(0,0) == "1")
				{
					conn.QueryString = "insert into bi_status (ap_regno, cu_ref, bs_reqdate, bs_recvdate, bs_bidataavail, bs_complete) " + 
						"values ('" + Request.QueryString["regno"] + "', '" + Request.QueryString["curef"] + "', getdate(), null, null, '0')";
					conn.ExecuteQuery();
				}
			}

			DataTable dt;
			conn.QueryString = "select apptype, productid, PROD_SEQ from custproduct where ap_regno='" + Request.QueryString["regno"] +
				"' AND isnull(cp_reject,'0') <> '1' and isnull(cp_cancel,'0') <> '1'";
			conn.ExecuteQuery();
			dt = conn.GetDataTable().Copy();
			for (int i = 0; i < dt.Rows.Count; i++)
			{
				conn.QueryString = "exec TRACKUPDATE '" + Request.QueryString["regno"] + "', '" +
					dt.Rows[i][1].ToString() + "', '" + dt.Rows[i][0].ToString() + "', '" + LBL_USERID.Text + "', '" + dt.Rows[i]["PROD_SEQ"].ToString() + "','"+Request.QueryString["tc"].Trim()+"'";
				//dt.Rows[i][1].ToString() + "', '" + dt.Rows[i][0].ToString() + "', '" + Session["UserID"].ToString() + "'";
				conn.ExecuteNonQuery();
			}
			Response.Redirect("FindCustomer.aspx?tc=" + Request.QueryString["tc"] + "&mc=" + Request.QueryString["mc"]);
		}

		private void DatGrdOld_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			DatGrdOld.CurrentPageIndex = e.NewPageIndex;
			bindData();
		}

		protected void DDL_CL_CURRENCY_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			try 
			{
				conn.QueryString = "select CURRENCYRATE from RFCURRENCY where CURRENCYID = '" + DDL_CL_CURRENCY.SelectedValue + "'";
				conn.ExecuteQuery();

				TXT_CL_EXCHANGERATE.Text = tool.MoneyFormat(conn.GetFieldValue("CURRENCYRATE"));
			}
			catch (NullReferenceException) 
			{
				GlobalTools.popMessage(this, "Connection Error !");
				return;
			}
		}
	}
}