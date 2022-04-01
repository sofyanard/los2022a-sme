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
	/// Summary description for RptDisbursementProd.
	/// </summary>
	public partial class RptDisbursementProd : System.Web.UI.Page
	{
		protected Connection Conn = new Connection();
		protected Tools tools = new Tools();
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			Conn = (Connection) Session["Connection"];
			//if (!Logic.AllowAccess(Session["GroupID"].ToString(), Request.QueryString["mc"], Conn))
			//Response.Redirect("/SME/Restricted.aspx");
			LBL_BU.Text = Request.QueryString["BU"];

			if (!IsPostBack)
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

				Label1.Text = Posisi_User().ToString();
				fillRegion();
				FillProgram();
				Fillindustry();
			}
		//	Load_Data("View");
		//	BTN_LIHAT.Attributes.Add("onclick","if(!cek_mandatory(document.Form1)){return false;};");
		}

		private void fillRegion()
		{
			DDL_REGION.Items.Clear();
			switch(Label1.Text)
			{
				case "1": case "2":
					Conn.QueryString = "select AreaID, AREANAME from rfarea where AreaID='" + Session["AreaID"].ToString() + "' ";
					break;
				case "3": 
					Conn.QueryString = "select AreaID, AREANAME from rfarea where arearegmanager='" + Session["UserID"].ToString() + "' ";
					break;
				default:
					Conn.QueryString = "select AreaID, AREANAME from rfarea";
					DDL_REGION.Items.Add(new ListItem("-- PILIH --",""));
					break;
			}
			Conn.ExecuteQuery();
			for (int i = 0; i < Conn.GetRowCount(); i++)
			{
				DDL_REGION.Items.Add(new ListItem(Conn.GetFieldValue(i,1),Conn.GetFieldValue(i,0)));
			}

		}

		private void FillProgram()
		{
			string BusinessUnit ="";
			try 
			{
				BusinessUnit = Request.QueryString["BU"];
			}
			catch{ BusinessUnit =""; }

			if (BusinessUnit.ToString().Trim() == "CB100")
				Conn.QueryString = "SELECT DISTINCT PROGRAMID, PROGRAMDESC FROM RFPROGRAM " + 
					" where businessunit = 'CB100' ORDER BY PROGRAMDESC";
			else 
				Conn.QueryString = "SELECT DISTINCT PROGRAMID, PROGRAMDESC FROM RFPROGRAM " + 
					" where businessunit <> 'CB100' ORDER BY PROGRAMDESC";

			Conn.ExecuteQuery();
			DDL_program.Items.Clear();
			DDL_program.Items.Add(new ListItem("-- PILIH --",""));
			for (int i = 0; i < Conn.GetRowCount(); i++)
			{
				String s0 = Conn.GetFieldValue(i,0),
					s1 = Conn.GetFieldValue(i,1);
				ListItem li = new ListItem(s1,s0);
				DDL_program.Items.Add(li);
			}
			FillProduct();
		}
 
		private void FillProduct()
		{
			Conn.QueryString = "select distinct rfproduct.productid, rfproduct.productdesc from rfproduct left join prog_prod "+
				"on rfproduct.productid= prog_prod.productid  where rfproduct.active='1' and prog_prod.programid= '" + DDL_program.SelectedValue.ToString() + "'";
			DDL_product.Items.Clear();
			DDL_product.Items.Add(new ListItem("-- PILIH --",""));
			if (DDL_program.SelectedValue!="")
			{
				Conn.ExecuteQuery();
				for (int i = 0; i < Conn.GetRowCount(); i++)
				{
					String s0 = Conn.GetFieldValue(i,0),
						s1 = Conn.GetFieldValue(i,1);
					ListItem li = new ListItem(s1,s0);
					DDL_product.Items.Add(li);
				}		
			}
		}

		private void Fillindustry()
		{
			Conn.QueryString = "SELECT BUSSTYPEID, BUSSTYPEDESC FROM RFBUSINESSTYPE WHERE ACTIVE = '1' ";
			Conn.ExecuteQuery();
			DDL_INDUSTRI.Items.Clear();
			DDL_INDUSTRI.Items.Add(new ListItem("-- PILIH --",""));
			for (int i = 0; i < Conn.GetRowCount(); i++)
			{
				String s0 = Conn.GetFieldValue(i,0),
					s1 = Conn.GetFieldValue(i,1);
				ListItem li = new ListItem(s1,s0);
				DDL_INDUSTRI.Items.Add(li);
			}
		}

		private int Posisi_User()
		{
			string area = "";
			int Posisi;
            if ((Session["BranchID"].ToString() == "000") || (Session["BranchID"].ToString() == "001"))
			{ 
				//Head Office
				Posisi = 0;
			}
			else
			{
				Conn.QueryString = "select * from RFAREA where AREAREGMANAGER ='" + Session["UserID"].ToString() + "' ";
				Conn.ExecuteQuery();
				if (Conn.GetRowCount() > 0) area = "yup";
				else area = "nop";				

				if (area=="yup")
				{
					//User adalah Manager Area
					Posisi=3;
				}
				else
				{
					//if (Session["GroupID"].ToString().StartsWith("01"))
					if (Session["CBC"].ToString().Equals(Session["BranchID"].ToString()))
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

		private void LoadSql(string action)
		{
			string sql_kondisi="",tanggal1="", tanggal1_k="", tanggal2="", tanggal2_k="", region, industri="", program="", product="";
			region      = DDL_REGION.SelectedValue;
			industri    = DDL_INDUSTRI.SelectedValue;
			program     = DDL_program.SelectedValue;
			product     = DDL_product.SelectedValue;
			tanggal1	= tools.ConvertDate(TXT_TGL1.Text,DDL_BLN1.SelectedValue,TXT_THN1.Text);
			tanggal2	= tools.ConvertDate(TXT_TGL2.Text,DDL_BLN2.SelectedValue,TXT_THN2.Text);
			tanggal1		= tanggal1.Replace("'","");
			tanggal2		= tanggal2.Replace("'","");

			if (!region.Equals(""))
			{
				sql_kondisi +=" and areaid='" + region + "' ";
			}
			if (!industri.Equals(""))
			{
				sql_kondisi +=" and industryID='" + industri + "' ";
			}
			if(!program.Equals(""))
			{
				sql_kondisi +=" and prog_code='" + program + "' ";
			}
			if (!product.Equals(""))
			{
				sql_kondisi +=" and productid='" + product + "' ";
			}
            /*
			if (!Session["bussunitid2"].Equals(""))    
			{
				sql_kondisi += "and (businessunit in (" + Session["bussunitid2"].ToString().Replace("''","'") + ")) ";
			}
            */
            if ((!Session["BussUnit"].Equals("")) && (Session["BussUnit"] != null))
            {
                sql_kondisi += "and (businessunit in ('" + Session["BussUnit"].ToString().Replace("''", "'") + "')) ";
            }
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
			/*
			if (!Information.IsDate(tanggal2))
			{
				tanggal2	= DateTime.Today.ToString();
				tanggal2_k = Tools.toISODate(DateTime.Today.Day.ToString(),DateTime.Today.Month.ToString() ,DateTime.Today.Year.ToString());
			}
			else
			*/
			{
				tanggal2_k = Tools.toISODate(DateTime.Parse(tanggal2.ToString()).Day.ToString(), DateTime.Parse(tanggal2.ToString()).Month.ToString(), DateTime.Parse(tanggal2.ToString()).Year.ToString());
			}
			sql_kondisi += " and convert(varchar, ap_Recvdate, 112) between '" + tanggal1_k + "' and '" + tanggal2_k + "' ";
			if (!action.Equals("PRINT"))			
				Load_ReportViewer(sql_kondisi, tanggal1,tanggal2,region, industri, program, product);
			else
				Response.Redirect("RptDisbursementProdPrint.aspx?sql_kondisi=" + sql_kondisi.Replace("'","''") + "&Start_Date=" + tanggal1 + "&End_Date=" + tanggal2 + "&region=" + region + "&industri=" + industri + "&program=" + program + "&product=" + product);
	
		}

		private void Load_ReportViewer(string sql_kondisi, string Start_Date, string End_Date, string region, string industri, string program, string product)
		{
			/*
			string tanggal1	= tools.ConvertDate(Start_Date);
			string tanggal2	= tools.ConvertDate(End_Date);
			*/
			string tanggal1	= Start_Date;
			string tanggal2	= End_Date;
			tanggal1		= tanggal1.Replace("'","");
			tanggal2		= tanggal2.Replace("'","");

            //ReportViewer1.ReportPath = "/SMEReports/RptDisburseProd&sql_kondisi=" + Server.HtmlEncode(sql_kondisi) + "&Start_Date=" + Start_Date + "&End_Date=" + End_Date + "&region=" + region + "&INDUSTRI=" + industri + "&program=" + program + "&PRODUCT=" + product + "&rs:Command=Render&rc:Toolbar=True";				

            IReportServerCredentials irsc = new CustomReportCredentials(WebConfigurationManager.AppSettings["ReportUser"].ToString(), WebConfigurationManager.AppSettings["ReportPassword"].ToString(), WebConfigurationManager.AppSettings["DomainName"].ToString());

            ReportViewer1.ProcessingMode = Microsoft.Reporting.WebForms.ProcessingMode.Remote;
            ReportViewer1.ServerReport.ReportServerCredentials = irsc;
            ReportViewer1.ServerReport.ReportServerUrl = new Uri(WebConfigurationManager.AppSettings["ServerUrl"].ToString());
            ReportViewer1.ServerReport.ReportPath = "/SMEReports/RptDisburseProd";

            List<ReportParameter> paramList = new List<ReportParameter>();

            //paramList.Add(new ReportParameter("sql_kondisi", Server.HtmlEncode(sql_kondisi), false));
            paramList.Add(new ReportParameter("sql_kondisi", sql_kondisi, false));
            paramList.Add(new ReportParameter("region", region, false));
            paramList.Add(new ReportParameter("Start_Date", Start_Date, false));
            paramList.Add(new ReportParameter("End_Date", End_Date, false));
            paramList.Add(new ReportParameter("INDUSTRI", industri, false));
            paramList.Add(new ReportParameter("program", program, false));
            paramList.Add(new ReportParameter("PRODUCT", product, false));

            ReportViewer1.ServerReport.SetParameters(paramList);
            ReportViewer1.ServerReport.Refresh();
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

		protected void DDL_program_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			FillProduct();
		}

		protected void BTN_LIHAT_Click(object sender, System.EventArgs e)
		{
			LoadSql("");
			
		}

		protected void btn_Back_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			Response.Redirect("MainReportOR.aspx?mc=" + Request.QueryString["mc"] + "&BU=" + LBL_BU.Text);
		}

		protected void Btn_Print_Click(object sender, System.EventArgs e)
		{
		   LoadSql("PRINT");
		}
	}
}
