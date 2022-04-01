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
using System.Configuration;

namespace SME.CreditChanneling
{
	/// <summary>
	/// Summary description for NasabahDetail.
	/// </summary>
	public partial class NasabahDetail : System.Web.UI.Page
	{
		/// ahmad:
		/// tambah view dan store prosedure berikut:
		/// CHANN_BPR_MANUALRESULT_SAVE
		/// VW_CHANN_BPR_MANUALRESULT
		
		protected System.Web.UI.WebControls.Label LBL_ACCEPT;
		
	
		#region My Variables
		protected Connection conn;
		protected Tools tool = new Tools();
		private string batchno, accept, parent, nonas, curef, regno, batchseq;
		#endregion

		protected void Page_Load(object sender, System.EventArgs e)
		{
			conn	= new Connection((string)Session["ConnString"]);

			batchno = Request.QueryString["batchno"];
			accept	= Request.QueryString["accept"];
			parent	= Request.QueryString["parent"];
			nonas	= Request.QueryString["nonas"];
			curef 	= Request.QueryString["curef"];
			regno	= Request.QueryString["regno"];
			batchseq = Request.QueryString["batchseq"];

			if (!IsPostBack) 
			{
				LBL_BATCHNO.Text	= Request.QueryString["batchno"];
				LBL_ACCEPT.Text		= Request.QueryString["accept"];
				LBL_PARENT.Text		= Request.QueryString["parent"];
				//TXT_NONAS.Text		= Request.QueryString["nonas"];
				LBL_TC.Text = Request.QueryString["tc"];
				LBL_MC.Text = Request.QueryString["mc"];
		
				fillDDL();
				fillMonths();
				fillKondisi();
				fillTujuanPenggunaan();
				cekReject();
				viewData();
				cekMandatoryFields();
				disableFields();		//Kalau sudah scoring, disable semua field
			}

			BTN_SAVE.Attributes.Add("onclick", "if(!cek_mandatory(document.Form1)){return false;}");

//			if (LBL_ACCEPT.Text == "1" || LBL_ACCEPT.Text == "2")
			if (Request.QueryString["score"] == "yes")
			{
				ddl_RejectMan.Visible = true;
				btn_RejectMan.Visible = true;
				grd_RejectMan.Visible = true;

				ddl_RejectMan.Enabled = true;
				btn_RejectMan.Enabled = true;
				grd_RejectMan.Enabled = true;

				cekRejectManually();
				BTN_SAVE.Visible = false;
			}


			if (Request.QueryString["score"] == "yes")
			{
				DatGrd.Visible = true;
				//DatGrdCompRvw.Visible = true;
			}

		}

		#region My Method

		private void fillDDL()
		{
			GlobalTools.fillRefList(ddl_RejectMan,"select reasonid,reasondesc from rfreason where reasontype = 5 and active = 1",false,conn);
		}

		private void fillMonths() 
		{
			GlobalTools.initDateForm(TXT_CH_TGLAHIR_DAY, DDL_CH_TGLAHIR, TXT_CH_TGLAHIR_YEAR);
			GlobalTools.initDateForm(TXT_CH_TGPK_DAY, DDL_CH_TGPK, TXT_CH_TGPK_YEAR);
		}

		private DataTable getMandatoryColumns() 
		{
			conn.QueryString = "select * from VW_CHANN_MANDATORYFIELD where CH_BPR_CUREF = '" + curef + "'";
			conn.ExecuteQuery();

			DataTable dt = conn.GetDataTable().Copy();

			return dt;
		}

		private void cekMandatoryFields() 
		{
			DataTable dtManCol = getMandatoryColumns();
			
			for(int i=0; i<dtManCol.Rows.Count; i++) 
			{
				TextBox TXT_MANDATORY = (TextBox) this.Page.FindControl("TXT_" + dtManCol.Rows[i]["CH_PRM_FIELD"].ToString());
				try 
				{
					TXT_MANDATORY.CssClass = "mandatory";
				} 
				catch 
				{
					DropDownList DDL_MANDATORY = (DropDownList) this.Page.FindControl("DDL_" + dtManCol.Rows[i]["CH_PRM_FIELD"].ToString());
					DDL_MANDATORY.CssClass = "mandatory";

					try 
					{
						TextBox TXT_MAND_DAY = (TextBox) this.Page.FindControl("TXT_" + dtManCol.Rows[i]["CH_PRM_FIELD"].ToString() + "_DAY");
						TextBox TXT_MAND_YEAR = (TextBox) this.Page.FindControl("TXT_" + dtManCol.Rows[i]["CH_PRM_FIELD"].ToString() + "_YEAR");

						TXT_MAND_DAY.CssClass = "mandatory";
						TXT_MAND_YEAR.CssClass = "mandatory";
					} 
					catch 
					{
					}
				}
			}
		}

