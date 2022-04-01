using System;
using System.IO;
using System.Runtime.Remoting;
using System.Diagnostics;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using Microsoft.VisualBasic;
using DMS.CuBESCore;
using DMS.DBConnection;

namespace SME.Verificator
{
	/// <summary>
	/// Summary description for Verificator.
	/// </summary>
	public partial class MainVerificator : System.Web.UI.Page
	{
		protected Connection conn;
		protected Tools tool = new Tools();
		string var_user;
		object oMissingObject = System.Reflection.Missing.Value;

		protected void Page_Load(object sender, System.EventArgs e)
		{
			conn = (Connection) Session["Connection"];
			var_user = Session["USERID"].ToString();

			InitializeEvent();

			if (!IsPostBack)
			{	
				ViewDataApplication();
				ViewFileUpload();
				ViewFileTemplate();
			}

			ViewMenu();
			SecureData();

			updatestatus.Attributes.Add("onclick","if(!update1()){return false;};");
		}

		private void InitializeEvent()
		{
			this.BTN_BACK.Click += new System.Web.UI.ImageClickEventHandler(this.BTN_BACK_Click);
			this.BTN_UPLOAD.Click += new System.EventHandler(this.BTN_UPLOAD_Click);
			this.updatestatus.Click += new System.EventHandler(this.updatestatus_Click);
		}

		private void deleteFile(string directory, string filename) 
		{
			if (File.Exists(directory + filename)) 
			{
				File.Delete(directory + filename);
			}
		}

