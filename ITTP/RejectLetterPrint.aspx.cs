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
namespace SME.ITTP
{
	/// <summary>
	/// Summary description for RejectLetterPrint.
	/// </summary>
	public partial class RejectLetterPrint : System.Web.UI.Page
	{
		protected string ProductDesc;
		protected Connection conn;
		protected Tools tools = new Tools();
		//protected Connection conn = new Connection("Data Source=10.123.12.30;Initial Catalog=SMEDEV;uid=sa;pwd=");
		protected System.Web.UI.WebControls.Button Button2;
		protected System.Web.UI.WebControls.Button BTN_BACK;

		protected void Page_Load(object sender, System.EventArgs e)
		{
			conn = (Connection) Session["Connection"];
		
			if (!IsPostBack)
			{
				string regno = Request.QueryString["regno"];
							
				ViewData();
				ViewTabel(regno);				
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
			" terhadap  Bank Mandiri. Setelah memproses permohonan Bapak/Ibu/Saudara"+
			" untuk memperoleh fasilitas kredit:";
		protected string String2 = "dengan ini kami beritahukan bahwa permohonan Bapak/Ibu/Saudara"+
			" pada saat ini belum dapat kami penuhi.";
		protected string String3 ="Demikian kami sampaikan, kami mengharap Bapak/Ibu/Saudara dapat"+
			" memanfaatkan produk-produk jasa/pelayanan Bank Mandiri lainnya."+
			" Atas perhatian dan kepercayaan Bapak/Ibu/Saudara pada Bank Mandiri "+
			"kami sampaikan terima kasih. ";

		private void ViewData()
		{
									
			LBL_NO.Text=Request.QueryString["nomor"].ToString();
			LBL_CUST_NAME.Text	= Request.QueryString["cu_name"].ToString();
			LBL_ADDR.Text		= Request.QueryString["ADDR1"].ToString();
			LBL_ADDR2.Text		= Request.QueryString["ADDR2"].ToString();
			LBL_ADDR3.Text		= Request.QueryString["ADDR3"].ToString();
			LBL_CITY.Text		= Request.QueryString["CITY"].ToString();
			LBL_POSTCODE.Text	= Request.QueryString["ZIPCODE"].ToString();
			
					
			LBL_BODY11.Text = String1;
			LBL_BODY12.Text = String2;
			
			LBL_BODY2.Text = String3;
			LBL_CUR_TIME.Text = Request.QueryString["curtime"].ToString();
			LBL_MANAGER.Text = Request.QueryString["MNGR"].ToString();
			LBL_BRANCH1.Text = Request.QueryString["BRANCH1"].ToString();
			LBL_BRANCH2.Text = Request.QueryString["BRANCH2"].ToString();
		
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

		private void PrintBtn_Click(object sender, System.EventArgs e)
		{
			Response.Redirect("RejectLetter.aspx");			
		}

		private void ViewTabel(string regno)
		{
			/*----- Modified by Yudi (28/07/2004) ------------
						conn.QueryString = "SELECT  DISTINCT APPTYPEDESC FROM VW_REJECT_ALL_PRODUCT" +
							" WHERE AP_REGNO ='" + regno + "'  and apptype='" + Request.QueryString["apptype"] + "' and productid='" + Request.QueryString["prodid"] + "'";
						*/
			conn.QueryString = "SELECT  distinct APPTYPEID, APPTYPEDESC FROM VW_SPPK_REJECT " +
				" WHERE AP_REGNO ='" + regno + "'";
			conn.ExecuteQuery();
			int jml_tipe = conn.GetRowCount();

			
			string[] APPTYPEDESC = new string[jml_tipe];	
			string[] APPTYPEID = new string[jml_tipe];			//----- Modified by Yudi (28/07/2004)
			int p = 0;
			DataTable dt = conn.GetDataTable();
			foreach(DataRow dr in dt.Rows) 
			{
				APPTYPEDESC[p]	= dr["APPTYPEDESC"].ToString();
				APPTYPEID[p]	= dr["APPTYPEID"].ToString();					   //----- Modified by Yudi (28/07/2004) 
				p++;
			}
			

			for (int u = 0 ; u < jml_tipe; u++)
			{				
				Label LBL_NO = new Label();
				LBL_NO.Text = (u+1)+ ". ";
				LBL_NO.Font.Bold = true;

				Label LBL_APPTYPEDESC = new Label();
				LBL_APPTYPEDESC.ID = "LBL_APPTYPEDESC"+u;
				LBL_APPTYPEDESC.Text = APPTYPEDESC[u];
				LBL_APPTYPEDESC.Font.Bold = true;
				LBL_APPTYPEDESC.Font.Underline = true;

				Table Tabelm = new Table();
				Tabelm.ID = "Tabelm"+u;
				int mn = 0;
				Tabelm.Rows.Add(new TableRow());
				Tabelm.Rows[mn].Cells.Add (new TableCell());
				Tabelm.Rows[mn].Cells.Add (new TableCell());
				Tabelm.Rows[mn].Cells[0].Controls.Add(LBL_NO);
				Tabelm.Rows[mn].Cells[1].Controls.Add(LBL_APPTYPEDESC);
				Tabelm.Rows[mn].Cells[0].Font.Size = FontUnit.XSmall;
				Tabelm.Rows[mn].Cells[1].Font.Size = FontUnit.XSmall;
				Tabelm.Rows[mn].VerticalAlign = VerticalAlign.Top;
				
				PH1.Controls.Add(Tabelm);
			
				/*   ----- Modified by Yudi (28/07/2004) -----------
				conn.QueryString = "SELECT distinct PRODUCTDESC " +
					" 	FROM VW_SPPK_VIEW2	"+
					" WHERE AP_REGNO ='" + regno + "' AND APPTYPEDESC= '" +APPTYPEDESC[u]+ "' ";
				*/
				conn.QueryString = "select * from VW_SPPK_REJECT where AP_REGNO = '"+regno+"' and APPTYPEID = '"+APPTYPEID[u]+"'";
				conn.ExecuteQuery();
			
				int jml_product = conn.GetRowCount();

				string[] PRODUCTID		= new string[jml_product];	//   ----- Modified by Yudi (28/07/2004) -----------
				string[] PRODUCTDESC	= new string[jml_product];
				int y = 0;
				DataTable dt3 = conn.GetDataTable();
				foreach(DataRow dr3 in dt3.Rows) 
				{
					PRODUCTID[y]	= dr3["PRODUCTID"].ToString();				//   ----- Modified by Yudi (28/07/2004) -----------
					PRODUCTDESC[y]	= dr3["PRODUCTDESC"].ToString();
					y++;
				}
			
				for (int i=0; i < jml_product; i++)
				{
					Table Tabelj = new Table();									
					Tabelj = new Table();
					Tabelj.ID = "Tabelj"+u+i;
										
					Label LBL_PRODUCTDESC = new Label();
					LBL_PRODUCTDESC.ID = "LBL_PRODUCTDESC"+u+i;
					LBL_PRODUCTDESC.Text = PRODUCTDESC[i];
														
					int jk = 0;
					Tabelj.Rows.Add(new TableRow());
					Tabelj.Rows[jk].Cells.Add (new TableCell());
					Tabelj.Rows[jk].Cells.Add (new TableCell());
					Tabelj.Rows[jk].Cells.Add (new TableCell());
					Tabelj.Rows[jk].Cells[0].Controls.Add(new LiteralControl("&nbsp;&nbsp;&nbsp;"));
					Tabelj.Rows[jk].Cells[1].Controls.Add(new LiteralControl("<LI>"));
					Tabelj.Rows[jk].Cells[2].Controls.Add(LBL_PRODUCTDESC);
					Tabelj.Rows[jk].Cells[1].Font.Size = FontUnit.XSmall;
					Tabelj.Rows[jk].Cells[2].Font.Size = FontUnit.XSmall;
					Tabelj.Rows[jk].VerticalAlign = VerticalAlign.Top;
				
					PH1.Controls.Add(Tabelj);
				}
		
			}

			/*----- Modified by Yudi (28/07/2004) --------------
			conn.QueryString = "SELECT  DISTINCT APPTYPEDESC FROM VW_REJECT_ALL_PRODUCT" +
				" WHERE AP_REGNO ='" + regno + "'  and apptype='" + Request.QueryString["apptype"] + "' and productid='" + Request.QueryString["prodid"] + "'";
			*/			
			/*
			conn.ExecuteQuery();
			int jml_tipe = conn.GetRowCount();

			
			string[] APPTYPEDESC = new string[jml_tipe];
			int p = 0;
			DataTable dt = conn.GetDataTable();
			foreach(DataRow dr in dt.Rows) 
			{
				APPTYPEDESC[p] = dr["APPTYPEDESC"].ToString();
				p++;
			}
			

			for (int u = 0 ; u < jml_tipe; u++)
			{
				
				Label LBL_NO = new Label();
				LBL_NO.Text = (u+1)+ ". ";
				LBL_NO.Font.Bold = true;
				Label LBL_APPTYPEDESC = new Label();
				LBL_APPTYPEDESC.ID = "LBL_APPTYPEDESC"+u;
				LBL_APPTYPEDESC.Text = APPTYPEDESC[u];
				LBL_APPTYPEDESC.Font.Bold = true;
				LBL_APPTYPEDESC.Font.Underline = true;
				Table Tabelm = new Table();
				Tabelm.ID = "Tabelm"+u;
				int mn = 0;
				Tabelm.Rows.Add(new TableRow());
				Tabelm.Rows[mn].Cells.Add (new TableCell());
				Tabelm.Rows[mn].Cells.Add (new TableCell());
				Tabelm.Rows[mn].Cells[0].Controls.Add(LBL_NO);
				Tabelm.Rows[mn].Cells[1].Controls.Add(LBL_APPTYPEDESC);
				Tabelm.Rows[mn].Cells[0].Font.Size = FontUnit.XSmall;
				Tabelm.Rows[mn].Cells[1].Font.Size = FontUnit.XSmall;
				Tabelm.Rows[mn].VerticalAlign = VerticalAlign.Top;
				
				PH1.Controls.Add(Tabelm);

				conn.QueryString = "SELECT distinct PRODUCTDESC " +
					" 	FROM VW_SPPK_VIEW2	"+
					" WHERE AP_REGNO ='" + regno + "' AND APPTYPEDESC= '" +APPTYPEDESC[u]+ "' ";
				conn.ExecuteQuery();
			
				int jml_product = conn.GetRowCount();

				string[] PRODUCTDESC = new string[jml_product];
				int y = 0;
				DataTable dt3 = conn.GetDataTable();
				foreach(DataRow dr3 in dt3.Rows) 
				{
					PRODUCTDESC[y] = dr3["PRODUCTDESC"].ToString();
					y++;
				}
			
				for (int i=0; i < jml_product; i++)
				{
					Table Tabelj = new Table();									
					Tabelj = new Table();
					Tabelj.ID = "Tabelj"+u+i;
										
					Label LBL_PRODUCTDESC = new Label();
					LBL_PRODUCTDESC.ID = "LBL_PRODUCTDESC"+u+i;
					LBL_PRODUCTDESC.Text = PRODUCTDESC[i];
					
									
					int jk = 0;
					Tabelj.Rows.Add(new TableRow());
					Tabelj.Rows[jk].Cells.Add (new TableCell());
					Tabelj.Rows[jk].Cells.Add (new TableCell());
					Tabelj.Rows[jk].Cells[0].Text = " * ";
					Tabelj.Rows[jk].Cells[1].Controls.Add(LBL_PRODUCTDESC);
					Tabelj.Rows[jk].Cells[0].Font.Size = FontUnit.XSmall;
					Tabelj.Rows[jk].Cells[1].Font.Size = FontUnit.XSmall;
					Tabelj.Rows[jk].VerticalAlign = VerticalAlign.Top;
				
					PH1.Controls.Add(Tabelj);
				}
		
			}
			*/

		}

		protected void BTN_PRINT_ServerClick(object sender, System.EventArgs e)
		{
			string USERID = (string) Session["UserID"];
			string REGNO  = Request.QueryString["regno"];

			conn.QueryString = "exec IDE_LETTERNO_INSERT '"+REGNO+"','2','"+Request.QueryString["nomor"]+"','"+USERID+"'";
			conn.ExecuteQuery();
		}	
            
	
	}
}
