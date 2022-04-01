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
using Microsoft.VisualBasic;
using DMS.CuBESCore;

namespace SME.CEA
{
	/// <summary>
	/// Summary description for SLARekanan.
	/// </summary>
	public partial class SLARekanan : System.Web.UI.Page
	{
		protected Connection conn;
		protected Tools tools = new Tools();
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			conn = (Connection) Session["Connection"];

			if (!IsPostBack)
			{
				DDL_BLN1.Items.Add(new ListItem("-- PILIH --",""));
				DDL_BLN2.Items.Add(new ListItem("-- PILIH --",""));
				for (int i = 1; i <= 12; i++)
				{
					DDL_BLN1.Items.Add(new ListItem(DateAndTime.MonthName(i, false), i.ToString()));
					DDL_BLN2.Items.Add(new ListItem(DateAndTime.MonthName(i, false), i.ToString()));
				}

				//penambahan DDL KLASIFIKASI 13-2-2013 Oleh Ariel
				DDL_KLASIFIKASI.Items.Add(new ListItem("--Pilih--",""));
				conn.QueryString = "select KL_ID from REKANAN_RFKLASIFIKASI where active=1";
				conn.ExecuteQuery();

				for(int i=0; i<conn.GetRowCount(); i++)
					DDL_KLASIFIKASI.Items.Add(new ListItem(conn.GetFieldValue(i,0), conn.GetFieldValue(i,0)));
				//
				TXT_TGL1.Text=DateAndTime.Today.Day.ToString();
				DDL_BLN1.SelectedValue=DateAndTime.Today.Month.ToString();
				TXT_THN1.Text=DateAndTime.Today.Year.ToString();
				TXT_TGL2.Text=DateAndTime.Today.Day.ToString();
				DDL_BLN2.SelectedValue=DateAndTime.Today.Month.ToString();
				TXT_THN2.Text=DateAndTime.Today.Year.ToString();

				Label1.Text = Posisi_User().ToString();
				FillRegion();
				FillJenisRekanan();
				FillRekanan();
			}

		}
		
		
		private void FillRegion()
		{
			DDL_REGION.Items.Clear();
			switch(Label1.Text)
			{
				case "1": case "2": case "3":
					conn.QueryString = "select AreaID, AREANAME from rfarea where AreaID='" + Session["AreaID"].ToString() + "' ";
					break;
					/*
				case "3": 
					Conn.QueryString = "select AreaID, AREANAME from rfarea where arearegmanager='" + Session["UserID"].ToString() + "' ";
					break;
					*/
				default:
					conn.QueryString = "select AreaID, AREANAME from rfarea";
					DDL_REGION.Items.Add(new ListItem("-- PILIH --",""));
					break;
			}
			conn.ExecuteQuery();
			for (int i = 0; i < conn.GetRowCount(); i++)
			{
				DDL_REGION.Items.Add(new ListItem(conn.GetFieldValue(i,1),conn.GetFieldValue(i,0)));
			}
			fillCBC();
		}

		private void fillCBC()
		{
			DDL_SBU.Items.Clear();
			switch(Label1.Text)
			{
				case "1": 
					conn.QueryString = "select cbc.branch_code as cbc_code, cbc.branch_name as branch_name  from rfbranch b " +
						" left join rfbranch cbc on cbc.branch_code = b.cbc_code " +
						" where b.Branch_CODE='" + Session["BranchID"].ToString() + "' ";

					break;

				case "2":
					conn.QueryString = "select branch_code as cbc_code, branch_name as branch_name  from rfbranch  " +
						" where branch_code = cbc_code and CBC_code='" + Session["CBC"].ToString() + "' ";
					break;

				case "3":
					conn.QueryString = "select branch_code as cbc_code, branch_name as branch_name  from rfbranch  " +
						" where branch_code = cbc_code and areaid  ='" + Session["AreaID"].ToString() + "' ";
					break;
				default:
					conn.QueryString = "select branch_code as cbc_code, branch_name as branch_name  from rfbranch  " +
						" where branch_code = cbc_code and areaid ='" +  DDL_REGION.SelectedValue  + "' ";
	
					DDL_SBU.Items.Add(new ListItem("-- PILIH --",""));
					break;
			}
			if(DDL_REGION.SelectedValue != "")
			{
				conn.ExecuteQuery();
				for (int i = 0; i < conn.GetRowCount(); i++)
				{
					DDL_SBU.Items.Add(new ListItem(conn.GetFieldValue(i,1),conn.GetFieldValue(i,0)));
				}
			}
		}

