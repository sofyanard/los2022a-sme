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

namespace SME.CreditOperation
{
	/// <summary>
	/// Summary description for MainCoAssignment.
	/// </summary>
	public partial class MainCoAssignment : System.Web.UI.Page
	{
		protected Tools tool = new Tools();
		protected Connection conn;
		//protected Connection conn = new Connection("Data Source=10.123.12.30;Initial Catalog=SMEDEV;uid=sa;pwd=");
		
		protected void Page_Load(object sender, System.EventArgs e)
		{
			conn = (Connection) Session["Connection"];

			if (!Logic.AllowAccess(Session["GroupID"].ToString(), Request.QueryString["mc"], conn))
				Response.Redirect("/SME/Restricted.aspx");

			if (!IsPostBack)
			{
				ViewDataApplication();
			}
			ViewListCollateral();
			ViewMenu();
		}

		private bool isPetugas(string groupid) 
		{
			bool petugas = false;

			conn.QueryString = "select groupid from scgroup where sg_grpupliner = '" + groupid + "'";
			conn.ExecuteQuery();
			
			if (conn.GetRowCount() == 0) petugas = true;

			return petugas;
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
			conn.QueryString = "select * from VW_CO_MAINASSIGNMENT where AP_REGNO = '" +Request.QueryString["regno"]+ "'";
			conn.ExecuteQuery();
			TXT_AP_REGNO.Text		= conn.GetFieldValue("AP_REGNO");
			TXT_CU_REF.Text			= conn.GetFieldValue("CU_REF");
			TXT_AP_SIGNDATE.Text	= tool.FormatDate(conn.GetFieldValue("AP_SIGNDATE"));
			TXT_PROGRAMDESC.Text	= conn.GetFieldValue("PROGRAMDESC");
			TXT_BRANCH_NAME.Text	= conn.GetFieldValue("BRANCH_NAME");
			TXT_AP_RELMNGR.Text		= conn.GetFieldValue("SU_FULLNAME");
			LBL_CU_CUSTTYPEID.Text	= conn.GetFieldValue("CU_CUSTTYPEID");
			TXT_AP_TEAMLEADER.Text = conn.GetFieldValue("AP_TLNAME");
			TXT_AP_BUSINESUNIT.Text = conn.GetFieldValue("AP_CANAME");
			TXT_AP_CA.Text = conn.GetFieldValue("AP_BUDESC");

			ViewDataCustomer();
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

		private void ViewListCollateral()
		{
			conn.QueryString = "select GRP_COOFF from APP_PARAMETER";
			conn.ExecuteQuery();
			string COOFF_CODE = conn.GetFieldValue("GRP_COOFF").ToString();
			
			conn.QueryString = "select * from VW_CO_ASSIGN_LISTCOLATERAL where AP_REGNO = '"+ Request.QueryString["regno"] +
							   "' and LA_CREDITOPR = '" +Session["BranchID"].ToString() + "'";
							   //"' and LA_CREDITOPR = '" +Session["UserID"].ToString()+ "'";
			conn.ExecuteQuery();
			DataTable dt = new DataTable();
			dt = conn.GetDataTable().Copy();
			
			int tblRowCount = Table_List.Rows.Count;
			for (int i = tblRowCount - 1; i >= 1; i--)
				Table_List.Rows.Remove(Table_List.Rows[i]);

			int row = conn.GetRowCount();
			int rowtemp = row;
			int CL_TYPE, CL_SEQ;
			string Directory = "../Dataentry/", BGCOLOR = "TDBGColor11";
			int no_row;
			TXT_JML_JAMINAN.Text = row.ToString();

			for (int i = 0; i < row; i++)
			{
				if (BGCOLOR == "TDBGColor11")
					BGCOLOR = "TDBGColor21";
				else
					BGCOLOR = "TDBGColor11";
				
				HyperLink t = new HyperLink();
				t.Text = dt.Rows[i][1].ToString()+". "+dt.Rows[i][4].ToString();
				t.ID = "COLL_LINK." + dt.Rows[i][1].ToString();		//--- Tambahan dari Yudi
				t.Font.Bold = true;
				CL_SEQ	= Convert.ToInt16(dt.Rows[i][1].ToString());
				CL_TYPE = Convert.ToInt16(dt.Rows[i][3].ToString());
				t.NavigateUrl = Directory + dt.Rows[i][5].ToString() +".aspx?curef="+ Request.QueryString["curef"] +"&coltypeid="+ CL_TYPE +"&CL_SEQ="+ CL_SEQ;
				t.Target = "coldetail";
				
				//------- tambahan dari yudi untuk menampilkan nama jaminan & Tipe Appraisal
				Label Lbl_Jaminan = new Label(), Lbl_Nama_Jaminan = new Label(), Lbl_ApprKhusus = new Label();				
				Lbl_Jaminan.Text = "Nama Jaminan";
				Lbl_Nama_Jaminan.Text	= dt.Rows[i][12].ToString();

				if (dt.Rows[i][14].ToString().Trim()=="1")
					Lbl_ApprKhusus.Text		= "Appraisal Khusus";
				else
					Lbl_ApprKhusus.Text		= "Appraisal Umum";
				//------- tambahan dari yudi untuk menampilkan nama jaminan
				
				RadioButton r1 = new RadioButton(), r2 = new RadioButton();
				r1.ID = "RDO_LA_APPRTYPE1" + i;
				r1.Text = "Eksternal";
				r1.GroupName = "RDG_LA_APPRTYPE"+i;
				r2.ID = "RDO_LA_APPRTYPE0" + i;
				r2.Text = "Internal   ";
				r2.GroupName = "RDG_LA_APPRTYPE"+i;
				r1.AutoPostBack = true;
				r2.AutoPostBack = true;
				r1.CheckedChanged += new EventHandler(r_CheckedChanged);
				r2.CheckedChanged += new EventHandler(r_CheckedChanged);

				Label LblAgency = new Label(), LblAgencyCode = new Label();
				Label LblStatus	= new Label(), LblStatus1 = new Label();
				Label LblOfficer = new Label();
				Label LblAgencyRate = new Label();

				Button btn1 = new Button(), btn2 = new Button();
				Button btn3 = new Button();
				//TextBox txtKet = new TextBox();

				/***
				txtKet.ID		= "TXT_REMARKTOBU"+i;
				txtKet.TextMode = TextBoxMode.MultiLine;
				txtKet.Rows		= 3;
				***/

				btn1.Text = "Process";
				btn1.ID = "BTN_PROCESS"+i;
				btn1.Click += new EventHandler(BTN_PROCESS_Click);
				//btn1.Attributes.Add("onclick","if(!cek_mandatory(document.Form1)){return false;};");

				btn2.Text = "Cancel";
				btn2.ID = "BTN_CANCEL"+i;
				btn2.Click += new EventHandler(BTN_CANCEL_Click);

				btn3.Text	= "Return To BU";
				btn3.ID		= "BTN_RETURN"+i;
				btn3.Click +=new EventHandler(btn3_Click);

				LblAgency.Text	 = "Agency";
				LblOfficer.Text	 = "Officer";
				LblStatus.Text	 = "Status";
				LblAgencyRate.Text = "Agency Rate";
				LblStatus.Font.Bold = true;
				LblStatus1.Font.Bold = true;
				LblAgencyCode.ID		= "LBL_AGENCYID"+i;
				LblAgencyCode.Visible	= false;

				System.Web.UI.WebControls.Image ImgStatus = new System.Web.UI.WebControls.Image();
				DropDownList DDL1 = new DropDownList(), Ddl_Agency = new DropDownList();
				DropDownList Ddl_AgencyRate = new DropDownList();

				DDL1.ID = "DDL_OFFICER"+i;
				Ddl_Agency.ID = "DDL_AGENCYID"+i;
				DDL1.Items.Add(new ListItem("- SELECT -", ""));
				Ddl_Agency.Items.Add(new ListItem("- SELECT -", ""));

				//---- Tambahan dari Yudi: Untuk pilihan Agency Rate ----------
				conn.QueryString = "select * from RFKONDISI";
				conn.ExecuteQuery();
				Ddl_AgencyRate.ID = "DDL_AGENCYRATE" + i;
				Ddl_AgencyRate.Items.Add(new ListItem("- SELECT - ",""));
				foreach(DataRow dr in conn.GetDataTable().Rows) 
				{
					Ddl_AgencyRate.Items.Add(new ListItem(dr["KONDISIDESC"].ToString(), dr["KONDISIID"].ToString()));
				}																	
				Ddl_AgencyRate.Enabled = false;
				//-------------------------------------------------------------

				//--- Tambahan dari Yudi: Untuk save Agency Rate ----------------
				Button brate = new Button();
				brate.Text = "Save";
				brate.ID = "bt_rate"+i;
				brate.Attributes.Add("onClick", "if(!isSave()) { return false; }");
				brate.Click += new EventHandler(brate_Click);
				brate.Enabled = false;
				//----------------------------------------------------------------

				DDL1.Items.Add(new ListItem(Session["FullName"].ToString(), Session["UserID"].ToString()));
				//conn.QueryString = "select USERID, SU_FULLNAME from SCUSER where SU_UPLINER = '" +dt.Rows[i][7].ToString()+ "' and SU_ACTIVE = '1' and GROUPID = '"+COOFF_CODE.Trim()+"'";
				conn.QueryString = "select USERID, SU_FULLNAME, GROUPID from SCUSER where SU_UPLINER = '" + Session["UserID"] +
									"' and SU_ACTIVE = '1'"; // and GROUPID = Petugas
				conn.ExecuteQuery();
				DataTable dtPetugas = conn.GetDataTable().Copy();
				for (int j = 0; j < dtPetugas.Rows.Count; j++) 
				{
					if (isPetugas(dtPetugas.Rows[j]["GROUPID"].ToString()))
						DDL1.Items.Add(new ListItem(dtPetugas.Rows[j]["SU_FULLNAME"].ToString(), dtPetugas.Rows[j]["USERID"].ToString()));
				}
				
				conn.QueryString = "select AGENCYID, AGENCYNAME from RFAGENCY where ACTIVE = '1' and AGENCYTYPEID = '01'";
				conn.ExecuteQuery();
				for (int j = 0; j < conn.GetRowCount(); j++)
					Ddl_Agency.Items.Add(new ListItem(conn.GetFieldValue(j,1), conn.GetFieldValue(j,0)));

				try { DDL1.SelectedValue = dt.Rows[i][9].ToString().Trim(); }
				catch {}
				Ddl_Agency.SelectedValue	= dt.Rows[i][8].ToString().Trim();
				LblAgencyCode.Text			= dt.Rows[i][8].ToString().Trim();

				DDL1.CssClass		= "mandatory";
				Ddl_Agency.CssClass	= "mandatory";

				Button b1 = new Button();
				b1.Text = "Print";
				b1.ID = "bt_print"+i;
				b1.Click += new EventHandler(b1_OnClick);		//--- Tambahan dari Yudi

				if (dt.Rows[i][6].ToString().Trim() == "1") //if external
				{
					r1.Checked = true;
					Ddl_Agency.Enabled = true;
					Ddl_Agency.CssClass	= "mandatory";
				}
				else //if internal
				{
					r2.Checked = true;
					Ddl_Agency.Enabled = false;
					Ddl_Agency.CssClass	= "";
					b1.Visible	= false;
				}

				//status
				string TIPETOMBOL = "2";
				if (dt.Rows[i][11].ToString().Trim() == "2" || 
					dt.Rows[i][11].ToString().Trim() == "5" || 
					dt.Rows[i][11].ToString().Trim() == "6")
				{
					Ddl_Agency.Enabled	= false;
					r1.Enabled			= false;
					r2.Enabled			= false;
					DDL1.Enabled = false;
					ImgStatus.ImageUrl = "../image/UnComplete.gif";

					if (dt.Rows[i][11].ToString().Trim() == "2")
					{
						LblStatus1.Text = "Assign To Officer";
						TIPETOMBOL = "1";
					}
					else if (dt.Rows[i][11].ToString().Trim() == "5") 
					{
						LblStatus1.Text = "Appraisal Entry Done";
					}
					else if (dt.Rows[i][11].ToString().Trim() == "6")
					{
						LblStatus1.Text = "Collateral Documents Incomplete";
					}

				}
				else if (dt.Rows[i][11].ToString().Trim() == "3")
				{					
					LblStatus1.Text = "Done";
					Ddl_Agency.Enabled	= false;

					//----- tambahan dari Yudi 
					if (r1.Checked == true) 
					{
						if (dt.Rows[i][13].ToString().Equals("")) 
						{
							Ddl_AgencyRate.Enabled = true;	//--- Agency Rate TRUE kalau status = DONE
							brate.Enabled = true;
						}
						else 
						{
							Ddl_AgencyRate.SelectedValue = dt.Rows[i][13].ToString();
						}
					}
					//---------------------------
					r1.Enabled			= false;
					r2.Enabled			= false;
					DDL1.Enabled = false;
					ImgStatus.ImageUrl = "../image/Complete.gif";
				}
				else if (dt.Rows[i][11].ToString().Trim() == "7") 
				{
					//
					//	collateral document incomplete dari co manager ke bu
					//
					TIPETOMBOL = "1";
					LblStatus1.Text = "Collateral Documents Incomplete";
					Ddl_Agency.Enabled	= false;

					//----- tambahan dari Yudi 
					if (r1.Checked == true) 
					{
						if (dt.Rows[i][13].ToString().Equals("")) 
						{
							Ddl_AgencyRate.Enabled = true;	//--- Agency Rate TRUE kalau status = DONE
							brate.Enabled = true;
						}
						else 
						{
							Ddl_AgencyRate.SelectedValue = dt.Rows[i][13].ToString();
						}
					}
					//---------------------------
					r1.Enabled			= false;
					r2.Enabled			= false;
					DDL1.Enabled = false;
					ImgStatus.ImageUrl = "../image/UnComplete.gif";
				}
				else
				{
					LblStatus1.Text = "Not Assign";
					ImgStatus.ImageUrl = "../image/UnComplete.gif";
					TIPETOMBOL = "0";
				}

				if (TIPETOMBOL != "2") //if not done
				{
					if (TIPETOMBOL == "0")//if process
					{
						btn1.Visible = true;
						btn2.Visible = false;
					}
					else //if cancel
					{
						btn1.Visible = false;
						btn2.Visible = true;
					}
				}
				else //if done
				{
					btn1.Visible = false;
					btn2.Visible = false;
					btn3.Visible = false;
					//txtKet.Visible = false;
				}

				TextBox t2 = new TextBox();
				t2.ID = "TXT_CL_SEQ" + i;
				t2.Text = CL_SEQ.ToString();
				t2.Visible = false;

				no_row = (i * 7)+1;
				this.Table_List.Rows.Add(new TableRow());
				this.Table_List.Rows[no_row].CssClass = BGCOLOR;
				this.Table_List.Rows[no_row].Cells.Add(new TableCell());
				TableCell mycell1 = new TableCell();
				mycell1 = this.Table_List.Rows[no_row].Cells[0];
				mycell1.RowSpan = 4;
				mycell1.Controls.Add(t);
				mycell1.VerticalAlign = VerticalAlign.Top;
				this.Table_List.Rows[no_row].Cells[0].Controls.Add(t2);
				this.Table_List.Rows[no_row].Cells[0].Controls.Add(LblAgencyCode);
				this.Table_List.Rows[no_row].Cells.Add(new TableCell());
				this.Table_List.Rows[no_row].Cells[1].Controls.Add(Lbl_ApprKhusus);
				this.Table_List.Rows[no_row].Cells[1].ColumnSpan = 2;
				 
				this.Table_List.Rows.Add(new TableRow());
				no_row = no_row + 1;
				this.Table_List.Rows[no_row].CssClass = BGCOLOR;
				this.Table_List.Rows[no_row].Cells.Add(new TableCell());
				this.Table_List.Rows[no_row].Cells[0].Controls.Add(r2);
				this.Table_List.Rows[no_row].Cells[0].Width = 100;
				this.Table_List.Rows[no_row].Cells.Add(new TableCell());
				this.Table_List.Rows[no_row].Cells[1].Controls.Add(r1);
				
				//----------
				this.Table_List.Rows.Add(new TableRow());
				no_row = no_row + 1;
				this.Table_List.Rows[no_row].CssClass = BGCOLOR;
				this.Table_List.Rows[no_row].Cells.Add(new TableCell());
				this.Table_List.Rows[no_row].Cells[0].Controls.Add(Lbl_Jaminan);
				this.Table_List.Rows[no_row].Cells.Add(new TableCell());
				this.Table_List.Rows[no_row].Cells[1].Controls.Add(Lbl_Nama_Jaminan);				
				//------------

				this.Table_List.Rows.Add(new TableRow());
				no_row = no_row + 1;
				this.Table_List.Rows[no_row].CssClass = BGCOLOR;
				//this.Table_List.Rows[no_row].Cells.Add(new TableCell());				
				//this.Table_List.Rows[no_row].Cells[0].Controls.Add(new LiteralControl("&nbsp"));
				this.Table_List.Rows[no_row].Cells.Add(new TableCell());
				this.Table_List.Rows[no_row].Cells[0].Controls.Add(LblAgency);
				this.Table_List.Rows[no_row].Cells.Add(new TableCell());
				this.Table_List.Rows[no_row].Cells[1].Controls.Add(Ddl_Agency);

				this.Table_List.Rows.Add(new TableRow());
				no_row = no_row + 1;
				this.Table_List.Rows[no_row].CssClass = BGCOLOR;
				this.Table_List.Rows[no_row].Cells.Add(new TableCell());				
				this.Table_List.Rows[no_row].Cells[0].Controls.Add(LblStatus);
				this.Table_List.Rows[no_row].Cells[0].HorizontalAlign = HorizontalAlign.Center;
				this.Table_List.Rows[no_row].Cells.Add(new TableCell());
				this.Table_List.Rows[no_row].Cells[1].Controls.Add(LblAgencyRate);
				this.Table_List.Rows[no_row].Cells.Add(new TableCell());
				this.Table_List.Rows[no_row].Cells[2].Controls.Add(Ddl_AgencyRate);
				this.Table_List.Rows[no_row].Cells[2].Controls.Add(brate);

				this.Table_List.Rows.Add(new TableRow());
				no_row = no_row + 1;
				this.Table_List.Rows[no_row].CssClass = BGCOLOR;
				this.Table_List.Rows[no_row].Cells.Add(new TableCell());
				this.Table_List.Rows[no_row].Cells[0].Controls.Add(ImgStatus);
				this.Table_List.Rows[no_row].Cells[0].Controls.Add(LblStatus1);
				this.Table_List.Rows[no_row].Cells[0].HorizontalAlign = HorizontalAlign.Center;
				this.Table_List.Rows[no_row].Cells.Add(new TableCell());
				this.Table_List.Rows[no_row].Cells[1].Controls.Add(LblOfficer);
				this.Table_List.Rows[no_row].Cells.Add(new TableCell());
				this.Table_List.Rows[no_row].Cells[2].Controls.Add(DDL1);

				no_row = no_row + 1;
				this.Table_List.Rows.Add(new TableRow());
				this.Table_List.Rows[no_row].CssClass = BGCOLOR;
				this.Table_List.Rows[no_row].Cells.Add(new TableCell());
				this.Table_List.Rows[no_row].Cells.Add(new TableCell());
				this.Table_List.Rows[no_row].Cells[1].Controls.Add(btn1);
				this.Table_List.Rows[no_row].Cells[1].Controls.Add(btn2);
				this.Table_List.Rows[no_row].Cells[1].Controls.Add(new LiteralControl("&nbsp"));				
				this.Table_List.Rows[no_row].Cells[1].Controls.Add(b1);
				this.Table_List.Rows[no_row].Cells[1].Controls.Add(new LiteralControl("&nbsp"));
				this.Table_List.Rows[no_row].Cells[1].Controls.Add(btn3);
				//this.Table_List.Rows[no_row].Cells[1].Controls.Add(new LiteralControl("<BR>"));
				//this.Table_List.Rows[no_row].Cells[1].Controls.Add(txtKet);
				this.Table_List.Rows[no_row].Cells[1].HorizontalAlign = HorizontalAlign.Center;
				this.Table_List.Rows[no_row].Cells[1].ColumnSpan = 2;
			}
		}

		private void BTN_PROCESS_Click(object sender, System.EventArgs e)
		{
			Button BTN = (Button) sender;
			string bId = BTN.ID;
			string idx = bId.Substring(11);
			
			TextBox TXT_CL_SEQ; //, TXT_LA_ASSIGNDATE_DAY, TXT_LA_ASSIGNDATE_YEAR;
			DropDownList DDL_OFFICERSEQ, DDL_AGENCYID, DDL_AGENCYRATE; //, DDL_LA_ASSIGNDATE_MONTH;
			RadioButton RDO_LA_APPRTYPE0, RDO_LA_APPRTYPE1;
			string LA_APPRTYPE;

			TXT_CL_SEQ = (TextBox) Table_List.FindControl("TXT_CL_SEQ"+idx);
			DDL_OFFICERSEQ = (DropDownList) Table_List.FindControl("DDL_OFFICER"+idx);
			DDL_AGENCYID	 = (DropDownList) Table_List.FindControl("DDL_AGENCYID"+idx);
			DDL_AGENCYRATE   = (DropDownList) Table_List.FindControl("DDL_AGENCYRATE"+idx);
			RDO_LA_APPRTYPE0 = (RadioButton) Table_List.FindControl("RDO_LA_APPRTYPE0"+idx);
			RDO_LA_APPRTYPE1 = (RadioButton) Table_List.FindControl("RDO_LA_APPRTYPE1"+idx);

			LA_APPRTYPE = "0";
			if (RDO_LA_APPRTYPE1.Checked)
				LA_APPRTYPE = "1";
			
			//---pengecekan mandatory------
			if (LA_APPRTYPE == "1" && DDL_AGENCYID.SelectedValue.Trim() == "")
				Tools.popMessage(this,"Agency Tidak Boleh Kosong");
			else if ((LA_APPRTYPE == "0" || LA_APPRTYPE == "1") && DDL_OFFICERSEQ.SelectedValue.Trim() == "")
				Tools.popMessage(this,"CO Officer Tidak Boleh Kosong");
			else
			{
				string cl_desc = "";
				string coManager = (string) Session["UserID"];

				//Get Collateral Description
				conn.QueryString = "select CL_DESC from COLLATERAL where CU_REF = '" + Request.QueryString["curef"] + "' and CL_SEQ = '" + TXT_CL_SEQ.Text + "'";
				conn.ExecuteQuery();
				if (conn.GetRowCount() > 0) cl_desc = conn.GetFieldValue("CL_DESC");

				try 
				{
					conn.QueryString = "exec CO_ASSIGNMENTOFFICER '" + Request.QueryString["regno"] + "', '" + Request.QueryString["curef"] + "', " +
						tool.ConvertNum(TXT_CL_SEQ.Text)+", '" + DDL_OFFICERSEQ.SelectedValue+ "', '" + DDL_AGENCYID.SelectedValue+ "', '" +
						LA_APPRTYPE+ "', '1'";
					conn.ExecTrans();

					//----------------- Start AUDIT TRAIL ----------------------

					//Appraisal Officer Assignment
					conn.QueryString = "exec SP_AUDITTRAIL_APP '" + 
						Request.QueryString["regno"] + "', NULL, NULL, NULL, '" + 
						Request.QueryString["curef"] + "', '" + 
						Request.QueryString["tc"] + "', '" + TXT_AUDITDESC_OFFICER.Text + cl_desc + "', '" + 
						DDL_OFFICERSEQ.SelectedItem.Text + "', '" + 
						coManager + "', NULL, 'N'";
					conn.ExecTrans();

					//Appraisal Agency Assignment
					if (LA_APPRTYPE == "1") 
					{
						conn.QueryString = "exec SP_AUDITTRAIL_APP '" + 
							Request.QueryString["regno"] + "', NULL, NULL, NULL, '" + 
							Request.QueryString["curef"] + "', '" + 
							Request.QueryString["tc"] + "', '" + TXT_AUDITDESC_AGENCY.Text + cl_desc + "', '" + 
							DDL_AGENCYID.SelectedItem.Text + "', '" + 
							coManager + "', NULL, 'N'";
						conn.ExecTrans();
					}

					//----------------- End AUDIT TRAIL ----------------------

					conn.ExecTran_Commit();
				} 
				catch 
				{
					if (conn != null)
						conn.ExecTran_Rollback();
				}

				ViewListCollateral();
			}
		}

		private void BTN_CANCEL_Click(object sender, System.EventArgs e)
		{
			Button BTN = (Button) sender;
			string bId = BTN.ID;
			string idx = bId.Substring(10);
			
			TextBox TXT_CL_SEQ;
			DropDownList DDL_OFFICERSEQ;

			TXT_CL_SEQ = (TextBox) Table_List.FindControl("TXT_CL_SEQ"+idx);
			DDL_OFFICERSEQ = (DropDownList) Table_List.FindControl("DDL_OFFICER"+idx);
			
			conn.QueryString = "exec CO_ASSIGNMENTOFFICER '" +Request.QueryString["regno"]+ "', '" +Request.QueryString["curef"]+ "', "+
				tool.ConvertNum(TXT_CL_SEQ.Text)+", '" +DDL_OFFICERSEQ.SelectedValue+ "', '', '', '2'";
			conn.ExecuteNonQuery();
			ViewListCollateral();
		}

		private void r_CheckedChanged(object sender, EventArgs e)
		{
			RadioButton RDO_TYPE = (RadioButton) sender;
			string mId = RDO_TYPE.ID;
			string mCount = mId.Substring(16,1);
			
			RadioButton RDO_LA_APPRTYPE1 = (RadioButton) Table_List.FindControl("RDO_LA_APPRTYPE1"+mCount);
			DropDownList DDL_AGENCY = (DropDownList) Table_List.FindControl("DDL_AGENCYID"+mCount);
			Label LBL_AGENCYID		= (Label) Table_List.FindControl("LBL_AGENCYID"+mCount);
			Button BTN_PRINT		= (Button) Table_List.FindControl("bt_print"+mCount);
			
			if (RDO_LA_APPRTYPE1.Checked)
			{
				DDL_AGENCY.Enabled	= true;
				DDL_AGENCY.SelectedValue = LBL_AGENCYID.Text;
				DDL_AGENCY.CssClass		 = "mandatory";
				BTN_PRINT.Visible	= true;
			}
			else
			{
				DDL_AGENCY.Enabled	= false;
				DDL_AGENCY.SelectedValue = "";
				DDL_AGENCY.CssClass		 = "";
				BTN_PRINT.Visible	= false;
			}
		}

		private void b1_OnClick(object sender, EventArgs e) //--- Tambahan dari Yudi
		{
			Button BTN = (Button) sender;
			string bId = BTN.ID;
			string idx = bId.Substring(8);

			HyperLink h = (HyperLink) Table_List.FindControl("COLL_LINK"+idx);
			DropDownList ddl = (DropDownList) Table_List.FindControl("DDL_AGENCYID" + idx);
			DropDownList ddloff = (DropDownList) Table_List.FindControl("DDL_OFFICER" + idx);
			TextBox txtseq = (TextBox) Table_List.FindControl("TXT_CL_SEQ" + idx);

			string seq = txtseq.Text;
			string agency_id = ddl.SelectedValue.ToString().Trim();
			string officer_id = ddloff.SelectedValue.ToString().Trim();
			string cu_ref = this.TXT_CU_REF.Text.ToString().Trim();
			string regno = this.TXT_AP_REGNO.Text.ToString().Trim();
				
			Response.Write("<script language='javascript'>window.open('CoverNote/PenugasanAgunan.aspx?seq=" + seq + "&regno=" + regno + "&agency_id=" + agency_id + "&officer_id=" + officer_id + "&cu_ref=" + cu_ref + "','Penugasan_Agunan','status=no,scrollbars=yes,width=800,height=600');</script>");
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

		private void brate_Click(object sender, EventArgs e)
		{
			Button bRate = (Button) sender;
			string bId = bRate.ID;
			string idx = bId.Substring(7);

			DropDownList ddl_agencyid   = (DropDownList) this.Table_List.FindControl("DDL_AGENCYID" + idx);
			DropDownList ddl_agencyrate = (DropDownList) this.Table_List.FindControl("DDL_AGENCYRATE" + idx);
			TextBox txtseq              = (TextBox) Table_List.FindControl("TXT_CL_SEQ" + idx);

			string agencyId = ddl_agencyid.SelectedValue;
			string agencyRate = ddl_agencyrate.SelectedValue;
			conn.QueryString = "exec CO_RATINGAGENCY '" + Request.QueryString["regno"] + "', '" + Request.QueryString["curef"] + "', '" + txtseq.Text + "', '" + agencyId + "','" + agencyRate + "'";
			conn.ExecuteNonQuery();

			ddl_agencyrate.Enabled = false;
			bRate.Enabled = false;
		}

		protected void BTN_BACK_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			Response.Redirect("/SME/" + DMS.CuBESCore.Logic.backLink(Request.QueryString["tc"].ToString(), conn));
		}

		private void btn3_Click(object sender, EventArgs e)
		{			
			Button bReturn = (Button) sender;
			string bId = bReturn.ID;
			string idx = bId.Substring(10);

			//TextBox txtRemark	= (TextBox) Table_List.FindControl("TXT_REMARKTOBU" + idx);
			TextBox txtseq		= (TextBox) Table_List.FindControl("TXT_CL_SEQ" + idx);

//			if (txtRemark.Text.Trim() == "") 
//			{
//				GlobalTools.popMessage(this, "Remark ke BU tidak boleh kosong!");
//				return;
//			}

			//	set status appraisal untuk incomplete document for appraisal
			conn.QueryString = "exec APPRAISAL_INCOMPLETE '" + 
				Request.QueryString["regno"] + "', '" + 
				Request.QueryString["curef"] + "', '" + 
				txtseq.Text + "', '7', ''";
				//txtseq.Text + "', '7', '" + txtRemark.Text + "'";
			conn.ExecuteQuery();

			ViewListCollateral();
		}
	}
}
