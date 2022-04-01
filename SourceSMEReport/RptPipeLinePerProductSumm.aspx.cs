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
using System.Web.Configuration;
using Microsoft.Reporting.WebForms;
using System.Collections.Generic;
using System.Net;
using SME.SourceSMEReport;

namespace SME.SourceSMEReport
{
	/// <summary>
	/// Summary description for RptPipeLinePerProductSumm.
	/// </summary>
	public partial class RptPipeLinePerProductSumm : System.Web.UI.Page
	{
		protected Connection Conn = new Connection();
		protected Tools tools = new Tools();
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			Conn = (Connection) Session["Connection"];

			
			if (!IsPostBack)
			{
				LBL_BU.Text = Request.QueryString["BU"];
				Label1.Text = Posisi_User().ToString();
				fillJenisProduct();
				fillBusinessUnit();
				fillDate();
				fillDropDowns();
			}
			
		}

		private void fillDate()
		{
			DDL_BLN1.Items.Add(new ListItem("-- PILIH --",""));
			DDL_BLN2.Items.Add(new ListItem("-- PILIH --",""));
			for (int i = 1; i <= 12; i++)
			{
				DDL_BLN1.Items.Add(new ListItem(DateAndTime.MonthName(i, false), i.ToString()));
				DDL_BLN2.Items.Add(new ListItem(DateAndTime.MonthName(i, false), i.ToString()));
			}

				
			TXT_TGL1.Text=DateAndTime.Today.Day.ToString();
			DDL_BLN1.SelectedValue=DateAndTime.Today.Month.ToString();
			TXT_THN1.Text=DateAndTime.Today.Year.ToString();
			TXT_TGL2.Text=DateAndTime.Today.Day.ToString();
			DDL_BLN2.SelectedValue=DateAndTime.Today.Month.ToString();
			TXT_THN2.Text=DateAndTime.Today.Year.ToString();
			
		}

		private void LoadSql(string action)
		{
			string JProduct = "", businessunit="";
			JProduct     = DDL_JENISPRODUCT.SelectedValue;
			businessunit = DDL_BUSINESSUNIT.SelectedValue;
			Load_ReportViewer(action,"", JProduct, businessunit);
				
		}

		private void Load_ReportViewer(string action,string sql_kondisi, string JProduct, string businessunit)
		{
			string tanggal1 = tools.ConvertDate(TXT_TGL1.Text,DDL_BLN1.SelectedValue,TXT_THN1.Text);
			string tanggal2 = tools.ConvertDate(TXT_TGL2.Text,DDL_BLN2.SelectedValue,TXT_THN2.Text);
			/*
			if (!Information.IsDate(tanggal1) || !Information.IsDate(tanggal2))
			{
				Tools.popMessage(this,"Invalid date");
				Response.Write("<Script language='javascript'>history.back();</Script>");
				if (!Information.IsDate(tanggal1))
					Tools.SetFocus(this,TXT_TGL1);
				else
					Tools.SetFocus(this,TXT_TGL2);
			}
			else
			*/
			{
				/***********************************************************************************************
				 * Construct sql kondisi
				***********************************************************************************************/
				sql_kondisi+=" and ap_recvdate between "+tanggal1+" and '"+tanggal2.Replace("'","")+" 23:59:59'  " ;
			
				/*
                if (!Session["bussunitid2"].Equals(""))    
				{
					sql_kondisi += " and A1.ap_businessunit in (" + Session["bussunitid2"].ToString().Replace("''","'") + ") ";
				}
                */
                if ((!Session["BussUnit"].Equals("")) && (Session["BussUnit"] != null))
                {
                    sql_kondisi += " and A1.ap_businessunit in ('" + Session["BussUnit"] + "') ";
                }
			
				if (!JProduct.Equals(""))
				{
					sql_kondisi+= " and jnsproduct='" + JProduct.ToString() + "' ";
				}

				if (!DDL_AREA.SelectedValue.Equals("")) 				
					sql_kondisi += " and areaid = '" + DDL_AREA.SelectedValue + "'";				

				if (!DDL_CBC.SelectedValue.Equals("")) 
					sql_kondisi += " and cbc_code = '" + DDL_CBC.SelectedValue + "'";

				if (!DDL_BRANCH.SelectedValue.Equals(""))
					sql_kondisi += " and branch_code = '" + DDL_BRANCH.SelectedValue + "'";

				/************************************************************************************************/

				if (!sql_kondisi.Equals(""))
				{
					sql_kondisi += " and 1=1 ";
				}

				string title_tgl1 = TXT_TGL1.Text + "-" + DDL_BLN1.SelectedItem.Text + "-" + TXT_THN1.Text;
				string title_tgl2 = TXT_TGL2.Text + "-" + DDL_BLN2.SelectedItem.Text + "-" + TXT_THN2.Text;
				string title_area = ( DDL_AREA.SelectedValue == "" ? "ALL" : DDL_AREA.SelectedItem.Text );
				string title_cbc  = ( DDL_CBC.SelectedValue == "" ? "ALL" : DDL_CBC.SelectedItem.Text );
				string title_branch = ( DDL_BRANCH.SelectedValue == "" ? "ALL" : DDL_BLN1.SelectedItem.Text );

                if (!action.Equals("PRINT"))
                {
                    /*
                    ReportViewer1.ReportPath = "/SMEReports/RptPipeLinePerProduct" +
                        "&sql_kondisi=" + sql_kondisi +
                        "&JProduct=" + JProduct +
                        "&BU=" + businessunit.ToString() +
                        "&tanggal1=" + title_tgl1 +
                        "&tanggal2=" + title_tgl2 +
                        "&areaname=" + title_area +
                        "&cbcname=" + title_cbc +
                        "&branchname=" + title_branch +
                        "&rs:Command=Render&rc:Toolbar=True";
                    */

                    IReportServerCredentials irsc = new CustomReportCredentials(WebConfigurationManager.AppSettings["ReportUser"].ToString(), WebConfigurationManager.AppSettings["ReportPassword"].ToString(), WebConfigurationManager.AppSettings["DomainName"].ToString());

                    ReportViewer1.ProcessingMode = Microsoft.Reporting.WebForms.ProcessingMode.Remote;
                    ReportViewer1.ServerReport.ReportServerCredentials = irsc;
                    ReportViewer1.ServerReport.ReportServerUrl = new Uri(WebConfigurationManager.AppSettings["ServerUrl"].ToString());
                    ReportViewer1.ServerReport.ReportPath = "/SMEReports/RptPipeLinePerProduct";

                    List<ReportParameter> paramList = new List<ReportParameter>();

                    paramList.Add(new ReportParameter("sql_kondisi", sql_kondisi, false));
                    paramList.Add(new ReportParameter("JProduct", JProduct, false));
                    paramList.Add(new ReportParameter("BU", businessunit.ToString(), false));
                    paramList.Add(new ReportParameter("branchname", title_branch, false));
                    paramList.Add(new ReportParameter("cbcname", title_cbc, false));
                    paramList.Add(new ReportParameter("areaname", title_area, false));
                    paramList.Add(new ReportParameter("tanggal1", title_tgl1, false));
                    paramList.Add(new ReportParameter("tanggal2", title_tgl2, false));

                    ReportViewer1.ServerReport.SetParameters(paramList);
                    ReportViewer1.ServerReport.Refresh();
                }
                else
                    Response.Redirect("RptPipeLinePerProductPrint.aspx?sql_kondisi=" + sql_kondisi.Replace("'", "''") + "&JProduct=" + JProduct + "&BU=" + businessunit);
			}
		}

		

