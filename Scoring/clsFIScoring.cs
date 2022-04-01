using System;
using System.Data;
using System.IO;
using DMS.DBConnection;
using DMS.CuBESCore;

namespace SME.Scoring
{
	/// <summary>
	/// Summary description for clsFIScoring.
	/// </summary>
	public class clsFIScoring
	{
		private Connection conn;
		private string regno;
		private string curef;

		public clsFIScoring(Connection cons, string reg_no, string cu_ref)
		{
			conn = cons;
			regno = reg_no;
			curef=cu_ref;

			//
			// TODO: Add constructor logic here
			//
		}



		private string CreateTextFilePreScoring()
		{
			//StreamWriter Sw;
			String tTxt,sql;

			tTxt="";

			//tTxt=tTxt+"START OF FILE--";

			////////////////////////////////////////////////////////////
			///	BAGIAN HEADER 
			///	

			//INP-SYSTEM-ID
			//tTxt=tTxt+"--INP-SYSTEM-ID--";
			tTxt=tTxt+="BM2";

			//INP-KEY-GRP-VAL
			//tTxt=tTxt+"--INP-KEY-GRP-VAL--";
			tTxt=tTxt + "9999";

			//INP-KEY-INQY-ID
			//tTxt=tTxt+"--INP-KEY-INQY-ID--";
			tTxt=tTxt + Pjg(regno,20);

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

			

			///////////////////////////////////////////////////////////////////////////
			///	Start Attributes Field
			///	

			sql="select *,datediff(m,mulai_usaha,getdate()) as Diff_Month_Mulai_Usaha,isnull(datediff(m,MULAI_MENETAP,getdate()),0) as Diff_Month_Mulai_Menetap from scoring_infoumum where ap_regno='" + regno + "'";
			conn.QueryString = sql;
			conn.ExecuteQuery();
			DataTable dt1 = conn.GetDataTable().Copy();

			
			//sql="select * from ca_neraca_small where sumberdata='prescoring' and  ap_regno='" + regno + "'";
			sql=" select top 1 * from ca_neraca_small   " +
				" where ap_regno = '"+ regno +"' and jml_bln = 12 and posisi_tgl <= getdate() " + 
				" order by posisi_tgl desc ";
			conn.QueryString = sql;
			conn.ExecuteQuery();
			DataTable dt2 = conn.GetDataTable().Copy();
			
			//sql="select * from ca_labarugi_small where SUMBERDATA='prescoring' and  ap_regno='" + regno + "'";
			sql=" select top 1 * from ca_labarugi_small " +   
				" where ap_regno = '" + regno + "' and jml_bln = 12 and posisi_tgl <= getdate() " +
				" order by posisi_tgl desc ";
			conn.QueryString = sql;
			conn.ExecuteQuery();
			DataTable dt3 = conn.GetDataTable().Copy();
			
			//sql="select * from CA_RATIO_SMALL where ap_regno = '" + regno + "' and sumberdata = 'PRESCORING'";
			sql=" select top 1 * from ca_ratio_small  " +
				" where ap_regno = '" + regno + "' and jml_bln = 12 and posisi_tgl <= getdate() " +
				" order by posisi_tgl desc ";
			conn.QueryString = sql;
			conn.ExecuteQuery();
			DataTable dt4 = conn.GetDataTable().Copy();

			sql="SELECT isnull(AP_BLBMPEMILIK,0) as AP_BLBMPEMILIK,isnull(AP_BLBMMGMT,0) as AP_BLBMMGMT, " +
				" isnull(AP_BLBMUSAHA,0) as AP_BLBMUSAHA,isnull(AP_BLBIPEMILIK,0) as AP_BLBIPEMILIK,isnull(AP_BLBIMGMT,0) as AP_BLBIMGMT, " +
				" isnull(AP_BLBIUSAHA,0) as AP_BLBIUSAHA FROM APPLICATION where ap_regno = '" + regno + "'";
			conn.QueryString = sql;
			conn.ExecuteQuery();
			DataTable dt5 = conn.GetDataTable().Copy();

			//###################################################################################ahmad

			/////////////////////////////////////////////////////////
			///	Total Application Value
			///	
			double x;
			int iThn,iBln;
			conn.QueryString = "DE_TOTALEXPOSURE '" + regno + "'";
			conn.ExecuteQuery(300);
			try {x = Convert.ToDouble(conn.GetFieldValue("tot_limit"));} 
			catch {x=0;}

			string TotExposure = Pjg(Convert.ToString(Math.Round(x/1000)),8);
		
			//###################################################################################ahmad

			
			//A0001 - Total Exposure
			//tTxt=tTxt+"--A0001--";
			//tTxt=tTxt+"00000000"; //ahmad
			//tTxt=tTxt+TotExposure; //ahmad

			if (TotExposure.Length > 8)
			{
				tTxt=tTxt + "99999999";
			}
			else
			{
				tTxt=tTxt+ TotExposure;
			}


			//A0002 - Type of Request
			//tTxt=tTxt+"--A0002--";
			tTxt=tTxt + Pjg( conn.GetFieldValue(dt1,0,"JENIS_PERMOHONAN"), 1);

			//A0003 - Requested Product
			//tTxt=tTxt+"--A0003--";
			tTxt=tTxt + Pjg( conn.GetFieldValue(dt1,0,"JENIS_KREDIT"), 2);

			//A0004 - Contractor requested
			//tTxt=tTxt+"--A0004--";
			tTxt=tTxt + Pjg(conn.GetFieldValue(dt1,0,"CONTRACTOR_TYPE"),1);

			//A0005 - Credit Scheme
			//tTxt=tTxt+"--A0005--";			
			tTxt=tTxt + Pjg(conn.GetFieldValue(dt1,0,"SKEMA_KREDIT"),2);

			//A0006 - Existing Product
			//tTxt=tTxt+"--A0006--";
			tTxt=tTxt + Pjg(conn.GetFieldValue(dt1,0,"PRODUCT_EXISTING"),2);

			//A0007 - Existing Exposure
			//tTxt=tTxt+"--A0007--";
			tTxt=tTxt + "00000000"; //ahmad
			//tTxt=tTxt + ExistingExposure; //ahmad

			//A0008 - Additional Collateral Flag
			//tTxt=tTxt+"--A0008--";
			tTxt=tTxt + Pjg( conn.GetFieldValue(dt1,0,"JAMINAN_TAMBAHAN"), 1);

			//tTxt=tTxt+"--Filler--";
			tTxt=tTxt + IsiBlank(175);			
			
			//A0201 - Number of Children of Main Owner
			//tTxt=tTxt+"--A0201--";
			if (conn.GetFieldValue(dt1,0,"JML_ANAK") == null || conn.GetFieldValue(dt1,0,"JML_ANAK") == "") 
			{tTxt=tTxt + "99";}
			else 
			{tTxt=tTxt + Pjg(conn.GetFieldValue(dt1,0,"JML_ANAK"),2);}

			//A0202 - Sex of Main Owner
			//tTxt=tTxt+"--A0202--";
			tTxt=tTxt + Pjg( conn.GetFieldValue(dt1,0,"JENIS_KELAMIN"), 1);

			//A0203 - Time at Residence of Main Owner (yymm)
			//tTxt=tTxt+"--A0203--";
			string strBulan;
			if (conn.GetFieldValue(dt1,0,"MULAI_MENETAP") == null || conn.GetFieldValue(dt1,0,"MULAI_MENETAP") == "" )
			{tTxt=tTxt+"9999";}
			else
			{
				iThn=Convert.ToInt32(conn.GetFieldValue(dt1,0,"Diff_Month_Mulai_Menetap")) /12;
				iBln=Convert.ToInt32(conn.GetFieldValue(dt1,0,"Diff_Month_Mulai_Menetap"))%12;
				tTxt=tTxt+Pjg(iThn.ToString() ,2);
				tTxt=tTxt+Pjg(iBln.ToString(),2);
			}

			//tTxt=tTxt + strBulan;
			//A0204 - Years as BM customer
			//tTxt=tTxt+"--A0204--";
			tTxt=tTxt + Pjg(conn.GetFieldValue(dt1,0,"LAMA_NASABAH_BM"),4);		// customer baru, maka 0000

			//A0205 - Age of Business (yymm)
			//tTxt=tTxt+"--A0205--";
			if (conn.GetFieldValue(dt1,0,"MULAI_USAHA") == null || conn.GetFieldValue(dt1,0,"MULAI_USAHA") == "" )
			{tTxt=tTxt+"9999";}
			else
			{
				iThn=Convert.ToInt32(conn.GetFieldValue(dt1,0,"Diff_Month_Mulai_Usaha"))/12;
				iBln=Convert.ToInt32(conn.GetFieldValue(dt1,0,"Diff_Month_Mulai_Usaha"))%12;
				tTxt=tTxt+Pjg(iThn.ToString(),2);
				tTxt=tTxt+Pjg(iBln.ToString(),2);
			}


			//A0206 - Sales (Millions)
			//tTxt=tTxt+"--A0206--";
			if (conn.GetFieldValue(dt1,0,"IU_PSRL_PENJUALANTAHUNAN_SATUAN") == null || 
				conn.GetFieldValue(dt1,0,"IU_PSRL_PENJUALANTAHUNAN_SATUAN") == "") 
			{tTxt=tTxt + "99999999";}
			else 
			{
				double vIU_PSRL_PENJUALANTAHUNAN_SATUAN= 0;
				int vIU_PSRL_PENJUALANTAHUNAN_SATUAN_int = 0;
				try { vIU_PSRL_PENJUALANTAHUNAN_SATUAN = Convert.ToDouble(conn.GetFieldValue(dt1,0,"IU_PSRL_PENJUALANTAHUNAN_SATUAN")); } 
				catch {}
				try { vIU_PSRL_PENJUALANTAHUNAN_SATUAN_int= Convert.ToInt32(Math.Round(vIU_PSRL_PENJUALANTAHUNAN_SATUAN, 0)); } 
				catch {}
				tTxt=tTxt + Pjg(vIU_PSRL_PENJUALANTAHUNAN_SATUAN_int.ToString(),8);
				//tTxt=tTxt + Pjg(Math.Round(Double.Parse(conn.GetFieldValue(dt1,0,"IU_PSRL_PENJUALANTAHUNAN_SATUAN"))).ToString(),8);
			}


			//A0207 - Total Liabilities (Millions)
			//tTxt=tTxt+"--A0207--";			
			if (conn.GetFieldValue(dt1,0,"IU_HUTANG_SATUAN") == null || 
				conn.GetFieldValue(dt1,0,"IU_HUTANG_SATUAN") == "") 
			{tTxt=tTxt + "99999999";}
			else
			{
				double vIU_HUTANG_SATUAN= 0;
				int vIU_HUTANG_SATUAN_int = 0;
				try { vIU_HUTANG_SATUAN = Convert.ToDouble(conn.GetFieldValue(dt1,0,"IU_HUTANG_SATUAN")); } 
				catch {}
				try { vIU_HUTANG_SATUAN_int= Convert.ToInt32(Math.Round(vIU_HUTANG_SATUAN, 0)); } 
				catch {}
				tTxt=tTxt + Pjg(vIU_HUTANG_SATUAN_int.ToString(),8);
				//tTxt=tTxt + Pjg(Math.Round(Double.Parse(conn.GetFieldValue(dt1,0,"IU_HUTANG_SATUAN"))).ToString(),8);
			}


			//A0208 - Cash 
			//tTxt=tTxt+"--A0208--";			
			//if (conn.GetFieldValue(dt2,0,"AKTV_KASBANK") == null || conn.GetFieldValue(dt2,0,"AKTV_KASBANK") == "") 
			if (conn.GetFieldValue(dt1,0,"IU_PSN_KASBANK") == null || 
				conn.GetFieldValue(dt1,0,"IU_PSN_KASBANK") == "") 
			{tTxt=tTxt + "99999999";}
			else {tTxt=tTxt + Pjg(Math.Round(Double.Parse(conn.GetFieldValue(dt1,0,"IU_PSN_KASBANK"))).ToString(),8);}


			//A0209 - Company Legal Type 
			//tTxt=tTxt+"--A0209--";
			tTxt=tTxt + Pjg( conn.GetFieldValue(dt1,0,"JNS_USAHA"), 1);


			//A0210 - Current Assets (Millions)
			//tTxt=tTxt+"--A0210--";			
			//if (conn.GetFieldValue(dt2,0,"AKTV_TTLAKTLCR") == null || conn.GetFieldValue(dt2,0,"AKTV_TTLAKTLCR") == "") 
			if (conn.GetFieldValue(dt1,0,"IU_PSN_TTLAKTIVALCR_SATUAN") == null || 
				conn.GetFieldValue(dt1,0,"IU_PSN_TTLAKTIVALCR_SATUAN") == "") 
			{tTxt=tTxt + "99999999";}
			else 
			{
				double vIU_PSN_TTLAKTIVALCR_SATUAN= 0;
				int vIU_PSN_TTLAKTIVALCR_SATUAN_int = 0;
				try { vIU_PSN_TTLAKTIVALCR_SATUAN = Convert.ToDouble(conn.GetFieldValue(dt1,0,"IU_PSN_TTLAKTIVALCR_SATUAN")); } 
				catch {}
				try { vIU_PSN_TTLAKTIVALCR_SATUAN_int= Convert.ToInt32(Math.Round(vIU_PSN_TTLAKTIVALCR_SATUAN, 0)); } 
				catch {}
				tTxt=tTxt + Pjg(vIU_PSN_TTLAKTIVALCR_SATUAN_int.ToString(),8);
				//tTxt=tTxt + Pjg(Math.Round(Double.Parse(conn.GetFieldValue(dt1,0,"IU_PSN_TTLAKTIVALCR_SATUAN"))).ToString(),8);
			}


			//A0211 - Net Worth 
			//tTxt=tTxt+"--A0211--";
			//if (conn.GetFieldValue(dt2,0,"PASV_TTLMODAL") == null || conn.GetFieldValue(dt2,0,"PASV_TTLMODAL") == "") 
			if (conn.GetFieldValue(dt1,0,"IU_TOTMODAL") == null || 
				conn.GetFieldValue(dt1,0,"IU_TOTMODAL") == "") 
			{tTxt=tTxt + "9999999";}
			else 
			{
				double vIU_TOTMODAL= 0;
				int vIU_TOTMODAL_int = 0;
				try { vIU_TOTMODAL = Convert.ToDouble(conn.GetFieldValue(dt1,0,"IU_TOTMODAL")); } 
				catch {}
				try { vIU_TOTMODAL_int= Convert.ToInt32(Math.Round(vIU_TOTMODAL, 0)); } 
				catch {}
				tTxt=tTxt + Pjg(CovToEBCDIC(vIU_TOTMODAL_int.ToString()),7);
				//tTxt=tTxt + Pjg(CovToEBCDIC(Math.Round(Double.Parse(conn.GetFieldValue(dt1,0,"IU_TOTMODAL"))).ToString()),7);
			}


			//A0212 - Sales / Working Capital %
			//tTxt=tTxt+"--A0212--";
			double AKTV_TTLAKTLCR = 0;
			double PASV_HTLNCR = 0;

			/* dont try to do this ... */
			try {AKTV_TTLAKTLCR = Double.Parse(conn.GetFieldValue(dt2,0, "AKTV_TTLAKTLCR"));}
			catch {}

			try { PASV_HTLNCR = Double.Parse(conn.GetFieldValue(dt2,0, "PASV_HTLNCR")); }
			catch {}

			if(dt3.Rows.Count == 0 || (conn.GetFieldValue(dt3,0,"IS_PENJ") == null || conn.GetFieldValue(dt3,0,"IS_PENJ") == "") ) 
			{tTxt=tTxt+ "9995";}
			else if(dt2.Rows.Count == 0 || conn.GetFieldValue(dt2,0,"AKTV_TTLAKTLCR") == null || conn.GetFieldValue(dt2,0,"AKTV_TTLAKTLCR") == "" || 
				conn.GetFieldValue(dt2,0,"PASV_HTLNCR") == null || conn.GetFieldValue(dt2,0,"PASV_HTLNCR") == "")
			{tTxt=tTxt+ "9996";}
			else if(dt2.Rows.Count == 0 || (conn.GetFieldValue(dt2,0,"AKTV_TTLAKTLCR") == null || conn.GetFieldValue(dt2,0,"AKTV_TTLAKTLCR") == "") && 
				(conn.GetFieldValue(dt2,0,"PASV_HTLNCR") == null || conn.GetFieldValue(dt2,0,"PASV_HTLNCR") == ""))
			{tTxt=tTxt+ "9997";}
			else if (AKTV_TTLAKTLCR - PASV_HTLNCR == 0)
			{tTxt=tTxt+ "9998";}
			else if (dt4.Rows.Count == 0 || conn.GetFieldValue(dt4,0,"SALES_TO_WK_CAPITAL") == null || conn.GetFieldValue(dt4,0,"SALES_TO_WK_CAPITAL") == "")
			{tTxt=tTxt+ "9999";}
			else
			{
				if (Convert.ToString(Math.Abs(Math.Round(Double.Parse(conn.GetFieldValue(dt4,0,"SALES_TO_WK_CAPITAL"))*100))).Length > 4)
				{
					tTxt=tTxt + Pjg(CovToEBCDIC("9994"),4);
				}
				else
				{
					double vSALES_TO_WK_CAPITAL= 0;
					int vSALES_TO_WK_CAPITAL_int = 0;
					try { vSALES_TO_WK_CAPITAL = Convert.ToDouble(conn.GetFieldValue(dt4,0,"SALES_TO_WK_CAPITAL")); } 
					catch {}
					vSALES_TO_WK_CAPITAL = vSALES_TO_WK_CAPITAL *100;
					try { vSALES_TO_WK_CAPITAL_int= Convert.ToInt32(Math.Round(vSALES_TO_WK_CAPITAL, 0)); } 
					catch {}
					tTxt=tTxt + Pjg(CovToEBCDIC(vSALES_TO_WK_CAPITAL_int.ToString()),4);
					//tTxt=tTxt + Pjg(CovToEBCDIC(Math.Round(Double.Parse(conn.GetFieldValue(dt4,0,"SALES_TO_WK_CAPITAL"))*100).ToString()),4);
				}
			}

			//A0213 - Debt / Net Worth %
			//tTxt=tTxt+"--A0213--";
			if(conn.GetFieldValue(dt1,0,"IU_HUTANG") == null || conn.GetFieldValue(dt1,0,"IU_HUTANG") == "" ) 
			{tTxt=tTxt+ "996";}
			else if(dt2.Rows.Count == 0 || conn.GetFieldValue(dt2,0,"PASV_TTLMODAL") == null || conn.GetFieldValue(dt2,0,"PASV_TTLMODAL") == "" ) 
			{tTxt=tTxt+ "997";}
			else if(dt2.Rows.Count == 0 || Double.Parse(conn.GetFieldValue(dt2,0,"PASV_TTLMODAL")) == 0) 
			{tTxt=tTxt+ "998";}
			else if(dt4.Rows.Count == 0 || conn.GetFieldValue(dt4,0,"DEBT_TO_NETWORTH") == null || conn.GetFieldValue(dt4,0,"DEBT_TO_NETWORTH") == "" ) 
			{tTxt=tTxt+ "997";}
			else 
			{
				if (Convert.ToString(Math.Abs(Math.Round(Double.Parse(conn.GetFieldValue(dt4,0,"DEBT_TO_NETWORTH"))*100))).Length > 3)
				{
					tTxt=tTxt + Pjg(CovToEBCDIC("995"),3);
				}
				else
				{
					double vDEBT_TO_NETWORTH= 0;
					int vDEBT_TO_NETWORTH_int = 0;
					try { vDEBT_TO_NETWORTH = Convert.ToDouble(conn.GetFieldValue(dt4,0,"DEBT_TO_NETWORTH")); } 
					catch {}
					vDEBT_TO_NETWORTH = vDEBT_TO_NETWORTH * 100;
					try { vDEBT_TO_NETWORTH_int= Convert.ToInt32(Math.Round(vDEBT_TO_NETWORTH, 0)); } 
					catch {}
					tTxt=tTxt + Pjg(CovToEBCDIC(vDEBT_TO_NETWORTH_int.ToString()),3);
					//tTxt=tTxt + Pjg(CovToEBCDIC(Math.Round(Double.Parse(conn.GetFieldValue(dt4,0,"DEBT_TO_NETWORTH"))*100).ToString()),3);
				}
			}

			//A0214 - Current Ratio %
			//tTxt=tTxt+"--A0214--";
			if(dt2.Rows.Count == 0 || conn.GetFieldValue(dt2,0,"AKTV_TTLAKTLCR") == null || conn.GetFieldValue(dt2,0,"AKTV_TTLAKTLCR") == "" ) 
			{tTxt=tTxt+ "996";}
			else if(dt2.Rows.Count == 0 || conn.GetFieldValue(dt2,0,"PASV_TTLHTLNCR") == null || conn.GetFieldValue(dt2,0,"PASV_TTLHTLNCR") == "" )
			{tTxt=tTxt+ "997";}
			else if(dt2.Rows.Count == 0 || Double.Parse(conn.GetFieldValue(dt2,0,"PASV_TTLHTLNCR")) == 0)
			{tTxt=tTxt+ "998";}
			else if(dt4.Rows.Count == 0 || conn.GetFieldValue(dt4,0,"CURRENT_RATIO") == null || conn.GetFieldValue(dt4,0,"CURRENT_RATIO") == "" )
			{tTxt=tTxt+ "999";}
			else 
			{
				if (Convert.ToString(Math.Round(Double.Parse(conn.GetFieldValue(dt4,0,"CURRENT_RATIO"))*100)).Length > 3)
				{
					tTxt=tTxt + "995";
				}
				else
				{
					double vCURRENT_RATIO= 0;
					int vCURRENT_RATIO_int = 0;
					try { vCURRENT_RATIO = Convert.ToDouble(conn.GetFieldValue(dt4,0,"CURRENT_RATIO")); } 
					catch {}
					vCURRENT_RATIO=vCURRENT_RATIO*100;
					try { vCURRENT_RATIO_int= Convert.ToInt32(Math.Round(vCURRENT_RATIO, 0)); } 
					catch {}
					tTxt=tTxt + Pjg(CovToEBCDIC(vCURRENT_RATIO_int.ToString()),3);
					//tTxt=tTxt + Pjg(Math.Round(Double.Parse(conn.GetFieldValue(dt4,0,"CURRENT_RATIO"))*100).ToString(),3);
				}
			}

			//A0215 - Business Debt Service Ratio %
			//tTxt=tTxt+"--A0215--";
			if(dt3.Rows.Count == 0 || conn.GetFieldValue(dt3,0,"IS_LABA_BRSH") == null || conn.GetFieldValue(dt3,0,"IS_LABA_BRSH") == "" ) 
			{tTxt=tTxt+ "996";}
			else if(dt2.Rows.Count == 0 || conn.GetFieldValue(dt2,0,"PASV_KIJTHTEMPO") == null || conn.GetFieldValue(dt2,0,"PASV_KIJTHTEMPO") == "" )
			{tTxt=tTxt+ "997";}
			else if(dt2.Rows.Count == 0 || Double.Parse(conn.GetFieldValue(dt2,0,"PASV_KIJTHTEMPO")) == 0)
			{tTxt=tTxt+ "998";}
			else if(dt4.Rows.Count == 0 || conn.GetFieldValue(dt4,0,"BUSINESS_DEBT_SERVICE_RATIO") == null || conn.GetFieldValue(dt4,0,"BUSINESS_DEBT_SERVICE_RATIO") == "" )
			{tTxt=tTxt+ "997";}
			else 
			{
				if (Convert.ToString(Math.Abs(Math.Round(Double.Parse(conn.GetFieldValue(dt4,0,"BUSINESS_DEBT_SERVICE_RATIO"))*100))).Length>3)
				{
					tTxt=tTxt + CovToEBCDIC("995");
				}
				else
				{
					double vBUSINESS_DEBT_SERVICE_RATIO= 0;
					int vBUSINESS_DEBT_SERVICE_RATIO_int = 0;
					try { vBUSINESS_DEBT_SERVICE_RATIO = Convert.ToDouble(conn.GetFieldValue(dt4,0,"BUSINESS_DEBT_SERVICE_RATIO")); } 
					catch {}
					vBUSINESS_DEBT_SERVICE_RATIO = vBUSINESS_DEBT_SERVICE_RATIO *100;
					try { vBUSINESS_DEBT_SERVICE_RATIO_int= Convert.ToInt32(Math.Round(vBUSINESS_DEBT_SERVICE_RATIO, 0)); } 
					catch {}
					tTxt=tTxt + Pjg(CovToEBCDIC(vBUSINESS_DEBT_SERVICE_RATIO_int.ToString()),3);
					//tTxt=tTxt + Pjg(CovToEBCDIC(Math.Round(Double.Parse(conn.GetFieldValue(dt4,0,"BUSINESS_DEBT_SERVICE_RATIO"))*100).ToString()),3);
				}
			}
			
			//tTxt=tTxt+"--Filler--";
			tTxt=tTxt + IsiBlank(32);

			//A0301 - Legal Lawsuit Flag
			//tTxt=tTxt+"--A0301--";
			tTxt=tTxt + Pjg( conn.GetFieldValue(dt1,0,"LEGAL_LAWSUIT"), 1);

			//A0302 - Existing Working Capital in other bank
			//tTxt=tTxt+"--A0302--";
			double vLIMIT_DIBANKLAIN= 0;
			int vLIMIT_DIBANKLAIN_int = 0;
			try { vLIMIT_DIBANKLAIN = Convert.ToDouble(conn.GetFieldValue(dt1,0,"LIMIT_DIBANKLAIN")); } 
			catch {}
			try { vLIMIT_DIBANKLAIN_int= Convert.ToInt32(Math.Round(vLIMIT_DIBANKLAIN, 0)); } 
			catch {}
			tTxt=tTxt + Pjg(vLIMIT_DIBANKLAIN_int.ToString(),8);
			//tTxt=tTxt + Pjg((conn.GetFieldValue(dt1,0,"LIMIT_DIBANKLAIN")),8);

			//tTxt=tTxt+"--Filler--";
			tTxt=tTxt + IsiBlank(91);
			
			//A0401 - Age of Primary Owner (yymm)
			//tTxt=tTxt+"--A0401--";
			tTxt=tTxt + Pjg(conn.GetFieldValue(dt1,0,"UMUR_OWNER"),4);

			//A0402 - Current PUKK facility from state flag
			//tTxt=tTxt+"--A0402--";
			tTxt=tTxt + Pjg( conn.GetFieldValue(dt1,0,"PUKK_CURR"), 1);

			//A0403 - Past PUKK facility from state flag
			//tTxt=tTxt+"--A0403--";
			tTxt=tTxt + Pjg( conn.GetFieldValue(dt1,0,"PUKK_PAST"), 1);

			//A0404 - Any business license flag
			//tTxt=tTxt+"--A0404--";
			tTxt=tTxt + Pjg( conn.GetFieldValue(dt1,0,"LISENSI_BISNIS"), 1);

			//A0405 - Share - main owner
			//tTxt=tTxt+"--A0405--";
			double vPROSEN_SAHAM= 0;
			int vPROSEN_SAHAM_int = 0;
			try { vPROSEN_SAHAM = Convert.ToDouble(conn.GetFieldValue(dt1,0,"PROSEN_SAHAM")); } 
			catch {}
			try { vPROSEN_SAHAM_int= Convert.ToInt32(Math.Round(vPROSEN_SAHAM, 0)); } 
			catch {}
			tTxt=tTxt + Pjg(vPROSEN_SAHAM_int.ToString(),3);
			//tTxt=tTxt + Pjg(conn.GetFieldValue(dt1,0,"PROSEN_SAHAM"),3);

			//tTxt=tTxt+"--Filler--";
			tTxt=tTxt + IsiBlank(190);
			
			//A0601 - Worst 12 Month BM Collectibility on previous/existing loan
			//tTxt=tTxt+"--A0601--";
			tTxt=tTxt + Pjg("0",2);

			//A0602 - Current Collectibility
			//tTxt=tTxt+"--A0602--";
			tTxt=tTxt + Pjg("0",2);

			//A0603 - Times Collectibility 2A last 12 Months
			//tTxt=tTxt+"--A0603--";
			tTxt=tTxt + "0";

			//A0604 - Times Collectibility 2B last 12 Months
			//tTxt=tTxt+"--A0604--";
			tTxt=tTxt + "0";

			//A0605 - Times Collectibility 2C last 12 Months
			//tTxt=tTxt+"--A0605--";
			tTxt=tTxt + "0";



			//A0606 - Business Currently in Black List at Bank Mandiri
			//tTxt=tTxt+"--A0606--";
			
			if ( conn.GetRowCount(dt5) > 0 ) tTxt=tTxt + Pjg(getYN(conn.GetFieldValue(dt5,0,"AP_BLBMUSAHA")),1);
			else {tTxt=tTxt + "N";}

			//A0607 - Past PUKK loan with BM flag
			//tTxt=tTxt+"--A0607--";
			tTxt=tTxt + "N";

			//A0608 - Watchlist flag
			//tTxt=tTxt+"--A0608--";
			tTxt=tTxt + "N";

			//A0609 - Times Collectibility 3+ last 12 mos
			//tTxt=tTxt+"--A0609--";
			tTxt=tTxt + "0";

			//tTxt=tTxt+"--Filler--";
			tTxt=tTxt + IsiBlank(89);

			//A0701 - Owner Currently in Black LIst at Bank Mandiri
			//tTxt=tTxt+"--A0701--";
			if ( conn.GetRowCount(dt5) > 0 ) tTxt=tTxt + Pjg(getYN(conn.GetFieldValue(dt5,0,"AP_BLBMPEMILIK")),1);
			else {tTxt=tTxt + "N";}
			//A0702 - Owner Currently Collectibility at Bank Mandiri
			//tTxt=tTxt+"--A0702--";
			tTxt=tTxt + "00";

			//A0703 - Owner Times Collectibility 2C+ Last 12 Month
			//tTxt=tTxt+"--A0703--";
			tTxt=tTxt + "0";

			//A0704 - Home Owned by Customer ?
			//tTxt=tTxt+"--A0704--";
			tTxt=tTxt + Pjg( conn.GetFieldValue(dt1,0, "IUM_HOMEOWNEDCUST"), 1);

			//tTxt=tTxt+"--Filler--";
			tTxt=tTxt + IsiBlank(95);
			
			//A0801 - Management Currently in Black LIst at Bank Mandiri
			//tTxt=tTxt+"--A0801--";
			if ( conn.GetRowCount(dt5) > 0 ) tTxt=tTxt + Pjg(getYN(conn.GetFieldValue(dt5,0,"AP_BLBMMGMT")),1);
			else {tTxt=tTxt + "N";}

			//A0802 - Management Currently Collectibility at Bank Mandiri
			//tTxt=tTxt+"--A0802--";
			tTxt=tTxt + "00";

			//A0803 - Management Times Collectibility 2C+ Last 12 Month
			//tTxt=tTxt+"--A0803--";
			tTxt=tTxt + "0";

			//tTxt=tTxt+"--Filler--";
			tTxt=tTxt + IsiBlank(96);

			//C0001 - Business Currently in Black List at Central Bank 
			//tTxt=tTxt+"--C0001--";
			if ( conn.GetRowCount(dt5) > 0 )tTxt=tTxt + Pjg(getYN(conn.GetFieldValue(dt5,0,"AP_BLBIUSAHA")),1);
			else {tTxt=tTxt + "N";}

			//C0002 - Business Central Bank Collectibility Level
			//tTxt=tTxt+"--C0002--";
			tTxt=tTxt + "0";

			//tTxt=tTxt+"--Filler--";
			tTxt=tTxt + IsiBlank(98);

			//C0100 - Owner Currently in Black List at Central Bank 
			//tTxt=tTxt+"--C0100--";
			if ( conn.GetRowCount(dt5) > 0 ) tTxt=tTxt + Pjg(getYN(conn.GetFieldValue(dt5,0,"AP_BLBIPEMILIK")),1);
			else {tTxt=tTxt + "N";}

			//C0101 - Owner Central Bank Collectibility Level
			//tTxt=tTxt+"--C0101--";
			tTxt=tTxt + "0";

			//tTxt=tTxt+"--Filler--";
			tTxt=tTxt + IsiBlank(98);

			//C0200 - Management Currently in Black List at Central Bank 
			//tTxt=tTxt+"--C0200--";
			if ( conn.GetRowCount(dt5) > 0 ) tTxt=tTxt + Pjg(getYN(conn.GetFieldValue(dt5,0,"AP_BLBIMGMT")),1);
			else {tTxt=tTxt + "N";}

			//C0201 - Management Central Bank Collectibility Level
			//tTxt=tTxt+"--C0201--";
			tTxt=tTxt + "0";

			//tTxt=tTxt+"--Filler--";
			tTxt=tTxt + IsiBlank(98);

			//A0901 - Assets : Total Assets 
			//tTxt=tTxt+"--A0901--";
			double vAKTV_TTLAKTV= 0;
			int vAKTV_TTLAKTV_int = 0;

			try { vAKTV_TTLAKTV = Convert.ToDouble(conn.GetFieldValue(dt2,0,"AKTV_TTLAKTV")); } 
			catch {}
			try { vAKTV_TTLAKTV_int= Convert.ToInt32(Math.Round(vAKTV_TTLAKTV, 0)); } 
			catch {}
			tTxt=tTxt + Pjg(vAKTV_TTLAKTV_int.ToString(),8);
			//tTxt=tTxt + Pjg((conn.GetFieldValue(dt2,0,"AKTV_TTLAKTV").ToString()),8);

			//A0902 - Fixed Assets : Land & Billing 
			//tTxt=tTxt+"--A0902--";
			double vAKTV_TNHBGN= 0;
			int vAKTV_TNHBGN_int = 0;
			try { vAKTV_TNHBGN = Convert.ToDouble(conn.GetFieldValue(dt2,0,"AKTV_TNHBGN")); } 
			catch {}
			try { vAKTV_TNHBGN_int= Convert.ToInt32(Math.Round(vAKTV_TNHBGN, 0)); } 
			catch {}
			tTxt=tTxt + Pjg(vAKTV_TNHBGN_int.ToString(),8);
			//tTxt=tTxt + Pjg((conn.GetFieldValue(dt2,0,"AKTV_TNHBGN").ToString()),8);

			//A0903 - % Sales Increase => For Prescoring => Hardcode to 100% increase
			//tTxt=tTxt+"--A0903--";
			tTxt=tTxt + Pjg(CovToEBCDIC("100"),3);	// untuk Micro saja, sehingga untuk small/middle default 0 (nol)			

			//A0904 - % Net Income Increase
			//tTxt=tTxt+"--A0904--";
			tTxt=tTxt + Pjg(CovToEBCDIC("100"),3);	// untuk Micro saja, sehingga untuk small/middle default 0 (nol)

			//A0905 - Cost of goods sold amt (Millions)
			//tTxt=tTxt+"--A0905--";
			double vIU_PSRL_HPP_SATUAN= 0;
			int vIU_PSRL_HPP_SATUAN_int = 0;
			try { vIU_PSRL_HPP_SATUAN = Convert.ToDouble(conn.GetFieldValue(dt1,0,"IU_PSRL_HPP_SATUAN")); } 
			catch {}
			try { vIU_PSRL_HPP_SATUAN_int= Convert.ToInt32(Math.Round(vIU_PSRL_HPP_SATUAN, 0)); } 
			catch {}
			tTxt=tTxt + Pjg(vIU_PSRL_HPP_SATUAN_int.ToString(),8);
			//tTxt=tTxt + Pjg((conn.GetFieldValue(dt1,0,"IU_PSRL_HPP_SATUAN").ToString()),8);	

			//A0906 - General Expense & Administration Ammount
			//tTxt=tTxt+"--A0906--";
			double vIU_PSRL_BIAYAUMUMADM= 0;
			int vIU_PSRL_BIAYAUMUMADM_int = 0;
			try { vIU_PSRL_BIAYAUMUMADM = Convert.ToDouble(conn.GetFieldValue(dt1,0,"IU_PSRL_BIAYAUMUMADM")); } 
			catch {}
			try { vIU_PSRL_BIAYAUMUMADM_int= Convert.ToInt32(Math.Round(vIU_PSRL_BIAYAUMUMADM, 0)); } 
			catch {}
			tTxt=tTxt + Pjg(vIU_PSRL_BIAYAUMUMADM_int.ToString(),8);
			//tTxt=tTxt + Pjg((conn.GetFieldValue(dt1,0,"IU_PSRL_BIAYAUMUMADM").ToString()),8);			

			//A0907 - TC : Trade Cycle Days
			//tTxt=tTxt+"--A0907--";
			if (Convert.ToString(Math.Abs(Math.Round(Double.Parse(conn.GetFieldValue(dt4,0,"TRADE_CYCLE"))))).Length > 3)
			{
				tTxt=tTxt + CovToEBCDIC("999");
			}
			else
			{
				double vTRADE_CYCLE= 0;
				int vTRADE_CYCLE_int = 0;
				try { vTRADE_CYCLE = Convert.ToDouble(conn.GetFieldValue(dt4,0,"TRADE_CYCLE")); } 
				catch {}
				vTRADE_CYCLE=vTRADE_CYCLE;
				try { vTRADE_CYCLE_int= Convert.ToInt32(Math.Round(vTRADE_CYCLE, 0)); } 
				catch {}
				tTxt=tTxt + Pjg(CovToEBCDIC(vTRADE_CYCLE_int.ToString()),3);
				//tTxt=tTxt + Pjg(CovToEBCDIC(Math.Round(Double.Parse(conn.GetFieldValue(dt4,0,"TRADE_CYCLE"))).ToString()),3);
			}
			//tTxt=tTxt + conn.GetFieldValue(,0,"");
			//A0908 - Purchasing Plan Amount
			//tTxt=tTxt+"--A0908--"; 
			double vPURCHASING_PLANT_AMOUNT_M = 0;
			int vPURCHASING_PLANT_AMOUNT_M_int = 0;
			try { vPURCHASING_PLANT_AMOUNT_M = Convert.ToDouble(conn.GetFieldValue(dt1,0,"PURCHASING_PLANT_AMOUNT_M")); } 
			catch {}
			try { vPURCHASING_PLANT_AMOUNT_M_int = Convert.ToInt32(Math.Round(vPURCHASING_PLANT_AMOUNT_M, 0)); } 
			catch {}
			tTxt=tTxt + Pjg(Convert.ToString(vPURCHASING_PLANT_AMOUNT_M_int),8);
			//tTxt=tTxt + Pjg(conn.GetFieldValue(dt1,0,"PURCHASING_PLANT_AMOUNT_M").ToString(),8);

			//tTxt=tTxt + conn.GetFieldValue(,0,"");
			//A0909 - Existing W/C limit in BM
			//tTxt=tTxt+"--A0909--";
			//			double vLIMIT_DIBANKLAIN = 0;  
			//			int vLIMIT_DIBANKLAIN_int = 0;
			//			try { vLIMIT_DIBANKLAIN = Convert.ToDouble(conn.GetFieldValue(dt1,0,"LIMIT_DIBANKLAIN")); } 
			//			catch {}
			//			try { vLIMIT_DIBANKLAIN_int = Convert.ToInt32(Math.Round(vLIMIT_DIBANKLAIN, 0)); } 
			//			catch {}
			//			tTxt=tTxt + Pjg(Convert.ToString(vLIMIT_DIBANKLAIN_int),8);
			tTxt=tTxt + Pjg("0",8);

			//tTxt=tTxt + conn.GetFieldValue(,0,"");
			//A0910 - Avg Net Profit
			//tTxt=tTxt+"--A0910--";
			double vIS_LABA_BRSH = 0;
			int vIS_LABA_BRSH_int = 0;
			try { vIS_LABA_BRSH = Convert.ToDouble(conn.GetFieldValue(dt3,0,"IS_LABA_BRSH")); } 
			catch {}
			vIS_LABA_BRSH = vIS_LABA_BRSH/12.0;
			try { vIS_LABA_BRSH_int = Convert.ToInt32(Math.Round(vIS_LABA_BRSH, 0)); } 
			catch {}
			tTxt=tTxt + Pjg(CovToEBCDIC(vIS_LABA_BRSH_int.ToString()),7);
			//tTxt=tTxt + Pjg(CovToEBCDIC(Math.Round(Convert.ToDouble(conn.GetFieldValue(dt1,0,"ML_AVGNET"))).ToString()),7);

			//tTxt=tTxt + conn.GetFieldValue(,0,"");
			//A0911 - Existing Facility Flag
			//tTxt=tTxt+"--A0911--";
			tTxt=tTxt + Pjg(conn.GetFieldValue(dt1,0,"ML_EXFAS"),1);

			//tTxt=tTxt + conn.GetFieldValue(,0,"");
			//A0912 - % Interest pa (x100)
			//tTxt=tTxt+"--A0912--";
			double vPRSN_INTEREST_PA = 0;
			try { vPRSN_INTEREST_PA = Double.Parse(conn.GetFieldValue(dt1,0,"PRSN_INTEREST_PA")); }
			catch {}
			vPRSN_INTEREST_PA = vPRSN_INTEREST_PA * 100;
			int vPRSN_INTEREST_PA_int = 0;
			try { vPRSN_INTEREST_PA_int = Convert.ToInt32(Math.Round(vPRSN_INTEREST_PA, 0)); } 
			catch {}
			tTxt=tTxt + Pjg(vPRSN_INTEREST_PA_int.ToString(),4);

			//tTxt=tTxt + conn.GetFieldValue(,0,"");
			//A0913 - Ters in months
			//tTxt=tTxt+"--A0913--";
			tTxt=tTxt + Pjg((conn.GetFieldValue(dt1,0,"TERMYN_MONTH").ToString()),2);

			//tTxt=tTxt + conn.GetFieldValue(,0,"");
			//A0914 - Acceptable Project Cost
			//tTxt=tTxt+"--A0914--";
			double vACCEPT_PROJ_COST = 0;
			int vACCEPT_PROJ_COST_int = 0;
			try { vACCEPT_PROJ_COST = Double.Parse(conn.GetFieldValue(dt1,0,"ACCEPT_PROJ_COST")); } 
			catch {}
			try { vACCEPT_PROJ_COST_int = Convert.ToInt32(Math.Round(vACCEPT_PROJ_COST, 0)); } 
			catch {}
			tTxt=tTxt + Pjg(vACCEPT_PROJ_COST_int.ToString(),8);
			//tTxt=tTxt + Pjg((conn.GetFieldValue(dt1,0,"ACCEPT_PROJ_COST").ToString()),8);

			//tTxt=tTxt + conn.GetFieldValue(,0,"");
			//A0915 - Contractor Plafond : Tot Value of Projects 
			//tTxt=tTxt+"--A0915--";
			double vPLAFOND_TOT_VAL_PROJECTS = 0;
			int vPLAFOND_TOT_VAL_PROJECTS_int = 0;
			try { vPLAFOND_TOT_VAL_PROJECTS = Double.Parse(conn.GetFieldValue(dt1,0,"PLAFOND_TOT_VAL_PROJECTS")); } 
			catch {}
			try { vPLAFOND_TOT_VAL_PROJECTS_int = Convert.ToInt32(Math.Round(vPLAFOND_TOT_VAL_PROJECTS, 0)); } 
			catch {}
			tTxt=tTxt + Pjg(vPLAFOND_TOT_VAL_PROJECTS_int.ToString(),8);
			//tTxt=tTxt + Pjg((Math.Round(Double.Parse(conn.GetFieldValue(dt1,0,"PLAFOND_TOT_VAL_PROJECTS"))).ToString()),8);

			//A0916 - Contractor Plafond : % project cost
			//tTxt=tTxt+"--A0916--";
			double vPLAFOND_PRSN_PROJ_COST = 0;
			int vPLAFOND_PRSN_PROJ_COST_int = 0;
			try { vPLAFOND_PRSN_PROJ_COST = Double.Parse(conn.GetFieldValue(dt1,0,"PLAFOND_PRSN_PROJ_COST")); } 
			catch {}
			try { vPLAFOND_PRSN_PROJ_COST_int = Convert.ToInt32(Math.Round(vPLAFOND_PRSN_PROJ_COST, 0)); } 
			catch {}
			tTxt=tTxt + Pjg(vPLAFOND_PRSN_PROJ_COST_int.ToString(),3);
			//tTxt=tTxt + Pjg((Math.Round(Double.Parse(conn.GetFieldValue(dt1,0,"PLAFOND_PRSN_PROJ_COST"))).ToString()),3);

			//tTxt=tTxt + conn.GetFieldValue(,0,"");
			//A0917 - Contractor Plafond " terma of payment (months)
			//tTxt=tTxt+"--A0917--";
			tTxt=tTxt + Pjg(conn.GetFieldValue(dt1,0,"PLAFOND_TOP").ToString(),2);

			//tTxt=tTxt + conn.GetFieldValue(,0,"");
			//A0918 - Contractor Plafond : downpayment amount
			//tTxt=tTxt+"--A0918--";
			double vPLAFOND_DP = 0;
			int vPLAFOND_DP_int = 0;
			try { vPLAFOND_DP = Convert.ToDouble(conn.GetFieldValue(dt1,0,"PLAFOND_DP")); } 
			catch {}
			try { vPLAFOND_DP_int = Convert.ToInt32(Math.Round(vPLAFOND_DP, 0)); } 
			catch {}
			tTxt=tTxt + Pjg(vPLAFOND_DP_int.ToString(),8);
			//tTxt=tTxt + Pjg(conn.GetFieldValue(dt1,0,"PLAFOND_DP").ToString(),8);

			

			//tTxt=tTxt + conn.GetFieldValue(,0,"");
			//A0919 - Existing WC plafond limit in BM
			//tTxt=tTxt+"--A0919--";
			/*
			double vCL_EXIST_WC_BM = 0;
			int vCL_EXIST_WC_BM_int = 0;
			try { vCL_EXIST_WC_BM = Convert.ToDouble(conn.GetFieldValue(dt1,0,"CL_EXIST_WC_BM")); } 
			catch {}
			try { vCL_EXIST_WC_BM_int = Convert.ToInt32(Math.Round(vCL_EXIST_WC_BM, 0)); } 
			catch {}
			*/
			int vCL_EXIST_WC_BM_int = 0;
			
			tTxt=tTxt + Pjg(vCL_EXIST_WC_BM_int.ToString(),8);
			//tTxt=tTxt + Pjg(Math.Round(Convert.ToDouble(conn.GetFieldValue(dt1,0,"CL_EXIST_WC_BM"))).ToString(),8);

			//tTxt=tTxt + conn.GetFieldValue(,0,"");
			//A0920 - Existing WC Plafond limit in other bank
			//tTxt=tTxt+"--A0920--";
			double vCL_EXIST_WC_OBANK = 0;
			int vCL_EXIST_WC_OBANK_int = 0;
			try { vCL_EXIST_WC_OBANK = Convert.ToDouble(conn.GetFieldValue(dt1,0,"CL_EXIST_WC_OBANK")); } 
			catch {}
			try { vCL_EXIST_WC_OBANK_int = Convert.ToInt32(Math.Round(vCL_EXIST_WC_OBANK, 0)); } 
			catch {}
			tTxt=tTxt + Pjg(vCL_EXIST_WC_OBANK_int.ToString(),8);
			//tTxt=tTxt + Pjg(Math.Round(Convert.ToDouble(conn.GetFieldValue(dt1,0,"CL_EXIST_WC_OBANK"))).ToString(),8);

			//tTxt=tTxt + conn.GetFieldValue(,0,"");
			//A0921 - Contrctor Termyn : Project Cost ( 1 Project)
			//tTxt=tTxt+"--A0921--";
			double vPROJ_COST = 0;
			int vPROJ_COST_int = 0;
			try { vPROJ_COST = Convert.ToDouble(conn.GetFieldValue(dt1,0,"PROJ_COST")); } 
			catch {}
			try { vPROJ_COST_int = Convert.ToInt32(Math.Round(vPROJ_COST, 0)); } 
			catch {}
			tTxt=tTxt + Pjg(vPROJ_COST_int.ToString(),8);
			//tTxt=tTxt + Pjg(conn.GetFieldValue(dt1,0,"PROJ_COST").ToString(),8);

			//tTxt=tTxt + conn.GetFieldValue(,0,"");
			//A0922 - Contractor Termyn : Number of Termyn 
			//tTxt=tTxt+"--A0922--";

			double vNUM_TERMYN = 0;
			int vNUM_TERMYN_int = 0;
			try { vNUM_TERMYN = Convert.ToDouble(conn.GetFieldValue(dt1,0,"NUM_TERMYN")); } 
			catch {}
			try { vNUM_TERMYN_int = Convert.ToInt32(Math.Round(vNUM_TERMYN, 0)); } 
			catch {}
			tTxt=tTxt + Pjg(vNUM_TERMYN_int.ToString(),2);
			//tTxt=tTxt + Pjg(conn.GetFieldValue(dt1,0,"NUM_TERMYN").ToString(),2);

			//tTxt=tTxt + conn.GetFieldValue(,0,"");
			//A0923 - SB Non Cash Value of Peoject Pa - General
			//tTxt=tTxt+"--A0923--";

			double vSB_NC_PROJ_PA_GENERAL = 0;
			int vSB_NC_PROJ_PA_GENERAL_int = 0;
			try { vSB_NC_PROJ_PA_GENERAL = Convert.ToDouble(conn.GetFieldValue(dt1,0,"SB_NC_PROJ_PA_GENERAL")); } 
			catch {}
			try { vSB_NC_PROJ_PA_GENERAL_int = Convert.ToInt32(Math.Round(vSB_NC_PROJ_PA_GENERAL, 0)); } 
			catch {}
			tTxt=tTxt + Pjg(vSB_NC_PROJ_PA_GENERAL_int.ToString(),8);
			//tTxt=tTxt + Pjg(conn.GetFieldValue(dt1,0,"SB_NC_PROJ_PA_GENERAL").ToString(),8);

			//tTxt=tTxt + conn.GetFieldValue(,0,"");
			//A0924 - SB Non Cash Value of Project pa - Purchase bbond
			//tTxt=tTxt+"--A0924--";
			double vNC_PROJ_PA_PURCHASE_BOND = 0;
			int vNC_PROJ_PA_PURCHASE_BOND_int = 0;
			try { vNC_PROJ_PA_PURCHASE_BOND = Convert.ToDouble(conn.GetFieldValue(dt1,0,"NC_PROJ_PA_PURCHASE_BOND")); } 
			catch {}
			try { vNC_PROJ_PA_PURCHASE_BOND_int = Convert.ToInt32(Math.Round(vNC_PROJ_PA_PURCHASE_BOND, 0)); } 
			catch {}
			tTxt=tTxt + Pjg(vNC_PROJ_PA_PURCHASE_BOND_int.ToString(),8);
			//tTxt=tTxt + Pjg(conn.GetFieldValue(dt1,0,"NC_PROJ_PA_PURCHASE_BOND").ToString(),8);

			//tTxt=tTxt + conn.GetFieldValue(,0,"");
			//A0925 - SB % Probability of Success bid bond
			//tTxt=tTxt+"--A0925--";
			double vPRSN_PROB_SUCCESS_BID_BOND = 0;
			int vPRSN_PROB_SUCCESS_BID_BOND_int = 0;
			try { vPRSN_PROB_SUCCESS_BID_BOND = Double.Parse(conn.GetFieldValue(dt1,0,"PRSN_PROB_SUCCESS_BID_BOND")); } 
			catch {}
			try { vPRSN_PROB_SUCCESS_BID_BOND_int= Convert.ToInt32(Math.Round(vPRSN_PROB_SUCCESS_BID_BOND, 0)); } 
			catch {}
			tTxt=tTxt + Pjg(vPRSN_PROB_SUCCESS_BID_BOND_int.ToString(),3);
			//tTxt=tTxt + Pjg(Math.Round(Double.Parse(conn.GetFieldValue(dt1,0,"PRSN_PROB_SUCCESS_BID_BOND"))).ToString(),3);

			//A0926 - % Bid Bond
			//tTxt=tTxt+"--A0926--";
			double vBID_BOND = 0;
			int vBID_BOND_int = 0;
			try { vBID_BOND = Double.Parse(conn.GetFieldValue(dt1,0,"BID_BOND")); } 
			catch {}
			try { vBID_BOND_int= Convert.ToInt32(Math.Round(vBID_BOND, 0)); } 
			catch {}
			tTxt=tTxt + Pjg(vBID_BOND_int.ToString(),3);
			//tTxt=tTxt + Pjg(Math.Round(Double.Parse(conn.GetFieldValue(dt1,0,"BID_BOND"))).ToString(),3);

			//A0927 - % Advance Bond
			//tTxt=tTxt+"--A0927--";
			double vADV_BOND = 0;
			int vADV_BOND_int = 0;
			try { vADV_BOND = Double.Parse(conn.GetFieldValue(dt1,0,"ADV_BOND")); } 
			catch {}
			try { vADV_BOND_int= Convert.ToInt32(Math.Round(vADV_BOND, 0)); } 
			catch {}
			tTxt=tTxt + Pjg(vADV_BOND_int.ToString(),3);
			//tTxt=tTxt + Pjg(Math.Round(Double.Parse(conn.GetFieldValue(dt1,0,"ADV_BOND"))).ToString(),3);

			//tTxt=tTxt + conn.GetFieldValue(,0,"");
			//A0928 - % Performance Bond
			//tTxt=tTxt+"--A0928--";
			double vPRFRMN_BOND = 0;
			int vPRFRMN_BOND_int = 0;
			try { vPRFRMN_BOND = Double.Parse(conn.GetFieldValue(dt1,0,"PRFRMN_BOND")); } 
			catch {}
			try { vPRFRMN_BOND_int= Convert.ToInt32(Math.Round(vPRFRMN_BOND, 0)); } 
			catch {}
			tTxt=tTxt + Pjg(vPRFRMN_BOND_int.ToString(),3);
			//tTxt=tTxt + Pjg(Math.Round(Double.Parse(conn.GetFieldValue(dt1,0,"PRFRMN_BOND"))).ToString(),3);

			//tTxt=tTxt + conn.GetFieldValue(,0,"");
			//A0929 - % Retention Bond
			//tTxt=tTxt+"--A0929--";
			double vPRSN_RET_BOND = 0;
			int vPRSN_RET_BOND_int = 0;
			try { vPRSN_RET_BOND = Convert.ToDouble(conn.GetFieldValue(dt1,0,"PRSN_RET_BOND")); } 
			catch {}
			try { vPRSN_RET_BOND_int= Convert.ToInt32(Math.Round(vPRSN_RET_BOND, 0)); } 
			catch {}
			tTxt=tTxt + Pjg(vPRSN_RET_BOND_int.ToString(),3);
			//tTxt=tTxt + Pjg(Math.Round(Double.Parse(conn.GetFieldValue(dt1,0,"PRSN_RET_BOND"))).ToString(),3);

			//tTxt=tTxt + conn.GetFieldValue(,0,"");
			//A0930 - % Purchase Bond
			//tTxt=tTxt+"--A0930--";
			double vPRSN_PURCHASE_BOND = 0;
			int vPRSN_PURCHASE_BOND_int = 0;
			try { vPRSN_PURCHASE_BOND = Convert.ToDouble(conn.GetFieldValue(dt1,0,"PRSN_PURCHASE_BOND")); } 
			catch {}
			try { vPRSN_PURCHASE_BOND_int= Convert.ToInt32(Math.Round(vPRSN_PURCHASE_BOND, 0)); } 
			catch {}
			tTxt=tTxt + Pjg(vPRSN_PURCHASE_BOND_int.ToString(),3);
			//tTxt=tTxt + Pjg(Math.Round(Double.Parse(conn.GetFieldValue(dt1,0,"PRSN_PURCHASE_BOND"))).ToString(),3);

			//vtTxt=tTxt + conn.GetFieldValue(,0,"");
			//A0931 - SB Avg Value L/C in a year
			//tTxt=tTxt+"--A0931--";
			double vSB_AVG_VALUELC_YEAR = 0;
			int vSB_AVG_VALUELC_YEAR_int = 0;
			try { vSB_AVG_VALUELC_YEAR = Convert.ToDouble(conn.GetFieldValue(dt1,0,"SB_AVG_VALUELC_YEAR")); } 
			catch {}
			try { vSB_AVG_VALUELC_YEAR_int= Convert.ToInt32(Math.Round(vSB_AVG_VALUELC_YEAR, 0)); } 
			catch {}
			tTxt=tTxt + Pjg(vSB_AVG_VALUELC_YEAR_int.ToString(),8);
			//tTxt=tTxt + Pjg(conn.GetFieldValue(dt1,0,"SB_AVG_VALUELC_YEAR").ToString(),8);

			//tTxt=tTxt + conn.GetFieldValue(,0,"");
			//A0932 - SB Avg term of L/C in a year (turnover in months)
			//tTxt=tTxt+"--A0932--";
			double vSB_AVG_TERMLC = 0;
			int vSB_AVG_TERMLC_int = 0;
			try { vSB_AVG_TERMLC = Convert.ToDouble(conn.GetFieldValue(dt1,0,"SB_AVG_TERMLC")); } 
			catch {}
			try { vSB_AVG_TERMLC_int= Convert.ToInt32(Math.Round(vSB_AVG_TERMLC, 0)); } 
			catch {}
			tTxt=tTxt + Pjg(vSB_AVG_TERMLC_int.ToString(),3);
			//tTxt=tTxt + Pjg(conn.GetFieldValue(dt1,0,"SB_AVG_TERMLC").ToString(),3);

			//tTxt=tTxt + conn.GetFieldValue(,0,"");
			//A0933 - MC Contractor Peak deficit cash flow
			//tTxt=tTxt+"--A0933--";
			double vMC_CONT_PEAK_DEFICIT_CF= 0;
			int vMC_CONT_PEAK_DEFICIT_CF_int = 0;
			try { vMC_CONT_PEAK_DEFICIT_CF = Convert.ToDouble(conn.GetFieldValue(dt1,0,"MC_CONT_PEAK_DEFICIT_CF")); } 
			catch {}
			try { vMC_CONT_PEAK_DEFICIT_CF_int= Convert.ToInt32(Math.Round(vMC_CONT_PEAK_DEFICIT_CF, 0)); } 
			catch {}
			tTxt=tTxt + Pjg(vMC_CONT_PEAK_DEFICIT_CF_int.ToString(),8);
			//tTxt=tTxt + Pjg(Math.Round(Convert.ToDouble(conn.GetFieldValue(dt1,0,"MC_CONT_PEAK_DEFICIT_CF"))).ToString(),8);

			//tTxt=tTxt + conn.GetFieldValue(,0,"");
			//A0934 - MC Non Cash Total Amount of Contract in Millions
			//tTxt=tTxt+"--A0934--";
			double vMC_NC_TOTAMOUNT= 0;
			int vMC_NC_TOTAMOUNT_int = 0;
			try { vMC_NC_TOTAMOUNT = Convert.ToDouble(conn.GetFieldValue(dt1,0,"MC_NC_TOTAMOUNT")); } 
			catch {}
			try { vMC_NC_TOTAMOUNT_int= Convert.ToInt32(Math.Round(vMC_NC_TOTAMOUNT, 0)); } 
			catch {}
			tTxt=tTxt + Pjg(vMC_NC_TOTAMOUNT_int.ToString(),8);
			//tTxt=tTxt + Pjg(Math.Round(Convert.ToDouble(conn.GetFieldValue(dt1,0,"MC_NC_TOTAMOUNT"))).ToString(),8);

			//tTxt=tTxt + conn.GetFieldValue(,0,"");
			//A0934 - Contractor Turnkey Project Cost
			//tTxt=tTxt+"--A0935--";
			double vCONTR_TURNKEY_PROJ_COST= 0;
			int vCONTR_TURNKEY_PROJ_COST_int = 0;
			try { vCONTR_TURNKEY_PROJ_COST = Convert.ToDouble(conn.GetFieldValue(dt1,0,"CONTR_TURNKEY_PROJ_COST")); } 
			catch {}
			try { vCONTR_TURNKEY_PROJ_COST_int= Convert.ToInt32(Math.Round(vCONTR_TURNKEY_PROJ_COST, 0)); } 
			catch {}
			tTxt=tTxt + Pjg(vCONTR_TURNKEY_PROJ_COST_int.ToString(),8);
			//tTxt=tTxt + Pjg(Math.Round(Convert.ToDouble(conn.GetFieldValue(dt1,0,"CONTR_TURNKEY_PROJ_COST"))).ToString(),8);

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

			// Start - Generate Text FIle 
			//			StreamWriter Sw;
			//			String strFileName;
			//			strFileName = @conn.GetFieldValue("FAIRISAAC_DIR");
			//			Sw = File.CreateText(strFileName);
			//			Sw.WriteLine(tTxt);
			//			Sw.Close();
			// End  - Generate Text FIle 

			
			// Start - Insert to Queue FIle 

			conn.QueryString="delete from SCORING_MESSAGE where ap_regno='" + regno + "'";
			conn.ExecuteNonQuery();

			conn.QueryString="insert into SCORING_MESSAGE values('" + regno + "','" + tTxt + "','PRESCORING','0')";
			conn.ExecuteNonQuery();

			// End - Insert to Queue File 
				
			return "1";

		}





