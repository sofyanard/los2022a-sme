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
using DMS.DBConnection;
using DMS.CuBESCore;	

namespace SME.InitialDataEntry
{
	/// <summary>
	/// Summary description for PermohonanBaru.
	/// </summary>
	public partial class PermohonanBaru : System.Web.UI.Page
	{
			
		#region "My Variables "
		protected Tools tool = new Tools();
		protected Connection conn;
		protected DataTable dtColl;
		protected string APPTYPE, PROG, REGNO, CUREF, TC, MC, PROD, KET_CODE, view;
		//20070725 add by sofyan for alih debitur
		protected string alihdeb;
		#endregion



		protected void Page_Load(object sender, System.EventArgs e)
		{
            //pundi 
            TR_COLL.Visible = false;
			conn = (Connection) Session["Connection"];

			APPTYPE			= Request.QueryString["app"];
			PROG			= Request.QueryString["prog"];
			PROD			= Request.QueryString["prod"];
			REGNO			= Request.QueryString["regno"];
			CUREF			= Request.QueryString["curef"];
			KET_CODE		= Request.QueryString["ket_code"];
			TC				= Request.QueryString["tc"];
			MC				= Request.QueryString["mc"];
			view			= Request.QueryString["view"];			//optional!


			/***
			 * //TODO : temporary turned off !
			if (!Logic.AllowAccess(Session["GroupID"].ToString(), Request.QueryString["mc"], conn))
				Response.Redirect("/SME/Restricted.aspx");
			***/
			
			cekIsView(view);

			if (!IsPostBack)
			{
				viewExchangeRate();

				LBL_MAINREGNO.Text		= Request.QueryString["mainregno"];		//optional!, berasal dari sub app (DE)
				LBL_MAINPROD_SEQ.Text	= Request.QueryString["mainprod_seq"];	//optional!, berasal dari sub app (DE)
				LBL_MAINPRODUCTID.Text	= Request.QueryString["mainproductid"];	//idem

				LBL_USERID.Text	 = Session["UserID"].ToString();

				DDL_CL_TYPE.Items.Add(new ListItem("- PILIH -", ""));
				DDL_CP_LOANPURPOSE.Items.Add(new ListItem("- PILIH -", ""));
				DDL_PRODUCTID.Items.Add(new ListItem("- PILIH -", ""));
				DDL_CL_TYPE_EXISTING.Items.Add(new ListItem("- PILIH -", "0"));
				DDL_CP_TENORCODE.Items.Add(new ListItem("- PILIH -", ""));
				DDL_CL_CURRENCY.Items.Add(new ListItem("- PILIH -", ""));
				DDL_CL_COLCLASSIFY.Items.Add(new ListItem("- PILIH -", ""));

				GlobalTools.fillRefList(DDL_PROJECT_CODE, "select * from VW_RFPROJECT where ACTIVE = '1'", false, conn);

				conn.QueryString = "select apptypeid, apptypedesc from rfapplicationtype where active='1'";
				conn.ExecuteQuery();
				for (int i = 0; i < conn.GetRowCount(); i++)
					DDL_APPTYPE.Items.Add(new ListItem(conn.GetFieldValue(i,1), conn.GetFieldValue(i,0)));

				//--- Jenis Jaminan
				conn.QueryString = "select COLTYPESEQ, COLTYPEID + ' - ' + COLTYPEDESC as COLTYPEDESC from RFCOLLATERALTYPE where ACTIVE='1' order by COLTYPEID";
				conn.ExecuteQuery();
				for (int i = 0; i < conn.GetRowCount(); i++)
					DDL_CL_TYPE.Items.Add(new ListItem(conn.GetFieldValue(i,1), conn.GetFieldValue(i,0)));

				//--- Tujuan Penggunaan
				conn.QueryString = "select LOANPURPID, LOANPURPID + ' - ' + LOANPURPDESC as LOANPURPDESC from RFLOANPURPOSE where ACTIVE='1' order by LOANPURPID";
				conn.ExecuteQuery();
				for (int i = 0; i < conn.GetRowCount(); i++)
					DDL_CP_LOANPURPOSE.Items.Add(new ListItem(conn.GetFieldValue(i,1), conn.GetFieldValue(i,0)));

				//--- Product
				//===KALAU PUNYA MAINREGNO, BERARTI PAGE INI DIPANGGIL OLEH SUBAPP (DE)===//
				if (LBL_MAINREGNO.Text != "" && LBL_MAINREGNO.Text != null) 
				{
					conn.QueryString = "select PRODUCTID, PRODUCTDESC from VW_PROGPROD where PROGRAMID='" + Request.QueryString["prog"] + "' and ACTIVE='1' and ISSUBAPPPROD = '1'";

					// untuk sub application, tidak ada earmarking
					DDL_PROJECT_CODE.Enabled = false;
				}
				else				
					conn.QueryString = "select PRODUCTID, PRODUCTDESC from VW_PROGPROD where PROGRAMID='" + Request.QueryString["prog"] + "' and ACTIVE='1'";
				conn.ExecuteQuery();
				for (int i = 0; i < conn.GetRowCount(); i++)
					DDL_PRODUCTID.Items.Add(new ListItem(conn.GetFieldValue(i,0) + " - " + conn.GetFieldValue(i,1), conn.GetFieldValue(i,0)));

				try {DDL_APPTYPE.SelectedValue	= Request.QueryString["app"];}
				catch {DDL_APPTYPE.SelectedValue = "";}
				try {DDL_PRODUCTID.SelectedValue = Request.QueryString["prod"];}
				catch {DDL_PRODUCTID.SelectedValue = "";}

				conn.QueryString = "select tenorcode, tenordesc from rftenorcode where active='1'";
				conn.ExecuteQuery();
				for (int i = 0; i < conn.GetRowCount(); i++)
					DDL_CP_TENORCODE.Items.Add(new ListItem(conn.GetFieldValue(i,1), conn.GetFieldValue(i,0)));
				try
				{
					DDL_CP_TENORCODE.SelectedValue = "M";
				}
				catch
				{
				}

				//--- Mata Uang
				//conn.QueryString = "select currencyid, currencyid+' - '+currencydesc from rfcurrency where active='1' order by currencyid";
				conn.QueryString = "select currencyid, currencydesc from rfcurrency where active='1' order by currencyid";
				conn.ExecuteQuery();
				for (int i = 0; i < conn.GetRowCount(); i++)
					DDL_CL_CURRENCY.Items.Add(new ListItem(conn.GetFieldValue(i,0) + " - " + conn.GetFieldValue(i,1), conn.GetFieldValue(i,0)));
				try
				{
					DDL_CL_CURRENCY.SelectedValue = "IDR";
				}
				catch{}

				conn.QueryString = "select colclassid, colclassdesc from rfcollclass where active='1'";
				conn.ExecuteQuery();
				for (int i = 0; i < conn.GetRowCount(); i++)
					DDL_CL_COLCLASSIFY.Items.Add(new ListItem(conn.GetFieldValue(i,1), conn.GetFieldValue(i,0)));

				
				dtColl = (DataTable) Session["dataTable"];
				
				try
				{
					if (dtColl.Rows.Count > 0)
						ViewCollateral();
				}
				catch {			
				
				dtColl = new DataTable();
				dtColl.Columns.Add(new DataColumn("CL_SEQ"));
				dtColl.Columns.Add(new DataColumn("CL_DESC"));
				dtColl.Columns.Add(new DataColumn("COLTYPEID"));
				dtColl.Columns.Add(new DataColumn("COLTYPEDESC"));
				dtColl.Columns.Add(new DataColumn("CL_VALUE"));
				dtColl.Columns.Add(new DataColumn("LC_PERCENTAGE"));
				dtColl.Columns.Add(new DataColumn("ISNEW"));
				dtColl.Columns.Add(new DataColumn("CL_CURRENCY"));
				dtColl.Columns.Add(new DataColumn("CL_COLCLASSIFY"));
				dtColl.Columns.Add(new DataColumn("CL_FOREIGNVAL"));
				dtColl.Columns.Add(new DataColumn("CL_EXCHANGERATE"));
					Session.Add("dataTable", dtColl);
					ViewCollateral();
				}

				conn.QueryString = "select isnull(max(cl_seq),0) from collateral where cu_ref='" + Request.QueryString["curef"] + "'";
				conn.ExecuteQuery();
				LBL_SEQ.Text = conn.GetFieldValue(0,0);

				/*
				conn.QueryString = "select cl_seq, cl_desc, cl_utilization, cl_apprvalue " + 
					"from collateral where cu_ref='" + Request.QueryString["curef"] + "' " +
					"and (cl_apprvalue is not null or cl_seq in (select cl_seq from " + 
					"list_collateral where ap_regno = '" + Request.QueryString["regno"] + "'))";
				*/
				conn.QueryString = "select cl_seq, cl_desc, cl_utilization, cl_apprvalue, sibs_colid " + 
					"from collateral where cu_ref='" + Request.QueryString["curef"] + "' " +
					"and ((sibs_colid is not null and sibs_colid <> '') or cl_seq in (select cl_seq from " + 
					"listcollateral where ap_regno = '" + Request.QueryString["regno"] + "'))";
				conn.ExecuteQuery();
				for (int i = 0; i < conn.GetRowCount(); i++)
					DDL_CL_TYPE_EXISTING.Items.Add(new ListItem(conn.GetFieldValue(i,1) + " [" + conn.GetFieldValue(i, "sibs_colid") + "]", conn.GetFieldValue(i,0)));

				//ViewCollateral();
				ViewApplications();

				/***
				 * --Yudi
				 * Checking apakah program termasuk pre-scoring
				 * Hal ini menentukan button selanjutnya
				 * ***/
				/***
				conn.QueryString = "select withfairisaac from rfprogram where programid='" + Request.QueryString["prog"] + "'";
				conn.ExecuteQuery();
				string withFairIsaac = conn.GetFieldValue(0,0);
				if (withFairIsaac == "0")
				{
					Button2.Visible = false;
					Button1.Visible = true;
				}
				else
				{
					conn.QueryString = "select cu_cif from customer where cu_ref='" + Request.QueryString["curef"] + "'";
					conn.ExecuteQuery();
					if (conn.GetFieldValue(0,0) == "")
					{
						Button2.Visible = true;
						Button1.Visible = false;
					}
					else
					{
						Button2.Visible = false;
						Button1.Visible = true;
					}
				}
				if (DATAGRID1.Items.Count != 0)
				{
					Button1.Enabled = true;
					Button2.Enabled = true;
				}
				***/

				conn.QueryString = "select withdrawl from rfprogram where programid='" + Request.QueryString["prog"] + "'";
				conn.ExecuteQuery();				
				if (conn.GetRowCount() > 0 && conn.GetFieldValue(0,0) == "0")
					DDL_APPTYPE.Items.Remove(DDL_APPTYPE.Items.FindByValue("06"));

				//-- Yudi
				//Untuk kebutuhan KETENTUAN KREDIT, kalau permohonan baru dalam satu ketentuan kredit
				//tidak bisa bergabung dengan jenis pengajuan lain.				
				DDL_APPTYPE.Enabled = false;

				//20070725 add by sofyan for alih debitur
				alihdeb = "0";
				TR_OLDCIFNO.Visible = false;
				TR_OLDACCNO.Visible = false;
			}
			//DisplayMenu();

			if (RDO_COLLATERAL.SelectedValue == "1")
			{
				DDL_CL_TYPE.Visible = true;
				DDL_CL_TYPE.CssClass = "mandatoryColl";
				DDL_CL_TYPE_EXISTING.Visible = false;
				DDL_CL_TYPE_EXISTING.CssClass = "";
				TXT_CL_DESC.ReadOnly = false;
				//TXT_CL_VALUE.ReadOnly = false;
				//TXT_CL_FOREIGNVAL.ReadOnly = false;
				//DDL_CL_COLCLASSIFY.Enabled = true;
				DDL_CL_CURRENCY.Enabled = true;
				//TXT_CL_EXCHANGERATE.ReadOnly = false;
				Label1.Text = "Jenis Jaminan";
				Label2.Text = "Keterangan";
				LBL_SISAUTILIZATION.Text = "100";
				//TXT_CL_DESC.Text = "";
				//TXT_CL_FOREIGNVAL.Text = "";
				//TXT_CL_EXCHANGERATE.Text = "";
				//TXT_CL_VALUE.Text = "";	
				DDL_CL_TYPE_EXISTING.SelectedValue = "0";
			}
			else 
			{
				DDL_CL_TYPE.Visible = false;
				DDL_CL_TYPE.CssClass = "";
				DDL_CL_TYPE_EXISTING.Visible = true;
				DDL_CL_TYPE_EXISTING.CssClass = "mandatoryColl";
				TXT_CL_DESC.ReadOnly = true;
				//TXT_CL_VALUE.ReadOnly = true;
				//TXT_CL_FOREIGNVAL.ReadOnly = true;
				//DDL_CL_COLCLASSIFY.Enabled = false;
				DDL_CL_CURRENCY.Enabled = false;
				//TXT_CL_EXCHANGERATE.ReadOnly = true;
				Label1.Text = "Keterangan";
				Label2.Text = "Jenis Jaminan";
				//TXT_CL_DESC.Text = "";
				//TXT_CL_FOREIGNVAL.Text = "";
				//TXT_CL_EXCHANGERATE.Text = "";
				//TXT_CL_VALUE.Text = "";
			}
			ViewMenu();
			BTN_INSCOLL.Attributes.Add("onclick","if(!cek_mandatoryColl(document.Form1)){return false;};");
			BTN_SAVE.Attributes.Add("onclick","if(!cek_mandatory(document.Form1)){return false;};");
			Button1.Attributes.Add("onclick","if(!update()){return false;};");
		}

