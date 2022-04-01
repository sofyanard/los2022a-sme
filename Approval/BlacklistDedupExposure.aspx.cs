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

namespace SME.Approval
{
	/// <summary>
	/// Summary description for BlacklistDedupExposure.
	/// </summary>
	public partial class BlacklistDedupExposure : System.Web.UI.Page
	{
		protected Connection conn, conn2;
		private string cold_prospectid, prog, tc, exist, FIRST_NM, MID_NM, LAST_NM, DOB, ID_CARD, cu_mmnm, cu_cif, cu_sex;
		string from, userid, group, ismitrakarya, cp_loanamount, cp_decloanamount, cu_mitracomp, cu_type, IDTYPE;
		private string ap_regno, regno, curef, mc, msg, cp_decinterest, cp_decinstallment, childinstallment, childint;
		private DataTable dt_cc;
		
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			conn = new Connection((string)Session["ConnString"]);
			conn2 = new Connection(System.Configuration.ConfigurationSettings.AppSettings["ConnBDE"]);
			cold_prospectid = Request.QueryString["COLD_PROSPECTID"]; 
			tc = Request.QueryString["tc"];
//			compcode = Request.QueryString["compcode"];
			regno = Request.QueryString["regno"];
			curef = Request.QueryString["curef"];
			mc = Request.QueryString["mc"];
			prog = Request.QueryString["prog"];
			exist = Request.QueryString["exist"];
			from = (string)Request.QueryString["from"];
			userid	= (string)Session["UserID"];
			group = (string)Session["GroupID"];
		
