using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using Microsoft.VisualBasic;
using DMS.CuBESCore;
using DMS.DBConnection;


namespace SME.CreditProposal
{
	/// <summary>
	/// Summary description for FasilitasLegalSigning_Data.
	/// </summary>
	public partial class BiayaPK_DataCBI : System.Web.UI.Page
	{

		protected Connection conn;
		//protected Connection conn = new Connection("Data Source=10.123.12.30;Initial Catalog=SMEDEV;uid=sa;pwd=");
		protected System.Web.UI.WebControls.RadioButton RDB_PK1;
		protected System.Web.UI.WebControls.RadioButton RDB_PK2;
		protected System.Web.UI.WebControls.Label LBL_H_APPTYPE;
		protected Tools tool = new Tools();
		string var_user, var_idExport, var_Nota;

		protected void Page_Load(object sender, System.EventArgs e)
		{
			conn = (Connection) Session["Connection"];
			var_user = (string)Session["UserID"];

			if (!IsPostBack)
			{
				///////////////////////////////////////
				///	Mengambil query parameter
				///	
				LBL_REGNO.Text		= Request.QueryString["regno"];
				LBL_CUREF.Text		= Request.QueryString["curef"];
				LBL_TC.Text			= Request.QueryString["tc"];
				LBL_PRODUCTID.Text	= Request.QueryString["productid"];
				LBL_APPTYPE.Text	= Request.QueryString["apptype"];
				LBL_PROD_SEQ.Text	= Request.QueryString["prod_seq"];
				//////////////////////////////////////////
				
				/////////////////////////////////////////
				///	Mengambil tipe customer
				///	
				conn.QueryString = "Select cu_custtypeid from Customer where cu_ref = '" + LBL_CUREF.Text + "'";
				conn.ExecuteQuery();	
				string ct = conn.GetFieldValue("cu_custtypeid");
				/////////////////////////////////////////

				/////////////////////////////////////////
				///	Mengambil program aplikasi
				///	
				conn.QueryString = "Select prog_code from application where ap_regno = '" + LBL_REGNO.Text + "'";
				conn.ExecuteQuery();
				string prg = conn.GetFieldValue("prog_code");
				/////////////////////////////////////////


				/////////////////////////////////////////
				///	
				var_Nota = "select PK_ID, PK_DESC from PK where programid = '" + prg + "' and custtypeid = '" + ct + "' order by PK_DESC";
				//var_Nota = "select distinct PK_ID, PK_DESC from PK order by PK_DESC";
				GlobalTools.fillRefList(DDL_FORMAT_TYPE, var_Nota , false, conn);
				/////////////////////////////////////////

				if (Request.QueryString["na"] == "2") 
				{
					TXT_CP_PKNO.Enabled = false;
					TXT_CP_PKNOADD.Enabled = false;
					TXT_CP_PKDATEDAY.Enabled = false;
					DDL_CP_PKDATEMONTH.Enabled = false;
					TXT_CP_PKDATEYEAR.Enabled = false;
					TXT_CP_PKDATEADDDAY.Enabled = false;
					DDL_CP_PKDATEADDMONTH.Enabled = false;
					TXT_CP_PKDATEADDYEAR.Enabled = false;
					TXT_CP_PKNO.CssClass = "";
					TXT_CP_PKNOADD.CssClass = "";
					TXT_CP_PKDATEDAY.CssClass = "";
					DDL_CP_PKDATEMONTH.CssClass = "";
					TXT_CP_PKDATEYEAR.CssClass = "";
					TXT_CP_PKDATEADDDAY.CssClass = "";
					DDL_CP_PKDATEADDMONTH.CssClass = "";
					TXT_CP_PKDATEADDYEAR.CssClass = "";
				}
				else
				{
					if (LBL_APPTYPE.Text.Trim() == "01")	//new application
					{
						conn.QueryString = "select SPK from RFPRODUCT where PRODUCTID = '" + LBL_PRODUCTID.Text.Trim() + "' ";
						conn.ExecuteQuery();
						if (conn.GetFieldValue(0,0).Trim() == "1")
						{
							//TXT_CP_BEAADM.CssClass = "mandatory";
							TXT_CP_BEAPROVISI_PCT.CssClass	= "mandatory";
							TXT_CP_BEAPROVISI.CssClass		= "mandatory";
						}
					}
				}

				//init rflegalstatus
				conn.QueryString = "select LEGALSTAID, LEGALSTADESC from RFLEGALSTATUS where active = '1' ";
				conn.ExecuteQuery();
				RBL_LEGALSTA.Items.Clear();
				for (int i=0; i<conn.GetRowCount(); i++)
					RBL_LEGALSTA.Items.Add(new ListItem(conn.GetFieldValue(i, 1), conn.GetFieldValue(i, 0)));
				RBL_LEGALSTA.Items[RBL_LEGALSTA.Items.Count - 1].Selected = true;

				//init rfrating
				conn.QueryString = "SELECT RATEID, RATEDESC FROM RFRATING ";
				conn.ExecuteQuery();
				DDL_ICRATE.Items.Clear();
				DDL_ICRATE.Items.Add(new ListItem("-- Pilih --", ""));
				for (int i=0; i<conn.GetRowCount(); i++)
					DDL_ICRATE.Items.Add(new ListItem(conn.GetFieldValue(i, 1), conn.GetFieldValue(i, 0)));

				//init rfinsurancecompanytype
				conn.QueryString = "SELECT ICT_ID, ICT_DESC FROM RFINSURANCECOMPANYTYPE ";
				conn.ExecuteQuery();
				DDL_INSURANCECOMPANYTYPE.Items.Clear();
				DDL_INSURANCECOMPANYTYPE.Items.Add(new ListItem("-- Pilih --", ""));
				for (int i=0; i<conn.GetRowCount(); i++)
					DDL_INSURANCECOMPANYTYPE.Items.Add(new ListItem(conn.GetFieldValue(i, 1), conn.GetFieldValue(i, 0)));

				//init CUR_ID
				//--- Mata Uang
				conn.QueryString = "select currencyid, currencyid+' - '+currencydesc as currencydesc from rfcurrency where active = '1' order by currencyid";
				conn.ExecuteQuery();
				DDL_CP_CUR.Items.Clear();
				DDL_CP_CUR.Items.Add(new ListItem("- PILIH -", ""));
				for (int i = 0; i < conn.GetRowCount(); i++)
				{
					String s0 = conn.GetFieldValue(i,0),
						s1 = conn.GetFieldValue(i,1);
					ListItem li = new ListItem(s1,s0);
					DDL_CP_CUR.Items.Add(li);
				}

				///////////////////////////////////////
				///	Inisialisasi Tanggal
				///	
				Tools.initDateForm(TXT_CP_PKDATEDAY, DDL_CP_PKDATEMONTH, TXT_CP_PKDATEYEAR, false);
				Tools.initDateForm(TXT_CP_PKDATEADDDAY, DDL_CP_PKDATEADDMONTH, TXT_CP_PKDATEADDYEAR, false);
				Tools.initDateForm(TXT_DATESTART_DAY, DDL_DATESTART_MONTH, TXT_DATESTART_YEAR, false);
				Tools.initDateForm(TXT_DATEEND_DAY, DDL_DATEEND_MONTH, TXT_DATEEND_YEAR, false);
				///////////////////////////////////////

				ViewData();

				//fillInsrComp();
				fillInsrType();

				bindData();
			}
			else
			{
				TXT_CP_BEAADM.Text = tool.MoneyFormat(TXT_CP_BEAADM.Text);
				TXT_CP_BEAIKAT.Text = tool.MoneyFormat(TXT_CP_BEAIKAT.Text);
				TXT_CP_BEAMATERAI.Text = tool.MoneyFormat(TXT_CP_BEAMATERAI.Text);
				TXT_CP_BEANOTARIS.Text = tool.MoneyFormat(TXT_CP_BEANOTARIS.Text);
				TXT_CP_BEAPROVISI.Text = tool.MoneyFormat(TXT_CP_BEAPROVISI.Text);
				TXT_CP_INSRAMNT.Text = tool.MoneyFormat(TXT_CP_INSRAMNT.Text);
				TXT_CP_INSRPREMI.Text = tool.MoneyFormat(TXT_CP_INSRPREMI.Text);
				TXT_CP_INSRPCT.Text = tool.MoneyFormat(TXT_CP_INSRPCT.Text);
			}

			ViewFileExport();
			var_idExport = DDL_FORMAT_TYPE.SelectedValue;

			if(var_idExport==string.Empty)
				BTN_EXPORT.Enabled = false;
			else
				BTN_EXPORT.Enabled = true;

			secureData();
			DataGrid1.PageIndexChanged += new DataGridPageChangedEventHandler(this.Grid_Change);

			BTN_SAVE.Attributes.Add("onclick","if(!cek_mandatory(document.Form1)){return false;};");
			BTN_EXPORT.Attributes.Add("onclick", "if (!exportInProgress()) { return false; }");
		}