		private void disableFields() 
		{
			// Artinya sudah scoring, maka disable semua field
			if (LBL_ACCEPT.Text == "0" || LBL_ACCEPT.Text == "1") 
			{
				BTN_SAVE.Visible = false;

				System.Web.UI.ControlCollection coll = this.Page.Controls;
				for (int i = 0; i < coll[4].Controls.Count; i++) 
				{
					if (coll[4].Controls[i] is TextBox) 
					{
						TextBox txt = (TextBox) coll[4].Controls[i];
						txt.ReadOnly = true;
					}
					else if (coll[4].Controls[i] is DropDownList) 
					{
						DropDownList ddl = (DropDownList) coll[4].Controls[i];
						ddl.Enabled = false;
					}
					else if (coll[4].Controls[i] is Button)
					{
						Button btn = (Button) coll[4].Controls[i];
						btn.Visible = false;
					}
					else if (coll[4].Controls[i] is RadioButtonList) 
					{
						RadioButtonList rbl = (RadioButtonList) coll[4].Controls[i];
						rbl.Enabled = false;
					}
					else if (coll[4].Controls[i] is RadioButton) 
					{
						RadioButton rb = (RadioButton) coll[4].Controls[i];
						rb.Enabled = false;
					}
					else if (coll[4].Controls[i] is CheckBox)
					{
						CheckBox cb = (CheckBox) coll[4].Controls[i];
						cb.Enabled = false;
					}					
					else if (coll[4].Controls[i] is HtmlTableRow) 
					{
						HtmlTableRow htr = (HtmlTableRow) coll[4].Controls[i];

						for (int j=0; j < htr.Controls.Count; j++) 
						{							
							for (int jj = 0; jj < htr.Controls[j].Controls.Count; jj++) 
							{
								if (htr.Controls[j].Controls[jj] is TextBox) 
								{
									TextBox txt = (TextBox) htr.Controls[j].Controls[jj];
									txt.ReadOnly = true;
								}
								else if (htr.Controls[j].Controls[jj] is DropDownList) 
								{
									DropDownList ddl = (DropDownList) htr.Controls[j].Controls[jj];
									ddl.Enabled = false;
								}
								else if (htr.Controls[j].Controls[jj] is Button)
								{
									Button btn = (Button) htr.Controls[j].Controls[jj];
									//btn.Enabled = false;
									btn.Visible = false;
								}
								else if (htr.Controls[j].Controls[jj] is RadioButtonList) 
								{
									RadioButtonList rbl = (RadioButtonList) htr.Controls[j].Controls[jj];
									rbl.Enabled = false;
								}
								else if (htr.Controls[j].Controls[jj] is RadioButton) 
								{
									RadioButton rb = (RadioButton) htr.Controls[j].Controls[jj];
									rb.Enabled = false;
								}
								else if (htr.Controls[j].Controls[jj] is CheckBox)
								{
									CheckBox cb = (CheckBox) htr.Controls[j].Controls[jj];
									cb.Enabled = false;
								}					
							}
						}
					}
				}
			}
		}
		private void fillKondisi() 
		{
			GlobalTools.fillRefList(DDL_CH_KOND_CODE, "select * from RFKONDISI_BRG where ACTIVE = '1'", false, conn);
		}

		private void fillTujuanPenggunaan() 
		{
			GlobalTools.fillRefList(DDL_CH_TUJ_CODE, "select * from RFTUJUANPENGGUNAAN where ACTIVE = '1'", false, conn);
		}

