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

namespace SME.AccountPlanning
{
	/// <summary>
	/// Summary description for CustomerList.
	/// </summary>
	public partial class CustomerList : System.Web.UI.Page
	{
		protected Tools tools = new Tools();
		protected Connection conn = new Connection(ConfigurationSettings.AppSettings["conn"]);
		protected Connection conn2 = new Connection(ConfigurationSettings.AppSettings["conn"]);
		protected Connection conn3 = new Connection(ConfigurationSettings.AppSettings["conn"]);
		protected Connection conn4 = new Connection(ConfigurationSettings.AppSettings["conn"]);
		protected Connection conn5 = new Connection(ConfigurationSettings.AppSettings["conn"]);
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			if(!IsPostBack)
			{
				FillDDLSegment();
				FillDDLUnit();
	
				if(Request.QueryString["mc"] == "AP05")			//wallet share & target
				{
					conn.QueryString = "SELECT DISTINCT * FROM VW_AP_CUSTOMER_LIST_TEMP";
					BindData(DATA_GRID.ID.ToString(), conn.QueryString);
				}

				else if(Request.QueryString["mc"] == "AP06")	//action plan
				{
					BTN_New.Visible = true;
					conn.QueryString = "SELECT DISTINCT CIF#,BUSSUNITID,BUSSUNITDESC,BUC,BRANCH_NAME,RM_NAME,CUSTOMER_GROUP FROM VW_AP_CUSTOMER_LIST2";
					BindData(DATA_GRID.ID.ToString(), conn.QueryString);
				}
				
				else
				{
					conn.QueryString = "SELECT DISTINCT CIF#,BUSSUNITID,BUSSUNITDESC,BUC,BRANCH_NAME,RM_NAME,CUSTOMER_GROUP FROM VW_AP_CUSTOMER_LIST";
					BindData(DATA_GRID.ID.ToString(), conn.QueryString);
				}
			}
		}

		private void FillDDLSegment()
		{
			DDL_SEGMENT.Items.Clear();
			DDL_SEGMENT.Items.Add(new ListItem("--Select--", ""));

			conn.QueryString = "SELECT BUSSUNITID, BUSSUNITDESC FROM RFBUSINESSUNIT WHERE ACTIVE='1' ORDER BY BUSSUNITDESC";
			conn.ExecuteQuery();
			
			for(int i=0; i < conn.GetRowCount(); i++)
			{
				DDL_SEGMENT.Items.Add(new ListItem(conn.GetFieldValue(i,1), conn.GetFieldValue(i,0)));
			}
		}

		private void FillDDLUnit()
		{
			DDL_UNIT.Items.Clear();
			DDL_UNIT.Items.Add(new ListItem("--Select--", ""));

			if(DDL_SEGMENT.SelectedValue == "")
			{
				conn.QueryString = "SELECT BRANCH_CODE, BRANCH_NAME FROM RFBRANCH WHERE ACTIVE='1' ORDER BY BRANCH_NAME";
				conn.ExecuteQuery();
			}
			else
			{
				conn.QueryString = "SELECT BRANCH_CODE, BRANCH_NAME FROM RFBRANCH WHERE BUSSUNITID = '" + DDL_SEGMENT.SelectedValue + "' AND ACTIVE='1' ORDER BY BRANCH_NAME";
				conn.ExecuteQuery();
			}
			
			for(int i=0; i < conn.GetRowCount(); i++)
			{
				DDL_UNIT.Items.Add(new ListItem(conn.GetFieldValue(i,1), conn.GetFieldValue(i,0)));
			}
		}

		/*private void FillDDLUpliner()
		{
			DDL_CST.Items.Clear();
			DDL_CST.Items.Add(new ListItem("--Select--", ""));

			if(DDL_UNIT.SelectedValue == "")
			{
				conn.QueryString = "SELECT USERID, SU_FULLNAME FROM SCUSER WHERE GROUPID IN('010101010101010501','010101010101010505','00001','0101010101010106','010101010101010601','01010101010356') AND SU_ACTIVE='1' ORDER BY SU_FULLNAME";
				conn.ExecuteQuery();
			}
			else
			{
				conn.QueryString = "SELECT USERID, SU_FULLNAME, SU_BRANCH FROM SCUSER WHERE GROUPID IN('010101010101010501','010101010101010505','00001','0101010101010106','010101010101010601','01010101010356') AND SU_BRANCH = '" + DDL_UNIT.SelectedValue + "' AND SU_ACTIVE='1' ORDER BY SU_FULLNAME";
				conn.ExecuteQuery();
			}
			
			for(int i=0; i < conn.GetRowCount(); i++)
			{
				DDL_CST.Items.Add(new ListItem(conn.GetFieldValue(i,1), conn.GetFieldValue(i,0)));
			}
		}*/

