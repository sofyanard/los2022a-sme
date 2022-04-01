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
using System.IO;
using System.Diagnostics;

namespace SME.InitialDataEntry.Channeling
{
	/// <summary>
	/// Summary description for ListInitiation.
	/// </summary>
	public partial class UploadData : System.Web.UI.Page
	{
		protected Connection conn;
		protected System.Web.UI.WebControls.ImageButton BTN_BACK;
		protected System.Web.UI.HtmlControls.HtmlTableRow TR_COLL;
		protected Tools tool = new Tools();
		protected ArrayList array = new ArrayList();
		private SMEExportImport.WordClient client;

		protected void Page_Load(object sender, System.EventArgs e)
		{
			conn = (Connection) Session["Connection"];
			tobehidden.Visible = false;
			client = new SMEExportImport.WordClient();

			if (!Logic.AllowAccess(Session["GroupID"].ToString(), Request.QueryString["mc"], conn))
				Response.Redirect("/SME/Restricted.aspx");

			ViewMenu();
			//BindData("dgListChan","EXEC CHANNELING_GET_INITIALDATAENTRY_UPLOADATA '" + Request.QueryString["curef"] + "','" + Session["UserID"].ToString() + "','" + Request.QueryString["regno"] + "'");
			BindData("dgListChan","EXEC CHANNELING_GET_UPLOADED_DATA '" + Request.QueryString["regno"] + "','" + Request.QueryString["productid"] + "','" + Request.QueryString["aano"] + "','" + Request.QueryString["prodseq"] + "'");
			BindData("DATA_EXPORT","EXEC CHANNELING_GET_FILE_UPLOAD_CHANNELING_UPLOADATA '" + Request.QueryString["regno"] + "'");
			ViewTemplateParameterChanneling();
			ViewUploadFiles();

			BindDgListChan();

			if (!IsPostBack)
			{
				PutExistingData();
			}
		}

		private void BindDgListChan()
		{

			for(int i=0; i< dgListChan.Items.Count; i++)
			{
				//dari sini pake index
				/*** DropDownList Assign To ***/
				DropDownList DDL_KOLEKTIBILITAS = (DropDownList) dgListChan.Items[i].Cells[3].FindControl("DDL_KOLEKTIBILITAS");
				if(DDL_KOLEKTIBILITAS != null)
				{
					GlobalTools.fillRefList(DDL_KOLEKTIBILITAS, "Select collectid, collectdesc  from RFCOLLECTABILITY where active=1" , false, conn);
					DDL_KOLEKTIBILITAS.ID = "DDL_KOLEKTIBILITAS." + dgListChan.Items[i].Cells[1].Text.ToString();
				}

				RadioButton rdo_yes = (RadioButton) dgListChan.Items[i].Cells[4].FindControl("rdo_yes");
				if(rdo_yes != null)
				{
					rdo_yes.ID = "rdo_yes." + dgListChan.Items[i].Cells[1].Text.ToString();
				}

				RadioButton rdo_no = (RadioButton) dgListChan.Items[i].Cells[4].FindControl("rdo_no");
				if(rdo_no != null)
				{
					rdo_no.ID = "rdo_no." + dgListChan.Items[i].Cells[1].Text.ToString();
				}
			}
		}

		private void PutExistingData()
		{
			for(int i=0; i< dgListChan.Items.Count; i++)
			{
				conn.QueryString = "SELECT AP_BLBIPEMILIK, AP_BLBIMCBKS FROM APPLICATION WHERE AP_REGNO = '" + dgListChan.Items[i].Cells[1].Text.ToString() + "'";
				conn.ExecuteQuery();

				DropDownList DDL_KOLEKTIBILITAS = (DropDownList) dgListChan.Items[i].Cells[3].FindControl("DDL_KOLEKTIBILITAS." + dgListChan.Items[i].Cells[1].Text.ToString());
				RadioButton rdo_yes = (RadioButton) dgListChan.Items[i].Cells[4].FindControl("rdo_yes." + dgListChan.Items[i].Cells[1].Text.ToString());
				RadioButton rdo_no = (RadioButton) dgListChan.Items[i].Cells[4].FindControl("rdo_no." + dgListChan.Items[i].Cells[1].Text.ToString());

				if(rdo_no != null && rdo_yes != null)
				{
					if(conn.GetFieldValue("AP_BLBIPEMILIK") == "0")
					{
						rdo_no.Checked = true;
						rdo_yes.Checked = false;
					}
					else
					{
						rdo_no.Checked = false;
						rdo_yes.Checked = true;
					}
				}

				if(DDL_KOLEKTIBILITAS != null)
				{
					if(conn.GetFieldValue("AP_BLBIMCBKS") == "")
					{
						DDL_KOLEKTIBILITAS.SelectedIndex = 0;
					}
					else
					{
						DDL_KOLEKTIBILITAS.SelectedValue  = conn.GetFieldValue("AP_BLBIMCBKS");
					}
				}

			}
		}


