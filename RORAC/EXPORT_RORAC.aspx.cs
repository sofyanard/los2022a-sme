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
using System.IO;
using System.Diagnostics;
using Microsoft.VisualBasic;
using DMS.CuBESCore;
using DMS.DBConnection;

namespace SME.RORAC
{
	/// <summary>
	/// Summary description for EXPORT_RORAC.
	/// </summary>
	public partial class EXPORT_RORAC : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.DataGrid DatGrd;
		protected Connection conn;
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			conn = (Connection) Session["Connection"];

			_ddlRegion.SelectedIndexChanged += new EventHandler(_ddlRegion_SelectedIndexChanged);
			_ddlCBC.SelectedIndexChanged += new EventHandler(_ddlCBC_SelectedIndexChanged);
			_ddlBranch.SelectedIndexChanged += new EventHandler(_ddlBranch_SelectedIndexChanged);

			if(!IsPostBack)
			{
				_ddlRegion.Items.Add(new ListItem("-", "-1"));
				_ddlBisnisUnit.Items.Add(new ListItem("-", "-1"));
				_ddlCBC.Items.Add(new ListItem("-", "-1"));
				_ddlBranch.Items.Add(new ListItem("-", "-1"));
				_ddlRM.Items.Add(new ListItem("-", "-1"));

				conn.QueryString = "select BUSSUNITID, BUSSUNITDESC from VW_RORAC_BISNISUNIT";
				conn.ExecuteQuery();
				for (int i=0; i< conn.GetRowCount(); i++)
					_ddlBisnisUnit.Items.Add(new ListItem(conn.GetFieldValue(i, 1), conn.GetFieldValue(i, 0)));

				conn.QueryString = "select AREAID, AREANAME from VW_RORAC_REGION";
				conn.ExecuteQuery();
				for (int i=0; i< conn.GetRowCount(); i++)
					_ddlRegion.Items.Add(new ListItem(conn.GetFieldValue(i, 1), conn.GetFieldValue(i, 0)));	

				conn.QueryString = "EXEC RORAC_CBC '" + _ddlRegion.SelectedValue.ToString() + "'";
				conn.ExecuteQuery();
				for (int i=0; i< conn.GetRowCount(); i++)
					_ddlCBC.Items.Add(new ListItem(conn.GetFieldValue(i, 1), conn.GetFieldValue(i, 0)));

				conn.QueryString = "EXEC RORAC_BRANCH '" + _ddlCBC.SelectedValue.ToString() + "'";
				conn.ExecuteQuery();
				for (int i=0; i< conn.GetRowCount(); i++)
					_ddlBranch.Items.Add(new ListItem(conn.GetFieldValue(i, 1), conn.GetFieldValue(i, 0)));

				conn.QueryString = "EXEC RORAC_RM '" + _ddlBranch.SelectedValue.ToString() + "'";
				conn.ExecuteQuery();
				for (int i=0; i< conn.GetRowCount(); i++)
					_ddlRM.Items.Add(new ListItem(conn.GetFieldValue(i, 1), conn.GetFieldValue(i, 0)));
			}

			//FillGrid();
		}

