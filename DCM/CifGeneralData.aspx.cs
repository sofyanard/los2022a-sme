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
using System.Configuration;

namespace SME.DCM
{
	/// <summary>
	/// Summary description for CifGeneralData.
	/// </summary>
	public partial class CifGeneralData : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.TextBox TXT_AREA;
		protected System.Web.UI.WebControls.TextBox TXT_UNIT;
		protected System.Web.UI.WebControls.DropDownList DDL_STATUS ;
		protected Connection conn2 = new Connection(ConfigurationSettings.AppSettings["conn2"]);
		protected Connection conn = new Connection(ConfigurationSettings.AppSettings["conn"]);
		protected Tools tool = new Tools();
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			if(!IsPostBack)
			{
				DDL_BLN_APP.Items.Add(new ListItem ("--Pilih--", ""));
				DDL_BLN_APT.Items.Add(new ListItem("Pilih--", ""));
				DDL_BLN_PEMERINGKAT.Items.Add(new ListItem("--Pilih--", ""));
				DDL_BLN_PERUSAHAAN.Items.Add(new ListItem("--Pilih--",""));
				DDL_BU.Items.Add(new ListItem("--Pilih--",""));
				DDL_BUC.Items.Add(new ListItem("--Pilih--",""));
				DDL_GOL_NASABAH.Items.Add(new ListItem("--Pilih--",""));
				DDL_HUB_DGN_BANK.Items.Add(new ListItem("--Pilih--",""));
				DDL_ID_UTAMA.Items.Add(new ListItem("--Pilih--",""));
				DDL_JABATAN_NASABAH.Items.Add(new ListItem("--Pilih--",""));
				DDL_JENIS_DEBITUR.Items.Add(new ListItem("--Pilih--",""));
				DDL_JENIS_KELAMIN.Items.Add(new ListItem("--Pilih--",""));
				DDL_KEWARGANEGARAAN.Items.Add(new ListItem("--Pilih--",""));
				DDL_LEMBAGA_PEMERINGKAT.Items.Add(new ListItem("--Pilih--",""));
				DDL_LOKASI_DATI.Items.Add(new ListItem("--Pilih--",""));
				DDL_NAMA_PREFIK.Items.Add(new ListItem("--Pilih--",""));
				DDL_PEKERJAAN_NASABAH.Items.Add(new ListItem("--Pilih--",""));
				DDL_PERINGKAT_PERUSAHAAN.Items.Add(new ListItem("--Pilih--",""));
				DDL_PIC_DATA_OWNER.Items.Add(new ListItem("--Pilih--",""));
				DDL_STATUS_PERKAWINAN.Items.Add(new ListItem("--Pilih--",""));
				DDL_VALUTA.Items.Add(new ListItem("--Pilih--",""));
				DDL_BU_NASABAH.Items.Add(new ListItem("--Pilih--",""));

				for (int i=1; i<=12; i++)
				{
					DDL_BLN_APP.Items.Add(new ListItem(DateAndTime.MonthName(i, false), i.ToString()));
					DDL_BLN_APT.Items.Add(new ListItem(DateAndTime.MonthName(i, false), i.ToString()));
					DDL_BLN_PEMERINGKAT.Items.Add(new ListItem(DateAndTime.MonthName(i, false), i.ToString()));
					DDL_BLN_PERUSAHAAN.Items.Add(new ListItem(DateAndTime.MonthName(i, false), i.ToString()));
				}

				conn2.QueryString = "select * from VW_DCM_CIF_DDL_BU";
				conn2.ExecuteQuery();
				for (int i=0; i<conn2.GetRowCount(); i++)
					DDL_BU.Items.Add(new ListItem(conn2.GetFieldValue(i,1), conn2.GetFieldValue(i,0)));

				conn2.QueryString = "select * from VW_DCM_CIF_DDL_BUC";
				conn2.ExecuteQuery();
				for (int i=0; i<conn2.GetRowCount(); i++)
					DDL_BUC.Items.Add(new ListItem(conn2.GetFieldValue(i,1), conn2.GetFieldValue(i,0)));

				conn2.QueryString = "select * from VW_DCM_CIF_DDL_GOLNASABAH";
				conn2.ExecuteQuery();
				for (int i=0; i<conn2.GetRowCount(); i++)
					DDL_GOL_NASABAH.Items.Add(new ListItem(conn2.GetFieldValue(i,1), conn2.GetFieldValue(i,0)));

				conn2.QueryString = "select * from VW_DCM_CIF_DDL_HUBDENGANBANK order by convert(int, hubexec_code)";
				conn2.ExecuteQuery();
				for (int i=0; i<conn2.GetRowCount(); i++)
					DDL_HUB_DGN_BANK.Items.Add(new ListItem(conn2.GetFieldValue(i,1), conn2.GetFieldValue(i,0)));

				conn2.QueryString = "select * from VW_DCM_CIF_DDL_JENISID";
				conn2.ExecuteQuery();
				for (int i=0; i<conn2.GetRowCount(); i++)
					DDL_ID_UTAMA.Items.Add(new ListItem(conn2.GetFieldValue(i,1), conn2.GetFieldValue(i,0)));

				conn2.QueryString = "select * from VW_DCM_CIF_DDL_JABATANNASABAH";
				conn2.ExecuteQuery();
				for (int i=0; i<conn2.GetRowCount(); i++)
					DDL_JABATAN_NASABAH.Items.Add(new ListItem(conn2.GetFieldValue(i,1), conn2.GetFieldValue(i,0)));

				conn2.QueryString = "select * from VW_DCM_CIF_DDL_JENISDEBITUR";
				conn2.ExecuteQuery();
				for (int i=0; i<conn2.GetRowCount(); i++)
					DDL_JENIS_DEBITUR.Items.Add(new ListItem(conn2.GetFieldValue(i,1), conn2.GetFieldValue(i,0)));

				conn2.QueryString = "select * from VW_DCM_CIF_DDL_JENISKELAMIN";
				conn2.ExecuteQuery();
				for (int i=0; i<conn2.GetRowCount(); i++)
					DDL_JENIS_KELAMIN.Items.Add(new ListItem(conn2.GetFieldValue(i,1), conn2.GetFieldValue(i,0)));

				conn2.QueryString = "select * from VW_DCM_CIF_DDL_KEWARGANEGARAAN";
				conn2.ExecuteQuery();
				for (int i=0; i<conn2.GetRowCount(); i++)
					DDL_KEWARGANEGARAAN.Items.Add(new ListItem(conn2.GetFieldValue(i,1), conn2.GetFieldValue(i,0)));

				conn2.QueryString = "select * from VW_DCM_CIF_DDL_LEMBAGAPEMERINGKAT";
				conn2.ExecuteQuery();
				for (int i=0; i<conn2.GetRowCount(); i++)
					DDL_LEMBAGA_PEMERINGKAT.Items.Add(new ListItem(conn2.GetFieldValue(i,1), conn2.GetFieldValue(i,0)));

				conn2.QueryString = "select * from VW_DCM_CIF_DDL_LOKASIDATI order by convert(int, locationid)";
				conn2.ExecuteQuery();
				for (int i=0; i<conn2.GetRowCount(); i++)
					DDL_LOKASI_DATI.Items.Add(new ListItem(conn2.GetFieldValue(i,1), conn2.GetFieldValue(i,0)));

				conn2.QueryString = "select * from VW_DCM_CIF_DDL_NAMAPREFIK";
				conn2.ExecuteQuery();
				for (int i=0; i<conn2.GetRowCount(); i++)
					DDL_NAMA_PREFIK.Items.Add(new ListItem(conn2.GetFieldValue(i,1), conn2.GetFieldValue(i,0)));

				conn2.QueryString = "select * from VW_DCM_CIF_DDL_PEKERJAANNASABAH";
				conn2.ExecuteQuery();
				for (int i=0; i<conn2.GetRowCount(); i++)
					DDL_PEKERJAAN_NASABAH.Items.Add(new ListItem(conn2.GetFieldValue(i,1), conn2.GetFieldValue(i,0)));

				conn2.QueryString = "select * from VW_DCM_CIF_DDL_PERINGKATPERUSAHAAN";
				conn2.ExecuteQuery();
				for (int i=0; i<conn2.GetRowCount(); i++)
					DDL_PERINGKAT_PERUSAHAAN.Items.Add(new ListItem(conn2.GetFieldValue(i,1), conn2.GetFieldValue(i,0)));

				conn2.QueryString = "select * from VW_DCM_CIF_DDL_PICDATAOWNER";
				conn2.ExecuteQuery();
				for (int i=0; i<conn2.GetRowCount(); i++)
					DDL_PIC_DATA_OWNER.Items.Add(new ListItem(conn2.GetFieldValue(i,1), conn2.GetFieldValue(i,0)));

				conn2.QueryString = "select * from VW_DCM_CIF_DDL_STATUSPERKAWINAN";
				conn2.ExecuteQuery();
				for (int i=0; i<conn2.GetRowCount(); i++)
					DDL_STATUS_PERKAWINAN.Items.Add(new ListItem(conn2.GetFieldValue(i,1), conn2.GetFieldValue(i,0)));

				conn2.QueryString = "select * from VW_DCM_CIF_DDL_VALUTA";
				conn2.ExecuteQuery();
				for (int i=0; i<conn2.GetRowCount(); i++)
					DDL_VALUTA.Items.Add(new ListItem(conn2.GetFieldValue(i,1), conn2.GetFieldValue(i,0)));

				conn2.QueryString = "select * from VW_DCM_CIF_DDL_BIDANGUSAHANASABAH";
				conn2.ExecuteQuery();
				for (int i=0; i<conn2.GetRowCount(); i++)
					DDL_BU_NASABAH.Items.Add(new ListItem(conn2.GetFieldValue(i,1), conn2.GetFieldValue(i,0)));

				conn.QueryString = "select custtypeid, custtypedesc from [LOSSME]..rfcustomertype where active='1'";
				conn.ExecuteQuery();
				for (int i = 0; i < conn.GetRowCount(); i++)
					RDO_JENIS_NASABAH.Items.Add(new ListItem(conn.GetFieldValue(i,1), conn.GetFieldValue(i,0)));

				RDO_JENIS_NASABAH.SelectedIndex=0;
			}
			ViewMenu();
			ViewData();
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

