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

namespace SME.Scoring
{
	/// <summary>
	/// Summary description for Main.sdafsadf
	/// </summary>
	public partial class ScoringResult : System.Web.UI.Page
	{
		protected Connection conn;
		protected Tools tool = new Tools();
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			conn = (Connection) Session["Connection"];
			int upload_response = 0;

			if (!Logic.AllowAccess(Session["GroupID"].ToString(), Request.QueryString["mc"], conn))
				Response.Redirect("/SME/Restricted.aspx");

			/*SME.Scoring.clsFICounter objFICounter = new SME.Scoring.clsFICounter(conn, (string)Request.QueryString["regno"], (string)Request.QueryString["curef"]);
			if (objFICounter.check_counter("FS" ) == false )
			{

				if (!IsPostBack)
				{
					
					lblCounter.Text="0";
					LBL_USERID.Text = Session["UserID"].ToString();

					if (Request.QueryString["mode"] == "result")
					{
						BTN_SEND_ULANG.Enabled=false;
						Button1.Enabled=false;
						viewData();
					}
					else
					{
						upload_response = 0;
						if ((upload_response = UploadResponse())==1)
						{
							/// Cek : SELECT AP_ACQINFO FROM APPLICATION where ap_regno='10012005CBC1000002'
							/// kalau ada isinya --> aplikasi dari Approval ke BU
							/// Kalau ngga ada isinya --> berarti ngga
							/// 
							conn.QueryString="SELECT isnull(AP_ACQINFO,'') as AP_ACQINFO FROM APPLICATION where ap_regno='" + Request.QueryString["regno"]  + "'";
							conn.ExecuteQuery();
							if(conn.GetFieldValue("AP_ACQINFO").Trim()!="")
							{
								//check acq_counter > 1 && status = 0
								// update status.Enabled=true;
								setEnableUpadateStatusButton();
							}
							else 
							{
								updatestatus.Enabled=true;	
							}

							///	// --start -- by ashari 20041227
							//	panggil fungsi setFICounter dari class clsFICounter 
							//SME.Scoring.clsFICounter objFICounter = new SME.Scoring.clsFICounter(conn, (string)Request.QueryString["regno"], (string)Request.QueryString["curef"]);
							objFICounter.setFICounter("FS","RCV");
							//	// --end -- by ashari 20041227
							viewData();
						}
					}
					
				}
			}
			else 
			{
				lblCounter.Text="0";
				upload_response = 1;
				viewData();
			}
			SecureData();
			ViewMenu();
			
			if (upload_response == 1 ) 
			{
				conn.QueryString="SELECT isnull(AP_ACQINFO,'') as AP_ACQINFO FROM APPLICATION where ap_regno='" + Request.QueryString["regno"]  + "'";
				conn.ExecuteQuery();
				if(conn.GetFieldValue("AP_ACQINFO").Trim()!="")
				{
					//check acq_counter > 1 && status = 0
					// update status.Enabled=true;
					setEnableUpadateStatusButton();
				}
				else 
				{
					updatestatus.Enabled=true;	
				}
				///	// --start -- by ashari 20041227
				//	panggil fungsi setFICounter dari class clsFICounter 
					//SME.Scoring.clsFICounter objFICounter = new SME.Scoring.clsFICounter(conn, (string)Request.QueryString["regno"], (string)Request.QueryString["curef"]);
					objFICounter.setFICounter("FS","RCV");
				//	// --end -- by ashari 20041227
			}
			
			setDisabledResult();
			setEnabledResult();

			//updatestatus.Attributes.Add("onclick", "if(!update()) { return false; };");
			updatestatus.Attributes.Add("onclick","if(!updateMsg('E')){return false;};");

			//setEnableUpadateStatusButton();
			//BTN_SAVE.Attributes.Add("onclick","if(!cek_mandatory(document.Form1)){return false;};");*/

			setDisabledResult();
			LoadResult();

			conn.QueryString = "SELECT * FROM SCORING_RESPONSE_TBL WHERE AP_REGNO = '" + Request.QueryString["REGNO"] + "' AND SUMBERDATA = 'FINALSCORING'  AND NUM_AC_INFO_SCORE = '12345'";
			conn.ExecuteQuery();

			if(conn.GetRowCount() > 0)
			{
				updatestatus.Visible = true;
				updatestatus.Enabled = true;
			}
		}

		private void LoadResult()
		{
			LBL_OHD_SYS_DECISION.Text = "";

			conn.QueryString = "SELECT ID, IDOVERALL, IDSCORECUTOFF, AP_REGNO FROM RFSCORINGRESULT WHERE AP_REGNO = '" + Request.QueryString["REGNO"] + "' AND SUMBERDATA = 'FINALSCORING'";
			conn.ExecuteQuery();

			if(conn.GetRowCount() > 0)
			{
				string APREGNO = conn.GetFieldValue("AP_REGNO").ToString();
				int IDOVERALL = Convert.ToInt32(conn.GetFieldValue("IDOVERALL").ToString());
				int IDSCORECUTOFF = Convert.ToInt32(conn.GetFieldValue("IDSCORECUTOFF").ToString());

				conn.QueryString = "SELECT DESCRIPTION FROM RFSCORINGOVERALRESULT WHERE ID = '" + IDOVERALL + "'";
				conn.ExecuteQuery();

				LBL_OHD_SYS_DECISION.Text = conn.GetFieldValue("DESCRIPTION").ToString();

				conn.QueryString = "SELECT SCORERESULT FROM RFSCORINGCUTOFFSCORE WHERE ID = '" + IDSCORECUTOFF + "'";
				conn.ExecuteQuery();

				LBL_A1401.Text = conn.GetFieldValue("SCORERESULT").ToString();

				conn.QueryString = "select RFSCORINGRULEREASON.REASON_CODE, RFSCORINGRULEREASON.DESCRIPTION from RFSCORINGRULEREASON,RFSCORINGRULEREASONRESULT where RFSCORINGRULEREASONRESULT.IDRULEREASON = RFSCORINGRULEREASON.ID AND RFSCORINGRULEREASONRESULT.APREGNO ='"+ APREGNO +"' AND RFSCORINGRULEREASONRESULT.SUMBERDATA = 'FINALSCORING'";
				conn.ExecuteQuery();
				DataTable dt = new DataTable();
				dt = conn.GetDataTable().Copy();

				dtGrid.DataSource = dt;				
				dtGrid.DataBind();
			}
			else
			{
				viewData();
			}
		}
		

		//Procedure ini melakukan set Enable/Disable UpdateStatusButton Final Scoring
		private void setEnableUpadateStatusButton()
		{
			conn.QueryString="exec SP_GET_SCORINGRESULT_STATUS '" + Request.QueryString["regno"] + "'";
			conn.ExecuteQuery();
			if (conn.GetFieldValue(0,0)=="1")
			{
				updatestatus.Enabled=true;
				//btn_Print.Enabled=true;
			}
			else
			{
				updatestatus.Enabled=false;
				//btn_Print.Enabled=false;
			}
		}

