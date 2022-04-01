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
using System.Configuration;
using DMS.DBConnection;
using DMS.CuBESCore;
using Microsoft.VisualBasic;
using System.IO;
using System.Diagnostics;

namespace SME.AccountPlanning.BackUpSnapShot
{
	/// <summary>
	/// Summary description for SnapShot.
	/// </summary>
	public class SnapShot : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.ImageButton BTN_BACK;
		protected System.Web.UI.WebControls.PlaceHolder Menu;
		protected System.Web.UI.WebControls.PlaceHolder SubMenu;
		protected System.Web.UI.WebControls.DataGrid DG_NeracaHistory;
		protected System.Web.UI.WebControls.DropDownList DDL_CURRENCY;
		protected System.Web.UI.WebControls.DropDownList DDL_DENOMINATOR;
		protected System.Web.UI.WebControls.Label LbL_FLAG_INISIALISASI;
		protected System.Web.UI.WebControls.Button BTN_CEK;
		protected System.Web.UI.WebControls.DataGrid DG_Neraca1;
		protected System.Web.UI.WebControls.TextBox TXT_TGL_B1;
		protected System.Web.UI.WebControls.DropDownList DDL_BLN_B1;
		protected System.Web.UI.WebControls.TextBox TXT_YEAR_B1;
		protected System.Web.UI.WebControls.TextBox TXT_TGL_C1;
		protected System.Web.UI.WebControls.DropDownList DDL_BLN_C1;
		protected System.Web.UI.WebControls.TextBox TXT_YEAR_C1;
		protected System.Web.UI.WebControls.TextBox TXT_TGL_D1;
		protected System.Web.UI.WebControls.DropDownList DDL_BLN_D1;
		protected System.Web.UI.WebControls.TextBox TXT_YEAR_D1;
		protected System.Web.UI.WebControls.TextBox TXT_TGL_E1;
		protected System.Web.UI.WebControls.DropDownList DDL_BLN_E1;
		protected System.Web.UI.WebControls.TextBox TXT_YEAR_E1;
		protected System.Web.UI.WebControls.TextBox TXT_B2;
		protected System.Web.UI.WebControls.TextBox TXT_C2;
		protected System.Web.UI.WebControls.TextBox TXT_D2;
		protected System.Web.UI.WebControls.TextBox TXT_E2;
		protected System.Web.UI.WebControls.DropDownList DDL_B3;
		protected System.Web.UI.WebControls.DropDownList DDL_C3;
		protected System.Web.UI.WebControls.DropDownList DDL_D3;
		protected System.Web.UI.WebControls.DropDownList DDL_E3;
		protected System.Web.UI.WebControls.TextBox TXT_B4;
		protected System.Web.UI.WebControls.TextBox TXT_C4;
		protected System.Web.UI.WebControls.TextBox TXT_D4;
		protected System.Web.UI.WebControls.TextBox TXT_E4;
		protected System.Web.UI.WebControls.TextBox TXT_B5;
		protected System.Web.UI.WebControls.TextBox TXT_C5;
		protected System.Web.UI.WebControls.TextBox TXT_D5;
		protected System.Web.UI.WebControls.TextBox TXT_E5;
		protected System.Web.UI.WebControls.TextBox TXT_B6;
		protected System.Web.UI.WebControls.TextBox TXT_C6;
		protected System.Web.UI.WebControls.TextBox TXT_D6;
		protected System.Web.UI.WebControls.TextBox TXT_E6;
		protected System.Web.UI.WebControls.TextBox TXT_B7;
		protected System.Web.UI.WebControls.TextBox TXT_C7;
		protected System.Web.UI.WebControls.TextBox TXT_D7;
		protected System.Web.UI.WebControls.TextBox TXT_E7;
		protected System.Web.UI.WebControls.TextBox TXT_B8;
		protected System.Web.UI.WebControls.TextBox TXT_C8;
		protected System.Web.UI.WebControls.TextBox TXT_D8;
		protected System.Web.UI.WebControls.TextBox TXT_E8;
		protected System.Web.UI.WebControls.TextBox TXT_B9;
		protected System.Web.UI.WebControls.TextBox TXT_C9;
		protected System.Web.UI.WebControls.TextBox TXT_D9;
		protected System.Web.UI.WebControls.TextBox TXT_E9;
		protected System.Web.UI.WebControls.TextBox TXT_B10;
		protected System.Web.UI.WebControls.TextBox TXT_C10;
		protected System.Web.UI.WebControls.TextBox TXT_D10;
		protected System.Web.UI.WebControls.TextBox TXT_E10;
		protected System.Web.UI.WebControls.TextBox TXT_B11;
		protected System.Web.UI.WebControls.TextBox TXT_C11;
		protected System.Web.UI.WebControls.TextBox TXT_D11;
		protected System.Web.UI.WebControls.TextBox TXT_E11;
		protected System.Web.UI.WebControls.TextBox TXT_B12;
		protected System.Web.UI.WebControls.TextBox TXT_C12;
		protected System.Web.UI.WebControls.TextBox TXT_D12;
		protected System.Web.UI.WebControls.TextBox TXT_E12;
		protected System.Web.UI.WebControls.TextBox TXT_B13;
		protected System.Web.UI.WebControls.TextBox TXT_C13;
		protected System.Web.UI.WebControls.TextBox TXT_D13;
		protected System.Web.UI.WebControls.TextBox TXT_E13;
		protected System.Web.UI.WebControls.TextBox TXT_B14;
		protected System.Web.UI.WebControls.TextBox TXT_C14;
		protected System.Web.UI.WebControls.TextBox TXT_D14;
		protected System.Web.UI.WebControls.TextBox TXT_E14;
		protected System.Web.UI.WebControls.TextBox TXT_B15;
		protected System.Web.UI.WebControls.TextBox TXT_C15;
		protected System.Web.UI.WebControls.TextBox TXT_D15;
		protected System.Web.UI.WebControls.TextBox TXT_E15;
		protected System.Web.UI.WebControls.TextBox TXT_B16;
		protected System.Web.UI.WebControls.TextBox TXT_C16;
		protected System.Web.UI.WebControls.TextBox TXT_D16;
		protected System.Web.UI.WebControls.TextBox TXT_E16;
		protected System.Web.UI.WebControls.TextBox TXT_B17;
		protected System.Web.UI.WebControls.TextBox TXT_C17;
		protected System.Web.UI.WebControls.TextBox TXT_D17;
		protected System.Web.UI.WebControls.TextBox TXT_E17;
		protected System.Web.UI.WebControls.TextBox TXT_B18;
		protected System.Web.UI.WebControls.TextBox TXT_C18;
		protected System.Web.UI.WebControls.TextBox TXT_D18;
		protected System.Web.UI.WebControls.TextBox TXT_E18;
		protected System.Web.UI.WebControls.TextBox TXT_B19;
		protected System.Web.UI.WebControls.TextBox TXT_C19;
		protected System.Web.UI.WebControls.TextBox TXT_D19;
		protected System.Web.UI.WebControls.TextBox TXT_E19;
		protected System.Web.UI.WebControls.TextBox TXT_B20;
		protected System.Web.UI.WebControls.TextBox TXT_C20;
		protected System.Web.UI.WebControls.TextBox TXT_D20;
		protected System.Web.UI.WebControls.TextBox TXT_E20;
		protected System.Web.UI.WebControls.TextBox TXT_B21;
		protected System.Web.UI.WebControls.TextBox TXT_C21;
		protected System.Web.UI.WebControls.TextBox TXT_D21;
		protected System.Web.UI.WebControls.TextBox TXT_E21;
		protected System.Web.UI.WebControls.TextBox TXT_B22;
		protected System.Web.UI.WebControls.TextBox TXT_C22;
		protected System.Web.UI.WebControls.TextBox TXT_D22;
		protected System.Web.UI.WebControls.TextBox TXT_E22;
		protected System.Web.UI.WebControls.TextBox TXT_B23;
		protected System.Web.UI.WebControls.TextBox TXT_C23;
		protected System.Web.UI.WebControls.TextBox TXT_D23;
		protected System.Web.UI.WebControls.TextBox TXT_E23;
		protected System.Web.UI.WebControls.TextBox TXT_B24;
		protected System.Web.UI.WebControls.TextBox TXT_C24;
		protected System.Web.UI.WebControls.TextBox TXT_D24;
		protected System.Web.UI.WebControls.TextBox TXT_E24;
		protected System.Web.UI.WebControls.TextBox TXT_B25;
		protected System.Web.UI.WebControls.TextBox TXT_C25;
		protected System.Web.UI.WebControls.TextBox TXT_D25;
		protected System.Web.UI.WebControls.TextBox TXT_E25;
		protected System.Web.UI.WebControls.TextBox TXT_B26;
		protected System.Web.UI.WebControls.TextBox TXT_C26;
		protected System.Web.UI.WebControls.TextBox TXT_D26;
		protected System.Web.UI.WebControls.TextBox TXT_E26;
		protected System.Web.UI.WebControls.TextBox TXT_B27;
		protected System.Web.UI.WebControls.TextBox TXT_C27;
		protected System.Web.UI.WebControls.TextBox TXT_D27;
		protected System.Web.UI.WebControls.TextBox TXT_E27;
		protected System.Web.UI.WebControls.TextBox TXT_B28;
		protected System.Web.UI.WebControls.TextBox TXT_C28;
		protected System.Web.UI.WebControls.TextBox TXT_D28;
		protected System.Web.UI.WebControls.TextBox TXT_E28;
		protected System.Web.UI.WebControls.TextBox TXT_B29;
		protected System.Web.UI.WebControls.TextBox TXT_C29;
		protected System.Web.UI.WebControls.TextBox TXT_D29;
		protected System.Web.UI.WebControls.TextBox TXT_E29;
		protected System.Web.UI.WebControls.TextBox TXT_B30;
		protected System.Web.UI.WebControls.TextBox TXT_C30;
		protected System.Web.UI.WebControls.TextBox TXT_D30;
		protected System.Web.UI.WebControls.TextBox TXT_E30;
		protected System.Web.UI.WebControls.TextBox TXT_B31;
		protected System.Web.UI.WebControls.TextBox TXT_C31;
		protected System.Web.UI.WebControls.TextBox TXT_D31;
		protected System.Web.UI.WebControls.TextBox TXT_E31;
		protected System.Web.UI.WebControls.TextBox TXT_B32;
		protected System.Web.UI.WebControls.TextBox TXT_C32;
		protected System.Web.UI.WebControls.TextBox TXT_D32;
		protected System.Web.UI.WebControls.TextBox TXT_E32;
		protected System.Web.UI.WebControls.TextBox TXT_B33;
		protected System.Web.UI.WebControls.TextBox TXT_C33;
		protected System.Web.UI.WebControls.TextBox TXT_D33;
		protected System.Web.UI.WebControls.TextBox TXT_E33;
		protected System.Web.UI.WebControls.TextBox TXT_B34;
		protected System.Web.UI.WebControls.TextBox TXT_C34;
		protected System.Web.UI.WebControls.TextBox TXT_D34;
		protected System.Web.UI.WebControls.TextBox TXT_E34;
		protected System.Web.UI.WebControls.TextBox TXT_B35;
		protected System.Web.UI.WebControls.TextBox TXT_C35;
		protected System.Web.UI.WebControls.TextBox TXT_D35;
		protected System.Web.UI.WebControls.TextBox TXT_E35;
		protected System.Web.UI.WebControls.Label LBL_H_TAHUN;
		protected System.Web.UI.WebControls.Panel PnlNeraca;
		protected Tools tool = new Tools();
		protected System.Web.UI.WebControls.TextBox TXT_B1;
		protected System.Web.UI.WebControls.TextBox TXT_C1;
		protected System.Web.UI.WebControls.TextBox TXT_D1;
		protected System.Web.UI.WebControls.TextBox TXT_E1;
		protected System.Web.UI.WebControls.TextBox TXT_B3;
		protected System.Web.UI.WebControls.TextBox TXT_C3;
		protected System.Web.UI.WebControls.TextBox TXT_D3;
		protected System.Web.UI.WebControls.TextBox TXT_E3;
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.Label LBL_TXT_SCENARIO;
		protected System.Web.UI.WebControls.Label Label2;
		protected System.Web.UI.WebControls.Label Label3;
		protected System.Web.UI.WebControls.Label Label4;
		protected System.Web.UI.WebControls.Button BTN_SAVE_BUSINESS_AND_STRATEGY;
		protected System.Web.UI.WebControls.TextBox TXT_DESCRIPTION_OF_BUSINESS;
		protected System.Web.UI.WebControls.TextBox TXT_CLIENTS_STRATEGY_AND_PRIORITIES;
		protected System.Web.UI.WebControls.TextBox TXT_RECENT_DEVELOPMENTS;
		protected System.Web.UI.WebControls.TextBox TXT_IMPLICATIONS_FOR_MANDIRI;
		protected System.Web.UI.WebControls.DataGrid DGR_SCENARIO;
		protected System.Web.UI.WebControls.Button BTN_SAVE_COMPITIVE;
		protected System.Web.UI.WebControls.Label LBL_TXT_CIF;
		protected System.Web.UI.WebControls.Label LBL_TXT_CUST_NAME;
		protected System.Web.UI.WebControls.Label LBL_TXT_ADDRESS;
		protected System.Web.UI.WebControls.DropDownList DDL_PRODUCT;
		protected System.Web.UI.WebControls.TextBox TXT_PRIMARY_BANK;
		protected System.Web.UI.WebControls.TextBox TXT_OTHER_BANK;
		protected System.Web.UI.WebControls.Label Label5;
		protected System.Web.UI.WebControls.Label Label6;
		protected System.Web.UI.WebControls.DataGrid StrategiesToGrowAnchors;
		protected System.Web.UI.WebControls.Button BTN_SAVE_STRATEGIES_TO_GROW_ANCHORS;
		protected System.Web.UI.WebControls.TextBox TXT_SEQ_GROW_ANCHORS;
		protected System.Web.UI.WebControls.TextBox TXT_KEY_SUPPORT_NEEDED;
		protected System.Web.UI.WebControls.DataGrid DATA_UPLOAD;
		protected System.Web.UI.HtmlControls.HtmlTableCell Td2;
		protected System.Web.UI.WebControls.Label LBL_STATUS;
		protected System.Web.UI.WebControls.RegularExpressionValidator RegularExpressionValidator1;
		protected System.Web.UI.WebControls.Label LBL_STATUSREPORT;
		protected System.Web.UI.WebControls.Button BTN_UPLOAD;
		protected System.Web.UI.HtmlControls.HtmlInputFile TXT_FILE_UPLOAD;
		protected System.Web.UI.HtmlControls.HtmlTableRow TR_NO;
		protected System.Web.UI.WebControls.DataGrid DG_LRHistory;
		protected System.Web.UI.WebControls.DropDownList Dropdownlist1;
		protected System.Web.UI.WebControls.DropDownList Dropdownlist2;
		protected System.Web.UI.WebControls.Label Label7;
		protected System.Web.UI.WebControls.Button Button1;
		protected System.Web.UI.WebControls.DataGrid DB_LBRG1;
		protected System.Web.UI.WebControls.TextBox TXT_TGL_B37;
		protected System.Web.UI.WebControls.DropDownList DDL_BLN_B37;
		protected System.Web.UI.WebControls.TextBox TXT_YEAR_B37;
		protected System.Web.UI.WebControls.TextBox TXT_TGL_C37;
		protected System.Web.UI.WebControls.DropDownList DDL_BLN_C37;
		protected System.Web.UI.WebControls.TextBox TXT_YEAR_C37;
		protected System.Web.UI.WebControls.TextBox TXT_TGL_D37;
		protected System.Web.UI.WebControls.DropDownList DDL_BLN_D37;
		protected System.Web.UI.WebControls.TextBox TXT_YEAR_D37;
		protected System.Web.UI.WebControls.TextBox TXT_TGL_E37;
		protected System.Web.UI.WebControls.DropDownList DDL_BLN_E37;
		protected System.Web.UI.WebControls.TextBox TXT_YEAR_E37;
		protected System.Web.UI.WebControls.TextBox TXT_B38;
		protected System.Web.UI.WebControls.TextBox TXT_C38;
		protected System.Web.UI.WebControls.TextBox TXT_D38;
		protected System.Web.UI.WebControls.TextBox TXT_E38;
		protected System.Web.UI.WebControls.DropDownList DDL_B39;
		protected System.Web.UI.WebControls.DropDownList DDL_C39;
		protected System.Web.UI.WebControls.DropDownList DDL_D39;
		protected System.Web.UI.WebControls.DropDownList DDL_E39;
		protected System.Web.UI.WebControls.TextBox TXT_B40;
		protected System.Web.UI.WebControls.TextBox TXT_C40;
		protected System.Web.UI.WebControls.TextBox TXT_D40;
		protected System.Web.UI.WebControls.TextBox TXT_E40;
		protected System.Web.UI.WebControls.TextBox TXT_B41;
		protected System.Web.UI.WebControls.TextBox TXT_C41;
		protected System.Web.UI.WebControls.TextBox TXT_D41;
		protected System.Web.UI.WebControls.TextBox TXT_E41;
		protected System.Web.UI.WebControls.TextBox TXT_B42;
		protected System.Web.UI.WebControls.TextBox TXT_C42;
		protected System.Web.UI.WebControls.TextBox TXT_D42;
		protected System.Web.UI.WebControls.TextBox TXT_E42;
		protected System.Web.UI.WebControls.TextBox TXT_B43;
		protected System.Web.UI.WebControls.TextBox TXT_C43;
		protected System.Web.UI.WebControls.TextBox TXT_D43;
		protected System.Web.UI.WebControls.TextBox TXT_E43;
		protected System.Web.UI.WebControls.TextBox TXT_B44;
		protected System.Web.UI.WebControls.TextBox TXT_C44;
		protected System.Web.UI.WebControls.TextBox TXT_D44;
		protected System.Web.UI.WebControls.TextBox TXT_E44;
		protected System.Web.UI.WebControls.TextBox TXT_B45;
		protected System.Web.UI.WebControls.TextBox TXT_C45;
		protected System.Web.UI.WebControls.TextBox TXT_D45;
		protected System.Web.UI.WebControls.TextBox TXT_E45;
		protected System.Web.UI.WebControls.TextBox TXT_B46;
		protected System.Web.UI.WebControls.TextBox TXT_C46;
		protected System.Web.UI.WebControls.TextBox TXT_D46;
		protected System.Web.UI.WebControls.TextBox TXT_E46;
		protected System.Web.UI.WebControls.TextBox TXT_B47;
		protected System.Web.UI.WebControls.TextBox TXT_C47;
		protected System.Web.UI.WebControls.TextBox TXT_D47;
		protected System.Web.UI.WebControls.TextBox TXT_E47;
		protected System.Web.UI.WebControls.TextBox TXT_B48;
		protected System.Web.UI.WebControls.TextBox TXT_C48;
		protected System.Web.UI.WebControls.TextBox TXT_D48;
		protected System.Web.UI.WebControls.TextBox TXT_E48;
		protected System.Web.UI.WebControls.TextBox TXT_B49;
		protected System.Web.UI.WebControls.TextBox TXT_C49;
		protected System.Web.UI.WebControls.TextBox TXT_D49;
		protected System.Web.UI.WebControls.TextBox TXT_E49;
		protected System.Web.UI.WebControls.TextBox TXT_B50;
		protected System.Web.UI.WebControls.TextBox TXT_C50;
		protected System.Web.UI.WebControls.TextBox TXT_D50;
		protected System.Web.UI.WebControls.TextBox TXT_E50;
		protected System.Web.UI.WebControls.TextBox TXT_B51;
		protected System.Web.UI.WebControls.TextBox TXT_C51;
		protected System.Web.UI.WebControls.TextBox TXT_D51;
		protected System.Web.UI.WebControls.TextBox TXT_E51;
		protected System.Web.UI.WebControls.TextBox TXT_B52;
		protected System.Web.UI.WebControls.TextBox TXT_C52;
		protected System.Web.UI.WebControls.TextBox TXT_D52;
		protected System.Web.UI.WebControls.TextBox TXT_E52;
		protected System.Web.UI.WebControls.TextBox TXT_B53;
		protected System.Web.UI.WebControls.TextBox TXT_C53;
		protected System.Web.UI.WebControls.TextBox TXT_D53;
		protected System.Web.UI.WebControls.TextBox TXT_E53;
		protected System.Web.UI.WebControls.TextBox TXT_B54;
		protected System.Web.UI.WebControls.TextBox TXT_C54;
		protected System.Web.UI.WebControls.TextBox TXT_D54;
		protected System.Web.UI.WebControls.TextBox TXT_E54;
		protected System.Web.UI.WebControls.TextBox TXT_B55;
		protected System.Web.UI.WebControls.TextBox TXT_C55;
		protected System.Web.UI.WebControls.TextBox TXT_D55;
		protected System.Web.UI.WebControls.TextBox TXT_E55;
		protected System.Web.UI.WebControls.TextBox TXT_B56;
		protected System.Web.UI.WebControls.TextBox TXT_C56;
		protected System.Web.UI.WebControls.TextBox TXT_D56;
		protected System.Web.UI.WebControls.TextBox TXT_E56;
		protected System.Web.UI.WebControls.TextBox TXT_B57;
		protected System.Web.UI.WebControls.TextBox TXT_C57;
		protected System.Web.UI.WebControls.TextBox TXT_D57;
		protected System.Web.UI.WebControls.TextBox TXT_E57;
		protected System.Web.UI.WebControls.TextBox TXT_B58;
		protected System.Web.UI.WebControls.TextBox TXT_C58;
		protected System.Web.UI.WebControls.TextBox TXT_D58;
		protected System.Web.UI.WebControls.TextBox TXT_E58;
		protected System.Web.UI.WebControls.TextBox TXT_B59;
		protected System.Web.UI.WebControls.TextBox TXT_C59;
		protected System.Web.UI.WebControls.TextBox TXT_D59;
		protected System.Web.UI.WebControls.TextBox TXT_E59;
		protected System.Web.UI.WebControls.TextBox TXT_B60;
		protected System.Web.UI.WebControls.TextBox TXT_C60;
		protected System.Web.UI.WebControls.TextBox TXT_D60;
		protected System.Web.UI.WebControls.TextBox TXT_E60;
		protected System.Web.UI.WebControls.TextBox TXT_B61;
		protected System.Web.UI.WebControls.TextBox TXT_C61;
		protected System.Web.UI.WebControls.TextBox TXT_D61;
		protected System.Web.UI.WebControls.TextBox TXT_E61;
		protected System.Web.UI.WebControls.Button BTN_SIMPAN;
		protected System.Web.UI.WebControls.Button BTNCLEAR;
		protected System.Web.UI.WebControls.Label Label8;
		protected System.Web.UI.WebControls.Panel Panel1;
		protected System.Web.UI.WebControls.TextBox TXT_B37;
		protected System.Web.UI.WebControls.TextBox TXT_C37;
		protected System.Web.UI.WebControls.TextBox TXT_D37;
		protected System.Web.UI.WebControls.TextBox TXT_E37;
		protected System.Web.UI.WebControls.TextBox TXT_B39;
		protected System.Web.UI.WebControls.TextBox TXT_C39;
		protected System.Web.UI.WebControls.TextBox TXT_D39;
		protected System.Web.UI.WebControls.TextBox TXT_E39;

