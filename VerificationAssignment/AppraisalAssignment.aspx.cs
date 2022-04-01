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


namespace SME.VerificationAssignment
{
	/// <summary>
	/// Summary description for AppraisalAssignment.
	/// </summary>
	public partial class AppraisalAssignment : System.Web.UI.Page
	{
		protected Connection conn;
		protected Tools tool = new Tools();
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			conn = (Connection) Session["Connection"];
			if (!IsPostBack)
			{
				CekNeedAppraisal();
			}
			CekCOBranch();
			ViewListCollateral();
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
		private void CekNeedAppraisal()
		{
			conn.QueryString = "select * from VW_NEED_APPRAISAL WHERE AP_REGNO = '"+ Request.QueryString["regno"] +"'";
			conn.ExecuteQuery();
			//REQAPPRAISAL <> '1' and 
			DataTable dc = new DataTable();
			dc = conn.GetDataTable().Copy();
			int jrow = conn.GetRowCount();
			for (int i = 0; i < jrow; i++)
			{
				conn.QueryString = "exec APPRAISAL_NOTNEED '" +dc.Rows[i][0].ToString()+ "', '" +dc.Rows[i][2].ToString()+ "', "+dc.Rows[i][1].ToString()+", '" +dc.Rows[i][3].ToString()+ "'";
				conn.ExecuteQuery();
			}
		}
		
		private void CekCOBranch()
		{
			conn.QueryString = "select top 1 USERID from APPLICATION app " +
							   "left join RFBRANCH br on app.BRANCH_CODE = br.BRANCH_CODE " +
							   "left join SCUSER sc on sc.SU_BRANCH = br.BR_CCOBRANCH and GROUPID = (select top 1 GRP_CO from APP_PARAMETER) " +
							   "where AP_REGNO = '" + Request.QueryString["regno"] + "'";
			conn.ExecuteQuery();
			LBL_COBRANCH.Text = conn.GetFieldValue("USERID").ToString();
		}

