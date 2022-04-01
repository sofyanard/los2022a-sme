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

namespace SME.MAS.CollateralAdministration.DetailCollateral
{
	/// <summary>
	/// Summary description for Collateral_Bond.
	/// </summary>
	public partial class Collateral_Bond : System.Web.UI.Page
	{
		protected Connection conn = new Connection(ConfigurationSettings.AppSettings["conn"]);
		protected Tools tool = new Tools();
			
		protected void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			//conn = (Connection) Session["Connection"];
			if(!IsPostBack)
			{
				DLLAll();	
				btn_save.Attributes.Add("onClick","return cek_mandatory(document.Form1);");
				TXT_SIBS_COLID.Text=Request.QueryString["collateral_id"];
				LBL_REGNO.Text=Request.QueryString["acc_number"];

				conn.QueryString = "select coltypedesc from rfcollateraltype where coltypeseq='"+ Request.QueryString["type"] + "'" ;
				conn.ExecuteQuery();			

				lbl_bond.Text=conn.GetFieldValue("coltypedesc");

				FillField();
			}
			
		}

		private void NewCol()
		{
			TXT_CL_COLLAMOUNT.Text="";
			TXT_CL_CONDITION.Text="";
			TXT_CL_DESC.Text="";
			TXT_CL_DUEDATEDAY.Text="";
			TXT_CL_DUEDATEYEAR.Text="";
			TXT_CL_ISSUEDBY.Text="";
			TXT_CL_ISSUEDDATEDAY.Text="";
			TXT_CL_ISSUEDDATEYEAR.Text="";
			TXT_CL_OWNER.Text="";
			TXT_CL_REGDATEDAY.Text="";
			TXT_CL_REGDATEYEAR.Text="";
			TXT_CL_REGNO.Text="";
			TXT_CL_SECURITYNO.Text="";
			TXT_CL_VALUE.Text="";
			TXT_CL_VALUE2.Text="";
			TXT_CL_VALUEIKAT.Text="";
			TXT_CL_VALUEINS.Text="";
			TXT_CL_VALUELIQ.Text="";
			TXT_CL_VALUEPPA.Text="";
			TXT_SIBS_COLID.Text="";

			DDL_CL_BONDTYPE.SelectedValue="";
			DDL_CL_COLCLASSIFY.SelectedValue="";
			DDL_CL_CURRENCY.SelectedValue="";
			DDL_CL_DUEDATEMONTH.SelectedValue="";
			DDL_CL_IKATTYPE.SelectedValue="";
			DDL_CL_ISSUEDDATEMONTH.SelectedValue="";
			DDL_CL_JNSAGUNAN.SelectedValue="";
			DDL_CL_PERINGKAT.SelectedValue="";
			DDL_CL_REGDATEMONTH.SelectedValue="";
			DDL_CL_RELATIONSHIP.SelectedValue="";
			DDL_CL_VALACCRDTO.SelectedValue="";						
			CHB_CL_ISCASHEDVALUE.Checked=false;
		}

