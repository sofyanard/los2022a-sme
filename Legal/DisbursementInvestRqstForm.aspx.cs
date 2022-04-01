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

namespace SME.Legal
{
	/// <summary>
	/// Summary description for DisbursementInvestRqstForm.
	/// </summary>
	public partial class DisbursementInvestRqstForm : System.Web.UI.Page
	{
		protected Connection conn = new Connection();
		protected Tools tool = new Tools();
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			conn = (Connection) Session["Connection"];

			viewdebitur();
			viewdata();
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
		private void viewdebitur()
		{
			string a = Request.QueryString["regno"];
			
			conn.QueryString = "select cu_custtypeid from customer where cu_ref in (select cu_ref from application where ap_regno = '" + a +"')";
			conn.ExecuteQuery();
			
			System.Data.DataTable dt;	
			dt = conn.GetDataTable().Copy();
			
			
			//if (dt.Rows[0]["cu_custtypeid"].ToString() == "01")// company
			if (conn.GetFieldValue("cu_custtypeid")=="01")
			{
				conn.QueryString = "select * from cust_company where cu_ref in (select cu_ref from application where ap_regno = '" + a + "')";
				conn.ExecuteQuery();
				try { LBL_DEBITUR.Text = conn.GetFieldValue("CU_COMPNAME").ToString(); }
				catch { LBL_DEBITUR.Text = "";}
			}
			else 
			{
				conn.QueryString = "select * from cust_personal where cu_ref in (select cu_ref from application where ap_regno = '" + a + "')";
				conn.ExecuteQuery();

				try { LBL_DEBITUR.Text = conn.GetFieldValue("CU_FIRSTNAME").ToString(); }
				catch { LBL_DEBITUR.Text = ""; }
			}

			LBL_TGLNILAI.Text = tool.FormatDate(System.DateTime.Now.ToString());

			conn.QueryString = "select * from ketentuan_kredit where ap_regno = '" + a + "'";
			conn.ExecuteQuery();
			System.Data.DataTable dt1 = new System.Data.DataTable();
			dt1 = conn.GetDataTable().Copy();

			string temp = "";
			double jns_product=0.00,limit_akhir=0.00,limit=0.00;
			for (int i=0;i<dt1.Rows.Count;i++)
			{
				
				/*
				conn.QueryString = "select kk.ket_code,prod.currency, cp.apptype, prod.productdesc, prod.jnsproduct, p.limit, p.baki_debet, ad.ad_limit,cp.cp_limitchg   from custproduct cp" +
					" left join ketentuan_kredit kk on kk.ap_regno = cp.ap_regno and kk.ket_code = cp.ket_code" +
					" left join application aa on aa.ap_regno = cp.ap_regno" +
					" left join bookedcust c on c.cu_ref = aa.cu_ref" +
					" left join bookedprod p  on (c.aa_no = p.aa_no and c.productid = p.productid) or (p.acc_no = kk.acc_no )" +
					" left join rfproduct prod on prod.productid = cp.productid" +
					" left join approval_decision ad on (ad.ap_regno = cp.ap_regno) and (ad.prod_seq = cp.prod_seq) and (ad.ad_seq = (select max(ad_seq) from approval_decision where ap_regno = '" + a + "' )) and (ad.ad_reject <> 1) AND (AD.APPTYPE = CP.APPTYPE)" +
					" where cp.ap_regno = '" + a + "' and cp.ket_code = '" + dt1.Rows[i]["KET_CODE"].ToString() + "'";
				conn.ExecuteQuery();
				System.Data.DataTable dt2 = new System.Data.DataTable();
				dt2 = conn.GetDataTable().Copy();

				Label t = new Label();
				//if (temp==dt2.Rows[i]["productdesc"].ToString() && limit==Convert.ToDouble(tool.ConvertNum(dt2.Rows[i]["limit"].ToString())))
				if (temp==dt2.Rows[i]["ket_code"].ToString())
					continue;
				else
				{
					temp=dt2.Rows[i]["ket_code"].ToString();
					limit=Convert.ToDouble(tool.ConvertNum(dt2.Rows[i]["limit"].ToString()));

				}
			
				t.Text = "-"+" "+ dt2.Rows[i]["productdesc"].ToString() + "-" + dt2.Rows[i]["currency"].ToString();
				LBL_KetKredit.Controls.Add(t);
				LBL_KetKredit.Controls.Add(new LiteralControl("<BR>"));

				//----------------------------------------------------------
				Label l = new Label();
				if (dt2.Rows[i]["jnsproduct"].ToString()=="KI")
					jns_product = Convert.ToDouble(tool.ConvertNum(dt2.Rows[i]["baki_debet"].ToString()));
				else
					jns_product = limit;


				if (dt2.Rows[i]["apptype"].ToString()=="03")
					if (dt2.Rows[i]["cp_limitchg"].ToString()=="+")
						limit_akhir = (jns_product + Convert.ToDouble(tool.ConvertNum(dt2.Rows[i]["ad_limit"].ToString())));
					else
						limit_akhir = (jns_product - Convert.ToDouble(tool.ConvertNum(dt2.Rows[i]["ad_limit"].ToString())));
				else
					limit_akhir = jns_product;

				//l.Text = "-"+" "+ GlobalTools.MoneyFormat(dtb.Rows[j][0].ToString() );
				l.Text = "-"+" "+ GlobalTools.MoneyFormat(limit_akhir.ToString());
				PLHLD_LIMIT.Controls.Add(l);
				PLHLD_LIMIT.Controls.Add(new LiteralControl("<BR>"));
				*/

				conn.QueryString = "exec LGL_LEGAL_DISBURSEMENT '" + a+ "','" + dt1.Rows[i]["KET_CODE"].ToString() + "'";
				conn.ExecuteQuery();
				System.Data.DataTable dt2 = new System.Data.DataTable();
				dt2 = conn.GetDataTable().Copy();

				if (dt2.Rows.Count > 0) 
				{
					Label t = new Label();
					t.Text = "-"+" "+ dt2.Rows[0]["productdesc"].ToString() + "-" + dt2.Rows[0]["currency"].ToString();
					LBL_KetKredit.Controls.Add(t);
					LBL_KetKredit.Controls.Add(new LiteralControl("<BR>"));


					Label l = new Label();
					l.Text = "-"+" "+ GlobalTools.MoneyFormat(dt2.Rows[0]["limit_legal"].ToString());
					PLHLD_LIMIT.Controls.Add(l);
					PLHLD_LIMIT.Controls.Add(new LiteralControl("<BR>"));
				}
			}

			//--------------------------------------------------------------------------------------------------//
			conn.QueryString = "select	top 1 ap_signdate from application where ap_regno = '" + a + "'";
			conn.ExecuteQuery();

			LBL_APSIGNDATE.Text = tool.FormatDate(conn.GetFieldValue("ap_signdate").ToString());
			LBL_APREGNO.Text = a;

			conn.QueryString = "select NT_NAME from RFNOTARY where NTID in " +
				"(select top 1 ntid from NOTARYASSIGN where ap_regno = '" + a + "')";
			conn.ExecuteQuery();
			LBL_NAMANOTARIS.Text = conn.GetFieldValue("NT_NAME").ToString();
			//--------------------------------------------------------------------------------------------------//
		}

