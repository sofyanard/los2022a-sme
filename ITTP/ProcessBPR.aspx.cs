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
using DMS.DBConnection;
using DMS.CuBESCore;

namespace SME.ITTP
{
	/// <summary>
	/// Summary description for ProcessBPR.
	/// </summary>
	public partial class ProcessBPR : System.Web.UI.Page
	{
		protected Tools tool = new Tools();
		protected Connection conn;

		private string APPTYPE;
		private string CUREF;
		private string TC;
		private string MC;
		private string KET_CODE;
		private string PROG;
		private string PROD;
		private string regno;
		private string view;
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			conn = (Connection) Session["Connection"];

			Session["curef"] = Request.QueryString["curef"];
			Session["tc"] = Request.QueryString["tc"];
			Session["mc"] = Request.QueryString["mc"];

			CUREF	= Session["curef"].ToString();
			//PROG	= Session["prog"].ToString();
			TC		= Session["tc"].ToString();
			MC		= Session["mc"].ToString();

			APPTYPE			= Request.QueryString["app"]; 
			PROG			= Request.QueryString["prog"];
			PROD			= Request.QueryString["prod"];
			regno			= Request.QueryString["regno"];
			//CUREF			= Request.QueryString["curef"];
			KET_CODE		= Request.QueryString["ket_code"];
			//TC				= Request.QueryString["tc"];
			//MC				= Request.QueryString["mc"];
			view			= Request.QueryString["view"];


			//if (!Logic.AllowAccess(Session["GroupID"].ToString(), Request.QueryString["mc"], conn))
			//	Response.Redirect("/SME/Restricted.aspx");

			cekIsView(view);

