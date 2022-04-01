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

namespace SME.SPPK
{
	/// <summary>
	/// Summary description for RejectLetter_Main.
	/// </summary>
	public partial class SPPKLetter_Main : System.Web.UI.Page
	{
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
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
			string TXT_CURTIME = Request.QueryString["TXT_CURTIME"];
			string TXT_NO = Request.QueryString["TXT_NO"];
			string TXT_LAMP = Request.QueryString["TXT_LAMP"];
			string TXT_AP_DATE = Request.QueryString["TXT_AP_DATE"];
			
			string TXT_CUST_NAME =  Request.QueryString["TXT_CUST_NAME"];
			string TXT_ADDR = Request.QueryString["TXT_ADDR"];
			string TXT_CITY = Request.QueryString["TXT_CITY"];
			string TXT_POSTCODE = Request.QueryString["TXT_POSTCODE"];
			string TXT_CP_LIMIT = Request.QueryString["TXT_CP_LIMIT"];
			string TXT_HURUF_CP_LIMIT = Request.QueryString["TXT_HURUF_CP_LIMIT"];
			string TXT_PRODUCTDESC = Request.QueryString["TXT_PRODUCTDESC"];
			string TXT_CP_TENOR = Request.QueryString["TXT_CP_TENOR"];
			string TXT_CP_LOANPURPOSE = Request.QueryString["TXT_CP_LOANPURPOSE"];
			string TXT_CP_INSTALLMENT = Request.QueryString["TXT_CP_INSTALLMENT"];
			string TXT_SIFATKREDIT = Request.QueryString["TXT_SIFATKREDIT"];
			string TXT_SUKUBUNGA	= Request.QueryString["TXT_SUKUBUNGA"];
			string TXT_PROVISI = Request.QueryString["TXT_PROVISI"];
			string TXT_THNTARGET	= Request.QueryString["TXT_THNTARGET"];
			string TXT_JMLTARGET	= Request.QueryString["TXT_JMLTARGET"];
			string TXT_STOCK	= Request.QueryString["TXT_STOCK"];
			string TXT_PU	= Request.QueryString["TXT_PU"]; 
			string TXT_KMK= Request.QueryString["TXT_KMK"]; 
			string TXT_KM	= Request.QueryString["TXT_KM"];
			string TXT_SF	= Request.QueryString["TXT_SF"];
			string TXT_MANAGER = Request.QueryString["TXT_MANAGER"];
			string TXT_BRANCH	= Request.QueryString["TXT_BRANCH"]; 
			string TXT_CRM = Request.QueryString["TXT_CRM"];
			string TXT_JMNUTAMA	= Request.QueryString["TXT_JMNUTAMA"]; 
			string TXT_JMNTAMBAHAN	= Request.QueryString["TXT_JMNTAMBAHAN"]; 
			string TXT_TGL1 = Request.QueryString["TXT_TGL1"]; 
			string TXT_BLN1 = Request.QueryString["TXT_BLN1"]; 
			string TXT_THN1 = Request.QueryString["TXT_THN1"]; 
			string TXT_TGL2 = Request.QueryString["TXT_TGL2"]; 
			string TXT_BLN2 = Request.QueryString["TXT_BLN2"]; 
			string TXT_THN2 = Request.QueryString["TXT_THN2"]; 
			string TXT_BRANCH1 = Request.QueryString["TXT_BRANCH1"]; 


			this.PH1.Controls.Add(new LiteralControl("<iframe src='SPPKPrint.aspx?TXT_NO=" + TXT_NO + 
				"&TXT_CURTIME= " + TXT_CURTIME + "&TXT_LAMP=" + TXT_LAMP + 
				"&TXT_CUST_NAME= " + TXT_CUST_NAME + "&TXT_ADDR=" + TXT_ADDR+ "&TXT_CITY= " + TXT_CITY + "&TXT_POSTCODE= " + TXT_POSTCODE +
				"&TXT_CP_LIMIT=" +TXT_CP_LIMIT + "&TXT_SIFATKREDIT=" + TXT_SIFATKREDIT +
				"&TXT_HURUF_CP_LIMIT=" + TXT_HURUF_CP_LIMIT +
				"&TXT_CP_LOANPURPOSE= " + TXT_CP_LOANPURPOSE + "&TXT_CP_TENOR=" + TXT_CP_TENOR +
				"&TXT_CP_INSTALLMENT= " + TXT_CP_INSTALLMENT + "&TXT_TGL1=" +TXT_TGL1 + "&TXT_BLN1=" + TXT_BLN1+
				"&TXT_THN1=" + TXT_THN1 + "&TXT_TGL2=" +TXT_TGL2 + "&TXT_BLN2= " + TXT_BLN2+
				"&TXT_THN2=" + TXT_THN2 + "&TXT_AP_DATE=" + TXT_AP_DATE +
				"&TXT_SIFAT=" + TXT_SIFATKREDIT +"&TXT_SUKUBUNGA= " + TXT_SUKUBUNGA + 
				"&TXT_PROVISI= " + TXT_PROVISI+ "&TXT_PU=" +TXT_PU + "&TXT_KMK=" + TXT_KMK +
				"&TXT_KM=" + TXT_KM + "&TXT_PRODUCTDESC=" + TXT_PRODUCTDESC + "&TXT_STOCK=" + TXT_STOCK +
				"&TXT_THNTARGET= " + TXT_THNTARGET + "&TXT_JMLTARGET= " + TXT_JMLTARGET + "&TXT_SF=" + TXT_SF + 
				"&TXT_JMNUTAMA= " + TXT_JMNUTAMA + "&TXT_BRANCH= " + TXT_BRANCH + "&TXT_MANAGER= " + TXT_MANAGER +
				"&TXT_BRANCH1=" + TXT_BRANCH1 +"&TXT_JMNTAMBAHAN=" + TXT_JMNTAMBAHAN +"&TXT_CRM= " + TXT_CRM +"' " +
			    " id='framesppk' frameborder='0' width=900 height=1500 ></iframe>"));			
		}
	}
}
