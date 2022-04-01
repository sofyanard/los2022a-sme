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

namespace SME.CEA.DataEntry
{
	/// <summary>
	/// Summary description for StrukturOrganisasi.
	/// </summary>
	public partial class StrukturOrganisasi : System.Web.UI.Page
	{
		protected Connection conn;
		protected Tools tool = new Tools();
		protected string jenisrek="";
		protected string nama="";
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			conn = (Connection) Session["Connection"];

			if (!Logic.AllowAccess(Session["GroupID"].ToString(), Request.QueryString["mc"], conn))
				Response.Redirect("/../SME/Restricted.aspx");
			
			ViewMenu();
			//---untuk kebutuhan audittrail
			conn.QueryString = "select * from vw_rekanan where rekanan_ref='" + Request.QueryString["rekanan_ref"] + "'";
			conn.ExecuteQuery();
			jenisrek		=	conn.GetFieldValue("rfrekanantype");
			nama			=	conn.GetFieldValue("namerekanan");
			//---

			if(!IsPostBack)
			{
				DDL_CITY_CAB.Items.Add(new ListItem("--Pilih--", ""));
				DDL_KAB_CAB.Items.Add(new ListItem("--Pilih--",""));

				conn.QueryString = "select cityid, cityname from rfcity where active='1' order by cityname";
				conn.ExecuteQuery();
				for (int i = 0; i < conn.GetRowCount(); i++)
					DDL_CITY_CAB.Items.Add(new ListItem(conn.GetFieldValue(i,1),conn.GetFieldValue(i,0)));

				DDL_JNS_CAB.Items.Add(new ListItem("--Pilih--",""));

				conn.QueryString = "select id_jeniscabang, jeniscabang from rekanan_rfcabang where active='1'";
				conn.ExecuteQuery();
				for(int i = 0; i < conn.GetRowCount(); i++)
					DDL_JNS_CAB.Items.Add(new ListItem(conn.GetFieldValue(i,1), conn.GetFieldValue(i,0)));

				CekRekanan();

				ViewData();
				ViewCab();
				TXT_MODAL.Text = tool.MoneyFormat(TXT_MODAL.Text);

				BTN_UPDATE_CAB.Visible=false;
				BTN_INSERT_CAB.Visible=true;
			}
			CekView();
			
		}

		private void CekRekanan()
		{
			conn.QueryString = "select * from rekanan where rekanan_ref='" + Request.QueryString["rekanan_ref"] + "'";
			conn.ExecuteQuery();

			if(conn.GetFieldValue("RFREKANANTYPE")=="04" || conn.GetFieldValue("RFREKANANTYPE")=="05")
				TR_MODAL.Visible=true;
			else
				TR_MODAL.Visible=false;
		}

		private void AuditTrailCheck(string kodeJenisData)
		{
			string userName		= Session["FullName"].ToString();
			string status		= "update";
			string rekanan_ref	= Request.QueryString["rekanan_ref"];
			string regnum		= Request.QueryString["regnum"];			

			switch(kodeJenisData)
			{
				case "21"://DATA ORGANISASI
						cekDO(kodeJenisData, rekanan_ref, regnum, userName, status);
					break;
				case "22": //DATA CABANG
						cekCabang(kodeJenisData, rekanan_ref, regnum, userName, status);
					break;
				case "23"://TENAGA AHLI
						cekTA(kodeJenisData, rekanan_ref, regnum, userName, status);
					break;
			}
		}

