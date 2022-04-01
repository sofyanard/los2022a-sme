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

namespace SME.DataEntry
{
	/// <summary>
	/// Summary description for NasabahGroupInfo. 
	/// 
	/// TODO : 
	/// - Validasi untuk simbol ' ................... done!
	/// - NPWP kok beda dengan IDE ?
	/// 
	/// </summary>
	public partial class NasabahGroupInfo : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Button updatestatus;
//pipeline FOR CORPORATE

//

		protected Tools tool = new Tools();
		protected Connection conn;
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			conn = (Connection) Session["Connection"];

			if (Request.QueryString["de"] == "1")
				if (!Logic.AllowAccess(Session["GroupID"].ToString(), Request.QueryString["mc"], conn))
					Response.Redirect("/SME/Restricted.aspx");

			if (!IsPostBack)
			{
				//conn.QueryString = "select select CU_CUSTTYEID from CUSTOMER where CU_REF = '19042004001000001'";
				//conn.ExecuteQuery();
				//if (conn.GetFieldValue(1,0).ToString() = )

				GlobalTools.initDateForm(TXT_CU_TGLJATUHTEMPO_DAY, DDL_CU_TGLJATUHTEMPO_MONTH, TXT_CU_TGLJATUHTEMPO_YEAR, true);
				GlobalTools.initDateForm(TXT_CU_TGLTERBIT_DAY, DDL_CU_TGLTERBIT_MONTH, TXT_CU_TGLTERBIT_YEAR, true);
				GlobalTools.initDateForm(TXT_CU_SPOUSE_KTPISSUEDATE_DAY, DDL_CU_SPOUSE_KTPISSUEDATE_MONTH, TXT_CU_SPOUSE_KTPISSUEDATE_YEAR, true);
				GlobalTools.initDateForm(TXT_CU_SPOUSE_KTPEXPDATE_DAY, DDL_CU_SPOUSE_KTPEXPDATE_MONTH, TXT_CU_SPOUSE_KTPEXPDATE_YEAR, true);
				GlobalTools.initDateForm(TXT_CU_COMPTGASURANSI_DAY, DDL_CU_TGASURANSI_MONTH, TXT_CU_COMPTGASURANSI_YEAR, true);
				GlobalTools.initDateForm(TXT_CU_COMPESTABLISHDD, DDL_CU_COMPESTABLISHMM, TXT_CU_COMPESTABLISHYY, true);
				GlobalTools.initDateForm(TXT_CU_ESTABLISHDD, DDL_CU_ESTABLISHMM, TXT_CU_ESTABLISHYY, true);

				string de = Request.QueryString["de"];
				if (de != "1") 
				{
					GlobalTools.fillRefList(DDL_CU_JNSNASABAH, "select NASABAHID, NASABAHDESC from RFJENISNASABAH  order by NASABAHID", true, conn);
					GlobalTools.fillRefList(DDL_JNSALAMAT_C, "select ALAMATID, ALAMATDESC from RFJENISALAMAT  order by ALAMATID", false, conn);
					GlobalTools.fillRefList(DDL_CU_HOMESTA, "select * from RFHOMESTA ", true, conn);
					GlobalTools.fillRefList(DDL_CU_COMPRATINGREASON, "SELECT REASONID, REASONDESC FROM RFREASON where REASONTYPE = '4' ", false, conn);
				}
				else 
				{
					GlobalTools.fillRefList(DDL_CU_JNSNASABAH, "select NASABAHID, NASABAHDESC from RFJENISNASABAH where ACTIVE='1' order by NASABAHID", true, conn);
					GlobalTools.fillRefList(DDL_JNSALAMAT_C, "select ALAMATID, ALAMATDESC from RFJENISALAMAT where ACTIVE='1' order by ALAMATID", false, conn);
					GlobalTools.fillRefList(DDL_CU_HOMESTA, "select * from RFHOMESTA where ACTIVE='1'", true, conn);
					GlobalTools.fillRefList(DDL_CU_COMPRATINGREASON, "SELECT REASONID, REASONDESC FROM RFREASON where REASONTYPE = '4' and active = '1'", false, conn);
				}

//				DDL_CS_DOB_MONTH.Items.Add(new ListItem("- PILIH -", ""));
//				DDL_CS_EDUCATION.Items.Add(new ListItem("- PILIH -", ""));
//				DDL_CS_EXPERIENCE.Items.Add(new ListItem("- PILIH -", ""));
//				DDL_CS_JOBTITLE.Items.Add(new ListItem("- PILIH -", ""));

				DDL_CU_BUSSTYPE.Items.Add(new ListItem("- PILIH -", ""));
				DDL_CU_COMPBUSSTYPE.Items.Add(new ListItem("- PILIH -", ""));
				DDL_CU_DOB_MONTH.Items.Add(new ListItem("- PILIH -", ""));
				DDL_CU_IDCARDEXP_MONTH.Items.Add(new ListItem("- PILIH -", ""));
				DDL_CU_COMPTYPE.Items.Add(new ListItem("- PILIH -", ""));
				DDL_CU_JOBTITLE.Items.Add(new ListItem("- PILIH -", ""));
				DDL_CU_MARITAL.Items.Add(new ListItem("- PILIH -", ""));
				DDL_CU_SEX.Items.Add(new ListItem("- PILIH -", ""));
				ddl_CU_CITIZENSHIP.Items.Add(new ListItem("- PILIH -", ""));
				DDL_CU_GRPBUSSTYPE.Items.Add(new ListItem("- PILIH -", ""));
                DDL_CU_KODEINSTANSI.Items.Add(new ListItem("- PILIH -", ""));
				
				for (int i = 1; i <= 12; i++)
				{
					DDL_CU_DOB_MONTH.Items.Add(new ListItem(DateAndTime.MonthName(i, false), i.ToString()));
					DDL_CU_IDCARDEXP_MONTH.Items.Add(new ListItem(DateAndTime.MonthName(i, false), i.ToString()));
//					DDL_CS_DOB_MONTH.Items.Add(new ListItem(DateAndTime.MonthName(i, false), i.ToString()));
				}
				
				string de2 = Request.QueryString["de"];
				if (de2 != "1")  conn.QueryString = "select expid, expdesc from rfexperience ";
				else conn.QueryString = "select expid, expdesc from rfexperience where active='1'";

				conn.ExecuteQuery();
				for (int i = 0; i < conn.GetRowCount(); i++)
//					DDL_CS_EXPERIENCE.Items.Add(new ListItem(conn.GetFieldValue(i,1), conn.GetFieldValue(i,0)));

				if (de2 != "1") conn.QueryString = "select educationid, educationdesc from rfeducation ";
				else conn.QueryString = "select educationid, educationdesc from rfeducation where active='1'";

				conn.ExecuteQuery();
				for (int i = 0; i < conn.GetRowCount(); i++)
//					DDL_CS_EDUCATION.Items.Add(new ListItem(conn.GetFieldValue(i,1), conn.GetFieldValue(i,0)));

				//--- Job Title
				if (de2 != "1") conn.QueryString = "select JOBTITLEID, JOBTITLEID + ' - ' + JOBTITLEDESC as JOBTITLEDESC from RFJOBTITLE  order by JOBTITLEID";
				else conn.QueryString = "select JOBTITLEID, JOBTITLEID + ' - ' + JOBTITLEDESC as JOBTITLEDESC from RFJOBTITLE where ACTIVE='1' order by JOBTITLEID";
				conn.ExecuteQuery();
				for (int i = 0; i < conn.GetRowCount(); i++)
//					DDL_CS_JOBTITLE.Items.Add(new ListItem(conn.GetFieldValue(i,1), conn.GetFieldValue(i,0)));

				conn.QueryString = "select * from rfsex";
				conn.ExecuteQuery();
				for (int i = 0; i < conn.GetRowCount(); i++)
					DDL_CU_SEX.Items.Add(new ListItem(conn.GetFieldValue(i,1), conn.GetFieldValue(i,0)));

				if (de2 != "1") conn.QueryString = "select * from RFCITIZENSHIP ";
				else conn.QueryString = "select * from RFCITIZENSHIP where active = '1'";
				conn.ExecuteQuery();
				for (int i = 0; i < conn.GetRowCount(); i++)
					ddl_CU_CITIZENSHIP.Items.Add(new ListItem(conn.GetFieldValue(i,1), conn.GetFieldValue(i,0)));

				if (de2 != "1") conn.QueryString = "select * from rfmarital ";
				else conn.QueryString = "select * from rfmarital where active = '1'";
				conn.ExecuteQuery();
				for (int i = 0; i < conn.GetRowCount(); i++)
					DDL_CU_MARITAL.Items.Add(new ListItem(conn.GetFieldValue(i,1), conn.GetFieldValue(i,0)));

				if (de2 != "1")  conn.QueryString = "select * from rfjobtitle ";
				else conn.QueryString = "select * from rfjobtitle where active = '1'";
				conn.ExecuteQuery();
				for (int i = 0; i < conn.GetRowCount(); i++)
					DDL_CU_JOBTITLE.Items.Add(new ListItem(conn.GetFieldValue(i,1), conn.GetFieldValue(i,0)));

				if (de2 != "1") conn.QueryString = "select BUSSTYPEID, BUSSTYPEID + ' - ' + BUSSTYPEDESC from RFBUSINESSTYPE where LEN(BUSSTYPEID) < 3 order by BUSSTYPEID";
				else conn.QueryString = "select BUSSTYPEID, BUSSTYPEID + ' - ' + BUSSTYPEDESC from RFBUSINESSTYPE where ACTIVE = '1' AND LEN(BUSSTYPEID) < 3 order by BUSSTYPEID";
				conn.ExecuteQuery();
				for (int i = 0; i < conn.GetRowCount(); i++)
				{
					DDL_CU_BUSSTYPE.Items.Add(new ListItem(conn.GetFieldValue(i,1), conn.GetFieldValue(i,0)));
					DDL_CU_COMPBUSSTYPE.Items.Add(new ListItem(conn.GetFieldValue(i,1), conn.GetFieldValue(i,0)));
					DDL_CU_GRPBUSSTYPE.Items.Add(new ListItem(conn.GetFieldValue(i,1), conn.GetFieldValue(i,0)));
				}

				if (de2 != "1")  conn.QueryString = "select * from rfcomptype ";
				else conn.QueryString = "select * from rfcomptype where active = '1'";

				conn.ExecuteQuery();
				for (int i = 0; i < conn.GetRowCount(); i++)
					DDL_CU_COMPTYPE.Items.Add(new ListItem(conn.GetFieldValue(i,1), conn.GetFieldValue(i,0)));

                if (de2 != "1") conn.QueryString = "SELECT * FROM VW_KODEINSTANSI ";
                else conn.QueryString = "SELECT * FROM VW_KODEINSTANSI WHERE ACTIVE = '1'";
                conn.ExecuteQuery();
                for (int i = 0; i < conn.GetRowCount(); i++)
                    DDL_CU_KODEINSTANSI.Items.Add(new ListItem(conn.GetFieldValue(i, 1), conn.GetFieldValue(i, 0)));

				ViewData();
				ViewCustHolder();				

				this.SecureData();

				setMandatoryFI();
			}
			ViewMenu();
		}

		private void setMandatoryFI() 
		{
			/////////////////////////////////////////////////////
			///	setMandatoryFI(custType, ap_regno)
			/// Men-set field mandatory untuk Fair Isaac (FI)
			/// 

			//////////////////////////////////////////////
			/// TODO : Please don't hard code !!!!
			/// 			
			TXT_CU_CHILDREN.CssClass = "";
			TXT_CU_MULAIMENETAPMM.CssClass = "";
			TXT_CU_MULAIMENETAPYY.CssClass = "";

			//			if (DDL_PROG_CODE.SelectedValue == "15" || 
			//				DDL_PROG_CODE.SelectedValue == "16" || 
			//				DDL_PROG_CODE.SelectedValue == "19") 
			//			{
			//				TXT_CU_CHILDREN.CssClass = "mandatory2";
			//				TXT_CU_MULAIMENETAPMM.CssClass = "mandatory2";
			//				TXT_CU_MULAIMENETAPYY.CssClass = "mandatory2";				
			//			}		

			conn.QueryString = "select PROG_CODE from APPLICATION where AP_REGNO = '" + Request.QueryString["regno"] + "'";
			conn.ExecuteQuery();

			string vProg_code = "";
			if (conn.GetRowCount() > 0) 
			{
				vProg_code = conn.GetFieldValue("prog_code");
			}

			setMandatoryFI(lbl_CU_CUSTTYPEID.Text, vProg_code);
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

		private void SecureDataManual() 
		{
			/// ****************************************************
			/// Personal Customer
			/// 
			TXT_CU_POB.ReadOnly = true;
			TXT_CU_DOB_DAY.ReadOnly = true;
			DDL_CU_DOB_MONTH.Enabled = false;
			TXT_CU_DOB_YEAR.ReadOnly = true;
			DDL_CU_MARITAL.Enabled = false;
			// spouse info
			TXT_CU_SPOUSE_FNAME.ReadOnly = true;
			TXT_CU_SPOUSE_MNAME.ReadOnly = true;
			TXT_CU_SPOUSE_LNAME.ReadOnly = true;
			TXT_CU_SPOUSE_IDCARDNUM.ReadOnly = true;
			TXT_CU_SPOUSE_KTPADDR1.ReadOnly = true;
			TXT_CU_SPOUSE_KTPADDR2.ReadOnly = true;
			TXT_CU_SPOUSE_KTPADDR3.ReadOnly = true;
			TXT_CU_SPOUSE_KTPEXPDATE_DAY.ReadOnly = true;
			DDL_CU_SPOUSE_KTPEXPDATE_MONTH.Enabled = false;
			TXT_CU_SPOUSE_KTPEXPDATE_YEAR.ReadOnly = true;
			TXT_CU_SPOUSE_KTPISSUEDATE_DAY.ReadOnly = true;
			DDL_CU_SPOUSE_KTPISSUEDATE_MONTH.Enabled = false;
			TXT_CU_SPOUSE_KTPISSUEDATE_YEAR.ReadOnly = true;
			TXT_CU_NOKARTUKELUARGA.ReadOnly = true;
			// end
			TXT_CU_CHILDREN.ReadOnly = true;
			DDL_CU_SEX.Enabled = false;
			ddl_CU_CITIZENSHIP.Enabled = false;
			TXT_CU_IDCARDNUM.ReadOnly = true;
			TXT_CU_IDCARDEXP_DAY.ReadOnly = true;
			DDL_CU_IDCARDEXP_MONTH.Enabled = false;
			TXT_CU_IDCARDEXP_YEAR.ReadOnly = true;
			DDL_CU_JOBTITLE.Enabled = false;
			DDL_CU_JNSNASABAH.Enabled = false;
			TXT_CU_ESTABLISHDD.ReadOnly = true;
			DDL_CU_ESTABLISHMM.Enabled = false;
			TXT_CU_ESTABLISHYY.ReadOnly = true;
			TXT_CU_NPWP.ReadOnly = true;
			TXT_CU_EMPLOYEE.ReadOnly = true;
			/// ****************************************************
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
		
		private void SecureData() 
		{
			// Jika yang memanggil bukan dalam scope DataEntry, maka disable semua control input
			// Flag :
			//		Nama  = de
			//		Value ==  1 --> Parent DataEntry
			//			  !=  1 --> Parent non-DataEntry
			string de = Request.QueryString["de"];
			if (de != "1") 
			{
				System.Web.UI.ControlCollection coll = this.Page.Controls;
				int k = 0, index = -1;
				for(k = 0; k < coll.Count; k++) 
				{
					if (coll[k] is System.Web.UI.HtmlControls.HtmlForm) 
					{
						index = k;
						break;
					}
				}

				if (index == -1) 
				{
					SecureDataManual();
					return;
				}

				/// Men-disable field secara manual
				/// 				
				SecureDataManual();
					
				for (int i = 0; i < coll[index].Controls.Count; i++) 
				{
					if (coll[index].Controls[i] is TextBox) 
					{
						TextBox txt = (TextBox) coll[index].Controls[i];
						txt.ReadOnly = true;
						//txt.Enabled = false;
					}
					else if (coll[index].Controls[i] is DropDownList) 
					{
						DropDownList ddl = (DropDownList) coll[index].Controls[i];
						ddl.Enabled = false;
					}
					else if (coll[index].Controls[i] is Button)
					{
						Button btn = (Button) coll[index].Controls[i];
						//btn.Enabled = false;
						btn.Visible = false;
					}
					else if (coll[index].Controls[i] is RadioButtonList) 
					{
						RadioButtonList rbl = (RadioButtonList) coll[index].Controls[i];
						rbl.Enabled = false;
					}
					else if (coll[index].Controls[i] is RadioButton) 
					{
						RadioButton rb = (RadioButton) coll[index].Controls[i];
						rb.Enabled = false;
					}
					else if (coll[index].Controls[i] is CheckBox)
					{
						CheckBox cb = (CheckBox) coll[index].Controls[i];
						cb.Enabled = false;
					}					
					else if (coll[index].Controls[i] is DataGrid) 
					{						
						DataGrid dg = (DataGrid) coll[index].Controls[i];						
						dg.Columns[10].Visible = false;
						for (int j = 0; j < dg.Items.Count; j++) 
						{
							//dg.Items[j].Cells[10].Enabled = false;
							dg.Items[j].Cells[10].Visible = false;
						}
					}
					else if (coll[index].Controls[i] is HtmlTableRow) 
					{
						HtmlTableRow htr = (HtmlTableRow) coll[index].Controls[i];
						//htr.Disabled = true;	

						for (int j=0; j < htr.Controls.Count; j++) 
						{							
							for (int jj = 0; jj < htr.Controls[j].Controls.Count; jj++) 
							{
								if (htr.Controls[j].Controls[jj] is TextBox) 
								{
									TextBox txt = (TextBox) htr.Controls[j].Controls[jj];
									txt.ReadOnly = true;
									//txt.Enabled = false;
								}
								else if (htr.Controls[j].Controls[jj] is DropDownList) 
								{
									DropDownList ddl = (DropDownList) htr.Controls[j].Controls[jj];
									ddl.Enabled = false;
								}
								else if (htr.Controls[j].Controls[jj] is Button)
								{
									Button btn = (Button) htr.Controls[j].Controls[jj];
									//btn.Enabled = false;
									btn.Visible = false;
								}
								else if (htr.Controls[j].Controls[jj] is RadioButtonList) 
								{
									RadioButtonList rbl = (RadioButtonList) htr.Controls[j].Controls[jj];
									rbl.Enabled = false;
								}
								else if (htr.Controls[j].Controls[jj] is RadioButton) 
								{
									RadioButton rb = (RadioButton) htr.Controls[j].Controls[jj];
									rb.Enabled = false;
								}
								else if (htr.Controls[j].Controls[jj] is CheckBox)
								{
									CheckBox cb = (CheckBox) htr.Controls[j].Controls[jj];
									cb.Enabled = false;
								}					
							}
						}
					}
				}
			}
		}

		private void ViewData()
		{
			conn.QueryString = "select CU_CUSTTYPEID from CUSTOMER where CU_REF = '" +Request.QueryString["curef"]+ "'";
			conn.ExecuteQuery();
			lbl_CU_CUSTTYPEID.Text = conn.GetFieldValue("CU_CUSTTYPEID").ToString();
			// If Company
			if (conn.GetFieldValue("CU_CUSTTYPEID") == "01")
			{
				TR_COMPANY.Visible = true;
				TR_PERSONAL.Visible = false;				
				conn.QueryString = "select * from vw_cust_company where cu_ref='" + Request.QueryString["curef"] + "'";
				conn.ExecuteQuery();

				TXT_CU_CIF_C.Text = conn.GetFieldValue("CU_CIF");
				try { DDL_CU_COMPTYPE.SelectedValue = conn.GetFieldValue("CU_COMPTYPE"); } 
				catch {}
				TXT_CU_COMPNAME.Text = conn.GetFieldValue("CU_COMPNAME");
				TXT_CU_COMPADDR1.Text = conn.GetFieldValue("CU_COMPADDR1");
				TXT_CU_COMPADDR2.Text = conn.GetFieldValue("CU_COMPADDR2");
				TXT_CU_COMPADDR3.Text = conn.GetFieldValue("CU_COMPADDR3");
				TXT_CU_COMPCITY.Text = conn.GetFieldValue("CITYNAME");
				LBL_CU_COMPCITY.Text = conn.GetFieldValue("CU_COMPCITY");
				TXT_CU_COMPZIPCODE.Text = conn.GetFieldValue("CU_COMPZIPCODE");
				try { DDL_CU_COMPBUSSTYPE.SelectedValue = conn.GetFieldValue("CU_COMPBUSSTYPE"); }
				catch {}
				string CU_COMPESTABLISH = conn.GetFieldValue("CU_COMPESTABLISH");
				TXT_CU_COMPESTABLISHDD.Text = tool.FormatDate_Day(CU_COMPESTABLISH);
				try {DDL_CU_COMPESTABLISHMM.SelectedValue = tool.FormatDate_Month(CU_COMPESTABLISH);}
				catch {DDL_CU_COMPESTABLISHMM.SelectedValue = "";}
				TXT_CU_COMPESTABLISHYY.Text = tool.FormatDate_Year(CU_COMPESTABLISH);
				TXT_CU_COMPPHNAREA.Text = conn.GetFieldValue("CU_COMPPHNAREA");
				TXT_CU_COMPPHNNUM.Text = conn.GetFieldValue("CU_COMPPHNNUM");
				TXT_CU_COMPFAXAREA.Text = conn.GetFieldValue("CU_COMPFAXAREA");
				TXT_CU_COMPFAXNUM.Text = conn.GetFieldValue("CU_COMPFAXNUM");
				TXT_CU_COMPFAXEXT.Text = conn.GetFieldValue("CU_COMPFAXEXT");
				TXT_CU_COMPNPWP.Text = conn.GetFieldValue("CU_NPWP");
				TXT_CU_CONTACTPERSON.Text = conn.GetFieldValue("CU_CONTACTPERSON");
				TXT_CU_CONTACTPHNAREA.Text = conn.GetFieldValue("CU_CONTACTPHNAREA");
				TXT_CU_CONTACTPHNNUM.Text = conn.GetFieldValue("CU_CONTACTPHNNUM");
				TXT_CU_CONTACTPHNEXT.Text = conn.GetFieldValue("CU_CONTACTPHNEXT");
				TXT_CU_GROUPCUST.Text = conn.GetFieldValue("CU_GROUPCUST");
				TXT_CU_GRPADDR1.Text = conn.GetFieldValue("CU_GRPADDR1");
				TXT_CU_GRPADDR2.Text = conn.GetFieldValue("CU_GRPADDR2");
				TXT_CU_GRPADDR3.Text = conn.GetFieldValue("CU_GRPADDR3");
				try { DDL_CU_GRPBUSSTYPE.SelectedValue  =conn.GetFieldValue("CU_GRPBUSSTYPE"); }
				catch {}
				TXT_CU_GRPPHNAREA.Text = conn.GetFieldValue("CU_GRPPHNAREA");
				TXT_CU_GRPPHNNUM.Text = conn.GetFieldValue("CU_GRPPHNNUM");
				TXT_CU_GRPPHNEXT.Text = conn.GetFieldValue("CU_GRPPHNEXT");

				//asdf
				try {RDO_CU_PERNAHJDNASABAHBM.SelectedValue = conn.GetFieldValue("CU_PERNAHJDNASABAHBM");}
				catch {RDO_CU_PERNAHJDNASABAHBM.SelectedValue = "0";}
				try {RBL_CU_RESTRUCTURE.SelectedValue = conn.GetFieldValue("CU_RESTRUCTURE");}
				catch {RBL_CU_RESTRUCTURE.SelectedValue = "0";}
				try {RBL_CU_COMPRATING.SelectedValue = conn.GetFieldValue("CU_COMPRATING");}
				catch {RBL_CU_COMPRATING.SelectedValue = "0";}
				try {RDO_CU_COMPPROBLEM.SelectedValue = conn.GetFieldValue("CU_COMPPROBLEM");}
				catch {RDO_CU_COMPPROBLEM.SelectedValue = "0";}
				try { DDL_CU_COMPRATINGREASON.SelectedValue = conn.GetFieldValue("CU_COMPRATINGREASON"); } 
				catch {}

				TXT_CU_COMPEMPLOYEE.Text = conn.GetFieldValue("CU_COMPEMPLOYEE");
				TXT_CU_AKTAPENDIRIAN.Text = conn.GetFieldValue("CU_COMPAKTAPENDIRIAN");
				TXT_CU_TDP.Text = conn.GetFieldValue("CU_TDP");
				try {DDL_CU_JNSNASABAH.SelectedValue = conn.GetFieldValue("CU_JNSNASABAH");}
				catch {}
				try {DDL_JNSALAMAT_C.SelectedValue = conn.GetFieldValue("CU_JNSALAMAT");}
				catch {}
				try {GlobalTools.fromSQLDate(conn.GetFieldValue("CU_INSURANCEDATE").ToString(), TXT_CU_COMPTGASURANSI_DAY, DDL_CU_TGASURANSI_MONTH, TXT_CU_COMPTGASURANSI_YEAR);}
				catch {}
				try {GlobalTools.fromSQLDate(conn.GetFieldValue("CU_TGLTERBIT"), TXT_CU_TGLTERBIT_DAY, DDL_CU_TGLTERBIT_MONTH, TXT_CU_TGLTERBIT_YEAR);}
				catch{}
				try {GlobalTools.fromSQLDate(conn.GetFieldValue("CU_TGLJATUHTEMPO"), TXT_CU_TGLJATUHTEMPO_DAY, DDL_CU_TGLJATUHTEMPO_MONTH, TXT_CU_TGLJATUHTEMPO_YEAR);}
				catch{}
				TXT_CU_COMPNOTARYNAME.Text = conn.GetFieldValue("CU_COMPNOTARYNAME");
				TXT_CU_GRPREMARK.Text = conn.GetFieldValue("CU_GRPREMARK");
				TXT_CU_COMPANGGOTA.Text = conn.GetFieldValue("CU_COMPANGGOTA");
			}

			else
			{
				TR_COMPANY.Visible = false;
				TR_PERSONAL.Visible = true;
				conn.QueryString = "select * from vw_cust_personal where cu_ref='" + Request.QueryString["curef"] + "'";
				conn.ExecuteQuery();

				TXT_CU_CIF_P.Text = conn.GetFieldValue("CU_CIF");
				TXT_CU_TITLEBEFORENAME.Text = conn.GetFieldValue("CU_TITLEBEFORENAME");
				TXT_CU_FIRSTNAME.Text = conn.GetFieldValue("CU_FIRSTNAME");
				TXT_CU_MIDDLENAME.Text = conn.GetFieldValue("CU_MIDDLENAME");
				TXT_CU_LASTNAME.Text = conn.GetFieldValue("CU_LASTNAME");
				TXT_CU_ADDR1.Text = conn.GetFieldValue("CU_ADDR1");
				TXT_CU_ADDR2.Text = conn.GetFieldValue("CU_ADDR2");
				TXT_CU_ADDR3.Text = conn.GetFieldValue("CU_ADDR3");
				LBL_CU_CITY.Text = conn.GetFieldValue("CU_CITY");
				TXT_CU_CITY.Text = conn.GetFieldValue("CITYNAME");
				TXT_CU_ZIPCODE.Text = conn.GetFieldValue("CU_ZIPCODE");
				TXT_CU_PHNAREA.Text = conn.GetFieldValue("CU_PHNAREA");
				TXT_CU_PHNNUM.Text = conn.GetFieldValue("CU_PHNNUM");
				TXT_CU_PHNEXT.Text = conn.GetFieldValue("CU_PHNEXT");
				TXT_CU_FAXAREA.Text = conn.GetFieldValue("CU_FAXAREA");
				TXT_CU_FAXNUM.Text = conn.GetFieldValue("CU_FAXNUM");
				TXT_CU_FAXEXT.Text = conn.GetFieldValue("CU_FAXEXT");
				TXT_CU_POB.Text = conn.GetFieldValue("CU_POB");
				TXT_CU_DOB_DAY.Text = tool.FormatDate_Day(conn.GetFieldValue("CU_DOB"));
				DDL_CU_DOB_MONTH.SelectedValue = tool.FormatDate_Month(conn.GetFieldValue("CU_DOB"));
				TXT_CU_DOB_YEAR.Text = tool.FormatDate_Year(conn.GetFieldValue("CU_DOB"));
				try { ddl_CU_CITIZENSHIP.SelectedValue = conn.GetFieldValue("CU_CITIZENSHIP"); } 
				catch {}
				try { DDL_CU_MARITAL.SelectedValue = conn.GetFieldValue("CU_MARITAL"); } 
				catch {}
				try { DDL_CU_SEX.SelectedValue = conn.GetFieldValue("CU_SEX"); } 
				catch {}
				TXT_CU_IDCARDNUM.Text = conn.GetFieldValue("CU_IDCARDNUM");
				TXT_CU_IDCARDEXP_DAY.Text = tool.FormatDate_Day(conn.GetFieldValue("CU_IDCARDEXP"));
				DDL_CU_IDCARDEXP_MONTH.SelectedValue = tool.FormatDate_Month(conn.GetFieldValue("CU_IDCARDEXP"));
				TXT_CU_IDCARDEXP_YEAR.Text = tool.FormatDate_Year(conn.GetFieldValue("CU_IDCARDEXP"));
				try { DDL_CU_JOBTITLE.SelectedValue = conn.GetFieldValue("CU_JOBTITLE"); } 
				catch {}
				try { DDL_CU_BUSSTYPE.SelectedValue = conn.GetFieldValue("CU_BUSSTYPE"); } 
				catch {}
				string CU_ESTABLISHYY = conn.GetFieldValue("CU_ESTABLISHYY");
				TXT_CU_ESTABLISHDD.Text = tool.FormatDate_Day(CU_ESTABLISHYY);
				try {DDL_CU_ESTABLISHMM.SelectedValue = tool.FormatDate_Month(CU_ESTABLISHYY);}
				catch {DDL_CU_ESTABLISHMM.SelectedValue = "";}
				TXT_CU_ESTABLISHYY.Text = tool.FormatDate_Year(CU_ESTABLISHYY);
				TXT_CU_NPWP.Text = conn.GetFieldValue("CU_NPWP");
				TXT_CU_GROUPCUST.Text = conn.GetFieldValue("CU_GROUPCUST");
				TXT_CU_GRPADDR1.Text = conn.GetFieldValue("CU_GRPADDR1");
				TXT_CU_GRPADDR2.Text = conn.GetFieldValue("CU_GRPADDR2");
				TXT_CU_GRPADDR3.Text = conn.GetFieldValue("CU_GRPADDR3");
				try { DDL_CU_GRPBUSSTYPE.SelectedValue  =conn.GetFieldValue("CU_GRPBUSSTYPE"); }
				catch {}
				TXT_CU_GRPPHNAREA.Text = conn.GetFieldValue("CU_GRPPHNAREA");
				TXT_CU_GRPPHNNUM.Text = conn.GetFieldValue("CU_GRPPHNNUM");
				TXT_CU_GRPPHNEXT.Text = conn.GetFieldValue("CU_GRPPHNEXT");
				string CU_COMPRATING = conn.GetFieldValue("CU_COMPRATING");
				if (CU_COMPRATING == "" || CU_COMPRATING == "0")
					CU_COMPRATING = "0";
				else
					CU_COMPRATING = "1";
				RBL_CU_COMPRATING.SelectedValue = CU_COMPRATING;
				string CU_RESTRUCTURE = conn.GetFieldValue("CU_RESTRUCTURE");
				if (CU_RESTRUCTURE == "" || CU_RESTRUCTURE == "0")
					CU_RESTRUCTURE= "0";
				else
					CU_RESTRUCTURE= "1";
				try { RBL_CU_RESTRUCTURE.SelectedValue = CU_RESTRUCTURE; } 
				catch {}
				RDO_CU_PERNAHJDNASABAHBM.SelectedValue = conn.GetFieldValue("CU_PERNAHJDNASABAHBM");
				//--- start of Informasi Spouse ------------------
				TXT_CU_SPOUSE_FNAME.Text		= conn.GetFieldValue("CU_SPOUSE_FNAME");
				TXT_CU_SPOUSE_MNAME.Text		= conn.GetFieldValue("CU_SPOUSE_MNAME");
				TXT_CU_SPOUSE_LNAME.Text		= conn.GetFieldValue("CU_SPOUSE_LNAME");
				TXT_CU_SPOUSE_IDCARDNUM.Text	= conn.GetFieldValue("CU_SPOUSE_IDCARDNUM");
				TXT_CU_SPOUSE_KTPADDR1.Text		= conn.GetFieldValue("CU_SPOUSE_KTPADDR1");
				TXT_CU_SPOUSE_KTPADDR2.Text		= conn.GetFieldValue("CU_SPOUSE_KTPADDR2");
				TXT_CU_SPOUSE_KTPADDR3.Text		= conn.GetFieldValue("CU_SPOUSE_KTPADDR3");
				if (conn.GetFieldValue("CU_SPOUSE_KTPISSUEDATE")!=null && conn.GetFieldValue("CU_SPOUSE_KTPISSUEDATE")!="") GlobalTools.fromSQLDate(conn.GetFieldValue("CU_SPOUSE_KTPISSUEDATE"), TXT_CU_SPOUSE_KTPISSUEDATE_DAY, DDL_CU_SPOUSE_KTPISSUEDATE_MONTH, TXT_CU_SPOUSE_KTPISSUEDATE_YEAR);
				if (conn.GetFieldValue("CU_SPOUSE_KTPEXPDATE")!=null && conn.GetFieldValue("CU_SPOUSE_KTPEXPDATE")!="") GlobalTools.fromSQLDate(conn.GetFieldValue("CU_SPOUSE_KTPEXPDATE"), TXT_CU_SPOUSE_KTPEXPDATE_DAY, DDL_CU_SPOUSE_KTPEXPDATE_MONTH, TXT_CU_SPOUSE_KTPEXPDATE_YEAR);
				TXT_CU_NOKARTUKELUARGA.Text		= conn.GetFieldValue("CU_NOKARTUKELUARGA");
				//-------------- end of spouseinfo --------------

				TXT_CU_GRPREMARK.Text = conn.GetFieldValue("CU_GRPREMARK");
				TXT_CU_MULAIMENETAPMM.Text = conn.GetFieldValue("CU_MULAIMENETAPMM");
				TXT_CU_MULAIMENETAPYY.Text = conn.GetFieldValue("CU_MULAIMENETAPYY");
				TXT_CU_EMPLOYEE.Text = conn.GetFieldValue("CU_EMPLOYEE");
				try { DDL_CU_HOMESTA.SelectedValue = conn.GetFieldValue("CU_HOMESTA");} 
				catch {}
				TXT_CU_CHILDREN.Text = conn.GetFieldValue("CU_CHILDREN");
				try { DDL_CU_COMPRATINGREASON.SelectedValue = conn.GetFieldValue("CU_COMPRATINGREASON"); } 
				catch {}

				TXT_CU_MOTHER.Text  = conn.GetFieldValue("CU_MOTHER");
                TXT_CU_TEMPATKERJA.Text = conn.GetFieldValue("CU_TEMPATKERJA");
                try { DDL_CU_KODEINSTANSI.SelectedValue = conn.GetFieldValue("CU_KODEINSTANSI"); }
                catch { }
                TXT_CU_NOPEGAWAI.Text = conn.GetFieldValue("CU_NOPEGAWAI");
			}

			conn.QueryString = "SELECT sg_BUSSUNITid FROM scgroup WHERE groupid = '" + Session["GroupID"].ToString() + "'";
			conn.ExecuteQuery();
			if (conn.GetFieldValue("sg_BUSSUNITid") == "CB100")
			{
				TR_COMPANY.Visible = false;
				TR_PERSONAL.Visible = false;
				TR_CUSTINFO.Visible = false;
				//TR_APARATING.Visible = false;
				//TR_APACRSS.Visible = false;
				TR_APAMANDIRI.Visible = false;
				TR_APAHUKUM.Visible = false;
				TR_APAWASPADA.Visible = false;
				TR_SPACE1.Visible = false;
			}
		}

		private void ViewCustHolder()
		{

			//double totSaham = 0;
			
			DataTable dt = new DataTable();
			conn.QueryString = "select *, case isnull(CS_NATSTAT,'0') when '0' then 'WNI' when '1' then 'WNA' end as STATUS_DESC, case isnull(CS_KEYPERSON,'0') when '0' then 'TIDAK' when '1' then 'YA' end as CS_KEYPERSON1 from VW_CUST_STOCKHOLDER where CU_REF ='"+ Request.QueryString["curef"] + "'";
			conn.ExecuteQuery();
			dt = conn.GetDataTable().Copy();
			DatGridPengurus.DataSource = dt;
			DatGridPengurus.DataBind();

			for (int i = 0; i < DatGridPengurus.Items.Count; i++)
				DatGridPengurus.Items[i].Cells[3].Text = tool.FormatDate(DatGridPengurus.Items[i].Cells[3].Text, true);
		}

		// Dibuat oleh Yudi (2004/09/18) 
		// Untuk memeriksa validitas input sebelum save data ke database
		private bool isInputValid(string customerType) 
		{
			string CU_REF = Request.QueryString["curef"];
			bool validkah = true;
			Int64 now = Int64.Parse(Tools.toISODate(DateTime.Now.Day.ToString(), DateTime.Now.Month.ToString(), DateTime.Now.Year.ToString()));

			if (customerType == "01") // company
			{
				//--- Cek NPWP Perusahaan
				conn.QueryString = "select count (*) from CUSTOMER where CU_REF <> '" + CU_REF + "' and CU_NPWP = '" + TXT_CU_COMPNPWP.Text + "'";
				conn.ExecuteQuery();
				if (conn.GetFieldValue(0,0) != "0")
				{
					Response.Write("<script language='javascript'>alert('Customer with NPWP: " + TXT_CU_COMPNPWP.Text + " exists in the system!');</script>");
					GlobalTools.SetFocus(this, TXT_CU_NPWP);
					return false;
				}

				//--- Cek Berdiri Sejak				
				
				if(!GlobalTools.isDateValid(this,TXT_CU_COMPESTABLISHDD.Text,DDL_CU_COMPESTABLISHMM.SelectedValue,TXT_CU_COMPESTABLISHYY.Text))
				{
					Response.Write("<script language='javascript'>alert('Tanggal berdiri sejak tidak valid!');</script>");
					GlobalTools.SetFocus(this, TXT_CU_COMPESTABLISHDD);
					return false;
				}
						
			}
			else	// personal
			{
				//--- Cek tanggal lahir
				if (!GlobalTools.isDateValid(this, TXT_CU_DOB_DAY.Text.Trim(), DDL_CU_DOB_MONTH.SelectedValue, TXT_CU_DOB_YEAR.Text.Trim())) 
				{
					GlobalTools.popMessage(this, "Tanggal Lahir tidak valid!");
					GlobalTools.SetFocus(this, TXT_CU_DOB_DAY);
					return false;
				}
				if (GlobalTools.isFuture(TXT_CU_DOB_DAY.Text.Trim(), DDL_CU_DOB_MONTH.SelectedValue, TXT_CU_DOB_YEAR.Text.Trim())) 
				{
					GlobalTools.popMessage(this, "Tanggal Lahir melewati Tanggal Sekarang!");
					GlobalTools.SetFocus(this, TXT_CU_DOB_DAY);
					return false;
				}

				/// Validasi Mulai Menetap
				/// 
				if (!GlobalTools.isDateValid("1", TXT_CU_MULAIMENETAPMM.Text, TXT_CU_MULAIMENETAPYY.Text)) 
				{
					GlobalTools.popMessage(this, "Mulai Menetap tidak valid!");
					GlobalTools.SetFocus(this, TXT_CU_MULAIMENETAPMM);
					return false;
				}

				//--- Cek No TKP dan Tanggal Expire
				string TGL_KTP = GlobalTools.ToSQLDate(TXT_CU_IDCARDEXP_DAY.Text.Trim(), DDL_CU_IDCARDEXP_MONTH.SelectedValue, TXT_CU_IDCARDEXP_YEAR.Text.Trim());
				if (!GlobalTools.isDateValid(this, TXT_CU_IDCARDEXP_DAY.Text.Trim(), DDL_CU_IDCARDEXP_MONTH.SelectedValue, TXT_CU_IDCARDEXP_YEAR.Text.Trim())) 
				{
					GlobalTools.popMessage(this, "Tanggal Expire KTP tidak valid!");
					GlobalTools.SetFocus(this, TXT_CU_IDCARDEXP_DAY);
					return false;			
				}
				Int64 idcardexp = Int64.Parse(Tools.toISODate(TXT_CU_IDCARDEXP_DAY.Text, DDL_CU_IDCARDEXP_MONTH.SelectedValue, TXT_CU_IDCARDEXP_YEAR.Text));
				if (idcardexp < now) 
				{
					GlobalTools.popMessage(this, "Tanggal Berakhir KTP tidak boleh kurang dari tanggal sekarang!");
					return false;
				}

				////////////////////////////////////////////////////////////////////
				///	VALIDASI TANGGAL BERAKHIR KTP SPOUSE
				///	
				if (TXT_CU_SPOUSE_KTPEXPDATE_DAY.Text != "" && DDL_CU_SPOUSE_KTPEXPDATE_MONTH.SelectedValue != "" && TXT_CU_SPOUSE_KTPEXPDATE_YEAR.Text != "") 
				{
					if (!GlobalTools.isDateValid(TXT_CU_SPOUSE_KTPEXPDATE_DAY.Text, DDL_CU_SPOUSE_KTPEXPDATE_MONTH.SelectedValue, TXT_CU_SPOUSE_KTPEXPDATE_YEAR.Text)) 
					{
						GlobalTools.popMessage(this, "Tanggal Berakhir KTP Spouse tidak valid!");
						return false;
					}
				}
				int banding = Tools.compareDate(DateTime.Now.Day.ToString(), DateTime.Now.Month.ToString(), DateTime.Now.Year.ToString(), TXT_CU_SPOUSE_KTPEXPDATE_DAY.Text, DDL_CU_SPOUSE_KTPEXPDATE_MONTH.SelectedValue, TXT_CU_SPOUSE_KTPEXPDATE_YEAR.Text);
				if (banding >= 0) 
				{
					GlobalTools.popMessage(this, "Tanggal Berakhir KTP Spouse tidak boleh kurang dari tanggal sekarang!");
					return false;
				}
				
				////////////////////////////////////////////////////////////////////
				///	VALIDASI TANGGAL ISSUANCE KTP
				///	
				if (TXT_CU_SPOUSE_KTPISSUEDATE_DAY.Text != "" && DDL_CU_SPOUSE_KTPISSUEDATE_MONTH.SelectedValue != "" && TXT_CU_SPOUSE_KTPISSUEDATE_YEAR.Text != "") 
				{
					if (!GlobalTools.isDateValid(TXT_CU_SPOUSE_KTPISSUEDATE_DAY.Text, DDL_CU_SPOUSE_KTPISSUEDATE_MONTH.SelectedValue, TXT_CU_SPOUSE_KTPISSUEDATE_YEAR.Text)) 
					{
						GlobalTools.popMessage(this, "Tanggal Issuance KTP Spouse tidak valid!");
						return false;
					}
				}				

				conn.QueryString = "select count (*) from cust_personal where CU_REF <> '" + CU_REF + "' and CU_IDCARDNUM='" + TXT_CU_IDCARDNUM.Text + "' and CU_IDCARDEXP = " + TGL_KTP + "";
				conn.ExecuteQuery();

				if (conn.GetFieldValue(0,0) != "0")
				{
					Response.Write("<script language='javascript'>alert('Customer with KTP: " + TXT_CU_IDCARDNUM.Text + " and Expire Date: " + TGL_KTP.Replace("'","") + " exists in the system!');</script>");
					GlobalTools.SetFocus(this, TXT_CU_IDCARDNUM);
					return false;
				}				

				//--- Cek berdiri sejak

				if(!GlobalTools.isDateValid(this,TXT_CU_ESTABLISHDD.Text,DDL_CU_ESTABLISHMM.SelectedValue,TXT_CU_ESTABLISHYY.Text))
				{
					GlobalTools.popMessage(this, "Tanggal berdiri sejak tidak valid!");
					GlobalTools.SetFocus(this, TXT_CU_ESTABLISHDD);
					return false;
				}				
			}

			return validkah;
		}

		protected void BTN_SAVE_Click(object sender, System.EventArgs e)
		{
			conn.QueryString = "select CU_CUSTTYPEID from CUSTOMER where CU_REF = '" +Request.QueryString["curef"]+ "'";
			conn.ExecuteQuery();
			lbl_CU_CUSTTYPEID.Text = conn.GetFieldValue("CU_CUSTTYPEID").ToString();

			try 
			{
				string CU_CUSTTYPEID = conn.GetFieldValue("CU_CUSTTYPEID");
				if (!isInputValid(CU_CUSTTYPEID)) return;

				if (CU_CUSTTYPEID == "01") // If Company
				{			
					conn.QueryString = "exec DE_NASABAHGROUPINFO_COMPANY '" +Request.QueryString["curef"]+ "', '" +DDL_CU_COMPTYPE.SelectedValue+ "', '" +TXT_CU_COMPNAME.Text+ "', '" +TXT_CU_COMPADDR1.Text+
						"', '" +TXT_CU_COMPADDR2.Text+ "', '" +TXT_CU_COMPADDR3.Text+ "', '" +LBL_CU_COMPCITY.Text+ "', '"+TXT_CU_COMPZIPCODE.Text+"', '" +TXT_CU_COMPPHNAREA.Text+ "', '" +
						TXT_CU_COMPPHNNUM.Text+ "', '" +TXT_CU_COMPPHNEXT.Text+ "', '" +TXT_CU_COMPFAXAREA.Text+ "', '" +TXT_CU_COMPFAXNUM.Text+ "', '" +TXT_CU_COMPFAXEXT.Text+ "', '" +
						DDL_CU_COMPBUSSTYPE.SelectedValue+"' "+
						", " + tool.ConvertDate(TXT_CU_COMPESTABLISHDD.Text, DDL_CU_COMPESTABLISHMM.SelectedValue, TXT_CU_COMPESTABLISHYY.Text) + " "+
						", '" +TXT_CU_COMPNPWP.Text+ "', '" +TXT_CU_CONTACTPERSON.Text+ "', '" +TXT_CU_CONTACTPHNAREA.Text+ "', '"+
						TXT_CU_CONTACTPHNNUM.Text+ "', '" +TXT_CU_CONTACTPHNEXT.Text+ "', '" +TXT_CU_CIF_C.Text+ "' "+
						", '"+ RBL_CU_COMPRATING.SelectedValue +"', '"+ RBL_CU_RESTRUCTURE.SelectedValue +"', '" + TXT_CU_GROUPCUST.Text + "', '" + 
						TXT_CU_GRPADDR1.Text + "', '" + TXT_CU_GRPADDR2.Text + "', '" + TXT_CU_GRPADDR3.Text + "', " + tool.ConvertNull(DDL_CU_GRPBUSSTYPE.SelectedValue) + ", '" + 
						TXT_CU_GRPPHNAREA.Text + "', '" + TXT_CU_GRPPHNNUM.Text + "', '" + TXT_CU_GRPPHNEXT.Text + "', '" + RDO_CU_PERNAHJDNASABAHBM.SelectedValue + "','" +
						TXT_CU_COMPEMPLOYEE.Text + "', '" + TXT_CU_AKTAPENDIRIAN.Text + "', '" + TXT_CU_TDP.Text + "','" + RDO_CU_COMPPROBLEM.SelectedValue + "', " + 
						tool.ConvertNull(DDL_JNSALAMAT_C.SelectedValue) + ", " + 
						tool.ConvertNull(DDL_CU_JNSNASABAH.SelectedValue) + ", " + 
						tool.ConvertDate(TXT_CU_COMPTGASURANSI_DAY.Text, DDL_CU_TGASURANSI_MONTH.SelectedValue, TXT_CU_COMPTGASURANSI_YEAR.Text) + ", " + 
						tool.ConvertNull(TXT_CU_GRPREMARK.Text.Trim()) + ", " + 
						RDO_CU_INWATCHLIST.SelectedValue + ", " + 
						tool.ConvertNull(DDL_CU_COMPRATINGREASON.SelectedValue) + "";
					conn.ExecuteNonQuery();

					//--- untuk memecah kebanyakan argumen
					conn.QueryString = "exec IDE_GENINFO_COMP_INSERT2 '" + 
						Request.QueryString["curef"] + "', " + 
						tool.ConvertDate(TXT_CU_COMPTGASURANSI_DAY.Text, DDL_CU_TGASURANSI_MONTH.SelectedValue, TXT_CU_COMPTGASURANSI_YEAR.Text) + ", " + // tanggal issuance
						tool.ConvertDate(TXT_CU_TGLJATUHTEMPO_DAY.Text, DDL_CU_TGLJATUHTEMPO_MONTH.SelectedValue, TXT_CU_TGLJATUHTEMPO_YEAR.Text) + ", " + // tanggal jatuh tempo
						tool.ConvertDate(TXT_CU_TGLTERBIT_DAY.Text, DDL_CU_TGLTERBIT_MONTH.SelectedValue, TXT_CU_TGLTERBIT_YEAR.Text) + ", " + // tgl penerbitan
						tool.ConvertNull(TXT_CU_COMPNOTARYNAME.Text.Trim()) + ", " +	// nama notaris
						tool.ConvertNull(TXT_CU_COMPANGGOTA.Text.Trim());
					conn.ExecuteNonQuery();

				}
				else //if personal
				{
					conn.QueryString = "exec DE_NASABAHGROUPINFO_PERSONAL '" +Request.QueryString["curef"]+ "', '" +TXT_CU_FIRSTNAME.Text+ "', '" +TXT_CU_MIDDLENAME.Text+ "', '" +TXT_CU_LASTNAME.Text+ "', '" +
						TXT_CU_ADDR1.Text+"', '" +TXT_CU_ADDR2.Text+ "', '" +TXT_CU_ADDR3.Text+ "', '" +LBL_CU_CITY.Text+ "', '" +TXT_CU_ZIPCODE.Text+ "', '" +TXT_CU_PHNAREA.Text+ "', '" +TXT_CU_PHNNUM.Text+ "', '" +
						TXT_CU_PHNEXT.Text+ "', '" +TXT_CU_FAXAREA.Text+ "', '" +TXT_CU_FAXNUM.Text+ "', '" +TXT_CU_FAXEXT.Text+ "', '" +TXT_CU_POB.Text+ "', "+
						tool.ConvertDate(TXT_CU_DOB_DAY.Text,DDL_CU_DOB_MONTH.SelectedValue,TXT_CU_DOB_YEAR.Text)+", " +tool.ConvertNull(DDL_CU_MARITAL.SelectedValue)+ ", " +tool.ConvertNull(DDL_CU_SEX.SelectedValue)+ ", " +
						tool.ConvertNull(ddl_CU_CITIZENSHIP.SelectedValue)+ ", '" +TXT_CU_IDCARDNUM.Text+ "', " +tool.ConvertDate(TXT_CU_IDCARDEXP_DAY.Text,DDL_CU_IDCARDEXP_MONTH.SelectedValue,TXT_CU_IDCARDEXP_YEAR.Text)+ ", " +
						tool.ConvertNull(DDL_CU_JOBTITLE.SelectedValue)+ ", " +tool.ConvertNull(DDL_CU_BUSSTYPE.SelectedValue)+ " "+
						", " + tool.ConvertDate(TXT_CU_ESTABLISHDD.Text, DDL_CU_ESTABLISHMM.SelectedValue, TXT_CU_ESTABLISHYY.Text) +
						", '" +TXT_CU_NPWP.Text+"' , '" +TXT_CU_CIF_P.Text+ "' "+
						", '"+ RBL_CU_COMPRATING.SelectedValue +"', '"+ RBL_CU_RESTRUCTURE.SelectedValue +"', '" + TXT_CU_GROUPCUST.Text + "', '" + 
						TXT_CU_GRPADDR1.Text + "', '" + TXT_CU_GRPADDR2.Text + "', '" + TXT_CU_GRPADDR3.Text + "', " + tool.ConvertNull(DDL_CU_GRPBUSSTYPE.SelectedValue) + ", '" + 
						TXT_CU_GRPPHNAREA.Text + "', '" + TXT_CU_GRPPHNNUM.Text + "', '" + TXT_CU_GRPPHNEXT.Text + "', '" + RDO_CU_PERNAHJDNASABAHBM.SelectedValue + "','" + 
						RDO_CU_COMPPROBLEM.SelectedValue + "', '"+TXT_CU_TITLEBEFORENAME.Text+"', " + 
						tool.ConvertNull(TXT_CU_GRPREMARK.Text.Trim()) + ", " + 
						RDO_CU_INWATCHLIST.SelectedValue + ", " + 
						TXT_CU_CHILDREN.Text + ", " + 
						tool.ConvertNull(DDL_CU_COMPRATINGREASON.SelectedValue) + ",'"+
						TXT_CU_MOTHER.Text+"', '" +
                        TXT_CU_TEMPATKERJA.Text + "', '" +
                        DDL_CU_KODEINSTANSI.SelectedValue + "', '" +
                        TXT_CU_NOPEGAWAI.Text + "'";
					conn.ExecuteNonQuery();

					//--- untuk menyimpan informasi spouse/pasangan
					conn.QueryString = "exec IDE_GENINFO_PERSON_INSERT3 '" + Request.QueryString["curef"] + "', " + 
						tool.ConvertNull(TXT_CU_SPOUSE_FNAME.Text.Trim()) + ", " + 
						tool.ConvertNull(TXT_CU_SPOUSE_MNAME.Text.Trim()) + ", " + 
						tool.ConvertNull(TXT_CU_SPOUSE_LNAME.Text.Trim()) + ", " + 
						tool.ConvertNull(TXT_CU_SPOUSE_IDCARDNUM.Text.Trim()) + ", " + 
						tool.ConvertNull(TXT_CU_SPOUSE_KTPADDR1.Text.Trim()) + ", " + 
						tool.ConvertNull(TXT_CU_SPOUSE_KTPADDR2.Text.Trim()) + ", " + 
						tool.ConvertNull(TXT_CU_SPOUSE_KTPADDR3.Text.Trim()) + ", " + 
						tool.ConvertDate(TXT_CU_SPOUSE_KTPISSUEDATE_DAY.Text, DDL_CU_SPOUSE_KTPISSUEDATE_MONTH.SelectedValue, TXT_CU_SPOUSE_KTPISSUEDATE_YEAR.Text) + ", " + 
						tool.ConvertDate(TXT_CU_SPOUSE_KTPEXPDATE_DAY.Text, DDL_CU_SPOUSE_KTPEXPDATE_MONTH.SelectedValue, TXT_CU_SPOUSE_KTPEXPDATE_YEAR.Text) + " , " + 
						tool.ConvertNull(TXT_CU_NOKARTUKELUARGA.Text.Trim()) + "";
					conn.ExecuteNonQuery();

										
					conn.QueryString = "exec IDE_GENINFO_PERSON_INSERT2 '" + Request.QueryString["curef"] + "', " + 
						tool.ConvertNull(DDL_CU_HOMESTA.SelectedValue) + ", " + 
						tool.ConvertNull(TXT_CU_MULAIMENETAPMM.Text) + ", " + 
						tool.ConvertNull(TXT_CU_MULAIMENETAPYY.Text) + ", " +
						tool.ConvertNull(TXT_CU_EMPLOYEE.Text.Trim()) + "";
					conn.ExecuteNonQuery();
				}
			} 
			catch (ApplicationException) 
			{
				GlobalTools.popMessage(this, "Input tidak valid !");
				return;
			}
			catch (NullReferenceException) 
			{
				Tools.popMessage(this, "Server Error !");
				return;
			}

			ViewData();
		}

		protected void TXT_CU_ZIPCODE_TextChanged(object sender, System.EventArgs e)
		{
			conn.QueryString = "select cityid, cityname, description from vw_zipcodecity where rtrim(ltrim(zipcode)) = '" + 
				TXT_CU_ZIPCODE.Text.Trim() + "' ";
			conn.ExecuteQuery();
			try
			{
				LBL_CU_CITY.Text = conn.GetFieldValue(0,0);
				TXT_CU_CITY.Text = conn.GetFieldValue(0,2);
			}
			catch
			{
				TXT_CU_COMPZIPCODE.Text = "";
				Response.Write("<script language='javascript'>alert('Invalid Zipcode!');</script>");
			}
		}

		protected void TXT_CU_COMPZIPCODE_TextChanged(object sender, System.EventArgs e)
		{
			conn.QueryString = "select cityid, cityname, description from vw_zipcodecity where rtrim(ltrim(zipcode)) = '" + 
				TXT_CU_COMPZIPCODE.Text.Trim() + "' ";
			conn.ExecuteQuery();
			try
			{
				LBL_CU_COMPCITY.Text = conn.GetFieldValue(0,0);
				TXT_CU_COMPCITY.Text = conn.GetFieldValue(0,2);
			}
			catch
			{
				TXT_CU_COMPZIPCODE.Text = "";
				Response.Write("<script language='javascript'>alert('Invalid Zipcode!');</script>");
			}
		}

		protected void BTN_SEARCHPERSONAL_Click(object sender, System.EventArgs e)
		{
			//Response.Write("<script language='javascript'>window.open('../InitialDataEntry/SearchZipcode.aspx?targetFormID=Form1&targetObjectID=TXT_CU_ZIPCODE','SearchZipcode','status=no,scrollbars=no,width=420,height=200');</script>");
            Response.Write("<script language='javascript'>window.open('../InitialDataEntry/SearchZipcode.aspx?targetFormID=Form1&targetObjectID=TXT_CU_ZIPCODE&trgObjID2=TXT_CU_ADDR3&trgObjID3=TXT_CU_CITY&trgObjID4=LBL_CU_CITY','SearchZipcode','status=no,scrollbars=no,width=640,height=480');</script>");
		}

		protected void BTN_SEARCHCOMP_Click(object sender, System.EventArgs e)
		{
			//Response.Write("<script language='javascript'>window.open('../InitialDataEntry/SearchZipcode.aspx?targetFormID=Form1&targetObjectID=TXT_CU_COMPZIPCODE','SearchZipcode','status=no,scrollbars=no,width=420,height=200');</script>");
            Response.Write("<script language='javascript'>window.open('../InitialDataEntry/SearchZipcode.aspx?targetFormID=Form1&targetObjectID=TXT_CU_COMPZIPCODE&trgObjID2=TXT_CU_COMPADDR3&trgObjID3=TXT_CU_COMPCITY&trgObjID4=LBL_CU_COMPCITY','SearchZipcode','status=no,scrollbars=no,width=640,height=480');</script>");
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
						if (conn.GetFieldValue(i,3).IndexOf("mc=") >= 0)
							strtemp = "regno=" + Request.QueryString["regno"] + "&curef="+Request.QueryString["curef"]+"&tc="+Request.QueryString["tc"];
						else	strtemp = "regno=" + Request.QueryString["regno"] + "&curef="+Request.QueryString["curef"]+"&mc="+Request.QueryString["mc"]+"&tc="+Request.QueryString["tc"];
						if (conn.GetFieldValue(i,3).IndexOf("?de=") < 0 && conn.GetFieldValue(i,3).IndexOf("&de=") < 0) 
							strtemp = strtemp + "&de=" + Request.QueryString["de"];	
						if (conn.GetFieldValue(i,3).IndexOf("?par=") < 0 && conn.GetFieldValue(i,3).IndexOf("&par=") < 0)  
							strtemp = strtemp + "&par=" + Request.QueryString["par"];

						//t.ForeColor = Color.MidnightBlue; 
						/*
						if (conn.GetFieldValue(i,3).IndexOf("de=") < 0) strtemp = strtemp + "&de=" + Request.QueryString["de"];
						if (conn.GetFieldValue(i,3).IndexOf("par=") < 0)  strtemp = strtemp + "&par=" + Request.QueryString["par"];
						*/
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
			if (Request.QueryString["par"] != null && Request.QueryString["par"] != "") 
				Response.Redirect(Request.QueryString["par"] + "&regno=" + Request.QueryString["regno"] + "&curef=" + Request.QueryString["curef"] + "&tc=" + Request.QueryString["tc"]);
			else
				Response.Redirect("/SME/" + DMS.CuBESCore.Logic.backLink(Request.QueryString["tc"].ToString(), conn));

		}	

		private void BTN_SEARCHCOMP1_Click(object sender, System.EventArgs e)
		{
			Response.Write("<script language='javascript'>window.open('../InitialDataEntry/SearchZipcode.aspx?targetFormID=Form1&targetObjectID=TXT_CS_ZIPCODE','SearchZipcode','status=no,scrollbars=no,width=420,height=200');</script>");
		}

	}
}
