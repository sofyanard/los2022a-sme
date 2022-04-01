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

namespace SME.MAS.SupervisionManagement.MicroCreditQuality.MonthlyReview
{
	/// <summary>
	/// Summary description for MonthlyReview.
	/// </summary>
	public partial class MonthlyReview : System.Web.UI.Page
	{
		protected Tools tool = new Tools();
		protected Connection conn = new Connection(ConfigurationSettings.AppSettings["conn"]);
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			if(!IsPostBack)
			{
				DDL_BLN.Items.Add(new ListItem("--Pilih--",""));				
				for(int i=1; i<=12; i++)
				{
					DDL_BLN.Items.Add(new ListItem(DateAndTime.MonthName(i, false), i.ToString()));					
				}

				DDL_THN.Items.Add(new ListItem("--Pilih--",""));
				conn.QueryString = "select * from vw_mas_year";
				conn.ExecuteQuery();
				for (int i = 0; i < conn.GetRowCount(); i++)
					DDL_THN.Items.Add(new ListItem(conn.GetFieldValue(i,0),conn.GetFieldValue(i,0)));				
				
				ViewData();				
			}
		}

		private void ViewData()
		{
			conn.QueryString = "select * from VW_MAS_RF_UNIT_REVIEW where pic_input='"+ Session["UserID"].ToString() +"'";
			conn.ExecuteQuery();
			FillGrid();
			conn.QueryString = "select top 1 *  from mas_monthly_review where pic_input='"+ Session["UserID"].ToString() +"'";
			conn.ExecuteQuery();
			TXT_TGL.Text = tool.FormatDate_Day(conn.GetFieldValue("periode"));
			DDL_BLN.SelectedValue = tool.FormatDate_Month(conn.GetFieldValue("periode"));
			DDL_THN.SelectedValue = tool.FormatDate_Year(conn.GetFieldValue("periode"));
		}

