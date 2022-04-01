using System;
using System.IO;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using Microsoft.VisualBasic;
using DMS.CuBESCore;
using DMS.DBConnection;

namespace SME.Appraisal
{
	/// <summary>
	/// Summary description for AppraisalEntry.
	/// 
	/// TABLE LISTASSIGNMENT :
	/// -- LA_APPRSTATUS
	/// -- 0 : belum assign ke co manager
	/// -- 1 : belum assign ke petugas
	/// -- 2 : sudah assign ke petugas
	/// -- 5 : sudah diappraise oleh petugas, tinggal validasi oleh co manager
	/// -- 3 : sudah selesai di validasi oleh CO Manager!
	/// -- 6 : incomplete document dari PETUGAS ke CO MANAGER
	/// -- 7 : incomplete document dari CO MANAGER ke BU
	/// 
	///
	///
	///////////////////////////////////////////////////////////////
	///
	/// ahmad
	/// new stored procedure use (16-5-2005):
	/// APPRAISAL_ENTRYRESULT
	/// 
	/// </summary> 

	public partial class AppraisalEntry : System.Web.UI.Page
	{
		protected Tools tool = new Tools();
		protected Connection conn;


		protected void Page_Load(object sender, System.EventArgs e)
		{
			conn = (Connection) Session["Connection"];

			LBL_REGNO.Text	= Request.QueryString["regno"];
			LBL_CUREF.Text	= Request.QueryString["curef"];
			LBL_CL_SEQ.Text	= Request.QueryString["CL_SEQ"];
			lbl_TC.Text = Request.QueryString["tc"];
			lbl_MC.Text = Request.QueryString["mc"];
			lbl_ISDELETE.Text = "";


			conn.QueryString = "select GRP_CO, GRP_COOFF from APP_PARAMETER";
			conn.ExecuteQuery();
			LBL_GRP_CO.Text		= conn.GetFieldValue("GRP_CO").ToString();
			LBL_GRP_COOFF.Text	= conn.GetFieldValue("GRP_COOFF").ToString();

			if (!IsPostBack)
			{
				DDL_APPR_DATE_MONTH.Items.Add(new ListItem("- SELECT -", ""));
				DDL_APPR_IKATCODE.Items.Add(new ListItem("- SELECT -", ""));
				DDL_APPR_IKSCODE.Items.Add(new ListItem("- SELECT -", ""));
				DDL_APPR_KUCODE.Items.Add(new ListItem("- SELECT -", ""));
				DDL_APPR_MRCODE.Items.Add(new ListItem("- SELECT -", ""));
				DDL_APPR_PMCODE.Items.Add(new ListItem("- SELECT -", ""));
				DDL_APPR_SERFDATE_MONTH.Items.Add(new ListItem("- SELECT -", ""));
				DDL_APPR_SERFEXPDATE_MONTH.Items.Add(new ListItem("- SELECT -", ""));
				DDL_CERTTYPEID.Items.Add(new ListItem("- SELECT -", ""));
				
				for (int i = 1; i <= 12; i++)
				{
					DDL_APPR_DATE_MONTH.Items.Add(new ListItem(DateAndTime.MonthName(i, false), i.ToString()));
					DDL_APPR_SERFDATE_MONTH.Items.Add(new ListItem(DateAndTime.MonthName(i, false), i.ToString()));
					DDL_APPR_SERFEXPDATE_MONTH.Items.Add(new ListItem(DateAndTime.MonthName(i, false), i.ToString()));
				}

				conn.QueryString = "select * from RF_APPR_IKAT where ACTIVE = '1'";
				conn.ExecuteQuery();
				for (int i = 0; i < conn.GetRowCount(); i++)
				{
					DDL_APPR_IKATCODE.Items.Add(new ListItem(conn.GetFieldValue(i,1), conn.GetFieldValue(i,0)));
				}

				conn.QueryString =	" select coltypeid from VW_APPRAISAL_RESULT where AP_REGNO = '" +LBL_REGNO.Text+
									"' and CU_REF = '" +LBL_CUREF.Text+ "' and CL_SEQ = "+LBL_CL_SEQ.Text;
				conn.ExecuteQuery();

				try
				{
					conn.QueryString = "select * from RFCERTTYPE where ACTIVE = '1' and colflag ='" + conn.GetFieldValue("coltypeid") + "'";
				}
				catch
				{
					conn.QueryString = "select * from RFCERTTYPE where ACTIVE = '1'";
				}
				conn.ExecuteQuery();
				for (int i = 0; i < conn.GetRowCount(); i++)
				{
					DDL_CERTTYPEID.Items.Add(new ListItem(conn.GetFieldValue(i,1), conn.GetFieldValue(i,0)));
				}

				conn.QueryString = "select * from RF_APPR_MARKETABILITY where ACTIVE = '1'";
				conn.ExecuteQuery();
				for (int i = 0; i < conn.GetRowCount(); i++)
				{
					DDL_APPR_MRCODE.Items.Add(new ListItem(conn.GetFieldValue(i,1), conn.GetFieldValue(i,0)));
				}

				conn.QueryString = "select * from RF_APPR_MASALAH where ACTIVE = '1'";
				conn.ExecuteQuery();
				for (int i = 0; i < conn.GetRowCount(); i++)
				{
					DDL_APPR_PMCODE.Items.Add(new ListItem(conn.GetFieldValue(i,1), conn.GetFieldValue(i,0)));
				}

				conn.QueryString = "select * from RF_APPR_IKATSEMPURNA where ACTIVE = '1'";
				conn.ExecuteQuery();
				for (int i = 0; i < conn.GetRowCount(); i++)
				{
					DDL_APPR_IKSCODE.Items.Add(new ListItem(conn.GetFieldValue(i,1), conn.GetFieldValue(i,0)));
				}

				conn.QueryString = "select * from RF_APPR_KUASA where ACTIVE = '1'";
				conn.ExecuteQuery();
				for (int i = 0; i < conn.GetRowCount(); i++)
				{
					DDL_APPR_KUCODE.Items.Add(new ListItem(conn.GetFieldValue(i,1), conn.GetFieldValue(i,0)));
				}
				
				ViewData();
				ViewFileUpload();
			}
			BTN_SAVE.Attributes.Add("onclick","if(!cek_mandatory(document.Form1)){return false;};");
			BTN_UPDATE.Attributes.Add("onclick","if(!cek_mandatory(document.Form1)){return false;}; if(!update()){return false;};");
			BTN_REENTRY.Attributes.Add("onclick","if(!update()){return false;};");
		}

