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
	/// Summary description for BookingList.
	/// </summary>
	public partial class BookingList : System.Web.UI.Page
	{
	
		//protected Connection conn = new Connection("Data Source=10.123.12.30;Initial Catalog=SMEDEV;uid=sa;pwd=");
		protected Connection conn;
		private string company_curef;

		protected void Page_Load(object sender, System.EventArgs e)
		{
			conn = (Connection) Session["Connection"];

			if (!Logic.AllowAccess(Session["GroupID"].ToString(), Request.QueryString["mc"], conn))
				Response.Redirect("/SME/Restricted.aspx");

			// Munculkan pesan next step
			if (Request.QueryString["msg"] != "" && Request.QueryString["msg"] != null) 
				GlobalTools.popMessage(this, Request.QueryString["msg"]);

			// Put user code to initialize the page here
			if (!IsPostBack)
			{
				bindData();
			}
			
			// Manually register the event-handling method for the PageIndexChanged 
			// event of the DataGrid control.
			DataGrid1.PageIndexChanged += new DataGridPageChangedEventHandler(this.Grid_Change);
			BTN_UPDATE.Attributes.Add("onclick","if(!ConfirmBox('Are you sure want to update ?')){return false;};");
		}

		private void bindData()
		{
			string vBRANCH_CODE = (string) Session["BranchID"];
			DataTable dt = new DataTable();
			DataRow dr;
			System.Web.UI.WebControls.Image ImgSta;
			conn.QueryString = "SELECT AP_REGNO, CU_REF, NAME, AP_SIGNDATE, AP_RELMNGR, AP_CONFIRMBOOK "+
				"FROM VW_CREOPR_BOOKING_LIST WHERE AP_CURRTRACK = '" + Request.QueryString["tc"].Trim() + "' " + 
				"and BRANCH_CODE = '" + vBRANCH_CODE + "'";
				//"and (ap_co='" + Session["UserID"].ToString() + "' or ap_co is null)";
			conn.ExecuteQuery();
			dt.Columns.Add(new DataColumn("AP_REGNO"));
			dt.Columns.Add(new DataColumn("CU_REF"));
			dt.Columns.Add(new DataColumn("NAME"));
			dt.Columns.Add(new DataColumn("AP_SIGNDATE"));
			dt.Columns.Add(new DataColumn("AP_RELMNGR"));
			dt.Columns.Add(new DataColumn("AP_CO"));

			int rows = conn.GetRowCount();
			if (rows < 1) BTN_UPDATE.Enabled = false;
			else BTN_UPDATE.Enabled = true;

			for (int i = 0; i < rows; i++) 
			{
				dr = dt.NewRow();
				for (int j = 0; j < conn.GetColumnCount() - 1; j++)
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
			for (int i = 0; i < DataGrid1.Items.Count; i++)
			{
				int j = DataGrid1.CurrentPageIndex * DataGrid1.PageSize;
				ImgSta	= (System.Web.UI.WebControls.Image) DataGrid1.Items[i].Cells[5].FindControl("IMG_CONFIRM"); 
				//Label LblSta1	= (Label) DataGrid1.Items[i].Cells[5].FindControl("LBL_CONFIRM");
				if (conn.GetFieldValue(j + i, "AP_CONFIRMBOOK") == "1")
				{
					ImgSta.ImageUrl = "../../image/Complete.gif";
				}
				else
				{
					ImgSta.ImageUrl = "../../image/UnComplete.gif";
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
			this.DataGrid1.ItemCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.DataGrid1_ItemCommand);

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
			string regno, curef;
			switch(((LinkButton)e.CommandSource).CommandName)
			{
				case "undo":
					regno = e.Item.Cells[0].Text.Trim();
					curef = e.Item.Cells[1].Text.Trim();
					conn.QueryString = "UPDATE APPLICATION SET AP_CONFIRMBOOK = '0' WHERE AP_REGNO = '"+ regno + "' ";
					conn.ExecuteNonQuery();
					bindData();
					break;

				case "view":								
					regno = e.Item.Cells[0].Text.Trim();
						curef = e.Item.Cells[1].Text.Trim();
					if (e.Item.Cells[7].Text == "&nbsp;")
					{
						conn.QueryString = "update application set ap_co='" + Session["UserID"].ToString() + "' where ap_regno='" + e.Item.Cells[0].Text + "'";
						conn.ExecuteNonQuery();
					}
					Response.Redirect("BookingDetail.aspx?regno=" + regno + "&curef="+curef + "&mc=" + Request.QueryString["mc"] +
						"&tc=" + Request.QueryString["tc"]);
					break;

				default:
					// Do nothing.
					break;
			}
		}

		protected void BTN_UPDATE_Click(object sender, System.EventArgs e)
		{
			string regno = "";

			try
			{
				conn.QueryString = "exec BOOKINGLIST_UPDATESTATUS '" + Session["UserID"] + "'";
				conn.ExecuteQuery();

				regno = conn.GetFieldValue("AP_REGNO").ToString().Trim();

				////////////////////////////////////////////////////
				/// mengupdate track next by
				/// 
				conn.QueryString = "exec TRACKNEXTBY_SET_BOOKING '" + regno + "', '" + Session["UserID"].ToString() + "'";
				conn.ExecuteNonQuery();

				string msg = getNextStepMsg(regno, Request.QueryString["tc"]);
				Response.Redirect("BookingList.aspx?tc=" + Request.QueryString["tc"] + "&mc=" + Request.QueryString["mc"] + "&msg=" + msg);

				bindData();
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
			bool bFound = false;
			string regno = "";

			DataTable dt;
			conn.QueryString = "select cp.apptype, cp.productid, a.ap_regno, cp.PROD_SEQ from application a " +
				"inner join custproduct cp on cp.ap_regno = a.ap_regno " +
				"inner join apptrack at on at.ap_regno = cp.ap_regno and at.apptype = cp.apptype " +
				"and at.productid = cp.productid and at.PROD_SEQ = cp.PROD_SEQ " + 
				"where a.ap_confirmbook = '1' " +
				"AND isnull(cp_reject,'0') <> '1' and isnull(cp_cancel,'0') <> '1'" +
				"AND at.ap_currtrack = '" + Request.QueryString["tc"].Trim() + "' ";
			conn.ExecuteQuery();
			dt = conn.GetDataTable().Copy();
			
			for (int i = 0; i < dt.Rows.Count; i++)
			{
				conn.QueryString = "exec TRACKUPDATE '" + dt.Rows[i][2].ToString().Trim() + "', '" +
					dt.Rows[i][1].ToString().Trim() + "', '" + dt.Rows[i][0].ToString().Trim() + "', '" +
					Session["UserID"].ToString() + "', '" + dt.Rows[i]["PROD_SEQ"].ToString() + "','"+
					Request.QueryString["tc"].Trim() +"'";

				conn.ExecuteNonQuery();

				////////////////////////////////////////////////////
				/// mengupdate track next by
				/// 
				conn.QueryString = "exec TRACKNEXTBY_SET_BOOKING '" + dt.Rows[i][2].ToString().Trim() + "', '" + Session["UserID"] + "'";
				conn.ExecuteNonQuery();

				if (i == 0) regno = dt.Rows[i][2].ToString().Trim(); // beri nilai regno
				bFound = true;
			}

			#region Modified by nana for BDE Checking
			insert_BDEChecking(regno);
			#endregion

			string msg = getNextStepMsg(regno, Request.QueryString["tc"]);
			Response.Redirect("BookingList.aspx?tc=" + Request.QueryString["tc"] + "&mc=" + Request.QueryString["mc"] + "&msg=" + msg);

			bindData();
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
	}
}
