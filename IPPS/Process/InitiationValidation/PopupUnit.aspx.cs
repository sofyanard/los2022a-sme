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
using System.Configuration;
using DMS.CuBESCore;
using DMS.DBConnection;
using Microsoft.VisualBasic;

namespace SME.IPPS.Process.InitiationValidation
{
	/// <summary>
	/// Summary description for PopupUnit.
	/// </summary>
	public partial class PopupUnit : System.Web.UI.Page
	{
		protected Connection conn = new Connection(ConfigurationSettings.AppSettings["conn"]);
		private string theForm, theObj1, regno,reqseq;
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			theForm = Request.QueryString["targetFormID"].Trim();
			theObj1 = Request.QueryString["targetObjectID1"].Trim();
			regno = Request.QueryString["ippsregno"].Trim();
			reqseq = Request.QueryString["reqseq"].Trim();

			if(!IsPostBack)
			{
				PopulateGridUnit();
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
			this.DG_List_Unit.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(this.DG_List_Unit_ItemDataBound);

		}
		#endregion

		protected void BTN_INSERT_Click(object sender, System.EventArgs e)
		{
			
			string listName="";
			string listCode="";
			string temp="";

			int rowDgr;

			rowDgr=DG_List_Unit.Items.Count;

			for (int i=0;i<rowDgr;i++)
			{
				System.Web.UI.WebControls.CheckBox cek=(System.Web.UI.WebControls.CheckBox)DG_List_Unit.Items[i].Cells[0].FindControl("ckbx_cek");

				if(cek.Checked==true)
				{
					listCode=listCode + DG_List_Unit.Items[i].Cells[2].Text + ",";
					listName=listName + DG_List_Unit.Items[i].Cells[3].Text + ",";
				}			
			}

			listCode=listCode.Substring(0,listCode.Length-1);
			listName=listName.Substring(0,listName.Length-1);
			temp=listCode + "=" + listName;

			Response.Write("<script language='JavaScript1.2'>window.opener.document." + 
				theForm + "." + theObj1 + ".value='" + temp + "'; " + "window.opener.document." +
				theForm + ".submit(); window.close();</script>");
//
////			Response.Write("<script language='JavaScript1.2'>window.opener.document." + 
//						theForm + "." + theObj + ".value='" + e.Item.Cells[0].Text.Trim() + "'; " +
//						"window.opener.document." + theForm + ".submit(); window.close();</script>");
		}

		private void PopulateGridUnit()
		{
			conn.QueryString = "EXEC IPPS_POPULATE_UNITREVIEWER";
			conn.ExecuteQuery();
			FillGrid();
		}

		private void FillGrid()
		{
			DataTable dt = new DataTable();
			dt = conn.GetDataTable().Copy();
			DG_List_Unit.DataSource = dt;
			try 
			{
				DG_List_Unit.DataBind();
			} 
			catch 
			{
				DG_List_Unit.CurrentPageIndex = 0;
				DG_List_Unit.DataBind();
			}
		}

		private void DG_List_Unit_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			if ( e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item ) 
			{
				System.Web.UI.WebControls.CheckBox cek=(System.Web.UI.WebControls.CheckBox)e.Item.Cells[0].FindControl("ckbx_cek");
				string code = e.Item.Cells[2].Text;
				
				conn.QueryString = "select count(REV_SEQ) as total from ipps_review " +
								   " where IPPS_REGNO='" + regno + "' and REQ_SEQ='" + reqseq + "' and ASSIGN_TOUNIT='" + code + "'";
				conn.ExecuteQuery();

				if (conn.GetFieldValue("total")!="0")
				{
                    cek.Checked=true;
				}
			}
		}

		protected void BTN_CLEAR_Click(object sender, System.EventArgs e)
		{
			int rowDgr;

			rowDgr=DG_List_Unit.Items.Count;

			for (int i=0;i<rowDgr;i++)
			{
				System.Web.UI.WebControls.CheckBox cek=(System.Web.UI.WebControls.CheckBox)DG_List_Unit.Items[i].Cells[0].FindControl("ckbx_cek");

				cek.Checked=false;		
			}
		}

	}
}
