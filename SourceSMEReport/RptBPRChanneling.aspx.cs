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
using System.Web.Configuration;
using Microsoft.Reporting.WebForms;
using System.Collections.Generic;
using System.Net;
using SME.SourceSMEReport;

namespace SME.SourceSMEReport
{
	/// <summary>
	/// Summary description for RptBPRChanneling.
	/// </summary>
	public partial class RptBPRChanneling : System.Web.UI.Page
	{
		protected Connection Conn = new Connection();
		protected Tools tools = new  Tools();
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			Conn = (Connection) Session["Connection"];

			if (!IsPostBack)
			{
				Filldate();
				fillBPRName();
				fillFacility();
				fillBatchNo();
				Label1.Text = Posisi_User().ToString();
			}
		
		}

		private void Filldate()
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

		private int Posisi_User()
		{
			string area="";
			int Posisi;
			if (Session["BranchID"].ToString()=="99999")
			{ 
				//Head Office
				Posisi = 0;
			}
			else
			{
				Conn.QueryString = "select * from rfarea where arearegmanager='" + Session["UserID"].ToString() + "' ";
				Conn.ExecuteQuery();
				if (Conn.GetRowCount()>0)
					area="yup";
				else
					area="nop";

				if (area=="yup")
				{
					Posisi=3;
				}
				else
				{
					if (Session["BranchID"].ToString()==Session["CBC"].ToString()) //(Session["GroupID"].ToString().StartsWith("01"))
					{
						//CBC
						Posisi=2;
					}
					else
					{
						//Branch
						Posisi = 1;
					}
				}
			}
			return Posisi;
		}

		private void fillBPRName()
		{
			//GlobalTools.fillRefList(DDL_COMPNAME, "select CU_REF, CU_NAME from VW_CHANNELCOMP ",Conn);//ahmad
			//////////////////////////////////////////////////////////////////
			/// ahmad
			/// used new stored procedure to get company
			/// 
			
			GlobalTools.fillRefList(DDL_COMPNAME, "EXEC CHANN_GETCOMPANY '" + Session["UserID"].ToString() + "'", Conn);
			
		}

		private void fillFacility()
		{
			DDL_FACILITY.Items.Clear();
			DDL_FACILITY.Items.Add(new ListItem("-- SELECT --",""));
			
			if (!DDL_COMPNAME.Equals(""))
				Conn.QueryString="select rfproduct.productid,productdesc from bookedprod join rfproduct on  rfproduct.productid=bookedprod.productid where cu_ref ='"+DDL_COMPNAME.SelectedValue+"' ";
			else
				Conn.QueryString="select rfproduct.productid,productdesc from bookedprod join rfproduct on  rfproduct.productid=bookedprod.productid ";

			Conn.ExecuteQuery();
			
			for (int i=0;i<Conn.GetRowCount();i++)
			{
				DDL_FACILITY.Items.Add(new ListItem(Conn.GetFieldValue(i,1),Conn.GetFieldValue(i,0)));
			}
		}

