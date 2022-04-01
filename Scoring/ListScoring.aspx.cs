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

namespace SME.Scoring
{
	/// <summary>
	/// Summary description for ListSPPK.
	/// 
	/// TODO : MaxLength dan Validasi di scoring sepertinya belum ... :(
	/// 
	/// </summary>
	public partial class ListScoring : System.Web.UI.Page
	{
		protected Connection conn;
		protected Tools tool = new Tools();
		protected DataTable dtapp;

		protected void Page_Load(object sender, System.EventArgs e)
		{
			conn = (Connection) Session["Connection"];

//			if (!Logic.AllowAccess(Session["GroupID"].ToString(), Request.QueryString["mc"], conn))
//				Response.Redirect("/SME/Restricted.aspx");

			this.fetchAppWithScoring();

			if (!IsPostBack)
			{
				// Munculkan pesan next step
				if (Request.QueryString["msg"] != "" && Request.QueryString["msg"] != null) 
					GlobalTools.popMessage(this, Request.QueryString["msg"]);


				Tools.initDateForm(txt_Date, ddl_Month, txt_Year, true);
				txt_Date.Text = "";
				txt_Year.Text = "";
				Tools.initDateForm(txt_Date1, ddl_Month1, txt_Year1, true);
				txt_Date1.Text = "";
				txt_Year1.Text = "";

				DataTable DTBO = new DataTable();
				this.dgListScoring.DataSource = new DataView(DTBO);
				this.dgListScoring.DataBind();

				this.getParams();
				viewAllData(); //menampilkan semua data

				// Munculkan pesan next step GATOT - AGUS
				if (Request.QueryString["msg"] != "" && Request.QueryString["msg"]!= null)  
				{
					GlobalTools.popMessage(this, Request.QueryString["msg"]);
				}
			}			
		}

		private void getParams() 
		{
			if (Request.QueryString["tc"] == null) 
			{
				this.LBL_TC.Text = (string) Session["tc"];
				this.LBL_MC.Text = (string) Session["mc"];
				Session.Remove("tc");
				Session.Remove("mc");
			}
			else
			{
				this.LBL_TC.Text = Request.QueryString["tc"];				
				this.LBL_MC.Text = Request.QueryString["mc"];
			}
		}

		private void fetchAppWithScoring() 
		{
			//--------------------------------------------------------------
			this.dtapp = new DataTable();
			conn.QueryString = "select " +
				"distinct(rfscoringtype.scr_link), " +
				"application.ap_regno " +
				"from  " +
				"application ,rfprogram, rfscoringtype " +
				"where " +
				"application.prog_code = rfprogram.programid and " +
				"rfprogram.scrid = rfscoringtype.scrid and " +
				"rfprogram.scrid <> '0' " +
				"order by " +
				"ap_regno, scr_link";
			conn.ExecuteQuery();
			this.dtapp = conn.GetDataTable();
			//----------------------------------------------------------------
		}

		private void viewAllData()
		{
			DataTable DTBO = new DataTable();
			DataRow datrow;

			DTBO.Columns.Add(new DataColumn("AP_REGNO"));
			DTBO.Columns.Add(new DataColumn("CU_REF"));
			DTBO.Columns.Add(new DataColumn("Name"));			
			DTBO.Columns.Add(new DataColumn("SU_FULLNAME"));
			DTBO.Columns.Add(new DataColumn("AP_SIGNDATE"));
			DTBO.Columns.Add(new DataColumn("LIMITEXPOSURE"));			
			DTBO.Columns.Add(new DataColumn("SCR_LINK"));			
			DTBO.Columns.Add(new DataColumn("AP_CA"));

			conn.QueryString = "SELECT ap_regno, cu_ref, name, su_fullname, ap_signdate, ap_ca FROM VW_LISTCUSTOMER_PERSONAL where AP_CURRTRACK='" + this.LBL_TC.Text + "' and ap_ca = '" + Session["UserID"].ToString() + "' ";
			conn.QueryString += "UNION SELECT ap_regno, cu_ref, cu_compname as name, su_fullname, ap_signdate, ap_ca FROM VW_LISTCUSTOMER_COMPANY where  AP_CURRTRACK='" + this.LBL_TC.Text + "' and ap_ca = '" + Session["UserID"].ToString() + "'";
			
			try 
			{
				conn.ExecuteQuery();
			} 
			catch (NullReferenceException ex) 
			{
				GlobalTools.popMessage(this, "Connection Error !");
				return;
			}

			for (int i =0; i < conn.GetRowCount(); i++) 
			{
				bool lanjut = false;
				string scr_link = "";
				//---- sebelum tampilkan, cek dulu apakah application termasuk No_Scoring ? ------
				for (int j = 0; j < this.dtapp.Rows.Count; j++) 
				{
					if (conn.GetFieldValue(i,0).ToString().Trim() == this.dtapp.Rows[j][1].ToString()) 
					{
						lanjut = true;
						scr_link = this.dtapp.Rows[j][0].ToString();
						break;
					}
				}					
				//--------------------------------------------------------------------------------

				if (lanjut) 
				{
					datrow = DTBO.NewRow();
					datrow[0] = conn.GetFieldValue(i,0);
					datrow[1] = conn.GetFieldValue(i,1);
					datrow[2] = "&nbsp;&nbsp;" + conn.GetFieldValue(i,2);
					datrow[3] = conn.GetFieldValue(i,3);
					datrow[4] = tool.FormatDate(conn.GetFieldValue(i,4));
					datrow[6] = scr_link;
					datrow[7] = conn.GetFieldValue(i,5);
					DTBO.Rows.Add(datrow);
				}
			}

			this.dgListScoring.DataSource = new DataView(DTBO);
			try 
			{
				this.dgListScoring.DataBind();
			} 
			catch 
			{
				Tools.popMessage(this, "DataGrid Error !");
				return;
			}
		}

