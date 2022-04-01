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
	/// Summary description for RekananTercela.
	/// </summary>
	public partial class RekananTercela : System.Web.UI.Page
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
				DDL_MONTH.Items.Add(new ListItem("--Pilih--",""));				
				for (int i = 1; i <= 12; i++)
					DDL_MONTH.Items.Add(new ListItem(DateAndTime.MonthName(i, false), i.ToString()));
	
				DDL_JNS_REKANAN.Items.Add(new ListItem("--Pilih--",""));
				conn.QueryString="select rekananid, rekanandesc from rfjenisrekanan where active='1'";
				conn.ExecuteQuery();
				for (int j = 0; j < conn.GetRowCount(); j++)
					DDL_JNS_REKANAN.Items.Add(new ListItem(conn.GetFieldValue(j,1), conn.GetFieldValue(j,0)));	
		
				DDL_BDG_KEAHLIAN.Items.Add(new ListItem("--Pilih--",""));
				conn.QueryString="select rekananid, rekanandesc from rfjenisrekanan where active='1'";
				conn.ExecuteQuery();
				for (int k = 0; k < conn.GetRowCount(); k++)
					DDL_BDG_KEAHLIAN.Items.Add(new ListItem(conn.GetFieldValue(k,1), conn.GetFieldValue(k,0)));	

				ViewData();
				BTN_UPDATE.Visible=false;
				FLAG.Text="0";
				
			}		
			
		}

		protected void BTN_INSERT_Click(object sender, System.EventArgs e)
		{
			if (FLAG.Text=="1")
			{
				GlobalTools.popMessage(this, "Jika ingin memasukkan data baru, klik tombol Clear terlebih dahulu!");
				return;
			}
			else if (FLAG.Text=="0")
			{
				Int64 now = Int64.Parse(Tools.toISODate(DateTime.Now.Day.ToString(), DateTime.Now.Month.ToString(), DateTime.Now.Year.ToString())), compEstablish;
			
				conn.QueryString = "exec REKANAN_Insert_Rekanan_Tercela '" +
					TXT_NAMA.Text +"', '" + 
					TXT_BIRTH_PLACE.Text + "', "+				
					tool.ConvertDate(TXT_DAY.Text, DDL_MONTH.SelectedValue, TXT_YEAR.Text) + ", '" +				
					TXT_ID.Text + "', '" +				
					TXT_ADDRESS.Text + "', '" +				
					DDL_JNS_REKANAN.SelectedValue + "', '" +				
					DDL_JNS_REKANAN.SelectedItem.Text + "', '" +
					TXT_CAT.Text +"' ";
 
				conn.ExecuteNonQuery();
				ViewData();
			
				ClearData();
				
			}
			
					
		}

		private void DGR_DAFTAR_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			switch (((LinkButton)e.CommandSource).CommandName)
			{
				case "lnk_delete":

					conn.QueryString = "delete from rekanan_tercela where SEQ=" + Convert.ToInt32(e.Item.Cells[0].Text) + "";
					conn.ExecuteQuery();
					
					ViewData();
					FillGrid();
					ClearData();
					BTN_INSERT.Visible=true;
					BTN_UPDATE.Visible=false;
					BTN_CLEAR.Visible=true;

					TXT_NAMA.ReadOnly=false;
					TXT_BIRTH_PLACE.ReadOnly=false;
					TXT_DAY.ReadOnly=false;
					DDL_MONTH.Enabled=true;
					TXT_YEAR.ReadOnly=false;
					DDL_JNS_REKANAN.Enabled=true;
					TXT_ADDRESS.ReadOnly=false;
					TXT_ID.ReadOnly=false;
					TXT_CAT.ReadOnly=false;
					
					break;

				case "lnk_edit":

					BTN_UPDATE.Visible=true;
					BTN_INSERT.Visible=false;
					BTN_CLEAR.Visible=true;

					TXT_NAMA.ReadOnly=false;
					TXT_BIRTH_PLACE.ReadOnly=false;
					TXT_DAY.ReadOnly=false;
					DDL_MONTH.Enabled=true;
					TXT_YEAR.ReadOnly=false;
					DDL_JNS_REKANAN.Enabled=true;
					TXT_ADDRESS.ReadOnly=false;
					TXT_ID.ReadOnly=false;
					TXT_CAT.ReadOnly=false;
					
					conn.QueryString = "select * from rekanan_tercela where SEQ=" + Convert.ToInt32(e.Item.Cells[0].Text) + "";
					conn.ExecuteQuery();						

					TXT_NAMA.Text = conn.GetFieldValue("NAMA");
					LBL_NAMA.Text = conn.GetFieldValue("NAMA");

					TXT_BIRTH_PLACE.Text = conn.GetFieldValue("TEMPAT_LAHIR");
					LBL_BIRTH_PLACE.Text =  conn.GetFieldValue("TEMPAT_LAHIR");

					TXT_ID.Text = conn.GetFieldValue("NO_IDENTITAS");
					LBL_ID.Text =  conn.GetFieldValue("NO_IDENTITAS");

					TXT_ADDRESS.Text = conn.GetFieldValue("ALAMAT");
					LBL_ADDRESS.Text = conn.GetFieldValue("ALAMAT");
					
					TXT_DAY.Text = tool.FormatDate_Day(conn.GetFieldValue("TGL_LAHIR"));
					LBL_DAY.Text = tool.FormatDate_Day(conn.GetFieldValue("TGL_LAHIR"));

					try{
						DDL_MONTH.SelectedValue = tool.FormatDate_Month(conn.GetFieldValue("TGL_LAHIR"));
						LBL_MONTH.Text = tool.FormatDate_Month(conn.GetFieldValue("TGL_LAHIR"));
					}
					catch {DDL_MONTH.SelectedValue="";}
					TXT_YEAR.Text = tool.FormatDate_Year(conn.GetFieldValue("TGL_LAHIR"));
					LBL_YEAR.Text = tool.FormatDate_Year(conn.GetFieldValue("TGL_LAHIR"));

					try{DDL_JNS_REKANAN.SelectedValue = conn.GetFieldValue("rfrekanantype");}
					catch {DDL_JNS_REKANAN.SelectedValue="";}
					
					TXT_SEQ.Text = conn.GetFieldValue("SEQ");
					TXT_CAT.Text = conn.GetFieldValue("ALASAN");
					LBL_CAT.Text = conn.GetFieldValue("ALASAN");

					//ViewData();
					
					break;

				case "lnk_view":

					FLAG.Text="1";

					conn.QueryString = "select * from rekanan_tercela where SEQ=" + Convert.ToInt32(e.Item.Cells[0].Text) + "";
					conn.ExecuteQuery();

					BTN_UPDATE.Visible=false;
					BTN_INSERT.Visible=true;
					BTN_CLEAR.Visible=true;

					TXT_NAMA.ReadOnly=true;
					TXT_BIRTH_PLACE.ReadOnly=true;
					TXT_DAY.ReadOnly=true;
					DDL_MONTH.Enabled=false;
					TXT_YEAR.ReadOnly=true;
					DDL_JNS_REKANAN.Enabled=false;
					TXT_ADDRESS.ReadOnly=true;
					TXT_ID.ReadOnly=true;
					TXT_CAT.ReadOnly=true;

					TXT_NAMA.Text = conn.GetFieldValue("NAMA");
					TXT_BIRTH_PLACE.Text = conn.GetFieldValue("TEMPAT_LAHIR");
					TXT_ID.Text = conn.GetFieldValue("NO_IDENTITAS");
					TXT_ADDRESS.Text = conn.GetFieldValue("ALAMAT");
					
					TXT_DAY.Text = tool.FormatDate_Day(conn.GetFieldValue("TGL_LAHIR"));
					try{DDL_MONTH.SelectedValue = tool.FormatDate_Month(conn.GetFieldValue("TGL_LAHIR"));}
					catch {DDL_MONTH.SelectedValue="";}
					TXT_YEAR.Text = tool.FormatDate_Year(conn.GetFieldValue("TGL_LAHIR"));

					try{DDL_JNS_REKANAN.SelectedValue = conn.GetFieldValue("rfrekanantype");}
					catch {DDL_JNS_REKANAN.SelectedValue="";}
					
					TXT_SEQ.Text = conn.GetFieldValue("SEQ");
					TXT_CAT.Text = conn.GetFieldValue("ALASAN");

				break;

				
			}
		
		}



		private void AuditTrailCheck(string kodeJenisData)
		{
			string userName		= Session["FullName"].ToString();
			string status		= "update";
			string rekanan_ref	= "";
			string regnum		= "";
			string jenisrek		= DDL_JNS_REKANAN.SelectedValue;
			string nama			= TXT_NAMA.Text;
			string temp			=  "";
			string sqlpar		=	rekanan_ref + "', '" +
				regnum + "', '" +
				kodeJenisData + "', '" +
				jenisrek + "', '" +
				nama + "', '" +
				userName + "', '" +
				status +  "' ";

			if(TXT_NAMA.Text!=LBL_NAMA.Text)
			{	
				temp="Nama: ";
				try
				{
					conn.QueryString = "EXEC REKANAN_AUDITTRAIL_INSERT '"+
						sqlpar + ", '" +
						temp + TXT_NAMA.Text + "', '" +
						temp + LBL_NAMA.Text+ "'"; 
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

			if(LBL_BIRTH_PLACE.Text!=TXT_BIRTH_PLACE.Text)
			{	
				temp="Tempat lahir: ";
				try
				{
					conn.QueryString = "EXEC REKANAN_AUDITTRAIL_INSERT '"+
						sqlpar + ", '" +
						temp + LBL_BIRTH_PLACE.Text + "', '" +
						temp + TXT_BIRTH_PLACE.Text+ "'"; 
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

			string tgllhr = tool.ConvertDate(LBL_DAY.Text, LBL_MONTH.Text, LBL_YEAR.Text);
			string tgllhiNew = tool.ConvertDate(TXT_DAY.Text, DDL_MONTH.SelectedValue, TXT_YEAR.Text);
			if(tgllhr!=tgllhiNew)
			{	
				temp="Tgl Lahir: ";
				try
				{
					conn.QueryString = "EXEC REKANAN_AUDITTRAIL_INSERT '"+
						sqlpar + ", '" +
						temp + tgllhr.Replace("'","") + "', '" +
						temp + tgllhiNew.Replace("'","") + "'"; 
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

			if(LBL_ID.Text!=TXT_ID.Text)
			{	
				temp="No. Identitas: ";
				try
				{
					conn.QueryString = "EXEC REKANAN_AUDITTRAIL_INSERT '"+
						sqlpar + ", '" +
						temp + LBL_ID.Text + "', '" +
						temp + TXT_ID.Text+ "'"; 
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

			if(LBL_ADDRESS.Text!=TXT_ADDRESS.Text)
			{	
				temp="Alamat: ";
				try
				{
					conn.QueryString = "EXEC REKANAN_AUDITTRAIL_INSERT '"+
						sqlpar + ", '" +
						temp + LBL_ADDRESS.Text + "', '" +
						temp + TXT_ADDRESS.Text+ "'"; 
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

			if(LBL_JNS_REKANAN.Text!=DDL_JNS_REKANAN.SelectedItem.Text)
			{	
				temp="Bidang keahlian: ";
				try
				{
					conn.QueryString = "EXEC REKANAN_AUDITTRAIL_INSERT '"+
						sqlpar + ", '" +
						temp + LBL_JNS_REKANAN.Text + "', '" +
						temp + DDL_JNS_REKANAN.SelectedItem.Text+ "'"; 
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

			if(LBL_CAT.Text!=TXT_CAT.Text)
			{	
				temp="Alasan: ";
				try
				{
					conn.QueryString = "EXEC REKANAN_AUDITTRAIL_INSERT '"+
						sqlpar + ", '" +
						temp + LBL_CAT.Text + "', '" +
						temp + TXT_CAT.Text+ "'"; 
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
		
		protected void BTN_UPDATE_Click(object sender, System.EventArgs e)
		{
			AuditTrailCheck("71");
			try
				{
			conn.QueryString = "exec REKANAN_Update_Rekanan_Tercela " +
				Convert.ToUInt32(TXT_SEQ.Text) + ", '"+	
				TXT_NAMA.Text +"', '" + 
				TXT_BIRTH_PLACE.Text + "', "+				
				tool.ConvertDate(TXT_DAY.Text, DDL_MONTH.SelectedValue, TXT_YEAR.Text) + ", '" +				
				TXT_ID.Text + "', '" +				
				TXT_ADDRESS.Text + "', '" +				
				DDL_JNS_REKANAN.SelectedValue + "', '" +				
				DDL_JNS_REKANAN.SelectedItem.Text + "', '" +
				TXT_CAT.Text +"' ";

			conn.ExecuteNonQuery();

			ViewData();

				}

			catch
				{
					GlobalTools.popMessage(this, "Connection Error!");
					Response.Redirect("../Login.aspx?expire=1");
				}
			//ViewData();
			
			BTN_UPDATE.Visible = false;
			BTN_INSERT.Visible = true;
			
			ClearData();
			
		}
	

		private void DGR_DAFTAR_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			 DGR_DAFTAR.CurrentPageIndex = e.NewPageIndex;
			ViewData();
			
		}

		protected void BTN_CLEAR_Click(object sender, System.EventArgs e)
		{
			ClearData();
			FLAG.Text="0";
			
		}

		private void SearchData()
		{
			string query=""; 
			
			if(TXT_CR_NAMA.Text!="")
			{
				query += "and nama LIKE '%" + TXT_CR_NAMA.Text + "%' ";
			}
			if(TXT_CR_ID.Text!="")
			{
				query += "and no_identitas='" + TXT_CR_ID.Text + "' ";
			}

			if(DDL_BDG_KEAHLIAN.SelectedValue!="")
			{
				query += "and rfrekanantype='" + DDL_BDG_KEAHLIAN.SelectedValue + "' ";
			}

			if(query!="")
			{
				conn.QueryString="select * from REKANAN_TERCELA where 1=1 " + query;
				conn.ExecuteQuery();
				FillGrid();
			}
		}

		protected void btn_Find_Click(object sender, System.EventArgs e)
		{
			//DGR_DAFTAR.CurrentPageIndex = 0;
			SearchData();
			ClearData();
			
		}


		private void ClearData()
		{
			TXT_NAMA.Text="";
			TXT_BIRTH_PLACE.Text="";
			TXT_DAY.Text="";
			DDL_MONTH.SelectedValue="";
			TXT_YEAR.Text="";
			TXT_ID.Text="";
			TXT_ADDRESS.Text="";			
			DDL_JNS_REKANAN.SelectedValue="";
			TXT_CAT.Text="";
			TXT_NAMA.ReadOnly=false;
			TXT_BIRTH_PLACE.ReadOnly=false;
			TXT_DAY.ReadOnly=false;
			DDL_MONTH.Enabled=true;
			TXT_YEAR.ReadOnly=false;
			DDL_JNS_REKANAN.Enabled=true;
			TXT_ADDRESS.ReadOnly=false;
			TXT_ID.ReadOnly=false;
			TXT_CAT.ReadOnly=false;
		}


		private void ViewData()
		{
			conn.QueryString = "select * from rekanan_tercela";
			conn.ExecuteQuery();
			FillGrid(); 
		}

		private void FillGrid()
		{
			DataTable dt = new DataTable();
			dt = conn.GetDataTable().Copy();
			DGR_DAFTAR.DataSource = dt;
			try 
			{
				DGR_DAFTAR.DataBind();
			} 
			catch 
			{
				DGR_DAFTAR.CurrentPageIndex = 0;
				DGR_DAFTAR.DataBind();
			}
			for (int i = 0; i < DGR_DAFTAR.Items.Count; i++)
			{
				DGR_DAFTAR.Items[i].Cells[3].Text = tool.FormatDate(DGR_DAFTAR.Items[i].Cells[3].Text, true);
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
			this.DGR_DAFTAR.ItemCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.DGR_DAFTAR_ItemCommand);

		}
		#endregion
	}
}
