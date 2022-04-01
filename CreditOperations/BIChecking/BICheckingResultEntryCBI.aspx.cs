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

namespace SME.CreditOperations.BIChecking
{
	/// <summary>
	/// Summary description for BICheckingEntry.
	/// </summary>
	public partial class BICheckingResultEntryCBI : System.Web.UI.Page
	{
		//protected Connection conn = new Connection("Data Source=10.123.12.30;Initial Catalog=SMEDEV;uid=sa;pwd=");
		protected Connection conn;
		protected Tools tool = new Tools();
		
		protected void Page_Load(object sender, System.EventArgs e)
		{
			conn = (Connection) Session["Connection"];

			if (!IsPostBack)
			{
				loadData();
				ViewData();
				InitName();
				bindData();
				bindData2();

			}
			SecureData();
			ViewMenu();
			DataGrid1.PageIndexChanged += new DataGridPageChangedEventHandler(this.Grid1_Change);
			Datagrid2.PageIndexChanged += new DataGridPageChangedEventHandler(this.Grid2_Change);
			BTN_UPDATESTATUS.Attributes.Add("onclick","if(!update()){return false;};");
			BTN_UPDATE_BI.Attributes.Add("onclick", "if(!cek_mandatory3(document.Form1)){return false;};");
		}

		private void SecureData() 
		{
			string bi = Request.QueryString["bi"];
			if (bi == "0")
			{
				this.BTN_UPDATE_BI.Visible = false;
				this.RDO_AP_BLBIMGMT.Enabled = false;
				this.RDO_AP_BLBIPEMILIK.Enabled = false;
				this.RDO_AP_BLBIPERNAH.Enabled = false;
				this.RDO_AP_BLBIUSAHA.Enabled = false;

				this.DDL_ACCBK.Enabled = false;
				this.DDL_OCBK.Enabled = false;
				this.DDL_MCBKS.Enabled = false;
				this.DDL_ACCBK12BLN.Enabled = false;
				this.DDL_OCBK12BLN.Enabled = false;
				this.DDL_MCBKS12BLN.Enabled = false;

				DataGrid1.Columns[21].Visible = false;
				for(int i=0; i<DataGrid1.Items.Count; i++) 
				{
					DataGrid1.Items[i].Cells[21].Visible = false;
				}
				
				Datagrid2.Columns[16].Visible = false;
				for(int i=0; i<Datagrid2.Items.Count; i++) 
				{
					Datagrid2.Items[i].Cells[16].Visible = false;
					/*
					LinkButton LNK_EDIT = (LinkButton) Datagrid2.Items[i].Cells[16].FindControl("LNK_EDIT");
					LinkButton LNK_DELETE = (LinkButton) Datagrid2.Items[i].Cells[16].FindControl("LNK_DELETE");

					LNK_EDIT.Enabled = false;
					LNK_DELETE.Enabled = false;
					*/
				}

				/*
				System.Web.UI.ControlCollection coll = this.Page.Controls;
				for (int i = 0; i < coll[1].Controls.Count; i++) 
				{
					if (coll[1].Controls[i] is DataGrid) 
					{						
						DataGrid dg = (DataGrid) coll[1].Controls[i];
						try 
						{
							dg.Columns[21].Visible = false;
						} 
						catch {
							dg.Columns[16].Visible = false;
						}
						for (int j = 0; j < dg.Items.Count; j++) 
						{				
							try 
							{
								dg.Items[j].Cells[21].Visible = false;
							} 
							catch 
							{
								dg.Items[j].Cells[16].Visible = false;
							}
						}
					}
				}
				*/
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

						if (conn.GetFieldValue(i,3).IndexOf("?bi=") < 0 && conn.GetFieldValue(i,3).IndexOf("&bi=") < 0)
							strtemp = strtemp + "&bi=" + Request.QueryString["bi"];
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

		private void ViewData()
		{
			string var_Nota = string.Empty;
			string bi = Request.QueryString["bi"];

			if (bi == "0")	var_Nota = "Select collectid, collectdesc  from RFCOLLECTABILITY ";
			else var_Nota = "Select collectid, collectdesc  from RFCOLLECTABILITY where active=1";

			GlobalTools.fillRefList(DDL_ACCBK, var_Nota , false, conn);
			GlobalTools.fillRefList(DDL_OCBK, var_Nota , false, conn);
			GlobalTools.fillRefList(DDL_MCBKS, var_Nota , false, conn);
			GlobalTools.fillRefList(DDL_ACCBK12BLN, var_Nota , false, conn);
			GlobalTools.fillRefList(DDL_OCBK12BLN, var_Nota , false, conn);
			GlobalTools.fillRefList(DDL_MCBKS12BLN, var_Nota , false, conn);

			conn.QueryString = "select VW_INFOUMUM.*, bi.BS_BIDATAAVAIL "+
				"from VW_INFOUMUM left join bi_status bi on VW_INFOUMUM.ap_regno = bi.ap_regno "+
				"where VW_INFOUMUM.AP_REGNO = '"+ Request.QueryString["regno"].Trim() +"' ";
			conn.ExecuteQuery();
			TXT_AP_REGNO.Text = conn.GetFieldValue("AP_REGNO");
			TXT_CU_REF.Text = conn.GetFieldValue("CU_REF");
			string AP_SIGNDATE = conn.GetFieldValue("AP_SIGNDATE");
			TXT_AP_SIGNDATE.Text = tool.FormatDate(AP_SIGNDATE);
			TXT_PROGRAMDESC.Text = conn.GetFieldValue("PROGRAMDESC");
			TXT_BRANCH_NAME.Text = conn.GetFieldValue("BRANCH_NAME");
			TXT_AP_TMLDRNM.Text = conn.GetFieldValue("AP_TMLDRNM");
			TXT_AP_RMNM.Text = conn.GetFieldValue("AP_RMNM");
			TXT_BU_DESC.Text = conn.GetFieldValue("BU_DESC");
			TXT_CU_NAME.Text = conn.GetFieldValue("CU_NAME");
			TXT_CU_ADDR1.Text = conn.GetFieldValue("CU_ADDR1");
			TXT_CU_ADDR2.Text = conn.GetFieldValue("CU_ADDR2");
			TXT_CU_ADDR3.Text = conn.GetFieldValue("CU_ADDR3");
			TXT_CU_CITYNM.Text = conn.GetFieldValue("CU_CITYNM");
			TXT_CU_PHN.Text = conn.GetFieldValue("CU_PHN");
			TXT_BUSSTYPEDESC.Text = conn.GetFieldValue("BUSSTYPEDESC");
			if (conn.GetFieldValue("BS_BIDATAAVAIL") == "1")
				CHK_BS_BIDATAAVAIL.Checked = true;
			else
				//biar bisa ngesave
				//CHK_BS_BIDATAAVAIL.Checked = false;
				CHK_BS_BIDATAAVAIL.Checked = true;

			try {DDL_ACCBK.SelectedValue = conn.GetFieldValue("AP_BLBIACCBK");} 
			catch {DDL_ACCBK.SelectedValue = "";}

			try {DDL_OCBK.SelectedValue = conn.GetFieldValue("AP_BLBIOCBK");} 
			catch {DDL_OCBK.SelectedValue = "";}

			try {DDL_MCBKS.SelectedValue = conn.GetFieldValue("AP_BLBIMCBKS");} 
			catch {DDL_MCBKS.SelectedValue = "";}

			try {RDO_AP_BLBIMGMT.SelectedValue = conn.GetFieldValue("AP_BLBIMGMT");} 
			catch {RDO_AP_BLBIMGMT.SelectedValue = "0";}

			try {RDO_AP_BLBIUSAHA.SelectedValue = conn.GetFieldValue("AP_BLBIUSAHA");} 
			catch {RDO_AP_BLBIUSAHA.SelectedValue = "0";}

			try {RDO_AP_BLBIPEMILIK.SelectedValue = conn.GetFieldValue("AP_BLBIPEMILIK");} 
			catch {RDO_AP_BLBIPEMILIK.SelectedValue = "0";}

			try {RDO_AP_BLBIPERNAH.SelectedValue = conn.GetFieldValue("AP_BLBIPERNAH");} 
			catch {RDO_AP_BLBIPERNAH.SelectedValue = "0";}

			try {DDL_ACCBK12BLN.SelectedValue = conn.GetFieldValue("AP_BLBIACCBK12BLN");} 
			catch {DDL_ACCBK12BLN.SelectedValue = "";}

			try {DDL_OCBK12BLN.SelectedValue = conn.GetFieldValue("AP_BLBIOCBK12BLN");} 
			catch {DDL_OCBK12BLN.SelectedValue = "";}

			try {DDL_MCBKS12BLN.SelectedValue = conn.GetFieldValue("AP_BLBIMCBKS12BLN");} 
			catch {DDL_MCBKS12BLN.SelectedValue = "";}
		}

		private void InitName()
		{
			//init NAMA

			DDL_NAMA.Items.Clear();
			DDL_NAMA2.Items.Clear();
			DDL_H_ALAMAT.Items.Clear();
			DDL_H_ALAMAT2.Items.Clear();

			DDL_NAMA.Items.Add(new ListItem("- PILIH -", ""));
			DDL_NAMA2.Items.Add(new ListItem("- PILIH -", ""));
			DDL_H_ALAMAT.Items.Add(new ListItem("- PILIH -", ""));
			DDL_H_ALAMAT2.Items.Add(new ListItem("- PILIH -", ""));

			conn.QueryString = "SELECT DISTINCT isnull(CS_SEQ,0), NAME, ALAMAT "+
				"FROM VW_CREOPR_BICHECK_RESULTENTRY "+
				"WHERE CU_REF = '" + TXT_CU_REF.Text.Trim() + "' "; 
			conn.ExecuteQuery();
			for (int i = 0; i < conn.GetRowCount(); i++)
			{
				String s0 = conn.GetFieldValue(i,0),
					s1 = conn.GetFieldValue(i,1),
					s2 = conn.GetFieldValue(i,2);
				ListItem li = new ListItem(s1,s0),
					li2 = new ListItem(s2,s0);
				DDL_NAMA.Items.Add(li);
				DDL_NAMA2.Items.Add(li);
				DDL_H_ALAMAT.Items.Add(li2);
				DDL_H_ALAMAT2.Items.Add(li2);
			}

		}

		private void loadData()
		{
			string bi = Request.QueryString["bi"];

			/*TXT_BS_RECVDATE.Text = tool.FormatDate(DateTime.Now.ToLongDateString(), false);

			conn.QueryString = "SELECT a.AP_REGNO , co.CU_REF , co.CU_COMPNAME , bi.BS_REQDATE, "+
				"bi.BS_RECVDATE, bi.BS_BIDATAAVAIL "+
				"FROM application a inner join bi_status bi on a.ap_regno = bi.ap_regno "+
				"inner join cust_company co on bi.cu_ref = co.cu_ref "+
				"WHERE a.AP_REGNO = '" + Request.QueryString["regno"] + "'";
			conn.ExecuteQuery();
			TXT_AP_REGNO.Text = conn.GetFieldValue("AP_REGNO");
			TXT_CU_REF.Text = conn.GetFieldValue("CU_REF");
			TXT_CU_COMPNAME.Text = conn.GetFieldValue("CU_COMPNAME");
			TXT_BS_REQDATE.Text = conn.GetFieldValue("BS_REQDATE");
			TXT_BS_RECVDATE.Text = conn.GetFieldValue("BS_RECVDATE");
			if (conn.GetFieldValue("BS_BIDATAAVAIL") == "1")
				CHK_BS_BIDATAAVAIL.Checked = true;
			else
				CHK_BS_BIDATAAVAIL.Checked = false;
			*/


			//init BANKID
			//--- Bank
			if (bi == "0") conn.QueryString = "SELECT BANKID, BANKID+' - '+BANKNAME as BANKNAME FROM RFBANK order by BANKID";
			else conn.QueryString = "SELECT BANKID, BANKID+' - '+BANKNAME as BANKNAME FROM RFBANK where active='1' order by BANKID";

			conn.ExecuteQuery();
			DDL_BANKID.Items.Clear();
			DDL_BANKID.Items.Add(new ListItem("- PILIH -", ""));
			for (int i = 0; i < conn.GetRowCount(); i++)
			{
				String s0 = conn.GetFieldValue(i,0),
					s1 = conn.GetFieldValue(i,1);
				ListItem li = new ListItem(s1,s0);
				DDL_BANKID.Items.Add(li);
			}

			//init CUR_ID
			//--- Mata Uang
			if (bi == "0")	conn.QueryString = "select CURRENCYID, CURRENCYID + ' - ' + CURRENCYDESC as CURRENCYDESC from RFCURRENCY order by CURRENCYID";
			else conn.QueryString = "select CURRENCYID, CURRENCYID + ' - ' + CURRENCYDESC as CURRENCYDESC from RFCURRENCY where ACTIVE = '1' order by CURRENCYID";

			conn.ExecuteQuery();
			DDL_CUR_ID.Items.Clear();
			DDL_CUR_ID2.Items.Clear();
			DDL_CUR_ID.Items.Add(new ListItem("- PILIH -", ""));
			DDL_CUR_ID2.Items.Add(new ListItem("- PILIH -", ""));
			for (int i = 0; i < conn.GetRowCount(); i++)
			{
				String s0 = conn.GetFieldValue(i,0),
					s1 = conn.GetFieldValue(i,1);
				ListItem li = new ListItem(s1,s0);
				DDL_CUR_ID.Items.Add(li);
				DDL_CUR_ID2.Items.Add(li);
			}

			//init COLLECTID
			if (bi == "0")	conn.QueryString = "SELECT COLLECTID, COLLECTDESC FROM RFCOLLECTABILITY ";
			else conn.QueryString = "SELECT COLLECTID, COLLECTDESC FROM RFCOLLECTABILITY WHERE ACTIVE = '1' ";

			conn.ExecuteQuery();
			DDL_COLLECTID.Items.Clear();
			DDL_COLLECTID.Items.Add(new ListItem("- PILIH -", ""));
			for (int i = 0; i < conn.GetRowCount(); i++)
			{
				String s0 = conn.GetFieldValue(i,0),
					s1 = conn.GetFieldValue(i,1);
				ListItem li = new ListItem(s1,s0);
				DDL_COLLECTID.Items.Add(li);
			}

			//init month
			DDL_BRP_TANGGALPK_MONTH.Items.Add(new ListItem("- PILIH -", ""));
			DDL_BRC_TANGGALBUKTI_MONTH.Items.Add(new ListItem("- PILIH -", ""));
			DDL_BRC_TANGGALPENILAIAN_MONTH.Items.Add(new ListItem("- PILIH -", ""));
			for (int i = 1; i <= 12; i++)
			{
				DDL_BRP_TANGGALPK_MONTH.Items.Add(new ListItem(DateAndTime.MonthName(i, false), i.ToString()));
				DDL_BRC_TANGGALBUKTI_MONTH.Items.Add(new ListItem(DateAndTime.MonthName(i, false), i.ToString()));
				DDL_BRC_TANGGALPENILAIAN_MONTH.Items.Add(new ListItem(DateAndTime.MonthName(i, false), i.ToString()));
			}
		}

		private void bindData()
		{
			DataTable dt = new DataTable();
			conn.QueryString = "SELECT * FROM VW_CREOPR_BICHECK_RESULTENTRY_PROD WHERE AP_REGNO = '" +
				Request.QueryString["regno"] + "' ORDER BY AP_REGNO, CU_REF, CS_SEQ, BR_SEQ ";
			conn.ExecuteQuery();
			dt = conn.GetDataTable().Copy();
			DataGrid1.DataSource = dt;
			try 
			{
				DataGrid1.DataBind();
			} 
			catch 
			{
				DataGrid1.CurrentPageIndex = 0;
				DataGrid1.DataBind();
			}
			for (int j = 0; j < DataGrid1.Items.Count; j++)
			{
				DataGrid1.Items[j].Cells[9].Text = tool.MoneyFormat(DataGrid1.Items[j].Cells[9].Text );
				DataGrid1.Items[j].Cells[10].Text = tool.MoneyFormat(DataGrid1.Items[j].Cells[10].Text );
				DataGrid1.Items[j].Cells[11].Text = tool.MoneyFormat(DataGrid1.Items[j].Cells[11].Text );
			}
		}

		private void bindData2()
		{
			DataTable dt = new DataTable();
			conn.QueryString = "SELECT * FROM VW_CREOPR_BICHECK_RESULTENTRY_COL WHERE AP_REGNO = '" +
				TXT_AP_REGNO.Text.Trim() + "' ORDER BY AP_REGNO, CU_REF, CS_SEQ, BR_SEQ ";
			conn.ExecuteQuery();
			dt = conn.GetDataTable().Copy();
			Datagrid2.DataSource = dt;
			try 
			{
				Datagrid2.DataBind();
			} 
			catch 
			{
				Datagrid2.CurrentPageIndex = 0;
				Datagrid2.DataBind();
			}
			for (int j = 0; j < Datagrid2.Items.Count; j++)
			{
				Datagrid2.Items[j].Cells[12].Text = tool.MoneyFormat(Datagrid2.Items[j].Cells[12].Text );
			}
		}

		private void clearEditBoxes()
		{
			try
			{
				DDL_NAMA.SelectedIndex = 0;
				DDL_H_ALAMAT.SelectedIndex = 0;
				DDL_BANKID.SelectedIndex = 0;
				DDL_COLLECTID.SelectedIndex = 0;
				DDL_CUR_ID.SelectedIndex = 0;
				DDL_BRP_TANGGALPK_MONTH.SelectedIndex = 0;
			}
			catch {}
			TXT_ALAMAT.Text = "";
			TXT_BRP_CREDTYPE.Text = "";
			TXT_BRP_REKENING.Text = "";
			TXT_BRP_LIMIT.Text = "";
			TXT_BRP_BAKIDEBET.Text = "";
			TXT_BRP_TUNGGAKAN.Text = "";
			TXT_BRP_SIFATKREDIT.Text = "";
			TXT_BRP_JENISGUNA.Text = "";
			TXT_BRP_JANGKAWAKTU.Text = "";
			TXT_BRP_JAMINAN.Text = "";
			TXT_BRP_TANGGALPK_DAY.Text = "";
			TXT_BRP_TANGGALPK_YEAR.Text = "";
			LBL_H_SHSEQ.Text = "";
			LBL_H_ACCSEQ.Text = "";
			activatePostBackControls(true);
		}

		private void clearEditBoxes2()
		{
			try
			{
				DDL_NAMA2.SelectedIndex = 0;
				DDL_H_ALAMAT2.SelectedIndex = 0;
				DDL_CUR_ID2.SelectedIndex = 0;
				DDL_BRC_TANGGALBUKTI_MONTH.SelectedIndex = 0;
				DDL_BRC_TANGGALPENILAIAN_MONTH.SelectedIndex = 0;
			}
			catch {}
			TXT_ALAMAT2.Text = "";
			TXT_BRC_JENISAGUNAN.Text = "";
			TXT_BRC_UKURAN.Text = "";
			TXT_BRC_LOKASI.Text = "";
			TXT_BRC_BUKTIPEMILIKAN.Text = "";
			TXT_BRC_PENGIKATAN.Text = "";
			TXT_BRC_NILAITAKSASI.Text = "";
			TXT_BRC_REF.Text = "";
			TXT_BRC_TANGGALBUKTI_DAY.Text = "";
			TXT_BRC_TANGGALBUKTI_YEAR.Text = "";
			TXT_BRC_TANGGALPENILAIAN_DAY.Text = "";
			TXT_BRC_TANGGALPENILAIAN_YEAR.Text = "";
			LBL_H_SHSEQ2.Text = "";
			LBL_H_ACCSEQ2.Text = "";
			activatePostBackControls2(true);
		}

		private void activatePostBackControls(bool mode)
		{
			DDL_NAMA.Enabled = mode;
		}

		private void activatePostBackControls2(bool mode)
		{
			DDL_NAMA2.Enabled = mode;
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
			this.Datagrid2.ItemCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.Datagrid2_ItemCommand);

		}
		#endregion

		void Grid1_Change(Object sender, DataGridPageChangedEventArgs e) 
		{
			// Set CurrentPageIndex to the page the user clicked.
			DataGrid1.CurrentPageIndex = e.NewPageIndex;
			// Re-bind the data to refresh the DataGrid control. 
			bindData();	
		}

		void Grid2_Change(Object sender, DataGridPageChangedEventArgs e) 
		{
			// Set CurrentPageIndex to the page the user clicked.
			Datagrid2.CurrentPageIndex = e.NewPageIndex;
			// Re-bind the data to refresh the DataGrid control. 
			bindData2();	
		}

		private void DataGrid1_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			clearEditBoxes();
			switch(((LinkButton)e.CommandSource).CommandName)
			{
				case "edit":
					//if (e.Item.Cells[1].Text.Trim() == "&nbsp;") 
					//return;
					LBL_H_SHSEQ.Text = e.Item.Cells[1].Text.Trim();
					LBL_H_ACCSEQ.Text = e.Item.Cells[2].Text.Trim();
					cleansLabel(LBL_H_SHSEQ);
					cleansLabel(LBL_H_ACCSEQ);
					if (LBL_H_SHSEQ.Text != "") 
					{
						try	{DDL_NAMA.SelectedValue = LBL_H_SHSEQ.Text.Trim();}
						catch{}

						try{DDL_H_ALAMAT.SelectedIndex = DDL_NAMA.SelectedIndex;} 
						catch {}
					}
					else
					{
						DDL_NAMA.SelectedIndex = 1;		//index 0 -> ListItem("- PILIH -", "")
						DDL_H_ALAMAT.SelectedIndex = 1;	//index 1 -> 
					}

					TXT_ALAMAT.Text = DDL_H_ALAMAT.SelectedItem.Text.Trim();
					try
					{
						DDL_BANKID.SelectedValue = e.Item.Cells[18].Text.Trim();
					} 
					catch {}

					TXT_BRP_CREDTYPE.Text = e.Item.Cells[6].Text.Trim();
					TXT_BRP_REKENING.Text = e.Item.Cells[7].Text.Trim();
					try
					{
						DDL_CUR_ID.SelectedValue = e.Item.Cells[20].Text.Trim();
					} 
					catch {}
					TXT_BRP_LIMIT.Text = e.Item.Cells[9].Text.Trim();
					TXT_BRP_BAKIDEBET.Text = e.Item.Cells[10].Text.Trim();
					TXT_BRP_TUNGGAKAN.Text = e.Item.Cells[11].Text.Trim();
					TXT_BRP_SIFATKREDIT.Text = e.Item.Cells[12].Text.Trim();
					TXT_BRP_JENISGUNA.Text = e.Item.Cells[13].Text.Trim();
					
					TXT_BRP_TANGGALPK_DAY.Text = tool.FormatDate_Day(e.Item.Cells[14].Text.Trim());
					try	{	DDL_BRP_TANGGALPK_MONTH.SelectedValue = tool.FormatDate_Month(e.Item.Cells[14].Text.Trim());}
					catch{}
					TXT_BRP_TANGGALPK_YEAR.Text = tool.FormatDate_Year(e.Item.Cells[14].Text.Trim());
					
					TXT_BRP_JANGKAWAKTU.Text = e.Item.Cells[15].Text.Trim();
					try
					{
						DDL_COLLECTID.SelectedValue = e.Item.Cells[19].Text.Trim();
					} 
					catch {}
					TXT_BRP_JAMINAN.Text = e.Item.Cells[17].Text.Trim();
					//cleans '&nbsp;'
					cleansTextBox(TXT_ALAMAT);
					cleansTextBox(TXT_BRP_CREDTYPE);
					cleansTextBox(TXT_BRP_REKENING);
					cleansTextBox(TXT_BRP_LIMIT);
					cleansTextBox(TXT_BRP_BAKIDEBET);
					cleansTextBox(TXT_BRP_TUNGGAKAN);
					cleansTextBox(TXT_BRP_SIFATKREDIT);
					cleansTextBox(TXT_BRP_JENISGUNA);
					cleansTextBox(TXT_BRP_TANGGALPK_DAY);
					cleansTextBox(TXT_BRP_TANGGALPK_YEAR);
					cleansTextBox(TXT_BRP_JANGKAWAKTU);
					cleansTextBox(TXT_BRP_JAMINAN);
					activatePostBackControls(false);
					break;
				case "delete":
					//if (e.Item.Cells[1].Text.Trim() == "&nbsp;") 
					//return;
					string regno = TXT_AP_REGNO.Text.Trim(),
						curef = e.Item.Cells[0].Text.Trim(),
						brseq = e.Item.Cells[2].Text.Trim();
					conn.QueryString = "delete biresultprod where "+
						"ap_regno = '" + regno + "' and seq = " + brseq + " ";
					try
					{
						conn.ExecuteNonQuery();
					} 
					catch {}
					bindData();
					break;
				default:
					// Do nothing.
					break;
			}
		}

