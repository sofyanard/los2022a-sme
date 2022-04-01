using System;
using DMS.DBConnection;

namespace Earmarking
{
	/// <summary>
	/// Summary description for Earmarking.
	/// </summary>
	public class Earmarking
	{
		public  Earmarking()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		public static void calculateEarmarkLimit(string ap_regno, Connection conn) 
		{
			conn.QueryString = "exec EARMARK_CALCULATEAMOUNT '" + ap_regno + "'";
			conn.ExecTrans();
			//conn.ExecuteNonQuery();
		}

		public static void calculateEarmarkLimit(string ap_Regno, string ket_code, Connection conn) 
		{
			conn.QueryString = "exec EARMARK_CALCULATEAMOUNT '" + ap_Regno + "', '" + ket_code + "'";
			conn.ExecTrans();
			//conn.ExecuteNonQuery();
		}
		
		public static void doEarmark(string ap_Regno, string ket_code, Connection conn) 
		{
			doEarmark(ap_Regno, ket_code, conn, "", "");
		}

		public static void doEarmark(string ap_Regno, string ket_code, Connection conn, string allowNegativeLimitProject, string allowNegativeLimitFacility)
		{
			try 
			{
				conn.QueryString = "exec EARMARK_DOEARMARK '" + ap_Regno + "', '" + ket_code + "', '" + allowNegativeLimitProject + "', '" + allowNegativeLimitFacility + "', 'PROJECT'";
				conn.ExecTrans();
				//conn.ExecuteNonQuery();
			} 
			catch 
			{
				throw new NegativeLimitException("PROJECT");
			}

			try 
			{
				conn.QueryString = "exec EARMARK_DOEARMARK '" + ap_Regno + "', '" + ket_code + "', '" + allowNegativeLimitProject + "', '" + allowNegativeLimitFacility + "', 'FACILITY'";
				conn.ExecTrans();
				//conn.ExecuteNonQuery();
			} 
			catch 
			{
				throw new NegativeLimitException("FACILITY");
			}
		}

		public static void doEarmark(string ap_Regno, Connection conn, string allowNegativeLimitProject, string allowNegativeLimitFacility)  
		{
			try 
			{
				conn.QueryString = "exec EARMARK_DOEARMARK '" + ap_Regno + "', null, '" + allowNegativeLimitProject + "', '" + allowNegativeLimitFacility + "', 'PROJECT'";
				conn.ExecTrans();
				//conn.ExecuteNonQuery();		
			} 
			catch 
			{
				throw new NegativeLimitException("PROJECT");
			}				

			try 
			{
				conn.QueryString = "exec EARMARK_DOEARMARK '" + ap_Regno + "', null, '" + allowNegativeLimitProject + "', '" + allowNegativeLimitFacility + "', 'FACILITY'";
				conn.ExecTrans();
				//conn.ExecuteNonQuery();		
			} 
			catch 
			{
				throw new NegativeLimitException("FACILITY");
			}				
		}

		public static void doEarmark(string ap_Regno, Connection conn) 
		{
			doEarmark(ap_Regno, conn, "", "");
		}

		public static void reverseEarmark(string ap_Regno, Connection conn) 
		{
			conn.QueryString = "exec EARMARK_REVERSEEARMARK '" + ap_Regno + "'";
			conn.ExecTrans();
			//conn.ExecuteNonQuery();
		}

		public static void reverseEarmark(string ap_regno, string ket_code, Connection conn) 
		{
			conn.QueryString = "exec EARMARK_REVERSEEARMARK '" + ap_regno + "', '" + ket_code + "'";
			conn.ExecTrans();
			//conn.ExecuteNonQuery();
		}
	}
}
