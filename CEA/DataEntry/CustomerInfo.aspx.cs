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

namespace dbrbm.Data_Entry
{
	/// <summary>
	/// Summary description for CustomerInfo.
	/// </summary>
	public partial class CustomerInfo : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Button BTN_SEARCHPERSONAL;
		protected System.Web.UI.WebControls.Button BTN_SAVE;
		protected System.Web.UI.WebControls.DataGrid DatGrd;
		protected System.Web.UI.WebControls.HyperLink Hyperlink4;
		protected System.Web.UI.WebControls.Button BTN_SEARCHCOMP;
		protected System.Web.UI.WebControls.TextBox Textbox15;
		protected System.Web.UI.WebControls.TextBox Textbox14;
		protected System.Web.UI.WebControls.TextBox Textbox13;
		protected System.Web.UI.WebControls.TextBox cu_gelarssdh;
		protected System.Web.UI.WebControls.TextBox cu_kodepos;
		protected System.Web.UI.WebControls.DropDownList cu_jeniskelamin;
		protected System.Web.UI.WebControls.TextBox cu_npwp;
		protected System.Web.UI.WebControls.TextBox cu_comtmptberdiri;
		protected System.Web.UI.WebControls.TextBox cu_email;
		protected System.Web.UI.WebControls.TextBox cu_notelp;
		protected System.Web.UI.WebControls.TextBox cu_nofax;
		protected System.Web.UI.WebControls.TextBox cu_comkodepos;
		protected System.Web.UI.WebControls.TextBox cu_comnama;
		protected Connection conn;
		protected System.Web.UI.WebControls.Label lbl_cu_nama;
		protected System.Web.UI.WebControls.Label lbl_cu_kota;
		protected System.Web.UI.WebControls.Label lbl_comkota;
		protected System.Web.UI.WebControls.Label lbl_no_registrasi;
		protected System.Web.UI.WebControls.TextBox TXT_AREAID;
		protected System.Web.UI.WebControls.TextBox TXT_AP_RELMNGR;
		protected System.Web.UI.WebControls.Label LBL_AP_RELMNGR;
		protected System.Web.UI.WebControls.TextBox TXT_AP_SIGNDATE_DAY;
		protected System.Web.UI.WebControls.DropDownList DDL_AP_SIGNDATE_MONTH;
		protected System.Web.UI.WebControls.TextBox TXT_AP_SIGNDATE_YEAR;
		protected System.Web.UI.WebControls.TextBox TXT_AP_REGNO;
		protected System.Web.UI.WebControls.TextBox TXT_CU_REF;
		protected System.Web.UI.WebControls.TextBox Textbox2;
		protected System.Web.UI.WebControls.DropDownList Dropdownlist1;
		protected System.Web.UI.WebControls.TextBox Textbox1;
		protected System.Web.UI.WebControls.DropDownList cu_jenis;
		protected System.Web.UI.WebControls.TextBox cu_gelarsblm;
		protected System.Web.UI.WebControls.TextBox cu_nama;
		protected System.Web.UI.WebControls.TextBox cu_alamat1;
		protected System.Web.UI.WebControls.TextBox cu_alamat2;
		protected System.Web.UI.WebControls.TextBox cu_alamat3;
		protected System.Web.UI.WebControls.TextBox cu_kota;
		protected System.Web.UI.WebControls.TextBox cu_noktp;
		protected System.Web.UI.WebControls.TextBox cu_tglakhirday;
		protected System.Web.UI.WebControls.DropDownList cu_tglakhirmonth;
		protected System.Web.UI.WebControls.TextBox cu_tglakhiryear;
		protected System.Web.UI.WebControls.TextBox cu_tmptlahir;
		protected System.Web.UI.WebControls.TextBox cu_tgllahirday;
		protected System.Web.UI.WebControls.DropDownList cu_tgllahirmonth;
		protected System.Web.UI.WebControls.TextBox cu_tgllahiryear;
		protected System.Web.UI.WebControls.TextBox cu_ket;
		protected System.Web.UI.WebControls.DropDownList cu_comjenis;
		protected System.Web.UI.WebControls.TextBox cu_comnamadulu;
		protected System.Web.UI.WebControls.TextBox cu_comberdiriday;
		protected System.Web.UI.WebControls.DropDownList cu_comberdirimonth;
		protected System.Web.UI.WebControls.TextBox cu_comberdiriyear;
		protected System.Web.UI.WebControls.TextBox cu_comalamat1;
		protected System.Web.UI.WebControls.TextBox cu_comalamat2;
		protected System.Web.UI.WebControls.TextBox cu_comalamat3;
		protected System.Web.UI.WebControls.TextBox cu_comkota;
		protected System.Web.UI.WebControls.TextBox cu_comnotelp;
		protected System.Web.UI.WebControls.TextBox cu_comnofax;
		protected System.Web.UI.WebControls.TextBox cu_comemail;
		protected System.Web.UI.WebControls.TextBox cu_comnpwp;
		protected System.Web.UI.WebControls.TextBox cu_comket;
		protected System.Web.UI.WebControls.Button BTN_NEW;
		protected System.Web.UI.WebControls.Button Button1;
		protected Tools tool = new Tools();