		private void secureData() 
		{
			if (Request.QueryString["na"] == "0") 
			{
				//--- protect Struktur Kredit
				TXT_CP_PKNO.ReadOnly		= true;
				TXT_CP_PKNOADD.ReadOnly		= true;
				TXT_CP_PKDATEDAY.ReadOnly	= true;
				DDL_CP_PKDATEMONTH.Enabled	= false;
				TXT_CP_PKDATEYEAR.ReadOnly	= true;
				TXT_CP_PKDATEADDDAY.ReadOnly	= true;
				DDL_CP_PKDATEADDMONTH.Enabled	= false;
				TXT_CP_PKDATEADDYEAR.ReadOnly	= true;

				//--- protect Biaya-biaya
				TXT_CP_BEAADM.ReadOnly = true;
				TXT_CP_BEAIKAT.ReadOnly = true;
				TXT_CP_BEAMATERAI.ReadOnly = true;
				TXT_CP_BEANOTARIS.ReadOnly = true;
				TXT_CP_BEAPROVISI.ReadOnly = true;
				TXT_CP_BEAPROVISI_PCT.ReadOnly = true;

				//--- protect datagrid
				DataGrid1.Columns[16].Visible = false;
				for(int i=0; i<DataGrid1.Items.Count; i++) 
				{
					DataGrid1.Items[i].Cells[16].Visible = false;
				}

				RBL_LEGALSTA.Enabled = false;
				BTN_SAVE.Visible = false;
			}
		}

