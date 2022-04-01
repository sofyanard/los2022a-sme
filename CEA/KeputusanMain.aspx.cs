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
using DMS.BlackList;
using Excel;
using System.IO;


namespace SME.CEA
{
	/// <summary>
	/// Summary description for KeputusanMain.
	/// </summary>
	public partial class KeputusanMain : System.Web.UI.Page
	{
		protected Connection conn;
		protected Tools tool = new Tools();
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			conn = (Connection) Session["Connection"];

			if (!Logic.AllowAccess(Session["GroupID"].ToString(), Request.QueryString["mc"], conn))
				Response.Redirect("../SME/Restricted.aspx");

			

			ViewMenu();
			BTN_UPDATE.Attributes.Add("onclick","if(!update()){return false;};");
			this.TXT_TEMP.TextChanged += new System.EventHandler(this.TXT_TEMP_TextChanged);

			if(!IsPostBack)
			{
				this.BTN_ACQUIRE_INFO.Click += new System.EventHandler(this.BTN_ACQUIRE_INFO_Click);
				this.RDO_DECISION.SelectedIndexChanged += new System.EventHandler(this.RDO_DECISION_SelectedIndexChanged);

				conn.QueryString = "select rekanantypeid from rekanan where rekanan_ref='" + Request.QueryString["rekanan_ref"] + "'";
				conn.ExecuteQuery();

				TR_ALASAN.Visible=false;

				if (conn.GetFieldValue("rekanantypeid")=="01")
				{
					conn.QueryString="select regnum, rekanandesc, namerekanan, pic_name, address1, address2, city, phone_area + '-' + phone# as phone from vw_rekanan_company where regnum='" + Request.QueryString["regnum"] + "'";
					conn.ExecuteQuery();

					TXT_REGNUM.Text = conn.GetFieldValue("regnum");
					TXT_JNS_REK.Text = conn.GetFieldValue("rekanandesc");
					TXT_REK_NAME.Text = conn.GetFieldValue("namerekanan");
					TXT_CP.Text = conn.GetFieldValue("pic_name");
					TXT_ADDRESS1.Text = conn.GetFieldValue("address1");
					TXT_ADDRESS2.Text = conn.GetFieldValue("address2");
					TXT_CITY.Text = conn.GetFieldValue("city");
					TXT_TELP.Text = conn.GetFieldValue("phone");
				}
				else
				{
					conn.QueryString="select regnum, rekanandesc, namerekanan, address1, address2, city, office_area + '-' + office# as phone from vw_rekanan_personal where regnum='" + Request.QueryString["regnum"] + "'";
					conn.ExecuteQuery();

					TXT_REGNUM.Text = conn.GetFieldValue("regnum");
					TXT_JNS_REK.Text = conn.GetFieldValue("rekanandesc");
					TXT_REK_NAME.Text = conn.GetFieldValue("namerekanan");
					TXT_ADDRESS1.Text = conn.GetFieldValue("address1");
					TXT_ADDRESS2.Text = conn.GetFieldValue("address2");
					TXT_CITY.Text = conn.GetFieldValue("city");
					TXT_TELP.Text = conn.GetFieldValue("phone");
				}

				ViewScore();
				
				ViewApprovalCommittee();
				fillDDLCommitee();
				ViewSanksiRekanan();
			}
			
			ViewFileUpload();
			lbl_regnum.Text=Request.QueryString["regnum"];
			lbl_rekananref.Text=Request.QueryString["rekanan_ref"];
			CekView();
		}

		private void ViewSanksiRekanan()
		{
			conn.QueryString = "select * from vw_rekanan_sanksi2 where rekanan_ref='" + Request.QueryString["rekanan_ref"] + "'";
			conn.ExecuteQuery();
			FillGridIn();
			//conn.QueryString = "select * from vw_rekanan_sanksi2 where rekanan_ref='" + Request.QueryString["rekanan_ref"] + "'";
			//conn.ExecuteQuery();
			FillGridExt();
		}

