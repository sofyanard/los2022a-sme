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

namespace SME.Syndication.Documentation
{
	/// <summary>
	/// Summary description for DokumenJaminan.
	/// </summary>
	public partial class DokumenJaminan : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.CheckBox Textbox5;
		protected System.Web.UI.WebControls.TextBox Textbox6;
		protected Tools tools = new Tools();
		protected Connection conn = new Connection(ConfigurationSettings.AppSettings["conn"]);
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			ViewMenu();

			if(!IsPostBack)
			{
				FillDDLJaminanAgunan();
				FillDDLJaminanAsuransi();
				FillDDLPengikatan();
				FillDDLDoc();
				FillDDLPertanggungan();

				DDL_TERBIT_MONTH_AGUNAN.Items.Add(new ListItem("--Select--",""));
				DDL_TERBIT_MONTH_ASURANSI.Items.Add(new ListItem("--Select--",""));
				DDL_JATUH_TEMPO_MONTH_AGUNAN.Items.Add(new ListItem("--Select--",""));
				DDL_JATUH_TEMPO_MONTH_ASURANSI.Items.Add(new ListItem("--Select--",""));
				for (int i = 1; i <= 12; i++)
				{
					DDL_TERBIT_MONTH_AGUNAN.Items.Add(new ListItem(DateAndTime.MonthName(i, false), i.ToString()));
					DDL_TERBIT_MONTH_ASURANSI.Items.Add(new ListItem(DateAndTime.MonthName(i, false), i.ToString()));
					DDL_JATUH_TEMPO_MONTH_AGUNAN.Items.Add(new ListItem(DateAndTime.MonthName(i, false), i.ToString()));
					DDL_JATUH_TEMPO_MONTH_ASURANSI.Items.Add(new ListItem(DateAndTime.MonthName(i, false), i.ToString()));
				}
			}
			FillDGRAgunan();
			FillDGRAsuransi();
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
						if (conn.GetFieldValue(i,3).IndexOf("mc=") >= 0)
							strtemp = "&curef=" + Request.QueryString["curef"] + "&cif=" + Request.QueryString["cif"] + "&exist=" + Request.QueryString["exist"];
						else
							strtemp = "&mc=" + Request.QueryString["mc"]+ "&curef=" + Request.QueryString["curef"] + "&cif=" + Request.QueryString["cif"] + "&exist=" + Request.QueryString["exist"];
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

		private void FillDDLJaminanAgunan()
		{
			DDL_JAMINAN_AGUNAN.Items.Clear();
			DDL_JAMINAN_AGUNAN.Items.Add(new ListItem("--Select--", ""));

			//conn.QueryString = "SELECT SEQ, DOC_TYPE + ' No.' + NO_DOC AS JAMINAN FROM SDC_COLLATERAL_INFO WHERE CU_REF = '" + Request.QueryString["curef"] + "'";
			conn.QueryString = "SELECT * FROM VW_SDC_DDLSELECTJAMINAN WHERE CU_REF = '" + Request.QueryString["curef"] + "'";
			conn.ExecuteQuery();
			for(int i=0; i < conn.GetRowCount(); i++)
			{
				DDL_JAMINAN_AGUNAN.Items.Add(new ListItem(conn.GetFieldValue(i,1), conn.GetFieldValue(i,0)));
			}
		}

		private void FillDDLJaminanAsuransi()
		{
			DDL_JAMINAN_ASURANSI.Items.Clear();
			DDL_JAMINAN_ASURANSI.Items.Add(new ListItem("--Select--", ""));

			conn.QueryString = "SELECT * FROM VW_SDC_DDLSELECTJAMINANASURANSI WHERE CU_REF = '" + Request.QueryString["curef"] + "'";
			conn.ExecuteQuery();
			for(int i=0; i < conn.GetRowCount(); i++)
			{
				DDL_JAMINAN_ASURANSI.Items.Add(new ListItem(conn.GetFieldValue(i,1), conn.GetFieldValue(i,0)));
			}
		}

