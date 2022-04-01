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

namespace SME.CEA.DataEntry
{
	/// <summary>
	/// Summary description for InfoPerusahaanCEA.
	/// </summary>
	public partial class InfoPerusahaanCEA : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.TextBox TXT_No_ijin;
		protected System.Web.UI.WebControls.TextBox TXT_DikelOl_ijin;
		protected System.Web.UI.WebControls.TextBox TXT_tglDoc_ijin;
		protected System.Web.UI.WebControls.DropDownList Drop_TglDoc_ijin;
		protected System.Web.UI.WebControls.TextBox TXT_th_ijin;
		protected System.Web.UI.WebControls.TextBox TXT_tglAkhir_ijin;
		protected System.Web.UI.WebControls.DropDownList Drop_tglAkhir_ijin;
		protected System.Web.UI.WebControls.TextBox TXT_thAkhir_ijin;
		protected System.Web.UI.WebControls.TextBox TXT_Notaris_ijin;
		protected System.Web.UI.WebControls.Button BTN_insert_ijin;
		protected System.Web.UI.WebControls.Button BTN_clear_ijin;
		protected System.Web.UI.WebControls.TextBox nama_company;
		protected System.Web.UI.WebControls.TextBox tglhr_berdiri_company;
		protected System.Web.UI.WebControls.DropDownList tglbln_berdiri_company;
		protected System.Web.UI.WebControls.TextBox tglth_berdiri_perusahaan;
		protected System.Web.UI.WebControls.TextBox KTP_perusahaan;
		protected System.Web.UI.WebControls.TextBox tglakhirday_KTP_perusahaan;
		protected System.Web.UI.WebControls.DropDownList tglakhirbln_KTP_perusahaan;
		protected System.Web.UI.WebControls.TextBox tglakhirth_KTP_perusahaan;
		protected System.Web.UI.WebControls.TextBox persen_perusahaan;
		protected System.Web.UI.WebControls.TextBox nilaisaham_company;
		protected System.Web.UI.WebControls.RadioButtonList RDO_KEY_PERSON_perusahaan;
		protected System.Web.UI.WebControls.TextBox TXT_CS_NPWP_perusahaan;
		protected System.Web.UI.WebControls.Button add_dataperusahaan;

		private void InitializeComponent()
		{

		}
	
		protected System.Web.UI.WebControls.DropDownList cu_jenis;

