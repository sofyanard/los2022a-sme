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

namespace SME.CreditAnalysis
{
	/// <summary>
	/// Summary description for ListCreditAnalysis.
	/// </summary>
	public partial class ListCreditAnalysis : System.Web.UI.Page
	{
		protected Tools tool = new Tools();
		//private Connection conn = new Connection("Data Source=10.123.12.30;Initial Catalog=SME;uid=sa;pwd=");
		protected Connection conn;
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			conn = (Connection) Session["Connection"];

			string tc = "";//,mi = "";//, si = "";
			try 
			{
				tc = Request.QueryString["tc"];
				//mi = Request.QueryString["mi"];sadfsdafdsasafsdsad
				//si = Request.QueryString["si"];
			} 
			catch {}
			
			if (!IsPostBack)
			{
				// Munculkan pesan next step
				if (Request.QueryString["msg"] != "" && Request.QueryString["msg"]!= null)  
				{
					GlobalTools.popMessage(this, Request.QueryString["msg"]);
				}

				LBL_USERID.Text = Session["UserID"].ToString();

				Tools.initDateForm(txt_Date, ddl_Month, txt_Year, true);
				txt_Date.Text = "";
				txt_Year.Text = "";
				Tools.initDateForm(txt_Date1, ddl_Month1, txt_Year1, true);
				txt_Date1.Text = "";
				txt_Year1.Text = "";

				DataTable DTBO = new DataTable();
				DatGrd.DataSource = new DataView(DTBO);
				try 
				{
					DatGrd.DataBind();
				} 
				catch 
				{
					DatGrd.CurrentPageIndex = 0;
					DatGrd.DataBind();
				}

				bindData(); // menampilkan semua data ketika page diload pertama kali
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

		private void bindData()
		{
			conn.QueryString = "select pp_trackfrom from procedurepath where pp_tracknext='" + Request.QueryString["tc"] + "'";
			conn.ExecuteQuery();
			string othTrack = conn.GetFieldValue("pp_trackfrom");

			System.Web.UI.WebControls.Image ImgAppr, ImgBI, ImgSiteVisit, ImgVer;
			DataTable dt = new DataTable();
			//--- modified by yudi (2004/09/09) ---
			//conn.QueryString = "select * from  VW_CREDITANALYSIS_LIST where (AP_CURRTRACK='" + Request.QueryString["tc"] + "' or AP_CURRTRACK='" + othTrack + "') and (AP_CA='" + Session["UserID"].ToString() + "' or AP_CA is null) " + this.LBL_SQLFIND_PERSONAL.Text.Trim();
			conn.QueryString = "select * from  VW_CREDITANALYSIS_LIST where (AP_CURRTRACK='" + Request.QueryString["tc"] + "' or AP_CURRTRACK='" + othTrack + "') and (AP_CA='" + LBL_USERID.Text + "') " + this.LBL_SQLFIND_PERSONAL.Text.Trim();
			//-------------------------------------
			try 
			{
				conn.ExecuteQuery();
			} 
			catch (ApplicationException) 
			{
				Tools.popMessage(this, "Input tidak valid !");
				return;
			}
			catch (FormatException) 
			{
				Tools.popMessage(this, "Input tidak valid !");
				return;
			}
			catch (NullReferenceException) 
			{
				Tools.popMessage(this, "Server Error !");
				return;
			}

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
				DatGrd.Items[i].Cells[2].Text = tool.FormatDate(DatGrd.Items[i].Cells[2].Text, true);
				
				ImgAppr	= (System.Web.UI.WebControls.Image) DatGrd.Items[i].Cells[9].FindControl("IMG_LA_APPRSTATUS"); 
				ImgBI	= (System.Web.UI.WebControls.Image) DatGrd.Items[i].Cells[12].FindControl("IMG_BS_COMPLETE");
				ImgSiteVisit = (System.Web.UI.WebControls.Image) DatGrd.Items[i].Cells[14].FindControl("IMG_AP_SITEVISITSTA");
				ImgVer	= (System.Web.UI.WebControls.Image) DatGrd.Items[i].Cells[7].FindControl("IMGVER");				
				
				Label LblAppr	= (Label) DatGrd.Items[i].Cells[9].FindControl("LBL_LA_APPRSTATUS");
				Label LblBI		= (Label) DatGrd.Items[i].Cells[12].FindControl("LBL_BS_COMPLETE");
				Label LblSite	= (Label) DatGrd.Items[i].Cells[14].FindControl("LBL_AP_SITEVISITSTA");
				Label LblVer	= (Label) DatGrd.Items[i].Cells[7].FindControl("LBLVER");				
				
				//------- column Ver (hidden) -------------
				// YUDI : AP_CURRTRACK
				if (DatGrd.Items[i].Cells[6].Text.Trim() == Request.QueryString["tc"].ToString().Trim()) 
				{ // tanggal diambil dari AP_CURRTRACKDATE pada tabel APPTRACK
					try 
					{
						conn.QueryString = "SELECT AP_CURRTRACKDATE FROM APPTRACK WHERE";
						conn.QueryString += " AP_REGNO = '" + DatGrd.Items[i].Cells[0].Text.Trim() + "'";
						//Response.Write(conn.QueryString+"<BR>");
						conn.ExecuteQuery();
						string currtrackdate = conn.GetFieldValue("AP_CURRTRACKDATE");
						if ((currtrackdate != "") && (currtrackdate != null))
						{
							LblVer.Text = tool.FormatDate_GetDate(currtrackdate);
						}
						else LblVer.Text = "Complete";
					}
					catch(NullReferenceException)
					{
						GlobalTools.popMessage(this,"Server error");
					}

					ImgVer.ImageUrl = "../image/Complete.gif";
				}
				else 
				{
					LblVer.Text = "Incomplete";
					ImgVer.ImageUrl = "../image/UnComplete.gif";
				}
				//--------------------------------------------------

				// AP_APPRSTATUS
				if (DatGrd.Items[i].Cells[8].Text == "1")
				{ // AP_APPRSTATUS di baris datagrid cells[8]
					try
					{
						//Response.Write("AP_APPRSTATUS["+i+"] = 1<BR>");
						conn.QueryString = "SELECT MAX(LA_COMPLETEDATE) AS COMPLETEDATE FROM LISTASSIGNMENT";
						conn.QueryString += " WHERE AP_REGNO ='" + DatGrd.Items[i].Cells[0].Text +"'";
						conn.QueryString += " and CU_REF='" + DatGrd.Items[i].Cells[4].Text + "'";
						conn.ExecuteQuery();
						//Response.Write(conn.QueryString+"<BR>");
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
					}
					catch(NullReferenceException)
					{
						GlobalTools.popMessage(this,"Server error");
						return;
					}
				}
				else
				{
					/* versi sebelumnya 01/11/04
					if (DatGrd.Items[i].Cells[8].Text == "2")
						LblAppr.Text = "Pending By CO";
					else
					{
						LblAppr.Text = "In Process";
					}
					ImgAppr.ImageUrl = "../image/UnComplete.gif";*/

					if (DatGrd.Items[i].Cells[5].Text == "2") 
					{  // AP_APPRSTATUS = 2 ?
						//Response.Write("AP_APPRSTATUS["+i+"] = 2<BR>");
						LblAppr.Text = "Pending by CO";
						ImgAppr.ImageUrl = "../image/UnComplete.gif";
					}
					else 
					{  // AP_APPRSTATUS != 1
						conn.QueryString = "select * from VW_VER_APPRAISALSTATUS " + 
							"where AP_REGNO ='" + DatGrd.Items[i].Cells[0].Text +
							"' and CU_REF='" + DatGrd.Items[i].Cells[4].Text + "'";
						conn.ExecuteQuery();

						if (conn.GetRowCount() == 1) 
						{ // jika hanya ada satu appraisal
							if (conn.GetFieldValue("LA_APPRSTATUS") == "3") 
							{
								//Response.Write("AP_APPRSTATUS["+i+"] = 0 appraisal = 1 dengan status = 3<BR>");
								conn.QueryString = "SELECT MAX(LA_COMPLETEDATE) AS COMPLETEDATE FROM LISTASSIGNMENT";
								conn.QueryString += " WHERE AP_REGNO ='" + DatGrd.Items[i].Cells[0].Text +"'";
								conn.QueryString += " and CU_REF='" + DatGrd.Items[i].Cells[4].Text + "'";
								conn.ExecuteQuery();
								//Response.Write(conn.QueryString+"<BR>");
								string completeDate = conn.GetFieldValue("COMPLETEDATE");
								if ((completeDate != "") && (completeDate != null)) LblAppr.Text = tool.FormatDate_GetDate(completeDate);
								else LblAppr.Text = "Complete";
								ImgAppr.ImageUrl = "../image/Complete.gif";
							}
							else 
							{
								//Response.Write("AP_APPRSTATUS["+i+"] = 0 appraisal = 1 dengan status != 3 <BR>");
								conn.QueryString = "SELECT MIN(LA_ASSIGNDATE) AS ASSIGNDATE FROM LISTASSIGNMENT";
								conn.QueryString += " WHERE AP_REGNO ='" + DatGrd.Items[i].Cells[0].Text +"'";
								conn.QueryString += " and CU_REF='" + DatGrd.Items[i].Cells[4].Text + "'";
								conn.QueryString += " and LA_APPRTYPE <> 2";
								conn.ExecuteQuery();
								//Response.Write(conn.QueryString);
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
						{
							// tidak ada jaminan yang harus diappraise sehingga status appraisal = Complete
							// tombol Update Status harus muncul
							LblAppr.Text = "Complete";
							ImgAppr.ImageUrl = "../image/Complete.gif";
						}
						else 
						{
							//Response.Write("AP_APPRSTATUS["+i+"] = 0 more than 1 appraisal<BR>");
							conn.QueryString = "SELECT MIN(LA_ASSIGNDATE) AS ASSIGNDATE FROM LISTASSIGNMENT";
							conn.QueryString += " WHERE AP_REGNO ='" + DatGrd.Items[i].Cells[0].Text +"'";
							conn.QueryString += " and CU_REF='" + DatGrd.Items[i].Cells[4].Text + "'";
							conn.QueryString += " and LA_APPRTYPE <> 2";
							conn.ExecuteQuery();
							//Response.Write(conn.QueryString+"<BR>");

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

				//conn.QueryString = "select count(*) from BI_STATUS where AP_REGNO = '"+DatGrd.Items[i].Cells[0].Text+"' and CU_REF = '"+DatGrd.Items[i].Cells[4].Text+"'";
				// modif oleh Yudi (2004/09/18)
				conn.QueryString = "select count(*) from BI_STATUS where AP_REGNO = '"+DatGrd.Items[i].Cells[0].Text+"' and CU_REF = '"+DatGrd.Items[i].Cells[4].Text+"'";
				conn.ExecuteQuery();
				
				//if (DatGrd.Items[i].Cells[10].Text == "1")
				if (conn.GetFieldValue(0,0).ToString() != "0")
				{ // AP_REGNO tidak sama dengan string "0"
					// BS_COMPLETE
					if (DatGrd.Items[i].Cells[11].Text == "2")
					{
						try
						{
							conn.QueryString = "SELECT BS_VALIDDATE FROM BI_STATUS";
							conn.QueryString += " WHERE AP_REGNO = '"+DatGrd.Items[i].Cells[0].Text+"' and CU_REF = '"+DatGrd.Items[i].Cells[4].Text+"'";
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
							conn.QueryString += " WHERE AP_REGNO = '"+DatGrd.Items[i].Cells[0].Text+"' and CU_REF = '"+DatGrd.Items[i].Cells[4].Text+"'";
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
						}
						catch(NullReferenceException)
						{
							GlobalTools.popMessage(this,"Server error");
						}
						ImgBI.ImageUrl = "../image/UnComplete.gif";
					}
				}
				else
				{ // count(*) == "0"
					try
					{
						conn.QueryString = "SELECT BS_VALIDDATE FROM BI_STATUS";
						conn.QueryString += " WHERE AP_REGNO = '"+DatGrd.Items[i].Cells[0].Text+"' and CU_REF = '"+DatGrd.Items[i].Cells[4].Text+"'";
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
					}
					catch(NullReferenceException)
					{
						GlobalTools.popMessage(this,"Server error");
					}
					ImgBI.ImageUrl = "../image/Complete.gif";
				}

				// AP_SITEVISITVA
				conn.QueryString = "select in_small, in_middle, in_corporate from rfinitial";
				conn.ExecuteQuery();
					 
				string m_in_small = conn.GetFieldValue("in_small");
				string m_in_middle = conn.GetFieldValue("in_middle");
				string m_in_corp = conn.GetFieldValue("in_corporate");

				conn.QueryString = "select isnull(AP_ISAPPEAL,0), AP_COMPLEVEL from APPLICATION ";
				conn.QueryString += "where AP_REGNO = '" + DatGrd.Items[i].Cells[0].Text + "'";
				conn.ExecuteQuery();
			
				string szCpLvl = conn.GetFieldValue("AP_COMPLEVEL");			
				bool isSmall = false;

				if(szCpLvl == m_in_small) 
					isSmall = true; // usernya adalah SMALL
				else if(szCpLvl == m_in_middle)
					isSmall = false; // usernya adalah MIDDLE
				else if(szCpLvl == m_in_corp)
					isSmall = false; // usernya adalah CORPORATE

				if (DatGrd.Items[i].Cells[13].Text == "1")
				{
					string completeDate = "";
					if (!isSmall)
					{
						conn.QueryString = "SELECT SV_TARGETDATE FROM CUST_SITEVISIT ";
						conn.QueryString += "WHERE AP_REGNO = '" + DatGrd.Items[i].Cells[0].Text + "' and ";
						conn.QueryString += "CU_REF = '" + DatGrd.Items[i].Cells[4].Text + "'";
						conn.ExecuteQuery();
						//Response.Write(conn.QueryString + "<BR>");
						completeDate = conn.GetFieldValue("SV_TARGETDATE").ToString();
					} 
					else
					{
						conn.QueryString = "SELECT TARGETSELESAI FROM LKKN ";
						conn.QueryString += "WHERE AP_REGNO ='" + DatGrd.Items[i].Cells[0].Text + "'";
						//conn.QueryString += " CU_REF = '" + DatGrd.Items[i].Cells[4].Text + "'";
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
					{
						conn.QueryString = "SELECT SV_DATE FROM CUST_SITEVISIT ";
						conn.QueryString += "WHERE AP_REGNO = '" + DatGrd.Items[i].Cells[0].Text + "' and ";
						conn.QueryString += "CU_REF = '" + DatGrd.Items[i].Cells[4].Text + "'";
						//Response.Write(conn.QueryString + "<BR>");
						conn.ExecuteQuery();
						visitDate = conn.GetFieldValue("SV_DATE").ToString();
					} 
					else
					{
						conn.QueryString = "SELECT VISITDATE FROM LKKN";
						conn.QueryString += " WHERE AP_REGNO ='" + DatGrd.Items[i].Cells[0].Text + "'";
						//conn.QueryString += " CU_REF = '" + DatGrd.Items[i].Cells[4].Text + "'";
						//Response.Write(conn.QueryString + "<BR>");
						conn.ExecuteQuery();
						visitDate = conn.GetFieldValue("VISITDATE").ToString();
					}
					
					if ((visitDate != "") && (visitDate != null)) 
						LblSite.Text = tool.FormatDate_GetDate(visitDate);
					else LblSite.Text = "In Process";
					ImgSiteVisit.ImageUrl = "../image/UnComplete.gif";
				}				
			}

			/*
			DataTable DTBO = new DataTable();
			DataRow datrow;
			DTBO.Columns.Add(new DataColumn("AP_REGNO"));
			DTBO.Columns.Add(new DataColumn("Name"));
			DTBO.Columns.Add(new DataColumn("AP_SIGNDATE"));
			DTBO.Columns.Add(new DataColumn("AP_LIMITEXPOSURE"));
			DTBO.Columns.Add(new DataColumn("SU_FULLNAME"));
			DTBO.Columns.Add(new DataColumn("CU_REF"));
			//personal
			//conn.QueryString = "SELECT * FROM VW_LISTCUSTOMER_PERSONAL where ap_currtrack='" + Request.QueryString["tc"] + "' or ap_currtrack='" + othTrack + "'";
			conn.QueryString = "SELECT * FROM VW_LISTCUSTOMER_PERSONAL where (ap_currtrack='" + Request.QueryString["tc"] + "' or ap_currtrack='" + othTrack + "') " + this.LBL_SQLFIND_PERSONAL.Text.Trim();

			conn.ExecuteQuery();
			for (int i =0; i < conn.GetRowCount(); i++) 
			{
				datrow = DTBO.NewRow();
				datrow[0] = conn.GetFieldValue(i,0);
				datrow[1] = "&nbsp;&nbsp;" + conn.GetFieldValue(i,2);
				datrow[2] = tool.FormatDate(conn.GetFieldValue(i,12), true);
				datrow[3] = conn.GetFieldValue(i,4);
				datrow[4] = conn.GetFieldValue(i,5);
				datrow[5] = conn.GetFieldValue(i,1);
				DTBO.Rows.Add(datrow);
			}

			//company
			//conn.QueryString = "SELECT * FROM VW_LISTCUSTOMER_COMPANY where ap_currtrack='" + Request.QueryString["tc"] + "' or ap_currtrack='" + othTrack + "'";
			conn.QueryString = "SELECT * FROM VW_LISTCUSTOMER_COMPANY where (ap_currtrack='" + Request.QueryString["tc"] + "' or ap_currtrack='" + othTrack + "') " + this.LBL_SQLFIND_COMP.Text.Trim();
			conn.ExecuteQuery();
			for (int i =0; i < conn.GetRowCount(); i++) 
			{
				datrow = DTBO.NewRow();
				datrow[0] = conn.GetFieldValue(i,0);
				datrow[1] = "&nbsp;&nbsp;" + conn.GetFieldValue(i,2);
				datrow[2] = tool.FormatDate(conn.GetFieldValue(i,11), true);
				datrow[3] = conn.GetFieldValue(i,4);
				datrow[4] = conn.GetFieldValue(i,5);
				datrow[5] = conn.GetFieldValue(i,1);
				DTBO.Rows.Add(datrow);
			}
			DatGrd.DataSource = new DataView(DTBO);
			DatGrd.DataBind();
			*/
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
					//TODO : Mengapa hal ini dilakukan ???
					//	     Hal ini kemungkinan penyebab aplikasi hilang
					if (e.Item.Cells[15].Text == "&nbsp;")
					{
						//--- modified by yudi (2004/09/09) ---
						//conn.QueryString = "update application set ap_ca='" + Session["UserID"].ToString() + "' where ap_regno='" + e.Item.Cells[0].Text + "'";
						conn.QueryString = "update application set ap_ca='" + LBL_USERID.Text + "' where ap_regno='" + e.Item.Cells[0].Text + "'";
						//-------------------------------------
						conn.ExecuteNonQuery();
					}
					
					string vjnsnasabah; 
					string vprgid;
					
					conn.QueryString = "select distinct top 1 cu_jnsnasabah from customer where cu_ref in (Select cu_ref from application where ap_regno = '"+e.Item.Cells[0].Text+ "')";
					conn.ExecuteQuery();
					vjnsnasabah = conn.GetFieldValue("cu_jnsnasabah").ToString();
					//------------------------------------------------------------------------------
					
					conn.QueryString = "select distinct top 1 programid from rfprogram where programid in (select prog_code from application where ap_regno = '"+e.Item.Cells[0].Text+ "')";
					conn.ExecuteQuery();
					vprgid = conn.GetFieldValue("programid").ToString();
					//------------------------------------------------------------------------------
					
					//GlobalTools.popMessage(this,"MainCreditAnalysis.aspx?regno=" + e.Item.Cells[0].Text + "&curef=" + e.Item.Cells[4].Text+ "&tc="+tc + "&mc=" + Request.QueryString["mc"] + "&programid=" + vprgid + "&jnsnasabah=" + vjnsnasabah);
					Session.Add("programid", vprgid);
					Session.Add("jnsnasabah", vjnsnasabah);					
					Response.Redirect("MainCreditAnalysis.aspx?regno=" + e.Item.Cells[0].Text + "&curef=" + e.Item.Cells[4].Text+ "&tc="+tc + "&mc=" + Request.QueryString["mc"] + "&programid=" + vprgid + "&jnsnasabah=" + vjnsnasabah);
					break;
				default:
					break;
			}
		}

		protected void btn_Find_Click(object sender, System.EventArgs e)
		{
			string sjoin = this.RDB_COND.SelectedValue;

			// CUSTOMER PERSONAL
			try 
			{
				this.LBL_SQLFIND_PERSONAL.Text = " AND (";			
				if (txt_IdCard.Text.Trim() != "")
					LBL_SQLFIND_PERSONAL.Text = LBL_SQLFIND_PERSONAL.Text + " CU_IDCARDNUM like '%" + txt_IdCard.Text.Trim() + "%' " + sjoin;
				if (txt_NPWP.Text.Trim() != "")
					LBL_SQLFIND_PERSONAL.Text = LBL_SQLFIND_PERSONAL.Text + " CU_NPWP like '%" + txt_NPWP.Text.Trim() + "%' " + sjoin;
				if (txt_Name.Text.Trim() != "")
					LBL_SQLFIND_PERSONAL.Text = LBL_SQLFIND_PERSONAL.Text + " CU_NAME like '%" + txt_Name.Text.Trim() + "%' " + sjoin;
				if (txt_ProsID.Text.Trim() != "")
					LBL_SQLFIND_PERSONAL.Text = LBL_SQLFIND_PERSONAL.Text + " AP_REGNO like '%" + txt_ProsID.Text.Trim() + "%' " + sjoin;
				if ( ((txt_Date.Text.Trim() != "") && (txt_Year.Text.Trim() != "")) && ((txt_Date1.Text.Trim() != "") && (txt_Year1.Text.Trim() != "")) )
					LBL_SQLFIND_PERSONAL.Text = LBL_SQLFIND_PERSONAL.Text + " AP_SIGNDATE BETWEEN '" + Tools.toSQLDate(txt_Date, ddl_Month, txt_Year) + "' and '"+ Tools.toSQLDate(txt_Date1, ddl_Month1, txt_Year1) +"' " + sjoin;
				if (LBL_SQLFIND_PERSONAL.Text.Trim() == "AND (") 
					LBL_SQLFIND_PERSONAL.Text = "";
					//LBL_SQLFIND_PERSONAL.Text = this.LBL_SQLFIND_PERSONAL.Text + " 1!=1) ";
				else
				{
					LBL_SQLFIND_PERSONAL.Text = LBL_SQLFIND_PERSONAL.Text.Substring(0, LBL_SQLFIND_PERSONAL.Text.Length - sjoin.Length);
					LBL_SQLFIND_PERSONAL.Text = LBL_SQLFIND_PERSONAL.Text + ")";
				}	
			} 
			catch (ApplicationException) 
			{
				Tools.popMessage(this, "Input tidak valid !");
				return;
			}

			// CUSTOMER COMPANY
			try 
			{
				this.LBL_SQLFIND_COMP.Text = " AND (";			
				if (txt_NPWP.Text.Trim() != "")
					LBL_SQLFIND_COMP.Text = LBL_SQLFIND_COMP.Text + " CU_NPWP like '%" + txt_NPWP.Text.Trim() + "%' " + sjoin;
				if (txt_Name.Text.Trim() != "")
					LBL_SQLFIND_COMP.Text = LBL_SQLFIND_COMP.Text + " CU_NAME like '%" + txt_Name.Text.Trim() + "%' " + sjoin;
				if (txt_ProsID.Text.Trim() != "")
					LBL_SQLFIND_COMP.Text = LBL_SQLFIND_COMP.Text + " AP_REGNO like '%" + txt_ProsID.Text.Trim() + "%' " + sjoin;
				if ( ((txt_Date.Text.Trim() != "") && (txt_Year.Text.Trim() != "")) && ((txt_Date1.Text.Trim() != "") && (txt_Year1.Text.Trim() != "")) )
					LBL_SQLFIND_COMP.Text = LBL_SQLFIND_COMP.Text + " AP_SIGNDATE BETWEEN '" + Tools.toSQLDate(txt_Date, ddl_Month, txt_Year) + "' and '"+ Tools.toSQLDate(txt_Date1, ddl_Month1, txt_Year1) +"' " + sjoin;
				if (LBL_SQLFIND_COMP.Text.Trim() == "AND (") 
					LBL_SQLFIND_COMP.Text = "";
					//LBL_SQLFIND_COMP.Text = this.LBL_SQLFIND_COMP.Text + " 1!=1) ";
				else
				{
					LBL_SQLFIND_COMP.Text = LBL_SQLFIND_COMP.Text.Substring(0, LBL_SQLFIND_COMP.Text.Length - sjoin.Length);
					LBL_SQLFIND_COMP.Text = LBL_SQLFIND_COMP.Text + ")";
				}	
			} 
			catch (ApplicationException) 
			{
				Tools.popMessage(this, "Input tidak valid !");
				return;
			}

			//------- bind Data
			if (this.LBL_SQLFIND_COMP.Text.Trim() != "" && this.LBL_SQLFIND_PERSONAL.Text.Trim() != "")
				this.bindData();
			else 
			{
				DataTable DTBO = new DataTable();
				DatGrd.DataSource = new DataView(DTBO);
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
		}

	}
}
