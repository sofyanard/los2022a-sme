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

namespace SME.CEA.CBI
{
	/// <summary>
	/// Summary description for WawancaraInput.
	/// </summary>
	public partial class WawancaraInput : System.Web.UI.Page
	{
		protected Tools tool = new Tools();
		protected Connection conn;
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			conn = (Connection) Session["Connection"];
			conn.QueryString="delete from rekanan_iscomply_interview";
			conn.ExecuteQuery();
			
			conn.QueryString="delete from rekanan_scoring_interview";
			conn.ExecuteQuery();

			conn.QueryString="update vw_rekanan_iscomply_interview set score=null";
			conn.ExecuteQuery();

			conn.QueryString = "exec REKANAN_InputData_Scoring_Interview '" + 
				Request.QueryString["rekanan_ref"] + "', '"+
				Request.QueryString["regnum"] + "' ";
			conn.ExecuteNonQuery();


			if (!IsPostBack)
			{
				DDL_IVW_MONTH.Items.Add(new ListItem("--Pilih--",""));
				for (int i = 1; i <= 12; i++)
					DDL_IVW_MONTH.Items.Add(new ListItem(DateAndTime.MonthName(i, false), i.ToString()));	
				
				BindDataQuestionInterviewSum();				
				BindDataQuestionInterview();
				ViewData();
								
			}
			
			conn = (Connection) Session["Connection"];
			ViewMenu();
			ViewUploadFiles();
			CekView();			
			
			this.UPLOAD.Click += new System.EventHandler(this.UPLOAD_Click);
			DATA_EXPORT.ItemCommand += new DataGridCommandEventHandler(DATA_EXPORT_ItemCommand);
			//BTN_SAVE.Attributes.Add("onclick","if(!cek_mandatory(document.Form1)){return false;};");
			this.BTN_SAVE.Click += new System.EventHandler(this.BTN_SAVE_Click);
		}

