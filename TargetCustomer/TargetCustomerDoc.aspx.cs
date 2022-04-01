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
using System.IO;
using Microsoft.VisualBasic;
using DMS.CuBESCore;
using DMS.DBConnection;

namespace SME.TargetCustomer
{
	/// <summary>
	/// Summary description for TargetCustomerDoc.
	/// </summary>
	public partial class TargetCustomerDoc : System.Web.UI.Page
	{
		protected Tools tool = new Tools();
		protected Connection conn;
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			conn = (Connection) Session["Connection"];

			if (!Logic.AllowAccess(Session["GroupID"].ToString(), Request.QueryString["mc"], conn))
				Response.Redirect("../Restricted.aspx");

			if (!IsPostBack)
			{
				ViewTemplateFiles();
				ViewUploadFiles();
			}

			ViewMenu();
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
							strtemp = "trgcuref="+Request.QueryString["trgcuref"]+"&tc="+Request.QueryString["tc"]+"&trg="+Request.QueryString["trg"];
						else	strtemp = "trgcuref="+Request.QueryString["trgcuref"]+"&mc="+Request.QueryString["mc"]+"&tc="+Request.QueryString["tc"]+"&trg="+Request.QueryString["trg"];
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

		private void ViewTemplateFiles()
		{
			System.Data.DataTable dt = new System.Data.DataTable();
			conn.QueryString = "SELECT * FROM VW_TARGETCUST_DOCUPLOAD_VIEWFILETEMPLATE";
			conn.ExecuteQuery();
			dt = conn.GetDataTable().Copy();
			DG_TEMPLATE.DataSource = dt;
			try 
			{
				DG_TEMPLATE.DataBind();
			} 
			catch 
			{
				DG_TEMPLATE.CurrentPageIndex = 0;
				DG_TEMPLATE.DataBind();
			}
			for (int i = 1; i <= DG_TEMPLATE.Items.Count; i++)
			{
				HyperLink HpDownload = (HyperLink) DG_TEMPLATE.Items[i-1].Cells[3].FindControl("HP_DOWNLOAD");
				HpDownload.NavigateUrl = DG_TEMPLATE.Items[i-1].Cells[5].Text.Trim();
			}
		}

		private void ViewUploadFiles()
		{
			System.Data.DataTable dt = new System.Data.DataTable();

			conn.QueryString = "SELECT * FROM VW_TARGETCUST_DOCUPLOAD_VIEWFILEUPLOAD WHERE TRG_CU_REF = '" + Request.QueryString["trgcuref"] + "'";
			conn.ExecuteQuery();
			dt = conn.GetDataTable().Copy();
			DG_UPLOAD.DataSource = dt;
			try 
			{
				DG_UPLOAD.DataBind();
			} 
			catch 
			{
				DG_UPLOAD.CurrentPageIndex = 0;
				DG_UPLOAD.DataBind();
			}
			for (int i = 1; i <= DG_UPLOAD.Items.Count; i++)
			{
				HyperLink HpDownload = (HyperLink) DG_UPLOAD.Items[i-1].Cells[5].FindControl("FU_DOWNLOAD");
				LinkButton HpDelete = (LinkButton) DG_UPLOAD.Items[i-1].Cells[6].FindControl("FU_DELETE");
				HpDownload.NavigateUrl = DG_UPLOAD.Items[i-1].Cells[7].Text.Trim();
				if (Session["UserID"].ToString().Trim() != DG_UPLOAD.Items[i-1].Cells[3].Text)
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

		private void UploadFile()
		{
			string directory;
			int counter = 0;
			string templateid, outputfilename, initfilename;
			
			//Get Export Properties
			conn.QueryString = "SELECT TOP 1 * FROM VW_TARGETCUST_DOCUPLOAD_PARAMETER";
			conn.ExecuteQuery();

			if (conn.GetRowCount() > 0)
			{
				directory = Server.MapPath(conn.GetFieldValue("UPLOAD_PATH").Trim());
				templateid = conn.GetFieldValue("TEMPLATE_ID");
				initfilename = conn.GetFieldValue("UPLOAD_FILEFORMAT");

				HttpFileCollection uploadedFiles = Request.Files;

				for (int i = 0; i < uploadedFiles.Count; i++)
				{
					HttpPostedFile userPostedFile = uploadedFiles[i];
					counter = i + 1;

					try
					{
						if (userPostedFile.ContentLength > 0)
						{
							outputfilename = conn.GetFieldValue("UPLOAD_FILEFORMAT").Replace("#REGNO$",Request.QueryString["trgcuref"]).Replace("#USERID$",Session["UserID"].ToString()) + "-" + Path.GetFileName(userPostedFile.FileName);
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
							conn.QueryString = "EXEC TARGETCUST_DOCUPLOAD_SAVE '1', '" + 
								Request.QueryString["trgcuref"] + "', '', '', '" + 
								Session["UserID"].ToString().Trim() + "', '" + 
								outputfilename + "'";
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
			this.DG_UPLOAD.ItemCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.DG_UPLOAD_ItemCommand);

		}
		#endregion

		protected void BTN_UPLOAD_Click(object sender, System.EventArgs e)
		{
			UploadFile();
		}

		private void DG_UPLOAD_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			switch (((LinkButton)e.CommandSource).CommandName)
			{
				case "delete":
					try 
					{					
						conn.QueryString = "SELECT TOP 1 UPLOAD_PATH FROM VW_TARGETCUST_DOCUPLOAD_PARAMETER";
						conn.ExecuteQuery();

						if (conn.GetRowCount() > 0)
						{
							string directory = Server.MapPath(conn.GetFieldValue("UPLOAD_PATH").Trim());
						
							//Delete File Physically
							deleteFile(directory, e.Item.Cells[4].Text);
							Response.Write("<!-- file : " + directory + e.Item.Cells[4].Text + " -->");
							Response.Write("<!-- file is deleted. -->");

							conn.QueryString = "EXEC TARGETCUST_DOCUPLOAD_SAVE '2', '" + 
								e.Item.Cells[0].Text + "', '" + 
								e.Item.Cells[1].Text + "', '" +
								e.Item.Cells[2].Text + "', '" + 
								Session["UserID"].ToString().Trim() + "', '" + 
								e.Item.Cells[4].Text + "'";
							conn.ExecuteQuery();

							ViewUploadFiles();
						}
					} 
					catch (Exception ex) 
					{
						Response.Write("<!-- Delete File Error: " + ex.Message.ToString() + " -->");
					}
					break;
			}
		}
	}
}
