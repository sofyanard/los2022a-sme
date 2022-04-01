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


namespace SME.CreditOperations.NotaryAssignment
{
	/// <summary>
	/// Summary description for DetailLegalSigning_Data.
	/// </summary>
	public partial class DetailLegalSigning_Data : System.Web.UI.Page
	{

		protected Connection conn;
		//protected Connection conn = new Connection("Data Source=10.123.12.30;Initial Catalog=SMEDEV;uid=sa;pwd=");
		protected Tools tool = new Tools();

		protected void Page_Load(object sender, System.EventArgs e)
		{
			conn = (Connection) Session["Connection"];

			if (!Logic.AllowAccess(Session["GroupID"].ToString(), Request.QueryString["mc"], conn))
				Response.Redirect("/SME/Restricted.aspx");

			if (!IsPostBack)
			{
				LBL_REGNO.Text = Request.QueryString["regno"];
				LBL_CUREF.Text = Request.QueryString["curef"];
				LBL_TC.Text = Request.QueryString["tc"];

				//init rfrating
				conn.QueryString = "SELECT RATEID, RATEDESC FROM RFRATING ";
				conn.ExecuteQuery();
				DDL_ICRATE.Items.Clear();
				DDL_ICRATE.Items.Add(new ListItem("-- Pilih --", ""));
				for (int i=0; i<conn.GetRowCount(); i++)
					DDL_ICRATE.Items.Add(new ListItem(conn.GetFieldValue(i, 1), conn.GetFieldValue(i, 0)));

				//init CUR_ID
				GlobalTools.fillRefList(DDL_CP_CUR, "select currencyid, currencydesc from rfcurrency where active = '1' ", true, conn);

				/***
				conn.QueryString = "select currencyid, currencydesc from rfcurrency where active = '1' ";
				conn.ExecuteQuery();
				DDL_CP_CUR.Items.Clear();
				DDL_CP_CUR.Items.Add(new ListItem("- PILIH -", ""));
				for (int i = 0; i < conn.GetRowCount(); i++)
				{
					String s0 = conn.GetFieldValue(i,0),
						s1 = conn.GetFieldValue(i,1);
					ListItem li = new ListItem(s1,s0);
					DDL_CP_CUR.Items.Add(li);
				}**/


				Tools.initDateForm(TXT_DATESTART_DAY, DDL_DATESTART_MONTH, TXT_DATESTART_YEAR, false);
				Tools.initDateForm(TXT_DATEEND_DAY, DDL_DATEEND_MONTH, TXT_DATEEND_YEAR, false);

				ViewData();
				fillInsrComp();
				bindData();
				ViewFacility();
			}
			SecureData();
			ViewMenu();
			DataGrid1.PageIndexChanged += new DataGridPageChangedEventHandler(this.Grid_Change);
			BTN_UPDATE.Attributes.Add("onclick","if(!update()){return false;};");
		}

