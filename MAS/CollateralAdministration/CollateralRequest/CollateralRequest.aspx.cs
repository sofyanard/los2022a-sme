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

namespace SME.MAS.CollateralAdministration.CollateralRequest
{
	/// <summary>
	/// Summary description for CollateralRequest.
	/// </summary>
	public partial class CollateralRequest : System.Web.UI.Page
	{
		protected Tools tool = new Tools();
		protected Connection conn = new Connection(ConfigurationSettings.AppSettings["conn"]);
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			if(!IsPostBack)
			{
				conn.QueryString = "select acc_number, collateral_id, cluster_code, distrik_code, unit_code from mas_collateral where ACC_NUMBER ='" +Request.QueryString["acc_number"]+ "' and collateral_id = '" +Request.QueryString["collateral_id"]+ "' ";
				conn.ExecuteQuery();
				LBL_DISTRIK.Text = conn.GetFieldValue("distrik_code");
				LBL_CLUSTER.Text = conn.GetFieldValue("cluster_code");

				DDL_REASON.Items.Add(new ListItem("--Pilih--",""));
				DDL_CA_NAME.Items.Add(new ListItem("--Pilih--",""));
				conn.QueryString = "select * from MAS_RF_REQUEST_REASON where status='1'";
				conn.ExecuteQuery();
				for (int i = 0; i < conn.GetRowCount(); i++)
					DDL_REASON.Items.Add(new ListItem(conn.GetFieldValue(i,1),conn.GetFieldValue(i,0)));

				//conn.QueryString = "select userid, su_fullname from scuser where groupid='84' and su_active='1'";
				conn.QueryString = "select userid, su_fullname from scuser where su_active='1' and groupid='84' and " +
					"su_branch=(select su_branch from scuser where userid = '"+ Session["UserID"].ToString() +"')" ;
				conn.ExecuteQuery();
				for (int i = 0; i < conn.GetRowCount(); i++)
					DDL_CA_NAME.Items.Add(new ListItem(conn.GetFieldValue(i,1),conn.GetFieldValue(i,0)));

				DDL_BLN_KIRIM.Items.Add(new ListItem("--Pilih--",""));
				for (int i=1; i<=12; i++)
				{				
					DDL_BLN_KIRIM.Items.Add(new ListItem(DateAndTime.MonthName(i, false), i.ToString()));				
				}

				ViewData();
				BTN_FINISH.Enabled = true;
				BTN_FINISH.Attributes.Add("OnClick","return confirm('Apakah Anda yakin sudah selesai pengisian datanya?')");

				ddl_process1.Items.Clear();	
				ddl_process1.Items.Add(new ListItem("- PILIH -", ""));
				ddl_process1.Items.Add(new ListItem("Simpan Data", "1"));
				ddl_process1.Items.Add(new ListItem("Simpan Dokumen di Unit", "2"));
				ddl_process1.Items.Add(new ListItem("Kirim ke CA", "3"));
				ddl_process1.Items.Add(new ListItem("Reset", "4"));
			}

				ViewScreenMenu();
			}

