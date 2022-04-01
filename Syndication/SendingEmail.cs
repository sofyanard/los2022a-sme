using System;
using System.Configuration;
using DMS.CuBESCore;
using DMS.DBConnection;

namespace SME.Syndication
{
	/// <summary>
	/// Summary description for SendingEmail.
	/// </summary>
	public class SendingEmail
	{
		public enum EmailFormat 
		{
			LaporanDokumenYangAkanJatuhTempo = 1, 
			LaporanJatuhTempoKewajiban, 
			LaporanPendingIssue, 
			LaporanPendingCovenant
		};
		protected Connection conn = new Connection(ConfigurationSettings.AppSettings["conn"]);

		static string subject = "";
		static string br = "------------------------------------------------";
		static string breakSpace = "\n";
		static string NamaNasabah = "Nama Nasabah : ";
		static string NamaBank = "Nama Bank : ";
		static string NamaDokumen = "Nama Dokumen : ";
		static string KelompokDokumen = "Kelompok Dokumen : ";
		static string TanggalJatuhTempo = "Tanggal Jatuh Tempo : ";
		static string NamaProduct = "Nama Product : ";
		static string BakiDebet = "Baki Debet : ";
		static string KewajibanBunga = "Kewajiban Bunga : ";
		static string IssueType = "Issue Type : ";
		static string TargetDatePenyelesaian = "Target Date Penyelesaian : ";
		static string Item = "Item : ";
		static string Description = "Description : ";
		static string JatuhTempo = "Jatuh Tempo : ";
		static string NextPeriode = "Next Priod : ";

		public SendingEmail()
		{
				
		}

		private void ResetParameter()
		{
			NamaNasabah = "Nama Nasabah : ";
			NamaBank = "Nama Bank : ";
			NamaDokumen = "Nama Dokumen : ";
			KelompokDokumen = "Kelompok Dokumen : ";
			TanggalJatuhTempo = "Tanggal Jatuh Tempo : ";
			NamaProduct = "Nama Product : ";
			BakiDebet = "Baki Debet : ";
			KewajibanBunga = "Kewajiban Bunga : ";
			IssueType = "Issue Type : ";
			TargetDatePenyelesaian = "Target Date Penyelesaian : ";
			Item = "Item : ";
			Description = "Description : ";
			JatuhTempo = "Jatuh Tempo : ";
			NextPeriode = "Next Priod : ";
		}