		private void ViewData()
		{
			conn2.QueryString = "select sname from vw_cif_list_data where cifno='" + Request.QueryString["cifno"] + "'";
			conn2.ExecuteQuery(10000);

			TXT_CIFNO.Text = Request.QueryString["cifno"];
			TXT_CUSTNAME.Text = conn2.GetFieldValue("sname");

			conn2.QueryString = "select * from ec_cif where ci_cif#='" + Request.QueryString["cifno"] + "'";
			conn2.ExecuteQuery(10000);

			if(conn2.GetRowCount() > 0)
			{
				try{RDO_JENIS_NASABAH.SelectedValue = conn2.GetFieldValue("CIF_CUST_TYPE");}
				catch{}
				try{DDL_BUC.SelectedValue = conn2.GetFieldValue("CIF_BUC");}
				catch{DDL_BUC.SelectedValue = "";}
				try{DDL_PIC_DATA_OWNER.SelectedValue = conn2.GetFieldValue("CIF_PIC_BRANCH");}
				catch{DDL_PIC_DATA_OWNER.SelectedValue = "";}
				TXT_NAMA_NASABAH_PELAPORAN.Text = conn2.GetFieldValue("CIF_REPORT_NAME");
				TXT_TGL_PERUSAHAAN.Text = tool.FormatDate_Day(conn2.GetFieldValue("CIF_BOD_ESTABLISH_DATE"));
				try{DDL_BLN_PERUSAHAAN.SelectedValue = tool.FormatDate_Month(conn2.GetFieldValue("CIF_BOD_ESTABLISH_DATE"));}
				catch{DDL_BLN_PERUSAHAAN.SelectedValue = "";}
				TXT_THN_PERUSAHAAN.Text = tool.FormatDate_Year(conn2.GetFieldValue("CIF_BOD_ESTABLISH_DATE"));
				TXT_TEMPAT_LAHIR.Text = conn2.GetFieldValue("CIF_PLACE_BOD_STABLISH");
				try{DDL_ID_UTAMA.SelectedValue = conn2.GetFieldValue("CIF_MAIN_ID_TYPE");}
				catch{DDL_ID_UTAMA.SelectedValue = "";}
				TXT_ID_UTAMA.Text = conn2.GetFieldValue("CIF_MAIN_ID#");
				try{DDL_GOL_NASABAH.SelectedValue = conn2.GetFieldValue("CIF_GOL_CUSTOMER");}
				catch{DDL_GOL_NASABAH.SelectedValue = "";}
				try{DDL_JENIS_DEBITUR.SelectedValue = conn2.GetFieldValue("CIF_DEBITUR_TYPE");}
				catch{DDL_JENIS_DEBITUR.SelectedValue = "";}
				TXT_GROUP_NASABAH.Text = conn2.GetFieldValue("CIF_CUST_GROUP");
				try{DDL_HUB_DGN_BANK.SelectedValue = conn2.GetFieldValue("CIF_HUBUNGAN");}
				catch{DDL_HUB_DGN_BANK.SelectedValue = "";}
				TXT_ADD_NASABAH.Text = conn2.GetFieldValue("CIF_ADDRESS_LINE1");
				TXT_KECAMATAN.Text = conn2.GetFieldValue("CIF_KECAMATAN");
				TXT_CU_COMPZIPCODE.Text = conn2.GetFieldValue("CIF_ZIP#");
				try{DDL_LOKASI_DATI.SelectedValue = conn2.GetFieldValue("CIF_DATI2");}
				catch{DDL_LOKASI_DATI.SelectedValue = "";}
				try{RDO_NO_TLP.SelectedValue = conn2.GetFieldValue("CIF_PHONE_TYPE");}
				catch{}
				if (conn2.GetFieldValue("CIF_PHONE_TYPE") == "HP")
					TXT_NO_TLP.Text = conn2.GetFieldValue("CIF_MOBILE_PH#");
				else if(conn2.GetFieldValue("CIF_PHONE_TYPE") == "TR")
					TXT_NO_TLP.Text = conn2.GetFieldValue("CIF_HOME_PH#");
				else if(conn2.GetFieldValue("CIF_PHONE_TYPE") == "TK")
					TXT_NO_TLP.Text = conn2.GetFieldValue("CIF_OFFICE_PH#");
				try{DDL_VALUTA.SelectedValue = conn2.GetFieldValue("CIF_CURRENCY");}
				catch{DDL_VALUTA.SelectedValue = "";}
				TXT_NO_APP.Text = conn2.GetFieldValue("CIF_APP#");
				TXT_TGL_APP.Text = tool.FormatDate_Day(conn2.GetFieldValue("CIF_APP_DATE"));
				try{DDL_BLN_APP.SelectedValue = tool.FormatDate_Month(conn2.GetFieldValue("CIF_APP_DATE"));}
				catch{DDL_BLN_APP.SelectedValue = "";}
				TXT_THN_APP.Text = tool.FormatDate_Year(conn2.GetFieldValue("CIF_APP_DATE"));
				TXT_NO_APT.Text = conn2.GetFieldValue("CIF_APT#");
				TXT_TGL_APT.Text = tool.FormatDate_Day(conn2.GetFieldValue("CIF_APT_DATE"));
				try{DDL_BLN_APT.SelectedValue = tool.FormatDate_Month(conn2.GetFieldValue("CIF_APT_DATE"));}
				catch{DDL_BLN_APT.SelectedValue = "";}
				TXT_THN_APT.Text = tool.FormatDate_Year(conn2.GetFieldValue("CIF_APT_DATE"));
				TXT_PENDAPATAN_OPERASIONAL.Text = conn2.GetFieldValue("CIF_PENDAPATAN_OPR");
				TXT_PENDAPATAN_NON_OPERASIONAL.Text = conn2.GetFieldValue("CIF_PEDAPATAN_NOPR");
				try{DDL_LEMBAGA_PEMERINGKAT.SelectedValue = conn2.GetFieldValue("CIF_RATING_COMP");}
				catch{DDL_LEMBAGA_PEMERINGKAT.SelectedValue = "";}
				try{DDL_PERINGKAT_PERUSAHAAN.SelectedValue = conn2.GetFieldValue("CIF_RATING_RESULT");}
				catch{DDL_PERINGKAT_PERUSAHAAN.SelectedValue = "";}
				TXT_TGL_PEMERINGKAT.Text = tool.FormatDate_Day(conn2.GetFieldValue("CIF_RATING_DATE"));
				try{DDL_BLN_PEMERINGKAT.SelectedValue = tool.FormatDate_Month(conn2.GetFieldValue("CIF_RATING_DATE"));}
				catch{DDL_BLN_PEMERINGKAT.SelectedValue = "";}
				TXT_THN_PEMERINGKAT.Text = tool.FormatDate_Year(conn2.GetFieldValue("CIF_RATING_DATE"));
				try{DDL_BU.SelectedValue = conn2.GetFieldValue("CIF_BUSINESS_TYPE");}
				catch{DDL_BU.SelectedValue = "";}
				try{DDL_JENIS_KELAMIN.SelectedValue = conn2.GetFieldValue("CIF_SEX_TYPE");}
				catch{DDL_JENIS_KELAMIN.SelectedValue = "";}
				TXT_NAMA_IBU.Text = conn2.GetFieldValue("CIF_MOTHER_NM");
				try{DDL_NAMA_PREFIK.SelectedValue = conn2.GetFieldValue("CIF_PREFIK_NAME");}
				catch{DDL_NAMA_PREFIK.SelectedValue = "";}
				TXT_NAMA_PERUSAHAAN.Text = conn2.GetFieldValue("CIF_CUST_COMP_NAME");
				try{DDL_BU_NASABAH.SelectedValue = conn2.GetFieldValue("CIF_BIDANG_USAHA");}
				catch{DDL_BU_NASABAH.SelectedValue = "";}
				try{DDL_JABATAN_NASABAH.SelectedValue = conn2.GetFieldValue("CIF_JOB_TITLE");}
				catch{DDL_JABATAN_NASABAH.SelectedValue = "";}
				try{DDL_PEKERJAAN_NASABAH.SelectedValue = conn2.GetFieldValue("CIF_CUST_OCCUPATION");}
				catch{DDL_PEKERJAAN_NASABAH.SelectedValue = "";}
				TXT_GAJI.Text = conn2.GetFieldValue("CIF_SALARY");
				TXT_PENDAPATAN_UTAMA.Text = conn2.GetFieldValue("CIF_MAIN_INCOME");
				TXT_PENDAPATAN_LAINNYA.Text = conn2.GetFieldValue("CIF_OTHER_INCOME");
				try{DDL_KEWARGANEGARAAN.SelectedValue = conn2.GetFieldValue("CIF_CITIZEN");}
				catch{DDL_KEWARGANEGARAAN.SelectedValue = "";}
				try{DDL_STATUS_PERKAWINAN.SelectedValue = conn2.GetFieldValue("CIF_MARITAL");}
				catch{DDL_STATUS_PERKAWINAN.SelectedValue = "";}
			}
			
			
			if(conn2.GetFieldValue("flag")=="1" || conn2.GetFieldValue("flag")=="2")
			{
				BTN_SAVE.Enabled = false;
				//TXT_AREA.ReadOnly = false;
				//TXT_UNIT.ReadOnly = false;
				BTN_SEARCHCOMP.Enabled = false;
				TXT_CU_COMPZIPCODE.Enabled = false;
				RDO_JENIS_NASABAH.Enabled = false;
				DDL_BUC.Enabled = false;
				DDL_PIC_DATA_OWNER.Enabled = false;
				TXT_NAMA_NASABAH_PELAPORAN.Enabled = false;
				TXT_TGL_PERUSAHAAN.Enabled = false;
				DDL_BLN_PERUSAHAAN.Enabled = false;
				TXT_THN_PERUSAHAAN.Enabled = false;
				TXT_TEMPAT_LAHIR.Enabled = false;
				DDL_ID_UTAMA.Enabled = false;
				TXT_ID_UTAMA.Enabled = false;
				DDL_GOL_NASABAH.Enabled = false;
				DDL_JENIS_DEBITUR.Enabled = false;
				TXT_GROUP_NASABAH.Enabled = false;
				DDL_HUB_DGN_BANK.Enabled = false;
				TXT_ADD_NASABAH.Enabled = false;
				TXT_KECAMATAN.Enabled = false;
				DDL_LOKASI_DATI.Enabled = false;
				RDO_NO_TLP.Enabled = false;
				DDL_VALUTA.Enabled = false;
				TXT_NO_APP.Enabled = false;
				TXT_TGL_APP.Enabled = false;
				DDL_BLN_APP.Enabled = false;
				TXT_THN_APP.Enabled = false;
				TXT_NO_APT.Enabled = false;
				TXT_TGL_APT.Enabled = false;
				DDL_BLN_APT.Enabled = false;
				TXT_PENDAPATAN_OPERASIONAL.Enabled = false;
				TXT_PENDAPATAN_NON_OPERASIONAL.Enabled = false;
				DDL_LEMBAGA_PEMERINGKAT.Enabled = false;
				DDL_PERINGKAT_PERUSAHAAN.Enabled = false;
				TXT_TGL_PEMERINGKAT.Enabled = false;
				DDL_BLN_PEMERINGKAT.Enabled = false;
				TXT_THN_PEMERINGKAT.Enabled = false;
				DDL_BU.Enabled = false;
				DDL_JENIS_KELAMIN.Enabled = false;
				TXT_NAMA_IBU.Enabled = false;
				DDL_NAMA_PREFIK.Enabled = false;
				TXT_NAMA_PERUSAHAAN.Enabled = false;
				DDL_JABATAN_NASABAH.Enabled = false;
				DDL_PEKERJAAN_NASABAH.Enabled = false;
				TXT_GAJI.Enabled = false;
				TXT_PENDAPATAN_UTAMA.Enabled = false;
				TXT_PENDAPATAN_LAINNYA.Enabled = false;
				BTN_CLEAR.Enabled = false;
				//BTN_BACK.Enabled = false;
				DDL_KEWARGANEGARAAN.Enabled = false;
				//DDL_STATUS.Enabled = false ;
				DDL_STATUS_PERKAWINAN.Enabled = false;
				TXT_THN_APT.Enabled = false;
				DDL_BU_NASABAH.Enabled = false;
				TXT_NO_TLP.Enabled = false;
				TXT_CIFNO.Enabled = false;
				TXT_CUSTNAME.Enabled = false;
			}
		}

