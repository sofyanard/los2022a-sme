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
using System.IO;
using System.Diagnostics;
using Microsoft.VisualBasic;
using DMS.CuBESCore;
using DMS.DBConnection;

namespace SME.Appraisal
{
	/// <summary>
	/// Summary description for AppraisalNew.
	/// </summary>
	public partial class AppraisalNew : System.Web.UI.Page
	{

		protected Connection conn;
		protected Tools tool = new Tools();
        private SMEExportImport.WordClient client;
        
		protected void Page_Load(object sender, System.EventArgs e)
		{

			//tr1.Visible = false;
			conn = (Connection) Session["Connection"];
            client = new SMEExportImport.WordClient();

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
				DDL_CL_CURRENCY.Items.Add(new ListItem("- SELECT -", ""));
				DDL_CL_COLLOC.Items.Add(new ListItem("- SELECT -", ""));
				DDL_CL_VALACCRDTO.Items.Add(new ListItem("- SELECT -", ""));
				DDL_CL_JNSAGUNAN.Items.Add(new ListItem("- SELECT -", ""));
				DDL_APPR_MRCODE.Items.Add(new ListItem("- SELECT -", ""));
				DDL_APPR_IKSCODE.Items.Add(new ListItem("- SELECT -", ""));
				DDL_APPR_KUCODE.Items.Add(new ListItem("- SELECT -", ""));
				DDL_APPR_PMCODE.Items.Add(new ListItem("- SELECT -", ""));

				for (int i = 1; i <= 12; i++)
				{
					DDL_APPR_DATE_MONTH.Items.Add(new ListItem(DateAndTime.MonthName(i, false), i.ToString()));
				}

				//--- Currency
				conn.QueryString = "select CURRENCYID, CURRENCYID + ' - ' + CURRENCYDESC as CURRENCYDESC from RFCURRENCY where ACTIVE = '1' order by CURRENCYID";
				conn.ExecuteQuery();
				for (int i=0; i< conn.GetRowCount(); i++)
					DDL_CL_CURRENCY.Items.Add(new ListItem(conn.GetFieldValue(i, 1), conn.GetFieldValue(i, 0)));

				//--- Lokasi Agunan
				conn.QueryString = "select LOCATIONID, LOCATIONID+' - '+LOCATIONDESC as LOCATIONDESC from RFCOLLOCATION where ACTIVE='1' order by LOCATIONID";
				conn.ExecuteQuery();
				for (int i=0; i< conn.GetRowCount(); i++)
					DDL_CL_COLLOC.Items.Add(new ListItem(conn.GetFieldValue(i, 1), conn.GetFieldValue(i, 0)));

				//--- Penilaian Menurut
				conn.QueryString = "select ACCRDTOID, ACCRDTODESC from RFVALUEACCORDING where active='1'";
				conn.ExecuteQuery();
				for (int i=0; i< conn.GetRowCount(); i++)
					DDL_CL_VALACCRDTO.Items.Add(new ListItem(conn.GetFieldValue(i, 1), conn.GetFieldValue(i, 0)));

				//--- Jenis Agunan
				conn.QueryString = "select AGUNANID, AGUNANID + ' - ' + AGUNANDESC AS AGUNANDESC from RFJENISAGUNAN WHERE ACTIVE='1' order by AGUNANID";
				conn.ExecuteQuery();
				for (int i=0; i< conn.GetRowCount(); i++)
					DDL_CL_JNSAGUNAN.Items.Add(new ListItem(conn.GetFieldValue(i, 1), conn.GetFieldValue(i, 0)));

				//--- Marketability
				conn.QueryString = "select * from RF_APPR_MARKETABILITY where ACTIVE = '1'";
				conn.ExecuteQuery();
				for (int i = 0; i < conn.GetRowCount(); i++)
					DDL_APPR_MRCODE.Items.Add(new ListItem(conn.GetFieldValue(i,1), conn.GetFieldValue(i,0)));

				//--- Pengikatan Sempurna
				conn.QueryString = "select * from RF_APPR_IKATSEMPURNA where ACTIVE = '1'";
				conn.ExecuteQuery();
				for (int i = 0; i < conn.GetRowCount(); i++)
					DDL_APPR_IKSCODE.Items.Add(new ListItem(conn.GetFieldValue(i,1), conn.GetFieldValue(i,0)));

				//--- Penguasaan
				conn.QueryString = "select * from RF_APPR_KUASA where ACTIVE = '1'";
				conn.ExecuteQuery();
				for (int i = 0; i < conn.GetRowCount(); i++)
					DDL_APPR_KUCODE.Items.Add(new ListItem(conn.GetFieldValue(i,1), conn.GetFieldValue(i,0)));

				//--- Permasalahan
				conn.QueryString = "select * from RF_APPR_MASALAH where ACTIVE = '1'";
				conn.ExecuteQuery();
				for (int i = 0; i < conn.GetRowCount(); i++)
					DDL_APPR_PMCODE.Items.Add(new ListItem(conn.GetFieldValue(i,1), conn.GetFieldValue(i,0)));

				ViewData();
				ViewTemplateFiles();
				ViewUploadFiles();
			}

