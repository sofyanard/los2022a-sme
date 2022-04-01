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
using System.Configuration;
using DMS.DBConnection;
using DMS.CuBESCore;
using Microsoft.VisualBasic;

namespace SME.IDI_BI
{
	/// <summary>
	/// Summary description for InputBIReq.
	/// </summary>
	public partial class InputBIReq : System.Web.UI.Page
	{
		protected Connection conn;
		protected CommonForm.DocExport DocExport1;
		protected Tools tool = new Tools();
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			conn = (Connection) Session["Connection"];
			if (!IsPostBack)
			{
				TXT_IDI_REQ.Text=Request.QueryString["regnum"];			

				DDL_BLN_REQ.Items.Add(new ListItem("--Pilih--",""));
				DDL_BLN_CHECK.Items.Add(new ListItem("--Pilih--",""));
				DDL_BLN_LAHIR.Items.Add(new ListItem("--Pilih--",""));					
				
				for (int i=1; i<=12; i++)
				{
					DDL_BLN_REQ.Items.Add(new ListItem(DateAndTime.MonthName(i, false), i.ToString()));
					DDL_BLN_CHECK.Items.Add(new ListItem(DateAndTime.MonthName(i, false), i.ToString()));
					DDL_BLN_LAHIR.Items.Add(new ListItem(DateAndTime.MonthName(i, false), i.ToString()));					
				}

				DDL_JNS_DATI2.Items.Add(new ListItem("--Pilih--", ""));
				DDL_IDI_TUJUAN.Items.Add(new ListItem("--Pilih--", ""));
				DDL_CO.Items.Add(new ListItem("--Pilih--", ""));
				DDL_STATUS_APP.Items.Add(new ListItem("--Pilih--",""));
				//DDL_CO.Items.Add(new ListItem("70101-RCO Medan", "70101"));
				//DDL_CO.Items.Add(new ListItem("CBC1-Strategic Business Unit", "CBC1"));

				//conn.QueryString="select zipcode, zipcode + '-' + description as dati2 from rfzipcodecity where active='1' order by description";
				conn.QueryString="select zipcode + '-' + description as code, zipcode + '-' + description as dati2 from rfzipcodecity where active='1' order by description";
				conn.ExecuteQuery();
				for (int i = 0; i < conn.GetRowCount(); i++)
					DDL_JNS_DATI2.Items.Add(new ListItem(conn.GetFieldValue(i,1), conn.GetFieldValue(i,0)));

				conn.QueryString="select * from rf_status_app where active='1'";
				conn.ExecuteQuery();
				for (int i = 0; i < conn.GetRowCount(); i++)
					DDL_STATUS_APP.Items.Add(new ListItem(conn.GetFieldValue(i,1), conn.GetFieldValue(i,0)));

				conn.QueryString="select tujuan_idi_cd + '-' + tujuan_idi_desc as code, tujuan_idi_cd + '-' + tujuan_idi_desc as description from rf_tujuan_idi where active='1'";
				conn.ExecuteQuery();
				for (int i = 0; i < conn.GetRowCount(); i++)
					DDL_IDI_TUJUAN.Items.Add(new ListItem(conn.GetFieldValue(i,1), conn.GetFieldValue(i,0)));

				/*string su_branch;
				conn.QueryString = "select su_branch from scuser where userid='"+Session["UserID"].ToString()+"'";
				conn.ExecuteQuery();
				su_branch = conn.GetFieldValue("su_branch"); */
				
				conn.QueryString="select cu_unit_cd, cu_unit_cd + '-' + cu_unit_desc as co_unit from rf_co_unit where active='1'";
				conn.ExecuteQuery();
				for (int i = 0; i < conn.GetRowCount(); i++)
					DDL_CO.Items.Add(new ListItem(conn.GetFieldValue(i,1), conn.GetFieldValue(i,0)));

				if (Request.QueryString["exist"]=="0")
				{
					ViewDataExist();
				}
				
				InsertDataAutomate();
				ViewData();
				BTN_UPDATE.Enabled = false;

				DocExport1.GroupTemplate = "IDIPRINT";
			}

		}

		private void InsertDataAutomate()
		{			
			conn.QueryString = "select getdate()";
			conn.ExecuteQuery();
			string tgl = conn.GetFieldValue(0,0);
			TXT_DAY_REQ.Text = tool.FormatDate_Day(conn.GetFieldValue(0,0));
			DDL_BLN_REQ.SelectedValue = tool.FormatDate_Month(tgl);
			TXT_THN_REQ.Text = tool.FormatDate_Year(conn.GetFieldValue(0,0));
			TXT_DAY_CHECK.Text = tool.FormatDate_Day(conn.GetFieldValue(0,0));
			DDL_BLN_CHECK.SelectedValue = tool.FormatDate_Month(tgl);
			TXT_THN_CHECK.Text = tool.FormatDate_Year(conn.GetFieldValue(0,0));
		}

