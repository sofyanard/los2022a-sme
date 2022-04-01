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

namespace SME.LOW
{
	/// <summary>
	/// Summary description for LOWCustomerInfo.
	/// </summary>
	public partial class LOWCustomerInfo : System.Web.UI.Page
	{
		protected Connection conn;
		protected Tools tool = new Tools();
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			if (!IsPostBack)
			{
				conn = (Connection) Session["Connection"];
				conn.QueryString = "SELECT CU_RM FROM CUSTOMER WHERE CU_REF = '" + Request.QueryString["curef"] + "'";
				conn.ExecuteQuery();

				RDO_RFCUSTOMERTYPE.Enabled = false;	

				if (!Logic.AllowAccess(Session["GroupID"].ToString(), Request.QueryString["mc"], conn))
					Response.Redirect("/SME/Restricted.aspx");

				if (!IsPostBack)
				{
					DDL_CU_BUSSTYPE.Items.Add(new ListItem("- PILIH -", ""));
					DDL_CU_COMPBUSSTYPE.Items.Add(new ListItem("- PILIH -", ""));
					DDL_CU_DOB_MONTH.Items.Add(new ListItem("- PILIH -", ""));
					DDL_CU_IDCARDEXP_MONTH.Items.Add(new ListItem("- PILIH -", ""));
					DDL_CU_COMPTYPE.Items.Add(new ListItem("- PILIH -", ""));
					DDL_CU_JOBTITLE.Items.Add(new ListItem("- PILIH -", ""));
					DDL_CU_MARITAL.Items.Add(new ListItem("- PILIH -", ""));
					DDL_CU_SEX.Items.Add(new ListItem("- PILIH -", ""));
					DDL_CU_CITIZENSHIP.Items.Add(new ListItem("- PILIH -", ""));
					DDL_JNSALAMAT_C.Items.Add(new ListItem("- PILIH -", ""));
					DDL_JNSALAMAT_P.Items.Add(new ListItem("- PILIH -", ""));
					DDL_CU_JNSNASABAH.Items.Add(new ListItem("- PILIH -", ""));
					DDL_CU_EDUCATION.Items.Add(new ListItem("- PILIH -", ""));
					DDL_bmsektor.Items.Add(new ListItem("- PILIH -", ""));
					DDL_bmsubsektor.Items.Add(new ListItem("- PILIH -", ""));
					DDL_bmsubsubsektor.Items.Add(new ListItem("- PILIH -", ""));

					//2010-04-08 Enhancement 2010
					DDL_CU_LOKASIDATI2.Items.Add(new ListItem("- PILIH -", ""));
					DDL_CU_HUBEXECBM.Items.Add(new ListItem("- PILIH -", ""));
					DDL_CU_COMPEXTRATING_BY.Items.Add(new ListItem("- PILIH -", ""));
					DDL_CU_COMPLISTINGCODE.Items.Add(new ListItem("- PILIH -", ""));
					DDL_CU_NEGARADOMISILI.Items.Add(new ListItem("- PILIH -", ""));

					for (int i = 1; i <= 12; i++)
					{
						DDL_CU_DOB_MONTH.Items.Add(new ListItem(DateAndTime.MonthName(i, false), i.ToString()));
						DDL_CU_IDCARDEXP_MONTH.Items.Add(new ListItem(DateAndTime.MonthName(i, false), i.ToString()));
					}

					GlobalTools.fillRefList(DDL_CU_HOMESTA, "select * from RFHOMESTA where ACTIVE='1'", true, conn);
					GlobalTools.initDateForm(TXT_CU_SPOUSE_KTPISSUEDATE_DAY, DDL_CU_SPOUSE_KTPISSUEDATE_MONTH, TXT_CU_SPOUSE_KTPISSUEDATE_YEAR, true);
					GlobalTools.initDateForm(TXT_CU_SPOUSE_KTPEXPDATE_DAY, DDL_CU_SPOUSE_KTPEXPDATE_MONTH, TXT_CU_SPOUSE_KTPEXPDATE_YEAR, true);
				
					conn.QueryString = "select custtypeid, custtypedesc from rfcustomertype where active='1'";
					conn.ExecuteQuery();
					for (int i = 0; i < conn.GetRowCount(); i++)
						RDO_RFCUSTOMERTYPE.Items.Add(new ListItem(conn.GetFieldValue(i,1), conn.GetFieldValue(i,0)));

					conn.QueryString = "select ALAMATID, ALAMATID + ' - ' + ALAMATDESC as ALAMATDESC from RFJENISALAMAT where ACTIVE='1' order by ALAMATID";
					conn.ExecuteQuery();
					for (int i = 0; i < conn.GetRowCount(); i++)
					{
						DDL_JNSALAMAT_C.Items.Add(new ListItem(conn.GetFieldValue(i,1), conn.GetFieldValue(i,0)));
						DDL_JNSALAMAT_P.Items.Add(new ListItem(conn.GetFieldValue(i,1), conn.GetFieldValue(i,0)));
					}

					RDO_RFCUSTOMERTYPE.SelectedIndex = 0;
					TR_PERSONAL.Visible = false;	TR_COMPANY.Visible = true;

					conn.QueryString = "select sexid, sexdesc from rfsex where active='1'";
					conn.ExecuteQuery();
					for (int i = 0; i < conn.GetRowCount(); i++)
						DDL_CU_SEX.Items.Add(new ListItem(conn.GetFieldValue(i,1), conn.GetFieldValue(i,0)));

					conn.QueryString = "select maritalid, maritaldesc from rfmarital where active='1'";
					conn.ExecuteQuery();
					for (int i = 0; i < conn.GetRowCount(); i++)
						DDL_CU_MARITAL.Items.Add(new ListItem(conn.GetFieldValue(i,1), conn.GetFieldValue(i,0)));

					conn.QueryString = "select jobtitleid, jobtitledesc from rfjobtitle where active='1'";
					conn.ExecuteQuery();
					for (int i = 0; i < conn.GetRowCount(); i++)
						DDL_CU_JOBTITLE.Items.Add(new ListItem(conn.GetFieldValue(i,1), conn.GetFieldValue(i,0)));

					conn.QueryString = "select BUSSTYPEID, BUSSTYPEID + ' - ' + BUSSTYPEDESC as BUSSTYPEDESC from RFBUSINESSTYPE where ACTIVE='1' AND LEN(BUSSTYPEID) < 3 order by BUSSTYPEID";
					conn.ExecuteQuery();
					for (int i = 0; i < conn.GetRowCount(); i++)
					{
						DDL_CU_BUSSTYPE.Items.Add(new ListItem(conn.GetFieldValue(i,1), conn.GetFieldValue(i,0)));
						DDL_CU_COMPBUSSTYPE.Items.Add(new ListItem(conn.GetFieldValue(i,1), conn.GetFieldValue(i,0)));
					}

					conn.QueryString = "select comptypeid, comptypedesc from rfcomptype where active='1'";
					conn.ExecuteQuery();
					for (int i = 0; i < conn.GetRowCount(); i++)
						DDL_CU_COMPTYPE.Items.Add(new ListItem(conn.GetFieldValue(i,1), conn.GetFieldValue(i,0)));

					conn.QueryString = "select citizenid, citizendesc from rfcitizenship where active='1'";
					conn.ExecuteQuery();
					for (int i = 0; i < conn.GetRowCount(); i++)
						DDL_CU_CITIZENSHIP.Items.Add(new ListItem(conn.GetFieldValue(i,1), conn.GetFieldValue(i,0)));

					conn.QueryString = "select NASABAHID, NASABAHID + ' - ' + NASABAHDESC as NASABAHDESC from RFJENISNASABAH where ACTIVE='1'";
					conn.ExecuteQuery();
					for (int i = 0; i < conn.GetRowCount(); i++)
					{
						DDL_CU_JNSNASABAH.Items.Add(new ListItem(conn.GetFieldValue(i,1), conn.GetFieldValue(i,0)));
						//DDL_CU_JNSNASABAH_P.Items.Add(new ListItem(conn.GetFieldValue(i,1), conn.GetFieldValue(i,0)));
					}

					conn.QueryString = "select NASABAHID, NASABAHID + ' - ' + NASABAHDESC as NASABAHDESC from RFJENISNASABAH where NASABAHID = 'A'";
					conn.ExecuteQuery();
					DDL_CU_JNSNASABAH_P.Items.Add(new ListItem(conn.GetFieldValue(0,1), conn.GetFieldValue(0,0)));

					conn.QueryString = "select educationid, educationdesc from rfeducation where active='1'";
					conn.ExecuteQuery();
					for (int i = 0; i < conn.GetRowCount(); i++)
						DDL_CU_EDUCATION.Items.Add(new ListItem(conn.GetFieldValue(i,1), conn.GetFieldValue(i,0)));


					//20080716 pipeline
					//bm sektor ekonomi
					conn.QueryString = "select bm_code,bm_code + ' - ' + bm_desc as bmsektorDESC from RFbmsektorekonomi where ACTIVE='1' order by bm_code";
					conn.ExecuteQuery();
					for (int i = 0; i < conn.GetRowCount(); i++)
						DDL_bmsektor.Items.Add(new ListItem(conn.GetFieldValue(i,1), conn.GetFieldValue(i,0)));
					//DDL_bmsektor.SelectedValue=conn.GetFieldValue("bm_code");
					//bm sub sektor
				
					conn.QueryString = "select bmsub_code,bmsub_code + ' - ' + bmsub_desc as bmsubsektorDESC from RFbmsubsektorekonomi where ACTIVE='1' and BM_CODE = '"  + DDL_bmsektor.SelectedValue + "'	order by bmsub_code";
					//conn.QueryString = "select bmsub_code,bmsub_code + ' - ' + bmsub_desc as bmsubsektorDESC from RFbmsubsektorekonomi where ACTIVE='1' and bm_code='01000000' order by bmsub_code";
					conn.ExecuteQuery();
					for (int i = 0; i < conn.GetRowCount(); i++)
						DDL_bmsubsektor.Items.Add(new ListItem(conn.GetFieldValue(i,1), conn.GetFieldValue(i,0)));
					//GlobalTools.popMessage(this, DDL_bmsektor.SelectedValue);

					//lokasi proyek
					conn.QueryString = "select [ID], [DESC] from VW_CREOPR_BOOKING_SANDIBI_LOKASIPROYEK_ALL";
					//else conn.QueryString = "select [ID], [DESC] from VW_CREOPR_BOOKING_SANDIBI_LOKASIPROYEK ";
					conn.ExecuteQuery();
					DDL_lokasiproyek.Items.Clear();
					DDL_lokasiproyek.Items.Add(new ListItem("- SELECT -", ""));
					for (int i=0; i<conn.GetRowCount(); i++)
						DDL_lokasiproyek.Items.Add(new ListItem(conn.GetFieldValue(i,0) + " - " + conn.GetFieldValue(i, 1), conn.GetFieldValue(i, 0)));
					//lokasi proyek end
					/*--nggak jadi pipeline
					conn.QueryString = "select bussunitid,bussunitdesc from rfbusinessunit where active = '1'";
					conn.ExecuteQuery();
					for (int i = 0; i < conn.GetRowCount(); i++)
						DDL_AP_BUSINESSUNIT.Items.Add(new ListItem(conn.GetFieldValue(i,1), conn.GetFieldValue(i,0)));
					--nggak jadi pipeline */
					//conn.QueryString = "select programid, programdesc from rfprogram where active='1' and businessunit='" + DDL_AP_BUSINESSUNIT.SelectedValue + "'";
					//conn.ExecuteQuery();
					//for (int i = 0; i < conn.GetRowCount(); i++)
					//	DDL_PROG_CODE.Items.Add(new ListItem(conn.GetFieldValue(i,1), conn.GetFieldValue(i,0)));
					conn.ClearData();

					GlobalTools.initDateForm(TXT_CU_COMPTGASURANSI_DAY, DDL_CU_TGASURANSI_MONTH, TXT_CU_COMPTGASURANSI_YEAR, true);
					GlobalTools.initDateForm(TXT_CU_TGLJATUHTEMPO_DAY, DDL_CU_TGLJATUHTEMPO_MONTH, TXT_CU_TGLJATUHTEMPO_YEAR, true);
					GlobalTools.initDateForm(TXT_CU_TGLTERBIT_DAY, DDL_CU_TGLTERBIT_MONTH, TXT_CU_TGLTERBIT_YEAR, true);
					GlobalTools.initDateForm(TXT_CU_ESTABLISHDD, DDL_CU_ESTABLISHMM, TXT_CU_ESTABLISHYY, true);
					GlobalTools.initDateForm(TXT_CU_COMPESTABLISHDD, DDL_CU_COMPESTABLISHMM, TXT_CU_COMPESTABLISHYY, true);
					GlobalTools.initDateForm(TXT_CU_COMPAKTATERAKHIR_DATE_DAY, DDL_CU_COMPAKTATERAKHIR_DATE_MONTH, TXT_CU_COMPAKTATERAKHIR_DATE_YEAR, true);
					GlobalTools.initDateForm(TXT_CU_COMPEXTRATING_DATE_DAY, DDL_CU_COMPEXTRATING_DATE_MONTH, TXT_CU_COMPEXTRATING_DATE_YEAR, true);
					GlobalTools.initDateForm(TXT_CU_COMPLISTINGDATE_DAY, DDL_CU_COMPLISTINGDATE_MONTH, TXT_CU_COMPLISTINGDATE_YEAR, true);

					//2010-04-08 Enhancement 2010
					//Lokasi Dati II
					conn.QueryString = "SELECT * FROM VW_LOKASIDATI2";
					conn.ExecuteQuery();
					for (int i = 0; i < conn.GetRowCount(); i++)
						DDL_CU_LOKASIDATI2.Items.Add(new ListItem(conn.GetFieldValue(i,1), conn.GetFieldValue(i,0)));

					//Hubungan dg Pejabat Executive BM
					conn.QueryString = "SELECT * FROM VW_HUBUNGANEXECUTIVEBM";
					conn.ExecuteQuery();
					for (int i = 0; i < conn.GetRowCount(); i++)
						DDL_CU_HUBEXECBM.Items.Add(new ListItem(conn.GetFieldValue(i,1), conn.GetFieldValue(i,0)));

					//External Rating
					conn.QueryString = "SELECT * FROM VW_EXTERNALRATINGCOMPANY";
					conn.ExecuteQuery();
					for (int i = 0; i < conn.GetRowCount(); i++)
						DDL_CU_COMPEXTRATING_BY.Items.Add(new ListItem(conn.GetFieldValue(i,1), conn.GetFieldValue(i,0)));

					//Kode Listing Bursa
					conn.QueryString = "SELECT * FROM VW_KODELISTINGBURSA";
					conn.ExecuteQuery();
					for (int i = 0; i < conn.GetRowCount(); i++)
						DDL_CU_COMPLISTINGCODE.Items.Add(new ListItem(conn.GetFieldValue(i,1), conn.GetFieldValue(i,0)));

					//Negara Domisili
					conn.QueryString = "SELECT * FROM VW_NEGARADOMISILI";
					conn.ExecuteQuery();
					for (int i = 0; i < conn.GetRowCount(); i++)
						DDL_CU_NEGARADOMISILI.Items.Add(new ListItem(conn.GetFieldValue(i,1), conn.GetFieldValue(i,0)));


					BTN_SAVECON.Visible = false;


					if (Request.QueryString["exist"] == "1")
					{
						conn.QueryString = "select top 1 bs_recvdate from bi_status where cu_ref='" + Request.QueryString["curef"] + "' order by bs_recvdate desc";
						conn.ExecuteQuery();
						try
						{
							TXT_BS_RECVDATE.Text = tool.FormatDate(conn.GetFieldValue(0,0), true);
						}
						catch{}

						//--- if existing customer, user tidak bisa ganti tipe customer
						RDO_RFCUSTOMERTYPE.Enabled = false;


					}

					//ViewData();

					GlobalTools.fillRefList(DDL_GRPUNIT, "select * from RFGROUPUNIT where ACTIVE ='1'", false, conn);
					DDL_GRPUNIT.Items.RemoveAt(0);	//hapus --PILIH--
					try {DDL_GRPUNIT.SelectedValue = "CO";}
					catch {}

					this.SetMandatory(RDO_RFCUSTOMERTYPE.SelectedValue);				

					//--- Kalau screen ini sudah dikunjungi, maka disable beberapa field
					if (Request.QueryString["gi"]=="0") 
					{
						//ViewDataVisited();
				
						//////////////////////////////////////////////
						/// TODO : Please don't hard code !!!!
						/// 			
						TXT_CU_CHILDREN.CssClass = "";
						TXT_CU_MULAIMENETAPMM.CssClass = "";
						TXT_CU_MULAIMENETAPYY.CssClass = "";

					}
					//pipeline
				

				}

			

				//--- Kalau baru masuk pertama kali ke screen, maka
				//--- screen tidak perlu diperlihatkan
				//if ((Request.QueryString["gi"] != "" && Request.QueryString["gi"] != null) || Request.QueryString["mc"] == "030")
				ViewMenu();

				if (RDO_RFCUSTOMERTYPE.SelectedValue != "01")
					TXT_CU_NETINCOMEMM.Text = tool.MoneyFormat(TXT_CU_NETINCOMEMM.Text);
				BTN_SAVE.Attributes.Add("onclick","if(!cek_mandatory(document.Form1)){return false;};");
				BTN_SAVECON.Attributes.Add("onclick","if(!cek_mandatory2(document.Form1)){return false;};"); 

				TR_HEADER_GENINFO.Visible = false;

			}
		}


