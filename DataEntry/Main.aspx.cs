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

namespace SME.DataEntry
{
	/// <summary>
	/// Summary description for Main.
	/// </summary>
	public partial class Main : System.Web.UI.Page
	{
		protected Tools tool = new Tools();
		protected Connection conn;
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			conn = (Connection) Session["Connection"];
		
			if (Request.QueryString["de"] == "1")
				if (!Logic.AllowAccess(Session["GroupID"].ToString(), Request.QueryString["mc"], conn))
					Response.Redirect("/SME/Restricted.aspx");

			if (!IsPostBack)
			{
				//DDL_AP_DATALNGKP_MONTH.Items.Add(new ListItem("- SELECT -", ""));
				DDL_AP_RECVDATE_MONTH.Items.Add(new ListItem("- SELECT -", ""));
				for (int i = 1; i <= 12; i++)
				{
					//DDL_AP_DATALNGKP_MONTH.Items.Add(new ListItem(DateAndTime.MonthName(i, false), i.ToString()));
					DDL_AP_RECVDATE_MONTH.Items.Add(new ListItem(DateAndTime.MonthName(i, false), i.ToString()));
				}
				/*
				ddl_PRODUCTID.Items.Add(new ListItem("- SELECT -", ""));
				ddl_APPTYPE.Items.Add(new ListItem("- SELECT -", ""));
				conn.QueryString = "select * from RFPRODUCT where ACTIVE = '1'";
				conn.ExecuteQuery();
				for (int i = 0; i < conn.GetRowCount(); i++)
					ddl_PRODUCTID.Items.Add(new ListItem(conn.GetFieldValue(i,1), conn.GetFieldValue(i,0)));

				conn.QueryString = "select * from RFAPPLICATIONTYPE where ACTIVE = '1'";
				conn.ExecuteQuery();
				for (int i = 0; i < conn.GetRowCount(); i++)
					ddl_APPTYPE.Items.Add(new ListItem(conn.GetFieldValue(i,1), conn.GetFieldValue(i,0)));
				*/

				ViewData();
				ViewProductList();
				SecureData();
			}
			ViewMenu();
			updatestatus.Attributes.Add("onclick","if(!update()){return false;};");
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

		private void SecureData() 
		{
			// Jika yang memanggil bukan dalam scope DataEntry, maka disable semua control input
			// Flag :
			//		Nama  = de
			//		Value ==  1 --> Parent DataEntry
			//			  !=  1 --> Parent non-DataEntry
			string de = Request.QueryString["de"];
			if (de != "1") 
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
	
				/// Kalau ada tidak ketemu HtmlForm, disable manual
				/// 
				if (index == -1) 
				{
					TXT_AP_RECVDATE_DAY.ReadOnly = true;
					DDL_AP_RECVDATE_MONTH.Enabled = false;
					TXT_AP_RECVDATE_YEAR.ReadOnly = false;
					updatestatus.Visible = false;
				}

				for (int i = 0; i < coll[index].Controls.Count; i++) 
				{
					if (coll[index].Controls[i] is TextBox) 
					{
						TextBox txt = (TextBox) coll[index].Controls[i];
						txt.ReadOnly = true;
						//txt.Enabled = false;
					}
					else if (coll[index].Controls[i] is DropDownList) 
					{
						DropDownList ddl = (DropDownList) coll[index].Controls[i];
						ddl.Enabled = false;
					}
					else if (coll[index].Controls[i] is Button)
					{
						Button btn = (Button) coll[index].Controls[i];
						//btn.Enabled = false;
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
						/*
						try 
						{
							for(int j=0; j < dg.Items.Count; j++) 
							{
								dg.Items[i].Enabled	= false;
							}
						}
						catch (ArgumentOutOfRangeException ex) 
						{
							// ignore...
						}
						*/
					}					
				}
			}
		}

