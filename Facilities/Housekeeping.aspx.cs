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
using System.IO;

namespace SME.Facilities
{
	/// <summary>
	/// Summary description for Housekeeping.
	/// </summary>
	public partial class Housekeeping : System.Web.UI.Page
	{
		protected Connection conn; //, con1, con2,con3;
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			conn = (Connection) Session["Connection"];

			if(!IsPostBack)
			{
				initialize();

				/// Karena testingnya di env SME, maka set default ke module SME
				/// 
				try { DDL_RFMODULE.SelectedValue = "01"; } 
				catch {}

				LBL_RESULT.Text = "";
				LBL_RESULT_RESTORE.Text = "";
				LBL_RESULT_DELETE.Text = "";

				try { createFileLog(); } 
				catch {}
			}

			TBL_ARC_HISTORY.Visible = false;
			TBL_REST_HISTORY.Visible = false;
			TBL_DEL_HISTORY.Visible = false;

			//BTN_ARC_HISTORY.Text = BTN_ARC_HISTORY.Text.ToUpper().Replace("HIDE", "View");
			//BTN_ARC_NEXT.Text = BTN_ARC_NEXT.Text.ToUpper().Replace("HIDE", "View");

			//BTN_ARC_HISTORY.Enabled = true;
			//BTN_ARC_NEXT.Enabled = true;

			BTN_BACKUP.Attributes.Add("onclick", "if(!cek_mandatory(document.Form1,'01','')){return false;}; if(!ConfirmBox('Are you sure you want to Archive?')) { return false; };");
			BTN_RESTORE.Attributes.Add("onclick", "if(!cek_mandatory(document.Form1,'02','')){return false;}; if(!ConfirmBox('Are you sure you want to Restore?')) { return false; };");
			BTN_DELETE.Attributes.Add("onclick", "if(!cek_mandatory(document.Form1,'03','')){return false;}; if(!ConfirmBox('Are you sure you want to Delete?\\nApplication will be deleted permanently from HouseKeep Database !')) { return false; };");			

			BTN_ARC_NEXT.Attributes.Add("onclick", "if(!cek_mandatory(document.Form1,'01','')){return false;};");
			BTN_REST_NEXT.Attributes.Add("onclick", "if(!cek_mandatory(document.Form1,'02','')){return false;};");
			BTN_DEL_NEXT.Attributes.Add("onclick", "if(!cek_mandatory(document.Form1,'03','')){return false;};");
		}

		private void initialize() 
		{
			GlobalTools.initDateForm(TXT_DATE1, DDL_MONTH1, TXT_YEAR1);
			GlobalTools.initDateForm(TXT_DATE2, DDL_MONTH2, TXT_YEAR2);

			GlobalTools.initDateForm(TXT_DATE1_R, DDL_MONTH1_R, TXT_YEAR1_R);
			GlobalTools.initDateForm(TXT_DATE2_R, DDL_MONTH2_R, TXT_YEAR2_R);

			GlobalTools.initDateForm(TXT_DATE1_D, DDL_MONTH1_D, TXT_YEAR1_D);
			GlobalTools.initDateForm(TXT_DATE2_D, DDL_MONTH2_D, TXT_YEAR2_D);

			GlobalTools.fillRefList(DDL_RFMODULE, "select moduleid, modulename from rfmodule order by modulename", false, conn);
		}

		private void archiveFileUpload(string startdate, string enddate, string moduleid) 
		{
			/// get application (app no) where fileupload to be archived
			/// 
			conn.QueryString = "exec HOUSEKEEP_GETAPPLICATION 'A', '" + moduleid + "', " + startdate + ", " + enddate + " ";
			conn.ExecuteQuery();
			DataTable dtArc = conn.GetDataTable();

			/// get directories where fileupload located
			/// 
			conn.QueryString = "exec HOUSEKEEP_GETDIRECTORYUPLOAD";
			conn.ExecuteQuery();
			DataTable dtDirUpload = conn.GetDataTable();

			/// get housekeeping directory (to keep fileupload) and application root directory
			/// 
			conn.QueryString = "select isnull(housekeep_upload_dir,'') housekeep_upload_dir, app_root from app_parameter";
			conn.ExecuteQuery();
			string housekeep_upload_dir = conn.GetFieldValue(0,0);
			string app_root = conn.GetFieldValue(0,1);

			if (housekeep_upload_dir.Trim().Length == 0) 
				throw new Exception("HouseKeeping Upload Directory has not been configured ...");

			if (!Directory.Exists(housekeep_upload_dir)) Directory.CreateDirectory(housekeep_upload_dir);

			for(int i=0; i < dtArc.Rows.Count; i++) 
			{
				string regno = dtArc.Rows[i]["ap_regno"].ToString();	// get app no

				for(int j=0; j < dtDirUpload.Rows.Count; j++) 
				{
					string dirUpload = dtDirUpload.Rows[j]["dirupload"].ToString();

					if (Directory.Exists(dirUpload)) 
					{
						DirectoryInfo di = new DirectoryInfo(dirUpload);
						FileInfo[] fi = di.GetFiles("*" + regno + "*.*");	// get file with app no pattern

						foreach(FileInfo file in fi) 
						{
							string new_housekeep_dir = @housekeep_upload_dir + dirUpload.Replace(app_root, "");
							string sourceFileName = @dirUpload + file.Name;
							string destFileName = @new_housekeep_dir + file.Name;

							try 
							{
								if (!Directory.Exists(new_housekeep_dir)) Directory.CreateDirectory(new_housekeep_dir);

								if (File.Exists(sourceFileName)) File.Move(sourceFileName, destFileName);
							} 
							catch 
							{
								Response.Write("<!-- error archive directory: " + new_housekeep_dir + " -->");
								Response.Write("<!-- error archive file: " + sourceFileName + " -->");
								//throw new Exception("Error on Creating Housekeep Upload Directory ...");
							}
						}
					}
				}
			}
		}

