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
	/// Summary description for CifListData.
	/// </summary>
	public partial class CifListData : System.Web.UI.Page
	{
		protected Connection conn;
		protected Connection conn2 = new Connection(ConfigurationSettings.AppSettings["conn2"]);

		protected string isCabang = "N";
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			conn = (Connection) Session["Connection"];

			if (!IsPostBack)
			{
				fillWilayah();
				fillKelompok();				
				//fillBranch();
				fillCabang();
				fillUnit();
				
				/*conn2.QueryString = "select NO_CIF as CIFNO, NM_NASABAH as SNAME, WILAYAH_ID, WILAYAH_NM, NAMA_HUB, KD_CABANG as BC," +
					"NM_CAB as NAMA_CAB, BUC_Rek_eMAS as BUC_EMAS, BUC_Rek_SPM as BUC_SPM, STATUS_CIF as STATUS_DATA, ERROR_MSG from CIF_DANA where error_msg='error'";
				*/
				conn2.QueryString = "SELECT * FROM VW_CIF_LIST_DATA ORDER BY SNAME";
				conn2.ExecuteQuery(10000);
				FillGrid();
			}		
			//BindData("DGR_CIF_LIST", "");			
		}

		

		private void isCabangFunction()
		{
			conn.QueryString = "EXEC ISCABANG '" + Session["userid"] + "'";
			conn.ExecuteQuery();
			FillGrid();
			//isCabang = conn.GetFieldValue();
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
			this.DGR_CIF_LIST.ItemCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.DGR_CIF_LIST_ItemCommand);
			this.DGR_CIF_LIST.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.DGR_CIF_LIST_PageIndexChanged);

		}
		#endregion

		private void DGR_CIF_LIST_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			switch (((LinkButton)e.CommandSource).CommandName)
			{
				case "View":	
					Response.Redirect("CifGeneralData.aspx?sta=exist&cifno=" + e.Item.Cells[2].Text + "&tc=" + Request.QueryString["tc"] + "&mc=DCM0101" + "&from_appr=0" );
					
					break;

				case "update_status":
					string cifno = e.Item.Cells[2].Text.Trim();
					try
					{
						conn2.QueryString  = " exec CIF_FLAG_UPDATE '" + 
							cifno + "', '1' ";
						conn2.ExecuteNonQuery();

						conn2.QueryString = "SELECT * FROM VW_CIF_LIST_DATA ORDER BY SNAME";
						conn2.ExecuteQuery(10000);
						FillGrid();						
					}
					catch (Exception ex)
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

		/*private void BindData(string dataGridName, string strconn)
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
		}*/

		private void FillGrid()
		{
			DataTable dt = new DataTable();
			dt = conn2.GetDataTable().Copy();
			DGR_CIF_LIST.DataSource = dt;
			try 
			{
				DGR_CIF_LIST.DataBind();
			} 
			catch 
			{
				DGR_CIF_LIST.CurrentPageIndex = 0;
				DGR_CIF_LIST.DataBind();
			}

			for (int i = 0; i < DGR_CIF_LIST.Items.Count; i++)
			{
				string flag_pengurus, flag_keuangan, flag_ec;
				LinkButton LbUpdate = (LinkButton) DGR_CIF_LIST.Items[i].Cells[6].FindControl("LB_UPDATE");
				conn2.QueryString = "select * from cif_data_pengurus where cifno = '"+DGR_CIF_LIST.Items[i].Cells[2].Text.Trim()+"' ";
				conn2.ExecuteQuery();
				flag_pengurus = conn2.GetFieldValue("flag");

				conn2.QueryString = "select * from cif_data_keuangan where cifno = '"+DGR_CIF_LIST.Items[i].Cells[2].Text.Trim()+"' ";
				conn2.ExecuteQuery();
				flag_keuangan = conn2.GetFieldValue("flag");

				conn2.QueryString = "select * from ec_cif where ci_cif# = '"+DGR_CIF_LIST.Items[i].Cells[2].Text.Trim()+"' ";
				conn2.ExecuteQuery();
				flag_ec = conn2.GetFieldValue("flag");

				if (flag_pengurus=="0" || flag_keuangan=="0" || flag_ec=="0")
				{
					LbUpdate.Visible = true;
				}
				else
				{
					LbUpdate.Visible = false;
				}

				/*if (conn2.GetRowCount() > 0)
				{
					LbUpdate.Visible = true;
				}

				conn2.QueryString = "select * from cif_data_keuangan where cifno = '"+DGR_CIF_LIST.Items[i].Cells[2].Text.Trim()+"' ";
				conn2.ExecuteQuery();
				if (conn2.GetRowCount() > 0)
				{
					LbUpdate.Visible = true;
				}

				conn2.QueryString = "select * from ec_cif where ci_cif# = '"+DGR_CIF_LIST.Items[i].Cells[2].Text.Trim()+"' ";
				conn2.ExecuteQuery();
				if (conn2.GetRowCount() > 0)
				{
					LbUpdate.Visible = true;
				}*/
								
			}
		}

		protected void BTN_FIND_Click(object sender, System.EventArgs e)
		{
			DGR_CIF_LIST.CurrentPageIndex = 0;
			SearchData();
		}

		private void SearchData()
		{
			conn.QueryString="select IDDQA from RFAREA where areaid = '" + DDL_WILAYAH.SelectedValue +"'";
			conn.ExecuteQuery();
			string wilayah;
			wilayah = conn.GetFieldValue("IDDQA");
			conn2.QueryString = "exec DQA_CIF_LIST_DANA2 '" +
			DDL_SEGMENT.SelectedValue +"', '" +
			//DDL_WILAYAH.SelectedValue +"', '" +
			wilayah +"', '" +
			DDL_UNIT_KERJA.SelectedValue +"', '" +
			DDL_CABANG.SelectedValue +"' ";
			conn2.ExecuteQuery(10000);
			FillGrid();
		}

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

		private void fillBranch()
		{
			DDL_CABANG.Items.Clear();
			DDL_CABANG.Items.Add(new ListItem("-- PILIH --",""));

			conn.QueryString = "select branch_code, branch_name from rfbranch order by branch_name";
			conn.ExecuteQuery();

			for (int i = 0; i < conn.GetRowCount(); i++)
			{
				DDL_CABANG.Items.Add(new ListItem(conn.GetFieldValue("branch_code") + " - " + conn.GetFieldValue("branch_name"), conn.GetFieldValue("branch_code")));
			}
		}

		/*private void fillArea() 
		{
			DDL_AREA.Items.Clear();
			DDL_AREA.Items.Add(new ListItem("-- PILIH --",""));

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
				DDL_AREA.Items.Add(new ListItem(conn2.GetFieldValue(i,1),conn2.GetFieldValue(i,0)));
			}			
		}*/

		private void fillCabang()
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

		private void DGR_CIF_LIST_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			DGR_CIF_LIST.CurrentPageIndex = e.NewPageIndex;
			conn2.QueryString = "SELECT * FROM VW_CIF_LIST_DATA ORDER BY SNAME";
			conn2.ExecuteQuery(10000);
			FillGrid();
			//SearchData();
		}

		protected void DDL_SEGMENT_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			fillUnit();
		}

		protected void DDL_WILAYAH_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			//fillArea();
			fillUnit();
		}

		protected void DDL_CABANG_SelectedIndexChanged(object sender, System.EventArgs e)
		{
		
		}

		protected void DDL_AREA_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			fillCabang();
		}
		
	}
}
