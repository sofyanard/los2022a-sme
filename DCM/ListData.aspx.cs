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
	/// Summary description for ListData.
	/// </summary>
	public partial class ListData : System.Web.UI.Page
	{
		protected Connection conn2 = new Connection(ConfigurationSettings.AppSettings["conn2"]);
		protected Connection conn = new Connection(ConfigurationSettings.AppSettings["conn"]);
		protected Tools tools = new Tools();
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			if(!IsPostBack)
			{
				if(Request.QueryString["msg"]!="" && Request.QueryString["msg"] != null)
				{
					GlobalTools.popMessage(this, Request.QueryString["msg"]);
				}

				fillWilayah();
				fillKelompok();
				DDL_UNIT_KERJA.Items.Add(new ListItem("-- PILIH --",""));
				DDL_CABANG.Items.Add(new ListItem("-- PILIH --",""));
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
			this.DGR_DATA_DANA_LIST.ItemCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.DGR_DATA_DANA_LIST_ItemCommand);
			this.DGR_DATA_DANA_LIST.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.DGR_DATA_DANA_LIST_PageIndexChanged);

		}
		#endregion

		private void fillWilayah()
		{
			DDL_WILAYAH.Items.Clear();
			DDL_WILAYAH.Items.Add(new ListItem("-- PILIH --",""));
			conn.QueryString = "select AREAID, AREANAME from rfarea where active ='1'";
			conn.ExecuteQuery();
			for (int i = 0; i < conn.GetRowCount(); i++)
			{
				DDL_WILAYAH.Items.Add(new ListItem(conn.GetFieldValue(i,1),conn.GetFieldValue(i,0)));
			}	
		}

		private void fillKelompok()
		{
			DDL_SEGMENT.Items.Clear();
			DDL_SEGMENT.Items.Add(new ListItem("-- PILIH --",""));
			conn.QueryString = "select bussunitid, bussunitdesc from rfbusinessunit order by bussunitid ";
			conn.ExecuteQuery();
			for (int i = 0; i < conn.GetRowCount(); i++)
			{
				DDL_SEGMENT.Items.Add(new ListItem(conn.GetFieldValue(i,1),conn.GetFieldValue(i,0)));
			}
		}

		private void fillUnit() 
		{
			DDL_UNIT_KERJA.Items.Clear();
			DDL_UNIT_KERJA.Items.Add(new ListItem("-- PILIH --",""));

			//Unit Kerja
			if (DDL_SEGMENT.SelectedValue=="")
			{
				conn.QueryString = "select DEPT_CODE, DEPT_DESC from  rfdepartmentcode order by dept_desc";
			}
			else
			{
				conn.QueryString = "select DEPT_CODE, DEPT_DESC from  rfdepartmentcode where BUSSUNITID='"+DDL_SEGMENT.SelectedValue+"'order by dept_desc";
			}

			conn.ExecuteQuery();
			for (int i = 0; i < conn.GetRowCount(); i++)
			{
				DDL_UNIT_KERJA.Items.Add(new ListItem(conn.GetFieldValue(i,0) + " - " + conn.GetFieldValue(i,1),conn.GetFieldValue(i,0)));
			}		
		
			//Area
			if (DDL_WILAYAH.SelectedValue=="")
			{
				conn2.QueryString = "select hub_nm, hub_nm from par_hub";
			}
			else
			{
				conn.QueryString="select IDDQA from RFAREA where areaid = '" + DDL_WILAYAH.SelectedValue +"'";
				conn.ExecuteQuery();
				conn2.QueryString = "select hub_nm, hub_nm from par_hub where wilayah_id = '"+ conn.GetFieldValue("IDDQA")+"'";
			}
			conn2.ExecuteQuery();
			for (int i = 0; i < conn2.GetRowCount(); i++)
			{
				DDL_UNIT_KERJA.Items.Add(new ListItem(conn2.GetFieldValue(i,1),conn2.GetFieldValue(i,0)));
			}	
		}

		private void fillbranch()
		{
			DDL_CABANG.Items.Clear();
			DDL_CABANG.Items.Add(new ListItem("-- PILIH --",""));

			if (DDL_UNIT_KERJA.SelectedValue=="")
			{
				conn.QueryString = "select BRANCH_CODE, BRANCH_NAME from rfbranch where BRANCH_TYPE='5' and BRANCH_CODE not in ('BMP01','BMP02','BMP07','BMP08','BMP09','BMP10','BMP11','BMP12','BMP13','BMP15','BMP18','BMP20','BMP21','BMP22','BMP29','BMP30','BMP31','BMP36','CASH','CLPC0','CLPC1','CLPC2','CLPC3','CLPC4','CLPC5','CLPC6','CLPC7','CLPC8','COR10','COR11','COR12','HQ','KANWIL1','KANWIL10','KANWIL2','KANWIL3','KANWIL4','KANWIL6','KANWIL7','KANWIL8','KANWIL9','PSP01','RCCA','RCCB','RCO I','RCO II','RCO III','RCO IV','RCO IX','RCO V','RCO VI','RCO VII','RCO VIII','RCO1','RCO11','RCO2','RCO3','RCO4','RCO5','RCO6','RCO7','RCO8','rrm1','RTM01','RTM06','RTM07','RTM08','RTM101')";
			}
			else
			{
				conn.QueryString = "select BRANCH_CODE, BRANCH_NAME from rfbranch where left(branch_code,3) in (select HUB_ID from DQA..PAR_HUB where HUB_NM = '" + DDL_UNIT_KERJA.SelectedValue + "')";
			}

			conn.ExecuteQuery();
			for (int i = 0; i < conn.GetRowCount(); i++)
			{
				DDL_CABANG.Items.Add(new ListItem(conn.GetFieldValue(i,0) + " - " + conn.GetFieldValue(i,1),conn.GetFieldValue(i,0)));
			}	
		}

		protected void BTN_LIHAT_Click(object sender, System.EventArgs e)
		{
			DGR_DATA_DANA_LIST.CurrentPageIndex = 0;
			SearchData();
		}

		private void SearchData()
		{
			conn.QueryString="select IDDQA from RFAREA where areaid = '" + DDL_WILAYAH.SelectedValue +"'";
			conn.ExecuteQuery();

			conn2.QueryString = "EXEC DCM_DATA_DANA_SEARCH '" + conn.GetFieldValue("IDDQA") + "', '" +
				DDL_UNIT_KERJA.SelectedValue + "', '" + DDL_SEGMENT.SelectedValue + "', '" +
				DDL_CABANG.SelectedValue + "'";
			conn2.ExecuteQuery(100000);
			FillGrid();
		}

		private void FillGrid()
		{
			DataTable dt = new DataTable();
			dt = conn2.GetDataTable().Copy();
			DGR_DATA_DANA_LIST.DataSource = dt;
			try 
			{
				DGR_DATA_DANA_LIST.DataBind();
			} 
			catch 
			{
				DGR_DATA_DANA_LIST.CurrentPageIndex = 0;
				DGR_DATA_DANA_LIST.DataBind();
			}

			LinkButton lnk;

			for (int i = 0; i < DGR_DATA_DANA_LIST.Items.Count; i++)
			{
				conn2.QueryString = "select * from ec_dana where ac_act#='" + DGR_DATA_DANA_LIST.Items[i].Cells[1].Text.Trim() + "' and flag='0'";
				conn2.ExecuteQuery();

				if (conn2.GetRowCount() > 0)	
				{
					lnk = (LinkButton)DGR_DATA_DANA_LIST.Items[i].Cells[6].FindControl("LNK_UPDATE");
					lnk.Visible = true;
				}
				else
				{
					lnk = (LinkButton)DGR_DATA_DANA_LIST.Items[i].Cells[6].FindControl("LNK_UPDATE");
					lnk.Visible = false;
				}
			}

			for (int i = 0; i < DGR_DATA_DANA_LIST.Items.Count; i++)
			{
				conn2.QueryString = "select * from ec_dana where ac_act#='" + DGR_DATA_DANA_LIST.Items[i].Cells[1].Text.Trim() + "' and flag='2'";
				conn2.ExecuteQuery();

				if (conn2.GetRowCount() > 0)	
				{
					lnk = (LinkButton)DGR_DATA_DANA_LIST.Items[i].Cells[5].FindControl("LNK_VIEW");
					lnk.Visible = false;
				}
				else
				{
					lnk = (LinkButton)DGR_DATA_DANA_LIST.Items[i].Cells[5].FindControl("LNK_VIEW");
					lnk.Visible = true;
				}
			}
		}

		protected void DDL_SEGMENT_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			fillUnit();
		}

		protected void DDL_WILAYAH_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			fillUnit();
		}

		protected void DDL_UNIT_KERJA_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if (DDL_UNIT_KERJA.SelectedValue=="")
				return;
			else 
			{
				conn.QueryString = "select DEPT_CODE, DEPT_DESC from rfdepartmentcode where dept_code='" + DDL_UNIT_KERJA.SelectedValue + "'";
				conn.ExecuteQuery();
				
				if(conn.GetRowCount()>0)
				{
					DDL_CABANG.Enabled = false;
					DDL_CABANG.SelectedValue = "";
				}
				else
				{
					DDL_CABANG.Enabled = true;
					fillbranch();
				}
			}
		}

		private void DGR_DATA_DANA_LIST_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			
			switch (((LinkButton)e.CommandSource).CommandName)
			{
				case "View":	
					if(e.Item.Cells[4].Text == "Tabungan")
						Response.Redirect("DetailDataSaving.aspx?acc=" + e.Item.Cells[1].Text);
					else if (e.Item.Cells[4].Text == "Giro")
						Response.Redirect("DetailDataGiro.aspx?acc=" + e.Item.Cells[1].Text);
					else if (e.Item.Cells[4].Text == "Deposito")
						Response.Redirect("DetailDataDeposito.aspx?acc=" + e.Item.Cells[1].Text);
					break;
				case "Update":
					try
					{
						conn2.QueryString = "EXEC DCM_DATA_DANA_UPDATE '" + e.Item.Cells[1].Text.Trim() +
							"', '1'";
						conn2.ExecuteQuery();
						GlobalTools.popMessage(this, "Data masuk ke list pending approval");
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

		private void DGR_DATA_DANA_LIST_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			DGR_DATA_DANA_LIST.CurrentPageIndex = e.NewPageIndex;
			SearchData();
		}
	}
}
