using System;
using System.Data;
using System.IO;
using DMS.DBConnection;
using DMS.CuBESCore;


namespace SME.Scoring
{
	/// <summary>
	/// Summary description for DSS_Header.
	/// 
	/// Cara Panggil
	/// 
	/// 			// --start -- by ashari 20041227
	//	//panggil fungsi DSSHeader dari class DSSHeader 
	//	SME.Scoring.clsDSSHeader objDSSHeader = new SME.Scoring.clsDSSHeader(conn, (string)Request.QueryString["regno"], (string)Request.QueryString["curef"]);
	//	objDSSHeader.addDSSHeader();
	//	// --end -- by ashari 20041227

	/// 
	/// </summary>
	public class clsDSSHeader
	{
		private Connection conn;
		private string regno;
		private string curef;
		public clsDSSHeader(Connection cons, string reg_no, string cu_ref)
		{
			conn = cons;
			regno = reg_no;
			curef=cu_ref;
			//
			// TODO: Add constructor logic here
			//
		}

		//Fungsi ini mengenerate DSS Header (sesuai DD)
		public string addDSSHeader(string dss_type)
		{
			string str;

			// mask out this when come to actual testing .....
			str = "";
			//return str;

			conn.QueryString="select * from VW_DSS_HEADER where ap_regno='" + regno + "'";
			conn.ExecuteQuery();
			//branch code, length : 10
			string branch_code=conn.GetFieldValue("branch_code");
			str=IsiBlankBehind(branch_code,10);
			//user id, length : 20
			string user_id=conn.GetFieldValue("userid");
			str=str+ IsiBlankBehind(user_id,20);
			//customer name, length : 50
			string customer_name=conn.GetFieldValue("customer_name");
			str=str+ IsiBlankBehind(customer_name,50);
			string cu_ref =conn.GetFieldValue("cu_ref");
			str=str+ IsiBlankBehind(cu_ref,20);
			string emas_cif =conn.GetFieldValue("emas_cif");
			str=str+ IsiBlankBehind(emas_cif,19);
			// if scoring -> pass in S space
			// if rating ->
			// if customer rating -> pass in 'C'
			// if fac rating -> pass in 'F'
			if (dss_type == "S" ) str = str + " ";
			else str = str + dss_type;
			return str;
		}

		//Fungsi ini menambahkan nilai "0" pada strTmp shg length strTmp menjadi intJml
		private String Pjg(string strTmp,int intJml)
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

		private String IsiBlankBehind(string strTmp, int intJml)
		{
			for(int i=0;i<intJml+1;i++)
			{
				if (i>strTmp.Length)
				{
					strTmp=strTmp+ " ";
				}
			}
			return strTmp;
		}
	}
}
