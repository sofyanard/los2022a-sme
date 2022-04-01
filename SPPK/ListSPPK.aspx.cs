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

namespace SME.SPPK
{
	/// <summary>
	/// Summary description for ListSPPK.sadfasdfsdfsadfadsfsdf
	/// </summary>
	public partial class ListSPPK : System.Web.UI.Page
	{
		protected Connection conn;
		protected Tools tool = new Tools();
		
		protected void Page_Load(object sender, System.EventArgs e)
		{
			conn = (Connection) Session["Connection"];

			if (!Logic.AllowAccess(Session["GroupID"].ToString(), Request.QueryString["mc"], conn))
				Response.Redirect("/SME/Restricted.aspx");

			if (!IsPostBack)
			{
				ViewData("0");
			}//sfsdf

			Button1.Attributes.Add("onclick","if(!update('appeal')) { return false; };");
            Button2.Attributes.Add("onclick","if(!update('update')) { return false; };");
			BTN_VER_ASSIGN.Attributes.Add("onclick","if(!update('Back to Verification Assignment')) { return false; };");
			//ViewAllData();
		}
		/* view all data */
		private void ViewAllData()
		{
			DataTable dt = new DataTable();
			//conn.QueryString = "select * from vw_listsppk where ap_currtrack='" + Request.QueryString["tc"] + "' and (ap_relmngr='" + Session["UserID"].ToString() + "' or ap_relmngr is null)";
			conn.QueryString = "select * from vw_listsppk";
			conn.ExecuteQuery();
			dt = conn.GetDataTable().Copy();

			dgListSPPK.DataSource = dt;
			dgListSPPK.DataBind();

			for (int i = 0; i < dgListSPPK.Items.Count; i++)
			{
				dgListSPPK.Items[i].Cells[5].Text = tool.FormatDate(dgListSPPK.Items[i].Cells[5].Text, true);
			}
		}

		private void ViewData(string sta)
		{	
			DataTable dt = new DataTable();
			if (sta == "1")
				conn.QueryString = "select * from vw_listsppk where ap_regno = '"+txt_regno.Text+"' and ap_currtrack='" + Request.QueryString["tc"] + "' and (ap_relmngr='" + Session["UserID"].ToString() + "' or ap_relmngr is null)";
			else
				conn.QueryString = "select * from vw_listsppk where ap_currtrack='" + Request.QueryString["tc"] + "' and (ap_relmngr='" + Session["UserID"].ToString() + "' or ap_relmngr is null)";
			conn.ExecuteQuery();
			dt = conn.GetDataTable().Copy();

			dgListSPPK.DataSource = dt;
			dgListSPPK.DataBind();

			for (int i = 0; i < dgListSPPK.Items.Count; i++)
			{
				dgListSPPK.Items[i].Cells[5].Text = tool.FormatDate(dgListSPPK.Items[i].Cells[5].Text, true);
			}
		}


