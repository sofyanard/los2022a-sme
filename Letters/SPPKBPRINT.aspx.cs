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

namespace SME.SPPK
{
	/// <summary>
	/// Summary description for SPPKBPRINT.
	/// </summary>
	public partial class SPPKBPRINT : System.Web.UI.Page
	{
		protected Connection conn;// = new Connection("Data Source=10.123.12.30;Initial Catalog=SMEDEV;uid=sa;pwd=");
		protected int tinggi,jml_tipeproduct,t1,t2,t3;
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
			
			string TXT_NO, TXT_CURTIME, TXT_LAMP;
			string TXT_CUST_NAME, TXT_ADDR ,TXT_ADDR2,TXT_ADDR3,TXT_CITY,TXT_POSTCODE;
			string TXT_AP_DATE,TXT_BRANCH,TXT_MANAGER;
			string TXT_BRANCHMANAGER,TXT_CRM; 
			string TXT_TEMBUSAN;
			string TXT_MATERAI;

			TXT_NO = Request.QueryString["TXT_NO"];
			TXT_CURTIME = Request.QueryString["TXT_CURTIME"];
			TXT_LAMP = Request.QueryString["TXT_LAMP"];
			TXT_CUST_NAME = Request.QueryString["TXT_CUST_NAME"];
			TXT_ADDR = Request.QueryString["TXT_ADDR"];
			TXT_ADDR2 = Request.QueryString["TXT_ADDR2"];
			TXT_ADDR3 = Request.QueryString["TXT_ADDR3"];
			TXT_CITY = Request.QueryString["TXT_CITY"];
			TXT_POSTCODE = Request.QueryString["TXT_POSTCODE"];
			TXT_AP_DATE = Request.QueryString["TXT_AP_DATE"];
			TXT_BRANCH = Request.QueryString["TXT_BRANCH"];
			TXT_MANAGER = Request.QueryString["TXT_MANAGER"];
			TXT_BRANCHMANAGER = Request.QueryString["TXT_BRANCHMANAGER"];
			TXT_CRM = Request.QueryString["TXT_CRM"];
			TXT_TEMBUSAN = Request.QueryString["TXT_TEMBUSAN"];
			TXT_MATERAI = Request.QueryString["TXT_MATERAI"];
		
			//string regno	= "19042004001000001";
			string regno = Request.QueryString["regno"];
			conn.QueryString = "SELECT  DISTINCT PRODUCTID,PRODUCTDESC FROM VW_SPPK_VIEW2" +
				" WHERE AP_REGNO ='" + regno + "'";
			conn.ExecuteQuery();
			int jml_product = conn.GetRowCount();

