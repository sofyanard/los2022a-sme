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
using DMS.CuBESCore;
using DMS.DBConnection;

namespace SME.DCM
{
	/// <summary>
	/// Summary description for CollateralListData.
	/// </summary>
	public partial class CollateralListData : System.Web.UI.Page
	{
		protected Connection conn = new Connection(ConfigurationSettings.AppSettings["conn"]);
		protected Connection conn2 = new Connection(ConfigurationSettings.AppSettings["conn2"]);
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			conn = (Connection) Session["Connection"];

			if (!Logic.AllowAccess(Session["GroupID"].ToString(), Request.QueryString["mc"], conn))
				Response.Redirect("../Restricted.aspx");

			if (!IsPostBack)
			{
				fillWilayah();
				fillKelompok();
				fillUnit();
				fillRCO();
				if ((Request.QueryString["asgn"] == "1") || (Request.QueryString["asgn"] == "2"))
					ViewDataPending();
			}
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
			DDL_KELOMPOK.Items.Clear();
			DDL_KELOMPOK.Items.Add(new ListItem("-- PILIH --",""));
			conn.QueryString = "select bussunitid, bussunitdesc from rfbusinessunit order by bussunitid ";
			conn.ExecuteQuery();
			for (int i = 0; i < conn.GetRowCount(); i++)
			{
				DDL_KELOMPOK.Items.Add(new ListItem(conn.GetFieldValue(i,1),conn.GetFieldValue(i,0)));
			}
		}

		private void fillRCO()
		{
			DDL_RCO.Items.Clear();
			DDL_RCO.Items.Add(new ListItem("-- PILIH --",""));
			conn2.QueryString = "select distinct RCO, RCO from PAR_RCO";
			conn2.ExecuteQuery();
			for (int i = 0; i < conn2.GetRowCount(); i++)
			{
				DDL_RCO.Items.Add(new ListItem(conn2.GetFieldValue(i,1),conn2.GetFieldValue(i,0)));
			}	
		}

		private void fillUnit() 
		{
			DDL_UNIT.Items.Clear();
			DDL_UNIT.Items.Add(new ListItem("-- PILIH --",""));

			if (DDL_KELOMPOK.SelectedValue=="")
			{
				conn.QueryString = "select DEPT_CODE, DEPT_DESC from  rfdepartmentcode order by dept_desc";
			}
			else
			{
				conn.QueryString = "select DEPT_CODE, DEPT_DESC from  rfdepartmentcode where BUSSUNITID='"+DDL_KELOMPOK.SelectedValue+"'order by dept_desc";
			}

			conn.ExecuteQuery();
			for (int i = 0; i < conn.GetRowCount(); i++)
			{
				DDL_UNIT.Items.Add(new ListItem(conn.GetFieldValue(i,0) + " - " + conn.GetFieldValue(i,1),conn.GetFieldValue(i,0)));
			}	
		}

		private void ViewData()
		{
			conn.QueryString="select IDDQA from RFAREA where areaid = '" + DDL_WILAYAH.SelectedValue +"'";
			conn.ExecuteQuery();

			string wilayah		= conn.GetFieldValue("IDDQA");
			
			conn2.QueryString = "EXEC DCM_COLLATERAL_CORRECTION_VIEWLISTASSIGNMENT '" + 
				DDL_KELOMPOK.SelectedValue + "', '" +
				wilayah + "', '" +
				DDL_UNIT.SelectedValue + "', '" +
				DDL_RCO.SelectedValue + "'";
			conn2.ExecuteQuery();
			
			DataTable dt = new DataTable();
			dt = conn2.GetDataTable().Copy();
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
				LinkButton LbUpdate = (LinkButton) DatGrd.Items[i].Cells[10].FindControl("LB_UPDATE");
				if (DatGrd.Items[i].Cells[6].Text.Trim() == "2")
				{
					LbUpdate.Visible = true;
				}
				else
				{
					LbUpdate.Visible = false;
				}
			}
		}

		private void ViewDataPending()
		{
			conn2.QueryString = "EXEC DCM_COLLATERAL_CORRECTION_VIEWLISTASSIGNMENT2 '" + 
				Request.QueryString["asgn"]+ "', '" +
				Session["UserID"].ToString() + "'";
			conn2.ExecuteQuery();
			
			DataTable dt = new DataTable();
			dt = conn2.GetDataTable().Copy();
			DatGrd2.DataSource = dt;
			try 
			{
				DatGrd2.DataBind();
			} 
			catch 
			{
				DatGrd2.CurrentPageIndex = 0;
				DatGrd2.DataBind();
			}

			for (int i = 0; i < DatGrd2.Items.Count; i++)
			{
				LinkButton LbUpdate = (LinkButton) DatGrd2.Items[i].Cells[10].FindControl("LB_UPDATE2");
				if (DatGrd2.Items[i].Cells[6].Text.Trim() == "2")
				{
					LbUpdate.Visible = true;
				}
				else
				{
					LbUpdate.Visible = false;
				}
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
			this.DatGrd2.ItemCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.DatGrd2_ItemCommand);
			this.DatGrd2.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.DatGrd2_PageIndexChanged);

		}
		#endregion

		protected void DDL_KELOMPOK_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			fillUnit();
		}

		protected void BTN_FIND_Click(object sender, System.EventArgs e)
		{
			ViewData();
		}

		private void DatGrd_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			DatGrd.CurrentPageIndex = e.NewPageIndex;
			ViewData();
		}

		private void DatGrd_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			switch(((LinkButton)e.CommandSource).CommandName)
			{
				case "view":
					//Response.Redirect("CollateralDetailData.aspx?accno=" + e.Item.Cells[3].Text + "&colid=" + e.Item.Cells[0].Text + "&mc=" + Request.QueryString["mc"]);
					string link = e.Item.Cells[8].Text + "&mc=" + Request.QueryString["mc"];
					Response.Redirect(link);
					break;

				case "update":
					string colid = e.Item.Cells[0].Text.Trim();
					try
					{
						conn2.QueryString  = "EXEC DCM_COLLATERAL_CORRECTION_APPROVAL '" + 
							colid + "', '" + Session["UserID"].ToString() + "'";
						conn2.ExecuteNonQuery();

						ViewData();
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
				
				default:
					break;
			}
		}

		private void DatGrd2_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			DatGrd2.CurrentPageIndex = e.NewPageIndex;
			ViewDataPending();
		}

		private void DatGrd2_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			switch(((LinkButton)e.CommandSource).CommandName)
			{
				case "view":
					//Response.Redirect("CollateralDetailData.aspx?accno=" + e.Item.Cells[3].Text + "&colid=" + e.Item.Cells[0].Text + "&mc=" + Request.QueryString["mc"]);
					string link = e.Item.Cells[8].Text + "&mc=" + Request.QueryString["mc"];
					Response.Redirect(link);
					break;

				case "update":
					string colid = e.Item.Cells[0].Text.Trim();
					try
					{
						conn2.QueryString  = "EXEC DCM_COLLATERAL_CORRECTION_APPROVAL '" + 
							colid + "', '" + Session["UserID"].ToString() + "'";
						conn2.ExecuteNonQuery();

						ViewDataPending();
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
				
				default:
					break;
			}
		}
	}
}
