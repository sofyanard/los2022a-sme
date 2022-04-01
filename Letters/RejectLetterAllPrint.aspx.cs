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

	public partial class RejectLetterAllPrint : System.Web.UI.Page
	{
		protected Tools tools = new Tools();
		//protected Connection conn = new Connection("Data Source=10.123.12.30;Initial Catalog=SMEDEV;uid=sa;pwd=");
		protected System.Web.UI.WebControls.Button Button2;
		protected System.Web.UI.WebControls.Button BTN_BACK;
		protected string ProductDesc;
		protected Connection conn;

		protected void Page_Load(object sender, System.EventArgs e)
		{
		conn = (Connection) Session["Connection"];
		
			if (!IsPostBack)
			{
				string regno = Request.QueryString["regno"];
			
				ViewData(regno);
				
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
									
			LBL_NO.Text=Request.QueryString["nomor"].ToString();
			LBL_CUST_NAME.Text	= Request.QueryString["cu_name"].ToString();
			LBL_ADDR.Text		= Request.QueryString["ADDR1"].ToString();
			LBL_ADDR2.Text		= Request.QueryString["ADDR2"].ToString();
			LBL_ADDR3.Text		= Request.QueryString["ADDR3"].ToString();
			LBL_CITY.Text		= Request.QueryString["CITY"].ToString();
			LBL_POSTCODE.Text	= Request.QueryString["ZIPCODE"].ToString();
			
			conn.QueryString = "SELECT  DISTINCT PRODUCTDESC FROM VW_REJECT_ALL_PRODUCT " +
				" WHERE AP_REGNO ='" + regno + "'  ";
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
		
			LBL_BODY11.Text = String1;
			LBL_BODY12.Text = String2;
			
			LBL_BODY2.Text = String3;
			LBL_CUR_TIME.Text = Request.QueryString["curtime"].ToString();
			LBL_MANAGER.Text = Request.QueryString["MNGR"].ToString();
			LBL_BRANCH1.Text = Request.QueryString["BRANCH1"].ToString();
			LBL_BRANCH2.Text = Request.QueryString["BRANCH2"].ToString();
			
		}
		

		private void PrintBtn_Click(object sender, System.EventArgs e)
		{
						Response.Redirect("RejectLetter.aspx");
			
		}

		private void BTN_BACK_Click(object sender, System.EventArgs e)
		{
		
		}
	
	}
}