		protected void BTN_SAVE_Click(object sender, System.EventArgs e)
		{	
			for(int i=0; i< dgListChan.Items.Count; i++)
			{
				string a = "DDL_KOLEKTIBILITAS." + dgListChan.Items[i].Cells[1].Text.ToString();

				DropDownList DDL_KOLEKTIBILITAS = (DropDownList) dgListChan.Items[i].Cells[3].FindControl("DDL_KOLEKTIBILITAS." + dgListChan.Items[i].Cells[1].Text);
				if(DDL_KOLEKTIBILITAS != null)
				{
					string sql = "update APPLICATION set AP_BLBIACCBK = '' " +
						",AP_BLBIOCBK = '" + DDL_KOLEKTIBILITAS.SelectedValue + "' " +
						",AP_BLBIMCBKS = '" + DDL_KOLEKTIBILITAS.SelectedValue + "' " +
						",AP_BLBIACCBK12BLN = '" + DDL_KOLEKTIBILITAS.SelectedValue + "' " +
						",AP_BLBIOCBK12BLN = '" + DDL_KOLEKTIBILITAS.SelectedValue + "' " +
						",AP_BLBIMCBKS12BLN = '" + DDL_KOLEKTIBILITAS.SelectedValue + "' " +
						"where AP_REGNO = '" + dgListChan.Items[i].Cells[1].Text.ToString() + "'";
					conn.QueryString = sql;
					conn.ExecuteNonQuery();
				}

				string b = "rdo_yes." + dgListChan.Items[i].Cells[1].Text.ToString();

				RadioButton rdo_yes = (RadioButton) dgListChan.Items[i].Cells[4].FindControl("rdo_yes." + dgListChan.Items[i].Cells[1].Text.ToString());
				if(rdo_yes != null)
				{
					if(rdo_yes.Checked == true)
					{
						string sql = "update APPLICATION set ";
						sql += "AP_BLBIPEMILIK = '1'";
						sql += ",AP_BLBIMGMT = '1'";
						sql += ",AP_BLBIUSAHA = '1'";
						sql += ",AP_BLBIPERNAH = '1'";
						sql += " where AP_REGNO = '" + dgListChan.Items[i].Cells[1].Text.ToString() + "'";
						conn.QueryString = sql;
						conn.ExecuteNonQuery();
					}
				}

				string c = "rdo_no." + dgListChan.Items[i].Cells[1].Text.ToString();

				RadioButton rdo_no = (RadioButton) dgListChan.Items[i].Cells[4].FindControl("rdo_no." + dgListChan.Items[i].Cells[1].Text.ToString());
				if(rdo_no != null)
				{
					if(rdo_no.Checked == true)
					{
						string sql = "update APPLICATION set ";
						sql += "AP_BLBIPEMILIK = '0'";
						sql += ",AP_BLBIMGMT = '0'";
						sql += ",AP_BLBIUSAHA = '0'";
						sql += ",AP_BLBIPERNAH = '0'";
						sql += " where AP_REGNO = '" + dgListChan.Items[i].Cells[1].Text.ToString() + "'";
						conn.QueryString = sql;
						conn.ExecuteNonQuery();
					}
				}
			}

			BindData("dgListChan","EXEC CHANNELING_GET_UPLOADED_DATA '" + Request.QueryString["regno"] + "','" + Request.QueryString["productid"] + "','" + Request.QueryString["aano"] + "','" + Request.QueryString["prodseq"] + "'");
			BindDgListChan();
			PutExistingData();
		}

