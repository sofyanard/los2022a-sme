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
using DMS.CuBESCore;
using DMS.DBConnection;
using Microsoft.VisualBasic;

namespace SME.Syndication.CustomerBasicInformation
{
	/// <summary>
	/// Summary description for CreditFacility.
	/// </summary>
	public partial class CreditFacility : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.TextBox Textbox24;
		protected System.Web.UI.WebControls.Label Label25;
		protected System.Web.UI.WebControls.TextBox Textbox25;
		protected System.Web.UI.WebControls.Label Label26;
		protected System.Web.UI.WebControls.TextBox Textbox26;
		protected System.Web.UI.WebControls.Button BTN_SAVE_NON_CASH;
		protected System.Web.UI.WebControls.Button BTN_CLEAR_NON_CASH;
		protected Tools tools = new Tools();
		protected Connection conn = new Connection(ConfigurationSettings.AppSettings["conn"]);
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			ViewMenu();
			
			if(!IsPostBack)
			{
				FillDDLBank();
				FillDDLCurrency();
				FillDDLDate();
				FillDDLProduct();
			}
			FillDGRFacilities();
			FillDGRInvest();
			FillDGRModal();
			FillDGRLoan();
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
							strtemp = "&curef=" + Request.QueryString["curef"] + "&cif=" + Request.QueryString["cif"] + "&exist=" + Request.QueryString["exist"];
						else	
							strtemp = "&mc=" + Request.QueryString["mc"]+ "&curef=" + Request.QueryString["curef"] + "&cif=" + Request.QueryString["cif"] + "&exist=" + Request.QueryString["exist"];
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

		private void FillDDLBank()
		{
			DDL_BANK_NM_INVEST.Items.Clear();
			DDL_BANK_NM_MODAL.Items.Clear();
			DDL_BANK_NM_NONCASH.Items.Clear();

			DDL_BANK_NM_INVEST.Items.Add(new ListItem("--Select--", ""));
			DDL_BANK_NM_MODAL.Items.Add(new ListItem("--Select--", ""));
			DDL_BANK_NM_NONCASH.Items.Add(new ListItem("--Select--", ""));

			conn.QueryString = "SELECT BANKID, BANKNAME FROM RFBANK WHERE ACTIVE = '1' ORDER BY BANKNAME";
			conn.ExecuteQuery();
			for(int i=0; i < conn.GetRowCount(); i++)
			{
				DDL_BANK_NM_INVEST.Items.Add(new ListItem(conn.GetFieldValue(i,1), conn.GetFieldValue(i,0)));
				DDL_BANK_NM_MODAL.Items.Add(new ListItem(conn.GetFieldValue(i,1), conn.GetFieldValue(i,0)));
				DDL_BANK_NM_NONCASH.Items.Add(new ListItem(conn.GetFieldValue(i,1), conn.GetFieldValue(i,0)));
			}
		}

		private void FillDDLCurrency()
		{
			DDL_CURRENCY_INVEST.Items.Clear();
			DDL_CURRENCY_MODAL.Items.Clear();
			DDL_CURRENCY_NONCASH.Items.Clear();

			DDL_CURRENCY_INVEST.Items.Add(new ListItem("--Select--", ""));
			DDL_CURRENCY_MODAL.Items.Add(new ListItem("--Select--", ""));
			DDL_CURRENCY_NONCASH.Items.Add(new ListItem("--Select--", ""));

			conn.QueryString = "SELECT CURRENCYID, CURRENCYDESC FROM RFCURRENCY WHERE ACTIVE = '1' ORDER BY CURRENCYDESC";
			conn.ExecuteQuery();
			for(int i=0; i < conn.GetRowCount(); i++)
			{
				DDL_CURRENCY_INVEST.Items.Add(new ListItem(conn.GetFieldValue(i,1), conn.GetFieldValue(i,0)));
				DDL_CURRENCY_MODAL.Items.Add(new ListItem(conn.GetFieldValue(i,1), conn.GetFieldValue(i,0)));
				DDL_CURRENCY_NONCASH.Items.Add(new ListItem(conn.GetFieldValue(i,1), conn.GetFieldValue(i,0)));
			}
		}

		private void FillDDLDate()
		{
			//Tanggal Mulai
			DDL_START_MONTH_INVEST.Items.Clear();
			DDL_START_MONTH_MODAL.Items.Clear();
			DDL_START_MONTH_NONCASH.Items.Clear();

			DDL_START_MONTH_INVEST.Items.Add(new ListItem("--Select--",""));
			DDL_START_MONTH_MODAL.Items.Add(new ListItem("--Select--",""));
			DDL_START_MONTH_NONCASH.Items.Add(new ListItem("--Select--",""));

			//Tanggal Akhir
			DDL_MATURITY_MONTH_INVEST.Items.Clear();
			DDL_MATURITY_MONTH_MODAL.Items.Clear();
			DDL_MATURITY_MONTH_NONCASH.Items.Clear();

			DDL_MATURITY_MONTH_INVEST.Items.Add(new ListItem("--Select--",""));
			DDL_MATURITY_MONTH_MODAL.Items.Add(new ListItem("--Select--",""));
			DDL_MATURITY_MONTH_NONCASH.Items.Add(new ListItem("--Select--",""));

			for (int i = 1; i <= 12; i++)
			{
				DDL_START_MONTH_INVEST.Items.Add(new ListItem(DateAndTime.MonthName(i, false), i.ToString()));
				DDL_START_MONTH_MODAL.Items.Add(new ListItem(DateAndTime.MonthName(i, false), i.ToString()));
				DDL_START_MONTH_NONCASH.Items.Add(new ListItem(DateAndTime.MonthName(i, false), i.ToString()));

				DDL_MATURITY_MONTH_INVEST.Items.Add(new ListItem(DateAndTime.MonthName(i, false), i.ToString()));
				DDL_MATURITY_MONTH_MODAL.Items.Add(new ListItem(DateAndTime.MonthName(i, false), i.ToString()));
				DDL_MATURITY_MONTH_NONCASH.Items.Add(new ListItem(DateAndTime.MonthName(i, false), i.ToString()));
			}
		}

