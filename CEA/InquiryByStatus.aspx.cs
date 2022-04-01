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
	/// Summary description for InquiryByStatus.
	/// </summary>
	public partial class InquiryByStatus : System.Web.UI.Page
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

				conn.QueryString = "select rekanan_ref, namerekanan, rfzipcd, rfrekanantype from rekanan where rekanan_ref='00'";
				conn.ExecuteQuery();
				FillGridInfo();

				DDL_BLN.Items.Add(new ListItem("--Pilih--",""));

				for (int i = 1; i <= 12; i++)
					DDL_BLN.Items.Add(new ListItem(DateAndTime.MonthName(i, false), i.ToString()));	

				DDL_JNS_REKANAN.Items.Add(new ListItem("--Pilih--",""));
				conn.QueryString="select rekananid, rekanandesc from rfjenisrekanan where active='1'";
				conn.ExecuteQuery();
				for (int i = 0; i < conn.GetRowCount(); i++)
					DDL_JNS_REKANAN.Items.Add(new ListItem(conn.GetFieldValue(i,1), conn.GetFieldValue(i,0)));
				
				DatGrd.Visible=false;
				DatGrdInfo.Visible=true;
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
			this.DatGrdInfo.ItemCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.DatGrdInfo_ItemCommand);
			this.DatGrdInfo.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.DatGrdInfo_PageIndexChanged);

		}
		#endregion

		protected void BTN_FIND_Click(object sender, System.EventArgs e)
		{
			DatGrd.Visible=false;
			DatGrdInfo.Visible=true;
			DatGrd.CurrentPageIndex = 0;
			SearchData();
		}

		private void DatGrdInfo_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			
			switch (((LinkButton)e.CommandSource).CommandName)
			{
				case "View":	
					DatGrdInfo.Visible=false;
					DatGrd.Visible=true;

					conn.QueryString = "select th.regnum, rf.trackname, th.trackcode, th.th_trackdate, th.th_trackby, th.th_nextby ";
					conn.QueryString += "from rekanan_trackhistory th left outer join rftrack rf on th.trackcode=rf.trackcode where regnum='" + e.Item.Cells[1].Text + "' order by th_trackdate desc";
					conn.ExecuteQuery();

					LBL_REGNUM.Visible=true;
					LBL_REGNUM.Text = conn.GetFieldValue("regnum");
					
					FillGrid();
					break;				
			}
		}


		private void FillGridInfo()
		{
			DataTable dt = new DataTable();
			dt = conn.GetDataTable().Copy();
			DatGrdInfo.DataSource = dt;
			try 
			{
				DatGrdInfo.DataBind();
			} 
			catch 
			{
				DatGrdInfo.CurrentPageIndex = 0;
				DatGrdInfo.DataBind();
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
				DatGrd.Items[i].Cells[3].Text = tool.FormatDate(DatGrd.Items[i].Cells[3].Text, true);
			}
		}

		private void SearchData()
		{
			bool stop = false;
			LBL_REGNUM.Visible = false;

			string query1=""; //untuk kriteria rekanan company
			string query2=""; //untuk kriteria rekanan personal
			
			if(TXT_NAME.Text!="")
			{
				query1 += "and namerekanan LIKE '%" + TXT_NAME.Text + "%' ";
				//query2 += "and namerekanan LIKE '%" + TXT_NAME.Text + "%' ";
			}
			if(TXT_ID.Text!="")
			{
				query1 += "and id_number='" + TXT_ID.Text + "' ";
				//query2 += "and id_number='" + TXT_ID.Text + "' ";
				
			}
			if(DDL_JNS_REKANAN.SelectedValue!="")
			{
				query1 += "and rfrekanantype='" + DDL_JNS_REKANAN.SelectedValue + "' ";
				//query2 += "and rfrekanantype='" + DDL_JNS_REKANAN.SelectedValue + "' ";
				
			}
			if(TXT_REGNUM.Text!="")
			{
				query1 += "and regnum='" + TXT_REGNUM.Text + "' ";
				//query2 += "and regnum='" + TXT_REGNUM.Text + "' ";
				
			}
			if(TXT_TGL.Text!="" && DDL_BLN.SelectedValue!="" && TXT_THN.Text!="")
			{
				if (!GlobalTools.isDateValid(TXT_TGL.Text, DDL_BLN.SelectedValue, TXT_THN.Text)) 
				{
					GlobalTools.popMessage(this, "Format tanggal tidak valid!");
					return;
				}
				query1 = query1 + " and tgl_lahir=" + tool.ConvertDate(TXT_TGL.Text,DDL_BLN.SelectedValue,TXT_THN.Text);
				//query2 = query2 + " and dob=" + tool.ConvertDate(TXT_TGL.Text,DDL_BLN.SelectedValue,TXT_THN.Text);
			}

			if(query1!="")
			{
				conn.QueryString="select * from vw_rekanan_app where 1=1 " + query1;
				conn.ExecuteQuery();
				FillGridInfo();
			}
			
			/*if (TXT_NAME.Text != "")
			{
				conn.QueryString = "SELECT REKANAN_REF, REGNUM, NAMEREKANAN, ID_NUMBER, REKANANDESC FROM VW_REKANAN_COMPANY WHERE NAMEREKANAN LIKE '%" + TXT_NAME.Text + "%' AND AP_CURRTRACK='A1.5'";
				conn.QueryString += "UNION SELECT REKANAN_REF, REGNUM, NAMEREKANAN, ID_NUMBER, REKANANDESC FROM VW_REKANAN_PERSONAL WHERE NAMEREKANAN LIKE '%" + TXT_NAME.Text + "%' AND AP_CURRTRACK='A1.5'";
				conn.ExecuteQuery();
				FillGridInfo();
				
				stop = true;
			}

			else if (stop == false && TXT_ID.Text != "")
			{
				conn.QueryString = "select rekanan_ref, regnum, namerekanan, id_number, rekanandesc from vw_rekanan_company where id_number ='" + TXT_ID.Text + "' AND AP_CURRTRACK='A1.5'";
				conn.ExecuteQuery();
				if(conn.GetRowCount()==0)
				{
					conn.QueryString = "select rekanan_ref, regnum, namerekanan, id_number, rekanandesc from vw_rekanan_personal where id_number ='" + TXT_ID.Text + "' AND AP_CURRTRACK='A1.5'";
					conn.ExecuteQuery();
				}
				
				FillGridInfo();
				stop = true;
			}

			else if (stop == false && DDL_JNS_REKANAN.SelectedItem.Value != "")
			{
				string JenisRekanan = DDL_JNS_REKANAN.SelectedItem.Text.ToString();
				
				conn.QueryString = "SELECT REKANAN_REF, REGNUM, NAMEREKANAN, ID_NUMBER, REKANANDESC FROM VW_REKANAN_COMPANY WHERE REKANANDESC='" + JenisRekanan + "' AND AP_CURRTRACK='A1.5' union SELECT REKANAN_REF, REGNUM, NAMEREKANAN, ID_NUMBER, REKANANDESC FROM VW_REKANAN_PERSONAL WHERE REKANANDESC='" + JenisRekanan + "' AND AP_CURRTRACK='A1.5'";
				conn.ExecuteQuery();	
				FillGridInfo();
				stop = true;
			}

			else if (stop == false && TXT_REGNUM.Text != "")
			{		
				conn.QueryString = "select REKANANTYPEID from REKANAN, APPLICATION_REKANAN where REKANAN.REKANAN_REF=APPLICATION_REKANAN.REKANAN_REF AND APPLICATION_REKANAN.REGNUM='" + TXT_REGNUM.Text + "'";
				conn.ExecuteQuery();
				
				if (conn.GetFieldValue("REKANANTYPEID") == "01")
					conn.QueryString = "SELECT REKANAN_REF, REGNUM, NAMEREKANAN, ID_NUMBER, REKANANDESC FROM VW_REKANAN_COMPANY WHERE REGNUM='" + TXT_REGNUM.Text + "' AND AP_CURRTRACK='A1.5'";
				else if (conn.GetFieldValue("REKANANTYPEID") == "02")
					conn.QueryString = "SELECT REKANAN_REF, REGNUM, NAMEREKANAN, ID_NUMBER, REKANANDESC FROM VW_REKANAN_PERSONAL WHERE REGNUM='" + TXT_REGNUM.Text + "' AND AP_CURRTRACK='A1.5'";
				conn.ExecuteQuery();
				FillGridInfo();				
			}*/
		}

		private void DatGrdInfo_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			DatGrdInfo.CurrentPageIndex = e.NewPageIndex;
			SearchData();
		}
	}
}
