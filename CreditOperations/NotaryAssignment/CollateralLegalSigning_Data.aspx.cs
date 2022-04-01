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

namespace SME.CreditOperations.NotaryAssignment
{
	/// <summary>
	/// Summary description for CollateralLegalSigning_Data.
	/// </summary>
	public partial class CollateralLegalSigning_Data : System.Web.UI.Page
	{
	

		//protected Connection conn = new Connection("Data Source=10.123.12.30;Initial Catalog=SMEDEV;uid=sa;pwd=");
		protected Connection conn;
		protected Tools tool = new Tools();

		protected void Page_Load(object sender, System.EventArgs e)
		{
			conn = (Connection) Session["Connection"];

			if (!IsPostBack)
			{
				LBL_REGNO.Text = Request.QueryString["regno"];
				LBL_CUREF.Text = Request.QueryString["curef"];
				LBL_PRODUCTID.Text = Request.QueryString["prod"];
				LBL_TC.Text = Request.QueryString["tc"];
				LBL_CL_SEQ.Text = Request.QueryString["cl_seq"];

				//init rfikat
				conn.QueryString = "select IKATID, IKATDESC from RFIKAT where active = '1' ";
				conn.ExecuteQuery();
				DDL_CL_IKATTYPE.Items.Clear();
				DDL_CL_IKATTYPE.Items.Add(new ListItem("-- Pilih --", ""));
				for (int i=0; i<conn.GetRowCount(); i++)
					DDL_CL_IKATTYPE.Items.Add(new ListItem(conn.GetFieldValue(i, 1), conn.GetFieldValue(i, 0)));

				//init rflegalstatus
				conn.QueryString = "select LEGALSTAID, LEGALSTADESC from RFLEGALSTATUS where active = '1' ";
				conn.ExecuteQuery();
				RBL_LEGALSTA.Items.Clear();
				for (int i=0; i<conn.GetRowCount(); i++)
					RBL_LEGALSTA.Items.Add(new ListItem(conn.GetFieldValue(i, 1), conn.GetFieldValue(i, 0)));
				try { RBL_LEGALSTA.Items[RBL_LEGALSTA.Items.Count - 1].Selected = true; } 
				catch {}

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

				//init broker
				conn.QueryString = "SELECT BROKERID, BROKERDESC FROM VW_RFBROKER ";
				conn.ExecuteQuery();
				DDL_CI_BROKER.Items.Clear();
				DDL_CI_BROKER.Items.Add(new ListItem("-- Pilih --", ""));
				for (int i=0; i<conn.GetRowCount(); i++)
					DDL_CI_BROKER.Items.Add(new ListItem(conn.GetFieldValue(i, 1), conn.GetFieldValue(i, 0)));

				Tools.initDateForm(TXT_DATESTART_DAY, DDL_DATESTART_MONTH, TXT_DATESTART_YEAR, false);
				Tools.initDateForm(TXT_DATEEND_DAY, DDL_DATEEND_MONTH, TXT_DATEEND_YEAR, false);
				Tools.initDateForm(TXT_PREMIDATE_DAY, DDL_PREMIDATE_MONTH, TXT_PREMIDATE_YEAR, false);
				Tools.initDateForm(TXT_ORDERDATE_DAY, DDL_ORDERDATE_MONTH, TXT_ORDERDATE_YEAR, false);
				Tools.initDateForm(TXT_COVERDATE_DAY, DDL_COVERDATE_MONTH, TXT_COVERDATE_YEAR, false);
				Tools.initDateForm(TXT_COVERDUEDATE_DAY, DDL_COVERDUEDATE_MONTH, TXT_COVERDUEDATE_YEAR, false);
				Tools.initDateForm(TXT_POLICYDATE_DAY, DDL_POLICYDATE_MONTH, TXT_POLICYDATE_YEAR, false);

				ViewData();
				fillInsrType();
				bindData();
			}
			else
			{
				TXT_CI_AMNT.Text = tool.MoneyFormat(TXT_CI_AMNT.Text);
				TXT_CI_PREMI.Text = tool.MoneyFormat(TXT_CI_PREMI.Text);
				TXT_CI_INSRPCT.Text = tool.MoneyFormat(TXT_CI_INSRPCT.Text);
				TXT_CL_APPRVALUE.Text = tool.MoneyFormat(TXT_CL_APPRVALUE.Text);
				TXT_CL_OFFERVALUE.Text = tool.MoneyFormat(TXT_CL_OFFERVALUE.Text);
				TXT_CI_AMNT_BANG.Text = tool.MoneyFormat(TXT_CI_AMNT_BANG.Text);
				TXT_CI_AMNT_MESIN.Text = tool.MoneyFormat(TXT_CI_AMNT_MESIN.Text);
				TXT_CI_AMNT_LAIN.Text = tool.MoneyFormat(TXT_CI_AMNT_LAIN.Text);
				TXT_CI_PREMI_DIBAYAR.Text = tool.MoneyFormat(TXT_CI_PREMI_DIBAYAR.Text);
			}
			secureData();
			DataGrid1.PageIndexChanged += new DataGridPageChangedEventHandler(this.Grid_Change);
			BTN_SAVE.Attributes.Add("onclick","if(!cek_mandatory(document.Form1)){return false;};");
		}

