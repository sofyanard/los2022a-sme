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

namespace SME.MAS.CollateralAdministration.InputNewCollateral
{
	/// <summary>
	/// Summary description for CollateralData.
	/// </summary>
	public partial class CollateralData : System.Web.UI.Page
	{
		protected Tools tool = new Tools();
		protected Connection conn = new Connection(ConfigurationSettings.AppSettings["conn"]);
		protected string acc_no,col_id,mc;
			
		protected void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			if(!IsPostBack)
			{
				
				conn.QueryString = "select acc_number, collateral_id, cluster_code, distrik_code, unit_code from mas_collateral where ACC_NUMBER ='" +Request.QueryString["acc_number"]+ "' and collateral_id = '" +Request.QueryString["collateral_id"]+ "' ";
				conn.ExecuteQuery();

				
				LBL_TC.Text = Request.QueryString["tc"];
				LBL_DISTRIK.Text = conn.GetFieldValue("distrik_code");
				LBL_CLUSTER.Text = conn.GetFieldValue("cluster_code");
				fillDDL();
				ViewData();	

				//Button1.Attributes.Add("OnClick","Button1_Click");
				//Page.re
				
			}
			ViewScreenMenu();
		}

		private void ViewScreenMenu()
		{
			//conn.QueryString = "select coltypeid from rfcollateraltype where coltypeseq='"+ Request.QueryString["type"] + "'" ;
			conn.QueryString = "select collateral_type from mas_collateral where ACC_NUMBER ='" +Request.QueryString["acc_number"]+ "' and collateral_id = '" +Request.QueryString["collateral_id"]+ "' ";
			conn.ExecuteQuery();	

			string a,b;
			a=conn.GetFieldValue("collateral_type");
			a="";
			b="";

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
			DDL_POSISI_AGUNAN.Items.Add(new ListItem("--Pilih--", ""));
			DDL_COLLATERAL_TYPE.Items.Add(new ListItem("--Pilih--",""));
			DDL_PENGIKATAN_TYPE.Items.Add(new ListItem("--Pilih--",""));
			DDL_CAO_NAME.Items.Add(new ListItem("--Pilih--",""));

			conn.QueryString = "select * from MAS_RF_POSISI_AGUNAN where status='1'";
			conn.ExecuteQuery();
			for (int i = 0; i < conn.GetRowCount(); i++)
				DDL_POSISI_AGUNAN.Items.Add(new ListItem(conn.GetFieldValue(i,1),conn.GetFieldValue(i,0)));

			conn.QueryString = "select * from MAS_RF_JENIS_AGUNAN where status='1'";
			conn.ExecuteQuery();
			for (int i = 0; i < conn.GetRowCount(); i++)
				DDL_COLLATERAL_TYPE.Items.Add(new ListItem(conn.GetFieldValue(i,1),conn.GetFieldValue(i,0)));

			conn.QueryString = "select * from rfikat where active='1' order by ikatid ";
			//conn.QueryString = "select * from mas_rf_jenis_pengikatan where status='1'";
			conn.ExecuteQuery();
			for (int i = 0; i < conn.GetRowCount(); i++)
				DDL_PENGIKATAN_TYPE.Items.Add(new ListItem(conn.GetFieldValue(i,1),conn.GetFieldValue(i,0)));

			//conn.QueryString = "select userid, su_fullname from scuser where groupid='83' and su_active='1'";
			//conn.QueryString = "select userid, su_fullname from scuser where su_active='1' and su_branch='" + LBL_CLUSTER.Text + "' ";
			conn.QueryString = "select userid, su_fullname from scuser where su_active='1' and userid!='"+ Session["UserID"].ToString()+
							   "' and groupid='83' and su_branch=(select su_branch from scuser where userid = '"+ Session["UserID"].ToString() +"')" ;
			conn.ExecuteQuery();
			for (int i = 0; i < conn.GetRowCount(); i++)
				DDL_CAO_NAME.Items.Add(new ListItem(conn.GetFieldValue(i,1),conn.GetFieldValue(i,0)));
		}

