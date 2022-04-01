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
using DMS.DBConnection;
using DMS.CuBESCore;
using Microsoft.VisualBasic;
using System.IO;
using System.Diagnostics;

namespace SME.IPPS.Process.FinalDraftEntry
{
	/// <summary>
	/// Summary description for PopupCommittee.
	/// </summary>
	public partial class PopupCommittee : System.Web.UI.Page
	{
		protected Connection conn = new Connection(ConfigurationSettings.AppSettings["conn"]);
		private string theForm, theObj1, regno,reqseq,apprseq,code1;
		string [] temp ;
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			theForm = Request.QueryString["targetFormID"].Trim();
			theObj1 = Request.QueryString["targetObjectID"].Trim();
			regno = Request.QueryString["ippsregno"].Trim();
			reqseq = Request.QueryString["reqseq"].Trim();
			apprseq= Request.QueryString["apprseq"].Trim();
			code1= Request.QueryString["listcode"].Trim();
			temp= code1.Split('!');

			if(!IsPostBack)
			{
				PopulateListCommittee();
				
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
			this.DG_List_Unit.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(this.DG_List_Unit_ItemDataBound_1);

		}
		#endregion

		protected void BTN_INSERT_Click(object sender, System.EventArgs e)
		{
			string listName="";
			string listName2="";

			string listCode="";
			
			string temp="";

			int rowDgr;

			rowDgr=DG_List_Unit.Items.Count;

			for (int i=0;i<rowDgr;i++)
			{
				System.Web.UI.WebControls.CheckBox cek=(System.Web.UI.WebControls.CheckBox)DG_List_Unit.Items[i].Cells[0].FindControl("ckbx_cek");

				if(cek.Checked==true)
				{
					listCode=listCode + DG_List_Unit.Items[i].Cells[1].Text + "!";
					listName=listName + DG_List_Unit.Items[i].Cells[2].Text + "!";
					listName2=listName2 + DG_List_Unit.Items[i].Cells[2].Text + ",";
				}			
			}
			if (listCode!="")
                listCode=listCode.Substring(0,listCode.Length-1);

			if (listName!="")
			listName=listName.Substring(0,listName.Length-1);

			if (listName2!="")
			listName2=listName2.Substring(0,listName2.Length-1);
			
			
			temp=listCode + "=" + listName + "=" + listName2;

			Response.Write("<script language='JavaScript1.2'>window.opener.document." + 
				theForm + "." + theObj1 + ".value='" + temp + "'; " + "window.opener.document." +
				theForm + ".submit(); window.close();</script>");		
			}

		protected void BTN_CLEAR_Click(object sender, System.EventArgs e)
		{
			for(int i=0;i<DG_List_Unit.Items.Count;i++)
			{
				System.Web.UI.WebControls.CheckBox cek=(System.Web.UI.WebControls.CheckBox)DG_List_Unit.Items[i].Cells[0].FindControl("ckbx_cek");

				cek.Checked=false;		
			}
		}

		private void PopulateListCommittee()
		{
			conn.QueryString="select * from IPPS_RFANGGOTACOMMITTEE where active='1'";
			conn.ExecuteQuery();

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
				System.Web.UI.WebControls.CheckBox cek=(System.Web.UI.WebControls.CheckBox)e.Item.FindControl("ckbx_cek");

				//ceklist(cek,e.Item.Cells[1].Text.Trim());
				if (code1!="")
				{
				
					for(int i=0;i<temp.Length;i++)
					{
						if (temp[i].ToString() == e.Item.Cells[1].Text.Trim())
						{
							cek.Checked=true;		
						}		
					}
				}

				else
				{
					ceklist(cek,e.Item.Cells[1].Text.Trim());
				}

			}
		}
		
		private void ceklist(CheckBox cek, string code)
		{
			conn.QueryString="select Approved_by from ipps_approval_info_user where ipps_regno='" + regno + "' and req_seq='" + reqseq + "' and appr_seq='" + apprseq + "' and Approved_by='" + code + "'";
			conn.ExecuteQuery();

			
			
				if (conn.GetRowCount()==0)
				{
					cek.Checked=false;
				}
				else
				{
					cek.Checked=true;
				}
			

		}

		private void DG_List_Unit_ItemDataBound_1(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			if ( e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item ) 
			{
				System.Web.UI.WebControls.CheckBox cek=(System.Web.UI.WebControls.CheckBox)e.Item.FindControl("ckbx_cek");

				//ceklist(cek,e.Item.Cells[1].Text.Trim());
				if (code1!="")
				{
				
					for(int i=0;i<temp.Length;i++)
					{
						if (temp[i].ToString() == e.Item.Cells[1].Text.Trim())
						{
							cek.Checked=true;		
						}		
					}
				}			

			}
		}
	}
}