		#region my methods
		private bool isPetugas(string groupid)
		{
			bool petugas = false;

			conn.QueryString = "select groupid from scgroup where sg_grpupliner = '" + groupid + "'";
			conn.ExecuteQuery();
			
			if (conn.GetRowCount() == 0) petugas = true;

			return petugas;
		}

		private void ViewFileUpload()
		{
			conn.QueryString = "select CREDANALYSIS_DIR from APP_PARAMETER";
			conn.ExecuteQuery();
			string path = "/SME/" + conn.GetFieldValue("CREDANALYSIS_DIR").ToString().Trim().Replace("\\", "/");
			
			System.Data.DataTable dt = new System.Data.DataTable();
			conn.QueryString = "select AP_REGNO, SEQ, FU_FILENAME, FU_USERID from FILE_UPLOAD where AP_REGNO ='"+ Request.QueryString["regno"] + "'";
			conn.ExecuteQuery();
			dt = conn.GetDataTable().Copy();
			DatGrid.DataSource = dt;
			try 
			{
				DatGrid.DataBind();
			} 
			catch 
			{
				DatGrid.CurrentPageIndex = 0;
				DatGrid.DataBind();
			}
			for (int i = 1; i <= DatGrid.Items.Count; i++)
			{
				HyperLink HpDownload = (HyperLink) DatGrid.Items[i-1].Cells[3].FindControl("HL_DOWNLOAD");
				LinkButton HpDelete = (LinkButton) DatGrid.Items[i-1].Cells[4].FindControl("LinkButton1");
				HpDownload.NavigateUrl = path + DatGrid.Items[i-1].Cells[2].Text.Trim();
				DatGrid.Items[i-1].Cells[1].Text = i.ToString();
				if (Session["UserID"].ToString().Trim() != DatGrid.Items[i-1].Cells[5].Text)
					HpDelete.Visible = false;

				if (Request.QueryString["cp"] == "0") 
				{
					//HpDownload.Enabled = false;
					HpDelete.Enabled = false;
				}
				
				if (lbl_ISDELETE.Text == "Y")
					HpDelete.Visible = false;
				
			}
		}