		private void DGR_IVW_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			DGR_IVW.CurrentPageIndex = e.NewPageIndex;
			BindDataQuestionInterview();
		}

		protected void BTN_PRINT_Click(object sender, System.EventArgs e)
		{
			conn.QueryString="select * from rekanan_wawancara where regnum ='" + Request.QueryString["regnum"]+" '";
			conn.ExecuteQuery();
			
			if (conn.GetRowCount() == 0)
			{
				GlobalTools.popMessage(this, "Data Wawancara belum diisi dan disimpan!");
				return;
			}

			//Cek Kelengkapan Mandatory Wawancara
			conn.QueryString="select * from rekanan_wawancara where regnum='" + Request.QueryString["regnum"] + "' and (intviewer1='' or candidate1='' or intview_date=null) ";
			conn.ExecuteQuery();
			if (conn.GetRowCount() > 0)
			{
				GlobalTools.popMessage(this, "Input Data mandatory Wawancara belum lengkap!");
				return;	
			}

			//Cek Kelengkapan Wawancara untuk Scoring
			conn.QueryString = "select * from rekanan_wawancara where regnum='" + Request.QueryString["regnum"] + "'";
			conn.ExecuteQuery();

			float subtot1=0, subtot2=0, subtot3=0, subtot4=0, subtot5=0, nonsub1=0, nonsub2=0, nonsub3=0;
			subtot1 = float.Parse(SUB_TOT1.Text);
			subtot2 = float.Parse(SUB_TOT2.Text);
			subtot3 = float.Parse(SUB_TOT3.Text);
			subtot4 = float.Parse(SUB_TOT4.Text);
			subtot5 = float.Parse(SUB_TOT5.Text);

			nonsub1 = float.Parse(DGR_IVW.Items[0].Cells[7].Text.Trim());
			nonsub2 = float.Parse(DGR_IVW.Items[1].Cells[7].Text.Trim());
			nonsub3 = float.Parse(DGR_IVW.Items[2].Cells[7].Text.Trim());

			if (subtot1==0 || subtot2==0 || subtot3==0 || subtot4==0 || subtot5==0 || nonsub1==0 || nonsub2==0 || nonsub3==0)
			{
				GlobalTools.popMessage(this, "Input Data Score Wawancara belum lengkap!");
				return;	
			}

			Response.Redirect("/SME/CEA/PrintWawancara.aspx?rekanan_ref=" + Request.QueryString["rekanan_ref"] + "&tc=" + Request.QueryString["tc"] + "&mc=" + Request.QueryString["mc"] + "&regnum=" + Request.QueryString["regnum"]);
		}

		private void BindDataQuestionInterview()
		{
						
			conn.QueryString="select * from VW_REKANAN_Iscomply_Interview";
			conn.ExecuteQuery();
				
			DataTable dt = new DataTable();
			dt = conn.GetDataTable().Copy();
			DGR_IVW.DataSource = dt;
			try 
			{
				DGR_IVW.DataBind();
			}
			catch 
			{
				DGR_IVW.CurrentPageIndex = 0;
				DGR_IVW.DataBind();
			}
			
		}

		private void BindDataQuestionInterviewSum()
		{
			conn.QueryString= "select sum(score)*0.3 as SUM from vw_rekanan_iscomply_interview";
			conn.ExecuteQuery();
				
			DataTable dt = new DataTable();
			dt = conn.GetDataTable().Copy();
			DGR_SUM.DataSource = dt;
			try 
			{
				DGR_SUM.DataBind();
			}
			catch 
			{
				DGR_SUM.CurrentPageIndex = 0;
				DGR_SUM.DataBind();
			}			
			
		}

		private void BindDataTot()
		{
			conn.QueryString= "select * from rekanan_wawancara where regnum = '"+Request.QueryString["regnum"]+"' ";
			conn.ExecuteQuery();
				
			DataTable dt = new DataTable();
			dt = conn.GetDataTable().Copy();
			DGR_TOT.DataSource = dt;
			try 
			{
				DGR_TOT.DataBind();
			}
			catch 
			{
				DGR_TOT.CurrentPageIndex = 0;
				DGR_TOT.DataBind();
			}			
			
		}

		protected void BTN_SAVE_Click(object sender, System.EventArgs e)
		{
			/*try
			{
				conn.QueryString = "exec REKANAN_CHECK_MANDATORY_Verification_Interview '" + Request.QueryString["regnum"] + "'";
				conn.ExecuteNonQuery();
			}

			catch (Exception ex)
			{
				string errmsg = ex.Message.Replace("'","");
				if (errmsg.IndexOf("Last Query:") > 0)
					errmsg = errmsg.Substring(0, errmsg.IndexOf("Last Query:"));
				GlobalTools.popMessage(this, errmsg);
				return;
			}*/
			Int64 now = Int64.Parse(Tools.toISODate(DateTime.Now.Day.ToString(), DateTime.Now.Month.ToString(), DateTime.Now.Year.ToString())), compEstablish;

			Int64 tanggalWawancara;
			//tanggalKunjungan = Int64.Parse(Tools.toISODate(TXT_DAY.Text, DDL_BLN_VISIT.SelectedValue, TXT_YEAR.Text));			

			if (!GlobalTools.isDateValid(TXT_DAY.Text, DDL_IVW_MONTH.SelectedValue, TXT_YEAR.Text)) 
			{
				GlobalTools.popMessage(this, "Tanggal Wawancara tidak valid!");
				return;
			}
			else 
			{			
				tanggalWawancara = Int64.Parse(Tools.toISODate(TXT_DAY.Text, DDL_IVW_MONTH.SelectedValue, TXT_YEAR.Text));

				if (tanggalWawancara > now) 
				{
					GlobalTools.popMessage(this, "Tanggal Wawancara tidak bisa lebih dari tanggal saat ini!!");
					return;
				}
			}


			for (int i = 0; i < DGR_IVW.Items.Count; i++)
			{		
				RadioButtonList rblinterview = (RadioButtonList)DGR_IVW.Items[i].Cells[6].FindControl("RBL_IVW");
			
				try
				{						
					string nilai = null;
					if (rblinterview.SelectedValue == "1")
						nilai = "1";
					else if (rblinterview.SelectedValue == "2")
						nilai = "2";
					else if (rblinterview.SelectedValue == "3")
						nilai = "3";
					else if (rblinterview.SelectedValue == "4")
						nilai = "4";
					else if (rblinterview.SelectedValue == "5")
						nilai = "5";  
					else 
						nilai="0";


					conn.QueryString=" exec REKANAN_Insert_Iscomply_Interview " + DGR_IVW.Items[i].Cells[0].Text.Trim() + ",  "+ tool.ConvertNum(MyConnection.ConvertToDouble(nilai).ToString()) +" ";
					conn.ExecuteNonQuery();

					conn.QueryString="update vw_rekanan_iscomply_interview set score=  iscomply*nilai_bobot";
					conn.ExecuteQuery();
									
					
				}				
						
				catch (Exception ex)
				{			
					
					string errmsg = ex.Message.Replace("'","");
					if (errmsg.IndexOf("Last Query:") > 0)
						errmsg = errmsg.Substring(0, errmsg.IndexOf("Last Query:"));
					GlobalTools.popMessage(this, errmsg);
					return;
				} 				
			}

			BindDataQuestionInterview();	
			
			BindDataQuestionInterviewSum();

			CekSub1();
			CekSub2();
			CekSub3();
			CekSub4();
			CekSub5();
								
			conn.QueryString=" exec REKANAN_WAWANCARA_INSERT '"+
				Request.QueryString["regnum"] + "', "+
				tool.ConvertDate(TXT_DAY.Text, DDL_IVW_MONTH.SelectedValue, TXT_YEAR.Text) + ", '" +
				TXT_DILAKSANAKAN1.Text +"', '"+
				TXT_DILAKSANAKAN2.Text +"', '"+
				TXT_PESERTA1.Text +"', '"+
				TXT_PESERTA2.Text +"', '"+
				TXT_PESERTA3.Text +"', "+
				tool.ConvertFloat(DGR_IVW.Items[0].Cells[7].Text.Trim()) + ", " +
				tool.ConvertFloat(DGR_IVW.Items[1].Cells[7].Text.Trim()) + ", " + 
				tool.ConvertFloat(DGR_IVW.Items[2].Cells[7].Text.Trim()) + ", " +
				tool.ConvertFloat(DGR_SUM.Items[0].Cells[0].Text.Trim()) +", " + 
				tool.ConvertFloat(MyConnection.ConvertToDouble2(SUB_TOT1.Text).ToString()) + ", '" +
				COMENT1.Text +"', " +
				tool.ConvertFloat(MyConnection.ConvertToDouble2(SUB_TOT2.Text).ToString()) + ", '" +
				COMENT2.Text +"', " +
				tool.ConvertFloat(MyConnection.ConvertToDouble2(SUB_TOT3.Text).ToString()) + ", '" +
				COMENT3.Text +"', " +
				tool.ConvertFloat(MyConnection.ConvertToDouble2(SUB_TOT4.Text).ToString()) + ", '" +
				COMENT4.Text +"', " +
				tool.ConvertFloat(MyConnection.ConvertToDouble2(SUB_TOT5.Text).ToString()) + ", '"+
				COMENT5.Text +"', '"+
				CAT.Text +"'";				

			conn.ExecuteNonQuery();

			

			conn.QueryString = "update rekanan_wawancara set s_tot= 0.7*(s_experiance + s_expert+ s_mutu +s_cost+s_others) where regnum= '"+Request.QueryString["regnum"]+"'";
			conn.ExecuteQuery(); 

			conn.QueryString = "update rekanan_wawancara set sc_total=s_tot + nons_tot   where regnum= '"+Request.QueryString["regnum"]+"'";
			conn.ExecuteQuery(); 

			BindDataTot();			

			TXT_SUM.Text = DGR_SUM.Items[0].Cells[0].Text.Trim() ;
			SUB_TOT.Text = DGR_TOT.Items[0].Cells[0].Text.Trim();
			TOT.Text = DGR_TOT.Items[0].Cells[1].Text.Trim();

			ViewData();

			//Cek Kelengkapan Mandatory Wawancara
			conn.QueryString="select * from rekanan_wawancara where regnum='" + Request.QueryString["regnum"] + "' and (intviewer1='' or candidate1='' or intview_date=null) ";
			conn.ExecuteQuery();
			if (conn.GetRowCount() > 0)
			{
				GlobalTools.popMessage(this, "Input Data mandatory Wawancara belum lengkap!");
				return;	
			}

			//Cek Kelengkapan Wawancara untuk Scoring
			conn.QueryString = "select * from rekanan_wawancara where regnum='" + Request.QueryString["regnum"] + "'";
			conn.ExecuteQuery();

			float subtot1=0, subtot2=0, subtot3=0, subtot4=0, subtot5=0, nonsub1=0, nonsub2=0, nonsub3=0;
			subtot1 = float.Parse(SUB_TOT1.Text);
			subtot2 = float.Parse(SUB_TOT2.Text);
			subtot3 = float.Parse(SUB_TOT3.Text);
			subtot4 = float.Parse(SUB_TOT4.Text);
			subtot5 = float.Parse(SUB_TOT5.Text);

			nonsub1 = float.Parse(DGR_IVW.Items[0].Cells[7].Text.Trim());
			nonsub2 = float.Parse(DGR_IVW.Items[1].Cells[7].Text.Trim());
			nonsub3 = float.Parse(DGR_IVW.Items[2].Cells[7].Text.Trim());

			if (subtot1==0 || subtot2==0 || subtot3==0 || subtot4==0 || subtot5==0 || nonsub1==0 || nonsub2==0 || nonsub3==0)
			{
				GlobalTools.popMessage(this, "Input Data Score Wawancara belum lengkap!");
				return;	
			}
									
			
			//Cek Score Wawancara jika nilainya < 3 
			float score=0;			
			
			conn.QueryString = "select sc_total from rekanan_wawancara where regnum='" + Request.QueryString["regnum"] + "'";
			conn.ExecuteQuery();

			score = float.Parse(TOT.Text);			

			if(score < 3)
			{		
				GlobalTools.popMessage(this, "Jika ingin ke tahap berikutnya, nilai wawancara harus > 3");
				return;				
			}
						
		}		

		private void ViewData()
		{
			conn.QueryString=" select * from rekanan_wawancara where regnum='"+Request.QueryString["regnum"]+"' ";
			conn.ExecuteQuery();

			TXT_DAY.Text=tool.FormatDate_Day(conn.GetFieldValue("INTVIEW_DATE"));
			try{ DDL_IVW_MONTH.SelectedValue = tool.FormatDate_Month(conn.GetFieldValue("INTVIEW_DATE"));}
			catch{DDL_IVW_MONTH.SelectedValue="";}
			TXT_YEAR.Text=tool.FormatDate_Year(conn.GetFieldValue("INTVIEW_DATE"));
			TXT_DILAKSANAKAN1.Text=conn.GetFieldValue("INTVIEWER1");
			TXT_DILAKSANAKAN2.Text=conn.GetFieldValue("INTVIEWER2");
			TXT_PESERTA1.Text=conn.GetFieldValue("CANDIDATE1");
			TXT_PESERTA2.Text=conn.GetFieldValue("CANDIDATE2");
			TXT_PESERTA3.Text=conn.GetFieldValue("CANDIDATE3");
			TXT_SUM.Text=conn.GetFieldValue("NONS_TOT");
			SUB_TOT1.Text=conn.GetFieldValue("S_EXPERIANCE");
			COMENT1.Text=conn.GetFieldValue("S_EXP_COMMENT");
			SUB_TOT2.Text=conn.GetFieldValue("S_EXPERT");
			COMENT2.Text=conn.GetFieldValue("S_EXPERT_COMMENT");
			SUB_TOT3.Text=conn.GetFieldValue("S_MUTU");
			COMENT3.Text=conn.GetFieldValue("S_MUTU_COMMENT");
			SUB_TOT4.Text=conn.GetFieldValue("S_COST");
			COMENT4.Text=conn.GetFieldValue("S_COST_COMMENT");
			SUB_TOT5.Text=conn.GetFieldValue("S_OTHERS");
			COMENT5.Text=conn.GetFieldValue("S_OTHERS_COMMENT");
			SUB_TOT.Text=conn.GetFieldValue("S_TOT");
			TOT.Text=conn.GetFieldValue("SC_TOTAL");
			CAT.Text = conn.GetFieldValue("cat");

			FillSub1();
			FillSub2();
			FillSub3();
			FillSub4();
			FillSub5();

			if(conn.GetRowCount()>0)
			{
				for (int i = 0; i < DGR_IVW.Items.Count; i++)
				{		
					DGR_IVW.Items[i].Cells[7].Text = conn.GetFieldValue(0,i+7);
				}
			

				conn.QueryString = "exec rekanan_fillgrid '" + Request.QueryString["regnum"] + "'";
				conn.ExecuteQuery();

				string time = conn.GetFieldValue(0,0);
				string prepare = conn.GetFieldValue(0,1);
				string delivary = conn.GetFieldValue(0,2);
			
				for (int i = 0; i < DGR_IVW.Items.Count; i++)
				{		
					RadioButtonList rblinterview = (RadioButtonList)DGR_IVW.Items[i].Cells[6].FindControl("RBL_IVW");
					try{rblinterview.SelectedValue = conn.GetFieldValue(0,i);}
					catch{}
						
				}
			}
		}
	
		protected void BTN_CLEAR_Click(object sender, System.EventArgs e)
		{
			ClearData();
		}

		private void ClearData()
		{
			TXT_DAY.Text=""; 
			DDL_IVW_MONTH.SelectedValue=""; 
			TXT_YEAR.Text="";
			TXT_DILAKSANAKAN1.Text="";
			TXT_DILAKSANAKAN2.Text="";
			TXT_PESERTA1.Text="";
			TXT_PESERTA2.Text="";
			TXT_PESERTA3.Text="";
			COMENT1.Text="";
			COMENT2.Text="";
			COMENT3.Text="";
			COMENT4.Text="";
			COMENT5.Text="";
		}

		private void DATA_EXPORT_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			string directory = "";
			conn.QueryString = "SELECT EXPORT_URL FROM REKANANRFEXPORT WHERE EXPORT_ID = 'daftar'";
			conn.ExecuteQuery();
			if (conn.GetRowCount() > 0)
			{
				directory = Server.MapPath(conn.GetFieldValue("EXPORT_URL").Trim());
			}

			switch (((LinkButton)e.CommandSource).CommandName)
			{
				case "delete":
					conn.QueryString = "EXEC REKANAN_DELETE_FILEDH_UPLOAD '" + e.Item.Cells[0].Text + "'";
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

		private void ViewUploadFiles()
		{
			string url = "";
			conn.QueryString = "SELECT EXPORT_URL FROM REKANANRFEXPORT WHERE EXPORT_ID = '" + "daftar" + "'";
			conn.ExecuteQuery();

			if (conn.GetRowCount() > 0) 
			{
				url = conn.GetFieldValue("EXPORT_URL");
			}

			System.Data.DataTable dt = new System.Data.DataTable();
			conn.QueryString = "SELECT ID_UPLOAD_REKANAN, FILE_UPLOAD_REKANAN_NAME FROM REKANAN_FILE_UPLOAD where regnum='" +Request.QueryString["regnum"]+ "'";
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
				HyperLink HpDownload = (HyperLink) DATA_EXPORT.Items[i-1].Cells[2].FindControl("UPL_REKANAN_DOWNLOAD");
				LinkButton HpDelete = (LinkButton) DATA_EXPORT.Items[i-1].Cells[3].FindControl("UPL_REKANAN_DELETE");
				HpDownload.NavigateUrl = url + conn.GetFieldValue("FILE_UPLOAD_REKANAN_NAME");
			} 
		}

		private void UPLOAD_Click(object sender, System.EventArgs e)
		{
			string directory;
			int counter = 0;
			int max_id = 10000;
			string outputfilename = "";

			if (TXT_FILE_UPLOAD.PostedFile.FileName == "")
			{
			}
			else
			{
				//Get Export Properties
				conn.QueryString = "EXEC REKANAN_INSERT_FILE_UPLOAD '" +Request.QueryString["regnum"]+ "', '" + Session["USERID"].ToString() + "','" +
					Path.GetFileName(TXT_FILE_UPLOAD.PostedFile.FileName) + "'";
				conn.ExecuteQuery();
			}


			//Get Export Properties
			/*conn.QueryString = "EXEC REKANAN_INSERT_FILE_UPLOAD '" +Request.QueryString["regnum"]+ "', '" + Session["USERID"].ToString() + "','" +
				Path.GetFileName(TXT_FILE_UPLOAD.PostedFile.FileName) + "'";
			conn.ExecuteQuery(); */

			conn.QueryString = "SELECT MAX(ID_UPLOAD_REKANAN) as MAX_ID from [REKANAN_FILE_UPLOAD]";
			conn.ExecuteQuery();

			if (conn.GetRowCount() > 0)
			{
				max_id = int.Parse(conn.GetFieldValue("MAX_ID"));
			}

			conn.QueryString = "SELECT FILE_UPLOAD_REKANAN_NAME from [REKANAN_FILE_UPLOAD] where ID_UPLOAD_REKANAN = '" + max_id + "'";
			conn.ExecuteQuery();

			if (conn.GetRowCount() > 0)
			{
				outputfilename = conn.GetFieldValue("FILE_UPLOAD_REKANAN_NAME");
			}

			conn.QueryString = "SELECT EXPORT_URL FROM REKANANRFEXPORT WHERE EXPORT_ID = 'daftar'";
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
        
		private void ViewMenu()
		{
			Menu.Controls.Clear();
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
							strtemp = "regnum=" + Request.QueryString["regnum"] + "&rekanan_ref="+Request.QueryString["rekanan_ref"]  + "&tc=" + Request.QueryString["tc"] + "&exist=" + Request.QueryString["exist"]+ "&view=" + Request.QueryString["view"];
						else	
							strtemp = "regnum=" + Request.QueryString["regnum"] + "&rekanan_ref="+Request.QueryString["rekanan_ref"]  + "&mc=" + Request.QueryString["mc"]+ "&exist=" + Request.QueryString["exist"]+ "&tc="+Request.QueryString["tc"]+ "&view=" + Request.QueryString["view"];
						if (conn.GetFieldValue(i,3).IndexOf("?par=") < 0 && conn.GetFieldValue(i,3).IndexOf("&par=") < 0)  
							strtemp = strtemp + "&par=" + Request.QueryString["par"] + "&mc2=" + Request.QueryString["mc2"];
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

		private void FillSub1()
		{
			if(SUB_TOT1.Text=="0,3")
				SUB11.Checked = true;
			else if(SUB_TOT1.Text=="0,6")
				SUB12.Checked = true;
			else if(SUB_TOT1.Text=="0,9")
				SUB13.Checked = true;
			else if(SUB_TOT1.Text=="1,2")
				SUB14.Checked = true;
			else if(SUB_TOT1.Text=="1,5")
				SUB15.Checked = true;
		}

		private void FillSub2()
		{
			if(SUB_TOT2.Text=="0,3")
				SUB21.Checked = true;
			else if(SUB_TOT2.Text=="0,6")
				SUB22.Checked = true;
			else if(SUB_TOT2.Text=="0,9")
				SUB23.Checked = true;
			else if(SUB_TOT2.Text=="1,2")
				SUB24.Checked = true;
			else if(SUB_TOT2.Text=="1,5")
				SUB25.Checked = true;
		}

		private void FillSub3()
		{
			if(SUB_TOT3.Text=="0,2")
				SUB31.Checked = true;
			else if(SUB_TOT3.Text=="0,4")
				SUB32.Checked = true;
			else if(SUB_TOT3.Text=="0,6")
				SUB33.Checked = true;
			else if(SUB_TOT3.Text=="0,8")
				SUB34.Checked = true;
			else if(SUB_TOT3.Text=="1")
				SUB35.Checked = true;
		}

		private void FillSub4()
		{
			if(SUB_TOT4.Text=="0,1")
				SUB41.Checked = true;
			else if(SUB_TOT4.Text=="0,2")
				SUB42.Checked = true;
			else if(SUB_TOT4.Text=="0,3")
				SUB43.Checked = true;
			else if(SUB_TOT4.Text=="0,4")
				SUB44.Checked = true;
			else if(SUB_TOT4.Text=="0,5")
				SUB45.Checked = true;
		}

		private void FillSub5()
		{
			if(SUB_TOT5.Text=="0,1")
				SUB51.Checked = true;
			else if(SUB_TOT5.Text=="0,2")
				SUB52.Checked = true;
			else if(SUB_TOT5.Text=="0,3")
				SUB53.Checked = true;
			else if(SUB_TOT5.Text=="0,4")
				SUB54.Checked = true;
			else if(SUB_TOT5.Text=="0,5")
				SUB55.Checked = true;
		}

		private void CekSub1()
		{	
			if(SUB11.Checked)
				SUB_TOT1.Text="0.3";
			else if(SUB12.Checked)
				SUB_TOT1.Text="0.6";
			else if(SUB13.Checked)
				SUB_TOT1.Text="0.9";
			else if(SUB14.Checked)
				SUB_TOT1.Text="1.2";
			else if(SUB15.Checked)
				SUB_TOT1.Text="1.5";
			else
				SUB_TOT1.Text="0";
		}

		private void CekSub2()
		{
			if(SUB21.Checked)
				SUB_TOT2.Text="0.3";
			else if(SUB22.Checked)
				SUB_TOT2.Text="0.6";
			else if(SUB23.Checked)
				SUB_TOT2.Text="0.9";
			else if(SUB24.Checked)
				SUB_TOT2.Text="1.2";
			else if(SUB25.Checked)
				SUB_TOT2.Text="1.5";
			else
				SUB_TOT2.Text="0";
		}

		private void CekSub3()
		{
			if(SUB31.Checked)
				SUB_TOT3.Text="0.2";
			else if(SUB32.Checked)
				SUB_TOT3.Text="0.4";
			else if(SUB33.Checked)
				SUB_TOT3.Text="0.6";
			else if(SUB34.Checked)
				SUB_TOT3.Text="0.8";
			else if(SUB35.Checked)
				SUB_TOT3.Text="1";
			else
				SUB_TOT3.Text="0";
		}

		private void CekSub4()
		{
			if(SUB41.Checked)
				SUB_TOT4.Text="0.1";
			else if(SUB42.Checked)
				SUB_TOT4.Text="0.2";
			else if(SUB43.Checked)
				SUB_TOT4.Text="0.3";
			else if(SUB44.Checked)
				SUB_TOT4.Text="0.4";
			else if(SUB45.Checked)
				SUB_TOT4.Text="0.5";
			else
				SUB_TOT4.Text="0";
		}

		private void CekSub5()
		{
			
			if(SUB51.Checked)
				SUB_TOT5.Text="0.1";
			else if(SUB52.Checked)
				SUB_TOT5.Text="0.2";
			else if(SUB53.Checked)
				SUB_TOT5.Text="0.3";
			else if(SUB54.Checked)
				SUB_TOT5.Text="0.4";
			else if(SUB55.Checked)
				SUB_TOT5.Text="0.5";
			else
				SUB_TOT5.Text="0";
		}

		protected void BTN_BACK_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			/*if (Request.QueryString["par"] != null && Request.QueryString["par"] != "") 
			{
				Response.Redirect(Request.QueryString["par"] + "&mc=" + Request.QueryString["mc2"] + "&regnum=" + Request.QueryString["regnum"] + "&rekanan_ref=" + Request.QueryString["rekanan_ref"] + "&tc=" + Request.QueryString["tc"]+ "&view=" + Request.QueryString["view"]);}
			else
				Response.Redirect("/SME/" + DMS.CuBESCore.Logic.backLink(Request.QueryString["tc"].ToString(), conn));
			*/
			Response.Redirect("ListRekananInput.aspx?tc=" + Request.QueryString["tc"]+ "&mc=" + Request.QueryString["mc"]);
		}

		private void DATA_EXPORT_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			DATA_EXPORT.CurrentPageIndex = e.NewPageIndex;
			ViewUploadFiles();
		}

		private void CekView()
		{
			if(Request.QueryString["view"]=="1")
			{
				DGR_IVW.Columns[6].Visible = false;
				BTN_SAVE.Enabled = false;
				TXT_DAY.ReadOnly = true;
				TXT_YEAR.ReadOnly = true;
				TXT_DILAKSANAKAN1.ReadOnly = true;
				TXT_DILAKSANAKAN2.ReadOnly = true;
				SUB11.Enabled = false;
				SUB12.Enabled = false;
				SUB13.Enabled = false;
				SUB14.Enabled = false;
				SUB15.Enabled = false;
				COMENT1.ReadOnly = true;
				SUB21.Enabled = false;
				SUB22.Enabled = false;
				SUB23.Enabled = false;
				SUB24.Enabled = false;
				SUB25.Enabled = false;
				COMENT2.ReadOnly = true;
				SUB31.Enabled = false;
				SUB32.Enabled = false;
				SUB33.Enabled = false;
				SUB34.Enabled = false;
				SUB35.Enabled = false;
				COMENT3.ReadOnly = true;
				SUB41.Enabled = false;
				SUB42.Enabled = false;
				SUB43.Enabled = false;
				SUB44.Enabled = false;
				SUB45.Enabled = false;
				COMENT4.ReadOnly = true;
				SUB51.Enabled = false;
				SUB52.Enabled = false;
				SUB53.Enabled = false;
				SUB54.Enabled = false;
				SUB55.Enabled = false;
				COMENT5.ReadOnly = true;
				DDL_IVW_MONTH.Enabled = false;
				TXT_SUM.ReadOnly = true;
				TXT_PESERTA1.ReadOnly = true;
				TXT_PESERTA2.ReadOnly = true;
				TXT_PESERTA3.ReadOnly = true;
				SUB_TOT1.ReadOnly = true;
				SUB_TOT2.ReadOnly = true;
				SUB_TOT3.ReadOnly = true;
				SUB_TOT4.ReadOnly = true;
				SUB_TOT5.ReadOnly = true;
				BTN_CLEAR.Enabled = false;
				BTN_PRINT.Enabled = false;
				UPLOAD.Enabled = false;
				DATA_EXPORT.Columns[3].Visible = false;
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
			this.DATA_EXPORT.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.DATA_EXPORT_PageIndexChanged);

		}
		#endregion
	}
}