		private void ViewData()
		{
			conn.QueryString = "select sum(AD_LIMIT) AD_LIMIT , TENOR , LOANPURPDESC , ITYPEDESC , APL_BEAADM , " +
				"APL_BEAPROVISI , APL_BEANOTARIS , APL_BEAIKAT , APL_BEAMATERAI , APL_LEGALSTATUS , INTEREST , " +
				"REVOLVING , APL_PKNO, APL_PKNOADD, APL_PKDATE, APL_PKDATEADD, PROD_SEQ, APL_BEAPROVISI_PCT, APL_BEAUPFRONTFEE " +
				"FROM VW_CREOPR_NOTARYASSIGN_CREDSTRUCT "+
				"where AP_REGNO = '"+ LBL_REGNO.Text +
				"' and PRODUCTID = '" + LBL_PRODUCTID.Text + 
				"' and APPTYPE = '" + LBL_APPTYPE.Text + "' and PROD_SEQ = '" + LBL_PROD_SEQ.Text + "' " +
				"GROUP BY TENOR , LOANPURPDESC , ITYPEDESC , APL_BEAADM , APL_BEAPROVISI , APL_BEANOTARIS , " +
				"APL_BEAIKAT , APL_BEAMATERAI , APL_LEGALSTATUS , INTEREST , REVOLVING , APL_PKNO, APL_PKNOADD, APL_PKDATE, APL_PKDATEADD, " + 
				" PROD_SEQ, APL_BEAPROVISI_PCT, APL_BEAUPFRONTFEE";
			conn.ExecuteQuery();

			if (conn.GetRowCount() == 0) 
			{
				//return;

				conn.QueryString = "select sum(AD_LIMIT) AD_LIMIT , TENOR , LOANPURPDESC , ITYPEDESC , APL_BEAADM , " +
					"APL_BEAPROVISI , APL_BEANOTARIS , APL_BEAIKAT , APL_BEAMATERAI , APL_LEGALSTATUS , INTEREST , " +
					"REVOLVING , APL_PKNO, APL_PKNOADD, APL_PKDATE, APL_PKDATEADD, PROD_SEQ, APL_BEAPROVISI_PCT, APL_BEAUPFRONTFEE " +
					"FROM VW_CREOPR_NOTARYASSIGN_CREDSTRUCT_NON_APPRDECISION "+		
					"where AP_REGNO = '"+ LBL_REGNO.Text +
					"' and PRODUCTID = '" + LBL_PRODUCTID.Text + 
					"' and APPTYPE = '" + LBL_APPTYPE.Text + "' and PROD_SEQ = '" + LBL_PROD_SEQ.Text + "' " +
					"GROUP BY TENOR , LOANPURPDESC , ITYPEDESC , APL_BEAADM , APL_BEAPROVISI , APL_BEANOTARIS , " +
					"APL_BEAIKAT , APL_BEAMATERAI , APL_LEGALSTATUS , INTEREST , REVOLVING , APL_PKNO, APL_PKNOADD, APL_PKDATE, APL_PKDATEADD, " + 
					"PROD_SEQ, APL_BEAPROVISI_PCT, APL_BEAUPFRONTFEE";
				conn.ExecuteQuery();
			}

			TXT_CP_LIMIT.Text		= tool.MoneyFormat(conn.GetFieldValue(0, "AD_LIMIT"));
			TXT_CP_INSRAMNT.Text	= tool.MoneyFormat(conn.GetFieldValue(0, "AD_LIMIT"));
			TXT_CP_TENOR.Text		= conn.GetFieldValue(0, "TENOR");
			TXT_CP_INTEREST.Text	= conn.GetFieldValue(0, "INTEREST");
			TXT_CP_INTTYPE.Text		= conn.GetFieldValue(0, "ITYPEDESC");
			TXT_CP_LOANPURPOSE.Text = conn.GetFieldValue(0, "LOANPURPDESC");
			TXT_REVOLVING.Text		= conn.GetFieldValue(0, "REVOLVING");
			TXT_CP_PKNO.Text		= conn.GetFieldValue(0, "APL_PKNO");
			TXT_CP_PKNOADD.Text		= conn.GetFieldValue(0, "APL_PKNOADD");
			try
			{
				string CP_PKDATE					= conn.GetFieldValue("APL_PKDATE");
				TXT_CP_PKDATEDAY.Text				= tool.FormatDate_Day(CP_PKDATE);
				DDL_CP_PKDATEMONTH.SelectedValue	= tool.FormatDate_Month(CP_PKDATE);
				TXT_CP_PKDATEYEAR.Text				= tool.FormatDate_Year(CP_PKDATE);
				string CP_PKDATEADD					= conn.GetFieldValue("APL_PKDATEADD");
				TXT_CP_PKDATEADDDAY.Text			= tool.FormatDate_Day(CP_PKDATEADD);
				DDL_CP_PKDATEADDMONTH.SelectedValue	= tool.FormatDate_Month(CP_PKDATEADD);
				TXT_CP_PKDATEADDYEAR.Text			= tool.FormatDate_Year(CP_PKDATEADD);
			} 
			catch {}

			TXT_CP_BEAADM.Text		= tool.MoneyFormat(conn.GetFieldValue(0, "APL_BEAADM"));
			TXT_CP_BEAPROVISI.Text	= tool.MoneyFormat(conn.GetFieldValue(0, "APL_BEAPROVISI"));			
			if (conn.GetFieldValue(0, "APL_BEAPROVISI_PCT") == "") 
			{
				try
				{
					double prov = double.Parse(TXT_CP_BEAPROVISI.Text),
						limit = double.Parse(TXT_CP_LIMIT.Text), val;
					if (limit == 0)
						TXT_CP_BEAPROVISI_PCT.Text = "0";
					else
					{
						val = prov * 100 / limit;
						TXT_CP_BEAPROVISI_PCT.Text = Tools.setDigit(val.ToString(),2,",");
					}
				} 
				catch {}
			} 
			else 
			{
				TXT_CP_BEAPROVISI_PCT.Text = conn.GetFieldValue("APL_BEAPROVISI_PCT");
			}

			TXT_CP_BEANOTARIS.Text = tool.MoneyFormat(conn.GetFieldValue(0, "APL_BEANOTARIS"));
			TXT_CP_BEAIKAT.Text = tool.MoneyFormat(conn.GetFieldValue(0, "APL_BEAIKAT"));
			TXT_CP_BEAMATERAI.Text = tool.MoneyFormat(conn.GetFieldValue(0, "APL_BEAMATERAI"));
			try
			{
				RBL_LEGALSTA.SelectedValue = conn.GetFieldValue(0, "APL_LEGALSTATUS").Trim();
			} 
			catch {}
			TXT_CP_BEAUPFRONTFEE.Text = tool.MoneyFormat(conn.GetFieldValue("APL_BEAUPFRONTFEE"));
		}

		/// <summary>
		/// Mengisi dropdown Insurance Company
		/// </summary>
		private void fillInsrComp()
		{
			/**
			conn.QueryString = "select distinct IC_ID, IC_DESC "+
				"from VW_CREOPR_NOTARYASSIGN_RFINSRCOMPANY_CREDASU ";
			conn.ExecuteQuery();
			DDL_CP_INSRCOMP.Items.Clear();
			DDL_CP_INSRCOMP.Items.Add(new ListItem("-- Pilih --",""));
			for (int i = 0; i < conn.GetRowCount(); i++)
			{
				String s0 = conn.GetFieldValue(i,0),
					s1 = conn.GetFieldValue(i,1);
				ListItem li = new ListItem(s1,s0);
				DDL_CP_INSRCOMP.Items.Add(li);
			}
			fillInsrType();
			**/

			DDL_CP_INSRCOMP.Items.Clear();
			if (DDL_CP_INSRTYPE.SelectedValue.Trim() == "")
				return;

			conn.QueryString = "select distinct IC_ID, IC_DESC "+
				"from VW_CREOPR_NOTARYASSIGN_RFINSRCOMPANY_CREDASU where IT_ID = '" + DDL_CP_INSRTYPE.SelectedValue + "'";
			conn.ExecuteQuery();
			DDL_CP_INSRCOMP.Items.Clear();
			DDL_CP_INSRCOMP.Items.Add(new ListItem("-- Pilih --",""));
			for (int i = 0; i < conn.GetRowCount(); i++)
			{
				String s0 = conn.GetFieldValue(i,0),
					s1 = conn.GetFieldValue(i,1);
				ListItem li = new ListItem(s1,s0);
				DDL_CP_INSRCOMP.Items.Add(li);
			}
		}

