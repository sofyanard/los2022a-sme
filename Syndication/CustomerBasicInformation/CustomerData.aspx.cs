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
using DMS.CuBESCore;
using DMS.DBConnection;
using Microsoft.VisualBasic;

namespace SME.Syndication.CustomerBasicInformation
{
	/// <summary>
	/// Summary description for CustomerData.
	/// </summary>
	public partial class CustomerData : System.Web.UI.Page
	{
		protected Tools tools = new Tools();
		protected Connection conn = new Connection(ConfigurationSettings.AppSettings["conn"]);
		protected Connection conn2 = new Connection(ConfigurationSettings.AppSettings["conn"]);
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			ViewMenu();
			
			if(!IsPostBack)
			{				
				DDL_SECTOR1.Items.Add(new ListItem("--Select--",""));
				DDL_SECTOR2.Items.Add(new ListItem("--Select--",""));
				DDL_SECTOR3.Items.Add(new ListItem("--Select--",""));
				DDL_SECTOR4.Items.Add(new ListItem("--Select--",""));

				FillDDLBusiness();
				FillDDLSector();

				DDL_OPERATE_MONTH.Items.Add(new ListItem("--Select--",""));
				for (int i = 1; i <= 12; i++)
				{
					DDL_OPERATE_MONTH.Items.Add(new ListItem(DateAndTime.MonthName(i, false), i.ToString()));
				}

				ViewData();
			}
		}

		private void ViewMenu()
		{
			Menu.Controls.Clear();
			try 
			{
				conn.QueryString = "SELECT * FROM SCREENMENU WHERE MENUCODE = '" + Request.QueryString["mc"] + "'";
				conn.ExecuteQuery();
				
				for (int i = 0; i < conn.GetRowCount(); i++) 
				{
					HyperLink t = new HyperLink();
					t.Text = conn.GetFieldValue(i, 2);
					t.Font.Bold = true;
					string strtemp = "";
					if (conn.GetFieldValue(i, 3).Trim()!= "") 
					{
						if(Request.QueryString["exist"] == "1")
						{
							if (conn.GetFieldValue(i,3).IndexOf("mc=") >= 0)
								strtemp = "&curef=" + Request.QueryString["curef"] + "&cif=" + Request.QueryString["cif"] + "&exist=" + Request.QueryString["exist"];
							else	
								strtemp = "&mc=" + Request.QueryString["mc"]+ "&curef=" + Request.QueryString["curef"] + "&cif=" + Request.QueryString["cif"] + "&exist=" + Request.QueryString["exist"];
						}
						else if(Request.QueryString["exist"] == "0")
						{
							if (conn.GetFieldValue(i,3).IndexOf("mc=") >= 0)
								strtemp = "&curef=" + Request.QueryString["curef"] + "&cif=" + TXT_CIF.Text + "&exist=" + Request.QueryString["exist"];
							else	
								strtemp = "&mc=" + Request.QueryString["mc"]+ "&curef=" + Request.QueryString["curef"] + "&cif=" + TXT_CIF.Text + "&exist=" + Request.QueryString["exist"];
						}
					}
					else 
					{
						strtemp = ""; 
					}
					t.NavigateUrl = conn.GetFieldValue(i, 3)+strtemp;
					Menu.Controls.Add(t);
					Menu.Controls.Add(new LiteralControl("&nbsp;&nbsp;&nbsp;"));
				}
			} 
			catch (Exception ex) 
			{
				string temp = ex.ToString();
			}
		}

		private void FillDDLBusiness()
		{
			DDL_BIDANG_USAHA.Items.Clear();
			DDL_BIDANG_USAHA.Items.Add(new ListItem("--Select--", ""));

			conn.QueryString = "SELECT BUSSTYPEID, BUSSTYPEDESC FROM RFBUSINESSTYPE WHERE ACTIVE = '1' ORDER BY BUSSTYPEDESC";
			conn.ExecuteQuery();
			for(int i=0; i < conn.GetRowCount(); i++)
			{
				DDL_BIDANG_USAHA.Items.Add(new ListItem(conn.GetFieldValue(i,1), conn.GetFieldValue(i,0)));
			}
		}