		public static void Send(string from, string to, EmailFormat type, Connection conn)
		{
			string Content = "";
			conn.ExecuteQuery();
			if(type == EmailFormat.LaporanDokumenYangAkanJatuhTempo)
			{
				subject = "Laporan Dokumen yang Akan Jatuh Tempo";
				for (int i = 0; i < conn.GetRowCount(); i++) 
				{
					/* 
					Nama Nasabah 	: 	 PT Semen Tonasa 
					Nama Bank 	: 	PT Bank Mandiri 
					Nama Dokumen 	: 	SKMHT 
					Kelompok Dokumen	:	Dokumen Pengikatan
					Tanggal Jatuh Tempo 	: 	01-08-2012 
					* */

					//format string disini
					Content += string.Concat(NamaNasabah + conn.GetFieldValue(i,"NamaNasabah"));
					Content += breakSpace;
					Content += string.Concat(NamaBank + conn.GetFieldValue(i,"NamaBank"));
					Content += breakSpace;
					Content += string.Concat(NamaDokumen + conn.GetFieldValue(i,"NamaDokumen"));
					Content += breakSpace;
					Content += string.Concat(KelompokDokumen + conn.GetFieldValue(i,"KelompokDokumen"));
					Content += breakSpace;
					Content += string.Concat(TanggalJatuhTempo + conn.GetFieldValue(i, "TanggalJatuhTempo"));
					Content += breakSpace;
					Content += br;
					Content += breakSpace;
				}
			}
			else if(type == EmailFormat.LaporanJatuhTempoKewajiban)
			{
				subject = "Laporan Jatuh Tempo Kewajiban";
				for (int i = 0; i < conn.GetRowCount(); i++) 
				{
					/*
					Nama Nasabah 	: 	 PT Semen Tonasa 
					Nama Bank 	: 	PT Bank Mandiri 
					Nama Product 	: 	Kredit Investasi
					Baki Debet	:	1.568.422.778.577,00
					Kewajiban Bunga	:	422.778.577,00
					 * */
					
					Content += string.Concat(NamaNasabah + conn.GetFieldValue(i,"NamaNasabah"));
					Content += breakSpace;
					Content += string.Concat(NamaBank + conn.GetFieldValue(i,"NamaBank"));
					Content += breakSpace;
					Content += string.Concat(NamaProduct + conn.GetFieldValue(i,"NamaProduct"));
					Content += breakSpace;
					Content += string.Concat(BakiDebet + conn.GetFieldValue(i,"BakiDebet"));
					Content += breakSpace;
					Content += string.Concat(KewajibanBunga + conn.GetFieldValue(i, "KewajibanBunga"));
					Content += breakSpace;
					Content += br;
					Content += breakSpace;
				}
			}
			else if(type == EmailFormat.LaporanPendingCovenant)
			{
				subject = "Laporan Pending Covenant";
				for (int i = 0; i < conn.GetRowCount(); i++) 
				{
					/*
					Nama Nasabah 	: 	 PT Semen Tonasa 
					Nama Bank 	: 	PT Bank Mandiri 
					Item 	: 	Syarat Penarikan 
					Description	:	Menyampaikan Laporan
					Jatuh Tempo	:	01-08-2012
					Next Period	:	-
					 * */
					
					Content += string.Concat(NamaNasabah + conn.GetFieldValue(i,"NamaNasabah"));
					Content += breakSpace;
					Content += string.Concat(NamaBank + conn.GetFieldValue(i,"NamaBank"));
					Content += breakSpace;
					Content += string.Concat(Item + conn.GetFieldValue(i,"Item"));
					Content += breakSpace;
					Content += string.Concat(Description + conn.GetFieldValue(i,"Description"));
					Content += breakSpace;
					Content += string.Concat(JatuhTempo + conn.GetFieldValue(i, "JatuhTempo"));
					Content += breakSpace;
					Content += string.Concat(NextPeriode + conn.GetFieldValue(i, "NextPeriod"));
					Content += breakSpace;
					Content += br;
					Content += breakSpace;
				}
			}
			else if(type == EmailFormat.LaporanPendingIssue)
			{
				for (int i = 0; i < conn.GetRowCount(); i++) 
				{
					/*
					Nama Nasabah 	: 	 PT Semen Tonasa 
					Nama Bank 	: 	PT Bank Mandiri 
					Issue Type 	: 	Pengembalian Dokumen
					Target Date Penyelesaian	:	01-08-2012
					 * */

					Content += string.Concat(NamaNasabah + conn.GetFieldValue(i,"NamaNasabah"));
					Content += breakSpace;
					Content += string.Concat(NamaBank + conn.GetFieldValue(i,"NamaBank"));
					Content += breakSpace;
					Content += string.Concat(IssueType + conn.GetFieldValue(i,"IssueType"));
					Content += breakSpace;
					Content += string.Concat(TargetDatePenyelesaian + conn.GetFieldValue(i,"TargetDatePenyelesaian"));
					Content += breakSpace;
					Content += br;
					Content += breakSpace;
				}
			}

			string footer = "Pembina System IPS";
			footer += breakSpace;
			footer += "PT BANK MANDIRI (PERSERO) TBK.";
			footer += breakSpace;
			footer += "Policy, System and Procedure Group";
			footer += breakSpace;
			footer += "Business Process and System Reengineering Dept";
			footer += breakSpace;
			footer += "Plaza Mandiri";
			footer += breakSpace;
			footer += "Jl. Jend Gatot Subroto Kav 36-38 26th Floor";
			footer += breakSpace;
			footer += "Jakarta 12190";
			footer += breakSpace;
			footer += "TELEPHONE OFFICE | +62 21 524 5008";
			Content += breakSpace;
			Content += breakSpace;
			Content += footer;

			MyConnection.SendEmail(from, to, subject, Content);
		}
	}
}
