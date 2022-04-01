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
using System.Configuration;

namespace SME.CreditAnalysis
{
	/// <summary>
	/// Summary description for MainCreditAnalysis.
	/// </summary>
	public partial class MainCreditAnalysis : System.Web.UI.Page
	{
		protected Tools tool = new Tools();
		protected Connection conn;

		/* *********************
		 * ToDo List: 
		 * Set Update Status Button to Hidden initially 
		 * *********************
		 */

		protected void Page_Load(object sender, System.EventArgs e)
		{
			conn = (Connection) Session["Connection"];

			if (!Logic.AllowAccess(Session["GroupID"].ToString(), Request.QueryString["mc"], conn))
				Response.Redirect("/SME/Restricted.aspx");
			
			InitializeEvent();

			if (!IsPostBack)
			{
				DDL_BU_COMMENTS.Items.Add(new ListItem("- PILIH -", ""));
				//DDL_AUDITORID.Items.Add(new ListItem("- PILIH -", ""));

				conn.QueryString = "select kondisiid, kondisidesc from rfkondisi where active='1'";
				conn.ExecuteQuery();
				for (int i = 0; i < conn.GetRowCount(); i++)
					DDL_BU_COMMENTS.Items.Add(new ListItem(conn.GetFieldValue(i,1), conn.GetFieldValue(i,0)));

				/*
				conn.QueryString = "select AUDITORID, AUDITORNAME from RFAUDITOR where ACTIVE = '1'";
				conn.ExecuteQuery();
				for (int i = 0; i < conn.GetRowCount(); i++)sdfsadfs
					DDL_AUDITORID.Items.Add(new ListItem(conn.GetFieldValue(i,1), conn.GetFieldValue(i,0)));
				*/

				ViewDataApplication();

				//conn.QueryString = "select distinct ap_currtrack from apptrack where ap_regno='" + Request.QueryString["regno"] + "'";
				conn.QueryString = "select distinct ap_currtrack from apptrack where ap_regno='" + Request.QueryString["regno"] + "' and ap_currtrack is not null";
				conn.ExecuteQuery();
				for (int i = 0; i < conn.GetRowCount(); i++)
				{
					if (conn.GetFieldValue(0,0) == Request.QueryString["tc"])
					{
						BTN_UPDATESTATUS.Visible = true;
						break;
					}
				}				
				
				////////////////////////////////////////////////////////////////
				/// menaruh programid dan jenisnasabah di session untuk
				/// kebutuhan submenu
				/// 				
				string vjnsnasabah; 
				string vprgid;
					
				conn.QueryString = "select distinct top 1 cu_jnsnasabah from customer where cu_ref in (Select cu_ref from application where ap_regno = '" + Request.QueryString["regno"] + "')";
				conn.ExecuteQuery();
				vjnsnasabah = conn.GetFieldValue("cu_jnsnasabah").ToString();
					
				conn.QueryString = "select distinct top 1 programid from rfprogram where programid in (select prog_code from application where ap_regno = '"+Request.QueryString["regno"]+ "')";
				conn.ExecuteQuery();
				vprgid = conn.GetFieldValue("programid").ToString();
					
				Session.Add("programid", vprgid);
				Session.Add("jnsnasabah", vjnsnasabah);					
				//////////////////////////////////////////////////////////////////
			}	

			ViewMenu();
			ViewSubMenu();
			secureData();

			//BTN_UPDATESTATUS.Attributes.Add("onclick","if(!update()){return false;};");
			BTN_UPDATESTATUS.Attributes.Add("onclick","if(!updateMsg('D')){return false;};");

            /*
            conn.QueryString = "SELECT AP_BUSINESSUNIT FROM APPLICATION WHERE AP_REGNO = '" + lbl_regno.Text + "'";
            conn.ExecuteQuery();
            string segment = conn.GetFieldValue(0, 0);
            if (ConfigurationManager.AppSettings["IsCAS-" + segment] == "YES")
            {
                SubMenu.Visible = false;
            }
            else
            {
                SubMenu.Visible = true;
            }
            */
		}

