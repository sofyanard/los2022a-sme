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
using Microsoft.VisualBasic;

namespace SME.Legal
{
	/// <summary>
	/// Summary description for LegalSigning1.
	/// </summary>
	public partial class LegalSigning2 : System.Web.UI.Page
	{
		protected Connection conn;
		protected Tools tools = new Tools();
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			conn = (Connection) Session["Connection"];

			if (!Logic.AllowAccess(Session["GroupID"].ToString(), Request.QueryString["mc"], conn))
				Response.Redirect("/SME/Restricted.aspx");

			if (!IsPostBack)
			{
				LBL_REGNO.Text	= Request.QueryString["regno"];
				LBL_TC.Text		= Request.QueryString["tc"];

				DDL_AP_SIGNDATEMONTH.Items.Add(new ListItem("- PILIH -", ""));
				DDL_BLN.Items.Add(new ListItem("- PILIH -", ""));
				DDL_COV_NEXTDATE_MONTH2.Items.Add(new ListItem("- PILIH -", ""));
				for (int i=1; i<=12; i++)
				{
					DDL_BLN.Items.Add(new ListItem(DateAndTime.MonthName(i, false), i.ToString()));
					DDL_AP_SIGNDATEMONTH.Items.Add(new ListItem(DateAndTime.MonthName(i, false), i.ToString()));
					DDL_COV_NEXTDATE_MONTH2.Items.Add(new ListItem(DateAndTime.MonthName(i, false), i.ToString()));
				}
				TXT_TGL.Text	= DateAndTime.Now.Date.Day.ToString();
				TXT_THN.Text	= DateAndTime.Now.Date.Year.ToString();
				DDL_BLN.SelectedValue	= DateAndTime.Now.Date.Month.ToString();
				ViewProses();
				ViewData();
				ViewDGR_LIST();
				SecureData();
			}
			
			ViewMenu();
			ViewFileUpload();
			BTN_UPDATE.Attributes.Add("onclick","if(!ConfirmBox('Are you sure want to update ?')){return false;};");
			BTN_DF_INPUT.Attributes.Add("onclick","if(!cek_mandatory(document.Form1)){return false;};");
			//BTN_RETURNTOBU.Attributes.Add("onclick","if(!ConfirmBox('Are you sure want to back this application to SPPK Confirmation?')){return false;};");
		}

		private void ViewFileUpload()
		{
			conn.QueryString = "SELECT AP_BUSINESSUNIT FROM VW_APPBUSINESSUNIT WHERE AP_REGNO = '" + LBL_REGNO.Text + "'";
			conn.ExecuteQuery();
			
			if (conn.GetRowCount() > 0)
			{
				if (conn.GetFieldValue("AP_BUSINESSUNIT") == "CB100")
				{
					TBL_FILEUPLOAD.Visible = true;
				}
				else
				{
					TBL_FILEUPLOAD.Visible = false;
				}
			}
			else
			{
				TBL_FILEUPLOAD.Visible = false;
			}
		}

		private void ViewProses()
		{
			DDL_PROSES.Items.Clear();
			conn.QueryString = "select seq, des from vw_syarat where doctypeid='4' and (sy_status='0' or sy_status is null or sy_status='') and ap_regno='"+LBL_REGNO.Text+"'";
			conn.ExecuteQuery();
			DDL_PROSES.Items.Add(new ListItem("-- Select --",""));
			int row	= conn.GetRowCount();
			for (int i = 0 ; i < row;i++)
				DDL_PROSES.Items.Add(new ListItem(conn.GetFieldValue(i,1),conn.GetFieldValue(i,0)));
			if (row<=0) 
			{
				BTN_UPDATE.Enabled	= true;
				BTN_PRINT.Enabled = true;
			}
			else 
			{
				BTN_UPDATE.Enabled	= false;
				BTN_PRINT.Enabled = false;
			}
			conn.ClearData();
		}