		private void ViewData()
		{
			/*conn.QueryString = "select * from VW_MAS_COLLATERAL_DATA WHERE ACC_NUMBER ='" +Request.QueryString["acc_number"]+ "' and collateral_id = '" +Request.QueryString["collateral_id"]+ "'  ";
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
			{*/
			conn.QueryString = "select * from VW_MAS_COLLATERAL_DATA WHERE ACC_NUMBER ='" +Request.QueryString["acc_number"]+ "' and collateral_id = '" +Request.QueryString["collateral_id"]+ "'  ";
			conn.ExecuteQuery();
			TXT_ACC_NUMBER.Text = conn.GetFieldValue("acc_number");
			TXT_ACC_STATUS.Text = conn.GetFieldValue("acc_status");
			TXT_CUST_NAME.Text = conn.GetFieldValue("cust_name");
			TXT_DISTRIK_CODE.Text = conn.GetFieldValue("distrik_code");
			TXT_CLUSTER_CODE.Text = conn.GetFieldValue("cluster_code");
			TXT_UNIT_CODE.Text = conn.GetFieldValue("buc");
			//}	

			conn.QueryString = "select * from MAS_COLLATERAL WHERE ACC_NUMBER ='" +Request.QueryString["acc_number"]+ "' and collateral_id = '" +Request.QueryString["collateral_id"]+ "'  ";
			conn.ExecuteQuery();
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
			try{DDL_PENGIKATAN_TYPE.SelectedValue = conn.GetFieldValue("pengikatan_type");}
			catch{DDL_PENGIKATAN_TYPE.SelectedValue = "";}	
			TXT_NOTARIS_NAME.Text = conn.GetFieldValue("notaris_name");
			try{RDO_TERIMA_PENGIKATAN.SelectedValue = conn.GetFieldValue("terima_pengikatan");}
			catch{RDO_TERIMA_PENGIKATAN.SelectedValue = null;}				
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

		private void BTN_SAVE_Click(object sender, System.EventArgs e)
		{
			if (DDL_POSISI_AGUNAN.SelectedValue == "1")
			{
				BTN_FINISH.Enabled = true;
				//GlobalTools.popMessage(this, "Posisi Agunan harus terisi Unit dari Debitur!");
				//return;	
			}	
			else
			{
				BTN_FINISH.Enabled = false;
			}

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
				Session["UserID"].ToString() +"', '"+
				TXT_CLUSTER_CODE.Text +"', '"+ 
				TXT_DISTRIK_CODE.Text +"', '"+  
				TXT_CUST_NAME.Text +"', '"+  
				TXT_UNIT_CODE.Text +"'";
				//tool.ConvertDate(LBL_UPLOAD_DATE.Text) +" ";
			conn.ExecuteQuery();

			//BTN_FINISH.Enabled = true;

			conn.QueryString = "select * from MAS_COLLATERAL_TRACK_HISTORY where acc_number = '"+ TXT_ACC_NUMBER.Text +"' ";
			conn.ExecuteQuery();
			if (conn.GetRowCount() > 0)
			{
				return;
			}
			else
			{
				conn.QueryString = "exec MAS_COLLATERAL_TRACKUPDATE '" +
					TXT_ACC_NUMBER.Text + "' , '" + 
					Request.QueryString["collateral_id"] + "' , 'M1.2' , '" + 
					Session["UserID"].ToString() + "' , '" + Session["UserID"].ToString() + "', '1', '" + TXT_ACC_STATUS.Text +"'";
				conn.ExecuteQuery();
			}
		}

		protected void BTN_FINISH_Click(object sender, System.EventArgs e)
		{
			/*conn.QueryString = "update MAS_COLLATERAL set posisi_agunan='6' where ACC_NUMBER ='" +Request.QueryString["acc_number"]+ "' and collateral_id = '" +Request.QueryString["collateral_id"]+ "'";
			conn.ExecuteQuery();*/		

			/*conn.QueryString = "exec MAS_COLLATERAL_DATA_UPDATE '" +
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
				Session["UserID"].ToString() +"', '"+
				TXT_CLUSTER_CODE.Text +"', '"+ 
				TXT_DISTRIK_CODE.Text +"', '"+  
				TXT_CUST_NAME.Text +"', '"+  
				TXT_UNIT_CODE.Text +"'";
			//tool.ConvertDate(LBL_UPLOAD_DATE.Text) +" ";
			conn.ExecuteQuery();

			conn.QueryString = "exec MAS_COLLATERAL_TRACKUPDATE '" +
				TXT_ACC_NUMBER.Text + "' , '" + 
				Request.QueryString["collateral_id"] + "' , 'M1.8' , '" + 
				Session["UserID"].ToString() + "' , '', '6', '" + TXT_ACC_STATUS.Text +"'";
			conn.ExecuteQuery(); */

			Response.Redirect("ListCollateral.aspx?tc=" + Request.QueryString["tc"] + "&mc=" + Request.QueryString["mc"] );
		}

		protected void BTN_BACK_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			Response.Redirect("ListCollateral.aspx?tc=" + Request.QueryString["tc"] + "&mc=" + Request.QueryString["mc"] );
		}

