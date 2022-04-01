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


namespace SME.Scoring
{
	/// <summary>
	/// Summary description for Neraca. a
	/// </summary>
	public partial class ScoringHubunganBank : System.Web.UI.Page
	{
		protected Connection conn;
		protected Tools tool = new Tools();
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			conn = (Connection) Session["Connection"];

			if (!IsPostBack) 
			{
				//////////////////////////////////////////////////////////
				///	Init DropDowns
				///	
				viewDDL();

				//////////////////////////////////////////////////////////
				///	Mengisi data dari proses sebelumnya
				///	
				Populate();

				//////////////////////////////////////////////////////////
				///	Mengisi data dari scoring_hubbank
				///	
				viewData();

				///////////////////////////////////////////////
				///	SET MANDATORY FIELDS
				///	
				setMandatoryFields("B");


				///////////////////////////////////////////////
				///	SET DISABLED FIELDS
				///	
				setDisabledFields("B");
			}

			BTN_SAVE.Attributes.Add("onclick", "if(!cek_mandatory_hubbank(document.Form1)){return false;};");			
		}

		private void setDisabledFields(string FAIRISAAC_SUBMODULE) 
		{
			conn.QueryString = "select * from VW_SCORING_DISABLED_FIELDS " + 
				"where FAIRISAAC_SUBMODULE = '" + FAIRISAAC_SUBMODULE + 
				"' and AP_REGNO = '" + Request.QueryString["regno"] +
				"' and ACTIVE = '1'";
			conn.ExecuteQuery();

			for(int i=0; i < conn.GetRowCount(); i++) 
			{
				string CONTROLID = conn.GetFieldValue(i, "FAIRISAAC_CONTROLID");
			
				if (CONTROLID.IndexOf(",") == 0) 
				{
					if (CONTROLID.StartsWith("TXT_")) 
					{
						TextBox TXT_CONTROL = (TextBox) Page.FindControl(CONTROLID);
						try 
						{
							TXT_CONTROL.ReadOnly = true;
							TXT_CONTROL.BackColor = Color.Gainsboro;
						} 
						catch (NullReferenceException) {}
					}
					else if (CONTROLID.StartsWith("DDL_")) 
					{
						DropDownList DDL_CONTROL = (DropDownList) Page.FindControl(CONTROLID);
						try 
						{
							DDL_CONTROL.Enabled = false;
							DDL_CONTROL.BackColor = Color.Gainsboro;
						} 
						catch (NullReferenceException) {}
					}
				} 
				else 
				{
					string CONTROL;
					string[] split = CONTROLID.Split(new Char[] {','});
				
					foreach(string s in split) 
					{
						if (s.Trim() != "") 
						{
							CONTROL = s;
							if (CONTROL.StartsWith("TXT_")) 
							{
								TextBox TXT_CONTROL = (TextBox) Page.FindControl(CONTROL);
								try 
								{
									TXT_CONTROL.ReadOnly = true;
									TXT_CONTROL.BackColor = Color.Gainsboro;
								} 
								catch (NullReferenceException) {}
							}
							else if (CONTROL.StartsWith("DDL_")) 
							{
								DropDownList DDL_CONTROL = (DropDownList) Page.FindControl(CONTROL);
								try 
								{
									DDL_CONTROL.Enabled = false;
									DDL_CONTROL.BackColor = Color.Gainsboro;
								}
								catch (NullReferenceException) {}
							}
						}
					}
				}
			}
		}