		private void ViewListCollateral()
		{

			conn.QueryString = "select * from VW_VER_ASSIGN_LISTCOLATERAL where AP_REGNO = '"+ Request.QueryString["regno"] +"'";
			conn.ExecuteQuery();
			DataTable dt = new DataTable();
			dt = conn.GetDataTable().Copy();

			int tblRowCount = Table_List.Rows.Count;
			for (int i = tblRowCount - 1; i >= 1; i--)
				Table_List.Rows.Remove(Table_List.Rows[i]);
			int row = conn.GetRowCount();
			int rowtemp = row;
			int CL_TYPE, CL_SEQ;
			string STS_APPR, LA_APPRTYPE, ASIGNDATE, LA_APPRSTATUS, Directory = "../Dataentry/", BGCOLOR = "TDBGColor11";
			int no_row, mCount;

			TXT_JML_JAMINAN.Text = row.ToString();
			LBL_CU_REF.Text = Request.QueryString["curef"];
			LBL_AP_REGNO.Text = Request.QueryString["regno"];
			
			for (int i = 0; i < row; i++)
			{
				if (BGCOLOR == "TDBGColor11")
					BGCOLOR = "TDBGColor21";
				else
					BGCOLOR = "TDBGColor11";
				mCount = i + 1;
				HyperLink t = new HyperLink();
				t.Text = mCount.ToString()+". "+dt.Rows[i][11].ToString() + " (" + dt.Rows[i][4].ToString() + ")";
				t.Font.Bold = true;

				CL_SEQ	= Convert.ToInt16(dt.Rows[i][1].ToString());
				CL_TYPE = Convert.ToInt16(dt.Rows[i][3].ToString());
				LA_APPRTYPE = dt.Rows[i][6].ToString().Trim();
				LA_APPRSTATUS = dt.Rows[i][9].ToString().Trim();
				
				STS_APPR = "";
				if (LA_APPRTYPE == "2" && LA_APPRSTATUS == "4")
					STS_APPR = "&de=1&appr=1";
				else if (LA_APPRTYPE == "2" && LA_APPRSTATUS == "3")
					STS_APPR = "&de=1";

				t.NavigateUrl = Directory + dt.Rows[i][5].ToString() +".aspx?regno="+Request.QueryString["regno"]+"&curef="+ Request.QueryString["curef"] +"&coltypeid="+ CL_TYPE +"&CL_SEQ="+ CL_SEQ + STS_APPR;
				t.Target = "coldetail";
				
				RadioButton ra1 = new RadioButton(), ra2 = new RadioButton();
				ra1.ID = "RDO_LA_APPRKHUSUS0" + i;
				ra1.Text = "Appraisal Umum";
				ra1.GroupName = "RDG_LA_APPRKHUSUS"+i;
				ra2.ID = "RDO_LA_APPRKHUSUS1" + i;
				ra2.Text = "Appraisal Khusus";
				ra2.GroupName = "RDG_LA_APPRKHUSUS"+i;
				ra1.AutoPostBack = true;
				ra2.AutoPostBack = true;
				ra1.CheckedChanged += new EventHandler(ra_CheckedChanged);
				ra2.CheckedChanged += new EventHandler(ra_CheckedChanged);
				
				RadioButton r1 = new RadioButton(), r2 = new RadioButton(), r3 = new RadioButton();
				r1.ID = "RDO_LA_APPRTYPE1" + i;
				r1.Text = "Ekternal  ";
				r1.GroupName = "RDG_TYPE"+i;
				r2.ID = "RDO_LA_APPRTYPE0" + i;
				r2.Text = "Internal  ";
				r2.GroupName = "RDG_TYPE"+i;
				r3.ID = "RDO_LA_APPRTYPE2" + i;
				r3.Text = "Not Appraised";
				r3.GroupName = "RDG_TYPE"+i;
				
				r1.AutoPostBack = true;
				r2.AutoPostBack = true;
				r3.AutoPostBack = true;
				r1.CheckedChanged += new EventHandler(r_CheckedChanged);
				r2.CheckedChanged += new EventHandler(r_CheckedChanged);
				r3.CheckedChanged += new EventHandler(r_CheckedChanged);

				Label LblAgency = new Label(), LblCO = new Label(), LblDate = new Label();
				Label LblStatus	= new Label(), LblStatus1 = new Label();
				
				LblAgency.Text	= "Agency";
				LblCO.Text		= "Credit Operations";
				LblDate.Text	= "Tanggal";
				LblStatus.Text	 = "Status";
				LblStatus.Font.Bold = true;
				LblStatus1.Font.Bold = true;

				System.Web.UI.WebControls.Image ImgStatus = new System.Web.UI.WebControls.Image();
				ImgStatus.ImageUrl = "../image/UnComplete.gif";

				DropDownList Ddl_Agency = new DropDownList(), 
							 Ddl_CO = new DropDownList(),
							 Ddl_Date_Month = new DropDownList();
				
				Ddl_Agency.ID = "DDL_AGENCYID"+i;
				Ddl_CO.ID = "DDL_CO"+i;
				Ddl_Date_Month.ID = "DDL_LA_ASSIGNDATE_MONTH"+i;

				//Ddl_CO.Enabled			= false;

				//--tambah button print--
				Button b1 = new Button();

				b1.Text = "Print";
				b1.ID = "BTN_PRINT"+i;
				b1.Visible = false;
				b1.Click += new EventHandler(b1_OnClick);
				//-----------------------
				
				Ddl_Agency.Items.Add(new ListItem("- SELECT -", ""));
				Ddl_Date_Month.Items.Add(new ListItem("- SELECT -", ""));

				conn.QueryString = "select AGENCYID, AGENCYNAME from RFAGENCY where AGENCYTYPEID = '01' and ACTIVE = '1'";
				conn.ExecuteQuery();
				for (int j = 0; j < conn.GetRowCount(); j++)
					Ddl_Agency.Items.Add(new ListItem(conn.GetFieldValue(j,1), conn.GetFieldValue(j,0)));

				//conn.QueryString = "select GRP_CO from APP_PARAMETER";
				//conn.ExecuteQuery();
				//string GROUPID = conn.GetFieldValue("GRP_CO");
				//conn.QueryString = "select USERID, SU_FULLNAME from SCUSER where GROUPID = '" +GROUPID.Trim()+ "'";
				/***
				 * --- Modif by Yudi
				 * Untuk kemudahan maintenance, query di bawah diubah ke view
				 * 
				conn.QueryString = "select distinct USERID, SU_FULLNAME from APPLICATION app "+
								   "left join RFBRANCH br on app.BRANCH_CODE = br.BRANCH_CODE "+
								   "left join SCUSER sc on sc.SU_BRANCH = br.BR_CCOBRANCH and SU_ACTIVE = '1' and GROUPID = (select top 1 GRP_CO from APP_PARAMETER) "+
								   "where AP_REGNO = '" +Request.QueryString["regno"].ToString().Trim()+ "'";				
				conn.ExecuteQuery();
				for (int j = 0; j < conn.GetRowCount(); j++)
					Ddl_CO.Items.Add(new ListItem(conn.GetFieldValue(j,1), conn.GetFieldValue(j,0)));
				***/
				GlobalTools.fillRefList(Ddl_CO, "select * from VW_IDE_COMANAGER", false, conn);

				for (int j = 1; j <= 12; j++)
				{
					Ddl_Date_Month.Items.Add(new ListItem(DateAndTime.MonthName(j, false), j.ToString()));
				}

				TextBox t2 = new TextBox(), t3 = new TextBox(),
						TxtDateDay = new TextBox(), TxtDateYear = new TextBox();
				
				TxtDateDay.MaxLength = 2;
				TxtDateDay.Width	 = 24;
				TxtDateDay.ID = "TXT_LA_ASSIGNDATE_DAY"+i;
				TxtDateYear.MaxLength = 4;
				TxtDateYear.Width	 = 36;
				TxtDateYear.ID = "TXT_LA_ASSIGNDATE_YEAR"+i;

				t2.ID = "TXT_CL_SEQ" + i;
				t2.Text = CL_SEQ.ToString();
				t2.Visible = false;

				Button btn1 = new Button(), btn2 = new Button(), btn3 = new Button();
				//TextBox txtKet = new TextBox();

				/***
				txtKet.ID		= "BTN_REMARKTOBU" + i;
				txtKet.TextMode = TextBoxMode.MultiLine;
				txtKet.Rows		= 3;
				txtKet.ReadOnly = true;
				***/


				btn1.Text = "Process";
				btn1.ID = "BTN_PROCESS"+i;
				btn1.Click += new EventHandler(BTN_PROCESS_Click);
				//btn1.Attributes.Add("onclick","if(!cek_mandatory(document.Form1)){return false;};");

				btn2.Text = "Cancel";
				btn2.ID = "BTN_CANCEL"+i;
				btn2.Click += new EventHandler(BTN_CANCEL_Click);

				btn3.Text = "Re-Appraised";
				btn3.ID = "BTN_REAPPR"+i;
				btn3.Visible = false;
				btn3.Click += new EventHandler(BTN_REAPPRAISED_Click);
				btn3.Attributes.Add("onclick","if(!update()){return false;};");
				
				//Ddl_Agency.CssClass		= "mandatory";
				Ddl_CO.CssClass			= "mandatory";
				TxtDateDay.CssClass		= "mandatory";
				Ddl_Date_Month.CssClass	= "mandatory";
				TxtDateYear.CssClass	= "mandatory";

				if (LA_APPRTYPE == "1") //if external
				{
					r1.Checked = true;
				}
				else if (LA_APPRTYPE == "2") //if not Appraise
				{
					r3.Checked = true;
					Ddl_Agency.CssClass		= "";
					Ddl_CO.CssClass			= "";
					TxtDateDay.CssClass		= "";
					Ddl_Date_Month.CssClass	= "";
					TxtDateYear.CssClass	= "";
				}
				else
				{
					r2.Checked = true;
					Ddl_Agency.CssClass		= "";
				}

				if (dt.Rows[i][13].ToString().Trim() == "1") //if appraisal khusus
				{
					ra2.Checked	= true;
					b1.Visible	= true;
					r1.Checked	= true;
					r2.Enabled	= false;
					r3.Enabled	= false;
				}
				else //if appraisal umum
				{
					ra1.Checked = true;
					b1.Visible = false;
				}

				//
				// Define Agency
				//
				Ddl_Agency.SelectedValue	= dt.Rows[i][8].ToString().Trim();


				//
				// Define Credit Operations
				//
				try 
				{
					Ddl_CO.SelectedValue		= dt.Rows[i][7].ToString().Trim();
				} 
				catch
				{
					/***
					string COMANAGER = dt.Rows[i][7].ToString().Trim();
					conn.QueryString = "select SU_BRANCH from SCUSER where userid = '" + COMANAGER + "'";
					conn.ExecuteQuery();
					Ddl_CO.SelectedValue = conn.GetFieldValue("SU_BRANCH");
					***/

					//20070803 remark by sofyan - replace with procedure below
					//SME Enhancement: CCO Branch has already input in Initial Data Entry,
					//so that appraisal should goes to the selected CCO Branch
					//conn.QueryString = "select b.br_ccobranch from application a " + 
					//	"left join rfbranch b on a.branch_code = b.branch_code " + 
					//	"where ap_regno = '" + LBL_AP_REGNO.Text + "'";
					//conn.ExecuteQuery();
					conn.QueryString = "EXEC APPRAISAL_ASSIGNMENT_CO '" + LBL_AP_REGNO.Text + "'";
					conn.ExecuteQuery();
					Ddl_CO.SelectedValue = conn.GetFieldValue("BR_CCOBRANCH");
				}
				Response.Write("<!-- CO defined : " + Ddl_CO.SelectedValue.ToString() + " -->");

				//
				// TODO :
				// Kalau Credit Operations kosong, biarkan user memilih manually
				//
				if (Ddl_CO.SelectedValue == "") 
				{
					Response.Write("<!-- CO Empty, so user can pick manually -->");
					conn.QueryString = "select b.br_ccobranch from application a " + 
						"left join rfbranch b on a.branch_code = b.branch_code " + 
						"where ap_regno = '" + LBL_AP_REGNO.Text + "'";
					conn.ExecuteQuery();
					try { Ddl_CO.SelectedValue = conn.GetFieldValue("BR_CCOBRANCH"); } 
					catch { Ddl_CO.Enabled = true; }

					Response.Write("<!-- CO : " + Ddl_CO.SelectedValue.ToString() + " -->");					
				}

				TextBox TxtCO = new TextBox();
				TxtCO.ID	= "TXT_CO"+i;
				TxtCO.Visible = false;

				if (dt.Rows[i][7].ToString().Trim() != "")
					TxtCO.Text	= dt.Rows[i][7].ToString().Trim();
				else
					TxtCO.Text	= LBL_COBRANCH.Text;

				if (dt.Rows[i][10].ToString() != "")
					ASIGNDATE = dt.Rows[i][10].ToString();
				else 
					ASIGNDATE = DateTime.Now.ToString();
				TxtDateDay.Text				 = tool.FormatDate_Day(ASIGNDATE);
				Ddl_Date_Month.SelectedValue = tool.FormatDate_Month(ASIGNDATE);
				TxtDateYear.Text			 = tool.FormatDate_Year(ASIGNDATE);

				string REQAPPRAISAL = dt.Rows[i][12].ToString().Trim();
				Label LblREQ	= new Label();
				LblREQ.Text = REQAPPRAISAL;
				LblREQ.Visible	= false;
				LblREQ.ID		= "LBL_REQAPPRAISAL" + i;


				//
				//	mengisi keterangan dari CO ke BU
				//
				/***
				conn.QueryString = "select LA_REMARKTOBU from LISTASSIGNMENT where AP_REGNO = '" + LBL_AP_REGNO.Text + 
					"' AND CU_REF = '" + LBL_CU_REF.Text + 
					"' AND CL_SEQ = '" + i + "'";
				conn.ExecuteQuery();
				if (conn.GetFieldValue("LA_REMARKTOBU") != "")  {
					txtKet.Text = conn.GetFieldValue("LA_REMARKTOBU");
					txtKet.Visible	= true;
				}
				else  {
					txtKet.Visible	= false;
				}
				***/
														

				string TIPETOMBOL = "2"; //done
				if (LA_APPRSTATUS == "0" || LA_APPRSTATUS == "")
				{
					if (LA_APPRTYPE == "0" || LA_APPRTYPE == "") //if internal
						Ddl_Agency.Enabled = false;
					else if (LA_APPRTYPE == "2")
					{
						Ddl_Agency.Enabled		= false;
						Ddl_CO.Enabled			= false;
						TxtDateDay.ReadOnly		= true;
						Ddl_Date_Month.Enabled	= false;
						TxtDateYear.ReadOnly	= true;
					}
					LblStatus1.Text = "Not Assign";
					TIPETOMBOL = "0"; //Process
				}
				else
				{
					r1.Enabled				= false;
					r2.Enabled				= false;
					r3.Enabled				= false;
					ra1.Enabled				= false;
					ra2.Enabled				= false;
					Ddl_Agency.Enabled		= false;
					Ddl_CO.Enabled			= false;
					TxtDateDay.ReadOnly		= true;
					Ddl_Date_Month.Enabled	= false;
					TxtDateYear.ReadOnly	= true;

					if (LA_APPRSTATUS == "1")
					{
						LblStatus1.Text = "Assign";
						TIPETOMBOL = "1"; //cancel
					}
					else if (LA_APPRSTATUS == "2") 
					{
						LblStatus1.Text = "Assign To CO Officer";
						TIPETOMBOL = "1"; // cancel btn
					}
					else if (LA_APPRSTATUS == "5") 
					{
						LblStatus1.Text = "Appraisal Entry Done";
					}
					else if (LA_APPRSTATUS == "3")
					{
						LblStatus1.Text = "Done";
						ImgStatus.ImageUrl = "../image/Complete.gif";
					}
					else if (LA_APPRSTATUS == "6")	// incomplete doc dari petugas
					{
						LblStatus1.Text = "Documents Incomplete";
						ImgStatus.ImageUrl = "../image/UnComplete.gif";
						TIPETOMBOL = "0";
					}
					else if (LA_APPRSTATUS == "7")	// incomplete doc dari co manager
					{
						LblStatus1.Text = "Documents Incomplete";
						ImgStatus.ImageUrl = "../image/UnComplete.gif";
						TIPETOMBOL = "0";

						//////////////////////////////////////////////////////////////////
						///	SET KE STATUS DEFAULT
						///	
						r1.Enabled				= true;	//internal
						r2.Enabled				= true;	//external
						r3.Enabled				= true;	//not appraised
						ra1.Enabled				= true;	//appraisal umum
						ra2.Enabled				= true;	//appraisal khusus

						r1.Checked = true;
						r2.Checked = false;
						r3.Checked = false;
						ra1.Checked = true;
						ra2.Checked = false;

						Ddl_Agency.Enabled		= false;
						Ddl_CO.Enabled			= true;
						TxtDateDay.ReadOnly		= false;
						Ddl_Date_Month.Enabled	= true;
						TxtDateYear.ReadOnly	= false;
						//////////////////////////////////////////////////////////////////
					}
					else
					{
						LblStatus1.Text = "Not Done";
						if (REQAPPRAISAL == "1")
							TIPETOMBOL = "1"; //cancel
					}
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
					btn1.Visible = false;		// hide process btn
					btn2.Visible = false;		// hide cancel btn				
					
					//btn3.Visible = true;		// show re-appraise btn, for all kind appraisal
					// Kenapa kalau apparaisal type != 2, tidak bisa di re-appraise ??? (yudi)
					if (LA_APPRTYPE != "2")
						btn3.Visible = true;
					
 				}

				no_row = (i * 6)+1;
				this.Table_List.Rows.Add(new TableRow());
				this.Table_List.Rows[no_row].CssClass = BGCOLOR;
				this.Table_List.Rows[no_row].Cells.Add(new TableCell());
				TableCell mycell1 = new TableCell();
				mycell1 = this.Table_List.Rows[no_row].Cells[0];
				mycell1.RowSpan = 3;
				mycell1.Controls.Add(t);
				mycell1.Controls.Add(t2);
				mycell1.Controls.Add(TxtCO);
				mycell1.Controls.Add(LblREQ);
				mycell1.VerticalAlign = VerticalAlign.Top;
				
				this.Table_List.Rows[no_row].Cells.Add(new TableCell());
				this.Table_List.Rows[no_row].Cells[1].Controls.Add(ra1);
				this.Table_List.Rows[no_row].Cells[1].Width = 120;
				this.Table_List.Rows[no_row].Cells.Add(new TableCell());
				this.Table_List.Rows[no_row].Cells[2].ColumnSpan = 2;
				this.Table_List.Rows[no_row].Cells[2].Controls.Add(ra2);

				this.Table_List.Rows.Add(new TableRow());
				no_row = no_row + 1;
				this.Table_List.Rows[no_row].CssClass = BGCOLOR;
				this.Table_List.Rows[no_row].Cells.Add(new TableCell());
				this.Table_List.Rows[no_row].Cells[0].ColumnSpan = 3;
				this.Table_List.Rows[no_row].Cells[0].Controls.Add(r2);
				//this.Table_List.Rows[no_row].Cells[1].Width = 120;
				//this.Table_List.Rows[no_row].Cells.Add(new TableCell());
				this.Table_List.Rows[no_row].Cells[0].Controls.Add(r1);
				this.Table_List.Rows[no_row].Cells[0].Controls.Add(r3);

				this.Table_List.Rows.Add(new TableRow());
				no_row = no_row + 1;
				this.Table_List.Rows[no_row].CssClass = BGCOLOR;
				this.Table_List.Rows[no_row].Cells.Add(new TableCell());
				this.Table_List.Rows[no_row].Cells[0].Controls.Add(LblAgency);
				this.Table_List.Rows[no_row].Cells.Add(new TableCell());
				this.Table_List.Rows[no_row].Cells.Add(new TableCell());
				this.Table_List.Rows[no_row].Cells[2].Controls.Add(Ddl_Agency);

				this.Table_List.Rows.Add(new TableRow());
				no_row = no_row + 1;
				this.Table_List.Rows[no_row].CssClass = BGCOLOR;
				this.Table_List.Rows[no_row].Cells.Add(new TableCell());
				this.Table_List.Rows[no_row].Cells[0].Controls.Add(LblStatus);
				this.Table_List.Rows[no_row].Cells[0].HorizontalAlign = HorizontalAlign.Center;
				this.Table_List.Rows[no_row].Cells.Add(new TableCell());
				this.Table_List.Rows[no_row].Cells[1].Controls.Add(LblCO);
				this.Table_List.Rows[no_row].Cells.Add(new TableCell());
				this.Table_List.Rows[no_row].Cells.Add(new TableCell());
				this.Table_List.Rows[no_row].Cells[3].Controls.Add(Ddl_CO);
				
				no_row = no_row + 1;
				this.Table_List.Rows.Add(new TableRow());
				this.Table_List.Rows[no_row].CssClass = BGCOLOR;
				this.Table_List.Rows[no_row].Cells.Add(new TableCell());
				this.Table_List.Rows[no_row].Cells[0].Controls.Add(ImgStatus);
				this.Table_List.Rows[no_row].Cells[0].Controls.Add(LblStatus1);
				this.Table_List.Rows[no_row].Cells[0].HorizontalAlign = HorizontalAlign.Center;
				this.Table_List.Rows[no_row].Cells.Add(new TableCell());
				this.Table_List.Rows[no_row].Cells[1].Controls.Add(LblDate);
				this.Table_List.Rows[no_row].Cells.Add(new TableCell());
				this.Table_List.Rows[no_row].Cells.Add(new TableCell());
				this.Table_List.Rows[no_row].Cells[3].Controls.Add(TxtDateDay);
				this.Table_List.Rows[no_row].Cells[3].Controls.Add(Ddl_Date_Month);
				this.Table_List.Rows[no_row].Cells[3].Controls.Add(TxtDateYear);

				no_row = no_row + 1;
				this.Table_List.Rows.Add(new TableRow());
				this.Table_List.Rows[no_row].CssClass = BGCOLOR;
				this.Table_List.Rows[no_row].Cells.Add(new TableCell());
				this.Table_List.Rows[no_row].Cells.Add(new TableCell());
				//this.Table_List.Rows[no_row].Cells[1].Controls.Add(b1);
				this.Table_List.Rows[no_row].Cells[1].HorizontalAlign = HorizontalAlign.Center;
				this.Table_List.Rows[no_row].Cells[1].ColumnSpan = 3;
				this.Table_List.Rows[no_row].Cells[1].Controls.Add(btn1);
				this.Table_List.Rows[no_row].Cells[1].Controls.Add(btn2);
				this.Table_List.Rows[no_row].Cells[1].Controls.Add(btn3);
				this.Table_List.Rows[no_row].Cells[1].Controls.Add(new LiteralControl("&nbsp&nbsp"));
				this.Table_List.Rows[no_row].Cells[1].Controls.Add(b1);
				//this.Table_List.Rows[no_row].Cells[1].Controls.Add(new LiteralControl("<BR>"));
				//this.Table_List.Rows[no_row].Cells[1].Controls.Add(txtKet);
			}
			
		}