		private void secureData() 
		{
			if (Request.QueryString["na"]=="0") 
			{
				//--- protect Datagrid
				DataGrid1.Columns[17].Visible = false;
				for(int i=0; i<DataGrid1.Items.Count; i++) 
				{
					DataGrid1.Items[i].Cells[17].Visible = false;
				}
				
				RBL_LEGALSTA.Enabled	= false;
				DDL_CL_IKATTYPE.Enabled = false;
				BTN_SAVE.Visible		= false;
				BTN_PRINT.Visible		= false;
			}
		}

		private void ViewData()
		{
			string sibscolid;
			/*conn.QueryString = "select isnull(cl_apprvalue,0) * lc_percentage APPRVALUE, LC_VALUE, CL_TYPE, "+
				"ACL_IKATID, ACL_LEGALSTATUS, CL_DESC "+
				"from LIST-COLLATERAL LC inner join COLLATERAL CL ON CL.CU_REF = LC.CU_REF AND CL.CL_SEQ = LC.CL_SEQ "+
				"left join APPCOLLEGAL acl on LC.AP_REGNO = acl.AP_REGNO AND LC.PRODUCTID = acl.PRODUCTID AND "+
				"LC.CL_SEQ = acl.CL_SEQ "+
				"where LC.AP_REGNO = '"+ LBL_REGNO.Text +"' AND LC.PRODUCTID = '" + LBL_PRODUCTID.Text +
						"' AND LC.CL_SEQ = "+ LBL_CL_SEQ.Text +" ";*/
			conn.QueryString = "SELECT TOP 1 IKATID FROM RFIKAT WHERE [DEFAULT] = '1' and active = '1' ";
			conn.ExecuteQuery();
			try
			{
				DDL_CL_IKATTYPE.SelectedValue = conn.GetFieldValue("IKATID");
			} 
			catch {}	//default bentuk pengikatan

			conn.QueryString = "select top 1 APPRVALUE, LC_VALUE, CL_TYPE, ACL_IKATID, ACL_LEGALSTATUS, CL_DESC, "+
				"ADDR1, ADDR2, ADDR3, SIBS_COLID "+
				"FROM VW_CREOPR_NOTARYASSIGN_COLDATA "+
				"WHERE AP_REGNO = '"+ LBL_REGNO.Text +//"' AND PRODUCTID = '" + LBL_PRODUCTID.Text +
				"' AND CL_SEQ = "+ LBL_CL_SEQ.Text +" ";
			conn.ExecuteQuery();

			TXT_CL_DESC.Text = conn.GetFieldValue("CL_DESC");
			TXT_CL_APPRVALUE.Text = tool.MoneyFormat(conn.GetFieldValue("APPRVALUE"));
			TXT_CL_OFFERVALUE.Text = tool.MoneyFormat(conn.GetFieldValue("LC_VALUE"));
			TXT_CI_AMNT.Text = tool.MoneyFormat(conn.GetFieldValue("LC_VALUE"));
			LBL_CL_TYPE.Text = conn.GetFieldValue("CL_TYPE").Trim();
			//CHB_CL_SERTADDRSM.Checked = tool.ConvertCheck(conn.GetFieldValue("CL_SERTADDRSM"));
			TXT_CL_SERTADDR1.Text = conn.GetFieldValue("ADDR1");
			TXT_CL_SERTADDR2.Text = conn.GetFieldValue("ADDR2");
			TXT_CL_SERTADDR3.Text = conn.GetFieldValue("ADDR3");
			sibscolid = conn.GetFieldValue("SIBS_COLID");
			//RDB_CM1.Checked = true;
			//RDB_CM2.Checked = true;
			try
			{
				DDL_CL_IKATTYPE.SelectedValue = conn.GetFieldValue("ACL_IKATID").Trim();
			} 
			catch {}
			try
			{
				RBL_LEGALSTA.SelectedValue = conn.GetFieldValue("ACL_LEGALSTATUS").Trim();
			} 
			catch{}
			if ((Request.QueryString["na"] != "2")&&(sibscolid == ""))
			{
				DDL_CL_IKATTYPE.CssClass = "mandatory";
			}
		}