		private void viewData() 
		{
			try 
			{
//				conn.QueryString = "select * from VW_CHANN_CUST_LIST " + 
//					" where NONAS='" + TXT_NONAS.Text.Trim() + "' and batchno = '" + batchno + "' and batchseq = '" + batchseq + "'";
				conn.QueryString = "select * from VW_CHANN_CUST_LIST " + 
					" where batchno = '" + batchno + "' and batchseq = '" + batchseq + "'";
				conn.ExecuteQuery();
			} 
			catch (NullReferenceException) 
			{
				GlobalTools.popMessage(this, "Connection Error !");
				Response.Redirect("../Login.aspx?expire=1");
			}
			
			try
			{	TXT_NONAS.Text = conn.GetFieldValue("NONAS"); }
			catch{};

			try
			{	TXT_CH_NAMA.Text = conn.GetFieldValue("CH_NAMA"); }
			catch{};

			try 
			{ TXT_CH_ALAMAT.Text = conn.GetFieldValue("CH_ALAMAT"); }
			catch{};

			try { TXT_CH_IDENTITAS.Text = conn.GetFieldValue("CH_IDENTITAS"); }
			catch{};

			//TXT_CH_TGLAHIR.Text = tool.FormatDate(conn.GetFieldValue("CH_TGLAHIR"), false);
			try {TXT_CH_TGLAHIR_DAY.Text = tool.FormatDate_Day(conn.GetFieldValue("CH_TGLAHIR"));}
			catch{};
			try {DDL_CH_TGLAHIR.SelectedValue = tool.FormatDate_Month(conn.GetFieldValue("CH_TGLAHIR"));}
			catch{};
			try {TXT_CH_TGLAHIR_YEAR.Text = tool.FormatDate_Year(conn.GetFieldValue("CH_TGLAHIR"));}
			catch{};

			try {TXT_CH_LIMIT.Text = tool.MoneyFormat(conn.GetFieldValue("CH_LIMIT"));}
			catch{};
			try {TXT_CH_HARGABELI.Text = tool.MoneyFormat(conn.GetFieldValue("CH_HARGABELI"));}
			catch{};
			try {TXT_CH_SBUN.Text = conn.GetFieldValue("CH_SBUN");}
			catch{};
			try {TXT_CH_JW.Text = conn.GetFieldValue("CH_JW");}
			catch{};
			try {TXT_CH_JB.Text = conn.GetFieldValue("CH_JB");}
			catch{};
			try {TXT_CH_MERKB.Text = conn.GetFieldValue("CH_MERKB");}
			catch{};
			try {TXT_CH_TYPE.Text = conn.GetFieldValue("CH_TYPE");}
			catch{};
			try {TXT_CH_TAHUN.Text = conn.GetFieldValue("CH_TAHUN");}
			catch{};
			try {TXT_CH_NORANGKA.Text = conn.GetFieldValue("CH_NORANGKA");}
			catch{};
			try {TXT_CH_NOMESIN.Text = conn.GetFieldValue("CH_NOMESIN");}
			catch{};
			try {TXT_CH_NOPK.Text = conn.GetFieldValue("CH_NOPK");}
			catch{};

			try
			{
				//add by Fajar
				if(Convert.ToInt32(conn.GetFieldValue("CH_JW"))> 0.001)
					TXT_INSTALLMENT.Text= tool.MoneyFormat(Convert.ToString(Convert.ToDouble(conn.GetFieldValue("CH_LIMIT"))/Convert.ToInt32(conn.GetFieldValue("CH_JW"))));
				else
					TXT_INSTALLMENT.Text="";
			}
			catch{}

			//TXT_CH_TGPK.Text = tool.FormatDate(conn.GetFieldValue("CH_TGPK"), false);
			try {TXT_CH_TGPK_DAY.Text = tool.FormatDate_Day(conn.GetFieldValue("CH_TGPK"));}
			catch{};
			try {DDL_CH_TGPK.SelectedValue = tool.FormatDate_Month(conn.GetFieldValue("CH_TGPK"));}
			catch{};
			try {TXT_CH_TGPK_YEAR.Text = tool.FormatDate_Year(conn.GetFieldValue("CH_TGPK"));}
			catch{};

			try {TXT_CH_JDOK.Text = conn.GetFieldValue("CH_JDOK");}
			catch{};
			try {TXT_CH_PENDAPATAN.Text = tool.MoneyFormat(conn.GetFieldValue("CH_PENDAPATAN"));}
			catch{};
			try {TXT_CH_JPTG.Text = conn.GetFieldValue("CH_JPTG");}
			catch{};
			try {TXT_CH_NPTG.Text = GlobalTools.MoneyFormat( conn.GetFieldValue("CH_NPTG") );}
			catch{};
			try {TXT_CH_MKERJA.Text = conn.GetFieldValue("CH_MKERJA");}
			catch{};
			try {DDL_CH_KOND_CODE.SelectedValue = conn.GetFieldValue("CH_KOND_CODE");}
			catch{};
			try {DDL_CH_TUJ_CODE.SelectedValue = conn.GetFieldValue("CH_TUJ_CODE");}
			catch{};
		}

