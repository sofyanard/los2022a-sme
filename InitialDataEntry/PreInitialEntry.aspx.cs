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

namespace SME.InitialDataEntry
{
	/// <summary>
	/// Summary description for GeneralInfo.
	/// Created by: Andri I. Gani
	/// </summary>
	public partial class PreInitialEntry : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.TextBox Textbox7;
		protected System.Web.UI.WebControls.TextBox Textbox8;
		protected System.Web.UI.WebControls.TextBox Textbox9;
	
		#region " My Variables "

		protected Connection conn;
		protected Tools tool = new Tools();
		//Pipeline **JT
		protected Deduplication dedup = new Deduplication();
		
		#endregion

		protected void Page_Load(object sender, System.EventArgs e)
		{
			conn = (Connection) Session["Connection"];

			if (!IsPostBack)
			{				
				LBL_CUREF.Text	= Request.QueryString["curef"];
				LBL_MC.Text		= Request.QueryString["mc"];
				LBL_EXIST.Text	= Request.QueryString["exist"];
				if (Request.QueryString["sta"].Trim() == "new" ) 
					DDL_RMUSER.Enabled = true;
				//
				// Init Tanggal Aplikasi
				//
				DDL_CU_IDCARDEXP_MONTH.Items.Add(new ListItem("- PILIH -", ""));
				DDL_MONTH_APP.Items.Add(new ListItem("- PILIH -", ""));
				for (int i = 1; i <= 12; i++)
				{
					DDL_CU_IDCARDEXP_MONTH.Items.Add(new ListItem(DateAndTime.MonthName(i, false), i.ToString()));
					DDL_MONTH_APP.Items.Add(new ListItem(DateAndTime.MonthName(i, false), i.ToString()));
				}

				// PipeLIne - Init Tanggal Terima **JT
				//
				DDL_MONTH_TRM.Items.Add(new ListItem("- PILIH -", ""));
				for (int i = 1; i <= 12; i++)
				{
					DDL_MONTH_TRM.Items.Add(new ListItem(DateAndTime.MonthName(i, false), i.ToString()));
				}

				DDL_CL_CURRENCY.Items.Add(new ListItem("- PILIH -", ""));

				//--- Mata Uang
				conn.QueryString = "select currencyid from rfcurrency where active='1' order by currencyid";
				conn.ExecuteQuery();
				for (int i = 0; i < conn.GetRowCount(); i++)
					DDL_CL_CURRENCY.Items.Add(new ListItem(conn.GetFieldValue(i,0), conn.GetFieldValue(i,0)));
				try
				{
					DDL_CL_CURRENCY.SelectedValue = "IDR";
				}
				catch{}

				//

				// Init Customer Type
				//
				try 
				{
					conn.QueryString = "select custtypeid, custtypedesc from rfcustomertype where active='1'";
					conn.ExecuteQuery();
				} 
				catch (NullReferenceException) 
				{
					GlobalTools.popMessage(this, "Connection Error!");
					Response.Redirect("../Login.aspx?expire=1");
				}
				for (int i = 0; i < conn.GetRowCount(); i++)
					RDO_RFCUSTOMERTYPE.Items.Add(new ListItem(conn.GetFieldValue(i,1), conn.GetFieldValue(i,0)));

				RDO_RFCUSTOMERTYPE.SelectedIndex = 0;
				//
				// Init RM User
				//
				fillRM();
				//this.LBL_MESSAGE.Text = "Add Collection";
				cekNewExistCust();
				viewData();
				SetMandatory(RDO_RFCUSTOMERTYPE.SelectedValue);

			}

			BTN_ADD.Attributes.Add("onclick", "if(!cek_mandatory(document.Form1)){return false;};");
		}

