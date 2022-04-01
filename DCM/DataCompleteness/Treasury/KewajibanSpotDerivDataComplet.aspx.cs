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
	public partial class KewajibanSpotDerivDataComplet : System.Web.UI.Page
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
		private string VAR_NomorReferensiTranksaksi;
		private string VAR_Jenis;
		private string VAR_Kontrak;
		private string VAR_JenisValuta;
		private string VAR_UnderlyingVariable;
		private string VAR_GolonganPihakLawan;
		private string VAR_HubunganDenganBank;
		private string VAR_StatusPihakLawan;
		private string VAR_NegaraPihakLawan;

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

				conn3.QueryString = "SELECT IDCONTROL FROM DCM_TABLE_ERROR WHERE PAGE = 'KewajibanSpotDerivDataComplet.aspx' AND MESSAGE = '" + err_msg.Trim() + "'";
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
			VAR_NomorReferensiTranksaksi = "";
			VAR_Jenis = "";
			VAR_Kontrak = "";
			VAR_JenisValuta = "";
			VAR_UnderlyingVariable = "";
			VAR_GolonganPihakLawan = "";
			VAR_HubunganDenganBank = "";
			VAR_StatusPihakLawan = "";
			VAR_NegaraPihakLawan = "";
		}

		private void AllDropDownListInitiation()
		{
			ListItem a = new ListItem("- SELECT -", "");

			DDL_GOLPHKLAWAN.Items.Add(a);
			DDL_HUBDGNBANK.Items.Add(a);
			DDL_JENIS.Items.Add(a);
			DDL_JNSVALUTA.Items.Add(a);
			DDL_KONTRAK.Items.Add(a);
			DDL_NGRPHKLAWAN.Items.Add(a);
			DDL_STTSPHKLAWAN.Items.Add(a);
			DDL_UNDERLYINGVAR.Items.Add(a);
		}

		private void VAR_to_CONTROL()
		{
			TXT_CIF.Text = VAR_CIF;
			TXT_CUSTNAME.Text = VAR_CustomerName;
			TXT_NO_TRANSAKSI.Text = VAR_NomorReferensiTranksaksi;
			DDL_JENIS.SelectedValue = VAR_Jenis;
			DDL_KONTRAK.SelectedValue = VAR_Kontrak;
			DDL_JNSVALUTA.SelectedValue = VAR_JenisValuta;
			DDL_UNDERLYINGVAR.SelectedValue = VAR_UnderlyingVariable;
			DDL_GOLPHKLAWAN.SelectedValue = VAR_GolonganPihakLawan;
			DDL_HUBDGNBANK.SelectedValue = VAR_HubunganDenganBank;
			DDL_STTSPHKLAWAN.SelectedValue = VAR_StatusPihakLawan;
			DDL_NGRPHKLAWAN.SelectedValue = VAR_NegaraPihakLawan;
		}

		private void CONTROL_to_VAR()
		{	
			VAR_CIF = TXT_CIF.Text.ToString();
			VAR_CustomerName = TXT_CUSTNAME.Text.ToString();
			VAR_NomorReferensiTranksaksi = TXT_NO_TRANSAKSI.Text.ToString();
			VAR_Jenis = DDL_JENIS.SelectedValue.ToString();
			VAR_Kontrak = DDL_KONTRAK.SelectedValue.ToString();
			VAR_JenisValuta = DDL_JNSVALUTA.SelectedValue.ToString();
			VAR_UnderlyingVariable =DDL_UNDERLYINGVAR.SelectedValue.ToString();
			VAR_GolonganPihakLawan = DDL_GOLPHKLAWAN.SelectedValue.ToString();
			VAR_HubunganDenganBank = DDL_HUBDGNBANK.SelectedValue.ToString();
			VAR_StatusPihakLawan = DDL_STTSPHKLAWAN.SelectedValue.ToString();
			VAR_NegaraPihakLawan = DDL_NGRPHKLAWAN.SelectedValue.ToString();
		}

		protected void BTN_BACK_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			Response.Redirect("TreasuryDataCompleteList.aspx?tc=" + Request.QueryString["tc"] + "&mc=" + Request.QueryString["mc"] );
		}
	}
}
