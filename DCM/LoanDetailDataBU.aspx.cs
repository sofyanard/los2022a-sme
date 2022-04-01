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
	/// Summary description for LoanDetailDataBU.
	/// </summary>
	public partial class LoanDetailDataBU : System.Web.UI.Page
	{
		protected Connection conn2 = new Connection(ConfigurationSettings.AppSettings["conn2"]);
		protected Connection conn = new Connection(ConfigurationSettings.AppSettings["conn"]);
		protected Tools tools = new Tools();
		//protected Connection conn;
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			if(!IsPostBack)
			{
				//conn = (Connection) Session["Connection"];

				DDL_BANK_UTAMA.Items.Add(new ListItem("--Pilih--",""));
				DDL_FACDANA.Items.Add(new ListItem("--Pilih--",""));
				DDL_GOL_PENJAMIN.Items.Add(new ListItem("--Pilih--",""));
				DDL_GOLKREDIT.Items.Add(new ListItem("--Pilih--",""));
				DDL_JNSKREDIT.Items.Add(new ListItem("--Pilih--",""));
				DDL_JNSPENGGUNAAN.Items.Add(new ListItem("--Pilih--",""));
				DDL_KOL_BI.Items.Add(new ListItem("--Pilih--",""));
				DDL_KOL_BM.Items.Add(new ListItem("--Pilih--",""));
				DDL_KSBI1.Items.Add(new ListItem("--Pilih--",""));
				DDL_KSBI2.Items.Add(new ListItem("--Pilih--",""));
				DDL_KSBI3.Items.Add(new ListItem("--Pilih--",""));
				DDL_KSBI4.Items.Add(new ListItem("--Pilih--",""));
				DDL_LOKASI_PROYEK.Items.Add(new ListItem("--Pilih--",""));
				DDL_ORIENTASI_PENGGUNAAN.Items.Add(new ListItem("--Pilih--",""));
				DDL_SIFATKREDIT.Items.Add(new ListItem("--Pilih--",""));
				
				conn2.QueryString = "SELECT * FROM VW_LOANBU_BANK_UTAMA_SINDIKASI";
				conn2.ExecuteQuery();
				for (int i=0; i < conn2.GetRowCount(); i++)
				{
					DDL_BANK_UTAMA.Items.Add(new ListItem(conn2.GetFieldValue(i,1),conn2.GetFieldValue(i,0)));
				}

				conn2.QueryString = "SELECT * FROM VW_LOANBU_FAC_DANA";
				conn2.ExecuteQuery();
				for (int i=0; i < conn2.GetRowCount(); i++)
				{
					DDL_FACDANA.Items.Add(new ListItem(conn2.GetFieldValue(i,1),conn2.GetFieldValue(i,0)));
				}

				conn2.QueryString = "SELECT * FROM VW_LOANBU_GOL_PENJAMIN";
				conn2.ExecuteQuery();
				for (int i=0; i < conn2.GetRowCount(); i++)
				{
					DDL_GOL_PENJAMIN.Items.Add(new ListItem(conn2.GetFieldValue(i,1),conn2.GetFieldValue(i,0)));
				}

				conn2.QueryString = "SELECT * FROM VW_LOANBU_GOL_KREDIT";
				conn2.ExecuteQuery();
				for (int i=0; i < conn2.GetRowCount(); i++)
				{
					DDL_GOLKREDIT.Items.Add(new ListItem(conn2.GetFieldValue(i,1),conn2.GetFieldValue(i,0)));
				}

				conn2.QueryString = "SELECT * FROM VW_LOANBU_JNS_KREDIT";
				conn2.ExecuteQuery();
				for (int i=0; i < conn2.GetRowCount(); i++)
				{
					DDL_JNSKREDIT.Items.Add(new ListItem(conn2.GetFieldValue(i,1),conn2.GetFieldValue(i,0)));
				}

				conn2.QueryString = "SELECT * FROM VW_LOANBU_JNS_PENGGUNAAN";
				conn2.ExecuteQuery();
				for (int i=0; i < conn2.GetRowCount(); i++)
				{
					DDL_JNSPENGGUNAAN.Items.Add(new ListItem(conn2.GetFieldValue(i,1),conn2.GetFieldValue(i,0)));
				}

				conn2.QueryString = "SELECT * FROM VW_LOANBU_KOL_BI";
				conn2.ExecuteQuery();
				for (int i=0; i < conn2.GetRowCount(); i++)
				{
					DDL_KOL_BI.Items.Add(new ListItem(conn2.GetFieldValue(i,1),conn2.GetFieldValue(i,0)));
				}

				conn2.QueryString = "SELECT * FROM VW_LOANBU_KOL_BM";
				conn2.ExecuteQuery();
				for (int i=0; i < conn2.GetRowCount(); i++)
				{
					DDL_KOL_BM.Items.Add(new ListItem(conn2.GetFieldValue(i,1),conn2.GetFieldValue(i,0)));
				}

				conn2.QueryString = "SELECT * FROM VW_LOANBU_KSEBI1";
				conn2.ExecuteQuery();
				for (int i=0; i < conn2.GetRowCount(); i++)
				{
					DDL_KSBI1.Items.Add(new ListItem(conn2.GetFieldValue(i,1),conn2.GetFieldValue(i,0)));
				}

				conn2.QueryString = "SELECT * FROM VW_LOANBU_LOKASI_PROYEK";
				conn2.ExecuteQuery();
				for (int i=0; i < conn2.GetRowCount(); i++)
				{
					DDL_LOKASI_PROYEK.Items.Add(new ListItem(conn2.GetFieldValue(i,1),conn2.GetFieldValue(i,0)));
				}

				conn2.QueryString = "SELECT * FROM VW_LOANBU_ORIENTASI_PENGGUNAAN";
				conn2.ExecuteQuery();
				for (int i=0; i < conn2.GetRowCount(); i++)
				{
					DDL_ORIENTASI_PENGGUNAAN.Items.Add(new ListItem(conn2.GetFieldValue(i,1),conn2.GetFieldValue(i,0)));
				}

				conn2.QueryString = "SELECT * FROM VW_LOANBU_SIFAT_KREDIT";
				conn2.ExecuteQuery();
				for (int i=0; i < conn2.GetRowCount(); i++)
				{
					DDL_SIFATKREDIT.Items.Add(new ListItem(conn2.GetFieldValue(i,1),conn2.GetFieldValue(i,0)));
				}

				if(Request.QueryString["acc"]!="" && Request.QueryString["acc"]!= null)
				{
					conn2.QueryString = "select error_msg from perkreditan where acctno='" + Request.QueryString["acc"] + "'";
					conn2.ExecuteQuery();

					TXT_ERROR_MSG.Text = conn2.GetFieldValue("error_msg");

					conn2.QueryString = "select * from pending_loan_bu where ac_act#='" + Request.QueryString["acc"] + "' and flag in ('0','1')";
					conn2.ExecuteQuery();

					if(conn2.GetRowCount()>0)
					{
						try{ DDL_BANK_UTAMA.SelectedValue= conn2.GetFieldValue("AC_BANK_UTAMASINDIKASI");}
						catch{DDL_BANK_UTAMA.SelectedValue = "";}
						try{ DDL_FACDANA.SelectedValue= conn2.GetFieldValue("AC_FAS_PENYEDIAAN_DANA");}
						catch{DDL_FACDANA.SelectedValue = "";}
						try{ DDL_GOL_PENJAMIN.SelectedValue= conn2.GetFieldValue("AC_GOL_PENJAMIN");}
						catch{DDL_GOL_PENJAMIN.SelectedValue = "";}
						try{ DDL_GOLKREDIT.SelectedValue= conn2.GetFieldValue("AC_GOL_KREDIT");}
						catch{DDL_GOLKREDIT.SelectedValue = "";}
						try{ DDL_JNSKREDIT.SelectedValue= conn2.GetFieldValue("AC_JENIS_KREDIT");}
						catch{DDL_JNSKREDIT.SelectedValue = "";}
						try{ DDL_JNSPENGGUNAAN.SelectedValue= conn2.GetFieldValue("AC_JENIS_PENGGUNAAN");}
						catch{DDL_JNSPENGGUNAAN.SelectedValue = "";}
						try{ DDL_KOL_BI.SelectedValue= conn2.GetFieldValue("AC_BIKOLE");}
						catch{DDL_KOL_BI.SelectedValue = "";}
						try{ DDL_KOL_BM.SelectedValue= conn2.GetFieldValue("AC_BMKOLE");}
						catch{DDL_KOL_BM.SelectedValue = "";}
						try{ DDL_LOKASI_PROYEK.SelectedValue= conn2.GetFieldValue("AC_LOKASI_PROJECT");}
						catch{DDL_LOKASI_PROYEK.SelectedValue = "";}
						try{ DDL_ORIENTASI_PENGGUNAAN.SelectedValue= conn2.GetFieldValue("AC_ORIENTASI");}
						catch{DDL_ORIENTASI_PENGGUNAAN.SelectedValue = "";}
						try{ DDL_SIFATKREDIT.SelectedValue= conn2.GetFieldValue("AC_SIFAT_CREDIT");}
						catch{DDL_SIFATKREDIT.SelectedValue = "";}
						TXT_NILAI_PROYEK.Text = conn2.GetFieldValue("AC_PROJECT_VALUE");
						TXT_ADD_PROYEK.Text = conn2.GetFieldValue("AC_PROJECT_ADDRESS");
						TXT_JAMINAN.Text = conn2.GetFieldValue("AC_BAGIAN_DIJAMIN");

						TXT_NILAI_PROYEK.Text = tools.MoneyFormat(TXT_NILAI_PROYEK.Text);
						TXT_JAMINAN.Text = tools.MoneyFormat(TXT_JAMINAN.Text);

						FillKSEBI3();
						FillKSEBI4();

						conn2.QueryString = "select * from pending_loan_bu where ac_act#='" + Request.QueryString["acc"] + "' and flag in ('0','1')";
						conn2.ExecuteQuery();

						try{ DDL_KSBI3.SelectedValue= conn2.GetFieldValue("AC_KSEBI3");}
						catch{DDL_KSBI3.SelectedValue = "";}
						try{ DDL_KSBI4.SelectedValue= conn2.GetFieldValue("AC_KSEBI4");}
						catch{DDL_KSBI4.SelectedValue = "";}
					}
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

		private void FillKSEBI2()
		{
			DDL_KSBI2.Items.Clear();
			DDL_KSBI2.Items.Add(new ListItem("--Pilih--",""));
			
			if(DDL_KSBI1.SelectedValue!="")
			{
				conn2.QueryString = "SELECT * FROM VW_LOANBU_KSEBI2 WHERE BM_CODE='" + DDL_KSBI1.SelectedValue + "'";
				conn2.ExecuteQuery();
				for (int i=0; i < conn2.GetRowCount(); i++)
				{
					DDL_KSBI2.Items.Add(new ListItem(conn2.GetFieldValue(i,1),conn2.GetFieldValue(i,0)));
				}
			}
			else
			{
				conn2.QueryString = "SELECT * FROM VW_LOANBU_KSEBI2";
				conn2.ExecuteQuery();
				for (int i=0; i < conn2.GetRowCount(); i++)
				{
					DDL_KSBI2.Items.Add(new ListItem(conn2.GetFieldValue(i,1),conn2.GetFieldValue(i,0)));
				}
			}
		}

		private void FillKSEBI3()
		{
			DDL_KSBI3.Items.Clear();
			DDL_KSBI3.Items.Add(new ListItem("--Pilih--",""));
			
			if(DDL_KSBI2.SelectedValue!="")
			{
				conn2.QueryString = "SELECT * FROM VW_LOANBU_KSEBI3 WHERE BMSUB_CODE='" + DDL_KSBI2.SelectedValue + "'";
				conn2.ExecuteQuery();
				for (int i=0; i < conn2.GetRowCount(); i++)
				{
					DDL_KSBI3.Items.Add(new ListItem(conn2.GetFieldValue(i,1),conn2.GetFieldValue(i,0)));
				}
			}
			else
			{
				conn2.QueryString = "SELECT * FROM VW_LOANBU_KSEBI3";
				conn2.ExecuteQuery();
				for (int i=0; i < conn2.GetRowCount(); i++)
				{
					DDL_KSBI3.Items.Add(new ListItem(conn2.GetFieldValue(i,1),conn2.GetFieldValue(i,0)));
				}
			}
		}

		private void FillKSEBI4()
		{
			DDL_KSBI4.Items.Clear();
			DDL_KSBI4.Items.Add(new ListItem("--Pilih--",""));
			
			if(DDL_KSBI3.SelectedValue!="")
			{
				conn2.QueryString = "SELECT * FROM VW_LOANBU_KSEBI4 WHERE 1=1"; // <-- kriteria masih salah
				conn2.ExecuteQuery();
				for (int i=0; i < conn2.GetRowCount(); i++)
				{
					DDL_KSBI4.Items.Add(new ListItem(conn2.GetFieldValue(i,1),conn2.GetFieldValue(i,0)));
				}
			}
			else
			{
				conn2.QueryString = "SELECT * FROM VW_LOANBU_KSEBI4";
				conn2.ExecuteQuery();
				for (int i=0; i < conn2.GetRowCount(); i++)
				{
					DDL_KSBI4.Items.Add(new ListItem(conn2.GetFieldValue(i,1),conn2.GetFieldValue(i,0)));
				}
			}
		}

		protected void DDL_KSBI1_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			FillKSEBI2();
		}

		protected void DDL_KSBI2_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			FillKSEBI3();
		}

		protected void DDL_KSBI3_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			FillKSEBI4();
		}

		protected void BTN_SAVE_Click(object sender, System.EventArgs e)
		{
			string pesan="";

			try
			{
				conn2.QueryString = "EXEC DQM_LOAN_BU_INSERT '" + 
					DDL_SIFATKREDIT.SelectedValue + "', '" +
					DDL_JNSPENGGUNAAN.SelectedValue + "', '" +
					DDL_ORIENTASI_PENGGUNAAN.SelectedValue + "', '" +
					DDL_GOLKREDIT.SelectedValue + "', '" +
					DDL_JNSKREDIT.SelectedValue + "', '" +
					DDL_FACDANA.SelectedValue + "', '" +
					DDL_BANK_UTAMA.SelectedValue + "', '" +
					DDL_LOKASI_PROYEK.SelectedValue + "', " +
					float.Parse(TXT_NILAI_PROYEK.Text) + ", '" +
					TXT_ADD_PROYEK.Text + "', '" +
					DDL_GOL_PENJAMIN.SelectedValue + "', " +
					float.Parse(TXT_JAMINAN.Text) + ", '" +
					DDL_KOL_BI.SelectedValue + "', '" +
					DDL_KOL_BM.SelectedValue + "', '" +
					DDL_KSBI3.SelectedValue + "', '" +
					DDL_KSBI4.SelectedValue + "', '" +
					Request.QueryString["acc"] + "', '0', '" + 
					Request.QueryString["from_appr"] + "', '" +
					Session["UserID"].ToString() + "', '" +
					Session["FullName"].ToString() + "'";
				conn2.ExecuteQuery();

				pesan = "Data berhasil di simpan";
			}
			catch
			{
				pesan = "Data gagal disimpan, silahkan ulangi kembali!";
			}
			
			if(Request.QueryString["from_appr"]!="" && Request.QueryString["from_appr"]!= null)
			{
				Response.Redirect("LoanListDataApprovalBU.aspx?msg=" + pesan);
			}
			else
			{
				Response.Redirect("LoanListDataBU.aspx?msg=" + pesan);
			}
		}

		protected void TXT_NILAI_PROYEK_TextChanged(object sender, System.EventArgs e)
		{
			TXT_NILAI_PROYEK.Text = tools.MoneyFormat(TXT_NILAI_PROYEK.Text);
		}

		protected void TXT_JAMINAN_TextChanged(object sender, System.EventArgs e)
		{
			TXT_JAMINAN.Text = tools.MoneyFormat(TXT_JAMINAN.Text);
		}
	}
}