		private void SecureData() 
		{
			string na = Request.QueryString["na"];
			if (na == "0")
			{
				//.Visible	= false;
				TBL_ENTRY.Visible = false;
				BTN_TAMBAH.Visible	= false;
				BTN_CANCEL.Visible	= false;
				
				try 
				{
					for(int i=0; i<DataGrid1.Items.Count; i++) 
					{
						LinkButton edit = (LinkButton) DataGrid1.Items[i].FindControl("BTNEDIT");
						LinkButton del  = (LinkButton) DataGrid1.Items[i].FindControl("BTNDEL");
						LinkButton print =  (LinkButton) DataGrid1.Items[i].FindControl("BTNLNK_PRINT");

						edit.Enabled	= false;
						del.Enabled		= false;
						print.Enabled	= false;
					}
				}
				catch {}
			}
			if (na == "2")
			{
				//Datagrid2.Enabled = false;
				for (int i = 0; i < Datagrid2.Items.Count; i++)
				{
					RadioButtonList rbl = (RadioButtonList)Datagrid2.Items[i].Cells[4].FindControl("RBL_FAC");
					rbl.Enabled = false;
				}
			}
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
						if (conn.GetFieldValue(i,3).IndexOf("na=") < 0) strtemp += "&" + Request.QueryString["na"];
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

		private void ViewData()
		{
			conn.QueryString = "select * from VW_INFOUMUM "+
				"where AP_REGNO = '"+ LBL_REGNO.Text.Trim() +"' ";
			conn.ExecuteQuery();
			TXT_AP_REGNO.Text = conn.GetFieldValue("AP_REGNO");
			TXT_CU_REF.Text = conn.GetFieldValue("CU_REF");
			string AP_SIGNDATE = conn.GetFieldValue("AP_SIGNDATE");
			TXT_AP_SIGNDATE.Text = tool.FormatDate(AP_SIGNDATE);
			TXT_PROGRAMDESC.Text = conn.GetFieldValue("PROGRAMDESC");
			TXT_BRANCH_NAME.Text = conn.GetFieldValue("BRANCH_NAME");
			TXT_AP_TMLDRNM.Text = conn.GetFieldValue("AP_TMLDRNM");
			TXT_AP_RMNM.Text = conn.GetFieldValue("AP_RMNM");
			TXT_BU_DESC.Text = conn.GetFieldValue("BU_DESC");
			TXT_CU_NAME.Text = conn.GetFieldValue("CU_NAME");
			TXT_CU_ADDR1.Text = conn.GetFieldValue("CU_ADDR1");
			TXT_CU_ADDR2.Text = conn.GetFieldValue("CU_ADDR2");
			TXT_CU_ADDR3.Text = conn.GetFieldValue("CU_ADDR3");
			TXT_CU_CITYNM.Text = conn.GetFieldValue("CU_CITYNM");
			TXT_CU_PHN.Text = conn.GetFieldValue("CU_PHN");
			TXT_BUSSTYPEDESC.Text = conn.GetFieldValue("BUSSTYPEDESC");
		}

		private void fillInsrComp()
		{
			//--- Modified By Yudi (2004-08-24) ---
			/***
			conn.QueryString = "select distinct IC_ID, IC_DESC "+
				"from VW_CREOPR_NOTARYASSIGN_RFINSRCOMPANY_INSURANCE ";
			***/
			conn.QueryString = "select distinct IC_ID, IC_ID + ' - ' + IC_DESC "+
				"from VW_CREOPR_NOTARYASSIGN_RFINSRCOMPANY_INSURANCE ";
			conn.ExecuteQuery();
			DDL_AP_INSRCOMP.Items.Clear();
			DDL_AP_INSRCOMP.Items.Add(new ListItem("-- Pilih --",""));
			for (int i = 0; i < conn.GetRowCount(); i++)
			{
				String s0 = conn.GetFieldValue(i,0),
					s1 = conn.GetFieldValue(i,1);
				ListItem li = new ListItem(s1,s0);
				DDL_AP_INSRCOMP.Items.Add(li);
			}
			fillInsrType();
		}

		private void fillInsrType()
		{
			DDL_CP_INSRTYPE.Items.Clear();
			if (DDL_AP_INSRCOMP.SelectedValue.Trim() == "")
				return;
			conn.QueryString = "select distinct IT_ID, IT_DESC from VW_CREOPR_NOTARYASSIGN_RFINSRTYPE_INSURANCE "+
				"where IC_ID = '" + DDL_AP_INSRCOMP.SelectedValue.Trim() + "' ";
			conn.ExecuteQuery();
			for (int i = 0; i < conn.GetRowCount(); i++)
			{
				String s0 = conn.GetFieldValue(i,0),
					s1 = conn.GetFieldValue(i,1);
				ListItem li = new ListItem(s1,s0);
				DDL_CP_INSRTYPE.Items.Add(li);
			}
		}

		private void bindData()
		{
			DataTable dt = new DataTable();
			DataRow dr;
			conn.QueryString = "SELECT SEQ, IC_DESC, IT_DESC, ALI_AMOUNT, ALI_PERCENTAGE, ALI_PREMI, "+
				"IC_ID, IT_ID, ALI_ICRATE, CURRENCYID, CURRENCYDESC, "+
				"ALI_POLICYNO, ALI_DATESTART, ALI_DATEEND " +
				"FROM VW_CREOPR_NOTARYASSIGN_INSURANCE WHERE AP_REGNO = '" + Request.QueryString["regno"] +
				"' ORDER BY IC_DESC ";
			conn.ExecuteQuery();
			dt.Columns.Add(new DataColumn("SEQ"));
			dt.Columns.Add(new DataColumn("INSRCOMPDESC"));
			dt.Columns.Add(new DataColumn("INSRTYPEDESC"));
			dt.Columns.Add(new DataColumn("AN_VALUE"));
			dt.Columns.Add(new DataColumn("AN_PERCENTAGE"));
			dt.Columns.Add(new DataColumn("AN_PREMI"));
			dt.Columns.Add(new DataColumn("IC_ID"));
			dt.Columns.Add(new DataColumn("IT_ID"));
			dt.Columns.Add(new DataColumn("RATE"));
			dt.Columns.Add(new DataColumn("CUR_ID"));
			dt.Columns.Add(new DataColumn("AN_CUR"));
			dt.Columns.Add(new DataColumn("AN_POLICYNO"));
			dt.Columns.Add(new DataColumn("AN_DATESTART"));
			dt.Columns.Add(new DataColumn("AN_DATEEND"));
			for (int i = 0; i < conn.GetRowCount(); i++) 
			{
				dr = dt.NewRow();
				for (int j = 0; j < conn.GetColumnCount(); j++)
				{
					dr[j] = conn.GetFieldValue(i,j);
				}
				dt.Rows.Add(dr);
			}
			DataGrid1.DataSource = new DataView(dt);
			try 
			{
				DataGrid1.DataBind();
			} 
			catch 
			{
				DataGrid1.CurrentPageIndex = 0;
				DataGrid1.DataBind();
			}

			for (int j = 0; j < DataGrid1.Items.Count; j++)
			{
				DataGrid1.Items[j].Cells[5].Text = tool.MoneyFormat(DataGrid1.Items[j].Cells[5].Text );
				DataGrid1.Items[j].Cells[8].Text = tool.MoneyFormat(DataGrid1.Items[j].Cells[8].Text );
				DataGrid1.Items[j].Cells[9].Text = tool.MoneyFormat(DataGrid1.Items[j].Cells[9].Text );
			}
		}

		private void clearEditBoxes()
		{
			try
			{
				DDL_AP_INSRCOMP.SelectedIndex = 0;
				DDL_CP_INSRTYPE.Items.Clear();
				DDL_ICRATE.SelectedIndex = 0;
				DDL_DATESTART_MONTH.SelectedIndex = 0;
				DDL_DATEEND_MONTH.SelectedIndex = 0;
				DDL_CP_CUR.SelectedIndex = 0;
			}
			catch {}
			TXT_CP_POLICYNO.Text = "";
			TXT_AP_INSRAMNT.Text = "";
			TXT_AP_INSRPREMI.Text = "";
			TXT_AP_INSRPCT.Text = "";
			TXT_DATESTART_DAY.Text = "";
			TXT_DATESTART_YEAR.Text = "";
			TXT_DATEEND_DAY.Text = "";
			TXT_DATEEND_YEAR.Text = "";
			LBL_H_SEQ.Text = "0";
			BTN_TAMBAH.Text = "Tambah";
			BTN_CANCEL.Visible = false;
		}

		private bool checkNotaryAssignOK()
		{
			conn.QueryString = "select ap_regno, productid, an_status, ap_signby, " +
				"apl_beaadm, apl_beaprovisi, acl_ikatid, ntid, apl_notarystatus, " +
				"acl_notarystatus, spk , apptype from VW_CREOPR_NOTARYASSIGN_CHECKLACKING " +
				"where ap_regno = '" + Request.QueryString["regno"] + "' " ;
			conn.ExecuteQuery();
			if (conn.GetRowCount() > 0)
			{
				string str = ""; 
				/*if ((conn.GetFieldValue(0,4).Trim() == "")||(conn.GetFieldValue(0,5).Trim() == "")||
					(conn.GetFieldValue(0,4).Trim() == "0")||(conn.GetFieldValue(0,5).Trim() == "0"))
				{
					if (conn.GetFieldValue(0, "spk") != "1")
						return true;
					else if (conn.GetFieldValue(0, "apptype") != "01")
						return true;
					str = "Data biaya-biaya belum lengkap.";
				}*/
				if (conn.GetFieldValue(0,4).Trim() == "")		//apl_beaadm = alias apl_pkno pada view 
				{
					str = "Data biaya-biaya belum lengkap.";
				}
				else if (conn.GetFieldValue(0,6).Trim() == "")
					str = "Data Pengikatan belum lengkap.";
				else if ((conn.GetFieldValue(0,7).Trim() == "")&&
					((conn.GetFieldValue(0,8).Trim() == "0")||(conn.GetFieldValue(0,9).Trim() == "0")))
					str = "Data Notary belum lengkap.";

				GlobalTools.popMessage(this, str);
			}
			return (conn.GetRowCount() == 0);
		}

		private bool checkNotaryAssignOK2()
		{
			bool STAUPDATE = false;
			try
			{
				conn.QueryString = "EXEC NOTARYASSIGN_CHECKMANDATORY '" + Request.QueryString["regno"] + "'";
				conn.ExecuteQuery();
			}
			catch (Exception ex)
			{
				string errmsg = ex.Message.Replace("'","");
				if (errmsg.IndexOf("Last Query:") > 0)
					errmsg = errmsg.Substring(0, errmsg.IndexOf("Last Query:"));
				GlobalTools.popMessage(this, errmsg);
				STAUPDATE = false;
			}
			if (conn.GetRowCount() != 0)
			{
				if (conn.GetFieldValue("CHECKSTATUS") == "1")
				{
					STAUPDATE = true;
				}
			}

			return STAUPDATE;
		}

		private string validateSQLString(string str)
		{
			return str.Replace("'", "''");
		}

		private void ViewFacility()
		{
			try 
			{
				conn.QueryString = "SELECT * FROM VW_NOTARYASSIGN_VIEWFAC WHERE AP_REGNO = '" + Request.QueryString["regno"] + 
					"' ORDER BY PROD_SEQ, APPTYPE";
				conn.ExecuteQuery();
			
				DataTable dt = new DataTable();
				dt = conn.GetDataTable().Copy();
				Datagrid2.DataSource = dt;
				try 
				{
					Datagrid2.DataBind();
				} 
				catch 
				{
					Datagrid2.CurrentPageIndex = 0;
					Datagrid2.DataBind();
				}
			} 
			catch (Exception ex) 
			{
				Response.Write("<!--" + ex.Message + "-->");
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
			this.DataGrid1.ItemCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.DataGrid1_ItemCommand);
			this.Datagrid2.ItemCreated += new System.Web.UI.WebControls.DataGridItemEventHandler(this.Datagrid2_ItemCreated);
			this.Datagrid2.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.Datagrid2_PageIndexChanged);
			this.Datagrid2.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(this.Datagrid2_ItemDataBound);

		}
		#endregion

