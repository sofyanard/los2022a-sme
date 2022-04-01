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
	/// Summary description for Watchlist.
	/// </summary>
	public partial class Watchlist : System.Web.UI.Page
	{
		protected Connection conn;
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			conn = (Connection) Session["Connection"];

			if (!Logic.AllowAccess(Session["GroupID"].ToString(), Request.QueryString["mc"], conn))
				Response.Redirect("../Restricted.aspx");

			if (!IsPostBack)
			{
				SetButton();
				
				ViewAcquireInfo();
				ViewExposure();
				ViewUploadFiles();
				ViewSummary();
				ViewHasil();
				ViewWewenang();
				ViewAdvis();
				ViewRemark();
			}

			ViewMenu();
			InitializeEvent();
		}

		private void SetButton()
		{
			if (Request.QueryString["scr"] == "3") //Nota Watchlist
			{
				DDL_WEWENANG.Enabled = true;
				DDL_WEWENANG.CssClass = "mandatory";
				CHK_RKK.Enabled = false;
				DDL_RKK.Enabled = false;
				BTN_SAVE.Visible = true;
				TR_UPDATE.Visible = true;
				TR_ADVIS.Visible = false;
				TR_ADVISREPLY.Visible = false;
				TR_FORWARD.Visible = false;
				TR_ACCEPT.Visible = false;
				TR_ACQINFO2.Visible = false;
			}
			else if (Request.QueryString["scr"] == "4") //Acceptance Loan Review (BU)
			{
				DDL_WEWENANG.Enabled = false;
				DDL_WEWENANG.CssClass = "";
				CHK_RKK.Enabled = false;
				DDL_RKK.Enabled = false;
				BTN_SAVE.Visible = false;
				TR_UPDATE.Visible = false;
				TR_ADVIS.Visible = false;
				TR_ADVISREPLY.Visible = false;
				ViewAccept();
				TR_ACQINFO2.Visible = true;
			}
			else if (Request.QueryString["scr"] == "4b") //Acceptance Loan Review (Risk)
			{
				DDL_WEWENANG.Enabled = false;
				DDL_WEWENANG.CssClass = "";
				CHK_RKK.Enabled = true;
				DDL_RKK.Enabled = true;
				BTN_SAVE.Visible = true;
				TR_UPDATE.Visible = false;
				TR_ADVIS.Visible = true;
				TR_ADVISREPLY.Visible = false;
				ViewAccept();
				TR_ACQINFO2.Visible = true;
			}
			else if (Request.QueryString["scr"] == "5") //Advis Nota Watchlist
			{
				DDL_WEWENANG.Enabled = false;
				DDL_WEWENANG.CssClass = "";
				CHK_RKK.Enabled = false;
				DDL_RKK.Enabled = false;
				BTN_SAVE.Visible = false;
				TR_UPDATE.Visible = false;
				TR_ADVIS.Visible = false;
				TR_ADVISREPLY.Visible = true;
				TR_FORWARD.Visible = false;
				TR_ACCEPT.Visible = false;
				TR_ACQINFO2.Visible = false;
			}
			else if (Request.QueryString["scr"] == "6") //Acceptance Loan Review BOD
			{
				DDL_WEWENANG.Enabled = false;
				DDL_WEWENANG.CssClass = "";
				CHK_RKK.Enabled = false;
				DDL_RKK.Enabled = false;
				BTN_SAVE.Visible = false;
				TR_UPDATE.Visible = false;
				TR_ADVIS.Visible = false;
				TR_ADVISREPLY.Visible = false;
				TR_FORWARD.Visible = false;
				TR_ACCEPT.Visible = true;
				TR_ACQINFO2.Visible = true;
			}
			else
			{
				DDL_WEWENANG.Enabled = false;
				CHK_RKK.Enabled = false;
				DDL_RKK.Enabled = false;
				BTN_SAVE.Visible = false;
				TR_UPDATE.Visible = false;
				TR_ADVIS.Visible = false;
				TR_ADVISREPLY.Visible = false;
				TR_FORWARD.Visible = false;
				TR_ACCEPT.Visible = false;
				TR_ACQINFO2.Visible = false;
			}
		}

		private void ViewWewenang()
		{
			conn.QueryString = "exec LMS_WATCHLIST_FILLDDL_WEWENANG '" + Request.QueryString["lmsreg"] + "', '" + Session["UserID"].ToString() + "'";
			conn.ExecuteQuery();

			for (int i = 0; i < conn.GetRowCount(); i++)
			{
				DDL_WEWENANG.Items.Add(new ListItem(conn.GetFieldValue(i,"USERNAME"),conn.GetFieldValue(i,"USERID")));
			}

			/* diremark, yg bisa milih BOD di Risk
			if (conn.GetFieldValue("NEEDBOD") == "1")
			{
				CHK_RKK.Checked = true;
				CHK_RKK.Enabled = false;
				DDL_RKK.Enabled = true;
				DDL_RKK.CssClass = "mandatory";
				try { DDL_WEWENANG.SelectedIndex = DDL_WEWENANG.Items.Count - 1; }
				catch {}
				DDL_WEWENANG.Enabled = false;
			}
			else
			{
				CHK_RKK.Checked = false;
				DDL_RKK.Enabled = false;
				DDL_RKK.CssClass = "";
				try { DDL_WEWENANG.SelectedIndex = 0; }
				catch {}
				DDL_WEWENANG.Enabled = true;
			}
			*/

			GlobalTools.fillRefList(DDL_RKK,"exec LMS_WATCHLIST_FILLDDL_RKK '" + Request.QueryString["lmsreg"] + "', '" + Session["UserID"].ToString() + "'",false,conn);

			conn.QueryString = "SELECT LMS_APRVUNTIL, LMS_APRVCOMMITEE FROM LMS_APPLICATION WHERE LMS_REGNO = '" + Request.QueryString["lmsreg"] + "'";
			conn.ExecuteQuery();

			if (conn.GetRowCount() > 0)
			{
				try { DDL_WEWENANG.SelectedValue = conn.GetFieldValue("LMS_APRVUNTIL"); }
				catch {}
				if (conn.GetFieldValue("LMS_APRVCOMMITEE").ToString().Trim() != "")
				{
					CHK_RKK.Checked = true;
					try { DDL_RKK.SelectedValue = conn.GetFieldValue("LMS_APRVCOMMITEE"); }
					catch {}
					if (Request.QueryString["scr"] == "4b")
					{
						DDL_RKK.CssClass = "mandatory";
					}
				}
				else
				{
					CHK_RKK.Checked = false;
					try { DDL_RKK.SelectedValue = conn.GetFieldValue(""); }
					catch {}
				}
			}
			else
			{
				try { DDL_WEWENANG.SelectedValue = conn.GetFieldValue(""); }
				catch {}
				try { DDL_RKK.SelectedValue = conn.GetFieldValue(""); }
				catch {}
				CHK_RKK.Checked = false;
			}
		}

		private void ViewAccept()
		{
			if ((Request.QueryString["scr"] == "4") || (Request.QueryString["scr"] == "4b"))
			{
				conn.QueryString = "SELECT * FROM VW_LMS_WATCHLIST_WEWENANG WHERE LMS_REGNO = '" + Request.QueryString["lmsreg"] + "'";
				conn.ExecuteQuery();

				if (conn.GetRowCount() > 0)
				{
					if (conn.GetFieldValue("WEWENANG_BU") == Session["UserID"].ToString() ||
						conn.GetFieldValue("WEWENANG_RISK") == Session["UserID"].ToString() ||
						conn.GetFieldValue("WEWENANG_BOD") == Session["UserID"].ToString())
					{
						TR_ACCEPT.Visible = true;
						TR_FORWARD.Visible = false;
					}
					else
					{
						TR_ACCEPT.Visible = false;
						TR_FORWARD.Visible = true;
					}
				}
				else
				{
					TR_ACCEPT.Visible = false;
					TR_FORWARD.Visible = false;
				}
			}

			if (TR_FORWARD.Visible == true)
			{
				GlobalTools.fillRefList(DDL_FORWARD,"exec LMS_WATCHLIST_FILLDDL_FORWARD '" + Request.QueryString["lmsreg"] + "', '" + Session["UserID"].ToString() + "'",false,conn);
			}

			if (DDL_FORWARD.Items.Count > 1)
			{
				try
				{
					DDL_FORWARD.SelectedIndex = DDL_FORWARD.Items.Count - 1;
				}
				catch {}
			}
		}

		private void ViewExposure()
		{
			conn.QueryString = "EXEC LMS_WATCHLIST_VIEWEXPOSURE '" + Request.QueryString["lmsreg"] + "'";
			conn.ExecuteQuery();

			if (conn.GetRowCount() > 0)
			{
				TXT_EXPOSURE.Text = conn.GetFieldValue("TOTALEXPOSURE");
			}
		}

		private void ViewAdvis()
		{
			if (TR_ADVIS.Visible == true)
			{
				GlobalTools.fillRefList(DDL_ADVIS,"exec LMS_WATCHLIST_FILLDDL_ADVIS '" + Request.QueryString["lmsreg"] + "', '" + Session["UserID"].ToString() + "'",false,conn);
			}
		}

		private void UploadFile()
		{
			string directory;
			int counter = 0;
			string outputfilename;
			
			//Get Export Properties
			conn.QueryString = "SELECT * FROM VW_LMS_PARAMETER";
			conn.ExecuteQuery();

			if (conn.GetRowCount() > 0)
			{
				directory = Server.MapPath(conn.GetFieldValue("UPLOAD_PATH").Trim());

				HttpFileCollection uploadedFiles = Request.Files;

				for (int i = 0; i < uploadedFiles.Count; i++)
				{
					HttpPostedFile userPostedFile = uploadedFiles[i];
					counter = i + 1;

					try
					{
						if (userPostedFile.ContentLength > 0)
						{
							outputfilename = Request.QueryString["lmsreg"].Trim() + "-"+ Session["USERID"].ToString() +"-" + Path.GetFileName(userPostedFile.FileName);
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
							conn.QueryString = "EXEC LMS_WATCHLIST_UPLOADSAVE '1', '" + Request.QueryString["lmsreg"] +
								"', '', '" + Session["UserID"].ToString().Trim() + "', '" + outputfilename + "'";
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

		private void ViewUploadFiles()
		{
			System.Data.DataTable dt = new System.Data.DataTable();
			conn.QueryString = "EXEC LMS_WATCHLIST_VIEWUPLOAD '" + Request.QueryString["lmsreg"] + "'";
			conn.ExecuteQuery();
			dt = conn.GetDataTable().Copy();
			DatGrid.DataSource = dt;
			try 
			{
				DatGrid.DataBind();
			} 
			catch 
			{
				DatGrid.CurrentPageIndex = 0;
				DatGrid.DataBind();
			}
			for (int i = 1; i <= DatGrid.Items.Count; i++)
			{
				HyperLink HpDownload = (HyperLink) DatGrid.Items[i-1].Cells[4].FindControl("FU_DOWNLOAD");
				LinkButton HpDelete = (LinkButton) DatGrid.Items[i-1].Cells[5].FindControl("FU_DELETE");
				HpDownload.NavigateUrl = DatGrid.Items[i-1].Cells[6].Text.Trim();
				if (Session["UserID"].ToString().Trim() != DatGrid.Items[i-1].Cells[2].Text)
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

		private void ViewSummary()
		{
			conn.QueryString = "EXEC LMS_WATCHLIST_VIEWSUMMARY '" + Request.QueryString["lmsreg"] + "'";
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

		private void ViewHasil()
		{
			conn.QueryString = "EXEC LMS_WATCHLIST_VIEWHASIL '" + Request.QueryString["lmsreg"] + "'";
			conn.ExecuteQuery();

			if (conn.GetRowCount() > 0)
			{
				TXT_KATEGORI.Text = conn.GetFieldValue("KATEGORI");
				TXT_FAKTOR.Text = conn.GetFieldValue("FAKTOR_PENYEBAB");
				TXT_FOLLOW.Text = conn.GetFieldValue("FOLLOW_UP");
			}
		}

		private void ViewAcquireInfo()
		{
			TR_ACQINFO.Visible = false;
			TR_ACQINFO1.Visible = false;
			
			conn.QueryString = "EXEC LMS_GENERALINFO_VIEWACQUIRE '"+Request.QueryString["lmsreg"]+"'";
			conn.ExecuteQuery();

			if (conn.GetRowCount() > 0)
			{
				string textacqinfo = conn.GetFieldValue("LMS_ACQINFO");

				if (textacqinfo != "")
				{
					TR_ACQINFO.Visible = true;
					TR_ACQINFO1.Visible = true;
					TXT_ACQINFO.Text = textacqinfo;
				}
			}
		}

		private void InitializeEvent()
		{
			BTN_UPDATE.Attributes.Add("onclick","if(!update()){return false;};");
			BTN_FORWARD.Attributes.Add("onclick","if(!update()){return false;};");
			BTN_ACCEPT.Attributes.Add("onclick","if(!update()){return false;};");
			BTN_ADVIS.Attributes.Add("onclick","if(!update()){return false;};");

			this.TXT_TEMP.TextChanged += new EventHandler(TXT_TEMP_TextChanged);
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

		private void SaveRemark()
		{
			try
			{
				conn.QueryString = "UPDATE LMS_APPLICATION SET LMS_APRVREMARK = '" + TXT_REMARK.Text + 
					"' WHERE LMS_REGNO = '" + Request.QueryString["lmsreg"] + "'";
				conn.ExecuteQuery();
			}
			catch (Exception ex)
			{
				Response.Write("<!--" + ex.Message + "-->");
			}
		}

		private void ViewRemark()
		{
			try
			{
				conn.QueryString = "SELECT LMS_APRVREMARK FROM LMS_APPLICATION WHERE LMS_REGNO = '" + Request.QueryString["lmsreg"] + "'";
				conn.ExecuteQuery();

				if (conn.GetRowCount() > 0)
				{
					TXT_REMARK.Text = conn.GetFieldValue("LMS_APRVREMARK");
				}
			}
			catch (Exception ex)
			{
				Response.Write("<!--" + ex.Message + "-->");
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
			this.DatGrid.ItemCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.DatGrid_ItemCommand);

		}
		#endregion

		protected void BTN_UPLOAD_Click(object sender, System.EventArgs e)
		{
			UploadFile();
		}

		private void DatGrid_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
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

						conn.QueryString = "EXEC LMS_WATCHLIST_UPLOADSAVE '2', '" + e.Item.Cells[0].Text +
							"', '" + e.Item.Cells[1].Text + "', '" + e.Item.Cells[2].Text + "', '" + e.Item.Cells[3].Text + "'";
						conn.ExecuteQuery();

						//View Upload Files
						ViewUploadFiles();
					}
					break;
			}
		}

		protected void BTN_ADVIS_Click(object sender, System.EventArgs e)
		{
			SaveRemark();
			
			try
			{
				conn.QueryString = "exec LMS_WATCHLIST_ADVIS '" + 
					Request.QueryString["lmsreg"] + "', '" +
					Request.QueryString["tc"] + "', '" +
					Session["UserID"].ToString() + "', '" +
					DDL_ADVIS.SelectedValue + "'";
				conn.ExecuteQuery();
				string msg = conn.GetFieldValue("MSG");

				Response.Redirect("SearchCustomer.aspx?tc=" + Request.QueryString["tc"] + 
					"&mc=" + Request.QueryString["mc"] + 
					"&msg=" + msg +
					"&scr=" + Request.QueryString["scr"]);
			}
			catch (Exception ex)
			{
				Response.Write("<!--" + ex.Message + "-->");
			}
		}

        protected void BTN_ACCEPT_Click(object sender, System.EventArgs e)
		{
			SaveRemark();
			
			try
			{
				conn.QueryString = "exec LMS_WATCHLIST_ACCEPT '" + 
					Request.QueryString["lmsreg"] + "', '" +
					Request.QueryString["tc"] + "', '" +
					Session["UserID"].ToString() + "'";
				conn.ExecuteQuery();
				string msg = conn.GetFieldValue("MSG");

				Response.Redirect("SearchCustomer.aspx?tc=" + Request.QueryString["tc"] + 
					"&mc=" + Request.QueryString["mc"] + 
					"&msg=" + msg +
					"&scr=" + Request.QueryString["scr"]);
			}
			catch (Exception ex)
			{
				Response.Write("<!--" + ex.Message + "-->");
			}
		}

        public string popUp = "";
        protected void BTN_ACQINFO_Click(object sender, System.EventArgs e)
		{
			SaveRemark();
			
			Response.Write("<script for=window event=onload language='javascript'>PopupPage('AcqInfo.aspx?lmsreg=" + Request.QueryString["lmsreg"] + "&tc=" + Request.QueryString["tc"] + "&theForm=Form1&theObj=TXT_TEMP', '800','300');</script>");
            popUp = "<script for=window event=onload language='javascript'>PopupPage('AcqInfo.aspx?lmsreg=" + Request.QueryString["lmsreg"] + "&tc=" + Request.QueryString["tc"] + "&theForm=Form1&theObj=TXT_TEMP', '800','300');</script>";
		}

		private void TXT_TEMP_TextChanged(object sender, EventArgs e)
		{
			if (TXT_TEMP.Text != "") 
			{
				string msg = "";
				msg = TXT_TEMP.Text;
				Response.Redirect("SearchCustomer.aspx?tc=" + Request.QueryString["tc"] + 
					"&mc=" + Request.QueryString["mc"] + 
					"&msg=" + msg +
					"&scr=" + Request.QueryString["scr"]);
			}
		}

		protected void BTN_UPDATE_Click(object sender, System.EventArgs e)
		{
			if (DDL_WEWENANG.SelectedValue == "" || DDL_WEWENANG.SelectedValue == null)
			{
				GlobalTools.popMessage(this, "Wewenang Memutus tidak boleh kosong!");
				return;
			}

			if (CHK_RKK.Checked == true)
				if (DDL_RKK.SelectedValue == "" || DDL_RKK.SelectedValue == null)
				{
					GlobalTools.popMessage(this, "Submit to RKK tidak boleh kosong!");
					return;
				}

			SaveRemark();

			try
			{
				conn.QueryString = "exec LMS_WATCHLIST_UPDATE '" + 
					Request.QueryString["lmsreg"] + "', '" +
					Request.QueryString["tc"] + "', '" +
					Session["UserID"].ToString() + "', '" +
					DDL_WEWENANG.SelectedValue + "', '" +
					DDL_RKK.SelectedValue + "'";
				conn.ExecuteQuery();
				string msg = conn.GetFieldValue("MSG");

				Response.Redirect("SearchCustomer.aspx?tc=" + Request.QueryString["tc"] + 
					"&mc=" + Request.QueryString["mc"] + 
					"&msg=" + msg +
					"&scr=" + Request.QueryString["scr"]);
			}
			catch (Exception ex)
			{
				Response.Write("<!--" + ex.Message + "-->");
			}
		}

		protected void CHK_RKK_CheckedChanged(object sender, System.EventArgs e)
		{
			if (CHK_RKK.Checked)
			{
				DDL_RKK.Enabled = true;
				DDL_RKK.CssClass = "mandatory";
				//try { DDL_WEWENANG.SelectedIndex = DDL_WEWENANG.Items.Count - 1; }
				//catch {}
				//DDL_WEWENANG.Enabled = false;
			}
			else
			{
				//DDL_RKK.Enabled = false;
				DDL_RKK.CssClass = "";
				try { DDL_RKK.SelectedValue = ""; }
				catch {}
				//try { DDL_WEWENANG.SelectedIndex = 0; }
				//catch {}
				//DDL_WEWENANG.Enabled = true;
			}
		}

		protected void BTN_FORWARD_Click(object sender, System.EventArgs e)
		{
			SaveRemark();
			
			try
			{
				conn.QueryString = "exec LMS_WATCHLIST_FORWARD '" + 
					Request.QueryString["lmsreg"] + "', '" +
					Request.QueryString["tc"] + "', '" +
					Session["UserID"].ToString() + "', '" +
					DDL_FORWARD.SelectedValue + "'";
				conn.ExecuteQuery();
				string msg = conn.GetFieldValue("MSG");

				Response.Redirect("SearchCustomer.aspx?tc=" + Request.QueryString["tc"] + 
					"&mc=" + Request.QueryString["mc"] + 
					"&msg=" + msg +
					"&scr=" + Request.QueryString["scr"]);
			}
			catch (Exception ex)
			{
				Response.Write("<!--" + ex.Message + "-->");
			}
		}

		protected void BTN_BACK_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			string url = "SearchCustomer.aspx?mc=" + Request.QueryString["mc"];
			if (Request.QueryString["tc"] != "")
			{
				url = url + "&tc=" + Request.QueryString["tc"];
			}
			if (Request.QueryString["scr"] != "")
			{
				url = url + "&scr=" + Request.QueryString["scr"];
			}
			Response.Redirect(url);
		}

		protected void BTN_SAVE_Click(object sender, System.EventArgs e)
		{
			string torkk;
			if (CHK_RKK.Checked == true)
				torkk = "1";
			else
				torkk = "0";

			SaveRemark();

			try
			{
				conn.QueryString = "exec LMS_WATCHLIST_SAVE '" + 
					Request.QueryString["lmsreg"] + "', '" +
					DDL_WEWENANG.SelectedValue + "', '" +
					torkk + "', '" +
					DDL_RKK.SelectedValue + "'";
				conn.ExecuteQuery();
			}
			catch (Exception ex)
			{
				Response.Write("<!--" + ex.Message + "-->");
			}
		}

		protected void BTN_ADVISREPLY_Click(object sender, System.EventArgs e)
		{
			SaveRemark();
			
			try
			{
				conn.QueryString = "exec LMS_WATCHLIST_ADVISREPLY '" + 
					Request.QueryString["lmsreg"] + "', '" +
					Request.QueryString["tc"] + "', '" +
					Session["UserID"].ToString() + "'";
				conn.ExecuteQuery();
				string msg = conn.GetFieldValue("MSG");

				Response.Redirect("SearchCustomer.aspx?tc=" + Request.QueryString["tc"] + 
					"&mc=" + Request.QueryString["mc"] + 
					"&msg=" + msg +
					"&scr=" + Request.QueryString["scr"]);
			}
			catch (Exception ex)
			{
				Response.Write("<!--" + ex.Message + "-->");
			}
		}
	}
}
