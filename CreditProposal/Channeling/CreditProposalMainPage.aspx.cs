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
using Microsoft.VisualBasic;
using DMS.CuBESCore;
using DMS.DBConnection;
using System.IO;
using System.Diagnostics;


namespace SME.CreditProposal.Channeling
{
	/// <summary>
	/// Summary description for MainVerificationAssignment.sadfsad
	/// </summary>
	public partial class CreditProposalMainPage : System.Web.UI.Page
	{
		protected Connection conn;
		protected Connection2 conn2;
		protected CommonForm.DocumentExport DocumentExport1;
		protected Tools tool = new Tools();

		protected void Page_Load(object sender, System.EventArgs e)
		{
			conn = (Connection) Session["Connection"];
			conn2 = new Connection2();
			//if (!Logic.AllowAccess(Session["GroupID"].ToString(), Request.QueryString["mc"], conn))
			//	Response.Redirect("/SME/Restricted.aspx");

			if (!IsPostBack)
			{
				//ViewDataApplication();		
				conn.QueryString = "SELECT AP_ACQINFO FROM APPLICATION WHERE AP_REGNO = '" + Request.QueryString["regno"] + "'";
				conn.ExecuteQuery();

				if(conn.GetFieldValue("AP_ACQINFO") != "")
				{
					//GlobalTools.popMessage(this, conn.GetFieldValue("AP_ACQINFO").ToString());
					Response.Write("<script for=window event=onload language='javascript'>PopupPage('AcqInfo.aspx?pesan=" + conn.GetFieldValue("AP_ACQINFO") + "&theForm=Form1', '800','350');</script>");			
				}

				DocumentExport1.GroupTemplate = "PRINTNAKCHANNELING";
			}
			conn2.QueryString = "EXEC CHANNELING_VIEWDATA_CREDITPROPOSALMAINPAGE '" + Request.QueryString["curef"] + "','" + Session["UserID"].ToString() + "','" + Request.QueryString["parentregno"] + "','" + Request.QueryString["aano"] + "','" + Request.QueryString["productid"] + "','" + Request.QueryString["prodseq"] + "'";
			conn2.ExecuteQuery(); 
			FillDropDownListDateAndApplicationNumber();

			ViewMenu();

			//DocumentUpload1.GroupTemplate = "CHANNELINGUPLOADFILE";
			//DocumentUpload1.WithReadExcel = false;
			BindData("DATA_EXPORT","EXEC CHANNELING_GET_FILE_UPLOAD_CHANNELING_ATTACH '" + Request.QueryString["regno"] + "'");
			ViewUploadFiles();
		}

		private void FillDropDownListDateAndApplicationNumber()
		{
			IsiTanggal();

			conn.QueryString = "select branch_name, branch_code from rfbranch where active='1' order by branch_code";
			conn.ExecuteQuery();
			for (int i = 0; i < conn.GetRowCount(); i++)
				DDL_AP_BOOKINGBRANCH.Items.Add(new ListItem(conn.GetFieldValue(i,1) + " - " + conn.GetFieldValue(i,0), conn.GetFieldValue(i,1)));
			//set default booking branch
			DDL_AP_BOOKINGBRANCH.SelectedValue = conn2.GetFieldValue("SU_BRANCH");

			conn.QueryString = "select branch_name, branch_code from vw_ccobranch order by branch_code";
			conn.ExecuteQuery();
			for (int i = 0; i < conn.GetRowCount(); i++)
				DDL_AP_CCOBRANCH.Items.Add(new ListItem(conn.GetFieldValue(i,1) + " - " + conn.GetFieldValue(i,0), conn.GetFieldValue(i,1)));
			//set default cco branch
			conn.QueryString = "select br_ccobranch from rfbranch where branch_code = '" + Session["BranchID"].ToString() + "'";
			conn.ExecuteQuery();
			DDL_AP_CCOBRANCH.SelectedValue = conn.GetFieldValue("br_ccobranch");

			//isi default tanggal
			txt_DD_B.Text = conn2.GetFieldValue("dy");
			ddl_MM_B.SelectedValue = conn2.GetFieldValue("mth");
			txt_YY_B.Text = conn2.GetFieldValue("yr");

			LBL_PLAFOND_OWNER.Text = conn2.GetFieldValue("CU_NAME");
			LBL_REMAINING_EMAS.Text = GlobalTools.MoneyFormat(conn2.GetFieldValue("REMAINING_EMAS_LIMIT"));
			LBL_PENDING_LIMIT.Text = GlobalTools.MoneyFormat(conn2.GetFieldValue("PENDING_LIMIT"));
			LBL_AVAILBALE_LIMIT.Text = GlobalTools.MoneyFormat(conn2.GetFieldValue("AVAILABLE_LIMIT"));
			TXT_APPLICATION.Text = Request.QueryString["regno"];
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
			this.DATA_EXPORT.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.DATA_EXPORT_PageIndexChanged);

		}
		#endregion

