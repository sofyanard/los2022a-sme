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
using DMS.CuBESCore;
using DMS.DBConnection;
using Microsoft.VisualBasic;



namespace SME.MAS.CollateralAdministration.DetailCollateral
{
	/// <summary>
	/// Summary description for Collateral_Dep.
	/// </summary>
	public partial class Collateral_Dep : System.Web.UI.Page
	{
		protected Tools tool = new Tools();
		protected Connection conn = new Connection(ConfigurationSettings.AppSettings["conn"]);
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			if (!IsPostBack)
			{
				//DDL Tanggal
				for (int i = 1; i <= 12; i++)
				{
					DDL_DRAWDOWNDATE_MONTH.Items.Add(new ListItem(DateAndTime.MonthName(i, false), i.ToString()));
				}
				
				//DDL Kanwil
				GlobalTools.fillRefList(DDL_KANWIL, "SELECT * FROM XXXXX_PROFILERESIKO_DDLKANWIL", false, conn);

				//DDL Kanca
				GlobalTools.fillRefList(DDL_KANCA, "SELECT * FROM XXXXX_PROFILERESIKO_DDLKANCA", false, conn);

				//DDL Uker
				GlobalTools.fillRefList(DDL_UKER, "SELECT * FROM XXXXX_PROFILERESIKO_DDLUKER", false, conn);

				//DDL Jenis Pekerjaan
				GlobalTools.fillRefList(DDL_JENISPEKERJAAN, "SELECT * FROM XXXXX_PROFILERESIKO_DDLJENISPEKERJAAN", false, conn);

				//DDL Bidang Pekerjaan
				GlobalTools.fillRefList(DDL_BIDANGPEKERJAAN, "SELECT * FROM XXXXX_PROFILERESIKO_DDLBIDANGPEKERJAAN", false, conn);

				//DDL Sub Bidang Pekerjaan
				GlobalTools.fillRefList(DDL_SUBBIDANGPEKERJAAN, "SELECT * FROM XXXXX_PROFILERESIKO_DDLSUBBIDANGPEKERJAAN", false, conn);

				//DDL Skim
				GlobalTools.fillRefList(DDL_SKIM, "SELECT * FROM XXXXX_PROFILERESIKO_DDLSKIM", false, conn);

				//DDL Tujuan
				GlobalTools.fillRefList(DDL_TUJUAN, "SELECT * FROM XXXXX_PROFILERESIKO_DDLTUJUAN", false, conn);

				//DDL Status Buy Back Guarantee
				GlobalTools.fillRefList(DDL_BUYBACKGRNTY, "SELECT * FROM XXXXX_PROFILERESIKO_DDLSUBBIDANGPEKERJAAN", false, conn);

				//DDL Jangka Waktu
				GlobalTools.fillRefList(DDL_JANGKAWAKTU_CODE, "SELECT * FROM XXXXX_PROFILERESIKO_DDLJANGKAWAKTU", false, conn);

				//DDL Kolektibilitas
				GlobalTools.fillRefList(DDL_KOLEKTIBILITAS, "SELECT * FROM XXXXX_PROFILERESIKO_DDLKOLEKTIBILITAS", false, conn);

				//DDL Lokasi Agunan
				GlobalTools.fillRefList(DDL_LOKASIAGUNAN, "SELECT * FROM XXXXX_PROFILERESIKO_DDLLOKASIAGUNAN", false, conn);

				//DDL Marketability Agunan
				GlobalTools.fillRefList(DDL_MARKETABLAGUNAN, "SELECT * FROM XXXXX_PROFILERESIKO_DDLMARKETABLAGUNAN", false, conn);

				//DDL Status Agunan
				GlobalTools.fillRefList(DDL_STATUSAGUNAN, "SELECT * FROM XXXXX_PROFILERESIKO_DDLSTATUSAGUNAN", false, conn);

				//DDL Dokumen Kepemilikan Agunan
				GlobalTools.fillRefList(DDL_DOCAGUNAN, "SELECT * FROM XXXXX_PROFILERESIKO_DDLDOCAGUNAN", false, conn);

				ViewGeneralInfo();
				ViewDataPenghasilan();
				ViewStrukturKredit();
				ViewDataAgunan();
				ViewDataMacet();
			}
		}

		private void ViewGeneralInfo()
		{
			conn.QueryString = "EXEC XXXXX_PROFILERESIKO_GENERALINFO '" + Request.QueryString["curef"] + "'";
			conn.ExecuteQuery();

			if (conn.GetRowCount() > 0)
			{
				TXT_NAMA_NASABAH.Text = conn.GetFieldValue("CU_NAME");
				TXT_NAMA_AO.Text = conn.GetFieldValue("CU_RELMNGR");
				try { DDL_KANWIL.SelectedValue = conn.GetFieldValue("KANWIL_CODE"); }
				catch {}
				try { DDL_KANCA.SelectedValue = conn.GetFieldValue("KANCA_CODE"); }
				catch {}
				try { DDL_UKER.SelectedValue = conn.GetFieldValue("UKER_CODE"); }
				catch {}
				TXT_STATUS_PERMOHONAN.Text = conn.GetFieldValue("STATUS_PERMOHONAN");
				TXT_STATUS1.Text = conn.GetFieldValue("STATUS1");
				TXT_STATUS2.Text = conn.GetFieldValue("STATUS2");
				TXT_STATUS3.Text = conn.GetFieldValue("STATUS3");
			}
		}