		private void ViewTemplateParameterChanneling()
		{
			string url = "";
			System.Data.DataTable dt = new System.Data.DataTable();
			conn.QueryString = "SELECT ID_TEMPLATE_CHANNELING, NAMA_TEMPLATE_CHANNELING, LINK_TEMPLATE_CHANNELING FROM TEMPLATE_CHANNELING";
			conn.ExecuteQuery();

			if (conn.GetRowCount() > 0) 
			{
				url = conn.GetFieldValue("LINK_TEMPLATE_CHANNELING");
			}

			dt = conn.GetDataTable().Copy();
			DATA_TEMPLATE.DataSource = dt;
			try 
			{
				DATA_TEMPLATE.DataBind();
			} 
			catch 
			{
				DATA_TEMPLATE.CurrentPageIndex = 0;
				DATA_TEMPLATE.DataBind();
			}
			for (int i = 1; i <= DATA_TEMPLATE.Items.Count; i++)
			{
				HyperLink HpDownload = (HyperLink) DATA_TEMPLATE.Items[i-1].Cells[2].FindControl("HL_DOWNLOAD");
				HpDownload.NavigateUrl = url + "ChannelingTemplate.xlt";
			}
		}

		private void ViewUploadFiles()
		{
			string url = "";
			conn.QueryString = "SELECT EXPORT_URL FROM RFCHANNELINGCUSTEXPORT WHERE EXPORT_ID = '" + "CHANNELING" + "'";
			conn.ExecuteQuery();

			if (conn.GetRowCount() > 0) 
			{
				url = conn.GetFieldValue("EXPORT_URL");
			}

			System.Data.DataTable dt = new System.Data.DataTable();
			conn.QueryString = "EXEC CHANNELING_GET_INITIALDATAENTRY_UPLOADATA '" + Request.QueryString["curef"] + "','" + Session["UserID"].ToString() + "','" + Request.QueryString["regno"] + "'";
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
			for (int i = 1; i <= DATA_EXPORT.Items.Count; i++)
			{
				HyperLink HpDownload = (HyperLink) DATA_EXPORT.Items[i-1].Cells[2].FindControl("UPL_CHANNELING_DOWNLOAD");
				LinkButton HpDelete = (LinkButton) DATA_EXPORT.Items[i-1].Cells[3].FindControl("UPL_CHANNELING_DELETE");
				HpDownload.NavigateUrl = url + conn.GetFieldValue("FILE_UPLOAD_CHANNELING_NAME");
			}
		}