            BTN_SAVE.Attributes.Add("onclick", "if(!cek_mandatory(document.getElementById('Form1'))){return false;};");
            BTN_UPDATE.Attributes.Add("onclick", "if(!cek_mandatory(document.getElementById('Form1'))){return false;}; if(!update()){return false;};");
			BTN_REENTRY.Attributes.Add("onclick","if(!update()){return false;};");
		}

		private void ViewData()
		{
			conn.QueryString = " select * from VW_APPRAISAL_RESULT_NEW where AP_REGNO = '" +LBL_REGNO.Text+
				"' and CU_REF = '" +LBL_CUREF.Text+ "' and CL_SEQ = "+LBL_CL_SEQ.Text;
			conn.ExecuteQuery();
			
			TXT_AGENCY.Text				= conn.GetFieldValue("APPR_AGENCYNAME");
			TXT_APPR_PEMERIKSA.Text		= conn.GetFieldValue("APPR_OFFICERNAME");

			try
			{
				TXT_APPR_DATE_DAY.Text		= tool.FormatDate_Day(conn.GetFieldValue("APPR_DATE"));
				DDL_APPR_DATE_MONTH.SelectedValue	= tool.FormatDate_Month(conn.GetFieldValue("APPR_DATE"));
				TXT_APPR_DATE_YEAR.Text		= tool.FormatDate_Year(conn.GetFieldValue("APPR_DATE"));
			}
			catch {}

			TXT_COL_DESC.Text = conn.GetFieldValue("CL_DESC");
			TXT_COL_ID.Text = conn.GetFieldValue("SIBS_COLID");

			try {DDL_CL_CURRENCY.SelectedValue = conn.GetFieldValue("APPR_CURRENCYID");}
			catch {}
			try {DDL_CL_COLLOC.SelectedValue = conn.GetFieldValue("APPR_LOCATIONID");}
			catch {}
			try {DDL_CL_VALACCRDTO.SelectedValue = conn.GetFieldValue("APPR_VALUEACCORDINGID");}
			catch {}
			try {DDL_CL_JNSAGUNAN.SelectedValue = conn.GetFieldValue("APPR_JENISAGUNANID");}
			catch {}

			TXT_VALUE_BANK.Text			= tool.MoneyFormat(conn.GetFieldValue("APPR_VALUEBANK"));
			TXT_VALUE_PASAR.Text		= tool.MoneyFormat(conn.GetFieldValue("APPR_VALUEPASAR"));
			TXT_VALUE_LIKUIDASI.Text	= tool.MoneyFormat(conn.GetFieldValue("APPR_VALUELIKUIDASI"));
			TXT_APPR_SAFETYMARGIN.Text	= tool.MoneyFormat(conn.GetFieldValue("APPR_SAFETYMARGIN"));
			TXT_SCORE.Text				= tool.MoneyFormat(conn.GetFieldValue("APPR_SCORE"));

			try {DDL_APPR_MRCODE.SelectedValue = conn.GetFieldValue("APPR_MRCODE");}
			catch {}
			try {DDL_APPR_IKSCODE.SelectedValue = conn.GetFieldValue("APPR_IKSCODE");}
			catch {}
			try {DDL_APPR_KUCODE.SelectedValue = conn.GetFieldValue("APPR_KUCODE");}
			catch {}
			try {DDL_APPR_PMCODE.SelectedValue = conn.GetFieldValue("APPR_PMCODE");}
			catch {}

			string LA_APPRSTATUS = conn.GetFieldValue("LA_APPRSTATUS");
			string OFFICERSEQ	 = conn.GetFieldValue("OFFICERSEQ");
			
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

				lbl_ISDELETE.Text = "Y";

				//BTN_INCOMPLETESTATUS.Visible = false;
				
				DisabledEntry();
			}
			else if (STSTOMBOL == "2")
			{
				BTN_SAVE.Visible	= false;				
				BTN_REENTRY.Visible	= true;
				BTN_DELETE.Visible = false;
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
			TXT_APPR_DATE_DAY.ReadOnly	= true;
			DDL_APPR_DATE_MONTH.Enabled = false;
			TXT_APPR_DATE_YEAR.ReadOnly = true;
			DDL_CL_CURRENCY.Enabled = false;
			DDL_CL_COLLOC.Enabled = false;
			DDL_CL_VALACCRDTO.Enabled = false;
			DDL_CL_JNSAGUNAN.Enabled = false;
			TXT_VALUE_BANK.ReadOnly = true;
			TXT_VALUE_PASAR.ReadOnly = true;
			TXT_VALUE_LIKUIDASI.ReadOnly = true;
			TXT_APPR_SAFETYMARGIN.ReadOnly = true;
			TXT_SCORE.ReadOnly = true;
			DDL_APPR_MRCODE.Enabled		= false;
			DDL_APPR_PMCODE.Enabled		= false;
			DDL_APPR_IKSCODE.Enabled	= false;
			DDL_APPR_KUCODE.Enabled		= false;
		}