		//Procedure ini melakukan set Disable semua kelompok business type
		private void setDisabledResult()
		{
			TR_MICLOW.Visible=false;
			TR_PUKK.Visible=false;
			TR_SB.Visible=false;
			TR_MC.Visible=false;
			tr_hide1.Visible=false;
			
			Button2.Visible = false;
			BTN_SEND_ULANG.Visible = false;
			Button1.Visible = false;
			TR_KetAmbilScoreTerakhir.Visible = false;
			updatestatus.Visible = false;
		}

		//Procedure ini melakukan set Disable semua kelompok business type
		private void setEnabledResult()
		{
			string tipeBusiness="";
			conn.QueryString="exec SP_GETBUSINESSTYPE '" + Request.QueryString["regno"] + "'";
				conn.ExecuteQuery();
			tipeBusiness=conn.GetFieldValue("tipeKey");
			/*
			if (tipeBusiness.Equals("SMALL_SCR"))
			{
				TR_SB.Visible=true;
			}
			else if (tipeBusiness.Equals("MIDDLE_SCR"))
			{
				TR_MC.Visible=true;
				setWCLClimit();
			}
			else if (tipeBusiness.Equals("MICRO_SCR")||tipeBusiness.Equals("LOWLINE_SCR"))
			{
				TR_MICLOW.Visible=true;
			}
			else if (tipeBusiness.Equals("PUKK_SCR"))
			{
				TR_PUKK.Visible=true;
			}
			*/
		}

		//Procedure ini melakukan pemilihan textbox mana yang aktif dengan kondisi sbb :
		//1. bila G0021 kosong dan G0030 kosong -> G0021 Enable dan G0030 Disable
		//2. bila G0021 kosong dan G0030 isi -> G0021 Enable dan G0030 Disable
		//3. bila G0021 isi dan G0030 kosong -> G0021 able dan G0030 Enable
		//4. bila G0021 isi dan G0030 isi -> G0021 Enable dan G0030 Disable
		private void setWCLClimit()
		{
			string str_G0021=LBL_G0021.Text.Trim();
			string str_G0030=LBL_G0030.Text.Trim();
			double dbl_G0021=0;
			double dbl_G0030=0;

			if (str_G0021.Trim()=="") 
			{
				dbl_G0021=0;
			}
			else
			{
				try
				{
					dbl_G0030=Convert.ToDouble(str_G0021);
				}
				catch
				{
					dbl_G0021=0;
				}
			}

			if (str_G0030.Trim()=="") 
			{
				dbl_G0030=0;
			}
			else
			{
				try
				{
					dbl_G0030=Convert.ToDouble(str_G0030);
				}
				catch
				{
					dbl_G0030=0;
				}
			}


			if ((dbl_G0021!=0) && (dbl_G0030!=0))
			{
				LBL_G0021.Visible=true;
				LBL_G0030.Visible=false;
			}
			else if ((dbl_G0021!=0) && (dbl_G0030==0))
			{
				LBL_G0021.Visible=true;
				LBL_G0030.Visible=false;
			}
			else if ((dbl_G0021==0) && (dbl_G0030!=0))
			{
				LBL_G0021.Visible=false;
				LBL_G0030.Visible=true;
			}
			else if ((dbl_G0021==0) && (dbl_G0030==0))
			{
				LBL_G0021.Visible=true;
				LBL_G0030.Visible=false;
			}
		}


		private void SecureData() 
		{
			string scr = Request.QueryString["scr"];

			if (scr == "0")
			{
				System.Web.UI.ControlCollection coll = this.Page.Controls;
				int k = 0;
				for (int j=0; j < coll.Count; j++) 
				{
					if (coll[j] is System.Web.UI.HtmlControls.HtmlForm) 
					{
						k = j;
						break;
					}
				}				

				for (int i = 0; i < coll[k].Controls.Count; i++) 
				{
					if (coll[k].Controls[i] is TextBox) 
					{
						TextBox txt = (TextBox) coll[k].Controls[i];
						txt.ReadOnly = true;
					}
					else if (coll[k].Controls[i] is DropDownList) 
					{
						DropDownList ddl = (DropDownList) coll[k].Controls[i];
						ddl.Enabled = false;
					}
					else if (coll[k].Controls[i] is Button)
					{
						Button btn = (Button) coll[k].Controls[i];
						btn.Visible = false;
					}
					else if (coll[k].Controls[i] is RadioButtonList) 
					{
						RadioButtonList rbl = (RadioButtonList) coll[k].Controls[i];
						rbl.Enabled = false;
					}
					else if (coll[k].Controls[i] is RadioButton) 
					{
						RadioButton rb = (RadioButton) coll[k].Controls[i];
						rb.Enabled = false;
					}
					else if (coll[k].Controls[i] is CheckBox)
					{
						CheckBox cb = (CheckBox) coll[k].Controls[i];
						cb.Enabled = false;
					}					
					else if (coll[k].Controls[i] is HtmlTableRow) 
					{
						HtmlTableRow htr = (HtmlTableRow) coll[k].Controls[i];

						for (int j=0; j < htr.Controls.Count; j++) 
						{							
							for (int jj = 0; jj < htr.Controls[j].Controls.Count; jj++) 
							{
								if (htr.Controls[j].Controls[jj] is TextBox) 
								{
									TextBox txt = (TextBox) htr.Controls[j].Controls[jj];
									txt.ReadOnly = true;
								}
								else if (htr.Controls[j].Controls[jj] is DropDownList) 
								{
									DropDownList ddl = (DropDownList) htr.Controls[j].Controls[jj];
									ddl.Enabled = false;
								}
								else if (htr.Controls[j].Controls[jj] is Button)
								{
									Button btn = (Button) htr.Controls[j].Controls[jj];
									btn.Visible = false;
								}
								else if (htr.Controls[j].Controls[jj] is RadioButtonList) 
								{
									RadioButtonList rbl = (RadioButtonList) htr.Controls[j].Controls[jj];
									rbl.Enabled = false;
								}
								else if (htr.Controls[j].Controls[jj] is RadioButton) 
								{
									RadioButton rb = (RadioButton) htr.Controls[j].Controls[jj];
									rb.Enabled = false;
								}
								else if (htr.Controls[j].Controls[jj] is CheckBox)
								{
									CheckBox cb = (CheckBox) htr.Controls[j].Controls[jj];
									cb.Enabled = false;
								}					
							}
						}
					}
				}
			}
		}