		private void cekReject() 
		{
			//--- kalau berasal dari screen scoring (dengan ditandai dengan query string "accept")
			//--- maka periksa
			if (LBL_ACCEPT.Text.Trim() == "0") 
			{
				DatGrd.Visible = true;

				conn.QueryString = "select * from VW_CHANN_RULERESULT " + 
					"where BATCHNO = '" + batchno + "' and batchseq = '" + batchseq + "'";
				conn.ExecuteQuery();

				DatGrd.DataSource = conn.GetDataTable().DefaultView;
				try 
				{
					DatGrd.DataBind();
				} 
				catch 
				{
					DatGrd.CurrentPageIndex = 0;
					DatGrd.DataBind();
				}
			}
		}


		private void cekRejectManually()
		{
//			if (LBL_ACCEPT.Text == "1" || LBL_ACCEPT.Text == "2")
			if (Request.QueryString["score"] == "yes")
			{
				grd_RejectMan.Visible = true;
				conn.QueryString = "select * from VW_CHANN_BPR_MANUALRESULT " + 
					"where BATCHNO = '"+batchno+"' and CH_BPR_CUREF = '"+curef+"' and batchseq = '" + batchseq + "'";
				conn.ExecuteQuery();

				grd_RejectMan.DataSource = conn.GetDataTable().DefaultView;
				try 
				{
					grd_RejectMan.DataBind();
				} 
				catch 
				{
					grd_RejectMan.CurrentPageIndex = 0;
					grd_RejectMan.DataBind();
				}


			}
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
			this.grd_RejectMan.ItemCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.grd_RejectMan_ItemCommand);

		}
		#endregion



