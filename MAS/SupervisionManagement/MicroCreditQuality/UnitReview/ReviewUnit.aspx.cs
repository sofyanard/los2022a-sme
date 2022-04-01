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

namespace SME.MAS.SupervisionManagement.MicroCreditQuality.UnitReview
{
	/// <summary>
	/// Summary description for ReviewUnit.
	/// </summary>
	public partial class ReviewUnit : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.TextBox TextBox35;
		protected Tools tool = new Tools();
		protected Connection conn = new Connection(ConfigurationSettings.AppSettings["conn"]);
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			if(!IsPostBack)
			{
				conn.QueryString = "select * from VW_MAS_UNIT_REVIEW where pic_input= '"+ Session["UserID"].ToString() +"' and unit_seq#='"+Request.QueryString["seq_unit"]+"' ";
				conn.ExecuteQuery();
				TXT_DISTRICT.Text = conn.GetFieldValue("distrik_code");
				TXT_CLUSTER.Text = conn.GetFieldValue("cluster_code");
				TXT_UNIT_CABANG.Text = conn.GetFieldValue("unit");
				TXT_THN_PEMBUKAAN.Text = conn.GetFieldValue("tahun_pembukaan");
				TXT_JUM_SO.Text = conn.GetFieldValue("jumlah_so");

				conn.QueryString = "select * from MAS_CREDIT_QUALITY_TRACK_HISTORY where seq_unit='"+Request.QueryString["seq_unit"]+"' ";
				conn.ExecuteQuery();
				if (conn.GetFieldValue("trackcode")=="")
				{
					BTN_PRINT.Enabled = false;			
				}
				if (conn.GetFieldValue("trackcode")=="M2.3.3")
				{
					BTN_INSERT_MKS.Enabled = false;
					BTN_INSERT_PEGAWAI_UNIT.Enabled = false;
					BTN_INSERT_PORTFOLIO_UNIT.Enabled = false;
					BTN_SAVE.Enabled = false;	
					BTN_SEND.Enabled = false;
				}

				ddlBulan();
				ddlRF();
				
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
			//TXT_DIKETAHUI_OLEH2.Text = conn.GetFieldValue("su_fullname");
		}
		
		private void ddlBulan()
		{
			DDL_BLN_BERGABUNG.Items.Add(new ListItem("--Pilih--",""));
			DDL_BLN_BERGABUNG_MKS.Items.Add(new ListItem("--Pilih--",""));
			DDL_BLN_KUNJUNGAN1.Items.Add(new ListItem("--Pilih--",""));
			DDL_BLN_KUNJUNGAN2.Items.Add(new ListItem("--Pilih--",""));
				
			for(int i=1; i<=12; i++)
			{
				DDL_BLN_BERGABUNG.Items.Add(new ListItem(DateAndTime.MonthName(i, false), i.ToString()));
				DDL_BLN_BERGABUNG_MKS.Items.Add(new ListItem(DateAndTime.MonthName(i, false), i.ToString()));
				DDL_BLN_KUNJUNGAN1.Items.Add(new ListItem(DateAndTime.MonthName(i, false), i.ToString()));
				DDL_BLN_KUNJUNGAN2.Items.Add(new ListItem(DateAndTime.MonthName(i, false), i.ToString()));
			}
		}

		private void ddlRF()
		{
			DDL_JABATAN.Items.Add(new ListItem("--Pilih--",""));
			conn.QueryString = "select code, code + '- ' + [desc] as [desc] from mas_rf_jabatan where status='1'";
			conn.ExecuteQuery();
			for (int i = 0; i < conn.GetRowCount(); i++)
				DDL_JABATAN.Items.Add(new ListItem(conn.GetFieldValue(i,1),conn.GetFieldValue(i,0)));

			DDL_STATUS_PEGAWAI.Items.Add(new ListItem("--Pilih--",""));
			conn.QueryString = "select code, code + '- ' + [desc] as [desc] from mas_RF_STATUS_PEGAWAI where status='1' ";
			conn.ExecuteQuery();
			for (int i = 0; i < conn.GetRowCount(); i++)
				DDL_STATUS_PEGAWAI.Items.Add(new ListItem(conn.GetFieldValue(i,1),conn.GetFieldValue(i,0)));

			DDL_STATUS_KEPEGAWAIAN_MKS.Items.Add(new ListItem("--Pilih--",""));
			conn.QueryString = "select code, code + '- ' + [desc] as [desc] from mas_RF_STATUS_PEGAWAI where status='1'";
			conn.ExecuteQuery();
			for (int i = 0; i < conn.GetRowCount(); i++)
				DDL_STATUS_KEPEGAWAIAN_MKS.Items.Add(new ListItem(conn.GetFieldValue(i,1),conn.GetFieldValue(i,0)));

			DDL_PRODUK.Items.Add(new ListItem("--Pilih--",""));
			conn.QueryString = "select code, code + '- ' + [desc] as [desc] from mas_rf_produk where status='1'";
			conn.ExecuteQuery();
			for (int i = 0; i < conn.GetRowCount(); i++)
				DDL_PRODUK.Items.Add(new ListItem(conn.GetFieldValue(i,1),conn.GetFieldValue(i,0)));
		}

