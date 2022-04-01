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
using Microsoft.VisualBasic;

namespace SME.Syndication.CustomerBasicInformation
{
	/// <summary>
	/// Summary description for CollateralInfo.
	/// </summary>
	public partial class CollateralInfo : System.Web.UI.Page
	{
		protected Tools tools = new Tools();
		protected Connection conn = new Connection(ConfigurationSettings.AppSettings["conn"]);
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			ViewMenu();

			if(!IsPostBack)
			{
				FillDDLJaminan();
				FillDDLDoc();
				FillDDLPengikatan();
			}
			FillDataGrid();
		}

		private void ViewMenu()
		{
			Menu.Controls.Clear();
			try 
			{
				conn.QueryString = "SELECT * FROM SCREENMENU WHERE MENUCODE = '" + Request.QueryString["mc"] + "'";
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
							strtemp = "&curef=" + Request.QueryString["curef"] + "&cif=" + Request.QueryString["cif"] + "&exist=" + Request.QueryString["exist"];
						else	
							strtemp = "&mc=" + Request.QueryString["mc"]+ "&curef=" + Request.QueryString["curef"] + "&cif=" + Request.QueryString["cif"] + "&exist=" + Request.QueryString["exist"];
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

		private void FillDDLJaminan()
		{
			DDL_JENIS_JAMINAN.Items.Clear();
			DDL_JENIS_JAMINAN.Items.Add(new ListItem("--Select--", ""));

			conn.QueryString = "SELECT * FROM VW_SDC_DDLJAMINAN ORDER BY COLTYPEDESC";
			conn.ExecuteQuery();
			for(int i=0; i < conn.GetRowCount(); i++)
			{
				DDL_JENIS_JAMINAN.Items.Add(new ListItem(conn.GetFieldValue(i,1), conn.GetFieldValue(i,0)));
			}
		}

		private void FillDDLDoc()
		{
			DDL_DOC_TYPE.Items.Clear();
			DDL_DOC_TYPE.Items.Add(new ListItem("--Select--", ""));

			conn.QueryString = "SELECT * FROM VW_SDC_DDLDOCUMENT ORDER BY CERTTYPEDESC";
			conn.ExecuteQuery();
			for(int i=0; i < conn.GetRowCount(); i++)
			{
				DDL_DOC_TYPE.Items.Add(new ListItem(conn.GetFieldValue(i,1), conn.GetFieldValue(i,0)));
			}
		}

		private void FillDDLPengikatan()
		{
			DDL_JENIS_PENGIKATAN.Items.Clear();
			DDL_JENIS_PENGIKATAN.Items.Add(new ListItem("--Select--", ""));

			conn.QueryString = "SELECT * FROM VW_SDC_DDLPENGIKATAN ORDER BY IKATDESC";
			conn.ExecuteQuery();
			for(int i=0; i < conn.GetRowCount(); i++)
			{
				DDL_JENIS_PENGIKATAN.Items.Add(new ListItem(conn.GetFieldValue(i,1), conn.GetFieldValue(i,0)));
			}
		}

		private void FillDataGrid()
		{
			conn.QueryString = "SELECT * FROM VW_SDC_COLLATERAL_INFO WHERE CU_REF = '" + Request.QueryString["curef"] + "'";
			BindData(DATA_GRID.ID.ToString(), conn.QueryString);
		}

		private void BindData(string dataGridName, string strconn)
		{
			if(strconn != "")
			{
				conn.QueryString = strconn;
				conn.ExecuteQuery();

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

				for (int i = 0; i < dg.Items.Count; i++)
				{
					dg.Items[i].Cells[6].Text = tools.MoneyFormat(dg.Items[i].Cells[6].Text);
				} 

				conn.ClearData();
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
			this.DATA_GRID.ItemCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.DATA_GRID_ItemCommand);
			this.DATA_GRID.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.DATA_GRID_PageIndexChanged);

		}
		#endregion

		protected void BTN_SAVE_Click(object sender, System.EventArgs e)
		{
			try
			{
				conn.QueryString = "EXEC SDC_COLLATERAL_INFO_INSERT '" +
									LBL_SEQ.Text + "','" +
									Session["UserID"].ToString() + "','" +
									Request.QueryString["curef"] + "','" +
									Request.QueryString["cif"] + "','" +
									TXT_NAMA_JAMINAN.Text + "','" +
									DDL_JENIS_JAMINAN.SelectedValue + "','" +
									DDL_DOC_TYPE.SelectedValue + "','" +
									TXT_NO_DOC.Text + "','" +
									TXT_ALAMAT_AGUNAN.Text + "','" +
									TXT_NILAI_AGUNAN.Text.Replace(",",".") + "','" +
									TXT_PEMBERI_JAMINAN.Text + "','" +
									TXT_PENERIMA_JAMINAN.Text + "','" +
									TXT_LUAS.Text + "','" +
									DDL_JENIS_PENGIKATAN.SelectedValue + "','" +
									TXT_NILAI_PENGIKATAN.Text.Replace(",",".") + "','" +
									TXT_KET_PENGIKATAN.Text + "','" +
									RDO_ASURANSI.SelectedValue + "'";
				conn.ExecuteQuery();

				ClearData();
				FillDataGrid();
			}

			catch(Exception ex)
			{
				string errmsg = ex.Message.Replace("'","");
				if (errmsg.IndexOf("Last Query:") > 0)
					errmsg = errmsg.Substring(0, errmsg.IndexOf("Last Query:"));
				GlobalTools.popMessage(this, errmsg);
				return;
			}
		}

		protected void BTN_CLEAR_Click(object sender, System.EventArgs e)
		{
			ClearData();
		}

		private void ClearData()
		{
			LBL_SEQ.Text						= "";
			TXT_NAMA_JAMINAN.Text				= "";
			DDL_JENIS_JAMINAN.SelectedValue		= "";
			DDL_DOC_TYPE.SelectedValue			= "";
			TXT_NO_DOC.Text						= "";
			TXT_ALAMAT_AGUNAN.Text				= "";
			TXT_NILAI_AGUNAN.Text				= "";
			TXT_PEMBERI_JAMINAN.Text			= "";
			TXT_PENERIMA_JAMINAN.Text			= "";
			TXT_LUAS.Text						= "";
			DDL_JENIS_PENGIKATAN.SelectedValue	= "";
			TXT_NILAI_PENGIKATAN.Text			= "";
			TXT_KET_PENGIKATAN.Text				= "";
			RDO_ASURANSI.SelectedValue			= null;
		}

		private void DATA_GRID_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			DATA_GRID.CurrentPageIndex = e.NewPageIndex;
			FillDataGrid();
		}

