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

namespace SME.LOW
{
	/// <summary>
	/// Summary description for PostFin.
	/// </summary>
	public partial class PostFin : System.Web.UI.Page
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
				viewExchangeRate();
				
				GlobalTools.fillRefList(DDL_APPTYPE, "select apptypeid, apptypedesc from rfapplicationtype where active='1'", false, conn);
				try
				{
					DDL_APPTYPE.SelectedValue	= Request.QueryString["app"];
				}
				catch
				{
					DDL_APPTYPE.SelectedValue = "";
				}
				DDL_APPTYPE.Enabled = false;

				GlobalTools.fillRefList(DDL_NCLPROD, "EXEC IDE_POSTFIN_GETNCLPRODUCT '" + Request.QueryString["curef"] + "'", false, conn);
				try
				{
					DDL_NCLPROD.SelectedValue	= Request.QueryString["ncl"];
				}
				catch
				{
					DDL_NCLPROD.SelectedValue = "";
				}

				GlobalTools.fillRefList(DDL_CP_TENORCODE, "select tenorcode, tenordesc from rftenorcode where active='1'", false, conn);

				DDL_PRODUCTID.Items.Add(new ListItem("- PILIH -", ""));
				conn.QueryString = "select PRODUCTID, PRODUCTDESC from VW_PROGPROD where PROGRAMID='" + Request.QueryString["prog"] + "' and ACTIVE='1'";
				conn.ExecuteQuery();
				for (int i = 0; i < conn.GetRowCount(); i++)
					DDL_PRODUCTID.Items.Add(new ListItem(conn.GetFieldValue(i,0) + " - " + conn.GetFieldValue(i,1), conn.GetFieldValue(i,0)));

				DDL_CP_LOANPURPOSE.Items.Add(new ListItem("- PILIH -", ""));
				conn.QueryString = "select LOANPURPID, LOANPURPID + ' - ' + LOANPURPDESC as LOANPURPDESC from RFLOANPURPOSE where ACTIVE='1' order by LOANPURPID";
				conn.ExecuteQuery();
				for (int i = 0; i < conn.GetRowCount(); i++)
					DDL_CP_LOANPURPOSE.Items.Add(new ListItem(conn.GetFieldValue(i,1), conn.GetFieldValue(i,0)));