		private void ViewData()
		{
			conn.QueryString = "select AP_REGNO, CU_REF, AP_SIGNDATE, BRANCH_NAME, AP_TMLDRNM, "+
				"AP_RMNM, CU_NAME, CU_ADDR1, CU_ADDR2, CU_ADDR3, CU_CITYNM, CU_PHN, BUSSTYPEDESC, ANALIS "+
				"from VW_INFOUMUM "+
				"where AP_REGNO = '"+ LBL_REGNO.Text +"' ";
			conn.ExecuteQuery();
			TXT_AP_REGNO.Text					= conn.GetFieldValue("AP_REGNO");
			TXT_CU_REF.Text						= conn.GetFieldValue("CU_REF");
			string AP_SIGNDATE					= conn.GetFieldValue("AP_SIGNDATE");
			TXT_AP_SIGNDATEDAY.Text				= tools.FormatDate_Day(AP_SIGNDATE);
			DDL_AP_SIGNDATEMONTH.SelectedValue	= tools.FormatDate_Month(AP_SIGNDATE);
			TXT_AP_SIGNDATEYEAR.Text			= tools.FormatDate_Year(AP_SIGNDATE);
			TXT_BRANCH_NAME.Text				= conn.GetFieldValue("BRANCH_NAME");
			TXT_AP_TMLDRNM.Text					= conn.GetFieldValue("AP_TMLDRNM");
			TXT_AP_RMNM.Text					= conn.GetFieldValue("AP_RMNM");
			TXT_CU_NAME.Text					= conn.GetFieldValue("CU_NAME");
			TXT_CU_ADDR1.Text					= conn.GetFieldValue("CU_ADDR1");
			TXT_CU_ADDR2.Text					= conn.GetFieldValue("CU_ADDR2");
			TXT_CU_ADDR3.Text					= conn.GetFieldValue("CU_ADDR3");
			TXT_CU_CITYNM.Text					= conn.GetFieldValue("CU_CITYNM");
			TXT_CU_PHN.Text						= conn.GetFieldValue("CU_PHN");
			TXT_BUSSTYPEDESC.Text				= conn.GetFieldValue("BUSSTYPEDESC");
			TXT_ANALIS.Text						= conn.GetFieldValue("ANALIS");
			conn.ClearData();
		}

		private void ViewDGR_LIST()
		{
			conn.QueryString = "select * from VW_SYARAT " +
				"where DOCTYPEID = '4' and sy_status='1' and AP_REGNO = '" + LBL_REGNO.Text + "'";
			conn.ExecuteQuery();
			DataTable data = new DataTable();
			data = conn.GetDataTable().Copy();
			DGR_LIST.DataSource = data;
			DGR_LIST.DataBind();
			for (int i = 0; i < DGR_LIST.Items.Count; i++)
				DGR_LIST.Items[i].Cells[2].Text = tools.FormatDate(DGR_LIST.Items[i].Cells[2].Text);

			ViewDGR_LIST2();
			ViewDataPKDoc();
		}

		private void ClearItems()
		{
			DDL_PROSES.SelectedValue	= "";
			/****
			TXT_TGL.Text				= "";
			DDL_BLN.SelectedValue		= "";
			TXT_THN.Text				= "";
			****/
			TXT_KET.Text				= "";
			TXT_COV_NEXTDATE_DAY2.Text	= "";
			DDL_COV_NEXTDATE_MONTH2.SelectedValue = "";
			TXT_COV_NEXTDATE_YEAR2.Text	= "";
			CHK_COV_ISFINISH2.Checked = false;
		}

		private void ViewDataPKDoc()
		{
			for (int i=0;i<DGR_LIST.Items.Count;i++)
			{
				DataGrid dgpkdoc = (DataGrid) DGR_LIST.Items[i].Cells[4].FindControl("DG_PKDOC");

				conn.QueryString = "SELECT * FROM VW_SYARAT_DOC WHERE AP_REGNO = '" + Request.QueryString["regno"] + "' AND DOCTYPEID = '4' AND COVSEQ = '" + DGR_LIST.Items[i].Cells[0].Text.Trim() + "'";
				conn.ExecuteQuery();

				if (conn.GetRowCount() > 0)
				{
					DataTable dtpkdoc = new DataTable();
					dtpkdoc = conn.GetDataTable().Copy();
					dgpkdoc.DataSource = dtpkdoc;
					try 
					{
						dgpkdoc.DataBind();
					} 
					catch 
					{
						dgpkdoc.CurrentPageIndex = 0;
						dgpkdoc.DataBind();
					}

					for (int j = 0; j < dgpkdoc.Items.Count; j++)
					{
						int n = j+1;
						dgpkdoc.Items[j].Cells[2].Text = n.ToString();
						HyperLink HpDownload = (HyperLink) dgpkdoc.Items[j].Cells[4].FindControl("HL_DOWNLOAD1");
						HpDownload.NavigateUrl = dgpkdoc.Items[j].Cells[7].Text.Trim();
					}
				}
			}
		}