		private void fillInsrComp()
		{
			DDL_CI_COMP.Items.Clear();
			if (DDL_CI_TYPE.SelectedValue.Trim() == "")
				return;
			/*conn.QueryString = "select INSRCOMPID, INSRCOMPDESC "+
				"from VW_CREOPR_NOTARYASSIGN_RFINSRCOMPANY_COLASU ";
			conn.ExecuteQuery();*/
			conn.QueryString = "select distinct IC_ID, IC_DESC "+
				"from VW_CREOPR_NOTARYASSIGN_RFINSRCOMPANY_COLASU "+
				"where IT_ID = '" + DDL_CI_TYPE.SelectedValue.Trim() +
				"' AND COLTYPESEQ = '" + LBL_CL_TYPE.Text + "' ";
			conn.ExecuteQuery();
			DDL_CI_COMP.Items.Add(new ListItem("-- Pilih --",""));
			for (int i = 0; i < conn.GetRowCount(); i++)
			{
				String s0 = conn.GetFieldValue(i,0),
					s1 = conn.GetFieldValue(i,1);
				ListItem li = new ListItem(s1,s0);
				DDL_CI_COMP.Items.Add(li);
			}
			//fillInsrType();
			//bindData();
		}

		private void fillInsrType()
		{
			DDL_CI_TYPE.Items.Clear();
			/*if (DDL_CI_COMP.SelectedValue.Trim() == "")
				return;
			conn.QueryString = "select a.INSRTYPEID, INSRTYPEDESC from RFINSRTYPE a "+
				"inner join RFINSRCOMPINSRLIST b on a.INSRTYPEID = b.INSRTYPEID "+
				"where INSRCOMPID = '" + DDL_CI_COMP.SelectedValue.Trim() + "' ";*/
			conn.QueryString = "select distinct IT_ID, IT_DESC "+
				"from VW_CREOPR_NOTARYASSIGN_RFINSRTYPE_COLASU "+
				"where COLTYPESEQ = '" + LBL_CL_TYPE.Text + "' " ;
			conn.ExecuteQuery();
			DDL_CI_TYPE.Items.Add(new ListItem("-- Pilih --",""));
			for (int i = 0; i < conn.GetRowCount(); i++)
			{
				String s0 = conn.GetFieldValue(i,0),
					s1 = conn.GetFieldValue(i,1);
				ListItem li = new ListItem(s1,s0);
				DDL_CI_TYPE.Items.Add(li);
			}
			fillInsrComp();
		}

		private void bindData()
		{
			DataTable dt = new DataTable();
			DataRow dr;
			conn.QueryString = "SELECT distinct SEQ, ICT_DESC, IC_DESC, IT_DESC, ACA_AMOUNT, ACA_PERCENTAGE, " +
				"ACA_CLASS, ACA_PREMI, IC_ID, IT_ID, ACA_ICRATE, ICT_ID, CURRENCYID, CURRENCYDESC, " +
				"ACA_POLICYNO, ACA_DATESTART, ACA_DATEEND ,CASE WHEN ICT_LEAD = '1' THEN 'Leader' ELSE '' END ICT_LEADDESC, " +
				"BROKER_ID, ACA_AMOUNT_BANG, ACA_AMOUNT_MESIN, ACA_AMOUNT_LAIN, ACA_PREMI_DIBAYAR, ACA_PREMIDATE, " +
				"ACA_ORDERNO, ACA_ORDERDATE, ACA_COVERNO, ACA_COVERDATE, ACA_COVERDUEDATE, ACA_POLICYDATE " +
				"FROM VW_CREOPR_NOTARYASSIGN_COLASU WHERE AP_REGNO = '" + LBL_REGNO.Text.Trim() +
				//"' AND PRODUCTID = '" + LBL_PRODUCTID.Text.Trim() +
				"' AND CL_SEQ = " + LBL_CL_SEQ.Text +
				" ORDER BY IC_DESC ";
			conn.ExecuteQuery();
			dt.Columns.Add(new DataColumn("SEQ"));
			dt.Columns.Add(new DataColumn("ICT_DESC"));
			dt.Columns.Add(new DataColumn("INSRCOMPDESC"));
			dt.Columns.Add(new DataColumn("INSRTYPEDESC"));
			dt.Columns.Add(new DataColumn("ACA_VALUE"));
			dt.Columns.Add(new DataColumn("ACA_PERCENTAGE"));
			dt.Columns.Add(new DataColumn("ACA_CLASS"));
			dt.Columns.Add(new DataColumn("ACA_PREMI"));
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
			dt.Columns.Add(new DataColumn("BROKER_ID"));
			dt.Columns.Add(new DataColumn("ACA_AMOUNT_BANG"));
			dt.Columns.Add(new DataColumn("ACA_AMOUNT_MESIN"));
			dt.Columns.Add(new DataColumn("ACA_AMOUNT_LAIN"));
			dt.Columns.Add(new DataColumn("ACA_PREMI_DIBAYAR"));
			dt.Columns.Add(new DataColumn("ACA_PREMIDATE"));
			dt.Columns.Add(new DataColumn("ACA_ORDERNO"));
			dt.Columns.Add(new DataColumn("ACA_ORDERDATE"));
			dt.Columns.Add(new DataColumn("ACA_COVERNO"));
			dt.Columns.Add(new DataColumn("ACA_COVERDATE"));
			dt.Columns.Add(new DataColumn("ACA_COVERDUEDATE"));
			dt.Columns.Add(new DataColumn("ACA_POLICYDATE"));
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
				DataGrid1.Items[j].Cells[11].Text = tool.MoneyFormat(DataGrid1.Items[j].Cells[11].Text );
			}
		}

