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
using System.Configuration;
namespace SME.PortfolioParameter
{
	/// <summary>
	/// Summary description for ParamIndustryClassLink.
	/// </summary>
	public partial class ParamIndustryClassLink : System.Web.UI.Page
	{
	
		protected Connection conn = new Connection(System.Configuration.ConfigurationSettings.AppSettings["connectionString"]);
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
		
			if (!IsPostBack)
			{
				LBL_SAVEMODE.Text = "1";
				conn.QueryString = "select PD_INDUSTRY_NAMECD, PD_INDUSTRY_NAME from PD_RF_INDUSTRY_CLASS where active='1' order by convert(int,PD_INDUSTRY_NAMECD)";
				conn.ExecuteQuery();
				DDL_INDUSTRY_NAME.Items.Clear();
				DDL_INDUSTRY_NAME.Items.Add(new ListItem("-- Pilih --", ""));
				for (int i=0; i<conn.GetRowCount(); i++)
					DDL_INDUSTRY_NAME.Items.Add(new ListItem(conn.GetFieldValue(i,1), conn.GetFieldValue(i, 0)));

				conn.QueryString = "select BMSUBSUB_CODE, BMSUBSUB_DESC from RFBMSUBSUBSEKTOREKONOMI where ACTIVE='1' order by BMSUBSUB_CODE";
				conn.ExecuteQuery();
				DDL_KSEBI4.Items.Clear();
				DDL_KSEBI4.Items.Add(new ListItem("-- Pilih --", ""));
				for (int i=0; i<conn.GetRowCount(); i++)
					DDL_KSEBI4.Items.Add(new ListItem(conn.GetFieldValue(i,1), conn.GetFieldValue(i, 0)));
/*
				conn.QueryString = "select PD_KSEBMCD,PD_KSEBMDESC from PD_RF_KSEBM where ACTIVE='1'";
				conn.ExecuteQuery();
				DDL_KSEBM.Items.Clear();
				DDL_KSEBM.Items.Add(new ListItem("-- Pilih --", ""));
				for (int i=0; i<conn.GetRowCount(); i++)
					DDL_KSEBM.Items.Add(new ListItem(conn.GetFieldValue(i,1), conn.GetFieldValue(i, 0)));
*/
				bindData1();
				bindData2();
			}
			
			Datagrid1.PageIndexChanged += new DataGridPageChangedEventHandler(this.Grid_Change1);
			DataGrid2.PageIndexChanged += new DataGridPageChangedEventHandler(this.Grid_Change2);
			
			TXT_INDUSTRY_CLASS.ReadOnly=true;
			TXT_RATIO.ReadOnly=true;
		}



		private string getPendingStatus(string saveMode) 
		{
			string status = "";			
			switch (saveMode)
			{
				case "0":
					status = "Update";
					break;
				case "1":
					status = "Insert";
					break;
				case "2":
					status = "Delete";
					break;
				default:
					status = "";
					break;
			}
			return status;
		}


	
		private void bindData1()
		{
			conn.QueryString = "select BI_SEQ, BI_DESC,PD_KSEBMCD,(select PD_KSEBMDESC from PD_RF_KSEBM B where A.PD_KSEBMCD = B.PD_KSEBMCD)PD_KSEBMDESC, A.PD_INDUSTRY_NAMECD, (select C.PD_INDUSTRY_NAME from PD_RF_INDUSTRY_CLASS C where A.PD_INDUSTRY_NAMECD = C.PD_INDUSTRY_NAMECD)PD_INDUSTRY_NAME, E.PD_INDUSTRY_CLASSCD, (select D.PD_INDUSTRY_CLASS from PD_RF_INDUSTRY_CLASS_CAP D where D.PD_INDUSTRY_CLASSCD = E.PD_INDUSTRY_CLASSCD)PD_INDUSTRY_CLASS, F.PD_RATIO_LIMIT from PD_RF_INDUSTRYCLASS_LINK A left join PD_RF_INDUSTRY_CLASS E on A.PD_INDUSTRY_NAMECD = E.PD_INDUSTRY_NAMECD left join PD_RF_INDUSTRY_CLASS_CAP F on E.PD_INDUSTRY_CLASSCD = F.PD_INDUSTRY_CLASSCD where A.ACTIVE='1'";
			conn.ExecuteQuery();
			
			DataTable dt = new DataTable();
			dt = conn.GetDataTable().Copy();
			Datagrid1.DataSource = dt;
			Datagrid1.DataBind();
		}

	
		private void bindData2()
		{
		
			conn.QueryString = "select BI_SEQ, BI_DESC,PD_KSEBMCD, PENDINGSTATUS, (select PD_KSEBMDESC from PD_RF_KSEBM B where A.PD_KSEBMCD = B.PD_KSEBMCD)PD_KSEBMDESC, A.PD_INDUSTRY_NAMECD, (select C.PD_INDUSTRY_NAME from PD_RF_INDUSTRY_CLASS C where A.PD_INDUSTRY_NAMECD = C.PD_INDUSTRY_NAMECD)PD_INDUSTRY_NAME, E.PD_INDUSTRY_CLASSCD, (select D.PD_INDUSTRY_CLASS from PD_RF_INDUSTRY_CLASS_CAP D where D.PD_INDUSTRY_CLASSCD = E.PD_INDUSTRY_CLASSCD)PD_INDUSTRY_CLASS, F.PD_RATIO_LIMIT from PD_PENDING_RF_INDUSTRYCLASS_LINK A left join PD_RF_INDUSTRY_CLASS E on A.PD_INDUSTRY_NAMECD = E.PD_INDUSTRY_NAMECD left join PD_RF_INDUSTRY_CLASS_CAP F on E.PD_INDUSTRY_CLASSCD = F.PD_INDUSTRY_CLASSCD where A.ACTIVE='1'";
			conn.ExecuteQuery();

			DataTable dt = new DataTable();
			dt = conn.GetDataTable().Copy();
			DataGrid2.DataSource = dt;
			DataGrid2.DataBind();

			for (int i = 0; i < DataGrid2.Items.Count; i++)
			{
				if (DataGrid2.Items[i].Cells[9].Text.Trim() == "0")
				{
					DataGrid2.Items[i].Cells[9].Text = "UPDATE";
				}
				else if (DataGrid2.Items[i].Cells[9].Text.Trim() == "1")
				{
					DataGrid2.Items[i].Cells[9].Text = "INSERT";
				}
				else if (DataGrid2.Items[i].Cells[9].Text.Trim() == "2")
				{
					DataGrid2.Items[i].Cells[9].Text = "DELETE";
				}
			} 
		}