		private void DLLAll()
		{
			DDL_CL_CURRENCY.Items.Add(new ListItem("- PILIH -", ""));
			DDL_CL_COLCLASSIFY.Items.Add(new ListItem("- PILIH -", ""));
			DDL_CL_BONDTYPE.Items.Add(new ListItem("- PILIH -", ""));
			DDL_CL_RELATIONSHIP.Items.Add(new ListItem("- PILIH -", ""));
			DDL_CL_REGDATEMONTH.Items.Add(new ListItem("- PILIH -", ""));
			DDL_CL_ISSUEDDATEMONTH.Items.Add(new ListItem("- PILIH -", ""));
			DDL_CL_DUEDATEMONTH.Items.Add(new ListItem("- PILIH -", ""));
			DDL_CL_IKATTYPE.Items.Add(new ListItem("- PILIH -", ""));
			DDL_CL_VALACCRDTO.Items.Add(new ListItem("- PILIH -", ""));
			DDL_CL_PERINGKAT.Items.Add(new ListItem("- PILIH -", ""));
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

			for (int i=1; i<=12; i++)
			{
				DDL_CL_REGDATEMONTH.Items.Add(new ListItem(DateAndTime.MonthName(i, false), i.ToString()));
				DDL_CL_ISSUEDDATEMONTH.Items.Add(new ListItem(DateAndTime.MonthName(i, false), i.ToString()));
				DDL_CL_DUEDATEMONTH.Items.Add(new ListItem(DateAndTime.MonthName(i, false), i.ToString()));
			}
				
			string de = Request.QueryString["de"];
				
			//--- Mata Uang
			conn.QueryString = "select CURRENCYID, CURRENCYID + ' - ' + CURRENCYDESC as CURRENCYDESC from RFCURRENCY where ACTIVE = '1' order by CURRENCYID";
			conn.ExecuteQuery();
			for (int i=0; i< conn.GetRowCount(); i++)
				DDL_CL_CURRENCY.Items.Add(new ListItem(conn.GetFieldValue(i, 1), conn.GetFieldValue(i, 0)));

			conn.QueryString = "select COLCLASSID, COLCLASSDESC from RFCOLLCLASS where active='1'";
			conn.ExecuteQuery();
			for (int i=0; i< conn.GetRowCount(); i++)
				DDL_CL_COLCLASSIFY.Items.Add(new ListItem(conn.GetFieldValue(i, 1), conn.GetFieldValue(i, 0)));

			//--- Hubungan
			conn.QueryString = "select RELTYPEID, RELTYPEID+' - '+RELTYPEDESC from RFRELATIONSHIP where active='1'";
			conn.ExecuteQuery();
			for (int i=0; i< conn.GetRowCount(); i++)
				DDL_CL_RELATIONSHIP.Items.Add(new ListItem(conn.GetFieldValue(i, 1), conn.GetFieldValue(i, 0)));

			//--- Jenis Pengikatan
			conn.QueryString = "select IKATID, IKATID + ' - ' + IKATDESC AS IKATDESC from RFIKAT where active = '1' order by IKATID";
			conn.ExecuteQuery();
			for (int i=0; i< conn.GetRowCount(); i++)
				DDL_CL_IKATTYPE.Items.Add(new ListItem(conn.GetFieldValue(i, 1), conn.GetFieldValue(i, 0)));
				
			conn.QueryString = "select ACCRDTOID, ACCRDTODESC from RFVALUEACCORDING where active='1'";
			conn.ExecuteQuery();
			for (int i=0; i< conn.GetRowCount(); i++)
				DDL_CL_VALACCRDTO.Items.Add(new ListItem(conn.GetFieldValue(i, 1), conn.GetFieldValue(i, 0)));

			//--- Jenis Agunan
			conn.QueryString = "select AGUNANID, AGUNANID + ' - ' + AGUNANDESC AS AGUNANDESC from RFJENISAGUNAN WHERE ACTIVE ='1' order by AGUNANID";
			//"where COLTYPEID = '"+ CL_TYPE +"'";
			conn.ExecuteQuery();
			for (int i=0; i< conn.GetRowCount(); i++)
				DDL_CL_JNSAGUNAN.Items.Add(new ListItem(conn.GetFieldValue(i, 1), conn.GetFieldValue(i, 0)));

			//--- Peringkat Surat Berharga
			conn.QueryString = "select PSBID, PSBID + ' - ' + PSBDESC AS PSBDESC from RFPERINGKATSRTHRG where ACTIVE='1' order by PSBID";
			conn.ExecuteQuery();
			for (int i = 0; i < conn.GetRowCount(); i++)
				DDL_CL_PERINGKAT.Items.Add(new ListItem(conn.GetFieldValue(i,1), conn.GetFieldValue(i,0)));

			conn.QueryString = "select * from RFBONDTYPE where active='1'";
			conn.ExecuteQuery();
			for (int i = 0; i < conn.GetRowCount(); i++)
				DDL_CL_BONDTYPE.Items.Add(new ListItem(conn.GetFieldValue(i,1), conn.GetFieldValue(i,0)));
		}

