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
using DMS.CuBESCore;
using DMS.DBConnection;
using Microsoft.VisualBasic;

namespace SME.MAS.CollateralAdministration.DetailCollateral
{
	/// <summary>
	/// Summary description for Collateral_Re.
	/// </summary>
	public partial class Collateral_Re : System.Web.UI.Page
	{
		protected Tools tool = new Tools();
		//protected Connection conn;
		protected Connection conn = new Connection(ConfigurationSettings.AppSettings["conn"]);
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			//conn = (Connection) Session["Connection"];
			if(!IsPostBack)
			{
				
				btn_save.Attributes.Add("onClick","return cek_mandatory(document.Form1);");
				TXT_SIBS_COLID.Text=Request.QueryString["collateral_id"];
				LBL_REGNO.Text=Request.QueryString["acc_number"];

				conn.QueryString = "select coltypedesc from rfcollateraltype where coltypeseq='"+ Request.QueryString["type"] + "'" ;
				conn.ExecuteQuery();			

				lbl_re.Text=conn.GetFieldValue("coltypedesc");

				FillFeild();

				ddl_process.Items.Clear();	
				ddl_process.Items.Add(new ListItem("- PILIH -", ""));
				ddl_process.Items.Add(new ListItem("Simpan Data", "1"));
				ddl_process.Items.Add(new ListItem("Simpan Dokumen di Unit", "2"));
		
				if (Request.QueryString["tc"]=="M1.2")
				{
					ddl_process.Items.Add(new ListItem("Kirim ke CAO", "3"));
				}

				if (Request.QueryString["tc"]=="M1.3")
				{
					//BTN_TO_MKA.Visible=true;
					BTN_FINISH.Enabled=true;
					ddl_process.Items.Add(new ListItem("Kirim Kembali ke MKA", "4"));
					ddl_process.Items.Add(new ListItem("Kirim ke CA", "5"));
				}

			}
		}

