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
using DMS.BlackList;
using Microsoft.VisualBasic;
using System.IO;
using System.Diagnostics;

namespace SME.CEA.CBI
{
	/// <summary>
	/// Summary description for BICheckingResultEntry.
	/// </summary>
	public class BICheckingResultEntry : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.ImageButton BTN_BACK;
		protected System.Web.UI.WebControls.PlaceHolder Menu;
		protected System.Web.UI.WebControls.DataGrid DatGrd;
		protected System.Web.UI.WebControls.DropDownList DDL_NAMA;
		protected System.Web.UI.WebControls.DropDownList DDL_BANK;
		protected System.Web.UI.WebControls.TextBox TXT_CS_DOB_DAY;
		protected System.Web.UI.WebControls.DropDownList DDL_IDI_BI_MONTH;
		protected System.Web.UI.WebControls.TextBox TXT_CS_DOB_YEAR;
		protected System.Web.UI.WebControls.TextBox TXT_POS_DT_DAY;
		protected System.Web.UI.WebControls.DropDownList DDL_POSISI_MONTH;
		protected System.Web.UI.WebControls.TextBox TXT_POS_DT_YEAR;
		protected System.Web.UI.WebControls.TextBox CREDIT_TYPE;
		protected System.Web.UI.WebControls.Label SEQ;
		protected System.Web.UI.WebControls.TextBox BAKI_DEBET;
		protected System.Web.UI.WebControls.DropDownList DDL_KOLE;
		protected System.Web.UI.WebControls.TextBox TUNGGAKAN_AGE;
		protected System.Web.UI.WebControls.TextBox TOT_TUNGGAKAN;
		protected System.Web.UI.WebControls.TextBox REMARK;
		protected System.Web.UI.WebControls.Label TXT_SEQ;
		protected System.Web.UI.WebControls.Button BTN_INSERT;
		protected System.Web.UI.WebControls.Button BTN_UPDATE;
		protected System.Web.UI.WebControls.Button BTN_Clear;
		protected System.Web.UI.WebControls.PlaceHolder Placeholder2;
		protected System.Web.UI.WebControls.Label LBL_REK_REF;
		protected System.Web.UI.WebControls.Label LBL_REK_REG;
		protected Tools tool = new Tools();
		int seq=8;
		protected Connection conn;
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			conn = (Connection) Session["Connection"];
			conn.QueryString="delete from rekanan_scoring_site_visit";
			conn.ExecuteQuery();

			if (!IsPostBack)
			{
				DDL_IDI_BI_MONTH.Items.Add(new ListItem("--Pilih--",""));
				DDL_POSISI_MONTH.Items.Add(new ListItem("--Pilih--",""));
				for (int i = 1; i <= 12; i++)
					DDL_IDI_BI_MONTH.Items.Add(new ListItem(DateAndTime.MonthName(i, false), i.ToString()));
				for (int j = 1; j <= 12; j++)
					DDL_POSISI_MONTH.Items.Add(new ListItem(DateAndTime.MonthName(j, false), j.ToString()));
				
				DDL_KOLE.Items.Add(new ListItem("--Pilih--",""));
				DDL_KOLE.Items.Add(new ListItem("1","1"));
				DDL_KOLE.Items.Add(new ListItem("2","2"));
				DDL_KOLE.Items.Add(new ListItem("3","3"));
				DDL_KOLE.Items.Add(new ListItem("4","4"));
				DDL_KOLE.Items.Add(new ListItem("5","5"));
												
				ViewNama();
				ViewBank();

				BAKI_DEBET.Text = tool.MoneyFormat(BAKI_DEBET.Text);
				TOT_TUNGGAKAN.Text = tool.MoneyFormat(TOT_TUNGGAKAN.Text);
			}
						
			ViewData();
			ViewMenu();
			CekView();