		private void reCalculateInstallment(string regno)
		{
			/// Get the latest credit status
			/// (Approved credit)
			/// 
			conn.QueryString = "select * from vw_custproduct where ap_regno = '"+ regno +"' and apptype in ('01', '03', '06')";
			conn.ExecuteQuery();
			DataTable dt = conn.GetDataTable();

			double _result = 0;
			double _cp_exlimitval = 0, _interest = 0;;
			int _cp_jangkawkt = 0;
			string _cp_tenorcode = "M";

			try 
			{				
				for(int i=0; i < dt.Rows.Count; i++) 
				{	
					// get limit
					try { _cp_exlimitval = double.Parse(dt.Rows[i]["cp_exlimitval"].ToString()); } 
					catch { _cp_exlimitval = 0; }

					// get tenor
					try { _cp_jangkawkt = int.Parse(dt.Rows[i]["cp_jangkawkt"].ToString()); } 
					catch { _cp_jangkawkt = 0; }

					// get tenorcode
					try { _cp_tenorcode = dt.Rows[i]["cp_tenorcode"].ToString(); } 
					catch {}
					_cp_tenorcode = (_cp_tenorcode==""||_cp_tenorcode==null?"M":_cp_tenorcode);

					/// Get interest value, according chosen product 
					/// 
					conn.QueryString = "select interesttype from rfproduct where productid = '" + dt.Rows[i]["productid"].ToString() + "'";
					conn.ExecuteQuery();
					DataTable dt2 = conn.GetDataTable();

					/// If interest type is Floating (01) or Alternate Rate (03) ...
					/// 
					if (dt2.Rows[0]["interesttype"].ToString() == "01" || dt2.Rows[0]["interesttype"].ToString() == "03")
					{
						conn.QueryString = "select * from vw_floatingrate where productid = '" + dt.Rows[i]["productid"].ToString() + "'";
						conn.ExecuteQuery();
						try { _interest = double.Parse(conn.GetFieldValue("rate")); } 
						catch { _interest = 0; }
					}
					else  // Interest Type is Fixed (02)
					{
						conn.QueryString = "select interesttyperate from rfproduct where productid = '" + dt.Rows[i]["productid"].ToString() + "'";
						conn.ExecuteQuery();
						try { _interest = double.Parse(conn.GetFieldValue("interesttyperate"));	} 
						catch { _interest = 0; }
					}

					try 
					{
						_result = DMS.CuBESCore.Logic.hitungInstalment(_cp_exlimitval, _cp_jangkawkt, _interest, dt.Rows[i]["productid"].ToString(), _cp_tenorcode, conn);
						if (Double.IsInfinity(_result) || Double.IsNaN(_result)) 
						{
							_result = 0;
						}
					} 
					catch 
					{ 
						_result = 0; 
					}

					conn.QueryString = "exec SPPK_RECALC_INSTALLMENT '" + 
						regno + "', '" + 
						dt.Rows[i]["apptype"].ToString() + "', '" + 
						dt.Rows[i]["productid"].ToString() + "', '" + 
						dt.Rows[i]["prod_seq"].ToString() + "', '" + 
						dt.Rows[i]["ket_code"].ToString() + "', " +
						tool.ConvertFloat(_result.ToString()) + "";
					conn.ExecuteNonQuery();
				}
			} 
			catch (Exception exn)
			{
				Response.Write("<!-- Most Outer : " + exn.ToString() + " -->");
				throw new Exception();
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
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{    
			this.dgListSPPK.ItemCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.dgListSPPK_ItemCommand);

		}
		#endregion


		private void dgListSPPK_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			switch (((LinkButton)e.CommandSource).CommandName)
			{
				case "view":
					//Response.Write ("regno : "+e.Item.Cells[0].Text);
					//Response.End();
					//--------- edited by Yudi -----------------
					//Response.Redirect("viewsppk.aspx?regno="+e.Item.Cells[0].Text+"&curef="+e.Item.Cells[1].Text + "&mc=" + Request.QueryString["mc"]);
					if (e.Item.Cells[8].Text == "&nbsp;")
					{
						conn.QueryString = "update application set ap_relmngr='" + Session["UserID"].ToString() + "' where ap_regno='" + e.Item.Cells[0].Text + "'";
						conn.ExecuteNonQuery();
					}
					Response.Redirect("viewsppk.aspx?regno="+e.Item.Cells[0].Text+"&curef="+e.Item.Cells[1].Text + "&mc=" + Request.QueryString["mc"]+"&tc="+Request.QueryString["tc"]);
					//------------------------------------------
					break;
			}
		}

		protected void btn_cari_Click(object sender, System.EventArgs e)
		{
			ViewData("1");			
		}