			if (!IsPostBack)
			{
				viewData();
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
			this.dg_list.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.dg_list_PageIndexChanged);
			this.dg_Dedup.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.dg_Dedup_PageIndexChanged);
			this.dg_exposure.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.dg_exposure_PageIndexChanged);

		}
		#endregion


		private void viewData()
		{
			if(from == "Approval")
			{
				btn_rechecking.Visible = true;
				btn_reject.Visible = false;	
			}
			
			#region Blacklist
			try
			{
				conn.QueryString = "exec delete_blacklist '"+regno+"'";
				conn.ExecuteQuery();

				conn.QueryString = "EXEC BDE_CHECKING '"+from+"', '"+regno+"', 'BL'";
				conn.ExecuteQuery();

				for(int j = 0; j< conn.GetRowCount(); j++)
				{
					ap_regno = conn.GetFieldValue(j, "AP_REGNO").Trim();
					FIRST_NM = conn.GetFieldValue(j,"first_nm").Trim(); 
					MID_NM	= conn.GetFieldValue(j,"mid_nm").Trim(); 
					LAST_NM = conn.GetFieldValue(j,"last_nm").Trim(); 
					DOB = conn.GetFieldValue(j,"dob").Trim();
					ID_CARD = conn.GetFieldValue(j,"id_card").Trim();
					cu_mmnm = conn.GetFieldValue(j,"cu_mmnm").Trim();
					cu_sex = conn.GetFieldValue(j,"cu_sex").Trim();
					cu_type = conn.GetFieldValue(j,"cu_type").Trim();
					cu_cif = conn.GetFieldValue(j,"cu_cif");
					IDTYPE = conn.GetFieldValue(j,"IDTYPE").Trim();
		
					conn2.QueryString = "exec SP_CENTRALDBCHECKINGPROCESS 'BL', 'LOSSME', 'APR', '"+ap_regno+"', '"+cu_type+"', '"+cu_cif+"', '"+FIRST_NM+"', '"+MID_NM+"', '"+LAST_NM+"', '"+DOB+"', '"+cu_sex+"', '"+IDTYPE+"', '"+
						ID_CARD+"', '"+cu_mmnm+"'";
					conn2.ExecuteQuery();

					if (conn2.GetRowCount()!=0)
					{
						dt_cc = new DataTable();	
						dt_cc = conn2.GetDataTable().Copy();
					
						if(dt_cc.Rows.Count > 0)
						{
							for(int i = 0; i < dt_cc.Rows.Count; i++)
							{
								string SEQ, EXACTMATCH_DESC, REMARK, BL_NAME, BL_IDTYPE, BL_IDNUMBER,  
									BL_SOURCE, BL_ADDRESS1, BL_ADDRESS2, BL_ADDRESS3, BL_ADDRESS4,
									BL_STARTDATE_dd, BL_STARTDATE_mm, BL_STARTDATE_yy;
							
								SEQ = dt_cc.Rows[i]["SEQ"].ToString().Trim();
								EXACTMATCH_DESC = dt_cc.Rows[i]["EXACTMATCH_DESC"].ToString().Trim();
								REMARK = dt_cc.Rows[i]["REMARK"].ToString().Trim();
								BL_NAME = dt_cc.Rows[i]["BL_NAME"].ToString().Trim();
								BL_IDTYPE = dt_cc.Rows[i]["BL_IDTYPE"].ToString().Trim();
								BL_IDNUMBER = dt_cc.Rows[i]["BL_IDNUMBER"].ToString().Trim();  
								BL_SOURCE = dt_cc.Rows[i]["BL_SOURCE"].ToString().Trim();
								BL_ADDRESS1 = dt_cc.Rows[i]["BL_ADDRESS1"].ToString().Trim();
								BL_ADDRESS2 = dt_cc.Rows[i]["BL_ADDRESS2"].ToString().Trim();
								BL_ADDRESS3 = dt_cc.Rows[i]["BL_ADDRESS3"].ToString().Trim();
								BL_ADDRESS4 = dt_cc.Rows[i]["BL_ADDRESS4"].ToString().Trim();
								BL_STARTDATE_dd = GlobalTools.FormatDate_Day(dt_cc.Rows[i]["BL_STARTDATE"].ToString().Trim());
								BL_STARTDATE_mm = GlobalTools.FormatDate_Month(dt_cc.Rows[i]["BL_STARTDATE"].ToString().Trim());
								BL_STARTDATE_yy = GlobalTools.FormatDate_Year(dt_cc.Rows[i]["BL_STARTDATE"].ToString().Trim());

								conn.QueryString = "exec INSERT_BLACKLIST '"+ap_regno+"', '"+SEQ+"', '"+EXACTMATCH_DESC+"', '"+REMARK+"', '"+BL_NAME.Replace("'","''")+"', '"+
									BL_IDTYPE+"', '"+BL_IDNUMBER+"', '"+BL_SOURCE+"', '"+BL_ADDRESS1.Replace("'","''")+"', '"+BL_ADDRESS2.Replace("'","''")+"', '"+
									BL_ADDRESS3.Replace("'","''")+"', '"+BL_ADDRESS4.Replace("'","''")+"', "+GlobalTools.ConvertDate(BL_STARTDATE_dd,BL_STARTDATE_mm,BL_STARTDATE_yy)+"";
								conn.ExecuteQuery();
							
							}
						}
					

					}
				
				}
				viewBlacklist(regno);
			}
			catch (Exception ex)
			{
				Response.Write("<!--" + ex.Message + "-->");
			}
			#endregion Blacklist

			#region Duplicate Checking
			try
			{
				conn.QueryString = "exec delete_dedup '"+regno+"'";
				conn.ExecuteQuery();

				conn.QueryString = "EXEC BDE_CHECKING '"+from+"', '"+regno+"', 'DEDUP'";
				conn.ExecuteQuery();

				for(int j = 0; j< conn.GetRowCount(); j++)
				{
					ap_regno = conn.GetFieldValue(j, "AP_REGNO").Trim();
					FIRST_NM = conn.GetFieldValue(j,"first_nm").Trim(); 
					MID_NM	= conn.GetFieldValue(j,"mid_nm").Trim(); 
					LAST_NM = conn.GetFieldValue(j,"last_nm").Trim(); 
					DOB = conn.GetFieldValue(j,"dob").Trim();
					ID_CARD = conn.GetFieldValue(j,"id_card").Trim();
					cu_mmnm = conn.GetFieldValue(j,"cu_mmnm").Trim();
					cu_sex = conn.GetFieldValue(j,"cu_sex").Trim();
					cu_type = conn.GetFieldValue(j,"cu_type").Trim();
					cu_cif = conn.GetFieldValue(j,"cu_cif");
					IDTYPE = conn.GetFieldValue(j,"IDTYPE").Trim();

					conn2.QueryString = "exec SP_CENTRALDBCHECKINGPROCESS 'DEDUP', 'LOSSME', 'APR', '"+ap_regno+"', '"+cu_type+"', '"+cu_cif+"', '"+FIRST_NM+"', '"+MID_NM+"', '"+LAST_NM+"', '"+DOB+"', '"+cu_sex+"', '"+IDTYPE+"', '"+
						ID_CARD+"', '"+cu_mmnm+"'";
					conn2.ExecuteQuery();
		
					if (conn2.GetRowCount()!=0)
					{
						dt_cc = new DataTable();	
						dt_cc = conn2.GetDataTable().Copy();
			
						if(dt_cc.Rows.Count > 0)
						{
							for(int i = 0; i < dt_cc.Rows.Count; i++)
							{
								string AP_REGNO, AP_SEQ, CU_REF, CU_CIF, EXACTMATCH, REMARK, CU_NAME, 
									CU_BORNDATE_dd, CU_BORNDATE_mm, CU_BORNDATE_yy, CU_SEX, CU_IDTYPE, 
									CU_IDNUMBER, CU_MOTHERNAME, CU_ADDRESS, MODULENAME, AP_RECVDATE_dd, 
									AP_RECVDATE_mm, AP_RECVDATE_yy, AP_PRODUCT, AP_AMOUNT,
									AP_TENOR, AP_INTEREST, AP_INSTALMENT, AP_STATUS;

								AP_REGNO = dt_cc.Rows[i]["AP_REGNO"].ToString().Trim();
								AP_SEQ = dt_cc.Rows[i]["AP_SEQ"].ToString().Trim();
								CU_REF = dt_cc.Rows[i]["CU_REF"].ToString().Trim();
								CU_CIF = dt_cc.Rows[i]["CU_CIF"].ToString().Trim();
								EXACTMATCH = dt_cc.Rows[i]["EXACTMATCH"].ToString().Trim();
								REMARK = dt_cc.Rows[i]["REMARK"].ToString().Trim();
								CU_NAME = dt_cc.Rows[i]["CU_NAME"].ToString().Trim();
								CU_BORNDATE_dd  = GlobalTools.FormatDate_Day(dt_cc.Rows[i]["CU_BORNDATE"].ToString().Trim()); 
								CU_BORNDATE_mm  = GlobalTools.FormatDate_Month(dt_cc.Rows[i]["CU_BORNDATE"].ToString().Trim());
								CU_BORNDATE_yy = GlobalTools.FormatDate_Year(dt_cc.Rows[i]["CU_BORNDATE"].ToString().Trim());
								CU_SEX = dt_cc.Rows[i]["CU_SEX"].ToString().Trim();
								CU_IDTYPE = dt_cc.Rows[i]["CU_IDTYPE"].ToString().Trim();
								CU_IDNUMBER = dt_cc.Rows[i]["CU_IDNUMBER"].ToString().Trim();
								CU_MOTHERNAME = dt_cc.Rows[i]["CU_MOTHERNAME"].ToString().Trim();
								CU_ADDRESS = dt_cc.Rows[i]["CU_ADDRESS"].ToString().Trim();
								MODULENAME = dt_cc.Rows[i]["MODULENAME"].ToString().Trim();
								AP_RECVDATE_dd = GlobalTools.FormatDate_Day(dt_cc.Rows[i]["AP_RECVDATE"].ToString().Trim());
								AP_RECVDATE_mm = GlobalTools.FormatDate_Month(dt_cc.Rows[i]["AP_RECVDATE"].ToString().Trim()); 
								AP_RECVDATE_yy = GlobalTools.FormatDate_Year(dt_cc.Rows[i]["AP_RECVDATE"].ToString().Trim());
								AP_PRODUCT = dt_cc.Rows[i]["AP_PRODUCT"].ToString().Trim();
								AP_AMOUNT = dt_cc.Rows[i]["AP_AMOUNT"].ToString().Trim();
								AP_TENOR = dt_cc.Rows[i]["AP_TENOR"].ToString().Trim();
								AP_INTEREST = dt_cc.Rows[i]["AP_INTEREST"].ToString().Trim().Replace(",",".");
								AP_INSTALMENT = dt_cc.Rows[i]["AP_INSTALMENT"].ToString().Trim();
								AP_STATUS = dt_cc.Rows[i]["AP_STATUS"].ToString().Trim();

								conn.QueryString = "exec INSERT_DEDUP '"+ap_regno+"', '"+AP_REGNO+"', '"+AP_SEQ+"', '"+CU_REF+"', '"+
									CU_CIF+"', '"+EXACTMATCH+"', '"+REMARK+"', '"+CU_NAME+"', "+
									GlobalTools.ConvertDate(CU_BORNDATE_dd, CU_BORNDATE_mm, CU_BORNDATE_yy)+", '"+
									CU_SEX+"', '"+CU_IDTYPE+"', '"+CU_IDNUMBER+"', '"+CU_MOTHERNAME+"', '"+
									CU_ADDRESS+"', '"+MODULENAME+"', "+GlobalTools.ConvertDate(AP_RECVDATE_dd,AP_RECVDATE_mm,AP_RECVDATE_yy)+", '"+
									AP_PRODUCT+"', "+GlobalTools.ConvertFloat(AP_AMOUNT)+", '"+AP_TENOR+"', "+GlobalTools.ConvertFloat(AP_INTEREST)+", "+
									GlobalTools.ConvertFloat(AP_INSTALMENT)+", '"+AP_STATUS+"'";
								conn.ExecuteQuery();
							}
						}
			
					
					}
			
				}
				viewDedup(regno);
			}
			catch (Exception ex)
			{
				Response.Write("<!--" + ex.Message + "-->");
			}
			#endregion Duplicate Checking
				
			#region Exposure
			try
			{
				conn.QueryString = "EXEC BDE_CHECKING '"+from+"', '"+regno+"', 'BL'";
				conn.ExecuteQuery();

				for(int j = 0; j< conn.GetRowCount(); j++)
				{
					ap_regno = conn.GetFieldValue(j, "AP_REGNO").Trim();
					FIRST_NM = conn.GetFieldValue(j,"first_nm").Trim(); 
					MID_NM	= conn.GetFieldValue(j,"mid_nm").Trim(); 
					LAST_NM = conn.GetFieldValue(j,"last_nm").Trim(); 
					DOB = conn.GetFieldValue(j,"dob").Trim();
					ID_CARD = conn.GetFieldValue(j,"id_card").Trim();
					cu_mmnm = conn.GetFieldValue(j,"cu_mmnm").Trim();
					cu_sex = conn.GetFieldValue(j,"cu_sex").Trim();
					cu_type = conn.GetFieldValue(j,"cu_type").Trim();
					cu_cif = conn.GetFieldValue(j,"cu_cif");
					IDTYPE = conn.GetFieldValue(j,"IDTYPE").Trim();

					conn2.QueryString = "exec SP_CENTRALDBCHECKINGEXPOSURE 'LOSSME', 'APR', '"+curef+"', '"+ap_regno+"', 1, '"+cu_type+"', '"+cu_cif+"', '"+FIRST_NM+"', '"+MID_NM+"', '"+LAST_NM+"', '"+DOB+"', '"+cu_sex+"', '"+IDTYPE+"', '"+
						ID_CARD+"', '"+cu_mmnm+"'";
					conn2.ExecuteQuery();
	
					if(conn2.GetRowCount() != 0)
					{
						string cucif = conn2.GetFieldValue("cif");
						conn.QueryString = "exec delete_EXPOSURE '"+ap_regno+"'";
						conn.ExecuteQuery();

						dt_cc = new DataTable();	
						dt_cc = conn2.GetDataTable().Copy();		
	
						if(dt_cc.Rows.Count > 0)					
						{
							for(int i = 0; i < dt_cc.Rows.Count; i++)
							{
								string CIF, NAME, NOREKENING, LIMITKREDIT, BAKIDEBET, STATUSREKENING, KOLEKBILITAS, JENISKREDIT;
								
								CIF = dt_cc.Rows[i]["CIF"].ToString().Trim();
								NAME = dt_cc.Rows[i]["NAME"].ToString().Trim();
								NOREKENING = dt_cc.Rows[i]["NOREKENING"].ToString().Trim();
								LIMITKREDIT = dt_cc.Rows[i]["LIMITKREDIT"].ToString().Trim();
								BAKIDEBET = dt_cc.Rows[i]["BAKIDEBET"].ToString().Trim();
								STATUSREKENING = dt_cc.Rows[i]["STATUSREKENING"].ToString().Trim();
								KOLEKBILITAS = dt_cc.Rows[i]["KOLEKBILITAS"].ToString().Trim();
								JENISKREDIT = dt_cc.Rows[i]["JENISKREDIT"].ToString().Trim();
								
								conn.QueryString = "exec insert_exposure '"+ap_regno+"', '"+CIF+"', '"+NOREKENING+"', '"+NAME+"', '"+LIMITKREDIT+"', '"+BAKIDEBET+"', '"+STATUSREKENING+"', '"+KOLEKBILITAS+"', '"+JENISKREDIT+"'";
								conn.ExecuteQuery();
							}
						}
					
					}
				}
				viewExposure(ap_regno);
			}
			catch (Exception ex)
			{
				Response.Write("<!--" + ex.Message + "-->");
			}
			#endregion Exposure

		}


		private void viewBlacklist(string ap_regno)
		{
			try
			{
				conn.QueryString = "exec SP_VW_BLACKLIST '"+ap_regno+"' ";	
				conn.ExecuteQuery();

				if(conn.GetRowCount() > 0)
				{
					/*	if(conn.GetFieldValue("EXACTMATCH_DESC") == "Exact Match")
						{
							btn_continue.Visible = false;
						}*/
					dt_cc = new DataTable();
					dt_cc = conn.GetDataTable().Copy();

					dg_list.DataSource = dt_cc;
					try
					{
						dg_list.DataBind();
					}
					catch
					{
						dg_list.CurrentPageIndex = 0;
						dg_list.DataBind();
					}

					for (int i = 0; i < dg_list.Items.Count; i++)
					{
						HyperLink hlSelect = (HyperLink) dg_list.Items[i].FindControl("view");
						string varUrl = "BlacklistCDBDetail.aspx?regno="+dg_list.Items[i].Cells[0].Text+"&seq="+
							dg_list.Items[i].Cells[1].Text;
						hlSelect.NavigateUrl = "javascript:PopupPage('" +varUrl+ "',450,350)";
					}
				}
			}
			catch (Exception ex)
			{
				Response.Write("<!--" + ex.Message + "-->");
			}
		}


		private void viewDedup(string ap_Regno)
		{
			try
			{
				conn.QueryString = "exec SP_VW_DEDUP '"+ap_Regno+"'";
				conn.ExecuteQuery();

				dt_cc = new DataTable();
				dt_cc = conn.GetDataTable().Copy();

				dg_Dedup.DataSource = dt_cc;
				try
				{
					dg_Dedup.DataBind();
				}
				catch
				{
					dg_Dedup.CurrentPageIndex = 0;
					dg_Dedup.DataBind();
				}

				for (int i = 0; i < dg_Dedup.Items.Count; i++)
				{
					HyperLink hlSelect = (HyperLink) dg_Dedup.Items[i].FindControl("view1");
					string varUrl = "DedupCDBDetail.aspx?regno="+dg_Dedup.Items[i].Cells[0].Text+"&regno_CDB="+dg_Dedup.Items[i].Cells[1].Text+
						"&seq="+dg_Dedup.Items[i].Cells[2].Text;
					hlSelect.NavigateUrl = "javascript:PopupPage('" +varUrl+ "',575,550)";
				}
			}
			catch (Exception ex)
			{
				Response.Write("<!--" + ex.Message + "-->");
			}
		}


		private void viewExposure(string ap_regno)
		{
			try
			{
				conn.QueryString = "exec SP_VW_EXPOSURE '"+ap_regno+"'";
				conn.ExecuteQuery();

				dt_cc = new DataTable();
				dt_cc = conn.GetDataTable().Copy();

				dg_exposure.DataSource = dt_cc;
				try
				{
					dg_exposure.DataBind();
				}
				catch
				{
					dg_exposure.CurrentPageIndex = 0;
					dg_exposure.DataBind();
				}
			}
			catch (Exception ex)
			{
				Response.Write("<!--" + ex.Message + "-->");
			}
		}


        protected void btn_continue_Click(object sender, System.EventArgs e)
		{
			if (from == "IDE")
			{
				Response.Redirect("../BlackList/BL_result.aspx?regno=" + 
					Request.QueryString["regno"] + "&curef=" + 
					Request.QueryString["curef"] + "&prog=" + 
					Request.QueryString["prog"] + "&tc=" + 
					Request.QueryString["tc"] + "&mc=" + 
					Request.QueryString["mc"] + "&exist=" + 
					Request.QueryString["exist"]);
			}
			else if(from == "Approval")
			{
				Response.Redirect("../Approval/Approval.aspx?regno="+regno+"&curef="+curef+ 
					"&mc=" + mc + "&tc=" + tc);
			}

		}


		protected void btn_reject_Click(object sender, System.EventArgs e)
		{
			if (from == "IDE")
			{
				try 
				{
					string sql = "update APPLICATION set AP_REJECT = '1' where AP_REGNO = '"+Request.QueryString["regno"]+"' ";
					conn.QueryString = sql;
					conn.ExecTrans();
					//conn.ExecuteNonQuery();

					conn.QueryString = "exec RJ_CHECKREJECT '" + Request.QueryString["regno"] + "', '" + Request.QueryString["curef"] + "'";
					conn.ExecTrans();
					//conn.ExecuteNonQuery();

					/// Membuat backup data aplikasi
					/// 
					conn.QueryString = "exec CHECK_BACKUP_DATA '" + Request.QueryString["regno"] + "'";
					conn.ExecTrans();


					/// Audit Trail
					/// 

					//ahmad
					conn.QueryString = "SP_AUDITTRAIL_APP '" + 
						Request.QueryString["regno"] + "',null,null,null,'" + 
						Request.QueryString["curef"] + "', '" + 
						Request.QueryString["tc"] + "','Application Reject', "+ 
						"null, '" +  
						Session["UserID"].ToString() + "',null,null";
					conn.ExecTrans();


					conn.ExecTran_Commit();	// commit transaction

					Response.Redirect("../letters/RejectLetterAll.aspx?regno=" + Request.QueryString["regno"] + "&curef=" + Request.QueryString["curef"] + "&tc=" + Request.QueryString["tc"] + "&mc=" + Request.QueryString["mc"] + "&prod=&apptype=");
				} 
				catch 
				{
					conn.ExecTran_Rollback();
				}
			}

		}

		protected void btn_rechecking_Click(object sender, System.EventArgs e)
		{
			viewData();
		}

		private void dg_list_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			dg_list.CurrentPageIndex = e.NewPageIndex;			
			viewBlacklist(regno);
		}

		private void dg_Dedup_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			dg_Dedup.CurrentPageIndex = e.NewPageIndex;
			viewDedup(regno);
		}

		private void dg_exposure_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			dg_exposure.CurrentPageIndex = e.NewPageIndex;
			viewExposure(regno);
		}



	}
}