		private void FillDDLProduct()
		{
			DDL_PRODUCT_TYPE_NONCASH.Items.Clear();
			DDL_PRODUCT_TYPE_NONCASH.Items.Add(new ListItem("--Select--", ""));

			conn.QueryString = "SELECT * FROM VW_SDC_DDLPRODUCT ORDER BY PRODUCTDESC";
			conn.ExecuteQuery();
			for(int i=0; i < conn.GetRowCount(); i++)
			{
				DDL_PRODUCT_TYPE_NONCASH.Items.Add(new ListItem(conn.GetFieldValue(i,1), conn.GetFieldValue(i,0)));
			}
		}

		private void FillDGRFacilities()
		{
			conn.QueryString = "EXEC SDC_VIEW_FACILITIES_INFO '" + Request.QueryString["curef"] + "'";
			BindData(DGR_FACILITY.ID.ToString(), conn.QueryString, "0");
		}

		private void FillDGRInvest()
		{
			conn.QueryString = "SELECT * FROM VW_SDC_FACILITIES_INFO WHERE CU_REF = '" + Request.QueryString["curef"] + "' AND PRODUCT_ID = '1'";
			BindData(DGR_KREDIT_INVESTASI.ID.ToString(), conn.QueryString, "1");
		}
		
		private void FillDGRModal()
		{
			conn.QueryString = "SELECT * FROM VW_SDC_FACILITIES_INFO WHERE CU_REF = '" + Request.QueryString["curef"] + "' AND PRODUCT_ID = '2'";
			BindData(DGR_KREDIT_MODAL_KERJA.ID.ToString(), conn.QueryString, "2");
		}

		private void FillDGRLoan()
		{
			conn.QueryString = "SELECT * FROM VW_SDC_FACILITIES_INFO WHERE CU_REF = '" + Request.QueryString["curef"] + "' AND PRODUCT_ID = '3'";
			BindData(DGR_NONCASH_LOAN.ID.ToString(), conn.QueryString, "3");
		}

