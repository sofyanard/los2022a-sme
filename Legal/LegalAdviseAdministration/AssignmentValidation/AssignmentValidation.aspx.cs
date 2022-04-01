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
using System.Diagnostics;

namespace SME.Legal.LegalAdviseAdministration.AssigmentValidation
{
	/// <summary>
	/// Summary description for Main.
	/// </summary>
	public partial class Main : System.Web.UI.Page
	{
		protected Tools tools = new Tools();
		protected Connection conn = new Connection(ConfigurationSettings.AppSettings["conn"]);
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			ViewMenu();
			if(!IsPostBack)
			{
				FillDDLGroup();
				FillDDLUnit();
				FillDDLRahasia();
				
				DDL_REQUEST_MONTH.Items.Add(new ListItem("--Select--",""));
				DDL_TGL_TARGET_MONTH.Items.Add(new ListItem("--Select--",""));
				for (int i = 1; i <= 12; i++)
				{
					DDL_REQUEST_MONTH.Items.Add(new ListItem(DateAndTime.MonthName(i, false), i.ToString()));
					DDL_TGL_TARGET_MONTH.Items.Add(new ListItem(DateAndTime.MonthName(i, false), i.ToString()));
				}

				FillDDLOfficer();
				ViewData();
			}
			FillDGRDoc();
			ViewUploadFiles();
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
							strtemp = "&curef=" + Request.QueryString["curef"];
						else	
							strtemp = "&mc=" + Request.QueryString["mc"]+ "&curef=" + Request.QueryString["curef"];
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

		private void FillDDLGroup()
		{
			DDL_GROUP.Items.Clear();
			DDL_GROUP.Items.Add(new ListItem("--Select--", ""));

			conn.QueryString = "SELECT * FROM VW_LGAM_DDLGROUP";
			conn.ExecuteQuery();
			for(int i=0; i < conn.GetRowCount(); i++)
			{
				DDL_GROUP.Items.Add(new ListItem(conn.GetFieldValue(i,1), conn.GetFieldValue(i,0)));
			}
		}

		private void FillDDLUnit()
		{
			DDL_UNIT.Items.Clear();
			DDL_UNIT.Items.Add(new ListItem("--Select--", ""));

			conn.QueryString = "SELECT * FROM VW_LGAM_DDLUNIT";
			conn.ExecuteQuery();
			for(int i=0; i < conn.GetRowCount(); i++)
			{
				DDL_UNIT.Items.Add(new ListItem(conn.GetFieldValue(i,1), conn.GetFieldValue(i,0)));
			}
		}

		private void FillDDLRahasia()
		{
			DDL_STS_RAHASIA.Items.Clear();
			DDL_STS_RAHASIA.Items.Add(new ListItem("--Select--", ""));

			conn.QueryString = "SELECT CODE, [DESC] FROM RF_RAHASIA_CODE WHERE ACTIVE = '1'";
			conn.ExecuteQuery();
			for(int i=0; i < conn.GetRowCount(); i++)
			{
				DDL_STS_RAHASIA.Items.Add(new ListItem(conn.GetFieldValue(i,1), conn.GetFieldValue(i,0)));
			}
		}

