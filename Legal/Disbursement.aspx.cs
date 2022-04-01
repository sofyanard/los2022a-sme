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
using System.Configuration;

namespace SME.Legal
{
	/// <summary>
	/// Summary description for Disbursement.
	/// </summary>
	public partial class Disbursement : System.Web.UI.Page
	{
		//protected Connection conn = new Connection("Data Source=10.123.12.30;Initial Catalog=SMEDEV;uid=sa;pwd=");
		protected Connection conn;
		protected Tools tools = new Tools();
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			conn = (Connection) Session["Connection"];

            InitializeEvent();

			if (!IsPostBack)
			{
				LBL_REGNO.Text	= Request.QueryString["regno"];
				LBL_TC.Text		= Request.QueryString["tc"];

				conn.ClearData();
				DDL_BLN.Items.Add(new ListItem("- PILIH -", ""));
				for (int i=1; i<=12; i++)
					DDL_BLN.Items.Add(new ListItem(DateAndTime.MonthName(i, false), i.ToString()));
				TXT_TGL.Text	= DateAndTime.Now.Date.Day.ToString();
				TXT_THN.Text	= DateAndTime.Now.Date.Year.ToString();
				DDL_BLN.SelectedValue	= DateAndTime.Now.Date.Month.ToString();
				ViewProses();

                DocExport1.GroupTemplate = "DISBURSESHEET";
			}

			/// View Application Information (product, application type, etc)
			/// 
			viewApplicationInfo();

			ViewData();
			ViewDGR_LIST();
			ViewMenu();
            BTN_UPDATE.Attributes.Add("onclick", "if(!updateMsg('H')){return false;};");
            //BTN_UPDATE.Attributes.Add("onclick", "if(!ConfirmBox('Are you sure want to update ?')){return false;};");
			BTN_DF_INPUT.Attributes.Add("onclick","if(!cek_mandatory(document.Form1)){return false;};");
		}

        private void InitializeEvent()
        {
            this.BTN_UPDATE.Click += new EventHandler(BTN_UPDATE_Click);
        }

		private void viewApplicationInfo() 
		{
			conn.QueryString = "select productdesc, APPTYPEDESC, stat = case when TRACKNAMe is null then 'In Proses' else TRACKNAMe end from custproduct a "+
				"inner join rfproduct b on a.productid=b.productid "+
				"left join rfapplicationtype c on a.apptype=c.APPTYPEID "+
				"left join  rftrack d on a.CP_DECSTA=d.TRACKCODE "+
				"where ap_regno='" + LBL_REGNO.Text + "'";
			conn.ExecuteQuery();
			for (int i = 0; i < conn.GetRowCount(); i++) 
			{
				oTable1.Rows.Add(new TableRow());
				oTable1.Rows[i+1].Cells.Add(new TableCell());
				oTable1.Rows[i+1].Cells[0].Text = conn.GetFieldValue(i, "productdesc");
				oTable1.Rows[i+1].Cells[0].HorizontalAlign = HorizontalAlign.Center;
				oTable1.Rows[i+1].Cells[0].CssClass	= "ReportList";
				
				oTable1.Rows[i+1].Cells.Add(new TableCell());
				oTable1.Rows[i+1].Cells[1].Text = conn.GetFieldValue(i, "APPTYPEDESC");
				oTable1.Rows[i+1].Cells[1].HorizontalAlign = HorizontalAlign.Center;
				oTable1.Rows[i+1].Cells[1].CssClass	= "ReportList";

				oTable1.Rows[i+1].Cells.Add(new TableCell());
				oTable1.Rows[i+1].Cells[2].Text = conn.GetFieldValue(i, "stat");
				oTable1.Rows[i+1].Cells[2].HorizontalAlign = HorizontalAlign.Center;
				oTable1.Rows[i+1].Cells[2].CssClass	= "ReportList";
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
			this.DGR_LIST.ItemCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.DGR_LIST_ItemCommand);

		}
		#endregion

