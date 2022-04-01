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
	
	public partial class LKN : System.Web.UI.Page
	{
		protected Tools tools = new Tools();
		protected Connection conn;
		//protected Connection conn = new Connection("Data Source=10.123.12.30;Initial Catalog=SMEDEV;uid=sa;pwd=");
		protected void Page_Load(object sender, System.EventArgs e)
		{
			conn = (Connection) Session["Connection"];
			PrintBtn.Enabled = false;

			if (!IsPostBack)
			{
				for (int i = 1; i <= 12; i++)
				{
					DDL_LKN_MONTH.Items.Add(new ListItem(DateAndTime.MonthName(i, false), i.ToString()));
				}

				//string regno = "31052004001000003";
				string regno = Request.QueryString["regno"].ToString();
				conn.QueryString = "SELECT * FROM VW_LKKN1 WHERE AP_REGNO ='" + regno + "'";
				conn.ExecuteQuery();
				TXT_CUST_NAME.Text = conn.GetFieldValue("NAMA");
				TXT_ADDR.Text= conn.GetFieldValue("ALAMAT");
				TXT_CALONNASABAH.Text = conn.GetFieldValue("NAMA");
					
			}
			SaveBtn.Attributes.Add("onclick","if(!cek_mandatory(document.Form1)){return false;};");
			
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



		protected void SaveBtn_Click(object sender, System.EventArgs e)
		{
				PrintBtn.Enabled = true;
				if (TXT_LKN_YEAR.Text == "" ||TXT_LKN_DAY.Text == "" ) 
				{
					string LKNDATE = "";
					TXT_LKNDATE.Text = LKNDATE;
				} 
				else
				{
					string LKNMONTH = DDL_LKN_MONTH.SelectedValue;
					string LKNDATE= TXT_LKN_YEAR.Text+ "/" + LKNMONTH + "/" + TXT_LKN_DAY.Text ;
					TXT_LKNDATE.Text = LKNDATE;
				}
			
				string regno = Request.QueryString["regno"].ToString();
				//string regno = "31052004001000003";
				conn.QueryString= " exec SVT_LKN '" + regno + "', '" +
					TXT_LKNDATE.Text + "', '" + RBL_LKN_PURPOSE.SelectedValue + "', '" +
					TXT_LKN_PURPOSELAIN.Text +"', '"+TXT_LKN_OFFICER.Text + "'";
					
				conn.ExecuteNonQuery();
		}

		protected void PrintBtn_Click(object sender, System.EventArgs e)
		{
			Response.Redirect("LKNBPrint.aspx");
		}

	

		
	}
}
