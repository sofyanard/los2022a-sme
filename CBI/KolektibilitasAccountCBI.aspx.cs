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

namespace SME.CBI
{
	/// <summary>
	/// Summary description for PRM_TBOMonitoring.sadfasdfsfd
	/// </summary>
	public partial class KolektibilitasAccountCBI : System.Web.UI.Page
	{
		protected Tools tool = new Tools();
		protected System.Web.UI.WebControls.DropDownList DDL_COLL12;
		protected System.Web.UI.WebControls.DropDownList DropDownList1;
		protected System.Web.UI.WebControls.TextBox NUM_COLL_2A;
		protected System.Web.UI.WebControls.TextBox NUM_COLL_2B;
		protected System.Web.UI.WebControls.TextBox NUM_COLL_2C;
		protected Connection conn;

		protected void Page_Load(object sender, System.EventArgs e)
		{
			conn = (Connection) Session["Connection"];

			if (Request.QueryString["de"] == "1")
				if (!Logic.AllowAccess(Session["GroupID"].ToString(), Request.QueryString["mc"], conn))
					Response.Redirect("/SME/Restricted.aspx");

			if(!IsPostBack)
			{
				viewDDL();
				viewData();
			}
			viewMenu();
			SecureData();
		}		

		void viewData()
		{
			string sql;

	
			sql="select * from collectibility where cu_ref='"+ Request.QueryString["curef"] +"'";
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
				" from APPLICATION where AP_REGNO = '" + Request.QueryString["regno"] + "'";
			conn.ExecuteQuery();

			try { RDO_BM_BL_MGMT.SelectedValue = conn.GetFieldValue("AP_BLBMMGMT"); } 
			catch {}
			try { RDO_BM_BL_PEMILIK.SelectedValue = conn.GetFieldValue("AP_BLBMPEMILIK"); } 
			catch {}
			try { RDO_BM_BL_PERUSAHAAN.SelectedValue = conn.GetFieldValue("AP_BLBMUSAHA"); } 
			catch {}
		}