		protected void Page_Load(object sender, System.EventArgs e)
		{
		
		}
	/*
		private void Page_Load(object sender, System.EventArgs e)
		{
			conn = new Connection(ConfigurationSettings.AppSettings["conn"]);

			if (!IsPostBack)
			{
				LBL_CUREF.Text = Request.QueryString["noreg"];

				DDL_CS_DOB_MONTH.Items.Add(new ListItem("- PILIH -", ""));
				DDL_CS_JOBTITLE.Items.Add(new ListItem("- PILIH -", ""));
				string nm_bln;

				for (int i=1; i<=12; i++)
				{
					nm_bln = DateAndTime.MonthName(i, false);
					DDL_CS_DOB_MONTH.Items.Add(new ListItem(nm_bln, i.ToString()));

				}


				//--- Job Title
				conn.QueryString = "select JOBTITLEID, JOBTITLEID + ' - ' + JOBTITLEDESC as JOBTITLEDESC from RFJOBTITLE where ACTIVE='1' order by JOBTITLEID";
				conn.ExecuteQuery();
				for (int i = 0; i < conn.GetRowCount(); i++)
					DDL_CS_JOBTITLE.Items.Add(new ListItem(conn.GetFieldValue(i,1), conn.GetFieldValue(i,0)));

				//--- Stock Holder Type
				conn.QueryString = "select custtypeid, custtypedesc from rfcustomertype where active='1'";
				conn.ExecuteQuery();
				for (int i = 0; i < conn.GetRowCount(); i++)
					RDO_RFCUSTOMERTYPE.Items.Add(new ListItem(conn.GetFieldValue(i,1), conn.GetFieldValue(i,0)));
				RDO_RFCUSTOMERTYPE.Items.Add(new ListItem("Lain-lain", "03"));	// Lain-lain

			{ 

				//TODO : Hardoced ?!
				RDO_RFCUSTOMERTYPE.SelectedValue = "02";


				FillCSGrid();

			}			

				//--- Kalau baru masuk pertama kali ke screen, maka
				//--- screen menu tidak perlu diperlihatkan
				if (Request.QueryString["info"] != "" && Request.QueryString["info"] != null)
					ViewMenu();

			}
		}


		private void ViewMenu()
		{
			try 
			{
				//SCREENMENU???
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
							strtemp = "regno=" + Request.QueryString["regno"] + "&noreg="+Request.QueryString["noreg"]+"&tc="+Request.QueryString["tc"];
						else	strtemp = "regno=" + Request.QueryString["regno"] + "&noreg="+Request.QueryString["noreg"]+"&mc="+Request.QueryString["mc"]+"&tc="+Request.QueryString["tc"];

						//---  untuk general info
						if (conn.GetFieldValue(i,3).IndexOf("?exist=") < 0 && conn.GetFieldValue(i,3).IndexOf("&exist=") < 0) 
							strtemp = strtemp + "&exist=" + Request.QueryString["exist"];	

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
		
	
		private void SecureData() 
		{
			string sta = Request.QueryString["sta"];
			if (sta == "view")
			{
				System.Web.UI.ControlCollection coll = this.Page.Controls;
				int k = 0;
				for(k = 0; k < coll.Count; k++) 
				{
					if (coll[k] is System.Web.UI.HtmlControls.HtmlForm) 
					{
						break;
					}
				}

				for (int i = 0; i < coll[k].Controls.Count; i++) 
				{
					if (coll[k].Controls[i] is TextBox) 
					{
						TextBox txt = (TextBox) coll[k].Controls[i];
						txt.ReadOnly = true;
						//txt.Enabled = false;
					}
					else if (coll[k].Controls[i] is DropDownList) 
					{
						DropDownList ddl = (DropDownList) coll[k].Controls[i];
						ddl.Enabled = false;
					}
					else if (coll[k].Controls[i] is Button)
					{
						Button btn = (Button) coll[k].Controls[i];
						//btn.Enabled = false;
						btn.Visible = false;
					}
					else if (coll[k].Controls[i] is RadioButtonList) 
					{
						RadioButtonList rbl = (RadioButtonList) coll[k].Controls[i];
						rbl.Enabled = false;
					}
					else if (coll[k].Controls[i] is RadioButton) 
					{
						RadioButton rb = (RadioButton) coll[k].Controls[i];
						rb.Enabled = false;
					}
					else if (coll[k].Controls[i] is CheckBox)
					{
						CheckBox cb = (CheckBox) coll[k].Controls[i];
						cb.Enabled = false;
					}					
					else if (coll[k].Controls[i] is DataGrid) 
					{						
						DataGrid dg = (DataGrid) coll[k].Controls[i];						
						dg.Columns[10].Visible = false;
						for (int j = 0; j < dg.Items.Count; j++) 
						{
							//dg.Items[j].Cells[10].Enabled = false;
							dg.Items[j].Cells[10].Visible = false;
						}
					}
					else if (coll[k].Controls[i] is HtmlTableRow) 
					{
						HtmlTableRow htr = (HtmlTableRow) coll[k].Controls[i];
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

		private bool isInputValid() 
		{
			bool isValid = true;

			//--- validasi Tanggal Lahir (DOB)
			Int64 dobDate = 0, now = 0;
			if ((TXT_CS_DOB_DAY.Text != "") && (DDL_CS_DOB_MONTH.SelectedValue != "") && (TXT_CS_DOB_YEAR.Text != ""))
			{
				if (!GlobalTools.isDateValid(TXT_CS_DOB_DAY.Text, DDL_CS_DOB_MONTH.SelectedValue, TXT_CS_DOB_YEAR.Text)) 
				{
					GlobalTools.popMessage(this, "Tanggal Lahir tidak valid !");
					isValid = false;
				}

				try 
				{
					dobDate = Int64.Parse(Tools.toISODate(TXT_CS_DOB_DAY, DDL_CS_DOB_MONTH, TXT_CS_DOB_YEAR));
				} 
				catch (ApplicationException) 
				{
					GlobalTools.popMessage(this, "Tanggal Lahir tidak valid !");
					isValid = false;
				}

				now = Int64.Parse(Tools.toISODate(DateTime.Now.Day.ToString(), DateTime.Now.Month.ToString(), DateTime.Now.Year.ToString()));
				
				if (dobDate > now)
				{
					GlobalTools.popMessage(this, "DOB cannot be greater than current date!");
					isValid = false;
				}
			}
			
			//if (double.Parse(tool.ConvertFloat(TXT_CS_STOCKPERC.Text)) > double.Parse(LBL_TOTPERC.Text))
			//if (float.Parse(TXT_CS_STOCKPERC.Text) > double.Parse(LBL_TOTPERC.Text))
			//if (double.Parse(tool.ConvertFloat(TXT_CS_STOCKPERC.Text)) > double.Parse(tool.ConvertFloat(LBL_TOTPERC.Text)))

			//--- validasi Percentage
			try 
			{
				/********
				 * Logic rebuild ... !
				 * ******
				if (float.Parse(TXT_CS_STOCKPERC.Text) > float.Parse(LBL_TOTPERC.Text))
				{
					TXT_CS_STOCKPERC.Text = "";
					GlobalTools.popMessage(this, "Stock Percentage Over 100% !");
					isValid = false;
				}
				***/
/*
				conn.QueryString = "exec IDE_INFOPERUSAHAAN_CEKSAHAM '" + 
					Request.QueryString["noreg"] + "', '" + SEQ.Text + "', '" + 
					tool.ConvertFloat(TXT_CS_STOCKPERC.Text.Trim()) + "'";
				conn.ExecuteQuery();
				double vTOTAL_CS_STOCKPERC = 0.0;
				try { vTOTAL_CS_STOCKPERC = Convert.ToDouble(conn.GetFieldValue("TOTAL_CS_STOCKPERC")); } 
				catch {}
				if (vTOTAL_CS_STOCKPERC > 100.0) 
				{
					GlobalTools.popMessage(this, "Stock Percentage Over 100% !");
					isValid = false;
				}

				if (RDO_RFCUSTOMERTYPE.SelectedValue == "01") //--- badan usaha
				{
					//... stock 0.00 tidak boleh
					if (float.Parse(TXT_CS_STOCKPERC.Text) <= 0.00) 
					{
						TXT_CS_STOCKPERC.Text = "";
						GlobalTools.popMessage(this, "Stock tidak boleh 0.00!");
						isValid = false;
					}
				}
			} 
			catch 
			{
				GlobalTools.popMessage(this, "Nilai Stock tidak valid !");
				isValid = false;
			}

			//--- VALIDASI KEY PERSON ---//

			//    KEY Person harus ORANG (kode : 02)
			if (RDO_KEY_PERSON.SelectedValue == "1" && RDO_RFCUSTOMERTYPE.SelectedValue != "02") //
			{
				GlobalTools.popMessage(this, "Key Person harus Perorangan!");
				isValid = false;
			}


			//				conn.QueryString = "select CS_KEYPERSON from CUST_STOCKHOLDER where no_registrasi = '" + LBL_CUREF.Text + 
			//					"' and CS_KEYPERSON = '1'";
			//				conn.ExecuteQuery();
			//
			//				DataTable dt1=new DataTable();
			//				dt1 = conn.GetDataTable().Copy();
			//				
			//
			//				if (dt1.Rows.Count == 1 && RDO_KEY_PERSON.SelectedValue == "1") 
			//				{
			//					conn.QueryString = "select CS_KEYPERSON from CUST_STOCKHOLDER where no_registrasi = '" + LBL_CUREF.Text + "' and CS_KEYPERSON = '1'";
			//					conn.ExecuteQuery();
			//					if (dt1.Rows.Count == 1 && RDO_KEY_PERSON.SelectedValue == "1") 
			//					{
			//						GlobalTools.popMessage(this, "Jumlah Key Person hanya boleh 1 orang!");
			//						isValid = false;
			//					}
			//				}

			//---------------------------------------------------------------------//

			return isValid;
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
			this.BTN_STOCKHOLDER.Click += new System.EventHandler(this.BTN_STOCKHOLDER_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void BTN_UPDATE_Click(object sender, System.EventArgs e)
		{

			conn.QueryString = "select cu_custtypeid from customer where no_registrasi='" + Request.QueryString["noreg"] + "'";
			conn.ExecuteQuery();
			string cu_custtypeid = conn.GetFieldValue("cu_custtypeid");

			//if (DatGridPengurus.Items.Count > 0)
			if (cu_custtypeid == "01") // Badan Usaha
			{
				// Belum ada pengurus diisi ....
				if (DatGridPengurus.Items.Count == 0) 
				{
					GlobalTools.popMessage(this, "Data Direksi harus diisi!");
					RDO_KEY_PERSON.SelectedValue = "1";	// set default ke YES
					return;
				}

				float totSahamPercentage = 0;
				bool isAdaKeyPerson = false;

				// Memeriksa jumlah persentase saham ...
				for (int i = 0; i < DatGridPengurus.Items.Count; i++)
				{
					//totSahamPercentage += float.Parse(DatGridPengurus.Items[i].Cells[7].Text);
					totSahamPercentage += float.Parse(float.Parse(DatGridPengurus.Items[i].Cells[7].Text).ToString("##,#0.00"));

					string KEYPERSON = DatGridPengurus.Items[i].Cells[11].Text;
					if (KEYPERSON == "YA") 					
						isAdaKeyPerson = true;					
				}
				
				if (totSahamPercentage  < 99.999 || totSahamPercentage > 100.001)
					GlobalTools.popMessage(this, "Total saham harus 100%!");
				else if (!isAdaKeyPerson) // Badan usaha
				{
					GlobalTools.popMessage(this, "Perusahaan harus punya Key Person, min 1 Orang !");
				}
			}

		}

		private void FillCSGrid()
		{
			float totSaham = 0, temp = 0;
			
			DataTable dt = new DataTable();
			conn.QueryString = "select *, case isnull(CS_NATSTAT,'0') when '0' then 'WNI' when '1' then 'WNA' end as STATUS_DESC, case isnull(CS_KEYPERSON,'0') when '0' then 'TIDAK' when '1' then 'YA' end as CS_KEYPERSON from CUST_STOCKHOLDER where no_registrasi ='"+ Request.QueryString["noreg"] + "'";
			conn.ExecuteQuery();
			dt = conn.GetDataTable().Copy();
			DatGridPengurus.DataSource = dt;
			DatGridPengurus.DataBind();

			for (int i = 0; i < DatGridPengurus.Items.Count; i++)
			{
				DatGridPengurus.Items[i].Cells[3].Text = tool.FormatDate(DatGridPengurus.Items[i].Cells[3].Text, true);
				DatGridPengurus.Items[i].Cells[7].Text = DatGridPengurus.Items[i].Cells[7].Text.Replace(".", ",");
				temp = float.Parse(DatGridPengurus.Items[i].Cells[7].Text);

				if (!DatGridPengurus.Items[i].Cells[1].Text.Trim().Equals(SEQ.Text.Trim()) && SEQ.Text!="")
				{
					totSaham = totSaham + temp;
				}

			}
			totSaham = 100 - totSaham;
			//LBL_TOTPERC.Text = totSaham.ToString();			
			//TXT_CS_STOCKPERC.Text = totSaham.ToString();

			//------- Modified by Yudi (06-08-2004) --------------
			LBL_TOTPERC.Text = totSaham.ToString("##,#0.00");
			TXT_CS_STOCKPERC.Text = totSaham.ToString("##,#0.00");
		}

		private void BTN_STOCKHOLDER_Click(object sender, System.EventArgs e)
		{
			SEQ.Text="";
			string status = "0", dbg = Request.QueryString["noreg"] ;
			int count = 0;
			Int64 dobDate = 0, now = 0;

			if (!isInputValid()) return;
			
			
			count = DatGridPengurus.Items.Count + 1;
			if (RDO_CS_NATSTAT1.Checked)
				status = "1";

			conn.QueryString = "exec DE_CUST_STOCKHOLDER '" + 
				Request.QueryString["noreg"] + "', '" + 
				//count.ToString() + ", '" + 
				TXT_CS_FIRSTNAME.Text + "', '" + 
				TXT_CS_MIDDLENAME.Text + "', '" + 
				TXT_CS_LASTNAME.Text + "', " + 
				tool.ConvertDate(TXT_CS_DOB_DAY.Text, DDL_CS_DOB_MONTH.SelectedValue, TXT_CS_DOB_YEAR.Text) + ", '" + 
				TXT_CS_IDCARDNUM.Text + "', '" + 
				TXT_CS_NPWP.Text + "', " + 
				tool.ConvertNull(DDL_CS_JOBTITLE.SelectedValue) + ", " + 
				tool.ConvertFloat(TXT_CS_STOCKPERC.Text) + ", '" + status + "', '" + 
				TXT_CS_ADDR1.Text + "', '" + TXT_CS_ADDR2.Text + "', '" + TXT_CS_ADDR3.Text + "', '" + 
				TXT_CS_CITY.Text + "', '" + TXT_CS_ZIPCODE.Text + "', '" + RDO_KEY_PERSON.SelectedValue + "', " + 
				tool.ConvertNull(DDL_CS_SEX.SelectedValue) + ", " + RDO_AKTIF.SelectedValue + "', " +
				TXT_CS_REMARK.Text + "','" + 
				RDO_RFCUSTOMERTYPE.SelectedValue + "'";
				
			conn.ExecuteNonQuery();
			/*
			conn.QueryString = "insert into cust_stockholder " + 
				"(no_registrasi, seq, cs_firstname, cs_middlename, cs_lastname, cs_dob, cs_idcardnum, cs_npwp, cs_experience, cs_education, cs_jobtitle, cs_stockperc, cs_natstat, active, cs_addr1, cs_addr2, cs_addr3, cs_zipcode) " + 
				"values ('" + Request.QueryString["noreg"] + "', " + 
				count.ToString() + ", '" + 
				TXT_CS_FIRSTNAME.Text + "', '" + 
				TXT_CS_MIDDLENAME.Text + "', '" + 
				TXT_CS_LASTNAME.Text + "', " + 
				tool.ConvertDate(TXT_CS_DOB_DAY.Text, DDL_CS_DOB_MONTH.SelectedValue, TXT_CS_DOB_YEAR.Text) + ", '" + 
				TXT_CS_IDCARDNUM.Text + "', '" + 
				TXT_CS_NPWP.Text + "', " + 
				tool.ConvertNull(DDL_CS_EXPERIENCE.SelectedValue) + ", " + 
				tool.ConvertNull(DDL_CS_EDUCATION.SelectedValue) + ", " + 
				tool.ConvertNull(DDL_CS_JOBTITLE.SelectedValue) + ", " + 
				TXT_CS_STOCKPERC.Text + ", '" + status + "', '1', '" + 
				TXT_CS_ADDR1.Text + "', '" + TXT_CS_ADDR2.Text + "', '" + TXT_CS_ADDR3.Text + "', '" + 
				TXT_CS_ZIPCODE.Text + "')";
			conn.ExecuteNonQuery();
			*/
/*
			ShowBlank();			
			FillCSGrid();
			//
			// kalau ada penambahan orang, reset nama stockholder account
			//
		}

		private void ShowBlank()
		{
			TXT_CS_FIRSTNAME.Text = "";
			TXT_CS_MIDDLENAME.Text = "";
			TXT_CS_LASTNAME.Text = "";
			TXT_CS_IDCARDNUM.Text = "";
			TXT_CS_ADDR1.Text = "";
			TXT_CS_ADDR2.Text = "";
			TXT_CS_ADDR3.Text = "";
			TXT_CS_CITY.Text = "";
			TXT_CS_ZIPCODE.Text = "";
			TXT_CS_DOB_DAY.Text = "";
			DDL_CS_DOB_MONTH.SelectedValue = "";
			TXT_CS_DOB_YEAR.Text = "";
			TXT_CS_NPWP.Text = "";
			DDL_CS_JOBTITLE.SelectedValue = "";
			TXT_CS_STOCKPERC.Text = "0";
			RDO_KEY_PERSON.SelectedValue = "0";
			RDO_AKTIF.SelectedValue = "0";
			DDL_CS_SEX.SelectedValue = "";
			TXT_CS_REMARK.Text = "";
			//TXT_CS_MOTHER.Text = "";
		}

		private void setCustomerTypeMandatory(string customerType) 
		{
			//--- Kalau jenis pemegang saham BADAN USAHA, disable field berikut :
			//    - Key Person
			//    - WNA/WNI
			//    - Job Title
			//    - Jenis Kelamin
			//----------------------------------------------------------------

			RDO_RFCUSTOMERTYPE.SelectedValue = customerType;
			
			if (customerType == "01")	//--- company / badan usaha			
			{
				//RDO_KEY_PERSON.Enabled = true;	// company tidak bisa key person !?
				RDO_KEY_PERSON.Enabled = false;	

				RDO_CS_NATSTAT0.Enabled	= false;
				RDO_CS_NATSTAT1.Enabled	= false;
				try {DDL_CS_JOBTITLE.Enabled	= false;}
				catch {}

				try {DDL_CS_SEX.Enabled = false;}
				catch {}

				try{ RDO_KEY_PERSON.SelectedValue = "0";} //by default TIDAK
				catch {}

				try {DDL_CS_JOBTITLE.SelectedIndex = 0;}
				catch {}

				try {DDL_CS_SEX.SelectedIndex = 0;}
				catch {}

				// Reset CssClass
				//				DDL_CS_JOBTITLE.BackColor		= Color.Gainsboro;
				//				DDL_CS_EXPERIENCE.BackColor		= Color.Gainsboro;				

				/**
				TXT_CS_CHILDREN.BackColor		= Color.Gainsboro;
				DDL_CS_SEX.BackColor			= Color.Gainsboro;
				TXT_CS_MULAIMENETAPMM.BackColor = Color.Gainsboro;
				TXT_CS_MULAIMENETAPYY.BackColor = Color.Gainsboro;				
				**/

