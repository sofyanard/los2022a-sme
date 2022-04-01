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
	/// Summary description for RptPipeLine1SummPrint.
	/// </summary>
	public partial class RptPipeLine1SummPrint : System.Web.UI.Page
	{
		protected Connection Conn = new Connection();
		protected Tools tools = new Tools();

		protected void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
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
			double tmp_LMT=0, tmp_NBR=0;;
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

			Conn.QueryString = "EXEC Rpt_PipeLine2 '" + sql_kondisi + "' ";
			Conn.ExecuteQuery();
			for (int i = 0; i < Conn.GetRowCount(); i++)
			{
				if (pre_area.ToString()!=Conn.GetFieldValue(i,"areaname"))
				{
					if (i.ToString()!="0")
					{
						TBL_CONTENT.Rows.Add(new TableRow());
						TBL_CONTENT.Rows[i + k + 3].Cells.Add(new TableCell());
						TBL_CONTENT.Rows[i + k + 3].Cells[0].Text = "&nbsp;";
						TBL_CONTENT.Rows[i + k + 3].Cells[0].HorizontalAlign = HorizontalAlign.Center;
						TBL_CONTENT.Rows[i + k + 3].Cells[0].CssClass= "ItemPrint_d";

						TBL_CONTENT.Rows[i + k + 3].Cells.Add(new TableCell());
						TBL_CONTENT.Rows[i + k + 3].Cells[1].Font.Bold=true;
						TBL_CONTENT.Rows[i + k + 3].Cells[1].Text = "&nbsp;SUB TOTAL&nbsp;";
						TBL_CONTENT.Rows[i + k + 3].Cells[1].HorizontalAlign = HorizontalAlign.Center;
						TBL_CONTENT.Rows[i + k + 3].Cells[1].CssClass= "ItemPrint_d";

						TBL_CONTENT.Rows[i + k + 3].Cells.Add(new TableCell());
						TBL_CONTENT.Rows[i + k + 3].Cells[2].Text = "&nbsp;" ;
						TBL_CONTENT.Rows[i + k + 3].Cells[2].HorizontalAlign = HorizontalAlign.Left;
						TBL_CONTENT.Rows[i + k + 3].Cells[2].CssClass= "ItemPrint_d";

						//BusinessUnit
						tmp_LMT = (double.Parse(sLmt_Of_PB_BU.ToString()) + double.Parse(sLmt_Of_RN_BU.ToString()) + double.Parse(sLmt_Of_LmtChg_BU.ToString()))/1000000;
						TBL_CONTENT.Rows[i + k + 3].Cells.Add(new TableCell());
						TBL_CONTENT.Rows[i + k + 3].Cells[3].Font.Bold=true;
						TBL_CONTENT.Rows[i + k + 3].Cells[3].Text = "&nbsp;" +  tmp_LMT.ToString() + "&nbsp;";
						TBL_CONTENT.Rows[i + k + 3].Cells[3].HorizontalAlign = HorizontalAlign.Right;
						TBL_CONTENT.Rows[i + k + 3].Cells[3].CssClass= "ItemPrint_d";
			
						tmp_NBR = double.Parse(sNbr_Of_PB_BU.ToString()) + double.Parse(sNbr_Of_RN_BU.ToString()) + double.Parse(sNbr_Of_LmtChg_BU.ToString());
						TBL_CONTENT.Rows[i + k + 3].Cells.Add(new TableCell());
						TBL_CONTENT.Rows[i + k + 3].Cells[4].Font.Bold=true;
						TBL_CONTENT.Rows[i + k + 3].Cells[4].Text = "&nbsp;" + tmp_NBR.ToString() + "&nbsp;";
						TBL_CONTENT.Rows[i + k + 3].Cells[4].HorizontalAlign = HorizontalAlign.Right;
						TBL_CONTENT.Rows[i + k + 3].Cells[4].CssClass= "ItemPrint_d";

						//CRM
						tmp_LMT = (double.Parse(sLmt_Of_PB_CRM.ToString()) + double.Parse(sLmt_Of_RN_CRM.ToString()) + double.Parse(sLmt_Of_LmtChg_CRM.ToString()))/1000000;
						TBL_CONTENT.Rows[i + k + 3].Cells.Add(new TableCell());
						TBL_CONTENT.Rows[i + k + 3].Cells[5].Font.Bold=true;
						TBL_CONTENT.Rows[i + k + 3].Cells[5].Text = "&nbsp;" + tmp_LMT.ToString() + "&nbsp;";
						TBL_CONTENT.Rows[i + k + 3].Cells[5].HorizontalAlign = HorizontalAlign.Right;
						TBL_CONTENT.Rows[i + k + 3].Cells[5].CssClass= "ItemPrint_d";

						tmp_NBR = double.Parse(sNbr_Of_PB_CRM.ToString()) + double.Parse(sNbr_Of_RN_CRM.ToString()) + double.Parse(sNbr_Of_LmtChg_CRM.ToString());
						TBL_CONTENT.Rows[i + k + 3].Cells.Add(new TableCell());
						TBL_CONTENT.Rows[i + k + 3].Cells[6].Font.Bold=true;
						TBL_CONTENT.Rows[i + k + 3].Cells[6].Text = "&nbsp;" +  tmp_NBR.ToString() + "&nbsp;";
						TBL_CONTENT.Rows[i + k + 3].Cells[6].HorizontalAlign = HorizontalAlign.Right;
						TBL_CONTENT.Rows[i + k + 3].Cells[6].CssClass= "ItemPrint_d";
				
						//CO
						tmp_LMT = (double.Parse(sLmt_Of_RN_CO.ToString())  + double.Parse(sLmt_Of_LmtChg_CO.ToString()) + double.Parse(sLmt_Of_PB_CO.ToString()))/1000000;
						TBL_CONTENT.Rows[i + k + 3].Cells.Add(new TableCell());
						TBL_CONTENT.Rows[i + k + 3].Cells[7].Font.Bold=true;
						TBL_CONTENT.Rows[i + k + 3].Cells[7].Text = "&nbsp;" + tmp_LMT.ToString() + "&nbsp;";
						TBL_CONTENT.Rows[i + k + 3].Cells[7].HorizontalAlign = HorizontalAlign.Right;
						TBL_CONTENT.Rows[i + k + 3].Cells[7].CssClass= "ItemPrint_d";

						tmp_NBR = double.Parse(sNbr_Of_PB_CO.ToString())+ double.Parse(sNbr_Of_RN_CO.ToString()) + double.Parse(sNbr_Of_LmtChg_CO.ToString());
						TBL_CONTENT.Rows[i + k + 3].Cells.Add(new TableCell());
						TBL_CONTENT.Rows[i + k + 3].Cells[8].Font.Bold=true;
						TBL_CONTENT.Rows[i + k + 3].Cells[8].Text = "&nbsp;" + tmp_NBR.ToString() + "&nbsp;";
						TBL_CONTENT.Rows[i + k + 3].Cells[8].HorizontalAlign = HorizontalAlign.Right;
						TBL_CONTENT.Rows[i + k + 3].Cells[8].CssClass= "ItemPrint_d";

						//jumlah dalam proses
						//BusinessUnit
						tmp_LMT = (double.Parse(sLmt_Of_PB.ToString().ToString()) + double.Parse(sLmt_Of_RN.ToString().ToString())  + double.Parse(sLmt_Of_LmtChg.ToString().ToString()))/1000000;
						TBL_CONTENT.Rows[i + k + 3].Cells.Add(new TableCell());
						TBL_CONTENT.Rows[i + k + 3].Cells[9].Font.Bold=true;
						TBL_CONTENT.Rows[i + k + 3].Cells[9].Text = "&nbsp;" +  tmp_LMT.ToString() + "&nbsp;";
						TBL_CONTENT.Rows[i + k + 3].Cells[9].HorizontalAlign = HorizontalAlign.Right;
						TBL_CONTENT.Rows[i + k + 3].Cells[9].CssClass= "ItemPrint_d";

						tmp_NBR = double.Parse(sNbr_Of_PB.ToString()) + double.Parse(sNbr_Of_RN.ToString()) + double.Parse(sNbr_Of_LmtChg.ToString()); 
						TBL_CONTENT.Rows[i + k + 3].Cells.Add(new TableCell());
						TBL_CONTENT.Rows[i + k + 3].Cells[10].Font.Bold=true;
						TBL_CONTENT.Rows[i + k + 3].Cells[10].Text = "&nbsp;" +  tmp_NBR.ToString() + "&nbsp;";
						TBL_CONTENT.Rows[i + k + 3].Cells[10].HorizontalAlign = HorizontalAlign.Right;
						TBL_CONTENT.Rows[i + k + 3].Cells[10].CssClass= "ItemPrint_d";

						/*
						TBL_CONTENT.Rows[i + k + 3].Cells.Add(new TableCell());
						TBL_CONTENT.Rows[i + k + 3].Cells[11].Font.Bold=true;
						TBL_CONTENT.Rows[i + k + 3].Cells[11].Text = "&nbsp;" + tools.ConvertCurr(sLmt_Of_RN.ToString()) + "&nbsp;";
						TBL_CONTENT.Rows[i + k + 3].Cells[11].HorizontalAlign = HorizontalAlign.Right;
						TBL_CONTENT.Rows[i + k + 3].Cells[11].CssClass= "ItemPrint_d";

						TBL_CONTENT.Rows[i + k + 3].Cells.Add(new TableCell());
						TBL_CONTENT.Rows[i + k + 3].Cells[13].Font.Bold=true;
						TBL_CONTENT.Rows[i + k + 3].Cells[13].Text = "&nbsp;" +  tools.ConvertCurr(sLmt_Of_LmtChg.ToString()) + "&nbsp;";
						TBL_CONTENT.Rows[i + k + 3].Cells[13].HorizontalAlign = HorizontalAlign.Right;
						TBL_CONTENT.Rows[i + k + 3].Cells[13].CssClass= "ItemPrint_d";
	*/
						/*
											TBL_CONTENT.Rows[i + k + 3].Cells.Add(new TableCell());
											TBL_CONTENT.Rows[i + k + 3].Cells[12].Font.Bold=true;
											TBL_CONTENT.Rows[i + k + 3].Cells[12].Text = "&nbsp;" +  sNbr_Of_RN.ToString() + "&nbsp;";
											TBL_CONTENT.Rows[i + k + 3].Cells[12].HorizontalAlign = HorizontalAlign.Right;
											TBL_CONTENT.Rows[i + k + 3].Cells[12].CssClass= "ItemPrint_d";
				
											//Limit Change

											TBL_CONTENT.Rows[i + k + 3].Cells.Add(new TableCell());
											TBL_CONTENT.Rows[i + k + 3].Cells[14].Font.Bold=true;
											TBL_CONTENT.Rows[i + k + 3].Cells[14].Text = "&nbsp;" + tools.ConvertCurr(sNbr_Of_LmtChg.ToString()) + "&nbsp;";
											TBL_CONTENT.Rows[i + k + 3].Cells[14].HorizontalAlign = HorizontalAlign.Right;
											TBL_CONTENT.Rows[i + k + 3].Cells[14].CssClass= "ItemPrint_d";			
						*/

						//jumlah on booking
						//BusinessUnit
						tmp_LMT = (double.Parse(sLmt_Of_PB_BOOK.ToString()) + double.Parse(sLmt_Of_RN_BOOK.ToString()) + double.Parse(sLmt_Of_LmtChg_BOOK.ToString()))/1000000;
						TBL_CONTENT.Rows[i + k + 3].Cells.Add(new TableCell());
						TBL_CONTENT.Rows[i + k + 3].Cells[11].Font.Bold=true;
						TBL_CONTENT.Rows[i + k + 3].Cells[11].Text = "&nbsp;" + tmp_LMT.ToString() + "&nbsp;";
						TBL_CONTENT.Rows[i + k + 3].Cells[11].HorizontalAlign = HorizontalAlign.Right;
						TBL_CONTENT.Rows[i + k + 3].Cells[11].CssClass= "ItemPrint_d";
						/*
											TBL_CONTENT.Rows[i + k + 3].Cells.Add(new TableCell());
											TBL_CONTENT.Rows[i + k + 3].Cells[17].Font.Bold=true;
											TBL_CONTENT.Rows[i + k + 3].Cells[17].Text = "&nbsp;" +  tools.ConvertCurr(sLmt_Of_RN_BOOK.ToString()) + "&nbsp;";
											TBL_CONTENT.Rows[i + k + 3].Cells[17].HorizontalAlign = HorizontalAlign.Right;
											TBL_CONTENT.Rows[i + k + 3].Cells[17].CssClass= "ItemPrint_d";

											TBL_CONTENT.Rows[i + k + 3].Cells.Add(new TableCell());
											TBL_CONTENT.Rows[i + k + 3].Cells[19].Font.Bold=true;
											TBL_CONTENT.Rows[i + k + 3].Cells[19].Text = "&nbsp;" +  tools.ConvertCurr(sLmt_Of_LmtChg_BOOK.ToString()) + "&nbsp;";
											TBL_CONTENT.Rows[i + k + 3].Cells[19].HorizontalAlign = HorizontalAlign.Right;
											TBL_CONTENT.Rows[i + k + 3].Cells[19].CssClass= "ItemPrint_d";
						*/
						tmp_NBR = double.Parse(sNbr_Of_PB_BOOK.ToString()) + double.Parse(sNbr_Of_RN_BOOK.ToString()) + double.Parse(sNbr_Of_LmtChg_BOOK.ToString());
						TBL_CONTENT.Rows[i + k + 3].Cells.Add(new TableCell());
						TBL_CONTENT.Rows[i + k + 3].Cells[12].Font.Bold=true;
						TBL_CONTENT.Rows[i + k + 3].Cells[12].Text = "&nbsp;" +  tmp_NBR.ToString() + "&nbsp;";
						TBL_CONTENT.Rows[i + k + 3].Cells[12].HorizontalAlign = HorizontalAlign.Right;
						TBL_CONTENT.Rows[i + k + 3].Cells[12].CssClass= "ItemPrint_d";
						/*
											//Renewal
											TBL_CONTENT.Rows[i + k + 3].Cells.Add(new TableCell());
											TBL_CONTENT.Rows[i + k + 3].Cells[18].Font.Bold=true;
											TBL_CONTENT.Rows[i + k + 3].Cells[18].Text = "&nbsp;" +  sNbr_Of_RN_BOOK.ToString() + "&nbsp;";
											TBL_CONTENT.Rows[i + k + 3].Cells[18].HorizontalAlign = HorizontalAlign.Right;
											TBL_CONTENT.Rows[i + k + 3].Cells[18].CssClass= "ItemPrint_d";
			
											//Limit Change
											TBL_CONTENT.Rows[i + k + 3].Cells.Add(new TableCell());
											TBL_CONTENT.Rows[i + k + 3].Cells[20].Font.Bold=true;
											TBL_CONTENT.Rows[i + k + 3].Cells[20].Text = "&nbsp;" +  sNbr_Of_LmtChg_BOOK.ToString() + "&nbsp;";
											TBL_CONTENT.Rows[i + k + 3].Cells[20].HorizontalAlign = HorizontalAlign.Right;
											TBL_CONTENT.Rows[i + k + 3].Cells[20].CssClass= "ItemPrint_d";
						*/					
						k += 1;
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
					TBL_CONTENT.Rows[i + k + 3].Cells.Add(new TableCell());
					TBL_CONTENT.Rows[i + k + 3].Cells[0].Text = "&nbsp;";
					TBL_CONTENT.Rows[i + k + 3].Cells[0].HorizontalAlign = HorizontalAlign.Center;
					TBL_CONTENT.Rows[i + k + 3].Cells[0].CssClass= "ItemPrint_d";

					//TBL_CONTENT.Rows.Add(new TableRow());
					TBL_CONTENT.Rows[i + k + 3].Cells.Add(new TableCell());
					TBL_CONTENT.Rows[i + k + 3].Cells[1].Text = "&nbsp;" + Conn.GetFieldValue(i,"areaname");
					TBL_CONTENT.Rows[i + k + 3].Cells[1].HorizontalAlign = HorizontalAlign.Center;
					TBL_CONTENT.Rows[i + k + 3].Cells[1].CssClass= "ItemPrint_d";
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
				tLmt_Of_PB += double.Parse(Conn.GetFieldValue(i,"Lmt_Of_PB_BU").ToString()) + double.Parse(Conn.GetFieldValue(i,"Lmt_Of_PB_CRM").ToString()) + double.Parse(Conn.GetFieldValue(i,"Lmt_Of_PB_CO").ToString());
				tLmt_Of_RN += double.Parse(Conn.GetFieldValue(i,"Lmt_Of_RN_BU").ToString()) + double.Parse(Conn.GetFieldValue(i,"Lmt_Of_RN_CRM").ToString()) + double.Parse(Conn.GetFieldValue(i,"Lmt_Of_RN_CO").ToString()); 
				tLmt_Of_LmtChg += double.Parse(Conn.GetFieldValue(i,"Lmt_Of_LmtChg_BU").ToString()) + double.Parse(Conn.GetFieldValue(i,"Lmt_Of_LmtChg_CRM").ToString()) + double.Parse(Conn.GetFieldValue(i,"Lmt_Of_LmtChg_CO").ToString());

				tNbr_Of_PB += double.Parse(Conn.GetFieldValue(i,"Nbr_Of_PB_BU").ToString()) + double.Parse(Conn.GetFieldValue(i,"Nbr_Of_PB_CRM").ToString()) + double.Parse(Conn.GetFieldValue(i,"Nbr_Of_PB_CO").ToString());
				tNbr_Of_RN += double.Parse(Conn.GetFieldValue(i,"Nbr_Of_RN_BU").ToString()) + double.Parse(Conn.GetFieldValue(i,"Nbr_Of_RN_CRM").ToString()) + double.Parse(Conn.GetFieldValue(i,"Nbr_Of_RN_CO").ToString());
				tNbr_Of_LmtChg += double.Parse(Conn.GetFieldValue(i,"Nbr_Of_LmtChg_BU").ToString()) + double.Parse(Conn.GetFieldValue(i,"Nbr_Of_LmtChg_CRM").ToString()) + double.Parse(Conn.GetFieldValue(i,"Nbr_Of_LmtChg_CO").ToString());
		
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
				TBL_CONTENT.Rows[i + k + 3].Cells.Add(new TableCell());
				TBL_CONTENT.Rows[i + k + 3].Cells[0].Text = "&nbsp;" + ((int)(i + 1)).ToString();
				TBL_CONTENT.Rows[i + k + 3].Cells[0].HorizontalAlign = HorizontalAlign.Center;
				TBL_CONTENT.Rows[i + k + 3].Cells[0].CssClass= "ItemPrint_d";

				TBL_CONTENT.Rows[i + k + 3].Cells.Add(new TableCell());
				TBL_CONTENT.Rows[i + k + 3].Cells[1].Text = "&nbsp;";
				TBL_CONTENT.Rows[i + k + 3].Cells[1].HorizontalAlign = HorizontalAlign.Center;
				TBL_CONTENT.Rows[i + k + 3].Cells[1].CssClass= "ItemPrint_d";

				TBL_CONTENT.Rows[i + k + 3].Cells.Add(new TableCell());
				TBL_CONTENT.Rows[i + k + 3].Cells[2].Text = "&nbsp;" + Conn.GetFieldValue(i,"GG");
				TBL_CONTENT.Rows[i + k + 3].Cells[2].HorizontalAlign = HorizontalAlign.Left;
				TBL_CONTENT.Rows[i + k + 3].Cells[2].CssClass= "ItemPrint_d";

				//BusinessUnit
				double tmp_lmt_BU = (double.Parse(Conn.GetFieldValue(i,"Lmt_Of_PB_BU").ToString()) + double.Parse(Conn.GetFieldValue(i,"Lmt_Of_RN_BU").ToString()) + double.Parse(Conn.GetFieldValue(i,"Lmt_Of_LmtChg_BU").ToString()))/1000000;
				TBL_CONTENT.Rows[i + k + 3].Cells.Add(new TableCell());
				TBL_CONTENT.Rows[i + k + 3].Cells[3].Text = "&nbsp;" + tmp_lmt_BU.ToString() + "&nbsp;";
				TBL_CONTENT.Rows[i + k + 3].Cells[3].HorizontalAlign = HorizontalAlign.Right;
				TBL_CONTENT.Rows[i + k + 3].Cells[3].CssClass= "ItemPrint_d";

			    double Nbr_BU = double.Parse(Conn.GetFieldValue(i,"Nbr_Of_PB_BU").ToString()) + double.Parse(Conn.GetFieldValue(i,"Nbr_Of_RN_BU").ToString()) + double.Parse(Conn.GetFieldValue(i,"Nbr_Of_LmtChg_BU").ToString());
				TBL_CONTENT.Rows[i + k + 3].Cells.Add(new TableCell());
				TBL_CONTENT.Rows[i + k + 3].Cells[4].Text = "&nbsp;" + Nbr_BU.ToString() + "&nbsp;";
				TBL_CONTENT.Rows[i + k + 3].Cells[4].HorizontalAlign = HorizontalAlign.Right;
				TBL_CONTENT.Rows[i + k + 3].Cells[4].CssClass= "ItemPrint_d";

				//CRM
				double Lmt_CRM = (double.Parse(Conn.GetFieldValue(i,"Lmt_Of_PB_CRM").ToString())+ double.Parse(Conn.GetFieldValue(i,"Lmt_Of_RN_CRM").ToString()) + double.Parse(Conn.GetFieldValue(i,"Lmt_Of_LmtChg_CRM").ToString()))/1000000;
				TBL_CONTENT.Rows[i + k + 3].Cells.Add(new TableCell());
				TBL_CONTENT.Rows[i + k + 3].Cells[5].Text = "&nbsp;" + Lmt_CRM.ToString() + "&nbsp;";
				TBL_CONTENT.Rows[i + k + 3].Cells[5].HorizontalAlign = HorizontalAlign.Right;
				TBL_CONTENT.Rows[i + k + 3].Cells[5].CssClass= "ItemPrint_d";

                double Nbr_CRM = double.Parse(Conn.GetFieldValue(i,"Nbr_Of_PB_CRM").ToString()) + double.Parse(Conn.GetFieldValue(i,"Nbr_Of_RN_CRM").ToString()) + double.Parse(Conn.GetFieldValue(i,"Nbr_Of_LmtChg_CRM").ToString()); 
				TBL_CONTENT.Rows[i + k + 3].Cells.Add(new TableCell());
				TBL_CONTENT.Rows[i + k + 3].Cells[6].Text = "&nbsp;" + Nbr_CRM.ToString() + "&nbsp;";
				TBL_CONTENT.Rows[i + k + 3].Cells[6].HorizontalAlign = HorizontalAlign.Right;
				TBL_CONTENT.Rows[i + k + 3].Cells[6].CssClass= "ItemPrint_d";

				//CO
				double LMT_CO = (double.Parse(Conn.GetFieldValue(i,"Lmt_Of_PB_CO").ToString()) + double.Parse(Conn.GetFieldValue(i,"Lmt_Of_RN_CO").ToString()) + double.Parse(Conn.GetFieldValue(i,"Lmt_Of_LmtChg_CO").ToString()))/1000000;
				TBL_CONTENT.Rows[i + k + 3].Cells.Add(new TableCell());
				TBL_CONTENT.Rows[i + k + 3].Cells[7].Text = "&nbsp;" + LMT_CO.ToString() + "&nbsp;";
				TBL_CONTENT.Rows[i + k + 3].Cells[7].HorizontalAlign = HorizontalAlign.Right;
				TBL_CONTENT.Rows[i + k + 3].Cells[7].CssClass= "ItemPrint_d";				

                double NBR_CO = double.Parse(Conn.GetFieldValue(i,"Nbr_Of_PB_CO").ToString()) + double.Parse(Conn.GetFieldValue(i,"Nbr_Of_RN_CO").ToString()) + double.Parse(Conn.GetFieldValue(i,"Nbr_Of_LmtChg_CO").ToString());
				TBL_CONTENT.Rows[i + k + 3].Cells.Add(new TableCell());
				TBL_CONTENT.Rows[i + k + 3].Cells[8].Text = "&nbsp;" + NBR_CO.ToString() + "&nbsp;";
				TBL_CONTENT.Rows[i + k + 3].Cells[8].HorizontalAlign = HorizontalAlign.Right;
				TBL_CONTENT.Rows[i + k + 3].Cells[8].CssClass= "ItemPrint_d";
				
				//jumlah dalam proses
				double Tmp_Value =  (double.Parse(Conn.GetFieldValue(i,"Lmt_Of_PB_BU").ToString()) + double.Parse(Conn.GetFieldValue(i,"Lmt_Of_PB_CRM").ToString()) + double.Parse(Conn.GetFieldValue(i,"Lmt_Of_PB_CO").ToString()) + double.Parse(Conn.GetFieldValue(i,"Lmt_Of_RN_BU").ToString()) + double.Parse(Conn.GetFieldValue(i,"Lmt_Of_RN_CRM").ToString()) + double.Parse(Conn.GetFieldValue(i,"Lmt_Of_RN_CO").ToString()) + double.Parse(Conn.GetFieldValue(i,"Lmt_Of_LmtChg_BU").ToString()) + double.Parse(Conn.GetFieldValue(i,"Lmt_Of_LmtChg_CRM").ToString()) + double.Parse(Conn.GetFieldValue(i,"Lmt_Of_LmtChg_CO").ToString()))/1000000;
				TBL_CONTENT.Rows[i + k + 3].Cells.Add(new TableCell());
				TBL_CONTENT.Rows[i + k + 3].Cells[9].Text = "&nbsp;" +  Tmp_Value.ToString() + "&nbsp;";
				TBL_CONTENT.Rows[i + k + 3].Cells[9].HorizontalAlign = HorizontalAlign.Right;
				TBL_CONTENT.Rows[i + k + 3].Cells[9].CssClass= "ItemPrint_d";

				Tmp_Value = double.Parse(Conn.GetFieldValue(i,"Nbr_Of_PB_BU").ToString()) + double.Parse(Conn.GetFieldValue(i,"Nbr_Of_PB_CRM").ToString()) + double.Parse(Conn.GetFieldValue(i,"Nbr_Of_PB_CO").ToString()) + double.Parse(Conn.GetFieldValue(i,"Nbr_Of_RN_BU").ToString()) + double.Parse(Conn.GetFieldValue(i,"Nbr_Of_RN_CRM").ToString()) + double.Parse(Conn.GetFieldValue(i,"Nbr_Of_RN_CO").ToString()) + double.Parse(Conn.GetFieldValue(i,"Nbr_Of_LmtChg_BU").ToString()) + double.Parse(Conn.GetFieldValue(i,"Nbr_Of_LmtChg_CRM").ToString()) + double.Parse(Conn.GetFieldValue(i,"Nbr_Of_LmtChg_CO").ToString());
				TBL_CONTENT.Rows[i + k + 3].Cells.Add(new TableCell());
				TBL_CONTENT.Rows[i + k + 3].Cells[10].Text = "&nbsp;" +  tools.ConvertCurr(Tmp_Value.ToString()) + "&nbsp;";
				TBL_CONTENT.Rows[i + k + 3].Cells[10].HorizontalAlign = HorizontalAlign.Right;
				TBL_CONTENT.Rows[i + k + 3].Cells[10].CssClass= "ItemPrint_d";

				//jumlah on booking
				//BusinessUnit
				Tmp_Value = (double.Parse(Conn.GetFieldValue(i,"Lmt_Of_PB_BU_BOOK")) + double.Parse(Conn.GetFieldValue(i,"Lmt_Of_PB_CRM_BOOK")) + double.Parse(Conn.GetFieldValue(i,"Lmt_Of_PB_CO_BOOK")) + double.Parse(Conn.GetFieldValue(i,"Lmt_Of_RN_BU_BOOK").ToString()) + double.Parse(Conn.GetFieldValue(i,"Lmt_Of_RN_CRM_BOOK").ToString()) + double.Parse(Conn.GetFieldValue(i,"Lmt_Of_RN_CO_BOOK").ToString()) + double.Parse(Conn.GetFieldValue(i,"Lmt_Of_LmtChg_BU_BOOK").ToString()) + double.Parse(Conn.GetFieldValue(i,"Lmt_Of_LmtChg_CRM_BOOK").ToString()) + double.Parse(Conn.GetFieldValue(i,"Lmt_Of_LmtChg_CO_BOOK").ToString()))/1000000;
				TBL_CONTENT.Rows[i + k + 3].Cells.Add(new TableCell());
				TBL_CONTENT.Rows[i + k + 3].Cells[11].Text = "&nbsp;" + Tmp_Value.ToString() + "&nbsp;";
				TBL_CONTENT.Rows[i + k + 3].Cells[11].HorizontalAlign = HorizontalAlign.Right;
				TBL_CONTENT.Rows[i + k + 3].Cells[11].CssClass= "ItemPrint_d";

				Tmp_Value = double.Parse(Conn.GetFieldValue(i,"Nbr_Of_PB_BU_BOOK").ToString()) + double.Parse(Conn.GetFieldValue(i,"Nbr_Of_PB_CRM_BOOK").ToString()) + double.Parse(Conn.GetFieldValue(i,"Nbr_Of_PB_CO_BOOK").ToString()) + double.Parse(Conn.GetFieldValue(i,"Nbr_Of_RN_BU_BOOK").ToString()) + double.Parse(Conn.GetFieldValue(i,"Nbr_Of_RN_CRM_BOOK").ToString()) + double.Parse(Conn.GetFieldValue(i,"Nbr_Of_RN_CO_BOOK").ToString()) + double.Parse(Conn.GetFieldValue(i,"Nbr_Of_LmtChg_BU_BOOK").ToString()) + double.Parse(Conn.GetFieldValue(i,"Nbr_Of_LmtChg_CRM_BOOK").ToString()) + double.Parse(Conn.GetFieldValue(i,"Nbr_Of_LmtChg_CO_BOOK").ToString());
				TBL_CONTENT.Rows[i + k + 3].Cells.Add(new TableCell());
				TBL_CONTENT.Rows[i + k + 3].Cells[12].Text = "&nbsp;" +  Tmp_Value.ToString() + "&nbsp;";
				TBL_CONTENT.Rows[i + k + 3].Cells[12].HorizontalAlign = HorizontalAlign.Right;
				TBL_CONTENT.Rows[i + k + 3].Cells[12].CssClass= "ItemPrint_d";
			}
			//Sub Total

			TBL_CONTENT.Rows.Add(new TableRow());
			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 3].Cells.Add(new TableCell());
			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 3].Cells[0].Text = "&nbsp;";
			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 3].Cells[0].HorizontalAlign = HorizontalAlign.Center;
			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 3].Cells[0].CssClass= "ItemPrint_d";

			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 3].Cells.Add(new TableCell());
			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 3].Cells[1].Font.Bold=true;
			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 3].Cells[1].Text = "&nbsp;SUB TOTAL&nbsp;";
			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 3].Cells[1].HorizontalAlign = HorizontalAlign.Center;
			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 3].Cells[1].CssClass= "ItemPrint_d";

			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 3].Cells.Add(new TableCell());
			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 3].Cells[2].Text = "&nbsp;" ;
			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 3].Cells[2].HorizontalAlign = HorizontalAlign.Left;
			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 3].Cells[2].CssClass= "ItemPrint_d";

			//BusinessUnit
			tmp_LMT = (double.Parse(sLmt_Of_PB_BU.ToString()) + double.Parse(sLmt_Of_RN_BU.ToString()) + double.Parse(sLmt_Of_LmtChg_BU.ToString()))/1000000;
			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 3].Cells.Add(new TableCell());
			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 3].Cells[3].Font.Bold=true;
			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 3].Cells[3].Text = "&nbsp;" + tmp_LMT .ToString() + "&nbsp;";
			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 3].Cells[3].HorizontalAlign = HorizontalAlign.Right;
			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 3].Cells[3].CssClass= "ItemPrint_d";

            tmp_NBR = double.Parse(sNbr_Of_PB_BU.ToString()) + double.Parse(sNbr_Of_RN_BU.ToString()) + double.Parse(sNbr_Of_LmtChg_BU.ToString()); 
			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 3].Cells.Add(new TableCell());
			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 3].Cells[4].Font.Bold=true;
			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 3].Cells[4].Text = "&nbsp;" + tmp_NBR.ToString() + "&nbsp;";
			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 3].Cells[4].HorizontalAlign = HorizontalAlign.Right;
			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 3].Cells[4].CssClass= "ItemPrint_d";

			//CRM
			tmp_LMT = (double.Parse(sLmt_Of_PB_CRM.ToString()) + double.Parse(sLmt_Of_RN_CRM.ToString()) + double.Parse(sLmt_Of_LmtChg_CRM.ToString()))/1000000;
			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 3].Cells.Add(new TableCell());
			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 3].Cells[5].Font.Bold=true;
			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 3].Cells[5].Text = "&nbsp;" + tmp_LMT.ToString() + "&nbsp;";
			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 3].Cells[5].HorizontalAlign = HorizontalAlign.Right;
			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 3].Cells[5].CssClass= "ItemPrint_d";

			tmp_NBR = double.Parse(sNbr_Of_PB_CRM.ToString()) + double.Parse(sNbr_Of_RN_CRM.ToString()) + double.Parse(sNbr_Of_LmtChg_CRM.ToString());
			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 3].Cells.Add(new TableCell());
			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 3].Cells[6].Font.Bold=true;
			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 3].Cells[6].Text = "&nbsp;" + tmp_NBR.ToString() + "&nbsp;";
			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 3].Cells[6].HorizontalAlign = HorizontalAlign.Right;
			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 3].Cells[6].CssClass= "ItemPrint_d";

			//CO
			tmp_LMT = (double.Parse(sLmt_Of_PB_CO.ToString()) + double.Parse(sLmt_Of_RN_CO.ToString()) + double.Parse(sLmt_Of_LmtChg_CO.ToString()))/1000000;
			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 3].Cells.Add(new TableCell());
			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 3].Cells[7].Font.Bold=true;
			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 3].Cells[7].Text = "&nbsp;" + tmp_LMT.ToString() + "&nbsp;";
			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 3].Cells[7].HorizontalAlign = HorizontalAlign.Right;
			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 3].Cells[7].CssClass= "ItemPrint_d";

			tmp_NBR = double.Parse(sNbr_Of_PB_CO.ToString()) + double.Parse(sNbr_Of_RN_CO.ToString()) + double.Parse(sNbr_Of_LmtChg_CO.ToString()); 
			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 3].Cells.Add(new TableCell());
			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 3].Cells[8].Font.Bold=true;
			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 3].Cells[8].Text = "&nbsp;" + tmp_NBR.ToString() + "&nbsp;";
			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 3].Cells[8].HorizontalAlign = HorizontalAlign.Right;
			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 3].Cells[8].CssClass= "ItemPrint_d";

			//jumlah dalam proses
			tmp_LMT = (double.Parse(sLmt_Of_PB.ToString()) + double.Parse(sLmt_Of_RN.ToString()) + double.Parse(sLmt_Of_LmtChg.ToString()))/1000000;
			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 3].Cells.Add(new TableCell());
			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 3].Cells[9].Font.Bold=true;
			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 3].Cells[9].Text = "&nbsp;" +  tmp_LMT.ToString() + "&nbsp;";
			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 3].Cells[9].HorizontalAlign = HorizontalAlign.Right;
			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 3].Cells[9].CssClass= "ItemPrint_d";

			tmp_NBR = double.Parse(sNbr_Of_PB.ToString()) + double.Parse(sNbr_Of_RN.ToString()) + double.Parse(sNbr_Of_LmtChg.ToString());
			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 3].Cells.Add(new TableCell());
			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 3].Cells[10].Font.Bold=true;
			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 3].Cells[10].Text = "&nbsp;" +  sNbr_Of_PB.ToString() + "&nbsp;";
			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 3].Cells[10].HorizontalAlign = HorizontalAlign.Right;
			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 3].Cells[10].CssClass= "ItemPrint_d";

			//jumlah on booking
			tmp_LMT = (double.Parse(sLmt_Of_PB_BOOK.ToString()) + double.Parse(sLmt_Of_RN_BOOK.ToString()) + double.Parse(sLmt_Of_LmtChg_BOOK.ToString()))/1000000;
			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 3].Cells.Add(new TableCell());
			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 3].Cells[11].Font.Bold=true;
			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 3].Cells[11].Text = "&nbsp;" + tmp_LMT.ToString() + "&nbsp;";
			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 3].Cells[11].HorizontalAlign = HorizontalAlign.Right;
			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 3].Cells[11].CssClass= "ItemPrint_d";
			
			tmp_NBR = double.Parse(sNbr_Of_PB_BOOK.ToString()) + double.Parse(sNbr_Of_RN_BOOK.ToString()) + double.Parse(sNbr_Of_LmtChg_BOOK.ToString());
			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 3].Cells.Add(new TableCell());
			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 3].Cells[12].Font.Bold=true;
			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 3].Cells[12].Text = "&nbsp;" +  tmp_NBR.ToString() + "&nbsp;";
			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 3].Cells[12].HorizontalAlign = HorizontalAlign.Right;
			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 3].Cells[12].CssClass= "ItemPrint_d";

			//Total
			TBL_CONTENT.Rows.Add(new TableRow());
			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 4].Cells.Add(new TableCell());
			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 4].Cells[0].Text = "&nbsp;";
			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 4].Cells[0].HorizontalAlign = HorizontalAlign.Center;
			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 4].Cells[0].CssClass= "ItemPrint_d";

			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 4].Cells.Add(new TableCell());
			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 4].Cells[1].Font.Bold=true;
			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 4].Cells[1].Text = "&nbsp;TOTAL&nbsp;";
			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 4].Cells[1].HorizontalAlign = HorizontalAlign.Center;
			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 4].Cells[1].CssClass= "ItemPrint_d";

			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 4].Cells.Add(new TableCell());
			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 4].Cells[2].Text = "&nbsp;" ;
			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 4].Cells[2].HorizontalAlign = HorizontalAlign.Left;
			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 4].Cells[2].CssClass= "ItemPrint_d";

			//BusinessUnit
			tmp_LMT = (double.Parse(tLmt_Of_PB_BU.ToString()) + double.Parse(tLmt_Of_RN_BU.ToString()) + double.Parse(tLmt_Of_LmtChg_BU.ToString()))/1000000;
			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 4].Cells.Add(new TableCell());
			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 4].Cells[3].Font.Bold=true;
			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 4].Cells[3].Text = "&nbsp;" + tmp_LMT.ToString() + "&nbsp;";
			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 4].Cells[3].HorizontalAlign = HorizontalAlign.Right;
			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 4].Cells[3].CssClass= "ItemPrint_d";

			tmp_NBR = double.Parse(tNbr_Of_PB_BU.ToString()) + double.Parse(tNbr_Of_RN_BU.ToString()) + double.Parse(tNbr_Of_LmtChg_BU.ToString());
			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 4].Cells.Add(new TableCell());
			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 4].Cells[4].Font.Bold=true;
			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 4].Cells[4].Text = "&nbsp;" + tmp_NBR.ToString() + "&nbsp;";
			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 4].Cells[4].HorizontalAlign = HorizontalAlign.Right;
			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 4].Cells[4].CssClass= "ItemPrint_d";
			
			//CRM
			tmp_LMT = (double.Parse(tLmt_Of_PB_CRM.ToString()) + double.Parse(tLmt_Of_RN_CRM.ToString()) + double.Parse(tLmt_Of_LmtChg_CRM.ToString()))/1000000;
			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 4].Cells.Add(new TableCell());
			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 4].Cells[5].Font.Bold=true;
			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 4].Cells[5].Text = "&nbsp;" + tmp_LMT.ToString() + "&nbsp;";
			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 4].Cells[5].HorizontalAlign = HorizontalAlign.Right;
			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 4].Cells[5].CssClass= "ItemPrint_d";

            tmp_NBR = double.Parse(tNbr_Of_PB_CRM.ToString()) + double.Parse(tNbr_Of_RN_CRM.ToString()) + double.Parse(tNbr_Of_LmtChg_CRM.ToString());
			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 4].Cells.Add(new TableCell());
			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 4].Cells[6].Font.Bold=true;
			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 4].Cells[6].Text = "&nbsp;" + tmp_NBR.ToString() + "&nbsp;";
			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 4].Cells[6].HorizontalAlign = HorizontalAlign.Right;
			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 4].Cells[6].CssClass= "ItemPrint_d";

			//CO
			tmp_LMT = (double.Parse(tLmt_Of_PB_CO.ToString()) + double.Parse(tLmt_Of_RN_CO.ToString()) + double.Parse(tLmt_Of_LmtChg_CO.ToString()))/1000000;
			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 4].Cells.Add(new TableCell());
			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 4].Cells[7].Font.Bold=true;
			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 4].Cells[7].Text = "&nbsp;" + tLmt_Of_PB_CO.ToString() + "&nbsp;";
			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 4].Cells[7].HorizontalAlign = HorizontalAlign.Right;
			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 4].Cells[7].CssClass= "ItemPrint_d";

			tmp_NBR = double.Parse(tNbr_Of_PB_CO.ToString()) + double.Parse(tNbr_Of_RN_CO.ToString()) + double.Parse(tNbr_Of_LmtChg_CO.ToString());
			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 4].Cells.Add(new TableCell());
			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 4].Cells[8].Font.Bold=true;
			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 4].Cells[8].Text = "&nbsp;" + tmp_NBR.ToString() + "&nbsp;";
			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 4].Cells[8].HorizontalAlign = HorizontalAlign.Right;
			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 4].Cells[8].CssClass= "ItemPrint_d";

			//jumlah dalam proses
			//BusinessUnit
			tmp_LMT = (double.Parse(tLmt_Of_PB.ToString()) + double.Parse(tLmt_Of_RN.ToString()) + double.Parse(tLmt_Of_LmtChg.ToString()))/1000000;
			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 4].Cells.Add(new TableCell());
			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 4].Cells[9].Font.Bold=true;
			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 4].Cells[9].Text = "&nbsp;" +  tLmt_Of_PB.ToString() + "&nbsp;";
			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 4].Cells[9].HorizontalAlign = HorizontalAlign.Right;
			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 4].Cells[9].CssClass= "ItemPrint_d";

			tmp_NBR = double.Parse(tNbr_Of_PB.ToString()) + double.Parse(tNbr_Of_RN.ToString()) + double.Parse(tNbr_Of_LmtChg.ToString());
			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 4].Cells.Add(new TableCell());
			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 4].Cells[10].Font.Bold=true;
			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 4].Cells[10].Text = "&nbsp;" +  tNbr_Of_PB.ToString() + "&nbsp;";
			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 4].Cells[10].HorizontalAlign = HorizontalAlign.Right;
			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 4].Cells[10].CssClass= "ItemPrint_d";

			//jumlah on booking
			//BusinessUnit
			tmp_LMT = (double.Parse(tLmt_Of_PB_BOOK.ToString()) + double.Parse(tLmt_Of_RN_BOOK.ToString()) + double.Parse(tLmt_Of_LmtChg_BOOK.ToString()))/1000000;
			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 4].Cells.Add(new TableCell());
			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 4].Cells[11].Font.Bold=true;
			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 4].Cells[11].Text = "&nbsp;" + tLmt_Of_PB_BOOK.ToString() + "&nbsp;";
			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 4].Cells[11].HorizontalAlign = HorizontalAlign.Right;
			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 4].Cells[11].CssClass= "ItemPrint_d";
		
			tmp_NBR = double.Parse(tNbr_Of_PB_BOOK.ToString()) + double.Parse(tNbr_Of_RN_BOOK.ToString()) + double.Parse(tNbr_Of_LmtChg_BOOK.ToString());
			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 4].Cells.Add(new TableCell());
			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 4].Cells[12].Font.Bold=true;
			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 4].Cells[12].Text = "&nbsp;" +  tmp_NBR.ToString() + "&nbsp;";
			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 4].Cells[12].HorizontalAlign = HorizontalAlign.Right;
			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 4].Cells[12].CssClass= "ItemPrint_d";
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
