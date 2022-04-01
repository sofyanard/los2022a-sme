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
	/// Summary description for Analisa.
	/// </summary>
	public partial class Analisa : System.Web.UI.Page
	{
		protected Connection conn;
		protected Tools tool = new Tools();
	
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
				
				DDL_BLN_LAHIR.Items.Add(new ListItem("--Pilih--",""));
				for (int i = 1; i <= 12; i++)
					DDL_BLN_LAHIR.Items.Add(new ListItem(DateAndTime.MonthName(i, false), i.ToString()));	
				conn.QueryString = "select rekanan_ref, namerekanan, rfzipcd, rfrekanantype from rekanan where rekanan_ref='00'";
				conn.ExecuteQuery();
				FillGrid();

				DDL_JNS_REKANAN.Items.Add(new ListItem("--Pilih--",""));
				conn.QueryString="select rekananid, rekanandesc from rfjenisrekanan where active='1'";
				conn.ExecuteQuery();
				for (int i = 0; i < conn.GetRowCount(); i++)
					DDL_JNS_REKANAN.Items.Add(new ListItem(conn.GetFieldValue(i,1), conn.GetFieldValue(i,0)));

				//conn.QueryString="select rekanan_ref, regnum, namerekanan, id_number, rekanandesc from vw_rekanan_company where AP_CURRTRACK='A1.3' " +
				//	" union select rekanan_ref, regnum, namerekanan, id_number, rekanandesc from vw_rekanan_personal where AP_CURRTRACK='A1.3' ";
				if(Session["BranchID"].ToString() == "99999")
					conn.QueryString = "select * from vw_rekanan_search where ap_currtrack='A1.3'";
				else
					conn.QueryString = "select * from vw_rekanan_search where ap_currtrack='A1.3' and areaid='" + Session["AreaID"].ToString() + "'";
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
		}
		private void DatGrd_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			string area="";
			switch (((LinkButton)e.CommandSource).CommandName)
			{
				case "Continue":
					conn.QueryString = "select rfarea.areaid, rfarea.areaname from rekanan left outer join rfarea on rekanan.rekanan_wilayah=rfarea.areaid where rekanan_ref='" + e.Item.Cells[0].Text + "'";
					conn.ExecuteQuery();
					area = Session["AreaID"].ToString();
					if ((conn.GetFieldValue(0,0) == "") || (conn.GetFieldValue(0,0) == Session["AreaID"].ToString())  || Session["BranchID"].ToString() == "99999")
					{
						conn.QueryString = "exec REKANAN_GENERATE_ID '" + Session["BranchID"].ToString() + "', '0'";
						conn.ExecuteQuery();
						Response.Redirect("AnalisaMain.aspx?rekanan_ref=" + e.Item.Cells[0].Text + "&tc=" + Request.QueryString["tc"] + "&mc=" + Request.QueryString["mc"] + "&regnum=" + e.Item.Cells[1].Text + "&exist=1") ;
								
					}
					else
					{
						Response.Write("<script language='javascript'>alert('" + "Rekanan ini merupakan rekanan: " + conn.GetFieldValue("areaname") + "');</script>");
					}
					break;
			}
		}
		private void DatGrd_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			DatGrd.CurrentPageIndex = e.NewPageIndex;
			SearchData();
		}
		protected void BTN_FIND_Click(object sender, System.EventArgs e)
		{
			DatGrd.CurrentPageIndex = 0;
			SearchData();
		}
		private void SearchData()
		{
			string query1=""; //untuk kriteria rekanan company
			//string query2=""; //untuk kriteria rekanan personal
			
			if(TXT_REK_NAME.Text!="")
			{
				query1 += "and namerekanan LIKE '%" + TXT_REK_NAME.Text + "%' ";
				//query2 += "and namerekanan LIKE '%" + TXT_REK_NAME.Text + "%' ";
			}
			if(TXT_REK_ID.Text!="")
			{
				query1 += "and npwp='" + TXT_REK_ID.Text + "' ";
				//query1 += "and id_number='" + TXT_REK_ID.Text + "' ";
				//query2 += "and id_number='" + TXT_REK_ID.Text + "' ";
				
			}
			if(DDL_JNS_REKANAN.SelectedValue!="")
			{
				query1 += "and rfrekanantype='" + DDL_JNS_REKANAN.SelectedValue + "' ";
				//query2 += "and rfrekanantype='" + DDL_JNS_REKANAN.SelectedValue + "' ";
				
			}
			if(TXT_NoReg.Text!="")
			{
				query1 += "and regnum='" + TXT_NoReg.Text + "' ";
				//query2 += "and regnum='" + TXT_NoReg.Text + "' ";
				
			}
			if(TXT_TGL_LAHIR.Text!="" || DDL_BLN_LAHIR.SelectedValue!="" || TXT_THN_LAHIR.Text!="")
			{
				if (!GlobalTools.isDateValid(TXT_TGL_LAHIR.Text, DDL_BLN_LAHIR.SelectedValue, TXT_THN_LAHIR.Text)) 
				{
					GlobalTools.popMessage(this, "Format tanggal tidak valid!");
					return;
				}
				query1 = query1 + " and tgl_lahir=" + tool.ConvertDate(TXT_TGL_LAHIR.Text,DDL_BLN_LAHIR.SelectedValue,TXT_THN_LAHIR.Text);
				//query1 = query1 + " and istablish_date=" + tool.ConvertDate(TXT_TGL_LAHIR.Text,DDL_BLN_LAHIR.SelectedValue,TXT_THN_LAHIR.Text);
				//query2 = query2 + " and dob=" + tool.ConvertDate(TXT_TGL_LAHIR.Text,DDL_BLN_LAHIR.SelectedValue,TXT_THN_LAHIR.Text);
			}

		//	if(query1!="")
		//	{
				//conn.QueryString="select rekanan_ref, regnum, namerekanan, id_number, rekanandesc from vw_rekanan_company where AP_CURRTRACK='A1.3' " + query1 +
				//	" union select rekanan_ref, regnum, namerekanan, id_number, rekanandesc from vw_rekanan_personal where AP_CURRTRACK='A1.3' " + query2;
				conn.QueryString = "select * from vw_rekanan_search where ap_currtrack='A1.3' and areaid='" + Session["AreaID"].ToString() + "' " + query1;
				conn.ExecuteQuery();
				FillGrid();
		//	}
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
			this.DatGrd.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.DatGrd_PageIndexChanged_1);

		}
		#endregion

		private void DatGrd_PageIndexChanged_1(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			DatGrd.CurrentPageIndex = e.NewPageIndex;
			SearchData();
		}
	}
}