		/// <summary>
		/// Mengisi dropdown Insurance Type
		/// </summary>
		private void fillInsrType()
		{
			/**
			DDL_CP_INSRTYPE.Items.Clear();
			if (DDL_CP_INSRCOMP.SelectedValue.Trim() == "")
				return;
			conn.QueryString = "select distinct IT_ID, IT_DESC from VW_CREOPR_NOTARYASSIGN_RFINSRTYPE_CREDASU "+
				"where IC_ID = '" + DDL_CP_INSRCOMP.SelectedValue.Trim() + "' ";
			conn.ExecuteQuery();
			for (int i = 0; i < conn.GetRowCount(); i++)
			{
				String s0 = conn.GetFieldValue(i,0),
					s1 = conn.GetFieldValue(i,1);
				ListItem li = new ListItem(s1,s0);
				DDL_CP_INSRTYPE.Items.Add(li);
			}
			**/

			conn.QueryString = "select distinct IT_ID, IT_DESC from VW_CREOPR_NOTARYASSIGN_RFINSRTYPE_CREDASU ";
			conn.ExecuteQuery();
			for (int i = 0; i < conn.GetRowCount(); i++)
			{
				String s0 = conn.GetFieldValue(i,0), s1 = conn.GetFieldValue(i,1);
				ListItem li = new ListItem(s1,s0);
				DDL_CP_INSRTYPE.Items.Add(li);
			}
			fillInsrComp();
		}

		private void bindData()
		{
			DataTable dt = new DataTable();
			DataRow dr;
			conn.QueryString = "SELECT SEQ, ICT_DESC, IC_DESC, IT_DESC, ACR_AMOUNT, " +
				"ACR_PERCENTAGE, ACR_PREMI, IC_ID, IT_ID, ACR_ICRATE, ICT_ID, CURRENCYID, CURRENCYDESC, "+
				"ACR_POLICYNO, ACR_DATESTART, ACR_DATEEND, CASE WHEN ICT_LEAD = '1' THEN 'Leader' ELSE '' END ICT_LEADDESC " +
				"FROM VW_CREOPR_NOTARYASSIGN_CREDASU WHERE AP_REGNO = '" + LBL_REGNO.Text.Trim() +
				"' AND PRODUCTID = '" + LBL_PRODUCTID.Text.Trim() + "' and APPTYPE = '" + LBL_APPTYPE.Text.Trim() + 
				"' ORDER BY IC_DESC ";
			conn.ExecuteQuery();
			dt.Columns.Add(new DataColumn("SEQ"));
			dt.Columns.Add(new DataColumn("ICT_DESC"));
			dt.Columns.Add(new DataColumn("INSRCOMPDESC"));
			dt.Columns.Add(new DataColumn("INSRTYPEDESC"));
			dt.Columns.Add(new DataColumn("AN_VALUE"));
			dt.Columns.Add(new DataColumn("AN_PERCENTAGE"));
			dt.Columns.Add(new DataColumn("AN_PREMI"));
			dt.Columns.Add(new DataColumn("IC_ID"));
			dt.Columns.Add(new DataColumn("IT_ID"));
			dt.Columns.Add(new DataColumn("RATE"));
			dt.Columns.Add(new DataColumn("ICT_ID"));
			dt.Columns.Add(new DataColumn("CUR_ID"));
			dt.Columns.Add(new DataColumn("AN_CUR"));
			dt.Columns.Add(new DataColumn("AN_POLICYNO"));
			dt.Columns.Add(new DataColumn("AN_DATESTART"));
			dt.Columns.Add(new DataColumn("AN_DATEEND"));
			dt.Columns.Add(new DataColumn("ICT_LEADDESC"));
			for (int i = 0; i < conn.GetRowCount(); i++) 
			{
				dr = dt.NewRow();
				for (int j = 0; j < conn.GetColumnCount(); j++)
				{
					dr[j] = conn.GetFieldValue(i,j);
				}
				dt.Rows.Add(dr);
			}
			DataGrid1.DataSource = new DataView(dt);
			try
			{
				DataGrid1.DataBind();
			}
			catch 
			{
				DataGrid1.CurrentPageIndex = DataGrid1.PageCount - 1;
				DataGrid1.DataBind();
			}
			for (int j = 0; j < DataGrid1.Items.Count; j++)
			{
				DataGrid1.Items[j].Cells[6].Text = tool.MoneyFormat(DataGrid1.Items[j].Cells[6].Text );
				DataGrid1.Items[j].Cells[9].Text = tool.MoneyFormat(DataGrid1.Items[j].Cells[9].Text );
				DataGrid1.Items[j].Cells[10].Text = tool.MoneyFormat(DataGrid1.Items[j].Cells[10].Text );
			}
		}

		private void clearEditBoxes()
		{
			try
			{
				DDL_CP_INSRCOMP.SelectedIndex = 0;
				DDL_ICRATE.SelectedIndex = 0;
				DDL_INSURANCECOMPANYTYPE.SelectedIndex = 0;
				DDL_CP_CUR.SelectedIndex = 0;
				DDL_DATESTART_MONTH.SelectedIndex = 0;
				DDL_DATEEND_MONTH.SelectedIndex = 0;
			}
			catch {}
			TXT_CP_POLICYNO.Text = "";
			TXT_CP_INSRAMNT.Text = "";
			TXT_CP_INSRPCT.Text = "";
			TXT_CP_INSRPREMI.Text = "";
			TXT_DATESTART_DAY.Text = "";
			TXT_DATESTART_YEAR.Text = "";
			TXT_DATEEND_DAY.Text = "";
			TXT_DATEEND_YEAR.Text = "";
			LBL_H_SEQ.Text = "0";
			BTN_TAMBAH.Text = "Tambah";
			BTN_CANCEL.Visible = false;
			RDO_LEAD.SelectedValue = "0";
		}