		private void InitializeComponent()
		{
		
		}
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			/*			conn = new Connection(ConfigurationSettings.AppSettings["conn"]);

						//if (!Logic.AllowAccess(Session["GroupID"].ToString(), Request.QueryString["mc"], conn))
						//	Response.Redirect("/SME/Restricted.aspx");
			
						if (!IsPostBack)
						{
							RDO_RFCUSTOMERTYPE.Items.Add(new ListItem("Badan Usaha", "01"));
							RDO_RFCUSTOMERTYPE.Items.Add(new ListItem("Perorangan", "02"));
							GlobalTools.fillRefList(cu_jenis, "select * from ddl_jenis where ACTIVE='1'", true, conn);
							GlobalTools.fillRefList(cu_comjenis, "select * from ddl_comjenis where ACTIVE='1'", true, conn);
							GlobalTools.fillRefList(cu_jeniskelamin, "select * from ddl_jeniskelamin where ACTIVE='1'", true, conn);

							for (int i = 1; i <= 12; i++)
							{
								cu_tglakhirmonth.Items.Add(new ListItem(DateAndTime.MonthName(i, false), i.ToString()));
								cu_tgllahirmonth.Items.Add(new ListItem(DateAndTime.MonthName(i, false), i.ToString()));
								cu_comberdirimonth.Items.Add(new ListItem(DateAndTime.MonthName(i, false), i.ToString()));
							}
						}

						BTN_SAVE.Attributes.Add("onclick","if(!cek_mandatory(document.Form1)){return false;};");
						BTN_NEW.Attributes.Add("onclick", "if(!cek_mandatory2(document.Form1)){return false;};");
					}

					private void ViewData()
					{
						string noreg = Request.QueryString["noreg"];
						conn.QueryString = "select CU_CUSTTYPEID from customer where no_registrasi='" + noreg + "'";
						conn.ExecuteQuery();
						string cust_type = conn.GetFieldValue("CU_CUSTTYPEID");
						conn.ClearData();
						if (cust_type.Trim() == "02")
						{ // tipe customer = PERORANGAN
							TR_COMPANY.Visible					= false;
							TR_PERSONAL.Visible					= true;
							RDO_RFCUSTOMERTYPE.SelectedValue	= "02";
				
							conn.QueryString = "select * from cust_personal where no_registrasi='" + noreg + "'";
							conn.ExecuteQuery();

							try {cu_jenis.SelectedValue		= conn.GetFieldValue("cu_jenis");} 
							catch {}
							cu_gelarsblm.Text		= conn.GetFieldValue("cu_gelarsblm");
							cu_nama.Text			= conn.GetFieldValue("cu_nama");
							cu_gelarssdh.Text		= conn.GetFieldValue("cu_gelarssdh");
							cu_alamat1.Text			= conn.GetFieldValue("cu_alamat1");
							cu_alamat2.Text			= conn.GetFieldValue("cu_alamat2");
							cu_alamat3.Text			= conn.GetFieldValue("cu_alamat3");
							cu_kota.Text			= conn.GetFieldValue("cu_kota");
							cu_kodepos.Text			= conn.GetFieldValue("cu_kodepos");
							cu_notelp.Text			= conn.GetFieldValue("cu_notelp");
							cu_nofax.Text			= conn.GetFieldValue("cu_nofax");
							cu_email.Text			= conn.GetFieldValue("cu_email");
							try {cu_jeniskelamin.SelectedValue		= conn.GetFieldValue("cu_jeniskelamin");} 
							catch {}
							cu_noktp.Text			= conn.GetFieldValue("cu_noktp");
							string dektp			= conn.GetFieldValue("cu_tgllahir");
							cu_tglakhirday.Text		= tool.FormatDate_Day(dektp);
							cu_tglakhirmonth.SelectedValue	= tool.FormatDate_Month(dektp);
							cu_tglakhiryear.Text	= tool.FormatDate_Year(dektp);
							cu_tmptlahir.Text		= conn.GetFieldValue("cu_tmptlahir");
							string tgllahir				= conn.GetFieldValue("cu_tgllahir");
							cu_tgllahirday.Text		= tool.FormatDate_Day(tgllahir);
							cu_tgllahirmonth.SelectedValue	= tool.FormatDate_Month(tgllahir);
							cu_tgllahiryear.Text	= tool.FormatDate_Year(tgllahir);
							cu_npwp.Text			= conn.GetFieldValue("cu_npwp");
							cu_ket.Text				= conn.GetFieldValue("cu_ket");
						}
						else
						{ // tipe customer = BADAN USAHA
							TR_COMPANY.Visible					= true;
							TR_PERSONAL.Visible					= false;
							RDO_RFCUSTOMERTYPE.SelectedValue	= "01";

							conn.QueryString = "select * from cust_company where no_registrasi='" + noreg + "'";
							conn.ExecuteQuery();
				
							try {cu_comjenis.SelectedValue		= conn.GetFieldValue("cu_comjenis");} 
							catch {}
							cu_npwp.Text			= conn.GetFieldValue("cu_npwp");
							cu_comnama.Text			= conn.GetFieldValue("cu_nama");
							cu_comnamadulu.Text		= conn.GetFieldValue("cu_namadulu");
							cu_comalamat1.Text		= conn.GetFieldValue("cu_alamat1");
							cu_comalamat2.Text		= conn.GetFieldValue("cu_alamat2");
							cu_comalamat3.Text		= conn.GetFieldValue("cu_alamat3");
							cu_comkota.Text			= conn.GetFieldValue("cu_kota");
							cu_comkodepos.Text		= conn.GetFieldValue("cu_kodepos");
							cu_comnotelp.Text		= conn.GetFieldValue("cu_notelp");
							cu_comnofax.Text		= conn.GetFieldValue("cu_nofax");
							cu_comemail.Text		= conn.GetFieldValue("cu_email");
							string berdirisejak		= conn.GetFieldValue("cu_berdirisejak");
							cu_comberdiriday.Text	= tool.FormatDate_Day(berdirisejak);
							cu_comberdirimonth.SelectedValue	= tool.FormatDate_Month(berdirisejak);
							cu_comberdiriyear.Text	= tool.FormatDate_Year(berdirisejak);
							cu_comtmptberdiri.Text	= conn.GetFieldValue("cu_tmptberdiri");
							cu_comket.Text			= conn.GetFieldValue("cu_ket");
						}


					}

					private void InitializeComponent()
					{
						this.RDO_RFCUSTOMERTYPE.SelectedIndexChanged += new System.EventHandler(this.RDO_RFCUSTOMERTYPE_SelectedIndexChanged_1);
						this.BTN_save_rekanan.Click += new System.EventHandler(this.BTN_NEW_Click);
						this.Load += new System.EventHandler(this.Page_Load);

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
	
						#endregion

					private void RDO_RFCUSTOMERTYPE_SelectedIndexChanged(object sender, System.EventArgs e)
					{
						if (RDO_RFCUSTOMERTYPE.SelectedValue == "01")
						{
							TR_COMPANY.Visible	= true;
							TR_PERSONAL.Visible = false;
						}
						else
						{
							TR_COMPANY.Visible	= false;
							TR_PERSONAL.Visible = true;
						}		
					}
					private bool isInputValid(string customerType) 
					{
						string no_registrasi = Request.QueryString["noreg"];
						bool validkah = true;

						if (customerType == "01") // company
						{
							//--- Cek NPWP Perusahaan
							conn.QueryString = "select count (*) from CUSTOMER where no_registrasi <> '" + no_registrasi + "' and cu_npwp = '" + cu_comnpwp.Text + "'";
							conn.ExecuteQuery();
							if (conn.GetFieldValue(0,0) != "0")
							{
								Response.Write("<script language='javascript'>alert('Customer with NPWP: " + cu_comnpwp.Text + " exists in the system!');</script>");
								GlobalTools.SetFocus(this, cu_npwp);
								return false;
							}

							//--- Cek Berdiri Sejak		
							if(!GlobalTools.isDateValid(this,cu_comberdiriday.Text, cu_comberdirimonth.SelectedValue, cu_comberdiriyear.Text))
							{
								Response.Write("<script language='javascript'>alert('Tanggal berdiri sejak tidak valid!');</script>");
								GlobalTools.SetFocus(this, cu_comberdiriday);
								return false;
							}
						
						}
						else	// personal
						{
							//--- Cek tanggal lahir
							if (!GlobalTools.isDateValid(this, cu_tgllahirday.Text.Trim(), cu_tgllahirmonth.SelectedValue, cu_tgllahiryear.Text.Trim())) 
							{
								Response.Write("<script language='javascript'>alert('Tanggal Lahir tidak valid');</script>");
								GlobalTools.SetFocus(this, cu_tgllahirday);
								return false;
							}
							if (GlobalTools.isFuture(cu_tgllahirday.Text.Trim(), cu_tgllahirmonth.SelectedValue, cu_tgllahiryear.Text.Trim())) 
							{
								Response.Write("<script language='javascript'>alert('Tanggal Lahir melewati Tanggal sekarang!');</script>");
								GlobalTools.SetFocus(this, cu_tgllahirday);
								return false;
							}

							string TGL_KTP = GlobalTools.ToSQLDate(cu_tglakhirday.Text.Trim(), cu_tglakhirmonth.SelectedValue, cu_tglakhiryear.Text.Trim());
							conn.QueryString = "select count (*) from cust_personal where no_registrasi <> '" + no_registrasi + "' and cu_noktp='" + cu_noktp.Text + "' and cu_tglakhirktp = " + TGL_KTP + "";
							conn.ExecuteQuery();

							if (conn.GetFieldValue(0,0) != "0")
							{
								Response.Write("<script language='javascript'>alert('Customer with KTP: " + cu_noktp.Text + " and Expire Date: " + TGL_KTP.Replace("'","") + " exists in the system!');</script>");
								GlobalTools.SetFocus(this, cu_noktp);
								return false;
							}				

								
							Int64 personalEstablish;
							Int64 now = Int64.Parse(Tools.toISODate(DateTime.Now.Day.ToString(), DateTime.Now.Month.ToString(), DateTime.Now.Year.ToString()));

							//////////////////////////////////////////////////////////////
							///	VALIDASI BERDIRI SEJAK
							///	
							if (int.Parse(cu_comberdirimonth.SelectedValue) > 12)
							{
								GlobalTools.popMessage(this, "Berdiri Sejak (MM) tidak valid");
								return false;
							}
							try 
							{
								personalEstablish = Int64.Parse(Tools.toISODate(cu_comberdiriday.Text, cu_comberdirimonth.SelectedValue, cu_comberdiriyear.Text));
							}
							catch 
							{
								GlobalTools.popMessage(this, "Berdiri Sejak tidak valid!");
								return false;
							}
							if (personalEstablish > now)
							{
								GlobalTools.popMessage(this, "Berdiri Sejak cannot be greater than current date!");
								return false;
							}

							//////////////////////////////////////////////////////////////////
							/// VALIDASI TANGGAL LAHIR
							/// 
							if (!GlobalTools.isDateValid(cu_tgllahirday.Text, cu_tgllahirmonth.SelectedValue, cu_tgllahiryear.Text)) 
							{
								GlobalTools.popMessage(this, "Tanggal Lahir tidak valid!");
								return false;
							}

							////////////////////////////////////////////////////////////////////
							///	VALIDASI TANGGAL BERAKHIR KTP
							///	
							if (!GlobalTools.isDateValid(cu_tglakhirday.Text, cu_tglakhirmonth.SelectedValue, cu_tglakhiryear.Text)) 
							{
								GlobalTools.popMessage(this, "Tanggal Berakhir KTP tidak valid!");
								return false;
							}

							Int64 idcardexp = Int64.Parse(Tools.toISODate(cu_tglakhirday.Text, cu_tglakhirmonth.SelectedValue, cu_tglakhiryear.Text));
							if (idcardexp < now) 
							{
								GlobalTools.popMessage(this, "Tanggal Berakhir KTP tidak boleh kurang dari tanggal sekarang!");
								return false;
							}

						}
						return validkah;
					}

					private void BTN_SAVE_Click(object sender, System.EventArgs e)
					{
						string noreg = Request.QueryString["noreg"];	
						if (!isInputValid(RDO_RFCUSTOMERTYPE.SelectedValue)) return;

						if (RDO_RFCUSTOMERTYPE.SelectedValue == "01")
						{ // kasus customer merupakan Badan Usaha
							conn.QueryString = "select cu_npwp from customer where cu_npwp='"+cu_comnpwp.Text+"' and no_registrasi<>'"+noreg+"' ";
							conn.ExecuteQuery();
							int row = conn.GetRowCount();
							if (row>0)
							{
								Tools.popMessage(this,"NPWP "+cu_comnpwp.Text+" already exist with another customer !");
								Tools.SetFocus(this,cu_comnpwp);
							}
							else
							{
					
									conn.QueryString = "exec IN_INFOCUST_COMPANY '" + 
						
									RDO_RFCUSTOMERTYPE.SelectedValue + "', '" +
									noreg + "', '" +
									cu_comjenis.SelectedValue + "', '" + 
									cu_comnpwp.Text + "', '" + 
									cu_comnama.Text + "', '" + 
									cu_comnamadulu.Text + "', '" + 
									cu_comalamat1.Text + "', '" + cu_comalamat2.Text + "', '" + cu_comalamat3.Text + "', '" + 
									cu_comkota.Text + "', '" + 
									cu_comkodepos.Text + "', '" + 
									cu_comnotelp.Text + "', '" + 
									cu_comnofax.Text + "', '" +
									cu_comemail.Text + "', " +
									tool.ConvertDate(cu_comberdiriday.Text, cu_comberdirimonth.SelectedValue ,cu_comberdiriyear.Text) + ", '" +
									cu_comtmptberdiri.Text + "','"+
									cu_comket.Text + "'";

								conn.ExecuteNonQuery();
								RDO_RFCUSTOMERTYPE.Enabled = false;
								lbl_cu_nama.Text	= "exist";
								BTN_NEW.Enabled	= true;
								ViewData();
							}
						}				
						else
						{

							conn.QueryString = "select cu_npwp from customer where cu_npwp='" + cu_npwp.Text + "' and no_registrasi<>'" + noreg + "' and cu_npwp <> ''";
							conn.ExecuteQuery();
							int row = conn.GetRowCount();
							if (row>0)
							{
								Tools.popMessage(this,"NPWP "+cu_npwp.Text+" already exist with another customer !");
								Tools.SetFocus(this,cu_npwp);
							}
							else
							{
								conn.QueryString = "exec IN_INFOCUST_PERSONAL '" + 
									noreg + "', '" + RDO_RFCUSTOMERTYPE.SelectedValue + "', '" +
									lbl_no_registrasi.Text + "', '" +
									cu_npwp.Text +"', '" +
									cu_gelarsblm.Text + "', '" + cu_nama.Text + "', '" + cu_gelarssdh.Text + "', '" + 
									cu_alamat1.Text + "', '" + cu_alamat2.Text + "', '" + cu_alamat3.Text + "', '" + 
									cu_kota.Text + "', '" + cu_kodepos.Text + "', '" + 
									cu_notelp.Text + "', '" + 
									cu_nofax.Text + "', '" + 
									cu_ket.Text + "', '" +
									tool.ConvertNull(cu_jeniskelamin.SelectedValue) + ", '" + 
									cu_tmptlahir.Text + "', " + tool.ConvertDate(cu_tgllahirday.Text, cu_tgllahirmonth.SelectedValue, cu_tgllahiryear.Text) + ", " +
									cu_noktp.Text + "', " + tool.ConvertDate(cu_tglakhirday.Text, cu_tglakhirmonth.SelectedValue, cu_tglakhiryear.Text) + ", " + 
									tool.ConvertDate(cu_tgllahirday.Text, cu_tgllahirmonth.SelectedValue ,cu_tgllahiryear.Text);
								conn.ExecuteNonQuery();

								RDO_RFCUSTOMERTYPE.Enabled = false;
								lbl_cu_nama.Text	= "exist";
								BTN_NEW.Enabled	= true;
								ViewData();
							}
						}
					}

					private void BTN_NEW_Click(object sender, System.EventArgs e)
					{
						string noreg = lbl_no_registrasi.Text;			

						if (RDO_RFCUSTOMERTYPE.SelectedValue == "01")
						{ // kasus customer merupakan Badan Usaha
							conn.QueryString = "select cu_npwp from customer where cu_npwp='"+cu_comnpwp.Text+"' and no_registrasi<>'"+noreg+"' ";
							conn.ExecuteQuery();
							int row = conn.GetRowCount();
							if (row>0)
							{
								Tools.popMessage(this,"NPWP "+cu_comnpwp.Text+" already exist with another customer !");
								Tools.SetFocus(this,cu_comnpwp);
							}
							else
							{
					
								conn.QueryString = "exec IN_INFOCUST_COMPANY '" + 
									RDO_RFCUSTOMERTYPE.SelectedValue + "', '" +
									noreg + "', '" +
									cu_comjenis + "', '" +
									cu_comnpwp.Text + "', '" + 
									cu_comnama.Text + "', '" + 
									cu_comnamadulu.Text + "', '" + 
									cu_comalamat1.Text + "', '" + cu_comalamat2.Text + "', '" + cu_comalamat3.Text + "', '" + 
									cu_comkota.Text + "', '" + 
									cu_comkodepos.Text + "', " +
									cu_comnotelp.Text + "', '" +
									cu_comnofax.Text + "', '" +
									cu_comemail.Text + "', " +
									tool.ConvertDate(cu_comberdiriday.Text, cu_comberdirimonth.SelectedValue ,cu_comberdiriyear.Text) + ", '" +
									cu_comtmptberdiri.Text + "', '" +
									cu_comket.Text + "'";
								conn.ExecuteNonQuery();


								/*conn.QueryString = "exec IDE_GENINFO_COMP_INSERT2 '" + 
									noreg + "', " + 
									tool.ConvertDate(TXT_CU_ISSUANCEDATE_DAY.Text,DDL_CU_ISSUANCEDATE_MONTH.SelectedValue,TXT_CU_ISSUANCEDATE_YEAR.Text) + ", " + // tanggal issuance
									tool.ConvertDate(TXT_CU_TGLJATUHTEMPO_DAY.Text, DDL_CU_TGLJATUHTEMPO_MONTH.SelectedValue, TXT_CU_TGLJATUHTEMPO_YEAR.Text) + ", " + // tanggal jatuh tempo
									tool.ConvertDate(TXT_CU_TGLTERBIT_DAY.Text, DDL_CU_TGLTERBIT_MONTH.SelectedValue, TXT_CU_TGLJATUHTEMPO_YEAR.Text) + ", " + // tgl penerbitan
									tool.ConvertNull(TXT_CU_COMPNOTARYNAME.Text.Trim()) + ", " +	// nama notaris
									tool.ConvertNull(TXT_CU_COMPANGGOTA.Text.Trim());
								conn.ExecuteNonQuery();
								*/
			/*
								RDO_RFCUSTOMERTYPE.Enabled = false;
								lbl_cu_nama.Text	= "exist";
								BTN_NEW.Enabled	= true;
								ViewData();
							}
						}				
						else
						{

							conn.QueryString = "select cu_npwp from customer where cu_npwp='" + cu_npwp.Text + "' and no_registrasi<>'" + noreg + "' and cu_npwp <> ''";
							conn.ExecuteQuery();
							int row = conn.GetRowCount();
							if (row>0)
							{
								Tools.popMessage(this,"NPWP "+cu_npwp.Text+" already exist with another customer !");
								Tools.SetFocus(this,cu_npwp);
							}
							else
							{
								conn.QueryString = "exec IN_INFOCUST_PERSONAL '" + 
									noreg + "', '" + RDO_RFCUSTOMERTYPE.SelectedValue + "', '" +
									lbl_no_registrasi.Text + "', '" +
									cu_npwp.Text +"', '" +
									cu_gelarsblm.Text + "', '" + cu_nama.Text + "', '" + cu_gelarssdh.Text + "', '" + 
									cu_alamat1.Text + "', '" + cu_alamat2.Text + "', '" + cu_alamat3.Text + "', '" + 
									cu_kota.Text + "', '" + cu_kodepos.Text + "', '" + 
									cu_notelp.Text + "', '" +
									cu_nofax.Text + "', '" +
									cu_ket.Text + "', '" +
									cu_tmptlahir.Text + "', " + tool.ConvertDate(cu_tgllahirday.Text, cu_tgllahirmonth.SelectedValue, cu_tgllahiryear.Text) + ", " +
									tool.ConvertNull(cu_jeniskelamin.SelectedValue) + ", '" + 
									cu_noktp.Text + "', " + tool.ConvertDate(cu_tglakhirday.Text, cu_tglakhirmonth.SelectedValue, cu_tglakhiryear.Text);
						
								conn.ExecuteNonQuery();

				
								RDO_RFCUSTOMERTYPE.Enabled = false;
								lbl_cu_nama.Text	= "exist";
								BTN_NEW.Enabled	= true;
								ViewData();
							}

						}
					}

					private void RDO_RFCUSTOMERTYPE_SelectedIndexChanged_1(object sender, System.EventArgs e)
					{
						if (RDO_RFCUSTOMERTYPE.SelectedValue == "01")
						{
							TR_COMPANY.Visible	= true;
							TR_PERSONAL.Visible = false;
						}
						else
						{
							TR_COMPANY.Visible	= false;
							TR_PERSONAL.Visible = true;
						}
					}

					private void BTN_SEARCHPERSONAL_Click(object sender, System.EventArgs e)
					{
						Response.Write("<script language='javascript'>window.open('SearchZipcode.aspx?targetFormID=Form1&targetObjectID=cu_kodepos','SearchZipcode','status=no,scrollbars=yes,width=420,height=200');</script>");
					}

					private void cu_kodepos_TextChanged(object sender, System.EventArgs e)
					{
						lbl_cu_kota.Text = "";
						cu_kota.Text = "";
						conn.QueryString = "select cityid, description from rfkodepos where rtrim(ltrim(zipcode)) = '" + 
							cu_kodepos.Text.Trim() + "' ";
						conn.ExecuteQuery();
						for (int i = 0; i < conn.GetRowCount(); i++)
						{
							lbl_cu_kota.Text = conn.GetFieldValue(i,0);
							cu_kota.Text = conn.GetFieldValue(i,1);
						}
					}
		
					private void cu_comkodepos_TextChanged(object sender, System.EventArgs e)
					{
						lbl_cu_kota.Text = "";
						cu_comkota.Text = "";
						conn.QueryString = "select cityid, description from rfkodepos where rtrim(ltrim(zipcode)) = '" + 
							cu_comkodepos.Text.Trim() + "' ";
						conn.ExecuteQuery();
						for (int i = 0; i < conn.GetRowCount(); i++)
						{
							lbl_cu_kota.Text = conn.GetFieldValue(i,0);
							cu_comkota.Text = conn.GetFieldValue(i,1);
						}
					}

					private void BTN_SEARCHCOMP_Click(object sender, System.EventArgs e)
					{
						Response.Write("<script language='javascript'>window.open('SearchZipcode.aspx?targetFormID=Form1&targetObjectID=cu_comkodepos','SearchZipcode','status=no,scrollbars=yes,width=420,height=200');</script>");
					}

		

			*/		
		}
	}}