		private void restoreFileUpload(string regno, string moduleid) 
		{
			/// get directories where fileupload located
			/// 
			conn.QueryString = "exec HOUSEKEEP_GETDIRECTORYUPLOAD";
			conn.ExecuteQuery();
			DataTable dtDirUpload = conn.GetDataTable();

			/// get housekeeping directory (to keep fileupload) and application root directory
			/// 
			conn.QueryString = "select isnull(housekeep_upload_dir,'') housekeep_upload_dir, app_root from app_parameter";
			conn.ExecuteQuery();
			string housekeep_upload_dir = conn.GetFieldValue(0,0);
			string app_root = conn.GetFieldValue(0,1);

			if (housekeep_upload_dir.Trim().Length == 0) 
				throw new Exception("HouseKeeping Upload Directory has not been configured ...");

			if (!Directory.Exists(housekeep_upload_dir)) Directory.CreateDirectory(housekeep_upload_dir);

			for(int j=0; j < dtDirUpload.Rows.Count; j++) 
			{
				string dirUpload = dtDirUpload.Rows[j]["dirupload"].ToString();
				string new_housekeep_dir = @housekeep_upload_dir + dirUpload.Replace(app_root, "");

				if (Directory.Exists(new_housekeep_dir)) 
				{
					DirectoryInfo di = new DirectoryInfo(new_housekeep_dir);
					FileInfo[] fi = di.GetFiles("*" + regno + "*.*");	// get file with app no pattern

					foreach(FileInfo file in fi) 
					{
						string destFileName = @dirUpload + file.Name;
						string sourceFileName = @new_housekeep_dir + file.Name;

						if (File.Exists(sourceFileName)) File.Move(sourceFileName, destFileName);
					}
				}
			}
		}
		

		private void deleteFileUpload(string regno, DateTime date1, DateTime date2, string moduleid) 
		{
			/// get directories where fileupload located
			/// 
			conn.QueryString = "exec HOUSEKEEP_GETDIRECTORYUPLOAD 'D'";
			conn.ExecuteQuery();
			DataTable dtDirUpload = conn.GetDataTable();

			for(int j=0; j < dtDirUpload.Rows.Count; j++) 
			{
				string dirUpload = dtDirUpload.Rows[j]["dirupload"].ToString();
				string filetype = dtDirUpload.Rows[j]["filetype"].ToString();

				if (filetype == "BACKUP") 
				{
					Response.Write("<!-- BACKUP file type : " + dirUpload + " -->");

					DirectoryInfo di = new DirectoryInfo(dirUpload);
					FileInfo[] fi = di.GetFiles();

					foreach(FileInfo file in fi) 
					{
						if (file.CreationTime >= date1 && file.CreationTime <= date2)
						{								
							string fileName = @dirUpload + file.Name;
							File.Delete(fileName);
						}
					}
				}
				else // APP/Export filetype
				{	
					Response.Write("<!-- APP file type : " + dirUpload + " -->");

					try 
					{ 
						DirectoryInfo di = new DirectoryInfo(dirUpload);
						FileInfo[] fi = di.GetFiles("*" + regno + "*.*");	// get file with app no pattern

						foreach(FileInfo file in fi) 
						{
							string fileName = @dirUpload + file.Name;
							try { File.Delete(fileName); } 
							catch { /* by pass file */ }
						}
					} 
					catch { /* by pass directory if not found */}
				}
			}
		}

		private void createFileLog() 
		{
			/////////////////////////////////////////////////////////////////////////////////////////
			/// Create file for history log
			/// filename : PARAMDOWNLOAD_<date>.LOG
			/// directory : C:\LOSSME_HouseKeepingLog
			/// 
			StreamWriter _filePtr = null;

			string _logfilename = "HOUSEKEEPING_";
			_logfilename = _logfilename + DateTime.Now.ToString("yyyyMMddmmss") + ".LOG";			

			string _logdir = @"C:\LOSSME_HouseKeepingLog";

			if (!Directory.Exists(_logdir)) 
				Directory.CreateDirectory(_logdir);			

			_filePtr = File.CreateText(_logdir + "\\" + _logfilename);			

			///////////////////// END OF CREATE FILE ////////////////////////////////////////////////

			//Session.Add("filePtr", _filePtr);
			Session.Add("fullPathLogFile", _logdir + "\\ " + _logfilename);
		}