		private void ViewProses()
		{
			DDL_PROSES.Items.Clear();
			conn.QueryString = "select seq, des from vw_syarat where doctypeid='5' and (sy_status='0' or sy_status is null or sy_status='') and ap_regno='"+LBL_REGNO.Text+"'";
			conn.ExecuteQuery();
			DDL_PROSES.Items.Add(new ListItem("-- PILIH --",""));
			int row = conn.GetRowCount();
			for (int i = 0 ; i < row;i++)
				DDL_PROSES.Items.Add(new ListItem(conn.GetFieldValue(i,1),conn.GetFieldValue(i,0)));
			conn.ClearData();
			if (row<=0)
				BTN_UPDATE.Enabled	= true;
			else
				BTN_UPDATE.Enabled	= false;
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
			conn.QueryString = "select AP_REGNO, CU_REF, AP_SIGNDATE, BRANCH_NAME, AP_TMLDRNM, "+
				"AP_RMNM, CU_NAME, CU_ADDR1, CU_ADDR2, CU_ADDR3, CU_CITYNM, CU_PHN, BUSSTYPEDESC, BU_DESC, ANALIS "+
				"from VW_INFOUMUM "+
				"where AP_REGNO = '"+ LBL_REGNO.Text +"' ";
			conn.ExecuteQuery();
			LBL_AP_REGNO.Text					= conn.GetFieldValue("AP_REGNO");
			LBL_CU_REF.Text						= conn.GetFieldValue("CU_REF");
			string AP_SIGNDATE					= conn.GetFieldValue("AP_SIGNDATE");
			LBL_TGL.Text						= tools.FormatDate(AP_SIGNDATE);
			LBL_BRANCH_NAME.Text				= conn.GetFieldValue("BRANCH_NAME");
			LBL_AP_TMLDRNM.Text					= conn.GetFieldValue("AP_TMLDRNM");
			LBL_ANALIS.Text						= conn.GetFieldValue("ANALIS");
			LBL_AP_RMNM.Text					= conn.GetFieldValue("AP_RMNM");
			LBL_CU_NAME.Text					= conn.GetFieldValue("CU_NAME");
			LBL_CU_ADDR1.Text					= conn.GetFieldValue("CU_ADDR1");
			LBL_CU_ADDR2.Text					= conn.GetFieldValue("CU_ADDR2");
			LBL_CU_ADDR3.Text					= conn.GetFieldValue("CU_ADDR3");
			LBL_CU_CITYNM.Text					= conn.GetFieldValue("CU_CITYNM");
			LBL_CU_PHN.Text						= conn.GetFieldValue("CU_PHN");
			LBL_BISNIS_UNIT.Text				= conn.GetFieldValue("BU_DESC");
			LBL_BUSSTYPEDESC.Text				= conn.GetFieldValue("BUSSTYPEDESC");
			conn.ClearData();
		}

		private void ViewDGR_LIST()
		{
			conn.QueryString = "select seq, des, sy_accdate, sy_ket,sy_islengkap = case sy_islengkap when '1' then 'Lengkap' else 'Tidak Lengkap' end  from VW_SYARAT "+
				"where DOCTYPEID = '5' and sy_status='1' and AP_REGNO = '"+ LBL_REGNO.Text +"' ";
			conn.ExecuteQuery();
			DataTable data = new DataTable();
			data = conn.GetDataTable().Copy();
			DGR_LIST.DataSource = data;
			DGR_LIST.DataBind();
			for (int i = 0; i < DGR_LIST.Items.Count; i++)
				DGR_LIST.Items[i].Cells[1].Text = tools.FormatDate(DGR_LIST.Items[i].Cells[1].Text);
		}

		private void ClearItems()
		{
			DDL_PROSES.SelectedValue	= "";
			//TXT_TGL.Text				= "";
			//DDL_BLN.SelectedValue		= "";
			//TXT_THN.Text				= "";
			TXT_KET.Text				= "";
		}

		protected void BTN_DF_INPUT_Click(object sender, System.EventArgs e)
		{
			if (!DDL_PROSES.SelectedValue.Equals(""))
			{
				
				string vlengkap;
				string userid = (string) Session["UserID"];
				string syaratDesc = DDL_PROSES.SelectedItem.Text;

				vlengkap = RDO_SY_ISLENGKAP.SelectedValue;
								
				try 
				{
					if (RDO_SY_ISLENGKAP.SelectedValue == "1") 
					{
					
						if (TXT_TGL.Text!="" && DDL_BLN.SelectedValue != "" && TXT_THN.Text != "")
						{
							conn.QueryString = "exec SP_SYARAT '"+ 
								LBL_REGNO.Text +"', "+
								DDL_PROSES.SelectedValue+", "+
								"'1', "+
								tools.ConvertDate(TXT_TGL.Text, DDL_BLN.SelectedValue, TXT_THN.Text )+", '"+ 
								TXT_KET.Text +"', " +  
								"'5' ,'" + 
								vlengkap + "'";
							conn.ExecTrans();
						}
						else
						{
							GlobalTools.popMessage(this, "Silakan diisi tanggalnya.");
						}
					}
					else
					{
						conn.QueryString = "exec SP_SYARAT '"+ 
							LBL_REGNO.Text +"', "+
							DDL_PROSES.SelectedValue+", "+
							"'1', "+
							tools.ConvertDate(TXT_TGL.Text, DDL_BLN.SelectedValue, TXT_THN.Text )+", '"+ 
							TXT_KET.Text +"', " +  
							"'5' ,'" + 
							vlengkap + "'";
						conn.ExecTrans();
					}


					//----------------- Start AUDIT TRAIL ----------------------
					
					conn.QueryString = "exec SP_AUDITTRAIL_APP '" + 
						LBL_REGNO.Text + "', NULL, NULL, NULL, '" + 
						Request.QueryString["curef"] + "', '" + 
						Request.QueryString["tc"] + "', " + 
						" 'Syarat: " + DDL_PROSES.SelectedItem.Text + "', '" + 
						RDO_SY_ISLENGKAP.SelectedItem.Text + "', '" + 
						userid + "', NULL, 'N'";
					conn.ExecTrans();

					//----------------- End AUDIT TRAIL ----------------------


					conn.ExecTran_Commit();
				} 
				catch 
				{
					if (conn != null)
						conn.ExecTran_Rollback();
				}
			}
			ClearItems();
			ViewDGR_LIST();
			ViewProses();
		}