		private void secureData() 
		{
			if (Request.QueryString["ca"]=="0") 
			{
				TXT_AUDITORID.ReadOnly = true;
				TXT_AUDITORID.BorderStyle = BorderStyle.None;
				DDL_BU_COMMENTS.Enabled = false;
			}
		}

		private void InitializeEvent()
		{
			this.BTN_BACK.Click += new System.Web.UI.ImageClickEventHandler(this.BTN_BACK_Click);
			this.BTN_UPDATESTATUS.Click += new EventHandler(BTN_UPDATESTATUS_Click);
			this.BTN_SAVE.Click += new EventHandler(BTN_SAVE_Click);
		}

		private void ViewMenu()
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
//						if (conn.GetFieldValue(i,3).IndexOf("mc=") >= 0)
//							strtemp = "regno=" + Request.QueryString["regno"] + "&curef="+Request.QueryString["curef"]+"&tc="+Request.QueryString["tc"];
//						else	
//							strtemp = "regno=" + Request.QueryString["regno"] + "&curef="+Request.QueryString["curef"]+"&mc="+Request.QueryString["mc"]+"&tc="+Request.QueryString["tc"];
//						//t.ForeColor = Color.MidnightBlue; 
						if (conn.GetFieldValue(i,3).IndexOf("mc=") >= 0)
							//strtemp = "regno=" + Request.QueryString["regno"] + "&curef="+Request.QueryString["curef"]+"&tc="+Request.QueryString["tc"];
							strtemp = "regno=" + Request.QueryString["regno"] + "&curef="+Request.QueryString["curef"]+"&tc="+Request.QueryString["tc"]+"&jnsnasabah="+Request.QueryString["jnsnasabah"]+"&programid="+Request.QueryString["programid"];
						else	
							//strtemp = "regno=" + Request.QueryString["regno"] + "&curef="+Request.QueryString["curef"]+"&mc="+Request.QueryString["mc"]+"&tc="+Request.QueryString["tc"];
							strtemp = "regno=" + Request.QueryString["regno"] + "&curef="+Request.QueryString["curef"]+"&mc="+Request.QueryString["mc"]+"&tc="+Request.QueryString["tc"]+"&jnsnasabah="+Request.QueryString["jnsnasabah"]+"&programid="+Request.QueryString["programid"];
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
			
		private void ViewSubMenu()
		{
			try 
			{
				string sProgramID,sJnsNasabah;

				conn.QueryString = "select distinct top 1 cu_jnsnasabah from customer where cu_ref in (Select cu_ref from application where ap_regno = '"+Request.QueryString["regno"]+ "')";
				conn.ExecuteQuery();
				sJnsNasabah = conn.GetFieldValue("cu_jnsnasabah").ToString();
				//------------------------------------------------------------------------------
					
				conn.QueryString = "select distinct top 1 programid from rfprogram where programid in (select prog_code from application where ap_regno = '"+Request.QueryString["regno"]+ "')";
				conn.ExecuteQuery();
				sProgramID = conn.GetFieldValue("programid").ToString();

				//conn.QueryString = "select * from screensubmenu where lg_code in (select distinct lg_code from rfcafinstatement where programid = '"+Request.QueryString["programid"]+"' and nasabahid = '" +Request.QueryString["jnsnasabah"]+"') and menucode = '" +Request.QueryString["mc"]+ "' and programid = '"+Request.QueryString["programid"]+"'";
				conn.QueryString = "select * from screensubmenu where lg_code in (select distinct lg_code from rfcafinstatement where programid = '"+sProgramID+"' and nasabahid = '" +sJnsNasabah+"') and menucode = '" +Request.QueryString["mc"]+ "' and programid = '"+sProgramID+"'";
				conn.ExecuteQuery();
				for (int i = 0; i < conn.GetRowCount(); i++) 
				{
					HyperLink t = new HyperLink();
					t.Text = conn.GetFieldValue(i, 4);
					string strtemp = "";
					strtemp = "regno=" + Request.QueryString["regno"]+ 
						"&curef="+Request.QueryString["curef"]+
						"&mc="+Request.QueryString["mc"]+
                        "&jnsnasabah="+Request.QueryString["jnsnasabah"]+
						"&programid="+Request.QueryString["programid"]+
						"&tc="+Request.QueryString["tc"]+
						"&ca="+Request.QueryString["ca"];
					t.NavigateUrl = conn.GetFieldValue(i, 5)+strtemp;
					SubMenu.Controls.Add(t);
					SubMenu.Controls.Add(new LiteralControl("&nbsp;&nbsp;&nbsp;"));
				}
			} 
			catch (NullReferenceException)
			{
				Tools.popMessage(this, "Connection Error !");
				return;
			}
		}