		private string CreateTextFileFinalScoring()
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
			tTxt=tTxt + Pjg(regno,20);
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
			

			conn.QueryString="select * from vw_cek_smdm where ap_regno='" + regno + "'";
			conn.ExecuteQuery();
			if(conn.GetFieldValue("businessunit")=="SM100")
			{strSmall="1";}
			else
			{strSmall="0";}


			

			sql="select *,datediff(m,mulai_usaha,getdate()) as Diff_Month_Mulai_Usaha,isnull(datediff(m,MULAI_MENETAP,getdate()),0) as Diff_Month_Mulai_Menetap from scoring_infoumum where ap_regno='" + regno + "'";
			//sql="select * from scoring_infoumum where ap_regno='" + regno + "'";
			conn.QueryString = sql;
			conn.ExecuteQuery();
			DataTable dt1 = conn.GetDataTable().Copy();
			if (dt1.Rows.Count == 0) 
			{
				
				//GlobalTools.popMessage(this, "Data Informasi Umum belum lengkap!");
				//return false;
				return "Data Informasi Umum belum lengkap!";
				
			}

			

			/////////////////////////////////////////////////////
			///	NERACA
			///	
			//			sql = "select * from ca_neraca_small where ap_regno= '" + regno + "' " +
			//				" and is_proyeksi <> '1' and year(posisi_tgl) = (" +
			//				" select max(year(posisi_tgl)) from ca_neraca_small where ap_regno= '" + regno +"'" +
			//				" and is_proyeksi <> '1' )";