		private void ViewMenu()
		{
			try 
			{
				conn.QueryString = "select SM_ID,MENUCODE,SM_MENUDISPLAY,SM_LINKNAME from SCREENMENU where menucode = '"+Request.QueryString["mc"]+"'";
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
							strtemp = "regno=" + Request.QueryString["regno"]+ "&curef="+Request.QueryString["curef"]+"&mc="+Request.QueryString["mc"]+"&tc="+Request.QueryString["tc"]+"&jnsnasabah="+Request.QueryString["jnsnasabah"]+"&programid="+Request.QueryString["programid"]+"&lmsreg="+Request.QueryString["lmsreg"]+"&scr="+Request.QueryString["scr"]+"&parentregno="+Request.QueryString["parentregno"]+"&aano="+Request.QueryString["aano"]+"&productid=" + Request.QueryString["productid"] + "&prodseq=" + Request.QueryString["prodseq"];
						else	
							strtemp = "regno=" + Request.QueryString["regno"]+ "&curef="+Request.QueryString["curef"]+"&mc="+Request.QueryString["mc"]+"&tc="+Request.QueryString["tc"]+"&jnsnasabah="+Request.QueryString["jnsnasabah"]+"&programid="+Request.QueryString["programid"]+"&lmsreg="+Request.QueryString["lmsreg"]+"&scr="+Request.QueryString["scr"]+"&parentregno="+Request.QueryString["parentregno"]+"&aano="+Request.QueryString["aano"]+"&productid=" + Request.QueryString["productid"] + "&prodseq=" + Request.QueryString["prodseq"];
						//t.ForeColor = Color.MidnightBlue; 
					}
					else 
					{
						strtemp = "";
						t.ForeColor = Color.Red; 
					}
					t.NavigateUrl = "../" + conn.GetFieldValue(i, 3)+strtemp;
					Menu.Controls.Add(t);
					Menu.Controls.Add(new LiteralControl("&nbsp;&nbsp;&nbsp;"));
				}
			} 
			catch (Exception ex) 
			{
				string temp = ex.ToString();
			}
		}


		private void IsiTanggal()
		{
			GlobalTools.initDateFormINA(txt_DD_B, ddl_MM_B, txt_YY_B, true);
		}

		private bool isSyaratSyaratLengkap() 
		{
			bool isLengkap = true;

			//-----Pengecekan Syarat Penandatangan PK----------------------
			conn.QueryString = "select count(*) from SYARAT where DOCTYPEID = '4' and AP_REGNO = '" +Request.QueryString["regno"]+ "'";
			conn.ExecuteQuery();
			if (conn.GetFieldValue(0,0).ToString().Trim() == "0")
			{
				isLengkap = false; //not complete
				GlobalTools.popMessage(this,"Syarat Penandatanganan Perjanjian Kredit Belum Ada !");
			}
			//-------------------------------------------------------------
			//-----Pengecekan Syarat Penarikan / Penerbitan Kredit----------------------
			if (isLengkap)
			{
				conn.QueryString = "select count(*) from SYARAT where DOCTYPEID = '5' and AP_REGNO = '" +Request.QueryString["regno"]+ "'";
				conn.ExecuteQuery();
				if (conn.GetFieldValue(0,0).ToString().Trim() == "0")
				{
					isLengkap = false; //not complete
					GlobalTools.popMessage(this,"Syarat Penarikan / Penerbitan Kredit Belum Ada !");
				}
			}
			//-------------------------------------------------------------
			//-----Pengecekan Syarat-syarat Lain----------------------
			if (isLengkap)
			{
				conn.QueryString = "select count(*) from SYARAT where DOCTYPEID = '6' and AP_REGNO = '" +Request.QueryString["regno"]+ "'";
				conn.ExecuteQuery();
				if (conn.GetFieldValue(0,0).ToString().Trim() == "0")
				{
					isLengkap = false; //not complete
					GlobalTools.popMessage(this,"Syarat-syarat Lain Belum Ada !");
				}
			}
			//-------------------------------------------------------------

			return isLengkap;
		}

		protected void BTN_SAVE_Click(object sender, System.EventArgs e)
		{
			/*conn.QueryString = "SELECT SU_UPLINER, SU_MIDUPLINER, SU_CORUPLINER FROM SCUSER WHERE USERID = '" + Session["userid"] + "'";
			conn.ExecuteQuery();

			if(conn.GetFieldValue("SU_UPLINER") != "")
			{
				conn.QueryString = "EXEC CHANNELING_TRACKUPDATE '" + Request.QueryString["regno"] + "','" + Request.QueryString["productid"] + "','" + conn.GetFieldValue("SU_UPLINER") + "','" + Request.QueryString["prodseq"] + "','" + Request.QueryString["aano"] + "','TCHAN3.0'";
			}
			else if(conn.GetFieldValue("SU_MIDUPLINER") != "")
			{
				conn.QueryString = "EXEC CHANNELING_TRACKUPDATE '" + Request.QueryString["regno"] + "','" + Request.QueryString["productid"] + "','" + conn.GetFieldValue("SU_MIDUPLINER") + "','" + Request.QueryString["prodseq"] + "','" + Request.QueryString["aano"] + "','TCHAN3.0'";
			}
			else if(conn.GetFieldValue("SU_CORUPLINER") != "")
			{
				conn.QueryString = "EXEC CHANNELING_TRACKUPDATE '" + Request.QueryString["regno"] + "','" + Request.QueryString["productid"] + "','" + conn.GetFieldValue("SU_CORUPLINER") + "','" + Request.QueryString["prodseq"] + "','" + Request.QueryString["aano"] + "','TCHAN3.0'";
			}*/

			if(isSyaratSyaratLengkap())
			{
				conn.QueryString = "EXEC CHANNELING_TRACKUPDATE '" + Request.QueryString["regno"] + "','" + Request.QueryString["productid"] + "','" + Session["UserID"] + "','" + Request.QueryString["prodseq"] + "','" + Request.QueryString["aano"] + "','TCHAN3.0'";
				conn.ExecuteQuery();
				Response.Redirect("FindCustomer.aspx?msg=ok");
			}
		}

		protected void BTN_UPLOAD_Click(object sender, System.EventArgs e)
		{
			string directory;
			int counter = 0;
			int max_id = 10000;
			string outputfilename = "";

			//Get Export Properties
			conn.QueryString = "EXEC CHANNELING_INSERT_FILE_UPLOAD '" + Session["USERID"].ToString() + "','" +
				Path.GetFileName(TXT_FILE_UPLOAD.PostedFile.FileName) + "','" + Request.QueryString["regno"] + "','ATTACH'";
			conn.ExecuteQuery();

			conn.QueryString = "SELECT MAX(ID_UPLOAD_CHANNELING) as MAX_ID from [FILE_UPLOAD_CHANNELING]";
			conn.ExecuteQuery();

			if (conn.GetRowCount() > 0)
			{
				max_id = int.Parse(conn.GetFieldValue("MAX_ID"));
			}

			conn.QueryString = "SELECT FILE_UPLOAD_CHANNELING_NAME from [FILE_UPLOAD_CHANNELING] where ID_UPLOAD_CHANNELING = '" + max_id + "'";
			conn.ExecuteQuery();

			if (conn.GetRowCount() > 0)
			{
				outputfilename = conn.GetFieldValue("FILE_UPLOAD_CHANNELING_NAME");
			}

			conn.QueryString = "SELECT EXPORT_URL FROM RFCHANNELINGCUSTEXPORT WHERE EXPORT_ID = 'CHANNELING'";
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

		private void ViewUploadFiles()
		{
			string url = "";
			conn.QueryString = "SELECT EXPORT_URL FROM RFCHANNELINGCUSTEXPORT WHERE EXPORT_ID = '" + "CHANNELING" + "'";
			conn.ExecuteQuery();

			if (conn.GetRowCount() > 0) 
			{
				url = conn.GetFieldValue("EXPORT_URL");
			}

			System.Data.DataTable dt = new System.Data.DataTable();
			conn.QueryString = "EXEC CHANNELING_GET_ATTACHMENT '" + Request.QueryString["curef"] + "','" + Session["UserID"].ToString() + "','" + Request.QueryString["regno"] + "'";
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
				HyperLink HpDownload = (HyperLink) DATA_EXPORT.Items[i-1].Cells[2].FindControl("UPL_CHANNELING_DOWNLOAD");
				LinkButton HpDelete = (LinkButton) DATA_EXPORT.Items[i-1].Cells[3].FindControl("UPL_CHANNELING_DELETE");
				HpDownload.NavigateUrl = url + conn.GetFieldValue(i-1,"FILE_UPLOAD_CHANNELING_NAME");
			}
		}

		private void DATA_EXPORT_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			switch (((LinkButton)e.CommandSource).CommandName)
			{
				case "Delete":
					conn.QueryString = "DELETE FROM FILE_UPLOAD_CHANNELING WHERE ID_UPLOAD_CHANNELING = '" + e.Item.Cells[0].Text + "'";
					conn.ExecuteQuery();
					BindData("DATA_EXPORT","EXEC CHANNELING_GET_ATTACHMENT '" + Request.QueryString["curef"] + "','" + Session["UserID"].ToString() + "','" + Request.QueryString["regno"] + "'");
					break;
			}
		}

		private void DATA_EXPORT_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			if(DATA_EXPORT.CurrentPageIndex >= 0 && DATA_EXPORT.CurrentPageIndex < DATA_EXPORT.PageCount)
			{
				DATA_EXPORT.CurrentPageIndex = e.NewPageIndex;
				BindData("DATA_EXPORT","EXEC CHANNELING_GET_ATTACHMENT '" + Request.QueryString["curef"] + "','" + Session["UserID"].ToString() + "','" + Request.QueryString["regno"] + "'");
			}
		}

		private void BindData(string dataGridName, string strconn)
		{
			if(strconn != "")
			{
				conn.QueryString = strconn;
				conn.ExecuteQuery();
			}

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
}
