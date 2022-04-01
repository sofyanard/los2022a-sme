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

	public partial class RejectLetter : System.Web.UI.Page
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
				
				string regno		= Request.QueryString["regno"];
		
				Label6.Text = regno;
		
				ViewData(regno);
				ViewTabel(regno);

				TXT_BRANCH.Text = (string) Session["BranchName"];
				TXT_MANAGER.Text = (string) Session["FullName"];
				TXT_GROUP.Text = (string) Session["GroupName"];

				setNomorSurat();
			}
			BTN_BACK.Click += new EventHandler(BTN_BACK_Click);
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
						" terhadap  Bank Papua. Setelah memproses permohonan Bapak/Ibu/Saudara "+
						"untuk memperoleh fasilitas kredit:";
	    protected string String2 = "dengan ini kami beritahukan bahwa permohonan Bapak/Ibu/Saudara"+
						" pada saat ini belum dapat kami penuhi.";
		protected string String3 ="Demikian kami sampaikan, kami mengharap Bapak/Ibu/Saudara dapat"+
						" memanfaatkan produk-produk jasa/pelayanan Bank Papua lainnya."+
						" Atas perhatian dan kepercayaan Bapak/Ibu/Saudara pada Bank Papua "+
						"kami sampaikan terima kasih. ";

		private void ViewData(string regno)
		{

			/*
			conn.QueryString = "select distinct NAMA, ALAMAT, KOTA, ZIPCODE from VW_REJECT_ALL_PRODUCT "+
				"where AP_REGNO ='" + regno + "' and apptype='" + Request.QueryString["apptype"] + "' and productid='" + Request.QueryString["prodid"] + "'";
			*/
			conn.QueryString = "select distinct NAMA, ALAMAT, KOTA, ZIPCODE, ALAMAT1, ALAMAT2, ALAMAT3, ZIPDESC " + 
				"from VW_REJECT_ALL_PRODUCT "+
				"where AP_REGNO ='" + regno + "'";
			conn.ExecuteQuery();				
			
			LBL_CUST_NAME.Text	= conn.GetFieldValue("NAMA");
			//LBL_ADDR.Text		= conn.GetFieldValue("ALAMAT");
			LBL_ADDR.Text		= conn.GetFieldValue("ALAMAT1");
			LBL_ADDR2.Text		= conn.GetFieldValue("ALAMAT2");
			LBL_ADDR3.Text		= conn.GetFieldValue("ALAMAT3");
			LBL_CITY.Text		= conn.GetFieldValue("ZIPDESC") + " " + conn.GetFieldValue("KOTA");
			LBL_POSTCODE.Text	= conn.GetFieldValue("ZIPCODE");
					
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
			* Menentukan NOMOR SURAT untuk AIP LETTER
			* ********************************************************/
			string no_surat;
			string USERID		= (string) Session["UserID"];

			conn.QueryString = "select * from LETTER where USERID = '"+USERID+"' and AP_REGNO = '"+Request.QueryString["regno"]+"' and LETTERTYPE = '2'";
			conn.ExecuteQuery();
			int nomor		= conn.GetRowCount()+1;
			string Now_Year = System.DateTime.Now.Year.ToString();
				
			no_surat	= TXT_BRANCH.Text + "/" + nomor + "/" + Now_Year;
			LBL_NO.Text = no_surat;
			/*----------------------------------------------------------*/	
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
					Tabelj.Rows[jk].Cells[0].Controls.Add(new LiteralControl("&nbsp&nbsp&nbsp"));
					Tabelj.Rows[jk].Cells[1].Controls.Add(new LiteralControl("<LI>"));
					Tabelj.Rows[jk].Cells[2].Controls.Add(LBL_PRODUCTDESC);
					Tabelj.Rows[jk].Cells[1].Font.Size = FontUnit.XSmall;
					Tabelj.Rows[jk].Cells[2].Font.Size = FontUnit.XSmall;
					Tabelj.Rows[jk].VerticalAlign = VerticalAlign.Top;
				
					PH1.Controls.Add(Tabelj);
				}
		
			}
		}	
                
							

		protected void PrintBtn_Click(object sender, System.EventArgs e)
		{
			Response.Redirect("RejectLetterPrint.aspx?regno=" + Request.QueryString["regno"] +  "&curtime=" + LBL_CUR_TIME.Text +
				"&apptype=" + Request.QueryString["apptype"] + "&prodid=" + Request.QueryString["prodid"] +
				"&nomor=" + LBL_NO.Text + "&cu_name=" + LBL_CUST_NAME.Text + 
				"&ADDR1=" + LBL_ADDR.Text + 
				"&ADDR2=" + LBL_ADDR2.Text + 
				"&ADDR3=" + LBL_ADDR3.Text + 
				"&CITY=" + LBL_CITY.Text+"&MNGR=" + TXT_MANAGER.Text + "&ZIPCODE=" + LBL_POSTCODE.Text +  
				"&BRANCH1=" + TXT_BRANCH.Text + 
				"&BRANCH2=" + TXT_GROUP.Text);
			
		}

		protected void BTN_BACK_Click(object sender, EventArgs e)
		{
			if ((Request.QueryString["presco"] != null) && (Request.QueryString["presco"] != ""))
			{
				Response.Write("<script language='JavaScript1.2'>window.close();</script>");
				//Response.Redirect("/SME/InitialDataEntry/PreScoringResult.aspx?regno=" + Request.QueryString["regno"] + "&curef=" + Request.QueryString["curef"]+ "&mc=" + Request.QueryString["mc"] + "&tc=" + Request.QueryString["tc"] + "&prog=" + Request.QueryString["prog"]);
			}
			else
			{
				Response.Redirect("/SME/SPPK/ListReject.aspx?tc="+Request.QueryString["tc"]+"&mc="+Request.QueryString["mc"]);
			}
		}
	}
}