		private void Datagrid2_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			clearEditBoxes2();
			switch(((LinkButton)e.CommandSource).CommandName)
			{
				case "edit":
					//if (e.Item.Cells[1].Text.Trim() == "&nbsp;") 
					//return;
					LBL_H_SHSEQ2.Text = e.Item.Cells[1].Text.Trim();
					LBL_H_ACCSEQ2.Text = e.Item.Cells[2].Text.Trim();
					cleansLabel(LBL_H_SHSEQ2);
					cleansLabel(LBL_H_ACCSEQ2);
					if (LBL_H_SHSEQ2.Text != "") 
					{
						try	{DDL_NAMA2.SelectedValue = LBL_H_SHSEQ2.Text.Trim();}
						catch{}
						try {DDL_H_ALAMAT2.SelectedIndex = DDL_NAMA2.SelectedIndex;}
						catch {}
					}
					else
					{
						DDL_NAMA2.SelectedIndex = 1;		//index 0 -> ListItem("- PILIH -", "")
						DDL_H_ALAMAT2.SelectedIndex = 1;	//index 1 -> 
					}

					TXT_ALAMAT2.Text = DDL_H_ALAMAT2.SelectedItem.Text.Trim();
					TXT_BRC_JENISAGUNAN.Text = e.Item.Cells[5].Text.Trim();
					TXT_BRC_UKURAN.Text = e.Item.Cells[6].Text.Trim();
					TXT_BRC_LOKASI.Text = e.Item.Cells[7].Text.Trim();
					TXT_BRC_BUKTIPEMILIKAN.Text = e.Item.Cells[8].Text.Trim();
					
					TXT_BRC_TANGGALBUKTI_DAY.Text = tool.FormatDate_Day(e.Item.Cells[9].Text.Trim());
					try	{DDL_BRC_TANGGALBUKTI_MONTH.SelectedValue = tool.FormatDate_Month(e.Item.Cells[9].Text.Trim());}
					catch{}
					TXT_BRC_TANGGALBUKTI_YEAR.Text = tool.FormatDate_Year(e.Item.Cells[9].Text.Trim());
					
					TXT_BRC_PENGIKATAN.Text = e.Item.Cells[10].Text.Trim();
					try
					{
						DDL_CUR_ID2.SelectedValue = e.Item.Cells[15].Text.Trim();
					} 
					catch {}
					TXT_BRC_NILAITAKSASI.Text = e.Item.Cells[12].Text.Trim();
					
					TXT_BRC_TANGGALPENILAIAN_DAY.Text = tool.FormatDate_Day(e.Item.Cells[13].Text.Trim());
					try	{ DDL_BRC_TANGGALPENILAIAN_MONTH.SelectedValue = tool.FormatDate_Month(e.Item.Cells[13].Text.Trim());}
					catch{}
					TXT_BRC_TANGGALPENILAIAN_YEAR.Text = tool.FormatDate_Year(e.Item.Cells[13].Text.Trim());
					
					TXT_BRC_REF.Text = e.Item.Cells[14].Text.Trim();
					//cleans '&nbsp;'
					cleansTextBox(TXT_ALAMAT2);
					cleansTextBox(TXT_BRC_JENISAGUNAN);
					cleansTextBox(TXT_BRC_UKURAN);
					cleansTextBox(TXT_BRC_LOKASI);
					cleansTextBox(TXT_BRC_BUKTIPEMILIKAN);
					cleansTextBox(TXT_BRC_PENGIKATAN);
					cleansTextBox(TXT_BRC_NILAITAKSASI);
					cleansTextBox(TXT_BRC_REF);
					cleansTextBox(TXT_BRC_TANGGALBUKTI_DAY);
					cleansTextBox(TXT_BRC_TANGGALBUKTI_YEAR);
					cleansTextBox(TXT_BRC_TANGGALPENILAIAN_DAY);
					cleansTextBox(TXT_BRC_TANGGALPENILAIAN_YEAR);
					activatePostBackControls2(false);
					break;
				case "delete":
					//if (e.Item.Cells[1].Text.Trim() == "&nbsp;") 
					//return;
					string regno = TXT_AP_REGNO.Text.Trim(),
						curef = e.Item.Cells[0].Text.Trim(),
						brseq = e.Item.Cells[2].Text.Trim();
					conn.QueryString = "delete biresultcol where "+
						"ap_regno = '" + regno + "' and seq = " + brseq + " ";
					try
					{
						conn.ExecuteNonQuery();
					} 
					catch {}
					bindData2();
					break;
				default:
					// Do nothing.
					break;
			}
		}