			private void ViewScreenMenu()
			{
				//conn.QueryString = "select coltypeid from rfcollateraltype where coltypeseq='"+ Request.QueryString["type"] + "'" ;
				conn.QueryString = "select collateral_type from mas_collateral where ACC_NUMBER ='" +Request.QueryString["acc_number"]+ "' and collateral_id = '" +Request.QueryString["collateral_id"]+ "' ";
				conn.ExecuteQuery();	

				string a,b;
				a="";
				b="";
				a=conn.GetFieldValue("collateral_type");

				if (conn.GetFieldValue("collateral_type")=="1")
				{
					b="Collateral_Re";
				}

				else if (conn.GetFieldValue("collateral_type")=="2")
				{
					b="Collateral_Veh";
				}


				HyperLink h2 = new HyperLink();
				h2.Text = "Data Agunan";
				h2.Font.Bold = true;
				//h2.NavigateUrl = "../DetailCollateral/Collateral_" + conn.GetFieldValue("coltypeid") + ".aspx?acc_number="+Request.QueryString["acc_number"]+"&collateral_id="+Request.QueryString["collateral_id"]+"&de=1&sta=view" + "&tc=" + Request.QueryString["tc"] + "&mc=" + Request.QueryString["mc"] + "&acc_status=" + Request.QueryString["acc_status"];
				h2.NavigateUrl = "../DetailCollateral/" + b + ".aspx?acc_number="+Request.QueryString["acc_number"]+"&collateral_id="+Request.QueryString["collateral_id"]+"&de=1&sta=view" + "&tc=" + Request.QueryString["tc"] + "&mc=" + Request.QueryString["mc"] + "&acc_status=" + Request.QueryString["acc_status"];
				h2.Target="scol";

				HyperLink h3 = new HyperLink();
				h3.Text = "Dokumen Kredit";
				h3.Font.Bold = true;
				string aaa="../DetailCollateral/DokumenKredit.aspx?acc_number="+Request.QueryString["acc_number"]+"&collateral_id="+Request.QueryString["collateral_id"]+"&de=1&sta=view" + "&tc=" + Request.QueryString["tc"] + "&mc=" + Request.QueryString["mc"] + "&kredit=1";
				h3.NavigateUrl=aaa;
				h3.Target="scol";

				HyperLink h4 = new HyperLink();
				h4.Text = "Dokumen Pendukung Agunan";
				h4.Font.Bold = true;
				string aaa1="../DetailCollateral/DokumenKredit.aspx?acc_number="+Request.QueryString["acc_number"]+"&collateral_id="+Request.QueryString["collateral_id"]+"&de=1&sta=view" + "&tc=" + Request.QueryString["tc"] + "&mc=" + Request.QueryString["mc"] + "&kredit=0";
				h4.NavigateUrl=aaa1;
				h4.Target="scol";

				PH_SUBMENU.Controls.Add(h2);
				PH_SUBMENU.Controls.Add(new LiteralControl("&nbsp;&nbsp;"));
				PH_SUBMENU.Controls.Add(h4);
				PH_SUBMENU.Controls.Add(new LiteralControl("&nbsp;&nbsp;"));
				PH_SUBMENU.Controls.Add(h3);
				PH_SUBMENU.Controls.Add(new LiteralControl("&nbsp;&nbsp;"));
			}

