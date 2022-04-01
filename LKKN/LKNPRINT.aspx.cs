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
using DMS.DBConnection;
using DMS.CuBESCore;
using Microsoft.VisualBasic;

namespace SME.LKKN1
{
	
	public partial class LKNPRINT : System.Web.UI.Page
	{
		protected Tools tools = new Tools();
		
		protected Connection conn;
		//protected Connection conn = new Connection("Data Source=10.123.12.30;Initial Catalog=SMEDEV;uid=sa;pwd=");
		protected void Page_Load(object sender, System.EventArgs e)
		{
			conn = (Connection) Session["Connection"];

			if (!IsPostBack)
			{
				
				//string regno = "31052004001000003";
				string regno = Request.QueryString["regno"].ToString();
				
				ViewData(regno);
					
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
		public void ViewData(string regno)
		{
				conn.QueryString = "SELECT * FROM VW_LKKN1 WHERE AP_REGNO ='" + regno + "'";
				conn.ExecuteQuery();
				LBL_CUST_NAME.Text = conn.GetFieldValue("NAMA");
				LBL_ADDR.Text= conn.GetFieldValue("ALAMAT");
				LBL_CALONNASABAH.Text = conn.GetFieldValue("NAMA");

			conn.QueryString = "SELECT * FROM LKKN WHERE AP_REGNO ='" + regno + "'";
			conn.ExecuteQuery();
			

			
			LBL_LKN_PURPOSELAIN.Text = conn.GetFieldValue("LKN_PURPOSELAIN");
			LBL_LKN_OFFICER.Text = conn.GetFieldValue("LKN_OFFICER");
			CBL_LKN_PURPOSE.SelectedValue = conn.GetFieldValue("LKN_PURPOSE");

			conn.QueryString = "SELECT VISITDAY = DATENAME(DAY, LKN_VISITDATE)+' '+ " +
					"DATENAME(MONTH, LKN_VISITDATE) +' '+ DATENAME(YEAR, LKN_VISITDATE)" +
					"FROM LKKN";
			conn.ExecuteQuery();

				LBL_LKNDATE.Text = conn.GetFieldValue("VISITDAY");
		}
		
	}
}
