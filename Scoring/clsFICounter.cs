using System;
using System.Data;
using System.IO;
using DMS.DBConnection;
using DMS.CuBESCore;

namespace SME.Scoring
{
	/// <summary>
	/// Summary description for clsFICounter.
	/// 
	/// // --start -- by ashari 20041227
	//	panggil fungsi setFICounter dari class clsFICounter 
	//	SMEScoring.clsFICounter objFICounter = new SME.Scoring.clsFICounter(conn, (string)Request.QueryString["regno"], (string)Request.QueryString["curef"]);
	//	objFICounter.setFICounter("PS","SND");
	//	// --end -- by ashari 20041227

	/// 
	/// 
	/// </summary>
	/// 


	public class clsFICounter
	{
		private Connection conn;
		private string regno;
		private string curef;
		public clsFICounter(Connection cons, string reg_no, string cu_ref)
		{
			conn = cons;
			regno = reg_no;
			curef=cu_ref;
			//
			// TODO: Add constructor logic here
			//
		}

		public void setFICounter(string ScoringType,string ActivityType)
		{
			string str="";
			int acq_info =0;

			conn.QueryString="select isnull(ap_acqinfo, '0'), isnull(ap_isappealby,'0') from application where ap_regno = '" + regno + "'";
			conn.ExecuteQuery();
			string col1 = conn.GetFieldValue(0,0);
			string col2 = conn.GetFieldValue(0,1);

			if (col1.Length > 1 ) acq_info = 1;
			else acq_info = 0;


			if (ScoringType=="PS")
			{
				if (ActivityType=="SND")
				{
					str="exec sp_set_scoring_counter 'Save','1','" + regno + "', 0, 0, 0";
				}
				else if (ActivityType=="RCV")
				{
					
					str="exec sp_set_scoring_counter 'Save','0','" + regno + "',1,0,0";
				}
			}
			else if (ScoringType=="FS")
			{
				if (ActivityType=="SND")
				{
					str="exec sp_set_scoring_counter 'Save','1','" + regno + "',0,0,0";
				}
				else if (ActivityType=="RCV")
				{
					if ( acq_info == 1 )
						str="exec sp_set_scoring_counter 'Save','0','" + regno + "',0,0,1";
					else
						str="exec sp_set_scoring_counter 'Save','0','" + regno + "',0,1,0";
				}
			}
			conn.QueryString=str;
			conn.ExecuteNonQuery();
		}

		public bool check_counter ( string ScoringType )
		{
			int acq_info =0;
			string retval;
			string col1, col2;

			
			if (ScoringType == "FS") 
			{
				conn.QueryString="select isnull(ap_acqinfo, '0'), isnull(ap_isappealby,'0') from application where ap_regno = '" + regno + "'";
				conn.ExecuteQuery();
				col1 = conn.GetFieldValue(0,0);
				col2 = conn.GetFieldValue(0,1);
			}
			else 
			{
				col1 = "0";
				col2 = "0";
			}

	

			if (col1.Length > 1 ) acq_info = 1;
			else acq_info = 0;

			// assuming appeal whom comes in ....
			//

			if (acq_info == 1 )  // acq info scoring
				conn.QueryString="exec  SP_GET_SCORING_COUNTER 'FS-AC', '" + regno + "'";
			else
				conn.QueryString="exec  SP_GET_SCORING_COUNTER '"+ScoringType +"', '" + regno + "'";
			conn.ExecuteQuery();
			retval = conn.GetFieldValue(0,0);

			if (retval =="1") return true;
 			return false;			
		}
	}	

}