		private void clearEditBoxes()
		{
			DDL_INDUSTRY_NAME.SelectedValue="";
			DDL_INDUSTRY_NAME.Enabled=true;
			TXT_INDUSTRY_CLASS.Text="";
			TXT_INDUSTRY_CLASS.ReadOnly=true;
			TXT_RATIO.Text="";
			TXT_RATIO.ReadOnly=true;
			DDL_KSEBI4.SelectedValue="";
			DDL_KSEBI4.Enabled=true;
			//DDL_KSEBM.SelectedValue="";
			//DDL_KSEBM.Enabled=true;
					
			LBL_SAVEMODE.Text = "1";
			activatePostBackControls(true);
		}

		private void activatePostBackControls(bool mode)
		{
			//TXT_BRANCH_CODE.Enabled = mode;
		}

		private void cleansTextBox (TextBox tb)
		{
			if (tb.Text.Trim() == "&nbsp;")
				tb.Text = "";
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
			this.Datagrid1.ItemCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.Datagrid1_ItemCommand);
			this.DataGrid2.ItemCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.DataGrid2_ItemCommand);

		}
		#endregion

		void Grid_Change1(Object sender, DataGridPageChangedEventArgs e) 
		{
			// Set CurrentPageIndex to the page the user clicked.
			Datagrid1.CurrentPageIndex = e.NewPageIndex;
			// Re-bind the data to refresh the DataGrid control. 
			bindData1();	
		}

		void Grid_Change2(Object sender, DataGridPageChangedEventArgs e) 
		{
			// Set CurrentPageIndex to the page the user clicked.
			DataGrid2.CurrentPageIndex = e.NewPageIndex;
			// Re-bind the data to refresh the DataGrid control. 
			bindData2();	
		}

		private void Datagrid1_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			clearEditBoxes();
			switch(((LinkButton)e.CommandSource).CommandName)
			{
				case "edit":
					DDL_INDUSTRY_NAME.SelectedValue		= e.Item.Cells[0].Text.Trim();
					TXT_INDUSTRY_CLASS.Text				= e.Item.Cells[2].Text.Trim();
					TXT_RATIO.Text						= e.Item.Cells[4].Text.Trim();
					DDL_KSEBI4.SelectedValue			= e.Item.Cells[5].Text.Trim();
					//DDL_KSEBM.SelectedValue				= e.Item.Cells[7].Text.Trim();
					TXT_INDUSTRY_CLASS.ReadOnly			= true;
					TXT_RATIO.ReadOnly					= true;
					DDL_INDUSTRY_NAME.Enabled			= true;
					DDL_KSEBI4.Enabled					= true;
					//DDL_KSEBM.Enabled					= true;
					LBL_SAVEMODE.Text = "0";
					activatePostBackControls(false);
					cleansTextBox(TXT_INDUSTRY_CLASS);
					cleansTextBox(TXT_RATIO);
					break;
					
				case "delete":
					//LBL_SAVEMODE.Text = "2";
					conn.QueryString = "INSERT INTO PD_PENDING_RF_INDUSTRYCLASS_LINK values ('"+e.Item.Cells[5].Text.Trim()+"','"+e.Item.Cells[6].Text.Trim()+"', '"+e.Item.Cells[7].Text.Trim()+"','"+e.Item.Cells[0].Text.Trim()+"','1','2')";
					conn.ExecuteNonQuery();

					bindData2();
					break;
				
				default:
					// Do nothing.
					break;
			} 
		}

		private void DataGrid2_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			clearEditBoxes();
			switch(((LinkButton)e.CommandSource).CommandName)
			{
				case "edit":
					DDL_INDUSTRY_NAME.SelectedValue		= e.Item.Cells[0].Text.Trim();
					TXT_INDUSTRY_CLASS.Text				= e.Item.Cells[2].Text.Trim();
					TXT_RATIO.Text						= e.Item.Cells[4].Text.Trim();
					DDL_KSEBI4.SelectedValue			= e.Item.Cells[5].Text.Trim();
					//DDL_KSEBM.SelectedValue				= e.Item.Cells[7].Text.Trim();
					TXT_INDUSTRY_CLASS.ReadOnly			= true;
					TXT_RATIO.ReadOnly					= true;
					DDL_INDUSTRY_NAME.Enabled			= true;
					DDL_KSEBI4.Enabled					= true;
					//DDL_KSEBM.Enabled					= true;
					LBL_SAVEMODE.Text = "0";
					activatePostBackControls(false);
					cleansTextBox(TXT_INDUSTRY_CLASS);
					cleansTextBox(TXT_RATIO);
					break;
					
				case "delete":
					//LBL_SAVEMODE.Text = "2";
					conn.QueryString = "delete PD_PENDING_RF_INDUSTRYCLASS_LINK where BI_SEQ='"+e.Item.Cells[5].Text.Trim()+"' and PD_INDUSTRY_NAMECD ='"+e.Item.Cells[0].Text.Trim()+"'";
					conn.ExecuteNonQuery();
					bindData2();
					break;
				default:
					// Do nothing.
					break;
			}  
		}

		protected void BTN_SAVE_Click(object sender, System.EventArgs e)
		{
			//namafungsi(LBL_SAVEMODE.Text);
			if (LBL_SAVEMODE.Text == "0")
			{
				conn.QueryString = "select * from PD_PENDING_RF_INDUSTRYCLASS_LINK where BI_SEQ='"+DDL_KSEBI4.SelectedValue+"'";
				conn.ExecuteQuery();
				if (conn.GetRowCount() > 0)
				{
					conn.QueryString = "UPDATE PD_PENDING_RF_INDUSTRYCLASS_LINK SET BI_DESC='"+DDL_KSEBI4.SelectedItem+"', PD_INDUSTRY_NAMECD='"+DDL_INDUSTRY_NAME.SelectedValue+"', active='1', PENDINGSTATUS='"+LBL_SAVEMODE.Text+"' where BI_SEQ='"+DDL_KSEBI4.SelectedValue+"'";
					conn.ExecuteQuery();
					bindData2();
					clearEditBoxes();
				}
				else
				{
					conn.QueryString = "INSERT INTO PD_PENDING_RF_INDUSTRYCLASS_LINK VALUES ('"+DDL_KSEBI4.SelectedValue+"','"+DDL_KSEBI4.SelectedItem+"',' ','"+DDL_INDUSTRY_NAME.SelectedValue+"','1','"+LBL_SAVEMODE.Text+"')";
					conn.ExecuteQuery();
					bindData2();
					clearEditBoxes();
				}
			}
			else if (LBL_SAVEMODE.Text == "1")
			{
				conn.QueryString = "INSERT INTO PD_PENDING_RF_INDUSTRYCLASS_LINK VALUES ('"+DDL_KSEBI4.SelectedValue+"','"+DDL_KSEBI4.SelectedItem+"',' ','"+DDL_INDUSTRY_NAME.SelectedValue+"','1','"+LBL_SAVEMODE.Text+"')";
				conn.ExecuteQuery();
				bindData2();
				clearEditBoxes();
				LBL_SAVEMODE.Text = "1";	
			}

		}

		protected void BTN_CANCEL_Click(object sender, System.EventArgs e)
		{
			clearEditBoxes();
			LBL_SAVEMODE.Text = "1";
		}

		protected void BTN_BACK_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			Response.Redirect("PDParam.aspx?mc="+Request.QueryString["mc"]+"&moduleId=01");
			//Response.Redirect("../../GeneralParamAll.aspx?mc="+Request.QueryString["mc"]);
		}

		protected void DDL_INDUSTRY_NAME_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			conn.QueryString = "select PD_INDUSTRY_CLASS, PD_RATIO_LIMIT from PD_RF_INDUSTRY_CLASS B left join PD_RF_INDUSTRY_CLASS_CAP A on B.PD_INDUSTRY_CLASSCD = A.PD_INDUSTRY_CLASSCD where PD_INDUSTRY_NAMECD='"+DDL_INDUSTRY_NAME.SelectedValue+"' and B.active='1'";
			conn.ExecuteQuery();
			TXT_INDUSTRY_CLASS.Text=conn.GetFieldValue("PD_INDUSTRY_CLASS");
			TXT_RATIO.Text=conn.GetFieldValue("PD_RATIO_LIMIT");
		}

	}
}