		protected void BTN_AGUNAN_Click(object sender, System.EventArgs e)
		{
			conn.QueryString = "SELECT * FROM VW_SDC_SELECT_JAMINAN WHERE CU_REF = '" + Request.QueryString["curef"] + "' AND SEQ = '" + DDL_JAMINAN_AGUNAN.SelectedValue + "'";
			conn.ExecuteQuery();

			TXT_NM_JAMINAN.Text				= conn.GetFieldValue("COLL_DESC").ToString();
			TXT_TYPE_JAMINAN.Text			= conn.GetFieldValue("COLTYPEDESC").ToString();
			TXT_TYPE_DOCUMENT.Text			= conn.GetFieldValue("CERTTYPEDESC").ToString();

			LBL_JAMINAN_AGUNAN.Text			= DDL_JAMINAN_AGUNAN.SelectedValue;
			LBL_JNS_JAMINAN.Text			= conn.GetFieldValue("COLL_TYPE").ToString();
			LBL_DOC_TYPE.Text				= conn.GetFieldValue("DOC_TYPE").ToString();
		}

		protected void BTN_ASURANSI_Click(object sender, System.EventArgs e)
		{
			LBL_JAMINAN_ASURANSI.Text		= DDL_JAMINAN_ASURANSI.SelectedValue;
		}

		private void FillDDLPengikatan()
		{
			DDL_DOC_PENGIKATAN.Items.Clear();
			DDL_DOC_PENGIKATAN.Items.Add(new ListItem("--Select--", ""));

			conn.QueryString = "SELECT * FROM VW_SDC_DDLDOCUMENTIKAT ORDER BY IKATDESC";
			conn.ExecuteQuery();
			for(int i=0; i < conn.GetRowCount(); i++)
			{
				DDL_DOC_PENGIKATAN.Items.Add(new ListItem(conn.GetFieldValue(i,1), conn.GetFieldValue(i,0)));
			}
		}

		private void FillDDLDoc()
		{
			DDL_TYPE_DOC.Items.Clear();
			DDL_TYPE_DOC.Items.Add(new ListItem("--Select--", ""));

			conn.QueryString = "SELECT * FROM VW_SDC_DDLDOCUMENTJENIS ORDER BY CERTTYPEDESC";
			conn.ExecuteQuery();
			for(int i=0; i < conn.GetRowCount(); i++)
			{
				DDL_TYPE_DOC.Items.Add(new ListItem(conn.GetFieldValue(i,1), conn.GetFieldValue(i,0)));
			}
		}

		private void FillDDLPertanggungan()
		{
			DDL_TYPE_PERTANGGUNGAN.Items.Clear();
			DDL_TYPE_PERTANGGUNGAN.Items.Add(new ListItem("--Select--", ""));

			conn.QueryString = "SELECT * FROM VW_SDC_RFPERTANGGUNGAN";
			conn.ExecuteQuery();
			for(int i=0; i < conn.GetRowCount(); i++)
			{
				DDL_TYPE_PERTANGGUNGAN.Items.Add(new ListItem(conn.GetFieldValue(i,1), conn.GetFieldValue(i,0)));
			}
		}

		private void FillDGRAgunan()
		{
			conn.QueryString = "EXEC SDC_VW_DOC_JAMINAN '1','" + Request.QueryString["curef"] + "'";
			BindData(DGR_AGUNAN.ID.ToString(), conn.QueryString, "1");
		}

		private void FillDGRAsuransi()
		{
			conn.QueryString = "EXEC SDC_VW_DOC_JAMINAN '2','" + Request.QueryString["curef"] + "'";
			BindData(DGR_ASURANSI.ID.ToString(), conn.QueryString, "2");
		}