		private void hitungInstallment() 
		{
			///
			/// HITUNG INSTALLMENT PER APLIKASI
			/// 

			/// Looping dalam aplikasi tersebut per ketentuan kredit
			/// 
			conn.QueryString = "select PRODUCTID, KET_CODE from KETENTUAN_KREDIT where AP_REGNO = '" + lbl_regno.Text + "'";
			conn.ExecuteQuery();
			DataTable dt = conn.GetDataTable();
			double vInstallment = 0;

			Hashtable ht = new Hashtable();			

			/// Kumpulkan dulu installmentnya (per ketentuan kredit) ....
			/// 
			for(int i=0; i<dt.Rows.Count; i++)
			{
				// get installment
				vInstallment = this.getInstallmentValue(dt.Rows[i]["PRODUCTID"].ToString(), dt.Rows[i]["KET_CODE"].ToString());

				// kumpulkan installment
				ht.Add(dt.Rows[i]["KET_CODE"], vInstallment);
			}


			/// Lalu update installment into database
			/// 
			try 
			{				
				IDictionaryEnumerator myEnumerator = ht.GetEnumerator();
				while ( myEnumerator.MoveNext() ) 
				{
					conn.QueryString = "exec CA_HITUNGINSTALLMENT '" + myEnumerator.Key + "', " + tool.ConvertFloat(myEnumerator.Value.ToString()) + "";
					conn.ExecTrans();
				}

				conn.ExecTran_Commit();
			} 
			catch 
			{
				conn.ExecTran_Rollback();
			}
		}

		private double getInstallmentValue(string productID, string ket_code)
		{
			/// PERLU DIPERHATIKAN : Untuk menghitung installment, jenis aplikasi diperhatikan.
			/// o Kalau dalam 1 ketentuan kredit hanya mencakup RENEWAL saja, perhatikan jenis tenornya (Tenor / Maturity Date).
			///   Kalau Maturity Date, maka tenornya adalah Maturity Date - Current Date
			/// o Kalau dalam 1 ketentuan kredit hanya mencakup PERUBAHAN LIMIT saja, maka Tenornya adalah 
			///   Maturity Date di BookedCust - Current Date
			///   

			double result = 0;
			string vISINSTALLMENT = "";

			/// Mengambil flag installment untuk facility yang dipilih
			/// 
			conn.QueryString = "select calcmethod, isinstallment from rfproduct where productid = '" + productID + "'";
			conn.ExecuteQuery();
			vISINSTALLMENT = conn.GetFieldValue("isinstallment");

			/// Mengambil limit (menggunakan stored procedure yang dipakai di scoring bcg)
			/// Mengambil Tenor
			/// Mengambil interest
			/// 
			conn.QueryString = "exec IDE_LOANINFO_GETINSTALLMENT '" + Request.QueryString["regno"] + 
				"', '" + Request.QueryString["curef"] + 
				"', '" + ket_code + "'";
			conn.ExecuteQuery();
			string vEXLIMITVAL, vCP_INTEREST, vTENOR;
			vEXLIMITVAL = "0.00";
			vCP_INTEREST = "0.00";
			vTENOR = "0.00";

			if (vISINSTALLMENT == "1") // installment
			{
				vEXLIMITVAL  = conn.GetFieldValue("CP_EXLIMITVAL").ToString().Trim();				
				vCP_INTEREST = conn.GetFieldValue("CP_INTEREST").ToString().Trim();
				vTENOR       = conn.GetFieldValue("TENOR").ToString().Trim();
				try { result = DMS.CuBESCore.Logic.hitungInstalment(double.Parse(vEXLIMITVAL), int.Parse(vTENOR), double.Parse(vCP_INTEREST), productID, "M", conn); } 
				catch {}
			}
			else if (vISINSTALLMENT == "0") // bukan installment
			{
				try { result = double.Parse(vCP_INTEREST) / 100 * double.Parse(vEXLIMITVAL) / 12; } 
				catch {}
			}

			return result;
		}

