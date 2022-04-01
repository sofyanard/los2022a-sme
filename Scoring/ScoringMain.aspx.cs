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
using System.Configuration;

namespace SME.Scoring
{
	/// <summary>
	/// Summary description for MainVerificationAssignment.sadfsad
	/// </summary>
	public partial class ScoringMain : System.Web.UI.Page
	{
		//protected System.Web.UI.WebControls.TextBox Textbox2;
		protected Connection conn;
		protected Tools tool = new Tools();
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			conn = (Connection) Session["Connection"];

			if (!Logic.AllowAccess(Session["GroupID"].ToString(), Request.QueryString["mc"], conn))
				Response.Redirect("/SME/Restricted.aspx");

			redirectToResult();

			if (!IsPostBack)
			{
				conn.QueryString = "select CU_JNSNASABAH, PROG_CODE from CUSTOMER c left join APPLICATION a on c.cu_ref = a.cu_Ref " +
					" where c.CU_REF = '" + Request.QueryString["curef"] + "'";
				conn.ExecuteQuery();

				LBL_CU_JNSNASABAH.Text = conn.GetFieldValue("CU_JNSNASABAH");
				LBL_PROGRAMID.Text = conn.GetFieldValue("PROG_CODE");
			}


//			if (Request.QueryString["stw"] == "1") 
//			{
//				BTN_SCORING_RESULT.Enabled = true;
//			}
//			else 
//			{
//				BTN_SCORING_RESULT.Enabled = false;
//			}

			/*
			HyperLink temp = new HyperLink();
			temp.Text = "Data Entry";
			temp.Font.Bold = true;
			temp.NavigateUrl = "/SME/DataEntry/Main.aspx?regno=" + Request.QueryString["regno"] + "&curef="+Request.QueryString["curef"]+"&mc=003"+"&tc="+Request.QueryString["tc"];
			Menu.Controls.Add(temp);
			Menu.Controls.Add(new LiteralControl("&nbsp;&nbsp;&nbsp;"));
			*/

			ViewDataApplication();
			ViewData();
			ViewMenu();
			ViewSubMenu();

            if (ConfigurationManager.AppSettings["IsCAS"] == "YES")
            {
                SubMenu.Visible = false;
            }
		}

		private void redirectToResult() 
		{
			if (Request.QueryString["mode"] == "result") 
			{
				Response.Redirect("ScoringResult.aspx?tc=" + Request.QueryString["tc"] + 
					"&mc=" + Request.QueryString["mc"] + 
					"&regno=" + Request.QueryString["regno"] + 
					"&curef=" + Request.QueryString["curef"] + 
					"&mode=" + Request.QueryString["mode"] +
					"&scr=" + Request.QueryString["scr"] + 
					"&CekData=1" );		
			}
		}

		String Pjg(string strTmp,int intJml)
		{
			for(int i=0;i<=intJml;i++)
			{
				if (i>strTmp.Length)
				{
					strTmp="0"+strTmp;
				}
			}
			return strTmp;
		}


		String IsiBlank(int intJml)
		{
			String strTmp="";
			for(int i=0;i<intJml;i++)
			{
				strTmp=strTmp+ " ";
			}
			return strTmp;
		}


		String IsiBintang(int intJml)
		{
			String strTmp="";
			for(int i=0;i<intJml;i++)
			{
				strTmp=strTmp+ "*";
			}
			return strTmp;
		}


		string CovToEBCDIC(string strTemp)
		{
			string strX;
			double dblX;
			if ((strTemp == null) || (strTemp == "")) strTemp = "0";
			strX = tool.ConvertFloat(strTemp);
			dblX = Double.Parse(strTemp);

			if (dblX>=0)
			{
				if(strX.Substring(strX.Length-1,1).Equals("0"))
					strX=strX.Substring(0,strX.Length-1)+"{";
				else if (strX.Substring(strX.Length-1,1).Equals("1"))
					strX=strX.Substring(0,strX.Length-1)+"A";
				else if (strX.Substring(strX.Length-1,1).Equals("2"))
					strX=strX.Substring(0,strX.Length-1)+"B";
				else if (strX.Substring(strX.Length-1,1).Equals("3"))
					strX=strX.Substring(0,strX.Length-1)+"C";
					//strX.Replace(strX.Substring(strX.Length-1,1),"C");
				else if (strX.Substring(strX.Length-1,1).Equals("4"))
					strX=strX.Substring(0,strX.Length-1)+"D";
				else if (strX.Substring(strX.Length-1,1).Equals("5"))
					strX=strX.Substring(0,strX.Length-1)+"E";
				else if (strX.Substring(strX.Length-1,1).Equals("6"))
					strX=strX.Substring(0,strX.Length-1)+"F";
				else if (strX.Substring(strX.Length-1,1).Equals("7"))
					strX=strX.Substring(0,strX.Length-1)+"G";
				else if (strX.Substring(strX.Length-1,1).Equals("8"))
					strX=strX.Substring(0,strX.Length-1)+"H";
				else if (strX.Substring(strX.Length-1,1).Equals("9"))
					strX=strX.Substring(0,strX.Length-1)+"I";
			}
			else if(dblX<0)
			{
				if(strX.Substring(strX.Length-1,1).Equals("0"))
					strX=strX.Substring(1,strX.Length-2)+"}";
				else if (strX.Substring(strX.Length-1,1).Equals("1"))
					strX=strX.Substring(1,strX.Length-2)+"J";
				else if (strX.Substring(strX.Length-1,1).Equals("2"))
					strX=strX.Substring(1,strX.Length-2)+"K";
				else if (strX.Substring(strX.Length-1,1).Equals("3"))
					strX=strX.Substring(1,strX.Length-2)+"L";
					//strX.Replace(strX.Substring(strX.Length-1,1),"C");
				else if (strX.Substring(strX.Length-1,1).Equals("4"))
					strX=strX.Substring(1,strX.Length-2)+"M";
				else if (strX.Substring(strX.Length-1,1).Equals("5"))
					strX=strX.Substring(1,strX.Length-2)+"N";
				else if (strX.Substring(strX.Length-1,1).Equals("6"))
					strX=strX.Substring(1,strX.Length-2)+"O";
				else if (strX.Substring(strX.Length-1,1).Equals("7"))
					strX=strX.Substring(1,strX.Length-2)+"P";
				else if (strX.Substring(strX.Length-1,1).Equals("8"))
					strX=strX.Substring(1,strX.Length-2)+"Q";
				else if (strX.Substring(strX.Length-1,1).Equals("9"))
					strX=strX.Substring(1,strX.Length-2)+"R";
			}
			return strX;
		}