		private void FillGridIn()
		{
			System.Data.DataTable dt = new System.Data.DataTable();
			dt = conn.GetDataTable().Copy();
			Datagrid1.DataSource = dt;
			try 
			{
				Datagrid1.DataBind();
			} 
			catch 
			{
				Datagrid1.CurrentPageIndex = 0;
				Datagrid1.DataBind();
			}
			for (int i = 0; i < Datagrid1.Items.Count; i++)
			{
				Datagrid1.Items[i].Cells[4].Text = tool.FormatDate(Datagrid1.Items[i].Cells[4].Text, true);
			}
		}

		private void FillGridExt()
		{
			System.Data.DataTable dt = new System.Data.DataTable();
			dt = conn.GetDataTable().Copy();
			DatGrdExt.DataSource = dt;
			try 
			{
				DatGrdExt.DataBind();
			} 
			catch 
			{
				DatGrdExt.CurrentPageIndex = 0;
				DatGrdExt.DataBind();
			}
			for (int i = 0; i < DatGrdExt.Items.Count; i++)
			{
				DatGrdExt.Items[i].Cells[4].Text = tool.FormatDate(DatGrdExt.Items[i].Cells[4].Text, true);
			}
		}

		private void ViewScore()
		{
			/*conn.QueryString = "select * from vw_rekanan_sanksi where rekanan_ref='" + Request.QueryString["rekanan_ref"] + "'";
			conn.ExecuteQuery();
			TXT_SANKSI.Text = conn.GetFieldValue("SANKSIDESC");*/

			conn.QueryString = "select * from rekanan_score where regnum='" + Request.QueryString["regnum"] + "'";
			conn.ExecuteQuery();
			TXT_SCORE_KUAL.Text = conn.GetFieldValue("SC_KUALITATIF");
			TXT_SCORE_KUAN.Text = conn.GetFieldValue("SC_KUANTITATIF");
			conn.QueryString = "select * from rekanan_wawancara where regnum='" + Request.QueryString["regnum"] + "'";
			conn.ExecuteQuery();
			TXT_SCORE_INTERVIEW.Text = conn.GetFieldValue("SC_TOTAL");
		}

		private void fillDDLCommitee()
		{
			GlobalTools.fillRefList(DDL_COMMITTEE, "SELECT * FROM VW_REKANAN_APPROVALCOMMITEE_FILLDDLCOMMITEE WHERE userid not in (select id_komite from rekanan_approval where regnum='" + Request.QueryString["regnum"] + "')ORDER BY USERNAME", false, conn);
			conn.QueryString = "SELECT count(*) as jumlah FROM VW_REKANAN_APPROVALCOMMITEE_FILLDDLCOMMITEE WHERE userid not in (select id_komite from rekanan_approval where regnum='" + Request.QueryString["regnum"] + "')";
			conn.ExecuteQuery();
			jml_komite.Text = conn.GetFieldValue("jumlah");
		}

		private void ViewApprovalCommittee()
		{
			conn.QueryString = "select * from VW_REKANAN_APPROVALCOMMITEE_VIEWDATA where regnum='" + Request.QueryString["regnum"] + "'";
			conn.ExecuteQuery();
			FillGrid();
		}

		private void FillGrid()
		{
			System.Data.DataTable dt = new System.Data.DataTable();
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
			for (int i = 0; i < DatGrd.Items.Count; i++)
			{
				DatGrd.Items[i].Cells[4].Text = tool.FormatDate(DatGrd.Items[i].Cells[4].Text, true);
			}
		}