		private void ViewDGR_LIST2()
		{
			for (int i=0;i<DGR_LIST.Items.Count;i++)
			{
				TextBox txtnextdate_day = (TextBox) DGR_LIST.Items[i].Cells[6].FindControl("TXT_COV_NEXTDATE_DAY");
				DropDownList ddlnextdate_month = (DropDownList) DGR_LIST.Items[i].Cells[6].FindControl("DDL_COV_NEXTDATE_MONTH");
				TextBox txtnextdate_year = (TextBox) DGR_LIST.Items[i].Cells[6].FindControl("TXT_COV_NEXTDATE_YEAR");

				txtnextdate_day.Text = tools.FormatDate_Day(DGR_LIST.Items[i].Cells[9].Text);
				try {ddlnextdate_month.SelectedValue = tools.FormatDate_Month(DGR_LIST.Items[i].Cells[9].Text);}
				catch {}
				txtnextdate_year.Text = tools.FormatDate_Year(DGR_LIST.Items[i].Cells[9].Text);

				CheckBox chkcovfinish = (CheckBox) DGR_LIST.Items[i].Cells[7].FindControl("CHK_COV_ISFINISH");

				if (DGR_LIST.Items[i].Cells[10].Text == "1")
					chkcovfinish.Checked = true;
				else
					chkcovfinish.Checked = false;
			}
		}

		private void SecureData() 
		{
			/* *
			 * Untuk men-disable syarat jika di-pass parameter sy==0
			 * */
			string sy = null;
			if (Request.QueryString["sy"] != null)
				sy = Request.QueryString["sy"];
			if (sy == "0") 
			{
				System.Web.UI.ControlCollection coll = this.Page.Controls;
				for (int i = 0; i < coll[1].Controls.Count; i++) 
				{
					if (coll[1].Controls[i] is TextBox) 
					{
						TextBox txt = (TextBox) coll[1].Controls[i];
						txt.ReadOnly = true;
					}
					else if (coll[1].Controls[i] is DropDownList) 
					{
						DropDownList ddl = (DropDownList) coll[1].Controls[i];
						ddl.Enabled = false;
					}
					else if (coll[1].Controls[i] is Button)
					{
						Button btn = (Button) coll[1].Controls[i];
						btn.Visible = false;
					}
					else if (coll[1].Controls[i] is DataGrid) 
					{						
						DataGrid dg = (DataGrid) coll[1].Controls[i];
						dg.Columns[5].Visible = false;
						for (int j = 0; j < dg.Items.Count; j++) 
						{
							dg.Items[j].Cells[9].Visible = false;
						}
					}
						/*
						else if (coll[1].Controls[i] is RadioButtonList) 
						{
							RadioButtonList rbl = (RadioButtonList) coll[1].Controls[i];
							rbl.Enabled = false;
						}					
						else if (coll[1].Controls[i] is RadioButton) 
						{
							RadioButton rb = (RadioButton) coll[1].Controls[i];
							rb.Enabled = false;
						}					
						else if (coll[1].Controls[i] is CheckBox)
						{
							CheckBox cb = (CheckBox) coll[1].Controls[i];
							cb.Enabled = false;
						}					
						*/
					else if (coll[1].Controls[i] is HtmlTableRow) 
					{
						HtmlTableRow htr = (HtmlTableRow) coll[1].Controls[i];

						for (int j=0; j < htr.Controls.Count; j++) 
						{							
							for (int jj = 0; jj < htr.Controls[j].Controls.Count; jj++) 
							{
								if (htr.Controls[j].Controls[jj] is TextBox) 
								{
									TextBox txt = (TextBox) htr.Controls[j].Controls[jj];
									txt.ReadOnly = true;
								}
								else if (htr.Controls[j].Controls[jj] is DropDownList) 
								{
									DropDownList ddl = (DropDownList) htr.Controls[j].Controls[jj];
									ddl.Enabled = false;
								}
								else if (htr.Controls[j].Controls[jj] is Button)
								{
									Button btn = (Button) htr.Controls[j].Controls[jj];
									btn.Visible = false;
								}
								/*
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
								*/					
							}
						}
					}
				}
			}
			if (sy == null)
			{
				for (int i=0; i<DGR_LIST.Items.Count; i++)
				{
					TextBox txtnextdate_day = (TextBox) DGR_LIST.Items[i].Cells[6].FindControl("TXT_COV_NEXTDATE_DAY");
					DropDownList ddlnextdate_month = (DropDownList) DGR_LIST.Items[i].Cells[6].FindControl("DDL_COV_NEXTDATE_MONTH");
					TextBox txtnextdate_year = (TextBox) DGR_LIST.Items[i].Cells[6].FindControl("TXT_COV_NEXTDATE_YEAR");
					CheckBox chkcovfinish = (CheckBox) DGR_LIST.Items[i].Cells[7].FindControl("CHK_COV_ISFINISH");

					txtnextdate_day.ReadOnly = true;
					ddlnextdate_month.Enabled = false;
					txtnextdate_year.ReadOnly = true;
					chkcovfinish.Enabled = false;
				}
				TR_REVIEWCOVENANT.Visible = false;
			}
			if (sy == "2")
			{
				DGR_LIST.Columns[8].Visible = false;
				TR_REVIEWCOVENANT.Visible = true;
				TR_LEGALSIGNING.Visible = false;
				TR_LEGALSIGNING2.Visible = false;
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
			this.DGR_LIST.ItemCreated += new System.Web.UI.WebControls.DataGridItemEventHandler(this.DGR_LIST_ItemCreated);
			this.DGR_LIST.ItemCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.DGR_LIST_ItemCommand);

		}
		#endregion