		private bool CreateTextFile()
		{
			//StreamWriter Sw;
			String tTxt,sql,strSmall;
			int iThn,iBln;

			tTxt="";

			//tTxt=tTxt+"START OF FILE--";


			//Bagian Header 

			//INP-SYSTEM-ID
			//tTxt=tTxt+"--INP-SYSTEM-ID--";
			tTxt=tTxt+="BM2";
			//INP-KEY-GRP-VAL
			//tTxt=tTxt+"--INP-KEY-GRP-VAL--";
			tTxt=tTxt + "9999";
			//INP-KEY-INQY-ID
			//tTxt=tTxt+"--INP-KEY-INQY-ID--";
			tTxt=tTxt + Pjg(Request.QueryString["regno"],20);
			//INP-REL-CB-NBR
			//tTxt=tTxt+"--INP-REL-CB-NBR--";
			tTxt=tTxt + "01";
			//INP-INP-SPID
			//tTxt=tTxt+"--INP-INP-SPID--";
			tTxt=tTxt + "0000";
			//INP-FUNCTION
			//tTxt=tTxt+"--INP-FUNCTION--";
			tTxt=tTxt + "01";

			//INP-SAMP-DIGITS
			//tTxt=tTxt+"--INP-SAMP-DIGITS--";
			tTxt=tTxt + "00";
			//INP-DIGITS-ASSIGNED-IND
			//tTxt=tTxt+"--INP-DIGITS-ASSIGNED-IND--";
			tTxt=tTxt + "N";
			//INP-BUS-UNIT
			//tTxt=tTxt+"--INP-BUS-UNIT--";
			tTxt=tTxt + IsiBlank(20);
			//INP-DATE-PROCESSED
			string strDate,strTime;
			DateTime a=DateTime.Now; 
			strDate = a.Year.ToString()  + Pjg(a.Month.ToString(),2)+ Pjg(a.Day.ToString(),2);
			//tTxt=tTxt+"--INP-DATE-PROCESSED--";
			tTxt=tTxt + strDate;
			//INP-TIME-PROCESSED
			strTime=Pjg(a.Hour.ToString(),2)+Pjg(a.Minute.ToString(),2)+Pjg(a.Second.ToString(),2)+a.Millisecond.ToString().Substring(a.Millisecond.ToString().Length-2,2); 
			//tTxt=tTxt+"--INP-TIME-PROCESSED--";
			tTxt=tTxt + strTime;
			//INP-SOUCE-CD
			//tTxt=tTxt+"--INP-SOUCE-CD--";
			tTxt=tTxt + IsiBlank(8);
			//INP-NBR-RTRN-RULE-SETS
			//tTxt=tTxt+"--INP-NBR-RTRN-RULE-SETS--";
			tTxt=tTxt + "20";
			//INP-NBR-RTRN-DECSN-SCEN
			//tTxt=tTxt+"--INP-NBR-RTRN-DECSN-SCEN--";
			tTxt=tTxt + "20";
			//INP-NBR-RTRN-PRICING-SCEN
			//tTxt=tTxt+"--INP-NBR-RTRN-PRICING-SCEN--";
			tTxt=tTxt + "20";
			//INP-NBR-RTRN-SCORING-SCEN
			//tTxt=tTxt+"--INP-NBR-RTRN-SCORING-SCEN--";
			tTxt=tTxt + "20";
			//INP-RTRN-ATTR-START
			//tTxt=tTxt+"--INP-RTRN-ATTR-START--";
			tTxt=tTxt + "01701";
			//INP-RTRN-ATTR-LENGTH
			//tTxt=tTxt+"--INP-RTRN-ATTR-LENGTH--";
			tTxt=tTxt + "01000";
			//FILLER ---------
			//tTxt=tTxt+"--FILLER--";
			tTxt=tTxt + IsiBlank(72);
			//-- END HEADER ----
			//BEGIN OTHER FIELD
			//tTxt=tTxt+"--OTHFIELD--";
			tTxt=tTxt + IsiBlank(1107);
			//INP-ATTR-AREA-LENGTH
			//tTxt=tTxt+"--INP-ATTR-AREA-LENGTH--";
			tTxt=tTxt + "03000";
			//END OTHER FIELD
			

			conn.QueryString="select * from vw_cek_smdm where ap_regno='" + Request.QueryString["regno"] + "'";
			conn.ExecuteQuery();
			if(conn.GetFieldValue("businessunit")=="SM100")
			{strSmall="1";}
			else
			{strSmall="0";}


			

			sql="select *,datediff(m,mulai_usaha,getdate()) as Diff_Month_Mulai_Usaha,isnull(datediff(m,MULAI_MENETAP,getdate()),0) as Diff_Month_Mulai_Menetap from scoring_infoumum where ap_regno='" + Request.QueryString["regno"] + "'";
			//sql="select * from scoring_infoumum where ap_regno='" + Request.QueryString["regno"] + "'";
			conn.QueryString = sql;
			conn.ExecuteQuery();
			DataTable dt1 = conn.GetDataTable().Copy();
			if (dt1.Rows.Count == 0) 
			{
				
				GlobalTools.popMessage(this, "Data Informasi Umum belum lengkap!");
				return false;
				
			}

			

			/////////////////////////////////////////////////////
			///	NERACA
			///	
			//			sql = "select * from ca_neraca_small where ap_regno= '" + Request.QueryString["regno"] + "' " +
			//				" and is_proyeksi <> '1' and year(posisi_tgl) = (" +
			//				" select max(year(posisi_tgl)) from ca_neraca_small where ap_regno= '" + Request.QueryString["regno"] +"'" +
			//				" and is_proyeksi <> '1' )";

			sql = "exec SP_CA_NERACA '" + Request.QueryString["regno"] + "'";
			conn.QueryString = sql;
			conn.ExecuteQuery();
			DataTable dt2 = conn.GetDataTable().Copy();
			if (dt2.Rows.Count == 0) 
			{
				GlobalTools.popMessage(this, "Data Neraca belum lengkap!");
				return false;
			}



			///////////////////////////////////////////////////////
			///	LABA-RUGI
			///	
			//			sql = "select * from ca_labarugi_small where ap_regno= '" + Request.QueryString["regno"] + "'" +
			//					" and year(posisi_tgl) = (" +
			//					" select max(year(posisi_tgl)) from ca_labarugi_small where ap_regno = '" + Request.QueryString["regno"] + "'" +
			//					" and is_proyeksi <> '1')";

			sql = "exec SP_CA_LABARUGI '" + Request.QueryString["regno"] + "'";
			conn.QueryString = sql;
			conn.ExecuteQuery();
			DataTable dt3 = conn.GetDataTable().Copy();
			if (dt3.Rows.Count == 0) 
			{
				GlobalTools.popMessage(this, "Data Laba-Rugi belum lengkap!");
				return false;
			}
			
			if (strSmall=="1" )
			{
				sql="select SALES_TO_WK_CAPITAL,DEBT_TO_NETWORTH,CURRENT_RATIO,BUSINESS_DEBT_SERVICE_RATIO,TRADE_CYCLE,SALES_INCREASE,NETINCOME_INCREASE,AVERAGE_NETPROFIT   from CA_ratio_SMALL where ap_regno = '" + Request.QueryString["regno"] + 
					"' and (is_proyeksi is null or rtrim(ltrim(is_proyeksi)) = ''   OR RTRIM(LTRIM(IS_PROYEKSI)) = '0' ) " + 
					"and year(posisi_tgl) = (select max(year(posisi_tgl)) from CA_ratio_SMALL where " + 
					"ap_regno = '" + Request.QueryString["regno"] + 
					"' and (is_proyeksi is null or rtrim(ltrim(is_proyeksi)) = ''   OR RTRIM(LTRIM(IS_PROYEKSI)) = '0' ))";
			}
			else
			{
				sql="select  top 1 SALES_TO_WK_CAPITAL,DEBT_TO_NETWORTH,CURRENT_RATIO," + 
					" BUSINESS_DEBT_SERV_RATIO as BUSINESS_DEBT_SERVICE_RATIO ,DAYS_TC as TRADE_CYCLE,SALES_INCREASE,NETINCOME_INCREASE,AVERAGE_NETPROFIT   from CA_ratio_MIDDLE where ap_regno = '" + Request.QueryString["regno"] + 
					"' and (is_proyeksi is null or rtrim(ltrim(is_proyeksi)) = ''  OR RTRIM(LTRIM(IS_PROYEKSI)) = '0' ) " + 
					"and year(DATE_PERIODE) = (select max(year(DATE_PERIODE)) from CA_ratio_MIDDLE where " + 
					"ap_regno = '" + Request.QueryString["regno"] + 
					"' and (is_proyeksi is null or rtrim(ltrim(is_proyeksi)) = ''  OR RTRIM(LTRIM(IS_PROYEKSI)) = '0' ))";
			}

			conn.QueryString = sql;
			conn.ExecuteQuery();
			DataTable dt4 = conn.GetDataTable().Copy();
			if (dt4.Rows.Count == 0) 
			{
				GlobalTools.popMessage(this, "Data Ratio Keuangan belum lengkap atau \\nTidak terdapat jumlah bulan 12 bulan!");
				return false;
			}

			//sql = "select datediff(m,Cast(MULAI_BM_MM as varchar)+'/01/'+ cast(MULAI_BM_YY as varchar),getdate()) as Diff_Month_Mulai_NasabahBM,* from scoring_hubbank  where ap_regno='" + Request.QueryString["regno"] + "'";
			sql = "select * from scoring_hubbank  where ap_regno='" + Request.QueryString["regno"] + "'";
			conn.QueryString = sql;
			conn.ExecuteQuery();

			DataTable dt5 = conn.GetDataTable().Copy();
			if (dt5.Rows.Count == 0) 
			{
				GlobalTools.popMessage(this, "Data Hubungan Dengan Bank belum lengkap!");
				return false;
			}

			


			//A0001 - Total Exposure
			//tTxt=tTxt+"--A0001--";
			if (Convert.ToString(Math.Round(Double.Parse(conn.GetFieldValue(dt5,0,"TTL_EXP_MILL")))).Length > 8)
			{
				tTxt=tTxt + "99999999";
			}
			else
			{
				tTxt=tTxt+ Pjg(Math.Round(Double.Parse(conn.GetFieldValue(dt5,0,"TTL_EXP_MILL"))).ToString(),8);
			}


			//A0002 - Type of Request
			//tTxt=tTxt+"--A0002--";
			if (conn.GetRowCount(dt1) > 0 ) 
				tTxt=tTxt + Pjg(conn.GetFieldValue(dt1,0,"JENIS_PERMOHONAN"),1);
			else 
				tTxt=tTxt + "9";  // tolong ubah

			//A0003 - Requested Product
			//tTxt=tTxt+"--A0003--";
			tTxt=tTxt + Pjg(conn.GetFieldValue(dt1,0,"JENIS_KREDIT"), 2);

			//A0004 - Contractor requested
			//tTxt=tTxt+"--A0004--";
			tTxt=tTxt + Pjg(conn.GetFieldValue(dt1,0,"CONTRACTOR_TYPE"), 1);

			//A0005 - Credit Scheme
			//tTxt=tTxt+"--A0005--";
			tTxt=tTxt + Pjg(conn.GetFieldValue(dt1,0,"SKEMA_KREDIT"), 2);

			//A0006 - Existing Product
			//tTxt=tTxt+"--A0006--";
			//tTxt=tTxt + conn.GetFieldValue(dt1,0,"PRODUCT_EXISTING"); //ahmad
			tTxt=tTxt + Pjg(conn.GetFieldValue(dt1,0,"PRODUCT_EXISTING"), 2);

			//A0007 - Existing Exposure
			//tTxt=tTxt+"--A0007--";
			//tTxt=tTxt + Pjg(conn.GetFieldValue(dt5,0,"LMT_CREDIT_CURR"),8);
			double appValue = Convert.ToDouble(conn.GetFieldValue(dt5, 0, "LMT_CREDIT_CURR_MILL"));
			double totalExposure = Convert.ToDouble(conn.GetFieldValue(dt5, 0, "TTL_EXP_MILL"));
			double existingExposure = totalExposure - appValue;

			tTxt=tTxt + Pjg(Math.Round(existingExposure).ToString(),8);			

			//A0008 - Additional Collateral Flag
			//tTxt=tTxt+"--A0008--";
			tTxt=tTxt + conn.GetFieldValue(dt1,0,"JAMINAN_TAMBAHAN");

			//tTxt=tTxt+"--Filler--";
			tTxt=tTxt + IsiBlank(175);


			//ahmad: sampe sini
			
			
			//A0201 - Number of Children of Main Owner
			//tTxt=tTxt+"--A0201--";
			if ((conn.GetFieldValue(dt1,0,"JML_ANAK")== null )||(conn.GetFieldValue(dt1,0,"JML_ANAK")==""))
			{
				tTxt=tTxt+"99";
			}
			else
			{
				tTxt=tTxt + Pjg(conn.GetFieldValue(dt1,0,"JML_ANAK"),2);
			}

			//A0202 - Sex of Main Owner
			//tTxt=tTxt+"--A0202--";
			tTxt=tTxt + conn.GetFieldValue(dt1,0,"JENIS_KELAMIN");

			//A0203 - Time at Residence of Main Owner (yymm)
			//tTxt=tTxt+"--A0203--";
			string strBulan;
			if (conn.GetFieldValue(dt1,0,"MULAI_MENETAP") == null || conn.GetFieldValue(dt1,0,"MULAI_MENETAP") == "" )
			{
				tTxt=tTxt+"9999";
			}
			else
			{
				//				tTxt=tTxt + GlobalTools.FormatDate_Year(conn.GetFieldValue(dt1,0,"MULAI_MENETAP")).Substring(2,2); 
				//				strBulan = GlobalTools.FormatDate_Month(conn.GetFieldValue(dt1,0,"MULAI_MENETAP"));
				//				if (strBulan.Length==1) {strBulan="0"+strBulan;}
				//				tTxt=tTxt + strBulan;
				iThn=Convert.ToInt32(conn.GetFieldValue(dt1,0,"Diff_Month_Mulai_Menetap"))/12;
				iBln=Convert.ToInt32(conn.GetFieldValue(dt1,0,"Diff_Month_Mulai_Menetap"))%12;
				tTxt=tTxt+Pjg(iThn.ToString(),2);
				tTxt=tTxt+Pjg(iBln.ToString(),2);
			}

			//tTxt=tTxt + strBulan;
			//A0204 - Years as BM customer
			//tTxt=tTxt+"--A0204--";
			//			tTxt=tTxt + Pjg((conn.GetFieldValue(dt5,0,"MULAI_BM_YY")),2); // year
			//			tTxt=tTxt + Pjg((conn.GetFieldValue(dt5,0,"MULAI_BM_MM")),2); // month
			//			if (conn.GetFieldValue(dt5,0,"MULAI_BM_YY") == null || conn.GetFieldValue(dt5,0,"MULAI_BM_YY") == "" )
			//			{
			//				tTxt=tTxt+"9999";
			//			}
			//			else
			//			{
			//				iThn=Convert.ToInt32(conn.GetFieldValue(dt5,0,"Diff_Month_Mulai_NasabahBM"))/12;
			//				iBln=Convert.ToInt32(conn.GetFieldValue(dt5,0,"Diff_Month_Mulai_NasabahBM"))%12;
			//				tTxt=tTxt+Pjg(iThn.ToString(),2);
			//				tTxt=tTxt+Pjg(iBln.ToString(),2);
			//			}
			if (conn.GetFieldValue(dt1,0,"LAMA_NASABAH_BM") == null || conn.GetFieldValue(dt1,0,"LAMA_NASABAH_BM") == "" )
			{
				tTxt=tTxt+"9999";
			}
			else
			{
				tTxt=tTxt + Pjg(conn.GetFieldValue(dt1,0,"LAMA_NASABAH_BM"),4);		// customer baru, maka 0000
			}

			//A0205 - Age of Business (yymm)
			//tTxt=tTxt+"--A0205--";
			if (conn.GetFieldValue(dt1,0,"MULAI_USAHA") == null || conn.GetFieldValue(dt1,0,"MULAI_USAHA") == "" )
			{
				tTxt=tTxt+"9999";
			}
			else
			{
				//				tTxt=tTxt + GlobalTools.FormatDate_Year(conn.GetFieldValue(dt1,0,"MULAI_USAHA")).Substring(2,2); 
				//				strBulan = GlobalTools.FormatDate_Month(conn.GetFieldValue(dt1,0,"MULAI_USAHA"));
				//				if (strBulan.Length==1) {strBulan="0"+strBulan;}
				//				tTxt=tTxt + strBulan;
				iThn=Convert.ToInt32(conn.GetFieldValue(dt1,0,"Diff_Month_Mulai_Usaha"))/12;
				iBln=Convert.ToInt32(conn.GetFieldValue(dt1,0,"Diff_Month_Mulai_Usaha"))%12;
				tTxt=tTxt+Pjg(iThn.ToString(),2);
				tTxt=tTxt+Pjg(iBln.ToString(),2);
			}

			//A0206 - Sales (Millions)
			//tTxt=tTxt+"--A0206--";			
			//if (conn.GetFieldValue(dt3,0,"IS_PENJ") == null || conn.GetFieldValue(dt3,0,"IS_PENJ") == "" )
			if (conn.GetFieldValue(dt1,0,"IU_PSRL_PENJUALANTAHUNAN_SATUAN") == null || 
				conn.GetFieldValue(dt1,0,"IU_PSRL_PENJUALANTAHUNAN_SATUAN") == "" )
			{
				tTxt=tTxt+"99999999";
			}
			else
			{
				//tTxt=tTxt + Pjg((conn.GetFieldValue(dt3,0,"IS_PENJ")),8);
				tTxt=tTxt + Pjg(Math.Round(Double.Parse(conn.GetFieldValue(dt1,0,"IU_PSRL_PENJUALANTAHUNAN_SATUAN"))).ToString(),8);
			}

			//A0207 - Total Liabilities (Millions)
			//tTxt=tTxt+"--A0207--";			
			//if (conn.GetFieldValue(dt2,0,"PASV_TTLHT") == null || conn.GetFieldValue(dt2,0,"PASV_TTLHT") == "" )
			if (conn.GetFieldValue(dt1,0,"IU_HUTANG_SATUAN") == null || 
				conn.GetFieldValue(dt1,0,"IU_HUTANG_SATUAN") == "" )
			{
				tTxt=tTxt+"99999999";
			}
			else
			{
				//tTxt=tTxt + Pjg((conn.GetFieldValue(dt2,0,"PASV_TTLHT")),8);
				tTxt=tTxt + Pjg(Math.Round(Double.Parse(conn.GetFieldValue(dt1,0,"IU_HUTANG_SATUAN"))).ToString(),8);
			}


			//A0208 - Cash 
			//tTxt=tTxt+"--A0208--";			
			//if (conn.GetFieldValue(dt2,0,"AKTV_KASBANK") == null || conn.GetFieldValue(dt2,0,"AKTV_KASBANK") == "" )
			if (conn.GetFieldValue(dt1,0,"IU_PSN_KASBANK") == null || 
				conn.GetFieldValue(dt1,0,"IU_PSN_KASBANK") == "" )
			{
				tTxt=tTxt+"99999999";
			}
			else
			{
				tTxt=tTxt + Pjg(Math.Round(Double.Parse(conn.GetFieldValue(dt1,0,"IU_PSN_KASBANK"))).ToString(),8);
			}


			//A0209 - Company Legal Type 
			//tTxt=tTxt+"--A0209--";
			tTxt=tTxt + conn.GetFieldValue(dt1,0,"JNS_USAHA");


			//A0210 - Current Assets (Millions)
			//tTxt=tTxt+"--A0210--";
			//if (conn.GetFieldValue(dt2,0,"AKTV_TTLAKTLCR") == null || conn.GetFieldValue(dt2,0,"AKTV_TTLAKTLCR") == "" )
			if (conn.GetFieldValue(dt1,0,"IU_PSN_TTLAKTIVALCR_SATUAN") == null || 
				conn.GetFieldValue(dt1,0,"IU_PSN_TTLAKTIVALCR_SATUAN") == "" )
			{
				tTxt=tTxt+"99999999";
			}
			else
			{
				tTxt=tTxt + Pjg(Math.Round(Double.Parse(conn.GetFieldValue(dt1,0,"IU_PSN_TTLAKTIVALCR_SATUAN"))).ToString(),8);
			}

			//A0211 - Net Worth 
			//tTxt=tTxt+"--A0211--";
			//if (conn.GetFieldValue(dt2,0,"PASV_TTLMODAL") == null || conn.GetFieldValue(dt2,0,"PASV_TTLMODAL") == "" )
			if (conn.GetFieldValue(dt1,0,"IU_TOTMODAL") == null || 
				conn.GetFieldValue(dt1,0,"IU_TOTMODAL") == "" )
			{
				//tTxt=tTxt+"99999999"; //ahmad: panjangnya 7 bukan 8
				tTxt=tTxt+"9999999";
			}
			else
			{
				//tTxt=tTxt + Pjg(CovToEBCDIC(Math.Round(Double.Parse(conn.GetFieldValue(dt1,0,"IU_TOTMODAL_SATUAN"))).ToString()),7);
				tTxt=tTxt + Pjg(CovToEBCDIC(Math.Round(Double.Parse(conn.GetFieldValue(dt1,0,"IU_TOTMODAL"))).ToString()),7);
			}

			

			//A0212 - Sales / Working Capital %
			//tTxt=tTxt+"--A0212--";
			double AKTV_TTLAKTLCR = 0;
			double PASV_HTLNCR = 0;
			try {AKTV_TTLAKTLCR = Double.Parse(conn.GetFieldValue(dt2,0, "AKTV_TTLAKTLCR"));}
			catch {}
			try { PASV_HTLNCR = Double.Parse(conn.GetFieldValue(dt2,0, "PASV_HTLNCR")); }
			catch {}
			if(conn.GetFieldValue(dt3,0,"IS_PENJ") == null || conn.GetFieldValue(dt3,0,"IS_PENJ") == "" ) 
			{tTxt=tTxt+ "9995";}
			else if(conn.GetFieldValue(dt2,0,"AKTV_TTLAKTLCR") == null || conn.GetFieldValue(dt2,0,"AKTV_TTLAKTLCR") == "" || 
				conn.GetFieldValue(dt2,0,"PASV_HTLNCR") == null || conn.GetFieldValue(dt2,0,"PASV_HTLNCR") == "")
			{tTxt=tTxt+ "9996";}
			else if((conn.GetFieldValue(dt2,0,"AKTV_TTLAKTLCR") == null || conn.GetFieldValue(dt2,0,"AKTV_TTLAKTLCR") == "") && 
				(conn.GetFieldValue(dt2,0,"PASV_HTLNCR") == null || conn.GetFieldValue(dt2,0,"PASV_HTLNCR") == ""))
			{tTxt=tTxt+ "9997";}
			else if (AKTV_TTLAKTLCR - PASV_HTLNCR == 0)
			{tTxt=tTxt+ "9998";}
			else if (conn.GetFieldValue(dt4,0,"SALES_TO_WK_CAPITAL") == null || conn.GetFieldValue(dt4,0,"SALES_TO_WK_CAPITAL") == "")
			{tTxt=tTxt+ "9999";}
			else
			{
				if (Convert.ToString(Math.Abs(Math.Round(Double.Parse(conn.GetFieldValue(dt4,0,"SALES_TO_WK_CAPITAL"))*100))).Length > 4)
				{
					tTxt=tTxt + CovToEBCDIC("9994");
				}
				else
				{
					tTxt=tTxt + Pjg(CovToEBCDIC(Math.Round(Double.Parse(conn.GetFieldValue(dt4,0,"SALES_TO_WK_CAPITAL"))*100).ToString()),4);
				}
			}


			//A0213 - Debt / Net Worth %
			//tTxt=tTxt+"--A0213--";
			if(conn.GetFieldValue(dt1,0,"IU_HUTANG_SATUAN") == null || conn.GetFieldValue(dt1,0,"IU_HUTANG_SATUAN") == "" ) 
			{tTxt=tTxt+ "996";}
			else if(conn.GetFieldValue(dt2,0,"PASV_TTLMODAL") == null || conn.GetFieldValue(dt2,0,"PASV_TTLMODAL") == "" ) 
			{tTxt=tTxt+ "997";}
			else if(Double.Parse(conn.GetFieldValue(dt2,0,"PASV_TTLMODAL")) == 0) 
			{tTxt=tTxt+ "998";}
			else if(conn.GetFieldValue(dt4,0,"DEBT_TO_NETWORTH") == null || conn.GetFieldValue(dt4,0,"DEBT_TO_NETWORTH") == "" ) 
			{tTxt=tTxt+ "997";}
			else 
			{
				if (Convert.ToString(Math.Abs(Math.Round(Double.Parse(conn.GetFieldValue(dt4,0,"DEBT_TO_NETWORTH"))*100))).Length > 3)
				{
					tTxt=tTxt + CovToEBCDIC("995");
				}
				else
				{
					tTxt=tTxt + Pjg(CovToEBCDIC(Math.Round(Double.Parse(conn.GetFieldValue(dt4,0,"DEBT_TO_NETWORTH"))*100).ToString()),3);
				}
			}

			//A0214 - Current Ratio %
			//tTxt=tTxt+"--A0214--";
			if(conn.GetFieldValue(dt2,0,"AKTV_TTLAKTLCR") == null || conn.GetFieldValue(dt2,0,"AKTV_TTLAKTLCR") == "" ) 
			{tTxt=tTxt+ "996";}
			else if(conn.GetFieldValue(dt2,0,"PASV_TTLHTLNCR") == null || conn.GetFieldValue(dt2,0,"PASV_TTLHTLNCR") == "" )
			{tTxt=tTxt+ "997";}
			else if(Double.Parse(conn.GetFieldValue(dt2,0,"PASV_TTLHTLNCR")) == 0)
			{tTxt=tTxt+ "998";}
			else if(conn.GetFieldValue(dt4,0,"CURRENT_RATIO") == null || conn.GetFieldValue(dt4,0,"CURRENT_RATIO") == "" )
			{tTxt=tTxt+ "999";}
			else 
			{
				if (Convert.ToString(Math.Round(Double.Parse(conn.GetFieldValue(dt4,0,"CURRENT_RATIO"))*100)).Length > 3)
				{
					tTxt=tTxt + "995";
				}
				else
				{
					tTxt=tTxt + Pjg(Math.Round(Double.Parse(conn.GetFieldValue(dt4,0,"CURRENT_RATIO"))*100).ToString(),3);
				}

			}

			//A0215 - Business Debt Service Ratio %
			//tTxt=tTxt+"--A0215--";
			if(conn.GetFieldValue(dt3,0,"IS_LABA_BRSH") == null || conn.GetFieldValue(dt3,0,"IS_LABA_BRSH") == "" ) 
			{tTxt=tTxt+ "996";}
			else if(conn.GetFieldValue(dt2,0,"PASV_KIJTHTEMPO") == null || conn.GetFieldValue(dt2,0,"PASV_KIJTHTEMPO") == "" )
			{tTxt=tTxt+ "997";}
			else if(Double.Parse(conn.GetFieldValue(dt2,0,"PASV_KIJTHTEMPO")) == 0)
			{tTxt=tTxt+ "998";}
			else if(conn.GetFieldValue(dt4,0,"BUSINESS_DEBT_SERVICE_RATIO") == null || conn.GetFieldValue(dt4,0,"BUSINESS_DEBT_SERVICE_RATIO") == "" )
			{tTxt=tTxt+ "997";}
			else 
			{
				if (Convert.ToString(Math.Abs(Math.Round(Double.Parse(conn.GetFieldValue(dt4,0,"BUSINESS_DEBT_SERVICE_RATIO"))*100))).Length>3)
				{
					tTxt=tTxt + CovToEBCDIC("995");
				}
				else
				{
					tTxt=tTxt + Pjg(CovToEBCDIC(Math.Round(Double.Parse(conn.GetFieldValue(dt4,0,"BUSINESS_DEBT_SERVICE_RATIO"))*100).ToString()),3);
				}
			}
			
			//tTxt=tTxt+"--Filler--";
			tTxt=tTxt + IsiBlank(32);

			//A0301 - Legal Lawsuit Flag
			//tTxt=tTxt+"--A0301--";
			tTxt=tTxt + conn.GetFieldValue(dt1,0,"LEGAL_LAWSUIT");

			//A0302 - Existing Working Capital in other bank
			//tTxt=tTxt+"--A0302--";
			tTxt=tTxt + Pjg(Math.Round(Double.Parse(conn.GetFieldValue(dt1,0,"LIMIT_DIBANKLAIN"))).ToString(),8);

			//tTxt=tTxt+"--Filler--";
			tTxt=tTxt + IsiBlank(91);
			
			//A0401 - Age of Primary Owner (yymm)
			//tTxt=tTxt+"--A0401--";
			tTxt=tTxt + Pjg(conn.GetFieldValue(dt1,0,"UMUR_OWNER"),4);

			//A0402 - Current PUKK facility from state flag
			//tTxt=tTxt+"--A0402--";
			tTxt=tTxt + Pjg(conn.GetFieldValue(dt1,0,"PUKK_CURR"),1);

			//A0403 - Past PUKK facility from state flag
			//tTxt=tTxt+"--A0403--";
			tTxt=tTxt + Pjg(conn.GetFieldValue(dt1,0,"PUKK_PAST"),1);

			//A0404 - Any business license flag
			//tTxt=tTxt+"--A0404--";
			tTxt=tTxt + Pjg(conn.GetFieldValue(dt1,0,"LISENSI_BISNIS"),1);

			//A0405 - Share - main owner
			//tTxt=tTxt+"--A0405--";
			tTxt=tTxt + Pjg(conn.GetFieldValue(dt1,0,"PROSEN_SAHAM"),3);

			//tTxt=tTxt+"--Filler--";
			tTxt=tTxt + IsiBlank(190);
			
			//A0601 - Worst 12 Month BM Collectibility on previous/existing loan
			//tTxt=tTxt+"--A0601--";
			tTxt=tTxt + Pjg(conn.GetFieldValue(dt5,0,"APP_BM_COLL_W12").ToString(),2);

			//A0602 - Current Collectibility
			//tTxt=tTxt+"--A0602--";
			tTxt=tTxt + Pjg(conn.GetFieldValue(dt5,0,"APP_BM_COLL_CURR").ToString(),2);

			//A0603 - Times Collectibility 2A last 12 Months
			//tTxt=tTxt+"--A0603--";
			tTxt=tTxt + Pjg(conn.GetFieldValue(dt5,0,"NUM_APP_COLL_12_2A").ToString(),1);

			//A0604 - Times Collectibility 2B last 12 Months
			//tTxt=tTxt+"--A0604--";
			tTxt=tTxt + Pjg(conn.GetFieldValue(dt5,0,"NUM_APP_COLL_12_2B").ToString(),1);
            
			//A0605 - Times Collectibility 2C last 12 Months
			//tTxt=tTxt+"--A0605--";
			tTxt=tTxt + Pjg(conn.GetFieldValue(dt5,0,"NUM_APP_COLL_12_2C").ToString(),1);

			//A0606 - Business Currently in Black List at Bank Mandiri
			//tTxt=tTxt+"--A0606--";
			tTxt=tTxt + Pjg(conn.GetFieldValue(dt5,0,"PERUSH_BLBM_CURR").ToString(),1);

			//A0607 - Past PUKK loan with BM flag
			//tTxt=tTxt+"--A0607--";
			tTxt=tTxt + Pjg(conn.GetFieldValue(dt1,0,"PUKK_PAST_BM").ToString(),1);			

			//A0608 - Watchlist flag
			//tTxt=tTxt+"--A0608--";
			tTxt=tTxt + Pjg(conn.GetFieldValue(dt5,0,"WATCH_LIST").ToString(),1);

			//A0609 - Times Collectibility 3+ last 12 month
			//tTxt=tTxt+"--A0609--";
			tTxt=tTxt + Pjg(conn.GetFieldValue(dt5,0,"NUM_APP_COLL_12_3PLUS").ToString(),1);

			//tTxt=tTxt+"--Filler--";
			tTxt=tTxt + IsiBlank(89);


			//A0701 - Owner Currently in Black LIst at Bank Mandiri
			//tTxt=tTxt+"--A0701--";
			tTxt=tTxt + Pjg(conn.GetFieldValue(dt5,0,"KEY_BM_BL").ToString(),1);

			//A0702 - Owner Currently Collectibility at Bank Mandiri
			//tTxt=tTxt+"--A0702--";
			tTxt=tTxt + Pjg(conn.GetFieldValue(dt5,0,"KEY_BM_COLL").ToString(),2);

			//A0703 - Owner Times Collectibility 2C+ Last 12 Month
			//tTxt=tTxt+"--A0703--";
			tTxt=tTxt + Pjg(conn.GetFieldValue(dt5,0,"KEY_BM_COLL_2C").ToString(),1);

			//A0704 - Home Owned by Customer ?
			//tTxt=tTxt+"--A0704--";
			tTxt=tTxt + Pjg(conn.GetFieldValue(dt1,0, "IUM_HOMEOWNEDCUST"),1);

			//tTxt=tTxt+"--Filler--";
			tTxt=tTxt + IsiBlank(95);
			
			//A0801 - Management Currently in Black LIst at Bank Mandiri
			//tTxt=tTxt+"--A0801--";
			tTxt=tTxt + Pjg(conn.GetFieldValue(dt5,0,"MGM_BLBM").ToString(),1);

			//A0802 - Management Currently Collectibility at Bank Mandiri
			//tTxt=tTxt+"--A0802--";
			tTxt=tTxt + Pjg(conn.GetFieldValue(dt5,0,"MGM_BM_COLL_CURR").ToString(),2);

			//A0803 - Management Times Collectibility 2C+ Last 12 Month
			//tTxt=tTxt+"--A0803--";
			tTxt=tTxt + Pjg(conn.GetFieldValue(dt5,0,"MGM_BM_COLL_2C").ToString(),1);

			//tTxt=tTxt+"--Filler--";
			tTxt=tTxt + IsiBlank(96);

			//C0001 - Business Currently in Black List at Central Bank 
			//tTxt=tTxt+"--C0001--";
			tTxt=tTxt + Pjg(conn.GetFieldValue(dt5,0,"PERUSH_BLBI_CURR").ToString(),1);

			//C0002 - Business Central Bank Collectibility Level
			//tTxt=tTxt+"--C0002--";
			tTxt=tTxt + Pjg(conn.GetFieldValue(dt5,0,"APP_BI_COLL_CURR").ToString(),1);

			//tTxt=tTxt+"--Filler--";
			tTxt=tTxt + IsiBlank(98);

			//C0100 - Owner Currently in Black List at Central Bank 
			//tTxt=tTxt+"--C0100--";
			tTxt=tTxt + Pjg(conn.GetFieldValue(dt5,0,"KEY_BI_BM").ToString(),1);

			//C0101 - Owner Central Bank Collectibility Level
			//tTxt=tTxt+"--C0101--";
			tTxt=tTxt + Pjg(conn.GetFieldValue(dt5,0,"KEY_BI_COLL_LVL").ToString(),1);

			//tTxt=tTxt+"--Filler--";
			tTxt=tTxt + IsiBlank(98);

			//C0200 - Management Currently in Black List at Central Bank 
			//tTxt=tTxt+"--C0200--";
			tTxt=tTxt + Pjg(conn.GetFieldValue(dt5,0,"MGM_BLBI").ToString(),1);

			//C0201 - Management Central Bank Collectibility Level
			//tTxt=tTxt+"--C0201--";
			tTxt=tTxt + Pjg(conn.GetFieldValue(dt5,0,"MGM_BI_COLL_LVL").ToString(),1);

			//tTxt=tTxt+"--Filler--";
			tTxt=tTxt + IsiBlank(98);

			//A0901 - Assets : Total Assets 
			//tTxt=tTxt+"--A0901--";
			tTxt=tTxt + Pjg(Math.Round(Double.Parse(conn.GetFieldValue(dt2,0,"AKTV_TTLAKTV"))).ToString(),8);

			//A0902 - Fixed Assets : Land & Billing 
			//tTxt=tTxt+"--A0902--";
			tTxt=tTxt + Pjg(Math.Round(Double.Parse(conn.GetFieldValue(dt2,0,"AKTV_TNHBGN"))).ToString(),8);

			//A0903 - % Sales Increase
			//tTxt=tTxt+"--A0903--";
			//Plus
			//A0904 - % Net Income Increase
			//tTxt=tTxt+"--A0904--";
			// check also for middle 

			// for middle only !!!!
			// check small run this code for if 

//			DataTable dt6;
//			string incStr;
//
//			if (strSmall=="0" )
//			{
//				sql = "exec SP_SLS_NEI_INC '" + Request.QueryString["regno"] + "'";
//				conn.QueryString = sql;
//				conn.ExecuteQuery();
//				dt6 = conn.GetDataTable().Copy();
//
//				double salesInc = 0;
//				double incomeInc = 0;
//				if (dt6.Rows.Count > 0) 
//				{
//					double salesYear2 = Double.Parse(conn.GetFieldValue(dt6, 0, "IS_NET_SALES"));
//					double salesYear1 = Double.Parse(conn.GetFieldValue(dt6, 1, "IS_NET_SALES"));
//					salesInc =	(salesYear2 - salesYear1) / salesYear1;
//					double incomeYear2 = Double.Parse(conn.GetFieldValue(dt6, 0, "IS_NET_INCM"));
//					double incomeYear1 = Double.Parse(conn.GetFieldValue(dt6, 1, "IS_NET_INCM"));
//					incomeInc = (incomeYear2 - incomeYear1) / incomeYear1;
//				}
//
//				incStr=Math.Round(salesInc*100).ToString();
//				if (incStr.Length>3)
//				{
//					incStr=Pjg(CovToEBCDIC("999"),3);				
//				}
//				tTxt=tTxt + Pjg(CovToEBCDIC(incStr),3);
//
//				incStr=Math.Round(incomeInc*100).ToString();
//				if (incStr.Length>3)
//				{
//					incStr=Pjg(CovToEBCDIC("999"),3);				
//				}
//				tTxt=tTxt + Pjg(CovToEBCDIC(incStr),3);
//			}
//			else 
//			{
//				incStr = "100";
//				tTxt=tTxt + Pjg(CovToEBCDIC(incStr),3);
//				tTxt=tTxt + Pjg(CovToEBCDIC(incStr),3);
//			}





			/*
			//A0903 - % Sales Increase
			//tTxt=tTxt+"--A0903--";
			if (strSmall=="0" )
			{
				if (Convert.ToString(Math.Round(Double.Parse(conn.GetFieldValue(dt4,0,"SALES_INCREASE"))*100)).Length > 3)
				{
					tTxt=tTxt + CovToEBCDIC("999");
				}
				else
				{
					tTxt=tTxt + Pjg(CovToEBCDIC(Math.Round(Double.Parse(conn.GetFieldValue(dt4,0,"SALES_INCREASE"))*100).ToString()),3);
				}
			}
			else
			{
				tTxt=tTxt + CovToEBCDIC("100");
			}

			//A0904 - % Net Income Increase
			//tTxt=tTxt+"--A0904--";
			if (strSmall=="0" )
			{
				if (Convert.ToString(Math.Round(Double.Parse(conn.GetFieldValue(dt4,0,"NETINCOME_INCREASE"))*100)).Length > 3)
				{
					tTxt=tTxt + "999";
				}
				else
				{
					tTxt=tTxt + Pjg(Math.Round(Double.Parse(conn.GetFieldValue(dt4,0,"NETINCOME_INCREASE"))*100).ToString(),3);
				}
			}
			else
			{
				tTxt=tTxt + CovToEBCDIC("100");
			}
			*/
			



			if (Convert.ToString(Math.Abs(Math.Round(Double.Parse(conn.GetFieldValue(dt4,0,"SALES_INCREASE"))*100))).Length > 3)
			{
				tTxt=tTxt + CovToEBCDIC("999");
			}
			else
			{
				tTxt=tTxt + Pjg(CovToEBCDIC(Math.Round(Double.Parse(conn.GetFieldValue(dt4,0,"SALES_INCREASE"))*100).ToString()),3);
			}



			if (Convert.ToString(Math.Abs(Math.Round(Double.Parse(conn.GetFieldValue(dt4,0,"NETINCOME_INCREASE"))*100))).Length > 3)
			{
				tTxt=tTxt + CovToEBCDIC("999");
			}
			else
			{
				tTxt=tTxt + Pjg(CovToEBCDIC(Math.Round(Double.Parse(conn.GetFieldValue(dt4,0,"NETINCOME_INCREASE"))*100).ToString()),3);
			}


			//A0905 - Cost of goods sold amt (Millions)
			//tTxt=tTxt+"--A0905--";
			tTxt=tTxt + Pjg(Math.Round(Double.Parse(conn.GetFieldValue(dt1,0,"IU_PSRL_HPP_SATUAN"))).ToString(),8);

			//A0906 - General Expense & Administration Ammount
			//tTxt=tTxt+"--A0906--";
			tTxt=tTxt + Pjg(Math.Round(Double.Parse(conn.GetFieldValue(dt1,0,"IU_PSRL_BIAYAUMUMADM"))).ToString(),8);

			//A0907 - TC : Trade Cycle Days
			//tTxt=tTxt+"--A0907--";
			//tTxt=tTxt + Pjg(CovToEBCDIC(Math.Round(Double.Parse(conn.GetFieldValue(dt4,0,"TRADE_CYCLE"))).ToString()),3);
			if (Convert.ToString(Math.Abs(Math.Round(Double.Parse(conn.GetFieldValue(dt4,0,"TRADE_CYCLE"))))).Length > 3)
			{
				tTxt=tTxt + CovToEBCDIC("999");
			}
			else
			{
				tTxt=tTxt + Pjg(CovToEBCDIC(Math.Round(Double.Parse(conn.GetFieldValue(dt4,0,"TRADE_CYCLE"))).ToString()),3);
			}



			//tTxt=tTxt + conn.GetFieldValue(dt2,0,"");
			//A0908 - Purchasing Plan Amount
			//tTxt=tTxt+"--A0908--"; 
			tTxt=tTxt + Pjg(Math.Round(Double.Parse(conn.GetFieldValue(dt1,0,"PURCHASING_PLANT_AMOUNT_M"))).ToString(),8);

			//tTxt=tTxt + conn.GetFieldValue(dt2,0,"");
			//A0909 - Existing W/C limit in BM
			//tTxt=tTxt+"--A0909--";
			tTxt=tTxt + Pjg(Math.Round(Double.Parse(conn.GetFieldValue(dt5, 0, "KMK_LMT_BM_CURR"))).ToString(),8);

			//tTxt=tTxt + conn.GetFieldValue(dt2,0,"");
			//A0910 - Avg Net Profit
			//tTxt=tTxt+"--A0910--";			
			tTxt=tTxt + Pjg(CovToEBCDIC(Math.Round(Double.Parse(conn.GetFieldValue(dt1, 0, "ML_AVGNET"))).ToString()),7);

			//tTxt=tTxt + conn.GetFieldValue(dt2,0,"");
			//A0911 - Existing Facility Flag
			//tTxt=tTxt+"--A0911--";
			if (conn.GetFieldValue(dt1,0,"ML_EXFAS")==""||conn.GetFieldValue(dt1,0,"ML_EXFAS")=="0")
			{
				tTxt=tTxt + "A";
			}
			else
			{
				tTxt=tTxt + Pjg(conn.GetFieldValue(dt1,0,"ML_EXFAS").ToString(),1);
			}
			//tTxt=tTxt + conn.GetFieldValue(dt2,0,"");
			//A0912 - % Interest pa (x100)
			//tTxt=tTxt+"--A0912--";
			//tTxt=tTxt + Pjg((100.00*(Math.Round(Double.Parse(conn.GetFieldValue(dt1,0,"PRSN_INTEREST_PA")))).ToString()),4);
			double vPRSN_INTEREST_PA = 0;
			try { vPRSN_INTEREST_PA = Double.Parse(conn.GetFieldValue(dt1,0,"PRSN_INTEREST_PA")); }
			catch {}
			vPRSN_INTEREST_PA = Math.Round(vPRSN_INTEREST_PA);
			vPRSN_INTEREST_PA = vPRSN_INTEREST_PA * 100;
			tTxt=tTxt + Pjg(vPRSN_INTEREST_PA.ToString(),4);


			//tTxt=tTxt + conn.GetFieldValue(dt2,0,"");
			//A0913 - Ters in months
			//tTxt=tTxt+"--A0913--";
			tTxt=tTxt + Pjg(conn.GetFieldValue(dt1,0,"TERMYN_MONTH").ToString(),2);

			//tTxt=tTxt + conn.GetFieldValue(dt2,0,"");
			//A0914 - Acceptable Project Cost
			//tTxt=tTxt+"--A0914--";
			tTxt=tTxt + Pjg(Math.Round(Double.Parse(conn.GetFieldValue(dt1,0,"ACCEPT_PROJECT_COST_KI"))).ToString(),8);

			//tTxt=tTxt + conn.GetFieldValue(dt2,0,"");
			//A0915 - Contractor Plafond : Tot Value of Projects 
			//tTxt=tTxt+"--A0915--";
			tTxt=tTxt + Pjg(Math.Round(Double.Parse(conn.GetFieldValue(dt1,0,"PLAFOND_TOT_VAL_PROJECTS"))).ToString(),8);

			//tTxt=tTxt + conn.GetFieldValue(dt2,0,"");
			//A0916 - Contractor Plafond : % project cost
			//tTxt=tTxt+"--A0916--";
			tTxt=tTxt + Pjg(Math.Round(Double.Parse(conn.GetFieldValue(dt1,0,"PLAFOND_PRSN_PROJ_COST"))).ToString(),3);

			//tTxt=tTxt + conn.GetFieldValue(dt2,0,"");
			//A0917 - Contractor Plafond " terma of payment (months)
			//tTxt=tTxt+"--A0917--";
			tTxt=tTxt + Pjg(conn.GetFieldValue(dt1,0,"PLAFOND_TOP").ToString(),2);

			//tTxt=tTxt + conn.GetFieldValue(dt2,0,"");
			//A0918 - Contractor Plafond : downpayment amount
			//tTxt=tTxt+"--A0918--";
			tTxt=tTxt + Pjg(Math.Round(Double.Parse(conn.GetFieldValue(dt1,0,"PLAFOND_DP"))).ToString(),8);

			//tTxt=tTxt + conn.GetFieldValue(dt2,0,"");
			//A0919 - Existing WC plafond limit in BM
			//tTxt=tTxt+"--A0919--";
			tTxt=tTxt + Pjg(Math.Round(Double.Parse(conn.GetFieldValue(dt1,0,"CL_EXIST_WC_BM"))).ToString(),8);

			//tTxt=tTxt + conn.GetFieldValue(dt2,0,"");
			//A0920 - Existing WC Plafond limit in other bank
			//tTxt=tTxt+"--A0920--";
			tTxt=tTxt + Pjg(Math.Round(Double.Parse(conn.GetFieldValue(dt1, 0, "CL_EXIST_WC_OBANK"))).ToString(),8);

			//tTxt=tTxt + conn.GetFieldValue(dt2,0,"");
			//A0921 - Contrctor Termyn : Project Cost ( 1 Project)
			//tTxt=tTxt+"--A0921--";
			tTxt=tTxt + Pjg(Math.Round(Double.Parse(conn.GetFieldValue(dt1,0,"PROJ_COST"))).ToString(),8);

			//tTxt=tTxt + conn.GetFieldValue(dt2,0,"");
			//A0922 - Contractor Termyn : Number of Termyn 
			//tTxt=tTxt+"--A0922--";
			tTxt=tTxt + Pjg(conn.GetFieldValue(dt1,0,"NUM_TERMYN").ToString(),2);

			//tTxt=tTxt + conn.GetFieldValue(dt2,0,"");
			//A0923 - SB Non Cash Value of Peoject Pa - General
			//tTxt=tTxt+"--A0923--";
			tTxt=tTxt + Pjg(Math.Round(Double.Parse(conn.GetFieldValue(dt1,0,"SB_NC_PROJ_PA_GENERAL"))).ToString(),8);

			//tTxt=tTxt + conn.GetFieldValue(dt2,0,"");
			//A0924 - SB Non Cash Value of Project pa - Purchase bbond
			//tTxt=tTxt+"--A0924--";
			tTxt=tTxt + Pjg(Math.Round(Double.Parse(conn.GetFieldValue(dt1,0,"NC_PROJ_PA_PURCHASE_BOND"))).ToString(),8);

			//tTxt=tTxt + conn.GetFieldValue(dt2,0,"");
			//A0925 - SB % Probability of Success bid bond
			//tTxt=tTxt+"--A0925--";
			tTxt=tTxt + Pjg(Math.Round(Double.Parse(conn.GetFieldValue(dt1,0,"PRSN_PROB_SUCCESS_BID_BOND"))).ToString(),3);

			//tTxt=tTxt + conn.GetFieldValue(dt2,0,"");
			//A0926 - % Bid Bond
			//tTxt=tTxt+"--A0926--";
			tTxt=tTxt + Pjg(Math.Round(Double.Parse(conn.GetFieldValue(dt1,0,"BID_BOND"))).ToString(),3);

			//tTxt=tTxt + conn.GetFieldValue(dt2,0,"");
			//A0927 - % Advance Bond
			//tTxt=tTxt+"--A0927--";
			tTxt=tTxt + Pjg(Math.Round(Double.Parse(conn.GetFieldValue(dt1,0,"ADV_BOND"))).ToString(),3);

			//tTxt=tTxt + conn.GetFieldValue(dt2,0,"");
			//A0928 - % Performance Bond
			//tTxt=tTxt+"--A0928--";
			tTxt=tTxt + Pjg(Math.Round(Double.Parse(conn.GetFieldValue(dt1,0,"PRFRMN_BOND"))).ToString(),3);

			//tTxt=tTxt + conn.GetFieldValue(dt2,0,"");
			//A0929 - % Retention Bond
			//tTxt=tTxt+"--A0929--";
			tTxt=tTxt + Pjg(Math.Round(Double.Parse(conn.GetFieldValue(dt1,0,"PRSN_RET_BOND"))).ToString(),3);

			//tTxt=tTxt + conn.GetFieldValue(dt2,0,"");
			//A0930 - % Purchase Bond
			//tTxt=tTxt+"--A0930--";
			tTxt=tTxt + Pjg(Math.Round(Double.Parse(conn.GetFieldValue(dt1,0,"PRSN_PURCHASE_BOND"))).ToString(),3);

			//vtTxt=tTxt + conn.GetFieldValue(dt2,0,"");
			//A0931 - SB Avg Value L/C in a year
			//tTxt=tTxt+"--A0931--";
			tTxt=tTxt + Pjg(Math.Round(Double.Parse(conn.GetFieldValue(dt1,0,"SB_AVG_VALUELC_YEAR"))).ToString(),8);

			//tTxt=tTxt + conn.GetFieldValue(dt2,0,"");
			//A0932 - SB Avg term of L/C in a year (turnover in months)
			//tTxt=tTxt+"--A0932--";
			tTxt=tTxt + Pjg(Math.Round(Double.Parse(conn.GetFieldValue(dt1,0,"SB_AVG_TERMLC"))).ToString(),3);

			//tTxt=tTxt + conn.GetFieldValue(dt2,0,"");
			//A0933 - MC Contractor Peak deficit cash flow
			//tTxt=tTxt+"--A0933--";
			tTxt=tTxt + Pjg(Math.Round(Double.Parse(conn.GetFieldValue(dt1,0,"MC_CONT_PEAK_DEFICIT_CF"))).ToString(),8);

			//tTxt=tTxt + conn.GetFieldValue(dt2,0,"");
			//A0934 - MC Non Cash Total Amount of Contract in Millions
			//tTxt=tTxt+"--A0934--";
			tTxt=tTxt + Pjg(Math.Round(Double.Parse(conn.GetFieldValue(dt1,0,"MC_NC_TOTAMOUNT"))).ToString(),8);

			//tTxt=tTxt + conn.GetFieldValue(dt2,0,"");
			//A0934 - Contractor Turnkey Project Cost
			//tTxt=tTxt+"--A0935--";
			tTxt=tTxt + Pjg(Math.Round(Convert.ToDouble(conn.GetFieldValue(dt1,0,"CONTR_TURNKEY_PROJ_COST"))).ToString(),8);

			//Isi Filler
			tTxt=tTxt+IsiBlank(305);

			//Format Response (kondisi blank)
			tTxt=tTxt+IsiBlank(343);

			//Isi Filler
			tTxt=tTxt+IsiBlank(957);

			//tTxt=tTxt+"--END OF FILE";

			///////////////////////////////////////////////////////////
			///	mengambil direktori penyimpan hasil FairIsaac
			///	
			conn.QueryString = "select FAIRISAAC_DIR from APP_PARAMETER";
			conn.ExecuteQuery();

			StreamWriter Sw;
			String strFileName;
			strFileName = @conn.GetFieldValue("FAIRISAAC_DIR");
			Sw = File.CreateText(strFileName);
			Sw.WriteLine(tTxt);
			Sw.Close();
			
			conn.QueryString="delete from SCORING_MESSAGE where ap_regno='" + Request.QueryString["regno"] + "' and sumberdata = 'FINALSCORING'";
			conn.ExecuteNonQuery();

			conn.QueryString="insert into SCORING_MESSAGE values('" + Request.QueryString["regno"] + "','" + tTxt + "','FINALSCORING','0')";
			conn.ExecuteNonQuery();

			return true;
		}


