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
using DMS.BlackList;

namespace SME.CEA
{
	/// <summary>
	/// Summary description for InputJatuhTempo.
	/// </summary>
	public partial class InputJatuhTempo : System.Web.UI.Page
	{
		protected Tools tool = new Tools();
		protected System.Web.UI.WebControls.Button Button1;
		
		protected Connection conn;
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			conn = (Connection) Session["Connection"];

			/*if (!Logic.AllowAccess(Session["GroupID"].ToString(), Request.QueryString["mc"], conn))				
				Response.Redirect("/SME/Restricted.aspx");*/

			if(!IsPostBack)
			{
				if (Request.QueryString["msg"] != "" && Request.QueryString["msg"] != null) 
					GlobalTools.popMessage(this, Request.QueryString["msg"]);

				DDL_BLN_TEMPO.Items.Add(new ListItem("--Pilih--",""));				

				for(int i=1; i<=12; i++)
				{
					DDL_BLN_TEMPO.Items.Add(new ListItem(DateAndTime.MonthName(i, false), i.ToString()));					
				}

				DDL_BLN_TEMPO2.Items.Add(new ListItem("--Pilih--",""));				

				for(int j=1; j<=12; j++)
				{
					DDL_BLN_TEMPO2.Items.Add(new ListItem(DateAndTime.MonthName(j, false), j.ToString()));					
				}

				DDL_BLN_JT.Items.Add(new ListItem("--Pilih--", ""));

				for (int i=1; i<=12; i++)
				{
					DDL_BLN_JT.Items.Add(new ListItem(DateAndTime.MonthName(i, false), i.ToString()));
				}
				
				ViewData();

				ViewData2();

				TR_CATATAN.Visible=false;
				TR_BTN.Visible=false;
				TR_CATATAN2.Visible=false;
				TR_BTN2.Visible=false;
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

		private void FillGrid2()
		{
			DataTable dt = new DataTable();
			dt = conn.GetDataTable().Copy();
			DatGrd2.DataSource = dt;
			try 
			{
				DatGrd2.DataBind();
			} 
			catch 
			{
				DatGrd2.CurrentPageIndex = 0;
				DatGrd2.DataBind();
			}
			for (int i = 0; i < DatGrd2.Items.Count; i++)
			{
				DatGrd2.Items[i].Cells[5].Text = tool.FormatDate(DatGrd2.Items[i].Cells[5].Text, true);
			}
		}

		protected void BTN_FIND_Click(object sender, System.EventArgs e)
		{
			DatGrd.CurrentPageIndex = 0;
			SearchData();
		}

		protected void BTN_FIND2_Click(object sender, System.EventArgs e)
		{
			DatGrd.CurrentPageIndex = 0;
			SearchData2();
		}

		private void DatGrd_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			string area="";
			switch (((LinkButton)e.CommandSource).CommandName)
			{
				case "Continue":	
								
					TR_CATATAN.Visible=true;
					conn.QueryString="select * from application_rekanan where regnum='" + e.Item.Cells[1].Text + "'";
					conn.ExecuteQuery();
					TXT_TGL_TEMPO.Text = tool.FormatDate_Day(conn.GetFieldValue("TGL_JATUH_TEMPO"));
					try{DDL_BLN_TEMPO.SelectedValue = tool.FormatDate_Month(conn.GetFieldValue("TGL_JATUH_TEMPO"));}
					catch{DDL_BLN_TEMPO.SelectedValue="";}
					TXT_THN_TEMPO.Text = tool.FormatDate_Year(conn.GetFieldValue("TGL_JATUH_TEMPO"));
					
					TXT_REGNUM.Text =conn.GetFieldValue("regnum");
					TXT_NAME.Text = e.Item.Cells[2].Text;
					TXT_JNS.Text = e.Item.Cells[4].Text;
					TR_BTN.Visible=true;
					TR_CATATAN.Visible=true;
				break;
			}
		}	
	
