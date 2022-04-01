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

namespace SME.Facilities
{
	/// <summary>
	/// Summary description for Messages.
	/// </summary>
	public partial class Messages : System.Web.UI.Page
	{
		protected Connection conn;
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			conn = (Connection) Session["Connection"];

			if (!IsPostBack)
			{
				ViewSentMsg();
				ViewRecvMsg();
			}
		}

		private void ViewSentMsg()
		{
			conn.QueryString = "SELECT * FROM VW_MESSAGES_VIEWSENTMSG WHERE MSG_SENDBY = '" + Session["UserID"].ToString() + "' ORDER BY MSG_SENDDATE";
			conn.ExecuteQuery();
			
			DataTable dt = new DataTable();
			dt = conn.GetDataTable().Copy();
			DG_SENTMSG.DataSource = dt;
			try 
			{
				DG_SENTMSG.DataBind();
			} 
			catch 
			{
				DG_SENTMSG.CurrentPageIndex = 0;
				DG_SENTMSG.DataBind();
			}

			for (int i = 0; i < DG_SENTMSG.Items.Count; i++)
			{
				DG_SENTMSG.Items[i].Cells[1].Text = (i+1).ToString(); 
			}
		}

		private void ViewRecvMsg()
		{
			conn.QueryString = "SELECT * FROM VW_MESSAGES_VIEWRECVMSG WHERE MSG_RECVBY = '" + Session["UserID"].ToString() + "' ORDER BY MSG_SENDDATE";
			conn.ExecuteQuery();
			
			DataTable dt = new DataTable();
			dt = conn.GetDataTable().Copy();
			DG_RECVMSG.DataSource = dt;
			try 
			{
				DG_RECVMSG.DataBind();
			} 
			catch 
			{
				DG_RECVMSG.CurrentPageIndex = 0;
				DG_RECVMSG.DataBind();
			}

			for (int i = 0; i < DG_RECVMSG.Items.Count; i++)
			{
				DG_RECVMSG.Items[i].Cells[1].Text = (i+1).ToString(); 
			}
		}

		private void ClearEntry()
		{
			TXT_MSGTO.Text = "";
			TXT_TEMPMSGTO.Text = "";
			TXT_MSGTEXT.Text = "";
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
			this.DG_SENTMSG.ItemCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.DG_SENTMSG_ItemCommand);
			this.DG_SENTMSG.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.DG_SENTMSG_PageIndexChanged);
			this.DG_RECVMSG.ItemCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.DG_RECVMSG_ItemCommand);
			this.DG_RECVMSG.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.DG_RECVMSG_PageIndexChanged);

		}
		#endregion

		protected void TXT_TEMPMSGTO_TextChanged(object sender, System.EventArgs e)
		{
			if(this.TXT_TEMPMSGTO.Text != "")
			{
				try
				{
					conn.QueryString = "SELECT USERNAME FROM VW_MESSAGES_USERTO WHERE USERID = '" + TXT_TEMPMSGTO.Text + "'";
					conn.ExecuteQuery();

					TXT_MSGTO.Text = conn.GetFieldValue("USERNAME");
				}
				catch (Exception ex)
				{
					Response.Write("<!--" + ex.ToString() + "-->");
				}
			}
		}

		protected void BTN_SAVE_Click(object sender, System.EventArgs e)
		{
			try
			{
				conn.QueryString  = "EXEC MESSAGES_SEND '" + 
					TXT_TEMPMSGTO.Text + "', '" + 
					TXT_MSGTEXT.Text + "', '" +
					Session["UserID"].ToString() + "'";
				conn.ExecuteNonQuery();

				ViewSentMsg();
				ClearEntry();
			}
			catch (Exception ex)
			{
				string errmsg = ex.Message.Replace("'","");
				if (errmsg.IndexOf("Last Query:") > 0)
					errmsg = errmsg.Substring(0, errmsg.IndexOf("Last Query:"));
				GlobalTools.popMessage(this, errmsg);
				return;
			}
		}

		private void DG_SENTMSG_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			DG_SENTMSG.CurrentPageIndex = e.NewPageIndex;
			ViewSentMsg();
		}

		private void DG_SENTMSG_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			switch (((LinkButton)e.CommandSource).CommandName)
			{
				case "Delete":
					try
					{
						conn.QueryString  = "EXEC MESSAGES_DELETE '" + 
							e.Item.Cells[0].Text + "', '" + 
							Session["UserID"].ToString() + "'";
						conn.ExecuteNonQuery();

						ViewSentMsg();
					}
					catch (Exception ex)
					{
						string errmsg = ex.Message.Replace("'","");
						if (errmsg.IndexOf("Last Query:") > 0)
							errmsg = errmsg.Substring(0, errmsg.IndexOf("Last Query:"));
						GlobalTools.popMessage(this, errmsg);
						return;
					}
					break;					
			}
		}

		private void DG_RECVMSG_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			switch (((LinkButton)e.CommandSource).CommandName)
			{
				case "Accept":
					try
					{
						conn.QueryString  = "EXEC MESSAGES_ACCEPT '" + 
							e.Item.Cells[0].Text + "', '" + 
							Session["UserID"].ToString() + "'";
						conn.ExecuteNonQuery();

						ViewRecvMsg();
					}
					catch (Exception ex)
					{
						string errmsg = ex.Message.Replace("'","");
						if (errmsg.IndexOf("Last Query:") > 0)
							errmsg = errmsg.Substring(0, errmsg.IndexOf("Last Query:"));
						GlobalTools.popMessage(this, errmsg);
						return;
					}
					break;
			}
		}

		private void DG_RECVMSG_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			DG_RECVMSG.CurrentPageIndex = e.NewPageIndex;
			ViewRecvMsg();
		}
	}
}