		private void viewHouseKeeping (Button btnViewShow, Button btnViewHide, 
									  string title, Label lblTitle, Label lblCount, string query, 
									  DataGrid dgrView, HtmlTable tblHtml, Connection localConn) 
		{
			//Response.Write("<!-- text button: " + btnViewShow.Text + " -->");

			if (btnViewShow.Text.ToUpper().Trim().StartsWith("VIEW")) 
			{				
				//Response.Write("<!-- Show !! -->");

				lblTitle.Text = title;
				btnViewHide.Enabled = false;


				localConn.QueryString = query;
				localConn.ExecuteQuery();

				dgrView.DataSource = localConn.GetDataTable().DefaultView;
				try 
				{ 
					dgrView.DataBind(); 
				}
				catch 
				{
					dgrView.CurrentPageIndex = 0;
					dgrView.DataBind();
				}

				tblHtml.Visible = true;
				btnViewShow.Text = btnViewShow.Text.ToUpper().Replace("VIEW", "HIDE");
				lblCount.Text = dgrView.Items.Count.ToString();				
			} 
			else 
			{
				//Response.Write("<!-- Hide !! -->");

				lblTitle.Text = "";
				btnViewHide.Enabled = true;


				tblHtml.Visible = false;
				btnViewShow.Text = btnViewShow.Text.ToUpper().Replace("HIDE", "VIEW");
			}
		}