		private void r_CheckedChanged(object sender, EventArgs e)
		{
			RadioButton RDO_TYPE = (RadioButton) sender;
			string mId = RDO_TYPE.ID;
			string mCount = "";

			try
			{
				mCount = mId.Substring(16,2);
			}
			catch
			{
				mCount = mId.Substring(16,1);
			}

			//DropDownList DDL_AGENCY = (DropDownList) Table_List.FindControl("DDL_AGENCYID"+mCount);
			//DropDownList DDL_CO		= (DropDownList) Table_List.FindControl("DDL_CO"+mCount);

			RadioButton RDO_LA_APPRTYPE0 = (RadioButton) Table_List.FindControl("RDO_LA_APPRTYPE0"+mCount);
			RadioButton RDO_LA_APPRTYPE1 = (RadioButton) Table_List.FindControl("RDO_LA_APPRTYPE1"+mCount);
			RadioButton RDO_LA_APPRTYPE2 = (RadioButton) Table_List.FindControl("RDO_LA_APPRTYPE2"+mCount);
			DropDownList DDL_AGENCYID	 = (DropDownList) Table_List.FindControl("DDL_AGENCYID"+mCount);
			DropDownList DDL_LA_CREDITOPR = (DropDownList) Table_List.FindControl("DDL_CO"+mCount);
			TextBox TXT_LA_ASSIGNDATE_DAY	= (TextBox) Table_List.FindControl("TXT_LA_ASSIGNDATE_DAY"+mCount);
			DropDownList DDL_LA_ASSIGNDATE_MONTH	= (DropDownList) Table_List.FindControl("DDL_LA_ASSIGNDATE_MONTH"+mCount);
			TextBox TXT_LA_ASSIGNDATE_YEAR	= (TextBox) Table_List.FindControl("TXT_LA_ASSIGNDATE_YEAR"+mCount);
			TextBox TXT_CO	= (TextBox) Table_List.FindControl("TXT_CO"+mCount);
			
			if (RDO_LA_APPRTYPE0.Checked)
			{
				DDL_AGENCYID.Enabled		= false;
				DDL_AGENCYID.SelectedValue	= "";
				DDL_LA_CREDITOPR.Enabled	= true;
				TXT_LA_ASSIGNDATE_DAY.ReadOnly	= false;
				DDL_LA_ASSIGNDATE_MONTH.Enabled	= true;
				TXT_LA_ASSIGNDATE_YEAR.ReadOnly	= false;
				DDL_AGENCYID.CssClass			= "";
				try {
					DDL_LA_CREDITOPR.SelectedValue	= TXT_CO.Text;
				} 
				catch (ArgumentOutOfRangeException) {
					//DDL_LA_CREDITOPR.SelectedValue = "";					
					conn.QueryString = "select SU_BRANCH from SCUSER where userid = '" + TXT_CO.Text + "'";
					conn.ExecuteQuery();
					DDL_LA_CREDITOPR.SelectedValue = conn.GetFieldValue("SU_BRANCH");
				}
				TXT_LA_ASSIGNDATE_DAY.Text		= tool.FormatDate_Day(DateTime.Now.ToString());
				DDL_LA_ASSIGNDATE_MONTH.SelectedValue	= tool.FormatDate_Month(DateTime.Now.ToString());
				TXT_LA_ASSIGNDATE_YEAR.Text		= tool.FormatDate_Year(DateTime.Now.ToString());
				DDL_LA_CREDITOPR.CssClass		= "mandatory";
				TXT_LA_ASSIGNDATE_DAY.CssClass	= "mandatory";
				DDL_LA_ASSIGNDATE_MONTH.CssClass= "mandatory";
				TXT_LA_ASSIGNDATE_YEAR.CssClass	= "mandatory";
			}
			else if (RDO_LA_APPRTYPE1.Checked)
			{
				DDL_AGENCYID.Enabled		= true;
				DDL_LA_CREDITOPR.Enabled	= true;
				TXT_LA_ASSIGNDATE_DAY.ReadOnly	= false;
				DDL_LA_ASSIGNDATE_MONTH.Enabled	= true;
				TXT_LA_ASSIGNDATE_YEAR.ReadOnly	= false;			
				DDL_AGENCYID.CssClass			= "";
				try {
					DDL_LA_CREDITOPR.SelectedValue	= TXT_CO.Text;
				} 
				catch (ArgumentOutOfRangeException) {
					//DDL_LA_CREDITOPR.SelectedValue	= "";
					conn.QueryString = "select SU_BRANCH from SCUSER where userid = '" + TXT_CO.Text + "'";
					conn.ExecuteQuery();
					DDL_LA_CREDITOPR.SelectedValue = conn.GetFieldValue("SU_BRANCH");
				}
				TXT_LA_ASSIGNDATE_DAY.Text		= tool.FormatDate_Day(DateTime.Now.ToString());
				DDL_LA_ASSIGNDATE_MONTH.SelectedValue	= tool.FormatDate_Month(DateTime.Now.ToString());
				TXT_LA_ASSIGNDATE_YEAR.Text		= tool.FormatDate_Year(DateTime.Now.ToString());
				DDL_LA_CREDITOPR.CssClass		= "mandatory";
				TXT_LA_ASSIGNDATE_DAY.CssClass	= "mandatory";
				DDL_LA_ASSIGNDATE_MONTH.CssClass= "mandatory";
				TXT_LA_ASSIGNDATE_YEAR.CssClass	= "mandatory";
			}
			else if (RDO_LA_APPRTYPE2.Checked)
			{
				DDL_AGENCYID.Enabled		= false;
				DDL_AGENCYID.SelectedValue	= "";
				DDL_LA_CREDITOPR.Enabled	= false;
				DDL_LA_CREDITOPR.SelectedValue	= "";
				TXT_LA_ASSIGNDATE_DAY.ReadOnly	= true;
				TXT_LA_ASSIGNDATE_DAY.Text		= "";
				DDL_LA_ASSIGNDATE_MONTH.Enabled	= false;
				DDL_LA_ASSIGNDATE_MONTH.SelectedValue	= "";
				TXT_LA_ASSIGNDATE_YEAR.ReadOnly	= true;
				TXT_LA_ASSIGNDATE_YEAR.Text		= "";
				DDL_AGENCYID.CssClass			= "";
				DDL_LA_CREDITOPR.CssClass		= "";
				TXT_LA_ASSIGNDATE_DAY.CssClass	= "";
				DDL_LA_ASSIGNDATE_MONTH.CssClass= "";
				TXT_LA_ASSIGNDATE_YEAR.CssClass	= "";
			}
		}