		private void setMandatoryFields(string FAIRISAAC_SUBMODULE) 
		{
			conn.QueryString = "select * from VW_SCORING_MANDATORY_FIELDS " + 
				"where FAIRISAAC_SUBMODULE = '" + FAIRISAAC_SUBMODULE + 
				"' and AP_REGNO = '" + Request.QueryString["regno"] +
				"' and ACTIVE = '1'";
			conn.ExecuteQuery();

			for(int i=0; i < conn.GetRowCount(); i++) 
			{
				string CONTROLID = conn.GetFieldValue(i, "FAIRISAAC_CONTROLID");
			
				if (CONTROLID.IndexOf(",") == 0) 
				{
					if (CONTROLID.StartsWith("TXT_")) 
					{
						TextBox TXT_CONTROL = (TextBox) Page.FindControl(CONTROLID);
						try {TXT_CONTROL.CssClass = "mandatory";}
						catch (NullReferenceException) {}
					}
					else if (CONTROLID.StartsWith("DDL_")) 
					{
						DropDownList DDL_CONTROL = (DropDownList) Page.FindControl(CONTROLID);
						try {DDL_CONTROL.CssClass = "mandatory";}
						catch {}
					}
				} 
				else 
				{
					string CONTROL;
					string[] split = CONTROLID.Split(new Char[] {','});
				
					foreach(string s in split) 
					{
						if (s.Trim() != "") 
						{
							CONTROL = s;
							if (CONTROL.StartsWith("TXT_")) 
							{
								TextBox TXT_CONTROL = (TextBox) Page.FindControl(CONTROL);
								try {TXT_CONTROL.CssClass = "mandatory";}
								catch (NullReferenceException) {}
							}
							else if (CONTROL.StartsWith("DDL_")) 
							{
								DropDownList DDL_CONTROL = (DropDownList) Page.FindControl(CONTROL);
								try {DDL_CONTROL.CssClass = "mandatory";}
								catch {}
							}
						}
					}
				}
			}
		}