		private void clearEditBoxes()
		{
			try
			{
				//DDL_CI_COMP.SelectedIndex = 0;
				DDL_CI_TYPE.SelectedIndex = 0;
				DDL_CI_COMP.Items.Clear();
				DDL_ICRATE.SelectedIndex = 0;
				DDL_INSURANCECOMPANYTYPE.SelectedIndex = 0;
				DDL_CP_CUR.SelectedIndex = 0;
				DDL_DATESTART_MONTH.SelectedIndex = 0;
				DDL_DATEEND_MONTH.SelectedIndex = 0;
				DDL_CI_BROKER.SelectedIndex = 0;
				DDL_PREMIDATE_MONTH.SelectedIndex = 0;
				DDL_ORDERDATE_MONTH.SelectedIndex = 0;
				DDL_COVERDATE_MONTH.SelectedIndex = 0;
				DDL_COVERDUEDATE_MONTH.SelectedIndex = 0;
				DDL_POLICYDATE_MONTH.SelectedIndex = 0;
			}
			catch {}
			TXT_CP_POLICYNO.Text = "";
			TXT_CI_AMNT.Text = "";
			TXT_CI_CLASS.Text = "";
			TXT_CI_INSRPCT.Text = "";
			TXT_CI_PREMI.Text = "";
			LBL_H_SEQ.Text = "0";
			BTN_TAMBAH.Text = "Tambah";
			RDO_LEAD.SelectedValue = "0";
			BTN_CANCEL.Visible = false;
			TXT_CI_AMNT_BANG.Text = "";
			TXT_CI_AMNT_MESIN.Text = "";
			TXT_CI_AMNT_LAIN.Text = "";
			TXT_CI_PREMI_DIBAYAR.Text = "";
			TXT_CI_ORDERNO.Text = "";
			TXT_CI_COVERNO.Text = "";
			TXT_PREMIDATE_DAY.Text = "";
			TXT_PREMIDATE_YEAR.Text = "";
			TXT_ORDERDATE_DAY.Text = "";
			TXT_ORDERDATE_YEAR.Text = "";
			TXT_ORDERDATE_DAY.Text = "";
			TXT_ORDERDATE_YEAR.Text = "";
			TXT_COVERDATE_DAY.Text = "";
			TXT_COVERDATE_YEAR.Text = "";
			TXT_COVERDUEDATE_DAY.Text = "";
			TXT_COVERDUEDATE_YEAR.Text = "";
			TXT_POLICYDATE_DAY.Text = "";
			TXT_POLICYDATE_YEAR.Text = "";
		}

		private void cleansTextBox (TextBox tb)
		{
			if (tb.Text.Trim() == "&nbsp;")
				tb.Text = "";
		}

		private void cleansLabel (Label lb)
		{
			if (lb.Text.Trim() == "&nbsp;")
				lb.Text = "";
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

		}
		#endregion

		void Grid_Change(Object sender, DataGridPageChangedEventArgs e) 
		{
			// Set CurrentPageIndex to the page the user clicked.
			DataGrid1.CurrentPageIndex = e.NewPageIndex;
			// Re-bind the data to refresh the DataGrid control. 
			bindData();	
		}