        public string popUp = "";

		protected void BTN_DF_INPUT_Click(object sender, System.EventArgs e)
		{
			string isfinish = null;
			if (!DDL_PROSES.SelectedValue.Equals(""))
			{
				try
				{
					conn.QueryString = "exec SP_SYARAT '"+ LBL_REGNO.Text +"', "+DDL_PROSES.SelectedValue+", "+
						"'1', "+tools.ConvertDate(TXT_TGL.Text, DDL_BLN.SelectedValue, TXT_THN.Text )+", '"+ TXT_KET.Text +"' , '4','1'";
					conn.ExecuteNonQuery();

					if (CHK_COV_ISFINISH2.Checked == true)
						isfinish = "1";
					else
						isfinish = "0";

					conn.QueryString = "EXEC COVENANT_SAVEREVIEW_CO '" +
						LBL_REGNO.Text + "', '4', '" +
						DDL_PROSES.SelectedValue + "', " +
						tools.ConvertDate(TXT_COV_NEXTDATE_DAY2.Text, DDL_COV_NEXTDATE_MONTH2.SelectedValue, TXT_COV_NEXTDATE_YEAR2.Text) + ", '" +
						isfinish + "'";
					conn.ExecuteNonQuery();
				}
				catch (Exception ex)
				{
					Response.Write("<!--" + ex.Message + "-->");
					Tools.popMessage(this,"Insert Error!!");
				}
			}
			ClearItems();
			ViewDGR_LIST();
			SecureData();
			ViewProses();
		}

		private void DGR_LIST_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			switch (((LinkButton)e.CommandSource).CommandName)
			{
				case "delete":
					try
					{
						conn.QueryString = "exec SP_SYARAT '"+ LBL_REGNO.Text +"', "+Int16.Parse(e.Item.Cells[0].Text)+", "+
							"'0', "+tools.ConvertDate(1.ToString(),1.ToString(),2000.ToString())+", '"+ e.Item.Cells[3].Text +"','4','1' ";
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
					break;

				case "Upload":
					Response.Write("<script language='javascript'>window.open('../CreditProposal/SyaratUploadFile.aspx?regno=" + Request.QueryString["regno"] + "&doctype=4&covseq=" + e.Item.Cells[0].Text + "&theForm=Form1&theObj=TXT_TEMP_PK','UploadDocument','status=no,scrollbars=yes,width=800,height=600');</script>");
					break;
			}		
			ViewDGR_LIST();
			SecureData();
			ViewProses();
		}