		private void bindData()
		{	
			DataTable DTBO = new DataTable();
			DataRow datrow;

			string sjoin = "";
			string sqlCondPersonal = "";
			string sqlCondCompany = "";

			try 
			{
				//Customer Personal
				sqlCondPersonal = "WHERE("; 
				sjoin = RDB_COND.SelectedValue;
				if (txt_IdCard.Text.Trim() != "")
					sqlCondPersonal = sqlCondPersonal + " CU_IDCARDNUM like '%" + txt_IdCard.Text + "%' " + sjoin;
				if (txt_NPWP.Text.Trim() != "")
					sqlCondPersonal = sqlCondPersonal + " CU_NPWP like '%" + txt_NPWP.Text + "%' " + sjoin;
				if (txt_Name.Text.Trim() != "")
					sqlCondPersonal = sqlCondPersonal + " NAME like '%" + txt_Name.Text + "%' " + sjoin;
				if (txt_ProsID.Text.Trim() != "")
					sqlCondPersonal = sqlCondPersonal + " AP_REGNO like '%" + txt_ProsID.Text + "%' " + sjoin;
				if ( ((txt_Date.Text.Trim() != "") && (txt_Year.Text.Trim() != "")) && ((txt_Date1.Text.Trim() != "") && (txt_Year1.Text.Trim() != "")) )
					sqlCondPersonal = sqlCondPersonal + " AP_RECVDATE BETWEEN '" + Tools.toSQLDate(txt_Date, ddl_Month, txt_Year) + "' and '"+ Tools.toSQLDate(txt_Date1, ddl_Month1, txt_Year1) +"' " + sjoin;
				if (sqlCondPersonal == "WHERE(") 
					sqlCondPersonal = "";
				else
				{
					sqlCondPersonal = sqlCondPersonal.Substring(0, sqlCondPersonal.Length - sjoin.Length);
					sqlCondPersonal = sqlCondPersonal + ")";
				}
			} 
			catch (ApplicationException ex) 
			{
				Tools.popMessage(this, "Input tidak valid !");
				return;
			}
			catch (FormatException ex) 
			{
				Tools.popMessage(this, "Input tidak valid !");
				return;
			}
			catch (Exception ex) 
			{
				Tools.popMessage(this, "Unknown Error !");
				return;
			}

			try 
			{
				//Customer Company
				sqlCondCompany = "WHERE(";
				if (txt_NPWP.Text.Trim() != "")
					sqlCondCompany = sqlCondCompany + " CU_COMPNPWP like '%" + txt_NPWP.Text + "%' " + sjoin;
				if (txt_Name.Text.Trim() != "")
					sqlCondCompany = sqlCondCompany + " CU_COMPNAME like '%" + txt_Name.Text + "%' " + sjoin;
				if (txt_ProsID.Text.Trim() != "")
					sqlCondCompany = sqlCondCompany + " AP_REGNO like '%" + txt_ProsID.Text + "%' " + sjoin;
				if ( ((txt_Date.Text.Trim() != "") && (txt_Year.Text.Trim() != "")) && ((txt_Date1.Text.Trim() != "") && (txt_Year1.Text.Trim() != "")) )
					sqlCondCompany = sqlCondCompany + " AP_RECVDATE BETWEEN '" + Tools.toSQLDate(txt_Date, ddl_Month, txt_Year) + "' and '"+ Tools.toSQLDate(txt_Date1, ddl_Month1, txt_Year1) +"' " + sjoin;
				if (sqlCondCompany == "WHERE(") 
					sqlCondCompany = "";
				else
				{
					sqlCondCompany = sqlCondCompany.Substring(0, sqlCondCompany.Length - sjoin.Length);
					sqlCondCompany = sqlCondCompany + ")";
				}
			} 
			catch (ApplicationException ex) 
			{
				Tools.popMessage(this, "Input tidak valid !");
				return;
			}
			catch (FormatException ex) 
			{
				Tools.popMessage(this, "Input tidak valid !");
				return;
			}
			catch (Exception ex) 
			{
				Tools.popMessage(this, "Unknown Error !");
				return;
			}

			DTBO.Columns.Add(new DataColumn("AP_REGNO"));
			DTBO.Columns.Add(new DataColumn("CU_REF"));
			DTBO.Columns.Add(new DataColumn("Name"));			
			DTBO.Columns.Add(new DataColumn("SU_FULLNAME"));
			DTBO.Columns.Add(new DataColumn("AP_SIGNDATE"));
			DTBO.Columns.Add(new DataColumn("LIMITEXPOSURE"));			
			DTBO.Columns.Add(new DataColumn("SCR_LINK"));			
			DTBO.Columns.Add(new DataColumn("AP_CA"));

			if (sqlCondPersonal != "")
			{
				//conn.QueryString = "SELECT * FROM VW_LISTCUSTOMER_PERSONAL " + sqlCondPersonal + " and ap_currtrack='" + Request.QueryString["tc"] + "'"; // and branch_code='" + Session["BranchID"].ToString() + "'";
				conn.QueryString = "SELECT * FROM VW_LISTCUSTOMER_PERSONAL " + sqlCondPersonal + " and ap_currtrack='" + this.LBL_TC.Text + "' and (ap_ca = '" + Session["UserID"].ToString() + "' or ap_ca is null)"; // and branch_code='" + Session["BranchID"].ToString() + "'";
				//Response.Write(conn.QueryString);
				try 
				{
					conn.ExecuteQuery();
				} 
				catch (ApplicationException ex) 
				{
					Tools.popMessage(this, "Input tidak valid !");
					return;
				}
				catch (NullReferenceException ex) 
				{
					Tools.popMessage(this, "Server Error !");
					return;
				}

				for (int i =0; i < conn.GetRowCount(); i++) 
				{
					bool lanjut = false;
					string scr_link = "";
					//---- sebelum tampilkan, cek dulu apakah application termasuk No_Scoring ? ------
					for (int j = 0; j < this.dtapp.Rows.Count; j++) 
					{
						if (conn.GetFieldValue(i,0).ToString().Trim() == this.dtapp.Rows[j][1].ToString()) 
						{
							lanjut = true;
							scr_link = this.dtapp.Rows[j][0].ToString();
							break;
						}
					}					
					//--------------------------------------------------------------------------------
					if (lanjut) {
						datrow = DTBO.NewRow();
						datrow[0] = conn.GetFieldValue(i,0);
						datrow[1] = conn.GetFieldValue(i,1);
						datrow[2] = "&nbsp;&nbsp;" + conn.GetFieldValue(i,2);
						datrow[3] = conn.GetFieldValue(i,5);
						datrow[4] = tool.FormatDate(conn.GetFieldValue(i,3));
						datrow[6] = scr_link;
						datrow[7] = conn.GetFieldValue(i,13);
					
						DTBO.Rows.Add(datrow);
					}
				}
			}
			if (sqlCondCompany != "")
			{
				//conn.QueryString = "SELECT * FROM VW_LISTCUSTOMER_COMPANY " + sqlCondCompany + " and ap_currtrack='" + Request.QueryString["tc"] + "'"; // and branch_code='" + Session["BranchID"].ToString() + "'";
				conn.QueryString = "SELECT * FROM VW_LISTCUSTOMER_COMPANY " + sqlCondCompany + " and ap_currtrack='" + this.LBL_TC.Text + "' and (ap_ca = '" + Session["UserID"].ToString() + "' or ap_ca is null)"; 
				conn.ExecuteQuery();
				//Response.Write(conn.QueryString);
				for (int i =0; i < conn.GetRowCount(); i++) 
				{
					bool lanjut = false;
					string scr_link = "";
					//---- sebelum tampilkan, cek dulu apakah application termasuk No_Scoring ? ------
					for (int j = 0; j < this.dtapp.Rows.Count; j++) 
					{
						if (conn.GetFieldValue(i,0).ToString().Trim() == this.dtapp.Rows[j][1].ToString()) 
						{
							lanjut = true;
							scr_link = this.dtapp.Rows[j][0].ToString();
							break;
						}
					}					
					//--------------------------------------------------------------------------------
					if (lanjut) 
					{
						datrow = DTBO.NewRow();
						datrow[0] = conn.GetFieldValue(i,0);
						datrow[1] = conn.GetFieldValue(i,1);
						datrow[2] = "&nbsp;&nbsp;" + conn.GetFieldValue(i,2);
						datrow[3] = conn.GetFieldValue(i,5);
						datrow[4] = tool.FormatDate(conn.GetFieldValue(i,3));
						datrow[6] = scr_link;
						datrow[7] = conn.GetFieldValue(i, 12);
					
						DTBO.Rows.Add(datrow);
					}
				}
			}
			this.dgListScoring.DataSource = new DataView(DTBO);
			try 
			{
				this.dgListScoring.DataBind();
			} 
			catch 
			{
				Tools.popMessage(this, "DataGrid Error !");
				return;
			}


			//---TODO : hilangkan hardcode dibawah !!
//			DTBO.Columns.Add(new DataColumn("AP_REGNO"));
//			DTBO.Columns.Add(new DataColumn("CU_REF"));
//			DTBO.Columns.Add(new DataColumn("Name"));			
//			DTBO.Columns.Add(new DataColumn("SU_FULLNAME"));
//			DTBO.Columns.Add(new DataColumn("AP_SIGNDATE"));
//			DTBO.Columns.Add(new DataColumn("LIMITEXPOSURE"));			
//			DTBO.Columns.Add(new DataColumn("SCR_LINK"));			
//			DTBO.Columns.Add(new DataColumn("AP_CA"));

			//---Test CRSS
			/*DataRow dr = DTBO.NewRow();
			dr = DTBO.NewRow();
			dr[0] = "";
			dr[1] = "";
			dr[2] = "&nbsp;&nbsp;Coba-coba CRSS";
			dr[3] = "SBO";
			dr[4] = "";
			dr[6] = "/SME/Scoring/CRSS.aspx?";					
			dr[7] = "";
			DTBO.Rows.Add(dr);

			//---Test BCG
			dr = DTBO.NewRow();
			dr = DTBO.NewRow();
			dr[0] = "";
			dr[1] = "";
			dr[2] = "&nbsp;&nbsp;Testing BCG";
			dr[3] = "SBO";
			dr[4] = "";
			dr[6] = "/SME/Scoring/BCG.aspx?";					
			dr[7] = "";
			DTBO.Rows.Add(dr);

			dr = DTBO.NewRow();
			dr = DTBO.NewRow();
			dr[0] = "";
			dr[1] = "";
			dr[2] = "&nbsp;&nbsp;Test BPR";
			dr[3] = "SBO";
			dr[4] = "";
			dr[6] = "/SME/Scoring/FIRSS_BPR.aspx?";					
			dr[7] = "";
			DTBO.Rows.Add(dr);

			this.dgListScoring.DataSource = new DataView(DTBO);
			try 
			{
				this.dgListScoring.DataBind();
			} 
			catch 
			{
				Tools.popMessage(this, "DataGrid Error !");
				return;
			}*/
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
			this.dgListScoring.ItemCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.dgListScoring_ItemCommand);

		}
		#endregion