		protected void BTN_SAVE_Click(object sender, System.EventArgs e)
		{
			if (DDL_NAMA.SelectedIndex == 0) 
			{
				Tools.popMessage(this, "Nama harus dipilih!");
				return;
			}
			/*if (TXT_BRP_REKENING.Text.Trim() == "")
			{
				Tools.popMessage(this, "No Rekening harus diisi!");
				return;
			}*/
			if (DDL_BANKID.SelectedIndex == 0) 
			{
				Tools.popMessage(this, "Nama Bank harus dipilih!");
				return;
			}
			if (TXT_BRP_CREDTYPE.Text.Trim() == "") 
			{
				Tools.popMessage(this, "Jenis Credit harus diisi!");
				return;
			}
			if (DDL_CUR_ID.SelectedIndex == 0) 
			{
				Tools.popMessage(this, "Mata uang harus dipilih!");
				return;
			}
			if (TXT_BRP_LIMIT.Text.Trim() == "") 
			{
				Tools.popMessage(this, "Limit harus diisi!");
				return;
			}
			if (TXT_BRP_BAKIDEBET.Text.Trim() == "") 
			{
				Tools.popMessage(this, "Baki debet harus diisi!");
				return;
			}
			if (TXT_BRP_TUNGGAKAN.Text.Trim() == "") 
			{
				Tools.popMessage(this, "Tunggakan harus diisi!");
				return;
			}
			if ((TXT_BRP_TANGGALPK_DAY.Text.Trim() == "")||(TXT_BRP_TANGGALPK_YEAR.Text.Trim() == "")||
				(DDL_BRP_TANGGALPK_MONTH.SelectedIndex == 0))
			{
				Tools.popMessage(this, "Tanggal PK harus diisi!");
				return;
			}
			if (TXT_BRP_JANGKAWAKTU.Text.Trim() == "") 
			{
				Tools.popMessage(this, "Jangka waktu harus diisi!");
				return;
			}
			if (DDL_COLLECTID.SelectedIndex == 0) 
			{
				Tools.popMessage(this, "Kolek harus dipilih!");
				return;
			}

			string regno=Request.QueryString["regno"],
				curef=TXT_CU_REF.Text.Trim(),
				brseq=LBL_H_ACCSEQ.Text.Trim(),
				csseq=LBL_H_SHSEQ.Text.Trim(),

				pbank=DDL_BANKID.SelectedValue.Trim(),
				pjeniskredit=validateSQLString(TXT_BRP_CREDTYPE.Text.Trim()),
				prekening=validateSQLString(TXT_BRP_REKENING.Text.Trim()),
				pcur = DDL_CUR_ID.SelectedValue.Trim(),
				plimit= tool.ConvertFloat(TXT_BRP_LIMIT.Text.Trim()),
				pbakidebet=tool.ConvertFloat(TXT_BRP_BAKIDEBET.Text.Trim()),
				ptunggakan=tool.ConvertFloat(TXT_BRP_TUNGGAKAN.Text.Trim()),
				psifatkredit=validateSQLString(TXT_BRP_SIFATKREDIT.Text.Trim()),
				pjenisguna=validateSQLString(TXT_BRP_JENISGUNA.Text.Trim()),
				ptanggalpk="",
				pjkwaktu=validateSQLString(TXT_BRP_JANGKAWAKTU.Text.Trim()),
				pkolek=DDL_COLLECTID.SelectedValue.Trim(),
				pjaminan=validateSQLString(TXT_BRP_JAMINAN.Text.Trim()),

				bidataavail = "0";

			try
			{
				ptanggalpk=Tools.toSQLDate(TXT_BRP_TANGGALPK_DAY, DDL_BRP_TANGGALPK_MONTH, TXT_BRP_TANGGALPK_YEAR);
				DateTime tgPK = Convert.ToDateTime(ptanggalpk);
				DateTime tgNow = Convert.ToDateTime(DateTime.Now.ToShortDateString());
				if (tgPK > tgNow) 
				{
					Tools.popMessage(this, "Tanggal PK tidak boleh lebih besar dari tanggal hari ini.");
					return;
				}
			} 
			catch {}
			if ((brseq.Trim() == "")||(brseq.Trim() == "0")) brseq = "NULL";
			if ((csseq.Trim() == "")||(csseq.Trim() == "0")) csseq = "NULL";
			if (plimit.Trim() == "") plimit = "0";
			if (pbakidebet.Trim() == "") pbakidebet = "0";
			if (ptunggakan.Trim() == "") ptunggakan = "0";

			if (CHK_BS_BIDATAAVAIL.Checked)
				bidataavail = "1";

			conn.QueryString = "exec BC_BI_RESULT_SAVE_CBI '" + regno + "', '" + Request.QueryString["curef"] + "', " + 
				brseq + ", " + csseq + ", '" + pbank + "', '" + pjeniskredit + "', '" + prekening + "', '" +
				pcur + "', " + plimit + ", " + pbakidebet + ", " + ptunggakan + ", '" + 
				psifatkredit + "', '" + pjenisguna + "', '" + ptanggalpk + "', '" +
				pjkwaktu + "', '" + pkolek + "', '" + pjaminan + "', " + 
				"NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, '" + bidataavail + "' ";
			try
			{
				conn.ExecuteNonQuery();
				InitName();
			} 
			catch 
			{
				Tools.popMessage(this, "Data not valid! Please check your data (e.g. dates,...).");
				return;
			}

			clearEditBoxes();
			bindData();
		}

