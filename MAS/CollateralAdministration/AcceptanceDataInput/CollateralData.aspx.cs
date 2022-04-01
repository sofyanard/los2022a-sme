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

namespace SME.MAS.CollateralAdministration.AcceptanceDataInput
{
	/// <summary>
	/// Summary description for CollateralData.
	/// </summary>
	public partial class CollateralData : System.Web.UI.Page
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
				fillDDL();
				Label1.Text=Request.QueryString["acc_status"];
				//ViewData();
				//ViewData2();
				Label1.Text=(Label1.Text).Substring(0,1);
				if (Label1.Text =="1")
				{
					ViewData();
					ViewData2();
				}
				if (Label1.Text =="2")
				{	
					ViewData();
					ViewData2();
					tra.Visible=true;
					trb.Visible=true;
					trcolreq.Visible=true;
					trcolreq2.Visible=true;
					trprocess.Visible=true;
				}
				
				BTN_FINISH.Enabled = false;
				BTN_FINISH.Attributes.Add("OnClick","return confirm('Apakah Anda yakin sudah selesai pengisian datanya?')");
				BTN_ACCEPT.Attributes.Add("OnClick","return confirm('Apakah Anda yakin data mau diterima?')");
				BTN_RETURN_TO_CA.Attributes.Add("OnClick","return confirm('Apakah Anda yakin data mau dikembalikan ke CA?')");
				BTN_TO_MKA.Attributes.Add("OnClick","return confirm('Apakah Anda yakin data mau dikembalikan ke MKA?')");

				
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


		private void fillDDL()
		{
			ddl_process1.Items.Clear();	
			ddl_process1.Items.Add(new ListItem("- PILIH -", ""));
			ddl_process1.Items.Add(new ListItem("Terima", "1"));
			ddl_process1.Items.Add(new ListItem("Kembalikan ke CA", "2"));

			DDL_POSISI_AGUNAN.Items.Add(new ListItem("--Pilih--", ""));
			DDL_COLLATERAL_TYPE.Items.Add(new ListItem("--Pilih--",""));
			DDL_PENGIKATAN_TYPE.Items.Add(new ListItem("--Pilih--",""));
			DDL_CA_NAME.Items.Add(new ListItem("--Pilih--",""));
			DDL_REASON.Items.Add(new ListItem("--Pilih--",""));

			conn.QueryString = "select * from MAS_RF_POSISI_AGUNAN where status='1'";
			conn.ExecuteQuery();
			for (int i = 0; i < conn.GetRowCount(); i++)
				DDL_POSISI_AGUNAN.Items.Add(new ListItem(conn.GetFieldValue(i,1),conn.GetFieldValue(i,0)));

			conn.QueryString = "select * from MAS_RF_JENIS_AGUNAN where status='1'";
			conn.ExecuteQuery();
			for (int i = 0; i < conn.GetRowCount(); i++)
				DDL_COLLATERAL_TYPE.Items.Add(new ListItem(conn.GetFieldValue(i,1),conn.GetFieldValue(i,0)));

			conn.QueryString = "select * from rfikat where active='1' order by ikatdesc ";
			conn.ExecuteQuery();
			for (int i = 0; i < conn.GetRowCount(); i++)
				DDL_PENGIKATAN_TYPE.Items.Add(new ListItem(conn.GetFieldValue(i,1),conn.GetFieldValue(i,0)));

			//conn.QueryString = "select userid, su_fullname from scuser where groupid='84' and su_active='1'";
			//conn.QueryString = "select userid, su_fullname from scuser where su_active='1' and su_branch='" + LBL_DISTRIK.Text + "' ";
			conn.QueryString = "select userid, su_fullname from scuser where userid like 'CAdmin%'";
			conn.ExecuteQuery();
			for (int i = 0; i < conn.GetRowCount(); i++)
				DDL_CA_NAME.Items.Add(new ListItem(conn.GetFieldValue(i,1),conn.GetFieldValue(i,0)));

			conn.QueryString = "select * from mas_rf_request_reason where status='1'";
			conn.ExecuteQuery();
			for (int i = 0; i < conn.GetRowCount(); i++)
				DDL_REASON.Items.Add(new ListItem(conn.GetFieldValue(i,1),conn.GetFieldValue(i,0)));

			DDL_BLN_PICK_UP.Items.Add(new ListItem("--Pilih--",""));
			DDL_BLN_KIRIM.Items.Add(new ListItem("--Pilih--",""));
			DDL_BLN_KIRIM_UNIT.Items.Add(new ListItem("--Pilih--",""));

			for (int i=1; i<=12; i++)
			{
				DDL_BLN_PICK_UP.Items.Add(new ListItem(DateAndTime.MonthName(i, false), i.ToString()));
				DDL_BLN_KIRIM.Items.Add(new ListItem(DateAndTime.MonthName(i, false), i.ToString()));	
				DDL_BLN_KIRIM_UNIT.Items.Add(new ListItem(DateAndTime.MonthName(i, false), i.ToString()));	
			}
		}

