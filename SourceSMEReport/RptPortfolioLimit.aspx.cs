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

namespace SME.SourceSMEReport
{
	/// <summary>
	/// Summary description for RptPortfolioLimit.
	/// </summary>
	public partial class RptPortfolioLimit : System.Web.UI.Page
	{

		protected Connection Conn = new Connection();
		protected Tools tools = new Tools();
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			//string vRMCODE ="";
			Conn = (Connection) Session["Connection"];

			//if (!Logic.AllowAccess(Session["GroupID"].ToString(), Request.QueryString["mc"], Conn))
			//Response.Redirect("/SME/Restricted.aspx");

			//LBL_BU.Text = Request.QueryString["BU"];
			//Conn.QueryString = "select rmcode from app_parameter ";
			//Conn.ExecuteQuery();
			//if (Conn.GetRowCount()>0)
			//{
			//	vRMCODE = Conn.GetFieldValue(0,0);
			//}

			if (!IsPostBack)
			{
				DDL_BLN1.Items.Add(new ListItem("-- PILIH --",""));
				//DDL_BLN2.Items.Add(new ListItem("-- PILIH --",""));
				for (int i = 1; i <= 12; i++)
				{
					DDL_BLN1.Items.Add(new ListItem(DateAndTime.MonthName(i, false), i.ToString()));
					//DDL_BLN2.Items.Add(new ListItem(DateAndTime.MonthName(i, false), i.ToString()));
				}

				TXT_TGL1.Text=DateAndTime.Today.Day.ToString();
				DDL_BLN1.SelectedValue=DateAndTime.Today.Month.ToString();
				TXT_THN1.Text=DateAndTime.Today.Year.ToString();


				//TXT_TGL2.Text=DateAndTime.Today.Day.ToString();
				//DDL_BLN2.SelectedValue=DateAndTime.Today.Month.ToString();
				//TXT_THN2.Text=DateAndTime.Today.Year.ToString();



				DDL_INDUSTRYNAME.Items.Add(new ListItem("- PILIH -", ""));
				
				Conn.QueryString = "select PD_INDUSTRY_NAMECD, PD_INDUSTRY_NAME from PD_RF_INDUSTRY_CLASS where active='1' order by convert(int,PD_INDUSTRY_NAMECD)";
				Conn.ExecuteQuery();
				for (int i = 0; i < Conn.GetRowCount(); i++)
					DDL_INDUSTRYNAME.Items.Add(new ListItem(Conn.GetFieldValue(i,0) + " - " + Conn.GetFieldValue(i,1), Conn.GetFieldValue(i,0)));



				//LBL_RM.Text = "'0002','0004'";
				//Conn.QueryString = "select rmcode from app_parameter ";
				//Conn.ExecuteQuery();
				//if (Conn.GetRowCount()>0)
				//{
				//	LBL_RM.Text = Conn.GetFieldValue(0,0);
				//}

				//Label1.Text = Posisi_User().ToString();
				//fillRegion();
				//FillProgram();
				
				fillKSEBI4();

				/* // Nama-nama RM berdasarkan region dan branch yg terpilih
				 * 
				Conn.QueryString = "select userid, su_fullname from scuser where groupID in (" + vRMCODE + ")";
				Conn.ExecuteQuery();
				for (int i = 0; i < Conn.GetRowCount(); i++)
				{
					DDL_RM.Items.Add(new ListItem(Conn.GetFieldValue(i,1),Conn.GetFieldValue(i,0)));
				}*/
			}

		}

		////////////////////////////////////////////////////////////////////////////////////////////////////
		#region My Method 

