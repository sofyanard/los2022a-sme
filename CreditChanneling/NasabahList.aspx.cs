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
using DMS.CuBESCore;
using DMS.DBConnection;

namespace SME.CreditChanneling
{
	/// <summary>
	/// Summary description for NasabahList.
	/// </summary>
	public partial class NasabahList : System.Web.UI.Page
	{
		/// ahmad:
		/// tambah view dan store prosedure berikut:
		/// CHANN_GETLIMIT
	
		protected System.Web.UI.WebControls.DataGrid DatGrd;
		protected System.Web.UI.WebControls.Label LBL_LIMIT;

		#region My Variables
		protected Connection conn;
		protected Tools tool = new Tools();
		private string batchno, curef, regno, tc, accept, cp_emas_limit, cp_dari_bank;
		private double remaining_emas_limit, pending_accept_limit;
		#endregion

		protected void Page_Load(object sender, System.EventArgs e)
		{
			conn		= new Connection((string)Session["ConnString"]);
			batchno		= Request.QueryString["batchno"];
			curef		= Request.QueryString["curef"];
			regno		= Request.QueryString["regno"];
			tc			= Request.QueryString["tc"];
			accept		= Request.QueryString["accept"];
			lbl_SCORE.Text = Request.QueryString["score"]; //ahmad

			TR_SCORING_RESULT.Visible = false;

			if (!IsPostBack) 
			{
				LBL_TC.Text = Request.QueryString["tc"];
				LBL_MC.Text = Request.QueryString["mc"];
				LBL_BATCHNO.Text = Request.QueryString["batchno"];				
				LBL_AP_REGNO.Text = Request.QueryString["regno"];

				viewDataGeneral();
				viewData(true);
				Hitung();

				LBL_JUM_NASABAH.Text = DatGrd.Items.Count.ToString();

				tr_confirm_negative.Visible = false;

				try
				{
					remaining_emas_limit = 0; pending_accept_limit = 0;
					conn.QueryString = "select isnull(REMAINING_EMAS_LIMIT,0) , isnull(PENDING_ACCEPT_LIMIT , 0) " +
						"from channeling ch left join bookedprod bp on bp.cu_Ref = ch.ch_bpr_curef " +
						"and bp.aa_no = ch.ch_aa_no and bp.productid = ch.ch_productid " +
						"and bp.acc_seq = ch.ch_acc_seq " +
						"where bp.ischannfacility = '1' and ch.batchno = '" + batchno + "' ";
					conn.ExecuteQuery();
					remaining_emas_limit = double.Parse(conn.GetFieldValue(0,0));
					pending_accept_limit = double.Parse(conn.GetFieldValue(0,1));
					ViewState["remaining_emas_limit"] = remaining_emas_limit;
					ViewState["pending_accept_limit"] = pending_accept_limit;
				} 
				catch (Exception ex)
				{
					Response.Write("<!-- " + ex.Message + " -->\n");
				}
			}
			else
			{
				remaining_emas_limit = (double)ViewState["remaining_emas_limit"];
				pending_accept_limit = (double)ViewState["pending_accept_limit"];
			}

			BTN_UPDATE.Attributes.Add("onclick", "if(!update()){return false;};");
			
			this.DatGrd.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.DatGrd_PageIndexChanged);
			this.DatGrd.SortCommand += new System.Web.UI.WebControls.DataGridSortCommandEventHandler(this.DatGrd_SortCommand);

			if (lbl_SCORE.Text == "yes")
			{
				BTN_UPDATE.Visible = true;
				//BTN_EARMARK.Visible = true;	// dimatikan dulu
				viewJumlahNasabahScoring();

				try
				{
					double danaBank = double.Parse(lbl_DanaDariBank.Text);
					if (danaBank + pending_accept_limit > remaining_emas_limit)
					{
						BTN_UPDATE.Visible = false;
						GlobalTools.popMessage(this, "Withdrawal amount is more than remaining limit.");
					}
				}
				catch (Exception ex)
				{
					BTN_UPDATE.Visible = false;
					Response.Write("<!-- " + ex.Message + " -->\n");
				}
			}
			else
			{
				BTN_SCORING.Visible = true;
				if (LBL_ISLENGKAPSEMUA.Text != "1")	//some data are still incomplete
					BTN_SCORING.Enabled = false;
				else
					BTN_SCORING.Enabled = true;
			}
		}