		private void ViewData()
		{
			conn.QueryString = "SELECT * FROM VW_LGAM_REQUEST_LIST WHERE CU_REF = '" + Request.QueryString["curef"] + "'";
			conn.ExecuteQuery();

			TXT_REF.Text						= conn.GetFieldValue("REFERENCE").ToString().Replace("&nbsp;","");
			TXT_REQUEST_DAY.Text				= tools.FormatDate_Day(conn.GetFieldValue("REQUEST_DATE").ToString());
			DDL_REQUEST_MONTH.SelectedValue		= tools.FormatDate_Month(conn.GetFieldValue("REQUEST_DATE").ToString());
			TXT_REQUEST_YEAR.Text				= tools.FormatDate_Year(conn.GetFieldValue("REQUEST_DATE").ToString());
			DDL_GROUP.SelectedValue				= conn.GetFieldValue("REQUESTER_GROUP").ToString();
			DDL_UNIT.SelectedValue				= conn.GetFieldValue("REQUESTER_UNIT").ToString();
			TXT_PIC_REQUEST.Text				= conn.GetFieldValue("REQUESTER").ToString().Replace("&nbsp;","");
			TXT_TGL_TARGET_DAY.Text				= tools.FormatDate_Day(conn.GetFieldValue("TARGET_FINISH").ToString());
			DDL_TGL_TARGET_MONTH.SelectedValue	= tools.FormatDate_Month(conn.GetFieldValue("TARGET_FINISH").ToString());
			TXT_TGL_TARGET_YEAR.Text			= tools.FormatDate_Year(conn.GetFieldValue("TARGET_FINISH").ToString());

			if(conn.GetFieldValue("DOC_COMPLITED").ToString() != "")
			{
				RDO_DOC_KELENGKAPAN.SelectedValue	= conn.GetFieldValue("DOC_COMPLITED").ToString();
			}

			DDL_STS_RAHASIA.SelectedValue		= conn.GetFieldValue("RAHASIA_STATUS").ToString();
			TXT_REQUEST_DESC.Text				= conn.GetFieldValue("REQUEST_DESC").ToString().Replace("&nbsp;","");
			DDL_LEGAL_OFFICER.SelectedValue		= conn.GetFieldValue("LEGAL_OFFICER").ToString();

			if(conn.GetFieldValue("AP_CURRTRACK").ToString() == "LGL.3")
			{
				BTN_ASSIGN.Enabled				= false;
				BTN_CANCEL_ASSIGN.Enabled		= true;
			}

			/*if(conn.GetFieldValue("PROCESS_STATUS").ToString() == "1")
			{
				BTN_INSERT_DOC.Enabled			= false;
				BTN_UPLOAD.Enabled				= false;
				BTN_ASSIGN.Enabled				= false;
				BTN_CANCEL_ASSIGN.Enabled		= false;
				DDL_LEGAL_OFFICER.Enabled		= false;
			}*/
		}

		private void FillDDLOfficer()
		{
			DDL_LEGAL_OFFICER.Items.Clear();
			DDL_LEGAL_OFFICER.Items.Add(new ListItem("--Select--", ""));

			conn.QueryString = "SELECT * FROM VW_LGAM_LIST_LEGAL_OFFICER";
			conn.ExecuteQuery();
			for(int i=0; i < conn.GetRowCount(); i++)
			{
				DDL_LEGAL_OFFICER.Items.Add(new ListItem(conn.GetFieldValue(i,1), conn.GetFieldValue(i,0)));
			}
		}