		private void ViewMenu()
		{
			try 
			{
				conn.QueryString = "select * from SCREENMENU where menucode = '" + Request.QueryString["mc"] + "'";
				conn.ExecuteQuery();

				if(Request.QueryString["flag"]=="1")
				{
					for (int i = 0; i < conn.GetRowCount(); i++) 
					{
						if(conn.GetFieldValue(i,0)=="A010401")
						{
							HyperLink t = new HyperLink();
							t.Text = conn.GetFieldValue(i, 2);
							t.Font.Bold = true;
							string strtemp = "";
							if (conn.GetFieldValue(i, 3).Trim()!= "") 
							{
								if (conn.GetFieldValue(i,3).IndexOf("mc=") >= 0)
									strtemp = "regnum=" + Request.QueryString["regnum"] + "&rekanan_ref="+Request.QueryString["rekanan_ref"]  + "&tc=" + Request.QueryString["tc"]+ "&flag=" + Request.QueryString["flag"]+ "&view=" + Request.QueryString["view"];
								else	
									strtemp = "regnum=" + Request.QueryString["regnum"] + "&rekanan_ref="+Request.QueryString["rekanan_ref"]  + "&mc=" + Request.QueryString["mc"]+"&tc="+Request.QueryString["tc"]+ "&flag=" + Request.QueryString["flag"]+ "&view=" + Request.QueryString["view"];
								//t.ForeColor = Color.MidnightBlue; 
								if (conn.GetFieldValue(i,3).IndexOf("?par=") < 0 && conn.GetFieldValue(i,3).IndexOf("&par=") < 0)  
									strtemp = strtemp + "&par=" + Request.QueryString["par"] + "&mc2=" + Request.QueryString["mc2"];
							}
							else 
							{
								strtemp = "";
								t.ForeColor = Color.Red; 
							}
							t.NavigateUrl = conn.GetFieldValue(i, 3)+strtemp;
							MenuKeputusanMain.Controls.Add(t);
							MenuKeputusanMain.Controls.Add(new LiteralControl("&nbsp;&nbsp;&nbsp;"));
						}
					}	
				}
				else
				{
					for (int i = 0; i < conn.GetRowCount(); i++) 
					{
						HyperLink t = new HyperLink();
						t.Text = conn.GetFieldValue(i, 2);
						t.Font.Bold = true;
						string strtemp = "";
						if (conn.GetFieldValue(i, 3).Trim()!= "") 
						{
							if (conn.GetFieldValue(i,3).IndexOf("mc=") >= 0)
								strtemp = "regnum=" + Request.QueryString["regnum"] + "&rekanan_ref="+Request.QueryString["rekanan_ref"]  + "&tc=" + Request.QueryString["tc"]+ "&view=" + Request.QueryString["view"];
							else	
								strtemp = "regnum=" + Request.QueryString["regnum"] + "&rekanan_ref="+Request.QueryString["rekanan_ref"]  + "&mc=" + Request.QueryString["mc"]+"&tc="+Request.QueryString["tc"]+ "&view=" + Request.QueryString["view"];
							//t.ForeColor = Color.MidnightBlue; 
						}
						else 
						{
							strtemp = "";
							t.ForeColor = Color.Red; 
						}
						t.NavigateUrl = conn.GetFieldValue(i, 3)+strtemp;
						MenuKeputusanMain.Controls.Add(t);
						MenuKeputusanMain.Controls.Add(new LiteralControl("&nbsp;&nbsp;&nbsp;"));
					}
				} 
			}
			catch (Exception ex) 
			{
				string temp = ex.ToString();
			}
		}

		private void DATA_EXPORT_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			string directory = "";
			conn.QueryString = "SELECT EXPORT_URL FROM REKANAN_RFEXPORT WHERE EXPORT_ID = 'REKANAN02'";
			conn.ExecuteQuery();
			if (conn.GetRowCount() > 0)
			{
				directory = Server.MapPath(conn.GetFieldValue("EXPORT_URL").Trim());
			}

