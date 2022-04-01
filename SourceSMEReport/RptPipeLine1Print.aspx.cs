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
using DMS.CuBESCore;
using DMS.DBConnection;
using Microsoft.VisualBasic;

namespace SME.SourceSMEReport
{
	/// <summary>
	/// Summary description for RptPipeLine1Print.
	/// </summary>
	public partial class RptPipeLine1Print : System.Web.UI.Page
	{
		protected Connection Conn = new Connection();
		protected Tools tools = new Tools();
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			Conn = (Connection) Session["Connection"];
			string sql_kondisi = Request.QueryString["sql_kondisi"];
			string region = Request.QueryString["region"];
			string businessunit = Request.QueryString["businessunit"];
			Load_Data(sql_kondisi, region, businessunit);
		}
        
		private void Load_Data(string sql_kondisi, string region, string businessunit)
		{
			int k = 0;
			string pre_area="";
			double sLmt_Of_PB_BU=0, sNbr_Of_PB_BU=0, sLmt_Of_RN_BU=0,sNbr_Of_RN_BU=0,sLmt_Of_LmtChg_BU=0,sNbr_Of_LmtChg_BU=0,sLmt_Of_PB_CRM=0,sNbr_Of_PB_CRM=0,sLmt_Of_RN_CRM=0,sNbr_Of_RN_CRM=0,sLmt_Of_LmtChg_CRM=0,sNbr_Of_LmtChg_CRM=0,sLmt_Of_PB_CO=0,sNbr_Of_PB_CO=0,sLmt_Of_RN_CO=0,sNbr_Of_RN_CO=0,sLmt_Of_LmtChg_CO=0,sNbr_Of_LmtChg_CO=0, sLmt_Of_PB=0,sNbr_Of_PB=0,sLmt_Of_RN=0,sNbr_Of_RN=0,sLmt_Of_LmtChg=0,sNbr_Of_LmtChg=0,sLmt_Of_PB_BOOK=0,sNbr_Of_PB_BOOK=0,sLmt_Of_RN_BOOK=0,sNbr_Of_RN_BOOK=0,sLmt_Of_LmtChg_BOOK=0,sNbr_Of_LmtChg_BOOK=0;
			double tLmt_Of_PB_BU=0, tNbr_Of_PB_BU=0, tLmt_Of_RN_BU=0, tNbr_Of_RN_BU=0, tLmt_Of_LmtChg_BU=0, tNbr_Of_LmtChg_BU=0, tLmt_Of_PB_CRM=0, tNbr_Of_PB_CRM=0, tLmt_Of_RN_CRM=0, tNbr_Of_RN_CRM=0, tLmt_Of_LmtChg_CRM=0, tNbr_Of_LmtChg_CRM=0, tLmt_Of_PB_CO=0, tNbr_Of_PB_CO=0, tLmt_Of_RN_CO=0, tNbr_Of_RN_CO=0, tLmt_Of_LmtChg_CO=0, tNbr_Of_LmtChg_CO=0, tLmt_Of_PB=0, tNbr_Of_PB=0, tLmt_Of_RN=0, tNbr_Of_RN=0, tLmt_Of_LmtChg=0, tNbr_Of_LmtChg=0, tLmt_Of_PB_BOOK=0, tNbr_Of_PB_BOOK=0, tLmt_Of_RN_BOOK=0, tNbr_Of_RN_BOOK=0, tLmt_Of_LmtChg_BOOK=0, tNbr_Of_LmtChg_BOOK=0;

			Conn.QueryString = "select bussunitdesc from rfbusinessunit where bussunitid='" + businessunit.ToString() + "'";
			Conn.ExecuteQuery();
			if (Conn.GetRowCount()>0)
			{
				LBL_BUSINESSUNIT.Text =  Conn.GetFieldValue(0,"bussunitdesc");
			}
			else
			{	
				LBL_BUSINESSUNIT.Text =  "All";
			}

			LBL_PERIODE.Text = tools.FormatDate(DateAndTime.Today.ToString(),false);

			Conn.QueryString = "EXEC Rpt_PipeLine1 '" + sql_kondisi + "' ";
			Conn.ExecuteQuery();
			for (int i = 0; i < Conn.GetRowCount(); i++)
			{
				if (pre_area.ToString()!=Conn.GetFieldValue(i,"areaname"))
				{
					if (i.ToString()!="0")
					{
						TBL_CONTENT.Rows.Add(new TableRow());
						TBL_CONTENT.Rows[i + k + 4].Cells.Add(new TableCell());
						TBL_CONTENT.Rows[i + k + 4].Cells[0].Text = "&nbsp;";
						TBL_CONTENT.Rows[i + k + 4].Cells[0].HorizontalAlign = HorizontalAlign.Center;
						TBL_CONTENT.Rows[i + k + 4].Cells[0].CssClass= "ItemPrint_d";

						TBL_CONTENT.Rows[i + k + 4].Cells.Add(new TableCell());
						TBL_CONTENT.Rows[i + k + 4].Cells[1].Font.Bold=true;
						TBL_CONTENT.Rows[i + k + 4].Cells[1].Text = "&nbsp;SUB TOTAL&nbsp;";
						TBL_CONTENT.Rows[i + k + 4].Cells[1].HorizontalAlign = HorizontalAlign.Center;
						TBL_CONTENT.Rows[i + k + 4].Cells[1].CssClass= "ItemPrint_d";

						TBL_CONTENT.Rows[i + k + 4].Cells.Add(new TableCell());
						TBL_CONTENT.Rows[i + k + 4].Cells[2].Text = "&nbsp;" ;
						TBL_CONTENT.Rows[i + k + 4].Cells[2].HorizontalAlign = HorizontalAlign.Left;
						TBL_CONTENT.Rows[i + k + 4].Cells[2].CssClass= "ItemPrint_d";

						//BusinessUnit
						TBL_CONTENT.Rows[i + k + 4].Cells.Add(new TableCell());
						TBL_CONTENT.Rows[i + k + 4].Cells[3].Font.Bold=true;
						TBL_CONTENT.Rows[i + k + 4].Cells[3].Text = "&nbsp;" + tools.ConvertCurr(sLmt_Of_PB_BU.ToString()) + "&nbsp;";
						TBL_CONTENT.Rows[i + k + 4].Cells[3].HorizontalAlign = HorizontalAlign.Right;
						TBL_CONTENT.Rows[i + k + 4].Cells[3].CssClass= "ItemPrint_d";

						TBL_CONTENT.Rows[i + k + 4].Cells.Add(new TableCell());
						TBL_CONTENT.Rows[i + k + 4].Cells[4].Font.Bold=true;
						TBL_CONTENT.Rows[i + k + 4].Cells[4].Text = "&nbsp;" + sNbr_Of_PB_BU.ToString() + "&nbsp;";
						TBL_CONTENT.Rows[i + k + 4].Cells[4].HorizontalAlign = HorizontalAlign.Right;
						TBL_CONTENT.Rows[i + k + 4].Cells[4].CssClass= "ItemPrint_d";

						TBL_CONTENT.Rows[i + k + 4].Cells.Add(new TableCell());
						TBL_CONTENT.Rows[i + k + 4].Cells[5].Font.Bold=true;
						TBL_CONTENT.Rows[i + k + 4].Cells[5].Text = "&nbsp;" + tools.ConvertCurr(sLmt_Of_RN_BU.ToString()) + "&nbsp;";
						TBL_CONTENT.Rows[i + k + 4].Cells[5].HorizontalAlign = HorizontalAlign.Right;
						TBL_CONTENT.Rows[i + k + 4].Cells[5].CssClass= "ItemPrint_d";

						TBL_CONTENT.Rows[i + k + 4].Cells.Add(new TableCell());
						TBL_CONTENT.Rows[i + k + 4].Cells[6].Font.Bold=true;
						TBL_CONTENT.Rows[i + k + 4].Cells[6].Text = "&nbsp;" + sNbr_Of_RN_BU.ToString() + "&nbsp;";
						TBL_CONTENT.Rows[i + k + 4].Cells[6].HorizontalAlign = HorizontalAlign.Right;
						TBL_CONTENT.Rows[i + k + 4].Cells[6].CssClass= "ItemPrint_d";

						TBL_CONTENT.Rows[i + k + 4].Cells.Add(new TableCell());
						TBL_CONTENT.Rows[i + k + 4].Cells[7].Font.Bold=true;
						TBL_CONTENT.Rows[i + k + 4].Cells[7].Text = "&nbsp;" + tools.ConvertCurr(sLmt_Of_LmtChg_BU.ToString()) + "&nbsp;";
						TBL_CONTENT.Rows[i + k + 4].Cells[7].HorizontalAlign = HorizontalAlign.Right;
						TBL_CONTENT.Rows[i + k + 4].Cells[7].CssClass= "ItemPrint_d";

						TBL_CONTENT.Rows[i + k + 4].Cells.Add(new TableCell());
						TBL_CONTENT.Rows[i + k + 4].Cells[8].Font.Bold=true;
						TBL_CONTENT.Rows[i + k + 4].Cells[8].Text = "&nbsp;" + sNbr_Of_LmtChg_BU.ToString()  + "&nbsp;";
						TBL_CONTENT.Rows[i + k + 4].Cells[8].HorizontalAlign = HorizontalAlign.Right;
						TBL_CONTENT.Rows[i + k + 4].Cells[8].CssClass= "ItemPrint_d";

						//CRM
						TBL_CONTENT.Rows[i + k + 4].Cells.Add(new TableCell());
						TBL_CONTENT.Rows[i + k + 4].Cells[9].Font.Bold=true;
						TBL_CONTENT.Rows[i + k + 4].Cells[9].Text = "&nbsp;" + tools.ConvertCurr(sLmt_Of_PB_CRM.ToString()) + "&nbsp;";
						TBL_CONTENT.Rows[i + k + 4].Cells[9].HorizontalAlign = HorizontalAlign.Right;
						TBL_CONTENT.Rows[i + k + 4].Cells[9].CssClass= "ItemPrint_d";

						TBL_CONTENT.Rows[i + k + 4].Cells.Add(new TableCell());
						TBL_CONTENT.Rows[i + k + 4].Cells[10].Font.Bold=true;
						TBL_CONTENT.Rows[i + k + 4].Cells[10].Text = "&nbsp;" + sNbr_Of_PB_CRM.ToString() + "&nbsp;";
						TBL_CONTENT.Rows[i + k + 4].Cells[10].HorizontalAlign = HorizontalAlign.Right;
						TBL_CONTENT.Rows[i + k + 4].Cells[10].CssClass= "ItemPrint_d";

						TBL_CONTENT.Rows[i + k + 4].Cells.Add(new TableCell());
						TBL_CONTENT.Rows[i + k + 4].Cells[11].Font.Bold=true;
						TBL_CONTENT.Rows[i + k + 4].Cells[11].Text = "&nbsp;" + tools.ConvertCurr(sLmt_Of_RN_CRM.ToString()) + "&nbsp;";
						TBL_CONTENT.Rows[i + k + 4].Cells[11].HorizontalAlign = HorizontalAlign.Right;
						TBL_CONTENT.Rows[i + k + 4].Cells[11].CssClass= "ItemPrint_d";

						TBL_CONTENT.Rows[i + k + 4].Cells.Add(new TableCell());
						TBL_CONTENT.Rows[i + k + 4].Cells[12].Font.Bold=true;
						TBL_CONTENT.Rows[i + k + 4].Cells[12].Text = "&nbsp;" + sNbr_Of_RN_CRM.ToString() + "&nbsp;";
						TBL_CONTENT.Rows[i + k + 4].Cells[12].HorizontalAlign = HorizontalAlign.Right;
						TBL_CONTENT.Rows[i + k + 4].Cells[12].CssClass= "ItemPrint_d";

						TBL_CONTENT.Rows[i + k + 4].Cells.Add(new TableCell());
						TBL_CONTENT.Rows[i + k + 4].Cells[13].Font.Bold=true;
						TBL_CONTENT.Rows[i + k + 4].Cells[13].Text = "&nbsp;" + tools.ConvertCurr(sLmt_Of_LmtChg_CRM.ToString()) + "&nbsp;";
						TBL_CONTENT.Rows[i + k + 4].Cells[13].HorizontalAlign = HorizontalAlign.Right;
						TBL_CONTENT.Rows[i + k + 4].Cells[13].CssClass= "ItemPrint_d";

						TBL_CONTENT.Rows[i + k + 4].Cells.Add(new TableCell());
						TBL_CONTENT.Rows[i + k + 4].Cells[14].Font.Bold=true;
						TBL_CONTENT.Rows[i + k + 4].Cells[14].Text = "&nbsp;" + sNbr_Of_LmtChg_CRM.ToString() + "&nbsp;";
						TBL_CONTENT.Rows[i + k + 4].Cells[14].HorizontalAlign = HorizontalAlign.Right;
						TBL_CONTENT.Rows[i + k + 4].Cells[14].CssClass= "ItemPrint_d";

						//CO
						TBL_CONTENT.Rows[i + k + 4].Cells.Add(new TableCell());
						TBL_CONTENT.Rows[i + k + 4].Cells[15].Font.Bold=true;
						TBL_CONTENT.Rows[i + k + 4].Cells[15].Text = "&nbsp;" + tools.ConvertCurr(sLmt_Of_PB_CO.ToString()) + "&nbsp;";
						TBL_CONTENT.Rows[i + k + 4].Cells[15].HorizontalAlign = HorizontalAlign.Right;
						TBL_CONTENT.Rows[i + k + 4].Cells[15].CssClass= "ItemPrint_d";

						TBL_CONTENT.Rows[i + k + 4].Cells.Add(new TableCell());
						TBL_CONTENT.Rows[i + k + 4].Cells[16].Font.Bold=true;
						TBL_CONTENT.Rows[i + k + 4].Cells[16].Text = "&nbsp;" + sNbr_Of_PB_CO.ToString() + "&nbsp;";
						TBL_CONTENT.Rows[i + k + 4].Cells[16].HorizontalAlign = HorizontalAlign.Right;
						TBL_CONTENT.Rows[i + k + 4].Cells[16].CssClass= "ItemPrint_d";

						TBL_CONTENT.Rows[i + k + 4].Cells.Add(new TableCell());
						TBL_CONTENT.Rows[i + k + 4].Cells[17].Font.Bold=true;
						TBL_CONTENT.Rows[i + k + 4].Cells[17].Text = "&nbsp;" + tools.ConvertCurr(sLmt_Of_RN_CO.ToString()) + "&nbsp;";
						TBL_CONTENT.Rows[i + k + 4].Cells[17].HorizontalAlign = HorizontalAlign.Right;
						TBL_CONTENT.Rows[i + k + 4].Cells[17].CssClass= "ItemPrint_d";

						TBL_CONTENT.Rows[i + k + 4].Cells.Add(new TableCell());
						TBL_CONTENT.Rows[i + k + 4].Cells[18].Font.Bold=true;
						TBL_CONTENT.Rows[i + k + 4].Cells[18].Text = "&nbsp;" + sNbr_Of_RN_CO.ToString() + "&nbsp;";
						TBL_CONTENT.Rows[i + k + 4].Cells[18].HorizontalAlign = HorizontalAlign.Right;
						TBL_CONTENT.Rows[i + k + 4].Cells[18].CssClass= "ItemPrint_d";

						TBL_CONTENT.Rows[i + k + 4].Cells.Add(new TableCell());
						TBL_CONTENT.Rows[i + k + 4].Cells[19].Font.Bold=true;
						TBL_CONTENT.Rows[i + k + 4].Cells[19].Text = "&nbsp;" + tools.ConvertCurr(sLmt_Of_LmtChg_CO.ToString()) + "&nbsp;";
						TBL_CONTENT.Rows[i + k + 4].Cells[19].HorizontalAlign = HorizontalAlign.Right;
						TBL_CONTENT.Rows[i + k + 4].Cells[19].CssClass= "ItemPrint_d";

						TBL_CONTENT.Rows[i + k + 4].Cells.Add(new TableCell());
						TBL_CONTENT.Rows[i + k + 4].Cells[20].Font.Bold=true;
						TBL_CONTENT.Rows[i + k + 4].Cells[20].Text = "&nbsp;" + sNbr_Of_LmtChg_CO.ToString() + "&nbsp;";
						TBL_CONTENT.Rows[i + k + 4].Cells[20].HorizontalAlign = HorizontalAlign.Right;
						TBL_CONTENT.Rows[i + k + 4].Cells[20].CssClass= "ItemPrint_d";

						//jumlah dalam proses
						//BusinessUnit
						TBL_CONTENT.Rows[i + k + 4].Cells.Add(new TableCell());
						TBL_CONTENT.Rows[i + k + 4].Cells[21].Font.Bold=true;
						TBL_CONTENT.Rows[i + k + 4].Cells[21].Text = "&nbsp;" +  tools.ConvertCurr(sLmt_Of_PB.ToString()) + "&nbsp;";
						TBL_CONTENT.Rows[i + k + 4].Cells[21].HorizontalAlign = HorizontalAlign.Right;
						TBL_CONTENT.Rows[i + k + 4].Cells[21].CssClass= "ItemPrint_d";

						TBL_CONTENT.Rows[i + k + 4].Cells.Add(new TableCell());
						TBL_CONTENT.Rows[i + k + 4].Cells[22].Font.Bold=true;
						TBL_CONTENT.Rows[i + k + 4].Cells[22].Text = "&nbsp;" +  sNbr_Of_PB.ToString() + "&nbsp;";
						TBL_CONTENT.Rows[i + k + 4].Cells[22].HorizontalAlign = HorizontalAlign.Right;
						TBL_CONTENT.Rows[i + k + 4].Cells[22].CssClass= "ItemPrint_d";

						//Renewal
						TBL_CONTENT.Rows[i + k + 4].Cells.Add(new TableCell());
						TBL_CONTENT.Rows[i + k + 4].Cells[23].Font.Bold=true;
						TBL_CONTENT.Rows[i + k + 4].Cells[23].Text = "&nbsp;" + tools.ConvertCurr(sLmt_Of_RN.ToString()) + "&nbsp;";
						TBL_CONTENT.Rows[i + k + 4].Cells[23].HorizontalAlign = HorizontalAlign.Right;
						TBL_CONTENT.Rows[i + k + 4].Cells[23].CssClass= "ItemPrint_d";

						TBL_CONTENT.Rows[i + k + 4].Cells.Add(new TableCell());
						TBL_CONTENT.Rows[i + k + 4].Cells[24].Font.Bold=true;
						TBL_CONTENT.Rows[i + k + 4].Cells[24].Text = "&nbsp;" +  sNbr_Of_RN.ToString() + "&nbsp;";
						TBL_CONTENT.Rows[i + k + 4].Cells[24].HorizontalAlign = HorizontalAlign.Right;
						TBL_CONTENT.Rows[i + k + 4].Cells[24].CssClass= "ItemPrint_d";
				
						//Limit Change
						TBL_CONTENT.Rows[i + k + 4].Cells.Add(new TableCell());
						TBL_CONTENT.Rows[i + k + 4].Cells[25].Font.Bold=true;
						TBL_CONTENT.Rows[i + k + 4].Cells[25].Text = "&nbsp;" +  tools.ConvertCurr(sLmt_Of_LmtChg.ToString()) + "&nbsp;";
						TBL_CONTENT.Rows[i + k + 4].Cells[25].HorizontalAlign = HorizontalAlign.Right;
						TBL_CONTENT.Rows[i + k + 4].Cells[25].CssClass= "ItemPrint_d";

						TBL_CONTENT.Rows[i + k + 4].Cells.Add(new TableCell());
						TBL_CONTENT.Rows[i + k + 4].Cells[26].Font.Bold=true;
						TBL_CONTENT.Rows[i + k + 4].Cells[26].Text = "&nbsp;" + tools.ConvertCurr(sNbr_Of_LmtChg.ToString()) + "&nbsp;";
						TBL_CONTENT.Rows[i + k + 4].Cells[26].HorizontalAlign = HorizontalAlign.Right;
						TBL_CONTENT.Rows[i + k + 4].Cells[26].CssClass= "ItemPrint_d";			

						//jumlah on booking
						//BusinessUnit
						TBL_CONTENT.Rows[i + k + 4].Cells.Add(new TableCell());
						TBL_CONTENT.Rows[i + k + 4].Cells[27].Font.Bold=true;
						TBL_CONTENT.Rows[i + k + 4].Cells[27].Text = "&nbsp;" + tools.ConvertCurr(sLmt_Of_PB_BOOK.ToString()) + "&nbsp;";
						TBL_CONTENT.Rows[i + k + 4].Cells[27].HorizontalAlign = HorizontalAlign.Right;
						TBL_CONTENT.Rows[i + k + 4].Cells[27].CssClass= "ItemPrint_d";

						TBL_CONTENT.Rows[i + k + 4].Cells.Add(new TableCell());
						TBL_CONTENT.Rows[i + k + 4].Cells[28].Font.Bold=true;
						TBL_CONTENT.Rows[i + k + 4].Cells[28].Text = "&nbsp;" +  tools.ConvertCurr(sNbr_Of_PB_BOOK.ToString()) + "&nbsp;";
						TBL_CONTENT.Rows[i + k + 4].Cells[28].HorizontalAlign = HorizontalAlign.Right;
						TBL_CONTENT.Rows[i + k + 4].Cells[28].CssClass= "ItemPrint_d";

						//Renewal
						TBL_CONTENT.Rows[i + k + 4].Cells.Add(new TableCell());
						TBL_CONTENT.Rows[i + k + 4].Cells[29].Font.Bold=true;
						TBL_CONTENT.Rows[i + k + 4].Cells[29].Text = "&nbsp;" +  tools.ConvertCurr(sLmt_Of_RN_BOOK.ToString()) + "&nbsp;";
						TBL_CONTENT.Rows[i + k + 4].Cells[29].HorizontalAlign = HorizontalAlign.Right;
						TBL_CONTENT.Rows[i + k + 4].Cells[29].CssClass= "ItemPrint_d";

						TBL_CONTENT.Rows[i + k + 4].Cells.Add(new TableCell());
						TBL_CONTENT.Rows[i + k + 4].Cells[30].Font.Bold=true;
						TBL_CONTENT.Rows[i + k + 4].Cells[30].Text = "&nbsp;" +  sNbr_Of_RN_BOOK.ToString() + "&nbsp;";
						TBL_CONTENT.Rows[i + k + 4].Cells[30].HorizontalAlign = HorizontalAlign.Right;
						TBL_CONTENT.Rows[i + k + 4].Cells[30].CssClass= "ItemPrint_d";
				
						//Limit Change
						TBL_CONTENT.Rows[i + k + 4].Cells.Add(new TableCell());
						TBL_CONTENT.Rows[i + k + 4].Cells[31].Font.Bold=true;
						TBL_CONTENT.Rows[i + k + 4].Cells[31].Text = "&nbsp;" +  tools.ConvertCurr(sLmt_Of_LmtChg_BOOK.ToString()) + "&nbsp;";
						TBL_CONTENT.Rows[i + k + 4].Cells[31].HorizontalAlign = HorizontalAlign.Right;
						TBL_CONTENT.Rows[i + k + 4].Cells[31].CssClass= "ItemPrint_d";

						TBL_CONTENT.Rows[i + k + 4].Cells.Add(new TableCell());
						TBL_CONTENT.Rows[i + k + 4].Cells[23].Font.Bold=true;
						TBL_CONTENT.Rows[i + k + 4].Cells[32].Text = "&nbsp;" +  sNbr_Of_LmtChg_BOOK.ToString() + "&nbsp;";
						TBL_CONTENT.Rows[i + k + 4].Cells[32].HorizontalAlign = HorizontalAlign.Right;
						TBL_CONTENT.Rows[i + k + 4].Cells[32].CssClass= "ItemPrint_d";
						k = k + 1;
					}
					sLmt_Of_PB_BU=0;
					sNbr_Of_PB_BU=0;
					sLmt_Of_RN_BU=0;
					sNbr_Of_RN_BU=0;
					sLmt_Of_LmtChg_BU=0;
					sNbr_Of_LmtChg_BU=0;
					sLmt_Of_PB_CRM=0;
					sNbr_Of_PB_CRM=0;
					sLmt_Of_RN_CRM=0;
					sNbr_Of_RN_CRM=0;
					sLmt_Of_LmtChg_CRM=0;
					sNbr_Of_LmtChg_CRM=0;
					sLmt_Of_PB_CO=0;
					sNbr_Of_PB_CO=0;
					sLmt_Of_RN_CO=0;
					sNbr_Of_RN_CO=0;
					sLmt_Of_LmtChg_CO=0;
					sNbr_Of_LmtChg_CO=0;
					sLmt_Of_PB=0;
					sNbr_Of_PB=0;
					sLmt_Of_RN=0;
					sNbr_Of_RN=0;
					sLmt_Of_LmtChg=0;
					sNbr_Of_LmtChg=0;
					sLmt_Of_PB_BOOK=0;
					sNbr_Of_PB_BOOK=0;
					sLmt_Of_RN_BOOK=0;
					sNbr_Of_RN_BOOK=0;
					sLmt_Of_LmtChg_BOOK=0;
					sNbr_Of_LmtChg_BOOK=0;

					TBL_CONTENT.Rows.Add(new TableRow());
					TBL_CONTENT.Rows[i + k + 4].Cells.Add(new TableCell());
					TBL_CONTENT.Rows[i + k + 4].Cells[0].Text = "&nbsp;";
					TBL_CONTENT.Rows[i + k + 4].Cells[0].HorizontalAlign = HorizontalAlign.Center;
					TBL_CONTENT.Rows[i + k + 4].Cells[0].CssClass= "ItemPrint_d";

					//TBL_CONTENT.Rows.Add(new TableRow());
					TBL_CONTENT.Rows[i + k + 4].Cells.Add(new TableCell());
					TBL_CONTENT.Rows[i + k + 4].Cells[1].Text = "&nbsp;" + Conn.GetFieldValue(i,"areaname");
					TBL_CONTENT.Rows[i + k + 4].Cells[1].HorizontalAlign = HorizontalAlign.Center;
					TBL_CONTENT.Rows[i + k + 4].Cells[1].CssClass= "ItemPrint_d";
					pre_area = Conn.GetFieldValue(i,"areaname");
					k += 1;
				}

				//sub total

				//BusinessUnit
				sLmt_Of_PB_BU += double.Parse(Conn.GetFieldValue(i,"Lmt_Of_PB_BU").ToString()); 
				sNbr_Of_PB_BU += double.Parse(Conn.GetFieldValue(i,"Nbr_Of_PB_BU").ToString());
				sLmt_Of_RN_BU +=double.Parse(Conn.GetFieldValue(i,"Lmt_Of_RN_BU").ToString());
				sNbr_Of_RN_BU +=double.Parse(Conn.GetFieldValue(i,"Nbr_Of_RN_BU").ToString());
				sLmt_Of_LmtChg_BU += double.Parse(Conn.GetFieldValue(i,"Lmt_Of_LmtChg_BU").ToString());
				sNbr_Of_LmtChg_BU += double.Parse(Conn.GetFieldValue(i,"Nbr_Of_LmtChg_BU").ToString());
				//CRM
				sLmt_Of_PB_CRM += double.Parse(Conn.GetFieldValue(i,"Lmt_Of_PB_CRM").ToString());
				sNbr_Of_PB_CRM += double.Parse(Conn.GetFieldValue(i,"Nbr_Of_PB_CRM").ToString());
				sLmt_Of_RN_CRM += double.Parse(Conn.GetFieldValue(i,"Lmt_Of_RN_CRM").ToString());

				sNbr_Of_RN_CRM += double.Parse(Conn.GetFieldValue(i,"Nbr_Of_RN_CRM").ToString());
				sLmt_Of_LmtChg_CRM += double.Parse(Conn.GetFieldValue(i,"Lmt_Of_LmtChg_CRM").ToString());
				sNbr_Of_LmtChg_CRM += double.Parse(Conn.GetFieldValue(i,"Nbr_Of_LmtChg_CRM").ToString());
				//CO
				sLmt_Of_PB_CO += double.Parse(Conn.GetFieldValue(i,"Lmt_Of_PB_CO").ToString());
				sNbr_Of_PB_CO += double.Parse(Conn.GetFieldValue(i,"Nbr_Of_PB_CO").ToString());
				sLmt_Of_RN_CO += double.Parse(Conn.GetFieldValue(i,"Lmt_Of_RN_CO").ToString());

				sNbr_Of_RN_CO +=  double.Parse(Conn.GetFieldValue(i,"Nbr_Of_RN_CO").ToString()); 
				sLmt_Of_LmtChg_CO += double.Parse(Conn.GetFieldValue(i,"Lmt_Of_LmtChg_CO").ToString());
				sNbr_Of_LmtChg_CO += double.Parse(Conn.GetFieldValue(i,"Nbr_Of_LmtChg_CO").ToString());
				//jumlah dalam proses
				//BusinessUnit
				sLmt_Of_PB += Convert.ToDouble(Conn.GetFieldValue(i,"Lmt_Of_PB_BU")) + Convert.ToDouble(Conn.GetFieldValue(i,"Lmt_Of_PB_CRM")) + Convert.ToDouble(Conn.GetFieldValue(i,"Lmt_Of_PB_CO"));
				sNbr_Of_PB += Convert.ToDouble(Conn.GetFieldValue(i,"Nbr_Of_PB_BU")) + Convert.ToDouble(Conn.GetFieldValue(i,"Nbr_Of_PB_CRM")) + Convert.ToDouble(Conn.GetFieldValue(i,"Nbr_Of_PB_CO"));
				//Renewal
				sLmt_Of_RN += Convert.ToDouble(Conn.GetFieldValue(i,"Lmt_Of_RN_BU")) + Convert.ToDouble(Conn.GetFieldValue(i,"Lmt_Of_RN_CRM")) + Convert.ToDouble(Conn.GetFieldValue(i,"Lmt_Of_RN_CO")); 
				sNbr_Of_RN += Convert.ToDouble(Conn.GetFieldValue(i,"Nbr_Of_RN_BU")) + Convert.ToDouble(Conn.GetFieldValue(i,"Nbr_Of_RN_CRM")) + Convert.ToDouble(Conn.GetFieldValue(i,"Nbr_Of_RN_CO"));
				//Limit Change
				sLmt_Of_LmtChg += Convert.ToDouble(Conn.GetFieldValue(i,"Lmt_Of_LmtChg_BU")) + Convert.ToDouble(Conn.GetFieldValue(i,"Lmt_Of_LmtChg_CRM")) + Convert.ToDouble(Conn.GetFieldValue(i,"Lmt_Of_LmtChg_CO"));
				sNbr_Of_LmtChg += Convert.ToDouble(Conn.GetFieldValue(i,"Nbr_Of_LmtChg_BU")) + Convert.ToDouble(Conn.GetFieldValue(i,"Nbr_Of_LmtChg_CRM")) + Convert.ToDouble(Conn.GetFieldValue(i,"Nbr_Of_LmtChg_CO"));
				//jumlah on booking
				//BusinessUnit
				sLmt_Of_PB_BOOK += Convert.ToDouble(Conn.GetFieldValue(i,"Lmt_Of_PB_BU_BOOK")) + Convert.ToDouble(Conn.GetFieldValue(i,"Lmt_Of_PB_CRM_BOOK")) + Convert.ToDouble(Conn.GetFieldValue(i,"Lmt_Of_PB_CO_BOOK"));
				sNbr_Of_PB_BOOK += Convert.ToDouble(Conn.GetFieldValue(i,"Nbr_Of_PB_BU_BOOK")) + Convert.ToDouble(Conn.GetFieldValue(i,"Nbr_Of_PB_CRM_BOOK")) + Convert.ToDouble(Conn.GetFieldValue(i,"Nbr_Of_PB_CO_BOOK"));
				//Renewal
				sLmt_Of_RN_BOOK += Convert.ToDouble(Conn.GetFieldValue(i,"Lmt_Of_RN_BU_BOOK")) + Convert.ToDouble(Conn.GetFieldValue(i,"Lmt_Of_RN_CRM_BOOK")) + Convert.ToDouble(Conn.GetFieldValue(i,"Lmt_Of_RN_CO_BOOK"));
				sNbr_Of_RN_BOOK += Convert.ToDouble(Conn.GetFieldValue(i,"Nbr_Of_RN_BU_BOOK")) + Convert.ToDouble(Conn.GetFieldValue(i,"Nbr_Of_RN_CRM_BOOK")) + Convert.ToDouble(Conn.GetFieldValue(i,"Nbr_Of_RN_CO_BOOK"));
				//Limit Change
				sLmt_Of_LmtChg_BOOK += Convert.ToDouble(Conn.GetFieldValue(i,"Lmt_Of_LmtChg_BU_BOOK")) + Convert.ToDouble(Conn.GetFieldValue(i,"Lmt_Of_LmtChg_CRM_BOOK")) + Convert.ToDouble(Conn.GetFieldValue(i,"Lmt_Of_LmtChg_CO_BOOK"));
				sNbr_Of_LmtChg_BOOK += Convert.ToDouble(Conn.GetFieldValue(i,"Nbr_Of_LmtChg_BU_BOOK")) + Convert.ToDouble(Conn.GetFieldValue(i,"Nbr_Of_LmtChg_CRM_BOOK")) + Convert.ToDouble(Conn.GetFieldValue(i,"Nbr_Of_LmtChg_CO_BOOK"));
				//Total
				//BusinessUnit
				tLmt_Of_PB_BU += double.Parse(Conn.GetFieldValue(i,"Lmt_Of_PB_BU").ToString()); 
				tNbr_Of_PB_BU += double.Parse(Conn.GetFieldValue(i,"Nbr_Of_PB_BU").ToString());
				tLmt_Of_RN_BU += double.Parse(Conn.GetFieldValue(i,"Lmt_Of_RN_BU").ToString());
				tNbr_Of_RN_BU += double.Parse(Conn.GetFieldValue(i,"Nbr_Of_RN_BU").ToString());
				tLmt_Of_LmtChg_BU += double.Parse(Conn.GetFieldValue(i,"Lmt_Of_LmtChg_BU").ToString());
				tNbr_Of_LmtChg_BU += double.Parse(Conn.GetFieldValue(i,"Nbr_Of_LmtChg_BU").ToString());
				//CRM
				tLmt_Of_PB_CRM += double.Parse(Conn.GetFieldValue(i,"Lmt_Of_PB_CRM").ToString());
				tNbr_Of_PB_CRM += double.Parse(Conn.GetFieldValue(i,"Nbr_Of_PB_CRM").ToString());
				tLmt_Of_RN_CRM += double.Parse(Conn.GetFieldValue(i,"Lmt_Of_RN_CRM").ToString());

				tNbr_Of_RN_CRM += double.Parse(Conn.GetFieldValue(i,"Nbr_Of_RN_CRM").ToString());
				tLmt_Of_LmtChg_CRM += double.Parse(Conn.GetFieldValue(i,"Lmt_Of_LmtChg_CRM").ToString());
				tNbr_Of_LmtChg_CRM += double.Parse(Conn.GetFieldValue(i,"Nbr_Of_LmtChg_CRM").ToString());
				//CO
				tLmt_Of_PB_CO += double.Parse(Conn.GetFieldValue(i,"Lmt_Of_PB_CO").ToString());
				tNbr_Of_PB_CO += double.Parse(Conn.GetFieldValue(i,"Nbr_Of_PB_CO").ToString());
				tLmt_Of_RN_CO += double.Parse(Conn.GetFieldValue(i,"Lmt_Of_RN_CO").ToString());

				tNbr_Of_RN_CO +=  double.Parse(Conn.GetFieldValue(i,"Nbr_Of_RN_CO").ToString()); 
				tLmt_Of_LmtChg_CO += double.Parse(Conn.GetFieldValue(i,"Lmt_Of_LmtChg_CO").ToString());
				tNbr_Of_LmtChg_CO += double.Parse(Conn.GetFieldValue(i,"Nbr_Of_LmtChg_CO").ToString());
				//jumlah dalam proses
				//BusinessUnit
				tLmt_Of_PB += Convert.ToDouble(Conn.GetFieldValue(i,"Lmt_Of_PB_BU")) + Convert.ToDouble(Conn.GetFieldValue(i,"Lmt_Of_PB_CRM")) + Convert.ToDouble(Conn.GetFieldValue(i,"Lmt_Of_PB_CO"));
				tNbr_Of_PB += Convert.ToDouble(Conn.GetFieldValue(i,"Nbr_Of_PB_BU")) + Convert.ToDouble(Conn.GetFieldValue(i,"Nbr_Of_PB_CRM")) + Convert.ToDouble(Conn.GetFieldValue(i,"Nbr_Of_PB_CO"));
				//Renewal
				tLmt_Of_RN += Convert.ToDouble(Conn.GetFieldValue(i,"Lmt_Of_RN_BU")) + Convert.ToDouble(Conn.GetFieldValue(i,"Lmt_Of_RN_CRM")) + Convert.ToDouble(Conn.GetFieldValue(i,"Lmt_Of_RN_CO")); 
				tNbr_Of_RN += Convert.ToDouble(Conn.GetFieldValue(i,"Nbr_Of_RN_BU")) + Convert.ToDouble(Conn.GetFieldValue(i,"Nbr_Of_RN_CRM")) + Convert.ToDouble(Conn.GetFieldValue(i,"Nbr_Of_RN_CO"));
				//Limit Change
				tLmt_Of_LmtChg += Convert.ToDouble(Conn.GetFieldValue(i,"Lmt_Of_LmtChg_BU")) + Convert.ToDouble(Conn.GetFieldValue(i,"Lmt_Of_LmtChg_CRM")) + Convert.ToDouble(Conn.GetFieldValue(i,"Lmt_Of_LmtChg_CO"));
				tNbr_Of_LmtChg += Convert.ToDouble(Conn.GetFieldValue(i,"Nbr_Of_LmtChg_BU")) + Convert.ToDouble(Conn.GetFieldValue(i,"Nbr_Of_LmtChg_CRM")) + Convert.ToDouble(Conn.GetFieldValue(i,"Nbr_Of_LmtChg_CO"));
				//jumlah on booking
				//BusinessUnit
				tLmt_Of_PB_BOOK += Convert.ToDouble(Conn.GetFieldValue(i,"Lmt_Of_PB_BU_BOOK")) + Convert.ToDouble(Conn.GetFieldValue(i,"Lmt_Of_PB_CRM_BOOK")) + Convert.ToDouble(Conn.GetFieldValue(i,"Lmt_Of_PB_CO_BOOK"));
				tNbr_Of_PB_BOOK += Convert.ToDouble(Conn.GetFieldValue(i,"Nbr_Of_PB_BU_BOOK")) + Convert.ToDouble(Conn.GetFieldValue(i,"Nbr_Of_PB_CRM_BOOK")) + Convert.ToDouble(Conn.GetFieldValue(i,"Nbr_Of_PB_CO_BOOK"));
				//Renewal
				tLmt_Of_RN_BOOK += Convert.ToDouble(Conn.GetFieldValue(i,"Lmt_Of_RN_BU_BOOK")) + Convert.ToDouble(Conn.GetFieldValue(i,"Lmt_Of_RN_CRM_BOOK")) + Convert.ToDouble(Conn.GetFieldValue(i,"Lmt_Of_RN_CO_BOOK"));
				tNbr_Of_RN_BOOK += Convert.ToDouble(Conn.GetFieldValue(i,"Nbr_Of_RN_BU_BOOK")) + Convert.ToDouble(Conn.GetFieldValue(i,"Nbr_Of_RN_CRM_BOOK")) + Convert.ToDouble(Conn.GetFieldValue(i,"Nbr_Of_RN_CO_BOOK"));
				//Limit Change
				tLmt_Of_LmtChg_BOOK += Convert.ToDouble(Conn.GetFieldValue(i,"Lmt_Of_LmtChg_BU_BOOK")) + Convert.ToDouble(Conn.GetFieldValue(i,"Lmt_Of_LmtChg_CRM_BOOK")) + Convert.ToDouble(Conn.GetFieldValue(i,"Lmt_Of_LmtChg_CO_BOOK"));
				tNbr_Of_LmtChg_BOOK += Convert.ToDouble(Conn.GetFieldValue(i,"Nbr_Of_LmtChg_BU_BOOK")) + Convert.ToDouble(Conn.GetFieldValue(i,"Nbr_Of_LmtChg_CRM_BOOK")) + Convert.ToDouble(Conn.GetFieldValue(i,"Nbr_Of_LmtChg_CO_BOOK"));

				TBL_CONTENT.Rows.Add(new TableRow());
				TBL_CONTENT.Rows[i + k + 4].Cells.Add(new TableCell());
				TBL_CONTENT.Rows[i + k + 4].Cells[0].Text = "&nbsp;" + ((int)(i + 1)).ToString();
				TBL_CONTENT.Rows[i + k + 4].Cells[0].HorizontalAlign = HorizontalAlign.Center;
				TBL_CONTENT.Rows[i + k + 4].Cells[0].CssClass= "ItemPrint_d";

				TBL_CONTENT.Rows[i + k + 4].Cells.Add(new TableCell());
				TBL_CONTENT.Rows[i + k + 4].Cells[1].Text = "&nbsp;";
				TBL_CONTENT.Rows[i + k + 4].Cells[1].HorizontalAlign = HorizontalAlign.Center;
				TBL_CONTENT.Rows[i + k + 4].Cells[1].CssClass= "ItemPrint_d";

				TBL_CONTENT.Rows[i + k + 4].Cells.Add(new TableCell());
				TBL_CONTENT.Rows[i + k + 4].Cells[2].Text = "&nbsp;" + Conn.GetFieldValue(i,"cbcbook");
				TBL_CONTENT.Rows[i + k + 4].Cells[2].HorizontalAlign = HorizontalAlign.Left;
				TBL_CONTENT.Rows[i + k + 4].Cells[2].CssClass= "ItemPrint_d";

				//BusinessUnit
				TBL_CONTENT.Rows[i + k + 4].Cells.Add(new TableCell());
				TBL_CONTENT.Rows[i + k + 4].Cells[3].Text = "&nbsp;" + tools.ConvertCurr(Conn.GetFieldValue(i,"Lmt_Of_PB_BU")) + "&nbsp;";
				TBL_CONTENT.Rows[i + k + 4].Cells[3].HorizontalAlign = HorizontalAlign.Right;
				TBL_CONTENT.Rows[i + k + 4].Cells[3].CssClass= "ItemPrint_d";

				TBL_CONTENT.Rows[i + k + 4].Cells.Add(new TableCell());
				TBL_CONTENT.Rows[i + k + 4].Cells[4].Text = "&nbsp;" + Conn.GetFieldValue(i,"Nbr_Of_PB_BU") + "&nbsp;";
				TBL_CONTENT.Rows[i + k + 4].Cells[4].HorizontalAlign = HorizontalAlign.Right;
				TBL_CONTENT.Rows[i + k + 4].Cells[4].CssClass= "ItemPrint_d";

				TBL_CONTENT.Rows[i + k + 4].Cells.Add(new TableCell());
				TBL_CONTENT.Rows[i + k + 4].Cells[5].Text = "&nbsp;" + tools.ConvertCurr(Conn.GetFieldValue(i,"Lmt_Of_RN_BU").ToString()) + "&nbsp;";
				TBL_CONTENT.Rows[i + k + 4].Cells[5].HorizontalAlign = HorizontalAlign.Right;
				TBL_CONTENT.Rows[i + k + 4].Cells[5].CssClass= "ItemPrint_d";

				TBL_CONTENT.Rows[i + k + 4].Cells.Add(new TableCell());
				TBL_CONTENT.Rows[i + k + 4].Cells[6].Text = "&nbsp;" + Conn.GetFieldValue(i,"Nbr_Of_RN_BU") + "&nbsp;";
				TBL_CONTENT.Rows[i + k + 4].Cells[6].HorizontalAlign = HorizontalAlign.Right;
				TBL_CONTENT.Rows[i + k + 4].Cells[6].CssClass= "ItemPrint_d";

				TBL_CONTENT.Rows[i + k + 4].Cells.Add(new TableCell());
				TBL_CONTENT.Rows[i + k + 4].Cells[7].Text = "&nbsp;" + tools.ConvertCurr(Conn.GetFieldValue(i,"Lmt_Of_LmtChg_BU").ToString()) + "&nbsp;";
				TBL_CONTENT.Rows[i + k + 4].Cells[7].HorizontalAlign = HorizontalAlign.Right;
				TBL_CONTENT.Rows[i + k + 4].Cells[7].CssClass= "ItemPrint_d";

				TBL_CONTENT.Rows[i + k + 4].Cells.Add(new TableCell());
				TBL_CONTENT.Rows[i + k + 4].Cells[8].Text = "&nbsp;" + Conn.GetFieldValue(i,"Nbr_Of_LmtChg_BU") + "&nbsp;";
				TBL_CONTENT.Rows[i + k + 4].Cells[8].HorizontalAlign = HorizontalAlign.Right;
				TBL_CONTENT.Rows[i + k + 4].Cells[8].CssClass= "ItemPrint_d";

				//CRM
				TBL_CONTENT.Rows[i + k + 4].Cells.Add(new TableCell());
				TBL_CONTENT.Rows[i + k + 4].Cells[9].Text = "&nbsp;" + tools.ConvertCurr(Conn.GetFieldValue(i,"Lmt_Of_PB_CRM")) + "&nbsp;";
				TBL_CONTENT.Rows[i + k + 4].Cells[9].HorizontalAlign = HorizontalAlign.Right;
				TBL_CONTENT.Rows[i + k + 4].Cells[9].CssClass= "ItemPrint_d";

				TBL_CONTENT.Rows[i + k + 4].Cells.Add(new TableCell());
				TBL_CONTENT.Rows[i + k + 4].Cells[10].Text = "&nbsp;" + Conn.GetFieldValue(i,"Nbr_Of_PB_CRM") + "&nbsp;";
				TBL_CONTENT.Rows[i + k + 4].Cells[10].HorizontalAlign = HorizontalAlign.Right;
				TBL_CONTENT.Rows[i + k + 4].Cells[10].CssClass= "ItemPrint_d";

				TBL_CONTENT.Rows[i + k + 4].Cells.Add(new TableCell());
				TBL_CONTENT.Rows[i + k + 4].Cells[11].Text = "&nbsp;" + tools.ConvertCurr(Conn.GetFieldValue(i,"Lmt_Of_RN_CRM").ToString()) + "&nbsp;";
				TBL_CONTENT.Rows[i + k + 4].Cells[11].HorizontalAlign = HorizontalAlign.Right;
				TBL_CONTENT.Rows[i + k + 4].Cells[11].CssClass= "ItemPrint_d";

				TBL_CONTENT.Rows[i + k + 4].Cells.Add(new TableCell());
				TBL_CONTENT.Rows[i + k + 4].Cells[12].Text = "&nbsp;" + Conn.GetFieldValue(i,"Nbr_Of_RN_CRM") + "&nbsp;";
				TBL_CONTENT.Rows[i + k + 4].Cells[12].HorizontalAlign = HorizontalAlign.Right;
				TBL_CONTENT.Rows[i + k + 4].Cells[12].CssClass= "ItemPrint_d";

				TBL_CONTENT.Rows[i + k + 4].Cells.Add(new TableCell());
				TBL_CONTENT.Rows[i + k + 4].Cells[13].Text = "&nbsp;" + tools.ConvertCurr(Conn.GetFieldValue(i,"Lmt_Of_LmtChg_CRM").ToString()) + "&nbsp;";
				TBL_CONTENT.Rows[i + k + 4].Cells[13].HorizontalAlign = HorizontalAlign.Right;
				TBL_CONTENT.Rows[i + k + 4].Cells[13].CssClass= "ItemPrint_d";

				TBL_CONTENT.Rows[i + k + 4].Cells.Add(new TableCell());
				TBL_CONTENT.Rows[i + k + 4].Cells[14].Text = "&nbsp;" + Conn.GetFieldValue(i,"Nbr_Of_LmtChg_CRM") + "&nbsp;";
				TBL_CONTENT.Rows[i + k + 4].Cells[14].HorizontalAlign = HorizontalAlign.Right;
				TBL_CONTENT.Rows[i + k + 4].Cells[14].CssClass= "ItemPrint_d";

				//CO
				TBL_CONTENT.Rows[i + k + 4].Cells.Add(new TableCell());
				TBL_CONTENT.Rows[i + k + 4].Cells[15].Text = "&nbsp;" + tools.ConvertCurr(Conn.GetFieldValue(i,"Lmt_Of_PB_CO")) + "&nbsp;";
				TBL_CONTENT.Rows[i + k + 4].Cells[15].HorizontalAlign = HorizontalAlign.Right;
				TBL_CONTENT.Rows[i + k + 4].Cells[15].CssClass= "ItemPrint_d";

				TBL_CONTENT.Rows[i + k + 4].Cells.Add(new TableCell());
				TBL_CONTENT.Rows[i + k + 4].Cells[16].Text = "&nbsp;" + Conn.GetFieldValue(i,"Nbr_Of_PB_CO") + "&nbsp;";
				TBL_CONTENT.Rows[i + k + 4].Cells[16].HorizontalAlign = HorizontalAlign.Right;
				TBL_CONTENT.Rows[i + k + 4].Cells[16].CssClass= "ItemPrint_d";

				TBL_CONTENT.Rows[i + k + 4].Cells.Add(new TableCell());
				TBL_CONTENT.Rows[i + k + 4].Cells[17].Text = "&nbsp;" + tools.ConvertCurr(Conn.GetFieldValue(i,"Lmt_Of_RN_CO").ToString()) + "&nbsp;";
				TBL_CONTENT.Rows[i + k + 4].Cells[17].HorizontalAlign = HorizontalAlign.Right;
				TBL_CONTENT.Rows[i + k + 4].Cells[17].CssClass= "ItemPrint_d";

				TBL_CONTENT.Rows[i + k + 4].Cells.Add(new TableCell());
				TBL_CONTENT.Rows[i + k + 4].Cells[18].Text = "&nbsp;" + Conn.GetFieldValue(i,"Nbr_Of_RN_CO") + "&nbsp;";
				TBL_CONTENT.Rows[i + k + 4].Cells[18].HorizontalAlign = HorizontalAlign.Right;
				TBL_CONTENT.Rows[i + k + 4].Cells[18].CssClass= "ItemPrint_d";

				TBL_CONTENT.Rows[i + k + 4].Cells.Add(new TableCell());
				TBL_CONTENT.Rows[i + k + 4].Cells[19].Text = "&nbsp;" + tools.ConvertCurr(Conn.GetFieldValue(i,"Lmt_Of_LmtChg_CO").ToString()) + "&nbsp;";
				TBL_CONTENT.Rows[i + k + 4].Cells[19].HorizontalAlign = HorizontalAlign.Right;
				TBL_CONTENT.Rows[i + k + 4].Cells[19].CssClass= "ItemPrint_d";

				TBL_CONTENT.Rows[i + k + 4].Cells.Add(new TableCell());
				TBL_CONTENT.Rows[i + k + 4].Cells[20].Text = "&nbsp;" + Conn.GetFieldValue(i,"Nbr_Of_LmtChg_CO") + "&nbsp;";
				TBL_CONTENT.Rows[i + k + 4].Cells[20].HorizontalAlign = HorizontalAlign.Right;
				TBL_CONTENT.Rows[i + k + 4].Cells[20].CssClass= "ItemPrint_d";

				//jumlah dalam proses
				//BusinessUnit
				
//				Convert.ToDouble(Conn.GetFieldValue(i,"Lmt_Of_PB_BU")) + Convert.ToDouble(Conn.GetFieldValue(i,"Lmt_Of_PB_CRM")) + Convert.ToDouble(Conn.GetFieldValue(i,"Lmt_Of_PB_CO"));

				//double Tmp_Value = double.Parse("0")  + double.Parse("0") + double.Parse("0");
				double Tmp_Value = Convert.ToDouble(Conn.GetFieldValue(i,"Lmt_Of_PB_BU")) + Convert.ToDouble(Conn.GetFieldValue(i,"Lmt_Of_PB_CRM")) + Convert.ToDouble(Conn.GetFieldValue(i,"Lmt_Of_PB_CO"));
				TBL_CONTENT.Rows[i + k + 4].Cells.Add(new TableCell());
				TBL_CONTENT.Rows[i + k + 4].Cells[21].Text = "&nbsp;" +  tools.ConvertCurr(Tmp_Value.ToString()) + "&nbsp;";
				TBL_CONTENT.Rows[i + k + 4].Cells[21].HorizontalAlign = HorizontalAlign.Right;
				TBL_CONTENT.Rows[i + k + 4].Cells[21].CssClass= "ItemPrint_d";

				Tmp_Value = Convert.ToDouble(Conn.GetFieldValue(i,"Nbr_Of_PB_BU")) + Convert.ToDouble(Conn.GetFieldValue(i,"Nbr_Of_PB_CRM")) + Convert.ToDouble(Conn.GetFieldValue(i,"Nbr_Of_PB_CO"));
				TBL_CONTENT.Rows[i + k + 4].Cells.Add(new TableCell());
				TBL_CONTENT.Rows[i + k + 4].Cells[22].Text = "&nbsp;" +  tools.ConvertCurr(Tmp_Value.ToString()) + "&nbsp;";
				TBL_CONTENT.Rows[i + k + 4].Cells[22].HorizontalAlign = HorizontalAlign.Right;
				TBL_CONTENT.Rows[i + k + 4].Cells[22].CssClass= "ItemPrint_d";

				//Renewal
				Tmp_Value = Convert.ToDouble(Conn.GetFieldValue(i,"Lmt_Of_RN_BU")) + Convert.ToDouble(Conn.GetFieldValue(i,"Lmt_Of_RN_CRM")) + Convert.ToDouble(Conn.GetFieldValue(i,"Lmt_Of_RN_CO")); 
				TBL_CONTENT.Rows[i + k + 4].Cells.Add(new TableCell());
				TBL_CONTENT.Rows[i + k + 4].Cells[23].Text = "&nbsp;" + tools.ConvertCurr(Tmp_Value.ToString()) + "&nbsp;";
				TBL_CONTENT.Rows[i + k + 4].Cells[23].HorizontalAlign = HorizontalAlign.Right;
				TBL_CONTENT.Rows[i + k + 4].Cells[23].CssClass= "ItemPrint_d";

				Tmp_Value = Convert.ToDouble(Conn.GetFieldValue(i,"Nbr_Of_RN_BU")) + Convert.ToDouble(Conn.GetFieldValue(i,"Nbr_Of_RN_CRM")) + Convert.ToDouble(Conn.GetFieldValue(i,"Nbr_Of_RN_CO"));
				TBL_CONTENT.Rows[i + k + 4].Cells.Add(new TableCell());
				TBL_CONTENT.Rows[i + k + 4].Cells[24].Text = "&nbsp;" +  tools.ConvertCurr(Tmp_Value.ToString()) + "&nbsp;";
				TBL_CONTENT.Rows[i + k + 4].Cells[24].HorizontalAlign = HorizontalAlign.Right;
				TBL_CONTENT.Rows[i + k + 4].Cells[24].CssClass= "ItemPrint_d";
				
				//Limit Change
				Tmp_Value = Convert.ToDouble(Conn.GetFieldValue(i,"Lmt_Of_LmtChg_BU")) + Convert.ToDouble(Conn.GetFieldValue(i,"Lmt_Of_LmtChg_CRM")) + Convert.ToDouble(Conn.GetFieldValue(i,"Lmt_Of_LmtChg_CO"));
				TBL_CONTENT.Rows[i + k + 4].Cells.Add(new TableCell());
				TBL_CONTENT.Rows[i + k + 4].Cells[25].Text = "&nbsp;" +  tools.ConvertCurr(Tmp_Value.ToString()) + "&nbsp;";
				TBL_CONTENT.Rows[i + k + 4].Cells[25].HorizontalAlign = HorizontalAlign.Right;
				TBL_CONTENT.Rows[i + k + 4].Cells[25].CssClass= "ItemPrint_d";

				Tmp_Value = Convert.ToDouble(Conn.GetFieldValue(i,"Nbr_Of_LmtChg_BU")) + Convert.ToDouble(Conn.GetFieldValue(i,"Nbr_Of_LmtChg_CRM")) + Convert.ToDouble(Conn.GetFieldValue(i,"Nbr_Of_LmtChg_CO"));
				TBL_CONTENT.Rows[i + k + 4].Cells.Add(new TableCell());
				TBL_CONTENT.Rows[i + k + 4].Cells[26].Text = "&nbsp;" + tools.ConvertCurr(Tmp_Value.ToString()) + "&nbsp;";
				TBL_CONTENT.Rows[i + k + 4].Cells[26].HorizontalAlign = HorizontalAlign.Right;
				TBL_CONTENT.Rows[i + k + 4].Cells[26].CssClass= "ItemPrint_d";			

//jumlah on booking
				//BusinessUnit
				Tmp_Value = Convert.ToDouble(Conn.GetFieldValue(i,"Lmt_Of_PB_BU_BOOK")) + Convert.ToDouble(Conn.GetFieldValue(i,"Lmt_Of_PB_CRM_BOOK")) + Convert.ToDouble(Conn.GetFieldValue(i,"Lmt_Of_PB_CO_BOOK"));
				TBL_CONTENT.Rows[i + k + 4].Cells.Add(new TableCell());
				TBL_CONTENT.Rows[i + k + 4].Cells[27].Text = "&nbsp;" + tools.ConvertCurr(Tmp_Value.ToString()) + "&nbsp;";
				TBL_CONTENT.Rows[i + k + 4].Cells[27].HorizontalAlign = HorizontalAlign.Right;
				TBL_CONTENT.Rows[i + k + 4].Cells[27].CssClass= "ItemPrint_d";

				Tmp_Value = Convert.ToDouble(Conn.GetFieldValue(i,"Nbr_Of_PB_BU_BOOK")) + Convert.ToDouble(Conn.GetFieldValue(i,"Nbr_Of_PB_CRM_BOOK")) + Convert.ToDouble(Conn.GetFieldValue(i,"Nbr_Of_PB_CO_BOOK"));
				TBL_CONTENT.Rows[i + k + 4].Cells.Add(new TableCell());
				TBL_CONTENT.Rows[i + k + 4].Cells[28].Text = "&nbsp;" +  tools.ConvertCurr(Tmp_Value.ToString()) + "&nbsp;";
				TBL_CONTENT.Rows[i + k + 4].Cells[28].HorizontalAlign = HorizontalAlign.Right;
				TBL_CONTENT.Rows[i + k + 4].Cells[28].CssClass= "ItemPrint_d";

				//Renewal
				Tmp_Value = Convert.ToDouble(Conn.GetFieldValue(i,"Lmt_Of_RN_BU_BOOK")) + Convert.ToDouble(Conn.GetFieldValue(i,"Lmt_Of_RN_CRM_BOOK")) + Convert.ToDouble(Conn.GetFieldValue(i,"Lmt_Of_RN_CO_BOOK"));
				TBL_CONTENT.Rows[i + k + 4].Cells.Add(new TableCell());
				TBL_CONTENT.Rows[i + k + 4].Cells[29].Text = "&nbsp;" +  tools.ConvertCurr(Tmp_Value.ToString()) + "&nbsp;";
				TBL_CONTENT.Rows[i + k + 4].Cells[29].HorizontalAlign = HorizontalAlign.Right;
				TBL_CONTENT.Rows[i + k + 4].Cells[29].CssClass= "ItemPrint_d";

				Tmp_Value = Convert.ToDouble(Conn.GetFieldValue(i,"Nbr_Of_RN_BU_BOOK")) + Convert.ToDouble(Conn.GetFieldValue(i,"Nbr_Of_RN_CRM_BOOK")) + Convert.ToDouble(Conn.GetFieldValue(i,"Nbr_Of_RN_CO_BOOK"));
				TBL_CONTENT.Rows[i + k + 4].Cells.Add(new TableCell());
				TBL_CONTENT.Rows[i + k + 4].Cells[30].Text = "&nbsp;" +  Tmp_Value.ToString() + "&nbsp;";
				TBL_CONTENT.Rows[i + k + 4].Cells[30].HorizontalAlign = HorizontalAlign.Right;
				TBL_CONTENT.Rows[i + k + 4].Cells[30].CssClass= "ItemPrint_d";
				
				//Limit Change
				Tmp_Value = Convert.ToDouble(Conn.GetFieldValue(i,"Lmt_Of_LmtChg_BU_BOOK")) + Convert.ToDouble(Conn.GetFieldValue(i,"Lmt_Of_LmtChg_CRM_BOOK")) + Convert.ToDouble(Conn.GetFieldValue(i,"Lmt_Of_LmtChg_CO_BOOK"));
				TBL_CONTENT.Rows[i + k + 4].Cells.Add(new TableCell());
				TBL_CONTENT.Rows[i + k + 4].Cells[31].Text = "&nbsp;" +  tools.ConvertCurr(Tmp_Value.ToString()) + "&nbsp;";
				TBL_CONTENT.Rows[i + k + 4].Cells[31].HorizontalAlign = HorizontalAlign.Right;
				TBL_CONTENT.Rows[i + k + 4].Cells[31].CssClass= "ItemPrint_d";

				Tmp_Value = Convert.ToDouble(Conn.GetFieldValue(i,"Nbr_Of_LmtChg_BU_BOOK")) + Convert.ToDouble(Conn.GetFieldValue(i,"Nbr_Of_LmtChg_CRM_BOOK")) + Convert.ToDouble(Conn.GetFieldValue(i,"Nbr_Of_LmtChg_CO_BOOK"));
				TBL_CONTENT.Rows[i + k + 4].Cells.Add(new TableCell());
				TBL_CONTENT.Rows[i + k + 4].Cells[32].Text = "&nbsp;" +  Tmp_Value.ToString() + "&nbsp;";
				TBL_CONTENT.Rows[i + k + 4].Cells[32].HorizontalAlign = HorizontalAlign.Right;
				TBL_CONTENT.Rows[i + k + 4].Cells[32].CssClass= "ItemPrint_d";
			}
			//Sub Total
			TBL_CONTENT.Rows.Add(new TableRow());
			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 4].Cells.Add(new TableCell());
			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 4].Cells[0].Text = "&nbsp;";
			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 4].Cells[0].HorizontalAlign = HorizontalAlign.Center;
			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 4].Cells[0].CssClass= "ItemPrint_d";

			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 4].Cells.Add(new TableCell());
			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 4].Cells[1].Font.Bold=true;
			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 4].Cells[1].Text = "&nbsp;SUB TOTAL&nbsp;";
			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 4].Cells[1].HorizontalAlign = HorizontalAlign.Center;
			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 4].Cells[1].CssClass= "ItemPrint_d";

			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 4].Cells.Add(new TableCell());
			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 4].Cells[2].Text = "&nbsp;" ;
			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 4].Cells[2].HorizontalAlign = HorizontalAlign.Left;
			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 4].Cells[2].CssClass= "ItemPrint_d";

			//BusinessUnit
			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 4].Cells.Add(new TableCell());
			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 4].Cells[3].Font.Bold=true;
			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 4].Cells[3].Text = "&nbsp;" + tools.ConvertCurr(sLmt_Of_PB_BU.ToString()) + "&nbsp;";
			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 4].Cells[3].HorizontalAlign = HorizontalAlign.Right;
			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 4].Cells[3].CssClass= "ItemPrint_d";

			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 4].Cells.Add(new TableCell());
			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 4].Cells[4].Font.Bold=true;
			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 4].Cells[4].Text = "&nbsp;" + sNbr_Of_PB_BU.ToString() + "&nbsp;";
			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 4].Cells[4].HorizontalAlign = HorizontalAlign.Right;
			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 4].Cells[4].CssClass= "ItemPrint_d";

			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 4].Cells.Add(new TableCell());
			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 4].Cells[5].Font.Bold=true;
			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 4].Cells[5].Text = "&nbsp;" + tools.ConvertCurr(sLmt_Of_RN_BU.ToString()) + "&nbsp;";
			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 4].Cells[5].HorizontalAlign = HorizontalAlign.Right;
			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 4].Cells[5].CssClass= "ItemPrint_d";

			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 4].Cells.Add(new TableCell());
			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 4].Cells[6].Font.Bold=true;
			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 4].Cells[6].Text = "&nbsp;" + sNbr_Of_RN_BU.ToString() + "&nbsp;";
			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 4].Cells[6].HorizontalAlign = HorizontalAlign.Right;
			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 4].Cells[6].CssClass= "ItemPrint_d";

			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 4].Cells.Add(new TableCell());
			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 4].Cells[7].Font.Bold=true;
			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 4].Cells[7].Text = "&nbsp;" + tools.ConvertCurr(sLmt_Of_LmtChg_BU.ToString()) + "&nbsp;";
			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 4].Cells[7].HorizontalAlign = HorizontalAlign.Right;
			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 4].Cells[7].CssClass= "ItemPrint_d";

			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 4].Cells.Add(new TableCell());
			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 4].Cells[8].Font.Bold=true;
			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 4].Cells[8].Text = "&nbsp;" + sNbr_Of_LmtChg_BU.ToString()  + "&nbsp;";
			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 4].Cells[8].HorizontalAlign = HorizontalAlign.Right;
			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 4].Cells[8].CssClass= "ItemPrint_d";

			//CRM
			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 4].Cells.Add(new TableCell());
			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 4].Cells[9].Font.Bold=true;
			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 4].Cells[9].Text = "&nbsp;" + tools.ConvertCurr(sLmt_Of_PB_CRM.ToString()) + "&nbsp;";
			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 4].Cells[9].HorizontalAlign = HorizontalAlign.Right;
			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 4].Cells[9].CssClass= "ItemPrint_d";

			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 4].Cells.Add(new TableCell());
			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 4].Cells[10].Font.Bold=true;
			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 4].Cells[10].Text = "&nbsp;" + sNbr_Of_PB_CRM.ToString() + "&nbsp;";
			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 4].Cells[10].HorizontalAlign = HorizontalAlign.Right;
			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 4].Cells[10].CssClass= "ItemPrint_d";

			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 4].Cells.Add(new TableCell());
			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 4].Cells[11].Font.Bold=true;
			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 4].Cells[11].Text = "&nbsp;" + tools.ConvertCurr(sLmt_Of_RN_CRM.ToString()) + "&nbsp;";
			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 4].Cells[11].HorizontalAlign = HorizontalAlign.Right;
			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 4].Cells[11].CssClass= "ItemPrint_d";

			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 4].Cells.Add(new TableCell());
			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 4].Cells[12].Font.Bold=true;
			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 4].Cells[12].Text = "&nbsp;" + sNbr_Of_RN_CRM.ToString() + "&nbsp;";
			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 4].Cells[12].HorizontalAlign = HorizontalAlign.Right;
			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 4].Cells[12].CssClass= "ItemPrint_d";

			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 4].Cells.Add(new TableCell());
			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 4].Cells[13].Font.Bold=true;
			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 4].Cells[13].Text = "&nbsp;" + tools.ConvertCurr(sLmt_Of_LmtChg_CRM.ToString()) + "&nbsp;";
			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 4].Cells[13].HorizontalAlign = HorizontalAlign.Right;
			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 4].Cells[13].CssClass= "ItemPrint_d";

			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 4].Cells.Add(new TableCell());
			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 4].Cells[14].Font.Bold=true;
			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 4].Cells[14].Text = "&nbsp;" + sNbr_Of_LmtChg_CRM.ToString() + "&nbsp;";
			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 4].Cells[14].HorizontalAlign = HorizontalAlign.Right;
			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 4].Cells[14].CssClass= "ItemPrint_d";

			//CO
			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 4].Cells.Add(new TableCell());
			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 4].Cells[15].Font.Bold=true;
			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 4].Cells[15].Text = "&nbsp;" + tools.ConvertCurr(sLmt_Of_PB_CO.ToString()) + "&nbsp;";
			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 4].Cells[15].HorizontalAlign = HorizontalAlign.Right;
			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 4].Cells[15].CssClass= "ItemPrint_d";

			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 4].Cells.Add(new TableCell());
			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 4].Cells[16].Font.Bold=true;
			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 4].Cells[16].Text = "&nbsp;" + sNbr_Of_PB_CO.ToString() + "&nbsp;";
			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 4].Cells[16].HorizontalAlign = HorizontalAlign.Right;
			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 4].Cells[16].CssClass= "ItemPrint_d";

			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 4].Cells.Add(new TableCell());
			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 4].Cells[17].Font.Bold=true;
			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 4].Cells[17].Text = "&nbsp;" + tools.ConvertCurr(sLmt_Of_RN_CO.ToString()) + "&nbsp;";
			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 4].Cells[17].HorizontalAlign = HorizontalAlign.Right;
			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 4].Cells[17].CssClass= "ItemPrint_d";

			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 4].Cells.Add(new TableCell());
			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 4].Cells[18].Font.Bold=true;
			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 4].Cells[18].Text = "&nbsp;" + sNbr_Of_RN_CO.ToString() + "&nbsp;";
			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 4].Cells[18].HorizontalAlign = HorizontalAlign.Right;
			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 4].Cells[18].CssClass= "ItemPrint_d";

			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 4].Cells.Add(new TableCell());
			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 4].Cells[19].Font.Bold=true;
			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 4].Cells[19].Text = "&nbsp;" + tools.ConvertCurr(sLmt_Of_LmtChg_CO.ToString()) + "&nbsp;";
			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 4].Cells[19].HorizontalAlign = HorizontalAlign.Right;
			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 4].Cells[19].CssClass= "ItemPrint_d";

			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 4].Cells.Add(new TableCell());
			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 4].Cells[20].Font.Bold=true;
			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 4].Cells[20].Text = "&nbsp;" + sNbr_Of_LmtChg_CO.ToString() + "&nbsp;";
			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 4].Cells[20].HorizontalAlign = HorizontalAlign.Right;
			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 4].Cells[20].CssClass= "ItemPrint_d";

			//jumlah dalam proses
			//BusinessUnit
			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 4].Cells.Add(new TableCell());
			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 4].Cells[21].Font.Bold=true;
			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 4].Cells[21].Text = "&nbsp;" +  tools.ConvertCurr(sLmt_Of_PB.ToString()) + "&nbsp;";
			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 4].Cells[21].HorizontalAlign = HorizontalAlign.Right;
			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 4].Cells[21].CssClass= "ItemPrint_d";

			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 4].Cells.Add(new TableCell());
			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 4].Cells[22].Font.Bold=true;
			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 4].Cells[22].Text = "&nbsp;" +  sNbr_Of_PB.ToString() + "&nbsp;";
			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 4].Cells[22].HorizontalAlign = HorizontalAlign.Right;
			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 4].Cells[22].CssClass= "ItemPrint_d";

			//Renewal
			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 4].Cells.Add(new TableCell());
			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 4].Cells[23].Font.Bold=true;
			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 4].Cells[23].Text = "&nbsp;" + tools.ConvertCurr(sLmt_Of_RN.ToString()) + "&nbsp;";
			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 4].Cells[23].HorizontalAlign = HorizontalAlign.Right;
			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 4].Cells[23].CssClass= "ItemPrint_d";

			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 4].Cells.Add(new TableCell());
			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 4].Cells[24].Font.Bold=true;
			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 4].Cells[24].Text = "&nbsp;" +  sNbr_Of_RN.ToString() + "&nbsp;";
			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 4].Cells[24].HorizontalAlign = HorizontalAlign.Right;
			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 4].Cells[24].CssClass= "ItemPrint_d";
				
			//Limit Change
			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 4].Cells.Add(new TableCell());
			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 4].Cells[25].Font.Bold=true;
			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 4].Cells[25].Text = "&nbsp;" +  tools.ConvertCurr(sLmt_Of_LmtChg.ToString()) + "&nbsp;";
			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 4].Cells[25].HorizontalAlign = HorizontalAlign.Right;
			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 4].Cells[25].CssClass= "ItemPrint_d";

			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 4].Cells.Add(new TableCell());
			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 4].Cells[26].Font.Bold=true;
			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 4].Cells[26].Text = "&nbsp;" + tools.ConvertCurr(sNbr_Of_LmtChg.ToString()) + "&nbsp;";
			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 4].Cells[26].HorizontalAlign = HorizontalAlign.Right;
			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 4].Cells[26].CssClass= "ItemPrint_d";			

			//jumlah on booking
			//BusinessUnit
			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 4].Cells.Add(new TableCell());
			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 4].Cells[27].Font.Bold=true;
			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 4].Cells[27].Text = "&nbsp;" + tools.ConvertCurr(sLmt_Of_PB_BOOK.ToString()) + "&nbsp;";
			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 4].Cells[27].HorizontalAlign = HorizontalAlign.Right;
			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 4].Cells[27].CssClass= "ItemPrint_d";

			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 4].Cells.Add(new TableCell());
			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 4].Cells[28].Font.Bold=true;
			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 4].Cells[28].Text = "&nbsp;" +  tools.ConvertCurr(sNbr_Of_PB_BOOK.ToString()) + "&nbsp;";
			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 4].Cells[28].HorizontalAlign = HorizontalAlign.Right;
			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 4].Cells[28].CssClass= "ItemPrint_d";

			//Renewal
			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 4].Cells.Add(new TableCell());
			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 4].Cells[29].Font.Bold=true;
			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 4].Cells[29].Text = "&nbsp;" +  tools.ConvertCurr(sLmt_Of_RN_BOOK.ToString()) + "&nbsp;";
			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 4].Cells[29].HorizontalAlign = HorizontalAlign.Right;
			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 4].Cells[29].CssClass= "ItemPrint_d";

			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 4].Cells.Add(new TableCell());
			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 4].Cells[30].Font.Bold=true;
			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 4].Cells[30].Text = "&nbsp;" +  sNbr_Of_RN_BOOK.ToString() + "&nbsp;";
			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 4].Cells[30].HorizontalAlign = HorizontalAlign.Right;
			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 4].Cells[30].CssClass= "ItemPrint_d";
				
			//Limit Change
			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 4].Cells.Add(new TableCell());
			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 4].Cells[31].Font.Bold=true;
			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 4].Cells[31].Text = "&nbsp;" +  tools.ConvertCurr(sLmt_Of_LmtChg_BOOK.ToString()) + "&nbsp;";
			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 4].Cells[31].HorizontalAlign = HorizontalAlign.Right;
			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 4].Cells[31].CssClass= "ItemPrint_d";

			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 4].Cells.Add(new TableCell());
			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 4].Cells[23].Font.Bold=true;
			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 4].Cells[32].Text = "&nbsp;" +  sNbr_Of_LmtChg_BOOK.ToString() + "&nbsp;";
			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 4].Cells[32].HorizontalAlign = HorizontalAlign.Right;
			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 4].Cells[32].CssClass= "ItemPrint_d";

			//Total
			TBL_CONTENT.Rows.Add(new TableRow());
			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 5].Cells.Add(new TableCell());
			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 5].Cells[0].Text = "&nbsp;";
			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 5].Cells[0].HorizontalAlign = HorizontalAlign.Center;
			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 5].Cells[0].CssClass= "ItemPrint_d";

			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 5].Cells.Add(new TableCell());
			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 5].Cells[1].Font.Bold=true;
			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 5].Cells[1].Text = "&nbsp;TOTAL&nbsp;";
			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 5].Cells[1].HorizontalAlign = HorizontalAlign.Center;
			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 5].Cells[1].CssClass= "ItemPrint_d";

			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 5].Cells.Add(new TableCell());
			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 5].Cells[2].Text = "&nbsp;" ;
			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 5].Cells[2].HorizontalAlign = HorizontalAlign.Left;
			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 5].Cells[2].CssClass= "ItemPrint_d";

			//BusinessUnit
			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 5].Cells.Add(new TableCell());
			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 5].Cells[3].Font.Bold=true;
			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 5].Cells[3].Text = "&nbsp;" + tools.ConvertCurr(tLmt_Of_PB_BU.ToString()) + "&nbsp;";
			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 5].Cells[3].HorizontalAlign = HorizontalAlign.Right;
			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 5].Cells[3].CssClass= "ItemPrint_d";

			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 5].Cells.Add(new TableCell());
			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 5].Cells[4].Font.Bold=true;
			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 5].Cells[4].Text = "&nbsp;" + tNbr_Of_PB_BU.ToString() + "&nbsp;";
			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 5].Cells[4].HorizontalAlign = HorizontalAlign.Right;
			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 5].Cells[4].CssClass= "ItemPrint_d";

			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 5].Cells.Add(new TableCell());
			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 5].Cells[5].Font.Bold=true;
			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 5].Cells[5].Text = "&nbsp;" + tools.ConvertCurr(tLmt_Of_RN_BU.ToString()) + "&nbsp;";
			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 5].Cells[5].HorizontalAlign = HorizontalAlign.Right;
			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 5].Cells[5].CssClass= "ItemPrint_d";

			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 5].Cells.Add(new TableCell());
			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 5].Cells[6].Font.Bold=true;
			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 5].Cells[6].Text = "&nbsp;" + tNbr_Of_RN_BU.ToString() + "&nbsp;";
			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 5].Cells[6].HorizontalAlign = HorizontalAlign.Right;
			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 5].Cells[6].CssClass= "ItemPrint_d";

			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 5].Cells.Add(new TableCell());
			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 5].Cells[7].Font.Bold=true;
			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 5].Cells[7].Text = "&nbsp;" + tools.ConvertCurr(tLmt_Of_LmtChg_BU.ToString()) + "&nbsp;";
			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 5].Cells[7].HorizontalAlign = HorizontalAlign.Right;
			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 5].Cells[7].CssClass= "ItemPrint_d";

			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 5].Cells.Add(new TableCell());
			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 5].Cells[8].Font.Bold=true;
			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 5].Cells[8].Text = "&nbsp;" + tNbr_Of_LmtChg_BU.ToString()  + "&nbsp;";
			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 5].Cells[8].HorizontalAlign = HorizontalAlign.Right;
			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 5].Cells[8].CssClass= "ItemPrint_d";

			//CRM
			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 5].Cells.Add(new TableCell());
			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 5].Cells[9].Font.Bold=true;
			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 5].Cells[9].Text = "&nbsp;" + tools.ConvertCurr(tLmt_Of_PB_CRM.ToString()) + "&nbsp;";
			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 5].Cells[9].HorizontalAlign = HorizontalAlign.Right;
			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 5].Cells[9].CssClass= "ItemPrint_d";

			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 5].Cells.Add(new TableCell());
			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 5].Cells[10].Font.Bold=true;
			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 5].Cells[10].Text = "&nbsp;" + tNbr_Of_PB_CRM.ToString() + "&nbsp;";
			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 5].Cells[10].HorizontalAlign = HorizontalAlign.Right;
			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 5].Cells[10].CssClass= "ItemPrint_d";

			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 5].Cells.Add(new TableCell());
			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 5].Cells[11].Font.Bold=true;
			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 5].Cells[11].Text = "&nbsp;" + tools.ConvertCurr(tLmt_Of_RN_CRM.ToString()) + "&nbsp;";
			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 5].Cells[11].HorizontalAlign = HorizontalAlign.Right;
			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 5].Cells[11].CssClass= "ItemPrint_d";

			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 5].Cells.Add(new TableCell());
			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 5].Cells[12].Font.Bold=true;
			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 5].Cells[12].Text = "&nbsp;" + tNbr_Of_RN_CRM.ToString() + "&nbsp;";
			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 5].Cells[12].HorizontalAlign = HorizontalAlign.Right;
			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 5].Cells[12].CssClass= "ItemPrint_d";

			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 5].Cells.Add(new TableCell());
			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 5].Cells[13].Font.Bold=true;
			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 5].Cells[13].Text = "&nbsp;" + tools.ConvertCurr(tLmt_Of_LmtChg_CRM.ToString()) + "&nbsp;";
			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 5].Cells[13].HorizontalAlign = HorizontalAlign.Right;
			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 5].Cells[13].CssClass= "ItemPrint_d";

			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 5].Cells.Add(new TableCell());
			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 5].Cells[14].Font.Bold=true;
			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 5].Cells[14].Text = "&nbsp;" + tNbr_Of_LmtChg_CRM.ToString() + "&nbsp;";
			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 5].Cells[14].HorizontalAlign = HorizontalAlign.Right;
			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 5].Cells[14].CssClass= "ItemPrint_d";

			//CO
			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 5].Cells.Add(new TableCell());
			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 5].Cells[15].Font.Bold=true;
			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 5].Cells[15].Text = "&nbsp;" + tools.ConvertCurr(tLmt_Of_PB_CO.ToString()) + "&nbsp;";
			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 5].Cells[15].HorizontalAlign = HorizontalAlign.Right;
			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 5].Cells[15].CssClass= "ItemPrint_d";

			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 5].Cells.Add(new TableCell());
			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 5].Cells[16].Font.Bold=true;
			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 5].Cells[16].Text = "&nbsp;" + tNbr_Of_PB_CO.ToString() + "&nbsp;";
			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 5].Cells[16].HorizontalAlign = HorizontalAlign.Right;
			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 5].Cells[16].CssClass= "ItemPrint_d";

			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 5].Cells.Add(new TableCell());
			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 5].Cells[17].Font.Bold=true;
			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 5].Cells[17].Text = "&nbsp;" + tools.ConvertCurr(tLmt_Of_RN_CO.ToString()) + "&nbsp;";
			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 5].Cells[17].HorizontalAlign = HorizontalAlign.Right;
			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 5].Cells[17].CssClass= "ItemPrint_d";

			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 5].Cells.Add(new TableCell());
			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 5].Cells[18].Font.Bold=true;
			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 5].Cells[18].Text = "&nbsp;" + tNbr_Of_RN_CO.ToString() + "&nbsp;";
			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 5].Cells[18].HorizontalAlign = HorizontalAlign.Right;
			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 5].Cells[18].CssClass= "ItemPrint_d";

			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 5].Cells.Add(new TableCell());
			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 5].Cells[19].Font.Bold=true;
			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 5].Cells[19].Text = "&nbsp;" + tools.ConvertCurr(tLmt_Of_LmtChg_CO.ToString()) + "&nbsp;";
			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 5].Cells[19].HorizontalAlign = HorizontalAlign.Right;
			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 5].Cells[19].CssClass= "ItemPrint_d";

			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 5].Cells.Add(new TableCell());
			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 5].Cells[20].Font.Bold=true;
			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 5].Cells[20].Text = "&nbsp;" + tNbr_Of_LmtChg_CO.ToString() + "&nbsp;";
			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 5].Cells[20].HorizontalAlign = HorizontalAlign.Right;
			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 5].Cells[20].CssClass= "ItemPrint_d";

			//jumlah dalam proses
			//BusinessUnit
			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 5].Cells.Add(new TableCell());
			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 5].Cells[21].Font.Bold=true;
			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 5].Cells[21].Text = "&nbsp;" +  tools.ConvertCurr(tLmt_Of_PB.ToString()) + "&nbsp;";
			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 5].Cells[21].HorizontalAlign = HorizontalAlign.Right;
			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 5].Cells[21].CssClass= "ItemPrint_d";

			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 5].Cells.Add(new TableCell());
			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 5].Cells[22].Font.Bold=true;
			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 5].Cells[22].Text = "&nbsp;" +  tNbr_Of_PB.ToString() + "&nbsp;";
			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 5].Cells[22].HorizontalAlign = HorizontalAlign.Right;
			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 5].Cells[22].CssClass= "ItemPrint_d";

			//Renewal
			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 5].Cells.Add(new TableCell());
			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 5].Cells[23].Font.Bold=true;
			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 5].Cells[23].Text = "&nbsp;" + tools.ConvertCurr(tLmt_Of_RN.ToString()) + "&nbsp;";
			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 5].Cells[23].HorizontalAlign = HorizontalAlign.Right;
			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 5].Cells[23].CssClass= "ItemPrint_d";

			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 5].Cells.Add(new TableCell());
			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 5].Cells[24].Font.Bold=true;
			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 5].Cells[24].Text = "&nbsp;" +  tNbr_Of_RN.ToString() + "&nbsp;";
			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 5].Cells[24].HorizontalAlign = HorizontalAlign.Right;
			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 5].Cells[24].CssClass= "ItemPrint_d";
				
			//Limit Change
			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 5].Cells.Add(new TableCell());
			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 5].Cells[25].Font.Bold=true;
			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 5].Cells[25].Text = "&nbsp;" +  tools.ConvertCurr(tLmt_Of_LmtChg.ToString()) + "&nbsp;";
			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 5].Cells[25].HorizontalAlign = HorizontalAlign.Right;
			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 5].Cells[25].CssClass= "ItemPrint_d";

			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 5].Cells.Add(new TableCell());
			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 5].Cells[26].Font.Bold=true;
			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 5].Cells[26].Text = "&nbsp;" + tools.ConvertCurr(tNbr_Of_LmtChg.ToString()) + "&nbsp;";
			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 5].Cells[26].HorizontalAlign = HorizontalAlign.Right;
			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 5].Cells[26].CssClass= "ItemPrint_d";			

			//jumlah on booking
			//BusinessUnit
			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 5].Cells.Add(new TableCell());
			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 5].Cells[27].Font.Bold=true;
			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 5].Cells[27].Text = "&nbsp;" + tools.ConvertCurr(tLmt_Of_PB_BOOK.ToString()) + "&nbsp;";
			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 5].Cells[27].HorizontalAlign = HorizontalAlign.Right;
			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 5].Cells[27].CssClass= "ItemPrint_d";

			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 5].Cells.Add(new TableCell());
			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 5].Cells[28].Font.Bold=true;
			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 5].Cells[28].Text = "&nbsp;" +  tools.ConvertCurr(tNbr_Of_PB_BOOK.ToString()) + "&nbsp;";
			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 5].Cells[28].HorizontalAlign = HorizontalAlign.Right;
			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 5].Cells[28].CssClass= "ItemPrint_d";

			//Renewal
			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 5].Cells.Add(new TableCell());
			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 5].Cells[29].Font.Bold=true;
			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 5].Cells[29].Text = "&nbsp;" +  tools.ConvertCurr(tLmt_Of_RN_BOOK.ToString()) + "&nbsp;";
			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 5].Cells[29].HorizontalAlign = HorizontalAlign.Right;
			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 5].Cells[29].CssClass= "ItemPrint_d";

			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 5].Cells.Add(new TableCell());
			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 5].Cells[30].Font.Bold=true;
			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 5].Cells[30].Text = "&nbsp;" +  tNbr_Of_RN_BOOK.ToString() + "&nbsp;";
			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 5].Cells[30].HorizontalAlign = HorizontalAlign.Right;
			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 5].Cells[30].CssClass= "ItemPrint_d";
				
			//Limit Change
			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 5].Cells.Add(new TableCell());
			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 5].Cells[31].Font.Bold=true;
			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 5].Cells[31].Text = "&nbsp;" +  tools.ConvertCurr(tLmt_Of_LmtChg_BOOK.ToString()) + "&nbsp;";
			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 5].Cells[31].HorizontalAlign = HorizontalAlign.Right;
			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 5].Cells[31].CssClass= "ItemPrint_d";

			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 5].Cells.Add(new TableCell());
			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 5].Cells[23].Font.Bold=true;
			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 5].Cells[32].Text = "&nbsp;" +  tNbr_Of_LmtChg_BOOK.ToString() + "&nbsp;";
			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 5].Cells[32].HorizontalAlign = HorizontalAlign.Right;
			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 5].Cells[32].CssClass= "ItemPrint_d";
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