			string[] PRODUCTDESC = new string[jml_product];
			int p = 0;
			DataTable dt = conn.GetDataTable();
			foreach(DataRow dr in dt.Rows) 
			{
				PRODUCTDESC[p] = dr["PRODUCTDESC"].ToString();
				p++;
			}
					
			
			for (int k = 0 ; k < jml_product ; k++)
			{
				conn.QueryString = "SELECT distinct APPTYPEDESC " +
					" 	FROM VW_SPPK_VIEW2	"+
					" WHERE AP_REGNO ='" + regno + "' AND PRODUCTDESC= '" +PRODUCTDESC[k]+ "' ";
				conn.ExecuteQuery();
			
				jml_tipeproduct = conn.GetRowCount();
				
				string [,] TXT_CP_LIMIT = new string[jml_product,jml_tipeproduct];
				string [,] TXT_CP_TENOR = new string[jml_product,jml_tipeproduct];
				string [,] TXT_REVOLVING = new string[jml_product, jml_tipeproduct];
				string [,] TXT_TGL1 = new string[jml_product,jml_tipeproduct];
				string [,] TXT_THN1 = new string[jml_product,jml_tipeproduct];
				string [,] TXT_TGL2 = new string[jml_product, jml_tipeproduct];
				string [,] TXT_THN2 = new string[jml_product, jml_tipeproduct];
				string [,] DDL_BLN1 = new string[jml_product, jml_tipeproduct];
				string [,] DDL_BLN2 = new string[jml_product, jml_tipeproduct];
				string [,] TXT_CP_INSTALLMENT = new string[jml_product, jml_tipeproduct];
				string [,] TXT_SUKUBUNGA = new string[jml_product, jml_tipeproduct];
				string [,] TXT_SUKUBUNGA_DUEDATE = new string[jml_product, jml_tipeproduct];
				string [,] TXT_PROVISI = new string[jml_product, jml_tipeproduct];
				string [,] waktu1 = new string[jml_product, jml_tipeproduct];
				string [,] waktu2 = new string[jml_product, jml_tipeproduct];
				string [,] TXT_TAHUNTARGET = new string[jml_product, jml_tipeproduct];
				string [,] TXT_ANGKATARGET = new string[jml_product, jml_tipeproduct];
				string [,] TXT_STOCK1 = new string[jml_product, jml_tipeproduct];
				string [,] TXT_PIUTANG = new string[jml_product, jml_tipeproduct];
				string [,] TXT_KMK1 = new string[jml_product, jml_tipeproduct];
				string [,] TXT_KM1 = new string[jml_product, jml_tipeproduct];
				string [,] TXT_SF1 = new string[jml_product, jml_tipeproduct];
				string [,] LBL_JAMINANUTAMA = new string[jml_product, jml_tipeproduct];
				string [,] LBL_JAMINANTAMBAHAN = new string[jml_product, jml_tipeproduct];
				for (int i = 0 ; i < jml_tipeproduct ; i++)
				{
					TXT_CP_LIMIT[k,i] = Request.QueryString["TXT_CP_LIMIT"+k+i];
					TXT_CP_TENOR[k,i] = Request.QueryString["TXT_CP_TENOR"+k+i];
					TXT_REVOLVING[k,i] = Request.QueryString["TXT_REVOLVING"+k+i];
				
					TXT_TGL1[k,i] = Request.QueryString["TXT_TGL1"+k+i];
					TXT_THN1[k,i] = Request.QueryString["TXT_THN1"+k+i];
					TXT_TGL2[k,i] = Request.QueryString["TXT_TGL2"+k+i];
					TXT_THN2[k,i] = Request.QueryString["TXT_THN2"+k+i];
								
					waktu1[k,i]= Request.QueryString["waktu1"+k+i];
					waktu2[k,i]= Request.QueryString["waktu2"+k+i];

					TXT_CP_INSTALLMENT[k,i] = Request.QueryString["TXT_CP_INSTALLMENT"+k+i];

					TXT_SUKUBUNGA[k,i] = Request.QueryString["SUKUBUNGA"+k+i];
					TXT_SUKUBUNGA_DUEDATE[k,i] = Request.QueryString["TXT_SUKUBUNGA_DUEDATE"+k+i];
					TXT_PROVISI[k,i] = Request.QueryString["TXT_PROVISI"+k+i];		
				
					TXT_TAHUNTARGET[k,i] = Request.QueryString["TXT_TAHUNTARGET"+k+i];
					TXT_ANGKATARGET[k,i] = Request.QueryString["TXT_ANGKATARGET"+k+i];	

					TXT_STOCK1[k,i] = Request.QueryString["TXT_STOCK1"+k+i];
					TXT_PIUTANG[k,i] = Request.QueryString["TXT_PIUTANG"+k+i];
					TXT_KMK1[k,i] = Request.QueryString["TXT_KMK1"+k+i];
					TXT_KM1[k,i] = Request.QueryString["TXT_KM1"+k+i];

					TXT_SF1[k,i] = Request.QueryString["TXT_SF1"+k+i];
					
					
					Label1.Text += "&TXT_CP_LIMIT" + k.ToString() + i.ToString() + "=" + TXT_CP_LIMIT[k,i] +
						"&TXT_CP_TENOR" + k.ToString() + i.ToString() + "=" + TXT_CP_TENOR[k,i] +
						"&TXT_REVOLVING" + k.ToString() + i.ToString() + "=" + TXT_REVOLVING[k,i] +
						"&WAKTU1" + k.ToString()+i.ToString() + "= " + waktu1[k,i] + 
						"&WAKTU2" + k.ToString()+i.ToString() + "= " + waktu2[k,i] +
						"&TXT_CP_INSTALLMENT" + k.ToString() + i.ToString() + "=" + TXT_CP_INSTALLMENT[k,i] +
						"&SUKUBUNGA" + k.ToString()+i.ToString() + "= " + TXT_SUKUBUNGA[k,i] + 
						"&TXT_SUKUBUNGA_DUEDATE" + k.ToString() + i.ToString() + "=" + TXT_SUKUBUNGA_DUEDATE[k,i] +
						"&TXT_PROVISI" + k.ToString()+i.ToString() + "= " + TXT_PROVISI[k,i] + 
						"&TXT_TAHUNTARGET" + k.ToString() + i.ToString() +  "= " + TXT_TAHUNTARGET[k,i] + "&TXT_ANGKATARGET" + k.ToString() + i.ToString() +  "= " + TXT_ANGKATARGET[k,i] + 
						"&TXT_STOCK1" + k.ToString()+i.ToString() + "= " + TXT_STOCK1[k,i] +"&TXT_PIUTANG" + k.ToString() + i.ToString() +  "= " + TXT_PIUTANG[k,i] +
						"&TXT_KMK1" + k.ToString() + i.ToString() +  "= " + TXT_KMK1[k,i] +"&TXT_KM1" + k.ToString() + i.ToString() +  "= " + TXT_KM1[k,i] +
						"&TXT_SF1" + k.ToString() + i.ToString() +  "= " + TXT_SF1[k,i] ;
					t1= jml_tipeproduct*1500;
					}
				t2=t1*jml_product;
				}
			tinggi = t2+100;
			
