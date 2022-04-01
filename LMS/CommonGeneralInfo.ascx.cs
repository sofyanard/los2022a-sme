namespace SME.LMS
{
	using System;
	using System.Data;
	using System.Drawing;
	using System.Web;
	using System.Web.UI.WebControls;
	using System.Web.UI.HtmlControls;
	using DMS.CuBESCore;
	using DMS.DBConnection;

	/// <summary>
	///		Summary description for CommonGeneralInfo.
	/// </summary>
	public partial class CommonGeneralInfo : System.Web.UI.UserControl
	{
		protected Connection conn;

		protected void Page_Load(object sender, System.EventArgs e)
		{
			conn = (Connection) Session["Connection"];
			if (!IsPostBack)
			{
				ViewData();
			}
		}

		private void ViewData()
		{
			conn.QueryString = "EXEC LMS_COMMONGENERALINFO '" + Request.QueryString["lmsreg"] + "'";
			conn.ExecuteQuery();

			TXT_LMS_REGNO.Text		= conn.GetFieldValue("LMS_REGNO");
			TXT_LMS_RECVDATE.Text	= conn.GetFieldValue("LMS_RECVDATE");

			TXT_CU_RM.Text			= conn.GetFieldValue("RM_NAME");
			TXT_CU_TL.Text			= conn.GetFieldValue("TL_NAME");

			TXT_CIFNO.Text			= conn.GetFieldValue("CIFNO");
			TXT_CU_NAME.Text		= conn.GetFieldValue("CU_NAME");
			TXT_ID_TYPE.Text		= conn.GetFieldValue("ID_TYPE");
			TXT_ID_NO.Text			= conn.GetFieldValue("ID_NO");
			TXT_CU_ADDR1.Text		= conn.GetFieldValue("CU_ADDR1");
			TXT_CU_ADDR2.Text		= conn.GetFieldValue("CU_ADDR2");
			TXT_CU_ADDR3.Text		= conn.GetFieldValue("CU_ADDR3");
			TXT_CU_ADDR4.Text		= conn.GetFieldValue("CU_ADDR4");
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
		///		Required method for Designer support - do not modify
		///		the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{

		}
		#endregion
	}
}