			BTN_UPDATE.Visible=false;
			BTN_INSERT.Visible=true;
		}

		private void ViewBank()
		{
			DDL_BANK.Items.Add(new ListItem("--Pilih--","0"));
			conn.QueryString="select bankid,bankname from rfbank where active='1'";
			conn.ExecuteQuery();
			for (int i = 0; i < conn.GetRowCount(); i++) 
			{
				DDL_BANK.Items.Add(new ListItem(conn.GetFieldValue(i,1), conn.GetFieldValue(i,0))); 
			}
		}

	
		private void ViewNama()
		{
			DDL_NAMA.Items.Clear();
			DDL_NAMA.Items.Add(new ListItem("--Pilih--",""));
			
			conn.QueryString="select * from rekanan_rfnama where active='1'";
			//conn.QueryString= "select rekanan_ref, nama from rekanan_pengurus where rekanan_ref='" + Request.QueryString["rekanan_ref"] + "'";
			conn.QueryString= "select seq, nama from rekanan_pengurus where rekanan_ref='" + Request.QueryString["rekanan_ref"] + "'";
			conn.ExecuteQuery();
								
			for (int i = 0; i < conn.GetRowCount(); i++) 
			{
				DDL_NAMA.Items.Add(new ListItem(conn.GetFieldValue(i,1), conn.GetFieldValue(i,0))); 
			}
		}
		private void BTN_INSERT_Click(object sender, System.EventArgs e)
		{
			try
			{
				Int64 now = Int64.Parse(Tools.toISODate(DateTime.Now.Day.ToString(), DateTime.Now.Month.ToString(), DateTime.Now.Year.ToString())), compEstablish;
				Int64 tanggalBI;
				Int64 tanggalPos;

				if (!GlobalTools.isDateValid(TXT_CS_DOB_DAY.Text, DDL_IDI_BI_MONTH.SelectedValue, TXT_CS_DOB_YEAR.Text)) 
				{
					GlobalTools.popMessage(this, "Tanggal IDI. BI tidak valid!");
					return;
				}
				else 
				{			
					tanggalBI = Int64.Parse(Tools.toISODate(TXT_CS_DOB_DAY.Text, DDL_IDI_BI_MONTH.SelectedValue, TXT_CS_DOB_YEAR.Text));

					if (tanggalBI > now) 
					{
						GlobalTools.popMessage(this, "Tanggal IDI. BI tidak bisa lebih dari tanggal saat ini!");
						return;
					}
				}

				if (!GlobalTools.isDateValid(TXT_POS_DT_DAY.Text, DDL_POSISI_MONTH.SelectedValue, TXT_POS_DT_YEAR.Text)) 
				{
					GlobalTools.popMessage(this, "Tanggal IDI. BI tidak valid!");
					return;
				}
				else 
				{			
					tanggalPos = Int64.Parse(Tools.toISODate(TXT_POS_DT_DAY.Text, DDL_POSISI_MONTH.SelectedValue, TXT_POS_DT_YEAR.Text));

					if (tanggalPos > now) 
					{
						GlobalTools.popMessage(this, "Tanggal Posisi Data tidak bisa lebih dari tanggal saat ini!!");
						return;
					}
				}

				conn.QueryString = "exec REKANAN_BI_INSERT " +
					DDL_NAMA.SelectedValue + ", '" + Request.QueryString["rekanan_ref"] + "', '" +
					DDL_NAMA.SelectedItem.Text +"', '"+
					DDL_BANK.SelectedItem.Text + "', " +
					tool.ConvertDate(TXT_CS_DOB_DAY.Text, DDL_IDI_BI_MONTH.SelectedValue, TXT_CS_DOB_YEAR.Text) + ", " +
					tool.ConvertDate(TXT_POS_DT_DAY.Text, DDL_POSISI_MONTH.SelectedValue, TXT_POS_DT_YEAR.Text) + ", '" +
					CREDIT_TYPE.Text + "', " +
					tool.ConvertFloat(BAKI_DEBET.Text) + ", '" +
					//BAKI_DEBET.Text + ", '" +
					DDL_KOLE.SelectedValue + "', '" +
					TUNGGAKAN_AGE.Text + "', " +
					tool.ConvertFloat(TOT_TUNGGAKAN.Text) + ", '" +
					//TOT_TUNGGAKAN.Text + ", '" +
					REMARK.Text + "'";
 
				conn.ExecuteNonQuery();
				ViewData();
				ViewNama();
				ClearData();
			}

			catch(Exception ex)
			{
				string errmsg = ex.Message.Replace("'","");
				if (errmsg.IndexOf("Last Query:") > 0)
					errmsg = errmsg.Substring(0, errmsg.IndexOf("Last Query:"));
				GlobalTools.popMessage(this, errmsg);
				return;
			}	
		}

		private void ClearData()
		{
			DDL_NAMA.SelectedValue="";
			DDL_BANK.SelectedItem.Text="";
			TXT_CS_DOB_DAY.Text="";
			DDL_IDI_BI_MONTH.SelectedValue="";
			TXT_CS_DOB_YEAR.Text="";
			TXT_POS_DT_DAY.Text="";
			DDL_POSISI_MONTH.SelectedValue="";
			TXT_POS_DT_YEAR.Text="";
			CREDIT_TYPE.Text="";
			BAKI_DEBET.Text="";
			DDL_KOLE.SelectedValue="";
			TUNGGAKAN_AGE.Text="";
			TOT_TUNGGAKAN.Text="";
			REMARK.Text="";
		}

		private void BTN_Clear_Click(object sender, System.EventArgs e)
		{
			ClearData();
		}
        
		private void ViewData()
		{
			conn.QueryString = "select SEQ, REKANAN_REF, NAMA,IDI_DATE,BANK_NAME,CREDIT_TYPE,CBAL,KOLE,TUNGGAKAN_AGE,TOT_TUNGGAKAN,POSITION_DATE from REKANAN_BI where rekanan_ref='" + Request.QueryString["rekanan_ref"] + "'";
			conn.ExecuteQuery();
			FillGrid(); 
		}

			
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		
		private void DatGrd_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			DatGrd.CurrentPageIndex = e.NewPageIndex;
			ViewData();
			
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
			for (int i = 0; i < DatGrd.Items.Count; i++)
			{
				DatGrd.Items[i].Cells[6].Text = tool.MoneyFormat(DatGrd.Items[i].Cells[6].Text);
				DatGrd.Items[i].Cells[9].Text = tool.MoneyFormat(DatGrd.Items[i].Cells[9].Text);
			}
		}

		private void DatGrd_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			switch (((LinkButton)e.CommandSource).CommandName)
			{
				case "lnk_delete":

					conn.QueryString = "delete from rekanan_bi where rekanan_ref='" + Request.QueryString["rekanan_ref"] + "' and SEQ=" + Convert.ToInt32(e.Item.Cells[0].Text) + "";
					conn.ExecuteQuery();
					conn.QueryString = "update rekanan_rfnama set active='1' where rekanan_ref='" + Request.QueryString["rekanan_ref"] + "' and SEQ=" + Convert.ToInt32(e.Item.Cells[0].Text) + "";
					conn.ExecuteQuery();
					ViewData();
					FillGrid();
					ViewNama();
					
					break;

				case "lnk_edit":

					BTN_UPDATE.Visible=true;
					BTN_INSERT.Visible=false;
					conn.QueryString = "update rekanan_rfnama set active='1' where rekanan_ref='" + Request.QueryString["rekanan_ref"] + "' and SEQ=" + Convert.ToInt32(e.Item.Cells[0].Text) + "";
					conn.ExecuteQuery();
					ViewNama(); 
					conn.QueryString = "select * from rekanan_bi where rekanan_ref='" + Request.QueryString["rekanan_ref"] + "' and SEQ=" + Convert.ToInt32(e.Item.Cells[0].Text) + "";
					conn.ExecuteQuery();	

					//seq = Convert.ToInt32(conn.GetFieldValue("SEQ"));

					//DDL_NAMA.Items.Add(new ListItem(conn.GetFieldValue("NAMA"),conn.GetFieldValue("REKANAN_REF")));
					try{DDL_NAMA.SelectedValue=conn.GetFieldValue("seq");}
					catch {DDL_NAMA.SelectedValue="";}

					try{DDL_BANK.SelectedItem.Text = conn.GetFieldValue("BANK_NAME");}
					catch{DDL_BANK.SelectedItem.Text = "";}

					try{DDL_KOLE.SelectedValue = conn.GetFieldValue("KOLE");}
					catch{DDL_KOLE.SelectedValue = "";}
					
					TXT_CS_DOB_DAY.Text = tool.FormatDate_Day(conn.GetFieldValue("IDI_DATE"));
					try{DDL_IDI_BI_MONTH.SelectedValue = tool.FormatDate_Month(conn.GetFieldValue("IDI_DATE"));}
					catch {DDL_IDI_BI_MONTH.SelectedValue="";}
					TXT_CS_DOB_YEAR.Text = tool.FormatDate_Year(conn.GetFieldValue("IDI_DATE"));

					TXT_POS_DT_DAY.Text = tool.FormatDate_Day(conn.GetFieldValue("POSITION_DATE"));;
					try{DDL_POSISI_MONTH.SelectedValue = tool.FormatDate_Month(conn.GetFieldValue("POSITION_DATE"));}
					catch {DDL_POSISI_MONTH.SelectedValue="";}
					TXT_POS_DT_YEAR.Text = tool.FormatDate_Year(conn.GetFieldValue("POSITION_DATE"));

					CREDIT_TYPE.Text = conn.GetFieldValue("CREDIT_TYPE");
					BAKI_DEBET.Text = conn.GetFieldValue("CBAL");
					//KOLE.Text = conn.GetFieldValue("KOLE");
					TUNGGAKAN_AGE.Text = conn.GetFieldValue("TUNGGAKAN_AGE");
					TOT_TUNGGAKAN.Text = conn.GetFieldValue("TOT_TUNGGAKAN");
					REMARK.Text = conn.GetFieldValue("REMARK");
					TXT_SEQ.Text = conn.GetFieldValue("SEQ");

					BAKI_DEBET.Text = tool.MoneyFormat(BAKI_DEBET.Text);
					TOT_TUNGGAKAN.Text = tool.MoneyFormat(TOT_TUNGGAKAN.Text);

					ViewData();
					break;
			}
		
		}

		private void BTN_UPDATE_Click(object sender, System.EventArgs e)
		{
			//	try
			//	{
			conn.QueryString = "exec REKANAN_BI_UPDATE " +
					
				//Convert.ToUInt32(TXT_SEQ.Text) + ", 
				DDL_NAMA.SelectedValue + ", '" +
				Request.QueryString["rekanan_ref"] + "', '" +
				DDL_NAMA.SelectedItem.Text +"', '"+
				DDL_BANK.SelectedItem.Text + "', " +
				tool.ConvertDate(TXT_CS_DOB_DAY.Text, DDL_IDI_BI_MONTH.SelectedValue, TXT_CS_DOB_YEAR.Text) + ", " +
				tool.ConvertDate(TXT_POS_DT_DAY.Text, DDL_POSISI_MONTH.SelectedValue, TXT_POS_DT_YEAR.Text) + ", '" +
				CREDIT_TYPE.Text + "', " +
				tool.ConvertFloat(BAKI_DEBET.Text) + ", '" +
				//BAKI_DEBET.Text + ", '" +
				DDL_KOLE.SelectedValue + "', '" +
				TUNGGAKAN_AGE.Text + "', " +
				tool.ConvertFloat(TOT_TUNGGAKAN.Text) + ", '" +
				//TOT_TUNGGAKAN.Text + ", '" +
				REMARK.Text + "'";
			conn.ExecuteNonQuery();
			//}
			//catch
			//{
			//	GlobalTools.popMessage(this, "Connection Error!");
			//		Response.Redirect("../Login.aspx?expire=1");
			//	}
			ViewData();
			
			BTN_UPDATE.Visible = false;
			BTN_INSERT.Visible = true;
			
			ClearData();
			ViewNama();
		}
	

		private void ViewMenu()
		{
			Menu.Controls.Clear();
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
							strtemp = "regnum=" + Request.QueryString["regnum"] + "&rekanan_ref="+Request.QueryString["rekanan_ref"]  + "&tc=" + Request.QueryString["tc"] + "&exist=" + Request.QueryString["exist"]+ "&view=" + Request.QueryString["view"];
						else	
							strtemp = "regnum=" + Request.QueryString["regnum"] + "&rekanan_ref="+Request.QueryString["rekanan_ref"]  + "&mc=" + Request.QueryString["mc"]+ "&exist=" + Request.QueryString["exist"]+ "&tc="+Request.QueryString["tc"]+ "&view=" + Request.QueryString["view"];
						if (conn.GetFieldValue(i,3).IndexOf("?par=") < 0 && conn.GetFieldValue(i,3).IndexOf("&par=") < 0)  
							strtemp = strtemp + "&par=" + Request.QueryString["par"] + "&mc2=" + Request.QueryString["mc2"];
					}
					else 
					{
						strtemp = ""; 
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

		private void BTN_BACK_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			Response.Redirect("ListRekananInput.aspx?tc=" + Request.QueryString["tc"]+ "&mc=" + Request.QueryString["mc"]);
		}

		private void BAKI_DEBET_TextChanged(object sender, System.EventArgs e)
		{
			BAKI_DEBET.Text = tool.MoneyFormat(BAKI_DEBET.Text);
		}

		private void TOT_TUNGGAKAN_TextChanged(object sender, System.EventArgs e)
		{
			TOT_TUNGGAKAN.Text = tool.MoneyFormat(TOT_TUNGGAKAN.Text);
		}

		private void CekView()
		{
			if(Request.QueryString["view"]=="1")
			{
				TXT_CS_DOB_DAY.ReadOnly = true;
				TXT_CS_DOB_YEAR.ReadOnly = true;
				BTN_INSERT.Enabled = false;
				DDL_IDI_BI_MONTH.Enabled = false;
				DDL_POSISI_MONTH.Enabled = false;
				DDL_NAMA.Enabled = false;
				//NAMA_BANK.ReadOnly = true;
				TXT_POS_DT_DAY.ReadOnly = true;
				TXT_POS_DT_YEAR.ReadOnly = true;
				CREDIT_TYPE.ReadOnly = true;
				BAKI_DEBET.ReadOnly = true;
				//KOLE.ReadOnly = true;
				TUNGGAKAN_AGE.ReadOnly = true;
				TOT_TUNGGAKAN.ReadOnly = true;
				REMARK.ReadOnly = true;
				DatGrd.Columns[11].Visible = false;
				BTN_Clear.Enabled = false;
				BTN_UPDATE.Enabled = false;
				DDL_BANK.Enabled = false;
				DDL_KOLE.Enabled = false;
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
			this.BTN_BACK.Click += new System.Web.UI.ImageClickEventHandler(this.BTN_BACK_Click);
			this.DatGrd.ItemCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.DatGrd_ItemCommand);
			this.BAKI_DEBET.TextChanged += new System.EventHandler(this.BAKI_DEBET_TextChanged);
			this.TOT_TUNGGAKAN.TextChanged += new System.EventHandler(this.TOT_TUNGGAKAN_TextChanged);
			this.BTN_INSERT.Click += new System.EventHandler(this.BTN_INSERT_Click);
			this.BTN_UPDATE.Click += new System.EventHandler(this.BTN_UPDATE_Click);
			this.BTN_Clear.Click += new System.EventHandler(this.BTN_Clear_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion
	}
}