		private void ViewDataPenghasilan()
		{
			conn.QueryString = "EXEC XXXXX_PROFILERESIKO_DATAPENGHASILAN '" + Request.QueryString["curef"] + "'";
			conn.ExecuteQuery();

			if (conn.GetRowCount() > 0)
			{
				TXT_SUMBER.Text = conn.GetFieldValue("SUMBER");
				try { DDL_JENISPEKERJAAN.SelectedValue = conn.GetFieldValue("JENISPEKERJAAN_CODE"); }
				catch {}
				try { DDL_BIDANGPEKERJAAN.SelectedValue = conn.GetFieldValue("BIDANGPEKERJAAN_CODE"); }
				catch {}
				try { DDL_SUBBIDANGPEKERJAAN.SelectedValue = conn.GetFieldValue("SUBBIDANGPEKERJAAN_CODE"); }
				catch {}
				TXT_NAMATEMPATKERJA.Text = conn.GetFieldValue("NAMATEMPATKERJA");
			}
		}

		private void ViewStrukturKredit()
		{
			conn.QueryString = "EXEC XXXXX_PROFILERESIKO_STRUKTURKREDIT '" + Request.QueryString["curef"] + "'";
			conn.ExecuteQuery();

			DataTable dt = new DataTable();
			dt = conn.GetDataTable().Copy();
			DG_STRUKTUR.DataSource = dt;
			try 
			{
				DG_STRUKTUR.DataBind();
			} 
			catch 
			{
				DG_STRUKTUR.CurrentPageIndex = 0;
				DG_STRUKTUR.DataBind();
			}
		}

		private void ViewDataAgunan()
		{
			conn.QueryString = "EXEC XXXXX_PROFILERESIKO_DATAAGUNAN '" + Request.QueryString["curef"] + "'";
			conn.ExecuteQuery();

			DataTable dt = new DataTable();
			dt = conn.GetDataTable().Copy();
			DG_AGUNAN.DataSource = dt;
			try 
			{
				DG_AGUNAN.DataBind();
			} 
			catch 
			{
				DG_AGUNAN.CurrentPageIndex = 0;
				DG_AGUNAN.DataBind();
			}
		}

		private void ViewDataMacet()
		{
			conn.QueryString = "EXEC XXXXX_PROFILERESIKO_DATAMACET '" + Request.QueryString["curef"] + "'";
			conn.ExecuteQuery();

			DataTable dt = new DataTable();
			dt = conn.GetDataTable().Copy();
			DG_MACET.DataSource = dt;
			try 
			{
				DG_MACET.DataBind();
			} 
			catch 
			{
				DG_MACET.CurrentPageIndex = 0;
				DG_MACET.DataBind();
			}
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
			this.DG_STRUKTUR.ItemCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.DatGrd_ItemCommand);

		}
		#endregion

		private void DatGrd_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			switch (((LinkButton)e.CommandSource).CommandName)
			{
				case "edit":
					try { DDL_SKIM.SelectedValue = e.Item.Cells[5].Text; }
					catch {}
					try { DDL_TUJUAN.SelectedValue = e.Item.Cells[6].Text; }
					catch {}
					TXT_NAMAPROYEK.Text = e.Item.Cells[8].Text;
					TXT_DEVELOPER.Text = e.Item.Cells[9].Text;
					try { DDL_BUYBACKGRNTY.SelectedValue = e.Item.Cells[10].Text; }
					catch {}
					TXT_PLAFOND.Text = e.Item.Cells[11].Text;
					TXT_OUTSTANDING.Text = e.Item.Cells[2].Text;
					TXT_DRAWDOWN.Text = e.Item.Cells[12].Text;
					TXT_JANGKAWAKTU.Text = e.Item.Cells[3].Text;
					try { DDL_JANGKAWAKTU_CODE.SelectedValue = e.Item.Cells[13].Text; }
					catch {}
					try { DDL_JANGKAWAKTU_CODE.SelectedValue = e.Item.Cells[14].Text; }
					catch {}
					TXT_PEMRAKARSA.Text = e.Item.Cells[15].Text;
					TXT_PEMUTUS.Text = e.Item.Cells[16].Text;
					TXT_ADK.Text = e.Item.Cells[17].Text;
					break;					
			}
		}

	}
}
