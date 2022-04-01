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


namespace SME.MAS.SupervisionManagement.MicroCreditQuality.Acceptance
{
	/// <summary>
	/// Summary description for PrintReviewUnitAccept.
	/// </summary>
	public partial class PrintReviewUnitAccept : System.Web.UI.Page
	{
		protected Connection conn = new Connection(ConfigurationSettings.AppSettings["conn"]);
		protected Tools tool = new Tools();
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			if(!IsPostBack)
			{
				conn.QueryString = "select * from VW_MAS_UNIT_REVIEW where unit_seq#='"+Request.QueryString["seq_unit"]+"' ";
				conn.ExecuteQuery();
				TXT_DISTRICT.Text = conn.GetFieldValue("distrik_code");
				TXT_CLUSTER.Text = conn.GetFieldValue("cluster_code");
				TXT_UNIT_CABANG.Text = conn.GetFieldValue("unit");
				TXT_THN_PEMBUKAAN.Text = conn.GetFieldValue("tahun_pembukaan");
				TXT_JUM_SO.Text = conn.GetFieldValue("jumlah_so");

				ddlBulan();				
				
				ViewDataUnitReview();
				ViewGridPegawaiUnit();
				ViewPortfolioMKS();
				ViewPortfolioUnit();
				ViewKualitasMMM();
				ViewPerson();
			}
		}

		private void ViewPerson()
		{
			string su_upliner1, su_upliner2;
			conn.QueryString = "select * from scuser where userid = '"+ Session["UserID"].ToString() +"'";
			conn.ExecuteQuery();
			TXT_DIBUAT_OLEH.Text = conn.GetFieldValue("su_fullname");
			su_upliner1 = conn.GetFieldValue("su_upliner");

			conn.QueryString = "select * from scuser where userid = '"+ su_upliner1 +"'";
			conn.ExecuteQuery();
			TXT_DIKETAHUI_OLEH1.Text = conn.GetFieldValue("su_fullname");
			su_upliner2 = conn.GetFieldValue("su_upliner");

			conn.QueryString = "select * from scuser where userid = '"+ su_upliner2 +"'";
			conn.ExecuteQuery();
			TXT_DIKETAHUI_OLEH2.Text = conn.GetFieldValue("su_fullname");
		}		

		private void ddlBulan()
		{			
			DDL_BLN_KUNJUNGAN1.Items.Add(new ListItem("--Pilih--",""));
			DDL_BLN_KUNJUNGAN2.Items.Add(new ListItem("--Pilih--",""));
				
			for(int i=1; i<=12; i++)
			{				
				DDL_BLN_KUNJUNGAN1.Items.Add(new ListItem(DateAndTime.MonthName(i, false), i.ToString()));
				DDL_BLN_KUNJUNGAN2.Items.Add(new ListItem(DateAndTime.MonthName(i, false), i.ToString()));
			}
		}

		private void ViewGridPegawaiUnit()
		{
			conn.QueryString = "select * from MAS_CQA_UNIT_REVIEW_PEGAWAI_UNIT where unit_seq='"+Request.QueryString["seq_unit"]+"' ";
			conn.ExecuteQuery();
			FillGridPegawaiUnit();
		}

		private void FillGridPegawaiUnit()
		{
			DataTable dt = new DataTable();
			dt = conn.GetDataTable().Copy();
			DGR_PEGAWAI.DataSource = dt;
			try 
			{
				DGR_PEGAWAI.DataBind();
			} 
			catch 
			{
				DGR_PEGAWAI.CurrentPageIndex = 0;
				DGR_PEGAWAI.DataBind();
			}
	
			for (int i = 0; i < DGR_PEGAWAI.Items.Count; i++)
			{
				DGR_PEGAWAI.Items[i].Cells[4].Text = tool.FormatDate(DGR_PEGAWAI.Items[i].Cells[5].Text, true);
			}
		}

		private void ViewPortfolioMKS()
		{
			conn.QueryString = "select * from MAS_CQA_UNIT_REVIEW_MKS where unit_seq='"+Request.QueryString["seq_unit"]+"' ";
			conn.ExecuteQuery();
			FillGridPortfolioMKS();
		}

		private void FillGridPortfolioMKS()
		{
			DataTable dt = new DataTable();
			dt = conn.GetDataTable().Copy();
			DGR_MKS.DataSource = dt;
			try 
			{
				DGR_MKS.DataBind();
			} 
			catch 
			{
				DGR_MKS.CurrentPageIndex = 0;
				DGR_MKS.DataBind();
			}
	
			for (int i = 0; i < DGR_MKS.Items.Count; i++)
			{
				DGR_MKS.Items[i].Cells[4].Text = tool.FormatDate(DGR_MKS.Items[i].Cells[4].Text, true);
			}
		}

