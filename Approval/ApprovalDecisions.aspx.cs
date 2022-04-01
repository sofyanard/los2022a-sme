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

namespace SME.Approval
{
	/// <summary>
	/// Summary description for ApprovalDecisions.
	/// </summary>
	public partial class ApprovalDecisions : System.Web.UI.Page
	{
		//protected Connection conn = new Connection("Data Source=10.123.12.30;Initial Catalog=SMEDEV;uid=sa;pwd=");
		protected Connection conn;
		protected Tools tool = new Tools();
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			conn = (Connection) Session["Connection"];

			if (!Logic.AllowAccess(Session["GroupID"].ToString(), Request.QueryString["mc"], conn))
				Response.Redirect("../Restricted.aspx");

			if (!IsPostBack)
			{
				viewdata();
			}
		}
		private void viewdata()
		{
			lbl_regno.Text	 = Request.QueryString["regno"];
			lbl_curef.Text	 = Request.QueryString["curef"];
			lbl_prod.Text	 = Request.QueryString["prod"];
			lbl_apptype.Text = Request.QueryString["apptype"];
			lbl_track.Text	 = Request.QueryString["tc"];
			lbl_userid.Text	 = Session["USERID"].ToString();

			//conn.QueryString = "select * from vw_approvaldecision where ap_regno = '"+lbl_regno.Text+"' and productid = '"+lbl_prod.Text+"' and apptype = '"+lbl_apptype.Text+"' order by ad_seq";
			conn.QueryString = "select * from vw_approvaldecision "+
							   " where ap_regno = '"+lbl_regno.Text+"' "+
							   " and userid <> '"+lbl_userid.Text+"' "+
							   " order by ad_seq";
			//Response.Write (conn.QueryString);
			//Response.End();
			conn.ExecuteQuery();

			/*int tblRowCount = tbl_decision.Rows.Count;
			for (int i = tblRowCount - 1; i >= 0; i--)
				tbl_decision.Rows.Remove(tbl_decision.Rows[i]);*/

			int row = conn.GetRowCount();
			int j = 0;
			for (int i = 0; i < row; i++)
			{
				Label lbl_header		= new Label();
				lbl_header.Text			= conn.GetFieldValue(i,5) + "  Decision";
			
				Table tbl_data1			= new Table();

				Label lbl_prod1			= new Label();
				lbl_prod1.Text			= "Jenis Pengajuan";
				TextBox txt_prod		= new TextBox();
				txt_prod.Text			= conn.GetFieldValue(i,3);
				txt_prod.ReadOnly		= true;
				txt_prod.Columns		= 45;
				
				Label lbl_limit			= new Label();
				lbl_limit.Text			= "Limit";
				TextBox txt_limit		= new TextBox();
				txt_limit.Text			= tool.MoneyFormat(conn.GetFieldValue(i,6));
				txt_limit.ReadOnly		= true;

				Label lbl_tenor			= new Label();
				lbl_tenor.Text			= "Tenor";
				TextBox txt_tenor		= new TextBox();
				txt_tenor.Text			= conn.GetFieldValue(i,7);
				txt_tenor.ReadOnly		= true;
				txt_tenor.Columns		= 4;
				Label lbl_tenorcode		= new Label();
				lbl_tenorcode.Text		= conn.GetFieldValue(i,8);
				
				Label lbl_interest		= new Label();
				lbl_interest.Text		= "Interest/p.a";
				TextBox txt_interest	= new TextBox();
				txt_interest.Text		= tool.ConvertFloat(conn.GetFieldValue(i,9));
				txt_interest.ReadOnly	= true;
				txt_interest.Columns	= 5;

				Label lbl_rate			= new Label();
				lbl_rate.Text			= "Interest Type";
				TextBox txt_rate		= new TextBox();
				txt_rate.Text			= Convert.ToString(double.Parse(conn.GetFieldValue(i,10)) * 100);
				txt_rate.Columns		= 5;
				txt_rate.ReadOnly		= true;

				Label lbl_percent		= new Label();
				lbl_percent.Text		= "%";
				
				TextBox txt_varcode		= new TextBox();
				txt_varcode.Text		= conn.GetFieldValue(i,11);
				txt_varcode.ReadOnly	= true;
				txt_varcode.Columns		= 2;

				TextBox txt_variance	= new TextBox();
				txt_variance.Text		= conn.GetFieldValue(i,12);
				txt_variance.ReadOnly	= true;
				txt_variance.Columns	= 2;

				Label lbl_percent1		= new Label();
				lbl_percent1.Text		= "%";

				Label lbl_installment	= new Label();
				lbl_installment.Text	= "Installment";
				TextBox txt_installment = new TextBox();
				txt_installment.Text	= tool.MoneyFormat(conn.GetFieldValue(i,17));
				txt_installment.ReadOnly= true;

				Label lbl_status		= new Label();
				lbl_status.Text			= "Status";
				TextBox txt_status		= new TextBox();
				txt_status.Text			= conn.GetFieldValue(i,20);
				txt_status.ReadOnly		= true;

				Table tbl_data2			= new Table();

				Label lbl_ovrsta		= new Label();
				lbl_ovrsta.Text			= "Override Status";
				TextBox txt_ovrsta		= new TextBox();
				txt_ovrsta.Text			= conn.GetFieldValue(i,13);
				txt_ovrsta.ReadOnly		= true;

				Label lbl_ovrreason		= new Label();
				lbl_ovrreason.Text		= "Override Reason";
				TextBox txt_ovrreason	= new TextBox();
				txt_ovrreason.Text		= conn.GetFieldValue(i,14);
				txt_ovrreason.ReadOnly	= true;
			
				TextBox txt_ovrreasontext= new TextBox();
				txt_ovrreasontext.Text	= conn.GetFieldValue(i,15);
				txt_ovrreasontext.ReadOnly= true;
				txt_ovrreasontext.Columns= 50;

				Label lbl_remark		= new Label();
				lbl_remark.Text			= "Remark";
				TextBox txt_remark		= new TextBox();
				txt_remark.Text			= conn.GetFieldValue(i,16);
				txt_remark.ReadOnly		= true;
				txt_remark.TextMode		= TextBoxMode.MultiLine;
				txt_remark.Columns		= 50;
				txt_remark.Height		= 40;

				Label lbl_decby			= new Label();
				lbl_decby.Text			= "Decision By";
				TextBox txt_decby		= new TextBox();
				txt_decby.Text			= conn.GetFieldValue(i,18);
				txt_decby.ReadOnly		= true;
				txt_decby.Columns		= 40;

				Label lbl_decdate		= new Label();
				lbl_decdate.Text		= "Decision Date";
				TextBox txt_decdate		= new TextBox();
				txt_decdate.Text		= conn.GetFieldValue(i,19);
				txt_decdate.ReadOnly	= true;
		
				this.tbl_decision.Rows.Add(new TableRow());
				this.tbl_decision.Rows[j].Cells.Add(new TableCell());
				this.tbl_decision.Rows[j].Cells[0].Controls.Add(lbl_header);
				this.tbl_decision.Rows[j].Cells[0].Width = System.Web.UI.WebControls.Unit.Percentage(100);
				this.tbl_decision.Rows[j].Cells[0].CssClass = "tdHeader1";
				this.tbl_decision.Rows[j].Cells[0].ColumnSpan = 2;

				this.tbl_decision.Rows.Add(new TableRow());
				this.tbl_decision.Rows[j+1].Cells.Add(new TableCell());
				this.tbl_decision.Rows[j+1].Cells[0].Controls.Add(tbl_data1);
				this.tbl_decision.Rows[j+1].Cells[0].Width = System.Web.UI.WebControls.Unit.Percentage(50);
				this.tbl_decision.Rows[j+1].Cells[0].VerticalAlign = VerticalAlign.Top;
				this.tbl_decision.Rows[j+1].Cells[0].CssClass = "td";
				tbl_data1.Width = System.Web.UI.WebControls.Unit.Percentage(100);
				tbl_data1.CellPadding = 0;
				tbl_data1.CellSpacing = 0;
				addrow(tbl_data1, lbl_prod1, "TDBGColor1", txt_prod, "TDBGColorValue");
				addrow(tbl_data1, lbl_limit, "TDBGColor1", txt_limit, "TDBGColorValue");
				addrow(tbl_data1, lbl_tenor, "TDBGColor1", txt_tenor, "TDBGColorValue", lbl_tenorcode);
				if (conn.GetFieldValue(i,21) == "02")
					addrow(tbl_data1, lbl_interest, "TDBGColor1", txt_interest, "TDBGColorValue");
				else if (conn.GetFieldValue(i,21) == "01")
					addrow(tbl_data1, lbl_rate, "TDBGColor1", txt_rate, "TDBGColorValue", lbl_percent, txt_varcode, txt_variance, lbl_percent1);
				addrow(tbl_data1, lbl_installment, "TDBGColor1", txt_installment, "TDBGColorValue");
				addrow(tbl_data1, lbl_status, "TDBGColor1", txt_status, "TDBGColorValue");

				this.tbl_decision.Rows[j+1].Cells.Add(new TableCell());
				this.tbl_decision.Rows[j+1].Cells[1].Controls.Add(tbl_data2);
				this.tbl_decision.Rows[j+1].Cells[1].VerticalAlign = VerticalAlign.Top;
				this.tbl_decision.Rows[j+1].Cells[1].CssClass = "td";
				tbl_data2.Width = System.Web.UI.WebControls.Unit.Percentage(100);
				tbl_data2.CellPadding = 0;
				tbl_data2.CellSpacing = 0;
				addrow(tbl_data2, lbl_ovrsta, "TDBGColor1", txt_ovrsta, "TDBGColorValue");
				addrow(tbl_data2, lbl_ovrreason, "TDBGColor1", txt_ovrreason, "TDBGColorValue");
				addrow(tbl_data2, txt_ovrreasontext, "TDBGColorValue");
				addrow(tbl_data2, lbl_remark, "TDBGColor1", txt_remark, "TDBGColorValue");
				addrow(tbl_data2, lbl_decby, "TDBGColor1", txt_decby, "TDBGColorValue");
				addrow(tbl_data2, lbl_decdate, "TDBGColor1", txt_decdate, "TDBGColorValue");
				j = j + 2;
			}
			conn.ClearData();
		}

