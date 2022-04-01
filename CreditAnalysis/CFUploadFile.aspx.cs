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
using Excel;

namespace TestSME.CreditAnalysis
{
	/// <summary>
	/// Summary description for CFUploadFile.
	/// </summary>
	public partial class CFUploadFile : System.Web.UI.Page
	{
		protected Connection conn;
		protected Tools tool = new Tools();
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here			
			conn = (Connection) Session["Connection"];
	
			viewPickList();	
	
			BTN_EXPORT.Attributes.Add("onclick", "if (!exportInProgress()) { return false; }");
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
		private void viewPickList()
		{
			DDL_FORMAT_CF.Items.Add(new ListItem("- PILIH -", ""));
			conn.QueryString = "select excel_name, xls_view from ca_excel_template where lg_code = 'CF_T'";
			conn.ExecuteQuery();
			for (int i = 0; i < conn.GetRowCount(); i++)
				DDL_FORMAT_CF.Items.Add(new ListItem(conn.GetFieldValue(i,1), conn.GetFieldValue(i,0)));
		}
	

		protected void BTN_UPLOAD_Click(object sender, System.EventArgs e)
		{
			UploadExcel();
		}
		private void UploadExcel()
		{
			string a = "CF_T";
			string path;
			
			conn.QueryString = "select xls_root,xls_dir from ca_excel_template where lg_code = '" + a + "'";
			conn.ExecuteQuery();
			path = conn.GetFieldValue("xls_root").ToString().Trim()+ conn.GetFieldValue("xls_dir").ToString().Trim();
 
			System.IO.FileInfo fi = new System.IO.FileInfo(TXT_FILE_UPLOAD.PostedFile.FileName);
			TXT_FILE_UPLOAD.PostedFile.SaveAs(path + fi.Name);
			
			LBL_STATUS.Text = "Upload Successful";
		}

		protected void BTN_EXPORT_Click(object sender, System.EventArgs e)
		{
			string vtemp = DDL_FORMAT_CF.SelectedValue;
			conn.QueryString = "select xls_root, xls_dir,location from ca_excel_template where lg_code = 'CF_T' and excel_name = '" + vtemp + "'";
			conn.ExecuteQuery();

			System.Data.DataTable dt;
			dt = conn.GetDataTable().Copy();

			string path = conn.GetFieldValue(dt,0,"xls_root").ToString()+conn.GetFieldValue(dt,0,"xls_dir").ToString()+vtemp;
				
			// Set the culture and UI culture to the browser's accept language
			System.Threading.Thread.CurrentThread.CurrentCulture = System.Globalization.CultureInfo.CreateSpecificCulture("en-US");
			System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("en-US");


			Excel.Application excelApp = new Excel.ApplicationClass();
			excelApp.Visible = false;
			excelApp.DisplayAlerts = false;
			Excel.Workbook excelWorkbook = excelApp.Workbooks.Open(path,
				0, false, 5, "", "", true, Excel.XlPlatform.xlWindows, "\t",
				false, false, 0, true);
			Excel.Sheets excelSheets = excelWorkbook.Worksheets;
			string currentSheet = "Sheet1";
			Excel.Worksheet excelWorksheet = (Excel.Worksheet)excelSheets.get_Item(currentSheet);
			//----------------- separator -----------------------------------------------------------------------------------------------------------------------------------------------------------------
			conn.QueryString = "select excel_cell, table_name,column_name,formula,sql_statement from ca_excel_cashflow where seq in (select seq from ca_excel_template where excel_name = '" + vtemp + "' and table_name is not null and table_name <> 'NA')";
			conn.ExecuteQuery();
			System.Data.DataTable dt1;
			dt1 = conn.GetDataTable().Copy();
				for (int i=0;i<dt1.Rows.Count;i++)
				{
					Excel.Range excelCell = (Excel.Range)excelWorksheet.get_Range(conn.GetFieldValue(dt1,i,"excel_cell"),conn.GetFieldValue(dt1,i,"excel_cell"));
					conn.QueryString = "Select "+conn.GetFieldValue(dt1,i,"column_name").ToString()+ " from "+conn.GetFieldValue(dt1,i,"table_name").ToString()+" where cu_ref in (select cu_ref from application where ap_regno = '"+ Request.QueryString["regno"] + "') and year(posisi_tgl) in ("+conn.GetFieldValue(dt1,i,"sql_statement")+")";
					conn.ExecuteQuery();
					for (int m=0;m<conn.GetRowCount();m++)
					{
						if (conn.GetFieldValue(m,0).ToString()=="CONVERT(VARCHAR,POSISI_TGL,102)")
						{ excelCell.Value2 = conn.GetFieldValue(m,0); }
						else
						{ excelCell.Value2 = tool.ConvertFloat(conn.GetFieldValue(m,0)); }
					}
				}
			//--------------------separator-------------------------------------------------------------------------------------------------------------------------------------------
			//Excel.Range range = (Excel.Range) this.Cells.get_Item(2, 2);
			//range.Insert(Excel.XlInsertShiftDirection.xlShiftDown, System.Type.Missing);
			

			string workbookPath = conn.GetFieldValue(dt,0,"xls_root")+conn.GetFieldValue(dt,0,"xls_dir")+vtemp.Substring(0,vtemp.IndexOf("."))+".xls";
			excelWorkbook.SaveAs(workbookPath,Excel.XlFileFormat.xlWorkbookNormal,null,null,null,null,Excel.XlSaveAsAccessMode.xlNoChange,null,null,null,null); 
			excelWorkbook.Close(null,null,null);
			excelApp.Workbooks.Close();
			excelApp.Application.Quit();
			excelApp.Quit();
			System.Runtime.InteropServices.Marshal.ReleaseComObject(excelSheets); 
			System.Runtime.InteropServices.Marshal.ReleaseComObject(excelWorkbook); 
			System.Runtime.InteropServices.Marshal.ReleaseComObject(excelApp); 
			excelSheets = null; 
			excelWorkbook = null; 
			excelApp = null;

			//Response.Redirect(conn.GetFieldValue(dt,0,"location").ToString());			
			Response.Write("<script language=JavaScript>window.open('"+conn.GetFieldValue(dt,0,"location").ToString()+"',null,'width=800;height=600,location=yes,toolbar=yes,menubar=yes')</script>");
		}
	}
}