			//---------------------------------------------------------------
			// Untuk mem-pass TEMBUSAN
			//----------------------------------------------------------------
			int jumtembusan;
			string TEMBUSAN = "";
			try 
			{
				jumtembusan = Convert.ToInt16(Request.QueryString["JUMTEMBUSAN"]);
			}
			catch 
			{
				jumtembusan = 0;
			}
			for (int i=1; i<=jumtembusan; i++) 
			{
				TEMBUSAN = TEMBUSAN + "&TXT_TEMBUSAN" + i + "=" + Request.QueryString["TXT_TEMBUSAN"+i];
			}			
			//----------------------------------------------------------------

			this.PH1.Controls.Add(new LiteralControl("<iframe src='SPPKPrint.aspx?TXT_NO=" + TXT_NO + "&TXT_CURTIME=" + TXT_CURTIME + "&TXT_LAMP=" + TXT_LAMP + 
				"&TXT_CUST_NAME=" + TXT_CUST_NAME + 
				"&TXT_ADDR=" + TXT_ADDR+ 
				"&TXT_ADDR2=" + TXT_ADDR2+ 
				"&TXT_ADDR3=" + TXT_ADDR3+ 
				"&TXT_CITY=" + TXT_CITY + 
				"&TXT_POSTCODE=" + TXT_POSTCODE +
				"&TXT_AP_DATE=" + TXT_AP_DATE +"&TXT_BRANCH=" + TXT_BRANCH + "&TXT_MANAGER=" + TXT_MANAGER +
				"&TXT_BRANCHMANAGER=" + TXT_BRANCHMANAGER +"&TXT_CRM=" + TXT_CRM + Label1.Text + TEMBUSAN + "&JUMTEMBUSAN=" + jumtembusan + 
				"&TXT_MATERAI=" + TXT_MATERAI +
				"&regno=" + regno + "'" +
				" id='framesppk' frameborder='0' width='900px' height='" + tinggi +"px'></iframe>"));			
		}
	}
}