		protected void BTN_TAMBAH_Click(object sender, System.EventArgs e)
		{
			string str = "";
			double val;

			string regno=LBL_REGNO.Text.Trim(),
				curef=LBL_CUREF.Text.Trim(),
				prodid=LBL_PRODUCTID.Text.Trim(),
				clseq=LBL_CL_SEQ.Text.Trim(),
				seq = LBL_H_SEQ.Text.Trim(),
				type = DDL_INSURANCECOMPANYTYPE.SelectedValue.Trim(),
				compname=DDL_CI_COMP.SelectedValue.Trim(),
				insrtype=DDL_CI_TYPE.SelectedValue.Trim(),
				insramount= tool.ConvertFloat(TXT_CI_AMNT.Text.Trim()),
				insrpct=TXT_CI_INSRPCT.Text.Trim(),
				insrclass=validateSQLString(TXT_CI_CLASS.Text.Trim()),
				insrpremi= tool.ConvertFloat(TXT_CI_PREMI.Text.Trim()),
				rate=DDL_ICRATE.SelectedValue.Trim(),
				insrpolicyno=validateSQLString(TXT_CP_POLICYNO.Text.Trim()),
				insrcur=DDL_CP_CUR.SelectedValue.Trim(),
				insrdatestart="",
				insrdateend="",
				isLead=RDO_LEAD.SelectedValue,
				broker=DDL_CI_BROKER.SelectedValue.Trim(),
				insramountbang= tool.ConvertFloat(TXT_CI_AMNT_BANG.Text.Trim()),
				insramountmesin= tool.ConvertFloat(TXT_CI_AMNT_MESIN.Text.Trim()),
				insramountlain= tool.ConvertFloat(TXT_CI_AMNT_LAIN.Text.Trim()),
				insrpremidibayar= tool.ConvertFloat(TXT_CI_PREMI_DIBAYAR.Text.Trim()),
				premidate="",
				orderno=validateSQLString(TXT_CI_ORDERNO.Text.Trim()),
				orderdate="",
				coverno=validateSQLString(TXT_CI_COVERNO.Text.Trim()),
				coverdate="",
				coverduedate="",
				policydate="";
			
			try
			{
				if(isLead=="1")
				{
					conn.QueryString = "SELECT CURRENCYID, CURRENCYDESC" +
						" FROM VW_CREOPR_NOTARYASSIGN_COLASU WHERE AP_REGNO = '" + regno +
						"' And ICT_LEAD = '1' AND CL_SEQ = " + clseq +
						" ORDER BY IC_DESC ";

					conn.ExecuteQuery();

					if(conn.GetRowCount() > 0)
					{
						GlobalTools.popMessage(this, "Leader sudah ada.");
						return;
					}
				}
				conn.QueryString = "SELECT CURRENCYID, CURRENCYDESC " +
					" FROM VW_CREOPR_NOTARYASSIGN_COLASU WHERE AP_REGNO = '" + regno +
					"' And CURRENCYID <> '" + insrcur + "' AND CL_SEQ = " + clseq + 
					" ORDER BY IC_DESC ";
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
			try
			{
				premidate=Tools.toSQLDate(TXT_PREMIDATE_DAY,DDL_PREMIDATE_MONTH,TXT_PREMIDATE_YEAR);
			}
			catch {}
			try
			{
				orderdate=Tools.toSQLDate(TXT_ORDERDATE_DAY,DDL_ORDERDATE_MONTH,TXT_ORDERDATE_YEAR);
			}
			catch {}
			try
			{
				coverdate=Tools.toSQLDate(TXT_COVERDATE_DAY,DDL_COVERDATE_MONTH,TXT_COVERDATE_YEAR);
			}
			catch {}
			try
			{
				coverduedate=Tools.toSQLDate(TXT_COVERDUEDATE_DAY,DDL_COVERDUEDATE_MONTH,TXT_COVERDUEDATE_YEAR);
			}
			catch {}
			try
			{
				policydate=Tools.toSQLDate(TXT_POLICYDATE_DAY,DDL_POLICYDATE_MONTH,TXT_POLICYDATE_YEAR);
			}
			catch {}

			if (insrpct.Trim() == "") insrpct = "0";
			if (compname == "")
				str += "Nama Perusahaan Asuransi harus dipilih! ";
			if (insrtype == "")
				str += "Jenis Asuransi harus dipilih! ";
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
				try {val = double.Parse(TXT_CI_AMNT.Text);} 
				catch {}
				if (val <= 0) str += "Nilai Pertanggungan harus diisi! ";
				val = 0;
				try {val = double.Parse(insrpct);} 
				catch {}
				if ((val < 0)||(val > 100)) str += "Persentase Pertanggungan harus diisi dan tidak boleh lebih dari 100%! ";
				/*val = 0;
				try {val = double.Parse(TXT_CI_PREMI.Text);} 
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
				double amount = double.Parse(TXT_CI_AMNT.Text),
					limit = double.Parse(TXT_CL_OFFERVALUE.Text);
				if (amount > limit) 
				{
					Tools.popMessage(this, "Nilai Pertanggungan tidak boleh lebih dari Offered Value. ");
					return;
				}
			} catch {}

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

			if (premidate.Trim() == "")
				premidate = "NULL";
			else
			{
				if (!Tools.isDateValid(this,TXT_PREMIDATE_DAY.Text,DDL_PREMIDATE_MONTH.SelectedValue,TXT_PREMIDATE_YEAR.Text))
				{
					Tools.popMessage(this, "Tanggal premi is not valid!");
					return;
				}
				premidate = "'" + premidate + "'";
			}

			if (orderdate.Trim() == "")
				orderdate = "NULL";
			else
			{
				if (!Tools.isDateValid(this,TXT_ORDERDATE_DAY.Text,DDL_ORDERDATE_MONTH.SelectedValue,TXT_ORDERDATE_YEAR.Text))
				{
					Tools.popMessage(this, "Tanggal surat order is not valid!");
					return;
				}
				orderdate = "'" + orderdate + "'";
			}

			if (coverdate.Trim() == "")
				coverdate = "NULL";
			else
			{
				if (!Tools.isDateValid(this,TXT_COVERDATE_DAY.Text,DDL_COVERDATE_MONTH.SelectedValue,TXT_COVERDATE_YEAR.Text))
				{
					Tools.popMessage(this, "Tanggal cover note is not valid!");
					return;
				}
				coverdate = "'" + coverdate + "'";
			}

			if (coverduedate.Trim() == "")
				coverduedate = "NULL";
			else
			{
				if (!Tools.isDateValid(this,TXT_COVERDUEDATE_DAY.Text,DDL_COVERDUEDATE_MONTH.SelectedValue,TXT_COVERDUEDATE_YEAR.Text))
				{
					Tools.popMessage(this, "Tanggal jatuh tempo cover note is not valid!");
					return;
				}
				coverduedate = "'" + coverduedate + "'";
			}

			if (policydate.Trim() == "")
				policydate = "NULL";
			else
			{
				if (!Tools.isDateValid(this,TXT_POLICYDATE_DAY.Text,DDL_POLICYDATE_MONTH.SelectedValue,TXT_POLICYDATE_YEAR.Text))
				{
					Tools.popMessage(this, "Tanggal polis tidak valid!");
					return;
				}
				policydate = "'" + policydate + "'";
			}

			if (insrcur.Trim() == "")
				insrcur = "NULL";
			else
				insrcur = "'" + insrcur + "'";

			insrpct = tool.ConvertFloat(insrpct);

			if (clseq == "") clseq = "0";
			if (insramount == "") insramount = "0";
			if (insrpct == "") insrpct = "0";
			if (insrpremi == "") insrpremi = "0";

			conn.QueryString = "exec NA_COLASU_SAVE '" + regno + "', '" +
				curef + "','"+prodid+"', " + clseq + ", " + seq + ", '" + type + "', '" +
				compname + "', '" + insrtype + "', '" + insrpolicyno + "', " + insrcur + ", " +
				insramount + ", " + insrdatestart + ", " + insrdateend + ", " + 
				insrpct + ", '" + insrclass + "', " + insrpremi + ", " + rate + ",'" + isLead + "', '" +
				broker + "', " + insramountbang + ", " + insramountmesin + ", " + insramountlain + ", " + insrpremidibayar + ", " + premidate + ", '" +
				orderno + "', " + orderdate + ", '" + coverno  + "', " + coverdate + ", " + coverduedate + ", " + policydate;
			conn.ExecuteNonQuery();
			clearEditBoxes();
			bindData();

			Tools.initDateForm(TXT_DATESTART_DAY, DDL_DATESTART_MONTH, TXT_DATESTART_YEAR, false);
			Tools.initDateForm(TXT_DATEEND_DAY, DDL_DATEEND_MONTH, TXT_DATEEND_YEAR, false);
			Tools.initDateForm(TXT_PREMIDATE_DAY, DDL_PREMIDATE_MONTH, TXT_PREMIDATE_YEAR, false);
			Tools.initDateForm(TXT_ORDERDATE_DAY, DDL_ORDERDATE_MONTH, TXT_ORDERDATE_YEAR, false);
			Tools.initDateForm(TXT_COVERDATE_DAY, DDL_COVERDATE_MONTH, TXT_COVERDATE_YEAR, false);
			Tools.initDateForm(TXT_COVERDUEDATE_DAY, DDL_COVERDUEDATE_MONTH, TXT_COVERDUEDATE_YEAR, false);
			Tools.initDateForm(TXT_POLICYDATE_DAY, DDL_POLICYDATE_MONTH, TXT_POLICYDATE_YEAR, false);
		}

		private void DataGrid1_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			string regno, curef, clseq, seq, prodid;
			switch(((LinkButton)e.CommandSource).CommandName)
			{
				case "print":
					//string cu_ref, cl_seq, productid;

					regno = LBL_REGNO.Text.Trim();
					seq = e.Item.Cells[0].Text.Trim();						
					curef = this.LBL_CUREF.Text.Trim();
					clseq = this.LBL_CL_SEQ.Text.Trim();
					prodid = this.LBL_PRODUCTID.Text.Trim();

					Response.Write("<script language='javascript'>window.open('../CoverNote/AsuransiJaminan.aspx?regno=" +
						regno + "&seq=" + seq + "&cu_ref=" + curef + "&cl_seq=" + clseq + //"&productid=" + prodid +
						"','PengikatanAgunan','status=no,scrollbars=yes,width=800,height=600');</script>");
					
					/*
					regno = LBL_REGNO.Text.Trim();
					curef = LBL_CUREF.Text.Trim();
					prodid = LBL_PRODUCTID.Text.Trim();
					clseq = LBL_CL_SEQ.Text.Trim();
					seq = e.Item.Cells[0].Text.Trim();
					Response.Write("<script language='javascript'>window.open('../CoverNote/AsuransiJaminan.aspx?ap_regno=" +
						regno + "&seq=" +  seq + "&cu_ref=" + curef + "&productid=" + prodid + "&cl_seq=" + clseq + "');</script>");
					*/
					break;

				case "delete":
					regno = LBL_REGNO.Text.Trim();
					seq = e.Item.Cells[0].Text.Trim();
					//delete data
					conn.QueryString = "delete from APPCOLASURANCE where AP_REGNO = '" +
						regno + "' AND SEQ = " + seq;
					conn.ExecuteNonQuery();
					bindData();
					break;

				case "edit":
					LBL_H_SEQ.Text = e.Item.Cells[0].Text.Trim();
					try
					{
						DDL_INSURANCECOMPANYTYPE.SelectedValue = e.Item.Cells[15].Text.Trim();
						fillInsrComp();
					} 
					catch {}
					try
					{
						DDL_CI_TYPE.SelectedValue = e.Item.Cells[13].Text.Trim();
						fillInsrComp();
					} 
					catch {}
					try
					{
						DDL_CI_COMP.SelectedValue = e.Item.Cells[12].Text.Trim();
					} 
					catch {}
					try
					{
						DDL_ICRATE.SelectedValue = e.Item.Cells[14].Text.Trim();
					} 
					catch {}
					TXT_CI_AMNT.Text = tool.MoneyFormat(e.Item.Cells[6].Text.Trim());
					TXT_CI_INSRPCT.Text = e.Item.Cells[9].Text.Trim();
					TXT_CI_CLASS.Text = e.Item.Cells[10].Text.Trim();
					TXT_CI_PREMI.Text = tool.MoneyFormat(e.Item.Cells[11].Text.Trim());
					TXT_CP_POLICYNO.Text = e.Item.Cells[4].Text.Trim();
					try
					{
						DDL_CP_CUR.SelectedValue = e.Item.Cells[16].Text.Trim();
					} 
					catch {}
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
					
					string LeadDesc = e.Item.Cells[17].Text.Trim();
					if(LeadDesc.Trim() == "&nbsp;")
						RDO_LEAD.SelectedValue = "0";
					else
						RDO_LEAD.SelectedValue = "1";

					try
					{
						DDL_CI_BROKER.SelectedValue = e.Item.Cells[18].Text.Trim();
					} 
					catch {}
					TXT_CI_AMNT_BANG.Text = tool.MoneyFormat(e.Item.Cells[19].Text.Trim());
					TXT_CI_AMNT_MESIN.Text = tool.MoneyFormat(e.Item.Cells[20].Text.Trim());
					TXT_CI_AMNT_LAIN.Text = tool.MoneyFormat(e.Item.Cells[21].Text.Trim());
					TXT_CI_PREMI_DIBAYAR.Text = tool.MoneyFormat(e.Item.Cells[22].Text.Trim());
					try
					{
						TXT_PREMIDATE_DAY.Text = tool.FormatDate_Day(e.Item.Cells[23].Text.Trim());
						DDL_PREMIDATE_MONTH.SelectedValue = tool.FormatDate_Month(e.Item.Cells[23].Text.Trim());
						TXT_PREMIDATE_YEAR.Text = tool.FormatDate_Year(e.Item.Cells[23].Text.Trim());
					} 
					catch {}
					TXT_CI_ORDERNO.Text = e.Item.Cells[24].Text.Trim();
					try
					{
						TXT_ORDERDATE_DAY.Text = tool.FormatDate_Day(e.Item.Cells[25].Text.Trim());
						DDL_ORDERDATE_MONTH.SelectedValue = tool.FormatDate_Month(e.Item.Cells[25].Text.Trim());
						TXT_ORDERDATE_YEAR.Text = tool.FormatDate_Year(e.Item.Cells[25].Text.Trim());
					} 
					catch {}
					TXT_CI_COVERNO.Text = e.Item.Cells[26].Text.Trim();
					try
					{
						TXT_COVERDATE_DAY.Text = tool.FormatDate_Day(e.Item.Cells[27].Text.Trim());
						DDL_COVERDATE_MONTH.SelectedValue = tool.FormatDate_Month(e.Item.Cells[27].Text.Trim());
						TXT_COVERDATE_YEAR.Text = tool.FormatDate_Year(e.Item.Cells[27].Text.Trim());
					} 
					catch {}
					try
					{
						TXT_COVERDUEDATE_DAY.Text = tool.FormatDate_Day(e.Item.Cells[28].Text.Trim());
						DDL_COVERDUEDATE_MONTH.SelectedValue = tool.FormatDate_Month(e.Item.Cells[28].Text.Trim());
						TXT_COVERDUEDATE_YEAR.Text = tool.FormatDate_Year(e.Item.Cells[28].Text.Trim());
					} 
					catch {}
					try
					{
						TXT_POLICYDATE_DAY.Text = tool.FormatDate_Day(e.Item.Cells[29].Text.Trim());
						DDL_POLICYDATE_MONTH.SelectedValue = tool.FormatDate_Month(e.Item.Cells[29].Text.Trim());
						TXT_POLICYDATE_YEAR.Text = tool.FormatDate_Year(e.Item.Cells[29].Text.Trim());
					} 
					catch {}

					BTN_TAMBAH.Text = "Save";
					BTN_CANCEL.Visible = true;
					break;

				default:
					// Do nothing.
					break;
			}
		}