		protected Connection conn;
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			conn = new Connection(ConfigurationSettings.AppSettings["conn"]);

			if(!IsPostBack)
			{
				viewdata();
				viewdata_history();
				isi_initial();		
				retrieve_data_neraca();

				/*selain neraca*/
				fillAllDDL();
				ClearAllField();

				BindAllGrid();

				ViewUploadFiles();
				TR_NO.Visible = false;

				/*laba rugi constructor*/
				viewdata_LabaRugi();
				viewdata_history_LabaRugi();
				retrieve_data_LabaRugi();
				isi_initial_LabaRugi();
			}

			ViewMenu();
			//ViewSubMenu();

			LBL_H_TAHUN.Visible = false;
		}

		#region Buat narik data Laba Rugi
		private void viewdata_LabaRugi()
		{
			 //cu_ref = '28042008COR1000002' and ap_regno = '14072008COR1000001'";
			conn.QueryString = "select distinct IS_DATE_PERIODE,IS_NUM_MONTH,IS_REPORTTYPE,year(IS_DATE_PERIODE) tahun,IS_CURRENCY,IS_DENOMINATOR from CA_LABARUGI_MIDDLE where ap_regno = '14072008COR1000001' ORDER BY IS_DATE_PERIODE DESC";
			conn.ExecuteQuery();
			
			DB_LBRG1.DataSource = conn.GetDataTable().Copy();
			DB_LBRG1.DataBind();
			for(int i = 0; i < DB_LBRG1.Items.Count; i++)
			{
				DB_LBRG1.Items[i].Cells[0].Text = tool.FormatDate(DB_LBRG1.Items[i].Cells[0].Text);
			}
		}

		private void viewdata_history_LabaRugi()
		{
			//conn.QueryString = "select POSISI_TGL,JML_BLN,JNS_LAP,year(POSISI_TGL) tahun from CA_LABARUGI_SMALL where ap_regno = '" + Request.QueryString["regno"]+ "' order by POSISI_TGL desc";
			//cu_ref = '28042008COR1000002' and ap_regno = '14072008COR1000001'";
			conn.QueryString = "exec CA_LABARUGI_MIDDLE_HISTORY '28042008COR1000002', '14072008COR1000001'";
			conn.ExecuteQuery();
			
			//			System.Data.DataTable data = new DataTable(); 
			//			data = conn.GetDataTable().Copy();
			DG_LRHistory.DataSource = conn.GetDataTable().Copy();
			DG_LRHistory.DataBind();
			for(int i = 0; i < DG_LRHistory.Items.Count; i++)
			{
				DG_LRHistory.Items[i].Cells[1].Text = tool.FormatDate(DG_LRHistory.Items[i].Cells[1].Text);
			}
		}

		private void retrieve_data_LabaRugi()
		{

			//cu_ref = '28042008COR1000002' and ap_regno = '14072008COR1000001'";
			//LBL_H_TAHUN.Text = Request.QueryString["tahun"];
			LBL_H_TAHUN.Text = "2012";

			int row;
			tgl_default();
			
			conn.QueryString = "select is_isproyeksi from ca_labarugi_middle where year(is_date_periode) = '2012' and ap_regno = '14072008COR1000001'";
			conn.ExecuteQuery();
			if (conn.GetFieldValue("is_isproyeksi")=="1")
				row = 70;
			else
				row = 69;


			conn.QueryString = "select top 4 CU_REF,AP_REGNO,IS_DATE_PERIODE,IS_NUM_MONTH,IS_REPORTTYPE,IS_SALES_ONCR,IS_NET_SALES" +
				",IS_COST_GS,IS_PROSEN1,IS_GROSS_MARGIN,IS_PROSEN2,IS_SELLING_GENADM,IS_PROSEN3" +
				",IS_OPR_EARN,IS_PROSEN4,IS_DEPRECIATE,IS_AMORTIZATION1,IS_AMORTIZATION2" +
				",IS_OTH_INCM_NET,IS_EXTRAORD,IS_EARN_BIT,IS_INTRST_EXP,IS_EARN_BT,IS_PROSEN5" +
				",IS_INCM_TAX,IS_NET_INCM,IS_PROSEN6,IS_CURRENCY,IS_DENOMINATOR,IS_SUMBERDATA,IS_ISPROYEKSI from ca_labarugi_middle where year(is_date_periode) <= '2012' and ap_regno = '14072008COR1000001' order by is_date_periode desc";
			conn.ExecuteQuery();

			System.Data.DataTable dt;
			dt = conn.GetDataTable().Copy();
			int jml_row = dt.Rows.Count;

			conn.QueryString = "select excel_field from ca_excel where excel_file = 'kmk_ki_middle' and excel_type = 'is'";
			conn.ExecuteQuery();

			
			for (int i = 0; i < jml_row; i++)
			{
				
				row--;
				string vtmp = ((char)row).ToString();
				int k = 6;
				int kk = 2;
				for (int m=37;m<41;m++)
				{
					System.Web.UI.WebControls.TextBox txt = (System.Web.UI.WebControls.TextBox) Page.FindControl("TXT_" + vtmp + m.ToString());
					if (Request.QueryString["mode"]=="retrieve")
						//if (mode=="retrieve")
					{
						if (m!=37)
						{
							if (m==39)
							{
								for (int nn=39;nn<40;nn++)
								{
									System.Web.UI.WebControls.DropDownList DDL_ = (System.Web.UI.WebControls.DropDownList) this.Page.FindControl("DDL_" + vtmp + nn.ToString());							
									txt.Text = dt.Rows[i][kk].ToString();
									try 
									{
										DDL_.SelectedValue = txt.Text;
									}
									catch(Exception ex)
									{
										DDL_.SelectedValue = "-";
										string temp = ex.ToString();
									}
								}
							}
							else
							{
								//txt.Text = myMoneyFormat_noDec(dt.Rows[i][kk].ToString());
								txt.Text = dt.Rows[i][kk].ToString();
							}
						} 
						else 
						{
							for (int n=37;n<38;n++)
							{
								System.Web.UI.WebControls.TextBox TXT_TGL_ = (System.Web.UI.WebControls.TextBox) this.Page.FindControl("TXT_TGL_" + vtmp + n.ToString());
								System.Web.UI.WebControls.DropDownList DDL_BLN_ = (System.Web.UI.WebControls.DropDownList) this.Page.FindControl("DDL_BLN_" + vtmp + n.ToString());
								System.Web.UI.WebControls.TextBox TXT_YEAR_ = (System.Web.UI.WebControls.TextBox) this.Page.FindControl("TXT_YEAR_" + vtmp + n.ToString());
			
								DateTime excdate = Convert.ToDateTime(tool.FormatDate(dt.Rows[i][kk].ToString()));
								GlobalTools.fillDateForm(TXT_TGL_, DDL_BLN_, TXT_YEAR_, excdate);
							}
						}			
					} 
					else 
					{
						txt.Text = "";
					}
					kk++;
				}
	
				for (int j = 41; j < 62; j++)
				{	
					System.Web.UI.WebControls.TextBox txt = (System.Web.UI.WebControls.TextBox) Page.FindControl("TXT_" + vtmp + j.ToString());
					if (Request.QueryString["mode"]=="retrieve")
					{
						txt.Text = myMoneyFormat_noDec(dt.Rows[i][k].ToString());
					}
					else 
					{
						txt.Text = "";
					}
					k++;
				}
			
				if (row<=66){ break; }
	
			}
		}

		private void isi_initial_LabaRugi()
		{
			//cu_ref = '28042008COR1000002' and ap_regno = '14072008COR1000001'";
			conn.QueryString = "select bs_currency,bs_denominator from ca_neraca_middle where cu_ref = '28042008COR1000002' and ap_regno = '14072008COR1000001'";
			conn.ExecuteQuery();
			System.Data.DataTable dt = new System.Data.DataTable();
			dt = conn.GetDataTable().Copy();

			if (conn.GetRowCount() <= 0)
			{
				GlobalTools.fillRefList(DDL_CURRENCY,"select currencyid,currencydesc from rfcurrency where active ='1'",true,conn);
				DDL_CURRENCY.SelectedValue = "IDR";
				DDL_DENOMINATOR.SelectedValue = "000";
				DDL_CURRENCY.Enabled = true;
				DDL_DENOMINATOR.Enabled = true;
				BTN_CEK.Enabled = true;
			}
			else
			{
				GlobalTools.fillRefList(DDL_CURRENCY,"select currencyid,currencydesc from rfcurrency where active ='1'",true,conn);
				try { DDL_CURRENCY.SelectedValue = dt.Rows[0]["bs_currency"].ToString(); }
				catch { DDL_CURRENCY.SelectedValue = "IDR"; }
				DDL_CURRENCY.Enabled = false;
				try { DDL_DENOMINATOR.SelectedValue = dt.Rows[0]["bs_denominator"].ToString(); }
				catch { DDL_DENOMINATOR.SelectedValue = "000"; }
				DDL_DENOMINATOR.Enabled = false;
				BTN_CEK.Enabled = false;
				PnlNeraca.Visible = true;
			}

			//----------------------------------------------
			//added by nyoman for current scoring condition 
			conn.QueryString = "select FI_APPROVAL_VER from  VW_CA_NERACA_MIDDLE_FI_APPROVAL_VER " +
				"where AP_REGNO = '14072008COR1000001' ";
			conn.ExecuteQuery();
			try
			{
				if (conn.GetFieldValue(0,0) == "2")
				{
					DDL_CURRENCY.SelectedValue = "IDR";
					DDL_DENOMINATOR.SelectedValue = "000";
					DDL_CURRENCY.Enabled = false;
					DDL_DENOMINATOR.Enabled = false;
					BTN_CEK.Enabled = false;
					PnlNeraca.Visible = true;
				}
			}
			catch {}
			//----------------------------------------------
		}
		#endregion

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
			this.BTN_CEK.Click += new System.EventHandler(this.BTN_CEK_Click);
			this.DG_Neraca1.ItemCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.DG_Neraca1_ItemCommand);
			this.DB_LBRG1.ItemCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.DB_LBRG1_ItemCommand);
			this.BTN_SAVE_BUSINESS_AND_STRATEGY.Click += new System.EventHandler(this.BTN_SAVE_BUSINESS_AND_STRATEGY_Click);
			this.DGR_SCENARIO.ItemCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.DGR_SCENARIO_ItemCommand);
			this.DGR_SCENARIO.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.DGR_SCENARIO_PageIndexChanged);
			this.BTN_SAVE_COMPITIVE.Click += new System.EventHandler(this.BTN_SAVE_COMPITIVE_Click);
			this.StrategiesToGrowAnchors.ItemCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.StrategiesToGrowAnchors_ItemCommand);
			this.StrategiesToGrowAnchors.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.StrategiesToGrowAnchors_PageIndexChanged);
			this.BTN_SAVE_STRATEGIES_TO_GROW_ANCHORS.Click += new System.EventHandler(this.BTN_SAVE_STRATEGIES_TO_GROW_ANCHORS_Click);
			this.BTN_UPLOAD.Click += new System.EventHandler(this.BTN_UPLOAD_Click);
			this.DATA_UPLOAD.ItemCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.DATA_UPLOAD_ItemCommand);
			this.DATA_UPLOAD.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.DATA_UPLOAD_PageIndexChanged);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void BTN_CEK_Click(object sender, System.EventArgs e)
		{
			conn.QueryString = "exec ca_temp_curr_denom_sp 'save','" + Request.QueryString["curef"] + "','" +
				Request.QueryString["regno"] + "','" + DDL_CURRENCY.SelectedValue + "','" +
				DDL_DENOMINATOR.SelectedValue + "'";
			conn.ExecuteNonQuery();
			PnlNeraca.Visible = true;
		}

		private void DG_Neraca1_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			string cmd = e.CommandName;
			
			switch (cmd)
			{
				case "retrieve" :
					string vtemp = e.Item.Cells[3].Text;
					//Response.Redirect("Neraca_KMK_KI_Medium.aspx?tahun=" + vtemp +"&mode=retrieve&regno="+Request.QueryString["regno"]+"&mc="+Request.QueryString["mc"]+"&bussunitid="+Request.QueryString["bussunitid"]+"&programid="+Request.QueryString["programid"]+"&jnsnasabah="+Request.QueryString["jnsnasabah"]+"&curef="+Request.QueryString["curef"]+"&tc="+Request.QueryString["tc"]+"&viewmode="+Request.QueryString["viewmode"]+"&lmsreg="+Request.QueryString["lmsreg"]+"&scr="+Request.QueryString["scr"]);
					Response.Redirect("SnapShot.aspx?tahun=" + vtemp +"&mode=retrieve&mc=" + Request.QueryString["mc"]+ "&cif=" + Request.QueryString["cif"] + "&bs=" + Request.QueryString["bs"] + "&bc=" + Request.QueryString["bc"] + "&rd=" + Request.QueryString["rd"] + "&cd=" + Request.QueryString["cd"]);
					clear_field();
					retrieve_data_neraca();
					
					break;
				default :
					break;
			}
		}

		private void BTN_SAVE_BUSINESS_AND_STRATEGY_Click(object sender, System.EventArgs e)
		{
			conn.QueryString = "EXEC AP_INSERT_BUSINESS_AND_STRATEGY '" + Request.QueryString["cif"] + "','" + TXT_DESCRIPTION_OF_BUSINESS.Text.ToString() + "','" + TXT_CLIENTS_STRATEGY_AND_PRIORITIES.Text.ToString() + "','" + TXT_RECENT_DEVELOPMENTS.Text.ToString() + "','" + TXT_IMPLICATIONS_FOR_MANDIRI.Text.ToString() + "'";
			conn.ExecuteQuery();

			//RETRIEVE_BUSINESS_AND_STRATEGY(Request.QueryString["cif"]);
			BindAllGrid();
		}

		private void RETRIEVE_BUSINESS_AND_STRATEGY(string CIF)
		{
			conn.QueryString = "SELECT * FROM VW_AP_BUSINESS_AND_STRATEGY WHERE CU_CIF = '" + CIF + "'";
			conn.ExecuteQuery();

			TXT_DESCRIPTION_OF_BUSINESS.Text = conn.GetFieldValue("DESCRIPTION_OF_BUSINESS");
			TXT_CLIENTS_STRATEGY_AND_PRIORITIES.Text = conn.GetFieldValue("CLIENT_STRATEGY_AND_PRIORITIES");
			TXT_RECENT_DEVELOPMENTS.Text = conn.GetFieldValue("RECENT_DEVELOPMENTS");
			TXT_IMPLICATIONS_FOR_MANDIRI.Text = conn.GetFieldValue("IMPLICATIONS_FOR_MANDIRI");
		}

		private void DGR_SCENARIO_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			switch(((LinkButton)e.CommandSource).CommandName)
			{
				case "edit":
					string CIF = e.Item.Cells[0].Text.Trim();
					string ID_AP_VARIABLE = e.Item.Cells[1].Text.Trim();
					RETRIEVE_COMPETITIVE_SCAN(CIF, ID_AP_VARIABLE);
					break;
				case "delete":
					CIF = e.Item.Cells[0].Text.Trim();
					ID_AP_VARIABLE = e.Item.Cells[1].Text.Trim();
					conn.QueryString = "DELETE AP_COMPETITIVE_SCAN WHERE CU_CIF = '" + CIF + "' AND ID_AP_VARIABLE = '" + ID_AP_VARIABLE + "'";
					conn.ExecuteQuery();
					
					//bindhere
					BindData(DGR_SCENARIO, "SELECT AP_VARIABLE.DESCRIPTION as product,* FROM AP_COMPETITIVE_SCAN, AP_VARIABLE WHERE CU_CIF = '" + Request.QueryString["CIF"] + "' AND  AP_VARIABLE.ID_AP_VARIABLE = AP_COMPETITIVE_SCAN.ID_AP_VARIABLE");
					BindDGRScenario();
					break;
			}
		}

		private void BindDGRScenario()
		{
			for(int i=0; i< DGR_SCENARIO.Items.Count; i++)
			{
				//dari sini pake index
				/*** DropDownList Assign To ***/
				conn.QueryString = "SELECT * FROM AP_COMPETITIVE_SCAN WHERE CU_CIF = '" + DGR_SCENARIO.Items[i].Cells[0].Text.ToString() + "' AND ID_AP_VARIABLE = '" + DGR_SCENARIO.Items[i].Cells[1].Text.ToString() + "'";
				conn.ExecuteQuery();

				System.Web.UI.WebControls.TextBox txt = (System.Web.UI.WebControls.TextBox) DGR_SCENARIO.Items[i].Cells[3].FindControl("TXT_PRIMARY_BANK_GRID");
				if(txt != null)
				{
					txt.Text = conn.GetFieldValue("PRIMARY_BANK");
				}

				txt = (System.Web.UI.WebControls.TextBox) DGR_SCENARIO.Items[i].Cells[4].FindControl("TXT_OTHER_BANKS_GRID");
				if(txt != null)
				{
					txt.Text = conn.GetFieldValue("OTHER_BANKS");
				}
			}
		}

		private void RETRIEVE_COMPETITIVE_SCAN(string CIF, string ID_AP_VARIABLE)
		{
			conn.QueryString = "SELECT * FROM VW_AP_COMPETITION_SCAN WHERE CU_CIF = '" + CIF + "' AND ID_AP_VARIABLE = '" + ID_AP_VARIABLE + "'";
			conn.ExecuteQuery();

			DDL_PRODUCT.SelectedValue = conn.GetFieldValue("ID_AP_VARIABLE");
			TXT_PRIMARY_BANK.Text = conn.GetFieldValue("PRIMARY_BANK");
			TXT_OTHER_BANK.Text = conn.GetFieldValue("OTHER_BANKS");
		}

		private void BTN_SAVE_COMPITIVE_Click(object sender, System.EventArgs e)
		{
			conn.QueryString = "EXEC AP_INSERT_AP_COMPETITIVE_SCAN '" + Request.QueryString["cif"] + "','" + DDL_PRODUCT.SelectedValue.ToString() + "','" + TXT_PRIMARY_BANK.Text + "','" + TXT_OTHER_BANK.Text + "'";
			conn.ExecuteQuery();

			BindData(DGR_SCENARIO, "SELECT AP_VARIABLE.DESCRIPTION as product,* FROM AP_COMPETITIVE_SCAN, AP_VARIABLE WHERE CU_CIF = '" + Request.QueryString["CIF"] + "' AND  AP_VARIABLE.ID_AP_VARIABLE = AP_COMPETITIVE_SCAN.ID_AP_VARIABLE");
			BindDGRScenario();

			DDL_PRODUCT.SelectedValue = "";
			TXT_PRIMARY_BANK.Text = "";
			TXT_OTHER_BANK.Text = "";
		}

		private void StrategiesToGrowAnchors_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			switch(((LinkButton)e.CommandSource).CommandName)
			{
				case "edit":
					string SEQ = e.Item.Cells[1].Text.Trim();
					string CIF = e.Item.Cells[0].Text.Trim();
					RETRIEVE_StrategiesToGrowAnchors(CIF, SEQ);
					break;
				case "delete":
					SEQ = e.Item.Cells[1].Text.Trim();
					CIF = e.Item.Cells[0].Text.Trim();
					conn.QueryString = "DELETE AP_STRATEGIES_TO_GROW_ANCHORS WHERE CU_CIF = '" + CIF + "' AND SEQ = '" + SEQ + "'";
					conn.ExecuteQuery();
					
					//bindhere
					BindData(StrategiesToGrowAnchors, "SELECT * FROM AP_STRATEGIES_TO_GROW_ANCHORS WHERE CU_CIF = '" + CIF + "' ORDER BY SEQ ASC");
					BindSTRATEGIES_TO_GROW_ANCHORS();
					break;
			}
		}

		private void RETRIEVE_StrategiesToGrowAnchors(string CIF, string SEQ)
		{
			conn.QueryString = "SELECT * FROM VW_AP_AP_STRATEGIES_TO_GROW_ANCHORS WHERE CU_CIF = '" + CIF + "' AND SEQ = '" + SEQ + "'";
			conn.ExecuteQuery();

			TXT_SEQ_GROW_ANCHORS.Text = conn.GetFieldValue("SEQ");
			TXT_KEY_SUPPORT_NEEDED.Text = conn.GetFieldValue("KEY_SUPPORT_NEEDED");
		}

		private void BTN_SAVE_STRATEGIES_TO_GROW_ANCHORS_Click(object sender, System.EventArgs e)
		{
			conn.QueryString = "EXEC AP_INSERT_AP_STRATEGIES_TO_GROW_ANCHORS '" + TXT_SEQ_GROW_ANCHORS.Text + "','" + Request.QueryString["CIF"]  + "','" + TXT_KEY_SUPPORT_NEEDED.Text.ToString() + "'";
			conn.ExecuteQuery();

			TXT_SEQ_GROW_ANCHORS.Text = "";

			BindData(StrategiesToGrowAnchors, "SELECT * FROM AP_STRATEGIES_TO_GROW_ANCHORS WHERE CU_CIF = '" + Request.QueryString["cif"] + "' ORDER BY SEQ ASC");
			BindSTRATEGIES_TO_GROW_ANCHORS();
		}

		private void BindSTRATEGIES_TO_GROW_ANCHORS()
		{
			for(int i=0; i< StrategiesToGrowAnchors.Items.Count; i++)
			{
				//dari sini pake index
				/*** DropDownList Assign To ***/
				conn.QueryString = "SELECT * FROM AP_STRATEGIES_TO_GROW_ANCHORS WHERE CU_CIF = '" + StrategiesToGrowAnchors.Items[i].Cells[0].Text.ToString() + "' AND SEQ = '" + StrategiesToGrowAnchors.Items[i].Cells[1].Text.ToString() + "'";
				conn.ExecuteQuery();

				System.Web.UI.WebControls.TextBox txt = (System.Web.UI.WebControls.TextBox) StrategiesToGrowAnchors.Items[i].Cells[2].FindControl("TXT_KEY_SUPPORT");
				if(txt != null)
				{
					txt.Text = conn.GetFieldValue("KEY_SUPPORT_NEEDED");
				}
			}
		}
		
		/* HOME MADE FUNCTION */
		private void viewdata()
		{
			/*conn.QueryString = "select distinct BS_DATE_PERIODE,BS_NUM_MONTH,BS_REPORTTYPE,year(BS_DATE_PERIODE) tahun,BS_CURRENCY,BS_DENOMINATOR from CA_NERACA_MIDDLE where ap_regno = '"+ Request.QueryString["regno"]+ "' order by BS_DATE_PERIODE desc";
			conn.ExecuteQuery();*/

			conn.QueryString = "select distinct BS_DATE_PERIODE,BS_NUM_MONTH,BS_REPORTTYPE,year(BS_DATE_PERIODE) tahun,BS_CURRENCY,BS_DENOMINATOR from CA_NERACA_MIDDLE where ap_regno = '14072008COR1000001' order by BS_DATE_PERIODE desc";
			conn.ExecuteQuery();
			
			DG_Neraca1.DataSource = conn.GetDataTable().Copy();
			DG_Neraca1.DataBind();
			for(int i = 0; i < DG_Neraca1.Items.Count; i++)
			{
				DG_Neraca1.Items[i].Cells[0].Text = tool.FormatDate(DG_Neraca1.Items[i].Cells[0].Text);
			}
		}

		private void isi_initial()
		{
			conn.QueryString = "select bs_currency,bs_denominator from ca_neraca_middle where cu_ref = '28042008COR1000002' and ap_regno = '14072008COR1000001'";
			conn.ExecuteQuery();
			System.Data.DataTable dt = new System.Data.DataTable();
			dt = conn.GetDataTable().Copy();

			if (conn.GetRowCount() <= 0)
			{
				GlobalTools.fillRefList(DDL_CURRENCY,"select currencyid,currencydesc from rfcurrency where active ='1'",true,conn);
				DDL_CURRENCY.SelectedValue = "IDR";
				DDL_DENOMINATOR.SelectedValue = "000";
				DDL_CURRENCY.Enabled = true;
				DDL_DENOMINATOR.Enabled = true;
				BTN_CEK.Enabled = true;
			}
			else
			{
				GlobalTools.fillRefList(DDL_CURRENCY,"select currencyid,currencydesc from rfcurrency where active ='1'",true,conn);
				try { DDL_CURRENCY.SelectedValue = dt.Rows[0]["bs_currency"].ToString(); }
				catch { DDL_CURRENCY.SelectedValue = "IDR"; }
				DDL_CURRENCY.Enabled = false;
				try { DDL_DENOMINATOR.SelectedValue = dt.Rows[0]["bs_denominator"].ToString(); }
				catch { DDL_DENOMINATOR.SelectedValue = "000"; }
				DDL_DENOMINATOR.Enabled = false;
				BTN_CEK.Enabled = false;
				PnlNeraca.Visible = true;
			}

			//----------------------------------------------
			//added by nyoman for current scoring condition 
			conn.QueryString = "select FI_APPROVAL_VER from  VW_CA_NERACA_MIDDLE_FI_APPROVAL_VER " +
				"where AP_REGNO = '14072008COR1000001' ";
			conn.ExecuteQuery();
			try
			{
				if (conn.GetFieldValue(0,0) == "2")
				{
					DDL_CURRENCY.SelectedValue = "IDR";
					DDL_DENOMINATOR.SelectedValue = "000";
					DDL_CURRENCY.Enabled = false;
					DDL_DENOMINATOR.Enabled = false;
					BTN_CEK.Enabled = false;
					PnlNeraca.Visible = true;
				}
			}
			catch {}
			//----------------------------------------------
		}

		private void clear_field()
		{
			LBL_H_TAHUN.Text = "";

			int cnt;
				
			conn.QueryString = "select CU_REF,AP_REGNO,BS_DATE_PERIODE,BS_NUM_MONTH,BS_REPORTTYPE,BS_SALES_ONCR,BS_CASH_BANK,BS_MARKET_SECUR" +
				",BS_AR,BS_AR_FRAFFIL,BS_INVENTORY,BS_OTH_CURASST,BS_PREPAID_EXP,BS_CURRASST,BS_NETFIXASST" +
				",BS_INVESTMENT,BS_NONCA,BS_NI,BS_TTL_NONCA,BS_TTL_ASST,BS_DBST,BS_AP,BS_AP_TOAFFL,BS_ACCRUALS" +
				",BS_TAXPAY,BS_OTH_CURLIAB,BS_CURR_PORTLTDEBT,BS_CURR_LIAB,BS_LONGTERM_DEBT,BS_OTH_LIAB,BS_LONGTERM_LIAB" +
				",BS_TTL_LIAB,BS_CMN_STK,BS_SURP_RESRV,BS_RET_EARN,BS_TTL_NETWORTH,BS_LIAB_NETWORTH,BS_CURRENCY" +
				",BS_DENOMINATOR,BS_SUMBERDATA,BS_ISPROYEKSI from ca_neraca_middle where ap_regno = '" + Request.QueryString["regno"] + "' order by bs_date_periode desc";
			conn.ExecuteQuery();
			cnt = conn.GetRowCount();

			conn.QueryString="select excel_field from ca_excel where excel_file = 'kmk_ki_middle' and excel_type = 'bs'";
			conn.ExecuteQuery();
				
			int row = 70;
			//for (int i = 0; i < cnt; i++)
			//TO DO :
			for (int i = 0; i < 4; i++)
			{
				row--;
				string vtmp = ((char)row).ToString();
				
				//for (int m=1;m<=conn.GetRowCount();m++)
				for (int m=2;m<=35;m++)
				{
					if (m==3)
					{
						System.Web.UI.WebControls.DropDownList DDL_ = (System.Web.UI.WebControls.DropDownList) this.Page.FindControl("DDL_" + vtmp + m.ToString());
						DDL_.SelectedValue = "-";
					}
					else
					{
						System.Web.UI.WebControls.TextBox txt = (System.Web.UI.WebControls.TextBox) Page.FindControl("TXT_" + vtmp + m.ToString());
						txt.Text = "";
					}
				}
				
				if(row<=66)
				{
					break;}
			}
			tgl_default();
		}

		private void retrieve_data_neraca()
		{
			LBL_H_TAHUN.Text = Request.QueryString["tahun"];

			int row;
			tgl_default();
			
			conn.QueryString = "select bs_isproyeksi from ca_neraca_middle where ap_regno = '" + Request.QueryString["regno"] + "' and year(bs_date_periode) = '" + Request.QueryString["tahun"] + "'";
			conn.ExecuteQuery();
			if (conn.GetFieldValue("bs_isproyeksi")=="1")
				row = 70;
			else
				row = 69;
			
			int jmlrow;
			conn.QueryString = "select excel_field from ca_excel where excel_file = 'kmk_ki_middle' and excel_type = 'bs'";
			conn.ExecuteQuery();
			jmlrow = conn.GetRowCount();

			conn.QueryString = "select top 4 CU_REF,AP_REGNO,BS_DATE_PERIODE,BS_NUM_MONTH,BS_REPORTTYPE,BS_SALES_ONCR,BS_CASH_BANK,BS_MARKET_SECUR" +
				",BS_AR,BS_AR_FRAFFIL,BS_INVENTORY,BS_OTH_CURASST,BS_PREPAID_EXP,BS_CURRASST,BS_NETFIXASST" +
				",BS_INVESTMENT,BS_NONCA,BS_NI,BS_TTL_NONCA,BS_TTL_ASST,BS_DBST,BS_AP,BS_AP_TOAFFL,BS_ACCRUALS" +
				",BS_TAXPAY,BS_OTH_CURLIAB,BS_CURR_PORTLTDEBT,BS_CURR_LIAB,BS_LONGTERM_DEBT,BS_OTH_LIAB,BS_LONGTERM_LIAB" +
				",BS_TTL_LIAB,BS_CMN_STK,BS_SURP_RESRV,BS_RET_EARN,BS_TTL_NETWORTH,BS_LIAB_NETWORTH,BS_CURRENCY" +
				",BS_DENOMINATOR,BS_SUMBERDATA,BS_ISPROYEKSI from ca_neraca_middle where year(bs_date_periode) <= '" + Request.QueryString["tahun"] + "' and ap_regno = '" + Request.QueryString["regno"]+ "' order by bs_date_periode desc";
			conn.ExecuteQuery();

			
			for (int i = 0; i < conn.GetRowCount(); i++)
			{
				
				row--;
				string vtmp = ((char)row).ToString();
				int k = 6;
				
				int xx=1;
				for (int m=1;m<5;m++)
				{
					xx++;
					System.Web.UI.WebControls.TextBox txt = (System.Web.UI.WebControls.TextBox) Page.FindControl("TXT_" + vtmp + m.ToString());
					if (Request.QueryString["mode"] == "retrieve")
					{
						if (m!=1)
						{
							if (m==3)
							{
								for (int p=3;p<4;p++)
								{
									System.Web.UI.WebControls.DropDownList DDL_ = (System.Web.UI.WebControls.DropDownList) this.Page.FindControl("DDL_" + vtmp + p.ToString());
									try
									{
										txt.ReadOnly = true;
										txt.Text = conn.GetFieldValue(i, xx);
									}
									catch(Exception ex)
									{
										string errorMessage = ex.Message.ToString();
										string ghgh = txt.ID;
										string a = conn.GetFieldValue(i, xx);
										string ghgh2 = txt.ID;
									}
									try 
									{
										DDL_.Enabled = false;
										DDL_.SelectedValue = txt.Text;
									}
									catch
									{
										DDL_.SelectedValue = "-";
									}
								}
							}
							else 
							{
								try
								{
									txt.ReadOnly = true;
									txt.Text = conn.GetFieldValue(i,xx);
								}
								catch
								{
									txt.ReadOnly = true;
									txt.Text = "0";
								}
							}
						} 
						else 
						{
							for (int n=1;n<2;n++)
							{
								System.Web.UI.WebControls.TextBox TXT_TGL_ = (System.Web.UI.WebControls.TextBox) this.Page.FindControl("TXT_TGL_" + vtmp + n.ToString());
								System.Web.UI.WebControls.DropDownList DDL_BLN_ = (System.Web.UI.WebControls.DropDownList) this.Page.FindControl("DDL_BLN_" + vtmp + n.ToString());
								System.Web.UI.WebControls.TextBox TXT_YEAR_ = (System.Web.UI.WebControls.TextBox) this.Page.FindControl("TXT_YEAR_" + vtmp + n.ToString());
								
								TXT_TGL_.ReadOnly = true;
								DDL_BLN_.Enabled = false;
								TXT_YEAR_.ReadOnly = true;

								DateTime excdatestr = Convert.ToDateTime(tool.FormatDate(conn.GetFieldValue(i, xx)));
								try
								{
									TXT_TGL_.Text = "";
									DDL_BLN_.SelectedValue = "";
									TXT_YEAR_.Text = "";
									GlobalTools.fillDateForm(TXT_TGL_, DDL_BLN_, TXT_YEAR_, excdatestr);
								}
								catch
								{
									//									TXT_TGL_.Text = "";
									//									DDL_BLN_.SelectedValue = "";
									//									TXT_YEAR_.Text = "";
								}

							}
						}			
					} 
					else 
					{
						txt.ReadOnly = true;
						txt.Text = "";
					}
				}
	
				
				for (int j = 5; j <= jmlrow; j++)
				{	
					System.Web.UI.WebControls.TextBox txt = (System.Web.UI.WebControls.TextBox) Page.FindControl("TXT_" + vtmp + j.ToString());
					if (Request.QueryString["mode"] == "retrieve")
					{
						try
						{
							txt.ReadOnly = true;
							txt.Text = myMoneyFormat_noDec(conn.GetFieldValue(i, k));
						}
						catch
						{
							txt.ReadOnly = true;
							txt.Text = "";
						}
					}
					else 
					{
						txt.ReadOnly = true;
						txt.Text = "";
					}
					k++;
				}

			}
			
		}

		private string myMoneyFormat_noDec(string str)
		{
			if ((str.Trim() == "") || (str.Trim() == "&nbsp;")) 
			{
				return Strings.FormatNumber(0, 0, TriState.UseDefault, TriState.UseDefault, TriState.UseDefault);
			} 
			else 
			{
				return Strings.FormatNumber(str, 0, TriState.UseDefault, TriState.UseDefault, TriState.UseDefault);
			}
		}

		private void retrieve_HistoryData(string regno, string tahun)
		{
			LBL_H_TAHUN.Text = tahun;

			int row;
			tgl_default();
			
			conn.QueryString = "select bs_isproyeksi from ca_neraca_middle where ap_regno = '" + 
				regno + "' and year(bs_date_periode) = '" + tahun + "'";
			conn.ExecuteQuery();
			if (conn.GetFieldValue("bs_isproyeksi")=="1")
				row = 70;
			else
				row = 69;
			
			int jmlrow;
			conn.QueryString = "select excel_field from ca_excel where excel_file = 'kmk_ki_middle' and excel_type = 'bs'";
			conn.ExecuteQuery();
			jmlrow = conn.GetRowCount();

			conn.QueryString = "select top 4 CU_REF,AP_REGNO,BS_DATE_PERIODE,BS_NUM_MONTH,BS_REPORTTYPE,BS_SALES_ONCR,BS_CASH_BANK,BS_MARKET_SECUR" +
				",BS_AR,BS_AR_FRAFFIL,BS_INVENTORY,BS_OTH_CURASST,BS_PREPAID_EXP,BS_CURRASST,BS_NETFIXASST" +
				",BS_INVESTMENT,BS_NONCA,BS_NI,BS_TTL_NONCA,BS_TTL_ASST,BS_DBST,BS_AP,BS_AP_TOAFFL,BS_ACCRUALS" +
				",BS_TAXPAY,BS_OTH_CURLIAB,BS_CURR_PORTLTDEBT,BS_CURR_LIAB,BS_LONGTERM_DEBT,BS_OTH_LIAB,BS_LONGTERM_LIAB" +
				",BS_TTL_LIAB,BS_CMN_STK,BS_SURP_RESRV,BS_RET_EARN,BS_TTL_NETWORTH,BS_LIAB_NETWORTH,BS_CURRENCY" +
				",BS_DENOMINATOR,BS_SUMBERDATA,BS_ISPROYEKSI from ca_neraca_middle where year(bs_date_periode) <= '" + 
				tahun + "' and ap_regno = '" + regno + "' order by bs_date_periode desc";
			conn.ExecuteQuery();

			//row = 69;
			
			for (int i = 0; i < conn.GetRowCount(); i++)
			{
				
				row--;
				string vtmp = ((char)row).ToString();
				int k = 6;
				
				int xx=1;
				for (int m=1;m<5;m++)
				{
					xx++;
					System.Web.UI.WebControls.TextBox txt = (System.Web.UI.WebControls.TextBox) Page.FindControl("TXT_" + vtmp + m.ToString());
					if (m!=1)
					{
						if (m==3)
						{
							for (int p=3;p<4;p++)
							{
								System.Web.UI.WebControls.DropDownList DDL_ = (System.Web.UI.WebControls.DropDownList) this.Page.FindControl("DDL_" + vtmp + p.ToString());
								txt.Text = conn.GetFieldValue(i, xx);
								try 
								{
									DDL_.SelectedValue = txt.Text;
								}
								catch
								{
									DDL_.SelectedValue = "-";
								}
							}
						}
						else 
						{
							try
							{
								txt.Text = conn.GetFieldValue(i,xx);
							}
							catch
							{
								txt.Text = "0";
							}
						}
					} 
					else 
					{
						for (int n=1;n<2;n++)
						{
							System.Web.UI.WebControls.TextBox TXT_TGL_ = (System.Web.UI.WebControls.TextBox) this.Page.FindControl("TXT_TGL_" + vtmp + n.ToString());
							System.Web.UI.WebControls.DropDownList DDL_BLN_ = (System.Web.UI.WebControls.DropDownList) this.Page.FindControl("DDL_BLN_" + vtmp + n.ToString());
							System.Web.UI.WebControls.TextBox TXT_YEAR_ = (System.Web.UI.WebControls.TextBox) this.Page.FindControl("TXT_YEAR_" + vtmp + n.ToString());
								
							DateTime excdatestr = Convert.ToDateTime(tool.FormatDate(conn.GetFieldValue(i, xx)));
							try
							{
								TXT_TGL_.Text = "";
								DDL_BLN_.SelectedValue = "";
								TXT_YEAR_.Text = "";
								GlobalTools.fillDateForm(TXT_TGL_, DDL_BLN_, TXT_YEAR_, excdatestr);
							}
							catch
							{
								//									TXT_TGL_.Text = "";
								//									DDL_BLN_.SelectedValue = "";
								//									TXT_YEAR_.Text = "";
							}

						}
					}
				}
	
				
				for (int j = 5; j <= jmlrow; j++)
				{	
					System.Web.UI.WebControls.TextBox txt = (System.Web.UI.WebControls.TextBox) Page.FindControl("TXT_" + vtmp + j.ToString());
					try
					{
						txt.Text = myMoneyFormat_noDec(conn.GetFieldValue(i, k));
					}
					catch
					{
						txt.Text = "";
					}
					k++;
				}

			}
			
		}

		private void tgl_default()
		{
			GlobalTools.initDateForm(this.TXT_TGL_B1, this.DDL_BLN_B1, this.TXT_YEAR_B1, true);
			GlobalTools.initDateForm(this.TXT_TGL_C1, this.DDL_BLN_C1, this.TXT_YEAR_C1, true);
			GlobalTools.initDateForm(this.TXT_TGL_D1, this.DDL_BLN_D1, this.TXT_YEAR_D1, true);
			GlobalTools.initDateForm(this.TXT_TGL_E1, this.DDL_BLN_E1, this.TXT_YEAR_E1, true);
			try
			{ 
				//this.DDL_BLN_B1.SelectedValue = DateTime.Now.Month.ToString();
				this.DDL_BLN_B1.SelectedValue = "";
				this.DDL_BLN_C1.SelectedValue = "";
				this.DDL_BLN_D1.SelectedValue = "";
				this.DDL_BLN_E1.SelectedValue = "";
			}
			catch{}
		}
		private void viewdata_history()
		{
			//conn.QueryString = "select POSISI_TGL,JML_BLN,JNS_LAP,year(POSISI_TGL) tahun from CA_NERACA_SMALL where ap_regno = '"+ Request.QueryString["regno"]+ "' order by POSISI_TGL desc";
			//conn.QueryString = "select AP_REGNO,BS_DATE_PERIODE,BS_NUM_MONTH,BS_REPORTTYPE,TAHUN " +
			//	"from VW_CA_NERACA_MIDDLE_HISTORY where cu_ref = '" + Request.QueryString["curef"] + "' " +
			//	"and ap_regno <> '"+ Request.QueryString["regno"] + "' order by AP_REGNO, BS_DATE_PERIODE desc";
			conn.QueryString = "exec CA_NERACA_MIDDLE_HISTORY '" + Request.QueryString["curef"] + "', '" +
				Request.QueryString["regno"] + "' ";
			conn.ExecuteQuery();
			
			DG_NeracaHistory.DataSource = conn.GetDataTable().Copy();
			DG_NeracaHistory.DataBind();
			for(int i = 0; i < DG_NeracaHistory.Items.Count; i++)
			{
				DG_NeracaHistory.Items[i].Cells[1].Text = tool.FormatDate(DG_NeracaHistory.Items[i].Cells[1].Text);
			}
		}

		private void BindData(DataGrid theGrid, string strconn)
		{
			if(strconn != "")
			{
				conn.QueryString = strconn;
				conn.ExecuteQuery();
			}

			System.Data.DataTable dt = new System.Data.DataTable();
			dt = conn.GetDataTable().Copy();

			System.Web.UI.WebControls.DataGrid dg = theGrid;

			dg.DataSource = dt;				

			try
			{
				try
				{
					dg.DataBind();
				}
				catch 
				{
					dg.CurrentPageIndex = dg.PageCount - 1;
					dg.DataBind();
				}
			}
			catch (Exception c)
			{
				string ab = c.Message.ToString();
				string cd = c.Message.ToString();
			}
			
			if(!IsPostBack)
			{

			}
			conn.ClearData();
		}

		private void fillAllDDL()
		{
			//DDL_PRODUCT
			GlobalTools.fillRefList(DDL_PRODUCT, "SELECT ID_AP_VARIABLE, DESCRIPTION FROM AP_VARIABLE", conn);
		}

		private void ClearAllField()
		{
			//TXT_CIF.Text = "";
			DDL_PRODUCT.SelectedIndex = 0;
			TXT_PRIMARY_BANK.Text = "";
			TXT_OTHER_BANK.Text = "";

			//TXT_CIF_GROW_ANCHORS.Text = "";
			TXT_SEQ_GROW_ANCHORS.Text = "";
			TXT_KEY_SUPPORT_NEEDED.Text = "";
		}

		private void BindAllGrid()
		{
			RETRIEVE_BUSINESS_AND_STRATEGY(Request.QueryString["cif"]);

			BindData(DGR_SCENARIO, "SELECT AP_VARIABLE.DESCRIPTION as product,* FROM AP_COMPETITIVE_SCAN, AP_VARIABLE WHERE CU_CIF = '" + Request.QueryString["CIF"] + "' AND  AP_VARIABLE.ID_AP_VARIABLE = AP_COMPETITIVE_SCAN.ID_AP_VARIABLE");
			BindDGRScenario();

			BindData(StrategiesToGrowAnchors, "SELECT * FROM AP_STRATEGIES_TO_GROW_ANCHORS WHERE CU_CIF = '" + Request.QueryString["cif"] + "' ORDER BY SEQ ASC");
			BindSTRATEGIES_TO_GROW_ANCHORS();
		}

		private void ViewMenu()
		{
			Menu.Controls.Clear();
			try 
			{
				conn.QueryString = "SELECT * FROM SCREENMENU WHERE MENUCODE = '" + Request.QueryString["mc"] + "'";
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
							strtemp = "cif=" + Request.QueryString["cif"] + "&bs=" + Request.QueryString["bs"] + "&bc=" + Request.QueryString["bc"] + "&rd=" + Request.QueryString["rd"] + "&cd=" + Request.QueryString["cd"];
						else	
							strtemp = "&mc=" + Request.QueryString["mc"]+ "&cif=" + Request.QueryString["cif"] + "&bs=" + Request.QueryString["bs"] + "&bc=" + Request.QueryString["bc"] + "&rd=" + Request.QueryString["rd"] + "&cd=" + Request.QueryString["cd"];
					}
					else 
					{
						strtemp = ""; 
					}
					t.NavigateUrl = conn.GetFieldValue(i, 3)+strtemp;
					string asb = t.NavigateUrl;
					Menu.Controls.Add(t);
					Menu.Controls.Add(new LiteralControl("&nbsp;&nbsp;&nbsp;"));
				}
			} 
			catch (Exception ex) 
			{
				string temp2 = ex.Message.ToString();
				string temp = ex.ToString();
			}
		}

		private void DGR_SCENARIO_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			if(DGR_SCENARIO.CurrentPageIndex >= 0 && DGR_SCENARIO.CurrentPageIndex < DGR_SCENARIO.PageCount)
			{
				DGR_SCENARIO.CurrentPageIndex = e.NewPageIndex;
				BindData(DGR_SCENARIO, "SELECT AP_VARIABLE.DESCRIPTION as product,* FROM AP_COMPETITIVE_SCAN, AP_VARIABLE WHERE CU_CIF = '" + Request.QueryString["CIF"] + "' AND  AP_VARIABLE.ID_AP_VARIABLE = AP_COMPETITIVE_SCAN.ID_AP_VARIABLE");
			}
		}

		private void StrategiesToGrowAnchors_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			if(StrategiesToGrowAnchors.CurrentPageIndex >= 0 && StrategiesToGrowAnchors.CurrentPageIndex < StrategiesToGrowAnchors.PageCount)
			{
				StrategiesToGrowAnchors.CurrentPageIndex = e.NewPageIndex;
				BindData(StrategiesToGrowAnchors, "SELECT * FROM AP_STRATEGIES_TO_GROW_ANCHORS WHERE CU_CIF = '" + Request.QueryString["cif"] + "' ORDER BY SEQ ASC");
			}
		}

		private void BTN_UPLOAD_Click(object sender, System.EventArgs e)
		{
			string directory;
			int counter = 0;
			int max_id = 10000;
			string outputfilename = "";

			conn.QueryString = "EXEC AP_UPLOAD_DATA_SNAPSHOT '" + 
				Session["USERID"].ToString() + "', '" +
				Path.GetFileName(TXT_FILE_UPLOAD.PostedFile.FileName) + "'";
			conn.ExecuteQuery();

			conn.QueryString = "SELECT MAX(ID_UPLOAD_DATA_SNAPSHOT) as MAX_ID from [AP_FILE_UPLOAD_DATA_SNAPSHOT] where userid='" + Session["USERID"].ToString() + "'";
			conn.ExecuteQuery();

			if (conn.GetRowCount() > 0)
			{
				max_id = int.Parse(conn.GetFieldValue("MAX_ID"));
			}

			conn.QueryString = "SELECT FILE_UPLOAD_NAME from [AP_FILE_UPLOAD_DATA_SNAPSHOT] where ID_UPLOAD_DATA_SNAPSHOT = '" + max_id + "' and userid='" + Session["USERID"].ToString() + "'";
			conn.ExecuteQuery();

			if (conn.GetRowCount() > 0)
			{
				outputfilename = conn.GetFieldValue("FILE_UPLOAD_NAME");
				//TXT_XLSNAME.Text = outputfilename;
			}

			conn.QueryString = "SELECT EXPORT_URL FROM AP_SNAPSHOT_RFUPLOAD WHERE EXPORT_ID = 'SNAPSHOT01'";
			conn.ExecuteQuery();

			if (conn.GetRowCount() > 0)
			{
				directory = Server.MapPath(conn.GetFieldValue("EXPORT_URL").Trim());

				HttpFileCollection uploadedFiles = Request.Files;

				for (int i = 0; i < uploadedFiles.Count; i++)
				{
					HttpPostedFile userPostedFile = uploadedFiles[i];
					counter = i + 1;

					try
					{
						if (userPostedFile.ContentLength > 0)
						{
							userPostedFile.SaveAs(directory + outputfilename);

							LBL_STATUS.ForeColor = Color.Green;
							LBL_STATUSREPORT.ForeColor = Color.Green;
							LBL_STATUS.Text = "Upload Successful!";
							LBL_STATUSREPORT.Text = "<u>File #" + counter.ToString() + "</u><br>" + 
								"File Content Type: " + userPostedFile.ContentType + "<br>" + 
								"File Size: " + userPostedFile.ContentLength + " bytes<br>" + 
								"File Name: " + userPostedFile.FileName + "<br>" +
								"Location Where Saved: " + directory + outputfilename + "<p>";

							//View Upload File
							ViewUploadFiles();
						}
					}
					catch (Exception ex)
					{
						LBL_STATUS.ForeColor = Color.Red;
						LBL_STATUSREPORT.ForeColor = Color.Red;
						LBL_STATUS.Text = "Upload Failed!";
						LBL_STATUSREPORT.Text = ex.Message + "\n" + ex.StackTrace;
					}
				}
				try
				{
					//ReadExcel(directory + outputfilename);
				}
				catch {}
			}
			ViewUploadFiles();		
		}

		private void deleteFile(string directory, string filename) 
		{
			if (File.Exists(directory + filename)) 
			{
				File.Delete(directory + filename);
			}
		}

		private void ViewUploadFiles()
		{
			string url = "";
			conn.QueryString = "SELECT EXPORT_URL FROM AP_SNAPSHOT_RFUPLOAD WHERE EXPORT_ID = 'SNAPSHOT01'";
			conn.ExecuteQuery();

			if (conn.GetRowCount() > 0) 
			{
				url = conn.GetFieldValue("EXPORT_URL");
			}

			System.Data.DataTable dt = new System.Data.DataTable();
			conn.QueryString = "SELECT ID_UPLOAD_DATA_SNAPSHOT, FILE_UPLOAD_NAME FROM AP_FILE_UPLOAD_DATA_SNAPSHOT where userid='" + Session["USERID"].ToString() + "'";
			conn.ExecuteQuery();
			dt = conn.GetDataTable().Copy();
			DATA_UPLOAD.DataSource = dt;
			try 
			{
				DATA_UPLOAD.DataBind();
			} 
			catch 
			{
				DATA_UPLOAD.CurrentPageIndex = 0;
				DATA_UPLOAD.DataBind();
			}
			for (int i = 1; i <= DATA_UPLOAD.Items.Count; i++)
			{
				HyperLink HpDownload = (HyperLink) DATA_UPLOAD.Items[i-1].Cells[2].FindControl("FILE_DOWNLOAD");
				LinkButton HpDelete = (LinkButton) DATA_UPLOAD.Items[i-1].Cells[3].FindControl("FILE_DELETE");
				HpDownload.NavigateUrl = url + conn.GetFieldValue("FILE_UPLOAD_NAME");
			}
		}

		private void DATA_UPLOAD_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			string directory = "";
			conn.QueryString = "SELECT EXPORT_URL FROM AP_SNAPSHOT_RFUPLOAD WHERE EXPORT_ID = 'SNAPSHOT01'";
			conn.ExecuteQuery();
			if (conn.GetRowCount() > 0)
			{
				directory = Server.MapPath(conn.GetFieldValue("EXPORT_URL").Trim());
			}

			switch (((LinkButton)e.CommandSource).CommandName)
			{
				case "delete":
					conn.QueryString = "EXEC AP_DELETE_FILE_UPLOAD_SNAPSHOT '" + e.Item.Cells[0].Text + "', '" +
						Session["USERID"].ToString() + "', '" +
						e.Item.Cells[1].Text + "'";
					conn.ExecuteQuery();
					deleteFile(directory, e.Item.Cells[1].Text);
					ViewUploadFiles();
					break;
			}
		}

		private void DATA_UPLOAD_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			DATA_UPLOAD.CurrentPageIndex = e.NewPageIndex;
			ViewUploadFiles();
		}

		private void DB_LBRG1_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			string cmd = e.CommandName;
			
			switch (cmd)
			{		  
				case "retrieve" :										
					string vtemp = e.Item.Cells[3].Text;
					Response.Redirect("SnapShot.aspx?tahun=" + vtemp +"&mode=retrieve&regno='14072008COR1000001'"+
						"&mc="+Request.QueryString["mc"]+"&bussunitid="+
						Request.QueryString["bussunitid"]+"&programid="+Request.QueryString["programid"]+
						"&jnsnasabah="+Request.QueryString["jnsnasabah"]+"&curef="+Request.QueryString["curef"]+
						"&tc="+Request.QueryString["tc"]+"&viewmode="+Request.QueryString["viewmode"]+
						"&lmsreg="+Request.QueryString["lmsreg"]+"&scr="+Request.QueryString["scr"]);
					clear_field();
					retrieve_data_neraca();
					break;
				case "delete" :
					//Response.Redirect("IS_KMK_KI_Medium.aspx?tahun=" + tool.FormatDate_Year(e.Item.Cells[0].Text) +"&mode=delete&regno="+Request.QueryString["regno"]+"&mc="+Request.QueryString["mc"]+"&bussunitid="+Request.QueryString["bussunitid"]+"&programid="+Request.QueryString["programid"]+"&jnsnasabah="+Request.QueryString["jnsnasabah"]+"&curef="+Request.QueryString["curef"]);
					string vtempe = e.Item.Cells[3].Text;
					conn.QueryString = "exec CA_LABARUGI_MIDDLE_SP_DELETE '" + Request.QueryString["curef"]+ "','" + Request.QueryString["regno"]+ "'," +
						GlobalTools.ToSQLDate(e.Item.Cells[4].Text) + ",'" + e.Item.Cells[1].Text + "','" + e.Item.Cells[2].Text + "'";
					conn.ExecuteNonQuery();

					//delete ratio as well 
					/*CLS_CALCULATION.delete_ratio(Request.QueryString["regno"],conn);
					
					isi_initial();
					viewdata();
					clear_field();*/
					break;
				default :
					break;
			}
		}
	}
}
