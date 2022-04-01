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

namespace SME.InitialDataEntry
{ 
	public partial class AIP1Print : System.Web.UI.Page
	{
		protected Tools tools = new Tools();
		protected System.Web.UI.WebControls.TextBox TXT_;
		
	
		protected void Page_Load(object sender, System.EventArgs e)
		{

			if (!IsPostBack)
			{
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
									
			LBL_NO.Text = Request.QueryString["TXT_NO"];
			LBL_CURTIME.Text = Request.QueryString["TXT_CURTIME"];
			LBL_LAMP.Text = Request.QueryString["TXT_LAMP"];
			LBL_PRODUCTDESC1.Text = Request.QueryString["TXT_PRODUCTDESC1"];
			LBL_PRODUCTDESC2.Text = Request.QueryString["TXT_PRODUCTDESC2"];
			LBL_PRODUCTDESC3.Text = Request.QueryString["TXT_PRODUCTDESC3"];
			LBL_LGL.Text = Request.QueryString["TXT_LGL"];
			LBL_BRANCH.Text = Request.QueryString["TXT_BRANCH"];
			LBL_CP_LIMIT.Text = Request.QueryString["TXT_CP_LIMIT"];
			LBL_NOMINAL_CP_LIMIT.Text = Request.QueryString["TXT_NOMINAL_CP_LIMIT"];
			LBL_BO.Text = Request.QueryString["TXT_BO"];
			LBL_OFFICER.Text = Request.QueryString["TXT_OFFICER"];
			LBL_CUST_NAME.Text = Request.QueryString["TXT_CUST_NAME"];
			LBL_ADDR.Text = Request.QueryString["TXT_ADDR"];
			LBL_ADDR2.Text = Request.QueryString["TXT_ADDR2"];
			LBL_ADDR3.Text = Request.QueryString["TXT_ADDR3"];
			LBL_CITY.Text = Request.QueryString["TXT_CITY"];
			LBL_POSTCODE.Text = Request.QueryString["TXT_POSTCODE"];
			
			rapihkanViewAddress();
		}

		private void rapihkanViewAddress() 
		{
			if (LBL_ADDR2.Text.Trim().Equals(""))		//--- ALAMAT2 KOSONG
			{				
				if (LBL_ADDR3.Text.Trim().Equals(""))
				{
					//--- ALAMAT3 KOSONG
					LBL_ADDR2.Text		= LBL_CITY.Text;					
					LBL_ADDR3.Text		= LBL_POSTCODE.Text;
					LBL_CITY.Text		= "";
					LBL_POSTCODE.Text	= "";
				}
				else 
				{
					//--- ALAMAT3 TIDAK KOSONG
					LBL_ADDR2.Text		= LBL_ADDR3.Text;
					LBL_ADDR3.Text		= LBL_CITY.Text;
					LBL_CITY.Text		= LBL_POSTCODE.Text;
					LBL_POSTCODE.Text	= "";
				}
			}
			else 
			{
				//--- ALAMAT2 TIDAK KOSONG
				if (LBL_ADDR3.Text.Trim().Equals("")) 
				{
					//--- ALAMAT3 KOSONG
					LBL_ADDR3.Text		= LBL_CITY.Text;
					LBL_CITY.Text		= LBL_POSTCODE.Text;
					LBL_POSTCODE.Text	= "";
				}
			}
		}
		

		
	
	}
}