			if (!IsPostBack)
			{

				viewExchangeRate();

				LBL_USERID.Text	 = Session["UserID"].ToString();
				TXT_CP_EXLIMITVAL.Text = "5.000.000";
				TXT_CP_LIMIT.Text = "5.000.000";
				
				//TR_COLL1.Visible			= false;

				//GlobalTools.fillRefList(DDL_AANO, "select distinct aa_no, aa_no from VW_IT_FACILITY where cu_ref='" + CUREF + "'", false, conn);

				//--- Application Type
				/*DDL_APPTYPE.Items.Add(new ListItem("- PILIH -", "0"));
				conn.QueryString = "select apptypeid, apptypedesc from rfapplicationtype where apptypeid like 'T%' and active='1'";
				conn.ExecuteQuery();
				for (int i = 0; i < conn.GetRowCount(); i++)
					DDL_APPTYPE.Items.Add(new ListItem(conn.GetFieldValue(i,1), conn.GetFieldValue(i,0)));*/

				//--- Product
				DDL_PRODUCTID.Items.Add(new ListItem("Tabungan", "0"));
				conn.QueryString = "select productid, productdesc from VW_PROGPROD where PROGRAMID='" + PROG + "' and ACTIVE='1'";
				conn.ExecuteQuery();
				for (int i = 0; i < conn.GetRowCount(); i++)
					DDL_PRODUCTID.Items.Add(new ListItem(conn.GetFieldValue(i,1), conn.GetFieldValue(i,0)));

				/*
							conn.ExecuteQuery();
							for (int i = 0; i < conn.GetRowCount(); i++)
								DDL_PRODUCTID.Items.Add(new ListItem(conn.GetFieldValue(i,0) + " - " + conn.GetFieldValue(i,1), conn.GetFieldValue(i,0)));

							try {DDL_APPTYPE.SelectedValue	= Request.QueryString["app"];}
							catch {DDL_APPTYPE.SelectedValue = "";}
							try {DDL_PRODUCTID.SelectedValue = Request.QueryString["prod"];}
							catch {DDL_PRODUCTID.SelectedValue = "";}
			*/
				//--- Tenor
				/*DDL_CP_TENORCODE.Items.Add(new ListItem("- PILIH -", ""));
				conn.QueryString = "select tenorcode, tenordesc from rftenorcode where active='1'";
				conn.ExecuteQuery();
				for (int i = 0; i < conn.GetRowCount(); i++)
					DDL_CP_TENORCODE.Items.Add(new ListItem(conn.GetFieldValue(i,1), conn.GetFieldValue(i,0)));
				try
				{
					DDL_CP_TENORCODE.SelectedValue = "M";
				}
				catch {}*/

				//--- Loan Purpose
				DDL_CP_LOANPURPOSE.Items.Add(new ListItem("Simpanan", ""));
				conn.QueryString = "select LOANPURPID, LOANPURPID + ' - ' + LOANPURPDESC as LOANPURPDESC from RFLOANPURPOSE where ACTIVE='1' order by LOANPURPID";
				conn.ExecuteQuery();
				for (int i = 0; i < conn.GetRowCount(); i++)
					DDL_CP_LOANPURPOSE.Items.Add(new ListItem(conn.GetFieldValue(i,1), conn.GetFieldValue(i,0)));

		
				//--- Jenis Jaminan
				/*DDL_CL_TYPE.Items.Add(new ListItem("- PILIH -", ""));
				conn.QueryString = "select COLTYPESEQ, COLTYPEID + ' - ' + COLTYPEDESC as COLTYPEDESC from RFCOLLATERALTYPE where ACTIVE='1' order by COLTYPEID";
				conn.ExecuteQuery();
				for (int i = 0; i < conn.GetRowCount(); i++)
					DDL_CL_TYPE.Items.Add(new ListItem(conn.GetFieldValue(i,1), conn.GetFieldValue(i,0)));*/

				//--- Currency
				//DDL_CL_CURRENCY.Items.Add(new ListItem("- PILIH -", ""));
				//DDL_CL_CURRENCY2.Items.Add(new ListItem("- PILIH -", ""));
				//conn.QueryString = "select currencyid, currencyid+' - '+currencydesc from rfcurrency where active='1' order by currencyid";
				/*conn.QueryString = "select currencyid, currencydesc from rfcurrency where active='1' order by currencyid";
				conn.ExecuteQuery();
				for (int i = 0; i < conn.GetRowCount(); i++)
					DDL_CL_CURRENCY.Items.Add(new ListItem(conn.GetFieldValue(i,0) + " - " + conn.GetFieldValue(i,1), conn.GetFieldValue(i,0)));
				try
				{
					DDL_CL_CURRENCY.SelectedValue = "IDR";
				}
				catch{}*/
				/*
				conn.QueryString = "select currencyid, currencydesc from rfcurrency where active='1' order by currencyid";
				conn.ExecuteQuery();
				for (int i = 0; i < conn.GetRowCount(); i++)
					DDL_CL_CURRENCY2.Items.Add(new ListItem(conn.GetFieldValue(i,0) + " - " + conn.GetFieldValue(i,1), conn.GetFieldValue(i,0)));
				try
				{
					DDL_CL_CURRENCY2.SelectedValue = "IDR";
				}
				catch{}
				*/
				//--- Klasifikasi Jaminan
				/*DDL_CL_COLCLASSIFY.Items.Add(new ListItem("- PILIH -", ""));
				conn.QueryString = "select colclassid, colclassdesc from rfcollclass where active='1'";
				conn.ExecuteQuery();
				for (int i = 0; i < conn.GetRowCount(); i++)
					DDL_CL_COLCLASSIFY.Items.Add(new ListItem(conn.GetFieldValue(i,1), conn.GetFieldValue(i,0)));

				DDL_CL_TYPE_EXISTING.Items.Add(new ListItem("- PILIH -", "0"));*/

				//--- Bukti Kepemilikan
				/*DDL_BUKTI_KEPEMILIKAN.Items.Add(new ListItem("- PILIH -", ""));
				conn.QueryString = "SELECT CERTTYPEID, CERTTYPEDESC FROM RFCERTTYPE WHERE ACTIVE = '1' ORDER BY CERTTYPEDESC";
				conn.ExecuteQuery();
				for (int i = 0; i < conn.GetRowCount(); i++)
					DDL_BUKTI_KEPEMILIKAN.Items.Add(new ListItem(conn.GetFieldValue(i,1), conn.GetFieldValue(i,0)));*/

				//--- Bentuk Pengikatan
				/*DDL_BENTUK_PENGIKATAN.Items.Add(new ListItem("- PILIH -", ""));
				conn.QueryString = "SELECT IKATID, IKATDESC FROM RFIKAT WHERE ACTIVE = '1' ORDER BY IKATID";
				conn.ExecuteQuery();
				for (int i = 0; i < conn.GetRowCount(); i++)
					DDL_BENTUK_PENGIKATAN.Items.Add(new ListItem(conn.GetFieldValue(i,1), conn.GetFieldValue(i,0)));*/

				//--- Tanggal Penilaian
				/*DDL_TGLPENILAIAN_MONTH.Items.Add(new ListItem("- PILIH -", ""));
				for (int i = 1; i <= 12; i++)
				{
					DDL_TGLPENILAIAN_MONTH.Items.Add(new ListItem(DateAndTime.MonthName(i, false), i.ToString()));
				}*/

				//--- Penilaian Oleh
				/*DDL_PENILAI_OLEH.Items.Add(new ListItem("- PILIH -", ""));
				conn.QueryString = "select ACCRDTOID, ACCRDTODESC from RFVALUEACCORDING where active='1'";
				conn.ExecuteQuery();
				for (int i = 0; i < conn.GetRowCount(); i++)
					DDL_PENILAI_OLEH.Items.Add(new ListItem(conn.GetFieldValue(i,1), conn.GetFieldValue(i,0)));*/
				
				/*dtColl = (DataTable) Session["dataTable"];
				try
				{
					if (dtColl.Rows.Count > 0)
						ViewCollateral();
				}
				catch 
				{			
					dtColl = new DataTable();
					dtColl.Columns.Add(new DataColumn("CL_SEQ"));
					dtColl.Columns.Add(new DataColumn("COLTYPEID"));
					dtColl.Columns.Add(new DataColumn("COLTYPEDESC"));
					dtColl.Columns.Add(new DataColumn("CL_DESC"));
					dtColl.Columns.Add(new DataColumn("CL_CERTTYPE1"));
					dtColl.Columns.Add(new DataColumn("CL_CERTTYPE1DESC"));
					dtColl.Columns.Add(new DataColumn("CL_IKATID"));
					dtColl.Columns.Add(new DataColumn("CL_IKATIDDESC"));
					dtColl.Columns.Add(new DataColumn("CL_VALUE2"));
					dtColl.Columns.Add(new DataColumn("CL_VALUE"));
					dtColl.Columns.Add(new DataColumn("CL_VALUEINS"));
					dtColl.Columns.Add(new DataColumn("CL_VALUEIKAT"));
					dtColl.Columns.Add(new DataColumn("CL_VALUEPPA"));
					dtColl.Columns.Add(new DataColumn("CL_VALUELIQ"));
					dtColl.Columns.Add(new DataColumn("LC_PERCENTAGE"));
					dtColl.Columns.Add(new DataColumn("ISNEW"));
					dtColl.Columns.Add(new DataColumn("CL_CURRENCY"));
					dtColl.Columns.Add(new DataColumn("CL_COLCLASSIFY"));
					dtColl.Columns.Add(new DataColumn("CL_FOREIGNVAL2"));
					dtColl.Columns.Add(new DataColumn("CL_FOREIGNVAL"));
					dtColl.Columns.Add(new DataColumn("CL_FOREIGNVALINS"));
					dtColl.Columns.Add(new DataColumn("CL_FOREIGNVALIKAT"));
					dtColl.Columns.Add(new DataColumn("CL_FOREIGNVALPPA"));
					dtColl.Columns.Add(new DataColumn("CL_FOREIGNVALLIQ"));
					dtColl.Columns.Add(new DataColumn("CL_EXCHANGERATE"));
					dtColl.Columns.Add(new DataColumn("CL_PENILAIANDATE"));
					dtColl.Columns.Add(new DataColumn("CL_PENILAIANBY"));
					dtColl.Columns.Add(new DataColumn("SIBS_COLID"));
					Session.Add("dataTable", dtColl);
					ViewCollateral();
				}

				conn.QueryString = "select isnull(max(cl_seq),0) from collateral where cu_ref='" + CUREF + "'";
				conn.ExecuteQuery();
				LBL_SEQ.Text = conn.GetFieldValue(0,0);*/

				/*conn.QueryString = "select cl_seq, cl_desc, cl_utilization, cl_apprvalue, sibs_colid " + 
					"from collateral where cu_ref='" + Request.QueryString["curef"] + "' " +
					"and ((sibs_colid is not null and sibs_colid <> '') or cl_seq in (select cl_seq from " + 
					"listcollateral where ap_regno = '" + Request.QueryString["regno"] + "'))";
				conn.ExecuteQuery();

				for (int i = 0; i < conn.GetRowCount(); i++)
					DDL_CL_TYPE_EXISTING.Items.Add(new ListItem(conn.GetFieldValue(i,1) + " [" + conn.GetFieldValue(i, "sibs_colid") + "]", conn.GetFieldValue(i,0)));*/

				//ViewCollateral();
				ViewApplications();

				/*conn.QueryString = "select withdrawl from rfprogram where programid='" + PROG + "'";
				conn.ExecuteQuery();
				if (conn.GetRowCount() > 0 && conn.GetFieldValue(0,0) == "0")
					DDL_APPTYPE.Items.Remove(DDL_APPTYPE.Items.FindByValue("06"));*/

				//ViewMenu();
				
			}

			

