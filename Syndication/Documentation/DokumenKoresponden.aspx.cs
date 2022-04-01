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
	/// Summary description for DokumenKoresponden.
	/// </summary>
	public partial class DokumenKoresponden : System.Web.UI.Page
	{
		protected Tools tools = new Tools();
		protected Connection conn = new Connection(ConfigurationSettings.AppSettings["conn"]);
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			ViewMenu();

			if(!IsPostBack)
			{
				FillDDLDoc();

				DDL_TERBIT_MONTH.Items.Add(new ListItem("--Select--",""));
				DDL_JATUH_TEMPO_MONTH.Items.Add(new ListItem("--Select--",""));
				for (int i = 1; i <= 12; i++)
				{
					DDL_TERBIT_MONTH.Items.Add(new ListItem(DateAndTime.MonthName(i, false), i.ToString()));
					DDL_JATUH_TEMPO_MONTH.Items.Add(new ListItem(DateAndTime.MonthName(i, false), i.ToString()));
				}
			}
			FillDataGrid();
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

		private void FillDDLDoc()
		{
			DDL_JENIS_DOC.Items.Clear();
			DDL_JENIS_DOC.Items.Add(new ListItem("--Select--", ""));

			conn.QueryString = "SELECT * FROM VW_SDC_DDLJENISDOCUMENT ORDER BY CERTTYPEDESC";
			conn.ExecuteQuery();
			for(int i=0; i < conn.GetRowCount(); i++)
			{
				DDL_JENIS_DOC.Items.Add(new ListItem(conn.GetFieldValue(i,1), conn.GetFieldValue(i,0)));
			}
		}

		private void FillDataGrid()
		{
			conn.QueryString = "SELECT * FROM VW_SDC_DOC_UMUM WHERE CU_REF = '" + Request.QueryString["curef"] + "' AND DOC_GROUP = '3'";
			BindData(DATA_GRID.ID.ToString(), conn.QueryString);
		}

		private void BindData(string dataGridName, string strconn)
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
			this.DATA_GRID.ItemCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.DATA_GRID_ItemCommand);
			this.DATA_GRID.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.DATA_GRID_PageIndexChanged);

		}
		#endregion

		protected void BTN_SAVE_Click(object sender, System.EventArgs e)
		{
			if (TXT_TERBIT_DAY.Text != "" && DDL_TERBIT_MONTH.SelectedValue != "" && TXT_TERBIT_YEAR.Text != "") 
			{
				if (!GlobalTools.isDateValid(TXT_TERBIT_DAY.Text, DDL_TERBIT_MONTH.SelectedValue, TXT_TERBIT_YEAR.Text)) 
				{
					GlobalTools.popMessage(this, "Tanggal Terbit Dokumen Tidak Valid!");
					return;
				}
			}

			if (TXT_JATUH_TEMPO_DAY.Text != "" && DDL_JATUH_TEMPO_MONTH.SelectedValue != "" && TXT_JATUH_TEMPO_YEAR.Text != "") 
			{
				if (!GlobalTools.isDateValid(TXT_JATUH_TEMPO_DAY.Text, DDL_JATUH_TEMPO_MONTH.SelectedValue, TXT_JATUH_TEMPO_YEAR.Text)) 
				{
					GlobalTools.popMessage(this, "Tanggal Jatuh Tempo Dokumen Tidak Valid!");
					return;
				}
			}

			try
			{
				conn.QueryString = "EXEC SDC_DOC_UMUM_INSERT '3','" +
									LBL_SEQ.Text + "','" +
									Session["UserID"].ToString() + "','" +
									Request.QueryString["curef"] + "','" +
									Request.QueryString["cif"] + "','" +
									DDL_JENIS_DOC.SelectedValue + "','" +
									TXT_NO_DOC.Text + "','" +
									RDO_FORMAT.SelectedValue + "','" +
									TXT_PERIHAL.Text + "','" +
									TXT_PENERBIT_DOC.Text + "','" +
									TXT_TEMPAT_PENYIMPANAN.Text + "'," +
									tools.ConvertDate(TXT_TERBIT_DAY.Text, DDL_TERBIT_MONTH.SelectedValue, TXT_TERBIT_YEAR.Text) + "," +
									tools.ConvertDate(TXT_JATUH_TEMPO_DAY.Text, DDL_JATUH_TEMPO_MONTH.SelectedValue, TXT_JATUH_TEMPO_YEAR.Text) + ",'" +
									TXT_ISI_DOC.Text + "','" +
									TXT_NOTARIS.Text + "','" +
									TXT_PENJELASAN.Text + "'";
				conn.ExecuteQuery();

				ClearData();
				FillDataGrid();
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
			ClearData();
		}

		private void ClearData()
		{
			LBL_SEQ.Text						= "";
			DDL_JENIS_DOC.SelectedValue			= "";
			TXT_NO_DOC.Text						= "";
			RDO_FORMAT.SelectedValue			= null;
			TXT_PERIHAL.Text					= "";
			TXT_PENERBIT_DOC.Text				= "";
			TXT_TEMPAT_PENYIMPANAN.Text			= "";
			TXT_TERBIT_DAY.Text					= "";
			DDL_TERBIT_MONTH.SelectedValue		= "";
			TXT_TERBIT_YEAR.Text				= "";
			TXT_JATUH_TEMPO_DAY.Text			= "";
			DDL_JATUH_TEMPO_MONTH.SelectedValue = "";
			TXT_JATUH_TEMPO_YEAR.Text			= "";
			TXT_ISI_DOC.Text					= "";
			TXT_NOTARIS.Text					= "";
			TXT_PENJELASAN.Text					= "";
		}

		protected void BTN_BACK_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			Response.Redirect("../CustomerList.aspx?mc=" + Request.QueryString["mc"]);
		}

		private void DATA_GRID_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			DATA_GRID.CurrentPageIndex = e.NewPageIndex;
			FillDataGrid();
		}

		private void DATA_GRID_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			switch(((LinkButton)e.CommandSource).CommandName)
			{
				case "edit":
					conn.QueryString = "SELECT * FROM SDC_DOC_UMUM WHERE SEQ = '" + e.Item.Cells[0].Text.ToString() + "' AND CU_REF = '" + Request.QueryString["curef"] + "' AND DOC_GROUP = '3'";
					conn.ExecuteQuery();

					LBL_SEQ.Text						= conn.GetFieldValue("SEQ").ToString().Replace("&nbsp;","");
					DDL_JENIS_DOC.SelectedValue			= conn.GetFieldValue("DOC_TYPE").ToString();
					TXT_NO_DOC.Text						= conn.GetFieldValue("DOC_NUMBER").ToString().Replace("&nbsp;","");

					if(conn.GetFieldValue("FORMAT") != "" && conn.GetFieldValue("FORMAT") != null)
					{
						RDO_FORMAT.SelectedValue		= conn.GetFieldValue("FORMAT").ToString();
					}

					TXT_PERIHAL.Text					= conn.GetFieldValue("PERIHAL").ToString().Replace("&nbsp;","");
					TXT_PENERBIT_DOC.Text				= conn.GetFieldValue("ISSUER").ToString().Replace("&nbsp;","");
					TXT_TEMPAT_PENYIMPANAN.Text			= conn.GetFieldValue("PLACE_DOC").ToString().Replace("&nbsp;","");
					TXT_TERBIT_DAY.Text					= tools.FormatDate_Day(conn.GetFieldValue("ISSUER_DATE").ToString());
					DDL_TERBIT_MONTH.SelectedValue		= tools.FormatDate_Month(conn.GetFieldValue("ISSUER_DATE").ToString());
					TXT_TERBIT_YEAR.Text				= tools.FormatDate_Year(conn.GetFieldValue("ISSUER_DATE").ToString());
					TXT_JATUH_TEMPO_DAY.Text			= tools.FormatDate_Day(conn.GetFieldValue("EXPIRED_DATE").ToString());
					DDL_JATUH_TEMPO_MONTH.SelectedValue = tools.FormatDate_Month(conn.GetFieldValue("EXPIRED_DATE").ToString());
					TXT_JATUH_TEMPO_YEAR.Text			= tools.FormatDate_Year(conn.GetFieldValue("EXPIRED_DATE").ToString());
					TXT_ISI_DOC.Text					= conn.GetFieldValue("DOC_CONTENT").ToString().Replace("&nbsp;","");
					TXT_NOTARIS.Text					= conn.GetFieldValue("NOTARY").ToString().Replace("&nbsp;","");
					TXT_PENJELASAN.Text					= conn.GetFieldValue("REMARK").ToString().Replace("&nbsp;","");
					break;

				case "delete":
					conn.QueryString = "DELETE SDC_DOC_UMUM WHERE SEQ = '" + e.Item.Cells[0].Text.ToString() + "' AND CU_REF = '" + Request.QueryString["curef"] + "' AND DOC_GROUP = '3'";
					conn.ExecuteQuery();

					FillDataGrid();
					break;
			}
		}
	}
}