		protected void BTN_CANCEL_Click(object sender, System.EventArgs e)
		{
			clearEditBoxes();
		}

		protected void BTN_SAVE2_Click(object sender, System.EventArgs e)
		{
			if (DDL_NAMA2.SelectedIndex == 0) 
			{
				Tools.popMessage(this, "Nama harus dipilih!");
				return;
			}
			if (TXT_BRC_JENISAGUNAN.Text.Trim() == "")
			{
				Tools.popMessage(this, "Jenis Agunan harus diisi!");
				return;
			}


			string regno=TXT_AP_REGNO.Text.Trim(),
				curef=TXT_CU_REF.Text.Trim(),
				brseq=LBL_H_ACCSEQ2.Text.Trim(),
				csseq=LBL_H_SHSEQ2.Text.Trim(),

				cjenisagunan=validateSQLString(TXT_BRC_JENISAGUNAN.Text.Trim()),
				cukuran=validateSQLString(TXT_BRC_UKURAN.Text.Trim()),
				clokasi=validateSQLString(TXT_BRC_LOKASI.Text.Trim()),
				cnobukti=validateSQLString(TXT_BRC_BUKTIPEMILIKAN.Text.Trim()),
				ctglbukti="",
				cikat=validateSQLString(TXT_BRC_PENGIKATAN.Text.Trim()),
				ccur=DDL_CUR_ID2.SelectedValue.Trim(),
				ctaksasi=tool.ConvertFloat(TXT_BRC_NILAITAKSASI.Text.Trim()),
				ctglnilai="",
				cref=validateSQLString(TXT_BRC_REF.Text.Trim()),
				bidataavail = "0";

			try
			{
				ctglbukti=Tools.toSQLDate(TXT_BRC_TANGGALBUKTI_DAY, DDL_BRC_TANGGALBUKTI_MONTH, TXT_BRC_TANGGALBUKTI_YEAR);
			} 
			catch {}
			try
			{
				ctglnilai=Tools.toSQLDate(TXT_BRC_TANGGALPENILAIAN_DAY, DDL_BRC_TANGGALPENILAIAN_MONTH, TXT_BRC_TANGGALPENILAIAN_YEAR);
			} 
			catch {}
			if ((brseq.Trim() == "")||(brseq.Trim() == "0")) brseq = "NULL";
			if ((csseq.Trim() == "")||(csseq.Trim() == "0")) csseq = "NULL";
			if (ctaksasi.Trim() == "") ctaksasi = "0";
			if ((TXT_BRC_TANGGALBUKTI_DAY.Text.Trim() == "")||
				(DDL_BRC_TANGGALBUKTI_MONTH.SelectedValue.Trim() == "")||
				(TXT_BRC_TANGGALBUKTI_YEAR.Text.Trim() == ""))
				ctglbukti = "NULL";
			else
				ctglbukti = "'" + ctglbukti + "'";
			if ((TXT_BRC_TANGGALPENILAIAN_DAY.Text.Trim() == "")||
				(DDL_BRC_TANGGALPENILAIAN_MONTH.SelectedValue.Trim() == "")||
				(TXT_BRC_TANGGALPENILAIAN_YEAR.Text.Trim() == ""))
				ctglnilai = "NULL";
			else
				ctglnilai = "'" + ctglnilai + "'";

			if (CHK_BS_BIDATAAVAIL.Checked)
				bidataavail = "1";

			conn.QueryString = "exec BC_BI_RESULT_SAVE '" + regno + "', " + brseq + ", " +
				csseq + ", NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, " +
				"NULL, NULL, NULL, '" + 
				cjenisagunan + "', '" + cukuran + "', '" + clokasi + "', '" +
				cnobukti + "', " + ctglbukti + ", '" + cikat + "', '" + ccur + "', " + 
				ctaksasi + ", " + ctglnilai + ", '" + cref + "', '" + bidataavail + "' ";
			try
			{
				conn.ExecuteNonQuery();
			} 
			catch 
			{
				Tools.popMessage(this, "Data not valid! Please check your data (e.g. dates,...).");
				return;
			}


			clearEditBoxes2();
			bindData2();
		}

