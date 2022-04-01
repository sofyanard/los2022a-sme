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

namespace SME.MAS.SupervisionManagement.ClusterSupervision.Daily
{
	/// <summary>
	/// Summary description for DailyActivities.
	/// </summary>
	public partial class DailyActivities : System.Web.UI.Page
	{
		protected Tools tool = new Tools();
		protected Connection conn = new Connection(ConfigurationSettings.AppSettings["conn"]);
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			if(!IsPostBack)
			{
				DDL_BLN_AKTIVITAS.Items.Add(new ListItem("--Pilih--",""));
				
				for(int i=1; i<=12; i++)
				{
					DDL_BLN_AKTIVITAS.Items.Add(new ListItem(DateAndTime.MonthName(i, false), i.ToString()));					
				}
				
				DDL_JNS_AKTIVITAS.Items.Add(new ListItem("--Pilih--",""));
				conn.QueryString = "select * from mas_rf_jenis_aktivitas where status='1'";
				conn.ExecuteQuery();
				for (int i = 0; i < conn.GetRowCount(); i++)
					DDL_JNS_AKTIVITAS.Items.Add(new ListItem(conn.GetFieldValue(i,1),conn.GetFieldValue(i,0)));
				
				DDL_UNIT.Items.Add(new ListItem("--Pilih--",""));
				conn.QueryString = "select * from rfbranch where active='1' order by branch_name";
				conn.ExecuteQuery();
				for (int i = 0; i < conn.GetRowCount(); i++)
					DDL_UNIT.Items.Add(new ListItem(conn.GetFieldValue(i,1),conn.GetFieldValue(i,0)));	
				
				/*conn.QueryString = "select * from mas_cluster_supervision_welcoming_call where unit_code = '"+ Session["BranchID"].ToString() +"' and pic_input_penyimpangan = '"+ Session["UserID"].ToString() +"' ";
				conn.ExecuteQuery();
				if (conn.GetFieldValue("flag") == "1")
				{
					BTN_INSERT.Enabled = false;
				}*/
			}

			ViewData();
			ViewMenu();
		}

		private void ViewData()
		{
			conn.QueryString = "select * from VW_MAS_DAILY_ACTIVITIES where pic_input_daily='"+ Session["UserID"].ToString() +"' ";
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
				DatGrd.Items[i].Cells[4].Text = tool.FormatDate(DatGrd.Items[i].Cells[4].Text, true);
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

		}
		#endregion

		protected void BTN_CLEAR_Click(object sender, System.EventArgs e)
		{
			ClearData();
		}

		private void ClearData()
		{
			DDL_JNS_AKTIVITAS.SelectedValue = "";
			TXT_JUM_AKTIVITAS.Text = "";
			DDL_UNIT.SelectedValue = "";
			TXT_STATUS.Text = "";
			TXT_TGL_AKTIVITAS.Text = "";
			DDL_BLN_AKTIVITAS.SelectedValue = "";
			TXT_THN_AKTIVITAS.Text = "";
			TXT_KET.Text = "";
			TXT_SEQ.Text = "";
		}

