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

namespace SME.CreditAnalysis.BPR
{
	/// <summary>
	/// Summary description for InformasiUmum.
	/// </summary>
	public partial class InformasiUmum : System.Web.UI.Page
	{

		//protected Connection conn = new Connection("Data Source=192.168.1.200;Initial Catalog=SME;uid=sa;pwd=");
		protected Connection conn;
		protected Tools tool = new Tools();
		
		protected void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			conn = (Connection) Session["Connection"];
			if (!IsPostBack)
			{
				LoadData();
			}
		}

		private void LoadData()
		{
			conn.QueryString = "select AP_REGNO, CU_REF, AP_SIGNDATE, PROGRAMDESC, BRANCH_NAME, " + 
				"AP_RELMNGR, NAME, ADDR1, ADDR2, ADDR3, CITY, TELP, BUSSTYPE, BUSSUNITDESC " +
				"from vw_creana_bpr_infoumum where ap_regno='" + Request.QueryString["regno"] + "'";
			conn.ExecuteQuery();
			TXT_AP_REGNO.Text = conn.GetFieldValue("AP_REGNO");
			TXT_CU_REF.Text = conn.GetFieldValue("CU_REF");
			TXT_AP_SIGNDATE.Text = conn.GetFieldValue("AP_SIGNDATE");
			TXT_PROGRAMDESC.Text = conn.GetFieldValue("PROGRAMDESC");
			TXT_BRANCH_NAME.Text = conn.GetFieldValue("BRANCH_NAME");
			TXT_AP_RELMNGR.Text = conn.GetFieldValue("AP_RELMNGR");
			txtName.Text = conn.GetFieldValue("NAME");
			txtAddr1.Text = conn.GetFieldValue("ADDR1");
			txtAddr2.Text = conn.GetFieldValue("ADDR2");
			txtAddr3.Text = conn.GetFieldValue("ADDR3");
			txtCity.Text = conn.GetFieldValue("CITY");
			txtTelp.Text = conn.GetFieldValue("TELP");
			txtBussType.Text = conn.GetFieldValue("BUSSTYPE");
			txtBussUnitDesc.Text = conn.GetFieldValue("BUSSUNITDESC");
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

		protected void BTN_UPDATESTATUS_Click(object sender, System.EventArgs e)
		{
			conn.QueryString = "select apptype, productid, PROD_SEQ from custproduct where ap_regno='" + Request.QueryString["regno"] + "'";
			conn.ExecuteQuery();
			for (int i = 0; i < conn.GetRowCount(); i++)
			{
				conn.QueryString = "exec TRACKUPDATE '" + Request.QueryString["regno"] + "', '" + 
					conn.GetFieldValue(i,1) + "', '" + conn.GetFieldValue(i,0) + "', '" + Session["UserID"].ToString() + "', '" + conn.GetFieldValue(i, "PROD_SEQ") + "','"+ Request.QueryString["tc"].Trim() +"'";
				conn.ExecuteNonQuery();
			}
		}
	}
}