		private bool isPetugas(string groupid)
		{
			bool petugas = false;

			conn.QueryString = "select groupid from scgroup where sg_grpupliner = '" + groupid + "'";
			conn.ExecuteQuery();
			
			if (conn.GetRowCount() == 0) petugas = true;

			return petugas;
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

		private void SaveData()
		{
			double valbank = double.Parse(TXT_VALUE_BANK.Text);
			double valpasar = double.Parse(TXT_VALUE_PASAR.Text);
			double valliq = double.Parse(TXT_VALUE_LIKUIDASI.Text);

			if (!Tools.isDateValid(this,TXT_APPR_DATE_DAY.Text, DDL_APPR_DATE_MONTH.SelectedValue, TXT_APPR_DATE_YEAR.Text))
			{
				Tools.popMessage(this, "Tanggal Penilaian tidak valid!");
				return;
			}

			if (valpasar < valliq)
			{
				Tools.popMessage(this,"Nilai Likuidasi tidak boleh lebih besar dari Nilai Pasar!!");
				return;
			}

			try
			{
				conn.QueryString = "EXEC APPRAISAL_ENTRYRESULT_NEW '1', '" +
					LBL_REGNO.Text + "', '" + 
					LBL_CUREF.Text + "', '" + 
					LBL_CL_SEQ.Text + "', " + 
					tool.ConvertDate(TXT_APPR_DATE_DAY.Text,DDL_APPR_DATE_MONTH.SelectedValue,TXT_APPR_DATE_YEAR.Text) + ", '" + 
					DDL_CL_CURRENCY.SelectedValue + "', '" + 
					DDL_CL_COLLOC.SelectedValue + "', '" + 
					DDL_CL_VALACCRDTO.SelectedValue + "', '" + 
					DDL_CL_JNSAGUNAN.SelectedValue + "', " + 
					tool.ConvertFloat(TXT_VALUE_BANK.Text) + ", " + 
					tool.ConvertFloat(TXT_VALUE_PASAR.Text) + ", " + 
					tool.ConvertFloat(TXT_VALUE_LIKUIDASI.Text) + ", " + 
					tool.ConvertFloat(TXT_APPR_SAFETYMARGIN.Text) + ", " + 
					tool.ConvertFloat(TXT_SCORE.Text) + ", '" + 
					DDL_APPR_MRCODE.SelectedValue + "', '" + 
					DDL_APPR_IKSCODE.SelectedValue + "', '" + 
					DDL_APPR_KUCODE.SelectedValue + "', '" + 
					DDL_APPR_PMCODE.SelectedValue + "'";
				conn.ExecuteQuery();
				ViewData();

				//-----------------------------------------------------------------simpan ke APPR_LIST
				conn.QueryString = "EXEC SP_APPR_LIST 'Save','" + LBL_REGNO.Text + "','" + LBL_CUREF.Text + "','" + 
					LBL_CL_SEQ.Text + "','10','Standar New'";
				conn.ExecuteNonQuery();

				//-----------------------------------------------------------------refresh parent
				Response.Write("<script language='javascript'> " +
					"parent.document.Form1.action = 'InfoUmum.aspx?regno=" + LBL_REGNO.Text + "&curef=" + LBL_CUREF.Text + "&cl_seq=" + LBL_CL_SEQ.Text + "&tc=" + lbl_TC.Text + "&mc=" + lbl_MC.Text + "';" +
					"parent.document.Form1.submit();</script>");
			}
			catch (Exception ex)
			{
				string errmsg = ex.Message.Replace("'","");
				if (errmsg.IndexOf("Last Query:") > 0)
					errmsg = errmsg.Substring(0, errmsg.IndexOf("Last Query:"));
				GlobalTools.popMessage(this, errmsg);
				return;
			}
		}

		private void ViewTemplateFiles()
		{
			System.Data.DataTable dt = new System.Data.DataTable();
			conn.QueryString = "SELECT * FROM VW_APPRAISALNEW_VIEWFILETEMPLATE ORDER BY SEQ";
			conn.ExecuteQuery();
			dt = conn.GetDataTable().Copy();
			DG_TEMPLATE.DataSource = dt;
			try 
			{
				DG_TEMPLATE.DataBind();
			} 
			catch 
			{
				DG_TEMPLATE.CurrentPageIndex = 0;
				DG_TEMPLATE.DataBind();
			}
			for (int i = 1; i <= DG_TEMPLATE.Items.Count; i++)
			{
				HyperLink HpDownload = (HyperLink) DG_TEMPLATE.Items[i-1].Cells[2].FindControl("HP_DOWNLOAD");
				HpDownload.NavigateUrl = DG_TEMPLATE.Items[i-1].Cells[5].Text.Trim();
			}
		}

		private void ViewUploadFiles()
		{
			System.Data.DataTable dt = new System.Data.DataTable();

			conn.QueryString = "SELECT * FROM VW_APPRAISALNEW_VIEWFILEUPLOAD WHERE AP_REGNO = '" + LBL_REGNO.Text + 
				"' AND CU_REF = '" + LBL_CUREF.Text + "' AND CL_SEQ = '" + LBL_CL_SEQ.Text + "'";
			conn.ExecuteQuery();
			dt = conn.GetDataTable().Copy();
			DG_UPLOAD.DataSource = dt;
			try 
			{
				DG_UPLOAD.DataBind();
			} 
			catch 
			{
				DG_UPLOAD.CurrentPageIndex = 0;
				DG_UPLOAD.DataBind();
			}
			for (int i = 1; i <= DG_UPLOAD.Items.Count; i++)
			{
				HyperLink HpDownload = (HyperLink) DG_UPLOAD.Items[i-1].Cells[6].FindControl("FU_DOWNLOAD");
				LinkButton HpDelete = (LinkButton) DG_UPLOAD.Items[i-1].Cells[7].FindControl("FU_DELETE");
				HpDownload.NavigateUrl = DG_UPLOAD.Items[i-1].Cells[8].Text.Trim();
				if (Session["UserID"].ToString().Trim() != DG_UPLOAD.Items[i-1].Cells[4].Text)
					HpDelete.Visible	= false;
			}
		}

		private void deleteFile(string directory, string filename) 
		{
			if (File.Exists(directory + filename)) 
			{
				File.Delete(directory + filename);
			}
		}

		private void UploadFile()
		{
			string directory;
			int counter = 0;
			string templateid, outputfilename, initfilename;
			
			//Get Export Properties
			conn.QueryString = "SELECT TOP 1 * FROM VW_APPRAISALNEW_DOCUPLOAD_PARAMETER ";
			conn.ExecuteQuery();

			if (conn.GetRowCount() > 0)
			{
				directory = Server.MapPath(conn.GetFieldValue("UPLOAD_PATH").Trim());
				templateid = conn.GetFieldValue("TEMPLATE_ID");
				initfilename = conn.GetFieldValue("UPLOAD_FILEFORMAT");

				HttpFileCollection uploadedFiles = Request.Files;

				for (int i = 0; i < uploadedFiles.Count; i++)
				{
					HttpPostedFile userPostedFile = uploadedFiles[i];
					counter = i + 1;

					try
					{
						if (userPostedFile.ContentLength > 0)
						{
							outputfilename = conn.GetFieldValue("UPLOAD_FILEFORMAT").Replace("#REGNO$",LBL_REGNO.Text).Replace("#CUREF$",LBL_CUREF.Text).Replace("#CLSEQ$",LBL_CL_SEQ.Text).Replace("#USERID$",Session["UserID"].ToString()) + "-" + Path.GetFileName(userPostedFile.FileName);
							userPostedFile.SaveAs(directory + outputfilename);

							LBL_STATUS.ForeColor = Color.Green;
							LBL_STATUSREPORT.ForeColor = Color.Green;
							LBL_STATUS.Text = "Upload Successful!";
							LBL_STATUSREPORT.Text = "<u>File #" + counter.ToString() + "</u><br>" + 
								"File Content Type: " + userPostedFile.ContentType + "<br>" + 
								"File Size: " + userPostedFile.ContentLength + " bytes<br>" + 
								"File Name: " + userPostedFile.FileName + "<br>" +
								"Location Where Saved: " + directory + outputfilename + "<p>";

							//Save to Table
							conn.QueryString = "EXEC APPRAISALNEW_DOCUPLOAD_SAVE '1', '" + 
								LBL_REGNO.Text + "', '" + LBL_CUREF.Text + "', '" + LBL_CL_SEQ.Text + "', '', '" + 
								Session["UserID"].ToString().Trim() + "', '" + 
								outputfilename + "'";
							conn.ExecuteQuery();

							//View Upload File
							ViewUploadFiles();

							//Read from Excel
							try
							{
								//ReadExcel(directory + outputfilename, templateid);
                                client.AppraisalNewASPXReadExcel(directory + outputfilename, templateid, LBL_REGNO.Text, LBL_CUREF.Text, LBL_CL_SEQ.Text);
							}
							catch {}
						}
					}
					catch (Exception ex)
					{
						LBL_STATUS.ForeColor = Color.Red;
						LBL_STATUSREPORT.ForeColor = Color.Red;
						LBL_STATUS.Text = "Upload Failed!";
						LBL_STATUSREPORT.Text = ex.Message + "\n" + ex.StackTrace;
					}
				}
			}
		}

		private void ReadExcel(string filename, string templateid)
		{
			Excel.Application excelApp = null;
			Excel.Workbook excelWorkBook = null;
			Excel.Sheets excelSheet = null;

			ArrayList orgId = new ArrayList();
			ArrayList newId = new ArrayList();

			Process[] oldProcess = Process.GetProcessesByName("EXCEL");
			foreach(Process thisProcess in oldProcess) orgId.Add(thisProcess);

			DataTable dt1, dt2;

			try
			{
				System.Threading.Thread.CurrentThread.CurrentCulture = System.Globalization.CultureInfo.CreateSpecificCulture("en-US");
				System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("en-US");

				excelApp = new Excel.ApplicationClass();
				excelApp.Visible = false;
				excelApp.DisplayAlerts = false;

				Process[] newProcess = Process.GetProcessesByName("EXCEL");
				foreach(Process thisProcess in newProcess) newId.Add(thisProcess);

				//Save process into database
				//SupportTools.saveProcessExcel(excelApp, newId, orgId, conn);

				excelWorkBook = excelApp.Workbooks.Open(filename,
					0, false, 5, "", "", true, Excel.XlPlatform.xlWindows, "\t",
					false, false, 0, true);

				excelSheet = excelWorkBook.Worksheets;

				//Loop for Template Master
				conn.QueryString = "SELECT SHEET_ID, SHEET_SEQ, STOREDPROCEDURE FROM APPRAISALNEW_TEMPLATE_MASTER WHERE TEMPLATE_ID = '" + templateid + "'";
				conn.ExecuteQuery();

				dt1 = conn.GetDataTable().Copy();

				if (dt1.Rows.Count > 0)
				{
					for (int i = 0; i < dt1.Rows.Count; i++)
					{
						string sheetid = dt1.Rows[i][0].ToString().Trim();
						string sheetseq = dt1.Rows[i][1].ToString().Trim();
						string proc = dt1.Rows[i][2].ToString().Trim();

						Excel.Worksheet excelWorkSheet = (Excel.Worksheet)excelSheet.get_Item(sheetid);

						//Loop for Template Detail
						conn.QueryString = "SELECT CELL_ROW, CELL_COL, DB_FIELD FROM APPRAISALNEW_TEMPLATE_DETAIL WHERE TEMPLATE_ID = '" + templateid + 
							"' AND SHEET_ID = '" + sheetid + "' AND SHEET_SEQ = '" + sheetseq + "' ORDER BY SEQ";
						conn.ExecuteQuery();
						dt2 = conn.GetDataTable().Copy();
						int n = dt2.Rows.Count;
						object[] par;
						par = new object[n];
						object[] dttype;
						dttype = new object[n];

						if (dt2.Rows.Count > 0)
						{
							for (int j = 0; j < dt2.Rows.Count; j++)
							{
								string xrow = dt2.Rows[j][0].ToString().Trim();
								string xcol = dt2.Rows[j][1].ToString().Trim();
								string datatype = dt2.Rows[j][2].ToString().Trim(); //data type
								string cell_value;
								string xcell = xcol + xrow;

								Excel.Range excelCell = (Excel.Range)excelWorkSheet.get_Range(xcell, xcell);
								if (excelCell != null)
								{
									cell_value = excelCell.Value2.ToString();
									par[j] = (string)cell_value;
									dttype[j] = (string)datatype;
								}
							}

							//Construct Query
							string query = "EXEC " + proc + " '" + LBL_REGNO.Text + "', '" + LBL_CUREF.Text + "', '" + LBL_CL_SEQ.Text + "', ";
							for (int k = 0; k < n; k++)
							{
								if (dttype[k].ToString() == "C")
									query = query + "'" + par[k].ToString() + "'";
								else if (dttype[k].ToString() == "N")
									query = query + "" + par[k].ToString() + "";

								if (k < n-1)
									query = query + ", ";
							}

							//Run Query
							conn.QueryString = query;
							conn.ExecuteQuery();

							//Show Success Message
							LBL_STATUS.ForeColor = Color.Green;
							LBL_STATUSREPORT.ForeColor = Color.Green;
							LBL_STATUS.Text = "Upload Sucessful! Insert Result Sucessful!";
							LBL_STATUSREPORT.Text = "";
						}
					}
				}
			}
			catch (Exception ex)
			{
				/*
				LBL_STATUS.ForeColor = Color.Red;
				LBL_STATUSREPORT.ForeColor = Color.Red;
				LBL_STATUS.Text = "Upload Failed!";
				LBL_STATUSREPORT.Text = ex.Message + "\n" + ex.StackTrace;
				*/
				Response.Write("<!--"+ex.Message + "\n" + ex.StackTrace+"-->");
			}
			finally
			{
				if(excelWorkBook!=null)
				{
					excelWorkBook.Close(true , filename, null);
					excelWorkBook=null;
				}
				if(excelApp!=null)
				{
					excelApp.Workbooks.Close();
					excelApp.Application.Quit();
					excelApp=null;
				}
			}

			try 
			{ 
				for(int x = 0; x < newId.Count; x++)
				{
					Process xnewId = (Process)newId[x];
								
					bool bSameId = false;
					for(int z = 0; z < orgId.Count; z++)
					{
						Process xoldId = (Process)orgId[z];
						
						if(xnewId.Id == xoldId.Id) 
						{
							bSameId = true;
							break;
						}
					}
                    if (!bSameId)
                    {
                        try
                        {
                            xnewId.Kill();
                        }
                        catch (Exception e)
                        {
                            continue;
                        }
                    }
				}
			}
			catch { }
		}

		#region Web Form Designer generated code
		override protected void OnInit(EventArgs e)
		{
			//
			// CODEGEN: This call is required by the ASP.NET Web Form Designer.
			//
			base.OnInit(e);
            if (!this.DesignMode)
            {
                InitializeComponent();
            }
		}
		
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{    
			this.DG_UPLOAD.ItemCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.DG_UPLOAD_ItemCommand);

		}
		#endregion

