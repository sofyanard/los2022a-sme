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
	/// Summary description for UploadDocument.
	/// </summary>
	public partial class UploadDocument : System.Web.UI.Page
	{
		protected Connection conn;
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			conn = (Connection) Session["Connection"];
			if (!Logic.AllowAccess(Session["GroupID"].ToString(), Request.QueryString["mc"], conn))
				Response.Redirect("/SME/Restricted.aspx");

			if (!IsPostBack)
			{
				DDL_KSEBM_IU.Items.Add(new ListItem("--Pilih--"));
				DDL_KSEBM_PPS.Items.Add(new ListItem("--Pilih--"));
				DDL_KSEBM_KS.Items.Add(new ListItem("--Pilih--"));
				DDL_KSEBM_IST.Items.Add(new ListItem("--Pilih--"));
				DDL_KSEBM_HST.Items.Add(new ListItem("--Pilih--"));
				DDL_KSEBM_BS.Items.Add(new ListItem("--Pilih--"));

				conn.QueryString = "select PD_INDUSTRY_NAMECD, PD_INDUSTRY_NAME from PD_RF_INDUSTRY_CLASS where active='1' order by convert(int,PD_INDUSTRY_NAMECD)";
				conn.ExecuteQuery();
				for (int i = 0; i < conn.GetRowCount(); i++)
					DDL_KSEBM_IU.Items.Add(new ListItem(conn.GetFieldValue(i,0) + " - " + conn.GetFieldValue(i,1), conn.GetFieldValue(i,0)));

				conn.QueryString = "select PD_INDUSTRY_NAMECD, PD_INDUSTRY_NAME from PD_RF_INDUSTRY_CLASS where active='1' order by convert(int,PD_INDUSTRY_NAMECD)";
				conn.ExecuteQuery();
				for (int i = 0; i < conn.GetRowCount(); i++)
					DDL_KSEBM_PPS.Items.Add(new ListItem(conn.GetFieldValue(i,0) + " - " + conn.GetFieldValue(i,1), conn.GetFieldValue(i,0)));

				conn.QueryString = "select PD_INDUSTRY_NAMECD, PD_INDUSTRY_NAME from PD_RF_INDUSTRY_CLASS where active='1' order by convert(int,PD_INDUSTRY_NAMECD)";
				conn.ExecuteQuery();
				for (int i = 0; i < conn.GetRowCount(); i++)
					DDL_KSEBM_KS.Items.Add(new ListItem(conn.GetFieldValue(i,0) + " - " + conn.GetFieldValue(i,1), conn.GetFieldValue(i,0)));

				conn.QueryString = "select PD_INDUSTRY_NAMECD, PD_INDUSTRY_NAME from PD_RF_INDUSTRY_CLASS where active='1' order by convert(int,PD_INDUSTRY_NAMECD)";
				conn.ExecuteQuery();
				for (int i = 0; i < conn.GetRowCount(); i++)
					DDL_KSEBM_IST.Items.Add(new ListItem(conn.GetFieldValue(i,0) + " - " + conn.GetFieldValue(i,1), conn.GetFieldValue(i,0)));

				conn.QueryString = "select PD_INDUSTRY_NAMECD, PD_INDUSTRY_NAME from PD_RF_INDUSTRY_CLASS where active='1' order by convert(int,PD_INDUSTRY_NAMECD)";
				conn.ExecuteQuery();
				for (int i = 0; i < conn.GetRowCount(); i++)
					DDL_KSEBM_HST.Items.Add(new ListItem(conn.GetFieldValue(i,0) + " - " + conn.GetFieldValue(i,1), conn.GetFieldValue(i,0)));
			
				conn.QueryString = "select PD_INDUSTRY_NAMECD, PD_INDUSTRY_NAME from PD_RF_INDUSTRY_CLASS where active='1' order by convert(int,PD_INDUSTRY_NAMECD)";
				conn.ExecuteQuery();
				for (int i = 0; i < conn.GetRowCount(); i++)
					DDL_KSEBM_BS.Items.Add(new ListItem(conn.GetFieldValue(i,0) + " - " + conn.GetFieldValue(i,1), conn.GetFieldValue(i,0)));

				ViewUploadFiles1();
				ViewUploadFiles2();
				ViewUploadFiles3();
				ViewUploadFiles4();
				ViewUploadFiles5();
				ViewUploadFiles6();
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
			this.DATA_EXPORT1.ItemCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.DATA_EXPORT1_ItemCommand);
			this.DATA_EXPORT2.ItemCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.DATA_EXPORT2_ItemCommand);
			this.DATA_EXPORT3.ItemCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.DATA_EXPORT3_ItemCommand);
			this.DATA_EXPORT4.ItemCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.DATA_EXPORT4_ItemCommand);
			this.DATA_EXPORT5.ItemCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.DATA_EXPORT5_ItemCommand);
			this.DATA_EXPORT6.ItemCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.DATA_EXPORT6_ItemCommand);

		}
		#endregion

		private void ViewUploadFiles1()
		{
			string url = "";
			conn.QueryString = "SELECT EXPORT_URL FROM PIC_RFEXPORT WHERE EXPORT_ID = '" + "PIC" + "'";
			conn.ExecuteQuery();

			if (conn.GetRowCount() > 0) 
			{
				url = conn.GetFieldValue("EXPORT_URL");
			}

			System.Data.DataTable dt = new System.Data.DataTable();
			conn.QueryString = "SELECT ID_UPLOAD, FILE_UPLOAD_NAME FROM PIC_FILE_UPLOAD_IU where KSEBM ='" +DDL_KSEBM_IU.SelectedValue+ "'";
			conn.ExecuteQuery();
			dt = conn.GetDataTable().Copy();
			DATA_EXPORT1.DataSource = dt;
			try 
			{
				DATA_EXPORT1.DataBind();
			} 
			catch 
			{
				DATA_EXPORT1.CurrentPageIndex = 0;
				DATA_EXPORT1.DataBind();
			}
			for (int i = 1; i <= DATA_EXPORT1.Items.Count; i++)
			{
				LinkButton HpDelete = (LinkButton) DATA_EXPORT1.Items[i-1].Cells[3].FindControl("UPL1_DELETE");
			}
		}

		protected void UPLOAD_IU_Click(object sender, System.EventArgs e)
		{
				string directory;
				int counter = 0;
				int max_id = 10000;
				string outputfilename = "";

				//Get Export Properties
				conn.QueryString = "EXEC PIC_INSERT_FILE_UPLOAD_IU '" + Session["USERID"].ToString() + "','" +
					Path.GetFileName(TXT_FILE_UPLOAD_IU.PostedFile.FileName) + "','"+DDL_KSEBM_IU.SelectedValue+"'";
				conn.ExecuteQuery();

				conn.QueryString = "SELECT MAX(ID_UPLOAD) as MAX_ID from [PIC_FILE_UPLOAD_IU]";
				conn.ExecuteQuery();

				if (conn.GetRowCount() > 0)
				{
					max_id = int.Parse(conn.GetFieldValue("MAX_ID"));
				}

				conn.QueryString = "SELECT FILE_UPLOAD_NAME from [PIC_FILE_UPLOAD_IU] where ID_UPLOAD = '" + max_id + "'";
				conn.ExecuteQuery();

				if (conn.GetRowCount() > 0)
				{
					outputfilename = conn.GetFieldValue("FILE_UPLOAD_NAME");
				}

				conn.QueryString = "SELECT EXPORT_URL FROM PIC_RFEXPORT WHERE EXPORT_ID = 'PIC'";
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

								LBL_STATUS1.ForeColor = Color.Green;
								LBL_STATUSREPORT1.ForeColor = Color.Green;
								LBL_STATUS1.Text = "Upload Successful!";
								LBL_STATUSREPORT1.Text = "<u>File #" + counter.ToString() + "</u><br>" + 
									"File Content Type: " + userPostedFile.ContentType + "<br>" + 
									"File Size: " + userPostedFile.ContentLength + " bytes<br>" + 
									"File Name: " + userPostedFile.FileName + "<br>" +
									"Location Where Saved: " + directory + outputfilename + "<p>";

								ViewUploadFiles1();
							}
						}
						catch (Exception ex)
						{
							LBL_STATUS1.ForeColor = Color.Red;
							LBL_STATUSREPORT1.ForeColor = Color.Red;
							LBL_STATUS1.Text = "Upload Failed!";
							LBL_STATUSREPORT1.Text = ex.Message + "\n" + ex.StackTrace;
						}
					}
				}
				ViewUploadFiles1();
			}

		protected void DDL_KSEBM_IU_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			ViewUploadFiles1();
		}

		private void DATA_EXPORT1_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			int i;
			switch (((LinkButton)e.CommandSource).CommandName)
			{
				case "delete":
					conn.QueryString = "DELETE FROM PIC_FILE_UPLOAD_IU WHERE ID_UPLOAD = '" + e.Item.Cells[0].Text + "'";
					conn.ExecuteQuery();
					ViewUploadFiles1();
					break;

				
				case "allfac1":
					for (i = 0; i < DATA_EXPORT1.Items.Count; i++)
					{
						try
						{
							CheckBox cb = (CheckBox) DATA_EXPORT1.Items[i].Cells[2].FindControl("chk_1");
							if(cb != null)
							{
								string a = cb.ID.ToString();
								cb.Checked = true;
							}
						} 
						catch(Exception ex) {}
					}
					break;
				default:
					break;
			}
		}

		protected void DELETE_IU_Click(object sender, System.EventArgs e)
		{
			for (int i=0; i<DATA_EXPORT1.Items.Count; i++)
			{
				CheckBox cbf = (CheckBox) DATA_EXPORT1.Items[i].Cells[2].FindControl("chk_1");
				if (cbf.Checked == true)
				{
					conn.QueryString = "DELETE PIC_FILE_UPLOAD_IU where ID_UPLOAD = '" +
					DATA_EXPORT1.Items[i].Cells[0].Text.Trim() + "'";
					conn.ExecuteNonQuery();
				}
			}
			ViewUploadFiles1();
		}

		private void ViewUploadFiles2()
		{
			string url = "";
			conn.QueryString = "SELECT EXPORT_URL FROM PIC_RFEXPORT WHERE EXPORT_ID = '" + "PIC" + "'";
			conn.ExecuteQuery();

			if (conn.GetRowCount() > 0) 
			{
				url = conn.GetFieldValue("EXPORT_URL");
			}

			System.Data.DataTable dt = new System.Data.DataTable();
			conn.QueryString = "SELECT ID_UPLOAD, FILE_UPLOAD_NAME FROM PIC_FILE_UPLOAD_PPS where KSEBM ='" +DDL_KSEBM_PPS.SelectedValue+ "'";
			conn.ExecuteQuery();
			dt = conn.GetDataTable().Copy();
			DATA_EXPORT2.DataSource = dt;
			try 
			{
				DATA_EXPORT2.DataBind();
			} 
			catch 
			{
				DATA_EXPORT2.CurrentPageIndex = 0;
				DATA_EXPORT2.DataBind();
			}
			for (int i = 1; i <= DATA_EXPORT2.Items.Count; i++)
			{
				LinkButton HpDelete = (LinkButton) DATA_EXPORT2.Items[i-1].Cells[3].FindControl("UPL2_DELETE");
			}
		}

		protected void UPLOAD_PPS_Click(object sender, System.EventArgs e)
		{
			string directory;
			int counter = 0;
			int max_id = 10000;
			string outputfilename = "";

			//Get Export Properties
			conn.QueryString = "EXEC PIC_INSERT_FILE_UPLOAD_PPS '" + Session["USERID"].ToString() + "','" +
				Path.GetFileName(TXT_FILE_UPLOAD_PPS.PostedFile.FileName) + "','"+DDL_KSEBM_PPS.SelectedValue+"'";
			conn.ExecuteQuery();

			conn.QueryString = "SELECT MAX(ID_UPLOAD) as MAX_ID from [PIC_FILE_UPLOAD_PPS]";
			conn.ExecuteQuery();

			if (conn.GetRowCount() > 0)
			{
				max_id = int.Parse(conn.GetFieldValue("MAX_ID"));
			}

			conn.QueryString = "SELECT FILE_UPLOAD_NAME from [PIC_FILE_UPLOAD_PPS] where ID_UPLOAD = '" + max_id + "'";
			conn.ExecuteQuery();

			if (conn.GetRowCount() > 0)
			{
				outputfilename = conn.GetFieldValue("FILE_UPLOAD_NAME");
			}

			conn.QueryString = "SELECT EXPORT_URL FROM PIC_RFEXPORT WHERE EXPORT_ID = 'PIC'";
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

							LBL_STATUS2.ForeColor = Color.Green;
							LBL_STATUSREPORT2.ForeColor = Color.Green;
							LBL_STATUS2.Text = "Upload Successful!";
							LBL_STATUSREPORT2.Text = "<u>File #" + counter.ToString() + "</u><br>" + 
								"File Content Type: " + userPostedFile.ContentType + "<br>" + 
								"File Size: " + userPostedFile.ContentLength + " bytes<br>" + 
								"File Name: " + userPostedFile.FileName + "<br>" +
								"Location Where Saved: " + directory + outputfilename + "<p>";

							ViewUploadFiles2();
						}
					}
					catch (Exception ex)
					{
						LBL_STATUS2.ForeColor = Color.Red;
						LBL_STATUSREPORT2.ForeColor = Color.Red;
						LBL_STATUS2.Text = "Upload Failed!";
						LBL_STATUSREPORT2.Text = ex.Message + "\n" + ex.StackTrace;
					}
				}
			}
			ViewUploadFiles2();
		}

		protected void DDL_KSEBM_PPS_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			ViewUploadFiles2();
		}

		private void DATA_EXPORT2_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			int i;
			switch (((LinkButton)e.CommandSource).CommandName)
			{
				case "delete":
					conn.QueryString = "DELETE FROM PIC_FILE_UPLOAD_PPS WHERE ID_UPLOAD = '" + e.Item.Cells[0].Text + "'";
					conn.ExecuteQuery();
					ViewUploadFiles2();
					break;

				
				case "allfac2":
					for (i = 0; i < DATA_EXPORT2.Items.Count; i++)
					{
						try
						{
							CheckBox cb = (CheckBox) DATA_EXPORT2.Items[i].Cells[2].FindControl("chk_2");
							if(cb != null)
							{
								string a = cb.ID.ToString();
								cb.Checked = true;
							}
						} 
						catch(Exception ex) {}
					}
					break;
				default:
					break;
			}
		}

		protected void DELETE_PPS_Click(object sender, System.EventArgs e)
		{
			for (int i=0; i<DATA_EXPORT2.Items.Count; i++)
			{
				CheckBox cbf = (CheckBox) DATA_EXPORT2.Items[i].Cells[2].FindControl("chk_2");
				if (cbf.Checked == true)
				{
					conn.QueryString = "DELETE PIC_FILE_UPLOAD_PPS where ID_UPLOAD = '" +
						DATA_EXPORT2.Items[i].Cells[0].Text.Trim() + "'";
					conn.ExecuteNonQuery();
				}
			}
			ViewUploadFiles2();
		}

		private void ViewUploadFiles3()
		{
			string url = "";
			conn.QueryString = "SELECT EXPORT_URL FROM PIC_RFEXPORT WHERE EXPORT_ID = '" + "PIC" + "'";
			conn.ExecuteQuery();

			if (conn.GetRowCount() > 0) 
			{
				url = conn.GetFieldValue("EXPORT_URL");
			}

			System.Data.DataTable dt = new System.Data.DataTable();
			conn.QueryString = "SELECT ID_UPLOAD, FILE_UPLOAD_NAME FROM PIC_FILE_UPLOAD_KS where KSEBM ='" +DDL_KSEBM_KS.SelectedValue+ "'";
			conn.ExecuteQuery();
			dt = conn.GetDataTable().Copy();
			DATA_EXPORT3.DataSource = dt;
			try 
			{
				DATA_EXPORT3.DataBind();
			} 
			catch 
			{
				DATA_EXPORT3.CurrentPageIndex = 0;
				DATA_EXPORT3.DataBind();
			}
			for (int i = 1; i <= DATA_EXPORT3.Items.Count; i++)
			{
				LinkButton HpDelete = (LinkButton) DATA_EXPORT3.Items[i-1].Cells[3].FindControl("UPL3_DELETE");
			}
		}

		protected void UPLOAD_KS_Click(object sender, System.EventArgs e)
		{
			string directory;
			int counter = 0;
			int max_id = 10000;
			string outputfilename = "";

			//Get Export Properties
			conn.QueryString = "EXEC PIC_INSERT_FILE_UPLOAD_KS '" + Session["USERID"].ToString() + "','" +
				Path.GetFileName(TXT_FILE_UPLOAD_KS.PostedFile.FileName) + "','"+DDL_KSEBM_KS.SelectedValue+"'";
			conn.ExecuteQuery();

			conn.QueryString = "SELECT MAX(ID_UPLOAD) as MAX_ID from [PIC_FILE_UPLOAD_KS]";
			conn.ExecuteQuery();

			if (conn.GetRowCount() > 0)
			{
				max_id = int.Parse(conn.GetFieldValue("MAX_ID"));
			}

			conn.QueryString = "SELECT FILE_UPLOAD_NAME from [PIC_FILE_UPLOAD_KS] where ID_UPLOAD = '" + max_id + "'";
			conn.ExecuteQuery();

			if (conn.GetRowCount() > 0)
			{
				outputfilename = conn.GetFieldValue("FILE_UPLOAD_NAME");
			}

			conn.QueryString = "SELECT EXPORT_URL FROM PIC_RFEXPORT WHERE EXPORT_ID = 'PIC'";
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

							LBL_STATUS3.ForeColor = Color.Green;
							LBL_STATUSREPORT3.ForeColor = Color.Green;
							LBL_STATUS3.Text = "Upload Successful!";
							LBL_STATUSREPORT3.Text = "<u>File #" + counter.ToString() + "</u><br>" + 
								"File Content Type: " + userPostedFile.ContentType + "<br>" + 
								"File Size: " + userPostedFile.ContentLength + " bytes<br>" + 
								"File Name: " + userPostedFile.FileName + "<br>" +
								"Location Where Saved: " + directory + outputfilename + "<p>";

							ViewUploadFiles3();
						}
					}
					catch (Exception ex)
					{
						LBL_STATUS3.ForeColor = Color.Red;
						LBL_STATUSREPORT3.ForeColor = Color.Red;
						LBL_STATUS3.Text = "Upload Failed!";
						LBL_STATUSREPORT3.Text = ex.Message + "\n" + ex.StackTrace;
					}
				}
			}
			ViewUploadFiles3();
		}

		protected void DDL_KSEBM_KS_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			ViewUploadFiles3();
		}

		private void DATA_EXPORT3_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			int i;
			switch (((LinkButton)e.CommandSource).CommandName)
			{
				case "delete":
					conn.QueryString = "DELETE FROM PIC_FILE_UPLOAD_KS WHERE ID_UPLOAD = '" + e.Item.Cells[0].Text + "'";
					conn.ExecuteQuery();
					ViewUploadFiles3();
					break;

				
				case "allfac3":
					for (i = 0; i < DATA_EXPORT3.Items.Count; i++)
					{
						try
						{
							CheckBox cb = (CheckBox) DATA_EXPORT3.Items[i].Cells[2].FindControl("chk_3");
							if(cb != null)
							{
								string a = cb.ID.ToString();
								cb.Checked = true;
							}
						} 
						catch(Exception ex) {}
					}
					break;
				default:
					break;
			}
		}

		protected void DELETE_KS_Click(object sender, System.EventArgs e)
		{
			for (int i=0; i<DATA_EXPORT3.Items.Count; i++)
			{
				CheckBox cbf = (CheckBox) DATA_EXPORT3.Items[i].Cells[2].FindControl("chk_3");
				if (cbf.Checked == true)
				{
					conn.QueryString = "DELETE PIC_FILE_UPLOAD_KS where ID_UPLOAD = '" +
						DATA_EXPORT3.Items[i].Cells[0].Text.Trim() + "'";
					conn.ExecuteNonQuery();
				}
			}
			ViewUploadFiles3();
		}

		private void ViewUploadFiles4()
		{
			string url = "";
			conn.QueryString = "SELECT EXPORT_URL FROM PIC_RFEXPORT WHERE EXPORT_ID = '" + "PIC" + "'";
			conn.ExecuteQuery();

			if (conn.GetRowCount() > 0) 
			{
				url = conn.GetFieldValue("EXPORT_URL");
			}

			System.Data.DataTable dt = new System.Data.DataTable();
			conn.QueryString = "SELECT ID_UPLOAD, FILE_UPLOAD_NAME FROM PIC_FILE_UPLOAD_IST where KSEBM ='" +DDL_KSEBM_IST.SelectedValue+ "'";
			conn.ExecuteQuery();
			dt = conn.GetDataTable().Copy();
			DATA_EXPORT4.DataSource = dt;
			try 
			{
				DATA_EXPORT4.DataBind();
			} 
			catch 
			{
				DATA_EXPORT4.CurrentPageIndex = 0;
				DATA_EXPORT4.DataBind();
			}
			for (int i = 1; i <= DATA_EXPORT4.Items.Count; i++)
			{
				LinkButton HpDelete = (LinkButton) DATA_EXPORT4.Items[i-1].Cells[3].FindControl("UPL4_DELETE");
			}
		}

		protected void UPLOAD_IST_Click(object sender, System.EventArgs e)
		{
			string directory;
			int counter = 0;
			int max_id = 10000;
			string outputfilename = "";

			//Get Export Properties
			conn.QueryString = "EXEC PIC_INSERT_FILE_UPLOAD_IST '" + Session["USERID"].ToString() + "','" +
				Path.GetFileName(TXT_FILE_UPLOAD_IST.PostedFile.FileName) + "','"+DDL_KSEBM_IST.SelectedValue+"'";
			conn.ExecuteQuery();

			conn.QueryString = "SELECT MAX(ID_UPLOAD) as MAX_ID from [PIC_FILE_UPLOAD_IST]";
			conn.ExecuteQuery();

			if (conn.GetRowCount() > 0)
			{
				max_id = int.Parse(conn.GetFieldValue("MAX_ID"));
			}

			conn.QueryString = "SELECT FILE_UPLOAD_NAME from [PIC_FILE_UPLOAD_IST] where ID_UPLOAD = '" + max_id + "'";
			conn.ExecuteQuery();

			if (conn.GetRowCount() > 0)
			{
				outputfilename = conn.GetFieldValue("FILE_UPLOAD_NAME");
			}

			conn.QueryString = "SELECT EXPORT_URL FROM PIC_RFEXPORT WHERE EXPORT_ID = 'PIC'";
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

							LBL_STATUS4.ForeColor = Color.Green;
							LBL_STATUSREPORT4.ForeColor = Color.Green;
							LBL_STATUS4.Text = "Upload Successful!";
							LBL_STATUSREPORT4.Text = "<u>File #" + counter.ToString() + "</u><br>" + 
								"File Content Type: " + userPostedFile.ContentType + "<br>" + 
								"File Size: " + userPostedFile.ContentLength + " bytes<br>" + 
								"File Name: " + userPostedFile.FileName + "<br>" +
								"Location Where Saved: " + directory + outputfilename + "<p>";

							ViewUploadFiles4();
						}
					}
					catch (Exception ex)
					{
						LBL_STATUS4.ForeColor = Color.Red;
						LBL_STATUSREPORT4.ForeColor = Color.Red;
						LBL_STATUS4.Text = "Upload Failed!";
						LBL_STATUSREPORT4.Text = ex.Message + "\n" + ex.StackTrace;
					}
				}
			}
			ViewUploadFiles4();
		}

		protected void DDL_KSEBM_IST_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			ViewUploadFiles4();
		}

		private void DATA_EXPORT4_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			int i;
			switch (((LinkButton)e.CommandSource).CommandName)
			{
				case "delete":
					conn.QueryString = "DELETE FROM PIC_FILE_UPLOAD_IST WHERE ID_UPLOAD = '" + e.Item.Cells[0].Text + "'";
					conn.ExecuteQuery();
					ViewUploadFiles4();
					break;

				
				case "allfac4":
					for (i = 0; i < DATA_EXPORT4.Items.Count; i++)
					{
						try
						{
							CheckBox cb = (CheckBox) DATA_EXPORT4.Items[i].Cells[2].FindControl("chk_4");
							if(cb != null)
							{
								string a = cb.ID.ToString();
								cb.Checked = true;
							}
						} 
						catch(Exception ex) {}
					}
					break;
				default:
					break;
			}
		}

		protected void DELETE_IST_Click(object sender, System.EventArgs e)
		{
			for (int i=0; i<DATA_EXPORT4.Items.Count; i++)
			{
				CheckBox cbf = (CheckBox) DATA_EXPORT4.Items[i].Cells[2].FindControl("chk_4");
				if (cbf.Checked == true)
				{
					conn.QueryString = "DELETE PIC_FILE_UPLOAD_IST where ID_UPLOAD = '" +
						DATA_EXPORT4.Items[i].Cells[0].Text.Trim() + "'";
					conn.ExecuteNonQuery();
				}
			}
			ViewUploadFiles4();
		}

		private void ViewUploadFiles5()
		{
			string url = "";
			conn.QueryString = "SELECT EXPORT_URL FROM PIC_RFEXPORT WHERE EXPORT_ID = '" + "PIC" + "'";
			conn.ExecuteQuery();

			if (conn.GetRowCount() > 0) 
			{
				url = conn.GetFieldValue("EXPORT_URL");
			}

			System.Data.DataTable dt = new System.Data.DataTable();
			conn.QueryString = "SELECT ID_UPLOAD, FILE_UPLOAD_NAME FROM PIC_FILE_UPLOAD_HST where KSEBM ='" +DDL_KSEBM_HST.SelectedValue+ "'";
			conn.ExecuteQuery();
			dt = conn.GetDataTable().Copy();
			DATA_EXPORT5.DataSource = dt;
			try 
			{
				DATA_EXPORT5.DataBind();
			} 
			catch 
			{
				DATA_EXPORT5.CurrentPageIndex = 0;
				DATA_EXPORT5.DataBind();
			}
			for (int i = 1; i <= DATA_EXPORT5.Items.Count; i++)
			{
				LinkButton HpDelete = (LinkButton) DATA_EXPORT5.Items[i-1].Cells[3].FindControl("UPL5_DELETE");
			}
		}

		protected void UPLOAD_HST_Click(object sender, System.EventArgs e)
		{
			string directory;
			int counter = 0;
			int max_id = 10000;
			string outputfilename = "";

			//Get Export Properties
			conn.QueryString = "EXEC PIC_INSERT_FILE_UPLOAD_HST '" + Session["USERID"].ToString() + "','" +
				Path.GetFileName(TXT_FILE_UPLOAD_HST.PostedFile.FileName) + "','"+DDL_KSEBM_HST.SelectedValue+"'";
			conn.ExecuteQuery();

			conn.QueryString = "SELECT MAX(ID_UPLOAD) as MAX_ID from [PIC_FILE_UPLOAD_HST]";
			conn.ExecuteQuery();

			if (conn.GetRowCount() > 0)
			{
				max_id = int.Parse(conn.GetFieldValue("MAX_ID"));
			}

			conn.QueryString = "SELECT FILE_UPLOAD_NAME from [PIC_FILE_UPLOAD_HST] where ID_UPLOAD = '" + max_id + "'";
			conn.ExecuteQuery();

			if (conn.GetRowCount() > 0)
			{
				outputfilename = conn.GetFieldValue("FILE_UPLOAD_NAME");
			}

			conn.QueryString = "SELECT EXPORT_URL FROM PIC_RFEXPORT WHERE EXPORT_ID = 'PIC'";
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

							LBL_STATUS5.ForeColor = Color.Green;
							LBL_STATUSREPORT5.ForeColor = Color.Green;
							LBL_STATUS5.Text = "Upload Successful!";
							LBL_STATUSREPORT5.Text = "<u>File #" + counter.ToString() + "</u><br>" + 
								"File Content Type: " + userPostedFile.ContentType + "<br>" + 
								"File Size: " + userPostedFile.ContentLength + " bytes<br>" + 
								"File Name: " + userPostedFile.FileName + "<br>" +
								"Location Where Saved: " + directory + outputfilename + "<p>";

							ViewUploadFiles5();
						}
					}
					catch (Exception ex)
					{
						LBL_STATUS5.ForeColor = Color.Red;
						LBL_STATUSREPORT5.ForeColor = Color.Red;
						LBL_STATUS5.Text = "Upload Failed!";
						LBL_STATUSREPORT5.Text = ex.Message + "\n" + ex.StackTrace;
					}
				}
			}
			ViewUploadFiles5();
		}

		protected void DDL_KSEBM_HST_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			ViewUploadFiles5();
		}

		private void DATA_EXPORT5_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			int i;
			switch (((LinkButton)e.CommandSource).CommandName)
			{
				case "delete":
					conn.QueryString = "DELETE FROM PIC_FILE_UPLOAD_HST WHERE ID_UPLOAD = '" + e.Item.Cells[0].Text + "'";
					conn.ExecuteQuery();
					ViewUploadFiles5();
					break;

				
				case "allfac5":
					for (i = 0; i < DATA_EXPORT5.Items.Count; i++)
					{
						try
						{
							CheckBox cb = (CheckBox) DATA_EXPORT5.Items[i].Cells[2].FindControl("chk_5");
							if(cb != null)
							{
								string a = cb.ID.ToString();
								cb.Checked = true;
							}
						} 
						catch(Exception ex) {}
					}
					break;
				default:
					break;
			}
		}

		protected void DELETE_HST_Click(object sender, System.EventArgs e)
		{
			for (int i=0; i<DATA_EXPORT5.Items.Count; i++)
			{
				CheckBox cbf = (CheckBox) DATA_EXPORT5.Items[i].Cells[2].FindControl("chk_5");
				if (cbf.Checked == true)
				{
					conn.QueryString = "DELETE PIC_FILE_UPLOAD_HST where ID_UPLOAD = '" +
						DATA_EXPORT5.Items[i].Cells[0].Text.Trim() + "'";
					conn.ExecuteNonQuery();
				}
			}
			ViewUploadFiles5();
		}

		private void ViewUploadFiles6()
		{
			string url = "";
			conn.QueryString = "SELECT EXPORT_URL FROM PIC_RFEXPORT WHERE EXPORT_ID = '" + "PIC" + "'";
			conn.ExecuteQuery();

			if (conn.GetRowCount() > 0) 
			{
				url = conn.GetFieldValue("EXPORT_URL");
			}

			System.Data.DataTable dt = new System.Data.DataTable();
			conn.QueryString = "SELECT ID_UPLOAD, FILE_UPLOAD_NAME FROM PIC_FILE_UPLOAD_BS where KSEBM ='" +DDL_KSEBM_BS.SelectedValue+ "'";
			conn.ExecuteQuery();
			dt = conn.GetDataTable().Copy();
			DATA_EXPORT6.DataSource = dt;
			try 
			{
				DATA_EXPORT6.DataBind();
			} 
			catch 
			{
				DATA_EXPORT6.CurrentPageIndex = 0;
				DATA_EXPORT6.DataBind();
			}
			for (int i = 1; i <= DATA_EXPORT6.Items.Count; i++)
			{
				LinkButton HpDelete = (LinkButton) DATA_EXPORT6.Items[i-1].Cells[3].FindControl("UPL6_DELETE");
			}
		}

		protected void UPLOAD_BS_Click(object sender, System.EventArgs e)
		{
			string directory;
			int counter = 0;
			int max_id = 10000;
			string outputfilename = "";

			//Get Export Properties
			conn.QueryString = "EXEC PIC_INSERT_FILE_UPLOAD_BS '" + Session["USERID"].ToString() + "','" +
				Path.GetFileName(TXT_FILE_UPLOAD_BS.PostedFile.FileName) + "','"+DDL_KSEBM_BS.SelectedValue+"'";
			conn.ExecuteQuery();

			conn.QueryString = "SELECT MAX(ID_UPLOAD) as MAX_ID from [PIC_FILE_UPLOAD_BS]";
			conn.ExecuteQuery();

			if (conn.GetRowCount() > 0)
			{
				max_id = int.Parse(conn.GetFieldValue("MAX_ID"));
			}

			conn.QueryString = "SELECT FILE_UPLOAD_NAME from [PIC_FILE_UPLOAD_BS] where ID_UPLOAD = '" + max_id + "'";
			conn.ExecuteQuery();

			if (conn.GetRowCount() > 0)
			{
				outputfilename = conn.GetFieldValue("FILE_UPLOAD_NAME");
			}

			conn.QueryString = "SELECT EXPORT_URL FROM PIC_RFEXPORT WHERE EXPORT_ID = 'PIC'";
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

							LBL_STATUS6.ForeColor = Color.Green;
							LBL_STATUSREPORT6.ForeColor = Color.Green;
							LBL_STATUS6.Text = "Upload Successful!";
							LBL_STATUSREPORT6.Text = "<u>File #" + counter.ToString() + "</u><br>" + 
								"File Content Type: " + userPostedFile.ContentType + "<br>" + 
								"File Size: " + userPostedFile.ContentLength + " bytes<br>" + 
								"File Name: " + userPostedFile.FileName + "<br>" +
								"Location Where Saved: " + directory + outputfilename + "<p>";

							ViewUploadFiles6();
						}
					}
					catch (Exception ex)
					{
						LBL_STATUS6.ForeColor = Color.Red;
						LBL_STATUSREPORT6.ForeColor = Color.Red;
						LBL_STATUS6.Text = "Upload Failed!";
						LBL_STATUSREPORT6.Text = ex.Message + "\n" + ex.StackTrace;
					}
				}
			}
			ViewUploadFiles6();
		}

		protected void DDL_KSEBM_BS_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			ViewUploadFiles6();
		}

		private void DATA_EXPORT6_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			int i;
			switch (((LinkButton)e.CommandSource).CommandName)
			{
				case "delete":
					conn.QueryString = "DELETE FROM PIC_FILE_UPLOAD_BS WHERE ID_UPLOAD = '" + e.Item.Cells[0].Text + "'";
					conn.ExecuteQuery();
					ViewUploadFiles6();
					break;

				
				case "allfac6":
					for (i = 0; i < DATA_EXPORT6.Items.Count; i++)
					{
						try
						{
							CheckBox cb = (CheckBox) DATA_EXPORT6.Items[i].Cells[2].FindControl("chk_6");
							if(cb != null)
							{
								string a = cb.ID.ToString();
								cb.Checked = true;
							}
						} 
						catch(Exception ex) {}
					}
					break;
				default:
					break;
			}
		}

		protected void DELETE_BS_Click(object sender, System.EventArgs e)
		{
			for (int i=0; i<DATA_EXPORT6.Items.Count; i++)
			{
				CheckBox cbf = (CheckBox) DATA_EXPORT6.Items[i].Cells[2].FindControl("chk_6");
				if (cbf.Checked == true)
				{
					conn.QueryString = "DELETE PIC_FILE_UPLOAD_BS where ID_UPLOAD = '" +
						DATA_EXPORT6.Items[i].Cells[0].Text.Trim() + "'";
					conn.ExecuteNonQuery();
				}
			}
			ViewUploadFiles6();
		}
	}

	}