		private void adjustImpactOnScoringInfoUmum() 
		{			
			string	LAMAJADINASABAH = "",  NAMA_PERUSHAAN = "", JML_KREDIT = "", NAMAPEMOHON = "", 
				EXPOSUREEXISTING = "", TGLLAHIR  = "",	  BULANLAHIR = "", THN_LAHIR = "",
				JNSKELAMIN = "",       JML_ANAK = "",		  BLN_MENETAP = "",THN_MENETAP = "",
				UMURKEYPERSON = "",    STATUSKAWIN = "",    PENDAKHIR  = "", KOTAUSAHA = "",
				KODEPOS = "",          THN_MILIKUSAHA = "", BLN_MILIKUSAHA = "", JML_PEGAWAI = "",
				PROSENSAHAM = "",      TGL_USAHA = "",      BLN_USAHA = "",    THN_USAHA = "";

			string UmurThn,UmurBln,Umur;

			// hitung Lama menjadi nasabah BM ########## start ####################################### by ahmad 
			conn.QueryString="SP_SCORING_TGL '"+ Request.QueryString["curef"] +"'";
			conn.ExecuteQuery();

			string Tahun = conn.GetFieldValue("TAHUN").ToString();
			string Bulan = conn.GetFieldValue("BULAN").ToString();

			LAMAJADINASABAH = Strings.Right(("0000" + Tahun),2) + Strings.Right(("0000"+ Bulan),2);
			
			// hitung Lama menjadi nasabah BM ########## end ####################################### by ahmad 

			string str="select cu_custtypeid from customer a inner join application b on a.cu_ref=b.cu_ref where b.ap_regno='" + Request.QueryString["regno"] + "'";
			conn.QueryString=str;
			conn.ExecuteQuery();
			if(conn.GetFieldValue("cu_custtypeid")=="02")	// perorangan
			{
				str="select *,cast((isnull(datediff(m,tgllahir,getdate()),0)/12) as varchar) as UmurThn, cast((isnull(datediff(m,tgllahir,getdate()),0)%12) as varchar)  as UmurBln from VW_PRESCORING_POPULATE_PERSONAL where ap_regno='" + Request.QueryString["regno"] + "'";
				conn.QueryString=str;
				conn.ExecuteQuery();
				JML_KREDIT = GlobalTools.MoneyFormat(conn.GetFieldValue("Limit"));
				if (conn.GetFieldValue("TglLahir").Equals(null)||(!conn.GetFieldValue("TglLahir").Equals(""))) 
				{
					DateTime a = Convert.ToDateTime(conn.GetFieldValue("TglLahir"));
					TGLLAHIR =a.Day.ToString();
					BULANLAHIR =a.Month.ToString();
					THN_LAHIR =a.Year.ToString();
				}
				if (conn.GetFieldValue("JenisKelamin")=="01")
				{
					JNSKELAMIN ="L";
				}
				else if (conn.GetFieldValue("JenisKelamin")=="02")
				{
					JNSKELAMIN ="P";
				}
				JML_ANAK = conn.GetFieldValue("JmlAnak");
				BLN_MENETAP =conn.GetFieldValue("BulanMenetap");
				THN_MENETAP =conn.GetFieldValue("TahunMenetap");
				//DDL_STATMILIKRMH.SelectedValue=conn.GetFieldValue("StatusRumah");

				UmurThn=conn.GetFieldValue("UmurThn");
				if (UmurThn.Length<2){UmurThn="0"+UmurThn;}
				UmurBln=conn.GetFieldValue("UmurBln");
				if (UmurBln.Length<2){UmurBln="0"+UmurBln;}
				Umur=UmurThn+UmurBln;
				UMURKEYPERSON =Umur;

				STATUSKAWIN =conn.GetFieldValue("StatusKawin");
				PENDAKHIR =conn.GetFieldValue("Pendidikan");
				//TXT_KOTAUSAHA.Text=conn.GetFieldValue("KotaLokasiUsaha");
				//TXT_KODEPOS.Text=conn.GetFieldValue("KodePosLokasiUsaha");
				THN_MILIKUSAHA =conn.GetFieldValue("LamaMilikTahun");
				BLN_MILIKUSAHA =conn.GetFieldValue("LamaMilikBulan");
				//TXT_LAMAJADINASABAH.Text=""; //ahmad
				JML_PEGAWAI  ="0";
				PROSENSAHAM ="0";
				if (conn.GetFieldValue("TglPendirian").Equals(null)||(!conn.GetFieldValue("TglPendirian").Equals(""))) 
				{
					DateTime a = Convert.ToDateTime(conn.GetFieldValue("TglPendirian"));
					TGL_USAHA =a.Day.ToString();
					BLN_USAHA =a.Month.ToString();
					THN_USAHA =a.Year.ToString();
				}
			}
			else if (conn.GetFieldValue("cu_custtypeid")=="01")	// badan usaha
			{
				str="select *,cast((isnull(datediff(m,tgllahir,getdate()),0)/12) as varchar) as UmurThn, cast((isnull(datediff(m,tgllahir,getdate()),0)%12) as varchar)  as UmurBln  from VW_PRESCORING_POPULATE_company where ap_regno='" + Request.QueryString["regno"] + "'";
				conn.QueryString=str;
				conn.ExecuteQuery();
				//TXT_NAMA_PERUSHAAN.Text=conn.GetFieldValue("NamaPerusahaan");
				JML_KREDIT = GlobalTools.MoneyFormat(conn.GetFieldValue("Limit"));
				//TXT_NAMAPEMOHON.Text=conn.GetFieldValue("NamaKeyPerson");
				//TXT_EXPOSUREEXISTING.Text = GlobalTools.MoneyFormat(conn.GetFieldValue("EXPOSUREEXISTING"));
				if (conn.GetFieldValue("TglLahir").Equals(null)||(!conn.GetFieldValue("TglLahir").Equals(""))) 
				{
					DateTime a = Convert.ToDateTime(conn.GetFieldValue("TglLahir"));
					TGLLAHIR =a.Day.ToString();
					BULANLAHIR =a.Month.ToString();
					THN_LAHIR =a.Year.ToString();
				}
				if (conn.GetFieldValue("JenisKelamin")=="01")
				{
					JNSKELAMIN ="L";
				}
				else if (conn.GetFieldValue("JenisKelamin")=="02")
				{
					JNSKELAMIN ="P";
				}
				// TXT_JML_ANAK.Text="0"; versi Azhari
				JML_ANAK = conn.GetFieldValue("JmlAnak"); // versi Gatot
				try {BLN_MENETAP =conn.GetFieldValue("BulanMenetap");} 
				catch {}
				THN_MENETAP =conn.GetFieldValue("TahunMenetap");

				//				try {DDL_STATMILIKRMH.SelectedValue=conn.GetFieldValue("StatusRumah");} 
				//				catch {}

				UmurThn=conn.GetFieldValue("UmurThn");
				if (UmurThn.Length<2){UmurThn="0"+UmurThn;}
				UmurBln=conn.GetFieldValue("UmurBln");
				if (UmurBln.Length<2){UmurBln="0"+UmurBln;}
				Umur=UmurThn+UmurBln;
				UMURKEYPERSON =Umur;

				PROSENSAHAM =conn.GetFieldValue("PersenSaham");
				//DDL_STATUSKAWIN.SelectedValue=conn.GetFieldValue("StatusKawin");
				//DDL_PENDAKHIR.SelectedValue=conn.GetFieldValue("Pendidikan");
				JML_PEGAWAI =conn.GetFieldValue("JmlKaryawan");
				//TXT_KOTAUSAHA.Text=conn.GetFieldValue("KotaLokasiUsaha");
				//TXT_KODEPOS.Text=conn.GetFieldValue("KodePosLokasiUsaha");
				THN_MILIKUSAHA =conn.GetFieldValue("LamaMilikTahun");
				BLN_MILIKUSAHA =conn.GetFieldValue("LamaMilikBulan");
				//TXT_LAMAJADINASABAH.Text="0";
				//DDL_STATMILIKRMH.SelectedValue=conn.GetFieldValue("StatusMilikRumah");
				if (conn.GetFieldValue("TglPendirian").Equals(null)||(!conn.GetFieldValue("TglPendirian").Equals(""))) 
				{
					DateTime a = Convert.ToDateTime(conn.GetFieldValue("TglPendirian"));
					TGL_USAHA =a.Day.ToString();
					BLN_USAHA =a.Month.ToString();
					THN_USAHA =a.Year.ToString();
				}
			}

			
			string PSRL_PENJUALANTAHUNAN = "",
				PSRL_PENJUALANTAHUNAN_INSATUAN = "",
				PSRL_BIAYAUMUMADM = "",
				PSN_KASBANK = "",
				PSN_KASBANK_INSATUAN = "",
				PSN_TTLAKTIVALCR = "",
				PSN_TTLAKTIVALCR_INSATUAN = "",
				TOTMODAL = "",
				TOTMODAL_INSATUAN = "",
				PSN_TNHBGN="",
				HUTANG="",
				HUTANG_INSATUAN="",
				PSN_TTLAKTIVA="";

			conn.QueryString = "select AP_BUSINESSUNIT from APPLICATION where AP_REGNO = '" + lbl_regno.Text + "'";
			conn.ExecuteQuery();
			string vAP_BUSINESSUNIT = conn.GetFieldValue("AP_BUSINESSUNIT");

			conn.QueryString = "select IN_SMALL, IN_MIDDLE from RFINITIAL";
			conn.ExecuteQuery();
			string vIN_SMALL, vIN_MIDDLE;
			vIN_SMALL = conn.GetFieldValue("IN_SMALL");
			vIN_MIDDLE = conn.GetFieldValue("IN_MIDDLE");
																													 

			//////////////////////////////////////////////////////////////////////////
			/// LABA RUGI 
			/// Mengambil : IS_PENJ, IS_ADMOPR
			/// 
//			if (vAP_BUSINESSUNIT == vIN_SMALL) 
//			{
//				conn.QueryString = "select * from CA_LABARUGI_SMALL where AP_REGNO = '" + lbl_regno.Text + "'";
//			}
//			else 
//			{
//				conn.QueryString = "select IS_NET_SALES as IS_PENJ, IS_SELLING_GENADM as IS_ADMOPR " + 
//					"from CA_LABARUGI_MIDDLE where AP_REGNO = '" + lbl_regno.Text + "'";
//			}

			conn.QueryString = "exec SP_CA_LABARUGI '" + lbl_regno.Text + "'";
			conn.ExecuteQuery();

			if(conn.GetRowCount()>0)
			{
				// Sales (millions)
				double x = Convert.ToDouble(conn.GetFieldValue("IS_PENJ"));
				double x_satuan = 0;
				PSRL_PENJUALANTAHUNAN = x.ToString("##,##0.00");
				x_satuan = x / 1000;
				x_satuan = Math.Round(x_satuan);
				PSRL_PENJUALANTAHUNAN_INSATUAN = x_satuan.ToString();

				// General Expense & Adm. Amount
				x = Convert.ToDouble(conn.GetFieldValue("IS_ADMOPR"));
				PSRL_BIAYAUMUMADM = x.ToString("##,##0.00");				
				
				//				x = Convert.ToDouble(conn.GetFieldValue("IS_HPP"));
				//				PSRL_HPP = x.ToString("##,##0.00");
				//				x_satuan = x / 1000;
				//				x_satuan = Math.Round(x_satuan);
				//				PSRL_HPP_INSATUAN = x_satuan.ToString();
			}

			////////////////////////////////////////////////////////////////////////////////
			///	NERACA (SMALL)
			///	Mengambil : AKTV_KASBANK, AKTV_TTLAKTLCR, PASV_TTLMODAL
			///	
//			if (vAP_BUSINESSUNIT == vIN_SMALL) 
//			{
//				conn.QueryString = "select * from CA_NERACA_SMALL where AP_REGNO = '" + lbl_regno.Text + "'";
//			} 
//			else 
//			{
//				conn.QueryString = "select BS_CASH_BANK, BS_CURRASST, BS_TTL_NETWORTH " + 
//					"from CA_NERACA_MIDDLE where AP_REGNO = '" + lbl_regno.Text + "'";
//			}

			conn.QueryString = "exec SP_CA_NERACA '" + lbl_regno.Text + "'";
			conn.ExecuteQuery();

			if(conn.GetRowCount()>0)
			{
				double x = Convert.ToDouble(conn.GetFieldValue("AKTV_KASBANK"));
				double x_satuan = 0;
				
				// Cash
				x_satuan = x / 1000;
				x_satuan = Math.Round(x_satuan);
				PSN_KASBANK = GlobalTools.MoneyFormat(conn.GetFieldValue("AKTV_KASBANK"));
				PSN_KASBANK_INSATUAN = x_satuan.ToString();
				
				// Current Assets (millions)
				x = Convert.ToDouble(conn.GetFieldValue("AKTV_TTLAKTLCR"));
				x_satuan = x / 1000;
				x_satuan = Math.Round(x_satuan);
				PSN_TTLAKTIVALCR = x.ToString("##,##0.00");
				PSN_TTLAKTIVALCR_INSATUAN = x_satuan.ToString();

				x = Convert.ToDouble(conn.GetFieldValue("AKTV_TNHBGN"));
				PSN_TNHBGN = x.ToString("##,##0.00");

				x = Convert.ToDouble(conn.GetFieldValue("PASV_TTLHT"));
				x_satuan = x / 1000;
				x_satuan = Math.Round(x_satuan);
				HUTANG = x.ToString("##,##0.00");
				HUTANG_INSATUAN = x_satuan.ToString();

				// Net Worth
				x = Convert.ToDouble(conn.GetFieldValue("PASV_TTLMODAL"));
				x_satuan = x / 1000;
				x_satuan = Math.Round(x_satuan);
				TOTMODAL = x.ToString("##,##0.00");
				TOTMODAL_INSATUAN = x_satuan.ToString();

				x = Convert.ToDouble(conn.GetFieldValue("AKTV_TTLAKTV"));
				PSN_TTLAKTIVA = x.ToString("##,##0.00");
			}
			///////////////////////////////////////////////////
			/// update scoring_infoumum
			/// 
			conn.QueryString = "exec SCORING_ADJUSTINFOUMUM1 '" + lbl_regno.Text + "', " + 
				"'FINALSCORING',";
			conn.QueryString += "'" + LAMAJADINASABAH + "',";
			//conn.QueryString += "'" + NAMA_PERUSHAAN + "',";
			//conn.QueryString += "'" + JML_KREDIT+ "',";
			//conn.QueryString += "'" + NAMAPEMOHON+ "',";
			//conn.QueryString += "'" + EXPOSUREEXISTING + "',";
			//conn.QueryString += "'" + TGLLAHIR + "',";
			//conn.QueryString += "'" + BULANLAHIR + "',";
			//conn.QueryString += "'" + THN_LAHIR + "',";
			conn.QueryString += "'" + JNSKELAMIN + "',";
			conn.QueryString += "'" + JML_ANAK + "',";
			conn.QueryString += "'" + BLN_MENETAP + "',";
			conn.QueryString += "'" + THN_MENETAP + "',";
			conn.QueryString += "'" + UMURKEYPERSON + "',";
			//conn.QueryString += "'" + STATUSKAWIN + "',";
			//conn.QueryString += "'" + PENDAKHIR + "',";
			//conn.QueryString += "'" + KOTAUSAHA + "',";
			//conn.QueryString += "'" + KODEPOS + "',";
			//conn.QueryString += "'" + THN_MILIKUSAHA + "',";
			//conn.QueryString += "'" + BLN_MILIKUSAHA + "',";
			//conn.QueryString += "'" + JML_PEGAWAI + "',";
			conn.QueryString += "'" + tool.ConvertFloat(PROSENSAHAM) + "',";
			conn.QueryString += "'" + TGL_USAHA + "',";
			conn.QueryString += "'" + BLN_USAHA + "',";
			conn.QueryString += "'" + THN_USAHA + "'";
			conn.ExecuteNonQuery();

			
			conn.QueryString = "exec SCORING_ADJUSTINFOUMUM2 '" + lbl_regno.Text + "', " + 
				"'FINALSCORING',";
			conn.QueryString += "'" + tool.ConvertFloat(PSRL_PENJUALANTAHUNAN_INSATUAN) + "',";
			conn.QueryString += "'" + tool.ConvertFloat(PSRL_BIAYAUMUMADM) + "',";
			conn.QueryString += "'" + tool.ConvertFloat(PSN_KASBANK_INSATUAN) + "',";
			conn.QueryString += "'" + tool.ConvertFloat(PSN_TTLAKTIVALCR_INSATUAN) + "',";
			conn.QueryString += "'" + tool.ConvertFloat(TOTMODAL_INSATUAN) + "'";
			conn.ExecuteNonQuery();
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


		private void ViewMenu()
		{
			try 
			{
				// "+Request.QueryString["mc"]+"
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
							strtemp = "regno=" + Request.QueryString["regno"] + "&curef="+Request.QueryString["curef"]+"&tc="+Request.QueryString["tc"];
						else	strtemp = "regno=" + Request.QueryString["regno"] + "&curef="+Request.QueryString["curef"]+"&mc="+Request.QueryString["mc"]+"&tc="+Request.QueryString["tc"];
						
						if (conn.GetFieldValue(i,3).IndexOf("?jnsnasabah=") < 0 && conn.GetFieldValue(i,3).IndexOf("&jnsnasabah=") < 0)  
							strtemp = strtemp + "&jnsnasabah=" + LBL_CU_JNSNASABAH.Text;

						if (conn.GetFieldValue(i,3).IndexOf("?programid=") < 0 && conn.GetFieldValue(i,3).IndexOf("&programid=") < 0)  
							strtemp = strtemp + "&programid=" + LBL_PROGRAMID.Text;
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

		private void ViewSubMenu() 
		{
			try 
			{
				conn.QueryString = "select CU_JNSNASABAH, PROG_CODE " + 
					"from CUSTOMER C left join APPLICATION A on C.CU_REF = A.CU_REF where " +
					"A.AP_REGNO = '" + Request.QueryString["regno"] + "'";
				conn.ExecuteQuery();
				
				string CU_JNSNASABAH, PROG_CODE;
				CU_JNSNASABAH = conn.GetFieldValue("CU_JNSNASABAH");
				PROG_CODE = conn.GetFieldValue("PROG_CODE");

				conn.QueryString = "select PROGRAMID_SEQ, MENUCODE, SM_MENUDISPLAY, SM_LINKNAME from SCREENSUBMENU " + 
					"where LG_CODE in " + 
					"(select distinct LG_CODE from RFCAFINSTATEMENT " + 
					"where programid = '"+ PROG_CODE + 
					"' and nasabahid = '" + CU_JNSNASABAH +
					"') and programid = '" + PROG_CODE + "' and MENUCODE = '" + Request.QueryString["mc"] + "'";
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
							strtemp = "regno=" + Request.QueryString["regno"] + "&curef="+Request.QueryString["curef"]+"&tc="+Request.QueryString["tc"];						
						
						else strtemp = "regno=" + Request.QueryString["regno"] + "&curef="+Request.QueryString["curef"]+"&mc="+Request.QueryString["mc"]+"&tc="+Request.QueryString["tc"];
						if (conn.GetFieldValue(i,3).IndexOf("?scr=") < 0 && conn.GetFieldValue(i,3).IndexOf("&scr=") < 0) 
							strtemp += "&"+Request.QueryString["scr"];
						if (conn.GetFieldValue(i,3).IndexOf("?par=") < 0 && conn.GetFieldValue(i,3).IndexOf("&par=") < 0) 
							strtemp += "&"+Request.QueryString["par"];
						//t.ForeColor = Color.MidnightBlue; 
					}
					else 
					{
						strtemp = "";
						t.ForeColor = Color.Red; 
					}
					t.NavigateUrl = conn.GetFieldValue(i, 3)+strtemp;
					SubMenu.Controls.Add(t);
					SubMenu.Controls.Add(new LiteralControl("&nbsp;&nbsp;&nbsp;"));
				}
			} 
			catch (Exception ex) 
			{
				Console.Write(ex.Message);
			}
		}

		private void ViewDataApplication()
		{
			lbl_regno.Text		= Request.QueryString["regno"];
			lbl_curef.Text		= Request.QueryString["curef"];
			lbl_tc.Text=Request.QueryString["tc"];

			HyperLink infoUmum = new HyperLink();
			infoUmum.Text = "Rasio Keuangan";
			infoUmum.Font.Bold = true;

			conn.QueryString = "select BUSINESSUNIT from APPLICATION a left join rfprogram p on a.prog_code = p.programid " + 
				"where AP_REGNO = '" + Request.QueryString["regno"] + "' and p.areaid = '" + Session["AreaID"] + "'";
			conn.ExecuteQuery();
			if (conn.GetFieldValue("BUSINESSUNIT") == "BPMCR")	//bank pundi micro
			{
				infoUmum.NavigateUrl = "../CreditAnalysis/Ratio_KMK_KI_Small.aspx?mode=retrieve&regno=" + Request.QueryString["regno"] + "&curef=" + Request.QueryString["curef"] + "&mc=" + Request.QueryString["mc"] + "&tc=" + Request.QueryString["tc"] + "&sta=view&viewmode=1";
			}
			else if (conn.GetFieldValue("BUSINESSUNIT") == "BPMCR") //bank pundi sme
			{
				infoUmum.NavigateUrl = "../CreditAnalysis/Ratio_KMK_KI_Medium.aspx?mode=retrieve&regno=" + Request.QueryString["regno"] + "&curef=" + Request.QueryString["curef"] + "&mc=" + Request.QueryString["mc"] + "&tc=" + Request.QueryString["tc"] + "&sta=view&viewmode=1";
			}

			//infoUmum.NavigateUrl = "../Scoring/ScoringRatio.aspx?regno="+lbl_regno.Text+"&curef="+ lbl_curef.Text+ "&mc=" + Request.QueryString["mc"]+ "&tc=" + Request.QueryString["tc"] + "&mode=retrieve";
			infoUmum.Target = "if2";

			HyperLink hubBank = new HyperLink();
			hubBank.Text = "Hubungan dengan Bank";
			hubBank.Font.Bold = true;
			hubBank.NavigateUrl = "../Scoring/ScoringHubunganBank.aspx?regno="+lbl_regno.Text+"&curef="+lbl_curef.Text+"&mc=" + Request.QueryString["mc"]+ "&tc=" + Request.QueryString["tc"];
			hubBank.Target = "if2";

			HyperLink infoKeuangan = new HyperLink();
			infoKeuangan.Text = "Informasi Umum";
			infoKeuangan.Font.Bold = true;
			infoKeuangan.NavigateUrl = "../Scoring/ScoringInformasiUmum.aspx?regno="+lbl_regno.Text+"&curef="+lbl_curef.Text+ "&mc=" + Request.QueryString["mc"]+ "&tc=" + Request.QueryString["tc"];
			infoKeuangan.Target = "if2";

            if (ConfigurationManager.AppSettings["IsCAS"] != "YES")
            {
                PlaceHolder1.Controls.Add(infoUmum);
                PlaceHolder1.Controls.Add(new LiteralControl("&nbsp;&nbsp;"));
            }
			PlaceHolder1.Controls.Add(hubBank);
			PlaceHolder1.Controls.Add(new LiteralControl("&nbsp;&nbsp;"));
			PlaceHolder1.Controls.Add(infoKeuangan);
			PlaceHolder1.Controls.Add(new LiteralControl("&nbsp;&nbsp;"));
		}


		private void ViewData()
		{
			conn.QueryString ="select * from vw_prescoring_main where ap_regno='" + Request.QueryString["regno"] + "'";
			conn.ExecuteQuery();
//			TXT_AP_REGNO.Text=conn.GetFieldValue(0,0);
//			TXT_CU_REF.Text=conn.GetFieldValue(0,1);
//			TXT_AP_SIGNDATE.Text=conn.GetFieldValue(0,9);
//			TXT_BRANCH_NAME.Text=conn.GetFieldValue(0,13);
//			TXT_AP_RELMNGR.Text=conn.GetFieldValue(0,12);
//			TXT_NAME.Text=conn.GetFieldValue(0,3);
//			TXT_ADDRESS1.Text=conn.GetFieldValue(0,4);
//			TXT_ADDRESS2.Text=conn.GetFieldValue(0,5);
//			TXT_ADDRESS3.Text=conn.GetFieldValue(0,6);
//			TXT_CITY.Text=conn.GetFieldValue(0,7);
//			TXT_PHONENUM.Text=conn.GetFieldValue(0,8);
//			//TXT_BUSINESSTYPE.Text=conn.GetFieldValue(0,1);
//			//TXT_AP_TEAMLEADER.Text=conn.GetFieldValue(0,13);
//			TXT_AP_BUSINESSUNIT.Text=conn.GetFieldValue(0,11);
//			TXT_PROGRAMDESC.Text=conn.GetFieldValue(0,14);
//
//
			TXT_AP_REGNO.Text=conn.GetFieldValue("AP_REGNO");
			TXT_CU_REF.Text=conn.GetFieldValue("CU_REF");
			TXT_AP_SIGNDATE.Text=GlobalTools.FormatDate(conn.GetFieldValue("AP_SIGNDATE"));
			TXT_BRANCH_NAME.Text=conn.GetFieldValue("BRANCH_NAME");
			TXT_AP_RELMNGR.Text=conn.GetFieldValue("AP_RELMNGR");
			TXT_NAME.Text=conn.GetFieldValue("CU_NAME");
			TXT_ADDRESS1.Text=conn.GetFieldValue("CU_ADDR1");
			TXT_ADDRESS2.Text=conn.GetFieldValue("CU_ADDR2");
			TXT_ADDRESS3.Text=conn.GetFieldValue("CU_ADDR3");
			TXT_CITY.Text=conn.GetFieldValue("CITYNAME");
			TXT_PHONENUM.Text=conn.GetFieldValue("CU_PHN");
			TXT_BUSINESSTYPE.Text=conn.GetFieldValue("BUSINESSTYPE");
			TXT_AP_TEAMLEADER.Text=conn.GetFieldValue("AP_TEAMLEADER");
			TXT_AP_BUSINESSUNIT.Text=conn.GetFieldValue("AP_BUSINESSUNIT");
			TXT_PROGRAMDESC.Text=conn.GetFieldValue("PROGRAMDESC");


		}

		protected void BTN_BACK_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			Response.Redirect("/SME/" + DMS.CuBESCore.Logic.backLink(Request.QueryString["tc"].ToString(), conn));
		}