		private void FillGrid()
		{
			DataTable dt = new DataTable();
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
			for (int i=0;i<DatGrd.Items.Count;i++)
			{
				RadioButtonList RDO_DOC_KREDIT = (RadioButtonList) DatGrd.Items[i].Cells[2].FindControl("RDO_DOC_KREDIT");
				DropDownList DDL_MMM_OTS = (DropDownList) DatGrd.Items[i].Cells[4].FindControl("DDL_MMM_OTS");
				RadioButtonList RDO_MONITORING_MMM = (RadioButtonList) DatGrd.Items[i].Cells[6].FindControl("RDO_MONITORING_MMM");
				RadioButtonList RDO_INDIKASI_CALO = (RadioButtonList) DatGrd.Items[i].Cells[7].FindControl("RDO_INDIKASI_CALO");
				DropDownList DDL_RISK_LEVEL = (DropDownList) DatGrd.Items[i].Cells[6].FindControl("DDL_RISK_LEVEL");
				TextBox TXT_REASON = (TextBox) DatGrd.Items[i].Cells[9].FindControl("TXT_REASON");

				GlobalTools.fillRefList(DDL_MMM_OTS, "Select code, [desc] from mas_rf_mmm_ots where status=1" , false, conn);
				GlobalTools.fillRefList(DDL_RISK_LEVEL, "Select code, [desc] from mas_rf_risk_level where status=1" , false, conn);

				conn.QueryString = "select * from mas_monthly_review where seq#= '"+DatGrd.Items[i].Cells[0].Text.Trim()+"'";
				conn.ExecuteQuery();	
				try{RDO_DOC_KREDIT.SelectedValue = conn.GetFieldValue("DOC_KREDIT");}
				catch{RDO_DOC_KREDIT.SelectedValue = null;}
				try{DDL_MMM_OTS.SelectedValue = conn.GetFieldValue("MMM_OTS");}
				catch{DDL_MMM_OTS.SelectedValue = "";}
				try{RDO_MONITORING_MMM.SelectedValue = conn.GetFieldValue("MONITORING_MMM");}
				catch{RDO_MONITORING_MMM.SelectedValue = null;}
				try{RDO_INDIKASI_CALO.SelectedValue = conn.GetFieldValue("INDIKASI_CALO");}
				catch{RDO_INDIKASI_CALO.SelectedValue = null;}
				try{DDL_RISK_LEVEL.SelectedValue = conn.GetFieldValue("RISK_LEVEL");}
				catch{DDL_RISK_LEVEL.SelectedValue = "";}
				TXT_REASON.Text = conn.GetFieldValue("REASON_NOT_REVIEW");
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
			this.DatGrd.ItemCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.DatGrd_ItemCommand);
			this.DatGrd.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.DatGrd_PageIndexChanged);
			this.DatGrd.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(this.DatGrd_ItemDataBound);

		}
		#endregion

		protected void BTN_CLEAR_Click(object sender, System.EventArgs e)
		{
			for (int i=0;i<DatGrd.Items.Count;i++)
			{
				conn.QueryString = "update mas_monthly_review set DOC_KREDIT='', MMM_OTS='', MONITORING_MMM='', " +
					"INDIKASI_CALO='', RISK_LEVEL='', REASON_NOT_REVIEW='' " +
					"where seq# = '"+DatGrd.Items[i].Cells[0].Text.Trim()+"' ";
				conn.ExecuteQuery();

				ViewData();
			}			
		}

		protected void BTN_SAVE_Click(object sender, System.EventArgs e)
		{
			for (int i=0;i<DatGrd.Items.Count;i++)
			{
				RadioButtonList RDO_DOC_KREDIT = (RadioButtonList) DatGrd.Items[i].Cells[2].FindControl("RDO_DOC_KREDIT");
				DropDownList DDL_MMM_OTS = (DropDownList) DatGrd.Items[i].Cells[3].FindControl("DDL_MMM_OTS");
				RadioButtonList RDO_MONITORING_MMM = (RadioButtonList) DatGrd.Items[i].Cells[4].FindControl("RDO_MONITORING_MMM");
				RadioButtonList RDO_INDIKASI_CALO = (RadioButtonList) DatGrd.Items[i].Cells[5].FindControl("RDO_INDIKASI_CALO");
				DropDownList DDL_RISK_LEVEL = (DropDownList) DatGrd.Items[i].Cells[6].FindControl("DDL_RISK_LEVEL");
				TextBox TXT_REASON = (TextBox) DatGrd.Items[i].Cells[7].FindControl("TXT_REASON");
				
				conn.QueryString = "exec MAS_MONTHLY_REVIEW_INSERT '" +
					Session["UserID"].ToString() +"', "+	
					tool.ConvertDate(TXT_TGL.Text, DDL_BLN.SelectedValue, DDL_THN.SelectedValue) + ", '" +
					DatGrd.Items[i].Cells[0].Text.Trim() + "' , '" + 
					DatGrd.Items[i].Cells[1].Text.Trim() + "' , '" + 
					RDO_DOC_KREDIT.SelectedValue + "' , '" + 
					DDL_MMM_OTS.SelectedValue + "' , '" +
					RDO_MONITORING_MMM.SelectedValue + "' , '" +
					RDO_INDIKASI_CALO.SelectedValue + "' , '" +
					DDL_RISK_LEVEL.SelectedValue + "' , '" + 
					Session["BranchID"].ToString() +"', '"+ //distrik
					Session["BranchID"].ToString() +"', '"+ //cluster
					TXT_REASON.Text + "' ";					
				conn.ExecuteQuery();	
			}
			ViewData();	
		}

		private void DatGrd_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			DatGrd.CurrentPageIndex = e.NewPageIndex;
			ViewData();
		}

		protected void BTN_PRINT_Click(object sender, System.EventArgs e)
		{
			Response.Redirect("/SME/MAS/SupervisionManagement/MicroCreditQuality/MonthlyReview/PrintMonthlyReview.aspx?tc=" + Request.QueryString["tc"] + "&mc=" + Request.QueryString["mc"] + "&pic_input=" + Session["UserID"].ToString());
		}

		private void DatGrd_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			switch (((LinkButton)e.CommandSource).CommandName)
			{
				case "delete_data":
					conn.QueryString = "delete from mas_rf_unit_review where UNIT_SEQ#=" + Convert.ToInt32(e.Item.Cells[0].Text) + "";
					conn.ExecuteQuery();										
					ViewData();
					break;
			}
		}

		private void DatGrd_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			if ( e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item ) 
			{
				System.Web.UI.WebControls.LinkButton linkntn=(System.Web.UI.WebControls.LinkButton)e.Item.FindControl("delete_data");
				linkntn.Attributes.Add("onClick", "return confirm('Apakah Anda yakin akan menghapus data ini?')");
			}
		}
	}
}