				//TXT_CS_CHILDREN.CssClass		= "";
				//DDL_CS_SEX.CssClass				= "";
				//TXT_CS_MULAIMENETAPMM.CssClass	= "";
				//TXT_CS_MULAIMENETAPYY.CssClass	= "";
				//TXT_CS_DOB_DAY.CssClass			= "";
				//DDL_CS_DOB_MONTH.CssClass		= "";
				//TXT_CS_DOB_YEAR.CssClass		= "";
/*			}
			else //--- perorangan / lain-lain
			{
				if (customerType == "02") 
				{
					RDO_KEY_PERSON.Enabled = true;	// hanya perorangan yang bisa jadi key person
				}
				else 
				{	// lain-lain

					RDO_KEY_PERSON.Enabled = false;
					try { RDO_KEY_PERSON.SelectedValue = "0"; } 
					catch {}

				}

				RDO_CS_NATSTAT0.Enabled			= true;
				RDO_CS_NATSTAT1.Enabled			= true;

				try {DDL_CS_JOBTITLE.Enabled			= true;}
				catch {}

				try {DDL_CS_SEX.Enabled				= true;}
				catch {}


				//				DDL_CS_JOBTITLE.BackColor		= Color.White;				
				//				DDL_CS_EXPERIENCE.BackColor		= Color.White;

				try {DDL_CS_JOBTITLE.SelectedValue	= "";}
				catch {}

				try {DDL_CS_SEX.SelectedValue		= "";}
				catch {}


				//TXT_CS_CHILDREN.CssClass		= "mandatoryColl";
				//DDL_CS_SEX.CssClass				= "mandatoryColl";
				//TXT_CS_MULAIMENETAPMM.CssClass	= "mandatoryColl";
				//TXT_CS_MULAIMENETAPYY.CssClass	= "mandatoryColl";
				//TXT_CS_DOB_DAY.CssClass			= "mandatoryColl";
				//DDL_CS_DOB_MONTH.CssClass		= "mandatoryColl";
				//TXT_CS_DOB_YEAR.CssClass		= "mandatoryColl";
			}
		}

		private void DatGridPengurus_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			switch (((LinkButton)e.CommandSource).CommandName)
			{
				case "delete":
					///////////////////////////////
					///	Hapus data stock holder
					conn.QueryString = "delete from cust_stockholder where no_registrasi='" + Request.QueryString["noreg"] + "' and seq=" + e.Item.Cells[1].Text;
					conn.ExecuteNonQuery();


					FillCSGrid();
					break;

				case "edit":
					SEQ.Text  =  e.Item.Cells[1].Text;
					// This code for link 
					conn.QueryString = "Select * from CUST_STOCKHOLDER where no_registrasi='" + 
						Request.QueryString["noreg"] + "' and seq=" + Convert.ToInt32(SEQ.Text);
					conn.ExecuteQuery();

					setCustomerTypeMandatory(conn.GetFieldValue("CS_TYPE"));
					
					TXT_CS_FIRSTNAME.Text = conn.GetFieldValue("CS_FIRSTNAME");
					TXT_CS_MIDDLENAME.Text = conn.GetFieldValue("CS_MIDDLENAME");
					TXT_CS_LASTNAME.Text = conn.GetFieldValue("CS_LASTNAME");
					TXT_CS_IDCARDNUM.Text = conn.GetFieldValue("CS_IDCARDNUM");
					TXT_CS_ADDR1.Text = conn.GetFieldValue("CS_ADDR1");
					TXT_CS_ADDR2.Text = conn.GetFieldValue("CS_ADDR2");
					TXT_CS_ADDR3.Text = conn.GetFieldValue("CS_ADDR3");
					TXT_CS_CITY.Text =  conn.GetFieldValue("CS_CITY");
					
					RDO_KEY_PERSON.SelectedValue = conn.GetFieldValue("CS_KEYPERSON");
					RDO_AKTIF.SelectedValue = conn.GetFieldValue("CS_AKTIF");

					string dtm = conn.GetFieldValue("CS_DOB");
					TXT_CS_DOB_DAY.Text = tool.FormatDate_Day(dtm);
					DDL_CS_DOB_MONTH.SelectedValue = tool.FormatDate_Month(dtm);
					TXT_CS_DOB_YEAR.Text = tool.FormatDate_Year(dtm);

					TXT_CS_NPWP.Text = conn.GetFieldValue("CS_NPWP");
					DDL_CS_JOBTITLE.SelectedValue = conn.GetFieldValue("CS_JOBTITLE");
					TXT_CS_ZIPCODE.Text = conn.GetFieldValue("CS_ZIPCODE");
					TXT_CS_STOCKPERC.Text = conn.GetFieldValue("CS_STOCKPERC");
					//Response.Write("Isi persen saham : " + TXT_CS_STOCKPERC.Text);
					
					string CHECK = conn.GetFieldValue("CS_NATSTAT");
					if (CHECK == "0")
					{ 
						RDO_CS_NATSTAT0.Checked = true;
						RDO_CS_NATSTAT1.Checked = false;
					}
					else
					{
						RDO_CS_NATSTAT1.Checked = true;
						RDO_CS_NATSTAT0.Checked = false;
					}
					
					try {DDL_CS_SEX.SelectedValue = conn.GetFieldValue("CS_SEX");}
					catch {}
					TXT_CS_REMARK.Text = conn.GetFieldValue("CS_REMARK");

					//TXT_CS_MOTHER.Text = conn.GetFieldValue("MOTHER");

					if (Request.QueryString["sta"] != "view")
					{
						BTN_STOCKHOLDER.Visible = false;
						BTN_UPDATE_NEW.Visible = true;
						BTN_CANCEL.Visible = true;
					}

					ZIP_CODE();
					break;
			}
		}
		
		private void ZIP_CODE()
		{
			conn.QueryString = "select cityid, cityname, description from vw_zipcodecity where rtrim(ltrim(zipcode)) = '" + 
				TXT_CS_ZIPCODE.Text.Trim() + "' ";
			conn.ExecuteQuery();
			try
			{
				if (conn.GetRowCount() > 0 && conn.GetFieldValue(0,2) != "")
					TXT_CS_CITY.Text = conn.GetFieldValue(0,2);
			}
			catch
			{
				TXT_CS_ZIPCODE.Text = "";
				GlobalTools.popMessage(this, "Invalid Zipcode!");
			}
		}
		
		private void BTN_SEARCHCOMP_Click(object sender, System.EventArgs e)
		{
			Response.Write("<script language='javascript'>window.open('SearchZipcode.aspx?targetFormID=Form1&targetObjectID=TXT_CS_ZIPCODE','SearchZipcode','status=no,scrollbars=no,width=420,height=200');</script>");
		}

		private void BTN_CANCEL_Click(object sender, System.EventArgs e)
		{
			ShowBlank();
			BTN_STOCKHOLDER.Visible = true;
			BTN_UPDATE_NEW.Visible = false;
			BTN_CANCEL.Visible = false;
		}

		private bool UpdateData()
		{
			string status = "0";
			int intSeq = 0;
			
			if (DatGridPengurus.Items.Count > 0)
			{

				if (!isInputValid()) return false;

				//				////////////////////////////////////////////
				//				/// Validasi Mulai Menetap
				//				/// 
				//				int CS_MULAIMENETAPMM = 0, CS_MULAIMENETAPYY = 0;
				//				if (TXT_CS_MULAIMENETAPMM.Text.Trim() != "" || TXT_CS_MULAIMENETAPYY.Text.Trim() != "") 
				//				{
				//					try { CS_MULAIMENETAPMM = Convert.ToInt16(TXT_CS_MULAIMENETAPMM.Text.Trim()); } 
				//					catch {}
				//					try { CS_MULAIMENETAPYY = Convert.ToInt16(TXT_CS_MULAIMENETAPYY.Text.Trim()); }
				//					catch {}
				//
				//					if ((CS_MULAIMENETAPMM < 1 && CS_MULAIMENETAPMM > 12) || 
				//						(!GlobalTools.isDateValid(1, CS_MULAIMENETAPMM, CS_MULAIMENETAPYY))) 
				//					{
				//						GlobalTools.popMessage(this, "Mulai Menetap tidak valid!");
				//						return false;
				//					}
				//				}
				//				///////////////////////////////////////////////////
				//				
				//
				//				///////////////////////////////////////////////////
				//				///--- validasi Tanggal Lahir (DOB)
				//				///
				//				if ((TXT_CS_DOB_DAY.Text != "") && (DDL_CS_DOB_MONTH.SelectedValue != "") && (TXT_CS_DOB_YEAR.Text != ""))
				//				{
				//					if (!GlobalTools.isDateValid(TXT_CS_DOB_DAY.Text, DDL_CS_DOB_MONTH.SelectedValue, TXT_CS_DOB_YEAR.Text)) 
				//					{
				//						GlobalTools.popMessage(this, "Tanggal Lahir tidak valid !");
				//						return;
				//					}
				//
				//					try 
				//					{
				//						dobDate = Int64.Parse(Tools.toISODate(TXT_CS_DOB_DAY, DDL_CS_DOB_MONTH, TXT_CS_DOB_YEAR));
				//					} 
				//					catch (ApplicationException) 
				//					{
				//						GlobalTools.popMessage(this, "Tanggal Lahir tidak valid !");
				//						return;
				//					}
				//
				//					now = Int64.Parse(Tools.toISODate(DateTime.Now.Day.ToString(), DateTime.Now.Month.ToString(), DateTime.Now.Year.ToString()));
				//				
				//					if (dobDate > now)
				//					{
				//						GlobalTools.popMessage(this, "DOB cannot be greater than current date!");
				//						return;
				//					}
				//				}
				//				///////////////////////////////////////////////////
				//
				//
				//				float totSahamPercentage = 0;
				//				for (int i = 0; i < DatGridPengurus.Items.Count; i++)
				//				{
				//					intSeq = Convert.ToInt32(DatGridPengurus.Items[i].Cells[1].Text);
				//
				//					if(Convert.ToInt32(SEQ.Text)==intSeq) continue;
				//					
				//					totSahamPercentage += float.Parse(float.Parse(DatGridPengurus.Items[i].Cells[7].Text).ToString("##,#0.00"));
				//				}
				//				if (totSahamPercentage + Convert.ToDouble(TXT_CS_STOCKPERC.Text) > 100)
				//				{
				//					TXT_CS_STOCKPERC.Text = "0";
				//					GlobalTools.popMessage(this, "Stock Percentage Over 100% !");
				//					return false;
				//				}

			}
			if (RDO_CS_NATSTAT1.Checked)
				status = "1";


			conn.QueryString = "exec DE_PENGURUS_PERUSAHAAN '" + Request.QueryString["noreg"] + "', " + Convert.ToInt32(SEQ.Text) + ", '" +
				TXT_CS_FIRSTNAME.Text + "', '" + 
				TXT_CS_MIDDLENAME.Text + "', '" + 
				TXT_CS_LASTNAME.Text + "', " + 
				tool.ConvertDate(TXT_CS_DOB_DAY.Text, DDL_CS_DOB_MONTH.SelectedValue, TXT_CS_DOB_YEAR.Text) + ", '" + 
				TXT_CS_IDCARDNUM.Text + "', '" + 
				TXT_CS_NPWP.Text + "', " + 
				tool.ConvertNull(DDL_CS_JOBTITLE.SelectedValue) + ", " + 
				tool.ConvertFloat(TXT_CS_STOCKPERC.Text) + ", '" + status + "', '" + 
				TXT_CS_ADDR1.Text + "', '" + TXT_CS_ADDR2.Text + "', '" + TXT_CS_ADDR3.Text + "', '" + 
				TXT_CS_CITY.Text + "','"+
				TXT_CS_ZIPCODE.Text + "', '" + RDO_KEY_PERSON.SelectedValue + "', " +
				tool.ConvertNull(DDL_CS_SEX.SelectedValue) + ", " +
				TXT_CS_REMARK.Text +"',''";

			conn.ExecuteNonQuery();

			return true;
		}

		private void RDO_RFCUSTOMERTYPE_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			this.setCustomerTypeMandatory(RDO_RFCUSTOMERTYPE.SelectedValue);
		}
*/
	}
}