		private void ViewData()
		{
			conn.QueryString = " select * from VW_APPRAISAL_RESULT where AP_REGNO = '" +LBL_REGNO.Text+
				"' and CU_REF = '" +LBL_CUREF.Text+ "' and CL_SEQ = "+LBL_CL_SEQ.Text;
			conn.ExecuteQuery();
			TXT_AGENCY.Text				= conn.GetFieldValue("AGENCYNAME");
			TXT_APPR_PEMERIKSA.Text		= conn.GetFieldValue("APPR_PEMERIKSA");
			try
			{
				TXT_APPR_DATE_DAY.Text		= tool.FormatDate_Day(conn.GetFieldValue("APPR_DATE"));
				DDL_APPR_DATE_MONTH.SelectedValue	= tool.FormatDate_Month(conn.GetFieldValue("APPR_DATE"));
				TXT_APPR_DATE_YEAR.Text		= tool.FormatDate_Year(conn.GetFieldValue("APPR_DATE"));
			}
			catch {}
			TXT_APPR_NAME.Text			= conn.GetFieldValue("APPR_NAME");
			if (TXT_APPR_NAME.Text.Trim() == "")
				TXT_APPR_NAME.Text	= conn.GetFieldValue("CL_DESC");

			TXT_APPR_ADDR.Text			= conn.GetFieldValue("APPR_ADDR");
			try {DDL_APPR_IKATCODE.SelectedValue		= conn.GetFieldValue("APPR_IKATCODE");}
			catch {}

			try {DDL_CERTTYPEID.SelectedValue		= conn.GetFieldValue("CERTTYPEID");}
			catch {}
			TXT_APPR_NOSERTIFIKAT.Text			= conn.GetFieldValue("APPR_NOSERTIFIKAT");
			try
			{
				TXT_APPR_SERFDATE_DAY.Text			= tool.FormatDate_Day(conn.GetFieldValue("APPR_SERFDATE"));
				DDL_APPR_SERFDATE_MONTH.SelectedValue	= tool.FormatDate_Month(conn.GetFieldValue("APPR_SERFDATE"));
				TXT_APPR_SERFDATE_YEAR.Text			= tool.FormatDate_Year(conn.GetFieldValue("APPR_SERFDATE"));
			}
			catch {}
			TXT_APPR_SERFEXPDATE_DAY.Text		= tool.FormatDate_Day(conn.GetFieldValue("APPR_SERFEXPDATE"));
			try {DDL_APPR_SERFEXPDATE_MONTH.SelectedValue= tool.FormatDate_Month(conn.GetFieldValue("APPR_SERFEXPDATE"));}
			catch {}
			TXT_APPR_SERFEXPDATE_YEAR.Text		= tool.FormatDate_Year(conn.GetFieldValue("APPR_SERFEXPDATE"));
			TXT_APPR_VALUE.Text			= tool.MoneyFormat(conn.GetFieldValue("APPR_VALUE"));
			TXT_APPR_SAFETYMARGIN.Text	= tool.MoneyFormat(conn.GetFieldValue("APPR_SAFETYMARGIN"));
			TXT_APPR_AFTERSMVALUE.Text	= tool.MoneyFormat(conn.GetFieldValue("APPR_AFTERSMVALUE"));
			try {DDL_APPR_MRCODE.SelectedValue	= conn.GetFieldValue("APPR_MRCODE");}
			catch {}
			try {DDL_APPR_PMCODE.SelectedValue	= conn.GetFieldValue("APPR_PMCODE");}
			catch {}
			try {DDL_APPR_IKSCODE.SelectedValue	= conn.GetFieldValue("APPR_IKSCODE");}
			catch {}
			try {DDL_APPR_KUCODE.SelectedValue	= conn.GetFieldValue("APPR_KUCODE");}
			catch {}
			TXT_APPR_REMARK.Text			= conn.GetFieldValue("APPR_REMARK");
			TXT_APPR_ATASNAMA.Text			= conn.GetFieldValue("APPR_ATASNAMA");
			string LA_APPRSTATUS = conn.GetFieldValue("LA_APPRSTATUS");
			string OFFICERSEQ	 = conn.GetFieldValue("OFFICERSEQ");

			conn.QueryString = "select * from VW_APPR_"+conn.GetFieldValue("COLLINKTABLE").ToString().Trim()+" where CU_REF = '" +
				LBL_CUREF.Text+ "' and CL_SEQ = "+LBL_CL_SEQ.Text;
			conn.ExecuteQuery();

			if (TXT_APPR_ATASNAMA.Text.Trim() == "")
				TXT_APPR_ATASNAMA.Text = conn.GetFieldValue("APPR_ATASNAMA").ToString();
			if (DDL_CERTTYPEID.SelectedValue.Trim() == "")
			{
				try
				{
					DDL_CERTTYPEID.SelectedValue	= conn.GetFieldValue("CERTTYPEID").ToString().Trim();
				}
				catch {}
			}
			if (TXT_APPR_NOSERTIFIKAT.Text.Trim() == "")
				TXT_APPR_NOSERTIFIKAT.Text		= conn.GetFieldValue("APPR_NOSERTIFIKAT").ToString();
			if (TXT_APPR_SERFDATE_DAY.Text.Trim() == "")
			{
				TXT_APPR_SERFDATE_DAY.Text			= tool.FormatDate_Day(conn.GetFieldValue("APPR_SERFDATE"));
				DDL_APPR_SERFDATE_MONTH.SelectedValue	= tool.FormatDate_Month(conn.GetFieldValue("APPR_SERFDATE"));
				TXT_APPR_SERFDATE_YEAR.Text			= tool.FormatDate_Year(conn.GetFieldValue("APPR_SERFDATE"));		
			}
			if (TXT_APPR_SERFEXPDATE_DAY.Text.Trim() == "")
			{
				TXT_APPR_SERFEXPDATE_DAY.Text		= tool.FormatDate_Day(conn.GetFieldValue("APPR_SERFEXPDATE"));
				DDL_APPR_SERFEXPDATE_MONTH.SelectedValue= tool.FormatDate_Month(conn.GetFieldValue("APPR_SERFEXPDATE"));
				TXT_APPR_SERFEXPDATE_YEAR.Text		= tool.FormatDate_Year(conn.GetFieldValue("APPR_SERFEXPDATE"));
			}

			string mGROUP = Session["GroupID"].ToString();
			string USERID = Session["UserID"].ToString();

			string STSTOMBOL = "0";
			if (LA_APPRSTATUS == "3") // || LA_APPRSTATUS == "7")
				STSTOMBOL = "1";
				//else if (mGROUP == petugas && LA_APPRSTATUS != "2")
			else if (isPetugas(mGROUP) && LA_APPRSTATUS != "2")
				STSTOMBOL = "1";
				//else if (mGROUP == CO Manager && (LA_APPRSTATUS != "5" || LA_APPRSTATUS != "6"))
			else if (!isPetugas(mGROUP) && (LA_APPRSTATUS != "5" || LA_APPRSTATUS != "6"))
				STSTOMBOL = "1";
				//else if (mGROUP != CO Manager && mGROUP != Petugas)
			else 
				STSTOMBOL = "1";

			if (LA_APPRSTATUS == "2" && OFFICERSEQ == USERID)
				STSTOMBOL = "0";

			//if ((LA_APPRSTATUS == "5" || LA_APPRSTATUS == "6") && mGROUP == CO Manager)
			if ((LA_APPRSTATUS == "5" || LA_APPRSTATUS == "6") && !isPetugas(mGROUP))
				STSTOMBOL = "2";

			if (STSTOMBOL == "1")
			{
				BTN_SAVE.Visible	= false;
				BTN_UPDATE.Visible	= false;
				BTN_REENTRY.Visible	= false;

				BTN_DELETE.Visible = false;
				TXT_FILE_UPLOAD.Disabled = true;
				BTN_UPLOAD.Visible = false;

				lbl_ISDELETE.Text = "Y";

				//BTN_INCOMPLETESTATUS.Visible = false;
				
				DisabledEntry();
			}
			else if (STSTOMBOL == "2")
			{
				BTN_SAVE.Visible	= false;				
				BTN_REENTRY.Visible	= true;
				BTN_DELETE.Visible = false;
				TXT_FILE_UPLOAD.Disabled = true;
				BTN_UPLOAD.Visible = false;
				lbl_ISDELETE.Text = "Y";

				if (LA_APPRSTATUS == "6") 
				{		// document collateral kurang
					//BTN_INCOMPLETESTATUS.Visible = true; 
				}
				else 
				{
					BTN_UPDATE.Visible	= true;
				}
				DisabledEntry();
			}
		}