		protected void BTN_BACK_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			Response.Redirect(LBL_PARENT.Text.Trim() + "?tc=" + LBL_TC.Text + "&mc=" + LBL_MC.Text +
				"&nonas=" + Request.QueryString["nonas"] +  "&curef=" + Request.QueryString["curef"] +
				"&regno=" + Request.QueryString["regno"] +  "&parent=" + Request.QueryString["parent"] +
				"&batchno=" + LBL_BATCHNO.Text.Trim() + "&accept=" +
				accept + "&score=" + Request.QueryString["score"] + "&batchseq=" + batchseq);
		}

		protected void BTN_SAVE_Click(object sender, System.EventArgs e)
		{
			//--- VALIDASI INPUT ---//

			//TANGGAL LAHIR
			if (!GlobalTools.isDateValid(TXT_CH_TGLAHIR_DAY.Text.Trim(), DDL_CH_TGLAHIR.SelectedValue, TXT_CH_TGLAHIR_YEAR.Text.Trim())) 
			{
				GlobalTools.popMessage(this, "Tanggal Lahir tidak valid!");
				return;
			}

			//TANGGAL KONTRAK
			if (!GlobalTools.isDateValid(TXT_CH_TGPK_DAY.Text.Trim(), DDL_CH_TGPK.SelectedValue, TXT_CH_TGPK_YEAR.Text.Trim())) 
			{
				GlobalTools.popMessage(this, "Tanggal Kontrak tidak valid!");
				return;
			}
			//----------------------//

		
			try 
			{ 
				conn.QueryString = "exec CHANN_CUST_CHANGE " +
					"" + tool.ConvertNull(TXT_NONAS.Text) + "," +	//-- Nonas
					"" + tool.ConvertNull(TXT_CH_NAMA.Text.Trim()) + "," +	
					"" + tool.ConvertNull(TXT_CH_ALAMAT.Text.Trim()) + "," +
					"" + tool.ConvertNull(TXT_CH_IDENTITAS.Text.Trim()) + "," +
					"" + GlobalTools.ToSQLDate(TXT_CH_TGLAHIR_DAY.Text, DDL_CH_TGLAHIR.SelectedValue, TXT_CH_TGLAHIR_YEAR.Text) + "," +
					"" + tool.ConvertNull(tool.ConvertFloat(TXT_CH_LIMIT.Text.Trim())) + "," +
					"" + tool.ConvertNull(tool.ConvertFloat(TXT_CH_HARGABELI.Text.Trim())) + "," +
					"" + tool.ConvertNull(tool.ConvertFloat(TXT_CH_SBUN.Text.Trim())) + "," +
					"" + tool.ConvertNull(TXT_CH_JW.Text.Trim()) + "," +
					"" + tool.ConvertNull(TXT_CH_JB.Text.Trim()) + "," +
					"" + tool.ConvertNull(TXT_CH_MERKB.Text.Trim()) + "," +
					"" + tool.ConvertNull(TXT_CH_TYPE.Text.Trim())+ "," +
					"" + tool.ConvertNull(TXT_CH_TAHUN.Text.Trim()) + "," +
					"" + tool.ConvertNull(TXT_CH_NORANGKA.Text.Trim()) + "," +
					"" + tool.ConvertNull(TXT_CH_NOMESIN.Text.Trim()) + "," +
					"" + tool.ConvertNull(TXT_CH_NOPK.Text.Trim()) + "," +
					"" + GlobalTools.ToSQLDate(TXT_CH_TGPK_DAY.Text, DDL_CH_TGPK.SelectedValue, TXT_CH_TGPK_YEAR.Text) + "," +
					"" + tool.ConvertNull(TXT_CH_JDOK.Text.Trim()) + "," +
					"" + tool.ConvertNull(tool.ConvertFloat(TXT_CH_PENDAPATAN.Text.Trim())) + "," +
					"" + tool.ConvertNull(TXT_CH_JPTG.Text.Trim()) + "," +
					"" + tool.ConvertNull(tool.ConvertFloat(TXT_CH_NPTG.Text.Trim())) + "," +
					"" + tool.ConvertNull(DDL_CH_KOND_CODE.SelectedValue) + "," +
					"" + tool.ConvertNull(TXT_CH_MKERJA.Text.Trim()) + "," +
					"" + tool.ConvertNull(DDL_CH_TUJ_CODE.SelectedValue) + "," +
					"" + LBL_BATCHNO.Text + "," +	//-- Batchno
					"null," +
					"'" + curef + "'," +
					"'" + batchseq + "', " +
					"'2'";
				conn.ExecuteNonQuery();
			} 
			catch  (Exception ex) 
			{
				Response.Write("<!-- " + ex.Message.Replace("-->", "-)") + " -->");
				GlobalTools.popMessage(this, "Input ada yang tidak valid. \nHarap periksa kembali masukan input!");
				return;
			}
		
			//GlobalTools.popMessage(this, "Data berhasil disimpan !");
			Response.Redirect("NasabahList.aspx?tc=" + LBL_TC.Text + "&mc=" + LBL_MC.Text + "&batchno=" +
				batchno + "&curef=" + curef + "&regno=" + regno);
		}

		protected void btn_RejectMan_Click(object sender, System.EventArgs e)
		{
			if (ddl_RejectMan.SelectedIndex == 0)
			{
				GlobalTools.popMessage(this, "Reject description harus dipilih dulu");
				GlobalTools.SetFocus(this, ddl_RejectMan);

			}
			else
			{
				conn.QueryString = "exec CHANN_BPR_MANUALRESULT_SAVE '1','" + nonas + "','" + batchno + "','" + 
					ddl_RejectMan.SelectedValue + "','5','" + curef + "', '" + batchseq + "'";	
				conn.ExecuteNonQuery();

				cekRejectManually();
			}
		}

		private void grd_RejectMan_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			switch(((LinkButton)e.CommandSource).CommandName)
			{

				case "delete":
					conn.QueryString = "exec CHANN_BPR_MANUALRESULT_SAVE '2','" + e.Item.Cells[0].Text.Trim() + "'," + e.Item.Cells[1].Text.Trim() + ",'" + 
						e.Item.Cells[3].Text.Trim() + "','" + e.Item.Cells[4].Text.Trim() + "','" + e.Item.Cells[2].Text.Trim() + "', '" + batchseq + "'";
					conn.ExecuteNonQuery();
					cekRejectManually();
					break;

			}			

		
		}
	}
}