		private void addrow(Table tblname, Label lblname, string lblclass, TextBox txtname, string txtclass, Label lblname1, TextBox txtname1, TextBox txtname2, Label lblname2)
		{
			tblname.Rows.Add(new TableRow());
			int rc = tblname.Rows.Count - 1;
			tblname.Rows[rc].Cells.Add(new TableCell());
			tblname.Rows[rc].Cells.Add(new TableCell());
			tblname.Rows[rc].Cells.Add(new TableCell());
			tblname.Rows[rc].Cells.Add(new TableCell());
			tblname.Rows[rc].Cells.Add(new TableCell());
			tblname.Rows[rc].Cells[0].Controls.Add(lblname);
			tblname.Rows[rc].Cells[0].CssClass = lblclass;
			tblname.Rows[rc].Cells[0].Width = 200;
			tblname.Rows[rc].Cells[1].Width = 15;
			tblname.Rows[rc].Cells[2].Controls.Add(txtname);
			tblname.Rows[rc].Cells[2].CssClass = txtclass;
			tblname.Rows[rc].Cells[2].Controls.Add(lblname1);
			tblname.Rows[rc].Cells[2].Controls.Add(txtname1);
			tblname.Rows[rc].Cells[2].Controls.Add(txtname2);
			tblname.Rows[rc].Cells[2].Controls.Add(lblname2);
		}

