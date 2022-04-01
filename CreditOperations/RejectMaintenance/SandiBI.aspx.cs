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
using DMS.DBConnection;
using DMS.CuBESCore;

namespace SME.CreditOperations.RejectMaintenance
{
	/// <summary>
	/// Summary description for SandiBI.
	/// </summary>
	public partial class SandiBI : System.Web.UI.Page
	{
		protected Connection conn;
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			conn = (Connection) Session["Connection"];

			if (!Logic.AllowAccess(Session["GroupID"].ToString(), Request.QueryString["mc"], conn))
				Response.Redirect("/SME/Restricted.aspx");

			if(!IsPostBack)
			{
				//ViewList();
                viewAllKetentuanKredit();
			}
		}

        void viewAllKetentuanKredit()
        {
            conn.QueryString = "SELECT * FROM [VW_CREOPR_REJECTMAINTENANCE_LIST_KETKREDIT] WHERE AP_REGNO = '" + Request.QueryString["regno"] + "'";
            conn.ExecuteQuery();

            DataGrid1.DataSource = conn.GetDataTable().Copy();
            try
            {
                DataGrid1.DataBind();
            }
            catch
            {
                DataGrid1.CurrentPageIndex = 0;
                DataGrid1.DataBind();
            }
        }

		private void ViewList(string regno, string apptype, string cpproductid, string prodseq)
		{
			conn.QueryString = "select distinct PR.PRODUCTID, PR.PRODUCTDESC "+
				"from CUSTPRODUCT CP join RFPRODUCT PR on PR.PRODUCTID = CP.PRODUCTID "+
                "where CP.AP_REGNO = '" + regno + "' and cp.apptype = '" +
                apptype + "' and cp.productid = '" + cpproductid +
                "' and cp.prod_seq = '" + prodseq + "'";
			conn.ExecuteQuery();
			int row = conn.GetRowCount();
			string productid;
			if (row == 0)
				Tools.popMessage(this, "Sandi BI hanya untuk Permohonan Baru");
			else
				for (int i = 0; i < row; i++)
				{
					productid = conn.GetFieldValue(i, 0);
					HyperLink t = new HyperLink();
					t.Text = productid +" - "+conn.GetFieldValue(i, 1);
					t.CssClass = "TDBGColor1";
					t.Font.Bold = true;

                    t.NavigateUrl = "../../DataEntry/DetailSandiBIData.aspx?regno=" + regno +
						"&curef=" + Request.QueryString["curef"] + "&tc=" + Request.QueryString["tc"] +
                        "&productid=" + cpproductid + "&de=" + Request.QueryString["de"] +
                        "&prod_seq=" + prodseq;
					t.Target = "frm_sandibi";
					this.TBL_FASILITAS.Rows.Add(new TableRow());
					this.TBL_FASILITAS.Rows[i].Cells.Add(new TableCell());
					this.TBL_FASILITAS.Rows[i].Cells[0].Controls.Add(t);
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

        protected void DataGrid1_ItemCommand(object source, DataGridCommandEventArgs e)
        {
            switch (((LinkButton)e.CommandSource).CommandName)
            {
                case "view":

                    string KET_CODE = e.Item.Cells[4].Text.Trim();
                    string apptype = e.Item.Cells[2].Text.Trim();
                    string cpproductid = e.Item.Cells[3].Text.Trim();
                    string prodseq = e.Item.Cells[13].Text.Trim();
                    string regno = e.Item.Cells[0].Text.Trim();

                    ViewList(regno, apptype, cpproductid, prodseq);
                    break;
            }
        }
	}
}
