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
using Microsoft.VisualBasic;
using System.Configuration;

namespace SME.DCM
{
	/// <summary>
	/// Summary description for CifDataPengurus.
	/// </summary>
	public partial class CifDataPengurus : System.Web.UI.Page
	{
		//protected Connection conn;
		protected Tools tool = new Tools();
		protected Tools tools = new Tools();
		protected Connection conn2 = new Connection(ConfigurationSettings.AppSettings["conn2"]);
		protected Connection conn = new Connection(ConfigurationSettings.AppSettings["conn"]);
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			//conn = (Connection) Session["Connection"];

			if(!IsPostBack)
			{
				BTN_UPDATE.Visible = false;
				BTN_ADD.Visible = true;

				DDL_JNS_NASABAH.Items.Add(new ListItem ("--Pilih--", ""));
				DDL_JNS_KELAMIN.Items.Add(new ListItem ("--Pilih--", ""));
				DDL_KODE_HUB.Items.Add(new ListItem ("--Pilih--", ""));
				DDL_JNS_ID.Items.Add(new ListItem ("--Pilih--", ""));
				DDL_BLN_COMP.Items.Add(new ListItem ("--Pilih--", ""));
				DDL_BLN_EXP.Items.Add(new ListItem ("--Pilih--", ""));
				DDL_BUC.Items.Add(new ListItem ("--Pilih--", ""));

				conn.QueryString = "select NASABAHID, NASABAHID + ' - ' + NASABAHDESC as NASABAHDESC from RFJENISNASABAH where ACTIVE='1'";
				conn.ExecuteQuery();
				for (int i = 0; i < conn.GetRowCount(); i++)
				{
					DDL_JNS_NASABAH.Items.Add(new ListItem(conn.GetFieldValue(i,1), conn.GetFieldValue(i,0)));
				}

				conn.QueryString = "select sexdesc from rfsex where active='1'";
				conn.ExecuteQuery();
				for (int i = 0; i < conn.GetRowCount(); i++)
					DDL_JNS_KELAMIN.Items.Add(new ListItem(conn.GetFieldValue(i,0), conn.GetFieldValue(i,0)));

				conn.QueryString = "select JOBTITLEID, JOBTITLEID + ' - ' + JOBTITLEDESC as JOBTITLEDESC from RFJOBTITLE where ACTIVE='1' order by JOBTITLEID";
				conn.ExecuteQuery();
				for (int i = 0; i < conn.GetRowCount(); i++)
					DDL_KODE_HUB.Items.Add(new ListItem(conn.GetFieldValue(i,1), conn.GetFieldValue(i,0)));

				conn.QueryString = "select CODE, CODE + ' - ' + DESCRIPTION as DESCRIPTION from RF_ID_TYPE where ACTIVE='1' order by CODE";
				conn.ExecuteQuery();
				for (int i = 0; i < conn.GetRowCount(); i++)
					DDL_JNS_ID.Items.Add(new ListItem(conn.GetFieldValue(i,1), conn.GetFieldValue(i,0)));

				conn2.QueryString = "SELECT UNIT_CODE, UNIT_DESC FROM RF_DATA_OWNER WHERE ACTIVE='1'";
				conn2.ExecuteQuery();
				for (int i = 0; i < conn2.GetRowCount(); i++)
					DDL_BUC.Items.Add(new ListItem(conn2.GetFieldValue(i,1), conn2.GetFieldValue(i,0)));
				
				for (int i=1; i<=12; i++)
				{
					DDL_BLN_COMP.Items.Add(new ListItem(DateAndTime.MonthName(i, false), i.ToString()));					
				}

				for (int i=1; i<=12; i++)
				{
					DDL_BLN_EXP.Items.Add(new ListItem(DateAndTime.MonthName(i, false), i.ToString()));					
				}

				conn2.QueryString = "select * from CIF_DATA_PENGURUS where cifno= '"+Request.QueryString["cifno"]+"' ";
				conn2.ExecuteQuery();
				FillGrid();

				conn2.QueryString = "select top 1 tot_saham from CIF_DATA_PENGURUS where cifno= '"+Request.QueryString["cifno"]+"' ";
				conn2.ExecuteQuery();
				TXT_TOT_SAHAM.Text = conn2.GetFieldValue("tot_saham");	
				if ( TXT_TOT_SAHAM.Text == "")
					TXT_TOT_SAHAM.Text = ""; 
				/*if ( TXT_TOT_SAHAM.Text == "")
				{
					GlobalTools.popMessage(this, "Total Saham harus 100%.");
					return;
				}

				else
				{
					float tot_saham = (float)Convert.ToDouble(TXT_TOT_SAHAM.Text);			
					if (tot_saham != 100)
					{
						GlobalTools.popMessage(this, "Total Saham harus 100%.");
						return;
					}
				}*/

				ViewDataAfterUpdate();
				
			}
			ViewMenu();
			
		}

