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

namespace SME.TargetCustomer
{
	/// <summary>
	/// Summary description for TargetCustomerEntry.
	/// </summary>
	public partial class TargetCustomerEntry : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.TextBox TXT_CU_CIF_C;
		protected Connection conn;
		protected Tools tool = new Tools();
        public string popUp = "";
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			conn = (Connection) Session["Connection"];

			if (!Logic.AllowAccess(Session["GroupID"].ToString(), Request.QueryString["mc"], conn))
				Response.Redirect("/SME/Restricted.aspx");

			if (!IsPostBack)
			{
				TXT_TRG_CU_REF.Text = Request.QueryString["trgcuref"];
				
				conn.QueryString = "SELECT CUSTTYPEID, CUSTTYPEDESC FROM RFCUSTOMERTYPE WHERE ACTIVE = '1'";
				conn.ExecuteQuery();
				for (int i = 0; i < conn.GetRowCount(); i++)
					RDO_RFCUSTOMERTYPE.Items.Add(new ListItem(conn.GetFieldValue(i,1), conn.GetFieldValue(i,0)));

				RDO_RFCUSTOMERTYPE.SelectedIndex = 0;
				TR_PERSONAL.Visible = false;
				TR_COMPANY.Visible = true;
				TR_PERSONAL2.Visible = false;
				TR_COMPANY2.Visible = true;
				
				DDL_CU_DOB_MONTH.Items.Add(new ListItem("- SELECT -", ""));
				DDL_TGLPROSES_MONTH.Items.Add(new ListItem("- SELECT -", ""));
				
				for (int i = 1; i <= 12; i++)
				{
					DDL_CU_DOB_MONTH.Items.Add(new ListItem(DateAndTime.MonthName(i, false), i.ToString()));
					DDL_TGLPROSES_MONTH.Items.Add(new ListItem(DateAndTime.MonthName(i, false), i.ToString()));
					DDL_TERM_DATE_MONTH.Items.Add(new ListItem(DateAndTime.MonthName(i, false), i.ToString()));
				}

				GlobalTools.fillRefList(DDL_CU_COMPTYPE, "SELECT COMPTYPEID, COMPTYPEDESC FROM RFCOMPTYPE WHERE ACTIVE='1'", false, conn);
				GlobalTools.fillRefList(DDL_CU_JENISINDUSTRI, "SELECT INDCLASS_CODE, INDCLASS_DESC, ACTIVE  FROM VW_TARGETCUST_RFINDUSTRYCLASS WHERE ACTIVE = '1' ORDER BY INDCLASS_SEQ", false, conn);
				GlobalTools.fillRefList(DDL_TARGETUNIT, "SELECT TARGETUNIT_CODE, TARGETUNIT_DESC, ACTIVE FROM VW_TARGETCUST_REFTARGETUNIT WHERE ACTIVE = '1' ORDER BY TARGETUNIT_SEQ", false, conn);
				GlobalTools.fillRefList(DDL_TARGETLIMITCUR, "SELECT CURRENCYID, CURRENCYDESC FROM VW_TARGETCUST_RFCURRENCY WHERE ACTIVE = '1' ORDER BY CURRENCYSEQ", false, conn);

				GlobalTools.fillRefList(DDL_JENISKREDIT, "SELECT JENISKREDIT_CODE, JENISKREDIT_DESC, ACTIVE  FROM VW_TARGETCUST_RFJENISKREDIT WHERE ACTIVE = '1' ORDER BY JENISKREDIT_SEQ", false, conn);
				GlobalTools.fillRefList(DDL_SEGMENLIMIT, "SELECT SEGMENLIMIT_CODE, SEGMENLIMIT_DESC, ACTIVE  FROM VW_TARGETCUST_RFSEGMENLIMIT WHERE ACTIVE = '1' ORDER BY SEGMENLIMIT_SEQ", false, conn);

				DDL_SEKTOREKONOMI1.Items.Add(new ListItem("- PILIH -", ""));
				conn.QueryString = "select bm_code,bm_code + ' - ' + bm_desc as bmsektorDESC from RFbmsektorekonomi where ACTIVE='1' order by bm_code";
				conn.ExecuteQuery();
				for (int i = 0; i < conn.GetRowCount(); i++)
					DDL_SEKTOREKONOMI1.Items.Add(new ListItem(conn.GetFieldValue(i,1), conn.GetFieldValue(i,0)));

				if (Request.QueryString["newtrg"]!="1")
				{
					RDO_RFCUSTOMERTYPE.Enabled	= false;
					ViewData();
					ViewDataBooking();
				}

				if (Request.QueryString["trg"] == "1") //Entry
				{
					TR_FORWARD.Visible = true;
					TR_APRVBU.Visible = false;
					TR_APRVRISK.Visible = false;

					GlobalTools.fillRefList(DDL_APRV, "SELECT * FROM VW_TARGETCUST_APRVUSER WHERE USERID = '" + Session["UserID"].ToString() + "' ORDER BY SEQ", false, conn);
					DDL_APRV.Items.RemoveAt(0);
				}
				else if (Request.QueryString["trg"] == "2") //Approval BU
				{
					TR_PERSONAL2.Visible = false;
					TR_COMPANY2.Visible = false;
					TR_FORWARD.Visible = false;
					TR_APRVBU.Visible = true;
					TR_APRVRISK.Visible = false;

					GlobalTools.fillRefList(DDL_ASSIGNBU, "SELECT * FROM VW_TARGETCUST_APRVFWDBU WHERE USERID = '" + Session["UserID"].ToString() + "' ORDER BY SEQ", false, conn);
					DDL_ASSIGNBU.Items.RemoveAt(0);
				}
				else if (Request.QueryString["trg"] == "3") //Approval Risk
				{
					TR_PERSONAL2.Visible = false;
					TR_COMPANY2.Visible = false;
					TR_FORWARD.Visible = false;
					TR_APRVBU.Visible = false;
					TR_APRVRISK.Visible = true;

					GlobalTools.fillRefList(DDL_ASSIGNRISK, "SELECT * FROM VW_TARGETCUST_APRVFWDRISK WHERE USERID = '" + Session["UserID"].ToString() + "' ORDER BY SEQ", false, conn);
					DDL_ASSIGNRISK.Items.RemoveAt(0);
				}
				else
				{
					TR_PERSONAL2.Visible = false;
					TR_COMPANY2.Visible = false;
					TR_FORWARD.Visible = false;
					TR_APRVBU.Visible = false;
					TR_APRVRISK.Visible = false;
				}
			}