		private void FillField()
		{
			DLLAll();

			conn.QueryString = "exec MAS_CHANGE_COL_BOND 'get'," +
				"'"+ Request.QueryString["acc_number"] +"','"+ Request.QueryString["collateral_id"] +"',''," +
				"'','','','','','','','','','','','','','','','','','',''" +
				"'','','','','','','','','','','','','','','','','',''";
			conn.ExecuteQuery();

			TXT_CL_COLLAMOUNT.Text=conn.GetFieldValue("CL_COLLAMOUNT");
			TXT_CL_CONDITION.Text=conn.GetFieldValue("CL_CONDITION");
			TXT_CL_DUEDATEDAY.Text=tool.FormatDate_Day(conn.GetFieldValue("CL_DUEDATE"));
			TXT_CL_DUEDATEYEAR.Text=tool.FormatDate_Year(conn.GetFieldValue("CL_DUEDATE"));
			TXT_CL_ISSUEDBY.Text=conn.GetFieldValue("CL_ISSUEDBY");
			TXT_CL_ISSUEDDATEDAY.Text=tool.FormatDate_Day(conn.GetFieldValue("CL_ISSUEDDATE"));
			TXT_CL_ISSUEDDATEYEAR.Text=tool.FormatDate_Year(conn.GetFieldValue("CL_ISSUEDDATE"));
			TXT_CL_OWNER.Text=conn.GetFieldValue("CL_OWNER");
			TXT_CL_REGDATEDAY.Text=tool.FormatDate_Day(conn.GetFieldValue("CL_REGDATE"));
			TXT_CL_REGDATEYEAR.Text=tool.FormatDate_Year(conn.GetFieldValue("CL_REGDATE"));
			TXT_CL_REGNO.Text=conn.GetFieldValue("CL_REGNO");
			TXT_CL_SECURITYNO.Text=conn.GetFieldValue("CL_SECURITYNO");			
			TXT_CL_VALUEPPA.Text=conn.GetFieldValue("CL_PPAPVAL");
			TXT_SIBS_COLID.Text=conn.GetFieldValue("COLLATERAL_ID");			
			if (conn.GetFieldValue("CL_ISCASHEDVALUE")=="1")
			{
				CHB_CL_ISCASHEDVALUE.Checked=true;
			}
			else
			{
				CHB_CL_ISCASHEDVALUE.Checked=false;
			}

			DDL_CL_BONDTYPE.SelectedValue=conn.GetFieldValue("CL_BONDTYPE");			
			TXT_CL_VALUE2.Text=conn.GetFieldValue("CL_MARKETVALUE");			

			DDL_CL_DUEDATEMONTH.SelectedValue="";
			DDL_CL_IKATTYPE.SelectedValue=conn.GetFieldValue("CL_IKATTYPE");			
			DDL_CL_ISSUEDDATEMONTH.SelectedValue="";
			DDL_CL_JNSAGUNAN.SelectedValue=conn.GetFieldValue("CL_JNSAGUNAN");			
			DDL_CL_PERINGKAT.SelectedValue=conn.GetFieldValue("CL_PERINGKAT");			
			DDL_CL_REGDATEMONTH.SelectedValue="";
			DDL_CL_RELATIONSHIP.SelectedValue=conn.GetFieldValue("CL_RELATIONSHIP");
			DDL_CL_VALACCRDTO.SelectedValue=conn.GetFieldValue("CL_VALACCRDTO");			

			conn.QueryString = "exec MAS_CHANGE_COL_VALUE 'get'," +
				"'"+ Request.QueryString["acc_number"] +"','"+ Request.QueryString["collateral_id"] +"'," +
				"'','','','','','','','','','','',''";
			conn.ExecuteQuery();

			TXT_CL_DESC.Text =conn.GetFieldValue("CL_DESC");
			TXT_CL_VALUE.Text=conn.GetFieldValue("CL_VALUE");			
			TXT_CL_VALUE2.Text=conn.GetFieldValue("CL_VALUE2");			
			TXT_CL_VALUEIKAT.Text=conn.GetFieldValue("CL_VALUEIKAT");
			TXT_CL_VALUEINS.Text=conn.GetFieldValue("CL_VALUEINS");
			TXT_CL_VALUELIQ.Text=conn.GetFieldValue("CL_VALUELIQ");

			DDL_CL_COLCLASSIFY.SelectedValue=conn.GetFieldValue("CL_COLCLASSIFY");
			DDL_CL_CURRENCY.SelectedValue=conn.GetFieldValue("CL_CURRENCY");

			conn.QueryString = "select * from mas_collateral where acc_number='" + LBL_REGNO.Text + "' and collateral_id='" + TXT_SIBS_COLID.Text + "'";
			conn.ExecuteQuery();

			TXT_BAST_KE_CA.Text=conn.GetFieldValue("bast_ke_ca");
			TXT_BAST_DARI_CA.Text=conn.GetFieldValue("bast_dari_ca");
			ddl_posisi.SelectedValue=conn.GetFieldValue("posisi_agunan");

			if (ddl_posisi.SelectedValue=="1")
			{
				BTN_FINISH.Enabled=true;
			}		
		}

