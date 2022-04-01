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
	/// Summary description for Kota (City)
	/// </summary>
	public partial class RFCityParam : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.PlaceHolder Menu;
		protected System.Web.UI.WebControls.Button updatestatus;
		protected Tools tool = new Tools();
		protected Connection conn;
		//protected Connection conn = new Connection("Data Source=10.123.12.30;Initial Catalog=SMEDEV;uid=sa;pwd=");
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			conn = (Connection) Session["Connection"];

			if (!Logic.AllowAccess(Session["GroupID"].ToString(), Request.QueryString["mc"], conn))
				Response.Redirect("/SME/Restricted.aspx");

			if (!IsPostBack) 
			{
				LBL_SAVEMODE.Text = "1";
				LBL_ACTIVE.Text = Request.QueryString["active"];
				if (LBL_ACTIVE.Text.Trim() != "0")
					LBL_ACTIVE.Text = "1";	//default condition

				viewExistingData(DDL_COLTYPEID.SelectedValue);
				viewPendingData(DDL_COLTYPEID.SelectedValue);
				setDescription();
				fillDDLCollType();
			}

			BTN_SAVE.Attributes.Add("onclick","if(!cek_mandatory(document.Form1)){return false;}");			
			DGExisting.PageIndexChanged +=new DataGridPageChangedEventHandler(DGExisting_PageIndexChanged);
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
			this.DGExisting.ItemCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.DGExisting_ItemCommand);
			this.DGRequest.ItemCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.DGRequest_ItemCommand);
			this.DGRequest.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.DGRequest_PageIndexChanged);

		}
		#endregion

		private void fillDDLCollType() 
		{
			conn.QueryString = "select * from VW_RFAREA";
			conn.ExecuteQuery();

			DDL_COLTYPEID.Items.Add(new ListItem("- PILIH -",""));
			for(int i=0; i<conn.GetRowCount(); i++) 
			{
				DDL_COLTYPEID.Items.Add(new ListItem(conn.GetFieldValue(i, "AREANAME"), conn.GetFieldValue(i, "AREAID")));
			}
		}

		private void setDescription() 
		{
			switch (Request.QueryString["tablename"]) 
			{
				case "RFTBODOC":
					TXT_DESC.TextMode = TextBoxMode.MultiLine;
					break;				
				default:
					TXT_DESC.TextMode = TextBoxMode.SingleLine;
					break;
			}
		}

		private void viewPendingData(string AREAID) 
		{
			string pendCol = "";

			conn.QueryString = "select * from VW_PARAM_GENERAL_PENDING_RFCITY where AREAID = '"+ AREAID +"'";
			conn.ExecuteQuery();

			DataTable dt = new DataTable();			
			dt.Columns.Add(new DataColumn("ID"));
			dt.Columns.Add(new DataColumn("DESC"));
			dt.Columns.Add(new DataColumn("AREAID"));
			dt.Columns.Add(new DataColumn("AREANAME"));
			dt.Columns.Add(new DataColumn("PENDINGSTATUS"));
			dt.Columns.Add(new DataColumn("PENDING_STATUS"));			

			if (LBL_ACTIVE.Text.Trim() == "1")
				pendCol = "PENDINGSTATUS";
			DataRow dr;
			for(int i = 0; i < conn.GetDataTable().Rows.Count; i++) 
			{
				dr = dt.NewRow();
				dr[0] = conn.GetFieldValue(i, "CITYID");
				dr[1] = conn.GetFieldValue(i, "CITYNAME");
				dr[2] = conn.GetFieldValue(i, "AREAID");
				dr[3] = conn.GetFieldValue(i, "AREANAME");
				dr[4] = conn.GetFieldValue(i,pendCol);
				dr[5] = getPendingStatus(conn.GetFieldValue(i,pendCol));
				dt.Rows.Add(dr);
			}			

			DGRequest.DataSource = new DataView(dt);
			try 
			{
				DGRequest.DataBind();
			}
			catch {
				DGRequest.CurrentPageIndex = DGRequest.PageCount - 1;
				DGRequest.DataBind();
			}
		}

		private string getPendingStatus(string saveMode) 
		{
			string status = "";			
			switch (saveMode)
			{
				case "0":
					status = "Update";
					break;
				case "1":
					status = "Insert";
					break;
				case "2":
					status = "Delete";
					break;
				default:
					status = "";
					break;
			}
			return status;
		}

		private void viewExistingData(string AREAID) 
		{
			if (LBL_ACTIVE.Text.Trim() == "1")
				conn.QueryString = "select * from VW_PARAM_GENERAL_RFCITY where ACTIVE = '1' and AREAID = '"+ AREAID +"'";
			else
				conn.QueryString = "select * from VW_PARAM_GENERAL_RFCITY where AREAID = '"+ AREAID +"'";
			conn.ExecuteQuery();

			DataTable dt = new DataTable();			
			dt.Columns.Add(new DataColumn("ID"));
			dt.Columns.Add(new DataColumn("DESC"));
			dt.Columns.Add(new DataColumn("AREAID"));
			dt.Columns.Add(new DataColumn("AREANAME"));

			DataRow dr;
			for(int i = 0; i < conn.GetDataTable().Rows.Count; i++) 
			{
				dr = dt.NewRow();
				dr[0] = conn.GetFieldValue(i, "CITYID");
				dr[1] = conn.GetFieldValue(i, "CITYNAME");
				dr[2] = conn.GetFieldValue(i, "AREAID");
				dr[3] = conn.GetFieldValue(i, "AREANAME");
				dt.Rows.Add(dr);
			}			

			DGExisting.DataSource = new DataView(dt);
			try 
			{
				DGExisting.DataBind();
			} 
			catch 
			{
				DGExisting.CurrentPageIndex = DGExisting.PageCount - 1;
				DGExisting.DataBind();
			}
		}

		private void DGExisting_PageIndexChanged(object source, DataGridPageChangedEventArgs e)
		{			
			DGExisting.CurrentPageIndex = e.NewPageIndex;
			viewExistingData(DDL_COLTYPEID.SelectedValue);
		} 

		

		protected void BTN_SAVE_Click(object sender, System.EventArgs e)
		{
			if (TXT_ID.Text.Trim() == "" || TXT_DESC.Text.Trim() == "") return;

			if (LBL_SAVEMODE.Text.Trim() == "1") //--- Status INSERT
			{
				conn.QueryString = "select * from RFCITY WHERE CITYID ='" + TXT_ID.Text.Trim() + "'";
				conn.ExecuteQuery();
				
				if (conn.GetRowCount() > 0) 
				{
					Tools.popMessage(this, "ID has already been used! Request canceled!");
					return;
				}

			}	
	
			executeMaker(TXT_ID.Text.Trim(), TXT_DESC.Text.Trim(), DDL_COLTYPEID.SelectedValue, LBL_SAVEMODE.Text.Trim());
			viewPendingData(DDL_COLTYPEID.SelectedValue);
			clearControls();

			LBL_SAVEMODE.Text = "1";
		}

		private void clearControls() 
		{
			TXT_ID.Text   = "";
			TXT_DESC.Text = "";
			activateControlKey(false);
		}

		private void activateControlKey(bool isReadOnly) 
		{
			TXT_ID.ReadOnly = isReadOnly;
			DDL_COLTYPEID.Enabled = !isReadOnly;
		}

		private void DGRequest_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{			
			clearControls();
			switch(((LinkButton)e.CommandSource).CommandName.ToLower())
			{
				case "edit":
					LBL_SAVEMODE.Text = e.Item.Cells[4].Text;
					if (LBL_SAVEMODE.Text.Trim() == "2") 
					{
						// kalau ingin EDIT, yang status_pendingnya DELETE, ignore ....
						LBL_SAVEMODE.Text = "1";
						break;
					}
					TXT_ID.Text = e.Item.Cells[0].Text;
					TXT_DESC.Text = e.Item.Cells[1].Text;
					DDL_COLTYPEID.SelectedValue = e.Item.Cells[2].Text;
					activateControlKey(true);
					break;

				case "delete":
					string id = e.Item.Cells[0].Text;
					conn.QueryString = "delete from PENDING_RFCITY WHERE CITYID ='" + id + "'";
					conn.ExecuteQuery();
					viewPendingData(DDL_COLTYPEID.SelectedValue);
					break;

				default :
					break;
			}
		}

        private string getColumnDesc()
		{
			return LBL_DESC.Text.Trim();
		}

		private void DGExisting_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			clearControls();
			switch(((LinkButton)e.CommandSource).CommandName.ToLower())
			{
				case "edit":
					LBL_SAVEMODE.Text = "0";
					TXT_ID.Text = e.Item.Cells[0].Text;
					TXT_DESC.Text = e.Item.Cells[1].Text;
					DDL_COLTYPEID.SelectedValue = e.Item.Cells[2].Text;
					activateControlKey(true);
					break;

				case "delete":					
					string id = e.Item.Cells[0].Text.Trim();
					string coltypeid = e.Item.Cells[2].Text;
					executeMaker(id, e.Item.Cells[1].Text, coltypeid, "2");
					viewPendingData(DDL_COLTYPEID.SelectedValue);
					break;

				default :
					break;
			}
		}

		private void DGRequest_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			DGRequest.CurrentPageIndex = e.NewPageIndex;
			viewPendingData(DDL_COLTYPEID.SelectedValue);
		}

		private void executeMaker(string id, string desc, string coltypeid, string pendingStatus) 
		{
			conn.QueryString = "exec PARAM_GENERAL_RFCITY_MAKER '" + pendingStatus + 
								"','" + id + 
								"','" + desc + 
								"','" + coltypeid + "'";
			try 
			{
				conn.ExecuteNonQuery();
			} 
			catch {
				Tools.popMessage(this, "Input tidak valid !");
				return;
			}

			viewPendingData(DDL_COLTYPEID.SelectedValue);
			clearControls();

			LBL_SAVEMODE.Text = "1";
		}

		protected void BTN_BACK_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			Response.Redirect("/SME/Maintenance/Parameters/GeneralParam.aspx?mc="+Request.QueryString["mc"]);
		}

		protected void BTN_CANCEL_Click(object sender, System.EventArgs e)
		{
			clearControls();
		}

		protected void DDL_COLTYPEID_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			viewExistingData(DDL_COLTYPEID.SelectedValue);
			viewPendingData(DDL_COLTYPEID.SelectedValue);
		}
	}		
}