			/*if (RDO_NCL.SelectedValue == "1")
			{
				DDL_AANO.Enabled = true;
				DDL_AANO.CssClass = "mandatoryColl";
				DDL_PRODUCTID1.Enabled = true;
				DDL_ACC_SEQ.Enabled = true;
				LBL_REMAINING.Enabled = true;
				LBL_PENDING.Enabled = true;
			}
			else
			{
				DDL_AANO.SelectedValue = "";
				DDL_PRODUCTID1.SelectedValue = "";
				DDL_ACC_SEQ.SelectedValue = "";
				LBL_CP_LIMIT.Text = "";
				LBL_TRX_LIMIT.Text = "";
				DDL_AANO.Enabled = false;
				DDL_PRODUCTID1.Enabled = false;
				DDL_ACC_SEQ.Enabled = false;
				LBL_REMAINING.Enabled = false;
				LBL_PENDING.Enabled = false;

			}*/
			

			/*if (RDO_COLLATERAL.SelectedValue == "1")
			{
				DDL_CL_TYPE.Visible = true;
				DDL_CL_TYPE.CssClass = "mandatoryColl";
				DDL_CL_TYPE_EXISTING.Visible = false;
				DDL_CL_TYPE_EXISTING.CssClass = "";
				TXT_CL_DESC.ReadOnly = false;
				DDL_CL_CURRENCY.Enabled = true;
				Label1.Text = "Jenis Jaminan";
				Label2.Text = "Keterangan";
				LBL_SISAUTILIZATION.Text = "100";
				DDL_CL_TYPE_EXISTING.SelectedValue = "0";
			}
			else 
			{
				DDL_CL_TYPE.Visible = false;
				DDL_CL_TYPE.CssClass = "";
				DDL_CL_TYPE_EXISTING.Visible = true;
				DDL_CL_TYPE_EXISTING.CssClass = "mandatoryColl";
				TXT_CL_DESC.ReadOnly = true;
				DDL_CL_CURRENCY.Enabled = false;
				Label1.Text = "Keterangan";
				Label2.Text = "Jenis Jaminan";
			}*/

			/*if (CHK_COLLATERAL.Checked == true) 
			{
				TR_COLL2.Visible = true;
				TR_BUTTONS2.Visible = true;
				TR_BUTTONS1.Visible	= true;
			}
			else 
			{
				TR_COLL2.Visible = false;
				TR_BUTTONS2.Visible = false;
				TR_BUTTONS1.Visible	= false;
			}*/


			secureData();
			ViewMenu();

			BTN_INSCOLL.Attributes.Add("onclick","if(!cek_mandatoryColl(document.Form1)){return false;};");
			//BTN_SAVECOLL.Attributes.Add("onclick","if(!cek_mandatory(document.Form1)){return false;};");
			//BTN_SAVE.Attributes.Add("onclick","if(!update()){return false;};");
			BTN_ADD.Attributes.Add("onclick","if(!cek_mandatory(document.Form1)){return false;};");
		}
			
		protected void BTN_ADD_Click(object sender, System.EventArgs e)
		{
			
			//RDO_NCL.Enabled				= false;
			//DDL_AANO.Enabled			= false;
			//DDL_PRODUCTID1.Enabled		= false;
			//DDL_ACC_SEQ.Enabled			= false;
			//DDL_AANO.Enabled			= false;
			//TXT_CP_NOTES.ReadOnly		= true;
			//DDL_APPTYPE.Enabled		= false;
			TR_COLL1.Visible			= true;
			//Tools.popMessage(this,DDL_CP_LOANPURPOSE.SelectedValue.ToString());
			addLoan();

			conn.QueryString = "select KET_CODE from KETENTUAN_KREDIT where AP_REGNO = '" + regno + "' order by KET_CODE desc";
			conn.ExecuteQuery();
			if (conn.GetRowCount() > 0)
			{
				LBL_KET_CODE.Text = conn.GetFieldValue(0, "KET_CODE");
			}
			try 
			{
				/*conn.QueryString = "exec IT_IDE_LOANINFO_PBARU '" + 
					Request.QueryString["regno"] + "', '" + 
					DDL_APPTYPE.SelectedValue + "', '" + 
					DDL_PRODUCTID.SelectedValue + "', " + 
					tool.ConvertFloat(TXT_CP_LIMIT.Text) + ", '" + 
					DDL_CP_LOANPURPOSE.SelectedValue + "', " +
					tool.ConvertFloat(TXT_CP_EXRPLIMIT.Text) + ", " + 
					tool.ConvertFloat(TXT_CP_EXLIMITVAL.Text) + ", '" + 
					TXT_CP_NOTES.Text + "', " + 
					TXT_CP_JANGKAWKT.Text + ", " + 
					tool.ConvertNull(DDL_CP_TENORCODE.SelectedValue) + " " ;*/
				//tool.ConvertNull(DDL_PROJECT_CODE.SelectedValue) + ", '" +
				//alihdeb + "', '" +
				//TXT_OLDCIFNO.Text + "', '" +
				//TXT_OLDACCNO.Text + "'";
				//conn.ExecuteQuery();
			} 
			catch (Exception ex)
			{
				string errmsg = ex.Message.Replace("'","");
				if (errmsg.IndexOf("Last Query:") > 0)
					errmsg = errmsg.Substring(0, errmsg.IndexOf("Last Query:"));
				GlobalTools.popMessage(this, errmsg);
				return;
			}

			try 
			{
				/*conn.QueryString = "exec IT_IDE_LOANINFO_GENERAL '" + 
					Request.QueryString["regno"] + "', '" + 
					DDL_APPTYPE.SelectedValue + "', '" + 
					DDL_PRODUCTID.SelectedValue + "', '" + 
					Request.QueryString["tc"] + "', '" + 
					LBL_USERID.Text + "'";
				conn.ExecuteNonQuery();*/
			} 

			catch (NullReferenceException) 
			{
				GlobalTools.popMessage(this, "Connection Error!");
				return;
			}
			ViewApplications();
			Clear1();

			Tools.popMessage(this,"Pastikan data yang anda input sudah benar");
		}
		
		protected void BTN_CANCEL_Click(object sender, System.EventArgs e)
		{
			//creddetail.Attributes.Add("src","");
			//TXT_CP_NOTES.Text = "";
			TR_COLL2.Visible = false;
			TR_COLL2.Visible = false;

			TR_BUTTONS1.Visible	= false;


			/*RDO_NCL.Enabled = true;
			TXT_CP_NOTES.ReadOnly = false;*/

			BTN_SAVE.Enabled = false;

			/*DDL_AANO.Enabled	= true;
			DDL_PRODUCTID1.Enabled		= true;
			DDL_ACC_SEQ.Enabled			= true;
			DDL_APPTYPE.Enabled			= true;*/
			TR_COLL1.Visible			= false;
		}