			switch (((LinkButton)e.CommandSource).CommandName)
			{
				case "delete":
					conn.QueryString = "EXEC REKANAN_DELETE_FILE_UPLOAD_XLS '" + e.Item.Cells[0].Text + "', '" +
						Request.QueryString["rekanan_ref"] + "'";
					conn.ExecuteQuery();
					deleteFile(directory, e.Item.Cells[1].Text);
					ViewFileUpload();
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

		private void ViewFileUpload()
		{
			string url = "";
			conn.QueryString = "SELECT EXPORT_URL FROM REKANAN_RFEXPORT WHERE EXPORT_ID = 'REKANAN02'";
			conn.ExecuteQuery();

			if (conn.GetRowCount() > 0) 
			{
				url = conn.GetFieldValue("EXPORT_URL");
			}
			
			System.Data.DataTable dt = new System.Data.DataTable();
			conn.QueryString = "SELECT ID_UPLOAD_XLS, FILE_UPLOAD_XLS_NAME FROM REKANAN_FILE_UPLOAD_XLS where rekanan_ref='" + Request.QueryString["rekanan_ref"] + "'";
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
				HyperLink HpDownload = (HyperLink) DATA_EXPORT.Items[i-1].Cells[2].FindControl("XLS_DOWNLOAD");
				LinkButton HpDelete = (LinkButton) DATA_EXPORT.Items[i-1].Cells[3].FindControl("XLS_DELETE");
				HpDownload.NavigateUrl = url + conn.GetFieldValue("FILE_UPLOAD_XLS_NAME");
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
			this.Datagrid1.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.Datagrid1_PageIndexChanged);
			this.DatGrdExt.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.DatGrdExt_PageIndexChanged);
			this.DatGrd.ItemCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.DatGrd_ItemCommand);
			this.DatGrd.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.DatGrd_PageIndexChanged);

		}
		#endregion

		protected void BTN_UPLOAD_Click(object sender, System.EventArgs e)
		{
			string directory;
			int counter = 0;
			int max_id = 10000;
			string outputfilename = "";

			if (TXT_FILE_UPLOAD.PostedFile.FileName != "")
			{
				conn.QueryString = "EXEC REKANAN_INSERT_FILE_XLS '" + 
					Request.QueryString["rekanan_ref"] + "', '" +
					Session["USERID"].ToString() + "', '" +
					Path.GetFileName(TXT_FILE_UPLOAD.PostedFile.FileName) + "'";
				conn.ExecuteQuery();
			}			

			conn.QueryString = "SELECT MAX(ID_UPLOAD_XLS) as MAX_ID from [REKANAN_FILE_UPLOAD_XLS] where rekanan_ref='" + Request.QueryString["rekanan_ref"] + "'";
			conn.ExecuteQuery();

			if (conn.GetRowCount() > 0)
			{
				max_id = int.Parse(conn.GetFieldValue("MAX_ID"));
			}

			conn.QueryString = "SELECT FILE_UPLOAD_XLS_NAME from [REKANAN_FILE_UPLOAD_XLS] where ID_UPLOAD_XLS = '" + max_id + "' and rekanan_ref='" + Request.QueryString["rekanan_ref"] + "'";
			conn.ExecuteQuery();

			if (conn.GetRowCount() > 0)
			{
				outputfilename = conn.GetFieldValue("FILE_UPLOAD_XLS_NAME");
				//TXT_XLSNAME.Text = outputfilename;
			}

			conn.QueryString = "SELECT EXPORT_URL FROM REKANAN_RFEXPORT WHERE EXPORT_ID = 'REKANAN02'";
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
							//ViewFileUpload();
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
			ViewFileUpload();
			
		}

		protected void RDO_DECISION_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			CheckDecision();
		}

		private void CheckDecision()
		{
			if(RDO_DECISION.SelectedValue=="0")
				TR_ALASAN.Visible=true;
			else
				TR_ALASAN.Visible=false;
		}

		protected void BTN_INSERT_Click(object sender, System.EventArgs e)
		{
			if(DDL_COMMITTEE.SelectedValue=="")
			{
				GlobalTools.popMessage(this, "Nama Komite Tidak Boleh Kosong!");
				return;
			}

			conn.QueryString = "exec REKANAN_APPROVAL_COMMITTEE_INSERT '" + 
				Request.QueryString["regnum"] + "', '" +
				DDL_COMMITTEE.SelectedValue + "', '" +
				RDO_DECISION.SelectedValue + "'";
			conn.ExecuteNonQuery();
			ViewApprovalCommittee();
			fillDDLCommitee();
			ClearEntryCommittee();

			UpdateAlasanDitolak();
		
		}

		private void ClearEntryCommittee()
		{
			try {DDL_COMMITTEE.SelectedValue = "";}
			catch {}
			RDO_DECISION.SelectedValue = "1";
		}

		protected void BTN_ACQUIRE_INFO_Click(object sender, System.EventArgs e)
		{
			Response.Write("<script for=window event=onload language='javascript'>PopupPage('AcqInfoRekanan.aspx?regnum=" + lbl_regnum.Text + "&rekanan_ref=" + lbl_rekananref.Text + "&theForm=Form1&theObj=TXT_TEMP', '800','300');</script>");
			//Response.Redirect("AcqInfoRekanan.aspx?regnum=" + lbl_regnum.Text + "&rekanan_ref=" + lbl_rekananref.Text + "&theForm=Form1&theObj='" + TXT_TEMP + "', '800', '300'");
		}

		protected void BTN_UPDATE_Click(object sender, System.EventArgs e)
		{
			if (RDO_DECISION.SelectedValue == "1")
			{
				conn.QueryString="select id_rekanan from rekanan where rekanan_ref='"+Request.QueryString["rekanan_ref"] + "'";
				conn.ExecuteQuery();
				ID_REKANAN.Text = conn.GetFieldValue("id_rekanan");
				
				if (ID_REKANAN.Text == "")
				{
					conn.QueryString = "select rfrekanantype from rekanan where rekanan_ref='"+Request.QueryString["rekanan_ref"] + "'";
					conn.ExecuteQuery();
					rekanantype.Text = conn.GetFieldValue("rfrekanantype");

					if (conn.GetFieldValue("rfrekanantype") == "04" || conn.GetFieldValue("rfrekanantype") == "05")
					{
						//mengenerate semua id rekanan (gak semua asuransi) ketika di approve
						conn.QueryString = "exec REKANAN_GENERATE_ID_Asuransi ";
						conn.ExecuteQuery();
					
						ID_ASURANSI.Text = conn.GetFieldValue(0,0);					
					}				

					conn.QueryString="exec REKANAN_APPROVAL_DECISION_DITERIMA '"+
						Request.QueryString["rekanan_ref"] + "', '" +
						Request.QueryString["regnum"] + "', '" +
						ID_ASURANSI.Text + "' ";
					conn.ExecuteNonQuery();					
				}

				

			}

			string pesan="";
			string reject="0";
			
			/*if(jml_komite.Text!="0")
			{
				GlobalTools.popMessage(this, "Ada komite yang belum memberi keputusan!");
				return;
			}*/

			conn.QueryString = "select * from rekanan_approval where regnum='" + Request.QueryString["regnum"] + "'";
			conn.ExecuteQuery();

			if(conn.GetRowCount()==0)
			{
				GlobalTools.popMessage(this, "Belum ada komite yang menyetujui!");
				return;
			}

			conn.QueryString = "select * from rekanan_approval where regnum='" + Request.QueryString["regnum"] + "' and decision in ('0')";
			conn.ExecuteQuery();

			if(conn.GetRowCount()>0)
			{
				pesan = "Tidak dapat melanjutkan ke tahap selanjutnya. Aplikasi ditolak oleh";
				for (int i=0; i < conn.GetRowCount(); i++)
					pesan = pesan + ", " + conn.GetFieldValue(i,2);

				//GlobalTools.popMessage(this, pesan);

				reject="1";
				
				conn.QueryString = "exec REKANAN_TRACKUPDATE '" + 
					Request.QueryString["regnum"] + "', '" +
					Request.QueryString["tc"] + "', '" +
					Session["UserID"].ToString() + "', '" +
					reject + "'";
				conn.ExecuteNonQuery();
				Response.Redirect("ListKeputusan.aspx?tc=" + Request.QueryString["tc"] + "&mc=" + Request.QueryString["mc"] + "&msg=" + pesan);
			}
			else
			{
				conn.QueryString = "exec REKANAN_TRACKUPDATE '" + 
					Request.QueryString["regnum"] + "', '" +
					Request.QueryString["tc"] + "', '" +
					Session["UserID"].ToString() + "', '" +
					reject + "'";
				conn.ExecuteNonQuery();

				conn.QueryString = "exec REKANAN_APPROVAL_DECISION_INSERT '" +
					Request.QueryString["rekanan_ref"] + "', '" +
					Request.QueryString["regnum"] + "'";
				conn.ExecuteNonQuery();

				string msg = getNextStepMsg(Request.QueryString["regnum"]);
				Response.Redirect("ListKeputusan.aspx?tc=" + Request.QueryString["tc"] + "&mc=" + Request.QueryString["mc"] + "&msg=" + msg);
			}
			
			
		}

		private void UpdateAlasanDitolak()
		{
			conn.QueryString= " exec Rekanan_Update_Application_Rekanan '"+ 
				TXT_CAT.Text+"', '"+
				Request.QueryString["regnum"] + "' ";
			conn.ExecuteNonQuery();
		}

		private string getNextStepMsg(string regnum) 
		{
			string pesan = "";
			string nextTrack = "";
			try 
			{
				/***
				 * Memunculkan pesan next step
				 ***/
				conn.QueryString = "exec REKANAN_TRACKNEXTMSG '" + regnum + "'";
				conn.ExecuteQuery();
				nextTrack = conn.GetFieldValue("TRACKNAME");
				pesan = "Rekanan diproses ke tahap " + nextTrack;
				/***********************************/
			} 
			catch 
			{
				throw new Exception();
			}

			return pesan;
		}
		
		protected void TXT_TEMP_TextChanged(object sender, EventArgs e)
		{
			if (TXT_TEMP.Text != "") 
			{
				string msg = "";
				msg = "Application acquire information from " + TXT_TEMP.Text + " !";
				Response.Redirect("ListKeputusan.aspx?mc="+Request.QueryString["mc"]+"&tc=" + Request.QueryString["tc"]+"&msg="+msg);
			}
		}

		private void DatGrd_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			switch (((LinkButton)e.CommandSource).CommandName)
			{
				case "Delete":
					conn.QueryString = "delete from rekanan_approval where regnum='" + e.Item.Cells[0].Text + "' and id_komite='" + e.Item.Cells[1].Text + "'";
					conn.ExecuteQuery();
					ViewApprovalCommittee();
					fillDDLCommitee();
					ClearEntryCommittee();
					break;
			}
		
		}

		private void Datagrid1_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			Datagrid1.CurrentPageIndex = e.NewPageIndex;
			ViewSanksiRekanan();
		}

		private void DatGrdExt_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			DatGrdExt.CurrentPageIndex = e.NewPageIndex;
			ViewSanksiRekanan();
		}

		protected void BTN_BACK_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			if (Request.QueryString["par"] != null && Request.QueryString["par"] != "") 
			{
				//string par2=Request.QueryString["par"] + "&mc=" + Request.QueryString["mc2"] + "&regnum=" + Request.QueryString["regnum"] + "&rekanan_ref=" + Request.QueryString["rekanan_ref"] + "&tc=" + Request.QueryString["tc"];
				Response.Redirect(Request.QueryString["par"] + "&mc=" + Request.QueryString["mc2"] + "&regnum=" + Request.QueryString["regnum"] + "&rekanan_ref=" + Request.QueryString["rekanan_ref"] + "&tc=" + Request.QueryString["tc"]+ "&view=" + Request.QueryString["view"]);}
			else
				Response.Redirect("/SME/" + DMS.CuBESCore.Logic.backLink(Request.QueryString["tc"].ToString(), conn));
		}

		private void CekView()
		{
			if(Request.QueryString["view"]=="1")
			{
				BTN_UPLOAD.Enabled = false;
				BTN_UPDATE.Enabled = false;
				BTN_INSERT.Enabled = false;
				BTN_ACQUIRE_INFO.Enabled = false;
				DatGrd.Columns[5].Visible = false;
				DATA_EXPORT.Columns[3].Visible = false;
				RDO_DECISION.Enabled = false;
				DDL_COMMITTEE.Enabled = false;
			}
		}

		private void DatGrd_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			DatGrd.CurrentPageIndex = e.NewPageIndex;
			ViewApprovalCommittee();		
		}
		
	}
}