		/*private void FillDDLAnchor()
		{
			DDL_ANCHOR.Items.Clear();
			DDL_ANCHOR.Items.Add(new ListItem("--Select--", ""));

			if(DDL_UNIT.SelectedValue == "")
			{
				//conn.QueryString = "SELECT CIF#, CUSTOMER_GROUP FROM AP_ANCHOR_INFO";
				conn.QueryString = "SELECT DISTINCT CIF#, CUSTOMER_GROUP FROM AP_ANCHOR_INFO ORDER BY CUSTOMER_GROUP";
				conn.ExecuteQuery();
			}
			else
			{
				//conn.QueryString = "SELECT CIF#, CUSTOMER_GROUP FROM AP_ANCHOR_INFO WHERE BUC = '" + DDL_UNIT.SelectedValue + "'";
				conn.QueryString = "SELECT DISTINCT CIF#, CUSTOMER_GROUP FROM AP_ANCHOR_INFO WHERE BUC = '" + DDL_UNIT.SelectedValue + "' ORDER BY CUSTOMER_GROUP";
				conn.ExecuteQuery();
			}
			
			for(int i=0; i < conn.GetRowCount(); i++)
			{
				DDL_ANCHOR.Items.Add(new ListItem(conn.GetFieldValue(i,1), conn.GetFieldValue(i,0)));
			}
		}*/