		private void ViewData()
		{
			double limitExposure = 0;
			conn.QueryString = "select * from VW_DE_MAIN where ap_regno='" + Request.QueryString["regno"] + "'";
			conn.ExecuteQuery();
			txt_AP_REGNO.Text		= conn.GetFieldValue("AP_REGNO");
			txt_CU_REF.Text			= conn.GetFieldValue("CU_REF");
			txt_AP_SIGNDATE.Text	= tool.FormatDate(conn.GetFieldValue("AP_SIGNDATE"));
			txt_PROGRAMDESC.Text	= conn.GetFieldValue("PROGRAMDESC");
			txt_BRANCH_NAME.Text	= conn.GetFieldValue("BRANCH_NAME");
			TXT_AP_RELMNGR.Text		= conn.GetFieldValue("SU_FULLNAME");
			try 
			{
				limitExposure /*txt_AP_LIMITEXPOSURE.Text*/ = double.Parse(conn.GetFieldValue("LIMITEXPOSURE"));
			} 
			catch {}
			txt_CHANNEL_DESC.Text	= conn.GetFieldValue("CHANNEL_DESC");
			txt_AP_SRCCODE.Text		= conn.GetFieldValue("AP_SRCCODE");
			txt_AP_SALESAGENCY.Text = conn.GetFieldValue("AGENCYNAME");
			TXT_GR_BUSINESSUNIT.Text = conn.GetFieldValue("BUSSUNITDESC");
			TXT_AP_TEAMLEADER.Text = conn.GetFieldValue("AP_TEAMLEADER");
			//TXT_AP_DATALNGKP_DAY.Text				= tool.FormatDate_Day(conn.GetFieldValue("AP_DATALNGKP"));
			//DDL_AP_DATALNGKP_MONTH.SelectedValue	= tool.FormatDate_Month(conn.GetFieldValue("AP_DATALNGKP"));	
			//TXT_AP_DATALNGKP_YEAR.Text				= tool.FormatDate_Year(conn.GetFieldValue("AP_DATALNGKP"));
			TXT_AP_RECVDATE_DAY.Text				= tool.FormatDate_Day(conn.GetFieldValue("AP_RECVDATE"));
			DDL_AP_RECVDATE_MONTH.SelectedValue		= tool.FormatDate_Month(conn.GetFieldValue("AP_RECVDATE"));
			TXT_AP_RECVDATE_YEAR.Text				= tool.FormatDate_Year(conn.GetFieldValue("AP_RECVDATE"));		
			
			conn.QueryString = "select sum(cp_limit) from custproduct where ap_regno='" + Request.QueryString["regno"] + "'";
			conn.ExecuteQuery();
			try {
				limitExposure = limitExposure + double.Parse(conn.GetFieldValue(0,0));
			} 
			catch {
				limitExposure = 0;
			}
			txt_AP_LIMITEXPOSURE.Text = tool.MoneyFormat(limitExposure.ToString());
		}

		private void ViewProductList()
		{
			DataTable dt = new DataTable();
			conn.QueryString = "select * from VW_DE_MAINPRODUCTLIST where ap_regno='" + Request.QueryString["regno"] + "'";
			conn.ExecuteQuery();
			dt = conn.GetDataTable().Copy();
			DatGrd.DataSource = dt;
			DatGrd.DataBind();
			//ddl_PRODUCTID.SelectedValue = "";
			//ddl_APPTYPE.SelectedValue = "";
		}

		/*
		private void DatGrd_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			switch (((LinkButton)e.CommandSource).CommandName)
			{
				case "delete":
                    //conn.QueryString = "exec IDE_LOANINFO_COLL '" + Request.QueryString["curef"] + "', '', null, " + 
						//e.Item.Cells[0].Text + ", '2'";
					conn.QueryString = "exec DE_MAIN_PRODUCTLIST '19042004001000001', '" +e.Item.Cells[0].Text+ "', '"+e.Item.Cells[1].Text+"', '2'";
					conn.ExecuteNonQuery();
					break;
			}
			ViewProductList();
		}
		*/

		private void BTN_INSERT_Click(object sender, System.EventArgs e)
		{
			//conn.QueryString = "exec DE_MAIN_PRODUCTLIST '19042004001000001', '"+ddl_PRODUCTID.SelectedValue.ToString()+"', '"+ddl_APPTYPE.SelectedValue.ToString()+"','1'";
			//conn.ExecuteQuery();
			//ViewProductList();
		}