		private void DGR_LIST_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			switch (((LinkButton)e.CommandSource).CommandName)
			{
				case "delete":
					conn.QueryString = "exec SP_SYARAT '"+ 
						LBL_REGNO.Text +"', "+
						//Int16.Parse(e.Item.Cells[4].Text)+", "+
						Int16.Parse(e.Item.Cells[5].Text)+", "+
						"'0', "+
						tools.ConvertDate(1.ToString(),1.ToString(),2000.ToString())+", '"+ 
						e.Item.Cells[2].Text +"', " + 
						"'5','" + RDO_SY_ISLENGKAP.SelectedValue + "'";
					conn.ExecuteNonQuery();
					break;
			}		
			ViewDGR_LIST();
			ViewProses();
		}

		protected void BTN_UPDATE_Click(object sender, System.EventArgs e)
		{
            conn.QueryString = "exec TRACKUPDATE2 '"+LBL_REGNO.Text+"', '"+Session["UserID"].ToString()+"','"+Request.QueryString["tc"].Trim() +"'";
			conn.ExecuteNonQuery();

            ////////////////////////////////////////////////////
			/// mengupdate track next by
			/// 
			conn.QueryString = "exec TRACKNEXTBY_SET_DISBURSEMENT '" + LBL_REGNO.Text + "'";
			conn.ExecuteNonQuery();

            /* UPLOAD TO CORE
            if (ConfigurationSettings.AppSettings["conn"].Contains("LOSSME_DEV"))
            {
                conn.QueryString = "SELECT CP.AP_REGNO, CP.APPTYPE, CP.PRODUCTID, CP.PROD_SEQ FROM [APPLICATION] A JOIN CUSTPRODUCT CP ON A.AP_REGNO = CP.AP_REGNO JOIN APPTRACK TR ON CP.AP_REGNO = TR.AP_REGNO AND CP.APPTYPE = TR.APPTYPE AND CP.PRODUCTID = TR.PRODUCTID AND CP.PROD_SEQ = TR.PROD_SEQ JOIN RFPRODUCT RP ON RP.PRODUCTID = CP.PRODUCTID WHERE (ISNULL(CP.CP_REJECT,'0') <> '1' and ISNULL(CP.CP_CANCEL,'0') <> '1') AND CP.APPTYPE = '01' AND TR.AP_CURRTRACK IN ('BP16.0','BP18.0') AND (RP.IS_PRK is null or RP.IS_PRK != '1') AND (convert(varchar(20),CP.CP_NOTES) != 'LOAN DONE' or CP.CP_NOTES is null) AND A.AP_REGNO = '" + LBL_REGNO.Text + "'";
                conn.ExecuteQuery();

                if (conn.GetRowCount() > 0)
                {
                    UploadingToCore.UploadToCoreClient upload = new UploadingToCore.UploadToCoreClient();
                    upload.CreateUploadFile(Request.QueryString["regno"], "CIF", "");
                }
                else
                {
                    UploadingToCore.UploadToCoreClient upload = new UploadingToCore.UploadToCoreClient();
                    upload.CreateUploadFile(Request.QueryString["regno"], "CIF", "PRK");
                }
            }
            */
            
            string msg = getNextStepMsg(Request.QueryString["regno"], Request.QueryString["tc"]);
			Response.Redirect("ListDisbursement.aspx?tc=" + Request.QueryString["tc"] + "&mc = " + Request.QueryString["mc"] + "&msg=" + msg);
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


		protected void BTN_BACK_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			Response.Redirect("/SME/" + DMS.CuBESCore.Logic.backLink(Request.QueryString["tc"].ToString(), conn));
		}

		protected void BTN_PRINT_Click(object sender, System.EventArgs e)
		{
			Response.Redirect("DisbursementInvestRqstForm.aspx?regno="+Request.QueryString["regno"]);
		}

		protected void RDO_SY_ISLENGKAP_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if (RDO_SY_ISLENGKAP.SelectedValue == "0") 
			{
				TXT_TGL.Text = "";
				DDL_BLN.SelectedValue = "";
				TXT_THN.Text = "";

				TXT_TGL.ReadOnly = true;
				DDL_BLN.Enabled = false;
				TXT_THN.ReadOnly = true;
			}
			else 
			{
				TXT_TGL.Text = DateTime.Today.Day.ToString();
				try { DDL_BLN.SelectedValue = DateTime.Today.Month.ToString(); } 
				catch {}
				TXT_THN.Text = DateTime.Today.Year.ToString();

				TXT_TGL.ReadOnly = false;
				DDL_BLN.Enabled = true;
				TXT_THN.ReadOnly = false;
			}
		}
	}
}
