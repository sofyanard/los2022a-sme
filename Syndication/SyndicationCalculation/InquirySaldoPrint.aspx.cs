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

namespace SME.Syndication.SyndicationCalculation
{
	/// <summary>
	/// Summary description for InquirySaldoPrint.
	/// </summary>
	public partial class InquirySaldoPrint : System.Web.UI.Page
	{
		protected System.Web.UI.HtmlControls.HtmlTable TBL_INQUIRY_SALDO;
		protected Tools tools = new Tools();
		protected Connection conn = new Connection(ConfigurationSettings.AppSettings["conn"]);
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			TR_KI.Visible		= false;
			TR_KMK.Visible		= false;
			TR_NCL.Visible		= false;
			TR_INQUIRY.Visible	= false;
			ViewData();
		}

		private void ViewData()
		{
			conn.QueryString = "EXEC SDC_INQUIRY_SALDO_INFO '" + Request.QueryString["curef"] + "','" + Request.QueryString["bk"] + "','" + Request.QueryString["type"] + "'," + Request.QueryString["seq"];
			conn.ExecuteQuery();

			if(Request.QueryString["type"] == "1")
			{
				TR_KI.Visible		= true;
				TR_INQUIRY.Visible	= true;

				TXT_SUKU_BUNGA_KI.Text			= conn.GetFieldValue("SUKU_BUNGA_POKOK").ToString().Replace("&nbsp;", "0");
				TXT_POSISI_KI.Text				= tools.FormatDate(conn.GetFieldValue("TGL_POSISI").ToString());
				TXT_BAKI_DEBET_POKOK_KI.Text	= tools.MoneyFormat(conn.GetFieldValue("BAKI_POKOK").ToString().Replace("&nbsp;", "0"));
				TXT_BAKI_DEBET_IDC_KI.Text		= tools.MoneyFormat(conn.GetFieldValue("BAKI_IDC").ToString().Replace("&nbsp;", "0"));

				conn.QueryString	= "SELECT BANKNAME FROM RFBANK WHERE BANKID = '" + Request.QueryString["bk"] + "' AND ACTIVE = '1'";
				conn.ExecuteQuery();
				TXT_PORSI_KI.Text	= conn.GetFieldValue("BANKNAME").ToString();

				conn.QueryString	= "SELECT [DESC] FROM RF_SINDIKASI_PRODUCT WHERE CODE = '" + Request.QueryString["type"] + "' AND ACTIVE = '1'";
				conn.ExecuteQuery();
				TXT_FASILITAS_KI.Text	= conn.GetFieldValue("DESC").ToString();
			}
			else if(Request.QueryString["type"] == "2")
			{
				TR_KMK.Visible		= true;
				TR_INQUIRY.Visible	= true;

				TXT_SUKU_BUNGA_KMK.Text			= conn.GetFieldValue("SUKU_BUNGA_POKOK").ToString().Replace("&nbsp;", "0");
				TXT_POSISI_KMK.Text				= tools.FormatDate(conn.GetFieldValue("TGL_POSISI").ToString());
				TXT_OUTSTANDING_POKOK_KMK.Text	= tools.MoneyFormat(conn.GetFieldValue("BAKI_POKOK").ToString().Replace("&nbsp;", "0"));
				TXT_OUTSTANDING_BUNGA_KMK.Text	= tools.MoneyFormat(conn.GetFieldValue("BUNGA_POKOK").ToString().Replace("&nbsp;", "0"));

				conn.QueryString	= "SELECT BANKNAME FROM RFBANK WHERE BANKID = '" + Request.QueryString["bk"] + "' AND ACTIVE = '1'";
				conn.ExecuteQuery();
				TXT_PORSI_KMK.Text	= conn.GetFieldValue("BANKNAME").ToString();

				conn.QueryString	= "SELECT [DESC] FROM RF_SINDIKASI_PRODUCT WHERE CODE = '" + Request.QueryString["type"] + "' AND ACTIVE = '1'";
				conn.ExecuteQuery();
				TXT_FASILITAS_KMK.Text	= conn.GetFieldValue("DESC").ToString();
			}
			else if(Request.QueryString["type"] == "3")
			{
				TR_NCL.Visible		= true;
				TR_INQUIRY.Visible	= true;

				TXT_POSISI_NCL.Text				= tools.FormatDate(conn.GetFieldValue("TGL_POSISI").ToString());
				TXT_OUTSTANDING_POKOK_KMK.Text	= tools.MoneyFormat(conn.GetFieldValue("OUT_NCL").ToString().Replace("&nbsp;", "0"));

				conn.QueryString	= "SELECT BANKNAME FROM RFBANK WHERE BANKID = '" + Request.QueryString["bk"] + "' AND ACTIVE = '1'";
				conn.ExecuteQuery();
				TXT_PORSI_NCL.Text	= conn.GetFieldValue("BANKNAME").ToString();

				conn.QueryString	= "SELECT [DESC] FROM RF_SINDIKASI_PRODUCT WHERE CODE = '" + Request.QueryString["type"] + "' AND ACTIVE = '1'";
				conn.ExecuteQuery();
				TXT_FASILITAS_NCL.Text	= conn.GetFieldValue("DESC").ToString();
			}

			conn.QueryString	= "SELECT * FROM VW_SDC_DOC_GENERAL_INFO WHERE CU_REF = '" + Request.QueryString["curef"] + "'";
			conn.ExecuteQuery();
			LBL_TITLE_CUST.Text	= conn.GetFieldValue("CUST_NAME").ToString();

			conn.QueryString	= "SELECT * FROM VW_SDC_INQUIRY_RESULT WHERE CU_REF = '" + Request.QueryString["curef"] + "' AND BANK_NM = '" + Request.QueryString["bk"] + "' AND PRODUCT_NM = '" + Request.QueryString["type"] + "' AND PRODUCT_SEQ = '" + Request.QueryString["seq"] + "' ORDER BY TRX_CODE ASC";
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
					dg.Items[i].Cells[0].Text = tools.FormatDate(dg.Items[i].Cells[0].Text, true);
					dg.Items[i].Cells[2].Text = tools.MoneyFormat(dg.Items[i].Cells[2].Text);
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

		}
		#endregion
	}
}