		private void ViewMenu()
		{
			MenuCIF.Controls.Clear();
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
							strtemp = "cifno=" + Request.QueryString["cifno"];
						else	
							strtemp = "mc=" + Request.QueryString["mc"] + "&cifno=" + Request.QueryString["cifno"];
					}
					else 
					{
						strtemp = ""; 
					}
					t.NavigateUrl = conn.GetFieldValue(i, 3)+strtemp;
					MenuCIF.Controls.Add(t);
					MenuCIF.Controls.Add(new LiteralControl("&nbsp;&nbsp;&nbsp;"));
				}
			} 
			catch (Exception ex) 
			{
				string temp = ex.ToString();
			}
		}

		private void FillGrid()
		{
			DataTable dt = new DataTable();
			dt = conn2.GetDataTable().Copy();
			DatGridDataPerusahaan.DataSource = dt;
			try 
			{
				DatGridDataPerusahaan.DataBind();
			} 
			catch 
			{
				DatGridDataPerusahaan.CurrentPageIndex = 0;
				DatGridDataPerusahaan.DataBind();
			}

			for (int i = 0; i < DatGridDataPerusahaan.Items.Count; i++)
			{
				DatGridDataPerusahaan.Items[i].Cells[2].Text = tool.FormatDate(DatGridDataPerusahaan.Items[i].Cells[2].Text, true);
				string flag_pengurus;
				LinkButton LbDelete = (LinkButton) DatGridDataPerusahaan.Items[i].Cells[8].FindControl("LB_DELETE");
				conn2.QueryString = "select * from cif_data_pengurus where cifno = '"+Request.QueryString["cifno"]+"' ";
				conn2.ExecuteQuery();
				flag_pengurus = conn2.GetFieldValue("flag");
				if(flag_pengurus != "0")
				{
					LbDelete.Visible = false;
				}
			}			
		}

		protected void BTN_SEARCHCOMP_Click(object sender, System.EventArgs e)
		{
			Response.Write("<script language='javascript'>window.open('SearchZipcode.aspx?targetFormID=Form1&targetObjectID=TXT_CU_ZIPCODE','SearchZipcode','status=no,scrollbars=no,width=420,height=200');</script>");
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
			this.DatGridDataPerusahaan.ItemCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.DatGridDataPerusahaan_ItemCommand);
			this.DatGridDataPerusahaan.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.DatGridDataPerusahaan_PageIndexChanged);

		}
		#endregion

		protected void BTN_ADD_Click(object sender, System.EventArgs e)
		{
			string removed;
			if (CHK_REMOVED.Checked == true)
				removed = "1";
			else
				removed = "0";
			// Update and insert data ke tabel cif_data_pengurus
			conn2.QueryString = "exec CIF_DATA_PENGURUS_INSERT '"+ 
				Request.QueryString["cifno"] + "', '" +
				TXT_CIF.Text + "', '" +
				TXT_NAMA.Text + "', '" +
				DDL_JNS_NASABAH.SelectedValue + "', " +
				tools.ConvertDate(TXT_TGL_COMP.Text, DDL_BLN_COMP.SelectedValue, TXT_THN_COMP.Text) + ", '" +
				DDL_JNS_KELAMIN.SelectedItem + "', '" +
				tools.ConvertFloat(TXT_SAHAM.Text) + "', '" +
				DDL_JNS_ID.SelectedValue + "', '" +
				TXT_ID_UTAMA.Text + "', " +
				tools.ConvertDate(TXT_EXP_DAY.Text, DDL_BLN_EXP.SelectedValue, TXT_EXP_YEAR.Text) + ", '" +
				TXT_ALAMAT.Text + "', '" +
				DDL_BUC.SelectedValue + "', '" +
				TXT_CU_ZIPCODE.Text + "', '" +				
				DDL_KODE_HUB.SelectedValue + "', '" +
				removed +"', '0',  '"+ Session["USERID"].ToString() +"' ";
			conn2.ExecuteQuery();

			conn.QueryString = "select su_fullname from scuser where userid= '"+ Session["USERID"].ToString() +"' ";
			conn.ExecuteQuery();
			string pic_name;
			pic_name = conn.GetFieldValue("su_fullname");

			conn2.QueryString = "update cif_data_pengurus set pic_name= '"+ pic_name +"' where cifno= '"+Request.QueryString["cifno"]+"' ";
			conn2.ExecuteQuery();
			
			/* Fill Grid */
			conn2.QueryString = "select * from CIF_DATA_PENGURUS where cifno= '"+Request.QueryString["cifno"]+"' ";
			conn2.ExecuteQuery();
			FillGrid();	

			ClearData();
			
			conn2.QueryString = "select top 1 tot_saham from CIF_DATA_PENGURUS where cifno= '"+Request.QueryString["cifno"]+"' ";
			conn2.ExecuteQuery();
			TXT_TOT_SAHAM.Text = conn2.GetFieldValue("tot_saham");			
			float tot_saham = (float)Convert.ToDouble(TXT_TOT_SAHAM.Text);			
			if (tot_saham != 100)
			{
				GlobalTools.popMessage(this, "Total Saham harus 100%.");
				return;
			}
			
		}

		

		private void ClearData()
		{
			TXT_CIF.Text = "";
			TXT_NAMA.Text = "";
			DDL_JNS_NASABAH.SelectedValue = "";
			TXT_TGL_COMP.Text = "";
			DDL_BLN_COMP.SelectedValue = "";
			TXT_THN_COMP.Text = "";
			DDL_JNS_KELAMIN.SelectedValue = "";
			TXT_SAHAM.Text = "";
			DDL_JNS_ID.SelectedValue = "";
			TXT_ID_UTAMA.Text = "";
			TXT_EXP_DAY.Text = "";
			DDL_BLN_EXP.SelectedValue = "";
			TXT_EXP_YEAR.Text = "";
			TXT_ALAMAT.Text = "";
			DDL_BUC.SelectedValue = "";
			DDL_KODE_HUB.SelectedValue = "";
			
		}

		protected void BTN_CLEAR_Click(object sender, System.EventArgs e)
		{
			ClearData();

			conn2.QueryString = "select top 1 tot_saham from CIF_DATA_PENGURUS where cifno= '"+Request.QueryString["cifno"]+"' ";
			conn2.ExecuteQuery();
			TXT_TOT_SAHAM.Text = conn2.GetFieldValue("tot_saham");			
			float tot_saham = (float)Convert.ToDouble(TXT_TOT_SAHAM.Text);			
			if (tot_saham != 100)
			{
				GlobalTools.popMessage(this, "Total Saham harus 100%.");
				return;
			}
		}

		private void DatGridDataPerusahaan_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			DatGridDataPerusahaan.CurrentPageIndex = e.NewPageIndex;
			conn2.QueryString = "select * from CIF_DATA_PENGURUS where cifno= '"+Request.QueryString["cifno"]+"' ";
			conn2.ExecuteQuery();
			FillGrid();	
		}

		private void DatGridDataPerusahaan_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			switch (((LinkButton)e.CommandSource).CommandName)
			{
				case "delete_data":
					conn2.QueryString = "delete from CIF_DATA_PENGURUS where cifno='" + Request.QueryString["cifno"] + "' and CIFNO_PENGURUS=" + e.Item.Cells[0].Text + "";
					conn2.ExecuteQuery();
					conn2.QueryString = "select * from CIF_DATA_PENGURUS where cifno= '"+Request.QueryString["cifno"]+"' ";
					conn2.ExecuteQuery();
					FillGrid();	

					conn2.QueryString = "select top 1 tot_saham from CIF_DATA_PENGURUS where cifno= '"+Request.QueryString["cifno"]+"' ";
					conn2.ExecuteQuery();
					TXT_TOT_SAHAM.Text = conn2.GetFieldValue("tot_saham");	
					if ( TXT_TOT_SAHAM.Text == "")
					{
						GlobalTools.popMessage(this, "Total Saham harus 100%.");
						return;
					}

					else
					{
						float tot_saham = (float)Convert.ToDouble(TXT_TOT_SAHAM.Text);			
						if (tot_saham != 100)
						{
							GlobalTools.popMessage(this, "Total Saham harus 100%.");
							return;
						}
					}

					break;

				case "edit_data":
					conn2.QueryString = "select * from CIF_DATA_PENGURUS where cifno='" + Request.QueryString["cifno"] + "' and CIFNO_PENGURUS=" + e.Item.Cells[0].Text + "";
					conn2.ExecuteQuery();				
					TXT_CIF.Text = conn2.GetFieldValue("CIFNO_PENGURUS");
					TXT_NAMA.Text = conn2.GetFieldValue("NAMA");
					try{DDL_JNS_NASABAH.SelectedValue = conn2.GetFieldValue("JNS_NASABAH");}
					catch{DDL_JNS_NASABAH.SelectedValue = "";}
					TXT_TGL_COMP.Text = tools.FormatDate_Day(conn2.GetFieldValue("BOD"));
					try{DDL_BLN_COMP.SelectedValue = tools.FormatDate_Month(conn2.GetFieldValue("BOD"));}
					catch{DDL_BLN_COMP.SelectedValue = "";}
					TXT_THN_COMP.Text = tools.FormatDate_Year(conn2.GetFieldValue("BOD"));
					try{DDL_JNS_KELAMIN.SelectedValue = conn2.GetFieldValue("GENDER");}
					catch{DDL_JNS_KELAMIN.SelectedValue = "";}
					TXT_SAHAM.Text = conn2.GetFieldValue("SHARE_SAHAM");
					try{DDL_JNS_ID.SelectedValue = conn2.GetFieldValue("JNS_ID");}
					catch{DDL_JNS_ID.SelectedValue = "";}
					TXT_ID_UTAMA.Text = conn2.GetFieldValue("NO_ID");
					TXT_EXP_DAY.Text = tools.FormatDate_Day(conn2.GetFieldValue("EXP_DATE"));
					try{DDL_BLN_EXP.SelectedValue = tools.FormatDate_Month(conn2.GetFieldValue("EXP_DATE"));}
					catch{DDL_BLN_EXP.SelectedValue = "";}
					TXT_EXP_YEAR.Text = tools.FormatDate_Year(conn2.GetFieldValue("EXP_DATE"));
					TXT_ALAMAT.Text = conn2.GetFieldValue("ALAMAT");
					TXT_CU_ZIPCODE.Text = conn2.GetFieldValue("KODE_POS");
					try{DDL_BUC.SelectedValue = conn2.GetFieldValue("BUC");}
					catch{DDL_BUC.SelectedValue = "";}
					try{DDL_KODE_HUB.SelectedValue = conn2.GetFieldValue("KODE_HUB");}
					catch{DDL_KODE_HUB.SelectedValue = "";}
					if (conn2.GetFieldValue("FLAG")=="1")
						CHK_REMOVED.Checked = true;
					else
						CHK_REMOVED.Checked = false;
						
					conn2.QueryString = "select * from CIF_DATA_PENGURUS where cifno= '"+Request.QueryString["cifno"]+"' ";
					conn2.ExecuteQuery();
					FillGrid();	
					BTN_UPDATE.Visible = true;
					BTN_ADD.Visible = false;
					
					conn2.QueryString = "select top 1 tot_saham from CIF_DATA_PENGURUS where cifno= '"+Request.QueryString["cifno"]+"' ";
					conn2.ExecuteQuery();
					TXT_TOT_SAHAM.Text = conn2.GetFieldValue("tot_saham");	
					break;
			}
		}

		protected void BTN_UPDATE_Click(object sender, System.EventArgs e)
		{
			try
			{

				string removed;
				if (CHK_REMOVED.Checked == true)
					removed = "1";
				else
					removed = "0";

				conn2.QueryString = "exec CIF_DATA_PENGURUS_UPDATE '"+ 
					Request.QueryString["cifno"] + "', '" +
					TXT_CIF.Text + "', '" +
					TXT_NAMA.Text + "', '" +
					DDL_JNS_NASABAH.SelectedValue + "', " +
					tools.ConvertDate(TXT_TGL_COMP.Text, DDL_BLN_COMP.SelectedValue, TXT_THN_COMP.Text) + ", '" +
					DDL_JNS_KELAMIN.SelectedItem + "', '" +
					tools.ConvertFloat(TXT_SAHAM.Text) + "', '" +
					DDL_JNS_ID.SelectedValue + "', '" +
					TXT_ID_UTAMA.Text + "', " +
					tools.ConvertDate(TXT_EXP_DAY.Text, DDL_BLN_EXP.SelectedValue, TXT_EXP_YEAR.Text) + ", '" +
					TXT_ALAMAT.Text + "', '" +
					DDL_BUC.SelectedValue + "', '" +
					TXT_CU_ZIPCODE.Text + "', '" +				
					DDL_KODE_HUB.SelectedValue + "', '" +
					removed +"', '0',  '"+ Session["USERID"].ToString() +"' ";
				conn2.ExecuteQuery(); 

				conn.QueryString = "select su_fullname from scuser where userid= '"+ Session["USERID"].ToString() +"' ";
				conn.ExecuteQuery();
				string pic_name;
				pic_name = conn.GetFieldValue("su_fullname");

				conn2.QueryString = "update cif_data_pengurus set pic_name= '"+ pic_name +"' where cifno= '"+Request.QueryString["cifno"]+"' ";
				conn2.ExecuteQuery();
			}

			catch
			{
				GlobalTools.popMessage(this, "Connection Error!");
				Response.Redirect("../../Login.aspx?expire=1");
			}

			ClearData();
			conn2.QueryString = "select * from CIF_DATA_PENGURUS where cifno= '"+Request.QueryString["cifno"]+"' ";
			conn2.ExecuteQuery();
			FillGrid();
			BTN_UPDATE.Visible=false;
			BTN_ADD.Visible=true;

			
			conn2.QueryString = "select top 1 tot_saham from CIF_DATA_PENGURUS where cifno= '"+Request.QueryString["cifno"]+"' ";
			conn2.ExecuteQuery();
			TXT_TOT_SAHAM.Text = conn2.GetFieldValue("tot_saham");	
			if ( TXT_TOT_SAHAM.Text == "")
			{
				GlobalTools.popMessage(this, "Total Saham harus 100%.");
				return;
			}

			else
			{
				float tot_saham = (float)Convert.ToDouble(TXT_TOT_SAHAM.Text);			
				if (tot_saham != 100)
				{
					GlobalTools.popMessage(this, "Total Saham harus 100%.");
					return;
				}
			}
		}

		protected void DatGridDataPerusahaan_SelectedIndexChanged(object sender, System.EventArgs e)
		{
		
		}

		protected void BTN_BACK_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			string from_appr;
			from_appr = Request.QueryString["from_appr"];
			if (Request.QueryString["from_appr"]=="0")
				Response.Redirect("CifListData.aspx?tc=" + Request.QueryString["tc"] + "&mc=" + Request.QueryString["mc"] );
			else
				Response.Redirect("CifListDataApproval.aspx?tc=" + Request.QueryString["tc"] + "&mc=" + Request.QueryString["mc"] );
		}

		private void ViewDataAfterUpdate()
		{
			string flag_pengurus;
			conn2.QueryString = "select * from cif_data_pengurus where cifno = '"+Request.QueryString["cifno"]+"' ";
			conn2.ExecuteQuery();
			flag_pengurus = conn2.GetFieldValue("flag");
			if (flag_pengurus == "1" || flag_pengurus == "2")
			{
				BTN_ADD.Enabled = false;
				BTN_UPDATE.Enabled = false;
				BTN_CLEAR.Enabled = false;
				TXT_CIF.ReadOnly = true;
				TXT_NAMA.ReadOnly = true;
				DDL_JNS_NASABAH.Enabled = false;
				TXT_TGL_COMP.ReadOnly = true;
				DDL_BLN_COMP.Enabled = false;
				TXT_THN_COMP.ReadOnly = true;
				DDL_JNS_KELAMIN.Enabled = false;
				TXT_SAHAM.ReadOnly = true;
				DDL_JNS_ID.Enabled = false;
				TXT_ID_UTAMA.ReadOnly = true;
				TXT_EXP_DAY.ReadOnly = true;
				DDL_BLN_EXP.Enabled = false;
				TXT_EXP_YEAR.ReadOnly = true;
				TXT_ALAMAT.ReadOnly = true;
				DDL_BUC.Enabled = false;
				DDL_KODE_HUB.Enabled = false;
				TXT_CU_ZIPCODE.ReadOnly = true;
				BTN_SEARCHCOMP.Enabled = false;
			}
		}	

	}
}
