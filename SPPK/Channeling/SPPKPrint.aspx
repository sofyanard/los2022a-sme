<%@ Page language="c#" Codebehind="SPPKPrint.aspx.cs" AutoEventWireup="True" Inherits="SME.Channeling.SPPKPrint.SPPKPrint" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>BICheckingRequestPrint</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<LINK href="../../style.css" type="text/css" rel="stylesheet">
		<script language="javascript">
		  function cetak()
		  {
		    TRPRINT.style.display = "none";
		    window.print();
		    TRPRINT.style.display = "";
		  }
		</script>
	</HEAD>
	<body leftMargin="0" topMargin="0">
		<form id="Form1" method="post" runat="server">
			<!-- Rubah di sini -->
			<TABLE id="Table1" cellSpacing="2" cellPadding="2" width="650" border="1">
				<TBODY>
					<!--
						<TR>
							<TD class="tdNoBorder" style="HEIGHT: 41px" align="center" colSpan="2"><asp:placeholder id="Menu" runat="server"></asp:placeholder></TD>
						</TR>
						-->
					<TR id="TRPRINT">
						<TD class="TDBGColor2" colSpan="2"><INPUT class="Button1" onclick="cetak()" type="button" value="Print" name="TRPRINT" CssClass="Button1">
							<INPUT class="Button1" id="BTN_BACK" onclick="javascript:history.back();" type="button"
								value="Back" name="BTN_BACK">
						</TD>
					</TR>
					<TR>
						<TD align="center"></TD>
					</TR>
					<TR>
						<TD class="td" vAlign="top" width="50%">
							<TABLE cellSpacing="0" cellPadding="0" width="100%" border="1">
								<TR>
									<TD width="84" style="WIDTH: 84px; HEIGHT: 19px">Nomor</TD>
									<TD style="WIDTH: 1px; HEIGHT: 19px">:</TD>
									<TD style="HEIGHT: 19px"><asp:label id="LBL_NOMOR_SURAT" runat="server" Width="100%"></asp:label></TD>
								</TR>
								<TR>
									<TD style="WIDTH: 84px">Tanggal</TD>
									<TD vAlign="top" style="WIDTH: 1px">:</TD>
									<TD><asp:label id="LBL_TANGGAL_SURAT" runat="server" Width="100%"></asp:label></TD>
								</TR>
								<TR>
									<TD style="WIDTH: 84px">
										Lampiran</TD>
									<TD vAlign="top" style="WIDTH: 1px">:</TD>
									<TD><asp:label id="LBL_LAMPIRAN_SURAT" runat="server" Width="100%"></asp:label></TD>
								</TR>
							</TABLE>
						</TD>
					</TR>
					<TR>
						<TD class="td" vAlign="top" width="50%">
							<TABLE cellSpacing="0" cellPadding="0" width="100%" border="1">
								<TR>
									<TD width="84" style="WIDTH: 84px">Kepada Yth.</TD>
									<TD style="WIDTH: 1px">:</TD>
									<TD><asp:label id="LBL_KEPADA_YTH" runat="server" Width="100%"></asp:label></TD>
								</TR>
								<TR>
									<TD style="WIDTH: 84px">Sdr.</TD>
									<TD vAlign="top" style="WIDTH: 1px">:</TD>
									<TD><asp:label id="LBL_SDR" runat="server" Width="100%"></asp:label></TD>
								</TR>
								<TR>
									<TD style="WIDTH: 84px">
										Jl.</TD>
									<TD vAlign="top" style="WIDTH: 1px">:</TD>
									<TD><asp:label id="LBL_DETAIL_JALAN" runat="server" Width="100%"></asp:label></TD>
								</TR>
							</TABLE>
						</TD>
					</TR>
					<TR>
						<TD class="td" vAlign="top" width="50%" style="HEIGHT: 19px">
							<TABLE cellSpacing="0" cellPadding="0" width="100%" border="1">
								<TR>
									<TD width="84" style="WIDTH: 84px">
										Perihal</TD>
									<TD style="WIDTH: 2px">:</TD>
									<TD><B><SPAN style="FONT-SIZE: 11pt; FONT-FAMILY: 'Calibri','sans-serif'; mso-bidi-font-size: 12.0pt; mso-fareast-font-family: 'Times New Roman'; mso-bidi-font-family: Arial; mso-ansi-language: EN-US; mso-fareast-language: EN-US; mso-bidi-language: AR-SA">Surat 
												Penawaran Pemberian Kredit melalui Channeling Agent
												<asp:label id="LBL_CHANNELING_AGENT" runat="server" Width="136px"></asp:label></SPAN></B></TD>
								</TR>
							</TABLE>
						</TD>
					</TR>
					<TR>
						<TD class="td" vAlign="top" width="50%" style="HEIGHT: 19px">
							<TABLE cellSpacing="0" cellPadding="0" width="100%" border="1">
								<TR>
									<TD width="91" style="WIDTH: 91px">Dengan&nbsp;hormat,</TD>
								</TR>
							</TABLE>
						</TD>
					</TR>
					<TR>
						<TD align="left" colSpan="2">
							Menunjuk Perjanjian Kerjasama dengan
							<asp:Label id="LABEL_PERJANJIAN_KERJASAMA_DENGAN" runat="server" Width="56px">Label</asp:Label>&nbsp;Nomor
							<asp:Label id="LABEL_NOMOR_PERJANJIAN" runat="server" Width="64px">Label</asp:Label>&nbsp;tanggal
							<asp:Label id="LABEL_TANGGAL_PERJANJIAN" runat="server" Width="88px">Label</asp:Label>, 
							dengan ini kami menyampaikan penawaran pemberian kredit dengan ketentuan dan 
							syarat sebagai berikut :
						</TD>
					</TR>
					<TR>
						<TD class="td" vAlign="top" width="50%" style="HEIGHT: 19px">
							<TABLE cellSpacing="0" cellPadding="0" width="100%" border="1">
								<TR>
									<TD width="91" style="WIDTH: 91px"><STRONG>A. Ketentuan</STRONG></TD>
								</TR>
							</TABLE>
						</TD>
					</TR>
					<TR>
						<TD class="td" vAlign="top" width="100%" colSpan="2">
							<TABLE cellSpacing="0" cellPadding="0" width="100%" border="1">
								<TR>
									<TD width="24%">1. Limit Kredit</TD>
									<TD width="1%"></TD>
									<TD width="75%">
										<asp:label id="LBL_LIMIT_KREDIT" runat="server"></asp:label></TD>
								</TR>
								<TR>
									<TD>2. Jenis Kredit</TD>
									<TD></TD>
									<TD>
										<asp:label id="LBL_JENIS_KREDIT" runat="server"></asp:label></TD>
								</TR>
								<TR>
									<TD>3. Sifat Kredit</TD>
									<TD></TD>
									<TD>
										<asp:label id="LBL_SIFAT_KREDIT" runat="server"></asp:label></TD>
								</TR>
								<TR>
									<TD>4. Tujuan Penggunaan</TD>
									<TD></TD>
									<TD>
										<asp:label id="LBL_TUJUAN_PENGGUNAAN" runat="server"></asp:label></TD>
								</TR>
								<TR>
									<TD>5. Jangka&nbsp;Waktu</TD>
									<TD></TD>
									<TD>
										<asp:label id="LBL_JANGKA_WAKTU" runat="server"></asp:label></TD>
								</TR>
								<TR>
									<TD>6. Suku Bunga</TD>
									<TD></TD>
									<TD>
										<asp:label id="LBL_SUKU_BUNGA" runat="server"></asp:label></TD>
								</TR>
								<TR>
									<TD>7. Denda</TD>
									<TD></TD>
									<TD>
										<asp:label id="LBL_DENDA" runat="server"></asp:label></TD>
								</TR>
								<TR>
									<TD>8. Provisi</TD>
									<TD></TD>
									<TD>
										<asp:label id="LBL_PROVISI" runat="server"></asp:label></TD>
								</TR>
								<TR>
									<TD>9. Biaya Administrasi</TD>
									<TD></TD>
									<TD>
										<asp:label id="LBL_BIAYA_ADMINISTRASI" runat="server"></asp:label></TD>
								</TR>
							</TABLE>
						</TD>
					</TR>
					<TR>
						<TD class="td" vAlign="top" width="50%" style="HEIGHT: 19px">
							<TABLE cellSpacing="0" cellPadding="0" width="100%" border="1">
								<TR>
									<TD width="91" style="WIDTH: 91px"><STRONG>B.&nbsp;Syarat&nbsp;Penandatanganan&nbsp;Perjanjian&nbsp;Kredit</STRONG></TD>
								</TR>
							</TABLE>
						</TD>
					</TR>
					<TR>
						<TD class="td" vAlign="top" width="100%">
							<TABLE cellSpacing="0" cellPadding="0" width="100%" border="1">
								<TR>
									<TD width="24%">1. Telah membayar provisi kredit dan biaya administrasi.</TD>
								</TR>
							</TABLE>
						</TD>
					</TR>
					<TR>
						<TD class="td" vAlign="top" width="50%" style="HEIGHT: 19px">
							<TABLE cellSpacing="0" cellPadding="0" width="100%" border="1">
								<TR>
									<TD width="91" style="WIDTH: 91px"><STRONG>C.&nbsp;Syarat&nbsp;Penarikan&nbsp;Kredit</STRONG></TD>
								</TR>
							</TABLE>
						</TD>
					</TR>
					<TR>
						<TD class="td" vAlign="top" width="100%">
							<TABLE cellSpacing="0" cellPadding="0" width="100%" border="1">
								<TR>
									<TD width="24%">1. Perjanjian kredit telah disetujui oleh yang berwenang.</TD>
								</TR>
							</TABLE>
						</TD>
					</TR>
					<TR>
						<TD class="td" vAlign="top" width="100%">
							<TABLE cellSpacing="0" cellPadding="0" width="100%" border="1">
								<TR>
									<TD width="24%" align='center"' style="TEXT-ALIGN: justify">Saudara dengan ini 
										menyetujui bahwa pembatalan surat pemberitahuan ini dilakukan dengan 
										mengesampingkan pasal 1266 dan 1267 KUH Perdata, sehingga pembatalan surat 
										pemberitahuan ini tidak memerlukan putusan/penetapan pengadilan, melainkan 
										cukup dengan pemberitahuan tertulis dari kami kepada Saudara.</TD>
								</TR>
							</TABLE>
						</TD>
					</TR>
					<TR>
						<TD class="td" vAlign="top" width="100%">
							<TABLE cellSpacing="0" cellPadding="0" width="100%" border="1">
								<TR>
									<TD width="24%" align='center"' style="TEXT-ALIGN: justify">Dalam rangka penerapan <i>Good 
											Corporate Governance,</i> Saudara dengan ini menyatakan tidak akan pernah 
										memberikan dan atau janji memberikan segala sesuatu yang dapat ditafsirkan 
										sebagai imbalan dalam arti yang seluas-luasnya, baik tersurat maupun tersirat 
										kepada Komisaris, Direksi, Karyawan PT Bank Mandiri (Persero), Tbk. berkaitan 
										dengan kredit yang diberikan oleh Bank kepada Saudara.
									</TD>
								</TR>
							</TABLE>
						</TD>
					</TR>
					<TR>
						<TD class="td" vAlign="top" width="100%">
							<TABLE cellSpacing="0" cellPadding="0" width="100%" border="1">
								<TR>
									<TD width="24%" align='center"' style="TEXT-ALIGN: justify">Surat pemberitahuan ini 
										berlaku dengan ketentuan bahwa apabila terdapat kekeliruan dalam isi surat ini 
										maka Saudara menyetujui dan PT Bank Mandiri (Persero), Tbk. berhak untuk 
										melakukan perbaikan seperlunya.
									</TD>
								</TR>
							</TABLE>
						</TD>
					</TR>
					<TR>
						<TD class="td" vAlign="top" width="100%">
							<TABLE cellSpacing="0" cellPadding="0" width="100%" border="1">
								<TR>
									<TD width="24%" align='center"' style="TEXT-ALIGN: justify">
										Surat pemberitahuan ini merupakan bagian dan menjadi satu kesatuan yang tidak 
										terpisahkan dengan Perjanjian Kerjasama dengan&nbsp;
										<asp:Label id="LBL_NAMA_AGENT_CHANNELING_2" runat="server">Label</asp:Label>
										&nbsp;,Nomor
										<asp:Label id="LBL_NOMOR_PERJANJIAN_CHANNELING_2" runat="server">Label</asp:Label>&nbsp;,tanggal&nbsp;
										<asp:Label id="LBL_TANGGAL_PERJANJIAN_2" runat="server">Label</asp:Label>
										Penawaran ini tidak bersifat mengikat dan dapat dibatalkan secara sepihak 
										sampai dengan ditanda-tanganinya Perjanjian Kredit antara Saudara dan Bank kami 
										atau nama channeling agent yang bertindak atas nama Bank.
									</TD>
								</TR>
							</TABLE>
						</TD>
					</TR>
					<TR>
						<TD class="td" vAlign="top" width="100%">
							<TABLE cellSpacing="0" cellPadding="0" width="100%" border="1">
								<TR>
									<TD width="24%" align='center"' style="TEXT-ALIGN: justify">
										Demikian penawaran kami dan apabila Saudara menyetujui, agar tembusan surat ini 
										Saudara kembalikan kepada kami selambat-lambatnya dalam 30 hari sejak tanggal 
										surat ini.
									</TD>
								</TR>
							</TABLE>
						</TD>
					</TR>
					<TR>
						<TD class="td" vAlign="top" width="100%">
							<TABLE cellSpacing="0" cellPadding="0" width="100%" border="1">
								<TR>
									<TD width="24%" align='center"' style="TEXT-ALIGN: justify">
										Hormat kami,
										<P></P>
										<STRONG>PT BANK MANDIRI (PERSERO)</STRONG>
									</TD>
								</TR>
							</TABLE>
						</TD>
					</TR>
					<TR>
						<TD class="td" vAlign="top" width="100%">
							<TABLE cellSpacing="0" cellPadding="0" width="100%" border="1">
								<TR>
									<TD width="24%" align='center"' style="TEXT-ALIGN: justify">
										<asp:Label id="LBL_NAMA_UNIT_KERJA" runat="server">Label</asp:Label>
										&nbsp;
									</TD>
								</TR>
							</TABLE>
						</TD>
					</TR>
					<TR>
						<TD class="td" vAlign="top" width="100%">
							<TABLE cellSpacing="0" cellPadding="0" width="640" border="1" style="WIDTH: 640px; HEIGHT: 52px">
								<TR>
									<TD width="24%" align='center"' style="VERTICAL-ALIGN: baseline; HEIGHT: 154px; TEXT-ALIGN: justify">
										<P>&nbsp;</P>
										<P>&nbsp;</P>
										<P>&nbsp;</P>
										<P>&nbsp;</P>
										<P>&nbsp;</P>
										<P>(Pejabat Yang Berwenang)</P>
									</TD>
								</TR>
							</TABLE>
						</TD>
					</TR>
				</TBODY>
			</TABLE>
		</form>
	</body>
</HTML>
