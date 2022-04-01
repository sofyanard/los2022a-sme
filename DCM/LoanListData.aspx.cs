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
using Microsoft.VisualBasic;
using System.Configuration;

namespace SME.DCM
{
	/// <summary>
	/// Summary description for LoanListData.
	/// </summary>
	public partial class LoanListData : System.Web.UI.Page
	{
		protected Connection conn2 = new Connection(ConfigurationSettings.AppSettings["conn2"]);
		protected Connection conn = new Connection(ConfigurationSettings.AppSettings["conn"]);
		protected Tools tools = new Tools();
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			if (!IsPostBack)
			{					
				FillAcct();	
				FillCust();
				conn2.QueryString = "select * from VW_LOANCO_LIST_DATA where assign_to='"+ Session["UserID"].ToString() +"' and status_flag='1' order by nama";
				conn2.ExecuteQuery();
				FillGrid();	
			}	
		}

		private void FillGrid()
		{
			DataTable dt = new DataTable();
			dt = conn2.GetDataTable().Copy();
			DGR.DataSource = dt;
			try 
			{
				DGR.DataBind();
			} 
			catch 
			{
				DGR.CurrentPageIndex = 0;
				DGR.DataBind();
			}
		}

		private void FillAcct()
		{
			DDL_ACTNO.Items.Add(new ListItem("--Pilih--",""));						
			conn2.QueryString = "select distinct acctno from vw_loanco_list_data where assign_to='"+ Session["UserID"].ToString() +"' ";
			conn2.ExecuteQuery();
			for (int i = 0; i < conn2.GetRowCount(); i++)
			{
				DDL_ACTNO.Items.Add(new ListItem(conn2.GetFieldValue(i,0),conn2.GetFieldValue(i,0)));
			}	
		}

		private void FillCust()
		{
			DDL_CUST.Items.Add(new ListItem("--Pilih--",""));						
			conn2.QueryString = "select distinct nama from vw_loanco_list_data where assign_to='"+ Session["UserID"].ToString() +"' ";
			conn2.ExecuteQuery();
			for (int i = 0; i < conn2.GetRowCount(); i++)
			{
				DDL_CUST.Items.Add(new ListItem(conn2.GetFieldValue(i,0),conn2.GetFieldValue(i,0)));
			}	
		}

		protected void BTN_FIND_Click(object sender, System.EventArgs e)
		{
			DGR.CurrentPageIndex = 0;
			SearchData();
		}

		private void SearchData()
		{
			string act, cust;
			act=DDL_ACTNO.SelectedValue;
			cust=DDL_CUST.SelectedValue;

			if (act=="" && cust=="")
			{
				conn2.QueryString = " select * from VW_LOANCO_LIST_DATA where assign_to='"+ Session["UserID"].ToString()+"' and status_flag='1' order by nama";
				conn2.ExecuteQuery();
			}

			if (act=="" && cust!="")
			{
				conn2.QueryString = " select * from VW_LOANCO_LIST_DATA where nama='"+ cust +"' and assign_to='"+ Session["UserID"].ToString()+"' and status_flag='1' order by nama";
				conn2.ExecuteQuery();
			}
			
			if (act!="" && cust=="")
			{
				conn2.QueryString = "select * from VW_LOANCO_LIST_DATA where acctno='"+ act +"' and status_flag='1' order by nama";
				conn2.ExecuteQuery();
			}

			if (act!="" && cust!="")
			{
				conn2.QueryString = "select * from VW_LOANCO_LIST_DATA where acctno='"+ act +"' and nama='"+ cust +"' and status_flag='1' order by nama";
				conn2.ExecuteQuery();
			}
			FillGrid();
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
			this.DGR.ItemCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.DGR_ItemCommand);
			this.DGR.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.DGR_PageIndexChanged);			

		}
		#endregion

		private void DGR_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			DGR.CurrentPageIndex = e.NewPageIndex;
			SearchData();
		}

		private void DGR_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{			
			switch (((LinkButton)e.CommandSource).CommandName)
			{
				case "view":						
					//GlobalTools.popMessage(this, e.Item.Cells[1].Text.ToString());
					Response.Redirect("LoanDetailDataCO.aspx?sta=exist&acctno=" + e.Item.Cells[2].Text + "&userid=" + Session["UserID"].ToString() + "&tc=" + Request.QueryString["tc"] + "&mc=" + Request.QueryString["mc"]);
					
				break;
			}
		}
		
	}
}
