using System;
using System.IO;
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

namespace SME.RORAC
{
	/// <summary>
	/// Summary description for CustomerRating.
	/// 1. Customer harus di-rate: (belum pernah di rate/rate expired)
	///			Load Current data&RATE!!
	///	2. Customer dah pernah di-rate:
	///			- munculkan data rate terakhir
	///			- btn text "Re-Rate"
	///			- Data yang tidak current lagi dikasih warna merah
	///			Saat "Re-rate" di tekan : 
	///			- muncul data yang current otomatis tanpa hasil rating
	///			- btn text jadi "Rate"
	///			Saat "Rate" ditekan :
	///			- Perform Rating : Generate text input file ==> kirim ke STW, baca hasil dan display
	/// 
	/// </summary>
	public partial class BCG_RORAC : System.Web.UI.Page
	{
		protected Connection conn;
		protected string CIF = "";
		protected Tools tool = new Tools();

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

		protected void Page_Load(object sender, System.EventArgs e)
		{
			conn = (Connection) Session["Connection"];
			string select1 =	"SELECT CU_CIF FROM CUSTOMER WHERE CU_REF = '" + Request.QueryString["curef"] + "'";
			conn.QueryString = select1;
			conn.ExecuteQuery();
			if (conn.GetRowCount() > 0) 
			{
				CIF = conn.GetFieldValue("CU_CIF");
			}

			string select2 = "SELECT * FROM VW_RORAC_RESULT " +
				"WHERE CU_CIF_RORAC = '" + CIF + "'";
			conn.QueryString = select2;
			conn.ExecuteQuery();
			if (conn.GetRowCount() > 0) 
			{
				TXT_NPAT_ANNUALIZED.Text = tool.MoneyFormat(conn.GetFieldValue("NAR_RORAC"));
				TXT_ECONOMIC_CAPITAL.Text = tool.MoneyFormat(conn.GetFieldValue("TEC_RORAC"));
				
				TXT_AVE.Text = tool.MoneyFormat(conn.GetFieldValue("AVE_RORAC"));

				try
				{
					TXT_REQUIREMENT_NILAI_AVE.Text = tool.MoneyFormat(conn.GetFieldValue("REF_AVE_RORAC"));
				}
				catch
				{
					TXT_REQUIREMENT_NILAI_AVE.Text = conn.GetFieldValue("REF_AVE_RORAC");
				}

				TXT_RORAC_PRECENTAGE.Text = tool.MoneyFormat(conn.GetFieldValue("RORAC_RORAC"));
				TXT_REQUIREMENT_NILAI_RORAC.Text = conn.GetFieldValue("REF_RORAC").Replace("%","");
				TXT_FINANCIAL_PERIOD.Text = conn.GetFieldValue("DATE_DAT");
			}
		}
	}
}