		private void ViewData()
		{
			conn.QueryString = "select * from VW_MAS_COLLATERAL_DATA WHERE ACC_NUMBER ='" +Request.QueryString["acc_number"]+ "' and collateral_id = '" +Request.QueryString["collateral_id"]+ "'  ";
			conn.ExecuteQuery();
			if (conn.GetRowCount()==0)
			{
				conn.QueryString = "select * from MAS_UPLOAD_DATA WHERE ACC_NUMBER ='" +Request.QueryString["acc_number"]+ "' and collateral_id = '" +Request.QueryString["collateral_id"]+ "'  ";
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

			try{RDO_LIFE_INS.SelectedValue = conn.GetFieldValue("life_ins");}
			catch{RDO_LIFE_INS.SelectedValue = null;}
			TXT_POLIS_LIFE.Text = conn.GetFieldValue("polis_life");
			TXT_LIFE_INS_NAME.Text = conn.GetFieldValue("life_ins_name");
			try{RDO_TERIMA_LIFE_POLIS.SelectedValue = conn.GetFieldValue("terima_life_polis");}
			catch{RDO_TERIMA_LIFE_POLIS.SelectedValue = null;}
			try{RDO_AGUNAN.SelectedValue = conn.GetFieldValue("agunan");}
			catch{RDO_AGUNAN.SelectedValue = null;}
			try{DDL_POSISI_AGUNAN.SelectedValue = conn.GetFieldValue("POSISI_AGUNAN");}
			catch{DDL_POSISI_AGUNAN.SelectedValue = "";}
			TXT_BAST_KE_CA.Text = conn.GetFieldValue("bast_ke_ca");
			TXT_BAST_DARI_CA.Text = conn.GetFieldValue("bast_dari_ca");
			try{DDL_COLLATERAL_TYPE.SelectedValue = conn.GetFieldValue("collateral_type");}
			catch{DDL_COLLATERAL_TYPE.SelectedValue = "";}

			TXT_AGUNAN_NAME.Text = conn.GetFieldValue("agunan_name");
			try{RDO_GENERAL_INS.SelectedValue = conn.GetFieldValue("general_ins");}
			catch{RDO_GENERAL_INS.SelectedValue = null;}
			TXT_POLIS_GENERAL.Text = conn.GetFieldValue("polis_general");
			TXT_GENERAL_INS_NM.Text = conn.GetFieldValue("general_ins_nm");
			try{RDO_TERIMA_GENERAL_POLIS.SelectedValue = conn.GetFieldValue("terima_general_polis");}
			catch{RDO_TERIMA_GENERAL_POLIS.SelectedValue = null;}
			try{RDO_PENGIKATAN_NOTARIAL.SelectedValue = conn.GetFieldValue("pengikatan_notarial");}
			catch{RDO_PENGIKATAN_NOTARIAL.SelectedValue = null;}
			string ioio = conn.GetFieldValue("pengikatan_type");
			try{DDL_PENGIKATAN_TYPE.SelectedValue = conn.GetFieldValue("pengikatan_type");}
			catch{DDL_PENGIKATAN_TYPE.SelectedValue = "";}	
			TXT_NOTARIS_NAME.Text = conn.GetFieldValue("notaris_name");
			try{RDO_TERIMA_PENGIKATAN.SelectedValue = conn.GetFieldValue("terima_pengikatan");}
			catch{RDO_TERIMA_PENGIKATAN.SelectedValue = null;}	

			BTN_ACCEPT.Enabled = true;
			BTN_RETURN_TO_CA.Enabled = true;
		}
		
		private void ViewData2()
		{
			conn.QueryString = "select * from VW_MAS_COLLATERAL_DATA WHERE ACC_NUMBER ='" +Request.QueryString["acc_number"]+ "' and collateral_id = '" +Request.QueryString["collateral_id"]+ "'  ";
			conn.ExecuteQuery();
			TXT_ACC_NUMBER.Text = conn.GetFieldValue("acc_number");
			TXT_ACC_STATUS.Text = conn.GetFieldValue("acc_status");
			TXT_CUST_NAME.Text = conn.GetFieldValue("cust_name");
			TXT_DISTRIK_CODE.Text = conn.GetFieldValue("distrik_code");
			TXT_CLUSTER_CODE.Text = conn.GetFieldValue("cluster_code");
			TXT_UNIT_CODE.Text = conn.GetFieldValue("buc");

			TXT_AGUNAN_NM.Text = conn.GetFieldValue("agunan_name");
			TXT_BAST_DR_CA.Text = conn.GetFieldValue("bast_dari_ca");
			TXT_TGL_KIRIM.Text = tool.FormatDate_Day(conn.GetFieldValue("send_ca_date"));
			try{DDL_BLN_KIRIM.SelectedValue = tool.FormatDate_Month(conn.GetFieldValue("send_ca_date"));}
			catch{DDL_BLN_KIRIM.SelectedValue = "";}
			TXT_THN_KIRIM.Text = tool.FormatDate_Year(conn.GetFieldValue("send_ca_date"));
			try{DDL_REASON.SelectedValue = conn.GetFieldValue("request_reason");}
			catch{DDL_REASON.SelectedValue = "";}

			TXT_TGL_PICK_UP.Text = tool.FormatDate_Day(conn.GetFieldValue("pick_up_date"));
			try{DDL_BLN_PICK_UP.SelectedValue = tool.FormatDate_Month(conn.GetFieldValue("pick_up_date"));}
			catch{DDL_BLN_PICK_UP.SelectedValue = "";}
			TXT_THN_PICK_UP.Text = tool.FormatDate_Year(conn.GetFieldValue("pick_up_date"));
			TXT_BAST_KE_CA_REQ.Text = conn.GetFieldValue("bast_ke_ca");
			TXT_TGL_KIRIM_UNIT.Text = tool.FormatDate_Day(conn.GetFieldValue("kirim_date"));
			try{DDL_BLN_KIRIM_UNIT.SelectedValue = tool.FormatDate_Month(conn.GetFieldValue("kirim_date"));}
			catch{DDL_BLN_KIRIM_UNIT.SelectedValue = "";}
			TXT_THN_KIRIM_UNIT.Text = tool.FormatDate_Year(conn.GetFieldValue("kirim_date"));
			TXT_CAT_ATAS_REQUEST.Text = conn.GetFieldValue("request_remark");

			BTN_SAVE.Enabled = true;
			BTN_TO_MKA.Enabled = true;
			BTN_FINISH.Enabled = true;
			BTN_SEND.Enabled = true;
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

		protected void BTN_SAVE_Click(object sender, System.EventArgs e)
		{
			conn.QueryString = "SELECT SU_UPLINER FROM SCUSER WHERE USERID = '" + Session["UserID"].ToString() + "'";
			conn.ExecuteQuery();

			string upliner = conn.GetFieldValue("SU_UPLINER");

			conn.QueryString = "exec MAS_COLLATERAL_DATA_UPDATE '" +
				TXT_ACC_NUMBER.Text + "' , '" + 
				Request.QueryString["collateral_id"] + "' , '" + 
				RDO_LIFE_INS.SelectedValue + "' , '" + 
				TXT_POLIS_LIFE.Text + "' , '" + 
				TXT_LIFE_INS_NAME.Text + "' , '" + 
				RDO_TERIMA_LIFE_POLIS.SelectedValue + "' , '" + 
				RDO_AGUNAN.SelectedValue + "' , '" + 
				DDL_POSISI_AGUNAN.SelectedValue + "' , '" + 
				TXT_BAST_KE_CA.Text + "' , '" + 
				TXT_BAST_DARI_CA.Text + "' , '" + 
				DDL_COLLATERAL_TYPE.SelectedValue + "' , '" + 
				TXT_AGUNAN_NAME.Text + "' , '" + 
				RDO_GENERAL_INS.SelectedValue + "' , '" + 
				TXT_POLIS_GENERAL.Text + "' , '" + 
				TXT_GENERAL_INS_NM.Text + "' , '" + 
				RDO_TERIMA_GENERAL_POLIS.SelectedValue + "' , '" + 
				RDO_PENGIKATAN_NOTARIAL.SelectedValue + "' , '" + 
				DDL_PENGIKATAN_TYPE.SelectedValue + "' , '" + 
				TXT_NOTARIS_NAME.Text + "' , '" + 
				RDO_TERIMA_PENGIKATAN.SelectedValue + "',  '" +
				upliner +"', '"+
				TXT_CLUSTER_CODE.Text +"', '"+ 
				TXT_DISTRIK_CODE.Text +"', '"+  
				TXT_CUST_NAME.Text +"', '"+  
				TXT_UNIT_CODE.Text +"'";
			//tool.ConvertDate(LBL_UPLOAD_DATE.Text) +" ";
			conn.ExecuteQuery();

			BTN_FINISH.Enabled = true;
		}

		protected void BTN_FINISH_Click(object sender, System.EventArgs e)
		{
			/*conn.QueryString = "update MAS_COLLATERAL set posisi_agunan='6' where ACC_NUMBER ='" +Request.QueryString["acc_number"]+ "' and collateral_id = '" +Request.QueryString["collateral_id"]+ "'";
			conn.ExecuteQuery();			

			conn.QueryString = "exec MAS_COLLATERAL_TRACKUPDATE '" +
				TXT_ACC_NUMBER.Text + "' , '" + 
				Request.QueryString["collateral_id"] + "' , 'M1.8' , '" + 
				Session["UserID"].ToString() + "' , '', '6' ";
			conn.ExecuteQuery();*/

			conn.QueryString = "exec MAS_COLLATERAL_TRACKUPDATE '" +
				TXT_ACC_NUMBER.Text + "' , '" + 
				Request.QueryString["collateral_id"] + "' , 'M1.11' , '" + 
				Session["UserID"].ToString() + "' , '', '4', '" + TXT_ACC_STATUS.Text +"'";
			conn.ExecuteQuery();

			Response.Redirect("ListAcceptance.aspx?tc=" + Request.QueryString["tc"] + "&mc=" + Request.QueryString["mc"] );
		}

		protected void BTN_TO_MKA_Click(object sender, System.EventArgs e)
		{
			/*conn.QueryString = "update MAS_COLLATERAL set posisi_agunan='1' where ACC_NUMBER ='" +Request.QueryString["acc_number"]+ "' and collateral_id = '" +Request.QueryString["collateral_id"]+ "'";
			conn.ExecuteQuery();			

			conn.QueryString = "exec MAS_COLLATERAL_TRACKUPDATE '" +
				TXT_ACC_NUMBER.Text + "' , '" + 
				Request.QueryString["collateral_id"] + "' , 'M1.2' , '" + 
				Session["UserID"].ToString() + "' , '" +Request.QueryString["track_by"]+ "', '1' ";
			conn.ExecuteQuery();*/

			conn.QueryString = "SELECT SU_UPLINER FROM SCUSER WHERE USERID = '" + Session["UserID"].ToString() + "'";
			conn.ExecuteQuery();

			string upliner = conn.GetFieldValue("SU_UPLINER");

			conn.QueryString = "exec MAS_COLLATERAL_TRACKUPDATE '" +
				TXT_ACC_NUMBER.Text + "' , '" + 
				Request.QueryString["collateral_id"] + "' , 'M1.2' , '" + 
				Session["UserID"].ToString() + "' , '" + upliner + "', '1', '" + TXT_ACC_STATUS.Text +"'";
			conn.ExecuteQuery();

			Response.Redirect("ListAcceptance.aspx?tc=" + Request.QueryString["tc"] + "&mc=" + Request.QueryString["mc"] );
		}

		protected void BTN_SEND_Click(object sender, System.EventArgs e)
		{
			if (DDL_CA_NAME.SelectedValue == "")
			{
				GlobalTools.popMessage(this, "CA Name tidak boleh kosong!");
				return;	
			}

			//kurang tepat

			/*
			conn.QueryString = "update MAS_COLLATERAL set posisi_agunan='2' where ACC_NUMBER ='" +Request.QueryString["acc_number"]+ "' and collateral_id = '" +Request.QueryString["collateral_id"]+ "'";
			conn.ExecuteQuery();

			conn.QueryString = "exec MAS_COLLATERAL_TRACKUPDATE '" +
				TXT_ACC_NUMBER.Text + "' , '" + 
				Request.QueryString["collateral_id"] + "' , 'M1.4' , '" + 
				Session["UserID"].ToString() + "' , '" + 
				DDL_CA_NAME.SelectedValue + "', '2' ";
			conn.ExecuteQuery();*/
			
			conn.QueryString = "update MAS_COLLATERAL set CA_NAME = '" + DDL_CA_NAME.SelectedValue.ToString() + "'," +
				" SEND_CA_DATE = '" + DateAndTime.Now.ToString() + "'" +
				" where ACC_NUMBER ='" +Request.QueryString["acc_number"]+ "' and collateral_id = '" +Request.QueryString["collateral_id"]+ "'";
			conn.ExecuteQuery();

			conn.QueryString = "exec MAS_COLLATERAL_TRACKUPDATE '" +
				TXT_ACC_NUMBER.Text + "' , '" + 
				Request.QueryString["collateral_id"] + "' , 'M1.4' , '" + 
				Session["UserID"].ToString() + "' , '', '2', '" + TXT_ACC_STATUS.Text +"'";
			conn.ExecuteQuery();

			Response.Redirect("ListAcceptance.aspx?tc=" + Request.QueryString["tc"] + "&mc=" + Request.QueryString["mc"] );
		}

		protected void BTN_BACK_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			Response.Redirect("ListAcceptance.aspx?tc=" + Request.QueryString["tc"] + "&mc=" + Request.QueryString["mc"] );
		}

		protected void BTN_ACCEPT_Click(object sender, System.EventArgs e)
		{
			/*conn.QueryString = "update MAS_COLLATERAL set posisi_agunan='5' where ACC_NUMBER ='" +Request.QueryString["acc_number"]+ "' and collateral_id = '" +Request.QueryString["collateral_id"]+ "'";
			conn.ExecuteQuery();

			conn.QueryString = "exec MAS_COLLATERAL_TRACKUPDATE '" +
				TXT_ACC_NUMBER.Text + "' , '" + 
				Request.QueryString["collateral_id"] + "' , 'M1.8' , '" + 
				Session["UserID"].ToString() + "' , '', '5' ";
			conn.ExecuteQuery();*/

			conn.QueryString = "exec MAS_COLLATERAL_TRACKUPDATE '" +
				TXT_ACC_NUMBER.Text + "' , '" + 
				Request.QueryString["collateral_id"] + "' , 'M1.5' , '" + 
				Session["UserID"].ToString() + "' , '', '2', '" + TXT_ACC_STATUS.Text +"'";
			conn.ExecuteQuery();

			Response.Redirect("ListAcceptance.aspx?tc=" + Request.QueryString["tc"] + "&mc=" + Request.QueryString["mc"] );
		}

		protected void BTN_RETURN_TO_CA_Click(object sender, System.EventArgs e)
		{
			/*conn.QueryString = "update MAS_COLLATERAL set posisi_agunan='2' where ACC_NUMBER ='" +Request.QueryString["acc_number"]+ "' and collateral_id = '" +Request.QueryString["collateral_id"]+ "'";
			conn.ExecuteQuery();*/			

			conn.QueryString = "exec MAS_COLLATERAL_TRACKUPDATE '" +
				TXT_ACC_NUMBER.Text + "' , '" + 
				Request.QueryString["collateral_id"] + "' , 'M1.6' , '" + 
				Session["UserID"].ToString() + "' , '', '2', '" + TXT_ACC_STATUS.Text +"'";
			conn.ExecuteQuery();

			Response.Redirect("ListAcceptance.aspx?tc=" + Request.QueryString["tc"] + "&mc=" + Request.QueryString["mc"] );
		}

		protected void btn_process1_Click(object sender, System.EventArgs e)
		{
			if (ddl_process1.SelectedValue=="1")
			{
				conn.QueryString = "exec MAS_COLLATERAL_TRACKUPDATE '" +
					TXT_ACC_NUMBER.Text + "' , '" + 
					Request.QueryString["collateral_id"] + "' , 'M1.5' , '" + 
					Session["UserID"].ToString() + "' , '', '2', '" + TXT_ACC_STATUS.Text +"'";
				conn.ExecuteQuery();

				Response.Redirect("ListAcceptance.aspx?tc=" + Request.QueryString["tc"] + "&mc=" + Request.QueryString["mc"] );				
			}
			else if (ddl_process1.SelectedValue=="2")
			{
				conn.QueryString = "exec MAS_COLLATERAL_TRACKUPDATE '" +
					TXT_ACC_NUMBER.Text + "' , '" + 
					Request.QueryString["collateral_id"] + "' , 'M1.6' , '" + 
					Session["UserID"].ToString() + "' , '', '2', '" + TXT_ACC_STATUS.Text +"'";
				conn.ExecuteQuery();

				Response.Redirect("ListAcceptance.aspx?tc=" + Request.QueryString["tc"] + "&mc=" + Request.QueryString["mc"] );

				
			}
		}

		
	}
}