		private void ViewMenu()
		{
			try 
			{
				conn.QueryString = "select * from SCREENMENU where menucode = '"+Request.QueryString["mc"]+"'";
				conn.ExecuteQuery();

				string mc1 = Request.QueryString["mc"];
				string mc2 = Request.QueryString["mc"];
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

						//---  untuk general info
						if (conn.GetFieldValue(i,3).IndexOf("?exist=") < 0 && conn.GetFieldValue(i,3).IndexOf("&exist=") < 0) 
							strtemp = strtemp + "&exist=" + Request.QueryString["exist"];	

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

		private void setMandatoryFI(string custType, string programid)
		{
			/////////////////////////////////////////////////////
			///	setMandatoryFI(custType, ap_regno)
			/// Men-set field mandatory untuk Fair Isaac (FI)
			/// 

			// menentukan nama mandatory
			string namaMandatory = "";
			if (custType == "02") namaMandatory = "mandatory2";
			else namaMandatory = "mandatory";

			// mencari field yang mandatory ....
			conn.QueryString = "select * from VW_SCORING_MANDATORY_FIELDS2 " + 
				"where FAIRISAAC_SUBMODULE = 'U'" +
				" and PROGRAMID = '" + programid +
				"' and ACTIVE = '1' " +
				" and GR_KEY like '%SCR_IDE%'";
			conn.ExecuteQuery();

			for(int i=0; i < conn.GetRowCount(); i++) 
			{
				string CONTROLID = conn.GetFieldValue(i, "FAIRISAAC_CONTROLID");
			
				if (CONTROLID.IndexOf(",") == 0) 
				{
					if (CONTROLID.StartsWith("TXT_")) 
					{
						TextBox TXT_CONTROL = (TextBox) Page.FindControl(CONTROLID);
						try {TXT_CONTROL.CssClass = namaMandatory;}
						catch (NullReferenceException) {}
					}
					else if (CONTROLID.StartsWith("DDL_")) 
					{
						DropDownList DDL_CONTROL = (DropDownList) Page.FindControl(CONTROLID);
						try {DDL_CONTROL.CssClass = namaMandatory;}
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
								try {TXT_CONTROL.CssClass = namaMandatory;}
								catch (NullReferenceException) {}
							}
							else if (CONTROL.StartsWith("DDL_")) 
							{
								DropDownList DDL_CONTROL = (DropDownList) Page.FindControl(CONTROL);
								try {DDL_CONTROL.CssClass = namaMandatory;}
								catch {}
							}
						}
					}
				}
			}
		}

		private void RDO_RFCUSTOMERTYPE_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			SetMandatory(RDO_RFCUSTOMERTYPE.SelectedValue);
			return;
		}

		private void SetMandatory(string custType)
		{
			if (custType == "01")
			{
				BTN_SAVE.Visible = true;
				BTN_SAVECON.Visible = false;
				TR_COMPANY.Visible = true;
				TR_PERSONAL.Visible = false;
			}
			else
			{
				BTN_SAVECON.Visible = true;
				BTN_SAVE.Visible = false;
				TR_COMPANY.Visible = false;
				TR_PERSONAL.Visible = true;
			}
		}

		private void BTN_SEARCHPERSONAL_Click(object sender, System.EventArgs e)
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

		}
		#endregion
	}
}
