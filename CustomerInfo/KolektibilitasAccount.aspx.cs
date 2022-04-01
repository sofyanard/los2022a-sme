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

namespace SME.CustomerInfo
{
	/// <summary>
	/// Summary description for KolektibilitasAccount.
	/// </summary>
	public partial class KolektibilitasAccount : System.Web.UI.Page
	{
		protected Connection conn;
		protected Tools tool = new Tools();
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			conn = (Connection) Session["Connection"];

			if (!Logic.AllowAccess(Session["GroupID"].ToString(), Request.QueryString["mc"], conn))
				Response.Redirect("/SME/Restricted.aspx");

			if(!IsPostBack)
			{
				viewDDL();
				viewData();
				viewDataBI();
			}

			viewMenu();
		}

		private void viewDDL()
		{
			string str;
			str = "select COLLECTID,COLLECTDESC  from RFCOLLECTABILITY where active = '1'";
			GlobalTools.fillRefList(DDL_COLL_FILTER,str,conn);

			str = "select COLLECTID,COLLECTDESC  from RFCOLLECTABILITY1 where active = '1'";
			//GlobalTools.fillRefList(DDL_BESTIN12MONTH,str,conn);
			GlobalTools.fillRefList(DDL_WORSTIN12MONTH,str,conn);
			GlobalTools.fillRefList(DDL_COLL_KP_CURR,str,conn);
			GlobalTools.fillRefList(DDL_COLL_MGM_CURR,str,conn);
			GlobalTools.fillRefList(DDL_COLL_CURR_CUST, str, conn);

			string var_Nota = "Select collectid, collectdesc  from RFCOLLECTABILITY where active = '1'";
			GlobalTools.fillRefList(DDL_ACCBK, var_Nota , false, conn);
			GlobalTools.fillRefList(DDL_OCBK, var_Nota , false, conn);
			GlobalTools.fillRefList(DDL_MCBKS, var_Nota , false, conn);
		}

		private void viewData()
		{
			string sql;

			sql="select * from collectibility where cu_ref = '" + Request.QueryString["curef"] + "'";
			conn.QueryString = sql;
			conn.ExecuteQuery();
			if (conn.GetRowCount()>0)
			{
				TXT_NUM_COLL_2A.Text	= conn.GetFieldValue("NUM_COLL_2A");
				TXT_NUM_COLL_2B.Text	= conn.GetFieldValue("NUM_COLL_2B");
				TXT_NUM_COLL_2C.Text	= conn.GetFieldValue("NUM_COLL_2C");
				TXT_NUM_COLL_3PLUS.Text = conn.GetFieldValue("NUM_COLL_3PLUS");
				try { DDL_LANCAR12.SelectedValue=conn.GetFieldValue("LANCAR_LAST_12BLN"); } 
				catch {}
				try { DDL_FULLRECOVERY.SelectedValue=conn.GetFieldValue("FULL_RECOVERY"); } 
				catch {}
				//TXT_COLL_12LAST_BM.Text =conn.GetFieldValue("COLL_12_LAST");
				TXT_COLL_2C_12_KP.Text =conn.GetFieldValue("COLL_2C_12_KP");
				TXT_COLL_2C_12_MGM.Text =conn.GetFieldValue("COLL_2C_12_MGM");
				try { DDL_COLL_KP_CURR.SelectedValue =conn.GetFieldValue("COLL_CURR_KP"); } 
				catch {}
				try { DDL_COLL_MGM_CURR.SelectedValue =conn.GetFieldValue("COLL_CURR_MGM"); } 
				catch {}
				try { DDL_WORSTIN12MONTH.SelectedValue = conn.GetFieldValue("COLL_W_12_B"); } 
				catch {}
				TXT_COLL_W_12.Text =conn.GetFieldValue("COLL_W_12_B");
				try { DDL_COLL_CURR_CUST.SelectedValue = conn.GetFieldValue("COLL_CURR_CUST"); } 
				catch {}
			}

			string str,keyperson="0";//,coll="1";
					
			string subQ = "''"; // sub query kosong
			if(DDL_NASABAH.SelectedValue.Equals("0"))
			{ // jika jenis nasabah yang dipilih bukan Key Person dan bukan Management
				subQ  = "select PROD.ACC_NO from BOOKEDPROD PROD ";
				subQ += "inner join BOOKEDCUST CUST on PROD.AA_NO = CUST.AA_NO ";
				subQ += "where CUST.CU_REF = '" + Request.QueryString["curef"] + "'";
			}
			else
			{ // jika jenis nasabah yang dipilih adalah Key Person atau Management
				if(DDL_NASABAH.SelectedValue.Equals("1")) 
				{ // Key Person
					keyperson="'1'";
				}
				else if(DDL_NASABAH.SelectedValue.Equals("2")) 
				{ // Management
					keyperson="'0' or HOLD.CS_KEYPERSON is null";
				}

				subQ  = "select HOLD_ACC_NO from CUST_STOCKHOLDER_ACC ACC ";
				subQ += "left join CUST_STOCKHOLDER HOLD on ACC.CU_REF = HOLD.CU_REF where ";
				subQ += "ACC.CU_REF ='" + Request.QueryString["curef"] + "'";
				subQ += "and (HOLD.CS_KEYPERSON = " + keyperson + ")";
			}
			str  = "select * from ACC_COLL where ";
			str += " ACC_NO in (" + subQ + ")";
			str += " and COLL_CODE='" + DDL_COLL_FILTER.SelectedValue  + "'";
			str += " and datediff(month,TGL_PERUBAHAN_COLL,getdate())<='"+ DDL_DURASI_FILTER.SelectedValue +"'"; 

			conn.QueryString = str;
			conn.ExecuteQuery();
			DataTable data = new DataTable();
			data = conn.GetDataTable().Copy();
			DGR_COLL.DataSource = data;
			try 
			{
				DGR_COLL.DataBind();
			} 
			catch 
			{
				DGR_COLL.CurrentPageIndex = 0;
				DGR_COLL.DataBind();
			}
			for (int i = 0; i < DGR_COLL.Items.Count; i++)
				DGR_COLL.Items[i].Cells[3].Text = tool.FormatDate(DGR_COLL.Items[i].Cells[3].Text, true);

			conn.QueryString = "select isnull(AP_BLBMPEMILIK,'') as AP_BLBMPEMILIK, " + 
				"isnull(AP_BLBMMGMT,'') as AP_BLBMMGMT, " + 
				"isnull(AP_BLBMUSAHA,'') as AP_BLBMUSAHA " + 
				" from CUSTINFO_APPDATA where CU_REF = '" + Request.QueryString["curef"] + "'";
			conn.ExecuteQuery();

			try { RDO_BM_BL_MGMT.SelectedValue = conn.GetFieldValue("AP_BLBMMGMT"); } 
			catch {}
			try { RDO_BM_BL_PEMILIK.SelectedValue = conn.GetFieldValue("AP_BLBMPEMILIK"); } 
			catch {}
			try { RDO_BM_BL_PERUSAHAAN.SelectedValue = conn.GetFieldValue("AP_BLBMUSAHA"); } 
			catch {}
		}