		private void view_Entry()
		{
//			conn.QueryString="select * from ca_neraca_middle where " +
//				" ap_regno='" + Request.QueryString["regno"] + "'";
//			conn.ExecuteQuery();
//			if (conn.GetRowCount()<=0)
//			{
//				GlobalTools.popMessage(this,"Data Neraca belum diisi");
//				return;
//			}
//			conn.QueryString="select * from ca_labarugi_middle where " +
//				" ap_regno='" + Request.QueryString["regno"] + "'";
//			conn.ExecuteQuery();
//			if (conn.GetRowCount()<=0)
//			{
//				GlobalTools.popMessage(this,"Data Rugi Laba diisi");
//				return;
//			}
			conn.QueryString="select * from scoring_infoumum where " +
				" ap_regno='" + Request.QueryString["regno"] + "'";
			conn.ExecuteQuery();
			if (conn.GetRowCount()<=0)
			{
				GlobalTools.popMessage(this,"Data Informasi Umum belum diisi");
				return;
			}
			Response.Redirect("ScoringView.aspx?tc=" + Request.QueryString["tc"] + 
				"&mc=" + Request.QueryString["mc"] + 
				"&regno=" + Request.QueryString["regno"]+ 
				"&curef=" + Request.QueryString["curef"] + 
				"&CekData=1" );
		}