		private void SecureData() 
		{
			// Jika yang memanggil bukan dalam scope DataEntry, maka disable semua control input
			// Flag :
			//		Nama  = de
			//		Value ==  1 --> Parent DataEntry
			//			  !=  1 --> Parent non-DataEntry
			string de = Request.QueryString["de"];
			if (de != "1") 
			{
				System.Web.UI.ControlCollection coll = this.Page.Controls;
				int k = 0;
				for(k = 0; k < coll.Count; k++) 
				{
					if (coll[k] is System.Web.UI.HtmlControls.HtmlForm) 
					{
						break;
					}
				}
				if (k == coll.Count) return;

				for (int i = 0; i < coll[k].Controls.Count; i++) 
				{
					if (coll[k].Controls[i] is TextBox) 
					{
						TextBox txt = (TextBox) coll[k].Controls[i];
						txt.ReadOnly = true;
						//txt.Enabled = false;
					}
					else if (coll[k].Controls[i] is DropDownList) 
					{
						DropDownList ddl = (DropDownList) coll[k].Controls[i];
						ddl.Enabled = false;
					}
					else if (coll[k].Controls[i] is Button)
					{
						Button btn = (Button) coll[k].Controls[i];
						//btn.Enabled = false;
						btn.Visible = false;
					}
					else if (coll[k].Controls[i] is RadioButtonList) 
					{
						RadioButtonList rbl = (RadioButtonList) coll[k].Controls[i];
						rbl.Enabled = false;
					}
					else if (coll[k].Controls[i] is RadioButton) 
					{
						RadioButton rb = (RadioButton) coll[k].Controls[i];
						rb.Enabled = false;
					}
					else if (coll[k].Controls[i] is CheckBox)
					{
						CheckBox cb = (CheckBox) coll[k].Controls[i];
						cb.Enabled = false;
					}					
						/**
						else if (coll[k].Controls[i] is DataGrid) 
						{						
							DataGrid dg = (DataGrid) coll[k].Controls[i];						
							dg.Columns[10].Visible = false;
							for (int j = 0; j < dg.Items.Count; j++) 
							{
								//dg.Items[j].Cells[10].Enabled = false;
								dg.Items[j].Cells[10].Visible = false;
							}
						}**/
					else if (coll[k].Controls[i] is HtmlTableRow) 
					{
						HtmlTableRow htr = (HtmlTableRow) coll[k].Controls[i];
						//htr.Disabled = true;	

						for (int j=0; j < htr.Controls.Count; j++) 
						{							
							for (int jj = 0; jj < htr.Controls[j].Controls.Count; jj++) 
							{
								if (htr.Controls[j].Controls[jj] is TextBox) 
								{
									TextBox txt = (TextBox) htr.Controls[j].Controls[jj];
									txt.ReadOnly = true;
									//txt.Enabled = false;
								}
								else if (htr.Controls[j].Controls[jj] is DropDownList) 
								{
									DropDownList ddl = (DropDownList) htr.Controls[j].Controls[jj];
									ddl.Enabled = false;
								}
								else if (htr.Controls[j].Controls[jj] is Button)
								{
									Button btn = (Button) htr.Controls[j].Controls[jj];
									//btn.Enabled = false;
									btn.Visible = false;
								}
								else if (htr.Controls[j].Controls[jj] is RadioButtonList) 
								{
									RadioButtonList rbl = (RadioButtonList) htr.Controls[j].Controls[jj];
									rbl.Enabled = false;
								}
								else if (htr.Controls[j].Controls[jj] is RadioButton) 
								{
									RadioButton rb = (RadioButton) htr.Controls[j].Controls[jj];
									rb.Enabled = false;
								}
								else if (htr.Controls[j].Controls[jj] is CheckBox)
								{
									CheckBox cb = (CheckBox) htr.Controls[j].Controls[jj];
									cb.Enabled = false;
								}					
							}
						}
					}
				}
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
		
		// <summary>
		// Required method for Designer support - do not modify
		// the contents of this method with the code editor.
		// </summary>
		private void InitializeComponent()
		{    

		}
		#endregion


		void viewDDL()
		{
			string de = Request.QueryString["de"];
			string str;
			str = "select COLLECTID,COLLECTDESC  from RFCOLLECTABILITY";
			if (de != "1") str = "select COLLECTID,COLLECTDESC  from RFCOLLECTABILITY where active = '1'";
			GlobalTools.fillRefList(DDL_COLL_FILTER,str,conn);

			str = "select COLLECTID,COLLECTDESC  from RFCOLLECTABILITY1";
			if (de != "1") str = "select COLLECTID,COLLECTDESC  from RFCOLLECTABILITY1 where active = '1'";
			//GlobalTools.fillRefList(DDL_BESTIN12MONTH,str,conn);
			GlobalTools.fillRefList(DDL_WORSTIN12MONTH,str,conn);
			GlobalTools.fillRefList(DDL_COLL_KP_CURR,str,conn);
			GlobalTools.fillRefList(DDL_COLL_MGM_CURR,str,conn);
			GlobalTools.fillRefList(DDL_COLL_CURR_CUST, str, conn);
		}
		

		private void DropDownList3_SelectedIndexChanged(object sender, System.EventArgs e)
		{
		}

		private void DatGrd_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			viewData();
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
			string sql = "update APPLICATION ";
			sql += "set AP_BLBMPEMILIK = '" + RDO_BM_BL_PEMILIK.SelectedValue + "'"; // pemilik
			sql += ",AP_BLBMMGMT = '" + RDO_BM_BL_MGMT.SelectedValue + "'"; // Key Person (Manajemen)
			sql += ",AP_BLBMUSAHA = '" + RDO_BM_BL_PERUSAHAAN.SelectedValue + "'"; // Perusahaan
			sql += " where AP_REGNO = '" + Request.QueryString["regno"] + "'";
			conn.QueryString = sql;
			conn.ExecuteNonQuery();
		}

		private void DropDownList1_SelectedIndexChanged(object sender, System.EventArgs e)
		{
		
		}

		protected void BTN_BACK_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			if (Request.QueryString["par"] != null && Request.QueryString["par"] != "")  
				Response.Redirect(Request.QueryString["par"] + "&regno=" + Request.QueryString["regno"] + "&curef=" + Request.QueryString["curef"] + "&tc=" + Request.QueryString["tc"]);
			else if (Request.QueryString["mc"] != "" && Request.QueryString["mc"] != null)
				Response.Redirect("/SME/" + DMS.CuBESCore.Logic.backLink(Request.QueryString["tc"].ToString(), Request.QueryString["mc"].ToString(), conn));
			else
				Response.Redirect("/SME/" + DMS.CuBESCore.Logic.backLink(Request.QueryString["tc"].ToString(), conn));		
		}

		protected void DDL_NASABAH_SelectedIndexChanged(object sender, System.EventArgs e)
		{
		
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
				
				//kolom ACC_COLL kosong.
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



	}
}