		private void viewDataBI()
		{
			conn.QueryString = "select * from CUSTINFO_APPDATA where cu_ref = '"+ Request.QueryString["curef"] + "'";
			conn.ExecuteQuery();

			if (conn.GetRowCount() > 0)
			{
				try {DDL_ACCBK.SelectedValue = conn.GetFieldValue("AP_BLBIACCBK");} 
				catch {DDL_ACCBK.SelectedValue = "";}

				try {DDL_OCBK.SelectedValue = conn.GetFieldValue("AP_BLBIOCBK");} 
				catch {DDL_OCBK.SelectedValue = "";}

				try {DDL_MCBKS.SelectedValue = conn.GetFieldValue("AP_BLBIMCBKS");} 
				catch {DDL_MCBKS.SelectedValue = "";}

				try {RDO_AP_BLBIMGMT.SelectedValue = conn.GetFieldValue("AP_BLBIMGMT");} 
				catch {RDO_AP_BLBIMGMT.SelectedValue = "0";}

				try {RDO_AP_BLBIUSAHA.SelectedValue = conn.GetFieldValue("AP_BLBIUSAHA");} 
				catch {RDO_AP_BLBIUSAHA.SelectedValue = "0";}

				try {RDO_AP_BLBIPEMILIK.SelectedValue = conn.GetFieldValue("AP_BLBIPEMILIK");} 
				catch {RDO_AP_BLBIPEMILIK.SelectedValue = "0";}

				try {RDO_AP_BLBIPERNAH.SelectedValue = conn.GetFieldValue("AP_BLBIPERNAH");} 
				catch {RDO_AP_BLBIPERNAH.SelectedValue = "0";}
			}
		}