		protected void BTN_SAVE_Click(object sender, System.EventArgs e)
		{
			SaveData();
		}

		protected void BTN_UPDATE_Click(object sender, System.EventArgs e)
		{
			// Save Data
			SaveData();

			// Update Status
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
				LA_APPRSTATUS.ToString()+"', "+ tool.ConvertFloat(TXT_VALUE_LIKUIDASI.Text)+", "+
				tool.ConvertFloat(TXT_VALUE_PASAR.Text)+", '" +TABLENAME.Trim()+ "', '"+mStat.ToString().Trim()+"'";
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
			catch {}
		}

		protected void BTN_REENTRY_Click(object sender, System.EventArgs e)
		{
			conn.QueryString = "update LISTASSIGNMENT set LA_APPRSTATUS = '2' where AP_REGNO ='" +LBL_REGNO.Text+ "' and CU_REF =  '"+LBL_CUREF.Text
				+"' and CL_SEQ = " +LBL_CL_SEQ.Text;
			conn.ExecuteQuery();
			ViewData();
		}

		protected void BTN_DELETE_Click(object sender, System.EventArgs e)
		{
			conn.QueryString = "exec APPRAISAL_ENTRYRESULT_NEW '2','" +LBL_REGNO.Text+ "', '" +LBL_CUREF.Text+ "', '"+ LBL_CL_SEQ.Text+"'"; 
			conn.ExecuteQuery();
			ViewData();

			//-----------------------------------------------------------------simpan ke APPR_LIST
			conn.QueryString = "EXEC SP_APPR_LIST 'Delete','" + LBL_REGNO.Text + "','" + LBL_CUREF.Text + "','" + 
				LBL_CL_SEQ.Text + "','10','Standar New'";
			conn.ExecuteNonQuery();

			//-----------------------------------------------------------------refresh parent
			Response.Write("<script language='javascript'> " +
				"parent.document.Form1.action = 'InfoUmum.aspx?regno=" + LBL_REGNO.Text + "&curef=" + LBL_CUREF.Text + "&cl_seq=" + LBL_CL_SEQ.Text + "&tc=" + lbl_TC.Text + "&mc=" + lbl_MC.Text + "';" +
				"parent.document.Form1.submit();</script>");
		}