		private void setProyeksiRatioApp(string ap_regno, string ap_businessunit) 
		{
			conn.QueryString = "exec CA_RECOUNTPROYEKSIRATIO '" + ap_regno + "', '" + ap_businessunit + "'";
			conn.ExecuteNonQuery();
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

		private void ViewDataApplication()
		{
			lbl_regno.Text		= Request.QueryString["regno"];
			lbl_curef.Text		= Request.QueryString["curef"];

            conn.QueryString = "SELECT IN_SMALL, IN_MIDDLE, IN_CORPORATE, IN_MICRO FROM RFINITIAL";
            conn.ExecuteQuery();

            //string m_in_small = conn.GetFieldValue("in_small");
            //string m_in_middle = conn.GetFieldValue("in_middle");
            //string m_in_corp = conn.GetFieldValue("in_corporate");

            string mInMicro = conn.GetFieldValue("IN_SMALL");
            string mInSmall = conn.GetFieldValue("IN_MIDDLE");
            string mInCorp = conn.GetFieldValue("IN_CORPORATE");
            string mInCons = conn.GetFieldValue("IN_MICRO");

			//
			//	mendapatkan status acquire information
			//
            conn.QueryString = "select ISNULL(AP_ACQINFOBY,'') as AP_ACQINFOBY, AP_BUSINESSUNIT from APPLICATION where AP_REGNO = '" + lbl_regno.Text + "'";
			conn.ExecuteQuery();
			string AP_ACQINFOBY = conn.GetFieldValue("AP_ACQINFOBY");
            string AP_BUSINESSUNIT = conn.GetFieldValue("AP_BUSINESSUNIT");

            //CAS PUNDI ----------------------------------------------------------------------------------
            //HyperLink strCAS = new HyperLink();
            //strCAS.Text = "CAS";
            //strCAS.Font.Bold = true;
            //strCAS.NavigateUrl = "PUNDI_CAS.aspx?regno=" + lbl_regno.Text + "&curef=" + lbl_curef.Text;
            //strCAS.NavigateUrl = strCAS.NavigateUrl + "&ca=" + Request.QueryString["ca"];
            //strCAS.Target = "if2";
            //CAS PUNDI END ----------------------------------------------------------------------------------
            //CAS PUNDI ----------------------------------------------------------------------------------
            //conn.QueryString = "SELECT AP_BUSINESSUNIT FROM APPLICATION WHERE AP_REGNO = '" + lbl_regno.Text + "'";
            //conn.ExecuteQuery();
            //string segment = conn.GetFieldValue(0, 0);
            //if (ConfigurationManager.AppSettings["IsCAS-" + segment] == "YES")
            //{
            //    PlaceHolder1.Controls.Add(strCAS);
            //    PlaceHolder1.Controls.Add(new LiteralControl("&nbsp;&nbsp;"));
            //}
            //CAS PUNDI END----------------------------------------------------------------------------------

            HyperLink strcre = new HyperLink();
            strcre.Text = "Upload File";
            strcre.Font.Bold = true;
            strcre.NavigateUrl = "UploadFile.aspx?regno=" + lbl_regno.Text + "&curef=" + lbl_curef.Text;
            strcre.NavigateUrl = strcre.NavigateUrl + "&ca=" + Request.QueryString["ca"];
            strcre.Target = "if2";

            PlaceHolder1.Controls.Add(strcre);
            PlaceHolder1.Controls.Add(new LiteralControl("&nbsp;&nbsp;"));

			if (AP_ACQINFOBY != "") 
			{
				HyperLink acqInfo = new HyperLink();
				acqInfo.Text = "Acquire Information";
				acqInfo.Font.Bold = true;
				acqInfo.NavigateUrl = "../Approval/AcqInfo.aspx?regno=" + lbl_regno.Text + "&curef=" + lbl_curef.Text + "&sta=view";
				acqInfo.Target = "if2";

                
				PlaceHolder1.Controls.Add(acqInfo);
                PlaceHolder1.Controls.Add(new LiteralControl("&nbsp;&nbsp;"));
			}

            if (AP_BUSINESSUNIT == mInMicro)
            {
                //SubMenu.Visible = false;
                
                HyperLink strCAS = new HyperLink();
                strCAS.Text = "CAS Analysis";
                strCAS.Font.Bold = true;
                strCAS.NavigateUrl = "PUNDI_CAS.aspx?regno=" + lbl_regno.Text + "&curef=" + lbl_curef.Text;
                strCAS.NavigateUrl = strCAS.NavigateUrl + "&ca=" + Request.QueryString["ca"];
                strCAS.Target = "if2";

                PlaceHolder1.Controls.Add(strCAS);
                PlaceHolder1.Controls.Add(new LiteralControl("&nbsp;&nbsp;"));
            }

            if (AP_BUSINESSUNIT == mInCons)
            {
                //SubMenu.Visible = false;
                
                HyperLink strDSR = new HyperLink();
                strDSR.Text = "DSR Analysis";
                strDSR.Font.Bold = true;
                strDSR.NavigateUrl = "PerhitunganDSR.aspx?regno=" + lbl_regno.Text + "&curef=" + lbl_curef.Text;
                strDSR.NavigateUrl = strDSR.NavigateUrl + "&ca=" + Request.QueryString["ca"];
                strDSR.Target = "if2";

                PlaceHolder1.Controls.Add(strDSR);
                PlaceHolder1.Controls.Add(new LiteralControl("&nbsp;&nbsp;"));
            }

			/*
			HyperLink strcre = new HyperLink();
			strcre.Text = "Upload File";
			strcre.Font.Bold = true;
			strcre.NavigateUrl = "UploadFile.aspx?regno="+lbl_regno.Text+"&curef="+lbl_curef.Text;
			strcre.NavigateUrl = strcre.NavigateUrl + "&ca=" + Request.QueryString["ca"];
			strcre.Target = "if2";
	
			HyperLink collateral = new HyperLink();
			collateral.Text = "Ratio";
			collateral.Font.Bold = true;
			collateral.NavigateUrl = "InputRatio.aspx?regno="+lbl_regno.Text+"&curef="+lbl_curef.Text;
			collateral.NavigateUrl = collateral.NavigateUrl + "&ca=" + Request.QueryString["ca"];
			collateral.Target = "if2";

			PlaceHolder1.Controls.Add(strcre);
			PlaceHolder1.Controls.Add(new LiteralControl("&nbsp;&nbsp;"));
			PlaceHolder1.Controls.Add(collateral);
			*/
			conn.QueryString = "select DISTINCT * from VW_CA_MAIN where AP_REGNO = '" +Request.QueryString["regno"]+ "'";
			conn.ExecuteQuery();
			TXT_AP_REGNO.Text		= conn.GetFieldValue("AP_REGNO");
			TXT_CU_REF.Text			= conn.GetFieldValue("CU_REF");
			TXT_AP_SIGNDATE.Text	= tool.FormatDate(conn.GetFieldValue("AP_SIGNDATE"));
			TXT_PROGRAMDESC.Text	= conn.GetFieldValue("PROGRAMDESC");
			TXT_BRANCH_NAME.Text	= conn.GetFieldValue("BRANCH_NAME");
			TXT_AP_RELMNGR.Text		= conn.GetFieldValue("SU_FULLNAME");
			LBL_CU_CUSTTYPEID.Text	= conn.GetFieldValue("CU_CUSTTYPEID");
			TXT_AP_BUSINESSUNIT.Text	= conn.GetFieldValue("AP_BUSINESSUNIT");
			TXT_AP_TEAMLEADER.Text		= conn.GetFieldValue("AP_TEAMLEADER");
			//DDL_AUDITORID.SelectedValue   = conn.GetFieldValue("AUDITORID");
			TXT_AUDITORID.Text		= conn.GetFieldValue("AUDITORID");
			try { DDL_BU_COMMENTS.SelectedValue = conn.GetFieldValue("BU_COMMENTS"); } 
			catch {}
			ViewDataCustomer();
			ViewValue();
		}

		private void ViewDataCustomer()
		{
			if (LBL_CU_CUSTTYPEID.Text == "01") //if company
			{
				conn.QueryString = "select * from VW_CUST_COMPANY where CU_REF = '" +Request.QueryString["curef"]+ "'";
				conn.ExecuteQuery();
				TXT_NAME.Text = conn.GetFieldValue("COMPTYPEDESC").Trim()+" "+conn.GetFieldValue("CU_COMPNAME").Trim();
				TXT_ADDRESS1.Text		= conn.GetFieldValue("CU_COMPADDR1");
				TXT_ADDRESS2.Text		= conn.GetFieldValue("CU_COMPADDR2");
				TXT_ADDRESS3.Text		= conn.GetFieldValue("CU_COMPADDR3");
				TXT_CITY.Text			= conn.GetFieldValue("CITYNAME");
				TXT_PHONENUM.Text		= conn.GetFieldValue("CU_COMPPHNAREA").Trim() + " - "+conn.GetFieldValue("CU_COMPPHNNUM").Trim();
				TXT_BUSINESSTYPE.Text	= conn.GetFieldValue("BUSSTYPEDESC");
			}
			else //if personal
			{
				conn.QueryString = "select * from VW_CUST_PERSONAL where CU_REF = '" +Request.QueryString["curef"]+ "'";
				conn.ExecuteQuery();
				TXT_NAME.Text			= conn.GetFieldValue("CU_FIRSTNAME").Trim()+ " "+conn.GetFieldValue("CU_MIDDLENAME").Trim()+" "+conn.GetFieldValue("CU_LASTNAME").Trim();
				TXT_ADDRESS1.Text		= conn.GetFieldValue("CU_ADDR1");
				TXT_ADDRESS2.Text		= conn.GetFieldValue("CU_ADDR2");
				TXT_ADDRESS3.Text		= conn.GetFieldValue("CU_ADDR3");
				TXT_CITY.Text			= conn.GetFieldValue("CITYNAME");
				TXT_PHONENUM.Text		= conn.GetFieldValue("CU_PHNAREA").Trim() + " - "+conn.GetFieldValue("CU_PHNNUM").Trim();
				TXT_BUSINESSTYPE.Text	= conn.GetFieldValue("BUSSTYPEDESC");
			}
		}

		private void ViewValue()
		{
//			conn.QueryString = "select sum(CP_LIMIT) TCP_LIMIT from CUSTPRODUCT  where AP_REGNO = '"+Request.QueryString["regno"].Trim()+"'";
//			conn.ExecuteQuery();
//			TXT_APPVALUE.Text	= tool.MoneyFormat(conn.GetFieldValue("TCP_LIMIT").ToString());

			/////////////////////////////////////////////////////////
			///	Menghitung ulang Total Application Value 			
			///	
			conn.QueryString = "DE_TOTALEXPOSURE '" + lbl_regno.Text + "'";
			conn.ExecuteQuery(300);			
			TXT_APPVALUE.Text = tool.MoneyFormat(conn.GetFieldValue("tot_limit"));



			conn.QueryString = "select sum(LC_VALUE) TLC_VALUE from LISTCOLLATERAL where AP_REGNO = '"+Request.QueryString["regno"].Trim()+"'";
			conn.ExecuteQuery();
			TXT_COLLVALUE.Text	= tool.MoneyFormat(conn.GetFieldValue("TLC_VALUE").ToString());
		}

		private void BTN_UPDATESTATUS_Click(object sender, System.EventArgs e)
		{
			conn.QueryString = "exec CA_CHECKMANDATORY '" + Request.QueryString["regno"] + "' ";
			conn.ExecuteQuery();
			if (conn.GetFieldValue(0,0) != "0")
			{//lacking something
				if (conn.GetFieldValue(0,1) != "")
					GlobalTools.popMessage(this, conn.GetFieldValue(0,1));
				return;
			}

			/// Pastikan APP_PROYEKSIRATIO terisi
			/// 
			setProyeksiRatioApp(lbl_regno.Text, (string) Session["BussUnit"]);

			////////////////////////////////
			///	RESET AP_ACQINFOBY
			///	
			conn.QueryString = "update application set ap_acqinfoby = null where ap_regno = '" + lbl_regno.Text + "'";
			conn.ExecuteNonQuery();
			////////////////////////////////
			

			/// Menghitung (ulang) installment
			/// 
			hitungInstallment();



			DataTable dt;
			conn.QueryString = "select apptype, productid, PROD_SEQ from custproduct  where ap_regno='" + Request.QueryString["regno"] +
				"' AND isnull(cp_reject,'0') <> '1' and isnull(cp_cancel,'0') <> '1'";
			conn.ExecuteQuery();
			dt = conn.GetDataTable().Copy();
			for (int i = 0; i < dt.Rows.Count; i++)
			{
				//exec trackupdate AP_REGNO, PRODUCTID, APPTYPE, USERID, PROD_SEQ
				conn.QueryString = "exec TRACKUPDATE '" + 
					Request.QueryString["regno"] + "', '" +
					dt.Rows[i][1].ToString() + "', '" + 
					dt.Rows[i][0].ToString() + "', '" + 
					Session["UserID"].ToString() + "', '" + 
					dt.Rows[i]["PROD_SEQ"].ToString() + "','"+Request.QueryString["tc"].Trim()+"'";
				conn.ExecuteNonQuery();
			}

			string msg = getNextStepMsg(Request.QueryString["regno"]);
			Response.Redirect("ListCreditAnalysis.aspx?tc=" + Request.QueryString["tc"] + "&mc=" + Request.QueryString["mc"] + "&msg=" + msg);
		}

		private string getNextStepMsg(string regno) 
		{
			string pesan = "";
			string nextTrack = "";
			try 
			{
				/***
				 * Memunculkan pesan next step
				 ***/
				conn.QueryString = "exec TRACKNEXTMSG '" + regno + "'";
				conn.ExecuteQuery();
				nextTrack = conn.GetFieldValue("TRACKNAME");
				pesan = "Application proceeds to " + nextTrack;
				/***********************************/
			} 
			catch 
			{
				throw new Exception();
			}
			return pesan;
		}

		private void BTN_BACK_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			string backlink = "Body.aspx";

			backlink = DMS.CuBESCore.Logic.backLink(Request.QueryString["tc"].ToString(), Request.QueryString["mc"].ToString(), conn);

			if (Request.QueryString["tc"] == null && Request.QueryString["tc"] == "")
				Response.Redirect("/SME/Approval/ListApproval.aspx?mc=" + Request.QueryString["mc"]);
			else
				Response.Redirect("/SME/" + backlink);
		}

		private void BTN_SAVE_Click(object sender, System.EventArgs e)
		{
			conn.QueryString = "exec CA_MAIN '"+ Request.QueryString["regno"] +"', '" +TXT_AUDITORID.Text+ "', '" +DDL_BU_COMMENTS.SelectedValue+ "'";
			conn.ExecuteQuery();
			ViewDataApplication();
		}
	}
}