		private bool cekLimitSubApplication() 
		{
			
			/*
			 * Mengambil limit main application
			 */
			conn.QueryString = "select CP_LIMIT, APPTYPE from CUSTPRODUCT C left join APPLICATION A on C.AP_REGNO = A.AP_REGNO " + 
					" where A.AP_REJECT <> '1' AND A.AP_CANCEL <> '1' " + 
					"  and C.AP_REGNO = '" + LBL_MAINREGNO.Text + 
					"' and C.PRODUCTID = '" + LBL_MAINPRODUCTID.Text + 
					"' and C.PROD_SEQ = '" + LBL_MAINPROD_SEQ.Text + "'";
			conn.ExecuteQuery();

			/////////////////////////////////////////////////////////////
			///	kalau main application bukan permohonan baru,
			///	tidak perlu cek limit main application
			///				
			if (conn.GetFieldValue("APPTYPE") != "01") return true;

			double CP_LIMIT_MAIN		= 0;
			double CP_LIMIT_CURR_SUB	= 0;
			double CP_LIMIT_ALL_SUB		= 0;
			
			try {CP_LIMIT_CURR_SUB = Convert.ToDouble(TXT_CP_LIMIT.Text);}
			catch {}

			try {CP_LIMIT_MAIN = Convert.ToDouble(conn.GetFieldValue("CP_LIMIT"));}
			catch {}

			/**
			 * Mengambil limit semua sub application
			 */
			conn.QueryString = "select sum(CP_LIMIT) as CP_LIMIT_ALL_SUB from CUSTPRODUCT where MAINAP_REGNO = '" + LBL_MAINREGNO.Text + 
				"' and MAINPRODUCTID = '" + LBL_MAINPRODUCTID.Text + 
				"' and MAINPROD_SEQ = '" + LBL_MAINPROD_SEQ.Text + "'";
			conn.ExecuteQuery();			

			try {CP_LIMIT_ALL_SUB = Convert.ToDouble(conn.GetFieldValue("CP_LIMIT_ALL_SUB"));}
			catch {}

			/*
			 * Kalau LIMIT SUB + LIMIT SEMUA SUB > LIMIT MAIN ....
			 */
			if (CP_LIMIT_ALL_SUB + CP_LIMIT_CURR_SUB > CP_LIMIT_MAIN) 
			{
				GlobalTools.popMessage(this, "Limit sub aplikasi melebihi limit main aplikasi!");
				return false;
			}

			return true;
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
			this.DatGrd.ItemCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.DatGrd_ItemCommand);
			this.DatGrd.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.DatGrd_PageIndexChanged);
			this.DATAGRID1.ItemCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.DATAGRID1_ItemCommand);

		}
		#endregion

		#region " Defined Methods "

		private void viewExchangeRate() 
		{
			try 
			{
				conn.QueryString = "select PRODUCTID, CURRENCY, C.CURRENCYRATE " +
					"from RFPRODUCT p " +
					"left join RFCURRENCY c on P.CURRENCY = C.CURRENCYID " +
					"where C.ACTIVE = '1' and P.ACTIVE = '1' and PRODUCTID = '" + Request.QueryString["prod"] + "'";
				conn.ExecuteQuery();

				TXT_CP_EXRPLIMIT.Text = conn.GetFieldValue("CURRENCYRATE");

//				double vCP_EXRPLIMIT = 0;
//				double vCP_EXLIMITVAL = 0;
//				double vCP_LIMIT = 0;
//				try { vCP_EXRPLIMIT = Convert.ToDouble(TXT_CP_EXRPLIMIT.Text); } 
//				catch {}
//				try { vCP_EXLIMITVAL = Convert.ToDouble(TXT_CP_EXLIMITVAL.Text); } 
//				catch {}
//
//				vCP_LIMIT = vCP_EXRPLIMIT * vCP_EXLIMITVAL;
//				TXT_CP_LIMIT.Text = tool.MoneyFormat(vCP_LIMIT.ToString());
			} 
			catch (NullReferenceException) 
			{
				Tools.popMessage(this, "Connection Error !");
				return;
			}
		}

		private void ViewMenu()
		{
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
							strtemp = "regno=" + Request.QueryString["regno"] + "&curef="+Request.QueryString["curef"]+"&tc="+Request.QueryString["tc"];
						else	strtemp = "regno=" + Request.QueryString["regno"] + "&curef="+Request.QueryString["curef"]+"&mc="+Request.QueryString["mc"]+"&tc="+Request.QueryString["tc"];
						//t.ForeColor = Color.MidnightBlue; 
					}
					else 
					{
						strtemp = "";
						t.ForeColor = Color.Red; 
					}
					t.NavigateUrl = conn.GetFieldValue(i, 3)+strtemp;
					Menu.Controls.Add(t);
					Menu.Controls.Add(new LiteralControl("&nbsp;&nbsp;&nbsp;"));
				}
			} 
			catch (Exception ex) 
			{
				string temp = ex.ToString();
			}
		}

		private void cekIsView(string view) 
		{
			if (view == "1") 
			{
				TR_JENISPENGAJUAN.Visible	= false;
				TR_COLL.Visible				= false;
				TR_BUTTONS.Visible			= false;
			}
		}

		#endregion

		private string getNextStepMsg(string regno) 
		{
			string pesan = "";
			string nextTrack = "";
			try 
			{
				/***
				 * Memunculkan pesan next step
				 ***/
				conn.QueryString = "exec TRACKNEXTMSG '" + regno + "'";
				conn.ExecuteQuery();
				nextTrack = conn.GetFieldValue("TRACKNAME");
				pesan = "Application proceeds to " + nextTrack;
				/***********************************/
			} 
			catch 
			{
				throw new Exception();
			}

			return pesan;
		}

		protected void DDL_PRODUCTID_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if ((DDL_APPTYPE.SelectedValue != "") && (DDL_PRODUCTID.SelectedValue != ""))
			{
				string isCashLoan = "", link = "", CURRENCY = "";;
				
				if (DDL_APPTYPE.SelectedValue == "01")
				{
					conn.QueryString = "select ISCASHLOAN, CURRENCY from RFPRODUCT where PRODUCTID='" + DDL_PRODUCTID.SelectedValue + "'";
					conn.ExecuteQuery();
					isCashLoan = conn.GetFieldValue(0,0);
					CURRENCY = conn.GetFieldValue("CURRENCY");
					TXT_CP_EXRPLIMIT.Text = CURRENCY;

					conn.QueryString = "select screenlink from apptypelink where apptypeid='01' and iscashloan='" + isCashLoan + "' and fungsiid='IDE'";
					conn.ExecuteQuery();
					link = conn.GetFieldValue(0,0) + "?app=01&prod=" + DDL_PRODUCTID.SelectedValue;

				}

				else 
				{
					conn.QueryString = "select screenlink from apptypelink where apptypeid='" + DDL_APPTYPE.SelectedValue + "' and productid='" + DDL_PRODUCTID.SelectedValue + "' and fungsiid='IDE'";
					conn.ExecuteQuery();
					link = conn.GetFieldValue(0,0) + "?app=" + DDL_APPTYPE.SelectedValue + "&prod=" + DDL_PRODUCTID.SelectedValue;
				}
				
				Response.Redirect(link + 
					"&regno=" + Request.QueryString["regno"] + 
					"&curef=" + Request.QueryString["curef"] + 
					"&prog=" + Request.QueryString["prog"] + 
					"&tc=" + Request.QueryString["tc"] + 
					"&mc=" + Request.QueryString["mc"] + 
					"&ket_code=" + Request.QueryString["ket_code"] + 
					"&mainregno=" + LBL_MAINREGNO.Text + 
					"&mainprod_seq=" + LBL_MAINPROD_SEQ.Text + 
					"&mainproductid=" + LBL_MAINPRODUCTID.Text);
			}
		}

		private void ViewCollateral()
		{
			double nilaiAkhir = 0;

			dtColl = (DataTable) Session["dataTable"];
			DatGrd.DataSource = dtColl;
			DatGrd.DataBind();

			for (int i = 0; i < DatGrd.Items.Count; i++)
			{
				nilaiAkhir = double.Parse(DatGrd.Items[i].Cells[4].Text) * double.Parse(DatGrd.Items[i].Cells[5].Text) / 100;
				DatGrd.Items[i].Cells[6].Text = tool.MoneyFormat(nilaiAkhir.ToString());
			}

			/*
			DataTable dt = new DataTable();
			conn.QueryString = "select * from vw_ide_listcollateral where cu_ref='0'";
			conn.ExecuteQuery();
			dt = conn.GetDataTable().Copy();
			DatGrd.DataSource = dt;
			DatGrd.DataBind();
			

			for (int i = 0; i < DatGrd.Items.Count; i++)
				DatGrd.Items[i].Cells[2].Text = tool.MoneyFormat(DatGrd.Items[i].Cells[2].Text);
			*/
		}

		protected void DDL_APPTYPE_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			//conn.QueryString = "select apptypeid, screenlink from rfapplicationtype where apptypeid='" + DDL_APPTYPE.SelectedValue + "'";
			/*
			if ((DDL_APPTYPE.SelectedValue != "") && (DDL_PRODUCTID.SelectedValue != ""))
			{
				conn.QueryString = "select screenlink from apptypelink where apptypeid='" + DDL_APPTYPE.SelectedValue + "' and productid='" + DDL_PRODUCTID.SelectedValue + "' and fungsiid='IDE'";
				conn.ExecuteQuery();
				string link = conn.GetFieldValue(0,0) + "?app=" + DDL_APPTYPE.SelectedValue + "&prod=" + DDL_PRODUCTID.SelectedValue;
				Response.Redirect(link + "&regno=" + Request.QueryString["regno"] + "&curef=" + Request.QueryString["curef"] + "&prog=" + Request.QueryString["prog"] + "&tc=" + Request.QueryString["tc"]);
			}
			*/
			if (DDL_APPTYPE.SelectedValue != "")
			{
				conn.QueryString = "select screenlink from apptypelink where apptypeid='" + DDL_APPTYPE.SelectedValue + "' and fungsiid='IDE' and [default]='1'";
				conn.ExecuteQuery();
				string link = conn.GetFieldValue(0,0) + "?app=" + DDL_APPTYPE.SelectedValue;
				Response.Redirect(link + "&regno=" + Request.QueryString["regno"] + "&curef=" + Request.QueryString["curef"] + "&prog=" + Request.QueryString["prog"] + "&tc=" + Request.QueryString["tc"] + "&mc=" + Request.QueryString["mc"]);
			}
		}

		private void ViewApplications()
		{
			DataTable dt1 = new DataTable();
			conn.QueryString = "select * from vw_ide_listapplication where ap_regno='" + Request.QueryString["regno"] + "' and KET_CODE = '" + Request.QueryString["ket_code"] + "'";
			conn.ExecuteQuery();
			dt1 = conn.GetDataTable().Copy();
			DATAGRID1.DataSource = dt1;
			DATAGRID1.DataBind();

			for (int i = 0; i < DATAGRID1.Items.Count; i++)
			{
				if (DATAGRID1.Items[i].Cells[5].Text != "&nbsp;")
					DATAGRID1.Items[i].Cells[5].Text = tool.MoneyFormat(DATAGRID1.Items[i].Cells[5].Text);
				if (DATAGRID1.Items[i].Cells[6].Text != "&nbsp;")
					DATAGRID1.Items[i].Cells[6].Text = tool.MoneyFormat(DATAGRID1.Items[i].Cells[6].Text);

				//if (DATAGRID1.Items[i].Cells[8].Text.Trim() != "&nbsp;")
				//	DATAGRID1.Items[i].Cells[8].Text = DATAGRID1.Items[i].Cells[8].Text + " Bulan";
			}
		}

		protected void BTN_SAVE_Click(object sender, System.EventArgs e)
		{
			//Sebelum save, cek dulu ......

			
			//-------------------------------------------------------------------------------
			//Kalau checkbox collateral dipilih, tapi tidak ada collateral dimasukkan, maka
			//munculkan pesan
			//keyword: collateral

			if (CHK_COLLATERAL.Checked == true)
			{
				if (DatGrd.Items.Count == 0)
				{
					Tools.popMessage(this, "Data collateral belum diisi!");
					return;
				}
			}
			//-------------------------------------------------------------------------------

			
			//-------------------------------------------------------------------------------
			//Kalau aplikasi ybs adalah sub aplikasi, maka limit sub aplikasi tidak boleh
			//melebihi limit aplikasi utama
			//keyword: limit, sub application

			if (LBL_MAINREGNO.Text != "" && LBL_MAINREGNO.Text != null) 
			{
				if (!cekLimitSubApplication()) return;
			}
	
			//-------------------------------------------------------------------------------



			/***
			 * --- Modif by Yudi
			 * Untuk SME Phase 2, dalam 1 aplikasi bisa memiliki >1 apptype dan productid
			 * 
			conn.QueryString = "select count (*) from cust_product where ap_regno='" + Request.QueryString["regno"] + "' and apptype='" + 
				DDL_APPTYPE.SelectedValue + "' and productid='" + DDL_PRODUCTID.SelectedValue + "'";
			conn.ExecuteQuery();
			if (conn.GetFieldValue(0,0) != "0")
			{
				Clear();
				Response.Write("<script language='javascript'>alert('Permohonan yg sama pada produk yg diminta!');</script>");
				return;
			}
			***/

			string vPROD_SEQ = "0";

			//20070313 add by sofyan for alih debitur
			if (CHK_ALIHDEB.Checked == true)
			{
				alihdeb = "1";
			}
			else
			{
				alihdeb = "0";
			}

			try 
			{
				conn.QueryString = "exec IDE_LOANINFO_PBARU '" + Request.QueryString["regno"] + "', '" + 
					DDL_APPTYPE.SelectedValue + "', '" + DDL_PRODUCTID.SelectedValue + "', " + 
					tool.ConvertFloat(TXT_CP_LIMIT.Text) + ", '" + DDL_CP_LOANPURPOSE.SelectedValue + "', " +
					tool.ConvertFloat(TXT_CP_EXRPLIMIT.Text) + ", " + 
					tool.ConvertFloat(TXT_CP_EXLIMITVAL.Text) + ", '" + 
					TXT_CP_NOTES.Text + "', " + 
					TXT_CP_JANGKAWKT.Text + ", " + 
					tool.ConvertNull(DDL_CP_TENORCODE.SelectedValue) + ", " + 
					tool.ConvertNull(DDL_PROJECT_CODE.SelectedValue) + ", '" +
					alihdeb + "', '" +
					TXT_OLDCIFNO.Text + "', '" +
					TXT_OLDACCNO.Text + "'";
				//conn.ExecuteNonQuery();
				conn.ExecuteQuery();
			} 
			catch (Exception ex)
			{
				string errmsg = ex.Message.Replace("'","");
				if (errmsg.IndexOf("Last Query:") > 0)
					errmsg = errmsg.Substring(0, errmsg.IndexOf("Last Query:"));
				GlobalTools.popMessage(this, errmsg);
				return;
			}

			vPROD_SEQ = conn.GetFieldValue("PROD_SEQ");


			//--- menyimpan data parent application untuk jika sub application --//
			try 
			{
				conn.QueryString = "exec IDE_LOANINFO_SUBAPP '" + 
					REGNO + "', '" + 
					DDL_APPTYPE.SelectedValue + "', '" + 
					DDL_PRODUCTID.SelectedValue + "', '" + 
					LBL_MAINREGNO.Text + "', '" +
				    LBL_MAINPRODUCTID.Text + "', '" + 
					LBL_MAINPROD_SEQ.Text + "'";
				conn.ExecuteNonQuery();					
			} 
			catch (NullReferenceException) 
			{
				GlobalTools.popMessage(this, "Connection Error!");
				return;
			}
				

				/***
				 * --- Modif by Yudi
				 * **/
				/***
				conn.QueryString = "insert into apptrack (ap_regno, apptype, productid, ap_currtrack, ap_currtrackdate, ap_currtrackby) " + 
					"values ('" + Request.QueryString["regno"] + "', '" + DDL_APPTYPE.SelectedValue + "', '" + 
					DDL_PRODUCTID.SelectedValue + "', '" + Request.QueryString["tc"] + "', getdate(), '" + LBL_USERID.Text + "')";
				conn.ExecuteNonQuery();
							
				conn.QueryString = "select count(*) from track_history where ap_regno='" + Request.QueryString["regno"] + "' and apptype='" + DDL_APPTYPE.SelectedValue + "' and productid='" + DDL_PRODUCTID.SelectedValue + "'";
				conn.ExecuteQuery();
				if (conn.GetFieldValue(0,0) == "0")
				{
					conn.QueryString = "insert into track_history (ap_regno, apptype, productid, trackcode, th_seq, th_trackdate, th_trackby) values " + 
						"('" + Request.QueryString["regno"] + "', '" + DDL_APPTYPE.SelectedValue + "', '" + DDL_PRODUCTID.SelectedValue + "', '" + Request.QueryString["tc"] + "', 1, getdate(), '" + LBL_USERID.Text + "')";
					conn.ExecuteNonQuery();					
				}
				***/
			try 
			{
				conn.QueryString = "exec IDE_LOANINFO_GENERAL '" + 
					Request.QueryString["regno"] + "', '" + 
					DDL_APPTYPE.SelectedValue + "', '" + 
					DDL_PRODUCTID.SelectedValue + "', '" + 
					Request.QueryString["tc"] + "', '" + 
					LBL_USERID.Text + "'";
				conn.ExecuteNonQuery();
			} 
			catch (NullReferenceException) 
			{
				GlobalTools.popMessage(this, "Connection Error!");
				return;
			}

				for (int i = 0; i < DatGrd.Items.Count; i++)
				{
					if (DatGrd.Items[i].Cells[8].Text == "1")
						//if (RDO_COLLATERAL.SelectedValue == "1")
					{
					
						//collateralValue = DatGrd.Items[i].Cells[6].Text.Replace(",", ".");
						conn.QueryString = "exec IDE_LOANINFO_COLL '" + Request.QueryString["regno"] + "', '" + 
							Request.QueryString["curef"] + "', '" +
							DatGrd.Items[i].Cells[1].Text + "', " +
							DatGrd.Items[i].Cells[2].Text/* DDL_CL_TYPE.SelectedValue */ + ", " + 
							tool.ConvertFloat(DatGrd.Items[i].Cells[4].Text) + ", " + 
							DatGrd.Items[i].Cells[0].Text + ", '" + 
							DDL_PRODUCTID.SelectedValue + "', " + 
							tool.ConvertFloat(DatGrd.Items[i].Cells[5].Text) + ", " + 
							tool.ConvertFloat(DatGrd.Items[i].Cells[6].Text)/* collateralValue */ + ", '1', '" + 
							DatGrd.Items[i].Cells[9].Text + "', '" +
							DatGrd.Items[i].Cells[10].Text + "', " + 
							tool.ConvertFloat(DatGrd.Items[i].Cells[11].Text) + ", " + 
							tool.ConvertFloat(DatGrd.Items[i].Cells[12].Text) + ", NULL, " + vPROD_SEQ + "";
						conn.ExecuteNonQuery();
					}		
					else if (DatGrd.Items[i].Cells[8].Text == "0")
					{
						//collateralValue = DatGrd.Items[i].Cells[6].Text.Replace(",", ".");
						/*
						conn.QueryString = "exec IDE_LOANINFOCOLL '" + Request.QueryString["regno"] + "', '" + 
							Request.QueryString["curef"] + "', " +
							"null, null, 0," + 
							//DatGrd.Items[i].Cells[1].Text + "', " +
							//DatGrd.Items[i].Cells[2].Text + ", " + 
							//DDL_CL_TYPE.SelectedValue 
							//DatGrd.Items[i].Cells[4].Text + ", " + 
							DatGrd.Items[i].Cells[0].Text + ", '" + 
							DDL_PRODUCTID.SelectedValue + "', " + 
							tool.ConvertFloat(DatGrd.Items[i].Cells[5].Text) + ", " + 
							tool.ConvertFloat(DatGrd.Items[i].Cells[6].Text) + ", '2', '" + 
							"', '', 0, 0";
						*/
						/*
							DatGrd.Items[i].Cells[9].Text + "', '" + 
							DatGrd.Items[i].Cells[10].Text + "', " + 
							DatGrd.Items[i].Cells[11].Text;
							*/
							conn.QueryString = "exec IDE_LOANINFO_COLL '" + Request.QueryString["regno"] + "', '" + 
								Request.QueryString["curef"] + "', " +
								"null, null, 0," + 
								//DatGrd.Items[i].Cells[1].Text + "', " +
								//DatGrd.Items[i].Cells[2].Text + ", " + 
								//DDL_CL_TYPE.SelectedValue 
								//DatGrd.Items[i].Cells[4].Text + ", " + 
								DatGrd.Items[i].Cells[0].Text + ", '" + 
								DDL_PRODUCTID.SelectedValue + "', " + 
								tool.ConvertFloat(DatGrd.Items[i].Cells[5].Text) + ", " + 
								tool.ConvertFloat(DatGrd.Items[i].Cells[6].Text) + ", '2', '" + 
								DatGrd.Items[i].Cells[9].Text + "', '" + 
								DatGrd.Items[i].Cells[10].Text + "', 0, 0, null, '" + vPROD_SEQ + "'";
							conn.ExecuteNonQuery();
						
					}
				}
				Clear();
				ViewApplications();
				Button1.Enabled = true;
				Button2.Enabled = true;	
				
				//Mengingat 1 ketentuan kredit hanya 1 permohonan baru, 
				//maka setelah permohonan baru dibuat, tidak bisa membuat pengajuan lagi
				//dengan jenis yang sama
				TR_JENISPENGAJUAN.Visible = false;
				TR_COLL.Visible = false;
				TR_BUTTONS.Visible = false;
		}

		private void Clear()
		{
			TXT_CP_LIMIT.Text = "";
			TXT_CP_JANGKAWKT.Text = "";
			TXT_CL_EXCHANGERATE.Text = "1";
			TXT_CP_EXRPLIMIT.Text = "1";

			DDL_CP_LOANPURPOSE.SelectedValue ="";
			TXT_CP_EXLIMITVAL.Text = "";
			TXT_CP_NOTES.Text = "";
			
			DDL_CL_TYPE.SelectedValue = "";
			DDL_CL_TYPE_EXISTING.SelectedValue = "0";
			DDL_CL_COLCLASSIFY.SelectedValue = "";
			DDL_CL_CURRENCY.SelectedValue = "";
			TXT_CL_FOREIGNVAL.Text = "";
			TXT_CL_EXCHANGERATE.Text = "1";
			TXT_CL_VALUE.Text = "";
			DDL_PRODUCTID.SelectedValue = "";
			
			dtColl = (DataTable) Session["dataTable"];
			int count = dtColl.Rows.Count;

			for (int i = 0; i < count; i++)
				dtColl.Rows[0].Delete();

			Session.Remove("dataTable");
			Session.Add("dataTable", dtColl);
			
			DatGrd.DataSource = dtColl;
			DatGrd.DataBind();
		}

		protected void BTN_INSCOLL_Click(object sender, System.EventArgs e)
		{
			/*
			conn.QueryString = "exec IDE_LOANINFOCOLL '" + Request.QueryString["curef"] + "', '" +
				TXT_CL_DESC.Text + "', '" + DDL_CL_TYPE.SelectedValue + "', '" + TXT_CL_VALUE.Text + "', " + 
				"null, '0'";
			conn.ExecuteNonQuery();
			ViewCollateral();
			DDL_CL_TYPE.SelectedValue = "";
			TXT_CL_VALUE.Text = "";
			*/

			//DataTable dt = new DataTable();
			
			// ---- Baru ----
			if (DDL_CL_COLCLASSIFY.SelectedValue == "") 
			{
				GlobalTools.popMessage(this, "Jenis Jaminan tidak boleh kosong!");
				return;
			}

			if (double.Parse(TXT_LC_PERCENTAGE.Text) > double.Parse(LBL_SISAUTILIZATION.Text))
			{
				Response.Write("<script language='javascript'>alert('Utilization Melebihi Limit!');</script>");
			}
			else
			{
				dtColl = (DataTable) Session["dataTable"];
				DataRow dr;
				try 
				{
					dr = dtColl.NewRow();
				} 
				catch 
				{
					//--- tambahan dari Yudi (2004-09-16) ---
					dtColl = new DataTable();
					dtColl.Columns.Add(new DataColumn("CL_SEQ"));
					dtColl.Columns.Add(new DataColumn("CL_DESC"));
					dtColl.Columns.Add(new DataColumn("COLTYPEID"));
					dtColl.Columns.Add(new DataColumn("COLTYPEDESC"));
					dtColl.Columns.Add(new DataColumn("CL_VALUE"));
					dtColl.Columns.Add(new DataColumn("LC_PERCENTAGE"));
					dtColl.Columns.Add(new DataColumn("ISNEW"));
					dtColl.Columns.Add(new DataColumn("CL_CURRENCY"));
					dtColl.Columns.Add(new DataColumn("CL_COLCLASSIFY"));
					dtColl.Columns.Add(new DataColumn("CL_FOREIGNVAL"));
					dtColl.Columns.Add(new DataColumn("CL_EXCHANGERATE"));
					Session.Add("dataTable", dtColl);

					dr = dtColl.NewRow();
					//----------------------------------------
				}

				int seq = 0;
				try 
				{
					seq = int.Parse(LBL_SEQ.Text);
				} 
				catch 
				{
					seq = 0;
				}

				if (RDO_COLLATERAL.SelectedValue == "1")
				{					
					seq++;
					dr[0] = seq.ToString();
					dr[1] = TXT_CL_DESC.Text;
					dr[2] = DDL_CL_TYPE.SelectedValue;
					dr[3] = DDL_CL_TYPE.SelectedItem.Text;
					dr[4] = TXT_CL_VALUE.Text;
					dr[5] = TXT_LC_PERCENTAGE.Text;
					dr[6] = "1";
					dr[7] = DDL_CL_CURRENCY.SelectedValue;
					dr[8] = DDL_CL_COLCLASSIFY.SelectedValue;
					dr[9] = TXT_CL_FOREIGNVAL.Text;
					dr[10] = TXT_CL_EXCHANGERATE.Text;
					//dtColl.Rows.Add(dr);
				}
				else
				{
					dr[0] = DDL_CL_TYPE_EXISTING.SelectedValue;
					dr[1] = DDL_CL_TYPE_EXISTING.SelectedItem.Text;
					//dr[2] = DDL_CL_TYPE.SelectedValue;
					//dr[3] = DDL_CL_TYPE.SelectedItem.Text;
					dr[4] = TXT_CL_VALUE.Text;
					dr[5] = TXT_LC_PERCENTAGE.Text;
					dr[6] = "0";
					dr[7] = DDL_CL_CURRENCY.SelectedValue;
					dr[8] = DDL_CL_COLCLASSIFY.SelectedValue;
					dr[9] = TXT_CL_FOREIGNVAL.Text;
					dr[10] = TXT_CL_EXCHANGERATE.Text;
				}

				dtColl.Rows.Add(dr);

				Session.Remove("dataTable");
				Session.Add("dataTable", dtColl);

				ViewCollateral();
			
				//DatGrd.DataSource = new DataView(dtColl);
				//DatGrd.DataBind();
				LBL_SEQ.Text = seq.ToString();
			
				TXT_CL_DESC.Text = "";
				DDL_CL_TYPE.SelectedValue = "";
				DDL_CL_COLCLASSIFY.SelectedValue = "";
				DDL_CL_CURRENCY.SelectedValue = "";
				TXT_CL_FOREIGNVAL.Text = "";
				TXT_CL_EXCHANGERATE.Text = "1";
				TXT_CL_VALUE.Text = "";
				TXT_LC_PERCENTAGE.Text = "";
				try{DDL_CL_TYPE_EXISTING.SelectedValue="0";}
				catch{}

				LBL_SISAUTILIZATION.Text = "100";
			}
		}

		private void DatGrd_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			string seq = null;

			switch (((LinkButton)e.CommandSource).CommandName)
			{
				case "delete":
					seq = e.Item.Cells[0].Text;
					dtColl = (DataTable) Session["dataTable"];
					
					for (int i = 0; i < dtColl.Rows.Count; i++)
						if (dtColl.Rows[i]["CL_SEQ"].ToString() == seq)
							dtColl.Rows[i].Delete();
					
					Session.Remove("dataTable");
					Session.Add("dataTable", dtColl);

					ViewCollateral();
					//DatGrd.DataSource = new DataView(dtColl);
					//DatGrd.DataBind();

					/*
					conn.QueryString = "exec IDE_LOANINFOCOLL '" + Request.QueryString["curef"] + "', '', null, " + 
						e.Item.Cells[0].Text + ", '2'";
					conn.ExecuteNonQuery();
					*/
					break;
			}
			//ViewCollateral();
		}

		private void DatGrd_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			DatGrd.CurrentPageIndex = e.NewPageIndex;
			ViewCollateral();
		}

		protected void Button2_Click(object sender, System.EventArgs e)
		{
			Session.Remove("dataTable");
			Response.Redirect("FairIsaac.aspx?regno=" + Request.QueryString["regno"] + "&curef=" + Request.QueryString["curef"] + "&prog=" + Request.QueryString["prog"] + "&tc=" + Request.QueryString["tc"] + "&mc=" + Request.QueryString["mc"]);
		}

		private void DATAGRID1_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			switch (((LinkButton)e.CommandSource).CommandName)
			{
				case "delete":
					/*
					conn.QueryString = "delete from apptrack where ap_regno='" + Request.QueryString["regno"] + "' and apptype='" + e.Item.Cells[1].Text + "' and productid='" + e.Item.Cells[3].Text + "' and PROD_SEQ = '" + e.Item.Cells[9].Text + "'";
					conn.ExecuteNonQuery();

					conn.QueryString = "delete from custproduct where ap_regno='" + Request.QueryString["regno"] + "' and apptype='" + e.Item.Cells[1].Text + "' and productid='" + e.Item.Cells[3].Text + "' and PROD_SEQ = '" + e.Item.Cells[9].Text + "'";
					conn.ExecuteNonQuery();

					conn.QueryString = "delete from trackhistory where ap_regno='" + Request.QueryString["regno"] + "' and apptype='" + e.Item.Cells[1].Text + "' and productid='" + e.Item.Cells[3].Text + "' and PROD_SEQ = '" + e.Item.Cells[9].Text + "'";
					conn.ExecuteNonQuery();

					conn.QueryString = "delete from listcollateral where ap_regno='" + Request.QueryString["regno"] + "' and productid='" + e.Item.Cells[3].Text + "' and PROD_SEQ = '" + e.Item.Cells[9].Text + "'";
					conn.ExecuteNonQuery();
					*/


					/****************************************************************************************
					 * Kalau delete dari selain IDE, tidak bisa dilakukan jika tinggal 1 jenis pengajuan
					 *****************************************************************************************/
					conn.QueryString = "select * from scgroup_init2 where gr_key like '%IDE%' and groupid = '" + Request.QueryString["tc"] + "'";
					conn.ExecuteQuery();
					if (conn.GetRowCount() == 0 && DATAGRID1.Items.Count == 1) 
					{
						GlobalTools.popMessage(this, "Jenis Pengajuan tidak bisa dihapus karena aplikasi akan tidak memiliki kredit !");
						return;
					}
					/****************************************************************************************/


					try 
					{ 
						conn.QueryString = "exec IDE_LOANINFO_DELETE '" + 
							Request.QueryString["regno"] + "', '" + 
							e.Item.Cells[1].Text + "', '" + // apptype
							e.Item.Cells[3].Text + "', '" + // productid
							e.Item.Cells[9].Text + "'";		// prod_seq
						conn.ExecTrans();
						conn.ExecTran_Commit();
					} 
					catch (Exception ex)
					{
						if (conn != null)
							conn.ExecTran_Rollback();
						ExceptionHandling.Handler.saveExceptionIntoWindowsLog(ex, Request.Path, "ERROR DELETE : " + Request.QueryString["regno"]);
					}

					break;
			}
			ViewApplications();
		}

		protected void DDL_CL_TYPE_EXISTING_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			//conn.QueryString = "select coltypedesc, cl_value, sisautilization, cl_currency, cl_colclassify, cl_exchangerate, cl_foreignval, sibs_colid from vw_collateral1 where cu_ref='" + Request.QueryString["curef"] + "' and cl_seq='" + DDL_CL_TYPE_EXISTING.SelectedValue + "'";
			conn.QueryString = "exec COLLATERAL1 '" + Request.QueryString["regno"] + "', '" + Request.QueryString["curef"] + "', " + DDL_CL_TYPE_EXISTING.SelectedValue;
			conn.ExecuteQuery();
			TXT_CL_DESC.Text = conn.GetFieldValue(0, "coltypedesc");
			TXT_CL_VALUE.Text = tool.MoneyFormat(conn.GetFieldValue(0, "cl_value"));
			DDL_CL_CURRENCY.SelectedValue = conn.GetFieldValue(0, "cl_currency");
			DDL_CL_COLCLASSIFY.SelectedValue = conn.GetFieldValue(0, "cl_colclassify");
			if (conn.GetFieldValue(0, "cl_exchangerate") != "")
				TXT_CL_EXCHANGERATE.Text = tool.MoneyFormat(conn.GetFieldValue(0, "cl_exchangerate"));
			else 
				TXT_CL_EXCHANGERATE.Text = tool.MoneyFormat("1");
			if (conn.GetFieldValue(0, "cl_foreignval") != "")
				TXT_CL_FOREIGNVAL.Text = tool.MoneyFormat(conn.GetFieldValue(0, "cl_foreignval"));
			else
				TXT_CL_FOREIGNVAL.Text = tool.MoneyFormat(conn.GetFieldValue(0, "cl_value"));
			LBL_SISAUTILIZATION.Text = conn.GetFieldValue(0, "sisautilization");
			if (conn.GetFieldValue(0, "sibs_colid") != "")
			{
				conn.QueryString = "select sum(lc_percentage) from listcollateral where ap_regno='" + Request.QueryString["regno"] + "' and cl_seq=" + DDL_CL_TYPE_EXISTING.SelectedValue;
				conn.ExecuteQuery();
				try
				{
					double temp = 100 - double.Parse(conn.GetFieldValue(0,0).ToString().Replace(".", ","));
					LBL_SISAUTILIZATION.Text = temp.ToString();
				}
				catch
				{
					LBL_SISAUTILIZATION.Text = "100";
				}
			}
		}

		protected void Button1_Click(object sender, System.EventArgs e)
		{
			//conn.QueryString = "select checkbi from customer where cu_ref='" + Request.QueryString["curef"] + "'";
			conn.QueryString = "select ap_checkbi from application where ap_regno='" + Request.QueryString["regno"] + "'";
			conn.ExecuteQuery();
			if (conn.GetRowCount() > 0)
			{
				if (conn.GetFieldValue(0,0) == "1")
				{
					conn.QueryString = "insert into bi_status (ap_regno, cu_ref, bs_reqdate, bs_recvdate, bs_bidataavail, bs_complete) " + 
						"values ('" + Request.QueryString["regno"] + "', '" + Request.QueryString["curef"] + "', getdate(), null, null, '0')";
					conn.ExecuteQuery();
				}
			}

			DataTable dt;
			conn.QueryString = "select apptype, productid, PROD_SEQ from custproduct where ap_regno='" + Request.QueryString["regno"] +
				"' AND isnull(cp_reject,'0') <> '1' and isnull(cp_cancel,'0') <> '1'";
			conn.ExecuteQuery();
			dt = conn.GetDataTable().Copy();
			for (int i = 0; i < dt.Rows.Count; i++)
			{
				conn.QueryString = "exec TRACKUPDATE '" + 
									Request.QueryString["regno"] + "', '" +
									dt.Rows[i][1].ToString() + "', '" + 
									dt.Rows[i][0].ToString() + "', '" + 
									LBL_USERID.Text + "', '" + 
									dt.Rows[i]["PROD_SEQ"].ToString() + "','"+Request.QueryString["tc"].Trim()+"'";
				conn.ExecuteNonQuery();
			}
			Response.Redirect("FindCustomer.aspx?tc=" + Request.QueryString["tc"] + "&mc=" + Request.QueryString["mc"]);
		}

		protected void CHK_COLLATERAL_CheckedChanged(object sender, System.EventArgs e)
		{
			if (CHK_COLLATERAL.Checked == true) 
			{
				TR_COLL.Visible = true;
			}
			else 
			{
				TR_COLL.Visible = false;
			}
		}

		protected void DDL_CL_CURRENCY_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			try 
			{
				conn.QueryString = "select CURRENCYRATE from RFCURRENCY where CURRENCYID = '" + DDL_CL_CURRENCY.SelectedValue + "'";
				conn.ExecuteQuery();

				TXT_CL_EXCHANGERATE.Text = tool.MoneyFormat(conn.GetFieldValue("CURRENCYRATE"));
			}
			catch (NullReferenceException) 
			{
				GlobalTools.popMessage(this, "Connection Error !");
				return;
			}
		}

		protected void RDO_COLLATERAL_SelectedIndexChanged(object sender, System.EventArgs e)
		{
		
		}

		protected void CHK_ALIHDEB_CheckedChanged(object sender, System.EventArgs e)
		{
			if (CHK_ALIHDEB.Checked == true)
			{
				TR_OLDCIFNO.Visible = true;
				TR_OLDACCNO.Visible = true;
			}
			else
			{
				TR_OLDCIFNO.Visible = false;
				TR_OLDACCNO.Visible = false;
			}
		}
	}
}