		protected void BTN_UPLOAD_Click(object sender, System.EventArgs e)
		{
			UploadFile();
			ViewData();
		}

		private void DG_UPLOAD_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			switch (((LinkButton)e.CommandSource).CommandName)
			{
				case "delete":
					try 
					{					
						conn.QueryString = "SELECT TOP 1 UPLOAD_PATH FROM VW_APPRAISALNEW_DOCUPLOAD_PARAMETER ";
						conn.ExecuteQuery();

						if (conn.GetRowCount() > 0)
						{
							string directory = Server.MapPath(conn.GetFieldValue("UPLOAD_PATH").Trim());
						
							//Delete File Physically
							deleteFile(directory, e.Item.Cells[4].Text);
							Response.Write("<!-- file : " + directory + e.Item.Cells[4].Text + " -->");
							Response.Write("<!-- file is deleted. -->");

							conn.QueryString = "EXEC APPRAISALNEW_DOCUPLOAD_SAVE '2', '" + 
								e.Item.Cells[0].Text + "', '" + 
								e.Item.Cells[1].Text + "', '" +
								e.Item.Cells[2].Text + "', '" + 
								e.Item.Cells[3].Text + "', '" + 
								Session["UserID"].ToString().Trim() + "', '" + 
								e.Item.Cells[5].Text + "'";
							conn.ExecuteQuery();

							ViewUploadFiles();
						}
					} 
					catch (Exception ex) 
					{
						Response.Write("<!-- Delete File Error: " + ex.Message.ToString() + " -->");
					}
					break;
			}
		}
	}
}
