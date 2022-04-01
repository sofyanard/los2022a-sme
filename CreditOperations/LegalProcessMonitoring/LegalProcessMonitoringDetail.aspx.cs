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
using DMS.CuBESCore;
using DMS.DBConnection;

namespace SME.CreditOperations.LegalProcessMonitoring
{
	/// <summary>
	/// Summary description for LegalProcessMonitoringDetail.
	/// </summary>
	public partial class LegalProcessMonitoringDetail : System.Web.UI.Page
	{
	
		//protected Connection conn = new Connection("Data Source=10.123.12.30;Initial Catalog=SMEDEV;uid=sa;pwd=");
		protected Connection conn;
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
				DDL_RATE.Items.Clear();
				DDL_RATE.Items.Add(new ListItem("-- Pilih --", ""));
				for (int i=0; i<conn.GetRowCount(); i++)
					DDL_RATE.Items.Add(new ListItem(conn.GetFieldValue(i, 1), conn.GetFieldValue(i, 0)));

				viewData();
				bindData();
			}
			ViewMenu();
			Datagrid1.PageIndexChanged += new DataGridPageChangedEventHandler(this.Grid1_Change);
			Datagrid2.PageIndexChanged += new DataGridPageChangedEventHandler(this.Grid2_Change);
			BTN_UPDATE.Attributes.Add("onclick","if(!update()){return false;};");
		}

		private void viewData()
		{
			/**
			conn.QueryString = "select VW_INFOUMUM.*, notaryassign.NTID, NT_NAME, RATEID from VW_INFOUMUM "+
				"left join notaryassign on notaryassign.AP_REGNO = VW_INFOUMUM.AP_REGNO and seq = 1 "+
                "left join rfnotary on rfnotary.ntid = notaryassign.ntid "+
				"where VW_INFOUMUM.AP_REGNO = '"+ LBL_REGNO.Text.Trim() +"' ";
			**/


			conn.QueryString = "select * from VW_INFOUMUM_CREOPR_LEGALPROCMONITORING_DETAIL where ap_regno = '" + LBL_REGNO.Text.Trim() + "'";
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
			TXT_NT_NAME.Text = conn.GetFieldValue("NT_NAME");
			try
			{
				LBL_H_NTID.Text = conn.GetFieldValue("NTID");
				LBL_H_RATEID.Text = conn.GetFieldValue("RATEID");
				DDL_RATE.SelectedValue = conn.GetFieldValue("RATEID");				
			}
			catch{}

			/// Kalau ngga ada notary di-assign, ngga perlu rate notary
			/// 
			if (LBL_H_NTID.Text.Trim() == "") DDL_RATE.Enabled = false;

			//Sofyan 2010-06-11 Acquire Info
			conn.QueryString = "select ISNULL(AP_ACQINFOBY,'') as AP_ACQINFOBY, AP_COMPLEVEL from APPLICATION where AP_REGNO = '"+Request.QueryString["regno"]+"'";
			conn.ExecuteQuery();
			string ISACQINFO = conn.GetFieldValue(0,0).ToString().Trim();
			if (ISACQINFO != "")
			{
				tbl_acqinfo.Visible = true;
			}
			else
			{
				tbl_acqinfo.Visible = false;
			}
		}

		private void bindData()
		{
			int i;
			System.Web.UI.WebControls.Image ImgSta1, ImgSta2;
			DataTable dt = new DataTable();
			conn.QueryString = "select * from VW_CREOPR_LEGALPROCMONITORING_PRODUCTLEGAL "+
				//"where ap_currtrack='" + LBL_TC.Text.Trim() + "'";
				"where AP_REGNO ='"+ Request.QueryString["regno"] + "'";
			conn.ExecuteQuery();
			dt = conn.GetDataTable().Copy();
			Datagrid1.DataSource = dt;
			try 
			{
				Datagrid1.DataBind();
			} 
			catch 
			{
				Datagrid1.CurrentPageIndex = 0;
				Datagrid1.DataBind();
			}
			for (i = 0; i < Datagrid1.Items.Count; i++)
			{
				Datagrid1.Items[i].Cells[3].Text = tool.FormatDate(Datagrid1.Items[i].Cells[3].Text, true);
				ImgSta1	= (System.Web.UI.WebControls.Image) Datagrid1.Items[i].Cells[4].FindControl("IMG_NOTARYSTATUS"); 
				Label LblSta1	= (Label) Datagrid1.Items[i].Cells[4].FindControl("LBL_NOTARYSTATUS");
				CheckBox ChkSta1 = (CheckBox) Datagrid1.Items[i].Cells[4].FindControl("CHK_NOTARYSTATUS");
				if (Datagrid1.Items[i].Cells[5].Text == "1")
				{
					LblSta1.Text = "Done";
					ImgSta1.ImageUrl = "../../image/Complete.gif";
					ChkSta1.Visible = false;
				}
				else
				{
					LblSta1.Text = "In Process";
					ImgSta1.ImageUrl = "../../image/UnComplete.gif";
					ChkSta1.Visible = true;
				}
			}
			DataTable dt2 = new DataTable();
			conn.QueryString = "select * from VW_CREOPR_LEGALPROCMONITORING_COLLEGAL "+
				//"where ap_currtrack='" + LBL_TC.Text.Trim() + "'";
				"where AP_REGNO ='"+ Request.QueryString["regno"] + "'";
			conn.ExecuteQuery();
			dt2 = conn.GetDataTable().Copy();
			Datagrid2.DataSource = dt2;
			try 
			{
				Datagrid2.DataBind();
			} 
			catch 
			{
				Datagrid2.CurrentPageIndex = 0;
				Datagrid2.DataBind();
			}
			for (i = 0; i < Datagrid2.Items.Count; i++)
			{
				Datagrid2.Items[i].Cells[3].Text = tool.FormatDate(Datagrid2.Items[i].Cells[3].Text, true);
				ImgSta2	= (System.Web.UI.WebControls.Image) Datagrid2.Items[i].Cells[4].FindControl("IMG_NOTARYSTATUS2"); 
				Label LblSta2	= (Label) Datagrid2.Items[i].Cells[4].FindControl("LBL_NOTARYSTATUS2");
				CheckBox ChkSta2 = (CheckBox) Datagrid2.Items[i].Cells[4].FindControl("CHK_NOTARYSTATUS2");
				if (Datagrid2.Items[i].Cells[5].Text == "1")
				{
					LblSta2.Text = "Done";
					ImgSta2.ImageUrl = "../../image/Complete.gif";
					ChkSta2.Visible = false;
				}
				else
				{
					LblSta2.Text = "In Process";
					ImgSta2.ImageUrl = "../../image/UnComplete.gif";
					ChkSta2.Visible = true;
				}
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

		}
		#endregion

		void Grid1_Change(Object sender, DataGridPageChangedEventArgs e) 
		{
			// Set CurrentPageIndex to the page the user clicked.
			Datagrid1.CurrentPageIndex = e.NewPageIndex;
			// Re-bind the data to refresh the DataGrid control. 
			bindData();	
		}

		void Grid2_Change(Object sender, DataGridPageChangedEventArgs e) 
		{
			// Set CurrentPageIndex to the page the user clicked.
			Datagrid2.CurrentPageIndex = e.NewPageIndex;
			// Re-bind the data to refresh the DataGrid control. 
			bindData();	
		}

		protected void BTN_UPDATE_Click(object sender, System.EventArgs e)
		{
			try
			{
				conn.QueryString = "EXEC LEGALPROCESS_CHECKMANDATORY '" + Request.QueryString["regno"] + "'";
				conn.ExecuteQuery();
			}
			catch (Exception ex)
			{
				string errmsg = ex.Message.Replace("'","");
				if (errmsg.IndexOf("Last Query:") > 0)
					errmsg = errmsg.Substring(0, errmsg.IndexOf("Last Query:"));
				GlobalTools.popMessage(this, errmsg);
				return;
			}
			if (conn.GetRowCount() != 0)
				if (conn.GetFieldValue("CHECKSTATUS") != "1")
					return;
				else {}
			else
				return;

			try
			{
				conn.QueryString = "EXEC LEGALPROCESS_UPDATESTATUS '" + Request.QueryString["regno"] + "', '" + Session["UserID"].ToString() + "'";
				conn.ExecuteQuery();
			}
			catch (Exception ex)
			{
				string errmsg = ex.Message.Replace("'","");
				if (errmsg.IndexOf("Last Query:") > 0)
					errmsg = errmsg.Substring(0, errmsg.IndexOf("Last Query:"));
				GlobalTools.popMessage(this, errmsg);
				return;
			}
			
			/*
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

			////////////////////////////////////////////////////
			/// mengupdate track next by
			/// 

			string msg = "";

			conn.QueryString = "SELECT * FROM KETENTUAN_KREDIT WHERE AP_REGNO = '" + Request.QueryString["regno"] + "' AND PRJ_CODE = 'CHAN1000'";
			conn.ExecuteQuery();

			if(conn.GetRowCount() > 0)
			{
				msg = "Channeling Plafond Has Been Set for End User ! Please check in Channeling for End User Flow Process !";
			}
			else
			{
				conn.QueryString = "exec TRACKNEXTBY_SET_NA '" + Request.QueryString["regno"] + "'";
				conn.ExecuteNonQuery();
				msg = getNextStepMsg(Request.QueryString["regno"], Request.QueryString["tc"]);
			}
			Response.Redirect("LegalProcessMonitoringList.aspx?tc=" + Request.QueryString["tc"] + "&mc=" + Request.QueryString["mc"] + "&msg=" + msg);
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

		protected void BTN_SAVE_Click(object sender, System.EventArgs e)
		{
			string regno, prodid, seq;
			int i;
			CheckBox chkSta;
		

			/// **********************************************************************
			/// Update Notary Rating
			/// 
			if (LBL_H_RATEID.Text.Trim() != DDL_RATE.SelectedValue.Trim())
			{
				conn.QueryString = "UPDATE NOTARYASSIGN SET RATEID = '" + DDL_RATE.SelectedValue.Trim() +
					"' WHERE AP_REGNO = '" + LBL_REGNO.Text.Trim() + "' AND NTID = '" +
					LBL_H_NTID.Text.Trim() + "' ";
				conn.ExecuteNonQuery();
			}
			/// **********************************************************************


			for (i = 0; i < Datagrid1.Items.Count; i++)
			{
				regno = Datagrid1.Items[i].Cells[7].Text.Trim();
				prodid = Datagrid1.Items[i].Cells[8].Text.Trim();
				chkSta = (CheckBox) Datagrid1.Items[i].Cells[4].FindControl("CHK_NOTARYSTATUS");
				if ((Datagrid1.Items[i].Cells[5].Text.Trim() != "1")&&(chkSta.Checked))
				{
					conn.QueryString = "UPDATE APPPRODUCTLEGAL SET APL_NOTARYSTATUS = '1' WHERE AP_REGNO = '" + regno +
						"' AND PRODUCTID = '" + prodid + "' ";
					conn.ExecuteNonQuery();
				}
			}
		    
			for (i = 0; i < Datagrid2.Items.Count; i++)
			{
				regno = Datagrid2.Items[i].Cells[7].Text.Trim();
				prodid = Datagrid2.Items[i].Cells[8].Text.Trim();
				seq = Datagrid2.Items[i].Cells[9].Text.Trim();
				chkSta = (CheckBox) Datagrid2.Items[i].Cells[4].FindControl("CHK_NOTARYSTATUS2");
				if ((Datagrid2.Items[i].Cells[5].Text.Trim() != "1")&&(chkSta.Checked))
				{
					conn.QueryString = "UPDATE APPCOLLEGAL SET ACL_NOTARYSTATUS = '1' WHERE AP_REGNO = '" +
						regno + "' AND CL_SEQ = " + seq;
					conn.ExecuteNonQuery();
				}
			}
			bindData();
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
				Response.Redirect("LegalProcessMonitoringList.aspx?tc=" + Request.QueryString["tc"] + "&mc=" + Request.QueryString["mc"] + "&msg=" + msg);
			}
		}
	}
}
