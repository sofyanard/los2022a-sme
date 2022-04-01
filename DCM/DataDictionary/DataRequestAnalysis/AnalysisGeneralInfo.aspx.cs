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
using System.IO;

namespace SME.DCM.DataDictionary.DataRequestAnalysis
{
	/// <summary>
	/// Summary description for AnalysisGeneralInfo.
	/// </summary>
	public partial class AnalysisGeneralInfo : System.Web.UI.Page
	{
		protected Tools tools = new Tools();
		protected Connection conn = new Connection(ConfigurationSettings.AppSettings["conn"]);
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			ViewMenu();
			if(!IsPostBack)
			{
				FillDDLPurpose();
				ViewData();
				FillGridCriteria();
				ViewUploadFiles1();
				ViewUploadFiles2();
			}
		}

		private void ViewMenu()
		{
			Menu.Controls.Clear();
			try 
			{
				conn.QueryString = "SELECT * FROM SCREENMENU WHERE MENUCODE = '" + Request.QueryString["mc"] + "'";
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
							strtemp = "&regno=" + Request.QueryString["regno"] + "&exist=1";
						else
							strtemp = "&mc=" + Request.QueryString["mc"]+ "&regno=" + Request.QueryString["regno"] + "&exist=1";
					}
					else 
					{
						strtemp = ""; 
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

		private void FillDDLPurpose()
		{
			DDL_PURPOSE.Items.Clear();
			DDL_PURPOSE.Items.Add(new ListItem("--Select--", ""));

			conn.QueryString = "SELECT * FROM VW_DD_RF_DATA_PURPOSE";
			conn.ExecuteQuery();
			for(int i=0; i < conn.GetRowCount(); i++)
			{
				DDL_PURPOSE.Items.Add(new ListItem(conn.GetFieldValue(i,1), conn.GetFieldValue(i,0)));
			}
		}

		private void ViewData()
		{
			conn.QueryString = "SELECT REQ_NUMBER, REQ_PURPOSE, CONVERT(VARCHAR, REQ_DATE, 106) AS REQ_DATE, REQ_REMARK, REQ_FILE_RESULT FROM DD_DATA_REQUEST WHERE REQ_NUMBER = '" + Request.QueryString["regno"] + "'";
			conn.ExecuteQuery();

			TXT_REQ.Text				= conn.GetFieldValue("REQ_NUMBER").ToString().Replace("&nbsp;","");
			DDL_PURPOSE.SelectedValue	= conn.GetFieldValue("REQ_PURPOSE");
			TXT_TGL.Text				= conn.GetFieldValue("REQ_DATE").ToString().Replace("&nbsp;","");
			TXT_REMARK.Text				= conn.GetFieldValue("REQ_REMARK").ToString().Replace("&nbsp;","");
			DESC_TXT.Text				= conn.GetFieldValue("REQ_FILE_RESULT").ToString().Replace("&nbsp;","");
		}

		private void FillGridCriteria()
		{
			conn.QueryString = "SELECT * FROM DD_REQ_CRITERIA WHERE AP_REGNO = '" + Request.QueryString["regno"] + "' ORDER BY SEQ";
			BindData(DATA_GRID.ID.ToString(), conn.QueryString);
		}

		private void BindData(string dataGridName, string strconn)
		{
			if(strconn != "")
			{
				conn.QueryString = strconn;
				conn.ExecuteQuery();

				System.Data.DataTable dt = new System.Data.DataTable();
				dt = conn.GetDataTable().Copy();

				System.Web.UI.WebControls.DataGrid dg = (System.Web.UI.WebControls.DataGrid)Page.FindControl(dataGridName);
				dg.DataSource = dt;

				try
				{
					dg.DataBind();
				}
				catch
				{
					dg.CurrentPageIndex = dg.PageCount - 1;	
					dg.DataBind();
				}

				conn.ClearData();
			}
		}

		private void ViewUploadFiles1()
		{
			string url = "";
			conn.QueryString = "SELECT EXPORT_URL FROM RFEXPORT WHERE EXPORT_ID = 'DATADICTIONARY01'";
			conn.ExecuteQuery();

			if (conn.GetRowCount() > 0) 
			{
				url = conn.GetFieldValue("EXPORT_URL");
				//url = /SME/JiwaServiceUpload/
			}

			conn.QueryString = "SELECT ID_UPLOAD_EXP, FILE_UPLOAD_EXP_NAME FROM DD_FILE_UPLOAD_EXP WHERE AP_REGNO = '" + Request.QueryString["regno"] + "' AND TYPE = '1'";
			conn.ExecuteQuery();

			System.Data.DataTable dt = new System.Data.DataTable();
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
				HyperLink HpDownload = (HyperLink) DATA_EXPORT.Items[i-1].Cells[2].FindControl("SCORING_DOWNLOAD");
				HpDownload.NavigateUrl = url + conn.GetFieldValue("FILE_UPLOAD_EXP_NAME");
			}
		}

		private void ViewUploadFiles2()
		{
			string url = "";
			conn.QueryString = "SELECT EXPORT_URL FROM RFEXPORT WHERE EXPORT_ID = 'DATADICTIONARY01'";
			conn.ExecuteQuery();

			if (conn.GetRowCount() > 0) 
			{
				url = conn.GetFieldValue("EXPORT_URL");
				//url = /SME/JiwaServiceUpload/
			}

			conn.QueryString = "SELECT ID_UPLOAD_EXP, FILE_UPLOAD_EXP_NAME FROM DD_FILE_UPLOAD_EXP WHERE AP_REGNO = '" + Request.QueryString["regno"] + "' AND TYPE = '2'";
			conn.ExecuteQuery();

			System.Data.DataTable dt = new System.Data.DataTable();
			dt = conn.GetDataTable().Copy();
			DGR_EXPORT.DataSource = dt;
			try 
			{
				DGR_EXPORT.DataBind();
			} 
			catch 
			{
				DGR_EXPORT.CurrentPageIndex = 0;
				DGR_EXPORT.DataBind();
			}
			for (int i = 1; i <= DGR_EXPORT.Items.Count; i++)
			{
				HyperLink HpDownload = (HyperLink) DGR_EXPORT.Items[i-1].Cells[2].FindControl("SCORING_DOWNLOAD1");
				LinkButton HpDelete = (LinkButton) DGR_EXPORT.Items[i-1].Cells[3].FindControl("SCORING_DELETE1");
				HpDownload.NavigateUrl = url + conn.GetFieldValue("FILE_UPLOAD_EXP_NAME");
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
			this.DATA_GRID.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.DATA_GRID_PageIndexChanged);
			this.DATA_EXPORT.ItemCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.DATA_EXPORT_ItemCommand);
			this.DATA_EXPORT.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.DATA_EXPORT_PageIndexChanged);
			this.DGR_EXPORT.ItemCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.DGR_EXPORT_ItemCommand);
			this.DGR_EXPORT.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.DGR_EXPORT_PageIndexChanged);

		}
		#endregion

		private void DATA_GRID_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			DATA_GRID.CurrentPageIndex = e.NewPageIndex;
			FillGridCriteria();
		}

		private void DATA_EXPORT_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			DATA_EXPORT.CurrentPageIndex = e.NewPageIndex;
			ViewUploadFiles1();
		}

		private void DATA_EXPORT_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			string directory = "";
			conn.QueryString = "SELECT EXPORT_URL FROM REKANAN_RFEXPORT WHERE EXPORT_ID = 'DATADICTIONARY01'";
			conn.ExecuteQuery();

			if(conn.GetRowCount() > 0)
			{
				directory = Server.MapPath(conn.GetFieldValue("EXPORT_URL").Trim());
			}

			/*switch(((LinkButton)e.CommandSource).CommandName)
			{
				 case "delete":
				 conn.QueryString = "EXEC DCM_DATADICTIONARY_DATAREQUESTANALYSIS_ANALYSISGENERALINFO2 ''"; //prosedur delete file
				 conn.ExecuteQuery();
				 deleteFile(directory, e.Item.Cells[0].Text);
				 ViewUploadFiles1();
				 break;
				 
			}*/
		}

		private void DGR_EXPORT_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			DGR_EXPORT.CurrentPageIndex = e.NewPageIndex;
			ViewUploadFiles2();
		}

		private void DGR_EXPORT_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			string directory = "";
			conn.QueryString = "SELECT EXPORT_URL FROM RFEXPORT WHERE EXPORT_ID = 'DATADICTIONARY01'";
			conn.ExecuteQuery();
			if (conn.GetRowCount() > 0)
			{
				directory = Server.MapPath(conn.GetFieldValue("EXPORT_URL").Trim());
			}

			switch (((LinkButton)e.CommandSource).CommandName)
			{
				case "delete":
					conn.QueryString = "DELETE DD_FILE_UPLOAD_EXP WHERE ID_UPLOAD_EXP = '" + e.Item.Cells[0].Text +
										"' AND FILE_UPLOAD_EXP_NAME = '" + e.Item.Cells[1].Text + "' AND AP_REGNO = '" + Request.QueryString["regno"] + "' AND TYPE = '2'";
					conn.ExecuteQuery();
					deleteFile(directory, e.Item.Cells[1].Text);
					ViewUploadFiles2();
					break;
			}
		}

		private void deleteFile(string directory, string filename)
		{
			if(File.Exists(directory + filename))
			{
				File.Delete(directory + filename);
			}
		}
		
		protected void BTN_UPLOAD_Click(object sender, System.EventArgs e)
		{
			string directory;
			int counter = 0;
			int max_id = 10000;
			string outputfilename = "";

			conn.QueryString = "EXEC DD_INSERT_FILE_EXP '2','" + 
								Request.QueryString["regno"] + "','" +
								Session["UserID"].ToString() + "','" +
								Path.GetFileName(TXT_FILE_UPLOAD.PostedFile.FileName) + "'";
			conn.ExecuteQuery();

			conn.QueryString = "SELECT MAX(ID_UPLOAD_EXP) AS MAX_ID FROM DD_FILE_UPLOAD_EXP WHERE AP_REGNO = '" + Request.QueryString["regno"] + "' AND TYPE = '2'";
			conn.ExecuteQuery();

			string sdfsd = conn.GetFieldValue("MAX_ID");

			if (conn.GetRowCount() > 0)
			{
				max_id = int.Parse(conn.GetFieldValue("MAX_ID"));
			}

			conn.QueryString = "SELECT FILE_UPLOAD_EXP_NAME FROM DD_FILE_UPLOAD_EXP WHERE ID_UPLOAD_EXP = '" + max_id + "' AND AP_REGNO = '" + Request.QueryString["regno"] + "' AND TYPE = '2'";
			conn.ExecuteQuery();

			if (conn.GetRowCount() > 0)
			{
				outputfilename = conn.GetFieldValue("FILE_UPLOAD_EXP_NAME");
				TXT_XLSNAME.Text = outputfilename;
			}

			conn.QueryString = "SELECT EXPORT_URL FROM RFEXPORT WHERE EXPORT_ID = 'DATADICTIONARY01'";
			conn.ExecuteQuery();

			if (conn.GetRowCount() > 0)
			{
				directory = Server.MapPath(conn.GetFieldValue("EXPORT_URL").Trim());
				//directory = /SME/JiwaServiceUpload/

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
							ViewUploadFiles2();
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
			ViewUploadFiles2();
		}

		protected void BTN_SAVE_Click(object sender, System.EventArgs e)
		{
			try
			{
				conn.QueryString = "UPDATE DD_DATA_REQUEST SET REQ_FILE_RESULT = '" + DESC_TXT.Text + "' WHERE REQ_NUMBER = '" + Request.QueryString["regno"] + "'";
				conn.ExecuteQuery();

				ViewData();
			}
			catch(Exception ex)
			{
				string errmsg = ex.Message.Replace("'","");
				if (errmsg.IndexOf("Last Query:") > 0)
					errmsg = errmsg.Substring(0, errmsg.IndexOf("Last Query:"));
				GlobalTools.popMessage(this, errmsg);
				return;
			}
		}

		protected void BTN_UPDATE_Click(object sender, System.EventArgs e)
		{
			try
			{
				conn.QueryString = "EXEC DD_TRACKUPDATE '0','" +
									Session["UserID"].ToString() + "','" +
									Request.QueryString["regno"] + "'";
				conn.ExecuteQuery();

				conn.QueryString = "UPDATE DD_DATA_REQUEST SET DATA_FLAG = '3' WHERE REQ_NUMBER = '" + Request.QueryString["regno"] + "'";
				conn.ExecuteQuery();

				BTN_SAVE.Enabled	= false;
				BTN_UPDATE.Enabled	= false;
			}
			catch(Exception ex)
			{
				string errmsg = ex.Message.Replace("'","");
				if (errmsg.IndexOf("Last Query:") > 0)
					errmsg = errmsg.Substring(0, errmsg.IndexOf("Last Query:"));
				GlobalTools.popMessage(this, errmsg);
				return;
			}
		}

		protected void BTN_BACK_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			Response.Redirect("DataRequestList.aspx?mc=" + Request.QueryString["mc"]);
		}		
	}
}
