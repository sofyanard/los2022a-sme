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

namespace SME.ComplyReview.Channeling.Condition
{
	/// <summary>
	/// Summary description for MainVerificationAssignment.sadfsad
	/// </summary>
	public partial class AssignmentComplyMain : System.Web.UI.Page
	{
		protected Connection conn;
		protected Tools tool = new Tools();
		//protected System.Web.UI.HtmlControls.HtmlTable TBL_FILEUPLOAD;
		protected Connection2 conn2;
		protected Tools tools = new Tools();

		protected void Page_Load(object sender, System.EventArgs e)
		{
			conn = (Connection) Session["Connection"];
			conn2 = new Connection2();
			//if (!Logic.AllowAccess(Session["GroupID"].ToString(), Request.QueryString["mc"], conn))
			//	Response.Redirect("/SME/Restricted.aspx");

			if (!IsPostBack)
			{
				conn2.QueryString = "EXEC CHANNELING_VIEWDATA_COMPLY_REVIEW_MAINPAGE_CONDITION '" + Request.QueryString["curef"] + "','" + Session["UserID"].ToString() + "','" + Request.QueryString["parentregno"] + "','" + Request.QueryString["aano"] + "','" + Request.QueryString["productid"] + "','" + Request.QueryString["prodseq"] + "'";
				conn2.ExecuteQuery(); 
				FillDropDownListDateAndApplicationNumber();

				LBL_REGNO.Text	= Request.QueryString["regno"];
				LBL_TC.Text		= Request.QueryString["tc"];

				TXT_TGL.Text	= DateAndTime.Now.Date.Day.ToString();
				TXT_THN.Text	= DateAndTime.Now.Date.Year.ToString();
				DDL_BLN.SelectedValue	= DateAndTime.Now.Date.Month.ToString();
				
				//DDL_SYARAT.Items.Add(new ListItem("Telah menyerahkan Surat permohonan kredit yang telah disetujui",""));
				
				GlobalTools.fillRefList(DDL_PROSES,"SELECT RFTBODOC.DOCID, RFTBODOC.DOCDESC FROM SYARAT, RFTBODOC WHERE AP_REGNO = '" + Request.QueryString["regno"] + "' AND DOCTYPEID = '4' AND RFTBODOC.DOCID = SYARAT.DOCID", conn);
			
				ViewProses();
				ViewDGR_LIST();
				SecureData();
			}

			string asasa = LBL_REGNO.Text;
			ViewMenu();
			TXT_TEMP_PK.TextChanged += new EventHandler(TXT_TEMP_PK_TextChanged);
			fillDgListEndUser();
			bindDgListEndUser();
		}

		private void fillDgListEndUser()
		{
			BindData("dgListEndUser","EXEC CHANNELING_GETLIST_ENDUSER_CONDITION '" + Request.QueryString["regno"]  + "'");
		}

