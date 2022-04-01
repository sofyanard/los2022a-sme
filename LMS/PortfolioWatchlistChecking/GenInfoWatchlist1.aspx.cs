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
using DMS.BlackList;
using Microsoft.VisualBasic;
using System.IO;
using System.Diagnostics;

namespace SME.LMS.PortfolioWatchlistChecking
{
	/// <summary>
	/// Summary description for GenInfoWatchlist1.
	/// </summary>
	public class GenInfoWatchlist1 : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.ImageButton BTN_BACK;
		protected System.Web.UI.WebControls.Label LBL_AP_PROG_CODE;
		protected System.Web.UI.WebControls.TextBox TXT_NO_NOTA;
		protected System.Web.UI.WebControls.TextBox TXT_PERIODE;
		protected System.Web.UI.WebControls.TextBox TXT_NO_LMS;
		protected System.Web.UI.WebControls.DataGrid DATGRD_PERIODE;
		protected System.Web.UI.WebControls.DataGrid DATGRD_PORTFOLIO;
		protected System.Web.UI.WebControls.Button BTN_CLEAR_PERIODE;
		protected System.Web.UI.WebControls.Button Button1;
		protected System.Web.UI.WebControls.DataGrid Datagrid1;
		protected System.Web.UI.HtmlControls.HtmlTableCell Td1;
		protected System.Web.UI.WebControls.Label LBL_STATUS;
		protected System.Web.UI.WebControls.RegularExpressionValidator RegularExpressionValidator1;
		protected System.Web.UI.WebControls.Label LBL_STATUSREPORT;
		protected System.Web.UI.WebControls.Button BTN_UPLOAD;
		protected System.Web.UI.HtmlControls.HtmlInputFile TXT_FILE_UPLOAD;
		protected System.Web.UI.HtmlControls.HtmlTableCell Td3;
		protected System.Web.UI.WebControls.TextBox Textbox1;
		protected System.Web.UI.WebControls.Button BTN_INSERT;
		protected System.Web.UI.WebControls.TextBox TXT_TGL_NOTA;
		protected System.Web.UI.WebControls.DropDownList DDL_BLN_NOTA;
		protected System.Web.UI.WebControls.TextBox TXT_THN_NOTA;
		protected System.Web.UI.WebControls.TextBox TXT_ANALYST;
		protected System.Web.UI.HtmlControls.HtmlTableCell Td2;
		protected Connection conn;
		protected System.Web.UI.WebControls.TextBox TXT_LMS_DATE;
		protected System.Web.UI.WebControls.DataGrid DATA_EXPORT;
		protected System.Web.UI.WebControls.RegularExpressionValidator Regularexpressionvalidator1;
		protected System.Web.UI.WebControls.Label LBL_LOAN_TYPE_ID;
		protected System.Web.UI.WebControls.Button BTN_UPDATE;
		protected Tools tool = new Tools();
		protected System.Web.UI.WebControls.PlaceHolder Placeholder1;
		protected System.Web.UI.WebControls.Label HTH_PICTRACK;
		protected System.Web.UI.WebControls.Label TXT_SEND_TO;
		protected System.Web.UI.WebControls.Label TXT_SEND_BY;
		protected System.Web.UI.WebControls.PlaceHolder Menu;
		protected CommonForm.DocExport DocExport1;
			
		private void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			conn = (Connection) Session["Connection"];

			//if (!Logic.AllowAccess(Session["GroupID"].ToString(), Request.QueryString["mc"], conn))
				//Response.Redirect("/SME/Restricted.aspx");