		private void ViewPortfolioUnit()
		{
			conn.QueryString = "select * from MAS_CQA_UNIT_REVIEW_PORTFOLIO_UNIT where unit_seq='"+Request.QueryString["seq_unit"]+"' ";
			conn.ExecuteQuery();
			FillGridPortfolioUnit();
		}

		private void FillGridPortfolioUnit()
		{
			DataTable dt = new DataTable();
			dt = conn.GetDataTable().Copy();
			DGR_POTFOLIO_UNIT.DataSource = dt;
			try 
			{
				DGR_POTFOLIO_UNIT.DataBind();
			} 
			catch 
			{
				DGR_POTFOLIO_UNIT.CurrentPageIndex = 0;
				DGR_POTFOLIO_UNIT.DataBind();
			}			
		}

		private void ViewDataUnitReview()
		{
			conn.QueryString = "select * from mas_unit_review where unit_seq = '"+ Request.QueryString["seq_unit"] +"'";
			conn.ExecuteQuery();
			TXT_TGL_KUNJUNGAN1.Text = tool.FormatDate_Day(conn.GetFieldValue("periode_start"));
			try{DDL_BLN_KUNJUNGAN1.SelectedValue = tool.FormatDate_Month(conn.GetFieldValue("periode_start"));}
			catch{DDL_BLN_KUNJUNGAN1.SelectedValue = "";}
			TXT_THN_KUNJUNGAN1.Text = tool.FormatDate_Year(conn.GetFieldValue("periode_start"));
			TXT_TGL_KUNJUNGAN2.Text = tool.FormatDate_Day(conn.GetFieldValue("periode_end"));
			try{DDL_BLN_KUNJUNGAN2.SelectedValue = tool.FormatDate_Month(conn.GetFieldValue("periode_end"));}
			catch{DDL_BLN_KUNJUNGAN2.SelectedValue = "";}
			TXT_THN_KUNJUNGAN2.Text = tool.FormatDate_Year(conn.GetFieldValue("periode_end"));
			TXT_NAMA_SO1.Text = conn.GetFieldValue("nama_so1");
			TXT_NAMA_SO2.Text = conn.GetFieldValue("nama_so2");
			TXT_NAMA_SO3.Text = conn.GetFieldValue("nama_so3");
			TXT_NAMA_SO4.Text = conn.GetFieldValue("nama_so4");
			try{RDO_LOKASI_SO1.SelectedValue = conn.GetFieldValue("lokasi_so1");}
			catch{RDO_LOKASI_SO1.SelectedValue = null;}
			try{RDO_LOKASI_SO2.SelectedValue = conn.GetFieldValue("lokasi_so2");}
			catch{RDO_LOKASI_SO2.SelectedValue = null;}
			try{RDO_LOKASI_SO3.SelectedValue = conn.GetFieldValue("lokasi_so3");}
			catch{RDO_LOKASI_SO3.SelectedValue = null;}
			try{RDO_LOKASI_SO4.SelectedValue = conn.GetFieldValue("lokasi_so4");}
			catch{RDO_LOKASI_SO4.SelectedValue = null;}
			TXT_DIBUAT_OLEH.Text = conn.GetFieldValue("cqo_name");
			TXT_DIKETAHUI_OLEH1.Text = conn.GetFieldValue("acceptance_by1");
			TXT_DIKETAHUI_OLEH2.Text = conn.GetFieldValue("acceptance_by2");
		}

		private void ViewKualitasMMM()
		{
			conn.QueryString = "select * from MAS_KUALITAS_MMM where unit_seq = '"+ Request.QueryString["seq_unit"] +"'";
			conn.ExecuteQuery();
			try{RDO_MMM1.SelectedValue = conn.GetFieldValue("buku_mks");}
			catch{RDO_MMM1.SelectedValue = null;}
			try{RDO_MMM2.SelectedValue = conn.GetFieldValue("mmm_monit");}
			catch{RDO_MMM2.SelectedValue = null;}
			try{RDO_MMM3.SelectedValue = conn.GetFieldValue("buku_agunan");}
			catch{RDO_MMM3.SelectedValue = null;}
			try{RDO_MMM4.SelectedValue = conn.GetFieldValue("buku_notaris");}
			catch{RDO_MMM4.SelectedValue = null;}
			try{RDO_MMM5.SelectedValue = conn.GetFieldValue("buku_insurance");}
			catch{RDO_MMM5.SelectedValue = null;}
			try{RDO_MMM6.SelectedValue = conn.GetFieldValue("buku_kredit");}
			catch{RDO_MMM6.SelectedValue = null;}
			TXT_PERMASALAHAN1.Text = conn.GetFieldValue("kredit_menyimpang");
			TXT_PERMASALAHAN2.Text = conn.GetFieldValue("info_lain");
			TXT_PERMASALAHAN3.Text = conn.GetFieldValue("rekomendasi");
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
	}
}
