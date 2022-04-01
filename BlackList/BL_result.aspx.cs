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
using System.Globalization;
using System.IO;

namespace SME.BlackList
{
	/// <summary>
	/// Summary description for WebForm1. 
	/// </summary>
	public partial class BL_result : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.TextBox TextBox2;
		//protected DataTable dt1,dt2 = new DataTable();

		#region Local Variables

		protected Tools tool = new Tools();
		protected Connection conn;
		private string mainregno, maincuref, regno, curef, prog, tc, mc, exist, presco, mainprod_seq, mainproductid;

		#endregion				



		string GetFieldValue(DataTable dt, int idx, string col)
		{
			return dt.Rows[idx][col].ToString().Trim();
		}

		string GetFieldValuecol(DataTable dt, int idx, int col)
		{
			return dt.Rows[idx][col].ToString().Trim();
		}

		int GetRowCount(DataTable dt)
		{
			return dt.Rows.Count;
		}

		int GetColCount(DataTable dt)
		{
			return dt.Columns.Count;
		}

		DataTable sqlQuery(string str)
		{
			conn.QueryString=str;
			conn.ExecuteQuery();
			return conn.GetDataTable().Copy();
		}
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			conn = (Connection) Session["Connection"];	

			mainregno	= Request.QueryString["mainregno"];
			mainprod_seq	= Request.QueryString["mainprod_seq"];
			mainproductid	= Request.QueryString["mainproductid"];
			maincuref	= Request.QueryString["maincuref"];
			regno		= Request.QueryString["regno"];
			curef		= Request.QueryString["curef"];
			prog		= Request.QueryString["prog"];
			tc			= Request.QueryString["tc"];
			mc			= Request.QueryString["mc"];
			exist		= Request.QueryString["exist"];
			presco		= Request.QueryString["presco"];

			// jika ada flag prescoring, disable button reject
			if ((presco != "") && (presco != null)) Button3.Visible = false;
			
				if (Request.QueryString["bl"] == "0")  BTN_BACK.Visible = true;
			if (mainregno == "" || mainregno == null) ViewMenu();