		private void ViewDataExist()
		{
			conn.QueryString = "select * from idi_request where idi_req#='" + Request.QueryString["regnumexist"] + "'";
			conn.ExecuteQuery();
			TXT_DAY_REQ.Text = tool.FormatDate_Day(conn.GetFieldValue("IDI_REQDATE"));
			try{DDL_BLN_REQ.SelectedValue = tool.FormatDate_Month(conn.GetFieldValue("IDI_REQDATE"));}
			catch{DDL_BLN_REQ.SelectedValue = "";}
			TXT_THN_REQ.Text = tool.FormatDate_Year(conn.GetFieldValue("IDI_REQDATE"));
			TXT_DAY_CHECK.Text = tool.FormatDate_Day(conn.GetFieldValue("IDI_LAST_REQDATE"));
			try{DDL_BLN_CHECK.SelectedValue = tool.FormatDate_Month(conn.GetFieldValue("IDI_LAST_REQDATE"));}
			catch{DDL_BLN_CHECK.SelectedValue = "";}
			TXT_THN_CHECK.Text = tool.FormatDate_Year(conn.GetFieldValue("IDI_LAST_REQDATE"));
			TXT_NO_SURAT.Text = conn.GetFieldValue("IDI_SURAT#");
			TXT_DIN.Text = conn.GetFieldValue("IDI_DIN#");
			TXT_NPWP.Text = conn.GetFieldValue("IDI_NPWP#");
			TXT_NAMA_DEBITUR.Text = conn.GetFieldValue("IDI_CUSTNAME");
			TXT_NO_KTP.Text = conn.GetFieldValue("IDI_KTP#");
			TXT_TGL_LAHIR.Text = tool.FormatDate_Day(conn.GetFieldValue("IDI_BOD_DATE"));
			try{DDL_BLN_LAHIR.SelectedValue = tool.FormatDate_Month(conn.GetFieldValue("IDI_BOD_DATE"));}
			catch{DDL_BLN_LAHIR.SelectedValue="";}
			TXT_THN_LAHIR.Text = tool.FormatDate_Year(conn.GetFieldValue("IDI_BOD_DATE"));
			TXT_CU_COMPZIPCODE.Text = conn.GetFieldValue("IDI_ZIPCODE");
			try{DDL_JNS_DATI2.SelectedValue = conn.GetFieldValue("IDI_DATI2");}
			catch{DDL_JNS_DATI2.SelectedValue="";}
			TXT_ALAMAT.Text = conn.GetFieldValue("IDI_ADDRESS");
			try{DDL_IDI_TUJUAN.SelectedValue = conn.GetFieldValue("IDI_TUJUAN");}
			catch{DDL_IDI_TUJUAN.SelectedValue = "";}
			try{DDL_CO.SelectedValue = conn.GetFieldValue("IDI_CO");}
			catch{DDL_CO.SelectedValue = "";}
			try{RDO_PERMINTAAN.SelectedValue = conn.GetFieldValue("IDI_KEBUTUHAN");} 
			catch{RDO_PERMINTAAN.SelectedValue = "1";}
			TXT_BORN_PLACE.Text = conn.GetFieldValue("IDI_BORN_PLACE");
			try{DDL_STATUS_APP.SelectedValue = conn.GetFieldValue("IDI_STATUS_APP");}
			catch{DDL_STATUS_APP.SelectedValue = "";}
		}

