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
using Microsoft.VisualBasic;
using System.IO;
using System.Diagnostics;

namespace SME.AccountPlanning.AccountPlanSetup
{
	/// <summary>
	/// Summary description for SnapShot.
	/// </summary>
	public partial class SnapShot : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.PlaceHolder SubMenu;
		protected Tools tool = new Tools();
		protected System.Web.UI.WebControls.TextBox TXT_B13;
		protected System.Web.UI.WebControls.TextBox TXT_C13;
		protected System.Web.UI.WebControls.TextBox TXT_D13;
		protected System.Web.UI.WebControls.TextBox TXT_E13;

		protected Connection conn;
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			conn = new Connection(ConfigurationSettings.AppSettings["conn"]);

			if(!IsPostBack)
			{
				/*viewdata();
				viewdata_history();
				isi_initial();		
				retrieve_data_neraca();*/

				/*selain neraca*/
				fillAllDDL();
				ClearAllField();
				BindAllGrid();
				ViewUploadFiles();
			}

			ViewMenu();
			TXT_TGL_B1.Text = "01";
			DDL_BLN_B1.SelectedValue = "1";
			TXT_TGL_C1.Text = "01";
			DDL_BLN_C1.SelectedValue = "1";
			TXT_TGL_D1.Text = "01";
			DDL_BLN_D1.SelectedValue = "1";
			TXT_TGL_E1.Text = "01";
			DDL_BLN_E1.SelectedValue = "1";
			//ViewSubMenu();
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
			this.DG_FinancialKey.ItemCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.DG_FinancialKey_ItemCommand);
			this.DGR_SCENARIO.ItemCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.DGR_SCENARIO_ItemCommand);
			this.DGR_SCENARIO.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.DGR_SCENARIO_PageIndexChanged);
			this.StrategiesToGrowAnchors.ItemCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.StrategiesToGrowAnchors_ItemCommand);
			this.StrategiesToGrowAnchors.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.StrategiesToGrowAnchors_PageIndexChanged);
			this.DATA_UPLOAD.ItemCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.DATA_UPLOAD_ItemCommand);
			this.DATA_UPLOAD.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.DATA_UPLOAD_PageIndexChanged);

		}
		#endregion

		private void DG_Neraca1_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			string cmd = e.CommandName;
			
			switch (cmd)
			{
				case "retrieve" :
					string vtemp = e.Item.Cells[3].Text;
					//Response.Redirect("Neraca_KMK_KI_Medium.aspx?tahun=" + vtemp +"&mode=retrieve&regno="+Request.QueryString["regno"]+"&mc="+Request.QueryString["mc"]+"&bussunitid="+Request.QueryString["bussunitid"]+"&programid="+Request.QueryString["programid"]+"&jnsnasabah="+Request.QueryString["jnsnasabah"]+"&curef="+Request.QueryString["curef"]+"&tc="+Request.QueryString["tc"]+"&viewmode="+Request.QueryString["viewmode"]+"&lmsreg="+Request.QueryString["lmsreg"]+"&scr="+Request.QueryString["scr"]);
					Response.Redirect("SnapShot.aspx?tahun=" + vtemp +"&mode=retrieve&mc=" + Request.QueryString["mc"]+ "&cif=" + Request.QueryString["cif"] + "&bs=" + Request.QueryString["bs"] + "&bc=" + Request.QueryString["bc"] + "&rd=" + Request.QueryString["rd"] + "&cd=" + Request.QueryString["cd"]);
					clear_field();
					retrieve_data_neraca();
					
					break;
				default :
					break;
			}
		}

		protected void BTN_SAVE_BUSINESS_AND_STRATEGY_Click(object sender, System.EventArgs e)
		{
			conn.QueryString = "EXEC AP_INSERT_BUSINESS_AND_STRATEGY '" + Request.QueryString["cif"] + "','" + TXT_DESCRIPTION_OF_BUSINESS.Text.ToString() + "','" + TXT_CLIENTS_STRATEGY_AND_PRIORITIES.Text.ToString() + "','" + TXT_RECENT_DEVELOPMENTS.Text.ToString() + "','" + TXT_IMPLICATIONS_FOR_MANDIRI.Text.ToString() + "'";
			conn.ExecuteQuery();

			//RETRIEVE_BUSINESS_AND_STRATEGY(Request.QueryString["cif"]);
			BindAllGrid();
		}

		private void RETRIEVE_BUSINESS_AND_STRATEGY(string CIF)
		{
			conn.QueryString = "SELECT * FROM VW_AP_BUSINESS_AND_STRATEGY WHERE CU_CIF = '" + CIF + "'";
			conn.ExecuteQuery();

			TXT_DESCRIPTION_OF_BUSINESS.Text = conn.GetFieldValue("DESCRIPTION_OF_BUSINESS");
			TXT_CLIENTS_STRATEGY_AND_PRIORITIES.Text = conn.GetFieldValue("CLIENT_STRATEGY_AND_PRIORITIES");
			TXT_RECENT_DEVELOPMENTS.Text = conn.GetFieldValue("RECENT_DEVELOPMENTS");
			TXT_IMPLICATIONS_FOR_MANDIRI.Text = conn.GetFieldValue("IMPLICATIONS_FOR_MANDIRI");
		}

		private void DGR_SCENARIO_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			switch(((LinkButton)e.CommandSource).CommandName)
			{
				case "edit":
					string CIF = e.Item.Cells[0].Text.Trim();
					string ID_AP_VARIABLE = e.Item.Cells[1].Text.Trim();
					RETRIEVE_COMPETITIVE_SCAN(CIF, ID_AP_VARIABLE);
					break;
				case "delete":
					CIF = e.Item.Cells[0].Text.Trim();
					ID_AP_VARIABLE = e.Item.Cells[1].Text.Trim();
					conn.QueryString = "DELETE AP_COMPETITIVE_SCAN WHERE CU_CIF = '" + CIF + "' AND ID_AP_VARIABLE = '" + ID_AP_VARIABLE + "'";
					conn.ExecuteQuery();
					
					//bindhere
					BindData(DGR_SCENARIO, "SELECT AP_VARIABLE.DESCRIPTION as product,* FROM AP_COMPETITIVE_SCAN, AP_VARIABLE WHERE CU_CIF = '" + Request.QueryString["CIF"] + "' AND  AP_VARIABLE.ID_AP_VARIABLE = AP_COMPETITIVE_SCAN.ID_AP_VARIABLE");
					BindDGRScenario();
					break;
			}
		}

		private void BindDGRScenario()
		{
			for(int i=0; i< DGR_SCENARIO.Items.Count; i++)
			{
				//dari sini pake index
				/*** DropDownList Assign To ***/
				conn.QueryString = "SELECT * FROM AP_COMPETITIVE_SCAN WHERE CU_CIF = '" + DGR_SCENARIO.Items[i].Cells[0].Text.ToString() + "' AND ID_AP_VARIABLE = '" + DGR_SCENARIO.Items[i].Cells[1].Text.ToString() + "'";
				conn.ExecuteQuery();

				System.Web.UI.WebControls.TextBox txt = (System.Web.UI.WebControls.TextBox) DGR_SCENARIO.Items[i].Cells[3].FindControl("TXT_PRIMARY_BANK_GRID");
				if(txt != null)
				{
					txt.Text = conn.GetFieldValue("PRIMARY_BANK");
				}

				txt = (System.Web.UI.WebControls.TextBox) DGR_SCENARIO.Items[i].Cells[4].FindControl("TXT_OTHER_BANKS_GRID");
				if(txt != null)
				{
					txt.Text = conn.GetFieldValue("OTHER_BANKS");
				}
			}
		}

		private void RETRIEVE_COMPETITIVE_SCAN(string CIF, string ID_AP_VARIABLE)
		{
			conn.QueryString = "SELECT * FROM VW_AP_COMPETITION_SCAN WHERE CU_CIF = '" + CIF + "' AND ID_AP_VARIABLE = '" + ID_AP_VARIABLE + "'";
			conn.ExecuteQuery();

			DDL_PRODUCT.SelectedValue = conn.GetFieldValue("ID_AP_VARIABLE");
			TXT_PRIMARY_BANK.Text = conn.GetFieldValue("PRIMARY_BANK");
			TXT_OTHER_BANK.Text = conn.GetFieldValue("OTHER_BANKS");
		}

		protected void BTN_SAVE_COMPITIVE_Click(object sender, System.EventArgs e)
		{
			conn.QueryString = "EXEC AP_INSERT_AP_COMPETITIVE_SCAN '" + Request.QueryString["cif"] + "','" + DDL_PRODUCT.SelectedValue.ToString() + "','" + TXT_PRIMARY_BANK.Text + "','" + TXT_OTHER_BANK.Text + "'";
			conn.ExecuteQuery();

			BindData(DGR_SCENARIO, "SELECT AP_VARIABLE.DESCRIPTION as product,* FROM AP_COMPETITIVE_SCAN, AP_VARIABLE WHERE CU_CIF = '" + Request.QueryString["CIF"] + "' AND  AP_VARIABLE.ID_AP_VARIABLE = AP_COMPETITIVE_SCAN.ID_AP_VARIABLE");
			BindDGRScenario();

			DDL_PRODUCT.SelectedValue = "";
			TXT_PRIMARY_BANK.Text = "";
			TXT_OTHER_BANK.Text = "";
		}

		private void StrategiesToGrowAnchors_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			switch(((LinkButton)e.CommandSource).CommandName)
			{
				case "edit":
					string SEQ = e.Item.Cells[1].Text.Trim();
					string CIF = e.Item.Cells[0].Text.Trim();
					RETRIEVE_StrategiesToGrowAnchors(CIF, SEQ);
					break;
				case "delete":
					SEQ = e.Item.Cells[1].Text.Trim();
					CIF = e.Item.Cells[0].Text.Trim();
					conn.QueryString = "DELETE AP_STRATEGIES_TO_GROW_ANCHORS WHERE CU_CIF = '" + CIF + "' AND SEQ = '" + SEQ + "'";
					conn.ExecuteQuery();
					
					//bindhere
					BindData(StrategiesToGrowAnchors, "SELECT * FROM AP_STRATEGIES_TO_GROW_ANCHORS WHERE CU_CIF = '" + CIF + "' ORDER BY SEQ ASC");
					BindSTRATEGIES_TO_GROW_ANCHORS();
					break;
			}
		}

		private void RETRIEVE_StrategiesToGrowAnchors(string CIF, string SEQ)
		{
			conn.QueryString = "SELECT * FROM VW_AP_AP_STRATEGIES_TO_GROW_ANCHORS WHERE CU_CIF = '" + CIF + "' AND SEQ = '" + SEQ + "'";
			conn.ExecuteQuery();

			TXT_SEQ_GROW_ANCHORS.Text = conn.GetFieldValue("SEQ");
			TXT_KEY_SUPPORT_NEEDED.Text = conn.GetFieldValue("KEY_SUPPORT_NEEDED");
		}

		protected void BTN_SAVE_STRATEGIES_TO_GROW_ANCHORS_Click(object sender, System.EventArgs e)
		{
			conn.QueryString = "EXEC AP_INSERT_AP_STRATEGIES_TO_GROW_ANCHORS '" + TXT_SEQ_GROW_ANCHORS.Text + "','" + Request.QueryString["CIF"]  + "','" + TXT_KEY_SUPPORT_NEEDED.Text.ToString() + "'";
			conn.ExecuteQuery();

			TXT_SEQ_GROW_ANCHORS.Text = "";

			BindData(StrategiesToGrowAnchors, "SELECT * FROM AP_STRATEGIES_TO_GROW_ANCHORS WHERE CU_CIF = '" + Request.QueryString["cif"] + "' ORDER BY SEQ ASC");
			BindSTRATEGIES_TO_GROW_ANCHORS();
		}

		private void BindSTRATEGIES_TO_GROW_ANCHORS()
		{
			for(int i=0; i< StrategiesToGrowAnchors.Items.Count; i++)
			{
				//dari sini pake index
				/*** DropDownList Assign To ***/
				conn.QueryString = "SELECT * FROM AP_STRATEGIES_TO_GROW_ANCHORS WHERE CU_CIF = '" + StrategiesToGrowAnchors.Items[i].Cells[0].Text.ToString() + "' AND SEQ = '" + StrategiesToGrowAnchors.Items[i].Cells[1].Text.ToString() + "'";
				conn.ExecuteQuery();

				System.Web.UI.WebControls.TextBox txt = (System.Web.UI.WebControls.TextBox) StrategiesToGrowAnchors.Items[i].Cells[2].FindControl("TXT_KEY_SUPPORT");
				if(txt != null)
				{
					txt.Text = conn.GetFieldValue("KEY_SUPPORT_NEEDED");
				}
			}
		}
		
		/* HOME MADE FUNCTION */
		private void viewdata()
		{
			/*conn.QueryString = "select distinct BS_DATE_PERIODE,BS_NUM_MONTH,BS_REPORTTYPE,year(BS_DATE_PERIODE) tahun,BS_CURRENCY,BS_DENOMINATOR from CA_NERACA_MIDDLE where ap_regno = '"+ Request.QueryString["regno"]+ "' order by BS_DATE_PERIODE desc";
			conn.ExecuteQuery();*/

			conn.QueryString = "select distinct BS_DATE_PERIODE,BS_NUM_MONTH,BS_REPORTTYPE,year(BS_DATE_PERIODE) tahun,BS_CURRENCY,BS_DENOMINATOR from CA_NERACA_MIDDLE where ap_regno = '14072008COR1000001' order by BS_DATE_PERIODE desc";
			conn.ExecuteQuery();

			/*DG_FinancialKey*/
			
			/*DG_Neraca1.DataSource = conn.GetDataTable().Copy();
			DG_Neraca1.DataBind();
			for(int i = 0; i < DG_Neraca1.Items.Count; i++)
			{
				DG_Neraca1.Items[i].Cells[0].Text = tool.FormatDate(DG_Neraca1.Items[i].Cells[0].Text);
			}*/
		}

		private void isi_initial()
		{
			/*conn.QueryString = "select bs_currency,bs_denominator from ca_neraca_middle where cu_ref = '28042008COR1000002' and ap_regno = '14072008COR1000001'";
			conn.ExecuteQuery();
			System.Data.DataTable dt = new System.Data.DataTable();
			dt = conn.GetDataTable().Copy();

			if (conn.GetRowCount() <= 0)
			{
				GlobalTools.fillRefList(DDL_CURRENCY,"select currencyid,currencydesc from rfcurrency where active ='1'",true,conn);
				DDL_CURRENCY.SelectedValue = "IDR";
				DDL_DENOMINATOR.SelectedValue = "000";
				DDL_CURRENCY.Enabled = true;
				DDL_DENOMINATOR.Enabled = true;
				BTN_CEK.Enabled = true;
			}
			else
			{
				GlobalTools.fillRefList(DDL_CURRENCY,"select currencyid,currencydesc from rfcurrency where active ='1'",true,conn);
				try { DDL_CURRENCY.SelectedValue = dt.Rows[0]["bs_currency"].ToString(); }
				catch { DDL_CURRENCY.SelectedValue = "IDR"; }
				DDL_CURRENCY.Enabled = false;
				try { DDL_DENOMINATOR.SelectedValue = dt.Rows[0]["bs_denominator"].ToString(); }
				catch { DDL_DENOMINATOR.SelectedValue = "000"; }
				DDL_DENOMINATOR.Enabled = false;
				BTN_CEK.Enabled = false;
				PnlNeraca.Visible = true;
			}*/

			//----------------------------------------------
			//added by nyoman for current scoring condition 
			conn.QueryString = "select FI_APPROVAL_VER from  VW_CA_NERACA_MIDDLE_FI_APPROVAL_VER " +
				"where AP_REGNO = '14072008COR1000001' ";
			conn.ExecuteQuery();
			/*try
			{
				if (conn.GetFieldValue(0,0) == "2")
				{
					DDL_CURRENCY.SelectedValue = "IDR";
					DDL_DENOMINATOR.SelectedValue = "000";
					DDL_CURRENCY.Enabled = false;
					DDL_DENOMINATOR.Enabled = false;
					BTN_CEK.Enabled = false;
					PnlNeraca.Visible = true;
				}
			}
			catch {}*/
			//----------------------------------------------
		}

		private void clear_field()
		{
			int cnt;
				
			conn.QueryString = "select CU_REF,AP_REGNO,BS_DATE_PERIODE,BS_NUM_MONTH,BS_REPORTTYPE,BS_SALES_ONCR,BS_CASH_BANK,BS_MARKET_SECUR" +
				",BS_AR,BS_AR_FRAFFIL,BS_INVENTORY,BS_OTH_CURASST,BS_PREPAID_EXP,BS_CURRASST,BS_NETFIXASST" +
				",BS_INVESTMENT,BS_NONCA,BS_NI,BS_TTL_NONCA,BS_TTL_ASST,BS_DBST,BS_AP,BS_AP_TOAFFL,BS_ACCRUALS" +
				",BS_TAXPAY,BS_OTH_CURLIAB,BS_CURR_PORTLTDEBT,BS_CURR_LIAB,BS_LONGTERM_DEBT,BS_OTH_LIAB,BS_LONGTERM_LIAB" +
				",BS_TTL_LIAB,BS_CMN_STK,BS_SURP_RESRV,BS_RET_EARN,BS_TTL_NETWORTH,BS_LIAB_NETWORTH,BS_CURRENCY" +
				",BS_DENOMINATOR,BS_SUMBERDATA,BS_ISPROYEKSI from ca_neraca_middle where ap_regno = '" + Request.QueryString["regno"] + "' order by bs_date_periode desc";
			conn.ExecuteQuery();
			cnt = conn.GetRowCount();

			conn.QueryString="select excel_field from ca_excel where excel_file = 'kmk_ki_middle' and excel_type = 'bs'";
			conn.ExecuteQuery();
				
			int row = 70;
			//for (int i = 0; i < cnt; i++)
			//TO DO :
			for (int i = 0; i < 4; i++)
			{
				row--;
				string vtmp = ((char)row).ToString();
				
				//for (int m=1;m<=conn.GetRowCount();m++)
				for (int m=2;m<=35;m++)
				{
					if (m==3)
					{
						System.Web.UI.WebControls.DropDownList DDL_ = (System.Web.UI.WebControls.DropDownList) this.Page.FindControl("DDL_" + vtmp + m.ToString());
						DDL_.SelectedValue = "-";
					}
					else
					{
						System.Web.UI.WebControls.TextBox txt = (System.Web.UI.WebControls.TextBox) Page.FindControl("TXT_" + vtmp + m.ToString());
						txt.Text = "";
					}
				}
				
				if(row<=66)
				{
					break;}
			}
			tgl_default();
		}

		private void retrieve_data_neraca()
		{
			int row;
			tgl_default();
			
			conn.QueryString = "select bs_isproyeksi from ca_neraca_middle where ap_regno = '" + Request.QueryString["regno"] + "' and year(bs_date_periode) = '" + Request.QueryString["tahun"] + "'";
			conn.ExecuteQuery();
			if (conn.GetFieldValue("bs_isproyeksi")=="1")
				row = 70;
			else
				row = 69;
			
			int jmlrow;
			conn.QueryString = "select excel_field from ca_excel where excel_file = 'kmk_ki_middle' and excel_type = 'bs'";
			conn.ExecuteQuery();
			jmlrow = conn.GetRowCount();

			conn.QueryString = "select top 4 CU_REF,AP_REGNO,BS_DATE_PERIODE,BS_NUM_MONTH,BS_REPORTTYPE,BS_SALES_ONCR,BS_CASH_BANK,BS_MARKET_SECUR" +
				",BS_AR,BS_AR_FRAFFIL,BS_INVENTORY,BS_OTH_CURASST,BS_PREPAID_EXP,BS_CURRASST,BS_NETFIXASST" +
				",BS_INVESTMENT,BS_NONCA,BS_NI,BS_TTL_NONCA,BS_TTL_ASST,BS_DBST,BS_AP,BS_AP_TOAFFL,BS_ACCRUALS" +
				",BS_TAXPAY,BS_OTH_CURLIAB,BS_CURR_PORTLTDEBT,BS_CURR_LIAB,BS_LONGTERM_DEBT,BS_OTH_LIAB,BS_LONGTERM_LIAB" +
				",BS_TTL_LIAB,BS_CMN_STK,BS_SURP_RESRV,BS_RET_EARN,BS_TTL_NETWORTH,BS_LIAB_NETWORTH,BS_CURRENCY" +
				",BS_DENOMINATOR,BS_SUMBERDATA,BS_ISPROYEKSI from ca_neraca_middle where year(bs_date_periode) <= '" + Request.QueryString["tahun"] + "' and ap_regno = '" + Request.QueryString["regno"]+ "' order by bs_date_periode desc";
			conn.ExecuteQuery();

			
			for (int i = 0; i < conn.GetRowCount(); i++)
			{
				
				row--;
				string vtmp = ((char)row).ToString();
				int k = 6;
				
				int xx=1;
				for (int m=1;m<5;m++)
				{
					xx++;
					System.Web.UI.WebControls.TextBox txt = (System.Web.UI.WebControls.TextBox) Page.FindControl("TXT_" + vtmp + m.ToString());
					if (Request.QueryString["mode"] == "retrieve")
					{
						if (m!=1)
						{
							if (m==3)
							{
								for (int p=3;p<4;p++)
								{
									System.Web.UI.WebControls.DropDownList DDL_ = (System.Web.UI.WebControls.DropDownList) this.Page.FindControl("DDL_" + vtmp + p.ToString());
									try
									{
										txt.ReadOnly = true;
										txt.Text = conn.GetFieldValue(i, xx);
									}
									catch(Exception ex)
									{
										string errorMessage = ex.Message.ToString();
										string ghgh = txt.ID;
										string a = conn.GetFieldValue(i, xx);
										string ghgh2 = txt.ID;
									}
									try 
									{
										DDL_.Enabled = false;
										DDL_.SelectedValue = txt.Text;
									}
									catch
									{
										DDL_.SelectedValue = "-";
									}
								}
							}
							else 
							{
								try
								{
									txt.ReadOnly = true;
									txt.Text = conn.GetFieldValue(i,xx);
								}
								catch
								{
									txt.ReadOnly = true;
									txt.Text = "0";
								}
							}
						} 
						else 
						{
							for (int n=1;n<2;n++)
							{
								System.Web.UI.WebControls.TextBox TXT_TGL_ = (System.Web.UI.WebControls.TextBox) this.Page.FindControl("TXT_TGL_" + vtmp + n.ToString());
								System.Web.UI.WebControls.DropDownList DDL_BLN_ = (System.Web.UI.WebControls.DropDownList) this.Page.FindControl("DDL_BLN_" + vtmp + n.ToString());
								System.Web.UI.WebControls.TextBox TXT_YEAR_ = (System.Web.UI.WebControls.TextBox) this.Page.FindControl("TXT_YEAR_" + vtmp + n.ToString());
								
								TXT_TGL_.ReadOnly = true;
								DDL_BLN_.Enabled = false;
								TXT_YEAR_.ReadOnly = true;

								DateTime excdatestr = Convert.ToDateTime(tool.FormatDate(conn.GetFieldValue(i, xx)));
								try
								{
									TXT_TGL_.Text = "";
									DDL_BLN_.SelectedValue = "";
									TXT_YEAR_.Text = "";
									GlobalTools.fillDateForm(TXT_TGL_, DDL_BLN_, TXT_YEAR_, excdatestr);
								}
								catch
								{
									//									TXT_TGL_.Text = "";
									//									DDL_BLN_.SelectedValue = "";
									//									TXT_YEAR_.Text = "";
								}

							}
						}			
					} 
					else 
					{
						txt.ReadOnly = true;
						txt.Text = "";
					}
				}
	
				
				for (int j = 5; j <= jmlrow; j++)
				{	
					System.Web.UI.WebControls.TextBox txt = (System.Web.UI.WebControls.TextBox) Page.FindControl("TXT_" + vtmp + j.ToString());
					if (Request.QueryString["mode"] == "retrieve")
					{
						try
						{
							txt.ReadOnly = true;
							txt.Text = myMoneyFormat_noDec(conn.GetFieldValue(i, k));
						}
						catch
						{
							txt.ReadOnly = true;
							txt.Text = "";
						}
					}
					else 
					{
						txt.ReadOnly = true;
						txt.Text = "";
					}
					k++;
				}

			}
			
		}

		private string myMoneyFormat_noDec(string str)
		{
			if ((str.Trim() == "") || (str.Trim() == "&nbsp;")) 
			{
				return Strings.FormatNumber(0, 0, TriState.UseDefault, TriState.UseDefault, TriState.UseDefault);
			} 
			else 
			{
				return Strings.FormatNumber(str, 0, TriState.UseDefault, TriState.UseDefault, TriState.UseDefault);
			}
		}

		private void retrieve_HistoryData(string regno, string tahun)
		{
			int row;
			tgl_default();
			
			conn.QueryString = "select bs_isproyeksi from ca_neraca_middle where ap_regno = '" + 
				regno + "' and year(bs_date_periode) = '" + tahun + "'";
			conn.ExecuteQuery();
			if (conn.GetFieldValue("bs_isproyeksi")=="1")
				row = 70;
			else
				row = 69;
			
			int jmlrow;
			conn.QueryString = "select excel_field from ca_excel where excel_file = 'kmk_ki_middle' and excel_type = 'bs'";
			conn.ExecuteQuery();
			jmlrow = conn.GetRowCount();

			conn.QueryString = "select top 4 CU_REF,AP_REGNO,BS_DATE_PERIODE,BS_NUM_MONTH,BS_REPORTTYPE,BS_SALES_ONCR,BS_CASH_BANK,BS_MARKET_SECUR" +
				",BS_AR,BS_AR_FRAFFIL,BS_INVENTORY,BS_OTH_CURASST,BS_PREPAID_EXP,BS_CURRASST,BS_NETFIXASST" +
				",BS_INVESTMENT,BS_NONCA,BS_NI,BS_TTL_NONCA,BS_TTL_ASST,BS_DBST,BS_AP,BS_AP_TOAFFL,BS_ACCRUALS" +
				",BS_TAXPAY,BS_OTH_CURLIAB,BS_CURR_PORTLTDEBT,BS_CURR_LIAB,BS_LONGTERM_DEBT,BS_OTH_LIAB,BS_LONGTERM_LIAB" +
				",BS_TTL_LIAB,BS_CMN_STK,BS_SURP_RESRV,BS_RET_EARN,BS_TTL_NETWORTH,BS_LIAB_NETWORTH,BS_CURRENCY" +
				",BS_DENOMINATOR,BS_SUMBERDATA,BS_ISPROYEKSI from ca_neraca_middle where year(bs_date_periode) <= '" + 
				tahun + "' and ap_regno = '" + regno + "' order by bs_date_periode desc";
			conn.ExecuteQuery();

			//row = 69;
			
			for (int i = 0; i < conn.GetRowCount(); i++)
			{
				
				row--;
				string vtmp = ((char)row).ToString();
				int k = 6;
				
				int xx=1;
				for (int m=1;m<5;m++)
				{
					xx++;
					System.Web.UI.WebControls.TextBox txt = (System.Web.UI.WebControls.TextBox) Page.FindControl("TXT_" + vtmp + m.ToString());
					if (m!=1)
					{
						if (m==3)
						{
							for (int p=3;p<4;p++)
							{
								System.Web.UI.WebControls.DropDownList DDL_ = (System.Web.UI.WebControls.DropDownList) this.Page.FindControl("DDL_" + vtmp + p.ToString());
								txt.Text = conn.GetFieldValue(i, xx);
								try 
								{
									DDL_.SelectedValue = txt.Text;
								}
								catch
								{
									DDL_.SelectedValue = "-";
								}
							}
						}
						else 
						{
							try
							{
								txt.Text = conn.GetFieldValue(i,xx);
							}
							catch
							{
								txt.Text = "0";
							}
						}
					} 
					else 
					{
						for (int n=1;n<2;n++)
						{
							System.Web.UI.WebControls.TextBox TXT_TGL_ = (System.Web.UI.WebControls.TextBox) this.Page.FindControl("TXT_TGL_" + vtmp + n.ToString());
							System.Web.UI.WebControls.DropDownList DDL_BLN_ = (System.Web.UI.WebControls.DropDownList) this.Page.FindControl("DDL_BLN_" + vtmp + n.ToString());
							System.Web.UI.WebControls.TextBox TXT_YEAR_ = (System.Web.UI.WebControls.TextBox) this.Page.FindControl("TXT_YEAR_" + vtmp + n.ToString());
								
							DateTime excdatestr = Convert.ToDateTime(tool.FormatDate(conn.GetFieldValue(i, xx)));
							try
							{
								TXT_TGL_.Text = "";
								DDL_BLN_.SelectedValue = "";
								TXT_YEAR_.Text = "";
								GlobalTools.fillDateForm(TXT_TGL_, DDL_BLN_, TXT_YEAR_, excdatestr);
							}
							catch
							{
								//									TXT_TGL_.Text = "";
								//									DDL_BLN_.SelectedValue = "";
								//									TXT_YEAR_.Text = "";
							}

						}
					}
				}
	
				
				for (int j = 5; j <= jmlrow; j++)
				{	
					System.Web.UI.WebControls.TextBox txt = (System.Web.UI.WebControls.TextBox) Page.FindControl("TXT_" + vtmp + j.ToString());
					try
					{
						txt.Text = myMoneyFormat_noDec(conn.GetFieldValue(i, k));
					}
					catch
					{
						txt.Text = "";
					}
					k++;
				}

			}
			
		}

		private void tgl_default()
		{
			GlobalTools.initDateForm(this.TXT_TGL_B1, this.DDL_BLN_B1, this.TXT_YEAR_B1, true);
			GlobalTools.initDateForm(this.TXT_TGL_C1, this.DDL_BLN_C1, this.TXT_YEAR_C1, true);
			GlobalTools.initDateForm(this.TXT_TGL_D1, this.DDL_BLN_D1, this.TXT_YEAR_D1, true);
			GlobalTools.initDateForm(this.TXT_TGL_E1, this.DDL_BLN_E1, this.TXT_YEAR_E1, true);
			try
			{ 
				//this.DDL_BLN_B1.SelectedValue = DateTime.Now.Month.ToString();
				this.DDL_BLN_B1.SelectedValue = "";
				this.DDL_BLN_C1.SelectedValue = "";
				this.DDL_BLN_D1.SelectedValue = "";
				this.DDL_BLN_E1.SelectedValue = "";
			}
			catch{}
		}
		private void viewdata_history()
		{
			//conn.QueryString = "select POSISI_TGL,JML_BLN,JNS_LAP,year(POSISI_TGL) tahun from CA_NERACA_SMALL where ap_regno = '"+ Request.QueryString["regno"]+ "' order by POSISI_TGL desc";
			//conn.QueryString = "select AP_REGNO,BS_DATE_PERIODE,BS_NUM_MONTH,BS_REPORTTYPE,TAHUN " +
			//	"from VW_CA_NERACA_MIDDLE_HISTORY where cu_ref = '" + Request.QueryString["curef"] + "' " +
			//	"and ap_regno <> '"+ Request.QueryString["regno"] + "' order by AP_REGNO, BS_DATE_PERIODE desc";
			conn.QueryString = "exec CA_NERACA_MIDDLE_HISTORY '" + Request.QueryString["curef"] + "', '" +
				Request.QueryString["regno"] + "' ";
			conn.ExecuteQuery();
			
			DG_FinancialKey.DataSource = conn.GetDataTable().Copy();
			DG_FinancialKey.DataBind();
			for(int i = 0; i < DG_FinancialKey.Items.Count; i++)
			{
				DG_FinancialKey.Items[i].Cells[1].Text = tool.FormatDate(DG_FinancialKey.Items[i].Cells[1].Text);
			}
		}

		private void BindData(DataGrid theGrid, string strconn)
		{
			if(strconn != "")
			{
				conn.QueryString = strconn;
				conn.ExecuteQuery();
			}

			System.Data.DataTable dt = new System.Data.DataTable();
			dt = conn.GetDataTable().Copy();

			System.Web.UI.WebControls.DataGrid dg = theGrid;

			dg.DataSource = dt;				

			try
			{
				try
				{
					dg.DataBind();
				}
				catch 
				{
					dg.CurrentPageIndex = dg.PageCount - 1;
					dg.DataBind();
				}
			}
			catch (Exception c)
			{
				string ab = c.Message.ToString();
				string cd = c.Message.ToString();
			}
			
			if(!IsPostBack)
			{

			}
			conn.ClearData();
		}

		private void fillAllDDL()
		{
			//DDL_PRODUCT
			GlobalTools.fillRefList(DDL_PRODUCT, "SELECT ID_AP_VARIABLE, DESCRIPTION FROM AP_VARIABLE", conn);
			isiDDLTanggal();
		}

		private void ClearAllField()
		{
			//TXT_CIF.Text = "";
			DDL_PRODUCT.SelectedIndex = 0;
			TXT_PRIMARY_BANK.Text = "";
			TXT_OTHER_BANK.Text = "";

			//TXT_CIF_GROW_ANCHORS.Text = "";
			TXT_SEQ_GROW_ANCHORS.Text = "";
			TXT_KEY_SUPPORT_NEEDED.Text = "";
		}

		private void BindAllGrid()
		{
			RETRIEVE_BUSINESS_AND_STRATEGY(Request.QueryString["cif"]);

			BindData(DGR_SCENARIO, "SELECT AP_VARIABLE.DESCRIPTION as product,* FROM AP_COMPETITIVE_SCAN, AP_VARIABLE WHERE CU_CIF = '" + Request.QueryString["CIF"] + "' AND  AP_VARIABLE.ID_AP_VARIABLE = AP_COMPETITIVE_SCAN.ID_AP_VARIABLE");
			BindDGRScenario();

			BindData(StrategiesToGrowAnchors, "SELECT * FROM AP_STRATEGIES_TO_GROW_ANCHORS WHERE CU_CIF = '" + Request.QueryString["cif"] + "' ORDER BY SEQ ASC");
			BindSTRATEGIES_TO_GROW_ANCHORS();

			BindData(DG_FinancialKey, "SELECT * FROM AP_KEY_FINANCIAL WHERE CU_CIF = '" + Request.QueryString["cif"] + "' ORDER BY BS_DATE_PERIODE DESC");
		}

		private void ViewMenu()
		{
			Menu.Controls.Clear();
			try 
			{
				conn.QueryString = "SELECT * FROM SCREENMENU WHERE MENUCODE = '" + Request.QueryString["mc"] + "'";
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
							strtemp = "cif=" + Request.QueryString["cif"] + "&bs=" + Request.QueryString["bs"] + "&bc=" + Request.QueryString["bc"] + "&rd=" + Request.QueryString["rd"] + "&cd=" + Request.QueryString["cd"];
						else	
							strtemp = "&mc=" + Request.QueryString["mc"]+ "&cif=" + Request.QueryString["cif"] + "&bs=" + Request.QueryString["bs"] + "&bc=" + Request.QueryString["bc"] + "&rd=" + Request.QueryString["rd"] + "&cd=" + Request.QueryString["cd"];
					}
					else 
					{
						strtemp = ""; 
					}
					t.NavigateUrl = conn.GetFieldValue(i, 3)+strtemp;
					string asb = t.NavigateUrl;
					Menu.Controls.Add(t);
					Menu.Controls.Add(new LiteralControl("&nbsp;&nbsp;&nbsp;"));
				}
			} 
			catch (Exception ex) 
			{
				string temp2 = ex.Message.ToString();
				string temp = ex.ToString();
			}
		}

		private void DGR_SCENARIO_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			if(DGR_SCENARIO.CurrentPageIndex >= 0 && DGR_SCENARIO.CurrentPageIndex < DGR_SCENARIO.PageCount)
			{
				DGR_SCENARIO.CurrentPageIndex = e.NewPageIndex;
				BindData(DGR_SCENARIO, "SELECT AP_VARIABLE.DESCRIPTION as product,* FROM AP_COMPETITIVE_SCAN, AP_VARIABLE WHERE CU_CIF = '" + Request.QueryString["CIF"] + "' AND  AP_VARIABLE.ID_AP_VARIABLE = AP_COMPETITIVE_SCAN.ID_AP_VARIABLE");
			}
		}

		private void StrategiesToGrowAnchors_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			if(StrategiesToGrowAnchors.CurrentPageIndex >= 0 && StrategiesToGrowAnchors.CurrentPageIndex < StrategiesToGrowAnchors.PageCount)
			{
				StrategiesToGrowAnchors.CurrentPageIndex = e.NewPageIndex;
				BindData(StrategiesToGrowAnchors, "SELECT * FROM AP_STRATEGIES_TO_GROW_ANCHORS WHERE CU_CIF = '" + Request.QueryString["cif"] + "' ORDER BY SEQ ASC");
			}
		}

		protected void BTN_UPLOAD_Click(object sender, System.EventArgs e)
		{
			string directory;
			int counter = 0;
			int max_id = 10000;
			string outputfilename = "";

			conn.QueryString = "EXEC AP_UPLOAD_DATA_SNAPSHOT '" + 
				Session["USERID"].ToString() + "', '" +
				Path.GetFileName(TXT_FILE_UPLOAD.PostedFile.FileName) + "'";
			conn.ExecuteQuery();

			conn.QueryString = "SELECT MAX(ID_UPLOAD_DATA_SNAPSHOT) as MAX_ID from [AP_FILE_UPLOAD_DATA_SNAPSHOT] where userid='" + Session["USERID"].ToString() + "'";
			conn.ExecuteQuery();

			if (conn.GetRowCount() > 0)
			{
				max_id = int.Parse(conn.GetFieldValue("MAX_ID"));
			}

			conn.QueryString = "SELECT FILE_UPLOAD_NAME from [AP_FILE_UPLOAD_DATA_SNAPSHOT] where ID_UPLOAD_DATA_SNAPSHOT = '" + max_id + "' and userid='" + Session["USERID"].ToString() + "'";
			conn.ExecuteQuery();

			if (conn.GetRowCount() > 0)
			{
				outputfilename = conn.GetFieldValue("FILE_UPLOAD_NAME");
				//TXT_XLSNAME.Text = outputfilename;
			}

			conn.QueryString = "SELECT EXPORT_URL FROM AP_SNAPSHOT_RFUPLOAD WHERE EXPORT_ID = 'SNAPSHOT01'";
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
			conn.QueryString = "SELECT EXPORT_URL FROM AP_SNAPSHOT_RFUPLOAD WHERE EXPORT_ID = 'SNAPSHOT01'";
			conn.ExecuteQuery();

			if (conn.GetRowCount() > 0) 
			{
				url = conn.GetFieldValue("EXPORT_URL");
			}

			System.Data.DataTable dt = new System.Data.DataTable();
			conn.QueryString = "SELECT ID_UPLOAD_DATA_SNAPSHOT, FILE_UPLOAD_NAME FROM AP_FILE_UPLOAD_DATA_SNAPSHOT where userid='" + Session["USERID"].ToString() + "'";
			conn.ExecuteQuery();
			dt = conn.GetDataTable().Copy();
			DATA_UPLOAD.DataSource = dt;
			try 
			{
				DATA_UPLOAD.DataBind();
			} 
			catch 
			{
				DATA_UPLOAD.CurrentPageIndex = 0;
				DATA_UPLOAD.DataBind();
			}
			for (int i = 1; i <= DATA_UPLOAD.Items.Count; i++)
			{
				HyperLink HpDownload = (HyperLink) DATA_UPLOAD.Items[i-1].Cells[2].FindControl("FILE_DOWNLOAD");
				LinkButton HpDelete = (LinkButton) DATA_UPLOAD.Items[i-1].Cells[3].FindControl("FILE_DELETE");
				HpDownload.NavigateUrl = url + conn.GetFieldValue("FILE_UPLOAD_NAME");
			}
		}

		private void DATA_UPLOAD_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			string directory = "";
			conn.QueryString = "SELECT EXPORT_URL FROM AP_SNAPSHOT_RFUPLOAD WHERE EXPORT_ID = 'SNAPSHOT01'";
			conn.ExecuteQuery();
			if (conn.GetRowCount() > 0)
			{
				directory = Server.MapPath(conn.GetFieldValue("EXPORT_URL").Trim());
			}

			switch (((LinkButton)e.CommandSource).CommandName)
			{
				case "delete":
					conn.QueryString = "EXEC AP_DELETE_FILE_UPLOAD_SNAPSHOT '" + e.Item.Cells[0].Text + "', '" +
						Session["USERID"].ToString() + "', '" +
						e.Item.Cells[1].Text + "'";
					conn.ExecuteQuery();
					deleteFile(directory, e.Item.Cells[1].Text);
					ViewUploadFiles();
					break;
			}
		}

		private void DATA_UPLOAD_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			DATA_UPLOAD.CurrentPageIndex = e.NewPageIndex;
			ViewUploadFiles();
		}

		private void DG_NeracaHistory_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			string cmd = e.CommandName;
			
			switch (cmd)
			{		  
				case "retrieve" :										
					string vtemp = e.Item.Cells[3].Text;
					Response.Redirect("SnapShot.aspx?tahun=" + vtemp +"&mode=retrieve&regno='14072008COR1000001'"+
						"&mc="+Request.QueryString["mc"]+"&bussunitid="+
						Request.QueryString["bussunitid"]+"&programid="+Request.QueryString["programid"]+
						"&jnsnasabah="+Request.QueryString["jnsnasabah"]+"&curef="+Request.QueryString["curef"]+
						"&tc="+Request.QueryString["tc"]+"&viewmode="+Request.QueryString["viewmode"]+
						"&lmsreg="+Request.QueryString["lmsreg"]+"&scr="+Request.QueryString["scr"]);
					clear_field();
					retrieve_data_neraca();
					break;
				case "delete" :
					//Response.Redirect("IS_KMK_KI_Medium.aspx?tahun=" + tool.FormatDate_Year(e.Item.Cells[0].Text) +"&mode=delete&regno="+Request.QueryString["regno"]+"&mc="+Request.QueryString["mc"]+"&bussunitid="+Request.QueryString["bussunitid"]+"&programid="+Request.QueryString["programid"]+"&jnsnasabah="+Request.QueryString["jnsnasabah"]+"&curef="+Request.QueryString["curef"]);
					string vtempe = e.Item.Cells[3].Text;
					conn.QueryString = "exec CA_LABARUGI_MIDDLE_SP_DELETE '" + Request.QueryString["curef"]+ "','" + Request.QueryString["regno"]+ "'," +
						GlobalTools.ToSQLDate(e.Item.Cells[4].Text) + ",'" + e.Item.Cells[1].Text + "','" + e.Item.Cells[2].Text + "'";
					conn.ExecuteNonQuery();

					//delete ratio as well 
					/*CLS_CALCULATION.delete_ratio(Request.QueryString["regno"],conn);
					
					isi_initial();
					viewdata();
					clear_field();*/
					break;
				default :
					break;
			}
		}
	
		private void isiDDLTanggal()
		{
			GlobalTools.initDateForm(this.TXT_TGL_B1, this.DDL_BLN_B1, this.TXT_YEAR_B1, true);
			GlobalTools.initDateForm(this.TXT_TGL_C1, this.DDL_BLN_C1, this.TXT_YEAR_C1, true);
			GlobalTools.initDateForm(this.TXT_TGL_D1, this.DDL_BLN_D1, this.TXT_YEAR_D1, true);
			GlobalTools.initDateForm(this.TXT_TGL_E1, this.DDL_BLN_E1, this.TXT_YEAR_E1, true);
		}

		private bool cek_tanggal()
		{
			if (TXT_TGL_B1.Text != "" && DDL_BLN_B1.SelectedIndex > 0 && TXT_YEAR_B1.Text != "")
				if(!GlobalTools.isDateValid(this,TXT_TGL_B1.Text,DDL_BLN_B1.SelectedValue,TXT_YEAR_B1.Text))
					return false;
			
			if (TXT_TGL_C1.Text != "" && DDL_BLN_C1.SelectedIndex > 0 && TXT_YEAR_C1.Text != "")
				if(!GlobalTools.isDateValid(this,TXT_TGL_C1.Text,DDL_BLN_C1.SelectedValue,TXT_YEAR_C1.Text))
					return false;

			if (TXT_TGL_D1.Text != "" && DDL_BLN_D1.SelectedIndex > 0 && TXT_YEAR_D1.Text != "")
				if(!GlobalTools.isDateValid(this,TXT_TGL_D1.Text,DDL_BLN_D1.SelectedValue,TXT_YEAR_D1.Text))
					return false;

			if (TXT_TGL_E1.Text != "" && DDL_BLN_E1.SelectedIndex > 0 && TXT_YEAR_E1.Text != "")
				if(!GlobalTools.isDateValid(this,TXT_TGL_E1.Text,DDL_BLN_E1.SelectedValue,TXT_YEAR_E1.Text))
					return false;
				
			return true;
		}

		protected void BTN_SIMPAN_Click(object sender, System.EventArgs e)
		{
			/*
			 *	PROCEDURE AP_INSERT_KEY_FINANCIAL
				@CU_CIF VARCHAR(50),
				@BS_DATE_PERIODE DATETIME,
				@CASH_EQUIVALENTS VARCHAR(100),
				@RECEIVABLES VARCHAR(100),
				@TOTAL_ASSETS VARCHAR(100),
				@PAYABLES VARCHAR(100),
				@TOTAL_LOANS VARCHAR(100),
				@INVESTMENT VARCHAR(100),
				@WORKING_CAPITAL VARCHAR(100),
				@REVENUE VARCHAR(100),
				@EBIT VARCHAR(100),
				@EBIT_MARGINS VARCHAR(100),
				@NPAT VARCHAR(100),
				@NPAT_MARGINS VARCHAR(100)
			 * 
			 * */

			//GlobalTools.ToSQLDate(TXT_TGL_B1.Text,DDL_BLN_B1.SelectedValue,TXT_YEAR_B1.Text)
			if(cek_tanggal())
			{
				if(TXT_TGL_B1.Text != "" && DDL_BLN_B1.SelectedIndex != 0 && TXT_YEAR_B1.Text != "")
				{
					conn.QueryString = "EXEC AP_INSERT_KEY_FINANCIAL '" + Request.QueryString["cif"] + "'," 
						+ GlobalTools.ToSQLDate(TXT_TGL_B1.Text,DDL_BLN_B1.SelectedValue,TXT_YEAR_B1.Text) + ",'"
						+ TXT_B5.Text.ToString() + "','" 
						+ TXT_B6.Text.ToString() + "','"
						+ TXT_B7.Text.ToString() + "','"
						+ TXT_B8.Text.ToString() + "','"
						+ TXT_B9.Text.ToString() + "','"
						+ TXT_B10.Text.ToString() + "','"
						+ TXT_B11.Text.ToString() + "','"
						+ TXT_B14.Text.ToString() + "','"
						+ TXT_B15.Text.ToString() + "','"
						+ TXT_B16.Text.ToString() + "','"
						+ TXT_B17.Text.ToString() + "','"
						+ TXT_B18.Text.ToString() + "'";
					conn.ExecuteQuery();
				}

				if(TXT_TGL_C1.Text != "" && DDL_BLN_C1.SelectedIndex != 0 && TXT_YEAR_C1.Text != "")
				{
					conn.QueryString = "EXEC AP_INSERT_KEY_FINANCIAL '" + Request.QueryString["cif"] + "'," 
						+ GlobalTools.ToSQLDate(TXT_TGL_C1.Text,DDL_BLN_C1.SelectedValue,TXT_YEAR_C1.Text) + ",'"
						+ TXT_C5.Text.ToString() + "','" 
						+ TXT_C6.Text.ToString() + "','"
						+ TXT_C7.Text.ToString() + "','"
						+ TXT_C8.Text.ToString() + "','"
						+ TXT_C9.Text.ToString() + "','"
						+ TXT_C10.Text.ToString() + "','"
						+ TXT_C11.Text.ToString() + "','"
						+ TXT_C14.Text.ToString() + "','"
						+ TXT_C15.Text.ToString() + "','"
						+ TXT_C16.Text.ToString() + "','"
						+ TXT_C17.Text.ToString() + "','"
						+ TXT_C18.Text.ToString() + "'";
					conn.ExecuteQuery();
				}

				if(TXT_TGL_D1.Text != "" && DDL_BLN_D1.SelectedIndex != 0 && TXT_YEAR_D1.Text != "")
				{
					conn.QueryString = "EXEC AP_INSERT_KEY_FINANCIAL '" + Request.QueryString["cif"] + "'," 
						+ GlobalTools.ToSQLDate(TXT_TGL_D1.Text,DDL_BLN_D1.SelectedValue,TXT_YEAR_D1.Text) + ",'"
						+ TXT_D5.Text.ToString() + "','" 
						+ TXT_D6.Text.ToString() + "','"
						+ TXT_D7.Text.ToString() + "','"
						+ TXT_D8.Text.ToString() + "','"
						+ TXT_D9.Text.ToString() + "','"
						+ TXT_D10.Text.ToString() + "','"
						+ TXT_D11.Text.ToString() + "','"
						+ TXT_D14.Text.ToString() + "','"
						+ TXT_D15.Text.ToString() + "','"
						+ TXT_D16.Text.ToString() + "','"
						+ TXT_D17.Text.ToString() + "','"
						+ TXT_D18.Text.ToString() + "'";
					conn.ExecuteQuery();
				}

				if(TXT_TGL_E1.Text != "" && DDL_BLN_E1.SelectedIndex != 0 && TXT_YEAR_E1.Text != "")
				{
					conn.QueryString = "EXEC AP_INSERT_KEY_FINANCIAL '" + Request.QueryString["cif"] + "'," 
						+ GlobalTools.ToSQLDate(TXT_TGL_E1.Text,DDL_BLN_E1.SelectedValue,TXT_YEAR_E1.Text) + ",'"
						+ TXT_E5.Text.ToString() + "','" 
						+ TXT_E6.Text.ToString() + "','"
						+ TXT_E7.Text.ToString() + "','"
						+ TXT_E8.Text.ToString() + "','"
						+ TXT_E9.Text.ToString() + "','"
						+ TXT_E10.Text.ToString() + "','"
						+ TXT_E11.Text.ToString() + "','"
						+ TXT_E14.Text.ToString() + "','"
						+ TXT_E15.Text.ToString() + "','"
						+ TXT_E16.Text.ToString() + "','"
						+ TXT_E17.Text.ToString() + "','"
						+ TXT_E18.Text.ToString() + "'";
					conn.ExecuteQuery();
				}

				BindData(DG_FinancialKey, "SELECT * FROM AP_KEY_FINANCIAL WHERE CU_CIF = '" + Request.QueryString["cif"] + "' ORDER BY BS_DATE_PERIODE DESC");
			}
			else
			{
				Tools.popMessage(this, "Incorrect date value !");
			}
		}

		private void ClearBalanceSheet()
		{
			TXT_TGL_B1.Text = "";
			DDL_BLN_B1.SelectedIndex = 0;
			TXT_YEAR_B1.Text = "";
			TXT_B5.Text = "";
			TXT_B6.Text = "";
			TXT_B7.Text = "";
			TXT_B8.Text = "";
			TXT_B9.Text = "";
			TXT_B10.Text = "";
			TXT_B11.Text = "";
			TXT_B14.Text = "";
			TXT_B15.Text = "";
			TXT_B16.Text = "";
			TXT_B17.Text = "";
			TXT_B18.Text = "";

			TXT_TGL_C1.Text = "";
			DDL_BLN_C1.SelectedIndex = 0;
			TXT_YEAR_C1.Text = "";
			TXT_C6.Text = "";
			TXT_C6.Text = ""; 
			TXT_C7.Text = ""; 
			TXT_C8.Text = ""; 
			TXT_C9.Text = ""; 
			TXT_C10.Text = ""; 
			TXT_C11.Text = ""; 
			TXT_C14.Text = ""; 
			TXT_C15.Text = ""; 
			TXT_C16.Text = ""; 
			TXT_C17.Text = ""; 
			TXT_C18.Text = ""; 

			TXT_TGL_D1.Text = "";
			DDL_BLN_D1.SelectedIndex = 0;
			TXT_YEAR_D1.Text = "";
			TXT_D5.Text = "";
			TXT_D6.Text = ""; 
			TXT_D7.Text = ""; 
			TXT_D8.Text = ""; 
			TXT_D9.Text = ""; 
			TXT_D10.Text = ""; 
			TXT_D11.Text = ""; 
			TXT_D14.Text = ""; 
			TXT_D15.Text = ""; 
			TXT_D16.Text = ""; 
			TXT_D17.Text = ""; 
			TXT_D18.Text = ""; 

			TXT_TGL_E1.Text = "";
			DDL_BLN_E1.SelectedIndex = 0;
			TXT_YEAR_E1.Text = "";
			TXT_E5.Text = "";
			TXT_E6.Text = ""; 
			TXT_E7.Text = ""; 
			TXT_E8.Text = ""; 
			TXT_E9.Text = ""; 
			TXT_E10.Text = ""; 
			TXT_E11.Text = ""; 
			TXT_E14.Text = ""; 
			TXT_E15.Text = ""; 
			TXT_E16.Text = ""; 
			TXT_E17.Text = ""; 
			TXT_E18.Text = ""; 

			TXT_TGL_B1.Text = "01";
			DDL_BLN_B1.SelectedValue = "1";
			TXT_TGL_C1.Text = "01";
			DDL_BLN_C1.SelectedValue = "1";
			TXT_TGL_D1.Text = "01";
			DDL_BLN_D1.SelectedValue = "1";
			TXT_TGL_E1.Text = "01";
			DDL_BLN_E1.SelectedValue = "1";
		}

		protected void BTNCLEAR_Click(object sender, System.EventArgs e)
		{
			ClearBalanceSheet();
		}

		private void DG_FinancialKey_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			string cmd = e.CommandName;
			
			switch (cmd)
			{
				case "retrieve" :
					retrieveData(e.Item.Cells[0].Text.ToString());
					break;
				case "delete":
					deleteData(e.Item.Cells[0].Text.ToString());
					break;
			}
		}

		private void deleteData(string year)
		{
			conn.QueryString = "DELETE AP_KEY_FINANCIAL where year(BS_DATE_PERIODE) = year('" + year + "') and CU_CIF = '" + Request.QueryString["cif"]+ "' and " +
				"month(BS_DATE_PERIODE) = month('" + year + "') AND day(BS_DATE_PERIODE) = day('" + year + "')";
			conn.ExecuteQuery();
			BindData(DG_FinancialKey, "SELECT * FROM AP_KEY_FINANCIAL WHERE CU_CIF = '" + Request.QueryString["cif"] + "' ORDER BY BS_DATE_PERIODE DESC");
		}

		private void retrieveData(string year)
		{
			conn.QueryString = "select top 4 * from AP_KEY_FINANCIAL where BS_DATE_PERIODE <= '" + year + "' and CU_CIF = '" + Request.QueryString["cif"]+ "' order by bs_date_periode desc";
			conn.ExecuteQuery();
			ClearBalanceSheet();
			/*
			 * 
			 *	CU_CIF
				BS_DATE_PERIODE
				CASH_EQUIVALENTS
				RECEIVABLES
				TOTAL_ASSETS
				PAYABLES
				TOTAL_LOANS
				INVESTMENT
				WORKING_CAPITAL
				REVENUE
				EBIT
				EBIT_MARGINS
				NPAT
				NPAT_MARGINS
			 * 
			 * 
			 */

			if(conn.GetFieldValue(0,"CU_CIF") != null || conn.GetFieldValue(0,"CU_CIF") != "")
			{
				TXT_TGL_E1.Text = GlobalTools.FormatDate_Day(conn.GetFieldValue(0, "BS_DATE_PERIODE"));
				DDL_BLN_E1.SelectedValue = GlobalTools.FormatDate_Month(conn.GetFieldValue(0, "BS_DATE_PERIODE"));
				TXT_YEAR_E1.Text = GlobalTools.FormatDate_Year(conn.GetFieldValue(0, "BS_DATE_PERIODE"));
				TXT_E5.Text = conn.GetFieldValue(0, "CASH_EQUIVALENTS");
				TXT_E6.Text = conn.GetFieldValue(0, "RECEIVABLES");
				TXT_E7.Text = conn.GetFieldValue(0, "TOTAL_ASSETS");
				TXT_E8.Text = conn.GetFieldValue(0, "PAYABLES");
				TXT_E9.Text = conn.GetFieldValue(0, "TOTAL_LOANS");
				TXT_E10.Text = conn.GetFieldValue(0, "INVESTMENT");
				TXT_E11.Text = conn.GetFieldValue(0, "WORKING_CAPITAL");
				TXT_E14.Text = conn.GetFieldValue(0, "REVENUE");
				TXT_E15.Text = conn.GetFieldValue(0, "EBIT");
				TXT_E16.Text = conn.GetFieldValue(0, "EBIT_MARGINS");
				TXT_E17.Text = conn.GetFieldValue(0, "NPAT");
				TXT_E18.Text = conn.GetFieldValue(0, "NPAT_MARGINS");
			}

			if(conn.GetRowCount() >= 2)
			{
				if(conn.GetFieldValue(1,"CU_CIF") != null || conn.GetFieldValue(1,"CU_CIF") != "")
				{
					TXT_TGL_D1.Text = GlobalTools.FormatDate_Day(conn.GetFieldValue(1, "BS_DATE_PERIODE"));
					DDL_BLN_D1.SelectedValue = GlobalTools.FormatDate_Month(conn.GetFieldValue(1, "BS_DATE_PERIODE"));
					TXT_YEAR_D1.Text = GlobalTools.FormatDate_Year(conn.GetFieldValue(1, "BS_DATE_PERIODE"));
					TXT_D5.Text = conn.GetFieldValue(1, "CASH_EQUIVALENTS");
					TXT_D6.Text = conn.GetFieldValue(1, "RECEIVABLES");
					TXT_D7.Text = conn.GetFieldValue(1, "TOTAL_ASSETS");
					TXT_D8.Text = conn.GetFieldValue(1, "PAYABLES");
					TXT_D9.Text = conn.GetFieldValue(1, "TOTAL_LOANS");
					TXT_D10.Text = conn.GetFieldValue(1, "INVESTMENT");
					TXT_D11.Text = conn.GetFieldValue(1, "WORKING_CAPITAL");
					TXT_D14.Text = conn.GetFieldValue(1, "REVENUE");
					TXT_D15.Text = conn.GetFieldValue(1, "EBIT");
					TXT_D16.Text = conn.GetFieldValue(1, "EBIT_MARGINS");
					TXT_D17.Text = conn.GetFieldValue(1, "NPAT");
					TXT_D18.Text = conn.GetFieldValue(1, "NPAT_MARGINS");

				}
			}

			if(conn.GetRowCount() >= 3)
			{
				if(conn.GetFieldValue(2,"CU_CIF") != null || conn.GetFieldValue(2,"CU_CIF") != "")
				{
					TXT_TGL_C1.Text = GlobalTools.FormatDate_Day(conn.GetFieldValue(2, "BS_DATE_PERIODE"));
					DDL_BLN_C1.SelectedValue = GlobalTools.FormatDate_Month(conn.GetFieldValue(2, "BS_DATE_PERIODE"));
					TXT_YEAR_C1.Text = GlobalTools.FormatDate_Year(conn.GetFieldValue(2, "BS_DATE_PERIODE"));
					TXT_C5.Text = conn.GetFieldValue(2, "CASH_EQUIVALENTS");
					TXT_C6.Text = conn.GetFieldValue(2, "RECEIVABLES");
					TXT_C7.Text = conn.GetFieldValue(2, "TOTAL_ASSETS");
					TXT_C8.Text = conn.GetFieldValue(2, "PAYABLES");
					TXT_C9.Text = conn.GetFieldValue(2, "TOTAL_LOANS");
					TXT_C10.Text = conn.GetFieldValue(2, "INVESTMENT");
					TXT_C11.Text = conn.GetFieldValue(2, "WORKING_CAPITAL");
					TXT_C14.Text = conn.GetFieldValue(2, "REVENUE");
					TXT_C15.Text = conn.GetFieldValue(2, "EBIT");
					TXT_C16.Text = conn.GetFieldValue(2, "EBIT_MARGINS");
					TXT_C17.Text = conn.GetFieldValue(2, "NPAT");
					TXT_C18.Text = conn.GetFieldValue(2, "NPAT_MARGINS");
				}
			}

			if(conn.GetRowCount() >= 4)
			{
				if(conn.GetFieldValue(3,"CU_CIF") != null || conn.GetFieldValue(3,"CU_CIF") != "")
				{
					TXT_TGL_B1.Text = GlobalTools.FormatDate_Day(conn.GetFieldValue(3, "BS_DATE_PERIODE"));
					DDL_BLN_B1.SelectedValue = GlobalTools.FormatDate_Month(conn.GetFieldValue(3, "BS_DATE_PERIODE"));
					TXT_YEAR_B1.Text = GlobalTools.FormatDate_Year(conn.GetFieldValue(3, "BS_DATE_PERIODE"));
					TXT_B5.Text = conn.GetFieldValue(3, "CASH_EQUIVALENTS");
					TXT_B6.Text = conn.GetFieldValue(3, "RECEIVABLES");
					TXT_B7.Text = conn.GetFieldValue(3, "TOTAL_ASSETS");
					TXT_B8.Text = conn.GetFieldValue(3, "PAYABLES");
					TXT_B9.Text = conn.GetFieldValue(3, "TOTAL_LOANS");
					TXT_B10.Text = conn.GetFieldValue(3, "INVESTMENT");
					TXT_B11.Text = conn.GetFieldValue(3, "WORKING_CAPITAL");
					TXT_B14.Text = conn.GetFieldValue(3, "REVENUE");
					TXT_B15.Text = conn.GetFieldValue(3, "EBIT");
					TXT_B16.Text = conn.GetFieldValue(3, "EBIT_MARGINS");
					TXT_B17.Text = conn.GetFieldValue(3, "NPAT");
					TXT_B18.Text = conn.GetFieldValue(3, "NPAT_MARGINS");
				}
			}
		}

		protected void BTN_BACK_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			Response.Redirect("../ActionPlan/CustomerList.aspx?mc=" + Request.QueryString["mc"]);
		}
	}

}
