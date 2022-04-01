using System;
using System.Collections;
using System.ComponentModel;
using System.IO;
using System.Runtime.Remoting;
using System.Diagnostics;
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
using Excel;

namespace SME.CustomerInfo
{
	/// <summary>
	/// Summary description for CustomerInfoExport.
	/// </summary>
	public partial class CustomerInfoExport : System.Web.UI.Page
	{
		protected Connection conn;
		protected Tools tool = new Tools();
        private SMEExportImport.WordClient client;
		string  var_idExport, var_Name;
		string cust_typeid, var_type;

		protected void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			conn = (Connection) Session["Connection"];
            client = new SMEExportImport.WordClient();
			LBL_USER_ID.Text = (string)Session["UserID"];
			LBL_GROUP_ID.Text = (string)Session["GroupID"];
			LBL_BRANCH_ID.Text = (string)Session["BranchID"];
			LBL_CUREF.Text = Request.QueryString["curef"];

			if (!Logic.AllowAccess(Session["GroupID"].ToString(), Request.QueryString["mc"], conn))
				Response.Redirect("/SME/Restricted.aspx");

			//'01022005CBC2000001'
					
			if (!IsPostBack)
			{
				/*
				var_type = "select EXPORT_ID, EXPORT_DESC from RFCUSTEXPORT a " +
					"left join customer c on c.cu_custtypeid= a.custtypeid"+
					" where c.cu_ref ='" + Request.QueryString["curef"] + "'"; 
				*/

				var_type = "select EXPORT_ID, EXPORT_DESC from RFCUSTEXPORT where EXPORT_ID <> 'RORAC'";					
				GlobalTools.fillRefList(DDL_FORMATFILE, var_type, false, conn);
				
				ViewFileExport();
				ViewUploadFiles();
			}
			
			viewMenu();

			DATA_EXPORT.ItemCommand+=new DataGridCommandEventHandler(DATA_EXPORT_ItemCommand);
			
			DDL_FORMATFILE.SelectedIndexChanged += new EventHandler(DDL_FORMATFILE_SelectedIndexChanged);
			BTN_EXPORT.Attributes.Add("onclick", "if(!cek_mandatory(document.Form1)){return false;}; if (!exportInProgress()) { return false; }");

			var_idExport = DDL_FORMATFILE.SelectedValue;
		}

		private void viewMenu() 
		{
			string strtemp = "";
			// View Link dari sub-modul
			try 
			{
				//--- Membuat menu dari DATABASE
				conn.QueryString = "select * from SCREENMENU where menucode = '" + Request.QueryString["mc"] + "'";
				conn.ExecuteQuery();
				for (int i = 0; i < conn.GetRowCount(); i++) 
				{
					HyperLink t = new HyperLink();
					t.Text = conn.GetFieldValue(i, 2);
					t.Font.Bold = true;
					if (conn.GetFieldValue(i, 3).Trim()!= "") 
					{
						if (conn.GetFieldValue(i,3).IndexOf("mc=") >= 0)
							strtemp = "regno=" + Request.QueryString["regno"] + "&curef="+Request.QueryString["curef"]+"&tc="+Request.QueryString["tc"];
						else	strtemp = "regno=" + Request.QueryString["regno"] + "&curef="+Request.QueryString["curef"]+"&mc="+Request.QueryString["mc"]+"&tc="+Request.QueryString["tc"];
					}
					else 
					{
						strtemp = "";
						t.ForeColor = Color.Red; 
					}
					t.NavigateUrl = conn.GetFieldValue(i, 3)+strtemp;
					Menu.Controls.Add(t);
					Menu.Controls.Add(new LiteralControl("&nbsp;&nbsp;&nbsp;"));
				}
			} 
			catch (Exception ex) 
			{
				Response.Write("<!-- Error: " + ex.ToString() + " Trace: " + ex.StackTrace + " -->");
			}
		}