			sql = "exec SP_CA_NERACA '" + regno + "'";
			conn.QueryString = sql;
			conn.ExecuteQuery();
			DataTable dt2 = conn.GetDataTable().Copy();
			if (dt2.Rows.Count == 0) 
			{
				//GlobalTools.popMessage(this, "Data Neraca belum lengkap!");
				//return false;
				return "Data Neraca belum lengkap!";
			}



			///////////////////////////////////////////////////////
			///	LABA-RUGI
			///	
			//			sql = "select * from ca_labarugi_small where ap_regno= '" + regno + "'" +
			//					" and year(posisi_tgl) = (" +
			//					" select max(year(posisi_tgl)) from ca_labarugi_small where ap_regno = '" + regno + "'" +
			//					" and is_proyeksi <> '1')";

			sql = "exec SP_CA_LABARUGI '" + regno + "'";
			conn.QueryString = sql;
			conn.ExecuteQuery();
			DataTable dt3 = conn.GetDataTable().Copy();
			if (dt3.Rows.Count == 0) 
			{
				//GlobalTools.popMessage(this, "Data Laba-Rugi belum lengkap!");
				//return false;
				return "Data Laba-Rugi belum lengkap!";
			}
			double vIS_LABA_BRSH = 0;
			try { vIS_LABA_BRSH = Convert.ToDouble(conn.GetFieldValue(dt3, 0, "IS_LABA_BRSH")); } 
			catch {}
			