		protected void BTN_CANCEL2_Click(object sender, System.EventArgs e)
		{
			clearEditBoxes2();
		}

		protected void BTN_UPDATESTATUS_Click(object sender, System.EventArgs e)
		{
			////////////////////////////////////////////////////
			///	cek dulu kolektibilitas
			///	
			if (DDL_ACCBK.SelectedValue == "") 
			{
				GlobalTools.popMessage(this, "Kolektibilitas perusahaan saat ini di bank lain (IDI BI) tidak boleh kosong!");
				return;
			}
			if (DDL_OCBK.SelectedValue == "") 
			{
				GlobalTools.popMessage(this, "Kolektibilitas pemilik saat ini di bank lain (IDI BI) tidak boleh kosong!");
				return;
			}
			if (DDL_MCBKS.SelectedValue == "") 
			{
				GlobalTools.popMessage(this, "Kolektibilitas manajemen saat ini di bank lain (IDI BI) tidak boleh kosong!");
				return;
			}
			if (DDL_ACCBK12BLN.SelectedValue == "") 
			{
				GlobalTools.popMessage(this, "Kolektibilitas perusahaan 12 bulan terakhir di bank lain (IDI BI) tidak boleh kosong!");
				return;
			}
			if (DDL_OCBK12BLN.SelectedValue == "") 
			{
				GlobalTools.popMessage(this, "Kolektibilitas pemilik 12 bulan terakhir di bank lain (IDI BI) tidak boleh kosong!");
				return;
			}
			if (DDL_MCBKS12BLN.SelectedValue == "") 
			{
				GlobalTools.popMessage(this, "Kolektibilitas manajemen 12 bulan terakhir di bank lain (IDI BI) tidak boleh kosong!");
				return;
			}
			/*
			conn.QueryString = "select apptype, productid from cust_product where ap_regno='" + Request.QueryString["regno"] + "'";
			conn.ExecuteQuery();
			for (int i = 0; i < conn.GetRowCount(); i++)
			{
				conn.QueryString = "exec TRACKUPDATE '" + Request.QueryString["regno"] + "', '" + 
					conn.GetFieldValue(i,1) + "', '" + conn.GetFieldValue(i,0) + "', '" + Session["UserID"].ToString() + "'";
				conn.ExecuteNonQuery();
			}
			conn.QueryString = "update bi_status set bs_complete='2' where ap_regno='" + Request.QueryString["regno"] + "'";
			conn.ExecuteNonQuery();
			*/

			/***
			 * -- YUDI
			 * Keterangan :
			 * BI_STATUS (BS_COMPLETE)
			 * => 0 : Belum lengkap
			 * => 1 : Sudah request, menuju result
			 * => 2 : SUDAH LENGKAP !
			 * => 3 : Sudah Result, menunggu validasi
			 * ***/	

			conn.QueryString = "update BI_STATUS set BS_COOFFICER='" + Session["UserID"].ToString() +
				"', BS_COMPLETE='3', BS_RECVDATE=getdate() where AP_REGNO='" + Request.QueryString["regno"] + "'";
			/***
			conn.QueryString = "update bi_status set bs_coofficer='" + Session["UserID"].ToString() +
				"', BS_COMPLETE='2', bs_recvdate=getdate() where ap_regno='" + Request.QueryString["regno"] + "'";
			***/
			conn.ExecuteNonQuery();

			//Response.Redirect("BICheckingResultList.aspx");
		}

