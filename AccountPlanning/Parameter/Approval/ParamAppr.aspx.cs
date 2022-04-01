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
using System.Configuration;

namespace SME.AccountPlanning.Parameter.Approval
{
	/// <summary>
	/// Summary description for ParamAppr.
	/// </summary>
	public partial class ParamAppr : System.Web.UI.Page
	{


		
		protected Tools tools = new Tools();
		protected Connection conn = new Connection(ConfigurationSettings.AppSettings["conn"]);

		protected void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			if(!IsPostBack)
			{
				TR_BENCHMARK.Visible		= false;
				TR_VARIABLE.Visible			= false;
				TR_MODEL.Visible			= false;
				TR_PRODUCT_MASTER.Visible	= false;
				TR_PRODUCT_ITEM.Visible		= false;
				TR_OTHERS.Visible			= false;
				TR_ATTRIBUTE.Visible		= false;
				TR_RANGE.Visible			= false;
				TR_NON_RANGE.Visible		= false;
				TR_INDUSTRY.Visible			= false;

				ViewData();
			}
		}

		private void ViewData()
		{
			//choose parameter type
			if(Request.QueryString["page"] == "01")		//Benchmark Parameter
			{
				LBL_PARAM.Text = "BENCHMARK PARAMETER - APPROVAL";
				TR_BENCHMARK.Visible = true;
				//conn.QueryString = "SELECT * FROM AP_RF_BENCHMARK WHERE BM_STATUS='2' ORDER BY SEQ ASC";
				conn.QueryString = "SELECT * FROM AP_BENCHMARK WHERE BM_STATUS='2' ORDER BY ID_AP_BENCHMARK ASC";
				BindData(DGR_BENCHMARK_REQ.ID.ToString(), conn.QueryString);
			}

			else if(Request.QueryString["page"] == "02")		//Variable Parameter
			{
				LBL_PARAM.Text = "VARIABLE PARAMETER - APPROVAL";
				TR_VARIABLE.Visible = true;
				conn.QueryString = "SELECT * FROM AP_RF_VARIABLE WHERE STATUS='2' ORDER BY SEQ ASC";				
				BindData(DGR_VARIABLE_REQ.ID.ToString(), conn.QueryString);
			}

			else if(Request.QueryString["page"] == "03")		//Model Parameter
			{
				LBL_PARAM.Text = "MODEL PARAMETER - APPROVAL";
				TR_MODEL.Visible = true;
				conn.QueryString = "SELECT * FROM AP_RF_MODEL WHERE STATUS='2' ORDER BY SEQ ASC";
				BindData(DGR_MODEL_REQ.ID.ToString(), conn.QueryString);
			}

			else if(Request.QueryString["page"] == "04")		//Product Link Parameter
			{
				LBL_PARAM.Text = "PRODUCT LINK - APPROVAL";
				TR_PRODUCT_MASTER.Visible = true;
				conn.QueryString = "SELECT * FROM AP_VARIABLE WHERE STATUS='2'";
				BindData(DGR_PRODUCT_MASTER_REQ.ID.ToString(), conn.QueryString);
			}

			else if(Request.QueryString["page"] == "05")		//Product Parameter
			{
				LBL_PARAM.Text = "PRODUCT - APPROVAL";
				TR_PRODUCT_ITEM.Visible = true;
				conn.QueryString = "SELECT * FROM AP_RF_PRODUCT_ITEM WHERE STATUS='2' ORDER BY SEQ ASC";
				BindData(DGR_PRODUCT_ITEM_REQ.ID.ToString(), conn.QueryString);
			}

			else if(Request.QueryString["page"] == "06")		//Others Parameter
			{
				LBL_PARAM.Text = "OTHERS - APPROVAL";
				TR_OTHERS.Visible = true;
				conn.QueryString = "SELECT TOP 0 * FROM AP_RF_OTHERS WHERE STATUS='2' ORDER BY SEQ ASC";
				BindData(DGR_OTHERS_REQ.ID.ToString(), conn.QueryString);
				FillDDLType();
			}
			else if(Request.QueryString["page"] == "07")		//Attribute Parameter
			{
				LBL_PARAM.Text = "ATTRIBUTE - APPROVAL";
				TR_ATTRIBUTE.Visible = true;
				conn.QueryString = "EXEC AP_BINDTEMP 'ATTRIBUTE'";
				BindData(DGR_ATTRIBUTE_REQ.ID.ToString(), conn.QueryString);
			}
			
			else if(Request.QueryString["page"] == "08")		//Attribute Range Parameter
			{
				LBL_PARAM.Text = "ATTRIBUTE RANGE - APPROVAL";
				TR_RANGE.Visible = true;
				conn.QueryString = "EXEC AP_BINDTEMP 'RANGE'";
				BindData(DGR_RANGE_REQ.ID.ToString(), conn.QueryString);
			}
			
			else if(Request.QueryString["page"] == "09")		//Attribute Non Range Parameter
			{
				LBL_PARAM.Text = "ATTRIBUTE NON RANGE - APPROVAL";
				TR_NON_RANGE.Visible = true;
				conn.QueryString = "EXEC AP_BINDTEMP 'NONRANGE'";
				BindData(DGR_NON_RANGE_REQ.ID.ToString(), conn.QueryString);
			}

			else if(Request.QueryString["page"] == "10")		//Industry Parameter
			{
				LBL_PARAM.Text = "INDUSTRY - APPROVAL";
				TR_INDUSTRY.Visible = true;
				conn.QueryString = "SELECT CODE, CODE_DESCRIPTION, (CODE +'-'+ CODE_DESCRIPTION) as CODEGAB, BM_INDUSTRY_CODE, (BM_INDUSTRY_CODE +' - '+ PD_KSEBMDESC) AS BM_INDUSTRY_LINK, PENDINGSTATUS " +
					"FROM AP_RF_PENDING_INDUSTRY_BCG a LEFT JOIN PD_RF_KSEBM b on a.BM_INDUSTRY_CODE = b.PD_KSEBMCD WHERE a.ACTIVE = '1' ORDER BY CONVERT(INT,CODE)";
				
				BindData(DGR_INDUSTRY.ID.ToString(), conn.QueryString);
			}
		}