		private void BindData(string dataGridName, string strconn, string type)
		{
			if(strconn != "")
			{
				conn.QueryString = strconn;
				conn.ExecuteQuery();

				System.Data.DataTable dt = new System.Data.DataTable();
				dt = conn.GetDataTable().Copy();

				System.Web.UI.WebControls.DataGrid dg = (System.Web.UI.WebControls.DataGrid)Page.FindControl(dataGridName);
				dg.DataSource = dt;

				try
				{
					dg.DataBind();
				}
				catch
				{
					dg.CurrentPageIndex = dg.PageCount - 1;	
					dg.DataBind();
				}

				if(type == "1")
				{
					for (int i = 0; i < dg.Items.Count; i++)
					{
						dg.Items[i].Cells[3].Text = tools.MoneyFormat(dg.Items[i].Cells[3].Text);
						dg.Items[i].Cells[4].Text = tools.MoneyFormat(dg.Items[i].Cells[4].Text);
						dg.Items[i].Cells[5].Text = tools.MoneyFormat(dg.Items[i].Cells[5].Text);
						dg.Items[i].Cells[6].Text = tools.MoneyFormat(dg.Items[i].Cells[6].Text);
						dg.Items[i].Cells[7].Text = tools.MoneyFormat(dg.Items[i].Cells[7].Text);
						dg.Items[i].Cells[8].Text = tools.MoneyFormat(dg.Items[i].Cells[8].Text);
						dg.Items[i].Cells[9].Text = tools.FormatDate(dg.Items[i].Cells[9].Text, true);
						dg.Items[i].Cells[10].Text = tools.FormatDate(dg.Items[i].Cells[10].Text, true);
					} 
				}

				else if(type == "2")
				{
					for (int i = 0; i < dg.Items.Count; i++)
					{
						dg.Items[i].Cells[3].Text = tools.MoneyFormat(dg.Items[i].Cells[3].Text);
						dg.Items[i].Cells[4].Text = tools.MoneyFormat(dg.Items[i].Cells[4].Text);
						dg.Items[i].Cells[5].Text = tools.MoneyFormat(dg.Items[i].Cells[5].Text);
						dg.Items[i].Cells[6].Text = tools.FormatDate(dg.Items[i].Cells[6].Text, true);
						dg.Items[i].Cells[7].Text = tools.FormatDate(dg.Items[i].Cells[7].Text, true);
					} 
				}

				else if(type == "3")
				{
					for (int i = 0; i < dg.Items.Count; i++)
					{
						dg.Items[i].Cells[4].Text = tools.MoneyFormat(dg.Items[i].Cells[4].Text);
						dg.Items[i].Cells[5].Text = tools.MoneyFormat(dg.Items[i].Cells[5].Text);
						dg.Items[i].Cells[6].Text = tools.FormatDate(dg.Items[i].Cells[6].Text, true);
						dg.Items[i].Cells[7].Text = tools.FormatDate(dg.Items[i].Cells[7].Text, true);
					} 
				}
				else
				{
					for (int i = 0; i < dg.Items.Count; i++)
					{
						dg.Items[i].Cells[2].Text = tools.MoneyFormat(dg.Items[i].Cells[2].Text);
						dg.Items[i].Cells[3].Text = tools.MoneyFormat(dg.Items[i].Cells[3].Text);
					} 
				}

				conn.ClearData();
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
			this.DGR_KREDIT_INVESTASI.ItemCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.DGR_KREDIT_INVESTASI_ItemCommand);
			this.DGR_KREDIT_INVESTASI.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.DGR_KREDIT_INVESTASI_PageIndexChanged);
			this.DGR_KREDIT_MODAL_KERJA.ItemCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.DGR_KREDIT_MODAL_KERJA_ItemCommand);
			this.DGR_KREDIT_MODAL_KERJA.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.DGR_KREDIT_MODAL_KERJA_PageIndexChanged);
			this.DGR_NONCASH_LOAN.ItemCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.DGR_NONCASH_LOAN_ItemCommand);
			this.DGR_NONCASH_LOAN.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.DGR_NONCASH_LOAN_PageIndexChanged);

		}
		#endregion

		protected void BTN_SAVE_INVEST_Click(object sender, System.EventArgs e)
		{
			InsertData("1");
		}

		protected void BTN_SAVE_MODAL_Click(object sender, System.EventArgs e)
		{
			InsertData("2");
		}

		protected void BTN_SAVE_NONCASH_Click(object sender, System.EventArgs e)
		{
			InsertData("3");
		}

		private void InsertData(string PRODUCT_TYPE)
		{	
			switch(PRODUCT_TYPE)
			{
				case "1":
					if (TXT_START_DAY_INVEST.Text != "" && DDL_START_MONTH_INVEST.SelectedValue != "" && TXT_START_YEAR_INVEST.Text != "") 
					{
						if (!GlobalTools.isDateValid(TXT_START_DAY_INVEST.Text, DDL_START_MONTH_INVEST.SelectedValue, TXT_START_YEAR_INVEST.Text)) 
						{
							GlobalTools.popMessage(this, "Tanggal Mulai Tidak Valid!");
							return;
						}
					}

					if (TXT_MATURITY_DAY_INVEST.Text != "" && DDL_MATURITY_MONTH_INVEST.SelectedValue != "" && TXT_MATURITY_YEAR_INVEST.Text != "") 
					{
						if (!GlobalTools.isDateValid(TXT_MATURITY_DAY_INVEST.Text, DDL_MATURITY_MONTH_INVEST.SelectedValue, TXT_MATURITY_YEAR_INVEST.Text)) 
						{
							GlobalTools.popMessage(this, "Tanggal Akhir Tidak Valid!");
							return;
						}
					}

					try
					{
						conn.QueryString = "EXEC SDC_FACILITIES_INFO_INVESTASI_INSERT '" +
											LBL_SEQ_INVEST.Text + "','" +
											Session["UserID"].ToString() + "','" +
											Request.QueryString["curef"] + "','" +
											Request.QueryString["cif"] + "','" +
											PRODUCT_TYPE + "','" +
											DDL_BANK_NM_INVEST.SelectedValue + "','" +
											DDL_CURRENCY_INVEST.SelectedValue + "','" +
											TXT_EXCHANGE_INVEST.Text.Replace(".","").Replace(",",".") + "','" +
											TXT_LIMIT_POKOK_INVEST.Text.Replace(".","").Replace(",",".") + "','" +
											TXT_LIMIT_IDC_INVEST.Text.Replace(".","").Replace(",",".") + "','" +
											TXT_LIMIT_POKOK_RP_INVEST.Text.Replace(".","").Replace(",",".") + "','" +
											TXT_LIMIT_IDC_RP_INVEST.Text.Replace(".","").Replace(",",".") + "','" +
											TXT_BUNGA_POKOK_INVEST.Text.Replace(",",".") + "','" +
											TXT_BUNGA_IDC_INVEST.Text.Replace(",",".") + "','" +
											TXT_IDC_PERCENT_INVEST.Text.Replace(",",".") + "'," +
											tools.ConvertDate(TXT_START_DAY_INVEST.Text, DDL_START_MONTH_INVEST.SelectedValue, TXT_START_YEAR_INVEST.Text) + "," +
											tools.ConvertDate(TXT_MATURITY_DAY_INVEST.Text, DDL_MATURITY_MONTH_INVEST.SelectedValue, TXT_MATURITY_YEAR_INVEST.Text) + ",'" +
											TXT_BUNGA_DENDA_PERCENT_INVEST.Text.Replace(",",".") + "','" +
											TXT_COMMITMENT_FEE_PERCENT_INVEST.Text.Replace(",",".") + "','" +
											TXT_OTHERS_FEE_PERCENT_INVEST.Text.Replace(",",".") + "'";
						conn.ExecuteQuery();

						ClearData("1");
						FillDGRInvest();
						FillDGRFacilities();
					}

					catch(Exception ex)
					{
						string errmsg = ex.Message.Replace("'","");
						if (errmsg.IndexOf("Last Query:") > 0)
							errmsg = errmsg.Substring(0, errmsg.IndexOf("Last Query:"));
						GlobalTools.popMessage(this, errmsg);
						return;
					}
					break;

				case "2":
					if (TXT_START_DAY_MODAL.Text != "" && DDL_START_MONTH_MODAL.SelectedValue != "" && TXT_START_YEAR_MODAL.Text != "") 
					{
						if (!GlobalTools.isDateValid(TXT_START_DAY_MODAL.Text, DDL_START_MONTH_MODAL.SelectedValue, TXT_START_YEAR_MODAL.Text)) 
						{
							GlobalTools.popMessage(this, "Tanggal Mulai Tidak Valid!");
							return;
						}
					}

					if (TXT_MATURITY_DAY_MODAL.Text != "" && DDL_MATURITY_MONTH_MODAL.SelectedValue != "" && TXT_MATURITY_YEAR_MODAL.Text != "") 
					{
						if (!GlobalTools.isDateValid(TXT_MATURITY_DAY_MODAL.Text, DDL_MATURITY_MONTH_MODAL.SelectedValue, TXT_MATURITY_YEAR_MODAL.Text)) 
						{
							GlobalTools.popMessage(this, "Tanggal Akhir Tidak Valid!");
							return;
						}
					}

					try
					{
						conn.QueryString = "EXEC SDC_FACILITIES_INFO_MODAL_INSERT '" +
											LBL_SEQ_MODAL.Text + "','" +
											Session["UserID"].ToString() + "','" +
											Request.QueryString["curef"] + "','" +
											Request.QueryString["cif"] + "','" +
											PRODUCT_TYPE + "','" +
											DDL_BANK_NM_MODAL.SelectedValue + "','" +
											DDL_CURRENCY_MODAL.SelectedValue + "','" +
											TXT_EXCHANGE_MODAL.Text.Replace(".","").Replace(",",".") + "','" +
											TXT_LIMIT_POKOK_MODAL.Text.Replace(".","").Replace(",",".") + "','" +
											TXT_LIMIT_POKOK_RP_MODAL.Text.Replace(".","").Replace(",",".") + "','" +
											TXT_SUKU_BUNGA_MODAL.Text.Replace(",",".") + "','" +
											TXT_BUNGA_DENDA_PERCENT_MODAL.Text.Replace(",",".") + "','" +
											TXT_COMMITMENT_FEE_PERCENT_MODAL.Text.Replace(",",".") + "','" +
											TXT_OTHERS_FEE_PERCENT_MODAL.Text.Replace(",",".") + "'," +
											tools.ConvertDate(TXT_START_DAY_MODAL.Text, DDL_START_MONTH_MODAL.SelectedValue, TXT_START_YEAR_MODAL.Text) + "," +
											tools.ConvertDate(TXT_MATURITY_DAY_MODAL.Text, DDL_MATURITY_MONTH_MODAL.SelectedValue, TXT_MATURITY_YEAR_MODAL.Text);
						conn.ExecuteQuery();

						ClearData("2");
						FillDGRModal();
						FillDGRFacilities();
					}

					catch(Exception ex)
					{
						string errmsg = ex.Message.Replace("'","");
						if (errmsg.IndexOf("Last Query:") > 0)
							errmsg = errmsg.Substring(0, errmsg.IndexOf("Last Query:"));
						GlobalTools.popMessage(this, errmsg);
						return;
					}
					break;

				case "3":
					if (TXT_START_DAY_NONCASH.Text != "" && DDL_START_MONTH_NONCASH.SelectedValue != "" && TXT_START_YEAR_NONCASH.Text != "") 
					{
						if (!GlobalTools.isDateValid(TXT_START_DAY_NONCASH.Text, DDL_START_MONTH_NONCASH.SelectedValue, TXT_START_YEAR_NONCASH.Text)) 
						{
							GlobalTools.popMessage(this, "Tanggal Mulai Tidak Valid!");
							return;
						}
					}

					if (TXT_MATURITY_DAY_NONCASH.Text != "" && DDL_MATURITY_MONTH_NONCASH.SelectedValue != "" && TXT_MATURITY_YEAR_NONCASH.Text != "") 
					{
						if (!GlobalTools.isDateValid(TXT_MATURITY_DAY_NONCASH.Text, DDL_MATURITY_MONTH_NONCASH.SelectedValue, TXT_MATURITY_YEAR_NONCASH.Text)) 
						{
							GlobalTools.popMessage(this, "Tanggal Akhir Tidak Valid!");
							return;
						}
					}

					try
					{
						conn.QueryString = "EXEC SDC_FACILITIES_INFO_LOAN_INSERT '" +
											LBL_SEQ_NONCASH.Text + "','" +
											Session["UserID"].ToString() + "','" +
											Request.QueryString["curef"] + "','" +
											Request.QueryString["cif"] + "','" +
											PRODUCT_TYPE + "','" +
											DDL_BANK_NM_NONCASH.SelectedValue + "','" +
											DDL_PRODUCT_TYPE_NONCASH.SelectedValue + "','" +
											DDL_CURRENCY_NONCASH.SelectedValue + "','" +
											TXT_EXCHANGE_NONCASH.Text.Replace(".","").Replace(",",".") + "','" +
											TXT_NOMINAL_NONCASH.Text.Replace(".","").Replace(",",".") + "','" +
											TXT_NOMINAL_RP_NONCASH.Text.Replace(".","").Replace(",",".") + "','" +
											TXT_PROVISI_KOMISI_PERCENT_NONCASH.Text.Replace(",",".") + "','" +
											TXT_OTHERS_FEE_PERCENT_NONCASH.Text.Replace(",",".") + "'," +
											tools.ConvertDate(TXT_START_DAY_NONCASH.Text, DDL_START_MONTH_NONCASH.SelectedValue, TXT_START_YEAR_NONCASH.Text) + "," +
											tools.ConvertDate(TXT_MATURITY_DAY_NONCASH.Text, DDL_MATURITY_MONTH_NONCASH.SelectedValue, TXT_MATURITY_YEAR_NONCASH.Text);
						conn.ExecuteQuery();

						ClearData("3");
						FillDGRLoan();
						FillDGRFacilities();
					}

					catch(Exception ex)
					{
						string errmsg = ex.Message.Replace("'","");
						if (errmsg.IndexOf("Last Query:") > 0)
							errmsg = errmsg.Substring(0, errmsg.IndexOf("Last Query:"));
						GlobalTools.popMessage(this, errmsg);
						return;
					}
					break;
			}
		}

		protected void BTN_CLEAR_INVEST_Click(object sender, System.EventArgs e)
		{
			ClearData("1");
		}

		protected void BTN_CLEAR_MODAL_Click(object sender, System.EventArgs e)
		{
			ClearData("2");
		}

		protected void BTN_CLEAR_NONCASH_Click(object sender, System.EventArgs e)
		{
			ClearData("3");
		}

		private void ClearData(string type)
		{
			switch(type)
			{
				case "1":
					LBL_SEQ_INVEST.Text						= "";
					DDL_BANK_NM_INVEST.SelectedValue		= "";
					DDL_CURRENCY_INVEST.SelectedValue		= "";
					TXT_EXCHANGE_INVEST.Text				= "";
					TXT_LIMIT_POKOK_INVEST.Text				= "";
					TXT_LIMIT_IDC_INVEST.Text				= "";
					TXT_LIMIT_POKOK_RP_INVEST.Text			= "";
					TXT_LIMIT_IDC_RP_INVEST.Text			= "";
					TXT_BUNGA_POKOK_INVEST.Text				= "";
					TXT_BUNGA_IDC_INVEST.Text				= "";
					TXT_IDC_PERCENT_INVEST.Text				= "";
					TXT_START_DAY_INVEST.Text				= "";
					DDL_START_MONTH_INVEST.SelectedValue	= "";
					TXT_START_YEAR_INVEST.Text				= "";
					TXT_MATURITY_DAY_INVEST.Text			= "";
					DDL_MATURITY_MONTH_INVEST.SelectedValue	= "";
					TXT_MATURITY_YEAR_INVEST.Text			= "";
					TXT_BUNGA_DENDA_PERCENT_INVEST.Text		= "";
					TXT_COMMITMENT_FEE_PERCENT_INVEST.Text	= "";
					TXT_OTHERS_FEE_PERCENT_INVEST.Text		= "";
					break;

				case "2":
					LBL_SEQ_MODAL.Text						= "";
					DDL_BANK_NM_MODAL.SelectedValue			= "";
					DDL_CURRENCY_MODAL.SelectedValue		= "";
					TXT_EXCHANGE_MODAL.Text					= "";
					TXT_LIMIT_POKOK_MODAL.Text				= "";
					TXT_LIMIT_POKOK_RP_MODAL.Text			= "";
					TXT_SUKU_BUNGA_MODAL.Text				= "";
					TXT_BUNGA_DENDA_PERCENT_MODAL.Text		= "";
					TXT_COMMITMENT_FEE_PERCENT_MODAL.Text	= "";
					TXT_OTHERS_FEE_PERCENT_MODAL.Text		= "";
					TXT_START_DAY_MODAL.Text				= "";
					DDL_START_MONTH_MODAL.SelectedValue		= "";
					TXT_START_YEAR_MODAL.Text				= "";
					TXT_MATURITY_DAY_MODAL.Text				= "";
					DDL_MATURITY_MONTH_MODAL.SelectedValue	= "";
					TXT_MATURITY_YEAR_MODAL.Text			= "";
					break;

				case "3":
					LBL_SEQ_NONCASH.Text					= "";
					DDL_BANK_NM_NONCASH.SelectedValue		= "";
					DDL_PRODUCT_TYPE_NONCASH.SelectedValue	= "";
					DDL_CURRENCY_NONCASH.SelectedValue		= "";
					TXT_EXCHANGE_NONCASH.Text				= "";
					TXT_NOMINAL_NONCASH.Text				= "";
					TXT_NOMINAL_RP_NONCASH.Text				= "";
					TXT_PROVISI_KOMISI_PERCENT_NONCASH.Text	= "";
					TXT_OTHERS_FEE_PERCENT_NONCASH.Text		= "";
					TXT_START_DAY_NONCASH.Text				= "";
					DDL_START_MONTH_NONCASH.SelectedValue	= "";
					TXT_START_YEAR_NONCASH.Text				= "";
					TXT_MATURITY_DAY_NONCASH.Text			= "";
					DDL_MATURITY_MONTH_NONCASH.SelectedValue= "";
					TXT_MATURITY_YEAR_NONCASH.Text			= "";
					break;
			}
			FillDGRFacilities();
		}

		protected void BTN_BACK_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			Response.Redirect("../CustomerList.aspx?mc=" + Request.QueryString["mc"]);
		}

		private void DGR_KREDIT_INVESTASI_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			DGR_KREDIT_INVESTASI.CurrentPageIndex = e.NewPageIndex;
			FillDGRInvest();
		}

		private void DGR_KREDIT_INVESTASI_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			switch(((LinkButton)e.CommandSource).CommandName)
			{
				case "edit":
					conn.QueryString = "SELECT * FROM SDC_FACILITIES_INFO WHERE SEQ = '" + e.Item.Cells[0].Text.ToString() + "' AND CU_REF = '" + Request.QueryString["curef"] + "' AND PRODUCT_TYPE = '1'";
					conn.ExecuteQuery();

					LBL_SEQ_INVEST.Text						= conn.GetFieldValue("SEQ").ToString().Replace("&nbsp;","");
					DDL_BANK_NM_INVEST.SelectedValue		= conn.GetFieldValue("BANK_NM").ToString();
					DDL_CURRENCY_INVEST.SelectedValue		= conn.GetFieldValue("CURR").ToString();
					TXT_EXCHANGE_INVEST.Text				= tools.MoneyFormat(conn.GetFieldValue("CURR_RATE").ToString().Replace("&nbsp;",""));
					TXT_LIMIT_POKOK_INVEST.Text				= tools.MoneyFormat(conn.GetFieldValue("LIMIT_POKOK").ToString().Replace("&nbsp;",""));
					TXT_LIMIT_IDC_INVEST.Text				= tools.MoneyFormat(conn.GetFieldValue("LIMIT_IDC").ToString().Replace("&nbsp;",""));
					TXT_LIMIT_POKOK_RP_INVEST.Text			= tools.MoneyFormat(conn.GetFieldValue("LIMIT_POKOK_RP").ToString().Replace("&nbsp;",""));
					TXT_LIMIT_IDC_RP_INVEST.Text			= tools.MoneyFormat(conn.GetFieldValue("LIMIT_IDC_RP").ToString().Replace("&nbsp;",""));
					TXT_BUNGA_POKOK_INVEST.Text				= conn.GetFieldValue("RATE_PERCENT").ToString().Replace("&nbsp;","");
					TXT_BUNGA_IDC_INVEST.Text				= conn.GetFieldValue("RATE_IDC_PERCENT").ToString().Replace("&nbsp;","");
					TXT_IDC_PERCENT_INVEST.Text				= conn.GetFieldValue("IDC_PERCENT").ToString().Replace("&nbsp;","");
					TXT_START_DAY_INVEST.Text				= tools.FormatDate_Day(conn.GetFieldValue("START_DATE").ToString());
					DDL_START_MONTH_INVEST.SelectedValue	= tools.FormatDate_Month(conn.GetFieldValue("START_DATE").ToString());
					TXT_START_YEAR_INVEST.Text				= tools.FormatDate_Year(conn.GetFieldValue("START_DATE").ToString());
					TXT_MATURITY_DAY_INVEST.Text			= tools.FormatDate_Day(conn.GetFieldValue("MATURITY_DATE").ToString());
					DDL_MATURITY_MONTH_INVEST.SelectedValue	= tools.FormatDate_Month(conn.GetFieldValue("MATURITY_DATE").ToString());
					TXT_MATURITY_YEAR_INVEST.Text			= tools.FormatDate_Year(conn.GetFieldValue("MATURITY_DATE").ToString());
					TXT_BUNGA_DENDA_PERCENT_INVEST.Text		= conn.GetFieldValue("RATE_INTEREST_PERCENT").ToString().Replace("&nbsp;","");
					TXT_COMMITMENT_FEE_PERCENT_INVEST.Text	= conn.GetFieldValue("COM_FEE_PERCENT").ToString().Replace("&nbsp;","");
					TXT_OTHERS_FEE_PERCENT_INVEST.Text		= conn.GetFieldValue("OTHER_FEE_PERCENT").ToString().Replace("&nbsp;","");
					break;

				case "delete":
					conn.QueryString = "DELETE SDC_FACILITIES_INFO WHERE SEQ = '" + e.Item.Cells[0].Text.ToString() + "' AND CU_REF = '" + Request.QueryString["curef"] + "' AND PRODUCT_TYPE = '1'";
					conn.ExecuteQuery();

					FillDGRInvest();
					FillDGRFacilities();
					break;
			}
		}

		private void DGR_KREDIT_MODAL_KERJA_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			DGR_KREDIT_MODAL_KERJA.CurrentPageIndex = e.NewPageIndex;
			FillDGRModal();
		}

		private void DGR_KREDIT_MODAL_KERJA_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			switch(((LinkButton)e.CommandSource).CommandName)
			{
				case "edit":
					conn.QueryString = "SELECT * FROM SDC_FACILITIES_INFO WHERE SEQ = '" + e.Item.Cells[0].Text.ToString() + "' AND CU_REF = '" + Request.QueryString["curef"] + "' AND PRODUCT_TYPE = '2'";
					conn.ExecuteQuery();

					LBL_SEQ_MODAL.Text						= conn.GetFieldValue("SEQ").ToString().Replace("&nbsp;","");
					DDL_BANK_NM_MODAL.SelectedValue			= conn.GetFieldValue("BANK_NM").ToString();
					DDL_CURRENCY_MODAL.SelectedValue		= conn.GetFieldValue("CURR").ToString();
					TXT_EXCHANGE_MODAL.Text					= tools.MoneyFormat(conn.GetFieldValue("CURR_RATE").ToString().Replace("&nbsp;",""));
					TXT_LIMIT_POKOK_MODAL.Text				= tools.MoneyFormat(conn.GetFieldValue("LIMIT_POKOK").ToString().Replace("&nbsp;",""));
					TXT_LIMIT_POKOK_RP_MODAL.Text			= tools.MoneyFormat(conn.GetFieldValue("LIMIT_POKOK_RP").ToString().Replace("&nbsp;",""));
					TXT_SUKU_BUNGA_MODAL.Text				= conn.GetFieldValue("RATE_PERCENT").ToString().Replace("&nbsp;","");
					TXT_BUNGA_DENDA_PERCENT_MODAL.Text		= conn.GetFieldValue("RATE_INTEREST_PERCENT").ToString().Replace("&nbsp;","");
					TXT_COMMITMENT_FEE_PERCENT_MODAL.Text	= conn.GetFieldValue("COM_FEE_PERCENT").ToString().Replace("&nbsp;","");
					TXT_OTHERS_FEE_PERCENT_MODAL.Text		= conn.GetFieldValue("OTHER_FEE_PERCENT").ToString().Replace("&nbsp;","");
					TXT_START_DAY_MODAL.Text				= tools.FormatDate_Day(conn.GetFieldValue("START_DATE").ToString());
					DDL_START_MONTH_MODAL.SelectedValue		= tools.FormatDate_Month(conn.GetFieldValue("START_DATE").ToString());
					TXT_START_YEAR_MODAL.Text				= tools.FormatDate_Year(conn.GetFieldValue("START_DATE").ToString());
					TXT_MATURITY_DAY_MODAL.Text				= tools.FormatDate_Day(conn.GetFieldValue("MATURITY_DATE").ToString());
					DDL_MATURITY_MONTH_MODAL.SelectedValue	= tools.FormatDate_Month(conn.GetFieldValue("MATURITY_DATE").ToString());
					TXT_MATURITY_YEAR_MODAL.Text			= tools.FormatDate_Year(conn.GetFieldValue("MATURITY_DATE").ToString());
					break;

				case "delete":
					conn.QueryString = "DELETE SDC_FACILITIES_INFO WHERE SEQ = '" + e.Item.Cells[0].Text.ToString() + "' AND CU_REF = '" + Request.QueryString["curef"] + "' AND PRODUCT_TYPE = '2'";
					conn.ExecuteQuery();

					FillDGRModal();
					FillDGRFacilities();
					break;
			}
		}

		private void DGR_NONCASH_LOAN_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			DGR_NONCASH_LOAN.CurrentPageIndex = e.NewPageIndex;
			FillDGRLoan();
		}

		private void DGR_NONCASH_LOAN_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			switch(((LinkButton)e.CommandSource).CommandName)
			{
				case "edit":
					conn.QueryString = "SELECT * FROM SDC_FACILITIES_INFO WHERE SEQ = '" + e.Item.Cells[0].Text.ToString() + "' AND CU_REF = '" + Request.QueryString["curef"] + "' AND PRODUCT_TYPE = '3'";
					conn.ExecuteQuery();

					LBL_SEQ_NONCASH.Text					= conn.GetFieldValue("SEQ").ToString().Replace("&nbsp;","");
					DDL_BANK_NM_NONCASH.SelectedValue		= conn.GetFieldValue("BANK_NM").ToString();
					DDL_PRODUCT_TYPE_NONCASH.SelectedValue	= conn.GetFieldValue("NCL_PRODUCT_TYPE").ToString();
					DDL_CURRENCY_NONCASH.SelectedValue		= conn.GetFieldValue("CURR").ToString();
					TXT_EXCHANGE_NONCASH.Text				= tools.MoneyFormat(conn.GetFieldValue("CURR_RATE").ToString().Replace("&nbsp;",""));
					TXT_NOMINAL_NONCASH.Text				= tools.MoneyFormat(conn.GetFieldValue("LIMIT_POKOK").ToString().Replace("&nbsp;",""));
					TXT_NOMINAL_RP_NONCASH.Text				= tools.MoneyFormat(conn.GetFieldValue("LIMIT_POKOK_RP").ToString().Replace("&nbsp;",""));
					TXT_PROVISI_KOMISI_PERCENT_NONCASH.Text	= conn.GetFieldValue("PROVISI_KOMISI_PERCENT").ToString().Replace("&nbsp;","");
					TXT_OTHERS_FEE_PERCENT_NONCASH.Text		= conn.GetFieldValue("OTHER_FEE_PERCENT").ToString().Replace("&nbsp;","");
					TXT_START_DAY_NONCASH.Text				= tools.FormatDate_Day(conn.GetFieldValue("START_DATE").ToString());
					DDL_START_MONTH_NONCASH.SelectedValue	= tools.FormatDate_Month(conn.GetFieldValue("START_DATE").ToString());
					TXT_START_YEAR_NONCASH.Text				= tools.FormatDate_Year(conn.GetFieldValue("START_DATE").ToString());
					TXT_MATURITY_DAY_NONCASH.Text			= tools.FormatDate_Day(conn.GetFieldValue("MATURITY_DATE").ToString());
					DDL_MATURITY_MONTH_NONCASH.SelectedValue= tools.FormatDate_Month(conn.GetFieldValue("MATURITY_DATE").ToString());
					TXT_MATURITY_YEAR_NONCASH.Text			= tools.FormatDate_Year(conn.GetFieldValue("MATURITY_DATE").ToString());
					break;

				case "delete":
					conn.QueryString = "DELETE SDC_FACILITIES_INFO WHERE SEQ = '" + e.Item.Cells[0].Text.ToString() + "' AND CU_REF = '" + Request.QueryString["curef"] + "' AND PRODUCT_TYPE = '3'";
					conn.ExecuteQuery();

					FillDGRLoan();
					FillDGRFacilities();
					break;
			}
		}

		protected void DDL_CURRENCY_INVEST_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			conn.QueryString = "SELECT CURRENCYRATE FROM RFCURRENCY WHERE CURRENCYID = '" + DDL_CURRENCY_INVEST.SelectedValue + "' AND ACTIVE='1'";
			conn.ExecuteQuery();

			TXT_EXCHANGE_INVEST.Text = tools.MoneyFormat(conn.GetFieldValue("CURRENCYRATE").ToString());
		}

		protected void TXT_LIMIT_POKOK_INVEST_TextChanged(object sender, System.EventArgs e)
		{
			conn.QueryString = "EXEC SDC_EXCHANGE_RATE '" + TXT_EXCHANGE_INVEST.Text.Replace(".","").Replace(",",".") + "','" + TXT_LIMIT_POKOK_INVEST.Text.Replace(".","").Replace(",",".") + "'";
			conn.ExecuteQuery();

			TXT_LIMIT_POKOK_RP_INVEST.Text = tools.MoneyFormat(conn.GetFieldValue("LIMIT").ToString());
		}

		protected void TXT_LIMIT_IDC_INVEST_TextChanged(object sender, System.EventArgs e)
		{
			conn.QueryString = "EXEC SDC_EXCHANGE_RATE '" + TXT_EXCHANGE_INVEST.Text.Replace(".","").Replace(",",".") + "','" + TXT_LIMIT_IDC_INVEST.Text.Replace(".","").Replace(",",".") + "'";
			conn.ExecuteQuery();

			TXT_LIMIT_IDC_RP_INVEST.Text = tools.MoneyFormat(conn.GetFieldValue("LIMIT").ToString());
		}

		protected void DDL_CURRENCY_MODAL_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			conn.QueryString = "SELECT CURRENCYRATE FROM RFCURRENCY WHERE CURRENCYID = '" + DDL_CURRENCY_MODAL.SelectedValue + "' AND ACTIVE='1'";
			conn.ExecuteQuery();

			TXT_EXCHANGE_MODAL.Text = tools.MoneyFormat(conn.GetFieldValue("CURRENCYRATE").ToString());
		}

		protected void TXT_LIMIT_POKOK_MODAL_TextChanged(object sender, System.EventArgs e)
		{
			conn.QueryString = "EXEC SDC_EXCHANGE_RATE '" + TXT_EXCHANGE_MODAL.Text.Replace(".","").Replace(",",".") + "','" + TXT_LIMIT_POKOK_MODAL.Text.Replace(".","").Replace(",",".") + "'";
			conn.ExecuteQuery();

			TXT_LIMIT_POKOK_RP_MODAL.Text = tools.MoneyFormat(conn.GetFieldValue("LIMIT").ToString());
		}

		protected void DDL_CURRENCY_NONCASH_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			conn.QueryString = "SELECT CURRENCYRATE FROM RFCURRENCY WHERE CURRENCYID = '" + DDL_CURRENCY_NONCASH.SelectedValue + "' AND ACTIVE='1'";
			conn.ExecuteQuery();

			TXT_EXCHANGE_NONCASH.Text = tools.MoneyFormat(conn.GetFieldValue("CURRENCYRATE").ToString());
		}

		protected void TXT_NOMINAL_NONCASH_TextChanged(object sender, System.EventArgs e)
		{
			conn.QueryString = "EXEC SDC_EXCHANGE_RATE '" + TXT_EXCHANGE_NONCASH.Text.Replace(".","").Replace(",",".") + "','" + TXT_NOMINAL_NONCASH.Text.Replace(".","").Replace(",",".") + "'";
			conn.ExecuteQuery();

			TXT_NOMINAL_RP_NONCASH.Text = tools.MoneyFormat(conn.GetFieldValue("LIMIT").ToString());
		}
	}
}
