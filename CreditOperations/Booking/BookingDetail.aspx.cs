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

namespace SME.CreditOperations.Booking
{
	/// <summary>
	/// Summary description for BookingDetail.
	/// </summary>
	public partial class BookingDetail : System.Web.UI.Page
	{
	
		protected Tools tool = new Tools();
		private string company_curef;
		protected Connection conn;

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

				ViewData();
				ViewFacility();
			}
			ViewMenu();
			initSubMenu();
			BTN_UPDATE.Attributes.Add("onclick","if(!update()){return false;};");
			BTN_CONFIRM.Attributes.Add("onclick","if(!confirming()){return false;};");
			BTN_BACK.Click +=new ImageClickEventHandler(BTN_BACK_Click);
			BTN_CONFIRM.Click += new EventHandler(BTN_CONFIRM_Click);
			BTN_UNCONFIRM.Click +=new EventHandler(BTN_UNCONFIRM_Click);
			BTN_UPDATE.Click += new EventHandler(BTN_UPDATE_Click);
			BTN_ACQINFO.Click += new System.EventHandler(this.BTN_ACQINFO_Click);
			this.TXT_TEMP.TextChanged += new System.EventHandler(this.TXT_TEMP_TextChanged);
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

		private void initSubMenu()
		{
			HyperLink ht1 = new HyperLink(), ht2 = new HyperLink(), ht3 = new HyperLink();
			ht1.Text = "Biaya-biaya";
			ht2.Text = "Jaminan";
			ht1.Font.Bold = true;
			ht2.Font.Bold = true;
			ht1.Target = "frm_content";
			ht2.Target = "frm_content";
			ht1.NavigateUrl = "DetailBiaya.aspx?regno=" + LBL_REGNO.Text.Trim() + "&curef=" + LBL_CUREF.Text.Trim();
			SubMenu.Controls.Add(ht1);
			SubMenu.Controls.Add(new LiteralControl("&nbsp;&nbsp;&nbsp;"));
			ht2.NavigateUrl = "DetailJaminan.aspx?regno=" + LBL_REGNO.Text.Trim() + "&curef=" + LBL_CUREF.Text.Trim();
			SubMenu.Controls.Add(ht2);
		}