		protected void BTN_UPDATE_Click(object sender, System.EventArgs e)
		{
			//25-10-2007 cek NCL limit
			conn.QueryString  = "select AP_REGNO, PRODUCTID, APPTYPE, PROD_SEQ, CP_LIMITAPPROVED from CUSTPRODUCT where AP_REGNO = '" + LBL_REGNO.Text + "'";
			conn.ExecuteQuery();
			DataTable dt = conn.GetDataTable().Copy();
			for (int i=0; i<dt.Rows.Count; i++) 
			{
				if (dt.Rows[i]["APPTYPE"].ToString() == "09")
				{
					conn.QueryString = "exec LEGAL_CHECKLIMIT_POSTFIN '" + dt.Rows[i]["AP_REGNO"].ToString() + "', '" +
						dt.Rows[i]["PRODUCTID"].ToString() + "', '" +
						dt.Rows[i]["APPTYPE"].ToString() + "', '" +
						dt.Rows[i]["PROD_SEQ"].ToString() + "'";
					conn.ExecuteQuery();
					double remaininglimit = double.Parse(conn.GetFieldValue("CP_LIMIT"));
					double applyvalue = double.Parse(dt.Rows[i]["CP_LIMITAPPROVED"].ToString());
					if (applyvalue > remaininglimit)
					{
						GlobalTools.popMessage(this, "Apply Value Exceeds Remaining NCL Limit!");
						return;
					}
					else
					{
						conn.QueryString = "exec LEGAL_UPDATELIMIT_POSTFIN '" + dt.Rows[i]["AP_REGNO"].ToString() + "', '" +
							dt.Rows[i]["PRODUCTID"].ToString() + "', '" +
							dt.Rows[i]["APPTYPE"].ToString() + "', '" +
							dt.Rows[i]["PROD_SEQ"].ToString() + "'";
						conn.ExecuteQuery();
					}
				}
			}

			//exec trackupdate2 AP_REGNO, USERID
			conn.QueryString = "exec TRACKUPDATE2 '" + 
				LBL_REGNO.Text + "', '" + 
				Session["UserID"] + "','"+
				Request.QueryString["tc"].Trim() +"'"; //4.7
			conn.ExecuteNonQuery();

			// trackupdate untuk sub application
			conn.QueryString = "exec TRACKUPDATE_SUBAPP '" + 
				LBL_REGNO.Text + "', '" + 
				Session["UserID"] + "','"+
				Request.QueryString["tc"].Trim() +"'";//4.7
			conn.ExecuteNonQuery();


			/* start of tambahan doctracking 20040916 -- ashari*/			 
			/*
			conn.QueryString="select * from SENDRECEIVEDOCLIST where ap_regno='" +  Request.QueryString["regno"] + "' and HASUPDATED<2 and not send_by='" + Session["USERID"].ToString() + "'";
			conn.ExecuteQuery();
			int jml = conn.GetRowCount();
			if (jml>0)
			{
				Tools.popMessage(this,"Document Tracking Harus diupdate");
				return;
			}
			else
			{
				conn.QueryString="update SENDRECEIVEDOCLIST set HASUPDATED=0 where ap_regno='" +  Request.QueryString["regno"] + "'";
				conn.ExecuteNonQuery();
			}
			*/			
			 /* end of tambahan doctracking 20040916 -- ashari -- */


			string msg = getNextStepMsg(Request.QueryString["regno"], Request.QueryString["tc"]);
			Response.Redirect("ListLegal.aspx?tc=" + Request.QueryString["tc"] + "&mc=" + Request.QueryString["mc"] + "&msg=" + msg);
		}

