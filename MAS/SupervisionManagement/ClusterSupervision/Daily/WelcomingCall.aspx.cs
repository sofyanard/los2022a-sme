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
	/// Summary description for WelcomingCall.
	/// </summary>
	public partial class WelcomingCall : System.Web.UI.Page
	{
		protected Tools tool = new Tools();
		protected Connection conn = new Connection(ConfigurationSettings.AppSettings["conn"]);
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			ViewMenu();			
			
			if(!IsPostBack)
			{
				ViewData();	
				/*conn.QueryString = "select * from mas_cluster_supervision_welcoming_call where unit_code = '"+ Session["BranchID"].ToString() +"' and pic_input_penyimpangan = '"+ Session["UserID"].ToString() +"'";
				conn.ExecuteQuery();
				if (conn.GetFieldValue("flag") == "1")
				{
					BTN_SAVE.Enabled = false;
				}*/			
			}
		}

		private void ViewData()
		{
			conn.QueryString = "select * from VW_MAS_WELCOMING_CALL_DETIL where unit_code='"+ Session["BranchID"].ToString() +"' ";
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
			for (int i=0;i<DatGrd.Items.Count;i++)
			{
				DropDownList DDL_INDIKASI = (DropDownList) DatGrd.Items[i].Cells[4].FindControl("DDL_INDIKASI");
				DropDownList DDL_KET_NOHP = (DropDownList) DatGrd.Items[i].Cells[6].FindControl("DDL_KET_NOHP");
				TextBox TXT_KET_PENYIMPANGAN = (TextBox) DatGrd.Items[i].Cells[5].FindControl("TXT_KET_PENYIMPANGAN");

				GlobalTools.fillRefList(DDL_INDIKASI, "Select code, description from mas_rf_penyimpangan where status=1" , false, conn);
				GlobalTools.fillRefList(DDL_KET_NOHP, "Select code, description from mas_rf_ket_hp where status=1" , false, conn);

				conn.QueryString = "select * from mas_cluster_supervision_welcoming_call where acc_number= '"+DatGrd.Items[i].Cells[0].Text.Trim()+"' ";
				conn.ExecuteQuery();

				TXT_KET_PENYIMPANGAN.Text = conn.GetFieldValue("ket_penyimpangan");
				try{DDL_INDIKASI.SelectedValue = conn.GetFieldValue("indikasi_penyimpangan_type");}
				catch{DDL_INDIKASI.SelectedValue = "";}
				try{DDL_KET_NOHP.SelectedValue = conn.GetFieldValue("ket_no_hp");}
				catch{DDL_KET_NOHP.SelectedValue = "";}							
			}
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
			this.DatGrd.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.DatGrd_PageIndexChanged);

		}
		#endregion

		protected void BTN_SAVE_Click(object sender, System.EventArgs e)
		{
			conn.QueryString = "select * from VW_MAS_WELCOMING_CALL_CLUSTER_ACTIVITIES where unit_code = '"+ Session["BranchID"].ToString() +"' and booking_date is null";
			conn.ExecuteQuery();
			if (conn.GetRowCount() > 1)
			{
				GlobalTools.popMessage(this, "Isi terlebih dahulu Periode Booking pada halaman Main!");
				return;
			}
			for (int i = 0; i < DatGrd.Items.Count; i++)
			{				
				DropDownList DDL_INDIKASI = (DropDownList) DatGrd.Items[i].Cells[4].FindControl("DDL_INDIKASI");
				DropDownList DDL_KET_NOHP = (DropDownList) DatGrd.Items[i].Cells[6].FindControl("DDL_KET_NOHP");
				TextBox TXT_KET_PENYIMPANGAN = (TextBox) DatGrd.Items[i].Cells[5].FindControl("TXT_KET_PENYIMPANGAN");		
					
				conn.QueryString = "exec MAS_CLUSTER_SUPERVISION_WELCOMING_INSERT '" +	
					Session["UserID"].ToString() + "' , '" + 
					DatGrd.Items[i].Cells[0].Text.Trim() + "' , '" + 
					DatGrd.Items[i].Cells[1].Text.Trim() + "' , '" + 
					DatGrd.Items[i].Cells[2].Text.Trim() + "' , '" + 
					DatGrd.Items[i].Cells[3].Text.Trim() + "' , '" + 
					DDL_INDIKASI.SelectedValue + "' , '" + 
					TXT_KET_PENYIMPANGAN.Text + "' , '" + 
					DDL_KET_NOHP.SelectedValue + "' ";
				conn.ExecuteQuery();				
			}
		}

		private void DatGrd_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			DatGrd.CurrentPageIndex = e.NewPageIndex;			

			if (TXT_ACC_NUM.Text != "" && TXT_CUST.Text== "")
			{
				conn.QueryString = "select * from VW_MAS_WELCOMING_CALL_DETIL " + 
					"WHERE a.acc_number = '"+ TXT_ACC_NUM.Text +"' ";
				conn.ExecuteQuery();
				FillGrid();
			}

			if (TXT_CUST.Text!= "" && TXT_ACC_NUM.Text == "")
			{
				conn.QueryString = "select * from VW_MAS_WELCOMING_CALL_DETIL " + 
					"WHERE a.cust_name like '%"+ TXT_CUST.Text +"%' ";
				conn.ExecuteQuery();
				FillGrid();
			}
			
			else
			{
				ViewData();
			}
		}

		protected void BTN_SEARCH_ACC_NUMBER_Click(object sender, System.EventArgs e)
		{
			SearchDataAccNum();
		}

		private void SearchDataAccNum()
		{
			if (TXT_ACC_NUM.Text!= "")
			{
				conn.QueryString = "select * from  VW_MAS_WELCOMING_CALL_DETIL where unit_code='"+ Session["BranchID"].ToString() +"' and " + 
					"acc_number = '"+ TXT_ACC_NUM.Text +"' ";
				conn.ExecuteQuery();
			}
			else
			{
				conn.QueryString = "select * from  VW_MAS_WELCOMING_CALL_DETIL where unit_code='"+ Session["BranchID"].ToString() +"'  ";
				conn.ExecuteQuery();
			}
			FillGrid();
		}

		protected void BTN_SEARCH_CUST_Click(object sender, System.EventArgs e)
		{
			SearchCust();
		}

		private void SearchCust()
		{
			if (TXT_CUST.Text!= "")
			{
				conn.QueryString = "select * from VW_MAS_WELCOMING_CALL_DETIL where unit_code='"+ Session["BranchID"].ToString() +"' and " + 
					"cust_name like '%"+ TXT_CUST.Text +"%' ";
				conn.ExecuteQuery();
			}
			else
			{
				conn.QueryString = "select * from VW_MAS_WELCOMING_CALL_DETIL where unit_code='"+ Session["BranchID"].ToString() +"'";
				conn.ExecuteQuery();
			}
			FillGrid();
		}
	}
}