		private void ViewData()
		{
			conn.QueryString = "select * from idi_request where idi_req#='" + Request.QueryString["regnum"] + "'";
			conn.ExecuteQuery();
			if (conn.GetRowCount() > 0)
			{
				TXT_DAY_REQ.Text = tool.FormatDate_Day(conn.GetFieldValue("IDI_REQDATE"));
				try{DDL_BLN_REQ.SelectedValue = tool.FormatDate_Month(conn.GetFieldValue("IDI_REQDATE"));}
				catch{DDL_BLN_REQ.SelectedValue = "";}
				TXT_THN_REQ.Text = tool.FormatDate_Year(conn.GetFieldValue("IDI_REQDATE"));
				TXT_DAY_CHECK.Text = tool.FormatDate_Day(conn.GetFieldValue("IDI_LAST_REQDATE"));
				try{DDL_BLN_CHECK.SelectedValue = tool.FormatDate_Month(conn.GetFieldValue("IDI_LAST_REQDATE"));}
				catch{DDL_BLN_CHECK.SelectedValue = "";}
				TXT_THN_CHECK.Text = tool.FormatDate_Year(conn.GetFieldValue("IDI_LAST_REQDATE"));
				TXT_NO_SURAT.Text = conn.GetFieldValue("IDI_SURAT#");
				TXT_DIN.Text = conn.GetFieldValue("IDI_DIN#");
				TXT_NPWP.Text = conn.GetFieldValue("IDI_NPWP#");
				TXT_NAMA_DEBITUR.Text = conn.GetFieldValue("IDI_CUSTNAME");
				TXT_NO_KTP.Text = conn.GetFieldValue("IDI_KTP#");
				TXT_TGL_LAHIR.Text = tool.FormatDate_Day(conn.GetFieldValue("IDI_BOD_DATE"));
				try{DDL_BLN_LAHIR.SelectedValue = tool.FormatDate_Month(conn.GetFieldValue("IDI_BOD_DATE"));}
				catch{DDL_BLN_LAHIR.SelectedValue="";}
				TXT_THN_LAHIR.Text = tool.FormatDate_Year(conn.GetFieldValue("IDI_BOD_DATE"));
				TXT_CU_COMPZIPCODE.Text = conn.GetFieldValue("IDI_ZIPCODE");
				try{DDL_JNS_DATI2.SelectedValue = conn.GetFieldValue("IDI_DATI2");}
				catch{DDL_JNS_DATI2.SelectedValue="";}
				TXT_ALAMAT.Text = conn.GetFieldValue("IDI_ADDRESS");
				try{DDL_IDI_TUJUAN.SelectedValue = conn.GetFieldValue("IDI_TUJUAN");}
				catch{DDL_IDI_TUJUAN.SelectedValue = "";}
				try{DDL_CO.SelectedValue = conn.GetFieldValue("IDI_CO");}
				catch{DDL_CO.SelectedValue = "";}
				try{RDO_PERMINTAAN.SelectedValue = conn.GetFieldValue("IDI_KEBUTUHAN");} 
				catch{RDO_PERMINTAAN.SelectedValue = "1";}
				TXT_BORN_PLACE.Text = conn.GetFieldValue("IDI_BORN_PLACE");
				try{DDL_STATUS_APP.SelectedValue = conn.GetFieldValue("IDI_STATUS_APP");}
				catch{DDL_STATUS_APP.SelectedValue = "";}
			}

			else
			{
				InsertDataAutomate();
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

		private void ClearData()
		{
			/*TXT_DAY_REQ.Text = "";
			DDL_BLN_REQ.SelectedValue = "";
			TXT_THN_REQ.Text = "";
			TXT_DAY_CHECK.Text = "";
			DDL_BLN_CHECK.SelectedValue = "";
			TXT_THN_CHECK.Text = "";*/
			TXT_NO_SURAT.Text = "";
			TXT_DIN.Text = "";
			TXT_NPWP.Text = "";
			TXT_NAMA_DEBITUR.Text = "";
			TXT_NO_KTP.Text = "";
			TXT_TGL_LAHIR.Text = "";
			DDL_BLN_LAHIR.SelectedValue = "";
			TXT_THN_LAHIR.Text = "";
			TXT_CU_COMPZIPCODE.Text = "";
			DDL_JNS_DATI2.SelectedValue = "";
			TXT_ALAMAT.Text = "";
			DDL_IDI_TUJUAN.SelectedValue = "";
			DDL_CO.SelectedValue = "";
		}

		protected void BTN_CLEAR_Click(object sender, System.EventArgs e)
		{
			ClearData();
		}

		protected void BTN_SAVE_Click(object sender, System.EventArgs e)
		{
			Int64 now = Int64.Parse(Tools.toISODate(DateTime.Now.Day.ToString(), DateTime.Now.Month.ToString(), DateTime.Now.Year.ToString())), compEstablish;
			Int64 tanggalBerdiri;
			tanggalBerdiri = Int64.Parse(Tools.toISODate(TXT_TGL_LAHIR.Text, DDL_BLN_LAHIR.SelectedValue, TXT_THN_LAHIR.Text));

			if (tanggalBerdiri > now) 
			{
				GlobalTools.popMessage(this, "Tanggal Lahir/Pendirian tidak bisa lebih dari tanggal saat ini!!");
				return;
			}

			if (TXT_NO_SURAT.Text=="" || DDL_CO.SelectedValue=="")
			{
				GlobalTools.popMessage(this, "Data mandatory belum lengkap!");
				return;	
			}

			conn.QueryString = "exec IDI_BI_INSERT '" +
				Request.QueryString["regnum"] + "', " +
				tool.ConvertDate(TXT_DAY_REQ.Text, DDL_BLN_REQ.SelectedValue, TXT_THN_REQ.Text) + ", " +
				tool.ConvertDate(TXT_DAY_CHECK.Text, DDL_BLN_CHECK.SelectedValue, TXT_THN_CHECK.Text) + ", '" +
				TXT_NO_SURAT.Text + "', '" +
				TXT_DIN.Text + "', '" +
				TXT_NPWP.Text + "', '" +
				TXT_NAMA_DEBITUR.Text + "', '" +
				TXT_NO_KTP.Text + "', " +
				tool.ConvertDate(TXT_TGL_LAHIR.Text, DDL_BLN_LAHIR.SelectedValue, TXT_THN_LAHIR.Text) + ", '" +	
				TXT_CU_COMPZIPCODE.Text + "', '" +
				DDL_JNS_DATI2.SelectedValue + "', '" +
				TXT_ALAMAT.Text + "', '" +
				RDO_PERMINTAAN.SelectedValue + "', '" +
				DDL_IDI_TUJUAN.SelectedValue + "', '" +
				DDL_CO.SelectedValue + "', '" +
				Session["BranchName"].ToString() + "', '" +
				Session["UserID"].ToString() + "', '" +
				DDL_STATUS_APP.SelectedValue + "', '" +
				TXT_BORN_PLACE.Text + "' ";				
			conn.ExecuteNonQuery();

			BTN_UPDATE.Enabled = true;
		}

		protected void BTN_BACK_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			Response.Redirect("ListInputReqBI.aspx?tc=" + Request.QueryString["tc"] + "&mc=" + Request.QueryString["mc"] );
		}

		protected void BTN_SEARCHCOMP_Click(object sender, System.EventArgs e)
		{
			Response.Write("<script language='javascript'>window.open('SearchZipcode.aspx?targetFormID=Form1&targetObjectID=TXT_CU_COMPZIPCODE','SearchZipcode','status=no,scrollbars=no,width=420,height=200');</script>");
		}

		protected void BTN_UPDATE_Click(object sender, System.EventArgs e)
		{
			Int64 now = Int64.Parse(Tools.toISODate(DateTime.Now.Day.ToString(), DateTime.Now.Month.ToString(), DateTime.Now.Year.ToString())), compEstablish;
			Int64 tanggalBerdiri;
			tanggalBerdiri = Int64.Parse(Tools.toISODate(TXT_TGL_LAHIR.Text, DDL_BLN_LAHIR.SelectedValue, TXT_THN_LAHIR.Text));

			if (tanggalBerdiri > now) 
			{
				GlobalTools.popMessage(this, "Tanggal Lahir/Pendirian tidak bisa lebih dari tanggal saat ini!!");
				return;
			}

			if (TXT_NO_SURAT.Text=="" || DDL_STATUS_APP.SelectedValue=="" || DDL_CO.SelectedValue=="" || TXT_TGL_LAHIR.Text=="" || DDL_BLN_LAHIR.SelectedValue=="" || TXT_THN_LAHIR.Text=="" ||TXT_NAMA_DEBITUR.Text=="" || DDL_IDI_TUJUAN.SelectedValue=="")
			{
				GlobalTools.popMessage(this, "Data mandatory belum lengkap!");
				return;	
			}

			conn.QueryString = "update idi_request set idi_status='0' where idi_req# = '"+Request.QueryString["regnum"]+"' ";
			conn.ExecuteQuery();

			conn.QueryString = "exec IDI_TRACKUPDATE '" + 
				Request.QueryString["regnum"] + "', '" +
				Request.QueryString["tc"] + "', '" +
				Session["UserID"].ToString() + "' ";				
			conn.ExecuteNonQuery();	
			
			conn.QueryString = "exec IDI_BI_INSERT_APPSIDPROCESS '" + 
				Request.QueryString["regnum"] + "' ";
			conn.ExecuteNonQuery();
			
	
			Response.Redirect("ListInputReqBI.aspx?tc=" + Request.QueryString["tc"] + "&mc=" + Request.QueryString["mc"]);	
		}
	}
}