		private void BindData(string dataGridName, string strconn)
		{
			if(strconn != "")
			{
				conn.QueryString = strconn;
				conn.ExecuteQuery();
			}

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

		private void FillDDLType()
		{
			DDL_ACT_PLAN.Items.Clear();
			DDL_ACT_PLAN.Items.Add(new ListItem("--Select--", ""));

			conn.QueryString = "SELECT * FROM VW_AP_RF_OTHERS_TYPE";
			conn.ExecuteQuery();
			for(int i = 0; i < conn.GetRowCount(); i++)
			{
				DDL_ACT_PLAN.Items.Add(new ListItem(conn.GetFieldValue(i,1), conn.GetFieldValue(i,0)));
			}
		}

		protected void DDL_ACT_PLAN_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			conn.QueryString = "SELECT * FROM AP_RF_OTHERS WHERE STATUS='2' AND OTHERS_TYPEID ='" + DDL_ACT_PLAN.SelectedValue + "'";
			BindData(DGR_OTHERS_REQ.ID.ToString(), conn.QueryString);
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
			this.DGR_BENCHMARK_REQ.ItemCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.DGR_BENCHMARK_REQ_ItemCommand);
			this.DGR_BENCHMARK_REQ.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.DGR_BENCHMARK_REQ_PageIndexChanged);
			this.DGR_VARIABLE_REQ.ItemCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.DGR_BENCHMARK_REQ_ItemCommand);
			this.DGR_VARIABLE_REQ.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.DGR_BENCHMARK_REQ_PageIndexChanged);
			this.DGR_MODEL_REQ.ItemCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.DGR_BENCHMARK_REQ_ItemCommand);
			this.DGR_MODEL_REQ.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.DGR_BENCHMARK_REQ_PageIndexChanged);
			this.DGR_PRODUCT_MASTER_REQ.ItemCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.DGR_BENCHMARK_REQ_ItemCommand);
			this.DGR_PRODUCT_MASTER_REQ.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.DGR_BENCHMARK_REQ_PageIndexChanged);
			this.DGR_PRODUCT_ITEM_REQ.ItemCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.DGR_BENCHMARK_REQ_ItemCommand);
			this.DGR_PRODUCT_ITEM_REQ.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.DGR_BENCHMARK_REQ_PageIndexChanged);
			this.DGR_ATTRIBUTE_REQ.ItemCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.DGR_BENCHMARK_REQ_ItemCommand);
			this.DGR_ATTRIBUTE_REQ.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.DGR_BENCHMARK_REQ_PageIndexChanged);
			this.DGR_RANGE_REQ.ItemCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.DGR_BENCHMARK_REQ_ItemCommand);
			this.DGR_RANGE_REQ.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.DGR_BENCHMARK_REQ_PageIndexChanged);
			this.DGR_NON_RANGE_REQ.ItemCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.DGR_BENCHMARK_REQ_ItemCommand);
			this.DGR_NON_RANGE_REQ.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.DGR_BENCHMARK_REQ_PageIndexChanged);

		}
		#endregion

		private void DGR_BENCHMARK_REQ_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			if(((DataGrid)source).ID == "DGR_BENCHMARK_REQ")
			{
				DGR_BENCHMARK_REQ.CurrentPageIndex = e.NewPageIndex;
			}
			else if(((DataGrid)source).ID == "DGR_VARIABLE_REQ")
			{
				DGR_VARIABLE_REQ.CurrentPageIndex = e.NewPageIndex;
			}
			else if(((DataGrid)source).ID == "DGR_MODEL_REQ")
			{
				DGR_MODEL_REQ.CurrentPageIndex = e.NewPageIndex;
			}
			else if(((DataGrid)source).ID == "DGR_PRODUCT_MASTER_REQ")
			{
				DGR_PRODUCT_MASTER_REQ.CurrentPageIndex = e.NewPageIndex;
			}
			else if(((DataGrid)source).ID == "DGR_PRODUCT_ITEM_REQ")
			{
				DGR_PRODUCT_ITEM_REQ.CurrentPageIndex = e.NewPageIndex;
			}
			else if(((DataGrid)source).ID == "DGR_OTHERS_REQ")
			{
				DGR_OTHERS_REQ.CurrentPageIndex = e.NewPageIndex;
			}
			else if(((DataGrid)source).ID == "DGR_ATTRIBUTE_REQ")
			{
				DGR_ATTRIBUTE_REQ.CurrentPageIndex = e.NewPageIndex;
			}
			else if(((DataGrid)source).ID == "DGR_RANGE_REQ")
			{
				DGR_RANGE_REQ.CurrentPageIndex = e.NewPageIndex;
			}
			else if(((DataGrid)source).ID == "DGR_NON_RANGE_REQ")
			{
				DGR_NON_RANGE_REQ.CurrentPageIndex = e.NewPageIndex;
			}
			else if(((DataGrid)source).ID == "DGR_INDUSTRY")
			{
				DGR_INDUSTRY.CurrentPageIndex = e.NewPageIndex;
			}
			
			ViewData();
		}

		private void DGR_BENCHMARK_REQ_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			string rdo1 = "", rdo2 = "", rdo3 = "";

			if(((DataGrid)source).ID == "DGR_BENCHMARK_REQ")
			{
				rdo1 = "RDO_APPROVE1"; rdo2 = "RDO_PENDING1"; rdo3 = "RDO_REJECT1";
			}
			else if(((DataGrid)source).ID == "DGR_VARIABLE_REQ")
			{
				rdo1 = "RDO_APPROVE2"; rdo2 = "RDO_PENDING2"; rdo3 = "RDO_REJECT2";
			}
			else if(((DataGrid)source).ID == "DGR_MODEL_REQ")
			{
				rdo1 = "RDO_APPROVE3"; rdo2 = "RDO_PENDING3"; rdo3 = "RDO_REJECT3";
			}
			else if(((DataGrid)source).ID == "DGR_PRODUCT_MASTER_REQ")
			{
				rdo1 = "RDO_APPROVE4"; rdo2 = "RDO_PENDING4"; rdo3 = "RDO_REJECT4";
			}
			else if(((DataGrid)source).ID == "DGR_PRODUCT_ITEM_REQ")
			{
				rdo1 = "RDO_APPROVE5"; rdo2 = "RDO_PENDING5"; rdo3 = "RDO_REJECT5";
			}
			else if(((DataGrid)source).ID == "DGR_OTHERS_REQ")
			{
				rdo1 = "RDO_APPROVE6"; rdo2 = "RDO_PENDING6"; rdo3 = "RDO_REJECT6";
			}
			else if(((DataGrid)source).ID == "DGR_ATTRIBUTE_REQ")
			{
				rdo1 = "RDO_APPROVE7"; rdo2 = "RDO_PENDING7"; rdo3 = "RDO_REJECT7";
			}
			else if(((DataGrid)source).ID == "DGR_RANGE_REQ")
			{
				rdo1 = "RDO_APPROVE8"; rdo2 = "RDO_PENDING8"; rdo3 = "RDO_REJECT8";
			}
			else if(((DataGrid)source).ID == "DGR_NON_RANGE_REQ")
			{
				rdo1 = "RDO_APPROVE9"; rdo2 = "RDO_PENDING9"; rdo3 = "RDO_REJECT9";
			}

			else if(((DataGrid)source).ID == "DGR_INDUSTRY")
			{
				rdo1 = "RDO_APPROVE10"; rdo2 = "RDO_PENDING10"; rdo3 = "RDO_REJECT10";
			}

			DataGrid dataGridName = (DataGrid)source;

			switch(((LinkButton)e.CommandSource).CommandName)
			{
				case "allAccept":
					for (int i = 0; i < dataGridName.PageSize; i++)
					{
						try
						{
							RadioButton rbA = (RadioButton) dataGridName.Items[i].FindControl(rdo1),
										rbP = (RadioButton) dataGridName.Items[i].FindControl(rdo2),
										rbR = (RadioButton) dataGridName.Items[i].FindControl(rdo3);
							rbA.Checked = true;
							rbP.Checked = false;
							rbR.Checked = false;
						} 
						catch {}
					}
					break;
				case "allPend":
					for (int i = 0; i < dataGridName.PageSize; i++)
					{
						try
						{
							RadioButton rbA = (RadioButton) dataGridName.Items[i].FindControl(rdo1),
										rbP = (RadioButton) dataGridName.Items[i].FindControl(rdo2),
										rbR = (RadioButton) dataGridName.Items[i].FindControl(rdo3);
							rbA.Checked = false;
							rbP.Checked = true;
							rbR.Checked = false;
						} 
						catch {}
					}
					break;
				case "allReject":
					for (int i = 0; i < dataGridName.PageSize; i++)
					{
						try
						{
							RadioButton rbA = (RadioButton) dataGridName.Items[i].FindControl(rdo1),
										rbP = (RadioButton) dataGridName.Items[i].FindControl(rdo2),
										rbR = (RadioButton) dataGridName.Items[i].FindControl(rdo3);
							rbA.Checked = false;
							rbP.Checked = false;
							rbR.Checked = true;
						} 
						catch {}
					}
					break;
				default:
					break;
			}
		}

		protected void BTN_SUB_Click(object sender, System.EventArgs e)
		{
			string gridname = "", rdo1 = "", rdo2 = "";

			if(Request.QueryString["page"] == "01")		// Benchmark Parameter
			{
				gridname = "DGR_BENCHMARK_REQ";
				rdo1 = "RDO_APPROVE1"; rdo2 = "RDO_REJECT1";
			}
			else if(Request.QueryString["page"] == "02")	// Variable Parameter
			{
				gridname = "DGR_VARIABLE_REQ";
				rdo1 = "RDO_APPROVE2"; rdo2 = "RDO_REJECT2";
			}
			else if(Request.QueryString["page"] == "03")	// Model Parameter
			{
				gridname = "DGR_MODEL_REQ";
				rdo1 = "RDO_APPROVE3"; rdo2 = "RDO_REJECT3";
			}
			else if(Request.QueryString["page"] == "04")	// Product Master Parameter
			{
				gridname = "DGR_PRODUCT_MASTER_REQ";
				rdo1 = "RDO_APPROVE4"; rdo2 = "RDO_REJECT4";
			}
			else if(Request.QueryString["page"] == "05")	// Product Item Parameter
			{
				gridname = "DGR_PRODUCT_ITEM_REQ";
				rdo1 = "RDO_APPROVE5"; rdo2 = "RDO_REJECT5";
			}
			else if(Request.QueryString["page"] == "06")	// Others Parameter
			{
				gridname = "DGR_OTHERS_REQ";
				rdo1 = "RDO_APPROVE6"; rdo2 = "RDO_REJECT6";
			}
			else if(Request.QueryString["page"] == "07")	// Attribute Parameter
			{
				gridname = "DGR_ATTRIBUTE_REQ";
				rdo1 = "RDO_APPROVE7"; rdo2 = "RDO_REJECT7";
			}
			else if(Request.QueryString["page"] == "08")	// Attribute Range Parameter
			{
				gridname = "DGR_RANGE_REQ";
				rdo1 = "RDO_APPROVE8"; rdo2 = "RDO_REJECT8";
			}
			else if(Request.QueryString["page"] == "09")	// Attribute Non Range Parameter
			{
				gridname = "DGR_NON_RANGE_REQ";
				rdo1 = "RDO_APPROVE9"; rdo2 = "RDO_REJECT9";
			}

			else if(Request.QueryString["page"] == "10")	// Industry Parameter
			{
				gridname = "DGR_INDUSTRY";
				rdo1 = "RDO_APPROVE10"; rdo2 = "RDO_REJECT10";
			}

			DataGrid dataGridName =  (System.Web.UI.WebControls.DataGrid)Page.FindControl(gridname);

			for (int i = 0; i < dataGridName.Items.Count; i++)
			{
				try	
				{
					RadioButton rbA = (RadioButton) dataGridName.Items[i].FindControl(rdo1),
								rbR = (RadioButton) dataGridName.Items[i].FindControl(rdo2);
					if (rbA.Checked)
					{
						performRequest(i, dataGridName);
					}
					else if (rbR.Checked)
					{
						deleteData(i, dataGridName);
					}
				} 
				catch {}
			}

			ViewData();
		}

		private void performRequest(int row, DataGrid dataGridName)
		{
			try 
			{
				if(Request.QueryString["page"] == "01")		// Benchmark Parameter
				{
					string seq = dataGridName.Items[row].Cells[0].Text.Trim();
					//conn.QueryString = "UPDATE AP_RF_BENCHMARK SET BM_STATUS='1', BM_REQUEST='Active' WHERE SEQ='" + seq + "'";
					conn.QueryString = "UPDATE AP_BENCHMARK SET BM_STATUS='1', BM_REQUEST='Active' WHERE ID_AP_BENCHMARK='" + seq + "'";
					conn.ExecuteNonQuery();
				}
				else if(Request.QueryString["page"] == "02")	// Variable Parameter
				{
					string seq = dataGridName.Items[row].Cells[0].Text.Trim();
					conn.QueryString = "UPDATE AP_RF_VARIABLE SET STATUS='1', REQUEST='Active' WHERE SEQ='" + seq + "'";					
					conn.ExecuteNonQuery();
				}
				else if(Request.QueryString["page"] == "03")	// Model Parameter
				{
					string seq = dataGridName.Items[row].Cells[0].Text.Trim();
					conn.QueryString = "UPDATE AP_RF_MODEL SET STATUS='1', REQUEST='Active' WHERE SEQ='" + seq + "'";
					conn.ExecuteNonQuery();
				}
				else if(Request.QueryString["page"] == "04")	// Product Master Parameter
				{
					string seq = dataGridName.Items[row].Cells[0].Text.Trim();
					conn.QueryString = "UPDATE AP_VARIABLE SET STATUS='1', REQUEST='Active' WHERE ID_AP_VARIABLE='" + seq + "'";
					conn.ExecuteNonQuery();
				}
				else if(Request.QueryString["page"] == "05")	// Product Item Parameter
				{
					string seq = dataGridName.Items[row].Cells[0].Text.Trim();
					conn.QueryString = "UPDATE AP_RF_PRODUCT_ITEM SET STATUS='1', REQUEST='Active' WHERE SEQ='" + seq + "'";
					conn.ExecuteNonQuery();
				}
				else if(Request.QueryString["page"] == "06")	// Others Parameter
				{
					string seq = dataGridName.Items[row].Cells[0].Text.Trim();
					conn.QueryString = "UPDATE AP_RF_OTHERS SET STATUS='1', REQUEST='Active' WHERE SEQ='" + seq + "'";
					conn.ExecuteNonQuery();
				}
				else if(Request.QueryString["page"] == "07")	// Attribute Parameter
				{
					string seq = dataGridName.Items[row].Cells[0].Text.Trim();
					executeApproval(seq, "1");
				}
				else if(Request.QueryString["page"] == "08")	// Attribute Range Parameter
				{
					string seq = dataGridName.Items[row].Cells[0].Text.Trim();
					executeApproval(seq, "1");
				}
				else if(Request.QueryString["page"] == "09")	// Attribute Non Range Parameter
				{
					string seq = dataGridName.Items[row].Cells[0].Text.Trim();
					executeApproval(seq, "1");
				}
				else if(Request.QueryString["page"] == "10")	// Attribute Industry Parameter
				{
					string param1 = dataGridName.Items[row].Cells[0].Text.Trim();
					string param2 = dataGridName.Items[row].Cells[1].Text.Trim();
					string param3 = dataGridName.Items[row].Cells[2].Text.Trim();
					executeApproval2(param1,param2,param3, "1");
				}
			} 
			catch (Exception e)
			{
				Response.Write("<!-- " + e.Message + " --> ");
			}
		}

		private void executeApproval(string seq, string approvalFlag) 
		{
			if(Request.QueryString["page"] == "07")	// Attribute Parameter
			{
				conn.QueryString = "EXEC AP_APPROVEVARIABLE '" + seq + "','" + approvalFlag + "'";
				conn.ExecuteNonQuery();
			}
			else if(Request.QueryString["page"] == "08")	// Attribute Range Parameter
			{
				conn.QueryString = "EXEC AP_APPROVEVARIABLERANGE '" + seq + "','" + approvalFlag + "'";
				conn.ExecuteNonQuery();
			}
			else if(Request.QueryString["page"] == "09")	// Attribute Non Range Parameter
			{
				conn.QueryString = "EXEC AP_APPROVEVARIABLENONRANGE '" + seq + "','" + approvalFlag + "'";
				conn.ExecuteNonQuery();
			}
			
			conn.ClearData();
			ViewData();
		}

		private void executeApproval2(string param1,string param2,string param3, string approvalFlag) 
		{
			if(Request.QueryString["page"] == "10")	// Industry Parameter
			{
				conn.QueryString = "EXEC AP_APPROVEVARIABLE_INDUSTRY '" + param1 + "','" + param2 + "','" + param3 + "','" + approvalFlag + "'";
				conn.ExecuteNonQuery();
			}
			
			conn.ClearData();
			ViewData();
		}

		private void deleteData(int row, DataGrid dataGridName)
		{
			try 
			{
				if(Request.QueryString["page"] == "01")		// Benchmark Parameter
				{
					string seq = dataGridName.Items[row].Cells[0].Text.Trim();
					//conn.QueryString = "DELETE AP_RF_BENCHMARK WHERE SEQ='" + seq + "'";
					conn.QueryString = "DELETE AP_BENCHMARK WHERE ID_AP_BENCHMARK='" + seq + "'";
					conn.ExecuteNonQuery();
				}
				else if(Request.QueryString["page"] == "02")	// Variable Parameter
				{
					string seq = dataGridName.Items[row].Cells[0].Text.Trim();
					conn.QueryString = "DELETE AP_RF_VARIABLE WHERE SEQ='" + seq + "'";					
					conn.ExecuteNonQuery();
				}
				else if(Request.QueryString["page"] == "03")	// Model Parameter
				{
					string seq = dataGridName.Items[row].Cells[0].Text.Trim();
					conn.QueryString = "DELETE AP_RF_MODEL WHERE SEQ='" + seq + "'";
					conn.ExecuteNonQuery();
				}
				else if(Request.QueryString["page"] == "04")	// Product Master Parameter
				{
					string seq = dataGridName.Items[row].Cells[0].Text.Trim();
					conn.QueryString = "DELETE AP_VARIABLE WHERE ID_AP_VARIABLE='" + seq + "'";
					conn.ExecuteNonQuery();
				}
				else if(Request.QueryString["page"] == "05")	// Product Item Parameter
				{
					string seq = dataGridName.Items[row].Cells[0].Text.Trim();
					conn.QueryString = "DELETE AP_RF_PRODUCT_ITEM WHERE SEQ='" + seq + "'";
					conn.ExecuteNonQuery();
				}
				else if(Request.QueryString["page"] == "06")	// Others Parameter
				{
					string seq = dataGridName.Items[row].Cells[0].Text.Trim();
					conn.QueryString = "DELETE AP_RF_OTHERS WHERE SEQ='" + seq + "'";
					conn.ExecuteNonQuery();
				}
				else if(Request.QueryString["page"] == "07")	// Attribute Parameter
				{
					string seq = dataGridName.Items[row].Cells[0].Text.Trim();
					executeApproval(seq, "0");
				}
				else if(Request.QueryString["page"] == "08")	// Attribute Range Parameter
				{
					string seq = dataGridName.Items[row].Cells[0].Text.Trim();
					executeApproval(seq, "0");
				}
				else if(Request.QueryString["page"] == "09")	// Attribute Non Range Parameter
				{
					string seq = dataGridName.Items[row].Cells[0].Text.Trim();
					executeApproval(seq, "0");
				}
				else if(Request.QueryString["page"] == "10")	// Attribute Non Range Parameter
				{
					string param1 = dataGridName.Items[row].Cells[0].Text.Trim();
					string param2 = dataGridName.Items[row].Cells[1].Text.Trim();
					string param3 = dataGridName.Items[row].Cells[2].Text.Trim();
					executeApproval2(param1,param2,param3, "0");
				}
			} 
			catch (Exception e)
			{
				Response.Write("<!-- " + e.Message + " --> ");
			}
		}

		protected void BTN_BACK_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			Response.Redirect("../AccountPlanningParam.aspx?mc=" + Request.QueryString["mc"]);
		}
	}
}