		private void ViewData()
		{	
			if (Request.QueryString["tc"]=="M1.5")
			{
				conn.QueryString = "select * from VW_MAS_COLLATERAL_DATA WHERE ACC_NUMBER ='" +Request.QueryString["acc_number"]+ "' and collateral_id = '" +Request.QueryString["collateral_id"]+ "'  ";
				conn.ExecuteQuery();
				if (conn.GetRowCount()==0)
				{
					conn.QueryString = "select * from MAS_UPLOAD_DATA WHERE ACC_NUMBER ='" +Request.QueryString["acc_number"]+ "' and collateral_id = '" +Request.QueryString["collateral_id"]+ "' ";
					conn.ExecuteQuery();
					TXT_ACC_NUMBER.Text = conn.GetFieldValue("acc_number");
					TXT_ACC_STATUS.Text = conn.GetFieldValue("acc_status");
					TXT_CUST_NAME.Text = conn.GetFieldValue("cust_name");
					TXT_DISTRIK_CODE.Text = conn.GetFieldValue("distrik_code");
					TXT_CLUSTER_CODE.Text = conn.GetFieldValue("cluster_code");
					TXT_UNIT_CODE.Text = conn.GetFieldValue("unit_code");
				}
				else
				{
					conn.QueryString = "select * from VW_MAS_COLLATERAL_DATA WHERE ACC_NUMBER ='" +Request.QueryString["acc_number"]+ "' and collateral_id = '" +Request.QueryString["collateral_id"]+ "'  ";
					conn.ExecuteQuery();
					TXT_ACC_NUMBER.Text = conn.GetFieldValue("acc_number");
					TXT_ACC_STATUS.Text = conn.GetFieldValue("acc_status");
					TXT_CUST_NAME.Text = conn.GetFieldValue("cust_name");
					TXT_DISTRIK_CODE.Text = conn.GetFieldValue("distrik_code");
					TXT_CLUSTER_CODE.Text = conn.GetFieldValue("cluster_code");
					TXT_UNIT_CODE.Text = conn.GetFieldValue("buc");
				}						

				conn.QueryString = "select * from VW_MAS_COLLATERAL_DATA WHERE ACC_NUMBER ='" +Request.QueryString["acc_number"]+ "' and collateral_id = '" +Request.QueryString["collateral_id"]+ "'  ";
				conn.ExecuteQuery();
			
				TXT_AGUNAN_NM.Text = conn.GetFieldValue("agunan_name");
				TXT_BAST_DR_CA.Text = conn.GetFieldValue("bast_dari_ca");
				TXT_TGL_KIRIM.Text = tool.FormatDate_Day(conn.GetFieldValue("SEND_CA_DATE"));
				try{DDL_BLN_KIRIM.SelectedValue = tool.FormatDate_Month(conn.GetFieldValue("SEND_CA_DATE"));}
				catch{DDL_BLN_KIRIM.SelectedValue = "";}
				TXT_THN_KIRIM.Text = tool.FormatDate_Year(conn.GetFieldValue("SEND_CA_DATE"));
				try{DDL_REASON.SelectedValue = conn.GetFieldValue("request_reason");}
				catch{DDL_REASON.SelectedValue = "";}			
			}

			else
			{
				conn.QueryString = "select * from VW_MAS_INPUT_NEW_COLLATERAL WHERE ACC_NUMBER ='" +Request.QueryString["acc_number"]+ "' and collateral_id = '" +Request.QueryString["collateral_id"]+ "' ";
				conn.ExecuteQuery();
				TXT_ACC_NUMBER.Text = conn.GetFieldValue("acc_number");
				TXT_ACC_STATUS.Text = conn.GetFieldValue("acc_status");
				TXT_CUST_NAME.Text = conn.GetFieldValue("cust_name");
				TXT_DISTRIK_CODE.Text = conn.GetFieldValue("distrik_code");
				TXT_CLUSTER_CODE.Text = conn.GetFieldValue("cluster_code");
				TXT_UNIT_CODE.Text = conn.GetFieldValue("buc");

				TXT_AGUNAN_NM.Text = conn.GetFieldValue("agunan_name");
				TXT_BAST_DR_CA.Text = conn.GetFieldValue("bast_dari_ca");
				TXT_TGL_KIRIM.Text = tool.FormatDate_Day(conn.GetFieldValue("SEND_CA_DATE"));
				try{DDL_BLN_KIRIM.SelectedValue = tool.FormatDate_Month(conn.GetFieldValue("SEND_CA_DATE"));}
				catch{DDL_BLN_KIRIM.SelectedValue = "";}
				TXT_THN_KIRIM.Text = tool.FormatDate_Year(conn.GetFieldValue("SEND_CA_DATE"));
				try{DDL_REASON.SelectedValue = conn.GetFieldValue("request_reason");}
				catch{DDL_REASON.SelectedValue = "";}			

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

		}
		#endregion

		protected void BTN_BACK_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			Response.Redirect("ListCollateral.aspx?tc=" + Request.QueryString["tc"] + "&mc=" + Request.QueryString["mc"] );
		}