		private void cekNewExistCust() 
		{
			if (LBL_EXIST.Text == "0") // kalau customernya adalah new ... 
			{
				RDO_RFCUSTOMERTYPE.Enabled		= true;
				TXT_PRE_APPAMOUNT.ReadOnly		= false;
				TXT_CU_FIRSTNAME.ReadOnly		= false;
				TXT_CU_MIDDLENAME.ReadOnly		= false;
				TXT_CU_LASTNAME.ReadOnly		= false;

				TXT_CU_NPWP.ReadOnly			= false;
				TXT_CU_IDCARDNUM.ReadOnly		= false;
				TXT_CU_IDCARDEXP_DAY.ReadOnly	= false;
				DDL_CU_IDCARDEXP_MONTH.Enabled	= true;
				TXT_CU_IDCARDEXP_YEAR.ReadOnly	= false;

				//DDL_RMUSER.Enabled				= true;
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
			this.DatGridPreEntry.ItemCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.DatGridPreEntry_ItemCommand);

		}
		#endregion

		#region " Defined Methods "

		private void fillRM() 
		{
			try 
			{
//				string query = "select USERID, SU_FULLNAME from SCUSER where SU_UPLINER = '" + Session["UserID"] + "' or SU_MIDUPLINER = '" + Session["UserID"] + "' or SU_CORUPLINER = '" + Session["UserID"] + "'" +
//					" and GROUPID in (select distinct GROUPID from GRPACCESSMENU where MENUCODE in (select MENUCODE from TRACK_MENU where TRACKCODE = '1.1'))";

				string query = "select USERID, SU_FULLNAME from SCUSER where SU_BRANCH = '" + Session["BranchID"].ToString() + "' " +
					" and GROUPID in (select distinct GROUPID from GRPACCESSMENU where MENUCODE in (select MENUCODE from TRACK_MENU where TRACKCODE = '1.1')) " +
					" order by SU_FULLNAME ";
				GlobalTools.fillRefList(DDL_RMUSER, query, false, conn);
			} 
			catch (NullReferenceException) 
			{
				GlobalTools.popMessage(this, "Connection Error !");
				Response.Redirect("../Login.aspx?expire=1");
			}
		}
		
		//PipeLine by **JT

		private void fillRMCorp() 
		{
			try 
			{
			//	string query = "select USERID, SU_FULLNAME from SCUSER where SU_BRANCH = '" + Session["BranchID"].ToString() + "' " +
			//		" and GROUPID in (select distinct GROUPID from GRPACCESSMENU where MENUCODE in (select MENUCODE from TRACK_MENU where TRACKCODE = '1.1')) " +
			//		" order by SU_FULLNAME ";

				string query = "select USERID, SU_FULLNAME from SCUSER where SU_BRANCH = '" + Session["BranchID"].ToString() + "' " +
					" and GROUPID in (select distinct GROUPID from GRPACCESSMENU where MENUCODE in (select MENUCODE from TRACK_MENU where TRACKCODE in ('1.0','1.1'))) " +
					" order by SU_FULLNAME ";
				GlobalTools.fillRefList(DDL_RMUSER, query, false, conn);
			} 
			catch (NullReferenceException) 
			{
				GlobalTools.popMessage(this, "Connection Error !");
				Response.Redirect("../Login.aspx?expire=1");
			}
		}
		


