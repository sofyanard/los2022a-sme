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

namespace SME.PRRK
{
	/// <summary>
	/// Summary description for MainPRRK.
	/// </summary>
	public partial class MainPRRK : System.Web.UI.Page
	{
		protected Connection conn;
		protected Tools tool = new Tools();
		string var_user, var_Nota, var_idExport, prog_code;
		string m_in_small="";
		string m_in_middle ="";
		string m_in_corporate ="";
		object oMissingObject = System.Reflection.Missing.Value;

		protected void Page_Load(object sender, System.EventArgs e)
		{
			conn = (Connection) Session["Connection"];
			var_user = Session["USERID"].ToString();
			
			

			InitializeEvent();

			conn.QueryString = "select in_small, in_middle, in_corporate from rfinitial";
			conn.ExecuteQuery();
					 
			m_in_small = conn.GetFieldValue("in_small");
			m_in_middle = conn.GetFieldValue("in_middle");
			m_in_corporate = conn.GetFieldValue("in_corporate");

			if(m_in_corporate!=prog_code) prog_code = "";

			if (!IsPostBack)
			{	
				fillDropDowns();

				ViewDataApplication();
				AddUserFoward();
				ViewFileUpload();

				var_Nota = "select NOTA_ID, NOTA_DESC from NOTA_ANALISA where PROGRAMID = '" + prog_code + " 'order by NOTA_DESC";
				GlobalTools.fillRefList(DDL_FORMAT_TYPE, var_Nota , false, conn);

				ViewFileExport();
			}

			var_idExport = DDL_FORMAT_TYPE.SelectedValue;

			if(var_idExport==string.Empty)
				BTN_EXPORT.Enabled = false;
			else
				BTN_EXPORT.Enabled = true;

			SecureData();
			ViewMenu();

			TR_KET1.Visible = false;
			TR_KET2.Visible = false;
			TR_FWD.Visible = false;
			TR_DOC1.Visible = false;
			TR_DOC2.Visible = false;
			TR_DOC3.Visible = false;
			TR_DOC4.Visible = false;

			updatestatus.Attributes.Add("onclick","if(!update()){return false;};");
			BtnFoward.Attributes.Add("onclick","if(!update1()){return false;};");
			BTN_EXPORT.Attributes.Add("onclick", "if (!exportInProgress()) { return false; }");
		}

		/// <summary>
		/// Mengisi field dropdown yang ada pada page
		/// </summary>
		private void fillDropDowns() 
		{
			GlobalTools.fillRefList(DDL_BU_COMMENTS, "select kondisiid, kondisidesc from rfkondisi where active='1'", false, conn);
		}

		private void InitializeEvent()
		{
			this.BTN_BACK.Click += new System.Web.UI.ImageClickEventHandler(this.BTN_BACK_Click);
			this.BTN_UPLOAD.Click += new System.EventHandler(this.BTN_UPLOAD_Click);
			this.BtnSave.Click += new System.EventHandler(this.BtnSave_Click);
			this.BtnFoward.Click += new System.EventHandler(this.BtnFoward_Click);
			this.updatestatus.Click += new System.EventHandler(this.updatestatus_Click);
			this.TXT_VERIFY.TextChanged += new EventHandler(TXT_VERIFY_TextChanged);
			this.TXT_VERIFY2.TextChanged += new EventHandler(TXT_VERIFY2_TextChanged);
		}

		/// <summary>
		/// Menghapus file hasil upload
		/// </summary>
		/// <param name="directory">directory yang menyimpan file</param>
		/// <param name="filename">nama file saja</param>
		private void deleteFile(string directory, string filename) 
		{
			if (File.Exists(directory + filename)) 
			{
				File.Delete(directory + filename);
			}
		}

