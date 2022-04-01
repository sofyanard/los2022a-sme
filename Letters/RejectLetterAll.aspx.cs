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

namespace SME.Letters
{

	public partial class RejectLetterAll : System.Web.UI.Page
	{
		protected Tools tools = new Tools();
		//protected Connection conn = new Connection("Data Source=10.123.12.30;Initial Catalog=SMEDEV;uid=sa;pwd=");
		protected System.Web.UI.WebControls.Button Button1;
		protected System.Web.UI.WebControls.Button Button2;
		protected string ProductDesc;
	
		protected Connection conn;
		
		
		protected void Page_Load(object sender, System.EventArgs e)
		{
		
			conn = (Connection) Session["Connection"];
					
			if (!IsPostBack)
			{
				//string regno	= "19042004001000001";
				string regno		= Request.QueryString["regno"].ToString();
				Label6.Text = regno;
					
				ViewData(regno);

				setNomorSurat();
						
				TXT_BRANCH1.Text = (string) Session["BranchName"];
				TXT_MANAGER.Text = (string) Session["FullName"];
				TXT_BRANCH2.Text = (string) Session["GroupName"];
			}
		}

		#region Web Form Designer generated code
		override protected void OnInit(EventArgs e)
		{
			InitializeComponent();
			base.OnInit(e);
		}
		
		
		private void InitializeComponent()
		{    

		}
		#endregion

		protected string String1 = "Terima kasih kami sampaikan atas kepercayaan Bapak/Ibu/Saudara"+
						" terhadap  Bank Papua. Setelah memproses permohonan Bapak/Ibu/Saudara"+
						" untuk memperoleh fasilitas kredit,";
	    protected string String2 = " dengan ini kami beritahukan bahwa permohonan Bapak/Ibu/Saudara"+
						" pada saat ini belum dapat kami penuhi.";
		protected string String3 ="Demikian kami sampaikan, kami mengharap Bapak/Ibu/Saudara dapat"+
						" memanfaatkan produk-produk jasa/pelayanan Bank Papua lainnya."+
						" Atas perhatian dan kepercayaan Bapak/Ibu/Saudara pada Bank Papua "+
						"kami sampaikan terima kasih. ";

		private void ViewData(string regno)
		{
			
			conn.QueryString = "select distinct NAMA, ALAMAT, KOTA, ZIPCODE, ALAMAT1, ALAMAT2, ALAMAT3, ZIPDESC " + 
				"from VW_REJECTLETTER_BL " +//VW_REJECT_ALL_PRODUCT "+
				"where AP_REGNO ='" + regno + "'" ;
			conn.ExecuteQuery();		
			
			LBL_CUST_NAME.Text	= conn.GetFieldValue("NAMA");
			//LBL_ADDR.Text		= conn.GetFieldValue("ALAMAT");
			LBL_ADDR.Text		= conn.GetFieldValue("ALAMAT1");
			LBL_ADDR2.Text		= conn.GetFieldValue("ALAMAT2");
			LBL_ADDR3.Text		= conn.GetFieldValue("ALAMAT3");
			LBL_CITY.Text		= conn.GetFieldValue("ZIPDESC") + " " + conn.GetFieldValue("KOTA");
			LBL_POSTCODE.Text	= conn.GetFieldValue("ZIPCODE");
			
			/*
				conn.QueryString = "SELECT  DISTINCT PRODUCTDESC FROM VW_REJECT_ALL_PRODUCT " +
					" WHERE AP_REGNO ='" + regno + "' ";
				conn.ExecuteQuery();
				int jml_product = conn.GetRowCount();
				DataTable dt3 = conn.GetDataTable();
				string[] PROD = new string[jml_product];
				int i = 0;
				foreach(DataRow dr3 in dt3.Rows) 
				{
					PROD[i] = dr3["PRODUCTDESC"].ToString();
					ProductTable.Rows.Add(new TableRow());
					ProductTable.Rows[i].Cells.Add(new TableCell());
					ProductTable.Rows[i].Cells.Add(new TableCell());
			
					ProductTable.Rows[i].Cells[0].Text = (i+1).ToString() + ". ";
					ProductTable.Rows[i].Cells[0].VerticalAlign = VerticalAlign.Top;
					ProductTable.Rows[i].Cells[1].Text = PROD[i];
					i++;
				}
			*/
			LBL_BODY11.Text = String1;
			LBL_BODY12.Text = String2;
			LBL_BODY2.Text = String3;
			conn.QueryString = "SELECT WAKTU = DATENAME(DAY, getDATE())+ ' '+" +
							"DATENAME(MONTH, getDATE()) +' '+ " +
							"DATENAME(YEAR, getDATE())" ;
			conn.ExecuteQuery();
			LBL_CUR_TIME.Text = conn.GetFieldValue("WAKTU");
			
		}
				
		private void setNomorSurat() 
		{
			/* *******************************************************
			* Menentukan NOMOR SURAT untuk REJECT LETTER
			* ********************************************************/
			string no_surat;
			string USERID		= (string) Session["UserID"];

			conn.QueryString = "select * from LETTER where USERID = '"+USERID+"' and AP_REGNO = '"+Request.QueryString["regno"]+"' and LETTERTYPE = '2'";
			conn.ExecuteQuery();
			int nomor		= conn.GetRowCount()+1;
			string Now_Year = System.DateTime.Now.Year.ToString();
			
			string branch = (string) Session["BranchName"];
			no_surat	= branch + "/" + nomor + "/" + Now_Year;
			LBL_NO.Text = no_surat;
			/*----------------------------------------------------------*/	
		}

		protected void PrintBtn_Click(object sender, System.EventArgs e)
		{
		
			Response.Redirect("RejectLetterAllPrint.aspx?regno=" + Label6.Text +  
				"&curtime=" + LBL_CUR_TIME.Text + 
				"&nomor= " + LBL_NO.Text + 
				"&cu_name=" + LBL_CUST_NAME.Text + 
				"&ADDR1=" + LBL_ADDR.Text + 
				"&ADDR2=" + LBL_ADDR2.Text + 
				"&ADDR3=" + LBL_ADDR3.Text + 
				"&CITY=" + LBL_CITY.Text+
				"&MNGR=" + TXT_MANAGER.Text + 
				"&ZIPCODE=" + LBL_POSTCODE.Text +  
				"&BRANCH1=" + TXT_BRANCH1.Text + 
				"&BRANCH2=" + TXT_BRANCH2.Text);
			
			
		}

		protected void BackBtn_Click(object sender, System.EventArgs e)
		{
			Response.Redirect("/SME/InitialDataEntry/FindCustomer.aspx?tc=" + Request.QueryString["tc"] + "&mc=" + Request.QueryString["mc"]);
		}

		

	}
}