		private void ClearDataDaftarPegawaiUnit()
		{
			TXT_SEQ1.Text = "";
			TXT_NIP_PEGAWAI.Text = "";
			TXT_NAMA_PEGAWAI.Text = "";
			DDL_JABATAN.SelectedValue = "";
			TXT_TGL_BERGABUNG.Text = "";
			DDL_BLN_BERGABUNG.SelectedValue = "";
			TXT_THN_BERGABUNG.Text = "";
			DDL_STATUS_PEGAWAI.SelectedValue = "";
			TXT_CAT_PEGAWAI.Text = "";
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
			this.DGR_PEGAWAI.ItemCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.DGR_PEGAWAI_ItemCommand);
			this.DGR_PEGAWAI.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.DGR_PEGAWAI_PageIndexChanged);
			this.DGR_PEGAWAI.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(this.DGR_PEGAWAI_ItemDataBound);
			this.DGR_MKS.ItemCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.DGR_MKS_ItemCommand);
			this.DGR_MKS.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.DGR_MKS_PageIndexChanged);
			this.DGR_MKS.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(this.DGR_MKS_ItemDataBound);
			this.DGR_POTFOLIO_UNIT.ItemCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.DGR_POTFOLIO_UNIT_ItemCommand);
			this.DGR_POTFOLIO_UNIT.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.DGR_POTFOLIO_UNIT_PageIndexChanged);
			this.DGR_POTFOLIO_UNIT.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(this.DGR_POTFOLIO_UNIT_ItemDataBound);

		}
		#endregion

		protected void BTN_CLEAR_PEGAWAI_UNIT_Click(object sender, System.EventArgs e)
		{
			ClearDataDaftarPegawaiUnit();
		}

		private void ClearDataMKS()
		{
			TXT_SEQ2.Text = "";
			TXT_NIP_MKS.Text = "";
			TXT_NAMA_PEGAWAI_MKS.Text = "";
			TXT_TGL_BERGABUNG_MKS.Text = "";
			DDL_BLN_BERGABUNG_MKS.SelectedValue = "";
			TXT_THN_BERGABUNG_MKS.Text = "";
			DDL_STATUS_KEPEGAWAIAN_MKS.SelectedValue = "";
			TXT_BADE_KELOLAAN_MKS.Text = "";
			TXT_KOL_LANCAR_MKS.Text = "";
			TXT_DPD_MKS.Text = "";
			TXT_NPL_MKS.Text = "";
		}

		protected void BTN_CLEAR_MKS_Click(object sender, System.EventArgs e)
		{
			ClearDataMKS();
		}

		private void ClearDataPortfolio()
		{
			TXT_SEQ3.Text = "";
			DDL_PRODUK.SelectedValue = "";
			TXT_JUM_DEBITUR.Text = "";
			TXT_BAKI_DEBET.Text = "";
			TXT_KOLEK_LANCAR.Text = "";
			TXT_DPD_PLUS.Text = "";
			TXT_NPL_PERCENT.Text = "";
			TXT_FR_TO_X.Text = "";
			TXT_FR_TO_30.Text = "";
			TXT_FR_TO_60.Text = "";
			TXT_FR_TO_90.Text = "";
		}

		protected void BTN_CLEAR_PORTFOLIO_UNIT_Click(object sender, System.EventArgs e)
		{
			ClearDataPortfolio();
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


		private void DGR_PEGAWAI_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			DGR_PEGAWAI.CurrentPageIndex = e.NewPageIndex;
			ViewGridPegawaiUnit();
		}

		private void DGR_PEGAWAI_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			switch (((LinkButton)e.CommandSource).CommandName)
			{
				case "delete_data":
					conn.QueryString = "delete from MAS_CQA_UNIT_REVIEW_PEGAWAI_UNIT where unit_seq='"+Request.QueryString["seq_unit"]+"' and seq= " + Convert.ToInt32(e.Item.Cells[0].Text) + " ";
					conn.ExecuteQuery();					
					ClearDataDaftarPegawaiUnit();					
					ViewGridPegawaiUnit();
					break;

				case "edit_data":					
					conn.QueryString = "select * from MAS_CQA_UNIT_REVIEW_PEGAWAI_UNIT where unit_seq='"+Request.QueryString["seq_unit"]+"' and seq= " + Convert.ToInt32(e.Item.Cells[0].Text) + " ";
					conn.ExecuteQuery();
					
					TXT_SEQ1.Text = conn.GetFieldValue("seq");
					TXT_NIP_PEGAWAI.Text = conn.GetFieldValue("nip");
					TXT_NAMA_PEGAWAI.Text = conn.GetFieldValue("nama_pegawai");
					try{DDL_JABATAN.SelectedValue = conn.GetFieldValue("jabatan");}
					catch{DDL_JABATAN.SelectedValue = "";}
					TXT_TGL_BERGABUNG.Text = tool.FormatDate_Day(conn.GetFieldValue("bergabung_sejak"));
					try{DDL_BLN_BERGABUNG.SelectedValue = tool.FormatDate_Month(conn.GetFieldValue("bergabung_sejak")); }
					catch{DDL_BLN_BERGABUNG.SelectedValue = "";}
					TXT_THN_BERGABUNG.Text = tool.FormatDate_Year(conn.GetFieldValue("bergabung_sejak"));
					try{DDL_STATUS_PEGAWAI.SelectedValue = conn.GetFieldValue("status_kepegawaian");}
					catch{DDL_STATUS_PEGAWAI.SelectedValue = "";}
					TXT_CAT_PEGAWAI.Text = conn.GetFieldValue("catatan");
					break;

				case "retrieve_data":					
					conn.QueryString = "select * from MAS_CQA_UNIT_REVIEW_PEGAWAI_UNIT where unit_seq='"+Request.QueryString["seq_unit"]+"' and seq= " + Convert.ToInt32(e.Item.Cells[0].Text) + " ";
					conn.ExecuteQuery();
					
					TXT_NIP_MKS.Text = conn.GetFieldValue("nip");
					TXT_NAMA_PEGAWAI_MKS.Text = conn.GetFieldValue("nama_pegawai");
					TXT_TGL_BERGABUNG_MKS.Text = tool.FormatDate_Day(conn.GetFieldValue("bergabung_sejak"));
					try{DDL_BLN_BERGABUNG_MKS.SelectedValue = tool.FormatDate_Month(conn.GetFieldValue("bergabung_sejak")); }
					catch{DDL_BLN_BERGABUNG_MKS.SelectedValue = "";}
					TXT_THN_BERGABUNG_MKS.Text = tool.FormatDate_Year(conn.GetFieldValue("bergabung_sejak"));
					try{DDL_STATUS_KEPEGAWAIAN_MKS.SelectedValue = conn.GetFieldValue("status_kepegawaian");}
					catch{DDL_STATUS_KEPEGAWAIAN_MKS.SelectedValue = "";}
					
					break;
			}
		}

		protected void BTN_INSERT_PEGAWAI_UNIT_Click(object sender, System.EventArgs e)
		{
			Int64 now = Int64.Parse(Tools.toISODate(DateTime.Now.Day.ToString(), DateTime.Now.Month.ToString(), DateTime.Now.Year.ToString())), compEstablish;
			try 
			{
				compEstablish = Int64.Parse(Tools.toISODate(TXT_TGL_BERGABUNG.Text, DDL_BLN_BERGABUNG.SelectedValue, TXT_THN_BERGABUNG.Text));
			} 
			catch 
			{
				GlobalTools.popMessage(this, "Tanggal bergabung daftar pegawai tidak valid!");
				return;
			}

			if (TXT_SEQ1.Text == "")
			{
				conn.QueryString = " exec MAS_CQA_UNIT_REVIEW_PEGAWAI_UNIT_INSERT '" + 
					Request.QueryString["seq_unit"] + "', '" +
					TXT_NIP_PEGAWAI.Text + "', '" +
					TXT_NAMA_PEGAWAI.Text + "', '" +
					DDL_JABATAN.SelectedValue + "', " +
					tool.ConvertDate(TXT_TGL_BERGABUNG.Text, DDL_BLN_BERGABUNG.SelectedValue, TXT_THN_BERGABUNG.Text) + ", '" +
					DDL_STATUS_PEGAWAI.SelectedValue + "', '" +
					TXT_CAT_PEGAWAI.Text +"' " ;
				conn.ExecuteQuery();				
			}
			else
			{
				conn.QueryString = " exec MAS_CQA_UNIT_REVIEW_PEGAWAI_UNIT_UPDATE " + 
					Convert.ToInt32(TXT_SEQ1.Text) + ", '" +					
					Request.QueryString["seq_unit"] + "', '" +
					TXT_NIP_PEGAWAI.Text + "', '" +
					TXT_NAMA_PEGAWAI.Text + "', '" +
					DDL_JABATAN.SelectedValue + "', " +
					tool.ConvertDate(TXT_TGL_BERGABUNG.Text, DDL_BLN_BERGABUNG.SelectedValue, TXT_THN_BERGABUNG.Text) + ", '" +
					DDL_STATUS_PEGAWAI.SelectedValue + "', '" +
					TXT_CAT_PEGAWAI.Text +"' " ;
				conn.ExecuteQuery();
			}
			ClearDataDaftarPegawaiUnit();
			ViewGridPegawaiUnit();
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

		private void DGR_MKS_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			DGR_MKS.CurrentPageIndex = e.NewPageIndex;
			ViewPortfolioMKS();
		}

		private void DGR_MKS_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			switch (((LinkButton)e.CommandSource).CommandName)
			{
				case "delete_data":
					conn.QueryString = "delete from MAS_CQA_UNIT_REVIEW_MKS where unit_seq='"+Request.QueryString["seq_unit"]+"' and seq= " + Convert.ToInt32(e.Item.Cells[0].Text) + " ";
					conn.ExecuteQuery();					
					ClearDataMKS();					
					ViewPortfolioMKS();
					break;

				case "edit_data":					
					conn.QueryString = "select * from MAS_CQA_UNIT_REVIEW_MKS where unit_seq='"+Request.QueryString["seq_unit"]+"' and seq= " + Convert.ToInt32(e.Item.Cells[0].Text) + " ";
					conn.ExecuteQuery();
					
					TXT_SEQ2.Text = conn.GetFieldValue("seq");
					TXT_NIP_MKS.Text = conn.GetFieldValue("nip");
					TXT_NAMA_PEGAWAI_MKS.Text = conn.GetFieldValue("nama_pegawai");					
					TXT_TGL_BERGABUNG_MKS.Text = tool.FormatDate_Day(conn.GetFieldValue("bergabung_sejak"));
					try{DDL_BLN_BERGABUNG_MKS.SelectedValue = tool.FormatDate_Month(conn.GetFieldValue("bergabung_sejak")); }
					catch{DDL_BLN_BERGABUNG_MKS.SelectedValue = "";}
					TXT_THN_BERGABUNG_MKS.Text = tool.FormatDate_Year(conn.GetFieldValue("bergabung_sejak"));
					try{DDL_STATUS_KEPEGAWAIAN_MKS.SelectedValue = conn.GetFieldValue("status_kepegawaian");}
					catch{DDL_STATUS_KEPEGAWAIAN_MKS.SelectedValue = "";}
					TXT_BADE_KELOLAAN_MKS.Text = conn.GetFieldValue("bade_kelolaan");
					TXT_KOL_LANCAR_MKS.Text = conn.GetFieldValue("kol_lancar");
					TXT_DPD_MKS.Text = conn.GetFieldValue("dpd_30");
					TXT_NPL_MKS.Text = conn.GetFieldValue("npl");
					break;
			}
		}

		protected void BTN_INSERT_MKS_Click(object sender, System.EventArgs e)
		{
			Int64 now = Int64.Parse(Tools.toISODate(DateTime.Now.Day.ToString(), DateTime.Now.Month.ToString(), DateTime.Now.Year.ToString())), compEstablish;
			try 
			{
				compEstablish = Int64.Parse(Tools.toISODate(TXT_TGL_BERGABUNG_MKS.Text, DDL_BLN_BERGABUNG_MKS.SelectedValue, TXT_THN_BERGABUNG_MKS.Text));
			} 
			catch 
			{
				GlobalTools.popMessage(this, "Tanggal bergabung MKS tidak valid!");
				return;
			}

			if (TXT_SEQ2.Text == "")
			{
				conn.QueryString = " exec MAS_CQA_UNIT_REVIEW_MKS_INSERT '" + 
					Request.QueryString["seq_unit"] + "', '" +
					TXT_NIP_MKS.Text + "', '" +
					TXT_NAMA_PEGAWAI_MKS.Text + "', " +					
					tool.ConvertDate(TXT_TGL_BERGABUNG_MKS.Text, DDL_BLN_BERGABUNG_MKS.SelectedValue, TXT_THN_BERGABUNG_MKS.Text) + ", '" +
					DDL_STATUS_KEPEGAWAIAN_MKS.SelectedValue + "', '" +
					TXT_BADE_KELOLAAN_MKS.Text + "', '" +
					TXT_KOL_LANCAR_MKS.Text + "', '" +
					TXT_DPD_MKS.Text + "', '" +
					TXT_NPL_MKS.Text +"' " ;
				conn.ExecuteQuery();				
			}
			else
			{
				conn.QueryString = " exec MAS_CQA_UNIT_REVIEW_MKS_UPDATE " + 
					Convert.ToInt32(TXT_SEQ2.Text) + ", '" +					
					Request.QueryString["seq_unit"] + "', '" +
					TXT_NIP_MKS.Text + "', '" +
					TXT_NAMA_PEGAWAI_MKS.Text + "', " +					
					tool.ConvertDate(TXT_TGL_BERGABUNG_MKS.Text, DDL_BLN_BERGABUNG_MKS.SelectedValue, TXT_THN_BERGABUNG_MKS.Text) + ", '" +
					DDL_STATUS_KEPEGAWAIAN_MKS.SelectedValue + "', '" +
					TXT_BADE_KELOLAAN_MKS.Text + "', '" +
					TXT_KOL_LANCAR_MKS.Text + "', '" +
					TXT_DPD_MKS.Text + "', '" +
					TXT_NPL_MKS.Text +"' " ;
				conn.ExecuteQuery();
			}
			ClearDataMKS();
			ViewPortfolioMKS();
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

		private void DGR_POTFOLIO_UNIT_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			DGR_MKS.CurrentPageIndex = e.NewPageIndex;
			ViewPortfolioUnit();
		}

		private void DGR_POTFOLIO_UNIT_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			switch (((LinkButton)e.CommandSource).CommandName)
			{
				case "delete_data":
					conn.QueryString = "delete from MAS_CQA_UNIT_REVIEW_PORTFOLIO_UNIT where unit_seq='"+Request.QueryString["seq_unit"]+"' and seq= " + Convert.ToInt32(e.Item.Cells[0].Text) + " ";
					conn.ExecuteQuery();					
					ClearDataPortfolio();					
					ViewPortfolioUnit();
					break;

				case "edit_data":					
					conn.QueryString = "select * from MAS_CQA_UNIT_REVIEW_PORTFOLIO_UNIT where unit_seq='"+Request.QueryString["seq_unit"]+"' and seq= " + Convert.ToInt32(e.Item.Cells[0].Text) + " ";
					conn.ExecuteQuery();
					
					TXT_SEQ3.Text = conn.GetFieldValue("seq");
					try{DDL_PRODUK.SelectedValue = conn.GetFieldValue("produk");}
					catch{DDL_PRODUK.SelectedValue = "";}
					TXT_JUM_DEBITUR.Text = conn.GetFieldValue("jum_debitur");
					TXT_BAKI_DEBET.Text = conn.GetFieldValue("baki_debet");						
					TXT_KOLEK_LANCAR.Text = conn.GetFieldValue("kolek_lancar");					
					TXT_DPD_PLUS.Text = conn.GetFieldValue("dpd_30_plus");
					TXT_NPL_PERCENT.Text = conn.GetFieldValue("npl");
					TXT_FR_TO_X.Text = conn.GetFieldValue("fr_to_x");
					TXT_FR_TO_30.Text = conn.GetFieldValue("fr_to_30");
					TXT_FR_TO_60.Text = conn.GetFieldValue("fr_to_60");
					TXT_FR_TO_90.Text = conn.GetFieldValue("fr_to_90");
					break;
			}
		}

		protected void BTN_INSERT_PORTFOLIO_UNIT_Click(object sender, System.EventArgs e)
		{
			if (TXT_SEQ3.Text == "")
			{
				conn.QueryString = " exec MAS_CQA_UNIT_REVIEW_PORTFOLIO_UNIT_INSERT '" + 
					Request.QueryString["seq_unit"] + "', '" +
					DDL_PRODUK.SelectedValue + "', '" +
					TXT_JUM_DEBITUR.Text + "', '" +
					TXT_BAKI_DEBET.Text + "', '" +					
					TXT_KOLEK_LANCAR.Text + "', '" +
					TXT_DPD_PLUS.Text + "', '" +
					TXT_NPL_PERCENT.Text + "', '" +
					TXT_FR_TO_X.Text + "', '" +
					TXT_FR_TO_30.Text + "', '" +
					TXT_FR_TO_60.Text + "', '" +
					TXT_FR_TO_90.Text +"' " ;
				conn.ExecuteQuery();				
			}
			else
			{
				conn.QueryString = " exec MAS_CQA_UNIT_REVIEW_PORTFOLIO_UNIT_UPDATE " + 
					Convert.ToInt32(TXT_SEQ3.Text) + ", '" +					
					Request.QueryString["seq_unit"] + "', '" +
					DDL_PRODUK.SelectedValue + "', '" +
					TXT_JUM_DEBITUR.Text + "', '" +
					TXT_BAKI_DEBET.Text + "', '" +					
					TXT_KOLEK_LANCAR.Text + "', '" +
					TXT_DPD_PLUS.Text + "', '" +
					TXT_NPL_PERCENT.Text + "', '" +
					TXT_FR_TO_X.Text + "', '" +
					TXT_FR_TO_30.Text + "', '" +
					TXT_FR_TO_60.Text + "', '" +
					TXT_FR_TO_90.Text +"' " ;
				conn.ExecuteQuery();
			}
			ClearDataPortfolio();
			ViewPortfolioUnit();
		}

		protected void BTN_BACK_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			Response.Redirect("ReviewList.aspx?tc=" + Request.QueryString["tc"] + "&mc=" + Request.QueryString["mc"] );
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

		protected void BTN_SAVE_Click(object sender, System.EventArgs e)
		{
			Int64 now = Int64.Parse(Tools.toISODate(DateTime.Now.Day.ToString(), DateTime.Now.Month.ToString(), DateTime.Now.Year.ToString())), compEstablish, KunjunganDate2;
			try 
			{
				compEstablish = Int64.Parse(Tools.toISODate(TXT_TGL_KUNJUNGAN1.Text, DDL_BLN_KUNJUNGAN1.SelectedValue, TXT_THN_KUNJUNGAN1.Text));
			} 
			catch 
			{
				GlobalTools.popMessage(this, "Tanggal kunjungan tidak valid!");
				return;
			}

			try 
			{
				KunjunganDate2 = Int64.Parse(Tools.toISODate(TXT_TGL_KUNJUNGAN2.Text, DDL_BLN_KUNJUNGAN2.SelectedValue, TXT_THN_KUNJUNGAN2.Text));
			} 
			catch 
			{
				GlobalTools.popMessage(this, "Tanggal kunjungan tidak valid!");
				return;
			}
			conn.QueryString = " exec MAS_UNIT_REVIEW_INSERT '" + 									
				Request.QueryString["seq_unit"] + "', '" +
				TXT_DISTRICT.Text + "', '" +
				TXT_CLUSTER.Text + "', '" +
				TXT_UNIT_CABANG.Text + "', '" +					
				TXT_THN_PEMBUKAAN.Text + "', '" +
				TXT_JUM_SO.Text + "', " +
				tool.ConvertDate(TXT_TGL_KUNJUNGAN1.Text, DDL_BLN_KUNJUNGAN1.SelectedValue, TXT_THN_KUNJUNGAN1.Text) + ", " +
				tool.ConvertDate(TXT_TGL_KUNJUNGAN2.Text, DDL_BLN_KUNJUNGAN2.SelectedValue, TXT_THN_KUNJUNGAN2.Text) + ", '" +
				TXT_NAMA_SO1.Text + "', '" +
				TXT_NAMA_SO2.Text + "', '" +
				TXT_NAMA_SO3.Text + "', '" +
				TXT_NAMA_SO4.Text + "' , '" + 
				RDO_LOKASI_SO1.SelectedValue + "' , '" + 
				RDO_LOKASI_SO2.SelectedValue + "' , '" + 
				RDO_LOKASI_SO3.SelectedValue + "' , '" + 
				RDO_LOKASI_SO4.SelectedValue + "' , '" + 
				TXT_DIBUAT_OLEH.Text + "' , '" + 
				TXT_DIKETAHUI_OLEH1.Text + "' , '" + 
				TXT_DIKETAHUI_OLEH2.Text + "' , '" + 
				Session["UserID"].ToString() + "' " ;
			conn.ExecuteQuery();

			conn.QueryString = " exec MAS_KUALITAS_MMM_INSERT '" + 
				Request.QueryString["seq_unit"] + "', '" +
				TXT_DISTRICT.Text + "', '" +
				TXT_CLUSTER.Text + "', '" +
				TXT_UNIT_CABANG.Text + "', '" +	
				RDO_MMM1.SelectedValue + "', '" +
				RDO_MMM2.SelectedValue + "', '" +
				RDO_MMM3.SelectedValue + "', '" +					
				RDO_MMM4.SelectedValue + "', '" +
				RDO_MMM5.SelectedValue + "', '" +
				RDO_MMM6.SelectedValue + "', '" +				
				TXT_PERMASALAHAN1.Text + "' , '" + 
				TXT_PERMASALAHAN2.Text + "' , '" + 
				TXT_PERMASALAHAN3.Text + "' , '" + 				
				TXT_DIBUAT_OLEH.Text + "' , '" + 
				TXT_DIKETAHUI_OLEH1.Text + "' , '" + 
				TXT_DIKETAHUI_OLEH2.Text + "' , '" + 
				Session["UserID"].ToString() + "' " ;
			conn.ExecuteQuery();

		}

		protected void BTN_PRINT_Click(object sender, System.EventArgs e)
		{
			Response.Redirect("/SME/MAS/SupervisionManagement/MicroCreditQuality/UnitReview/PrintUnitReview	.aspx?tc=" + Request.QueryString["tc"] + "&mc=" + Request.QueryString["mc"] + "&seq_unit=" + Request.QueryString["seq_unit"]);
		}

		protected void BTN_SEND_Click(object sender, System.EventArgs e)
		{
			string su_upliner1;
			conn.QueryString = "select * from scuser where userid = '"+ Session["UserID"].ToString() +"'";
			conn.ExecuteQuery();
			TXT_DIBUAT_OLEH.Text = conn.GetFieldValue("su_fullname");
			su_upliner1 = conn.GetFieldValue("su_upliner");			

			conn.QueryString = "exec MAS_MICRO_CREDIT_TRACKUPDATE '" +
				Request.QueryString["seq_unit"] + "' , 'M2.3.4' , '" + 
				Session["UserID"].ToString() + "' , '"+ su_upliner1 +"' ";
			conn.ExecuteQuery();

			Response.Redirect("ReviewList.aspx?tc=" + Request.QueryString["tc"] + "&mc=" + Request.QueryString["mc"] );
		}

		private void DGR_PEGAWAI_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			if ( e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item ) 
			{
				System.Web.UI.WebControls.LinkButton linkntn=(System.Web.UI.WebControls.LinkButton)e.Item.FindControl("delete_data");
				linkntn.Attributes.Add("onClick", "return confirm('Apakah Anda yakin akan menghapus data ini?')");
			}		
		}

		private void DGR_MKS_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{ 
			if ( e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item ) 
			{
				System.Web.UI.WebControls.LinkButton linkntn=(System.Web.UI.WebControls.LinkButton)e.Item.FindControl("delete_data");
				linkntn.Attributes.Add("onClick", "return confirm('Apakah Anda yakin akan menghapus data ini?')");
			}		
		}

		private void DGR_POTFOLIO_UNIT_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			if ( e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item ) 
			{
				System.Web.UI.WebControls.LinkButton linkntn=(System.Web.UI.WebControls.LinkButton)e.Item.FindControl("delete_data");
				linkntn.Attributes.Add("onClick", "return confirm('Apakah Anda yakin akan menghapus data ini?')");
			}
		}
				
	}
}