		private void bindDgListEndUser()
		{
			for (int i = 0; i < dgListEndUser.Items.Count; i++)
			{
				/*** DropDownList Assign To ***/
				RadioButton rdo_yes = (RadioButton) dgListEndUser.Items[i].Cells[3].FindControl("rdo_yes");
				RadioButton rdo_no = (RadioButton) dgListEndUser.Items[i].Cells[3].FindControl("rdo_no");
				
				if(rdo_yes != null)
				{
					rdo_yes.ID = "rdo_yes." + dgListEndUser.Items[i].Cells[1].Text.ToString();
				}

				if(rdo_no != null)
				{	
					rdo_no.ID = "rdo_no." + dgListEndUser.Items[i].Cells[1].Text.ToString();
				}
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

		private void FillDropDownListDateAndApplicationNumber()
		{
			IsiTanggal();

			conn.QueryString = "select branch_name, branch_code from rfbranch where active='1' order by branch_code";
			conn.ExecuteQuery();
			for (int i = 0; i < conn.GetRowCount(); i++)
				DDL_AP_BOOKINGBRANCH.Items.Add(new ListItem(conn.GetFieldValue(i,1) + " - " + conn.GetFieldValue(i,0), conn.GetFieldValue(i,1)));
			//set default booking branch
			DDL_AP_BOOKINGBRANCH.SelectedValue = conn2.GetFieldValue("SU_BRANCH");

			conn.QueryString = "select branch_name, branch_code from vw_ccobranch order by branch_code";
			conn.ExecuteQuery();
			for (int i = 0; i < conn.GetRowCount(); i++)
				DDL_AP_CCOBRANCH.Items.Add(new ListItem(conn.GetFieldValue(i,1) + " - " + conn.GetFieldValue(i,0), conn.GetFieldValue(i,1)));
			//set default cco branch
			conn.QueryString = "select br_ccobranch from rfbranch where branch_code = '" + Session["BranchID"].ToString() + "'";
			conn.ExecuteQuery();
			DDL_AP_CCOBRANCH.SelectedValue = conn.GetFieldValue("br_ccobranch");

			//isi default tanggal
			txt_DD_B.Text = conn2.GetFieldValue("dy");
			ddl_MM_B.SelectedValue = conn2.GetFieldValue("mth");
			txt_YY_B.Text = conn2.GetFieldValue("yr");

			LBL_PLAFOND_OWNER.Text = conn2.GetFieldValue("CU_NAME");
			LBL_REMAINING_EMAS.Text = GlobalTools.MoneyFormat(conn2.GetFieldValue("REMAINING_EMAS_LIMIT"));
			LBL_PENDING_LIMIT.Text = GlobalTools.MoneyFormat(conn2.GetFieldValue("PENDING_LIMIT"));
			LBL_AVAILBALE_LIMIT.Text = GlobalTools.MoneyFormat(conn2.GetFieldValue("AVAILABLE_LIMIT"));
			TXT_APPLICATION.Text = conn2.GetFieldValue("APREGNO");
		}

		private void ViewMenu()
		{
			try 
			{
				conn.QueryString = "select SM_ID,MENUCODE,SM_MENUDISPLAY,SM_LINKNAME from SCREENMENU where menucode = '"+Request.QueryString["mc"]+"'";
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
							strtemp = "regno=" + Request.QueryString["regno"]+ "&curef="+Request.QueryString["curef"]+"&mc="+Request.QueryString["mc"]+"&tc="+Request.QueryString["tc"]+"&jnsnasabah="+Request.QueryString["jnsnasabah"]+"&programid="+Request.QueryString["programid"]+"&lmsreg="+Request.QueryString["lmsreg"]+"&scr="+Request.QueryString["scr"]+"&parentregno="+Request.QueryString["parentregno"]+"&aano="+Request.QueryString["aano"] + "&productid=" + Request.QueryString["productid"] + "&prodseq=" + Request.QueryString["prodseq"];
						else	
							strtemp = "regno=" + Request.QueryString["regno"]+ "&curef="+Request.QueryString["curef"]+"&mc="+Request.QueryString["mc"]+"&tc="+Request.QueryString["tc"]+"&jnsnasabah="+Request.QueryString["jnsnasabah"]+"&programid="+Request.QueryString["programid"]+"&lmsreg="+Request.QueryString["lmsreg"]+"&scr="+Request.QueryString["scr"]+"&parentregno="+Request.QueryString["parentregno"]+"&aano="+Request.QueryString["aano"] + "&productid=" + Request.QueryString["productid"] + "&prodseq=" + Request.QueryString["prodseq"];
						//t.ForeColor = Color.MidnightBlue; 
					}
					else 
					{
						strtemp = "";
						t.ForeColor = Color.Red; 
					}
					t.NavigateUrl = "../" + conn.GetFieldValue(i, 3)+strtemp;
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
			this.DGR_LIST.ItemCreated += new System.Web.UI.WebControls.DataGridItemEventHandler(this.DGR_LIST_ItemCreated);
			this.DGR_LIST.ItemCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.DGR_LIST_ItemCommand);
			this.dgListEndUser.ItemCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.dgListEndUser_ItemCommand);

		}
		#endregion

		private void IsiTanggal()
		{
			GlobalTools.initDateFormINA(txt_DD_B, ddl_MM_B, txt_YY_B, true);
			GlobalTools.initDateFormINA(TXT_TGL, DDL_BLN, TXT_THN, true);
			GlobalTools.initDateFormINA(TXT_COV_NEXTDATE_DAY2, DDL_COV_NEXTDATE_MONTH2, TXT_COV_NEXTDATE_YEAR2, true);
		}