		private void viewdata()
		{
			string a = Request.QueryString["regno"];

			conn.QueryString = "select seq, des, sy_accdate, sy_ket,sy_islengkap from VW_SYARAT where DOCTYPEID = '5' and sy_status='1' and AP_REGNO = '"+ a + "'"; 
			conn.ExecuteQuery();
			for (int i = 0; i < conn.GetRowCount(); i++)
			{
				TBL_CONTENT.Rows.Add(new TableRow());
				TBL_CONTENT.Rows[i + 1].Cells.Add(new TableCell());
				TBL_CONTENT.Rows[i + 1].Cells[0].VerticalAlign = VerticalAlign.Top;
				TBL_CONTENT.Rows[i + 1].Cells[0].Text = "<br>" + ((int)(i + 1)).ToString();
				TBL_CONTENT.Rows[i + 1].Cells[0].HorizontalAlign = HorizontalAlign.Center;
				TBL_CONTENT.Rows[i + 1].Cells[0].CssClass= "ItemPrint";

				TBL_CONTENT.Rows[i + 1].Cells.Add(new TableCell());
				TBL_CONTENT.Rows[i + 1].Cells[1].VerticalAlign = VerticalAlign.Top;
				TBL_CONTENT.Rows[i + 1].Cells[1].Text = "<br>" + conn.GetFieldValue(i, "des").Trim();
				TBL_CONTENT.Rows[i + 1].Cells[1].CssClass= "ItemPrint";

				TBL_CONTENT.Rows[i + 1].Cells.Add(new TableCell());
				TBL_CONTENT.Rows[i + 1].Cells[2].VerticalAlign = VerticalAlign.Top;
				TBL_CONTENT.Rows[i + 1].Cells[2].HorizontalAlign = HorizontalAlign.Center;
				TBL_CONTENT.Rows[i + 1].Cells[2].Text = "<br>" + (conn.GetFieldValue(i,"sy_islengkap")=="1"?"Lengkap":"Tidak Lengkap") ;
				TBL_CONTENT.Rows[i + 1].Cells[2].CssClass= "ItemPrint";

				TBL_CONTENT.Rows[i + 1].Cells.Add(new TableCell());
				TBL_CONTENT.Rows[i + 1].Cells[3].VerticalAlign = VerticalAlign.Top;
				TBL_CONTENT.Rows[i + 1].Cells[3].HorizontalAlign = HorizontalAlign.Center;
				TBL_CONTENT.Rows[i + 1].Cells[3].Text = "<br>" + conn.GetFieldValue(i, "sy_ket").Trim();
				TBL_CONTENT.Rows[i + 1].Cells[3].CssClass= "ItemPrint";
			}
		}
	}
}
