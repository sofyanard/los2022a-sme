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
	/// Summary description for ClusterActivities.
	/// </summary>
	public partial class ClusterActivities : System.Web.UI.Page
	{
		protected Connection conn = new Connection(ConfigurationSettings.AppSettings["conn"]);
		protected Tools tool = new Tools();
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			ViewMenu();

			if(!IsPostBack)
			{
				DDL_BLN_BOOKING1.Items.Add(new ListItem("--Pilih--",""));
				DDL_BLN_BOOKING2.Items.Add(new ListItem("--Pilih--",""));				
				for(int i=1; i<=12; i++)
				{
					DDL_BLN_BOOKING1.Items.Add(new ListItem(DateAndTime.MonthName(i, false), i.ToString()));					
					DDL_BLN_BOOKING2.Items.Add(new ListItem(DateAndTime.MonthName(i, false), i.ToString()));					
				}
				TXT_CLUSTER.Text = Session["BranchName"].ToString();
				TXT_DISCTRICT.Text = Session["BranchName"].ToString();

				ViewDataDaily();
				VewDataWelcoming();
				ViewBtnSend();
			}
		}

		private void ViewBtnSend()
		{
			conn.QueryString = "select * from VW_MAS_WELCOMING_CALL where pic_input_penyimpangan='"+ Session["UserID"].ToString() +"' ";
			conn.ExecuteQuery();
			string indikasi, ket_no_hp, ket_penyimpangan;
			indikasi = conn.GetFieldValue("indikasi_penyimpangan_type");
			ket_no_hp = conn.GetFieldValue("ket_no_hp");
			ket_penyimpangan = conn.GetFieldValue("ket_penyimpangan");

			conn.QueryString = "select * from VW_MAS_DAILY_ACTIVITIES where pic_input_daily='"+ Session["UserID"].ToString() +"' ";
			conn.ExecuteQuery();
			if (conn.GetRowCount() > 0 || indikasi != "" || ket_no_hp != "" || ket_penyimpangan != "" )
			{
				BTN_SEND_TO_CAO.Enabled = false;
			}			
		}

		private void ViewDataDaily()
		{
			conn.QueryString = "select * from VW_MAS_DAILY_ACTIVITIES where pic_input_daily='"+ Session["UserID"].ToString() +"' ";
			conn.ExecuteQuery();
			FillGrid();
		}

		private void FillGrid()
		{
			DataTable dt = new DataTable();
			dt = conn.GetDataTable().Copy();
			DGR_DAILY.DataSource = dt;
			try 
			{
				DGR_DAILY.DataBind();
			} 
			catch 
			{
				DGR_DAILY.CurrentPageIndex = 0;
				DGR_DAILY.DataBind();
			}
	
			for (int i = 0; i < DGR_DAILY.Items.Count; i++)
			{
				DGR_DAILY.Items[i].Cells[4].Text = tool.FormatDate(DGR_DAILY.Items[i].Cells[4].Text, true);
			}
		}

		private void VewDataWelcoming()
		{
			//conn.QueryString = "select * from VW_MAS_WELCOMING_CALL_CLUSTER_ACTIVITIES where unit_code='"+ Session["BranchID"].ToString() +"' ";
			conn.QueryString = "select * from VW_MAS_WELCOMING_CALL where unit_code='"+ Session["BranchID"].ToString() +"' ";
			conn.ExecuteQuery();					
			FillGrid2();
		}

		private void FillGrid2()
		{
			DataTable dt = new DataTable();
			dt = conn.GetDataTable().Copy();
			DGR_WELCOMING.DataSource = dt;
			try 
			{
				DGR_WELCOMING.DataBind();
			} 
			catch 
			{
				DGR_WELCOMING.CurrentPageIndex = 0;
				DGR_WELCOMING.DataBind();
			}
	
			for (int i = 0; i < DGR_WELCOMING.Items.Count; i++)
			{
				DGR_WELCOMING.Items[i].Cells[2].Text = tool.FormatDate(DGR_WELCOMING.Items[i].Cells[2].Text, true);
			}
		}

		

		private void DGR_DAILY_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			DGR_DAILY.CurrentPageIndex = e.NewPageIndex;
			ViewDataDaily();
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
			this.DGR_WELCOMING.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.DGR_WELCOMING_PageIndexChanged);
			this.DGR_DAILY.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.DGR_DAILY_PageIndexChanged);

		}
		#endregion

		private void DGR_WELCOMING_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			DGR_WELCOMING.CurrentPageIndex = e.NewPageIndex;
			VewDataWelcoming();
		}

		protected void BTN_SAVE_Click(object sender, System.EventArgs e)
		{
			/*conn.QueryString = "select * from mas_cluster_supervision_welcoming_call where unit_code = '"+ Session["BranchID"].ToString() +"' ";
			conn.ExecuteQuery();
			if(conn.GetRowCount() == 0)
			{
				conn.QueryString = "insert into mas_cluster_supervision_welcoming_call (acc_number, cust_name, unit_code, distrik_code, cluster_code)" +
					"select acc_number, cust_name, unit_code, distrik_code, cluster_code from mas_upload_data where unit_code = '"+ Session["BranchID"].ToString() +"' ";
				conn.ExecuteQuery();
			}
			conn.QueryString = "update mas_cluster_supervision_welcoming_call set booking_date = "+ tool.ConvertDate(TXT_TGL_BOOKING1.Text, DDL_BLN_BOOKING1.SelectedValue, TXT_THN_BOOKING1.Text) +", " +
				"booking_date_to = "+ tool.ConvertDate(TXT_TGL_BOOKING2.Text, DDL_BLN_BOOKING2.SelectedValue, TXT_THN_BOOKING2.Text) +", pic_input_penyimpangan = '"+ Session["UserID"].ToString() +"' " + 
				"where unit_code = '"+ Session["BranchID"].ToString() +"' ";				
			conn.ExecuteQuery();*/
			for (int i = 0; i < DGR_WELCOMING.Items.Count; i++)
			{
				conn.QueryString = "exec MAS_CLUSTER_SUPERVISION_WELCOMING_UPDATE "+
					tool.ConvertDate(TXT_TGL_BOOKING1.Text, DDL_BLN_BOOKING1.SelectedValue, TXT_THN_BOOKING1.Text) +" , " +
					tool.ConvertDate(TXT_TGL_BOOKING2.Text, DDL_BLN_BOOKING2.SelectedValue, TXT_THN_BOOKING2.Text) +" , '" +
					Session["UserID"].ToString() +"', '" +
					Session["BranchID"].ToString() +"', '"+
					DGR_WELCOMING.Items[i].Cells[0].Text.Trim() + "', '"+
					DGR_WELCOMING.Items[i].Cells[1].Text.Trim() + "' ";					
				conn.ExecuteQuery();
			}			
			
			VewDataWelcoming(); 
		}

		protected void BTN_SEND_TO_CAO_Click(object sender, System.EventArgs e)
		{
			conn.QueryString = "update mas_cluster_supervision_welcoming_call set flag='1', sending_date=getdate() where unit_code = '"+ Session["BranchID"].ToString() +"' ";
			conn.ExecuteQuery();			
			Response.Redirect("../../../../Body.aspx?tc=" + Request.QueryString["tc"] + "&mc=" + Request.QueryString["mc"]);
		}

		
	}
}
