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
using System.Web.Configuration;

namespace SME.Approval
{
	/// <summary>
	/// Summary description for ListApproval.
	/// </summary>
	public partial class ListApproval : System.Web.UI.Page
	{
		protected Connection conn;
		protected Tools tool = new Tools();


		protected void Page_Load(object sender, System.EventArgs e)
		{
			conn = (Connection) Session["Connection"];

			if (!Logic.AllowAccess(Session["GroupID"].ToString(), Request.QueryString["mc"], conn))
				Response.Redirect("/SME/Restricted.aspx");

			if (!IsPostBack)
			{
				if ((Request.QueryString["msg"] != "") && (Request.QueryString["msg"] != null))
					GlobalTools.popMessage(this, Request.QueryString["msg"]);
				ViewData();

				// Munculkan pesan next step - Gatot - Agus
				if (Request.QueryString["msg"] != "" && Request.QueryString["msg"]!= null)  
				{
					GlobalTools.popMessage(this, Request.QueryString["msg"]);
				}

                //pundiUpdate
                cekListReview();
			}
		}

        private void cekListReview()
        {
            string GROUPID = Session["GroupID"].ToString();

            string[] GROUPIDPAIRLIST = WebConfigurationManager.AppSettings["crpairing"].ToString().Split(new string[] { "#" }, StringSplitOptions.None);
            string GROUPIDPAIRRESULT = "";
            string[] GROUPIDPAIRRESULTLIST;
            string GROUPIDPAIR = "";

            if ((GROUPIDPAIRLIST.Length > 0) & (GROUPIDPAIRLIST[0] != ""))
            {
                for (int i = 0; i < GROUPIDPAIRLIST.Length; i++)
                {
                    GROUPIDPAIR = GROUPIDPAIRLIST[i];
                    GROUPIDPAIRRESULTLIST = GROUPIDPAIR.Split(new string[] { "-" }, StringSplitOptions.None);

                    if (GROUPID == GROUPIDPAIRRESULTLIST[1].ToString())
                    {
                        GROUPIDPAIRRESULT = GROUPIDPAIRRESULTLIST[0].ToString();
                        break;
                    }
                }
            }

            if (GROUPIDPAIRRESULT != "")
            {
                //bind disini
                //cari NIP BM pairing

                conn.QueryString = "SELECT SCUSER.GROUPID, SCUSER.SU_BRANCH, RFBRANCH.CBC_CODE, RFBRANCH.AREAID FROM SCUSER, RFBRANCH " +
                "WHERE SCUSER.USERID = '" + lbl_userid.Text + "' " +
                "AND SCUSER.SU_BRANCH = RFBRANCH.BRANCH_CODE ";
                conn.ExecuteQuery();

                string SUBRANCH = conn.GetFieldValue(0, 1);
                string CBCCODE = conn.GetFieldValue(0, 2);
                string AREAID = conn.GetFieldValue(0, 3);

                conn.QueryString = "SELECT SCUSER.USERID, SCUSER.SU_FULLNAME FROM SCUSER, RFBRANCH " +
                "WHERE SCUSER.GROUPID = '" + GROUPIDPAIRRESULT + "' " +
                "AND SCUSER.SU_BRANCH = RFBRANCH.BRANCH_CODE " +
                "AND RFBRANCH.BRANCH_CODE = '" + SUBRANCH + "' " +
                "AND RFBRANCH.AREAID = '" + AREAID + "' " +
                "AND RFBRANCH.CBC_CODE = '" + CBCCODE + "' " +
                "AND SCUSER.SU_ACTIVE = '1'";

                conn.QueryString = conn.QueryString + " UNION SELECT SCUSER.USERID, SCUSER.SU_FULLNAME FROM SCUSER, RFBRANCH " +
                "WHERE SCUSER.GROUPID = '" + GROUPIDPAIRRESULT + "' " +
                "AND SCUSER.SU_BRANCH = RFBRANCH.BRANCH_CODE " +
                "AND RFBRANCH.AREAID = '" + AREAID + "' " +
                "AND RFBRANCH.CBC_CODE = '" + SUBRANCH + "' " +
                "AND SCUSER.SU_ACTIVE = '1'";

                conn.ExecuteQuery();

                string NIP;
                ArrayList ListDownline = new ArrayList();
                DataTable dtTot = new DataTable();
                DataTable dtTemp = new DataTable();

                if (conn.GetRowCount() > 0)
                {
                    for (int i = 0; i < conn.GetRowCount(); i++)
                    {
                        NIP = conn.GetFieldValue(i, 0);
                        ListDownline.Add(NIP);
                    }
                }

                for (int i = 0; i < ListDownline.Count; i++)
                {
                    try
                    {
                        conn.QueryString = "exec list_approval '', '" + ListDownline[i] + "'";
                        conn.ExecuteQuery();

                        dtTemp = conn.GetDataTable().Copy();
                        dtTot.Merge(dtTemp);
                    }
                    catch { }
                }

                dgListApproval.DataSource = dtTot;
                try
                {
                    dgListApproval.DataBind();
                }
                catch
                {
                    dgListApproval.CurrentPageIndex = 0;
                    dgListApproval.DataBind();
                }
            }
        }