		private void viewData() 
		{
			try 
			{
				conn.QueryString = "select top 1 * from VW_IDE_GENINFO where cu_ref='" + LBL_CUREF.Text + "'";
				conn.ExecuteQuery();
			} 
			catch (NullReferenceException) 
			{
				GlobalTools.popMessage(this, "Connection Error !");
				Response.Redirect("../Login.aspx?expire=1");
			}

			// mengambil jenis customer
			try {RDO_RFCUSTOMERTYPE.SelectedValue = conn.GetFieldValue("CU_CUSTTYPEID");}
			catch {}

			// currency
			try {DDL_CL_CURRENCY.SelectedValue = conn.GetFieldValue("PRE_APPAMOUNTCURR");} 
			catch {DDL_CL_CURRENCY.SelectedValue = "";}

			// set mandatory field entry (sesuai jenis customer)
			SetMandatory(conn.GetFieldValue("CU_CUSTTYPEID"));


			// populate field entry
			if (conn.GetFieldValue("CU_CUSTTYPEID")=="01") // Company
			{			
				conn.QueryString = "select * from VW_CUST_COMPANY where CU_REF='" + LBL_CUREF.Text + "'";
				conn.ExecuteQuery();

				TXT_CU_FIRSTNAME.Text	= conn.GetFieldValue("CU_COMPNAME");
				TXT_CU_NPWP.Text		= conn.GetFieldValue("CU_NPWP");

				// hide field entry personal
				TXT_CU_MIDDLENAME.ReadOnly	= true;
				TXT_CU_LASTNAME.ReadOnly	= true;
			}
			else // Personal
			{
				conn.QueryString = "select * from VW_CUST_PERSONAL where CU_REF='" + LBL_CUREF.Text + "'";
				conn.ExecuteQuery();

				TXT_CU_FIRSTNAME.Text	= conn.GetFieldValue("CU_FIRSTNAME");
				TXT_CU_MIDDLENAME.Text	= conn.GetFieldValue("CU_MIDDLENAME");
				TXT_CU_LASTNAME.Text	= conn.GetFieldValue("CU_LASTNAME");
				TXT_CU_IDCARDNUM.Text	= conn.GetFieldValue("CU_IDCARDNUM");
				try {GlobalTools.fromSQLDate(conn.GetFieldValue("CU_IDCARDEXP"), TXT_CU_IDCARDEXP_DAY, DDL_CU_IDCARDEXP_MONTH, TXT_CU_IDCARDEXP_YEAR);}
				catch {}

				// hide field entry company
			}



			//
			// Populate data grid
			//
			try 
			{
				conn.QueryString = "select * from VW_PRE_ENTRY where PRE_ISPROCESSED = '0' and PRE_ENTRYUSER = '" + (string) Session["UserID"] + "'";
				conn.ExecuteQuery();

				DatGridPreEntry.DataSource = conn.GetDataTable().DefaultView;
				DatGridPreEntry.DataBind();
			} 
			catch (NullReferenceException) 
			{
				GlobalTools.popMessage(this, "Connection Error !");
				Response.Redirect("../Login.aspx?expire=1");
			}


			//
			// Define RM jika customer yang dipilih adalah existing
			//
			if (LBL_CUREF.Text != "" && LBL_CUREF.Text != null) 
			{
				//DDL_RMUSER.Enabled = false;

				try 
				{
					conn.QueryString = "select CU_RM from CUSTOMER where CU_REF = '" + LBL_CUREF.Text + "'";
					conn.ExecuteQuery();
				} 
				catch (NullReferenceException) 
				{
					GlobalTools.popMessage(this, "Connection Error !");
					Response.Redirect("../Login.aspx?expire=1");
				}

				try {DDL_RMUSER.SelectedValue = conn.GetFieldValue("CU_RM");}
				catch {}
			}

			//pipeline FOR CORPORATE **JT

			conn.QueryString = "SELECT sg_BUSSUNITid FROM scgroup WHERE groupid = '" + Session["GroupID"].ToString() + "'";
			conn.ExecuteQuery();
			
			if (conn.GetFieldValue("sg_BUSSUNITid") == "CB100")
			{
				this.LBL_TGL_APL.Text = "Tanggal Surat";
				this.LBL_RMUSER.Text = "PIC";
				TR_DDL_UNIT.Visible  = true;
				TR_TGL_TRM.Visible = true;
				DDL_RMUSER.Enabled = true;

				//--- Assign to Unit  **jt
				conn.QueryString = "select branch_code, branch_name from rfbranch where branch_code = cbc_code and cbc_code = '" + Session["BranchID"].ToString() + "'";
				conn.ExecuteQuery();
				for (int i = 0; i < conn.GetRowCount(); i++)
					DDL_UNIT.Items.Add(new ListItem(conn.GetFieldValue(i,1), conn.GetFieldValue(i,0)));
				try
				{
					DDL_UNIT.SelectedValue = "";
				}
				catch{}
				
				fillRMCorp();

			}
			else
			{
				this.LBL_TGL_APL.Text = "Tanggal Aplikasi";
				this.LBL_RMUSER.Text = "RM USER";
				TR_DDL_UNIT.Visible  = false;
				TR_TGL_TRM.Visible = false;
			}
		}

