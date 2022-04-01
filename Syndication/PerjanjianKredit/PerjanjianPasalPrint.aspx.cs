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

namespace SME.Syndication.PerjanjianKredit
{
	/// <summary>
	/// Summary description for PerjanjianPasalPrint.
	/// </summary>
	public partial class PerjanjianPasalPrint : System.Web.UI.Page
	{
		protected Tools tools = new Tools();
		protected Connection conn = new Connection(ConfigurationSettings.AppSettings["conn"]);
		protected Connection conn2 = new Connection(ConfigurationSettings.AppSettings["conn"]);
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			if(!IsPostBack)
			{
				ViewData();
			}
		}

		private void ViewData()
		{
			conn.QueryString = "SELECT TOP 1 * FROM VW_SDC_DOC_GENERAL_INFO WHERE CU_REF = '" + Request.QueryString["curef"] + "'";
			conn.ExecuteQuery();

			LBL_TXT_GROUP.Text		= conn.GetFieldValue("CUST_NAME").ToString().Replace("&nbsp;","");

			conn.QueryString = "SELECT * FROM SDC_PERJANJIAN WHERE CU_REF = '" + Request.QueryString["curef"] + "'";
			conn.ExecuteQuery();

			LBL_NO_PK_AWAL.Text		= conn.GetFieldValue("FIRST_PK_NO").ToString().Replace("&nbsp;","");
			LBL_TGL_PK_AWAL.Text	= tools.FormatDate(conn.GetFieldValue("FIRST_PK_DATE").ToString());
			LBL_NO_ADDENDUM.Text	= conn.GetFieldValue("ADM_PK_NO").ToString().Replace("&nbsp;","");
			LBL_TGL_ADDENDUM.Text	= tools.FormatDate(conn.GetFieldValue("ADM_PK_DATE").ToString());

			//CreateContentHeader();

			conn2.QueryString = "SELECT * FROM VW_SDC_PERJANJIAN_PASAL WHERE CU_REF = '" + Request.QueryString["curef"] + "'";
			conn2.ExecuteQuery();

			/*for(int i = 0; i < conn2.GetRowCount(); i++)
			{
				CreateContent(conn2.GetFieldValue(i, "SEQ"), conn2.GetFieldValue(i, "CU_REF"));
			}*/

			CreateContent(conn2.GetFieldValue("CU_REF"));

			conn.QueryString = "SELECT A.SU_FULLNAME, B.SG_GRPNAME FROM SCUSER A LEFT JOIN SCGROUP B ON A.GROUPID = B.GROUPID WHERE A.USERID = '" + Session["UserID"].ToString() + "' AND A.SU_ACTIVE = '1'";
			conn.ExecuteQuery();
			
			LBL_TXT_NAME.Text		= conn.GetFieldValue("SU_FULLNAME").ToString();
			LBL_TXT_NM_TITLE.Text	= conn.GetFieldValue("SG_GRPNAME").ToString();
		}

		/*private void CreateContentHeader()
		{
			System.Web.UI.HtmlControls.HtmlTableRow TR;
			System.Web.UI.HtmlControls.HtmlTableCell TD;
			System.Web.UI.WebControls.Label LBL_LABEL;

			TR = new HtmlTableRow();
			
			TD = new HtmlTableCell();
			TD.Attributes["class"] = "tdSmallHeader";
			TD.Attributes["align"] = "center";
			TD.Attributes["width"] = "15%";
			LBL_LABEL = new Label();
			LBL_LABEL.Text = "No.Pasal";
			TD.Controls.Add(LBL_LABEL);
			TR.Controls.Add(TD);

			TD = new HtmlTableCell();
			TD.Attributes["class"] = "tdSmallHeader";
			TD.Attributes["align"] = "center";
			TD.Attributes["width"] = "15%";
			LBL_LABEL = new Label();
			LBL_LABEL.Text = "Judul Pasal";
			TD.Controls.Add(LBL_LABEL);
			TR.Controls.Add(TD);

			TD = new HtmlTableCell();
			TD.Attributes["class"] = "tdSmallHeader";
			TD.Attributes["align"] = "center";
			TD.Attributes["width"] = "30%";
			LBL_LABEL = new Label();
			LBL_LABEL.Text = "Isi Pasal";
			TD.Controls.Add(LBL_LABEL);
			TR.Controls.Add(TD);

			TD = new HtmlTableCell();
			TD.Attributes["class"] = "tdSmallHeader";
			TD.Attributes["align"] = "center";
			TD.Attributes["width"] = "30%";
			LBL_LABEL = new Label();
			LBL_LABEL.Text = "Keterangan";
			TD.Controls.Add(LBL_LABEL);
			TR.Controls.Add(TD);

			TD = new HtmlTableCell();
			TD.Attributes["class"] = "tdSmallHeader";
			TD.Attributes["align"] = "center";
			TD.Attributes["width"] = "10%";
			LBL_LABEL = new Label();
			LBL_LABEL.Text = "Tabel";
			TD.Controls.Add(LBL_LABEL);
			TR.Controls.Add(TD);

			TBL_ACTION.Controls.Add(TR);
		}*/