				// mengambil informasi next track dari track yang sekarang
		private string getNextStepMsg(string regno, string tc) 
		{
			string pesan = "";
			string nextTrack = "";
			try 
			{
				/***
				 * Memunculkan pesan next step
				 ***/
				conn.QueryString  = "exec TRACKNEXTMSG1 '" + regno + "', '" + tc + "'";
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

		private string getNextStepMsg1(string regno) 
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

		protected void BTN_BACK_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			Response.Redirect("/SME/" + DMS.CuBESCore.Logic.backLink(Request.QueryString["tc"].ToString(), conn));
		}

		protected void BTN_PRINT_Click(object sender, System.EventArgs e)
		{
			//Response.Redirect("LegalInvestRqstForm.aspx?regno=" + Request.QueryString["regno"]);
			//Response.Write("<script for=window event=onload language='javascript'>PopupPage('LegalInvestRqstForm.aspx?regno=" + Request.QueryString["regno"] + "','800','400');</script>");
            popUp = "<script for=window event=onload language='javascript'>PopupPage('LegalInvestRqstForm.aspx?regno=" + Request.QueryString["regno"] + "','800','400');</script>";
		}

		/* Menangani proses pengembalian applikasi ke proses sebelumnya: SPPK Confirmation */
        
        protected void BTN_RETURNTOBU_Click(object sender, System.EventArgs e)
		{
			/*
			conn.QueryString  = "select APPTYPE, PRODUCTID, PROD_SEQ from CUSTPRODUCT ";
			conn.QueryString += "where AP_REGNO = '" + LBL_REGNO.Text + "'";
			conn.ExecuteQuery();
			DataTable dt = conn.GetDataTable().Copy();

			for (int i=0; i<dt.Rows.Count; i++) 
			{
				conn.QueryString = "exec TRACKBACK '" + 
					LBL_REGNO.Text + "', '" + 
					dt.Rows[i]["PRODUCTID"].ToString() + "', '" + 
					dt.Rows[i]["APPTYPE"].ToString() + "', '" + 
					Session["UserID"].ToString() + "', '" +	
					dt.Rows[i]["PROD_SEQ"].ToString() + "'"; 
				conn.ExecuteNonQuery();	
			}

			// AP_CO harus diset null karena applikasi dikembalikan ke sbo
			conn.QueryString = "update APPLICATION set AP_CO = null where AP_REGNO = '" + LBL_REGNO.Text + "'";
			conn.ExecuteNonQuery();

			///////////////////////////////////////////////////////////////////////////////////////////
			/// Audit Trail
			/// 
			conn.QueryString = "exec SP_AUDITTRAIL_APP '" + 
				LBL_REGNO.Text + "', " + 
				" NULL, NULL, NULL, '" + 
				TXT_CU_REF.Text + "', '" + 
				LBL_TC.Text + "', '" + TXT_AU_TEXT.Text + "', NULL, '" + 
				Session["UserID"].ToString() + "', NULL, 'N', NULL";			
			conn.ExecuteNonQuery();	
			////////////////////////////////////////////////////////////////////////////////////////////
			

			string msg = getPrevStepMsg(LBL_REGNO.Text, Request.QueryString["tc"]);
			Response.Redirect("ListLegal.aspx?tc=" + Request.QueryString["tc"] + "&mc=" + Request.QueryString["mc"] + "&msg=" + msg);
			*/
			//Response.Write("<script for=window event=onload language='javascript'>PopupPage('../Approval/AcqInfo.aspx?regno=" + LBL_REGNO.Text + "&curef=" + TXT_CU_REF.Text + "&aprv=CO&theForm=Form1&theObj=TXT_TEMP', '800','300');</script>");
            popUp = "<script for=window event=onload language='javascript'>PopupPage('../Approval/AcqInfo.aspx?regno=" + LBL_REGNO.Text + "&curef=" + TXT_CU_REF.Text + "&aprv=CO&theForm=Form1&theObj=TXT_TEMP', '800','300');</script>";
		}

		private string getPrevStepMsg(string regno, string tc)
		{
			string pesan = "";
			string nextTrack = "";
			string area = (string) Session["AreaID"];

			try 
			{
				/***
				 * Memunculkan pesan prev step: Gatot
				 ***/
				conn.QueryString = "exec TRACKPREVMSG '" + regno + "', '" + tc + "'";
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

		private void DGR_LIST_ItemCreated(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			DataGrid dgpkdoc = (DataGrid) e.Item.FindControl("DG_PKDOC");
			if (dgpkdoc != null)
			{
				dgpkdoc.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(this.dgpkdoc_ItemDataBound);
				dgpkdoc.ItemCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.dgpkdoc_ItemCommand);
				dgpkdoc.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.dgpkdoc_PageIndexChanged);
			}

			if (e.Item.Cells[6].Visible == true)
			{
				DropDownList ddlnextdate = (DropDownList) e.Item.FindControl("DDL_COV_NEXTDATE_MONTH");
				if (ddlnextdate != null)
				{
					ddlnextdate.Items.Add(new ListItem("- SELECT -", ""));
					for (int i = 1; i <= 12; i++)
					{
						ddlnextdate.Items.Add(new ListItem(DateAndTime.MonthName(i, false), i.ToString()));
					}
				}
			}
		}

		private void dgpkdoc_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			
		}

