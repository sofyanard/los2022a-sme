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
using Microsoft.VisualBasic;
namespace SME.DataEntry
{
	/// <summary>
	/// Summary description for Memo.
	/// </summary>
	public partial class Memo : System.Web.UI.Page
	{
		protected Connection conn;
		protected Tools tool = new Tools();

		protected void Page_Load(object sender, System.EventArgs e)
		{
			conn = (Connection) Session["Connection"];

			if (!Logic.AllowAccess(Session["GroupID"].ToString(), Request.QueryString["mc"], conn))
				Response.Redirect("/SME/Restricted.aspx");

			isiGrid();
		}

		void isiGrid()
		{
			DataTable dt = new DataTable();
			conn.QueryString="Select * from vw_memo";
			conn.ExecuteQuery();
			dt = conn.GetDataTable().Copy();
			DatGrd.DataSource = dt;
			DatGrd.DataBind();
			for (int i = 0; i < DatGrd.Items.Count; i++)
			{
				DatGrd.Items[i].Cells[2].Text = ""+tool.FormatDate_Day(DatGrd.Items[i].Cells[2].Text)+"-"+tool.FormatDate_MonthName(DatGrd.Items[i].Cells[2].Text)+"-"+tool.FormatDate_Year(DatGrd.Items[i].Cells[2].Text)+"";
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
			this.DatGrd.ItemCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.DatGrd_ItemCommand);
			this.DatGrd.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.DatGrd_PageIndexChanged);

		}
		#endregion

		private void DatGrd_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			DatGrd.CurrentPageIndex = e.NewPageIndex;
			isiGrid();
		}


		protected void BTN_SAVE_Click(object sender, System.EventArgs e)
		{
			if (TXT_REGNO.Text =="")//insert
			{
				if (TXT_TM_CONTENT.Text.Trim() != "")
				{
					conn.QueryString="exec DE_MEMO '19042004001000001','','','"+ TXT_TM_CONTENT.Text +"','Endi',0";
					conn.ExecuteQuery();
					isiGrid();
				
				}
			}
			else //update
			{
				conn.QueryString="exec DE_MEMO '19042004001000001',"+ tool.ConvertNum(TXT_TMSEQ.Text) +",'','"+ TXT_TM_CONTENT.Text +"','Endi',2";
				conn.ExecuteQuery();
				isiGrid();
				TXT_REGNO.Text="";
				TXT_TMSEQ.Text="";
			}
			TXT_TM_CONTENT.Text="";
		}


		private void DatGrd_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			switch(((LinkButton)e.CommandSource).CommandName)
			{
				case "Delete":	
					conn.QueryString="exec DE_MEMO '"+ e.Item.Cells[0].Text +"',"+ tool.ConvertNum(e.Item.Cells[1].Text) +",'','','',1 ";
					conn.ExecuteQuery();

					int index = DatGrd.Items.Count;
					int jml = (index % 3)-1;
					if (jml == 0)
						DatGrd.CurrentPageIndex = index/3;
					break;

				case "Edit":
					conn.QueryString="select tm_content from vw_memo where ap_regno ='"+ e.Item.Cells[0].Text +"' and tm_seq = "+tool.ConvertNum(e.Item.Cells[1].Text)+" ";
					conn.ExecuteQuery();
					TXT_TM_CONTENT.Text = conn.GetFieldValue("tm_content");//"select tm_content from vw_memo where ap_regno ='"+ e.Item.Cells[0].Text +"' and tm_seq = "+tool.ConvertNum(e.Item.Cells[0].Text)+" ";//conn.GetFieldValue("TM_content");
					TXT_REGNO.Text = e.Item.Cells[0].Text;
					TXT_TMSEQ.Text = e.Item.Cells[1].Text;
					//Server.Transfer("Memo.aspx?Edit=1");
					break;
				default:
					// Do nothing.
					break;
			}
			isiGrid();
		}
	}
}