		protected void Button2_Click(object sender, System.EventArgs e)
		{ // button Update Status
			CheckBox chk;
			string regno = "";
			//string productid = "";
			string tc = "";

			string pesanError = "Aplikasi yang gagal update status:\\n";
			int countError = 0;

			//areaid = Session["AreaID"].ToString();
			tc = Request.QueryString["tc"];			

			bool updateYes = false;
			// menyimpan data salah satu aplikasi untuk menentukan next track dari track sekarang

			for (int i = 0; i < dgListSPPK.Items.Count; i++)
			{
				chk = (CheckBox) dgListSPPK.Items[i].Cells[6].FindControl("CheckBox1");

				try 
				{
					if (chk.Checked == true)
					{
						//conn.QueryString = "select apptype, productid from cust_product where ap_regno='" + dgListSPPK.Items[i].Cells[0].Text + "'";
						DataTable dt;
						conn.QueryString = "select apptype, productid, PROD_SEQ from custproduct where ap_regno='" + dgListSPPK.Items[i].Cells[0].Text +
							"' AND isnull(cp_reject,'0') <> '1' and isnull(cp_cancel,'0') <> '1'";
						conn.ExecuteQuery();
						dt = conn.GetDataTable().Copy();

						/// Menghitung ulang Installment
						/// 
//						try 
//						{
//							reCalculateInstallment(dgListSPPK.Items[i].Cells[0].Text);
//						} 
//						catch (Exception ex1)
//						{
//							ExceptionHandling.Handler.saveExceptionIntoWindowsLog(ex1, Request.Path, dgListSPPK.Items[i].Cells[0].Text);
//							Response.Write("<!-- " + ex1.ToString() + " -->");
//						}


					
						for (int j = 0; j < dt.Rows.Count; j++)
						{
							conn.QueryString = "exec TRACKUPDATE '" + 
								dgListSPPK.Items[i].Cells[0].Text + "', '" +
								dt.Rows[j][1].ToString() + "', '" + 
								dt.Rows[j][0].ToString() + "', '" + 
								Session["UserID"].ToString() + "', '" + 
								dt.Rows[j]["prod_seq"].ToString() + "','"+ Request.QueryString["tc"].Trim() +"'";
							//conn.ExecuteNonQuery();
							conn.ExecTrans();

							if (i==0) 
							{ //ambil data pertama saja
								regno		= dgListSPPK.Items[i].Cells[0].Text; // regno
								//productid	= dt.Rows[j][1].ToString();
							}
							updateYes = true;
						}			 

						/// Membuat backup data aplikasi
						/// 
						conn.QueryString = "exec CHECK_BACKUP_DATA '" + dgListSPPK.Items[i].Cells[0].Text + "'";
						//conn.ExecuteNonQuery();
						conn.ExecTrans();


						conn.ExecTran_Commit();					
					}					
				} 
				catch (Exception exup)
				{
                    conn.ExecTran_Rollback();
                    countError++;
                    pesanError = pesanError + countError + " - " + dgListSPPK.Items[i].Cells[0].Text + "\\n";
                    try { ExceptionHandling.Handler.saveExceptionIntoWindowsLog(exup, Request.Path, pesanError); }
                    catch { }
				}

				try 
				{
					////////////////////////////////////////////////////////////////////////////////////////
					/// SCORING UPDATE
					/// 
					// --start -- by ashari 20041221
					//panggil fungsi update (accept) dari class updateScoring
					SME.Scoring.updateScoring x = new SME.Scoring.updateScoring(conn, dgListSPPK.Items[i].Cells[0].Text);
					x.CreateTextUpdateFIA(1);
					// --end -- by ashari 20041205						
				} 
				catch (Exception exscr) 
				{
					try { ExceptionHandling.Handler.saveExceptionIntoWindowsLog(exscr, Request.Path, "SPPK SCORING UPDATE ERR: " + dgListSPPK.Items[i].Cells[0].Text); } 
					catch {}
				}
			}

			if (countError > 0) 
			{
				GlobalTools.popMessage(this, pesanError);
			}
			// menampilkan pesan next step
			else if (updateYes)
			{
				string msg = getNextStepMsg1(regno);
				GlobalTools.popMessage(this, msg);
			}

			ViewData("0");
		}		