		private DateTime getDateTime(string dd, string mm, string yyyy) 
		{
			DateTime date;

			int _dd=0, _mm=0, _yyyy=0;			

			try { _dd = Convert.ToInt32(dd); } catch {}
			try { _mm = Convert.ToInt32(mm);  } catch {}
			try { _yyyy = Convert.ToInt32(yyyy); } catch {}

			date = new DateTime(_yyyy, _mm, _dd);

			return date;
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

		protected void BTN_BACKUP_Click(object sender, System.EventArgs e)
		{
			LBL_RESULT_RESTORE.Text = "";
			LBL_RESULT_DELETE.Text = "";			

			bool inputIsValid = true;
			bool hasErrors = false;

			/***************************************************************************************************
			 * Input Validation
			 **************************************************************************************************/
			if (!GlobalTools.isDateValid(this,TXT_DATE1.Text,DDL_MONTH1.SelectedValue,TXT_YEAR1.Text))
			{
				GlobalTools.popMessage(this,"Date is not Valid!");
				GlobalTools.SetFocus(this, TXT_DATE1);
				inputIsValid = false;
			}
			else if (!GlobalTools.isDateValid(this,TXT_DATE2.Text,DDL_MONTH2.SelectedValue,TXT_YEAR2.Text))
			{
				GlobalTools.popMessage(this,"Date is not Valid!");
				GlobalTools.SetFocus(this, TXT_DATE2);
				inputIsValid = false;
			}
			else if (TXT_YEAR2.Text == DateTime.Today.Year.ToString() && DateTime.Today.Month - Convert.ToInt32(DDL_MONTH2.SelectedValue) <= 3 ) 
			{
				GlobalTools.popMessage(this, "End Date must be 3-months-earlier than Today!");
				GlobalTools.SetFocus(this, TXT_DATE2);
				inputIsValid = false;
			}
			/**********************************************************
			 * End of Input Validation
			 **********************************************************/


			if (inputIsValid) 
			{
				string startdate = GlobalTools.ToSQLDate(TXT_DATE1.Text,DDL_MONTH1.SelectedValue,TXT_YEAR1.Text);
				string enddate = GlobalTools.ToSQLDate(TXT_DATE2.Text,DDL_MONTH2.SelectedValue,TXT_YEAR2.Text);
				//con2 = conn;	// buat apa ya ?? --yudi
					
				StreamWriter _filePtr = null;
				_filePtr = File.AppendText(Session["fullPathLogFile"].ToString());

				try 
				{
					/// Meng-copy aplikasi dari produksi ke housekeeping
					/// 
					conn.QueryString = "exec HOUSEKEEP_ARCHIVE_APPLICATION 'A', " + startdate + ", " + enddate + ", '" + DDL_RFMODULE.SelectedValue	+ "', NULL, '" + Session["UserID"].ToString() + "' ";
					conn.ExecTrans();

					//// insert into detail tabel
					///			
					conn.QueryString = "exec HOUSEKEEP_ARCHIVE_DATA " + startdate + "," + enddate + ", '" + DDL_RFMODULE.SelectedValue + "'";
					conn.ExecTrans();

					conn.ExecTran_Commit();

					if (_filePtr  != null) 
					{
						_filePtr.WriteLine(DateTime.Now.ToString());
						_filePtr.WriteLine("Archiving database ended successfully ....");
						_filePtr.WriteLine("=================================================================================================================================");					
					}

				} 
				catch (Exception ex)
				{
					LBL_RESULT.Text = "Archieving is not Success! <BR>Please contact System Administrator for more information.";
					hasErrors = true;

					if (_filePtr  != null) 
					{						
						_filePtr.WriteLine(DateTime.Now.ToString());
						_filePtr.WriteLine("Archiving ERROR1 :");
						_filePtr.WriteLine(ex.ToString());
						_filePtr.WriteLine("=================================================================================================================================");					
					}

					try 
					{ 
						ExceptionHandling.Handler.saveExceptionIntoWindowsLog(ex, Request.Path, "HouseKeepingArchive");
					} 
					catch {}
					if (conn != null) conn.ExecTran_Rollback();
				}

				/// Memindahkan file upload dari produksi ke housekeeping
				/// 
				try 
				{ 
					if (!hasErrors) 
					{
						archiveFileUpload(startdate, enddate, DDL_RFMODULE.SelectedValue); 
						LBL_RESULT.Text = "Archieving is Success!";

						if (_filePtr  != null) 
						{
							_filePtr.WriteLine(DateTime.Now.ToString());
							_filePtr.WriteLine("Archiving file upload ended successfully ....");
							_filePtr.WriteLine("=================================================================================================================================");					
						}
					}
				} 
				catch (Exception ex)
				{
					if (_filePtr  != null) 
					{
						_filePtr.WriteLine(DateTime.Now.ToString());
						_filePtr.WriteLine("Archiving ERROR2 :");
						_filePtr.WriteLine(ex.ToString());
						_filePtr.WriteLine("=================================================================================================================================");					
					}

					try 
					{ 
						ExceptionHandling.Handler.saveExceptionIntoWindowsLog(ex, Request.Path, "Archive Upload File");
					} 
					catch {}
					LBL_RESULT.Text = ex.ToString();
				}
				


				//////////////////////////////////////////////////////////////////////////////////////////
				/// Menghapus user activity di LOSMNT
				/// 
				conn.QueryString = "select * from rfmodule where moduleid = '99'";
				conn.ExecuteQuery();
				if (conn.GetRowCount() > 0) 
				{
					string dbmnt_ip, dbmnt_name, dbmnt_uid, dbmnt_pwd;

					try 
					{ 
						dbmnt_ip = conn.GetFieldValue("db_ip");
						dbmnt_name = conn.GetFieldValue("db_nama");
						dbmnt_uid = conn.GetFieldValue("db_loginid");
						dbmnt_pwd = conn.GetFieldValue("db_loginpwd");

						Connection conn_mnt = new Connection("Data Source=" + dbmnt_ip + ";Initial Catalog=" + dbmnt_name + ";uid="+ dbmnt_uid +";pwd="+ dbmnt_pwd +";Pooling=true");
						conn_mnt.QueryString = "delete from scuseractivity where sa_login < getdate()-60"; // 2 months before today
						conn_mnt.ExecuteNonQuery();
						conn_mnt.CloseConnection();
					} 
					catch (Exception ex)
					{
						if (_filePtr  != null) 
						{
							_filePtr.WriteLine(DateTime.Now.ToString());
							_filePtr.WriteLine("Archiving ERROR3 :");
							_filePtr.WriteLine(ex.ToString());
							_filePtr.WriteLine("=================================================================================================================================");					
						}
					}
				}

				/////////////////////////////////////////////////////////
				/// Close file Pointer
				/// 
				if (_filePtr != null) _filePtr.Close();

				/* // tidak dipakai lagi ...
				if (hasil.Trim() != "0") LBL_RESULT.Text = "Archieving is not Success!";
				else LBL_RESULT.Text = "Archieving is Success!";
				*/
			}				
		}

		protected void BTN_RESTORE_Click(object sender, System.EventArgs e)
		{
			LBL_RESULT.Text = "";
			LBL_RESULT_DELETE.Text = "";


			bool inputIsValid = true;
			bool hasErrors = false;

			/***********************************************
			 * Input Validation
			 ***********************************************/
			if (!GlobalTools.isDateValid(this,TXT_DATE1_R.Text,DDL_MONTH1_R.SelectedValue,TXT_YEAR1_R.Text))
			{
				GlobalTools.popMessage(this,"Date is not Valid!");
				GlobalTools.SetFocus(this, TXT_DATE1_R);
				inputIsValid = false;
			}
			else if (!GlobalTools.isDateValid(this,TXT_DATE2_R.Text,DDL_MONTH2_R.SelectedValue,TXT_YEAR2_R.Text))
			{
				GlobalTools.popMessage(this,"Date is not Valid!");
				GlobalTools.SetFocus(this, TXT_DATE2_R);
				inputIsValid = false;
			}

			/* // Yg ini tidak jadi. 
			 * // Last update : restore per periode aplikasi
			 * 
			if (TXT_APPNO_RESTORE.Text.Trim().Length == 0) 
			{
				inputIsValid = false;
				LBL_RESULT_RESTORE.Text = "Application Number must be filled !";
			}
			else 
			{
				/// Cek apakah aplikasi yang dimasukkan ada atau tidak
				/// 
				conn.QueryString = "exec HOUSEKEEP_GETAPPLICATION2 'R', '" + TXT_APPNO_RESTORE.Text.Trim() + "', '01'";
				conn.ExecuteQuery();

				if (conn.GetRowCount() == 0) 
				{
					inputIsValid = false;
					LBL_RESULT_RESTORE.Text = "Application is not found !";
				}
			}*/
			/**********************************************************
			 * End of Input Validation
			 **********************************************************/


			if (inputIsValid)
			{
				string startdate = GlobalTools.ToSQLDate(TXT_DATE1_R.Text,DDL_MONTH1_R.SelectedValue,TXT_YEAR1_R.Text);
				string enddate = GlobalTools.ToSQLDate(TXT_DATE2_R.Text,DDL_MONTH2_R.SelectedValue,TXT_YEAR2_R.Text);

				/* // kayaknya ga perlu deh ! --yudi
				con1 = conn;
				con2 = conn;
				*/

				StreamWriter _filePtr = null;
				_filePtr = File.AppendText(Session["fullPathLogFile"].ToString());


				try 
				{
					/// Men-copy aplikasi dari housekeeping ke production
					/// 			
					conn.QueryString = "exec HOUSEKEEP_ARCHIVE_APPLICATION 'R', " + startdate + ", " + enddate + ", '" + DDL_RFMODULE.SelectedValue + "', NULL, '" + Session["UserID"].ToString() + "' ";
					conn.ExecTrans();

					///// insert into detail tabel
					///				
					conn.QueryString = "exec HOUSEKEEP_RESTORE_DATA " + startdate + "," + enddate + ", '" + DDL_RFMODULE.SelectedValue + "', NULL ";
					conn.ExecTrans();

					conn.ExecTran_Commit();					

					if (_filePtr  != null) 
					{
						_filePtr.WriteLine(DateTime.Now.ToString());
						_filePtr.WriteLine("Restoring database ended successfully ....");
						_filePtr.WriteLine("=================================================================================================================================");					
					}
				} 
				catch (Exception ex) 
				{
					LBL_RESULT_RESTORE.Text = "Restoring is not Success! <BR>Please contact System Administrator for more information.";
					hasErrors = true;

					if (_filePtr  != null) 
					{
						_filePtr.WriteLine(DateTime.Now.ToString());
						_filePtr.WriteLine("Restoring database ERROR1 :");
						_filePtr.WriteLine(ex.ToString());
						_filePtr.WriteLine("=================================================================================================================================");					
					}

					try 
					{ 
						ExceptionHandling.Handler.saveExceptionIntoWindowsLog(ex, Request.Path, "HouseKeepingRestore");
					} 
					catch {}
					if (conn != null) conn.ExecTran_Rollback();
				}				

				try 
				{
					if (!hasErrors) 
					{
						/// Restore file upload
						/// 
						restoreFileUpload(TXT_APPNO_RESTORE.Text.Trim(), DDL_RFMODULE.SelectedValue);
						LBL_RESULT_RESTORE.Text = "Restoring is Success!";

						if (_filePtr  != null) 
						{
							_filePtr.WriteLine(DateTime.Now.ToString());
							_filePtr.WriteLine("Restoring file upload ended successfully ....");
							_filePtr.WriteLine("=================================================================================================================================");					
						}
					}
				} 
				catch (Exception ex) 
				{
					try 
					{
						ExceptionHandling.Handler.saveExceptionIntoWindowsLog(ex, Request.Path, "Restore Upload File");
					} 
					catch {}
					LBL_RESULT_RESTORE.Text = ex.ToString();
					
					if (_filePtr  != null) 
					{
						_filePtr.WriteLine(DateTime.Now.ToString());
						_filePtr.WriteLine("Restoring file upload ERROR1 :");
						_filePtr.WriteLine(ex.ToString());
						_filePtr.WriteLine("=================================================================================================================================");					
					}
				}
				
				if (_filePtr != null) _filePtr.Close();

				/* // ga perlu kayaknya ...
				if (hasil1.Trim() != "0") LBL_RESULT_RESTORE.Text = "Restoring is not Success!";
				else LBL_RESULT_RESTORE.Text = "Restoring is Success!";
				*/

			}
		}

		protected void BTN_BACK_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
		
		}