		private void DatGrd2_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			string area="";
			switch (((LinkButton)e.CommandSource).CommandName)
			{
				case "Edit":	
								
					TR_CATATAN2.Visible=true;
					conn.QueryString="select * from application_rekanan where regnum='" + e.Item.Cells[1].Text + "'";
					conn.ExecuteQuery();
					TXT_TGL_TEMPO2.Text = tool.FormatDate_Day(conn.GetFieldValue("TGL_JATUH_TEMPO"));
					try{DDL_BLN_TEMPO2.SelectedValue = tool.FormatDate_Month(conn.GetFieldValue("TGL_JATUH_TEMPO"));}
					catch{DDL_BLN_TEMPO2.SelectedValue="";}
					TXT_THN_TEMPO2.Text = tool.FormatDate_Year(conn.GetFieldValue("TGL_JATUH_TEMPO"));
					
					TXT_REGNUM2.Text =conn.GetFieldValue("regnum");
					TXT_NAME2.Text = e.Item.Cells[2].Text;
					TXT_JNS2.Text = e.Item.Cells[4].Text;
					LBL_REKREF.Text = e.Item.Cells[0].Text;
					TR_BTN2.Visible=true;
					TR_CATATAN2.Visible=true;
					break;
			}
		}		

		protected void BTN_SAVE_Click(object sender, System.EventArgs e)
		{
			//Validasi Tanggal
			Int64 now = Int64.Parse(Tools.toISODate(DateTime.Now.Day.ToString(), DateTime.Now.Month.ToString(), DateTime.Now.Year.ToString())), compEstablish;
			Int64 tanggalJatuhTempo;			

			if (!GlobalTools.isDateValid(TXT_TGL_TEMPO.Text, DDL_BLN_TEMPO.SelectedValue, TXT_THN_TEMPO.Text)) 
			{
				GlobalTools.popMessage(this, "Tanggal Jatuh Tempo tidak valid!");
				return;
			}
			else 
			{			
				tanggalJatuhTempo = Int64.Parse(Tools.toISODate(TXT_TGL_TEMPO.Text, DDL_BLN_TEMPO.SelectedValue, TXT_THN_TEMPO.Text));

				if (tanggalJatuhTempo < now) 
				{
					GlobalTools.popMessage(this, "Tanggal Jatuh Tempo tidak bisa kurang dari tanggal saat ini!!");
					return;
				}
			}
			
			conn.QueryString=" exec REKANAN_INPUT_JATUH_TEMPO " + tool.ConvertDate(TXT_TGL_TEMPO.Text, DDL_BLN_TEMPO.SelectedValue, TXT_THN_TEMPO.Text) + ",  '"+ TXT_REGNUM.Text +"' ";
			conn.ExecuteNonQuery();
			ViewData();
			ClearData();

			ViewData2();			
		}

		private void AuditTrailCheck(string kodeJenisData)
		{
			string userName		= Session["FullName"].ToString();
			string status		= "update";
			string rekanan_ref	= LBL_REKREF.Text;
			string regnum		= TXT_REGNUM2.Text;
			string jenisrek		= TXT_JNS2.Text;
			string nama			= TXT_NAME2.Text;
			string temp			=   "";
			string sqlpar		=	rekanan_ref + "', '" +
				regnum + "', '" +
				kodeJenisData + "', '" +
				jenisrek + "', '" +
				nama + "', '" +
				userName + "', '" +
				status +  "' ";

			string tglTempo = tool.ConvertDate(LBL_TGL_TEMPO2.Text, LBL_BLN_TEMPO2.Text, LBL_THN_TEMPO2.Text);
			string tglTempoNew = tool.ConvertDate(TXT_TGL_TEMPO2.Text, DDL_BLN_TEMPO2.SelectedValue, TXT_THN_TEMPO2.Text);
			if(tglTempo!=tglTempoNew)
			{	
				temp="Tgl Jatuh Tempo: ";
				try
				{
					conn.QueryString = "EXEC REKANAN_AUDITTRAIL_INSERT '"+
						sqlpar + ", '" +
						temp + tglTempo.Replace("'","") + "', '" +
						temp + tglTempoNew.Replace("'","") + "'"; 
					conn.ExecuteNonQuery(); 
				}
				catch (Exception ex)
				{
					string errmsg = ex.Message.Replace("'","");
					if (errmsg.IndexOf("Last Query:") > 0)
						errmsg = errmsg.Substring(0, errmsg.IndexOf("Last Query:"));
					GlobalTools.popMessage(this, errmsg);
					return;
				}	
			}


				
		}

		
		protected void BTN_UDATE_Click(object sender, System.EventArgs e)
		{
			//Validasi Tanggal
			Int64 now = Int64.Parse(Tools.toISODate(DateTime.Now.Day.ToString(), DateTime.Now.Month.ToString(), DateTime.Now.Year.ToString())), compEstablish;
			Int64 tanggalJatuhTempo;			

			if (!GlobalTools.isDateValid(TXT_TGL_TEMPO2.Text, DDL_BLN_TEMPO2.SelectedValue, TXT_THN_TEMPO2.Text)) 
			{
				GlobalTools.popMessage(this, "Tanggal Jatuh Tempo tidak valid!");
				return;
			}
			else 
			{			
				tanggalJatuhTempo = Int64.Parse(Tools.toISODate(TXT_TGL_TEMPO2.Text, DDL_BLN_TEMPO2.SelectedValue, TXT_THN_TEMPO2.Text));

				if (tanggalJatuhTempo < now) 
				{
					GlobalTools.popMessage(this, "Tanggal Jatuh Tempo tidak bisa kurang dari tanggal saat ini!!");
					return;
				}
			}
			
			AuditTrailCheck("61");
			conn.QueryString=" exec REKANAN_INPUT_JATUH_TEMPO " + tool.ConvertDate(TXT_TGL_TEMPO2.Text, DDL_BLN_TEMPO2.SelectedValue, TXT_THN_TEMPO2.Text) + ",  '"+ TXT_REGNUM2.Text +"' ";
			conn.ExecuteNonQuery();
			ViewData2();
			ClearData2();
		}