		private void FillDDLSector()
		{
			DDL_SECTOR1.Items.Clear();
			DDL_SECTOR1.Items.Add(new ListItem("--Select--", ""));

			conn.QueryString = "SELECT BM_CODE, BM_CODE + ' - ' + BM_DESC AS BMSEKTORDESC FROM RFBMSEKTOREKONOMI WHERE ACTIVE='1' ORDER BY BM_CODE";
			conn.ExecuteQuery();
			for(int i=0; i < conn.GetRowCount(); i++)
			{
				DDL_SECTOR1.Items.Add(new ListItem(conn.GetFieldValue(i,1), conn.GetFieldValue(i,0)));
			}
		}

		protected void DDL_SECTOR1_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			DDL_SECTOR2.Items.Clear();
			DDL_SECTOR2.Items.Add(new ListItem("--Select--", ""));

			conn.QueryString = "SELECT BMSUB_CODE, BMSUB_CODE + ' - ' + BMSUB_DESC AS BMSUBSEKTORDESC FROM RFBMSUBSEKTOREKONOMI WHERE ACTIVE='1' AND BM_CODE = '" + DDL_SECTOR1.SelectedValue + "' ORDER BY BMSUB_CODE";
			conn.ExecuteQuery();
			for (int i = 0; i < conn.GetRowCount(); i++)
			{
				DDL_SECTOR2.Items.Add(new ListItem(conn.GetFieldValue(i,1), conn.GetFieldValue(i,0)));
			}
			conn.ClearData();

			DDL_SECTOR3.Items.Clear();
			DDL_SECTOR3.Items.Add(new ListItem("--Select--", ""));

			conn.QueryString = "SELECT BMSUBSUB_CODE, BMSUBSUB_CODE + ' - ' + BMSUBSUB_DESC AS BMSUBSUBSEKTORDESC FROM RFBMSUBSUBSEKTOREKONOMI WHERE ACTIVE='1' AND BMSUB_CODE = '" + DDL_SECTOR2.SelectedValue + "' ORDER BY BMSUBSUB_CODE";
			conn.ExecuteQuery();
			for (int i = 0; i < conn.GetRowCount(); i++)
			{
				DDL_SECTOR3.Items.Add(new ListItem(conn.GetFieldValue(i,1), conn.GetFieldValue(i,0)));
			}