		protected void BTN_DELETE_Click(object sender, System.EventArgs e)
		{
			LBL_RESULT.Text = "";
			LBL_RESULT_RESTORE.Text = "";

			bool inputIsValid = true;
			bool hasErrors = false;

			//======================================				
			//	Input Validation
			//======================================
			if (!GlobalTools.isDateValid(this,TXT_DATE1_D.Text,DDL_MONTH1_D.SelectedValue,TXT_YEAR1_D.Text))
			{
				GlobalTools.popMessage(this,"Date is not Valid!");
				GlobalTools.SetFocus(this, TXT_DATE1_D);
				inputIsValid = false;
			}
			else if (!GlobalTools.isDateValid(this,TXT_DATE2_D.Text,DDL_MONTH2_D.SelectedValue,TXT_YEAR2_D.Text))
			{
				GlobalTools.popMessage(this,"Date is not Valid!");
				GlobalTools.SetFocus(this, TXT_DATE2_D);
				inputIsValid = false;
			}
			//======================================				
			// End of Input Validation
			//======================================


			/*** // delete by last track date
			 * 
			if (TXT_APPNO_DELETE.Text.Trim().Length == 0) 
			{
				inputIsValid = false;
				LBL_RESULT_DELETE.Text = "Application Number must be filled !";
			}
			else {
				/// Cek apakah aplikasi yang dimasukkan ada atau tidak
				/// 
				conn.QueryString = "exec HOUSEKEEP_GETAPPLICATION2 'D', '" + TXT_APPNO_DELETE.Text.Trim() + "', '01'";
				conn.ExecuteQuery();
				if (conn.GetRowCount() == 0) {
					inputIsValid = false;
					LBL_RESULT_DELETE.Text = "Application is not found !";
				}
			}
			**/


			if (inputIsValid) 
			{
				string startdate = GlobalTools.ToSQLDate(TXT_DATE1_D.Text,DDL_MONTH1_D.SelectedValue,TXT_YEAR1_D.Text);
				string enddate = GlobalTools.ToSQLDate(TXT_DATE2_D.Text,DDL_MONTH2_D.SelectedValue,TXT_YEAR2_D.Text);

				StreamWriter _filePtr = null;
				_filePtr = File.AppendText(Session["fullPathLogFile"].ToString());

				try 
				{ 
					conn.QueryString = "exec HOUSEKEEP_DELETE_DATA " + startdate + ", " + enddate + ", '" + 
						DDL_RFMODULE.SelectedValue + "', '" + 
						TXT_APPNO_DELETE.Text.Trim() + "', '" + 
						Session["UserID"].ToString() + "'";
					conn.ExecTrans();

					conn.ExecTran_Commit();
					LBL_RESULT_DELETE.Text = "Deleting is Success!";

					if (_filePtr  != null) 
					{
						_filePtr.WriteLine(DateTime.Now.ToString());
						_filePtr.WriteLine("Delete housekeep database ended successfully ....");
						_filePtr.WriteLine("=================================================================================================================================");					
					}
				} 
				catch (Exception ex) 
				{
					LBL_RESULT_DELETE.Text = "Deleting is not Success! <BR>Please contact System Administrator for more information.";
					hasErrors = true;
					if (conn != null) conn.ExecTran_Rollback();				

					if (_filePtr  != null) 
					{
						_filePtr.WriteLine(DateTime.Now.ToString());
						_filePtr.WriteLine("Delete housekeep database ERROR1 :");
						_filePtr.WriteLine(ex.ToString());
						_filePtr.WriteLine("=================================================================================================================================");					
					}

					//ExceptionHandling.Handler.saveExceptionIntoWindowsLog(ex, Request.Path, "HouseKeepingDelete");
				}


				////////////////////////////////////////////////////////////////////////////////////////
				/// Delete file backup and upload/export
				/// 
				try 
				{
					if (!hasErrors) 
					{
						DateTime date1 = getDateTime(TXT_DATE1_D.Text, DDL_MONTH1_D.SelectedValue, TXT_YEAR1_D.Text);
						DateTime date2 = getDateTime(TXT_DATE2_D.Text, DDL_MONTH2_D.SelectedValue, TXT_YEAR2_D.Text);

						deleteFileUpload(TXT_APPNO_DELETE.Text, date1, date2, DDL_RFMODULE.SelectedValue);

						if (_filePtr  != null) 
						{
							_filePtr.WriteLine(DateTime.Now.ToString());
							_filePtr.WriteLine("Delete file upload ended successfully ....");
							_filePtr.WriteLine("=================================================================================================================================");					
						}
					}
				} 
				catch (Exception ex) 
				{
					try 
					{
						ExceptionHandling.Handler.saveExceptionIntoWindowsLog(ex, Request.Path, "Delete Upload File");
					} 
					catch {}
					
					if (_filePtr  != null) 
					{
						_filePtr.WriteLine(DateTime.Now.ToString());
						_filePtr.WriteLine("Delete file upload ERROR1 :");
						_filePtr.WriteLine(ex.ToString());
						_filePtr.WriteLine("=================================================================================================================================");					
					}
				}

				if (_filePtr != null) _filePtr.Close();
			}			
		}		