		private void ViewFileExport()
		{
			conn.QueryString = "Select EXPORT_URL from RFCUSTEXPORT where EXPORT_ID = " + tool.ConvertNull(DDL_FORMATFILE.SelectedValue);
			conn.ExecuteQuery();
			
			if (conn.GetRowCount() > 0) 
			{
				string url = conn.GetFieldValue("EXPORT_URL");
			
				System.Data.DataTable dt = new System.Data.DataTable();
				conn.QueryString = "select * from CUST_EXPORT where CU_REF = '"+ Request.QueryString["curef"] + "' and FU_USERID = '" + LBL_USER_ID.Text + "' and EXPORT_ID = " + tool.ConvertNull(DDL_FORMATFILE.SelectedValue);
				conn.ExecuteQuery();
				dt = conn.GetDataTable().Copy();
				DATA_EXPORT.DataSource = dt;
				try 
				{
					DATA_EXPORT.DataBind();
				} 
				catch 
				{
					DATA_EXPORT.CurrentPageIndex = 0;
					DATA_EXPORT.DataBind();
				}


				for (int i = 1; i <= DATA_EXPORT.Items.Count; i++)
				{
					HyperLink HpDownload = (HyperLink) DATA_EXPORT.Items[i-1].Cells[2].FindControl("HL_DOWNLOAD");
					LinkButton HpDelete = (LinkButton) DATA_EXPORT.Items[i-1].Cells[3].FindControl("LB_DELETE");
					HpDownload.NavigateUrl = url + DATA_EXPORT.Items[i-1].Cells[1].Text.Trim();
				}
			}
		}
		
