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

namespace SME.CreditProposal
{
	/// <summary>
	/// Summary description for SyaratUploadFile.
	/// </summary>
	public partial class SyaratUploadFile : System.Web.UI.Page
	{
		protected Connection conn;
		string theForm = "";
		string theObj = "";
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			conn = (Connection) Session["Connection"];
			theForm = Request.QueryString["theForm"];
			theObj = Request.QueryString["theObj"];
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

		protected void BTN_UPLOAD_Click(object sender, System.EventArgs e)
		{
			string path, initname, filename, mStatus = string.Empty, mStatusReport = string.Empty;
			conn.QueryString = "select * from VW_CP_DOCUPLOAD_PARAM";
			conn.ExecuteQuery();
			path = conn.GetFieldValue("APP_ROOT").ToString().Trim()+ conn.GetFieldValue("UPLOAD_DIR").ToString().Trim();
			initname = conn.GetFieldValue("INIT_NAME").ToString().Trim();
 
			HttpFileCollection uploadedFiles = Request.Files;
			
			int counter = 0, mField = 0;
			LBL_STATUS.Text = string.Empty;
			LBL_STATUSREPORT.Text = string.Empty;
			for (int i = 0; i < uploadedFiles.Count; i++)
			{
				HttpPostedFile userPostedFile = uploadedFiles[i];
				counter = i + 1;
				try
				{
					if (userPostedFile.ContentLength > 0)
					{
						filename = initname + "-" + Request.QueryString["regno"].Trim() + "-" + Session["USERID"].ToString() + "-" + Path.GetFileName(userPostedFile.FileName);
						userPostedFile.SaveAs(path + filename);
						LBL_STATUS.ForeColor = Color.Black;
						LBL_STATUSREPORT.ForeColor = Color.Black;
						mStatus = "Upload Successful!";
						mStatusReport = "<u>File #" + counter.ToString() + "</u><br>" + 
							"File Content Type: " + userPostedFile.ContentType + "<br>" + 
							"File Size: " + userPostedFile.ContentLength + "kb<br>" + 
							"File Name: " + userPostedFile.FileName + "<br>";
						mStatusReport += "Location Where Saved: " + path + filename + "<p>";

						int lket = initname.Length + Request.QueryString["regno"].Trim().Length + Session["USERID"].ToString().Trim().Length + 3;
						conn.QueryString = "select COVFILENAME from COVENANT_FILEUPLOAD where AP_REGNO = '" + Request.QueryString["regno"] + 
							//"' and DOCTYPEID = '" + Request.QueryString["doctype"].Trim() + 
							//"' and COVSEQ = '" + Request.QueryString["covseq"].Trim() + 
							"' and USERID = '" + Session["USERID"].ToString() + "'";
						conn.ExecuteQuery();
						for (int j = 0; j < conn.GetRowCount(); j++)
						{
							string fileNameDB = conn.GetFieldValue(j,0).Substring(lket, conn.GetFieldValue(j,0).Trim().Length - lket);
							if (fileNameDB.Trim() == Path.GetFileName(userPostedFile.FileName).Trim())
							{
								mField = mField + 1;
							}
						}

						if (mField == 0)
						{
							conn.QueryString = "exec COVENANT_FILE_UPLOAD '" + 
								Request.QueryString["regno"].Trim()+ "', '" + 
								Request.QueryString["doctype"].Trim() + "', '" + 
								Request.QueryString["covseq"].Trim() + "', '', '" + 
								filename + "', '" + 
								Session["USERID"].ToString()+ "', '1'";
							conn.ExecuteNonQuery();
							//ViewFileUpload();
						}
					}

					//Response.Write("<script language='JavaScript1.2'>window.opener.document.Form1.submit(); </script>");
					//Response.Write("<script language='JavaScript1.2'>window.close();</script>");
					string val = Path.GetFileName(userPostedFile.FileName);
                    /*
					Response.Write("<script language='JavaScript1.2'>window.opener.document." + 
						theForm + "." + theObj + ".value='" + val + "'; " +
						"window.opener.document." + theForm + ".submit();window.close();</script>");
                    */
                    Response.Write("<script language='JavaScript'>window.opener.document." +
                        "getElementById('" + theObj + "').value='" + val + "'; " +
                        "window.opener.document.getElementById('" + theForm + "').submit();window.close();</script>");
				}

				catch (Exception ex)
				{
					LBL_STATUS.ForeColor = Color.Red;
					LBL_STATUSREPORT.ForeColor = Color.Red;
					mStatus		  = "Error Uploading File";
					mStatusReport = ex.ToString();
				}
				
				LBL_STATUS.Text			= mStatus.Trim();
				LBL_STATUSREPORT.Text	= mStatusReport.Trim();
			
			}
		}
	}
}