		private void cekIsView(string view) 
		{
			if (view == "1") 
			{
				//TR_JENISPENGAJUAN.Visible	= true;
				TR_COLL1.Visible			= true;
				TR_COLL2.Visible			= false;
				TR_BUTTONS1.Visible			= false;
				//TR_BUTTONS2.Visible			= false;
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

			
		private void CHK_COLLATERAL_CheckedChanged(object sender, System.EventArgs e)
		{
			/*if (CHK_COLLATERAL.Checked == true) 
			{
				TR_COLL2.Visible = true;
				TR_BUTTONS2.Visible = true;
			}
			else 
			{
				TR_COLL2.Visible = false;
				//TR_BUTTONS2.Visible = false;
			}*/
		}

		private void ViewCollateral()
		{
			double nilaiAkhir = 0;

			/*dtColl = (DataTable) Session["dataTable"];
			DatGrd.DataSource = dtColl;
			DatGrd.DataBind();

			for (int i = 0; i < DatGrd.Items.Count; i++)
			{
				nilaiAkhir = double.Parse(DatGrd.Items[i].Cells[9].Text) * double.Parse(DatGrd.Items[i].Cells[14].Text) / 100;
				DatGrd.Items[i].Cells[15].Text = tool.MoneyFormat(nilaiAkhir.ToString());
			}*/
		}

		private void ViewApplications()
		{
			DataTable dt1 = new DataTable();
			conn.QueryString = "select * from VW_IT_IDE_LISTAPPLICATION where ap_regno='" + regno + "' ";
			conn.ExecuteQuery();
			dt1 = conn.GetDataTable().Copy();
			DATAGRID1.DataSource = dt1;
			DATAGRID1.DataBind();

			for (int i = 0; i < DATAGRID1.Items.Count; i++)
			{
				if (DATAGRID1.Items[i].Cells[5].Text != "&nbsp;")
					DATAGRID1.Items[i].Cells[5].Text = tool.MoneyFormat(DATAGRID1.Items[i].Cells[5].Text);
				if  (DATAGRID1.Items[i].Cells[7].Text != "&nbsp;")
					DATAGRID1.Items[i].Cells[7].Text = tool.MoneyFormat(DATAGRID1.Items[i].Cells[7].Text);
			}
		}

		private void Clear()
		{
			/*DDL_CL_TYPE.SelectedValue = "";
			DDL_CL_TYPE_EXISTING.SelectedValue = "0";
			DDL_CL_COLCLASSIFY.SelectedValue = "";
			DDL_CL_CURRENCY.SelectedValue = "";
			TXT_CL_FOREIGNVAL.Text = "";
			TXT_CL_EXCHANGERATE.Text = "1";
			TXT_CL_VALUE.Text = "";


			TXT_COL_ID.Text = "";
			DDL_BUKTI_KEPEMILIKAN.SelectedValue = "";
			DDL_BENTUK_PENGIKATAN.SelectedValue = "";
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
			DDL_TGLPENILAIAN_MONTH.SelectedValue = "";
			TXT_TGLPENILAIAN_YEAR.Text = "";
			DDL_PENILAI_OLEH.SelectedValue = "";*/
			
			/*dtColl = (DataTable) Session["dataTable"];
			int count = dtColl.Rows.Count;

			for (int i = 0;	i < count; i++)
				dtColl.Rows[0].Delete();

			Session.Remove("dataTable");
			Session.Add("dataTable", dtColl);
			
			DatGrd.DataSource = dtColl;*/
			DatGrd.DataBind();
		}

		private void Clear1()
		{
			//LBL_CP_LIMIT.Text = "";
			TXT_CP_LIMIT.Text = "";
			//DDL_CP_LOANPURPOSE.SelectedValue ="";
			//LBL_TRX_LIMIT.Text = "";
			TXT_CP_EXRPLIMIT.Text = "";
			/*TXT_CP_JANGKAWKT.Text = "";
			DDL_CP_TENORCODE.SelectedValue = "";
			TXT_CP_NOTES.Text = "";
			DDL_APPTYPE.SelectedValue = "0";

			DDL_AANO.SelectedValue = "";
			DDL_PRODUCTID1.SelectedValue = "";
			DDL_ACC_SEQ.SelectedValue = "";*/

			DDL_PRODUCTID.SelectedValue = "0";
			//DDL_PRODUCTID.Enabled = true;

			TXT_CP_EXLIMITVAL.Text = "";
		}

		
		private void viewExchangeRate() 
		{
			try 
			{
				conn.QueryString = "select PRODUCTID, CURRENCY, C.CURRENCYRATE " +
					"from RFPRODUCT p " +
					"left join RFCURRENCY c on P.CURRENCY = C.CURRENCYID " +
					"where C.ACTIVE = '1' and P.ACTIVE = '1' and PRODUCTID = '" + Request.QueryString["prod"] + "'";
				conn.ExecuteQuery();

				TXT_CP_EXRPLIMIT.Text = conn.GetFieldValue("CURRENCYRATE");
			} 
			catch (NullReferenceException) 
			{
				Tools.popMessage(this, "Connection Error !");
				return;
			}
		}

		private void DATAGRID1_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{

			switch (((LinkButton)e.CommandSource).CommandName)
			{
				case "delete":

					string de = Request.QueryString["de"];
					if (de == "1")
					{
						Tools.popMessage(this,"Hanya Bisnis Unit yang bisa men-delete");
					}
					else
					{

						/****************************************************************************************
						 * Kalau delete dari selain IDE, tidak bisa dilakukan jika tinggal 1 jenis pengajuan
						 *****************************************************************************************/
						conn.QueryString = "select * from scgroup_init2 where gr_key like '%IDE%' and groupid = '" + TC + "'";
						conn.ExecuteQuery();
						/*					
											if (conn.GetRowCount() == 0 && DATAGRID1.Items.Count == 1) 
											{
												GlobalTools.popMessage(this, "Jenis Pengajuan tidak bisa dihapus karena aplikasi akan tidak memiliki request !");
												return;
											}
											/****************************************************************************************/

						try 
						{ 
							conn.QueryString = "exec IT_IDE_LOANINFO_DELETE '" + 
								regno + "', '" + 
								e.Item.Cells[2].Text + "', '" + // apptype
								e.Item.Cells[4].Text + "', '" + // productid
								e.Item.Cells[10].Text + "'";		// prod_seq
							conn.ExecTrans();
							conn.ExecTran_Commit();
						} 
						catch (Exception ex)
						{
							if (conn != null)
								conn.ExecTran_Rollback();
							ExceptionHandling.Handler.saveExceptionIntoWindowsLog(ex, Request.Path, "ERROR DELETE : " + Request.QueryString["regno"]);
						}
					}

					break;
				
				case "view":

					Response.Write("<script language='javascript'>window.open('ViewCollateral.aspx?regno="+e.Item.Cells[0].Text+"&apptype="+e.Item.Cells[2].Text+"&productid="+e.Item.Cells[4].Text+"' ,'ViewCollateral','status=no,scrollbars=yes,width=1200,height=400');</script>");
					break;	

			}
			ViewApplications();
		}


		private void DatGrd_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			string seq = null;

			switch (((LinkButton)e.CommandSource).CommandName)
			{
				case "delete":
					/*seq = e.Item.Cells[0].Text;
					dtColl = (DataTable) Session["dataTable"];
					
					for (int i = 0; i < dtColl.Rows.Count; i++)
						if (dtColl.Rows[i]["CL_SEQ"].ToString() == seq)
							dtColl.Rows[i].Delete();
					
					Session.Remove("dataTable");
					Session.Add("dataTable", dtColl);

					ViewCollateral();*/
					break;
			}
		}

		private void DatGrd_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			DatGrd.CurrentPageIndex = e.NewPageIndex;
			ViewCollateral();
		}