		private void BindData(string dataGridName, string strconn)
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
			this.DATA_GRID.ItemCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.DATA_GRID_ItemCommand);
			this.DATA_GRID.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.DATA_GRID_PageIndexChanged);

		}
		#endregion

		protected void DDL_SEGMENT_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			FillDDLUnit();
			//FillDDLUpliner();
			//FillDDLAnchor();
		}

		protected void DDL_UNIT_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			//FillDDLUpliner();
			//FillDDLAnchor();
		}

		protected void BTN_Find_Click(object sender, System.EventArgs e)
		{
			DATA_GRID.CurrentPageIndex = 0;
			SearchData();
		}

		private void SearchData()
		{
			string query = "";

			if(DDL_SEGMENT.SelectedValue != "")
			{
				query += "AND BUSSUNITID = '" + DDL_SEGMENT.SelectedValue + "' ";
			}
			if(DDL_UNIT.SelectedValue != "")
			{
				query += "AND BUC = '" + DDL_UNIT.SelectedValue + "' ";
			}
			if(TXT_RM_NAME.Text != "")
			{
				query += "AND RM_NAME LIKE '%" + TXT_RM_NAME.Text + "%' ";
			}

			if(TXT_ANCHOR.Text != "")
			{
				query += "AND CUSTOMER_GROUP LIKE '%" + TXT_ANCHOR.Text +"%' ";
			}

			if(Request.QueryString["mc"] == "AP05")			//wallet share & target
			{
				if(query != "")
				{
					conn.QueryString = "SELECT DISTINCT * FROM VW_AP_CUSTOMER_LIST_TEMP WHERE 1=1 " + query;
					BindData(DATA_GRID.ID.ToString(), conn.QueryString);
				}

				else
				{
					conn.QueryString = "SELECT DISTINCT * FROM VW_AP_CUSTOMER_LIST_TEMP";
					BindData(DATA_GRID.ID.ToString(), conn.QueryString);
				}
			}
			
			else if(Request.QueryString["mc"] == "AP06")			//action plan
			{
				if(query != "")
				{
					conn.QueryString = "SELECT DISTINCT CIF#,BUSSUNITID,BUSSUNITDESC,BUC,BRANCH_NAME,RM_NAME,CUSTOMER_GROUP FROM VW_AP_CUSTOMER_LIST2 WHERE 1=1 " + query;
					BindData(DATA_GRID.ID.ToString(), conn.QueryString);
				}

				else
				{
					conn.QueryString = "SELECT DISTINCT CIF#,BUSSUNITID,BUSSUNITDESC,BUC,BRANCH_NAME,RM_NAME,CUSTOMER_GROUP FROM VW_AP_CUSTOMER_LIST2";
					BindData(DATA_GRID.ID.ToString(), conn.QueryString);
				}
			}

			else
			{
				if(query != "")
				{
					conn.QueryString = "SELECT DISTINCT CIF#,BUSSUNITID,BUSSUNITDESC,BUC,BRANCH_NAME,RM_NAME,CUSTOMER_GROUP FROM VW_AP_CUSTOMER_LIST WHERE 1=1 " + query;
					BindData(DATA_GRID.ID.ToString(), conn.QueryString);
				}

				else
				{
					conn.QueryString = "SELECT DISTINCT CIF#,BUSSUNITID,BUSSUNITDESC,BUC,BRANCH_NAME,RM_NAME,CUSTOMER_GROUP FROM VW_AP_CUSTOMER_LIST";
					BindData(DATA_GRID.ID.ToString(), conn.QueryString);
				}
			}
		}

		private void DATA_GRID_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			DATA_GRID.CurrentPageIndex = e.NewPageIndex;
			SearchData();
		}

		private void DATA_GRID_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			switch(((LinkButton)e.CommandSource).CommandName)
			{
				case "continue":
					if(Request.QueryString["mc"] == "AP04")			//opportunity & indentification
					{
						Response.Redirect("OportunityIndentification/ClientStrategyOpportunity.aspx?mc=" + Request.QueryString["mc"] +
							"&cif=" + e.Item.Cells[0].Text.Trim() + "&bs=" + e.Item.Cells[1].Text.Trim() + "&bc=" + e.Item.Cells[3].Text.Trim() +
							"&rd=" + e.Item.Cells[5].Text.Trim() + "&cd=" + e.Item.Cells[7].Text.Trim());
					}
					else if(Request.QueryString["mc"] == "AP05")	//wallet share & target
					{
						//calculate
						/*
						 * Cek ke tabel upload
						 * Klo g ada langsung hit ke benchmark
						 * 
						 * */
						string cu_cif = e.Item.Cells[0].Text.Trim();
						//calculate(cu_cif);

						Response.Redirect("WalletShareTarget/WalletMain.aspx?mc=" + Request.QueryString["mc"] +
							"&cif=" + e.Item.Cells[0].Text.Trim() + "&bs=" + e.Item.Cells[1].Text.Trim() + "&bc=" + e.Item.Cells[3].Text.Trim() +
							"&rd=" + e.Item.Cells[5].Text.Trim() + "&cd=" + e.Item.Cells[7].Text.Trim());
					}
					else if(Request.QueryString["mc"] == "AP06")	//action plan
					{
						Response.Redirect("ActionPlan/ActionPlanMain.aspx?mc=" + Request.QueryString["mc"] +
							"&cif=" + e.Item.Cells[0].Text.Trim() + "&bs=" + e.Item.Cells[1].Text.Trim() + "&bc=" + e.Item.Cells[3].Text.Trim() +
							"&rd=" + e.Item.Cells[5].Text.Trim() + "&cd=" + e.Item.Cells[7].Text.Trim());
					}
					/*else if(Request.QueryString["mc"] == "AP08")	//account planning setup
					{
						Response.Redirect("AccountPlanSetup/Main.aspx?mc=" + Request.QueryString["mc"] +
							"&cif=" + e.Item.Cells[0].Text.Trim() + "&bs=" + e.Item.Cells[1].Text.Trim() + "&bc=" + e.Item.Cells[3].Text.Trim() +
							"&rd=" + e.Item.Cells[5].Text.Trim() + "&cd=" + e.Item.Cells[7].Text.Trim());
					}*/
					break;
			}
		}

		private void calculate(string cu_cif)
		{
			conn.QueryString = "SELECT * FROM AP_WALLET_SIZE_RESULT WHERE CU_CIF = '" + cu_cif + "'";
			conn.ExecuteQuery();

			string status = "";
			if(conn.GetRowCount() == 0)
			{
				status = "INSERT";
			}
			else
			{
				status = "UPDATE";
			}

			/*
			 *	ID_AP_WALLET_SIZE_RESULT
				ID_AP_WALLET_SIZE_CATEGORY_TO_AP_MODEL
				CU_CIF
				CURRENT_INCOME
				POTENTIAL_INCOME
				CURRENT_VOLUME
				POTENTIAL_VOLUME
			 * */

			string CURRENT_INCOME = "";
			string POTENTIAL_INCOME = "";
			string CURRENT_VOLUME = "";
			string POTENTIAL_VOLUME = "";

			/*
			 *	ID_AP_WALLET_SIZE_CATEGORY
				ID_AP_VARIABLE
				ID_AP_WALLET_SIZE_CATEGORY_TO_AP_MODEL
				ID_AP_WHOLESALE_ALLIANCE_CATEGORY
				ID_AP_BENCHMARK
			 *
			 * */

			string ID_AP_WHOLESALE_ALLIANCE_CATEGORY = "";
			string ID_AP_WALLET_SIZE_CATEGORY = "";
			string ID_AP_VARIABLE = "";
			string ID_AP_WALLET_SIZE_CATEGORY_TO_AP_MODEL = ""; 
			string ID_AP_BENCHMARK = "";

			string QUERY = "";
			string CI_COLUMN = "";
			string CV_COLUMN = "";
			string PI_COLUMN = "";
			string PV_COLUMN = "";
			string COLTYPE = "";
			string BENCHMARK_VALUE = "";

			conn.QueryString = "SELECT ID_AP_WHOLESALE_ALLIANCE_CATEGORY FROM AP_WHOLESALE_ALLIANCE_CATEGORY";
			conn.ExecuteQuery();

			for(int z = 0; z<conn.GetRowCount(); z++)
			{
				ID_AP_WHOLESALE_ALLIANCE_CATEGORY = conn.GetFieldValue(z, "ID_AP_WHOLESALE_ALLIANCE_CATEGORY");

				conn2.QueryString = "SELECT ID_AP_WALLET_SIZE_CATEGORY FROM AP_WALLET_SIZE_CATEGORY";
				conn2.ExecuteQuery();

				for(int i = 0; i<conn2.GetRowCount(); i++)
				{
					ID_AP_WALLET_SIZE_CATEGORY = conn2.GetFieldValue(i, "ID_AP_WALLET_SIZE_CATEGORY");

					conn3.QueryString = "SELECT ID_AP_VARIABLE FROM AP_VARIABLE";
					conn3.ExecuteQuery();

					for(int j = 0; j<conn3.GetRowCount(); j++)
					{
						ID_AP_VARIABLE = conn3.GetFieldValue(j, "ID_AP_VARIABLE");

						conn4.QueryString = "SELECT ID_AP_WALLET_SIZE_CATEGORY_TO_AP_MODEL, ID_AP_BENCHMARK FROM " +
							"AP_WALLET_SIZE_CATEGORY_TO_AP_MODEL WHERE " +
							"ID_AP_WHOLESALE_ALLIANCE_CATEGORY = '" + ID_AP_WHOLESALE_ALLIANCE_CATEGORY + "' AND " +
							"ID_AP_VARIABLE = '" + ID_AP_VARIABLE + "' AND " +
							"ID_AP_WALLET_SIZE_CATEGORY = '" + ID_AP_WALLET_SIZE_CATEGORY + "'";
						conn4.ExecuteQuery();

						for(int k = 0; k<conn4.GetRowCount(); k++)
						{
							ID_AP_WALLET_SIZE_CATEGORY_TO_AP_MODEL = conn4.GetFieldValue(k, "ID_AP_WALLET_SIZE_CATEGORY_TO_AP_MODEL");
							ID_AP_BENCHMARK = conn4.GetFieldValue(k, "ID_AP_BENCHMARK");
							
							conn5.QueryString = "SELECT QUERY, CI_COLUMN, PI_COLUMN, CV_COLUMN, PV_COLUMN, COLTYPE FROM AP_VARIABLE WHERE ID_AP_VARIABLE = '" + ID_AP_VARIABLE + "'";
							conn5.ExecuteQuery();

							if(conn5.GetFieldValue("QUERY") == "" || conn5.GetFieldValue("QUERY") == null)
							{
								continue;
							}

							QUERY = conn5.GetFieldValue("QUERY");
							COLTYPE = conn5.GetFieldValue("COLTYPE");
							CI_COLUMN = conn5.GetFieldValue("CI_COLUMN");
							CV_COLUMN = conn5.GetFieldValue("CV_COLUMN");
							PI_COLUMN = conn5.GetFieldValue("PI_COLUMN");
							PV_COLUMN = conn5.GetFieldValue("PV_COLUMN");

							conn5.QueryString = "SELECT [VALUES] FROM AP_BENCHMARK WHERE ID_AP_BENCHMARK = '" + ID_AP_BENCHMARK + "'";
							conn5.ExecuteQuery();
							BENCHMARK_VALUE = conn5.GetFieldValue("VALUES").ToString();

							//dari sini lakukan calculate
							CURRENT_INCOME = "";
							if(COLTYPE == "PROCEDURE")
							{
								conn5.QueryString = "EXEC " + QUERY + " '" + cu_cif + "'";
								conn5.ExecuteQuery();
							}

							else if(COLTYPE == "TABLE")
							{	
								conn5.QueryString = "SELECT * FROM " + QUERY + " WHERE CU_CIF = '" + cu_cif + "'";
								conn5.ExecuteQuery();
							}

							CURRENT_INCOME = conn5.GetFieldValue(CI_COLUMN).ToString();
			
							if(CURRENT_INCOME == "" || CURRENT_INCOME == null)
							{
								CURRENT_INCOME = "0.0";
							}

							POTENTIAL_VOLUME = conn5.GetFieldValue(PV_COLUMN).ToString();

							if(POTENTIAL_VOLUME == "" || POTENTIAL_VOLUME == null)
							{
								POTENTIAL_VOLUME = ((double)(MyConnection.ConvertToDouble2(CURRENT_INCOME) * MyConnection.ConvertToDouble2(BENCHMARK_VALUE))).ToString();
							}

							POTENTIAL_INCOME = conn5.GetFieldValue(PI_COLUMN).ToString();

							if(POTENTIAL_INCOME == "" || POTENTIAL_INCOME == null)
							{
								POTENTIAL_INCOME = ((double)(MyConnection.ConvertToDouble2(POTENTIAL_VOLUME) * MyConnection.ConvertToDouble2(BENCHMARK_VALUE))).ToString();
							}

							CURRENT_VOLUME = conn5.GetFieldValue(CV_COLUMN).ToString();

							if(CURRENT_VOLUME == "" || CURRENT_VOLUME == null)
							{
								CURRENT_VOLUME = "0.0";
							}

							//done wallet size result
							conn5.QueryString = "SELECT * FROM AP_WALLET_SIZE_RESULT WHERE ID_AP_WALLET_SIZE_CATEGORY_TO_AP_MODEL = '" + ID_AP_WALLET_SIZE_CATEGORY_TO_AP_MODEL + "' AND " +
								"CU_CIF = '" + cu_cif + "'";
							conn5.ExecuteQuery();

							if(conn5.GetRowCount() == 0)
							{
								conn5.QueryString = "INSERT INTO AP_WALLET_SIZE_RESULT " +
									"(ID_AP_WALLET_SIZE_CATEGORY_TO_AP_MODEL," +
									"CU_CIF," +
									"CURRENT_INCOME," +
									"POTENTIAL_INCOME," +
									"CURRENT_VOLUME," +
									"POTENTIAL_VOLUME) " +
									"VALUES (" + 
									ID_AP_WALLET_SIZE_CATEGORY_TO_AP_MODEL + ",'" +
									cu_cif + "','" +
									CURRENT_INCOME + "','" +
									POTENTIAL_INCOME + "','" +
									CURRENT_VOLUME + "','" +
									POTENTIAL_VOLUME + "')";
								conn5.ExecuteQuery();
							}
							else
							{
								conn5.QueryString = "UPDATE AP_WALLET_SIZE_RESULT " +
									"SET CURRENT_INCOME = '" + CURRENT_INCOME + "'," +
									"POTENTIAL_INCOME = '" + POTENTIAL_INCOME + "'," +
									"CURRENT_VOLUME = '" + CURRENT_VOLUME + "'," +
									"POTENTIAL_VOLUME = '" + POTENTIAL_VOLUME + "' " +
									"WHERE ID_AP_WALLET_SIZE_CATEGORY_TO_AP_MODEL = " +  ID_AP_WALLET_SIZE_CATEGORY_TO_AP_MODEL + " AND " +
									"CU_CIF = '" + cu_cif + "'";
								conn5.ExecuteQuery();
							}
						}
					}
				}
			}
		}

		private void calculateBackup(string cu_cif)
		{
			conn.QueryString = "SELECT * FROM AP_WALLET_SIZE_RESULT WHERE CU_CIF = '" + cu_cif + "'";
			conn.ExecuteQuery();

			string status = "";
			if(conn.GetRowCount() == 0)
			{
				status = "INSERT";
			}
			else
			{
				status = "UPDATE";
			}

			string ID_AP_WALLET_SIZE_CATEGORY_TO_AP_MODEL = ""; 
			string GROUP = ""; //wholesale
			string CATEGORY = ""; //wholesale lending
			string VARIABLE = ""; // investment loan
			string NILAIUPLOAD = "";
			string PARAMETERVALUE = "";
			string RESULT = "";

			//insert value satu satu based on category ke wallet size result
			conn.QueryString = "SELECT ID_AP_WALLET_SIZE_CATEGORY FROM AP_WALLET_SIZE_CATEGORY";
			conn.ExecuteQuery();

			for(int i = 0; i<conn.GetRowCount(); i++)
			{
				CATEGORY = conn.GetFieldValue(i, "ID_AP_WALLET_SIZE_CATEGORY");

				conn2.QueryString = "SELECT ID_AP_VARIABLE, ID_AP_WALLET_SIZE_CATEGORY_TO_AP_MODEL  FROM AP_WALLET_SIZE_CATEGORY_TO_AP_MODEL WHERE ID_AP_WALLET_SIZE_CATEGORY = '" + CATEGORY + "'";
				conn2.ExecuteQuery();

				ID_AP_WALLET_SIZE_CATEGORY_TO_AP_MODEL = conn2.GetFieldValue("ID_AP_WALLET_SIZE_CATEGORY_TO_AP_MODEL");
				VARIABLE = conn2.GetFieldValue("ID_AP_VARIABLE");

				//dapetin semua variable
				string IDBENCHMARK = "";
				string IDRELATIONTOTABLEUPLOAD = "";

				for(int k = 0; k<conn2.GetRowCount(); k++)
				{
					#region INSERT EACH RESULT PERCATEGORY

					conn3.QueryString = "SELECT * FROM AP_VARIABLE WHERE ID_AP_VARIABLE = '" + VARIABLE + "'";
					conn3.ExecuteQuery();

					VARIABLE = conn3.GetFieldValue("ID_AP_VARIABLE");
					IDBENCHMARK = conn3.GetFieldValue("ID_AP_BENCHMARK");
					IDRELATIONTOTABLEUPLOAD = conn3.GetFieldValue("ID_AP_UPLOADED_DATA");
					double RESULTDOUBLE = 1.0;

					//masing masing variable punya formula sendiri lo

					conn3.QueryString = "SELECT * FROM AP_ITEM WHERE ID_AP_VARIABLE = '" + VARIABLE + "'";
					conn3.ExecuteQuery();

					//hitung dari sini, dilooping dikalikan
					#region INSERT EACH RESULT PERITEM
					for(int l = 0; l<conn3.GetRowCount(); l++)
					{
						//1.Ambil variable dari hasil upload
						/********************* ambil nilai upload ***********************/
						string QUERY = "";
						string QUERYFIELD = "";
						string ISRANGE = "";
						string ID_AP_ITEM = "";
						string NERACAVALUE = "";
						
						QUERY = conn3.GetFieldValue(l,"QUERY");
						QUERYFIELD = conn3.GetFieldValue(l,"FIELD");
						ISRANGE = conn3.GetFieldValue(l,"ISRANGE");
						ID_AP_ITEM = conn3.GetFieldValue(l,"ID_AP_ITEM");

						string TABLE = "";
						string FIELD = "";

						conn4.QueryString = "SELECT TABLE, FIELD FROM AP_UPLOADED_DATA WHERE ID_AP_UPLOADED_DATA = '" + IDRELATIONTOTABLEUPLOAD + "'";
						conn4.ExecuteQuery();

						TABLE  = conn4.GetFieldValue("TABLE");
						FIELD = conn4.GetFieldValue("FIELD");

						conn4.QueryString = "SELECT " + TABLE + " FROM " + FIELD + " WHERE CU_CIF = '" + cu_cif + "'";
						conn4.ExecuteQuery();

						try
						{
							/***************** SET-UP NILAI UPLOAD ******************/
							/*****/ NILAIUPLOAD = conn3.GetFieldValue(TABLE); /******/
							/********************************************************/
						}
						catch
						{
							/***************** SET-UP NILAI UPLOAD ******************/
							/*****************/ NILAIUPLOAD = ""; /******************/
							/********************************************************/
						}
						/***************************************************************/
						//kalau di upload g ada, langsung ambil dari benchmark
						if(NILAIUPLOAD == "")
						{
							//ambil dari benchmark
							conn4.QueryString = "SELECT VALUES FROM AP_BENCHMARK WHERE ID_AP_BENCHMARK = '" + IDBENCHMARK + "'";
							/***************** SET-UP NILAI BENCHMARK ******************/
							/*****/ NILAIUPLOAD = conn4.GetFieldValue("VALUES"); /******/
							/***********************************************************/
						}

						//2.Nilai Upload / Benchmark uda didapat sekarang ambil nilai di laporan keuangan
						/********************* ambil dari neraca keuangan ***********************/
						conn4.QueryString = "EXEC " + QUERY + " '" + cu_cif + "'";
						conn4.ExecuteQuery();

						/***************** SET-UP NILAI DARI NERACA ********************/ 
						try
						{
							NERACAVALUE = conn4.GetFieldValue(QUERYFIELD); 
						}
						catch
						{
							NERACAVALUE = "";
						}
						/***************************************************************/

						//3.Nilai dari neraca bandingin ama parameter
						if(NERACAVALUE != "")
						{
							/********************* ambil nilai dari parameter **********************/
							if(ISRANGE == "0")
							{
								conn4.QueryString = "SELECT SCORE, VALUES FROM AP_ITEM_NON_RANGE WHERE ID_AP_ITEM = '" + ID_AP_ITEM + "'";
								conn4.ExecuteQuery();

								//dapat value, dicompare ama NERACA VALUE

								for(int m = 0; m<conn4.GetRowCount(); m++)
								{
									if(decimal.Parse(conn4.GetFieldValue(m, "SCORE")) == decimal.Parse(NERACAVALUE))
									{
										/***************** SET-UP NILAI DARI PARAMETER ********************/
										/******/ PARAMETERVALUE = conn4.GetFieldValue(m, "VALUES"); /******/
										/******************************************************************/
										break;
									}
								}
							}
							else if(ISRANGE == "1")
							{
								conn4.QueryString = "SELECT LOWEST, HIGHEST, VALUES FROM AP_ITEM_RANGE WHERE ID_AP_ITEM = '" + VARIABLE + "'";
								conn4.ExecuteQuery();

								for(int m = 0; m<conn4.GetRowCount(); m++)
								{
									if(conn4.GetFieldValue(m, "LOWEST") == "LOWEST")
									{
										if(decimal.Parse(NERACAVALUE) <= decimal.Parse(conn4.GetFieldValue(m, "HIGHEST")))
										{
											/***************** SET-UP NILAI DARI PARAMETER ********************/
											/******/ PARAMETERVALUE = conn4.GetFieldValue(m, "VALUES"); /******/
											/******************************************************************/
											break;
										}
									}
									else if(conn4.GetFieldValue(m, "HIGHEST") == "HIGHEST")
									{
										if(decimal.Parse(NERACAVALUE) >= decimal.Parse(conn4.GetFieldValue(m, "HIGHEST")))
										{
											/***************** SET-UP NILAI DARI PARAMETER ********************/
											/******/ PARAMETERVALUE = conn4.GetFieldValue(m, "VALUES"); /******/
											/******************************************************************/
											break;
										}
									}
									else
									{
										if((decimal.Parse(NERACAVALUE) >= decimal.Parse(conn4.GetFieldValue(m, "LOWEST")))
											&& (decimal.Parse(NERACAVALUE) <= decimal.Parse(conn4.GetFieldValue(m, "HIGHEST"))))
										{
											/***************** SET-UP NILAI DARI PARAMETER ********************/
											/******/ PARAMETERVALUE = conn4.GetFieldValue(m, "VALUES"); /******/
											/******************************************************************/
											break;
										}
									}
								}
							}
						}
						else
						{
							//ambil dari benchmark
							conn4.QueryString = "SELECT VALUES FROM AP_BENCHMARK WHERE ID_AP_BENCHMARK = '" + IDBENCHMARK + "'";
							conn4.ExecuteQuery();
							/***************** SET-UP NILAI BENCHMARK ******************/
							/*****/ PARAMETERVALUE = conn4.GetFieldValue("VALUES"); /******/
							/***********************************************************/
						}
						//4.Nilai dari hasil mapping parameter dioperasikan dengan hasil upload sesuai dengan jenis operator
						double DoubleResult = 0.0d;
						string OPERATOR = "";

						try
						{
							OPERATOR = conn3.GetFieldValue(l,"OPERATOR");
						}
						catch
						{
							OPERATOR = "";
						}

						if(OPERATOR == "*")
						{
							DoubleResult = MyConnection.ConvertToDouble(NERACAVALUE) * MyConnection.ConvertToDouble(PARAMETERVALUE);
						}
						else if(OPERATOR == ":")
						{
							DoubleResult = MyConnection.ConvertToDouble(NERACAVALUE) / MyConnection.ConvertToDouble(PARAMETERVALUE);
						}
						else if(OPERATOR == "+")
						{
							DoubleResult = MyConnection.ConvertToDouble(NERACAVALUE) + MyConnection.ConvertToDouble(PARAMETERVALUE);
						}
						else if(OPERATOR == "-")
						{
							DoubleResult = MyConnection.ConvertToDouble(NERACAVALUE) - MyConnection.ConvertToDouble(PARAMETERVALUE);
						}

						//RESULT = DoubleResult.ToString();
						RESULTDOUBLE *= DoubleResult;
						string teswes = "";
						//dikalkulasi disini
						//Result double adalah hasil kalkulasi per category
						#endregion
					}
					RESULTDOUBLE = 1.0;
					ID_AP_WALLET_SIZE_CATEGORY_TO_AP_MODEL = conn2.GetFieldValue(k, "ID_AP_WALLET_SIZE_CATEGORY_TO_AP_MODEL");

					string CURRENT_INCOME = "";
					string POTENTIAL_INCOME = "";
					string CURRENT_VOLUME = "";
					string POTENTIAL_VOLUME = "";

					if(status == "INSERT")
					{
						conn3.QueryString = "INSERT INTO AP_WALLET_SIZE_RESULT (ID_AP_WALLET_SIZE_CATEGORY_TO_AP_MODEL, " + 
							"CU_CIF, " +
							"GROUP, " + 
							"CURRENT_INCOME, " +
							"POTENTIAL_INCOME, " + 
							"CURRENT_VOLUME, " +
							"POTENTIAL_VOLUME) VALUES (" + 
							ID_AP_WALLET_SIZE_CATEGORY_TO_AP_MODEL + ",'" +
							cu_cif + "','" +
							"" + "','" +   
							CURRENT_INCOME + "','" +
							POTENTIAL_INCOME + "','" +
							CURRENT_VOLUME + "','" +
							POTENTIAL_VOLUME + "')";
						conn3.ExecuteQuery();
					}

					#endregion
				}
			}
		}

		protected void BTN_New_Click(object sender, System.EventArgs e) //Action Plan
		{
			if(TXT_ANCHOR.Text == "")
			{
				GlobalTools.popMessage(this, "Pilih Anchor Name!");
				return;
			}
			else
			{
				try
				{
					Response.Redirect("ActionPlan/ActionPlanMain.aspx?mc=" + Request.QueryString["mc"] + "&cif=" + TXT_ANCHOR.Text);
						//"&cif=" + e.Item.Cells[0].Text.Trim() + "&bs=" + e.Item.Cells[1].Text.Trim() + "&bc=" + e.Item.Cells[3].Text.Trim() +
						//"&rd=" + e.Item.Cells[5].Text.Trim() + "&cd=" + e.Item.Cells[7].Text.Trim());
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
		}
	}
}