				ViewApplications();
			}
		}

		private void ViewApplications()
		{
			conn.QueryString = "select KET_CODE from KETENTUAN_KREDIT where ap_regno='" + Request.QueryString["regno"] + "'";
			conn.ExecuteQuery();
			string KET_CODE = conn.GetFieldValue("KET_CODE");
			
			DataTable dt1 = new DataTable();
			conn.QueryString = "select * from VW_IDE_LISTAPPLICATION where AP_REGNO='" + Request.QueryString["regno"] + "' and KET_CODE = '" + KET_CODE + "'";
			conn.ExecuteQuery();
			dt1 = conn.GetDataTable().Copy();
			DATAGRID1.DataSource = dt1;
			DATAGRID1.DataBind();

			for (int i = 0; i < DATAGRID1.Items.Count; i++)
			{
				if (DATAGRID1.Items[i].Cells[5].Text != "&nbsp;")
					DATAGRID1.Items[i].Cells[5].Text = tool.MoneyFormat(DATAGRID1.Items[i].Cells[5].Text);
				if (DATAGRID1.Items[i].Cells[6].Text != "&nbsp;")
					DATAGRID1.Items[i].Cells[6].Text = tool.MoneyFormat(DATAGRID1.Items[i].Cells[6].Text);

				//if (DATAGRID1.Items[i].Cells[8].Text.Trim() != "&nbsp;")
				//	DATAGRID1.Items[i].Cells[8].Text = DATAGRID1.Items[i].Cells[8].Text + " Bulan";
			}
		}

		private void Clear()
		{
			TXT_CP_LIMIT.Text = "";
			TXT_CP_JANGKAWKT.Text = "";
			TXT_CP_EXRPLIMIT.Text = "1";
			DDL_CP_LOANPURPOSE.SelectedValue ="";
			TXT_CP_EXLIMITVAL.Text = "";
			TXT_CP_NOTES.Text = "";
			DDL_PRODUCTID.SelectedValue = "";
		}

		private void viewExchangeRate() 
		{
			try 
			{
				conn.QueryString = "select PRODUCTID, CURRENCY, C.CURRENCYRATE " +
					"from RFPRODUCT p " +
					"left join RFCURRENCY c on P.CURRENCY = C.CURRENCYID " +
					"where C.ACTIVE = '1' and P.ACTIVE = '1' and PRODUCTID = '" + Request.QueryString["prod"] + "'";
				conn.ExecuteQuery();

				TXT_CP_EXRPLIMIT.Text = conn.GetFieldValue("CURRENCYRATE");
			} 
			catch (NullReferenceException) 
			{
				Tools.popMessage(this, "Connection Error !");
				return;
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
			this.DATAGRID1.ItemCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.DATAGRID1_ItemCommand);

		}
		#endregion

		protected void BTN_SAVE_Click(object sender, System.EventArgs e)
		{
			//Check limit
			conn.QueryString = "exec IDE_POSTFIN_GETNCLLIMIT '" + Request.QueryString["ncl"] + "'";
			conn.ExecuteQuery();
			double remaininglimit = double.Parse(conn.GetFieldValue("CP_LIMIT"));
			double applyvalue = double.Parse(TXT_CP_LIMIT.Text);
			if (applyvalue > remaininglimit)
			{
				GlobalTools.popMessage(this, "Apply Value Exceeds Remaining NCL Limit!");
				return;
			}

			
			string vPROD_SEQ = "0";
			try 
			{
				conn.QueryString = "exec IDE_LOANINFO_POSTFIN '" + Request.QueryString["regno"] + "', '" + 
					DDL_APPTYPE.SelectedValue + "', '" + DDL_PRODUCTID.SelectedValue + "', " + 
					tool.ConvertFloat(TXT_CP_LIMIT.Text) + ", '" + DDL_CP_LOANPURPOSE.SelectedValue + "', " +
					tool.ConvertFloat(TXT_CP_EXRPLIMIT.Text) + ", " + 
					tool.ConvertFloat(TXT_CP_EXLIMITVAL.Text) + ", '" + 
					TXT_CP_NOTES.Text + "', " + 
					TXT_CP_JANGKAWKT.Text + ", " + 
					tool.ConvertNull(DDL_CP_TENORCODE.SelectedValue) + ", '" +
					DDL_NCLPROD.SelectedValue + "'";
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

			vPROD_SEQ = conn.GetFieldValue("PROD_SEQ");

			//--- menyimpan data parent application untuk jika sub application --//
			try 
			{
				conn.QueryString = "exec IDE_LOANINFO_SUBAPP '" + 
					Request.QueryString["regno"] + "', '" + 
					DDL_APPTYPE.SelectedValue + "', '" + 
					DDL_PRODUCTID.SelectedValue + "', '" + 
					LBL_MAINREGNO.Text + "', '" +
					LBL_MAINPRODUCTID.Text + "', '" + 
					LBL_MAINPROD_SEQ.Text + "'";
				conn.ExecuteNonQuery();					
			} 
			catch (NullReferenceException) 
			{
				GlobalTools.popMessage(this, "Connection Error!");
				return;
			}

			try 
			{
				conn.QueryString = "exec IDE_LOANINFO_GENERAL '" + 
					Request.QueryString["regno"] + "', '" + 
					DDL_APPTYPE.SelectedValue + "', '" + 
					DDL_PRODUCTID.SelectedValue + "', '" + 
					Request.QueryString["tc"] + "', '" + 
					LBL_USERID.Text + "'";
				conn.ExecuteNonQuery();
			} 
			catch (NullReferenceException) 
			{
				GlobalTools.popMessage(this, "Connection Error!");
				return;
			}

			ViewApplications();

			//Mengingat 1 ketentuan kredit hanya 1 post fin, 
			//maka setelah permohonan dibuat, tidak bisa membuat pengajuan lagi
			//dengan jenis yang sama
			TR_JENISPENGAJUAN.Visible = false;
			TR_BUTTONS.Visible = false;
		}

		protected void Button2_Click(object sender, System.EventArgs e)
		{
			Response.Redirect("FairIsaac.aspx?regno=" + Request.QueryString["regno"] + "&curef=" + Request.QueryString["curef"] + "&prog=" + Request.QueryString["prog"] + "&tc=" + Request.QueryString["tc"] + "&mc=" + Request.QueryString["mc"]);
		}

		protected void Button1_Click(object sender, System.EventArgs e)
		{
			//conn.QueryString = "select checkbi from customer where cu_ref='" + Request.QueryString["curef"] + "'";
			conn.QueryString = "select ap_checkbi from application where ap_regno='" + Request.QueryString["regno"] + "'";
			conn.ExecuteQuery();
			if (conn.GetRowCount() > 0)
			{
				if (conn.GetFieldValue(0,0) == "1")
				{
					conn.QueryString = "insert into bi_status (ap_regno, cu_ref, bs_reqdate, bs_recvdate, bs_bidataavail, bs_complete) " + 
						"values ('" + Request.QueryString["regno"] + "', '" + Request.QueryString["curef"] + "', getdate(), null, null, '0')";
					conn.ExecuteQuery();
				}
			}

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
					LBL_USERID.Text + "', '" + 
					dt.Rows[i]["PROD_SEQ"].ToString() + "','"+Request.QueryString["tc"].Trim()+"'";
				conn.ExecuteNonQuery();
			}
			Response.Redirect("FindCustomer.aspx?tc=" + Request.QueryString["tc"] + "&mc=" + Request.QueryString["mc"]);
		}

		private void DATAGRID1_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			switch (((LinkButton)e.CommandSource).CommandName)
			{
				case "delete":
					/*
					conn.QueryString = "delete from apptrack where ap_regno='" + Request.QueryString["regno"] + "' and apptype='" + e.Item.Cells[1].Text + "' and productid='" + e.Item.Cells[3].Text + "' and PROD_SEQ = '" + e.Item.Cells[9].Text + "'";
					conn.ExecuteNonQuery();

					conn.QueryString = "delete from custproduct where ap_regno='" + Request.QueryString["regno"] + "' and apptype='" + e.Item.Cells[1].Text + "' and productid='" + e.Item.Cells[3].Text + "' and PROD_SEQ = '" + e.Item.Cells[9].Text + "'";
					conn.ExecuteNonQuery();

					conn.QueryString = "delete from trackhistory where ap_regno='" + Request.QueryString["regno"] + "' and apptype='" + e.Item.Cells[1].Text + "' and productid='" + e.Item.Cells[3].Text + "' and PROD_SEQ = '" + e.Item.Cells[9].Text + "'";
					conn.ExecuteNonQuery();

					conn.QueryString = "delete from listcollateral where ap_regno='" + Request.QueryString["regno"] + "' and productid='" + e.Item.Cells[3].Text + "' and PROD_SEQ = '" + e.Item.Cells[9].Text + "'";
					conn.ExecuteNonQuery();
					*/


					/****************************************************************************************
					 * Kalau delete dari selain IDE, tidak bisa dilakukan jika tinggal 1 jenis pengajuan
					 *****************************************************************************************/
					conn.QueryString = "select * from scgroup_init2 where gr_key like '%IDE%' and groupid = '" + Request.QueryString["tc"] + "'";
					conn.ExecuteQuery();
					if (conn.GetRowCount() == 0 && DATAGRID1.Items.Count == 1) 
					{
						GlobalTools.popMessage(this, "Jenis Pengajuan tidak bisa dihapus karena aplikasi akan tidak memiliki kredit !");
						return;
					}
					/****************************************************************************************/


					try 
					{ 
						conn.QueryString = "exec IDE_LOANINFO_DELETE '" + 
							Request.QueryString["regno"] + "', '" + 
							e.Item.Cells[1].Text + "', '" + // apptype
							e.Item.Cells[3].Text + "', '" + // productid
							e.Item.Cells[9].Text + "'";		// prod_seq
						conn.ExecTrans();
						conn.ExecTran_Commit();
					} 
					catch (Exception ex)
					{
						if (conn != null)
							conn.ExecTran_Rollback();
						ExceptionHandling.Handler.saveExceptionIntoWindowsLog(ex, Request.Path, "ERROR DELETE : " + Request.QueryString["regno"]);
					}

					break;
			}
			ViewApplications();
		}

		protected void DDL_PRODUCTID_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			try 
			{
				conn.QueryString = "select PRODUCTID, CURRENCY, C.CURRENCYRATE " +
					"from RFPRODUCT p " +
					"left join RFCURRENCY c on P.CURRENCY = C.CURRENCYID " +
					"where C.ACTIVE = '1' and P.ACTIVE = '1' and PRODUCTID = '" + DDL_PRODUCTID.SelectedValue + "'";
				conn.ExecuteQuery();

				TXT_CP_EXRPLIMIT.Text = conn.GetFieldValue("CURRENCYRATE");
			} 
			catch (NullReferenceException) 
			{
				Tools.popMessage(this, "Connection Error !");
				return;
			}
		}
	}
}