		private void dgListScoring_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			switch(((LinkButton)e.CommandSource).CommandName)
			{
				case "VIEW":								
					/*
					string tc = Request.QueryString["tc"];					
					string mc = Request.QueryString["mc"];					
					*/
					string tc = this.LBL_TC.Text;
					string mc = this.LBL_MC.Text;

					if (e.Item.Cells[8].Text == "&nbsp;")
					{
						conn.QueryString = "update application set ap_ca='" + Session["UserID"].ToString() + "' where ap_regno='" + e.Item.Cells[0].Text + "'";
						conn.ExecuteNonQuery();
					}
					Response.Redirect(e.Item.Cells[7].Text+"regno="+e.Item.Cells[0].Text+"&curef="+e.Item.Cells[1].Text + "&mc=" + mc + "&tc=" + tc);

					/*
					double limitExposure = 0;
					try 
					{
						limitExposure = Convert.ToDouble(e.Item.Cells[6].Text);
					}
					catch (Exception ex) 
					{
						string temp = ex.ToString();
					}
					conn.QueryString = "select * from RFSCORINGTYPE";
					conn.ExecuteQuery();

					double min, max;
					for(int i = 0; i < conn.GetRowCount(); i++) 
					{
						min = Convert.ToDouble(conn.GetDataTable().Rows[i]["SCR_MIN"]);
						max = Convert.ToDouble(conn.GetDataTable().Rows[i]["SCR_MAX"]);
						if (limitExposure >= min && limitExposure < max) 
						{
							Response.Redirect(conn.GetDataTable().Rows[i]["SCR_LINK"].ToString()+"regno="+e.Item.Cells[0].Text+"&curef="+e.Item.Cells[1].Text + "&mc=" + mc + "&tc=" + tc);
						}
					}
					*/

					break;

				default:
					break;
			}
		}

		protected void btn_cari_Click(object sender, System.EventArgs e)
		{
			//ViewData("1");			
		}

		protected void btn_Find_Click(object sender, System.EventArgs e)
		{
			this.bindData();
		}
	}
}
