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

namespace SME.DCM.DataCompleteness.Trade
{
	/// <summary>
	/// Summary description for LCDataComplet.
	/// </summary>
	public partial class SetorJamDataComplet : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.TextBox TXT_JUMLAH;
		protected Tools tool = new Tools();
		protected Connection conn2 = new Connection(ConfigurationSettings.AppSettings["conn2"]);
		protected Connection conn3 = new Connection(ConfigurationSettings.AppSettings["conn2"]);
		protected Connection conn = new Connection(ConfigurationSettings.AppSettings["conn"]);

		private string VAR_CIF;
		private string VAR_CustomerName;
		private string VAR_JenisValuta;
		private string VAR_NilaiSetoranJaminan;
		private string VAR_TglSetoranJaminanDay;
		private string VAR_TglSetoranJaminanMonth;
		private string VAR_TglSetoranJaminanYear;
		private string VAR_TglBlokirDay;
		private string VAR_TglBlokirMonth;
		private string VAR_TglBlokirYear;
		private string VAR_JenisBlokir;
		private string VAR_NilaiBlokir;
		private string VAR_GolonganPemilik;
		private string VAR_HubunganDenganBank;
		private string VAR_TujuanBerhubunganDgnBank;
		private string VAR_StatusPemilik;
	
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

				conn3.QueryString = "SELECT IDCONTROL FROM DCM_TABLE_ERROR WHERE PAGE = 'SetorJamDataComplet.aspx' AND MESSAGE = '" + err_msg.Trim() + "'";
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


		private void RetrieveSOA()
		{
			VAR_CIF = "";
			VAR_CustomerName = "";
			VAR_JenisValuta = "";
			VAR_NilaiSetoranJaminan = "";
			VAR_TglSetoranJaminanDay = "";
			VAR_TglSetoranJaminanMonth = "";
			VAR_TglSetoranJaminanYear = "";
			VAR_TglBlokirDay = "";
			VAR_TglBlokirMonth = "";
			VAR_TglBlokirYear = "";
			VAR_JenisBlokir = "";
			VAR_NilaiBlokir = "";
			VAR_GolonganPemilik = "";
			VAR_HubunganDenganBank = "";
			VAR_TujuanBerhubunganDgnBank = "";
			VAR_StatusPemilik = "";
		}

		private void AllDropDownListInitiation()
		{
			ListItem a = new ListItem("- SELECT -", "");

			DDL_GOLONGANPMLK.Items.Add(a);
			DDL_HUBDGNBANK.Items.Add(a);
			DDL_JENISBLOKIR.Items.Add(a);
			DDL_JNS_VALUTA.Items.Add(a);
			DDL_MM_TGLBLOKIR.Items.Add(a);
			DDL_MM_TGLSETORJAM.Items.Add(a);
			DDL_STATUSPEMILIK.Items.Add(a);
			DDL_TUJUANBERHUBDGNBANK.Items.Add(a);
		}

		private void VAR_to_CONTROL()
		{
			TXT_CIF.Text = VAR_CIF;
			TXT_NAME.Text = VAR_CustomerName;
			DDL_JNS_VALUTA.SelectedValue = VAR_JenisValuta;
			TXT_NILAI_SETORJAM.Text = VAR_NilaiSetoranJaminan;
			TXT_DD_TGLSETORJAM.Text = VAR_TglSetoranJaminanDay;
			DDL_MM_TGLSETORJAM.SelectedValue = VAR_TglSetoranJaminanMonth;
			TXT_YY_TGLSETORJAM.Text = VAR_TglSetoranJaminanYear;
			TXT_DD_TGLBLOKIR.Text = VAR_TglBlokirDay;
			DDL_MM_TGLBLOKIR.SelectedValue = VAR_TglBlokirMonth;
			TXT_YY_TGLBLOKIR.Text = VAR_TglBlokirYear;
			DDL_JENISBLOKIR.SelectedValue = VAR_JenisBlokir;
			TXT_NILAIBLOKIR.Text = VAR_NilaiBlokir;
			DDL_GOLONGANPMLK.SelectedValue = VAR_GolonganPemilik;
			DDL_HUBDGNBANK.SelectedValue = VAR_HubunganDenganBank;
			DDL_TUJUANBERHUBDGNBANK.SelectedValue = VAR_TujuanBerhubunganDgnBank;
			DDL_STATUSPEMILIK.SelectedValue = VAR_StatusPemilik;
		}

		private void CONTROL_to_VAR()
		{
			VAR_CIF = TXT_CIF.Text.ToString();
			VAR_CustomerName = TXT_NAME.Text.ToString();
			VAR_JenisValuta = DDL_JNS_VALUTA.SelectedValue.ToString();
			VAR_NilaiSetoranJaminan = TXT_NILAI_SETORJAM.Text.ToString();
			VAR_TglSetoranJaminanDay = TXT_DD_TGLSETORJAM.Text.ToString();
			VAR_TglSetoranJaminanMonth = DDL_MM_TGLSETORJAM.SelectedValue.ToString();
			VAR_TglSetoranJaminanYear = TXT_YY_TGLSETORJAM.Text.ToString();
			VAR_TglBlokirDay = TXT_DD_TGLBLOKIR.Text.ToString();
			VAR_TglBlokirMonth = DDL_MM_TGLBLOKIR.SelectedValue.ToString();
			VAR_TglBlokirYear = TXT_YY_TGLBLOKIR.Text.ToString();
			VAR_JenisBlokir = DDL_JENISBLOKIR.SelectedValue.ToString();
			VAR_NilaiBlokir = TXT_NILAIBLOKIR.Text.ToString();
			VAR_GolonganPemilik = DDL_GOLONGANPMLK.SelectedValue.ToString();
			VAR_HubunganDenganBank = DDL_HUBDGNBANK.SelectedValue.ToString();
			VAR_TujuanBerhubunganDgnBank = DDL_TUJUANBERHUBDGNBANK.SelectedValue.ToString();
			VAR_StatusPemilik = DDL_STATUSPEMILIK.SelectedValue.ToString();
		}

		protected void BTN_BACK_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			Response.Redirect("TradeDataCompleteList.aspx?tc=" + Request.QueryString["tc"] + "&mc=" + Request.QueryString["mc"] );
		}

		
	}
}
