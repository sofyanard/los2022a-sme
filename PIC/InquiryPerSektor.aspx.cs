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
using System.IO;
using System.Diagnostics;

namespace SME.PIC
{
	/// <summary>
	/// Summary description for InquiryPerSektor.
	/// </summary>
	public partial class InquiryPerSektor : System.Web.UI.Page
	{
		protected Connection conn;
		protected Tools tool;
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			conn = (Connection) Session["Connection"];
			tool = new Tools();

			if (!Logic.AllowAccess(Session["GroupID"].ToString(), Request.QueryString["mc"], conn))
				Response.Redirect("/SME/Restricted.aspx");		
			
			if (!IsPostBack)
			{
				DDL_KSEBM.Items.Add(new ListItem("--Pilih--"));

				conn.QueryString = "select BMSUBSUB_CODE, BMSUBSUB_DESC from RFBMSUBSUBSEKTOREKONOMI where ACTIVE='1' order by BMSUBSUB_CODE";
				conn.ExecuteQuery();
				for (int i = 0; i < conn.GetRowCount(); i++)
					DDL_KSEBM.Items.Add(new ListItem(conn.GetFieldValue(i,0)  + " - " + conn.GetFieldValue(i,1), conn.GetFieldValue(i,0)));
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
			this.DATA_EXPORT.ItemCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.DATA_EXPORT_ItemCommand);

		}
		#endregion

		private void ViewUploadFiles()
		{
			string url = "";
			conn.QueryString = "SELECT EXPORT_URL FROM PIC_RFEXPORT WHERE EXPORT_ID = '" + "PIC" + "'";
			conn.ExecuteQuery();

			if (conn.GetRowCount() > 0) 
			{
				url = conn.GetFieldValue("EXPORT_URL");
			}

			System.Data.DataTable dt = new System.Data.DataTable();
			conn.QueryString = "EXEC PIC_FILE_UPLOAD_VIEW_ALL '" +DDL_KSEBM.SelectedValue+ "'";
			conn.ExecuteQuery();
			dt = conn.GetDataTable().Copy();
			DATA_EXPORT.DataSource = dt;
			try 
			{
				DATA_EXPORT.DataBind();
			} 
			catch 
			{
				DATA_EXPORT.CurrentPageIndex = 0;
				DATA_EXPORT.DataBind();
			}
			//for (int i = 1; i <= DATA_EXPORT.Items.Count; i++)
			//{
				//HyperLink HpDownload = (HyperLink) DATA_EXPORT.Items[i-1].Cells[3].FindControl("DOWNLOAD");
				//HpDownload.Click += new EventHandler(HpDownload_Click);
				//string a = url;
				//string b = conn.GetFieldValue("FILE_UPLOAD_NAME");
				//HpDownload.NavigateUrl = url + conn.GetFieldValue(i-1, "FILE_UPLOAD_NAME");
				//HpDownload.
				//HpDownload.Target = "blank";

				//conn.QueryString = "EXEC PIC_USER_VISIT_INSERT '"+ Session[BranchID].ToString +"','"+ Session[UserID].ToString +"','"+ e.Item.Cells[2].Text.ToString()+"','Download'";
				//conn.ExecuteQuery();
			//}
		}

		protected void RETRIEVE_Click(object sender, System.EventArgs e)
		{
			ViewUploadFiles();
		
		}

		private void DATA_EXPORT_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			string a = "";
			string filetype = "";
			
			string url2 = "";
			conn.QueryString = "SELECT EXPORT_URL FROM PIC_RFEXPORT WHERE EXPORT_ID = '" + "PIC" + "'";
			conn.ExecuteQuery();

			if (conn.GetRowCount() > 0) 
			{
				url2 = conn.GetFieldValue("EXPORT_URL");
			}

			a = e.Item.Cells[2].Text.ToString();
			filetype = a.Substring(a.Length-4, 3);
			url2 = url2 + e.Item.Cells[2].Text.ToString();

			switch (((LinkButton)e.CommandSource).CommandName)
			{
				case "View":
					try
					{
						conn.QueryString = "EXEC PIC_USER_VISIT_INSERT '"+ Session["BranchID"].ToString() +"','"+ Session["UserID"].ToString() +"','"+ e.Item.Cells[1].Text.ToString()+"','View'";
						conn.ExecuteQuery();
						Response.Write("<script for=window event=onload language='javascript'>PopupPage('PopUp.aspx?filetype=" + filetype + "&url=" + url2 + "&theForm=Form1&theObj=TXT_TEMP', '0','0');</script>");
					}
					catch(Exception risan)
					{
						string asas = risan.Message.ToString();
						string ddf = "";
					}
					break;
				case "Download":
					
					if(filetype == "jpg" || filetype == "bmp")
					{
						conn.QueryString = "EXEC PIC_USER_VISIT_INSERT '"+ Session["BranchID"].ToString() +"','"+ Session["UserID"].ToString() +"','"+ e.Item.Cells[1].Text.ToString()+"','Download'";
						conn.ExecuteQuery();
						Response.Write("<script for=window event=onload language='javascript'>PopupPage('PopUp.aspx?filetype=" + filetype + "&url=" + url2 + "&theForm=Form1&theObj=TXT_TEMP', '0','0');</script>");
					}
					else
					{
						conn.QueryString = "EXEC PIC_USER_VISIT_INSERT '"+ Session["BranchID"].ToString() +"','"+ Session["UserID"].ToString() +"','"+ e.Item.Cells[1].Text.ToString()+"','Download'";
						conn.ExecuteQuery();
						Response.Redirect(url2); 
					}
					break;
			}
		}

	}
}