		private bool isCustomerExist()
		{
			bool isExist = false;

			if (RDO_RFCUSTOMERTYPE.SelectedValue == "01")	// Badan usaha
			{
				conn.QueryString = "select CU_REF from CUSTOMER where CU_NPWP = '" + TXT_CU_NPWP.Text + "'";
				conn.ExecuteQuery();

				if (conn.GetRowCount() > 0) 
				{
					GlobalTools.popMessage(this, "Customer with NPWP: " + TXT_CU_NPWP.Text.Trim() + " exists in the system!");
					isExist = true;
				}
			}
			else // Perorangan
			{
				string TGL_KTP = GlobalTools.ToSQLDate(TXT_CU_IDCARDEXP_DAY.Text.Trim(), DDL_CU_IDCARDEXP_MONTH.SelectedValue, TXT_CU_IDCARDEXP_YEAR.Text.Trim());
				conn.QueryString = "select CU_REF from CUST_PERSONAL WHERE CU_IDCARDNUM = '" + TXT_CU_IDCARDNUM.Text.Trim () + 
					"' and CU_IDCARDEXP = " + TGL_KTP + "";
				conn.ExecuteQuery();

				if (conn.GetRowCount() > 0) 
				{
					GlobalTools.popMessage(this, "Customer with KTP: " + TXT_CU_IDCARDNUM.Text + " and Expire Date: " + TGL_KTP.Replace("'","") + " exists in the system!");
					isExist = true;
				}
			}

			return isExist;
		}

		private void setFieldStatus(bool isEnabled) 
		{
//			TXT_PRE_PERIHAL.ReadOnly = !isEnabled;				
//			TXT_PRE_APPAMOUNT.ReadOnly = !isEnabled;

//			TXT_CU_FIRSTNAME.ReadOnly = !isEnabled;
//			TXT_CU_MIDDLENAME.ReadOnly = !isEnabled;
//			TXT_CU_LASTNAME.ReadOnly = !isEnabled;
//			TXT_CU_NPWP.ReadOnly = !isEnabled;
//			TXT_CU_IDCARDNUM.ReadOnly = !isEnabled;
//			TXT_CU_IDCARDEXP_DAY.ReadOnly = !isEnabled;
//			DDL_CU_IDCARDEXP_MONTH.Enabled = isEnabled;
//			TXT_CU_IDCARDEXP_YEAR.ReadOnly = !isEnabled;

//			DDL_RMUSER.Enabled = isEnabled;

			BTN_ADD.Visible		= isEnabled;
			BTN_UPDATE.Visible	= !isEnabled;
		}
		
		private void clearFields() 
		{
			TXT_PRE_PERIHAL.Text = "";
			TXT_PRE_APPAMOUNT.Text = "";
			TXT_CU_FIRSTNAME.Text	= "";
			TXT_CU_MIDDLENAME.Text	= "";
			TXT_CU_LASTNAME.Text	= "";
			TXT_CU_NPWP.Text		= "";
			TXT_CU_IDCARDNUM.Text	= "";
			TXT_CU_IDCARDEXP_DAY.Text				= "";
			DDL_CU_IDCARDEXP_MONTH.SelectedValue	= "";
			TXT_CU_IDCARDEXP_YEAR.Text				= "";
			DDL_RMUSER.SelectedValue = "";
			TXT_DAY_APP.Text = "";
			DDL_MONTH_APP.SelectedValue = "";
			TXT_YEAR_APP.Text = "";	
			DDL_CL_CURRENCY.SelectedValue = "";
			TXT_DAY_TRM.Text = "";
			DDL_MONTH_TRM.SelectedValue = "";
			TXT_YEAR_TRM.Text = "";
		}

