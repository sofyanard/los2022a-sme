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

namespace SME.MAS.SupervisionManagement.BusinessRecoverySupervision.ProblemSolving
{
	/// <summary>
	/// Summary description for ProblemSolving.
	/// </summary>
	public partial class ProblemSolving : System.Web.UI.Page
	{
		protected Connection conn = new Connection(ConfigurationSettings.AppSettings["conn"]);
		protected Tools tool = new Tools();
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here

			if(!IsPostBack)
			{
				DDL_BLN_FINISH.Items.Add(new ListItem("--Pilih--",""));
				DDL_BLN_MULAI.Items.Add(new ListItem("--Pilih--",""));
				
				for(int i=1; i<=12; i++)
				{
					DDL_BLN_FINISH.Items.Add(new ListItem(DateAndTime.MonthName(i, false), i.ToString()));
					DDL_BLN_MULAI.Items.Add(new ListItem(DateAndTime.MonthName(i, false), i.ToString()));
				}
				
				DDL_STATUS.Items.Add(new ListItem("--Pilih--",""));
				conn.QueryString = "select * from mas_rf_problem_solve where status='1'";
				conn.ExecuteQuery();
				for (int i = 0; i < conn.GetRowCount(); i++)
					DDL_STATUS.Items.Add(new ListItem(conn.GetFieldValue(i,1),conn.GetFieldValue(i,0)));
				
				DDL_UNIT.Items.Add(new ListItem("--Pilih--",""));
				conn.QueryString = "select branch_code, branch_code + '-' + branch_name as branch, branch_name from rfbranch where active='1' order by branch_name";
				conn.ExecuteQuery();
				for (int i = 0; i < conn.GetRowCount(); i++)
					DDL_UNIT.Items.Add(new ListItem(conn.GetFieldValue(i,1),conn.GetFieldValue(i,0)));									
			}

			ViewData();
		}

		private void ViewData()
		{
			conn.QueryString = "select * from mas_problem_solving where pic_input='"+ Session["UserID"].ToString() +"'";
			conn.ExecuteQuery();
			FillGrid();
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
	
			for (int i = 0; i < DatGrd.Items.Count; i++)
			{
				DatGrd.Items[i].Cells[6].Text = tool.FormatDate(DatGrd.Items[i].Cells[6].Text, true);
				DatGrd.Items[i].Cells[7].Text = tool.FormatDate(DatGrd.Items[i].Cells[7].Text, true);
			}
		}

		private void ClearData()
		{
			TXT_NAME.Text = "";
			DDL_UNIT.SelectedValue = "";
			TXT_MASALAH.Text = "";
			TXT_PIC_SOLUTION.Text = "";
			TXT_SOLUSI.Text = "";
			DDL_STATUS.SelectedValue = "";
			TXT_TGL_FINISH.Text = "";
			DDL_BLN_FINISH.SelectedValue = "";
			TXT_THN_FINISH.Text = "";
			TXT_SEQ.Text = "";
			TXT_TGL_MULAI.Text = "";
			DDL_BLN_MULAI.SelectedValue = "";
			TXT_THN_MULAI.Text = "";
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

		}
		#endregion

		protected void BTN_CLEAR_Click(object sender, System.EventArgs e)
		{
			ClearData();
		}