		private void BTN_PROCESS_Click(object sender, System.EventArgs e)
		{
			Button BTN = (Button) sender;
			string bId = BTN.ID;
			string idx = bId.Substring(11);

			TextBox TXT_CL_SEQ, TXT_LA_ASSIGNDATE_DAY, TXT_LA_ASSIGNDATE_YEAR;
			RadioButton RDO_LA_APPRTYPE0, RDO_LA_APPRTYPE1, RDO_LA_APPRTYPE2, RDO_LA_APPRKHUSUS0, RDO_LA_APPRKHUSUS1;
			DropDownList DDL_LA_CREDITOPR, DDL_AGENCYID, DDL_LA_ASSIGNDATE_MONTH;
			Label LBL_REQAPPRAISAL;
			string LA_APPRTYPE, LA_APPRKHUSUS;

			TXT_CL_SEQ = (TextBox) Table_List.FindControl("TXT_CL_SEQ"+idx);
			RDO_LA_APPRTYPE0 = (RadioButton) Table_List.FindControl("RDO_LA_APPRTYPE0"+idx);
			RDO_LA_APPRTYPE1 = (RadioButton) Table_List.FindControl("RDO_LA_APPRTYPE1"+idx);
			RDO_LA_APPRTYPE2 = (RadioButton) Table_List.FindControl("RDO_LA_APPRTYPE2"+idx);
			DDL_AGENCYID	 = (DropDownList) Table_List.FindControl("DDL_AGENCYID"+idx);
			DDL_LA_CREDITOPR = (DropDownList) Table_List.FindControl("DDL_CO"+idx);
			TXT_LA_ASSIGNDATE_DAY	= (TextBox) Table_List.FindControl("TXT_LA_ASSIGNDATE_DAY"+idx);
			DDL_LA_ASSIGNDATE_MONTH	= (DropDownList) Table_List.FindControl("DDL_LA_ASSIGNDATE_MONTH"+idx);
			TXT_LA_ASSIGNDATE_YEAR	= (TextBox) Table_List.FindControl("TXT_LA_ASSIGNDATE_YEAR"+idx);
			LBL_REQAPPRAISAL	= (Label) Table_List.FindControl("LBL_REQAPPRAISAL"+idx);
			RDO_LA_APPRKHUSUS0 = (RadioButton) Table_List.FindControl("RDO_LA_APPRKHUSUS0"+idx);
			RDO_LA_APPRKHUSUS1 = (RadioButton) Table_List.FindControl("RDO_LA_APPRKHUSUS1"+idx);

			
			/// Before process begins, check first mandatory fields on collateral form that's still empty
			/// 
			conn.QueryString = "exec APPRAISAL_CEKCOLLMANDATORYFLD '" + LBL_AP_REGNO.Text + "', '" + TXT_CL_SEQ.Text + "'";
			conn.ExecuteQuery();

			if (conn.GetFieldValue("ISCOMPLETE") == "0") 
			{
				GlobalTools.popMessage(this, "Data Jaminan Ada Yang Belum Lengkap !");
				return;
			}



			LA_APPRKHUSUS = "0";
			if (RDO_LA_APPRKHUSUS1.Checked)
				LA_APPRKHUSUS = "1";

			LA_APPRTYPE = "0";
			if (RDO_LA_APPRTYPE1.Checked)
			{	
				LA_APPRTYPE = "1";
			}
			else if (RDO_LA_APPRTYPE2.Checked)
			{
				LA_APPRTYPE = "2";
			}

			//---pengecekan mandatory------
			//if (LA_APPRTYPE == "1" && DDL_AGENCYID.SelectedValue.Trim() == "")
				//Tools.popMessage(this,"Agency Tidak Boleh Kosong");
			//else 
			if ((LA_APPRTYPE == "0" || LA_APPRTYPE == "1") && DDL_LA_CREDITOPR.SelectedValue.Trim() == "")
				Tools.popMessage(this,"Credit Operations Tidak Boleh Kosong");
			else if ((LA_APPRTYPE == "0" || LA_APPRTYPE == "1") && TXT_LA_ASSIGNDATE_DAY.Text.Trim() == "")
				Tools.popMessage(this,"Tanggal Tidak Boleh Kosong");
			else if ((LA_APPRTYPE == "0" || LA_APPRTYPE == "1") && DDL_LA_ASSIGNDATE_MONTH.SelectedValue.Trim() == "")
				Tools.popMessage(this,"Bulan Tidak Boleh Kosong");
			else if ((LA_APPRTYPE == "0" || LA_APPRTYPE == "1") && TXT_LA_ASSIGNDATE_YEAR.Text.Trim() == "")
				Tools.popMessage(this,"Tahun Tidak Boleh Kosong");
			else
			{
				try 
				{
					conn.QueryString = "exec VERIFICATION_ASSIGNMENT '" +Request.QueryString["regno"]+ "', '" +Request.QueryString["curef"]+ "', "+
						tool.ConvertNum(TXT_CL_SEQ.Text)+", '" +DDL_LA_CREDITOPR.SelectedValue+ "', '" +DDL_AGENCYID.SelectedValue+ "', " +
						tool.ConvertDate(TXT_LA_ASSIGNDATE_DAY.Text,DDL_LA_ASSIGNDATE_MONTH.SelectedValue,TXT_LA_ASSIGNDATE_YEAR.Text)+ ",'" +
						LA_APPRTYPE+ "', '1','" +LBL_REQAPPRAISAL.Text+ "', '" +LA_APPRKHUSUS+ "'";
					conn.ExecuteNonQuery();
				} 
				catch (NullReferenceException) 
				{
					GlobalTools.popMessage(this, "Connection Error !");
					Response.Redirect("../Login.aspx?expire=1");
				} 
				ViewListCollateral();
			}

			////////////////////////////////////////////////////////////
			/// audit trail
			try
			{
				conn.QueryString = "SP_AUDITTRAIL_APP '" + 
					Request.QueryString["regno"] + "',null,null,null,'" + 
					Request.QueryString["curef"] + "','" + 
					Request.QueryString["tc"] + "','Proses appraisal entry '," + 
					"'" + DDL_LA_CREDITOPR.SelectedItem.Text + "'" + ",'" +  
					Session["userid"].ToString() + "',null,null";
				conn.ExecuteNonQuery();
			}
			catch
			{
			}



		}

