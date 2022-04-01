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

namespace SME.VerificationAssignment
{
	/// <summary>
	/// Summary description for ListAssignment. Created By Noerrr.....
	/// </summary>
	public partial class ListAssignment : System.Web.UI.Page
	{
		protected Tools tool = new Tools();
		protected Connection conn;
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			conn = (Connection) Session["Connection"];

			string tc = "";//,mi = "";//, si = "";
			try 
			{
				tc = Request.QueryString["tc"];
				//mi = Request.QueryString["mi"];
				//si = Request.QueryString["si"]asdsadsasdaas;
			} 
			catch {}
			
			if (!IsPostBack)
			{
				Tools.initDateForm(txt_Date, ddl_Month, txt_Year, true);
				txt_Date.Text = "";
				txt_Year.Text = "";
				Tools.initDateForm(txt_Date1, ddl_Month1, txt_Year1, true);
				txt_Date1.Text = "";
				txt_Year1.Text = "";

				DataTable DTBO = new DataTable();
				DatGrd.DataSource = new DataView(DTBO);

				DatGrd.DataBind();
				bindData();

			}
			
			DatGrd.PageIndexChanged += new DataGridPageChangedEventHandler(this.Grid_Change);
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
			this.DatGrd.ItemCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.DatGrd_ItemCommand);

		}
		#endregion
		
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

		private void bindData()
		{
			System.Web.UI.WebControls.Image ImgAppr, ImgBI, ImgSiteVisit, ImgIsAppeal;
			DataTable dt = new DataTable();

			//conn.QueryString = "select * from VW_VER_ASSIGNMENTLIST where ap_currtrack='" + Request.QueryString["tc"] + "'";
			conn.QueryString = "select * from VW_VER_ASSIGNMENTLIST where ap_currtrack='" + Request.QueryString["tc"] + "' and cu_rm='" + Session["UserID"].ToString() + "' " + this.LBL_SQLFIND.Text.Trim();
			try 
			{
				conn.ExecuteQuery();
			} 
			catch  (ApplicationException)
			{
				GlobalTools.popMessage(this, "Input tidak valid !");
				return;
			}
			catch (NullReferenceException) 
			{
				GlobalTools.popMessage(this, "Server Error !");
				return;
			}
			dt = conn.GetDataTable().Copy();
			DatGrd.DataSource = dt;
			DatGrd.DataBind();
			for (int i = 0; i < DatGrd.Items.Count; i++)
			{
				DatGrd.Items[i].Cells[3].Text = tool.FormatDate(DatGrd.Items[i].Cells[3].Text, true);
				ImgAppr	= (System.Web.UI.WebControls.Image) DatGrd.Items[i].Cells[6].FindControl("IMG_LA_APPRSTATUS"); 
				ImgBI	= (System.Web.UI.WebControls.Image) DatGrd.Items[i].Cells[9].FindControl("IMG_BS_COMPLETE");
				ImgSiteVisit = (System.Web.UI.WebControls.Image) DatGrd.Items[i].Cells[11].FindControl("IMG_AP_SITEVISITSTA");
				ImgIsAppeal = (System.Web.UI.WebControls.Image) DatGrd.Items[i].Cells[13].FindControl("IMG_AP_ISAPPEAL");				
				Label LblAppr	= (Label) DatGrd.Items[i].Cells[6].FindControl("LBL_LA_APPRSTATUS");
				Label LblBI		= (Label) DatGrd.Items[i].Cells[9].FindControl("LBL_BS_COMPLETE");
				Label LblSite	= (Label) DatGrd.Items[i].Cells[9].FindControl("LBL_AP_SITEVISITSTA");
				Label LblIsAppeal	= (Label) DatGrd.Items[i].Cells[13].FindControl("LBL_AP_ISAPPEAL");				
				LinkButton LbUpdate = (LinkButton) DatGrd.Items[i].Cells[10].FindControl("LB_UPDATESTATUS");

				string StaAppr = "0", StaBI = "0";
				//------- column AP_ISAPPEAL (hidden) -------------
				if (DatGrd.Items[i].Cells[12].Text == "1") 
				{
					try 
					{ // oleh Gatot -- OK
						conn.QueryString = "SELECT AP_ISAPPEALDATE FROM APPLICATION";
						conn.QueryString += " WHERE AP_REGNO = '" + DatGrd.Items[i].Cells[0].Text + "'";
						conn.ExecuteQuery();
						//Response.Write(conn.QueryString);

						string appealdate = conn.GetFieldValue("AP_ISAPPEALDATE");
						if ((appealdate != "") && (appealdate != null))
						{ // jika tanggal tidak NULL dan bukan "", tampilkan tanggal berformat dd/mm/yyyy
							LblIsAppeal.Text =  tool.FormatDate_GetDate(appealdate);
						}
						else 
						{
							LblIsAppeal.Text = "Yes";
						}
						ImgIsAppeal.ImageUrl = "../image/Complete.gif";
					}
					catch (NullReferenceException) 
					{
						GlobalTools.popMessage(this, "Server Error !");
						return;
					}
				}
				else 
				{
					LblIsAppeal.Text = "No";
					ImgIsAppeal.ImageUrl = "../image/UnComplete.gif";
				}
				//--------------------------------------------------

				//--- modif by Yudi
				//Bandingkan collateral di appraisal assignment dengan collateral di struktur kredit
				//Cari di LISTASSIGNMENT yang LA_APPRSTATUS = '3'
				//Bandingkan dengan collateral di LISTCOLLATERAL dan COLLATERAL
				if (DatGrd.Items[i].Cells[5].Text == "1")
				{ 
					// AP_APPRSTATUS di baris datagrid cells[5]
					try
					{
						// get appraisal status per application
						conn.QueryString = "exec VA_APPR_COLL_GETSTATUS '" + 
							DatGrd.Items[i].Cells[0].Text + "', '" + 
							DatGrd.Items[i].Cells[1].Text + "'";
						conn.ExecuteQuery();
						
						// get the latest appraisal-complete date
						LblAppr.Text = conn.GetFieldValue("APPR_COMPLETEDATE");

						// get appraisal-complete status
						if (conn.GetFieldValue("APPR_COMPLETE") == "1") 
						{							
							ImgAppr.ImageUrl = "../image/Complete.gif";
							StaAppr = "1";
						}
						else 
						{
							ImgAppr.ImageUrl = "../image/UnComplete.gif";
							StaAppr = "0";
						}

						/**
						conn.QueryString = "SELECT MAX(LA_COMPLETEDATE) AS COMPLETEDATE FROM LISTASSIGNMENT";
						conn.QueryString += " WHERE AP_REGNO ='" + DatGrd.Items[i].Cells[0].Text +"'";
						conn.QueryString += " and CU_REF='" + DatGrd.Items[i].Cells[1].Text + "'";
						conn.ExecuteQuery();
						string completeDate = conn.GetFieldValue("COMPLETEDATE");
						if ((completeDate != "") && (completeDate != null))
						{ // jika tanggal tidak null maka ditampilkan
							LblAppr.Text = tool.FormatDate_GetDate(completeDate);
						}
						else
						{ // jika tanggal LA_COMPLETEDATE belum diset maka diberi pesan "NotSet"
							LblAppr.Text = "Complete"; // tanggal belum tersimpan di database
						}
						ImgAppr.ImageUrl = "../image/Complete.gif";
						StaAppr = "1";
						**/
					}
					catch(NullReferenceException)
					{
						GlobalTools.popMessage(this,"Server error");
						return;
					}
				}
				else
				{
					if (DatGrd.Items[i].Cells[5].Text == "2") 
					{  // AP_APPRSTATUS = 2 ?
						LblAppr.Text = "Pending by CO";
						ImgAppr.ImageUrl = "../image/UnComplete.gif";
					}
					else 
					{  // AP_APPRSTATUS != 1
						conn.QueryString = "select * from VW_VER_APPRAISALSTATUS " + 
							"where AP_REGNO ='" + DatGrd.Items[i].Cells[0].Text +
							"' and CU_REF='" + DatGrd.Items[i].Cells[1].Text + "'";
						conn.ExecuteQuery();

						if (conn.GetRowCount() == 1) 
						{ // jika hanya ada satu appraisal
							if (conn.GetFieldValue("LA_APPRSTATUS") == "3") 
							{
								conn.QueryString = "SELECT MAX(LA_COMPLETEDATE) AS COMPLETEDATE FROM LISTASSIGNMENT";
								conn.QueryString += " WHERE AP_REGNO ='" + DatGrd.Items[i].Cells[0].Text +"'";
								conn.QueryString += " and CU_REF='" + DatGrd.Items[i].Cells[1].Text + "'";
								conn.ExecuteQuery();
								//Response.Write(conn.QueryString+"<BR>");
								string completeDate = conn.GetFieldValue("COMPLETEDATE");
								if ((completeDate != "") && (completeDate != null)) LblAppr.Text = tool.FormatDate_GetDate(completeDate);
								else LblAppr.Text = "Complete";
								ImgAppr.ImageUrl = "../image/Complete.gif";
								StaAppr = "1";
								//TODO : Apakah perlu diset APPLICATION(AP_APPRSTATUS) menjadi 1 ???
								//....
							}
							else 
							{
								conn.QueryString = "SELECT MIN(LA_ASSIGNDATE) AS ASSIGNDATE FROM LISTASSIGNMENT";
								conn.QueryString += " WHERE AP_REGNO ='" + DatGrd.Items[i].Cells[0].Text +"'";
								conn.QueryString += " and CU_REF='" + DatGrd.Items[i].Cells[1].Text + "'";
								conn.QueryString += " and LA_APPRTYPE <> 2";
								conn.ExecuteQuery();
								string assignDate = conn.GetFieldValue("ASSIGNDATE");
								if ((assignDate != "") && (assignDate != null)) 
								{
									LblAppr.Text = tool.FormatDate_GetDate(assignDate);
								}
								else LblAppr.Text = "Incomplete";
								ImgAppr.ImageUrl = "../image/UnComplete.gif";
							}
						}
						else if (conn.GetRowCount() == 0)
						{	// tidak ada jaminan yang harus diappraise sehingga status appraisal = Complete
							// tombol Update Status harus muncul
							LblAppr.Text = "Complete";
							ImgAppr.ImageUrl = "../image/Complete.gif";
							StaAppr = "1";
						} 
						else
						{	// ada beberapa yang perlu diappraise
							//Response.Write("AP_APPRSTATUS["+i+"] = 0 more than 1 appraisal<BR>");
							conn.QueryString = "SELECT MIN(LA_ASSIGNDATE) AS ASSIGNDATE FROM LISTASSIGNMENT";
							conn.QueryString += " WHERE AP_REGNO ='" + DatGrd.Items[i].Cells[0].Text +"'";
							conn.QueryString += " and CU_REF='" + DatGrd.Items[i].Cells[1].Text + "'";
							conn.QueryString += " and LA_APPRTYPE <> 2";
							//conn.QueryString += " and LA_ASSIGNDATE <>3";
							conn.ExecuteQuery();

							string assignDate = conn.GetFieldValue("ASSIGNDATE");
							if ((assignDate != "") && (assignDate != null)) 
							{
								LblAppr.Text = tool.FormatDate_GetDate(assignDate);
							}
							else LblAppr.Text = "Incomplete";
							ImgAppr.ImageUrl = "../image/UnComplete.gif";
						}
					}
				}

				//status BI
				conn.QueryString = "select count(*) from BI_STATUS where AP_REGNO = '"+DatGrd.Items[i].Cells[0].Text+"' and CU_REF = '"+DatGrd.Items[i].Cells[1].Text+"'";
				conn.ExecuteQuery();
				//if (DatGrd.Items[i].Cells[7].Text == "1")
				if (conn.GetFieldValue(0,0).ToString() != "0")
				{
					if (DatGrd.Items[i].Cells[8].Text == "2")
					{
						try
						{
							conn.QueryString = "SELECT BS_VALIDDATE FROM BI_STATUS";
							conn.QueryString += " WHERE AP_REGNO = '"+DatGrd.Items[i].Cells[0].Text+"' and CU_REF = '"+DatGrd.Items[i].Cells[1].Text+"'";
							conn.ExecuteQuery();
						
							string validdate = conn.GetFieldValue("BS_VALIDDATE").ToString();
							if ((validdate != "") && (validdate != null))
							{// mengisi VALIDDATE
								LblBI.Text = tool.FormatDate_GetDate(validdate); // menampilkan tanggal berformat dd/mm/yyyy
							}
							else 
							{
								LblBI.Text = "Complete";
							}
							ImgBI.ImageUrl = "../image/Complete.gif";
							StaBI = "1";
						}
						catch(NullReferenceException)
						{
							GlobalTools.popMessage(this,"Server error");
						}
					}
					else
					{
						try 
						{
							conn.QueryString = "SELECT BS_REQDATE FROM BI_STATUS";
							conn.QueryString += " WHERE AP_REGNO = '"+DatGrd.Items[i].Cells[0].Text+"' and CU_REF = '"+DatGrd.Items[i].Cells[1].Text+"'";
							conn.ExecuteQuery();
						
							string reqdate = conn.GetFieldValue("BS_REQDATE").ToString();
							//Response.Write("<script language='javascript'>alert('Tes"+reqdate+"');</script>");
							if ((reqdate != "") && (reqdate != null))
							{// mengisi REQUESTDATE
								LblBI.Text = tool.FormatDate_GetDate(reqdate); // menampilkan tanggal berformat dd/mm/yyyy
							}
							else
							{
								LblBI.Text = "Incomplete";
							}
							ImgBI.ImageUrl = "../image/UnComplete.gif";
						}
						catch(NullReferenceException)
						{
							GlobalTools.popMessage(this,"Server error");
						}
					}
				}
				else
				{ // count (*) == 0
					try
					{
						/****************************************************************************************
						 * Due to the missing record in BI_STATUS, in order not to let the app pending in VA,
						 * consider it as completed
						 * */
						conn.QueryString = "SELECT BS_VALIDDATE FROM BI_STATUS";
						conn.QueryString += " WHERE AP_REGNO = '"+DatGrd.Items[i].Cells[0].Text+"' and CU_REF = '"+DatGrd.Items[i].Cells[1].Text+"'";
						conn.ExecuteQuery();
						
						string validdate = conn.GetFieldValue("BS_VALIDDATE").ToString();
						//Response.Write("<script language='javascript'>alert('Tes"+validdate+"');</script>");
						if ((validdate != "") && (validdate != null))
						{// mengisi VALIDDATE
							LblBI.Text = tool.FormatDate_GetDate(validdate);
						}
						else 
						{
							LblBI.Text = "Complete";
						}
						ImgBI.ImageUrl = "../image/Complete.gif";
						StaBI = "1";
						
						/*
						conn.QueryString = "SELECT ISNULL(AP_CHECKBI,0) AS AP_CHECKBI FROM APPLICATION " +
							"WHERE AP_REGNO = '"+DatGrd.Items[i].Cells[0].Text+
							"' AND CU_REF = '"+DatGrd.Items[i].Cells[1].Text+"'";
						conn.ExecuteQuery();
						if (conn.GetFieldValue("AP_CHECKBI") == "0")
						{
							StaBI = "1";
							LblBI.Text = "Complete";
							ImgBI.ImageUrl = "../image/Complete.gif";
						}
						else
						{
							StaBI = "0";
							ImgBI.ImageUrl = "../image/UnComplete.gif";
							LblBI.Text = "Incomplete";
						}
						*/
					}
					catch(NullReferenceException)
					{
						GlobalTools.popMessage(this,"Server error");
					}
				}

				// Site Visit
				// tentukan dulu middle atau small
				conn.QueryString = "select in_small, in_middle, in_corporate from rfinitial";
				conn.ExecuteQuery();
					 
				string m_in_small = conn.GetFieldValue("in_small");
				string m_in_middle = conn.GetFieldValue("in_middle");
				string m_in_corp = conn.GetFieldValue("in_corporate");

				conn.QueryString = "select isnull(AP_ISAPPEAL,0), AP_COMPLEVEL ";
				conn.QueryString += "from APPLICATION ";
				conn.QueryString += "where AP_REGNO = '" + DatGrd.Items[i].Cells[0].Text + "'";
				conn.ExecuteQuery();
			
				string szCpLvl = conn.GetFieldValue("AP_COMPLEVEL");			
				bool isSmall = false;

				if(szCpLvl == m_in_small) 
					isSmall = true; // usernya adalah SMALL
				else if(szCpLvl == m_in_middle)
					isSmall = false; // usernya adalah MIDDLE
				else if(szCpLvl == m_in_corp)
					isSmall = false; // usernya adalah Corporate

				if (DatGrd.Items[i].Cells[10].Text == "1")
				{
					string completeDate = "";
					if (!isSmall)
					{ // middle user
						conn.QueryString = "SELECT SV_TARGETDATE FROM CUST_SITEVISIT ";
						conn.QueryString += "WHERE AP_REGNO = '" + DatGrd.Items[i].Cells[0].Text + "' and ";
						conn.QueryString += "CU_REF = '" + DatGrd.Items[i].Cells[1].Text + "'";
						conn.ExecuteQuery();
						//Response.Write(conn.QueryString + "<BR>");
						completeDate = conn.GetFieldValue("SV_TARGETDATE").ToString();
					} 
					else
					{ // small user
						conn.QueryString = "SELECT TARGETSELESAI FROM LKKN ";
						conn.QueryString += "WHERE AP_REGNO ='" + DatGrd.Items[i].Cells[0].Text + "'";
						//conn.QueryString += " CU_REF = '" + DatGrd.Items[i].Cells[1].Text + "'";
						//Response.Write(conn.QueryString + "<BR>");
						conn.ExecuteQuery();
						completeDate = conn.GetFieldValue("TARGETSELESAI").ToString();
					}
					if ((completeDate != "") && (completeDate != null)) 
						LblSite.Text = tool.FormatDate_GetDate(completeDate);
					else LblSite.Text = "Done";
					
					ImgSiteVisit.ImageUrl = "../image/Complete.gif";
				}
				else
				{ // sitevisit = 0, tampilkan visit date
					string visitDate = "";
					if (!isSmall)
					{ // middle user
						conn.QueryString = "SELECT SV_DATE FROM CUST_SITEVISIT ";
						conn.QueryString += "WHERE AP_REGNO = '" + DatGrd.Items[i].Cells[0].Text + "' and ";
						conn.QueryString += "CU_REF = '" + DatGrd.Items[i].Cells[1].Text + "'";
						//Response.Write(conn.QueryString + "<BR>");
						conn.ExecuteQuery();
						visitDate = conn.GetFieldValue("SV_DATE").ToString();
					} 
					else
					{ // small user
						conn.QueryString = "SELECT VISITDATE FROM LKKN";
						conn.QueryString += " WHERE AP_REGNO ='" + DatGrd.Items[i].Cells[0].Text + "'";
						//conn.QueryString += " CU_REF = '" + DatGrd.Items[i].Cells[1].Text + "'";
						//Response.Write(conn.QueryString + "<BR>");
						conn.ExecuteQuery();
						visitDate = conn.GetFieldValue("VISITDATE").ToString();
					}
					
					if ((visitDate != "") && (visitDate != null)) 
						LblSite.Text = tool.FormatDate_GetDate(visitDate);
					else LblSite.Text = "In Process";
					ImgSiteVisit.ImageUrl = "../image/UnComplete.gif";
				}				

				//Update Status Button
				//LbUpdate.Attributes.Add("onclick","if(!update()) { return false; };");
				LbUpdate.Attributes.Add("onclick","if(!updateMsgC()) { return false; };");

				if (StaAppr == "1" && StaBI == "1")
					LbUpdate.Visible = true;
				else
					LbUpdate.Visible = false;
			}
		}

		void Grid_Change(Object sender, DataGridPageChangedEventArgs e) 
		{
			DatGrd.CurrentPageIndex = e.NewPageIndex;
			bindData();	
		}

		private void DatGrd_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			switch(((LinkButton)e.CommandSource).CommandName)
			{
				case "View":								
					string tc = (string) Request.QueryString["tc"];
					Response.Redirect("MainVerificationAssignment.aspx?regno=" + e.Item.Cells[0].Text + "&curef=" + e.Item.Cells[1].Text+ "&tc="+tc + "&mc=" + Request.QueryString["mc"]);
					break;
				case "UpdateStatus":								
					bool STAUPDATE = true;

					//Check Mandatory
					try
					{
						conn.QueryString = "EXEC VERASSIGN_CHECKMANDATORY '" + e.Item.Cells[0].Text + "'";
						conn.ExecuteQuery();
					}
					catch (Exception ex)
					{
						string errmsg = ex.Message.Replace("'","");
						if (errmsg.IndexOf("Last Query:") > 0)
							errmsg = errmsg.Substring(0, errmsg.IndexOf("Last Query:"));
						GlobalTools.popMessage(this, errmsg);
						STAUPDATE = false;
						return;
					}
					if (conn.GetRowCount() != 0)
					{
						if (conn.GetFieldValue("CHECKSTATUS") != "1")
						{
							STAUPDATE = false;
							return;
						}
					}
					else
					{
						STAUPDATE = false;
						return;
					}

					////////////////////////////////////////////////////////////////////////////////////////////
					/// Cek Total Exposure untuk existing facilities
					/// 
					if (STAUPDATE) 
					{
						conn.QueryString = "exec SCORING_CEKTOTALEXPOSURE '" + e.Item.Cells[0].Text + "'";
						conn.ExecuteQuery();
						if (conn.GetFieldValue("totalExposureIsValid") == "0") 
						{
							STAUPDATE = false;
							GlobalTools.popMessage(this, conn.GetFieldValue("errorMessage"));
						}
					}
					////////////////////////////////////////////////////////////////////////////////////////////

					if (STAUPDATE)
					{

						DataTable dt;
						conn.QueryString = "select apptype, productid, prod_seq from custproduct where ap_regno='" + e.Item.Cells[0].Text +
							"' AND isnull(cp_reject,'0') <> '1' and isnull(cp_cancel,'0') <> '1'";
						conn.ExecuteQuery();
						dt = conn.GetDataTable().Copy();
						for (int i = 0; i < dt.Rows.Count; i++)
						{
							// exec trackupdate
							conn.QueryString = "exec TRACKUPDATE '" + 
								e.Item.Cells[0].Text + "', '" +			// AP_REGNO
								dt.Rows[i][1].ToString() + "', '" +		// PRODUCTID 
								dt.Rows[i][0].ToString() + "', '" +		// APPTYPE
								Session["UserID"].ToString() + "', '" +	// USERID
								dt.Rows[i]["prod_seq"].ToString() + "','"+Request.QueryString["tc"].Trim()+"'";// PROD_SEQ -- CURRENT TRACK
								
							conn.ExecuteNonQuery();
						}

						GlobalTools.popMessage(this, getNextStepMsg(e.Item.Cells[0].Text));

						bindData();
					}
					break;
				default:
					break;
			}
		}

		protected void btn_Find_Click(object sender, System.EventArgs e)
		{
			this.LBL_SQLFIND.Text = " AND (";
			string sjoin = this.RDB_COND.SelectedValue;
			
			try 
			{
				if (txt_IdCard.Text.Trim() != "")
					LBL_SQLFIND.Text = LBL_SQLFIND.Text + " CU_IDCARDNUM like '%" + txt_IdCard.Text.Trim() + "%' " + sjoin;
				if (txt_NPWP.Text.Trim() != "")
					LBL_SQLFIND.Text = LBL_SQLFIND.Text + " CU_NPWP like '%" + txt_NPWP.Text.Trim() + "%' " + sjoin;
				if (txt_Name.Text.Trim() != "")
					LBL_SQLFIND.Text = LBL_SQLFIND.Text + " CU_NAME like '%" + txt_Name.Text.Trim() + "%' " + sjoin;
				if (txt_ProsID.Text.Trim() != "")
					LBL_SQLFIND.Text = LBL_SQLFIND.Text + " AP_REGNO like '%" + txt_ProsID.Text.Trim() + "%' " + sjoin;
				if ( ((txt_Date.Text.Trim() != "") && (txt_Year.Text.Trim() != "")) && ((txt_Date1.Text.Trim() != "") && (txt_Year1.Text.Trim() != "")) )
					LBL_SQLFIND.Text = LBL_SQLFIND.Text + " AP_SIGNDATE BETWEEN '" + Tools.toSQLDate(txt_Date, ddl_Month, txt_Year) + "' and '"+ Tools.toSQLDate(txt_Date1, ddl_Month1, txt_Year1) +"' " + sjoin;
				if (LBL_SQLFIND.Text.Trim() == "AND (") 
					//LBL_SQLFIND.Text = "";				
					LBL_SQLFIND.Text = this.LBL_SQLFIND.Text + " 1!=1) ";
				else
				{
					LBL_SQLFIND.Text = LBL_SQLFIND.Text.Substring(0, LBL_SQLFIND.Text.Length - sjoin.Length);
					LBL_SQLFIND.Text = LBL_SQLFIND.Text + ")";				
				}	
			} 
			catch (ApplicationException) 
			{
				GlobalTools.popMessage(this, "Input tidak valid !");
				return;
			}
			catch (FormatException) 
			{
				GlobalTools.popMessage(this, "Input tidak valid !");
				return;
			}
			catch (Exception) 
			{
				GlobalTools.popMessage(this, "Unknown Error !");
				return;
			}

			this.bindData();

		}
	}
}
 
  