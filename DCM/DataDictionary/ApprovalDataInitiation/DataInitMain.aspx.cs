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

namespace SME.DCM.DataDictionary.ApprovalDataInitiation
{
	/// <summary>
	/// Summary description for DataInitMain.
	/// </summary>
	public class DataInitMain : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.ImageButton BTN_BACK;
		protected System.Web.UI.WebControls.DropDownList DDL_PURPOSE;
		protected System.Web.UI.WebControls.TextBox TXT_CODE;
		protected System.Web.UI.WebControls.TextBox TXT_REQ;
		protected System.Web.UI.WebControls.TextBox TXT_TGL;
		protected System.Web.UI.WebControls.TextBox TXT_REMARK;
		protected System.Web.UI.WebControls.DataGrid DGR_CRITERIA;
		protected System.Web.UI.WebControls.Label LBL_STATUS;
		protected System.Web.UI.WebControls.RegularExpressionValidator Regularexpressionvalidator1;
		protected System.Web.UI.WebControls.Label LBL_STATUSREPORT;
		protected System.Web.UI.WebControls.DataGrid DATA_EXPORT;
		protected System.Web.UI.HtmlControls.HtmlInputFile TXT_FILE_UPLOAD;
		protected System.Web.UI.WebControls.PlaceHolder Menu;
		protected System.Web.UI.WebControls.RegularExpressionValidator RegularExpressionValidator1;
		protected System.Web.UI.WebControls.Button BTN_UPLOAD;
		protected System.Web.UI.WebControls.Label TXT_XLSNAME;
		protected Tools tools = new Tools();
		protected Connection conn = new Connection(ConfigurationSettings.AppSettings["conn"]);
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			ViewMenu();
			if(!IsPostBack)
			{
				FillDDLPurpose();
				ViewData();
				FillGridCriteria();
				ViewUploadFiles();
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
			conn.QueryString = "SELECT REQ_NUMBER, REQ_PURPOSE, CONVERT(VARCHAR, REQ_DATE, 106) AS REQ_DATE, REQ_REMARK FROM DD_DATA_REQUEST WHERE REQ_NUMBER = '" + Request.QueryString["regno"] + "'";
			conn.ExecuteQuery();

			TXT_REQ.Text				= conn.GetFieldValue("REQ_NUMBER").ToString().Replace("&nbsp;","");
			DDL_PURPOSE.SelectedValue	= conn.GetFieldValue("REQ_PURPOSE");
			TXT_TGL.Text				= conn.GetFieldValue("REQ_DATE").ToString().Replace("&nbsp;","");
			TXT_REMARK.Text				= conn.GetFieldValue("REQ_REMARK").ToString().Replace("&nbsp;","");
		}

		private void FillGridCriteria()
		{
			conn.QueryString = "SELECT * FROM DD_REQ_CRITERIA WHERE AP_REGNO = '" + Request.QueryString["regno"] + "' ORDER BY SEQ";
			BindData(DGR_CRITERIA.ID.ToString(), conn.QueryString);
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

		private void ViewUploadFiles()
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
				LinkButton HpDelete = (LinkButton) DATA_EXPORT.Items[i-1].Cells[3].FindControl("SCORING_DELETE");
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
			this.BTN_BACK.Click += new System.Web.UI.ImageClickEventHandler(this.BTN_BACK_Click);
			this.DGR_CRITERIA.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.DGR_CRITERIA_PageIndexChanged);
			this.DATA_EXPORT.ItemCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.DATA_EXPORT_ItemCommand);
			this.DATA_EXPORT.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.DATA_EXPORT_PageIndexChanged);
			this.BTN_UPLOAD.Click += new System.EventHandler(this.BTN_UPLOAD_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void DGR_CRITERIA_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			DGR_CRITERIA.CurrentPageIndex = e.NewPageIndex;
			FillGridCriteria();
		}

		private void DATA_EXPORT_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			DATA_EXPORT.CurrentPageIndex = e.NewPageIndex;
			ViewUploadFiles();
		}

		private void DATA_EXPORT_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
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
										"' AND FILE_UPLOAD_EXP_NAME = '" + e.Item.Cells[1].Text + "' AND AP_REGNO = '" + Request.QueryString["regno"] + "' AND TYPE = '1'";
					conn.ExecuteQuery();
					deleteFile(directory, e.Item.Cells[1].Text);
					ViewUploadFiles();
					break;
			}
		}

		private void deleteFile(string directory, string filename) 
		{
			if (File.Exists(directory + filename)) 
			{
				File.Delete(directory + filename);
			}
		}

		private void BTN_BACK_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			Response.Redirect("ApprDataRequestList.aspx?mc=" + Request.QueryString["mc"]);
		}

		private void BTN_UPLOAD_Click(object sender, System.EventArgs e)
		{
			string directory;
			int counter = 0;
			int max_id = 10000;
			string outputfilename = "";

			conn.QueryString = "EXEC DD_INSERT_FILE_EXP '1','" + 
								Request.QueryString["regno"] + "','" +
								Session["UserID"].ToString() + "','" +
								Path.GetFileName(TXT_FILE_UPLOAD.PostedFile.FileName) + "'";
			conn.ExecuteQuery();

			conn.QueryString = "SELECT MAX(ID_UPLOAD_EXP) AS MAX_ID FROM DD_FILE_UPLOAD_EXP WHERE AP_REGNO = '" + Request.QueryString["regno"] + "' AND TYPE = '1'";
			conn.ExecuteQuery();

			string sdfsd = conn.GetFieldValue("MAX_ID");

			if (conn.GetRowCount() > 0)
			{
				max_id = int.Parse(conn.GetFieldValue("MAX_ID"));
			}

			conn.QueryString = "SELECT FILE_UPLOAD_EXP_NAME FROM DD_FILE_UPLOAD_EXP WHERE ID_UPLOAD_EXP = '" + max_id + "' AND AP_REGNO = '" + Request.QueryString["regno"] + "' AND TYPE = '1'";
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
			ViewUploadFiles();
		}
	}
}
