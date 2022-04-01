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
using DMS.BlackList;

namespace SME.IDI_BI
{
	/// <summary>
	/// Summary description for ChooseBIData.
	/// </summary>
	public partial class ChooseBIData : System.Web.UI.Page
	{
		protected Connection conn;
		protected System.Web.UI.WebControls.TextBox TXT_TGL_LAHIR;
		protected System.Web.UI.WebControls.DropDownList DDL_BLN_LAHIR;
		protected System.Web.UI.WebControls.TextBox TXT_THN_LAHIR;
		protected System.Web.UI.HtmlControls.HtmlTableRow TR_TGL;
		protected Tools tool = new Tools();
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			conn = (Connection) Session["Connection"];
			if (!IsPostBack)
			{					
				//conn.QueryString="select * from VW_IDI_REQUEST_TRACK_LIST where idi_officer='"+Session["UserID"].ToString()+"' and idi_status='0' ";
				//conn.ExecuteQuery();
				conn.QueryString="select * from VW_IDI_TRACK_LIST where idi_officer='"+Session["UserID"].ToString()+"' and idi_trackcode='BI.2' order by idi_reqdate desc ";
				conn.ExecuteQuery();
				FillGrid();
				string officer = conn.GetFieldValue("idi_officer");
				LBL_IDI_REQ.Text = conn.GetFieldValue("idi_req#");
				
				//conn.QueryString="select * from VW_IDI_TRACK_LIST where idi_trackcode='BI.2'";
				//conn.ExecuteQuery();
				if (conn.GetFieldValue("idi_trackcode")!= "BI.2")
				{
					BTN_SAVE.Enabled = false;
					//BTN_CLEAR.Enabled = false;
					BTN_UPDATE.Enabled = false;
				}

				conn.QueryString="select top 0 * from idi_result where idi_officer='"+Session["UserID"].ToString()+"' and idi_status='1' ";
				conn.ExecuteQuery();
				FillGrid2();				
				BTN_UPDATE.Enabled = false;				
			}	
		}

		private void FillGrid()
		{
			DataTable dt = new DataTable();
			dt = conn.GetDataTable().Copy();
			DGR_REQ.DataSource = dt;
			try 
			{
				DGR_REQ.DataBind();
			} 
			catch 
			{
				DGR_REQ.CurrentPageIndex = 0;
				DGR_REQ.DataBind();
			}
		}

		private void FillGrid2()
		{
			DataTable dt = new DataTable();
			dt = conn.GetDataTable().Copy();
			DGR_RESULT.DataSource = dt;
			try 
			{
				DGR_RESULT.DataBind();
			} 
			catch 
			{
				DGR_RESULT.CurrentPageIndex = 0;
				DGR_RESULT.DataBind();
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
			this.DGR_REQ.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.DGR_REQ_PageIndexChanged);

		}
		#endregion
		