		protected void DDL_CI_TYPE_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			fillInsrComp();
		}

		protected void BTN_SAVE_Click(object sender, System.EventArgs e)
		{
			string cm = RBL_LEGALSTA.SelectedValue.Trim(),
				ikat = DDL_CL_IKATTYPE.SelectedValue.Trim();
			conn.QueryString = "exec LGL_SCOL '"+ LBL_REGNO.Text +"', null, "+
				LBL_CL_SEQ.Text + ", '" + ikat + "', '" + cm + "'";
			conn.ExecuteNonQuery();
			ViewData();
		}

		protected void BTN_CANCEL_Click(object sender, System.EventArgs e)
		{
			clearEditBoxes();
		}

		private bool isNotaryDefined(string regno) 
		{
			bool isDef = false;

			conn.QueryString = "select NTID from NOTARYASSIGN where AP_REGNO = '"+regno+"'";
			conn.ExecuteQuery();

			if (conn.GetFieldValue("NTID") != "" && conn.GetFieldValue("NTID") != null) isDef = true;

			return isDef;
		}

		protected void BTN_PRINT_Click(object sender, System.EventArgs e)
		{
			string regno = this.LBL_REGNO.Text.Trim();
			string cu_ref = this.LBL_CUREF.Text.Trim();
			
			//--- sebelum print, periksa dulu apakah NAMA NOTARY sudah diisi
			if (isNotaryDefined(regno) == true)
				Response.Write("<script language='javascript'>window.open('../CoverNote/PengikatanAgunan.aspx?regno=" +
					regno + "&cu_ref=" + cu_ref + "&cl_seq=" + LBL_CL_SEQ.Text + "','PengikatanAgunan','status=no,scrollbars=yes,width=800,height=600');</script>");
			else
				Tools.popMessage(this, "Notary harus ditentukan dulu !");

			/*
			string regno = LBL_REGNO.Text.Trim(), curef = LBL_CUREF.Text.Trim(),
				prodid = LBL_PRODUCTID.Text.Trim(), clseq = LBL_CL_SEQ.Text.Trim();
			Response.Write("<script language='javascript'>window.open('../CoverNote/PengikatanAgunan.aspx?ap_regno=" +
				regno + "&cu_ref=" + curef + "&productid=" + prodid + "&cl_seq=" + clseq + "');</script>");
			*/
		}
	}
}