			//////////////////
			///TODO :
			///	
			
			if (strSmall=="1" )
			{
				sql="select SALES_TO_WK_CAPITAL,DEBT_TO_NETWORTH,CURRENT_RATIO,BUSINESS_DEBT_SERVICE_RATIO,TRADE_CYCLE,isnull(SALES_INCREASE,0) as SALES_INCREASE,isnull(NETINCOME_INCREASE,0) as NETINCOME_INCREASE,isnull(AVERAGE_NETPROFIT,0) as AVERAGE_NETPROFIT  from CA_ratio_SMALL where ap_regno = '" + regno + "' and JML_BLN = 12 " +
					" and (is_proyeksi is null or rtrim(ltrim(is_proyeksi)) = ''   OR RTRIM(LTRIM(IS_PROYEKSI)) = '0' ) " + 
					"and year(posisi_tgl) = (select max(year(posisi_tgl)) from CA_ratio_SMALL where " + 
					"ap_regno = '" + regno + "'" +
					" and (is_proyeksi is null or rtrim(ltrim(is_proyeksi)) = ''   OR RTRIM(LTRIM(IS_PROYEKSI)) = '0' )  )";
			}
			else
			{
				sql="select  top 1 SALES_TO_WK_CAPITAL,DEBT_TO_NETWORTH,CURRENT_RATIO," + 
					" BUSINESS_DEBT_SERV_RATIO as BUSINESS_DEBT_SERVICE_RATIO ,DAYS_TC as TRADE_CYCLE,isnull(SALES_INCREASE,0) as SALES_INCREASE,isnull(NETINCOME_INCREASE,0) as NETINCOME_INCREASE,isnull(AVERAGE_NETPROFIT,0) as AVERAGE_NETPROFIT   from CA_ratio_MIDDLE where ap_regno = '" + regno + "' and NUMBEROFMONTH = 12 " +
					" and (is_proyeksi is null or rtrim(ltrim(is_proyeksi)) = ''  OR RTRIM(LTRIM(IS_PROYEKSI)) = '0' ) " + 
					"and year(DATE_PERIODE) = (select max(year(DATE_PERIODE)) from CA_ratio_MIDDLE  where " + 
					"ap_regno = '" + regno + 
					"' and (is_proyeksi is null or rtrim(ltrim(is_proyeksi)) = ''  OR RTRIM(LTRIM(IS_PROYEKSI)) = '0' ))";
			}

