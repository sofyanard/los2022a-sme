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
using System.Diagnostics;
using Microsoft.VisualBasic;
using DMS.CuBESCore;
using DMS.DBConnection;

namespace SME.LMS
{
	/// <summary>
	/// Summary description for Nota.
	/// </summary>
	public partial class Nota : System.Web.UI.Page
	{
		protected Connection conn;
		protected Tools tool = new Tools();
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			conn = (Connection) Session["Connection"];

			if (!Logic.AllowAccess(Session["GroupID"].ToString(), Request.QueryString["mc"], conn))
				Response.Redirect("../Restricted.aspx");

			if (!IsPostBack)
			{
				DDL_NOTADATE_MONTH.Items.Add(new ListItem("- PILIH -", ""));
				DDL_PENDIRIAN_MONTH.Items.Add(new ListItem("- PILIH -", ""));
				DDL_TGLPEMBUKAANREK_MONTH.Items.Add(new ListItem("- PILIH -", ""));
				DDL_TGLMASUKWATCHLIST_MONTH.Items.Add(new ListItem("- PILIH -", ""));
				DDL_TGLKOLEKTIBILITAS_N_MONTH.Items.Add(new ListItem("- PILIH -", ""));
				DDL_TGLKOLEKTIBILITAS_N1_MONTH.Items.Add(new ListItem("- PILIH -", ""));
				DDL_TGLKOLEKTIBILITAS_N2_MONTH.Items.Add(new ListItem("- PILIH -", ""));

				for (int i = 1; i <= 12; i++)
				{
					DDL_NOTADATE_MONTH.Items.Add(new ListItem(DateAndTime.MonthName(i, false), i.ToString()));
					DDL_PENDIRIAN_MONTH.Items.Add(new ListItem(DateAndTime.MonthName(i, false), i.ToString()));
					DDL_TGLPEMBUKAANREK_MONTH.Items.Add(new ListItem(DateAndTime.MonthName(i, false), i.ToString()));
					DDL_TGLMASUKWATCHLIST_MONTH.Items.Add(new ListItem(DateAndTime.MonthName(i, false), i.ToString()));
					DDL_TGLKOLEKTIBILITAS_N_MONTH.Items.Add(new ListItem(DateAndTime.MonthName(i, false), i.ToString()));
					DDL_TGLKOLEKTIBILITAS_N1_MONTH.Items.Add(new ListItem(DateAndTime.MonthName(i, false), i.ToString()));
					DDL_TGLKOLEKTIBILITAS_N2_MONTH.Items.Add(new ListItem(DateAndTime.MonthName(i, false), i.ToString()));
				}

				GlobalTools.fillRefList(DDL_STRATEGY,"SELECT * FROM VW_LMS_NOTA_FILLDDLACCOUNTSTRATEGY ",false,conn);
				
				ViewData();
				ViewExportFiles();

                DocExport1.GroupTemplate = "LMS_NOTAWATCHLIST";
			}

			ViewMenu();
			//BTN_SAVE.Attributes.Add("onclick","if(!cek_mandatory(document.Form1)){return false;};");

            TRE1.Visible = false;
            TRE2.Visible = false;
		}

