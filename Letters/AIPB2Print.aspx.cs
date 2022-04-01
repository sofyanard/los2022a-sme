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

namespace SME.InitialDataEntry
{
	
	public partial class AIPB2Print : System.Web.UI.Page
	{
		protected Connection conn;
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			conn = (Connection) Session["Connection"];
			if (!IsPostBack) 
			{
				this.view();
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

		private void view() 
		{
			


			string TXT_NO = Request.QueryString["TXT_NO"];
			string TXT_CURTIME = Request.QueryString["TXT_CURTIME"];
			string TXT_LAMP = Request.QueryString["TXT_LAMP"];
			string TXT_PRODUCTDESC1 = Request.QueryString["TXT_PRODUCTDESC1"];
			string TXT_PRODUCTDESC2 = Request.QueryString["TXT_PRODUCTDESC2"];
			string TXT_PRODUCTDESC3 = Request.QueryString["TXT_PRODUCTDESC3"];
			string TXT_LGL = Request.QueryString["TXT_LGL"];
			string TXT_BRANCH = Request.QueryString["TXT_BRANCH"];
			string TXT_CP_LIMIT = Request.QueryString["TXT_CP_LIMIT"];
			string TXT_NOMINAL_CP_LIMIT = Request.QueryString["TXT_NOMINAL_CP_LIMIT"];
			string TXT_BO = Request.QueryString["TXT_BO"];
			string TXT_OFFICER = Request.QueryString["TXT_OFFICER"];
			string TXT_CUST_NAME = Request.QueryString["TXT_CUST_NAME"];
			string TXT_ADDR = Request.QueryString["TXT_ADDR"];
			string TXT_ADDR2 = Request.QueryString["TXT_ADDR2"];
			string TXT_ADDR3 = Request.QueryString["TXT_ADDR3"];
			string TXT_CITY = Request.QueryString["TXT_CITY"];
			string TXT_POSTCODE = Request.QueryString["TXT_POSTCODE"];

			this.PH1.Controls.Add(new LiteralControl("<iframe src='AIP2Print.aspx?TXT_NO=" + TXT_NO + "&TXT_CURTIME=" + TXT_CURTIME + "&TXT_LAMP=" + TXT_LAMP+ "&TXT_PRODUCTDESC1=" + TXT_PRODUCTDESC1 + 
				"&TXT_PRODUCTDESC2=" + TXT_PRODUCTDESC2 + "&TXT_PRODUCTDESC3=" + TXT_PRODUCTDESC3 + "&TXT_LGL=" + TXT_LGL + 
				"&TXT_BRANCH=" + TXT_BRANCH + "&TXT_CP_LIMIT=" + TXT_CP_LIMIT + 
				"&TXT_BO=" + TXT_BO+ "&TXT_OFFICER=" + TXT_OFFICER  +
				"&TXT_CUST_NAME= " + TXT_CUST_NAME + 
				"&TXT_ADDR= " + TXT_ADDR +
				"&TXT_ADDR2= " + TXT_ADDR2 +
				"&TXT_ADDR3= " + TXT_ADDR3 +
				"&TXT_CITY= " + TXT_CITY + "&TXT_POSTCODE= " + TXT_POSTCODE +
				"&TXT_NOMINAL_CP_LIMIT=" + TXT_NOMINAL_CP_LIMIT+"' id='frameaip2' frameborder='0' width=1000 height=2000></iframe>"));			
		}

		protected void BTN_PRINT_ServerClick(object sender, System.EventArgs e)
		{
			string USERID = (string) Session["UserID"];
			string REGNO = Request.QueryString["regno"];

			conn.QueryString = "exec IDE_LETTERNO_INSERT '"+REGNO+"','1','"+Request.QueryString["TXT_NO"]+"','"+USERID+"'";
			conn.ExecuteNonQuery();		
		}
	}
}