		private void BindData(string dataGridName, string strconn, string type)
		{
			if(strconn != "")
			{
				conn.QueryString = strconn;
				conn.ExecuteQuery();

				System.Data.DataTable dt = new System.Data.DataTable();
				dt = conn.GetDataTable().Copy();

				System.Web.UI.WebControls.DataGrid dg = (System.Web.UI.WebControls.DataGrid)Page.FindControl(dataGridName);
				dg.DataSource = dt;

				try
				{
					dg.DataBind();
				}
				catch
				{
					dg.CurrentPageIndex = dg.PageCount - 1;	
					dg.DataBind();
				}

				if(type == "1")
				{
					for (int i = 0; i < dg.Items.Count; i++)
					{
						dg.Items[i].Cells[8].Text = tools.FormatDate(dg.Items[i].Cells[8].Text, true);
						dg.Items[i].Cells[9].Text = tools.FormatDate(dg.Items[i].Cells[9].Text, true);
					} 
				}
				else if(type == "2")
				{
					for (int i = 0; i < dg.Items.Count; i++)
					{
						dg.Items[i].Cells[4].Text = tools.FormatDate(dg.Items[i].Cells[4].Text, true);
						dg.Items[i].Cells[5].Text = tools.FormatDate(dg.Items[i].Cells[5].Text, true);
					} 
				}

				conn.ClearData();
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
			this.DGR_AGUNAN.ItemCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.DGR_AGUNAN_ItemCommand);
			this.DGR_AGUNAN.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.DGR_AGUNAN_PageIndexChanged);
			this.DGR_ASURANSI.ItemCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.DGR_ASURANSI_ItemCommand);
			this.DGR_ASURANSI.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.DGR_ASURANSI_PageIndexChanged);

		}
		#endregion

		protected void BTN_BACK_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			Response.Redirect("../CustomerList.aspx?mc=" + Request.QueryString["mc"]);
		}

		protected void BTN_SAVE_AGUNAN_Click(object sender, System.EventArgs e)
		{
			if(DDL_JAMINAN_AGUNAN.SelectedValue == "" || DDL_JAMINAN_AGUNAN.SelectedValue == null)
			{
				GlobalTools.popMessage(this, "Select Jaminan!");
				return;
			}
			else
			{
				if (TXT_TERBIT_DAY_AGUNAN.Text != "" && DDL_TERBIT_MONTH_AGUNAN.SelectedValue != "" && TXT_TERBIT_YEAR_AGUNAN.Text != "") 
				{
					if (!GlobalTools.isDateValid(TXT_TERBIT_DAY_AGUNAN.Text, DDL_TERBIT_MONTH_AGUNAN.SelectedValue, TXT_TERBIT_YEAR_AGUNAN.Text)) 
					{
						GlobalTools.popMessage(this, "Tanggal Terbit Dokumen Agunan Tidak Valid!");
						return;
					}
				}

				if (TXT_JATUH_TEMPO_DAY_AGUNAN.Text != "" && DDL_JATUH_TEMPO_MONTH_AGUNAN.SelectedValue != "" && TXT_JATUH_TEMPO_YEAR_AGUNAN.Text != "") 
				{
					if (!GlobalTools.isDateValid(TXT_JATUH_TEMPO_DAY_AGUNAN.Text, DDL_JATUH_TEMPO_MONTH_AGUNAN.SelectedValue, TXT_JATUH_TEMPO_YEAR_AGUNAN.Text)) 
					{
						GlobalTools.popMessage(this, "Tanggal Jatuh Tempo Dokumen Agunan Tidak Valid!");
						return;
					}
				}

				try
				{
					conn.QueryString = "EXEC SDC_DOC_JAMINAN_INSERT '1','" +
										LBL_SEQ_AGUNAN.Text + "','" +
										Session["UserID"].ToString() + "','" +
										Request.QueryString["curef"] + "','" +
										Request.QueryString["cif"] + "','" +
										LBL_JAMINAN_AGUNAN.Text + "','" +
										TXT_NM_JAMINAN.Text + "','" +
										LBL_JNS_JAMINAN.Text + "','" +
										LBL_DOC_TYPE.Text + "','" +
										TXT_ISI_AKTA.Text + "','" +
										TXT_NM_NOTARIS.Text + "','" +
										DDL_DOC_PENGIKATAN.SelectedValue + "','" +
										TXT_NO_DOC_PENGIKATAN.Text + "','','','','','','','',''," +
										tools.ConvertDate(TXT_TERBIT_DAY_AGUNAN.Text, DDL_TERBIT_MONTH_AGUNAN.SelectedValue, TXT_TERBIT_YEAR_AGUNAN.Text) + "," +
										tools.ConvertDate(TXT_JATUH_TEMPO_DAY_AGUNAN.Text, DDL_JATUH_TEMPO_MONTH_AGUNAN.SelectedValue, TXT_JATUH_TEMPO_YEAR_AGUNAN.Text) + ",'" +
										TXT_PENYIMPANAN_AGUNAN.Text + "'";
					conn.ExecuteQuery();

					ClearData("1");
					FillDGRAgunan();
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
		}

		protected void BTN_CLEAR_AGUNAN_Click(object sender, System.EventArgs e)
		{
			ClearData("1");
		}

		protected void BTN_SAVE_ASURANSI_Click(object sender, System.EventArgs e)
		{
			if(DDL_JAMINAN_ASURANSI.SelectedValue == "" || DDL_JAMINAN_ASURANSI.SelectedValue == null)
			{
				GlobalTools.popMessage(this, "Select Jaminan!");
				return;
			}
			else
			{
				if (TXT_TERBIT_DAY_AGUNAN.Text != "" && DDL_TERBIT_MONTH_AGUNAN.SelectedValue != "" && TXT_TERBIT_YEAR_AGUNAN.Text != "") 
				{
					if (!GlobalTools.isDateValid(TXT_TERBIT_DAY_AGUNAN.Text, DDL_TERBIT_MONTH_AGUNAN.SelectedValue, TXT_TERBIT_YEAR_AGUNAN.Text)) 
					{
						GlobalTools.popMessage(this, "Tanggal Terbit Dokumen Agunan Tidak Valid!");
						return;
					}
				}

				if (TXT_JATUH_TEMPO_DAY_AGUNAN.Text != "" && DDL_JATUH_TEMPO_MONTH_AGUNAN.SelectedValue != "" && TXT_JATUH_TEMPO_YEAR_AGUNAN.Text != "") 
				{
					if (!GlobalTools.isDateValid(TXT_JATUH_TEMPO_DAY_AGUNAN.Text, DDL_JATUH_TEMPO_MONTH_AGUNAN.SelectedValue, TXT_JATUH_TEMPO_YEAR_AGUNAN.Text)) 
					{
						GlobalTools.popMessage(this, "Tanggal Jatuh Tempo Dokumen Agunan Tidak Valid!");
						return;
					}
				}

				try
				{
					conn.QueryString = "EXEC SDC_DOC_JAMINAN_INSERT '2','" +
										LBL_SEQ_ASURANSI.Text + "','" +
										Session["UserID"].ToString() + "','" +
										Request.QueryString["curef"] + "','" +
										Request.QueryString["cif"] + "','" +
										LBL_JAMINAN_ASURANSI.Text + "','','','','','','','','" +
										TXT_NO_POLIS.Text + "','" +
										TXT_POLIS_DESC.Text + "','" +
										DDL_TYPE_DOC.SelectedValue + "','" +
										DDL_TYPE_PERTANGGUNGAN.SelectedValue + "','" +
										TXT_NILAI_PERTANGGUNGAN.Text + "','" +
										TXT_PERUSAHAAN_ASURANSI.Text + "','" +
										TXT_KONSORSIUM.Text + "','" +
										CHK_LEADER_FLAG.Checked + "'," +
										tools.ConvertDate(TXT_TERBIT_DAY_ASURANSI.Text, DDL_TERBIT_MONTH_ASURANSI.SelectedValue, TXT_TERBIT_YEAR_ASURANSI.Text) + "," +
										tools.ConvertDate(TXT_JATUH_TEMPO_DAY_ASURANSI.Text, DDL_JATUH_TEMPO_MONTH_ASURANSI.SelectedValue, TXT_JATUH_TEMPO_YEAR_ASURANSI.Text) + ",'" +
										TXT_PENYIMPANAN_ASURANSI.Text + "'";
					conn.ExecuteQuery();

					ClearData("2");
					FillDGRAsuransi();
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
		}

		protected void BTN_CLEAR_ASURANSI_Click(object sender, System.EventArgs e)
		{
			ClearData("2");
		}

		private void ClearData(string TYPE)
		{
			switch(TYPE)
			{
				case "1":
					DDL_JAMINAN_AGUNAN.SelectedValue			= "";
					LBL_JAMINAN_AGUNAN.Text						= "";
					LBL_JNS_JAMINAN.Text						= "";
					LBL_DOC_TYPE.Text							= "";
					LBL_SEQ_AGUNAN.Text							= "";
					TXT_NM_JAMINAN.Text							= "";
					TXT_TYPE_JAMINAN.Text						= "";
					TXT_TYPE_DOCUMENT.Text						= "";
					TXT_ISI_AKTA.Text							= "";
					TXT_NM_NOTARIS.Text							= "";
					DDL_DOC_PENGIKATAN.SelectedValue			= "";
					TXT_NO_DOC_PENGIKATAN.Text					= "";
					TXT_TERBIT_DAY_AGUNAN.Text					= "";
					DDL_TERBIT_MONTH_AGUNAN.SelectedValue		= "";
					TXT_TERBIT_YEAR_AGUNAN.Text					= "";
					TXT_JATUH_TEMPO_DAY_AGUNAN.Text				= "";
					DDL_JATUH_TEMPO_MONTH_AGUNAN.SelectedValue	= "";
					TXT_JATUH_TEMPO_YEAR_AGUNAN.Text			= "";
					TXT_PENYIMPANAN_AGUNAN.Text					= "";
					break;

				case "2":
					DDL_JAMINAN_ASURANSI.SelectedValue			= "";
					LBL_JAMINAN_ASURANSI.Text					= "";
					LBL_SEQ_ASURANSI.Text						= "";
					TXT_NO_POLIS.Text							= "";
					TXT_POLIS_DESC.Text							= "";
					DDL_TYPE_DOC.SelectedValue					= "";
					TXT_TERBIT_DAY_ASURANSI.Text				= "";
					DDL_TERBIT_MONTH_ASURANSI.SelectedValue		= "";
					TXT_TERBIT_YEAR_ASURANSI.Text				= "";
					TXT_JATUH_TEMPO_DAY_ASURANSI.Text			= "";
					DDL_JATUH_TEMPO_MONTH_ASURANSI.SelectedValue= "";
					TXT_JATUH_TEMPO_YEAR_ASURANSI.Text			= "";
					DDL_TYPE_PERTANGGUNGAN.SelectedValue		= "";
					TXT_NILAI_PERTANGGUNGAN.Text				= "";
					TXT_PERUSAHAAN_ASURANSI.Text				= "";
					TXT_KONSORSIUM.Text							= "";
					CHK_LEADER_FLAG.Checked						= false;
					TXT_PENYIMPANAN_ASURANSI.Text				= "";
					break;
			}
		}

		private void DGR_AGUNAN_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			DGR_AGUNAN.CurrentPageIndex = e.NewPageIndex;
			FillDGRAgunan();
		}

		private void DGR_AGUNAN_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			switch(((LinkButton)e.CommandSource).CommandName)
			{
				case "edit":
					conn.QueryString = "SELECT * FROM SDC_DOC_JAMINAN WHERE SEQ = '" + e.Item.Cells[0].Text.ToString() + "' AND CU_REF = '" + Request.QueryString["curef"] + "' AND DOC_GROUP = '1'";
					conn.ExecuteQuery();

					DDL_JAMINAN_AGUNAN.SelectedValue			= conn.GetFieldValue("INSURANCE_SEQ").ToString();
					LBL_JAMINAN_AGUNAN.Text						= conn.GetFieldValue("INSURANCE_SEQ").ToString().Replace("&nbsp;","");
					LBL_JNS_JAMINAN.Text						= conn.GetFieldValue("COLL_TYPE").ToString().Replace("&nbsp;","");
					LBL_DOC_TYPE.Text							= conn.GetFieldValue("DOC_TYPE").ToString().Replace("&nbsp;","");
					LBL_SEQ_AGUNAN.Text							= conn.GetFieldValue("SEQ").ToString().Replace("&nbsp;","");
					TXT_NM_JAMINAN.Text							= conn.GetFieldValue("COLL_DESC").ToString().Replace("&nbsp;","");
					TXT_ISI_AKTA.Text							= conn.GetFieldValue("AKTA_DESC").ToString().Replace("&nbsp;","");
					TXT_NM_NOTARIS.Text							= conn.GetFieldValue("NOTARY").ToString().Replace("&nbsp;","");
					DDL_DOC_PENGIKATAN.SelectedValue			= conn.GetFieldValue("DOC_PENGIKATAN").ToString();
					TXT_NO_DOC_PENGIKATAN.Text					= conn.GetFieldValue("NO_DOC_PENGIKATAN").ToString().Replace("&nbsp;","");
					TXT_TERBIT_DAY_AGUNAN.Text					= tools.FormatDate_Day(conn.GetFieldValue("ISSUED_DATE").ToString());
					DDL_TERBIT_MONTH_AGUNAN.SelectedValue		= tools.FormatDate_Month(conn.GetFieldValue("ISSUED_DATE").ToString());
					TXT_TERBIT_YEAR_AGUNAN.Text					= tools.FormatDate_Year(conn.GetFieldValue("ISSUED_DATE").ToString());
					TXT_JATUH_TEMPO_DAY_AGUNAN.Text				= tools.FormatDate_Day(conn.GetFieldValue("EXP_DATE").ToString());
					DDL_JATUH_TEMPO_MONTH_AGUNAN.SelectedValue	= tools.FormatDate_Month(conn.GetFieldValue("EXP_DATE").ToString());
					TXT_JATUH_TEMPO_YEAR_AGUNAN.Text			= tools.FormatDate_Year(conn.GetFieldValue("EXP_DATE").ToString());
					TXT_PENYIMPANAN_AGUNAN.Text					= conn.GetFieldValue("PLACE_DOC").ToString().Replace("&nbsp;","");

					conn.QueryString = "SELECT COLTYPESEQ, COLTYPEDESC FROM RFCOLLATERALTYPE WHERE ACTIVE = '1' AND COLTYPESEQ = '" + LBL_JNS_JAMINAN.Text + "'";
					conn.ExecuteQuery();
					TXT_TYPE_JAMINAN.Text						= conn.GetFieldValue("COLTYPEDESC").ToString().Replace("&nbsp;","");

					conn.QueryString = "SELECT CERTTYPEID, CERTTYPEDESC FROM RFCERTTYPE WHERE ACTIVE = '1' AND CERTTYPEID = '" + LBL_DOC_TYPE.Text + "'";
					conn.ExecuteQuery();
					TXT_TYPE_DOCUMENT.Text						= conn.GetFieldValue("CERTTYPEDESC").ToString().Replace("&nbsp;","");
					break;

				case "delete":
					conn.QueryString = "DELETE SDC_DOC_JAMINAN WHERE SEQ = '" + e.Item.Cells[0].Text.ToString() + "' AND CU_REF = '" + Request.QueryString["curef"] + "' AND DOC_GROUP = '1'";
					conn.ExecuteQuery();

					FillDGRAgunan();
					break;
			}
		}

		private void DGR_ASURANSI_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			DGR_ASURANSI.CurrentPageIndex = e.NewPageIndex;
			FillDGRAsuransi();
		}

		private void DGR_ASURANSI_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			switch(((LinkButton)e.CommandSource).CommandName)
			{
				case "edit":
					conn.QueryString = "SELECT * FROM SDC_DOC_JAMINAN WHERE SEQ = '" + e.Item.Cells[0].Text.ToString() + "' AND CU_REF = '" + Request.QueryString["curef"] + "' AND DOC_GROUP = '2'";
					conn.ExecuteQuery();

					DDL_JAMINAN_ASURANSI.SelectedValue			= conn.GetFieldValue("INSURANCE_SEQ").ToString();
					LBL_JAMINAN_ASURANSI.Text					= conn.GetFieldValue("INSURANCE_SEQ").ToString().Replace("&nbsp;","");
					LBL_SEQ_ASURANSI.Text						= conn.GetFieldValue("SEQ").ToString().Replace("&nbsp;","");
					TXT_NO_POLIS.Text							= conn.GetFieldValue("NO_POLIS").ToString().Replace("&nbsp;","");
					TXT_POLIS_DESC.Text							= conn.GetFieldValue("POLIS_DESC").ToString().Replace("&nbsp;","");
					DDL_TYPE_DOC.SelectedValue					= conn.GetFieldValue("INS_DOC_TYPE").ToString().Replace("&nbsp;","");
					TXT_TERBIT_DAY_ASURANSI.Text				= tools.FormatDate_Day(conn.GetFieldValue("ISSUED_DATE").ToString());
					DDL_TERBIT_MONTH_ASURANSI.SelectedValue		= tools.FormatDate_Month(conn.GetFieldValue("ISSUED_DATE").ToString());
					TXT_TERBIT_YEAR_ASURANSI.Text				= tools.FormatDate_Year(conn.GetFieldValue("ISSUED_DATE").ToString());
					TXT_JATUH_TEMPO_DAY_ASURANSI.Text			= tools.FormatDate_Day(conn.GetFieldValue("EXP_DATE").ToString());
					DDL_JATUH_TEMPO_MONTH_ASURANSI.SelectedValue= tools.FormatDate_Month(conn.GetFieldValue("EXP_DATE").ToString());
					TXT_JATUH_TEMPO_YEAR_ASURANSI.Text			= tools.FormatDate_Year(conn.GetFieldValue("EXP_DATE").ToString());
					DDL_TYPE_PERTANGGUNGAN.SelectedValue		= conn.GetFieldValue("PERTANGGUNGAN_TYPE").ToString();
					TXT_NILAI_PERTANGGUNGAN.Text				= conn.GetFieldValue("PERTANGGUNGAN_VAL").ToString().Replace("&nbsp;","");
					TXT_PERUSAHAAN_ASURANSI.Text				= conn.GetFieldValue("INS_COMPANY").ToString().Replace("&nbsp;","");
					TXT_KONSORSIUM.Text							= conn.GetFieldValue("KONSORSIUM_PERCENT").ToString().Replace("&nbsp;","");
					TXT_PENYIMPANAN_ASURANSI.Text				= conn.GetFieldValue("PLACE_DOC").ToString().Replace("&nbsp;","");
					
					if(conn.GetFieldValue("REMARK_INS").ToString() == "" || conn.GetFieldValue("REMARK_INS").ToString() == null || conn.GetFieldValue("REMARK_INS").ToString() == "False")
					{
						CHK_LEADER_FLAG.Checked					= false;
					}
					else
					{
						CHK_LEADER_FLAG.Checked					= true;
					}
					break;

				case "delete":
					conn.QueryString = "DELETE SDC_DOC_JAMINAN WHERE SEQ = '" + e.Item.Cells[0].Text.ToString() + "' AND CU_REF = '" + Request.QueryString["curef"] + "' AND DOC_GROUP = '2'";
					conn.ExecuteQuery();

					FillDGRAsuransi();
					break;
			}
		}
	}
}