		private int Posisi_User()
		{
			string area="";
			int Posisi;
            if ((Session["BranchID"].ToString() == "000") || (Session["BranchID"].ToString() == "001"))
			{ 
				//Head Office
				Posisi = 0;
			}
			else
			{
				Conn.QueryString = "select * from rfarea where arearegmanager='" + Session["UserID"].ToString() + "' ";
				Conn.ExecuteQuery();
				if (Conn.GetRowCount()>0)
					area="yup";
				else
					area="nop";

				if (area=="yup")
				{
					Posisi=3;
				}
				else
				{
					if (Session["BranchID"].ToString()==Session["CBC"].ToString()) //(Session["GroupID"].ToString().StartsWith("01"))
					{
						//CBC
						Posisi=2;
					}
					else
					{
						//Branch
						Posisi = 1;
					}
				}
			}
			return Posisi;
		}

		private void fillBusinessUnit()
		{
			DDL_BUSINESSUNIT.Items.Clear();
			switch(LBL_BU.Text)
			{
				case "CB100": case "2":
					Conn.QueryString = "select bussunitid, bussunitdesc from rfbusinessunit where bussunitid='CB100' order by bussunitid ";
					break;
				default: 
					DDL_BUSINESSUNIT.Items.Add(new ListItem("-- PILIH --",""));
					Conn.QueryString = "select bussunitid, bussunitdesc from rfbusinessunit where bussunitid<>'CB100' order by bussunitid ";
					break;
			}
			Conn.ExecuteQuery();
			for (int i = 0; i < Conn.GetRowCount(); i++)
			{
				DDL_BUSINESSUNIT.Items.Add(new ListItem(Conn.GetFieldValue(i,1),Conn.GetFieldValue(i,0)));
			}
		}

		private void fillDropDowns() 
		{
			fillArea();
			fillCBC();
			fillBranch();
		}

		private void fillArea () 
		{
			GlobalTools.fillRefList(DDL_AREA, "exec RPT_GETAREA '" + Session["UserID"].ToString() + "'", false, Conn);
		}

		private void fillCBC () 
		{
			GlobalTools.fillRefList(DDL_CBC, "exec RPT_GETCBC '" + Session["UserID"].ToString() + "', '" + DDL_AREA.SelectedValue + "'", false, Conn);
		}

		private void fillBranch() 
		{
			GlobalTools.fillRefList(DDL_BRANCH, "exec RPT_GETBRANCH '" + Session["UserID"].ToString() + "', '" + DDL_AREA.SelectedValue + "', '" + DDL_CBC.SelectedValue + "'", false, Conn);
		}

		private void fillJenisProduct()
		{
			DDL_JENISPRODUCT.Items.Clear();
			DDL_JENISPRODUCT.Items.Add(new ListItem("-- PILIH --",""));
			Conn.QueryString = "select jenisid, jenisdesc from rfjenisproduct order by jenisid asc";
			Conn.ExecuteQuery();
			for (int i = 0; i < Conn.GetRowCount(); i++)
			{
				DDL_JENISPRODUCT.Items.Add(new ListItem(Conn.GetFieldValue(i,1),Conn.GetFieldValue(i,0)));
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

		protected void BTN_LIHAT_Click(object sender, System.EventArgs e)
		{
			LoadSql("");
		}

		protected void Btn_Print_Click(object sender, System.EventArgs e)
		{
			LoadSql("PRINT");
		}

		protected void btn_back_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			Response.Redirect("MainReportOR.aspx?mc=" + Request.QueryString["mc"] + "&BU=" + LBL_BU.Text);
		}

		protected void DDL_AREA_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			fillCBC();
			fillBranch();
		}

		protected void DDL_CBC_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			fillBranch();
		}
	}
}
