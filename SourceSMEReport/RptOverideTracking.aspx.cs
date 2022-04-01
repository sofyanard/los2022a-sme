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
using Microsoft.VisualBasic;
namespace SME.SourceSMEReport
{
	/// <summary>
	/// Summary description for RptOverideTracking.
	/// </summary>
	public partial class RptOverideTracking : System.Web.UI.Page
	{
		protected Connection Conn = new Connection();
		protected Tools tools = new Tools();
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			string kriterianya="";
			Conn = (Connection) Session["Connection"];
			if(!IsPostBack)
			{
				LBL_BU.Text = Request.QueryString["BU"];
				DDL_Month.Items.Add(new ListItem("-- PILIH --",""));
				for (int i = 1; i <= 12; i++)
				{
					DDL_Month.Items.Add(new ListItem(DateAndTime.MonthName(i, false), i.ToString()));
				}
				DDL_Month.SelectedValue=DateAndTime.Today.Month.ToString();
				TXT_Year.Text=DateAndTime.Today.Year.ToString();

				Label1.Text = Posisi_User().ToString();
				fillRegion();
				FillProduct();
			}

			string tanggal1_k = Tools.toISODate(DateTime.Today.Day.ToString(), DateTime.Today.Month.ToString(), DateTime.Today.Year.ToString());
			string tanggal2_k = Tools.toISODate(DateTime.Today.Day.ToString(), DateTime.Today.Month.ToString(), DateTime.Today.Year.ToString());
			string tanggal1 = DateTime.Today.ToString();
			string tanggal2 = DateTime.Today.ToString();

			kriterianya= " and (convert(varchar, Ap_signdate, 112) BETWEEN " + tanggal1_k + " AND " + tanggal2_k + ") ";

			if (!LBL_BU.Text.Equals(""))
			{kriterianya += " and businessunit='" + LBL_BU.Text + "'";}
			//Load_ReportViewer(kriterianya, tanggal1, tanggal2,"","");
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