		private bool validateInputs() 
		{
			if (!GlobalTools.isDateValid(TXT_DAY_APP.Text, DDL_MONTH_APP.SelectedValue, TXT_YEAR_APP.Text)) 
			{
				GlobalTools.popMessage(this, "Tanggal Aplikasi tidak valid!");
				return false;
			}

			if (GlobalTools.compareDate(TXT_DAY_APP.Text, DDL_MONTH_APP.SelectedValue, TXT_YEAR_APP.Text, DateTime.Now.Day.ToString(), DateTime.Now.Month.ToString(), DateTime.Now.Year.ToString()) > 0) 
			{
				GlobalTools.popMessage(this, "Tanggal Aplikasi tidak boleh lebih dari Tanggal sekarang!");
				return false;
			}

			// Validasi Tanggal Terima
			if (TR_TGL_TRM.Visible == true)
				if (!GlobalTools.isDateValid(TXT_DAY_TRM.Text, DDL_MONTH_TRM.SelectedValue, TXT_YEAR_TRM.Text)) 
				{
					GlobalTools.popMessage(this, "Tanggal Terima tidak valid!");
					return false;
				}
	
			
			if (GlobalTools.compareDate(TXT_DAY_TRM.Text, DDL_MONTH_TRM.SelectedValue, TXT_YEAR_TRM.Text, DateTime.Now.Day.ToString(), DateTime.Now.Month.ToString(), DateTime.Now.Year.ToString()) > 0) 
			{
				GlobalTools.popMessage(this, "Tanggal Terima tidak boleh lebih dari Tanggal sekarang!");
				return false;
			}


			if (RDO_RFCUSTOMERTYPE.SelectedValue != "01")	// Perorangan
			{
				if (TXT_CU_IDCARDEXP_DAY.Text != "" || DDL_CU_IDCARDEXP_MONTH.SelectedValue != "" || TXT_CU_IDCARDEXP_YEAR.Text != "") 
				{
					if (!GlobalTools.isDateValid(TXT_CU_IDCARDEXP_DAY.Text, DDL_CU_IDCARDEXP_MONTH.SelectedValue, TXT_CU_IDCARDEXP_YEAR.Text))
					{
						GlobalTools.popMessage(this, "Tanggal Kadaluarsa tidak valid!");
						return false;
					}

					if (GlobalTools.compareDate(TXT_CU_IDCARDEXP_DAY.Text, DDL_CU_IDCARDEXP_MONTH.SelectedValue, TXT_CU_IDCARDEXP_YEAR.Text, DateTime.Now.Day.ToString(), DateTime.Now.Month.ToString(), DateTime.Now.Year.ToString()) < 0) 
					{
						GlobalTools.popMessage(this, "Tanggal kadaluarsa tidak boleh kurang dari tanggal sekarang!");
						return false;
					}
				}
			}

			return true;
		}
		#endregion