		private void DatGrd_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			DatGrd.CurrentPageIndex = e.NewPageIndex;
			ViewData();
		}

		protected void BTN_INSERT_Click(object sender, System.EventArgs e)
		{
			Int64 now = Int64.Parse(Tools.toISODate(DateTime.Now.Day.ToString(), DateTime.Now.Month.ToString(), DateTime.Now.Year.ToString())), tglMulai, tglFinish;
			try 
			{
				tglMulai = Int64.Parse(Tools.toISODate(TXT_TGL_MULAI.Text, DDL_BLN_MULAI.SelectedValue, TXT_THN_MULAI.Text));
			} 
			catch 
			{
				GlobalTools.popMessage(this, "Tanggal mulai tidak valid!");
				return;
			}

			try 
			{
				tglFinish = Int64.Parse(Tools.toISODate(TXT_TGL_FINISH.Text, DDL_BLN_FINISH.SelectedValue, TXT_THN_FINISH.Text));
			} 
			catch 
			{
				GlobalTools.popMessage(this, "Tanggal selesai tidak valid!");
				return;
			}
			if (TXT_SEQ.Text == "")
			{
				conn.QueryString = " exec MAS_PROBLEM_SOLVING_INSERT '" + 			
					TXT_NAME.Text + "', '" +
					DDL_UNIT.SelectedValue + "', '" +
					TXT_MASALAH.Text + "', '" +
					TXT_PIC_SOLUTION.Text + "', '" +
					TXT_SOLUSI.Text + "', '" +
					DDL_STATUS.SelectedValue + "', " +
					tool.ConvertDate(TXT_TGL_MULAI.Text, DDL_BLN_MULAI.SelectedValue, TXT_THN_MULAI.Text) + ", " +					
					tool.ConvertDate(TXT_TGL_FINISH.Text, DDL_BLN_FINISH.SelectedValue, TXT_THN_FINISH.Text) + ", '" +					
					Session["UserID"].ToString() +"' " ;
				conn.ExecuteQuery();				
			}
			else
			{
				conn.QueryString = " exec MAS_PROBLEM_SOLVING_UPDATE " + 
					Convert.ToInt32(TXT_SEQ.Text) + ", '" +					
					TXT_NAME.Text + "', '" +
					DDL_UNIT.SelectedValue + "', '" +
					TXT_MASALAH.Text + "', '" +
					TXT_PIC_SOLUTION.Text + "', '" +
					TXT_SOLUSI.Text + "', '" +
					DDL_STATUS.SelectedValue + "', " +
					tool.ConvertDate(TXT_TGL_MULAI.Text, DDL_BLN_MULAI.SelectedValue, TXT_THN_MULAI.Text) + ", " +					
					tool.ConvertDate(TXT_TGL_FINISH.Text, DDL_BLN_FINISH.SelectedValue, TXT_THN_FINISH.Text) + ", '" +	
					Session["UserID"].ToString() +"' " ;
				conn.ExecuteQuery();
			}
			ClearData();
			ViewData();
		}

		private void DatGrd_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			switch (((LinkButton)e.CommandSource).CommandName)
			{
				case "delete_data":
					conn.QueryString = "delete from mas_problem_solving where seq=" + Convert.ToInt32(e.Item.Cells[0].Text) + "";
					conn.ExecuteQuery();					
					ClearData();					
					ViewData();
					break;

				case "edit_data":					
					conn.QueryString = "select * from mas_problem_solving where seq=" + Convert.ToInt32(e.Item.Cells[0].Text) + "";
					conn.ExecuteQuery();
					
					TXT_SEQ.Text = conn.GetFieldValue("seq");
					TXT_NAME.Text = conn.GetFieldValue("nama");
					try{DDL_UNIT.SelectedValue = conn.GetFieldValue("unit_code");}
					catch{DDL_UNIT.SelectedValue = "";}
					TXT_MASALAH.Text = conn.GetFieldValue("masalah");
					TXT_PIC_SOLUTION.Text = conn.GetFieldValue("pic_solution");
					TXT_SOLUSI.Text = conn.GetFieldValue("solution");
					try{DDL_STATUS.SelectedValue = conn.GetFieldValue("status");}
					catch{DDL_STATUS.SelectedValue = "";}	
					TXT_TGL_FINISH.Text = tool.FormatDate_Day(conn.GetFieldValue("tgl_selesai"));
					try{DDL_BLN_FINISH.SelectedValue = tool.FormatDate_Month(conn.GetFieldValue("tgl_selesai")); }
					catch{DDL_BLN_FINISH.SelectedValue = "";}					
					TXT_THN_FINISH.Text = tool.FormatDate_Year(conn.GetFieldValue("tgl_selesai"));
					TXT_TGL_MULAI.Text = tool.FormatDate_Day(conn.GetFieldValue("tgl_mulai"));
					try{DDL_BLN_MULAI.SelectedValue = tool.FormatDate_Month(conn.GetFieldValue("tgl_mulai")); }
					catch{DDL_BLN_MULAI.SelectedValue = "";}					
					TXT_THN_MULAI.Text = tool.FormatDate_Year(conn.GetFieldValue("tgl_mulai"));				
					break;
			}
		}


	}
}
