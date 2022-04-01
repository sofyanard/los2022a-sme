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
using Microsoft.VisualBasic;
using DMS.CuBESCore;
using DMS.DBConnection;


namespace SME.DisbursementWorksheet.NotaryAssignment
{
	/// <summary>
	/// Summary description for DetailLegalSigning_Data.
	/// </summary>
	public partial class DetailLegalSigning_Data : System.Web.UI.Page
	{

		protected Connection conn;
		protected Tools tool = new Tools();

		protected void Page_Load(object sender, System.EventArgs e)
		{
			conn = (Connection) Session["Connection"];

			if (!IsPostBack)
			{
				LBL_REGNO.Text = Request.QueryString["regno"];
				LBL_CUREF.Text = Request.QueryString["curef"];
				LBL_TC.Text = Request.QueryString["tc"];
				ViewData();
				bindData();
			}
			ViewMenu();
			DataGrid1.PageIndexChanged += new DataGridPageChangedEventHandler(this.Grid_Change);
		}

		private void ViewMenu()
		{
			try 
			{
				conn.QueryString = "select * from SCREENMENU where menucode = '"+Request.QueryString["mc"]+"'";
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
							strtemp = "regno=" + Request.QueryString["regno"] + "&curef="+Request.QueryString["curef"]+"&tc="+Request.QueryString["tc"];
						else	strtemp = "regno=" + Request.QueryString["regno"] + "&curef="+Request.QueryString["curef"]+"&mc="+Request.QueryString["mc"]+"&tc="+Request.QueryString["tc"];
						//t.ForeColor = Color.MidnightBlue; 
					}
					else 
					{
						strtemp = "";
						t.ForeColor = Color.Red; 
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

		private void ViewData()
		{
			conn.QueryString = "select * from VW_INFOUMUM "+
				"where AP_REGNO = '"+ LBL_REGNO.Text.Trim() +"' ";
			conn.ExecuteQuery();
			TXT_AP_REGNO.Text = conn.GetFieldValue("AP_REGNO");
			TXT_CU_REF.Text = conn.GetFieldValue("CU_REF");
			string AP_SIGNDATE = conn.GetFieldValue("AP_SIGNDATE");
			TXT_AP_SIGNDATE.Text = tool.FormatDate(AP_SIGNDATE);
			TXT_PROGRAMDESC.Text = conn.GetFieldValue("PROGRAMDESC");
			TXT_BRANCH_NAME.Text = conn.GetFieldValue("BRANCH_NAME");
			TXT_AP_TMLDRNM.Text = conn.GetFieldValue("AP_TMLDRNM");
			TXT_AP_RMNM.Text = conn.GetFieldValue("AP_RMNM");
			TXT_BU_DESC.Text = conn.GetFieldValue("BU_DESC");
			TXT_CU_NAME.Text = conn.GetFieldValue("CU_NAME");
			TXT_CU_ADDR1.Text = conn.GetFieldValue("CU_ADDR1");
			TXT_CU_ADDR2.Text = conn.GetFieldValue("CU_ADDR2");
			TXT_CU_ADDR3.Text = conn.GetFieldValue("CU_ADDR3");
			TXT_CU_CITYNM.Text = conn.GetFieldValue("CU_CITYNM");
			TXT_CU_PHN.Text = conn.GetFieldValue("CU_PHN");
			TXT_BUSSTYPEDESC.Text = conn.GetFieldValue("BUSSTYPEDESC");
		}

		private void bindData()
		{
			DataTable dt = new DataTable();
			DataRow dr;
			conn.QueryString = "SELECT SEQ, IC_DESC, IT_DESC, ALI_AMOUNT, ALI_PERCENTAGE, ALI_PREMI, "+
				"IC_ID, IT_ID, ALI_ICRATE, CURRENCYID, CURRENCYDESC, "+
				"ALI_POLICYNO, ALI_DATESTART, ALI_DATEEND " +
				"FROM VW_CREOPR_NOTARYASSIGN_INSURANCE WHERE AP_REGNO = '" + Request.QueryString["regno"] +
				"' ORDER BY IC_DESC ";
			conn.ExecuteQuery();
			dt.Columns.Add(new DataColumn("SEQ"));
			dt.Columns.Add(new DataColumn("INSRCOMPDESC"));
			dt.Columns.Add(new DataColumn("INSRTYPEDESC"));
			dt.Columns.Add(new DataColumn("AN_VALUE"));
			dt.Columns.Add(new DataColumn("AN_PERCENTAGE"));
			dt.Columns.Add(new DataColumn("AN_PREMI"));
			dt.Columns.Add(new DataColumn("IC_ID"));
			dt.Columns.Add(new DataColumn("IT_ID"));
			dt.Columns.Add(new DataColumn("RATE"));
			dt.Columns.Add(new DataColumn("CUR_ID"));
			dt.Columns.Add(new DataColumn("AN_CUR"));
			dt.Columns.Add(new DataColumn("AN_POLICYNO"));
			dt.Columns.Add(new DataColumn("AN_DATESTART"));
			dt.Columns.Add(new DataColumn("AN_DATEEND"));
			for (int i = 0; i < conn.GetRowCount(); i++) 
			{
				dr = dt.NewRow();
				for (int j = 0; j < conn.GetColumnCount(); j++)
				{
					dr[j] = conn.GetFieldValue(i,j);
				}
				dt.Rows.Add(dr);
			}
			DataGrid1.DataSource = new DataView(dt);
			DataGrid1.DataBind();
			for (int j = 0; j < DataGrid1.Items.Count; j++)
			{
				DataGrid1.Items[j].Cells[5].Text = tool.MoneyFormat(DataGrid1.Items[j].Cells[5].Text );
				DataGrid1.Items[j].Cells[8].Text = tool.MoneyFormat(DataGrid1.Items[j].Cells[8].Text );
				DataGrid1.Items[j].Cells[9].Text = tool.MoneyFormat(DataGrid1.Items[j].Cells[9].Text );
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
			this.DataGrid1.ItemCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.DataGrid1_ItemCommand);

		}
		#endregion

		void Grid_Change(Object sender, DataGridPageChangedEventArgs e) 
		{
			// Set CurrentPageIndex to the page the user clicked.
			DataGrid1.CurrentPageIndex = e.NewPageIndex;
			// Re-bind the data to refresh the DataGrid control. 
			bindData();	
		}

		private void DataGrid1_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			string regno, seq, cu_ref;
			switch(((LinkButton)e.CommandSource).CommandName)
			{
				case "print":
					//Response.Redirect("../CoverNote/AsuransiJiwa.aspx?ap_regno=" + LBL_REGNO.Text + "&cu_ref=" + LBL_CUREF.Text + "&seq=" + e.Item.Cells[0].Text.Trim());
					regno = TXT_AP_REGNO.Text.Trim();
					cu_ref = this.TXT_CU_REF.Text.Trim();			
					seq = e.Item.Cells[0].Text.Trim();
					Response.Write("<script language='javascript'>window.open('../CoverNote/AsuransiJiwa.aspx?seq=" + seq + "&regno=" + regno + "&cu_ref=" + cu_ref + "','AsuransiJiwa','status=no,scrollbars=yes,width=800,height=600');</script>");
					break;

				case "delete":
					regno = TXT_AP_REGNO.Text.Trim();
						seq = e.Item.Cells[0].Text.Trim();
					//delete data
					conn.QueryString = "delete from APPLIFEINSURANCE where AP_REGNO = '" +
						regno + "' AND SEQ = " + seq;
					conn.ExecuteNonQuery();
					bindData();
					break;

				default:
					// Do nothing.
					break;
			}

		}

		protected void BTN_BACK_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			Response.Redirect("/SME/" + DMS.CuBESCore.Logic.backLink(Request.QueryString["tc"].ToString(), conn));
		}
	}
}