		private void cekDO(string kodeJenisData, string rekref, string regnum, string user, string stat)
		{
			
			string temp			=   "";
			string sqlpar		=	rekref + "', '" +
				regnum + "', '" +
				kodeJenisData + "', '" +
				jenisrek + "', '" +
				nama + "', '" +
				user + "', '" +
				stat +  "' ";
			//cek field yang berubah dan masukan ke audittrail jika ada perubahan
			if(LBL_STATUS_KANTOR.Text!=TXT_STATUS_KANTOR.Text)
			{
				temp="Status Kantor: ";
				try
				{
					conn.QueryString = "EXEC REKANAN_AUDITTRAIL_INSERT '"+
						sqlpar + ", '" +
						temp + LBL_STATUS_KANTOR.Text + "', '" +
						temp + TXT_STATUS_KANTOR.Text + "'"; 
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

			if(LBL_JML_CAB.Text!=TXT_JML_CAB.Text)
			{
				temp="Jumlah Cabang: ";
				try
				{
					conn.QueryString = "EXEC REKANAN_AUDITTRAIL_INSERT '"+
						sqlpar + ", '" +
						temp + LBL_JML_CAB.Text + "', '" +
						temp + TXT_JML_CAB.Text + "'"; 
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

			if(LBL_PEG_TETAP.Text!=TXT_PEG_TETAP.Text)
			{
				temp="Total Pegawai Tetap: ";
				try
				{
					conn.QueryString = "EXEC REKANAN_AUDITTRAIL_INSERT '"+
						sqlpar + ", '" +
						temp + LBL_PEG_TETAP.Text + "', '" +
						temp + TXT_PEG_TETAP.Text + "'"; 
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

			if(LBL_PEG_TDK_TETAP.Text!=TXT_PEG_TDK_TETAP.Text)
			{
				temp="Total Pegawai Tidak Tetap: ";
				try
				{
					conn.QueryString = "EXEC REKANAN_AUDITTRAIL_INSERT '"+
						sqlpar + ", '" +
						temp + LBL_PEG_TDK_TETAP.Text + "', '" +
						temp + TXT_PEG_TDK_TETAP.Text + "'"; 
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

			if(LBL_JML_AGEN.Text!=TXT_JML_AGEN.Text)
			{
				temp="Jumlah Agen: ";
				try
				{
					conn.QueryString = "EXEC REKANAN_AUDITTRAIL_INSERT '"+
						sqlpar + ", '" +
						temp + LBL_JML_AGEN.Text + "', '" +
						temp + TXT_JML_AGEN.Text + "'"; 
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

			if(LBL_MODAL.Text!=TXT_MODAL.Text)
			{
				temp="Jumlah Modal: ";
				try
				{
					conn.QueryString = "EXEC REKANAN_AUDITTRAIL_INSERT '"+
						sqlpar + ", '" +
						temp + LBL_MODAL.Text + "', '" +
						temp + TXT_MODAL.Text + "'"; 
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

		
		private void cekCabang(string kodeJenisData, string rekref, string regnum, string user, string stat)
		{
			
				string temp			=   "";
				string sqlpar		=	rekref + "', '" +
					regnum + "', '" +
					kodeJenisData + "', '" +
					jenisrek + "', '" +
					nama + "', '" +
					user + "', '" +
					stat +  "' ";
				//cek field yang berubah dan masukan ke audittrail jika ada perubahan
			if(LBL_JNS_CAB.Text!=DDL_JNS_CAB.SelectedItem.Text)
			{
				temp="Jenis Cabang: ";
				try
				{
					conn.QueryString = "EXEC REKANAN_AUDITTRAIL_INSERT '"+
						sqlpar + ", '" +
						temp + LBL_JNS_CAB.Text + "', '" +
						temp + DDL_JNS_CAB.SelectedItem.Text + "'"; 
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

			if(LBL_NAMA_CAB.Text!=TXT_NAMA_CAB.Text)
			{
				temp="Nama Cabang/Perwakilan: ";
				try
				{
					conn.QueryString = "EXEC REKANAN_AUDITTRAIL_INSERT '"+
						sqlpar + ", '" +
						temp + LBL_NAMA_CAB.Text + "', '" +
						temp + TXT_NAMA_CAB.Text + "'"; 
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

			if(LBL_ADD_CAB.Text!=TXT_ADD_CAB.Text)
			{
				temp="Alamat Cabang/Perwakilan: ";
				try
				{
					conn.QueryString = "EXEC REKANAN_AUDITTRAIL_INSERT '"+
						sqlpar + ", '" +
						temp + LBL_ADD_CAB.Text + "', '" +
						temp + TXT_ADD_CAB.Text + "'"; 
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


			string no1=LBL_NO_AREA + " " + LBL_NO_KNTR;
			string no2=TXT_NO_AREA + " " + TXT_NO_KNTR;
			if(no1!=no2)
			{
				temp="No Telp: ";
				try
				{
					conn.QueryString = "EXEC REKANAN_AUDITTRAIL_INSERT '"+
						sqlpar + ", '" +
						temp + no1 + "', '" +
						temp + no2 + "'"; 
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

			if(LBL_CITY_CAB.Text!=DDL_CITY_CAB.SelectedItem.Text)
			{
				temp="Wilayah: ";
				try
				{
					conn.QueryString = "EXEC REKANAN_AUDITTRAIL_INSERT '"+
						sqlpar + ", '" +
						temp + LBL_CITY_CAB.Text + "', '" +
						temp + DDL_CITY_CAB.SelectedItem.Text + "'"; 
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
	
			if(LBL_KAB_CAB.Text!=DDL_KAB_CAB.SelectedItem.Text)
			{
				temp="Kecamatan: ";
				try
				{
					conn.QueryString = "EXEC REKANAN_AUDITTRAIL_INSERT '"+
						sqlpar + ", '" +
						temp + LBL_KAB_CAB.Text + "', '" +
						temp + DDL_KAB_CAB.SelectedItem.Text + "'"; 
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
		
			if(LBL_ZIPCD_CAB.Text!=TXT_ZIPCD_CAB.Text)
			{
				temp="Zipcode: ";
				try
				{
					conn.QueryString = "EXEC REKANAN_AUDITTRAIL_INSERT '"+
						sqlpar + ", '" +
						temp + LBL_ZIPCD_CAB.Text + "', '" +
						temp + TXT_ZIPCD_CAB.Text + "'"; 
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
		
		
		private void cekTA(string kodeJenisData, string rekref, string regnum, string user, string stat)
		{
				
				string temp			=   "";
				string sqlpar		=	rekref + "', '" +
					regnum + "', '" +
					kodeJenisData + "', '" +
					jenisrek + "', '" +
					nama + "', '" +
					user + "', '" +
					stat +  "' ";
				//cek field yang berubah dan masukan ke audittrail jika ada perubahan
				if(LBL_NAMA_TA.Text!=TXT_NAMA_TA.Text)
				{
					temp="Nama: ";
					try
					{
						conn.QueryString = "EXEC REKANAN_AUDITTRAIL_INSERT '"+
							sqlpar + ", '" +
							temp + LBL_NAMA_TA.Text + "', '" +
							temp + TXT_NAMA_TA.Text + "'"; 
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
		
				if(LBL_JABATAN_TA.Text!=TXT_JABATAN_TA.Text)
				{
					temp="Jabatan: ";
					try
					{
						conn.QueryString = "EXEC REKANAN_AUDITTRAIL_INSERT '"+
							sqlpar + ", '" +
							temp + LBL_JABATAN_TA.Text + "', '" +
							temp + TXT_JABATAN_TA.Text + "'"; 
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

				if(LBL_SERTIFIKASI.Text!=TXT_SERTIFIKASI.Text)
				{
					temp="Sertifikasi: ";
					try
					{
						conn.QueryString = "EXEC REKANAN_AUDITTRAIL_INSERT '"+
							sqlpar + ", '" +
							temp + LBL_SERTIFIKASI.Text + "', '" +
							temp + TXT_SERTIFIKASI.Text + "'"; 
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

			if(LBL_GELAR_TA.Text!=TXT_GELAR_TA.Text)
			{
				temp="Gelar: ";
				try
				{
					conn.QueryString = "EXEC REKANAN_AUDITTRAIL_INSERT '"+
						sqlpar + ", '" +
						temp + LBL_GELAR_TA.Text + "', '" +
						temp + TXT_GELAR_TA.Text + "'"; 
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

			if(LBL_ASOSIASI_PROFESI.Text!=TXT_ASOSIASI_PROFESI.Text)
			{
				temp="Asosiasi Profesi: ";
				try
				{
					conn.QueryString = "EXEC REKANAN_AUDITTRAIL_INSERT '"+
						sqlpar + ", '" +
						temp + LBL_ASOSIASI_PROFESI.Text + "', '" +
						temp + TXT_ASOSIASI_PROFESI.Text + "'"; 
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

			if(LBL_PENGALAMAN_TA.Text!=TXT_PENGALAMAN_TA.Text)
			{
				temp="Pengalaman: ";
				try
				{
					conn.QueryString = "EXEC REKANAN_AUDITTRAIL_INSERT '"+
						sqlpar + ", '" +
						temp + LBL_PENGALAMAN_TA.Text + "', '" +
						temp + TXT_PENGALAMAN_TA.Text + "'"; 
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

		
		protected void BTN_SAVE_SO_Click(object sender, System.EventArgs e)
		{
			int temp;
			//---VALIDASI JUMLAH CABANG---//
			if(TXT_JML_CAB.Text=="")
				TXT_JML_CAB.Text="0";
			try
			{
				temp = Convert.ToInt32(TXT_JML_CAB.Text);
			}
			catch
			{
				GlobalTools.popMessage(this, "Jumlah Cabang Tidak Valid!");
				return;
			}

			//---VALIDASI TOTAL PEGAWAI TETAP--//
			if(TXT_PEG_TETAP.Text=="")
				TXT_PEG_TETAP.Text="0";
			try
			{
				temp = Convert.ToInt32(TXT_PEG_TETAP.Text);
			}
			catch
			{
				GlobalTools.popMessage(this, "Jumlah Pegawai Tetap Tidak Valid!");
				return;
			}

			//---VALIDASI TOTAL PEGAWAI TIDAK TETAP---//
			if(TXT_PEG_TDK_TETAP.Text=="")
				TXT_PEG_TDK_TETAP.Text="0";
			try
			{
				temp = Convert.ToInt32(TXT_PEG_TDK_TETAP.Text);
			}
			catch
			{
				GlobalTools.popMessage(this, "Jumlah Pegawai Tidak Tetap Tidak Valid!");
				return;
			}

			//---VALIDASI JUMLAH AGEN---//
			if(TXT_JML_AGEN.Text=="")
				TXT_JML_AGEN.Text="0";
			try
			{
				temp = Convert.ToInt32(TXT_JML_AGEN.Text);
			}
			catch
			{
				GlobalTools.popMessage(this, "Jumlah Agen Tidak Valid!");
				return;
			}

			conn.QueryString = "select * from rekanan_so where rekanan_ref='" + Request.QueryString["rekanan_ref"] + "'";
			conn.ExecuteQuery();
			if (conn.GetRowCount() > 0)
			{
				//penambahan auditrail oleh ariel
				AuditTrailCheck("21");
				//---

				try
				{
					conn.QueryString = "exec REKANAN_SO_UPDATE '" +
						Request.QueryString["rekanan_ref"] + "', '" +
						TXT_STATUS_KANTOR.Text + "', " +
						Convert.ToInt32(TXT_JML_CAB.Text) + ", " +
						Convert.ToInt32(TXT_PEG_TETAP.Text) + ", " +
						Convert.ToInt32(TXT_PEG_TDK_TETAP.Text) + ", " +
						Convert.ToInt32(TXT_JML_AGEN.Text) + ", " +
						tool.ConvertFloat(TXT_MODAL.Text);
				}
				catch
				{
					GlobalTools.popMessage(this, "Connection Error!");
					Response.Redirect("../../Login.aspx?expire=1");
				}
			}
			else
			{
				try
				{
					conn.QueryString = "exec REKANAN_SO_INSERT '" +
						Request.QueryString["rekanan_ref"] + "', '" +
						TXT_STATUS_KANTOR.Text + "', " +
						Convert.ToInt32(TXT_JML_CAB.Text) + ", " +
						Convert.ToInt32(TXT_PEG_TETAP.Text) + ", " +
						Convert.ToInt32(TXT_PEG_TDK_TETAP.Text) + ", " +
						Convert.ToInt32(TXT_JML_AGEN.Text) + ", " +
						tool.ConvertFloat(TXT_MODAL.Text);
				}
				catch
				{
					GlobalTools.popMessage(this, "Connection Error!");
					Response.Redirect("../../Login.aspx?expire=1");
				}
			}
			
			conn.ExecuteNonQuery();
			ViewData();
		}

		
		protected void BTN_CLEAR_SO_Click(object sender, System.EventArgs e)
		{
			TXT_STATUS_KANTOR.Text = "";
			TXT_JML_CAB.Text = "";
			TXT_PEG_TETAP.Text = "";
			TXT_PEG_TDK_TETAP.Text="";
			TXT_JML_AGEN.Text="";
			TXT_MODAL.Text="";
		}

		protected void BTN_INSERT_TA_Click(object sender, System.EventArgs e)
		{
			if(TXT_NAMA_TA.Text== "" && TXT_JABATAN_TA.Text== "" && TXT_GELAR_TA.Text=="" && TXT_PENGALAMAN_TA.Text=="" && TXT_SERTIFIKASI.Text=="" && TXT_ASOSIASI_PROFESI.Text=="")
			{
				GlobalTools.popMessage(this, "Dilarang memasukkan data kosong!");
				return;
			}

			if(TXT_SEQ.Text=="")
			{
				conn.QueryString = "exec REKANAN_TENAGA_AHLI_INSERT '" +
					Request.QueryString["rekanan_ref"] + "', '" +
					TXT_NAMA_TA.Text + "', '" +
					TXT_JABATAN_TA.Text + "', '" +
					TXT_GELAR_TA.Text + "', '" +
					TXT_PENGALAMAN_TA.Text + "', '" +
					TXT_SERTIFIKASI.Text + "', '" +
					TXT_ASOSIASI_PROFESI.Text +  "'";
			}
			else
			{
				
				//Penambahan audittrail oleh Ariel
				AuditTrailCheck("23");

				conn.QueryString = "exec REKANAN_TENAGA_AHLI_UPDATE " +
					Convert.ToInt32(TXT_SEQ.Text) + ", '" +
					Request.QueryString["rekanan_ref"] + "', '" +
					TXT_NAMA_TA.Text + "', '" +
					TXT_JABATAN_TA.Text + "', '" +
					TXT_GELAR_TA.Text + "', '" +
					TXT_PENGALAMAN_TA.Text + "', '" +
					TXT_SERTIFIKASI.Text + "', '" +
					TXT_ASOSIASI_PROFESI.Text +  "'";
			}
			conn.ExecuteNonQuery();
			ViewData();
			ClearData();
			

		}

		private void ClearData()
		{
			TXT_NAMA_TA.Text="";
			TXT_JABATAN_TA.Text="";
			TXT_GELAR_TA.Text="";
			TXT_PENGALAMAN_TA.Text="";
			TXT_SEQ.Text="";
			TXT_SERTIFIKASI.Text="";
			TXT_ASOSIASI_PROFESI.Text="";
		}

		protected void BTN_CLEAR_TA_Click(object sender, System.EventArgs e)
		{
			ClearData();
		}

		private void DatGridTenagaAhli_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			switch (((LinkButton)e.CommandSource).CommandName)
			{
				case "delete_tenaga_ahli":
					conn.QueryString = "delete from rekanan_tenaga_ahli where seq=" + Convert.ToInt32(e.Item.Cells[0].Text);
					conn.ExecuteQuery();
					ViewData();
					break;

				case "edit_tenaga_ahli":
					conn.QueryString = "select * from rekanan_tenaga_ahli where seq=" + Convert.ToInt32(e.Item.Cells[0].Text);
					conn.ExecuteQuery();
					TXT_SEQ.Text = conn.GetFieldValue("SEQ");

					TXT_NAMA_TA.Text = conn.GetFieldValue("NAMA");
					LBL_NAMA_TA.Text = conn.GetFieldValue("NAMA");

					TXT_JABATAN_TA.Text = conn.GetFieldValue("POSITION_TA");
					LBL_JABATAN_TA.Text = conn.GetFieldValue("POSITION_TA");

					TXT_GELAR_TA.Text = conn.GetFieldValue("TITLE");
					LBL_GELAR_TA.Text = conn.GetFieldValue("TITLE");

					TXT_PENGALAMAN_TA.Text = conn.GetFieldValue("EXPERIENCE");
					LBL_PENGALAMAN_TA.Text = conn.GetFieldValue("EXPERIENCE");

					TXT_SERTIFIKASI.Text = conn.GetFieldValue("SERTIFIKASI");
					LBL_SERTIFIKASI.Text = conn.GetFieldValue("SERTIFIKASI");

					TXT_ASOSIASI_PROFESI.Text = conn.GetFieldValue("ASOSIASI_PROFESI");
					LBL_ASOSIASI_PROFESI.Text = conn.GetFieldValue("ASOSIASI_PROFESI");
					ViewData();
					break;
			}
		}
		private void ViewData()
		{
			conn.QueryString = "select * from rekanan_tenaga_ahli where rekanan_ref='" + Request.QueryString["rekanan_ref"] + "'";
			conn.ExecuteQuery();
			FillGrid();

			
			conn.QueryString = "select * from rekanan_so where rekanan_ref='" + Request.QueryString["rekanan_ref"] + "'";
			conn.ExecuteQuery();
			if (conn.GetRowCount() > 0)
			{
				TXT_STATUS_KANTOR.Text = conn.GetFieldValue("OFFICE_STATUS");
				LBL_STATUS_KANTOR.Text = conn.GetFieldValue("OFFICE_STATUS");

				TXT_JML_CAB.Text = conn.GetFieldValue("TOT_BRANCH");
				LBL_JML_CAB.Text = conn.GetFieldValue("TOT_BRANCH");

				TXT_PEG_TETAP.Text = conn.GetFieldValue("TOT_EMPLOYEE");
				LBL_PEG_TETAP.Text = conn.GetFieldValue("TOT_EMPLOYEE");

				TXT_PEG_TDK_TETAP.Text = conn.GetFieldValue("TOT_OUTSOURCE");
				LBL_PEG_TDK_TETAP.Text = conn.GetFieldValue("TOT_OUTSOURCE");

				TXT_JML_AGEN.Text = conn.GetFieldValue("TOT_AGEN");
				LBL_JML_AGEN.Text = conn.GetFieldValue("TOT_AGEN");

				TXT_MODAL.Text = conn.GetFieldValue("MODAL");
				TXT_MODAL.Text = tool.MoneyFormat(TXT_MODAL.Text);
				LBL_MODAL.Text = conn.GetFieldValue("MODAL");
				LBL_MODAL.Text = tool.MoneyFormat(TXT_MODAL.Text);
			}
		}

		private void FillGrid()
		{
			DataTable dt = new DataTable();
			dt = conn.GetDataTable().Copy();
			DatGridTenagaAhli.DataSource = dt;
			try 
			{
				DatGridTenagaAhli.DataBind();
			} 
			catch 
			{
				DatGridTenagaAhli.CurrentPageIndex = 0;
				DatGridTenagaAhli.DataBind();
			}
		}

		private void ViewMenu()
		{
			try 
			{
				conn.QueryString = "select * from SCREENMENU where menucode = '" + Request.QueryString["mc"] + "'";
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
							strtemp = "regnum=" + Request.QueryString["regnum"] + "&rekanan_ref="+Request.QueryString["rekanan_ref"]  + "&tc=" + Request.QueryString["tc"]+ "&exist=" + Request.QueryString["exist"]+ "&view=" + Request.QueryString["view"];
						else	
							strtemp = "regnum=" + Request.QueryString["regnum"] + "&rekanan_ref="+Request.QueryString["rekanan_ref"]  + "&mc=" + Request.QueryString["mc"]+"&tc="+Request.QueryString["tc"]+ "&exist=" + Request.QueryString["exist"]+ "&view=" + Request.QueryString["view"];
						//t.ForeColor = Color.MidnightBlue; 
						if (conn.GetFieldValue(i,3).IndexOf("?par=") < 0 && conn.GetFieldValue(i,3).IndexOf("&par=") < 0)  
							strtemp = strtemp + "&par=" + Request.QueryString["par"] + "&mc2=" + Request.QueryString["mc2"];
					}
					else 
					{
						strtemp = "";
						t.ForeColor = Color.Red; 
					}
					t.NavigateUrl = conn.GetFieldValue(i, 3)+strtemp;
					MenuStrukturOrganisasi.Controls.Add(t);
					MenuStrukturOrganisasi.Controls.Add(new LiteralControl("&nbsp;&nbsp;&nbsp;"));
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
			this.DatGrdCab.ItemCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.DatGrdCab_ItemCommand);
			this.DatGrdCab.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.DatGrdCab_PageIndexChanged);
			this.DatGridTenagaAhli.ItemCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.DatGridTenagaAhli_ItemCommand);
			this.DatGridTenagaAhli.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.DatGridTenagaAhli_PageIndexChanged);

		}
		#endregion

		private void TXT_MODAL_TextChanged(object sender, System.EventArgs e)
		{
			TXT_MODAL.Text = tool.MoneyFormat(TXT_MODAL.Text);
		}

		protected void BTN_INSERT_CAB_Click(object sender, System.EventArgs e)
		{
			if(TXT_NAMA_CAB.Text=="" && TXT_ADD_CAB.Text=="" && DDL_CITY_CAB.SelectedValue=="" && DDL_KAB_CAB.SelectedValue=="" && TXT_ZIPCD_CAB.Text=="" && DDL_JNS_CAB.SelectedValue=="")
				return;

			try
			{
				conn.QueryString = "exec REKANAN_CAB_INSERT '" +
					Request.QueryString["rekanan_ref"] + "', '" +
					TXT_NAMA_CAB.Text + "', '" +
					TXT_ADD_CAB.Text + "', '" +
					DDL_CITY_CAB.SelectedValue + "', '" +
					DDL_KAB_CAB.SelectedValue + "', '" +
					TXT_ZIPCD_CAB.Text + "', '" +
					DDL_JNS_CAB.SelectedValue + "', '" +
					TXT_NO_AREA.Text + "', '" +
					TXT_NO_KNTR.Text + "'";
				conn.ExecuteNonQuery();
			}
			catch
			{
				GlobalTools.popMessage(this, "Connection Error!");
				Response.Redirect("../../Login.aspx?expire=1");
			}
			
			ViewCab();
			ClearDataCab();
		}

		protected void BTN_UPDATE_CAB_Click(object sender, System.EventArgs e)
		{
			if(TXT_NAMA_CAB.Text=="" && TXT_ADD_CAB.Text=="" && DDL_CITY_CAB.SelectedValue=="" && DDL_KAB_CAB.SelectedValue=="" && TXT_ZIPCD_CAB.Text=="" && DDL_JNS_CAB.SelectedValue=="")
				return;

			//Penambahan audittrail oleh Ariel
			AuditTrailCheck("22");

			try
			{
				conn.QueryString = "exec REKANAN_CAB_UPDATE " +
					Convert.ToUInt32(TXT_SEQ_CAB.Text) + ", '" +
					Request.QueryString["rekanan_ref"] + "', '" +
					TXT_NAMA_CAB.Text + "', '" +
					TXT_ADD_CAB.Text + "', '" +
					DDL_CITY_CAB.SelectedValue + "', '" +
					DDL_KAB_CAB.SelectedValue + "', '" +
					TXT_ZIPCD_CAB.Text + "', '" +
					DDL_JNS_CAB.SelectedValue + "', '" +
					TXT_NO_AREA.Text + "', '" +
					TXT_NO_KNTR.Text + "'";
				conn.ExecuteNonQuery();
			}
			catch
			{
				GlobalTools.popMessage(this, "Connection Error!");
				Response.Redirect("../../Login.aspx?expire=1");
			}
			ViewCab();
			BTN_UPDATE_CAB.Visible = false;
			BTN_INSERT_CAB.Visible = true;
			ClearDataCab();
		}

		protected void BTN_CLEAR_CAB_Click(object sender, System.EventArgs e)
		{
			ClearDataCab();
		}

		private void ClearDataCab()
		{
			TXT_NAMA_CAB.Text = "";
			TXT_ADD_CAB.Text = "";
			DDL_CITY_CAB.SelectedValue = "";
			DDL_KAB_CAB.Items.Clear();
			DDL_KAB_CAB.Items.Add(new ListItem("--Pilih--", ""));
			DDL_KAB_CAB.SelectedValue = "";
			TXT_ZIPCD_CAB.Text = "";
			DDL_JNS_CAB.SelectedValue = "";
			TXT_NO_AREA.Text = "";
			TXT_NO_KNTR.Text = "";
		}

		private void ViewCab()
		{
			conn.QueryString = "select * FROM VW_REKANAN_CABANG where rekanan_ref='" + Request.QueryString["rekanan_ref"] + "'";
			conn.ExecuteQuery();
			FillGridCab();
		}

		private void FillGridCab()
		{
			DataTable dt = new DataTable();
			dt = conn.GetDataTable().Copy();
			DatGrdCab.DataSource = dt;
			try 
			{
				DatGrdCab.DataBind();
			} 
			catch 
			{
				DatGrdCab.CurrentPageIndex = 0;
				DatGrdCab.DataBind();
			}
		}

		private void ViewKab()
		{
			DDL_KAB_CAB.Items.Clear();
			DDL_KAB_CAB.Items.Add(new ListItem("- PILIH -", ""));
			
			conn.QueryString = "select zipcode, description from rfzipcodecity " + 
				"where cityid='" + DDL_CITY_CAB.SelectedValue + 
				"' and active='1' order by rtrim(ltrim(zipcode))";
			conn.ExecuteQuery();
			for (int i = 0; i < conn.GetRowCount(); i++)
				DDL_KAB_CAB.Items.Add(new ListItem(conn.GetFieldValue(i,1), conn.GetFieldValue(i,0)));
		}

		private void DDL_CITY_CAB_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			ViewKab();
		}

		private void DDL_KAB_CAB_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			TXT_ZIPCD_CAB.Text = DDL_KAB_CAB.SelectedValue;	
		}

		private void TXT_ZIPCD_CAB_TextChanged(object sender, System.EventArgs e)
		{
			DDL_KAB_CAB.SelectedValue = TXT_ZIPCD_CAB.Text;
		}

		private void DatGrdCab_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			string kabupaten="";
			switch (((LinkButton)e.CommandSource).CommandName)
			{
				case "delete_cab":
					conn.QueryString = "delete from rekanan_cabang where rekanan_ref='" + Request.QueryString["rekanan_ref"] + "' and SEQ=" + Convert.ToInt32(e.Item.Cells[0].Text) + "";
					conn.ExecuteQuery();
					
					ClearDataCab();
					FillGridCab();
					ViewCab();
					break;
				case "edit_cab":
					BTN_UPDATE_CAB.Visible=true;
					BTN_INSERT_CAB.Visible=false;
					conn.QueryString = "select * from rekanan_cabang where rekanan_ref='" + Request.QueryString["rekanan_ref"] + "' and SEQ=" + Convert.ToInt32(e.Item.Cells[0].Text) + "";
					conn.ExecuteQuery();

					//seq = Convert.ToInt32(conn.GetFieldValue("SEQ"));
					TXT_NAMA_CAB.Text = conn.GetFieldValue("NAMA_CABANG");
					LBL_NAMA_CAB.Text = conn.GetFieldValue("NAMA_CABANG");

					TXT_ADD_CAB.Text = conn.GetFieldValue("ALAMAT");
					LBL_ADD_CAB.Text = conn.GetFieldValue("ALAMAT");

					TXT_NO_AREA.Text = conn.GetFieldValue("telp_area");
					LBL_NO_AREA.Text = conn.GetFieldValue("telp_area");

					TXT_NO_KNTR.Text = conn.GetFieldValue("no_telp");
					LBL_NO_KNTR.Text = conn.GetFieldValue("no_telp");

					try{
						DDL_CITY_CAB.SelectedValue = conn.GetFieldValue("KOTA");
						LBL_CITY_CAB.Text = DDL_CITY_CAB.SelectedItem.Text;
					}
					catch{DDL_CITY_CAB.SelectedValue = "";}

					TXT_ZIPCD_CAB.Text = conn.GetFieldValue("ZIPCODE");
					LBL_ZIPCD_CAB.Text = conn.GetFieldValue("ZIPCODE");

					TXT_SEQ_CAB.Text = conn.GetFieldValue("SEQ");

					try{
						DDL_JNS_CAB.SelectedValue = conn.GetFieldValue("JENIS");
						LBL_JNS_CAB.Text = DDL_JNS_CAB.SelectedItem.Text;
					}
					catch{
						DDL_JNS_CAB.SelectedValue = conn.GetFieldValue("JENIS");
					}

					kabupaten = conn.GetFieldValue("KABUPATEN");
					ViewKab();
					try{
						DDL_KAB_CAB.SelectedValue = kabupaten;
						LBL_KAB_CAB.Text = DDL_KAB_CAB.SelectedItem.Text;
					}
					catch{DDL_KAB_CAB.SelectedValue = "";}
					
					ViewCab();
					break;
			}
		}

		private void DatGrdCab_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			DatGrdCab.CurrentPageIndex = e.NewPageIndex;
			ViewCab();
		}

		
		protected void BTN_BACK_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			if (Request.QueryString["par"] != null && Request.QueryString["par"] != "") 
			{
				Response.Redirect(Request.QueryString["par"] + "&mc=" + Request.QueryString["mc2"] + "&regnum=" + Request.QueryString["regnum"] + "&rekanan_ref=" + Request.QueryString["rekanan_ref"] + "&tc=" + Request.QueryString["tc"]+ "&view=" + Request.QueryString["view"]);
			}
			else
				Response.Redirect("/SME/" + DMS.CuBESCore.Logic.backLink(Request.QueryString["tc"].ToString(), conn));
		}

		private void CekView()
		{
			if(Request.QueryString["view"]=="1")
			{
				DatGridTenagaAhli.Columns[7].Visible = false;
				BTN_Clear_TA.Enabled = false;
				BTN_SAVE_SO.Enabled = false;
				BTN_CLEAR_SO.Enabled = false;
				BTN_INSERT_TA.Enabled = false;
				TXT_NAMA_TA.ReadOnly = true;
				TXT_JABATAN_TA.ReadOnly = true;
				TXT_GELAR_TA.ReadOnly = true;
				TXT_PENGALAMAN_TA.ReadOnly = true;
				TXT_STATUS_KANTOR.ReadOnly = true;
				TXT_JML_CAB.ReadOnly = true;
				TXT_PEG_TETAP.ReadOnly = true;
				TXT_PEG_TDK_TETAP.ReadOnly = true;
				TXT_JML_AGEN.ReadOnly = true;
				TXT_SERTIFIKASI.ReadOnly = true;
				TXT_ASOSIASI_PROFESI.ReadOnly = true;
				TXT_MODAL.ReadOnly = true;
				DatGrdCab.Columns[5].Visible = false;
				DDL_JNS_CAB.Enabled = false;
				TXT_NAMA_CAB.ReadOnly = true;
				TXT_ADD_CAB.ReadOnly = true;
				DDL_CITY_CAB.Enabled = false;
				DDL_KAB_CAB.Enabled = false;
				TXT_ZIPCD_CAB.ReadOnly = true;
				BTN_INSERT_CAB.Enabled = false;
				BTN_UPDATE_CAB.Enabled = false;
				BTN_CLEAR_CAB.Enabled = false;
				TXT_NO_AREA.ReadOnly = true;
				TXT_NO_KNTR.ReadOnly = true;
				
			}
		}

		private void DatGridTenagaAhli_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			DatGridTenagaAhli.CurrentPageIndex = e.NewPageIndex;
			ViewData();
		}

		
	}
}