		#region My Methods

		private void Hitung()
		{
			string curef;

			conn.QueryString = "SELECT CU_REF FROM APPLICATION WHERE AP_REGNO = '" + LBL_AP_REGNO.Text + "'";
			conn.ExecuteQuery();

			curef = conn.GetFieldValue("CU_REF");

			//conn.QueryString = "CHANN_GETLIMIT '" + curef + "','" + batchno + "'";
			conn.QueryString = "SELECT * FROM VW_CHANN_GETLIMIT WHERE  CH_BPR_CUREF = '" + curef + "' AND BATCHNO ='" + batchno + "'";
			conn.ExecuteQuery();
			
			cp_emas_limit = conn.GetFieldValue("remaining_limit");
			cp_dari_bank = conn.GetFieldValue("DANA_DARI_BANK");

			lbl_TotalLimitAccept.Text = GlobalTools.MoneyFormat(conn.GetFieldValue("TOTAL_LIMIT_ACCEPT"));
			lbl_DanaDariBank.Text = GlobalTools.MoneyFormat(conn.GetFieldValue("DANA_DARI_BANK"));
			lbl_DanaDariChanneling.Text = GlobalTools.MoneyFormat(conn.GetFieldValue("DANA_DARI_CHANNELING"));
		}

		private string getStatus(string NONAS) 
		{
			//--- Untuk menampilkan status nasabah (kelengkapan data / result scoring) ------------------------
			//--- Return Value :
			//    1 : Lengkap / Accept
			//    2 : Tidak Lengkap / Reject
			//-------------------------------------------------------------------------------------------------
			string status = "1";
			conn.QueryString = "select CH_PRM_FIELD from RFCHANN_PARAM_LIST where CH_PRM_ACTIVE = '1'";
			conn.ExecuteQuery();

			DataTable dt = conn.GetDataTable().Copy();
			for(int i=0; i<dt.Rows.Count; i++) 
			{
				conn.QueryString = "select " + dt.Rows[i]["CH_PRM_FIELD"].ToString() + " from CHANN_CUSTOMER where BATCHNO = '" + LBL_BATCHNO.Text + "' and NONAS = '" + NONAS + "'";
				conn.ExecuteQuery();

				if (conn.GetFieldValue(dt.Rows[i]["CH_PRM_FIELD"].ToString()) == "" || 
					conn.GetFieldValue(dt.Rows[i]["CH_PRM_FIELD"].ToString()) == null ||
					conn.GetFieldValue(dt.Rows[i]["CH_PRM_FIELD"].ToString()) == "&nbsp;") 
				{
					status = "0";
					break;
				}
			}

			return status;
		}

		private void viewDataGeneral() 
		{
			conn.QueryString = "select * from VW_CHANN_CHANNELINGINFO where BATCHNO = '" + LBL_BATCHNO.Text + "'";
			conn.ExecuteQuery();

			LBL_CH_NAMAFILE.Text		= conn.GetFieldValue("CH_NAMAFILE");
			LBL_CH_USERID.Text			= conn.GetFieldValue("CH_USERID");
			LBL_CH_UPLOADDATE.Text		= tool.FormatDate(conn.GetFieldValue("CH_UPLOADDATE"));
			LBL_BPR_NO.Text				= conn.GetFieldValue("CH_BPR_NO");
			LBL_CH_BPR_DESC.Text		= conn.GetFieldValue("CH_BPR_DESC");
			LBL_CH_PLAFOND_LOS.Text		= tool.MoneyFormat(conn.GetFieldValue("CH_PLAFOND_LOS"));
			LBL_CH_PLAFOND_EMAS.Text	= tool.MoneyFormat(conn.GetFieldValue("CH_PLAFOND_EMAS"));
			LBL_CH_TENOR.Text			= conn.GetFieldValue("CH_TENOR");
			LBL_CUREF.Text				= conn.GetFieldValue("CU_REF");
			//LBL_AP_REGNO.Text			= regno;
		}