        private void ViewData(string UserID)
        {
            //lbl_userid.Text = Session["UserID"].ToString();
            DataTable dt = new DataTable();

            if (Request.QueryString["tc"] == "" || Request.QueryString["tc"] == null)
            {
                conn.QueryString = "exec list_approval_commitee '" + txt_regno.Text + "'";
                conn.ExecuteQuery();
            }
            else
            {
                conn.QueryString = "exec list_approval '" + txt_regno.Text + "', '" + UserID + "'";
                conn.ExecuteQuery();
            }

            dt = conn.GetDataTable().Copy();
            dgListApproval.DataSource = dt;
            try
            {
                dgListApproval.DataBind();
            }
            catch
            {
                dgListApproval.CurrentPageIndex = 0;
                dgListApproval.DataBind();
            }


            /// Menghitung ulang Application Value
            /// karena stored procedure list_approval menghasilkan limit application yang keliru
            /// 
            for (int i = 0; i < dgListApproval.Items.Count; i++)
            {
                //conn.QueryString = "DE_TOTALEXPOSURE '" + dgListApproval.Items[i].Cells[0].Text.Trim() + "'";
                //conn.ExecuteQuery(300);
                //dgListApproval.Items[i].Cells[4].Text = tool.MoneyFormat(conn.GetFieldValue("tot_limit"));
                dgListApproval.Items[i].Cells[4].Text = tool.MoneyFormat(dgListApproval.Items[i].Cells[4].Text);
            }


            /***
             * Yudi : Formatting dilakukan saat design DataGrid saja ...
             * 
            for (int i = 0; i < dgListApproval.Items.Count; i++)
            {
                dgListApproval.Items[i].Cells[3].Text = tool.FormatDate(dgListApproval.Items[i].Cells[3].Text, true);
                dgListApproval.Items[i].Cells[4].Text = tool.MoneyFormat(dgListApproval.Items[i].Cells[4].Text);
                //lbl_prod.Text		=  conn.GetFieldValue(i,4);
                //lbl_apptype.Text	=  conn.GetFieldValue(i,7);
            }
            ****/
        }