		private void FillJenisRekanan()
		{
			DDL_JNS_REK.Items.Add(new ListItem("--Pilih--",""));
			conn.QueryString = "select rekananid, rekanandesc from rfjenisrekanan where active='1'";
			conn.ExecuteQuery();

			for(int i = 0; i < conn.GetRowCount(); i++)
			{
				DDL_JNS_REK.Items.Add(new ListItem(conn.GetFieldValue(i,1), conn.GetFieldValue(i,0)));
			}
			FillRekanan();
		}
		private void FillRekanan()
		{
			DDL_Rekanan.Items.Clear();
			DDL_Rekanan.Items.Add(new ListItem("--Pilih--",""));

			if(DDL_JNS_REK.SelectedValue!="")
				//conn.QueryString = "select rekanan_ref, namerekanan from rekanan where rfrekanantype='" + DDL_JNS_REK.SelectedValue + "'";
				switch(DDL_JNS_REK.SelectedValue)
				{
					case "01":
						conn.QueryString = "select agencyid, agencyname from rfagency where active='1'";
						break;
					case "02": 
						conn.QueryString = "select kap_id, kap_name from rfkap where active='1'";
						break;
					case "03":
						conn.QueryString = "select km_id, km_name from rfkonsultanmanajemen where active='1'";
						break;
					case "04": case "05":
						conn.QueryString = "select ic_id, ic_desc from rfinsurancecompany where active='1'";
						break;
					case "06":
						conn.QueryString = "select ba_id, ba_name from rfbrokerasuransi where active='1'";
						break;
					case "07":
						conn.QueryString = "select ntid, nt_name from rfnotary where active='1'";
						break;
					case "08":
						conn.QueryString = "select bl_id, bl_name from rfbalailelang where active='1'";
						break;
				}
			else
				conn.QueryString = "select * from vw_rekanan_all";
			
			conn.ExecuteQuery();
			
			for(int i = 0; i < conn.GetRowCount(); i++)
				DDL_Rekanan.Items.Add(new ListItem(conn.GetFieldValue(i,1), conn.GetFieldValue(i,0)));

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
				conn.QueryString = "select * from rfarea where arearegmanager='" + Session["UserID"].ToString() + "' ";
				conn.ExecuteQuery();
				if (conn.GetRowCount()>0)
					area="yup";
				else
					area="nop";

				if (area=="yup")
				{
					Posisi=3;
				}//aa
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

		protected void DDL_REGION_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			fillCBC();
		}

		protected void DDL_JNS_REK_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			FillRekanan();
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

		protected void DDL_SBU_SelectedIndexChanged(object sender, System.EventArgs e)
		{
		
		}

		private void LoadReport_Load(string area, string cbc, string rekanantype, string rekanan, string tgl1, string tgl2, string klasifikasi)
		{	
			string ReportAddr="", kriterianya="", tanggal1_k="", tanggal2_k="";
			string tanggal1	= tools.ConvertDate(tgl1);
			string tanggal2	= tools.ConvertDate(tgl2);
			 
			tanggal1		= tanggal1.Replace("'","");
			tanggal2		= tanggal2.Replace("'","");

			conn.QueryString = "select reportaddr from app_parameter";
			conn.ExecuteQuery();
			if (conn.GetRowCount()>0)
				ReportAddr = conn.GetFieldValue(0,0);
			else
				ReportAddr  = "10.123.12.50";
			
			ReportViewer2.ServerUrl = "http://" + ReportAddr + "/ReportServer";
			if (!Information.IsDate(tanggal1))
			{
				tanggal1	= DateTime.Today.ToString();
				tanggal1_k = Tools.toISODate(DateTime.Today.Day.ToString(),DateTime.Today.Month.ToString() ,DateTime.Today.Year.ToString());
			}
			else
			{
				tanggal1_k = Tools.toISODate(DateTime.Parse(tanggal1.ToString()).Day.ToString(),DateTime.Parse(tanggal1.ToString()).Month.ToString(), DateTime.Parse(tanggal1.ToString()).Year.ToString());
			}
			if (!Information.IsDate(tanggal2))
			{
				tanggal2	= DateTime.Today.ToString();
				tanggal2_k = Tools.toISODate(DateTime.Today.Day.ToString(),DateTime.Today.Month.ToString() ,DateTime.Today.Year.ToString());
			}
			else
			{
				tanggal2_k = Tools.toISODate(DateTime.Parse(tanggal2.ToString()).Day.ToString(), DateTime.Parse(tanggal2.ToString()).Month.ToString(), DateTime.Parse(tanggal2.ToString()).Year.ToString());
			}
			kriterianya += "AND (convert(nvarchar, TgApplikasi, 112) between " + tanggal1_k + " and " + tanggal2_k + ") ";

			if (!area.Equals(""))
			{
				kriterianya += "AND (areaid = '" + area + "') ";
			}
			if (!cbc.Equals(""))     
			{
				kriterianya += " AND (branch_code = '" + cbc + "') ";
			}
			if (!rekanantype.Equals(""))
			{
				kriterianya += " AND (rfrekanantype = '" + rekanantype + "') ";
			}
			if (!rekanan.Equals(""))
			{
				kriterianya += "and (id_rekanan = '" + rekanan + "') ";
			}
			if(!klasifikasi.Equals(""))
			{
				kriterianya += "and (klasifikasi = '" + klasifikasi + "') ";
			}
			
			ReportViewer2.ReportPath = "/SMEReports/RptRekananSLA&kriterianya=" + kriterianya;
		}

		protected void BTN_Find_Click(object sender, System.EventArgs e)
		{
			string area		= DDL_REGION.SelectedValue;
			string cbc      = DDL_SBU.SelectedValue;
			string rekanantype = DDL_JNS_REK.SelectedValue;
			string rekanan = DDL_Rekanan.SelectedValue;
			string klasifikasi = DDL_KLASIFIKASI.SelectedValue;

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
					LoadReport_Load(area, cbc, rekanantype, rekanan, tanggal1, tanggal2, klasifikasi);
			}
			else
			{
				Response.Write("<script language='javascript'>alert('Invalid Date !')</script>");
			}
		}

		protected void BTN_Back_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			Response.Redirect("ReportingListing.aspx?mc=" + Request.QueryString["mc"]);
		}
	}
}