		private void DDLAll()
		{

			DDL_CL_CURRENCY.Items.Clear();
			DDL_CL_COLCLASSIFY.Items.Clear();
			DDL_CL_CERTTYPE1.Items.Clear();
			DDL_CL_CERTTYPE2.Items.Clear();
			DDL_CL_PROPTYPE.Items.Clear();
			DDL_CL_CERTISSUEMONTH.Items.Clear();
			DDL_CL_CERTEXPIREMONTH.Items.Clear();
			DDL_CL_RELATIONSHIP.Items.Clear();
			//DDL_CL_DEVELOPER.Items.Add(new ListItem("- PILIH -", ""));
			DDL_CL_COLLOC.Items.Clear();			
			DDL_CL_VALACCRDTO.Items.Clear();
			DDL_CL_JNSAGUNAN.Items.Clear();

			DDL_CA_NAME.Items.Clear();
			
			DDL_CA_NAME.Items.Add(new ListItem("--Pilih--",""));
			conn.QueryString = "select userid, su_fullname from scuser where userid like 'CAdmin%'";
			conn.ExecuteQuery();
			for (int i = 0; i < conn.GetRowCount(); i++)
				DDL_CA_NAME.Items.Add(new ListItem(conn.GetFieldValue(i,1),conn.GetFieldValue(i,0)));

			ddl_notaris_asuransi.Items.Clear();
			ddl_notaris_asuransi.Items.Add(new ListItem("--Pilih--",""));
			
			conn.QueryString = "select name from MAS_RFNOTARIS_ASURANSI where type='1' and branch='" + Session["BranchID"].ToString()+"'";
			conn.ExecuteQuery();
			for (int i = 0; i < conn.GetRowCount(); i++)
				ddl_notaris_asuransi.Items.Add(new ListItem(conn.GetFieldValue(i,0),conn.GetFieldValue(i,0)));


			ddl_posisi.Items.Clear();
			DDL_CAO_NAME.Items.Clear();

			DDL_CL_CURRENCY.Items.Add(new ListItem("- PILIH -", ""));
			DDL_CL_COLCLASSIFY.Items.Add(new ListItem("- PILIH -", ""));
			DDL_CL_CERTTYPE1.Items.Add(new ListItem("- PILIH -", ""));
			DDL_CL_CERTTYPE2.Items.Add(new ListItem("- PILIH -", ""));
			DDL_CL_PROPTYPE.Items.Add(new ListItem("- PILIH -", ""));
			DDL_CL_CERTISSUEMONTH.Items.Add(new ListItem("- PILIH -", ""));
			DDL_CL_CERTEXPIREMONTH.Items.Add(new ListItem("- PILIH -", ""));
			DDL_CL_RELATIONSHIP.Items.Add(new ListItem("- PILIH -", ""));
			//DDL_CL_DEVELOPER.Items.Add(new ListItem("- PILIH -", ""));
			DDL_CL_COLLOC.Items.Add(new ListItem("- PILIH -", ""));
			DDL_CL_VALACCRDTO.Items.Add(new ListItem("- PILIH -", ""));
			DDL_CL_JNSAGUNAN.Items.Add(new ListItem("- PILIH -", ""));

			ddl_posisi.Items.Add(new ListItem("- PILIH -", ""));
			DDL_CAO_NAME.Items.Add(new ListItem("--Pilih--",""));



			conn.QueryString = "select userid, su_fullname from scuser where su_active='1' and userid!='"+ Session["UserID"].ToString()+
				"' and groupid='83' and su_branch=(select su_branch from scuser where userid = '"+ Session["UserID"].ToString() +"')" ;
			conn.ExecuteQuery();
			for (int i = 0; i < conn.GetRowCount(); i++)
				DDL_CAO_NAME.Items.Add(new ListItem(conn.GetFieldValue(i,1),conn.GetFieldValue(i,0)));

			
			conn.QueryString = "select * from MAS_RF_POSISI_AGUNAN where status='1'";
			conn.ExecuteQuery();
			for (int i = 0; i < conn.GetRowCount(); i++)
				ddl_posisi.Items.Add(new ListItem(conn.GetFieldValue(i,1),conn.GetFieldValue(i,0)));

			for (int i=1 ; i<=12; i++)
			{
				DDL_CL_CERTISSUEMONTH.Items.Add(new ListItem(DateAndTime.MonthName(i, false), i.ToString()));
				DDL_CL_CERTEXPIREMONTH.Items.Add(new ListItem(DateAndTime.MonthName(i, false), i.ToString()));
			}
			conn.QueryString = "select CURRENCYID, CURRENCYID + ' - ' + CURRENCYDESC as CURRENCYDESC from RFCURRENCY where ACTIVE = '1' order by currencyref desc";

			conn.ExecuteQuery();
			for (int i=0; i< conn.GetRowCount(); i++)
				DDL_CL_CURRENCY.Items.Add(new ListItem(conn.GetFieldValue(i, 1), conn.GetFieldValue(i, 0)));

			conn.QueryString = "select COLCLASSID, COLCLASSDESC from RFCOLLCLASS where active='1'";

			conn.ExecuteQuery();
			for (int i=0; i< conn.GetRowCount(); i++)
				DDL_CL_COLCLASSIFY.Items.Add(new ListItem(conn.GetFieldValue(i, 1), conn.GetFieldValue(i, 0)));

			conn.QueryString = "select CERTTYPEID, CERTTYPEID + ' - ' + CERTTYPEDESC as CERTTYPEDESC from RFCERTTYPE where COLFLAG = 'RE' and ACTIVE = '1'";		

			//-----------------------------------------
			conn.ExecuteQuery();
			for (int i=0; i< conn.GetRowCount(); i++)
			{
				DDL_CL_CERTTYPE1.Items.Add(new ListItem(conn.GetFieldValue(i, 1), conn.GetFieldValue(i, 0)));
				DDL_CL_CERTTYPE2.Items.Add(new ListItem(conn.GetFieldValue(i, 1), conn.GetFieldValue(i, 0)));
			}

			conn.QueryString = "select PROPTYPEID, PROPTYPEID+' - '+PROPTYPEDESC as PROPTYPEDESC from RFPROPTYPE where ACTIVE='1' order by PROPTYPEID";

			conn.ExecuteQuery();
			for (int i=0; i< conn.GetRowCount(); i++)
				DDL_CL_PROPTYPE.Items.Add(new ListItem(conn.GetFieldValue(i, 1), conn.GetFieldValue(i, 0)));

			conn.QueryString = "select RELTYPEID, RELTYPEID+' - '+RELTYPEDESC from RFRELATIONSHIP where active='1' ";

			conn.ExecuteQuery();
			for (int i=0; i< conn.GetRowCount(); i++)
				DDL_CL_RELATIONSHIP.Items.Add(new ListItem(conn.GetFieldValue(i, 1), conn.GetFieldValue(i, 0)));

			//conn.QueryString = "select DEVELOPERID, DEVELOPERDESC from RFDEVELOPER where active='1'";

			//conn.ExecuteQuery();
			//for (int i=0; i< conn.GetRowCount(); i++)
			//	DDL_CL_DEVELOPER.Items.Add(new ListItem(conn.GetFieldValue(i, 1), conn.GetFieldValue(i, 0)));

			conn.QueryString = "select LOCATIONID, LOCATIONID+' - '+LOCATIONDESC as LOCATIONDESC from RFCOLLOCATION where ACTIVE='1' order by LOCATIONID";

			conn.ExecuteQuery();
			for (int i=0; i< conn.GetRowCount(); i++)
				DDL_CL_COLLOC.Items.Add(new ListItem(conn.GetFieldValue(i, 1), conn.GetFieldValue(i, 0)));

			conn.QueryString = "select ACCRDTOID, ACCRDTODESC from RFVALUEACCORDING where active='1'";

			conn.ExecuteQuery();
			for (int i=0; i< conn.GetRowCount(); i++)
				DDL_CL_VALACCRDTO.Items.Add(new ListItem(conn.GetFieldValue(i, 1), conn.GetFieldValue(i, 0)));
			
			conn.QueryString = "select AGUNANID, AGUNANID + ' - ' + AGUNANDESC AS AGUNANDESC from RFJENISAGUNAN WHERE ACTIVE='1' order by AGUNANID";
			//"where COLTYPEID = '"+ CL_TYPE +"'";
			conn.ExecuteQuery();
			for (int i=0; i< conn.GetRowCount(); i++)
				DDL_CL_JNSAGUNAN.Items.Add(new ListItem(conn.GetFieldValue(i, 1), conn.GetFieldValue(i, 0)));
			
			//this.SecureData();
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

		protected void btn_save_Click(object sender, System.EventArgs e)
		{
			if(ddl_posisi.SelectedValue!="")
			{
				BTN_FINISH.Enabled=true;
			}

			if (TXT_CL_DESC.Text!="" &&
				DDL_CL_CURRENCY.SelectedValue!="" &&
				DDL_CL_COLCLASSIFY.SelectedValue!="" &&
				ddl_posisi.SelectedValue!="" &&
				DDL_CL_CERTTYPE1.SelectedValue!="" &&
				DDL_CL_PROPTYPE.SelectedValue!="" &&
				TXT_CL_CERTNO.Text!="" &&
				TXT_CL_LANDAREA.Text!="" &&
				TXT_CL_OWNER.Text!="" &&
				DDL_CL_RELATIONSHIP.SelectedValue!="" &&
				TXT_CL_VALUE.Text!="" &&
				TXT_CL_VALUE2.Text!="" &&
				TXT_CL_LOCJLN.Text!="" &&
				TXT_CL_LOCRT.Text!="" &&
				TXT_CL_LOCRW.Text!="" &&
				TXT_CL_LOCKAVNO.Text!="" &&
				DDL_CL_COLLOC.SelectedValue!="" &&
				DDL_CL_VALACCRDTO.SelectedValue!="" )
			{
				SaveField();
			}
			
			FillFeild();
		}

		private void FillFeild()
		{
			DDLAll();	
			conn.QueryString = "exec MAS_CHANGE_COL_RE 'get','" + LBL_REGNO.Text + "','" + TXT_SIBS_COLID.Text + "'," +
				"'" + Request.QueryString["type"] + "'," +
				"'" + DDL_CL_CERTTYPE1.SelectedValue + "','" + DDL_CL_CERTTYPE2.SelectedValue + "'," +
				"'" + DDL_CL_PROPTYPE.SelectedValue + "','" + TXT_CL_CERTNO.Text + "'," +
				tool.ConvertDate(TXT_CL_CERTISSUEDAY.Text,DDL_CL_CERTISSUEMONTH.SelectedValue,TXT_CL_CERTISSUEYEAR.Text) + "," +
				tool.ConvertDate(TXT_CL_CERTEXPIREDAY.Text,DDL_CL_CERTEXPIREMONTH.SelectedValue,TXT_CL_CERTEXPIREYEAR.Text) + "," +
				"'" + TXT_CL_LANDAREA.Text + "','" + TXT_CL_BUILDAREA.Text + "'," +
				"'" + TXT_CL_OWNER.Text + "','" + DDL_CL_RELATIONSHIP.SelectedValue + "'," +
				tool.ConvertFloat(TXT_CL_VALUE.Text) + "," +
				tool.ConvertFloat(TXT_CL_VALUE2.Text) + "," +
				tool.ConvertFloat(TXT_CL_VALUEPPA.Text) + "," +
				"'','" + TXT_CL_LOCJLN.Text + "','" + TXT_CL_LOCRT.Text + "','" + TXT_CL_LOCRW.Text + "','" + TXT_CL_LOCKAVNO.Text + "'," +
				"'" + DDL_CL_COLLOC.SelectedValue + "','" + DDL_CL_VALACCRDTO.SelectedValue + "','" + DDL_CL_JNSAGUNAN.SelectedValue +"'," +
				tool.ConvertFloat(TXT_CL_VALUE.Text) + "," +
				tool.ConvertFloat(TXT_CL_VALUE2.Text) + "," +
				tool.ConvertFloat(TXT_CL_VALUEINS.Text) + "," +
				tool.ConvertFloat(TXT_CL_VALUEIKAT.Text) + "," +
				tool.ConvertFloat(TXT_CL_VALUEPPA.Text) + "," +
				tool.ConvertFloat(TXT_CL_VALUELIQ.Text) + "," +
				"'"+ TXT_CL_DESC.Text + "'," +
				"'" + DDL_CL_CURRENCY.SelectedValue + "',NULL," +
				"NULL,'" + DDL_CL_COLCLASSIFY.SelectedValue + "'," +
				"'" + Session["userID"] + "','','','',''";
			conn.ExecuteQuery();

			TXT_CL_BUILDAREA.Text=conn.GetFieldValue("CL_BUILDAREA");
			TXT_CL_CERTEXPIREDAY.Text=tool.FormatDate_Day(conn.GetFieldValue("CL_CERTEXPIRE"));
			TXT_CL_CERTEXPIREYEAR.Text=tool.FormatDate_Year(conn.GetFieldValue("CL_CERTEXPIRE"));
			TXT_CL_CERTISSUEDAY.Text=tool.FormatDate_Day(conn.GetFieldValue("CL_CERTISSUE"));
			TXT_CL_CERTISSUEYEAR.Text=tool.FormatDate_Year(conn.GetFieldValue("CL_CERTISSUE"));
			TXT_CL_CERTNO.Text=conn.GetFieldValue("CL_CERTNO");
            TXT_CL_LANDAREA.Text=conn.GetFieldValue("CL_LANDAREA");
			TXT_CL_LOCJLN.Text=conn.GetFieldValue("CL_LOCJLN");
			TXT_CL_LOCKAVNO.Text=conn.GetFieldValue("CL_LOCKAVNO");
			TXT_CL_LOCRT.Text=conn.GetFieldValue("CL_LOCRT");
			TXT_CL_LOCRW.Text=conn.GetFieldValue("CL_LOCRW");
			TXT_CL_OWNER.Text=conn.GetFieldValue("CL_OWNER");

			DDL_CL_CERTEXPIREMONTH.SelectedValue=tool.FormatDate_Month(conn.GetFieldValue("CL_CERTEXPIRE"));
			DDL_CL_CERTISSUEMONTH.SelectedValue=tool.FormatDate_Month(conn.GetFieldValue("CL_CERTISSUE"));
			DDL_CL_CERTTYPE1.SelectedValue=conn.GetFieldValue("CL_CERTTYPE1");
			DDL_CL_CERTTYPE2.SelectedValue=conn.GetFieldValue("CL_CERTTYPE2");
			DDL_CL_COLLOC.SelectedValue=conn.GetFieldValue("CL_COLLOC");			
			DDL_CL_JNSAGUNAN.SelectedValue=conn.GetFieldValue("CL_JNSAGUNAN");
			DDL_CL_PROPTYPE.SelectedValue=conn.GetFieldValue("CL_PROPTYPE");
			DDL_CL_RELATIONSHIP.SelectedValue=conn.GetFieldValue("CL_RELATIONSHIP");
			DDL_CL_VALACCRDTO.SelectedValue=conn.GetFieldValue("CL_VALACCRDTO");
			TXT_CL_VALUEPPA.Text=tool.MoneyFormat(conn.GetFieldValue("CL_PPAPVAL"));

			conn.QueryString = "exec MAS_CHANGE_COL_VALUE 'get'," +
				"'"+ Request.QueryString["acc_number"] +"','"+ Request.QueryString["collateral_id"] +"'," +
				"'','','','','','','','','','','',''";
			conn.ExecuteQuery();

			TXT_CL_DESC.Text =conn.GetFieldValue("CL_DESC");
			TXT_CL_VALUE.Text=tool.MoneyFormat(conn.GetFieldValue("CL_VALUE"));			
			TXT_CL_VALUEIKAT.Text=tool.MoneyFormat(conn.GetFieldValue("CL_VALUEIKAT"));
			TXT_CL_VALUEINS.Text=tool.MoneyFormat(conn.GetFieldValue("CL_VALUEINS"));
			TXT_CL_VALUELIQ.Text=tool.MoneyFormat(conn.GetFieldValue("CL_VALUELIQ"));

			DDL_CL_COLCLASSIFY.SelectedValue=conn.GetFieldValue("CL_COLCLASSIFY");
			DDL_CL_CURRENCY.SelectedValue=conn.GetFieldValue("CL_CURRENCY");
			TXT_CL_VALUE2.Text=tool.MoneyFormat(conn.GetFieldValue("CL_VALUE2"));			
			

			conn.QueryString = "select * from mas_collateral where acc_number='" + LBL_REGNO.Text + "' and collateral_id='" + TXT_SIBS_COLID.Text + "'";
			conn.ExecuteQuery();

			TXT_BAST_KE_CA.Text=conn.GetFieldValue("bast_ke_ca");
			TXT_BAST_DARI_CA.Text=conn.GetFieldValue("bast_dari_ca");
			ddl_posisi.SelectedValue=conn.GetFieldValue("posisi_agunan");

			if (ddl_posisi.SelectedValue=="5")
			{
				ddl_notaris_asuransi.Visible=true;
				try{ddl_notaris_asuransi.SelectedValue	= conn.GetFieldValue("NOTARIS_NAME");}
				catch{}
			}

			if (ddl_posisi.SelectedValue=="1")
			{
				BTN_FINISH.Enabled=true;
			}		

			ddl_process.Items.Clear();	
			ddl_process.Items.Add(new ListItem("- PILIH -", ""));
			ddl_process.Items.Add(new ListItem("Simpan Data", "1"));
			ddl_process.Items.Add(new ListItem("Simpan Dokumen di Unit", "2"));
		
			if (Request.QueryString["tc"]=="M1.2")
			{
				ddl_process.Items.Add(new ListItem("Kirim ke CAO", "3"));
			}

			if (Request.QueryString["tc"]=="M1.3")
			{
				//BTN_TO_MKA.Visible=true;
				BTN_FINISH.Enabled=true;
				ddl_process.Items.Add(new ListItem("Kirim Kembali ke MKA", "4"));
				ddl_process.Items.Add(new ListItem("Kirim ke CA", "5"));
			}


			if (Request.QueryString["tc"]=="M1.4" || Request.QueryString["tc"]=="M1.5" || Request.QueryString["tc"]=="M1.6")
			{
				ReadOnlyObject();
			}
			
			if (Request.QueryString["tc"]=="finish")
			{
				ReadOnlyObject();
			}

		}

		private void ReadOnlyObject()
		{
			TXT_BAST_DARI_CA.ReadOnly=true;
			TXT_BAST_KE_CA.ReadOnly=true;
			TXT_CL_BUILDAREA.ReadOnly=true;
			TXT_CL_CERTEXPIREDAY.ReadOnly=true;
			TXT_CL_CERTEXPIREYEAR.ReadOnly=true;
			TXT_CL_CERTISSUEDAY.ReadOnly=true;
			TXT_CL_CERTISSUEYEAR.ReadOnly=true;
			TXT_CL_CERTNO.ReadOnly=true;
			TXT_CL_DESC.ReadOnly=true;
			TXT_CL_LANDAREA.ReadOnly=true;
			TXT_CL_LOCJLN.ReadOnly=true;
			TXT_CL_LOCKAVNO.ReadOnly=true;
			TXT_CL_LOCRT.ReadOnly=true;
			TXT_CL_LOCRW.ReadOnly=true;
			TXT_CL_OWNER.ReadOnly=true;
			
			TXT_CL_VALUE.ReadOnly=true;
			TXT_CL_VALUE2.ReadOnly=true;
			TXT_CL_VALUEIKAT.ReadOnly=true;
			TXT_CL_VALUEINS.ReadOnly=true;
			TXT_CL_VALUELIQ.ReadOnly=true;
			TXT_CL_VALUEPPA.ReadOnly=true;

			ddl_posisi.Enabled=false;
			DDL_CL_PROPTYPE.Enabled=false;
			DDL_CL_CERTEXPIREMONTH.Enabled=false;
			DDL_CL_CERTISSUEMONTH.Enabled=false;
			DDL_CL_CERTTYPE1.Enabled=false;
			DDL_CL_CERTTYPE2.Enabled=false;
			DDL_CL_COLCLASSIFY.Enabled=false;
			DDL_CL_COLLOC.Enabled=false;
			DDL_CL_CURRENCY.Enabled=false;
			DDL_CL_JNSAGUNAN.Enabled=false;
			DDL_CL_RELATIONSHIP.Enabled=false;
			DDL_CL_VALACCRDTO.Enabled=false;

				tr_save.Visible=false;
			ddl_notaris_asuransi.Enabled=false;
		}

		private void SaveField()
		{
			conn.QueryString = "exec MAS_CHANGE_COL_RE 'save','" + LBL_REGNO.Text + "','" + TXT_SIBS_COLID.Text + "'," +
				"'" + Request.QueryString["type"] + "'," +
				"'" + DDL_CL_CERTTYPE1.SelectedValue + "','" + DDL_CL_CERTTYPE2.SelectedValue + "'," +
				"'" + DDL_CL_PROPTYPE.SelectedValue + "','" + TXT_CL_CERTNO.Text + "'," +
				tool.ConvertDate(TXT_CL_CERTISSUEDAY.Text,DDL_CL_CERTISSUEMONTH.SelectedValue,TXT_CL_CERTISSUEYEAR.Text) + "," +
				tool.ConvertDate(TXT_CL_CERTEXPIREDAY.Text,DDL_CL_CERTEXPIREMONTH.SelectedValue,TXT_CL_CERTEXPIREYEAR.Text) + "," +
				"'" + TXT_CL_LANDAREA.Text + "','" + TXT_CL_BUILDAREA.Text + "'," +
				"'" + TXT_CL_OWNER.Text + "','" + DDL_CL_RELATIONSHIP.SelectedValue + "'," +
				tool.ConvertFloat(TXT_CL_VALUE.Text) + "," +
				tool.ConvertFloat(TXT_CL_VALUE2.Text) + "," +
				tool.ConvertFloat(TXT_CL_VALUEPPA.Text) + "," +
				"'','" + TXT_CL_LOCJLN.Text + "','" + TXT_CL_LOCRT.Text + "','" + TXT_CL_LOCRW.Text + "','" + TXT_CL_LOCKAVNO.Text + "'," +
				"'" + DDL_CL_COLLOC.SelectedValue + "','" + DDL_CL_VALACCRDTO.SelectedValue + "','" + DDL_CL_JNSAGUNAN.SelectedValue +"'," +
				tool.ConvertFloat(TXT_CL_VALUE.Text) + "," +
				tool.ConvertFloat(TXT_CL_VALUE2.Text) + "," +
				tool.ConvertFloat(TXT_CL_VALUEINS.Text) + "," +
				tool.ConvertFloat(TXT_CL_VALUEIKAT.Text) + "," +
				tool.ConvertFloat(TXT_CL_VALUEPPA.Text) + "," +
				tool.ConvertFloat(TXT_CL_VALUELIQ.Text) + "," +
				"'"+ TXT_CL_DESC.Text + "'," +
				"'" + DDL_CL_CURRENCY.SelectedValue + "',NULL," +
				"NULL,'" + DDL_CL_COLCLASSIFY.SelectedValue + "'," +
				"'" + Session["userID"] + "','" + TXT_BAST_KE_CA.Text + "','" + TXT_BAST_DARI_CA.Text + "','" + ddl_posisi.SelectedValue + "','" +  lbl_re.Text +"'";
			conn.ExecuteQuery();

			if (ddl_notaris_asuransi.Visible==true && ddl_notaris_asuransi.SelectedValue!="")
			{
				conn.QueryString = "update mas_collateral set NOTARIS_NAME='" + ddl_notaris_asuransi.SelectedValue + "' " +
					"where acc_number='" + LBL_REGNO.Text + "' and collateral_id='" + TXT_SIBS_COLID.Text + "'";
				conn.ExecuteQuery();

			}
		}

		protected void BTN_FINISH_Click(object sender, System.EventArgs e)
		{
			if (TXT_CL_DESC.Text!="" &&
				DDL_CL_CURRENCY.SelectedValue!="" &&
				DDL_CL_COLCLASSIFY.SelectedValue!="" &&
				ddl_posisi.SelectedValue!="" &&
				DDL_CL_CERTTYPE1.SelectedValue!="" &&
				DDL_CL_PROPTYPE.SelectedValue!="" &&
				TXT_CL_CERTNO.Text!="" &&
				TXT_CL_LANDAREA.Text!="" &&
				TXT_CL_OWNER.Text!="" &&
				DDL_CL_RELATIONSHIP.SelectedValue!="" &&
				TXT_CL_VALUE.Text!="" &&
				TXT_CL_VALUE2.Text!="" &&
				TXT_CL_LOCJLN.Text!="" &&
				TXT_CL_LOCRT.Text!="" &&
				TXT_CL_LOCRW.Text!="" &&
				TXT_CL_LOCKAVNO.Text!="" &&
				DDL_CL_COLLOC.SelectedValue!="" &&
				DDL_CL_VALACCRDTO.SelectedValue!="" &&
				DDL_CL_JNSAGUNAN.SelectedValue!="")
			{
				SaveField();
				if (Request.QueryString["tc"]=="M1.3")
				{
					conn.QueryString = "exec MAS_COLLATERAL_TRACKUPDATE '" +
						LBL_REGNO.Text + "' , '" + 
						TXT_SIBS_COLID.Text + "' , 'M1.8' , '" + 
						Session["UserID"].ToString() + "' , '', '6', '" + Request.QueryString["acc_status"] +"'";
					conn.ExecuteQuery();
				}
				else
				{
					conn.QueryString = "exec MAS_COLLATERAL_TRACKUPDATE '" +
						LBL_REGNO.Text + "' , '" + 
						Request.QueryString["collateral_id"] + "' , 'M1.11' , '" + 
						TXT_SIBS_COLID.Text + "' , '', '4', '" + Request.QueryString["acc_status"] +"'";
					conn.ExecuteQuery();
				}
				btn_save.Enabled=false;
				btn_save.Enabled=false;
				BTN_SEND.Enabled=false;
				BTN_FINISH.Enabled=false;
				BTN_TO_MKA.Enabled=false;

			}
			

//			Response.Write("<script>"); Response.Write("parent.document.location.href='" +
//											"../InputNewCollateral/ListCollateral.aspx?tc=" + Request.QueryString["tc"] + "&mc=" + Request.QueryString["mc"] + "';"); Response.Write("");
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

			conn.QueryString = "update MAS_COLLATERAL set CAO_NAME = '" + DDL_CAO_NAME.SelectedValue.ToString() + "'," +
				" SEND_CAO_DATE = '" + DateAndTime.Now.ToString() + "'" +
				" where ACC_NUMBER ='" +LBL_REGNO.Text + "' and collateral_id = '" + TXT_SIBS_COLID.Text + "'";
			conn.ExecuteQuery();

			conn.QueryString = "exec MAS_COLLATERAL_TRACKUPDATE '" +
				LBL_REGNO.Text + "' , '" + 
				TXT_SIBS_COLID.Text + "' , 'M1.3' , '" + 
				Session["UserID"].ToString() + "' , '', '4', '" + Request.QueryString["acc_status"] +"'";
			conn.ExecuteQuery();
			btn_save.Enabled=false;
			BTN_FINISH.Enabled=false;
//			
//			Response.Write("<script>"); Response.Write("parent.document.location.href='" +
//										"../InputNewCollateral/ListCollateral.aspx?tc=" + Request.QueryString["tc"] + "&mc=" + Request.QueryString["mc"] + "';"); Response.Write("");
		}

		protected void BTN_TO_MKA_Click(object sender, System.EventArgs e)
		{
			conn.QueryString = "SELECT SU_UPLINER FROM SCUSER WHERE USERID = '" + Session["UserID"].ToString() + "'";
			conn.ExecuteQuery();

			string upliner = conn.GetFieldValue("SU_UPLINER");

			conn.QueryString = "exec MAS_COLLATERAL_TRACKUPDATE '" +
				LBL_REGNO.Text + "' , '" + 
				TXT_SIBS_COLID.Text + "' , 'M1.2' , '" + 
				Session["UserID"].ToString() + "' , '" + upliner + "', '1', '" + Request.QueryString["acc_status"] +"'";
			conn.ExecuteQuery();
			btn_save.Enabled=false;
			BTN_SEND.Enabled=false;
			BTN_FINISH.Enabled=false;
			BTN_TO_MKA.Enabled=false;
		}

		protected void ddl_process_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if (ddl_process.SelectedValue=="3")
			{
				DDL_CAO_NAME.Visible=true;
			}
			else if (ddl_process.SelectedValue=="5")
			{
				DDL_CA_NAME.Visible=true;
			}
			else
			{
				DDL_CAO_NAME.Visible=false;
				DDL_CA_NAME.Visible=false;
			}

		}