			conn.QueryString = sql;
			conn.ExecuteQuery();
			DataTable dt4 = conn.GetDataTable().Copy();
			if (dt4.Rows.Count == 0) 
			{
				//GlobalTools.popMessage(this, "Data Ratio Keuangan belum lengkap!");
				//return false;
				return "Data Ratio Keuangan belum lengkap!";
			}




			//DT5 watchlist
			sql="select cu_inwatchlist = case when isnull(cu_inwatchlist,'0') = '0' then 'N' else 'Y' end " + 
				" from customer where cu_ref='" + curef + "'";
			conn.QueryString = sql;
			conn.ExecuteQuery();
			DataTable dt5 = conn.GetDataTable().Copy();



			//sql = "select datediff(m,Cast(MULAI_BM_MM as varchar)+'/01/'+ cast(MULAI_BM_YY as varchar),getdate()) as Diff_Month_Mulai_NasabahBM,* from scoring_hubbank  where ap_regno='" + regno + "'";

			/* Mask Out .... get direct from source as Yudi -----
			sql = "select * from scoring_hubbank  where ap_regno='" + regno + "'";
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
			*/
			//A0001 - Total Exposure
			double existingExposure;
			double appValue;

			conn.QueryString = "FAIRISAAC_EXISTINGEXPOSURE '" + curef + "'";
			conn.ExecuteQuery();

			if (conn.GetRowCount() > 0) 
			{
				existingExposure =  Convert.ToDouble(conn.GetFieldValue("existing_exposure"));	
				
			}
			else existingExposure = 0;

			conn.QueryString = "DE_TOTALEXPOSURE '" + regno + "'";
			conn.ExecuteQuery(300);
			if (conn.GetRowCount() > 0) 
			{
				appValue =  Convert.ToDouble(conn.GetFieldValue("tot_limit"));	
				
			}
			else appValue = 0;

			int SendValue = Convert.ToInt32(Math.Round((appValue + existingExposure)/1000.0));

			if (Convert.ToString(SendValue).Length > 8)
			{
				tTxt=tTxt + "99999999";
			}
			else
			{
				tTxt=tTxt+ Pjg(Convert.ToString(SendValue),8);
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
			//double appValue = Convert.ToDouble(conn.GetFieldValue(dt5, 0, "LMT_CREDIT_CURR_MILL"));
			//double totalExposure = Convert.ToDouble(conn.GetFieldValue(dt5, 0, "TTL_EXP_MILL"));
			//total exposure
			try { SendValue = Convert.ToInt32(Math.Round(existingExposure / 1000.0));  }
			catch {}

			tTxt=tTxt + Pjg(SendValue.ToString(),8);			

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
				double vIU_PSRL_PENJUALANTAHUNAN_SATUAN = 0;
				int vIU_PSRL_PENJUALANTAHUNAN_SATUAN_int = 0;
				try { vIU_PSRL_PENJUALANTAHUNAN_SATUAN = Convert.ToDouble(conn.GetFieldValue(dt1,0,"IU_PSRL_PENJUALANTAHUNAN_SATUAN"));  }
				catch {}
				try { vIU_PSRL_PENJUALANTAHUNAN_SATUAN_int = Convert.ToInt32(Math.Round(vIU_PSRL_PENJUALANTAHUNAN_SATUAN,0)); } 
				catch {}
				tTxt=tTxt + Pjg(vIU_PSRL_PENJUALANTAHUNAN_SATUAN_int.ToString(),8);
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
				double vIU_HUTANG_SATUAN = 0;
				int vIU_HUTANG_SATUAN_int = 0;
				try { vIU_HUTANG_SATUAN = Convert.ToDouble(conn.GetFieldValue(dt1,0,"IU_HUTANG_SATUAN")); } 
				catch {}
				try { vIU_HUTANG_SATUAN_int = Convert.ToInt32(Math.Round(vIU_HUTANG_SATUAN,0)); } 
				catch {}
				tTxt=tTxt + Pjg(vIU_HUTANG_SATUAN_int.ToString(),8);
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
				double vIU_PSN_KASBANK = 0;
				int vIU_PSN_KASBANK_int = 0;
				try { vIU_PSN_KASBANK = Convert.ToDouble(conn.GetFieldValue(dt1,0,"IU_PSN_KASBANK")); } 
				catch {}
				try { vIU_PSN_KASBANK_int = Convert.ToInt32(Math.Round(vIU_PSN_KASBANK,0)); } 
				catch {}
				tTxt=tTxt + Pjg(vIU_PSN_KASBANK_int.ToString(),8);
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
				double vIU_PSN_TTLAKTIVALCR_SATUAN = 0.0;
				int vIU_PSN_TTLAKTIVALCR_SATUAN_int = 0;
				try { vIU_PSN_TTLAKTIVALCR_SATUAN = Convert.ToDouble(conn.GetFieldValue(dt1,0,"IU_PSN_TTLAKTIVALCR_SATUAN")); } 
				catch {}
				try { vIU_PSN_TTLAKTIVALCR_SATUAN_int = Convert.ToInt32(Math.Round(vIU_PSN_TTLAKTIVALCR_SATUAN, 0)); } 
				catch {}
				tTxt=tTxt + Pjg(vIU_PSN_TTLAKTIVALCR_SATUAN_int.ToString(),8);
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
			else if(Convert.ToString(Math.Abs(Convert.ToInt32(Math.Round(Double.Parse(conn.GetFieldValue(dt1,0,"IU_TOTMODAL")))))).Length > 7)
			{
				tTxt=tTxt + CovToEBCDIC("9999998");
			}

			else
			{
				//tTxt=tTxt + Pjg(CovToEBCDIC(Math.Round(Double.Parse(conn.GetFieldValue(dt1,0,"IU_TOTMODAL_SATUAN"))).ToString()),7);
				double vIU_TOTMODAL = 0.0;
				int vIU_TOTMODAL_int = 0;
				try { vIU_TOTMODAL = Convert.ToDouble(conn.GetFieldValue(dt1,0,"IU_TOTMODAL")); } 
				catch {}
				try { vIU_TOTMODAL_int = Convert.ToInt32(Math.Round(vIU_TOTMODAL, 0)); } 
				catch {}
				tTxt=tTxt + Pjg(CovToEBCDIC(vIU_TOTMODAL_int.ToString()),7);
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
					double vSALES_TO_WK_CAPITAL = 0.0;
					int vSALES_TO_WK_CAPITAL_int = 0;
					try { vSALES_TO_WK_CAPITAL = Convert.ToDouble(conn.GetFieldValue(dt4,0,"SALES_TO_WK_CAPITAL")); } 
					catch {}
					vSALES_TO_WK_CAPITAL = vSALES_TO_WK_CAPITAL * 100;
					try { vSALES_TO_WK_CAPITAL_int = Convert.ToInt32(Math.Round(vSALES_TO_WK_CAPITAL, 0)); } 
					catch {}
					tTxt=tTxt + Pjg(CovToEBCDIC(vSALES_TO_WK_CAPITAL_int.ToString()),4);
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
					//tTxt=tTxt + Pjg(CovToEBCDIC(Math.Round(Double.Parse(conn.GetFieldValue(dt4,0,"DEBT_TO_NETWORTH"))*100).ToString()),3);
					double vDEBT_TO_NETWORTH = 0;
					int vDEBT_TO_NETWORTH_int = 0;
					try { vDEBT_TO_NETWORTH = Convert.ToDouble(conn.GetFieldValue(dt4,0,"DEBT_TO_NETWORTH")); } 
					catch {}
					vDEBT_TO_NETWORTH = vDEBT_TO_NETWORTH * 100;
					try { vDEBT_TO_NETWORTH_int = Convert.ToInt32(Math.Round(vDEBT_TO_NETWORTH, 0)); } 
					catch {}
					tTxt=tTxt + Pjg(CovToEBCDIC(vDEBT_TO_NETWORTH_int.ToString()),3);
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
					//tTxt=tTxt + Pjg(Math.Round(Double.Parse(conn.GetFieldValue(dt4,0,"CURRENT_RATIO"))*100).ToString(),3);
					double vCURRENT_RATIO = 0;
					double vCURRENT_RATIO_int = 0;
					try { vCURRENT_RATIO  =  Convert.ToDouble(conn.GetFieldValue(dt4,0,"CURRENT_RATIO")); } 
					catch {}
					vCURRENT_RATIO = vCURRENT_RATIO  * 100;
					try { vCURRENT_RATIO_int = Convert.ToInt32(Math.Round(vCURRENT_RATIO, 0)); } 
					catch {}
					tTxt=tTxt + Pjg(vCURRENT_RATIO_int.ToString(),3);
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
					//tTxt=tTxt + Pjg(CovToEBCDIC(Math.Round(Double.Parse(conn.GetFieldValue(dt4,0,"BUSINESS_DEBT_SERVICE_RATIO"))*100).ToString()),3);
					double vBUSINESS_DEBT_SERVICE_RATIO = 0;
					int vBUSINESS_DEBT_SERVICE_RATIO_int = 0;
					try { vBUSINESS_DEBT_SERVICE_RATIO = Convert.ToDouble(conn.GetFieldValue(dt4,0,"BUSINESS_DEBT_SERVICE_RATIO")); } 
					catch {}
					vBUSINESS_DEBT_SERVICE_RATIO = vBUSINESS_DEBT_SERVICE_RATIO * 100;
					try { vBUSINESS_DEBT_SERVICE_RATIO_int = Convert.ToInt32(Math.Round(vBUSINESS_DEBT_SERVICE_RATIO, 0)); } 
					catch {}
					tTxt=tTxt + Pjg(CovToEBCDIC(vBUSINESS_DEBT_SERVICE_RATIO_int.ToString()),3);
				}
			}
			