		private void ViewData()
		{
			conn.QueryString = "select cu_cif, VW_INFOUMUM.* " +
				"from VW_INFOUMUM left join customer on customer.cu_ref = VW_INFOUMUM.cu_ref "+
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
			TXT_CU_CIF.Text = conn.GetFieldValue("CU_CIF");
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

				for (int i = 0; i < Datagrid2.Items.Count; i++)
				{
					RadioButtonList rbl = (RadioButtonList)Datagrid2.Items[i].Cells[4].FindControl("RBL_FAC");
					if (Datagrid2.Items[i].Cells[5].Text.Trim() == "1")
					{
						rbl.SelectedValue = "1";
					}
					else
					{
						rbl.SelectedValue = "0";
					}
					rbl.Enabled = false;
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

		}
		#endregion

		private void BTN_CONFIRM_Click(object sender, System.EventArgs e)
		{
			if (TXT_CU_CIF.Text.Trim() != LBL_CU_CIF.Text.Trim())
			{
				conn.QueryString = "update customer set cu_cif = '" + TXT_CU_CIF.Text.Trim() +
					"' where cu_ref = '" + TXT_CU_REF.Text.Trim() + "' ";
				conn.ExecuteNonQuery();
			}
			conn.QueryString = "UPDATE APPLICATION SET AP_CONFIRMBOOK = '1' WHERE AP_REGNO = '"+
				TXT_AP_REGNO.Text.Trim() + "' ";
			conn.ExecuteNonQuery();
			Response.Redirect("BookingList.aspx?tc=" + Request.QueryString["tc"] + "&mc=" + Request.QueryString["mc"]);
		}

		private void BTN_UNCONFIRM_Click(object sender, System.EventArgs e)
		{
			conn.QueryString = "UPDATE APPLICATION SET AP_CONFIRMBOOK = '0' WHERE AP_REGNO = '"+
				TXT_AP_REGNO.Text.Trim() + "' ";
			conn.ExecuteNonQuery();
			Response.Redirect("BookingList.aspx?tc=" + Request.QueryString["tc"] + "&mc=" + Request.QueryString["mc"]);
		}

		protected void BTN_UPDATE_Click(object sender, System.EventArgs e)
		{
			try
			{
				conn.QueryString = "exec BOOKING_UPDATESTATUS '" +
					Request.QueryString["regno"] + "', '" +
					Session["UserID"] + "', '" +
					TXT_CU_CIF.Text.Trim() + "'";
				conn.ExecuteNonQuery();

				////////////////////////////////////////////////////
				/// mengupdate track next by
				/// 
				conn.QueryString = "exec TRACKNEXTBY_SET_BOOKING '" + LBL_REGNO.Text + "', '" + Session["UserID"] + "'";
				conn.ExecuteNonQuery();
					
				string msg = getNextStepMsg(Request.QueryString["regno"], Request.QueryString["tc"]);
				Response.Redirect("BookingList.aspx?mc=" + Request.QueryString["mc"] + "&tc=" + Request.QueryString["tc"] + "&msg=" + msg);
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
			conn.QueryString = "select cp.apptype, cp.productid, a.ap_confirmbook, cp.PROD_SEQ from application a " +
				"inner join custproduct  cp on a.ap_regno = cp.ap_regno " +
				"where a.ap_regno='" + Request.QueryString["regno"] +
				"' AND isnull(cp_reject,'0') <> '1' and isnull(cp_cancel,'0') <> '1'";
			conn.ExecuteQuery();
			dt = conn.GetDataTable().Copy();
			if (conn.GetFieldValue(0, "AP_CONFIRMBOOK").Trim() == "0")
			{
				Tools.popMessage(this, "This application has not been confirmed for booking!");
			}
			else if (dt.Rows.Count > 0)
			{
				if (TXT_CU_CIF.Text.Trim() != LBL_CU_CIF.Text.Trim())
				{
					conn.QueryString = "update customer set cu_cif = '" + TXT_CU_CIF.Text.Trim() +
						"' where cu_ref = '" + TXT_CU_REF.Text.Trim() + "' ";
					conn.ExecuteNonQuery();
				}
				for (int i = 0; i < dt.Rows.Count; i++)
				{
					conn.QueryString = "exec TRACKUPDATE '" + 
										Request.QueryString["regno"] + "', '" +
										dt.Rows[i][1].ToString() + "', '" + 
										dt.Rows[i][0].ToString() + "', '" + 
										Session["UserID"].ToString() + "', '" + 
										dt.Rows[i]["PROD_SEQ"].ToString() + "','"+
										Request.QueryString["tc"] +"'";
					conn.ExecuteNonQuery();
				}

				////////////////////////////////////////////////////
				/// mengupdate track next by
				/// 
				conn.QueryString = "exec TRACKNEXTBY_SET_BOOKING '" + LBL_REGNO.Text + "', '" + Session["UserID"] + "'";
				conn.ExecuteNonQuery();

				#region Modified by nana for BDE Checking
				insert_BDEChecking(LBL_REGNO.Text);
				#endregion

				string msg = getNextStepMsg(Request.QueryString["regno"], Request.QueryString["tc"]);
				Response.Redirect("BookingList.aspx?mc=" + Request.QueryString["mc"] + "&tc=" + Request.QueryString["tc"] + "&msg=" + msg);
			}
			*/
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

		private void BTN_BACK_Click(object sender, ImageClickEventArgs e)
		{
			Response.Redirect("/SME/" + DMS.CuBESCore.Logic.backLink(Request.QueryString["tc"].ToString(), conn));
		}

        public string popUp = "";
        private void BTN_ACQINFO_Click(object sender, System.EventArgs e)
		{
			Response.Write("<script for=window event=onload language='javascript'>PopupPage('../../Approval/AcqInfo.aspx?regno=" + LBL_REGNO.Text + "&curef=" + TXT_CU_REF.Text + "&aprv=BOOK&theForm=Form1&theObj=TXT_TEMP', '800','300');</script>");
            popUp = "<script for=window event=onload language='javascript'>PopupPage('../../Approval/AcqInfo.aspx?regno=" + LBL_REGNO.Text + "&curef=" + TXT_CU_REF.Text + "&aprv=BOOK&theForm=Form1&theObj=TXT_TEMP', '800','300');</script>";
		}

		private void TXT_TEMP_TextChanged(object sender, System.EventArgs e)
		{
			if (TXT_TEMP.Text != "") 
			{
				string msg = "";
				msg = "Application acquire information from " + TXT_TEMP.Text + " !";
				Response.Redirect("BookingList.aspx?tc=" + Request.QueryString["tc"] + "&mc=" + Request.QueryString["mc"] + "&msg=" + msg);
			}
		}
	}
}