		protected void btn_process_Click(object sender, System.EventArgs e)
		{
			string acc_sta;
			acc_sta=Request.QueryString["acc_status"];			
			acc_sta=(acc_sta).Substring(0,1);

			switch(ddl_process.SelectedValue)		
			{
				case "1":
					if (TXT_CL_DESC.Text!="" &&
				DDL_CL_CURRENCY.SelectedValue!="" &&
				DDL_CL_COLCLASSIFY.SelectedValue!="" &&
				ddl_posisi.SelectedValue!="" &&
				DDL_CL_CERTTYPE1.SelectedValue!="" &&
				DDL_CL_PROPTYPE.SelectedValue!="" &&
				TXT_CL_CERTNO.Text!="" &&
				TXT_CL_LANDAREA.Text!="" &&
				TXT_CL_OWNER.Text!="" &&
				DDL_CL_RELATIONSHIP.SelectedValue!="" &&
				TXT_CL_VALUE.Text!="" &&
				TXT_CL_VALUE2.Text!="" &&
				TXT_CL_LOCJLN.Text!="" &&
				TXT_CL_LOCRT.Text!="" &&
				TXT_CL_LOCRW.Text!="" &&
				TXT_CL_LOCKAVNO.Text!="" &&
				DDL_CL_COLLOC.SelectedValue!="" &&
				DDL_CL_VALACCRDTO.SelectedValue!="" )
					{
						SaveField();
					}
					break;

				case "2":
					if (Request.QueryString["tc"]=="M1.3")
					{
						conn.QueryString = "exec MAS_COLLATERAL_TRACKUPDATE '" +
							LBL_REGNO.Text + "' , '" + 
							TXT_SIBS_COLID.Text + "' , 'M1.8' , '" + 
							Session["UserID"].ToString() + "' , '', '6', '2'";
						conn.ExecuteQuery();
					}
					else
					{
						conn.QueryString = "exec MAS_COLLATERAL_TRACKUPDATE '" +
							LBL_REGNO.Text + "' , '" + 
							Request.QueryString["collateral_id"] + "' , 'M1.11' , '" + 
							TXT_SIBS_COLID.Text + "' , '', '4', '2'";
						conn.ExecuteQuery();
					}
					break;

				case "3":
					if (DDL_CAO_NAME.SelectedValue == "")
					{
						GlobalTools.popMessage(this, "CAO Name tidak boleh kosong!");
						return;	
					}

					/*conn.QueryString = "update MAS_COLLATERAL set posisi_agunan='4' where ACC_NUMBER ='" +Request.QueryString["acc_number"]+ "' and collateral_id = '" +Request.QueryString["collateral_id"]+ "'";
					conn.ExecuteQuery();*/

					conn.QueryString = "update MAS_COLLATERAL set CAO_NAME = '" + DDL_CAO_NAME.SelectedValue.ToString() + "'," +
						" SEND_CAO_DATE = '" + DateAndTime.Now.ToString() + "'" +
						" where ACC_NUMBER ='" +LBL_REGNO.Text + "' and collateral_id = '" + TXT_SIBS_COLID.Text + "'";
					conn.ExecuteQuery();

					conn.QueryString = "exec MAS_COLLATERAL_TRACKUPDATE '" +
						LBL_REGNO.Text + "' , '" + 
						TXT_SIBS_COLID.Text + "' , 'M1.3' , '" + 
						Session["UserID"].ToString() + "' , '', '4', '" + acc_sta +"'";
					conn.ExecuteQuery();

					Page.RegisterStartupScript("RefreshParent","<script language='javascript'>RefreshParent('../InputNewCollateral/ListCollateral.aspx?tc=M1.2&mc=M0102')</script>");

					break;

				case "4" :
					conn.QueryString = "SELECT SU_UPLINER FROM SCUSER WHERE USERID = '" + Session["UserID"].ToString() + "'";
					conn.ExecuteQuery();

					string upliner = conn.GetFieldValue("SU_UPLINER");

					conn.QueryString = "exec MAS_COLLATERAL_TRACKUPDATE '" +
						LBL_REGNO.Text + "' , '" + 
						TXT_SIBS_COLID.Text + "' , 'M1.2' , '" + 
						Session["UserID"].ToString() + "' , '" + upliner + "', '1', '" + acc_sta +"'";
					conn.ExecuteQuery();

					Page.RegisterStartupScript("RefreshParent","<script language='javascript'>RefreshParent('../AcceptanceDataInput/ListAcceptance.aspx?tc=M1.3&mc=M0103')</script>");				

					break;

				case "5":
					if (DDL_CA_NAME.SelectedValue == "")
					{
						GlobalTools.popMessage(this, "CA Name tidak boleh kosong!");
						return;	
					}
					
			
					conn.QueryString = "update MAS_COLLATERAL set CA_NAME = '" + DDL_CA_NAME.SelectedValue.ToString() + "'," +
						" SEND_CA_DATE = '" + DateAndTime.Now.ToString() + "'" +
						" where ACC_NUMBER ='" +LBL_REGNO.Text + "' and collateral_id = '" +TXT_SIBS_COLID.Text+ "'";
					conn.ExecuteQuery();

					conn.QueryString = "exec MAS_COLLATERAL_TRACKUPDATE '" +
						LBL_REGNO.Text + "' , '" + 
						TXT_SIBS_COLID.Text + "' , 'M1.4' , '" + 
						Session["UserID"].ToString() + "' , '', '2', '" + acc_sta +"'";
					conn.ExecuteQuery();

					Page.RegisterStartupScript("RefreshParent","<script language='javascript'>RefreshParent('../AcceptanceDataInput/ListAcceptance.aspx?tc=M1.3&mc=M0103')</script>");				

					break;					
			}
		}

		protected void ddl_posisi_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if (ddl_posisi.SelectedValue=="5")
			{
				ddl_notaris_asuransi.Visible=true;
			}
			else
			{
				ddl_notaris_asuransi.Visible=false;
			}
		}
	}
}
