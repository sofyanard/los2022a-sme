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
	/// Summary description for BankRelation.
	/// </summary>
	public partial class ScoreRatingData : System.Web.UI.Page
	{	
		protected System.Web.UI.WebControls.Button BTN_CLOSE;

		#region " My Variables "
		protected Connection conn;
		protected Tools tool = new Tools();
		private string curef;
		#endregion

	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			conn = (Connection) Session["Connection"];			
			curef = Request.QueryString["curef"];

			if (!IsPostBack)
			{
				string query = "select COLLECTID, COLLECTDESC from RFCOLLECTABILITY1 where ACTIVE = '1' order by COLLECTID ASC";
				
				GlobalTools.fillRefList(DDL_APP_CUR_COLLECTABILITAS, query, false, conn);
				viewData();
			}
			secureData();
		}

		private void secureData() 
		{
			if (Request.QueryString["de"] != "1") 
			{
				RDO_CURR_KOLEKTIBILITAS.Enabled = false;
				RDO_DEFAULT_LOSS.Enabled = false;
				RDO_PRIORRESULT_LOSS.Enabled = false;
				RDO_RESTRUKTUR_KREDIT.Enabled = false;
				RDO_REVOLVING_NOW.Enabled = false;

				BTN_SAVE.Visible = false;
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
		private void viewData() 
		{
			try 
			{
				conn.QueryString = "select * from DE_SCORINGRATINGDATA where CU_REF = '" + curef + "'";
				conn.ExecuteQuery();
			}
			catch (NullReferenceException) 
			{
				GlobalTools.popMessage(this, "Connection Error!");
				Response.Redirect("../Login.aspx?expire=1");
			}

			try 
			{
				RDO_CURR_KOLEKTIBILITAS.SelectedValue	= conn.GetFieldValue("CURR_KOLEKTIBILITAS");
			}
			catch {}

			try 
			{
				RDO_RESTRUKTUR_KREDIT.SelectedValue		= conn.GetFieldValue("CURR_KOLEKTIBILITAS");
			} 
			catch {}

			try 
			{
				RDO_DEFAULT_LOSS.SelectedValue			= conn.GetFieldValue("DEFAULT_LOSS");
			}
			catch {}

			try 
			{
				RDO_PRIORRESULT_LOSS.SelectedValue		= conn.GetFieldValue("PRIORRESULT_LOSS");
			} 
			catch {}

			try 
			{
				RDO_RESTRUKTUR_KREDIT.SelectedValue		= conn.GetFieldValue("RESTRUKTUR_KREDIT");
			} 
			catch {}

			try 
			{
				RDO_REVOLVING_NOW.SelectedValue			= conn.GetFieldValue("REVOLVING_NOW");
			} 
			catch {}
			try 
			{
				DDL_APP_CUR_COLLECTABILITAS.SelectedValue = conn.GetFieldValue("COLLECTID");
			} 
			catch {}
		}
			

		protected void BTN_SAVE_Click(object sender, System.EventArgs e)
		{
			try 
			{
//                string APP_CUR_COL = "";
//				if (DDL_APP_CUR_COLLECTABILITAS.SelectedIndex != 0) // memilih -SELECT-
//					APP_CUR_COL = DDL_APP_CUR_COLLECTABILITAS.SelectedValue;
//				if (DDL_APP_CUR_COLLECTABILITAS.SelectedIndex == 0)
//				{
//					Response.Write("<script language='javascript'>alert('Applicants Current Collectibilitas belum dipilih');</script>");
//					return;
//				}

				conn.QueryString = "exec SP_DE_SCORINGRATINGDATA '" + 
						curef + "', '" + 
						RDO_CURR_KOLEKTIBILITAS.SelectedValue + "', '" + 
						RDO_RESTRUKTUR_KREDIT.SelectedValue + "', '" + 
						RDO_PRIORRESULT_LOSS.SelectedValue + "', '" + 
						RDO_REVOLVING_NOW.SelectedValue + "', '" + 
						RDO_DEFAULT_LOSS.SelectedValue + "', '" +
						DDL_APP_CUR_COLLECTABILITAS.SelectedValue + "'";
				conn.ExecuteNonQuery();
			} 
			catch (NullReferenceException) 
			{
				GlobalTools.popMessage(this, "Connection Error!");
				Response.Redirect("../Login.aspx?expire=1");
			}

			viewData();
		}

		protected void RDO_PRIORRESULT_LOSS_SelectedIndexChanged(object sender, System.EventArgs e)
		{
		
		}
	}
}