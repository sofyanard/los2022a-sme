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

namespace SME.Approval
{
	/// <summary>
	/// Summary description for ApprovalHistoryPrint.
	/// </summary>
	public partial class ApprovalHistoryPrint : System.Web.UI.Page
	{
		protected Connection conn;
		protected Tools tools = new Tools();
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			conn = (Connection) Session["Connection"];

			if (!IsPostBack)
			{
				LBL_CASH.Text		= Request.QueryString["cash"];
				LBL_APREGNO.Text	= Request.QueryString["regno"];
//				LBL_PRODUCTID.Text	= Request.QueryString["prodid"];
//				LBL_KET_CODE.Text	= Request.QueryString["ket_code"];
//				LBL_PROD_SEQ.Text	= Request.QueryString["prod_seq"];
				LBL_PRINT.Text		= tools.FormatDate(DateTime.Today.ToString());
				ViewReport();
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
	
		private void ViewReport()
		{
			string ket_code = LBL_KET_CODE.Text.Trim();

			////////////////////////////////////////
			///	mengambil ketentuan kredit
			///	////////////////////////////////////
			conn.QueryString = "select distinct KET_CODE, KET_DESC from VW_CUST_DISBURSEMENT_KETKREDIT where ap_regno='" + LBL_APREGNO.Text + "'";
			conn.ExecuteQuery();
			DataTable tmp = conn.GetDataTable();

			for (int j = 0; j < tmp.Rows.Count; j++)
			{
				/////////////////////////////////////////
				///	menampilkan ketentuan kredit
				///	
				System.Web.UI.WebControls.Literal lit = new System.Web.UI.WebControls.Literal();
				lit.Text = "<h4>Ketentuan Kredit : " + tmp.Rows[j]["KET_DESC"].ToString() + "</h4>";
				PlaceHolder1.Controls.Add(lit);


				////////////////////////////////////////////
				///	mengambil jenis pengajuan dan product
				///	////////////////////////////////////////
				conn.QueryString = "select distinct APPTYPE, PRODUCTID, PROD_SEQ from CUSTPRODUCT where KET_CODE = '" + tmp.Rows[j]["KET_CODE"].ToString() + "'";
				conn.ExecuteQuery();

				System.Data.DataTable dt = new System.Data.DataTable();
				dt = conn.GetDataTable().Copy();	

				for (int i=0;i<dt.Rows.Count;i++)
				{
					if (dt.Rows[i]["APPTYPE"].ToString()=="01")			//	permohonan baru
						ViewSK01(dt.Rows[i]["APPTYPE"].ToString(), dt.Rows[i]["PRODUCTID"].ToString(), dt.Rows[i]["PROD_SEQ"].ToString());
					else if (dt.Rows[i]["APPTYPE"].ToString()=="02")	//	perubahan jaminan
						ViewSK02(dt.Rows[i]["APPTYPE"].ToString(), dt.Rows[i]["PRODUCTID"].ToString(), dt.Rows[i]["PROD_SEQ"].ToString());
					else if (dt.Rows[i]["APPTYPE"].ToString()=="03")	//	perubahan limit
						ViewSK03(dt.Rows[i]["APPTYPE"].ToString(), dt.Rows[i]["PRODUCTID"].ToString(), dt.Rows[i]["PROD_SEQ"].ToString());	
					else if (dt.Rows[i]["APPTYPE"].ToString()=="04")	//	renewal
						ViewSK04(dt.Rows[i]["APPTYPE"].ToString(), dt.Rows[i]["PRODUCTID"].ToString(), dt.Rows[i]["PROD_SEQ"].ToString());	
					else if (dt.Rows[i]["APPTYPE"].ToString()=="05")	//	perubahan syarat
						ViewSK05(dt.Rows[i]["APPTYPE"].ToString(), dt.Rows[i]["PRODUCTID"].ToString(), dt.Rows[i]["PROD_SEQ"].ToString());
					else if (dt.Rows[i]["APPTYPE"].ToString()=="06")	//	withdrawal
						ViewSK06(dt.Rows[i]["APPTYPE"].ToString(), dt.Rows[i]["PRODUCTID"].ToString(), dt.Rows[i]["PROD_SEQ"].ToString());
				}
			}
			ViewBEA();
		}			


		/****
		private void Query(string vapptype)
		{
			conn.QueryString = "select * from VW_REPORT_DISBURSHEET1_KETKREDIT a where " + 
				" a.ap_regno='" + LBL_APREGNO.Text + 
				"' and a.productid='" + LBL_PRODUCTID.Text + 
				"' and a.apptype='" + vapptype + "' "+
				" and a.ad_seq=(select max(ad.ad_seq) from approval_decision ad " +
				" where ad.ap_regno='" + LBL_APREGNO.Text + 
				"' and ad.productid='" + LBL_PRODUCTID.Text + 
				"' and ad.apptype='" + vapptype + "') ";
			conn.ExecuteQuery();
		}
		***/


		private void Query(string vapptype, string productID, string prod_seq)
		{
			conn.QueryString = "select * "+
				"from VW_APPROVALDECISION_HISTORY a "+
				" where a.ap_regno='" + LBL_APREGNO.Text + 
				"' and a.productid='" + productID + 
				"' and a.apptype='" + vapptype + 
				"' and a.prod_seq = '" + prod_seq + "'"+
				"and a.ad_seq=(select max(ad.ad_seq) from approval_decision ad "+
				"where ad.ap_regno='" + LBL_APREGNO.Text + 
				"' and ad.productid='" + productID + 
				"' and ad.apptype='" + vapptype + 
				"' and ad.prod_seq = '" + prod_seq + "') ";
			conn.ExecuteQuery();
		}

		private void QueryIDC()
		{
			conn.QueryString = "select IDC_CAPAMNT, IDC_CAPRATIO, IDC_JWAKTU, IDC_PRIMEVARCODE, IDC_RATIO "+
				"from custproduct where AP_REGNO='"+LBL_APREGNO.Text+"' and PRODUCTID='"+LBL_PRODUCTID.Text+"'";
			conn.ExecuteQuery();
		}

		private void ViewSK07()
		{
		}
		private void ViewSK04(string vapptype, string productID, string prod_seq)
		{
			//////////////////////////////////////////////////////
			///	mengambil AA NO, Kode Fasilitas, account number
			///	
			conn.QueryString = "select ACC_NO from vw_custproduct where ap_regno = '" + LBL_APREGNO.Text + 
				"' and apptype = '" + vapptype + 
				"' and productid = '" + productID + 
				"' and prod_seq = '" + prod_seq + "'";
			conn.ExecuteQuery();
			string ACC_NO = conn.GetFieldValue("ACC_NO");

			Query(vapptype, productID, prod_seq);

			/**
			System.Web.UI.WebControls.Literal lit = new System.Web.UI.WebControls.Literal();
			lit.Text = "<b>Product " + conn.GetFieldValue("PRODUCTDESC") + "</b>";
			PlaceHolder1.Controls.Add(lit);
			**/

			System.Web.UI.WebControls.Table tmp = new System.Web.UI.WebControls.Table();
			
			///////////////////////////////////////////////////
			///	Ketentuan Kredit
			///	
			tmp.Rows.Add(new TableRow());
			tmp.Rows[0].Cells.Add(new TableCell());
			tmp.Rows[0].Cells[0].Width = Unit.Pixel(250);
			tmp.Rows[0].Cells[0].Text = "Ketentuan Kredit";
			tmp.Rows[0].Cells.Add(new TableCell());
			tmp.Rows[0].Cells[1].Text = ":";
			tmp.Rows[0].Cells.Add(new TableCell());
			tmp.Rows[0].Cells[2].Text = conn.GetFieldValue("KET_DESC");

			///////////////////////////////////////////////////
			///	Nomor Rekening
			///	
			tmp.Rows.Add(new TableRow());
			tmp.Rows[1].Cells.Add(new TableCell());
			tmp.Rows[1].Cells[0].Width = Unit.Pixel(250);
			tmp.Rows[1].Cells[0].Text = "Account No";
			tmp.Rows[1].Cells.Add(new TableCell());
			tmp.Rows[1].Cells[1].Text = ":";
			tmp.Rows[1].Cells.Add(new TableCell());
			tmp.Rows[1].Cells[2].Text = ACC_NO;

			//////////////////////////////////////////////////////
			///	Jenis Pengajuan
			///	
			tmp.Rows.Add(new TableRow());
			tmp.Rows[2].Cells.Add(new TableCell());
			tmp.Rows[2].Cells[0].Width = Unit.Pixel(250);
			tmp.Rows[2].Cells[0].Text = "Jenis Pengajuan";
			tmp.Rows[2].Cells.Add(new TableCell());
			tmp.Rows[2].Cells[1].Text = ":";
			tmp.Rows[2].Cells.Add(new TableCell());
			tmp.Rows[2].Cells[2].Text = conn.GetFieldValue("APPTYPEDESC");

			////////////////////////////////////////////////////////
			///	Jenis Kredit + No Fasilitas
			///	
			tmp.Rows.Add(new TableRow());
			tmp.Rows[3].Cells.Add(new TableCell());
			tmp.Rows[3].Cells[0].Width = Unit.Pixel(250);
			tmp.Rows[3].Cells[0].Text = "Jenis Kredit";
			tmp.Rows[3].Cells.Add(new TableCell());
			tmp.Rows[3].Cells[1].Text = ":";
			tmp.Rows[3].Cells.Add(new TableCell());
			tmp.Rows[3].Cells[2].Text = conn.GetFieldValue("PRODUCTDESC") + " (" + conn.GetFieldValue("PRODUCTID") + ")";

			////////////////////////////////////////////////////////
			///	Pembentukan
			///	
			tmp.Rows.Add(new TableRow());
			tmp.Rows[4].Cells.Add(new TableCell());
			tmp.Rows[4].Cells[0].Width = Unit.Pixel(250);
			tmp.Rows[4].Cells[0].Text = "Pembentukan";
			tmp.Rows[4].Cells.Add(new TableCell());
			tmp.Rows[4].Cells[1].Text = ":";
			tmp.Rows[4].Cells.Add(new TableCell());
			tmp.Rows[4].Cells[2].Text = conn.GetFieldValue("revolving");

			/////////////////////////////////////////////////////////////
			///	Installment / bunga per bulan
			///	
			tmp.Rows.Add(new TableRow());
			tmp.Rows[5].Cells.Add(new TableCell());
			tmp.Rows[5].Cells[0].Width = Unit.Pixel(250);
			tmp.Rows[5].Cells[0].Text = conn.GetFieldValue("INSTALL");//"Installment";
			tmp.Rows[5].Cells.Add(new TableCell());
			tmp.Rows[5].Cells[1].Text = ":";
			tmp.Rows[5].Cells.Add(new TableCell());
			tmp.Rows[5].Cells[2].Text = tools.MoneyFormat(conn.GetFieldValue("CP_INSTALLMENT"));

			/////////////////////////////////////////////////////////////////
			///	Limit Booked
			///	
			tmp.Rows.Add(new TableRow());
			tmp.Rows[6].Cells.Add(new TableCell());
			tmp.Rows[6].Cells[0].Width = Unit.Pixel(250);
			tmp.Rows[6].Cells[0].Text = "Limit";
			tmp.Rows[6].Cells.Add(new TableCell());
			tmp.Rows[6].Cells[1].Text = ":";
			tmp.Rows[6].Cells.Add(new TableCell());
			tmp.Rows[6].Cells[2].Text = tools.MoneyFormat(conn.GetFieldValue("BC_LOANAMOUNT"));
			
			//////////////////////////////////////////////////////////////////
			///	Project
			///	
			tmp.Rows.Add(new TableRow());
			tmp.Rows[7].Cells.Add(new TableCell());
			tmp.Rows[7].Cells[0].Width = Unit.Pixel(250);
			tmp.Rows[7].Cells[0].Text = "Project";
			tmp.Rows[7].Cells.Add(new TableCell());
			tmp.Rows[7].Cells[1].Text = ":";
			tmp.Rows[7].Cells.Add(new TableCell());
			tmp.Rows[7].Cells[2].Text = conn.GetFieldValue("PRJ_NAME");
			/////////////////////////////////////////////////////////////////////
			///	Tenor lama
			///	
			tmp.Rows.Add(new TableRow());
			tmp.Rows[8].Cells.Add(new TableCell());
			tmp.Rows[8].Cells[0].Width = Unit.Pixel(250);
			tmp.Rows[8].Cells[0].Text = "Tenor Lama";
			tmp.Rows[8].Cells.Add(new TableCell());
			tmp.Rows[8].Cells[1].Text = ":";
			tmp.Rows[8].Cells.Add(new TableCell());
			tmp.Rows[8].Cells[2].Text = conn.GetFieldValue("OLD_TENOR");
		
			///////////////////////////////////////////////////////////////////
			///	Tenor Baru
			///	
			tmp.Rows.Add(new TableRow());
			tmp.Rows[9].Cells.Add(new TableCell());
			tmp.Rows[9].Cells[0].Width = Unit.Pixel(250);
			tmp.Rows[9].Cells[0].Text = "Tenor Baru";
			tmp.Rows[9].Cells.Add(new TableCell());
			tmp.Rows[9].Cells[1].Text = ":";
			tmp.Rows[9].Cells.Add(new TableCell());
			tmp.Rows[9].Cells[2].Text =  conn.GetFieldValue("CP_TENOR");

			PlaceHolder1.Controls.Add(tmp);

			System.Web.UI.WebControls.Literal lit1 = new System.Web.UI.WebControls.Literal();
			lit1.Text = "<br><b>Decision History Product " + conn.GetFieldValue("PRODUCTDESC") + "</b>";

			PlaceHolder1.Controls.Add(lit1);

			conn.QueryString = "select * from vw_approvaldecision where ap_regno = '" + LBL_APREGNO.Text + 
				"' and userid <> '" + Session["UserID"].ToString()  + 
				"' and productid = '" + productID + 
				"' and apptype = '" + vapptype +
				"' and prod_seq = '" + prod_seq + "' order by ad_seq";
			conn.ExecuteQuery();

			for (int k = 0; k < conn.GetRowCount(); k++)
			{
				System.Web.UI.WebControls.Table dec = new System.Web.UI.WebControls.Table();
				int no = k + 1;

				////////////////////////////////////////
				///	PIC Approval
				///	
				dec.Rows.Add(new TableRow());
				dec.Rows[0].Cells.Add(new TableCell());
				dec.Rows[0].Cells[0].Text = no.ToString() + ".";
				dec.Rows[0].Cells.Add(new TableCell());
				dec.Rows[0].Cells[1].Width = Unit.Pixel(250);
				dec.Rows[0].Cells[1].Text = "Person in charge";
				dec.Rows[0].Cells.Add(new TableCell());
				dec.Rows[0].Cells[2].Text = ":";
				dec.Rows[0].Cells.Add(new TableCell());
				dec.Rows[0].Cells[3].Text = conn.GetFieldValue(k, "su_fullname");

				//////////////////////////////////////////
				///	Group PIC Approval
				///	
				dec.Rows.Add(new TableRow());
				dec.Rows[1].Cells.Add(new TableCell());
				dec.Rows[1].Cells.Add(new TableCell());
				dec.Rows[1].Cells[1].Width = Unit.Pixel(250);
				dec.Rows[1].Cells[1].Text = "Group";
				dec.Rows[1].Cells.Add(new TableCell());
				dec.Rows[1].Cells[2].Text = ":";
				dec.Rows[1].Cells.Add(new TableCell());
				dec.Rows[1].Cells[3].Text = conn.GetFieldValue(k, "sg_grpname");

				///////////////////////////////////////////
				///	Status PIC Approval
				///	
				dec.Rows.Add(new TableRow());
				dec.Rows[2].Cells.Add(new TableCell());
				dec.Rows[2].Cells.Add(new TableCell());
				dec.Rows[2].Cells[1].Width = Unit.Pixel(250);
				dec.Rows[2].Cells[1].Text = "Decision";
				dec.Rows[2].Cells.Add(new TableCell());
				dec.Rows[2].Cells[2].Text = ":";
				dec.Rows[2].Cells.Add(new TableCell());
				dec.Rows[2].Cells[3].Text = conn.GetFieldValue(k, "ad_status");

				//////////////////////////////////////////////////
				///	Tenor Approved
				///	
				dec.Rows.Add(new TableRow());
				dec.Rows[3].Cells.Add(new TableCell());
				dec.Rows[3].Cells.Add(new TableCell());
				dec.Rows[3].Cells[1].Width = Unit.Pixel(250);
				dec.Rows[3].Cells[1].Text = "Tenor Limit";
				dec.Rows[3].Cells.Add(new TableCell());
				dec.Rows[3].Cells[2].Text = ":";
				dec.Rows[3].Cells.Add(new TableCell());				
				dec.Rows[3].Cells[3].Text = conn.GetFieldValue(k, "ad_tenor");


				/////////////////////////////////////////////////////
				///	Override Status
				///	
				dec.Rows.Add(new TableRow());
				dec.Rows[4].Cells.Add(new TableCell());
				dec.Rows[4].Cells.Add(new TableCell());
				dec.Rows[4].Cells[1].Width = Unit.Pixel(250);
				dec.Rows[4].Cells[1].Text = "Override Status";
				dec.Rows[4].Cells.Add(new TableCell());
				dec.Rows[4].Cells[2].Text = ":";
				dec.Rows[4].Cells.Add(new TableCell());
				dec.Rows[4].Cells[3].Text = conn.GetFieldValue(k, "ad_ovrsta");

				dec.Rows.Add(new TableRow());

				PlaceHolder1.Controls.Add(dec);
			}

			System.Web.UI.WebControls.Literal lit2 = new System.Web.UI.WebControls.Literal();
			lit2.Text = "<br><br>";

			PlaceHolder1.Controls.Add(lit2);
		}

		private void ViewSK041()
		{
		}

		private void ViewSK05(string vapptype, string productID, string prod_seq)
		{
			Query(vapptype, productID, prod_seq);

			/**
			System.Web.UI.WebControls.Literal lit = new System.Web.UI.WebControls.Literal();
			lit.Text = "<b>Product " + conn.GetFieldValue("PRODUCTDESC") + "</b>";
			PlaceHolder1.Controls.Add(lit);
			**/

			System.Web.UI.WebControls.Table tmp = new System.Web.UI.WebControls.Table();
			
			tmp.Rows.Add(new TableRow());
			tmp.Rows[0].Cells.Add(new TableCell());
			tmp.Rows[0].Cells[0].Width = Unit.Pixel(250);
			tmp.Rows[0].Cells[0].Text = "Ketentuan Kredit";
			tmp.Rows[0].Cells.Add(new TableCell());
			tmp.Rows[0].Cells[1].Text = ":";
			tmp.Rows[0].Cells.Add(new TableCell());
			tmp.Rows[0].Cells[2].Text = conn.GetFieldValue("KET_DESC");

			tmp.Rows.Add(new TableRow());
			tmp.Rows[1].Cells.Add(new TableCell());
			tmp.Rows[1].Cells[0].Width = Unit.Pixel(250);
			tmp.Rows[1].Cells[0].Text = "Jenis Pengajuan";
			tmp.Rows[1].Cells.Add(new TableCell());
			tmp.Rows[1].Cells[1].Text = ":";
			tmp.Rows[1].Cells.Add(new TableCell());
			tmp.Rows[1].Cells[2].Text = conn.GetFieldValue("APPTYPEDESC");

			tmp.Rows.Add(new TableRow());
			tmp.Rows[2].Cells.Add(new TableCell());
			tmp.Rows[2].Cells[0].Width = Unit.Pixel(250);
			tmp.Rows[2].Cells[0].Text = "Jenis Kredit";
			tmp.Rows[2].Cells.Add(new TableCell());
			tmp.Rows[2].Cells[1].Text = ":";
			tmp.Rows[2].Cells.Add(new TableCell());
			tmp.Rows[2].Cells[2].Text = conn.GetFieldValue("PRODUCTDESC");

			tmp.Rows.Add(new TableRow());
			tmp.Rows[3].Cells.Add(new TableCell());
			tmp.Rows[3].Cells[0].Width = Unit.Pixel(250);
			tmp.Rows[3].Cells[0].Text = "Pembentukan";
			tmp.Rows[3].Cells.Add(new TableCell());
			tmp.Rows[3].Cells[1].Text = ":";
			tmp.Rows[3].Cells.Add(new TableCell());
			tmp.Rows[3].Cells[2].Text = conn.GetFieldValue("revolving");

			tmp.Rows.Add(new TableRow());
			tmp.Rows[4].Cells.Add(new TableCell());
			tmp.Rows[4].Cells[0].Width = Unit.Pixel(250);
			tmp.Rows[4].Cells[0].Text = "Limit";
			tmp.Rows[4].Cells.Add(new TableCell());
			tmp.Rows[4].Cells[1].Text = ":";
			tmp.Rows[4].Cells.Add(new TableCell());
			tmp.Rows[4].Cells[2].Text = tools.MoneyFormat(conn.GetFieldValue("BC_LOANAMOUNT"));

			tmp.Rows.Add(new TableRow());
			tmp.Rows[5].Cells.Add(new TableCell());
			tmp.Rows[5].Cells[0].Width = Unit.Pixel(250);
			tmp.Rows[5].Cells[0].Text = "Loan Term";
			tmp.Rows[5].Cells.Add(new TableCell());
			tmp.Rows[5].Cells[1].Text = ":";
			tmp.Rows[5].Cells.Add(new TableCell());
			tmp.Rows[5].Cells[2].Text = conn.GetFieldValue("CP_TENOR");

			tmp.Rows.Add(new TableRow());
			tmp.Rows[6].Cells.Add(new TableCell());
			tmp.Rows[6].Cells[0].Width = Unit.Pixel(250);
			tmp.Rows[6].Cells[0].Text = "Keterangan";
			tmp.Rows[6].Cells.Add(new TableCell());
			tmp.Rows[6].Cells[1].Text = ":";
			tmp.Rows[6].Cells.Add(new TableCell());
			tmp.Rows[6].Cells[2].Text = conn.GetFieldValue("CP_KETERANGAN");

			PlaceHolder1.Controls.Add(tmp);
			PlaceHolder1.Controls.Add(new LiteralControl("<BR><BR>"));
		}

		private void ViewSK01(string vapptype, string productID, string prod_seq)
		{
			Query(vapptype, productID, prod_seq);

			/**
			System.Web.UI.WebControls.Literal lit = new System.Web.UI.WebControls.Literal();
			lit.Text = "<b>Product " + conn.GetFieldValue("PRODUCTDESC") + "</b>";
			PlaceHolder1.Controls.Add(lit);
			**/

			System.Web.UI.WebControls.Table tmp = new System.Web.UI.WebControls.Table();
			
			tmp.Rows.Add(new TableRow());
			tmp.Rows[0].Cells.Add(new TableCell());
			tmp.Rows[0].Cells[0].Width = Unit.Pixel(250);
			tmp.Rows[0].Cells[0].Text = "Ketentuan Kredit";
			tmp.Rows[0].Cells.Add(new TableCell());
			tmp.Rows[0].Cells[1].Text = ":";
			tmp.Rows[0].Cells.Add(new TableCell());
			tmp.Rows[0].Cells[2].Text = conn.GetFieldValue("KET_DESC");

			tmp.Rows.Add(new TableRow());
			tmp.Rows[1].Cells.Add(new TableCell());
			tmp.Rows[1].Cells[0].Width = Unit.Pixel(250);
			tmp.Rows[1].Cells[0].Text = "Jenis Pengajuan";
			tmp.Rows[1].Cells.Add(new TableCell());
			tmp.Rows[1].Cells[1].Text = ":";
			tmp.Rows[1].Cells.Add(new TableCell());
			tmp.Rows[1].Cells[2].Text = conn.GetFieldValue("APPTYPEDESC");

			tmp.Rows.Add(new TableRow());
			tmp.Rows[2].Cells.Add(new TableCell());
			tmp.Rows[2].Cells[0].Width = Unit.Pixel(250);
			tmp.Rows[2].Cells[0].Text = "Jenis Kredit";
			tmp.Rows[2].Cells.Add(new TableCell());
			tmp.Rows[2].Cells[1].Text = ":";
			tmp.Rows[2].Cells.Add(new TableCell());
			tmp.Rows[2].Cells[2].Text = conn.GetFieldValue("PRODUCTDESC");

			tmp.Rows.Add(new TableRow());
			tmp.Rows[3].Cells.Add(new TableCell());
			tmp.Rows[3].Cells[0].Width = Unit.Pixel(250);
			tmp.Rows[3].Cells[0].Text = "Pembentukan";
			tmp.Rows[3].Cells.Add(new TableCell());
			tmp.Rows[3].Cells[1].Text = ":";
			tmp.Rows[3].Cells.Add(new TableCell());
			tmp.Rows[3].Cells[2].Text = conn.GetFieldValue("revolving");

			tmp.Rows.Add(new TableRow());
			tmp.Rows[4].Cells.Add(new TableCell());
			tmp.Rows[4].Cells[0].Width = Unit.Pixel(250);
			tmp.Rows[4].Cells[0].Text = "Tujuan Penggunaan";
			tmp.Rows[4].Cells.Add(new TableCell());
			tmp.Rows[4].Cells[1].Text = ":";
			tmp.Rows[4].Cells.Add(new TableCell());
			tmp.Rows[4].Cells[2].Text = conn.GetFieldValue("LOANPURPDESC");

			tmp.Rows.Add(new TableRow());
			tmp.Rows[5].Cells.Add(new TableCell());
			tmp.Rows[5].Cells[0].Width = Unit.Pixel(250);
			tmp.Rows[5].Cells[0].Text = conn.GetFieldValue("INSTALL");//"Installment";
			tmp.Rows[5].Cells.Add(new TableCell());
			tmp.Rows[5].Cells[1].Text = ":";
			tmp.Rows[5].Cells.Add(new TableCell());
			tmp.Rows[5].Cells[2].Text = tools.MoneyFormat(conn.GetFieldValue("CP_INSTALLMENT"));

			tmp.Rows.Add(new TableRow());
			tmp.Rows[6].Cells.Add(new TableCell());
			tmp.Rows[6].Cells[0].Width = Unit.Pixel(250);
			tmp.Rows[6].Cells[0].Text = "Limit";
			tmp.Rows[6].Cells.Add(new TableCell());
			tmp.Rows[6].Cells[1].Text = ":";
			tmp.Rows[6].Cells.Add(new TableCell());
			tmp.Rows[6].Cells[2].Text = tools.MoneyFormat(conn.GetFieldValue("CP_LIMIT"));

			tmp.Rows.Add(new TableRow());
			tmp.Rows[7].Cells.Add(new TableCell());
			tmp.Rows[7].Cells[0].Width = Unit.Pixel(250);
			tmp.Rows[7].Cells[0].Text = "Exchange Rate";
			tmp.Rows[7].Cells.Add(new TableCell());
			tmp.Rows[7].Cells[1].Text = ":";
			tmp.Rows[7].Cells.Add(new TableCell());
			tmp.Rows[7].Cells[2].Text = tools.MoneyFormat(conn.GetFieldValue("CP_EXRPLIMIT"));

			tmp.Rows.Add(new TableRow());
			tmp.Rows[8].Cells.Add(new TableCell());
			tmp.Rows[8].Cells[0].Width = Unit.Pixel(250);
			tmp.Rows[8].Cells[0].Text = "Limit Rp.";
			tmp.Rows[8].Cells.Add(new TableCell());
			tmp.Rows[8].Cells[1].Text = ":";
			tmp.Rows[8].Cells.Add(new TableCell());
			tmp.Rows[8].Cells[2].Text = tools.MoneyFormat(conn.GetFieldValue("CP_EXLIMITVAL"));

			tmp.Rows.Add(new TableRow());
			tmp.Rows[9].Cells.Add(new TableCell());
			tmp.Rows[9].Cells[0].Width = Unit.Pixel(250);
			tmp.Rows[9].Cells[0].Text = "Loan Term";
			tmp.Rows[9].Cells.Add(new TableCell());
			tmp.Rows[9].Cells[1].Text = ":";
			tmp.Rows[9].Cells.Add(new TableCell());
			tmp.Rows[9].Cells[2].Text = conn.GetFieldValue("CP_TENOR");

			tmp.Rows.Add(new TableRow());
			tmp.Rows[10].Cells.Add(new TableCell());
			tmp.Rows[10].Cells[0].Width = Unit.Pixel(250);
			tmp.Rows[10].Cells[0].Text = "Grace Period";
			tmp.Rows[10].Cells.Add(new TableCell());
			tmp.Rows[10].Cells[1].Text = ":";
			tmp.Rows[10].Cells.Add(new TableCell());
			tmp.Rows[10].Cells[2].Text = conn.GetFieldValue("CP_GRACEPERIOD");

			tmp.Rows.Add(new TableRow());
			tmp.Rows[11].Cells.Add(new TableCell());
			tmp.Rows[11].Cells[0].Width = Unit.Pixel(250);
			tmp.Rows[11].Cells[0].Text = "Repayment Frequency";
			tmp.Rows[11].Cells.Add(new TableCell());
			tmp.Rows[11].Cells[1].Text = ":";
			tmp.Rows[11].Cells.Add(new TableCell());
			tmp.Rows[11].Cells[2].Text = conn.GetFieldValue("CP_PAYMENTDESC");

			tmp.Rows.Add(new TableRow());
			tmp.Rows[12].Cells.Add(new TableCell());
			tmp.Rows[12].Cells[0].Width = Unit.Pixel(250);
			tmp.Rows[12].Cells[0].Text = conn.GetFieldValue("interesttype");
			tmp.Rows[12].Cells.Add(new TableCell());
			tmp.Rows[12].Cells[1].Text = ":";
			tmp.Rows[12].Cells.Add(new TableCell());
			tmp.Rows[12].Cells[2].Text =  conn.GetFieldValue("cp_interestvalue");

			PlaceHolder1.Controls.Add(tmp);

			System.Web.UI.WebControls.Literal lit1 = new System.Web.UI.WebControls.Literal();
			lit1.Text = "<br><b>Decision History Product " + conn.GetFieldValue("PRODUCTDESC") + "</b>";

			PlaceHolder1.Controls.Add(lit1);

			conn.QueryString = "select * from vw_approvaldecision where ap_regno = '" + LBL_APREGNO.Text + 
				"' and userid <> '" + Session["UserID"].ToString()  + 
				"' and productid = '" + productID + 
				"' and apptype = '" + vapptype +
				"' and prod_seq = '" + prod_seq + "' order by ad_seq";
			conn.ExecuteQuery();

			for (int k = 0; k < conn.GetRowCount(); k++)
			{
				System.Web.UI.WebControls.Table dec = new System.Web.UI.WebControls.Table();
				int no = k + 1;

				////////////////////////////////////////
				///	PIC Approval
				///	
				dec.Rows.Add(new TableRow());
				dec.Rows[0].Cells.Add(new TableCell());
				dec.Rows[0].Cells[0].Text = no.ToString() + ".";
				dec.Rows[0].Cells.Add(new TableCell());
				dec.Rows[0].Cells[1].Width = Unit.Pixel(250);
				dec.Rows[0].Cells[1].Text = "Person in charge";
				dec.Rows[0].Cells.Add(new TableCell());
				dec.Rows[0].Cells[2].Text = ":";
				dec.Rows[0].Cells.Add(new TableCell());
				dec.Rows[0].Cells[3].Text = conn.GetFieldValue(k, "su_fullname");

				//////////////////////////////////////////
				///	Group PIC Approval
				///	
				dec.Rows.Add(new TableRow());
				dec.Rows[1].Cells.Add(new TableCell());
				dec.Rows[1].Cells.Add(new TableCell());
				dec.Rows[1].Cells[1].Width = Unit.Pixel(250);
				dec.Rows[1].Cells[1].Text = "Group";
				dec.Rows[1].Cells.Add(new TableCell());
				dec.Rows[1].Cells[2].Text = ":";
				dec.Rows[1].Cells.Add(new TableCell());
				dec.Rows[1].Cells[3].Text = conn.GetFieldValue(k, "sg_grpname");

				///////////////////////////////////////////
				///	Status PIC Approval
				///	
				dec.Rows.Add(new TableRow());
				dec.Rows[2].Cells.Add(new TableCell());
				dec.Rows[2].Cells.Add(new TableCell());
				dec.Rows[2].Cells[1].Width = Unit.Pixel(250);
				dec.Rows[2].Cells[1].Text = "Decision";
				dec.Rows[2].Cells.Add(new TableCell());
				dec.Rows[2].Cells[2].Text = ":";
				dec.Rows[2].Cells.Add(new TableCell());
				dec.Rows[2].Cells[3].Text = conn.GetFieldValue(k, "ad_status");

				//////////////////////////////////////////////////
				///	Limit Approved
				///	
				dec.Rows.Add(new TableRow());
				dec.Rows[3].Cells.Add(new TableCell());
				dec.Rows[3].Cells.Add(new TableCell());
				dec.Rows[3].Cells[1].Width = Unit.Pixel(250);
				dec.Rows[3].Cells[1].Text = "Approved Limit";
				dec.Rows[3].Cells.Add(new TableCell());
				dec.Rows[3].Cells[2].Text = ":";
				dec.Rows[3].Cells.Add(new TableCell());				
				dec.Rows[3].Cells[3].Text = GlobalTools.MoneyFormat(conn.GetFieldValue(k, "ad_limit"));

				//////////////////////////////////////////////////
				///	Tenor Approved
				///	
				dec.Rows.Add(new TableRow());
				dec.Rows[4].Cells.Add(new TableCell());
				dec.Rows[4].Cells.Add(new TableCell());
				dec.Rows[4].Cells[1].Width = Unit.Pixel(250);
				dec.Rows[4].Cells[1].Text = "Approved Tenor";
				dec.Rows[4].Cells.Add(new TableCell());
				dec.Rows[4].Cells[2].Text = ":";
				dec.Rows[4].Cells.Add(new TableCell());
				dec.Rows[4].Cells[3].Text = conn.GetFieldValue(k, "ad_tenor") + " " + conn.GetFieldValue(k, "ad_tenorcode");

				/////////////////////////////////////////////////////
				///	Grace Period Approved
				///	
				dec.Rows.Add(new TableRow());
				dec.Rows[5].Cells.Add(new TableCell());
				dec.Rows[5].Cells.Add(new TableCell());
				dec.Rows[5].Cells[1].Width = Unit.Pixel(250);
				dec.Rows[5].Cells[1].Text = "Grace Periode";
				dec.Rows[5].Cells.Add(new TableCell());
				dec.Rows[5].Cells[2].Text = ":";
				dec.Rows[5].Cells.Add(new TableCell());
				dec.Rows[5].Cells[3].Text = conn.GetFieldValue(k , "ad_graceperiod");

				/////////////////////////////////////////////////////
				///	Repayment Frequency Approved
				///	
				dec.Rows.Add(new TableRow());
				dec.Rows[6].Cells.Add(new TableCell());
				dec.Rows[6].Cells.Add(new TableCell());
				dec.Rows[6].Cells[1].Width = Unit.Pixel(250);
				dec.Rows[6].Cells[1].Text = "Repayment Frequency";
				dec.Rows[6].Cells.Add(new TableCell());
				dec.Rows[6].Cells[2].Text = ":";
				dec.Rows[6].Cells.Add(new TableCell());
				dec.Rows[6].Cells[3].Text = conn.GetFieldValue(k, "ad_paymentfreqdesc");

				/////////////////////////////////////////////////////
				///	Bunga
				///	
				dec.Rows.Add(new TableRow());
				dec.Rows[7].Cells.Add(new TableCell());
				dec.Rows[7].Cells.Add(new TableCell());
				dec.Rows[7].Cells[1].Width = Unit.Pixel(250);
				dec.Rows[7].Cells[1].Text = "Bunga / p.a";
				dec.Rows[7].Cells.Add(new TableCell());
				dec.Rows[7].Cells[2].Text = ":";
				dec.Rows[7].Cells.Add(new TableCell());
				dec.Rows[7].Cells[3].Text = conn.GetFieldValue(k, "interestvalue");

				/////////////////////////////////////////////////////
				///	Override Status
				///	
				dec.Rows.Add(new TableRow());
				dec.Rows[8].Cells.Add(new TableCell());
				dec.Rows[8].Cells.Add(new TableCell());
				dec.Rows[8].Cells[1].Width = Unit.Pixel(250);
				dec.Rows[8].Cells[1].Text = "Override Status";
				dec.Rows[8].Cells.Add(new TableCell());
				dec.Rows[8].Cells[2].Text = ":";
				dec.Rows[8].Cells.Add(new TableCell());
				dec.Rows[8].Cells[3].Text = conn.GetFieldValue(k, "ad_ovrsta");

				dec.Rows.Add(new TableRow());

				PlaceHolder1.Controls.Add(dec);
			}

			System.Web.UI.WebControls.Literal lit2 = new System.Web.UI.WebControls.Literal();
			lit2.Text = "<br><br>";

			PlaceHolder1.Controls.Add(lit2);
		}

		private void ViewSK011()
		{
		}

		private void ViewSK02(string vapptype, string productID, string prod_seq)
		{
			//////////////////////////////////////////////////////
			///	mengambil AA NO, Kode Fasilitas, account number
			///	
			conn.QueryString = "select ACC_NO from vw_custproduct where ap_regno = '" + LBL_APREGNO.Text + 
				"' and apptype = '" + vapptype + 
				"' and productid = '" + productID + 
				"' and prod_seq = '" + prod_seq + "'";
			conn.ExecuteQuery();
			string ACC_NO = conn.GetFieldValue("ACC_NO");

			Query(vapptype, productID, prod_seq);

			/**
			System.Web.UI.WebControls.Literal lit = new System.Web.UI.WebControls.Literal();
			lit.Text = "<b>Product " + conn.GetFieldValue("PRODUCTDESC") + "</b>";
			PlaceHolder1.Controls.Add(lit);
			**/

			System.Web.UI.WebControls.Table tmp = new System.Web.UI.WebControls.Table();
			
			tmp.Rows.Add(new TableRow());
			tmp.Rows[0].Cells.Add(new TableCell());
			tmp.Rows[0].Cells[0].Width = Unit.Pixel(250);
			tmp.Rows[0].Cells[0].Text = "Ketentuan Kredit";
			tmp.Rows[0].Cells.Add(new TableCell());
			tmp.Rows[0].Cells[1].Text = ":";
			tmp.Rows[0].Cells.Add(new TableCell());
			tmp.Rows[0].Cells[2].Text = conn.GetFieldValue("KET_DESC");

			tmp.Rows.Add(new TableRow());
			tmp.Rows[1].Cells.Add(new TableCell());
			tmp.Rows[1].Cells[0].Width = Unit.Pixel(250);
			tmp.Rows[1].Cells[0].Text = "Account No";
			tmp.Rows[1].Cells.Add(new TableCell());
			tmp.Rows[1].Cells[1].Text = ":";
			tmp.Rows[1].Cells.Add(new TableCell());
			tmp.Rows[1].Cells[2].Text = ACC_NO;

			tmp.Rows.Add(new TableRow());
			tmp.Rows[2].Cells.Add(new TableCell());
			tmp.Rows[2].Cells[0].Width = Unit.Pixel(250);
			tmp.Rows[2].Cells[0].Text = "Jenis Pengajuan";
			tmp.Rows[2].Cells.Add(new TableCell());
			tmp.Rows[2].Cells[1].Text = ":";
			tmp.Rows[2].Cells.Add(new TableCell());
			tmp.Rows[2].Cells[2].Text = conn.GetFieldValue("APPTYPEDESC");

			tmp.Rows.Add(new TableRow());
			tmp.Rows[3].Cells.Add(new TableCell());
			tmp.Rows[3].Cells[0].Width = Unit.Pixel(250);
			tmp.Rows[3].Cells[0].Text = "Jenis Kredit";
			tmp.Rows[3].Cells.Add(new TableCell());
			tmp.Rows[3].Cells[1].Text = ":";
			tmp.Rows[3].Cells.Add(new TableCell());
			tmp.Rows[3].Cells[2].Text = conn.GetFieldValue("PRODUCTDESC") + " (" + conn.GetFieldValue("PRODUCTID") + ")";

			tmp.Rows.Add(new TableRow());
			tmp.Rows[4].Cells.Add(new TableCell());
			tmp.Rows[4].Cells[0].Width = Unit.Pixel(250);
			tmp.Rows[4].Cells[0].Text = "Pembentukan";
			tmp.Rows[4].Cells.Add(new TableCell());
			tmp.Rows[4].Cells[1].Text = ":";
			tmp.Rows[4].Cells.Add(new TableCell());
			tmp.Rows[4].Cells[2].Text = conn.GetFieldValue("revolving");			

			PlaceHolder1.Controls.Add(tmp);

			//////////////////////////////////////////////////////////////////////
			///	membentuk table untuk collateral
			///	
			Table oTable		= new Table();
			TableRow rowColl	= new TableRow();

			TableCell cellColl	= new TableCell();
			cellColl.Text		= "Collateral Name";
			cellColl.CssClass	= "HeaderReportList";
			rowColl.Cells.Add(cellColl);

			cellColl	= new TableCell();
			cellColl.Text		= "Amount";
			cellColl.CssClass	= "HeaderReportList";
			rowColl.Cells.Add(cellColl);

			cellColl	= new TableCell();
			cellColl.Text		= "Klasifikasi Jaminan";
			cellColl.CssClass	= "HeaderReportList";
			rowColl.Cells.Add(cellColl);
		
			cellColl	= new TableCell();
			cellColl.Text		= "Currency";
			cellColl.CssClass	= "HeaderReportList";
			rowColl.Cells.Add(cellColl);

			cellColl	= new TableCell();
			cellColl.Text		= "Percentage";
			cellColl.CssClass	= "HeaderReportList";
			rowColl.Cells.Add(cellColl);

			cellColl	= new TableCell();
			cellColl.Text		= "Function";
			cellColl.CssClass	= "HeaderReportList";
			rowColl.Cells.Add(cellColl);

			oTable.Rows.Add(rowColl);

			ViewCollateral(vapptype, productID, prod_seq, ref oTable);
			//////////////////////////////////////////////////////////////////////////////
			///

			PlaceHolder1.Controls.Add(oTable);
			PlaceHolder1.Controls.Add(new LiteralControl("<BR><BR>"));
		}

		private void ViewCollateral(string varapptype, string productid, string prod_seq, ref Table oTable)
		{
			conn.QueryString = "SELECT SIBS_COLID, isnull(CL_DESC,'')+' ('+isnull(COLTYPEDESC,'')+')' as COLTYPEDESC, LC_VALUE, LC_PERCENTAGE, CL_CURRENCY, COLCLASSDESC, ACTION "+
				"FROM vw_report_DISBURSHEET_COL WHERE AP_REGNO='" + LBL_APREGNO.Text + "' AND PRODUCTID='" + productid + "' and PROD_SEQ = '" + prod_seq + "' ORDER BY COLTYPEID";
			conn.ExecuteQuery();

			for (int i = 0; i < conn.GetRowCount(); i++) 
			{
				oTable.Rows.Add(new TableRow());
				oTable.Rows[i].Cells.Add(new TableCell());
				oTable.Rows[i].Cells[0].Text = conn.GetFieldValue(i, "SIBS_COLID");
				oTable.Rows[i].Cells[0].HorizontalAlign = HorizontalAlign.Center;
				oTable.Rows[i].Cells[0].CssClass	= "ReportList";
				
				oTable.Rows[i].Cells.Add(new TableCell());
				oTable.Rows[i].Cells[1].Text = conn.GetFieldValue(i, "COLTYPEDESC");
				oTable.Rows[i].Cells[1].HorizontalAlign = HorizontalAlign.Center;
				oTable.Rows[i].Cells[1].CssClass	= "ReportList";

				oTable.Rows[i].Cells.Add(new TableCell());
				oTable.Rows[i].Cells[2].Text = tools.MoneyFormat(conn.GetFieldValue(i, "LC_VALUE"));
				oTable.Rows[i].Cells[2].HorizontalAlign = HorizontalAlign.Center;
				oTable.Rows[i].Cells[2].CssClass	= "ReportList";
				
				oTable.Rows[i].Cells.Add(new TableCell());
				oTable.Rows[i].Cells[3].Text = conn.GetFieldValue(i, "COLCLASSDESC");
				oTable.Rows[i].Cells[3].HorizontalAlign = HorizontalAlign.Center;
				oTable.Rows[i].Cells[3].CssClass	= "ReportList";

				oTable.Rows[i].Cells.Add(new TableCell());
				oTable.Rows[i].Cells[4].Text = conn.GetFieldValue(i, "CL_CURRENCY");
				oTable.Rows[i].Cells[4].HorizontalAlign = HorizontalAlign.Center;
				oTable.Rows[i].Cells[4].CssClass	= "ReportList";

				oTable.Rows[i].Cells.Add(new TableCell());
				oTable.Rows[i].Cells[5].Text = tools.ConvertNum(conn.GetFieldValue(i, "LC_PERCENTAGE"))+"%";
				oTable.Rows[i].Cells[5].HorizontalAlign = HorizontalAlign.Center;
				oTable.Rows[i].Cells[5].CssClass	= "ReportList";

				oTable.Rows[i].Cells.Add(new TableCell());
				oTable.Rows[i].Cells[6].Text = conn.GetFieldValue(i, "ACTION");
				oTable.Rows[i].Cells[6].HorizontalAlign = HorizontalAlign.Center;
				oTable.Rows[i].Cells[6].CssClass	= "ReportList";
			}
			conn.ClearData();
		}

		private void ViewSK03(string vapptype, string productID, string prod_seq)
		{
			//////////////////////////////////////////////////////
			///	mengambil AA NO, Kode Fasilitas, account number
			///	
			conn.QueryString = "select ACC_NO from vw_custproduct where ap_regno = '" + LBL_APREGNO.Text + 
				"' and apptype = '" + vapptype + 
				"' and productid = '" + productID + 
				"' and prod_seq = '" + prod_seq + "'";
			conn.ExecuteQuery();
			string ACC_NO = conn.GetFieldValue("ACC_NO");

			Query(vapptype, productID, prod_seq);

			/**
			System.Web.UI.WebControls.Literal lit = new System.Web.UI.WebControls.Literal();
			lit.Text = "<b>Product " + conn.GetFieldValue("PRODUCTDESC") + "</b>";
			PlaceHolder1.Controls.Add(lit);
			**/

			System.Web.UI.WebControls.Table tmp = new System.Web.UI.WebControls.Table();
			
			tmp.Rows.Add(new TableRow());
			tmp.Rows[0].Cells.Add(new TableCell());
			tmp.Rows[0].Cells[0].Width = Unit.Pixel(250);
			tmp.Rows[0].Cells[0].Text = "Ketentuan Kredit";
			tmp.Rows[0].Cells.Add(new TableCell());
			tmp.Rows[0].Cells[1].Text = ":";
			tmp.Rows[0].Cells.Add(new TableCell());
			tmp.Rows[0].Cells[2].Text = conn.GetFieldValue("KET_DESC");

			tmp.Rows.Add(new TableRow());
			tmp.Rows[1].Cells.Add(new TableCell());
			tmp.Rows[1].Cells[0].Width = Unit.Pixel(250);
			tmp.Rows[1].Cells[0].Text = "Account No";
			tmp.Rows[1].Cells.Add(new TableCell());
			tmp.Rows[1].Cells[1].Text = ":";
			tmp.Rows[1].Cells.Add(new TableCell());
			tmp.Rows[1].Cells[2].Text = ACC_NO;

			tmp.Rows.Add(new TableRow());
			tmp.Rows[2].Cells.Add(new TableCell());
			tmp.Rows[2].Cells[0].Width = Unit.Pixel(250);
			tmp.Rows[2].Cells[0].Text = "Jenis Pengajuan";
			tmp.Rows[2].Cells.Add(new TableCell());
			tmp.Rows[2].Cells[1].Text = ":";
			tmp.Rows[2].Cells.Add(new TableCell());
			tmp.Rows[2].Cells[2].Text = conn.GetFieldValue("APPTYPEDESC");

			tmp.Rows.Add(new TableRow());
			tmp.Rows[3].Cells.Add(new TableCell());
			tmp.Rows[3].Cells[0].Width = Unit.Pixel(250);
			tmp.Rows[3].Cells[0].Text = "Jenis Kredit";
			tmp.Rows[3].Cells.Add(new TableCell());
			tmp.Rows[3].Cells[1].Text = ":";
			tmp.Rows[3].Cells.Add(new TableCell());
			tmp.Rows[3].Cells[2].Text = conn.GetFieldValue("PRODUCTDESC") + " (" + conn.GetFieldValue("PRODUCTID") + ")";

			tmp.Rows.Add(new TableRow());
			tmp.Rows[4].Cells.Add(new TableCell());
			tmp.Rows[4].Cells[0].Width = Unit.Pixel(250);
			tmp.Rows[4].Cells[0].Text = "Pembentukan";
			tmp.Rows[4].Cells.Add(new TableCell());
			tmp.Rows[4].Cells[1].Text = ":";
			tmp.Rows[4].Cells.Add(new TableCell());
			tmp.Rows[4].Cells[2].Text = conn.GetFieldValue("revolving");

			tmp.Rows.Add(new TableRow());
			tmp.Rows[5].Cells.Add(new TableCell());
			tmp.Rows[5].Cells[0].Width = Unit.Pixel(250);
			tmp.Rows[5].Cells[0].Text = conn.GetFieldValue("INSTALL");//"Installment";
			tmp.Rows[5].Cells.Add(new TableCell());
			tmp.Rows[5].Cells[1].Text = ":";
			tmp.Rows[5].Cells.Add(new TableCell());
			tmp.Rows[5].Cells[2].Text = tools.MoneyFormat(conn.GetFieldValue("CP_INSTALLMENT"));

			tmp.Rows.Add(new TableRow());
			tmp.Rows[6].Cells.Add(new TableCell());
			tmp.Rows[6].Cells[0].Width = Unit.Pixel(250);
			tmp.Rows[6].Cells[0].Text = "Limit Lama";
			tmp.Rows[6].Cells.Add(new TableCell());
			tmp.Rows[6].Cells[1].Text = ":";
			tmp.Rows[6].Cells.Add(new TableCell());
			tmp.Rows[6].Cells[2].Text = tools.MoneyFormat(conn.GetFieldValue("BC_LOANAMOUNT"));
			
			tmp.Rows.Add(new TableRow());
			tmp.Rows[7].Cells.Add(new TableCell());
			tmp.Rows[7].Cells[0].Width = Unit.Pixel(250);
			tmp.Rows[7].Cells[0].Text = "Limit";
			tmp.Rows[7].Cells.Add(new TableCell());
			tmp.Rows[7].Cells[1].Text = ":";
			tmp.Rows[7].Cells.Add(new TableCell());
			tmp.Rows[7].Cells[2].Text = conn.GetFieldValue("CP_LIMITCHG") + " " + tools.MoneyFormat(conn.GetFieldValue("CP_LIMIT"));

			tmp.Rows.Add(new TableRow());
			tmp.Rows[8].Cells.Add(new TableCell());
			tmp.Rows[8].Cells[0].Width = Unit.Pixel(250);
			tmp.Rows[8].Cells[0].Text = "Exchange Rate";
			tmp.Rows[8].Cells.Add(new TableCell());
			tmp.Rows[8].Cells[1].Text = ":";
			tmp.Rows[8].Cells.Add(new TableCell());
			tmp.Rows[8].Cells[2].Text = tools.MoneyFormat(conn.GetFieldValue("CP_EXRPLIMIT"));

			tmp.Rows.Add(new TableRow());
			tmp.Rows[9].Cells.Add(new TableCell());
			tmp.Rows[9].Cells[0].Width = Unit.Pixel(250);
			tmp.Rows[9].Cells[0].Text = "Limit Rp.";
			tmp.Rows[9].Cells.Add(new TableCell());
			tmp.Rows[9].Cells[1].Text = ":";
			tmp.Rows[9].Cells.Add(new TableCell());
			tmp.Rows[9].Cells[2].Text = tools.MoneyFormat(conn.GetFieldValue("CP_EXLIMITVAL"));

			tmp.Rows.Add(new TableRow());
			tmp.Rows[10].Cells.Add(new TableCell());
			tmp.Rows[10].Cells[0].Width = Unit.Pixel(250);
			tmp.Rows[10].Cells[0].Text = "Loan Term";
			tmp.Rows[10].Cells.Add(new TableCell());
			tmp.Rows[10].Cells[1].Text = ":";
			tmp.Rows[10].Cells.Add(new TableCell());
			tmp.Rows[10].Cells[2].Text = conn.GetFieldValue("CP_TENOR");
		
			tmp.Rows.Add(new TableRow());
			tmp.Rows[11].Cells.Add(new TableCell());
			tmp.Rows[11].Cells[0].Width = Unit.Pixel(250);
			tmp.Rows[11].Cells[0].Text = conn.GetFieldValue("interesttype");
			tmp.Rows[11].Cells.Add(new TableCell());
			tmp.Rows[11].Cells[1].Text = ":";
			tmp.Rows[11].Cells.Add(new TableCell());
			tmp.Rows[11].Cells[2].Text =  conn.GetFieldValue("CP_interestvalue");

			PlaceHolder1.Controls.Add(tmp);

			System.Web.UI.WebControls.Literal lit1 = new System.Web.UI.WebControls.Literal();
			lit1.Text = "<br><b>Decision History Product " + conn.GetFieldValue("PRODUCTDESC") + "</b>";

			PlaceHolder1.Controls.Add(lit1);

			conn.QueryString = "select * from vw_approvaldecision where ap_regno = '" + LBL_APREGNO.Text + 
				"' and userid <> '" + Session["UserID"].ToString()  + 
				"' and productid = '" + productID + 
				"' and apptype = '" + vapptype +
				"' and prod_seq = '" + prod_seq + "' order by ad_seq";
			conn.ExecuteQuery();

			for (int k = 0; k < conn.GetRowCount(); k++)
			{
				System.Web.UI.WebControls.Table dec = new System.Web.UI.WebControls.Table();
				int no = k + 1;

				////////////////////////////////////////
				///	PIC Approval
				///	
				dec.Rows.Add(new TableRow());
				dec.Rows[0].Cells.Add(new TableCell());
				dec.Rows[0].Cells[0].Text = no.ToString() + ".";
				dec.Rows[0].Cells.Add(new TableCell());
				dec.Rows[0].Cells[1].Width = Unit.Pixel(250);
				dec.Rows[0].Cells[1].Text = "Person in charge";
				dec.Rows[0].Cells.Add(new TableCell());
				dec.Rows[0].Cells[2].Text = ":";
				dec.Rows[0].Cells.Add(new TableCell());
				dec.Rows[0].Cells[3].Text = conn.GetFieldValue(k, "su_fullname");


				//////////////////////////////////////////
				///	Group PIC Approval
				///	
				dec.Rows.Add(new TableRow());
				dec.Rows[1].Cells.Add(new TableCell());
				dec.Rows[1].Cells.Add(new TableCell());
				dec.Rows[1].Cells[1].Width = Unit.Pixel(250);
				dec.Rows[1].Cells[1].Text = "Group";
				dec.Rows[1].Cells.Add(new TableCell());
				dec.Rows[1].Cells[2].Text = ":";
				dec.Rows[1].Cells.Add(new TableCell());
				dec.Rows[1].Cells[3].Text = conn.GetFieldValue(k, "sg_grpname");


				///////////////////////////////////////////
				///	Status PIC Approval
				///	
				dec.Rows.Add(new TableRow());
				dec.Rows[2].Cells.Add(new TableCell());
				dec.Rows[2].Cells.Add(new TableCell());
				dec.Rows[2].Cells[1].Width = Unit.Pixel(250);
				dec.Rows[2].Cells[1].Text = "Decision";
				dec.Rows[2].Cells.Add(new TableCell());
				dec.Rows[2].Cells[2].Text = ":";
				dec.Rows[2].Cells.Add(new TableCell());
				dec.Rows[2].Cells[3].Text = conn.GetFieldValue(k, "ad_status");


				//////////////////////////////////////////////////
				///	Limit Approved
				///	
				dec.Rows.Add(new TableRow());
				dec.Rows[3].Cells.Add(new TableCell());
				dec.Rows[3].Cells.Add(new TableCell());
				dec.Rows[3].Cells[1].Width = Unit.Pixel(250);
				dec.Rows[3].Cells[1].Text = "Approved Limit";
				dec.Rows[3].Cells.Add(new TableCell());
				dec.Rows[3].Cells[2].Text = ":";
				dec.Rows[3].Cells.Add(new TableCell());				
				dec.Rows[3].Cells[3].Text = GlobalTools.MoneyFormat(conn.GetFieldValue(k, "ad_exlimitval"));
				

				//////////////////////////////////////////////////
				///	Exchange Rate
				///	
				dec.Rows.Add(new TableRow());
				dec.Rows[3].Cells.Add(new TableCell());
				dec.Rows[3].Cells.Add(new TableCell());
				dec.Rows[3].Cells[1].Width = Unit.Pixel(250);
				dec.Rows[3].Cells[1].Text = "Exchange Rate";
				dec.Rows[3].Cells.Add(new TableCell());
				dec.Rows[3].Cells[2].Text = ":";
				dec.Rows[3].Cells.Add(new TableCell());				
				dec.Rows[3].Cells[3].Text = GlobalTools.MoneyFormat(conn.GetFieldValue(k, "ad_exrplimit"));


				//////////////////////////////////////////////////
				///	Limit Approved (in Rupiah)
				///	
				dec.Rows.Add(new TableRow());
				dec.Rows[3].Cells.Add(new TableCell());
				dec.Rows[3].Cells.Add(new TableCell());
				dec.Rows[3].Cells[1].Width = Unit.Pixel(250);
				dec.Rows[3].Cells[1].Text = "Approved Limit (Rp)";
				dec.Rows[3].Cells.Add(new TableCell());
				dec.Rows[3].Cells[2].Text = ":";
				dec.Rows[3].Cells.Add(new TableCell());				
				dec.Rows[3].Cells[3].Text = GlobalTools.MoneyFormat(conn.GetFieldValue(k, "ad_limit"));


				/////////////////////////////////////////////////////
				///	Override Status
				///	
				dec.Rows.Add(new TableRow());
				dec.Rows[4].Cells.Add(new TableCell());
				dec.Rows[4].Cells.Add(new TableCell());
				dec.Rows[4].Cells[1].Width = Unit.Pixel(250);
				dec.Rows[4].Cells[1].Text = "Override Status";
				dec.Rows[4].Cells.Add(new TableCell());
				dec.Rows[4].Cells[2].Text = ":";
				dec.Rows[4].Cells.Add(new TableCell());
				dec.Rows[4].Cells[3].Text = conn.GetFieldValue(k, "ad_ovrsta");

				dec.Rows.Add(new TableRow());

				PlaceHolder1.Controls.Add(dec);
			}

			System.Web.UI.WebControls.Literal lit2 = new System.Web.UI.WebControls.Literal();
			lit2.Text = "<br><br>";

			PlaceHolder1.Controls.Add(lit2);
		}

		private void ViewSK06(string vapptype, string productID, string prod_seq)
		{
			Query(vapptype, productID, prod_seq);

			/**
			System.Web.UI.WebControls.Literal lit = new System.Web.UI.WebControls.Literal();
			lit.Text = "<b>Product " + conn.GetFieldValue("PRODUCTDESC") + "</b>";
			PlaceHolder1.Controls.Add(lit);
			**/

			System.Web.UI.WebControls.Table tmp = new System.Web.UI.WebControls.Table();
			
			tmp.Rows.Add(new TableRow());
			tmp.Rows[0].Cells.Add(new TableCell());
			tmp.Rows[0].Cells[0].Width = Unit.Pixel(250);
			tmp.Rows[0].Cells[0].Text = "Ketentuan Kredit";
			tmp.Rows[0].Cells.Add(new TableCell());
			tmp.Rows[0].Cells[1].Text = ":";
			tmp.Rows[0].Cells.Add(new TableCell());
			tmp.Rows[0].Cells[2].Text = conn.GetFieldValue("KET_DESC");

			tmp.Rows.Add(new TableRow());
			tmp.Rows[1].Cells.Add(new TableCell());
			tmp.Rows[1].Cells[0].Width = Unit.Pixel(250);
			tmp.Rows[1].Cells[0].Text = "Jenis Pengajuan";
			tmp.Rows[1].Cells.Add(new TableCell());
			tmp.Rows[1].Cells[1].Text = ":";
			tmp.Rows[1].Cells.Add(new TableCell());
			tmp.Rows[1].Cells[2].Text = conn.GetFieldValue("APPTYPEDESC");

			tmp.Rows.Add(new TableRow());
			tmp.Rows[2].Cells.Add(new TableCell());
			tmp.Rows[2].Cells[0].Width = Unit.Pixel(250);
			tmp.Rows[2].Cells[0].Text = "Jenis Kredit";
			tmp.Rows[2].Cells.Add(new TableCell());
			tmp.Rows[2].Cells[1].Text = ":";
			tmp.Rows[2].Cells.Add(new TableCell());
			tmp.Rows[2].Cells[2].Text = conn.GetFieldValue("PRODUCTDESC");

			tmp.Rows.Add(new TableRow());
			tmp.Rows[3].Cells.Add(new TableCell());
			tmp.Rows[3].Cells[0].Width = Unit.Pixel(250);
			tmp.Rows[3].Cells[0].Text = "Pembentukan";
			tmp.Rows[3].Cells.Add(new TableCell());
			tmp.Rows[3].Cells[1].Text = ":";
			tmp.Rows[3].Cells.Add(new TableCell());
			tmp.Rows[3].Cells[2].Text = conn.GetFieldValue("revolving");

			tmp.Rows.Add(new TableRow());
			tmp.Rows[4].Cells.Add(new TableCell());
			tmp.Rows[4].Cells[0].Width = Unit.Pixel(250);
			tmp.Rows[4].Cells[0].Text = "Tujuan Penggunaan";
			tmp.Rows[4].Cells.Add(new TableCell());
			tmp.Rows[4].Cells[1].Text = ":";
			tmp.Rows[4].Cells.Add(new TableCell());
			tmp.Rows[4].Cells[2].Text = conn.GetFieldValue("LOANPURPDESC");

			tmp.Rows.Add(new TableRow());
			tmp.Rows[5].Cells.Add(new TableCell());
			tmp.Rows[5].Cells[0].Width = Unit.Pixel(250);
			tmp.Rows[5].Cells[0].Text = conn.GetFieldValue("INSTALL");//"Installment";
			tmp.Rows[5].Cells.Add(new TableCell());
			tmp.Rows[5].Cells[1].Text = ":";
			tmp.Rows[5].Cells.Add(new TableCell());
			tmp.Rows[5].Cells[2].Text = tools.MoneyFormat(conn.GetFieldValue("CP_INSTALLMENT"));

			tmp.Rows.Add(new TableRow());
			tmp.Rows[6].Cells.Add(new TableCell());
			tmp.Rows[6].Cells[0].Width = Unit.Pixel(250);
			tmp.Rows[6].Cells[0].Text = "Limit";
			tmp.Rows[6].Cells.Add(new TableCell());
			tmp.Rows[6].Cells[1].Text = ":";
			tmp.Rows[6].Cells.Add(new TableCell());
			tmp.Rows[6].Cells[2].Text = tools.MoneyFormat(conn.GetFieldValue("CP_LIMIT"));

			tmp.Rows.Add(new TableRow());
			tmp.Rows[7].Cells.Add(new TableCell());
			tmp.Rows[7].Cells[0].Width = Unit.Pixel(250);
			tmp.Rows[7].Cells[0].Text = "Exchange Rate";
			tmp.Rows[7].Cells.Add(new TableCell());
			tmp.Rows[7].Cells[1].Text = ":";
			tmp.Rows[7].Cells.Add(new TableCell());
			tmp.Rows[7].Cells[2].Text = tools.MoneyFormat(conn.GetFieldValue("CP_EXRPLIMIT"));

			tmp.Rows.Add(new TableRow());
			tmp.Rows[8].Cells.Add(new TableCell());
			tmp.Rows[8].Cells[0].Width = Unit.Pixel(250);
			tmp.Rows[8].Cells[0].Text = "Limit Rp.";
			tmp.Rows[8].Cells.Add(new TableCell());
			tmp.Rows[8].Cells[1].Text = ":";
			tmp.Rows[8].Cells.Add(new TableCell());
			tmp.Rows[8].Cells[2].Text = tools.MoneyFormat(conn.GetFieldValue("CP_EXLIMITVAL"));

			tmp.Rows.Add(new TableRow());
			tmp.Rows[9].Cells.Add(new TableCell());
			tmp.Rows[9].Cells[0].Width = Unit.Pixel(250);
			tmp.Rows[9].Cells[0].Text = "Loan Term";
			tmp.Rows[9].Cells.Add(new TableCell());
			tmp.Rows[9].Cells[1].Text = ":";
			tmp.Rows[9].Cells.Add(new TableCell());
			tmp.Rows[9].Cells[2].Text = conn.GetFieldValue("CP_TENOR");

			tmp.Rows.Add(new TableRow());
			tmp.Rows[10].Cells.Add(new TableCell());
			tmp.Rows[10].Cells[0].Width = Unit.Pixel(250);
			tmp.Rows[10].Cells[0].Text = "Grace Period";
			tmp.Rows[10].Cells.Add(new TableCell());
			tmp.Rows[10].Cells[1].Text = ":";
			tmp.Rows[10].Cells.Add(new TableCell());
			tmp.Rows[10].Cells[2].Text = conn.GetFieldValue("CP_GRACEPERIOD");

			tmp.Rows.Add(new TableRow());
			tmp.Rows[11].Cells.Add(new TableCell());
			tmp.Rows[11].Cells[0].Width = Unit.Pixel(250);
			tmp.Rows[11].Cells[0].Text = "Repayment Frequency";
			tmp.Rows[11].Cells.Add(new TableCell());
			tmp.Rows[11].Cells[1].Text = ":";
			tmp.Rows[11].Cells.Add(new TableCell());
			tmp.Rows[11].Cells[2].Text = conn.GetFieldValue("CP_PAYMENTDESC");

			tmp.Rows.Add(new TableRow());
			tmp.Rows[12].Cells.Add(new TableCell());
			tmp.Rows[12].Cells[0].Width = Unit.Pixel(250);
			tmp.Rows[12].Cells[0].Text = conn.GetFieldValue("interesttype");
			tmp.Rows[12].Cells.Add(new TableCell());
			tmp.Rows[12].Cells[1].Text = ":";
			tmp.Rows[12].Cells.Add(new TableCell());
			tmp.Rows[12].Cells[2].Text =  conn.GetFieldValue("cp_interestvalue");

			PlaceHolder1.Controls.Add(tmp);

			System.Web.UI.WebControls.Literal lit1 = new System.Web.UI.WebControls.Literal();
			lit1.Text = "<br><b>Decision History Product " + conn.GetFieldValue("PRODUCTDESC") + "</b>";

			PlaceHolder1.Controls.Add(lit1);

			conn.QueryString = "select * from vw_approvaldecision where ap_regno = '" + LBL_APREGNO.Text + 
				"' and userid <> '" + Session["UserID"].ToString()  + 
				"' and productid = '" + productID + 
				"' and prod_seq = '" + prod_seq + "' order by ad_seq";
			conn.ExecuteQuery();

			for (int k = 0; k < conn.GetRowCount(); k++)
			{
				System.Web.UI.WebControls.Table dec = new System.Web.UI.WebControls.Table();
				int no = k + 1;

				////////////////////////////////////////
				///	PIC Approval
				///	
				dec.Rows.Add(new TableRow());
				dec.Rows[0].Cells.Add(new TableCell());
				dec.Rows[0].Cells[0].Text = no.ToString() + ".";
				dec.Rows[0].Cells.Add(new TableCell());
				dec.Rows[0].Cells[1].Width = Unit.Pixel(250);
				dec.Rows[0].Cells[1].Text = "Person in charge";
				dec.Rows[0].Cells.Add(new TableCell());
				dec.Rows[0].Cells[2].Text = ":";
				dec.Rows[0].Cells.Add(new TableCell());
				dec.Rows[0].Cells[3].Text = conn.GetFieldValue(k, "su_fullname");

				//////////////////////////////////////////
				///	Group PIC Approval
				///	
				dec.Rows.Add(new TableRow());
				dec.Rows[1].Cells.Add(new TableCell());
				dec.Rows[1].Cells.Add(new TableCell());
				dec.Rows[1].Cells[1].Width = Unit.Pixel(250);
				dec.Rows[1].Cells[1].Text = "Group";
				dec.Rows[1].Cells.Add(new TableCell());
				dec.Rows[1].Cells[2].Text = ":";
				dec.Rows[1].Cells.Add(new TableCell());
				dec.Rows[1].Cells[3].Text = conn.GetFieldValue(k, "sg_grpname");

				///////////////////////////////////////////
				///	Status PIC Approval
				///	
				dec.Rows.Add(new TableRow());
				dec.Rows[2].Cells.Add(new TableCell());
				dec.Rows[2].Cells.Add(new TableCell());
				dec.Rows[2].Cells[1].Width = Unit.Pixel(250);
				dec.Rows[2].Cells[1].Text = "Decision";
				dec.Rows[2].Cells.Add(new TableCell());
				dec.Rows[2].Cells[2].Text = ":";
				dec.Rows[2].Cells.Add(new TableCell());
				dec.Rows[2].Cells[3].Text = conn.GetFieldValue(k, "ad_status");

				//////////////////////////////////////////////////
				///	Limit Approved
				///	
				dec.Rows.Add(new TableRow());
				dec.Rows[3].Cells.Add(new TableCell());
				dec.Rows[3].Cells.Add(new TableCell());
				dec.Rows[3].Cells[1].Width = Unit.Pixel(250);
				dec.Rows[3].Cells[1].Text = "Approved Limit";
				dec.Rows[3].Cells.Add(new TableCell());
				dec.Rows[3].Cells[2].Text = ":";
				dec.Rows[3].Cells.Add(new TableCell());				
				dec.Rows[3].Cells[3].Text = GlobalTools.MoneyFormat(conn.GetFieldValue(k, "ad_limit"));

				//////////////////////////////////////////////////
				///	Tenor Approved
				///	
				dec.Rows.Add(new TableRow());
				dec.Rows[4].Cells.Add(new TableCell());
				dec.Rows[4].Cells.Add(new TableCell());
				dec.Rows[4].Cells[1].Width = Unit.Pixel(250);
				dec.Rows[4].Cells[1].Text = "Approved Tenor";
				dec.Rows[4].Cells.Add(new TableCell());
				dec.Rows[4].Cells[2].Text = ":";
				dec.Rows[4].Cells.Add(new TableCell());
				dec.Rows[4].Cells[3].Text = conn.GetFieldValue(k, "ad_tenor") + " " + conn.GetFieldValue(k, "ad_tenorcode");

				/////////////////////////////////////////////////////
				///	Grace Period Approved
				///	
				dec.Rows.Add(new TableRow());
				dec.Rows[5].Cells.Add(new TableCell());
				dec.Rows[5].Cells.Add(new TableCell());
				dec.Rows[5].Cells[1].Width = Unit.Pixel(250);
				dec.Rows[5].Cells[1].Text = "Grace Periode";
				dec.Rows[5].Cells.Add(new TableCell());
				dec.Rows[5].Cells[2].Text = ":";
				dec.Rows[5].Cells.Add(new TableCell());
				dec.Rows[5].Cells[3].Text = conn.GetFieldValue(k, "ad_graceperiod");

				/////////////////////////////////////////////////////
				///	Repayment Frequency Approved
				///	
				dec.Rows.Add(new TableRow());
				dec.Rows[6].Cells.Add(new TableCell());
				dec.Rows[6].Cells.Add(new TableCell());
				dec.Rows[6].Cells[1].Width = Unit.Pixel(250);
				dec.Rows[6].Cells[1].Text = "Repayment Frequency";
				dec.Rows[6].Cells.Add(new TableCell());
				dec.Rows[6].Cells[2].Text = ":";
				dec.Rows[6].Cells.Add(new TableCell());
				dec.Rows[6].Cells[3].Text = conn.GetFieldValue(k, "ad_paymentfreqdesc");

				/////////////////////////////////////////////////////
				///	Bunga
				///	
				dec.Rows.Add(new TableRow());
				dec.Rows[7].Cells.Add(new TableCell());
				dec.Rows[7].Cells.Add(new TableCell());
				dec.Rows[7].Cells[1].Width = Unit.Pixel(250);
				dec.Rows[7].Cells[1].Text = "Bunga / p.a";
				dec.Rows[7].Cells.Add(new TableCell());
				dec.Rows[7].Cells[2].Text = ":";
				dec.Rows[7].Cells.Add(new TableCell());
				dec.Rows[7].Cells[3].Text = conn.GetFieldValue(k, "interestvalue");

				/////////////////////////////////////////////////////
				///	Override Status
				///	
				dec.Rows.Add(new TableRow());
				dec.Rows[8].Cells.Add(new TableCell());
				dec.Rows[8].Cells.Add(new TableCell());
				dec.Rows[8].Cells[1].Width = Unit.Pixel(250);
				dec.Rows[8].Cells[1].Text = "Override Status";
				dec.Rows[8].Cells.Add(new TableCell());
				dec.Rows[8].Cells[2].Text = ":";
				dec.Rows[8].Cells.Add(new TableCell());
				dec.Rows[8].Cells[3].Text = conn.GetFieldValue(k, "ad_ovrsta");

				dec.Rows.Add(new TableRow());

				PlaceHolder1.Controls.Add(dec);
			}

			System.Web.UI.WebControls.Literal lit2 = new System.Web.UI.WebControls.Literal();
			lit2.Text = "<br><br>";

			PlaceHolder1.Controls.Add(lit2);
		}

		private void ViewAcc()
		{
			/*
			string aa_no		= conn.GetFieldValue("AA_NO").Trim();
			string no_fas		= conn.GetFieldValue("SIBS_PRODID").Trim();
			int seq				= int.Parse(tools.ConvertNum(conn.GetFieldValue("ACC_SEQ")));
			if (aa_no!="")
			{
				PanelACC.Visible		= true;
				LBL_ACCAANO.Text		= aa_no;
				LBL_ACCNOFASILITAS.Text	= no_fas;
				LBL_ACCSEQ.Text			= seq.ToString();
			}
			*/
		}

		private void ViewBEA()
		{
			/*
			conn.QueryString = "select APL_BEAADM, APL_BEAPROVISI, APL_BEANOTARIS, APL_BEAIKAT, APL_BEAMATERAI "+
				"from appproductlegal  "+
				"where ap_regno='"+LBL_APREGNO.Text+"' and productid='"+LBL_PRODUCTID.Text+"' AND APPTYPE IN (select distinct apptype from custproduct " +
				" where ket_code in (select ket_code from ketentuan_kredit where ap_regno = '" + LBL_APREGNO.Text + "'))";
			conn.ExecuteQuery();
			LBL_BIAYA_ADM.Text		= tools.MoneyFormat(conn.GetFieldValue("APL_BEAADM"));
			LBL_BIAYA_NOTARIS.Text	= tools.MoneyFormat(conn.GetFieldValue("APL_BEANOTARIS"));
			LBL_BIAYA_PROVISI.Text	= tools.MoneyFormat(conn.GetFieldValue("APL_BEAPROVISI"));
			LBL_BIAYA_IKAT.Text		= tools.MoneyFormat(conn.GetFieldValue("APL_BEAIKAT"));
			LBL_BIAYA_MATERAI.Text	= tools.MoneyFormat(conn.GetFieldValue("APL_BEAMATERAI"));
			conn.ClearData();
			*/
		}

		private void Button1_Click(object sender, System.EventArgs e)
		{
			Response.Redirect("DisbursementSheet.aspx?tc="+Request.QueryString["tc"]);
		}
	}
}