		private void ViewMenu()
		{
			try 
			{
				conn.QueryString = "select * from SCREENMENU where menucode = '"+Request.QueryString["mc"]+"'";
				conn.ExecuteQuery();

				string mc1 = Request.QueryString["mc"];
				string mc2 = Request.QueryString["mc"];
				for (int i = 0; i < conn.GetRowCount(); i++) 
				{
					HyperLink t = new HyperLink();
					t.Text = conn.GetFieldValue(i, 2);
					t.Font.Bold = true;
					string strtemp = "";
					if (conn.GetFieldValue(i, 3).Trim()!= "") 
					{
						if (conn.GetFieldValue(i,3).IndexOf("mc=") >= 0)
							strtemp = "lmsreg="+Request.QueryString["lmsreg"]+"&scr="+Request.QueryString["scr"];
						else	strtemp = "lmsreg="+Request.QueryString["lmsreg"]+"&mc="+Request.QueryString["mc"]+"&scr="+Request.QueryString["scr"];
						//t.ForeColor = Color.MidnightBlue; 
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
				string temp = ex.ToString();
			}
		}

		private void ViewData()
		{
			//Data General
			try 
			{
				conn.QueryString = "EXEC LMS_NOTA_VIEWDATA_GENERAL '" + Request.QueryString["lmsreg"] + "'";
				conn.ExecuteQuery();
				
				if (conn.GetRowCount() > 0)
				{
					TXT_NOTANO.Text = conn.GetFieldValue("NOTA_NO");
					TXT_NOTADATE_DAY.Text = tool.FormatDate_Day(conn.GetFieldValue("NOTA_DATE"));
					DDL_NOTADATE_MONTH.SelectedValue = tool.FormatDate_Month(conn.GetFieldValue("NOTA_DATE"));
					TXT_NOTADATE_YEAR.Text = tool.FormatDate_Year(conn.GetFieldValue("NOTA_DATE"));

					TXT_GROUP.Text = conn.GetFieldValue("GROUPNAME");
					TXT_NAMANASABAH.Text = conn.GetFieldValue("NAMANASABAH");
					TXT_KODESEBI.Text = conn.GetFieldValue("KODESEBI");

					TXT_UNITBISNIS.Text = conn.GetFieldValue("UNITBISNIS");
					TXT_ACCMGR.Text = conn.GetFieldValue("RMNAME");
					TXT_KODESEBM.Text = conn.GetFieldValue("KODESEBM");

					TXT_TUNGGBUNGA.Text = conn.GetFieldValue("TGKBUNGA");
					TXT_TUNGGPOKOK.Text = conn.GetFieldValue("TGKPOKOK");

					TXT_OUTSTANDINGPAST3.Text = conn.GetFieldValue("OUTSTANDING_3BLNSEBELUM");
					TXT_FACAWAL.Text = conn.GetFieldValue("POSISI_FASILITAS_AWAL");

					TXT_WEWENANG.Text = conn.GetFieldValue("WEWENANG");
					TXT_WEWENANG2.Text = conn.GetFieldValue("WEWENANG2");

					TXT_RATINGKESIMPULAN.Text = conn.GetFieldValue("KESIMPULAN_RATING");

					TXT_NAMANASABAH2.Text = conn.GetFieldValue("NAMANASABAH2");
					TXT_PENDIRIAN_DAY.Text = tool.FormatDate_Day(conn.GetFieldValue("PENDIRIAN"));
					DDL_PENDIRIAN_MONTH.SelectedValue = tool.FormatDate_Month(conn.GetFieldValue("PENDIRIAN"));
					TXT_PENDIRIAN_YEAR.Text = tool.FormatDate_Year(conn.GetFieldValue("PENDIRIAN"));
					TXT_GRPUSAHA.Text = conn.GetFieldValue("GRPUSAHA");
					TXT_ALAMAT1.Text = conn.GetFieldValue("ADDR1");
					TXT_ALAMAT2.Text = conn.GetFieldValue("ADDR2");
					TXT_ALAMAT3.Text = conn.GetFieldValue("ADDr3");
					TXT_ALAMAT4.Text = conn.GetFieldValue("ADDR4");

					TXT_LOKASIPROYEK.Text = conn.GetFieldValue("LOKASIPROYEK");
					TXT_BIDUSAHA.Text = conn.GetFieldValue("BIDUSAHA");
					TXT_KEYPERSON.Text = conn.GetFieldValue("KEYPERSON");
					TXT_TAHUNHUBBANK.Text = conn.GetFieldValue("THN_HUB_BANK");
					TXT_TGLPEMBUKAANREK_DAY.Text = tool.FormatDate_Day(conn.GetFieldValue("TGL_PEMBUKAAN_REK"));
					DDL_TGLPEMBUKAANREK_MONTH.SelectedValue = tool.FormatDate_Month(conn.GetFieldValue("TGL_PEMBUKAAN_REK"));
					TXT_TGLPEMBUKAANREK_YEAR.Text = tool.FormatDate_Year(conn.GetFieldValue("TGL_PEMBUKAAN_REK"));
					TXT_TGLMASUKWATCHLIST_DAY.Text = tool.FormatDate_Day(conn.GetFieldValue("TGL_MASUK_WATCHLIST"));
					DDL_TGLMASUKWATCHLIST_MONTH.SelectedValue = tool.FormatDate_Month(conn.GetFieldValue("TGL_MASUK_WATCHLIST"));
					TXT_TGLMASUKWATCHLIST_YEAR.Text = tool.FormatDate_Year(conn.GetFieldValue("TGL_MASUK_WATCHLIST"));

					TXT_KOLEKTIBILITAS_N.Text = conn.GetFieldValue("KOLEKTIBILITAS_N");
					TXT_TGLKOLEKTIBILITAS_N_DAY.Text = tool.FormatDate_Day(conn.GetFieldValue("KOLEKTIBILITAS_N_DATE"));
					DDL_TGLKOLEKTIBILITAS_N_MONTH.SelectedValue = tool.FormatDate_Month(conn.GetFieldValue("KOLEKTIBILITAS_N_DATE"));
					TXT_TGLKOLEKTIBILITAS_N_YEAR.Text = tool.FormatDate_Year(conn.GetFieldValue("KOLEKTIBILITAS_N_DATE"));

					TXT_KOLEKTIBILITAS_N1.Text = conn.GetFieldValue("KOLEKTIBILITAS_N1");
					TXT_TGLKOLEKTIBILITAS_N1_DAY.Text = tool.FormatDate_Day(conn.GetFieldValue("KOLEKTIBILITAS_N1_DATE"));
					DDL_TGLKOLEKTIBILITAS_N1_MONTH.SelectedValue = tool.FormatDate_Month(conn.GetFieldValue("KOLEKTIBILITAS_N1_DATE"));
					TXT_TGLKOLEKTIBILITAS_N1_YEAR.Text = tool.FormatDate_Year(conn.GetFieldValue("KOLEKTIBILITAS_N1_DATE"));

					TXT_KOLEKTIBILITAS_N2.Text = conn.GetFieldValue("KOLEKTIBILITAS_N2");
					TXT_TGLKOLEKTIBILITAS_N2_DAY.Text = tool.FormatDate_Day(conn.GetFieldValue("KOLEKTIBILITAS_N2_DATE"));
					DDL_TGLKOLEKTIBILITAS_N2_MONTH.SelectedValue = tool.FormatDate_Month(conn.GetFieldValue("KOLEKTIBILITAS_N2_DATE"));
					TXT_TGLKOLEKTIBILITAS_N2_YEAR.Text = tool.FormatDate_Year(conn.GetFieldValue("KOLEKTIBILITAS_N2_DATE"));

					TXT_KOLEKTIBILITAS_KESIMPULAN.Text = conn.GetFieldValue("KESIMPULAN_KOLEKTIBILITAS");
					TXT_KONDISIKEUANGAN.Text = conn.GetFieldValue("KONDISI_KEUANGAN");
					TXT_ALASANWATCHLIST.Text = conn.GetFieldValue("ALASAN_MASUK_WATCHLIST");
					TXT_PERKEMBANGAN3BLN.Text = conn.GetFieldValue("PERKEMBANGAN_3BLNTERAKHIR");
					TXT_CALLREPORT.Text = conn.GetFieldValue("INFO_KUNJUNGAN");
					try { DDL_STRATEGY.SelectedValue = conn.GetFieldValue("ACCOUNT_STRATEGY"); }
					catch {}
					TXT_USULAN.Text = conn.GetFieldValue("USULAN");
				}
			}
			catch (Exception ex)
			{
				Response.Write("<!--" + ex.Message + "-->");
			}

			//Data Account
			try 
			{
				conn.QueryString = "EXEC LMS_NOTA_VIEWDATA_FACILITY '" + Request.QueryString["lmsreg"] + "'";
				conn.ExecuteQuery();

				DataTable dt = new DataTable();
				dt = conn.GetDataTable().Copy();
				DatGrd.DataSource = dt;
				try 
				{
					DatGrd.DataBind();
				} 
				catch 
				{
					DatGrd.CurrentPageIndex = 0;
					DatGrd.DataBind();
				}
			}
			catch (Exception ex)
			{
				Response.Write("<!--" + ex.Message + "-->");
			}

			//Data Cust Rating
			try 
			{
				conn.QueryString = "EXEC LMS_NOTA_VIEWDATA_CUSTRATING '" + Request.QueryString["lmsreg"] + "'";
				conn.ExecuteQuery();

				DataTable dt = new DataTable();
				dt = conn.GetDataTable().Copy();
				DG_CUSTRATING.DataSource = dt;
				try 
				{
					DG_CUSTRATING.DataBind();
				} 
				catch 
				{
					DG_CUSTRATING.CurrentPageIndex = 0;
					DG_CUSTRATING.DataBind();
				}
			}
			catch (Exception ex)
			{
				Response.Write("<!--" + ex.Message + "-->");
			}

			//Data Fac Rating
			try 
			{
				conn.QueryString = "EXEC LMS_NOTA_VIEWDATA_FACRATING '" + Request.QueryString["lmsreg"] + "'";
				conn.ExecuteQuery();

				DataTable dt = new DataTable();
				dt = conn.GetDataTable().Copy();
				DG_FACRATING.DataSource = dt;
				try 
				{
					DG_FACRATING.DataBind();
				} 
				catch 
				{
					DG_FACRATING.CurrentPageIndex = 0;
					DG_FACRATING.DataBind();
				}
			}
			catch (Exception ex)
			{
				Response.Write("<!--" + ex.Message + "-->");
			}
		}

		private void ClearEntry()
		{
			TXT_NOTANO.Text = "";
			TXT_NOTADATE_DAY.Text = "";
			try { DDL_NOTADATE_MONTH.SelectedValue = ""; } 
			catch{}
			TXT_NOTADATE_YEAR.Text = "";

			TXT_GROUP.Text = "";
			TXT_NAMANASABAH.Text = "";
			TXT_KODESEBI.Text = "";

			TXT_UNITBISNIS.Text = "";
			TXT_ACCMGR.Text = "";
			TXT_KODESEBM.Text = "";

			TXT_TUNGGBUNGA.Text = "";
			TXT_TUNGGPOKOK.Text = "";

			TXT_OUTSTANDINGPAST3.Text = "";
			TXT_FACAWAL.Text = "";

			TXT_WEWENANG.Text = "";
			TXT_WEWENANG2.Text = "";

			TXT_RATINGKESIMPULAN.Text = "";

			TXT_NAMANASABAH2.Text = "";
			TXT_PENDIRIAN_DAY.Text = "";
			try { DDL_PENDIRIAN_MONTH.SelectedValue = ""; } 
			catch{}
			TXT_PENDIRIAN_YEAR.Text = "";
			TXT_GRPUSAHA.Text = "";
			TXT_ALAMAT1.Text = "";
			TXT_ALAMAT2.Text = "";
			TXT_ALAMAT3.Text = "";
			TXT_ALAMAT4.Text = "";

			TXT_LOKASIPROYEK.Text = "";
			TXT_BIDUSAHA.Text = "";
			TXT_KEYPERSON.Text = "";
			TXT_TAHUNHUBBANK.Text = "";
			TXT_TGLPEMBUKAANREK_DAY.Text = "";
			try { DDL_TGLPEMBUKAANREK_MONTH.SelectedValue = ""; } 
			catch{}
			TXT_TGLPEMBUKAANREK_YEAR.Text = "";
			TXT_TGLMASUKWATCHLIST_DAY.Text = "";
			try { DDL_TGLMASUKWATCHLIST_MONTH.SelectedValue = ""; } 
			catch{}
			TXT_TGLMASUKWATCHLIST_YEAR.Text = "";

			TXT_KOLEKTIBILITAS_N.Text = "";
			TXT_TGLKOLEKTIBILITAS_N_DAY.Text = "";
			try { DDL_TGLKOLEKTIBILITAS_N_MONTH.SelectedValue = ""; } 
			catch{}
			TXT_TGLKOLEKTIBILITAS_N_YEAR.Text = "";

			TXT_KOLEKTIBILITAS_N1.Text = "";
			TXT_TGLKOLEKTIBILITAS_N1_DAY.Text = "";
			try { DDL_TGLKOLEKTIBILITAS_N1_MONTH.SelectedValue = ""; } 
			catch{}
			TXT_TGLKOLEKTIBILITAS_N1_YEAR.Text = "";

			TXT_KOLEKTIBILITAS_N2.Text = "";
			TXT_TGLKOLEKTIBILITAS_N2_DAY.Text = "";
			try { DDL_TGLKOLEKTIBILITAS_N2_MONTH.SelectedValue = ""; } 
			catch{}
			TXT_TGLKOLEKTIBILITAS_N2_YEAR.Text = "";

			TXT_KOLEKTIBILITAS_KESIMPULAN.Text = "";
			TXT_KONDISIKEUANGAN.Text = "";
			TXT_ALASANWATCHLIST.Text = "";
			TXT_PERKEMBANGAN3BLN.Text = "";
			TXT_CALLREPORT.Text = "";
			try { DDL_STRATEGY.SelectedValue = ""; }
			catch {}
			TXT_USULAN.Text = "";
		}

		private string CreateWord()
		{
			string templateid = "",
				templatefilename = "", 
				outputfilename = "", 
				templatepath = "", 
				outputpath = "";
			string returnmsg = string.Empty;
			int writeitem = 0;
			bool savestatus;

			//string fileIn = string.Empty;
			//string fileOut = string.Empty;
			object fileIn;
			object fileOut;
			System.Data.DataTable dt1;
			System.Data.DataTable dt2;
			System.Data.DataTable dt3;

			System.Threading.Thread.CurrentThread.CurrentCulture = System.Globalization.CultureInfo.CreateSpecificCulture("en-US");
			System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("en-US");

			object oMissingObject = System.Reflection.Missing.Value;
			Word.Application wordApp = null;
			Word.Document wordDoc = null;

			ArrayList orgId = new ArrayList();
			ArrayList newId = new ArrayList();

			wordApp = new Word.ApplicationClass();
			wordApp.Visible = false;
				
			//Collecting Existing Excel in Taskbar
			Process[] oldProcess = Process.GetProcessesByName("WINWORD");
			foreach(Process thisProcess in oldProcess)
				orgId.Add(thisProcess);

			//Get Export Properties
			conn.QueryString = "SELECT * FROM VW_LMS_PARAMETER";
			conn.ExecuteQuery();

			if (conn.GetRowCount() > 0)
			{
				templateid = conn.GetFieldValue("NOTA_TMPLID");
				templatefilename = conn.GetFieldValue("NOTA_TEMPLATE_FILE");
				outputfilename = conn.GetFieldValue("NOTA_INITFILENAME") + "-" + Request.QueryString["lmsreg"] + "-" + Session["UserID"].ToString() + ".DOC";
				templatepath = Server.MapPath(conn.GetFieldValue("TEMPLATE_PATH").Trim());
				outputpath = Server.MapPath(conn.GetFieldValue("UPLOAD_PATH").Trim());

				try
				{
					//Collectiong Existing Excel in Taskbar
					Process[] newProcess = Process.GetProcessesByName("EXCEL");
					foreach(Process thisProcess in newProcess)
						newId.Add(thisProcess);

					//Save process into database
					//SupportTools.saveProcessWord(wordApp, newId, orgId, conn);

					fileIn = templatepath + templatefilename;
					wordDoc = wordApp.Documents.Open(ref fileIn, ref oMissingObject, ref oMissingObject, ref oMissingObject, ref oMissingObject, ref oMissingObject, 
						ref oMissingObject, ref oMissingObject, ref oMissingObject, ref oMissingObject, ref oMissingObject, ref oMissingObject);
					wordDoc.Activate();
					Word.Bookmarks wordBookMark = (Word.Bookmarks)wordDoc.Bookmarks;

					//Loop for Template Master
					conn.QueryString = "SELECT SHEET_ID, SHEET_SEQ, STOREDPROCEDURE FROM LMS_RFTEMPLATE WHERE TEMPLATE_ID = '" + templateid + "'";
					conn.ExecuteQuery();

					dt1 = conn.GetDataTable().Copy();

					if (dt1.Rows.Count > 0)
					{
						for (int i = 0; i < dt1.Rows.Count; i++)
						{
							string sheetid = dt1.Rows[i][0].ToString().Trim();
							string sheetseq = dt1.Rows[i][1].ToString().Trim();
							string proc = dt1.Rows[i][2].ToString().Trim();

							//Query Stored Procedure
							conn.QueryString = "EXEC " + proc + " '" + Request.QueryString["lmsreg"] + "'";
							conn.ExecuteQuery();
							dt3 = conn.GetDataTable().Copy();

							//Loop for Template Detail
							conn.QueryString = "SELECT EXCEL_ROW, EXCEL_COL, DB_FIELD FROM LMS_RFTEMPLATE_DETAIL WHERE SHEET_ID = '" + 
								sheetid + "' AND SHEET_SEQ = '" + sheetseq + "' ORDER BY SEQ";
							conn.ExecuteQuery();
							dt2 = conn.GetDataTable().Copy();

							for (int k = 0; k < dt3.Rows.Count; k++)
							{
								for (int j = 0; j < dt2.Rows.Count; j++)
								{
									string xarr = dt2.Rows[j][0].ToString().Trim(); //indicating "0"=array, "1"=single data
									object wbm = dt2.Rows[j][1].ToString().Trim(); //bookmark di wordnya
									string dbfield = dt2.Rows[j][2].ToString().Trim();
									string cell_value = dt3.Rows[k][dbfield].ToString().Trim();

									if (wordBookMark.Exists(wbm.ToString()))
									{
										if (xarr == "0") cell_value = cell_value + "\n";
									
										Word.Bookmark oBook = wordBookMark.Item(ref wbm);
										oBook.Select();
										oBook.Range.Text = cell_value;
										writeitem++;
									}
								}
							}
						}

						
						//if (writeitem > 0)
						//{
						//Save Word File
						fileOut = outputpath + outputfilename;
						wordDoc.SaveAs(ref fileOut, ref oMissingObject, ref oMissingObject, ref oMissingObject, ref oMissingObject, ref oMissingObject, 
							ref oMissingObject, ref oMissingObject, ref oMissingObject, ref oMissingObject, ref oMissingObject);

						System.Threading.Thread.Sleep(TimeSpan.FromSeconds(3));

						savestatus = true;
						//}
						//else
						//{
						//	savestatus = false;
						//	returnmsg = "Error in Saving File!!";
						//	return returnmsg;
						//}

						if (savestatus == true)
						{
							//Save to Table
							conn.QueryString = "EXEC LMS_NOTA_EXPORTSAVE '1', '" + Request.QueryString["lmsreg"] +
								"', '" + templateid + "', '" + Session["UserID"].ToString().Trim() + "', '" + outputfilename + "'";
							conn.ExecuteQuery();

							//View Upload Files
							ViewExportFiles();

							returnmsg = "Export Success!!";
						}
					}
					else
					{
						returnmsg = "Template Procedure Not Yet Defined!!";
						return returnmsg;
					}
				}
				catch (Exception e)
				{
					Response.Write("<!-- " + e.Message + "\n" + e.StackTrace + " -->\n" );

					//Return Fail Message
					returnmsg = e.Message + "\n" + e.StackTrace;
				}
				finally
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
			else
			{
				returnmsg = "Export Parameter Not Yet Defined!!";
				return returnmsg;
			}
			return returnmsg;
		}

		private void ViewExportFiles()
		{
			System.Data.DataTable dt = new System.Data.DataTable();
			conn.QueryString = "EXEC LMS_NOTA_VIEWEXPORT '" + Request.QueryString["lmsreg"] + "'";
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
				HyperLink HpDownload = (HyperLink) DATA_EXPORT.Items[i-1].Cells[4].FindControl("FE_DOWNLOAD");
				LinkButton HpDelete = (LinkButton) DATA_EXPORT.Items[i-1].Cells[5].FindControl("FE_DELETE");
				HpDownload.NavigateUrl = DATA_EXPORT.Items[i-1].Cells[6].Text.Trim();
				if (Session["UserID"].ToString().Trim() != DATA_EXPORT.Items[i-1].Cells[2].Text)
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

		protected void BTN_CLEAR_Click(object sender, System.EventArgs e)
		{
			ClearEntry();
		}

		protected void BTN_SAVE_Click(object sender, System.EventArgs e)
		{
			if (TXT_NOTANO.Text.Trim() == "")
			{
				GlobalTools.popMessage(this, "No tidak boleh kosong!");
				GlobalTools.SetFocus(this, TXT_NOTANO);
				return;
			}

			if (TXT_NOTADATE_DAY.Text.Trim() == "" || DDL_NOTADATE_MONTH.SelectedValue.Trim() == "" || TXT_NOTADATE_YEAR.Text.Trim() == "")
			{
				GlobalTools.popMessage(this, "Tanggal tidak boleh kosong!");
				GlobalTools.SetFocus(this, TXT_NOTADATE_DAY);
				return;
			}

			if (!GlobalTools.isDateValid(this, TXT_NOTADATE_DAY.Text.Trim(), DDL_NOTADATE_MONTH.SelectedValue, TXT_NOTADATE_YEAR.Text.Trim())) 
			{
				GlobalTools.popMessage(this, "Tanggal Nota tidak valid!");
				GlobalTools.SetFocus(this, TXT_NOTADATE_DAY);
				return;
			}

			if (TXT_TGLPEMBUKAANREK_DAY.Text.Trim() != "" || DDL_TGLPEMBUKAANREK_MONTH.SelectedValue.Trim() != "" || TXT_TGLPEMBUKAANREK_YEAR.Text.Trim() != "")
				if (!GlobalTools.isDateValid(this, TXT_TGLPEMBUKAANREK_DAY.Text.Trim(), DDL_TGLPEMBUKAANREK_MONTH.SelectedValue, TXT_TGLPEMBUKAANREK_YEAR.Text.Trim())) 
				{
					GlobalTools.popMessage(this, "Tanggal Pembukaan Rekening tidak valid!");
					GlobalTools.SetFocus(this, TXT_TGLPEMBUKAANREK_DAY);
					return;
				}

			if (TXT_TGLMASUKWATCHLIST_DAY.Text.Trim() != "" || DDL_TGLMASUKWATCHLIST_MONTH.SelectedValue.Trim() != "" || TXT_TGLMASUKWATCHLIST_YEAR.Text.Trim() != "")
				if (!GlobalTools.isDateValid(this, TXT_TGLMASUKWATCHLIST_DAY.Text.Trim(), DDL_TGLMASUKWATCHLIST_MONTH.SelectedValue, TXT_TGLMASUKWATCHLIST_YEAR.Text.Trim())) 
				{
					GlobalTools.popMessage(this, "Tanggal Masuk Watchlist tidak valid!");
					GlobalTools.SetFocus(this, TXT_TGLMASUKWATCHLIST_DAY);
					return;
				}

			if (TXT_TGLKOLEKTIBILITAS_N_DAY.Text.Trim() != "" || DDL_TGLKOLEKTIBILITAS_N_MONTH.SelectedValue.Trim() != "" || TXT_TGLKOLEKTIBILITAS_N_YEAR.Text.Trim() != "")
				if (!GlobalTools.isDateValid(this, TXT_TGLKOLEKTIBILITAS_N_DAY.Text.Trim(), DDL_TGLKOLEKTIBILITAS_N_MONTH.SelectedValue, TXT_TGLKOLEKTIBILITAS_N_YEAR.Text.Trim())) 
				{
					GlobalTools.popMessage(this, "Tanggal Kolektibilitas tidak valid!");
					GlobalTools.SetFocus(this, TXT_TGLKOLEKTIBILITAS_N_DAY);
					return;
				}

			if (TXT_TGLKOLEKTIBILITAS_N1_DAY.Text.Trim() != "" || DDL_TGLKOLEKTIBILITAS_N1_MONTH.SelectedValue.Trim() != "" || TXT_TGLKOLEKTIBILITAS_N1_YEAR.Text.Trim() != "")
				if (!GlobalTools.isDateValid(this, TXT_TGLKOLEKTIBILITAS_N1_DAY.Text.Trim(), DDL_TGLKOLEKTIBILITAS_N1_MONTH.SelectedValue, TXT_TGLKOLEKTIBILITAS_N1_YEAR.Text.Trim())) 
				{
					GlobalTools.popMessage(this, "Tanggal Kolektibilitas tidak valid!");
					GlobalTools.SetFocus(this, TXT_TGLKOLEKTIBILITAS_N1_DAY);
					return;
				}

			if (TXT_TGLKOLEKTIBILITAS_N2_DAY.Text.Trim() != "" || DDL_TGLKOLEKTIBILITAS_N2_MONTH.SelectedValue.Trim() != "" || TXT_TGLKOLEKTIBILITAS_N2_YEAR.Text.Trim() != "")
				if (!GlobalTools.isDateValid(this, TXT_TGLKOLEKTIBILITAS_N2_DAY.Text.Trim(), DDL_TGLKOLEKTIBILITAS_N2_MONTH.SelectedValue, TXT_TGLKOLEKTIBILITAS_N2_YEAR.Text.Trim())) 
				{
					GlobalTools.popMessage(this, "Tanggal Kolektibilitas tidak valid!");
					GlobalTools.SetFocus(this, TXT_TGLKOLEKTIBILITAS_N2_DAY);
					return;
				}
			
			try 
			{
				conn.QueryString = "EXEC LMS_NOTA_SAVE '" + Request.QueryString["lmsreg"] + "', '" +
					TXT_NOTANO.Text + "', " +
					tool.ConvertDate(TXT_NOTADATE_DAY.Text, DDL_NOTADATE_MONTH.SelectedValue, TXT_NOTADATE_YEAR.Text) + ", '" +

					TXT_GROUP.Text + "', '" +
					TXT_UNITBISNIS.Text + "', '" +

					TXT_OUTSTANDINGPAST3.Text + "', '" +
					TXT_FACAWAL.Text + "', '" +

					TXT_RATINGKESIMPULAN.Text + "', '" +

					TXT_KEYPERSON.Text + "', '" +
					TXT_TAHUNHUBBANK.Text + "', " +
					tool.ConvertDate(TXT_TGLPEMBUKAANREK_DAY.Text, DDL_TGLPEMBUKAANREK_MONTH.SelectedValue, TXT_TGLPEMBUKAANREK_YEAR.Text) + ", " +
					tool.ConvertDate(TXT_TGLMASUKWATCHLIST_DAY.Text, DDL_TGLMASUKWATCHLIST_MONTH.SelectedValue, TXT_TGLMASUKWATCHLIST_YEAR.Text) + ", '" +

					TXT_KOLEKTIBILITAS_N.Text + "', " +
					tool.ConvertDate(TXT_TGLKOLEKTIBILITAS_N_DAY.Text, DDL_TGLKOLEKTIBILITAS_N_MONTH.SelectedValue, TXT_TGLKOLEKTIBILITAS_N_YEAR.Text) + ", '" +
					TXT_KOLEKTIBILITAS_N1.Text + "', " +
					tool.ConvertDate(TXT_TGLKOLEKTIBILITAS_N1_DAY.Text, DDL_TGLKOLEKTIBILITAS_N1_MONTH.SelectedValue, TXT_TGLKOLEKTIBILITAS_N1_YEAR.Text) + ", '" +
					TXT_KOLEKTIBILITAS_N2.Text + "', " +
					tool.ConvertDate(TXT_TGLKOLEKTIBILITAS_N2_DAY.Text, DDL_TGLKOLEKTIBILITAS_N2_MONTH.SelectedValue, TXT_TGLKOLEKTIBILITAS_N2_YEAR.Text) + ", '" +
					TXT_KOLEKTIBILITAS_KESIMPULAN.Text + "', '" +

					TXT_KONDISIKEUANGAN.Text + "', '" +
					TXT_ALASANWATCHLIST.Text + "', '" +
					TXT_PERKEMBANGAN3BLN.Text + "', '" +
					TXT_CALLREPORT.Text + "', '" +
					DDL_STRATEGY.SelectedValue + "', '" +
					TXT_USULAN.Text + "'";

				conn.ExecuteQuery();
			}
			catch (Exception ex)
			{
				Response.Write("<!--" + ex.Message + "-->");
			}
		}

		protected void BTN_EXPORT_Click(object sender, System.EventArgs e)
		{
			string status;
			try
			{
				status = CreateWord();
				if (status == "Export Success!!")
				{
					//Show Success Message
					LBL_STATUS_EXPORT.ForeColor	= Color.Green;
					LBL_STATUSEXPORT.ForeColor	= Color.Green;
					LBL_STATUS_EXPORT.Text		= status;
					LBL_STATUSEXPORT.Text		= "";

					//View Upload Files
					ViewExportFiles();
				}
				else
				{
					//Show Success Message
					LBL_STATUS_EXPORT.ForeColor	= Color.Red;
					LBL_STATUSEXPORT.ForeColor	= Color.Red;
					LBL_STATUS_EXPORT.Text		= "Error Exporting File!!";
					LBL_STATUSEXPORT.Text		= status;
				}
			}
			catch (Exception ex)
			{
				//Show Fail Message
				LBL_STATUS_EXPORT.ForeColor = Color.Red;
				LBL_STATUSEXPORT.ForeColor	= Color.Red;
				LBL_STATUS_EXPORT.Text		= "Error Exporting File!!";
				LBL_STATUSEXPORT.Text		= ex.Message + "\n" + ex.StackTrace;
			}
		}

		private void DATA_EXPORT_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			switch (((LinkButton)e.CommandSource).CommandName)
			{
				case "delete":
					//Get Export Properties
					conn.QueryString = "SELECT * FROM VW_LMS_PARAMETER";
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

						conn.QueryString = "EXEC LMS_NOTA_EXPORTSAVE '2', '" + e.Item.Cells[0].Text +
							"', '" + e.Item.Cells[1].Text + "', '" + e.Item.Cells[2].Text + "', '" + e.Item.Cells[3].Text + "'";
						conn.ExecuteQuery();

						//View Upload Files
						ViewExportFiles();
					}
					break;
			}
		}
	}
}