		private void ViewData()
		{	
			lbl_userid.Text = Session["UserID"].ToString();
			DataTable dt = new DataTable();
			
			if (Request.QueryString["tc"] == "" || Request.QueryString["tc"] == null) 
			{
				conn.QueryString = "exec list_approval_commitee '" + txt_regno.Text + "'";
				conn.ExecuteQuery();
			}
			else 
			{
				conn.QueryString = "exec list_approval '"+txt_regno.Text+"', '"+lbl_userid.Text+"'";
				conn.ExecuteQuery();
			}

			dt = conn.GetDataTable().Copy();
			dgListApproval.DataSource = dt;
			try 
			{
				dgListApproval.DataBind();
			}
			catch 
			{
				dgListApproval.CurrentPageIndex = 0;
				dgListApproval.DataBind();
			}

			
			/// Menghitung ulang Application Value
			/// karena stored procedure list_approval menghasilkan limit application yang keliru
			/// 
			for (int i = 0; i < dgListApproval.Items.Count; i++)
			{
				//conn.QueryString = "DE_TOTALEXPOSURE '" + dgListApproval.Items[i].Cells[0].Text.Trim() + "'";
				//conn.ExecuteQuery(300);
				//dgListApproval.Items[i].Cells[4].Text = tool.MoneyFormat(conn.GetFieldValue("tot_limit"));
				dgListApproval.Items[i].Cells[4].Text = tool.MoneyFormat(dgListApproval.Items[i].Cells[4].Text);
			}
			

			/***
			 * Yudi : Formatting dilakukan saat design DataGrid saja ...
			 * 
			for (int i = 0; i < dgListApproval.Items.Count; i++)
			{
				dgListApproval.Items[i].Cells[3].Text = tool.FormatDate(dgListApproval.Items[i].Cells[3].Text, true);
				dgListApproval.Items[i].Cells[4].Text = tool.MoneyFormat(dgListApproval.Items[i].Cells[4].Text);
				//lbl_prod.Text		=  conn.GetFieldValue(i,4);
				//lbl_apptype.Text	=  conn.GetFieldValue(i,7);
			}
			****/
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
			this.dgListApproval.ItemCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.dgListApproval_ItemCommand);

		}
		#endregion

		private void dgListApproval_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			switch (((LinkButton)e.CommandSource).CommandName)
			{
				case "view":
					//
					// Kalau TC kosong, berarti dipanggil oleh Facilities -> inquiry app in apprv commitee
					//
					if (Request.QueryString["tc"] == "" || Request.QueryString["tc"] == null) 
					{
						Response.Redirect("ApprovalCommite.aspx?regno="+e.Item.Cells[0].Text+
							"&curef="+e.Item.Cells[1].Text+
							"&tc="+Request.QueryString["tc"]+
							"&mc="+Request.QueryString["mc"]);
					}

					//--- sebelum lanjut : periksa dulu GROUP USER-nya.
					//--- Kalau BU (01*) : link PRRK tidak ada (menucode=011)
					//--- Kalau Approval Commitee : ???
					string mc = Request.QueryString["mc"];
					string GROUPID = (string) Session["GroupID"];

					conn.QueryString = "select * from VW_APPR_GROUP_CEK where GROUPID = '"+GROUPID+"'";
					conn.ExecuteQuery();

					try 
					{
						mc = conn.GetFieldValue("MENUCODE");
					} 
					catch {}

					/*
					if (GROUPID.StartsWith("01"))		//--- BU
					{
						mc = "011";
					}
					else if (GROUPID.StartsWith("02"))	//--- RM
					{
						mc = "012";
					}
					*/
					
					//--- Kalau merupakan Approval commitee, dimana :
					//    AP_APRVCOMMITEE = AP_APRVNEXTBY
					//	  maka link redirect ke screen approval commitee
					//

					try 
					{
						conn.QueryString = "select AP_APRVCOMMITEE, AP_APRVUNTIL from APPLICATION where AP_REGNO = '" + e.Item.Cells[0].Text + "'";
						conn.ExecuteQuery();
					} 
					catch 
					{
						GlobalTools.popMessage(this, "Connection Error!");
						Response.Redirect("../Login.aspx?expire=1");
					}

					/*
					if (conn.GetFieldValue("AP_APRVCOMMITEE") == lbl_userid.Text && conn.GetFieldValue("AP_APRVUNTIL") == "")
					{
						Response.Redirect("ApprovalCommite.aspx?regno="+e.Item.Cells[0].Text+
							"&curef="+e.Item.Cells[1].Text+
							"&tc="+Request.QueryString["tc"]+
							"&mc="+Request.QueryString["mc"]);
					}
					else 
					*/
					{
						Response.Redirect("Approval.aspx?regno="+e.Item.Cells[0].Text+
							"&curef="+e.Item.Cells[1].Text+
							"&tc="+Request.QueryString["tc"]+
							"&mc="+Request.QueryString["mc"]);
					}
					break;
			}
		}

		protected void btn_cari_Click(object sender, System.EventArgs e)
		{
			ViewData();
		}
	}
}
