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

namespace SME.CreditOperations.RejectMaintenance
{
	/// <summary>
	/// Summary description for StructureCredit.
	/// </summary>
	public partial class StructureCredit : System.Web.UI.Page
	{
		protected Connection conn;

		protected void Page_Load(object sender, System.EventArgs e)
		{
			conn = (Connection) Session["Connection"];

			if (!Logic.AllowAccess(Session["GroupID"].ToString(), Request.QueryString["mc"], conn))
				Response.Redirect("/SME/Restricted.aspx");

			if (!IsPostBack)
			{
				if (Request.QueryString["apptype"] == "01")
					TXT_PRODUCTID.Enabled = false;
                /*
				GlobalTools.fillRefList(DDL_KETENTUAN_KREDIT, "select KET_CODE, KET_DESC from KETENTUAN_KREDIT where AP_REGNO = '" + Request.QueryString["regno"] + "'", false, conn);
				conn.QueryString = "SELECT KET_CODE FROM CUSTPRODUCT " +
                    "WHERE AP_REGNO = '" + Request.QueryString["regno"] +"' AND PRODUCTID = '" +
					Request.QueryString["productid"] + "' AND PROD_SEQ = '" + Request.QueryString["prod_seq"] + "'";
				conn.ExecuteQuery();
				try
				{
					DDL_KETENTUAN_KREDIT.SelectedValue = conn.GetFieldValue(0,0);
					DDL_KETENTUAN_KREDIT.Enabled = false;
					viewdata(DDL_KETENTUAN_KREDIT.SelectedValue);
					viewKetentuanKredit(DDL_KETENTUAN_KREDIT.SelectedValue);
				} 
				catch {}*/
				//viewdata();
                viewAllKetentuanKredit();
			}
		}