		private void viewData(bool isShowAll) 
		{
			/***
			string modeSearch;
			if (isShowAll) modeSearch = "0";
			else modeSearch = "1";
			***/

			/***
				conn.QueryString = "exec CHANN_CUST_FIND '"+
					TXT_NONAS.Text.Trim()+ "','"+
					TXT_NAMA.Text.Trim()+"','"+
					TXT_LIMIT1.Text.Trim()+"','"+
					TXT_LIMIT2.Text.Trim()+"','"+
					TXT_JW1.Text.Trim()+"','"+
					TXT_JW2.Text.Trim()+"','" + modeSearch + "', '" + 
					LBL_BATCHNO.Text+"'";
				***/

			//--- Asumsi: tidak ada fitur searching
			conn.QueryString = "SELECT * FROM CHANN_CUSTOMER " +
				"WHERE BATCHNO = '" + LBL_BATCHNO.Text + "' " +
				"ORDER BY " + LBL_SORTEXP.Text + " " + LBL_SORTTYPE.Text;
			conn.ExecuteQuery(); 

			DataTable dt = conn.GetDataTable().Copy();
			DatGrd.DataSource = dt.DefaultView;
			DatGrd.DataBind();

			//--- View Status Nasabah : Lengkap - Tidak Lengkap / Accept - Reject
			viewStatusNasabah();

			if (LBL_ISLENGKAPSEMUA.Text == "1") 
			{
				if (accept == null || accept == "") 
				{
					BTN_SCORING.Visible = true;
				}
				else 
				{
					BTN_SCORING.Visible	= false;
					BTN_UPDATE.Visible	= true;
					//BTN_EARMARK.Visible = true;	// dimatikan dulu
					viewJumlahNasabahScoring();
				}
			}

			//---GANTI LINK DELETE DENGAN LINK REJECT

			if (lbl_SCORE.Text == "yes")
			{
				for (int i = 0; i < DatGrd.Items.Count; i++)
				{
					LinkButton lnk_DeleteReject = (LinkButton) DatGrd.Items[i].Cells[8].FindControl("lnk_DeleteReject");

					lnk_DeleteReject.Visible = false;
				}
			}
			Hitung();
		}

		private void viewStatusNasabah()
		{
			LBL_ISLENGKAPSEMUA.Text = "1";

			for(int i=0; i < DatGrd.Items.Count; i++) 
			{
				string status			= DatGrd.Items[i].Cells[6].Text;
				string statusScoring	= DatGrd.Items[i].Cells[9].Text;
				System.Web.UI.WebControls.Image IMG_STATUS = (System.Web.UI.WebControls.Image) DatGrd.Items[i].Cells[7].FindControl("IMG_STATUS");
				Label LBL_STATUS = (Label) DatGrd.Items[i].Cells[7].FindControl("LBL_STATUS");

				//if (BTN_UPDATE.Visible == false) 
				//if (accept == "" || accept == null) 
				if (statusScoring == "&nbsp;" || statusScoring == "" || statusScoring == null)
				{
					if (status == "1")	//--- Lengkap / Accept
					{
						IMG_STATUS.ImageUrl = "../image/Complete.gif";
						LBL_STATUS.Text = "Lengkap";
					}
					else if (status == "0") //--- TidakLengkap / Reject
					{
						IMG_STATUS.ImageUrl = "../image/UnComplete.gif";
						LBL_STATUS.Text = "Tidak Lengkap";
						LBL_ISLENGKAPSEMUA.Text = "0";
					}
				}
				else 
				{
					LBL_ISLENGKAPSEMUA.Text = "0";	
					if (statusScoring == "1")	//--- Lengkap / Accept - reject by system
					{
						IMG_STATUS.ImageUrl = "../image/Complete.gif";
						LBL_STATUS.Text = "Accept";
					}
					else if (statusScoring == "0") //--- TidakLengkap / Reject
					{
						IMG_STATUS.ImageUrl = "../image/UnComplete.gif";
						LBL_STATUS.Text = "Reject";
					}
					else if (statusScoring == "2") //--- reject by user
					{
						IMG_STATUS.ImageUrl = "../image/UnComplete.gif";
						LBL_STATUS.Text = "Reject";
					}
					else 
					{
						IMG_STATUS.ImageUrl = "../image/UnComplete.gif";
						LBL_STATUS.Text = "Unknown";
					}
				}
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
		#endregion

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


		private void BTN_CLEAR_Click(object sender, System.EventArgs e)
		{
			TXT_NONAS.Text = "";
			TXT_NAMA.Text = "";
			TXT_JW1.Text = "";
			TXT_JW2.Text = "";
			TXT_LIMIT1.Text = "";
			TXT_LIMIT2.Text = "";
		}

		private void BTN_FIND_Click(object sender, System.EventArgs e)
		{
			viewData(false);
		}

		private void BTN_ALL_Click(object sender, System.EventArgs e)
		{
			viewData(true);
		}

		private void DatGrd_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			/// tabel keys : batchno, nonas, batchseq
			/// 
			string nonas = e.Item.Cells[0].Text.Trim();
			string batchseq = e.Item.Cells[10].Text.Trim();

			switch(((LinkButton)e.CommandSource).CommandName)
			{
				case "view":
					if (BTN_UPDATE.Visible == true)
						Response.Redirect("NasabahDetail.aspx?tc=" + LBL_TC.Text + "&mc=" + LBL_MC.Text +
							"&nonas=" + nonas + "&batchno=" + LBL_BATCHNO.Text + "&curef=" + LBL_CUREF.Text +
							"&regno=" + LBL_AP_REGNO.Text + "&accept=" + e.Item.Cells[9].Text +
							"&score=" + lbl_SCORE.Text + "&parent=NasabahList.aspx&batchseq=" + batchseq);
					else
						Response.Redirect("NasabahDetail.aspx?tc=" + LBL_TC.Text + "&mc=" + LBL_MC.Text +
							"&nonas=" + nonas + "&batchno=" + LBL_BATCHNO.Text + "&curef=" + LBL_CUREF.Text +
							"&regno=" + LBL_AP_REGNO.Text + "&score=" + lbl_SCORE.Text +
							"&parent=NasabahList.aspx&batchseq=" + batchseq);
					break;

				case "delete":
					conn.QueryString = "exec CHANN_CUST_CHANGE2 '" +  nonas + "','" + LBL_BATCHNO.Text + "', '" + batchseq + "','3'";
					conn.ExecuteNonQuery();
					viewData(true);
					break;

			}			
		}

		protected void BTN_BACK_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			Response.Redirect("MainChanneling.aspx?tc=" + LBL_TC.Text + "&mc=" + LBL_MC.Text);
		}