		void viewDDL()
		{
			String str;
			str="select COLLECTIBILITY,DESCRIPTION  from RFCOLLECTIBILITYSCORING  ";
			if (Request.QueryString["tc"] == "1.7") str = str + " where active = '1'";
			//GlobalTools.fillRefList(DDL_BUSINESS_BM_COLL_W12,str,conn);

			str="select COLLECTIBILITY,DESCRIPTION  from RFCOLLECTIBILITYSCORING  ";
			if (Request.QueryString["tc"] == "1.7") str = str + " where active = '1'";
			//GlobalTools.fillRefList(DDL_MGM_BM_COLL_CURR,str,conn);

			str="select COLLECTIBILITY,DESCRIPTION  from RFCOLLECTIBILITYSCORING  ";
			if (Request.QueryString["tc"] == "1.7") str = str + " where active = '1'";
			//GlobalTools.fillRefList(DDL_APP_BM_COLL_CURR,str,conn);

			str="select COLLECTIBILITY,DESCRIPTION  from RFCOLLECTIBILITYSCORING  ";
			if (Request.QueryString["tc"] == "1.7") str = str + " where active = '1'";
			//GlobalTools.fillRefList(DDL_KEY_BM_COLL,str,conn);

			DDL_BUSINESS_BM_COLL_W12.Items.Clear();
			DDL_MGM_BM_COLL_CURR.Items.Clear();
			DDL_APP_BM_COLL_CURR.Items.Clear();
			DDL_KEY_BM_COLL.Items.Clear();

			conn.QueryString = str;
			conn.ExecuteQuery();
			for(int i=0; i<conn.GetRowCount(); i++) 
			{
				DDL_BUSINESS_BM_COLL_W12.Items.Add(new ListItem(conn.GetFieldValue(i, "DESCRIPTION"), conn.GetFieldValue(i, "COLLECTIBILITY")));
				DDL_MGM_BM_COLL_CURR.Items.Add(new ListItem(conn.GetFieldValue(i, "DESCRIPTION"), conn.GetFieldValue(i, "COLLECTIBILITY")));
				DDL_APP_BM_COLL_CURR.Items.Add(new ListItem(conn.GetFieldValue(i, "DESCRIPTION"), conn.GetFieldValue(i, "COLLECTIBILITY")));
				DDL_KEY_BM_COLL.Items.Add(new ListItem(conn.GetFieldValue(i, "DESCRIPTION"), conn.GetFieldValue(i, "COLLECTIBILITY")));
			}


			str="select COLLLEVEL,DESCRIPTION   from RFCOLLECTIBILITYLEVELSCORING  ";
			if (Request.QueryString["tc"] == "1.7") str = str + " where active = '1'";
			//GlobalTools.fillRefList(DDL_APP_BI_COLL_CURR,str,conn);		

			str="select COLLLEVEL,DESCRIPTION   from RFCOLLECTIBILITYLEVELSCORING  ";
			if (Request.QueryString["tc"] == "1.7") str = str + " where active = '1'";
			//GlobalTools.fillRefList(DDL_KEY_BI_COLL_LVL,str,conn);	

			str="select COLLLEVEL,DESCRIPTION   from RFCOLLECTIBILITYLEVELSCORING  ";
			if (Request.QueryString["tc"] == "1.7") str = str + " where active = '1'";
			//GlobalTools.fillRefList(DDL_MGM_BI_COLL_LVL,str,conn);


			DDL_APP_BI_COLL_CURR.Items.Clear();
			DDL_KEY_BI_COLL_LVL.Items.Clear();
			DDL_MGM_BI_COLL_LVL.Items.Clear();
			DDL_APP_BI_COLL_CURR_12BLN.Items.Clear();
			DDL_KEY_BI_COLL_LVL_12BLN.Items.Clear();
			DDL_MGM_BI_COLL_LVL_12BLN.Items.Clear();

			conn.QueryString = str;
			conn.ExecuteQuery();
			for(int i=0; i<conn.GetRowCount(); i++) 
			{
				DDL_APP_BI_COLL_CURR.Items.Add(new ListItem(conn.GetFieldValue(i, "DESCRIPTION"), conn.GetFieldValue(i, "COLLLEVEL")));
				DDL_KEY_BI_COLL_LVL.Items.Add(new ListItem(conn.GetFieldValue(i, "DESCRIPTION"), conn.GetFieldValue(i, "COLLLEVEL")));
				DDL_MGM_BI_COLL_LVL.Items.Add(new ListItem(conn.GetFieldValue(i, "DESCRIPTION"), conn.GetFieldValue(i, "COLLLEVEL")));
				DDL_APP_BI_COLL_CURR_12BLN.Items.Add(new ListItem(conn.GetFieldValue(i, "DESCRIPTION"), conn.GetFieldValue(i, "COLLLEVEL")));
				DDL_KEY_BI_COLL_LVL_12BLN.Items.Add(new ListItem(conn.GetFieldValue(i, "DESCRIPTION"), conn.GetFieldValue(i, "COLLLEVEL")));
				DDL_MGM_BI_COLL_LVL_12BLN.Items.Add(new ListItem(conn.GetFieldValue(i, "DESCRIPTION"), conn.GetFieldValue(i, "COLLLEVEL")));
			}

			str="select FACILITYFLAG,DESCRIPTION from RFFACILITYFLAGSCORING  ";
			if (Request.QueryString["tc"] == "1.7") str = str + " where active = '1'";
			//GlobalTools.fillRefList(DDL_FACKREDIT ,str,conn);	

			DDL_FACKREDIT.Items.Clear();
			conn.QueryString = str;
			conn.ExecuteQuery();
			for(int i=0; i<conn.GetRowCount(); i++) 
			{
				DDL_FACKREDIT.Items.Add(new ListItem(conn.GetFieldValue(i, "DESCRIPTION"), conn.GetFieldValue(i, "FACILITYFLAG")));
			}

		}
	