		protected void BTN_ARC_HISTORY_Click(object sender, System.EventArgs e)
		{
			viewHouseKeeping (BTN_ARC_HISTORY, BTN_ARC_NEXT, "Last Archived Result", LBL_TITLE_ARCHIVE, 
				LBL_ARCHIVE_COUNT, "exec HOUSEKEEP_VIEWRESULT 'A', null, null, null, '01'", 
				DGR_ARC_HISTORY, TBL_ARC_HISTORY, conn);

			/**
			if (BTN_ARC_HISTORY.Text.ToUpper().Trim().StartsWith("VIEW")) 
			{				
				LBL_TITLE_ARCHIVE.Text = "Last Archived Result";
				BTN_ARC_NEXT.Enabled = false;


				conn.QueryString = "exec HOUSEKEEP_VIEWRESULT 'A', null, null, null, '01'";
				conn.ExecuteQuery();

				DGR_ARC_HISTORY.DataSource = conn.GetDataTable().DefaultView;
				try 
				{ 
					DGR_ARC_HISTORY.DataBind(); 
				}
				catch 
				{
					DGR_ARC_HISTORY.CurrentPageIndex = 0;
					DGR_ARC_HISTORY.DataBind();
				}

				TBL_ARC_HISTORY.Visible = true;
				BTN_ARC_HISTORY.Text = BTN_ARC_HISTORY.Text.ToUpper().Replace("VIEW", "Hide");
				LBL_ARCHIVE_COUNT.Text = DGR_ARC_HISTORY.Items.Count.ToString();
			} 
			else 
			{
				LBL_TITLE_ARCHIVE.Text = "";
				BTN_ARC_NEXT.Enabled = true;


				TBL_ARC_HISTORY.Visible = false;
				BTN_ARC_HISTORY.Text = BTN_ARC_HISTORY.Text.ToUpper().Replace("HIDE", "View");
			}**/

		}

