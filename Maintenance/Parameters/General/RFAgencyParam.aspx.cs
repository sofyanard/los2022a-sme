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

namespace SME.InitialDataEntry
{
	/// <summary>
	/// Summary description for GeneralInfo.
	/// </summary>
	public partial class RFAgencyParam : System.Web.UI.Page
	{
		//protected Connection conn = new Connection("Data Source=10.123.12.30;Initial Catalog=SMEDEV;uid=sa;pwd=");
		protected Connection conn;
		protected Tools tool = new Tools();
		protected Deduplication dedup = new Deduplication();
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			conn = (Connection) Session["Connection"];

			if (!IsPostBack)
			{
				fillAgencyType();
				fillCity();

				viewExisting();
				viewRequest();
			}

			BTN_SAVE.Attributes.Add("onclick", "if(!cek_mandatory(document.Form1)) { return false; };");
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
			this.DGR_AGENCY_EXIST.ItemCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.DGR_AGENCY_EXIST_ItemCommand);
			this.DGR_AGENCY_EXIST.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.DGR_AGENCY_EXIST_PageIndexChanged);
			this.DGR_AGENCY_REQ.ItemCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.DGR_AGENCY_REQ_ItemCommand);
			this.DGR_AGENCY_REQ.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.DGR_AGENCY_REQ_PageIndexChanged);

		}
		#endregion

		private void fillAgencyType() 
		{
			conn.QueryString = "select * from RFAGENCYTYPE"; // where ACTIVE = '1'";
			conn.ExecuteQuery();

			DDL_AGENCYTYPE.Items.Add(new ListItem("- PILIH -",""));
			for(int i=0; i<conn.GetRowCount(); i++) 
			{
				DDL_AGENCYTYPE.Items.Add(new ListItem(conn.GetFieldValue(i,1), conn.GetFieldValue(i,0)));
			}
		}

		private void fillCity() 
		{
			conn.QueryString = "select * from RFCITY where ACTIVE = '1'";
			conn.ExecuteQuery();

			DDL_CITY.Items.Add(new ListItem("- PILIH -",""));
			for(int i=0; i<conn.GetRowCount(); i++) 
			{
				DDL_CITY.Items.Add(new ListItem(conn.GetFieldValue(i,2), conn.GetFieldValue(i,1)));
			}
		}

		private void viewExisting() 
		{
			conn.QueryString = "select * from VW_PARAM_RFAGENCY";
			conn.ExecuteQuery();

			DataTable dt = new DataTable();			
			dt.Columns.Add(new DataColumn("AGENCYID"));
			dt.Columns.Add(new DataColumn("AGENCYNAME"));
			dt.Columns.Add(new DataColumn("AGENCY_ADDR"));
			dt.Columns.Add(new DataColumn("AGENCY_CITY"));
			dt.Columns.Add(new DataColumn("AGENCY_ZIPCODE"));
			dt.Columns.Add(new DataColumn("AGENCY_PHN"));
			dt.Columns.Add(new DataColumn("AGENCY_FAX"));
			dt.Columns.Add(new DataColumn("AGENCY_EMAIL"));
			dt.Columns.Add(new DataColumn("AGENCYTYPEID"));
			dt.Columns.Add(new DataColumn("AGENCYTYPEDESC"));
			dt.Columns.Add(new DataColumn("CITYID"));
			dt.Columns.Add(new DataColumn("CITYNAME"));

			DataRow dr;
			for(int i = 0; i < conn.GetDataTable().Rows.Count; i++) 
			{
				dr = dt.NewRow();
				dr[0] = conn.GetFieldValue(i,"AGENCYID");
				dr[1] = conn.GetFieldValue(i,"AGENCYNAME");
				dr[2] = conn.GetFieldValue(i,"AGENCY_ADDR");
				dr[3] = conn.GetFieldValue(i,"AGENCY_CITY");
				dr[4] = conn.GetFieldValue(i,"AGENCY_ZIPCODE");
				dr[5] = conn.GetFieldValue(i,"AGENCY_PHN");
				dr[6] = conn.GetFieldValue(i,"AGENCY_FAX");
				dr[7] = conn.GetFieldValue(i,"AGENCY_EMAIL");
				dr[8] = conn.GetFieldValue(i,"AGENCYTYPEID");
				dr[9] = conn.GetFieldValue(i,"AGENCYTYPEDESC");
				dr[10] = conn.GetFieldValue(i,"CITYID");
				dr[11] = conn.GetFieldValue(i,"CITYNAME");

				dt.Rows.Add(dr);
			}			

			DGR_AGENCY_EXIST.DataSource = new DataView(dt);
			try 
			{
				DGR_AGENCY_EXIST.DataBind();
			} 
			catch 
			{
				DGR_AGENCY_EXIST.CurrentPageIndex = DGR_AGENCY_EXIST.PageCount - 1;
				DGR_AGENCY_EXIST.DataBind();
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

		private void viewRequest() 
		{
			conn.QueryString = "select * from VW_PARAM_PENDING_RFAGENCY";
			conn.ExecuteQuery();

			DataTable dt = new DataTable();			
			dt.Columns.Add(new DataColumn("AGENCYID"));
			dt.Columns.Add(new DataColumn("AGENCYNAME"));
			dt.Columns.Add(new DataColumn("AGENCY_ADDR"));
			dt.Columns.Add(new DataColumn("AGENCY_CITY"));
			dt.Columns.Add(new DataColumn("AGENCY_ZIPCODE"));
			dt.Columns.Add(new DataColumn("AGENCY_PHN"));
			dt.Columns.Add(new DataColumn("AGENCY_FAX"));
			dt.Columns.Add(new DataColumn("AGENCY_EMAIL"));
			dt.Columns.Add(new DataColumn("AGENCYTYPEID"));
			dt.Columns.Add(new DataColumn("AGENCYTYPEDESC"));
			dt.Columns.Add(new DataColumn("CITYID"));
			dt.Columns.Add(new DataColumn("CITYNAME"));
			dt.Columns.Add(new DataColumn("PENDINGSTATUS"));
			dt.Columns.Add(new DataColumn("PENDING_STATUS"));


			DataRow dr;
			for(int i = 0; i < conn.GetDataTable().Rows.Count; i++) 
			{
				dr = dt.NewRow();
				dr[0] = conn.GetFieldValue(i,"AGENCYID");
				dr[1] = conn.GetFieldValue(i,"AGENCYNAME");
				dr[2] = conn.GetFieldValue(i,"AGENCY_ADDR");
				dr[3] = conn.GetFieldValue(i,"AGENCY_CITY");
				dr[4] = conn.GetFieldValue(i,"AGENCY_ZIPCODE");
				dr[5] = conn.GetFieldValue(i,"AGENCY_PHN");
				dr[6] = conn.GetFieldValue(i,"AGENCY_FAX");
				dr[7] = conn.GetFieldValue(i,"AGENCY_EMAIL");				
				dr[8] = conn.GetFieldValue(i,"AGENCYTYPEID");
				dr[9] = conn.GetFieldValue(i,"AGENCYTYPEDESC");
				dr[10] = conn.GetFieldValue(i,"CITYID");
				dr[11] = conn.GetFieldValue(i,"CITYNAME");
				dr[12] = conn.GetFieldValue(i,"PENDINGSTATUS");
				dr[13] = getPendingStatus(conn.GetFieldValue(i,"PENDINGSTATUS").ToString());

				dt.Rows.Add(dr);
			}			

			DGR_AGENCY_REQ.DataSource = new DataView(dt);
			try 
			{
				DGR_AGENCY_REQ.DataBind();
			} 
			catch 
			{
				DGR_AGENCY_REQ.CurrentPageIndex = DGR_AGENCY_REQ.PageCount - 1;
				DGR_AGENCY_REQ.DataBind();
			}
		}

		private void DGR_AGENCY_EXIST_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			DGR_AGENCY_EXIST.CurrentPageIndex = e.NewPageIndex;
			viewExisting();
		}

		private void DGR_AGENCY_REQ_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			DGR_AGENCY_REQ.CurrentPageIndex = e.NewPageIndex;
			viewRequest();
		}

		protected void BTN_SEARCHCOMP_Click(object sender, System.EventArgs e)
		{
			Response.Write("<script language='javascript'>window.open('../../../InitialDataEntry/SearchZipcode.aspx?targetFormID=Form1&targetObjectID=TXT_AGENCY_ZIPCODE','SearchZipcode','status=no,scrollbars=no,width=420,height=200');</script>");
			//Response.Write("<script language='javascript'>window.open('SearchZipcode2.aspx?targetFormID=Form1&targetObjectID=TXT_AGENCY_ZIPCODE','SearchZipcode','status=no,scrollbars=no,width=420,height=200');</script>");
		}

		protected void BTN_SAVE_Click(object sender, System.EventArgs e)
		{
			if (LBL_SAVEMODE.Text.Trim() == "1") 
			{
				conn.QueryString = "select * from RFAGENCY where AGENCYID='" + TXT_AGENCY_ID.Text.Trim() + "' order by agencyname";
				conn.ExecuteQuery();
				
				if (conn.GetRowCount() > 0) 
				{
					Tools.popMessage(this, "ID has already been used! Request canceled!");
					return;
				}
			}				

			conn.QueryString = "exec PARAM_GENERAL_RFAGENCY_MAKER '" + LBL_SAVEMODE.Text + 
									"', '" + DDL_CITY.SelectedValue +
									"', '" + TXT_AGENCY_ID.Text + 
									"', '" + DDL_AGENCYTYPE.SelectedValue +
									"', '" + TXT_AGENCY_NAME.Text + 
									"', '" + TXT_AGENCY_ADDR1.Text + 
									"', '" + TXT_AGENCY_ADDR2.Text + 
									"', '" + TXT_AGENCY_ADDR3.Text + 
									"', '" + TXT_AGENCY_EMAIL.Text + 
									"', '" + TXT_AGENCY_PHNAREA.Text + 
									"', '" + TXT_AGENCY_PHNNUM.Text + 
									"', '" + TXT_AGENCY_PHNEXT.Text + 
									"', '" + TXT_AGENCY_FAXAREA.Text + 
									"', '" + TXT_AGENCY_FAXNUM.Text + 
									"', '" + TXT_AGENCY_FAXEXT.Text+ 
									"', '" + TXT_AGENCY_ZIPCODE.Text + "'";
			try 
			{
				conn.ExecuteNonQuery();
			}
			catch 
			{
				Tools.popMessage(this, "Input tidak valid !");
				return;
			}

			viewRequest();
			clearControls();

			LBL_SAVEMODE.Text = "1";
		}

		private void clearControls() 
		{
//			LBL_SAVEMODE.Text = "1";

			TXT_AGENCY_ID.Text		= "";
			TXT_AGENCY_NAME.Text	= "";
			TXT_AGENCY_ADDR1.Text	= "";
			TXT_AGENCY_ADDR2.Text	= "";
			TXT_AGENCY_ADDR3.Text	= "";
			TXT_AGENCY_CITY.Text	= "";
			TXT_AGENCY_ZIPCODE.Text = "";
			TXT_AGENCY_PHNAREA.Text = "";
			TXT_AGENCY_PHNNUM.Text	= "";
			TXT_AGENCY_PHNEXT.Text	= "";
			TXT_AGENCY_FAXAREA.Text = "";
			TXT_AGENCY_FAXNUM.Text	= "";
			TXT_AGENCY_FAXEXT.Text	= "";
			TXT_AGENCY_EMAIL.Text	= "";
			DDL_AGENCYTYPE.SelectedValue = "";
			DDL_CITY.SelectedValue = "";
			activateControlKey(false);
		}

		protected void TXT_AGENCY_ZIPCODE_TextChanged(object sender, System.EventArgs e)
		{
			conn.QueryString = "select cityid, cityname, description from vw_zipcodecity where rtrim(ltrim(zipcode)) = '" + 
				TXT_AGENCY_ZIPCODE.Text.Trim() + "' ";
			conn.ExecuteQuery();
			try
			{
				LBL_AGENCY_CITY.Text = conn.GetFieldValue(0,0);
				TXT_AGENCY_CITY.Text = conn.GetFieldValue(0,2);
			}
			catch
			{
				TXT_AGENCY_ZIPCODE.Text = "";
				TXT_AGENCY_CITY.Text = "";
				Response.Write("<script language='javascript'>alert('Invalid Zipcode!');</script>");
			}
		}

		private void activateControlKey(bool isReadOnly) 
		{
			TXT_AGENCY_ID.ReadOnly = isReadOnly;
		}

		private void DGR_AGENCY_REQ_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			clearControls();
			switch(((LinkButton)e.CommandSource).CommandName.ToLower())
			{
				case "edit":
					LBL_SAVEMODE.Text = e.Item.Cells[8].Text;
					if (LBL_SAVEMODE.Text.Trim() == "2") 
					{
						// kalau ingin EDIT, yang status_pendingnya DELETE, ignore ....
						LBL_SAVEMODE.Text = "1";
						break;
					}
					TXT_AGENCY_ID.Text		= e.Item.Cells[0].Text;
					conn.QueryString = "select * from VW_PARAM_PENDING_RFAGENCY_2 where ACTIVE = '1' and AGENCYID = '" + TXT_AGENCY_ID.Text + "'";
					conn.ExecuteQuery();

					DDL_CITY.SelectedValue  = conn.GetFieldValue("CITYID");
					DDL_AGENCYTYPE.SelectedValue = conn.GetFieldValue("AGENCYTYPEID");
					TXT_AGENCY_NAME.Text	= conn.GetFieldValue("agencyname");
					TXT_AGENCY_ADDR1.Text	= conn.GetFieldValue("AGENCY_ADDR1");
					TXT_AGENCY_ADDR2.Text	= conn.GetFieldValue("AGENCY_ADDR2");
					TXT_AGENCY_ADDR3.Text	= conn.GetFieldValue("AGENCY_ADDR3");
					TXT_AGENCY_CITY.Text	= conn.GetFieldValue("ZIPDESC");
					TXT_AGENCY_ZIPCODE.Text = conn.GetFieldValue("AGENCY_ZIPCODE");
					TXT_AGENCY_PHNAREA.Text = conn.GetFieldValue("AGENCY_PHNAREA");
					TXT_AGENCY_PHNNUM.Text	= conn.GetFieldValue("AGENCY_PHNNUM");
					TXT_AGENCY_PHNEXT.Text	= conn.GetFieldValue("AGENCY_PHNEXT");
					TXT_AGENCY_FAXAREA.Text = conn.GetFieldValue("AGENCY_FAXAREA");
					TXT_AGENCY_FAXNUM.Text	= conn.GetFieldValue("AGENCY_FAXNUM");
					TXT_AGENCY_FAXEXT.Text	= conn.GetFieldValue("AGENCY_FAXEXT");
					TXT_AGENCY_EMAIL.Text	= conn.GetFieldValue("AGENCY_EMAIL");
					
					activateControlKey(true);
					break;

				case "delete":
					string id = e.Item.Cells[0].Text;					
				
					conn.QueryString = "delete from PENDING_RFAGENCY WHERE ACTIVE = '1' and AGENCYID = '" + id + "'";
					conn.ExecuteQuery();
					viewRequest();
					break;
				default :
					break;
			}
		}

		private void DGR_AGENCY_EXIST_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			clearControls();
			switch(((LinkButton)e.CommandSource).CommandName.ToLower())
			{
				case "edit":					
					LBL_SAVEMODE.Text = "0";
					TXT_AGENCY_ID.Text = e.Item.Cells[0].Text;
					//conn.QueryString = "select * from RFAGENCY where AGENCYID = '" + TXT_AGENCY_ID.Text + "' order by agencyname";
					//conn.QueryString = "select * from VW_PARAM_RFAGENCY where AGENCYID = '" + TXT_AGENCY_ID.Text + "'";
					conn.QueryString = "select * from VW_PARAM_RFAGENCY_2 where AGENCYID = '" + TXT_AGENCY_ID.Text + "'";
					conn.ExecuteQuery();

					DDL_CITY.SelectedValue			= conn.GetFieldValue("CITYID");
					DDL_AGENCYTYPE.SelectedValue	= conn.GetFieldValue("AGENCYTYPEID");
					TXT_AGENCY_NAME.Text			= conn.GetFieldValue("agencyname");
					TXT_AGENCY_ADDR1.Text			= conn.GetFieldValue("AGENCY_ADDR1");
					TXT_AGENCY_ADDR2.Text			= conn.GetFieldValue("AGENCY_ADDR2");
					TXT_AGENCY_ADDR3.Text			= conn.GetFieldValue("AGENCY_ADDR3");
					TXT_AGENCY_ZIPCODE.Text			= conn.GetFieldValue("AGENCY_ZIPCODE");
					TXT_AGENCY_CITY.Text			= conn.GetFieldValue("AGENCY_CITY");
					TXT_AGENCY_PHNAREA.Text			= conn.GetFieldValue("AGENCY_PHNAREA");
					TXT_AGENCY_PHNNUM.Text			= conn.GetFieldValue("AGENCY_PHNNUM");
					TXT_AGENCY_PHNEXT.Text			= conn.GetFieldValue("AGENCY_PHNEXT");
					TXT_AGENCY_FAXAREA.Text			= conn.GetFieldValue("AGENCY_FAXAREA");
					TXT_AGENCY_FAXNUM.Text			= conn.GetFieldValue("AGENCY_FAXNUM");
					TXT_AGENCY_FAXEXT.Text			= conn.GetFieldValue("AGENCY_FAXEXT");
					TXT_AGENCY_EMAIL.Text			= conn.GetFieldValue("AGENCY_EMAIL");

					activateControlKey(true);
					break;

				case "delete":					
					string ID = e.Item.Cells[0].Text.Trim();
					//conn.QueryString = "select * from RFAGENCY where AGENCYID = '" + ID + "' order by agencyname";
					conn.QueryString = "select * from VW_PARAM_RFAGENCY_2 where AGENCYID = '" + ID + "'";
					conn.ExecuteQuery();

					string CITYID		= conn.GetFieldValue("CITYID");
					string AGENCYTYPEID = conn.GetFieldValue("AGENCYTYPEID");
					string NAME			= conn.GetFieldValue("agencyname");
					string ADDR1		= conn.GetFieldValue("AGENCY_ADDR1");
					string ADDR2		= conn.GetFieldValue("AGENCY_ADDR2");
					string ADDR3		= conn.GetFieldValue("AGENCY_ADDR3");
					string ZIPCODE		= conn.GetFieldValue("AGENCY_ZIPCODE");					
					string PHNAREA		= conn.GetFieldValue("AGENCY_PHNAREA");
					string PHNNUM		= conn.GetFieldValue("AGENCY_PHNNUM");
					string PHNEXT		= conn.GetFieldValue("AGENCY_PHNEXT");
					string FAXAREA		= conn.GetFieldValue("AGENCY_FAXAREA");
					string FAXNUM		= conn.GetFieldValue("AGENCY_FAXNUM");
					string FAXEXT		= conn.GetFieldValue("AGENCY_FAXEXT");
					string EMAIL		= conn.GetFieldValue("AGENCY_EMAIL");

					conn.QueryString = "exec PARAM_GENERAL_RFAGENCY_MAKER '2', '"+CITYID+
						"', '" + ID + 
						"', '" + AGENCYTYPEID +
						"', '" + NAME + 
						"', '" + ADDR1 + 
						"', '" + ADDR2 + 
						"', '" + ADDR3 + 
						"', '" + EMAIL + 
						"', '" + PHNAREA + 
						"', '" + PHNNUM + 
						"', '" + PHNEXT + 
						"', '" + FAXAREA + 
						"', '" + FAXNUM + 
						"', '" + FAXEXT+ 
						"', '" + ZIPCODE + "'";
					conn.ExecuteQuery();
					viewRequest();
					break;

				default :
					break;
			}
		}

		protected void BTN_BACK_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			Response.Redirect("/SME/Maintenance/Parameters/GeneralParam.aspx?mc="+Request.QueryString["mc"]);
		}

		protected void BTN_CANCEL_Click(object sender, System.EventArgs e)
		{
			clearControls();
			LBL_SAVEMODE.Text = "1";
		}
	}
}