		private string validateSQLString(string str)
		{
			return str.Replace("'", "''");

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
			this.DataGrid1.ItemCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.DataGrid1_ItemCommand);
			this.DATA_EXPORT.ItemCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.DATA_EXPORT_ItemCommand);

		}
		#endregion

		void Grid_Change(Object sender, DataGridPageChangedEventArgs e) 
		{
			// Set CurrentPageIndex to the page the user clicked.
			DataGrid1.CurrentPageIndex = e.NewPageIndex;
			// Re-bind the data to refresh the DataGrid control. 
			bindData();	
		}

		protected void BTN_SAVE_Click(object sender, System.EventArgs e)
		{
			//20071003 add by sofyan
			//cek validasi tanggal PK hanya kalau isian PK enabled aja (supaya bisa save biaya)
			if (TXT_CP_PKNO.Enabled == true &&	TXT_CP_PKDATEDAY.Enabled == true && DDL_CP_PKDATEMONTH.Enabled == true &&	TXT_CP_PKDATEYEAR.Enabled == true)
				if (!GlobalTools.isDateValid(TXT_CP_PKDATEDAY.Text, DDL_CP_PKDATEMONTH.SelectedValue, TXT_CP_PKDATEYEAR.Text)) 
				{
					GlobalTools.popMessage(this, "Tanggal PK tidak valid!");
					GlobalTools.SetFocus(this, TXT_CP_PKDATEDAY);
					return;
				}

			string pk = RBL_LEGALSTA.SelectedValue.Trim();
			conn.QueryString = "exec LGL_SCREDIT '"+ 
				LBL_REGNO.Text +"', '"+ 
				LBL_APPTYPE.Text +"', '" +
				LBL_PRODUCTID.Text + "', " + 
				tool.ConvertFloat(TXT_CP_BEAADM.Text) +", "+
				tool.ConvertFloat(TXT_CP_BEAPROVISI.Text) +", "+ 
				tool.ConvertFloat(TXT_CP_BEANOTARIS.Text) + ", "+ 
				tool.ConvertFloat(TXT_CP_BEAIKAT.Text) +", "+ 
				tool.ConvertFloat(TXT_CP_BEAMATERAI.Text) + ", '" + 
				pk + "', '" + 
				validateSQLString(TXT_CP_PKNO.Text.Trim()) + "', '" + 
				validateSQLString(TXT_CP_PKNOADD.Text.Trim()) + "', " + 
				tool.ConvertDate(TXT_CP_PKDATEDAY.Text, DDL_CP_PKDATEMONTH.SelectedValue, TXT_CP_PKDATEYEAR.Text) + ", " + 
				tool.ConvertDate(TXT_CP_PKDATEADDDAY.Text, DDL_CP_PKDATEADDMONTH.SelectedValue, TXT_CP_PKDATEADDYEAR.Text) + 
				", '" + LBL_PROD_SEQ.Text + "', '" + 
				tool.ConvertFloat(TXT_CP_BEAPROVISI_PCT.Text) + "', '" + 
				tool.ConvertFloat(TXT_CP_BEAUPFRONTFEE.Text) + "'";
			try 
			{
				conn.ExecuteNonQuery();
			} 
			catch (ApplicationException ex) 
			{
				Tools.popMessage(this, "Input tidak valid !");
				ExceptionHandling.Handler.saveExceptionIntoWindowsLog(ex, Request.Path, "App :" + LBL_REGNO.Text);
				return;
			}
			catch (NullReferenceException ex) 
			{
				Tools.popMessage(this, "Server Error !");
				ExceptionHandling.Handler.saveExceptionIntoWindowsLog(ex, Request.Path, "App :" + LBL_REGNO.Text);
				return;
			}

			ViewData();
		}

		protected void BTN_TAMBAH_Click(object sender, System.EventArgs e)
		{
			string str = "";
			double val;

			string regno=LBL_REGNO.Text.Trim(),
				curef=LBL_CUREF.Text.Trim(),
				apptype=LBL_APPTYPE.Text.Trim(),
				prodid=LBL_PRODUCTID.Text.Trim(),
				seq = LBL_H_SEQ.Text.Trim(),
				type = DDL_INSURANCECOMPANYTYPE.SelectedValue.Trim(),
				compname=DDL_CP_INSRCOMP.SelectedValue.Trim(),
				insrtype=DDL_CP_INSRTYPE.SelectedValue.Trim(),
				insramount=tool.ConvertFloat(TXT_CP_INSRAMNT.Text.Trim()),
				insrpct=TXT_CP_INSRPCT.Text.Trim(),
				insrpremi=tool.ConvertFloat(TXT_CP_INSRPREMI.Text.Trim()),
				rate=DDL_ICRATE.SelectedValue.Trim(),
				insrpolicyno=validateSQLString(TXT_CP_POLICYNO.Text.Trim()),
				insrcur=DDL_CP_CUR.SelectedValue.Trim(),
				insrdatestart="",
				insrdateend="",
				isLead=RDO_LEAD.SelectedValue;

			try
			{
				if(isLead=="1")
				{
					conn.QueryString = "SELECT CURRENCYID, CURRENCYDESC" +
						" FROM VW_CREOPR_NOTARYASSIGN_CREDASU WHERE AP_REGNO = '" + LBL_REGNO.Text.Trim() +
						"' And ICT_LEAD = '1' AND PRODUCTID = '" + LBL_PRODUCTID.Text.Trim() + "' and APPTYPE = '" + LBL_APPTYPE.Text.Trim() + 
						"' ORDER BY IC_DESC ";

					conn.ExecuteQuery();

					if(conn.GetRowCount() > 0)
					{
						GlobalTools.popMessage(this, "Leader sudah ada.");
						return;
					}
				}
				conn.QueryString = "SELECT CURRENCYID, CURRENCYDESC " +
					" FROM VW_CREOPR_NOTARYASSIGN_CREDASU WHERE AP_REGNO = '" + LBL_REGNO.Text.Trim() +
					"' And CURRENCYID <> '" + insrcur + "' AND PRODUCTID = '" + LBL_PRODUCTID.Text.Trim() + "' and APPTYPE = '" + LBL_APPTYPE.Text.Trim() + 
					"' ORDER BY IC_DESC ";
				conn.ExecuteQuery();

				if(conn.GetRowCount() > 0)
				{
					GlobalTools.popMessage(this, "Mata uang yang dipakai lebih dari 1");
					return;
				}

			}
			catch
			{
			}
			
			try
			{
				insrdatestart=Tools.toSQLDate(TXT_DATESTART_DAY,DDL_DATESTART_MONTH,TXT_DATESTART_YEAR);
			}
			catch {}
			try
			{
				insrdateend=Tools.toSQLDate(TXT_DATEEND_DAY,DDL_DATEEND_MONTH,TXT_DATEEND_YEAR);
			}
			catch {}

			if (insrpct.Trim() == "") insrpct = "0";
			if (compname == "")
				str += "Nama Perusahaan Asuransi harus dipilih! ";
			val = 0;
			if (Request.QueryString["na"] != "2")
			{
				if(TXT_CP_POLICYNO.Text.Trim() == "")
					str += "No Polis harus diisi! ";
				if(DDL_CP_CUR.SelectedValue.Trim() == "")
					str += "Mata uang harus dipilih! ";
				val = 0;
				try {val = double.Parse(insramount);} 
				catch {}
				if (val <= 0) str += "Nilai Pertanggungan harus diisi! ";
				val = 0;
				try 
				{
					if((TXT_DATESTART_DAY.Text.Trim()!="")&&(TXT_DATESTART_YEAR.Text.Trim()!="")&&
						(DDL_DATESTART_MONTH.SelectedValue.Trim()!="")) val=1;
				}
				catch{}
				if (val <= 0) str += "Tanggal mulai harus diisi! ";
				val = 0;
				try 
				{
					if((TXT_DATEEND_DAY.Text.Trim()!="")&&(TXT_DATEEND_YEAR.Text.Trim()!="")&&
						(DDL_DATEEND_MONTH.SelectedValue.Trim()!="")) val=1;
				}
				catch{}
				if (val <= 0) str += "Tanggal akhir harus diisi! ";
				val = 0;
				try {val = double.Parse(insrpct);} 
				catch {}
				if ((val < 0)||(val > 100)) str += "Persentase Pertanggungan harus diisi dan tidak boleh lebih dari 100%! ";
				/*val = 0;
				try {val = double.Parse(insrpremi);} 
				catch{}
				if (val == 0) str += "Premi harus diisi! ";*/
			}
			if (str != "")
			{
				Tools.popMessage(this, str);
				return;
			}
			try
			{
				/*double amount = double.Parse(insramount),
					limit = double.Parse(tool.ConvertFloat(TXT_CP_LIMIT.Text));*/
				double amount = double.Parse(TXT_CP_INSRAMNT.Text.Trim()),
					limit = double.Parse(tool.ConvertFloat(TXT_CP_LIMIT.Text));
				if (amount > limit) 
				{
					Tools.popMessage(this,"Nilai Pertanggungan tidak boleh lebih dari Loan Amount (Limit). ");
					return;
				}
			}
			catch {}

			

			if (rate.Trim() == "")
				rate = "NULL";
			else
				rate = "'" + rate + "'";

			if (insrdatestart.Trim() == "")
				insrdatestart = "NULL";
			else
			{
				if (!Tools.isDateValid(this,TXT_DATESTART_DAY.Text,DDL_DATESTART_MONTH.SelectedValue,TXT_DATESTART_YEAR.Text))
				{
					Tools.popMessage(this, "Start date is not valid!");
					return;
				}
				insrdatestart = "'" + insrdatestart + "'";
			}

			if (insrdateend.Trim() == "")
				insrdateend = "NULL";
			else
			{
				if (!Tools.isDateValid(this,TXT_DATEEND_DAY.Text,DDL_DATEEND_MONTH.SelectedValue,TXT_DATEEND_YEAR.Text))
				{
					Tools.popMessage(this, "End date is not valid!");
					return;
				}
				insrdateend = "'" + insrdateend + "'";
			}

			if (insrcur.Trim() == "")
				insrcur = "NULL";
			else
				insrcur = "'" + insrcur + "'";

			insrpct = tool.ConvertFloat(insrpct);

			if (insramount.Trim() == "") insramount = "0";
			if (insrpct.Trim() == "") insrpct = "0";
			if (insrpremi.Trim() == "") insrpremi = "0";
			
			conn.QueryString = "exec NA_CREDASU_SAVE '" + regno + "', '" + curef + "', '" + apptype + 
				"', '" + prodid + "', " + seq + ", '" + type + "', '" + compname + "', '" + insrtype + "', '" +
				insrpolicyno + "', " + insrcur + ", " + insramount + ", " + insrdatestart + ", " +
				insrdateend + ", " + insrpct + ", " + insrpremi + ", " + rate + ", '" + LBL_PROD_SEQ.Text + "','" + isLead + "'";

			conn.ExecuteNonQuery();
			clearEditBoxes();
			bindData();

			Tools.initDateForm(TXT_CP_PKDATEDAY, DDL_CP_PKDATEMONTH, TXT_CP_PKDATEYEAR, false);
			Tools.initDateForm(TXT_DATESTART_DAY, DDL_DATESTART_MONTH, TXT_DATESTART_YEAR, false);
			Tools.initDateForm(TXT_DATEEND_DAY, DDL_DATEEND_MONTH, TXT_DATEEND_YEAR, false);
		}

		private void DataGrid1_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			string regno, seq, curef, apptype;
			switch(((LinkButton)e.CommandSource).CommandName)
			{
				case "print":
					regno = LBL_REGNO.Text.Trim();
						seq = e.Item.Cells[0].Text.Trim();
					curef = LBL_CUREF.Text.Trim();
					apptype = LBL_APPTYPE.Text.Trim();
					Response.Write("<script language='javascript'>window.open('../CoverNote/AsuransiKredit.aspx?regno=" +
						regno + "&seq=" + seq + "&cu_ref=" + curef + "','Asuransi_Kredit','status=no,scrollbars=yes,width=800,height=600');</script>");
					break;

				case "delete":
					regno = LBL_REGNO.Text.Trim();
						seq = e.Item.Cells[0].Text.Trim();
					//delete data
					conn.QueryString = "delete from APPCREDASURANCE where AP_REGNO = '" +
						regno + "' AND SEQ = " + seq;
					conn.ExecuteNonQuery();
					bindData();
					break;

				case "edit":

					LBL_H_SEQ.Text = e.Item.Cells[0].Text.Trim();
					try
					{
						DDL_INSURANCECOMPANYTYPE.SelectedValue = e.Item.Cells[15].Text.Trim();
					} 
					catch {}
					try
					{

						DDL_CP_INSRCOMP.SelectedValue = e.Item.Cells[12].Text.Trim();
						//fillInsrType(); //ahmad
					} 
					catch {}
					try
					{
						DDL_CP_INSRTYPE.SelectedValue = e.Item.Cells[13].Text.Trim();
					} 
					catch {}
					try
					{
						DDL_ICRATE.SelectedValue = e.Item.Cells[14].Text.Trim();
					} 
					catch {}
					TXT_CP_POLICYNO.Text = e.Item.Cells[4].Text.Trim();
					try
					{
						DDL_CP_CUR.SelectedValue = e.Item.Cells[16].Text.Trim();
					} 
					catch {}
					TXT_CP_INSRAMNT.Text = tool.MoneyFormat(e.Item.Cells[6].Text.Trim());
					try
					{
						TXT_DATESTART_DAY.Text = tool.FormatDate_Day(e.Item.Cells[7].Text.Trim());
						DDL_DATESTART_MONTH.SelectedValue = tool.FormatDate_Month(e.Item.Cells[7].Text.Trim());
						TXT_DATESTART_YEAR.Text = tool.FormatDate_Year(e.Item.Cells[7].Text.Trim());
					} 
					catch {}
					try
					{
						TXT_DATEEND_DAY.Text = tool.FormatDate_Day(e.Item.Cells[8].Text.Trim());
						DDL_DATEEND_MONTH.SelectedValue = tool.FormatDate_Month(e.Item.Cells[8].Text.Trim());
						TXT_DATEEND_YEAR.Text = tool.FormatDate_Year(e.Item.Cells[8].Text.Trim());
					} 
					catch {}

					string LeadDesc = e.Item.Cells[11].Text.Trim();
					if(LeadDesc.Trim() == "&nbsp;")
						RDO_LEAD.SelectedValue = "0";
					else
						RDO_LEAD.SelectedValue = "1";
						
					TXT_CP_INSRPCT.Text = e.Item.Cells[9].Text.Trim();
					TXT_CP_INSRPREMI.Text = tool.MoneyFormat(e.Item.Cells[10].Text.Trim());
					BTN_TAMBAH.Text = "Save";
					BTN_CANCEL.Visible = true;
					break;

				default:
					// Do nothing.
					break;
			}
		}

		protected void BTN_CANCEL_Click(object sender, System.EventArgs e)
		{
			clearEditBoxes();
		}

		private void DDL_CP_INSRCOMP_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			fillInsrType();
		}

		protected void TXT_CP_BEAPROVISI_PCT_TextChanged(object sender, System.EventArgs e)
		{
			try
			{
				/*double dbl = (Double.Parse(tool.ConvertFloat(TXT_CP_BEAPROVISI_PCT.Text)) / 100) * 
					Double.Parse(tool.ConvertFloat(TXT_CP_LIMIT.Text));*/
				/*double dbl = (Double.Parse(TXT_CP_BEAPROVISI_PCT.Text) / 100) * 
					Double.Parse(TXT_CP_LIMIT.Text);*/
				double pct = (Double.Parse(TXT_CP_BEAPROVISI_PCT.Text) / 100), 
					limit = Double.Parse(TXT_CP_LIMIT.Text), val;
				if (pct <= 0)
				{
					pct = 0;
					TXT_CP_BEAPROVISI_PCT.Text = "0";
				}
				else if (pct > 1)
				{
					pct = 1;
					TXT_CP_BEAPROVISI_PCT.Text = "100";
				}
				val = pct * limit;
				TXT_CP_BEAPROVISI.Text = tool.MoneyFormat(val.ToString());
			}
			catch {}
		}

		protected void BTN_EXPORT_Click(object sender, System.EventArgs e)
		{

			string szId = tool.ConvertNull(DDL_FORMAT_TYPE.SelectedValue);
			object objType = Type.Missing;
			string mStatus = string.Empty;
			string mStatusReport = string.Empty;

			try
			{
				System.Threading.Thread.CurrentThread.CurrentCulture = System.Globalization.CultureInfo.CreateSpecificCulture("en-US");
				System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("en-US");

				mStatus = p_CreatePKWord();

				ViewFileExport();
			}
			catch (Exception ex)
			{
				LBL_STATUS_EXPORT.ForeColor = Color.Red;
				LBL_STATUSEXPORT.ForeColor = Color.Red;
				mStatus		  = "Error Exporting File";
				mStatusReport = ex.ToString();
			}
			finally
			{
				LBL_STATUS_EXPORT.Text = mStatus.Trim();
				LBL_STATUSEXPORT.Text = mStatusReport.Trim();
			}
		}


		#region p_CreatePKWord return string
		private string p_CreatePKWord()
		{
			string fileNm = string.Empty;
			string fileIn = string.Empty;
			string fileOut = string.Empty;
			string mStatus = string.Empty;
			object objType = Type.Missing;
			bool bSukses = true;
			object objValue = null;					
			int iItem = 0;

			System.Data.DataTable dt_field = null;

			conn.QueryString = "Select * from PK where PK_ID = '" + var_idExport + "'";
			conn.ExecuteQuery();
				
			if (conn.GetRowCount() > 0) 
			{
				// Set the culture and UI culture to the browser's accept language

				string nota = conn.GetFieldValue("PK_ID");
				string path = conn.GetFieldValue("PK_PATH");
				string template_path = conn.GetFieldValue("TEMPLATE_PATH");
				string file_doc = nota + ".DOT";
				string url = conn.GetFieldValue("PK_URL");
	

				fileNm = Request.QueryString["regno"] + "-" + Request.QueryString["productid"] + "-" + nota + "-" + var_user + ".DOC";
				object oMissingObject = System.Reflection.Missing.Value;
				object objFileIn = template_path + file_doc;	// input file is from directory template
				object objFileOut = path + fileNm;				// output file is to directory upload (or in this case template)

				Word.Application wordApp = null;
				Word.Document wordDoc = null;

				ArrayList orgId = new ArrayList();
				ArrayList newId = new ArrayList();
		
				//Collecting Existing Winword in Taskbar

				Process[] oldProcess = Process.GetProcessesByName("WINWORD");
				foreach(Process thisProcess in oldProcess)
					orgId.Add(thisProcess);
		
				try
				{

					wordApp = new Word.ApplicationClass();
					wordApp.Visible = false;

					//Collecting Existing Winword in Taskbar 

					Process[] newProcess = Process.GetProcessesByName("WINWORD");
					foreach(Process thisProcess in newProcess)
						newId.Add(thisProcess);

					/// Save process into database
					/// 					
					//SupportTools.saveProcessWord(wordApp, newId, orgId, conn);

					iItem = 0;		

					wordDoc = wordApp.Documents.Open(ref objFileIn, ref oMissingObject, ref oMissingObject, ref oMissingObject, ref oMissingObject, ref oMissingObject, 
						ref oMissingObject, ref oMissingObject, ref oMissingObject, ref oMissingObject, ref oMissingObject, ref oMissingObject);

					wordDoc.Activate();
					Word.Bookmarks wordBookMark = (Word.Bookmarks)wordDoc.Bookmarks;


					#region Step Fill All Data
					// Step 1
					conn.QueryString = "Select * from PK_DETAIL1 where PK_ID = '" + nota + "' order by PK_ID, SEQ";
					conn.ExecuteQuery();
		
					dt_field = conn.GetDataTable().Copy();

					conn.QueryString = "exec CP_EXPORT_PK_WORD1 '" + Request.QueryString["regno"] + "', '" + Request.QueryString["productid"] + "', '" + Request.QueryString["prod_seq"] + "'";
					conn.ExecuteQuery();

					string szBilang = GlobalTools.Terbilang(conn.GetFieldValue("LIMIT"));

					for(int j = 0; j < conn.GetRowCount(); j++)
					{
						for(int i = 0; i < dt_field.Rows.Count; i++)
						{
							object Cell = dt_field.Rows[i][2];
							string Field = dt_field.Rows[i][4].ToString();

							objValue = conn.GetFieldValue(Field);
							
							string strObject = objValue.ToString();

							if(wordBookMark.Exists(Cell.ToString())) 
							{
								try
								{
									strObject = Convert.ToDateTime(objValue).ToShortDateString();
								}
								catch
								{}
								Word.Bookmark oBook = wordBookMark.Item(ref Cell);
								oBook.Select();
								oBook.Range.Text = strObject;
							}
							iItem++;
						}
					}
					#endregion
					#region Step Fill Finalizing
					// Step 1
					conn.QueryString = "Select * from PK_DETAIL9 where PK_ID = '" + nota + "' order by PK_ID, SEQ";
					conn.ExecuteQuery();
		
					dt_field = conn.GetDataTable().Copy();

					conn.QueryString = "exec CP_EXPORT_PK_WORD9 '" + Request.QueryString["regno"] + "', '" + var_user + "', '" + szBilang + "'";
					conn.ExecuteQuery();

					for(int j = 0; j < conn.GetRowCount(); j++)
					{
						for(int i = 0; i < dt_field.Rows.Count; i++)
						{
							object Cell = dt_field.Rows[i][2];
							string Field = dt_field.Rows[i][4].ToString();

							objValue = conn.GetFieldValue(Field);
							
							string strObject = objValue.ToString();

							if(wordBookMark.Exists(Cell.ToString())) 
							{
								try
								{
									strObject = Convert.ToDateTime(objValue).ToShortDateString();
								}
								catch
								{}
								Word.Bookmark oBook = wordBookMark.Item(ref Cell);
								oBook.Select();
								oBook.Range.Text = strObject;
							}
							iItem++;
						}
					}
					#endregion

					if(iItem > 0) 
					{
						wordDoc.SaveAs(ref objFileOut, ref oMissingObject, ref oMissingObject, ref oMissingObject, ref oMissingObject, ref oMissingObject, 
							ref oMissingObject, ref oMissingObject, ref oMissingObject, ref oMissingObject, ref oMissingObject);

						System.Threading.Thread.Sleep(TimeSpan.FromSeconds(3));  																					 
						bSukses = true;
					}
					else
						bSukses = false;

					if(bSukses)	
					{
						// Maintenance Table Nota_Export

						conn.QueryString = "exec NA_PK_EXPORT '" + nota +"','" + Request.QueryString["regno"] + "', '" + Request.QueryString["productid"] + "','" + fileNm + "', '" + Session["UserID"] + "', '1'";
						conn.ExecuteQuery();

						mStatus = "Export Succesfully";

					}
					else
					{
						mStatus = "No Data to Export";
					}
				}
				catch{}
				finally
				{

					if(wordDoc!=null)
					{
						wordDoc.Close(ref oMissingObject, ref oMissingObject, ref oMissingObject);
						wordDoc=null;
					}
					if(wordApp!=null)
					{
						wordApp.Application.Quit(ref oMissingObject, ref oMissingObject, ref oMissingObject);
						wordApp=null;

						// Killing Proses after Export
						for(int x = 0; x < newId.Count; x++)
						{
							Process xnewId = (Process)newId[x];
				
							bool bSameId = false;
							for(int z = 0; z < orgId.Count; z++)
							{
								Process xoldId = (Process)orgId[z];
		
								if(xnewId.Id == xoldId.Id) 
								{
									bSameId = true;
									break;
								}
							}
                            if (!bSameId)
                            {
                                try
                                {
                                    xnewId.Kill();
                                }
                                catch (Exception e)
                                {
                                    continue;
                                }
                            }
						}
					}
				}
			}
			return mStatus;
		}
		#endregion


		private void DATA_EXPORT_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			switch (((LinkButton)e.CommandSource).CommandName)
			{
				case "delete":
					conn.QueryString = "exec NA_PK_EXPORT '" + e.Item.Cells[0].Text +"','" + Request.QueryString["regno"] + "', '" + Request.QueryString["productid"] + "', '', '" + Session["UserID"] + "', '2'";
					conn.ExecuteQuery();

					ViewFileExport();
					//tambahkan function untuk delete file
					break;
			}
		}

		private void ViewFileExport()
		{
			conn.QueryString = "Select * from PK";
			conn.ExecuteQuery();
			
			if (conn.GetRowCount() > 0) 
			{
				string url = conn.GetFieldValue("PK_URL");
			
				System.Data.DataTable dt = new System.Data.DataTable();
				conn.QueryString = "select * from PK_EXPORT where AP_REGNO ='"+ Request.QueryString["regno"] + "' And ProductId ='" + Request.QueryString["productid"] + "'";
				conn.ExecuteQuery();
				dt = conn.GetDataTable().Copy();
				DATA_EXPORT.DataSource = dt;
				try 
				{
					DATA_EXPORT.DataBind();
				} 
				catch 
				{
					DATA_EXPORT.CurrentPageIndex = 0;
					DATA_EXPORT.DataBind();
				}
				for (int i = 1; i <= DATA_EXPORT.Items.Count; i++)
				{
					HyperLink HpDownload = (HyperLink) DATA_EXPORT.Items[i-1].Cells[2].FindControl("HL_DOWNLOAD");
					LinkButton HpDelete = (LinkButton) DATA_EXPORT.Items[i-1].Cells[3].FindControl("LinkButton1");
					HpDownload.NavigateUrl = url + DATA_EXPORT.Items[i-1].Cells[1].Text.Trim();
					if (var_user.ToString().Trim() != DATA_EXPORT.Items[i-1].Cells[4].Text)
						HpDelete.Visible	= false;

					if (Request.QueryString["cp"] == "0") 
					{
						//HpDownload.Enabled = false;
						HpDelete.Enabled = false;
					}
				}
			}
		}

		protected void DDL_CP_INSRTYPE_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			fillInsrComp();
		}
	}
}