			conn.QueryString = "SELECT BI_SEQ, BMSUBSUB_DESC, * FROM RFBMSUBSUBSEKTOREKONOMI WHERE ACTIVE = '1' AND BMSUBSUB_CODE = '" + DDL_SECTOR3.SelectedValue + "'";
			conn.ExecuteQuery();
			GlobalTools.fillRefList(DDL_SECTOR4, "SELECT BI_SEQ, BI_DESC FROM RFBICODE WHERE ACTIVE = '1' AND BG_GROUP = '3' AND BI_SEQ = '" + conn.GetFieldValue("BI_SEQ") + "'", true, conn);
			try
			{
				DDL_SECTOR4.SelectedValue = conn.GetFieldValue("BI_SEQ");
			}
			catch
			{
				DDL_SECTOR4.SelectedValue = "";
			}
		}

		protected void DDL_SECTOR2_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			DDL_SECTOR3.Items.Clear();

			conn.QueryString = "SELECT BMSUBSUB_CODE, BMSUBSUB_CODE + ' - ' + BMSUBSUB_DESC AS BMSUBSUBSEKTORDESC FROM RFBMSUBSUBSEKTOREKONOMI WHERE ACTIVE='1' AND BMSUB_CODE = '" + DDL_SECTOR2.SelectedValue + "' ORDER BY BMSUBSUB_CODE";
			conn.ExecuteQuery();
			for (int i = 0; i < conn.GetRowCount(); i++)
				DDL_SECTOR3.Items.Add(new ListItem(conn.GetFieldValue(i,1), conn.GetFieldValue(i,0)));

			conn.QueryString = "SELECT BI_SEQ, BMSUBSUB_DESC, * FROM RFBMSUBSUBSEKTOREKONOMI WHERE ACTIVE = '1' AND BMSUBSUB_CODE = '" + DDL_SECTOR3.SelectedValue + "'";
			conn.ExecuteQuery();
			GlobalTools.fillRefList(DDL_SECTOR4, "SELECT BI_SEQ, BI_DESC FROM RFBICODE WHERE ACTIVE = '1' AND BG_GROUP = '3' AND BI_SEQ = '" + conn.GetFieldValue("BI_SEQ") + "'", true, conn);
			try
			{
				DDL_SECTOR4.SelectedValue = conn.GetFieldValue("BI_SEQ");
			}
			catch
			{
				DDL_SECTOR4.SelectedValue = "";
			}
		}

		protected void DDL_SECTOR3_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			conn.QueryString = "SELECT BI_SEQ, BMSUBSUB_DESC, * FROM RFBMSUBSUBSEKTOREKONOMI WHERE ACTIVE = '1' AND BMSUBSUB_CODE = '" + DDL_SECTOR3.SelectedValue + "'";
			conn.ExecuteQuery();
			GlobalTools.fillRefList(DDL_SECTOR4, "SELECT BI_SEQ, BI_DESC FROM RFBICODE WHERE ACTIVE = '1' AND BG_GROUP = '3' AND BI_SEQ = '" + conn.GetFieldValue("BI_SEQ") + "'", true, conn);
			try
			{
				DDL_SECTOR4.SelectedValue = conn.GetFieldValue("BI_SEQ");
			}
			catch
			{
				DDL_SECTOR4.SelectedValue = "";
			}
		}

		protected void TXT_TEMPBI_TextChanged(object sender, System.EventArgs e)
		{
			string biall, bi1, bi2, bi3, bi4;
			int x, y;
			if(this.TXT_TEMPBI.Text != "")
			{
				try
				{
					biall = TXT_TEMPBI.Text.Trim();
					y = biall.Length;

					x = biall.IndexOf("|");
					bi1 = biall.Substring(0, x);
					biall = biall.Substring(x+1, y-x-1);
					y = biall.Length;

					x = biall.IndexOf("|");
					bi2 = biall.Substring(0, x);
					biall = biall.Substring(x+1, y-x-1);
					y = biall.Length;

					x = biall.IndexOf("|");
					bi3 = biall.Substring(0, x);
					biall = biall.Substring(x+1, y-x-1);

					bi4 = biall;

					DDL_SECTOR1.SelectedValue = bi1;

					DDL_SECTOR2.Items.Clear();
					DDL_SECTOR2.Items.Add(new ListItem("--Select--", ""));
					conn.QueryString = "SELECT BMSUB_CODE, BMSUB_CODE + ' - ' + BMSUB_DESC AS BMSUBSEKTORDESC FROM RFBMSUBSEKTOREKONOMI WHERE ACTIVE='1' AND BM_CODE = '"  + bi1 + "' ORDER BY BMSUB_CODE";
					conn.ExecuteQuery();
					for (int i = 0; i < conn.GetRowCount(); i++)
					{
						DDL_SECTOR2.Items.Add(new ListItem(conn.GetFieldValue(i,1), conn.GetFieldValue(i,0)));
					}

					DDL_SECTOR2.SelectedValue = bi2;

					DDL_SECTOR3.Items.Clear();
					DDL_SECTOR3.Items.Add(new ListItem("--Select--", ""));
					conn.QueryString = "SELECT BMSUBSUB_CODE, BMSUBSUB_CODE + ' - ' + BMSUBSUB_DESC AS BMSUBSEKTORDESC FROM RFBMSUBSUBSEKTOREKONOMI WHERE ACTIVE='1' AND BMSUB_CODE = '"  + bi2 + "' ORDER BY BMSUBSUB_CODE";
					conn.ExecuteQuery();
					for (int i = 0; i < conn.GetRowCount(); i++)
					{
						DDL_SECTOR3.Items.Add(new ListItem(conn.GetFieldValue(i,1), conn.GetFieldValue(i,0)));
					}

					DDL_SECTOR3.SelectedValue = bi3;

					DDL_SECTOR4.Items.Clear();
					conn.QueryString = "SELECT BI_SEQ, BMSUBSUB_DESC, * FROM RFBMSUBSUBSEKTOREKONOMI WHERE BMSUBSUB_CODE = '" + bi3 + "'";
					conn.ExecuteQuery();
					GlobalTools.fillRefList(DDL_SECTOR4, "SELECT BI_SEQ, BI_DESC FROM RFBICODE WHERE BG_GROUP = '3' AND BI_SEQ = '" + conn.GetFieldValue("BI_SEQ") + "'", true, conn);

					DDL_SECTOR4.SelectedValue = bi4;
				}
				catch (Exception ex)
				{
					Response.Write("<!--" + ex.ToString() + "-->");
				}
			}
		}

		private void ViewData()
		{
			conn.QueryString = "SELECT * FROM SDC_CUSTOMER_INFO WHERE CU_REF = '" + Request.QueryString["curef"] + "'";
			conn.ExecuteQuery();

			LBL_SEQ.Text					= conn.GetFieldValue("SEQ").ToString().Replace("&nbsp;","");
			TXT_CIF.Text					= conn.GetFieldValue("CIF").ToString().Replace("&nbsp;","");
			TXT_NAMA_DEBIT.Text				= conn.GetFieldValue("CUST_NAME").ToString().Replace("&nbsp;","");
			TXT_ALAMAT_KANPUS.Text			= conn.GetFieldValue("HQ_ADR").ToString().Replace("&nbsp;","");
			TXT_ALAMAT_PABRIK.Text			= conn.GetFieldValue("FACTORY_ADR").ToString().Replace("&nbsp;","");
			TXT_ALAMAT_WAKIL.Text			= conn.GetFieldValue("AGENCY_ADR").ToString().Replace("&nbsp;","");
			TXT_NPWP.Text					= conn.GetFieldValue("NPWP").ToString().Replace("&nbsp;","");
			TXT_OPERATE_DAY.Text			= tools.FormatDate_Day(conn.GetFieldValue("ISTABLISH_DATE").ToString());
			DDL_OPERATE_MONTH.SelectedValue	= tools.FormatDate_Month(conn.GetFieldValue("ISTABLISH_DATE").ToString());
			TXT_OPERATE_YEAR.Text			= tools.FormatDate_Year(conn.GetFieldValue("ISTABLISH_DATE").ToString());
			DDL_BIDANG_USAHA.SelectedValue	= conn.GetFieldValue("BUSS_ID").ToString().Replace("&nbsp;","");
			TXT_GROUP_USAHA.Text			= conn.GetFieldValue("GROUP_NM").ToString().Replace("&nbsp;","");
			TXT_KEY_PERSON.Text				= conn.GetFieldValue("KEY_PERSON").ToString().Replace("&nbsp;","");
			TXT_NO_SIUP.Text				= conn.GetFieldValue("SIUP_TDP_NUMBER").ToString().Replace("&nbsp;","");
			DDL_SECTOR1.SelectedValue		= conn.GetFieldValue("SEKTOR1").ToString();
			
			//FillDDLSector2
			conn2.QueryString = "SELECT BMSUB_CODE, BMSUB_CODE + ' - ' + BMSUB_DESC AS BMSUBSEKTORDESC FROM RFBMSUBSEKTOREKONOMI WHERE ACTIVE='1' AND BM_CODE = '"  + DDL_SECTOR1.SelectedValue + "'ORDER BY BMSUB_CODE";
			conn2.ExecuteQuery();
			for (int i = 0; i < conn2.GetRowCount(); i++)
			{
				DDL_SECTOR2.Items.Add(new ListItem(conn2.GetFieldValue(i,1), conn2.GetFieldValue(i,0)));
			}
			DDL_SECTOR2.SelectedValue		= conn.GetFieldValue("SEKTOR2").ToString();
			
			//FillDDLSector3
			conn2.QueryString = "SELECT BMSUBSUB_CODE, BMSUBSUB_CODE + ' - ' + BMSUBSUB_DESC AS BMSUBSEKTORDESC FROM RFBMSUBSUBSEKTOREKONOMI WHERE ACTIVE='1' AND BMSUB_CODE = '"  + DDL_SECTOR2.SelectedValue + "' ORDER BY BMSUBSUB_CODE";
			conn2.ExecuteQuery();
			for (int i = 0; i < conn2.GetRowCount(); i++)
			{
				DDL_SECTOR3.Items.Add(new ListItem(conn2.GetFieldValue(i,1), conn2.GetFieldValue(i,0)));
			}
			DDL_SECTOR3.SelectedValue		= conn.GetFieldValue("SEKTOR3").ToString();

			//FillDDLSector4
			conn2.QueryString = "SELECT BI_SEQ, BMSUBSUB_DESC, * FROM RFBMSUBSUBSEKTOREKONOMI WHERE BMSUBSUB_CODE = '" + DDL_SECTOR3.SelectedValue + "'";
			conn2.ExecuteQuery();
			GlobalTools.fillRefList(DDL_SECTOR4, "SELECT BI_SEQ, BI_DESC FROM RFBICODE WHERE BG_GROUP = '3' AND BI_SEQ = '" + conn2.GetFieldValue("BI_SEQ") + "'", true, conn2);
			DDL_SECTOR4.SelectedValue		= conn.GetFieldValue("SEKTOR4").ToString();
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

		protected void BTN_SAVE_Click(object sender, System.EventArgs e)
		{
			if (TXT_OPERATE_DAY.Text != "" && DDL_OPERATE_MONTH.SelectedValue != "" && TXT_OPERATE_YEAR.Text != "") 
			{
				if (!GlobalTools.isDateValid(TXT_OPERATE_DAY.Text, DDL_OPERATE_MONTH.SelectedValue, TXT_OPERATE_YEAR.Text)) 
				{
					GlobalTools.popMessage(this, "Date Not Valid!");
					return;
				}
			}
			
			try
			{
				conn.QueryString = "EXEC SDC_CUSTOMER_INFO_INSERT '" +
									LBL_SEQ.Text + "','" +
									Session["UserID"].ToString() + "','" +
									Request.QueryString["curef"] + "','" +
									TXT_CIF.Text + "','" +
									TXT_NAMA_DEBIT.Text + "','" +
									TXT_ALAMAT_KANPUS.Text + "','" +
									TXT_ALAMAT_PABRIK.Text + "','" +
									TXT_ALAMAT_WAKIL.Text + "','" +
									TXT_NPWP.Text + "'," +
									tools.ConvertDate(TXT_OPERATE_DAY.Text, DDL_OPERATE_MONTH.SelectedValue, TXT_OPERATE_YEAR.Text) + ",'" +
									DDL_SECTOR1.SelectedValue + "','" +
									DDL_SECTOR2.SelectedValue + "','" +
									DDL_SECTOR3.SelectedValue + "','" +
									DDL_SECTOR4.SelectedValue + "','" +
									TXT_KEY_PERSON.Text + "','" +
									TXT_NO_SIUP.Text + "','" +
									DDL_BIDANG_USAHA.SelectedValue + "','" +
									TXT_GROUP_USAHA.Text + "'";
				conn.ExecuteQuery();

				//Label Sequence
				conn.QueryString = "SELECT * FROM SDC_CUSTOMER_INFO WHERE CU_REF = '" + Request.QueryString["curef"] + "'";
				conn.ExecuteQuery();
				LBL_SEQ.Text		= conn.GetFieldValue("SEQ").ToString();
			}

			catch(Exception ex)
			{
				string errmsg = ex.Message.Replace("'","");
				if (errmsg.IndexOf("Last Query:") > 0)
					errmsg = errmsg.Substring(0, errmsg.IndexOf("Last Query:"));
				GlobalTools.popMessage(this, errmsg);
				return;
			}
		}

		protected void BTN_CLEAR_Click(object sender, System.EventArgs e)
		{
			TXT_CIF.Text					= "";
			TXT_NAMA_DEBIT.Text				= "";
			TXT_ALAMAT_KANPUS.Text			= "";
			TXT_ALAMAT_PABRIK.Text			= "";
			TXT_ALAMAT_WAKIL.Text			= "";
			TXT_NPWP.Text					= "";
			TXT_OPERATE_DAY.Text			= "";
			DDL_OPERATE_MONTH.SelectedValue	= "";
			TXT_OPERATE_YEAR.Text			= "";
			DDL_BIDANG_USAHA.SelectedValue	= "";
			TXT_GROUP_USAHA.Text			= "";
			DDL_SECTOR1.SelectedValue		= "";
			DDL_SECTOR2.Items.Clear();
			DDL_SECTOR2.Items.Add(new ListItem("--Select--",""));
			DDL_SECTOR3.Items.Clear();
			DDL_SECTOR3.Items.Add(new ListItem("--Select--",""));
			DDL_SECTOR4.Items.Clear();
			DDL_SECTOR4.Items.Add(new ListItem("--Select--",""));
			TXT_KEY_PERSON.Text				= "";
			TXT_NO_SIUP.Text				= "";
		}

		protected void BTN_BACK_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			Response.Redirect("../CustomerList.aspx?mc=" + Request.QueryString["mc"]);
		}
	}
}
