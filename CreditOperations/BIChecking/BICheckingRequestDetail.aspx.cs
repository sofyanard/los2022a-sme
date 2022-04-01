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

namespace SME.CreditOperations.BIChecking
{
	/// <summary>
	/// Summary description for BICheckingRequestDetail.
	/// </summary>
	public partial class BICheckingRequestDetail : System.Web.UI.Page
	{
		protected Connection conn ;
		protected Tools tool = new Tools();
		
		protected void Page_Load(object sender, System.EventArgs e)
		{
			conn = (Connection) Session["Connection"];

			if (!IsPostBack)
			{
				loadData();
				bindData();
				BTN_UPDATE.Enabled = false;
			}
			BTN_PRINT.Attributes.Add("onclick","if(!cek_mandatory(document.Form1)){return false;};");
			BTN_UPDATE.Attributes.Add("onclick","if(!update()){return false;};");
		}

		private void loadData()
		{
			conn.QueryString = "SELECT NO_SURAT, BRANCH_NAME, TEAM_LEADER, AP_RELMNGR, "+
				"CO, AP_SIGNDATE, AP_REGNO, NAME, JENIS_BADAN_HUKUM, "+
				"ALAMAT, DATI1, NPWP, IDNO, BUSSUNITDESC, AP_RECVDATE "+
				"FROM VW_CREOPR_BICHECK_REQUESTDETAIL "+
				"WHERE AP_REGNO = '" + Request.QueryString["regno"] + "'";
			conn.ExecuteQuery();
			TXT_NOSURAT.Text = conn.GetFieldValue("NO_SURAT");
			TXT_CABANG.Text = conn.GetFieldValue("BRANCH_NAME");
			TXT_TEAMLEADER.Text = conn.GetFieldValue("TEAM_LEADER");
			TXT_RM.Text = conn.GetFieldValue("AP_RELMNGR");
			TXT_CO.Text = Session["FullName"].ToString();
			TXT_AP_SIGNDATE.Text = conn.GetFieldValue("AP_RECVDATE");
			TXT_AP_REGNO.Text = conn.GetFieldValue("AP_REGNO");
			TXT_NAME.Text = conn.GetFieldValue("NAME");
			TXT_BADANHUKUM.Text = conn.GetFieldValue("JENIS_BADAN_HUKUM");
			TXT_ALAMAT.Text = conn.GetFieldValue("ALAMAT");
			TXT_DATI1.Text = conn.GetFieldValue("DATI1");
			TXT_CU_NPWP.Text = conn.GetFieldValue("NPWP");
			TXT_IDNO.Text = conn.GetFieldValue("IDNO");
			TXT_BUSINESSUNIT.Text = conn.GetFieldValue("BUSSUNITDESC");
		}

		private void bindData()
		{
			DataTable dt = new DataTable();
			DataRow dr;

//			conn.QueryString = "SELECT isnull(cs_firstname, '') + isnull(' '+ cs_middlename, '') + "+
//				"isnull(' ' + cs_lastname, '') NAME, " +
//				"ISNULL(CS_ADDR1, '') + ISNULL(' ' + CS_ADDR2, '') + ISNULL(' ' + CS_ADDR3, '') ADDR, " +
//				"CS_DOB, CS_IDCARDNUM, JOBTITLEDESC "+
//				"FROM CUST_STOCKHOLDER CS LEFT JOIN RFJOBTITLE JT ON JT.JOBTITLEID = CS.CS_JOBTITLE "+
//				"WHERE CU_REF = '" + Request.QueryString["curef"] + "' ";

			conn.QueryString = "select * from VW_CREOPR_BICHECK_PENGURUSLIST where CU_REF = '" + Request.QueryString["curef"] + "'";
			conn.ExecuteQuery();
			if (conn.GetRowCount() == 0)
			{
				DataGrid1.Visible = false;
				return;
			}
			dt.Columns.Add(new DataColumn("NAME"));
			dt.Columns.Add(new DataColumn("ADDR"));
			dt.Columns.Add(new DataColumn("DOB"));
			dt.Columns.Add(new DataColumn("ID"));
			dt.Columns.Add(new DataColumn("JOBTITLE"));
			dt.Columns.Add(new DataColumn("AKTA"));
			for (int i = 0; i < conn.GetRowCount(); i++) 
			{
				dr = dt.NewRow();
				for (int j = 0; j < conn.GetColumnCount(); j++)
				{
					dr[j] = conn.GetFieldValue(i,j);
				}
				dt.Rows.Add(dr);
			}
			DataGrid1.DataSource = new DataView(dt);
			try 
			{
				DataGrid1.DataBind();
			} 
			catch 
			{
				DataGrid1.CurrentPageIndex = 0;
				DataGrid1.DataBind();
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

		protected void BTN_UPDATE_Click(object sender, System.EventArgs e)
		{
			/***
			 * -- YUDI
			 * Keterangan :
			 * BS_COMPLETE
			 * => 0 : Belum lengkap
			 * => 1 : Sudah request, menuju result
			 * => 2 : SUDAH LENGKAP !
			 * => 3 : Sudah Result, menunggu validasi
			 * ***/
			conn.QueryString = "update bi_status set bs_coofficer='" + Session["UserID"].ToString() +
				"', BS_COMPLETE='1', BS_COREQBI=GETDATE() where ap_regno='" + Request.QueryString["regno"] + "'";
			conn.ExecuteNonQuery();

			//string msg = getNextStepMsg(Request.QueryString["regno"]);
			/*string msg = "Application proceeds to BI Checking Result";
			Response.Redirect("BICheckingRequestList.aspx?msg=" + msg);*/
			Response.Redirect("BICheckingRequestList.aspx");
		}

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

		protected void BTN_BACK_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			Response.Redirect("BICheckingRequestList.aspx");
		}

		protected void BTN_PRINT_Click(object sender, System.EventArgs e)
		{
			BTN_UPDATE.Enabled = true;
			Response.Write("<script language='javascript'>window.open('BICheckingRequestPrint.aspx?regno=" +
				Request.QueryString["regno"] + "&curef=" + Request.QueryString["curef"] + "&nosurat=" + TXT_NOSURAT.Text.Trim() +
				"','PrintBIRequest');</script>");
				//"','PrintBIRequest','status=no,width=600,height=200');</script>");
		}
	}
}
