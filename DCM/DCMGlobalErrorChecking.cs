using System;
using System.Configuration;
using DMS.DBConnection;

namespace SME.DCM
{
	/// <summary>
	/// Summary description for DCMGlobalErrorChecking.
	/// </summary>
	public class DCMGlobalErrorChecking
	{
		public enum PageType 
		{
			CIFGeneralDataBU = 1, 
			LaporanJatuhTempoKewajiban, 
			LaporanPendingIssue, 
			LaporanPendingCovenant
		};
		//protected Connection conn = new Connection(ConfigurationSettings.AppSettings["conn"]);

		public DCMGlobalErrorChecking()
		{
			//
			// TODO: Add constructor logic here
			//
		}


	}
}
