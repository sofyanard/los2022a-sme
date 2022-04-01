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
using System.Runtime.Remoting;
using System.Diagnostics;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace SME.SPPK
{
	/// <summary>
	/// Summary description for SPPKExport.
	/// </summary>
	public partial class SPPKExport : System.Web.UI.Page
	{
		protected Connection conn;
        private SMEExportImport.WordClient client;
		string business_unit,var_user;
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			conn = (Connection) Session["Connection"];
            client = new SMEExportImport.WordClient();
			var_user = (string)Session["UserID"];

			if (!IsPostBack) 
			{
				//fillGrid(Request.QueryString["regno"]);
				ViewFileExport();

                docexport.GroupTemplate = "SPPK";
			}

			BTN_EXPORT.Attributes.Add("onclick", "if (!exportInProgress()) { return false; }");
		}

		private void fillGrid(string regno) 
		{
			System.Data.DataTable dt = new System.Data.DataTable();
			conn.QueryString = "select * from SPPK_EXPORT where AP_REGNO = '"+ regno + "'";
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
		}

		private void clearMessage()
		{
			LBL_STATUSEXPORT.Text="";
			LBL_STATUS_EXPORT.Text="";
		}


		private void ViewFileExport()
		{
			conn.QueryString = "select top 1 nota_url from rfsppk ";
			conn.ExecuteQuery();
			
			if (conn.GetRowCount() > 0) 
			{
				string url = conn.GetFieldValue("nota_url");

				fillGrid(Request.QueryString["regno"]);

				for (int i = 1; i <= DATA_EXPORT.Items.Count; i++)
				{
					HyperLink HpDownload = (HyperLink) DATA_EXPORT.Items[i-1].Cells[2].FindControl("HL_DOWNLOAD");
					LinkButton HpDelete = (LinkButton) DATA_EXPORT.Items[i-1].Cells[3].FindControl("LinkButton1");
					HpDownload.NavigateUrl = url + DATA_EXPORT.Items[i-1].Cells[1].Text.Trim();
					HpDownload.Enabled = true;
					if (var_user.ToString().Trim() != DATA_EXPORT.Items[i-1].Cells[4].Text)
						HpDelete.Visible	= false;

					if (Request.QueryString["cp"] == "0") 
					{
						
						HpDelete.Enabled = false;
					}
				}
			}
			else
			{
				fillGrid(Request.QueryString["regno"]);
			}
		}




		private string CreateSPPKWord()
		{
			//string szUser = ddl_manual.SelectedValue;
			string fileNm = string.Empty;
			string fileIn = string.Empty;
			string fileOut = string.Empty;
			string mStatus = string.Empty;
			string mNotaNumber = string.Empty;
			short Step = 0;
			object objType = Type.Missing;
			bool bSukses = true;
			object objValue = null;					
			object Bookmark ;
			string Field ;
			string strObject ;
			object objFileIn;
			object objFileOut;
			int bookmark_cnt=0;
			string vAPP_ROOT = "";


			System.Data.DataTable dt_field = null;
			System.Data.DataTable dt_field1 = null;
			System.Data.DataTable dt_field2 = null;
			System.Data.DataTable dt_field3 = null;
			System.Data.DataTable dt_field4 = null;

			
			/// Mengambil application root
			/// 
			conn.QueryString = "select APP_ROOT from APP_PARAMETER";
			conn.ExecuteQuery();
			vAPP_ROOT = conn.GetFieldValue("APP_ROOT");			


			conn.QueryString = "select * from rfsppk  " +				
				" where b_unit = '" + business_unit + "'";			
			conn.ExecuteQuery();			
				
			if (conn.GetRowCount() > 0) 
			{
				string nota = conn.GetFieldValue("NOTA_ID");
				string sheet = conn.GetFieldValue("NOTA_SHEET");
				//string path = conn.GetFieldValue("NOTA_PATH");
				string path = vAPP_ROOT + conn.GetFieldValue("NOTA_PATH");
				string file_doc = nota + ".DOT";
				//string url = conn.GetFieldValue("NOTA_URL");
				string template = conn.GetFieldValue("NOTA_TEMPLATE");
				string b_unit = conn.GetFieldValue("B_UNIT");
				string drill = conn.GetFieldValue("DRILL");

				/// Cek apakah file templatenya (input) ada atau tidak
				/// 
				if (!File.Exists(template + file_doc)) 
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


				int iItem = 0;

				object oMissingObject = System.Reflection.Missing.Value;
		
				Word.Application wordApp = null;
				Word.Document wordDoc = null;

				ArrayList orgId = new ArrayList();
				ArrayList newId = new ArrayList();
		
				//Collecting Existing Winword in Taskbar

				Process[] oldProcess = Process.GetProcessesByName("WINWORD");
				foreach(Process thisProcess in oldProcess)
					orgId.Add(thisProcess);
		
				
				try 
				{
					wordApp = new Word.ApplicationClass();
					wordApp.Visible = false;

					//Collecting Existing Winword in Taskbar 

					Process[] newProcess = Process.GetProcessesByName("WINWORD");
					foreach(Process thisProcess in newProcess)
						newId.Add(thisProcess);

					//SupportTools.saveProcessWord(wordApp, newId, orgId, conn);


					iItem = 0;
		
					string var_user="";
					fileNm = Request.QueryString["regno"] + "-" + nota + "-" + var_user + ".DOC";

					//objFileIn = path + file_doc;		
					//fileResult = url + fileNm;

					objFileIn = template + file_doc;
					objFileOut = path + fileNm;

					//wordDoc = wordApp.Documents.Open(ref objFileIn, ref oMissingObject, ref oMissingObject, ref oMissingObject, ref oMissingObject, ref oMissingObject, 
					//	ref oMissingObject, ref oMissingObject, ref oMissingObject, ref oMissingObject, ref oMissingObject, ref oMissingObject);
					wordDoc = wordApp.Documents.Add(ref objFileIn, ref oMissingObject, ref oMissingObject, ref oMissingObject);

					wordDoc.Activate();

				}
				catch (Exception e1)
				{
					Response.Write("<!-- " + e1.Message.Replace("'","") + " -->");
					LBL_STATUS_EXPORT.ForeColor = Color.Red;
					LBL_STATUSEXPORT.ForeColor = Color.Red;
					LBL_STATUS_EXPORT.Text = "Fail in creating the Objects";
					LBL_STATUSEXPORT.Text = "";
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
					}
					catch {}
					return "";
				}

				Word.Bookmarks wordBookMark = (Word.Bookmarks)wordDoc.Bookmarks;
				Word.Bookmark oBook;

				/*  SPPK compose of the followings:
					 *	1.General Info -  ( 1 time ), Category 1
					 *  2.Ketentuan Kredit ( Multiples ... depending .... )
					 *		2.1 Collaterals - depending on Ketentuan
					 *  3.Syarats ...
					 */


				#region Step Fill General Info
				// Step 1 - mask out the old codes .... dangerous 
				//conn.QueryString = "Select * from NOTA_ANALISA_DETAIL where NOTA_ID = '" + nota + "' order by NOTA_ID, SEQ";
				conn.QueryString = "Select NOTA_ID,SEQ,NOTA_COL,NOTA_ROW,NOTA_FIELD,[DESCRIPTION],BOOKMARK from rfsppkdetail where NOTA_ID = '" + nota + "' and category = 1  order by SEQ";
				conn.ExecuteQuery();

				dt_field = conn.GetDataTable().Copy();

				conn.QueryString = "exec CP_EXPORT_SPPK_GENERAL '" + Request.QueryString["regno"] + "','"+business_unit+"'";
				conn.ExecuteQuery();

				for(int j = 0; j < conn.GetRowCount(); j++)
				{
					for(int i = 0; i < dt_field.Rows.Count; i++)
					{
						try
						{
							Bookmark = dt_field.Rows[i][6];
							Field = dt_field.Rows[i][4].ToString();

							objValue = conn.GetFieldValue(Field);
				
							strObject = objValue.ToString();

							if(wordBookMark.Exists(Bookmark.ToString())) 
							{
								//strObject = Convert.ToDateTime(objValue).ToShortDateString();
								
								//Word.Bookmark oBook = wordBookMark.Item(ref Cell);
								oBook = wordBookMark.Item(ref Bookmark);
								oBook.Select();
								oBook.Range.Text = strObject;
							}
							iItem++;
						}
						catch (Exception e2)
						{
							Response.Write("<!-- " + e2.Message.Replace("'","") + " -->");
						}
					}
				}
					
				#endregion

				#region Step Fill in Ketentuan Kredit
										
				conn.QueryString = "Select NOTA_ID,SEQ,NOTA_COL,NOTA_ROW,NOTA_FIELD,[DESCRIPTION],BOOKMARK from rfsppkdetail where NOTA_ID = '" + nota + "' and category = 2  order by SEQ";					
				conn.ExecuteQuery();

				dt_field = conn.GetDataTable().Copy();


				// collaterals list
				conn.QueryString = "Select NOTA_ID,SEQ,NOTA_COL,NOTA_ROW,NOTA_FIELD,[DESCRIPTION],BOOKMARK from rfsppkdetail where NOTA_ID = '" + nota + "' and category = 3  order by SEQ";					
				conn.ExecuteQuery();

				dt_field2 = conn.GetDataTable().Copy();

				conn.QueryString = "select  distinct kk.ket_code from approval_decision ad " +
					"left join custproduct cp on ad.productid = cp.productid  and ad.ap_regno = cp.ap_regno and cp.apptype = ad.apptype and cp.prod_seq = ad.prod_seq " +
					"left join ketentuan_kredit kk on kk.ket_code = cp.ket_code " +
					"where cp.cp_reject <> 1 AND Ad.ap_regno = '" + Request.QueryString["regno"]+"' " +
					"and ad.ad_seq = (select max(ad_seq) from approval_decision where ap_regno = '"+Request.QueryString["regno"]+ "')";
				conn.ExecuteQuery();

				dt_field1 = conn.GetDataTable().Copy();


				for(int k =0; k < dt_field1.Rows.Count; k++)
				{
						
					conn.QueryString = "exec CP_EXPORT_SPPK_KETENTUAN '" + Request.QueryString["regno"] + "','" + dt_field1.Rows[k][0]+ "'";
					conn.ExecuteQuery();
					dt_field3 = conn.GetDataTable().Copy();


						
					for(int j = 0; j < dt_field3.Rows.Count; j++)  // could be multiple ketentuan ....
					{
							
						for(int i = 0; i < dt_field.Rows.Count; i++)
						{
							bookmark_cnt = i;
							try 
							{
								Field = dt_field.Rows[i][4].ToString();
								
								Bookmark = (string)(dt_field.Rows[i][6]+ k.ToString());

								objValue = dt_field3.Rows[j][Field];

								strObject = objValue.ToString();

								if(wordBookMark.Exists(Bookmark.ToString())) 
								{
									//Word.Bookmark oBook = wordBookMark.Item(ref Cell);
									oBook = wordBookMark.Item(ref Bookmark);
									oBook.Select();
									oBook.Range.Text = strObject;
								}
								iItem++;
							}
							catch (Exception e3)
							{
								Response.Write("<!-- " + e3.Message.Replace("'","") + " -->");
							}
						}  // i end
					} // j end
				
							

					conn.QueryString = "exec CP_EXPORT_SPPK_COLLATERALS '" + Request.QueryString["regno"] + "','" + dt_field1.Rows[k][0]+ "'";
					conn.ExecuteQuery();
							

					for(int i = 0; i < dt_field2.Rows.Count; i++)
					{
								
						try 
						{
							//Bookmark = dt_field2.Rows[bookmark_cnt][6];
							Bookmark = (string)(dt_field2.Rows[i][6]+ k.ToString());
							Field = dt_field2.Rows[i][4].ToString();

							for (int j = 0; j < conn.GetRowCount(); j++)
							{
								objValue = conn.GetFieldValue(j,Field);
								strObject = objValue.ToString() + "\n";

								if(wordBookMark.Exists(Bookmark.ToString())) 
								{
									//Word.Bookmark oBook = wordBookMark.Item(ref Cell);
									oBook = wordBookMark.Item(ref Bookmark);
									oBook.Select();
									oBook.Range.Text = strObject;
								}
								iItem++;
							} // end of j
						}
						catch (Exception e4)
						{
							Response.Write("<!-- " + e4.Message.Replace("'","") + " -->");
						}
					} // end of i						
				}
					
					
				#endregion

				#region Syarat-syarats
				// SYARAT TandaTangan
				conn.QueryString = "Select NOTA_ID,SEQ,NOTA_COL,NOTA_ROW,NOTA_FIELD,[DESCRIPTION],BOOKMARK from rfsppkdetail where NOTA_ID = '" + nota + "' and category = 4  order by SEQ";										
				conn.ExecuteQuery();

				dt_field = conn.GetDataTable().Copy();

				conn.QueryString = "exec CP_EXPORT_SPPK_SYARAT_TANDATANGAN '" + Request.QueryString["regno"] + "'";
				conn.ExecuteQuery();

				for(int j = 0; j < conn.GetRowCount(); j++)
				{
					for(int i = 0; i < dt_field.Rows.Count; i++)
					{
						try 
						{
							Bookmark = dt_field.Rows[i][6];							
							Field = dt_field.Rows[i][4].ToString();

							objValue = conn.GetFieldValue(j, Field);

							strObject = objValue.ToString() + "\n";

							if(wordBookMark.Exists(Bookmark.ToString())) 
							{
								//Word.Bookmark oBook = wordBookMark.Item(ref Cell);
								oBook = wordBookMark.Item(ref Bookmark);
								oBook.Select();
								oBook.Range.Text = strObject;
							}
							iItem++;
						}
						catch (Exception e5)
						{
							Response.Write("<!-- " + e5.Message.Replace("'","") + " -->");
						}
					}
				}

				// SYARAT PENRARIKAN KREDIT CL
				conn.QueryString = "Select NOTA_ID,SEQ,NOTA_COL,NOTA_ROW,NOTA_FIELD,[DESCRIPTION],BOOKMARK from rfsppkdetail where NOTA_ID = '" + nota + "' and category = 5  order by SEQ";										
				conn.ExecuteQuery();

				dt_field = conn.GetDataTable().Copy();

				conn.QueryString = "exec CP_EXPORT_SPPK_SYARAT_PENARIKAN_CL '" + Request.QueryString["regno"] + "'";
				conn.ExecuteQuery();

				for(int j = 0; j < conn.GetRowCount(); j++)
				{
					for(int i = 0; i < dt_field.Rows.Count; i++)
					{
						try 
						{
							Bookmark = dt_field.Rows[i][6];							
							Field = dt_field.Rows[i][4].ToString();

							objValue = conn.GetFieldValue(j, Field);

							strObject = objValue.ToString() + "\n";

							if(wordBookMark.Exists(Bookmark.ToString())) 
							{
								//Word.Bookmark oBook = wordBookMark.Item(ref Cell);
								oBook = wordBookMark.Item(ref Bookmark);
								oBook.Select();
								oBook.Range.Text = strObject;
							}
							iItem++;
						}
						catch (Exception e6)
						{
							Response.Write("<!-- " + e6.Message.Replace("'","") + " -->");
						}
					}
				}

				if (business_unit != "SM100") 
				{
					// SYARAT PENRARIKAN KREDIT NCL
					conn.QueryString = "Select NOTA_ID,SEQ,NOTA_COL,NOTA_ROW,NOTA_FIELD,[DESCRIPTION],BOOKMARK from rfsppkdetail where NOTA_ID = '" + nota + "' and category = 6  order by SEQ";										
					conn.ExecuteQuery();

					dt_field = conn.GetDataTable().Copy();

					conn.QueryString = "exec CP_EXPORT_SPPK_SYARAT_PENARIKAN_NCL '" + Request.QueryString["regno"] + "'";
					conn.ExecuteQuery();

					for(int j = 0; j < conn.GetRowCount(); j++)
					{
						for(int i = 0; i < dt_field.Rows.Count; i++)
						{
							try 
							{
								Bookmark = dt_field.Rows[i][6];							
								Field = dt_field.Rows[i][4].ToString();

								objValue = conn.GetFieldValue(j, Field);

								strObject = objValue.ToString() + "\n" ;

								if(wordBookMark.Exists(Bookmark.ToString())) 
								{
									//Word.Bookmark oBook = wordBookMark.Item(ref Cell);
									oBook = wordBookMark.Item(ref Bookmark);
									oBook.Select();
									oBook.Range.Text = strObject;
								}
								iItem++;
							}
							catch (Exception e7)
							{
								Response.Write("<!-- " + e7.Message.Replace("'","") + " -->");
							}
						}
					}

				}

				// SYARAT syarat lain
				conn.QueryString = "Select NOTA_ID,SEQ,NOTA_COL,NOTA_ROW,NOTA_FIELD,[DESCRIPTION],BOOKMARK from rfsppkdetail where NOTA_ID = '" + nota + "' and category = 7  order by SEQ";
				conn.ExecuteQuery();

				dt_field = conn.GetDataTable().Copy();

				conn.QueryString = "exec CP_EXPORT_SPPK_SYARAT_LAIN2 '" + Request.QueryString["regno"] + "'";
				conn.ExecuteQuery();

				for(int j = 0; j < conn.GetRowCount(); j++)
				{
					for(int i = 0; i < dt_field.Rows.Count; i++)
					{
						try 
						{
							Bookmark = dt_field.Rows[i][6];							
							Field = dt_field.Rows[i][4].ToString();

							objValue = conn.GetFieldValue(j, Field);

							strObject = objValue.ToString() + "\n";

							if(wordBookMark.Exists(Bookmark.ToString())) 
							{
								//Word.Bookmark oBook = wordBookMark.Item(ref Cell);
								oBook = wordBookMark.Item(ref Bookmark);
								oBook.Select();
								oBook.Range.Text = strObject;
							}
							iItem++;
						}
						catch (Exception e8)
						{
							Response.Write("<!-- " + e8.Message.Replace("'","") + " -->");
						}
					}
				}
				#endregion


				///* start -- simpen hasil export					

				if(iItem > 0) 
				{
					wordDoc.SaveAs(ref objFileOut, ref oMissingObject, ref oMissingObject, ref oMissingObject, ref oMissingObject, ref oMissingObject, 
						ref oMissingObject, ref oMissingObject, ref oMissingObject, ref oMissingObject, ref oMissingObject);

					System.Threading.Thread.Sleep(TimeSpan.FromSeconds(3));  																					 
					bSukses = true;
				}
				else
					bSukses = false;

				if(bSukses)	
				{
					// Maintenance Table SPPK_Export

					conn.QueryString = "exec CP_SPPK_EXPORT '" + nota +"','" + Request.QueryString["regno"] + "','" + fileNm + "','','" + Session["UserID"].ToString() + "', '1'";
					//conn.QueryString = "exec CP_SPPK_EXPORT '" + nota +"','" + Request.QueryString["regno"] + "','" + var_idExport2 + "','" + fileNm + "','', '" + Session["UserID"] + "', '1'";

					conn.ExecuteQuery();
					mStatus = "Export Succesfully";

				}
				else
				{
					mStatus = "No Data to Export";
				}



				///* end -- simpen hasil export					


				
				if(wordDoc!=null)
				{
					wordDoc.Close(ref oMissingObject, ref oMissingObject, ref oMissingObject);
					wordDoc=null;
				}
				if(wordApp!=null)
				{
					wordApp.Application.Quit(ref oMissingObject, ref oMissingObject, ref oMissingObject);
					wordApp=null;

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
				


				ViewFileExport();
				/*
				catch (Exception ex) {

					LBL_STATUS_EXPORT.ForeColor = Color.Red;
					LBL_STATUSEXPORT.ForeColor = Color.Red;

					LBL_STATUS_EXPORT.Text = "Error Exporting File!";
					LBL_STATUSEXPORT.Text = ex.ToString();
				}
				*/

			}
			return mStatus;
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
			this.DATA_EXPORT.ItemCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.DATA_EXPORT_ItemCommand);

		}
		#endregion

		protected void BTN_EXPORT_Click(object sender, System.EventArgs e)
		{
			//string szId = tool.ConvertNull(DDL_FORMAT_TYPE.SelectedValue);
			string mStatus = string.Empty ;
			string mStatusReport = string.Empty;
			
			
			business_unit = "SM100";


			//			string vIN_SMALL, vIN_MIDDLE;
			//
			//			// mengambil tipe bisnis unit dari initial
			//			
			//			conn.QueryString = "select * from rfinitial";
			//			conn.ExecuteQuery();
			//			vIN_SMALL = conn.GetFieldValue("IN_SMALL");
			//			vIN_MIDDLE = conn.GetFieldValue("IN_MIDDLE");
			//			
			//
			//
			//
			//			// mengambil tipe bisnis unit dari aplikasi
			//			conn.QueryString = "select ap_regno,ap_businessunit from application where ap_regno = '" + Request.QueryString["regno"] + "'";
			//			conn.ExecuteQuery();
			//			string tipeBusiness = conn.GetFieldValue("ap_businessunit");


			conn.QueryString = "select p.businessunit from application a " +
				" left join rfprogram p on a.prog_code = p.programid " +
				" where ap_regno = '" + Request.QueryString["regno"] + "'";
			conn.ExecuteQuery();
			
			try 
			{
				business_unit = conn.GetFieldValue("businessunit");
			}
			catch{}				
			
					
			System.Threading.Thread.CurrentThread.CurrentCulture = System.Globalization.CultureInfo.CreateSpecificCulture("en-US");
			System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("en-US");
					
			//ViewFileExport(); - ubah yourself to handle the data grid
			//mStatus = CreateSPPKWord();

            Dictionary<string, string> theresult = new Dictionary<string, string>();

            mStatus = client.SPPKExportASPXCreateSPPKWord(out theresult, Request.QueryString["regno"], Session["UserID"].ToString());
			if (mStatus.ToString().Trim() != "") 
			{
				/*
                LBL_STATUS_EXPORT.ForeColor = Color.Red;
				LBL_STATUSEXPORT.ForeColor = Color.Red;

				LBL_STATUS_EXPORT.Text = "Export Succesfully";
				LBL_STATUSEXPORT.Text = "";
                */

                for (int i = 0; i < theresult.Keys.Count; i++)
                {
                    string ID_CONTROL = theresult.Keys.ElementAt(i);

                    System.Web.UI.Control controls = this.Page.FindControl(ID_CONTROL);
                    if (controls is System.Web.UI.WebControls.TextBox)
                    {
                        ((System.Web.UI.WebControls.TextBox)controls).Text = theresult[ID_CONTROL];
                    }
                }

                ViewFileExport();
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
						string directory = @"C:\";
						conn.QueryString = "select app_root + nota_path as FULLPATH from app_parameter, rfsppk " +
							"where seq = 1 and b_unit = '" + Session["BussUnit"].ToString() + "'";
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

					conn.QueryString = "exec CP_SPPK_EXPORT '" + e.Item.Cells[0].Text +"','" + Request.QueryString["regno"] + "', '','','', '2'";
					conn.ExecuteQuery();

					ViewFileExport();
					clearMessage();					
					break;
			}
		
		}
	}
}