		private void ViewData()
		{
			//conn.QueryString="select * from vw_rekanan_jatuh_tempo where regnum in (select regnum from application_rekanan where tgl_jatuh_tempo is null)";
			conn.QueryString="select * from VW_REKANAN_JATUH_TEMPO_FIX_NULL where approval_date in (select max(approval_date) from vw_rekanan_jatuh_tempo_fix_null group by rekanan_ref)";
			conn.ExecuteQuery();
			FillGrid();
			
		}		 

		private void ViewData2()
		{
			//conn.QueryString="select * from vw_rekanan_jatuh_tempo where regnum in (select regnum from application_rekanan where tgl_jatuh_tempo is not null)";
			conn.QueryString="select * from VW_REKANAN_JATUH_TEMPO_FIX_NOTNULL where approval_date in (select max(approval_date) from vw_rekanan_jatuh_tempo_fix_notnull group by rekanan_ref)";
			conn.ExecuteQuery();
			FillGrid2();
		}
		
		private void ClearData()
		{
			TXT_JNS.Text="";
			TXT_NAME.Text="";
			TXT_REGNUM.Text="";
			DDL_BLN_TEMPO.SelectedValue="";
			TXT_TGL_TEMPO.Text="";
			TXT_THN_TEMPO.Text="";			
		}

		private void ClearData2()
		{
			TXT_JNS2.Text="";
			TXT_NAME2.Text="";
			TXT_REGNUM2.Text="";
			DDL_BLN_TEMPO2.SelectedValue="";
			TXT_TGL_TEMPO2.Text="";
			TXT_THN_TEMPO2.Text="";			
		}

		private void DatGrd_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			DatGrd.CurrentPageIndex = e.NewPageIndex;
			SearchData();
		}

		private void SearchData()
		{			
			conn.QueryString="select * from vw_rekanan_jatuh_tempo where regnum in (select regnum from application_rekanan where tgl_jatuh_tempo is null) and NAMEREKANAN LIKE '%" + TXT_REK_NAME.Text + "%'";
			conn.ExecuteQuery();
			FillGrid();
		}

		private void SearchData2()
		{				
			string query1="";
			if (DDL_BLN_JT.SelectedValue!="")
			{
				query1 += "and year(tgl_jatuh_tempo)=year(getdate()) and month(tgl_jatuh_tempo)='" + DDL_BLN_JT.SelectedValue + "' ";				
			}

			conn.QueryString="select * from VW_REKANAN_JATUH_TEMPO_FIX_NOTNULL where approval_date in (select max(approval_date) from vw_rekanan_jatuh_tempo_fix_notnull group by rekanan_ref) and NAMEREKANAN LIKE '%" + TXT_REK_NAME2.Text + "%'"  + query1;
			conn.ExecuteQuery();
			FillGrid2();
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
			this.DatGrd2.ItemCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.DatGrd2_ItemCommand);

		}
		#endregion
	}
}