		private void ViewDataApplication()
		{
			conn.QueryString = "select * from VW_VERIFICATOR_MAIN where AP_REGNO = '" +Request.QueryString["regno"]+ "'";
			conn.ExecuteQuery();
			TXT_AP_REGNO.Text		= conn.GetFieldValue("AP_REGNO");
			TXT_CU_REF.Text			= conn.GetFieldValue("CU_REF");
			TXT_AP_SIGNDATE.Text	= tool.FormatDate(conn.GetFieldValue("AP_SIGNDATE"));
			TXT_PROGRAMDESC.Text	= conn.GetFieldValue("PROGRAMDESC");
			TXT_BRANCH_NAME.Text	= conn.GetFieldValue("BRANCH_NAME");
			TXT_AP_RELMNGR.Text		= conn.GetFieldValue("SU_FULLNAME");
			LBL_CU_CUSTTYPEID.Text	= conn.GetFieldValue("CU_CUSTTYPEID");
			TXT_AP_TEAMLEADER.Text	= conn.GetFieldValue("AP_TEAMLEADER");
			TXT_PK_KETERANGAN.Text	= conn.GetFieldValue("KETERANGAN");

			ViewDataCustomer();
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

		private void ViewDataCustomer()
		{
			if (LBL_CU_CUSTTYPEID.Text == "01") //if company
			{
				conn.QueryString = "select * from VW_CUST_COMPANY where CU_REF = '" +Request.QueryString["curef"]+ "'";
				conn.ExecuteQuery();
				TXT_NAME.Text = conn.GetFieldValue("COMPTYPEDESC").Trim()+" "+conn.GetFieldValue("CU_COMPNAME").Trim();
				TXT_ADDRESS1.Text		= conn.GetFieldValue("CU_COMPADDR1");
				TXT_ADDRESS2.Text		= conn.GetFieldValue("CU_COMPADDR2");
				TXT_ADDRESS3.Text		= conn.GetFieldValue("CU_COMPADDR3");
				TXT_CITY.Text			= conn.GetFieldValue("CITYNAME");
				TXT_PHONENUM.Text		= conn.GetFieldValue("CU_COMPPHNAREA").Trim() + " - "+conn.GetFieldValue("CU_COMPPHNNUM").Trim();
				TXT_BUSINESSTYPE.Text	= conn.GetFieldValue("BUSSTYPEDESC");
			}
			else //if personal
			{
				conn.QueryString = "select * from VW_CUST_PERSONAL where CU_REF = '" +Request.QueryString["curef"]+ "'";
				conn.ExecuteQuery();
				TXT_NAME.Text			= conn.GetFieldValue("CU_FIRSTNAME").Trim()+ " "+conn.GetFieldValue("CU_MIDDLENAME").Trim()+" "+conn.GetFieldValue("CU_LASTNAME").Trim();
				TXT_ADDRESS1.Text		= conn.GetFieldValue("CU_ADDR1");
				TXT_ADDRESS2.Text		= conn.GetFieldValue("CU_ADDR2");
				TXT_ADDRESS3.Text		= conn.GetFieldValue("CU_ADDR3");
				TXT_CITY.Text			= conn.GetFieldValue("CITYNAME");
				TXT_PHONENUM.Text		= conn.GetFieldValue("CU_PHNAREA").Trim() + " - "+conn.GetFieldValue("CU_PHNNUM").Trim();
				TXT_BUSINESSTYPE.Text	= conn.GetFieldValue("BUSSTYPEDESC");
			}
		}

		private void ViewFileUpload()
		{
			conn.QueryString = "select CREDANALYSIS_DIR from APP_PARAMETER";
			conn.ExecuteQuery();
			string path = "/SME/" + conn.GetFieldValue("CREDANALYSIS_DIR").ToString().Trim().Replace("\\", "/");
			DataTable dt = new DataTable();
			
			conn.QueryString = "select * from FILE_UPLOAD where AP_REGNO ='"+ Request.QueryString["regno"] + "'";
			conn.ExecuteQuery();
			dt = conn.GetDataTable().Copy();
			DatGrid.DataSource = dt;
			DatGrid.DataBind();

			for (int i = 1; i <= DatGrid.Items.Count; i++)
			{
				HyperLink HpDownload = (HyperLink) DatGrid.Items[i-1].Cells[3].FindControl("HL_DOWNLOAD");
				LinkButton HpDelete   = (LinkButton) DatGrid.Items[i-1].Cells[4].FindControl("LinkButton1");
				HpDownload.NavigateUrl = path + DatGrid.Items[i-1].Cells[2].Text.Trim();
				DatGrid.Items[i-1].Cells[1].Text = i.ToString();
				if (Session["USERID"].ToString().Trim() != DatGrid.Items[i-1].Cells[5].Text)
					HpDelete.Visible	= false;

				if (Request.QueryString["prrk"] =="0") 
				{
					//HpDownload.Enabled	= false;
					HpDelete.Enabled	= false;
				}

			}
		}

		private void ViewFileTemplate()
		{
			conn.QueryString = "SELECT * FROM VW_VERIFICATOR_LISTTEMPLATEFILE";
			conn.ExecuteQuery();

			DG_TEMPLATE.DataSource = conn.GetDataTable().Copy();
			DG_TEMPLATE.DataBind();

			for(int i = 0; i < DG_TEMPLATE.Items.Count; i++)
			{
				HyperLink Hp = (HyperLink) DG_TEMPLATE.Items[i].Cells[3].FindControl("HP_DOWNLOAD");
				Hp.NavigateUrl = DG_TEMPLATE.Items[i].Cells[2].Text.Trim();
			}
		}

		private void SecureData() 
		{
			conn.QueryString = "select in_verificator from rfinitial";
			conn.ExecuteQuery();

			if (conn.GetFieldValue("in_verificator") != Request.QueryString["tc"])
			{
				updatestatus.Visible = false;
				btn_backtover.Visible = false;
				BTN_UPLOAD.Visible = false;
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
		/// the contents of this method with the code editor.dsafasfd
		/// </summary>
		private void InitializeComponent()
		{    
			this.DatGrid.ItemCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.DatGrid_ItemCommand);

		}
		#endregion

		private void DatGrid_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			switch (((LinkButton)e.CommandSource).CommandName)
			{
				case "delete":					
					/// Function delete file fisik
					/// 
					try 
					{					
						string directory = @"C:\";
						conn.QueryString = "select app_root + CREDANALYSIS_DIR as FULLPATH from APP_PARAMETER";
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



					//conn.QueryString = "exec CP_NOTA_EXPORT '" + e.Item.Cells[0].Text +"','" + Request.QueryString["regno"] + "', '" + e.Item.Cells[5].Text + "','','" + Session["UserID"] + "', '2'";
					conn.QueryString = "exec CA_FILE_UPLOAD '" +Request.QueryString["regno"]+ "', '" +e.Item.Cells[0].Text+ "','','','2'";
					conn.ExecuteNonQuery();
					ViewFileUpload();					
					break;
			}
		}

		private void BTN_UPLOAD_Click(object sender, System.EventArgs e)
		{
			string path, mStatus = "", mStatusReport = "";
			conn.QueryString = "select APP_ROOT, CREDANALYSIS_DIR from APP_PARAMETER";
			conn.ExecuteQuery();
			path = conn.GetFieldValue("APP_ROOT").ToString().Trim()+ conn.GetFieldValue("CREDANALYSIS_DIR").ToString().Trim();
 
			HttpFileCollection uploadedFiles = Request.Files;
			
			int counter = 0, mField = 0;
			LBL_STATUS.Text = "";
			LBL_STATUSREPORT.Text = "";
			for (int i = 0; i < uploadedFiles.Count; i++)
			{
				HttpPostedFile userPostedFile = uploadedFiles[i];
				counter = i + 1;
				try
				{
					if (userPostedFile.ContentLength > 0)
					{
						userPostedFile.SaveAs(path + Request.QueryString["regno"].Trim() + "-"+Session["USERID"].ToString()+"-" + Path.GetFileName(userPostedFile.FileName));
						LBL_STATUS.ForeColor = Color.Black;
						LBL_STATUSREPORT.ForeColor = Color.Black;
						mStatus = "Upload Successful!";
						mStatusReport = "<u>File #" + counter.ToString() + "</u><br>" + 
							"File Content Type: " + userPostedFile.ContentType + "<br>" + 
							"File Size: " + userPostedFile.ContentLength + " bytes<br>" + 
							"File Name: " + userPostedFile.FileName + "<br>";
						mStatusReport += "Location Where Saved: " + path + Request.QueryString["regno"].Trim() + "-"+Session["USERID"].ToString()+"-" + Path.GetFileName(userPostedFile.FileName) + "<p>";
						conn.QueryString = "select FU_FILENAME from FILE_UPLOAD where AP_REGNO = '" +Request.QueryString["regno"]+ "'";
						conn.ExecuteQuery();

						int lket = Request.QueryString["regno"].Trim().Length + Session["USERID"].ToString().Trim().Length + 2;
						conn.QueryString = "select FU_FILENAME from FILE_UPLOAD where AP_REGNO = '" +Request.QueryString["regno"]+ "' and FU_USERID = '"+Session["USERID"].ToString()+"'";
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
							conn.QueryString = "exec CA_FILE_UPLOAD '" +Request.QueryString["regno"]+ "', '', '" +Request.QueryString["regno"].Trim() + "-"+Session["USERID"].ToString()+"-" +
										Path.GetFileName(userPostedFile.FileName)+ "', '" +Session["USERID"].ToString()+ "', '1'";
							conn.ExecuteNonQuery();
							ViewFileUpload();
						}
					}
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

		private void BTN_BACK_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			if (Request.QueryString["tc"] != null && Request.QueryString["tc"] != "")
			Response.Redirect("/SME/" + DMS.CuBESCore.Logic.backLink(Request.QueryString["tc"].ToString(), conn));
			else
				Response.Write("<script language='javascript'>history.back(-1);</script>");
		}

		protected void updatestatus_Click(object sender, System.EventArgs e)
		{
			//Response.Write("<script for=window event=onload language='javascript'>PopupPage('../VerifyUser.aspx?userid=" + var_user + "&theForm=Form1&theObj=TXT_VERIFY', '430','150');</script>");
			conn.QueryString = "exec VERIFICATOR_NEXTTRACK '" + Request.QueryString["regno"] + "', '" + Session["USERID"].ToString() + "'";
			conn.ExecuteNonQuery();

			string msg = getNextStepMsg(Request.QueryString["regno"]);
			Response.Redirect("ListVerificator.aspx?tc=" + Request.QueryString["tc"] + "&mc=" + Request.QueryString["mc"] + "&msg=" + msg);
		}

		private string getNextStepMsg(string regno) 
		{
			string pesan = "";
			string nextTrack = "";
			try 
			{
				/***
				 * Memunculkan pesan next step
				 ***/
				conn.QueryString = "exec TRACKNEXTMSG '" + regno + "'";
				conn.ExecuteQuery();
				nextTrack = conn.GetFieldValue("TRACKNAME");
				pesan = "Application proceeds to " + nextTrack;
				/***********************************/
			} 
			catch 
			{
				throw new Exception();
			}
			return pesan;
		}

		protected void btn_backtover_Click(object sender, System.EventArgs e)
		{
			Response.Write("<script for=window event=onload language='javascript'>PopupPage('AcqInfo.aspx?regno=" + Request.QueryString["regno"] + "&curef=" + Request.QueryString["curef"]+ "&aprv=BU&theForm=Form1&theObj=TXT_TEMP', '800','300');</script>");
		}

		protected void TXT_TEMP_TextChanged(object sender, System.EventArgs e)
		{
			if (TXT_TEMP.Text != "") 
			{
				string msg = "";
				msg = "Application acquire information from " + TXT_TEMP.Text + " !";
				Response.Redirect("ListVerificator.aspx?mc="+Request.QueryString["mc"]+"&tc=" + Request.QueryString["tc"]+"&msg="+msg);
			}
		}
	}
}