			if (!IsPostBack)
			{				
				DDL_BLN_NOTA.Items.Add(new ListItem("--Pilih--",""));
				for(int i=1; i<=12; i++)
				{
					DDL_BLN_NOTA.Items.Add(new ListItem(DateAndTime.MonthName(i, false), i.ToString()));					
				}

				conn.QueryString = "select top 0 * from VW_PORTFOLIO_KU_FIX";
				conn.ExecuteQuery();
				FillGridPortfolio();
				
				CekCode();
				//ViewUploadFiles();
				ViewPeriodeData();

				BTN_UPDATE.Enabled = false;		
				DocExport1.GroupTemplate = "PWLPRINT";
				
			}	
			ViewAcqInfo2();	
			ViewMenu();
		}

		private void ViewPeriodeData()
		{
			conn.QueryString = "select distinct loan_type_id, loan_type from porlms_emas_data";
			conn.ExecuteQuery();

			FillGridPeriodeData();
		}

		private void FillGridPeriodeData()
		{
			DataTable dt = new DataTable();
			dt = conn.GetDataTable().Copy();
			DATGRD_PERIODE.DataSource = dt;
			try 
			{
				DATGRD_PERIODE.DataBind();
			} 
			catch 
			{
				DATGRD_PERIODE.CurrentPageIndex = 0;
				DATGRD_PERIODE.DataBind();
			}			
		}
		
		private void CekCode()
		{			
			string flag = Request.QueryString["flag"];
			 TXT_NO_LMS.Text = Request.QueryString["porlmsregno"];
			conn.QueryString = "select * from scuser where userid='"+Session["UserID"].ToString()+"' ";
			conn.ExecuteQuery();
			TXT_ANALYST.Text = conn.GetFieldValue("su_fullname") ;		
		
			if (flag=="0")
			{
				conn.QueryString = "select getdate()";
				conn.ExecuteQuery();
				TXT_LMS_DATE.Text = conn.GetFieldValue(0,0);
			}
			else
			{
				conn.QueryString = "select * from PORTFOLIO_WC where no_lms= '"+Request.QueryString["porlmsregno"]+"' ";
				conn.ExecuteQuery();
				//TXT_LMS_DATE.Text = tool.ConvertDate(conn.GetFieldValue("lms_date"));
				TXT_LMS_DATE.Text = conn.GetFieldValue("lms_date");
				TXT_NO_NOTA.Text = conn.GetFieldValue("no_nota");
				TXT_PERIODE.Text = conn.GetFieldValue("periode");
				TXT_TGL_NOTA.Text = tool.FormatDate_Day(conn.GetFieldValue("tgl_nota"));
				try{DDL_BLN_NOTA.SelectedValue = tool.FormatDate_Month(conn.GetFieldValue("tgl_nota"));}
				catch{DDL_BLN_NOTA.SelectedValue = "";}
				TXT_THN_NOTA.Text = tool.FormatDate_Year(conn.GetFieldValue("tgl_nota"));
			}
			
		}

		/*private void deleteFile(string directory, string filename) 
		{
			if (File.Exists(directory + filename)) 
			{
				File.Delete(directory + filename);
			}
		}

		/*private void ViewUploadFiles()
		{
			string url = "";
			conn.QueryString = "SELECT EXPORT_URL FROM portfolio_rfexport WHERE EXPORT_ID = '" + "daftar" + "'";
			conn.ExecuteQuery();

			if (conn.GetRowCount() > 0) 
			{
				url = conn.GetFieldValue("EXPORT_URL");
			}

			System.Data.DataTable dt = new System.Data.DataTable();
			conn.QueryString = "SELECT ID_UPLOAD_PORTFOLIO, FILE_UPLOAD_PORTFOLIO_NAME FROM PORTFOLIO_FILE_UPLOAD where NO_LMS ='" +TXT_NO_LMS.Text+ "'";
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
				HyperLink HpDownload = (HyperLink) DATA_EXPORT.Items[i-1].Cells[2].FindControl("UPL_PORTFOLIO_DOWNLOAD");
				LinkButton HpDelete = (LinkButton) DATA_EXPORT.Items[i-1].Cells[3].FindControl("UPL_PORTFOLIO_DELETE");
				HpDownload.NavigateUrl = url + conn.GetFieldValue("FILE_UPLOAD_PORTFOLIO_NAME");
			} 
		}*/

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
			this.BTN_BACK.Click += new System.Web.UI.ImageClickEventHandler(this.BTN_BACK_Click);
			this.DATGRD_PERIODE.ItemCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.DATGRD_PERIODE_ItemCommand);
			this.DATGRD_PERIODE.SelectedIndexChanged += new System.EventHandler(this.DATGRD_PERIODE_SelectedIndexChanged);
			this.DATGRD_PORTFOLIO.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.DATGRD_PORTFOLIO_PageIndexChanged);
			this.DATGRD_PORTFOLIO.SelectedIndexChanged += new System.EventHandler(this.DATGRD_PORTFOLIO_SelectedIndexChanged);
			this.Button1.Click += new System.EventHandler(this.Button1_Click);
			this.BTN_CLEAR_PERIODE.Click += new System.EventHandler(this.BTN_CLEAR_PERIODE_Click);
			//this.BTN_UPLOAD.Click += new System.EventHandler(this.BTN_UPLOAD_Click);
			//this.DATA_EXPORT.ItemCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.DATA_EXPORT_ItemCommand);
			//this.DATA_EXPORT.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.DATA_EXPORT_PageIndexChanged);
			//this.DATA_EXPORT.SelectedIndexChanged += new System.EventHandler(this.DATA_EXPORT_SelectedIndexChanged);
			this.BTN_UPDATE.Click += new System.EventHandler(this.BTN_UPDATE_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void BTN_BACK_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			Response.Redirect("PorSearchCustomer2.aspx?tc=" + Request.QueryString["tc"] + "&mc=" + Request.QueryString["mc"] );
		}

		private void BTN_CLEAR_PERIODE_Click(object sender, System.EventArgs e)
		{
			/*TXT_NO_NOTA.Text = "";
			TXT_PERIODE.Text = "";
			TXT_TGL_NOTA.Text = "";
			DDL_BLN_NOTA.SelectedValue = "";
			TXT_THN_NOTA.Text = ""; */
			conn.QueryString = "update PORLMS_RESULT_DATA set strategy='' where loan_type_id = '"+ LBL_LOAN_TYPE_ID.Text +"' and no_lms='"+Request.QueryString["porlmsregno"]+"'";
			conn.ExecuteQuery();

			if (LBL_LOAN_TYPE_ID.Text=="01")
			{
				conn.QueryString = "select * from VW_PORTFOLIO_KUP_FIX";
				conn.ExecuteQuery();
			}
			else
			{
				conn.QueryString = "select * from VW_PORTFOLIO_KU_FIX";
				conn.ExecuteQuery();
			}
			FillGridPortfolio();
		}

		private void Button1_Click(object sender, System.EventArgs e)
		{
			conn.QueryString = " exec LMSPOR_INSERT  '" +
				TXT_NO_NOTA.Text +"', '"+
				TXT_PERIODE.Text +"', '"+
				TXT_NO_LMS.Text +"', "+				
				tool.ConvertDate(TXT_TGL_NOTA.Text, DDL_BLN_NOTA.SelectedValue, TXT_THN_NOTA.Text) + ", '" +
				Session["UserID"].ToString()+"', '"+
				TXT_ANALYST.Text +"', "+
				tool.ConvertDate(TXT_LMS_DATE.Text) +" ";
			conn.ExecuteNonQuery();

			/*conn.QueryString = "select * from PORTFOLIO_WC_TRACKHISTORY where no_lms= '"+TXT_NO_LMS.Text+"' ";
			conn.ExecuteQuery();
			if (conn.GetRowCount() == 0)
			{
				conn.QueryString = " exec PORTFOLIO_WC_TRACKUPDATE '" +
					TXT_NO_LMS.Text +"', 'P1', '" + 				
					Session["UserID"].ToString()+" ', '' ";	
				conn.ExecuteNonQuery();
			}*/			

			string loan_id = LBL_LOAN_TYPE_ID.Text;
			BTN_UPDATE.Enabled = true;

			for (int i = 0; i < DATGRD_PORTFOLIO.Items.Count; i++)
			{				
				//TextBox txtnextdate_day = (TextBox) DGR_LIST.Items[i].Cells[6].FindControl("TXT_COV_NEXTDATE_DAY");
				TextBox por_strategy = (TextBox) DATGRD_PORTFOLIO.Items[i].Cells[7].FindControl("TXT_STRATEGY");
				string strategy;
				strategy=por_strategy.Text;
				//try
				//{
					/*conn.QueryString = "update porlms_emas_data set por_strategy='" + por_strategy.Text + "' " 
						+ "where buc_cd= '"+DATGRD_PORTFOLIO.Items[i].Cells[8].Text.Trim()+"' and loan_type_id='"+loan_id+"' ";	
					conn.ExecuteQuery(); */	
					
					conn.QueryString = "exec LMSPO_RSULT_INSERT '" +
						TXT_NO_LMS.Text +"', "+	
						tool.ConvertDate(TXT_LMS_DATE.Text) +", '"+
						DATGRD_PORTFOLIO.Items[i].Cells[8].Text.Trim() + "' , '" + 
						DATGRD_PORTFOLIO.Items[i].Cells[0].Text.Trim() + "' , '" + 
						DATGRD_PORTFOLIO.Items[i].Cells[2].Text.Trim() + "' , '" + 
						tool.ConvertFloat(DATGRD_PORTFOLIO.Items[i].Cells[3].Text.Trim()) + "' , '" +
						tool.ConvertFloat(DATGRD_PORTFOLIO.Items[i].Cells[4].Text.Trim()) + "' , '" +
						tool.ConvertFloat(DATGRD_PORTFOLIO.Items[i].Cells[5].Text.Trim()) + "' , '" +
						DATGRD_PORTFOLIO.Items[i].Cells[6].Text.Trim() + "' , '" + 
                        por_strategy.Text + "' , '" + 
						DATGRD_PORTFOLIO.Items[i].Cells[9].Text.Trim() + "' ";
					conn.ExecuteQuery();
							
				//}			
						
				/*catch (Exception ex)
				{					
					string errmsg = ex.Message.Replace("'","");
					if (errmsg.IndexOf("Last Query:") > 0)
						errmsg = errmsg.Substring(0, errmsg.IndexOf("Last Query:"));
					GlobalTools.popMessage(this, errmsg);
					return;
				} */
			}
		}

		private void DATA_EXPORT_SelectedIndexChanged(object sender, System.EventArgs e)
		{
		
		}

		/*private void DATA_EXPORT_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			string directory = "";
			conn.QueryString = "SELECT EXPORT_URL FROM PORTFOLIO_RFEXPORT WHERE EXPORT_ID = 'daftar'";
			conn.ExecuteQuery();
			if (conn.GetRowCount() > 0)
			{
				directory = Server.MapPath(conn.GetFieldValue("EXPORT_URL").Trim());
			}

			switch (((LinkButton)e.CommandSource).CommandName)
			{
				case "delete":
					conn.QueryString = "EXEC PORTFOLIO_DELETE_FILEDH_UPLOAD '" + e.Item.Cells[0].Text + "'";
					conn.ExecuteQuery();
					deleteFile(directory, e.Item.Cells[1].Text);
					ViewUploadFiles();
					break;
			}
		}*/

		/*private void BTN_UPLOAD_Click(object sender, System.EventArgs e)
		{
			//Cek Jumlah File
			/*conn.QueryString = "SELECT FILE_UPLOAD_PORTFOLIO_NAME from [PORTFOLIO_FILE_UPLOAD] where NO_LMS = '" + TXT_NO_LMS.Text + "'";
			conn.ExecuteQuery();
			if (conn.GetRowCount() == 1)
			{
				GlobalTools.popMessage(this, "File telah diinput, harap delete file apabila ingin mengganti file baru!");
				return;	
			}*/

			/*string directory;
			int counter = 0;
			int max_id = 10000;
			string outputfilename = "";

			if (TXT_FILE_UPLOAD.PostedFile.FileName == "")
			{
			}
			else
			{
				//Get Export Properties
				conn.QueryString = "EXEC PORTFOLIO_INSERT_FILE_UPLOAD '" +TXT_NO_LMS.Text+ "', '" + Session["USERID"].ToString() + "','" +
					Path.GetFileName(TXT_FILE_UPLOAD.PostedFile.FileName) + "'";
				conn.ExecuteQuery();
			}

			conn.QueryString = "SELECT MAX(ID_UPLOAD_PORTFOLIO) as MAX_ID from [PORTFOLIO_FILE_UPLOAD]";
			conn.ExecuteQuery();

			if (conn.GetRowCount() > 0)
			{
				max_id = int.Parse(conn.GetFieldValue("MAX_ID"));
			}

			conn.QueryString = "SELECT FILE_UPLOAD_PORTFOLIO_NAME from [PORTFOLIO_FILE_UPLOAD] where ID_UPLOAD_PORTFOLIO = '" + max_id + "'";
			conn.ExecuteQuery();

			if (conn.GetRowCount() > 0)
			{
				outputfilename = conn.GetFieldValue("FILE_UPLOAD_PORTFOLIO_NAME");
			}

			conn.QueryString = "SELECT EXPORT_URL FROM portfolio_rfexport WHERE EXPORT_ID = 'daftar'";
			conn.ExecuteQuery();

			if (conn.GetRowCount() > 0)
			{
				directory = Server.MapPath(conn.GetFieldValue("EXPORT_URL").Trim());

				HttpFileCollection uploadedFiles = Request.Files;

				for (int i = 0; i < uploadedFiles.Count; i++)
				{
					HttpPostedFile userPostedFile = uploadedFiles[i];
					counter = i + 1;

					try
					{
						if (userPostedFile.ContentLength > 0)
						{
							userPostedFile.SaveAs(directory + outputfilename);

							LBL_STATUS.ForeColor = Color.Green;
							LBL_STATUSREPORT.ForeColor = Color.Green;
							LBL_STATUS.Text = "Upload Successful!";
							LBL_STATUSREPORT.Text = "<u>File #" + counter.ToString() + "</u><br>" + 
								"File Content Type: " + userPostedFile.ContentType + "<br>" + 
								"File Size: " + userPostedFile.ContentLength + " bytes<br>" + 
								"File Name: " + userPostedFile.FileName + "<br>" +
								"Location Where Saved: " + directory + outputfilename + "<p>";

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

				try
				{
					//ReadExcel(directory + outputfilename);
				}
				catch {}
			}

			ViewUploadFiles();
		}

		*/
		private void DATGRD_PERIODE_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			switch (((LinkButton)e.CommandSource).CommandName)
			{
				case "Retrieve":
					LBL_LOAN_TYPE_ID.Text = e.Item.Cells[0].Text;
					if (LBL_LOAN_TYPE_ID.Text=="01")
					{
						conn.QueryString = "select * from VW_PORTFOLIO_KUP_FIX order by buc_cd";
						conn.ExecuteQuery();
					}
					else
					{
						conn.QueryString = "select * from VW_PORTFOLIO_KU_FIX order by buc_cd";
						conn.ExecuteQuery();
					}
					FillGridPortfolio();
					break;
			}
		}

		private void FillGridPortfolio()
		{			
			DataTable dt = new DataTable();
			dt = conn.GetDataTable().Copy();
			DATGRD_PORTFOLIO.DataSource = dt;
			try 
			{
				DATGRD_PORTFOLIO.DataBind();
			} 
			catch 
			{
				DATGRD_PORTFOLIO.CurrentPageIndex = 0;
				DATGRD_PORTFOLIO.DataBind();
			}

			for (int i=0;i<DATGRD_PORTFOLIO.Items.Count;i++)
			{
				TextBox por_strategy = (TextBox) DATGRD_PORTFOLIO.Items[i].Cells[7].FindControl("TXT_STRATEGY");
				//conn.QueryString = "select * from porlms_emas_data where buc_cd= '"+DATGRD_PORTFOLIO.Items[i].Cells[8].Text.Trim()+"' and loan_type_id='"+LBL_LOAN_TYPE_ID.Text+"'";
				conn.QueryString = "select * from PORLMS_RESULT_DATA where unit_cd= '"+DATGRD_PORTFOLIO.Items[i].Cells[8].Text.Trim()+"' and loan_type_id='"+LBL_LOAN_TYPE_ID.Text+"' and no_lms='"+Request.QueryString["porlmsregno"]+"'";
				conn.ExecuteQuery();
				//por_strategy.Text = conn.GetFieldValue("por_strategy");
				por_strategy.Text = conn.GetFieldValue("strategy");
			}
		}

		private void DATGRD_PORTFOLIO_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			DATGRD_PORTFOLIO.CurrentPageIndex = e.NewPageIndex;
			if (LBL_LOAN_TYPE_ID.Text=="01")
			{
				conn.QueryString = "select * from VW_PORTFOLIO_KUP_FIX";
				conn.ExecuteQuery();
			}
			else
			{
				conn.QueryString = "select * from VW_PORTFOLIO_KU_FIX";
				conn.ExecuteQuery();
			}

			FillGridPortfolio();		
		}

		private void DATGRD_PORTFOLIO_SelectedIndexChanged(object sender, System.EventArgs e)
		{
		
		}

		private void DATGRD_PERIODE_SelectedIndexChanged(object sender, System.EventArgs e)
		{
		
		}

		private void BTN_UPDATE_Click(object sender, System.EventArgs e)
		{
			string upliner;
			conn.QueryString = "select * from scuser where userid='" + Session["UserID"].ToString() +"'";
			conn.ExecuteQuery();
			upliner = conn.GetFieldValue("su_teamleader");

			conn.QueryString = " exec PORTFOLIO_WC_TRACKUPDATE '" +
				TXT_NO_LMS.Text +"', 'P2', '" + 				
				Session["UserID"].ToString()+" ', '"+upliner+"' ";			
			conn.ExecuteQuery();
			Response.Redirect("PorSearchCustomer2.aspx?tc=" + Request.QueryString["tc"] + "&mc=" + Request.QueryString["mc"] );
			
		}

		private void ViewAcqInfo2()
		{
			conn.QueryString = "select * from VW_PORTFOLIO_WC_USER_HISTORY where no_lms='" +TXT_NO_LMS.Text+ "' ";
			conn.ExecuteQuery();			
			TXT_SEND_BY.Text = conn.GetFieldValue("analyst_userid");

			string upliner;
			conn.QueryString = "select * from scuser where userid='" + Session["UserID"].ToString() +"'";
			conn.ExecuteQuery();
			upliner=conn.GetFieldValue("su_upliner");

			HyperLink acqInfo = new HyperLink();
			acqInfo.Text = "Acquire Information";
			acqInfo.Font.Bold = true;
			acqInfo.NavigateUrl = "AcqInfo1.aspx?no_lms=" + TXT_NO_LMS.Text + "&send_to=" + upliner + "&send_by=" + TXT_SEND_BY.Text; //+ "&sta=view";
			//Response.Write("<script for=window event=onload language='javascript'>PopupPage('ACQ.aspx?regnum=" + TXT_HRS.Text + "&send_to=" + TXT_SEND_TO.Text + "&send_by=" + TXT_SEND_BY.Text + "&theForm=Form1&theObj=TXT_TEMP', '800','350');</script>");			
			acqInfo.Target = "if2";

			conn.QueryString = "select * from VW_PORTFOLIO_WC_ACQ_APPTRACK where no_lms='" +TXT_NO_LMS.Text+ "' ";
			conn.ExecuteQuery();
			if (conn.GetFieldValue("TRACKCODE")=="P1")
			{
				Placeholder1.Controls.Add(acqInfo);
				Placeholder1.Controls.Add(new LiteralControl("&nbsp;&nbsp;&nbsp;"));

				/***
				PlaceHolder1.Controls.Add(collateral_peal);
				PlaceHolder1.Controls.Add(new LiteralControl("&nbsp;&nbsp;&nbsp;"));
				***/
			}
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

		/*private void DATA_EXPORT_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			DATA_EXPORT.CurrentPageIndex = e.NewPageIndex;
			ViewUploadFiles();
		}*/


	}
}