		private void BTN_CANCEL_Click(object sender, System.EventArgs e)
		{
			Button BTN = (Button) sender;
			string bId = BTN.ID;
			string idx = bId.Substring(10);
			TextBox TXT_CL_SEQ;

			TXT_CL_SEQ = (TextBox) Table_List.FindControl("TXT_CL_SEQ"+idx);
			conn.QueryString = "exec VERIFICATION_ASSIGNMENT '" +Request.QueryString["regno"]+ "', '" +Request.QueryString["curef"]+ "', "+
				tool.ConvertNum(TXT_CL_SEQ.Text)+", '', '', '','', '2','1',''";
			//conn.ExecuteNonQuery();
			conn.ExecuteQuery();

			if (conn.GetFieldValue("STATUSPROC").ToString().Trim().Length > 0) 
			{
				GlobalTools.popMessage(this, conn.GetFieldValue("STATUSPROC").ToString());
				return;
			}

			//ahmad: delete appr_list
			double clseq = Double.Parse(idx) + 1;
			conn.QueryString = "sp_appr_list 'Delete','" + Request.QueryString["regno"] + "','" + 
				Request.QueryString["curef"] + "', '" + 
				TXT_CL_SEQ.Text.Trim() + "','',''";;
			conn.ExecuteNonQuery();

			ViewListCollateral();
			
			////////////////////////////////////////////////////////////
			/// audit trail
			try
			{
				conn.QueryString = "SP_AUDITTRAIL_APP '" + 
					Request.QueryString["regno"] + "',null,null,null,'" + 
					Request.QueryString["curef"] + "','" + 
					Request.QueryString["tc"] + "','Cancel appraisal entry ',"+ 
					"null" + ",'" +  
					Session["userid"].ToString() + "',null,null";
				conn.ExecuteNonQuery();
			}
			catch
			{
			}
		}