		private void DGR_REQ_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			DGR_REQ.CurrentPageIndex = e.NewPageIndex;
		}

		private void DGR_RESULT_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			DGR_RESULT.CurrentPageIndex = e.NewPageIndex;
		}

		protected void BTN_RETRIEVE_Click(object sender, System.EventArgs e)
		{
			//conn.QueryString="select * from VW_IDI_RESULT_TRACK_LIST where idi_officer='"+Session["UserID"].ToString()+"' and idi_status='1' and idi_trackcode='BI.2' ";
			conn.QueryString="select * from VW_IDI_RESULT_TRACK_LIST where idi_officer='"+Session["UserID"].ToString()+"' and idi_trackcode='BI.2' order by idi_reqdate desc";
			conn.ExecuteQuery();
			FillGrid2();			
		}

		protected void BTN_SAVE_Click(object sender, System.EventArgs e)
		{
			string tanggallahir ="";
			for (int i = 0; i < DGR_RESULT.Items.Count; i++)
			{				
				//TextBox txtnextdate_day = (TextBox) DGR_LIST.Items[i].Cells[6].FindControl("TXT_COV_NEXTDATE_DAY");
				CheckBox checkbox = (CheckBox)DGR_RESULT.Items[i].Cells[8].FindControl("check");
				
				//try
				//{			

					string choose = null;					
					if(checkbox.Checked == false)
					{
						choose = "0";
					}
					else
					{
						choose = "1";						
					}					
				
					tanggallahir = DGR_RESULT.Items[i].Cells[6].Text.Substring(6,4) + "-" +DGR_RESULT.Items[i].Cells[6].Text.Substring(3,2)+ "-" +DGR_RESULT.Items[i].Cells[6].Text.Substring(0,2);

					conn.QueryString = "exec IDI_BI_REQUEST_INSERT2 '" +
						DGR_RESULT.Items[i].Cells[0].Text.Trim() + "' , '" + //no_surat
						DGR_RESULT.Items[i].Cells[1].Text.Trim() + "' , '" + //ap_regno
						DGR_RESULT.Items[i].Cells[2].Text.Trim() + "' , '" + //din
						DGR_RESULT.Items[i].Cells[3].Text.Trim() + "' , '" + //nama_debitur
						DGR_RESULT.Items[i].Cells[4].Text.Trim() + "' , '" + //npwp
						DGR_RESULT.Items[i].Cells[5].Text.Trim() + "' , " + //no_ktp						
						tool.ConvertDate(DGR_RESULT.Items[i].Cells[6].Text.Trim()) + " , '" + //tgl_lahir							
						//DGR_RESULT.Items[i].Cells[6].Text.Trim() + "' , '" + //tgl_lahir	
						DGR_RESULT.Items[i].Cells[7].Text.Trim() + "' , '" + //idi_born_place
						DGR_RESULT.Items[i].Cells[8].Text.Trim() + "' , '" + //alamat
						DGR_RESULT.Items[i].Cells[9].Text.Trim() + "' , '" + //idi_zipcode						
						DGR_RESULT.Items[i].Cells[10].Text.Trim() + "' , '" + //idi_dati2
						DGR_RESULT.Items[i].Cells[12].Text.Trim() + "' , '" + //idi_officer
						DGR_RESULT.Items[i].Cells[13].Text.Trim() + "' , '" + //seq
						choose + "', " + //idi_choose
						tool.ConvertDate(DGR_RESULT.Items[i].Cells[14].Text.Trim()) + " "; //idi_reqdate									
					conn.ExecuteNonQuery();

					BTN_UPDATE.Enabled = true;
				//}			
						
				/*catch (Exception ex)
				{					
					string errmsg = ex.Message.Replace("'","");
					if (errmsg.IndexOf("Last Query:") > 0)
						errmsg = errmsg.Substring(0, errmsg.IndexOf("Last Query:"));
					GlobalTools.popMessage(this, errmsg);
					return;
				} */
			}
		}

		protected void BTN_CLEAR_Click(object sender, System.EventArgs e)
		{
			conn.QueryString="select top 0 * from idi_result where idi_officer='"+Session["UserID"].ToString()+"' and idi_status='1' ";
			conn.ExecuteQuery();
			FillGrid2();
		}

		protected void BTN_UPDATE_Click(object sender, System.EventArgs e)
		{		
			for (int i = 0; i < DGR_RESULT.Items.Count; i++)
			{
				conn.QueryString = "exec IDI_TRACKUPDATE '" + 
					DGR_RESULT.Items[i].Cells[1].Text.Trim() + "', '" +
					Request.QueryString["tc"] + "', '" +
					Session["UserID"].ToString() + "' ";				
				conn.ExecuteNonQuery();					
			}
						
			
			Response.Redirect("../Body.aspx?tc=" + Request.QueryString["tc"] + "&mc=" + Request.QueryString["mc"]);	
		}

		protected void DGR_REQ_SelectedIndexChanged(object sender, System.EventArgs e)
		{
		
		}
	}
}