		void Grid_Change(Object sender, DataGridPageChangedEventArgs e) 
		{
			// Set CurrentPageIndex to the page the user clicked.
			DataGrid1.CurrentPageIndex = e.NewPageIndex;
			// Re-bind the data to refresh the DataGrid control. 
			bindData();	
		}

		private void DataGrid1_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			string regno, seq, cu_ref;
			switch(((LinkButton)e.CommandSource).CommandName)
			{
				case "print":
					//Response.Redirect("../CoverNote/AsuransiJiwa.aspx?ap_regno=" + LBL_REGNO.Text + "&cu_ref=" + LBL_CUREF.Text + "&seq=" + e.Item.Cells[0].Text.Trim());
					regno = TXT_AP_REGNO.Text.Trim();
					cu_ref = this.TXT_CU_REF.Text.Trim();			
					seq = e.Item.Cells[0].Text.Trim();
					Response.Write("<script language='javascript'>window.open('../CoverNote/AsuransiJiwa.aspx?seq=" + seq + "&regno=" + regno + "&cu_ref=" + cu_ref + "','AsuransiJiwa','status=no,scrollbars=yes,width=800,height=600');</script>");
					break;

				case "delete":
					regno = TXT_AP_REGNO.Text.Trim();
						seq = e.Item.Cells[0].Text.Trim();
					//delete data
					conn.QueryString = "delete from APPLIFEINSURANCE where AP_REGNO = '" +
						regno + "' AND SEQ = " + seq;
					conn.ExecuteNonQuery();
					bindData();
					break;

				case "edit":
					LBL_H_SEQ.Text = e.Item.Cells[0].Text.Trim();
					try
					{
						DDL_AP_INSRCOMP.SelectedValue = e.Item.Cells[10].Text.Trim();
						fillInsrType();
					} 
					catch {}
					try
					{
						DDL_CP_INSRTYPE.SelectedValue = e.Item.Cells[11].Text.Trim();
					} 
					catch {}
					try
					{
						DDL_ICRATE.SelectedValue = e.Item.Cells[12].Text.Trim();
					} 
					catch {}
					try
					{
						DDL_CP_CUR.SelectedValue = e.Item.Cells[13].Text.Trim();
					} 
					catch {}
					TXT_AP_INSRAMNT.Text = e.Item.Cells[5].Text.Trim();
					try
					{
						TXT_DATESTART_DAY.Text = tool.FormatDate_Day(e.Item.Cells[6].Text.Trim());
						DDL_DATESTART_MONTH.SelectedValue = tool.FormatDate_Month(e.Item.Cells[6].Text.Trim());
						TXT_DATESTART_YEAR.Text = tool.FormatDate_Year(e.Item.Cells[6].Text.Trim());
					} 
					catch {}
					try
					{
						TXT_DATEEND_DAY.Text = tool.FormatDate_Day(e.Item.Cells[7].Text.Trim());
						DDL_DATEEND_MONTH.SelectedValue = tool.FormatDate_Month(e.Item.Cells[7].Text.Trim());
						TXT_DATEEND_YEAR.Text = tool.FormatDate_Year(e.Item.Cells[7].Text.Trim());
					} 
					catch {}
					TXT_AP_INSRPCT.Text = e.Item.Cells[8].Text.Trim();
					TXT_AP_INSRPREMI.Text = e.Item.Cells[9].Text.Trim();
					TXT_CP_POLICYNO.Text = e.Item.Cells[3].Text.Trim();
					BTN_TAMBAH.Text = "Save";
					BTN_CANCEL.Visible = true;
					break;

				default:
					// Do nothing.
					break;
			}

		}