		private void ViewData(string sta)
		{	
			DataTable dt = new DataTable();
			if (sta == "1")
				conn.QueryString = "select * from VW_CHANNELING_INITIATION_LIST where cu_name like ''";
			else
				conn.QueryString = "select * from VW_CHANNELING_INITIATION_LIST";
			conn.ExecuteQuery();
			dt = conn.GetDataTable().Copy();
			dgListChan.DataSource = dt;
			dgListChan.DataBind();
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
			this.DATA_EXPORT.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.DATA_EXPORT_PageIndexChanged);
			this.dgListChan.ItemCreated += new System.Web.UI.WebControls.DataGridItemEventHandler(this.dgListChan_ItemCreated);
			this.dgListChan.ItemCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.dgListChan_ItemCommand);
			this.dgListChan.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.dgListChan_PageIndexChanged);

		}
		#endregion

		private void selectAllYes()
		{
			for(int i=0; i< dgListChan.Items.Count; i++)
			{
				string b = dgListChan.Items[i].Cells[1].Text.ToString();

				RadioButton rdo_yes = (RadioButton) dgListChan.Items[i].Cells[4].FindControl("rdo_yes." + dgListChan.Items[i].Cells[1].Text.ToString());
				RadioButton rdo_no = (RadioButton) dgListChan.Items[i].Cells[4].FindControl("rdo_no." + dgListChan.Items[i].Cells[1].Text.ToString());

				if(rdo_no != null && rdo_yes != null)
				{
						rdo_no.Checked = false;
						rdo_yes.Checked = true;
				}
			}
		}

		private void selectAllNo()
		{
			for(int i=0; i< dgListChan.Items.Count; i++)
			{
				RadioButton rdo_yes = (RadioButton) dgListChan.Items[i].Cells[4].FindControl("rdo_yes." + dgListChan.Items[i].Cells[1].Text.ToString());
				RadioButton rdo_no = (RadioButton) dgListChan.Items[i].Cells[4].FindControl("rdo_no." + dgListChan.Items[i].Cells[1].Text.ToString());

				if(rdo_no != null && rdo_yes != null)
				{
					rdo_no.Checked = true;
					rdo_yes.Checked = false;
				}
			}
		}

		private void dgListChan_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			switch (((LinkButton)e.CommandSource).CommandName)
			{
				case "Edit":
					Response.Redirect("EditNasabah.aspx?curefanak="+e.Item.Cells[6].Text+"&curef="+Request.QueryString["curef"]+"&regnoanak="+e.Item.Cells[1].Text+"&regno="+Request.QueryString["regno"]+"&mc=" + Request.QueryString["mc"]+"&tc="+Request.QueryString["tc"]+"&productid="+Request.QueryString["productid"]+"&aano="+Request.QueryString["aano"]+"&prodseq="+Request.QueryString["prodseq"]+"&parentregno="+Request.QueryString["parentregno"]);
					break;
				case "Delete":
					conn.QueryString = "EXEC CHANNELING_DELETE_PER_ENDUSER '"+e.Item.Cells[6].Text+"','"+e.Item.Cells[1].Text+"'";
					conn.ExecuteQuery();
					BindData("dgListChan","EXEC CHANNELING_GET_UPLOADED_DATA '" + Request.QueryString["regno"] + "','" + Request.QueryString["productid"] + "','" + Request.QueryString["aano"] + "','" + Request.QueryString["prodseq"] + "'");
					BindDgListChan();
					PutExistingData();
					break;
				case "yesall":
					BindData("dgListChan","EXEC CHANNELING_GET_UPLOADED_DATA '" + Request.QueryString["regno"] + "','" + Request.QueryString["productid"] + "','" + Request.QueryString["aano"] + "','" + Request.QueryString["prodseq"] + "'");
					BindDgListChan();
					PutExistingData();
					selectAllYes();
					break;
				case "noall":
					BindData("dgListChan","EXEC CHANNELING_GET_UPLOADED_DATA '" + Request.QueryString["regno"] + "','" + Request.QueryString["productid"] + "','" + Request.QueryString["aano"] + "','" + Request.QueryString["prodseq"] + "'");
					BindDgListChan();
					PutExistingData();
					selectAllNo();
					break;
			}
		}

		private void btn_cari_Click(object sender, System.EventArgs e)
		{
			ViewData("1");
		}

		private void ViewMenu()
		{
			try 
			{
				conn.QueryString = "select SM_ID,MENUCODE,SM_MENUDISPLAY,SM_LINKNAME from SCREENMENU where menucode = '"+Request.QueryString["mc"]+"'";
				conn.ExecuteQuery();
				for (int i = 0; i < conn.GetRowCount(); i++) 
				{
					HyperLink t = new HyperLink();
					t.Text = conn.GetFieldValue(i, 2);
					t.Font.Bold = true;
					string strtemp = "";
					if (conn.GetFieldValue(i, 3).Trim()!= "") 
					{
						if (conn.GetFieldValue(i,3).IndexOf("mc=") >= 0)
							strtemp = "regno=" + Request.QueryString["regno"]+ "&curef="+Request.QueryString["curef"]+"&mc="+Request.QueryString["mc"]+"&tc="+Request.QueryString["tc"]+"&jnsnasabah="+Request.QueryString["jnsnasabah"]+"&programid="+Request.QueryString["programid"]+"&lmsreg="+Request.QueryString["lmsreg"]+"&scr="+Request.QueryString["scr"]+"&parentregno="+Request.QueryString["parentregno"]+"&aano="+Request.QueryString["aano"] + "&productid=" + Request.QueryString["productid"] + "&prodseq=" + Request.QueryString["prodseq"];
						else	
							strtemp = "regno=" + Request.QueryString["regno"]+ "&curef="+Request.QueryString["curef"]+"&mc="+Request.QueryString["mc"]+"&tc="+Request.QueryString["tc"]+"&jnsnasabah="+Request.QueryString["jnsnasabah"]+"&programid="+Request.QueryString["programid"]+"&lmsreg="+Request.QueryString["lmsreg"]+"&scr="+Request.QueryString["scr"]+"&parentregno="+Request.QueryString["parentregno"]+"&aano="+Request.QueryString["aano"] + "&productid=" + Request.QueryString["productid"] + "&prodseq=" + Request.QueryString["prodseq"];
						//t.ForeColor = Color.MidnightBlue; 
					}
					else 
					{
						strtemp = "";
						t.ForeColor = Color.Red; 
					}
					t.NavigateUrl = "../" + conn.GetFieldValue(i, 3)+strtemp;
					Menu.Controls.Add(t);
					Menu.Controls.Add(new LiteralControl("&nbsp;&nbsp;&nbsp;"));
				}
			} 
			catch (Exception ex) 
			{
				string temp = ex.ToString();
			}
		}

		private void BindData(string dataGridName, string strconn)
		{
			if(strconn != "")
			{
				conn.QueryString = strconn;
				conn.ExecuteQuery();
			}

			System.Data.DataTable dt = new System.Data.DataTable();
			dt = conn.GetDataTable().Copy();

			System.Web.UI.WebControls.DataGrid dg = (System.Web.UI.WebControls.DataGrid)Page.FindControl(dataGridName);

			dg.DataSource = dt;				

			try
			{
				dg.DataBind();
			}
			catch 
			{
				dg.CurrentPageIndex = dg.PageCount - 1;
				dg.DataBind();
			}

			conn.ClearData();
		}

		/********************************************UPLOAD FUNCTION************************************************/

		private void ReadExcel(string filename)
		{
			try
			{
				String status = client.ChannellingInitialDataEntryUploadExcel(
					filename,
					Request.QueryString["regno"],
					Request.QueryString["aano"],
					Request.QueryString["productid"],
					Request.QueryString["prodseq"], 
					Session["UserID"].ToString());

				//Show Success Message
				LBL_STATUS.ForeColor = Color.Green;
				LBL_STATUSREPORT.ForeColor = Color.Green;
				LBL_STATUS.Text = "Upload Sucessful! Insert Result Sucessful!";
				LBL_STATUSREPORT.Text = "";
			}
			catch (Exception ex)
			{
				LBL_STATUS.ForeColor = Color.Red;
				LBL_STATUSREPORT.ForeColor = Color.Red;
				LBL_STATUS.Text = "Upload Failed !";
				LBL_STATUSREPORT.Text = ex.Message + "\n" + ex.StackTrace;
			}
		}

		private void dgListChan_EditCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			switch (((LinkButton)e.CommandSource).CommandName)
			{
				case "Edit":
					Response.Redirect("EditNasabah.aspx?curef="+e.Item.Cells[3].Text+"&regnoanak="+e.Item.Cells[1].Text+"&regno="+Request.QueryString["regno"]+"&mc=" + Request.QueryString["mc"]+"&tc="+Request.QueryString["tc"]);
					break;
			}
		}


		protected void BTN_UPLOAD_Click(object sender, System.EventArgs e)
		{
			string directory;
			int counter = 0;
			int max_id = 10000;
			string outputfilename = "";

			//Get Export Properties
			conn.QueryString = "EXEC CHANNELING_INSERT_FILE_UPLOAD '" + Session["USERID"].ToString() + "','" +
				Path.GetFileName(TXT_FILE_UPLOAD.PostedFile.FileName) + "','" + Request.QueryString["regno"] + "'";
			conn.ExecuteQuery();

			conn.QueryString = "SELECT MAX(ID_UPLOAD_CHANNELING) as MAX_ID from [FILE_UPLOAD_CHANNELING]";
			conn.ExecuteQuery();

			if (conn.GetRowCount() > 0)
			{
				max_id = int.Parse(conn.GetFieldValue("MAX_ID"));
			}

			conn.QueryString = "SELECT FILE_UPLOAD_CHANNELING_NAME from [FILE_UPLOAD_CHANNELING] where ID_UPLOAD_CHANNELING = '" + max_id + "'";
			conn.ExecuteQuery();

			if (conn.GetRowCount() > 0)
			{
				outputfilename = conn.GetFieldValue("FILE_UPLOAD_CHANNELING_NAME");
			}

			conn.QueryString = "SELECT EXPORT_URL FROM RFCHANNELINGCUSTEXPORT WHERE EXPORT_ID = 'CHANNELING'";
			conn.ExecuteQuery();

			if (conn.GetRowCount() > 0)
			{
				directory = Server.MapPath(conn.GetFieldValue("EXPORT_URL").Trim());

				HttpFileCollection uploadedFiles = Request.Files;

				for (int i = 0; i < uploadedFiles.Count; i++)
				{
					HttpPostedFile userPostedFile = uploadedFiles[i];
					counter = i + 1;

					try
					{
						if (userPostedFile.ContentLength > 0)
						{
							userPostedFile.SaveAs(directory + outputfilename);

							LBL_STATUS.ForeColor = Color.Green;
							LBL_STATUSREPORT.ForeColor = Color.Green;
							LBL_STATUS.Text = "Upload Successful!";
							LBL_STATUSREPORT.Text = "<u>File #" + counter.ToString() + "</u><br>" + 
								"File Content Type: " + userPostedFile.ContentType + "<br>" + 
								"File Size: " + userPostedFile.ContentLength + " bytes<br>" + 
								"File Name: " + userPostedFile.FileName + "<br>" +
								"Location Where Saved: " + directory + outputfilename + "<p>";

							//View Upload File
							ViewUploadFiles();
						}
					}
					catch (Exception ex)
					{
						LBL_STATUS.ForeColor = Color.Red;
						LBL_STATUSREPORT.ForeColor = Color.Red;
						LBL_STATUS.Text = "Upload Failed!";
						LBL_STATUSREPORT.Text = ex.Message + "\n" + ex.StackTrace;
					}
				}

				try
				{
					ReadExcel(directory + outputfilename);
				}
				catch(Exception ex)
				{
					LBL_STATUSREPORT.Text = ex.Message + "\n" + ex.StackTrace;
				}
			}
			insertMainCustProduct();
			ViewUploadFiles();
			BindData("dgListChan","EXEC CHANNELING_GET_UPLOADED_DATA '" + Request.QueryString["regno"] + "','" + Request.QueryString["productid"] + "','" + Request.QueryString["aano"] + "','" + Request.QueryString["prodseq"] + "'");
			BindDgListChan();
			PutExistingData();
		}

		private void insertMainCustProduct()
		{
			conn.QueryString = "EXEC CHANNELING_INSERT_PARENT_CUSTPRODUCT '" + Request.QueryString["regno"] + "','01','" + Request.QueryString["productid"] + "'," + Request.QueryString["prodseq"]+ ",'TCHAN1.0','" + Session["UserID"].ToString() + "'";
			conn.ExecuteQuery();
		}

		private void DATA_EXPORT_EditCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			switch (((LinkButton)e.CommandSource).CommandName)
			{
				case "delete":
					conn.QueryString = "DELETE FROM FILE_UPLOAD_CHANNELING WHERE ID_UPLOAD_CHANNELING = '" + e.Item.Cells[0].Text + "'";
					conn.ExecuteQuery();
					BindData("DATA_EXPORT","EXEC CHANNELING_GET_FILE_UPLOAD_CHANNELING_UPLOADATA '" + Request.QueryString["regno"] + "'");
					break;
			}
		}

		private void DATA_EXPORT_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			switch (((LinkButton)e.CommandSource).CommandName)
			{
				case "delete":
					conn.QueryString = "DELETE FROM FILE_UPLOAD_CHANNELING WHERE ID_UPLOAD_CHANNELING = '" + e.Item.Cells[0].Text + "'";
					conn.ExecuteQuery();
					BindData("DATA_EXPORT","EXEC CHANNELING_GET_FILE_UPLOAD_CHANNELING_UPLOADATA '" + Request.QueryString["regno"] + "'");
					break;
			}
		}

		private void DATA_EXPORT_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			if(DATA_EXPORT.CurrentPageIndex >= 0 && DATA_EXPORT.CurrentPageIndex < DATA_EXPORT.PageCount)
			{
				DATA_EXPORT.CurrentPageIndex = e.NewPageIndex;
				BindData("DATA_EXPORT","EXEC CHANNELING_GET_FILE_UPLOAD_CHANNELING_UPLOADATA '" + Request.QueryString["regno"] + "'");
			}
		}

		private void dgListChan_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			if(dgListChan.CurrentPageIndex >= 0 && dgListChan.CurrentPageIndex < dgListChan.PageCount)
			{
				dgListChan.CurrentPageIndex = e.NewPageIndex;
				BindData("dgListChan","EXEC CHANNELING_GET_UPLOADED_DATA '" + Request.QueryString["regno"] + "','" + Request.QueryString["productid"] + "','" + Request.QueryString["aano"] + "','" + Request.QueryString["prodseq"] + "'");
				BindDgListChan();
				PutExistingData();
			}
		}

		private void dgListChan_ItemCreated(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{

		}


		public class UploadedData
		{
			private string cif;
			private string rorac;
			private string ec;

			public UploadedData(string CIF, string RORAC, string EC)
			{
				this.cif = CIF;
				this.rorac = RORAC;
				this.ec = EC;
			}

			public string CIF
			{
				get
				{
					return this.cif;
				}
			}

			public string RORAC
			{
				get
				{
					return this.rorac;
				}
			}

			public string EC
			{
				get
				{
					return this.ec;
				}
			}
		}
	}
}