		private void DatGrd_SortCommand(object source, System.Web.UI.WebControls.DataGridSortCommandEventArgs e)
		{
			if (LBL_SORTTYPE.Text == "ASC")
				LBL_SORTTYPE.Text = "DESC";
			else
				LBL_SORTTYPE.Text = "ASC";
			LBL_SORTEXP.Text = e.SortExpression;
			viewData(true);
		}

		private void DatGrd_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			DatGrd.CurrentPageIndex = e.NewPageIndex;
			viewData(true);
		}

		private void viewJumlahNasabahScoring() 
		{
			//--- MENDAPATKAN JUMLAH NASABAH ACCEPT DAN REJECT
			try 
			{
				conn.QueryString = "exec SP_CHANN_JUMLAHSCORING '" + LBL_BATCHNO.Text + "'";
				conn.ExecuteQuery();
			} 
			catch (NullReferenceException) 
			{
				GlobalTools.popMessage(this, "Connection Error !");
				Response.Redirect("../Login.aspx?expire=1");
			}
			LBL_JUML_NASABAH_ACCEPTED.Text = conn.GetFieldValue(0,"JUMLAH");
			LBL_JUML_NASABAH_REJECTED.Text = conn.GetFieldValue(1,"JUMLAH");

			Hitung();

			TR_SCORING_RESULT.Visible = true;
		}

		protected void BTN_SCORING_Click(object sender, System.EventArgs e)
		{
			lbl_SCORE.Text = "yes"; //ahmad

			if (BTN_UPDATE.Visible == true) return;

			string nonas, batchseq, status;
			
			for (int i=0; i < DatGrd.Items.Count; i++) 
			{
				nonas = DatGrd.Items[i].Cells[0].Text;
				batchseq = DatGrd.Items[i].Cells[10].Text;

				/// VALIDASI COMPLIANCE RULES TERHADAP KONDISI CUSTOMER
				/// 
				conn.QueryString = "exec CHANN_VALIDATE_RULES '" + LBL_CUREF.Text + "', '" + nonas + "', '" + LBL_BATCHNO.Text + "', " + batchseq + "";
				conn.ExecuteQuery();

				//Response.Write(conn.QueryString + " <BR>");

				/// MENGAMBIL KEPUTUSAN ACCEPT/REJECT
				/// return value : status
				/// 1 => Accept
				/// 0 => Reject
				/// 
//				conn.QueryString = "exec CHANN_VALIDATE_CUSTOMER '" + nonas + "', '" + LBL_BATCHNO.Text + "', " + batchseq + "";
//				conn.ExecuteQuery();				
//
//				status = conn.GetFieldValue("status");

				
//				/// MENGUPDATE STATUS ACCEPT/REJECT NASABAH
//				///
//				conn.QueryString = "UPDATE CHANN_CUSTOMER SET CH_ISACCEPT = '" + status + "' WHERE BATCHNO = '" + batchno + "' AND NONAS = '" + nonas + "' and batchseq = '" + batchseq + "'";
//				conn.ExecuteNonQuery();
			}

			/*****************************************************************************
			 * Ubah ke logci lain yang lebih mudah (?)
			 *****************************************************************************
			 			  
			//--- MENDAPATKAN COMPLIANCE RULE PERUSAHAAN BPR
			conn.QueryString = "select * from VW_CHANN_BPR_RULES where CH_BPR_CUREF = '" + LBL_CUREF.Text + "'";				
			conn.ExecuteQuery();

			DataTable dt = conn.GetDataTable().Copy();
			string CH_PRM_CODE, CH_PRM_FIELD, CH_PRM_TABLE, CH_PRM_ISPARAMETER, CH_PRM_FORMULA, CH_VALUE1, CH_VALUE2, CH_SCORE;

			CH_SCORE = "";

			//--- LOOPING PER PARAMETER COMPLIANCE
			for(int i=0; i<dt.Rows.Count; i++) 
			{
				CH_PRM_CODE			= dt.Rows[i]["CH_PRM_CODE"].ToString();
				CH_PRM_FIELD		= dt.Rows[i]["CH_PRM_FIELD"].ToString();
				CH_PRM_TABLE		= dt.Rows[i]["CH_PRM_TABLE"].ToString();
				CH_PRM_ISPARAMETER	= dt.Rows[i]["CH_PRM_ISPARAMETER"].ToString();
				CH_PRM_FORMULA		= dt.Rows[i]["CH_PRM_FORMULA"].ToString();

				if (CH_PRM_ISPARAMETER == "0")	// kalau bukan parameterized
				{
					//conn.QueryString = "select ISNULL(CH_VALUE1,0) as CH_VALUE1, ISNULL(CH_VALUE2, 922337203685477) as CH_VALUE2 , CH_VALUE3  from CHANN_BPR_RULEVALUE where CH_PRM_CODE = '" + CH_PRM_CODE + "' and ch_bpr_cu_ref = '"+LBL_CUREF.Text + "'";
					conn.QueryString = "exec CHANN_GETRULEVALUE '" + CH_PRM_CODE + "', '" + LBL_CUREF.Text + "'";
					conn.ExecuteQuery();

					if (conn.GetRowCount() > 0)  
					{
						CH_VALUE1 = conn.GetFieldValue("CH_VALUE1");
						CH_VALUE2 = conn.GetFieldValue("CH_VALUE2");

						if (CH_PRM_FORMULA == null || CH_PRM_FORMULA == "")  // kalau ngga ada formula
						{
							conn.QueryString = "select nonas, " + CH_PRM_FIELD + ", '1.0' as CH_SCORE from chann_customer where batchno = '" + LBL_BATCHNO.Text + "' and " + CH_PRM_FIELD + " between " + CH_VALUE1 + " and " + CH_VALUE2 +
								"union " +
								"select nonas, " + CH_PRM_FIELD + ", '0.0' as CH_SCORE from chann_customer where batchno = '" + LBL_BATCHNO.Text + "' and " + CH_PRM_FIELD + " not between " + CH_VALUE1 + " and " + CH_VALUE2 + "";
							conn.ExecuteQuery();
						}
						else 
						{
							conn.QueryString = "select nonas, " + CH_PRM_FORMULA + " as " + CH_PRM_FIELD + ", '1.0' as CH_SCORE from chann_customer where batchno = '" + LBL_BATCHNO.Text + "' and " + CH_PRM_FIELD + " between " + CH_VALUE1 + " and " + CH_VALUE2 +
								"union " +
								"select nonas, " + CH_PRM_FORMULA + " as " + CH_PRM_FIELD + ", '0.0' as CH_SCORE from chann_customer where batchno = '" + LBL_BATCHNO.Text + "' and " + CH_PRM_FIELD + " not between " + CH_VALUE1 + " and " + CH_VALUE2 + "";
							conn.ExecuteQuery();
						}

						CH_SCORE = conn.GetFieldValue("CH_SCORE");
					}
				}
				else // kalau parameterized
				{
					if (CH_PRM_FORMULA == null || CH_PRM_FORMULA == "")  // kalau ngga ada formula
					{
						conn.QueryString = "select nonas, " + CH_PRM_FIELD + ", isnull(ch_score,0.0) as CH_SCORE " +
							"from chann_customer cc " + 
							" left join CHANN_BPR_RULEVALUE pv on cc.ch_kond_code = convert(varchar,pv.ch_value3)  " +
							"where batchno = '" + LBL_BATCHNO.Text + "'";
						conn.ExecuteQuery();
					}
					else 
					{
						conn.QueryString = "select nonas, " + CH_PRM_FORMULA + " as " + CH_PRM_FIELD + " , isnull(ch_score,0.0) as CH_SCORE " +
							"from chann_customer cc " + 
							" left join CHANN_BPR_RULEVALUE pv on cc.ch_kond_code = convert(varchar,pv.ch_value3)  " +
							"where batchno = '" + LBL_BATCHNO.Text + "'";
						conn.ExecuteQuery();
					}

					CH_SCORE = (conn.GetRowCount() > 0 ? conn.GetFieldValue("CH_SCORE") : "0");
				}


				//--- MEMASUKKAN HASIL SCORING KE TABEL
				DataTable dtCust = conn.GetDataTable().Copy();
				for(int j=0; j<dtCust.Rows.Count; j++) 
				{
					//TODO : Ubah jadi SP ???
					conn.QueryString = "insert into CHANN_BPR_RULERESULT (NONAS, BATCHNO, CH_PRM_CODE, CH_BPR_CUREF, CH_SCORINGDATE, CH_RESULT_VAL) " +
						"values ('" + dtCust.Rows[j]["NONAS"] + "', '" + LBL_BATCHNO.Text + "', '" + CH_PRM_CODE + "', '" + LBL_CUREF.Text + "', getdate(), '" + dtCust.Rows[j]["CH_SCORE"] + "')";
					conn.ExecuteNonQuery();
				}

				Hitung();
			}


			//--- MENGUPDATE STATUS ACCEPT/REJECT NASABAH
			conn.QueryString = "SELECT * FROM CHANN_CUSTOMER WHERE batchno = '" + LBL_BATCHNO.Text + "' ";
			conn.ExecuteQuery();

			DataTable dtCust2 = conn.GetDataTable().Copy();
			for(int k=0; k<dtCust2.Rows.Count; k++) 
			{
				conn.QueryString = "select CH_RESULT_VAL from CHANN_BPR_RULERESULT where BATCHNO = '" + LBL_BATCHNO.Text + "' and NONAS = '" + dtCust2.Rows[k]["NONAS"] + "' and CH_RESULT_VAL = 1.0";
				conn.ExecuteQuery();

				if (conn.GetRowCount() == dt.Rows.Count) //---Accept
				{
					conn.QueryString = "exec SP_CHANN_UPDATE_ACCREJ '" + LBL_BATCHNO.Text + "', '" + dtCust2.Rows[k]["NONAS"] + "', '1'";
				}
				else //---Reject
				{
					conn.QueryString = "exec SP_CHANN_UPDATE_ACCREJ '" + LBL_BATCHNO.Text + "', '" + dtCust2.Rows[k]["NONAS"] + "', '0'";
				}
				conn.ExecuteNonQuery();
			}
			***********************************************************************************/


			//--- MENDAPATKAN JUMLAH NASABAH ACCEPT DAN REJECT
			viewJumlahNasabahScoring();

			//--- REFRESH GRID
			viewData(true);
//			Response.Write("Dana Bank = "+cp_dari_bank +"<br>Limit = "+cp_emas_limit);
//			Response.End();

			if(Convert.ToDouble(cp_dari_bank) > Convert.ToDouble(cp_emas_limit))
			{
				BTN_SCORING.Visible = true;
				BTN_UPDATE.Visible = false;
			}
			else
			{
				BTN_SCORING.Visible = false;			
				BTN_UPDATE.Visible = true;

			//	if(Convert.ToDouble(LBL_CH_PLAFOND_LOS.Text.Trim()) <= Convert.ToDouble(lbl_TotalLimitAccept.Text.Trim()))
			//		BTN_UPDATE.Enabled = false;

				Response.Redirect("NasabahList.aspx?batchno=" + LBL_BATCHNO.Text	+ 
					"&curef=" + LBL_CUREF.Text + 
					"&regno=" + LBL_AP_REGNO.Text + 
					"&tc=" + LBL_TC.Text + 
					"&mc=" + LBL_MC.Text + 
					"&accept=" + accept + 
					"&score=" + lbl_SCORE.Text + "");
			}

			//BTN_EARMARK.Visible = true;\

			if(Convert.ToDouble(cp_dari_bank) > Convert.ToDouble(cp_emas_limit))
			{
				GlobalTools.popMessage(this,"Dana yang di butuhkan melebihi limit yang masih ada !");
			}
		}

		protected void BTN_UPDATE_Click(object sender, System.EventArgs e)
		{
			string USERID = (string) Session["UserID"];

			try 
			{	
				/// Track Update
				/// 
				conn.QueryString = "exec CHANN_TRACKUPDATE '" + 
						LBL_AP_REGNO.Text.Trim() + "', '" +
						LBL_BATCHNO.Text.Trim() + "', '" + 
						(string) Session["UserID"] + "'";
				conn.ExecTrans();

				/// Alternate Payment Calculation and insertion
				/// 
				conn.QueryString = "exec CHANN_FILLALTERNATEPAYMENT '" + LBL_AP_REGNO.Text.Trim() + "','" + LBL_BATCHNO.Text.Trim() + "'";
				conn.ExecTrans();

				conn.ExecTran_Commit();				
			} 
			catch (Exception ex)
			{
				if (conn != null)
					conn.ExecTran_Rollback();

				Response.Write("<!-- " + ex.Message + " -->");
				GlobalTools.popMessage(this, "Aplikasi gagal update status!");
				return;
			}

			string msg = getNextStepMsg(LBL_AP_REGNO.Text);
			Response.Redirect("MainChanneling.aspx?tc=" + LBL_TC.Text + "&mc=" + LBL_MC.Text + "&msg=" + msg);
		}

		protected void BTN_NEGATIVE_NO_Click(object sender, System.EventArgs e)
		{
			tr_confirm_negative.Visible = false;
		}

		protected void BTN_NEGATIVE_YES_Click(object sender, System.EventArgs e)
		{
			TXT_NEGATIVE.Text = "YES";
			BTN_EARMARK_Click(sender, e);
			TXT_NEGATIVE.Text = "NO";
			tr_confirm_negative.Visible = false;
		}

		protected void BTN_EARMARK_Click(object sender, System.EventArgs e)
		{
			//////////////////////////////////
			/// Earmarking
			/// 
			//////////////////////////////////////////////////////////////////
			/// For the sake of safety, check first whether it needs
			/// earmarking or not
			/// 
			conn.QueryString = "exec EARMARK_CEK '" + LBL_AP_REGNO.Text + "', null";
			conn.ExecuteQuery();
			if (conn.GetFieldValue("NEED_EARMARK") == "1") 
			{
				try 
				{
					if (TXT_NEGATIVE.Text == "NO")
						Earmarking.Earmarking.doEarmark(LBL_AP_REGNO.Text, conn);
					else
						Earmarking.Earmarking.doEarmark(LBL_AP_REGNO.Text, conn, "1", "");

					conn.ExecTran_Commit();
				} 
				catch (Earmarking.NegativeLimitException ex1) 
				{
					if (conn != null) conn.ExecTran_Rollback();
					if (ex1.getMessage() == "FACILITY") 
					{
						GlobalTools.popMessage(this, "Earmarking by facility failed. Remaining limit become negative!");
						return;
					} 
					if (TXT_NEGATIVE.Text == "NO") tr_confirm_negative.Visible = false;
				}
				catch (Exception ex)
				{
					ExceptionHandling.Handler.saveExceptionIntoWindowsLog(ex, Request.Path, LBL_AP_REGNO.Text);
					if (conn != null) conn.ExecTran_Rollback();
				}
			}
		}
	}
}