		#region Web Form Designer generated code
		override protected void OnInit(EventArgs e)
		{
			//
			// CODEGEN: This call is required by the ASP.NET Web Form Designer.
			//
            
			base.OnInit(e);
            if (!this.DesignMode)
            {
                InitializeComponent();
            }
		}
		
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.dsafasfd
		/// </summary>
		private void InitializeComponent()
		{    
			this.DatGrid.ItemCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.DatGrid_ItemCommand);
			this.DATA_EXPORT.ItemCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.DATA_EXPORT_ItemCommand);

		}
		#endregion

		private void SecureData() 
		{
			if (Request.QueryString["prrk"]== "0") 
			{
				BTN_UPLOAD.Visible			= false;
				BtnSave.Visible				= false;
				TXT_FILE_UPLOAD.Disabled	= true;
				updatestatus.Visible		= false;
//				LNK_SYARAT2.Visible			= false;
				TXT_PK_KETERANGAN.ReadOnly	= true;		//--- Keterangan
				TXT_PK_ANALIS.ReadOnly		= true;		
				DDL_BU_COMMENTS.Enabled		= false;
				CB_FORWARD.Enabled			= false;	//--- Forward/No
				DDL_FORMAT_TYPE.Enabled		= false;
                BTN_APPROVE.Visible = false;
                BTN_REJECT.Visible = false;
			}
		}

		private void AddUserFoward()
		{
			string var_cbc, var_inbranch, var_complevel, var_small, var_corporate,
				var_middle, var_sgprrk; //sgupawal, sgup, koma

			conn.QueryString = "select CBC_CODE, AP_COMPLEVEL from APPLICATION app left join RFBRANCH rb on app.BRANCH_CODE = rb.BRANCH_CODE "+
							   "where AP_REGNO = '"+Request.QueryString["regno"]+"'";
			conn.ExecuteQuery();
			var_cbc = conn.GetFieldValue("CBC_CODE").ToString();
			var_complevel	= conn.GetFieldValue("AP_COMPLEVEL").ToString();

			conn.QueryString = "select IN_BRANCHPUSAT, IN_SMALL, IN_MIDDLE, IN_SGPRRK, IN_CORPORATE from RFINITIAL";
			conn.ExecuteQuery();
			var_inbranch = conn.GetFieldValue("IN_BRANCHPUSAT").ToString();
			var_small	 = conn.GetFieldValue("IN_SMALL").ToString();
			var_middle	 = conn.GetFieldValue("IN_MIDDLE").ToString();
			var_sgprrk	 = conn.GetFieldValue("IN_SGPRRK").ToString();
			var_corporate = conn.GetFieldValue("IN_CORPORATE").ToString();

			//----Cari Atasan-------------------------
			/*sgupawal = Session["GROUPID"].ToString();
			sgup = "(";
			koma = "";
			while (sgupawal.Trim() != "") 
			{
				conn.QueryString = "select distinct smlupgroup, midupgroup from vw_approvaluser where groupid = '"+sgupawal+"'"+
					" and (usercbc = '"+var_cbc+"' or userbranch = '"+var_inbranch+"') ";
				conn.ExecuteQuery();
				
				if (conn.GetRowCount() == 0)
					sgupawal = "";

				for (int i=0; i< conn.GetRowCount(); i++)
				{
					if (var_complevel == var_small)
					{
						if (conn.GetFieldValue("smlupgroup") != "")
						{
							sgup = sgup + koma + "'"+conn.GetFieldValue("smlupgroup")+"'";	
							koma = ",";
						}
						sgupawal = conn.GetFieldValue("smlupgroup");
					}
					else if (var_complevel == var_middle)
					{
						if (conn.GetFieldValue("midupgroup") != "")
						{
							sgup = sgup + koma + "'"+conn.GetFieldValue("midupgroup")+"'";	
							koma = ",";
						}
						sgupawal = conn.GetFieldValue("midupgroup");
					}
				}	

			}
			if (sgup == "(")
				sgup = sgup + "''";
			sgup = sgup + ")";

			conn.QueryString = "select USERID, USERFULLNM from vw_approvaluser where groupid in "+sgup+" "+
				" and (usercbc = '"+var_cbc+"' or userbranch = '"+var_inbranch+"') ";
			conn.ExecuteQuery();			
			for (int i=0; i< conn.GetRowCount(); i++)
				DDL_USERID.Items.Add(new ListItem(conn.GetFieldValue(i, 1), conn.GetFieldValue(i, 0)));

			//----------------------------------------

			//--Cari Bawahan--------------------------
			string grouptemp, sgdown;
			grouptemp = Session["GROUPID"].ToString();
			sgdown = "(";
			koma = "";
			while (grouptemp != "") 
			{
				if (var_complevel == var_small)
				{
					conn.QueryString = "select * from vw_approvaluser where smlupgroup = '"+grouptemp+"'"+
						" and (usercbc = '"+var_cbc+"' or userbranch = '"+var_inbranch+"') ";
				}
				else if (var_complevel == var_middle)
				{
					conn.QueryString = "select * from vw_approvaluser where midupgroup = '"+grouptemp+"'"+
						" and (usercbc = '"+var_cbc+"' or userbranch = '"+var_inbranch+"') ";
				}
				conn.ExecuteQuery();

				if (conn.GetRowCount() == 0)
					grouptemp = "";

				for (int i=0; i< conn.GetRowCount(); i++)
				{
					if (conn.GetFieldValue("groupid") != "")
					{
						sgdown = sgdown + koma + "'"+conn.GetFieldValue("groupid")+"'";	
						koma = ",";
					}
					grouptemp = conn.GetFieldValue("groupid");
				}
			}
			if (sgdown == "(")
				sgdown = sgdown + "''";
			sgdown = sgdown + ")";
			
			conn.QueryString = "select USERID, USERFULLNM  from vw_approvaluser where (groupid in "+sgdown+" "+
				" or groupid = '"+var_sgprrk+"') "+
				" and (usercbc = '"+var_cbc+"' or userbranch = '"+var_inbranch+"') ";
			conn.ExecuteQuery();
			for (int i=0; i< conn.GetRowCount(); i++)
				DDL_USERID.Items.Add(new ListItem(conn.GetFieldValue(i, 1), conn.GetFieldValue(i, 0)));*/
			//----------------------------------------
			conn.QueryString = "select USERID, USERFULLNM  from vw_approvaluser where substring(groupid,1,2) = '02' "+
							   " and (usercbc = '"+var_cbc+"' or userbranch = '"+var_inbranch+"') ";
			conn.ExecuteQuery();
			for (int i=0; i< conn.GetRowCount(); i++)
				DDL_USERID.Items.Add(new ListItem(conn.GetFieldValue(i, 1), conn.GetFieldValue(i, 0)));
		}

		private void ViewDataApplication()
		{
			conn.QueryString = "select * from VW_PRRK_MAIN where AP_REGNO = '" +Request.QueryString["regno"]+ "'";
			conn.ExecuteQuery();
			TXT_AP_REGNO.Text		= conn.GetFieldValue("AP_REGNO");
			TXT_CU_REF.Text			= conn.GetFieldValue("CU_REF");
			TXT_AP_SIGNDATE.Text	= tool.FormatDate(conn.GetFieldValue("AP_SIGNDATE"));
			TXT_PROGRAMDESC.Text	= conn.GetFieldValue("PROGRAMDESC");
			TXT_BRANCH_NAME.Text	= conn.GetFieldValue("BRANCH_NAME");
			TXT_AP_RELMNGR.Text		= conn.GetFieldValue("SU_FULLNAME");
			LBL_CU_CUSTTYPEID.Text	= conn.GetFieldValue("CU_CUSTTYPEID");
			TXT_AP_TEAMLEADER.Text	= conn.GetFieldValue("AP_TEAMLEADER");
			TXT_PK_KETERANGAN.Text	= conn.GetFieldValue("PK_KETERANGAN");
			TXT_PK_ANALIS.Text		= conn.GetFieldValue("PK_ANALIS");
			DDL_BU_COMMENTS.SelectedValue	= conn.GetFieldValue("BU_COMMENTS");

			if (TXT_PK_ANALIS.Text.Trim() == "")
			{
				conn.QueryString = "select AUDITORID from CREDITANALYSIS where AP_REGNO = '"+Request.QueryString["regno"]+"'";
				conn.ExecuteQuery();
				TXT_PK_ANALIS.Text = conn.GetFieldValue("AUDITORID");
			}
			//diremark tgl 12102004 o.denny utk kebuthan menampilkan kolom user yg menambah syarat di page creditproposal/syarat-syarat
			//-- this.LNK_SYARAT2.NavigateUrl = "/SME/CreditProposal/Syarat.aspx?regno=" + Request.QueryString["regno"] + "&curef=" + Request.QueryString["curef"] + "&mc="+Request.QueryString["mc"]+"&tc="+Request.QueryString["tc"];
		//	this.LNK_SYARAT2.NavigateUrl = "/SME/CreditProposal/Syarat.aspx?regno=" + Request.QueryString["regno"] + "&curef=" + Request.QueryString["curef"] + "&mc="+Request.QueryString["mc"]+"&tc="+Request.QueryString["tc"]+"&prrk=yes";
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

		private void BtnFoward_Click(object sender, System.EventArgs e)
		{
			//Update PPRK BY
			string var_nextby = DDL_USERID.SelectedValue.ToString().Trim();
			string var_nextby_fullname = DDL_USERID.SelectedItem.Text;
			//pipeline conn.QueryString = "update APPLICATION set AP_PRRKBY = '" +var_nextby.ToString()+"' where AP_REGNO = '" +Request.QueryString["regno"]+ "'";
			//conn.ExecuteQuery();

            /*
			conn.QueryString = "select SG_APRVTRACK from SCUSER sc join SCGROUP sg on sc.GROUPID = sg.GROUPID "+
				"where USERID = '" +var_nextby+ "'";
			conn.ExecuteQuery();
			string var_prrk = conn.GetFieldValue("SG_APRVTRACK");
			*/
			/// Get PRRK track from initial
			/// 
			conn.QueryString = "select IN_PRRK from RFINITIAL";
			conn.ExecuteQuery();
			string var_prrk = conn.GetFieldValue("IN_PRRK");


			//-- YUDI --
			//Update Track History
			conn.QueryString = "select * from vw_currtrack where ap_regno = '"+Request.QueryString["regno"]+"'";
			conn.ExecuteQuery();
			DataTable dt_currtrack = new DataTable();
			dt_currtrack = conn.GetDataTable().Copy();
			for (int i = 0; i < dt_currtrack.Rows.Count;i++) 
			{
				string var_apptype		= dt_currtrack.Rows[i]["apptype"].ToString();
				string var_prod			= dt_currtrack.Rows[i]["productid"].ToString();
				string PROD_SEQ			= dt_currtrack.Rows[i]["PROD_SEQ"].ToString();

				conn.QueryString = "select max(th_seq)+1 th_seq from trackhistory "+
					" where ap_regno = '" + Request.QueryString["regno"] + 
					"' and productid = '" + var_prod + 
					"' and apptype = '" + var_apptype + 
					"' and PROD_SEQ = '" + PROD_SEQ + "'";
				conn.ExecuteQuery();
				int var_seq = Convert.ToInt16(conn.GetFieldValue("th_seq"));
				conn.QueryString = "insert trackhistory(ap_regno, apptype, productid, trackcode, th_seq, th_trackdate, th_trackby, PROD_SEQ, TH_TRACKNEXTBY) "+
					" values('"+Request.QueryString["regno"]+"', '"+var_apptype+"', '"+var_prod+"', '"+var_prrk+"', '"+var_seq+"', getdate(), '"+Session["USERID"].ToString()+"', '" + PROD_SEQ + "', '" + var_nextby.ToString() + "')";
				conn.ExecuteQuery();
				conn.QueryString = "update overall_sla_responsetime set userid = '" +  var_nextby.ToString() +
					"', ap_currtrack = '" + var_prrk + "' where ap_regno = '" + Request.QueryString["regno"] + "' ";
				conn.ExecuteNonQuery();

				/// Get Track Name Approval
				/// 
				string trackname = "";
				conn.QueryString = "exec SP_AUDITTRAIL_TRACKNAMEAPPRV '" + Request.QueryString["regno"] + "'";
				conn.ExecuteQuery();
				trackname = conn.GetFieldValue("TRACKNAME");

				/// Audit Trail Tracking for application
				/// 
				try 
				{ 
					conn.QueryString = "exec SP_AUDITTRAIL_APP '" + 
						Request.QueryString["regno"] + "', '"+
						var_apptype + "', '" +
						var_prod + "', '" +
						PROD_SEQ + "', '" + 
						Request.QueryString["curef"] + "', NULL, '" + 
						lbl_PRRK_Forward.Text +" "+ var_nextby_fullname.ToString() +"', NULL, '" + 
						Session["USERID"].ToString() + "', NULL, 'Y', '" + 
						trackname + "'";
					conn.ExecuteNonQuery();
				} 
				catch (Exception ex)
				{
					/// TODO : 
					/// Try .. catch harus diberikan informasi lebih lengkap 				
					/// Sekarang dikosongkan dulu karena belum migrasi, tapi sudah UAT
					/// 
					Response.Write("<!-- " + ex.Message.ToString() + " -->");
				}
			}

			Response.Redirect("ListPRRK.aspx?tc=" + Request.QueryString["tc"] + "&mc=" + Request.QueryString["mc"]);
		}

		protected void updatestatus_Click(object sender, System.EventArgs e)
		{
			Response.Write("<script for=window event=onload language='javascript'>PopupPage('../VerifyUser.aspx?userid=" + var_user + "&theForm=Form1&theObj=TXT_VERIFY', '430','150');</script>");
		}

		protected void BtnSave_Click(object sender, System.EventArgs e)
		{
			conn.QueryString = "exec PRRK_MAIN '"+Request.QueryString["regno"]+"', '"+TXT_PK_ANALIS.Text+"', '"+DDL_BU_COMMENTS.SelectedValue+"', '"+TXT_PK_KETERANGAN.Text+"'";
			conn.ExecuteNonQuery();
			ViewDataApplication();
		}

		private void BTN_VIEWNOTA_Click(object sender, System.EventArgs e)
		{
			Response.Write("<script language='javascript'>window.open('NotaPRRK.aspx','NotaPRRK','status=no,scrollbars=yes,width=1000,height=700');</script>");

		}

		private void TXT_VERIFY_TextChanged(object sender, System.EventArgs e)
		{
			if(this.TXT_VERIFY.Text != "")
			{
				this.TXT_VERIFY.Text = "";

				try
				{
					conn.QueryString  = "EXEC AIP_APPROVE '" + Request.QueryString["regno"] + "', '" + Session["UserID"].ToString() + "', '" + Request.QueryString["tc"].ToString() + "'";
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

				string msg = getNextStepMsg(Request.QueryString["regno"]);
				Response.Redirect("ListPRRK.aspx?tc=" + Request.QueryString["tc"] + "&mc=" + Request.QueryString["mc"] + "&msg=" + msg);
			}
		}

		private void TXT_VERIFY2_TextChanged(object sender, System.EventArgs e)
		{
			if(this.TXT_VERIFY2.Text != "")
			{
				this.TXT_VERIFY2.Text = "";

				try
				{
					conn.QueryString  = "EXEC AIP_REJECT '" + Request.QueryString["regno"] + "', '" + Session["UserID"].ToString() + "', '" + Request.QueryString["tc"].ToString() + "'";
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

				string msg = getNextStepMsg(Request.QueryString["regno"]);
				Response.Redirect("ListPRRK.aspx?tc=" + Request.QueryString["tc"] + "&mc=" + Request.QueryString["mc"] + "&msg=" + msg);
			}
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
		private void BTN_EXPORT_Click(object sender, System.EventArgs e)
		{

			string szId = tool.ConvertNull(DDL_FORMAT_TYPE.SelectedValue);
			string mStatus = string.Empty ;
			string mStatusReport = string.Empty;
			
			try
			{
				string szUser = DDL_USERID.SelectedValue;

				conn.QueryString = "Select * from NOTA_ANALISA where NOTA_ID = '" + var_idExport + "'";
				conn.ExecuteQuery();
				
				if (conn.GetRowCount() > 0) 
				{
					string nota = conn.GetFieldValue("NOTA_SHEET");
					string b_unit = conn.GetFieldValue("B_UNIT");

					System.Threading.Thread.CurrentThread.CurrentCulture = System.Globalization.CultureInfo.CreateSpecificCulture("en-US");
					System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("en-US");
					
					if(nota=="ANALISA")
					{
						/*
						if (b_unit.ToUpper() == m_in_small.ToUpper()) 
							mStatus = p_CreateNotaExcel();
						else
						*/
						
						mStatus = p_CreateNotaWord();
					}
					if(nota=="SYARAT2") mStatus = p_CreateSyarat2();
					if(nota=="BANK") mStatus = p_CreateBank();
					if(nota=="RATA") mStatus = p_CreateRata();
					if(nota=="URUS") mStatus = p_CreateUrus();
					
					ViewFileExport();

				}
			}
			catch (Exception ex)
			{
				LBL_STATUS_EXPORT.ForeColor = Color.Red;
				LBL_STATUSEXPORT.ForeColor = Color.Red;
				mStatus		  = "Error Exporting File";
				mStatusReport = ex.ToString();
			}
			finally
			{
				LBL_STATUS_EXPORT.Text = mStatus.Trim();
				LBL_STATUSEXPORT.Text = mStatusReport.Trim();
			}
		}

		private void DATA_EXPORT_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			switch (((LinkButton)e.CommandSource).CommandName)
			{
				case "delete":
					/// Function delete file fisik
					/// 
					try 
					{					
						string directory = @"C:\";
						conn.QueryString = "select NOTA_PATH from NOTA_ANALISA where NOTA_ID = '" + e.Item.Cells[0].Text + "'";
						conn.ExecuteQuery();
						directory = conn.GetFieldValue("NOTA_PATH");						

						deleteFile(directory, e.Item.Cells[2].Text);
						Response.Write("<!-- file : " + directory + e.Item.Cells[2].Text + " -->");
						Response.Write("<!-- file is deleted. -->");
					} 
					catch (Exception ex) 
					{
						Response.Write("<!-- Delete File Error: " + ex.Message.ToString() + " -->");
					}

					conn.QueryString = "exec CP_NOTA_EXPORT '" + e.Item.Cells[0].Text +"','" + Request.QueryString["regno"] + "', '" + e.Item.Cells[5].Text + "','','" + Session["UserID"] + "', '2'";
					conn.ExecuteQuery();
					ViewFileExport();					
					break;
			}
		}

		private void ViewFileExport()
		{
			conn.QueryString = "Select * from NOTA_ANALISA ";
			conn.ExecuteQuery();
			
			if (conn.GetRowCount() > 0) 
			{
				string url = conn.GetFieldValue("NOTA_URL");
			
				System.Data.DataTable dt = new System.Data.DataTable();
				conn.QueryString = "select * from NOTA_EXPORT where AP_REGNO ='"+ Request.QueryString["regno"] + "'";
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
					HyperLink HpDownload = (HyperLink) DATA_EXPORT.Items[i-1].Cells[2].FindControl("HL_DOWNLOAD");
					LinkButton HpDelete = (LinkButton) DATA_EXPORT.Items[i-1].Cells[3].FindControl("LinkButton1");
					HpDownload.NavigateUrl = url + DATA_EXPORT.Items[i-1].Cells[1].Text.Trim();
					if (var_user.ToString().Trim() != DATA_EXPORT.Items[i-1].Cells[4].Text)
						HpDelete.Visible	= false;

					if (Request.QueryString["cp"] == "0" || Request.QueryString["prrk"] == "0") 
					{
						//HpDownload.Enabled = false;
						HpDelete.Enabled = false;
					}
				}
			}
		}

		#region p_CreateNotaWord return string
		private string p_CreateNotaWord()
		{
			string szUser = DDL_USERID.SelectedValue;
			string fileNm = string.Empty;
			string fileIn = string.Empty;
			string fileOut = string.Empty;
			string mStatus = string.Empty;
			string mNotaNumber = string.Empty;
			short Step = 0;
			object objType = Type.Missing;
			bool bSukses = true;
			object objValue = null;					

			System.Data.DataTable dt_field = null;

			conn.QueryString = "Select * from NOTA_ANALISA where NOTA_ID = '" + var_idExport + "'";
			conn.ExecuteQuery();
				
			if (conn.GetRowCount() > 0) 
			{
				string nota = conn.GetFieldValue("NOTA_ID");
				string sheet = conn.GetFieldValue("NOTA_SHEET");
				string path = conn.GetFieldValue("NOTA_PATH");
				string file_doc = nota + ".DOT";
				string url = conn.GetFieldValue("NOTA_URL");
				string b_unit = conn.GetFieldValue("B_UNIT");

				int iItem = 0;

				object oMissingObject = System.Reflection.Missing.Value;
		
				Word.Application wordApp = null;
				Word.Document wordDoc = null;

				ArrayList orgId = new ArrayList();
				ArrayList newId = new ArrayList();
		
				//Collecting Existing Winword in Taskbar

				Process[] oldProcess = Process.GetProcessesByName("WINWORD");
				foreach(Process thisProcess in oldProcess)
					orgId.Add(thisProcess);
		
				try
				{

					wordApp = new Word.ApplicationClass();
					wordApp.Visible = false;

					//Collecting Existing Winword in Taskbar 

					Process[] newProcess = Process.GetProcessesByName("WINWORD");
					foreach(Process thisProcess in newProcess)
						newId.Add(thisProcess);

					iItem = 0;
		
					fileNm = Request.QueryString["regno"] + "-" + nota + "-" + var_user + ".DOC";

					object objFileIn = path + file_doc;
					object objFileOut = path + fileNm;
		
					//fileResult = url + fileNm;

					wordDoc = wordApp.Documents.Open(ref objFileIn, ref oMissingObject, ref oMissingObject, ref oMissingObject, ref oMissingObject, ref oMissingObject, 
						ref oMissingObject, ref oMissingObject, ref oMissingObject, ref oMissingObject, ref oMissingObject, ref oMissingObject);

					wordDoc.Activate();
					Word.Bookmarks wordBookMark = (Word.Bookmarks)wordDoc.Bookmarks;

					#region Step Fill General Info
					// Step 1
					conn.QueryString = "Select * from NOTA_ANALISA_DETAIL where NOTA_ID = '" + nota + "' order by NOTA_ID, SEQ";
					conn.ExecuteQuery();

					dt_field = conn.GetDataTable().Copy();

					conn.QueryString = "exec CP_EXPORT_NOTA_ANALISA_WORD '" + Session["BranchName"] + "', '" + Session["FullName"] + "', '" + Request.QueryString["regno"] + "'";
					conn.ExecuteQuery();

					for(int j = 0; j < conn.GetRowCount(); j++)
					{
						for(int i = 0; i < dt_field.Rows.Count; i++)
						{
							object Cell = dt_field.Rows[i][2];
							string Field = dt_field.Rows[i][4].ToString();

							objValue = conn.GetFieldValue(Field);
				
							string strObject = objValue.ToString();

							if(wordBookMark.Exists(Cell.ToString())) 
							{
								try
								{
									strObject = Convert.ToDateTime(objValue).ToShortDateString();
								}
								catch
								{}
								Word.Bookmark oBook = wordBookMark.Item(ref Cell);
								oBook.Select();
								oBook.Range.Text = strObject;
							}
							iItem++;
						}
					}
					#endregion
					#region Step Fill Credit Rating Summary

					conn.QueryString = "Select * from NOTA_ANALISA_DETAIL2 where NOTA_ROW = 1 and NOTA_ID = '" + nota + "' order by NOTA_ID, SEQ";
					conn.ExecuteQuery();

					dt_field = conn.GetDataTable().Copy();

					conn.QueryString = "exec CP_EXPORT_NOTA_ANALISA_WORD1_2A '" + Request.QueryString["regno"] + "'";
					conn.ExecuteQuery();

					for(int j = 0; j < conn.GetRowCount(); j++)
					{
						for(int i = 0; i < dt_field.Rows.Count; i++)
						{
							object Cell = dt_field.Rows[i][2];
							string Field = dt_field.Rows[i][4].ToString();

							objValue = conn.GetFieldValue(j, Field);

							string strObject = objValue.ToString();

							if(wordBookMark.Exists(Cell.ToString())) 
							{
								Word.Bookmark oBook = wordBookMark.Item(ref Cell);
								oBook.Select();
								oBook.Range.Text = strObject;
							}
							iItem++;
						}
					}

					conn.QueryString = "Select * from NOTA_ANALISA_DETAIL2 where NOTA_ROW = 0 and NOTA_ID = '" + nota + "' order by NOTA_ID, SEQ";
					conn.ExecuteQuery();

					dt_field = conn.GetDataTable().Copy();

					conn.QueryString = "exec CP_EXPORT_NOTA_ANALISA_WORD1_2B '" + Request.QueryString["regno"] + "'";
					conn.ExecuteQuery();

					for(int j = 0; j < conn.GetRowCount(); j++)
					{
						for(int i = 0; i < dt_field.Rows.Count; i++)
						{
							object Cell = dt_field.Rows[i][2];
							string Field = dt_field.Rows[i][4].ToString();

							objValue = conn.GetFieldValue(j, Field);

							string strObject = objValue.ToString();

							if(wordBookMark.Exists(Cell.ToString())) 
							{
								Word.Bookmark oBook = wordBookMark.Item(ref Cell);
								oBook.Select();
								oBook.Range.Text = strObject;
							}
							iItem++;
						}
					}
					#endregion
					#region Step Fill Yang Memutuskan
					conn.QueryString = "Select * from NOTA_ANALISA_DETAIL9 where NOTA_ID = '" + nota + "' order by NOTA_ID, NOTA_ROW, SEQ";
					conn.ExecuteQuery();

					dt_field = conn.GetDataTable().Copy();

					conn.QueryString = "exec CP_EXPORT_NOTA_ANALISA_WORD9 '" + Request.QueryString["regno"] + "', '" + var_user + "'";
					conn.ExecuteQuery();

					for(int j = 0; j < conn.GetRowCount(); j++)
					{
						for(int i = 0; i < dt_field.Rows.Count; i++)
						{
							object Cell = dt_field.Rows[i][2];
							string Field = dt_field.Rows[i][4].ToString();

							objValue = conn.GetFieldValue(j, Field);

							string strObject = objValue.ToString();

							if(wordBookMark.Exists(Cell.ToString())) 
							{
								Word.Bookmark oBook = wordBookMark.Item(ref Cell);
								oBook.Select();
								oBook.Range.Text = strObject;
							}
							iItem++;
						}
					}
					#endregion
					#region Step Fill Ratio
					conn.QueryString = "Select * from NOTA_ANALISA_DETAIL3 where NOTA_ID = '" + nota + "' order by NOTA_ID, SEQ";
					conn.ExecuteQuery();

					dt_field = conn.GetDataTable().Copy();
					
					if (b_unit.ToUpper() == m_in_small.ToUpper()) 
						conn.QueryString = "exec CP_EXPORT_NOTA_ANALISA_WORD3_1 '" + Request.QueryString["regno"] + "'";
					else				
						conn.QueryString = "exec CP_EXPORT_NOTA_ANALISA_WORD3_2 '" + Request.QueryString["regno"] + "'";

					conn.ExecuteQuery();

					Step = 0;
					for(int j = 0; j < conn.GetRowCount(); j++)
					{
						for(int i = 0; i < dt_field.Rows.Count; i++)
						{
							Step = (short)dt_field.Rows[i][2];
			
							if(Step==j+1)
							{
								object Cell = dt_field.Rows[i][3];
								string Field = dt_field.Rows[i][5].ToString();

								objValue = conn.GetFieldValue(j, Field);

								string strObject = objValue.ToString();

								if(wordBookMark.Exists(Cell.ToString())) 
								{
									Word.Bookmark oBook = wordBookMark.Item(ref Cell);
									oBook.Select();
									oBook.Range.Text = strObject;
								}
								iItem++;
							}
						}
					}
					#endregion
					#region Step Fill Aspek
					conn.QueryString = "Select * from NOTA_ANALISA_DETAIL2 where NOTA_ID = '" + nota + "' order by NOTA_ID, SEQ";
					conn.ExecuteQuery();

					dt_field = conn.GetDataTable().Copy();

					conn.QueryString = "exec CP_EXPORT_NOTA_ANALISA2 '" + Request.QueryString["regno"] + "'";
					conn.ExecuteQuery();
			
					string szField = string.Empty;
					for(int j = 0; j < conn.GetRowCount(); j++)
					{
						szField = conn.GetFieldValue(j ,"Control");

						for(int i = 0; i < dt_field.Rows.Count; i++)
						{
							object Cell = dt_field.Rows[i][2];
							string Field = dt_field.Rows[i][4].ToString();

							//objValue = conn.GetFieldValue(Field);
				
							if (Field==szField)
							{
								objValue = conn.GetFieldValue(j, "Nilai");
				
								if(objValue.ToString() == "1") 
									objValue = "X";
								else if(objValue.ToString() == "0")
									objValue = string.Empty;

								string strObject = objValue.ToString();

								if(wordBookMark.Exists(Cell.ToString())) 
								{
									Word.Bookmark oBook = wordBookMark.Item(ref Cell);
									oBook.Select();
									oBook.Range.Text = strObject;
								}

								iItem++;

								break;
							}
						}
					}
					#endregion
					#region Step Fill BU Signature
					// Step 1
					conn.QueryString = "Select * from NOTA_ANALISA_DETAIL10 where Step = 1 and NOTA_ID = '" + nota + "'";
					conn.ExecuteQuery();

					dt_field = conn.GetDataTable().Copy();

					conn.QueryString = "exec CP_EXPORT_NOTA_ANALISA_BU '" + szUser + "'";
					conn.ExecuteQuery();

					for(int j = 0; j < conn.GetRowCount(); j++)
					{
						for(int i = 0; i < dt_field.Rows.Count; i++)
						{
							object Cell = dt_field.Rows[i][3];
							string Field = dt_field.Rows[i][5].ToString();

							objValue = conn.GetFieldValue(j, Field);

							string strObject = objValue.ToString();

							if(wordBookMark.Exists(Cell.ToString())) 
							{
								Word.Bookmark oBook = wordBookMark.Item(ref Cell);
								oBook.Select();
								oBook.Range.Text = strObject;
							}

							iItem++;
						}
					}
					#endregion 
					#region Step Fill RM Signature
					// Step 1
					conn.QueryString = "Select * from NOTA_ANALISA_DETAIL10 where Step = 2 and NOTA_ID = '" + nota + "'";
					conn.ExecuteQuery();

					dt_field = conn.GetDataTable().Copy();

					conn.QueryString = "exec CP_EXPORT_NOTA_ANALISA_RM '" + szUser + "'";
					conn.ExecuteQuery();

					for(int j = 0; j < conn.GetRowCount(); j++)
					{
						for(int i = 0; i < dt_field.Rows.Count; i++)
						{
							object Cell = dt_field.Rows[i][3];
							string Field = dt_field.Rows[i][5].ToString();

							objValue = conn.GetFieldValue(j, Field);

							string strObject = objValue.ToString();

							if(wordBookMark.Exists(Cell.ToString())) 
							{
								Word.Bookmark oBook = wordBookMark.Item(ref Cell);
								oBook.Select();
								oBook.Range.Text = strObject;
							}

							iItem++;
						}
					}
					#endregion 
					#region Step Fill BU FRONT Signature
					// Step 1
					conn.QueryString = "Select * from NOTA_ANALISA_DETAIL10 where Step = 3 and NOTA_ID = '" + nota + "'";
					conn.ExecuteQuery();

					dt_field = conn.GetDataTable().Copy();

					conn.QueryString = "exec CP_EXPORT_NOTA_ANALISA_BUFRONT '" + szUser + "'";
					conn.ExecuteQuery();

					for(int j = 0; j < conn.GetRowCount(); j++)
					{
						for(int i = 0; i < dt_field.Rows.Count; i++)
						{
							object Cell = dt_field.Rows[i][3];
							string Field = dt_field.Rows[i][5].ToString();

							objValue = conn.GetFieldValue(j, Field);

							string strObject = objValue.ToString();

							if(wordBookMark.Exists(Cell.ToString())) 
							{
								Word.Bookmark oBook = wordBookMark.Item(ref Cell);
								oBook.Select();
								oBook.Range.Text = strObject;
							}

							iItem++;
						}
					}
					#endregion 
					#region Step Fill RM FRONT Signature
					// Step 1
					conn.QueryString = "Select * from NOTA_ANALISA_DETAIL10 where Step = 4 and NOTA_ID = '" + nota + "'";
					conn.ExecuteQuery();

					dt_field = conn.GetDataTable().Copy();

					conn.QueryString = "exec CP_EXPORT_NOTA_ANALISA_RMFRONT '" + szUser + "'";
					conn.ExecuteQuery();

					for(int j = 0; j < conn.GetRowCount(); j++)
					{
						for(int i = 0; i < dt_field.Rows.Count; i++)
						{
							object Cell = dt_field.Rows[i][3];
							string Field = dt_field.Rows[i][5].ToString();

							objValue = conn.GetFieldValue(j, Field);

							string strObject = objValue.ToString();

							if(wordBookMark.Exists(Cell.ToString())) 
							{
								Word.Bookmark oBook = wordBookMark.Item(ref Cell);
								oBook.Select();
								oBook.Range.Text = strObject;
							}

							iItem++;
						}
					}
					#endregion 

					if(iItem > 0) 
					{
						wordDoc.SaveAs(ref objFileOut, ref oMissingObject, ref oMissingObject, ref oMissingObject, ref oMissingObject, ref oMissingObject, 
							ref oMissingObject, ref oMissingObject, ref oMissingObject, ref oMissingObject, ref oMissingObject);

						System.Threading.Thread.Sleep(TimeSpan.FromSeconds(3));  																					 
						bSukses = true;
					}
					else
						bSukses = false;

					if(bSukses)	
					{
						// Maintenance Table Nota_Export

						conn.QueryString = "exec CP_NOTA_EXPORT '" + nota +"','" + Request.QueryString["regno"] + "','NOTA','" + fileNm + "','" + Session["UserID"] + "', '1'";

						conn.ExecuteQuery();
						mStatus = "Export Succesfully";

					}
					else
					{
						mStatus = "No Data to Export";
					}
				}
				catch{}
				finally
				{

					if(wordDoc!=null)
					{
						wordDoc.Close(ref oMissingObject, ref oMissingObject, ref oMissingObject);
						wordDoc=null;
					}
					if(wordApp!=null)
					{
						wordApp.Application.Quit(ref oMissingObject, ref oMissingObject, ref oMissingObject);
						wordApp=null;

						// Killing Proses after Export
						for(int x = 0; x < newId.Count; x++)
						{
							Process xnewId = (Process)newId[x];
				
							bool bSameId = false;
							for(int z = 0; z < orgId.Count; z++)
							{
								Process xoldId = (Process)orgId[z];
		
								if(xnewId.Id == xoldId.Id) 
								{
									bSameId = true;
									break;
								}
							}
                            if (!bSameId)
                            {
                                try
                                {
                                    xnewId.Kill();
                                }
                                catch (Exception e)
                                {
                                    continue;
                                }
                            }
						}

					}
				}
			}
			return mStatus;
		}
		#endregion
		#region p_CreateSyarat2 return string
		private string p_CreateSyarat2()
		{
			string szUser = DDL_USERID.SelectedValue;

			string fileNm = string.Empty;
			string fileIn = string.Empty;
			string fileOut = string.Empty;
			object objPaste = null;
			object objCopy = null;
			bool bSukses = true;
			object objValue = null;
			object objType = Type.Missing;		
			string mStatus = string.Empty;
			int iItem = 0;
			int iItemOther = 0;
			int iItemPosition = 0;
			int m_Row = 0;

			System.Data.DataTable dt_field = null;
			
			conn.QueryString = "Select * from NOTA_ANALISA where NOTA_ID = '" + var_idExport + "'";
			conn.ExecuteQuery();
				
			if (conn.GetRowCount() > 0) 
			{
				string nota = conn.GetFieldValue("NOTA_ID");
				string sheet = conn.GetFieldValue("NOTA_SHEET");
				string path = conn.GetFieldValue("NOTA_PATH");
				string file_xls = nota + ".XLT";
				string url = conn.GetFieldValue("NOTA_URL");

				Excel.Application excelApp = null;
				Excel.Workbook excelWorkBook = null;
				Excel.Sheets excelSheet = null;

				ArrayList orgId = new ArrayList();
				ArrayList newId = new ArrayList();
						
				Process[] oldProcess = Process.GetProcessesByName("EXCEL");
				foreach(Process thisProcess in oldProcess)
					orgId.Add(thisProcess);

				try
				{
					excelApp = new Excel.ApplicationClass();
					excelApp.Visible = false;
					excelApp.DisplayAlerts = false;
						
					Process[] newProcess = Process.GetProcessesByName("EXCEL");
					foreach(Process thisProcess in newProcess)
						newId.Add(thisProcess);
					
					/// Save process into database
					/// 
					//SupportTools.saveProcessExcel(excelApp, newId, orgId, conn);


					fileIn = path + file_xls;

					excelWorkBook = excelApp.Workbooks.Open(fileIn, 0, false, 5, string.Empty, string.Empty, true, Excel.XlPlatform.xlWindows, "\t|",
						false, false, 0, true);

					excelSheet = excelWorkBook.Worksheets;

					Excel.Worksheet excelWorkSheet = (Excel.Worksheet)excelSheet.get_Item(sheet);
					
					fileNm = Request.QueryString["regno"] + "-" + nota + "-" +  var_user + ".XLS";
					fileOut = path + fileNm;
					//fileResult = url + fileNm;

					m_Row = 0;

					// Sheet SYARAT
					#region Step Fill Syarat Perjanjian Kredit

					// Step 2.1
					conn.QueryString = "Select * from NOTA_ANALISA_DETAIL8 where SEQ = 1 and NOTA_ID = '" + nota + "' order by NOTA_ID, NOTA_ROW, SEQ";
					conn.ExecuteQuery();
		
					dt_field = conn.GetDataTable().Copy();

					conn.QueryString = "exec CP_EXPORT_NOTA_ANALISA8_1 '" + Request.QueryString["regno"] + "'";
					conn.ExecuteQuery();
					

					if(conn.GetRowCount()>1)
					{
						iItemPosition = Convert.ToInt32(dt_field.Rows[0][3]) +  m_Row;

						//Prepare Empty Row with all Formats
						for(int j = 0; j < conn.GetRowCount()-1; j++)
						{
							Excel.Range excelRange = excelWorkSheet.get_Range("A" + iItemPosition.ToString().Trim(), "IV" + (iItemPosition + 1).ToString().Trim()).EntireRow;
							excelRange.Insert(Excel.XlInsertShiftDirection.xlShiftDown);

							Excel.Range exlCopy = excelWorkSheet.get_Range("A" + (iItemPosition + 2).ToString().Trim(), "IV" + (iItemPosition + 3).ToString().Trim());
							objCopy = exlCopy.Copy(objType);

							Excel.Range exlPaste = excelWorkSheet.get_Range("A"+ iItemPosition.ToString().Trim(), "A" + iItemPosition.ToString().Trim());
							objPaste = exlPaste.PasteSpecial(Excel.XlPasteType.xlPasteAll, Excel.XlPasteSpecialOperation.xlPasteSpecialOperationNone, false, false);
						}
					}		
					for(int j = 0; j < conn.GetRowCount(); j++)
					{
						if(j > 0) m_Row = m_Row + 2;

						for(int i = 0; i < dt_field.Rows.Count; i++)
						{
							string Col = dt_field.Rows[i][2].ToString().Trim();
							int Row = Convert.ToInt32(dt_field.Rows[i][3])+ m_Row;
							string Cell = Col + Row.ToString().Trim();
							string Field = dt_field.Rows[i][4].ToString();

							objValue = conn.GetFieldValue(j, Field);

							Excel.Range excelCell = (Excel.Range)excelWorkSheet.get_Range(Cell, Cell);
							excelCell.Value2 = objValue;

							iItem++;
						}
					}

					#endregion
					#region Step Fill Syarat Penarikan Kredit
					#region Step Fill Syarat CL

					// Step 2.1
					conn.QueryString = "Select * from NOTA_ANALISA_DETAIL8 where SEQ = 2 and NOTA_ID = '" + nota + "' order by NOTA_ID, NOTA_ROW, SEQ";
					conn.ExecuteQuery();
		
					dt_field = conn.GetDataTable().Copy();

					conn.QueryString = "exec CP_EXPORT_NOTA_ANALISA8_2A '" + Request.QueryString["regno"] + "'";
					conn.ExecuteQuery();
					

					if(conn.GetRowCount()>1)
					{
						iItemPosition = Convert.ToInt32(dt_field.Rows[0][3]) +  m_Row;

						//Prepare Empty Row with all Formats
						for(int j = 0; j < conn.GetRowCount()-1; j++)
						{
							iItemOther = iItemPosition + j;

							Excel.Range excelRange = excelWorkSheet.get_Range("A" + iItemPosition.ToString().Trim(), "IV" + (iItemPosition + 1).ToString().Trim()).EntireRow;
							excelRange.Insert(Excel.XlInsertShiftDirection.xlShiftDown);

							Excel.Range exlCopy = excelWorkSheet.get_Range("A" + (iItemPosition + 2).ToString().Trim(), "IV" + (iItemPosition + 3).ToString().Trim());
							objCopy = exlCopy.Copy(objType);

							Excel.Range exlPaste = excelWorkSheet.get_Range("A"+ iItemPosition.ToString().Trim(), "A" + iItemPosition.ToString().Trim());
							objPaste = exlPaste.PasteSpecial(Excel.XlPasteType.xlPasteAll, Excel.XlPasteSpecialOperation.xlPasteSpecialOperationNone, false, false);
						}
					}		
					for(int j = 0; j < conn.GetRowCount(); j++)
					{
						if(j > 0) m_Row = m_Row + 2;

						for(int i = 0; i < dt_field.Rows.Count; i++)
						{
							string Col = dt_field.Rows[i][2].ToString().Trim();
							int Row = Convert.ToInt32(dt_field.Rows[i][3])+ m_Row;
							string Cell = Col + Row.ToString().Trim();
							string Field = dt_field.Rows[i][4].ToString();

							objValue = conn.GetFieldValue(j, Field);

							Excel.Range excelCell = (Excel.Range)excelWorkSheet.get_Range(Cell, Cell);
							excelCell.Value2 = objValue;

							iItem++;
						}
					}

					#endregion
					#region Step Fill Syarat NCL

					// Step 2.1
					conn.QueryString = "Select * from NOTA_ANALISA_DETAIL8 where SEQ = 3 and NOTA_ID = '" + nota + "' order by NOTA_ID, NOTA_ROW, SEQ";
					conn.ExecuteQuery();
		
					dt_field = conn.GetDataTable().Copy();

					conn.QueryString = "exec CP_EXPORT_NOTA_ANALISA8_2B '" + Request.QueryString["regno"] + "'";
					conn.ExecuteQuery();
					

					if(conn.GetRowCount()>1)
					{
						iItemPosition = Convert.ToInt32(dt_field.Rows[0][3]) +  m_Row;

						//Prepare Empty Row with all Formats
						for(int j = 0; j < conn.GetRowCount()-1; j++)
						{
							iItemOther = iItemPosition + j;

							Excel.Range excelRange = excelWorkSheet.get_Range("A" + iItemPosition.ToString().Trim(), "IV" + (iItemPosition + 1).ToString().Trim()).EntireRow;
							excelRange.Insert(Excel.XlInsertShiftDirection.xlShiftDown);

							Excel.Range exlCopy = excelWorkSheet.get_Range("A" + (iItemPosition + 2).ToString().Trim(), "IV" + (iItemPosition + 3).ToString().Trim());
							objCopy = exlCopy.Copy(objType);

							Excel.Range exlPaste = excelWorkSheet.get_Range("A"+ iItemPosition.ToString().Trim(), "A" + iItemPosition.ToString().Trim());
							objPaste = exlPaste.PasteSpecial(Excel.XlPasteType.xlPasteAll, Excel.XlPasteSpecialOperation.xlPasteSpecialOperationNone, false, false);
						}
					}		
					for(int j = 0; j < conn.GetRowCount(); j++)
					{
						if(j > 0) m_Row = m_Row + 2;

						for(int i = 0; i < dt_field.Rows.Count; i++)
						{
							string Col = dt_field.Rows[i][2].ToString().Trim();
							int Row = Convert.ToInt32(dt_field.Rows[i][3])+ m_Row;
							string Cell = Col + Row.ToString().Trim();
							string Field = dt_field.Rows[i][4].ToString();

							objValue = conn.GetFieldValue(j, Field);

							Excel.Range excelCell = (Excel.Range)excelWorkSheet.get_Range(Cell, Cell);
							excelCell.Value2 = objValue;

							iItem++;
						}
					}

					#endregion

					#endregion
					#region Step Fill Syarat Lain

					// Step 2.1
					conn.QueryString = "Select * from NOTA_ANALISA_DETAIL8 where SEQ = 4 and NOTA_ID = '" + nota + "' order by NOTA_ID, NOTA_ROW, SEQ";
					conn.ExecuteQuery();
		
					dt_field = conn.GetDataTable().Copy();

					conn.QueryString = "exec CP_EXPORT_NOTA_ANALISA8_3 '" + Request.QueryString["regno"] + "'";
					conn.ExecuteQuery();
					

					if(conn.GetRowCount()>1)
					{
						iItemPosition = Convert.ToInt32(dt_field.Rows[0][3]) +  m_Row;

						//Prepare Empty Row with all Formats
						for(int j = 0; j < conn.GetRowCount()-1; j++)
						{
							iItemOther = iItemPosition + j;

							Excel.Range excelRange = excelWorkSheet.get_Range("A" + iItemPosition.ToString().Trim(), "IV" + (iItemPosition + 1).ToString().Trim()).EntireRow;
							excelRange.Insert(Excel.XlInsertShiftDirection.xlShiftDown);

							Excel.Range exlCopy = excelWorkSheet.get_Range("A" + (iItemPosition + 2).ToString().Trim(), "IV" + (iItemPosition + 3).ToString().Trim());
							objCopy = exlCopy.Copy(objType);

							Excel.Range exlPaste = excelWorkSheet.get_Range("A"+ iItemPosition.ToString().Trim(), "A" + iItemPosition.ToString().Trim());
							objPaste = exlPaste.PasteSpecial(Excel.XlPasteType.xlPasteAll, Excel.XlPasteSpecialOperation.xlPasteSpecialOperationNone, false, false);
						}
					}		
					for(int j = 0; j < conn.GetRowCount(); j++)
					{
						if(j > 0) m_Row = m_Row + 2;

						for(int i = 0; i < dt_field.Rows.Count; i++)
						{
							string Col = dt_field.Rows[i][2].ToString().Trim();
							int Row = Convert.ToInt32(dt_field.Rows[i][3])+ m_Row;
							string Cell = Col + Row.ToString().Trim();
							string Field = dt_field.Rows[i][4].ToString();

							objValue = conn.GetFieldValue(j, Field);

							Excel.Range excelCell = (Excel.Range)excelWorkSheet.get_Range(Cell, Cell);
							excelCell.Value2 = objValue;

							iItem++;
						}
					}

					#endregion

					if(iItem > 0) 
					{
						excelWorkBook.SaveAs(fileOut, Excel.XlFileFormat.xlWorkbookNormal, null, null, null, null,
							Excel.XlSaveAsAccessMode.xlNoChange, null, null, null, true);
					
						System.Threading.Thread.Sleep(TimeSpan.FromSeconds(3));  																					 
						bSukses = true;
					}
					else
						bSukses = false;

					if(bSukses)	
					{
						// Maintenance Table Nota_Export
						
						conn.QueryString = "exec CP_NOTA_EXPORT '" + nota +"','" + Request.QueryString["regno"] + "','NOTA','" + fileNm + "','" + Session["UserID"] + "', '1'";
						
						conn.ExecuteQuery();
						mStatus = "Export Succesfully";

					}
					else
					{
						mStatus = "No Data to Export";
					}
				}
				catch{}
				finally
				{
					if(excelWorkBook!=null)
					{
						excelWorkBook.Close(true , fileOut, null);
						excelWorkBook=null;
					}
					if(excelApp!=null)
					{
						excelApp.Workbooks.Close();
						excelApp.Application.Quit();
						excelApp=null;

						for(int x = 0; x < newId.Count; x++)
						{
							Process xnewId = (Process)newId[x];
							
							bool bSameId = false;
							for(int z = 0; z < orgId.Count; z++)
							{
								Process xoldId = (Process)orgId[z];
					
								if(xnewId.Id == xoldId.Id) 
								{
									bSameId = true;
									break;
								}
							}
                            if (!bSameId)
                            {
                                try
                                {
                                    xnewId.Kill();
                                }
                                catch (Exception e)
                                {
                                    continue;
                                }
                            }
						}
					}
				}
			}
			return mStatus;
		}
		#endregion
		#region p_CreateRata return string
		private string p_CreateRata()
		{
			string szUser = DDL_USERID.SelectedValue;

			string fileNm = string.Empty;
			string fileIn = string.Empty;
			string fileOut = string.Empty;
			bool bSukses = true;
			object objValue = null;					
			string mStatus = string.Empty;

			conn.QueryString = "Select * from NOTA_ANALISA where NOTA_ID = '" + var_idExport + "'";
			conn.ExecuteQuery();
				
			if (conn.GetRowCount() > 0) 
			{
				string nota = conn.GetFieldValue("NOTA_ID");
				string sheet = conn.GetFieldValue("NOTA_SHEET");
				string path = conn.GetFieldValue("NOTA_PATH");
				string file_xls = nota + ".XLT";
				string url = conn.GetFieldValue("NOTA_URL");
			
				fileNm = Request.QueryString["regno"] + "-" + nota + "-" +  var_user + ".XLS";
				fileOut = path + fileNm;

				System.Data.DataTable dt_field = null;

				Excel.Application excelApp = null;
				Excel.Workbook excelWorkBook = null;
				Excel.Sheets excelSheet = null;

				ArrayList orgId = new ArrayList();
				ArrayList newId = new ArrayList();
						
				Process[] oldProcess = Process.GetProcessesByName("EXCEL");
				foreach(Process thisProcess in oldProcess)
					orgId.Add(thisProcess);

				try
				{
					excelApp = new Excel.ApplicationClass();
					excelApp.Visible = false;
					excelApp.DisplayAlerts = false;
						
					Process[] newProcess = Process.GetProcessesByName("EXCEL");
					foreach(Process thisProcess in newProcess)
						newId.Add(thisProcess);

					/// Save process into database
					/// 
					//SupportTools.saveProcessExcel(excelApp, newId, orgId, conn);

			
					fileIn = path + file_xls;

					excelWorkBook = excelApp.Workbooks.Open(fileIn, 0, false, 5, string.Empty, string.Empty, true, Excel.XlPlatform.xlWindows, "\t|",
						false, false, 0, true);

					excelSheet = excelWorkBook.Worksheets;
					Excel.Worksheet excelWorkSheet = (Excel.Worksheet)excelSheet.get_Item(sheet);
							
					#region Step Fill Rata-Rata 

					int iItem = 0;
					// Step 1
					conn.QueryString = "Select * from NOTA_ANALISA_DETAIL9 where NOTA_ID = '" + nota + "' order by NOTA_ID, SEQ";
					conn.ExecuteQuery();
		
					dt_field = conn.GetDataTable().Copy();

					conn.QueryString = "exec CP_EXPORT_NOTA_ANALISA_BANK '" + Request.QueryString["regno"] + "'";
					conn.ExecuteQuery();

					for(int j = 0; j < conn.GetRowCount(); j++)
					{
						for(int i = 0; i < dt_field.Rows.Count; i++)
						{
							string Col = dt_field.Rows[i][2].ToString().Trim();
							int Row = Convert.ToInt32(dt_field.Rows[i][3]);
							string Cell = Col + Row.ToString().Trim();
							string Field = dt_field.Rows[i][4].ToString();

							objValue = conn.GetFieldValue(Field);

							Excel.Range excelCell = (Excel.Range)excelWorkSheet.get_Range(Cell, Cell);
							excelCell.Value2 = objValue;
			
							iItem++;
						}
					}

					#endregion 
					if(iItem > 0)
					{
						excelWorkBook.SaveAs(fileOut, Excel.XlFileFormat.xlWorkbookNormal, null, null, null, null,
							Excel.XlSaveAsAccessMode.xlNoChange, null, null, null, true);
					
						System.Threading.Thread.Sleep(TimeSpan.FromSeconds(3));  																					 
						bSukses = true;
					}
					else
						bSukses = false;

					if(bSukses)	
					{
		
						// Maintenance Table Nota_Export

						conn.QueryString = "exec CP_NOTA_EXPORT '" + nota +"','" + Request.QueryString["regno"] + "','NOTA','" + fileNm + "','" + Session["UserID"] + "', '1'";

						conn.ExecuteQuery();
						mStatus = "Export Succesfully";

					}
					else
					{
						mStatus = "No Data to Export";
					}

				}
				catch{}
				finally
				{
					if(excelWorkBook!=null)
					{
						excelWorkBook.Close(true , fileOut, null);
						excelWorkBook=null;
					}
					if(excelApp!=null)
					{
						excelApp.Workbooks.Close();
						excelApp.Application.Quit();
						excelApp=null;

						for(int x = 0; x < newId.Count; x++)
						{
							Process xnewId = (Process)newId[x];
							
							bool bSameId = false;
							for(int z = 0; z < orgId.Count; z++)
							{
								Process xoldId = (Process)orgId[z];
					
								if(xnewId.Id == xoldId.Id) 
								{
									bSameId = true;
									break;
								}
							}
                            if (!bSameId)
                            {
                                try
                                {
                                    xnewId.Kill();
                                }
                                catch (Exception e)
                                {
                                    continue;
                                }
                            }
						}
			
					}
				}
			}
			return mStatus;
		}
		#endregion
		#region p_CreateBank return string 
		private string p_CreateBank()
		{
			string szUser = DDL_USERID.SelectedValue;

			string fileNm = string.Empty;
			string fileIn = string.Empty;
			string fileOut = string.Empty;
			int m_Row = 0;
			object objPaste = null;
			object objCopy = null;
			object objType = Type.Missing;		
			bool bSukses = true;
			object objValue = null;					
			string mStatus = string.Empty;

			conn.QueryString = "Select * from NOTA_ANALISA where NOTA_ID = '" + var_idExport + "'";
			conn.ExecuteQuery();
				
			if (conn.GetRowCount() > 0) 
			{
				string nota = conn.GetFieldValue("NOTA_ID");
				string sheet = conn.GetFieldValue("NOTA_SHEET");
				string path = conn.GetFieldValue("NOTA_PATH");
				string file_xls = nota + ".XLT";
				string url = conn.GetFieldValue("NOTA_URL");
			
				fileNm = Request.QueryString["regno"] + "-" + nota + "-" + var_user + ".XLS";
				fileOut = path + fileNm;

				System.Data.DataTable dt_field = null;

				int iItem = 0;
				int iItemOther = 0;
				int iItemPosition = 0;

				Excel.Application excelApp = null;
				Excel.Workbook excelWorkBook = null;
				Excel.Sheets excelSheet = null;

				ArrayList orgId = new ArrayList();
				ArrayList newId = new ArrayList();
						
				Process[] oldProcess = Process.GetProcessesByName("EXCEL");
				foreach(Process thisProcess in oldProcess)
					orgId.Add(thisProcess);

				try
				{
					excelApp = new Excel.ApplicationClass();
					excelApp.Visible = false;
					excelApp.DisplayAlerts = false;
						
					Process[] newProcess = Process.GetProcessesByName("EXCEL");
					foreach(Process thisProcess in newProcess)
						newId.Add(thisProcess);
					
					/// Save process into database
					/// 
					//SupportTools.saveProcessExcel(excelApp, newId, orgId, conn);

					fileIn = path + file_xls;

					excelWorkBook = excelApp.Workbooks.Open(fileIn, 0, false, 5, string.Empty, string.Empty, true, Excel.XlPlatform.xlWindows, "\t|",
						false, false, 0, true);

					excelSheet = excelWorkBook.Worksheets;
					Excel.Worksheet excelWorkSheet = (Excel.Worksheet)excelSheet.get_Item(sheet);

				
					#region Step Fill General Info
					// Step 1
					conn.QueryString = "Select * from NOTA_ANALISA_DETAIL where NOTA_ID = '" + nota + "' order by NOTA_ID, SEQ";
					conn.ExecuteQuery();
		
					dt_field = conn.GetDataTable().Copy();

					conn.QueryString = "exec CP_EXPORT_NOTA_ANALISA '" + Session["BranchName"] + "', '" + Session["FullName"] + "', '" + Request.QueryString["regno"] + "'";
					conn.ExecuteQuery();

					for(int j = 0; j < conn.GetRowCount(); j++)
					{
						for(int i = 0; i < dt_field.Rows.Count; i++)
						{
							string Col = dt_field.Rows[i][2].ToString().Trim();
							int Row = Convert.ToInt32(dt_field.Rows[i][3]);
							string Cell = Col + Row.ToString().Trim();
							string Field = dt_field.Rows[i][4].ToString();

							objValue = conn.GetFieldValue(Field);

							Excel.Range excelCell = (Excel.Range)excelWorkSheet.get_Range(Cell, Cell);
							excelCell.Value2 = objValue;
			
							iItem++;
						}
					}
					#endregion 
					#region Step Fill Hubungan dengan Bank Mandiri 1
					// Step 2.1
					conn.QueryString = "Select * from NOTA_ANALISA_DETAIL1_1 where NOTA_ID = '" + nota + "' order by NOTA_ID, NOTA_ROW, SEQ";
					conn.ExecuteQuery();
		
					dt_field = conn.GetDataTable().Copy();

					conn.QueryString = "exec CP_EXPORT_NOTA_ANALISA1_1 '" + Request.QueryString["regno"] + "'";
					conn.ExecuteQuery();
					
					if((conn.GetRowCount()>1) && (dt_field.Rows.Count>1))
					{
						iItemPosition = Convert.ToInt32(dt_field.Rows[0][3]) + m_Row;

						//Prepare Empty Row with all Formats
						for(int j = 0; j < conn.GetRowCount()-1; j++)
						{
							Excel.Range excelRange = excelWorkSheet.get_Range("A" + iItemPosition.ToString().Trim(), "IV" + iItemPosition.ToString().Trim()).EntireRow;
							excelRange.Insert(Excel.XlInsertShiftDirection.xlShiftDown);
							iItemOther = iItemPosition + j;
						}

						Excel.Range exlCopy = excelWorkSheet.get_Range("A" + (iItemOther + 1).ToString().Trim(), "IV" + (iItemOther + 1).ToString().Trim());
						objCopy = exlCopy.Copy(objType);

						Excel.Range exlPaste = excelWorkSheet.get_Range("A"+ iItemPosition.ToString().Trim(), "A" + iItemOther.ToString().Trim());
						objPaste = exlPaste.PasteSpecial(Excel.XlPasteType.xlPasteAll, Excel.XlPasteSpecialOperation.xlPasteSpecialOperationNone, false, false);
					}
					for(int j = 0; j < conn.GetRowCount(); j++)
					{
						if(j > 0) m_Row = m_Row + 1;

						for(int i = 0; i < dt_field.Rows.Count; i++)
						{
							string Col = dt_field.Rows[i][2].ToString().Trim();
							int Row = Convert.ToInt32(dt_field.Rows[i][3]) + m_Row;
							string Cell = Col + Row.ToString().Trim();
							string Field = dt_field.Rows[i][4].ToString();
							if(Field == "NUM")
								objValue = j + 1 ;
							else
								objValue = conn.GetFieldValue(j, Field);

							Excel.Range excelCell = (Excel.Range)excelWorkSheet.get_Range(Cell, Cell);
							excelCell.Value2 = objValue;

							iItem++;
						}
					}
					#endregion
					#region Step Fill Hubungan dengan Bank Mandiri 2
					// Step 2.2
					conn.QueryString = "Select * from NOTA_ANALISA_DETAIL1_2 where NOTA_ID = '" + nota + "' order by NOTA_ID, SEQ";
					conn.ExecuteQuery();
		
					dt_field = conn.GetDataTable().Copy();

					conn.QueryString = "exec CP_EXPORT_NOTA_ANALISA1_2 '" + Request.QueryString["regno"] + "'";
					conn.ExecuteQuery();

					if((conn.GetRowCount()>1) && (dt_field.Rows.Count>1))
					{
						iItemPosition = Convert.ToInt32(dt_field.Rows[0][3]) +  m_Row;

						//Prepare Empty Row with all Formats
						for(int j = 0; j < conn.GetRowCount()-1; j++)
						{
							Excel.Range excelRange = excelWorkSheet.get_Range("A" + iItemPosition.ToString().Trim(), "IV" + iItemPosition.ToString().Trim()).EntireRow;
							excelRange.Insert(Excel.XlInsertShiftDirection.xlShiftDown);
							iItemOther = iItemPosition + j;
						}

						Excel.Range exlCopy = excelWorkSheet.get_Range("A" + (iItemOther + 1).ToString().Trim(), "IV" + (iItemOther + 1).ToString().Trim());
						objCopy = exlCopy.Copy(objType);

						Excel.Range exlPaste = excelWorkSheet.get_Range("A"+ iItemPosition.ToString().Trim(), "A" + iItemOther.ToString().Trim());
						objPaste = exlPaste.PasteSpecial(Excel.XlPasteType.xlPasteAll, Excel.XlPasteSpecialOperation.xlPasteSpecialOperationNone, false, false);
					}		
					for(int j = 0; j < conn.GetRowCount(); j++)
					{
						if(j > 0) m_Row = m_Row + 1;

						for(int i = 0; i < dt_field.Rows.Count; i++)
						{
							string Col = dt_field.Rows[i][2].ToString().Trim();
							int Row = Convert.ToInt32(dt_field.Rows[i][3]) + m_Row;
							string Cell = Col + Row.ToString().Trim();
							string Field = dt_field.Rows[i][4].ToString();
							if(Field == "NUM")
								objValue = j + 1 ;
							else
								objValue = conn.GetFieldValue(j, Field);

							Excel.Range excelCell = (Excel.Range)excelWorkSheet.get_Range(Cell, Cell);
							excelCell.Value2 = objValue;
						}
					}
					#endregion		
					#region Step Fill Hubungan dengan Bank Lain
					// Step 2.3
					conn.QueryString = "Select * from NOTA_ANALISA_DETAIL1_3 where NOTA_ID = '" + nota + "' order by NOTA_ID, SEQ";
					conn.ExecuteQuery();
		
					dt_field = conn.GetDataTable().Copy();

					conn.QueryString = "exec CP_EXPORT_NOTA_ANALISA1_3 '" + Request.QueryString["regno"] + "'";
					conn.ExecuteQuery();

					if((conn.GetRowCount()>1) && (dt_field.Rows.Count>1))
					{
						iItemPosition = Convert.ToInt32(dt_field.Rows[0][3]) +  m_Row;

						//Prepare Empty Row with all Formats
						for(int j = 0; j < conn.GetRowCount()-1; j++)
						{
							Excel.Range excelRange = excelWorkSheet.get_Range("A" + iItemPosition.ToString().Trim(), "IV" + iItemPosition.ToString().Trim()).EntireRow;
							excelRange.Insert(Excel.XlInsertShiftDirection.xlShiftDown);
							iItemOther = iItemPosition + j;
						}

						Excel.Range exlCopy = excelWorkSheet.get_Range("A" + (iItemOther + 1).ToString().Trim(), "IV" + (iItemOther + 1).ToString().Trim());
						objCopy = exlCopy.Copy(objType);

						Excel.Range exlPaste = excelWorkSheet.get_Range("A"+ iItemPosition.ToString().Trim(), "A" + iItemOther.ToString().Trim());
						objPaste = exlPaste.PasteSpecial(Excel.XlPasteType.xlPasteAll, Excel.XlPasteSpecialOperation.xlPasteSpecialOperationNone, false, false);
					}		
					for(int j = 0; j < conn.GetRowCount(); j++)
					{
						if(j > 0) m_Row = m_Row + 1;

						for(int i = 0; i < dt_field.Rows.Count; i++)
						{
							string Col = dt_field.Rows[i][2].ToString().Trim();
							int Row = Convert.ToInt32(dt_field.Rows[i][3]) + m_Row;
							string Cell = Col + Row.ToString().Trim();
							string Field = dt_field.Rows[i][4].ToString();

							objValue = conn.GetFieldValue(j, Field);

							Excel.Range excelCell = (Excel.Range)excelWorkSheet.get_Range(Cell, Cell);
							excelCell.Value2 = objValue;
						}
					}
					#endregion

					if(iItem > 0)
					{
						excelWorkBook.SaveAs(fileOut, Excel.XlFileFormat.xlWorkbookNormal, null, null, null, null,
							Excel.XlSaveAsAccessMode.xlNoChange, null, null, null, true);
					
						System.Threading.Thread.Sleep(TimeSpan.FromSeconds(3));  																					 
						bSukses = true;
					}
					else
						bSukses = false;

					if(bSukses)	
					{
		
						// Maintenance Table Nota_Export

						conn.QueryString = "exec CP_NOTA_EXPORT '" + nota +"','" + Request.QueryString["regno"] + "','NOTA','" + fileNm + "','" + Session["UserID"] + "', '1'";

						conn.ExecuteQuery();
						mStatus = "Export Succesfully";

					}
					else
					{
						mStatus = "No Data to Export";
					}
				}
				catch{}
				finally
				{
					if(excelWorkBook!=null)
					{
						excelWorkBook.Close(true , fileOut, null);
						excelWorkBook=null;
					}
					if(excelApp!=null)
					{
						excelApp.Workbooks.Close();
						excelApp.Application.Quit();
						excelApp=null;

						for(int x = 0; x < newId.Count; x++)
						{
							Process xnewId = (Process)newId[x];
							
							bool bSameId = false;
							for(int z = 0; z < orgId.Count; z++)
							{
								Process xoldId = (Process)orgId[z];
					
								if(xnewId.Id == xoldId.Id) 
								{
									bSameId = true;
									break;
								}
							}
                            if (!bSameId)
                            {
                                try
                                {
                                    xnewId.Kill();
                                }
                                catch (Exception e)
                                {
                                    continue;
                                }
                            }
						}
					}
				}
			}
			return mStatus;
		}

		#endregion
		#region p_CreateUrus return string
		private string p_CreateUrus()
		{
			string szUser = DDL_USERID.SelectedValue;

			string fileNm = string.Empty;
			string fileIn = string.Empty;
			string fileOut = string.Empty;
			object objPaste = null;
			object objCopy = null;
			bool bSukses = true;
			object objValue = null;
			object objType = Type.Missing;		
			string mStatus = string.Empty;
			int iItem = 0;
			int iItemOther = 0;
			int iItemPosition = 0;
			int m_Row = 0;


			System.Data.DataTable dt_field = null;

			conn.QueryString = "Select * from NOTA_ANALISA where NOTA_ID = '" + var_idExport + "'";
			conn.ExecuteQuery();
				
			if (conn.GetRowCount() > 0) 
			{
				string nota = conn.GetFieldValue("NOTA_ID");
				string sheet = conn.GetFieldValue("NOTA_SHEET");
				string path = conn.GetFieldValue("NOTA_PATH");
				string file_xls = nota + ".XLT";
				string url = conn.GetFieldValue("NOTA_URL");

				Excel.Application excelApp = null;
				Excel.Workbook excelWorkBook = null;
				Excel.Sheets excelSheet = null;

				ArrayList orgId = new ArrayList();
				ArrayList newId = new ArrayList();
						
				Process[] oldProcess = Process.GetProcessesByName("EXCEL");
				foreach(Process thisProcess in oldProcess)
					orgId.Add(thisProcess);

				try
				{
					excelApp = new Excel.ApplicationClass();
					excelApp.Visible = false;
					excelApp.DisplayAlerts = false;
							
					Process[] newProcess = Process.GetProcessesByName("EXCEL");
					foreach(Process thisProcess in newProcess)
						newId.Add(thisProcess);
							
					/// Save process into database
					/// 
					//SupportTools.saveProcessExcel(excelApp, newId, orgId, conn);


					fileIn = path + file_xls;

					excelWorkBook = excelApp.Workbooks.Open(fileIn, 0, false, 5, string.Empty, string.Empty, true, Excel.XlPlatform.xlWindows, "\t|",
						false, false, 0, true);

					excelSheet = excelWorkBook.Worksheets;

					Excel.Worksheet excelWorkSheet = (Excel.Worksheet)excelSheet.get_Item(sheet);
						
					fileNm = Request.QueryString["regno"] + "-" + nota + "-" + var_user + ".XLS";
					fileOut = path + fileNm;
					//fileResult = url + fileNm;

					#region Step Fill Multi Ketentuan Kredit
					// Step 2.1

					conn.QueryString = "Select * from NOTA_ANALISA_DETAIL1_0 where STEP = 1 AND NOTA_ID = '" + nota + "' order by NOTA_ID, NOTA_ROW, SEQ";
					conn.ExecuteQuery();
	
					dt_field = conn.GetDataTable().Copy();

					conn.QueryString = "exec CP_EXPORT_NOTA_ANALISA_WORD6 '" + Request.QueryString["regno"] + "'";
					conn.ExecuteQuery();
				
					for(int j = 0; j < conn.GetRowCount(); j++)
					{
						for(int i = 0; i < dt_field.Rows.Count; i++)
						{
							string Col = dt_field.Rows[i][3].ToString().Trim();
							int Row = Convert.ToInt32(dt_field.Rows[i][4]);
							string Cell = Col + Row.ToString().Trim();
							string Field = dt_field.Rows[i][5].ToString();

							objValue = conn.GetFieldValue(j, Field);

							Excel.Range excelCell = (Excel.Range)excelWorkSheet.get_Range(Cell, Cell);
							excelCell.Value2 = objValue;

							iItem++;
						}
					}

						
					// sTE 2.2
					conn.QueryString = "Select * from NOTA_ANALISA_DETAIL1_0 where STEP = 0 AND NOTA_ID = '" + nota + "' order by NOTA_ID, NOTA_ROW, SEQ";
					conn.ExecuteQuery();
	
					dt_field = conn.GetDataTable().Copy();

					conn.QueryString = "exec CP_EXPORT_NOTA_ANALISA_WORD6 '" + Request.QueryString["regno"] + "'";
					conn.ExecuteQuery();
				
					if((conn.GetRowCount()>1) && (dt_field.Rows.Count>1))
					{
						iItemPosition = Convert.ToInt32(dt_field.Rows[0][4]);

						//Prepare Empty Row with all Formats
						for(int j = 0; j < conn.GetRowCount()-1; j++)
						{
							Excel.Range excelRange = excelWorkSheet.get_Range("A" + iItemPosition.ToString().Trim(), "IV" + iItemPosition.ToString().Trim()).EntireRow;
							excelRange.Insert(Excel.XlInsertShiftDirection.xlShiftDown);
							iItemOther = iItemPosition + j;
						}

						Excel.Range exlCopy = excelWorkSheet.get_Range("A" + (iItemOther + 1).ToString().Trim(), "IV" + (iItemOther + 1).ToString().Trim());
						objCopy = exlCopy.Copy(objType);

						Excel.Range exlPaste = excelWorkSheet.get_Range("A"+ iItemPosition.ToString().Trim(), "A" + iItemOther.ToString().Trim());
						objPaste = exlPaste.PasteSpecial(Excel.XlPasteType.xlPasteAll, Excel.XlPasteSpecialOperation.xlPasteSpecialOperationNone, false, false);
					}

					for(int j = 0; j < conn.GetRowCount(); j++)
					{
						if(j > 0) m_Row = m_Row + 1;

						for(int i = 0; i < dt_field.Rows.Count; i++)
						{
							string Col = dt_field.Rows[i][3].ToString().Trim();
							int Row = Convert.ToInt32(dt_field.Rows[i][4])+ m_Row;
							string Cell = Col + Row.ToString().Trim();
							string Field = dt_field.Rows[i][5].ToString();

							if(Field == "NUM")
								objValue = j + 1 ;
							else
								objValue = conn.GetFieldValue(j, Field);

							Excel.Range excelCell = (Excel.Range)excelWorkSheet.get_Range(Cell, Cell);
							excelCell.Value2 = objValue;

							iItem++;
						}
					}
					#endregion


					if(iItem > 0) 
					{
						excelWorkBook.SaveAs(fileOut, Excel.XlFileFormat.xlWorkbookNormal, null, null, null, null,
							Excel.XlSaveAsAccessMode.xlNoChange, null, null, null, true);
						
						System.Threading.Thread.Sleep(TimeSpan.FromSeconds(3));  																					 
						bSukses = true;
					}
					else
						bSukses = false;

					if(bSukses)	
					{
						// Maintenance Table Nota_Export
							
						conn.QueryString = "exec CP_NOTA_EXPORT '" + nota +"','" + Request.QueryString["regno"] + "','NOTA','" + fileNm + "','" + Session["UserID"] + "', '1'";
						conn.ExecuteQuery();

						mStatus = "Export Succesfully";

					}
					else
					{
						mStatus = "No Data to Export";
					}
				}
				catch{}
				finally
				{
					if(excelWorkBook!=null)
					{
						excelWorkBook.Close(true , fileOut, null);
						excelWorkBook=null;
					}
					if(excelApp!=null)
					{
						excelApp.Workbooks.Close();
						excelApp.Application.Quit();
						excelApp=null;

						for(int x = 0; x < newId.Count; x++)
						{
							Process xnewId = (Process)newId[x];
								
							bool bSameId = false;
							for(int z = 0; z < orgId.Count; z++)
							{
								Process xoldId = (Process)orgId[z];
						
								if(xnewId.Id == xoldId.Id) 
								{
									bSameId = true;
									break;
								}
							}
                            if (!bSameId)
                            {
                                try
                                {
                                    xnewId.Kill();
                                }
                                catch (Exception e)
                                {
                                    continue;
                                }
                            }
						}
					}
				}

			}
			return mStatus;
		}
		#endregion

        public string popUp = "";
        protected void BTN_APPROVE_Click(object sender, System.EventArgs e)
		{
			//Response.Write("<script for=window event=onload language='javascript'>PopupPage('../VerifyUser.aspx?userid=" + var_user + "&theForm=Form1&theObj=TXT_VERIFY', '430','150');</script>");
            popUp = "<script for=window event=onload language='javascript'>PopupPage('../VerifyUser.aspx?userid=" + var_user + "&theForm=Form1&theObj=TXT_VERIFY', '430','150');</script>";
		}

		protected void BTN_REJECT_Click(object sender, System.EventArgs e)
		{
			//Response.Write("<script for=window event=onload language='javascript'>PopupPage('../VerifyUser.aspx?userid=" + var_user + "&theForm=Form1&theObj=TXT_VERIFY2', '430','150');</script>");
            popUp = "<script for=window event=onload language='javascript'>PopupPage('../VerifyUser.aspx?userid=" + var_user + "&theForm=Form1&theObj=TXT_VERIFY2', '430','150');</script>";
		}

	}
}