		protected void BTN_INSERT_Click(object sender, System.EventArgs e)
		{
			Int64 now = Int64.Parse(Tools.toISODate(DateTime.Now.Day.ToString(), DateTime.Now.Month.ToString(), DateTime.Now.Year.ToString())), compEstablish;
			try 
			{
				compEstablish = Int64.Parse(Tools.toISODate(TXT_TGL_AKTIVITAS.Text, DDL_BLN_AKTIVITAS.SelectedValue, TXT_THN_AKTIVITAS.Text));
			} 
			catch 
			{
				GlobalTools.popMessage(this, "Tanggal aktivitas tidak valid!");
				return;
			}

			if (TXT_SEQ.Text == "")
			{
				conn.QueryString = " exec MAS_CLUSTER_SUPERVISION_INSERT '" + 			
					DDL_JNS_AKTIVITAS.SelectedValue + "', '" +
					TXT_JUM_AKTIVITAS.Text + "', '" +
					DDL_UNIT.SelectedValue + "', '" +
					TXT_STATUS.Text + "', " +
					tool.ConvertDate(TXT_TGL_AKTIVITAS.Text, DDL_BLN_AKTIVITAS.SelectedValue, TXT_THN_AKTIVITAS.Text) + ", '" +
					TXT_KET.Text + "', '" +
					Session["BranchID"].ToString() + "', '" + //distrik code
					Session["BranchID"].ToString() + "', '" + //cluster code
					Session["UserID"].ToString() +"' " ;
				conn.ExecuteQuery();				
			}
			else
			{
				conn.QueryString = " exec MAS_CLUSTER_SUPERVISION_UPDATE " + 
					Convert.ToInt32(TXT_SEQ.Text) + ", '" +					
					DDL_JNS_AKTIVITAS.SelectedValue + "', '" +
					TXT_JUM_AKTIVITAS.Text + "', '" +
					DDL_UNIT.SelectedValue + "', '" +
					TXT_STATUS.Text + "', " +
					tool.ConvertDate(TXT_TGL_AKTIVITAS.Text, DDL_BLN_AKTIVITAS.SelectedValue, TXT_THN_AKTIVITAS.Text) + ", '" +
					TXT_KET.Text + "', '" +
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
					conn.QueryString = "delete from mas_cluster_supervision where seq=" + Convert.ToInt32(e.Item.Cells[0].Text) + "";
					conn.ExecuteQuery();					
					ClearData();					
					ViewData();
					break;

				case "edit_data":					
					conn.QueryString = "select * from mas_cluster_supervision where seq=" + Convert.ToInt32(e.Item.Cells[0].Text) + "";
					conn.ExecuteQuery();
					
					TXT_SEQ.Text = conn.GetFieldValue("seq");					
					try{DDL_JNS_AKTIVITAS.SelectedValue = conn.GetFieldValue("activity_type");}
					catch{DDL_JNS_AKTIVITAS.SelectedValue = "";}
					TXT_JUM_AKTIVITAS.Text = conn.GetFieldValue("jumlah_activity");
					try{DDL_UNIT.SelectedValue = conn.GetFieldValue("unit_code");}
					catch{DDL_UNIT.SelectedValue = "";}
					TXT_STATUS.Text = conn.GetFieldValue("status_daily_activity");
					TXT_TGL_AKTIVITAS.Text = tool.FormatDate_Day(conn.GetFieldValue("activity_date"));
					try{DDL_BLN_AKTIVITAS.SelectedValue = tool.FormatDate_Month(conn.GetFieldValue("activity_date")); }
					catch{DDL_BLN_AKTIVITAS.SelectedValue = "";}
					TXT_THN_AKTIVITAS.Text = tool.FormatDate_Year(conn.GetFieldValue("activity_date"));
					TXT_KET.Text = conn.GetFieldValue("ket_daily_activity");					
					break;
			}
		}

		private void DatGrd_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			DatGrd.CurrentPageIndex = e.NewPageIndex;
			ViewData();
		}

		private void ViewMenu()
		{
			Menu.Controls.Clear();
			try 
			{
				conn.QueryString = "select * from SCREENMENU where menucode = '"+Request.QueryString["mc"]+"'";
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
							strtemp = "regnum=" + Request.QueryString["regnum"] + "&rekanan_ref="+Request.QueryString["rekanan_ref"]  + "&tc=" + Request.QueryString["tc"] + "&exist=" + Request.QueryString["exist"]+ "&view=" + Request.QueryString["view"];
						else	
							strtemp = "regnum=" + Request.QueryString["regnum"] + "&rekanan_ref="+Request.QueryString["rekanan_ref"]  + "&mc=" + Request.QueryString["mc"]+ "&exist=" + Request.QueryString["exist"]+ "&tc="+Request.QueryString["tc"]+ "&view=" + Request.QueryString["view"];
						if (conn.GetFieldValue(i,3).IndexOf("?par=") < 0 && conn.GetFieldValue(i,3).IndexOf("&par=") < 0)  
							strtemp = strtemp + "&par=" + Request.QueryString["par"] + "&mc2=" + Request.QueryString["mc2"];
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
	}
}