		protected void BTN_CLEAR_Click(object sender, System.EventArgs e)
		{
			TXT_AGUNAN_NM.Text = "";
			TXT_BAST_DR_CA.Text = "";
			TXT_TGL_KIRIM.Text = "";
			DDL_BLN_KIRIM.SelectedValue = "";
			TXT_THN_KIRIM.Text = "";
			DDL_REASON.SelectedValue = "";
		}

		protected void BTN_FINISH_Click(object sender, System.EventArgs e)
		{
			/*conn.QueryString = "exec MAS_COLLATERAL_TRACKUPDATE '" +
				TXT_ACC_NUMBER.Text + "' , '" + 
				Request.QueryString["collateral_id"] + "' , 'M1.8' , '" + 
				Session["UserID"].ToString() + "' , '', '' ";
			conn.ExecuteQuery();*/

			conn.QueryString = "exec MAS_COLLATERAL_TRACKUPDATE '" +
				TXT_ACC_NUMBER.Text + "' , '" + 
				Request.QueryString["collateral_id"] + "' , 'M1.11' , '" + 
				Session["UserID"].ToString() + "' , '', '', '" + TXT_ACC_STATUS.Text.ToString() + "'";
			conn.ExecuteQuery();

			Response.Redirect("ListCollateral.aspx?tc=" + Request.QueryString["tc"] + "&mc=" + Request.QueryString["mc"] );
		}

		protected void BTN_SAVE_Click(object sender, System.EventArgs e)
		{
			conn.QueryString = "exec MAS_COLLATERAL_REQUEST_UPDATE '" +
				TXT_ACC_NUMBER.Text + "' , '" + 
				Request.QueryString["collateral_id"] + "', '"+
				TXT_AGUNAN_NM.Text + "' , '" + 
				TXT_BAST_DR_CA.Text + "' , " + 
				tool.ConvertDate(TXT_TGL_KIRIM.Text, DDL_BLN_KIRIM.SelectedValue, TXT_THN_KIRIM.Text) + ", '" +
				DDL_REASON.SelectedValue + "'";
			conn.ExecuteQuery();
			BTN_FINISH.Enabled = true;
		}

		protected void BTN_SEND_Click(object sender, System.EventArgs e)
		{
			if (DDL_CA_NAME.SelectedValue == "")
			{
				GlobalTools.popMessage(this, "CA Name tidak boleh kosong!");
				return;	
			}

			/*
			conn.QueryString = "update MAS_COLLATERAL set posisi_agunan='2' where ACC_NUMBER ='" +Request.QueryString["acc_number"]+ "' and collateral_id = '" +Request.QueryString["collateral_id"]+ "'";
			conn.ExecuteQuery();

			conn.QueryString = "exec MAS_COLLATERAL_TRACKUPDATE '" +
				TXT_ACC_NUMBER.Text + "' , '" + 
				Request.QueryString["collateral_id"] + "' , 'M1.6' , '" + 
				Session["UserID"].ToString() + "' , '" + 
				DDL_CA_NAME.SelectedValue + "', '2' ";
			conn.ExecuteQuery();*/

			conn.QueryString = "update MAS_COLLATERAL set CA_NAME = '" + DDL_CA_NAME.SelectedValue.ToString() + "'," +
				" SEND_CA_DATE = '" + DateAndTime.Now.ToString() + "'" +
				" where ACC_NUMBER ='" +Request.QueryString["acc_number"]+ "' and collateral_id = '" +Request.QueryString["collateral_id"]+ "'";
			conn.ExecuteQuery();

			conn.QueryString = "exec MAS_COLLATERAL_TRACKUPDATE '" +
				TXT_ACC_NUMBER.Text + "' , '" + 
				Request.QueryString["collateral_id"] + "' , 'M1.6' , '" + 
				Session["UserID"].ToString() + "' , '', '2', '" + TXT_ACC_STATUS.Text +"'";
			conn.ExecuteQuery();

			Response.Redirect("ListCollateral.aspx?tc=" + Request.QueryString["tc"] + "&mc=" + Request.QueryString["mc"] );
		}