		/*
		private void BTN_SAVE_Click(object sender, System.EventArgs e)
		{
			conn.QueryString = "exec DE_MAIN '"+Request.QueryString["regno"]+"', " +tool.ConvertDate(TXT_AP_DATALNGKP_DAY.Text,DDL_AP_DATALNGKP_MONTH.SelectedValue,TXT_AP_DATALNGKP_YEAR.Text)+ ","+
								tool.ConvertDate(TXT_AP_RECVDATE_DAY.Text,DDL_AP_RECVDATE_MONTH.SelectedValue,TXT_AP_RECVDATE_YEAR.Text);
			conn.ExecuteNonQuery();
			ViewData();
		}
		*/

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
							strtemp = "regno=" + Request.QueryString["regno"] + "&curef="+Request.QueryString["curef"]+"&tc="+Request.QueryString["tc"];
						else	strtemp = "regno=" + Request.QueryString["regno"] + "&curef="+Request.QueryString["curef"]+"&mc="+Request.QueryString["mc"]+"&tc="+Request.QueryString["tc"];
						//t.ForeColor = Color.MidnightBlue; 
						if (conn.GetFieldValue(i,3).IndexOf("?de=") < 0 && conn.GetFieldValue(i,3).IndexOf("&de=") < 0) 
							strtemp = strtemp + "&de=" + Request.QueryString["de"];	
						if (conn.GetFieldValue(i,3).IndexOf("?par=") < 0 && conn.GetFieldValue(i,3).IndexOf("&par=") < 0)  
							strtemp = strtemp + "&par=" + Request.QueryString["par"];
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

		private string getNextStepMsg(string regno) 
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

		protected void updatestatus_Click(object sender, System.EventArgs e)
		{
			DataTable dt;
			bool STSAVE = true;

			//Check Mandatory
			try
			{
				conn.QueryString = "EXEC DDE_CHECKMANDATORY '" + Request.QueryString["regno"] + "'";
				conn.ExecuteQuery();
			}
			catch (Exception ex)
			{
				string errmsg = ex.Message.Replace("'","");
				if (errmsg.IndexOf("Last Query:") > 0)
					errmsg = errmsg.Substring(0, errmsg.IndexOf("Last Query:"));
				GlobalTools.popMessage(this, errmsg);
				STSAVE = false;
				return;
			}
			if (conn.GetRowCount() != 0)
			{
				if (conn.GetFieldValue("CHECKSTATUS") != "1")
				{
					STSAVE = false;
					return;
				}
			}
			else
			{
				STSAVE = false;
				return;
			}
			
			if 	(STSAVE)
			{
				conn.QueryString = "select count (*) from listcollateral where ap_regno='" + Request.QueryString["regno"] + "'";
				conn.ExecuteQuery();
				if (conn.GetFieldValue(0,0) == "0")
				{
					conn.QueryString = "update APPLICATION set AP_APPRSTATUS = '1' where AP_REGNO = '" + Request.QueryString["regno"] + "'";
					conn.ExecuteNonQuery();
				}

				conn.QueryString = "select apptype, productid, PROD_SEQ from custproduct where ap_regno='" + Request.QueryString["regno"] +
					"' AND isnull(cp_reject,'0') <> '1' and isnull(cp_cancel,'0') <> '1'";
				conn.ExecuteQuery();
				dt = conn.GetDataTable().Copy();
				for (int i = 0; i < dt.Rows.Count; i++)
				{
					//exec trackupdate AP_REGNO, PRODUCTID, APPTYPE, USERID, PROD_SEQ
					conn.QueryString = "exec TRACKUPDATE '" + 
						Request.QueryString["regno"] + "', '" +
						dt.Rows[i][1].ToString() + "', '" + 
						dt.Rows[i][0].ToString() + "', '" + 
						Session["UserID"].ToString() + "', '" + 
						dt.Rows[i]["PROD_SEQ"].ToString() + "','"+Request.QueryString["tc"].Trim()+"'";
					conn.ExecuteNonQuery();
				}

				string msg = getNextStepMsg(Request.QueryString["regno"]);
				Response.Redirect("ListCustomer.aspx?tc=" + Request.QueryString["tc"] + "&mc=" + Request.QueryString["mc"] + "&msg=" + msg);
			}
                    

		}

		protected void BTN_BACK_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			if (Request.QueryString["par"] != null && Request.QueryString["par"] != "") 
				Response.Redirect(Request.QueryString["par"] + "&regno=" + Request.QueryString["regno"] + "&curef=" + Request.QueryString["curef"] + "&tc=" + Request.QueryString["tc"]);
			else
				Response.Redirect("/SME/" + DMS.CuBESCore.Logic.backLink(Request.QueryString["tc"].ToString(), conn));

		}
	}
}
