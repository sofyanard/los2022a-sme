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

namespace SME.CreditProposal
{
	/// <summary>
	/// Summary description for DetailLegalSigning.
	/// </summary>
	public partial class BiayaPKCBI : System.Web.UI.Page
	{
		protected string cust_typeid;

		protected Connection conn;
		//protected Connection conn = new Connection("Data Source=10.123.12.30;Initial Catalog=SMEDEV;uid=sa;pwd=");

		protected void Page_Load(object sender, System.EventArgs e)
		{
			conn = (Connection) Session["Connection"];

			DDL_AP_BOOKINGBRANCH.Enabled = false;
			BTN_SAVE.Enabled = false;

			if (!Logic.AllowAccess(Session["GroupID"].ToString(), Request.QueryString["mc"], conn))
				Response.Redirect("/SME/Restricted.aspx");

			//20081007, add for pipeline
			if (Request.QueryString["doc"] == "1")
			{
				TR_DOC.Visible = true;
				TR_DOC2.Visible = true;
				TBL_FILEUPLOAD.Visible = true;
			}
			else
			{
				TR_DOC.Visible = false;
				TR_DOC2.Visible = false;
				TBL_FILEUPLOAD.Visible = false;
			}

			if (!IsPostBack)
			{
				LBL_REGNO.Text = Request.QueryString["regno"];
				LBL_CUREF.Text = Request.QueryString["curef"];
				LBL_TC.Text = Request.QueryString["tc"];

				DDL_AP_BOOKINGBRANCH.Items.Add(new ListItem("- PILIH -", ""));
				conn.QueryString = "select branch_name, branch_code from rfbranch where active='1' and br_isbookingbranch = '1' order by branch_code";
				conn.ExecuteQuery();
				for (int i = 0; i < conn.GetRowCount(); i++)
					DDL_AP_BOOKINGBRANCH.Items.Add(new ListItem(conn.GetFieldValue(i,1) + " - " + conn.GetFieldValue(i,0), conn.GetFieldValue(i,1)));

				conn.QueryString = "select ap_bookingbranch from application where cu_ref ='"+LBL_CUREF.Text+"'";
				conn.ExecuteQuery();

				try { DDL_AP_BOOKINGBRANCH.SelectedValue =conn.GetFieldValue("ap_bookingbranch"); } 
				catch {}
								
				//set mandatatory
				conn.QueryString = "select cu_custtypeid from customer where cu_ref = '"+LBL_CUREF.Text+"' ";
				conn.ExecuteQuery();
				cust_typeid = conn.GetFieldValue("cu_custtypeid");

				if (cust_typeid == "01")
				{
					DDL_AP_BOOKINGBRANCH.CssClass = "mandatory";
				}
				else
				{
					DDL_AP_BOOKINGBRANCH.CssClass = "mandatory2";
				}
			


				/*
				ViewList();
				conn.QueryString = "select top 1 PRODUCTID , APPTYPE, PROD_SEQ from VW_CREOPR_NOTARYASSIGN_CREDLIST "+
					"where AP_REGNO = '"+ LBL_REGNO.Text +"' order by apptype, productid ";
				conn.ExecuteQuery();
				if(conn.GetRowCount() > 0)
				{
					string autoLoadScript = "<script language='javascript'>" +
						"document.getElementById('frm_fasilitas').src='FasilitasLegalSigning_Data.aspx?regno=" +
						LBL_REGNO.Text + "&curef=" + LBL_CUREF.Text + "&tc=" + LBL_TC.Text + "&na=" +
						Request.QueryString["na"] + "&productid=" + conn.GetFieldValue(0,0) + "&apptype=" +
						conn.GetFieldValue(0,1) + "&prod_seq=" + conn.GetFieldValue(0, "PROD_SEQ") + "';</script>";
					Page.RegisterStartupScript("LoadScript ", autoLoadScript);
				}
				*/

				ViewExportFiles();
			}

			ViewList();
			conn.QueryString = "select top 1 PRODUCTID , APPTYPE, PROD_SEQ, AP_REGNO from VW_CREOPR_NOTARYASSIGN_CREDLIST_CBI "+
				"where CU_REF = '"+ LBL_CUREF.Text +"' order by apptype, productid ";
			conn.ExecuteQuery();
			if(conn.GetRowCount() > 0)
			{
				string autoLoadScript = "<script language='javascript'>" +
					"document.getElementById('frm_fasilitas').src='FasilitasLegalSigning_Data.aspx?regno=" +
					conn.GetFieldValue(0, "AP_REGNO") + "&curef=" + LBL_CUREF.Text + "&tc=" + LBL_TC.Text + "&na=" +
					Request.QueryString["na"] + "&productid=" + conn.GetFieldValue(0,0) + "&apptype=" +
					conn.GetFieldValue(0,1) + "&prod_seq=" + conn.GetFieldValue(0, "PROD_SEQ") + "';</script>";
				Page.RegisterStartupScript("LoadScript ", autoLoadScript);
			}

			ViewMenu();
			BTN_SAVE.Attributes.Add("onclick","if(!cek_mandatory(document.Form1)){return false;};");
		}