		protected void RDO_RFCUSTOMERTYPE_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			SetMandatory(RDO_RFCUSTOMERTYPE.SelectedValue);
		}

		private void SetMandatory(string custType)
		{
			if (custType == "01")	//Badan Usaha
			{
				tblKTP.Visible = false;
				tblNPWP.Visible = true;
		
				TXT_CU_NPWP.CssClass = "mandatory";
				TXT_CU_IDCARDNUM.CssClass = "";
				TXT_CU_IDCARDEXP_DAY.CssClass = "";
				TXT_CU_IDCARDEXP_YEAR.CssClass = "";
				DDL_CU_IDCARDEXP_MONTH.CssClass = "";

				TXT_CU_MIDDLENAME.Visible = false;
				TXT_CU_LASTNAME.Visible = false;
			}
			else	//Perorangan
			{
				tblKTP.Visible = true;
				tblNPWP.Visible = false;

				TXT_CU_NPWP.CssClass = "";
				TXT_CU_IDCARDNUM.CssClass = "mandatory";
				TXT_CU_IDCARDEXP_DAY.CssClass = "mandatory";
				TXT_CU_IDCARDEXP_YEAR.CssClass = "mandatory";
				DDL_CU_IDCARDEXP_MONTH.CssClass = "mandatory";

				TXT_CU_MIDDLENAME.Visible = true;
				TXT_CU_LASTNAME.Visible = true;
			}
		}

		protected void BTN_ADD_Click(object sender, System.EventArgs e)
		{
			//
			// Validasi Input field
			//
			//if (!validateInputs()) return;

			//this.DatGridPreEntry.Visible = false;
			//this.DatGridExist.Visible = false;

			/**
			if(!p_SearchData())
				p_AddData();
			**/
			//if (LBL_EXIST.Text == "0")
				p_AddData("1", LBL_CUREF.Text);			

			//Grid_Add.Visible = false;
			Grid_Exist.Visible = false;
		}

		private bool p_SearchData()
		{
			bool isExist = false;
			string idnumber = string.Empty;

			if (RDO_RFCUSTOMERTYPE.SelectedValue == "01")	// Badan usaha
				idnumber = TXT_CU_NPWP.Text.Trim();
			else
				idnumber = TXT_CU_IDCARDNUM.Text.Trim();

			try 
			{
				conn.QueryString = " SEARCH_PRE_INITAL_ENTRY '" + idnumber + "','" + RDO_RFCUSTOMERTYPE.SelectedValue + "'" ;
				conn.ExecuteQuery();

				if (conn.GetRowCount() > 0) 
				{
					isExist = true;
					DatGridExist.DataSource = conn.GetDataTable().DefaultView;
					DatGridExist.DataBind();

					Grid_Exist.Visible = true;
					//this.LBL_MESSAGE.Text = "Search Result";

				}
			}
			catch (NullReferenceException) 
			{
				isExist = false;
				GlobalTools.popMessage(this, "Connection Error!");
				Response.Redirect("../Login.aspx?expire=1");
			}
			return isExist;
		}

		private void p_AddData(string mode, string CUREF)
		{
			try 
			{
				string BRANCH_CODE = (string) Session["BranchID"];
				string userID = (string) Session["UserID"];

			
				if (LBL_EXIST.Text == "0")
				{
					if (isCustomerExist()) 
					{
						TR_PERSONAL.Visible = false;
						TR_BUTTON.Visible	= false;
						return;
					}
				}

				string regno = "";
				if (mode != "2")
				{
					conn.QueryString = "exec GENERATE_ID '" + Session["BranchID"].ToString() + "', '0'";
					conn.ExecuteQuery();
					regno =  conn.GetFieldValue(0,0);
				}
				else
					regno = LBL_REGNO.Text ;
				
				//Save data ke database

				//pipeline FOR CORPORATE **JT
				conn.QueryString = "SELECT sg_BUSSUNITid FROM scgroup WHERE groupid = '" + Session["GroupID"].ToString() + "'";
				conn.ExecuteQuery();
			
				if (conn.GetFieldValue("sg_BUSSUNITid") == "CB100")
				{
					conn.QueryString = "exec IDE_PRE_INITIAL_ENTRY_CORP '" + 
						CUREF + "', '" + LBL_PRE_SEQSURAT.Text + "', '" + 
						RDO_RFCUSTOMERTYPE.SelectedValue + "', " + 
						tool.ConvertNull(TXT_PRE_PERIHAL.Text.Trim()) + ", '" + 
						TXT_CU_FIRSTNAME.Text.Trim() + "', " + 
						tool.ConvertNull(TXT_CU_MIDDLENAME.Text.Trim()) + ", " + 
						tool.ConvertNull(TXT_CU_LASTNAME.Text.Trim()) + ", " + 
						tool.ConvertNull(TXT_CU_NPWP.Text.Trim()) + ", " + 
						tool.ConvertNull(TXT_CU_IDCARDNUM.Text.Trim()) + ", " + 
						GlobalTools.ToSQLDate(TXT_CU_IDCARDEXP_DAY.Text, DDL_CU_IDCARDEXP_MONTH.SelectedValue, TXT_CU_IDCARDEXP_YEAR.Text) + " , " +
						tool.ConvertFloat(TXT_PRE_APPAMOUNT.Text) + ", '" + 
						userID + "', '" +
						DDL_RMUSER.SelectedValue + "', '" + mode + "', " +
						GlobalTools.ToSQLDate(TXT_DAY_APP.Text, DDL_MONTH_APP.SelectedValue, TXT_YEAR_APP.Text)+", '"+
						regno + "','" + DDL_CL_CURRENCY.SelectedValue + "', '" +
						DDL_CL_CURRENCY.SelectedValue + "', " +
						GlobalTools.ToSQLDate(TXT_DAY_TRM.Text, DDL_MONTH_TRM.SelectedValue, TXT_YEAR_TRM.Text);

					conn.ExecuteNonQuery();


				}
				else
				{
					Grid_Add.Visible = true;

					conn.QueryString = "exec IDE_PRE_INITIAL_ENTRY '" + 
						CUREF + "', '" + LBL_PRE_SEQSURAT.Text + "', '" + 
						RDO_RFCUSTOMERTYPE.SelectedValue + "', " + 
						tool.ConvertNull(TXT_PRE_PERIHAL.Text.Trim()) + ", '" + 
						TXT_CU_FIRSTNAME.Text.Trim() + "', " + 
						tool.ConvertNull(TXT_CU_MIDDLENAME.Text.Trim()) + ", " + 
						tool.ConvertNull(TXT_CU_LASTNAME.Text.Trim()) + ", " + 
						tool.ConvertNull(TXT_CU_NPWP.Text.Trim()) + ", " + 
						tool.ConvertNull(TXT_CU_IDCARDNUM.Text.Trim()) + ", " + 
						GlobalTools.ToSQLDate(TXT_CU_IDCARDEXP_DAY.Text, DDL_CU_IDCARDEXP_MONTH.SelectedValue, TXT_CU_IDCARDEXP_YEAR.Text) + " , " +
						tool.ConvertFloat(TXT_PRE_APPAMOUNT.Text) + ", '" + 
						userID + "', '" +
						DDL_RMUSER.SelectedValue + "', '" + mode + "', " +
						GlobalTools.ToSQLDate(TXT_DAY_APP.Text, DDL_MONTH_APP.SelectedValue, TXT_YEAR_APP.Text)+", '"+
						regno + "','" + DDL_CL_CURRENCY.SelectedValue + "'" ;
					conn.ExecuteNonQuery();

					Grid_Add.Visible = true;

				}

				//this.LBL_MESSAGE.Text = "Add Collection";

			}
			catch (NullReferenceException) 
			{
				GlobalTools.popMessage(this, "Connection Error!");
				Response.Redirect("../Login.aspx?expire=1");
			}

			viewData();
			clearFields();
			SetMandatory(RDO_RFCUSTOMERTYPE.SelectedValue);


		}
		private void DatGridPreEntry_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			string CU_REF		= e.Item.Cells[0].Text;
			string PRE_SEQSURAT = e.Item.Cells[1].Text;
			string regno		= e.Item.Cells[9].Text;

			switch (e.CommandName.ToString()) 
			{
				case "Delete":
					bool bBolehHapus = false;
					//Cek Apakah cu_ref sudah ada di dalam application?
					try
					{
						conn.QueryString = "Select * from VW_PRE_ENTRY where cu_ref = '" +  CU_REF + "'";
						conn.ExecuteQuery();

						string IsProcessed = conn.GetFieldValue("PRE_ISPROCESSED");
						if (IsProcessed == "0")
							bBolehHapus = true;

					}
					catch(NullReferenceException)
					{
						GlobalTools.popMessage(this, "Connection Error !");
						Response.Redirect("../Login.aspx?expire=1");
					}

					if(bBolehHapus)
					{
						//Hapus 
						try
						{
							conn.QueryString = "exec DE_PRE_INITIAL_ENTRY '" +  CU_REF + "', '" + PRE_SEQSURAT + "', '"+regno+"' ";
							conn.ExecuteNonQuery();
						}
						catch(NullReferenceException)
						{
							GlobalTools.popMessage(this, "Connection Error !");
							Response.Redirect("../Login.aspx?expire=1");
						}
					}

					viewData();
					clearFields();
					//DDL_RMUSER.Enabled=true;

					break;

				case "View":
					try {
						conn.QueryString = "select * from VW_PRE_ENTRY where CU_REF = '" +  CU_REF + "' and PRE_SEQSURAT = '" + PRE_SEQSURAT + "' and AP_REGNO='"+regno+"'";
						conn.ExecuteQuery();
					} 
					catch (NullReferenceException)  {
						GlobalTools.popMessage(this, "Connection Error !");
						Response.Redirect("../Login.aspx?expire=1");
					}

					if (conn.GetRowCount()>0)  
					{
						LBL_PRE_SEQSURAT.Text	= PRE_SEQSURAT;
						LBL_REGNO.Text			= regno;
						LBL_CUREF2.Text			= CU_REF;

						TXT_PRE_PERIHAL.Text	= conn.GetFieldValue("PRE_PERIHAL");
						TXT_PRE_APPAMOUNT.Text	= conn.GetFieldValue("AMOUNT");
						GlobalTools.fromSQLDate(conn.GetFieldValue("PRE_APPENTRYDATE"), TXT_DAY_APP, DDL_MONTH_APP, TXT_YEAR_APP);
						
						//Show Tanggal Terima
						GlobalTools.fromSQLDate(conn.GetFieldValue("PRE_APPTRMDATE"), TXT_DAY_TRM, DDL_MONTH_TRM, TXT_YEAR_TRM);

						TXT_CU_FIRSTNAME.Text	= conn.GetFieldValue("PRE_FIRSTNAME");
						TXT_CU_MIDDLENAME.Text	= conn.GetFieldValue("PRE_MIDDLENAME");
						TXT_CU_LASTNAME.Text	= conn.GetFieldValue("PRE_LASTNAME");
						DDL_RMUSER.SelectedValue			= conn.GetFieldValue("PRE_RMUSER");
						RDO_RFCUSTOMERTYPE.SelectedValue	= conn.GetFieldValue("CU_CUSTTYPEID");
						DDL_CL_CURRENCY.SelectedValue		= conn.GetFieldValue("PRE_APPAMOUNTCURR");
						TXT_CU_NPWP.Text = conn.GetFieldValue("PRE_NPWP");
						TXT_CU_IDCARDNUM.Text = conn.GetFieldValue("PRE_IDCARDNUM");
						GlobalTools.fromSQLDate(conn.GetFieldValue("PRE_IDCARDEXP"), TXT_CU_IDCARDEXP_DAY, DDL_CU_IDCARDEXP_MONTH, TXT_CU_IDCARDEXP_YEAR);
						setFieldStatus(false);

						SetMandatory(conn.GetFieldValue("CU_CUSTTYPEID"));

						//DDL_RMUSER.Enabled=false;
					}
					break;
			}
		}

		private void DatGridPreEntry_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			DatGridPreEntry.CurrentPageIndex = e.NewPageIndex;
			viewData();
		}

		protected void BTN_CANCEL_Click(object sender, System.EventArgs e)
		{
			setFieldStatus(true);
			clearFields();
		}

		protected void BTN_BACK_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			Response.Redirect("FindCustomer.aspx?mc=" + LBL_MC.Text);
		}

		protected void BTN_UPDATE_Click(object sender, System.EventArgs e)
		{
			//
			// Validasi Input field
			//
			if (!validateInputs()) return;

			Grid_Add.Visible = false;
			Grid_Exist.Visible = false;

			LBL_EXIST.Text = "1";
			p_AddData("2", LBL_CUREF2.Text);
	
			setFieldStatus(true);
			//DDL_RMUSER.Enabled=true;
		}	
	}
}