		private string Export_Word()
		{
			System.Data.DataTable dt_field	= null;
			System.Data.DataTable dt_proc	= null;
			
			string fileNm = string.Empty;
			string fileIn = string.Empty;
			string fileOut = string.Empty;
			object objValue = null;
			object objType = Type.Missing;		
			string mStatus = string.Empty;
			
			ArrayList orgId = new ArrayList();
			ArrayList newId = new ArrayList();
			
			/// Mengambil application root
			/// 
			conn.QueryString = "select APP_ROOT from APP_PARAMETER";
			conn.ExecuteQuery();
			string vAPP_ROOT = conn.GetFieldValue("APP_ROOT");	
			
			/// Mengambil nilai parameter
			/// 
			conn.QueryString = " select * from RFCUSTEXPORT where EXPORT_ID = '" + var_idExport + "'";
			conn.ExecuteQuery();

			if (conn.GetRowCount() == 0)  
			{
				GlobalTools.popMessage(this, "Data Referensi RFCUSTEXPORT kosong!");
				return "";
			}


			string nota = var_idExport;											// nama file hasil export
			string path = vAPP_ROOT + conn.GetFieldValue("EXPORT_PATH");		// path untuk upload
			string file_xls = nota + ".dot";									// nama file word template
			string template = conn.GetFieldValue("EXPORT_ID");					// nama word template
			string template_path = conn.GetFieldValue("EXPORT_TEMPLATE");		// directory word template
			string url = conn.GetFieldValue("EXPORT_URL");						// url (link) untuk download
	

			fileNm = Request.QueryString["curef"] + "-" + nota + "-" + Session["UserID"] + ".DOC";

			object objFileIn = template_path + file_xls;
			object objFileOut = path + fileNm;

			////////////////////////////////////////////////////////////////////////////
			/// Cek apakah file templatenya (input) ada atau tidak
			/// 
			if (!File.Exists(template_path+file_xls))
			{
				GlobalTools.popMessage(this, "File Template tidak ada!");
				return "";
			}
			

			/////////////////////////////////////////////////////////////////////////////
			/// Cek direktori untuk menyimpan file hasil export (output)
			/// 
			if (!Directory.Exists(path)) 
			{
				// create directory if does not exist
				Directory.CreateDirectory(path);
			}


			object oMissingObject = System.Reflection.Missing.Value;
		
			Word.Application wordApp = null;
			Word.Document wordDoc = null;
			
			Process[] oldProcess = Process.GetProcessesByName("WINWORD");				
			foreach(Process thisProcess in oldProcess)
				orgId.Add(thisProcess);

	
			/// 
			/// Always already when using Export Excel file format					
			/// 
			System.Threading.Thread.CurrentThread.CurrentCulture = System.Globalization.CultureInfo.CreateSpecificCulture("en-US");
			System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("en-US");


			wordApp = new Word.ApplicationClass();
			wordApp.Visible = false;

			/// Collecting Existing Winword in Taskbar 
			/// 
			Process[] newProcess = Process.GetProcessesByName("WINWORD");
			foreach(Process thisProcess in newProcess)
				newId.Add(thisProcess);

			/// 
			/// Save word process into database
			/// 					
            try
            {
                //SupportTools.saveProcessWord(wordApp, newId, orgId, conn);
            }
            catch (Exception ex)
            {
                string error = ex.Message;
                string tes = "";
            }
					
			
			wordDoc = wordApp.Documents.Open(ref objFileIn, ref oMissingObject, ref oMissingObject, ref oMissingObject, ref oMissingObject, ref oMissingObject, 
				ref oMissingObject, ref oMissingObject, ref oMissingObject, ref oMissingObject, ref oMissingObject, ref oMissingObject);
			wordDoc.Activate();
			Word.Bookmarks wordBookMark = (Word.Bookmarks)wordDoc.Bookmarks;						
			

			object oCell ;
			string tempField ;
			object sField ;
			string strObject;

			conn.QueryString = "select * from RFCUSTEXPORTPROC where EXPORT_ID = '" + var_idExport + "'";
			conn.ExecuteQuery();
			dt_proc = conn.GetDataTable().Copy();		
	
			
			//////////////////////////////////////////////////////////////////////////
			/// Populate data to word file using different stored procedure
			/// 
			for(int p = 0; p < dt_proc.Rows.Count; p++) 
			{
				string storedproc = dt_proc.Rows[p]["STOREDPROCEDURE"].ToString();

				/// if no stored procedure defined, continue to the next one
				/// 
				if (storedproc.Length == 0) continue;

				/// Get fields from db to map to bookmark in word file
				/// 
				conn.QueryString =	"select d.export_id, d.seq, d.export_col, d.export_row, d.export_field, " + 
									" d.[description], d.[group], d.category, p.storedprocedure " +
									" from rfcustexportdetail d " + 
									" left join rfcustexportproc p on d.export_id = p.export_id and d.category = p.seq " + 
									" where d.export_id = '" + var_idExport + "' and p.storedprocedure = '" + storedproc + "' " + 
									" order by d.seq";
				conn.ExecuteQuery();
				dt_field = conn.GetDataTable().Copy();


				/// Execute each stored procedure
				/// 
				try 
				{
					conn.QueryString = "exec " + storedproc + " '" + LBL_CUREF.Text + "', '" + Request.QueryString["regno"] + "'";
					conn.ExecuteQuery();
				} 
				catch (Exception ex)
				{
					/// There's no such stored procedure in db ??
					/// 
                    String a = ex.Message;
					ExceptionHandling.Handler.saveExceptionIntoWindowsLog(ex, Request.Path, "CU_REF: " + LBL_CUREF.Text);
					continue;
				}

				for(int j = 0; j < conn.GetRowCount(); j++)
				{			          
					for(int i = 0; i < dt_field.Rows.Count; i++)
					{	
						try 
						{
							oCell = dt_field.Rows[i]["export_col"];
							tempField = dt_field.Rows[i]["export_field"].ToString();
							sField = dt_field.Rows[i]["export_field"].ToString();							

							objValue = conn.GetFieldValue(j,tempField);		
							
							if(wordBookMark.Exists(sField.ToString())) 
							{
								
								if (dt_field.Rows[i]["Group"].ToString() != "0") strObject = objValue.ToString();
								else strObject = objValue.ToString() + "\n";
									
								Word.Bookmark oBook = wordBookMark.Item(ref sField);
								oBook.Select();
								oBook.Range.Text = strObject;								
							}	
						}
						catch { }								

					} //endloop var i
				} //endloop var j
			}


			////////////////////////////////////////////////////////////////////////////
			/// Save Word File
			try 
			{	
				wordDoc.SaveAs(ref objFileOut, ref oMissingObject, ref oMissingObject, ref oMissingObject, ref oMissingObject, ref oMissingObject, 
					ref oMissingObject, ref oMissingObject, ref oMissingObject, ref oMissingObject, ref oMissingObject);

				System.Threading.Thread.Sleep(TimeSpan.FromSeconds(3));  	
				
				/// 
				/// Menyimpan data hasil export ke database
				/// 
				conn.QueryString = "exec IN_CUST_EXPORT '" + nota +"','" + Request.QueryString["curef"] + "','" + fileNm + "', '" + Session["UserID"] + "', '1'";

				conn.ExecuteQuery();
				mStatus = "Export Succesfully";	
			}
			catch (Exception ex)
			{ 
				ExceptionHandling.Handler.saveExceptionIntoWindowsLog(ex, Request.Path, "CU_REF: " + LBL_CUREF.Text);
			}


			// try to close word dulu ...
			try 
			{ 
				if(wordDoc!=null)
				{
					wordDoc.Close(ref oMissingObject, ref oMissingObject, ref oMissingObject);
					wordDoc=null;
				}
				if(wordApp!=null)
				{
					wordApp.Application.Quit(ref oMissingObject, ref oMissingObject, ref oMissingObject);
					wordApp=null;
				}
			}
			catch (Exception ex)
			{ 
				ExceptionHandling.Handler.saveExceptionIntoWindowsLog(ex, Request.Path, "CU_REF: " + LBL_CUREF.Text);
			}

			/// Kill process
			/// 
			try 
			{
						
				// Killing Proses after Export
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
					if(!bSameId) 
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
				
				} // end x		
			}
			catch   (Exception ex)
			{ 	
				ExceptionHandling.Handler.saveExceptionIntoWindowsLog(ex, Request.Path, "CU_REF: " + LBL_CUREF.Text);
			}	

