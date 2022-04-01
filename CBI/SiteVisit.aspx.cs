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

namespace SME.CBI
{
	/// <summary>
	/// Summary description for SiteVisit.
	/// </summary>
	public partial class SiteVisit : System.Web.UI.Page
	{
		protected Connection conn;
		protected Tools tool = new Tools();
		protected CommonForm.DocumentExport DocExport1;
		protected CommonForm.DocumentUpload DocUpload1;
		private string userid;
		
		protected void Page_Load(object sender, System.EventArgs e)
		{
			conn = (Connection) Session["Connection"];

			conn.QueryString = "SELECT CU_RM FROM CUSTOMER WHERE CU_REF = '" + Request.QueryString["curef"] + "'";
			conn.ExecuteQuery();
			userid = conn.GetFieldValue("CU_RM");

			if (!IsPostBack)
			{
				LBL_CUREF.Text = Request.QueryString["curef"];
				LBL_REGNO.Text = Request.QueryString["regnosite"];

				DDL_SV_DATE_MONTH.Items.Add(new ListItem("- Select -", ""));
				string nm_bln;
				for (int i=1; i<=12; i++)
				{
					nm_bln = DateAndTime.MonthName(i, false);
					DDL_SV_DATE_MONTH.Items.Add(new ListItem(nm_bln, i.ToString()));
				}

				DDL_TG_DATE_MONTH.Items.Add(new ListItem("- Select -", ""));
				string nm_blntg;
				for (int i=1; i<=12; i++)
				{
					nm_blntg = DateAndTime.MonthName(i, false);
					DDL_TG_DATE_MONTH.Items.Add(new ListItem(nm_blntg, i.ToString()));
				}

				ViewDataApplication();

				DocExport1.GroupTemplate = "SVPRINT";
				DocUpload1.GroupTemplate = "SVUPLOAD";
				DocUpload1.WithReadExcel = false;
			}
			secureData();
			ViewMenu();			

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

		private void secureData() 
		{
			string lkkn = Request.QueryString["lkkn"];

			if (lkkn == "0")
			{
				int index = -1;
				System.Web.UI.ControlCollection coll = this.Page.Controls;
				for(int j=0; j<coll.Count; j++) 
				{
					if (coll[j] is HtmlForm) 
					{
						index = j;
						break;
					}
				}

				for (int i = 0; i < coll[index].Controls.Count; i++) 
				{
					if (coll[index].Controls[i] is TextBox) 
					{
						TextBox txt = (TextBox) coll[index].Controls[i];
						txt.ReadOnly = true;
					}
					else if (coll[index].Controls[i] is DropDownList) 
					{
						DropDownList ddl = (DropDownList) coll[index].Controls[i];
						ddl.Enabled = false;
					}
					else if (coll[index].Controls[i] is Button)
					{
						Button btn = (Button) coll[index].Controls[i];
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
						for(int idg=0; idg < dg.Items.Count; idg++) 
						{
							dg.Items[idg].Cells[6].Text		= "Delete";
							dg.Items[idg].Cells[6].Enabled	= false;
						}
					}
					else if (coll[index].Controls[i] is HtmlTableRow) 
					{
						HtmlTableRow htr = (HtmlTableRow) coll[index].Controls[i];

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

		private void ViewDataApplication()
		{
			conn.QueryString = "select * from VW_CUST_FOR_SITEVISIT where AP_REGNO = '" + Request.QueryString["regnosite"] + "'";
			conn.ExecuteQuery();

			if(conn.GetRowCount() == 0)
			{
				conn.QueryString = "select * from VW_CUST_FOR_SITEVISIT where CU_REF = '" + Request.QueryString["curef"] + "'";
				conn.ExecuteQuery();
			}
			
			TXT_AP_RELMNGR.Text		= conn.GetFieldValue("SU_FULLNAME");
			TXT_BRANCH_CODE.Text	= conn.GetFieldValue("BRANCH_NAME");
			TXT_CU_NAME.Text		= conn.GetFieldValue("CU_NAME");
			TXT_CU_ADDR1.Text		= conn.GetFieldValue("CU_ADDR1");
			TXT_CU_ADDR2.Text		= conn.GetFieldValue("CU_ADDR2");
			TXT_CU_ADDR3.Text		= conn.GetFieldValue("CU_ADDR2");
			TXT_CU_CONTACTPERSON.Text	= conn.GetFieldValue("CU_CONTACTPERSON");
			TXT_GROUP.Text = conn.GetFieldValue("CU_GROUP");
			TXT_CREDIT_ANALIS.Text = conn.GetFieldValue("CREDIT_ANALIS");

			conn.QueryString = "select * from CUST_SITEVISIT where AP_REGNO = '" + Request.QueryString["regnosite"] + "'";
			conn.ExecuteQuery();
			
			if(conn.GetRowCount() > 0)
				BTN_PRINT.Enabled = true;


			TXT_SV_DATE_DAY.Text		= tool.FormatDate_Day(conn.GetFieldValue("SV_DATE"));
			DDL_SV_DATE_MONTH.SelectedValue = tool.FormatDate_Month(conn.GetFieldValue("SV_DATE"));
			TXT_SV_DATE_YEAR.Text	= tool.FormatDate_Year(conn.GetFieldValue("SV_DATE"));
			TXT_SV_NAME.Text		= conn.GetFieldValue("SV_NAME");
			TXT_SV_TUJUAN.Text		= conn.GetFieldValue("SV_TUJUAN");
			TXT_SV_NASABAH.Text		= conn.GetFieldValue("SV_NASABAH");
			TXT_SV_BANK.Text		= conn.GetFieldValue("SV_BANK");
			TXT_SV_OFFICE.Text		= conn.GetFieldValue("SV_OFFICE");
			TXT_SV_FACTORY.Text		= conn.GetFieldValue("SV_FACTORY");
			TXT_SV_MANAGEMENT.Text  = conn.GetFieldValue("SV_MANAGEMENT");
			TXT_SV_PRODUKSI.Text	= conn.GetFieldValue("SV_PRODUKSI");
			TXT_SV_PEMASARAN.Text	= conn.GetFieldValue("SV_PEMASARAN");
			TXT_SV_KEUANGAN.Text	= conn.GetFieldValue("SV_KEUANGAN");
			TXT_SV_AGUNAN.Text		= conn.GetFieldValue("SV_AGUNAN");
			TXT_SV_PERSOALAN.Text	= conn.GetFieldValue("SV_PERSOALAN");
			TXT_TG_DATE_DAY.Text		= tool.FormatDate_Day(conn.GetFieldValue("TG_DATE"));
			DDL_TG_DATE_MONTH.SelectedValue = tool.FormatDate_Month(conn.GetFieldValue("TG_DATE"));
			TXT_TG_DATE_YEAR.Text	= tool.FormatDate_Year(conn.GetFieldValue("TG_DATE"));
			
			conn.QueryString = "select * from application  where ap_sitevisitsta='1' and CU_REF = '" + Request.QueryString["curef"] + "'";
			conn.ExecuteQuery();

			if(conn.GetRowCount() > 0)
				BTN_UPDATE.Visible = false;


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
							strtemp = "regno=" + Request.QueryString["regno"] + "&curef="+Request.QueryString["curef"]+"&tc="+Request.QueryString["tc"]+"&lmsreg="+Request.QueryString["lmsreg"]+"&scr="+Request.QueryString["scr"];
						else	strtemp = "regno=" + Request.QueryString["regno"] + "&curef="+Request.QueryString["curef"]+"&mc="+Request.QueryString["mc"]+"&tc="+Request.QueryString["tc"]+"&lmsreg="+Request.QueryString["lmsreg"]+"&scr="+Request.QueryString["scr"];
						//t.ForeColor = Color.MidnightBlue; 
						if (conn.GetFieldValue(i,3).IndexOf("?lkkn=") < 0 && conn.GetFieldValue(i,3).IndexOf("&lkkn=") < 0) 
							strtemp = strtemp + "&lkkn=" + Request.QueryString["lkkn"];
						//strtemp = strtemp + "&de=" + Request.QueryString["de"];
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

		protected void BTN_SAVE_Click(object sender, System.EventArgs e)
		{
			//Tools.popMessage(this,"regnosite : " + Request.QueryString["regnosite"] + ",regno : " + Request.QueryString["curef"]);
			conn.QueryString = "exec VER_CUST_SITEVISIT '" +
				Request.QueryString["regnosite"]+ "', '" +
				Request.QueryString["curef"]+ "', "+
				tool.ConvertDate(TXT_SV_DATE_DAY.Text,DDL_SV_DATE_MONTH.SelectedValue,TXT_SV_DATE_YEAR.Text)+ ", '" +
				TXT_SV_NAME.Text+ "', '" +
				TXT_SV_TUJUAN.Text+ "', '" +
				TXT_SV_NASABAH.Text+ "', '" +
				TXT_SV_BANK.Text+ "', '" +
				TXT_SV_OFFICE.Text+ "', '" +
				TXT_SV_FACTORY.Text+ "', '" +
				TXT_SV_MANAGEMENT.Text+ "', '" +
				TXT_SV_PRODUKSI.Text+ "', '" +
				TXT_SV_PEMASARAN.Text+ "', '" +
                TXT_SV_KEUANGAN.Text+ "', '" +
				TXT_SV_AGUNAN.Text+ "', '" +
				TXT_SV_PERSOALAN.Text+ "', " +
				tool.ConvertDate(TXT_TG_DATE_DAY.Text,DDL_TG_DATE_MONTH.SelectedValue,TXT_TG_DATE_YEAR.Text);
				conn.ExecuteNonQuery();

			try
			{
				/// Site visit tanggal kunjungan
				/// 
				conn.QueryString = "SP_AUDITTRAIL_APP '" + 
					Request.QueryString["regnosite"] + "',null,null,null,'" + 
					Request.QueryString["curef"] + "','" + 
					Request.QueryString["tc"] + "','Site visit start date [" + TXT_SV_DATE_DAY.Text + "-" + DDL_SV_DATE_MONTH.SelectedValue + "-" + TXT_SV_DATE_YEAR.Text + "]', '" + 
					TXT_SV_DATE_DAY.Text + "-" + DDL_SV_DATE_MONTH.SelectedValue + "-" + TXT_SV_DATE_YEAR.Text + "', '" +
					userid + "',null,null";
				conn.ExecTrans();

				/// Site visit tanggal selesai
				/// 
				conn.QueryString = "SP_AUDITTRAIL_APP '" + 
					Request.QueryString["regnosite"] + "',null,null,null,'" + 
					Request.QueryString["curef"] + "','" + 
					Request.QueryString["tc"] + "','Site visit finish date [" + TXT_TG_DATE_DAY.Text + "-" + DDL_TG_DATE_MONTH.SelectedValue + "-" + TXT_TG_DATE_YEAR.Text + "]', '" +  
					TXT_SV_DATE_DAY.Text + "-" + DDL_SV_DATE_MONTH.SelectedValue + "-" + TXT_SV_DATE_YEAR.Text + "', '" +
					userid + "',null,null";
				conn.ExecTrans();

				conn.ExecTran_Commit();
			} 
			catch (Exception ex)
			{
				if (conn != null) conn.ExecTran_Rollback();
				try { ExceptionHandling.Handler.saveExceptionIntoWindowsLog(ex, Request.Path, "AP_REGNO: " + Request.QueryString["regnosite"]); } 
				catch {}
			}

			BTN_UPDATE.Enabled = true;
			BTN_PRINT.Enabled = true;

			ViewDataApplication();
		}

		protected void BTN_BACK_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			Tools.popMessage(this, DMS.CuBESCore.Logic.backLink(Request.QueryString["tc"].ToString(), conn));
			Response.Redirect("/SME/CBI/" + DMS.CuBESCore.Logic.backLink(Request.QueryString["tc"].ToString(), conn));
		}

		protected void BTN_PRINT_Click(object sender, System.EventArgs e)
		{
			//ahmad
			//Response.Write("<script language='javascript'>window.open('SiteVisitPrint.aspx?regno="+ LBL_REGNO.Text +"','SiteVisitPrint','status=no,scrollbars=yes,width=1000,height=700');</script>"); 

			Response.Redirect("SiteVisitPrint.aspx?&regno=" + Request.QueryString["regnosite"]);

		}

		protected void BTN_UPDATE_Click(object sender, System.EventArgs e)
		{
			conn.QueryString = "update application set ap_sitevisitsta='1' where ap_regno='" + Request.QueryString["regnosite"] + "'";
			conn.ExecuteNonQuery();

			//////////////////////////////////////////////
			/// audit trail			 
			try
			{
				conn.QueryString = "SP_AUDITTRAIL_APP '" + 
					Request.QueryString["regnosite"] + "',null,null,null,'" + 
					Request.QueryString["curef"] + "','" + 
					Request.QueryString["tc"] + "','Update LKKN ','"+ 
					Session["FullName"].ToString() + "','" +  
					userid + "',null,null";
				conn.ExecuteNonQuery();
			}
			catch (Exception ex)
			{
				try { ExceptionHandling.Handler.saveExceptionIntoWindowsLog(ex, Request.Path, "AP_REGNO: " + Request.QueryString["regno"]); } 
				catch {}
			}


			BTN_UPDATE.Visible = false;
		}

	}
}
