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

namespace SME.SourceSMEReport.ILPDashBoard
{
	/// <summary>
	/// Summary description for RptTATEndToEndProcess.
	/// </summary>
	public partial class RptTATEndToEndProcess : System.Web.UI.Page
	{
		protected Connection Conn = new Connection();	
		protected Tools tools = new Tools();
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			Conn = (Connection) Session["Connection"];

			if (!IsPostBack)
			{
				fillDate();
				fillBusinessUnit();
				fillArea();
				//fillBranch();
				DDL_BRANCH.Items.Add(new ListItem("-- PILIH --",""));
				fillProcessType();
				fillApplicationType();

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

		private void fillProcessType()
		{
			DDL_PROTYPE.Items.Clear();
			DDL_PROTYPE.Items.Add(new ListItem("-- PILIH --",""));
			Conn.QueryString = "select distinct flow_name, flow_name from rf_tat order by flow_name ";
			Conn.ExecuteQuery();
			for (int i = 0; i < Conn.GetRowCount(); i++)
			{
				DDL_PROTYPE.Items.Add(new ListItem(Conn.GetFieldValue(i,1),Conn.GetFieldValue(i,0)));
			}
		}

		private void fillApplicationType()
		{
			DDL_APPTYPE.Items.Clear();
			DDL_APPTYPE.Items.Add(new ListItem("-- PILIH --",""));
			Conn.QueryString = "select apptypeid, apptypedesc from rfapplicationtype order by apptypeid";
			Conn.ExecuteQuery();
			for (int i = 0; i < Conn.GetRowCount(); i++)
			{
				DDL_APPTYPE.Items.Add(new ListItem(Conn.GetFieldValue(i,1),Conn.GetFieldValue(i,0)));
			}
		}

		private void fillBusinessUnit()
		{
			DDL_BUSINESSUNIT.Items.Clear();
			DDL_BUSINESSUNIT.Items.Add(new ListItem("-- PILIH --",""));
			Conn.QueryString = "select bussunitid, bussunitdesc from rfbusinessunit order by bussunitid ";
			Conn.ExecuteQuery();
			for (int i = 0; i < Conn.GetRowCount(); i++)
			{
				DDL_BUSINESSUNIT.Items.Add(new ListItem(Conn.GetFieldValue(i,1),Conn.GetFieldValue(i,0)));
			}
		}

		private void fillArea () 
		{
			DDL_AREA.Items.Clear();
			DDL_AREA.Items.Add(new ListItem("-- PILIH --",""));
			Conn.QueryString = "select AREAID, AREANAME from rfarea where active ='1'";
			Conn.ExecuteQuery();
			for (int i = 0; i < Conn.GetRowCount(); i++)
			{
				DDL_AREA.Items.Add(new ListItem(Conn.GetFieldValue(i,1),Conn.GetFieldValue(i,0)));
			}	
		}

		private void fillBranch() 
		{
			DDL_BRANCH.Items.Clear();
			DDL_BRANCH.Items.Add(new ListItem("-- PILIH --",""));

			Conn.QueryString = "select branch_code, branch_name from rfbranch where active ='1' and areaid='" + DDL_AREA.SelectedValue + "' order by branch_name";
			Conn.ExecuteQuery();

			for (int i = 0; i < Conn.GetRowCount(); i++)
			{
				DDL_BRANCH.Items.Add(new ListItem(Conn.GetFieldValue(i,1),Conn.GetFieldValue(i,0)));
			}			
		}

		private void fillDate()
		{
			DDL_BLN1.Items.Add(new ListItem("-- PILIH --",""));
			DDL_BLN2.Items.Add(new ListItem("-- PILIH --",""));
			for (int i = 1; i <= 12; i++)
			{
				DDL_BLN1.Items.Add(new ListItem(DateAndTime.MonthName(i, false), i.ToString()));
				DDL_BLN2.Items.Add(new ListItem(DateAndTime.MonthName(i, false), i.ToString()));
			}

				
			TXT_TGL1.Text=DateAndTime.Today.Day.ToString();
			DDL_BLN1.SelectedValue=DateAndTime.Today.Month.ToString();
			TXT_THN1.Text=DateAndTime.Today.Year.ToString();
			TXT_TGL2.Text=DateAndTime.Today.Day.ToString();
			DDL_BLN2.SelectedValue=DateAndTime.Today.Month.ToString();
			TXT_THN2.Text=DateAndTime.Today.Year.ToString();
			
		}

		protected void btn_back_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			Response.Redirect("ILPDashboard.aspx?mc=" + Request.QueryString["mc"]);
		}