		private void DisabledEntry()
		{
			TXT_APPR_PEMERIKSA.ReadOnly = true;
			TXT_APPR_DATE_DAY.ReadOnly	= true;
			DDL_APPR_DATE_MONTH.Enabled = false;
			TXT_APPR_DATE_YEAR.ReadOnly = true;
			TXT_APPR_NAME.ReadOnly		= true;
			TXT_APPR_ADDR.ReadOnly		= true;
			DDL_APPR_IKATCODE.Enabled	= false;
			DDL_CERTTYPEID.Enabled		= false;
			TXT_APPR_NOSERTIFIKAT.ReadOnly	= true;
			TXT_APPR_SERFDATE_DAY.ReadOnly	= true;
			DDL_APPR_SERFDATE_MONTH.Enabled = false;
			TXT_APPR_SERFDATE_YEAR.ReadOnly = true;		
			TXT_APPR_SERFEXPDATE_DAY.ReadOnly	= true;
			DDL_APPR_SERFEXPDATE_MONTH.Enabled	= false;
			TXT_APPR_SERFEXPDATE_YEAR.ReadOnly	= true;
			TXT_APPR_VALUE.ReadOnly				= true;
			TXT_APPR_SAFETYMARGIN.ReadOnly		= true;
			TXT_APPR_AFTERSMVALUE.ReadOnly		= true;
			DDL_APPR_MRCODE.Enabled		= false;
			DDL_APPR_PMCODE.Enabled		= false;
			DDL_APPR_IKSCODE.Enabled	= false;
			DDL_APPR_KUCODE.Enabled		= false;
			TXT_APPR_REMARK.ReadOnly	= true;
			TXT_APPR_ATASNAMA.ReadOnly	= true;
		}

		private void BackToList() 
		{
			Session.Add("tc", Request.QueryString["tc"]);
			Session.Add("mc", Request.QueryString["mc"]);
			
			string link = "ListAppraisal.aspx?tc=" + Request.QueryString["tc"] + "&mc=" + Request.QueryString["mc"];
			Response.Write("<form name='Form1' action='"+link+"' target='main'");
			Response.Write("");
			Response.Write("</form>");
			Response.Write("<script language='javascript'>alert('Update Successful!');");
			Response.Write("document.Form2.submit();</script>");			
		}

		private void BackToList2() 
		{
			Session.Add("tc", Request.QueryString["tc"]);
			Session.Add("mc", Request.QueryString["mc"]);
			
			string link = "ListAppraisal.aspx?tc=" + Request.QueryString["tc"] + "&mc=" + Request.QueryString["mc"];
			Response.Write("<form name='Form2' action='"+link+"' target='main'");
			Response.Write("");
			Response.Write("</form>");
			Response.Write("<script language='javascript'>alert('Collateral is returned!');");
			Response.Write("document.Form2.submit();</script>");			
		}

