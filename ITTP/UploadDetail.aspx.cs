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
namespace SME.ITTP
{
	/// <summary>
	/// Summary description for UploadDetail.
	/// </summary>
	public partial class UploadDetail : System.Web.UI.Page
	{
		protected Connection conn, conn2;
		protected Tools tool = new Tools();
		private string company_curef;

	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			conn = (Connection) Session["Connection"];

			if (!Logic.AllowAccess(Session["GroupID"].ToString(), Request.QueryString["mc"], conn))
				Response.Redirect("/SME/Restricted.aspx");

			if (!IsPostBack)
			{
				LBL_REGNO.Text	= Request.QueryString["regno"];
				LBL_TC.Text		= Request.QueryString["tc"];

				//ViewProses();
				ViewData();
				ViewDGR_LIST();
				//SecureData();
			}
			
			ViewMenu();
			//ViewFileUpload();
			//BTN_UPDATE.Attributes.Add("onclick","if(!ConfirmBox('Are you sure want to update ?')){return false;};");
			//BTN_DF_INPUT.Attributes.Add("onclick","if(!cek_mandatory(document.Form1)){return false;};");
		}

		private void ViewDGR_LIST()
		{
			conn.QueryString = "select * from VW_IT_SYARAT " +
				"where sy_status='1' and AP_REGNO = '" + LBL_REGNO.Text + "'";
			conn.ExecuteQuery();
			DataTable data = new DataTable();
			data = conn.GetDataTable().Copy();
			DGR_LIST.DataSource = data;
			DGR_LIST.DataBind();
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

		private void ViewData()
		{
			DataTable dt		= new DataTable();
			conn.QueryString	= "select * from vw_it_viewdata2 where ap_regno = '"+LBL_REGNO.Text+"'";
			conn.ExecuteQuery();
			dt	= conn.GetDataTable().Copy();		
			LBL_CU_CIF.Text		= conn.GetFieldValue("cu_cif");
			LBL_CU_REF.Text		= conn.GetFieldValue("cu_ref");
			LBL_CU_CIF.Visible	= false;
			LBL_CU_REF.Visible	= false;
		}

		protected void BTN_CONFIRM_Click(object sender, System.EventArgs e)
		{
			//if (TXT_CU_CIF.Text.Trim() != LBL_CU_CIF.Text.Trim())
			//{
				conn.QueryString = "update customer set cu_cif = '" + LBL_CU_CIF.Text.Trim() +
					"' where cu_ref = '" + LBL_CU_REF.Text.Trim() + "' ";
				conn.ExecuteNonQuery();
			//}
			conn.QueryString = "UPDATE APPLICATION SET AP_CONFIRMBOOK = '1' WHERE AP_REGNO = '"+
				LBL_REGNO.Text.Trim() + "' ";
			conn.ExecuteNonQuery();
			Response.Redirect("UploadList.aspx?tc=" + Request.QueryString["tc"] + "&mc=" + Request.QueryString["mc"]);
		}

		protected void BTN_UNCONFIRM_Click(object sender, System.EventArgs e)
		{
			conn.QueryString = "UPDATE APPLICATION SET AP_CONFIRMBOOK = '0' WHERE AP_REGNO = '"+
				LBL_REGNO.Text.Trim() + "' ";
			conn.ExecuteNonQuery();
			Response.Redirect("UploadList.aspx?tc=" + Request.QueryString["tc"] + "&mc=" + Request.QueryString["mc"]);
		}

		private void BTN_UPDATE_Click(object sender, System.EventArgs e)
		{
			DataTable dt;
			conn.QueryString = "select cp.apptype, cp.productid, a.ap_confirmbook, cp.PROD_SEQ from application a " +
				"inner join custproduct  cp on a.ap_regno = cp.ap_regno " +
				"where a.ap_regno='" + Request.QueryString["regno"] +
				"' AND isnull(cp_reject,'0') <> '1' and isnull(cp_cancel,'0') <> '1'";
			conn.ExecuteQuery();
			dt = conn.GetDataTable().Copy();
			if (conn.GetFieldValue(0, "AP_CONFIRMBOOK").Trim() == "0")
			{
				Tools.popMessage(this, "This application has not been confirmed for Upload!");
			}
			else if (dt.Rows.Count > 0)
			{
				//if (LBL_CU_CIF.Text.Trim() != LBL_CU_CIF.Text.Trim())
				//{
					conn.QueryString = "update customer set cu_cif = '" + LBL_CU_CIF.Text.Trim() +
						"' where cu_ref = '" + LBL_CU_REF.Text.Trim() + "' ";
					conn.ExecuteNonQuery();
				//}
				for (int i = 0; i < dt.Rows.Count; i++)
				{
					conn.QueryString = "exec IT_TRACKUPDATE '" + 
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

				//string msg = getNextStepMsg(Request.QueryString["regno"], Request.QueryString["tc"]);
				Response.Redirect("UploadList.aspx?mc=" + Request.QueryString["mc"] + "&tc=" + Request.QueryString["tc"]); 
					//+ "&msg=" + msg);
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

		protected void BTN_ACQINFO_Click(object sender, System.EventArgs e)
		{

				Response.Write("<script for=window event=onload language='javascript'>PopupPage('AcqInfo2.aspx?regno=" + LBL_REGNO.Text + "&curef=" + LBL_CU_REF.Text + "&aprv=CO&theForm=Form1&theObj=TXT_TEMP', '800','300');</script>");
		
//				conn.QueryString = "update APPLICATION set AP_CO = null where AP_REGNO = '" + LBL_REGNO.Text + "'";
//				conn.ExecuteNonQuery();

		}
		protected void TXT_TEMP_TextChanged(object sender, EventArgs e)
		{
			if (TXT_TEMP.Text != "") 
			{
				string msg = "";
				msg = "Application acquire information from " + TXT_TEMP.Text + " !";
				Response.Redirect("UploadList.aspx?tc=" + Request.QueryString["tc"] + "&mc=" + Request.QueryString["mc"]);
			}
		}

	}
}