		private void FillProduct()
		{
			Conn.QueryString = "select distinct rfproduct.productid, rfproduct.productdesc from rfproduct left join prog_prod "+
				"on rfproduct.productid= prog_prod.productid  where rfproduct.active='1'";
			DDL_Product.Items.Clear();
			DDL_Product.Items.Add(new ListItem("-- PILIH --",""));
			{
				Conn.ExecuteQuery();
				for (int i = 0; i < Conn.GetRowCount(); i++)
				{
					String s0 = Conn.GetFieldValue(i,0),
						s1 = Conn.GetFieldValue(i,1);
					ListItem li = new ListItem(s1,s0);
					DDL_Product.Items.Add(li);
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

		protected void BTN_LIHAT_Click(object sender, System.EventArgs e)
		{
			string kriterianya = "";
			string region   = DDL_REGION.SelectedValue;
			string product = DDL_Product.SelectedValue;
			string tmp_date="";
			
			string tanggal1 = tools.ConvertDate("1",DDL_Month.SelectedValue,TXT_Year.Text);
			tmp_date = DateAndTime.DateAdd(DateInterval.Month,1,DateTime.Parse(tanggal1.ToString())).ToString();
			tmp_date = DateAndTime.DateAdd(DateInterval.Day,-1,DateTime.Parse(tmp_date)).ToString();
            string tanggal2 = tmp_date;

			/*
			if (!Information.IsDate(tanggal1) || !Information.IsDate(tanggal2))
			{
				Tools.popMessage(this,"Invalid date");
				Response.Write("<Script language='javascript'>history.back();</Script>");
				if (!Information.IsDate(tanggal1))
					Tools.SetFocus(this,DDL_Month);
				else
					Tools.SetFocus(this,DDL_Month);
			}
			else 
			*/
			{
				string tanggal1_k = Tools.toISODate(DateTime.Parse(tanggal1.ToString()).Day.ToString(), DateTime.Parse(tanggal1.ToString()).Month.ToString(), DateTime.Parse(tanggal1.ToString()).Year.ToString()); //Tools.toISODate("1",DDL_Month,TXT_Year);
				string tanggal2_k = Tools.toISODate(DateTime.Parse(tanggal2.ToString()).Day.ToString(), DateTime.Parse(tanggal2.ToString()).Month.ToString(), DateTime.Parse(tanggal2.ToString()).Year.ToString()); //Tools.toISODate(TXT_Day2,DDL_Month,TXT_Year);
				kriterianya= " and (convert(varchar, Ap_signdate, 112) BETWEEN " + tanggal1_k + " AND " + tanggal2_k + ") ";
				if (!Session["bussunitid"].Equals(""))    
				{
					kriterianya += "and (businessunit in (" + Session["bussunitid"].ToString() + ")) ";
				}
/*
				if (Session["sg_grpunit"].ToString()=="CO")
				{
					kriterianya += "and (businessunit in ('CB100')) ";
				}
*/
				if (!region.Equals(""))
				{
					kriterianya += "and (app.areaid='" + region + "' )";
				}
				if(!product.Equals(""))
				{
					kriterianya += "and (ad.productid='" + product + "') ";
				}
				Load_ReportViewer(kriterianya, tanggal1,tanggal2,region, product);
			}
		}

		private void Load_ReportViewer(string sql_kondisi, string Start_Date, string End_Date, string region, string product)
		{
			string tanggal1	= tools.ConvertDate(Start_Date);
			string tanggal2	= tools.ConvertDate(End_Date);
			tanggal1		= tanggal1.Replace("'","");
			tanggal2		= tanggal2.Replace("'","");
			string ReportAddr;
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
			ReportViewer1.ReportPath = "/SMEReports/RptOvrTracking&sql_kondisi=" + sql_kondisi + "&Start_Date=" + tanggal1 + "&End_Date=" + tanggal2 + "&region=" + region + "&product=" + product + "&rs:Command=Render&rc:Toolbar=True";
		}

		protected void DDL_Product_SelectedIndexChanged(object sender, System.EventArgs e)
		{
		
		}

		protected void btn_back_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			Response.Redirect("MainReportCR.aspx?mc=" + Request.QueryString["mc"] + "&BU=" + LBL_BU.Text);
		}

		protected void Btn_Print_Click(object sender, System.EventArgs e)
		{
			string kriterianya = "";
			string region   = DDL_REGION.SelectedValue;
			string product = DDL_Product.SelectedValue;
			string tmp_date="";
			
			string tanggal1 = tools.ConvertDate("1",DDL_Month.SelectedValue,TXT_Year.Text);
			tmp_date = DateAndTime.DateAdd(DateInterval.Month,1,DateTime.Parse(tanggal1.ToString())).ToString();
			tmp_date = DateAndTime.DateAdd(DateInterval.Day,-1,DateTime.Parse(tmp_date)).ToString();
			string tanggal2 = tmp_date;

			/*
			if (!Information.IsDate(tanggal1) || !Information.IsDate(tanggal2))
			{
				Tools.popMessage(this,"Invalid date");
				Response.Write("<Script language='javascript'>history.back();</Script>");
				if (!Information.IsDate(tanggal1))
					Tools.SetFocus(this,DDL_Month);
				else
					Tools.SetFocus(this,DDL_Month);
			}
			else 
			*/
			{
				string tanggal1_k = Tools.toISODate(DateTime.Parse(tanggal1.ToString()).Day.ToString(), DateTime.Parse(tanggal1.ToString()).Month.ToString(), DateTime.Parse(tanggal1.ToString()).Year.ToString()); //Tools.toISODate("1",DDL_Month,TXT_Year);
				string tanggal2_k = Tools.toISODate(DateTime.Parse(tanggal2.ToString()).Day.ToString(), DateTime.Parse(tanggal2.ToString()).Month.ToString(), DateTime.Parse(tanggal2.ToString()).Year.ToString()); //Tools.toISODate(TXT_Day2,DDL_Month,TXT_Year);
				kriterianya= " and (convert(varchar, Ap_signdate, 112) BETWEEN " + tanggal1_k + " AND " + tanggal2_k + ") ";
				
				string tmp_bussunit = Session["bussunitid"].ToString();
				tmp_bussunit = tmp_bussunit.Replace("'","''");
				if (!Session["bussunitid"].Equals(""))    
				{
					kriterianya += "and (businessunit in (" + tmp_bussunit.ToString() + ")) ";
				}
/*
				if (Session["sg_grpunit"].ToString()=="CO")
				{
					kriterianya += "and (businessunit in (''CB100'')) ";
				}
*/

				if (!region.Equals(""))
				{
					kriterianya += "and (app.areaid=''" + region + "'') ";
				}
				if(!product.Equals(""))
				{
					kriterianya += "and (ad.productid=''" + product + "'') ";
				}
				Response.Redirect("RptOverideTrackingPrint.aspx?sql_kondisi=" + Server.HtmlEncode(kriterianya) + "&Start_Date=" + tanggal1 + "&End_Date=" + tanggal2 + "&region=" + region + "&product=" + product);
			}
		}
	}
}