			return mStatus;
		
		}

		private string Export_Excel()
		{
			System.Data.DataTable dt_field = null;
			string data_id=null;
			string prgid=null;
			string fileNm = string.Empty;
			string fileIn = string.Empty;
			string fileOut = string.Empty;
			object objPaste = null;
			object objCopy = null;
			bool bSukses = true;
			object objValue = null;
			object objType = Type.Missing;		
			string mStatus = string.Empty;
			int iItem = 0;
			int iItemOther = 0;
			int iItemPosition = 0;
			int m_Row = 0;

			ArrayList orgId = new ArrayList();
			ArrayList newId = new ArrayList();
			
			conn.QueryString = "select APP_ROOT from APP_PARAMETER";
			conn.ExecuteQuery();
			string vAPP_ROOT = conn.GetFieldValue("APP_ROOT");	

			
			/// Mengambil nilai parameter
			/// 
			conn.QueryString = " select * from RFCUSTEXPORT where EXPORT_ID = '" + var_idExport + "'";
			conn.ExecuteQuery();

			if (conn.GetRowCount() == 0)  
			{
				GlobalTools.popMessage(this, "Data Referensi RFCUSTEXPORT kosong!");
				return "";
			}

			string nota = var_idExport;										// nama file hasil export
			string sheet = conn.GetFieldValue("EXPORT_SHEET");			// sheet di excel
			string path = vAPP_ROOT + conn.GetFieldValue("EXPORT_PATH");	// directory excel hasil export			
			string file_xls = nota + ".XLT";							// nama file excel template
			string template = conn.GetFieldValue("EXPORT_TEMPLATE");		// directory excel template
			string url = conn.GetFieldValue("EXPORT_URL");				// url (link) untuk download			
			//string procedure_name = conn.GetFieldValue ("STOREPROCEDURE");
			
			

			/// Men-construct nama file
			/// 
			fileIn = template + file_xls;	// file template
			fileNm = Request.QueryString["curef"] + "-" + nota + "-" + Session["userid"] + ".XLS";	// file hasil export
			fileOut = path + fileNm;		


			/// Cek apakah file templatenya (input) ada atau tidak
			/// 
			if (!File.Exists(template + file_xls)) 
			{
				GlobalTools.popMessage(this, "File Template tidak ada!");
				return "";
			}

			/// Cek direktori untuk menyimpan file hasil export (output)
			/// 
			if (!Directory.Exists(path)) 
			{
				// create directory if does not exist
				Directory.CreateDirectory(path);
			}


			/// dapatkan semua fields to populate
			/// 
										
			Excel.Application excelApp = null;
			Excel.Workbook excelWorkBook = null;
			Excel.Sheets excelSheet = null;

			Process[] oldProcess = Process.GetProcessesByName("EXCEL");				
			foreach(Process thisProcess in oldProcess)
				orgId.Add(thisProcess);

	
			// Always already when using Export Excel file format					
			System.Threading.Thread.CurrentThread.CurrentCulture = System.Globalization.CultureInfo.CreateSpecificCulture("en-US");
			System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("en-US");


			excelApp = new Excel.ApplicationClass();
			excelApp.Visible = false;
			excelApp.DisplayAlerts = false;						

			Process[] newProcess = Process.GetProcessesByName("EXCEL");
			foreach(Process thisProcess in newProcess)
				newId.Add(thisProcess);

			/// Save process into database
			/// 
			//SupportTools.saveProcessExcel(excelApp, newId, orgId, conn);
					
			
			excelWorkBook = excelApp.Workbooks.Open(fileIn, 0, false, 5, string.Empty, string.Empty, true, Excel.XlPlatform.xlWindows, "\t|",
				false, false, 0, true);

			excelSheet = excelWorkBook.Worksheets;

			Excel.Worksheet excelWorkSheet = (Excel.Worksheet)excelSheet.get_Item(sheet);
							
			int counter  = 0;
			string Col ;
			int Row = 3  ;
			string Cell ;
			string Field ;

			#region " Fill Customer Information "
			try
			{
				conn.QueryString = "Select SEQ, EXPORT_COL, EXPORT_ROW, EXPORT_FIELD, [DESCRIPTION] from RFCUSTEXPORTDETAIL" + 
					" where EXPORT_ID = '" + nota + "' order by SEQ";
				conn.ExecuteQuery();
				dt_field = conn.GetDataTable().Copy();			

				
			}
			catch (Exception ex)
			{
				ExceptionHandling.Handler.saveExceptionIntoWindowsLog(ex, Request.Path, "CU_REF: " + LBL_CUREF.Text); 
			}
			#endregion

	
			try 
			{
				/// Save file fisik hasil export
				/// 
				//excelWorkSheet.Visible = Excel.XlSheetVisibility.xlSheetHidden;
				excelWorkBook.SaveAs(fileOut, Excel.XlFileFormat.xlWorkbookNormal, null, null, null, null,
					Excel.XlSaveAsAccessMode.xlNoChange, null, null, null, true);						
				System.Threading.Thread.Sleep(TimeSpan.FromSeconds(3));  																					 
					
	
				/// Save data file hasil export ke database
				/// 
				conn.QueryString = "exec IN_CUST_EXPORT '" + 
					var_idExport + "','" + Request.QueryString["curef"] + "', '" + 
					fileNm + "', '" + 
					LBL_USER_ID.Text + " ', '1'";
					conn.ExecuteNonQuery();													
					mStatus = "Export Succesfully";	
			}
			catch 	{    }	
			//}
			


			/// Kill Process
			/// 
			try 
			{
				// close the excel objects
				if(excelWorkBook!=null)
				{
					excelWorkBook.Close(true , fileOut, null);
					excelWorkBook=null;
				}

				if(excelApp!=null)
				{
					excelApp.Workbooks.Close();
					excelApp.Application.Quit();
					excelApp=null;
				}
			}
			catch { } 

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
			catch {	 }
			return mStatus;

		}

		private void ViewUploadFiles()
		{
			System.Data.DataTable dt = new System.Data.DataTable();
			conn.QueryString = "EXEC CUSTINFO_VIEWUPLOAD '" + Request.QueryString["curef"] + "'";
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
				HyperLink HpDownload = (HyperLink) DatGrid.Items[i-1].Cells[4].FindControl("FU_DOWNLOAD");
				LinkButton HpDelete = (LinkButton) DatGrid.Items[i-1].Cells[5].FindControl("FU_DELETE");
				HpDownload.NavigateUrl = DatGrid.Items[i-1].Cells[6].Text.Trim();
				if (Session["UserID"].ToString().Trim() != DatGrid.Items[i-1].Cells[2].Text)
					HpDelete.Visible	= false;
			}
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
			this.DatGrid.ItemCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.DatGrid_ItemCommand);

		}
		#endregion

		


		private void deleteFile(string directory, string filename) 
		{
			if (File.Exists(directory + filename)) 
			{
				File.Delete(directory + filename);
			}
		}


		protected void BTN_EXPORT_Click(object sender, System.EventArgs e)
		{
			if (TXT_AP_REGNO.Text.Trim() != "")
			{ 
				conn.QueryString = "select ap.ap_regno, ap.cu_ref cu_ref from application ap "+ 
					"inner join apptrack apt on ap.ap_regno =apt.ap_regno "+
					"where ap.ap_regno ='" + Request.QueryString["regno"] + "' " ;
				conn.ExecuteQuery();

				if (conn.GetRowCount() > 0)
				{	
					if (conn.GetFieldValue("cu_ref").Trim() == Request.QueryString["curef"])
					{
						exportData();
					}
					else
					{
						//GlobalTools.popMessage(this,"No Aplikasi ");
						LBL_STATUS_EXPORT.ForeColor = Color.Red;
						LBL_STATUS_EXPORT.Text = "Application Number belong to Others Customer";

					}
				}
				else
				{
					//GlobalTools.popMessage(this,"No Aplikasi tidak ada");
					LBL_STATUS_EXPORT.ForeColor = Color.Red;
					LBL_STATUS_EXPORT.Text = "Application Number is not found";
				}
			}
			else
			{
				if(Request.QueryString["regno"].ToString().EndsWith("C"))
				{
					//GlobalTools.popMessage(this, Request.QueryString["regno"].ToString());
					string regno = Request.QueryString["regno"].ToString();
					conn.QueryString = "select ap.ap_regno, ap.cu_ref cu_ref from application ap "+ 
						"where ap.ap_regno ='" + Request.QueryString["regno"].ToString() + "' " ;
					conn.ExecuteQuery();

					if (conn.GetRowCount() > 0)
					{	
						if (conn.GetFieldValue("cu_ref").Trim() == Request.QueryString["curef"])
						{
							exportData();
						}
						else
						{
							//GlobalTools.popMessage(this,"No Aplikasi ");
							LBL_STATUS_EXPORT.ForeColor = Color.Red;
							LBL_STATUS_EXPORT.Text = "Application Number belong to Others Customer";

						}
					}
					else
					{
						//GlobalTools.popMessage(this,"No Aplikasi tidak ada");
						LBL_STATUS_EXPORT.ForeColor = Color.Red;
						LBL_STATUS_EXPORT.Text = "Application Number is not found";
					}
				}
				else
				{
					exportData();
				}
			}
		}


		private void exportData()
		{
			string szId = tool.ConvertNull(DDL_FORMATFILE.SelectedValue);
			string mStatus = string.Empty ;
			string mStatusReport = string.Empty;
			
			try
			{
				//ambil jenis file di RFCUSTEXPORT
				conn.QueryString = "Select * from RFCUSTEXPORT where EXPORT_ID = " + szId;
				conn.ExecuteQuery();
				
				if (conn.GetRowCount() > 0) 
				{
					string formatnya = conn.GetFieldValue("EXPORT_FORMAT");
					
					// Always already when using Export Excel file format
					
					System.Threading.Thread.CurrentThread.CurrentCulture = System.Globalization.CultureInfo.CreateSpecificCulture("en-US");
					System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("en-US");
					
					if ( formatnya == "EXCEL" ) 
						//mStatus = Export_Excel();
                        mStatus = client.CustomerInfoExportASPXExport_Excel(Request.QueryString["regno"], Session["UserID"].ToString(), Request.QueryString["curef"], DDL_FORMATFILE.SelectedValue);
					else 
						//mStatus = Export_Word();
                        mStatus = client.CustomerInfoExportASPXExport_Word(Request.QueryString["regno"], Session["UserID"].ToString(), Request.QueryString["curef"], DDL_FORMATFILE.SelectedValue);
					

					ViewFileExport();
				}
			}
			catch (Exception ex)
			{
				LBL_STATUS_EXPORT.ForeColor = Color.Red;
				LBL_STATUSEXPORT.ForeColor = Color.Red;
				mStatus		  = "Error Exporting File";
				mStatusReport = ex.ToString();
			}
			finally
			{
				LBL_STATUS_EXPORT.Text = mStatus.Trim();
				LBL_STATUSEXPORT.Text = mStatusReport.Trim();
			}			
		}
	

		private void DATA_EXPORT_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			switch (((LinkButton)e.CommandSource).CommandName)
			{
				case "delete":
					/// Function delete file fisik
					/// 
					try 
					{					
						conn.QueryString = "select APP_ROOT from APP_PARAMETER";
						conn.ExecuteQuery();
						string vAPP_ROOT = conn.GetFieldValue("APP_ROOT");	

						
						conn.QueryString = "Select EXPORT_PATH from RFCUSTEXPORT where export_id = '" + e.Item.Cells[0].Text + "'";
						conn.ExecuteQuery();
						//directory = conn.GetFieldValue("EXPORT_PATH");

						string directory = vAPP_ROOT + conn.GetFieldValue("EXPORT_PATH");

						deleteFile(directory, e.Item.Cells[1].Text);
						Response.Write("<!-- file : " + directory + e.Item.Cells[1].Text + " -->");
						Response.Write("<!-- file is deleted. -->"); 
					} 
					catch (Exception ex) 
					{
						Response.Write("<!-- Delete File Error: " + ex.Message.ToString() + " -->");
					}

					conn.QueryString = "exec IN_CUST_EXPORT '" + e.Item.Cells[0].Text +"','" + Request.QueryString["curef"] + "', '','" + Session["UserID"] + "', '2'";
					conn.ExecuteQuery();

					ViewFileExport();
					//tambahkan function untuk delete file
					break;
			}
		}

		protected void BTN_UPLOAD_Click(object sender, System.EventArgs e)
		{
			string directory;
			int counter = 0;
			string outputfilename;
			
			//Get Export Properties
			conn.QueryString = "SELECT UPLOAD_PATH FROM VW_CUSTINFO_EXPORTPARAM";
			conn.ExecuteQuery();

			if (conn.GetRowCount() > 0)
			{
				directory = Server.MapPath(conn.GetFieldValue("UPLOAD_PATH").Trim());

				HttpFileCollection uploadedFiles = Request.Files;

				for (int i = 0; i < uploadedFiles.Count; i++)
				{
					HttpPostedFile userPostedFile = uploadedFiles[i];
					counter = i + 1;

					try
					{
						if (userPostedFile.ContentLength > 0)
						{
							outputfilename = Request.QueryString["curef"].Trim() + "-"+ Session["USERID"].ToString() +"-" + Path.GetFileName(userPostedFile.FileName);
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
							conn.QueryString = "EXEC CUSTINFO_UPLOADSAVE '1', '" + Request.QueryString["curef"] +
								"', '', '" + Session["UserID"].ToString().Trim() + "', '" + outputfilename + "'";
							conn.ExecuteQuery();

							//View Upload File
							ViewUploadFiles();
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

		private void DatGrid_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			switch (((LinkButton)e.CommandSource).CommandName)
			{
				case "delete":
					//Get Export Properties
					conn.QueryString = "SELECT UPLOAD_PATH FROM VW_CUSTINFO_EXPORTPARAM";
					conn.ExecuteQuery();

					if (conn.GetRowCount() > 0)
					{
						string directory = Server.MapPath(conn.GetFieldValue("UPLOAD_PATH").Trim());
				
						try 
						{					
							//Delete File Physically
							deleteFile(directory, e.Item.Cells[3].Text);
							Response.Write("<!-- file : " + directory + e.Item.Cells[3].Text + " -->");
							Response.Write("<!-- file is deleted. -->");
						} 
						catch (Exception ex) 
						{
							Response.Write("<!-- Delete File Error: " + ex.Message.ToString() + " -->");
						}

						conn.QueryString = "EXEC CUSTINFO_UPLOADSAVE '2', '" + e.Item.Cells[0].Text +
							"', '" + e.Item.Cells[1].Text + "', '" + e.Item.Cells[2].Text + "', '" + e.Item.Cells[3].Text + "'";
						conn.ExecuteQuery();

						//View Upload Files
						ViewUploadFiles();
					}
					break;
			}
		}

		private void DDL_FORMATFILE_SelectedIndexChanged(object sender, EventArgs e)
		{
			ViewFileExport();
		}
	}
}