		private void ViewMenu()
		{
			MenuCIF.Controls.Clear();
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
							strtemp = "cifno=" + Request.QueryString["cifno"];
						else	
							strtemp = "mc=" + Request.QueryString["mc"] + "&cifno=" + Request.QueryString["cifno"];
					}
					else 
					{
						strtemp = ""; 
					}
					t.NavigateUrl = conn.GetFieldValue(i, 3)+strtemp;
					MenuCIF.Controls.Add(t);
					MenuCIF.Controls.Add(new LiteralControl("&nbsp;&nbsp;&nbsp;"));
				}
			} 
			catch (Exception ex) 
			{
				string temp = ex.ToString();
			}
		}

		protected void BTN_SEARCHCOMP_Click(object sender, System.EventArgs e)
		{
			Response.Write("<script language='javascript'>window.open('SearchZipcode.aspx?targetFormID=Form1&targetObjectID=TXT_CU_COMPZIPCODE','SearchZipcode','status=no,scrollbars=no,width=420,height=200');</script>"); 
		}

		protected void BTN_SAVE_Click(object sender, System.EventArgs e)
		{
			try
			{
				conn2.QueryString = "EXEC DCM_CIF_GENERAL_DATA_INSERT '" + 
					Request.QueryString["cifno"] + "', '" +
					RDO_JENIS_NASABAH.SelectedValue + "', '" +
					DDL_BUC.SelectedValue + "', '" +
					DDL_PIC_DATA_OWNER.SelectedValue + "', '" +
					TXT_NAMA_NASABAH_PELAPORAN.Text + "', " +
					tool.ConvertDate(TXT_TGL_PERUSAHAAN.Text, DDL_BLN_PERUSAHAAN.SelectedValue, TXT_THN_PERUSAHAAN.Text) + ", '" +
					TXT_TEMPAT_LAHIR.Text + "', '" +
					DDL_ID_UTAMA.SelectedValue + "', '" +
					TXT_ID_UTAMA.Text + "', '" +
					DDL_GOL_NASABAH.SelectedValue + "', '" +
					DDL_HUB_DGN_BANK.SelectedValue + "', '" +
					TXT_ADD_NASABAH.Text + "', '" +
					TXT_KECAMATAN.Text + "', '" +
					TXT_CU_COMPZIPCODE.Text + "', '" +
					DDL_LOKASI_DATI.SelectedValue + "', '" +
					RDO_NO_TLP.SelectedValue + "', '" +
					TXT_NO_TLP.Text + "', '" +
					DDL_VALUTA.SelectedValue + "', '" +
					TXT_NO_APP.Text + "', " +
					tool.ConvertDate(TXT_TGL_APP.Text, DDL_BLN_APP.SelectedValue, TXT_THN_APP.Text) + ", '" +
					TXT_NO_APT.Text + "', " +
					tool.ConvertDate(TXT_TGL_APT.Text, DDL_BLN_APT.SelectedValue, TXT_THN_APT.Text) + ", " +
					tool.ConvertFloat(TXT_PENDAPATAN_OPERASIONAL.Text) + ", " +
					tool.ConvertFloat(TXT_PENDAPATAN_NON_OPERASIONAL.Text) + ", '" +
					DDL_LEMBAGA_PEMERINGKAT.SelectedValue + "', '" +
					DDL_PERINGKAT_PERUSAHAAN.SelectedValue + "', " +
					tool.ConvertDate(TXT_TGL_PEMERINGKAT.Text, DDL_BLN_PEMERINGKAT.SelectedValue, TXT_THN_PEMERINGKAT.Text) + ", '" +
					DDL_BU.SelectedValue + "', '" +
					DDL_JENIS_KELAMIN.SelectedValue + "', '" +
					TXT_NAMA_IBU.Text + "', '" +
					DDL_NAMA_PREFIK.SelectedValue + "', '" +
					TXT_NAMA_PERUSAHAAN.Text + "', '" +
					DDL_BU_NASABAH.SelectedValue + "', '" +
					DDL_JABATAN_NASABAH.SelectedValue + "', '" +
					DDL_PEKERJAAN_NASABAH.SelectedValue + "', " +
					tool.ConvertFloat(TXT_GAJI.Text) + ", " +
					tool.ConvertFloat(TXT_PENDAPATAN_LAINNYA.Text) + ", '" +
					DDL_KEWARGANEGARAAN.SelectedValue + "', '" +
					DDL_STATUS_PERKAWINAN.SelectedValue + "', '" +
					DDL_JENIS_DEBITUR.SelectedValue + "', '" +
					TXT_GROUP_NASABAH.Text + "', " + 
					tool.ConvertFloat(TXT_PENDAPATAN_UTAMA.Text) + ", '" +
					Session["UserID"].ToString() + "', '" +
					Session["FullName"].ToString() + "'";
				conn2.ExecuteQuery(10000);

				Tools.popMessage(this, "General data berhasil disimpan");
			}
			catch
			{
				Tools.popMessage(this, "General data gagal disimpan, silahkan ulangi kembali!");
			}
		}

		private void ClearData()
		{
			RDO_JENIS_NASABAH.SelectedIndex = 0;
			DDL_BUC.SelectedValue = "";
			DDL_PIC_DATA_OWNER.SelectedValue = "";
			TXT_NAMA_NASABAH_PELAPORAN.Text = "";
			TXT_TGL_PERUSAHAAN.Text = "";
			DDL_BLN_PERUSAHAAN.SelectedValue = "";
			TXT_THN_PERUSAHAAN.Text = "";
			TXT_TEMPAT_LAHIR.Text = "";
			DDL_ID_UTAMA.SelectedValue = "";
			TXT_ID_UTAMA.Text = "";
			DDL_GOL_NASABAH.SelectedValue = "";
			DDL_HUB_DGN_BANK.SelectedValue = "";
			TXT_ADD_NASABAH.Text = "";
			TXT_KECAMATAN.Text = "";
			TXT_CU_COMPZIPCODE.Text = "";
			DDL_LOKASI_DATI.SelectedValue = "";
			RDO_NO_TLP.SelectedIndex = 0;
			DDL_VALUTA.SelectedValue = "";
			TXT_NO_APP.Text = "";
			TXT_TGL_APP.Text = "";
			DDL_BLN_APP.SelectedValue = "";
			TXT_THN_APP.Text = "";
			TXT_NO_APT.Text = "";
			TXT_TGL_APT.Text = "";
			DDL_BLN_APT.SelectedValue = "";
			TXT_THN_APT.Text = "";
			TXT_PENDAPATAN_OPERASIONAL.Text = "";
			TXT_PENDAPATAN_NON_OPERASIONAL.Text = "";
			DDL_LEMBAGA_PEMERINGKAT.SelectedValue = "";
			DDL_PERINGKAT_PERUSAHAAN.SelectedValue = "";
			TXT_TGL_PEMERINGKAT.Text = "";
			DDL_BLN_PEMERINGKAT.SelectedValue = "";
			TXT_THN_PEMERINGKAT.Text = "";
			DDL_BU.SelectedValue = "";
			DDL_JENIS_KELAMIN.SelectedValue = "";
			TXT_NAMA_IBU.Text = "";
			DDL_NAMA_PREFIK.SelectedValue = "";
			TXT_NAMA_PERUSAHAAN.Text = "";
			DDL_BU_NASABAH.SelectedValue = "";
			DDL_JABATAN_NASABAH.SelectedValue = "";
			DDL_PEKERJAAN_NASABAH.SelectedValue = "";
			TXT_GAJI.Text = "";
			TXT_PENDAPATAN_LAINNYA.Text = "";
			DDL_KEWARGANEGARAAN.SelectedValue = "";
			DDL_STATUS_PERKAWINAN.SelectedValue = "";
			TXT_NO_TLP.Text = "";
			TXT_PENDAPATAN_UTAMA.Text = "";
			TXT_GROUP_NASABAH.Text = "";
			DDL_JENIS_DEBITUR.SelectedValue = "";
		}

		protected void BTN_CLEAR_Click(object sender, System.EventArgs e)
		{
			ClearData();
		}

		protected void BTN_BACK_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			string from_appr;
			from_appr = Request.QueryString["from_appr"];
			if (Request.QueryString["from_appr"] == "0")
				Response.Redirect("CifListData.aspx?tc=" + Request.QueryString["tc"] + "&mc=" + Request.QueryString["mc"] );
			else
				Response.Redirect("CifListDataApproval.aspx?tc=" + Request.QueryString["tc"] + "&mc=" + Request.QueryString["mc"] );
		}
	}
}