		private void fillBatchNo()
		{
			string tgl1="", tgl2="", tgl1_k="", tgl2_k="", whr="";

			tgl1 = tools.ConvertDate(TXT_TGL1.Text,DDL_BLN1.SelectedValue,TXT_THN1.Text);
			tgl2 = tools.ConvertDate(TXT_TGL2.Text,DDL_BLN2.SelectedValue,TXT_THN2.Text);
			/*
			if (!Information.IsDate(tgl1)||!Information.IsDate(tgl2)){}
			else 
			*/
			{
				tgl1_k = Tools.toISODate(TXT_TGL1.Text,DDL_BLN1.SelectedValue,TXT_THN1.Text);
				tgl2_k = Tools.toISODate(TXT_TGL2.Text,DDL_BLN2.SelectedValue,TXT_THN2.Text);
				whr = " CONVERT(DATETIME,(SUBSTRING(AP_REGNO,5,4)+SUBSTRING(AP_REGNO,3,2)+LEFT(AP_REGNO,2))) Between '" + tgl1_k + "' and '" + tgl2_k + "'" ;
			}

			DDL_BATCHNO.Items.Clear();
			DDL_BATCHNO.Items.Add(new ListItem("-- SELECT --",""));

			if (!DDL_COMPNAME.Equals(""))
				Conn.QueryString="select Distinct Batchno,Batchno from Channeling where ch_bpr_curef ='"+DDL_COMPNAME.SelectedValue+"' and "+ whr.Trim() ;
			else
				Conn.QueryString="select Distinct Batchno,Batchno from Channeling where "+whr.Trim() ;

			Conn.ExecuteQuery();
			
			for (int i=0;i<Conn.GetRowCount();i++)
			{
				DDL_BATCHNO.Items.Add(new ListItem(Conn.GetFieldValue(i,1),Conn.GetFieldValue(i,0)));
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

		protected void BTN_LIHAT_Click(object sender, System.EventArgs e)
		{
			LoadSql("");
		}

		private void LoadSql(string action)
		{
			string kriterianya = "", tanggal1="", tanggal2="", tanggal1_k="", tanggal2_k="";
			string BPRName	= DDL_COMPNAME.SelectedValue;
			string Facility = DDL_FACILITY.SelectedValue;
			string _BatchNo = DDL_BATCHNO.SelectedValue;
			
			if (!BPRName.Equals(""))
			{
				kriterianya+="and (CH.CH_BPR_CUREF='" + BPRName + "' )";
				BPRName=DDL_COMPNAME.SelectedItem.ToString();
			}
			else
				BPRName="ALL";

			if (!Facility.Equals(""))
			{
				kriterianya+="and (CH.ch_productid='" + Facility + "' )";
				Facility=DDL_FACILITY.SelectedItem.ToString();
			}
			else
				Facility="ALL";

			if (!_BatchNo.Equals(""))
			{
				kriterianya+="and (CH.batchno='" + _BatchNo + "' )";
				_BatchNo=DDL_BATCHNO.SelectedItem.ToString();
			}
			else
				_BatchNo="ALL";

			tanggal1 = tools.ConvertDate(TXT_TGL1.Text,DDL_BLN1.SelectedValue,TXT_THN1.Text);
			tanggal2 = tools.ConvertDate(TXT_TGL2.Text,DDL_BLN2.SelectedValue,TXT_THN2.Text);
			/*
			if (!Information.IsDate(tanggal1)||!Information.IsDate(tanggal2)){}
			else 
			*/
			{
				tanggal1_k = Tools.toISODate(TXT_TGL1.Text,DDL_BLN1.SelectedValue,TXT_THN1.Text);
				tanggal2_k = Tools.toISODate(TXT_TGL2.Text,DDL_BLN2.SelectedValue,TXT_THN2.Text);
				//kriterianya += " and convert(varchar, CH_TGPK, 112) between " + tanggal1_k + " and " + tanggal2_k + "" ;
				kriterianya += " and CONVERT(DATETIME,(SUBSTRING(CH.AP_REGNO,5,4)+SUBSTRING(CH.AP_REGNO,3,2)+LEFT(CH.AP_REGNO,2))) Between '" + tanggal1_k + "' and '" + tanggal2_k + "'" ;
			}
			
			tanggal1=TXT_TGL1.Text+"  "+ DDL_BLN1.SelectedItem+"  "+TXT_THN1.Text;
			tanggal2=TXT_TGL2.Text+"  "+ DDL_BLN2.SelectedItem+"  "+TXT_THN2.Text;
            tanggal1=tanggal1+" To " + tanggal2;
			//Response.Write("<BR> Where 1=1 "+kriterianya); 
			if (!action.Equals("PRINT"))
			{
				//ReportViewer1.ReportPath = "/SMEReports/RptBprChanneling&sql_kondisi=" + kriterianya.Replace("+","]") + "&date=" + tanggal1 + "&BPR=" + BPRName + "&Facility=" + Facility + "";
                
                IReportServerCredentials irsc = new CustomReportCredentials(WebConfigurationManager.AppSettings["ReportUser"].ToString(), WebConfigurationManager.AppSettings["ReportPassword"].ToString(), WebConfigurationManager.AppSettings["DomainName"].ToString());

                ReportViewer1.ProcessingMode = Microsoft.Reporting.WebForms.ProcessingMode.Remote;
                ReportViewer1.ServerReport.ReportServerCredentials = irsc;
                ReportViewer1.ServerReport.ReportServerUrl = new Uri(WebConfigurationManager.AppSettings["ServerUrl"].ToString());
                ReportViewer1.ServerReport.ReportPath = "/SMEReports/RptBprChanneling";

                List<ReportParameter> paramList = new List<ReportParameter>();

                paramList.Add(new ReportParameter("sql_kondisi", kriterianya.Replace("+", "]"), false));
                paramList.Add(new ReportParameter("BPR", BPRName, false));
                paramList.Add(new ReportParameter("Facility", Facility, false));
                paramList.Add(new ReportParameter("date", tanggal1, false));

                ReportViewer1.ServerReport.SetParameters(paramList);
                ReportViewer1.ServerReport.Refresh();
			}
			else
				Response.Redirect("RptBPRChannelingPrint.aspx?sql_kondisi=" + kriterianya.Replace("'","''").Replace("+","]") + "&BPRName=" + BPRName +"&Facility=" + Facility + "&date=" + tanggal1 + " ") ;
			}

		protected void Btn_Print_Click(object sender, System.EventArgs e)
		{
			LoadSql("PRINT");
		}

		protected void btn_back_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			Response.Redirect("MainReportOR.aspx?mc=" + Request.QueryString["mc"] + "&BU=" + LBL_BU.Text);
		}

		protected void DDL_COMPNAME_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			fillFacility();
		}

		protected void DDL_FACILITY_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			fillBatchNo();
		}

		protected void TXT_TGL1_TextChanged(object sender, System.EventArgs e)
		{
			fillBatchNo();
		}

		protected void DDL_BLN1_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			fillBatchNo();
		}

		protected void TXT_THN1_TextChanged(object sender, System.EventArgs e)
		{
			fillBatchNo();
		}

		protected void TXT_TGL2_TextChanged(object sender, System.EventArgs e)
		{
			fillBatchNo();
		}

		protected void DDL_BLN2_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			fillBatchNo();
		}

		protected void TXT_THN2_TextChanged(object sender, System.EventArgs e)
		{
			fillBatchNo();
		}
	}
}