			//tTxt=tTxt+"--Filler--";
			tTxt=tTxt + IsiBlank(32);

			//A0301 - Legal Lawsuit Flag
			//tTxt=tTxt+"--A0301--";
			tTxt=tTxt + conn.GetFieldValue(dt1,0,"LEGAL_LAWSUIT");



			//A0302 - Existing Working Capital in other bank
			//tTxt=tTxt+"--A0302--";
			//tTxt=tTxt + Pjg(Math.Round(Double.Parse(conn.GetFieldValue(dt1,0,"LIMIT_DIBANKLAIN"))).ToString(),8);
			double vLIMIT_DIBANKLAIN = 0;
			int vLIMIT_DIBANKLAIN_int = 0;
			try { vLIMIT_DIBANKLAIN = Convert.ToDouble(conn.GetFieldValue(dt1,0,"LIMIT_DIBANKLAIN")); } 
			catch {}
			try { vLIMIT_DIBANKLAIN_int = Convert.ToInt32(Math.Round(vLIMIT_DIBANKLAIN, 0)); } 
			catch {}
			tTxt=tTxt + Pjg(vLIMIT_DIBANKLAIN_int.ToString(),8);



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
			
			

			//applicant 2a,2b,2c,3+			
			string worst_col_12b;  // worst 12 month  A601
			string col_bm_curr;   //  current kolekblitas A602
			string app_col_2a;    //  2a
			string app_col_2b; 
			string app_col_2c;
			string bm_bl_usaha;   // a606
			string app_col_3;     // a609
			
			// pemilik			
			string bm_bl_pemilik;   //a701
			string collbm_curr_pemilik;   // a702			
			string coll_2c_12_pemilik;    // a703
			

			// key person - previously management
			string bm_key_person;  // a801
			string col_bm_mgt;   //a802
			string col_bm_2c;    // a803

			string bi_usaha;       // c001
			string kol_bi_usaha;		//C002
			string bi_bl_pemilik;  // c100
			string kol_bi_pemilik;  // c101

			string bi_key_person;  // c200
			string kol_bi_key;    // c201

			
			conn.QueryString = "select AP_BLBIACCBK, AP_BLBIOCBK, AP_BLBIMCBKS " + 
				"from APPLICATION where AP_REGNO = '" + regno + "'";
			conn.ExecuteQuery();
			

			//Kolektibilitas pemilik saat ini di bank lain (IDI BI) - C101
			try { kol_bi_pemilik = conn.GetFieldValue("AP_BLBIOCBK"); } 
			catch {kol_bi_pemilik  = "0";  }

			
			//C200  Kolektibilitas perusahaan saat ini di bank lain (IDI BI)			
			try { kol_bi_usaha = conn.GetFieldValue("AP_BLBIACCBK"); } 
			catch {kol_bi_usaha = "0"; }

			
			
			//C0100			
			try { kol_bi_key = conn.GetFieldValue("AP_BLBIMCBKS"); } 
			catch { kol_bi_key = "0"; }


			conn.QueryString="select * from VW_BLACKLIST_FI WHERE AP_REGNO = '" + regno + "'";
			conn.ExecuteQuery();
			if (conn.GetRowCount() > 0) 
			{
				
				
				bm_bl_usaha =conn.GetFieldValue("AP_BLBMUSAHA");
				bm_bl_pemilik =conn.GetFieldValue("AP_BLBMPEMILIK");				
				bm_key_person =conn.GetFieldValue("AP_BLBMMGMT");

				bi_usaha =conn.GetFieldValue("AP_BLBIUSAHA");				
				bi_bl_pemilik =conn.GetFieldValue("AP_BLBIPEMILIK");			
				bi_key_person =conn.GetFieldValue("AP_BLBIMGMT");
			}
			else 
			{
				bm_bl_usaha = "N";
				bm_bl_pemilik = "N";				
				bm_key_person = "N";

				bi_usaha = "N";
				bi_bl_pemilik = "N";			
				bi_key_person = "N";
			}	 
			
			
			conn.QueryString = "select * from VW_COLLECTIBILITY where cu_ref='"+ curef +"'";
			conn.ExecuteQuery();			
			
			try { worst_col_12b = conn.GetFieldValue("COLLBM_WORST_12B");} 
			catch 
			{
				worst_col_12b = "0";
			}			

			
			try { col_bm_curr = conn.GetFieldValue("COLLBM_CURR_CUST"); } 
			catch 
			{
				col_bm_curr = "00";
			}

			

			try {app_col_2a = conn.GetFieldValue("NUM_COLL_2A");}
			catch
			{
				app_col_2a ="0";
			}
			
			try {app_col_2b = conn.GetFieldValue("NUM_COLL_2B");}
			catch
			{
				app_col_2b ="0";
			}
			
			try {app_col_2c = conn.GetFieldValue("NUM_COLL_2C");}
			catch
			{
				app_col_2c ="0";
			}
			
			try {app_col_3 = conn.GetFieldValue("NUM_COLL_3PLUS");}
			catch
			{
				app_col_3 ="0";
			}
			

			

			//Main Owner
			//try {DDL_KEY_BM_COLL.SelectedValue = conn.GetFieldValue("COLL_CURR_KP");}		
			

			try { collbm_curr_pemilik = conn.GetFieldValue("COLLBM_CURR_KP");}
			catch 
			{
				collbm_curr_pemilik = "00";
			}

			coll_2c_12_pemilik = conn.GetFieldValue("COLL_2C_12_KP");
			//management
			//try {DDL_MGM_BM_COLL_CURR.SelectedValue = conn.GetFieldValue("COLL_CURR_MGM");}
			
			try { col_bm_mgt = conn.GetFieldValue("COLLBM_CURR_MGMG");}				
			catch 
			{
				col_bm_mgt = "00";
			}

			col_bm_2c  = conn.GetFieldValue("COLL_2C_12_MGM");
			
			//601
			tTxt=tTxt + Pjg(worst_col_12b,2);

			//string col_bm_curr;
			//A0602 - Current Collectibility
			//tTxt=tTxt+"--A0602--";
			tTxt=tTxt + Pjg(col_bm_curr,2);
		
			

			//A0603 - Times Collectibility 2A last 12 Months
			//tTxt=tTxt+"--A0603--";
			tTxt=tTxt + Pjg(app_col_2a,1);

			//A0604 - Times Collectibility 2B last 12 Months
			//tTxt=tTxt+"--A0604--";
			tTxt=tTxt + Pjg(app_col_2b,1);
	            
			//A0605 - Times Collectibility 2C last 12 Months
			//tTxt=tTxt+"--A0605--";
			tTxt=tTxt + Pjg(app_col_2c,1);

			//A0606 - Business Currently in Black List at Bank Mandiri
			//tTxt=tTxt+"--A0606--";
			tTxt=tTxt + Pjg(bm_bl_usaha ,1);

			//A0607 - Past PUKK loan with BM flag
			//tTxt=tTxt+"--A0607--";
			tTxt=tTxt + Pjg(conn.GetFieldValue(dt1,0,"PUKK_PAST_BM").ToString(),1);			

			//A0608 - Watchlist flag
			//tTxt=tTxt+"--A0608--";
			//tTxt=tTxt + Pjg(conn.GetFieldValue(dt5,0,"WATCH_LIST").ToString(),1);
			string myWatchList = conn.GetFieldValue(dt5,0,"CU_INWATCHLIST");
			tTxt=tTxt + myWatchList;
							
			//A0609 - Times Collectibility 3+ last 12 month
			//tTxt=tTxt+"--A0609--";
			tTxt=tTxt + Pjg(app_col_3,1);

			//tTxt=tTxt+"--Filler--";
			tTxt=tTxt + IsiBlank(89);


			
			
			//A0701 - Owner Currently in Black LIst at Bank Mandiri
			//tTxt=tTxt+"--A0701--";
			tTxt=tTxt + Pjg(bm_bl_pemilik,1);

			//A0702 - Owner Currently Collectibility at Bank Mandiri
			//tTxt=tTxt+"--A0702--";
			tTxt=tTxt + Pjg(collbm_curr_pemilik,2);

			//A0703 - Owner Times Collectibility 2C+ Last 12 Month
			//tTxt=tTxt+"--A0703--";
			tTxt=tTxt + Pjg(coll_2c_12_pemilik,1);

			//A0704 - Home Owned by Customer ?
			//tTxt=tTxt+"--A0704--";
			tTxt=tTxt + Pjg(conn.GetFieldValue(dt1,0, "IUM_HOMEOWNEDCUST"),1);

			//tTxt=tTxt+"--Filler--";
			tTxt=tTxt + IsiBlank(95);
				
			
			

			//A0801 - Management Currently in Black LIst at Bank Mandiri
			//tTxt=tTxt+"--A0801--";
			tTxt=tTxt + Pjg(bm_key_person,1);

			//A0802 - Management Currently Collectibility at Bank Mandiri
			//tTxt=tTxt+"--A0802--";
			//string col_bm_mgt;
			tTxt=tTxt + Pjg(col_bm_mgt,2);

			//A0803 - Management Times Collectibility 2C+ Last 12 Month
			//tTxt=tTxt+"--A0803--";
			tTxt=tTxt + Pjg(col_bm_2c,1);

			//tTxt=tTxt+"--Filler--";
			tTxt=tTxt + IsiBlank(96);			
			
			
			
			
			//C0001 - Business Currently in Black List at Central Bank 
			//tTxt=tTxt+"--C0001--";
			tTxt=tTxt + Pjg(bi_usaha,1);

			
			
			//C0002 - Business Central Bank Collectibility Level
			//tTxt=tTxt+"--C0002--";
			tTxt=tTxt + Pjg(kol_bi_usaha,1);  // ??? - salah

			//tTxt=tTxt+"--Filler--";
			tTxt=tTxt + IsiBlank(98);		
			
			
			//C0100 - Owner Currently in Black List at Central Bank 
			//tTxt=tTxt+"--C0100--";
			tTxt=tTxt + Pjg(bi_bl_pemilik,1);		


			//C0101 - Owner Central Bank Collectibility Level
			//tTxt=tTxt+"--C0101--";
			tTxt=tTxt + Pjg(kol_bi_pemilik,1);

			//tTxt=tTxt+"--Filler--";
			tTxt=tTxt + IsiBlank(98);

			//C0200 - Management Currently in Black List at Central Bank 
			//tTxt=tTxt+"--C0200--";
			tTxt=tTxt + Pjg(bi_key_person,1);

			//C0201 - Management Central Bank Collectibility Level
			//tTxt=tTxt+"--C0201--";
			tTxt=tTxt + Pjg(kol_bi_key,1);

			//tTxt=tTxt+"--Filler--";
			tTxt=tTxt + IsiBlank(98);



			//A0901 - Assets : Total Assets 
			//tTxt=tTxt+"--A0901--";
			//tTxt=tTxt + Pjg(Math.Round(Double.Parse(conn.GetFieldValue(dt2,0,"AKTV_TTLAKTV"))).ToString(),8);
			double vAKTV_TTLAKTV = 0.0;
			int vAKTV_TTLAKTV_int = 0;
			try { vAKTV_TTLAKTV = Convert.ToDouble(conn.GetFieldValue(dt2,0,"AKTV_TTLAKTV")); } 
			catch {}
			try { vAKTV_TTLAKTV_int = Convert.ToInt32(Math.Round(vAKTV_TTLAKTV, 0)); } 
			catch {}
			tTxt=tTxt + Pjg(vAKTV_TTLAKTV_int.ToString(),8);



			//A0902 - Fixed Assets : Land & Billing 
			//tTxt=tTxt+"--A0902--";
			//tTxt=tTxt + Pjg(Math.Round(Double.Parse(conn.GetFieldValue(dt2,0,"AKTV_TNHBGN"))).ToString(),8);
			double vAKTV_TNHBGN = 0.0;
			int vAKTV_TNHBGN_int = 0;
			try { vAKTV_TNHBGN = Convert.ToDouble(conn.GetFieldValue(dt2,0,"AKTV_TNHBGN")); } 
			catch {}
			try { vAKTV_TNHBGN_int = Convert.ToInt32(Math.Round(vAKTV_TNHBGN, 0)); } 
			catch {}
			tTxt=tTxt + Pjg(vAKTV_TNHBGN_int.ToString(),8);



			//A0903 - % Sales Increase
			//tTxt=tTxt+"--A0903--";
			//Plus
			//A0904 - % Net Income Increase
			//tTxt=tTxt+"--A0904--";
			// check also for middle 