		protected void BTN_TAMBAH_Click(object sender, System.EventArgs e)
		{
			string str = "";
			double val;
			string regno=TXT_AP_REGNO.Text.Trim(),
				seq = LBL_H_SEQ.Text.Trim(),
				compname=DDL_AP_INSRCOMP.SelectedValue.Trim(),
				insrtype=DDL_CP_INSRTYPE.SelectedValue.Trim(),
				insramount=tool.ConvertFloat(TXT_AP_INSRAMNT.Text.Trim()),
				insrpct=TXT_AP_INSRPCT.Text.Trim(),
				insrpremi=tool.ConvertFloat(TXT_AP_INSRPREMI.Text.Trim()),
				rate=DDL_ICRATE.SelectedValue.Trim(),
				insrpolicyno=validateSQLString(TXT_CP_POLICYNO.Text.Trim()),
				insrcur=DDL_CP_CUR.SelectedValue.Trim(),
				insrdatestart="",
				insrdateend="",
				premi = tool.ConvertFloat(TXT_AP_INSRPREMI.Text.Trim());

			try
			{
				insrdatestart=Tools.toSQLDate(TXT_DATESTART_DAY,DDL_DATESTART_MONTH,TXT_DATESTART_YEAR);
			}
			catch {}
			try
			{
				insrdateend=Tools.toSQLDate(TXT_DATEEND_DAY,DDL_DATEEND_MONTH,TXT_DATEEND_YEAR);
			}
			catch {}

			if (insrpct.Trim() == "") insrpct = "0";
			if (compname == "")
				str += "Nama Perusahaan Asuransi harus dipilih! ";
			if (Request.QueryString["na"] != "0")
			{
				if(TXT_CP_POLICYNO.Text.Trim() == "")
					str += "No Polis harus diisi! ";
				if(DDL_CP_CUR.SelectedValue.Trim() == "")
					str += "Mata uang harus dipilih! ";
				val = 0;
				try {val = double.Parse(insramount);} 
				catch {}
				if (val <= 0) str += "Nilai Pertanggungan harus diisi! ";
				val = 0;

				try { val = double.Parse(premi); }
				catch {}
				if (val <= 0) str += "Premi harus diisi! ";
				val = 0;

				try 
				{
					if((TXT_DATESTART_DAY.Text.Trim()!="")&&(TXT_DATESTART_YEAR.Text.Trim()!="")&&
						(DDL_DATESTART_MONTH.SelectedValue.Trim()!="")) val=1;
				}
				catch{}
				if (val <= 0) str += "Tanggal mulai harus diisi! ";
				val = 0;
				try 
				{
					if((TXT_DATEEND_DAY.Text.Trim()!="")&&(TXT_DATEEND_YEAR.Text.Trim()!="")&&
						(DDL_DATEEND_MONTH.SelectedValue.Trim()!="")) val=1;
				}
				catch{}
				if (val <= 0) str += "Tanggal akhir harus diisi! ";
				val = 0;
				try {val = double.Parse(insrpct);} 
				catch {}
				if ((val < 0)||(val > 100)) str += "Persentase Pertanggungan harus diisi dan tidak boleh lebih dari 100%! ";
			}
			if (str != "")
			{
				GlobalTools.popMessage(this, str);
				return;
			}

			if (rate.Trim() == "")
				rate = "NULL";
			else
				rate = "'" + rate + "'";

			if (insrdatestart.Trim() == "")
				insrdatestart = "NULL";
			else
			{
				if (!Tools.isDateValid(this,TXT_DATESTART_DAY.Text,DDL_DATESTART_MONTH.SelectedValue,TXT_DATESTART_YEAR.Text))
				{
					GlobalTools.popMessage(this, "Start date is not valid!");
					return;
				}
				insrdatestart = "'" + insrdatestart + "'";
			}

			if (insrdateend.Trim() == "")
				insrdateend = "NULL";
			else
			{
				if (!Tools.isDateValid(this,TXT_DATEEND_DAY.Text,DDL_DATEEND_MONTH.SelectedValue,TXT_DATEEND_YEAR.Text))
				{
					GlobalTools.popMessage(this, "End date is not valid!");
					return;
				}
				insrdateend = "'" + insrdateend + "'";
			}

			if (insrcur.Trim() == "")
				insrcur = "NULL";
			else
				insrcur = "'" + insrcur + "'";

			insrpct = tool.ConvertFloat(insrpct);

			if (insramount.Trim() == "") insramount = "0";
			if (insrpct.Trim() == "") insrpct = "0";
			if (insrpremi.Trim() == "") insrpremi = "0";

			conn.QueryString = "exec NA_INSURANCE_SAVE '" + regno + "', " + seq + ", '" +
				compname + "', '" + insrtype + "', '" + insrpolicyno + "', " + insrcur + ", " +
				insramount + ", " + insrdatestart + ", " + insrdateend + ", " + 
				insrpct + ", " + insrpremi + ", " + rate ;
			conn.ExecuteNonQuery();
			clearEditBoxes();
			bindData();

			Tools.initDateForm(TXT_DATESTART_DAY, DDL_DATESTART_MONTH, TXT_DATESTART_YEAR, false);
			Tools.initDateForm(TXT_DATEEND_DAY, DDL_DATEEND_MONTH, TXT_DATEEND_YEAR, false);
		}

