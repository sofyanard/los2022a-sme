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
	/// Summary description for RptPipeLinePerProductPrint.
	/// </summary>
	public partial class RptPipeLinePerProductPrint : System.Web.UI.Page
	{
		protected Connection Conn = new Connection();
		protected Tools tools = new Tools();
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			Conn = (Connection) Session["Connection"];
			string sql_kondisi = Request.QueryString["sql_kondisi"];
			string JProduct = Request.QueryString["JProduct"];
			string businessunit = Request.QueryString["businessunit"];
			Load_Data(sql_kondisi, JProduct, businessunit);
		}


		private void Load_Data(string sql_kondisi, string JProduct, string businessunit)
		{
			int k = 0;
			string pre_proddesc="";
			double Lmt_Of_BU=0, Nbr_Of_BU=0, Lmt_Of_CRM=0, Nbr_Of_CRM=0, Lmt_Of_CO=0, Nbr_Of_CO=0, Lmt_Of_On_Proc=0, Nbr_of_BU=0, Lmt_Of_BU_BOOK=0, Nbr_Of_BU_BOOK=0;
			double tLmt_Of_BU=0, tNbr_Of_BU=0, tLmt_Of_CRM=0, tNbr_Of_CRM=0, tLmt_Of_CO=0, tNbr_Of_CO=0, tLmt_Of_On_Proc=0, tNbr_of_BU=0, tLmt_Of_BU_BOOK=0, tNbr_Of_BU_BOOK=0;

			Conn.QueryString = "select bussunitdesc from rfbusinessunit where bussunitid='" + businessunit + "'";
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

			Conn.QueryString = "EXEC Rpt_PipeLinePerProduct '" + sql_kondisi + "' ";
			Conn.ExecuteQuery();
			for (int i = 0; i < Conn.GetRowCount(); i++)
			{
				if (pre_proddesc.ToString()!=Conn.GetFieldValue(i,"JENISDESC"))
				{
					if (!pre_proddesc.Equals(""))
					{
						//---Sub Total
						TBL_CONTENT.Rows.Add(new TableRow());
						TBL_CONTENT.Rows[i + k + 3].Cells.Add(new TableCell());
						TBL_CONTENT.Rows[i + k + 3].Cells[0].Text = "&nbsp;";
						TBL_CONTENT.Rows[i + k + 3].Cells[0].HorizontalAlign = HorizontalAlign.Center;
						TBL_CONTENT.Rows[i + k + 3].Cells[0].CssClass= "ItemPrint_d";

						TBL_CONTENT.Rows[i + k + 3].Cells.Add(new TableCell());
						TBL_CONTENT.Rows[i + k + 3].Cells[1].Font.Bold=true;
						TBL_CONTENT.Rows[i + k + 3].Cells[1].Text = "&nbsp;SUB TOTAL&nbsp;";
						TBL_CONTENT.Rows[i + k + 3].Cells[1].HorizontalAlign = HorizontalAlign.Left;
						TBL_CONTENT.Rows[i + k + 3].Cells[1].CssClass= "ItemPrint_d";

						TBL_CONTENT.Rows[i + k + 3].Cells.Add(new TableCell());
                        TBL_CONTENT.Rows[i + k + 3].Cells[2].Font.Bold=true; 
						TBL_CONTENT.Rows[i + k + 3].Cells[2].Text = "&nbsp;";
						TBL_CONTENT.Rows[i + k + 3].Cells[2].HorizontalAlign = HorizontalAlign.Left;
						TBL_CONTENT.Rows[i + k + 3].Cells[2].CssClass= "ItemPrint_d";

                        TBL_CONTENT.Rows[i + k + 3].Cells.Add(new TableCell());
						TBL_CONTENT.Rows[i + k + 3].Cells[3].Font.Bold=true; 
						TBL_CONTENT.Rows[i + k + 3].Cells[3].Text = "&nbsp;" + tools.ConvertCurr(tools.ConvertNum(Lmt_Of_BU.ToString()).ToString()) + "&nbsp;";
						TBL_CONTENT.Rows[i + k + 3].Cells[3].HorizontalAlign = HorizontalAlign.Right;
						TBL_CONTENT.Rows[i + k + 3].Cells[3].CssClass= "ItemPrint_d";
				
						TBL_CONTENT.Rows[i + k + 3].Cells.Add(new TableCell());
                        TBL_CONTENT.Rows[i + k + 3].Cells[4].Font.Bold=true; 
						TBL_CONTENT.Rows[i + k + 3].Cells[4].Text = "&nbsp;" + Nbr_Of_BU.ToString() + "&nbsp;";
						TBL_CONTENT.Rows[i + k + 3].Cells[4].HorizontalAlign = HorizontalAlign.Right;
						TBL_CONTENT.Rows[i + k + 3].Cells[4].CssClass= "ItemPrint_d";

						TBL_CONTENT.Rows[i + k + 3].Cells.Add(new TableCell());
                        TBL_CONTENT.Rows[i + k + 3].Cells[5].Font.Bold=true; 
						TBL_CONTENT.Rows[i + k + 3].Cells[5].Text = "&nbsp;" +  tools.ConvertCurr(tools.ConvertNum(Lmt_Of_CRM.ToString()).ToString()) + "&nbsp;";
						TBL_CONTENT.Rows[i + k + 3].Cells[5].HorizontalAlign = HorizontalAlign.Right;
						TBL_CONTENT.Rows[i + k + 3].Cells[5].CssClass= "ItemPrint_d";

						TBL_CONTENT.Rows[i + k + 3].Cells.Add(new TableCell());
						TBL_CONTENT.Rows[i + k + 3].Cells[6].Font.Bold=true; 
						TBL_CONTENT.Rows[i + k + 3].Cells[6].Text = "&nbsp;" +  tools.ConvertNum(Nbr_Of_CRM.ToString()) + "&nbsp;";
						TBL_CONTENT.Rows[i + k + 3].Cells[6].HorizontalAlign = HorizontalAlign.Right;
						TBL_CONTENT.Rows[i + k + 3].Cells[6].CssClass= "ItemPrint_d";

						TBL_CONTENT.Rows[i + k + 3].Cells.Add(new TableCell());
						TBL_CONTENT.Rows[i + k + 3].Cells[7].Font.Bold=true; 
						TBL_CONTENT.Rows[i + k + 3].Cells[7].Text = "&nbsp;" + tools.ConvertCurr(tools.ConvertNum(Lmt_Of_CO.ToString()).ToString()) + "&nbsp;";
						TBL_CONTENT.Rows[i + k + 3].Cells[7].HorizontalAlign = HorizontalAlign.Right;
						TBL_CONTENT.Rows[i + k + 3].Cells[7].CssClass= "ItemPrint_d";

						TBL_CONTENT.Rows[i + k + 3].Cells.Add(new TableCell());
						TBL_CONTENT.Rows[i + k + 3].Cells[8].Font.Bold=true; 
						TBL_CONTENT.Rows[i + k + 3].Cells[8].Text = "&nbsp;" +  tools.ConvertNum(Nbr_Of_CO.ToString()) + "&nbsp;";
						TBL_CONTENT.Rows[i + k + 3].Cells[8].HorizontalAlign = HorizontalAlign.Right;
						TBL_CONTENT.Rows[i + k + 3].Cells[8].CssClass= "ItemPrint_d";

						TBL_CONTENT.Rows[i + k + 3].Cells.Add(new TableCell());
						TBL_CONTENT.Rows[i + k + 3].Cells[9].Font.Bold=true; 
						TBL_CONTENT.Rows[i + k + 3].Cells[9].Text = "&nbsp;" + tools.ConvertCurr(tools.ConvertNum(Lmt_Of_On_Proc.ToString()).ToString()) + "&nbsp;";
						TBL_CONTENT.Rows[i + k + 3].Cells[9].HorizontalAlign = HorizontalAlign.Right;
						TBL_CONTENT.Rows[i + k + 3].Cells[9].CssClass= "ItemPrint_d";
		
						TBL_CONTENT.Rows[i + k + 3].Cells.Add(new TableCell());
						TBL_CONTENT.Rows[i + k + 3].Cells[10].Font.Bold=true; 
						TBL_CONTENT.Rows[i + k + 3].Cells[10].Text = "&nbsp;" + tools.ConvertNum(Nbr_of_BU.ToString()) + "&nbsp;";
						TBL_CONTENT.Rows[i + k + 3].Cells[10].HorizontalAlign = HorizontalAlign.Right;
						TBL_CONTENT.Rows[i + k + 3].Cells[10].CssClass= "ItemPrint_d";

						TBL_CONTENT.Rows[i + k + 3].Cells.Add(new TableCell());
						TBL_CONTENT.Rows[i + k + 3].Cells[11].Font.Bold=true; 
						TBL_CONTENT.Rows[i + k + 3].Cells[11].Text = "&nbsp;" + tools.ConvertCurr(tools.ConvertNum(Lmt_Of_BU_BOOK.ToString()).ToString()) + "&nbsp;";
						TBL_CONTENT.Rows[i + k + 3].Cells[11].HorizontalAlign = HorizontalAlign.Right;
						TBL_CONTENT.Rows[i + k + 3].Cells[11].CssClass= "ItemPrint_d";

						TBL_CONTENT.Rows[i + k + 3].Cells.Add(new TableCell());
						TBL_CONTENT.Rows[i + k + 3].Cells[12].Font.Bold=true; 
						TBL_CONTENT.Rows[i + k + 3].Cells[12].Text = "&nbsp;" + tools.ConvertNum(Nbr_Of_BU_BOOK.ToString()) + "&nbsp;";
						TBL_CONTENT.Rows[i + k + 3].Cells[12].HorizontalAlign = HorizontalAlign.Right;
						TBL_CONTENT.Rows[i + k + 3].Cells[12].CssClass= "ItemPrint_d";
					    k += 1;
						//---------sub total
					}
					Lmt_Of_BU = 0;
					Nbr_Of_BU = 0;
					Lmt_Of_CRM = 0;
					Nbr_Of_CRM = 0;
					Lmt_Of_CO = 0;
					Nbr_Of_CO = 0;
					Lmt_Of_On_Proc = 0;
					Nbr_of_BU = 0;
					Lmt_Of_BU_BOOK = 0;
					Nbr_Of_BU_BOOK = 0;

					TBL_CONTENT.Rows.Add(new TableRow());
					TBL_CONTENT.Rows[i + k + 3].Cells.Add(new TableCell());
					TBL_CONTENT.Rows[i + k + 3].Cells[0].Text = "&nbsp;";
					TBL_CONTENT.Rows[i + k + 3].Cells[0].HorizontalAlign = HorizontalAlign.Center;
					TBL_CONTENT.Rows[i + k + 3].Cells[0].CssClass= "ItemPrint_d";

					//TBL_CONTENT.Rows.Add(new TableRow());
					TBL_CONTENT.Rows[i + k + 3].Cells.Add(new TableCell());
					TBL_CONTENT.Rows[i + k + 3].Cells[1].Text = "&nbsp;" + Conn.GetFieldValue(i,"JENISDESC");
					TBL_CONTENT.Rows[i + k + 3].Cells[1].HorizontalAlign = HorizontalAlign.Center;
					TBL_CONTENT.Rows[i + k + 3].Cells[1].CssClass= "ItemPrint_d";
					pre_proddesc = Conn.GetFieldValue(i,"JENISDESC");
					k += 1;
				}
				Lmt_Of_BU += (double.Parse(Conn.GetFieldValue(i,"Lmt_Of_PB_BU")) + double.Parse(Conn.GetFieldValue(i,"Lmt_Of_RN_BU")) + double.Parse(Conn.GetFieldValue(i,"Lmt_Of_LmtChg_BU")))/1000000;
				Nbr_Of_BU += double.Parse(Conn.GetFieldValue(i,"Nbr_Of_PB_BU")) + double.Parse(Conn.GetFieldValue(i,"Nbr_Of_RN_BU")) + double.Parse(Conn.GetFieldValue(i,"Nbr_Of_LmtChg_BU"));
				Lmt_Of_CRM += double.Parse(Conn.GetFieldValue(i,"Lmt_Of_PB_CRM")) + double.Parse(Conn.GetFieldValue(i,"Lmt_Of_RN_CRM")) + double.Parse(Conn.GetFieldValue(i,"Lmt_Of_LmtChg_CRM"))/1000000;
				Nbr_Of_CRM += double.Parse(Conn.GetFieldValue(i,"Nbr_Of_PB_CRM")) + double.Parse(Conn.GetFieldValue(i,"Nbr_Of_RN_CRM")) + double.Parse(Conn.GetFieldValue(i,"Nbr_Of_LmtChg_CRM"));
				Lmt_Of_CO += (double.Parse(Conn.GetFieldValue(i,"Lmt_Of_PB_CO")) + double.Parse(Conn.GetFieldValue(i,"Lmt_Of_RN_CO")) + double.Parse(Conn.GetFieldValue(i,"Lmt_Of_LmtChg_CO")))/1000000;
				Nbr_Of_CO += double.Parse(Conn.GetFieldValue(i,"Nbr_Of_PB_CO")) + double.Parse(Conn.GetFieldValue(i,"Nbr_Of_RN_CO")) + double.Parse(Conn.GetFieldValue(i,"Nbr_Of_LmtChg_CO"));
				Lmt_Of_On_Proc += (double.Parse(Conn.GetFieldValue(i,"Lmt_Of_PB_BU")) + double.Parse(Conn.GetFieldValue(i,"Lmt_Of_RN_BU")) + double.Parse(Conn.GetFieldValue(i,"Lmt_Of_LmtChg_BU")) + double.Parse(Conn.GetFieldValue(i,"Lmt_Of_PB_CRM")) + double.Parse(Conn.GetFieldValue(i,"Lmt_Of_RN_CRM")) + double.Parse(Conn.GetFieldValue(i,"Lmt_Of_LmtChg_CRM")) + double.Parse(Conn.GetFieldValue(i,"Lmt_Of_PB_CO")) +  double.Parse(Conn.GetFieldValue(i,"Lmt_Of_RN_CO")) + double.Parse(Conn.GetFieldValue(i,"Lmt_Of_LmtChg_CO")))/1000000;
				Nbr_of_BU += double.Parse(Conn.GetFieldValue(i,"Nbr_Of_PB_BU")) + double.Parse(Conn.GetFieldValue(i,"Nbr_Of_RN_BU")) + double.Parse(Conn.GetFieldValue(i,"Nbr_Of_LmtChg_BU")) + double.Parse(Conn.GetFieldValue(i,"Nbr_Of_PB_CO")) + double.Parse(Conn.GetFieldValue(i,"Nbr_Of_RN_CO")) + double.Parse(Conn.GetFieldValue(i,"Nbr_Of_LmtChg_CO")) + double.Parse(Conn.GetFieldValue(i,"Nbr_Of_PB_CRM")) + double.Parse(Conn.GetFieldValue(i,"Nbr_Of_RN_CRM")) + double.Parse(Conn.GetFieldValue(i,"Nbr_Of_LmtChg_CRM"));
				Lmt_Of_BU_BOOK +=(double.Parse(Conn.GetFieldValue(i,"Lmt_Of_LmtChg_BU_BOOK")) + double.Parse(Conn.GetFieldValue(i,"Lmt_Of_LmtChg_CO_BOOK")) + double.Parse(Conn.GetFieldValue(i,"Lmt_Of_LmtChg_CRM_BOOK")) +  double.Parse(Conn.GetFieldValue(i,"Lmt_Of_PB_BU_BOOK")) +  double.Parse(Conn.GetFieldValue(i,"Lmt_Of_PB_CO_BOOK")) +  double.Parse(Conn.GetFieldValue(i,"Lmt_Of_PB_CRM_BOOK")) +  double.Parse(Conn.GetFieldValue(i,"Lmt_Of_RN_BU_BOOK")) +  double.Parse(Conn.GetFieldValue(i,"Lmt_Of_RN_CO_BOOK")) +  double.Parse(Conn.GetFieldValue(i,"Lmt_Of_RN_CRM_BOOK")))/1000000;
				Nbr_Of_BU_BOOK += double.Parse(Conn.GetFieldValue(i,"Nbr_Of_LmtChg_BU_BOOK")) + double.Parse(Conn.GetFieldValue(i,"Nbr_Of_LmtChg_CO_BOOK")) +  double.Parse(Conn.GetFieldValue(i,"Nbr_Of_LmtChg_CRM_BOOK")) +  double.Parse(Conn.GetFieldValue(i,"Nbr_Of_PB_BU_BOOK")) +   double.Parse(Conn.GetFieldValue(i,"Nbr_Of_PB_CO_BOOK")) +  double.Parse(Conn.GetFieldValue(i,"Nbr_Of_PB_CRM_BOOK")) + double.Parse(Conn.GetFieldValue(i,"Nbr_Of_RN_BU_BOOK")) +  double.Parse(Conn.GetFieldValue(i,"Nbr_Of_RN_CO_BOOK")) +   double.Parse(Conn.GetFieldValue(i,"Nbr_Of_RN_CRM_BOOK"));

				tLmt_Of_BU += (double.Parse(Conn.GetFieldValue(i,"Lmt_Of_PB_BU")) + double.Parse(Conn.GetFieldValue(i,"Lmt_Of_RN_BU")) + double.Parse(Conn.GetFieldValue(i,"Lmt_Of_LmtChg_BU")))/1000000;
				tNbr_Of_BU += double.Parse(Conn.GetFieldValue(i,"Nbr_Of_PB_BU")) + double.Parse(Conn.GetFieldValue(i,"Nbr_Of_RN_BU")) + double.Parse(Conn.GetFieldValue(i,"Nbr_Of_LmtChg_BU"));
				tLmt_Of_CRM += double.Parse(Conn.GetFieldValue(i,"Lmt_Of_PB_CRM")) + double.Parse(Conn.GetFieldValue(i,"Lmt_Of_RN_CRM")) + double.Parse(Conn.GetFieldValue(i,"Lmt_Of_LmtChg_CRM"))/1000000;
				tNbr_Of_CRM += double.Parse(Conn.GetFieldValue(i,"Nbr_Of_PB_CRM")) + double.Parse(Conn.GetFieldValue(i,"Nbr_Of_RN_CRM")) + double.Parse(Conn.GetFieldValue(i,"Nbr_Of_LmtChg_CRM"));
				tLmt_Of_CO += (double.Parse(Conn.GetFieldValue(i,"Lmt_Of_PB_CO")) + double.Parse(Conn.GetFieldValue(i,"Lmt_Of_RN_CO")) + double.Parse(Conn.GetFieldValue(i,"Lmt_Of_LmtChg_CO")))/1000000;
				tNbr_Of_CO += double.Parse(Conn.GetFieldValue(i,"Nbr_Of_PB_CO")) + double.Parse(Conn.GetFieldValue(i,"Nbr_Of_RN_CO")) + double.Parse(Conn.GetFieldValue(i,"Nbr_Of_LmtChg_CO"));
				tLmt_Of_On_Proc += (double.Parse(Conn.GetFieldValue(i,"Lmt_Of_PB_BU")) + double.Parse(Conn.GetFieldValue(i,"Lmt_Of_RN_BU")) + double.Parse(Conn.GetFieldValue(i,"Lmt_Of_LmtChg_BU")) + double.Parse(Conn.GetFieldValue(i,"Lmt_Of_PB_CRM")) + double.Parse(Conn.GetFieldValue(i,"Lmt_Of_RN_CRM")) + double.Parse(Conn.GetFieldValue(i,"Lmt_Of_LmtChg_CRM")) + double.Parse(Conn.GetFieldValue(i,"Lmt_Of_PB_CO")) +  double.Parse(Conn.GetFieldValue(i,"Lmt_Of_RN_CO")) + double.Parse(Conn.GetFieldValue(i,"Lmt_Of_LmtChg_CO")))/1000000;
				tNbr_of_BU += double.Parse(Conn.GetFieldValue(i,"Nbr_Of_PB_BU")) + double.Parse(Conn.GetFieldValue(i,"Nbr_Of_RN_BU")) + double.Parse(Conn.GetFieldValue(i,"Nbr_Of_LmtChg_BU")) + double.Parse(Conn.GetFieldValue(i,"Nbr_Of_PB_CO")) + double.Parse(Conn.GetFieldValue(i,"Nbr_Of_RN_CO")) + double.Parse(Conn.GetFieldValue(i,"Nbr_Of_LmtChg_CO")) + double.Parse(Conn.GetFieldValue(i,"Nbr_Of_PB_CRM")) + double.Parse(Conn.GetFieldValue(i,"Nbr_Of_RN_CRM")) + double.Parse(Conn.GetFieldValue(i,"Nbr_Of_LmtChg_CRM"));
				tLmt_Of_BU_BOOK +=(double.Parse(Conn.GetFieldValue(i,"Lmt_Of_LmtChg_BU_BOOK")) + double.Parse(Conn.GetFieldValue(i,"Lmt_Of_LmtChg_CO_BOOK")) + double.Parse(Conn.GetFieldValue(i,"Lmt_Of_LmtChg_CRM_BOOK")) +  double.Parse(Conn.GetFieldValue(i,"Lmt_Of_PB_BU_BOOK")) +  double.Parse(Conn.GetFieldValue(i,"Lmt_Of_PB_CO_BOOK")) +  double.Parse(Conn.GetFieldValue(i,"Lmt_Of_PB_CRM_BOOK")) +  double.Parse(Conn.GetFieldValue(i,"Lmt_Of_RN_BU_BOOK")) +  double.Parse(Conn.GetFieldValue(i,"Lmt_Of_RN_CO_BOOK")) +  double.Parse(Conn.GetFieldValue(i,"Lmt_Of_RN_CRM_BOOK")))/1000000;
				tNbr_Of_BU_BOOK += double.Parse(Conn.GetFieldValue(i,"Nbr_Of_LmtChg_BU_BOOK")) + double.Parse(Conn.GetFieldValue(i,"Nbr_Of_LmtChg_CO_BOOK")) +  double.Parse(Conn.GetFieldValue(i,"Nbr_Of_LmtChg_CRM_BOOK")) +  double.Parse(Conn.GetFieldValue(i,"Nbr_Of_PB_BU_BOOK")) +   double.Parse(Conn.GetFieldValue(i,"Nbr_Of_PB_CO_BOOK")) +  double.Parse(Conn.GetFieldValue(i,"Nbr_Of_PB_CRM_BOOK")) + double.Parse(Conn.GetFieldValue(i,"Nbr_Of_RN_BU_BOOK")) +  double.Parse(Conn.GetFieldValue(i,"Nbr_Of_RN_CO_BOOK")) +   double.Parse(Conn.GetFieldValue(i,"Nbr_Of_RN_CRM_BOOK"));

				TBL_CONTENT.Rows.Add(new TableRow());
				TBL_CONTENT.Rows[i + k + 3].Cells.Add(new TableCell());
				TBL_CONTENT.Rows[i + k + 3].Cells[0].Text = "&nbsp;" + ((int)(i + 1)).ToString();
				TBL_CONTENT.Rows[i + k + 3].Cells[0].HorizontalAlign = HorizontalAlign.Center;
				TBL_CONTENT.Rows[i + k + 3].Cells[0].CssClass= "ItemPrint_d";

				TBL_CONTENT.Rows[i + k + 3].Cells.Add(new TableCell());
				TBL_CONTENT.Rows[i + k + 3].Cells[1].Text = "&nbsp;";
				TBL_CONTENT.Rows[i + k + 3].Cells[1].HorizontalAlign = HorizontalAlign.Left;
				TBL_CONTENT.Rows[i + k + 3].Cells[1].CssClass= "ItemPrint_d";

				TBL_CONTENT.Rows[i + k + 3].Cells.Add(new TableCell());
				TBL_CONTENT.Rows[i + k + 3].Cells[2].Text = "&nbsp;" + Conn.GetFieldValue(i,"product_name");
				TBL_CONTENT.Rows[i + k + 3].Cells[2].HorizontalAlign = HorizontalAlign.Left;
				TBL_CONTENT.Rows[i + k + 3].Cells[2].CssClass= "ItemPrint_d";

				double tmp_val = (Double.Parse(Conn.GetFieldValue(i,"Lmt_Of_PB_BU")) + Double.Parse(Conn.GetFieldValue(i,"Lmt_Of_RN_BU")) + Double.Parse(Conn.GetFieldValue(i,"Lmt_Of_LmtChg_BU")))/1000000;
				TBL_CONTENT.Rows[i + k + 3].Cells.Add(new TableCell());
				TBL_CONTENT.Rows[i + k + 3].Cells[3].Text = "&nbsp;" + tools.ConvertCurr(tools.ConvertNum(tmp_val.ToString()).ToString()) + "&nbsp;";
				TBL_CONTENT.Rows[i + k + 3].Cells[3].HorizontalAlign = HorizontalAlign.Right;
				TBL_CONTENT.Rows[i + k + 3].Cells[3].CssClass= "ItemPrint_d";

				tmp_val = double.Parse(Conn.GetFieldValue(i,"Nbr_Of_PB_BU")) + double.Parse(Conn.GetFieldValue(i,"Nbr_Of_RN_BU")) + double.Parse(Conn.GetFieldValue(i,"Nbr_Of_LmtChg_BU"));
				TBL_CONTENT.Rows[i + k + 3].Cells.Add(new TableCell());
				TBL_CONTENT.Rows[i + k + 3].Cells[4].Text = "&nbsp;" + tools.ConvertNum(tmp_val.ToString()) + "&nbsp;";
				TBL_CONTENT.Rows[i + k + 3].Cells[4].HorizontalAlign = HorizontalAlign.Right;
				TBL_CONTENT.Rows[i + k + 3].Cells[4].CssClass= "ItemPrint_d";

				tmp_val = double.Parse(Conn.GetFieldValue(i,"Lmt_Of_PB_CRM")) + double.Parse(Conn.GetFieldValue(i,"Lmt_Of_RN_CRM")) + double.Parse(Conn.GetFieldValue(i,"Lmt_Of_LmtChg_CRM"))/1000000;
				TBL_CONTENT.Rows[i + k + 3].Cells.Add(new TableCell());
				TBL_CONTENT.Rows[i + k + 3].Cells[5].Text = "&nbsp;" +  tools.ConvertCurr(tools.ConvertNum(tmp_val.ToString()).ToString()) + "&nbsp;";
				TBL_CONTENT.Rows[i + k + 3].Cells[5].HorizontalAlign = HorizontalAlign.Right;
				TBL_CONTENT.Rows[i + k + 3].Cells[5].CssClass= "ItemPrint_d";

				tmp_val = double.Parse(Conn.GetFieldValue(i,"Nbr_Of_PB_CRM")) + double.Parse(Conn.GetFieldValue(i,"Nbr_Of_RN_CRM")) + double.Parse(Conn.GetFieldValue(i,"Nbr_Of_LmtChg_CRM"));
				TBL_CONTENT.Rows[i + k + 3].Cells.Add(new TableCell());
				TBL_CONTENT.Rows[i + k + 3].Cells[6].Text = "&nbsp;" +  tools.ConvertNum(tmp_val.ToString()) + "&nbsp;";
				TBL_CONTENT.Rows[i + k + 3].Cells[6].HorizontalAlign = HorizontalAlign.Right;
				TBL_CONTENT.Rows[i + k + 3].Cells[6].CssClass= "ItemPrint_d";

				tmp_val = (double.Parse(Conn.GetFieldValue(i,"Lmt_Of_PB_CO")) + double.Parse(Conn.GetFieldValue(i,"Lmt_Of_RN_CO")) + double.Parse(Conn.GetFieldValue(i,"Lmt_Of_LmtChg_CO")))/1000000;
				TBL_CONTENT.Rows[i + k + 3].Cells.Add(new TableCell());
				TBL_CONTENT.Rows[i + k + 3].Cells[7].Text = "&nbsp;" + tools.ConvertCurr(tools.ConvertNum(tmp_val.ToString()).ToString()) + "&nbsp;";
				TBL_CONTENT.Rows[i + k + 3].Cells[7].HorizontalAlign = HorizontalAlign.Right;
				TBL_CONTENT.Rows[i + k + 3].Cells[7].CssClass= "ItemPrint_d";

				tmp_val = double.Parse(Conn.GetFieldValue(i,"Nbr_Of_PB_CO")) + double.Parse(Conn.GetFieldValue(i,"Nbr_Of_RN_CO")) + double.Parse(Conn.GetFieldValue(i,"Nbr_Of_LmtChg_CO"));
				TBL_CONTENT.Rows[i + k + 3].Cells.Add(new TableCell());
				TBL_CONTENT.Rows[i + k + 3].Cells[8].Text = "&nbsp;" +  tools.ConvertNum(tmp_val.ToString()) + "&nbsp;";
				TBL_CONTENT.Rows[i + k + 3].Cells[8].HorizontalAlign = HorizontalAlign.Right;
				TBL_CONTENT.Rows[i + k + 3].Cells[8].CssClass= "ItemPrint_d";

				tmp_val = (double.Parse(Conn.GetFieldValue(i,"Lmt_Of_PB_BU")) + double.Parse(Conn.GetFieldValue(i,"Lmt_Of_RN_BU")) + double.Parse(Conn.GetFieldValue(i,"Lmt_Of_LmtChg_BU")) + double.Parse(Conn.GetFieldValue(i,"Lmt_Of_PB_CRM")) + double.Parse(Conn.GetFieldValue(i,"Lmt_Of_RN_CRM")) + double.Parse(Conn.GetFieldValue(i,"Lmt_Of_LmtChg_CRM")) + double.Parse(Conn.GetFieldValue(i,"Lmt_Of_PB_CO")) +  double.Parse(Conn.GetFieldValue(i,"Lmt_Of_RN_CO")) + double.Parse(Conn.GetFieldValue(i,"Lmt_Of_LmtChg_CO")))/1000000;
				TBL_CONTENT.Rows[i + k + 3].Cells.Add(new TableCell());
				TBL_CONTENT.Rows[i + k + 3].Cells[9].Text = "&nbsp;" + tools.ConvertCurr(tools.ConvertNum(tmp_val.ToString()).ToString()) + "&nbsp;";
				TBL_CONTENT.Rows[i + k + 3].Cells[9].HorizontalAlign = HorizontalAlign.Right;
				TBL_CONTENT.Rows[i + k + 3].Cells[9].CssClass= "ItemPrint_d";
		
				tmp_val = double.Parse(Conn.GetFieldValue(i,"Nbr_Of_PB_BU")) + double.Parse(Conn.GetFieldValue(i,"Nbr_Of_RN_BU")) + double.Parse(Conn.GetFieldValue(i,"Nbr_Of_LmtChg_BU")) + double.Parse(Conn.GetFieldValue(i,"Nbr_Of_PB_CO")) + double.Parse(Conn.GetFieldValue(i,"Nbr_Of_RN_CO")) + double.Parse(Conn.GetFieldValue(i,"Nbr_Of_LmtChg_CO")) + double.Parse(Conn.GetFieldValue(i,"Nbr_Of_PB_CRM")) + double.Parse(Conn.GetFieldValue(i,"Nbr_Of_RN_CRM")) + double.Parse(Conn.GetFieldValue(i,"Nbr_Of_LmtChg_CRM"));
				TBL_CONTENT.Rows[i + k + 3].Cells.Add(new TableCell());
				TBL_CONTENT.Rows[i + k + 3].Cells[10].Text = "&nbsp;" + tools.ConvertNum(tmp_val.ToString()) + "&nbsp;";
				TBL_CONTENT.Rows[i + k + 3].Cells[10].HorizontalAlign = HorizontalAlign.Right;
				TBL_CONTENT.Rows[i + k + 3].Cells[10].CssClass= "ItemPrint_d";

				tmp_val = (double.Parse(Conn.GetFieldValue(i,"Lmt_Of_LmtChg_BU_BOOK")) + double.Parse(Conn.GetFieldValue(i,"Lmt_Of_LmtChg_CO_BOOK")) + double.Parse(Conn.GetFieldValue(i,"Lmt_Of_LmtChg_CRM_BOOK")) +  double.Parse(Conn.GetFieldValue(i,"Lmt_Of_PB_BU_BOOK")) +  double.Parse(Conn.GetFieldValue(i,"Lmt_Of_PB_CO_BOOK")) +  double.Parse(Conn.GetFieldValue(i,"Lmt_Of_PB_CRM_BOOK")) +  double.Parse(Conn.GetFieldValue(i,"Lmt_Of_RN_BU_BOOK")) +  double.Parse(Conn.GetFieldValue(i,"Lmt_Of_RN_CO_BOOK")) +  double.Parse(Conn.GetFieldValue(i,"Lmt_Of_RN_CRM_BOOK")))/1000000;
				TBL_CONTENT.Rows[i + k + 3].Cells.Add(new TableCell());
				TBL_CONTENT.Rows[i + k + 3].Cells[11].Text = "&nbsp;" + tools.ConvertCurr(tools.ConvertNum(tmp_val.ToString()).ToString()) + "&nbsp;";
				TBL_CONTENT.Rows[i + k + 3].Cells[11].HorizontalAlign = HorizontalAlign.Right;
				TBL_CONTENT.Rows[i + k + 3].Cells[11].CssClass= "ItemPrint_d";

				tmp_val = double.Parse(Conn.GetFieldValue(i,"Nbr_Of_LmtChg_BU_BOOK")) + double.Parse(Conn.GetFieldValue(i,"Nbr_Of_LmtChg_CO_BOOK")) +  double.Parse(Conn.GetFieldValue(i,"Nbr_Of_LmtChg_CRM_BOOK")) +  double.Parse(Conn.GetFieldValue(i,"Nbr_Of_PB_BU_BOOK")) +   double.Parse(Conn.GetFieldValue(i,"Nbr_Of_PB_CO_BOOK")) +  double.Parse(Conn.GetFieldValue(i,"Nbr_Of_PB_CRM_BOOK")) + double.Parse(Conn.GetFieldValue(i,"Nbr_Of_RN_BU_BOOK")) +  double.Parse(Conn.GetFieldValue(i,"Nbr_Of_RN_CO_BOOK")) +   double.Parse(Conn.GetFieldValue(i,"Nbr_Of_RN_CRM_BOOK"));
				TBL_CONTENT.Rows[i + k + 3].Cells.Add(new TableCell());
				TBL_CONTENT.Rows[i + k + 3].Cells[12].Text = "&nbsp;" + tools.ConvertNum(tmp_val.ToString()) + "&nbsp;";
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
			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 3].Cells[1].HorizontalAlign = HorizontalAlign.Left;
			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 3].Cells[1].CssClass= "ItemPrint_d";

			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 3].Cells.Add(new TableCell());
			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 3].Cells[2].Font.Bold=true; 
			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 3].Cells[2].Text = "&nbsp;";
			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 3].Cells[2].HorizontalAlign = HorizontalAlign.Left;
			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 3].Cells[2].CssClass= "ItemPrint_d";

			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 3].Cells.Add(new TableCell());
			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 3].Cells[3].Font.Bold=true; 
			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 3].Cells[3].Text = "&nbsp;" + tools.ConvertCurr(tools.ConvertNum(Lmt_Of_BU.ToString()).ToString()) + "&nbsp;";
			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 3].Cells[3].HorizontalAlign = HorizontalAlign.Right;
			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 3].Cells[3].CssClass= "ItemPrint_d";
				
			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 3].Cells.Add(new TableCell());
			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 3].Cells[4].Font.Bold=true; 
			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 3].Cells[4].Text = "&nbsp;" + Nbr_Of_BU.ToString() + "&nbsp;";
			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 3].Cells[4].HorizontalAlign = HorizontalAlign.Right;
			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 3].Cells[4].CssClass= "ItemPrint_d";

			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 3].Cells.Add(new TableCell());
			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 3].Cells[5].Font.Bold=true; 
			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 3].Cells[5].Text = "&nbsp;" +  tools.ConvertCurr(tools.ConvertNum(Lmt_Of_CRM.ToString()).ToString()) + "&nbsp;";
			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 3].Cells[5].HorizontalAlign = HorizontalAlign.Right;
			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 3].Cells[5].CssClass= "ItemPrint_d";

			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 3].Cells.Add(new TableCell());
			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 3].Cells[6].Font.Bold=true; 
			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 3].Cells[6].Text = "&nbsp;" +  tools.ConvertNum(Nbr_Of_CRM.ToString()) + "&nbsp;";
			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 3].Cells[6].HorizontalAlign = HorizontalAlign.Right;
			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 3].Cells[6].CssClass= "ItemPrint_d";

			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 3].Cells.Add(new TableCell());
			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 3].Cells[7].Font.Bold=true; 
			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 3].Cells[7].Text = "&nbsp;" + tools.ConvertCurr(tools.ConvertNum(Lmt_Of_CO.ToString()).ToString()) + "&nbsp;";
			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 3].Cells[7].HorizontalAlign = HorizontalAlign.Right;
			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 3].Cells[7].CssClass= "ItemPrint_d";

			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 3].Cells.Add(new TableCell());
			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 3].Cells[8].Font.Bold=true; 
			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 3].Cells[8].Text = "&nbsp;" +  tools.ConvertNum(Nbr_Of_CO.ToString()) + "&nbsp;";
			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 3].Cells[8].HorizontalAlign = HorizontalAlign.Right;
			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 3].Cells[8].CssClass= "ItemPrint_d";

			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 3].Cells.Add(new TableCell());
			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 3].Cells[9].Font.Bold=true; 
			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 3].Cells[9].Text = "&nbsp;" + tools.ConvertCurr(tools.ConvertNum(Lmt_Of_On_Proc.ToString()).ToString()) + "&nbsp;";
			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 3].Cells[9].HorizontalAlign = HorizontalAlign.Right;
			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 3].Cells[9].CssClass= "ItemPrint_d";
		
			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 3].Cells.Add(new TableCell());
			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 3].Cells[10].Font.Bold=true; 
			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 3].Cells[10].Text = "&nbsp;" + tools.ConvertNum(Nbr_of_BU.ToString()) + "&nbsp;";
			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 3].Cells[10].HorizontalAlign = HorizontalAlign.Right;
			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 3].Cells[10].CssClass= "ItemPrint_d";

			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 3].Cells.Add(new TableCell());
			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 3].Cells[11].Font.Bold=true; 
			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 3].Cells[11].Text = "&nbsp;" + tools.ConvertCurr(tools.ConvertNum(Lmt_Of_BU_BOOK.ToString()).ToString()) + "&nbsp;";
			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 3].Cells[11].HorizontalAlign = HorizontalAlign.Right;
			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 3].Cells[11].CssClass= "ItemPrint_d";

			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 3].Cells.Add(new TableCell());
			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 3].Cells[12].Font.Bold=true; 
			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 3].Cells[12].Text = "&nbsp;" + tools.ConvertNum(Nbr_Of_BU_BOOK.ToString()) + "&nbsp;";
			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 3].Cells[12].HorizontalAlign = HorizontalAlign.Right;
			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 3].Cells[12].CssClass= "ItemPrint_d";

			//Total
			TBL_CONTENT.Rows.Add(new TableRow());
			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 4].Cells.Add(new TableCell());
			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 4].Cells[0].Text = "&nbsp;";
			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 4].Cells[0].HorizontalAlign = HorizontalAlign.Center;
			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 4].Cells[0].CssClass= "ItemPrint_d";

			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 4].Cells.Add(new TableCell());
			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 4].Font.Bold=true;
			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 4].Cells[1].Text = "&nbsp;TOTAL&nbsp;";
			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 4].Cells[1].HorizontalAlign = HorizontalAlign.Left;
			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 4].Cells[1].CssClass= "ItemPrint_d";

			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 4].Cells.Add(new TableCell());
			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 4].Cells[2].Font.Bold=true; 
			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 4].Cells[2].Text = "&nbsp;";
			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 4].Cells[2].HorizontalAlign = HorizontalAlign.Left;
			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 4].Cells[2].CssClass= "ItemPrint_d";

			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 4].Cells.Add(new TableCell());
			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 4].Cells[3].Font.Bold=true; 
			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 4].Cells[3].Text = "&nbsp;" + tools.ConvertCurr(tools.ConvertNum(tLmt_Of_BU.ToString()).ToString()) + "&nbsp;";
			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 4].Cells[3].HorizontalAlign = HorizontalAlign.Right;
			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 4].Cells[3].CssClass= "ItemPrint_d";
				
			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 4].Cells.Add(new TableCell());
			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 4].Cells[4].Font.Bold=true; 
			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 4].Cells[4].Text = "&nbsp;" + tNbr_Of_BU.ToString() + "&nbsp;";
			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 4].Cells[4].HorizontalAlign = HorizontalAlign.Right;
			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 4].Cells[4].CssClass= "ItemPrint_d";

			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 4].Cells.Add(new TableCell());
			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 4].Cells[5].Font.Bold=true; 
			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 4].Cells[5].Text = "&nbsp;" +  tools.ConvertCurr(tools.ConvertNum(tLmt_Of_CRM.ToString()).ToString()) + "&nbsp;";
			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 4].Cells[5].HorizontalAlign = HorizontalAlign.Right;
			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 4].Cells[5].CssClass= "ItemPrint_d";

			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 4].Cells.Add(new TableCell());
			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 4].Cells[6].Font.Bold=true; 
			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 4].Cells[6].Text = "&nbsp;" +  tools.ConvertNum(tNbr_Of_CRM.ToString()) + "&nbsp;";
			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 4].Cells[6].HorizontalAlign = HorizontalAlign.Right;
			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 4].Cells[6].CssClass= "ItemPrint_d";

			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 4].Cells.Add(new TableCell());
			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 4].Cells[7].Font.Bold=true; 
			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 4].Cells[7].Text = "&nbsp;" + tools.ConvertCurr(tools.ConvertNum(tLmt_Of_CO.ToString()).ToString()) + "&nbsp;";
			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 4].Cells[7].HorizontalAlign = HorizontalAlign.Right;
			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 4].Cells[7].CssClass= "ItemPrint_d";

			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 4].Cells.Add(new TableCell());
			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 4].Cells[8].Font.Bold=true; 
			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 4].Cells[8].Text = "&nbsp;" +  tools.ConvertNum(tNbr_Of_CO.ToString()) + "&nbsp;";
			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 4].Cells[8].HorizontalAlign = HorizontalAlign.Right;
			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 4].Cells[8].CssClass= "ItemPrint_d";

			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 4].Cells.Add(new TableCell());
			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 4].Cells[9].Font.Bold=true; 
			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 4].Cells[9].Text = "&nbsp;" + tools.ConvertCurr(tools.ConvertNum(tLmt_Of_On_Proc.ToString()).ToString()) + "&nbsp;";
			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 4].Cells[9].HorizontalAlign = HorizontalAlign.Right;
			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 4].Cells[9].CssClass= "ItemPrint_d";
		
			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 4].Cells.Add(new TableCell());
			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 4].Cells[10].Font.Bold=true; 
			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 4].Cells[10].Text = "&nbsp;" + tools.ConvertNum(tNbr_of_BU.ToString()) + "&nbsp;";
			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 4].Cells[10].HorizontalAlign = HorizontalAlign.Right;
			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 4].Cells[10].CssClass= "ItemPrint_d";

			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 4].Cells.Add(new TableCell());
			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 4].Cells[11].Font.Bold=true; 
			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 4].Cells[11].Text = "&nbsp;" + tools.ConvertCurr(tools.ConvertNum(tLmt_Of_BU_BOOK.ToString()).ToString()) + "&nbsp;";
			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 4].Cells[11].HorizontalAlign = HorizontalAlign.Right;
			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 4].Cells[11].CssClass= "ItemPrint_d";

			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 4].Cells.Add(new TableCell());
			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 4].Cells[12].Font.Bold=true; 
			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 4].Cells[12].Text = "&nbsp;" + tools.ConvertNum(tNbr_Of_BU_BOOK.ToString()) + "&nbsp;";
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
