using System;
using DMS.DBConnection;
using DMS.CuBESCore;

namespace SME.Scoring
{
	/// <summary>
	/// Summary description for updateScoring.
	/// </summary>
	public class updateScoring
	{
		private Connection conn;
		private string regno;

		public updateScoring(Connection cons, string reg_no)
		{
			conn = cons;
			regno = reg_no;
			//
			// TODO: Add constructor logic here
			//
		}

		//Fungsi ini menambahkan nilai "0" di depan strTmp sehingga length strTmp menjadi intJml
		string Pjg(string strTmp,int intJml)
		{
			// kalau strTmp.Length > intJml
			if (strTmp.Length > intJml) 
			{
				strTmp = strTmp.Substring(strTmp.Length - intJml, intJml);
			}
			else 
			{
				// kalau strTmp.Length < intJml
				for(int i=0; i<= intJml; i++)
				{
					if (i>strTmp.Length)
					{
						strTmp = "0" + strTmp;
					}
				}
			}
			return strTmp;
		}


		//Fungsi ini mengenerate string " " sejumlah intJml kali untuk ditambahkan pada string yang membutuhkannnya
		string IsiBlank(int intJml)
		{
			String strTmp="";
			for(int i=0;i<intJml;i++)
			{
				strTmp=strTmp+ " ";
			}
			return strTmp;
		}


		//Procedure ini mengenerate string update untuk scoring 
		public void CreateTextUpdateFIA(int sppk)
		{
			// if call from SPPK, sppk = 1
			// else sppk = 0;

			string strFIACRPU="";
			int prescoring = 0;

			string cu_ref="";
			conn.QueryString="select cu_ref from application where ap_regno='" + regno  + "'";
			conn.ExecuteQuery();
			cu_ref=conn.GetFieldValue("cu_ref");

			// decide whether the application has scoring !!!!
			conn.QueryString="select SUMBERDATA, UPDATE_FLAG from scoring_response_tbl where " +
				" ap_regno = '" + regno  + "' and SUMBERDATA in ('PRESCORING','FINALSCORING')"; 
			conn.ExecuteQuery();

			if ((conn.GetRowCount()) == 0 ) return;  // not scoring program
			if ((conn.GetRowCount()) == 2 ) prescoring = 0;
			else 
			{
				if ( conn.GetFieldValue("SUMBERDATA").ToUpper() == "PRESCORING") prescoring = 1;	
				else prescoring = 0;
			}

			if ( conn.GetFieldValue("UPDATE_FLAG")  == "1") return;		


			// Create Text File for Update Scoring


			// Create DSS

			///	// --start -- by ashari 20041227
			//	//panggil fungsi DSSHeader dari class DSSHeader 
			//	SME.Scoring.clsDSSHeader objDSSHeader = new SME.Scoring.clsDSSHeader(conn, (string)Request.QueryString["regno"], (string)Request.QueryString["curef"]);
			//	strFIACRPU=objDSSHeader.addDSSHeader();
			SME.Scoring.clsDSSHeader objDSSHeader = new SME.Scoring.clsDSSHeader(conn, regno, cu_ref );
			strFIACRPU=objDSSHeader.addDSSHeader("S");
			//	// --end -- by ashari 20041227
			


			//-3-Kode Mandiri
			strFIACRPU=strFIACRPU+"BM2";
			//-4-
			strFIACRPU=strFIACRPU+"9999";
			//-20-ID : APRegno
			strFIACRPU=strFIACRPU+Pjg(regno,20);
			//-2-Kode NBR
			strFIACRPU=strFIACRPU+"01";
				
				
			if (prescoring == 1 ) 
			{
				//-2-App Decission
				strFIACRPU=strFIACRPU+"D ";
				// if call from reject letter REJECT

				//-8-Tanggal Approval (yyyymmdd)
				//conn.QueryString="select ad_date from approval_decision where ap_regno='" + regno + "'";
				//conn.ExecuteQuery();				
				// cuba format date format
				strFIACRPU=strFIACRPU+ Pjg( Convert.ToString(DateTime.Now.Year), 4) + Pjg( Convert.ToString(DateTime.Now.Month), 2) + Pjg( Convert.ToString(DateTime.Now.Day), 2);	
				//-8- Approval
				conn.QueryString="select AP_RELMNGR from application where ap_regno = '" + regno  + "'";					
				conn.ExecuteQuery();
				strFIACRPU=strFIACRPU+Pjg(conn.GetFieldValue("AP_RELMNGR"),8);
				//-3-Override Code
				//conn.QueryString="select AD_OVRREASON from approval_decision where ap_regno='" + regno + "'";
				//conn.ExecuteQuery();
				// prescoring - REJECT
				strFIACRPU=strFIACRPU+Pjg("999",3);

			}
			else  // final scoring ... the decision is from decision table 
			{
//				conn.QueryString = "select AP_CURRTRACK from APPTRACK where AP_REGNO = '" + regno + "'";
//				conn.ExecuteQuery();
//
//				if (conn.GetFieldValue("AP_CURRTRACK") == "3.7")	// Approved, SPPK Creation
//				{
//					sppk = 1;
//				}
//				else sppk = 0;
				
				/*
				conn.QueryString="select top 1 officer_code, ad_date, AD_OVRSTA from approval_decision where " +
					" ad_seq = (select max(ad_seq) from approval_decision ad left join scuser u on " +
					" ad.officer_code = u.officer_code where  ad.ap_regno = '" + regno  + 
					"'  and u.userid <> 'SYSTEM') and ap_regno = '" + regno  + "'"; 
				*/
				conn.QueryString = "exec SCORING_APPROVALINFO '" + regno + "'";
				conn.ExecuteQuery();

				// if call from SPPK	
				//-2-App Decission
				if (sppk == 1 ) strFIACRPU=strFIACRPU+Pjg("A ",2);
				else strFIACRPU=strFIACRPU+Pjg("D ",2);
				// if call from reject letter REJECT

				//-8-Tanggal Approval
				//conn.QueryString="select ad_date from approval_decision where ap_regno='" + regno + "'";
				//conn.ExecuteQuery();	
				// cuba format date format
				strFIACRPU=strFIACRPU+Convert.ToString(DateTime.Parse(conn.GetFieldValue("ad_date")).Year);	
				strFIACRPU=strFIACRPU+Pjg(Convert.ToString(DateTime.Parse(conn.GetFieldValue("ad_date")).Month),2);	
				strFIACRPU=strFIACRPU+Pjg(Convert.ToString(DateTime.Parse(conn.GetFieldValue("ad_date")).Day),2);	
				//-8- Approval
				strFIACRPU=strFIACRPU+Pjg(conn.GetFieldValue("officer_code"),8);
				//-3-Override Code
				//conn.QueryString="select AD_OVRREASON from approval_decision where ap_regno='" + regno + "'";
				//conn.ExecuteQuery();
				if (sppk == 1) strFIACRPU = strFIACRPU + Pjg("000",3);
				else strFIACRPU = strFIACRPU + Pjg(conn.GetFieldValue("AD_OVRSTA"),3);
			}

			conn.QueryString="exec SCORING_SPPK_LETTER_UPDATE 'Save','" + regno + "','" + strFIACRPU + "','UPDATE','0'";
			conn.ExecuteNonQuery();



			// update flag ----  update to scoring_response_tbl
			conn.QueryString="update scoring_response_tbl set update_flag = 1 where ap_regno ='" + regno + "'" ;
			conn.ExecuteNonQuery();
			   
		}
	



	}
}
