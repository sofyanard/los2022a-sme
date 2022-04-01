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
using Microsoft.VisualBasic;
using DMS.CuBESCore;
using DMS.DBConnection;


namespace SME.Legal
{
	/// <summary>
	/// Summary description for DetailLegalSigning_Data.
	/// </summary>
	public partial class DetailLegalSigning_Data : System.Web.UI.Page
	{
		//protected Connection conn = new Connection("Data Source=10.123.12.30;Initial Catalog=SME;uid=sa;pwd=");
		protected Connection conn;
		protected Tools tool = new Tools();

	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			conn = (Connection) Session["Connection"];

			if (!IsPostBack)
			{
				LBL_REGNO.Text = Request.QueryString["regno"];
				LBL_CUREF.Text = Request.QueryString["curef"];
				LBL_TC.Text = Request.QueryString["tc"];

				DDL_AP_SIGNDATEMONTH.Items.Add(new ListItem("-- Pilih --", ""));
				for (int i=1; i<=12; i++)
					DDL_AP_SIGNDATEMONTH.Items.Add(new ListItem(DateAndTime.MonthName(i, false), i.ToString()));

				ViewData();
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

		private void ViewData()
		{
			conn.QueryString = "select * from VW_INFOUMUM "+
				"where AP_REGNO = '"+ LBL_REGNO.Text +"' ";
			conn.ExecuteQuery();
			TXT_AP_REGNO.Text = conn.GetFieldValue("AP_REGNO");
			TXT_CU_REF.Text = conn.GetFieldValue("CU_REF");
			string AP_SIGNDATE = conn.GetFieldValue("AP_SIGNDATE");
			TXT_AP_SIGNDATEDAY.Text = tool.FormatDate_Day(AP_SIGNDATE);
			DDL_AP_SIGNDATEMONTH.SelectedValue = tool.FormatDate_Month(AP_SIGNDATE);
			TXT_AP_SIGNDATEYEAR.Text = tool.FormatDate_Year(AP_SIGNDATE);
			TXT_PROGRAMDESC.Text = conn.GetFieldValue("PROGRAMDESC");
			TXT_BRANCH_NAME.Text = conn.GetFieldValue("BRANCH_NAME");
			TXT_AP_TMLDRNM.Text = conn.GetFieldValue("AP_TMLDRNM");
			TXT_AP_RMNM.Text = conn.GetFieldValue("AP_RMNM");
			TXT_BU_DESC.Text = conn.GetFieldValue("BU_DESC");
			TXT_CU_NAME.Text = conn.GetFieldValue("CU_NAME");
			TXT_CU_ADDR1.Text = conn.GetFieldValue("CU_ADDR1");
			TXT_CU_ADDR2.Text = conn.GetFieldValue("CU_ADDR2");
			TXT_CU_ADDR3.Text = conn.GetFieldValue("CU_ADDR3");
			TXT_CU_CITYNM.Text = conn.GetFieldValue("CU_CITYNM");
			TXT_CU_PHN.Text = conn.GetFieldValue("CU_PHN");
			TXT_BUSSTYPEDESC.Text = conn.GetFieldValue("BUSSTYPEDESC");
		}

	}
}
