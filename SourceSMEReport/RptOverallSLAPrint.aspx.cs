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
	/// Summary description for RptOverallSLAPrint.
	/// </summary>
	public partial class RptOverallSLAPrint : System.Web.UI.Page
	{
		protected Connection Conn = new Connection();
        protected Tools tools = new Tools();
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			Conn = (Connection) Session["Connection"];
			string sql_kondisi = Request.QueryString["sql_kondisi"];
			string Start_Date = Request.QueryString["Start_Date"];
			string End_Date = Request.QueryString["End_Date"];
			string area = Request.QueryString["area"];
			string cbc = Request.QueryString["cbc"];
			string branch = Request.QueryString["branch"];
			string rm = Request.QueryString["rm"];
			string teamleader = Request.QueryString["teamleader"];
			string program = Request.QueryString["program"];
			Load_Data(sql_kondisi, Start_Date, End_Date, area, cbc, branch, rm, teamleader, program);
		}

		private void Load_Data(string sql_kondisi, string Start_Date, string End_Date, string area, string cbc, string branch, string rm, string teamleader, string program)
		{
			//string branchname="", teamleadername="", programname=""; 
			LBL_PERIODE.Text = tools.FormatDate(Start_Date, false) + " TO " + tools.FormatDate(End_Date, false);

			if(!area.Equals(""))
			{
				Conn.QueryString = "select areaname from rfarea where areaid='" + area + "' ";
				Conn.ExecuteQuery();
				if (Conn.GetRowCount()>0)
				{
					LBL_CBC.Text = Conn.GetFieldValue(0,"areaname");
				}
			}
			else
			{
				this.LBL_CBC.Text = "All Region";
			}

			if(!cbc.Equals(""))
			{
				Conn.QueryString = "select distinct  branch_name  from rfbranch where branch_code ='" + cbc + "'";
				Conn.ExecuteQuery();
				if (Conn.GetRowCount()>0)
				{
                   LBL_CBC.Text= Conn.GetFieldValue(0,"branch_name");
				}
			}
			else
			{
				LBL_CBC.Text = "All CBC";
			}

			if(!branch.Equals(""))
			{
				Conn.QueryString = "select distinct  branch_name  from rfbranch where branch_code ='" + branch + "'";
				Conn.ExecuteQuery();
				if (Conn.GetRowCount()>0)
				{
					LBL_BRANCH.Text  = Conn.GetFieldValue(0,"branch_name");
				}
			}
			else
			{
				LBL_BRANCH.Text = "All Branch";
			}

			if(!program.Equals(""))
			{
				Conn.QueryString = "select programdesc from rfprogram where programid='" + program + "'";
				Conn.ExecuteQuery();
				if (Conn.GetRowCount()>0)
				{
					LBL_PROGRAM.Text = Conn.GetFieldValue(0,"programdesc");
				}
			}
			else
			{
				LBL_PROGRAM.Text = "All";
			}       


			if(!teamleader.Equals(""))
			{
				Conn.QueryString = "select su_fullname from scuser where userid='" + teamleader + "' ";
				Conn.ExecuteQuery();
				if (Conn.GetRowCount()>0)
				{
					LBL_TEAM.Text = Conn.GetFieldValue(0,"su_fullname");
				}
			}
			else
			{
				LBL_TEAM.Text = "ALL";
			}            
                  
			
			if(!rm.Equals(""))
			{
				Conn.QueryString = "select su_fullname from scuser where userid='" + rm + "' ";
				Conn.ExecuteQuery();
				if (Conn.GetRowCount()>0)
				{
					LBL_RM.Text = Conn.GetFieldValue(0,"su_fullname");
				}
			}
			else
			{
				LBL_RM.Text = "All";
			}       

			Conn.QueryString = "exec Rpt_OverallSLA '" + sql_kondisi + "'";
			Conn.ExecuteQuery(1800);
			string pre_apregno = "", pre_applicantname="";
			int k = 0;

			for (int i = 0; i < Conn.GetRowCount(); i++)
			{
				if(pre_apregno.ToString()!=Conn.GetFieldValue(i,"ap_regno"))
				{
					k += 1; 
					pre_apregno = Conn.GetFieldValue(i,"ap_regno");
					TBL_CONTENT.Rows.Add(new TableRow());
					TBL_CONTENT.Rows[i + k + 3].Cells.Add(new TableCell());
					TBL_CONTENT.Rows[i + k + 3].Cells[0].Text = "&nbsp;" + pre_apregno.ToString();
					TBL_CONTENT.Rows[i + k + 3].Cells[0].HorizontalAlign = HorizontalAlign.Center;
					TBL_CONTENT.Rows[i + k + 3].Cells[0].CssClass= "ItemPrint_d";

					if (pre_applicantname.ToString()!=Conn.GetFieldValue(i,"Customer_Name"))
					{
						pre_applicantname=Conn.GetFieldValue(i,"Customer_Name");
						TBL_CONTENT.Rows[i + k + 3].Cells.Add(new TableCell());
						TBL_CONTENT.Rows[i + k + 3].Cells[1].Text = pre_applicantname.ToString();
						TBL_CONTENT.Rows[i + k + 3].Cells[1].HorizontalAlign = HorizontalAlign.Left;
						TBL_CONTENT.Rows[i + k + 3].Cells[1].CssClass= "ItemPrint_d";
					}
				}
				else
				{
					if (pre_applicantname.ToString()!=Conn.GetFieldValue(i,"Customer_Name"))
					{
					    k += 1; 
						pre_apregno = Conn.GetFieldValue(i,"ap_regno");
						TBL_CONTENT.Rows.Add(new TableRow());
						TBL_CONTENT.Rows[i + k + 3].Cells.Add(new TableCell());
						TBL_CONTENT.Rows[i + k + 3].Cells[0].Text = "&nbsp;";
						TBL_CONTENT.Rows[i + k + 3].Cells[0].HorizontalAlign = HorizontalAlign.Center;
						TBL_CONTENT.Rows[i + k + 3].Cells[0].CssClass= "ItemPrint_d";

						pre_applicantname =Conn.GetFieldValue(i,"Customer_Name");
						TBL_CONTENT.Rows[i + k + 3].Cells.Add(new TableCell());
						TBL_CONTENT.Rows[i + k + 3].Cells[1].Text = pre_applicantname.ToString();
						TBL_CONTENT.Rows[i + k + 3].Cells[1].HorizontalAlign = HorizontalAlign.Left;
						TBL_CONTENT.Rows[i + k + 3].Cells[1].CssClass= "ItemPrint_d";
					}
				}

				TBL_CONTENT.Rows.Add(new TableRow());
				TBL_CONTENT.Rows[i + k + 3].Cells.Add(new TableCell());
				TBL_CONTENT.Rows[i + k + 3].Cells[0].Text = ((int)(i + 1)).ToString();
				TBL_CONTENT.Rows[i + k + 3].Cells[0].HorizontalAlign = HorizontalAlign.Center;
				TBL_CONTENT.Rows[i + k + 3].Cells[0].CssClass= "ItemPrint_d";

				TBL_CONTENT.Rows[i + k + 3].Cells.Add(new TableCell());
				TBL_CONTENT.Rows[i + k + 3].Cells[1].Text = "&nbsp;";
				TBL_CONTENT.Rows[i + k + 3].Cells[1].HorizontalAlign = HorizontalAlign.Left;
				TBL_CONTENT.Rows[i + k + 3].Cells[1].CssClass= "ItemPrint_d";

				TBL_CONTENT.Rows[i + k + 3].Cells.Add(new TableCell());
				TBL_CONTENT.Rows[i + k + 3].Cells[2].Text = "&nbsp;";
				TBL_CONTENT.Rows[i + k + 3].Cells[2].HorizontalAlign = HorizontalAlign.Left;
				TBL_CONTENT.Rows[i + k + 3].Cells[2].CssClass= "ItemPrint_d";

				TBL_CONTENT.Rows[i + k + 3].Cells.Add(new TableCell());
				TBL_CONTENT.Rows[i + k + 3].Cells[3].Text = Conn.GetFieldValue(i,"Program");
				TBL_CONTENT.Rows[i + k + 3].Cells[3].HorizontalAlign = HorizontalAlign.Left;
				TBL_CONTENT.Rows[i + k + 3].Cells[3].CssClass= "ItemPrint_d";

				TBL_CONTENT.Rows[i + k + 3].Cells.Add(new TableCell());
				TBL_CONTENT.Rows[i + k + 3].Cells[4].Text = Conn.GetFieldValue(i,"product_name");
				TBL_CONTENT.Rows[i + k + 3].Cells[4].HorizontalAlign = HorizontalAlign.Left;
				TBL_CONTENT.Rows[i + k + 3].Cells[4].CssClass= "ItemPrint_d";

				TBL_CONTENT.Rows[i + k + 3].Cells.Add(new TableCell());
				TBL_CONTENT.Rows[i + k + 3].Cells[5].Text = Conn.GetFieldValue(i,"Limit");
				TBL_CONTENT.Rows[i + k + 3].Cells[5].HorizontalAlign = HorizontalAlign.Left;
				TBL_CONTENT.Rows[i + k + 3].Cells[5].CssClass= "ItemPrint_d";

				TBL_CONTENT.Rows[i + k + 3].Cells.Add(new TableCell());
				TBL_CONTENT.Rows[i + k + 3].Cells[6].Text = Conn.GetFieldValue(i,"TgApplikasi");
				TBL_CONTENT.Rows[i + k + 3].Cells[6].HorizontalAlign = HorizontalAlign.Left;
				TBL_CONTENT.Rows[i + k + 3].Cells[6].CssClass= "ItemPrint_d";

				TBL_CONTENT.Rows[i + k + 3].Cells.Add(new TableCell());
				TBL_CONTENT.Rows[i + k + 3].Cells[7].Text = Conn.GetFieldValue(i,"IDEStartdate");
				TBL_CONTENT.Rows[i + k + 3].Cells[7].HorizontalAlign = HorizontalAlign.Left;
				TBL_CONTENT.Rows[i + k + 3].Cells[7].CssClass= "ItemPrint_d";

				TBL_CONTENT.Rows[i + k + 3].Cells.Add(new TableCell());
				TBL_CONTENT.Rows[i + k + 3].Cells[8].Text = Conn.GetFieldValue(i,"DTBO");
				TBL_CONTENT.Rows[i + k + 3].Cells[8].HorizontalAlign = HorizontalAlign.Left;
				TBL_CONTENT.Rows[i + k + 3].Cells[8].CssClass= "ItemPrint_d";

				TBL_CONTENT.Rows[i + k + 3].Cells.Add(new TableCell());
				TBL_CONTENT.Rows[i + k + 3].Cells[9].Text = Conn.GetFieldValue(i,"DDE");
				TBL_CONTENT.Rows[i + k + 3].Cells[9].HorizontalAlign = HorizontalAlign.Left;
				TBL_CONTENT.Rows[i + k + 3].Cells[9].CssClass= "ItemPrint_d";

				TBL_CONTENT.Rows[i + k + 3].Cells.Add(new TableCell());
				TBL_CONTENT.Rows[i + k + 3].Cells[10].Text = Conn.GetFieldValue(i,"VA");
				TBL_CONTENT.Rows[i + k + 3].Cells[10].HorizontalAlign = HorizontalAlign.Left;
				TBL_CONTENT.Rows[i + k + 3].Cells[10].CssClass= "ItemPrint_d";

				TBL_CONTENT.Rows[i + k + 3].Cells.Add(new TableCell());
				TBL_CONTENT.Rows[i + k + 3].Cells[11].Text = Conn.GetFieldValue(i,"CA");
				TBL_CONTENT.Rows[i + k + 3].Cells[11].HorizontalAlign = HorizontalAlign.Left;
				TBL_CONTENT.Rows[i + k + 3].Cells[11].CssClass= "ItemPrint_d";

				TBL_CONTENT.Rows[i + k + 3].Cells.Add(new TableCell());
				TBL_CONTENT.Rows[i + k + 3].Cells[12].Text = Conn.GetFieldValue(i,"FS");
				TBL_CONTENT.Rows[i + k + 3].Cells[12].HorizontalAlign = HorizontalAlign.Left;
				TBL_CONTENT.Rows[i + k + 3].Cells[12].CssClass= "ItemPrint_d";

				TBL_CONTENT.Rows[i + k + 3].Cells.Add(new TableCell());
				TBL_CONTENT.Rows[i + k + 3].Cells[12].Text = Conn.GetFieldValue(i,"CP");
				TBL_CONTENT.Rows[i + k + 3].Cells[12].HorizontalAlign = HorizontalAlign.Left;
				TBL_CONTENT.Rows[i + k + 3].Cells[12].CssClass= "ItemPrint_d";

				TBL_CONTENT.Rows[i + k + 3].Cells.Add(new TableCell());
				TBL_CONTENT.Rows[i + k + 3].Cells[13].Text = Conn.GetFieldValue(i,"ttlappr");
				TBL_CONTENT.Rows[i + k + 3].Cells[13].HorizontalAlign = HorizontalAlign.Left;
				TBL_CONTENT.Rows[i + k + 3].Cells[13].CssClass= "ItemPrint_d";

				TBL_CONTENT.Rows[i + k + 3].Cells.Add(new TableCell());
				TBL_CONTENT.Rows[i + k + 3].Cells[14].Text = Conn.GetFieldValue(i,"tCBCappr");
				TBL_CONTENT.Rows[i + k + 3].Cells[14].HorizontalAlign = HorizontalAlign.Left;
				TBL_CONTENT.Rows[i + k + 3].Cells[14].CssClass= "ItemPrint_d";

				TBL_CONTENT.Rows[i + k + 3].Cells.Add(new TableCell());
				TBL_CONTENT.Rows[i + k + 3].Cells[15].Text = Conn.GetFieldValue(i,"tGHAppr");
				TBL_CONTENT.Rows[i + k + 3].Cells[15].HorizontalAlign = HorizontalAlign.Left;
				TBL_CONTENT.Rows[i + k + 3].Cells[15].CssClass= "ItemPrint_d";

				TBL_CONTENT.Rows[i + k + 3].Cells.Add(new TableCell());
				TBL_CONTENT.Rows[i + k + 3].Cells[16].Text = Conn.GetFieldValue(i,"SLA_BU_VA_TO_APPR");
				TBL_CONTENT.Rows[i + k + 3].Cells[16].HorizontalAlign = HorizontalAlign.Left;
				TBL_CONTENT.Rows[i + k + 3].Cells[16].CssClass= "ItemPrint_d";

				TBL_CONTENT.Rows[i + k + 3].Cells.Add(new TableCell());
				TBL_CONTENT.Rows[i + k + 3].Cells[17].Text = Conn.GetFieldValue(i,"LastCRMApproval");
				TBL_CONTENT.Rows[i + k + 3].Cells[17].HorizontalAlign = HorizontalAlign.Left;
				TBL_CONTENT.Rows[i + k + 3].Cells[17].CssClass= "ItemPrint_d";

				TBL_CONTENT.Rows[i + k + 3].Cells.Add(new TableCell());
				TBL_CONTENT.Rows[i + k + 3].Cells[18].Text = Conn.GetFieldValue(i,"tPRRK");
				TBL_CONTENT.Rows[i + k + 3].Cells[18].HorizontalAlign = HorizontalAlign.Left;
				TBL_CONTENT.Rows[i + k + 3].Cells[18].CssClass= "ItemPrint_d";
				
				TBL_CONTENT.Rows[i + k + 3].Cells.Add(new TableCell());
				TBL_CONTENT.Rows[i + k + 3].Cells[19].Text = Conn.GetFieldValue(i,"SLA_CRM_BUAPPR_TO_CRMAPPR");
				TBL_CONTENT.Rows[i + k + 3].Cells[19].HorizontalAlign = HorizontalAlign.Left;
				TBL_CONTENT.Rows[i + k + 3].Cells[19].CssClass= "ItemPrint_d";

				TBL_CONTENT.Rows[i + k + 3].Cells.Add(new TableCell());
				TBL_CONTENT.Rows[i + k + 3].Cells[20].Text = Conn.GetFieldValue(i,"BI_Entry");
				TBL_CONTENT.Rows[i + k + 3].Cells[20].HorizontalAlign = HorizontalAlign.Left;
				TBL_CONTENT.Rows[i + k + 3].Cells[20].CssClass= "ItemPrint_d";

				TBL_CONTENT.Rows[i + k + 3].Cells.Add(new TableCell());
				TBL_CONTENT.Rows[i + k + 3].Cells[21].Text = Conn.GetFieldValue(i,"tApprEntry");
				TBL_CONTENT.Rows[i + k + 3].Cells[21].HorizontalAlign = HorizontalAlign.Left;
				TBL_CONTENT.Rows[i + k + 3].Cells[21].CssClass= "ItemPrint_d";

				TBL_CONTENT.Rows[i + k + 3].Cells.Add(new TableCell());
				TBL_CONTENT.Rows[i + k + 3].Cells[22].Text = Conn.GetFieldValue(i,"tLSC");
				TBL_CONTENT.Rows[i + k + 3].Cells[22].HorizontalAlign = HorizontalAlign.Left;
				TBL_CONTENT.Rows[i + k + 3].Cells[22].CssClass= "ItemPrint_d";

				TBL_CONTENT.Rows[i + k + 3].Cells.Add(new TableCell());
				TBL_CONTENT.Rows[i + k + 3].Cells[23].Text = Conn.GetFieldValue(i,"tAssNtr");
				TBL_CONTENT.Rows[i + k + 3].Cells[23].HorizontalAlign = HorizontalAlign.Left;
				TBL_CONTENT.Rows[i + k + 3].Cells[23].CssClass= "ItemPrint_d";

				TBL_CONTENT.Rows[i + k + 3].Cells.Add(new TableCell());
				TBL_CONTENT.Rows[i + k + 3].Cells[24].Text = Conn.GetFieldValue(i,"tDisbursCk");
				TBL_CONTENT.Rows[i + k + 3].Cells[24].HorizontalAlign = HorizontalAlign.Left;
				TBL_CONTENT.Rows[i + k + 3].Cells[24].CssClass= "ItemPrint_d";
				
				TBL_CONTENT.Rows[i + k + 3].Cells.Add(new TableCell());
				TBL_CONTENT.Rows[i + k + 3].Cells[25].Text = Conn.GetFieldValue(i,"tBook");
				TBL_CONTENT.Rows[i + k + 3].Cells[25].HorizontalAlign = HorizontalAlign.Left;
				TBL_CONTENT.Rows[i + k + 3].Cells[25].CssClass= "ItemPrint_d";
			
				TBL_CONTENT.Rows[i + k + 3].Cells.Add(new TableCell());
				TBL_CONTENT.Rows[i + k + 3].Cells[26].Text = Conn.GetFieldValue(i,"tSPPKLtr");
				TBL_CONTENT.Rows[i + k + 3].Cells[26].HorizontalAlign = HorizontalAlign.Left;
				TBL_CONTENT.Rows[i + k + 3].Cells[26].CssClass= "ItemPrint_d";

				TBL_CONTENT.Rows[i + k + 3].Cells.Add(new TableCell());
				TBL_CONTENT.Rows[i + k + 3].Cells[27].Text = Conn.GetFieldValue(i,"tSPPKConf");
				TBL_CONTENT.Rows[i + k + 3].Cells[27].HorizontalAlign = HorizontalAlign.Left;
				TBL_CONTENT.Rows[i + k + 3].Cells[27].CssClass= "ItemPrint_d";

			    TBL_CONTENT.Rows[i + k + 3].Cells.Add(new TableCell());
				TBL_CONTENT.Rows[i + k + 3].Cells[28].Text = Conn.GetFieldValue(i,"SLA_CO");
				TBL_CONTENT.Rows[i + k + 3].Cells[28].HorizontalAlign = HorizontalAlign.Left;
				TBL_CONTENT.Rows[i + k + 3].Cells[28].CssClass= "ItemPrint_d";
				
				TBL_CONTENT.Rows[i + k + 3].Cells.Add(new TableCell());
				TBL_CONTENT.Rows[i + k + 3].Cells[29].Text = Conn.GetFieldValue(i,"Limit");
				TBL_CONTENT.Rows[i + k + 3].Cells[29].HorizontalAlign = HorizontalAlign.Left;
				TBL_CONTENT.Rows[i + k + 3].Cells[29].CssClass= "ItemPrint_d";

			
				string temp_val = "";
				if (Conn.GetFieldValue(i,"cp_limitdisbursed").ToString()=="")
				{temp_val="0";}
				else
				{temp_val=Conn.GetFieldValue(i,"cp_limitdisbursed").ToString();}
			
				TBL_CONTENT.Rows[i + k + 3].Cells.Add(new TableCell());
				TBL_CONTENT.Rows[i + k + 3].Cells[30].Text = tools.MoneyFormat(temp_val).ToString() + "&nbsp;";
				TBL_CONTENT.Rows[i + k + 3].Cells[30].HorizontalAlign = HorizontalAlign.Right;
				TBL_CONTENT.Rows[i + k + 3].Cells[30].CssClass= "ItemPrint_d";
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
