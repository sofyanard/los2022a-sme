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
	/// Summary description for Sanksi.
	/// </summary>
	public partial class Sanksi : System.Web.UI.Page
	{
		protected Connection conn;
		protected System.Web.UI.WebControls.DataGrid Datagrid1;
		protected Tools tool = new Tools();
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			conn = (Connection) Session["Connection"];

			if (!Logic.AllowAccess(Session["GroupID"].ToString(), Request.QueryString["mc"], conn))
				Response.Redirect("/SME/Restricted.aspx");
			
			if(!IsPostBack)
			{
				DDL_JNS_SANKSI.Items.Add(new ListItem("--Pilih--",""));	
				DDL_JANGKA_WKT_SANKSI.Items.Add(new ListItem("--Pilih--",""));
				DDL_JANGKA_WKT_SANKSI_EXT.Items.Add(new ListItem("--Pilih--",""));
				TR_INFO.Visible=false;
				TR_SANKSI.Visible=false;	
				TR_SANKSI_EXT.Visible=false;

				DDL_BLN_SURAT.Items.Add(new ListItem("--Pilih-",""));
				for(int i=1; i<=12; i++)
					DDL_BLN_SURAT.Items.Add(new ListItem(DateAndTime.MonthName(i, false), i.ToString()));

				DDL_BLN_EXT.Items.Add(new ListItem("--Pilih-",""));
				for(int j=1; j<=12; j++)
					DDL_BLN_EXT.Items.Add(new ListItem(DateAndTime.MonthName(j, false), j.ToString()));

				conn.QueryString = "select tenorcode, tenordesc from rftenorcode where active='1'";
				conn.ExecuteQuery();
				for (int i = 0; i < conn.GetRowCount(); i++)
				{
					DDL_JANGKA_WKT_SANKSI.Items.Add(new ListItem(conn.GetFieldValue(i,1), conn.GetFieldValue(i,0)));
					DDL_JANGKA_WKT_SANKSI_EXT.Items.Add(new ListItem(conn.GetFieldValue(i,1), conn.GetFieldValue(i,0)));
				}

				ViewDataPending();
				SearchData();
				//BTN_UPDATE.Visible = false;
			}
			BTN_UPDATE.Visible = false;
			BTN_SAVE.Visible = true;

			
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
			this.DGR_DAFTAR.ItemCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.DGR_DAFTAR_ItemCommand);

		}
		#endregion

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

		protected void btn_Find_Click(object sender, System.EventArgs e)
		{
			DatGrd.CurrentPageIndex = 0;
			SearchData();
			ClearData();
			ClearDataInfoRekanan();
		}

		private void SearchData()
		{
			string query=""; 
			
			if(TXT_REK_NAME.Text!="")
			{
				query += "and namerekanan LIKE '%" + TXT_REK_NAME.Text + "%' ";
			}
			if(TXT_NoReg.Text!="")
			{
				query += "and rekanan_ref='" + TXT_NoReg.Text + "' ";
			}

			//if(query!="")
			//{
				conn.QueryString="select * from vw_rekanan_existing2 where 1=1 " + query;
				conn.ExecuteQuery();
				FillGrid();
			//}
		}

		private void DatGrd_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			switch (((LinkButton)e.CommandSource).CommandName)
			{
				case "View":	
					LBL_REKANANREF.Text = e.Item.Cells[0].Text;
					ClearData();
					ViewData();
					break;				
			}
		}

		private void ViewData()
		{
			TR_INFO.Visible=true;
			TR_SANKSI.Visible=true;
			TR_SANKSI_EXT.Visible=true;
			conn.QueryString = "select rekanantypeid from rekanan where rekanan_ref='" + LBL_REKANANREF.Text + "'";
			conn.ExecuteQuery();

			if (conn.GetFieldValue("rekanantypeid")=="01")
			{
				conn.QueryString="select top 1 rekanan_ref, rekanandesc, namerekanan, pic_name, address1, address2, city, phone_area + '-' + phone# as phone from vw_rekanan_company where rekanan_ref='" + LBL_REKANANREF.Text + "'";
				conn.ExecuteQuery();

				TXT_REGNUM.Text = conn.GetFieldValue("rekanan_ref");
				TXT_JNS_REK.Text = conn.GetFieldValue("rekanandesc");
				TXT_NAMA_REK.Text = conn.GetFieldValue("namerekanan");
				TXT_CP.Text = conn.GetFieldValue("pic_name");
				TXT_ADDRESS1.Text = conn.GetFieldValue("address1");
				TXT_ADDRESS2.Text = conn.GetFieldValue("address2");
				TXT_CITY.Text = conn.GetFieldValue("city");
				TXT_NOTLP.Text = conn.GetFieldValue("phone");
			}
			else
			{
				conn.QueryString="select top 1 rekanan_ref, rekanandesc, namerekanan, address1, address2, city, office_area + '-' + office# as phone from vw_rekanan_personal where rekanan_ref='" + LBL_REKANANREF.Text + "'";
				conn.ExecuteQuery();

				TXT_REGNUM.Text = conn.GetFieldValue("rekanan_ref");
				TXT_JNS_REK.Text = conn.GetFieldValue("rekanandesc");
				TXT_NAMA_REK.Text = conn.GetFieldValue("namerekanan");
				TXT_ADDRESS1.Text = conn.GetFieldValue("address1");
				TXT_ADDRESS2.Text = conn.GetFieldValue("address2");
				TXT_CITY.Text = conn.GetFieldValue("city");
				TXT_NOTLP.Text = conn.GetFieldValue("phone");
			}

			ViewSanksi();
			//conn.QueryString = "select * from rekanan_sanksi_temp where rekanan_ref='" + LBL_REKANANREF.Text + "'";
			//conn.ExecuteQuery();
			//try{DDL_JNS_SANKSI.SelectedValue = conn.GetFieldValue("RF_SANKSI_TYPE");}
			//catch{DDL_JNS_SANKSI.SelectedValue ="";}
			//ViewProblem();
			//ViewDataSanksi();
			
		}

		/*private void ViewDataSanksi()
		{
			conn.QueryString = "select * from rekanan_sanksi_temp where rekanan_ref='" + LBL_REKANANREF.Text + "'";
			conn.ExecuteQuery();
			if (conn.GetRowCount() > 0)
			{
				//Sanksi Internal
				DDL_JNS_SANKSI.SelectedValue = conn.GetFieldValue("RF_SANKSI_TYPE");
				TXT_NO_SURAT.Text = conn.GetFieldValue("LETTER#");
				TXT_TGL_SURAT.Text = tool.FormatDate_Day(conn.GetFieldValue("LETTER_DATE"));
				DDL_BLN_SURAT.SelectedValue = tool.FormatDate_Month(conn.GetFieldValue("LETTER_DATE"));
				TXT_THN_SURAT.Text = tool.FormatDate_Year(conn.GetFieldValue("LETTER_DATE"));
				TXT_JANGKA_WKT_SANKSI.Text = conn.GetFieldValue("TENOR");
				DDL_JANGKA_WKT_SANKSI.SelectedValue = conn.GetFieldValue("PERIODE");
				DDL_PROBLEM.SelectedValue = conn.GetFieldValue("RFPROBLEM");
				TXT_STATUS_SANKSI.Text = conn.GetFieldValue("RFSTATUS");
				
				//Sanksi Eksternal
				SANKSI_EXT.Text = conn.GetFieldValue("sanksi");
				NO_SURAT_EXT.Text = conn.GetFieldValue("no_surat");
				TXT_DAY_EXT.Text = tool.FormatDate_Day(conn.GetFieldValue("tgl_surat"));
				DDL_BLN_EXT.SelectedValue = tool.FormatDate_Month(conn.GetFieldValue("tgl_surat"));
				TXT_YEAR_EXT.Text = tool.FormatDate_Year(conn.GetFieldValue("tgl_surat"));
				DIKELUARKAN_EXT.Text = conn.GetFieldValue("dikeluarkan");
				JANGKA_WKT_EXT.Text = conn.GetFieldValue("jangka_waktu");
				MASALAH_EXT.Text = conn.GetFieldValue("permasalahan");
				STATUS_EXT.Text = conn.GetFieldValue("status_sanksi");
				KET_EXT.Text = conn.GetFieldValue("keterangan");
			}
		}*/

		private void DatGrd_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			DatGrd.CurrentPageIndex = e.NewPageIndex;
			SearchData();
		}

		private void DDL_JNS_SANKSI_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			ViewProblem();
			if(DDL_JNS_SANKSI.SelectedValue=="S03")
			{
				TXT_JANGKA_WKT_SANKSI.Enabled = false;
				DDL_JANGKA_WKT_SANKSI.Enabled = false;
			}
			else
			{
				TXT_JANGKA_WKT_SANKSI.Enabled = true;
				DDL_JANGKA_WKT_SANKSI.Enabled = true;
			}
		}

		private void ViewSanksi()
		{
			DDL_JNS_SANKSI.Items.Clear();
			DDL_JNS_SANKSI.Items.Add(new ListItem("--Pilih--",""));
			conn.QueryString = "select sanksi_id, sanksidesc from rekanan_rfsanksi where active='1'";
			conn.ExecuteQuery();
			for (int i = 0; i < conn.GetRowCount();i++)
				DDL_JNS_SANKSI.Items.Add(new ListItem(conn.GetFieldValue(i,1), conn.GetFieldValue(i,0)));
		}

		private void ViewProblem()
		{
			DDL_PROBLEM.Items.Clear();
			DDL_PROBLEM.Items.Add(new ListItem("--Pilih--",""));

			conn.QueryString = "select rfrekanantype from rekanan where rekanan_ref='" + LBL_REKANANREF.Text + "'";
			conn.ExecuteQuery();

			conn.QueryString = "select problem_id, problemdesc from vw_rekanan_problem where rfrekanantype='" + conn.GetFieldValue("rfrekanantype") + "' and sanksi_id='" + DDL_JNS_SANKSI.SelectedValue + "'";
			conn.ExecuteQuery();
			for (int i=0; i< conn.GetRowCount(); i++)
				DDL_PROBLEM.Items.Add(new ListItem(conn.GetFieldValue(i,1), conn.GetFieldValue(i,0)));
		}

		protected void BTN_SAVE_Click(object sender, System.EventArgs e)
		{
			string teamleader;
			Int64 now = Int64.Parse(Tools.toISODate(DateTime.Now.Day.ToString(), DateTime.Now.Month.ToString(), DateTime.Now.Year.ToString())), LetterDate;

			if(DDL_JNS_SANKSI.SelectedValue!="")
			{
				//PENGECEKAN KET SANKSI LAINNYA -- ARIEL
				if(DDL_JNS_SANKSI.SelectedValue=="S04")
				{
					if(TXT_KET_LAINNYA.Text=="")
					{
						GlobalTools.popMessage(this,"Keterangan Sanksi Lainnya belum diisi!");
						return;
					}

				}
				else
				{
					if(DDL_PROBLEM.SelectedValue=="")
					{
						GlobalTools.popMessage(this,"Permasalahan tidak boleh kosong!");
						return;
					}
				}
				
			}

				
			//--VALIDASI TANGGAL SURAT--//
			if(TXT_TGL_SURAT.Text=="" && DDL_BLN_SURAT.SelectedValue=="" && TXT_THN_SURAT.Text=="")
			{
				
			}
			else
			{
				try 
				{
					LetterDate = Int64.Parse(Tools.toISODate(TXT_TGL_SURAT.Text, DDL_BLN_SURAT.SelectedValue, TXT_THN_SURAT.Text));
				} 
				catch 
				{
					GlobalTools.popMessage(this, "Tanggal surat tidak valid!");
					return;
				}
				if (LetterDate > now)
				{
					GlobalTools.popMessage(this, "Tanggal surat tidak boleh lebih besar dari tanggal hari ini!");
					return;
				}
			}

			conn.QueryString = "select su_teamleader from scuser where userid='" + Session["UserID"] + "'";
			conn.ExecuteQuery();
			teamleader = conn.GetFieldValue("su_teamleader");

			//conn.QueryString = "select * from rekanan_sanksi_temp where rekanan_ref='" + LBL_REKANANREF.Text + "'";
			//conn.ExecuteQuery();
			//if (conn.GetRowCount() > 0)
			//{
				/*try
				{
					conn.QueryString = "exec REKANAN_SANKSITEMP_UPDATE '" +
						LBL_REKANANREF.Text + "', '" +
						DDL_JNS_SANKSI.SelectedValue + "', '" +
						TXT_NO_SURAT.Text + "', " +
						tool.ConvertDate(TXT_TGL_SURAT.Text, DDL_BLN_SURAT.SelectedValue, TXT_THN_SURAT.Text) + ", '" +
						tool.ConvertNum(TXT_JANGKA_WKT_SANKSI.Text) + "', '" +
						DDL_JANGKA_WKT_SANKSI.SelectedValue + "', '" +
						DDL_PROBLEM.SelectedValue + "', '" +
						TXT_STATUS_SANKSI.Text + "', '" +
						teamleader + "', '" +
						SANKSI_EXT.Text + "', '" +						
						NO_SURAT_EXT.Text + "', " +
						tool.ConvertDate(TXT_DAY_EXT.Text, DDL_BLN_EXT.SelectedValue, TXT_YEAR_EXT.Text) + ", '" +
						DIKELUARKAN_EXT.Text + "', '" +
						JANGKA_WKT_EXT.Text + "', '" +
						MASALAH_EXT.Text + "', '" +
						STATUS_EXT.Text + "', '" +						
						KET_EXT.Text + "'";
				}
				catch
				{
					GlobalTools.popMessage(this, "Connection Error!");
					Response.Redirect("../../Login.aspx?expire=1");
				}
			}
			else
			{*/
				try
				{
					conn.QueryString = "exec REKANAN_SANKSITEMP_INSERT '" +
						LBL_REKANANREF.Text + "', '" +
						DDL_JNS_SANKSI.SelectedValue + "', '" +
						TXT_NO_SURAT.Text + "', " +
						tool.ConvertDate(TXT_TGL_SURAT.Text, DDL_BLN_SURAT.SelectedValue, TXT_THN_SURAT.Text) + ", '" +
						tool.ConvertNum(TXT_JANGKA_WKT_SANKSI.Text) + "', '" +
						DDL_JANGKA_WKT_SANKSI.SelectedValue + "', '" +
						DDL_PROBLEM.SelectedValue + "', '" +
						TXT_STATUS_SANKSI.Text + "', '" +
						teamleader + "', '" +
						SANKSI_EXT.Text + "', '" +						
						NO_SURAT_EXT.Text + "', " +
						tool.ConvertDate(TXT_DAY_EXT.Text, DDL_BLN_EXT.SelectedValue, TXT_YEAR_EXT.Text) + ", '" +
						DIKELUARKAN_EXT.Text + "', '" +
						tool.ConvertNum(JANGKA_WKT_EXT.Text) + "', '" +
						MASALAH_EXT.Text + "', '" +
						STATUS_EXT.Text + "', '" +						
						KET_EXT.Text + "', '" +
						Session["UserID"] + "', '" +
						DDL_JANGKA_WKT_SANKSI_EXT.SelectedValue + "', '" +
						TXT_KET_LAINNYA.Text + "'";

				}
				catch
				{
					GlobalTools.popMessage(this, "Connection Error!");
					Response.Redirect("../../Login.aspx?expire=1");
				}
			//}
			conn.ExecuteNonQuery();
			ClearData();
			ViewDataPending();
		}

		private void AuditTrailCheck(string kodeJenisData)
		{
			string userName		= Session["FullName"].ToString();
			string status		= "update";
			string rekanan_ref	= LBL_REKANANREF.Text;
			string regnum		= TXT_REGNUM.Text;			

			cekFIELD(kodeJenisData, rekanan_ref, regnum, userName, status);
				
		}

		private void cekFIELD(string kodeJenisData, string rekref, string regnum, string user, string stat)
		{
			
			string nama			= TXT_NAMA_REK.Text;
			string jenisrek		= TXT_JNS_REK.Text;
			string temp			=   "";
			string sqlpar		=	rekref + "', '" +
				regnum + "', '" +
				kodeJenisData + "', '" +
				jenisrek + "', '" +
				nama + "', '" +
				user + "', '" +
				stat +  "' ";

			//cek field yang berubah dan masukan ke audittrail jika ada perubahan
			//---sanksi internal
			if(LBL_JNS_SANKSI.Text!=DDL_JNS_SANKSI.SelectedItem.Text)
			{
				temp="Jenis sanksi internal: ";
				try
				{
					conn.QueryString = "EXEC REKANAN_AUDITTRAIL_INSERT '"+
						sqlpar + ", '" +
						temp + LBL_JNS_SANKSI.Text + "', '" +
						temp + DDL_JNS_SANKSI.SelectedItem.Text + "'"; 
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

			if(LBL_PROBLEM.Text!=DDL_PROBLEM.SelectedItem.Text)
			{
				temp="Sanksi Internal - Permasalahan: ";
				try
				{
					conn.QueryString = "EXEC REKANAN_AUDITTRAIL_INSERT '"+
						sqlpar + ", '" +
						temp + LBL_PROBLEM.Text + "', '" +
						temp + DDL_PROBLEM.SelectedItem.Text + "'"; 
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

			if(LBL_NO_SURAT.Text!=TXT_NO_SURAT.Text)
			{
				temp="Sanksi Internal - No. Surat: ";
				try
				{
					conn.QueryString = "EXEC REKANAN_AUDITTRAIL_INSERT '"+
						sqlpar + ", '" +
						temp + LBL_NO_SURAT.Text + "', '" +
						temp + TXT_NO_SURAT.Text + "'"; 
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
			
			string tglSurat = tool.ConvertDate(LBL_TGL_SURAT.Text, LBL_BLN_SURAT.Text, LBL_THN_SURAT.Text);
			string tglSuratnew = tool.ConvertDate(TXT_TGL_SURAT.Text, DDL_BLN_SURAT.SelectedValue, TXT_THN_SURAT.Text);
			if(tglSurat!=tglSuratnew)
			{	
				temp="Sanksi Internal - Tgl Surat: ";
				try
				{
					conn.QueryString = "EXEC REKANAN_AUDITTRAIL_INSERT '"+
						sqlpar + ", '" +
						temp + tglSurat.Replace("'","") + "', '" +
						temp + tglSuratnew.Replace("'","") + "'"; 
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

			string jgka = LBL_TXT_JANGKA_WKT_SANKSI.Text + " " + LBL_DDL_JANGKA_WKT_SANKSI.Text;
			string jgkaNew = TXT_JANGKA_WKT_SANKSI.Text + " " + DDL_JANGKA_WKT_SANKSI.SelectedItem.Text;
			if(jgka != jgkaNew)
			{
				temp="Sanksi Internal - Jangka Waktu Sanksi: ";
				try
				{
					conn.QueryString = "EXEC REKANAN_AUDITTRAIL_INSERT '"+
						sqlpar + ", '" +
						temp + jgka + "', '" +
						temp + jgkaNew + "'"; 
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

			if(LBL_KET_LAINNYA.Text!=TXT_KET_LAINNYA.Text)
			{
				temp="Sanksi Internal - Keterangan sanksi lainnya: ";
				try
				{
					conn.QueryString = "EXEC REKANAN_AUDITTRAIL_INSERT '"+
						sqlpar + ", '" +
						temp + LBL_KET_LAINNYA.Text + "', '" +
						temp + TXT_KET_LAINNYA.Text + "'"; 
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

			//sanksi eksternal
			if(LBL_SANKSI_EXT.Text!=SANKSI_EXT.Text)
			{
				temp="Sanksi Eksternal: ";
				try
				{
					conn.QueryString = "EXEC REKANAN_AUDITTRAIL_INSERT '"+
						sqlpar + ", '" +
						temp + LBL_SANKSI_EXT.Text + "', '" +
						temp + SANKSI_EXT.Text + "'"; 
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

			if(LBL_NO_SURAT_EXT.Text!=NO_SURAT_EXT.Text)
			{
				temp="Sanksi Eksternal - No. Surat: ";
				try
				{
					conn.QueryString = "EXEC REKANAN_AUDITTRAIL_INSERT '"+
						sqlpar + ", '" +
						temp + LBL_NO_SURAT_EXT.Text + "', '" +
						temp + NO_SURAT_EXT.Text + "'"; 
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
			
			string tglSurate = tool.ConvertDate(LBL_DAY_EXT.Text, LBL_BLN_EXT.Text, LBL_YEAR_EXT.Text);
			string tglSuratenew = tool.ConvertDate(TXT_DAY_EXT.Text, DDL_BLN_EXT.SelectedValue, TXT_YEAR_EXT.Text);
			if(tglSurate!=tglSuratenew)
			{	
				temp="Sanksi Eksternal - Tgl Surat: ";
				try
				{
					conn.QueryString = "EXEC REKANAN_AUDITTRAIL_INSERT '"+
						sqlpar + ", '" +
						temp + tglSurate.Replace("'","") + "', '" +
						temp + tglSuratenew.Replace("'","") + "'"; 
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

			if(LBL_DIKELUARKAN_EXT.Text!=DIKELUARKAN_EXT.Text)
			{
				temp="Sanksi Eksternal - Dikeluarkan oleh: ";
				try
				{
					conn.QueryString = "EXEC REKANAN_AUDITTRAIL_INSERT '"+
						sqlpar + ", '" +
						temp + LBL_DIKELUARKAN_EXT.Text + "', '" +
						temp + DIKELUARKAN_EXT.Text + "'"; 
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

			string jgka1 = LBL_JANGKA_WKT_EXT.Text + " " + LBL_DDL_JANGKA_WKT_SANKSI_EXT.Text;
			string jgkaNew1= JANGKA_WKT_EXT.Text + " " + DDL_JANGKA_WKT_SANKSI_EXT.SelectedItem.Text;
			if(jgka1 != jgkaNew1)
			{
				temp="Sanksi Eksternal - Jangka Waktu Sanksi: ";
				try
				{
					conn.QueryString = "EXEC REKANAN_AUDITTRAIL_INSERT '"+
						sqlpar + ", '" +
						temp + jgka1 + "', '" +
						temp + jgkaNew1 + "'"; 
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
			
			if(LBL_MASALAH_EXT.Text!=MASALAH_EXT.Text)
			{
				temp="Sanksi Eksternal - Permasalahan: ";
				try
				{
					conn.QueryString = "EXEC REKANAN_AUDITTRAIL_INSERT '"+
						sqlpar + ", '" +
						temp + LBL_MASALAH_EXT.Text + "', '" +
						temp + MASALAH_EXT.Text + "'"; 
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

			if(LBL_STATUS_EXT.Text!=STATUS_EXT.Text)
			{
				temp="Sanksi Eksternal - Status Sanksi: ";
				try
				{
					conn.QueryString = "EXEC REKANAN_AUDITTRAIL_INSERT '"+
						sqlpar + ", '" +
						temp + LBL_STATUS_EXT.Text + "', '" +
						temp + STATUS_EXT.Text + "'"; 
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

			if(LBL_KET_EXT.Text!=KET_EXT.Text)
			{
				temp="Sanksi Eksternal - Keterangan: ";
				try
				{
					conn.QueryString = "EXEC REKANAN_AUDITTRAIL_INSERT '"+
						sqlpar + ", '" +
						temp + LBL_KET_EXT.Text + "', '" +
						temp + KET_EXT.Text + "'"; 
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
			string teamleader;
			Int64 now = Int64.Parse(Tools.toISODate(DateTime.Now.Day.ToString(), DateTime.Now.Month.ToString(), DateTime.Now.Year.ToString())), LetterDate;

			if(DDL_JNS_SANKSI.SelectedValue!="")
			{
				//PENGECEKAN KET SANKSI LAINNYA -- ARIEL
				if(DDL_JNS_SANKSI.SelectedValue=="S04")
				{
					if(TXT_KET_LAINNYA.Text=="")
					{
						GlobalTools.popMessage(this,"Keterangan Sanksi Lainnya belum diisi!");
						return;
					}

				}
				else
				{
					if(DDL_PROBLEM.SelectedValue=="")
					{
						GlobalTools.popMessage(this,"Permasalahan tidak boleh kosong!");
						return;
					}
				}
			}
			
			//--VALIDASI TANGGAL SURAT--//
			if(TXT_TGL_SURAT.Text=="" && DDL_BLN_SURAT.SelectedValue=="" && TXT_THN_SURAT.Text=="")
			{
				
			}
			else
			{
				try 
				{
					LetterDate = Int64.Parse(Tools.toISODate(TXT_TGL_SURAT.Text, DDL_BLN_SURAT.SelectedValue, TXT_THN_SURAT.Text));
				} 
				catch 
				{
					GlobalTools.popMessage(this, "Tanggal surat tidak valid!");
					return;
				}
				if (LetterDate > now)
				{
					GlobalTools.popMessage(this, "Tanggal surat tidak boleh lebih besar dari tanggal hari ini!");
					return;
				}
			}

			AuditTrailCheck("51");

			conn.QueryString = "select su_teamleader from scuser where userid='" + Session["UserID"] + "'";
			conn.ExecuteQuery();
			teamleader = conn.GetFieldValue("su_teamleader");
			try
			{
				conn.QueryString = "exec REKANAN_SANKSITEMP_UPDATE2  '" +
					LBL_REKANANREF.Text + "', '" +
					DDL_JNS_SANKSI.SelectedValue + "', '" +
					TXT_NO_SURAT.Text + "', " +
					tool.ConvertDate(TXT_TGL_SURAT.Text, DDL_BLN_SURAT.SelectedValue, TXT_THN_SURAT.Text) + ", '" +
					tool.ConvertNum(TXT_JANGKA_WKT_SANKSI.Text) + "', '" +
					DDL_JANGKA_WKT_SANKSI.SelectedValue + "', '" +
					DDL_PROBLEM.SelectedValue + "', '" +
					TXT_STATUS_SANKSI.Text + "', '" +
					teamleader + "', '" +
					SANKSI_EXT.Text + "', '" +						
					NO_SURAT_EXT.Text + "', " +
					tool.ConvertDate(TXT_DAY_EXT.Text, DDL_BLN_EXT.SelectedValue, TXT_YEAR_EXT.Text) + ", '" +
					DIKELUARKAN_EXT.Text + "', '" +
					tool.ConvertNum(JANGKA_WKT_EXT.Text) + "', '" +
					MASALAH_EXT.Text + "', '" +
					STATUS_EXT.Text + "', '" +						
					KET_EXT.Text + "', '" +
					Session["UserID"] + "', '" +
					DDL_JANGKA_WKT_SANKSI_EXT.SelectedValue + "', '" +
					TXT_KET_LAINNYA.Text + "'";

			}
			catch
			{
				GlobalTools.popMessage(this, "Connection Error!");
				Response.Redirect("../../Login.aspx?expire=1");
			}
			//}
			conn.ExecuteNonQuery();
			ClearData();
			ViewDataPending();

		}

		private void DGR_DAFTAR_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			switch (((LinkButton)e.CommandSource).CommandName)
			{
				case "lnk_edit":
					BTN_UPDATE.Visible = true;
					BTN_SAVE.Visible = false;
					LBL_REKANANREF.Text = e.Item.Cells[1].Text;
					ViewData();
					conn.QueryString = "select * from rekanan_sanksi_temp where SEQ=" + Convert.ToInt32(e.Item.Cells[0].Text) + "";
					conn.ExecuteQuery();                    

					try{
						DDL_JNS_SANKSI.SelectedValue = conn.GetFieldValue("rf_sanksi_type");
						LBL_JNS_SANKSI.Text = DDL_JNS_SANKSI.SelectedItem.Text;
					}
					catch{DDL_JNS_SANKSI.SelectedValue = "";}
					ViewProblem();

					conn.QueryString = "select * from rekanan_sanksi_temp where SEQ=" + Convert.ToInt32(e.Item.Cells[0].Text) + "";
					conn.ExecuteQuery();
					try{
						DDL_PROBLEM.SelectedValue = conn.GetFieldValue("rfproblem");
						LBL_PROBLEM.Text = DDL_PROBLEM.SelectedItem.Text;
					}
					catch{DDL_PROBLEM.SelectedValue = "";}

					TXT_NO_SURAT.Text = conn.GetFieldValue("letter#");
					LBL_NO_SURAT.Text = conn.GetFieldValue("letter#");

					TXT_TGL_SURAT.Text = tool.FormatDate_Day(conn.GetFieldValue("letter_date"));
					LBL_TGL_SURAT.Text = tool.FormatDate_Day(conn.GetFieldValue("letter_date"));

					try{
						DDL_BLN_SURAT.SelectedValue = tool.FormatDate_Month(conn.GetFieldValue("letter_date"));
						LBL_BLN_SURAT.Text = tool.FormatDate_Month(conn.GetFieldValue("letter_date"));
					}
					catch{DDL_BLN_SURAT.SelectedValue = "";}

					TXT_THN_SURAT.Text = tool.FormatDate_Year(conn.GetFieldValue("letter_date"));
					LBL_THN_SURAT.Text = tool.FormatDate_Year(conn.GetFieldValue("letter_date"));

					TXT_JANGKA_WKT_SANKSI.Text = conn.GetFieldValue("tenor");
					LBL_TXT_JANGKA_WKT_SANKSI.Text = conn.GetFieldValue("tenor");

					try{
						DDL_JANGKA_WKT_SANKSI.SelectedValue = conn.GetFieldValue("periode");
						LBL_DDL_JANGKA_WKT_SANKSI.Text = DDL_JANGKA_WKT_SANKSI.SelectedItem.Text;
					}
					catch{DDL_JANGKA_WKT_SANKSI.SelectedValue = "";}

					TXT_EXP_SANKSI.Text = tool.FormatDate(conn.GetFieldValue("letter_exp"));

					TXT_STATUS_SANKSI.Text = conn.GetFieldValue("rfstatus");
					LBL_STATUS_SANKSI.Text = conn.GetFieldValue("rfstatus");

					SANKSI_EXT.Text = conn.GetFieldValue("sanksi");
					LBL_SANKSI_EXT.Text = conn.GetFieldValue("sanksi");

					NO_SURAT_EXT.Text = conn.GetFieldValue("no_surat");
					LBL_NO_SURAT_EXT.Text = conn.GetFieldValue("no_surat");

					TXT_DAY_EXT.Text = tool.FormatDate_Day(conn.GetFieldValue("tgl_surat"));
					LBL_DAY_EXT.Text = tool.FormatDate_Day(conn.GetFieldValue("tgl_surat"));

					try{
						DDL_BLN_EXT.SelectedValue = tool.FormatDate_Month(conn.GetFieldValue("tgl_surat"));
						LBL_BLN_EXT.Text = tool.FormatDate_Month(conn.GetFieldValue("tgl_surat"));
					}
					catch{DDL_BLN_EXT.SelectedValue = "";}

					TXT_YEAR_EXT.Text = tool.FormatDate_Day(conn.GetFieldValue("tgl_surat"));
					LBL_YEAR_EXT.Text = tool.FormatDate_Day(conn.GetFieldValue("tgl_surat"));

					DIKELUARKAN_EXT.Text = conn.GetFieldValue("dikeluarkan");
					LBL_DIKELUARKAN_EXT.Text = conn.GetFieldValue("dikeluarkan");

					JANGKA_WKT_EXT.Text = conn.GetFieldValue("jangka_waktu");
					LBL_JANGKA_WKT_EXT.Text = conn.GetFieldValue("jangka_waktu");

					try{
						DDL_JANGKA_WKT_SANKSI_EXT.SelectedValue = conn.GetFieldValue("periode_ext");
						LBL_DDL_JANGKA_WKT_SANKSI_EXT.Text = DDL_JANGKA_WKT_SANKSI_EXT.SelectedItem.Text;
					}
					catch{DDL_JANGKA_WKT_SANKSI_EXT.SelectedValue = "";}	
				
					TGL_EXP_EXT.Text = tool.FormatDate(conn.GetFieldValue("batas_sanksi_ext"));
					
					MASALAH_EXT.Text = conn.GetFieldValue("permasalahan");
					LBL_MASALAH_EXT.Text = conn.GetFieldValue("permasalahan");
					STATUS_EXT.Text = conn.GetFieldValue("status_sanksi");
					LBL_STATUS_EXT.Text = conn.GetFieldValue("status_sanksi");
					KET_EXT.Text = conn.GetFieldValue("keterangan");
					LBL_KET_EXT.Text = conn.GetFieldValue("keterangan");
				break;
				case "lnk_delete":
					conn.QueryString = "delete rekanan_sanksi_temp where SEQ=" + Convert.ToInt32(e.Item.Cells[0].Text) + "";
					conn.ExecuteQuery();
					ViewDataPending();
					ClearData();
					ClearDataInfoRekanan();
					TR_INFO.Visible=false;
					TR_SANKSI.Visible=false;
					TR_SANKSI_EXT.Visible=false;
				break;
			}
		}

		private void ClearDataInfoRekanan()
		{
			TXT_REGNUM.Text="";
			TXT_JNS_REK.Text="";
			TXT_NAMA_REK.Text="";
			TXT_CP.Text="";
			TXT_ADDRESS1.Text="";
			TXT_ADDRESS2.Text="";
			TXT_CITY.Text="";
			TXT_NOTLP.Text="";
		}

		private void ClearData()
		{
			DDL_JNS_SANKSI.SelectedValue="";
			TXT_NO_SURAT.Text="";
			TXT_TGL_SURAT.Text="";
			DDL_BLN_SURAT.SelectedValue="";
			TXT_THN_SURAT.Text="";
			TXT_JANGKA_WKT_SANKSI.Text="";
			DDL_JANGKA_WKT_SANKSI.SelectedValue="";
			DDL_PROBLEM.Items.Clear();
			DDL_PROBLEM.Items.Add(new ListItem("--Pilih--",""));
			DDL_PROBLEM.SelectedValue="";
			TXT_STATUS_SANKSI.Text="";
			TXT_EXP_SANKSI.Text="";

			SANKSI_EXT.Text = "";
			NO_SURAT_EXT.Text = "";
			TXT_DAY_EXT.Text = "";
			DDL_BLN_EXT.SelectedValue = "";
			TXT_YEAR_EXT.Text = "";
			DIKELUARKAN_EXT.Text = "";
			JANGKA_WKT_EXT.Text = "";
			MASALAH_EXT.Text = "";
			STATUS_EXT.Text = "";
			KET_EXT.Text = "";
			DDL_JANGKA_WKT_SANKSI_EXT.SelectedValue = "";
			TGL_EXP_EXT.Text = "";

		}

		protected void BTN_CLEAR_Click(object sender, System.EventArgs e)
		{
			ClearData();
		}

		private void DDL_JANGKA_WKT_SANKSI_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			int jangka_waktu;
			Int64 now = Int64.Parse(Tools.toISODate(DateTime.Now.Day.ToString(), DateTime.Now.Month.ToString(), DateTime.Now.Year.ToString())), LetterDate;
			try
			{
				jangka_waktu = int.Parse(TXT_JANGKA_WKT_SANKSI.Text);
			}
			catch
			{
				GlobalTools.popMessage(this, "Jangka waktu sanksi tidak valid!");
				return;
			}

			try 
			{
				LetterDate = Int64.Parse(Tools.toISODate(TXT_TGL_SURAT.Text, DDL_BLN_SURAT.SelectedValue, TXT_THN_SURAT.Text));
			} 
			catch 
			{
				GlobalTools.popMessage(this, "Tanggal surat tidak valid!");
				return;
			}
			if (LetterDate > now)
			{
				GlobalTools.popMessage(this, "Tanggal surat tidak dapat lebih besar dari tanggal hari ini!");
				return;
			}

			if(DDL_JANGKA_WKT_SANKSI.SelectedValue=="D")
			{
				conn.QueryString = "select dateadd(day, " + jangka_waktu + " , " + tool.ConvertDate(TXT_TGL_SURAT.Text, DDL_BLN_SURAT.SelectedValue, TXT_THN_SURAT.Text) + ") as tanggal";
				conn.ExecuteQuery();

				TXT_EXP_SANKSI.Text = tool.FormatDate(conn.GetFieldValue("tanggal"), true);
			}
			else if(DDL_JANGKA_WKT_SANKSI.SelectedValue=="M")
			{
				conn.QueryString = "select dateadd(month, " + jangka_waktu + " , " + tool.ConvertDate(TXT_TGL_SURAT.Text, DDL_BLN_SURAT.SelectedValue, TXT_THN_SURAT.Text) + ") as tanggal";
				conn.ExecuteQuery();

				TXT_EXP_SANKSI.Text = tool.FormatDate(conn.GetFieldValue("tanggal"), true);

			}

		}

		private void ViewDataPending()
		{
			conn.QueryString = "select * from vw_rekanan_sanksi_TEMP left outer join rekanan on vw_rekanan_sanksi_temp.rekanan_ref=rekanan.rekanan_ref where userid='" + Session["UserID"] + "'";
			conn.ExecuteQuery();
			FillGridPending();
		}

		private void FillGridPending()
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
		}

		/*private void DatGrd_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			DatGrd.CurrentPageIndex = e.NewPageIndex;
			ViewDataPending();
		}*/
		

		private void DDL_JANGKA_WKT_SANKSI_EXT_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			int jangka_waktu;
			Int64 now = Int64.Parse(Tools.toISODate(DateTime.Now.Day.ToString(), DateTime.Now.Month.ToString(), DateTime.Now.Year.ToString())), LetterDate;
			try
			{
				jangka_waktu = int.Parse(JANGKA_WKT_EXT.Text);
			}
			catch
			{
				GlobalTools.popMessage(this, "Jangka waktu sanksi tidak valid!");
				return;
			}

			try 
			{
				LetterDate = Int64.Parse(Tools.toISODate(TXT_DAY_EXT.Text, DDL_BLN_EXT.SelectedValue, TXT_YEAR_EXT.Text));
			} 
			catch 
			{
				GlobalTools.popMessage(this, "Tanggal surat tidak valid!");
				return;
			}
			if (LetterDate > now)
			{
				GlobalTools.popMessage(this, "Tanggal surat tidak dapat lebih besar dari tanggal hari ini!");
				return;
			}

			if(DDL_JANGKA_WKT_SANKSI_EXT.SelectedValue=="D")
			{
				conn.QueryString = "select dateadd(day, " + jangka_waktu + " , " + tool.ConvertDate(TXT_DAY_EXT.Text, DDL_BLN_EXT.SelectedValue, TXT_YEAR_EXT.Text) + ") as tanggal";
				conn.ExecuteQuery();

				TGL_EXP_EXT.Text = tool.FormatDate(conn.GetFieldValue("tanggal"), true);
			}
			else if(DDL_JANGKA_WKT_SANKSI_EXT.SelectedValue=="M")
			{
				conn.QueryString = "select dateadd(month, " + jangka_waktu + " , " + tool.ConvertDate(TXT_DAY_EXT.Text, DDL_BLN_EXT.SelectedValue, TXT_YEAR_EXT.Text) + ") as tanggal";
				conn.ExecuteQuery();

				TGL_EXP_EXT.Text = tool.FormatDate(conn.GetFieldValue("tanggal"), true);

			}
		}

		protected void TXT_STATUS_SANKSI_TextChanged(object sender, System.EventArgs e)
		{
		
		}
	}
}
