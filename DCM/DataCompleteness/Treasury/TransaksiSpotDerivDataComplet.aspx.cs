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

namespace SME.DCM.DataCompleteness.Treasury
{
	/// <summary>
	/// Summary description for AccountDataComplet.
	/// </summary>
	public partial class TransaksiSpotDerivDataComplet : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.TextBox TXT_BAKIDEBET;
		protected System.Web.UI.WebControls.Label LBL_TXT_BAKIDEBET;
		protected System.Web.UI.WebControls.RadioButtonList RDO_COMMITTED;
		protected System.Web.UI.WebControls.RadioButtonList RDO_UNCOMMITED;
		protected System.Web.UI.WebControls.Label LBL_RDO_COMMITTED;
		protected System.Web.UI.WebControls.Label LBL_RDO_UNCOMMITED;
		protected System.Web.UI.WebControls.TextBox TXT_PDPTBUNGAYAD;
		protected System.Web.UI.WebControls.TextBox TXT_PDPTDITANGGUHKAN;
		protected System.Web.UI.WebControls.Label LBL_TXT_PDPTBUNGAYAD;
		protected System.Web.UI.WebControls.Label LBL_TXT_PDPTDITANGGUHKAN;
		protected System.Web.UI.WebControls.RadioButtonList RDO_INDIVIDUAL;
		protected System.Web.UI.WebControls.RadioButtonList RDO_KOLEKTIF;
		protected System.Web.UI.WebControls.RadioButtonList RDO_JNSPENGAJUAN;
		protected System.Web.UI.WebControls.Label LBL_RDO_INDIVIDUAL;
		protected System.Web.UI.WebControls.Label LBL_RDO_KOLEKTIF;
		protected System.Web.UI.WebControls.Label LBL_RDO_JNSPENGAJUAN;
		protected Tools tools = new Tools();
		protected Connection conn2 = new Connection(ConfigurationSettings.AppSettings["conn2"]);
		protected Connection conn3 = new Connection(ConfigurationSettings.AppSettings["conn2"]);
		protected Connection conn = new Connection(ConfigurationSettings.AppSettings["conn"]);