		protected void DDL_AP_INSRCOMP_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			fillInsrType();
		}

		protected void BTN_CANCEL_Click(object sender, System.EventArgs e)
		{
			clearEditBoxes();
		}

		protected void BTN_BACK_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			Response.Redirect("/SME/" + DMS.CuBESCore.Logic.backLink(Request.QueryString["tc"].ToString(), conn));
		}

		protected void BTN_UPDATE_Click(object sender, System.EventArgs e)
		{
			if (!checkNotaryAssignOK2()) return;

//			//////////////////////////////////////////////////////////
//			///	sebelum update status, cek dulu apakah aplikasi ybs
//			///	adalah sub aplikasi
//			///	Kalau iya, update dulu APPTRACK dan TRACKHISTORY
//			///	sesuai dengan track sekarang
//			///	
//			conn.QueryString = "exec NA_SUBAPPLICATION_CEK '" + 
//				LBL_REGNO.Text + "', '" + 
//				LBL_TC.Text + "', '" + 
//				Session["UserID"].ToString() + "'";
//			conn.ExecuteNonQuery();
//			///////////////////////////////////////////////////////////

			/* 2010-07-29 Sofyan - ILP Enhancement 2010 Fase 2
			 * bisa di-break per facility, kalau ada facility yg sudah di-approve tapi nggak jadi PK
			 * yg ini nggak dipakai, diganti dg procedure di bawahnya
			 * 
			DataTable dt;
			conn.QueryString = "select apptype, productid, PROD_SEQ from custproduct where ap_regno='" + Request.QueryString["regno"] +
				"' AND isnull(cp_reject,'0') <> '1' and isnull(cp_cancel,'0') <> '1'";
			conn.ExecuteQuery();
			dt = conn.GetDataTable().Copy();
			for (int i = 0; i < dt.Rows.Count; i++)
			{
				conn.QueryString = "exec TRACKUPDATE '" + 
									Request.QueryString["regno"] + "', '" +
									dt.Rows[i][1].ToString() + "', '" + 
									dt.Rows[i][0].ToString() + "', '" + 
									Session["UserID"].ToString() + "', '" + 
									dt.Rows[i]["PROD_SEQ"].ToString() + "','"+
									Request.QueryString["tc"].Trim() +"'";
				conn.ExecuteNonQuery();
			}
			*/

			for (int i = 0; i < Datagrid2.Items.Count; i++)
			{
				try
				{
					string isconfirm = null;
					RadioButtonList rbl = (RadioButtonList)Datagrid2.Items[i].Cells[4].FindControl("RBL_FAC");
					if (rbl.SelectedValue == "1")
						isconfirm = "1";
					else if (rbl.SelectedValue == "0")
						isconfirm = "0";
					
					conn.QueryString = "exec NOTARYASSIGN_UPDATESTATUS '" +
						Request.QueryString["regno"] + "', '" +
						Datagrid2.Items[i].Cells[0].Text.Trim() + "', '" + 
						Datagrid2.Items[i].Cells[1].Text.Trim() + "', '" + 
						Datagrid2.Items[i].Cells[2].Text.Trim() + "', '" +
						isconfirm + "', '" +
						Session["UserID"].ToString() + "'";
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


			////////////////////////////////////////////////////
			/// mengupdate track next by
			/// 
			conn.QueryString = "exec TRACKNEXTBY_SET_NA '" + Request.QueryString["regno"] + "'";
			conn.ExecuteNonQuery();

			string msg = getNextStepMsg(Request.QueryString["regno"], Request.QueryString["tc"]);
			Response.Redirect("NotaryAssignmentList.aspx?tc=" + Request.QueryString["tc"] + "&mc=" + Request.QueryString["mc"] + "&msg=" + msg);
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

        public string popUp = "";
        protected void BTN_RETURNTOBU_Click(object sender, System.EventArgs e)
		{
			Response.Write("<script for=window event=onload language='javascript'>PopupPage('../../Approval/AcqInfo.aspx?regno=" + LBL_REGNO.Text + "&curef=" + LBL_CUREF.Text + "&aprv=CO&theForm=Form1&theObj=TXT_TEMP', '800','300');</script>");
            popUp = "<script for=window event=onload language='javascript'>PopupPage('../../Approval/AcqInfo.aspx?regno=" + LBL_REGNO.Text + "&curef=" + LBL_CUREF.Text + "&aprv=CO&theForm=Form1&theObj=TXT_TEMP', '800','300');</script>";
		}

		protected void TXT_TEMP_TextChanged(object sender, System.EventArgs e)
		{
			if (TXT_TEMP.Text != "") 
			{
				string msg = "";
				msg = "Application acquire information from " + TXT_TEMP.Text + " !";
				Response.Redirect("NotaryAssignmentList.aspx?tc=" + Request.QueryString["tc"] + "&mc=" + Request.QueryString["mc"] + "&msg=" + msg);
			}
		}

		private void Datagrid2_ItemCreated(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			RadioButtonList rbl = (RadioButtonList) e.Item.FindControl("RBL_FAC");
			if (rbl != null)
			{
				rbl.AutoPostBack = true;
				rbl.SelectedIndexChanged += new System.EventHandler(this.rbl_SelectedIndexChanged);
			}
		}

		private void rbl_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			//Find the current selected RadioButton
			RadioButtonList rbl1 = (RadioButtonList)sender;

			foreach(DataGridItem dgitem in Datagrid2.Items)
			{                
				//Find the previous selected RadioButton
				RadioButtonList rbl2 = (RadioButtonList)dgitem.FindControl("RBL_FAC");

				if( rbl2.Equals(rbl1) )
				{                    
					try
					{
						string isconfirm = null;
						if (rbl2.SelectedValue == "1")
							isconfirm = "1";
						else if (rbl2.SelectedValue == "0")
							isconfirm = "0";

						conn.QueryString = "exec NOTARYASSIGN_CONFIRM '" +
							Request.QueryString["regno"] + "', '" +
							dgitem.Cells[0].Text.Trim() + "', '" + 
							dgitem.Cells[1].Text.Trim() + "', '" + 
							dgitem.Cells[2].Text.Trim() + "', '" +
							isconfirm + "', '" +
							Session["UserID"].ToString() + "'";
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
			}
		}

		private void Datagrid2_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			switch (e.Item.ItemType)
			{
				case ListItemType.AlternatingItem:
				case ListItemType.EditItem:
				case ListItemType.Item:
				case ListItemType.SelectedItem:
					try
					{
						RadioButtonList rbl = (RadioButtonList) e.Item.FindControl("RBL_FAC");
						if (rbl != null)
						{
							if (e.Item.Cells[5].Text.Trim() == "1")
							{
								rbl.SelectedValue = "1";
							}
							else if (e.Item.Cells[5].Text.Trim() == "0")
							{
								rbl.SelectedValue = "0";
							}

							if (e.Item.Cells[6].Text.Trim() != "1")
							{
								rbl.Enabled = false;
							}
						}
					} 
					catch {}
					break;
				case ListItemType.Footer:
					break;
				default:
					break;
			}
		}

		private void Datagrid2_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			Datagrid2.CurrentPageIndex = e.NewPageIndex;
			ViewFacility();
		}
	}
}