		private string getNextStepMsg1(string regno) 
		{
			string pesan = "";
			string nextTrack = "";
			try 
			{
				/***
				 * Memunculkan pesan next step
				 ***/
				conn.QueryString = "exec TRACKNEXTMSG1 NULL, '" + Request.QueryString["tc"] + "'";
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


		protected void Button1_Click(object sender, System.EventArgs e)
		{
			//--- Button di enable oleh Yudi (2004-08-23)
			//--- Q: Kenapa ya kok (di awal) tombolnya sudah ada, tapi di hide ???
			CheckBox chk;

			for (int i = 0; i < dgListSPPK.Items.Count; i++)
			{
				chk = (CheckBox) dgListSPPK.Items[i].Cells[6].FindControl("CheckBox1");
				
				if (chk.Checked == true)
				{
					DataTable dt;
					//conn.QueryString = "select apptype, productid from cust_product where ap_regno='" + dgListSPPK.Items[i].Cells[0].Text  + "'";
					conn.QueryString = "select cp.apptype, cp.productid, cp.cp_reject, cp.cp_cancel, cp.prod_seq from custproduct cp left join " + 
						"application ap on ap.ap_regno=cp.ap_regno where ap.ap_regno='" + dgListSPPK.Items[i].Cells[0].Text + "' and " + 
						"(isnull(cp.cp_reject, '0') <> '1' or isnull(cp.cp_cancel, '0')<> '1')";
					conn.ExecuteQuery();
					dt = conn.GetDataTable().Copy();
					for (int j = 0; j < dt.Rows.Count; j++)
					{
						conn.QueryString = "exec TRACKFAIL '" + dgListSPPK.Items[i].Cells[0].Text + "', '" +
											conn.GetFieldValue(j,1) + "', '" + 
											conn.GetFieldValue(j,0) + "', '" + 
											Session["UserID"].ToString() + "', '" + 
											conn.GetFieldValue(j, "prod_seq") + "','"+ Request.QueryString["tc"] +"'";
						conn.ExecuteNonQuery();
					}
					
					
					//////////////////////////////////////////////////////////////////////
					/// set flag appeal application, appeal_date, appeal_user
					/// 
					conn.QueryString = "update application set ap_isappeal = '1', ap_isappealdate = getdate(), ap_isappealby = '" + Session["UserID"] + "' where ap_regno = '" + dgListSPPK.Items[i].Cells[0].Text + "'";
					conn.ExecuteNonQuery();
					//////////////////////////////////////////////////////////////////////


					//////////////////////////////////////////////////////////////////////
					/// audit trail
					try
					{
						conn.QueryString = "SP_AUDITTRAIL_APP '" + 
							dgListSPPK.Items[i].Cells[0].Text + "',null,null,null,'" + 
							dgListSPPK.Items[i].Cells[1].Text + "','" + 
							Request.QueryString["tc"] + "','Appeal SPPK',"+ 
							"null" + ",'" +  
							Session["userid"].ToString() + "',null,null";
						conn.ExecuteNonQuery();
					}
					catch (Exception ex)
					{
						try { ExceptionHandling.Handler.saveExceptionIntoWindowsLog(ex, Request.Path, "AP_REGNO: " + dgListSPPK.Items[i].Cells[0].Text); } 
						catch {}
					}
					//////////////////////////////////////////////////////////////////////

					/*
					conn.QueryString = "exec TRACKFAIL '" + dgListSPPK.Items[i].Cells[0].Text + "', '" +
						dgListSPPK.Items[i].Cells[10].Text + "', '" + dgListSPPK.Items[i].Cells[11].Text + "', '" + Session["UserID"].ToString() + "'";
					conn.ExecuteNonQuery();
					*/
				}
			}

			ViewData("0");

			///////////////////////////////////////////////
			///	Prompt message
			///	
			string msg = "Application is appealed to Verification Assignment";
			GlobalTools.popMessage(this, msg);
		}

		protected void BTN_VER_ASSIGN_Click(object sender, System.EventArgs e)
		{
			//--- Button di enable oleh Yudi (2004-08-23)
			//--- Q: Kenapa ya kok (di awal) tombolnya sudah ada, tapi di hide ???
			CheckBox chk;

			for (int i = 0; i < dgListSPPK.Items.Count; i++)
			{
				chk = (CheckBox) dgListSPPK.Items[i].Cells[6].FindControl("CheckBox1");
				
				if (chk.Checked == true)
				{
					//////////////////////////////////////////////////////////////////////////////
					/// Mark this application as a-never-been-in-approval-application
					/// 
					/*
					conn.QueryString = "update CUSTPRODUCT set CP_DECSTA = '' " + 
						"where AP_REGNO = '"+dgListSPPK.Items[i].Cells[0].Text+"'";
					conn.ExecuteQuery();
					*/


					DataTable dt;
					//conn.QueryString = "select apptype, productid from cust_product where ap_regno='" + dgListSPPK.Items[i].Cells[0].Text  + "'";
					/*
					conn.QueryString = "select cp.apptype, cp.productid, cp.cp_reject, cp.cp_cancel, cp.prod_seq from custproduct cp left join " + 
						"application ap on ap.ap_regno=cp.ap_regno where ap.ap_regno='" + dgListSPPK.Items[i].Cells[0].Text + "' and " + 
						"(isnull(cp.cp_reject, '0') <> '1' or isnull(cp.cp_cancel, '0')<> '1')";
					*/

					conn.QueryString = "exec SPPK_GETPROD_BACKVA '" + dgListSPPK.Items[i].Cells[0].Text + "', '" + Request.QueryString["tc"] + "'";
					conn.ExecuteQuery();
					dt = conn.GetDataTable().Copy();
					for (int j = 0; j < dt.Rows.Count; j++)
					{						
						conn.QueryString = "exec TRACKBACK '" + 
							dgListSPPK.Items[i].Cells[0].Text + "', '" +
							dt.Rows[j][1].ToString() + "', '" + 
							dt.Rows[j][0].ToString() + "', '" + 
							Session["UserID"].ToString() + "', '" + 
							dt.Rows[j]["prod_seq"].ToString() + "'";
						conn.ExecuteNonQuery();
					}
					
					//////////////////////////////////////////////////////////////////////
					/// audit trail
					try
					{
						conn.QueryString = "SP_AUDITTRAIL_APP '" + 
							dgListSPPK.Items[i].Cells[0].Text + "', null, null, null, '" + 
							dt.Rows[0]["CU_REF"].ToString() + "','" + 
							Request.QueryString["tc"] + "','Back to Ver Assignment', " + 
							"null" + ", '" +  
							Session["userid"].ToString() + "',null,null";
						conn.ExecuteNonQuery();
					}
					catch (Exception ex)
					{
						try { ExceptionHandling.Handler.saveExceptionIntoWindowsLog(ex, Request.Path, dgListSPPK.Items[i].Cells[0].Text + " Back to VA"); } 
						catch {}
					}			
				}
			}

			ViewData("0");

			///////////////////////////////////////////////
			///	Prompt message
			///	
			string msg = "Application is Back to Verification Assignment";
			GlobalTools.popMessage(this, msg);
		}
	}
}
