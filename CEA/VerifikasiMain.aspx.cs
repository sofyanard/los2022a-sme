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
using DMS.DBConnection;
using DMS.CuBESCore;


namespace SME.CEA
{
	/// <summary>
	/// Summary description for VerifikasiMain.
	/// </summary>
	public partial class VerifikasiMain : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.HyperLink HL_ACCOUNT;
		protected Connection conn;
		protected Tools tool = new Tools();
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			conn = (Connection) Session["Connection"];

			conn.QueryString="delete from rekanan_scoring_site_visit";
			conn.ExecuteQuery();
			
			/*if (!Logic.AllowAccess(Session["GroupID"].ToString(), Request.QueryString["mc"], conn))
				Response.Redirect("/SME/Restricted.aspx"); */

			if (!IsPostBack)
			{
				ViewDataApplication();
			}

			
			ViewMenu();

			conn.QueryString = "select ap_currtrack from rekanan_apptrack where regnum='" + lbl_regnum.Text + "'";
			conn.ExecuteQuery();

			//string tes = conn.GetFieldValue("ap_currtrack");

			if (conn.GetFieldValue("ap_currtrack") != "A1.2")
				BTN_UPDATE.Enabled = false;
			else
				BTN_UPDATE.Enabled = true;

			BTN_BACK.Click += new ImageClickEventHandler(BTN_BACK_Click);
			BTN_UPDATE.Attributes.Add("onclick","if(!update()){return false;};");

			
		}

		private void ViewDataApplication()
		{	
			lbl_regnum.Text			= Request.QueryString["regnum"];
			lbl_rekananref.Text		= Request.QueryString["rekanan_ref"];
									
			conn.QueryString = "select REKANANTYPEID from REKANAN, APPLICATION_REKANAN where REKANAN.REKANAN_REF=APPLICATION_REKANAN.REKANAN_REF AND APPLICATION_REKANAN.REGNUM='" +Request.QueryString["regnum"]+ "'";
			conn.ExecuteQuery();
			
			LBL_REKANANTYPEID.Text	= conn.GetFieldValue("REKANANTYPEID");
						
			ViewDataRekanan();
		}

		
		private void ViewDataRekanan()
		{
			
			if (LBL_REKANANTYPEID.Text == "02") //if personal
			{
				conn.QueryString = "select * from VW_REKANAN_PERSONAL where REGNUM = '" +Request.QueryString["regnum"]+ "'";
				conn.ExecuteQuery();
				TXT_NO_Reg.Text			= conn.GetFieldValue("REGNUM");
				TXT_NAMA_REK.Text		= conn.GetFieldValue("NAMEREKANAN");
				TXT_JNS_REK.Text		= conn.GetFieldValue("REKANANDESC");
				TXT_ADDRESS1.Text		= conn.GetFieldValue("ADDRESS1");
				TXT_ADDRESS2.Text		= conn.GetFieldValue("ADDRESS2");
				TXT_CITY.Text			= conn.GetFieldValue("CITY");
				
			}
			else //if company
			{
				conn.QueryString = "select * from VW_REKANAN_COMPANY where REGNUM = '" +Request.QueryString["regnum"]+ "'";
				conn.ExecuteQuery();
				TXT_NO_Reg.Text			= conn.GetFieldValue("REGNUM");
				TXT_NAMA_REK.Text		= conn.GetFieldValue("BADANUSAHA_DESC").Trim()+ " "+conn.GetFieldValue("NAMEREKANAN").Trim();
				TXT_JNS_REK.Text		= conn.GetFieldValue("REKANANDESC");
				TXT_ADDRESS1.Text		= conn.GetFieldValue("ADDRESS1");
				TXT_ADDRESS2.Text		= conn.GetFieldValue("ADDRESS2");
				TXT_CITY.Text			= conn.GetFieldValue("CITY");
				TXT_CP.Text				= conn.GetFieldValue("PIC_NAME");
				TXT_NoTelp.Text			= conn.GetFieldValue("PIC_PHONE_AREA").Trim()+"-"+ conn.GetFieldValue("PIC_PHONE#").Trim();
			}
		}

		private void ViewMenu()
		{
			try 
			{
				// "+Request.QueryString["mc"]+"
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
							strtemp = "regnum=" + Request.QueryString["regnum"] + "&rekanan_ref="+Request.QueryString["rekanan_ref"]  + "&tc=" + Request.QueryString["tc"];
						else	
							strtemp = "regnum=" + Request.QueryString["regnum"] + "&rekanan_ref="+Request.QueryString["rekanan_ref"]  + "&mc=" + Request.QueryString["mc"]+"&tc="+Request.QueryString["tc"];
						//t.ForeColor = Color.MidnightBlue; 
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

		protected void BTN_BACK_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			Response.Redirect("/SME/" + DMS.CuBESCore.Logic.backLink(Request.QueryString["tc"].ToString(), conn));
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

		}
		#endregion

		protected void BTN_UPDATE_Click(object sender, System.EventArgs e)
		{
			string reject = "0";
			float score=0;
			string pesan = "";
			
			conn.QueryString = "select sc_total from rekanan_wawancara where regnum='" + Request.QueryString["regnum"] + "'";
			conn.ExecuteQuery();

			txt_score.Text = conn.GetFieldValue("sc_total");
			try{score = float.Parse(txt_score.Text);}
			catch
			{
				GlobalTools.popMessage(this, "Isi terlebih dahulu halaman wawancara!");
				return;
			}

			//Jika Site Visit Belum Diisi
			conn.QueryString="select * from rekanan_site_visit where regnum='" + Request.QueryString["regnum"] + "' ";
			conn.ExecuteQuery();
			if (conn.GetRowCount() == 0)
			{
				GlobalTools.popMessage(this, "Halaman Site Visit belum diisi dan disimpan!");
				return;	
			}

			//Cek Kelengkapan Mandatory Site Visit
			conn.QueryString="select * from rekanan_site_visit where regnum='" + Request.QueryString["regnum"] + "' and (dilaksanakan1='' or diterima1='' or tgl_kunjungan=null)";
			conn.ExecuteQuery();
			if (conn.GetRowCount() > 0)
			{
				GlobalTools.popMessage(this, "Input Data mandatory Site Visit belum lengkap!");
				return;	
			}
			
			//Cek Kelengkapan Mandatory Wawancara
			conn.QueryString="select * from rekanan_wawancara where regnum='" + Request.QueryString["regnum"] + "' and (intviewer1='' or candidate1='' or intview_date=null) ";
			conn.ExecuteQuery();
			if (conn.GetRowCount() > 0)
			{
				GlobalTools.popMessage(this, "Input Data mandatory Wawancara belum lengkap!");
				return;	
			}
			
			//Cek Kelengkapan Data BI Checking
			conn.QueryString="select * from rekanan_bi where rekanan_ref='" + Request.QueryString["rekanan_ref"] + "'";
			conn.ExecuteQuery();
			if (conn.GetRowCount() < 1)
			{
				GlobalTools.popMessage(this, "Data BI Checking masih kosong!");
				return;
			}

			//Cek Kelengkapan Data Scoring Site_visit
			conn.QueryString = "select * from rekanan_site_visit where regnum='" + Request.QueryString["regnum"] + "'";
			conn.ExecuteQuery();

			float sc_add=0, sc_sarana=0, sc_database=0, sc_equitment=0, sc_building=0, sc_resource=0;			

			sc_add = float.Parse(conn.GetFieldValue("sc_add"));
			sc_sarana = float.Parse(conn.GetFieldValue("sc_sarana"));
			sc_database = float.Parse(conn.GetFieldValue("sc_database"));
			sc_equitment = float.Parse(conn.GetFieldValue("sc_equitment"));
			sc_building = float.Parse(conn.GetFieldValue("sc_building"));
			sc_resource = float.Parse(conn.GetFieldValue("sc_resource"));

			if (sc_add==0 || sc_sarana==0 || sc_database==0 || sc_equitment==0 || sc_building==0 || sc_resource==0)
			{
				GlobalTools.popMessage(this, "Input Data Kesimpulan/Pendapat Site Visit belum lengkap!");
				return;	
			}	
			

			//Cek Kelengkapan Wawancara untuk Scoring
			conn.QueryString = "select * from rekanan_wawancara where regnum='" + Request.QueryString["regnum"] + "'";
			conn.ExecuteQuery();

			float subtot1=0, subtot2=0, subtot3=0, subtot4=0, subtot5=0, nonsub1=0, nonsub2=0, nonsub3=0;
			subtot1 = float.Parse(conn.GetFieldValue("s_experiance"));
			subtot2 = float.Parse(conn.GetFieldValue("s_expert"));
			subtot3 = float.Parse(conn.GetFieldValue("s_mutu"));
			subtot4 = float.Parse(conn.GetFieldValue("s_cost"));
			subtot5 = float.Parse(conn.GetFieldValue("s_others"));

			nonsub1 = float.Parse(conn.GetFieldValue("nons_time"));
			nonsub2 = float.Parse(conn.GetFieldValue("nons_prepare"));
			nonsub3 = float.Parse(conn.GetFieldValue("nons_delivary"));

			if (subtot1==0 || subtot2==0 || subtot3==0 || subtot4==0 || subtot5==0 || nonsub1==0 || nonsub2==0 || nonsub3==0)
			{
				GlobalTools.popMessage(this, "Input Data Score Wawancara belum lengkap!");
				return;	
			}

			
			
			if(score < 3)
			{
				//Response.Write("<script language='javascript'>confirm('" + "Hasil wawancara < 3. Ingin memperbaiki hasil?" + "');</script>");
				pesan = "Tidak dapat melanjutkan ke tahap selanjutnya. Score wawancara < 3";
				
				reject="1";
				
				conn.QueryString = "exec REKANAN_TRACKUPDATE '" + 
					Request.QueryString["regnum"] + "', '" +
					Request.QueryString["tc"] + "', '" +
					Session["UserID"].ToString() + "', '" +
					reject + "'";
				conn.ExecuteNonQuery();

				conn.QueryString = "update application_rekanan set alasan='Score wawancara < 3' where regnum='" + Request.QueryString["regnum"] + "'";
				conn.ExecuteQuery();

				Response.Redirect("Verifikasi.aspx?tc=" + Request.QueryString["tc"] + "&mc=" + Request.QueryString["mc"] + "&msg=" + pesan);
			}
			else
			{
				conn.QueryString = "exec REKANAN_TRACKUPDATE '" + 
					Request.QueryString["regnum"] + "', '" +
					Request.QueryString["tc"] + "', '" +
					Session["UserID"].ToString() + "', '" +
					reject + "'";
				conn.ExecuteNonQuery();

				string msg = getNextStepMsg(Request.QueryString["regnum"]);
				Response.Redirect("Verifikasi.aspx?tc=" + Request.QueryString["tc"] + "&mc=" + Request.QueryString["mc"] + "&msg=" + msg);		
			}
		}
		private string getNextStepMsg(string regnum) 
		{
			string pesan = "";
			string nextTrack = "";
			try 
			{
				/***
				 * Memunculkan pesan next step
				 ***/
				conn.QueryString = "exec REKANAN_TRACKNEXTMSG '" + regnum + "'";
				conn.ExecuteQuery();
				nextTrack = conn.GetFieldValue("TRACKNAME");
				pesan = "Rekanan diproses ke tahap " + nextTrack;
				/***********************************/
			} 
			catch 
			{
				throw new Exception();
			}

			return pesan;
		}
	}
}