		protected void BTN_ARC_NEXT_Click(object sender, System.EventArgs e)
		{
			bool inputIsValid = true;
			//======================================				
			//	Input Validation
			//======================================
			if (!GlobalTools.isDateValid(this,TXT_DATE1.Text,DDL_MONTH1.SelectedValue,TXT_YEAR1.Text))
			{
				GlobalTools.popMessage(this,"Date is not Valid!");
				GlobalTools.SetFocus(this, TXT_DATE1);
				inputIsValid = false;
			}
			else if (!GlobalTools.isDateValid(this,TXT_DATE2.Text,DDL_MONTH2.SelectedValue,TXT_YEAR2.Text))
			{
				GlobalTools.popMessage(this,"Date is not Valid!");
				GlobalTools.SetFocus(this, TXT_DATE2);
				inputIsValid = false;
			}
			else if (TXT_YEAR2.Text == DateTime.Today.Year.ToString() && DateTime.Today.Month - Convert.ToInt32(DDL_MONTH2.SelectedValue) <= 3 ) 
			{
				GlobalTools.popMessage(this, "End Date must be 3-months-earlier than Today!");
				GlobalTools.SetFocus(this, TXT_DATE2);
				inputIsValid = false;
			}

			//======================================				
			// End of Input Validation
			//======================================				 

			if (inputIsValid) 
			{
				string startdate = GlobalTools.ToSQLDate(TXT_DATE1.Text,DDL_MONTH1.SelectedValue,TXT_YEAR1.Text);
				string enddate = GlobalTools.ToSQLDate(TXT_DATE2.Text,DDL_MONTH2.SelectedValue,TXT_YEAR2.Text);

				viewHouseKeeping (BTN_ARC_NEXT, BTN_ARC_HISTORY, "Applications to be archived", LBL_TITLE_ARCHIVE, 
					LBL_ARCHIVE_COUNT, "exec HOUSEKEEP_VIEWNEXT 'A', " + startdate + ", " + enddate + ", null, '01'", 
					DGR_ARC_HISTORY, TBL_ARC_HISTORY, conn);
			}


			/***
			if (BTN_ARC_NEXT.Text.ToUpper().Trim().StartsWith("VIEW")) 
			{			

				if (inputIsValid) 
				{
					string startdate = GlobalTools.ToSQLDate(TXT_DATE1.Text,DDL_MONTH1.SelectedValue,TXT_YEAR1.Text);
					string enddate = GlobalTools.ToSQLDate(TXT_DATE2.Text,DDL_MONTH2.SelectedValue,TXT_YEAR2.Text);

					LBL_TITLE_ARCHIVE.Text = "Applications to be archived";
					BTN_ARC_HISTORY.Enabled = false;


					conn.QueryString = "exec HOUSEKEEP_VIEWNEXT 'A', " + startdate + ", " + enddate + ", null, '01'";
					conn.ExecuteQuery();

					DGR_ARC_HISTORY.DataSource = conn.GetDataTable().DefaultView;
					try 
					{ 
						DGR_ARC_HISTORY.DataBind(); 
					}
					catch 
					{
						DGR_ARC_HISTORY.CurrentPageIndex = 0;
						DGR_ARC_HISTORY.DataBind();
					}

					TBL_ARC_HISTORY.Visible = true;
					BTN_ARC_NEXT.Text = BTN_ARC_NEXT.Text.ToUpper().Replace("VIEW", "Hide");
					LBL_ARCHIVE_COUNT.Text = DGR_ARC_HISTORY.Items.Count.ToString();
				}
			} 
			else 
			{
				LBL_TITLE_ARCHIVE.Text = "";
				BTN_ARC_HISTORY.Enabled = true;


				TBL_ARC_HISTORY.Visible = false;
				BTN_ARC_NEXT.Text = BTN_ARC_NEXT.Text.ToUpper().Replace("HIDE", "View");
			}
			***/
		}