		private bool inputIsValid() 
		{
			bool _inputIsValid = true;

			/**************************************************************
			 * Sebelum save, pastikan 2 hal (utk kebutuhan scoring):
			 * 1. Untuk existing debitur, pastikan dia punya existing limit
			 * 2. Pastikan Total Exposure > 0
			 ***************************************************************/
			conn.QueryString = "exec SCORING_CEKTOTALEXPOSURE '" + Request.QueryString["regno"].ToString() + "'";
			conn.ExecuteQuery();
			if (conn.GetFieldValue("totalExposureIsValid") == "0") 
			{
				GlobalTools.popMessage(this, conn.GetFieldValue("errorMessage"));
				_inputIsValid = false;
			}

			return _inputIsValid ;
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


		private void Populate()
		{
			//////////////////////////////////////////////////////////
			///	Watchlist
			///	
			conn.QueryString = "select cu_inwatchlist = case when isnull(cu_inwatchlist,'0') = '0' then 'N' else 'Y' end " +
				"from customer where cu_ref = '" + Request.QueryString["curef"] + "'";
			conn.ExecuteQuery();
			try { DDL_WATCH_LIST.SelectedValue = conn.GetFieldValue("cu_inwatchlist"); } 
			catch {}


			///////////////////////////////////////////////////////////
			///	Mengambil Existing Exposure di BM untuk KMK
			///	
			conn.QueryString = "exec FAIRISAAC_EXISTINGEXPOSURE_KMKONLY '" + Request.QueryString["curef"] + "'";
			conn.ExecuteQuery();
			double vKMK_LMT_BM_CURR = 0;
			try { vKMK_LMT_BM_CURR = Convert.ToDouble(conn.GetFieldValue("EXISTINGEXPOSURE_KMK")); } 
			catch {}
			vKMK_LMT_BM_CURR = vKMK_LMT_BM_CURR / 1000;
			TXT_KMK_LMT_BM_CURR.Text = tool.MoneyFormat(vKMK_LMT_BM_CURR.ToString());


			//ahmad: begin

			///////////////////////////////////////////////////////////
			/// collectibility
			/// 
			///

			conn.QueryString = "select * from VW_COLLECTIBILITY where cu_ref='"+ Request.QueryString["curef"] +"'";
			conn.ExecuteQuery();

			//applicant
			TXT_NUM_APP_COLL_12_2A.Text = conn.GetFieldValue("NUM_COLL_2A");
			TXT_NUM_APP_COLL_12_2B.Text = conn.GetFieldValue("NUM_COLL_2B");
			TXT_NUM_APP_COLL_12_2C.Text = conn.GetFieldValue("NUM_COLL_2C");
			TXT_NUM_APP_COLL_12_3PLUS.Text = conn.GetFieldValue("NUM_COLL_3PLUS");
			try {DDL_BUSINESS_BM_COLL_W12.SelectedValue = conn.GetFieldValue("COLLBM_WORST_12B");} 
			catch {}
			//try { DDL_APP_BM_COLL_CURR.SelectedValue = conn.GetFieldValue("COLL_CURR_CUST"); } 
			try { DDL_APP_BM_COLL_CURR.SelectedValue = conn.GetFieldValue("COLLBM_CURR_CUST"); } 
			catch {}

			//key person
			//try {DDL_KEY_BM_COLL.SelectedValue = conn.GetFieldValue("COLL_CURR_KP");}
			try {DDL_KEY_BM_COLL.SelectedValue = conn.GetFieldValue("COLLBM_CURR_KP");}
			catch {}
			TXT_KEY_BM_COLL_2C.Text = conn.GetFieldValue("COLL_2C_12_KP");

			//management
			//try {DDL_MGM_BM_COLL_CURR.SelectedValue = conn.GetFieldValue("COLL_CURR_MGM");}
			try {DDL_MGM_BM_COLL_CURR.SelectedValue = conn.GetFieldValue("COLLBM_CURR_MGMG");}				
			catch {}

			TXT_MGM_BM_COLL_2C.Text = conn.GetFieldValue("COLL_2C_12_MGM");


			////////////////////////////////////////////////
			/// Mengisi Kolektibilitas di BI
			/// 
			conn.QueryString = "select AP_BLBIACCBK, AP_BLBIOCBK, AP_BLBIMCBKS, " + 
				"AP_BLBIACCBK12BLN, AP_BLBIOCBK12BLN, AP_BLBIMCBKS12BLN " + 
				"from APPLICATION where AP_REGNO = '" + Request.QueryString["regno"] + "'";
			conn.ExecuteQuery();

			//Kolektibilitas perusahaan saat ini di bank lain (IDI BI)
			try { DDL_APP_BI_COLL_CURR.SelectedValue = conn.GetFieldValue("AP_BLBIACCBK"); } 
			catch {}

			//Kolektibilitas pemilik saat ini di bank lain (IDI BI)
			try { DDL_KEY_BI_COLL_LVL.SelectedValue = conn.GetFieldValue("AP_BLBIOCBK"); } 
			catch {}

			//Kolektibilitas key person saat ini di bank lain (IDI BI)
			try { DDL_MGM_BI_COLL_LVL.SelectedValue = conn.GetFieldValue("AP_BLBIMCBKS"); } 
			catch {}

			//Kolektibilitas perusahaan 12 bulan terakhir di bank lain (IDI BI)
			try { DDL_APP_BI_COLL_CURR_12BLN.SelectedValue = conn.GetFieldValue("AP_BLBIACCBK12BLN"); } 
			catch {}

			//Kolektibilitas pemilik 12 bulan terakhir di bank lain (IDI BI)
			try { DDL_KEY_BI_COLL_LVL_12BLN.SelectedValue = conn.GetFieldValue("AP_BLBIOCBK12BLN"); } 
			catch {}

			//Kolektibilitas key person 12 bulan terakhir di bank lain (IDI BI)
			try { DDL_MGM_BI_COLL_LVL_12BLN.SelectedValue = conn.GetFieldValue("AP_BLBIMCBKS12BLN"); } 
			catch {}

			
			// ahmad: end
			
			conn.QueryString = "exec SP_SCORING_COMPANY_INFO '" + Request.QueryString["curef"] + "'";
			conn.ExecuteQuery();	
	
			// Mulai menjadi nasabah BM
			TXT_MULAI_BM_MM.Text = conn.GetFieldValue("BULAN");
			TXT_MULAI_BM_YY.Text = conn.GetFieldValue("TAHUN");
			if (TXT_MULAI_BM_MM.Text.Trim() == "") TXT_MULAI_BM_MM.Text = "00";
			if (TXT_MULAI_BM_YY.Text.Trim() == "") TXT_MULAI_BM_YY.Text = "0000";

			// Saat ini menjadi nasabah BM
			if (TXT_MULAI_BM_MM.Text == "00" && TXT_MULAI_BM_YY.Text == "0000") 
				DDL_BUSINESS_CURR_BM.SelectedValue = "N";
			else 
				DDL_BUSINESS_CURR_BM.SelectedValue = "Y";
			
			double x = 0;
			double x_satuan = 0;


			/////////////////////////////////////////////////////////
			///	Total Application Value (Total limit aplikasi)
			///	
			conn.QueryString = "DE_TOTALEXPOSURE '" + Request.QueryString["regno"] + "'";
			conn.ExecuteQuery(300);
			if (conn.GetRowCount() > 0) 
			{
				x = Convert.ToDouble(conn.GetFieldValue("tot_limit"));				
			}
			x_satuan = x / 1000;
			TXT_LMT_CREDIT_CURR.Text = GlobalTools.MoneyFormat(x.ToString());
			TXT_LMT_CREDIT_CURR_MILL.Text = Convert.ToString(Math.Round(x_satuan));
			TXT_LMT_CREDIT_CURR_MILL.Text = GlobalTools.MoneyFormat(TXT_LMT_CREDIT_CURR_MILL.Text);


			/////////////////////////////////////////////////////////////////////////
			///	Total Limit Exposure = Total Exposure + Total Application Value
			///	
			conn.QueryString = "FAIRISAAC_EXISTINGEXPOSURE '" + Request.QueryString["curef"] + "'";
			conn.ExecuteQuery();
			if (conn.GetRowCount() > 0) 
			{
				x = x + Convert.ToDouble(conn.GetFieldValue("existing_exposure"));	
				x_satuan = 0;
			}
			TXT_TTL_EXP.Text = x.ToString("##,##0.00");
			x_satuan = x / 1000;
			TXT_TTL_EXP_MILL.Text = Convert.ToString(Math.Round(x_satuan));
			TXT_TTL_EXP_MILL.Text = GlobalTools.MoneyFormat(TXT_TTL_EXP_MILL.Text);


			conn.QueryString="select a.ap_regno , c.CU_PERNAHJDNASABAHBM " +
			" from custproduct a inner join application b on a.ap_regno=b.ap_regno " +
			" inner join customer c on b.cu_ref=c.cu_ref where b.ap_regno = '" + Request.QueryString["regno"] + "'";
			conn.ExecuteQuery();			

			try {DDL_BUSINESS_PAST_BM.SelectedValue = conn.GetFieldValue("CU_PERNAHJDNASABAHBM");}
			catch {}

			// DIATAS sudah diambil, kok disini diambil lagi ... ??
//			conn.QueryString=" select  b.ap_regno,b.cu_ref,a.NUM_COLL_2A,a.NUM_COLL_2B,a.NUM_COLL_2C, " +
//			" a.COLL_12_LAST,a.COLL_W_12_B,a.COLL_2C_12_KP,a.COLL_CURR_KP,a.COLL_2C_12_MGM, " + 
//			" a.COLL_CURR_MGM , NUM_COLL_3PLUS from collectibility a inner join application b on a.cu_ref=b.cu_ref ";
//			conn.ExecuteQuery();
//
//			TXT_NUM_APP_COLL_12_2A.Text = conn.GetFieldValue("NUM_COLL_2A");
//			TXT_NUM_APP_COLL_12_2B.Text = conn.GetFieldValue("NUM_COLL_2B");
//			TXT_NUM_APP_COLL_12_2C.Text = conn.GetFieldValue("NUM_COLL_2C");
//			TXT_KEY_BM_COLL_2C.Text = conn.GetFieldValue("COLL_2C_12_KP");
//			try	{DDL_KEY_BM_COLL.SelectedValue = conn.GetFieldValue("COLL_CURR");}
//			catch{}
//			TXT_MGM_BM_COLL_2C.Text = conn.GetFieldValue("COLL_2C_12_MGM");
//			try{DDL_MGM_BM_COLL_CURR.SelectedValue = conn.GetFieldValue("COLL_CURR_MGM");} 
//			catch{}						
//			TXT_NUM_APP_COLL_12_3PLUS.Text = conn.GetFieldValue("NUM_COLL_3PLUS");


			conn.QueryString="select * from VW_BLACKLIST_FI WHERE AP_REGNO = '" + Request.QueryString["regno"] + "'";
			conn.ExecuteQuery();
			try{DDL_KEY_BM_BL.SelectedValue=conn.GetFieldValue("AP_BLBMPEMILIK");}
			catch{}
			try{DDL_PERUSH_BLBM_CURR.SelectedValue=conn.GetFieldValue("AP_BLBMUSAHA");}
			catch{}
			try {DDL_MGM_BLBI.SelectedValue = conn.GetFieldValue("AP_BLBIMGMT"); }
			catch {}
			try{DDL_KEY_BI_BM.SelectedValue=conn.GetFieldValue("AP_BLBIPEMILIK");}
			catch{}
			try{DDL_PERUSH_BLBI_CURR.SelectedValue=conn.GetFieldValue("AP_BLBIUSAHA");}
			catch{}
			try{DDL_MGM_BLBM.SelectedValue=conn.GetFieldValue("AP_BLBMMGMT");}
			catch{}
		}

		private void viewData()
		{
			conn.QueryString="select * from scoring_hubbank where ap_regno='" + Request.QueryString["regno"] + "'";
			conn.ExecuteQuery();
			if (conn.GetRowCount()>0)
			{
				try{DDL_FACKREDIT.SelectedValue = conn.GetFieldValue(0,"FACKREDIT");} catch{}

				//TXT_LMT_CREDIT_CURR.Text =  conn.GetFieldValue("LMT_CREDIT_CURR");
//				TXT_LMT_CREDIT_CURR_MILL.Text =  conn.GetFieldValue(0,"LMT_CREDIT_CURR_MILL");
//				TXT_TTL_EXP_MILL.Text =  conn.GetFieldValue("TTL_EXP_MILL");
//				//TXT_TTL_EXP.Text =  conn.GetFieldValue("TTL_EXP");
//				try{DDL_BUSINESS_CURR_BM.SelectedValue =  conn.GetFieldValue("BUSINESS_CURR_BM");}catch{}
//				try{DDL_BUSINESS_PAST_BM.SelectedValue =  conn.GetFieldValue("BUSINESS_PAST_BM");}catch{}
//				TXT_MULAI_BM_MM.Text  =  conn.GetFieldValue("MULAI_BM_MM");
//				TXT_MULAI_BM_YY.Text  =  conn.GetFieldValue("MULAI_BM_YY");
//				try{DDL_APP_BI_COLL_CURR.SelectedValue =  conn.GetFieldValue("APP_BI_COLL_CURR");}catch{}
//				try{DDL_APP_BM_COLL_CURR.SelectedValue =  conn.GetFieldValue("APP_BM_COLL_CURR");}catch{}
//				DDL_BUSINESS_BM_COLL_W12.SelectedValue  =  conn.GetFieldValue("APP_BM_COLL_W12");
//				TXT_NUM_APP_COLL_12_2A.Text  =  conn.GetFieldValue("NUM_APP_COLL_12_2A");
//				TXT_NUM_APP_COLL_12_2B.Text  =  conn.GetFieldValue("NUM_APP_COLL_12_2B");
//				TXT_NUM_APP_COLL_12_2C.Text  =  conn.GetFieldValue("NUM_APP_COLL_12_2C");
//				try{DDL_PERUSH_BLBM_CURR.SelectedValue =  conn.GetFieldValue("PERUSH_BLBM_CURR");}catch{}
//				try{DDL_PERUSH_BLBI_CURR.SelectedValue =  conn.GetFieldValue("PERUSH_BLBI_CURR");}catch{}
//				try{DDL_WATCH_LIST.SelectedValue =  conn.GetFieldValue("WATCH_LIST");}catch{}
//				TXT_KMK_LMT_BM_CURR.Text  =  tool.MoneyFormat(conn.GetFieldValue("KMK_LMT_BM_CURR"));
//				try{DDL_KEY_BM_COLL.SelectedValue =  conn.GetFieldValue("KEY_BM_COLL");}catch{}
//				try{DDL_KEY_BM_BL.SelectedValue =  conn.GetFieldValue("KEY_BM_BL");}catch{}
//				TXT_KEY_BM_COLL_2C.Text =  conn.GetFieldValue("KEY_BM_COLL_2C");
//				try{DDL_KEY_BI_BM.SelectedValue =  conn.GetFieldValue("KEY_BI_BM");}catch{}
//				try{DDL_KEY_BI_COLL_LVL.SelectedValue =  conn.GetFieldValue("KEY_BI_COLL_LVL");}catch{}
//				try{DDL_MGM_BM_COLL_CURR.SelectedValue =  conn.GetFieldValue("MGM_BM_COLL_CURR");}catch{}
//				TXT_MGM_BM_COLL_2C.Text  =  conn.GetFieldValue("MGM_BM_COLL_2C");
//				try{DDL_MGM_BLBI.SelectedValue =  conn.GetFieldValue("MGM_BLBI");}catch{}
//				try{DDL_MGM_BI_COLL_LVL.SelectedValue  =  conn.GetFieldValue("MGM_BI_COLL_LVL");}catch{}
//				TXT_NUM_APP_COLL_12_3PLUS.Text = conn.GetFieldValue("NUM_APP_COLL_12_3PLUS");
			}
		}

		protected void BTN_SAVE_Click(object sender, System.EventArgs e)
		{
			if (TXT_MULAI_BM_YY.Text.Length<4)
			{
				GlobalTools.popMessage(this,"Tahun harus diisi empat angka.");
				return;
			}

			if (inputIsValid()) 
			{
				saveHubBank();
				Session["SaveHub"]="1";
			}
		}

		string toZerro(string par)
		{
			if (par.Trim()=="")
				return "0";
			else
			{
				try
				{
					float.Parse(par);
					return par;
				} 
				catch
				{return "0";}
			}
		}


		private void saveHubBank()
		{
			conn.QueryString="exec scoring_hubbank_sp '1','" +
			Request.QueryString["regno"] + "','" + 
			DDL_FACKREDIT.SelectedValue  + "'," + 
			tool.ConvertFloat(TXT_LMT_CREDIT_CURR_MILL.Text) + "," +  
			tool.ConvertFloat(TXT_LMT_CREDIT_CURR.Text) + "," +  
			tool.ConvertFloat(TXT_TTL_EXP_MILL.Text) + "," +  
			tool.ConvertFloat(TXT_TTL_EXP.Text) + ",'" +  
			DDL_BUSINESS_CURR_BM.SelectedValue  + "','" +  
			DDL_BUSINESS_PAST_BM.SelectedValue  + "'," +  
			tool.ConvertFloat(TXT_MULAI_BM_MM.Text) + "," +  
			tool.ConvertFloat(TXT_MULAI_BM_YY.Text) + ",'" +  
			DDL_APP_BI_COLL_CURR.SelectedValue  + "','" +  
			DDL_APP_BM_COLL_CURR.SelectedValue  + "','" +  
			DDL_BUSINESS_BM_COLL_W12.SelectedValue  + "'," + 
			tool.ConvertFloat(TXT_NUM_APP_COLL_12_2A.Text) + "," +  
			tool.ConvertFloat(TXT_NUM_APP_COLL_12_2B.Text) + "," +  
			tool.ConvertFloat(TXT_NUM_APP_COLL_12_2C.Text) + ",'" +  
			DDL_PERUSH_BLBM_CURR.SelectedValue  + "','" +  
			DDL_PERUSH_BLBI_CURR.SelectedValue  + "','" +  
			DDL_WATCH_LIST.SelectedValue  + "'," +  
			tool.ConvertFloat(TXT_KMK_LMT_BM_CURR.Text) + ",'" +  
			DDL_KEY_BM_COLL.SelectedValue   + "','" +  
			DDL_KEY_BM_BL.SelectedValue   + "'," +  
			tool.ConvertFloat(TXT_KEY_BM_COLL_2C.Text)    + ",'" +  
			DDL_KEY_BI_BM.SelectedValue   + "','" +  
			DDL_KEY_BI_COLL_LVL.SelectedValue   + "','" +  
			DDL_MGM_BM_COLL_CURR.SelectedValue   + "'," +  
			tool.ConvertFloat(TXT_MGM_BM_COLL_2C.Text)    + ",'" +  
			DDL_MGM_BLBI.SelectedValue   + "','" +  
			DDL_MGM_BI_COLL_LVL.SelectedValue + "','" +
			DDL_MGM_BLBM.SelectedValue + "'," +
			tool.ConvertFloat(TXT_NUM_APP_COLL_12_3PLUS.Text) + ", '" + 
			DDL_APP_BI_COLL_CURR_12BLN.SelectedValue + "', '" + 
			DDL_KEY_BI_COLL_LVL_12BLN.SelectedValue + "', '" +
			DDL_MGM_BI_COLL_LVL_12BLN.SelectedValue + "'";
			conn.ExecuteNonQuery();			
		}

		protected void DDL_BUSINESS_BM_COLL_W12_SelectedIndexChanged(object sender, System.EventArgs e)
		{
		
		}

		protected void DDL_PERUSH_BLBI_CURR_SelectedIndexChanged(object sender, System.EventArgs e)
		{
		
		}

		protected void DDL_APP_BM_COLL_CURR_SelectedIndexChanged(object sender, System.EventArgs e)
		{
		
		}

	}
}