		/// <summary>
		/// Menghapus file hasil upload
		/// </summary>
		/// <param name="directory">directory yang menyimpan file</param>
		/// <param name="filename">nama file saja</param>
		private void deleteFile(string directory, string filename) 
		{
			if (File.Exists(directory + filename)) 
			{
				File.Delete(directory + filename);
			}
		}
		#endregion

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
			this.DatGrid.ItemCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.DatGrid_ItemCommand);

		}
		#endregion

		protected void BTN_SAVE_Click(object sender, System.EventArgs e)
		{
			double APPR_VALUE			= double.Parse(TXT_APPR_VALUE.Text), 
				   APPR_AFTERSMVALUE	= double.Parse(TXT_APPR_AFTERSMVALUE.Text);
			bool CERDATE = true, EXPDATE = true;

			if (TXT_APPR_SERFDATE_DAY.Text.Trim() == "" && TXT_APPR_SERFDATE_YEAR.Text.Trim() == "" && DDL_APPR_SERFDATE_MONTH.SelectedValue.Trim() == "")
				CERDATE = false;

			if (TXT_APPR_SERFEXPDATE_DAY.Text == "" && TXT_APPR_SERFEXPDATE_YEAR.Text == "" && DDL_APPR_SERFEXPDATE_MONTH.SelectedValue == "")
				EXPDATE = false;
			
			if (APPR_VALUE < APPR_AFTERSMVALUE)
				Tools.popMessage(this,"Nilai Pasar After Safety Margin tidak boleh lebih besar dari Nilai Pasar!!");

			else if (!Tools.isDateValid(this,TXT_APPR_DATE_DAY.Text, DDL_APPR_DATE_MONTH.SelectedValue, TXT_APPR_DATE_YEAR.Text))
			{
				Tools.popMessage(this, "Tanggal Appraisal tidak valid!");
				return;
			}
			else if (CERDATE && !Tools.isDateValid(this,TXT_APPR_SERFDATE_DAY.Text, DDL_APPR_SERFDATE_MONTH.SelectedValue, TXT_APPR_SERFDATE_YEAR.Text))
			{
				Tools.popMessage(this, "Tanggal Penerbitan Sertifikat/Surat tidak valid!");
				return;
			}
			else if (EXPDATE && !Tools.isDateValid(this,TXT_APPR_SERFEXPDATE_DAY.Text, DDL_APPR_SERFEXPDATE_MONTH.SelectedValue, TXT_APPR_SERFEXPDATE_YEAR.Text))
			{
				Tools.popMessage(this, "Tanggal Kadaluarsa Sertifikat tidak valid!");
				return;
			}
			else
			{
				conn.QueryString = "exec APPRAISAL_ENTRYRESULT 'Save','" +LBL_REGNO.Text+ "', '" +LBL_CUREF.Text+ "', '"+LBL_CL_SEQ.Text+"', '"+TXT_APPR_PEMERIKSA.Text+"', "+
					tool.ConvertDate(TXT_APPR_DATE_DAY.Text,DDL_APPR_DATE_MONTH.SelectedValue,TXT_APPR_DATE_YEAR.Text)+", '" +TXT_APPR_NAME.Text+ "', '"+
					TXT_APPR_ADDR.Text+"', '" +DDL_APPR_IKATCODE.SelectedValue+ "', '" +DDL_CERTTYPEID.SelectedValue+ "', '"+TXT_APPR_NOSERTIFIKAT.Text+"', "+
					tool.ConvertDate(TXT_APPR_SERFDATE_DAY.Text,DDL_APPR_SERFDATE_MONTH.SelectedValue,TXT_APPR_SERFDATE_YEAR.Text)+", " +tool.ConvertDate(TXT_APPR_SERFEXPDATE_DAY.Text,DDL_APPR_SERFEXPDATE_MONTH.SelectedValue,TXT_APPR_SERFEXPDATE_YEAR.Text)+
					", " +tool.ConvertFloat(TXT_APPR_VALUE.Text)+ ", " +tool.ConvertFloat(TXT_APPR_SAFETYMARGIN.Text)+ ", "+tool.ConvertFloat(TXT_APPR_AFTERSMVALUE.Text)+ ", '" +DDL_APPR_MRCODE.SelectedValue+ "', '" +DDL_APPR_PMCODE.SelectedValue+ "', '" +
					DDL_APPR_IKSCODE.SelectedValue+ "', '"+DDL_APPR_KUCODE.SelectedValue+"', '" +TXT_APPR_REMARK.Text+ "', '"+TXT_APPR_ATASNAMA.Text+"' ";
				conn.ExecuteQuery();
				ViewData();

				//-----------------------------------------------------------------simpan ke APPR_LIST
				conn.QueryString = "EXEC SP_APPR_LIST 'Save','" + LBL_REGNO.Text + "','" + LBL_CUREF.Text + "','" + 
					LBL_CL_SEQ.Text + "','9','Standar'";
				conn.ExecuteNonQuery();

				//-----------------------------------------------------------------refresh parent
				Response.Write("<script language='javascript'> " +
					"parent.document.Form1.action = 'InfoUmum.aspx?regno=" + LBL_REGNO.Text + "&curef=" + LBL_CUREF.Text + "&cl_seq=" + LBL_CL_SEQ.Text + "&tc=" + lbl_TC.Text + "&mc=" + lbl_MC.Text + "';" +
					"parent.document.Form1.submit();</script>");

			}
		}

		protected void BTN_UPDATE_Click(object sender, System.EventArgs e)
		{
			double APPR_VALUE			= double.Parse(TXT_APPR_VALUE.Text), 
				   APPR_AFTERSMVALUE	= double.Parse(TXT_APPR_AFTERSMVALUE.Text);
			bool CERDATE = true, EXPDATE = true;

			if (TXT_APPR_SERFDATE_DAY.Text.Trim() == "" && TXT_APPR_SERFDATE_YEAR.Text.Trim() == "" && DDL_APPR_SERFDATE_MONTH.SelectedValue.Trim() == "")
				CERDATE = false;

			if (TXT_APPR_SERFEXPDATE_DAY.Text == "" && TXT_APPR_SERFEXPDATE_YEAR.Text == "" && DDL_APPR_SERFEXPDATE_MONTH.SelectedValue == "")
				EXPDATE = false;

			if (APPR_VALUE < APPR_AFTERSMVALUE)
				Tools.popMessage(this,"Nilai Pasar After Safety Margin tidak boleh lebih besar dari Nilai Pasar!!");
			/*
			else if (!Tools.isDateValid(this,TXT_APPR_DATE_DAY.Text, DDL_APPR_DATE_MONTH.SelectedValue, TXT_APPR_DATE_YEAR.Text))
			{
				Tools.popMessage(this, "Tanggal Appraisal tidak valid!");
				return;
			}
			else if (! Tools.isDateValid(this,TXT_APPR_SERFDATE_DAY.Text, DDL_APPR_SERFDATE_MONTH.SelectedValue, TXT_APPR_SERFDATE_YEAR.Text))
			{
				Tools.popMessage(this, "Tanggal Penerbitan Sertifikat/Surat tidak valid!");
				return;
			}
			else if (! Tools.isDateValid(this,TXT_APPR_SERFEXPDATE_DAY.Text, DDL_APPR_SERFEXPDATE_MONTH.SelectedValue, TXT_APPR_SERFEXPDATE_YEAR.Text))
			{
				Tools.popMessage(this, "Tanggal Kadaluarsa Sertifikat tidak valid!");
				return;
			}
			*/
			else if (!Tools.isDateValid(this,TXT_APPR_DATE_DAY.Text, DDL_APPR_DATE_MONTH.SelectedValue, TXT_APPR_DATE_YEAR.Text))
			{
				Tools.popMessage(this, "Tanggal Appraisal tidak valid!");
				return;
			}
			else if (CERDATE && !Tools.isDateValid(this,TXT_APPR_SERFDATE_DAY.Text, DDL_APPR_SERFDATE_MONTH.SelectedValue, TXT_APPR_SERFDATE_YEAR.Text))
			{
				Tools.popMessage(this, "Tanggal Penerbitan Sertifikat/Surat tidak valid!");
				return;
			}
			else if (EXPDATE && !Tools.isDateValid(this,TXT_APPR_SERFEXPDATE_DAY.Text, DDL_APPR_SERFEXPDATE_MONTH.SelectedValue, TXT_APPR_SERFEXPDATE_YEAR.Text))
			{
				Tools.popMessage(this, "Tanggal Kadaluarsa Sertifikat tidak valid!");
				return;
			}
			else
			{
				//simpan data
				conn.QueryString = "exec APPRAISAL_ENTRYRESULT 'Save','" +LBL_REGNO.Text+ "', '" +LBL_CUREF.Text+ "', "+LBL_CL_SEQ.Text+", '"+TXT_APPR_PEMERIKSA.Text+"', "+
					tool.ConvertDate(TXT_APPR_DATE_DAY.Text,DDL_APPR_DATE_MONTH.SelectedValue,TXT_APPR_DATE_YEAR.Text)+", '" +TXT_APPR_NAME.Text+ "', '"+
					TXT_APPR_ADDR.Text+"', '" +DDL_APPR_IKATCODE.SelectedValue+ "', '" +DDL_CERTTYPEID.SelectedValue+ "', '"+TXT_APPR_NOSERTIFIKAT.Text+"', "+
					tool.ConvertDate(TXT_APPR_SERFDATE_DAY.Text,DDL_APPR_SERFDATE_MONTH.SelectedValue,TXT_APPR_SERFDATE_YEAR.Text)+", " +tool.ConvertDate(TXT_APPR_SERFEXPDATE_DAY.Text,DDL_APPR_SERFEXPDATE_MONTH.SelectedValue,TXT_APPR_SERFEXPDATE_YEAR.Text)+
					", " +tool.ConvertFloat(TXT_APPR_VALUE.Text)+ ", " +tool.ConvertFloat(TXT_APPR_SAFETYMARGIN.Text)+ ", "+tool.ConvertFloat(TXT_APPR_AFTERSMVALUE.Text)+ ", '" +DDL_APPR_MRCODE.SelectedValue+ "', '" +DDL_APPR_PMCODE.SelectedValue+ "', '" +
					DDL_APPR_IKSCODE.SelectedValue+ "', '"+DDL_APPR_KUCODE.SelectedValue+"', '" +TXT_APPR_REMARK.Text+ "', '"+TXT_APPR_ATASNAMA.Text+"' ";
				conn.ExecuteQuery();

				//-----------------------------------------------------------------simpan ke APPR_LIST
				conn.QueryString = "EXEC SP_APPR_LIST 'Save','" + LBL_REGNO.Text + "','" + LBL_CUREF.Text + "','" + 
					LBL_CL_SEQ.Text + "','9','Standar'";
				conn.ExecuteNonQuery();

				//-----------------------------------------------------------------refresh parent
				Response.Write("<script language='javascript'> " +
					"parent.document.Form1.action = 'InfoUmum.aspx?regno=" + LBL_REGNO.Text + "&curef=" + LBL_CUREF.Text + "&cl_seq=" + LBL_CL_SEQ.Text + "&tc=" + lbl_TC.Text + "&mc=" + lbl_MC.Text + "';" +
					"parent.document.Form1.submit();</script>");

				//update status
				string mGROUP = Session["GroupID"].ToString();
				string LA_APPRSTATUS = "", TABLENAME = "";

				//if (mGROUP == Petugas)
				if (isPetugas(mGROUP))
					//LA_APPRSTATUS = "5";
                    LA_APPRSTATUS = "3";
				//else if (mGROUP == CO Manager)
				else // if (!isPetugas(mGROUP))
				{
					LA_APPRSTATUS = "3";
					/*
					conn.QueryString = "select COLLINKTABLE from COLLATERAL cl "+
									   "left join RFCOLLATERALTYPE rf on cl.CL_TYPE = rf.COLTYPESEQ "+
									   "where CU_REF = '"+LBL_CUREF.Text+"' and CL_SEQ = "+LBL_CL_SEQ.Text;
					conn.ExecuteQuery();
					TABLENAME	= conn.GetFieldValue("COLLINKTABLE");
					asdfasdf
					*/
				}
				conn.QueryString = "select COLLINKTABLE from COLLATERAL cl "+
					"left join RFCOLLATERALTYPE rf on cl.CL_TYPE = rf.COLTYPESEQ "+
					"where CU_REF = '"+LBL_CUREF.Text+"' and CL_SEQ = "+LBL_CL_SEQ.Text;
				conn.ExecuteQuery();
				TABLENAME	= conn.GetFieldValue("COLLINKTABLE");

				conn.QueryString = "select count(*) from "+TABLENAME+" where CU_REF = '"+LBL_CUREF.Text+"' and CL_SEQ = "+LBL_CL_SEQ.Text;
				conn.ExecuteQuery();
				string mStat = conn.GetFieldValue(0,0).ToString();

				conn.QueryString = "exec APPRAISAL_UPDATESTATUS '" +LBL_REGNO.Text+ "', '"+LBL_CUREF.Text+"', " +LBL_CL_SEQ.Text+ ", '"+
					LA_APPRSTATUS.ToString()+"', "+ tool.ConvertFloat(TXT_APPR_AFTERSMVALUE.Text)+", "+
					tool.ConvertFloat(TXT_APPR_VALUE.Text)+", '" +TABLENAME.Trim()+ "', '"+mStat.ToString().Trim()+"'";
				conn.ExecuteQuery();

				if (LA_APPRSTATUS == "5")
					BackToList();
				else if (LA_APPRSTATUS == "3")
					ViewData();

				////////////////////////////////////////////////////////////
				/// audit trail
				try
				{
					conn.QueryString = "SP_AUDITTRAIL_APP '" + 
						Request.QueryString["regno"] + "',null,null,null,'" + 
						Request.QueryString["curef"] + "','" + 
						Request.QueryString["tc"] + "','Update status appraisal  ',"+ 
						"null" + ",'" +  
						Session["userid"].ToString() + "',null,null";
					conn.ExecuteNonQuery();
				}
				catch
				{
				}

			}
		}

		protected void BTN_REENTRY_Click(object sender, System.EventArgs e)
		{
			conn.QueryString = "update LISTASSIGNMENT set LA_APPRSTATUS = '2' where AP_REGNO ='" +LBL_REGNO.Text+ "' and CU_REF =  '"+LBL_CUREF.Text
								+"' and CL_SEQ = " +LBL_CL_SEQ.Text;
			conn.ExecuteQuery();
			ViewData();
		}

		private void BTN_INCOMPLETESTATUS_Click(object sender, System.EventArgs e)
		{
			string mGROUP = Session["GroupID"].ToString();
			string LA_APPRSTATUS = "";

			//if (mGROUP == Petugas) 
			if (isPetugas(mGROUP)) 
			{
				//
				//	kalau group yang login adalah petugas
				//
				LA_APPRSTATUS = "6";
			}
			//else if (mGROUP == CO Manager) 
			else if (!isPetugas(mGROUP)) 
			{
				//
				//	kalau group yang login adalah co manager
				//
				LA_APPRSTATUS = "7";
			}
				
			//	set status appraisal untuk incomplete document for appraisal
			conn.QueryString = "exec APPRAISAL_INCOMPLETE '" + 
				LBL_REGNO.Text + "', '" + 
				LBL_CUREF.Text + "', '" + 
				LBL_CL_SEQ.Text + "', '" + 
				LA_APPRSTATUS + "'";
			conn.ExecuteQuery();

			if (LA_APPRSTATUS == "6")
				BackToList2();
			else if (LA_APPRSTATUS == "7")
				ViewData();		
		}

		protected void BTN_DELETE_Click(object sender, System.EventArgs e)
		{
			conn.QueryString = "exec APPRAISAL_ENTRYRESULT 'Delete','" +LBL_REGNO.Text+ "', '" +LBL_CUREF.Text+ "', '"+
				LBL_CL_SEQ.Text+"'"; 
			conn.ExecuteQuery();
			ViewData();

			//-----------------------------------------------------------------simpan ke APPR_LIST
			conn.QueryString = "EXEC SP_APPR_LIST 'Delete','" + LBL_REGNO.Text + "','" + LBL_CUREF.Text + "','" + 
				LBL_CL_SEQ.Text + "','9','Standar'";
			conn.ExecuteNonQuery();

			//-----------------------------------------------------------------refresh parent
			Response.Write("<script language='javascript'> " +
				"parent.document.Form1.action = 'InfoUmum.aspx?regno=" + LBL_REGNO.Text + "&curef=" + LBL_CUREF.Text + "&cl_seq=" + LBL_CL_SEQ.Text + "&tc=" + lbl_TC.Text + "&mc=" + lbl_MC.Text + "';" +
				"parent.document.Form1.submit();</script>");

		}

		protected void BTN_UPLOAD_Click(object sender, System.EventArgs e)
		{
			string path, mStatus = string.Empty, mStatusReport = string.Empty;
			conn.QueryString = "select APP_ROOT, CREDANALYSIS_DIR from APP_PARAMETER";
			conn.ExecuteQuery();
			path = conn.GetFieldValue("APP_ROOT").ToString().Trim()+ conn.GetFieldValue("CREDANALYSIS_DIR").ToString().Trim();
 
			HttpFileCollection uploadedFiles = Request.Files;
			
			int counter = 0, mField = 0;
			LBL_STATUS.Text = string.Empty;
			LBL_STATUSREPORT.Text = string.Empty;
			for (int i = 0; i < uploadedFiles.Count; i++)
			{
				HttpPostedFile userPostedFile = uploadedFiles[i];
				counter = i + 1;
				try
				{
					if (userPostedFile.ContentLength > 0)
					{
						userPostedFile.SaveAs(path + Request.QueryString["regno"].Trim() + "-"+Session["USERID"].ToString()+"-" + Path.GetFileName(userPostedFile.FileName));
						LBL_STATUS.ForeColor = Color.Black;
						LBL_STATUSREPORT.ForeColor = Color.Black;
						mStatus = "Upload Successful!";
						mStatusReport = "<u>File #" + counter.ToString() + "</u><br>" + 
							"File Content Type: " + userPostedFile.ContentType + "<br>" + 
							"File Size: " + userPostedFile.ContentLength + "kb<br>" + 
							"File Name: " + userPostedFile.FileName + "<br>";
						mStatusReport += "Location Where Saved: " + path + Request.QueryString["regno"].Trim() + "-"+Session["USERID"].ToString()+"-" + Path.GetFileName(userPostedFile.FileName) + "<p>";

						int lket = Request.QueryString["regno"].Trim().Length + Session["USERID"].ToString().Trim().Length + 2;
						conn.QueryString = "select FU_FILENAME from FILE_UPLOAD where AP_REGNO = '" +Request.QueryString["regno"]+ "' and FU_USERID = '"+Session["USERID"].ToString()+"'";
						conn.ExecuteQuery();
						for (int j = 0; j < conn.GetRowCount(); j++)
						{
							string fileNameDB = conn.GetFieldValue(j,0).Substring(lket, conn.GetFieldValue(j,0).Trim().Length - lket);
							if (fileNameDB.Trim() == Path.GetFileName(userPostedFile.FileName).Trim())
							{
								mField = mField + 1;
							}
						}


						if (mField == 0)
						{
							conn.QueryString = "exec CA_FILE_UPLOAD '" +Request.QueryString["regno"]+ "', '', '" +Request.QueryString["regno"].Trim() +
								"-"+Session["USERID"].ToString()+"-" + Path.GetFileName(userPostedFile.FileName)+ "', '" +Session["USERID"].ToString()+ "', '1'";
							conn.ExecuteNonQuery();
							ViewFileUpload();
						}
					}
				}

				catch (Exception ex)
				{
					LBL_STATUS.ForeColor = Color.Red;
					LBL_STATUSREPORT.ForeColor = Color.Red;
					mStatus		  = "Error Uploading File";
					mStatusReport = ex.ToString();
				}
				
				LBL_STATUS.Text			= mStatus.Trim();
				LBL_STATUSREPORT.Text	= mStatusReport.Trim();
			}
		}

		private void DatGrid_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			switch (((LinkButton)e.CommandSource).CommandName)
			{
				case "delete":
					/// Function delete file fisik
					/// 
					try 
					{					
						string directory = @"C:\";
						conn.QueryString = "select APP_ROOT + CREDANALYSIS_DIR as FULLPATH from APP_PARAMETER";
						conn.ExecuteQuery();
						directory = conn.GetFieldValue("FULLPATH");						

						deleteFile(directory, e.Item.Cells[2].Text);
						Response.Write("<!-- file : " + directory + e.Item.Cells[2].Text + " -->");
						Response.Write("<!-- file is deleted. -->");
					} 
					catch (Exception ex) 
					{
						Response.Write("<!-- Delete File Error: " + ex.Message.ToString() + " -->");
					}


					conn.QueryString = "exec CA_FILE_UPLOAD '" +Request.QueryString["regno"]+ "', '" +e.Item.Cells[0].Text+ "','','','2'";
					conn.ExecuteNonQuery();
					ViewFileUpload();					
					break;
			}

		}


	}
}
