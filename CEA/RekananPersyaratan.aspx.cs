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
using System.Configuration;
using DMS.DBConnection;
using DMS.CuBESCore;
using Microsoft.VisualBasic;

namespace SME.CEA
{
	/// <summary>
	/// Summary description for RekananPersyaratan.
	/// </summary>
	public partial class RekananPersyaratan : System.Web.UI.Page
	{
		protected Connection conn;
		protected Tools tool = new Tools();
		
		//protected Deduplication dedup = new Deduplication();
		private string theForm, theObj;
		protected Table TBL = new Table();
		
		

	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			conn = (Connection) Session["Connection"];

			if (Request.QueryString.Count > 0)
			{	
				theForm = Request.QueryString["theForm"];
				theObj = Request.QueryString["theObj"];
			}	
			//Response.Write(theForm+" "+theObj);

			conn.QueryString = "select jenis, subjenis from rekanan_persyaratan where rekanantypeid='" + Request.QueryString["rekanantypeid"] + "'";
			conn.ExecuteQuery();
            
			FillGrid();

			/*for(int i=0; i<conn.GetRowCount(); i++) 
			{
				TableRow tr = new TableRow();
				TableCell tc1 = new TableCell();
				TableCell tc2 = new TableCell();
				//TableCell tc3 = new TableCell();

				Label LBL_NO = new Label();
				Label LBL_DESC = new Label();
				//CheckBox CB_NILAI= new CheckBox();

				LBL_NO.Text = conn.GetFieldValue(i, "jenis") + "  ";
				LBL_DESC.Text = conn.GetFieldValue(i, "subjenis") + "  ";
				
				//CB_NILAI.Checked = Convert.ToBoolean(INT_NILAI);

				tc1.Controls.Add(LBL_NO);
				tc2.Controls.Add(LBL_DESC);

				tr.Cells.Add(tc1);
				tr.Cells.Add(tc2);
				//tr.Cells.Add(tc3);
					
				TBL.Rows.Add(tr);
			}
				
			this.PH_ARTIKEL.Controls.Add(TBL); */

			
		}

		private void FillGrid()
		{
			conn.QueryString = "select jenis, subjenis from rekanan_persyaratan where rekanantypeid='" + Request.QueryString["rekanantypeid"] + "'";
			conn.ExecuteQuery();
			DataTable dt = new DataTable();
			dt = conn.GetDataTable().Copy();
			DatGrd.DataSource = dt;
			try 
			{
				DatGrd.DataBind();
			} 
			catch 
			{
				DatGrd.CurrentPageIndex = 0;
				DatGrd.DataBind();
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
	}
}
