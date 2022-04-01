using System;
using Microsoft.VisualBasic;
using DMS.DBConnection;
using DMS.CuBESCore;

namespace SME.CreditAnalysis.BPR
{
	/// <summary>
	/// Summary description for HitRasioBPR.
	/// </summary>
	public class HitRasioBPR
	{
		public HitRasioBPR()
		{
			//
			// TODO: Add constructor logic here
			//
		}
		/*-----------------« start kamus »------------------------------------------------ */
		/*	
		Neraca BPR -> Lihat Excel template ada di Sheet LapKeu
			(BS=Neraca, IS=LabaRugi)	
					14!	Kas			
					15!	Sertifikat Bank Indonesia			
					16!	Antar bank Aktiva			
					17!	Kredit yang diberikan			
					18!	Penyisihan penghapusan aktiva produktif			
					20!	Aktiva dalam Valas			
					21!	Aktiva tetap dan Inventaris			
					22!	Antarkantor Aktiva			
					23!	Total Aktiva	

					28!	Kewajiban2 yang segera dapat dibayar			
					29!	Tabungan			
					30!	Deposito Berjangka			
					31!	Bank Indonesia (KMK)			
					32!	Antar bank Pasiva			
					33!	Pinjaman Subordinasi			
					34!	Pinjaman Lainnya (>3bulan)			
					35!	Antar kantor pasiva			
					36!	Rupa-rupa pasiva			
					37!	Modal disetor (modal dasar-belum disetor)			
					38!	Modal pinjaman/sumbangan			
					39!	Cadangan			
					40!	Laba Tahun Berjalan
					41!	Total Pasiva	
					
					Labarugi BPR -> Lihat Excel template ada di Sheet LapKeu	
					109!	1.1. Pendapatan bunga dari bank			
					110!	1.2. Pendapatan bunga dari pihak III bukan bank			
					111!	1.3. Provisi dan komisi			
					112!	Total Pendapatan operasional			

					114!	2.1. Biaya Bunga Kepada bank Indonesia			
					115!	2.2. Biaya bunga kepada bank lain			
					116!	2.3. Biaya bunga kepada pihak III bukan bank			
					117!	Total Beban Operasional			
					118!	Pendapatan Operasional Bersih			

					120!	3.1. Provisi dan komisi diterima bukan dari kredit			
					122!	3.3. Lain-lain			
					123!	Total Pendapatan operasional lainnya			

					125!	4.1. Biaya Umum dan Administrasi			
					126!	4.2. Biaya Tenaga kerja			
					127!	4.3. Biaya Pemeliharaan dan perbaikan			
					128!	4.4. Biaya Penyusutan/Penghapusan Aktiva Prod.			
					129!	4.5. Depresiasi dan amortisasi			
					130!	4.6. Lain-lain			
					131!	Total Biaya Operasional Lainnya			
					132!	Pendapatan Operasional lainnya bersih			
					133!	Laba Operasional			
					134!	Pendapatan & Biaya Non-Operasional (Netto)
					135!	Pendapatan Sebelum Pajak (E B I T)
					136!	Pajak Penghasilan
					137!	Pendapatan Bersih (EAT)
							
					140!	Saldo Kas Awal			
					141!	Deviden			
					143!	Laba ditahan akhir tahun 
		*/
		/*-----------------« end kamus »----------------------------------------------------*/
		public static bool proses_calculate(System.Web.UI.Page page, string curef, string regno, string tahun, Connection conn)
		{
			conn.QueryString = "SELECT CU_REF FROM BPR_NERACA WHERE CU_REF = '" + curef + "' AND AKTIVA_TOT <> PASIVA_TOT";
			conn.ExecuteQuery();

			if (conn.GetRowCount() > 0)
			{
				GlobalTools.popMessage(page,"Neraca belum balance !!");
				conn.QueryString = "DELETE FROM BPR_RASIO WHERE CU_REF = '" + curef + " ' and AP_REGNO = '" + regno + "'" ;
				conn.ExecuteNonQuery();

				return false;
			}
			
			if (!compare_BS_IS(page, curef, regno, conn))
			{
				//-- if rasio bpr exist, then delete ---//
				conn.QueryString = "DELETE FROM BPR_RASIO WHERE CU_REF = '" + curef + "' and ap_regno = '" + regno + "'";
				conn.ExecuteNonQuery();
				
				return false;
			}

			// var for rasio
			double dTotalAssets,dRiskWeightedAssets,dJumlahAktivaProduktif,dJumlahModal,dDanaPihakKetiga,		
				dBankIndonesia,dPinjamanLainnya,dRupapasiva,dKreditYangDiberikan,dPenyisihanpenghapusanaktivaproduktif,		
				dAntarbankAktiva,dKas,dFixedassets,dOthersAssets,dBorrowings,		
				dLoanToDeposit,dDanaMasythdTotalDeposit,dCurrentratio,		
				dROA,dReturnOnEquity,dLabaOperasional_TotAssets,dBeban_PendapatanOperasional,dFeeBasedIncomeToTotalIncome,		
				dOverheadCost_TotalAssets,dOperatingexpenses_netrevenue,dBiayadana,
				dModal_RiskAssetRatio,dNetworth_totalassets,		
				dNetInterestMargin,dNetinterestincome_quickriskassets,dProvisionChargeToTotalLoans,		
				dNonPerformingLoanToTotalLoan;

			// var for neraca
			double BS14, BS15, BS16, BS17, BS18, BS20, BS21, BS22, BS23, BS26,
				BS28, BS29, BS30, BS31, BS32, BS33, BS34, BS35, BS36,
				BS37, BS38, BS39, BS40, BS41,
				BS57=0.00, BS64=0.00, BS65=0.00;

			
			// var for labarugi
			double IS109, IS110, IS111, IS112,
				IS114, IS115, IS116, IS117, IS118,
				IS120, IS123, IS122, 
				IS125, IS126, IS127, IS128, IS129, IS130, IS131, IS132, IS133, IS134, IS135, IS136,
				IS137, IS140, IS141, IS143;

			// var for ATMR
			double C49 = 0.00, C50 = 0.00, C51 = 0.2, C52 = 1.00, C54 = 1.00, C55 = 1.00, C56 = 1.00; 
				
			conn.QueryString = "DELETE FROM BPR_RASIO WHERE CU_REF = '" + curef + "'";
			conn.ExecuteNonQuery();
		
			conn.QueryString = "SELECT CU_REF,AP_REGNO,POSISI_TGL,JML_BLN, JNS_LAP, AKTIVA_01,AKTIVA_02,AKTIVA_03,AKTIVA_04,AKTIVA_05,AKTIVA_06" +
				",AKTIVA_07,AKTIVA_08,AKTIVA_09,AKTIVA_TOT,PASIVA_01,PASIVA_02,PASIVA_03,PASIVA_04 " +
				",PASIVA_05,PASIVA_06,PASIVA_07,PASIVA_08,PASIVA_09,PASIVA_10,PASIVA_11,PASIVA_12 " +
				",PASIVA_13,PASIVA_TOT,IN_OPR_11,IN_OPR_12,IN_OPR_13,IN_OPR_TOT,EX_OPR_21,EX_OPR_22 " +
				",EX_OPR_23,EX_OPR_TOT,NET_OPR,IN_OTHER_OPR_31,IN_OTHER_OPR_32,IN_OTHER_OPR_33,IN_OTHER_OPR_TOT " +
				",EX_OTHER_OPR_41,EX_OTHER_OPR_42,EX_OTHER_OPR_43,EX_OTHER_OPR_44,EX_OTHER_OPR_45,EX_OTHER_OPR_46 " +
				",EX_OTHER_OPR_TOT,NET_OTHER_OPR,OPR_EARN,NET_NON_OPR,IN_BEFORE_TAX,IN_TAX,NET_INCOME,BALANCE " +
				",DEVIDEN,TOT_EARN,IS_PROYEKSI " + 
				" FROM VW_CA_HITUNG_RASIO_BPR WHERE CU_REF = '" + curef + "' AND AP_REGNO = '" + regno + "'AND YEAR(POSISI_TGL) <= '" + tahun + "' ORDER BY POSISI_TGL ASC";
			conn.ExecuteQuery();	
			
			System.Data.DataTable dtCurrent = new System.Data.DataTable();
			dtCurrent = conn.GetDataTable().Copy();

			for (int i=0;i<dtCurrent.Rows.Count;i++)
			{
				/*---« start assign var for neraca BPR »-------------*/
				if (Strings.Trim(dtCurrent.Rows[i]["AKTIVA_01"].ToString())=="" || dtCurrent.Rows[i]["AKTIVA_01"].ToString()==null)  
					BS14 = 0.0;
				else BS14 = Convert.ToDouble(dtCurrent.Rows[i]["AKTIVA_01"].ToString());

				if (Strings.Trim(dtCurrent.Rows[i]["AKTIVA_02"].ToString())=="" || dtCurrent.Rows[i]["AKTIVA_02"].ToString()==null)  
					BS15 = 0.0;
				else BS15 = Convert.ToDouble(dtCurrent.Rows[i]["AKTIVA_02"].ToString());
	
				if (Strings.Trim(dtCurrent.Rows[i]["AKTIVA_03"].ToString())=="" || dtCurrent.Rows[i]["AKTIVA_03"].ToString()==null)  
					BS16 = 0.0;
				else BS16 = Convert.ToDouble(dtCurrent.Rows[i]["AKTIVA_03"].ToString());

				if (Strings.Trim(dtCurrent.Rows[i]["AKTIVA_04"].ToString())=="" || dtCurrent.Rows[i]["AKTIVA_04"].ToString()==null)  
					BS17 = 0.0;
				else BS17 = Convert.ToDouble(dtCurrent.Rows[i]["AKTIVA_04"].ToString());

				if (Strings.Trim(dtCurrent.Rows[i]["AKTIVA_05"].ToString())=="" || dtCurrent.Rows[i]["AKTIVA_05"].ToString()==null)  
					BS18 = 0.0;
				else BS18 = Convert.ToDouble(dtCurrent.Rows[i]["AKTIVA_05"].ToString());

				if (Strings.Trim(dtCurrent.Rows[i]["AKTIVA_07"].ToString())=="" || dtCurrent.Rows[i]["AKTIVA_07"].ToString()==null)  
					BS20 = 0.0;
				else BS20 = Convert.ToDouble(dtCurrent.Rows[i]["AKTIVA_07"].ToString());

				if (Strings.Trim(dtCurrent.Rows[i]["AKTIVA_08"].ToString())=="" || dtCurrent.Rows[i]["AKTIVA_07"].ToString()==null)  
					BS21 = 0.0;
				else BS21 = Convert.ToDouble(dtCurrent.Rows[i]["AKTIVA_08"].ToString());

				if (Strings.Trim(dtCurrent.Rows[i]["AKTIVA_09"].ToString())=="" || dtCurrent.Rows[i]["AKTIVA_09"].ToString()==null)  
					BS22 = 0.0;
				else BS22 = Convert.ToDouble(dtCurrent.Rows[i]["AKTIVA_09"].ToString());

				if (Strings.Trim(dtCurrent.Rows[i]["AKTIVA_TOT"].ToString())=="" || dtCurrent.Rows[i]["AKTIVA_TOT"].ToString()==null)  
					BS23 = 0.0;
				else BS23 = Convert.ToDouble(dtCurrent.Rows[i]["AKTIVA_TOT"].ToString());

				//--« SEPARATOR »----

				if (Strings.Trim(dtCurrent.Rows[i]["PASIVA_01"].ToString())=="" || dtCurrent.Rows[i]["PASIVA_01"].ToString()==null)  
					BS28 = 0.0;
				else BS28 = Convert.ToDouble(dtCurrent.Rows[i]["PASIVA_01"].ToString());

				if (Strings.Trim(dtCurrent.Rows[i]["PASIVA_02"].ToString())=="" || dtCurrent.Rows[i]["PASIVA_02"].ToString()==null)  
					BS29 = 0.0;
				else BS29 = Convert.ToDouble(dtCurrent.Rows[i]["PASIVA_02"].ToString());

				if (Strings.Trim(dtCurrent.Rows[i]["PASIVA_03"].ToString())=="" || dtCurrent.Rows[i]["PASIVA_03"].ToString()==null)  
					BS30 = 0.0;
				else BS30 = Convert.ToDouble(dtCurrent.Rows[i]["PASIVA_03"].ToString());

				if (Strings.Trim(dtCurrent.Rows[i]["PASIVA_04"].ToString())=="" || dtCurrent.Rows[i]["PASIVA_04"].ToString()==null)  
					BS31 = 0.0;
				else BS31 = Convert.ToDouble(dtCurrent.Rows[i]["PASIVA_04"].ToString());

				if (Strings.Trim(dtCurrent.Rows[i]["PASIVA_05"].ToString())=="" || dtCurrent.Rows[i]["PASIVA_05"].ToString()==null)  
					BS32 = 0.0;
				else BS32 = Convert.ToDouble(dtCurrent.Rows[i]["PASIVA_05"].ToString());

				if (Strings.Trim(dtCurrent.Rows[i]["PASIVA_06"].ToString())=="" || dtCurrent.Rows[i]["PASIVA_06"].ToString()==null)  
					BS33 = 0.0;
				else BS33 = Convert.ToDouble(dtCurrent.Rows[i]["PASIVA_06"].ToString());

				if (Strings.Trim(dtCurrent.Rows[i]["PASIVA_07"].ToString())=="" || dtCurrent.Rows[i]["PASIVA_07"].ToString()==null)  
					BS34 = 0.0;
				else BS34 = Convert.ToDouble(dtCurrent.Rows[i]["PASIVA_07"].ToString());

				if (Strings.Trim(dtCurrent.Rows[i]["PASIVA_08"].ToString())=="" || dtCurrent.Rows[i]["PASIVA_08"].ToString()==null)  
					BS35 = 0.0;
				else BS35 = Convert.ToDouble(dtCurrent.Rows[i]["PASIVA_08"].ToString());

				if (Strings.Trim(dtCurrent.Rows[i]["PASIVA_09"].ToString())=="" || dtCurrent.Rows[i]["PASIVA_09"].ToString()==null)  
					BS36 = 0.0;
				else BS36 = Convert.ToDouble(dtCurrent.Rows[i]["PASIVA_09"].ToString());

				if (Strings.Trim(dtCurrent.Rows[i]["PASIVA_10"].ToString())=="" || dtCurrent.Rows[i]["PASIVA_10"].ToString()==null)  
					BS37 = 0.0;
				else BS37 = Convert.ToDouble(dtCurrent.Rows[i]["PASIVA_10"].ToString());

				if (Strings.Trim(dtCurrent.Rows[i]["PASIVA_11"].ToString())=="" || dtCurrent.Rows[i]["PASIVA_11"].ToString()==null)  
					BS38 = 0.0;
				else BS38 = Convert.ToDouble(dtCurrent.Rows[i]["PASIVA_11"].ToString());

				if (Strings.Trim(dtCurrent.Rows[i]["PASIVA_12"].ToString())=="" || dtCurrent.Rows[i]["PASIVA_12"].ToString()==null)  
					BS39 = 0.0;
				else BS39 = Convert.ToDouble(dtCurrent.Rows[i]["PASIVA_12"].ToString());

				if (Strings.Trim(dtCurrent.Rows[i]["PASIVA_13"].ToString())=="" || dtCurrent.Rows[i]["PASIVA_13"].ToString()==null)  
					BS40 = 0.0;
				else BS40 = Convert.ToDouble(dtCurrent.Rows[i]["PASIVA_13"].ToString());
	
				if (Strings.Trim(dtCurrent.Rows[i]["PASIVA_TOT"].ToString())=="" || dtCurrent.Rows[i]["PASIVA_TOT"].ToString()==null)  
					BS41 = 0.0;
				else BS41 = Convert.ToDouble(dtCurrent.Rows[i]["PASIVA_TOT"].ToString());	
				/*---« end assign var for neraca BPR »-------------*/	

				/*---« start assign var for labarugi BPR »------------------------ */
				if (Strings.Trim(dtCurrent.Rows[i]["IN_OPR_11"].ToString())=="" || dtCurrent.Rows[i]["IN_OPR_11"].ToString()==null)  
					IS109 = 0.0;
				else IS109 = Convert.ToDouble(dtCurrent.Rows[i]["IN_OPR_11"].ToString());

				if (Strings.Trim(dtCurrent.Rows[i]["IN_OPR_12"].ToString())=="" || dtCurrent.Rows[i]["IN_OPR_12"].ToString()==null)  
					IS110 = 0.0;
				else IS110 = Convert.ToDouble(dtCurrent.Rows[i]["IN_OPR_12"].ToString());

				if (Strings.Trim(dtCurrent.Rows[i]["IN_OPR_13"].ToString())=="" || dtCurrent.Rows[i]["IN_OPR_13"].ToString()==null)  
					IS111 = 0.0;
				else IS111 = Convert.ToDouble(dtCurrent.Rows[i]["IN_OPR_13"].ToString());

				if (Strings.Trim(dtCurrent.Rows[i]["IN_OPR_TOT"].ToString())=="" || dtCurrent.Rows[i]["IN_OPR_TOT"].ToString()==null)  
					IS112 = 0.0;
				else IS112 = Convert.ToDouble(dtCurrent.Rows[i]["IN_OPR_TOT"].ToString());

				//--« SEPARATOR »--//

				if (Strings.Trim(dtCurrent.Rows[i]["EX_OPR_21"].ToString())=="" || dtCurrent.Rows[i]["EX_OPR_21"].ToString()==null)  
					IS114 = 0.0;
				else IS114 = Convert.ToDouble(dtCurrent.Rows[i]["EX_OPR_21"].ToString());

				if (Strings.Trim(dtCurrent.Rows[i]["EX_OPR_22"].ToString())=="" || dtCurrent.Rows[i]["EX_OPR_22"].ToString()==null)  
					IS115 = 0.0;
				else IS115 = Convert.ToDouble(dtCurrent.Rows[i]["EX_OPR_22"].ToString());

				if (Strings.Trim(dtCurrent.Rows[i]["EX_OPR_23"].ToString())=="" || dtCurrent.Rows[i]["EX_OPR_23"].ToString()==null)  
					IS116 = 0.0;
				else IS116 = Convert.ToDouble(dtCurrent.Rows[i]["EX_OPR_23"].ToString());

				if (Strings.Trim(dtCurrent.Rows[i]["EX_OPR_TOT"].ToString())=="" || dtCurrent.Rows[i]["EX_OPR_TOT"].ToString()==null)  
					IS117 = 0.0;
				else IS117 = Convert.ToDouble(dtCurrent.Rows[i]["EX_OPR_TOT"].ToString());

				if (Strings.Trim(dtCurrent.Rows[i]["NET_OPR"].ToString())=="" || dtCurrent.Rows[i]["NET_OPR"].ToString()==null)  
					IS118 = 0.0;
				else IS118 = Convert.ToDouble(dtCurrent.Rows[i]["NET_OPR"].ToString());

				//--« SEPARATOR »--//

				if (Strings.Trim(dtCurrent.Rows[i]["IN_OTHER_OPR_31"].ToString())=="" || dtCurrent.Rows[i]["IN_OTHER_OPR_31"].ToString()==null)  
					IS120 = 0.0;
				else IS120 = Convert.ToDouble(dtCurrent.Rows[i]["IN_OTHER_OPR_31"].ToString());

				if (Strings.Trim(dtCurrent.Rows[i]["IN_OTHER_OPR_33"].ToString())=="" || dtCurrent.Rows[i]["IN_OTHER_OPR_33"].ToString()==null)  
					IS122 = 0.0;
				else IS122 = Convert.ToDouble(dtCurrent.Rows[i]["IN_OTHER_OPR_33"].ToString());

				if (Strings.Trim(dtCurrent.Rows[i]["IN_OTHER_OPR_TOT"].ToString())=="" || dtCurrent.Rows[i]["IN_OTHER_OPR_TOT"].ToString()==null)  
					IS123 = 0.0;
				else IS123 = Convert.ToDouble(dtCurrent.Rows[i]["IN_OTHER_OPR_TOT"].ToString());


				//--« SEPARATOR »--//

				if (Strings.Trim(dtCurrent.Rows[i]["EX_OTHER_OPR_41"].ToString())=="" || dtCurrent.Rows[i]["EX_OTHER_OPR_41"].ToString()==null)  
					IS125 = 0.0;
				else IS125 = Convert.ToDouble(dtCurrent.Rows[i]["EX_OTHER_OPR_41"].ToString());

				if (Strings.Trim(dtCurrent.Rows[i]["EX_OTHER_OPR_42"].ToString())=="" || dtCurrent.Rows[i]["EX_OTHER_OPR_42"].ToString()==null)  
					IS126 = 0.0;
				else IS126 = Convert.ToDouble(dtCurrent.Rows[i]["EX_OTHER_OPR_42"].ToString());

				if (Strings.Trim(dtCurrent.Rows[i]["EX_OTHER_OPR_43"].ToString())=="" || dtCurrent.Rows[i]["EX_OTHER_OPR_43"].ToString()==null)  
					IS127 = 0.0;
				else IS127 = Convert.ToDouble(dtCurrent.Rows[i]["EX_OTHER_OPR_43"].ToString());

				if (Strings.Trim(dtCurrent.Rows[i]["EX_OTHER_OPR_44"].ToString())=="" || dtCurrent.Rows[i]["EX_OTHER_OPR_44"].ToString()==null)  
					IS128 = 0.0;
				else IS128 = Convert.ToDouble(dtCurrent.Rows[i]["EX_OTHER_OPR_44"].ToString());

				if (Strings.Trim(dtCurrent.Rows[i]["EX_OTHER_OPR_45"].ToString())=="" || dtCurrent.Rows[i]["EX_OTHER_OPR_45"].ToString()==null)  
					IS129 = 0.0;
				else IS129 = Convert.ToDouble(dtCurrent.Rows[i]["EX_OTHER_OPR_45"].ToString());

				if (Strings.Trim(dtCurrent.Rows[i]["EX_OTHER_OPR_46"].ToString())=="" || dtCurrent.Rows[i]["EX_OTHER_OPR_46"].ToString()==null)  
					IS130 = 0.0;
				else IS130 = Convert.ToDouble(dtCurrent.Rows[i]["EX_OTHER_OPR_46"].ToString());

				if (Strings.Trim(dtCurrent.Rows[i]["EX_OTHER_OPR_TOT"].ToString())=="" || dtCurrent.Rows[i]["EX_OTHER_OPR_TOT"].ToString()==null)  
					IS131 = 0.0;
				else IS131 = Convert.ToDouble(dtCurrent.Rows[i]["EX_OTHER_OPR_TOT"].ToString());

				if (Strings.Trim(dtCurrent.Rows[i]["NET_OTHER_OPR"].ToString())=="" || dtCurrent.Rows[i]["NET_OTHER_OPR"].ToString()==null)  
					IS132 = 0.0;
				else IS132 = Convert.ToDouble(dtCurrent.Rows[i]["NET_OTHER_OPR"].ToString());

				if (Strings.Trim(dtCurrent.Rows[i]["OPR_EARN"].ToString())=="" || dtCurrent.Rows[i]["OPR_EARN"].ToString()==null)  
					IS133 = 0.0;
				else IS133 = Convert.ToDouble(dtCurrent.Rows[i]["OPR_EARN"].ToString());

				if (Strings.Trim(dtCurrent.Rows[i]["NET_NON_OPR"].ToString())=="" || dtCurrent.Rows[i]["NET_NON_OPR"].ToString()==null)  
					IS134 = 0.0;
				else IS134 = Convert.ToDouble(dtCurrent.Rows[i]["NET_NON_OPR"].ToString());

				if (Strings.Trim(dtCurrent.Rows[i]["IN_BEFORE_TAX"].ToString())=="" || dtCurrent.Rows[i]["IN_BEFORE_TAX"].ToString()==null)  
					IS135 = 0.0;
				else IS135 = Convert.ToDouble(dtCurrent.Rows[i]["IN_BEFORE_TAX"].ToString());

				if (Strings.Trim(dtCurrent.Rows[i]["IN_TAX"].ToString())=="" || dtCurrent.Rows[i]["IN_TAX"].ToString()==null)  
					IS136 = 0.0;
				else IS136 = Convert.ToDouble(dtCurrent.Rows[i]["IN_TAX"].ToString());

				if (Strings.Trim(dtCurrent.Rows[i]["NET_INCOME"].ToString())=="" || dtCurrent.Rows[i]["NET_INCOME"].ToString()==null)  
					IS137 = 0.0;
				else IS137 = Convert.ToDouble(dtCurrent.Rows[i]["NET_INCOME"].ToString());


				//--« SEPARATOR »--//

				if (Strings.Trim(dtCurrent.Rows[i]["BALANCE"].ToString())=="" || dtCurrent.Rows[i]["BALANCE"].ToString()==null)  
					IS140 = 0.0;
				else IS140 = Convert.ToDouble(dtCurrent.Rows[i]["BALANCE"].ToString());

				if (Strings.Trim(dtCurrent.Rows[i]["DEVIDEN"].ToString())=="" || dtCurrent.Rows[i]["DEVIDEN"].ToString()==null)  
					IS141 = 0.0;
				else IS141 = Convert.ToDouble(dtCurrent.Rows[i]["DEVIDEN"].ToString());

				if (Strings.Trim(dtCurrent.Rows[i]["TOT_EARN"].ToString())=="" || dtCurrent.Rows[i]["TOT_EARN"].ToString()==null)  
					IS143 = 0.0;
				else IS143 = Convert.ToDouble(dtCurrent.Rows[i]["TOT_EARN"].ToString());

				/*---« end assign var for labarugi BPR »------------------------ */	
				/*---« START RUMUS RASIO »-------------------------------------- */
				BS26 = BS14 + BS15 + BS16 + BS17 + BS18 + BS20 + BS21 + BS22 + BS23;

				//=Lap.Keu!H26
				dTotalAssets = BS14+BS15+BS16+BS17+BS18+BS20+BS21+BS22;
				
				//=+Lap.Keu!H59
				BS57 = (C49*BS14)+(C50*BS15)+(C51*BS16)+(C52*BS17)+(C54*BS20)+(C55*BS21)+(C56*BS22);
				dRiskWeightedAssets = BS57;

				dJumlahAktivaProduktif = BS16+BS17+BS18;

				BS64 = BS37+BS38+BS39+BS40;
				dJumlahModal = BS64;
			
				//=SUM(Lap.Keu!H28:H30)+Lap.Keu!H35+Lap.Keu!H31+Lap.Keu!H33+Lap.Keu!H34
				dDanaPihakKetiga = BS28+BS29+BS30+BS35+BS31+BS33+BS34;

				/* start hide */
				dBankIndonesia = BS31;

				dPinjamanLainnya = BS34;

				dRupapasiva = BS36;
				/* end hide */

				dKreditYangDiberikan = BS17;

				dPenyisihanpenghapusanaktivaproduktif = BS18;

				/* start hide */
				dAntarbankAktiva = BS16;

				dKas = BS14;

				dFixedassets = BS21;

				dOthersAssets = BS23;

				dBorrowings = BS32;		
				/* end hide */


				//=SUM(Lap.Keu!H16:H17)/(SUM(Lap.Keu!H28:H32)+Lap.Keu!H36+Lap.Keu!H65)
				BS65 = (BS37+BS38+BS39)+(BS40*0.5);
				if ((BS28+BS29+BS30+BS31+BS32+BS36+BS65) > 0.000001)
					dLoanToDeposit = (BS16+BS17) / (BS28+BS29+BS30+BS31+BS32+BS36+BS65);
				else
					dLoanToDeposit = 0.00;
				
				/* start hide */
				//=SUM(Lap.Keu!H31:H33)/(SUM(Lap.Keu!H31:H35)+Lap.Keu!H39+Lap.Keu!H67)
				if ( ((BS28+BS29+BS30+BS31+BS32)+BS36+BS65) > 0.000001)
					dDanaMasythdTotalDeposit = (BS28+BS29+BS30) / ((BS28+BS29+BS30+BS31+BS32)+BS36+BS65);
				else
					dDanaMasythdTotalDeposit = 0.00;
				/* end hide */

				//=+SUM(Lap.Keu!H14:H16)/SUM(Lap.Keu!H28:H30)
				if ( (BS28+BS29+BS30) > 0.000001 )
					dCurrentratio = (BS14+BS15+BS16) / (BS28+BS29+BS30);
				else
					dCurrentratio = 0.00;

				//=Lap.Keu!H135/Lap.Keu!H23
				if (BS23 > 0.000001)
					dROA = (IS133+IS134) / BS23;
				else
					dROA = 0.00;

				//=(Lap.Keu!H135*12/G5)/Lap.Keu!H64
				if (BS64 > 0.000001)
					dReturnOnEquity = (IS133+IS134)*12.0/Convert.ToDouble(dtCurrent.Rows[i]["JML_BLN"].ToString()) / BS64;
				else
					dReturnOnEquity = 0.00;

				//=(Lap.Keu!H133*12/G5)/Lap.Keu!H23
				if (BS23 > 0.000001)
					dLabaOperasional_TotAssets = (IS133 * 12/Convert.ToDouble(dtCurrent.Rows[i]["JML_BLN"].ToString())) / BS23;
				else
					dLabaOperasional_TotAssets = 0.00;

				//=(Lap.Keu!H117+Lap.Keu!H131)/(Lap.Keu!H112+Lap.Keu!H123)
				if ( (IS112+IS123) > 0.000001)
					dBeban_PendapatanOperasional = (IS117+IS131) / (IS112+IS123);
				else
					dBeban_PendapatanOperasional = 0.00;	
				
				
				//=(Lap.Keu!H111+Lap.Keu!H123)/(Lap.Keu!H112+Lap.Keu!H123+Lap.Keu!H134)
				if ((IS112+IS123+IS134) > 0.000001)
					dFeeBasedIncomeToTotalIncome = (IS111+IS123) / (IS112+IS123+IS134);
				else
					dFeeBasedIncomeToTotalIncome = 0.00;
			
				//=Lap.Keu!H131*12/G5/Lap.Keu!H23
				if (BS23 > 0.000001)
					dOverheadCost_TotalAssets = (IS131 * 12/Convert.ToDouble(dtCurrent.Rows[i]["JML_BLN"].ToString())) / BS23;
				else
					dOverheadCost_TotalAssets = 0.00;
	

				//=Lap.Keu!H131/(Lap.Keu!H118+Lap.Keu!H123)
				if ((IS118+IS123) > 0.000001)
					dOperatingexpenses_netrevenue = IS131/(IS118+IS123);
				else
					dOperatingexpenses_netrevenue = 0.00;

				
				//=Lap.Keu!H117*12/G5/(SUM(Lap.Keu!H28:H35))
				if ( (BS28+BS29+BS30+BS31+BS32+BS33+BS34+BS35) > 0.000001)
					dBiayadana = (IS117 * 12/Convert.ToDouble(dtCurrent.Rows[i]["JML_BLN"].ToString())) / (BS28+BS29+BS30+BS31+BS32+BS33+BS34+BS35);
				else
					dBiayadana = 0.00;

				//=G12/G10
				if ( dRiskWeightedAssets > 0.000001)
					dModal_RiskAssetRatio = dJumlahModal/dRiskWeightedAssets;
				else
					dModal_RiskAssetRatio = 0.00;

				//=+G12/G9
				if (dTotalAssets > 0.000001)
					dNetworth_totalassets = dJumlahModal/dTotalAssets;		
				else
					dNetworth_totalassets = 0.00;

				//=Lap.Keu!H118*12/G5/G11
				if (dJumlahAktivaProduktif > 0.000001)
					dNetInterestMargin = (IS118 * 12/Convert.ToDouble(dtCurrent.Rows[i]["JML_BLN"].ToString())) / dJumlahAktivaProduktif;
				else
					dNetInterestMargin = 0.00;

				//=(Lap.Keu!H118*12/G5)/SUM(Lap.Keu!H14:H18)
				if ((BS14+BS15+BS16+BS17+BS18) > 0.000001)
					dNetinterestincome_quickriskassets = (IS118 * 12/Convert.ToDouble(dtCurrent.Rows[i]["JML_BLN"].ToString())) / (BS14+BS15+BS16+BS17+BS18);
				else
					dNetinterestincome_quickriskassets = 0.00;

				//=-Lap.Keu!H18/Lap.Keu!H17
				if (BS17 > 0.000001)
					dProvisionChargeToTotalLoans = ((-1)* BS18)/BS17;		
				else	
					dProvisionChargeToTotalLoans = 0.00;

				//=+Lap.Keu!H98
				dNonPerformingLoanToTotalLoan = 0.00;

				/*---« END RUMUS RASIO »-------------------------------------- */
				string is_proyeksi;
				is_proyeksi = dtCurrent.Rows[i]["IS_PROYEKSI"].ToString();

				//-- INSERT INTO RATIO BPR --//
				conn.QueryString = "exec sp_bpr_rasio 'save','" + curef + "','" + regno + "','" + 
					Strings.Format(DateTime.Parse(dtCurrent.Rows[i]["POSISI_TGL"].ToString()),"yyyy-MM-dd") + "'," + 
					Convert.ToInt32(dtCurrent.Rows[i]["JML_BLN"].ToString()) + ",'" +
					dtCurrent.Rows[i]["JNS_LAP"].ToString() + "'," +
					GlobalTools.ConvertFloat(Convert.ToString(dTotalAssets)) + "," +
					GlobalTools.ConvertFloat(Convert.ToString(dRiskWeightedAssets)) + "," +
					GlobalTools.ConvertFloat(Convert.ToString(dJumlahAktivaProduktif)) + "," +
					GlobalTools.ConvertFloat(Convert.ToString(dJumlahModal)) + "," +
					GlobalTools.ConvertFloat(Convert.ToString(dDanaPihakKetiga)) + "," +		
					GlobalTools.ConvertFloat(Convert.ToString(dBankIndonesia)) + "," +
					GlobalTools.ConvertFloat(Convert.ToString(dPinjamanLainnya)) + "," +
					GlobalTools.ConvertFloat(Convert.ToString(dRupapasiva)) + "," +
					GlobalTools.ConvertFloat(Convert.ToString(dKreditYangDiberikan)) + "," +
					GlobalTools.ConvertFloat(Convert.ToString(dPenyisihanpenghapusanaktivaproduktif)) + "," +		
					GlobalTools.ConvertFloat(Convert.ToString(dAntarbankAktiva)) + "," +
					GlobalTools.ConvertFloat(Convert.ToString(dKas)) + "," +
					GlobalTools.ConvertFloat(Convert.ToString(dFixedassets)) + "," +
					GlobalTools.ConvertFloat(Convert.ToString(dOthersAssets)) + "," +
					GlobalTools.ConvertFloat(Convert.ToString(dBorrowings)) + "," +		
					GlobalTools.ConvertFloat(Convert.ToString(dLoanToDeposit)) + "," +
					GlobalTools.ConvertFloat(Convert.ToString(dDanaMasythdTotalDeposit)) + "," +
					GlobalTools.ConvertFloat(Convert.ToString(dCurrentratio)) + "," +		
					GlobalTools.ConvertFloat(Convert.ToString(dROA)) + "," +
					GlobalTools.ConvertFloat(Convert.ToString(dReturnOnEquity)) + "," +
					GlobalTools.ConvertFloat(Convert.ToString(dLabaOperasional_TotAssets)) + "," +
					GlobalTools.ConvertFloat(Convert.ToString(dBeban_PendapatanOperasional)) + "," +
					GlobalTools.ConvertFloat(Convert.ToString(dFeeBasedIncomeToTotalIncome)) + "," +		
					GlobalTools.ConvertFloat(Convert.ToString(dOverheadCost_TotalAssets)) + "," +
					GlobalTools.ConvertFloat(Convert.ToString(dOperatingexpenses_netrevenue)) + "," +
					GlobalTools.ConvertFloat(Convert.ToString(dBiayadana)) + "," +
					GlobalTools.ConvertFloat(Convert.ToString(dModal_RiskAssetRatio)) + "," +
					GlobalTools.ConvertFloat(Convert.ToString(dNetworth_totalassets)) + "," +		
					GlobalTools.ConvertFloat(Convert.ToString(dNetInterestMargin)) + "," +
					GlobalTools.ConvertFloat(Convert.ToString(dNetinterestincome_quickriskassets)) + "," +
					GlobalTools.ConvertFloat(Convert.ToString(dProvisionChargeToTotalLoans)) + "," +
					GlobalTools.ConvertFloat(Convert.ToString(dNonPerformingLoanToTotalLoan)) + ",'" +
					is_proyeksi + "'";
				conn.ExecuteNonQuery();
			}

			return true;
		}