		protected void BTN_VIEW_LIST_Click(object sender, System.EventArgs e)
		{
			view_Entry();
		}

		private void Button1_Click(object sender, System.EventArgs e)
		{
			view_Entry();
		}

		protected void BTN_SND_FAIRISAAC_Click(object sender, System.EventArgs e)
		{
			conn.QueryString="select * from scoring_infoumum where " +
				" ap_regno='" + Request.QueryString["regno"] + "'";
			conn.ExecuteQuery();
			if (conn.GetRowCount()<=0)
			{
				GlobalTools.popMessage(this,"Data Informasi Umum belum diisi");
				return;
			}

			//adjustImpactOnScoringInfoUmum();

			if (CreateTextFile()) 
				GlobalTools.popMessage(this,"Data terkirim ke Strategy Ware.Tekan Button Scoring Result untuk melihat hasil Scoring ");
			BTN_SCORING_RESULT.Enabled=true;
		}

		protected void BTN_SCORING_RESULT_Click(object sender, System.EventArgs e)
		{
			Response.Redirect("ScoringResult.aspx?tc=" + Request.QueryString["tc"] + 
				"&mc=" + Request.QueryString["mc"] + 
				"&regno=" + Request.QueryString["regno"]+ 
				"&curef=" + Request.QueryString["curef"]+ 
				"&CekData=1" );		
		}