		//Menentukan url link back dari menu scoring result
		private string backLinkLocal(string mc) 
		{
			try 
			{
				conn.QueryString = "select TM_LINKNAME + TM_PARSINGPARAM as BACKLINK from track_menu where menucode = '" + mc + "'";
				conn.ExecuteQuery(); 

				return conn.GetFieldValue("BACKLINK");
			}
			catch (NullReferenceException) 
			{
				GlobalTools.popMessage(this, "Server Error!");				
				return "Login.aspx?expire=1";
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

		}
		#endregion

		private void BTN_SAVE_Click(object sender, System.EventArgs e)
		{
		}

		//Procedure ini menampilkan data hasil scoring yang telah disimpan di database
		private void viewData()
		{

			string strRegno = Request.QueryString["regno"];
			string lblA1405="";
			string lblA1405A="";

			//conn.QueryString = "select * from scoring_response_tbl where ap_Regno like '%"+ strRegno +"%'  AND SUMBERDATA='PRESCORING'";
			conn.QueryString = "EXEC SP_SCORING_RESPONSE_TBL_GET '" + strRegno + "','FINALSCORING'";
			conn.ExecuteQuery();
			if (conn.GetRowCount()>0)
			{
				LBL_A1401.Text = getScoringResultDesc("SCRCLASS",conn.GetFieldValue(0,"A1401"));
				LBL_A1401_HIDEN.Text = conn.GetFieldValue(0,"A1401");
				LBL_A1402.Text = getScoringResultDesc("VISITIND",conn.GetFieldValue(0,"A1402")); 
				LBL_A1403.Text = getScoringResultDesc("FINFORMAT",conn.GetFieldValue(0,"A1403")); 
				if (LBL_A1403.Text.Trim()=="0")  LBL_A1403.Text = "";
				LBL_A1404.Text = getScoringResultDesc("MANREVIEW",conn.GetFieldValue(0,"A1404"));

				lblA1405 = conn.GetFieldValue(0,"A1405");
				lblA1405A=conn.GetFieldValue(0,"A1405");
				LBL_A1407.Text = conn.GetFieldValue(0,"A1407");
				LBL_A1408.Text = conn.GetFieldValue(0,"A1408");
				LBL_A1409.Text = conn.GetFieldValue(0,"A1409");
				LBL_A1410.Text = conn.GetFieldValue(0,"A1410");
				LBL_A1411.Text = conn.GetFieldValue(0,"A1411");
				LBL_A1412.Text = conn.GetFieldValue(0,"A1412");
				LBL_A1413.Text = conn.GetFieldValue(0,"A1413");
				LBL_A1414.Text = conn.GetFieldValue(0,"A1414");
				LBL_A1415.Text = conn.GetFieldValue(0,"A1415");
				LBL_A1419.Text = conn.GetFieldValue(0,"A1419");
				LBL_G0001.Text=conn.GetFieldValue(0,"G0001");
				LBL_G0002.Text=conn.GetFieldValue(0,"G0002");
				LBL_G0002A.Text=GlobalTools.MoneyFormat(conn.GetFieldValue(0,"G0002"));
				LBL_G0003.Text=GlobalTools.MoneyFormat(conn.GetFieldValue(0,"G0003"));
				LBL_G0004.Text=GlobalTools.MoneyFormat(conn.GetFieldValue(0,"G0004"));
				LBL_G0005.Text=GlobalTools.MoneyFormat(conn.GetFieldValue(0,"G0005"));
				LBL_G0006.Text=GlobalTools.MoneyFormat(conn.GetFieldValue(0,"G0006"));
				LBL_G0006A.Text=GlobalTools.MoneyFormat(conn.GetFieldValue(0,"G0006"));
				LBL_G0006B.Text=GlobalTools.MoneyFormat(conn.GetFieldValue(0,"G0006"));
				LBL_G0007.Text=GlobalTools.MoneyFormat(conn.GetFieldValue(0,"G0007"));
				LBL_G0008.Text=GlobalTools.MoneyFormat(conn.GetFieldValue(0,"G0008"));
				LBL_G0009.Text=GlobalTools.MoneyFormat(conn.GetFieldValue(0,"G0009"));
				LBL_G0010.Text=GlobalTools.MoneyFormat(conn.GetFieldValue(0,"G0010"));
				LBL_G0011.Text=GlobalTools.MoneyFormat(conn.GetFieldValue(0,"G0011"));
				LBL_G0011A.Text=GlobalTools.MoneyFormat(conn.GetFieldValue(0,"G0011"));
				LBL_G0012.Text=GlobalTools.MoneyFormat(conn.GetFieldValue(0,"G0012"));
				LBL_G0013.Text=GlobalTools.MoneyFormat(conn.GetFieldValue(0,"G0013"));
				LBL_G0014.Text=GlobalTools.MoneyFormat(conn.GetFieldValue(0,"G0014"));
				LBL_G0015.Text=GlobalTools.MoneyFormat(conn.GetFieldValue(0,"G0015"));
				LBL_G0016.Text=GlobalTools.MoneyFormat(conn.GetFieldValue(0,"G0016"));
				LBL_G0017.Text=GlobalTools.MoneyFormat(conn.GetFieldValue(0,"G0017"));
				LBL_G0018.Text=GlobalTools.MoneyFormat(conn.GetFieldValue(0,"G0018"));
				LBL_G0019.Text=GlobalTools.MoneyFormat(conn.GetFieldValue(0,"G0019"));
				LBL_G0020.Text=GlobalTools.MoneyFormat(conn.GetFieldValue(0,"G0020"));
				LBL_G0021.Text=GlobalTools.MoneyFormat(conn.GetFieldValue(0,"G0021"));
				LBL_G0022.Text=GlobalTools.MoneyFormat(conn.GetFieldValue(0,"G0022"));
				LBL_G0023.Text=GlobalTools.MoneyFormat(conn.GetFieldValue(0,"G0023"));
				LBL_G0024.Text=GlobalTools.MoneyFormat(conn.GetFieldValue(0,"G0024"));
				LBL_G0025.Text=GlobalTools.MoneyFormat(conn.GetFieldValue(0,"G0025"));
				LBL_G0026.Text=GlobalTools.MoneyFormat(conn.GetFieldValue(0,"G0026"));
				LBL_G0027.Text=GlobalTools.MoneyFormat(conn.GetFieldValue(0,"G0027"));
				LBL_G0028.Text=GlobalTools.MoneyFormat(conn.GetFieldValue(0,"G0028"));
				LBL_G0029.Text=GlobalTools.MoneyFormat(conn.GetFieldValue(0,"G0029"));
				LBL_G0030.Text=GlobalTools.MoneyFormat(conn.GetFieldValue(0,"G0030"));
				LBL_G0031.Text=GlobalTools.MoneyFormat(conn.GetFieldValue(0,"G0031"));

				LBL_OHD_SYS_DECISION.Text        = getScoringResultDesc("OVERALL",conn.GetFieldValue(0,"OHD_SYS_DECISION"));
				LBL_OHD_SYS_DECISION_HIDDEN.Text = conn.GetFieldValue(0,"OHD_SYS_DECISION");
				OSC_FINAL_SCORE.Text             = conn.GetFieldValue(0,"OSC_FINAL_SCORE");

				conn.QueryString = "select * from VW_IDT_RULE_REASON where AP_REGNO='"+ Request.QueryString["regno"] +"' AND SUMBERDATA='FINALSCORING'";
				conn.ExecuteQuery();
				DataTable dt = new DataTable();
				dt = conn.GetDataTable().Copy();

				dtGrid.DataSource = dt;				
				dtGrid.DataBind();

				statusButton();
			}			
			if (!lblA1405.Trim().Equals(""))
			{
				LBL_A1405.Text=getScoringResultDesc("PRICING",lblA1405);
				LBL_A1405.Text=getScoringResultDesc("PRICING",lblA1405A);
			}
		}



		//Procedure untuk menampilkan menu melalui placeholder
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
						strtemp = "regno=" + Request.QueryString["regno"] + "&curef="+Request.QueryString["curef"]+"&mc="+Request.QueryString["mc"]+"&tc="+Request.QueryString["tc"];
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

		protected void updatestatus_Click(object sender, System.EventArgs e)
		{
			/////////////////////////////////////////////////////////////////////////////////////////////////
			///	Before update status, make sure user already send message to STW
			///	
			//conn.QueryString = "select isnull(fscounter, 0) fscounter from scoring_counter where ap_regno = '" + Request.QueryString["regno"] + "'";
			/*conn.QueryString = "exec SCORING_CEKMESSAGE '" + Request.QueryString["regno"] + "'";
			conn.ExecuteQuery();
			int _fscounter = 0;
			try { _fscounter = Convert.ToInt16(conn.GetFieldValue("fscounter")); } catch {}
			if (_fscounter <= 0) 
			{
				GlobalTools.popMessage(this, "Please conduct final scoring first!");
				return;
			}*/

			DataTable dt;
			conn.QueryString = "select apptype, productid, PROD_SEQ from custproduct where ap_regno='" + Request.QueryString["regno"] +
				"' AND isnull(cp_reject,'0') <> '1' and isnull(cp_cancel,'0') <> '1'";
			conn.ExecuteQuery();
			dt = conn.GetDataTable().Copy();
			for (int i = 0; i < dt.Rows.Count; i++)
			{
				conn.QueryString = "exec TRACKUPDATE '" + Request.QueryString["regno"] + "', '" +
					dt.Rows[i][1].ToString() + "', '" + dt.Rows[i][0].ToString() + "', '" + Session["UserID"].ToString() + "', '" + dt.Rows[i]["PROD_SEQ"].ToString() + "','"+Request.QueryString["tc"].Trim()+"'";
				conn.ExecuteNonQuery();
			}

			///////////////////////////////////////////////////////////////////////////////////////
			/// Reset Acquire Info counter to zero
			/// 
			conn.QueryString = " update scoring_counter set AcqCounter = 0 where ap_regno = '" + Request.QueryString["regno"] + "'";
			conn.ExecuteNonQuery();


			////////////////////////////////////////////////////////////////////////////////////////
			/// Update Routing Approval according Scoring Result
			/// 
			conn.QueryString = "exec SCORING_SETAPRVROUTE '" + Request.QueryString["regno"] + "'";
			conn.ExecuteNonQuery();
		
			string msg = getNextStepMsg(Request.QueryString["regno"]);

			Response.Redirect("ListScoring.aspx?tc=" + Request.QueryString["tc"] + "&mc=" + Request.QueryString["mc"] + "&msg=" + msg);				
			//Response.Redirect("ListPreScoring.aspx?tc=" + Request.QueryString["tc"] + "&mc=" + Request.QueryString["mc"]);		
		}

		//fungsi untuk cek apakah business unit-nya adalah LOW-LINE atau HIGH-LINE
		private bool isLowLine() 
		{
			bool ret = true;

			//---- Memeriksa LOW-LINE atau HIGH-LINE
			conn.QueryString = "select * from VW_SR_GREYZONE_CEK where AP_REGNO = '"+Request.QueryString["regno"]+"'";
			conn.ExecuteQuery();
		
			if (conn.GetFieldValue("ISLOWLINE") == "0") ret = false;

			return ret;
		}

		//Update track terjadi bila hasil score adalah ACCEPT 
		/***
		private void trackUpdate() 
		{
			//DataTable dt;
			conn.QueryString = "select checkbi from customer where cu_ref='" + Request.QueryString["curef"] + "'";
			conn.ExecuteQuery();
			if (conn.GetRowCount() > 0)
			{
				if (conn.GetFieldValue(0,0) == "1")
				{
					conn.QueryString = "insert into bi_status (ap_regno, cu_ref, bs_reqdate, bs_recvdate, bs_bidataavail, bs_complete) " + 
						"values ('" + Request.QueryString["regno"] + "', '" + Request.QueryString["curef"] + "', getdate(), null, null, '0')";
					conn.ExecuteQuery();
				}
			}
			
			conn.QueryString = "select apptype, productid, PROD_SEQ " +
			" from custproduct where ap_regno='" + Request.QueryString["regno"] + "'";
			conn.ExecuteQuery();
			DataTable data = new DataTable();
			data = conn.GetDataTable().Copy();
			
			for (int i = 0; i < data.Rows.Count; i++)
			{
				// trackupdate execution
				conn.QueryString = "exec TRACKUPDATE '" + 
					Request.QueryString["regno"] + "', '" +
					data.Rows[i]["productid"].ToString() + "', '" + 
					data.Rows[i]["apptype"].ToString() + "', '" + 
					Session["UserID"].ToString() + "', '" + 
					data.Rows[i]["PROD_SEQ"].ToString() + "'";
				conn.ExecuteNonQuery();
			}

			Response.Redirect("ListPreScoring.aspx?tc=" + Request.QueryString["tc"] + "&mc=" + Request.QueryString["mc"]);

		}
		***/


		//Gagal update status terjadi bilamana hasil score adalah Decline (DL)
		private void trackFail() 
		{
			string sql = "update application set AP_REJECT = '1' where ap_regno = '"+Request.QueryString["regno"]+"' ";
			conn.QueryString = sql;
			conn.ExecuteNonQuery();
			
			conn.QueryString = "exec RJ_CHECKREJECT '" + Request.QueryString["regno"] + "', '" + Request.QueryString["curef"] + "'";
			conn.ExecuteNonQuery();

			DataTable dt;
			conn.QueryString = "select apptype, productid, prod_seq from custproduct where ap_regno='" + Request.QueryString["regno"] + "'";
			conn.ExecuteQuery();
			dt = conn.GetDataTable().Copy();
			for (int i = 0; i < dt.Rows.Count; i++)
			{
				conn.QueryString = "exec TRACKFAIL '" + 
									Request.QueryString["regno"] + "', '" +
									dt.Rows[i][1].ToString() + "', '" + 
									dt.Rows[i][0].ToString() + "', '" + 
									LBL_USERID.Text + "', '" + 
									dt.Rows[i]["prod_seq"].ToString() + "','"+ Request.QueryString["tc"] +"'";
				conn.ExecuteNonQuery();
			}
			Response.Redirect("ListPreScoring.aspx?tc=" + Request.QueryString["tc"] + "&mc=" + Request.QueryString["mc"]);
		}

		protected void Button1_Click(object sender, System.EventArgs e)
		{
			if (LBL_OHD_SYS_DECISION_HIDDEN.Text== "DL")
				Response.Write("<script language='javascript'>window.open('/SME/Letters/RejectLetter.aspx?regno=" + Request.QueryString["regno"] + "','RejectLetter','status=no,scrollbars=yes,width=800,height=600');</script>");
			else if (LBL_OHD_SYS_DECISION_HIDDEN.Text== "AC")
			{
				conn.QueryString = "select cu_custtypeid from customer where cu_ref='" + Request.QueryString["curef"] + "'";
				conn.ExecuteQuery();
				if (conn.GetFieldValue(0,0) == "01")
					Response.Write("<script language='javascript'>window.open('/SME/Letters/AIP1.aspx?regno=" + Request.QueryString["regno"] + "&apptype=01','AIPLetter','status=no,scrollbars=yes,width=800,height=600');</script>");
				else
					Response.Write("<script language='javascript'>window.open('/SME/Letters/AIP2.aspx?regno=" + Request.QueryString["regno"] + "&apptype=01','AIPLetter','status=no,scrollbars=yes,width=800,height=600');</script>");
			}
			else 
			{
				string TEXT = Button1.Text;
				if (TEXT.IndexOf("AIP") >= 0) 
				{
					conn.QueryString = "select cu_custtypeid from customer where cu_ref='" + Request.QueryString["curef"] + "'";
					conn.ExecuteQuery();
					if (conn.GetFieldValue(0,0) == "01")
						Response.Write("<script language='javascript'>window.open('/SME/Letters/AIP1.aspx?regno=" + Request.QueryString["regno"] + "&apptype=01','AIPLetter','status=no,scrollbars=yes,width=800,height=600');</script>");
					else
						Response.Write("<script language='javascript'>window.open('/SME/Letters/AIP2.aspx?regno=" + Request.QueryString["regno"] + "&apptype=01','AIPLetter','status=no,scrollbars=yes,width=800,height=600');</script>");
				}
				else 
				{
					Response.Write("<script language='javascript'>window.open('/SME/Letters/RejectLetter.aspx?regno=" + Request.QueryString["regno"] + "','RejectLetter','status=no,scrollbars=yes,width=800,height=600');</script>");
				}
			}
		}
		private void TXT_SR_MANREVIEWTYPE_TextChanged(object sender, System.EventArgs e)
		{
		}

		protected void BTN_SEND_ULANG_Click(object sender, System.EventArgs e)
		{
			Response.Redirect("ScoringMain.aspx?regno=" + Request.QueryString["regno"]+ "&curef=" + Request.QueryString["curef"] + "&mc=" + Request.QueryString["mc"] + "&tc=" + Request.QueryString["tc"]);		
		}

		private void BTN_RETRIEVE_Click(object sender, System.EventArgs e)
		{
			UploadResponse();
		}

		//Fungsi ini melakukan pemecahan string panjang response scoring dan dimasukan ke database
		private int UploadResponse()
		{
			string strHasil;
			string strRegno = Request.QueryString["regno"];			
			System.Threading.Thread.Sleep(2000);

			///////////////////////////////////////////////////////////////////////////////////////////////////
			/// Retrieve scoring response from Strategy Ware
			/// Note: Strategy Ware doesn't differentiate between PRESCORING and FINALSCORING
			/// 
			conn.QueryString="SP_SCORING_RESPONSE_GET '" + strRegno + "','PRESCORING'";
			conn.ExecuteQuery();
			if (conn.GetRowCount()==0)
			{
				GlobalTools.popMessage(this,"Response belum diterima. Tunggu beberapa detik lagi.");
				return 0;

				System.Threading.Thread.Sleep(4000);
				conn.QueryString="SP_SCORING_RESPONSE_GET '" + strRegno + "','PRESCORING'";
				conn.ExecuteQuery();
				if (conn.GetRowCount()==0)
				{
					GlobalTools.popMessage(this,"Response masih belum diterima. Silakan Kirim Ulang.");
					return 0;
				}
			}
			strHasil=conn.GetFieldValue("msgresponse");


			string strDate, strTime, strOrs, strOst, strOsc, strOpr, strFACOSC, strFACOHD, OSC_FINAL_SCORE, OHD_SYS_DECISION;
			int startCalcPos, Pos, lenFACOSC, intFACOSC;

			if (strHasil.Trim().Length == 0)
			{
				GlobalTools.popMessage(this,"Hasil response kosong.");
				return 0;
			}

			strDate=strHasil.Substring(61,8);
			strTime=strHasil.Substring(69,8);
			
			strOrs=strHasil.Substring(85,2);
			strOst=strHasil.Substring(87,2);
			strOpr=strHasil.Substring(89,2);
			strOsc=strHasil.Substring(91,2);
			
			startCalcPos = 1922 + (int.Parse(strOrs)*63) + (int.Parse(strOst)*117) + (int.Parse(strOsc)*691) + (int.Parse(strOpr)*202) ;
			intFACOSC    = 1922 + (int.Parse(strOrs)*63) + (int.Parse(strOst)*117);
			lenFACOSC    = (int.Parse(strOsc)*691);

			// Cek Error Code yang dikirim oleh STW
			// Blank 5 char : sukses
			strFACOHD    = strHasil.Substring(0,1921);
			string strErrorCode = strFACOHD.Substring(1579,5);
			bool blSuccess = true;
			LBL_STATUS.Text = "Successfull.";
			if (strErrorCode.Trim()!="")
			{
				//conn.QueryString = "select * from RF_STW_LOS_ERROR where ERROR_CODE='"+ strErrorCode.Trim() +"'";
				conn.QueryString = "EXEC SP_SCORING_RF_STW_LOS_ERROR_GET '" + strErrorCode.Trim() + "'";
				conn.ExecuteQuery();
				if (conn.GetRowCount()!=0)
					LBL_STATUS.Text = conn.GetFieldValue(0,1);
				else
					LBL_STATUS.Text = "Undefined Error";
				blSuccess = false;
			}

			/* -- Kalau Ada Error Code dari FairIsaac
			 *    Non Aktif Tombol Update Status dan Print 
			if (blSuccess)
			{
				Button1.Enabled = true;
				updatestatus.Enabled = true;
			} 
			else
			{
				Button1.Enabled = false;
				updatestatus.Enabled = false;
			}
			*/

			// Overal Strategy Ware Decision
			OHD_SYS_DECISION = strHasil.Substring(258,2);             // 259 - 260 ( 2 char)
			if (OHD_SYS_DECISION.Trim()=="" && LBL_STATUS.Text == "Successfull.")
				LBL_STATUS.Text = "No DECISION.";

			string OHD_RULE_REASON_CODE = strHasil.Substring(297,40); // 298 - 337 ( 40 char)

			// cari Final Score , posisi sesuai dengan Excel
			strFACOSC = strHasil.Substring(intFACOSC-1,lenFACOSC);
			if (lenFACOSC!=0)
				OSC_FINAL_SCORE = CovFromEBCDIC(strFACOSC.Substring(19,4));
			else
				OSC_FINAL_SCORE = "0";
			
			// end cari Final Score
			
			Pos = startCalcPos;

			string FIACOAT = "";
			try
			{
				FIACOAT = strHasil.Substring(Pos,strHasil.Length-Pos);
			}
			catch{};

			string A1401 = "";
			string A1402 = "";
			string A1403 = ""; 
			string A1404 = ""; 
			string A1405 = ""; 
			string A1406 = ""; 
			string A1407 = ""; 
			string A1408 = ""; 
			string A1409 = ""; 
			string A1410 = "";  
			string A1411 = "";  
			string A1412 = "";  
			string A1413 = "";  
			string A1414 = "";  
			string A1415 = "";  
			string A1416 = "";  
			string A1417 = "";  
			string A1418 = "";  
			string A1419 = "";  
			string G0001 = "";  
			string G0002 = "";  
			string G0003 = "";  
			string G0004 = "";  
			string G0005 = "";  
			string G0006 = "";  
			string G0007 = "";  
			string G0008 = "";  
			string G0009 = "";  
			string G0010 = "";  
			string G0011 = "";  
			string G0012 = "";  
			string G0013 = "";  
			string G0014 = "";  
			string G0015 = "";  
			string G0016 = "";  
			string G0017 = "";  
			string G0018 = "";  
			string G0019 = "";  
			string G0020 = "";  
			string G0021 = "";  
			string G0022 = "";  
			string G0023 = "";  
			string G0024 = "";  
			string G0025 = "";  
			string G0026 = "";  
			string G0027 = "";  
			string G0028 = "";  
			string G0029 = "";  
			string G0030 = "";  
			string G0031 = "";  

			try
			{
				int intPos = 8;
				A1401 = FIACOAT.Substring(intPos,1);
				intPos = intPos + 1;
				A1402 = FIACOAT.Substring(intPos,1);
				intPos = intPos + 1;
				A1403 = FIACOAT.Substring(intPos,1);
				intPos = intPos + 1;
				A1404 = FIACOAT.Substring(intPos,1);
				intPos = intPos + 1;
				A1405 = FIACOAT.Substring(intPos,1);
				intPos = intPos + 1;
				A1406 = FIACOAT.Substring(intPos,2);
				intPos = intPos + 2;
				A1407 = FIACOAT.Substring(intPos,3);
				intPos = intPos + 3;
				A1408 = FIACOAT.Substring(intPos,3);
				intPos = intPos + 3;
				A1409 = FIACOAT.Substring(intPos,3);
				intPos = intPos + 3;
				A1410 = FIACOAT.Substring(intPos,3);
				intPos = intPos + 3;
				A1411 = FIACOAT.Substring(intPos,3);
				intPos = intPos + 3;
				A1412 = FIACOAT.Substring(intPos,3);
				intPos = intPos + 3;
				A1413 = FIACOAT.Substring(intPos,3);
				intPos = intPos + 3;
				A1414 = FIACOAT.Substring(intPos,3);
				intPos = intPos + 3;
				A1415 = FIACOAT.Substring(intPos,3);
				intPos = intPos + 3;
				A1416 = FIACOAT.Substring(intPos,1);
				intPos = intPos + 1;
				A1417 = FIACOAT.Substring(intPos,1);
				intPos = intPos + 1;
				A1418 = FIACOAT.Substring(intPos,1);
				intPos = intPos + 1;
				A1419 = FIACOAT.Substring(intPos,3);
				intPos = intPos + 3;
				intPos = intPos + 60; // For Filler
				G0001 = CovFromEBCDIC(FIACOAT.Substring(intPos,3));
				intPos = intPos + 3;
				G0002 = FIACOAT.Substring(intPos,8);
				intPos = intPos + 8;
				G0003 = FIACOAT.Substring(intPos,8);
				intPos = intPos + 8;
				G0004 = FIACOAT.Substring(intPos,8);
				intPos = intPos + 8;
				G0005 = FIACOAT.Substring(intPos,8);
				intPos = intPos + 8;
				G0006 = FIACOAT.Substring(intPos,8);
				intPos = intPos + 8;
				G0007 = FIACOAT.Substring(intPos,8);
				intPos = intPos + 8;
				G0008 = FIACOAT.Substring(intPos,8);
				intPos = intPos + 8;
				G0009 = FIACOAT.Substring(intPos,8);
				intPos = intPos + 8;
				G0010 = FIACOAT.Substring(intPos,8);
				intPos = intPos + 8;			
				G0011 = FIACOAT.Substring(intPos,8);
				intPos = intPos + 8;			
				G0012 = FIACOAT.Substring(intPos,8);
				intPos = intPos + 8;			
				G0013 = FIACOAT.Substring(intPos,8);
				intPos = intPos + 8;			
				G0014 = FIACOAT.Substring(intPos,8);
				intPos = intPos + 8;			
				G0015 = FIACOAT.Substring(intPos,8);
				intPos = intPos + 8;			
				G0016 = FIACOAT.Substring(intPos,8);
				intPos = intPos + 8;			
				G0017 = FIACOAT.Substring(intPos,8);
				intPos = intPos + 8;			
				G0018 = FIACOAT.Substring(intPos,8);
				intPos = intPos + 8;			
				G0019 = FIACOAT.Substring(intPos,8);
				intPos = intPos + 8;			
				G0020 = FIACOAT.Substring(intPos,8);
				intPos = intPos + 8;			
				G0021 = CovFromEBCDIC(FIACOAT.Substring(intPos,7));
				intPos = intPos + 7;
				intPos = intPos + 1; // Filler
				G0022 = FIACOAT.Substring(intPos,8);
				intPos = intPos + 8;			
				G0023 = FIACOAT.Substring(intPos,8);
				intPos = intPos + 8;			
				G0024 = FIACOAT.Substring(intPos,8);
				intPos = intPos + 8;			
				G0025 = FIACOAT.Substring(intPos,8);
				intPos = intPos + 8;			
				G0026 = FIACOAT.Substring(intPos,8);
				intPos = intPos + 8;			
				G0027 = FIACOAT.Substring(intPos,8);
				intPos = intPos + 8;			
				G0028 = FIACOAT.Substring(intPos,8);
				intPos = intPos + 8;			
				G0029 = FIACOAT.Substring(intPos,8);
				intPos = intPos + 8;			
				G0030 = FIACOAT.Substring(intPos,8);
				intPos = intPos + 8;			
				G0031 = FIACOAT.Substring(intPos,8);
			} 
			catch{};

			string strSQL = "";

			conn.QueryString = "delete scoring_response_tbl where sumberdata='FINALSCORING' and ap_regno='"+ strRegno +"'";
			conn.ExecuteNonQuery();
			
			strSQL = "insert into scoring_response_tbl "+
				"( AP_REGNO, A1401, A1402, A1403, A1404, "+
				" A1405, A1406, A1407, A1408, A1409, "+
				" A1410, A1411, A1412, A1413, A1414, "+
				" A1415, A1416, A1417, A1418, A1419, "+
				" G0001, G0002, G0003, G0004, G0005, "+
				" G0006, G0007, G0008, G0009, G0010, "+
				" G0011, G0012, G0013, G0014, G0015, "+
				" G0016, G0017, G0018, G0019, G0020, "+
				" G0021, G0022, G0023, G0024, G0025, "+
				" G0026, G0027, G0028, G0029, G0030, "+
				" G0031, OHD_SYS_DECISION, OSC_FINAL_SCORE,SUMBERDATA) values "+
				" ( '"+ strRegno +"','"+ A1401 + "','"+ A1402 +"','"+ A1403 +"','"+ A1404 +"','" +
				A1405 +"','"+ A1406+"',"+ toZerro(A1407)+","+toZerro(A1408)+","+toZerro(A1409)+","+
				toZerro(A1410) +","+ toZerro(A1411) +","+ toZerro(A1412) +","+ toZerro(A1413) +","+ toZerro(A1414) +","+ 
				toZerro(A1415) +",'"+ A1416 +"','"+ A1417 +"','"+ A1418 +"',"+ toZerro(A1419) +","+ 
				toZerro(G0001) +","+ toZerro(G0002) +","+ toZerro(G0003) +","+ toZerro(G0004) +","+ toZerro(G0005) +","+ 
				toZerro(G0006) +","+ toZerro(G0007) +","+ toZerro(G0008) +","+ toZerro(G0009) +","+ toZerro(G0010) +","+ 
				toZerro(G0011) +","+ toZerro(G0012) +","+ toZerro(G0013) +","+ toZerro(G0014) +","+ toZerro(G0015) +","+ 
				toZerro(G0016) +","+ toZerro(G0017) +","+ toZerro(G0018) +","+ toZerro(G0019) +","+ toZerro(G0020) +","+ 
				toZerro(G0021) +","+ toZerro(G0022) +","+ toZerro(G0023) +","+ toZerro(G0024) +","+ toZerro(G0025) +","+ 
				toZerro(G0026) +","+ toZerro(G0027) +","+ toZerro(G0028) +","+ toZerro(G0029) +","+ toZerro(G0030) +","+ 
				toZerro(G0031) +",'" + OHD_SYS_DECISION + "'," + toZerro(OSC_FINAL_SCORE) + ",'FINALSCORING')";
			 
			conn.QueryString = strSQL;
			conn.ExecuteNonQuery();

			string strTemp = "";
			conn.QueryString = "delete OHD_RULE_REASON_CODE where sumberdata='FINALSCORING' and ap_regno='"+ strRegno +"'";
			conn.ExecuteNonQuery();
			for (int i=0; i<20; i+=2)
			{
				strTemp = "";
				strTemp = OHD_RULE_REASON_CODE.Substring(i,2);
				if (strTemp.Trim()!="")
				{ 					
					try 
					{
						conn.QueryString = "insert into OHD_RULE_REASON_CODE values ('"+ strRegno +"','"+ strTemp +"','FINALSCORING')";
						conn.ExecuteNonQuery();
					} 
					catch {}
				}
			}	
		
			// -- start -- ashari 20041212 hapus scoring_message
			// yudi : dicomment karena .... ga tahu :) (diminta chengkl sih)
//			conn.QueryString="delete from scoring_response where received='0' and ap_regno like '%"+ strRegno +"%'";
//			conn.ExecuteQuery();
			// -- end -- ashari 20041212 hapus scoring_message
			
			return 1;
		}


		//Fungsi ini melakukan konversi balik dari sign number (EBCDIC) ke bilangan aslinya
		String CovFromEBCDIC(string strTemp)
		{
			string strX;
			//double dblX;
			strX=strTemp;
			//dblX = Convert.ToDouble(strTemp);

			if(strX.Substring(strX.Length-1,1).Equals("{"))
				strX=strX.Substring(0,strX.Length-1)+"0";
			else if (strX.Substring(strX.Length-1,1).Equals("A"))
				strX=strX.Substring(0,strX.Length-1)+"1";
			else if (strX.Substring(strX.Length-1,1).Equals("B"))
				strX=strX.Substring(0,strX.Length-1)+"2";
			else if (strX.Substring(strX.Length-1,1).Equals("C"))
				strX=strX.Substring(0,strX.Length-1)+"3";
			else if (strX.Substring(strX.Length-1,1).Equals("D"))
				strX=strX.Substring(0,strX.Length-1)+"4";
			else if (strX.Substring(strX.Length-1,1).Equals("E"))
				strX=strX.Substring(0,strX.Length-1)+"5";
			else if (strX.Substring(strX.Length-1,1).Equals("F"))
				strX=strX.Substring(0,strX.Length-1)+"6";
			else if (strX.Substring(strX.Length-1,1).Equals("G"))
				strX=strX.Substring(0,strX.Length-1)+"7";
			else if (strX.Substring(strX.Length-1,1).Equals("H"))
				strX=strX.Substring(0,strX.Length-1)+"8";
			else if (strX.Substring(strX.Length-1,1).Equals("I"))
				strX=strX.Substring(0,strX.Length-1)+"9";
			else if(strX.Substring(strX.Length-1,1).Equals("}"))
				strX="-"+strX.Substring(0,strX.Length-1)+"}";
			else if (strX.Substring(strX.Length-1,1).Equals("J"))
				strX="-"+strX.Substring(0,strX.Length-1)+"1";
			else if (strX.Substring(strX.Length-1,1).Equals("K"))
				strX="-"+strX.Substring(0,strX.Length-1)+"2";
			else if (strX.Substring(strX.Length-1,1).Equals("L"))
				strX="-"+strX.Substring(0,strX.Length-1)+"3";
			else if (strX.Substring(strX.Length-1,1).Equals("M"))
				strX="-"+strX.Substring(0,strX.Length-1)+"4";
			else if (strX.Substring(strX.Length-1,1).Equals("N"))
				strX="-"+strX.Substring(0,strX.Length-1)+"5";
			else if (strX.Substring(strX.Length-1,1).Equals("O"))
				strX="-"+strX.Substring(0,strX.Length-1)+"6";
			else if (strX.Substring(strX.Length-1,1).Equals("P"))
				strX="-"+strX.Substring(0,strX.Length-1)+"7";
			else if (strX.Substring(strX.Length-1,1).Equals("Q"))
				strX="-"+strX.Substring(0,strX.Length-1)+"8";
			else if (strX.Substring(strX.Length-1,1).Equals("R"))
				strX="-"+strX.Substring(0,strX.Length-1)+"9";

			return strX;
		}


		//Procedure ini mengisikan nilai nol ke semua label sbg nilai inisialisasi
		private void fillZero()
		{
			LBL_A1401.Text = "";
			LBL_A1401_HIDEN.Text = "";
			LBL_A1402.Text =  "";
			LBL_A1403.Text =  "";
			LBL_A1404.Text =  "";
			LBL_A1405.Text =  "0";
			LBL_A1405A.Text=  "0";
			LBL_A1407.Text =  "0";
			LBL_A1408.Text =  "0";
			LBL_A1409.Text =  "0";
			LBL_A1410.Text =  "0";
			LBL_A1411.Text =  "0";
			LBL_A1412.Text =  "0";
			LBL_A1413.Text =  "0";
			LBL_A1414.Text =  "0";
			LBL_A1415.Text =  "0";
			LBL_A1419.Text =  "0";

			LBL_G0001.Text = "0";
			LBL_G0002.Text = "0";
			LBL_G0002A.Text= "0";
			LBL_G0003.Text = "0";
			LBL_G0004.Text = "0";
			LBL_G0005.Text = "0";
			LBL_G0006.Text = "0";
			LBL_G0007.Text = "0";
			LBL_G0008.Text = "0";
			LBL_G0009.Text = "0";
			LBL_G0010.Text = "0";
			LBL_G0011.Text = "0";
			LBL_G0011A.Text= "0";
			LBL_G0012.Text = "0";
			LBL_G0013.Text = "0";
			LBL_G0014.Text = "0";
			LBL_G0015.Text = "0";
			LBL_G0016.Text = "0";
			LBL_G0017.Text = "0";
			LBL_G0018.Text = "0";
			LBL_G0019.Text = "0";
			LBL_G0020.Text = "0";
			LBL_G0021.Text = "0";
			LBL_G0022.Text = "0";
			LBL_G0023.Text = "0";
			LBL_G0024.Text = "0";
			LBL_G0025.Text = "0";
			LBL_G0026.Text = "0";
			LBL_G0027.Text = "0";
			LBL_G0028.Text = "0";
			LBL_G0029.Text = "0";
			LBL_G0030.Text = "0";
			LBL_G0031.Text = "0";
			OSC_FINAL_SCORE.Text  = "";
			LBL_OHD_SYS_DECISION.Text = "";
		}
		
		//Fungsi ini menambahkan nilai "0" di depan strTmp shg length dari strTmp menjadi intJml
		String Pjg(string strTmp,int intJml)
		{
			for(int i=0;i<=intJml;i++)
			{
				if (i>strTmp.Length)
				{
					strTmp="0"+strTmp;
				}
			}
			return strTmp;
		}


		String IsiBlank(int intJml)
		{
			String strTmp="";
			for(int i=0;i<intJml;i++)
			{
				strTmp=strTmp+ " ";
			}
			return strTmp;
		}

		//Fungsi ini melakukan setting nilai kosong menjadi null
		string toZerro(string par)
		{
			if (par.Trim()=="")
				return "0";
			else
			{
				try
				{
					float.Parse(par);
					return par;
				} 
				catch
				{return "0";}
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

		//Fungsi ini menampilkan descripsi dari kode hasil scoring yang diterima dari strategy ware
		private string getScoringResultDesc(string stw_type,string stw_code)
		{
			Connection conn2 = new Connection(conn.connString);
			string scoringResultDesc="";
			conn2.QueryString="EXEC SP_SCORING_RESULT_DESC_GET '" + stw_type + "','" + stw_code + "'";
			conn2.ExecuteQuery();
			if (conn2.GetFieldValue("STW_DESC").Trim()!="")
			{
				scoringResultDesc= stw_code + " - " + conn2.GetFieldValue("STW_DESC");
			}
			else
			{
				if (stw_code.Trim()!="")
				{
					scoringResultDesc= stw_code + " - Undefined";
				}
				else
				{
					scoringResultDesc="";
				}
			}
			conn2.ClearData();
			conn2.CloseConnection();
			return scoringResultDesc;
		}



		//Procedure ini melakukan pemilihan pengaktifan tombol AIP Letter atau Reject Letter
		private void statusButton()
		{
			Button1.Enabled = true;
			if (LBL_OHD_SYS_DECISION_HIDDEN.Text == "AC")
				Button1.Text = "Print AIP Letter";
			else if (LBL_OHD_SYS_DECISION_HIDDEN.Text == "DL")
				Button1.Text = "Print Reject Letter";
			else if (LBL_OHD_SYS_DECISION_HIDDEN.Text== "GZ")	//--- Grey Zone
			{
				Button1.Text = "Print Reject Letter";
				
				if (isLowLine()) 
				{
					Button1.Text = "Print Reject Letter";
				}
				else 
				{
					Button1.Text = "Print AIP Letter";
				}				
			} 
			else {Button1.Enabled = false;}
		}

		protected void Button2_Click(object sender, System.EventArgs e)
		{  // Retrieve Response
			if(Convert.ToInt32(lblCounter.Text)<2)
			{
				
				if ((UploadResponse()) == 1 ) 
				{
					updatestatus.Enabled=true;
					///	 --start -- by ashari 20041227
					//	panggil fungsi setFICounter dari class clsFICounter 
						SME.Scoring.clsFICounter objFICounter = new SME.Scoring.clsFICounter(conn, (string)Request.QueryString["regno"], (string)Request.QueryString["curef"]);
						objFICounter.setFICounter("FS","RCV");
					//	 --end -- by ashari 20041227
					viewData();
				}
				lblCounter.Text=Convert.ToString(Convert.ToInt32(lblCounter.Text)+1);
				if (lblCounter.Text=="2")
				{
					BTN_SEND_ULANG.Enabled=true;
					Button2.Enabled=false;
				}
				
			}
		}

		protected void BTN_BACK_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			if (Request.QueryString["tc"] != null && Request.QueryString["tc"] != "") 
			{
				Response.Redirect("/SME/" + DMS.CuBESCore.Logic.backLink(Request.QueryString["tc"].ToString(), conn));
			} 
			else if (Request.QueryString["mc"] != null && Request.QueryString["mc"] != "") 
			{
				Response.Redirect("/SME/" + backLinkLocal(Request.QueryString["mc"]));
			}
			else 
			{
				// do nothing !!
			}
		}

//		private void btn_Print_Click(object sender, System.EventArgs e)
//		{
//			Response.Redirect("ScoringPrint.aspx?regno="+Request.QueryString["regno"]);
//		}

	}
}