		private void BTN_REAPPRAISED_Click(object sender, System.EventArgs e)
		{
			Button BTN = (Button) sender;
			string bId = BTN.ID;
			string idx = bId.Substring(10);
			TextBox TXT_CL_SEQ;
			TXT_CL_SEQ = (TextBox) Table_List.FindControl("TXT_CL_SEQ"+idx);
			
			conn.QueryString = "update APPLICATION set AP_APPRSTATUS = '0' where AP_REGNO = '"+Request.QueryString["regno"]+"'";
			conn.ExecuteNonQuery();

			conn.QueryString = "update LISTASSIGNMENT set LA_APPRSTATUS = '0', LA_CREDITOPR = NULL, OFFICERSEQ = NULL  where AP_REGNO = '"+Request.QueryString["regno"]+"' and CU_REF = '"+
								Request.QueryString["curef"]+"' and  CL_SEQ = "+tool.ConvertNum(TXT_CL_SEQ.Text);
			conn.ExecuteNonQuery();

			//ahmad: delete appr_list
			double clseq = Double.Parse(idx) + 1;
			conn.QueryString = "sp_appr_list 'Delete','" + Request.QueryString["regno"] + "','" + Request.QueryString["curef"] + "','"+TXT_CL_SEQ.Text.Trim()+"','',''";
			conn.ExecuteNonQuery();
			
			//conn.QueryString = "exec VERIFICATION_ASSIGNMENT '" +Request.QueryString["regno"]+ "', '" +Request.QueryString["curef"]+ "', "+
				//tool.ConvertNum(TXT_CL_SEQ.Text)+", '', '', '','', '3','1',''";
			//conn.ExecuteNonQuery();
			ViewListCollateral();
			
			////////////////////////////////////////////////////////////
			/// audit trail
			try
			{
				conn.QueryString = "SP_AUDITTRAIL_APP '" + 
					Request.QueryString["regno"] + "',null,null,null,'" + 
					Request.QueryString["curef"] + "','" + 
					Request.QueryString["tc"] + "','Re-appraised entry ',"+ 
					"null" + ",'" +  
					Session["userid"].ToString() + "',null,null";
				conn.ExecuteNonQuery();
			}
			catch
			{
			}

		}
		