		private void SaveUpdateData()
		{
			string cash="0";
			if (CHB_CL_ISCASHEDVALUE.Checked==true)
			{
				cash="1";
			}

			
				conn.QueryString = "exec MAS_CHANGE_COL_BOND 'insert'," +
					"'"+ Request.QueryString["acc_number"] +"','"+ TXT_SIBS_COLID.Text + "'," +
					"'" + Request.QueryString["type"] + "'," +
					"'" + DDL_CL_BONDTYPE.SelectedValue + "'," +
					"'" + cash + "'," +
					"'" + TXT_CL_REGNO.Text + "'," + 
					"'" + TXT_CL_SECURITYNO.Text + "'," +
					tool.ConvertFloat(TXT_CL_VALUE2.Text) + "," +
					tool.ConvertDate(TXT_CL_REGDATEDAY.Text,DDL_CL_REGDATEMONTH.SelectedValue,TXT_CL_REGDATEYEAR.Text)+ "," + 
					"'" + TXT_CL_ISSUEDBY.Text + "'," +
					tool.ConvertDate(TXT_CL_ISSUEDDATEDAY.Text,DDL_CL_ISSUEDDATEMONTH.SelectedValue,TXT_CL_ISSUEDDATEYEAR.Text)+ "," + 
					tool.ConvertDate(TXT_CL_DUEDATEDAY.Text,DDL_CL_DUEDATEMONTH.SelectedValue,TXT_CL_DUEDATEYEAR.Text)+ "," + 
					"'" + TXT_CL_CONDITION.Text + "'," +
					"'" + TXT_CL_OWNER.Text + "'," +
					"'" + DDL_CL_RELATIONSHIP.SelectedValue + "'," +
					"'" + TXT_CL_COLLAMOUNT.Text +"'," +
					"'" + DDL_CL_IKATTYPE.SelectedValue +"'," +
					"'" + DDL_CL_VALACCRDTO.SelectedValue + "'," +
					"'" + DDL_CL_PERINGKAT.SelectedValue + "'," +
					"'" + DDL_CL_JNSAGUNAN.SelectedValue + "'," +
					tool.ConvertFloat(TXT_CL_VALUEPPA.Text) + "," +
					"'',NULL,NULL,"+
				tool.ConvertFloat(TXT_CL_VALUE.Text) + "," +
				tool.ConvertFloat(TXT_CL_VALUE2.Text) + "," +
				tool.ConvertFloat(TXT_CL_VALUEINS.Text) + "," +
				tool.ConvertFloat(TXT_CL_VALUEIKAT.Text) + "," +
				tool.ConvertFloat(TXT_CL_VALUEPPA.Text) + "," +
				tool.ConvertFloat(TXT_CL_VALUELIQ.Text) + "," +
				"'" + TXT_CL_DESC.Text + "'," +
				"'" + DDL_CL_CURRENCY.SelectedValue + "'," +
				"NULL,NULL," +
				"'" + DDL_CL_COLCLASSIFY.SelectedValue + "'," +
				"'" + Session["userID"] + "','" + TXT_BAST_KE_CA.Text + "','" + TXT_BAST_DARI_CA.Text + "','" + ddl_posisi.SelectedValue + "','" + lbl_bond.Text + DDL_CL_BONDTYPE.SelectedItem.Text + "'";
				conn.ExecuteQuery();			
			
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
			if (ddl_posisi.SelectedValue=="1")
			{
				BTN_FINISH.Enabled=true ;
			}
			if (TXT_CL_DESC.Text!="" &&
				DDL_CL_CURRENCY.SelectedValue!="" &&
				DDL_CL_COLCLASSIFY.SelectedValue!="" &&
				ddl_posisi.SelectedValue!="" &&
				TXT_CL_SECURITYNO.Text!="" &&
				TXT_CL_VALUE.Text!="" &&
				TXT_CL_VALUE2.Text!="" &&
				TXT_CL_OWNER.Text!="" &&
				TXT_CL_COLLAMOUNT.Text!="" &&
				DDL_CL_RELATIONSHIP.SelectedValue!="" &&
				DDL_CL_JNSAGUNAN.SelectedValue!="" &&
				DDL_CL_VALACCRDTO.SelectedValue!="" &&
				DDL_CL_IKATTYPE.SelectedValue!="")

			{
				SaveUpdateData();
			}
		}

		protected void BTN_FINISH_Click(object sender, System.EventArgs e)
		{
			if (TXT_CL_DESC.Text!="" &&
				DDL_CL_CURRENCY.SelectedValue!="" &&
				DDL_CL_COLCLASSIFY.SelectedValue!="" &&
				ddl_posisi.SelectedValue!="" &&
				TXT_CL_SECURITYNO.Text!="" &&
				TXT_CL_VALUE.Text!="" &&
				TXT_CL_VALUE2.Text!="" &&
				TXT_CL_OWNER.Text!="" &&
				TXT_CL_COLLAMOUNT.Text!="" &&
				DDL_CL_RELATIONSHIP.SelectedValue!="" &&
				DDL_CL_JNSAGUNAN.SelectedValue!="" &&
				DDL_CL_VALACCRDTO.SelectedValue!="" &&
				DDL_CL_IKATTYPE.SelectedValue!="")

			{
				SaveUpdateData();
				conn.QueryString = "exec MAS_COLLATERAL_TRACKUPDATE '" +
					LBL_REGNO.Text + "' , '" + 
					TXT_SIBS_COLID.Text + "' , 'M1.8' , '" + 
					Session["UserID"].ToString() + "' , '', '6', '" + Request.QueryString["status"] +"'";
				conn.ExecuteQuery();
				btn_save.Enabled=false;BTN_SEND.Enabled=false;
			}
			
			
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
				Session["UserID"].ToString() + "' , '', '4', '" + Request.QueryString["status"] +"'";
			conn.ExecuteQuery();
			btn_save.Enabled=false;BTN_FINISH.Enabled=false;
		}
	}
}