        private string getNextStepMsg(string regno)
        {
            string pesan = "";
            string nextTrack = "";
            try
            {
                /***
                 * Memunculkan pesan next step
                 ***/
                conn.QueryString = "exec TRACKNEXTMSG '" + regno + "'";
                conn.ExecuteQuery();
                nextTrack = conn.GetFieldValue("TRACKNAME");
                pesan = "Application proceeds to " + nextTrack;
                /***********************************/
            }
            catch
            {
                throw new Exception();
            }
            return pesan;
        }

        protected void BTN_UPDATE_STATUS_Click(object sender, EventArgs e)
        {
            DataTable dt;
            conn.QueryString = "select apptype, productid, PROD_SEQ from custproduct where ap_regno='" + Request.QueryString["regno"] +
                "' AND isnull(cp_reject,'0') <> '1' and isnull(cp_cancel,'0') <> '1'";
            conn.ExecuteQuery();
            dt = conn.GetDataTable().Copy();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                conn.QueryString = "exec TRACKUPDATE '" + Request.QueryString["regno"] + "', '" +
                    dt.Rows[i][1].ToString() + "', '" + dt.Rows[i][0].ToString() + "', '" + Session["UserID"].ToString() + "', '" + dt.Rows[i]["PROD_SEQ"].ToString() + "','" + Request.QueryString["tc"].Trim() + "'";
                conn.ExecuteNonQuery();
            }

            string msg = getNextStepMsg(Request.QueryString["regno"]);
            Response.Redirect("ListScoring.aspx?tc=" + Request.QueryString["tc"] + "&mc=" + Request.QueryString["mc"] + "&msg=" + msg);		
        }
	}
}