		private void ViewMenu()
		{
			try 
			{
				conn.QueryString = "select * from SCREENMENU where menucode = '"+Request.QueryString["mc"]+"'";
				conn.ExecuteQuery();
				for (int i = 0; i < conn.GetRowCount(); i++) 
				{
					HyperLink t = new HyperLink();
					t.Text = conn.GetFieldValue(i, 2);
					t.Font.Bold = true;
					string strtemp = "";
					if (conn.GetFieldValue(i, 3).Trim()!= "") 
					{
						if (conn.GetFieldValue(i,3).IndexOf("mc=") >= 0)
							strtemp = "regno=" + Request.QueryString["regno"] + "&curef="+Request.QueryString["curef"]+"&tc="+Request.QueryString["tc"];
						else	strtemp = "regno=" + Request.QueryString["regno"] + "&curef="+Request.QueryString["curef"]+"&mc="+Request.QueryString["mc"]+"&tc="+Request.QueryString["tc"];
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

		private void ViewList()
		{
			conn.QueryString = "select distinct PRODUCTID , PRODUCTDESC , APPTYPE , APPTYPEDESC, PROD_SEQ, AP_REGNO "+
				"from VW_CREOPR_NOTARYASSIGN_CREDLIST_CBI "+
				"where CU_REF = '"+ LBL_CUREF.Text +"' order by apptype, productid ";
			conn.ExecuteQuery();
			int row = conn.GetRowCount();

//			if (row == 0)
//			{
//				conn.QueryString = "";
//				conn.ExecuteQuery();
//			}

			string productid, apptype, prod_seq;
			for (int i = 0; i < row; i++)
			{
				productid	= conn.GetFieldValue(i, 0);
				apptype		= conn.GetFieldValue(i, 2);
				prod_seq	= conn.GetFieldValue(i, "prod_seq");
				LBL_REGNO.Text = conn.GetFieldValue(i, "AP_REGNO");

				HyperLink t = new HyperLink();
				t.Text = productid + " - " + conn.GetFieldValue(i, 1) + " (" + conn.GetFieldValue(i, 3) + ") ";
				t.CssClass = "TDBGColor1";
				t.Font.Bold = true;
				
				t.NavigateUrl = "FasilitasLegalSigning_Data.aspx?regno=" + LBL_REGNO.Text + "&curef=" + LBL_CUREF.Text +
					"&tc=" + LBL_TC.Text + "&productid=" + productid + "&apptype=" + apptype + "&na=" + Request.QueryString["na"] + "&prod_seq=" + prod_seq;
				t.Target = "frm_fasilitas";
				this.TBL_FASILITAS.Rows.Add(new TableRow());
				this.TBL_FASILITAS.Rows[i].Cells.Add(new TableCell());
				this.TBL_FASILITAS.Rows[i].Cells[0].Controls.Add(t);
			}
		}

		protected void BTN_BACK_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			Response.Redirect("/SME/" + DMS.CuBESCore.Logic.backLink(Request.QueryString["tc"].ToString(), Request.QueryString["mc"].ToString(), conn));
		}

		protected void BTN_SAVE_Click(object sender, System.EventArgs e)
		{
			conn.QueryString = "update application set ap_bookingbranch ='"+DDL_AP_BOOKINGBRANCH.SelectedValue+"'"+
								" where ap_regno='"+LBL_REGNO.Text+"' and cu_ref = '"+LBL_CUREF.Text+"' ";
			conn.ExecuteQuery();

			Response.Redirect("/SME/CreditOperations/NotaryAssignment/FasilitasLegalSigning.aspx?na=2&regno="+LBL_REGNO.Text+"&curef="+LBL_CUREF.Text+"&mc="+Request.QueryString["mc"]+"&tc="+LBL_TC.Text+"");
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

					//View Export Files
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
				
			//Collecting Existing Winword in Taskbar
			Process[] oldProcess = Process.GetProcessesByName("WINWORD");
			foreach(Process thisProcess in oldProcess)
				orgId.Add(thisProcess);

			//Get Export Properties
			conn.QueryString = "SELECT * FROM VW_CHECKLISTCO_PARAMETER";
			conn.ExecuteQuery();

			if (conn.GetRowCount() > 0)
			{
				templateid = conn.GetFieldValue("CHECKLIST_TEMPLATEID");
				templatefilename = conn.GetFieldValue("CHECKLIST_TEMPLATEFILE");
				outputfilename = conn.GetFieldValue("CHECKLIST_EXPORTFILENAME") + "-" + Request.QueryString["regno"] + "-" + Session["UserID"].ToString() + ".DOC";
				templatepath = Server.MapPath(conn.GetFieldValue("TEMPLATE_PATH").Trim());
				outputpath = Server.MapPath(conn.GetFieldValue("UPLOAD_PATH").Trim());

				try
				{
					//Collectiong Existing Winword in Taskbar
					Process[] newProcess = Process.GetProcessesByName("WINWORD");
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
					conn.QueryString = "SELECT SHEET_ID, SHEET_SEQ, STOREDPROCEDURE FROM CHECKLISTCO_RFTEMPLATE WHERE TEMPLATE_ID = '" + templateid + "'";
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
							conn.QueryString = "EXEC " + proc + " '" + Request.QueryString["regno"] + "'";
							conn.ExecuteQuery();
							dt3 = conn.GetDataTable().Copy();

							//Loop for Template Detail
							conn.QueryString = "SELECT EXCEL_ROW, EXCEL_COL, DB_FIELD FROM CHECKLISTCO_RFTEMPLATE_DETAIL WHERE SHEET_ID = '" + 
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
							conn.QueryString = "EXEC CHECKLISTCO_EXPORTSAVE '1', '" + Request.QueryString["regno"] +
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
			conn.QueryString = "EXEC CHECKLISTCO_VIEWEXPORT '" + Request.QueryString["regno"] + "'";
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

		private void DATA_EXPORT_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			switch (((LinkButton)e.CommandSource).CommandName)
			{
				case "delete":
					//Get Export Properties
					conn.QueryString = "SELECT * FROM VW_CHECKLISTCO_PARAMETER";
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

						conn.QueryString = "EXEC CHECKLISTCO_EXPORTSAVE '2', '" + e.Item.Cells[0].Text +
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