		/*private void CreateContent(string SEQ, string CU_REF)
		{
			System.Web.UI.HtmlControls.HtmlTableRow TR;
			System.Web.UI.HtmlControls.HtmlTableCell TD;
			System.Web.UI.WebControls.Label LBL_LABEL;
			System.Web.UI.WebControls.TextBox TXT_BOX;

			conn.QueryString = "SELECT * FROM VW_SDC_PERJANJIAN_PASAL WHERE SEQ = '" + SEQ + "' AND CU_REF = '" + CU_REF + "'";
			conn.ExecuteQuery();

			TR = new HtmlTableRow();

			TD = new HtmlTableCell();
			TD.Attributes["align"] = "left";
			TD.Attributes["width"] = "15%";
			LBL_LABEL = new Label();
			LBL_LABEL.Text = conn.GetFieldValue("PASAL_NO").ToString();
			TD.Controls.Add(LBL_LABEL);
			TR.Controls.Add(TD);

			TD = new HtmlTableCell();
			TD.Attributes["align"] = "left";
			TD.Attributes["width"] = "15%";
			LBL_LABEL = new Label();
			LBL_LABEL.Text = conn.GetFieldValue("PASAL_TITLE").ToString();
			TD.Controls.Add(LBL_LABEL);
			TR.Controls.Add(TD);

			TD = new HtmlTableCell();
			TD.Attributes["align"] = "left";
			TD.Attributes["width"] = "30%";
			TXT_BOX = new TextBox();
			TXT_BOX.TextMode = TextBoxMode.MultiLine;
			TXT_BOX.Width = 400;
			TXT_BOX.BorderStyle = BorderStyle.None;
			TXT_BOX.Text = conn.GetFieldValue("PASAL_ISI").ToString();
			TXT_BOX.ReadOnly = true;
			TD.Controls.Add(TXT_BOX);
			TR.Controls.Add(TD);

			TD = new HtmlTableCell();
			TD.Attributes["align"] = "left";
			TD.Attributes["width"] = "30%";
			LBL_LABEL = new Label();
			LBL_LABEL.Text = conn.GetFieldValue("PASAL_REMARK").ToString();
			TD.Controls.Add(LBL_LABEL);
			TR.Controls.Add(TD);

			TD = new HtmlTableCell();
			TD.Attributes["align"] = "left";
			TD.Attributes["width"] = "10%";
			LBL_LABEL = new Label();
			LBL_LABEL.Text = conn.GetFieldValue("KETERANGAN").ToString();
			TD.Controls.Add(LBL_LABEL);
			TR.Controls.Add(TD);

			TBL_ACTION.Controls.Add(TR);
		}*/

		private void CreateContent(string CU_REF)
		{
			System.Web.UI.WebControls.DataGrid DATA_GRID;
			System.Web.UI.HtmlControls.HtmlTableRow TR;
			System.Web.UI.HtmlControls.HtmlTableCell TD;

			// Membuat Data Grid

			TR = new HtmlTableRow();
			TD = new HtmlTableCell();
			TD.Attributes["colspan"] = "2";

			DATA_GRID = new DataGrid();
			DATA_GRID.ID = "GRID_" + CU_REF;
			DATA_GRID.AllowPaging = false;
			DATA_GRID.CellPadding = 1;
			DATA_GRID.AutoGenerateColumns = false;
			DATA_GRID.Width = Unit.Percentage(100.0);
			DATA_GRID.AlternatingItemStyle.CssClass = "TblAlternating";

			// Membuat Field pada Data Grid
			conn.QueryString = "SELECT * FROM VW_SDC_PERJANJIAN_FIELD_DATA_GRID ORDER BY CONVERT(INT,FIELDID) ASC";
			conn.ExecuteQuery();
	
			BoundColumn columns = new BoundColumn();

			for(int i = 0; i < conn.GetRowCount(); i++)
			{
				columns = new BoundColumn();
				columns.HeaderText = conn.GetFieldValue(i,1).ToString();
				columns.DataField = conn.GetFieldValue(i,2).ToString();
				columns.HeaderStyle.CssClass = "tdSmallHeader";
				columns.Visible = true;
				columns.ItemStyle.HorizontalAlign = HorizontalAlign.Left;
				DATA_GRID.Columns.Add(columns);
			}

			// BIND DATA
			conn.QueryString = "SELECT * FROM VW_SDC_PERJANJIAN_PASAL WHERE CU_REF = '" + CU_REF + "'";
			BindData(DATA_GRID, conn.QueryString);

			TD.Controls.Add(DATA_GRID);
			TR.Controls.Add(TD);

			TBL_ACTION.Controls.Add(TR);
		}

		private void BindData(DataGrid theGrid, string strconn)
		{
			if(strconn != "")
			{
				conn.QueryString = strconn;
				conn.ExecuteQuery();
			}

			System.Data.DataTable dt = new System.Data.DataTable();
			dt = conn.GetDataTable().Copy();

			System.Web.UI.WebControls.DataGrid dg = theGrid;

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

		}
		#endregion
	}
}
