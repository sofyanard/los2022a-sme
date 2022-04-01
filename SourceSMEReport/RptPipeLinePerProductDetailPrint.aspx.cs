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
	/// Summary description for RptPipeLinePerProductDetailPrint.
	/// </summary>
	public partial class RptPipeLinePerProductDetailPrint : System.Web.UI.Page
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
			double tmp_val=0;
            double sLmt_Of_PB_BU=0, sNbr_Of_PB_BU=0, sLmt_Of_RN_BU=0, sNbr_Of_RN_BU=0, sLmt_Of_LmtChg_BU=0,sNbr_Of_LmtChg_BU=0, sLmt_Of_PB_CRM=0, sNbr_Of_PB_CRM=0, sLmt_Of_RN_CRM=0,sNbr_Of_RN_CRM=0,sLmt_Of_LmtChg_CRM=0, sNbr_Of_LmtChg_CRM=0, sLmt_Of_PB_CO=0,sNbr_Of_PB_CO=0,sLmt_Of_RN_CO=0, sNbr_Of_RN_CO=0, sLmt_Of_LmtChg_CO=0, sNbr_Of_LmtChg_CO=0, sLmt_PB_Proc=0,sNbr_PB_Proc=0, sLmt_RN_Proc=0, sNbr_RN_Proc=0, sLmt_LmtChg_Proc=0, sNbr_LmtChg_Proc=0, sLmt_Lmt_PB_Book=0, sNbr_Lmt_PB_Book=0, sLmt_Lmt_RN_Book=0, sNbr_Lmt_RN_Book=0, sLmt_Lmt_LmtChg_Book=0, sNbr_Lmt_LmtChg_Book=0;
			double tLmt_Of_PB_BU=0, tNbr_Of_PB_BU=0, tLmt_Of_RN_BU=0, tNbr_Of_RN_BU=0, tLmt_Of_LmtChg_BU=0,tNbr_Of_LmtChg_BU=0, tLmt_Of_PB_CRM=0, tNbr_Of_PB_CRM=0, tLmt_Of_RN_CRM=0, tNbr_Of_RN_CRM=0,tLmt_Of_LmtChg_CRM=0, tNbr_Of_LmtChg_CRM=0, tLmt_Of_PB_CO=0, tNbr_Of_PB_CO=0, tLmt_Of_RN_CO=0, tNbr_Of_RN_CO=0, tLmt_Of_LmtChg_CO=0, tNbr_Of_LmtChg_CO=0, tLmt_PB_Proc=0, tNbr_PB_Proc=0, tLmt_RN_Proc=0, tNbr_RN_Proc=0, tLmt_LmtChg_Proc=0, tNbr_LmtChg_Proc=0, tLmt_Lmt_PB_Book=0, tNbr_Lmt_PB_Book=0, tLmt_Lmt_RN_Book=0, tNbr_Lmt_RN_Book=0, tLmt_Lmt_LmtChg_Book=0, tNbr_Lmt_LmtChg_Book=0;

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
						TBL_CONTENT.Rows[i + k + 4].Cells.Add(new TableCell());
						TBL_CONTENT.Rows[i + k + 4].Cells[0].Text = "&nbsp;";
						TBL_CONTENT.Rows[i + k + 4].Cells[0].HorizontalAlign = HorizontalAlign.Center;
						TBL_CONTENT.Rows[i + k + 4].Cells[0].CssClass= "ItemPrint_d";

						TBL_CONTENT.Rows[i + k + 4].Cells.Add(new TableCell());
						TBL_CONTENT.Rows[i + k + 4].Cells[1].Font.Bold=true;
						TBL_CONTENT.Rows[i + k + 4].Cells[1].Text = "&nbsp;SUB TOTAL&nbsp;";
						TBL_CONTENT.Rows[i + k + 4].Cells[1].HorizontalAlign = HorizontalAlign.Left;
						TBL_CONTENT.Rows[i + k + 4].Cells[1].CssClass= "ItemPrint_d";

						TBL_CONTENT.Rows[i + k + 4].Cells.Add(new TableCell());
						TBL_CONTENT.Rows[i + k + 4].Cells[2].Text = "&nbsp;";
						TBL_CONTENT.Rows[i + k + 4].Cells[2].HorizontalAlign = HorizontalAlign.Center;
						TBL_CONTENT.Rows[i + k + 4].Cells[2].CssClass= "ItemPrint_d";

						TBL_CONTENT.Rows[i + k + 4].Cells.Add(new TableCell());
						TBL_CONTENT.Rows[i + k + 4].Cells[3].Font.Bold=true; 
						TBL_CONTENT.Rows[i + k + 4].Cells[3].Text = tools.MoneyFormat(sLmt_Of_PB_BU.ToString())+ "&nbsp;";
						TBL_CONTENT.Rows[i + k + 4].Cells[3].HorizontalAlign = HorizontalAlign.Left;
						TBL_CONTENT.Rows[i + k + 4].Cells[3].CssClass= "ItemPrint_d";

						TBL_CONTENT.Rows[i + k + 4].Cells.Add(new TableCell());
						TBL_CONTENT.Rows[i + k + 4].Cells[4].Font.Bold=true; 
						TBL_CONTENT.Rows[i + k + 4].Cells[4].Text = "&nbsp;" + sNbr_Of_PB_BU.ToString() +  "&nbsp;";
						TBL_CONTENT.Rows[i + k + 4].Cells[4].HorizontalAlign = HorizontalAlign.Right;
						TBL_CONTENT.Rows[i + k + 4].Cells[4].CssClass= "ItemPrint_d";
				
						TBL_CONTENT.Rows[i + k + 4].Cells.Add(new TableCell());
						TBL_CONTENT.Rows[i + k + 4].Cells[5].Font.Bold=true; 
						TBL_CONTENT.Rows[i + k + 4].Cells[5].Text = "&nbsp;" + tools.MoneyFormat(sLmt_Of_RN_BU.ToString()) + "&nbsp;";
						TBL_CONTENT.Rows[i + k + 4].Cells[5].HorizontalAlign = HorizontalAlign.Right;
						TBL_CONTENT.Rows[i + k + 4].Cells[5].CssClass= "ItemPrint_d";

						TBL_CONTENT.Rows[i + k + 4].Cells.Add(new TableCell());
						TBL_CONTENT.Rows[i + k + 4].Cells[6].Font.Bold=true; 
						TBL_CONTENT.Rows[i + k + 4].Cells[6].Text = "&nbsp;" +  sNbr_Of_RN_BU.ToString() + "&nbsp;";
						TBL_CONTENT.Rows[i + k + 4].Cells[6].HorizontalAlign = HorizontalAlign.Right;
						TBL_CONTENT.Rows[i + k + 4].Cells[6].CssClass= "ItemPrint_d";

						TBL_CONTENT.Rows[i + k + 4].Cells.Add(new TableCell());
						TBL_CONTENT.Rows[i + k + 4].Cells[7].Font.Bold=true; 
						TBL_CONTENT.Rows[i + k + 4].Cells[7].Text = "&nbsp;" + tools.MoneyFormat(sLmt_Of_LmtChg_BU.ToString())  + "&nbsp;";
						TBL_CONTENT.Rows[i + k + 4].Cells[7].HorizontalAlign = HorizontalAlign.Right;
						TBL_CONTENT.Rows[i + k + 4].Cells[7].CssClass= "ItemPrint_d";

						TBL_CONTENT.Rows[i + k + 4].Cells.Add(new TableCell());
						TBL_CONTENT.Rows[i + k + 4].Cells[8].Font.Bold=true; 
						TBL_CONTENT.Rows[i + k + 4].Cells[8].Text = "&nbsp;" + sNbr_Of_LmtChg_BU.ToString() + "&nbsp;";
						TBL_CONTENT.Rows[i + k + 4].Cells[8].HorizontalAlign = HorizontalAlign.Right;
						TBL_CONTENT.Rows[i + k + 4].Cells[8].CssClass= "ItemPrint_d";

						TBL_CONTENT.Rows[i + k + 4].Cells.Add(new TableCell());
						TBL_CONTENT.Rows[i + k + 4].Cells[9].Font.Bold=true; 
						TBL_CONTENT.Rows[i + k + 4].Cells[9].Text = "&nbsp;" + tools.MoneyFormat(sLmt_Of_PB_CRM.ToString()) + "&nbsp;";
						TBL_CONTENT.Rows[i + k + 4].Cells[9].HorizontalAlign = HorizontalAlign.Right;
						TBL_CONTENT.Rows[i + k + 4].Cells[9].CssClass= "ItemPrint_d";

						TBL_CONTENT.Rows[i + k + 4].Cells.Add(new TableCell());
						TBL_CONTENT.Rows[i + k + 4].Cells[10].Font.Bold=true; 
						TBL_CONTENT.Rows[i + k + 4].Cells[10].Text = "&nbsp;" + sNbr_Of_PB_CRM.ToString() + "&nbsp;";
						TBL_CONTENT.Rows[i + k + 4].Cells[10].HorizontalAlign = HorizontalAlign.Right;
						TBL_CONTENT.Rows[i + k + 4].Cells[10].CssClass= "ItemPrint_d";

						TBL_CONTENT.Rows[i + k + 4].Cells.Add(new TableCell());
						TBL_CONTENT.Rows[i + k + 4].Cells[11].Font.Bold=true; 
						TBL_CONTENT.Rows[i + k + 4].Cells[11].Text = "&nbsp;" + tools.MoneyFormat(sLmt_Of_RN_CRM.ToString()) + "&nbsp;";
						TBL_CONTENT.Rows[i + k + 4].Cells[11].HorizontalAlign = HorizontalAlign.Right;
						TBL_CONTENT.Rows[i + k + 4].Cells[11].CssClass= "ItemPrint_d";

						TBL_CONTENT.Rows[i + k + 4].Cells.Add(new TableCell());
						TBL_CONTENT.Rows[i + k + 4].Cells[12].Font.Bold=true; 
						TBL_CONTENT.Rows[i + k + 4].Cells[12].Text = "&nbsp;" + sNbr_Of_RN_CRM.ToString() + "&nbsp;";
						TBL_CONTENT.Rows[i + k + 4].Cells[12].HorizontalAlign = HorizontalAlign.Right;
						TBL_CONTENT.Rows[i + k + 4].Cells[12].CssClass= "ItemPrint_d";

						TBL_CONTENT.Rows[i + k + 4].Cells.Add(new TableCell());
						TBL_CONTENT.Rows[i + k + 4].Cells[13].Font.Bold=true; 
						TBL_CONTENT.Rows[i + k + 4].Cells[13].Text = "&nbsp;" + tools.MoneyFormat(sLmt_Of_LmtChg_CRM.ToString()) + "&nbsp;";
						TBL_CONTENT.Rows[i + k + 4].Cells[13].HorizontalAlign = HorizontalAlign.Right;
						TBL_CONTENT.Rows[i + k + 4].Cells[13].CssClass= "ItemPrint_d";

						TBL_CONTENT.Rows[i + k + 4].Cells.Add(new TableCell());
						TBL_CONTENT.Rows[i + k + 4].Cells[14].Font.Bold=true; 
						TBL_CONTENT.Rows[i + k + 4].Cells[14].Text = "&nbsp;" + sNbr_Of_LmtChg_CRM.ToString() + "&nbsp;";
						TBL_CONTENT.Rows[i + k + 4].Cells[14].HorizontalAlign = HorizontalAlign.Right;
						TBL_CONTENT.Rows[i + k + 4].Cells[14].CssClass= "ItemPrint_d";
							
						TBL_CONTENT.Rows[i + k + 4].Cells.Add(new TableCell());
						TBL_CONTENT.Rows[i + k + 4].Cells[15].Font.Bold=true; 
						TBL_CONTENT.Rows[i + k + 4].Cells[15].Text = "&nbsp;" + tools.MoneyFormat(sLmt_Of_PB_CO.ToString()) + "&nbsp;";
						TBL_CONTENT.Rows[i + k + 4].Cells[15].HorizontalAlign = HorizontalAlign.Right;
						TBL_CONTENT.Rows[i + k + 4].Cells[15].CssClass= "ItemPrint_d";
							
						TBL_CONTENT.Rows[i + k + 4].Cells.Add(new TableCell());
						TBL_CONTENT.Rows[i + k + 4].Cells[16].Font.Bold=true; 
						TBL_CONTENT.Rows[i + k + 4].Cells[16].Text = "&nbsp;" + sNbr_Of_PB_CO.ToString() + "&nbsp;";
						TBL_CONTENT.Rows[i + k + 4].Cells[16].HorizontalAlign = HorizontalAlign.Right;
						TBL_CONTENT.Rows[i + k + 4].Cells[16].CssClass= "ItemPrint_d";
								
						TBL_CONTENT.Rows[i + k + 4].Cells.Add(new TableCell());
						TBL_CONTENT.Rows[i + k + 4].Cells[17].Font.Bold=true; 
						TBL_CONTENT.Rows[i + k + 4].Cells[17].Text = "&nbsp;" + tools.MoneyFormat(sLmt_Of_RN_CO.ToString()) + "&nbsp;";
						TBL_CONTENT.Rows[i + k + 4].Cells[17].HorizontalAlign = HorizontalAlign.Right;
						TBL_CONTENT.Rows[i + k + 4].Cells[17].CssClass= "ItemPrint_d";
                        
						TBL_CONTENT.Rows[i + k + 4].Cells.Add(new TableCell());
						TBL_CONTENT.Rows[i + k + 4].Cells[18].Font.Bold=true; 
						TBL_CONTENT.Rows[i + k + 4].Cells[18].Text = "&nbsp;" + sNbr_Of_RN_CO.ToString() + "&nbsp;";
						TBL_CONTENT.Rows[i + k + 4].Cells[18].HorizontalAlign = HorizontalAlign.Right;
						TBL_CONTENT.Rows[i + k + 4].Cells[18].CssClass= "ItemPrint_d";
								
						TBL_CONTENT.Rows[i + k + 4].Cells.Add(new TableCell());
						TBL_CONTENT.Rows[i + k + 4].Cells[19].Font.Bold=true; 
						TBL_CONTENT.Rows[i + k + 4].Cells[19].Text = "&nbsp;" + tools.MoneyFormat(sLmt_Of_LmtChg_CO.ToString()) + "&nbsp;";
						TBL_CONTENT.Rows[i + k + 4].Cells[19].HorizontalAlign = HorizontalAlign.Right;
						TBL_CONTENT.Rows[i + k + 4].Cells[19].CssClass= "ItemPrint_d";
									
						TBL_CONTENT.Rows[i + k + 4].Cells.Add(new TableCell());
						TBL_CONTENT.Rows[i + k + 4].Cells[20].Font.Bold=true; 
						TBL_CONTENT.Rows[i + k + 4].Cells[20].Text = "&nbsp;" + sNbr_Of_LmtChg_CO.ToString() + "&nbsp;";
						TBL_CONTENT.Rows[i + k + 4].Cells[20].HorizontalAlign = HorizontalAlign.Right;
						TBL_CONTENT.Rows[i + k + 4].Cells[20].CssClass= "ItemPrint_d";
										
						TBL_CONTENT.Rows[i + k + 4].Cells.Add(new TableCell());
						TBL_CONTENT.Rows[i + k + 4].Cells[21].Font.Bold=true; 
						TBL_CONTENT.Rows[i + k + 4].Cells[21].Text = "&nbsp;" + tools.MoneyFormat(sLmt_PB_Proc.ToString()) + "&nbsp;";
						TBL_CONTENT.Rows[i + k + 4].Cells[21].HorizontalAlign = HorizontalAlign.Right;
						TBL_CONTENT.Rows[i + k + 4].Cells[21].CssClass= "ItemPrint_d";
										
						TBL_CONTENT.Rows[i + k + 4].Cells.Add(new TableCell());
						TBL_CONTENT.Rows[i + k + 4].Cells[22].Font.Bold=true; 
						TBL_CONTENT.Rows[i + k + 4].Cells[22].Text = "&nbsp;" + sNbr_PB_Proc.ToString() + "&nbsp;";
						TBL_CONTENT.Rows[i + k + 4].Cells[22].HorizontalAlign = HorizontalAlign.Right;
						TBL_CONTENT.Rows[i + k + 4].Cells[22].CssClass= "ItemPrint_d";
											
						TBL_CONTENT.Rows[i + k + 4].Cells.Add(new TableCell());
						TBL_CONTENT.Rows[i + k + 4].Cells[23].Font.Bold=true; 
						TBL_CONTENT.Rows[i + k + 4].Cells[23].Text = "&nbsp;" + tools.MoneyFormat(sLmt_RN_Proc.ToString()) + "&nbsp;";
						TBL_CONTENT.Rows[i + k + 4].Cells[23].HorizontalAlign = HorizontalAlign.Right;
						TBL_CONTENT.Rows[i + k + 4].Cells[23].CssClass= "ItemPrint_d";
											
						TBL_CONTENT.Rows[i + k + 4].Cells.Add(new TableCell());
						TBL_CONTENT.Rows[i + k + 4].Cells[24].Font.Bold=true; 
						TBL_CONTENT.Rows[i + k + 4].Cells[24].Text = "&nbsp;" + sNbr_RN_Proc.ToString() + "&nbsp;";
						TBL_CONTENT.Rows[i + k + 4].Cells[24].HorizontalAlign = HorizontalAlign.Right;
						TBL_CONTENT.Rows[i + k + 4].Cells[24].CssClass= "ItemPrint_d";
												
						TBL_CONTENT.Rows[i + k + 4].Cells.Add(new TableCell());
						TBL_CONTENT.Rows[i + k + 4].Cells[25].Font.Bold=true; 
						TBL_CONTENT.Rows[i + k + 4].Cells[25].Text = "&nbsp;" + tools.MoneyFormat(sLmt_LmtChg_Proc.ToString()) + "&nbsp;";
						TBL_CONTENT.Rows[i + k + 4].Cells[25].Text = "&nbsp;" + sLmt_LmtChg_Proc.ToString() + "&nbsp;";
						TBL_CONTENT.Rows[i + k + 4].Cells[25].HorizontalAlign = HorizontalAlign.Right;
						TBL_CONTENT.Rows[i + k + 4].Cells[25].CssClass= "ItemPrint_d";
												
						TBL_CONTENT.Rows[i + k + 4].Cells.Add(new TableCell());
						TBL_CONTENT.Rows[i + k + 4].Cells[26].Font.Bold=true; 
						TBL_CONTENT.Rows[i + k + 4].Cells[26].Text = "&nbsp;" + sNbr_LmtChg_Proc.ToString() + "&nbsp;";
						TBL_CONTENT.Rows[i + k + 4].Cells[26].HorizontalAlign = HorizontalAlign.Right;
						TBL_CONTENT.Rows[i + k + 4].Cells[26].CssClass= "ItemPrint_d";
													
						TBL_CONTENT.Rows[i + k + 4].Cells.Add(new TableCell());
						TBL_CONTENT.Rows[i + k + 4].Cells[27].Font.Bold=true; 
						TBL_CONTENT.Rows[i + k + 4].Cells[27].Text = "&nbsp;" + tools.MoneyFormat(sLmt_Lmt_PB_Book.ToString()) + "&nbsp;";
						TBL_CONTENT.Rows[i + k + 4].Cells[27].HorizontalAlign = HorizontalAlign.Right;
						TBL_CONTENT.Rows[i + k + 4].Cells[27].CssClass= "ItemPrint_d";
													
						TBL_CONTENT.Rows[i + k + 4].Cells.Add(new TableCell());
						TBL_CONTENT.Rows[i + k + 4].Cells[28].Font.Bold=true; 
						TBL_CONTENT.Rows[i + k + 4].Cells[28].Text = "&nbsp;" + sNbr_Lmt_PB_Book.ToString() + "&nbsp;";
						TBL_CONTENT.Rows[i + k + 4].Cells[28].HorizontalAlign = HorizontalAlign.Right;
						TBL_CONTENT.Rows[i + k + 4].Cells[28].CssClass= "ItemPrint_d";
														
						TBL_CONTENT.Rows[i + k + 4].Cells.Add(new TableCell());
						TBL_CONTENT.Rows[i + k + 4].Cells[29].Font.Bold=true; 
						TBL_CONTENT.Rows[i + k + 4].Cells[29].Text = "&nbsp;" + tools.MoneyFormat(sLmt_Lmt_RN_Book.ToString()) + "&nbsp;";
						TBL_CONTENT.Rows[i + k + 4].Cells[29].HorizontalAlign = HorizontalAlign.Right;
						TBL_CONTENT.Rows[i + k + 4].Cells[29].CssClass= "ItemPrint_d";
														
						TBL_CONTENT.Rows[i + k + 4].Cells.Add(new TableCell());
						TBL_CONTENT.Rows[i + k + 4].Cells[30].Font.Bold=true; 
						TBL_CONTENT.Rows[i + k + 4].Cells[30].Text = "&nbsp;" + sNbr_Lmt_RN_Book.ToString() + "&nbsp;";
						TBL_CONTENT.Rows[i + k + 4].Cells[30].HorizontalAlign = HorizontalAlign.Right;
						TBL_CONTENT.Rows[i + k + 4].Cells[30].CssClass= "ItemPrint_d";
															
 					    TBL_CONTENT.Rows[i + k + 4].Cells.Add(new TableCell());
						TBL_CONTENT.Rows[i + k + 4].Cells[31].Font.Bold=true; 
						TBL_CONTENT.Rows[i + k + 4].Cells[31].Text = "&nbsp;" + tools.MoneyFormat(sLmt_Lmt_LmtChg_Book.ToString()) + "&nbsp;";
						TBL_CONTENT.Rows[i + k + 4].Cells[31].HorizontalAlign = HorizontalAlign.Right;
						TBL_CONTENT.Rows[i + k + 4].Cells[31].CssClass= "ItemPrint_d";
															
						TBL_CONTENT.Rows[i + k + 4].Cells.Add(new TableCell());
						TBL_CONTENT.Rows[i + k + 4].Cells[32].Font.Bold=true; 
						TBL_CONTENT.Rows[i + k + 4].Cells[32].Text = "&nbsp;" + sNbr_Lmt_LmtChg_Book.ToString() + "&nbsp;";
						TBL_CONTENT.Rows[i + k + 4].Cells[32].HorizontalAlign = HorizontalAlign.Right;
						TBL_CONTENT.Rows[i + k + 4].Cells[32].CssClass= "ItemPrint_d";
						k += 1;
						//---------sub total
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
					sLmt_PB_Proc=0;
					sNbr_PB_Proc=0;
					sLmt_RN_Proc=0;
					sNbr_RN_Proc=0;
					sLmt_LmtChg_Proc=0;
					sNbr_LmtChg_Proc=0;
					sLmt_Lmt_PB_Book=0;
					sNbr_Lmt_PB_Book=0;
					sLmt_Lmt_RN_Book=0;
					sNbr_Lmt_RN_Book=0;
					sLmt_Lmt_LmtChg_Book=0;
					sNbr_Lmt_LmtChg_Book=0;

					TBL_CONTENT.Rows.Add(new TableRow());
					TBL_CONTENT.Rows[i + k + 4].Cells.Add(new TableCell());
					TBL_CONTENT.Rows[i + k + 4].Cells[0].Text = "&nbsp;";
					TBL_CONTENT.Rows[i + k + 4].Cells[0].HorizontalAlign = HorizontalAlign.Center;
					TBL_CONTENT.Rows[i + k + 4].Cells[0].CssClass= "ItemPrint_d";

					//TBL_CONTENT.Rows.Add(new TableRow());
					TBL_CONTENT.Rows[i + k + 4].Cells.Add(new TableCell());
					TBL_CONTENT.Rows[i + k + 4].Cells[1].Text = "&nbsp;" + Conn.GetFieldValue(i,"JENISDESC");
					TBL_CONTENT.Rows[i + k + 4].Cells[1].HorizontalAlign = HorizontalAlign.Center;
					TBL_CONTENT.Rows[i + k + 4].Cells[1].CssClass= "ItemPrint_d";
					pre_proddesc = Conn.GetFieldValue(i,"JENISDESC");
					k += 1;
				}

                //Sub Total
				tLmt_Of_PB_BU += double.Parse(Conn.GetFieldValue(i,"Lmt_Of_PB_BU"));
				tNbr_Of_PB_BU += double.Parse(Conn.GetFieldValue(i,"Nbr_Of_PB_BU")) ;
				//RN
				tLmt_Of_RN_BU += double.Parse(Conn.GetFieldValue(i,"Lmt_Of_RN_BU"));
				tNbr_Of_RN_BU += double.Parse(Conn.GetFieldValue(i,"Nbr_Of_RN_BU"));
				//Lmt Change
				tLmt_Of_LmtChg_BU += Double.Parse(Conn.GetFieldValue(i,"Lmt_Of_LmtChg_BU"));
				tNbr_Of_LmtChg_BU += double.Parse(Conn.GetFieldValue(i,"Nbr_Of_LmtChg_BU"));
				//CRM
				//Baru
				tLmt_Of_PB_CRM += double.Parse(Conn.GetFieldValue(i,"Lmt_Of_PB_CRM"));
				tNbr_Of_PB_CRM += double.Parse(Conn.GetFieldValue(i,"Nbr_Of_PB_CRM"));
				//RN
				tLmt_Of_RN_CRM += double.Parse(Conn.GetFieldValue(i,"Lmt_Of_RN_CRM"));
				tNbr_Of_RN_CRM += double.Parse(Conn.GetFieldValue(i,"Nbr_Of_RN_CRM"));
				//Lmt Change
				tLmt_Of_LmtChg_CRM += double.Parse(Conn.GetFieldValue(i,"Lmt_Of_LmtChg_CRM"));
				tNbr_Of_LmtChg_CRM += double.Parse(Conn.GetFieldValue(i,"Nbr_Of_LmtChg_CRM"));
				//CO
				//Baru
				tLmt_Of_PB_CO += double.Parse(Conn.GetFieldValue(i,"Lmt_Of_PB_CO"));
				tNbr_Of_PB_CO += double.Parse(Conn.GetFieldValue(i,"Nbr_Of_PB_CO"));
				//RN 
				tLmt_Of_RN_CO += double.Parse(Conn.GetFieldValue(i,"Lmt_Of_RN_CO"));
				tNbr_Of_RN_CO += double.Parse(Conn.GetFieldValue(i,"Nbr_Of_RN_CO"));
				//Lmt Chg
				tLmt_Of_LmtChg_CO += double.Parse(Conn.GetFieldValue(i,"Lmt_Of_LmtChg_CO"));
				tNbr_Of_LmtChg_CO += double.Parse(Conn.GetFieldValue(i,"Nbr_Of_LmtChg_CO"));
				//Jumlah Dalam Proses
				//Baru
				tLmt_PB_Proc += double.Parse(Conn.GetFieldValue(i,"Lmt_Of_PB_BU")) + double.Parse(Conn.GetFieldValue(i,"Lmt_Of_PB_CRM")) + double.Parse(Conn.GetFieldValue(i,"Lmt_Of_PB_CO"));
				tNbr_PB_Proc += double.Parse(Conn.GetFieldValue(i,"Nbr_Of_PB_BU")) + double.Parse(Conn.GetFieldValue(i,"Nbr_Of_PB_CRM")) + double.Parse(Conn.GetFieldValue(i,"Nbr_Of_PB_CO")) ;

				//RN
				tLmt_RN_Proc += double.Parse(Conn.GetFieldValue(i,"Lmt_Of_RN_BU")) + double.Parse(Conn.GetFieldValue(i,"Lmt_Of_RN_CRM")) + double.Parse(Conn.GetFieldValue(i,"Lmt_Of_RN_CO"));
				tNbr_RN_Proc += double.Parse(Conn.GetFieldValue(i,"Nbr_Of_RN_BU")) + double.Parse(Conn.GetFieldValue(i,"Nbr_Of_RN_CRM")) + double.Parse(Conn.GetFieldValue(i,"Nbr_Of_RN_CO"));

				//Lmt Change
				tLmt_LmtChg_Proc += double.Parse(Conn.GetFieldValue(i,"Lmt_Of_LmtChg_BU")) + double.Parse(Conn.GetFieldValue(i,"Lmt_Of_LmtChg_CRM")) + double.Parse(Conn.GetFieldValue(i,"Lmt_Of_LmtChg_CO"));
				tNbr_LmtChg_Proc += double.Parse(Conn.GetFieldValue(i,"Nbr_Of_LmtChg_BU")) + double.Parse(Conn.GetFieldValue(i,"Nbr_Of_LmtChg_CRM")) + double.Parse(Conn.GetFieldValue(i,"Nbr_Of_LmtChg_CO"));

				//Booking
				//Baru
				tLmt_Lmt_PB_Book += double.Parse(Conn.GetFieldValue(i,"Lmt_Of_PB_BU_BOOK")) +  double.Parse(Conn.GetFieldValue(i,"Lmt_Of_PB_CO_BOOK")) +  double.Parse(Conn.GetFieldValue(i,"Lmt_Of_PB_CRM_BOOK"));
				tNbr_Lmt_PB_Book += double.Parse(Conn.GetFieldValue(i,"Nbr_Of_PB_BU_BOOK")) +   double.Parse(Conn.GetFieldValue(i,"Nbr_Of_PB_CO_BOOK")) +  double.Parse(Conn.GetFieldValue(i,"Nbr_Of_PB_CRM_BOOK"));
				//RN
				tLmt_Lmt_RN_Book += double.Parse(Conn.GetFieldValue(i,"Lmt_Of_RN_BU_BOOK")) +  double.Parse(Conn.GetFieldValue(i,"Lmt_Of_RN_CO_BOOK")) +  double.Parse(Conn.GetFieldValue(i,"Lmt_Of_RN_CRM_BOOK"));
				tNbr_Lmt_RN_Book += double.Parse(Conn.GetFieldValue(i,"Nbr_Of_RN_BU_BOOK")) +  double.Parse(Conn.GetFieldValue(i,"Nbr_Of_RN_CO_BOOK")) +   double.Parse(Conn.GetFieldValue(i,"Nbr_Of_RN_CRM_BOOK"));
				//Lmt Change
				tLmt_Lmt_LmtChg_Book += double.Parse(Conn.GetFieldValue(i,"Lmt_Of_LmtChg_BU_BOOK")) + double.Parse(Conn.GetFieldValue(i,"Lmt_Of_LmtChg_CO_BOOK")) + double.Parse(Conn.GetFieldValue(i,"Lmt_Of_LmtChg_CRM_BOOK"));
				tNbr_Lmt_LmtChg_Book += double.Parse(Conn.GetFieldValue(i,"Nbr_Of_LmtChg_BU_BOOK")) + double.Parse(Conn.GetFieldValue(i,"Nbr_Of_LmtChg_CO_BOOK")) +  double.Parse(Conn.GetFieldValue(i,"Nbr_Of_LmtChg_CRM_BOOK"));
				//Sub Total

				//Total
				tLmt_Of_PB_BU += Double.Parse(Conn.GetFieldValue(i,"Lmt_Of_PB_BU"));
				tNbr_Of_PB_BU += double.Parse(Conn.GetFieldValue(i,"Nbr_Of_PB_BU")) ;
				//RN
				tLmt_Of_RN_BU += double.Parse(Conn.GetFieldValue(i,"Lmt_Of_RN_BU").ToString());
				tNbr_Of_RN_BU += double.Parse(Conn.GetFieldValue(i,"Nbr_Of_RN_BU").ToString());
				//Lmt Change
				tLmt_Of_LmtChg_BU += double.Parse(Conn.GetFieldValue(i,"Lmt_Of_LmtChg_BU").ToString());
				tNbr_Of_LmtChg_BU += double.Parse(Conn.GetFieldValue(i,"Nbr_Of_LmtChg_BU").ToString());
				//CRM
				//Baru
				tLmt_Of_PB_CRM += double.Parse(Conn.GetFieldValue(i,"Lmt_Of_PB_CRM").ToString());
				tNbr_Of_PB_CRM += double.Parse(Conn.GetFieldValue(i,"Nbr_Of_PB_CRM").ToString());
				//RN
				tLmt_Of_RN_CRM += double.Parse(Conn.GetFieldValue(i,"Lmt_Of_RN_CRM").ToString());
				tNbr_Of_RN_CRM += double.Parse(Conn.GetFieldValue(i,"Nbr_Of_RN_CRM").ToString());
				//Lmt Change
				tLmt_Of_LmtChg_CRM += double.Parse(Conn.GetFieldValue(i,"Lmt_Of_LmtChg_CRM").ToString());
				tNbr_Of_LmtChg_CRM += double.Parse(Conn.GetFieldValue(i,"Nbr_Of_LmtChg_CRM").ToString());
				//CO
				//Baru
				tLmt_Of_PB_CO += double.Parse(Conn.GetFieldValue(i,"Lmt_Of_PB_CO").ToString());
				tNbr_Of_PB_CO += double.Parse(Conn.GetFieldValue(i,"Nbr_Of_PB_CO").ToString());
				//RN 
				tLmt_Of_RN_CO += double.Parse(Conn.GetFieldValue(i,"Lmt_Of_RN_CO").ToString());
				tNbr_Of_RN_CO += double.Parse(Conn.GetFieldValue(i,"Nbr_Of_RN_CO").ToString());
				//Lmt Chg
				tLmt_Of_LmtChg_CO += double.Parse(Conn.GetFieldValue(i,"Lmt_Of_LmtChg_CO").ToString());
				tNbr_Of_LmtChg_CO += double.Parse(Conn.GetFieldValue(i,"Nbr_Of_LmtChg_CO").ToString());
				//Jumlah Dalam Proses
				//Baru
				tLmt_PB_Proc += double.Parse(Conn.GetFieldValue(i,"Lmt_Of_PB_BU")) + double.Parse(Conn.GetFieldValue(i,"Lmt_Of_PB_CRM")) + double.Parse(Conn.GetFieldValue(i,"Lmt_Of_PB_CO"));
				tNbr_PB_Proc += double.Parse(Conn.GetFieldValue(i,"Nbr_Of_PB_BU")) + double.Parse(Conn.GetFieldValue(i,"Nbr_Of_PB_CRM")) + double.Parse(Conn.GetFieldValue(i,"Nbr_Of_PB_CO")) ;

				//RN
				tLmt_RN_Proc += double.Parse(Conn.GetFieldValue(i,"Lmt_Of_RN_BU")) + double.Parse(Conn.GetFieldValue(i,"Lmt_Of_RN_CRM")) + double.Parse(Conn.GetFieldValue(i,"Lmt_Of_RN_CO"));
				tNbr_RN_Proc += double.Parse(Conn.GetFieldValue(i,"Nbr_Of_RN_BU")) + double.Parse(Conn.GetFieldValue(i,"Nbr_Of_RN_CRM")) + double.Parse(Conn.GetFieldValue(i,"Nbr_Of_RN_CO"));

				//Lmt Change
				tLmt_LmtChg_Proc += double.Parse(Conn.GetFieldValue(i,"Lmt_Of_LmtChg_BU")) + double.Parse(Conn.GetFieldValue(i,"Lmt_Of_LmtChg_CRM")) + double.Parse(Conn.GetFieldValue(i,"Lmt_Of_LmtChg_CO"));
				tNbr_LmtChg_Proc += double.Parse(Conn.GetFieldValue(i,"Nbr_Of_LmtChg_BU")) + double.Parse(Conn.GetFieldValue(i,"Nbr_Of_LmtChg_CRM")) + double.Parse(Conn.GetFieldValue(i,"Nbr_Of_LmtChg_CO"));

				//Booking
				//Baru
				tLmt_Lmt_PB_Book += double.Parse(Conn.GetFieldValue(i,"Lmt_Of_PB_BU_BOOK")) +  double.Parse(Conn.GetFieldValue(i,"Lmt_Of_PB_CO_BOOK")) +  double.Parse(Conn.GetFieldValue(i,"Lmt_Of_PB_CRM_BOOK"));
				tNbr_Lmt_PB_Book += double.Parse(Conn.GetFieldValue(i,"Nbr_Of_PB_BU_BOOK")) +   double.Parse(Conn.GetFieldValue(i,"Nbr_Of_PB_CO_BOOK")) +  double.Parse(Conn.GetFieldValue(i,"Nbr_Of_PB_CRM_BOOK"));
				//RN
				tLmt_Lmt_RN_Book += double.Parse(Conn.GetFieldValue(i,"Lmt_Of_RN_BU_BOOK")) +  double.Parse(Conn.GetFieldValue(i,"Lmt_Of_RN_CO_BOOK")) +  double.Parse(Conn.GetFieldValue(i,"Lmt_Of_RN_CRM_BOOK"));
				tNbr_Lmt_RN_Book += double.Parse(Conn.GetFieldValue(i,"Nbr_Of_RN_BU_BOOK")) +  double.Parse(Conn.GetFieldValue(i,"Nbr_Of_RN_CO_BOOK")) +   double.Parse(Conn.GetFieldValue(i,"Nbr_Of_RN_CRM_BOOK"));
				//Lmt Change
				tLmt_Lmt_LmtChg_Book += double.Parse(Conn.GetFieldValue(i,"Lmt_Of_LmtChg_BU_BOOK")) + double.Parse(Conn.GetFieldValue(i,"Lmt_Of_LmtChg_CO_BOOK")) + double.Parse(Conn.GetFieldValue(i,"Lmt_Of_LmtChg_CRM_BOOK"));
				tNbr_Lmt_LmtChg_Book += double.Parse(Conn.GetFieldValue(i,"Nbr_Of_LmtChg_BU_BOOK")) + double.Parse(Conn.GetFieldValue(i,"Nbr_Of_LmtChg_CO_BOOK")) +  double.Parse(Conn.GetFieldValue(i,"Nbr_Of_LmtChg_CRM_BOOK"));
				//Total


				TBL_CONTENT.Rows.Add(new TableRow());
				TBL_CONTENT.Rows[i + k + 4].Cells.Add(new TableCell());
				TBL_CONTENT.Rows[i + k + 4].Cells[0].Text = "&nbsp;" + ((int)(i + 1)).ToString();
				TBL_CONTENT.Rows[i + k + 4].Cells[0].HorizontalAlign = HorizontalAlign.Center;
				TBL_CONTENT.Rows[i + k + 4].Cells[0].CssClass= "ItemPrint_d";

				TBL_CONTENT.Rows[i + k + 4].Cells.Add(new TableCell());
				TBL_CONTENT.Rows[i + k + 4].Cells[1].Text = "&nbsp;";
				TBL_CONTENT.Rows[i + k + 4].Cells[1].HorizontalAlign = HorizontalAlign.Left;
				TBL_CONTENT.Rows[i + k + 4].Cells[1].CssClass= "ItemPrint_d";

				TBL_CONTENT.Rows[i + k + 4].Cells.Add(new TableCell());
				TBL_CONTENT.Rows[i + k + 4].Cells[2].Text = "&nbsp;" + Conn.GetFieldValue(i,"product_name");
				TBL_CONTENT.Rows[i + k + 4].Cells[2].HorizontalAlign = HorizontalAlign.Left;
				TBL_CONTENT.Rows[i + k + 4].Cells[2].CssClass= "ItemPrint_d";

				// BU
				//Baru
				tmp_val = (Double.Parse(Conn.GetFieldValue(i,"Lmt_Of_PB_BU")))/1000000;
				TBL_CONTENT.Rows[i + k + 4].Cells.Add(new TableCell());
				TBL_CONTENT.Rows[i + k + 4].Cells[3].Text = "&nbsp;" + tools.MoneyFormat(tmp_val.ToString()) + "&nbsp;";
				TBL_CONTENT.Rows[i + k + 4].Cells[3].HorizontalAlign = HorizontalAlign.Right;
				TBL_CONTENT.Rows[i + k + 4].Cells[3].CssClass= "ItemPrint_d";

				tmp_val = double.Parse(Conn.GetFieldValue(i,"Nbr_Of_PB_BU")) ;
				TBL_CONTENT.Rows[i + k + 4].Cells.Add(new TableCell());
				TBL_CONTENT.Rows[i + k + 4].Cells[4].Text = "&nbsp;" + tmp_val.ToString() + "&nbsp;";
				TBL_CONTENT.Rows[i + k + 4].Cells[4].HorizontalAlign = HorizontalAlign.Right;
				TBL_CONTENT.Rows[i + k + 4].Cells[4].CssClass= "ItemPrint_d";

			    //RN
				tmp_val = (double.Parse(Conn.GetFieldValue(i,"Lmt_Of_RN_BU").ToString()))/1000000;
				TBL_CONTENT.Rows[i + k + 4].Cells.Add(new TableCell());
				TBL_CONTENT.Rows[i + k + 4].Cells[5].Text = "&nbsp;" + tools.MoneyFormat(tmp_val.ToString()) + "&nbsp;";
				TBL_CONTENT.Rows[i + k + 4].Cells[5].HorizontalAlign = HorizontalAlign.Right;
				TBL_CONTENT.Rows[i + k + 4].Cells[5].CssClass= "ItemPrint_d";

				tmp_val = double.Parse(Conn.GetFieldValue(i,"Nbr_Of_RN_BU").ToString());
				TBL_CONTENT.Rows[i + k + 4].Cells.Add(new TableCell());
				TBL_CONTENT.Rows[i + k + 4].Cells[6].Text = "&nbsp;" + tmp_val.ToString() + "&nbsp;";
				TBL_CONTENT.Rows[i + k + 4].Cells[6].HorizontalAlign = HorizontalAlign.Right;
				TBL_CONTENT.Rows[i + k + 4].Cells[6].CssClass= "ItemPrint_d";
				
				//Lmt Change
				tmp_val = (double.Parse(Conn.GetFieldValue(i,"Lmt_Of_LmtChg_BU".ToString())))/1000000;
				TBL_CONTENT.Rows[i + k + 4].Cells.Add(new TableCell());
				TBL_CONTENT.Rows[i + k + 4].Cells[7].Text = "&nbsp;" + tools.MoneyFormat(tmp_val.ToString()) + "&nbsp;";
				TBL_CONTENT.Rows[i + k + 4].Cells[7].HorizontalAlign = HorizontalAlign.Right;
				TBL_CONTENT.Rows[i + k + 4].Cells[7].CssClass= "ItemPrint_d";
			
				tmp_val = double.Parse(Conn.GetFieldValue(i,"Nbr_Of_LmtChg_BU"));
				TBL_CONTENT.Rows[i + k + 4].Cells.Add(new TableCell());
				TBL_CONTENT.Rows[i + k + 4].Cells[8].Text = "&nbsp;" + tmp_val.ToString() + "&nbsp;";
				TBL_CONTENT.Rows[i + k + 4].Cells[8].HorizontalAlign = HorizontalAlign.Right;
				TBL_CONTENT.Rows[i + k + 4].Cells[8].CssClass= "ItemPrint_d";

				//CRM
				//Baru
				tmp_val = double.Parse(Conn.GetFieldValue(i,"Lmt_Of_PB_CRM"))/1000000;
				TBL_CONTENT.Rows[i + k + 4].Cells.Add(new TableCell());
				TBL_CONTENT.Rows[i + k + 4].Cells[9].Text = "&nbsp;" +  tools.MoneyFormat(tmp_val.ToString()) + "&nbsp;";
				TBL_CONTENT.Rows[i + k + 4].Cells[9].HorizontalAlign = HorizontalAlign.Right;
				TBL_CONTENT.Rows[i + k + 4].Cells[9].CssClass= "ItemPrint_d";

				tmp_val = double.Parse(Conn.GetFieldValue(i,"Nbr_Of_PB_CRM"));
				TBL_CONTENT.Rows[i + k + 4].Cells.Add(new TableCell());
				TBL_CONTENT.Rows[i + k + 4].Cells[10].Text = "&nbsp;" +  tmp_val.ToString() + "&nbsp;";
				TBL_CONTENT.Rows[i + k + 4].Cells[10].HorizontalAlign = HorizontalAlign.Right;
				TBL_CONTENT.Rows[i + k + 4].Cells[10].CssClass= "ItemPrint_d";

				//RN
				tmp_val = double.Parse(Conn.GetFieldValue(i,"Lmt_Of_RN_CRM").ToString())/1000000;
				TBL_CONTENT.Rows[i + k + 4].Cells.Add(new TableCell());
				TBL_CONTENT.Rows[i + k + 4].Cells[11].Text = "&nbsp;" +  tools.MoneyFormat(tmp_val.ToString())  + "&nbsp;";
				TBL_CONTENT.Rows[i + k + 4].Cells[11].HorizontalAlign = HorizontalAlign.Right;
				TBL_CONTENT.Rows[i + k + 4].Cells[11].CssClass= "ItemPrint_d";

				tmp_val = double.Parse(Conn.GetFieldValue(i,"Nbr_Of_RN_CRM").ToString());
				TBL_CONTENT.Rows[i + k + 4].Cells.Add(new TableCell());
				TBL_CONTENT.Rows[i + k + 4].Cells[12].Text = "&nbsp;" +  tmp_val.ToString() + "&nbsp;";
				TBL_CONTENT.Rows[i + k + 4].Cells[12].HorizontalAlign = HorizontalAlign.Right;
				TBL_CONTENT.Rows[i + k + 4].Cells[12].CssClass= "ItemPrint_d";

			    //Lmt Change
				tmp_val = double.Parse(Conn.GetFieldValue(i,"Lmt_Of_LmtChg_CRM"))/1000000;
				TBL_CONTENT.Rows[i + k + 4].Cells.Add(new TableCell());
				TBL_CONTENT.Rows[i + k + 4].Cells[13].Text = "&nbsp;" +  tools.MoneyFormat(tmp_val.ToString()) + "&nbsp;";
				TBL_CONTENT.Rows[i + k + 4].Cells[13].HorizontalAlign = HorizontalAlign.Right;
				TBL_CONTENT.Rows[i + k + 4].Cells[13].CssClass= "ItemPrint_d";

				tmp_val = double.Parse(Conn.GetFieldValue(i,"Nbr_Of_LmtChg_CRM"));
				TBL_CONTENT.Rows[i + k + 4].Cells.Add(new TableCell());
				TBL_CONTENT.Rows[i + k + 4].Cells[14].Text = "&nbsp;" +  tmp_val.ToString() + "&nbsp;";
				TBL_CONTENT.Rows[i + k + 4].Cells[14].HorizontalAlign = HorizontalAlign.Right;
				TBL_CONTENT.Rows[i + k + 4].Cells[14].CssClass= "ItemPrint_d";

			    //CO
				//Baru
				tmp_val = (double.Parse(Conn.GetFieldValue(i,"Lmt_Of_PB_CO")))/1000000;
				TBL_CONTENT.Rows[i + k + 4].Cells.Add(new TableCell());
				TBL_CONTENT.Rows[i + k + 4].Cells[15].Text = "&nbsp;" + tools.MoneyFormat(tmp_val.ToString()) + "&nbsp;";
				TBL_CONTENT.Rows[i + k + 4].Cells[15].HorizontalAlign = HorizontalAlign.Right;
				TBL_CONTENT.Rows[i + k + 4].Cells[15].CssClass= "ItemPrint_d";

				tmp_val = double.Parse(Conn.GetFieldValue(i,"Nbr_Of_PB_CO"));
				TBL_CONTENT.Rows[i + k + 4].Cells.Add(new TableCell());
				TBL_CONTENT.Rows[i + k + 4].Cells[16].Text = "&nbsp;" +  tmp_val.ToString() + "&nbsp;";
				TBL_CONTENT.Rows[i + k + 4].Cells[16].HorizontalAlign = HorizontalAlign.Right;
				TBL_CONTENT.Rows[i + k + 4].Cells[16].CssClass= "ItemPrint_d";

                //RN 
				tmp_val = (double.Parse(Conn.GetFieldValue(i,"Lmt_Of_RN_CO")))/1000000;
				TBL_CONTENT.Rows[i + k + 4].Cells.Add(new TableCell());
				TBL_CONTENT.Rows[i + k + 4].Cells[17].Text = "&nbsp;" + tools.MoneyFormat(tmp_val.ToString()) + "&nbsp;";
				TBL_CONTENT.Rows[i + k + 4].Cells[17].HorizontalAlign = HorizontalAlign.Right;
				TBL_CONTENT.Rows[i + k + 4].Cells[17].CssClass= "ItemPrint_d";

				tmp_val = double.Parse(Conn.GetFieldValue(i,"Nbr_Of_RN_CO"));
				TBL_CONTENT.Rows[i + k + 4].Cells.Add(new TableCell());
				TBL_CONTENT.Rows[i + k + 4].Cells[18].Text = "&nbsp;" +  tmp_val.ToString() + "&nbsp;";
				TBL_CONTENT.Rows[i + k + 4].Cells[18].HorizontalAlign = HorizontalAlign.Right;
				TBL_CONTENT.Rows[i + k + 4].Cells[18].CssClass= "ItemPrint_d";

				//Lmt Chg
				tmp_val = (double.Parse(Conn.GetFieldValue(i,"Lmt_Of_LmtChg_CO")))/1000000;
				TBL_CONTENT.Rows[i + k + 4].Cells.Add(new TableCell());
				TBL_CONTENT.Rows[i + k + 4].Cells[19].Text = "&nbsp;" + tools.MoneyFormat(tmp_val.ToString()) + "&nbsp;";
				TBL_CONTENT.Rows[i + k + 4].Cells[19].HorizontalAlign = HorizontalAlign.Right;
				TBL_CONTENT.Rows[i + k + 4].Cells[19].CssClass= "ItemPrint_d";

				tmp_val = double.Parse(Conn.GetFieldValue(i,"Nbr_Of_LmtChg_CO"));
				TBL_CONTENT.Rows[i + k + 4].Cells.Add(new TableCell());
				TBL_CONTENT.Rows[i + k + 4].Cells[20].Text = "&nbsp;test" +  tmp_val.ToString() + "&nbsp;";
				TBL_CONTENT.Rows[i + k + 4].Cells[20].HorizontalAlign = HorizontalAlign.Right;
				TBL_CONTENT.Rows[i + k + 4].Cells[20].CssClass= "ItemPrint_d";

                //Jumlah Dalam Proses
				//Baru
				tmp_val = (double.Parse(Conn.GetFieldValue(i,"Lmt_Of_PB_BU")) + double.Parse(Conn.GetFieldValue(i,"Lmt_Of_PB_CRM")) + double.Parse(Conn.GetFieldValue(i,"Lmt_Of_PB_CO")))/1000000;
				TBL_CONTENT.Rows[i + k + 4].Cells.Add(new TableCell());
				TBL_CONTENT.Rows[i + k + 4].Cells[21].Text = "&nbsp;" + tools.MoneyFormat(tmp_val.ToString()) + "&nbsp;";
				TBL_CONTENT.Rows[i + k + 4].Cells[21].HorizontalAlign = HorizontalAlign.Right;
				TBL_CONTENT.Rows[i + k + 4].Cells[21].CssClass= "ItemPrint_d";

				tmp_val = double.Parse(Conn.GetFieldValue(i,"Nbr_Of_PB_BU")) + double.Parse(Conn.GetFieldValue(i,"Nbr_Of_PB_CRM")) + double.Parse(Conn.GetFieldValue(i,"Nbr_Of_PB_CO")) ;
				TBL_CONTENT.Rows[i + k + 4].Cells.Add(new TableCell());
				TBL_CONTENT.Rows[i + k + 4].Cells[22].Text = "&nbsp;" + tmp_val.ToString() + "&nbsp;";
				TBL_CONTENT.Rows[i + k + 4].Cells[22].HorizontalAlign = HorizontalAlign.Right;
				TBL_CONTENT.Rows[i + k + 4].Cells[22].CssClass= "ItemPrint_d";

				//RN
				tmp_val = (double.Parse(Conn.GetFieldValue(i,"Lmt_Of_RN_BU")) + double.Parse(Conn.GetFieldValue(i,"Lmt_Of_RN_CRM")) + double.Parse(Conn.GetFieldValue(i,"Lmt_Of_RN_CO")))/1000000;
				TBL_CONTENT.Rows[i + k + 4].Cells.Add(new TableCell());
				TBL_CONTENT.Rows[i + k + 4].Cells[23].Text = "&nbsp;" + tools.MoneyFormat(tmp_val.ToString()) + "&nbsp;";
				TBL_CONTENT.Rows[i + k + 4].Cells[23].HorizontalAlign = HorizontalAlign.Right;
				TBL_CONTENT.Rows[i + k + 4].Cells[23].CssClass= "ItemPrint_d";

				tmp_val = double.Parse(Conn.GetFieldValue(i,"Nbr_Of_RN_BU")) + double.Parse(Conn.GetFieldValue(i,"Nbr_Of_RN_CRM")) + double.Parse(Conn.GetFieldValue(i,"Nbr_Of_RN_CO"));
				TBL_CONTENT.Rows[i + k + 4].Cells.Add(new TableCell());
				TBL_CONTENT.Rows[i + k + 4].Cells[24].Text = "&nbsp;" + tmp_val.ToString() + "&nbsp;";
				TBL_CONTENT.Rows[i + k + 4].Cells[24].HorizontalAlign = HorizontalAlign.Right;
				TBL_CONTENT.Rows[i + k + 4].Cells[24].CssClass= "ItemPrint_d";

				//Lmt Change
				tmp_val = (double.Parse(Conn.GetFieldValue(i,"Lmt_Of_LmtChg_BU")) + double.Parse(Conn.GetFieldValue(i,"Lmt_Of_LmtChg_CRM")) + double.Parse(Conn.GetFieldValue(i,"Lmt_Of_LmtChg_CO")))/1000000;
				TBL_CONTENT.Rows[i + k + 4].Cells.Add(new TableCell());
				TBL_CONTENT.Rows[i + k + 4].Cells[25].Text = "&nbsp;" + tools.MoneyFormat(tmp_val.ToString()) + "&nbsp;";
				TBL_CONTENT.Rows[i + k + 4].Cells[25].HorizontalAlign = HorizontalAlign.Right;
				TBL_CONTENT.Rows[i + k + 4].Cells[25].CssClass= "ItemPrint_d";

			    tmp_val = double.Parse(Conn.GetFieldValue(i,"Nbr_Of_LmtChg_BU")) + double.Parse(Conn.GetFieldValue(i,"Nbr_Of_LmtChg_CRM")) + double.Parse(Conn.GetFieldValue(i,"Nbr_Of_LmtChg_CO"));
				TBL_CONTENT.Rows[i + k + 4].Cells.Add(new TableCell());
				TBL_CONTENT.Rows[i + k + 4].Cells[26].Text = "&nbsp;" + tmp_val.ToString() + "&nbsp;";
				TBL_CONTENT.Rows[i + k + 4].Cells[26].HorizontalAlign = HorizontalAlign.Right;
				TBL_CONTENT.Rows[i + k + 4].Cells[26].CssClass= "ItemPrint_d";

                //Booking
				//Baru
			    tmp_val = (double.Parse(Conn.GetFieldValue(i,"Lmt_Of_PB_BU_BOOK")) +  double.Parse(Conn.GetFieldValue(i,"Lmt_Of_PB_CO_BOOK")) +  double.Parse(Conn.GetFieldValue(i,"Lmt_Of_PB_CRM_BOOK")) )/1000000;
				TBL_CONTENT.Rows[i + k + 4].Cells.Add(new TableCell());
				TBL_CONTENT.Rows[i + k + 4].Cells[27].Text = "&nbsp;" + tools.MoneyFormat(tmp_val.ToString()) + "&nbsp;";
				TBL_CONTENT.Rows[i + k + 4].Cells[27].HorizontalAlign = HorizontalAlign.Right;
				TBL_CONTENT.Rows[i + k + 4].Cells[27].CssClass= "ItemPrint_d";

				tmp_val = double.Parse(Conn.GetFieldValue(i,"Nbr_Of_PB_BU_BOOK")) +   double.Parse(Conn.GetFieldValue(i,"Nbr_Of_PB_CO_BOOK")) +  double.Parse(Conn.GetFieldValue(i,"Nbr_Of_PB_CRM_BOOK")) + 
				TBL_CONTENT.Rows[i + k + 4].Cells.Add(new TableCell());
				TBL_CONTENT.Rows[i + k + 4].Cells[28].Text = "&nbsp;" + tmp_val.ToString() + "&nbsp;";
				TBL_CONTENT.Rows[i + k + 4].Cells[28].HorizontalAlign = HorizontalAlign.Right;
				TBL_CONTENT.Rows[i + k + 4].Cells[28].CssClass= "ItemPrint_d";

				//RN
				tmp_val = (double.Parse(Conn.GetFieldValue(i,"Lmt_Of_RN_BU_BOOK")) +  double.Parse(Conn.GetFieldValue(i,"Lmt_Of_RN_CO_BOOK")) +  double.Parse(Conn.GetFieldValue(i,"Lmt_Of_RN_CRM_BOOK")))/1000000;
				TBL_CONTENT.Rows[i + k + 4].Cells.Add(new TableCell());
				TBL_CONTENT.Rows[i + k + 4].Cells[29].Text = "&nbsp;" + tools.MoneyFormat(tmp_val.ToString()) + "&nbsp;";
				TBL_CONTENT.Rows[i + k + 4].Cells[29].HorizontalAlign = HorizontalAlign.Right;
				TBL_CONTENT.Rows[i + k + 4].Cells[29].CssClass= "ItemPrint_d";

				tmp_val = double.Parse(Conn.GetFieldValue(i,"Nbr_Of_RN_BU_BOOK")) +  double.Parse(Conn.GetFieldValue(i,"Nbr_Of_RN_CO_BOOK")) +   double.Parse(Conn.GetFieldValue(i,"Nbr_Of_RN_CRM_BOOK"));
				TBL_CONTENT.Rows[i + k + 4].Cells.Add(new TableCell());
				TBL_CONTENT.Rows[i + k + 4].Cells[30].Text = "&nbsp;" + tmp_val.ToString() + "&nbsp;";
				TBL_CONTENT.Rows[i + k + 4].Cells[30].HorizontalAlign = HorizontalAlign.Right;
				TBL_CONTENT.Rows[i + k + 4].Cells[30].CssClass= "ItemPrint_d";

				//Lmt Change
				tmp_val = (double.Parse(Conn.GetFieldValue(i,"Lmt_Of_LmtChg_BU_BOOK")) + double.Parse(Conn.GetFieldValue(i,"Lmt_Of_LmtChg_CO_BOOK")) + double.Parse(Conn.GetFieldValue(i,"Lmt_Of_LmtChg_CRM_BOOK")))/1000000;
				TBL_CONTENT.Rows[i + k + 4].Cells.Add(new TableCell());
				TBL_CONTENT.Rows[i + k + 4].Cells[31].Text = "&nbsp;" + tools.MoneyFormat(tmp_val.ToString()) + "&nbsp;";
				TBL_CONTENT.Rows[i + k + 4].Cells[31].HorizontalAlign = HorizontalAlign.Right;
				TBL_CONTENT.Rows[i + k + 4].Cells[31].CssClass= "ItemPrint_d";
				
				tmp_val = double.Parse(Conn.GetFieldValue(i,"Nbr_Of_LmtChg_BU_BOOK")) + double.Parse(Conn.GetFieldValue(i,"Nbr_Of_LmtChg_CO_BOOK")) +  double.Parse(Conn.GetFieldValue(i,"Nbr_Of_LmtChg_CRM_BOOK"));
				TBL_CONTENT.Rows[i + k + 4].Cells.Add(new TableCell());
				TBL_CONTENT.Rows[i + k + 4].Cells[32].Text = "&nbsp;" + tmp_val.ToString() + "&nbsp;";
				TBL_CONTENT.Rows[i + k + 4].Cells[32].HorizontalAlign = HorizontalAlign.Right;
				TBL_CONTENT.Rows[i + k + 4].Cells[32].CssClass= "ItemPrint_d";

				/*
				tmp_val = (double.Parse(Conn.GetFieldValue(i,"Lmt_Of_LmtChg_BU_BOOK")) + double.Parse(Conn.GetFieldValue(i,"Lmt_Of_LmtChg_CO_BOOK")) + double.Parse(Conn.GetFieldValue(i,"Lmt_Of_LmtChg_CRM_BOOK")) +  double.Parse(Conn.GetFieldValue(i,"Lmt_Of_PB_BU_BOOK")) +  double.Parse(Conn.GetFieldValue(i,"Lmt_Of_PB_CO_BOOK")) +  double.Parse(Conn.GetFieldValue(i,"Lmt_Of_PB_CRM_BOOK")) +  double.Parse(Conn.GetFieldValue(i,"Lmt_Of_RN_BU_BOOK")) +  double.Parse(Conn.GetFieldValue(i,"Lmt_Of_RN_CO_BOOK")) +  double.Parse(Conn.GetFieldValue(i,"Lmt_Of_RN_CRM_BOOK")))/1000000;
				TBL_CONTENT.Rows[i + k + 3].Cells.Add(new TableCell());
				TBL_CONTENT.Rows[i + k + 3].Cells[11].Text = "&nbsp;" + tools.ConvertCurr(tools.ConvertNum(tmp_val.ToString()).ToString()) + "&nbsp;";
				TBL_CONTENT.Rows[i + k + 3].Cells[11].HorizontalAlign = HorizontalAlign.Right;
				TBL_CONTENT.Rows[i + k + 3].Cells[11].CssClass= "ItemPrint_d";

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
*/				
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
			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 4].Cells[1].HorizontalAlign = HorizontalAlign.Left;
			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 4].Cells[1].CssClass= "ItemPrint_d";

			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 4].Cells.Add(new TableCell());
			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 4].Cells[2].Text = "&nbsp;";
			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 4].Cells[2].HorizontalAlign = HorizontalAlign.Center;
			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 4].Cells[2].CssClass= "ItemPrint_d";

			sLmt_Of_PB_BU = (sLmt_Of_PB_BU/1000000);
			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 4].Cells.Add(new TableCell());
			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 4].Cells[3].Font.Bold=true; 
			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 4].Cells[3].Text = tools.MoneyFormat(sLmt_Of_PB_BU.ToString()) + "&nbsp;";
			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 4].Cells[3].HorizontalAlign = HorizontalAlign.Right;
			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 4].Cells[3].CssClass= "ItemPrint_d";

			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 4].Cells.Add(new TableCell());
			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 4].Cells[4].Font.Bold=true; 
			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 4].Cells[4].Text = "&nbsp;" + sNbr_Of_PB_BU.ToString() +  "&nbsp;";
			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 4].Cells[4].HorizontalAlign = HorizontalAlign.Right;
			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 4].Cells[4].CssClass= "ItemPrint_d";
				
			sLmt_Of_RN_BU = (sLmt_Of_RN_BU/1000000);
			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 4].Cells.Add(new TableCell());
			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 4].Cells[5].Font.Bold=true; 
			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 4].Cells[5].Text = "&nbsp;" + tools.MoneyFormat(sLmt_Of_RN_BU.ToString()) + "&nbsp;";
			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 4].Cells[5].HorizontalAlign = HorizontalAlign.Right;
			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 4].Cells[5].CssClass= "ItemPrint_d";

			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 4].Cells.Add(new TableCell());
			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 4].Cells[6].Font.Bold=true; 
			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 4].Cells[6].Text = "&nbsp;" +  sNbr_Of_RN_BU.ToString() + "&nbsp;";
			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 4].Cells[6].HorizontalAlign = HorizontalAlign.Right;
			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 4].Cells[6].CssClass= "ItemPrint_d";

			sLmt_Of_LmtChg_BU = (sLmt_Of_LmtChg_BU/1000000);
			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 4].Cells.Add(new TableCell());
			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 4].Cells[7].Font.Bold=true; 
			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 4].Cells[7].Text = "&nbsp;" + tools.MoneyFormat(sLmt_Of_LmtChg_BU.ToString())  + "&nbsp;";
			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 4].Cells[7].HorizontalAlign = HorizontalAlign.Right;
			TBL_CONTENT.Rows[Conn.GetRowCount()+ k + 4].Cells[7].CssClass= "ItemPrint_d";

			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 4].Cells.Add(new TableCell());
			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 4].Cells[8].Font.Bold=true; 
			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 4].Cells[8].Text = "&nbsp;" + sNbr_Of_LmtChg_BU.ToString() + "&nbsp;";
			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 4].Cells[8].HorizontalAlign = HorizontalAlign.Right;
			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 4].Cells[8].CssClass= "ItemPrint_d";

			sLmt_Of_PB_CRM = (sLmt_Of_PB_CRM / 1000000);
			TBL_CONTENT.Rows[Conn.GetRowCount()+ k + 4].Cells.Add(new TableCell());
			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 4].Cells[9].Font.Bold=true; 
			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 4].Cells[9].Text = "&nbsp;" + tools.MoneyFormat(sLmt_Of_PB_CRM.ToString()) + "&nbsp;";
			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 4].Cells[9].HorizontalAlign = HorizontalAlign.Right;
			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 4].Cells[9].CssClass= "ItemPrint_d";

			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 4].Cells.Add(new TableCell());
			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 4].Cells[10].Font.Bold=true; 
			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 4].Cells[10].Text = "&nbsp;" + sNbr_Of_PB_CRM.ToString() + "&nbsp;";
			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 4].Cells[10].HorizontalAlign = HorizontalAlign.Right;
			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 4].Cells[10].CssClass= "ItemPrint_d";

			sLmt_Of_RN_CRM = (sLmt_Of_RN_CRM/1000000);
			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 4].Cells.Add(new TableCell());
			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 4].Cells[11].Font.Bold=true; 
			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 4].Cells[11].Text = "&nbsp;" + tools.MoneyFormat(sLmt_Of_RN_CRM.ToString()) + "&nbsp;";
			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 4].Cells[11].HorizontalAlign = HorizontalAlign.Right;
			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 4].Cells[11].CssClass= "ItemPrint_d";

			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 4].Cells.Add(new TableCell());
			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 4].Cells[12].Font.Bold=true; 
			TBL_CONTENT.Rows[Conn.GetRowCount()+ k + 4].Cells[12].Text = "&nbsp;" + sNbr_Of_RN_CRM.ToString() + "&nbsp;";
			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 4].Cells[12].HorizontalAlign = HorizontalAlign.Right;
			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 4].Cells[12].CssClass= "ItemPrint_d";

			sLmt_Of_LmtChg_CRM = (sLmt_Of_LmtChg_CRM/1000000);
			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 4].Cells.Add(new TableCell());
			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 4].Cells[13].Font.Bold=true; 
			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 4].Cells[13].Text = "&nbsp;" + tools.MoneyFormat(sLmt_Of_LmtChg_CRM.ToString()) + "&nbsp;";
			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 4].Cells[13].HorizontalAlign = HorizontalAlign.Right;
			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 4].Cells[13].CssClass= "ItemPrint_d";

			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 4].Cells.Add(new TableCell());
			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 4].Cells[14].Font.Bold=true; 
			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 4].Cells[14].Text = "&nbsp;" + sNbr_Of_LmtChg_CRM.ToString() + "&nbsp;";
			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 4].Cells[14].HorizontalAlign = HorizontalAlign.Right;
			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 4].Cells[14].CssClass= "ItemPrint_d";
							
			sLmt_Of_PB_CO = (sLmt_Of_PB_CO/1000000);
			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 4].Cells.Add(new TableCell());
			TBL_CONTENT.Rows[Conn.GetRowCount()+ k + 4].Cells[15].Font.Bold=true; 
			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 4].Cells[15].Text = "&nbsp;" + tools.MoneyFormat(sLmt_Of_PB_CO.ToString()) + "&nbsp;";
			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 4].Cells[15].HorizontalAlign = HorizontalAlign.Right;
			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 4].Cells[15].CssClass= "ItemPrint_d";
							
			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 4].Cells.Add(new TableCell());
			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 4].Cells[16].Font.Bold=true; 
			TBL_CONTENT.Rows[Conn.GetRowCount()+ k + 4].Cells[16].Text = "&nbsp;" + sNbr_Of_PB_CO.ToString() + "&nbsp;";
			TBL_CONTENT.Rows[Conn.GetRowCount()+ k + 4].Cells[16].HorizontalAlign = HorizontalAlign.Right;
			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 4].Cells[16].CssClass= "ItemPrint_d";
								
			sLmt_Of_RN_CO = (sLmt_Of_RN_CO /1000000);
			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 4].Cells.Add(new TableCell());
			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 4].Cells[17].Font.Bold=true; 
			TBL_CONTENT.Rows[Conn.GetRowCount()+ k + 4].Cells[17].Text = "&nbsp;" + tools.MoneyFormat(sLmt_Of_RN_CO.ToString()) + "&nbsp;";
			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 4].Cells[17].HorizontalAlign = HorizontalAlign.Right;
			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 4].Cells[17].CssClass= "ItemPrint_d";
                        
			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 4].Cells.Add(new TableCell());
			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 4].Cells[18].Font.Bold=true; 
			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 4].Cells[18].Text = "&nbsp;" + sNbr_Of_RN_CO.ToString() + "&nbsp;";
			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 4].Cells[18].HorizontalAlign = HorizontalAlign.Right;
			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 4].Cells[18].CssClass= "ItemPrint_d";
								
			sLmt_Of_LmtChg_CO = (sLmt_Of_LmtChg_CO / 1000000);
			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 4].Cells.Add(new TableCell());
			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 4].Cells[19].Font.Bold=true; 
			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 4].Cells[19].Text = "&nbsp;" + tools.MoneyFormat(sLmt_Of_LmtChg_CO.ToString()) + "&nbsp;";
			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 4].Cells[19].HorizontalAlign = HorizontalAlign.Right;
			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 4].Cells[19].CssClass= "ItemPrint_d";
									
			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 4].Cells.Add(new TableCell());
			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 4].Cells[20].Font.Bold=true; 
			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 4].Cells[20].Text = "&nbsp;" + sNbr_Of_LmtChg_CO.ToString() + "&nbsp;";
			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 4].Cells[20].HorizontalAlign = HorizontalAlign.Right;
			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 4].Cells[20].CssClass= "ItemPrint_d";
										
			sLmt_PB_Proc = (sLmt_PB_Proc/1000000);
			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 4].Cells.Add(new TableCell());
			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 4].Cells[21].Font.Bold=true; 
			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 4].Cells[21].Text = "&nbsp;" + tools.MoneyFormat(sLmt_PB_Proc.ToString()) + "&nbsp;";
			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 4].Cells[21].HorizontalAlign = HorizontalAlign.Right;
			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 4].Cells[21].CssClass= "ItemPrint_d";
										
			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 4].Cells.Add(new TableCell());
			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 4].Cells[22].Font.Bold=true; 
			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 4].Cells[22].Text = "&nbsp;" + sNbr_PB_Proc.ToString() + "&nbsp;";
			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 4].Cells[22].HorizontalAlign = HorizontalAlign.Right;
			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 4].Cells[22].CssClass= "ItemPrint_d";
											
			sLmt_RN_Proc = (sLmt_RN_Proc / 1000000);
			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 4].Cells.Add(new TableCell());
			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 4].Cells[23].Font.Bold=true; 
			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 4].Cells[23].Text = "&nbsp;" + tools.MoneyFormat(sLmt_RN_Proc.ToString()) + "&nbsp;";
			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 4].Cells[23].HorizontalAlign = HorizontalAlign.Right;
			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 4].Cells[23].CssClass= "ItemPrint_d";
											
			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 4].Cells.Add(new TableCell());
			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 4].Cells[24].Font.Bold=true; 
			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 4].Cells[24].Text = "&nbsp;" + sNbr_RN_Proc.ToString() + "&nbsp;";
			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 4].Cells[24].HorizontalAlign = HorizontalAlign.Right;
			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 4].Cells[24].CssClass= "ItemPrint_d";
												
			sLmt_LmtChg_Proc = (sLmt_LmtChg_Proc / 1000000);
			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 4].Cells.Add(new TableCell());
			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 4].Cells[25].Font.Bold=true; 
			TBL_CONTENT.Rows[Conn.GetRowCount()+ k + 4].Cells[25].Text = "&nbsp;" + tools.MoneyFormat(sLmt_LmtChg_Proc.ToString()) + "&nbsp;";
			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 4].Cells[25].Text = "&nbsp;" + sLmt_LmtChg_Proc.ToString() + "&nbsp;";
			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 4].Cells[25].HorizontalAlign = HorizontalAlign.Right;
			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 4].Cells[25].CssClass= "ItemPrint_d";
												
			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 4].Cells.Add(new TableCell());
			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 4].Cells[26].Font.Bold=true; 
			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 4].Cells[26].Text = "&nbsp;" + sNbr_LmtChg_Proc.ToString() + "&nbsp;";
			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 4].Cells[26].HorizontalAlign = HorizontalAlign.Right;
			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 4].Cells[26].CssClass= "ItemPrint_d";
													
			sLmt_Lmt_PB_Book = (sLmt_Lmt_PB_Book / 1000000);
			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 4].Cells.Add(new TableCell());
			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 4].Cells[27].Font.Bold=true; 
			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 4].Cells[27].Text = "&nbsp;" + tools.MoneyFormat(sLmt_Lmt_PB_Book.ToString()) + "&nbsp;";
			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 4].Cells[27].HorizontalAlign = HorizontalAlign.Right;
			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 4].Cells[27].CssClass= "ItemPrint_d";
													
			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 4].Cells.Add(new TableCell());
			TBL_CONTENT.Rows[Conn.GetRowCount()+ k + 4].Cells[28].Font.Bold=true; 
			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 4].Cells[28].Text = "&nbsp;" + sNbr_Lmt_PB_Book.ToString() + "&nbsp;";
			TBL_CONTENT.Rows[Conn.GetRowCount()+ k + 4].Cells[28].HorizontalAlign = HorizontalAlign.Right;
			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 4].Cells[28].CssClass= "ItemPrint_d";
														
			sLmt_Lmt_RN_Book = (sLmt_Lmt_RN_Book / 1000000);
			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 4].Cells.Add(new TableCell());
			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 4].Cells[29].Font.Bold=true; 
			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 4].Cells[29].Text = "&nbsp;" + tools.MoneyFormat(sLmt_Lmt_RN_Book.ToString()) + "&nbsp;";
			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 4].Cells[29].HorizontalAlign = HorizontalAlign.Right;
			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 4].Cells[29].CssClass= "ItemPrint_d";
														
			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 4].Cells.Add(new TableCell());
			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 4].Cells[30].Font.Bold=true; 
			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 4].Cells[30].Text = "&nbsp;" + sNbr_Lmt_RN_Book.ToString() + "&nbsp;";
			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 4].Cells[30].HorizontalAlign = HorizontalAlign.Right;
			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 4].Cells[30].CssClass= "ItemPrint_d";
															
			sLmt_Lmt_LmtChg_Book = (sLmt_Lmt_LmtChg_Book / 1000000);
			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 4].Cells.Add(new TableCell());
			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 4].Cells[31].Font.Bold=true; 
			TBL_CONTENT.Rows[Conn.GetRowCount()+ k + 4].Cells[31].Text = "&nbsp;" + tools.MoneyFormat(sLmt_Lmt_LmtChg_Book.ToString()) + "&nbsp;";
			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 4].Cells[31].HorizontalAlign = HorizontalAlign.Right;
			TBL_CONTENT.Rows[Conn.GetRowCount()+ k + 4].Cells[31].CssClass= "ItemPrint_d";
															
			TBL_CONTENT.Rows[Conn.GetRowCount()+ k + 4].Cells.Add(new TableCell());
			TBL_CONTENT.Rows[Conn.GetRowCount()+ k + 4].Cells[32].Font.Bold=true; 
			TBL_CONTENT.Rows[Conn.GetRowCount() + k + 4].Cells[32].Text = "&nbsp;" + sNbr_Lmt_LmtChg_Book.ToString() + "&nbsp;";
			TBL_CONTENT.Rows[Conn.GetRowCount()+ k + 4].Cells[32].HorizontalAlign = HorizontalAlign.Right;
			TBL_CONTENT.Rows[Conn.GetRowCount()+ k + 4].Cells[32].CssClass= "ItemPrint_d";
			//Sub total
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