			// for middle only !!!!
			// check small run this code for if 

			
			if (Convert.ToString(Math.Abs(Math.Round(Double.Parse(conn.GetFieldValue(dt4,0,"SALES_INCREASE"))*100))).Length > 3)
			{
				tTxt=tTxt + CovToEBCDIC("999");
			}
			else
			{
				//tTxt=tTxt + Pjg(CovToEBCDIC(Math.Round(Double.Parse(conn.GetFieldValue(dt4,0,"SALES_INCREASE"))*100).ToString()),3);
				double vSALES_INCREASE = 0.0;
				int vSALES_INCREASE_int = 0;
				try { vSALES_INCREASE = Convert.ToDouble(conn.GetFieldValue(dt4,0,"SALES_INCREASE")); } 
				catch {}
				vSALES_INCREASE = vSALES_INCREASE * 100;
				try { vSALES_INCREASE_int = Convert.ToInt32(Math.Round(vSALES_INCREASE, 0)); } 
				catch {}
				tTxt=tTxt + Pjg(CovToEBCDIC(vSALES_INCREASE_int.ToString()),3);
			}



			if (Convert.ToString(Math.Abs(Math.Round(Double.Parse(conn.GetFieldValue(dt4,0,"NETINCOME_INCREASE"))*100))).Length > 3)
			{
				tTxt=tTxt + CovToEBCDIC("999");
			}
			else
			{
				//tTxt=tTxt + Pjg(CovToEBCDIC(Math.Round(Double.Parse(conn.GetFieldValue(dt4,0,"NETINCOME_INCREASE"))*100).ToString()),3);
				double vNETINCOME_INCREASE = 0.0;
				int vNETINCOME_INCREASE_int = 0;
				try { vNETINCOME_INCREASE = Convert.ToDouble(conn.GetFieldValue(dt4,0,"NETINCOME_INCREASE")); } 
				catch {}
				vNETINCOME_INCREASE = vNETINCOME_INCREASE * 100;
				try { vNETINCOME_INCREASE_int = Convert.ToInt32(Math.Round(vNETINCOME_INCREASE, 0)); } 
				catch {}
				tTxt=tTxt + Pjg(CovToEBCDIC(vNETINCOME_INCREASE_int.ToString()),3);
			}



			//A0905 - Cost of goods sold amt (Millions)
			//tTxt=tTxt+"--A0905--";
			//tTxt=tTxt + Pjg(Math.Round(Double.Parse(conn.GetFieldValue(dt1,0,"IU_PSRL_HPP_SATUAN"))).ToString(),8);
			double vIU_PSRL_HPP_SATUAN = 0;
			int vIU_PSRL_HPP_SATUAN_int = 0;
			try { vIU_PSRL_HPP_SATUAN = Convert.ToDouble(conn.GetFieldValue(dt1,0,"IU_PSRL_HPP_SATUAN")); } 
			catch {}
			try { vIU_PSRL_HPP_SATUAN_int = Convert.ToInt32(Math.Round(vIU_PSRL_HPP_SATUAN, 0)); } 
			catch {}
			tTxt=tTxt + Pjg(vIU_PSRL_HPP_SATUAN_int.ToString(),8);



			//A0906 - General Expense & Administration Ammount
			//tTxt=tTxt+"--A0906--";
			//tTxt=tTxt + Pjg(Math.Round(Double.Parse(conn.GetFieldValue(dt1,0,"IU_PSRL_BIAYAUMUMADM"))).ToString(),8);
			double vIU_PSRL_BIAYAUMUMADM = 0.0;
			int vIU_PSRL_BIAYAUMUMADM_int = 0;
			try { vIU_PSRL_BIAYAUMUMADM = Convert.ToDouble(conn.GetFieldValue(dt1,0,"IU_PSRL_BIAYAUMUMADM")); } 
			catch {}
			try { vIU_PSRL_BIAYAUMUMADM_int = Convert.ToInt32(Math.Round(vIU_PSRL_BIAYAUMUMADM, 0)); } 
			catch {}
			tTxt=tTxt + Pjg(vIU_PSRL_BIAYAUMUMADM_int.ToString(),8);



			//A0907 - TC : Trade Cycle Days
			//tTxt=tTxt+"--A0907--";
			//tTxt=tTxt + Pjg(CovToEBCDIC(Math.Round(Double.Parse(conn.GetFieldValue(dt4,0,"TRADE_CYCLE"))).ToString()),3);
			if (Convert.ToString(Math.Abs(Math.Round(Double.Parse(conn.GetFieldValue(dt4,0,"TRADE_CYCLE"))))).Length > 3)
			{
				tTxt=tTxt + CovToEBCDIC("999");
			}
			else
			{
				//tTxt=tTxt + Pjg(CovToEBCDIC(Math.Round(Double.Parse(conn.GetFieldValue(dt4,0,"TRADE_CYCLE"))).ToString()),3);
				double vTRADE_CYCLE = 0;
				int vTRADE_CYCLE_int = 0;
				try { vTRADE_CYCLE = Convert.ToDouble(conn.GetFieldValue(dt4,0,"TRADE_CYCLE")); } 
				catch {}
				try { vTRADE_CYCLE_int = Convert.ToInt32(Math.Round(vTRADE_CYCLE, 0)); } 
				catch {}
				tTxt=tTxt + Pjg(CovToEBCDIC(vTRADE_CYCLE_int.ToString()),3);
			}



			//tTxt=tTxt + conn.GetFieldValue(dt2,0,"");
			//A0908 - Purchasing Plan Amount
			//tTxt=tTxt+"--A0908--"; 
			//tTxt=tTxt + Pjg(Math.Round(Double.Parse(conn.GetFieldValue(dt1,0,"PURCHASING_PLANT_AMOUNT_M"))).ToString(),8);
			double vPURCHASING_PLANT_AMOUNT_M = 0;
			int vPURCHASING_PLANT_AMOUNT_M_int = 0;
			try { vPURCHASING_PLANT_AMOUNT_M = Convert.ToDouble(conn.GetFieldValue(dt1,0,"PURCHASING_PLANT_AMOUNT_M")); } 
			catch {}
			try { vPURCHASING_PLANT_AMOUNT_M_int = Convert.ToInt32(Math.Round(vPURCHASING_PLANT_AMOUNT_M, 0)); } 
			catch {}
			tTxt=tTxt + Pjg(vPURCHASING_PLANT_AMOUNT_M_int.ToString(),8);




			//tTxt=tTxt + conn.GetFieldValue(dt2,0,"");
			//A0909 - Existing W/C limit in BM
			//tTxt=tTxt+"--A0909--";
			conn.QueryString = "exec FAIRISAAC_EXISTINGEXPOSURE_KMKONLY '" + curef + "'";
			conn.ExecuteQuery();
			double vKMK_LMT_BM_CURR = 0;
			int vKMK_LMT_BM_CURR_int = 0;
			try { vKMK_LMT_BM_CURR = Convert.ToDouble(conn.GetFieldValue("EXISTINGEXPOSURE_KMK")); } 
			catch {}
			vKMK_LMT_BM_CURR = vKMK_LMT_BM_CURR / 1000;
			try { vKMK_LMT_BM_CURR_int = Convert.ToInt32(Math.Round(vKMK_LMT_BM_CURR, 0)); } 
			catch {}			
			tTxt=tTxt + Pjg(vKMK_LMT_BM_CURR_int.ToString(),8);



			//tTxt=tTxt + conn.GetFieldValue(dt2,0,"");
			//A0910 - Avg Net Profit
			//tTxt=tTxt+"--A0910--";			
			//tTxt=tTxt + Pjg(CovToEBCDIC(Math.Round(Double.Parse(conn.GetFieldValue(dt1, 0, "ML_AVGNET"))).ToString()),7);
			double vIS_LABA_BRSH_RATA2 = vIS_LABA_BRSH / 12;
			int vIS_LABA_BRSH_RATA2_int = 0;
			try { vIS_LABA_BRSH_RATA2_int = Convert.ToInt32(Math.Round(vIS_LABA_BRSH_RATA2,0)); } 
			catch {}
			tTxt=tTxt + Pjg(CovToEBCDIC(vIS_LABA_BRSH_RATA2_int.ToString()),7);




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
			catch {vPRSN_INTEREST_PA = 0;}
			vPRSN_INTEREST_PA = vPRSN_INTEREST_PA * 100;
			int vPRSN_INTEREST_PA_int  = 0;
			try { vPRSN_INTEREST_PA_int = Convert.ToInt32(Math.Round(vPRSN_INTEREST_PA, 0)); } 
			catch {vPRSN_INTEREST_PA_int = 0;}
			tTxt=tTxt + Pjg(vPRSN_INTEREST_PA_int.ToString(),4);


			//tTxt=tTxt + conn.GetFieldValue(dt2,0,"");
			//A0913 - Ters in months
			//tTxt=tTxt+"--A0913--";
			tTxt=tTxt + Pjg(conn.GetFieldValue(dt1,0,"TERMYN_MONTH").ToString(),2);


			//tTxt=tTxt + conn.GetFieldValue(dt2,0,"");
			//A0914 - Acceptable Project Cost
			//tTxt=tTxt+"--A0914--";
			//tTxt=tTxt + Pjg(Math.Round(Double.Parse(conn.GetFieldValue(dt1,0,"ACCEPT_PROJECT_COST_KI"))).ToString(),8);
			double vACCEPT_PROJECT_COST_KI = 0.0;
			int vACCEPT_PROJECT_COST_KI_int = 0;
			try { vACCEPT_PROJECT_COST_KI = Convert.ToDouble(conn.GetFieldValue(dt1,0,"ACCEPT_PROJECT_COST_KI")); } 
			catch {}
			try { vACCEPT_PROJECT_COST_KI_int = Convert.ToInt32(Math.Round(vACCEPT_PROJECT_COST_KI, 0)); } 
			catch {}
			tTxt=tTxt + Pjg(vACCEPT_PROJECT_COST_KI_int.ToString(),8);



			//tTxt=tTxt + conn.GetFieldValue(dt2,0,"");
			//A0915 - Contractor Plafond : Tot Value of Projects 
			//tTxt=tTxt+"--A0915--";
			//tTxt=tTxt + Pjg(Math.Round(Double.Parse(conn.GetFieldValue(dt1,0,"PLAFOND_TOT_VAL_PROJECTS"))).ToString(),8);
			double vPLAFOND_TOT_VAL_PROJECTS = 0.0;
			int vPLAFOND_TOT_VAL_PROJECTS_int = 0;
			try { vPLAFOND_TOT_VAL_PROJECTS = Convert.ToDouble(conn.GetFieldValue(dt1,0,"PLAFOND_TOT_VAL_PROJECTS")); } 
			catch {}
			try { vPLAFOND_TOT_VAL_PROJECTS_int = Convert.ToInt32(Math.Round(vPLAFOND_TOT_VAL_PROJECTS, 0)); } 
			catch {}
			tTxt=tTxt + Pjg(vPLAFOND_TOT_VAL_PROJECTS_int.ToString(),8);



			//tTxt=tTxt + conn.GetFieldValue(dt2,0,"");
			//A0916 - Contractor Plafond : % project cost
			//tTxt=tTxt+"--A0916--";
			//tTxt=tTxt + Pjg(Math.Round(Double.Parse(conn.GetFieldValue(dt1,0,"PLAFOND_PRSN_PROJ_COST"))).ToString(),3);
			double vPLAFOND_PRSN_PROJ_COST = 0.0;
			int vPLAFOND_PRSN_PROJ_COST_int = 0;
			try { vPLAFOND_PRSN_PROJ_COST = Convert.ToDouble(conn.GetFieldValue(dt1,0,"PLAFOND_PRSN_PROJ_COST")); } 
			catch {}
			try { vPLAFOND_PRSN_PROJ_COST_int = Convert.ToInt32(Math.Round(vPLAFOND_PRSN_PROJ_COST, 0)); } 
			catch {}
			tTxt=tTxt + Pjg(vPLAFOND_PRSN_PROJ_COST_int.ToString(),3);



			//tTxt=tTxt + conn.GetFieldValue(dt2,0,"");
			//A0917 - Contractor Plafond " terma of payment (months)
			//tTxt=tTxt+"--A0917--";
			tTxt=tTxt + Pjg(conn.GetFieldValue(dt1,0,"PLAFOND_TOP").ToString(),2);
			

			//tTxt=tTxt + conn.GetFieldValue(dt2,0,"");
			//A0918 - Contractor Plafond : downpayment amount
			//tTxt=tTxt+"--A0918--";
			//tTxt=tTxt + Pjg(Math.Round(Double.Parse(conn.GetFieldValue(dt1,0,"PLAFOND_DP"))).ToString(),8);
			double vPLAFOND_DP = 0;
			int vPLAFOND_DP_int = 0;
			try { vPLAFOND_DP = Convert.ToDouble(conn.GetFieldValue(dt1,0,"PLAFOND_DP")); } 
			catch {}
			try { vPLAFOND_DP_int = Convert.ToInt32(Math.Round(vPLAFOND_DP, 0)); } 
			catch {}
			tTxt=tTxt + Pjg(vPLAFOND_DP_int.ToString(),8);



			//tTxt=tTxt + conn.GetFieldValue(dt2,0,"");
			//A0919 - Existing WC plafond limit in BM
			//tTxt=tTxt+"--A0919--";
			//tTxt=tTxt + Pjg(Math.Round(Double.Parse(conn.GetFieldValue(dt1,0,"CL_EXIST_WC_BM"))).ToString(),8);
			double vCL_EXIST_WC_BM = 0;
			int vCL_EXIST_WC_BM_int = 0;
			try { vCL_EXIST_WC_BM = Convert.ToDouble(conn.GetFieldValue(dt1,0,"CL_EXIST_WC_BM")); } 
			catch {}
			try { vCL_EXIST_WC_BM_int = Convert.ToInt32(Math.Round(vCL_EXIST_WC_BM, 0)); } 
			catch {}
			tTxt=tTxt + Pjg(vCL_EXIST_WC_BM_int.ToString(),8);



			//tTxt=tTxt + conn.GetFieldValue(dt2,0,"");
			//A0920 - Existing WC Plafond limit in other bank
			//tTxt=tTxt+"--A0920--";
			//tTxt=tTxt + Pjg(Math.Round(Double.Parse(conn.GetFieldValue(dt1, 0, "CL_EXIST_WC_OBANK"))).ToString(),8);
			double vCL_EXIST_WC_OBANK = 0.0;
			int vCL_EXIST_WC_OBANK_int = 0;
			try { vCL_EXIST_WC_OBANK = Convert.ToDouble(conn.GetFieldValue(dt1, 0, "CL_EXIST_WC_OBANK")); } 
			catch {}
			try { vCL_EXIST_WC_OBANK_int = Convert.ToInt32(Math.Round(vCL_EXIST_WC_OBANK, 0)); } 
			catch {}
			tTxt=tTxt + Pjg(vCL_EXIST_WC_OBANK_int.ToString(),8);