		private void fillKSEBI4()
		{
			DDL_KSEBI4.Items.Clear();
			Conn.QueryString = "select BI_SEQ, BI_SEQ + ' - ' + BI_DESC as KSEBI4 from PD_RF_INDUSTRYCLASS_LINK "+ 
				"where active= '1' and PD_INDUSTRY_NAMECD ='" + DDL_INDUSTRYNAME.SelectedValue + "'";		
			DDL_KSEBI4.Items.Add(new ListItem("-- PILIH --",""));
			if(DDL_INDUSTRYNAME.SelectedValue != "")
			{
				Conn.ExecuteQuery();
				for (int i = 0; i < Conn.GetRowCount(); i++)
				{
					DDL_KSEBI4.Items.Add(new ListItem(Conn.GetFieldValue(i,1),Conn.GetFieldValue(i,0)));
				}
			}
		}

		#endregion
		////////////////////////////////////////////////////////////////////////////////////////////////////

		private void LoadReport_Load(string action,string tgl1, string industry,string ksebi4)
		{	
			string ReportAddr="", kriterianya="", tanggal1_k="";
			//string tanggal1	= tools.ConvertDate(tgl1);
			string tanggal1	= tgl1;
			 
			tanggal1		= tanggal1.Replace("'","");

			Conn.QueryString = "select reportaddr from app_parameter";
			Conn.ExecuteQuery();
			if (Conn.GetRowCount()>0)
				ReportAddr = Conn.GetFieldValue(0,0);
			else
				ReportAddr  = "10.123.12.50";
			
			ReportViewer1.ServerUrl = "http://" + ReportAddr + "/ReportServer";
			/*
			if (!Information.IsDate(tanggal1))
			{
				tanggal1	= DateTime.Today.ToString();
				tanggal1_k = Tools.toISODate(DateTime.Today.Day.ToString(),DateTime.Today.Month.ToString() ,DateTime.Today.Year.ToString());
			}
			else
			*/
			{
				tanggal1_k = Tools.toISODate(DateTime.Parse(tanggal1.ToString()).Day.ToString(),DateTime.Parse(tanggal1.ToString()).Month.ToString(), DateTime.Parse(tanggal1.ToString()).Year.ToString());
			}

			kriterianya += "AND (convert(nvarchar, TgApplikasi, 112) = " + tanggal1_k + " ) ";

			if (!industry.Equals(""))
			{
				kriterianya += "AND (PD_INDUSTRY_NAMECD = '" + industry + "') ";
			}
			if (!ksebi4.Equals(""))     
			{
				kriterianya += " AND (BI_SEQ = '" + ksebi4 + "') ";
			}

//			ReportViewer1.ReportPath = "/SMEReports/RptOverallSLA&sql_kondisi=" + kriterianya + "&Start_Date="+ tanggal1 + "&End_Date=" + tanggal2 + "&area=" + area + "&cbc=" + cbc + "&branch=" + branch + "&rm=" + rm + "&teamleader=" + teamleader + "&program=" + program + "&rs:Command=Render&rc:Toolbar=True";

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

		protected void BTN_SAVE_Click(object sender, System.EventArgs e)
		{
			LoadSql("");
		}

		private void LoadSql(string action)
		{
			string industry     = DDL_INDUSTRYNAME.SelectedValue;
			string ksebi4		= DDL_KSEBI4.SelectedValue;

			string tanggal1 = "";
			
			if (Tools.isDateValid(this,TXT_TGL1.Text,DDL_BLN1.SelectedValue,TXT_THN1.Text))
			{
				tanggal1 = tools.ConvertDate(TXT_TGL1.Text,DDL_BLN1.SelectedValue,TXT_THN1.Text);

				/*
				if (!Information.IsDate(tanggal1))
				{
					Tools.popMessage(this,"Invalid date");
					if (!Information.IsDate(tanggal1))
						Tools.SetFocus(this,TXT_TGL1);
					else
						Tools.SetFocus(this,TXT_TGL1);
				}
				else
				*/
					LoadReport_Load(action,tanggal1,industry,ksebi4);
			}
			else
			{
				Response.Write("<script language='javascript'>alert('Invalid Date !')</script>");
			}
		}

		protected void DDL_INDUSTRYNAME_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			fillKSEBI4();
		}


		protected void btn_back_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
				Response.Redirect("MainReportSLA.aspx?mc=" + Request.QueryString["mc"]);
		}


	}
}