		private void addrow(Table tblname, Label lblname, string lblclass, TextBox txtname, string txtclass, Label lblname1)
		{
			tblname.Rows.Add(new TableRow());
			int rc = tblname.Rows.Count - 1;
			tblname.Rows[rc].Cells.Add(new TableCell());
			tblname.Rows[rc].Cells.Add(new TableCell());
			tblname.Rows[rc].Cells.Add(new TableCell());
			tblname.Rows[rc].Cells.Add(new TableCell());
			tblname.Rows[rc].Cells.Add(new TableCell());
			tblname.Rows[rc].Cells[0].Controls.Add(lblname);
			tblname.Rows[rc].Cells[0].CssClass = lblclass;
			tblname.Rows[rc].Cells[0].Width = 200;
			tblname.Rows[rc].Cells[1].Width = 15;
			tblname.Rows[rc].Cells[2].Controls.Add(txtname);
			tblname.Rows[rc].Cells[2].CssClass = txtclass;
			tblname.Rows[rc].Cells[2].Controls.Add(lblname1);
		}

		private void addrow(Table tblname, Label lblname, string lblclass, TextBox txtname, string txtclass)
		{
			tblname.Rows.Add(new TableRow());
			int rc = tblname.Rows.Count - 1;
			tblname.Rows[rc].Cells.Add(new TableCell());
			tblname.Rows[rc].Cells.Add(new TableCell());
			tblname.Rows[rc].Cells.Add(new TableCell());
			tblname.Rows[rc].Cells[0].Controls.Add(lblname);
			tblname.Rows[rc].Cells[0].CssClass = lblclass;
			tblname.Rows[rc].Cells[0].Width = 200;
			tblname.Rows[rc].Cells[1].Width = 15;
			tblname.Rows[rc].Cells[2].Controls.Add(txtname);
			tblname.Rows[rc].Cells[2].CssClass = txtclass;
		}

		private void addrow(Table tblname, TextBox txtname, string txtclass)
		{
			tblname.Rows.Add(new TableRow());
			int rc = tblname.Rows.Count - 1;
			tblname.Rows[rc].Cells.Add(new TableCell());
			tblname.Rows[rc].Cells.Add(new TableCell());
			tblname.Rows[rc].Cells.Add(new TableCell());
			tblname.Rows[rc].Cells[2].Controls.Add(txtname);
			tblname.Rows[rc].Cells[2].CssClass = txtclass;
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

		protected void BTN_BACK_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			Response.Redirect("Approval.aspx?regno="+lbl_regno.Text+"&curef="+lbl_curef.Text+"&prod="+lbl_prod.Text+"&apptype="+lbl_apptype.Text+"&mc="+Request.QueryString["mc"]+"&tc="+lbl_track.Text);
		}
	}
}