		private void Button1_Click(object sender, System.EventArgs e)
		{

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
				//TR_REVIEWCOVENANT.Visible = false;
			}
			if (sy == "2")
			{
				DGR_LIST.Columns[8].Visible = false;
				//TR_REVIEWCOVENANT.Visible = true;
				TR_LEGALSIGNING.Visible = false;
				TR_LEGALSIGNING2.Visible = false;
			}
		}

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
					Response.Write("<script language='javascript'>window.open('SyaratUploadFile.aspx?regno=" + Request.QueryString["regno"] + "&doctype=4&covseq=" + e.Item.Cells[0].Text + "&theForm=Form1&theObj=TXT_TEMP_PK','UploadDocument','status=no,scrollbars=yes,width=800,height=600');</script>");
					break;
			}		
			ViewDGR_LIST();
			SecureData();
			ViewProses();
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

		/*private void ViewFileUpload()
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
		}*/

		private void TXT_TEMP_PK_TextChanged(object sender, EventArgs e)
		{
			ViewDGR_LIST();
			SecureData();
			TXT_TEMP_PK.Text = "";
		}

		protected void BTN_RETURNTOBU_Click(object sender, System.EventArgs e)
		{
			conn.QueryString = "EXEC CHANNELING_TRACKUPDATE '" + Request.QueryString["regno"] + "','" + Request.QueryString["productid"] + "','" + Session["userid"] + "','" + Request.QueryString["prodseq"] + "','" + Request.QueryString["aano"] + "','TCHAN2.0'";
			conn.ExecuteQuery();
			Response.Redirect("ListComplyCOndition.aspx");
		}

		private void moveEndUserToBookingOrPending()
		{
			for (int i = 0; i < dgListEndUser.Items.Count; i++)
			{
				/*** DropDownList Assign To ***/
				RadioButton rdo_yes = (RadioButton) dgListEndUser.Items[i].Cells[3].FindControl("rdo_yes." + dgListEndUser.Items[i].Cells[1].Text.ToString());
				//RadioButton rdo_no = (RadioButton) dgListEndUser.Items[i].Cells[3].FindControl("rdo_no." + dgListEndUser.Items[i].Cells[1].Text.ToString());

				if(rdo_yes != null)
				{
					if(rdo_yes.Checked == true)
					{
						conn.QueryString = "EXEC CHANNELING_TRACKUPDATE_PERENDUSER '" + dgListEndUser.Items[i].Cells[1].Text.ToString() + "','" + Session["UserID"] + "','TCHAN7.0'";
						conn.ExecuteNonQuery();
					}
					else
					{
						conn.QueryString = "EXEC CHANNELING_TRACKUPDATE_PERENDUSER '" + dgListEndUser.Items[i].Cells[1].Text.ToString() + "','" + Session["UserID"] + "','TCHAN8.0'";
						conn.ExecuteNonQuery();
					}
				}
			}
		}

		protected void BTN_UPDATE_Click(object sender, System.EventArgs e)
		{
			/*conn.QueryString = "EXEC CHANNELING_TRACKUPDATE '" + Request.QueryString["regno"] + "','" + Request.QueryString["productid"] + "','" + Session["userid"] + "','" + Request.QueryString["prodseq"] + "','" + Request.QueryString["aano"] + "','TCHAN7.0'";
			conn.ExecuteQuery();*/

			conn.QueryString = "EXEC CHANNELING_TRACKUPDATE_PERENDUSER '" + Request.QueryString["regno"] + "','" + Session["UserID"] + "','TCHAN7.0'";
			conn.ExecuteNonQuery();

			//disini lempar ke booking atau ke list pending
			moveEndUserToBookingOrPending();

			Response.Redirect("ListComplyCOndition.aspx?msg=ok");
		}

		protected void BTN_PRINT_Click(object sender, System.EventArgs e)
		{
			Response.Write("<script for=window event=onload language='javascript'>PopupPage('LegalInvestRqstForm.aspx?regno=" + Request.QueryString["regno"] + "','800','400');</script>");
		}

		private void BindData(string dataGridName, string strconn)
		{
			if(strconn != "")
			{
				conn.QueryString = strconn;
				conn.ExecuteQuery();
			}

			System.Data.DataTable dt = new System.Data.DataTable();
			dt = conn.GetDataTable().Copy();

			System.Web.UI.WebControls.DataGrid dg = (System.Web.UI.WebControls.DataGrid)Page.FindControl(dataGridName);

			dg.DataSource = dt;				

			try
			{
				dg.DataBind();
			}
			catch 
			{
				dg.CurrentPageIndex = dg.PageCount - 1;
				dg.DataBind();
			}

			conn.ClearData();
		}

		private void dgListEndUser_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			switch (((LinkButton)e.CommandSource).CommandName)
			{
				case "yesall":
					selectAllYes();
					break;
				case "noall":
					selectAllNo();
					break;
			}
		}

		private void selectAllYes()
		{
			for(int i=0; i< dgListEndUser.Items.Count; i++)
			{
				string b = dgListEndUser.Items[i].Cells[1].Text.ToString();

				RadioButton rdo_yes = (RadioButton) dgListEndUser.Items[i].Cells[3].FindControl("rdo_yes." + dgListEndUser.Items[i].Cells[1].Text.ToString());
				RadioButton rdo_no = (RadioButton) dgListEndUser.Items[i].Cells[3].FindControl("rdo_no." + dgListEndUser.Items[i].Cells[1].Text.ToString());

				if(rdo_no != null && rdo_yes != null)
				{
					rdo_no.Checked = false;
					rdo_yes.Checked = true;
				}
			}
		}

		private void selectAllNo()
		{
			for(int i=0; i< dgListEndUser.Items.Count; i++)
			{
				RadioButton rdo_yes = (RadioButton) dgListEndUser.Items[i].Cells[3].FindControl("rdo_yes." + dgListEndUser.Items[i].Cells[1].Text.ToString());
				RadioButton rdo_no = (RadioButton) dgListEndUser.Items[i].Cells[3].FindControl("rdo_no." + dgListEndUser.Items[i].Cells[1].Text.ToString());

				if(rdo_no != null && rdo_yes != null)
				{
					rdo_no.Checked = true;
					rdo_yes.Checked = false;
				}
			}
		}
	}
}