		protected void BTN_LIHAT_Click(object sender, System.EventArgs e)
		{
			CreateQuery();
			//LoadSql("");
		}

		private void CreateQuery()
		{
			//string query = "select * from tat_test ";
			string query1 = "";
			string query2 = "";
			string query3 = "left join rf_tat_commitment_model on ";
			string query4 = " (select flow_name, segment, sum(sla_day) total_hari from rf_tat group by flow_name, segment) A ";
			//string query5 = "";
			//string query6 = " left join VW_TOTAL_LIBUR B on tat_test.ap_regno=B.ap_regno and tat_test.trackcode=B.trackcode and tat_test.th_seq=B.th_seq and tat_test.apptype=B.apptype and tat_test.prod_seq=B.prod_seq and tat_test.productid=B.productid ";
			string select = "select distinct tat_test.*, rf_tat_commitment_model.flow_code, A.total_hari ";
			string from = " from tat_test ";
			DataTable dt1;
			string reffieldid;
			string cbstable;
			string cbsfield;
			string cbslink;

			Conn.QueryString = "select reffieldid, cbstable, cbsfield, cbslink from rf_tat_commit";
			Conn.ExecuteQuery();

			dt1 = Conn.GetDataTable().Copy();

			if(dt1.Rows.Count > 0)
			{
				for(int i = 0; i < dt1.Rows.Count; i++)
				{
					reffieldid = dt1.Rows[i][0].ToString().Trim();
					cbstable = dt1.Rows[i][1].ToString().Trim();
					cbsfield = dt1.Rows[i][2].ToString().Trim();
					cbslink = dt1.Rows[i][3].ToString().Trim();

					select = select + ", " + cbstable + "." + cbsfield;

					query1 = query1 + "left join " + cbstable + " on " + cbslink + " ";
					query2 = query2 + cbstable + "." + cbsfield + " = rf_tat_commitment_model." + reffieldid + " and ";
				}

				select = select + from + query1 + query3 + query2 + "1=1 left join" + query4 + " on rf_tat_commitment_model.flow_code =A.flow_name";// + query6;

				LoadSql(select);
				
				/*----------------------------------------------------------------------
				Conn.QueryString = "select distinct flow_name from rf_tat";
				Conn.ExecuteQuery();

				for (int i = 0; i < Conn.GetRowCount(); i++)
				{
					query5 = query5 + select + " where flow_name='" + Conn.GetFieldValue(i,0) + "' and trackcode in (select distinct b.track_cd from rf_tat a left join rf_stage_track b on a.sla_code=b.stage_cd left join rf_stage c on b.stage_cd=c.stage_cd where a.flow_name='" + Conn.GetFieldValue(i,0) + "')";

					if (i != Conn.GetRowCount()-1)
					{
						query5 = query5 + " union ";
					}
				}

				--------------------------------------------------------------------------*/

				//query = query + "1=1 left join rf_tat on rf_tat_commitment_model.flow_code =rf_tat.code";
			}

			/*Conn.QueryString = "EXEC DASHBOARD_TOTAL_LIBUR_COUNT";
			Conn.ExecuteQuery();

			dt1 = Conn.GetDataTable().Copy();
 
			if(dt1.Rows.Count > 0)
			{
				for (int i = 0; i < dt1.Rows.Count; i++)
				{
					string ap_regno = dt1.Rows[i][0].ToString().Trim();
					string trackcode = dt1.Rows[i][1].ToString().Trim();
					string th_seq = dt1.Rows[i][2].ToString().Trim();
					string apptype = dt1.Rows[i][3].ToString().Trim();
					string prod_seq = dt1.Rows[i][4].ToString().Trim();
					string productid = dt1.Rows[i][5].ToString().Trim();
					int tgl_awal = int.Parse(dt1.Rows[i][10].ToString().Trim());
					int bln_awal = int.Parse(dt1.Rows[i][11].ToString().Trim());
					int thn_awal = int.Parse(dt1.Rows[i][12].ToString().Trim());
					int tgl_akhir = int.Parse(dt1.Rows[i][13].ToString().Trim());
					int bln_akhir = int.Parse(dt1.Rows[i][14].ToString().Trim());
					int thn_akhir = int.Parse(dt1.Rows[i][15].ToString().Trim());
					int jumlah=0;
					string jumlah2="";

					if(bln_akhir-bln_awal==0 && thn_awal==thn_akhir)
					{
						Conn.QueryString = "select tahun, bulan, count(tanggal) as total from rf_libur2 where tanggal between '" + tgl_awal + "' and '" + tgl_akhir + "' and tahun='" + thn_awal + "' and bulan='" + bln_awal + "' group by tahun, bulan";
						Conn.ExecuteQuery();

						//jumlah2 = Conn.GetFieldValue("total");
						if(Conn.GetFieldValue("total")=="")
							jumlah2 = "0";

						Conn.QueryString = "EXEC DASHBOARD_TOTAL_LIBUR_UPDATE '" + ap_regno + "', '" +
							trackcode + "', '" + th_seq + "', '" + apptype + "', '" + prod_seq + "', '" +
							productid + "', '" + jumlah2 + "'";
						Conn.ExecuteQuery();
					}
					else if(bln_akhir-bln_awal==1 && thn_awal==thn_akhir)
					{
						Conn.QueryString = "select tahun, bulan, count(tanggal) as total from rf_libur2 where tanggal between '" + tgl_awal + "' and '31' and tahun='" + thn_awal + "' and bulan='" + bln_awal + "' group by tahun, bulan";
						Conn.ExecuteQuery();

						if(Conn.GetFieldValue("total")=="")
							jumlah2 = "0";

						jumlah = jumlah + int.Parse(jumlah2);

						Conn.QueryString = "select tahun, bulan, count(tanggal) as total from rf_libur2 where tanggal between '1' and '" + tgl_akhir + "' and tahun='" + thn_awal + "' and bulan='" + bln_akhir + "' group by tahun, bulan";
						Conn.ExecuteQuery();

						if(Conn.GetFieldValue("total")=="")
							jumlah2 = "0";

						jumlah = jumlah + int.Parse(jumlah2);

						Conn.QueryString = "EXEC DASHBOARD_TOTAL_LIBUR_UPDATE '" + ap_regno + "', '" +
							trackcode + "', '" + th_seq + "', '" + apptype + "', '" + prod_seq + "', '" +
							productid + "', '" + jumlah.ToString() + "'";
						Conn.ExecuteQuery();

						jumlah = 0;
					}
					else if(bln_akhir-bln_awal > 1 && thn_awal==thn_akhir)
					{
						for(int j=bln_awal; j<=bln_akhir; j++)
						{
							if(j==bln_awal)
							{
								Conn.QueryString = "select tahun, bulan, count(tanggal) as total from rf_libur2 where tanggal between '" + tgl_awal + "' and '31' and tahun='" + thn_awal + "' and bulan='" + bln_awal + "' group by tahun, bulan";
								Conn.ExecuteQuery();
							}
							else if(j==bln_akhir)
							{
								Conn.QueryString = "select tahun, bulan, count(tanggal) as total from rf_libur2 where tanggal between '1' and '" + tgl_akhir + "' and tahun='" + thn_awal + "' and bulan='" + bln_akhir + "' group by tahun, bulan";
								Conn.ExecuteQuery();
							}
							else
							{
								Conn.QueryString =  "select tahun, bulan, count(tanggal) as total from rf_libur2 where tahun='" + j + "' and bulan='" + bln_akhir + "' group by tahun, bulan";
								Conn.ExecuteQuery();
							}

							if(Conn.GetFieldValue("total")=="")
								jumlah2 = "0";

							jumlah = jumlah + int.Parse(jumlah2);
						}

						Conn.QueryString = "EXEC DASHBOARD_TOTAL_LIBUR_UPDATE '" + ap_regno + "', '" +
							trackcode + "', '" + th_seq + "', '" + apptype + "', '" + prod_seq + "', '" +
							productid + "', '" + jumlah.ToString() + "'";
						Conn.ExecuteQuery();

						jumlah = 0;
					}
				}
			}*/

			/*if(dt1.Rows.Count > 0)
			{
				for(int i = 0; i < dt1.Rows.Count; i++)
				{
					reffieldid = dt1.Rows[i][0].ToString().Trim();
					cbstable = dt1.Rows[i][1].ToString().Trim();
					cbsfield = dt1.Rows[i][2].ToString().Trim();
					cbslink = dt1.Rows[i][3].ToString().Trim();

					query = query + "left join " + cbstable + " on " + cbslink + " ";
				}

				query = query + "left join rf_tat_commitment_model on ";

				for(int i = 0; i < dt1.Rows.Count; i++)
				{
					reffieldid = dt1.Rows[i][0].ToString().Trim();
					cbstable = dt1.Rows[i][1].ToString().Trim();
					cbsfield = dt1.Rows[i][2].ToString().Trim();
					cbslink = dt1.Rows[i][3].ToString().Trim();

					query = query + cbstable + "." + cbsfield + " = rf_tat_commitment_model." + reffieldid + " and ";
				}

				query = query + "1=1 left join rf_tat on rf_tat_commitment_model.flow_code =rf_tat.code";
			}*/
		}
		