		private void DATA_GRID_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			switch(((LinkButton)e.CommandSource).CommandName)
			{
				case "edit":
					conn.QueryString = "SELECT * FROM SDC_COLLATERAL_INFO WHERE SEQ = '" + e.Item.Cells[0].Text.ToString() + "' AND CU_REF = '" + Request.QueryString["curef"] + "'";
					conn.ExecuteQuery();

					LBL_SEQ.Text						= conn.GetFieldValue("SEQ").ToString().Replace("&nbsp;","");
					TXT_NAMA_JAMINAN.Text				= conn.GetFieldValue("COLL_DESC").ToString().Replace("&nbsp;","");
					DDL_JENIS_JAMINAN.SelectedValue		= conn.GetFieldValue("COLL_TYPE").ToString();
					DDL_DOC_TYPE.SelectedValue			= conn.GetFieldValue("DOC_TYPE").ToString();
					TXT_NO_DOC.Text						= conn.GetFieldValue("NO_DOC").ToString().Replace("&nbsp;","");
					TXT_ALAMAT_AGUNAN.Text				= conn.GetFieldValue("COLL_ADD").ToString().Replace("&nbsp;","");
					TXT_NILAI_AGUNAN.Text				= conn.GetFieldValue("COLL_VAL").ToString().Replace("&nbsp;","");
					TXT_PEMBERI_JAMINAN.Text			= conn.GetFieldValue("GUARANTOR").ToString().Replace("&nbsp;","");
					TXT_PENERIMA_JAMINAN.Text			= conn.GetFieldValue("GUARANTEE").ToString().Replace("&nbsp;","");
					TXT_LUAS.Text						= conn.GetFieldValue("AREA_UNIT").ToString().Replace("&nbsp;","");
					DDL_JENIS_PENGIKATAN.SelectedValue	= conn.GetFieldValue("PENGIKATAN_TYPE").ToString();
					TXT_NILAI_PENGIKATAN.Text			= conn.GetFieldValue("PENGIKATAN_VAL").ToString().Replace("&nbsp;","");
					TXT_KET_PENGIKATAN.Text				= conn.GetFieldValue("REMARK").ToString().Replace("&nbsp;","");

					if(conn.GetFieldValue("INSURANCE") != "" && conn.GetFieldValue("INSURANCE") != null)
					{
						RDO_ASURANSI.SelectedValue	= conn.GetFieldValue("INSURANCE");
					}
					break;

				case "delete":
					conn.QueryString = "DELETE SDC_COLLATERAL_INFO WHERE SEQ = '" + e.Item.Cells[0].Text.ToString() + "' AND CU_REF = '" + Request.QueryString["curef"] + "'";
					conn.ExecuteQuery();

					FillDataGrid();
					break;
			}
		}

		protected void BTN_BACK_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			Response.Redirect("../CustomerList.aspx?mc=" + Request.QueryString["mc"]);
		}
	}
}