		public static bool compare_BS_IS(System.Web.UI.Page page, string curef, string regno, Connection conn)
		{
			conn.QueryString = "select year(posisi_tgl) tahun from bpr_neraca " +
				"where cu_ref = '" + curef + "' and ap_regno = '" + regno + "'";
			conn.ExecuteQuery();
			int row_neraca = conn.GetRowCount();

			conn.QueryString = "select year(posisi_tgl) tahun from bpr_labarugi " +
				"where cu_ref = '" + curef + "' and ap_regno = '" + regno + "'";
			conn.ExecuteQuery();
			int row_labarugi = conn.GetRowCount();

			conn.QueryString = "select n.cu_ref , n.ap_regno, year(n.posisi_tgl) , year(l.posisi_tgl) " +
				"from bpr_neraca n inner join bpr_labarugi l on l.cu_ref = n.cu_ref and n.ap_regno = l.ap_regno " +
				"and year(l.posisi_tgl) = year(n.posisi_tgl) and l.jml_bln = n.jml_bln " +
				"where n.cu_ref = '" + curef + "' and n.ap_regno = '" + regno + "'";
			conn.ExecuteQuery();
			int row = conn.GetRowCount();
			
			if (row_neraca != row_labarugi)
			{
				GlobalTools.popMessage(page,"Ratio tidak bisa di hitung karena periode tahun pada labarugi dan neraca tidak sama!");				
				return false;
			}
			else
			{
				if (row == row_neraca) return true;
				else
				{
					GlobalTools.popMessage(page,"Ratio tidak bisa di hitung karena periode tahun pada labarugi dan neraca tidak sama!");				
					return false;
				}
			}
		}
	}
}