		private void viewMenu()
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
						if (conn.GetFieldValue(i,3).IndexOf("?de=") < 0 && conn.GetFieldValue(i,3).IndexOf("&de=") < 0)
							strtemp = strtemp + "&de=" + Request.QueryString["de"];
						if (conn.GetFieldValue(i,3).IndexOf("?par=") < 0 && conn.GetFieldValue(i,3).IndexOf("&par=") < 0) 
							strtemp = strtemp + "&par=" + Request.QueryString["par"];
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
			this.DGR_COLL.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.DGR_COLL_PageIndexChanged);

		}
		#endregion

		protected void BTN_SAVE_Click(object sender, System.EventArgs e)
		{
			string strSql;
			string strSql2;

			strSql="delete from collectibility where cu_ref='"+ Request.QueryString["curef"] +"'";
			conn.QueryString = strSql;
			conn.ExecuteQuery();

			strSql2=" insert into collectibility(CU_REF, TYPE_NASABAH," +
				" NUM_COLL_2A, NUM_COLL_2B, NUM_COLL_2C," + 
				" LANCAR_LAST_12BLN, FULL_RECOVERY, COLL_12_LAST, COLL_W_12_B," +
				" COLL_2C_12_KP, COLL_CURR_KP, COLL_2C_12_MGM, COLL_CURR_MGM, NUM_COLL_3PLUS, COLL_CURR_CUST) " + 
				"values('" + 
				Request.QueryString["curef"] + "','" + DDL_NASABAH.SelectedValue + "'," + 
				TXT_NUM_COLL_2A.Text.Trim() + "," + TXT_NUM_COLL_2B.Text.Trim() + "," + 
				TXT_NUM_COLL_2C.Text.Trim() + ",'" + DDL_LANCAR12.SelectedValue + "','" + 
				DDL_FULLRECOVERY.SelectedValue + "',null,'" + 
				DDL_WORSTIN12MONTH.SelectedValue  + "'," + TXT_COLL_2C_12_KP.Text.Trim() + ",'" + 
				DDL_COLL_KP_CURR.SelectedValue   + "'," + 
				TXT_COLL_2C_12_MGM.Text.Trim() + ",'" + DDL_COLL_MGM_CURR.SelectedValue + "', " +
				TXT_NUM_COLL_3PLUS.Text.Trim() + ", '" + DDL_COLL_CURR_CUST.SelectedValue + "')";
			//LBL_SQL.Text=strSql2;
			conn.QueryString=strSql2;
			conn.ExecuteNonQuery();

			// Blacklist di Bank Mandiri
			conn.QueryString = "EXEC CUSTINFO_APPDATA_SAVE_BLACKLISTBM '" + Request.QueryString["curef"] + "', '" +
				RDO_BM_BL_PEMILIK.SelectedValue + "', '" +
				RDO_BM_BL_MGMT.SelectedValue + "', '" +
				RDO_BM_BL_PERUSAHAAN.SelectedValue + "'";
			conn.ExecuteNonQuery();
		}

		protected void btn_back_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			Response.Redirect("SearchCustomer.aspx?mc=030");
		}

		protected void BTN_CARI_Click(object sender, System.EventArgs e)
		{
			string str,keyperson="0";//,coll="1";
		
			string subQ = "''"; // sub query kosong
			if(DDL_NASABAH.SelectedValue.Equals("0"))
			{ // jika jenis nasabah yang dipilih bukan Key Person dan bukan Management
				subQ  = "select PROD.ACC_NO from BOOKEDPROD PROD ";
				subQ += "inner join BOOKEDCUST CUST on PROD.AA_NO = CUST.AA_NO ";
				subQ += "where CUST.CU_REF = '" + Request.QueryString["curef"] + "'";
			}
			else
			{ // jika jenis nasabah yang dipilih adalah Key Person atau Management
				if(DDL_NASABAH.SelectedValue.Equals("1")) 
				{ // Key Person
					keyperson="'1'";
				}
				else if(DDL_NASABAH.SelectedValue.Equals("2")) 
				{ // Management
					keyperson="null or HOLD.CS_KEYPERSON is not null";
				}

				subQ  = "select HOLD_ACC_NO from CUST_STOCKHOLDER_ACC ACC ";
				subQ += "left join CUST_STOCKHOLDER HOLD on ACC.CU_REF = HOLD.CU_REF where ";
				subQ += "ACC.CU_REF ='" + Request.QueryString["curef"] + "'";
				subQ += "and (HOLD.CS_KEYPERSON = " + keyperson + ")";
			}
			str  = "select * from ACC_COLL where ";
			str += " ACC_NO in (" + subQ + ")";
			str += " and COLL_CODE='" + DDL_COLL_FILTER.SelectedValue  + "'";
			str += " and datediff(month,TGL_PERUBAHAN_COLL,getdate())<='"+ DDL_DURASI_FILTER.SelectedValue + "'"; 

			conn.QueryString=str;
			conn.ExecuteQuery();
			LBL_SQL.Text=str;
			DataTable data = new DataTable();
			data = conn.GetDataTable().Copy();
			DGR_COLL.DataSource = data;
			try 
			{
				DGR_COLL.DataBind();
			} 
			catch 
			{
				DGR_COLL.CurrentPageIndex = 0;
				DGR_COLL.DataBind();
			}
			for (int i = 0; i < DGR_COLL.Items.Count; i++)
				DGR_COLL.Items[i].Cells[3].Text = tool.FormatDate(DGR_COLL.Items[i].Cells[3].Text, true);
		}

		private void DGR_COLL_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			DGR_COLL.CurrentPageIndex = e.NewPageIndex;
			viewData();
		}

		protected void BTN_UPDATE_BI_Click(object sender, System.EventArgs e)
		{
			try
			{
				conn.QueryString = "EXEC CUSTINFO_APPDATA_SAVE_BLACKLISTBI '" + Request.QueryString["curef"] + "', '" +
					RDO_AP_BLBIPEMILIK.SelectedValue + "', '" +
					RDO_AP_BLBIMGMT.SelectedValue + "', '" +
					RDO_AP_BLBIUSAHA.SelectedValue + "', '" +
					RDO_AP_BLBIPERNAH.SelectedValue + "', '" +
					DDL_ACCBK.SelectedValue + "', '" +
					DDL_OCBK.SelectedValue + "', '" +
					DDL_MCBKS.SelectedValue + "'";
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
}