			//tTxt=tTxt + conn.GetFieldValue(dt2,0,"");
			//A0921 - Contrctor Termyn : Project Cost ( 1 Project)
			//tTxt=tTxt+"--A0921--";
			//tTxt=tTxt + Pjg(Math.Round(Double.Parse(conn.GetFieldValue(dt1,0,"PROJ_COST"))).ToString(),8);
			double vPROJ_COST = 0;
			int vPROJ_COST_int = 0;
			try { vPROJ_COST = Convert.ToDouble(conn.GetFieldValue(dt1,0,"PROJ_COST")); } 
			catch {}
			try { vPROJ_COST_int = Convert.ToInt32(Math.Round(vPROJ_COST, 0)); } 
			catch {}
			tTxt=tTxt + Pjg(vPROJ_COST_int.ToString(),8);



			//tTxt=tTxt + conn.GetFieldValue(dt2,0,"");
			//A0922 - Contractor Termyn : Number of Termyn 
			//tTxt=tTxt+"--A0922--";
			tTxt=tTxt + Pjg(conn.GetFieldValue(dt1,0,"NUM_TERMYN").ToString(),2);



			//tTxt=tTxt + conn.GetFieldValue(dt2,0,"");
			//A0923 - SB Non Cash Value of Peoject Pa - General
			//tTxt=tTxt+"--A0923--";
			//tTxt=tTxt + Pjg(Math.Round(Double.Parse(conn.GetFieldValue(dt1,0,"SB_NC_PROJ_PA_GENERAL"))).ToString(),8);
			double vSB_NC_PROJ_PA_GENERAL = 0.0;
			int vSB_NC_PROJ_PA_GENERAL_int = 0;
			try { vSB_NC_PROJ_PA_GENERAL = Convert.ToDouble(conn.GetFieldValue(dt1,0,"SB_NC_PROJ_PA_GENERAL")); } 
			catch {}
			try { vSB_NC_PROJ_PA_GENERAL_int = Convert.ToInt32(Math.Round(vSB_NC_PROJ_PA_GENERAL, 0)); } 
			catch {}
			tTxt=tTxt + Pjg(vSB_NC_PROJ_PA_GENERAL_int.ToString(),8);



			//tTxt=tTxt + conn.GetFieldValue(dt2,0,"");
			//A0924 - SB Non Cash Value of Project pa - Purchase bbond
			//tTxt=tTxt+"--A0924--";
			//tTxt=tTxt + Pjg(Math.Round(Double.Parse(conn.GetFieldValue(dt1,0,"NC_PROJ_PA_PURCHASE_BOND"))).ToString(),8);
			double vNC_PROJ_PA_PURCHASE_BOND = 0;
			int vNC_PROJ_PA_PURCHASE_BOND_int = 0;
			try { vNC_PROJ_PA_PURCHASE_BOND = Convert.ToDouble(conn.GetFieldValue(dt1,0,"NC_PROJ_PA_PURCHASE_BOND")); } 
			catch {}
			try { vNC_PROJ_PA_PURCHASE_BOND_int = Convert.ToInt32(Math.Round(vNC_PROJ_PA_PURCHASE_BOND, 0)); } 
			catch {}
			tTxt=tTxt + Pjg(vNC_PROJ_PA_PURCHASE_BOND_int.ToString(),8);



			//tTxt=tTxt + conn.GetFieldValue(dt2,0,"");
			//A0925 - SB % Probability of Success bid bond
			//tTxt=tTxt+"--A0925--";
			//tTxt=tTxt + Pjg(Math.Round(Double.Parse(conn.GetFieldValue(dt1,0,"PRSN_PROB_SUCCESS_BID_BOND"))).ToString(),3);
			double vPRSN_PROB_SUCCESS_BID_BOND = 0;
			int vPRSN_PROB_SUCCESS_BID_BOND_int = 0;
			try { vPRSN_PROB_SUCCESS_BID_BOND = Convert.ToDouble(conn.GetFieldValue(dt1,0,"PRSN_PROB_SUCCESS_BID_BOND")); } 
			catch {}
			try { vPRSN_PROB_SUCCESS_BID_BOND_int = Convert.ToInt32(Math.Round(vPRSN_PROB_SUCCESS_BID_BOND, 0)); } 
			catch {}
			tTxt=tTxt + Pjg(vPRSN_PROB_SUCCESS_BID_BOND_int.ToString(),3);



			//tTxt=tTxt + conn.GetFieldValue(dt2,0,"");
			//A0926 - % Bid Bond
			//tTxt=tTxt+"--A0926--";
			//tTxt=tTxt + Pjg(Math.Round(Double.Parse(conn.GetFieldValue(dt1,0,"BID_BOND"))).ToString(),3);
			double vBID_BOND = 0;
			int vBID_BOND_int = 0;
			try { vBID_BOND = Convert.ToDouble(conn.GetFieldValue(dt1,0,"BID_BOND")); } 
			catch {}
			try { vBID_BOND_int = Convert.ToInt32(Math.Round(vBID_BOND, 0)); } 
			catch {}
			tTxt=tTxt + Pjg(vBID_BOND_int.ToString(),3);



			//tTxt=tTxt + conn.GetFieldValue(dt2,0,"");
			//A0927 - % Advance Bond
			//tTxt=tTxt+"--A0927--";
			//tTxt=tTxt + Pjg(Math.Round(Double.Parse(conn.GetFieldValue(dt1,0,"ADV_BOND"))).ToString(),3);
			double vADV_BOND = 0;
			int vADV_BOND_int = 0;
			try { vADV_BOND = Convert.ToDouble(conn.GetFieldValue(dt1,0,"ADV_BOND")); } 
			catch {}
			try { vADV_BOND_int = Convert.ToInt32(Math.Round(vADV_BOND, 0)); } 
			catch {}
			tTxt=tTxt + Pjg(vADV_BOND_int.ToString(),3);




			//tTxt=tTxt + conn.GetFieldValue(dt2,0,"");
			//A0928 - % Performance Bond
			//tTxt=tTxt+"--A0928--";
			//tTxt=tTxt + Pjg(Math.Round(Double.Parse(conn.GetFieldValue(dt1,0,"PRFRMN_BOND"))).ToString(),3);
			double vPRFRMN_BOND = 0;
			int vPRFRMN_BOND_int = 0;
			try { vPRFRMN_BOND = Convert.ToDouble(conn.GetFieldValue(dt1,0,"PRFRMN_BOND")); } 
			catch {}
			try { vPRFRMN_BOND_int = Convert.ToInt32(Math.Round(vPRFRMN_BOND, 0)); } 
			catch {}
			tTxt=tTxt + Pjg(vPRFRMN_BOND_int.ToString(),3);




			//tTxt=tTxt + conn.GetFieldValue(dt2,0,"");
			//A0929 - % Retention Bond
			//tTxt=tTxt+"--A0929--";
			//tTxt=tTxt + Pjg(Math.Round(Double.Parse(conn.GetFieldValue(dt1,0,"PRSN_RET_BOND"))).ToString(),3);
			double vPRSN_RET_BOND = 0;
			int vPRSN_RET_BOND_int = 0;
			try { vPRSN_RET_BOND = Convert.ToDouble(conn.GetFieldValue(dt1,0,"PRSN_RET_BOND")); } 
			catch {}
			try { vPRSN_RET_BOND_int = Convert.ToInt32(Math.Round(vPRSN_RET_BOND, 0)); } 
			catch {}
			tTxt=tTxt + Pjg(vPRSN_RET_BOND_int.ToString(),3);




			//tTxt=tTxt + conn.GetFieldValue(dt2,0,"");
			//A0930 - % Purchase Bond
			//tTxt=tTxt+"--A0930--";
			//tTxt=tTxt + Pjg(Math.Round(Double.Parse(conn.GetFieldValue(dt1,0,"PRSN_PURCHASE_BOND"))).ToString(),3);
			double vPRSN_PURCHASE_BOND = 0;
			int vPRSN_PURCHASE_BOND_int = 0;
			try { vPRSN_PURCHASE_BOND = Convert.ToDouble(conn.GetFieldValue(dt1,0,"PRSN_PURCHASE_BOND")); } 
			catch {}
			try { vPRSN_PURCHASE_BOND_int = Convert.ToInt32(Math.Round(vPRSN_PURCHASE_BOND, 0)); } 
			catch {}
			tTxt=tTxt + Pjg(vPRSN_PURCHASE_BOND_int.ToString(),3);
			


			//vtTxt=tTxt + conn.GetFieldValue(dt2,0,"");
			//A0931 - SB Avg Value L/C in a year
			//tTxt=tTxt+"--A0931--";
			//tTxt=tTxt + Pjg(Math.Round(Double.Parse(conn.GetFieldValue(dt1,0,"SB_AVG_VALUELC_YEAR"))).ToString(),8);
			double vSB_AVG_VALUELC_YEAR = 0;
			int vSB_AVG_VALUELC_YEAR_int = 0;
			try { vSB_AVG_VALUELC_YEAR = Convert.ToDouble(conn.GetFieldValue(dt1,0,"SB_AVG_VALUELC_YEAR")); } 
			catch {}
			try { vSB_AVG_VALUELC_YEAR_int = Convert.ToInt32(Math.Round(vSB_AVG_VALUELC_YEAR, 0)); } 
			catch {}
			tTxt=tTxt + Pjg(vSB_AVG_VALUELC_YEAR_int.ToString(),8);




			//			//tTxt=tTxt + conn.GetFieldValue(dt2,0,"");
			//			//A0932 - SB Avg term of L/C in a year (turnover in months)
			//			//tTxt=tTxt+"--A0932--";
			//			tTxt=tTxt + Pjg(Math.Round(Double.Parse(conn.GetFieldValue(dt1,0,"SB_AVG_TERMLC"))).ToString(),3);
			//
			//
			//			//tTxt=tTxt + conn.GetFieldValue(dt2,0,"");
			//			//A0933 - MC Contractor Peak deficit cash flow
			//			//tTxt=tTxt+"--A0933--";
			//			tTxt=tTxt + Pjg(Math.Round(Double.Parse(conn.GetFieldValue(dt1,0,"MC_CONT_PEAK_DEFICIT_CF"))).ToString(),8);
			//
			//
			//			//tTxt=tTxt + conn.GetFieldValue(dt2,0,"");
			//			//A0934 - MC Non Cash Total Amount of Contract in Millions
			//			//tTxt=tTxt+"--A0934--";
			//			tTxt=tTxt + Pjg(Math.Round(Double.Parse(conn.GetFieldValue(dt1,0,"MC_NC_TOTAMOUNT"))).ToString(),8);
			//
			//
			//			//tTxt=tTxt + conn.GetFieldValue(dt2,0,"");
			//			//A0934 - Contractor Turnkey Project Cost
			//			//tTxt=tTxt+"--A0935--";
			//			tTxt=tTxt + Pjg(Math.Round(Convert.ToDouble(conn.GetFieldValue(dt1,0,"CONTR_TURNKEY_PROJ_COST"))).ToString(),8);


			//A0932 - SB Avg term of L/C in a year (turnover in months)
			//tTxt=tTxt+"--A0932--";
			double vSB_AVG_TERMLC= 0;
			int vSB_AVG_TERMLC_int = 0;
			try { vSB_AVG_TERMLC = Convert.ToDouble(conn.GetFieldValue(dt1,0,"SB_AVG_TERMLC")); } 
			catch {}
			try { vSB_AVG_TERMLC_int= Convert.ToInt32(Math.Round(vSB_AVG_TERMLC, 0)); } 
			catch {}
			tTxt=tTxt + Pjg(vSB_AVG_TERMLC_int.ToString(),3);
			//tTxt=tTxt + Pjg(Math.Round(Double.Parse(conn.GetFieldValue(dt1,0,"SB_AVG_TERMLC"))).ToString(),3);


			//A0933 - MC Contractor Peak deficit cash flow
			//tTxt=tTxt+"--A0933--";
			double vMC_CONT_PEAK_DEFICIT_CF= 0;
			int vMC_CONT_PEAK_DEFICIT_CF_int = 0;
			try { vMC_CONT_PEAK_DEFICIT_CF = Convert.ToDouble(conn.GetFieldValue(dt1,0,"MC_CONT_PEAK_DEFICIT_CF")); } 
			catch {}
			try { vMC_CONT_PEAK_DEFICIT_CF_int= Convert.ToInt32(Math.Round(vMC_CONT_PEAK_DEFICIT_CF, 0)); } 
			catch {}
			tTxt=tTxt + Pjg(vMC_CONT_PEAK_DEFICIT_CF_int.ToString(),8);
			//tTxt=tTxt + Pjg(Math.Round(Double.Parse(conn.GetFieldValue(dt1,0,"MC_CONT_PEAK_DEFICIT_CF"))).ToString(),8);


			//A0934 - MC Non Cash Total Amount of Contract in Millions
			//tTxt=tTxt+"--A0934--";
			double vMC_NC_TOTAMOUNT= 0;
			int vMC_NC_TOTAMOUNT_int = 0;
			try { vMC_NC_TOTAMOUNT = Convert.ToDouble(conn.GetFieldValue(dt1,0,"MC_NC_TOTAMOUNT")); } 
			catch {}
			try { vMC_NC_TOTAMOUNT_int= Convert.ToInt32(Math.Round(vMC_NC_TOTAMOUNT, 0)); } 
			catch {}
			tTxt=tTxt + Pjg(vMC_NC_TOTAMOUNT_int.ToString(),8);
			//tTxt=tTxt + Pjg(Math.Round(Double.Parse(conn.GetFieldValue(dt1,0,"MC_NC_TOTAMOUNT"))).ToString(),8);


			//A0934 - Contractor Turnkey Project Cost
			//tTxt=tTxt+"--A0935--";
			double vCONTR_TURNKEY_PROJ_COST= 0;
			int vCONTR_TURNKEY_PROJ_COST_int = 0;
			try { vCONTR_TURNKEY_PROJ_COST = Convert.ToDouble(conn.GetFieldValue(dt1,0,"CONTR_TURNKEY_PROJ_COST")); } 
			catch {}
			try { vCONTR_TURNKEY_PROJ_COST_int= Convert.ToInt32(Math.Round(vCONTR_TURNKEY_PROJ_COST, 0)); } 
			catch {}
			tTxt=tTxt + Pjg(vCONTR_TURNKEY_PROJ_COST_int.ToString(),8);
			//tTxt=tTxt + Pjg(Math.Round(Convert.ToDouble(conn.GetFieldValue(dt1,0,"CONTR_TURNKEY_PROJ_COST"))).ToString(),8);





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
			
			conn.QueryString="delete from SCORING_MESSAGE where ap_regno='" + regno + "' and sumberdata = 'FINALSCORING'";
			conn.ExecuteNonQuery();

			conn.QueryString="insert into SCORING_MESSAGE values('" + regno + "','" + tTxt + "','FINALSCORING','0')";
			conn.ExecuteNonQuery();

			return "1";
		}


		string CovToEBCDIC(string strTemp)
		{
			string strX;
			double dblX;
			if ((strTemp == null) || (strTemp == "")) strTemp = "0";
			strX = GlobalTools.ConvertFloat(strTemp);
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

		string getYN(string xYN)
		{
			if (xYN=="1")
			{	
				return "Y";
			}
			else if (xYN=="0")
			{	
				return "N";
			}
			else
			{
				return "N";
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





	}
}