		protected void ddl_process1_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if(ddl_process1.SelectedValue=="3")
			{
				DDL_CA_NAME.Visible=true;
			}
			else
			{
				DDL_CA_NAME.Visible=false;
			}
		}

		protected void btn_process1_Click(object sender, System.EventArgs e)
		{
			switch(ddl_process1.SelectedValue)
			{
				case "1" :
					conn.QueryString = "exec MAS_COLLATERAL_REQUEST_UPDATE '" +
						TXT_ACC_NUMBER.Text + "' , '" + 
						Request.QueryString["collateral_id"] + "', '"+
						TXT_AGUNAN_NM.Text + "' , '" + 
						TXT_BAST_DR_CA.Text + "' , " + 
						tool.ConvertDate(TXT_TGL_KIRIM.Text, DDL_BLN_KIRIM.SelectedValue, TXT_THN_KIRIM.Text) + ", '" +
						DDL_REASON.SelectedValue + "'";
					conn.ExecuteQuery();
					break;

				case "2":
					conn.QueryString = "exec MAS_COLLATERAL_TRACKUPDATE '" +
						TXT_ACC_NUMBER.Text + "' , '" + 
						Request.QueryString["collateral_id"] + "' , 'M1.11' , '" + 
						Session["UserID"].ToString() + "' , '', '', '" + TXT_ACC_STATUS.Text.ToString() + "'";
					conn.ExecuteQuery();

					Response.Redirect("ListCollateral.aspx?tc=" + Request.QueryString["tc"] + "&mc=" + Request.QueryString["mc"] );
					break;

				case "3":
					if (DDL_CA_NAME.SelectedValue == "")
					{
						GlobalTools.popMessage(this, "CA Name tidak boleh kosong!");
						return;	
					}

					/*
					conn.QueryString = "update MAS_COLLATERAL set posisi_agunan='2' where ACC_NUMBER ='" +Request.QueryString["acc_number"]+ "' and collateral_id = '" +Request.QueryString["collateral_id"]+ "'";
					conn.ExecuteQuery();

					conn.QueryString = "exec MAS_COLLATERAL_TRACKUPDATE '" +
						TXT_ACC_NUMBER.Text + "' , '" + 
						Request.QueryString["collateral_id"] + "' , 'M1.6' , '" + 
						Session["UserID"].ToString() + "' , '" + 
						DDL_CA_NAME.SelectedValue + "', '2' ";
					conn.ExecuteQuery();*/

					conn.QueryString = "update MAS_COLLATERAL set CA_NAME = '" + DDL_CA_NAME.SelectedValue.ToString() + "'," +
						" SEND_CA_DATE = '" + DateAndTime.Now.ToString() + "'" +
						" where ACC_NUMBER ='" +Request.QueryString["acc_number"]+ "' and collateral_id = '" +Request.QueryString["collateral_id"]+ "'";
					conn.ExecuteQuery();

					conn.QueryString = "exec MAS_COLLATERAL_TRACKUPDATE '" +
						TXT_ACC_NUMBER.Text + "' , '" + 
						Request.QueryString["collateral_id"] + "' , 'M1.6' , '" + 
						Session["UserID"].ToString() + "' , '', '2', '" + TXT_ACC_STATUS.Text +"'";
					conn.ExecuteQuery();

					Response.Redirect("ListCollateral.aspx?tc=" + Request.QueryString["tc"] + "&mc=" + Request.QueryString["mc"] );

					break;

				case "4":
					TXT_AGUNAN_NM.Text = "";
					TXT_BAST_DR_CA.Text = "";
					TXT_TGL_KIRIM.Text = "";
					DDL_BLN_KIRIM.SelectedValue = "";
					TXT_THN_KIRIM.Text = "";
					DDL_REASON.SelectedValue = "";
					break;
			}
				
		}
	}
}