//		private void FillGrid()
//		{
//			DataTable dt = new DataTable();
//			dt = conn.GetDataTable().Copy();
//			DatGrd.DataSource = dt;
//			try 
//			{
//				DatGrd.DataBind();
//			} 
//			catch 
//			{
//				DatGrd.CurrentPageIndex = 0;
//				DatGrd.DataBind();
//			}
//		}

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

		}
		#endregion

		protected void _ddlRegion_SelectedIndexChanged(object sender, EventArgs e)
		{
			if(_ddlRegion.SelectedValue.ToString() != "-1")
			{
				//isi CBC
				_ddlRM.Items.Clear();
				_ddlRM.Items.Add(new ListItem("-", "-1"));
				_ddlCBC.Items.Clear();
				_ddlCBC.Items.Add(new ListItem("-", "-1"));
				_ddlBranch.Items.Clear();
				_ddlBranch.Items.Add(new ListItem("-", "-1"));
				conn.QueryString = "EXEC RORAC_CBC '" + _ddlRegion.SelectedValue.ToString() + "'";
				conn.ExecuteQuery();
				for (int i=0; i< conn.GetRowCount(); i++)
					_ddlCBC.Items.Add(new ListItem(conn.GetFieldValue(i, 1), conn.GetFieldValue(i, 0)));
				_ddlCBC.Enabled = true;
			}
			else
			{
				_ddlCBC.Enabled = false;
				_ddlBranch.Enabled = false;
				_ddlRM.Enabled = false;
			}
		}

		private void _ddlCBC_SelectedIndexChanged(object sender, EventArgs e)
		{
			if(_ddlCBC.SelectedValue.ToString() != "-1")
			{
				_ddlBranch.Items.Clear();
				_ddlBranch.Items.Add(new ListItem("-", "-1"));
				_ddlRM.Items.Clear();
				_ddlRM.Items.Add(new ListItem("-", "-1"));
				conn.QueryString = "EXEC RORAC_BRANCH '" + _ddlCBC.SelectedValue.ToString() + "'";
				conn.ExecuteQuery();
				for (int i=0; i< conn.GetRowCount(); i++)
					_ddlBranch.Items.Add(new ListItem(conn.GetFieldValue(i, 1), conn.GetFieldValue(i, 0)));
				_ddlBranch.Enabled = true;
			}
			else
			{
				_ddlBranch.Enabled = false;
				_ddlRM.Enabled = false;
			}
		}

		private void _ddlBranch_SelectedIndexChanged(object sender, EventArgs e)
		{
			if(_ddlBranch.SelectedValue.ToString() != "-1")
			{
				_ddlRM.Items.Clear();
				_ddlRM.Items.Add(new ListItem("-", "-1"));
				_ddlRM.Enabled = true;
				conn.QueryString = "EXEC RORAC_RM '" + _ddlBranch.SelectedValue.ToString() + "'";
				conn.ExecuteQuery();
				for (int i=0; i< conn.GetRowCount(); i++)
					_ddlRM.Items.Add(new ListItem(conn.GetFieldValue(i, 1), conn.GetFieldValue(i, 0)));
			}
			else
			{
				_ddlRM.Enabled = false;
			}
		}

		protected void BTN_CLEAR_Click(object sender, System.EventArgs e)
		{
			_ddlRegion.SelectedIndex = 0;
			_ddlCBC.Items.Clear();
			_ddlCBC.Items.Add(new ListItem("-", "-1"));
			_ddlBranch.Items.Clear();
			_ddlBranch.Items.Add(new ListItem("-", "-1"));
			_ddlRM.Items.Clear();
			_ddlRM.Items.Add(new ListItem("-", "-1"));
		}

		private void LoadReportViewer()
		{
			string ReportAddr;
			string bu, area, cbc, br, rm, cif, cunm;
			bu = _ddlBisnisUnit.SelectedValue;
			area = _ddlRegion.SelectedValue;
			cbc = _ddlCBC.SelectedValue;
			br = _ddlBranch.SelectedValue;
			rm = _ddlRM.SelectedValue;
			cif = _txtCIF.Text;
			cunm = _txtNamaPemohon.Text;
			
			conn.QueryString	= "select reportaddr from app_parameter";
			conn.ExecuteQuery();
			if (conn.GetRowCount()>0)
				ReportAddr = conn.GetFieldValue(0,0);
			else
				return;
			ReportViewer1.ServerUrl = "http://" + ReportAddr+ "/ReportServer";
			ReportViewer1.ReportPath = "/SMEReports/RORACReport&BU=" + bu + "&REGION=" + area + "&CBC=" + cbc + "&BRANCH=" + br + "&RM=" + rm + "&CIF=" + cif + "&NAMAPEMOHON=" + cunm + "&rs:Command=Render";
		}

		protected void btn_Find_Click(object sender, System.EventArgs e)
		{
//			string select =	"SELECT CU_CIF_RORAC, RORAC_RORAC, ECR_RORAC, CUST_NAME FROM VW_RORAC_FIND " +
//				"WHERE 1=1 ";
//
//			if(_ddlRegion.SelectedValue.ToString() != "-1")
//			{
//				select = select + "AND VW_RORAC_FIND.AREAID = '" + _ddlRegion.SelectedValue.ToString() +  "' ";
//			}
//			if(_ddlCBC.SelectedValue.ToString() != "-1")
//			{
//				select = select + "AND VW_RORAC_FIND.CBC_CODE = '" + _ddlCBC.SelectedValue.ToString() + "' ";
//			}
//			if(_ddlBranch.SelectedValue.ToString() != "-1")
//			{
//				select = select + "AND VW_RORAC_FIND.BRANCH_CODE = '" + _ddlBranch.SelectedValue.ToString() + "' ";
//			}
//			if(_ddlRM.SelectedValue.ToString() != "-1")
//			{
//				select = select + "AND VW_RORAC_FIND.CU_RM = '" + _ddlRM.SelectedValue.ToString() + "' ";
//			}
//			if(_txtCIF.Text != "")
//			{
//				select = select + "AND VW_RORAC_FIND.CU_CIF_RORAC LIKE '%" + _txtCIF.Text.ToString() + "%' ";
//			}
//			if(_txtNamaPemohon.Text != "")
//			{
//				select = select + "AND VW_RORAC_FIND.CUST_NAME LIKE '%" + _txtNamaPemohon.Text.ToString() + "%' ";
//			}
//			
//			conn.QueryString = select;
//			conn.ExecuteQuery();
//
//			FillGrid();
			LoadReportViewer();
		}
	}
}