		protected void BTN_REST_NEXT_Click(object sender, System.EventArgs e)
		{
			bool inputIsValid = true;
			//======================================				
			//	Input Validation
			//======================================
			if (!GlobalTools.isDateValid(this,TXT_DATE1_R.Text,DDL_MONTH1_R.SelectedValue,TXT_YEAR1_R.Text))
			{
				GlobalTools.popMessage(this,"Date is not Valid!");
				GlobalTools.SetFocus(this, TXT_DATE1_R);
				inputIsValid = false;
			}
			else if (!GlobalTools.isDateValid(this,TXT_DATE2_R.Text,DDL_MONTH2_R.SelectedValue,TXT_YEAR2_R.Text))
			{
				GlobalTools.popMessage(this,"Date is not Valid!");
				GlobalTools.SetFocus(this, TXT_DATE2_R);
				inputIsValid = false;
			}
			//======================================				
			// End of Input Validation
			//======================================				 

			if (inputIsValid) 
			{
				string startdate = GlobalTools.ToSQLDate(TXT_DATE1_R.Text,DDL_MONTH1_R.SelectedValue,TXT_YEAR1_R.Text);
				string enddate = GlobalTools.ToSQLDate(TXT_DATE2_R.Text,DDL_MONTH2_R.SelectedValue,TXT_YEAR2_R.Text);

				viewHouseKeeping (BTN_REST_NEXT, BTN_REST_HISTORY, "Applications to be restored", LBL_TITLE_RESTORE, 
					LBL_RESTORE_COUNT, "exec HOUSEKEEP_VIEWNEXT 'R', " + startdate + ", " + enddate + ", null, '01'", 
					DGR_REST_HISTORY, TBL_REST_HISTORY, conn);

				GlobalTools.SetFocus(this, BTN_RESTORE);
			}		
		}

		protected void BTN_REST_HISTORY_Click(object sender, System.EventArgs e)
		{
			viewHouseKeeping(BTN_REST_HISTORY, BTN_REST_NEXT, "Last Restored Result", LBL_TITLE_RESTORE, 
				LBL_RESTORE_COUNT, "exec HOUSEKEEP_VIEWRESULT 'R', null, null, null, '01'", 
				DGR_REST_HISTORY, TBL_REST_HISTORY, conn);
		}

		protected void BTN_DEL_NEXT_Click(object sender, System.EventArgs e)
		{
			bool inputIsValid = true;
			//======================================				
			//	Input Validation
			//======================================
			if (!GlobalTools.isDateValid(this,TXT_DATE1_D.Text,DDL_MONTH1_D.SelectedValue,TXT_YEAR1_D.Text))
			{
				GlobalTools.popMessage(this,"Date is not Valid!");
				GlobalTools.SetFocus(this, TXT_DATE1_D);
				inputIsValid = false;
			}
			else if (!GlobalTools.isDateValid(this,TXT_DATE2_D.Text,DDL_MONTH2_D.SelectedValue,TXT_YEAR2_D.Text))
			{
				GlobalTools.popMessage(this,"Date is not Valid!");
				GlobalTools.SetFocus(this, TXT_DATE2_D);
				inputIsValid = false;
			}
			//======================================				
			// End of Input Validation
			//======================================				 

			if (inputIsValid) 
			{
				string startdate = GlobalTools.ToSQLDate(TXT_DATE1_D.Text,DDL_MONTH1_D.SelectedValue,TXT_YEAR1_D.Text);
				string enddate = GlobalTools.ToSQLDate(TXT_DATE2_D.Text,DDL_MONTH2_D.SelectedValue,TXT_YEAR2_D.Text);

				viewHouseKeeping (BTN_DEL_NEXT, BTN_DEL_HISTORY, "Applications to be deleted", LBL_TITLE_DELETE, 
					LBL_DELETE_COUNT, "exec HOUSEKEEP_VIEWNEXT 'D', " + startdate + ", " + enddate + ", null, '01'", 
					DGR_DEL_HISTORY, TBL_DEL_HISTORY, conn);

				GlobalTools.SetFocus(this, BTN_DELETE);
			}							
		}
	}
}
