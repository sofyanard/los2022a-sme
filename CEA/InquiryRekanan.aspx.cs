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
using DMS.DBConnection;
using DMS.CuBESCore;
using Microsoft.VisualBasic;


namespace SME.CEA
{
	/// <summary>
	/// Summary description for InquiryRekanan.
	/// </summary>
	public partial class InquiryRekanan : System.Web.UI.Page
	{
		protected Connection conn;
		protected Tools tool=new Tools();
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			conn = (Connection) Session["Connection"];

			if (!Logic.AllowAccess(Session["GroupID"].ToString(), Request.QueryString["mc"], conn))
				Response.Redirect("/SME/Restricted.aspx");

			if (!IsPostBack)
			{
				if (Request.QueryString["msg"] != "" && Request.QueryString["msg"] != null) 
					GlobalTools.popMessage(this, Request.QueryString["msg"]);

				conn.QueryString = "select REGNUM, namarekanan, rfrekanantype, approval_date from rekanan_approval_decision where regnum='00'";
				conn.ExecuteQuery();
				FillGrid();

				DDL_BLN.Items.Add(new ListItem("--Pilih--",""));

				for (int i = 1; i <= 12; i++)
					DDL_BLN.Items.Add(new ListItem(DateAndTime.MonthName(i, false), i.ToString()));	

				DDL_JNS_REKANAN.Items.Add(new ListItem("--Pilih--",""));
				conn.QueryString="select rekananid, rekanandesc from rfjenisrekanan where active='1'";
				conn.ExecuteQuery();
				for (int i = 0; i < conn.GetRowCount(); i++)
					DDL_JNS_REKANAN.Items.Add(new ListItem(conn.GetFieldValue(i,1), conn.GetFieldValue(i,0)));

				conn.QueryString="SELECT REKANAN_REF, REGNUM, NAMEREKANAN, APPROVAL_DATE, REKANANDESC from VW_REKANAN_COMPANY_INQUIRY where AP_CURRTRACK='A1.5' " +
					" union SELECT REKANAN_REF, REGNUM, NAMEREKANAN, APPROVAL_DATE, REKANANDESC from VW_REKANAN_PERSONAL_INQUIRY where AP_CURRTRACK='A1.5' ";
				conn.ExecuteQuery();
				FillGrid();
			}
		}

		private void FillGrid()
		{
			DataTable dt = new DataTable();
			dt = conn.GetDataTable().Copy();
			DatGrd.DataSource = dt;
			try 
			{
				DatGrd.DataBind();
			} 
			catch 
			{
				DatGrd.CurrentPageIndex = 0;
				DatGrd.DataBind();
			}
			for (int i = 0; i < DatGrd.Items.Count; i++)
			{
				DatGrd.Items[i].Cells[4].Text = tool.FormatDate(DatGrd.Items[i].Cells[4].Text, true);
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
			this.DatGrd.ItemCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.DatGrd_ItemCommand);
			this.DatGrd.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.DatGrd_PageIndexChanged);

		}
		#endregion

		protected void BTN_FIND_Click(object sender, System.EventArgs e)
		{
			DatGrd.CurrentPageIndex = 0;
			SearchData();
		}

		private void DatGrd_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			DatGrd.CurrentPageIndex = e.NewPageIndex;
			SearchData();
		}

		private void SearchData()
		{
			string query1=""; //untuk kriteria rekanan company
			string query2=""; //untuk kriteria rekanan personal
			
			if(TXT_NAME.Text!="")
			{
				query1 += "and namerekanan LIKE '%" + TXT_NAME.Text + "%' ";
				query2 += "and namerekanan LIKE '%" + TXT_NAME.Text + "%' ";
			}
			if(TXT_ID.Text!="")
			{
				query1 += "and id_number='" + TXT_ID.Text + "' ";
				query2 += "and id_number='" + TXT_ID.Text + "' ";
				
			}
			if(DDL_JNS_REKANAN.SelectedValue!="")
			{
				string JenisRekanan = DDL_JNS_REKANAN.SelectedItem.Text.ToString();
				query1 += "and REKANANDESC='" + JenisRekanan + "' ";
				query2 += "and REKANANDESC='" + JenisRekanan + "' ";
				
			}
			if(TXT_REGNUM.Text!="")
			{
				query1 += "and regnum='" + TXT_REGNUM.Text + "' ";
				query2 += "and regnum='" + TXT_REGNUM.Text + "' ";
				
			}
			if(TXT_TGL.Text!="" && DDL_BLN.SelectedValue!="" && TXT_THN.Text!="")
			{
				if (!GlobalTools.isDateValid(TXT_TGL.Text, DDL_BLN.SelectedValue, TXT_THN.Text)) 
				{
					GlobalTools.popMessage(this, "Format tanggal tidak valid!");
					return;
				}
				query1 = query1 + " and istablish_date=" + tool.ConvertDate(TXT_TGL.Text,DDL_BLN.SelectedValue,TXT_THN.Text);
				query2 = query2 + " and dob=" + tool.ConvertDate(TXT_TGL.Text,DDL_BLN.SelectedValue,TXT_THN.Text);
			}

			//if(query1!="")
			//{
				conn.QueryString="SELECT REKANAN_REF, REGNUM, NAMEREKANAN, APPROVAL_DATE, REKANANDESC from VW_REKANAN_COMPANY_INQUIRY where AP_CURRTRACK='A1.5' " + query1 +
					" union SELECT REKANAN_REF, REGNUM, NAMEREKANAN, APPROVAL_DATE, REKANANDESC from VW_REKANAN_PERSONAL_INQUIRY where AP_CURRTRACK='A1.5' " + query2;
				conn.ExecuteQuery();
				FillGrid();
			//}
		}

			private void DatGrd_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
			{
			
				switch (((LinkButton)e.CommandSource).CommandName)
				{
					case "View":	
						Response.Redirect("DataRekanan.aspx?rekanan_ref=" + e.Item.Cells[0].Text + "&tc=" + Request.QueryString["tc"] + "&mc=" + Request.QueryString["mc"] + "&regnum=" + e.Item.Cells[1].Text + "&exist=1&flag=1&view=1");
						break;				
				}
			}
	}
}
