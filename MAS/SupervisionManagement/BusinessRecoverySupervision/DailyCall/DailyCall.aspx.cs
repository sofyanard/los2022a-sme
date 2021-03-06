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

namespace SME.MAS.SupervisionManagement.BusinessRecoverySupervision.DailyCall
{
	/// <summary>
	/// Summary description for DailyCall.
	/// </summary>
	public partial class DailyCall : System.Web.UI.Page
	{
		protected Connection conn = new Connection(ConfigurationSettings.AppSettings["conn"]);
		protected Tools tool = new Tools();
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			if(!IsPostBack)
			{
				DDL_UNIT.Items.Add(new ListItem("--Pilih--",""));
				conn.QueryString = "select * from rfbranch where active='1' order by branch_name";
				conn.ExecuteQuery();
				for (int i = 0; i < conn.GetRowCount(); i++)
					DDL_UNIT.Items.Add(new ListItem(conn.GetFieldValue(i,1),conn.GetFieldValue(i,0)));
			}
			ViewData();
		}

		private void ViewData()
		{
			conn.QueryString = "select * from mas_daily_call where pic_input='"+ Session["UserID"].ToString() +"' ";
			conn.ExecuteQuery();
			FillGrid();
		}

		private void FillGrid()
		{
			DataTable dt = new DataTable();
			dt = conn.GetDataTable().Copy();
			DatGrd.DataSource = dt;
			try 
			{
				DatGrd.DataBind();
			} 
			catch 
			{
				DatGrd.CurrentPageIndex = 0;
				DatGrd.DataBind();
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

		protected void BTN_CLEAR_Click(object sender, System.EventArgs e)
		{
			ClearData();
		}

		private void ClearData()
		{
			TXT_NAME.Text = "";
			DDL_UNIT.SelectedValue = "";
			TXT_NO_TELP.Text = "";
			TXT_ASK1.Text = "";
			TXT_ASK2.Text = "";
			TXT_ASK3.Text = "";
			TXT_ASK4.Text = "";
			TXT_ASK5.Text = "";
			TXT_ASK6.Text = "";
			TXT_ASK7.Text = "";
			TXT_ASK8.Text = "";
			TXT_JWB1.Text = "";
			TXT_JWB2.Text = "";
			TXT_JWB3.Text = "";
			TXT_JWB4.Text = "";
			TXT_JWB5.Text = "";
			TXT_JWB6.Text = "";
			TXT_JWB7.Text = "";
			TXT_JWB8.Text = "";
			TXT_SEQ.Text = "";
		}

		private void DatGrd_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			switch (((LinkButton)e.CommandSource).CommandName)
			{
				case "delete_data":
					conn.QueryString = "delete from mas_daily_call where seq=" + Convert.ToInt32(e.Item.Cells[0].Text) + "";
					conn.ExecuteQuery();					
					ClearData();					
					ViewData();
					break;

				case "edit_data":					
					conn.QueryString = "select * from mas_daily_call where seq=" + Convert.ToInt32(e.Item.Cells[0].Text) + "";
					conn.ExecuteQuery();
					TXT_SEQ.Text = conn.GetFieldValue("SEQ");					
					TXT_NAME.Text = conn.GetFieldValue("nama");
					try{DDL_UNIT.SelectedValue = conn.GetFieldValue("unit_code");}
					catch{DDL_UNIT.SelectedValue = "";}
					TXT_NO_TELP.Text = conn.GetFieldValue("phone#");
					TXT_ASK1.Text = conn.GetFieldValue("ask1");
					TXT_ASK2.Text = conn.GetFieldValue("ask2");
					TXT_ASK3.Text = conn.GetFieldValue("ask3");
					TXT_ASK4.Text = conn.GetFieldValue("ask4");
					TXT_ASK5.Text = conn.GetFieldValue("ask5");
					TXT_ASK6.Text = conn.GetFieldValue("ask6");
					TXT_ASK7.Text = conn.GetFieldValue("ask7");
					TXT_ASK8.Text = conn.GetFieldValue("ask8");
					TXT_JWB1.Text = conn.GetFieldValue("answer1");
					TXT_JWB2.Text = conn.GetFieldValue("answer2");
					TXT_JWB3.Text = conn.GetFieldValue("answer3");
					TXT_JWB4.Text = conn.GetFieldValue("answer4");
					TXT_JWB5.Text = conn.GetFieldValue("answer5");
					TXT_JWB6.Text = conn.GetFieldValue("answer6");
					TXT_JWB7.Text = conn.GetFieldValue("answer7");
					TXT_JWB8.Text = conn.GetFieldValue("answer8");
					break;
			}
		}

		private void DatGrd_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			DatGrd.CurrentPageIndex = e.NewPageIndex;
			ViewData();
		}

		protected void BTN_INSERT_Click(object sender, System.EventArgs e)
		{
			if (TXT_SEQ.Text == "")
			{
				conn.QueryString = " exec MAS_DAILY_CALL_INSERT '" + 					
					TXT_NAME.Text + "', '" +
					DDL_UNIT.SelectedValue + "', '" +
					TXT_NO_TELP.Text + "', '" +					
					TXT_ASK1.Text + "', '" +
					TXT_ASK2.Text + "', '" +
					TXT_ASK3.Text + "', '" +
					TXT_ASK4.Text + "', '" +
					TXT_ASK5.Text + "', '" +
					TXT_ASK6.Text + "', '" +
					TXT_ASK7.Text + "', '" +
					TXT_ASK8.Text + "', '" +					
					TXT_JWB1.Text + "', '" +
					TXT_JWB2.Text + "', '" +
					TXT_JWB3.Text + "', '" +
					TXT_JWB4.Text + "', '" +
					TXT_JWB5.Text + "', '" +
					TXT_JWB6.Text + "', '" +
					TXT_JWB7.Text + "', '" +
					TXT_JWB8.Text + "', '" +
					Session["UserID"].ToString() +"' " ;
				conn.ExecuteQuery();				
			}
			else
			{
				conn.QueryString = " exec MAS_DAILY_CALL_UPDATE " + 
					Convert.ToInt32(TXT_SEQ.Text) + ", '" +						
					TXT_NAME.Text + "', '" +
					DDL_UNIT.SelectedValue + "', '" +
					TXT_NO_TELP.Text + "', '" +						
					TXT_ASK1.Text + "', '" +
					TXT_ASK2.Text + "', '" +
					TXT_ASK3.Text + "', '" +
					TXT_ASK4.Text + "', '" +
					TXT_ASK5.Text + "', '" +
					TXT_ASK6.Text + "', '" +
					TXT_ASK7.Text + "', '" +
					TXT_ASK8.Text + "', '" +					
					TXT_JWB1.Text + "', '" +
					TXT_JWB2.Text + "', '" +
					TXT_JWB3.Text + "', '" +
					TXT_JWB4.Text + "', '" +
					TXT_JWB5.Text + "', '" +
					TXT_JWB6.Text + "', '" +
					TXT_JWB7.Text + "', '" +
					TXT_JWB8.Text + "', '" +
					Session["UserID"].ToString() +"' " ;
				conn.ExecuteQuery();
			}
			ClearData();
			ViewData();
		}
	}
}