		private void dgpkdoc_ItemCommand(object sender, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			DataGrid dg = (DataGrid)sender;
			switch (((LinkButton)e.CommandSource).CommandName)
			{
				case "delete":
					try
					{
						conn.QueryString = "EXEC SYARAT_DOC_DELETE '" +
							Request.QueryString["regno"] + "', '4', '" +
							e.Item.Cells[0].Text + "', '" +
							e.Item.Cells[1].Text + "'";
						conn.ExecuteNonQuery();
					}
					catch (Exception ex)
					{
						Response.Write("<!--" + ex.Message + "-->");
						Tools.popMessage(this,"Delete Error!!");
					}

					ViewDGR_LIST();
					SecureData();
					break;
			}
		}

		private void dgpkdoc_PageIndexChanged(object sender, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			DataGrid dg = (DataGrid)sender;
			dg.CurrentPageIndex = e.NewPageIndex;
			ViewDataPKDoc();
			//SecureData();
		}

		protected void TXT_TEMP_PK_TextChanged(object sender, System.EventArgs e)
		{
			ViewDGR_LIST();
			SecureData();
			TXT_TEMP_PK.Text = "";
		}

		protected void TXT_TEMP_TextChanged(object sender, System.EventArgs e)
		{
			if (TXT_TEMP.Text != "") 
			{
				string msg = "";
				msg = "Application acquire information from " + TXT_TEMP.Text + " !";
				Response.Redirect("ListLegal.aspx?tc=" + Request.QueryString["tc"] + "&mc=" + Request.QueryString["mc"] + "&msg=" + msg);
			}
		}

		protected void BTN_SAVEREV_Click(object sender, System.EventArgs e)
		{
			string nextdate = null, isfinish = null;
			try
			{
				for (int i=0; i<DGR_LIST.Items.Count; i++)
				{
					if ((DGR_LIST.Items[i].Cells[6].Visible == true) && (DGR_LIST.Items[i].Cells[7].Visible == true))
					{
						TextBox txtnextdate_day = (TextBox) DGR_LIST.Items[i].Cells[6].FindControl("TXT_COV_NEXTDATE_DAY");
						DropDownList ddlnextdate_month = (DropDownList) DGR_LIST.Items[i].Cells[6].FindControl("DDL_COV_NEXTDATE_MONTH");
						TextBox txtnextdate_year = (TextBox) DGR_LIST.Items[i].Cells[6].FindControl("TXT_COV_NEXTDATE_YEAR");
						CheckBox chkcovfinish = (CheckBox) DGR_LIST.Items[i].Cells[7].FindControl("CHK_COV_ISFINISH");

						if ((txtnextdate_day != null) && (ddlnextdate_month != null) && (txtnextdate_year != null))
						{
							if (GlobalTools.isDateValid(this, txtnextdate_day.Text.Trim(), ddlnextdate_month.SelectedValue.Trim(), txtnextdate_year.Text.Trim())) 
							{
								nextdate = tools.ConvertDate(txtnextdate_day.Text, ddlnextdate_month.SelectedValue, txtnextdate_year.Text);
							}
							else
							{
								nextdate = "''";
							}
						}
						else
						{
							nextdate = null;
						}

						if (chkcovfinish != null)
						{
							if (chkcovfinish.Checked == true)
								isfinish = "1";
							else
								isfinish = "0";
						}
						else
						{
							isfinish = null;
						}
					}
					else
					{
						return;
					}

					conn.QueryString = "EXEC COVENANT_SAVEREVIEW_CO '" +
						Request.QueryString["regno"] + "', '4', '" +
						DGR_LIST.Items[i].Cells[0].Text.Trim() + "', " +
						nextdate + ", '" +
						isfinish + "'";
					conn.ExecuteNonQuery();

					ViewDGR_LIST();
					SecureData();
				}
			}
			catch (Exception ex)
			{
				Response.Write("<!--" + ex.Message + "-->");
				Tools.popMessage(this,"Insert Error!!");
			}
		}

	}
}