		private string VAR_CIF;
		private string VAR_CustomerName;
		private string VAR_NomorTransaksiRekening;
		private string VAR_Jenis;
		private string VAR_Status;
		private string VAR_TglMulaiDay;
		private string VAR_TglMulaiMonth;
		private string VAR_TglMulaiYear;
		private string VAR_TglJatuhTempoDay;
		private string VAR_TglJatuhTempoMonth;
		private string VAR_TglJatuhTempoYear;
		private string VAR_ValutaDasar;
		private string VAR_ValutaLawan;
		private string VAR_NilaiKontrakCurrAsal;
		private string VAR_Kurs;
		private string VAR_NilaiKontrakRp;
		private string VAR_ExposureLimit;
		private string VAR_MarginDeposit;
		private string VAR_PosisiTerbukaDebitur;
		private string VAR_Tujuan;
		private string VAR_JenisHedging;
		private string VAR_UnderlyingVariable;
		private string VAR_GolonganPihakLawan;
		private string VAR_StatusPihakLawan;
		private string VAR_NegaraPihakLawan;
		private string VAR_TagihanSpotDanDerivatif;
		private string VAR_KewajibanSpotDanDerivatif;
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			AllDropDownListInitiation();
			RetrieveSOA();
			VAR_to_CONTROL();
			CheckingError(this, Color.Red);
		}

		private void CheckError()
		{
			string id = "";

			conn2.QueryString = "EXEC DCM_DATA_ERROR_CHECKING '" + Request.QueryString["acctno"] + "','4'";
			conn2.ExecuteQuery();

			for (int i = 0; i < conn2.GetRowCount(); i++)
			{
				string err_msg = conn2.GetFieldValue(i, "ERR_MSG").ToString().Replace(";","");

				conn3.QueryString = "SELECT IDCONTROL FROM DCM_TABLE_ERROR WHERE PAGE = 'TransaksiSpotDerivDataComplet.aspx' AND MESSAGE = '" + err_msg.Trim() + "'";
				conn3.ExecuteQuery();

				if (conn3.GetFieldValue("IDCONTROL") != "")
				{
					id = "LBL_" + conn3.GetFieldValue("IDCONTROL");
					((Label)this.Page.FindControl(id)).ForeColor = Color.Red;
				}
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

		}
		#endregion

		private void CheckingError(Control Page, Color clr)
		{
			/*ini ngeceknya klo kosong doang*/
			string id = "";

			foreach (Control ctrl in Page.Controls)
			{
				if (ctrl is Label)
				{
					id = ctrl.ID;
					id = id.Replace("LBL_","");
					Control ctrlfix = (Control)this.FindControl(id);
						
					if(ctrlfix is DropDownList)
					{
						DropDownList ddl = (DropDownList)this.FindControl(id);
						if(ddl.SelectedValue.ToString().Trim() == "")
						{
							((Label)(ctrl)).ForeColor = clr;
							((Label)(ctrl)).ToolTip = "Harus Diisi !";
						}
					}
					else if(ctrlfix is TextBox)
					{
						TextBox txt = (TextBox)this.FindControl(id);
						if(txt != null)
						{
							if(txt.Text.ToString().Trim() == "")
							{
								((Label)(ctrl)).ForeColor = clr;
								((Label)(ctrl)).ToolTip = "Tidak sesuai dengan data eMas !";
							}
						}
					}
					else if(ctrlfix is RadioButtonList)
					{
						RadioButtonList rdo = (RadioButtonList)this.FindControl(id);
						if(rdo != null)
						{
							if(rdo.SelectedValue.ToString().Trim() == "")
							{
								((Label)(ctrl)).ForeColor = clr;
								((Label)(ctrl)).ToolTip = "Tidak boleh kosong ";
							}
						}
					}
					else
					{
						continue;
					}
				}
				else
				{
					if (ctrl.Controls.Count > 0)
					{
						CheckingError(ctrl, clr);
					}
				}
			}
		}

		private void AllDropDownListInitiation()
		{
			ListItem a = new ListItem("- SELECT -", "");

			DDL_GOLPHKLAWAN.Items.Add(a);
			DDL_JENIS.Items.Add(a);
			DDL_JENIS_HEDGING.Items.Add(a);
			DDL_MM_TGLJTHTEMPO.Items.Add(a);
			DDL_MM_TGLMULAI.Items.Add(a);
			DDL_NGRPHKLAWAN.Items.Add(a);
			DDL_STATUS.Items.Add(a);
			DDL_STTSPHKLAWAN.Items.Add(a);
			DDL_TUJUAN.Items.Add(a);
			DDL_UNDERLYINGVAR.Items.Add(a);
			DDL_VALUTADASAR.Items.Add(a);
			DDL_VALUTALAWAN.Items.Add(a);
		}

		private void RetrieveSOA()
		{
			VAR_CIF = "";
			VAR_CustomerName = "";
			VAR_NomorTransaksiRekening = "";
			VAR_Jenis = "";
			VAR_Status = "";
			VAR_TglMulaiDay = "";
			VAR_TglMulaiMonth = "";
			VAR_TglMulaiYear = "";
			VAR_TglJatuhTempoDay = "";
			VAR_TglJatuhTempoMonth = "";
			VAR_TglJatuhTempoYear = "";
			VAR_ValutaDasar = "";
			VAR_ValutaLawan = "";
			VAR_NilaiKontrakCurrAsal = "";
			VAR_Kurs = "";
			VAR_NilaiKontrakRp = "";
			VAR_ExposureLimit = "";
			VAR_MarginDeposit = "";
			VAR_PosisiTerbukaDebitur = "";
			VAR_Tujuan = "";
			VAR_JenisHedging = "";
			VAR_UnderlyingVariable = "";
			VAR_GolonganPihakLawan = "";
			VAR_StatusPihakLawan = "";
			VAR_NegaraPihakLawan = "";
			VAR_TagihanSpotDanDerivatif = null;
			VAR_KewajibanSpotDanDerivatif = null;
		}

		public void VAR_to_CONTROL()
		{
			TXT_CIF.Text = VAR_CIF;
			TXT_CUSTNAME.Text = VAR_CustomerName;
			TXT_NO_TRANSAKSI.Text = VAR_NomorTransaksiRekening;
			DDL_JENIS.SelectedValue = VAR_Jenis;
			DDL_STATUS.SelectedValue = VAR_Status;
			TXT_DD_TGLMULAI.Text = VAR_TglMulaiDay;
			DDL_MM_TGLMULAI.SelectedValue = VAR_TglMulaiMonth;
			TXT_YY_TGLMULAI.Text = VAR_TglMulaiYear;
			TXT_DD_TGLJTHTEMPO.Text = VAR_TglJatuhTempoDay;
			DDL_MM_TGLJTHTEMPO.SelectedValue = VAR_TglJatuhTempoMonth;
			TXT_YY_TGLJTHTEMPO.Text = VAR_TglJatuhTempoYear;
			DDL_VALUTADASAR.SelectedValue = VAR_ValutaDasar;
			DDL_VALUTALAWAN.SelectedValue = VAR_ValutaLawan;
			TXT_NIKONCURRASAL.Text = VAR_NilaiKontrakCurrAsal;
			TXT_KURS.Text = VAR_Kurs;
			TXT_NILAI_KONTRAK.Text = VAR_NilaiKontrakRp;
			TXT_EKSPOSURLIMIT.Text = VAR_ExposureLimit;
			TXT_MARGINDEPOSIT.Text = VAR_MarginDeposit;
			TXT_POSTERBUKADEBITUR.Text = VAR_PosisiTerbukaDebitur;
			DDL_TUJUAN.SelectedValue = VAR_Tujuan;
			DDL_JENIS_HEDGING.SelectedValue = VAR_JenisHedging;
			DDL_UNDERLYINGVAR.SelectedValue = VAR_UnderlyingVariable;
			DDL_GOLPHKLAWAN.SelectedValue = VAR_GolonganPihakLawan;
			DDL_STTSPHKLAWAN.SelectedValue = VAR_StatusPihakLawan;
			DDL_NGRPHKLAWAN.SelectedValue = VAR_NegaraPihakLawan;
			RDO_TGHNSPOTDERIVATIF.SelectedValue = VAR_TagihanSpotDanDerivatif;
			RDO_KWJBNPOTDERIVATIF.SelectedValue = VAR_KewajibanSpotDanDerivatif;
		}

		public void CONTROL_to_VAR()
		{
			VAR_CIF = TXT_CIF.Text.ToString();
			VAR_CustomerName = TXT_CUSTNAME.Text.ToString();
			VAR_NomorTransaksiRekening = TXT_NO_TRANSAKSI.Text.ToString();
			VAR_Jenis = DDL_JENIS.SelectedValue.ToString();
			VAR_Status = DDL_STATUS.SelectedValue.ToString();
			VAR_TglMulaiDay = TXT_DD_TGLMULAI.Text.ToString();
			VAR_TglMulaiMonth = DDL_MM_TGLMULAI.SelectedValue.ToString();
			VAR_TglMulaiYear = TXT_YY_TGLMULAI.Text.ToString();
			VAR_TglJatuhTempoDay = TXT_DD_TGLJTHTEMPO.Text.ToString();
			VAR_TglJatuhTempoMonth = DDL_MM_TGLJTHTEMPO.SelectedValue.ToString();
			VAR_TglJatuhTempoYear = TXT_YY_TGLJTHTEMPO.Text.ToString();
			VAR_ValutaDasar = DDL_VALUTADASAR.SelectedValue.ToString();
			VAR_ValutaLawan = DDL_VALUTALAWAN.SelectedValue.ToString();
			VAR_NilaiKontrakCurrAsal = TXT_NIKONCURRASAL.Text.ToString();
			VAR_Kurs = TXT_KURS.Text.ToString();
			VAR_NilaiKontrakRp = TXT_NILAI_KONTRAK.Text.ToString();
			VAR_ExposureLimit = TXT_EKSPOSURLIMIT.Text.ToString();
			VAR_MarginDeposit = TXT_MARGINDEPOSIT.Text.ToString();
			VAR_PosisiTerbukaDebitur = TXT_POSTERBUKADEBITUR.Text.ToString();
			VAR_Tujuan = DDL_TUJUAN.SelectedValue.ToString();
			VAR_JenisHedging = DDL_JENIS_HEDGING.SelectedValue.ToString();
			VAR_UnderlyingVariable = DDL_UNDERLYINGVAR.SelectedValue.ToString();
			VAR_GolonganPihakLawan = DDL_GOLPHKLAWAN.SelectedValue.ToString();
			VAR_StatusPihakLawan = DDL_STTSPHKLAWAN.SelectedValue.ToString();
			VAR_NegaraPihakLawan = DDL_NGRPHKLAWAN.SelectedValue.ToString();
			VAR_TagihanSpotDanDerivatif = RDO_TGHNSPOTDERIVATIF.SelectedValue.ToString();
			VAR_KewajibanSpotDanDerivatif = RDO_KWJBNPOTDERIVATIF.SelectedValue.ToString();
		}

		protected void BTN_BACK_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			Response.Redirect("TreasuryDataCompleteList.aspx?tc=" + Request.QueryString["tc"] + "&mc=" + Request.QueryString["mc"] );
		}
	}
}