			ViewMenu();

            BTN_SAVE_P.Attributes.Add("onclick", "if(!cek_mandatory(document.getElementById('Form1'))){return false;};");
            BTN_SAVE_C.Attributes.Add("onclick", "if(!cek_mandatory2(document.getElementById('Form1'))){return false;};");
			BTN_UPDATE.Attributes.Add("onclick","if(!update()){return false;};");
			BTN_APRVBU.Attributes.Add("onclick","if(!approve()){return false;};");
			BTN_APRVRISK.Attributes.Add("onclick","if(!approve()){return false;};");
		}

		private void SetCustomerType(string custType)
		{
			if (custType == "01")
			{
				TR_COMPANY2.Visible = true;
				TR_PERSONAL2.Visible = false;
				TR_COMPANY.Visible = true;
				TR_PERSONAL.Visible = false;

				DDL_CU_JENISINDUSTRI.CssClass = "mandatory2";
				TXT_TGLPROSES_DAY.CssClass = "mandatory2";
				DDL_TGLPROSES_MONTH.CssClass = "mandatory2";
				TXT_TGLPROSES_YEAR.CssClass = "mandatory2";
				DDL_TARGETUNIT.CssClass = "mandatory2";
				//DDL_TARGETUSER.CssClass = "mandatory2";
				//TXT_IACREMARK.CssClass = "mandatory2";
			}
			else if (custType == "02")
			{
				TR_COMPANY2.Visible = false;
				TR_PERSONAL2.Visible = true;
				TR_COMPANY.Visible = false;
				TR_PERSONAL.Visible = true;

				DDL_CU_JENISINDUSTRI.CssClass = "mandatory";
				TXT_TGLPROSES_DAY.CssClass = "mandatory";
				DDL_TGLPROSES_MONTH.CssClass = "mandatory";
				TXT_TGLPROSES_YEAR.CssClass = "mandatory";
				DDL_TARGETUNIT.CssClass = "mandatory";
				//DDL_TARGETUSER.CssClass = "mandatory";
				//TXT_IACREMARK.CssClass = "mandatory";
			}
		}

		private void ViewData()
		{
			conn.QueryString = "SELECT * FROM VW_TARGETCUST_CUSTOMER WHERE TRG_CU_REF = '" + Request.QueryString["trgcuref"] + "'";
			conn.ExecuteQuery();
			string cust_type = conn.GetFieldValue("CU_CUSTTYPEID");

			TXT_CONTACTPERSON.Text = conn.GetFieldValue("CONTACTPERSON");
			DDL_JENISKREDIT.SelectedValue = conn.GetFieldValue("JENISKREDIT");
			DDL_SEGMENLIMIT.SelectedValue = conn.GetFieldValue("SEGMENLIMIT");
			TXT_KETERANGAN.Text = conn.GetFieldValue("KETERANGAN");

			try {DDL_CU_JENISINDUSTRI.SelectedValue = conn.GetFieldValue("INDUSTRYCODE");}
			catch {}
			TXT_TGLPROSES_DAY.Text = tool.FormatDate_Day(conn.GetFieldValue("TARGETDATE"));
			try {DDL_TGLPROSES_MONTH.SelectedValue = tool.FormatDate_Month(conn.GetFieldValue("TARGETDATE"));} 
			catch {}
			TXT_TGLPROSES_YEAR.Text = tool.FormatDate_Year(conn.GetFieldValue("TARGETDATE"));
			try {DDL_TARGETUNIT.SelectedValue = conn.GetFieldValue("TARGETUNIT");}
			catch {}
			try {DDL_TARGETLIMITCUR.SelectedValue = conn.GetFieldValue("TARGETLIMITCUR");}
			catch {}
			TXT_TARGETLIMITVAL.Text = tool.MoneyFormat(conn.GetFieldValue("TARGETLIMITVAL"));
			TXT_TARGETLIMITRATE.Text = tool.MoneyFormat(conn.GetFieldValue("TARGETLIMITRATE"));
			TXT_TARGETLIMIT.Text = tool.MoneyFormat(conn.GetFieldValue("TARGETLIMIT"));
			TXT_IACREMARK.Text = conn.GetFieldValue("IACREMARK");
			string trguser = conn.GetFieldValue("TARGETUSER");
			string se1 = conn.GetFieldValue("SEKTOREKONOMI1");
			string se2 = conn.GetFieldValue("SEKTOREKONOMI2");
			string se3 = conn.GetFieldValue("SEKTOREKONOMI3");
			string se4 = conn.GetFieldValue("SEKTOREKONOMI4");
			
			DDL_TARGETUSER.Items.Clear();
			GlobalTools.fillRefList(DDL_TARGETUSER, "SELECT TARGETUSER_CODE, TARGETUSER_DESC, TARGETUNIT_CODE, ACTIVE FROM VW_TARGETCUST_REFTARGETUSER WHERE ACTIVE = '1' AND TARGETUNIT_CODE = '" + DDL_TARGETUNIT.SelectedValue + "' ORDER BY TARGETUSER_DESC", false, conn);
			try {DDL_TARGETUSER.SelectedValue = trguser;} 
			catch{}

			try {DDL_SEKTOREKONOMI1.SelectedValue = se1;}
			catch {}
			//sub sektor
			GlobalTools.fillRefList(DDL_SEKTOREKONOMI2, "select BMSUB_CODE, BMSUB_DESC from RFBMSUBSEKTOREKONOMI where ACTIVE = '1' and BM_CODE = '" + se1 + "'", true, conn);
			try {DDL_SEKTOREKONOMI2.SelectedValue = se2;}
			catch {}
			//sub sub sektor
			GlobalTools.fillRefList(DDL_SEKTOREKONOMI3, "select BMSUBSUB_CODE, BMSUBSUB_DESC from RFBMSUBSUBSEKTOREKONOMI where ACTIVE = '1' and BMSUB_CODE = '" + se2 + "'", true, conn);
			try {DDL_SEKTOREKONOMI3.SelectedValue = se3;}
			catch {}
			//bi sektor
			GlobalTools.fillRefList(DDL_SEKTOREKONOMI4, "select BI_SEQ, BI_DESC from RFBICODE where BG_GROUP = '3' and BI_SEQ = '" + se4 + "'", true, conn);
			try{DDL_SEKTOREKONOMI4.SelectedValue = se4;}
			catch{DDL_SEKTOREKONOMI4.SelectedValue="";}
			conn.ClearData();

			if (cust_type.Trim() == "02")
			{
				TR_COMPANY.Visible	= false;
				TR_PERSONAL.Visible	= true;
				TR_COMPANY2.Visible = false;
				TR_PERSONAL2.Visible = true;
				
				RDO_RFCUSTOMERTYPE.SelectedValue	= "02";
				
				conn.QueryString = "SELECT * FROM VW_TARGETCUST_PERSONAL WHERE TRG_CU_REF = '" + Request.QueryString["trgcuref"] + "'";
				conn.ExecuteQuery();

				if (conn.GetRowCount() > 0)
				{
					TXT_CU_NPWP.Text = conn.GetFieldValue("CU_NPWP");
					
					TXT_CU_FIRSTNAME.Text = conn.GetFieldValue("CU_FIRSTNAME");
					TXT_CU_MIDDLENAME.Text = conn.GetFieldValue("CU_MIDDLENAME");
					TXT_CU_LASTNAME.Text = conn.GetFieldValue("CU_LASTNAME");
					TXT_CU_ADDR1.Text = conn.GetFieldValue("CU_ADDR1");
					TXT_CU_ADDR2.Text = conn.GetFieldValue("CU_ADDR2");
					TXT_CU_ADDR3.Text = conn.GetFieldValue("CU_ADDR3");
					TXT_CU_CITY.Text = conn.GetFieldValue("CU_CITYNAME");
					TXT_CU_ZIPCODE.Text = conn.GetFieldValue("CU_ZIPCODE");
					TXT_CU_DOB_DAY.Text = tool.FormatDate_Day(conn.GetFieldValue("CU_DOB"));
					try {DDL_CU_DOB_MONTH.SelectedValue = tool.FormatDate_Month(conn.GetFieldValue("CU_DOB"));} 
					catch{}
					TXT_CU_DOB_YEAR.Text = tool.FormatDate_Year(conn.GetFieldValue("CU_DOB"));
					TXT_CU_IDCARDNUM.Text = conn.GetFieldValue("CU_IDCARDNUM");
				}
			}
			else if (cust_type.Trim() == "01")
			{
				TR_COMPANY.Visible	= true;
				TR_PERSONAL.Visible	= false;
				TR_COMPANY2.Visible = true;
				TR_PERSONAL2.Visible = false;
				
				RDO_RFCUSTOMERTYPE.SelectedValue	= "01";
				
				conn.QueryString = "SELECT * FROM VW_TARGETCUST_COMPANY WHERE TRG_CU_REF = '" + Request.QueryString["trgcuref"] + "'";
				conn.ExecuteQuery();

				if (conn.GetRowCount() > 0)
				{
					TXT_CU_COMPNPWP.Text = conn.GetFieldValue("CU_NPWP");
					
					try {DDL_CU_COMPTYPE.SelectedValue = conn.GetFieldValue("CU_COMPTYPE");}
					catch {}
					TXT_CU_COMPNAME.Text = conn.GetFieldValue("CU_COMPNAME");
					TXT_CU_COMPADDR1.Text = conn.GetFieldValue("CU_COMPADDR1");
					TXT_CU_COMPADDR2.Text = conn.GetFieldValue("CU_COMPADDR2");
					TXT_CU_COMPADDR3.Text = conn.GetFieldValue("CU_COMPADDR3");
					TXT_CU_COMPCITY.Text = conn.GetFieldValue("CU_COMPCITYNAME");
					TXT_CU_COMPZIPCODE.Text = conn.GetFieldValue("CU_COMPZIPCODE");
				}
			}
		}

		private void ViewDataBooking()
		{
			conn.QueryString = "SELECT * FROM VW_TARGETCUST_RENCANABOOKING WHERE TRG_CU_REF = '" + Request.QueryString["trgcuref"] + "' ORDER BY TERM_DATE";
			conn.ExecuteQuery();
			
			DataTable dt = new DataTable();
			dt = conn.GetDataTable().Copy();
			DG_GRID.DataSource = dt;
			try 
			{
				DG_GRID.DataBind();
			} 
			catch 
			{
				DG_GRID.CurrentPageIndex = 0;
				DG_GRID.DataBind();
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
							strtemp = "trgcuref="+Request.QueryString["trgcuref"]+"&tc="+Request.QueryString["tc"]+"&trg="+Request.QueryString["trg"];
						else	strtemp = "trgcuref="+Request.QueryString["trgcuref"]+"&mc="+Request.QueryString["mc"]+"&tc="+Request.QueryString["tc"]+"&trg="+Request.QueryString["trg"];
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
			this.DG_GRID.ItemCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.DG_GRID_ItemCommand);
			this.DG_GRID.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.DG_GRID_PageIndexChanged);

		}
		#endregion

		protected void DDL_TARGETUNIT_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			GlobalTools.fillRefList(DDL_TARGETUSER, "SELECT TARGETUSER_CODE, TARGETUSER_DESC, TARGETUNIT_CODE, ACTIVE FROM VW_TARGETCUST_REFTARGETUSER WHERE ACTIVE = '1' AND TARGETUNIT_CODE = '" + DDL_TARGETUNIT.SelectedValue + "' ORDER BY TARGETUSER_DESC", false, conn);
		}

		protected void RDO_RFCUSTOMERTYPE_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			SetCustomerType(RDO_RFCUSTOMERTYPE.SelectedValue);
			return;
		}

		protected void BTN_SAVE_P_Click(object sender, System.EventArgs e)
		{
			try
			{
				conn.QueryString  = "EXEC TARGETCUST_SAVEPERSONAL '" + Request.QueryString["trgcuref"] + "', '" + 
					RDO_RFCUSTOMERTYPE.SelectedValue + "', '" +
					TXT_CU_NPWP.Text + "', '" +
					DDL_CU_JENISINDUSTRI.SelectedValue + "', " +
					tool.ConvertDate(TXT_TGLPROSES_DAY.Text, DDL_TGLPROSES_MONTH.SelectedValue, TXT_TGLPROSES_YEAR.Text) + ", '" +
					DDL_TARGETUNIT.SelectedValue + "', '" +
					DDL_TARGETUSER.SelectedValue + "', '" +
					TXT_IACREMARK.Text + "', '" +
					TXT_CONTACTPERSON.Text + "', '" +
					DDL_SEKTOREKONOMI1.SelectedValue + "', '" +
					DDL_SEKTOREKONOMI2.SelectedValue + "', '" +
					DDL_SEKTOREKONOMI3.SelectedValue + "', '" +
					DDL_SEKTOREKONOMI4.SelectedValue + "', '" +
					DDL_JENISKREDIT.SelectedValue + "', '" +
					DDL_SEGMENLIMIT.SelectedValue + "', '" +
					TXT_KETERANGAN.Text + "', '" +
					DDL_TARGETLIMITCUR.SelectedValue + "', " +
					tool.ConvertFloat(TXT_TARGETLIMITVAL.Text) + ", " +
					tool.ConvertFloat(TXT_TARGETLIMITRATE.Text) + ", " +
					tool.ConvertFloat(TXT_TARGETLIMIT.Text) + ", '" +
					TXT_CU_FIRSTNAME.Text + "', '" +
					TXT_CU_MIDDLENAME.Text + "', '" +
					TXT_CU_LASTNAME.Text + "', '" +
					TXT_CU_ADDR1.Text + "', '" +
					TXT_CU_ADDR2.Text + "', '" +
					TXT_CU_ADDR3.Text + "', '" +
					LBL_CU_CITY.Text + "', '" +
					TXT_CU_ZIPCODE.Text + "', " +
					tool.ConvertDate(TXT_CU_DOB_DAY.Text, DDL_CU_DOB_MONTH.SelectedValue, TXT_CU_DOB_YEAR.Text) + ", '" +
					TXT_CU_IDCARDNUM.Text + "', '" +
					Session["UserID"].ToString() + "', '" +
                    Session["BranchID"].ToString() + "', '" +
					Request.QueryString["tc"] + "'";
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

		protected void BTN_SAVE_C_Click(object sender, System.EventArgs e)
		{
			try
			{
				conn.QueryString  = "EXEC TARGETCUST_SAVECOMPANY '" + Request.QueryString["trgcuref"] + "', '" + 
					RDO_RFCUSTOMERTYPE.SelectedValue + "', '" +
					TXT_CU_COMPNPWP.Text + "', '" +
					DDL_CU_JENISINDUSTRI.SelectedValue + "', " +
					tool.ConvertDate(TXT_TGLPROSES_DAY.Text, DDL_TGLPROSES_MONTH.SelectedValue, TXT_TGLPROSES_YEAR.Text) + ", '" +
					DDL_TARGETUNIT.SelectedValue + "', '" +
					DDL_TARGETUSER.SelectedValue + "', '" +
					TXT_IACREMARK.Text + "', '" +
					TXT_CONTACTPERSON.Text + "', '" +
					DDL_SEKTOREKONOMI1.SelectedValue + "', '" +
					DDL_SEKTOREKONOMI2.SelectedValue + "', '" +
					DDL_SEKTOREKONOMI3.SelectedValue + "', '" +
					DDL_SEKTOREKONOMI4.SelectedValue + "', '" +
					DDL_JENISKREDIT.SelectedValue + "', '" +
					DDL_SEGMENLIMIT.SelectedValue + "', '" +
					TXT_KETERANGAN.Text + "', '" +
					DDL_TARGETLIMITCUR.SelectedValue + "', " +
					tool.ConvertFloat(TXT_TARGETLIMITVAL.Text) + ", " +
					tool.ConvertFloat(TXT_TARGETLIMITRATE.Text) + ", " +
					tool.ConvertFloat(TXT_TARGETLIMIT.Text) + ", '" +
					DDL_CU_COMPTYPE.SelectedValue + "', '" +
					TXT_CU_COMPNAME.Text + "', '" +
					TXT_CU_COMPADDR1.Text + "', '" +
					TXT_CU_COMPADDR2.Text + "', '" +
					TXT_CU_COMPADDR3.Text + "', '" +
					LBL_CU_COMPCITY.Text + "', '" +
					TXT_CU_COMPZIPCODE.Text + "', '" +
					Session["UserID"].ToString() + "', '" +
                    Session["BranchID"].ToString() + "', '" +
					Request.QueryString["tc"] + "'";
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

		protected void BTN_SEARCHPERSONAL_Click(object sender, System.EventArgs e)
		{
			//Response.Write("<script language='javascript'>window.open('../InitialDataEntry/SearchZipcode.aspx?targetFormID=Form1&targetObjectID=TXT_CU_ZIPCODE','SearchZipcode','status=no,scrollbars=yes,width=420,height=200');</script>");
            Response.Write("<script language='javascript'>window.open('../InitialDataEntry/SearchZipcode.aspx?targetFormID=Form1&targetObjectID=TXT_CU_ZIPCODE&trgObjID2=TXT_CU_ADDR3&trgObjID3=TXT_CU_CITY&trgObjID4=LBL_CU_CITY','SearchZipcode','status=no,scrollbars=yes,width=640,height=480');</script>");
		}

		protected void BTN_SEARCHCOMP_Click(object sender, System.EventArgs e)
		{
			//Response.Write("<script language='javascript'>window.open('../InitialDataEntry/SearchZipcode.aspx?targetFormID=Form1&targetObjectID=TXT_CU_COMPZIPCODE','SearchZipcode','status=no,scrollbars=yes,width=420,height=200');</script>");
            Response.Write("<script language='javascript'>window.open('../InitialDataEntry/SearchZipcode.aspx?targetFormID=Form1&targetObjectID=TXT_CU_COMPZIPCODE&trgObjID2=TXT_CU_COMPADDR3&trgObjID3=TXT_CU_COMPCITY&trgObjID4=LBL_CU_COMPCITY','SearchZipcode','status=no,scrollbars=yes,width=420,height=200');</script>");
		}

		protected void TXT_CU_ZIPCODE_TextChanged(object sender, System.EventArgs e)
		{
			conn.QueryString = "select cityid, cityname, description from vw_zipcodecity where rtrim(ltrim(zipcode)) = '" + 
				TXT_CU_ZIPCODE.Text.Trim() + "' ";
			conn.ExecuteQuery();
			try
			{
				LBL_CU_CITY.Text = conn.GetFieldValue(0,0);
				TXT_CU_CITY.Text = conn.GetFieldValue(0,1);
                TXT_CU_ADDR3.Text = conn.GetFieldValue(0, 2);
			}
			catch
			{
				TXT_CU_ZIPCODE.Text = "";
				TXT_CU_CITY.Text = "";
				GlobalTools.popMessage(this, "Invalid Zipcode!");
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
				TXT_CU_COMPCITY.Text = conn.GetFieldValue(0,1);
                TXT_CU_COMPADDR3.Text = conn.GetFieldValue(0, 2);
			}
			catch
			{
				TXT_CU_COMPZIPCODE.Text = "";
				TXT_CU_COMPCITY.Text = "";
				GlobalTools.popMessage(this, "Invalid Zipcode!");
			}
		}

		protected void BTN_UPDATE_Click(object sender, System.EventArgs e)
		{
			try
			{
				conn.QueryString  = "EXEC TARGETCUST_FWDTOAPPROVAL '" + 
					Request.QueryString["trgcuref"] + "', '" + 
					DDL_APRV.SelectedValue + "', '" +
					Session["UserID"].ToString() + "', '" +
					Request.QueryString["tc"] + "'";
				conn.ExecuteNonQuery();

				Response.Redirect("TargetCustomerSearch.aspx?trg=" + Request.QueryString["trg"] + "&tc=" + Request.QueryString["tc"] + "&mc=" + Request.QueryString["mc"]);
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

		protected void BTN_APRVBU_Click(object sender, System.EventArgs e)
		{
			try
			{
				conn.QueryString  = "EXEC TARGETCUST_APPROVALBU '" + 
					Request.QueryString["trgcuref"] + "', '" + 
					DDL_ASSIGNBU.SelectedValue + "', '" +
					Session["UserID"].ToString() + "', '" +
					Request.QueryString["tc"] + "'";
				conn.ExecuteQuery();

				string msg = conn.GetFieldValue("MSG");
				Response.Redirect("TargetCustomerAprvList.aspx?trg=" + Request.QueryString["trg"] + "&tc=" + Request.QueryString["tc"] + "&mc=" + Request.QueryString["mc"] + "&msg=" + msg);
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

		protected void BTN_ASSIGNRISK_Click(object sender, System.EventArgs e)
		{
			try
			{
				conn.QueryString  = "EXEC TARGETCUST_ASSIGNAPPROVALRISK '" + 
					Request.QueryString["trgcuref"] + "', '" + 
					DDL_ASSIGNRISK.SelectedValue + "', '" +
					Session["UserID"].ToString() + "', '" +
					Request.QueryString["tc"] + "'";
				conn.ExecuteQuery();

				string msg = conn.GetFieldValue("MSG");
				Response.Redirect("TargetCustomerSearch.aspx?trg=" + Request.QueryString["trg"] + "&tc=" + Request.QueryString["tc"] + "&mc=" + Request.QueryString["mc"] + "&msg=" + msg);
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

		protected void BTN_APRVRISK_Click(object sender, System.EventArgs e)
		{
			try
			{
				conn.QueryString  = "EXEC TARGETCUST_APPROVALRISK '" + 
					Request.QueryString["trgcuref"] + "', '" + 
					Session["UserID"].ToString() + "', '" +
					Request.QueryString["tc"] + "'";
				conn.ExecuteQuery();

				string msg = conn.GetFieldValue("MSG");
				Response.Redirect("TargetCustomerAprvList.aspx?trg=" + Request.QueryString["trg"] + "&tc=" + Request.QueryString["tc"] + "&mc=" + Request.QueryString["mc"] + "&msg=" + msg);
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

		protected void BTN_ACQINFOBU_Click(object sender, System.EventArgs e)
		{
			//Response.Write("<script for=window event=onload language='javascript'>PopupPage('TargetCustomerAcqInfo.aspx?trgcuref=" + Request.QueryString["trgcuref"] + "&aprv=bu&theForm=Form1&theObj=TXT_TEMP', '800','300');</script>");
            popUp = "<script for=window event=onload language='javascript'>PopupPage('TargetCustomerAcqInfo.aspx?trgcuref=" + Request.QueryString["trgcuref"] + "&aprv=bu&theForm=Form1&theObj=TXT_TEMP', '800','300');</script>";
		}

		protected void TXT_TEMP_TextChanged(object sender, System.EventArgs e)
		{
			if (TXT_TEMP.Text != "") 
			{
				string msg = "";
				msg = "Application acquire information from " + TXT_TEMP.Text + " !";
				Response.Redirect("TargetCustomerAprvList.aspx?mc="+Request.QueryString["mc"]+"&tc=" + Request.QueryString["tc"]+"&trg=" + Request.QueryString["trg"]+"&msg="+msg);
			}
		}

		protected void BTN_ACQINFORISK_Click(object sender, System.EventArgs e)
		{
			//Response.Write("<script for=window event=onload language='javascript'>PopupPage('TargetCustomerAcqInfo.aspx?trgcuref=" + Request.QueryString["trgcuref"] + "&aprv=risk&theForm=Form1&theObj=TXT_TEMP', '800','300');</script>");
            popUp = "<script for=window event=onload language='javascript'>PopupPage('TargetCustomerAcqInfo.aspx?trgcuref=" + Request.QueryString["trgcuref"] + "&aprv=risk&theForm=Form1&theObj=TXT_TEMP', '800','300');</script>";
		}

		protected void DDL_SEKTOREKONOMI1_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			DDL_SEKTOREKONOMI2.Items.Clear();
			DDL_SEKTOREKONOMI2.Items.Add(new ListItem("- PILIH -", ""));

			conn.QueryString = "select bmsub_code,bmsub_code + ' - ' + bmsub_desc as bmsubsektorDESC from RFbmsubsektorekonomi where ACTIVE='1' and BM_CODE = '"  + DDL_SEKTOREKONOMI1.SelectedValue + "'	order by bmsub_code";
			conn.ExecuteQuery();
			for (int i = 0; i < conn.GetRowCount(); i++)
				DDL_SEKTOREKONOMI2.Items.Add(new ListItem(conn.GetFieldValue(i,1), conn.GetFieldValue(i,0)));
			conn.ClearData();

			DDL_SEKTOREKONOMI3.Items.Clear();
			DDL_SEKTOREKONOMI3.Items.Add(new ListItem("- PILIH -", ""));

			conn.QueryString = "select bmsubsub_code,bmsubsub_code + ' - ' + bmsubsub_desc as bmsubsektorDESC from RFbmsubsubsektorekonomi where ACTIVE='1' and bmsub_code = '"  + DDL_SEKTOREKONOMI2.SelectedValue + "'	order by bmsubsub_code";
			conn.ExecuteQuery();
			for (int i = 0; i < conn.GetRowCount(); i++)
				DDL_SEKTOREKONOMI3.Items.Add(new ListItem(conn.GetFieldValue(i,1), conn.GetFieldValue(i,0)));

			conn.QueryString = "SELECT BI_SEQ, BMSUBSUB_DESC, * FROM RFBMSUBSUBSEKTOREKONOMI WHERE BMSUBSUB_CODE = '" + DDL_SEKTOREKONOMI3.SelectedValue + "'";
			conn.ExecuteQuery();
			GlobalTools.fillRefList(DDL_SEKTOREKONOMI4, "SELECT BI_SEQ, BI_DESC FROM RFBICODE WHERE BG_GROUP = '3' AND BI_SEQ = '" + conn.GetFieldValue("BI_SEQ") + "'", true, conn);
			try{DDL_SEKTOREKONOMI4.SelectedValue = conn.GetFieldValue("BI_SEQ");}
			catch{DDL_SEKTOREKONOMI4.SelectedValue="";}
		}

		protected void DDL_SEKTOREKONOMI2_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			DDL_SEKTOREKONOMI3.Items.Clear();

			conn.QueryString = "select bmsubsub_code,bmsubsub_code + ' - ' + bmsubsub_desc as bmsubsektorDESC from RFbmsubsubsektorekonomi where ACTIVE='1' and bmsub_code = '"  + DDL_SEKTOREKONOMI2.SelectedValue + "'	order by bmsubsub_code";
			conn.ExecuteQuery();
			for (int i = 0; i < conn.GetRowCount(); i++)
				DDL_SEKTOREKONOMI3.Items.Add(new ListItem(conn.GetFieldValue(i,1), conn.GetFieldValue(i,0)));

			conn.QueryString = "SELECT BI_SEQ, BMSUBSUB_DESC, * FROM RFBMSUBSUBSEKTOREKONOMI WHERE BMSUBSUB_CODE = '" + DDL_SEKTOREKONOMI3.SelectedValue + "'";
			conn.ExecuteQuery();
			GlobalTools.fillRefList(DDL_SEKTOREKONOMI4, "SELECT BI_SEQ, BI_DESC FROM RFBICODE WHERE BG_GROUP = '3' AND BI_SEQ = '" + conn.GetFieldValue("BI_SEQ") + "'", true, conn);
			try{DDL_SEKTOREKONOMI4.SelectedValue = conn.GetFieldValue("BI_SEQ");}
			catch{DDL_SEKTOREKONOMI4.SelectedValue="";}
		}

		protected void DDL_SEKTOREKONOMI3_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			conn.QueryString = "SELECT BI_SEQ, BMSUBSUB_DESC, * FROM RFBMSUBSUBSEKTOREKONOMI WHERE BMSUBSUB_CODE = '" + DDL_SEKTOREKONOMI3.SelectedValue + "'";
			conn.ExecuteQuery();
			GlobalTools.fillRefList(DDL_SEKTOREKONOMI4, "SELECT BI_SEQ, BI_DESC FROM RFBICODE WHERE BG_GROUP = '3' AND BI_SEQ = '" + conn.GetFieldValue("BI_SEQ") + "'", true, conn);
			try{DDL_SEKTOREKONOMI4.SelectedValue = conn.GetFieldValue("BI_SEQ");}
			catch{DDL_SEKTOREKONOMI4.SelectedValue="";}
		}

		protected void TXT_TEMPBI_TextChanged(object sender, System.EventArgs e)
		{
			string biall, bi1, bi2, bi3, bi4;
			int x, y;
			if(this.TXT_TEMPBI.Text != "")
			{
				try
				{
					biall = TXT_TEMPBI.Text.Trim();
					y = biall.Length;

					x = biall.IndexOf("|");
					bi1 = biall.Substring(0, x);
					biall = biall.Substring(x+1, y-x-1);
					y = biall.Length;

					x = biall.IndexOf("|");
					bi2 = biall.Substring(0, x);
					biall = biall.Substring(x+1, y-x-1);
					y = biall.Length;

					x = biall.IndexOf("|");
					bi3 = biall.Substring(0, x);
					biall = biall.Substring(x+1, y-x-1);

					bi4 = biall;

					DDL_SEKTOREKONOMI1.SelectedValue = bi1;

					DDL_SEKTOREKONOMI2.Items.Clear();
					DDL_SEKTOREKONOMI2.Items.Add(new ListItem("- PILIH -", ""));
					conn.QueryString = "select bmsub_code,bmsub_code + ' - ' + bmsub_desc as bmsubsektorDESC from RFbmsubsektorekonomi where ACTIVE='1' and BM_CODE = '"  + bi1 + "' order by bmsub_code";
					conn.ExecuteQuery();
					for (int i = 0; i < conn.GetRowCount(); i++)
						DDL_SEKTOREKONOMI2.Items.Add(new ListItem(conn.GetFieldValue(i,1), conn.GetFieldValue(i,0)));

					DDL_SEKTOREKONOMI2.SelectedValue = bi2;

					DDL_SEKTOREKONOMI3.Items.Clear();
					DDL_SEKTOREKONOMI3.Items.Add(new ListItem("- PILIH -", ""));
					conn.QueryString = "select bmsubsub_code,bmsubsub_code + ' - ' + bmsubsub_desc as bmsubsektorDESC from RFbmsubsubsektorekonomi where ACTIVE='1' and bmsub_code = '"  + bi2 + "' order by bmsubsub_code";
					conn.ExecuteQuery();
					for (int i = 0; i < conn.GetRowCount(); i++)
						DDL_SEKTOREKONOMI3.Items.Add(new ListItem(conn.GetFieldValue(i,1), conn.GetFieldValue(i,0)));

					DDL_SEKTOREKONOMI3.SelectedValue = bi3;

					DDL_SEKTOREKONOMI4.Items.Clear();
					conn.QueryString = "SELECT BI_SEQ, BMSUBSUB_DESC, * FROM RFBMSUBSUBSEKTOREKONOMI WHERE BMSUBSUB_CODE = '" + bi3 + "'";
					conn.ExecuteQuery();
					GlobalTools.fillRefList(DDL_SEKTOREKONOMI4, "SELECT BI_SEQ, BI_DESC FROM RFBICODE WHERE BG_GROUP = '3' AND BI_SEQ = '" + conn.GetFieldValue("BI_SEQ") + "'", true, conn);

					DDL_SEKTOREKONOMI4.SelectedValue = bi4;

				}
				catch (Exception ex)
				{
					Response.Write("<!--" + ex.ToString() + "-->");
				}
			}
		}

		protected void BTN_SAVE_TERM_Click(object sender, System.EventArgs e)
		{
			try
			{
				conn.QueryString  = "EXEC TARGETCUST_SAVERENCANABOOKING '" + Request.QueryString["trgcuref"] + "', " + 
					tool.ConvertDate(TXT_TERM_DATE_DAY.Text, DDL_TERM_DATE_MONTH.SelectedValue, TXT_TERM_DATE_YEAR.Text) + ", " +
					tool.ConvertFloat(TXT_TERM_VALUE.Text);
				conn.ExecuteNonQuery();

				ViewDataBooking();

				TXT_TERM_DATE_DAY.Text = "";
				try {DDL_TERM_DATE_MONTH.SelectedValue = "";}
				catch {}
				TXT_TERM_DATE_YEAR.Text = "";
				TXT_TERM_VALUE.Text = "";
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

		private void DG_GRID_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			try 
			{
				conn.QueryString = "EXEC TARGETCUST_DELETERENCANABOOKING '" + Request.QueryString["trgcuref"] + 
					"', '" + e.Item.Cells[0].Text + "'";
				conn.ExecuteQuery();

				ViewDataBooking();
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

		private void DG_GRID_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			DG_GRID.CurrentPageIndex = e.NewPageIndex;
			ViewDataBooking();
		}
	}
}