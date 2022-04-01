<%@ Page language="c#" Codebehind="PreScoringNeracaRL.aspx.cs" AutoEventWireup="True" Inherits="SME.InitialDataEntry.PreScoringNeracaRL" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>Neraca</title> 
		<!-- #include file="../include/cek_entries.html" -->
		<!-- include file="../include/cek_all.html" -->
		<!-- #include file="../include/popup.html" -->
		<script language="javascript">	
		function valid_scoringNeracaRL()
		{
			if(
				(document.Form1.DDL_AUDITED.value == "")||
				(document.Form1.DDL_POSISITGL_MM.value == "")||
				(document.Form1.TXT_PSN_KASBANK.value == "")||
				(document.Form1.TXT_PSN_PIUTANGDAGANG.value == "")||
				(document.Form1.TXT_PSN_PERSEDIAAN.value == "")||
				(document.Form1.TXT_PSN_TTLAKTIVALCR.value == "")||
				(document.Form1.TXT_PSN_TNHBGN.value == "")||
				(document.Form1.TXT_PSN_MSNPRLTN.value == "")||
				(document.Form1.TXT_PSN_INVKNDRN.value == "")||
				(document.Form1.TXT_PSN_AKTIVATTPLAIN.value == "")||
				(document.Form1.TXT_PSN_AKUMSUSUT.value == "")||
				(document.Form1.TXT_PSN_NETAKTIVATTP.value == "")||
				(document.Form1.TXT_PSN_BIAYADITANGGUHKAN.value == "")||
				(document.Form1.TXT_PSN_AKUMAMORTISASI.value == "")||
				(document.Form1.TXT_PSN_AKTIVALAIN.value == "")||
				(document.Form1.TXT_PSN_TTLAKTIVALAIN.value == "")||
				(document.Form1.TXT_PSN_TTLAKTIVA.value == "")||
				(document.Form1.TXT_PSRL_PENJUALANTAHUNAN.value == "")||
				(document.Form1.TXT_PSRL_HPP.value == "")||
				(document.Form1.TXT_PSRL_BIAYAUMUMADM.value == "")||
				(document.Form1.TXT_PSRL_LABAOPERASI.value == "")||
				(document.Form1.TXT_PSRL_BIAYABUNGA.value == "")||
				(document.Form1.TXT_PSRL_BIAYAPENYUSUTAN.value == "")||
				(document.Form1.TXT_JMLBLN.value == "")||
				(document.Form1.TXT_SALESONCREDIT.value == "")||
				(document.Form1.TXT_PSRL_BIAYALAIN.value == "")||
				(document.Form1.TXT_HUTBANK.value == "")||
				(document.Form1.TXT_HUTDAGANG.value == "")||
				(document.Form1.TXT_KI12BLN.value == "")||
				(document.Form1.TXT_HUTLANCARLAIN.value == "")||
				(document.Form1.TXT_TOTHUTLANCAR.value == "")||
				(document.Form1.TXT_HUTPS.value == "")||
				(document.Form1.TXT_HUTJKPJG.value == "")||
				(document.Form1.TXT_HUTPJGLAIN.value == "")||
				(document.Form1.TXT_TOTHUTJKPJG.value == "")||
				(document.Form1.TXT_HUTANG.value == "")||
				(document.Form1.TXT_MODALDISETOR.value == "")||
				(document.Form1.TXT_LABADITAHAN.value == "")||
				(document.Form1.TXT_TOTMODAL.value == "")||
				(document.Form1.TXT_TOTPASIVA.value == "")||
				(document.Form1.TXT_PEND_LAIN.value == "")||
				(document.Form1.TXT_LABASBLMPAJAK.value == "")||
				(document.Form1.TXT_PAJAK.value == "")||
				(document.Form1.TXT_LABABERSIH.value == "")||
				(document.Form1.TXT_PSN_AKTIVALCRLAIN.value == "")||
				(document.Form1.TXT_POSISITGL_DD.value == "")||
				(document.Form1.TXT_POSISITGL_YY.value == "")
			  )
			{
				alert("Kolom Tidak boleh mengandung nilai null\nSilakan anda melengkapi data nya.");
				return false;
			}	
			return true;	
		}	
		
		</script>
		<script language="vbscript">

		function Hitung()


		    setlocale("in")
			set obj = document.Form1

			if isnumeric(obj.TXT_PSN_KASBANK.value) then
				KASBANK = cdbl(obj.TXT_PSN_KASBANK.value)
			else
				KASBANK = 0
			end if
		
			
			if isnumeric(obj.TXT_PSN_PIUTANGDAGANG.value) then
				PIUTANGDAGANG = cdbl(obj.TXT_PSN_PIUTANGDAGANG.value)
			else
				PIUTANGDAGANG = 0
			end if
			
			if isnumeric(obj.TXT_PSN_PERSEDIAAN.value) then
				PERSEDIAAN = cdbl(obj.TXT_PSN_PERSEDIAAN.value)
			else
				PERSEDIAAN = 0
			end if


			if isnumeric(obj.TXT_PSN_AKTIVALCRLAIN.value) then
				AKTIVALCRLAIN = cdbl(obj.TXT_PSN_AKTIVALCRLAIN.value)
			else
				AKTIVALCRLAIN = 0
			end if

			TTLAKTIVALCR2 = KASBANK+PIUTANGDAGANG+PERSEDIAAN+AKTIVALCRLAIN
			TTLAKTIVALCR = FormatNumber(TTLAKTIVALCR2,0)
			obj.TXT_PSN_TTLAKTIVALCR.value = TTLAKTIVALCR


			if isnumeric(obj.TXT_PSN_TNHBGN.value) then
				 TNHBGN= cdbl(obj.TXT_PSN_TNHBGN.value)
			else
				 TNHBGN= 0
			end if
			
			if isnumeric(obj.TXT_PSN_MSNPRLTN.value) then
				MSNPRLTN = cdbl(obj.TXT_PSN_MSNPRLTN.value)
			else
				MSNPRLTN = 0
			end if

			if isnumeric(obj.TXT_PSN_INVKNDRN.value) then
				INVKNDRN = cdbl(obj.TXT_PSN_INVKNDRN.value)
			else
				INVKNDRN = 0
			end if

			if isnumeric(obj.TXT_PSN_AKTIVATTPLAIN.value) then
				AKTIVATTPLAIN = cdbl(obj.TXT_PSN_AKTIVATTPLAIN.value)
			else
				 AKTIVATTPLAIN= 0
			end if

			if isnumeric(obj.TXT_PSN_AKUMSUSUT.value) then
				 AKUMSUSUT= cdbl(obj.TXT_PSN_AKUMSUSUT.value)
			else
				 AKUMSUSUT= 0
			end if
				 
				 
			NETAKTIVATTP2 = TNHBGN+MSNPRLTN+INVKNDRN+AKTIVATTPLAIN-AKUMSUSUT
			NETAKTIVATTP = FormatNumber(NETAKTIVATTP2,0)
			obj.TXT_PSN_NETAKTIVATTP.value = NETAKTIVATTP


			if isnumeric(obj.TXT_PSN_BIAYADITANGGUHKAN.value) then
				 BIAYADITANGGUHKAN= cdbl(obj.TXT_PSN_BIAYADITANGGUHKAN.value)
			else
				 BIAYADITANGGUHKAN= 0
			end if
			
			if isnumeric(obj.TXT_PSN_AKUMAMORTISASI.value) then
				AKUMAMORTISASI = cdbl(obj.TXT_PSN_AKUMAMORTISASI.value)
			else
				AKUMAMORTISASI = 0
			end if

			if isnumeric(obj.TXT_PSN_AKTIVALAIN.value) then
				AKTIVALAIN = cdbl(obj.TXT_PSN_AKTIVALAIN.value)
			else
				AKTIVALAIN = 0
			end if


			TTLAKTIVALAIN2 = BIAYADITANGGUHKAN-AKUMAMORTISASI+AKTIVALAIN
			TTLAKTIVALAIN = FormatNumber(TTLAKTIVALAIN2,0)
			obj.TXT_PSN_TTLAKTIVALAIN.value = TTLAKTIVALAIN 
			
			TTLAKTIVA =  TTLAKTIVALCR2 + NETAKTIVATTP2 + TTLAKTIVALAIN2
			TTLAKTIVA = FormatNumber(TTLAKTIVA,0)
			obj.TXT_PSN_TTLAKTIVA.value =  TTLAKTIVA



			if isnumeric(obj.TXT_HUTDAGANG.value) then
				HUTDAGANG = cdbl(obj.TXT_HUTDAGANG.value)
			else
				HUTDAGANG = 0
			end if


			if isnumeric(obj.TXT_HUTBANK.value) then
				HUTBANK = cdbl(obj.TXT_HUTBANK.value)
			else
				HUTBANK = 0
			end if


			if isnumeric(obj.TXT_KI12BLN.value) then
				KI12BLN = cdbl(obj.TXT_KI12BLN.value)
			else
				KI12BLN = 0
			end if


			if isnumeric(obj.TXT_HUTLANCARLAIN.value) then
				HUTLANCARLAIN = cdbl(obj.TXT_HUTLANCARLAIN.value)
			else
				HUTLANCARLAIN = 0
			end if


			TOTHUTLANCAR2 = HUTDAGANG+HUTBANK+KI12BLN+HUTLANCARLAIN
			TOTHUTLANCAR = FormatNumber(TOTHUTLANCAR2,0)
			obj.TXT_TOTHUTLANCAR.value = TOTHUTLANCAR 




			if isnumeric(obj.TXT_HUTJKPJG.value) then
				HUTJKPJG = cdbl(obj.TXT_HUTJKPJG.value)
			else
				HUTJKPJG = 0
			end if


			if isnumeric(obj.TXT_HUTPS.value) then
				HUTPS = cdbl(obj.TXT_HUTPS.value)
			else
				HUTPS = 0
			end if

			if isnumeric(obj.TXT_HUTPJGLAIN.value) then
				HUTPJGLAIN = cdbl(obj.TXT_HUTPJGLAIN.value)
			else
				HUTPJGLAIN = 0
			end if

			TOTHUTJKPJG2 = HUTJKPJG+HUTPS+HUTPJGLAIN
			TOTHUTJKPJG = FormatNumber(TOTHUTJKPJG2,0)
			obj.TXT_TOTHUTJKPJG.value = TOTHUTJKPJG 


			HUTANG2 = TOTHUTJKPJG2+TOTHUTLANCAR2
			HUTANG = FormatNumber(HUTANG2,0)
			obj.TXT_HUTANG.value = HUTANG 



			if isnumeric(obj.TXT_MODALDISETOR.value) then
				MODALDISETOR = cdbl(obj.TXT_MODALDISETOR.value)
			else
				MODALDISETOR = 0
			end if

			if isnumeric(obj.TXT_LABADITAHAN.value) then
				LABADITAHAN = cdbl(obj.TXT_LABADITAHAN.value)
			else
				LABADITAHAN = 0
			end if
			
			if isnumeric(obj.TXT_LABABERJALAN.value) then
				LABABERJALAN = cdbl(obj.TXT_LABABERJALAN.value)
			else
				LABABERJALAN = 0
			end if
			
			TOTMODAL2 = MODALDISETOR+LABADITAHAN+LABABERJALAN
			TOTMODAL = FormatNumber(TOTMODAL2,0)
			obj.TXT_TOTMODAL.value = TOTMODAL 




			TOTPASIVA2 = HUTANG2+TOTMODAL2
			TOTPASIVA = FormatNumber(TOTPASIVA2,0)
			obj.TXT_TOTPASIVA.value = TOTPASIVA 



			if isnumeric(obj.TXT_PSRL_PENJUALANTAHUNAN.value) then
				PENJUALANTAHUNAN = cdbl(obj.TXT_PSRL_PENJUALANTAHUNAN.value)
			else
				PENJUALANTAHUNAN = 0
			end if

			if isnumeric(obj.TXT_PSRL_HPP.value) then
				HPP = cdbl(obj.TXT_PSRL_HPP.value)
			else
				HPP = 0
			end if

			if isnumeric(obj.TXT_PSRL_BIAYAUMUMADM.value) then
				BIAYAUMUMADM = cdbl(obj.TXT_PSRL_BIAYAUMUMADM.value)
			else
				BIAYAUMUMADM = 0
			end if


			LABAOPERASI2 = PENJUALANTAHUNAN-HPP-BIAYAUMUMADM
			LABAOPERASI = FormatNumber(LABAOPERASI2,0)
			obj.TXT_PSRL_LABAOPERASI.value = LABAOPERASI 





			if isnumeric(obj.TXT_PSRL_LABAOPERASI.value) then
				LABAOPERASI = cdbl(obj.TXT_PSRL_LABAOPERASI.value)
			else
				LABAOPERASI = 0
			end if

			if isnumeric(obj.TXT_PSRL_BIAYABUNGA.value) then
				BIAYABUNGA = cdbl(obj.TXT_PSRL_BIAYABUNGA.value)
			else
				BIAYABUNGA = 0
			end if

			if isnumeric(obj.TXT_PSRL_BIAYAPENYUSUTAN.value) then
				BIAYAPENYUSUTAN = cdbl(obj.TXT_PSRL_BIAYAPENYUSUTAN.value)
			else
				BIAYAPENYUSUTAN = 0
			end if


			if isnumeric(obj.TXT_PSRL_BIAYALAIN.value) then
				BIAYALAIN = cdbl(obj.TXT_PSRL_BIAYALAIN.value)
			else
				BIAYALAIN = 0
			end if


			if isnumeric(obj.TXT_PEND_LAIN.value) then
				PEND_LAIN = cdbl(obj.TXT_PEND_LAIN.value)
			else
				PEND_LAIN = 0
			end if


			if isnumeric(obj.TXT_LABASBLMPAJAK.value) then
				LABASBLMPAJAK = cdbl(obj.TXT_LABASBLMPAJAK.value)
			else
				LABASBLMPAJAK = 0
			end if

			LABASBLMPAJAK2 = LABAOPERASI2-BIAYABUNGA-BIAYAPENYUSUTAN-BIAYALAIN+PEND_LAIN
			LABASBLMPAJAK = FormatNumber(LABASBLMPAJAK2,0)
			obj.TXT_LABASBLMPAJAK.value = LABASBLMPAJAK 


			if isnumeric(obj.TXT_LABASBLMPAJAK.value) then
				LABASBLMPAJAK = cdbl(obj.TXT_LABASBLMPAJAK.value)
			else
				LABASBLMPAJAK = 0
			end if


			if isnumeric(obj.TXT_PAJAK.value) then
				PAJAK = cdbl(obj.TXT_PAJAK.value)
			else
				PAJAK = 0
			end if

			if isnumeric(obj.TXT_LABABERSIH.value) then
				LABABERSIH = cdbl(obj.TXT_LABABERSIH.value)
			else
				LABABERSIH = 0
			end if


			LABABERSIH2 = LABASBLMPAJAK2-PAJAK
			LABABERSIH = FormatNumber(LABABERSIH2,0)
			obj.TXT_LABABERSIH.value = LABABERSIH 





		end function
		
		

		
		'function FormatCurrency(edit)
		'	SetLocale("in")
		'	value = edit.value
		'	value = replace(value, ".", "")
		'	value = replace(value, ",", ".")
		'	if isnumeric(value) then
		'		edit.value = formatnumber(value,0)
		'	else	edit.value = ""
		'	end if
		'	edit.style.textAlign = "right"
		'end function
		
		function RestoreCurrency(edit)
			value = edit.value
			value = replace(value, ".", "")
			value = replace(value, ",", ".")
			if isnumeric(value) then
				edit.value = eval(value)
				edit.select
			else	edit.value = ""
			end if
			edit.style.textAlign = "left"
		end function
		function EnsureNumber(edit)
			value = edit.value
			value = replace(value, ".", "")
			value = replace(value, ",", ".")
			if not isnumeric(value) then
				edit.value = ""
			end if
		end function
		</script>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../style.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body leftMargin="0" topMargin="0" onload="Hitung()" MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<center>
				<TABLE id="Table1" style="HEIGHT: 1142px" cellSpacing="2" cellPadding="2" width="100%">
					<TBODY>
						<!-- ************************* separator *************------------------------------------------------------------------------------------------------------------------------------------------->
						<!-- ************************* separator *************------------------------------------------------------------------------------------------------------------------------------------------->
						<!-- ************************* separator *************------------------------------------------------------------------------------------------------------------------------------------------->
						<!-- ************************* separator *************------------------------------------------------------------------------------------------------------------------------------------------->
						<!--  separator ------------------------------------------------------------------------------------------------------------------------------------------>
						<TR>
							<td class="tdNoBorder" align="center" colSpan="2">
								<TABLE id="Table4" cellSpacing="0" cellPadding="0" width="100%" border="1">
									<TR>
										<TD class="tdHeader1" align="center" width="100%" colSpan="2">Input Data Pre 
											Scoring Neraca dan Rugi Laba (dalam ribuan) <input id="temp1" type="hidden" runat="server" name="temp1">
										</TD>
									</TR>
								</TABLE>
								<TABLE id="Table5" cellSpacing="0" cellPadding="0" width="100%" border="0">
									<TR>
										<TD class="TDBGColor1" style="WIDTH: 225px; HEIGHT: 23px"><STRONG>Posisi Tanggal</STRONG></TD>
										<TD style="WIDTH: 9px; HEIGHT: 23px"></TD>
										<TD style="WIDTH: 148px; HEIGHT: 23px" colSpan="4"><P><nobr>
													<asp:textbox id="TXT_POSISITGL_DD" tabIndex="1" runat="server" Columns="1" Width="30px" MaxLength="2"
														onkeypress="return digitsonly()"></asp:textbox>
													<asp:dropdownlist id="DDL_POSISITGL_MM" tabIndex="2" runat="server" Width="144px"></asp:dropdownlist>
													<asp:textbox id="TXT_POSISITGL_YY" tabIndex="3" runat="server" Width="48px" MaxLength="4" onkeypress="return digitsonly()"></asp:textbox>
												</nobr>
											</P>
										</TD>
									</TR>
									<TR>
										<TD class="TDBGColor1" style="WIDTH: 225px; HEIGHT: 22px"><STRONG>Jumlah Bulan</STRONG></TD>
										<TD style="WIDTH: 9px; HEIGHT: 22px"></TD>
										<TD style="WIDTH: 148px; HEIGHT: 22px" colSpan="4">
											<asp:textbox id="TXT_JMLBLN" tabIndex="4" runat="server" Width="46px" MaxLength="2" ReadOnly="True"
												onkeypress="return numbersonly()"></asp:textbox>
										</TD>
									</TR>
									<TR>
										<TD class="TDBGColor1" style="WIDTH: 225px; HEIGHT: 22px"><STRONG>Jenis Laporan</STRONG></TD>
										<TD style="WIDTH: 9px; HEIGHT: 22px"></TD>
										<TD style="WIDTH: 148px; HEIGHT: 22px" colSpan="4"><asp:dropdownlist id="DDL_AUDITED" tabIndex="5" runat="server" Width="118px">
												<asp:ListItem Value="Audited">Audited</asp:ListItem>
												<asp:ListItem Value="Un-Audited">Un-Audited</asp:ListItem>
											</asp:dropdownlist></TD>
									</TR>
									<TR>
										<TD class="TDBGColor1" style="WIDTH: 225px; HEIGHT: 21px"><STRONG>Sales On Credit %</STRONG></TD>
										<TD style="WIDTH: 9px; HEIGHT: 21px"></TD>
										<TD style="WIDTH: 148px; HEIGHT: 21px" colSpan="4">
											<asp:textbox id="TXT_SALESONCREDIT" tabIndex="6" runat="server" MaxLength="3" onkeypress="return numbersonly()"></asp:textbox>
										</TD>
									</TR>
								</TABLE>
								<TABLE id="Table2" cellSpacing="0" cellPadding="0" width="100%" border="1">
									<TR>
										<TD align="center" width="100%" colSpan="2"></TD>
									</TR>
									<TR>
										<TD class="tdHeader1" align="center" width="100%" colSpan="2">Neraca (Rp.000,-)</TD>
									</TR>
									<TR>
										<TD>
											<TABLE id="Table6" cellSpacing="0" cellPadding="0" width="100%" border="0">
												<TR>
													<TD class="TDBGColor1" style="HEIGHT: 25px"><STRONG>Aktiva Lancar</STRONG></TD>
													<TD style="WIDTH: 9px; HEIGHT: 25px"></TD>
													<TD style="WIDTH: 221px" width="221">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</TD>
													<TD class="TDBGColor1" style="HEIGHT: 25px"><STRONG>Hutang Lancar</STRONG></TD>
													<TD style="WIDTH: 13px; HEIGHT: 25px"></TD>
													<TD width="25%"></TD>
												</TR>
												<TR>
													<TD class="TDBGColor1">
														<P>Kas dan Bank</P>
													</TD>
													<TD style="WIDTH: 9px"></TD>
													<TD style="WIDTH: 221px; HEIGHT: 23px">
														<asp:textbox id="TXT_PSN_KASBANK" onblur="FormatCurrency(this);Hitung();" style="TEXT-ALIGN: right"
															tabIndex="7" runat="server" MaxLength="12" onkeypress="return numbersonly()"></asp:textbox>
													</TD>
													<TD class="TDBGColor1" style="HEIGHT: 23px" width="30%">Hutang Dagang</TD>
													<TD style="WIDTH: 13px"></TD>
													<TD width="20%">
														<asp:textbox id="TXT_HUTDAGANG" onblur="FormatCurrency(this),Hitung()" style="TEXT-ALIGN: right"
															onkeypress="return numbersonly()" tabIndex="19" runat="server" MaxLength="12"></asp:textbox></TD>
												</TR>
												<TR>
													<TD class="TDBGColor1" style="HEIGHT: 23px">Piutang Dagang</TD>
													<TD style="WIDTH: 9px; HEIGHT: 25px"></TD>
													<TD style="WIDTH: 221px">
														<asp:textbox id="TXT_PSN_PIUTANGDAGANG" onblur="FormatCurrency(this),Hitung()" style="TEXT-ALIGN: right"
															onkeypress="return numbersonly()" tabIndex="8" runat="server" MaxLength="12"></asp:textbox></TD>
													<TD class="TDBGColor1">Hutang Bank</TD>
													<TD style="WIDTH: 13px"></TD>
													<TD>
														<asp:textbox id="TXT_HUTBANK" onblur="FormatCurrency(this),Hitung()" style="TEXT-ALIGN: right"
															onkeypress="return numbersonly()" tabIndex="20" runat="server" MaxLength="12"></asp:textbox></TD>
												</TR>
												<TR>
													<TD class="TDBGColor1" style="HEIGHT: 23px" width="30%">Persediaan</TD>
													<TD style="WIDTH: 9px; HEIGHT: 20px"></TD>
													<TD style="WIDTH: 221px; HEIGHT: 20px">
														<asp:textbox id="TXT_PSN_PERSEDIAAN" onblur="FormatCurrency(this),Hitung()" style="TEXT-ALIGN: right"
															onkeypress="return numbersonly()" tabIndex="9" runat="server" MaxLength="12"></asp:textbox></TD>
													<TD class="TDBGColor1" style="HEIGHT: 20px">Bagian KI Jatuh Tempo 12 Bulan</TD>
													<TD style="WIDTH: 13px; HEIGHT: 20px"></TD>
													<TD style="HEIGHT: 20px">
														<asp:textbox id="TXT_KI12BLN" onblur="FormatCurrency(this),Hitung()" style="TEXT-ALIGN: right"
															onkeypress="return numbersonly()" tabIndex="21" runat="server" MaxLength="12"></asp:textbox></TD>
												</TR>
												<TR>
													<TD class="TDBGColor1">Aktiva Lancar Lainnya</TD>
													<TD style="WIDTH: 9px"></TD>
													<TD style="WIDTH: 221px">
														<asp:textbox id="TXT_PSN_AKTIVALCRLAIN" onblur="FormatCurrency(this),Hitung()" style="TEXT-ALIGN: right"
															onkeypress="return numbersonly()" tabIndex="10" runat="server" MaxLength="12"></asp:textbox></TD>
													<TD class="TDBGColor1">Hutang Lancar Lainnya</TD>
													<TD style="WIDTH: 13px"></TD>
													<TD>
														<asp:textbox id="TXT_HUTLANCARLAIN" onblur="FormatCurrency(this),Hitung()" style="TEXT-ALIGN: right"
															onkeypress="return numbersonly()" tabIndex="22" runat="server" MaxLength="12"></asp:textbox></TD>
												</TR>
												<TR>
													<TD class="TDBGColor1">Total Aktiva Lancar</TD>
													<TD style="WIDTH: 9px"><STRONG></STRONG></TD>
													<TD style="WIDTH: 221px">
														<asp:textbox id="TXT_PSN_TTLAKTIVALCR" onblur="FormatCurrency(this),Hitung()" style="TEXT-ALIGN: right"
															onkeypress="return numbersonly()" tabIndex="10" runat="server" MaxLength="12" ReadOnly="True"
															BackColor="Gainsboro"></asp:textbox></TD>
													<TD class="TDBGColor1">Total Hutang Lancar</TD>
													<TD style="WIDTH: 13px">&nbsp;</TD>
													<TD>
														<asp:textbox id="TXT_TOTHUTLANCAR" onblur="FormatCurrency(this),Hitung()" style="TEXT-ALIGN: right"
															runat="server" MaxLength="12" BackColor="Gainsboro" readonly></asp:textbox></TD>
												</TR>
												<TR>
													<TD class="TDBGColor1"><STRONG>Aktiva Tetap</STRONG></TD>
													<TD style="WIDTH: 9px"><STRONG></STRONG></TD>
													<TD style="WIDTH: 221px"></TD>
													<TD class="TDBGColor1"><STRONG>Hutang Jangka Panjang</STRONG></TD>
													<TD style="WIDTH: 13px">&nbsp;</TD>
													<TD></TD>
												</TR>
												<TR>
													<TD class="TDBGColor1">Tanah dan Bangunan</TD>
													<TD style="WIDTH: 9px"></TD>
													<TD style="WIDTH: 221px">
														<asp:textbox id="TXT_PSN_TNHBGN" onblur="FormatCurrency(this),Hitung()" style="TEXT-ALIGN: right"
															onkeypress="return numbersonly()" tabIndex="11" runat="server" MaxLength="12"></asp:textbox></TD>
													<TD class="TDBGColor1">Hutang Jangka Panjang</TD>
													<TD style="WIDTH: 13px"></TD>
													<TD>
														<asp:textbox id="TXT_HUTJKPJG" onblur="FormatCurrency(this),Hitung()" style="TEXT-ALIGN: right"
															onkeypress="return numbersonly()" tabIndex="23" runat="server" MaxLength="12"></asp:textbox></TD>
												</TR>
												<TR>
													<TD class="TDBGColor1">Mesin dan Peralatan</TD>
													<TD style="WIDTH: 9px"></TD>
													<TD style="WIDTH: 221px">
														<asp:textbox id="TXT_PSN_MSNPRLTN" onblur="FormatCurrency(this),Hitung()" style="TEXT-ALIGN: right"
															onkeypress="return numbersonly()" tabIndex="12" runat="server" MaxLength="12"></asp:textbox></TD>
													<TD class="TDBGColor1">Hutang Pemegang Saham</TD>
													<TD style="WIDTH: 13px"></TD>
													<TD>
														<asp:textbox id="TXT_HUTPS" onblur="FormatCurrency(this),Hitung()" style="TEXT-ALIGN: right"
															onkeypress="return numbersonly()" tabIndex="24" runat="server" MaxLength="12"></asp:textbox></TD>
												</TR>
												<TR>
													<TD class="TDBGColor1">Inventaris dan Kendaraan</TD>
													<TD style="WIDTH: 9px"></TD>
													<TD style="WIDTH: 221px">
														<asp:textbox id="TXT_PSN_INVKNDRN" onblur="FormatCurrency(this),Hitung()" style="TEXT-ALIGN: right"
															onkeypress="return numbersonly()" tabIndex="13" runat="server" MaxLength="12"></asp:textbox></TD>
													<TD class="TDBGColor1">Hutang Jangka Panjang Lainnya</TD>
													<TD style="WIDTH: 13px"></TD>
													<TD>
														<asp:textbox id="TXT_HUTPJGLAIN" onblur="FormatCurrency(this),Hitung()" style="TEXT-ALIGN: right"
															onkeypress="return numbersonly()" tabIndex="25" runat="server" MaxLength="12"></asp:textbox></TD>
												</TR>
												<TR>
													<TD class="TDBGColor1" style="HEIGHT: 24px">Aktiva Tetap Lainnya</TD>
													<TD style="WIDTH: 9px; HEIGHT: 24px"></TD>
													<TD style="WIDTH: 221px; HEIGHT: 24px">
														<asp:textbox id="TXT_PSN_AKTIVATTPLAIN" onblur="FormatCurrency(this),Hitung()" style="TEXT-ALIGN: right"
															onkeypress="return numbersonly()" tabIndex="14" runat="server" MaxLength="12"></asp:textbox></TD>
													<TD class="TDBGColor1" style="HEIGHT: 24px">Total Hutang Jangka Panjang</TD>
													<TD style="WIDTH: 13px; HEIGHT: 24px"></TD>
													<TD style="HEIGHT: 24px">
														<asp:textbox id="TXT_TOTHUTJKPJG" onblur="FormatCurrency(this),Hitung()" style="TEXT-ALIGN: right"
															runat="server" MaxLength="12" ReadOnly BackColor="Gainsboro"></asp:textbox></TD>
												</TR>
												<TR>
													<TD class="TDBGColor1">Akumulasi Penyusutan</TD>
													<TD style="WIDTH: 9px"></TD>
													<TD style="WIDTH: 221px">
														<asp:textbox id="TXT_PSN_AKUMSUSUT" onblur="FormatCurrency(this),Hitung()" style="TEXT-ALIGN: right"
															onkeypress="return numbersonly()" tabIndex="15" runat="server" MaxLength="12"></asp:textbox></TD>
													<TD class="TDBGColor1">Total Hutang</TD>
													<TD style="WIDTH: 13px"></TD>
													<TD>
														<asp:textbox id="TXT_HUTANG" onblur="FormatCurrency(this),Hitung()" style="TEXT-ALIGN: right"
															runat="server" MaxLength="12" ReadOnly BackColor="Gainsboro"></asp:textbox></TD>
												</TR>
												<TR>
													<TD class="TDBGColor1">Total Aktiva Tetap</TD>
													<TD style="WIDTH: 9px"><STRONG></STRONG></TD>
													<TD style="WIDTH: 221px">
														<asp:textbox id="TXT_PSN_NETAKTIVATTP" onblur="FormatCurrency(this),Hitung()" style="TEXT-ALIGN: right"
															runat="server" MaxLength="12" ReadOnly BackColor="Gainsboro"></asp:textbox></TD>
													<TD class="TDBGColor1" style="WIDTH: 170px">&nbsp;</TD>
													<TD style="WIDTH: 13px"></TD>
													<TD></TD>
												</TR>
												<TR>
													<TD class="TDBGColor1"><STRONG>Aktiva Lain</STRONG></TD>
													<TD style="WIDTH: 9px"><STRONG></STRONG></TD>
													<TD style="WIDTH: 221px"></TD>
													<TD class="TDBGColor1">Modal Disetor</TD>
													<TD style="WIDTH: 13px">&nbsp;</TD>
													<TD>
														<asp:textbox id="TXT_MODALDISETOR" onblur="FormatCurrency(this),Hitung()" style="TEXT-ALIGN: right"
															onkeypress="return numbersonly()" tabIndex="26" runat="server" MaxLength="12"></asp:textbox></TD>
												</TR>
												<TR>
													<TD class="TDBGColor1" style="HEIGHT: 4px">Beban yang ditangguhkan</TD>
													<TD style="WIDTH: 9px; HEIGHT: 4px"></TD>
													<TD style="WIDTH: 221px; HEIGHT: 4px">
														<asp:textbox id="TXT_PSN_BIAYADITANGGUHKAN" onblur="FormatCurrency(this),Hitung()" style="TEXT-ALIGN: right"
															onkeypress="return numbersonly()" tabIndex="16" runat="server" MaxLength="12"></asp:textbox></TD>
													<TD class="TDBGColor1" style="HEIGHT: 4px">Laba (rugi) Ditahan</TD>
													<TD style="WIDTH: 13px; HEIGHT: 4px"></TD>
													<TD style="HEIGHT: 4px">
														<asp:textbox onkeypress="return numbersonly()" id="TXT_LABADITAHAN" onblur=" FormatCurrency(this),Hitung()"
															style="TEXT-ALIGN: right" tabIndex="27" runat="server" MaxLength="12"></asp:textbox></TD>
												</TR>
												<TR>
													<TD class="TDBGColor1" style="HEIGHT: 7px">Akumulasi Amortisasi</TD>
													<TD style="WIDTH: 9px; HEIGHT: 7px"></TD>
													<TD style="WIDTH: 221px; HEIGHT: 7px">
														<asp:textbox id="TXT_PSN_AKUMAMORTISASI" onblur="FormatCurrency(this),Hitung()" style="TEXT-ALIGN: right"
															onkeypress="return numbersonly()" tabIndex="17" runat="server" MaxLength="12"></asp:textbox></TD>
													<TD class="TDBGColor1" style="HEIGHT: 7px">Laba (rugi) Berjalan&nbsp;</TD>
													<TD style="WIDTH: 13px; HEIGHT: 7px">&nbsp;</TD>
													<TD style="HEIGHT: 7px">
														<asp:TextBox onkeypress="return numbersonly()" id="TXT_LABABERJALAN" onblur=" FormatCurrency(this),Hitung()"
															style="TEXT-ALIGN: right" tabIndex="27" runat="server"></asp:TextBox></TD>
												</TR>
												<TR>
													<TD class="TDBGColor1">Aktiva Lainnya</TD>
													<TD style="WIDTH: 9px"></TD>
													<TD style="WIDTH: 221px">
														<asp:textbox id="TXT_PSN_AKTIVALAIN" onblur="FormatCurrency(this),Hitung()" style="TEXT-ALIGN: right"
															onkeypress="return numbersonly()" tabIndex="18" runat="server" MaxLength="12"></asp:textbox></TD>
													<TD class="TDBGColor1">Total Equity/Modal</TD>
													<TD style="WIDTH: 13px"></TD>
													<TD>
														<asp:textbox id="TXT_TOTMODAL" onblur="FormatCurrency(this),Hitung()" style="TEXT-ALIGN: right"
															onkeypress="return numbersonly()" runat="server" MaxLength="12" ReadOnly BackColor="Gainsboro"></asp:textbox></TD>
												</TR>
												<TR>
													<TD class="TDBGColor1" style="HEIGHT: 21px">Total Aktiva Lain</TD>
													<TD style="WIDTH: 9px; HEIGHT: 21px"><STRONG></STRONG></TD>
													<TD style="WIDTH: 221px; HEIGHT: 21px">
														<asp:textbox id="TXT_PSN_TTLAKTIVALAIN" style="TEXT-ALIGN: right" runat="server" MaxLength="12"
															onkeypress="return numbersonly()" ReadOnly BackColor="Gainsboro"></asp:textbox></TD>
													<TD class="TDBGColor1" style="WIDTH: 170px; HEIGHT: 21px"><STRONG><EM>&nbsp;</EM></STRONG></TD>
													<TD style="WIDTH: 13px; HEIGHT: 21px">&nbsp;</TD>
													<TD style="HEIGHT: 21px"></TD>
												</TR>
												<TR>
													<TD class="TDBGColor1" onblur="FormatCurrency(this),Hitung()">Total Aktiva</TD>
													<TD style="WIDTH: 9px"><STRONG></STRONG></TD>
													<TD style="WIDTH: 216px">
														<asp:textbox id="TXT_PSN_TTLAKTIVA" onblur="FormatCurrency(this),Hitung()" style="TEXT-ALIGN: right"
															onkeypress="return numbersonly()" runat="server" MaxLength="12" BackColor="Gainsboro" readonly></asp:textbox></TD>
													<TD class="TDBGColor1">Total Pasiva</TD>
													<TD style="WIDTH: 13px"></TD>
													<TD>
														<asp:textbox id="TXT_TOTPASIVA" onblur="FormatCurrency(this),Hitung()" style="TEXT-ALIGN: right"
															onkeypress="return numbersonly()" runat="server" MaxLength="12" ReadOnly BackColor="Gainsboro"></asp:textbox></TD>
												</TR>
											</TABLE>
										</TD>
									</TR> <!-- Labarugi -->
									<TR>
										<TD class="tdHeader1" align="center" width="100%" colSpan="2">
											<P>Laba Rugi (Rp.000,-)</P>
										</TD>
									</TR>
									<TR>
										<TD>
											<TABLE id="Table7" style="HEIGHT: 234px" cellSpacing="0" cellPadding="0" width="100%" border="0">
												<TR>
													<TD class="TDBGColor1" style="HEIGHT: 23px" width="30%">Penjualan Pertahun</TD>
													<TD style="HEIGHT: 23px" width="50%">
														<asp:textbox id="TXT_PSRL_PENJUALANTAHUNAN" onblur="FormatCurrency(this),Hitung()" style="TEXT-ALIGN: right"
															onkeypress="return numbersonly()" tabIndex="28" runat="server" MaxLength="12" Width="136px"></asp:textbox></TD>
												</TR>
												<TR>
													<TD class="TDBGColor1" width="50%">Harga Pokok Penjualan</TD>
													<TD width="20%">
														<asp:textbox id="TXT_PSRL_HPP" onblur="FormatCurrency(this),Hitung()" style="TEXT-ALIGN: right"
															onkeypress="return numbersonly()" tabIndex="29" runat="server" MaxLength="12"></asp:textbox></TD>
												</TR>
												<TR>
													<TD class="TDBGColor1">Biaya Umum &amp; Administrasi</TD>
													<TD width="20%">
														<asp:textbox id="TXT_PSRL_BIAYAUMUMADM" onblur="FormatCurrency(this),Hitung()" style="TEXT-ALIGN: right"
															onkeypress="return numbersonly()" tabIndex="30" runat="server" MaxLength="12"></asp:textbox></TD>
												</TR>
												<TR>
													<TD class="TDBGColor1" style="HEIGHT: 22px" width="25%">Laba Operasi</TD>
													<TD style="HEIGHT: 22px">
														<asp:textbox id="TXT_PSRL_LABAOPERASI" onblur="FormatCurrency(this),Hitung()" style="TEXT-ALIGN: right"
															onkeypress="return numbersonly()" tabIndex="31" runat="server" MaxLength="12" ReadOnly="True"
															BackColor="Gainsboro"></asp:textbox></TD>
												</TR>
												<TR>
													<TD class="TDBGColor1">Biaya Bunga</TD>
													<TD>
														<asp:textbox id="TXT_PSRL_BIAYABUNGA" onblur="FormatCurrency(this),Hitung()" style="TEXT-ALIGN: right"
															onkeypress="return numbersonly()" tabIndex="32" runat="server" MaxLength="12"></asp:textbox></TD>
												</TR>
												<TR>
													<TD class="TDBGColor1">Biaya Penyusutan</TD>
													<TD>
														<asp:textbox id="TXT_PSRL_BIAYAPENYUSUTAN" onblur="FormatCurrency(this),Hitung()" style="TEXT-ALIGN: right"
															onkeypress="return numbersonly()" tabIndex="33" runat="server" MaxLength="12"></asp:textbox></TD>
												</TR>
												<TR>
													<TD class="TDBGColor1">Biaya Lain-lain</TD>
													<TD>
														<asp:textbox id="TXT_PSRL_BIAYALAIN" onblur="FormatCurrency(this),Hitung()" style="TEXT-ALIGN: right"
															onkeypress="return numbersonly()" tabIndex="34" runat="server" MaxLength="12"></asp:textbox></TD>
												</TR>
												<TR>
													<TD class="TDBGColor1">Pendapatan Lain-lain</TD>
													<TD>
														<asp:textbox id="TXT_PEND_LAIN" onblur="FormatCurrency(this),Hitung()" style="TEXT-ALIGN: right"
															onkeypress="return numbersonly()" tabIndex="35" runat="server" MaxLength="12"></asp:textbox></TD>
												</TR>
												<TR>
													<TD class="TDBGColor1">Laba Sebelum Pajak</TD>
													<TD>
														<asp:textbox id="TXT_LABASBLMPAJAK" onblur="FormatCurrency(this),Hitung()" style="TEXT-ALIGN: right"
															onkeypress="return numbersonly()" tabIndex="36" runat="server" MaxLength="12" ReadOnly="True"
															BackColor="Gainsboro"></asp:textbox></TD>
												</TR>
												<TR>
													<TD class="TDBGColor1">Pajak</TD>
													<TD>
														<asp:textbox id="TXT_PAJAK" onblur="FormatCurrency(this),Hitung()" style="TEXT-ALIGN: right"
															onkeypress="return numbersonly()" tabIndex="37" runat="server" MaxLength="12"></asp:textbox></TD>
												</TR>
												<TR>
													<TD class="TDBGColor1">Laba Bersih</TD>
													<TD>
														<asp:textbox id="TXT_LABABERSIH" onblur="FormatCurrency(this),Hitung()" style="TEXT-ALIGN: right"
															onkeypress="return numbersonly()" tabIndex="38" runat="server" MaxLength="12" ReadOnly="True"
															BackColor="Gainsboro"></asp:textbox></TD>
												</TR>
											</TABLE>
										</TD>
									</TR> <!-- ratio -->
									<TR>
										<TD class="tdHeader1" align="center" width="100%" colSpan="2">Ratio &amp; Key 
											Figures
										</TD>
									</TR>
									<TR>
										<TD>
											<TABLE id="Table3" cellSpacing="0" cellPadding="0" width="100%" border="0">
												<TR>
													<TD class="TDBGColor1" style="HEIGHT: 22px" width="50%">Sales / Working Capital 
														Ratio</TD>
													<TD style="HEIGHT: 22px" width="50%">
														<asp:textbox id="TXT_SLSWKR" onblur="FormatCurrency(this)" style="TEXT-ALIGN: right" runat="server"
															onkeypress="return numbersonly()" MaxLength="4" ReadOnly="True"></asp:textbox></TD>
												</TR>
												<TR>
													<TD class="TDBGColor1" style="HEIGHT: 21px">Debt / Net Worth Ratio</TD>
													<TD style="HEIGHT: 21px" width="50%">
														<asp:textbox id="TXT_DNWR" onblur="FormatCurrency(this)" style="TEXT-ALIGN: right" runat="server"
															onkeypress="return numbersonly()" MaxLength="3" ReadOnly="True"></asp:textbox></TD>
												</TR>
												<TR>
													<TD class="TDBGColor1" width="50%">Current Ratio</TD>
													<TD width="50%"><NOBR>
															<asp:textbox id="TXT_CURRENTRATIO" onblur="FormatCurrency(this)" style="TEXT-ALIGN: right" runat="server"
																onkeypress="return numbersonly()" MaxLength="3" ReadOnly="True"></asp:textbox></NOBR></TD>
												</TR>
												<TR>
													<TD class="TDBGColor1">Business Debt Service Ratio</TD>
													<TD width="50%"><NOBR>
															<asp:textbox id="TXT_BUSSDEBTSRATIO" onblur="FormatCurrency(this)" style="TEXT-ALIGN: right"
																onkeypress="return numbersonly()" tabIndex="38" runat="server" MaxLength="3" ReadOnly="True"></asp:textbox></NOBR></TD>
												</TR>
												<TR>
													<TD class="TDBGColor1">Trade Cycle Days</TD>
													<TD width="50%">
														<asp:textbox id="TXT_TRADECYCLEDAYS" onblur="FormatCurrency(this)" style="TEXT-ALIGN: right"
															onkeypress="return numbersonly()" tabIndex="41" runat="server" MaxLength="3" ReadOnly="True"></asp:textbox>&nbsp;days</TD>
												</TR>
												<TR>
													<TD class="TDBGColor1">Laba Bersih Rata-Rata</TD>
													<TD width="50%">
														<asp:textbox id="TXT_LABABERSIHRATA2" onblur="FormatCurrency(this),Hitung()" style="TEXT-ALIGN: right"
															tabIndex="42" runat="server" MaxLength="7" ReadOnly="True" BackColor="Gainsboro"></asp:textbox></TD>
												</TR>
												<TR>
													<TD class="TDBGColor1">Cash Velocity
													</TD>
													<TD width="50%">
														<asp:TextBox id="TXT_CASH_VELOCITY" style="TEXT-ALIGN: right" runat="server" MaxLength="8" ReadOnly="True"></asp:TextBox>&nbsp;</TD>
												</TR>
												<TR>
													<TD class="TDBGColor1">Days Receivable</TD>
													<TD width="50%">
														<asp:TextBox id="TXT_DAYS_RECEIVABLE" style="TEXT-ALIGN: right" runat="server" MaxLength="8"
															ReadOnly="True"></asp:TextBox>&nbsp;days&nbsp;</TD>
												</TR>
												<TR>
													<TD class="TDBGColor1">Days Inventory
													</TD>
													<TD width="50%">
														<asp:TextBox id="TXT_DAYS_INVENTORY" style="TEXT-ALIGN: right" runat="server" MaxLength="8" ReadOnly="True"></asp:TextBox>&nbsp;days</TD>
												</TR>
												<TR>
													<TD class="TDBGColor1">Days Account Payable
													</TD>
													<TD width="50%">
														<asp:TextBox id="TXT_DAYS_ACCPAYABLE" style="TEXT-ALIGN: right" runat="server" MaxLength="8"
															ReadOnly="True"></asp:TextBox>&nbsp;days</TD>
												</TR>
												<TR>
													<TD class="TDBGColor1">Net Working Capital</TD>
													<TD width="50%">
														<asp:TextBox id="TXT_NETWORKING_CAPITAL" style="TEXT-ALIGN: right" runat="server" MaxLength="8"
															ReadOnly="True"></asp:TextBox></TD>
												</TR> <!--
												<TR>
													<TD class="TDBGColor1">Return On Investment</TD>
													<TD width="50%">
														<asp:TextBox id="TXT_ROI" runat="server" MaxLength="8" style="TEXT-ALIGN: right"></asp:TextBox></TD>
												</TR>
												-->
												<TR>
													<TD class="TDBGColor1">Total Asset Turn Over
													</TD>
													<TD width="50%">
														<asp:TextBox id="TXT_TOTALASSET_TO" style="TEXT-ALIGN: right" runat="server" MaxLength="8" ReadOnly="True"></asp:TextBox></TD>
												</TR>
												<TR>
													<TD class="TDBGColor1"></TD>
													<TD width="50%"></TD>
												</TR>
											</TABLE>
											<asp:label id="LBL_CUREF" runat="server" Visible="False"></asp:label>
											<asp:label id="LBL_APREGNO" runat="server" Visible="False"></asp:label></TD>
									</TR> <!-- ************************* separator *************------------------------------------------------------------------------------------------------------------------------------------------->
									<TR>
										<TD class="TDBGColor2" vAlign="top" align="center" colSpan="2">
											<asp:label id="LBL_HITUNG" runat="server" Visible="False">0</asp:label>
											<asp:button id="BTN_HITUNG" tabIndex="43" runat="server" CssClass="Button1" Text="Hitung" onclick="BTN_HITUNG_Click"></asp:button>&nbsp;
											<asp:button id="BTN_SAVE" tabIndex="44" runat="server" CssClass="Button1" Text="Save" onclick="BTN_SAVE_Click"></asp:button></TD>
									</TR>
								</TABLE>
		</form>
		</TD></TR></TBODY></TABLE></TR></TBODY></TABLE>
		<CENTER><asp:textbox id="TXT_PUCHASEPLAN" onblur="FormatCurrency(this)" style="Z-INDEX: 101; LEFT: 128px; POSITION: absolute; TOP: 1424px; TEXT-ALIGN: right"
				onkeypress="return numbersonly()" runat="server" Width="25px" Visible="False"></asp:textbox><asp:textbox id="TXT_LIMITWCBM" onblur="FormatCurrency(this),Hitung()" style="Z-INDEX: 102; LEFT: 168px; POSITION: absolute; TOP: 1424px; TEXT-ALIGN: right"
				onkeypress="return numbersonly()" runat="server" Width="25px" Visible="False"></asp:textbox></CENTER>
		</FORM></CENTER>
	</body>
</HTML>
