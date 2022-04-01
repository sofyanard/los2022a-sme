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
	/// Summary description for InfoRekanan.
	/// </summary>
	public partial class InfoRekanan : System.Web.UI.Page
	{
		protected Connection conn;
		protected Tools tool = new Tools();
		int seq=8;
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			conn = (Connection) Session["Connection"];
			this.TXT_TEMP.TextChanged += new System.EventHandler(this.TXT_TEMP_TextChanged);

			//if (!Logic.AllowAccess(Session["GroupID"].ToString(), Request.QueryString["mc"], conn))
			//	Response.Redirect("/SME/Restricted.aspx");
			

			CheckPensiun();
			//

			if (Request.QueryString["exist"] == "1")
			{		
				//--- if existing rekanan, user tidak bisa ganti tipe rekanan
				RDO_RFCUSTOMERTYPE.Enabled = false;
				DDL_JENIS_REK_COMP.Enabled = false;
				DDL_JNS_REKANAN.Enabled = false;

			}

			CekView();
				
			LBL_REK_REF.Text=Request.QueryString["rekanan_ref"];
			LBL_REK_REG.Text=Request.QueryString["regnum"];
			
			CekTrack();
			ViewMenu();
			if(!IsPostBack)
			{
				BindQual();			    
				BindDataQuanitative();
				BindCla();
				TR_RBI.Visible = false;
				CekRBI();
				TR_NOTARIS.Visible=false;
				TR_PM.Visible = false;
				TR_TGL_PM.Visible = false;

				//ZipCode Perorangan
				DDL_CITY_CAB.Items.Add(new ListItem("--Pilih--", ""));
				DDL_KAB_CAB.Items.Add(new ListItem("--Pilih--",""));

				conn.QueryString = "select cityid, cityname from rfcity where active='1' order by cityname";
				conn.ExecuteQuery();
				for (int i = 0; i < conn.GetRowCount(); i++)
					DDL_CITY_CAB.Items.Add(new ListItem(conn.GetFieldValue(i,1),conn.GetFieldValue(i,0)));

				//ZipCode Badan Usaha
				DDL_CITY_CAB2.Items.Add(new ListItem("--Pilih--", ""));
				DDL_KAB_CAB2.Items.Add(new ListItem("--Pilih--",""));

				conn.QueryString = "select cityid, cityname from rfcity where active='1' order by cityname";
				conn.ExecuteQuery();
				for (int i = 0; i < conn.GetRowCount(); i++)
					DDL_CITY_CAB2.Items.Add(new ListItem(conn.GetFieldValue(i,1),conn.GetFieldValue(i,0)));



				DDL_BLN_DOC.Items.Add(new ListItem("--Pilih--",""));
				DDL_BLNEXP_DOC.Items.Add(new ListItem("--Pilih--",""));
				DDL_JNS_DOC.Items.Add(new ListItem("--Pilih--",""));

				for(int i=1; i<=12; i++)
				{
					DDL_BLN_DOC.Items.Add(new ListItem(DateAndTime.MonthName(i, false), i.ToString()));
					DDL_BLNEXP_DOC.Items.Add(new ListItem(DateAndTime.MonthName(i, false), i.ToString()));
				}

				conn.QueryString = "select doc_id, doc_desc from rekanan_rfdoctype where active='1'";
				conn.ExecuteQuery();
				for (int i=0; i<conn.GetRowCount(); i++)
				{
					DDL_JNS_DOC.Items.Add(new ListItem(conn.GetFieldValue(i,1),conn.GetFieldValue(i,0)));
				}
				
				DDL_BLN_LAHIR.Items.Add(new ListItem("--Pilih--",""));
				DDL_COMP_BLN.Items.Add(new ListItem("--Pilih--",""));
				DDL_JENIS_BU.Items.Add(new ListItem("--Pilih--",""));
				DDL_JENIS_REK_COMP.Items.Add(new ListItem("--Pilih--",""));
				DDL_JNS_REKANAN.Items.Add(new ListItem("--Pilih--",""));
				DDL_BLN_KTP.Items.Add(new ListItem("--Pilih--",""));
				DDL_BLN_PENSIUN.Items.Add(new ListItem("--Pilih--",""));

				for (int i=1; i<=12; i++)
				{
					DDL_BLN_KTP.Items.Add(new ListItem(DateAndTime.MonthName(i, false), i.ToString()));
					DDL_BLN_LAHIR.Items.Add(new ListItem(DateAndTime.MonthName(i, false), i.ToString()));
					DDL_BLN_PENSIUN.Items.Add(new ListItem(DateAndTime.MonthName(i, false), i.ToString()));
					DDL_COMP_BLN.Items.Add(new ListItem(DateAndTime.MonthName(i, false), i.ToString()));
				}

				/*conn.QueryString="select rekananid, rekanandesc from rfjenisrekanan where active='1'";
				conn.ExecuteQuery();
				for (int i = 0; i < conn.GetRowCount(); i++)
					DDL_JNS_REKANAN.Items.Add(new ListItem(conn.GetFieldValue(i,1), conn.GetFieldValue(i,0)));

				conn.QueryString="select rekananid, rekanandesc from rfjenisrekanan where active='1'";
				conn.ExecuteQuery();
				for (int i = 0; i < conn.GetRowCount(); i++)
					DDL_JENIS_REK_COMP.Items.Add(new ListItem(conn.GetFieldValue(i,1), conn.GetFieldValue(i,0)));
					*/

				conn.QueryString="SELECT BADANUSAHA_ID, BADANUSAHA_DESC FROM RFBADANUSAHA_REKANAN WHERE ACTIVE='1'";
				conn.ExecuteQuery();
				for (int i=0; i < conn.GetRowCount(); i++)
					DDL_JENIS_BU.Items.Add(new ListItem(conn.GetFieldValue(i,1), conn.GetFieldValue(i,0)));

				conn.QueryString = "select custtypeid, custtypedesc from rfcustomertype where active='1'";
				conn.ExecuteQuery();
				for (int i = 0; i < conn.GetRowCount(); i++)
					RDO_RFCUSTOMERTYPE.Items.Add(new ListItem(conn.GetFieldValue(i,1), conn.GetFieldValue(i,0)));

				RDO_RFCUSTOMERTYPE.SelectedIndex=0;
				TR_COMPANY.Visible=true;	TR_PERSONAL.Visible=false;

				conn.QueryString="select rekananid, rekanandesc from rfjenisrekanan where active='1' and rekananid not in('07')";
				conn.ExecuteQuery();
				for (int i = 0; i < conn.GetRowCount(); i++)
					DDL_JENIS_REK_COMP.Items.Add(new ListItem(conn.GetFieldValue(i,1), conn.GetFieldValue(i,0)));

				TXT_NO_REG.Text=Request.QueryString["regnum"];

				GlobalTools.initDateForm(TXT_TGL_LAHIR, DDL_BLN_LAHIR, TXT_THN_LAHIR, true);
				GlobalTools.initDateForm(TXT_TGL_KTP, DDL_BLN_KTP, TXT_THN_KTP, true);
				GlobalTools.initDateForm(TXT_TGL_PENSIUN, DDL_BLN_PENSIUN, TXT_THN_PENSIUN, true);
				GlobalTools.initDateForm(TXT_COMP_TGL, DDL_COMP_BLN, TXT_COMP_THN, true);

				DDL_BLN_BURSA.Items.Add(new ListItem("--Pilih--", ""));
				DDL_BLN_PPAT.Items.Add(new ListItem("--Pilih--",""));
				DDL_BLN_SK.Items.Add(new ListItem("--Pilih--",""));
				DDL_BLN_SUMPAH.Items.Add(new ListItem("--Pilih--",""));
				DDL_BLN_BAPEPAM.Items.Add(new ListItem("--Pilih--",""));
				DDL_BLN_KOP.Items.Add(new ListItem("--Pilih--",""));
				DDL_BLN_INI.Items.Add(new ListItem("--Pilih--",""));
				DDL_BLN_IPPAT.Items.Add(new ListItem("--Pilih--",""));
				DDL_BLN_SUMPAH_PPAT.Items.Add(new ListItem("--Pilih--",""));

				for(int i=1; i<=12; i++)
				{
					DDL_BLN_BURSA.Items.Add(new ListItem(DateAndTime.MonthName(i, false), i.ToString()));
					DDL_BLN_PPAT.Items.Add(new ListItem(DateAndTime.MonthName(i, false), i.ToString()));
					DDL_BLN_SK.Items.Add(new ListItem(DateAndTime.MonthName(i, false), i.ToString()));
					DDL_BLN_SUMPAH.Items.Add(new ListItem(DateAndTime.MonthName(i, false), i.ToString()));
					DDL_BLN_SUMPAH_PPAT.Items.Add(new ListItem(DateAndTime.MonthName(i, false), i.ToString()));
					DDL_BLN_INI.Items.Add(new ListItem(DateAndTime.MonthName(i, false), i.ToString()));
					DDL_BLN_IPPAT.Items.Add(new ListItem(DateAndTime.MonthName(i, false), i.ToString()));
					DDL_BLN_KOP.Items.Add(new ListItem(DateAndTime.MonthName(i, false), i.ToString()));
					DDL_BLN_BAPEPAM.Items.Add(new ListItem(DateAndTime.MonthName(i, false), i.ToString()));
				}
				
				TXT_HIGH_LIMIT.Text = tool.MoneyFormat(TXT_HIGH_LIMIT.Text);

				
				ViewData();
				
				ViewDoc();
				ViewDataNotaris();
				CekSyarat();
				
			}
			BTN_UPDATE_REKANAN.Attributes.Add("onclick","if(!update()){return false;};");
			//BTN_SAVE_REKANAN.Click += new System.EventHandler(BTN_SAVE_REKANAN_Click);
			//this.BTN_SAVE_REKANAN.Click += new System.EventHandler(this.BTN_SAVE_REKANAN_Click);
			//BTN_SAVE_REKANAN.Attributes.Add("onclick","if(!cek_mandatory(document.Form1)){return false;};");
			BTN_UPDATE.Visible=false;
			BTN_INSERT.Visible=true;
			
		}

		private void CekRBI()
		{
			conn.QueryString = "select * from application_rekanan where regnum= '" + Request.QueryString["rekanan_ref"] + "C" + "' ";
			conn.ExecuteQuery();
			if (conn.GetRowCount() == 1)
				TR_RBI.Visible = true;
		}

		private void TXT_TEMP_TextChanged(object sender, EventArgs e)
		{
			if (TXT_TEMP.Text != "") 
			{
				string msg = "";
				msg = "Application acquire information from " + TXT_TEMP.Text + " !";
				Response.Redirect("ListKeputusan.aspx?mc="+Request.QueryString["mc"]+"&tc=" + Request.QueryString["tc"]+"&msg="+msg);
			}
		}

		private void CheckPensiun()
		{
			string tanggal;
			
			try
			{
				conn.QueryString = "exec REKANAN_CEK_PENSIUN '" + Request.QueryString["rekanan_ref"] + "'";
				conn.ExecuteNonQuery();
			}
			catch(Exception ex)
			{
				string errmsg = ex.Message.Replace("'","");
				if (errmsg.IndexOf("Last Query:") > 0)
					errmsg = errmsg.Substring(0, errmsg.IndexOf("Last Query:"));

				conn.QueryString = "select pensiun_date from vw_rekanan_daftar_pensiun where rekanan_ref='" + Request.QueryString["rekanan_ref"] + "'";
				conn.ExecuteQuery();
				tanggal = tool.FormatDate(conn.GetFieldValue("pensiun_date"), true);

				GlobalTools.popMessage(this, errmsg+ " " + tanggal);
				return;
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
			this.DatGridDoc.ItemCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.DatGridDoc_ItemCommand);
			this.DatGridDoc.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.DatGridDoc_PageIndexChanged);

		}
		#endregion

		private void ViewDataNotaris()
		{
			conn.QueryString = "select * from rekanan_notaris where rekanan_ref='" + Request.QueryString["rekanan_ref"] + "'";
			conn.ExecuteQuery();

			if (conn.GetRowCount() > 0)
			{
				TXT_REK_BURSA.Text = conn.GetFieldValue("REG_BURSA");
				LBL_REK_BURSA.Text = conn.GetFieldValue("REG_BURSA");

				TXT_TGL_BURSA.Text = tool.FormatDate_Day(conn.GetFieldValue("REG_DATE"));
				LBL_TGL_BURSA.Text = tool.FormatDate_Day(conn.GetFieldValue("REG_DATE"));

				try
				{
					DDL_BLN_BURSA.SelectedValue = tool.FormatDate_Month(conn.GetFieldValue("REG_DATE"));
					LBL_BLN_BURSA.Text = tool.FormatDate_Month(conn.GetFieldValue("REG_DATE"));

				}
				catch{DDL_BLN_BURSA.SelectedValue="";}

				TXT_THN_BURSA.Text = tool.FormatDate_Year(conn.GetFieldValue("REG_DATE"));
				LBL_THN_BURSA.Text = tool.FormatDate_Year(conn.GetFieldValue("REG_DATE"));

				TXT_HIGH_LIMIT.Text = conn.GetFieldValue("HIGH_LIMIT");
				LBL_HIGH_LIMIT.Text = conn.GetFieldValue("HIGH_LIMIT");

				TXT_SK_NOTARIS.Text = conn.GetFieldValue("SK_NOTARIS");
				LBL_SK_NOTARIS.Text = conn.GetFieldValue("SK_NOTARIS");

				TXT_TGL_SK.Text = tool.FormatDate_Day(conn.GetFieldValue("SK_DATE"));
				LBL_TGL_SK.Text = tool.FormatDate_Day(conn.GetFieldValue("SK_DATE"));

				try{
					DDL_BLN_SK.SelectedValue = tool.FormatDate_Month(conn.GetFieldValue("SK_DATE"));
					LBL_TGL_SK.Text = tool.FormatDate_Month(conn.GetFieldValue("SK_DATE"));
				}
				catch{DDL_BLN_SK.SelectedValue="";}

				TXT_THN_SK.Text = tool.FormatDate_Year(conn.GetFieldValue("SK_DATE"));
				LBL_THN_SK.Text = tool.FormatDate_Year(conn.GetFieldValue("SK_DATE"));

				TXT_KOTA_NOTARIS.Text = conn.GetFieldValue("NOTARY_CITY");
				LBL_KOTA_NOTARIS.Text = conn.GetFieldValue("NOTARY_CITY");

				TXT_SK_PPAT.Text = conn.GetFieldValue("PPAT");
				LBL_SK_PPAT.Text = conn.GetFieldValue("PPAT");

				TXT_TGL_PPAT.Text = tool.FormatDate_Day(conn.GetFieldValue("PPAT_DATE"));
				LBL_TGL_PPAT.Text = tool.FormatDate_Day(conn.GetFieldValue("PPAT_DATE"));

				try{
					DDL_BLN_PPAT.SelectedValue = tool.FormatDate_Month(conn.GetFieldValue("PPAT_DATE"));
					LBL_BLN_PPAT.Text= tool.FormatDate_Month(conn.GetFieldValue("PPAT_DATE"));
				}
				catch{DDL_BLN_PPAT.SelectedValue = "";}

				TXT_THN_PPAT.Text = tool.FormatDate_Year(conn.GetFieldValue("PPAT_DATE"));
				LBL_THN_PPAT.Text = tool.FormatDate_Year(conn.GetFieldValue("PPAT_DATE"));

				TXT_PPAT_LOKASI.Text = conn.GetFieldValue("PPAT_LOKASI");
				LBL_PPAT_LOKASI.Text = conn.GetFieldValue("PPAT_LOKASI");

				TXT_SUMPAH_NOTARIS.Text = conn.GetFieldValue("NOTARY#");
				LBL_SUMPAH_NOTARIS.Text = conn.GetFieldValue("NOTARY#");

				TXT_TGL_SUMPAH.Text = tool.FormatDate_Day(conn.GetFieldValue("NOTARY_DATE"));
				LBL_TGL_SUMPAH.Text = tool.FormatDate_Day(conn.GetFieldValue("NOTARY_DATE"));

				try{
					DDL_BLN_SUMPAH.SelectedValue = tool.FormatDate_Month(conn.GetFieldValue("NOTARY_DATE"));
					LBL_BLN_SUMPAH.Text = tool.FormatDate_Month(conn.GetFieldValue("NOTARY_DATE"));}
				catch{DDL_BLN_SUMPAH.SelectedValue = "";}

				TXT_THN_SUMPAH.Text = tool.FormatDate_Year(conn.GetFieldValue("NOTARY_DATE"));
				LBL_THN_SUMPAH.Text = tool.FormatDate_Year(conn.GetFieldValue("NOTARY_DATE"));

				TXT_REMARK.Text = conn.GetFieldValue("REMARKS");
				LBL_REMARK.Text = conn.GetFieldValue("REMARKS");

				try{
					RDO_KOPERASI.SelectedValue = conn.GetFieldValue("ANGGOTA_KOPERASI");
					LBL_KOPERASI.Text = RDO_KOPERASI.SelectedItem.Text;
				}
				catch{RDO_KOPERASI.SelectedValue = "Y";}

				CekKoperasi();

				TXT_NO_KOP.Text = conn.GetFieldValue("SK_KOPERASI");
				LBL_NO_KOP.Text = conn.GetFieldValue("SK_KOPERASI");

				TXT_TGL_KOP.Text = tool.FormatDate_Day(conn.GetFieldValue("SK_KOP_DATE"));
				LBL_TGL_KOP.Text = tool.FormatDate_Day(conn.GetFieldValue("SK_KOP_DATE"));

				try{
					DDL_BLN_KOP.SelectedValue = tool.FormatDate_Month(conn.GetFieldValue("SK_KOP_DATE"));
					LBL_BLN_KOP.Text= tool.FormatDate_Month(conn.GetFieldValue("SK_KOP_DATE"));
				}
				catch{DDL_BLN_KOP.SelectedValue ="";}

				TXT_THN_KOP.Text = tool.FormatDate_Year(conn.GetFieldValue("SK_KOP_DATE"));
				LBL_THN_KOP.Text = tool.FormatDate_Year(conn.GetFieldValue("SK_KOP_DATE"));

				try{
					RDO_BAPEPAM.SelectedValue = conn.GetFieldValue("ANGGOTA_BAPEPAM");
					LBL_BAPEPAM.Text = RDO_BAPEPAM.SelectedItem.Text;
				}
				catch{RDO_BAPEPAM.SelectedValue ="Y";}
				CekBapepam();

				TXT_NO_BAPEPAM.Text = conn.GetFieldValue("SK_BAPEPAM");
				LBL_NO_BAPEPAM.Text = conn.GetFieldValue("SK_BAPEPAM");

				TXT_TGL_BAPEPAM.Text = tool.FormatDate_Day(conn.GetFieldValue("SK_BAP_DATE"));
				LBL_TGL_BAPEPAM.Text = tool.FormatDate_Day(conn.GetFieldValue("SK_BAP_DATE"));

				try{
					DDL_BLN_BAPEPAM.SelectedValue = tool.FormatDate_Month(conn.GetFieldValue("SK_BAP_DATE"));
					LBL_BLN_BAPEPAM.Text = tool.FormatDate_Month(conn.GetFieldValue("SK_BAP_DATE"));
				}
				catch{DDL_BLN_BAPEPAM.SelectedValue ="";}

				TXT_THN_BAPEPAM.Text = tool.FormatDate_Year(conn.GetFieldValue("SK_BAP_DATE"));
				LBL_THN_BAPEPAM.Text = tool.FormatDate_Year(conn.GetFieldValue("SK_BAP_DATE"));

				TXT_SUMPAH_PPAT.Text = conn.GetFieldValue("PPAT#");
				LBL_SUMPAH_PPAT.Text = conn.GetFieldValue("PPAT#");

				TXT_TGL_SUMPAH_PPAT.Text = tool.FormatDate_Day(conn.GetFieldValue("PPAT#_DATE"));
				LBL_TGL_SUMPAH_PPAT.Text = tool.FormatDate_Day(conn.GetFieldValue("PPAT#_DATE"));

				try{
					DDL_BLN_SUMPAH_PPAT.SelectedValue = tool.FormatDate_Month(conn.GetFieldValue("PPAT#_DATE"));
					LBL_BLN_SUMPAH_PPAT.Text = tool.FormatDate_Month(conn.GetFieldValue("PPAT#_DATE"));
				}
				catch{DDL_BLN_SUMPAH_PPAT.SelectedValue ="";}

				TXT_THN_SUMPAH_PPAT.Text = tool.FormatDate_Year(conn.GetFieldValue("PPAT#_DATE"));
				LBL_THN_SUMPAH_PPAT.Text = tool.FormatDate_Year(conn.GetFieldValue("PPAT#_DATE"));

				try{
					RDO_INI.SelectedValue = conn.GetFieldValue("ANGGOTA_INI");
					LBL_INI.Text = RDO_INI.SelectedItem.Text;
				}
				catch{RDO_INI.SelectedValue ="Y";}
				CekINI();

				TXT_NO_INI.Text = conn.GetFieldValue("SK_INI");
				LBL_NO_INI.Text = conn.GetFieldValue("SK_INI");

				TXT_TGL_INI.Text = tool.FormatDate_Day(conn.GetFieldValue("SK_INI_DATE"));
				LBL_TGL_INI.Text = tool.FormatDate_Day(conn.GetFieldValue("SK_INI_DATE"));

				try{
					DDL_BLN_INI.SelectedValue = tool.FormatDate_Month(conn.GetFieldValue("SK_INI_DATE"));
					LBL_BLN_INI.Text = tool.FormatDate_Month(conn.GetFieldValue("SK_INI_DATE"));
				}
				catch{DDL_BLN_INI.SelectedValue ="";}

				TXT_THN_INI.Text = tool.FormatDate_Year(conn.GetFieldValue("SK_INI_DATE"));
				LBL_THN_INI.Text = tool.FormatDate_Year(conn.GetFieldValue("SK_INI_DATE"));

				TXT_HIGH_LIMIT.Text = tool.MoneyFormat(TXT_HIGH_LIMIT.Text);
				LBL_HIGH_LIMIT.Text = tool.MoneyFormat(TXT_HIGH_LIMIT.Text);
				
				try{
					RDO_IPPAT.SelectedValue = conn.GetFieldValue("ANGGOTA_IPPAT");
					LBL_IPPAT.Text = RDO_IPPAT.SelectedItem.Text;
				}
				catch{RDO_IPPAT.SelectedValue ="Y";}
				CekIPPAT();

				TXT_NO_IPPAT.Text = conn.GetFieldValue("SK_IPPAT");
				LBL_NO_IPPAT.Text = conn.GetFieldValue("SK_IPPAT");

				TXT_TGL_IPPAT.Text = tool.FormatDate_Day(conn.GetFieldValue("SK_IPPAT_DATE"));
				LBL_TGL_IPPAT.Text = tool.FormatDate_Day(conn.GetFieldValue("SK_IPPAT_DATE"));

				try{
					DDL_BLN_IPPAT.SelectedValue = tool.FormatDate_Month(conn.GetFieldValue("SK_IPPAT_DATE"));
					LBL_BLN_IPPAT.Text= tool.FormatDate_Month(conn.GetFieldValue("SK_IPPAT_DATE"));
				}
				catch{DDL_BLN_IPPAT.SelectedValue ="";}

				TXT_THN_IPPAT.Text = tool.FormatDate_Year(conn.GetFieldValue("SK_IPPAT_DATE"));
				LBL_THN_IPPAT.Text = tool.FormatDate_Year(conn.GetFieldValue("SK_IPPAT_DATE"));
				
			}
		}

		private void CekTrack()
		{
			conn.QueryString = "select ap_currtrack from rekanan_apptrack where regnum='" + LBL_REK_REG.Text + "'";
			conn.ExecuteQuery();

			if (conn.GetFieldValue("ap_currtrack") != "A1.1")
				BTN_UPDATE_REKANAN.Enabled = false;
			else
				BTN_UPDATE_REKANAN.Enabled = true;
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


		private void ViewData()
		{
			conn.QueryString = "SELECT * FROM REKANAN WHERE REKANAN_REF='" + LBL_REK_REF.Text + "'";
			conn.ExecuteQuery();
			string kabupaten="";

			if(conn.GetFieldValue("REKANANTYPEID")=="01")
			{
				conn.QueryString="SELECT * FROM VW_REKANAN_COMPANY WHERE REKANAN_REF='" + LBL_REK_REF.Text + "'";
				conn.ExecuteQuery();
				
				TR_COMPANY.Visible = true;
				TR_PERSONAL.Visible = false;

				RDO_RFCUSTOMERTYPE.SelectedValue = "01";

				SetMandatory(RDO_RFCUSTOMERTYPE.SelectedValue);

				conn.QueryString="SELECT * FROM VW_REKANAN_COMPANY WHERE REKANAN_REF='" + LBL_REK_REF.Text + "'";
				conn.ExecuteQuery();

				//Tambahan penyimpanan data ke label untuk audittrail oleh Ariel
				try
				{ 
					DDL_JENIS_REK_COMP.SelectedValue = conn.GetFieldValue("RFREKANANTYPE");
					LBL_JENIS_REK_COMP.Text = DDL_JENIS_REK_COMP.SelectedItem.Text;
				}
				catch{DDL_JENIS_REK_COMP.SelectedValue="";}

				try
				{
					DDL_JENIS_BU.SelectedValue = conn.GetFieldValue("LAWTYPE");
					LBL_JENIS_BU.Text = DDL_JENIS_BU.SelectedItem.Text;
				}
				catch{DDL_JENIS_BU.SelectedValue="";}

				TXT_NAMA_COMP.Text = conn.GetFieldValue("NAMEREKANAN");
				LBL_NAMA_COMP.Text = conn.GetFieldValue("NAMEREKANAN");

				TXT_COMP_ADD1.Text = conn.GetFieldValue("ADDRESS1");
				LBL_COMP_ADD1.Text = conn.GetFieldValue("ADDRESS1");
				//DDL_CITY_CAB.SelectedValue = conn.GetFieldValue("ADDRESS2");
				//DDL_KAB_CAB.SelectedValue = conn.GetFieldValue("CITY");

				TXT_COMP_ZIPCODE.Text = conn.GetFieldValue("RFZIPCD");
				LBL_COMP_ZIPCODE.Text = conn.GetFieldValue("RFZIPCD");

				TXT_COMP_AREA.Text = conn.GetFieldValue("PHONE_AREA");
				LBL_COMP_AREA.Text = conn.GetFieldValue("PHONE_AREA");

				TXT_COMP_TLP.Text = conn.GetFieldValue("PHONE#");
				LBL_COMP_TLP.Text = conn.GetFieldValue("PHONE#");

				TXT_COMP_AREA2.Text = conn.GetFieldValue("PHONE_AREA2");
				LBL_COMP_AREA2.Text = conn.GetFieldValue("PHONE_AREA2");

				TXT_COMP_TLP2.Text = conn.GetFieldValue("PHONE2#");
				LBL_COMP_TLP2.Text = conn.GetFieldValue("PHONE2#");

				TXT_COMP_TGL.Text = tool.FormatDate_Day(conn.GetFieldValue("ISTABLISH_DATE"));
				LBL_COMP_TGL.Text = tool.FormatDate_Day(conn.GetFieldValue("ISTABLISH_DATE"));

				try
				{ 
					DDL_COMP_BLN.SelectedValue = tool.FormatDate_Month(conn.GetFieldValue("ISTABLISH_DATE"));
					LBL_COMP_BLN.Text =DDL_COMP_BLN.SelectedValue;
				}
				catch{DDL_COMP_BLN.SelectedValue="";}

				TXT_COMP_THN.Text = tool.FormatDate_Year(conn.GetFieldValue("ISTABLISH_DATE"));
				LBL_COMP_THN.Text = tool.FormatDate_Year(conn.GetFieldValue("ISTABLISH_DATE"));

				TXT_COMP_TMP.Text = conn.GetFieldValue("ISTABLISH_PLACE");
				LBL_COMP_TMP.Text = conn.GetFieldValue("ISTABLISH_PLACE");

				TXT_COMP_FAX1.Text = conn.GetFieldValue("FAX_AREA");
				LBL_COMP_FAX1.Text = conn.GetFieldValue("FAX_AREA");

				TXT_COMP_FAX2.Text = conn.GetFieldValue("FAX#");
				TXT_COMP_FAX2.Text = conn.GetFieldValue("FAX#");

				TXT_COMP_FAX3.Text = conn.GetFieldValue("FAX_AREA2");
				LBL_COMP_FAX3.Text = conn.GetFieldValue("FAX_AREA2");

				TXT_COMP_FAX4.Text = conn.GetFieldValue("FAX2#");	
				LBL_COMP_FAX4.Text = conn.GetFieldValue("FAX2#");

				TXT_COMP_NPWP.Text = conn.GetFieldValue("ID_NUMBER");
				LBL_COMP_NPWP.Text = conn.GetFieldValue("ID_NUMBER");

				TXT_COMP_CPNAME.Text = conn.GetFieldValue("PIC_NAME");
				LBL_COMP_CPNAME.Text = conn.GetFieldValue("PIC_NAME");

				TXT_COMP_CPJBT.Text = conn.GetFieldValue("PIC_POSITION");
				LBL_COMP_CPJBT.Text = conn.GetFieldValue("PIC_POSITION");

				TXT_COMP_TLPCP1.Text = conn.GetFieldValue("PIC_PHONE_AREA");
				LBL_COMP_TLPCP1.Text = conn.GetFieldValue("PIC_PHONE_AREA");

				TXT_COMP_TLPCP2.Text = conn.GetFieldValue("PIC_PHONE#");
				LBL_COMP_TLPCP2.Text = conn.GetFieldValue("PIC_PHONE#");

				TXT_COMP_HPCP1.Text = conn.GetFieldValue("PIC_MOBILE_AREA");
				LBL_COMP_HPCP1.Text = conn.GetFieldValue("PIC_MOBILE_AREA");

				TXT_COMP_CPHP2.Text = conn.GetFieldValue("PIC_MOBILE#");
				LBL_COMP_CPHP2.Text = conn.GetFieldValue("PIC_MOBILE#");

				try
				{
					RDO_MERANGKAP_KM.SelectedValue = conn.GetFieldValue("RANGKAP_KM");
				}
				catch{RDO_MERANGKAP_KM.SelectedValue = "0";}

				try
				{ 
					DDL_CITY_CAB2.SelectedValue = conn.GetFieldValue("ADD2");
					LBL_CITY_CAB2.Text = DDL_CITY_CAB2.SelectedItem.Text;
				}
				catch{DDL_CITY_CAB2.SelectedValue="";}

				kabupaten = conn.GetFieldValue("CITYCODE");

				ViewKab2();
				try
				{
					DDL_KAB_CAB2.SelectedValue = kabupaten;
					LBL_KAB_CAB2.Text = DDL_KAB_CAB2.SelectedItem.Text;
				}
				catch{DDL_KAB_CAB2.SelectedValue = "";}

				CekRekananComp();
				
				CekDocType(DDL_JENIS_REK_COMP.SelectedValue);
			}
			else
				if(conn.GetFieldValue("REKANANTYPEID")=="02")
			{
				conn.QueryString="SELECT * FROM VW_REKANAN_PERSONAL WHERE REKANAN_REF='" + LBL_REK_REF.Text + "'";
				conn.ExecuteQuery();
				
				TR_COMPANY.Visible = false;
				TR_PERSONAL.Visible = true;

				RDO_RFCUSTOMERTYPE.SelectedValue = "02";

				SetMandatory(RDO_RFCUSTOMERTYPE.SelectedValue);

				conn.QueryString="SELECT * FROM VW_REKANAN_PERSONAL WHERE REKANAN_REF='" + LBL_REK_REF.Text + "'";
				conn.ExecuteQuery();				

				try
				{ 
					DDL_JENIS_REK_COMP.SelectedValue = conn.GetFieldValue("RFREKANANTYPE");
				}
				catch{DDL_JENIS_REK_COMP.SelectedValue="";}

				try
				{
					DDL_JNS_REKANAN.SelectedValue = conn.GetFieldValue("RFREKANANTYPE");
					LBL_JNS_REKANAN.Text = DDL_JNS_REKANAN.SelectedItem.Text;
				}
				catch{DDL_JNS_REKANAN.SelectedValue="";}

				TXT_TITLE.Text = conn.GetFieldValue("TITLE");
				LBL_TITLE.Text = conn.GetFieldValue("TITLE");

				TXT_NAMA.Text =  conn.GetFieldValue("NAMEREKANAN");
				LBL_NAMA.Text =  conn.GetFieldValue("NAMEREKANAN");

				TXT_TGL_LAHIR.Text = tool.FormatDate_Day(conn.GetFieldValue("DOB"));
				LBL_TGL_LAHIR.Text = tool.FormatDate_Day(conn.GetFieldValue("DOB"));

				try
				{
					DDL_BLN_LAHIR.SelectedValue = tool.FormatDate_Month(conn.GetFieldValue("DOB"));
					LBL_BLN_LAHIR.Text = DDL_BLN_LAHIR.SelectedValue;
				}
				catch{DDL_BLN_LAHIR.SelectedValue = "";}

				TXT_THN_LAHIR.Text = tool.FormatDate_Year(conn.GetFieldValue("DOB"));
				LBL_THN_LAHIR.Text = tool.FormatDate_Year(conn.GetFieldValue("DOB"));

				TXT_TMP_LAHIR.Text = conn.GetFieldValue("BIRTH_PLACE");
				LBL_TMP_LAHIR.Text = conn.GetFieldValue("BIRTH_PLACE");

				TXT_REK_ADD1.Text = conn.GetFieldValue("ADDRESS1");
				LBL_REK_ADD1.Text = conn.GetFieldValue("ADDRESS1");

				//DDL_CITY_CAB2.SelectedValue = conn.GetFieldValue("ADDRESS2");
				//DDL_KAB_CAB2.SelectedValue = conn.GetFieldValue("CITY");
				TXT_NO_AREA.Text = conn.GetFieldValue("OFFICE_AREA");
				LBL_NO_AREA.Text = conn.GetFieldValue("OFFICE_AREA");

				TXT_NO_KNTR.Text = conn.GetFieldValue("OFFICE#");
				LBL_NO_KNTR.Text = conn.GetFieldValue("OFFICE#");

				TXT_NO_AREA2.Text = conn.GetFieldValue("OFFICE_AREA2");
				LBL_NO_AREA2.Text = conn.GetFieldValue("OFFICE_AREA2");

				TXT_NO_KNTR2.Text = conn.GetFieldValue("OFFICE2#");
				LBL_NO_KNTR2.Text = conn.GetFieldValue("OFFICE2#");

				TXT_NO_AREA_FAX.Text = conn.GetFieldValue("FAX_AREA");
				LBL_NO_AREA_FAX.Text = conn.GetFieldValue("FAX_AREA");

				TXT_NO_FAX.Text = conn.GetFieldValue("FAX#");
				LBL_NO_FAX.Text = conn.GetFieldValue("FAX#");

				TXT_NO_AREA_FAX2.Text = conn.GetFieldValue("FAX_AREA2");
				LBL_NO_AREA_FAX2.Text = conn.GetFieldValue("FAX_AREA2");

				TXT_NO_FAX2.Text = conn.GetFieldValue("FAX2#");
				LBL_NO_FAX2.Text = conn.GetFieldValue("FAX2#");

				TXT_EMAIL.Text = conn.GetFieldValue("eMAIL");
				LBL_EMAIL.Text = conn.GetFieldValue("eMAIL");

				TXT_HP1.Text = conn.GetFieldValue("MOBILE_AREA");
				LBL_HP1.Text = conn.GetFieldValue("MOBILE_AREA");

				TXT_HP2.Text = conn.GetFieldValue("MOBILE#");
				LBL_HP2.Text = conn.GetFieldValue("MOBILE#");

				TXT_NPWP_PERSONAL.Text = conn.GetFieldValue("ID_NUMBER");
				LBL_NPWP_PERSONAL.Text = conn.GetFieldValue("ID_NUMBER");

				TXT_NOKTP.Text = conn.GetFieldValue("ktp#");
				LBL_NOKTP.Text = conn.GetFieldValue("ktp#");

				TXT_TGL_KTP.Text = tool.FormatDate_Day(conn.GetFieldValue("KTP_DATE"));
				LBL_TGL_KTP.Text = tool.FormatDate_Day(conn.GetFieldValue("KTP_DATE"));

				try
				{
					DDL_BLN_KTP.SelectedValue = tool.FormatDate_Month(conn.GetFieldValue("KTP_DATE"));
					LBL_BLN_KTP.Text = DDL_BLN_KTP.SelectedValue;
				}
				catch{DDL_BLN_KTP.SelectedValue = "";}

				TXT_THN_KTP.Text = tool.FormatDate_Year(conn.GetFieldValue("KTP_DATE"));
				LBL_THN_KTP.Text = tool.FormatDate_Year(conn.GetFieldValue("KTP_DATE"));

				TXT_TGL_PENSIUN.Text = tool.FormatDate_Day(conn.GetFieldValue("PENSIUN_DATE"));
				LBL_TGL_PENSIUN.Text = tool.FormatDate_Day(conn.GetFieldValue("PENSIUN_DATE"));

				try
				{
					DDL_BLN_PENSIUN.SelectedValue = tool.FormatDate_Month(conn.GetFieldValue("PENSIUN_DATE"));
					LBL_BLN_PENSIUN.Text = DDL_BLN_PENSIUN.SelectedValue;
				}
				catch{DDL_BLN_PENSIUN.SelectedValue = "";}

				TXT_THN_PENSIUN.Text = tool.FormatDate_Year(conn.GetFieldValue("PENSIUN_DATE"));
				LBL_THN_PENSIUN.Text = tool.FormatDate_Year(conn.GetFieldValue("PENSIUN_DATE"));

				TXT_ZIP_CODE.Text = conn.GetFieldValue("RFZIPCD");
				LBL_ZIP_CODE.Text = conn.GetFieldValue("RFZIPCD");
				
				try{RDO_MERANGKAP_KM.SelectedValue = conn.GetFieldValue("RANGKAP_KM");}
				catch{RDO_MERANGKAP_KM.SelectedValue ="0";}
				try
				{ 
					DDL_CITY_CAB.SelectedValue = conn.GetFieldValue("ADD2");
					LBL_CITY_CAB.Text = DDL_CITY_CAB.SelectedItem.Text;
				}
				catch{DDL_CITY_CAB.SelectedValue="";}				

				kabupaten = conn.GetFieldValue("CITYCODE");
				ViewKab();
				try{DDL_KAB_CAB.SelectedValue = kabupaten;}
				catch{DDL_KAB_CAB.SelectedValue = "";}
				CekRekananPersonal();
				CekDocType(DDL_JNS_REKANAN.SelectedValue);
			}
			
		}

		private void FillDocGrid()
		{
			DataTable dt = new DataTable();
			dt = conn.GetDataTable().Copy();
			DatGridDoc.DataSource = dt;
			try 
			{
				DatGridDoc.DataBind();
			} 
			catch 
			{
				DatGridDoc.CurrentPageIndex = 0;
				DatGridDoc.DataBind();
			}
			for (int i = 0; i < DatGridDoc.Items.Count; i++)
			{
				DatGridDoc.Items[i].Cells[3].Text = tool.FormatDate(DatGridDoc.Items[i].Cells[3].Text, true);
				DatGridDoc.Items[i].Cells[4].Text = tool.FormatDate(DatGridDoc.Items[i].Cells[4].Text, true);
			}
		}
		
		protected void RDO_RFCUSTOMERTYPE_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			SetMandatory(RDO_RFCUSTOMERTYPE.SelectedValue);
			ViewMenu();
			return;
		}

		private void SetMandatory(string custType)
		{
			if (custType == "01")
			{
				
				TR_COMPANY.Visible = true;
				TR_PERSONAL.Visible = false;

				DDL_JENIS_REK_COMP.Items.Clear();
				DDL_JENIS_REK_COMP.Items.Add(new ListItem("--Pilih--",""));
				conn.QueryString="select rekananid, rekanandesc from rfjenisrekanan where active='1' and rekananid not in('07')";
				conn.ExecuteQuery();
				for (int i = 0; i < conn.GetRowCount(); i++)
					DDL_JENIS_REK_COMP.Items.Add(new ListItem(conn.GetFieldValue(i,1), conn.GetFieldValue(i,0)));

			}
			else
			{	
				
				TR_COMPANY.Visible = false;
				TR_PERSONAL.Visible = true;

				DDL_JNS_REKANAN.Items.Clear();
				DDL_JNS_REKANAN.Items.Add(new ListItem("--Pilih--",""));
				conn.QueryString="select rekananid, rekanandesc from rfjenisrekanan where active='1' and rekananid in('07')";
				conn.ExecuteQuery();
				for (int i = 0; i < conn.GetRowCount(); i++)
					DDL_JNS_REKANAN.Items.Add(new ListItem(conn.GetFieldValue(i,1), conn.GetFieldValue(i,0)));
			}
		}

		protected void BTN_UPDATE_REKANAN_Click(object sender, System.EventArgs e)
		{
			string reject="0";
			conn.QueryString = "SELECT * FROM REKANAN WHERE REKANAN_REF='" + LBL_REK_REF.Text + "'";
			conn.ExecuteQuery();
			

			if(conn.GetFieldValue("REKANANTYPEID")=="01")
			{
				try
				{
					conn.QueryString = "exec REKANAN_CHECK_MANDATORY_INISIASI_COMPANY '" + Request.QueryString["regnum"] + "'";
					conn.ExecuteNonQuery();
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
			else
			{
				try
				{
					conn.QueryString = "exec REKANAN_CHECK_MANDATORY_INISIASI_PERSONAL '" + Request.QueryString["regnum"] + "'";
					conn.ExecuteNonQuery();
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

			if (RDO_RBI.SelectedValue == "1" )
			{
				conn.QueryString = "exec REKANAN_RBI_INSERT '" + 
					Request.QueryString["regnum"] + "', '" +
					Request.QueryString["rekanan_ref"] + "', '" +
					Request.QueryString["rekanan_ref"] + "C" + " ' ";				
				conn.ExecuteNonQuery();

				for (int i=0; i<DGR_QUAN.Items.Count; i++)
				{
					try
					{
						conn.QueryString = "exec REKANAN_INSERT_QUANTITATIVE_RBI '" +
							Request.QueryString["regnum"] + "', '" +
							DGR_QUAN.Items[i].Cells[0].Text.Trim() + "', '" + 
							DGR_QUAN.Items[i].Cells[1].Text.Trim() + "', '" +
							DGR_QUAN.Items[i].Cells[2].Text.Trim() + "', '" +
							tool.ConvertFloat(DGR_QUAN.Items[i].Cells[3].Text.Trim())+ "' ";
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

				for (int j=0; j<DGR_QUAL.Items.Count; j++)
				{
					try
					{
						conn.QueryString = "exec REKANAN_INSERT_QUALITATIVE_RBI '" +
							Request.QueryString["regnum"] + "', '" +
							DGR_QUAL.Items[j].Cells[0].Text.Trim() + "', '" + 
							DGR_QUAL.Items[j].Cells[1].Text.Trim() + "', '" +							
							tool.ConvertFloat(DGR_QUAL.Items[j].Cells[2].Text.Trim())+ "' ";
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

				for (int k=0; k<DGR_CLA.Items.Count; k++)
				{
					try
					{
						conn.QueryString = "exec REKANAN_INSERT_CRITE_RBI '" +
							Request.QueryString["regnum"] + "', '" +
							DGR_CLA.Items[k].Cells[0].Text.Trim() + "', '" + 
							DGR_CLA.Items[k].Cells[1].Text.Trim() + "', '" +							
							DGR_CLA.Items[k].Cells[2].Text.Trim() + "' ";
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
				
				
				conn.QueryString = "exec REKANAN_TRACKUPDATE_CBI '" + 
					Request.QueryString["regnum"] + "', 'A1.4', '" +
					Request.QueryString["rekanan_ref"] + "', '" +
					Session["UserID"].ToString() + "' ";
					
				conn.ExecuteNonQuery();
				Response.Redirect("FindCustomer.aspx?tc=" + Request.QueryString["tc"] + "&mc=" + Request.QueryString["mc"]);
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
				Response.Redirect("FindCustomer.aspx?tc=" + Request.QueryString["tc"] + "&mc=" + Request.QueryString["mc"] + "&msg=" + msg);
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

		private void cekIdentitasPerusahaan(string kodeJenisData, string rekref, string regnum, string user, string stat)
		{
			string temp			=   "";
			string jenisrek		=	DDL_JENIS_REK_COMP.SelectedValue;
			string namacomp		=	TXT_NAMA_COMP.Text;
			string sqlpar		=	rekref + "', '" +
				regnum + "', '" +
				kodeJenisData + "', '" +
				jenisrek + "', '" +
				namacomp + "', '" +
				user + "', '" +
				stat +  "' ";
			//cek field yang berubah dan masukan ke audittrail jika ada perubahan
			if(LBL_JENIS_BU.Text!=DDL_JENIS_BU.SelectedItem.Text)
			{
				temp="Jenis Badan Usaha: ";
				try
				{
					conn.QueryString = "EXEC REKANAN_AUDITTRAIL_INSERT '"+
						sqlpar + ", '" +
						temp + LBL_JENIS_BU.Text + "', '" +
						temp + DDL_JENIS_BU.SelectedItem.Text + "'"; 
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

			if(LBL_NAMA_COMP.Text!=TXT_NAMA_COMP.Text)
			{
				temp="Nama: ";
				try
				{
								 
					conn.QueryString = "EXEC REKANAN_AUDITTRAIL_INSERT '"+
						sqlpar + ", '" +
						temp + LBL_NAMA_COMP.Text + "', '" +
						temp + TXT_NAMA_COMP.Text + "' " ;
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

			if(LBL_COMP_ADD1.Text!=TXT_COMP_ADD1.Text)
			{
				temp="Alamat Kantor Pusat: ";
				try
				{
								 
					conn.QueryString = "EXEC REKANAN_AUDITTRAIL_INSERT '"+
						sqlpar + ", '" +
						temp + LBL_COMP_ADD1.Text + "', '" +
						temp + TXT_COMP_ADD1.Text + "' ";
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

			if(LBL_CITY_CAB2.Text!=DDL_CITY_CAB2.SelectedItem.Text)
			{
				temp="Wilayah: ";
				try
				{
								 
					conn.QueryString = "EXEC REKANAN_AUDITTRAIL_INSERT '"+
						sqlpar + ", '" +
						temp + LBL_CITY_CAB2.Text + "', '" +
						temp + DDL_CITY_CAB2.SelectedItem.Text + "' ";
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

			if(LBL_COMP_ZIPCODE.Text!=TXT_COMP_ZIPCODE.Text)
			{
				temp="ZIP Code: ";
				try
				{
					conn.QueryString = "EXEC REKANAN_AUDITTRAIL_INSERT '"+
						sqlpar + ", '" +
						temp + LBL_COMP_ZIPCODE.Text + "', '" +
						temp + TXT_COMP_ZIPCODE.Text + "'"; 
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

			if(LBL_COMP_AREA.Text!=TXT_COMP_AREA.Text)
			{
				temp="No. Area Telepon 1: ";
				try
				{
					conn.QueryString = "EXEC REKANAN_AUDITTRAIL_INSERT '"+
						sqlpar + ", '" +
						temp + LBL_COMP_AREA.Text + "', '" +
						temp + TXT_COMP_AREA.Text + "'"; 
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

			if(LBL_COMP_TLP.Text!=TXT_COMP_TLP.Text)
			{
				temp="No. Telepon 1: ";
				try
				{
					conn.QueryString = "EXEC REKANAN_AUDITTRAIL_INSERT '"+
						sqlpar + ", '" +
						temp + LBL_COMP_TLP.Text + "', '" +
						temp + TXT_COMP_TLP.Text + "'"; 
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

			if(LBL_COMP_AREA2.Text!=TXT_COMP_AREA2.Text)
			{
				temp="No. Area Telepon 2: ";
				try
				{
					conn.QueryString = "EXEC REKANAN_AUDITTRAIL_INSERT '"+
						sqlpar + ", '" +
						temp + LBL_COMP_AREA2.Text + "', '" +
						temp + TXT_COMP_AREA2.Text + "'"; 
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

			if(LBL_COMP_TLP2.Text!=TXT_COMP_TLP2.Text)
			{
				temp="No. Telepon 2: ";
				try
				{
					conn.QueryString = "EXEC REKANAN_AUDITTRAIL_INSERT '"+
						sqlpar + ", '" +
						temp + LBL_COMP_TLP2.Text + "', '" +
						temp + TXT_COMP_TLP2.Text + "'"; 
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

			string tgllama = tool.ConvertDate(LBL_COMP_TGL.Text, LBL_COMP_BLN.Text, LBL_COMP_THN.Text);
			string tglbaru = tool.ConvertDate(TXT_COMP_TGL.Text, DDL_COMP_BLN.SelectedValue, TXT_COMP_THN.Text);

			if(tgllama!=tglbaru)
			{	
				temp="Tgl Berdiri Perusahaan: ";
				try
				{
					conn.QueryString = "EXEC REKANAN_AUDITTRAIL_INSERT '"+
						sqlpar + ", '" +
						temp + tgllama.Replace("'","") + "', '" +
						temp + tglbaru.Replace("'","") + "'"; 
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

			if(LBL_COMP_TMP.Text!=TXT_COMP_TMP.Text)
			{
				temp="Tempat Berdiri Perusahaan: ";
				try
				{
					conn.QueryString = "EXEC REKANAN_AUDITTRAIL_INSERT '"+
						sqlpar + ", '" +
						temp + LBL_COMP_TMP.Text + "', '" +
						temp + TXT_COMP_TMP.Text + "'"; 
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

			if(LBL_COMP_FAX1.Text!=TXT_COMP_FAX1.Text)
			{
				temp="No. Area FAX1: ";
				try
				{
					conn.QueryString = "EXEC REKANAN_AUDITTRAIL_INSERT '"+
						sqlpar + ", '" +
						temp + LBL_COMP_FAX1.Text + "', '" +
						temp + TXT_COMP_FAX1.Text + "'"; 
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

			if(LBL_COMP_FAX2.Text!=TXT_COMP_FAX2.Text)
			{
				temp="No. FAX1: ";
				try
				{
					conn.QueryString = "EXEC REKANAN_AUDITTRAIL_INSERT '"+
						sqlpar + ", '" +
						temp + LBL_COMP_FAX2.Text + "', '" +
						temp + TXT_COMP_FAX2.Text + "'"; 
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

			if(LBL_COMP_FAX3.Text!=TXT_COMP_FAX3.Text)
			{
				temp="No. Area FAX2: ";
				try
				{
					conn.QueryString = "EXEC REKANAN_AUDITTRAIL_INSERT '"+
						sqlpar + ", '" +
						temp + LBL_COMP_FAX3.Text + "', '" +
						temp + TXT_COMP_FAX3.Text + "'"; 
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

			if(LBL_COMP_FAX4.Text!=TXT_COMP_FAX4.Text)
			{
				temp="No. FAX2: ";
				try
				{
					conn.QueryString = "EXEC REKANAN_AUDITTRAIL_INSERT '"+
						sqlpar + ", '" +
						temp + LBL_COMP_FAX4.Text + "', '" +
						temp + TXT_COMP_FAX4.Text + "'"; 
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


			if(LBL_COMP_NPWP.Text!=TXT_COMP_NPWP.Text)
			{
				temp="No.NPWP Perusahaan: ";
				try
				{
					conn.QueryString = "EXEC REKANAN_AUDITTRAIL_INSERT '"+
						sqlpar + ", '" +
						temp + LBL_COMP_NPWP.Text + "', '" +
						temp + TXT_COMP_NPWP.Text + "'"; 
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

			if(LBL_COMP_CPNAME.Text!=TXT_COMP_CPNAME.Text)
			{
				temp="Contact Person Name: ";
				try
				{
					conn.QueryString = "EXEC REKANAN_AUDITTRAIL_INSERT '"+
						sqlpar + ", '" +
						temp + LBL_COMP_CPNAME.Text + "', '" +
						temp + TXT_COMP_CPNAME.Text + "'"; 
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

			if(LBL_COMP_CPJBT.Text!=TXT_COMP_CPJBT.Text)
			{
				temp="Contact Person Jabatan: ";
				try
				{
					conn.QueryString = "EXEC REKANAN_AUDITTRAIL_INSERT '"+
						sqlpar + ", '" +
						temp + LBL_COMP_CPJBT.Text + "', '" +
						temp + LBL_COMP_CPJBT.Text + "'"; 
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

			if(LBL_COMP_TLPCP1.Text!=TXT_COMP_TLPCP1.Text)
			{
				temp="No. Area Telepon CP: ";
				try
				{
					conn.QueryString = "EXEC REKANAN_AUDITTRAIL_INSERT '"+
						sqlpar + ", '" +
						temp + LBL_COMP_TLPCP1.Text + "', '" +
						temp + TXT_COMP_TLPCP1.Text + "'"; 
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

			if(LBL_COMP_TLPCP2.Text!=TXT_COMP_TLPCP2.Text)
			{
				temp="No. Telepon CP: ";
				try
				{
					conn.QueryString = "EXEC REKANAN_AUDITTRAIL_INSERT '"+
						sqlpar + ", '" +
						temp + LBL_COMP_TLPCP2.Text + "', '" +
						temp + TXT_COMP_TLPCP2.Text + "'"; 
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

			string HPCPold=LBL_COMP_HPCP1.Text+LBL_COMP_CPHP2.Text;
			string HPCPnew=TXT_COMP_HPCP1.Text+TXT_COMP_CPHP2.Text;
			if(HPCPold!=HPCPnew)
			{
				temp="No. HP CP: ";
				try
				{
					conn.QueryString = "EXEC REKANAN_AUDITTRAIL_INSERT '"+
						sqlpar + ", '" +
						temp + HPCPold + "', '" +
						temp + HPCPnew + "'"; 
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

			
			//LBL_KAB_CAB2; KARENA DISABLED JADI GA DICEK
		}

		private void cekIdentitasPersonal(string kodeJenisData, string rekref, string regnum, string user, string stat)
		{
			string temp			=   "";
			string jenisrek		=	DDL_JNS_REKANAN.SelectedValue;
			string nama			=	TXT_NAMA.Text;
			string sqlpar		=	rekref + "', '" +
				regnum + "', '" +
				kodeJenisData + "', '" +
				jenisrek + "', '" +
				nama + "', '" +
				user + "', '" +
				stat +  "' ";
			//cek field yang berubah dan masukan ke audittrail jika ada perubahan
			if(LBL_TITLE.Text!=TXT_TITLE.Text)
			{
				temp="Gelar: ";
				try
				{
					conn.QueryString = "EXEC REKANAN_AUDITTRAIL_INSERT '"+
						sqlpar + ", '" +
						temp + LBL_TITLE.Text + "', '" +
						temp + TXT_TITLE.Text + "'"; 
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

			if(LBL_NAMA.Text!=TXT_NAMA.Text)
			{
				temp="Nama: ";
				try
				{
					conn.QueryString = "EXEC REKANAN_AUDITTRAIL_INSERT '"+
						sqlpar + ", '" +
						temp + LBL_NAMA.Text + "', '" +
						temp + TXT_NAMA.Text + "'"; 
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

			string tgllahirlama = tool.ConvertDate(LBL_TGL_LAHIR.Text, LBL_BLN_LAHIR.Text, LBL_THN_LAHIR.Text);
			string tgllahirbaru = tool.ConvertDate(TXT_TGL_LAHIR.Text, DDL_BLN_LAHIR.SelectedValue, TXT_THN_LAHIR.Text);

			if(tgllahirlama!=tgllahirbaru)
			{	
				temp="Tgl Lahir: ";
				try
				{
					conn.QueryString = "EXEC REKANAN_AUDITTRAIL_INSERT '"+
						sqlpar + ", '" +
						temp + tgllahirlama.Replace("'","") + "', '" +
						temp + tgllahirbaru.Replace("'","") + "'"; 
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

			if(LBL_TMP_LAHIR.Text!=TXT_TMP_LAHIR.Text)
			{
				temp="Tempat Lahir: ";
				try
				{
					conn.QueryString = "EXEC REKANAN_AUDITTRAIL_INSERT '"+
						sqlpar + ", '" +
						temp + LBL_TMP_LAHIR.Text + "', '" +
						temp + TXT_TMP_LAHIR.Text + "'"; 
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

			if(LBL_REK_ADD1.Text!=TXT_REK_ADD1.Text)
			{
				temp="Alamat: ";
				try
				{
					conn.QueryString = "EXEC REKANAN_AUDITTRAIL_INSERT '"+
						sqlpar + ", '" +
						temp + LBL_REK_ADD1.Text + "', '" +
						temp + TXT_REK_ADD1.Text + "'"; 
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

			if(LBL_ZIP_CODE.Text!=TXT_ZIP_CODE.Text)
			{
				temp="ZIPCODE: ";
				try
				{
					conn.QueryString = "EXEC REKANAN_AUDITTRAIL_INSERT '"+
						sqlpar + ", '" +
						temp + LBL_ZIP_CODE.Text + "', '" +
						temp + TXT_ZIP_CODE.Text + "'"; 
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

			if(LBL_NO_AREA.Text!=TXT_NO_AREA.Text)
			{
				temp="No. Area Telp. Kantor 1: ";
				try
				{
					conn.QueryString = "EXEC REKANAN_AUDITTRAIL_INSERT '"+
						sqlpar + ", '" +
						temp + LBL_NO_AREA.Text + "', '" +
						temp + TXT_NO_AREA.Text + "'"; 
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

			if(LBL_NO_KNTR.Text!=TXT_NO_KNTR.Text)
			{
				temp="No. Telp. Kantor 1: ";
				try
				{
					conn.QueryString = "EXEC REKANAN_AUDITTRAIL_INSERT '"+
						sqlpar + ", '" +
						temp + LBL_NO_KNTR.Text + "', '" +
						temp + TXT_NO_KNTR.Text + "'"; 
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

			if(LBL_NO_AREA2.Text!=TXT_NO_AREA2.Text)
			{
				temp="No. Area Telp. Kantor 2: ";
				try
				{
					conn.QueryString = "EXEC REKANAN_AUDITTRAIL_INSERT '"+
						sqlpar + ", '" +
						temp + LBL_NO_AREA2.Text + "', '" +
						temp + TXT_NO_AREA2.Text + "'"; 
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

			if(LBL_NO_KNTR2.Text!=TXT_NO_KNTR2.Text)
			{
				temp="No. Telp. Kantor 2: ";
				try
				{
					conn.QueryString = "EXEC REKANAN_AUDITTRAIL_INSERT '"+
						sqlpar + ", '" +
						temp + LBL_NO_KNTR2.Text + "', '" +
						temp + TXT_NO_KNTR2.Text + "'"; 
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

			if(LBL_NO_AREA_FAX.Text!=TXT_NO_AREA_FAX.Text)
			{
				temp="No. Area Fax 1: ";
				try
				{
					conn.QueryString = "EXEC REKANAN_AUDITTRAIL_INSERT '"+
						sqlpar + ", '" +
						temp + LBL_NO_AREA_FAX.Text + "', '" +
						temp + TXT_NO_AREA_FAX.Text + "'"; 
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

			if(LBL_NO_FAX.Text!=TXT_NO_FAX.Text)
			{
				temp="No. Fax 1: ";
				try
				{
					conn.QueryString = "EXEC REKANAN_AUDITTRAIL_INSERT '"+
						sqlpar + ", '" +
						temp + LBL_NO_FAX.Text + "', '" +
						temp + TXT_NO_FAX.Text + "'"; 
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

			if(LBL_NO_AREA_FAX2.Text!=TXT_NO_AREA_FAX2.Text)
			{
				temp="No. Area Fax 2: ";
				try
				{
					conn.QueryString = "EXEC REKANAN_AUDITTRAIL_INSERT '"+
						sqlpar + ", '" +
						temp + LBL_NO_AREA_FAX2.Text + "', '" +
						temp + TXT_NO_AREA_FAX2.Text + "'"; 
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

			if(LBL_NO_FAX2.Text!=TXT_NO_FAX2.Text)
			{
				temp="No. Fax 2: ";
				try
				{
					conn.QueryString = "EXEC REKANAN_AUDITTRAIL_INSERT '"+
						sqlpar + ", '" +
						temp + LBL_NO_FAX2.Text + "', '" +
						temp + TXT_NO_FAX2.Text + "'"; 
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

			if(LBL_EMAIL.Text!=TXT_EMAIL.Text)
			{
				temp="eMail: ";
				try
				{
					conn.QueryString = "EXEC REKANAN_AUDITTRAIL_INSERT '"+
						sqlpar + ", '" +
						temp + LBL_EMAIL.Text + "', '" +
						temp + TXT_EMAIL.Text + "'"; 
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

			
			string HPold=LBL_HP1.Text+LBL_HP2.Text;
			string HPnew=TXT_HP1.Text+TXT_HP2.Text;
			if(HPold!=HPnew)
			{
				temp="Mobile Phone: ";
				try
				{
					conn.QueryString = "EXEC REKANAN_AUDITTRAIL_INSERT '"+
						sqlpar + ", '" +
						temp + HPold + "', '" +
						temp + HPnew + "'"; 
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

			if(LBL_NPWP_PERSONAL.Text!=TXT_NPWP_PERSONAL.Text)
			{
				temp="NPWP: ";
				try
				{
					conn.QueryString = "EXEC REKANAN_AUDITTRAIL_INSERT '"+
						sqlpar + ", '" +
						temp + LBL_NPWP_PERSONAL.Text + "', '" +
						temp + TXT_NPWP_PERSONAL.Text + "'"; 
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

			if(LBL_NOKTP.Text!=TXT_NOKTP.Text)
			{
				temp="No. KTP: ";
				try
				{
					conn.QueryString = "EXEC REKANAN_AUDITTRAIL_INSERT '"+
						sqlpar + ", '" +
						temp + LBL_NOKTP.Text + "', '" +
						temp + TXT_NOKTP.Text + "'"; 
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

			string tglKTPlama = tool.ConvertDate(LBL_TGL_KTP.Text, LBL_BLN_KTP.Text, LBL_THN_KTP.Text);
			string tglKTPbaru = tool.ConvertDate(TXT_TGL_KTP.Text, DDL_BLN_KTP.SelectedValue, TXT_THN_KTP.Text);
			if(tgllahirlama!=tglKTPbaru)
			{	
				temp="Tgl Berakhir KTP: ";
				try
				{
					conn.QueryString = "EXEC REKANAN_AUDITTRAIL_INSERT '"+
						sqlpar + ", '" +
						temp + tglKTPlama.Replace("'","") + "', '" +
						temp + tglKTPbaru.Replace("'","") + "'"; 
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

			string tglPensiun = tool.ConvertDate(LBL_TGL_PENSIUN.Text, LBL_BLN_PENSIUN.Text, LBL_THN_PENSIUN.Text);
			string tglPensiunbaru = tool.ConvertDate(TXT_TGL_PENSIUN.Text, DDL_BLN_PENSIUN.SelectedValue, TXT_THN_PENSIUN.Text);
			if(tglPensiun!=tglPensiunbaru)
			{	
				temp="Tgl Pensiun: ";
				try
				{
					conn.QueryString = "EXEC REKANAN_AUDITTRAIL_INSERT '"+
						sqlpar + ", '" +
						temp + tglPensiun.Replace("'","") + "', '" +
						temp + tglPensiunbaru.Replace("'","") + "'"; 
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

		private void cekDoc(string kodeJenisData, string rekref, string regnum, string user, string stat)
		{
			string temp			=   "";
			string jenisrek	;
			string nama;
			if (RDO_RFCUSTOMERTYPE.SelectedValue == "01")//badan usaha
			{
				jenisrek		=	DDL_JENIS_REK_COMP.SelectedValue;
				nama			=	TXT_NAMA_COMP.Text;
			}
			else //personal
			{
				jenisrek		=	DDL_JNS_REKANAN.SelectedValue;
				nama			=	TXT_NAMA.Text;
			}		

			string sqlpar		=	rekref + "', '" +
				regnum + "', '" +
				kodeJenisData + "', '" +
				jenisrek + "', '" +
				nama + "', '" +
				user + "', '" +
				stat +  "' ";
			//cek field yang berubah dan masukan ke audittrail jika ada perubahan
			if(LBL_JNS_DOC.Text!=DDL_JNS_DOC.SelectedItem.Text)
			{
				temp="Jenis Dokumen: ";
				try
				{
					conn.QueryString = "EXEC REKANAN_AUDITTRAIL_INSERT '"+
						sqlpar + ", '" +
						temp + LBL_JNS_DOC.Text + "', '" +
						temp + DDL_JNS_DOC.SelectedItem.Text + "'"; 
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

			if(LBL_NO_DOC.Text!=TXT_NO_DOC.Text)
			{
				temp="Nomor Dokumen: ";
				try
				{
					conn.QueryString = "EXEC REKANAN_AUDITTRAIL_INSERT '"+
						sqlpar + ", '" +
						temp + LBL_NO_DOC.Text + "', '" +
						temp + TXT_NO_DOC.Text + "'"; 
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

			if(LBL_DIKELUARKAN_OLEH.Text!=TXT_DIKELUARKAN_OLEH.Text)
			{
				temp="Dikeluarkan oleh: ";
				try
				{
					conn.QueryString = "EXEC REKANAN_AUDITTRAIL_INSERT '"+
						sqlpar + ", '" +
						temp + LBL_DIKELUARKAN_OLEH.Text + "', '" +
						temp + TXT_DIKELUARKAN_OLEH.Text + "'"; 
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

			string tglDocOld = tool.ConvertDate(LBL_TGL_DOC.Text, LBL_BLN_DOC.Text, LBL_THN_DOC.Text);
			string tglDocNew = tool.ConvertDate(TXT_TGL_DOC.Text, DDL_BLN_DOC.SelectedValue, TXT_THN_DOC.Text);
			if(tglDocOld!=tglDocNew)
			{	
				temp="Tgl Dokumen: ";
				try
				{
					conn.QueryString = "EXEC REKANAN_AUDITTRAIL_INSERT '"+
						sqlpar + ", '" +
						temp + tglDocOld.Replace("'","") + "', '" +
						temp + tglDocNew.Replace("'","") + "'"; 
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

			string tglAkhirOld = tool.ConvertDate(LBL_TGLEXP_DOC.Text, LBL_BLNEXP_DOC.Text, LBL_THNEXP_DOC.Text);
			string tglAkhirNew = tool.ConvertDate(TXT_TGLEXP_DOC.Text, DDL_BLNEXP_DOC.SelectedValue, TXT_THNEXP_DOC.Text);
			if(tglAkhirOld!=tglAkhirNew)
			{	
				temp="Tgl Berakhir Dokumen: ";
				try
				{
					conn.QueryString = "EXEC REKANAN_AUDITTRAIL_INSERT '"+
						sqlpar + ", '" +
						temp + tglAkhirOld.Replace("'","") + "', '" +
						temp + tglAkhirNew.Replace("'","") + "'"; 
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

			if(LBL_NOTARIS.Text!=TXT_NOTARIS.Text)
			{
				temp="Notaris: ";
				try
				{
					conn.QueryString = "EXEC REKANAN_AUDITTRAIL_INSERT '"+
						sqlpar + ", '" +
						temp + LBL_NOTARIS.Text + "', '" +
						temp + TXT_NOTARIS.Text + "'"; 
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

			if(LBL_KAPA.Text!=TXT_KAPA.Text)
			{
				temp="KAPA: ";
				try
				{
					conn.QueryString = "EXEC REKANAN_AUDITTRAIL_INSERT '"+
						sqlpar + ", '" +
						temp + LBL_KAPA.Text + "', '" +
						temp + TXT_KAPA.Text + "'"; 
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


		private void cekDataNotaris(string kodeJenisData, string rekref, string regnum, string user, string stat)
		{
			string temp		=   "";
			string jenisrek	=	DDL_JNS_REKANAN.SelectedValue;;
			string nama		=	TXT_NAMA.Text;;
			
			string sqlpar		=	rekref + "', '" +
				regnum + "', '" +
				kodeJenisData + "', '" +
				jenisrek + "', '" +
				nama + "', '" +
				user + "', '" +
				stat +  "' ";
			

			if(LBL_SK_NOTARIS.Text!=TXT_SK_NOTARIS.Text)
			{
				temp="SK Notaris: ";
				try
				{
					conn.QueryString = "EXEC REKANAN_AUDITTRAIL_INSERT '"+
						sqlpar + ", '" +
						temp + LBL_SK_NOTARIS.Text + "', '" +
						temp + TXT_SK_NOTARIS.Text + "'"; 
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

			string tglSK = tool.ConvertDate(LBL_TGL_SK.Text, LBL_BLN_SK.Text, LBL_THN_SK.Text);
			string tglSKNew = tool.ConvertDate(TXT_TGL_SK.Text, DDL_BLN_SK.SelectedValue, TXT_THN_SK.Text);
			if(tglSK!=tglSKNew)
			{	
				temp="Tgl SK Notaris: ";
				try
				{
					conn.QueryString = "EXEC REKANAN_AUDITTRAIL_INSERT '"+
						sqlpar + ", '" +
						temp + tglSK.Replace("'","") + "', '" +
						temp + tglSKNew.Replace("'","") + "'"; 
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

			if(LBL_SUMPAH_NOTARIS.Text!=TXT_SUMPAH_NOTARIS.Text)
			{
				temp="Sumpah Notaris: ";
				try
				{
					conn.QueryString = "EXEC REKANAN_AUDITTRAIL_INSERT '"+
						sqlpar + ", '" +
						temp + LBL_SUMPAH_NOTARIS.Text + "', '" +
						temp + TXT_SUMPAH_NOTARIS.Text + "'"; 
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

			string tglSumpah = tool.ConvertDate(LBL_TGL_SUMPAH.Text, LBL_BLN_SUMPAH.Text, LBL_THN_SUMPAH.Text);
			string tglSumpahNew = tool.ConvertDate(TXT_TGL_SUMPAH.Text, DDL_BLN_SUMPAH.SelectedValue, TXT_THN_SUMPAH.Text);
			if(tglSumpah!=tglSumpahNew)
			{	
				temp="Tgl Sumpah Notaris: ";
				try
				{
					conn.QueryString = "EXEC REKANAN_AUDITTRAIL_INSERT '"+
						sqlpar + ", '" +
						temp + tglSumpah.Replace("'","") + "', '" +
						temp + tglSumpahNew.Replace("'","") + "'"; 
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

			if(LBL_KOTA_NOTARIS.Text!=TXT_KOTA_NOTARIS.Text)
			{
				temp="Kota Notaris: ";
				try
				{
					conn.QueryString = "EXEC REKANAN_AUDITTRAIL_INSERT '"+
						sqlpar + ", '" +
						temp + LBL_KOTA_NOTARIS.Text + "', '" +
						temp + TXT_KOTA_NOTARIS.Text + "'"; 
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

			if(LBL_KOPERASI.Text!=RDO_KOPERASI.SelectedItem.Text)
			{
				temp="Anggota Koperasi: ";
				try
				{
					conn.QueryString = "EXEC REKANAN_AUDITTRAIL_INSERT '"+
						sqlpar + ", '" +
						temp + LBL_KOPERASI.Text + "', '" +
						temp + RDO_KOPERASI.SelectedItem.Text + "'"; 
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

			if(LBL_NO_KOP.Text!=TXT_NO_KOP.Text)
			{
				temp="No. SK Koperasi: ";
				try
				{
					conn.QueryString = "EXEC REKANAN_AUDITTRAIL_INSERT '"+
						sqlpar + ", '" +
						temp + LBL_NO_KOP.Text + "', '" +
						temp + TXT_NO_KOP.Text + "'"; 
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

			string tglSkKop = tool.ConvertDate(LBL_TGL_KOP.Text, LBL_BLN_KOP.Text, LBL_THN_KOP.Text);
			string tglSkKopNew = tool.ConvertDate(TXT_TGL_KOP.Text, DDL_BLN_KOP.SelectedValue, TXT_THN_KOP.Text);
			if(tglSkKop!=tglSkKopNew)
			{	
				temp="Tgl SK Koperasi: ";
				try
				{
					conn.QueryString = "EXEC REKANAN_AUDITTRAIL_INSERT '"+
						sqlpar + ", '" +
						temp + tglSkKop.Replace("'","") + "', '" +
						temp + tglSkKopNew.Replace("'","") + "'"; 
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

			if(LBL_BAPEPAM.Text!=RDO_BAPEPAM.SelectedItem.Text)
			{
				temp="Terdaftar Sebagai Rekanan Bapepam: ";
				try
				{
					conn.QueryString = "EXEC REKANAN_AUDITTRAIL_INSERT '"+
						sqlpar + ", '" +
						temp + LBL_BAPEPAM.Text + "', '" +
						temp + RDO_BAPEPAM.SelectedItem.Text + "'"; 
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

			if(LBL_NO_BAPEPAM.Text!=TXT_NO_BAPEPAM.Text)
			{
				temp="No. SK Bapepam: ";
				try
				{
					conn.QueryString = "EXEC REKANAN_AUDITTRAIL_INSERT '"+
						sqlpar + ", '" +
						temp + LBL_NO_BAPEPAM.Text + "', '" +
						temp + TXT_NO_BAPEPAM.Text + "'"; 
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

			string tglSkBap = tool.ConvertDate(LBL_TGL_BAPEPAM.Text, LBL_BLN_BAPEPAM.Text, LBL_THN_BAPEPAM.Text);
			string tglSkBapNew = tool.ConvertDate(TXT_TGL_BAPEPAM.Text, DDL_BLN_BAPEPAM.SelectedValue, TXT_THN_BAPEPAM.Text);
			if(tglSkBap!=tglSkBap)
			{	
				temp="Tgl SK Bapepam: ";
				try
				{
					conn.QueryString = "EXEC REKANAN_AUDITTRAIL_INSERT '"+
						sqlpar + ", '" +
						temp + tglSkBap.Replace("'","") + "', '" +
						temp + tglSkBapNew.Replace("'","") + "'"; 
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

			if(LBL_HIGH_LIMIT.Text!=TXT_HIGH_LIMIT.Text)
			{
				temp="Limit Tertinggi: ";
				try
				{
					conn.QueryString = "EXEC REKANAN_AUDITTRAIL_INSERT '"+
						sqlpar + ", '" +
						temp + LBL_HIGH_LIMIT.Text + "', '" +
						temp + TXT_HIGH_LIMIT.Text + "'"; 
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

			if(LBL_SK_PPAT.Text!=TXT_SK_PPAT.Text)
			{
				temp="SK PPAT: ";
				try
				{
					conn.QueryString = "EXEC REKANAN_AUDITTRAIL_INSERT '"+
						sqlpar + ", '" +
						temp + LBL_SK_PPAT.Text + "', '" +
						temp + TXT_SK_PPAT.Text + "'"; 
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

			string tglPPAT = tool.ConvertDate(LBL_TGL_PPAT.Text, LBL_BLN_PPAT.Text, LBL_THN_PPAT.Text);
			string tglPPATNew = tool.ConvertDate(TXT_TGL_PPAT.Text, DDL_BLN_PPAT.SelectedValue, TXT_THN_PPAT.Text);
			if(tglPPAT!=tglPPATNew)
			{	
				temp="Tgl PPAT: ";
				try
				{
					conn.QueryString = "EXEC REKANAN_AUDITTRAIL_INSERT '"+
						sqlpar + ", '" +
						temp + tglPPAT.Replace("'","") + "', '" +
						temp + tglPPATNew.Replace("'","") + "'"; 
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

			if(LBL_SUMPAH_PPAT.Text!=TXT_SUMPAH_PPAT.Text)
			{
				temp="Sumpah PPAT: ";
				try
				{
					conn.QueryString = "EXEC REKANAN_AUDITTRAIL_INSERT '"+
						sqlpar + ", '" +
						temp + LBL_SUMPAH_PPAT.Text + "', '" +
						temp + TXT_SUMPAH_PPAT.Text + "'"; 
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

			string tglSumPAT = tool.ConvertDate(LBL_TGL_SUMPAH_PPAT.Text, LBL_BLN_SUMPAH_PPAT.Text, LBL_THN_SUMPAH_PPAT.Text);
			string tglSumPATNew = tool.ConvertDate(TXT_TGL_SUMPAH_PPAT.Text, DDL_BLN_SUMPAH_PPAT.SelectedValue, TXT_THN_SUMPAH_PPAT.Text);
			if(tglSumPAT!=tglSumPATNew)
			{	
				temp="Tgl Sumpah PPAT: ";
				try
				{
					conn.QueryString = "EXEC REKANAN_AUDITTRAIL_INSERT '"+
						sqlpar + ", '" +
						temp + tglSumPAT.Replace("'","") + "', '" +
						temp + tglSumPATNew.Replace("'","") + "'"; 
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

			if(LBL_PPAT_LOKASI.Text!=TXT_PPAT_LOKASI.Text)
			{
				temp="Wilayah Kerja PPAT: ";
				try
				{
					conn.QueryString = "EXEC REKANAN_AUDITTRAIL_INSERT '"+
						sqlpar + ", '" +
						temp + LBL_SUMPAH_PPAT.Text + "', '" +
						temp + TXT_SUMPAH_PPAT.Text + "'"; 
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

			if(LBL_IPPAT.Text!=RDO_IPPAT.SelectedItem.Text)
			{
				temp="Anggota IPPAT: ";
				try
				{
					conn.QueryString = "EXEC REKANAN_AUDITTRAIL_INSERT '"+
						sqlpar + ", '" +
						temp + LBL_IPPAT.Text + "', '" +
						temp + RDO_IPPAT.SelectedItem.Text + "'"; 
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

			if(LBL_NO_IPPAT.Text!=TXT_NO_IPPAT.Text)
			{
				temp="NO.SK IPPAT: ";
				try
				{
					conn.QueryString = "EXEC REKANAN_AUDITTRAIL_INSERT '"+
						sqlpar + ", '" +
						temp + LBL_NO_IPPAT.Text + "', '" +
						temp + TXT_NO_IPPAT.Text + "'"; 
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

			string tglSKIPPAT = tool.ConvertDate(LBL_TGL_IPPAT.Text, LBL_BLN_IPPAT.Text, LBL_THN_IPPAT.Text);
			string tglSKIPPATNew = tool.ConvertDate(TXT_TGL_IPPAT.Text, DDL_BLN_IPPAT.SelectedValue, TXT_THN_IPPAT.Text);
			if(tglSKIPPAT!=tglSKIPPATNew)
			{	
				temp="Tgl SK IPPAT: ";
				try
				{
					conn.QueryString = "EXEC REKANAN_AUDITTRAIL_INSERT '"+
						sqlpar + ", '" +
						temp + tglSKIPPAT.Replace("'","") + "', '" +
						temp + tglSKIPPATNew.Replace("'","") + "'"; 
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

			if(LBL_INI.Text!=RDO_INI.SelectedItem.Text)
			{
				temp="Anggota INI: ";
				try
				{
					conn.QueryString = "EXEC REKANAN_AUDITTRAIL_INSERT '"+
						sqlpar + ", '" +
						temp + LBL_INI.Text + "', '" +
						temp + RDO_INI.SelectedItem.Text + "'"; 
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

			if(LBL_NO_INI.Text!=TXT_NO_INI.Text)
			{
				temp="NO.SK INI: ";
				try
				{
					conn.QueryString = "EXEC REKANAN_AUDITTRAIL_INSERT '"+
						sqlpar + ", '" +
						temp + LBL_NO_INI.Text + "', '" +
						temp + TXT_NO_INI.Text + "'"; 
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

			string tglSKINI = tool.ConvertDate(LBL_TGL_INI.Text, LBL_BLN_INI.Text, LBL_THN_INI.Text);
			string tglSKININew = tool.ConvertDate(TXT_TGL_INI.Text, DDL_BLN_INI.SelectedValue, TXT_THN_INI.Text);
			if(tglSKINI!=tglSKININew)
			{	
				temp="Tgl SK INI: ";
				try
				{
					conn.QueryString = "EXEC REKANAN_AUDITTRAIL_INSERT '"+
						sqlpar + ", '" +
						temp + tglSKINI.Replace("'","") + "', '" +
						temp + tglSKININew.Replace("'","") + "'"; 
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

			if(LBL_REK_BURSA.Text!=TXT_REK_BURSA.Text)
			{
				temp="Rekanan Pasar Modal: ";
				try
				{
					conn.QueryString = "EXEC REKANAN_AUDITTRAIL_INSERT '"+
						sqlpar + ", '" +
						temp + LBL_REK_BURSA.Text + "', '" +
						temp + TXT_REK_BURSA.Text + "'"; 
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

			string tglBursa = tool.ConvertDate(LBL_TGL_BURSA.Text, LBL_BLN_BURSA.Text, LBL_THN_BURSA.Text);
			string tglBursaNew = tool.ConvertDate(TXT_TGL_BURSA.Text, DDL_BLN_BURSA.SelectedValue, TXT_THN_BURSA.Text);
			if(tglBursa!=tglBursaNew)
			{	
				temp="Tgl Rekanan Pasar Modal: ";
				try
				{
					conn.QueryString = "EXEC REKANAN_AUDITTRAIL_INSERT '"+
						sqlpar + ", '" +
						temp + tglBursa.Replace("'","") + "', '" +
						temp + tglBursaNew.Replace("'","") + "'"; 
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

			if(LBL_REMARK.Text!=TXT_REMARK.Text)
			{
				temp="Remark: ";
				try
				{
					conn.QueryString = "EXEC REKANAN_AUDITTRAIL_INSERT '"+
						sqlpar + ", '" +
						temp + LBL_REMARK.Text + "', '" +
						temp + TXT_REMARK.Text + "'"; 
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

		private void AuditTrailCheck(string kodeJenisData)
		{
			string userName		= Session["FullName"].ToString();
			string status		= "update";
			string rekanan_ref	= Request.QueryString["rekanan_ref"];
			string regnum		= Request.QueryString["regnum"];			

			switch(kodeJenisData)
			{
				case "11"://identitas_Rekanan
					if (RDO_RFCUSTOMERTYPE.SelectedValue == "01")//badan usaha
					{
						cekIdentitasPerusahaan(kodeJenisData, rekanan_ref, regnum, userName, status);
					}
					else //personal
					{
						cekIdentitasPersonal(kodeJenisData, rekanan_ref, regnum, userName, status);
					}		
					break;
				case "12": 
					cekDoc(kodeJenisData, rekanan_ref, regnum, userName, status);
					break;
				case "13":
					cekDataNotaris(kodeJenisData, rekanan_ref, regnum, userName, status);
					break;
			}
		}

		//		private void CekSubHalaman1(Control parentControl, string kodeJenisData, string namarekanan, string jenisrek)
		//		{
		//			//TR_PERSONAL
		//			string userName		= Session["FullName"].ToString();
		//			string status		= "update";
		//			string rekanan_ref	= Request.QueryString["rekanan_ref"];
		//			string regnum		= Request.QueryString["regnum"];
		//			string sqlpar		=	rekanan_ref + "', '" +
		//				regnum + "', '" +
		//				kodeJenisData + "', '" +
		//				jenisrek + "', '" +
		//				namarekanan + "', '" +
		//				userName + "', '" +
		//				status +  "' ";
		//
		//			string controlID = "";
		//			string labelID = "";
		//
		//			TextBox txtBox;
		//			DropDownList ddlList;
		//			RadioButtonList rdbList;
		//			Control tempControl;
		//			Label lbl;
		//
		//			foreach(Control ctrl2 in parentControl.Controls)
		//			{
		//				if(ctrl2.Controls.Count != 0)
		//				{
		//					CekSubHalaman1(ctrl2, kodeJenisData, namarekanan, jenisrek);	
		//				}
		//				else
		//				{
		////					controlID = ctrl2.ID.ToString();
		////					string ctrlSub = controlID.Substring(4,3);
		////					if ((ctrlSub=="TGL")|| (ctrlSub=="BLN") || (ctrlSub=="THN"))
		////					{
		////						controlID = ctrl2.ID.ToString();
		////						string sub = controlID.Substring(7);
		////						Label lbltgl = (Label) this.FindControl("LBL_TGL_"+ sub);
		////						Label lblbln = (Label) this.FindControl("LBL_BLN_"+ sub);
		////						Label lblthn = (Label) this.FindControl("LBL_THN_"+ sub);
		////						TextBox tgl  = (TextBox) this.FindControl("TXT_TGL" + sub);
		////						DropDownList bln = (DropDownList) this.FindControl("DDL_BLN" + sub);
		////						TextBox thn  = (TextBox) this.FindControl("TXT_THN" + sub);
		////						string tgllama = tool.ConvertDate(lbltgl.Text, lblbln.Text, lblthn.Text);
		////						string tglbaru = tool.ConvertDate(tgl.Text, bln.SelectedValue, thn.Text);
		////
		////						if(tgllama!=tglbaru)
		////						{	
		////							string temp="TGL " + sub + ": ";
		////							try
		////							{
		////								conn.QueryString = "EXEC REKANAN_AUDITTRAIL_INSERT '"+
		////									sqlpar + ", '" +
		////									temp + tgllama.Replace("'","") + "', '" +
		////									temp + tglbaru.Replace("'","") + "'"; 
		////								conn.ExecuteNonQuery(); 
		////							}
		////							catch (Exception ex)
		////							{
		////								string errmsg = ex.Message.Replace("'","");
		////								if (errmsg.IndexOf("Last Query:") > 0)
		////									errmsg = errmsg.Substring(0, errmsg.IndexOf("Last Query:"));
		////								GlobalTools.popMessage(this, errmsg);
		////								return;
		////							}	
		////						}
		////
		////
		////
		////					}
		//
		//					if(ctrl2 is DropDownList)
		//					{
		//						controlID = ctrl2.ID.ToString();
		//					}
		//					else if(ctrl2 is TextBox)
		//					{
		//						controlID = ctrl2.ID.ToString();
		//						//LBL_TITLE
		//						labelID = controlID.Replace("TXT","LBL");
		//						txtBox = (TextBox)ctrl2;
		//						tempControl = this.FindControl(labelID);
		//						lbl = (Label)tempControl;
		//
		//						if(txtBox.Text != lbl.Text)
		//						{
		//							string namaField = lbl.ID.Replace("_"," ");
		//							//insert(namaField, lbl.Text, txtBox.Text );
		//						}
		//					}
		//					else if(ctrl2 is RadioButtonList)
		//					{
		//						controlID = ctrl2.ID.ToString();
		//					}
		//				}
		//			}
		//		}Ga diterusin karena ga ngerti

		protected void BTN_SAVE_REKANAN_Click(object sender, System.EventArgs e)
		{
			//			Control TableRow = this.FindControl("TR_PERSONAL");
			//			CekSubHalaman1(TableRow,"11", TXT_NAMA.Text, DDL_JNS_REKANAN.SelectedValue);

			string rekanan_ref = LBL_REK_REF.Text;
			Int64 now = Int64.Parse(Tools.toISODate(DateTime.Now.Day.ToString(), DateTime.Now.Month.ToString(), DateTime.Now.Year.ToString())), compEstablish;
			
			/* Check Existing Customer or Not */
			if (Request.QueryString["exist"] == "0")
			{
				if (RDO_RFCUSTOMERTYPE.SelectedValue == "01")
				{
					conn.QueryString = "select count (*) from vw_rekanan_company where id_number = '" + TXT_COMP_NPWP.Text + "' and rekanan_ref <> '" + rekanan_ref + "'";
					conn.ExecuteQuery();
					if (conn.GetFieldValue(0,0) != "0")
					{
						GlobalTools.popMessage(this, "Rekanan with NPWP: " + TXT_COMP_NPWP.Text + " exists in the system!");
						return;
					}
				}
				else
				{
					string TGL_KTP = GlobalTools.ToSQLDate(TXT_TGL_KTP.Text.Trim(), DDL_BLN_KTP.SelectedValue, TXT_THN_KTP.Text.Trim());										
					conn.QueryString = "select count (*) from vw_rekanan_personal where id_number='" + TXT_NOKTP.Text + "' and KTP_DATE = " + TGL_KTP + " and rekanan_ref <> '" + rekanan_ref + "'";
					//----------------------------------
					conn.ExecuteQuery();
					if (conn.GetFieldValue(0,0) != "0")
					{
						GlobalTools.popMessage(this, "Customer with KTP: " + TXT_NOKTP.Text + " and Expire Date: " + TGL_KTP.Replace("'","") + " exists in the system!");
						return;
					}
				}
			}

			/////////////////////////////////////////////////////////////////////
			///	BADAN USAHA
			///	
			if (RDO_RFCUSTOMERTYPE.SelectedValue == "01")	// badan usaha
			{
				//Validasi Jenis Rekanan
				if (DDL_JENIS_BU.SelectedValue == "")
				{
					GlobalTools.popMessage(this, "Isi terlebih dahulu Jenis Rekanan!");
					return;	
				}
				
				////////////////////////////////////////////////////////////
				///	VALIDASI BERDIRI SEJAK
				///	
				try 
				{
					compEstablish = Int64.Parse(Tools.toISODate(TXT_COMP_TGL.Text, DDL_COMP_BLN.SelectedValue, TXT_COMP_THN.Text));
				} 
				catch 
				{
					GlobalTools.popMessage(this, "Tanggal berdiri perusahaan tidak valid!");
					return;
				}
				if (compEstablish > now)
				{
					GlobalTools.popMessage(this, "Tanggal berdiri perusahaan tidak boleh lebih dari tanggal sekarang!");
					return;
				}

				//-----penambahan pengecekan untuk audittrail oleh Ariel
				if (Request.QueryString["exist"] == "1")
				{	
					AuditTrailCheck("11");//identitas_Rekanan					
				}
				//-----


				try
				{
					conn.QueryString = "exec IDE_REKANAN_COMP_INSERT '" +
						Request.QueryString["rekanan_ref"] + "', '" +
						Request.QueryString["regnum"] + "', '" +
						RDO_RFCUSTOMERTYPE.SelectedValue + "', '" +
						DDL_JENIS_REK_COMP.SelectedValue + "', '" +
						TXT_NAMA_COMP.Text + "', '" +
						TXT_COMP_ADD1.Text + "', '" +
						DDL_CITY_CAB2.SelectedValue + "', '" +
						DDL_KAB_CAB2.SelectedValue + "', '" +
						TXT_COMP_ZIPCODE.Text + "', '" +
						DDL_JENIS_BU.SelectedValue + "', '" +
						TXT_COMP_AREA.Text + "', '" +
						TXT_COMP_TLP.Text + "', '" +
						TXT_COMP_AREA2.Text + "', '" +
						TXT_COMP_TLP2.Text + "', " +
						tool.ConvertDate(TXT_COMP_TGL.Text, DDL_COMP_BLN.SelectedValue, TXT_COMP_THN.Text) + ", '" +
						TXT_COMP_TMP.Text + "', '" +
						TXT_COMP_FAX1.Text + "', '" +
						TXT_COMP_FAX2.Text + "', '" +
						TXT_COMP_FAX3.Text + "', '" +
						TXT_COMP_FAX4.Text + "', '" +
						TXT_COMP_NPWP.Text + "', '" +
						TXT_COMP_CPNAME.Text + "', '" +
						TXT_COMP_CPJBT.Text + "', '" +
						TXT_COMP_TLPCP1.Text + "', '" +
						TXT_COMP_TLPCP2.Text + "', '" +
						TXT_COMP_HPCP1.Text + "', '" +
						TXT_COMP_CPHP2.Text + "', '" +
						Session["AreaID"].ToString() + "', '" +
						Session["BranchID"].ToString() + "', '" +
						Session["UserID"].ToString() + "', '" +
						RDO_MERANGKAP_KM.SelectedValue + "'"; 
					conn.ExecuteNonQuery();
				} 
				catch (NullReferenceException)
				{
					GlobalTools.popMessage(this, "Connection Error!");
					Response.Redirect("../../Login.aspx?expire=1");
				}

			}
				///////////////////////////////////////////////////////////////////////
				/// PERORANGAN
				/// 
			else
			{
				//Validasi Jenis Rekanan
				if (DDL_JNS_REKANAN.SelectedValue == "")
				{
					GlobalTools.popMessage(this, "Isi terlebih dahulu Jenis Rekanan!");
					return;	
				}
				//////////////////////////////////////////////////////////////////
				/// VALIDASI TANGGAL LAHIR
				/// 
				if (!GlobalTools.isDateValid(TXT_TGL_LAHIR.Text, DDL_BLN_LAHIR.SelectedValue, TXT_THN_LAHIR.Text)) 
				{
					GlobalTools.popMessage(this, "Tanggal Lahir tidak valid!");
					return;
				}
				else 
				{
					Int64 tanggalLahir;
					tanggalLahir = Int64.Parse(Tools.toISODate(TXT_TGL_LAHIR.Text, DDL_BLN_LAHIR.SelectedValue, TXT_THN_LAHIR.Text));

					if (tanggalLahir > now) 
					{
						GlobalTools.popMessage(this, "Tanggal Lahir tidak bisa lebih dari tanggal sekarang!!");
						return;
					}
				}

				////////////////////////////////////////////////////////////////////
				///	VALIDASI TANGGAL BERAKHIR KTP
				///	
				if (!GlobalTools.isDateValid(TXT_TGL_KTP.Text, DDL_BLN_KTP.SelectedValue, TXT_THN_KTP.Text)) 
				{
					GlobalTools.popMessage(this, "Tanggal Berakhir KTP tidak valid!");
					return;
				}

				int banding = Tools.compareDate(DateTime.Now.Day.ToString(), DateTime.Now.Month.ToString(), DateTime.Now.Year.ToString(), TXT_TGL_KTP.Text, DDL_BLN_KTP.SelectedValue, TXT_THN_KTP.Text);
				if (banding >= 0) 
				{
					GlobalTools.popMessage(this, "Tanggal Berakhir KTP tidak boleh kurang dari tanggal sekarang!");
					return;
				}

				////////////////////////////////////////////////////////////////////
				///	VALIDASI TANGGAL PENSIUN
				///	
				if (!GlobalTools.isDateValid(TXT_TGL_PENSIUN.Text, DDL_BLN_PENSIUN.SelectedValue, TXT_THN_PENSIUN.Text)) 
				{
					GlobalTools.popMessage(this, "Tanggal Pensiun tidak valid!");
					return;
				}

				int banding2 = Tools.compareDate(DateTime.Now.Day.ToString(), DateTime.Now.Month.ToString(), DateTime.Now.Year.ToString(), TXT_TGL_PENSIUN.Text, DDL_BLN_PENSIUN.SelectedValue, TXT_THN_PENSIUN.Text);
				if (banding2 >= 0) 
				{
					GlobalTools.popMessage(this, "Tanggal Pensiun tidak boleh kurang dari tanggal sekarang!");
					return;
				}

				//-----penambahan pengecekan untuk audittrail oleh Ariel
				if (Request.QueryString["exist"] == "1")
				{	
					AuditTrailCheck("11");//identitas_Rekanan					
				}
				//-----

				try
				{
					conn.QueryString = "exec IDE_REKANAN_PERSONAL_INSERT '" +
						Request.QueryString["rekanan_ref"] + "', '" +
						Request.QueryString["regnum"] + "', '" +
						RDO_RFCUSTOMERTYPE.SelectedValue + "', '" +
						DDL_JNS_REKANAN.SelectedValue + "', '" +
						TXT_NAMA.Text + "', '" +
						TXT_REK_ADD1.Text + "', '" +
						DDL_CITY_CAB.SelectedValue + "', '" +
						DDL_KAB_CAB.SelectedValue + "', '" +
						TXT_ZIP_CODE.Text + "', '" +
						TXT_TITLE.Text + "', " +
						tool.ConvertDate(TXT_TGL_LAHIR.Text, DDL_BLN_LAHIR.SelectedValue, TXT_THN_LAHIR.Text) + ", '" +
						TXT_TMP_LAHIR.Text + "', '" +
						TXT_NO_AREA.Text + "', '" +
						TXT_NO_KNTR.Text + "', '" +
						TXT_NO_AREA2.Text + "', '" +
						TXT_NO_KNTR2.Text + "', '" +
						TXT_NO_AREA_FAX.Text + "', '" +
						TXT_NO_FAX.Text + "', '" +
						TXT_NO_AREA_FAX2.Text + "', '" +
						TXT_NO_FAX2.Text + "', '" +
						TXT_EMAIL.Text + "', '" +
						TXT_HP1.Text + "', '" +
						TXT_HP2.Text + "', '" +
						TXT_NPWP_PERSONAL.Text + "', '" +
						TXT_NOKTP.Text + "', " +
						tool.ConvertDate(TXT_TGL_KTP.Text, DDL_BLN_KTP.SelectedValue, TXT_THN_KTP.Text) + ", " +
						tool.ConvertDate(TXT_TGL_PENSIUN.Text, DDL_BLN_PENSIUN.SelectedValue, TXT_THN_PENSIUN.Text) + ", '" +
						Session["AreaID"].ToString() + "', '" +
						Session["BranchID"].ToString() + "', '" +
						Session["UserID"].ToString() + "', '" +
						RDO_MERANGKAP_KM.SelectedValue + "'"; 
					conn.ExecuteNonQuery();

				}
				catch
				{
					GlobalTools.popMessage(this, "Connection Error!");
					Response.Redirect("../../Login.aspx?expire=1");
				}

			}
			CekTrack();
			ViewData();
			
			string reject="0";
			conn.QueryString = "SELECT * FROM REKANAN WHERE REKANAN_REF='" + LBL_REK_REF.Text + "'";
			conn.ExecuteQuery();
			

			if(conn.GetFieldValue("REKANANTYPEID")=="01")
			{
				try
				{
					conn.QueryString = "exec REKANAN_CHECK_MANDATORY_INISIASI_COMPANY '" + Request.QueryString["regnum"] + "'";
					conn.ExecuteNonQuery();
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
			else
			{
				try
				{
					conn.QueryString = "exec REKANAN_CHECK_MANDATORY_INISIASI_PERSONAL '" + Request.QueryString["regnum"] + "'";
					conn.ExecuteNonQuery();
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
		}
		
		private void DatGridDoc_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			DatGridDoc.CurrentPageIndex = e.NewPageIndex;
			ViewDoc();
		}

		private void ViewDoc()
		{
			conn.QueryString = "select * from vw_rekanan_doc where rekanan_ref='" + Request.QueryString["rekanan_ref"] + "'";
			conn.ExecuteQuery();
			FillDocGrid();
		}

		private void DatGridDoc_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			switch (((LinkButton)e.CommandSource).CommandName)
			{
				case "delete_doc":
					conn.QueryString = "delete from rekanan_doc where rekanan_ref='" + Request.QueryString["rekanan_ref"] + "' and SEQ=" + Convert.ToInt32(e.Item.Cells[0].Text) + "";
					conn.ExecuteQuery();
					
					FillDocGrid();
					ViewDoc();
					break;
				case "edit_doc":
					BTN_UPDATE.Visible=true;
					BTN_INSERT.Visible=false;
					conn.QueryString = "select * from rekanan_doc where rekanan_ref='" + Request.QueryString["rekanan_ref"] + "' and SEQ=" + Convert.ToInt32(e.Item.Cells[0].Text) + "";
					conn.ExecuteQuery();

					seq = Convert.ToInt32(conn.GetFieldValue("SEQ"));
					//Penambahan label2 untuk keperluan audittrail oleh ARIEL
					try
					{
						DDL_JNS_DOC.SelectedValue = conn.GetFieldValue("rfdoc");
						LBL_JNS_DOC.Text = DDL_JNS_DOC.SelectedItem.Text;
					}
					catch{DDL_JNS_DOC.SelectedValue = "";}

					TXT_NO_DOC.Text = conn.GetFieldValue("DOC#");
					LBL_NO_DOC.Text = conn.GetFieldValue("DOC#");

					TXT_DIKELUARKAN_OLEH.Text = conn.GetFieldValue("DOC_FROM");
					LBL_DIKELUARKAN_OLEH.Text = conn.GetFieldValue("DOC_FROM");

					TXT_TGL_DOC.Text = tool.FormatDate_Day(conn.GetFieldValue("DOC_DATE"));
					LBL_TGL_DOC.Text = tool.FormatDate_Day(conn.GetFieldValue("DOC_DATE"));

					try
					{ 
						DDL_BLN_DOC.SelectedValue = tool.FormatDate_Month(conn.GetFieldValue("DOC_DATE"));
						LBL_BLN_DOC.Text = DDL_BLN_DOC.SelectedValue;
					}
					catch{DDL_BLN_DOC.SelectedValue = "";}

					TXT_THN_DOC.Text = tool.FormatDate_Year(conn.GetFieldValue("DOC_DATE"));
					LBL_THN_DOC.Text = tool.FormatDate_Year(conn.GetFieldValue("DOC_DATE"));

					TXT_TGLEXP_DOC.Text = tool.FormatDate_Day(conn.GetFieldValue("DOC_END"));
					LBL_TGLEXP_DOC.Text = tool.FormatDate_Day(conn.GetFieldValue("DOC_END"));

					try
					{
						DDL_BLNEXP_DOC.SelectedValue = tool.FormatDate_Month(conn.GetFieldValue("DOC_END"));
						LBL_BLNEXP_DOC.Text = DDL_BLNEXP_DOC.SelectedValue;
					}
					catch{ DDL_BLNEXP_DOC.SelectedValue = "";}

					TXT_THNEXP_DOC.Text = tool.FormatDate_Year(conn.GetFieldValue("DOC_END"));
					LBL_THNEXP_DOC.Text = tool.FormatDate_Year(conn.GetFieldValue("DOC_END"));

					TXT_NOTARIS.Text = conn.GetFieldValue("NOTARIS");
					LBL_NOTARIS.Text = conn.GetFieldValue("NOTARIS");

					TXT_SEQ.Text = conn.GetFieldValue("SEQ");
					TXT_KAPA.Text = conn.GetFieldValue("KAPA");
					LBL_KAPA.Text = conn.GetFieldValue("KAPA");
					ViewDoc();
					break;
			}
		
		}

		protected void BTN_INSERT_Click(object sender, System.EventArgs e)
		{

			Int64 now = Int64.Parse(Tools.toISODate(DateTime.Now.Day.ToString(), DateTime.Now.Month.ToString(), DateTime.Now.Year.ToString())), DocExp, DocDate;
			
			//--VALIDASI TANGGAL DOKUMEN--//
			try 
			{
				DocDate = Int64.Parse(Tools.toISODate(TXT_TGL_DOC.Text, DDL_BLN_DOC.SelectedValue, TXT_THN_DOC.Text));
			} 
			catch 
			{
				GlobalTools.popMessage(this, "Tanggal Dokumen tidak valid!");
				return;
			}
			if (DocDate > now)
			{
				GlobalTools.popMessage(this, "Tanggal Dokumen tidak boleh lebih dari tanggal sekarang!");
				return;
			}

			//--VALIDASI DOKUMEN EXP--//				
			int banding = Tools.compareDate(DateTime.Now.Day.ToString(), DateTime.Now.Month.ToString(), DateTime.Now.Year.ToString(), TXT_TGLEXP_DOC.Text, DDL_BLNEXP_DOC.SelectedValue, TXT_THNEXP_DOC.Text);
			if (banding >= 0) 
			{
				GlobalTools.popMessage(this, "Tanggal berakhir dokumen tidak boleh kurang dari atau sama dengan tanggal sekarang!");
				return;
			}

			try
			{
				conn.QueryString = "exec REKANAN_DOC_INSERT2 '" +
					Request.QueryString["rekanan_ref"] + "', '" +
					DDL_JNS_DOC.SelectedValue + "', '" +
					TXT_NO_DOC.Text + "', '" +
					TXT_DIKELUARKAN_OLEH.Text + "', " +
					tool.ConvertDate(TXT_TGL_DOC.Text, DDL_BLN_DOC.SelectedValue, TXT_THN_DOC.Text) + ", " +
					tool.ConvertDate(TXT_TGLEXP_DOC.Text, DDL_BLNEXP_DOC.SelectedValue, TXT_THNEXP_DOC.Text) + ", '" +
					TXT_NOTARIS.Text + "', '" +
					TXT_KAPA.Text + "'";
				conn.ExecuteNonQuery();
			}
			catch
			{
				GlobalTools.popMessage(this, "Connection Error!");
				Response.Redirect("../../Login.aspx?expire=1");
			}
			
			ViewDoc();
			ClearData();
		}

		protected void BTN_UPDATE_Click(object sender, System.EventArgs e)
		{
			//-----penambahan pengecekan untuk audittrail oleh Ariel
				
			AuditTrailCheck("12");//doc				
			
			//-----

			try
			{
				conn.QueryString = "exec REKANAN_DOC_UPDATE " +
					Convert.ToUInt32(TXT_SEQ.Text) + ", '" + Request.QueryString["rekanan_ref"] + "', '" +
					DDL_JNS_DOC.SelectedValue + "', '" +
					TXT_NO_DOC.Text + "', '" +
					TXT_DIKELUARKAN_OLEH.Text + "', " +
					tool.ConvertDate(TXT_TGL_DOC.Text, DDL_BLN_DOC.SelectedValue, TXT_THN_DOC.Text) + ", " +
					tool.ConvertDate(TXT_TGLEXP_DOC.Text, DDL_BLNEXP_DOC.SelectedValue, TXT_THNEXP_DOC.Text) + ", '" +
					TXT_NOTARIS.Text + "', '" +
					TXT_KAPA.Text + "'";
				conn.ExecuteNonQuery();
			}
			catch
			{
				GlobalTools.popMessage(this, "Connection Error!");
				Response.Redirect("../../Login.aspx?expire=1");
			}
			ViewDoc();
			BTN_UPDATE.Visible = false;
			BTN_INSERT.Visible = true;
			ClearData();
		}

		protected void BTN_CLEAR_Click(object sender, System.EventArgs e)
		{
			ClearData();
		}

		private void ClearData()
		{
			DDL_JNS_DOC.SelectedValue = "";
			TXT_NO_DOC.Text="";
			TXT_DIKELUARKAN_OLEH.Text="";
			TXT_TGL_DOC.Text="";
			DDL_BLN_DOC.SelectedValue="";
			TXT_THN_DOC.Text="";
			TXT_TGLEXP_DOC.Text="";
			DDL_BLNEXP_DOC.SelectedValue="";
			TXT_THNEXP_DOC.Text="";
			TXT_NOTARIS.Text="";
			TXT_KAPA.Text="";
		}

		

		private void CekRekananPersonal()
		{
			if(DDL_JNS_REKANAN.SelectedValue=="07")
				TR_NOTARIS.Visible=true;
			else
				TR_NOTARIS.Visible=false;

			if(DDL_JNS_REKANAN.SelectedValue=="01" || DDL_JENIS_REK_COMP.SelectedValue=="02")
			{
				TR_RANGKAP_KM.Visible=true;
				TR_KAPA.Visible=true;
			}
			else 
			{
				TR_RANGKAP_KM.Visible=false;
				RDO_MERANGKAP_KM.SelectedValue="0";
				TR_KAPA.Visible=false;
			}
		}

		private void CekSyarat()
		{			
			string view = Request.QueryString["view"];
			string mc2 = Request.QueryString["mc2"];
			if(Request.QueryString["view"]!="1" && Request.QueryString["mc2"] == null)
			{
				if (RDO_RFCUSTOMERTYPE.SelectedValue=="01")
				{
					SYARAT_TYPEIDE.Text= DDL_JENIS_REK_COMP.SelectedValue ;
					if (SYARAT_TYPEIDE.Text!= "")
						Response.Write("<script for=window event=onload language='javascript'>PopupPage('../RekananPersyaratan.aspx?rekanantypeid=" + SYARAT_TYPEIDE.Text + "&theForm=Form1&theObj=TXT_TEMP', '800','650');</script>");
				}
			
				else if (RDO_RFCUSTOMERTYPE.SelectedValue=="02")
			
				{
					SYARAT_TYPEIDE.Text=DDL_JNS_REKANAN.SelectedValue ;
					if (SYARAT_TYPEIDE.Text!= "")
						Response.Write("<script for=window event=onload language='javascript'>PopupPage('../RekananPersyaratan.aspx?rekanantypeid=" + SYARAT_TYPEIDE.Text + "&theForm=Form1&theObj=TXT_TEMP', '800','650');</script>");
				}
			}
			
		}

		private void CekRekananComp()
		{ 
			if(DDL_JENIS_REK_COMP.SelectedValue=="07")
				TR_NOTARIS.Visible=true;
			else
				TR_NOTARIS.Visible=false;
				
			if(DDL_JENIS_REK_COMP.SelectedValue=="01" || DDL_JENIS_REK_COMP.SelectedValue=="02")
			{
				TR_RANGKAP_KM.Visible=true;
				TR_KAPA.Visible=true;
			}
			else
			{
				TR_RANGKAP_KM.Visible=false;
				RDO_MERANGKAP_KM.SelectedValue="0";
				TR_KAPA.Visible=false;
			}
		}

		protected void DDL_JNS_REKANAN_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			CekRekananPersonal();
			CekSyarat();
			CekDocType(DDL_JNS_REKANAN.SelectedValue);
		}

		protected void DDL_JENIS_REK_COMP_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			CekRekananComp();
			CekSyarat();
			CekDocType(DDL_JENIS_REK_COMP.SelectedValue);
		}

		private void CekDocType(string rekanan_id)
		{
			DDL_JNS_DOC.Items.Clear();
			DDL_JNS_DOC.Items.Add(new ListItem("--Pilih--",""));
			conn.QueryString = "select doc_id, doc_desc from rekanan_rfdoctype where rekanan_id='" + rekanan_id + "'";
			conn.ExecuteQuery();
			
			for (int i=0; i<conn.GetRowCount(); i++)
			{
				DDL_JNS_DOC.Items.Add(new ListItem(conn.GetFieldValue(i,1),conn.GetFieldValue(i,0)));
			}
		}

		private void CekKoperasi()
		{
			if(RDO_KOPERASI.SelectedValue=="Y")
			{
				TXT_NO_KOP.Enabled=true;
				TXT_TGL_KOP.Enabled=true;
				DDL_BLN_KOP.Enabled=true;
				TXT_THN_KOP.Enabled=true;
			}
			else
			{
				TXT_NO_KOP.Enabled=false;
				TXT_TGL_KOP.Enabled=false;
				DDL_BLN_KOP.Enabled=false;
				TXT_THN_KOP.Enabled=false;

				TXT_NO_KOP.Text="";
				TXT_TGL_KOP.Text="";
				DDL_BLN_KOP.SelectedValue="";
				TXT_THN_KOP.Text="";
			}
		}

		protected void RDO_KOPERASI_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			CekKoperasi();
		}

		private void CekBapepam()
		{
			if(RDO_BAPEPAM.SelectedValue=="Y")
			{
				TXT_NO_BAPEPAM.Enabled=true;
				TXT_TGL_BAPEPAM.Enabled=true;
				DDL_BLN_BAPEPAM.Enabled=true;
				TXT_THN_BAPEPAM.Enabled=true;
			}
			else
			{
				TXT_NO_BAPEPAM.Enabled=false;
				TXT_TGL_BAPEPAM.Enabled=false;
				DDL_BLN_BAPEPAM.Enabled=false;
				TXT_THN_BAPEPAM.Enabled=false;

				TXT_NO_BAPEPAM.Text="";
				TXT_TGL_BAPEPAM.Text="";
				DDL_BLN_BAPEPAM.SelectedValue="";
				TXT_THN_BAPEPAM.Text="";
			}
		}

		protected void RDO_BAPEPAM_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			CekBapepam();
		}

		private void CekINI()
		{
			if(RDO_INI.SelectedValue=="Y")
			{
				TXT_NO_INI.Enabled=true;
				TXT_TGL_INI.Enabled=true;
				DDL_BLN_INI.Enabled=true;
				TXT_THN_INI.Enabled=true;
			}
			else
			{
				TXT_NO_INI.Enabled=false;
				TXT_TGL_INI.Enabled=false;
				DDL_BLN_INI.Enabled=false;
				TXT_THN_INI.Enabled=false;

				TXT_NO_INI.Text="";
				TXT_TGL_INI.Text="";
				DDL_BLN_INI.SelectedValue="";
				TXT_THN_INI.Text="";
			}
		}

		private void CekIPPAT()
		{
			if(RDO_IPPAT.SelectedValue=="Y")
			{
				TXT_NO_IPPAT.Enabled=true;
				TXT_TGL_IPPAT.Enabled=true;
				DDL_BLN_IPPAT.Enabled=true;
				TXT_THN_IPPAT.Enabled=true;
			}
			else
			{
				TXT_NO_IPPAT.Enabled=false;
				TXT_TGL_IPPAT.Enabled=false;
				DDL_BLN_IPPAT.Enabled=false;
				TXT_THN_IPPAT.Enabled=false;

				TXT_NO_IPPAT.Text="";
				TXT_TGL_IPPAT.Text="";
				DDL_BLN_IPPAT.SelectedValue="";
				TXT_THN_IPPAT.Text="";
			}
		}

		protected void RDO_INI_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			CekINI();
		}

		protected void RDO_IPPAT_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			CekIPPAT();
		}

		protected void BTN_SAVE_NOTARIS_Click(object sender, System.EventArgs e)
		{
			Int64 now = Int64.Parse(Tools.toISODate(DateTime.Now.Day.ToString(), DateTime.Now.Month.ToString(), DateTime.Now.Year.ToString())), BursaDate, SKDate, PPATDate, SumpahDate, KoperasiDate, BapepamDate, SumpahPPATDate, INIDate, IPPATDate;
			
			//--VALIDASI TANGGAL REKENING PASAR MODAL--//
			/*try 
			{
				BursaDate = Int64.Parse(Tools.toISODate(TXT_TGL_BURSA.Text, DDL_BLN_BURSA.SelectedValue, TXT_THN_BURSA.Text));
			} 
			catch 
			{
				GlobalTools.popMessage(this, "Tanggal rekanan pasar modal tidak valid!");
				return;
			}
			if (BursaDate > now)
			{
				GlobalTools.popMessage(this, "Tanggal rekanan pasar modal tidak boleh lebih dari tanggal hari ini!");
				return;
			}*/
			
			//--VALIDASI TANGGAL SK NOTARIS--//
			try 
			{
				SKDate = Int64.Parse(Tools.toISODate(TXT_TGL_SK.Text, DDL_BLN_SK.SelectedValue, TXT_THN_SK.Text));
			} 
			catch 
			{
				GlobalTools.popMessage(this, "Tanggal SK notaris tidak valid!");
				return;
			}
			if (SKDate > now)
			{
				GlobalTools.popMessage(this, "Tanggal SK notaris tidak boleh lebih dari tanggal hari ini!");
				return;
			}

			//--VALIDASI TANGGAL PPAT--//
			try 
			{
				PPATDate = Int64.Parse(Tools.toISODate(TXT_TGL_PPAT.Text, DDL_BLN_PPAT.SelectedValue, TXT_THN_PPAT.Text));
			} 
			catch 
			{
				GlobalTools.popMessage(this, "Tanggal PPAT tidak valid!");
				return;
			}
			if (PPATDate > now)
			{
				GlobalTools.popMessage(this, "Tanggal PPAT tidak boleh lebih dari tanggal hari ini!");
				return;
			}

			//--VALIDASI TANGGAL SK KOPERASI--//
			if(RDO_KOPERASI.SelectedValue=="Y")
			{
				try 
				{
					KoperasiDate = Int64.Parse(Tools.toISODate(TXT_TGL_KOP.Text, DDL_BLN_KOP.SelectedValue, TXT_THN_KOP.Text));
				} 
				catch 
				{
					GlobalTools.popMessage(this, "Tanggal SK Koperasi tidak valid!");
					return;
				}
				if (KoperasiDate > now)
				{
					GlobalTools.popMessage(this, "Tanggal PPAT tidak boleh lebih dari tanggal hari ini!");
					return;
				}
			}

			//--VALIDASI TANGGAL SK BAPEPAM--//
			if(RDO_BAPEPAM.SelectedValue=="Y")
			{
				try 
				{
					BapepamDate = Int64.Parse(Tools.toISODate(TXT_TGL_BAPEPAM.Text, DDL_BLN_BAPEPAM.SelectedValue, TXT_THN_BAPEPAM.Text));
				} 
				catch 
				{
					GlobalTools.popMessage(this, "Tanggal SK Bapepam tidak valid!");
					return;
				}
				if (BapepamDate > now)
				{
					GlobalTools.popMessage(this, "Tanggal Bapepam tidak boleh lebih dari tanggal hari ini!");
					return;
				}
			}

			//--VALIDASI TANGGAL SUMPAH PPAT--//
			try 
			{
				SumpahPPATDate = Int64.Parse(Tools.toISODate(TXT_TGL_SUMPAH_PPAT.Text, DDL_BLN_SUMPAH_PPAT.SelectedValue, TXT_THN_SUMPAH_PPAT.Text));
			} 
			catch 
			{
				GlobalTools.popMessage(this, "Tanggal Sumpah PPAT tidak valid!");
				return;
			}
			if (SumpahPPATDate > now)
			{
				GlobalTools.popMessage(this, "Tanggal Sumpah PPAT tidak boleh lebih dari tanggal hari ini!");
				return;
			}

			//--validasi tanggal sumpah ini--//
			if(RDO_INI.SelectedValue=="Y")
			{
				try 
				{
					INIDate = Int64.Parse(Tools.toISODate(TXT_TGL_INI.Text, DDL_BLN_INI.SelectedValue, TXT_THN_INI.Text));
				} 
				catch 
				{
					GlobalTools.popMessage(this, "Tanggal SK INI tidak valid!");
					return;
				}
				if (INIDate > now)
				{
					GlobalTools.popMessage(this, "Tanggal SK INI tidak boleh lebih dari tanggal hari ini!");
					return;
				}
			}

			//VALIDASI TANGGAL IPPAT
			if(RDO_IPPAT.SelectedValue=="Y")
			{
				try 
				{
					IPPATDate = Int64.Parse(Tools.toISODate(TXT_TGL_IPPAT.Text, DDL_BLN_IPPAT.SelectedValue, TXT_THN_IPPAT.Text));
				} 
				catch 
				{
					GlobalTools.popMessage(this, "Tanggal SK IPPAT tidak valid!");
					return;
				}
				if (IPPATDate > now)
				{
					GlobalTools.popMessage(this, "Tanggal SK IPPAT tidak boleh lebih dari tanggal hari ini!");
					return;
				}
			}

			//--VALIDASI TANGGAL SUMPAH NOTARIS--//
			try 
			{
				SumpahDate = Int64.Parse(Tools.toISODate(TXT_TGL_SUMPAH.Text, DDL_BLN_SUMPAH.SelectedValue, TXT_THN_SUMPAH.Text));
			} 
			catch 
			{
				GlobalTools.popMessage(this, "Tanggal sumpah notaris tidak valid!");
				return;
			}
			if (SumpahDate > now)
			{
				GlobalTools.popMessage(this, "Tanggal sumpah notaris tidak boleh lebih dari tanggal hari ini!");
				return;
			}

			conn.QueryString = "select * from rekanan_notaris where rekanan_ref='" + Request.QueryString["rekanan_ref"] + "'";
			conn.ExecuteQuery();

			if (conn.GetRowCount() > 0)
			{
				//-----penambahan pengecekan untuk audittrail oleh Ariel
					AuditTrailCheck("13");
				//-----
				try
				{
					conn.QueryString = "exec REKANAN_NOTARIS_UPDATE '" +
						Request.QueryString["rekanan_ref"] + "', '" +
						TXT_REK_BURSA.Text + "', " +
						tool.ConvertDate(TXT_TGL_BURSA.Text, DDL_BLN_BURSA.SelectedValue, TXT_THN_BURSA.Text) + ", " +
						tool.ConvertFloat(TXT_HIGH_LIMIT.Text) + ", '" +
						TXT_SK_NOTARIS.Text + "', " +
						tool.ConvertDate(TXT_TGL_SK.Text, DDL_BLN_SK.SelectedValue, TXT_THN_SK.Text) + ", '" +
						TXT_KOTA_NOTARIS.Text + "', '" +
						TXT_SK_PPAT.Text + "', " +
						tool.ConvertDate(TXT_TGL_PPAT.Text, DDL_BLN_PPAT.SelectedValue, TXT_THN_PPAT.Text) + ", '" +
						TXT_PPAT_LOKASI.Text + "', '" +
						TXT_SUMPAH_NOTARIS.Text + "', " +
						tool.ConvertDate(TXT_TGL_SUMPAH.Text, DDL_BLN_SUMPAH.SelectedValue, TXT_THN_SUMPAH.Text) + ", '" +
						TXT_REMARK.Text + "', '" +
						RDO_KOPERASI.SelectedValue + "', '" +
						TXT_NO_KOP.Text + "', " +
						tool.ConvertDate(TXT_TGL_KOP.Text, DDL_BLN_KOP.SelectedValue, TXT_THN_KOP.Text) + ", '" +
						RDO_BAPEPAM.SelectedValue + "', '" +
						TXT_NO_BAPEPAM.Text + "', " +
						tool.ConvertDate(TXT_TGL_BAPEPAM.Text, DDL_BLN_BAPEPAM.SelectedValue, TXT_THN_BAPEPAM.Text) + ", '" +
						TXT_SUMPAH_PPAT.Text + "', " +
						tool.ConvertDate(TXT_TGL_SUMPAH_PPAT.Text, DDL_BLN_SUMPAH_PPAT.SelectedValue, TXT_THN_SUMPAH_PPAT.Text) + ", '" +
						RDO_IPPAT.SelectedValue + "', '" +
						TXT_NO_IPPAT.Text + "', " +
						tool.ConvertDate(TXT_TGL_IPPAT.Text, DDL_BLN_IPPAT.SelectedValue, TXT_THN_IPPAT.Text) +", '"+
						RDO_INI.SelectedValue + "', '" +
						TXT_NO_INI.Text + "', " +
						tool.ConvertDate(TXT_TGL_INI.Text, DDL_BLN_INI.SelectedValue, TXT_THN_INI.Text);
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
					conn.QueryString = "exec REKANAN_NOTARIS_INSERT '" +
						Request.QueryString["rekanan_ref"] + "', '" +
						TXT_REK_BURSA.Text + "', " +
						tool.ConvertDate(TXT_TGL_BURSA.Text, DDL_BLN_BURSA.SelectedValue, TXT_THN_BURSA.Text) + ", " +
						tool.ConvertFloat(TXT_HIGH_LIMIT.Text) + ", '" +
						TXT_SK_NOTARIS.Text + "', " +
						tool.ConvertDate(TXT_TGL_SK.Text, DDL_BLN_SK.SelectedValue, TXT_THN_SK.Text) + ", '" +
						TXT_KOTA_NOTARIS.Text + "', '" +
						TXT_SK_PPAT.Text + "', " +
						tool.ConvertDate(TXT_TGL_PPAT.Text, DDL_BLN_PPAT.SelectedValue, TXT_THN_PPAT.Text) + ", '" +
						TXT_PPAT_LOKASI.Text + "', '" +
						TXT_SUMPAH_NOTARIS.Text + "', " +
						tool.ConvertDate(TXT_TGL_SUMPAH.Text, DDL_BLN_SUMPAH.SelectedValue, TXT_THN_SUMPAH.Text) + ", '" +
						TXT_REMARK.Text + "', '" +
						RDO_KOPERASI.SelectedValue + "', '" +
						TXT_NO_KOP.Text + "', " +
						tool.ConvertDate(TXT_TGL_KOP.Text, DDL_BLN_KOP.SelectedValue, TXT_THN_KOP.Text) + ", '" +
						RDO_BAPEPAM.SelectedValue + "', '" +
						TXT_NO_BAPEPAM.Text + "', " +
						tool.ConvertDate(TXT_TGL_BAPEPAM.Text, DDL_BLN_BAPEPAM.SelectedValue, TXT_THN_BAPEPAM.Text) + ", '" +
						TXT_SUMPAH_PPAT.Text + "', " +
						tool.ConvertDate(TXT_TGL_SUMPAH_PPAT.Text, DDL_BLN_SUMPAH_PPAT.SelectedValue, TXT_THN_SUMPAH_PPAT.Text) + ", '" +
						RDO_IPPAT.SelectedValue + "', '" +
						TXT_NO_IPPAT.Text + "', " +
						tool.ConvertDate(TXT_TGL_IPPAT.Text, DDL_BLN_IPPAT.SelectedValue, TXT_THN_IPPAT.Text) +", '"+
						RDO_INI.SelectedValue + "', '" +
						TXT_NO_INI.Text + "', " +
						tool.ConvertDate(TXT_TGL_INI.Text, DDL_BLN_INI.SelectedValue, TXT_THN_INI.Text);
				}
				catch
				{
					GlobalTools.popMessage(this, "Connection Error!");
					Response.Redirect("../../Login.aspx?expire=1");
				}
			}
			conn.ExecuteNonQuery();
		}

		protected void BTN_CLEAR_NOTARIS_Click(object sender, System.EventArgs e)
		{
			TXT_REK_BURSA.Text = "";
			TXT_TGL_BURSA.Text = "";
			DDL_BLN_BURSA.SelectedValue = "";
			TXT_THN_BURSA.Text = "";
			TXT_HIGH_LIMIT.Text = "";
			TXT_SK_NOTARIS.Text = "";
			TXT_TGL_SK.Text = "";
			DDL_BLN_SK.SelectedValue = "";
			TXT_THN_SK.Text = "";
			TXT_KOTA_NOTARIS.Text = "";
			TXT_SK_PPAT.Text = "";
			TXT_TGL_PPAT.Text = "";
			DDL_BLN_PPAT.SelectedValue = "";
			TXT_THN_PPAT.Text = "";
			TXT_PPAT_LOKASI.Text = "";
			TXT_SUMPAH_NOTARIS.Text = "";
			TXT_TGL_SUMPAH.Text = "";
			DDL_BLN_SUMPAH.SelectedValue = "";
			TXT_THN_SUMPAH.Text = "";
			TXT_REMARK.Text = "";
		}

		protected void TXT_HIGH_LIMIT_TextChanged(object sender, System.EventArgs e)
		{
			TXT_HIGH_LIMIT.Text = tool.MoneyFormat(TXT_HIGH_LIMIT.Text);
		}

		protected void BTN_BACK_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			if (Request.QueryString["par"] != null && Request.QueryString["par"] != "") 
			{
				Response.Redirect(Request.QueryString["par"] + "&mc=" + Request.QueryString["mc2"] + "&regnum=" + Request.QueryString["regnum"] + "&rekanan_ref=" + Request.QueryString["rekanan_ref"] + "&tc=" + Request.QueryString["tc"]+ "&view=" + Request.QueryString["view"]);}
			else
				Response.Redirect("/SME/" + DMS.CuBESCore.Logic.backLink(Request.QueryString["tc"].ToString(), conn));
		}

		private void CekView()
		{
			if(Request.QueryString["view"]=="1")
			{
				RDO_RFCUSTOMERTYPE.Enabled = false;
				TXT_NO_REG.ReadOnly = true;
				DDL_JNS_REKANAN.Enabled = false;
				TXT_TITLE.ReadOnly = true;
				TXT_NO_AREA.ReadOnly = true;
				TXT_NO_KNTR.ReadOnly = true;
				TXT_EMAIL.ReadOnly = true;
				TXT_HP1.ReadOnly = true;
				TXT_HP2.ReadOnly = true;
				TXT_NOKTP.ReadOnly = true;
				TXT_TGL_KTP.ReadOnly = true;
				TXT_THN_KTP.ReadOnly = true;
				TXT_TGL_PENSIUN.ReadOnly = true;
				TXT_THN_PENSIUN.ReadOnly = true;
				TXT_ZIP_CODE.ReadOnly = true;
				DDL_JENIS_REK_COMP.Enabled = false;
				DDL_JENIS_BU.Enabled = false;
				TXT_NAMA_COMP.ReadOnly = true;
				TXT_COMP_ADD1.ReadOnly = true;
				DDL_CITY_CAB.Enabled = false;
				DDL_KAB_CAB.Enabled = false;
				TXT_COMP_ZIPCODE.ReadOnly = true;
				TXT_COMP_AREA.ReadOnly = true;
				TXT_COMP_TLP.ReadOnly = true;
				TXT_COMP_TGL.ReadOnly = true;
				DDL_COMP_BLN.Enabled = false;
				TXT_COMP_THN.ReadOnly = true;
				TXT_COMP_TMP.ReadOnly = true;
				TXT_COMP_FAX1.ReadOnly = true;
				TXT_COMP_FAX2.ReadOnly = true;
				TXT_COMP_NPWP.ReadOnly = true;
				TXT_COMP_CPNAME.ReadOnly = true;
				TXT_COMP_CPJBT.ReadOnly = true;
				TXT_COMP_TLPCP1.ReadOnly = true;
				TXT_COMP_TLPCP2.ReadOnly = true;
				TXT_COMP_HPCP1.ReadOnly = true;
				TXT_COMP_CPHP2.ReadOnly = true;
				BTN_SAVE_REKANAN.Enabled = false;
				BTN_UPDATE_REKANAN.Enabled = false;
				TXT_TGL_LAHIR.ReadOnly = true;
				DDL_BLN_LAHIR.Enabled = false;
				TXT_THN_LAHIR.ReadOnly = true;
				TXT_TMP_LAHIR.ReadOnly = true;
				TXT_REK_ADD1.ReadOnly = true;				
				DDL_CITY_CAB2.Enabled = false;
				DDL_BLN_KTP.Enabled = false;
				DDL_BLN_PENSIUN.Enabled = false;
				TXT_NAMA.ReadOnly = true;
				LBL_REK_REF.Visible = false;
				LBL_REK_REG.Visible = false;
				TXT_SEQ.Visible = false;
				DDL_JNS_DOC.Enabled = false;
				TXT_NO_DOC.ReadOnly = true;
				TXT_DIKELUARKAN_OLEH.ReadOnly = true;
				TXT_TGL_DOC.ReadOnly = true;
				DDL_BLN_DOC.Enabled = false;
				TXT_THN_DOC.ReadOnly = true;
				TXT_TGLEXP_DOC.ReadOnly = true;
				DDL_BLNEXP_DOC.Enabled = false;
				TXT_THNEXP_DOC.ReadOnly = true;
				TXT_NOTARIS.ReadOnly = true;
				BTN_INSERT.Enabled = false;
				BTN_UPDATE.Enabled = false;
				BTN_CLEAR.Enabled = false;
				TXT_SK_NOTARIS.ReadOnly = true;
				TXT_TGL_SK.ReadOnly = true;
				DDL_BLN_SK.Enabled = false;
				TXT_THN_SK.ReadOnly = true;
				TXT_SUMPAH_NOTARIS.ReadOnly = true;
				TXT_TGL_SUMPAH.ReadOnly = true;
				DDL_BLN_SUMPAH.Enabled = false;
				TXT_THN_SUMPAH.ReadOnly = true;
				TXT_KOTA_NOTARIS.ReadOnly = true;
				RDO_KOPERASI.Enabled = false;
				TXT_NO_KOP.ReadOnly = true;
				TXT_TGL_KOP.ReadOnly = true;
				DDL_BLN_KOP.Enabled = false;
				TXT_THN_KOP.ReadOnly = true;
				RDO_BAPEPAM.Enabled = false;
				TXT_NO_BAPEPAM.ReadOnly = true;
				TXT_TGL_BAPEPAM.ReadOnly = true;
				DDL_BLN_BAPEPAM.Enabled = false;
				TXT_THN_BAPEPAM.ReadOnly = true;
				TXT_SK_PPAT.ReadOnly = true;
				TXT_TGL_PPAT.ReadOnly = true;
				DDL_BLN_PPAT.Enabled = false;
				TXT_THN_PPAT.ReadOnly = true;
				TXT_SUMPAH_PPAT.ReadOnly = true;
				TXT_TGL_SUMPAH_PPAT.ReadOnly = true;
				DDL_BLN_SUMPAH_PPAT.Enabled = false;
				TXT_THN_SUMPAH_PPAT.ReadOnly = true;
				TXT_PPAT_LOKASI.ReadOnly = true;
				RDO_INI.Enabled = false;
				TXT_NO_INI.ReadOnly = true;
				TXT_TGL_INI.ReadOnly = true;
				DDL_BLN_INI.Enabled = false;
				TXT_NO_IPPAT.ReadOnly = true;
				TXT_TGL_IPPAT.ReadOnly = true;
				DDL_BLN_IPPAT.Enabled = false;
				TXT_REK_BURSA.ReadOnly = true;
				TXT_TGL_BURSA.ReadOnly = true;
				DDL_BLN_BURSA.Enabled = false;
				TXT_THN_BURSA.ReadOnly = true;
				TXT_HIGH_LIMIT.ReadOnly = true;
				TXT_REMARK.ReadOnly = true;
				BTN_SAVE_NOTARIS.Enabled = false;
				BTN_CLEAR_NOTARIS.Enabled = false;
				TXT_THN_INI.ReadOnly = true;
				TXT_NPWP_PERSONAL.ReadOnly = true;
				RDO_MERANGKAP_KM.Enabled = false;
				TXT_KAPA.ReadOnly = true;
				SYARAT_TYPEIDE.Visible = false;
				Label1.Visible = false;
				TXT_TEMP.ReadOnly = true;
				DatGridDoc.Columns[7].Visible = false;
			}
		}

		protected void DDL_CITY_CAB_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			ViewKab();
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

		private void ViewKab2()
		{
			DDL_KAB_CAB2.Items.Clear();
			DDL_KAB_CAB2.Items.Add(new ListItem("- PILIH -", ""));
			
			conn.QueryString = "select zipcode, description from rfzipcodecity " + 
				"where cityid='" + DDL_CITY_CAB2.SelectedValue + 
				"' and active='1' order by rtrim(ltrim(zipcode))";
			conn.ExecuteQuery();
			for (int i = 0; i < conn.GetRowCount(); i++)
				DDL_KAB_CAB2.Items.Add(new ListItem(conn.GetFieldValue(i,1), conn.GetFieldValue(i,0)));
		}

		/*private void DDL_KAB_CAB_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			TXT_ZIP_CODE.Text = DDL_KAB_CAB.SelectedValue;	
		}*/

		protected void DDL_CITY_CAB2_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			ViewKab2();
		}

		/*private void DDL_KAB_CAB2_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			TXT_COMP_ZIPCODE.Text = DDL_KAB_CAB2.SelectedValue;	
		}*/

		protected void TXT_ZIP_CODE_TextChanged(object sender, System.EventArgs e)
		{	
			try	{DDL_KAB_CAB.SelectedValue = TXT_ZIP_CODE.Text;}
			catch{DDL_KAB_CAB.SelectedValue="";}
		}

		protected void TXT_COMP_ZIPCODE_TextChanged(object sender, System.EventArgs e)
		{
			try{DDL_KAB_CAB2.SelectedValue = TXT_COMP_ZIPCODE.Text;}
			catch{DDL_KAB_CAB2.SelectedValue="";}
		}

		private void BindDataQuanitative()
		{
			conn.QueryString = "select * from rekanan_quantitative WHERE regnum= '" + Request.QueryString["rekanan_ref"] + "C" + "' ";
			conn.ExecuteQuery();

			DataTable dt = new DataTable();
			dt = conn.GetDataTable().Copy();
			DGR_QUAN.DataSource = dt;
			try 
			{
				DGR_QUAN.DataBind();
			}
			catch 
			{
				DGR_QUAN.CurrentPageIndex = 0;
				DGR_QUAN.DataBind();
			}					
		}

		private void BindQual()
		{
			conn.QueryString = "select * from rekanan_qualitative WHERE regnum= '" + Request.QueryString["rekanan_ref"] + "C" + "' ";
			conn.ExecuteQuery();

			DataTable dt = new DataTable();
			dt = conn.GetDataTable().Copy();
			DGR_QUAL.DataSource = dt;
			try 
			{
				DGR_QUAL.DataBind();
			}
			catch 
			{
				DGR_QUAL.CurrentPageIndex = 0;
				DGR_QUAL.DataBind();
			}			
		}

		private void BindCla()
		{
			conn.QueryString="select * from rekanan_crite WHERE regnum= '" + Request.QueryString["rekanan_ref"] + "C" + "' ";
			conn.ExecuteQuery();

			DataTable dt = new DataTable();
			dt = conn.GetDataTable().Copy();
			DGR_CLA.DataSource = dt;
			try 
			{
				DGR_CLA.DataBind();
			}
			catch 
			{
				DGR_CLA.CurrentPageIndex = 0;
				DGR_CLA.DataBind();
			}

			
		}

		

	}
}
