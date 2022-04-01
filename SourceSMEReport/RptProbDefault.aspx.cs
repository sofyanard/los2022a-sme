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

namespace SME.SourceSMEReport
{
	/// <summary>
	/// Summary description for RptProbDefault.
	/// </summary>
	public partial class RptProbDefault : System.Web.UI.Page
	{
		protected Tools tools = new Tools();
		protected Connection Conn = new Connection();
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			Conn = (Connection) Session["Connection"];
			double tahun;
			LBL_BU.Text = Request.QueryString["BU"];
			if (!IsPostBack)
			{
				DDL_year.Items.Add(new ListItem("-- PILIH --",""));
				tahun = double.Parse(DateTime.Now.Date.Year.ToString());
				for (double i=tahun-3; i <= tahun; i++)
				{
					DDL_year.Items.Add(new ListItem(i.ToString(), i.ToString()));
				}
				Label1.Text = Posisi_User().ToString();
			}
			//Load_Data("VIEW");
			//BTN_LIHAT.Attributes.Add("onclick","if(!cek_mandatory(document.Form1)){return false;};");
		}

		private void Load_Data(string command)
		{
			string ddl_tahun = "";
			if (!DDL_year.SelectedValue.Equals(""))
			{
				ddl_tahun = DDL_year.SelectedValue;
			}
			else
			{
				ddl_tahun = DateTime.Now.Year.ToString();
			}
			if (command=="VIEW")
			{
				Load_ReportViewer(ddl_tahun);
			}
			else
			{
				Load_ReportPrint(ddl_tahun);
			}
		}
		
		private void Load_ReportViewer(string ddl_tahun)
		{
			string ReportAddr="", sql_kondisi="";
			double start_year=0, end_year=0;
			end_year = double.Parse(ddl_tahun.ToString());
			start_year = end_year; //double.Parse(ddl_tahun.ToString())-3;

			sql_kondisi += " and year=" + end_year.ToString() + " "; 
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
			ReportViewer1.ReportPath = "/SMEReports/RptProbDefault&sql_kondisi=" + Server.HtmlEncode(sql_kondisi) + "&tahun=" + ddl_tahun + "&rs:Command=Render&rc:Toolbar=True";
		}

		private void Load_ReportPrint(string ddl_tahun)
		{
			string sql_kondisi="";
			double start_year=0, end_year=0;
			end_year = double.Parse(ddl_tahun.ToString());
			start_year = double.Parse(ddl_tahun.ToString())-3;
			sql_kondisi += " and year between " + start_year.ToString() + " and " + end_year.ToString(); 
			Response.Redirect("RptProbDefaultPrint.aspx?sql_kondisi=" + Server.HtmlEncode(sql_kondisi) + "&start_year=" + start_year + "&end_year=" + end_year);
		}

		private int Posisi_User()
		{
			string area = "";
			int Posisi;
			if (Session["BranchID"].ToString()=="99999")
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
			Load_Data("VIEW");
		}

		protected void Btn_Print_Click(object sender, System.EventArgs e)
		{
			Load_Data("PRINT");
		}

		protected void btn_Back_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			Response.Redirect("MainReportCR.aspx?mc=" + Request.QueryString["mc"] + "&BU=" + LBL_BU.Text);
		}
	}
}