		private void ra_CheckedChanged(object sender, EventArgs e)
		{
			RadioButton RDO_TYPE = (RadioButton) sender;
			string mId = RDO_TYPE.ID;
			string mCount = mId.Substring(18,1);

			Button BTNPRINT = (Button) Table_List.FindControl("BTN_PRINT"+mCount);
			RadioButton	RDO_LA_APPRKHUSUS0 = (RadioButton) Table_List.FindControl("RDO_LA_APPRKHUSUS0"+mCount);

			RadioButton	RDO_LA_APPRTYPE0 = (RadioButton) Table_List.FindControl("RDO_LA_APPRTYPE0"+mCount);
			RadioButton	RDO_LA_APPRTYPE1 = (RadioButton) Table_List.FindControl("RDO_LA_APPRTYPE1"+mCount);
			RadioButton	RDO_LA_APPRTYPE2 = (RadioButton) Table_List.FindControl("RDO_LA_APPRTYPE2"+mCount);
			DropDownList DDL_AGENCYID	 = (DropDownList) Table_List.FindControl("DDL_AGENCYID"+mCount);
			DropDownList DDL_LA_CREDITOPR = (DropDownList) Table_List.FindControl("DDL_CO"+mCount);
			TextBox TXT_LA_ASSIGNDATE_DAY	= (TextBox) Table_List.FindControl("TXT_LA_ASSIGNDATE_DAY"+mCount);
			DropDownList DDL_LA_ASSIGNDATE_MONTH	= (DropDownList) Table_List.FindControl("DDL_LA_ASSIGNDATE_MONTH"+mCount);
			TextBox TXT_LA_ASSIGNDATE_YEAR	= (TextBox) Table_List.FindControl("TXT_LA_ASSIGNDATE_YEAR"+mCount);

			if (RDO_LA_APPRKHUSUS0.Checked)
			{
				BTNPRINT.Visible	= false;
				RDO_LA_APPRTYPE0.Enabled	= true;
				RDO_LA_APPRTYPE2.Enabled	= true;
			}
			else
			{
				BTNPRINT.Visible	= true;
				RDO_LA_APPRTYPE0.Enabled	= false;
				RDO_LA_APPRTYPE2.Enabled	= false;
				RDO_LA_APPRTYPE0.Checked	= false;
				RDO_LA_APPRTYPE2.Checked	= false;
				RDO_LA_APPRTYPE1.Checked	= true;
				DDL_AGENCYID.Enabled		= true;
				//DDL_LA_CREDITOPR.Enabled	= true;
				TXT_LA_ASSIGNDATE_DAY.ReadOnly	= false;
				DDL_LA_ASSIGNDATE_MONTH.Enabled	= true;
				TXT_LA_ASSIGNDATE_YEAR.ReadOnly	= false;			
				DDL_AGENCYID.CssClass			= "";
				DDL_LA_CREDITOPR.CssClass		= "mandatory";
				TXT_LA_ASSIGNDATE_DAY.CssClass	= "mandatory";
				DDL_LA_ASSIGNDATE_MONTH.CssClass= "mandatory";
				TXT_LA_ASSIGNDATE_YEAR.CssClass	= "mandatory";
			}
		}

		private void b1_OnClick(object sender, EventArgs e)
		{
			Button BTN = (Button) sender;
			string bId = BTN.ID;
			string idx = bId.Substring(9);

			HyperLink h = (HyperLink) Table_List.FindControl("COLL_LINK"+idx);
			DropDownList ddl = (DropDownList) Table_List.FindControl("DDL_AGENCYID" + idx);
			TextBox txtseq = (TextBox) Table_List.FindControl("TXT_CL_SEQ" + idx);

			if (ddl.SelectedValue.ToString().Trim() == "")
				Tools.popMessage(this,"Data Agency Tidak Boleh Kosong !");
			else
			{
				string seq = txtseq.Text;
				string agency_id = ddl.SelectedValue.ToString().Trim();
				string cu_ref = this.LBL_CU_REF.Text.ToString().Trim();
				string regno = this.LBL_AP_REGNO.Text.ToString().Trim();
				Response.Write("<script language='javascript'>window.open('../CreditOperations/CoverNote/PenugasanAgunan.aspx?seq=" + seq + "&regno=" + regno + "&agency_id=" + agency_id + "&cu_ref=" + cu_ref + "','Penugasan_Agunan','status=no,scrollbars=yes,width=800,height=600');</script>");
			}

		}
	
	}
}