		private void FillDGRDoc()
		{
			conn.QueryString = "SELECT * FROM LGAM_INITIATION_DOC_NAME WHERE CU_REF = '" + Request.QueryString["curef"] + "' ORDER BY SEQ";
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

		private void ViewUploadFiles()
		{
			string url = "";
			conn.QueryString = "SELECT EXPORT_URL FROM RFEXPORT WHERE EXPORT_ID = 'LEGALADVISE01'";
			conn.ExecuteQuery();

			if (conn.GetRowCount() > 0) 
			{
				url = conn.GetFieldValue("EXPORT_URL");
				//url = /SME/JiwaServiceUpload/
			}

			conn.QueryString = "SELECT ID_UPLOAD_EXP, FILE_UPLOAD_EXP_NAME FROM LGAM_FILE_UPLOAD_EXP WHERE CU_REF = '" + Request.QueryString["curef"] + "' AND TYPE = '1'";
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
			this.DATA_GRID.ItemCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.DATA_GRID_ItemCommand);
			this.DATA_GRID.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.DATA_GRID_PageIndexChanged);
			this.DATA_EXPORT.ItemCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.DATA_EXPORT_ItemCommand);
			this.DATA_EXPORT.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.DATA_EXPORT_PageIndexChanged);

		}
		#endregion

		protected void BTN_UPLOAD_Click(object sender, System.EventArgs e)
		{
			string directory;
			int counter = 0;
			int max_id = 10000;
			string outputfilename = "";

			conn.QueryString = "EXEC LGAM_INSERT_FILE_EXP '1','" + 
								Request.QueryString["curef"] + "','" +
								Session["UserID"].ToString() + "','" +
								Path.GetFileName(TXT_FILE_UPLOAD.PostedFile.FileName) + "'";
			conn.ExecuteQuery();

			conn.QueryString = "SELECT MAX(ID_UPLOAD_EXP) AS MAX_ID FROM LGAM_FILE_UPLOAD_EXP WHERE CU_REF = '" + Request.QueryString["curef"] + "' AND TYPE = '1'";
			conn.ExecuteQuery();

			string sdfsd = conn.GetFieldValue("MAX_ID");

			if (conn.GetRowCount() > 0)
			{
				max_id = int.Parse(conn.GetFieldValue("MAX_ID"));
			}

			conn.QueryString = "SELECT FILE_UPLOAD_EXP_NAME FROM LGAM_FILE_UPLOAD_EXP WHERE ID_UPLOAD_EXP = '" + max_id + "' AND CU_REF = '" + Request.QueryString["curef"] + "' AND TYPE = '1'";
			conn.ExecuteQuery();

			if (conn.GetRowCount() > 0)
			{
				outputfilename = conn.GetFieldValue("FILE_UPLOAD_EXP_NAME");
				TXT_XLSNAME.Text = outputfilename;
			}

			conn.QueryString = "SELECT EXPORT_URL FROM RFEXPORT WHERE EXPORT_ID = 'LEGALADVISE01'";
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
			}
			ViewUploadFiles();
		}

		private void DATA_GRID_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			DATA_GRID.CurrentPageIndex = e.NewPageIndex;
			FillDGRDoc();
		}

		private void DATA_GRID_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			switch(((LinkButton)e.CommandSource).CommandName)
			{
				case "delete":
					conn.QueryString = "DELETE LGAM_INITIATION_DOC_NAME WHERE SEQ = '" + e.Item.Cells[0].Text.ToString() + "' AND CU_REF = '" + Request.QueryString["curef"] + "'";
					conn.ExecuteQuery();

					FillDGRDoc();
					break;
			}
		}

		private void DATA_EXPORT_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			DATA_EXPORT.CurrentPageIndex = e.NewPageIndex;
			ViewUploadFiles();
		}

		private void DATA_EXPORT_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			string directory = "";
			conn.QueryString = "SELECT EXPORT_URL FROM RFEXPORT WHERE EXPORT_ID = 'LEGALADVISE01'";
			conn.ExecuteQuery();
			if (conn.GetRowCount() > 0)
			{
				directory = Server.MapPath(conn.GetFieldValue("EXPORT_URL").Trim());
			}

			switch (((LinkButton)e.CommandSource).CommandName)
			{
				case "delete":
					conn.QueryString = "DELETE LGAM_FILE_UPLOAD_EXP WHERE ID_UPLOAD_EXP = '" + e.Item.Cells[0].Text +
										"' AND FILE_UPLOAD_EXP_NAME = '" + e.Item.Cells[1].Text + "' AND CU_REF = '" + Request.QueryString["curef"] + "' AND TYPE = '1'";
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

		protected void BTN_BACK_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			Response.Redirect("RequestList.aspx?mc=" + Request.QueryString["mc"]);
		}

		protected void BTN_ASSIGN_Click(object sender, System.EventArgs e)
		{
			if(DDL_LEGAL_OFFICER.SelectedValue == "" || DDL_LEGAL_OFFICER.SelectedValue == null)
			{
				GlobalTools.popMessage(this, "Legal Officer Kosong!");
				return;
			}
			else
			{
				try
				{
					conn.QueryString = "EXEC LGAM_TRACKUPDATE '0','" +
										Session["UserID"].ToString() + "','" +
										Request.QueryString["curef"] + "'";
					conn.ExecuteQuery();

					conn.QueryString = "UPDATE LGAM_LEGAL_ADMIN SET LEGAL_OFFICER = '" + DDL_LEGAL_OFFICER.SelectedValue + "', PROCESS_STATUS = '0' WHERE CU_REF = '" + Request.QueryString["curef"] + "'";
					conn.ExecuteQuery();

					BTN_ASSIGN.Enabled			= false;
					BTN_CANCEL_ASSIGN.Enabled	= true;
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
		}

		protected void BTN_CANCEL_ASSIGN_Click(object sender, System.EventArgs e)
		{
			try
			{
				conn.QueryString = "EXEC LGAM_TRACKUPDATE '1','" +
									Session["UserID"].ToString() + "','" +
									Request.QueryString["curef"] + "'";
				conn.ExecuteQuery();

				conn.QueryString = "UPDATE LGAM_LEGAL_ADMIN SET LEGAL_OFFICER = '', PROCESS_STATUS = '0' WHERE CU_REF = '" + Request.QueryString["curef"] + "'";

				BTN_ASSIGN.Enabled			= true;
				BTN_CANCEL_ASSIGN.Enabled	= false;
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
	}
}