        void viewAllKetentuanKredit()
        {
            conn.QueryString = "SELECT * FROM [VW_CREOPR_REJECTMAINTENANCE_LIST_KETKREDIT] WHERE [STATUS] = 'Failed' AND AP_REGNO = '" + Request.QueryString["regno"] + "'";
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

		void viewdata(string KET_CODE, string regno, string apptype, string productid, string prodseq)
		{
            conn.QueryString = "select * from VW_PRODUCTLIST where ap_regno ='" + regno +
                "' and apptype = '" + apptype + "' and productid = '" +
                productid + "' and PROD_SEQ = '" + prodseq + 
				"' and KET_CODE = '" + KET_CODE + "'";
			conn.ExecuteQuery();
			DataTable dt = new DataTable();
			dt = conn.GetDataTable().Copy();
			int jmlCell = dt.Rows.Count;
			int jmlRow = HitungRow(jmlCell);
			int cellKe = 0;

			for (int i = 0; i < jmlRow ; i++) // Jumlah Row = 3
			{
				int posisi = 0;
				if (cellKe == jmlCell)
					break;
				for (int j = 0; j < 3; j++) // Jumlah Cell per Row = 3
				{
					if (cellKe == jmlCell)
						break;
					this.Table1.Rows.Add(new TableRow());
						
					HyperLink t = new HyperLink();
					//t.Text = dt.Rows[i+j][1]+" "+dt.Rows[i+j][2]+" ("+dt.Rows[i+j][3]+")";
					t.Text = dt.Rows[cellKe][1]+" "+dt.Rows[cellKe][2]+" ("+dt.Rows[cellKe][3]+")";
					t.CssClass = "White";
					t.Font.Bold = true;

					if (dt.Rows[cellKe][0].ToString() == "01")
					{
						conn.QueryString = "select iscashloan from rfproduct where productid='" + dt.Rows[cellKe][1].ToString() + "'";
						conn.ExecuteQuery();
						if (conn.GetFieldValue(0,0) == "0")
							conn.QueryString = "select screenlink from apptypelink where APPTYPEID = '"+ dt.Rows[cellKe][0] + "' and PRODUCTID='" + "M21" + "' and fungsiId='CS' and iscashloan='0'";
						else	conn.QueryString = "select screenlink from apptypelink where APPTYPEID = '"+ dt.Rows[cellKe][0] + "' and PRODUCTID='" + "M21" + "' and fungsiId='CS' and iscashloan='1'";
					}
					else
						conn.QueryString = "select screenlink from apptypelink where APPTYPEID = '"+ dt.Rows[cellKe][0] + "' and PRODUCTID='" + "M21" + "' and fungsiId='CS' ";
					conn.ExecuteQuery();
					t.NavigateUrl = "../../RejectMaintenanceDE/" + conn.GetFieldValue("screenlink")+"?regno="+Request.QueryString["regno"] + 
						"&apptype="+dt.Rows[cellKe][0] +
                        "&prodid=" + productid + 
						"&teks="+t.Text + 
						"&de=" + Request.QueryString["de"] +
                        "&prod_seq=" + prodseq;
					t.Target = "ProdDetail";
					this.Table1.Rows[i].Cells.Add(new TableCell());
					//this.Table1.Rows[rowKe].Cells[posisi].Text = (j+i+1) +". ";
					this.Table1.Rows[i].Cells[posisi].Text = (cellKe+1) +". ";
					this.Table1.Rows[i].Cells[posisi].VerticalAlign=VerticalAlign.Top;
					this.Table1.Rows[i].Cells.Add(new TableCell());
					this.Table1.Rows[i].Cells[posisi+1].Controls.Add(t);
					this.Table1.Rows[i].Cells[posisi+1].VerticalAlign=VerticalAlign.Top;
					posisi +=2;
					cellKe++;
				}
				//rowKe++;
				//jmlCell -=3;
				if (cellKe == jmlCell)
					break;
			}
			conn.ClearData();
		}

		int HitungRow(int count)
		{
			int jml = count/3;
			int mod = count % 3;
			if (mod == 0)
				return jml;
			else
				return jml+1;

		}

		private void viewKetentuanKredit(string KET_CODE) 
		{
			try 
			{
				conn.QueryString = "select * from VW_REJECTMAIN_KET_KREDIT where KET_CODE = '" + KET_CODE + "'";
				conn.ExecuteQuery();

				TXT_AA_NO.Text = conn.GetFieldValue(0,"AA_NO");
				TXT_ACC_NO.Text = conn.GetFieldValue(0,"ACC_NO");
				TXT_PRODUCTID.Text = conn.GetFieldValue(0,"CP_FACILITY_CODE");
				TXT_ACC_SEQ.Text = conn.GetFieldValue(0,"ACC_SEQ");
			} 
			catch (NullReferenceException) 
			{
				Tools.popMessage(this, "Connection Error !");
				return;
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

		protected void DDL_KETENTUAN_KREDIT_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			try
			{
				//viewdata(DDL_KETENTUAN_KREDIT.SelectedValue);
				//viewKetentuanKredit(DDL_KETENTUAN_KREDIT.SelectedValue);
			} 
			catch{}
		}

		protected void BTN_SAVE_KREDIT_Click(object sender, System.EventArgs e)
		{
			conn.QueryString = "EXEC REJECTMAIN_KET_KREDIT '" + DDL_KETENTUAN_KREDIT.SelectedValue +
				"'," + GlobalTools.ConvertNull(TXT_AA_NO.Text) + "," + 
				GlobalTools.ConvertNull(TXT_ACC_NO.Text) + "," +
				GlobalTools.ConvertNull(TXT_PRODUCTID.Text) + "," +
				GlobalTools.ConvertNull(TXT_ACC_SEQ.Text);
			conn.ExecuteNonQuery();
			try
			{
				//viewdata(DDL_KETENTUAN_KREDIT.SelectedValue);
				//viewKetentuanKredit(DDL_KETENTUAN_KREDIT.SelectedValue);
			} 
			catch{}
		}

        protected void DataGrid1_ItemCommand(object source, DataGridCommandEventArgs e)
        {
            switch (((LinkButton)e.CommandSource).CommandName)
            {
                case "view":
                    string KET_CODE = e.Item.Cells[4].Text.Trim();
                    string APPTYPE = e.Item.Cells[2].Text.Trim();
                    string PRODUCTID = e.Item.Cells[3].Text.Trim();
                    string PRODSEQ = e.Item.Cells[13].Text.Trim();
                    string regno = e.Item.Cells[0].Text.Trim();

                    viewdata(KET_CODE, regno, APPTYPE, PRODUCTID, PRODSEQ);
                    break;
            }
        }
	}
}