		protected void DDL_NAMA_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			try{DDL_H_ALAMAT.SelectedValue = DDL_NAMA.SelectedValue.Trim();}
			catch{}
			TXT_ALAMAT.Text = DDL_H_ALAMAT.SelectedItem.Text.Trim();
			LBL_H_SHSEQ.Text = DDL_NAMA.SelectedItem.Value.Trim();
		}

		protected void DDL_NAMA2_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			try{DDL_H_ALAMAT2.SelectedValue = DDL_NAMA2.SelectedValue.Trim();}
			catch{}
			TXT_ALAMAT2.Text = DDL_H_ALAMAT2.SelectedItem.Text.Trim();
			LBL_H_SHSEQ2.Text = DDL_NAMA2.SelectedItem.Value.Trim();
		}

		private string getLink(string mc, Connection conn) 
		{
			try 
			{
				conn.QueryString = "select TM_LINKNAME, TM_PARSINGPARAM from TRACK_MENU where MENUCODE = '" + mc + "'";
				conn.ExecuteQuery();
			}
			catch (NullReferenceException)
			{
				GlobalTools.popMessage(this, "Connection Error !");
				return "";
			}

			return conn.GetFieldValue("TM_LINKNAME") + conn.GetFieldValue("TM_PARSINGPARAM");
		}

		protected void BTN_BACK_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			string mc = Request.QueryString["mc"];
			string tc = Request.QueryString["tc"];
			string link = "";

			if (Request.QueryString["bi"] == "0" || Request.QueryString["bi"] == "2") 
			{
				link = DMS.CuBESCore.Logic.backLink(Request.QueryString["tc"].ToString(), conn);
				if (link == "" || link.ToString().Trim().Length == 0)
					Response.Redirect("/SME/" + getLink(mc, conn));
				else
					Response.Redirect("/SME/" + link);				
			}
			else
				Response.Redirect("BICheckingResultList.aspx?mc=" + mc);
		}

		protected void BTN_UPDATE_BI_Click(object sender, System.EventArgs e)
		{
			try
			{
				string sql = "update APPLICATION set AP_BLBIPEMILIK = '" + RDO_AP_BLBIPEMILIK.SelectedValue + "'";
				sql += ",AP_BLBIMGMT = '" + RDO_AP_BLBIMGMT.SelectedValue + "'";
				sql += ",AP_BLBIUSAHA = '" + RDO_AP_BLBIUSAHA.SelectedValue + "'";
				sql += ",AP_BLBIPERNAH = '" + RDO_AP_BLBIPERNAH.SelectedValue + "'";
				sql += ",AP_BLBIACCBK = '" + DDL_ACCBK.SelectedValue + "'";
				sql += ",AP_BLBIOCBK = '" + DDL_OCBK.SelectedValue + "'";
				sql += ",AP_BLBIMCBKS = '" + DDL_MCBKS.SelectedValue + "'";
				sql += ",AP_BLBIACCBK12BLN = '" + DDL_ACCBK12BLN.SelectedValue + "'";
				sql += ",AP_BLBIOCBK12BLN = '" + DDL_OCBK12BLN.SelectedValue + "'";
				sql += ",AP_BLBIMCBKS12BLN = '" + DDL_MCBKS12BLN.SelectedValue + "'";
				sql += " where AP_REGNO = '" + TXT_AP_REGNO.Text + "'";
				conn.QueryString = sql;
				conn.ExecuteNonQuery();
			}			
			catch{}

		}

	}
}