			if (!IsPostBack)
			{
				secureData();
						
				TXT_AP_REGNO.Text = Request.QueryString["regno"];
				TXT_CU_REF.Text = Request.QueryString[1];					

//				string sql =	"select distinct  " +
//					"case when CU_COMPNAME is null then 'personal' else 'company' end STATUS , " +
//					"case when CU_COMPNAME is null then isnull(CU_FIRSTNAME,'')+' '+isnull(CU_MIDDLENAME,'')+' '+isnull(CU_LASTNAME,'') else CU_COMPNAME end NAME , " +
//					"case when CU_COMPNAME is null then isnull(CU_ADDR1,'')+' '+isnull(CU_ADDR2,'')+' '+isnull(CU_ADDR3,'') else isnull(CU_COMPADDR1,'')+' '+isnull(CU_COMPADDR2,'')+' '+isnull(CU_COMPADDR3,'') end ADDR, " +
//					"case when CU_COMPNAME is null then RFCITY.CITYNAME else ct.CITYNAME end CITY, " +
//					"case when CU_COMPNAME is null then CU_IDCARDNUM else CU_NPWP end IDCARD, " +
//					"case when CU_COMPNAME is null then CU_DOB else CU_COMPESTABLISH end DOB, " +
//					"case when CU_COMPNAME is null then CU_PHNAREA+CU_PHNNUM else CU_COMPPHNAREA+CU_COMPPHNNUM end TELP,  " +
//					"case when CU_COMPNAME is null then '' else isnull(CS_FIRSTNAME,'')+' '+isnull(CS_MIDDLENAME,'')+' '+isnull(CS_LASTNAME,'') end nama_pengurus,  " +
//					"case when CU_COMPNAME is null then '' else CS_IDCARDNUM end id_pengurus  " +
//					"from application  " +
//					"left join cust_personal on application.cu_ref = cust_personal.cu_ref  " +
//					"left join cust_company on application.cu_ref = cust_company.cu_ref  " +
//					"left join customer on application.cu_ref = customer.cu_ref  " +
//					"left join RFCITY on cust_personal.CU_CITY  = RFCITY.CITYID  " +					
//					"left join cust_stockholder on application.cu_ref = cust_stockholder.cu_ref "+
//					"left join RFCITY ct on cust_company.CU_COMPCITY  = ct.CITYID where application.CU_REF = '" +Request.QueryString["curef"]+ "' ";

				string sql = "select * from VW_BL_LISTPENGURUS where CU_REF = '" + Request.QueryString["curef"] + "'";
				conn.QueryString = sql;
				conn.ExecuteQuery();
				TXT_NAME.Text			= conn.GetFieldValue("NAME").Trim();
				TXT_ADDRESS1.Text		= conn.GetFieldValue("ADDR").Trim();			
				TXT_KTPNO.Text		= conn.GetFieldValue("IDCARD").Trim();			
				TXT_CITY.Text			= conn.GetFieldValue("CITY");			
				TXT_PHNNO.Text			= conn.GetFieldValue("TELP");
				LBL_CU_CUSTTYPEID.Text = conn.GetFieldValue("STATUS");
				TXT_TGLLAHIR.Text	= conn.GetFieldValue("DOB");

				for (int i = 0;i < conn.GetRowCount();i++)
				{					
					LST_PENGURUS.Items.Add(new ListItem (conn.GetFieldValue(i,"nama_pengurus")+":"+conn.GetFieldValue(i,"id_pengurus")));				
				}

				/**
				sql = "select PRODUCTDESC from application a  " +
					"left join custproduct b on a.ap_regno = b.ap_regno  " +
					"left join rfproduct c on b.productid = c.productid where a.ap_regno = '"+Request.QueryString["regno"]+"'";
				**/
				sql = "select * from VW_KETENTUANPRODUCTLIST where ap_regno = '" + Request.QueryString["regno"] + "'";
				conn.QueryString = sql;
				conn.ExecuteQuery();
				LST_PRODUCT.Items.Clear();
				for (int i=0; i<conn.GetRowCount(); i++)
				{								
					LST_PRODUCT.Items.Add(new ListItem ( conn.GetFieldValue(i, "KET_DESC") + " / " + conn.GetFieldValue(i, "APPTYPEDESC") + " / " + conn.GetFieldValue(i, "PRODUCTDESC") ));
				}

				GlobalTools.fillRefList(DDL_BLKRITERIA, "select * from RFBlKRITERIA where ACTIVE = '1'", false, conn);
				GlobalTools.fillRefList(DDL_BLKRITERIAVALUE, "select * from RFBlKRITERIAVALUE where ACTIVE = '1'", false, conn);

				/*string xsts_debitur;
				if (LBL_CU_CUSTTYPEID.Text == "company") {xsts_debitur = "01";}
				else { xsts_debitur = "02"; }			
				//GlobalTools.fillRefList(DDL_BLKRITERIAVALUE, "select * from RFBlKRITERIAVALUE where ACTIVE = '1' and (CUSTTYPEID is null or CUSTTYPEID ='" + xsts_debitur + "')", false, conn);*/

				viewData();
			} //--- END if (!IsPostBack) ---
		}

		private void viewData() 
		{
			ViewBlackList(); // menampilkan data black list
			viewMemo();
		}

		private void secureData() 
		{	
			if (Request.QueryString["bl"] == "0") 
			{
				//secure data
				TXT_MEMO.ReadOnly = true;
				
				RDO_BI_BL_PEMILIK.Enabled		= false;
				RDO_BI_BL_PERUSAHAAN.Enabled	= false;
				RDO_BI_BL_MGMT.Enabled			= false;
				RDO_BI_BL_PERNAH.Enabled		= false;

				RDO_BM_BL_MGMT.Enabled			= false;
				RDO_BM_BL_PEMILIK.Enabled		= false;
				RDO_BM_BL_PERUSAHAAN.Enabled	= false;
				RDO_BM_BL_PERNAH.Enabled		= false;
			}
		}

		private void viewMemo() 
		{
			conn.QueryString = "select AP_BLMEMO from APPLICATION where AP_REGNO = '"+Request.QueryString["regno"]+"'";
			conn.ExecuteQuery();

			TXT_MEMO.Text = conn.GetFieldValue("AP_BLMEMO");
		}

		private void ViewBlackList()
		{
			// mengambil data blacklist
			try 
			{
				conn.QueryString = "SELECT AP_BLBMPEMILIK,AP_BLBMMGMT,AP_BLBMUSAHA,";
				conn.QueryString += "AP_BLBIPEMILIK,AP_BLBIMGMT,AP_BLBIUSAHA, AP_BLBMPERNAH, AP_BLBIPERNAH";
				conn.QueryString += " FROM APPLICATION WHERE AP_REGNO = '" + regno + "'";
				conn.ExecuteQuery();
			} 
			catch (NullReferenceException) 
			{
				GlobalTools.popMessage(this, "Connection Error!");
				Response.Redirect("../Login.aspx?expire=1");
			} 
			
			// mengeset radio button yang harus diselect sesuai dengan state di database
			try {RDO_BI_BL_MGMT.SelectedValue = conn.GetFieldValue("AP_BLBIMGMT");} 
			catch {RDO_BI_BL_MGMT.SelectedValue = "0";}

			try {RDO_BI_BL_PEMILIK.SelectedValue = conn.GetFieldValue("AP_BLBIPEMILIK");}
			catch {RDO_BI_BL_PEMILIK.SelectedValue = "0";}
			
			try {RDO_BI_BL_PERUSAHAAN.SelectedValue = conn.GetFieldValue("AP_BLBIUSAHA");}
			catch {RDO_BI_BL_PERUSAHAAN.SelectedValue = "0";}

			try {RDO_BM_BL_MGMT.SelectedValue = conn.GetFieldValue("AP_BLBMMGMT");}
			catch {RDO_BM_BL_MGMT.SelectedValue = "0";}

			try {RDO_BM_BL_PEMILIK.SelectedValue = conn.GetFieldValue("AP_BLBMPEMILIK");}
			catch {RDO_BM_BL_PEMILIK.SelectedValue = "0";}

			try {RDO_BM_BL_PERUSAHAAN.SelectedValue = conn.GetFieldValue("AP_BLBMUSAHA");}
			catch {RDO_BM_BL_PERUSAHAAN.SelectedValue = "0";}

			try {RDO_BM_BL_PERNAH.SelectedValue = conn.GetFieldValue("AP_BLBMPERNAH");}
			catch {RDO_BM_BL_PERNAH.SelectedValue = "0";}

			try {RDO_BI_BL_PERNAH.SelectedValue = conn.GetFieldValue("AP_BLBIPERNAH");}
			catch {RDO_BI_BL_PERNAH.SelectedValue = "0";}

		}

		private void ViewMenu()
		{
			try 
			{
				conn.QueryString = "select * from SCREENMENU where menucode = '"+Request.QueryString["mc"]+"'";
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
							strtemp = "regno=" + Request.QueryString["regno"] + "&curef="+Request.QueryString["curef"]+"&tc="+Request.QueryString["tc"]+"&";
						else	strtemp = "regno=" + Request.QueryString["regno"] + "&curef="+Request.QueryString["curef"]+"&mc="+Request.QueryString["mc"]+"&tc="+Request.QueryString["tc"]+"&";
						//t.ForeColor = Color.MidnightBlue; 

						if (conn.GetFieldValue(i,3).IndexOf("?bl=") < 0 && conn.GetFieldValue(i,3).IndexOf("&bl=") < 0) 
							strtemp = strtemp + "&bl=" + Request.QueryString["bl"];

						//---  untuk general info
						if (conn.GetFieldValue(i,3).IndexOf("?exist=") < 0 && conn.GetFieldValue(i,3).IndexOf("&exist=") < 0) 
							strtemp = strtemp + "&exist=" + Request.QueryString["exist"];	

						//--- untuk program yang dipilih
						if (conn.GetFieldValue(i,3).IndexOf("?prog=") < 0 && conn.GetFieldValue(i,3).IndexOf("&prog=") < 0) 
							strtemp = strtemp + "&prog=" + Request.QueryString["prog"];	

					}
					else 
					{
						strtemp = "";
						t.ForeColor = Color.Red; 
					}
					t.NavigateUrl = conn.GetFieldValue(i, 3)+strtemp;
					Menu.Controls.Add(t);
					Menu.Controls.Add(new LiteralControl("&nbsp;&nbsp;&nbsp;"));
				}
			} 
			catch (Exception ex) 
			{
				string temp = ex.ToString();
			}
		}

		void check_bl(string sts_debitur,string curef,ref bool locResultbl,ref DataTable dt1)
		{
			string sql = "";			
			//string sqlname = "";
			string REF_COLUMN = "";
			string REF_COLUMN_VAL = "";
			string REF_BLCOLUMN = "";
			DataTable dtinfo = new DataTable();

			//DEBUG
			Response.Write("<!-- sts_debitur : " + sts_debitur + " -->");
			

			if (sts_debitur == "1")	//company
			{					
				sql = "exec BL_CUSTOMERINFO '" + sts_debitur + "', '" + curef + "', '" + DDL_BLKRITERIA.SelectedValue + "'";
				conn.QueryString = sql;
				conn.ExecuteQuery();
				dtinfo = conn.GetDataTable().Copy();

				//DEBUG
				//Response.Write("<!-- " + sql + " -->");

				conn.QueryString = "select REF_BLCOLUMN, REF_COLUMN from RFBLKRITERIAVALUE where VALUECODE = '" + DDL_BLKRITERIAVALUE.SelectedValue + "'";
				conn.ExecuteQuery();

				//DEBUG
				//Response.Write("<!-- " + conn.QueryString.ToString() + " -->");

				if (dtinfo.Rows.Count == 0 || conn.GetRowCount() == 0) return;

				REF_BLCOLUMN = conn.GetFieldValue("REF_BLCOLUMN");
				REF_COLUMN = conn.GetFieldValue("REF_COLUMN");
				try { REF_COLUMN_VAL = dtinfo.Rows[0][REF_COLUMN].ToString(); }
				catch {}

				//DEBUG
				//Response.Write("<!-- REF_BLCOLUMN : " + REF_BLCOLUMN + " -->");
				//Response.Write("<!-- REF_COLUMN : " + REF_COLUMN + " -->");
				//Response.Write("<!-- REF_COLUMN_VAL : " + REF_COLUMN_VAL + " -->");


				//sql = "exec BL_CHECKBLACKLIST '" + REF_BLCOLUMN + "','" + REF_COLUMN + "', '" + REF_COLUMN_VAL + "'";

				////////////////////////////////////////////////
				///	kalau kriteria NAMA
				///	
				if (DDL_BLKRITERIAVALUE.SelectedValue == "1")	// CUST_NAME
				{
					/***
					sql = "select top 100 ISNULL(ltrim(rtrim(CUST_NAME1)),'') + ' ' + ISNULL(ltrim(rtrim(CUST_NAME2)),'') + ' ' + ISNULL(ltrim(rtrim(CUST_NAME3)),'') [NAME], " + 
						"CUST_IDTYPE IDTYPE, CUST_ID IDNO, ADDR1 ADDR, SC_DESC SR, RR_DESC RR, " +
						"EXPIRE_DATE [EXP] " + 
						"FROM BL_COMPPERSONAL A LEFT JOIN BL_SOURCECODE B ON A.SC_CODE = B.SC_CODE " + 
						"LEFT JOIN BL_REJECTREASON C ON A.RS_CODE = C.RR_CODE WHERE " +
						"(ltrim(rtrim(cust_name1)) like  '%" + dtinfo.Rows[0]["NAME1"].ToString() + "%' or ltrim(rtrim(cust_name1)) like '%" + dtinfo.Rows[0]["NAME2"].ToString() + "%' or ltrim(rtrim(cust_name1)) like '%" + dtinfo.Rows[0]["NAME3"].ToString() + "%') " +
						"or " +
						"(ltrim(rtrim(cust_name2)) like  '%" + dtinfo.Rows[0]["NAME1"].ToString() + "%' or ltrim(rtrim(cust_name2)) like '%" + dtinfo.Rows[0]["NAME2"].ToString() + "%' or ltrim(rtrim(cust_name2)) like '%" + dtinfo.Rows[0]["NAME3"].ToString() + "%') " +
						"or " + 
						"(ltrim(rtrim(cust_name3)) like  '%" + dtinfo.Rows[0]["NAME1"].ToString() + "%' or ltrim(rtrim(cust_name3)) like '%" + dtinfo.Rows[0]["NAME2"].ToString() + "%' or ltrim(rtrim(cust_name3)) like '%" + dtinfo.Rows[0]["NAME3"].ToString() + "%') ";
					***/

					/***
					sql = "exec BL_CHECKBLACKLIST1 '" + 
							dtinfo.Rows[0]["NAME1"].ToString() + "', '" + 
							dtinfo.Rows[0]["NAME2"].ToString() + "', '" + 
							dtinfo.Rows[0]["NAME3"].ToString() + "'";
					***/

					sql = "exec BL_CHECKBLACKLIST2 '" + sts_debitur + "', '" + curef + "', '" + DDL_BLKRITERIA.SelectedValue + "'";
				}
				else // Kriteria CUST_ID
				{
					string subsql = "";
					if (DDL_BLKRITERIA.SelectedValue == "3")	// Kriteria : PENGURUS
					{
						subsql = "select cs_idcardnum from cust_stockholder where cu_ref = '" + Request.QueryString["curef"] + "'";
					}
					else 
					{
						subsql = "select '" + REF_COLUMN_VAL + "'";
					}


					sql = "select top 100 ISNULL(ltrim(rtrim(CUST_NAME1)),'') + ' ' + ISNULL(ltrim(rtrim(CUST_NAME2)),'') + ' ' + ISNULL(ltrim(rtrim(CUST_NAME3)),'') [NAME], " + 
						"CUST_IDTYPE IDTYPE, CUST_ID IDNO, ADDR1 ADDR, SC_DESC SR, RR_DESC RR, " +
						"EXPIRE_DATE [EXP] " + 
						"FROM BL_COMPPERSONAL A LEFT JOIN BL_SOURCECODE B ON A.SC_CODE = B.SC_CODE " + 
						"LEFT JOIN BL_REJECTREASON C ON A.RS_CODE = C.RR_CODE WHERE " +
						"rtrim(ltrim(CUST_IDTYPE)) = '" + REF_COLUMN + "' and ltrim(rtrim(CUST_ID)) in (" + subsql + ")";
				}

				//DEBUG
				//Response.Write("<!-- sql blacklist : " + sql + " -->");

				conn.QueryString = sql;
				conn.ExecuteQuery();
			}
			else	// perorangan
			{				
				sql = "exec BL_CUSTOMERINFO '" + sts_debitur + "', '" + curef + "', '" + DDL_BLKRITERIA.SelectedValue + "'";
				conn.QueryString = sql;
				conn.ExecuteQuery();
				dtinfo = conn.GetDataTable().Copy();

				//DEBUG
				Response.Write("<!-- " + sql + " -->");

				conn.QueryString = "select REF_BLCOLUMN, REF_COLUMN from RFBLKRITERIAVALUE where VALUECODE = '" + DDL_BLKRITERIAVALUE.SelectedValue + "'";
				conn.ExecuteQuery();

				//DEBUG
				Response.Write("<!-- " + conn.QueryString.ToString() + " -->");

				if (dtinfo.Rows.Count == 0 || conn.GetRowCount() == 0) return;

				REF_BLCOLUMN = conn.GetFieldValue("REF_BLCOLUMN");
				REF_COLUMN = conn.GetFieldValue("REF_COLUMN");
				try { REF_COLUMN_VAL = dtinfo.Rows[0][REF_COLUMN].ToString(); }
				catch {}

				//DEBUG
				//Response.Write("<!-- REF_BLCOLUMN : " + REF_BLCOLUMN + " -->");
				//Response.Write("<!-- REF_COLUMN : " + REF_COLUMN + " -->");
				//Response.Write("<!-- REF_COLUMN_VAL : " + REF_COLUMN_VAL + " -->");

				//sql = "exec BL_CHECKBLACKLIST '" + REF_BLCOLUMN + "','" + REF_COLUMN + "', '" + REF_COLUMN_VAL + "'";				

				////////////////////////////////////////////////
				///	kalau kriteria NAMA
				///	DDL_BLKRITERIA
				///	DDL_BLKRITERIAVALUE
				if (DDL_BLKRITERIAVALUE.SelectedValue == "1")	// CUST_NAME
				{
					/***
					sql = "select top 100 ISNULL(CUST_NAME1,'') + ' ' + ISNULL(CUST_NAME2,'') + ' ' + ISNULL(CUST_NAME3,'') [NAME], " + 
						"CUST_IDTYPE IDTYPE, CUST_ID IDNO, ADDR1 ADDR, SC_DESC SR, RR_DESC RR, " +
						"EXPIRE_DATE [EXP] " + 
						"FROM BL_COMPPERSONAL A LEFT JOIN BL_SOURCECODE B ON A.SC_CODE = B.SC_CODE " + 
						"LEFT JOIN BL_REJECTREASON C ON A.RS_CODE = C.RR_CODE WHERE " +
						"(ltrim(rtrim(cust_name1)) like  '%" + dtinfo.Rows[0]["NAME1"].ToString() + "%' or ltrim(rtrim(cust_name1)) like '%" + dtinfo.Rows[0]["NAME2"].ToString() + "%' or ltrim(rtrim(cust_name1)) like '%" + dtinfo.Rows[0]["NAME3"].ToString() + "%') " +
						"or " +
						"(ltrim(rtrim(cust_name2)) like  '%" + dtinfo.Rows[0]["NAME1"].ToString() + "%' or ltrim(rtrim(cust_name2)) like '%" + dtinfo.Rows[0]["NAME2"].ToString() + "%' or ltrim(rtrim(cust_name2)) like '%" + dtinfo.Rows[0]["NAME3"].ToString() + "%') " +
						"or " + 
						"(ltrim(rtrim(cust_name3)) like  '%" + dtinfo.Rows[0]["NAME1"].ToString() + "%' or ltrim(rtrim(cust_name3)) like '%" + dtinfo.Rows[0]["NAME2"].ToString() + "%' or ltrim(rtrim(cust_name3)) like '%" + dtinfo.Rows[0]["NAME3"].ToString() + "%') ";
					***/

					/***
					sql = "exec BL_CHECKBLACKLIST1 '" + 
						dtinfo.Rows[0]["NAME1"].ToString() + "', '" + 
						dtinfo.Rows[0]["NAME2"].ToString() + "', '" + 
						dtinfo.Rows[0]["NAME3"].ToString() + "'";
					***/

					sql = "exec BL_CHECKBLACKLIST2 '" + sts_debitur + "', '" + curef + "', '" + DDL_BLKRITERIA.SelectedValue + "'";
				}
				else	// Kalau Kriterai CUST_ID 
				{
					string subsql = "";
					if (DDL_BLKRITERIA.SelectedValue == "3")	// Kriteria : PENGURUS
					{
						subsql = "select cs_idcardnum from cust_stockholder where cu_ref = '" + Request.QueryString["curef"] + "'";
					}
					else 
					{
						subsql = "select '" + REF_COLUMN_VAL + "'";
					}


					sql = "select top 100 ISNULL(ltrim(rtrim(CUST_NAME1)),'') + ' ' + ISNULL(ltrim(rtrim(CUST_NAME2)),'') + ' ' + ISNULL(ltrim(rtrim(CUST_NAME3)),'') [NAME], " + 
						"CUST_IDTYPE IDTYPE, CUST_ID IDNO, ADDR1 ADDR, SC_DESC SR, RR_DESC RR, " +
						"EXPIRE_DATE [EXP] " + 
						"FROM BL_COMPPERSONAL A LEFT JOIN BL_SOURCECODE B ON A.SC_CODE = B.SC_CODE " + 
						"LEFT JOIN BL_REJECTREASON C ON A.RS_CODE = C.RR_CODE WHERE " +
						"rtrim(ltrim(CUST_IDTYPE)) = '" + REF_COLUMN + "' and ltrim(rtrim(CUST_ID)) in (" + subsql + ")";
				}

				//DEBUG
				Response.Write("<!-- sql blacklist : " + sql + " -->");

				conn.QueryString = sql;
				conn.ExecuteQuery();				
				
			}

			//--- MENGECEK HASIL BLACK LIST
			if (conn.GetRowCount() > 0)
			{
				locResultbl = true;							
				dt1 = sqlQuery(sql);															
			}
			else
			{
				locResultbl = false;							
			}			
		}

		void check_dd(string sts_debitur,string apregno,ref bool locResult,ref DataTable dt2)
		{
			string  sql = "";

			/**
			 * "This Codes is no longer needed. It's too complicated", Mr Cheng said.
			 * 
			conn.QueryString = "select distinct * from VW_BL_CEKDUPLIKASI where AP_REGNO = '" + apregno + "'";
			conn.ExecuteQuery();
			string fs_name	= conn.GetFieldValue("nama");
			string md_name	= conn.GetFieldValue("midlenm");
			string ls_name	= conn.GetFieldValue("lastnm");
			string tgl		= conn.GetFieldValue("umur");
			string idno		= conn.GetFieldValue("idno");
			string idtype	= conn.GetFieldValue("idtype");
			string ketdesc	= conn.GetFieldValue("ket_desc");
			string sqlname = "";
			for (int i = 0;i < conn.GetRowCount();i++)
			{				
				sqlname = sqlname + " or ((CU_FIRSTNAME like '" + conn.GetFieldValue("csname1") + "%') and (CU_LASTNAME like '" + conn.GetFieldValue("csname3") + "%') and (convert(varchar,CU_DOB,112) = '" + conn.GetFieldValue("csdob") + "') )or ((CU_IDCARDNUM = '"+ conn.GetFieldValue("csidno") +"') and (CU_IDCARDNUM <> '')) ";
			}

			if (sts_debitur == "1")		// company
			{			
				sql =	"select * from VW_BL_DUPLIKASI_CUSTCOMPANY " + 
						"where ((CU_COMPNAME like '" + fs_name + "%') " +
					    "or (CU_NPWP = '" + idno + "')) and (ap_regno <> '" + apregno + "')" + sqlname;				
				conn.QueryString = sql;
				conn.ExecuteQuery();				
			}
			else	// individual
			{			
				sql =	"select * from VW_BL_DUPLIKASI_CUSTPERSONAL " + 
						"where ((CU_FIRSTNAME like '"+fs_name+"%' and CU_LASTNAME like '%"+ls_name+"%' " +					  					  
						"and convert(varchar,CU_DOB,112) = '"+tgl+"') " +
						"or (CU_IDCARDNUM = '"+idno+"')) " +
						"and ap_regno <> '"+apregno+"'";
				conn.QueryString = sql;
				conn.ExecuteQuery();			
			}
			**/

			sql = "exec BL_CHECKDUPLICATE '" + apregno + "'";
			conn.QueryString = sql;
			conn.ExecuteQuery();


			/// Debug
			Response.Write("<!-- query dup: " + sql + "-->");

			if (conn.GetRowCount() > 0)
			{
				locResult = true;
				dt2 = sqlQuery(sql);																							
			}
			else
			{
				locResult = false;
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
			this.DataGrid2.ItemCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.DataGrid2_ItemCommand);
			this.DataGrid2.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.DataGrid2_PageIndexChanged);
			this.DataGrid1.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.DataGrid1_PageIndexChanged);

		}
		#endregion

		protected void DataGrid1_SelectedIndexChanged(object sender, System.EventArgs e)
		{
		
		}
		
		
		protected void Button1_Click(object sender, System.EventArgs e)
		{			
			DataGrid Datagrid1  = new DataGrid();			
			DataGrid Datagrid2  = new DataGrid();			
			DataGrid Datagrid3  = new DataGrid();	

			string sts_debitur = "";

			if (LBL_CU_CUSTTYPEID.Text == "company") {sts_debitur = "1";}
			else { sts_debitur = "2"; }			

//			bool locresultbl = false;
//			DataTable dt1 = new DataTable();
//
//			check_bl(sts_debitur,TXT_CU_REF.Text,ref locresultbl,ref dt1);
//
//			if (locresultbl)
//			{				
//				DataGrid1.DataSource = dt1;
//				try 
//				{
//					DataGrid1.DataBind();		
//				} 
//				catch 
//				{
//					DataGrid1.CurrentPageIndex = 0;
//					DataGrid1.DataBind();
//				}
//			}
//			else
//			{
//				Label1.Visible = true;	
//			}			

			bool locresult = false;
			DataTable dt2 = new DataTable();

			check_dd(sts_debitur, TXT_AP_REGNO.Text, ref locresult, ref dt2);

			if (locresult)
			{				
				DataGrid2.DataSource = dt2;
				try 
				{
					DataGrid2.DataBind();		
				} 
				catch 
				{
					DataGrid2.CurrentPageIndex = 0;
					DataGrid2.DataBind();
				}
			}
			else
			{
				Label2.Visible = true;	
			}			
		}

		protected void Button2_Click(object sender, System.EventArgs e)
		{	// tombol Save
			string sql = "update APPLICATION set AP_BLMEMO = '" + TXT_MEMO.Text + "'";
			sql += ",AP_BLBMPEMILIK = '" + RDO_BM_BL_PEMILIK.SelectedValue + "'";
			sql += ",AP_BLBMMGMT = '" + RDO_BM_BL_MGMT.SelectedValue + "'";
			sql += ",AP_BLBMUSAHA = '" + RDO_BM_BL_PERUSAHAAN.SelectedValue + "'";
			sql += ",AP_BLBMPERNAH = '" + RDO_BM_BL_PERNAH.SelectedValue + "'";
			sql += ",AP_BLBIPEMILIK = '" + RDO_BI_BL_PEMILIK.SelectedValue + "'";
			sql += ",AP_BLBIMGMT = '" + RDO_BI_BL_MGMT.SelectedValue + "'";
			sql += ",AP_BLBIUSAHA = '" + RDO_BI_BL_PERUSAHAAN.SelectedValue + "'";
			sql += ",AP_BLBIPERNAH = '" + RDO_BI_BL_PERNAH.SelectedValue + "'";
			sql += " where AP_REGNO = '" + TXT_AP_REGNO.Text + "'";
			conn.QueryString = sql;
			conn.ExecuteNonQuery();

//			string sts_debitur = "";
//			if (LBL_CU_CUSTTYPEID.Text == "company") {sts_debitur = "1";}
//			else { sts_debitur = "2"; }			
//			bool locresultbl = false;
//
//			DataTable dt1 = new DataTable();
//			check_bl(sts_debitur,TXT_CU_REF.Text,ref locresultbl,ref dt1);
//			
//			bool locresult = false;
//			DataTable dt2 = new DataTable();
//			check_dd(sts_debitur,TXT_AP_REGNO.Text,ref locresult,ref dt2);			 

			string userid = Session["UserID"].ToString();

//			if (mainregno == "" || mainregno == null || mainregno == "&nbsp")
			// periksa jika ada flag prescoring, jangan bolehkan redirect
			if ((Request.QueryString["presco"] != "") && (Request.QueryString["presco"] != null))
				return;

				Response.Redirect("../InitialDataEntry/KetentuanKredit.aspx?" + 
					"mainregno=" + mainregno +
					"&mainprod_seq=" + mainprod_seq +
					"&mainproductid=" + mainproductid +
					"&regno=" + regno + 
					"&curef=" + curef + 
					"&prog=" + prog + 
					"&tc=" + tc + 
					"&mc=" + mc + 
					"&exist=" + exist);
//			else
//				Response.Redirect("../DataEntry/IDE_KetentuanKredit.aspx?mainregno=" + mainregno + 
//					"&maincuref=" + maincuref + 
//					"&regno=" + regno + 
//					"&curef=" + curef + 
//					"&prog=" + prog + 
//					"&tc=" + tc + 
//					"&mc=" + mc + 
//					"&exist=" + exist);
		}

		private string GetSeq(string parSeqType)
		{   			
			string retValue = "";

			conn.QueryString = "EXEC BL_REALSEQ '" + parSeqType + "'";
			conn.ExecuteQuery();

			retValue = conn.GetFieldValue(0,0);

			return retValue;
		}

		private string addPreZerro(string parText, int parLenght)
		{
			int intLenght = parText.Length;
			string temp = "";
			if (parText.Length<parLenght)
			{				
				for (int i=1; i<=(parLenght-intLenght); i++)
				{ 
					temp = temp + "0";
				}
				temp = temp + parText;
			}
			else
			{
				temp = parText;
			}
			return temp;
		}

		private void createTextFile(DataTable dt1,DataTable dt2,string ap_regno,string userid,string stsdebitur,bool stsbl,bool stsdd)
		{
			
			string locScUser = userid;
			string strSeq = GetSeq("1");
			conn.QueryString = "select USERID, SU_FULLNAME, GETDATE() as TGL, APP_ROOT+BL_BACKUPDIR as BL_BACKUPDIR " +
				"from SCUSER , APP_PARAMETER where USERID = '"+locScUser+"'";
			conn.ExecuteQuery();
			
			string strUserName	= conn.GetFieldValue("SU_FULLNAME");			
			
			string strTgl		= addPreZerro(tool.FormatDate_Day(conn.GetFieldValue("TGL")),2);
			string strBln		= addPreZerro(tool.FormatDate_Month(conn.GetFieldValue("TGL")),2);
			string strThn		= tool.FormatDate_Year(conn.GetFieldValue("TGL"));
			string strJam		= tool.FormatDate_GetTime(conn.GetFieldValue("TGL"));
			//string strFileName	= strTgl + strBln + strThn + strJam.Replace(":","").Replace("AM","").Replace("PM","").Trim() + conn.GetFieldValue("USERID") + ".txt";
			string strFileName	= ap_regno+".txt";
			string strHariIni   = conn.GetFieldValue("TGL");
			string strPath = conn.GetFieldValue("BL_BACKUPDIR");			

			strFileName    = strPath + "\\"+ strFileName;
			// create New if not exist
			if (!Directory.Exists(strPath))
			{
				Directory.CreateDirectory(strPath);
			}

			StreamWriter FileTemp;
			FileTemp = File.CreateText(strFileName);

			string strProcNum = "R" + strTgl + strBln + strThn + addPreZerro(strSeq,6);

			if (stsdebitur == "1")
			{//company data
				string sql = "select CU_COMPNAME,CU_COMPESTABLISH,CU_NPWP,CU_COMPADDR1,CU_COMPADDR2,CU_COMPADDR3,CU_COMPCITY from application a left join customer b on a.cu_ref = b.cu_ref left join cust_company c on a.cu_ref = c.cu_ref where a.ap_regno = '"+ap_regno+"'";
				conn.QueryString = sql;
				conn.ExecuteQuery();
				
				string locCompName = conn.GetFieldValue("CU_COMPNAME");
				string locCompDOB = conn.GetFieldValue("CU_COMPESTABLISH");
				string locCompNPWP = conn.GetFieldValue("CU_NPWP");
				string locAddress1 = conn.GetFieldValue("CU_COMPADDR1");
				string locAddress2 = conn.GetFieldValue("CU_COMPADDR2");
				string locAddress3 = conn.GetFieldValue("CU_COMPADDR3");
				string locAddress4 = conn.GetFieldValue("CU_COMPCITY");

				FileTemp.WriteLine("User ID   : " + locScUser);
				FileTemp.WriteLine("User Name : " + strUserName );
				FileTemp.WriteLine("");
				FileTemp.WriteLine("D U P L I C A T E  /  B L A C K L I S T");
				FileTemp.WriteLine("C H E C K I N G   R E S U L T");
				FileTemp.WriteLine("=======================================");
				FileTemp.WriteLine("");
				FileTemp.WriteLine("CUSTOMER");
				FileTemp.WriteLine("Process #       : " + strProcNum);
				FileTemp.WriteLine("Process Date    : " + strHariIni);
				FileTemp.WriteLine("Company Name    : " + locCompName);
				FileTemp.WriteLine("Found Date      : " + locCompDOB);
				FileTemp.WriteLine("NPWP            : " + locCompNPWP);
				FileTemp.WriteLine("Address         : " + locAddress1);
				FileTemp.WriteLine("                  " + locAddress2);
				FileTemp.WriteLine("                  " + locAddress3);
				FileTemp.WriteLine("                  " + locAddress4);
			}
			else
			{//personal data
				string sql = "select CU_FIRSTNAME,CU_MIDDLENAME,CU_LASTNAME,CU_ADDR1,CU_ADDR2,CU_ADDR3,CU_DOB,CU_CITY,CU_IDCARDNUM,CU_NPWP " +
							 "from application a left join customer b on a.cu_ref = b.cu_ref left join cust_personal c on a.cu_ref = c.cu_ref where a.ap_regno = '"+ap_regno+"'";
				conn.QueryString = sql;
				conn.ExecuteQuery();
				
				string locFirstName = conn.GetFieldValue("CU_FIRSTNAME");
				string locMidName = conn.GetFieldValue("CU_MIDDLENAME");
				string locLastName = conn.GetFieldValue("CU_LASTNAME");
				string locIdCard = conn.GetFieldValue("CU_IDCARDNUM");
				string locDOB = conn.GetFieldValue("CU_DOB");
				string locNPWP = conn.GetFieldValue("CU_NPWP");
				string locAddress1 = conn.GetFieldValue("CU_ADDR1");
				string locAddress2 = conn.GetFieldValue("CU_ADDR2");
				string locAddress3 = conn.GetFieldValue("CU_ADDR3");
				string locAddress4 = conn.GetFieldValue("CU_CITY");

				string fullName = "";
				if (locMidName.Trim()=="")
				{fullName = locFirstName +" "+ locLastName;}
				else
				{fullName = locFirstName +" "+ locMidName +" "+ locLastName;}

				FileTemp.WriteLine("User ID   : " + locScUser );
				FileTemp.WriteLine("User Name : " + strUserName );
				FileTemp.WriteLine("");
				FileTemp.WriteLine("D U P L I C A T E  /  B L A C K L I S T");
				FileTemp.WriteLine("C H E C K I N G   R E S U L T");
				FileTemp.WriteLine("=======================================");
				FileTemp.WriteLine("");
				FileTemp.WriteLine("CUSTOMER");
				FileTemp.WriteLine("Process #       : " + strProcNum);
				FileTemp.WriteLine("Process Date    : " + strHariIni);
				FileTemp.WriteLine("Full Name       : " + fullName);
				FileTemp.WriteLine("Date of Birth   : " + locDOB);
				FileTemp.WriteLine("ID Card #       : " + locIdCard);
				FileTemp.WriteLine("NPWP            : " + locNPWP);
				FileTemp.WriteLine("Address         : " + locAddress1);
				FileTemp.WriteLine("                  " + locAddress2);
				FileTemp.WriteLine("                  " + locAddress3);
				FileTemp.WriteLine("                  " + locAddress4);
			}
			FileTemp.WriteLine("Checking Result : ");
			if (stsdd)
			{				
				FileTemp.WriteLine("                * Customer is Duplicated : ");
				FileTemp.WriteLine("");
				for (int i=0;i < GetRowCount(dt2);i++)
				{														
					FileTemp.WriteLine("                Name               :"+GetFieldValue(dt2,i,"name"));
					FileTemp.WriteLine("                ID Number          :"+GetFieldValue(dt2,i,"cardno"));
					FileTemp.WriteLine("                Establish Date/DOB :"+GetFieldValue(dt2,i,"tgl"));
					FileTemp.WriteLine("                Address            :"+GetFieldValue(dt2,i,"addr"));
					FileTemp.WriteLine("                Product            :"+GetFieldValue(dt2,i,"product"));
					FileTemp.WriteLine("");
				}
			}
			else
			{			
				FileTemp.WriteLine("                * Customer is not Duplicated");
			}

			if (stsbl)
			{
				FileTemp.WriteLine("                * Customer is Blacklisted : ");
				FileTemp.WriteLine("");
				for (int j=0;j < GetRowCount(dt1);j++)
				{																			
					FileTemp.WriteLine("                Name               :"+GetFieldValue(dt1,j,"name"));
					FileTemp.WriteLine("                ID Number          :"+GetFieldValue(dt1,j,"idno"));
					FileTemp.WriteLine("                Address            :"+GetFieldValue(dt1,j,"addr"));
					FileTemp.WriteLine("");
				}				
				//if (locMatch != "")
				//	FileTemp.WriteLine("Match Criteria  : " + locMatch);
			}
			else{FileTemp.WriteLine("                * Customer is not Blacklisted");}

			FileTemp.WriteLine("");
			conn.QueryString = "select AP_BLMEMO " +
				               "from APPLICATION where AP_REGNO = '"+ap_regno+"'";
			conn.ExecuteQuery();			
			FileTemp.WriteLine("Memo   : "+conn.GetFieldValue("AP_BLMEMO"));
			FileTemp.Close();			
			
			//string strSQL = "insert into PROCESS (PC_CODE, PC_DATE, PC_FILENAME, PC_STATUS) values " +
		//		"('" + strProcNum + "','" + strBln + "/" + strTgl + "/" + strThn + " " + strJam + "','" + strFileName + "','4')";

			//conn.QueryString = strSQL;
			//conn.ExecuteNonQuery();
		}

		private void DataGrid2_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			switch(((LinkButton)e.CommandSource).CommandName)
			{
				case "view":
					string regno = e.Item.Cells[0].Text.Trim();
					string curef = e.Item.Cells[8].Text.Trim();
					Response.Write("<script language='javascript'>window.open('../dataentry/CustProduct.aspx?regno=" + regno + "&curef=" + curef + "&sta=view','Penugasan_Agunan','status=no,scrollbars=yes,width=800,height=600');</script>");
					//Response.Redirect("CustProduct.aspx?regno=" + regno +"&curef="+curef);
					break;
				default:
					// Do nothing.
					break;
			}
		}

		protected void Button3_Click(object sender, System.EventArgs e)
		{

			try 
			{
				string sql = "update APPLICATION set AP_REJECT = '1' where AP_REGNO = '"+Request.QueryString["regno"]+"' ";
				conn.QueryString = sql;
				conn.ExecTrans();
				//conn.ExecuteNonQuery();

				conn.QueryString = "exec RJ_CHECKREJECT '" + Request.QueryString["regno"] + "', '" + Request.QueryString["curef"] + "'";
				conn.ExecTrans();
				//conn.ExecuteNonQuery();

				/// Membuat backup data aplikasi
				/// 
				conn.QueryString = "exec CHECK_BACKUP_DATA '" + Request.QueryString["regno"] + "'";
				conn.ExecTrans();


				/// Audit Trail
				/// 

				//ahmad
				conn.QueryString = "SP_AUDITTRAIL_APP '" + 
					Request.QueryString["regno"] + "',null,null,null,'" + 
					Request.QueryString["curef"] + "', '" + 
					Request.QueryString["tc"] + "','Application Reject', "+ 
					"null, '" +  
					Session["UserID"].ToString() + "',null,null";
				conn.ExecTrans();


				conn.ExecTran_Commit();	// commit transaction

				Response.Redirect("../letters/RejectLetterAll.aspx?regno=" + Request.QueryString["regno"] + "&curef=" + Request.QueryString["curef"] + "&tc=" + Request.QueryString["tc"] + "&mc=" + Request.QueryString["mc"] + "&prod=&apptype=");
			} 
			catch {
				conn.ExecTran_Rollback();
			}

		}

		protected void BTN_BACK_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			Response.Redirect("/SME/" + DMS.CuBESCore.Logic.backLink(Request.QueryString["tc"].ToString(), conn));
		}

		protected void BTN_PROSES_BL_Click(object sender, System.EventArgs e)
		{
			bool locresultbl	= false;
			DataTable dt1		= new DataTable();
			string sts_debitur	= "";

			//--- pertama, periksa status debitur/customer
			//    apakah company atau perorangan
			//---------------------------------------------
			if (LBL_CU_CUSTTYPEID.Text == "company") {sts_debitur = "1";}
			else { sts_debitur = "2"; }			


			//--- kedua, periksa picklist ---
			//-------------------------------
			if (DDL_BLKRITERIA.SelectedValue == "" || DDL_BLKRITERIAVALUE.SelectedValue == "")
			{
				GlobalTools.popMessage(this, "Kriteria tidak boleh kosong!");
				return;
			}

			
			check_bl(sts_debitur, TXT_CU_REF.Text, ref locresultbl, ref dt1);

			if (locresultbl)
			{				
				DataGrid1.DataSource = dt1;
				try 
				{
					DataGrid1.DataBind();		
				} 
				catch 
				{					
					DataGrid1.CurrentPageIndex = 0;
					DataGrid1.DataBind();
				}

				Label1.Visible = false;
			}
			else
			{
				dt1 = new DataTable();
				DataGrid1.DataSource = dt1;
				DataGrid1.DataBind();

				Label1.Visible = true;	
			}					
		}

		private void DataGrid2_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
		}

		private void DataGrid1_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
		
		}

		protected void BTN_SAVE_Click(object sender, System.EventArgs e)
		{
			// tombol Save
			string sql = "update APPLICATION set AP_BLMEMO = '" + TXT_MEMO.Text + "'";
			sql += ",AP_BLBMPEMILIK = '" + RDO_BM_BL_PEMILIK.SelectedValue + "'";
			sql += ",AP_BLBMMGMT = '" + RDO_BM_BL_MGMT.SelectedValue + "'";
			sql += ",AP_BLBMUSAHA = '" + RDO_BM_BL_PERUSAHAAN.SelectedValue + "'";
			sql += ",AP_BLBMPERNAH = '" + RDO_BM_BL_PERNAH.SelectedValue + "'";
			sql += ",AP_BLBIPEMILIK = '" + RDO_BI_BL_PEMILIK.SelectedValue + "'";
			sql += ",AP_BLBIMGMT = '" + RDO_BI_BL_MGMT.SelectedValue + "'";
			sql += ",AP_BLBIUSAHA = '" + RDO_BI_BL_PERUSAHAAN.SelectedValue + "'";
			sql += ",AP_BLBIPERNAH = '" + RDO_BI_BL_PERNAH.SelectedValue + "'";
			sql += " where AP_REGNO = '" + TXT_AP_REGNO.Text + "'";
			conn.QueryString = sql;
			conn.ExecuteNonQuery();
		}
	}
}