		private void DATAGRID1_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			DatGrd.CurrentPageIndex = e.NewPageIndex;
		}

		private void DDL_CL_TYPE_EXISTING_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			//conn.QueryString = "select coltypedesc, cl_value, sisautilization, cl_currency, cl_colclassify, cl_exchangerate, cl_foreignval, sibs_colid from vw_collateral1 where cu_ref='" + Request.QueryString["curef"] + "' and cl_seq='" + DDL_CL_TYPE_EXISTING.SelectedValue + "'";
			/*conn.QueryString = "exec COLLATERALNEW1 '" + regno + "', '" + CUREF + "', " + DDL_CL_TYPE_EXISTING.SelectedValue;
			conn.ExecuteQuery();
			TXT_CL_DESC.Text = conn.GetFieldValue(0, "coltypedesc");
			TXT_CL_VALUE.Text = tool.MoneyFormat(conn.GetFieldValue(0, "cl_value"));
			TXT_CL_VALUE2.Text = tool.MoneyFormat(conn.GetFieldValue(0, "cl_value2"));
			TXT_CL_VALUEINS.Text = tool.MoneyFormat(conn.GetFieldValue(0, "cl_valueins"));
			TXT_CL_VALUEIKAT.Text = tool.MoneyFormat(conn.GetFieldValue(0, "cl_valueikat"));
			TXT_CL_VALUEPPA.Text = tool.MoneyFormat(conn.GetFieldValue(0, "cl_valueppa"));
			TXT_CL_VALUELIQ.Text = tool.MoneyFormat(conn.GetFieldValue(0, "cl_valueliq"));
			try {DDL_CL_CURRENCY.SelectedValue = conn.GetFieldValue(0, "cl_currency");}
			catch {}
			try {DDL_CL_COLCLASSIFY.SelectedValue = conn.GetFieldValue(0, "cl_colclassify");}
			catch {}
			try {DDL_BUKTI_KEPEMILIKAN.SelectedValue = conn.GetFieldValue("cl_certtype1");}
			catch {}
			try {DDL_BENTUK_PENGIKATAN.SelectedValue = conn.GetFieldValue("cl_ikatid");}
			catch {}
			TXT_TGLPENILAIAN_DAY.Text = tool.FormatDate_Day(conn.GetFieldValue("cl_penilaiandate"));
			try {DDL_TGLPENILAIAN_MONTH.SelectedValue	= tool.FormatDate_Month(conn.GetFieldValue("cl_penilaiandate"));}
			catch {}
			TXT_TGLPENILAIAN_YEAR.Text = tool.FormatDate_Year(conn.GetFieldValue("cl_penilaiandate"));
			try {DDL_PENILAI_OLEH.SelectedValue = conn.GetFieldValue("cl_penilaianby");}
			catch {}
			if (conn.GetFieldValue(0, "cl_exchangerate") != "")
				TXT_CL_EXCHANGERATE.Text = tool.MoneyFormat(conn.GetFieldValue(0, "cl_exchangerate"));
			else 
				TXT_CL_EXCHANGERATE.Text = tool.MoneyFormat("1");
			if (conn.GetFieldValue(0, "cl_foreignval") != "")
				TXT_CL_FOREIGNVAL.Text = tool.MoneyFormat(conn.GetFieldValue(0, "cl_foreignval"));
			else
				TXT_CL_FOREIGNVAL.Text = tool.MoneyFormat(conn.GetFieldValue(0, "cl_value"));
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
			LBL_SISAUTILIZATION.Text = conn.GetFieldValue(0, "sisautilization");
			if (conn.GetFieldValue(0, "sibs_colid") != "")
			{
				conn.QueryString = "select sum(lc_percentage) from listcollateral where ap_regno='" + Request.QueryString["regno"] + "' and cl_seq=" + DDL_CL_TYPE_EXISTING.SelectedValue;
				conn.ExecuteQuery();
				try
				{
					double temp = 100 - double.Parse(conn.GetFieldValue(0,0).ToString().Replace(".", ","));
					LBL_SISAUTILIZATION.Text = temp.ToString();
				}
				catch
				{
					LBL_SISAUTILIZATION.Text = "100";
				}
			}*/
		}


		private void DDL_CL_CURRENCY_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			/*try 
			{
				conn.QueryString = "select CURRENCYRATE from RFCURRENCY where CURRENCYID = '" + DDL_CL_CURRENCY.SelectedValue + "'";
				conn.ExecuteQuery();

				TXT_CL_EXCHANGERATE.Text = tool.MoneyFormat(conn.GetFieldValue("CURRENCYRATE"));
			}
			catch (NullReferenceException) 
			{
				GlobalTools.popMessage(this, "Connection Error !");
				return;
			}*/
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
			this.DATAGRID1.ItemCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.DATAGRID1_ItemCommand);
			this.DATAGRID1.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.DatGrd_PageIndexChanged);
			this.DatGrd.ItemCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.DatGrd_ItemCommand);
			this.DatGrd.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.DatGrd_PageIndexChanged);

		}
		#endregion


		protected void BTN_SAVECOLL_Click(object sender, System.EventArgs e)
		{
			//Sebelum save, cek dulu ......
			
			//-------------------------------------------------------------------------------
			//Kalau checkbox collateral dipilih, tapi tidak ada collateral dimasukkan, maka
			//munculkan pesan
			//keyword: collateral
			/*if (CHK_COLLATERAL.Checked == true)
			{
				if (DatGrd.Items.Count == 0)
				{
					Tools.popMessage(this, "Data collateral belum diisi!");
					return;
				}
			}*/


			string vPROD_SEQ = "0";

			for (int i = 0; i < DatGrd.Items.Count; i++)
			{
				if (DatGrd.Items[i].Cells[17].Text == "1")
				{
					conn.QueryString = "exec IDE_LOANINFO_COLL2 '" + regno + "', '" + 
						CUREF + "', '" +
						DatGrd.Items[i].Cells[3].Text + "', " +
						DatGrd.Items[i].Cells[1].Text + ", " + 
						tool.ConvertFloat(DatGrd.Items[i].Cells[9].Text) + ", " + 
						DatGrd.Items[i].Cells[0].Text + ", '" + 
						DDL_PRODUCTID.SelectedValue + "', " + 
						tool.ConvertFloat(DatGrd.Items[i].Cells[14].Text) + ", " + 
						tool.ConvertFloat(DatGrd.Items[i].Cells[15].Text) + ", '1', '" + 
						DatGrd.Items[i].Cells[18].Text + "', '" +
						DatGrd.Items[i].Cells[19].Text + "', " + 
						tool.ConvertFloat(DatGrd.Items[i].Cells[21].Text) + ", " + 
						tool.ConvertFloat(DatGrd.Items[i].Cells[26].Text) + ", NULL, " + vPROD_SEQ + ", " +
						tool.ConvertFloat(DatGrd.Items[i].Cells[8].Text) + ", " + 
						tool.ConvertFloat(DatGrd.Items[i].Cells[20].Text) + ", " + 
						tool.ConvertFloat(DatGrd.Items[i].Cells[10].Text) + ", " + 
						tool.ConvertFloat(DatGrd.Items[i].Cells[22].Text) + ", " + 
						tool.ConvertFloat(DatGrd.Items[i].Cells[11].Text) + ", " + 
						tool.ConvertFloat(DatGrd.Items[i].Cells[23].Text) + ", " + 
						tool.ConvertFloat(DatGrd.Items[i].Cells[12].Text) + ", " + 
						tool.ConvertFloat(DatGrd.Items[i].Cells[24].Text) + ", " + 
						tool.ConvertFloat(DatGrd.Items[i].Cells[13].Text) + ", " + 
						tool.ConvertFloat(DatGrd.Items[i].Cells[25].Text) + ", '" + 
						DatGrd.Items[i].Cells[4].Text + "', '" + 
						DatGrd.Items[i].Cells[6].Text + "', " + 
						tool.ConvertDate(DatGrd.Items[i].Cells[27].Text) + ", '" + 
						DatGrd.Items[i].Cells[28].Text + "'";
					conn.ExecuteNonQuery();
				}		
				else if (DatGrd.Items[i].Cells[17].Text == "0")
				{
					conn.QueryString = "exec IDE_LOANINFO_COLL2 '" + regno + "', '" + 
						CUREF + "', " +
						"null, null, 0," + 
						DatGrd.Items[i].Cells[0].Text + ", '" + 
						DDL_PRODUCTID.SelectedValue + "', " + 
						tool.ConvertFloat(DatGrd.Items[i].Cells[14].Text) + ", " + 
						tool.ConvertFloat(DatGrd.Items[i].Cells[15].Text) + ", '2', '" + 
						DatGrd.Items[i].Cells[18].Text + "', '" + 
						DatGrd.Items[i].Cells[19].Text + "', 0, 0, NULL, '" + vPROD_SEQ + "', " +
						tool.ConvertFloat(DatGrd.Items[i].Cells[8].Text) + ", " + 
						tool.ConvertFloat(DatGrd.Items[i].Cells[20].Text) + ", " + 
						tool.ConvertFloat(DatGrd.Items[i].Cells[10].Text) + ", " + 
						tool.ConvertFloat(DatGrd.Items[i].Cells[22].Text) + ", " + 
						tool.ConvertFloat(DatGrd.Items[i].Cells[11].Text) + ", " + 
						tool.ConvertFloat(DatGrd.Items[i].Cells[23].Text) + ", " + 
						tool.ConvertFloat(DatGrd.Items[i].Cells[12].Text) + ", " + 
						tool.ConvertFloat(DatGrd.Items[i].Cells[24].Text) + ", " + 
						tool.ConvertFloat(DatGrd.Items[i].Cells[13].Text) + ", " + 
						tool.ConvertFloat(DatGrd.Items[i].Cells[25].Text) + ", '" + 
						DatGrd.Items[i].Cells[4].Text + "', '" + 
						DatGrd.Items[i].Cells[6].Text + "', " + 
						tool.ConvertDate(DatGrd.Items[i].Cells[27].Text) + ", '" + 
						DatGrd.Items[i].Cells[28].Text + "'";
					conn.ExecuteNonQuery();
				}
			}
			//DDL_APPTYPE.Enabled = true;
			Clear();
			BTN_SAVE.Enabled = true;



				

			//Mengingat 1 ketentuan kredit hanya 1 permohonan baru, 
			//maka setelah permohonan baru dibuat, tidak bisa membuat pengajuan lagi
			//dengan jenis yang sama

		}

		protected void BTN_INSCOLL_Click(object sender, System.EventArgs e)
		{
			// ---- Baru ----
			/*if (DDL_CL_COLCLASSIFY.SelectedValue == "") 
			{
				GlobalTools.popMessage(this, "Jenis Jaminan tidak boleh kosong!");
				return;
			}

			if(!GlobalTools.isDateValid(this, TXT_TGLPENILAIAN_DAY.Text, DDL_TGLPENILAIAN_MONTH.SelectedValue, TXT_TGLPENILAIAN_YEAR.Text))
			{
				GlobalTools.popMessage(this, "Tanggal Penilaian tidak valid!");
				GlobalTools.SetFocus(this, TXT_TGLPENILAIAN_DAY);
				return;
			}*/
				/*
							if (double.Parse(TXT_LC_PERCENTAGE.Text) > double.Parse(LBL_SISAUTILIZATION.Text))
							{
								Response.Write("<script language='javascript'>alert('Utilization Melebihi Limit!');</script>");
							}
				*/
			/*else
			{*/
				/*dtColl = (DataTable) Session["dataTable"];
				DataRow dr;
				try 
				{
					dr = dtColl.NewRow();
				} 
				catch 
				{
					dtColl = new DataTable();
					dtColl.Columns.Add(new DataColumn("CL_SEQ"));
					dtColl.Columns.Add(new DataColumn("COLTYPEID"));
					dtColl.Columns.Add(new DataColumn("COLTYPEDESC"));
					dtColl.Columns.Add(new DataColumn("CL_DESC"));
					dtColl.Columns.Add(new DataColumn("CL_CERTTYPE1"));
					dtColl.Columns.Add(new DataColumn("CL_CERTTYPE1DESC"));
					dtColl.Columns.Add(new DataColumn("CL_IKATID"));
					dtColl.Columns.Add(new DataColumn("CL_IKATIDDESC"));
					dtColl.Columns.Add(new DataColumn("CL_VALUE2"));
					dtColl.Columns.Add(new DataColumn("CL_VALUE"));
					dtColl.Columns.Add(new DataColumn("CL_VALUEINS"));
					dtColl.Columns.Add(new DataColumn("CL_VALUEIKAT"));
					dtColl.Columns.Add(new DataColumn("CL_VALUEPPA"));
					dtColl.Columns.Add(new DataColumn("CL_VALUELIQ"));
					dtColl.Columns.Add(new DataColumn("LC_PERCENTAGE"));
					dtColl.Columns.Add(new DataColumn("ISNEW"));
					dtColl.Columns.Add(new DataColumn("CL_CURRENCY"));
					dtColl.Columns.Add(new DataColumn("CL_COLCLASSIFY"));
					dtColl.Columns.Add(new DataColumn("CL_FOREIGNVAL2"));
					dtColl.Columns.Add(new DataColumn("CL_FOREIGNVAL"));
					dtColl.Columns.Add(new DataColumn("CL_FOREIGNVALINS"));
					dtColl.Columns.Add(new DataColumn("CL_FOREIGNVALIKAT"));
					dtColl.Columns.Add(new DataColumn("CL_FOREIGNVALPPA"));
					dtColl.Columns.Add(new DataColumn("CL_FOREIGNVALLIQ"));
					dtColl.Columns.Add(new DataColumn("CL_EXCHANGERATE"));
					dtColl.Columns.Add(new DataColumn("CL_PENILAIANDATE"));
					dtColl.Columns.Add(new DataColumn("CL_PENILAIANBY"));
					dtColl.Columns.Add(new DataColumn("SIBS_COLID"));
					Session.Add("dataTable", dtColl);

					dr = dtColl.NewRow();
				}

				int seq = 0;
				try 
				{
					seq = int.Parse(LBL_SEQ.Text);
				} 
				catch 
				{
					seq = 0;
				}

				if (RDO_COLLATERAL.SelectedValue == "1")
				{					
					seq++;
					dr[0] = seq.ToString();
					dr[1] = DDL_CL_TYPE.SelectedValue;
					dr[2] = DDL_CL_TYPE.SelectedItem.Text;
					dr[3] = TXT_CL_DESC.Text;
					dr[4] = DDL_BUKTI_KEPEMILIKAN.SelectedValue;
					dr[5] = DDL_BUKTI_KEPEMILIKAN.SelectedItem.Text;
					dr[6] = DDL_BENTUK_PENGIKATAN.SelectedValue;
					dr[7] = DDL_BENTUK_PENGIKATAN.SelectedItem.Text;
					dr[8] = TXT_CL_VALUE2.Text;
					dr[9] = TXT_CL_VALUE.Text;
					dr[10] = TXT_CL_VALUEINS.Text;
					dr[11] = TXT_CL_VALUEIKAT.Text;
					dr[12] = TXT_CL_VALUEPPA.Text;
					dr[13] = TXT_CL_VALUELIQ.Text;
					dr[14] = TXT_LC_PERCENTAGE.Text;
					dr[15] = "1";
					dr[16] = DDL_CL_CURRENCY.SelectedValue;
					dr[17] = DDL_CL_COLCLASSIFY.SelectedValue;
					dr[18] = TXT_CL_FOREIGNVAL2.Text;
					dr[19] = TXT_CL_FOREIGNVAL.Text;
					dr[20] = TXT_CL_FOREIGNVALINS.Text;
					dr[21] = TXT_CL_FOREIGNVALIKAT.Text;
					dr[22] = TXT_CL_FOREIGNVALPPA.Text;
					dr[23] = TXT_CL_FOREIGNVALLIQ.Text;
					dr[24] = TXT_CL_EXCHANGERATE.Text;
					dr[25] = tool.ConvertDate(TXT_TGLPENILAIAN_DAY.Text,DDL_TGLPENILAIAN_MONTH.SelectedValue,TXT_TGLPENILAIAN_YEAR.Text);
					dr[26] = DDL_PENILAI_OLEH.SelectedValue;
					dr[27] = TXT_COL_ID.Text;
				}
				else
				{
					dr[0] = DDL_CL_TYPE_EXISTING.SelectedValue;
					//dr[1] = DDL_CL_TYPE.SelectedValue;
					//dr[2] = DDL_CL_TYPE.SelectedItem.Text;
					dr[3] = DDL_CL_TYPE_EXISTING.SelectedItem.Text;
					dr[4] = DDL_BUKTI_KEPEMILIKAN.SelectedValue;
					dr[5] = DDL_BUKTI_KEPEMILIKAN.SelectedItem.Text;
					dr[6] = DDL_BENTUK_PENGIKATAN.SelectedValue;
					dr[7] = DDL_BENTUK_PENGIKATAN.SelectedItem.Text;
					dr[8] = TXT_CL_VALUE2.Text;
					dr[9] = TXT_CL_VALUE.Text;
					dr[10] = TXT_CL_VALUEINS.Text;
					dr[11] = TXT_CL_VALUEIKAT.Text;
					dr[12] = TXT_CL_VALUEPPA.Text;
					dr[13] = TXT_CL_VALUELIQ.Text;
					dr[14] = TXT_LC_PERCENTAGE.Text;
					dr[15] = "0";
					dr[16] = DDL_CL_CURRENCY.SelectedValue;
					dr[17] = DDL_CL_COLCLASSIFY.SelectedValue;
					dr[18] = TXT_CL_FOREIGNVAL2.Text;
					dr[19] = TXT_CL_FOREIGNVAL.Text;
					dr[20] = TXT_CL_FOREIGNVALINS.Text;
					dr[21] = TXT_CL_FOREIGNVALIKAT.Text;
					dr[22] = TXT_CL_FOREIGNVALPPA.Text;
					dr[23] = TXT_CL_FOREIGNVALLIQ.Text;
					dr[24] = TXT_CL_EXCHANGERATE.Text;
					dr[25] = tool.ConvertDate(TXT_TGLPENILAIAN_DAY.Text,DDL_TGLPENILAIAN_MONTH.SelectedValue,TXT_TGLPENILAIAN_YEAR.Text);
					dr[26] = DDL_PENILAI_OLEH.SelectedValue;
					dr[27] = TXT_COL_ID.Text;
				}

				/*dtColl.Rows.Add(dr);

				Session.Remove("dataTable");
				Session.Add("dataTable", dtColl);*/

				//ViewCollateral();
			
				//DatGrd.DataSource = new DataView(dtColl);
				//DatGrd.DataBind();
				//LBL_SEQ.Text = seq.ToString();
			
				/*TXT_CL_DESC.Text = "";
				DDL_CL_TYPE.SelectedValue = "";
				DDL_CL_COLCLASSIFY.SelectedValue = "";
				DDL_CL_CURRENCY.SelectedValue = "";
				TXT_CL_FOREIGNVAL.Text = "";
				TXT_CL_EXCHANGERATE.Text = "1";
				TXT_CL_VALUE.Text = "";
				TXT_LC_PERCENTAGE.Text = "100";
				try{DDL_CL_TYPE_EXISTING.SelectedValue="0";}
				catch{}
				

				TXT_COL_ID.Text = "";
				DDL_BUKTI_KEPEMILIKAN.SelectedValue = "";
				DDL_BENTUK_PENGIKATAN.SelectedValue = "";
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
				DDL_TGLPENILAIAN_MONTH.SelectedValue = "";
				TXT_TGLPENILAIAN_YEAR.Text = "";
				DDL_PENILAI_OLEH.SelectedValue = "";

				LBL_SISAUTILIZATION.Text = "100";*/
			//}
		}

		private void addLoan() 
		{
			try 
			{
				//Memasukkan data ke tabel KETENTUAN_KREDIT								
				/*conn.QueryString = "exec IT_KET2 '','" + 
					TXT_CP_NOTES.Text + "','" + 
					regno + "'," + 
					//GlobalTools.ConvertNull(DDL_AANO.SelectedValue) + "," + 
					GlobalTools.ConvertNull(DDL_AANO.SelectedValue) + "," + 
					GlobalTools.ConvertNull(DDL_PRODUCTID1.SelectedValue) + "," + 
					GlobalTools.ConvertNull(DDL_ACC_SEQ.SelectedValue) + ",'0'"; */
				//GlobalTools.ConvertNull(DDL_CL_CURRENCY2.SelectedValue) + ",'0'"; 
				//GlobalTools.ConvertNull(LBL_ACC_NOVAL.Text) + ", '0', " + 
				//GlobalTools.ConvertNull(DDL_PRJ_CODE.SelectedValue) + ", " +
				//GlobalTools.ConvertNull(DDL_CHANNCOMP.SelectedValue) + "";
				conn.ExecuteNonQuery();
			} 
			catch (NullReferenceException) 
			{
				Tools.popMessage(this, "Connection Error !");
				return;
			}
		}

		private void DDL_NCLPRODUCTID_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			/*GlobalTools.fillRefList(DDL_PRODUCTID1, "select distinct PRODUCTID, PRODUCTID from IT_EXISTFACILITY where CU_REF = '" + CUREF + "'", false, conn);
			DDL_ACC_SEQ.SelectedValue = "";*/

		}


		private void DDL_PRODUCTID1_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			/*DDL_ACC_SEQ.Items.Clear();
			DDL_ACC_SEQ.Items.Add(new ListItem("- PILIH -", ""));
			conn.QueryString = "select distinct ACC_SEQ, ACC_SEQ from VW_IT_FACILITY " + 
				" where aa_no='" + DDL_AANO.SelectedValue + 
				"' and productid='" + DDL_PRODUCTID1.SelectedValue + "' " + 
				" and cu_ref = '" + CUREF + "'";
			conn.ExecuteQuery();
			for (int i = 0; i < conn.GetRowCount(); i++)
				DDL_ACC_SEQ.Items.Add(new ListItem(conn.GetFieldValue(i,0), conn.GetFieldValue(i,0)));
			
			//			conn.QueryString = "select productdesc from rfproduct where productid='" + DDL_PRODUCTID.SelectedValue + "'";
			//			conn.ExecuteQuery();

			DDL_ACC_SEQ.Visible = true;*/

			//DDL_PRODUCTID.SelectedValue = DDL_PRODUCTID1.SelectedValue;
			//DDL_PRODUCTID.Enabled = false;
		}


		private void DDL_AANO_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			/*GlobalTools.fillRefList(DDL_PRODUCTID1, "SELECT distinct PRODUCTID, PRODUCTID FROM VW_IT_FACILITY where AA_NO = '" + DDL_AANO.SelectedValue + "' and CU_REF = '" + CUREF + "'", false, conn);
			LBL_PRODUCTID1.Text = "";
			LBL_SEQ.Text = "";*/
		}

		protected void DDL_PRODUCTID_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if (DDL_PRODUCTID.SelectedValue == "CRP1")
			{
				//DDL_CL_CURRENCY2.Enabled = false;
				TXT_CP_EXLIMITVAL.Enabled = false;
				TXT_CP_EXRPLIMIT.Enabled = false;
				TXT_CP_LIMIT.Enabled = false;
				/*TXT_CP_JANGKAWKT.Text = "0";
				TXT_CP_JANGKAWKT.Enabled = false;
				DDL_CP_TENORCODE.Enabled = false;
				CHK_COLLATERAL.Enabled = false;*/
				BTN_INSCOLL.Enabled = false;
			}
			else
			{
				TXT_CP_EXLIMITVAL.Enabled = true;
				TXT_CP_EXRPLIMIT.Enabled = true;
				TXT_CP_LIMIT.Enabled = true;
				//TXT_CP_JANGKAWKT.Text = "0";
				/*TXT_CP_JANGKAWKT.Enabled = true;
				DDL_CP_TENORCODE.Enabled = true;
				CHK_COLLATERAL.Enabled = true;*/
				BTN_INSCOLL.Enabled = true;
			}
		}

		private void DDL_ACC_SEQ_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			/*conn.QueryString = "exec IT_REMAIN_LIMIT '"+ CUREF +"','" + DDL_PRODUCTID1.SelectedValue + "' ,'" + DDL_AANO.SelectedValue +"','"+ DDL_ACC_SEQ.SelectedValue +"'";
			conn.ExecuteQuery();*/
			/*LBL_CP_LIMIT.Text = tool.MoneyFormat(conn.GetFieldValue("REMAIN_LIMIT"));
			LBL_TRX_LIMIT.Text = tool.MoneyFormat(conn.GetFieldValue("PENDING_LIMIT"));*/
		}

		private void secureData() 
		{
			string de = Request.QueryString["de"];
			if (de == "1")
			{
				//TR_COLL1.Visible = false;
				TR_COLL4.Visible = false;
				//TR_JENISPENGAJUAN.Visible = false;
				//TR_BUTTONS1.Visible = false;
				//TR_BUTTONS2.Visible = false;
				TR_JUDUL.Visible = false;
				TR_BODY.Visible = false;


				
				
			}
		}


	}
}