		protected void BTN_SEND_Click(object sender, System.EventArgs e)
		{
			if (DDL_CAO_NAME.SelectedValue == "")
			{
				GlobalTools.popMessage(this, "CAO Name tidak boleh kosong!");
				return;	
			}

			/*conn.QueryString = "update MAS_COLLATERAL set posisi_agunan='4' where ACC_NUMBER ='" +Request.QueryString["acc_number"]+ "' and collateral_id = '" +Request.QueryString["collateral_id"]+ "'";
			conn.ExecuteQuery();*/

			conn.QueryString = "select AP_CURRTRACK from MAS_APP_CURRTRACK where ACC_NUMBER ='" +Request.QueryString["acc_number"]+ "' and collateralid = '" +Request.QueryString["collateral_id"]+ "'";
			conn.ExecuteQuery();

			if (conn.GetFieldValue("AP_CURRTRACK")!="M1.8")
			{
				conn.QueryString = "update MAS_COLLATERAL set CAO_NAME = '" + DDL_CAO_NAME.SelectedValue.ToString() + "'," +
					" SEND_CAO_DATE = '" + DateAndTime.Now.ToString() + "'" +
					" where ACC_NUMBER ='" +Request.QueryString["acc_number"]+ "' and collateral_id = '" +Request.QueryString["collateral_id"]+ "'";
				conn.ExecuteQuery();

				conn.QueryString = "exec MAS_COLLATERAL_TRACKUPDATE '" +
					TXT_ACC_NUMBER.Text + "' , '" + 
					Request.QueryString["collateral_id"] + "' , 'M1.3' , '" + 
					Session["UserID"].ToString() + "' , '', '4', '" + TXT_ACC_STATUS.Text +"'";
				conn.ExecuteQuery();
			}
			


			Response.Redirect("ListCollateral.aspx?tc=" + Request.QueryString["tc"] + "&mc=" + Request.QueryString["mc"] );
		}

		private void RDO_GENERAL_INS_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if (RDO_GENERAL_INS.SelectedValue == "0")
			{
				TXT_POLIS_GENERAL.Enabled = false;
				TXT_GENERAL_INS_NM.Enabled = false;
				RDO_TERIMA_GENERAL_POLIS.Enabled = false;
				RDO_TERIMA_GENERAL_POLIS.SelectedValue = null;
			}
			else
			{
				TXT_POLIS_GENERAL.Enabled = true;
				TXT_GENERAL_INS_NM.Enabled = true;
				RDO_TERIMA_GENERAL_POLIS.Enabled = true;
				//RDO_TERIMA_GENERAL_POLIS.SelectedValue = null;
			}
		}

		private void RDO_PENGIKATAN_NOTARIAL_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if (RDO_PENGIKATAN_NOTARIAL.SelectedValue == "0")
			{
				TXT_NOTARIS_NAME.Enabled = false;
				TXT_NOTARIS_NAME.Text = "";
				RDO_TERIMA_PENGIKATAN.Enabled = false;
				RDO_TERIMA_PENGIKATAN.SelectedValue = null;
			}
			else
			{
				TXT_NOTARIS_NAME.Enabled = true;
				//TXT_NOTARIS_NAME.Text = "";
				RDO_TERIMA_PENGIKATAN.Enabled = true;				
			}
		}

		private void DDL_POSISI_AGUNAN_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			/*if (DDL_POSISI_AGUNAN.SelectedValue == "1")
			{
				BTN_FINISH.Enabled = true;
			}
			else
			{
				BTN_FINISH.Enabled = false;
			}*/
		}

		protected void Button1_Click(object sender, System.EventArgs e)
		{
			Response.Redirect("ListCollateral.aspx?tc=" + Request.QueryString["tc"] + "&mc=" + Request.QueryString["mc"] );
		}
	}
}