		private void LoadSql(string query)
		{
			string businessunit		= DDL_BUSINESSUNIT.SelectedValue;
			string area				= DDL_AREA.SelectedValue;
			string branch			= DDL_BRANCH.SelectedValue;
			string apptype			= DDL_APPTYPE.SelectedValue;
			string protype			= DDL_PROTYPE.SelectedValue;

			string tanggal1 = "";
			string tanggal2 = "";
			
			if (Tools.isDateValid(this,TXT_TGL1.Text,DDL_BLN1.SelectedValue,TXT_THN1.Text)&&Tools.isDateValid(this, TXT_TGL2.Text,DDL_BLN2.SelectedValue,TXT_THN2.Text))
			{
				tanggal1 = tools.ConvertDate(TXT_TGL1.Text,DDL_BLN1.SelectedValue,TXT_THN1.Text);
				tanggal2 = tools.ConvertDate(TXT_TGL2.Text,DDL_BLN2.SelectedValue,TXT_THN2.Text);

				if (!Information.IsDate(tanggal1) || !Information.IsDate(tanggal2))
				{
					Tools.popMessage(this,"Invalid date");
					if (!Information.IsDate(tanggal1))
						Tools.SetFocus(this,TXT_TGL1);
					else
						Tools.SetFocus(this,TXT_TGL2);
				}
				else
					LoadReport_Load(query, tanggal1, tanggal2, businessunit, area, branch, apptype, protype);
			}
			else
			{
				Response.Write("<script language='javascript'>alert('Invalid Date !')</script>");
			}
			
		}

		private void LoadReport_Load(string query, string tanggal1, string tanggal2, string businessunit, string area, string branch, string apptype, string protype)
		{
			string ReportAddr="";
			Conn.QueryString = "select reportaddr from app_parameter";
			Conn.ExecuteQuery();
			if (Conn.GetRowCount()>0)
			{
				ReportAddr = Conn.GetFieldValue(0,0);
			}
			else
			{
				ReportAddr  = "10.123.12.50";
			}
			
			ReportViewer1.ServerUrl = "http://" + ReportAddr + "/ReportServer";

			ReportViewer1.ReportPath = "/SMEReports/RptDashboardTATEndToEndProcess&query="+ query + "&date1="+ tanggal1 + "&date2=" + tanggal2 + "&businessunit=" + businessunit +  "&area=" + area + "&branch=" + branch + "&apptype=" + apptype + "&protype=" + protype + "&rs:Command=Render";
		}


		protected void BTN_PRINT_Click(object sender, System.EventArgs e)
		{
		
		}

		protected void DDL_AREA_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			fillBranch();
		}
	}
}
