<%@ Page language="c#" Codebehind="AIP2Print.aspx.cs" AutoEventWireup="True" Inherits="SME.InitialDataEntry.AIP2Print" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML xmlns:o>
	<HEAD>
		<title>AIP2Print</title>
		<meta content="False" name="vs_showGrid">
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../style.css" type="text/css" rel="stylesheet">
		<!-- #include file="../include/cek_all.html" -->
	</HEAD>
	<body leftMargin="0" topMargin="0" MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<center>
				<TABLE cellSpacing="0" cellPadding="0" width="100%">
					<TR>
						<TD class="tdNoBorder" style="WIDTH: 669px" align="right" colSpan="2"><A href="../Body.aspx"><FONT face="Tahoma" size="2"></FONT></A><A href="../Logout.aspx" target="_top"><FONT face="Tahoma" size="2"></FONT></A></TD>
						<TD class="tdNoBorder" style="WIDTH: 669px" align="right"></TD>
					</TR>
					<TR>
						<TD style="WIDTH: 669px; HEIGHT: 102px" align="right" colSpan="2">
							<TABLE id="Table4" width="100%">
								<TR>
									<TD style="WIDTH: 78px; HEIGHT: 24px"><FONT face="Tahoma" size="2">Nomor</FONT></TD>
									<TD style="WIDTH: 5px; HEIGHT: 24px"><FONT face="Tahoma" size="2">:</FONT></TD>
									<TD style="HEIGHT: 24px"><asp:label id="LBL_NO" runat="server" MaxLength="100" Font-Size="X-Small" ForeColor="#0000C0"></asp:label><FONT face="Tahoma" size="2"><STRONG></STRONG></FONT></TD>
								</TR>
								<TR>
									<TD style="WIDTH: 78px; HEIGHT: 24px"><FONT face="Tahoma" size="2">Tanggal</FONT></TD>
									<TD style="WIDTH: 5px; HEIGHT: 24px"><FONT face="Tahoma" size="2">:</FONT></TD>
									<TD style="HEIGHT: 24px"><FONT face="Tahoma" size="2"><asp:label id="LBL_CURTIME" runat="server" MaxLength="100" ForeColor="#0000C0" ReadOnly="True"
												Font-Size="X-Small"></asp:label><STRONG></STRONG></FONT></TD>
								</TR>
								<TR>
									<TD style="WIDTH: 78px"><FONT face="Tahoma" size="2">Lampiran</FONT></TD>
									<TD style="WIDTH: 5px"><FONT face="Tahoma" size="2">:</FONT></TD>
									<TD><asp:label id="LBL_LAMP" runat="server" MaxLength="100" ForeColor="#0000C0" Font-Size="X-Small"></asp:label></TD>
								</TR>
							</TABLE>
						</TD>
						<TD style="WIDTH: 669px; HEIGHT: 102px" align="right"></TD>
					</TR>
					<TR>
						<TD vAlign="top" align="left" width="100%" colSpan="2" style="HEIGHT: 20px"></TD>
					</TR>
					<TR>
						<TD vAlign="top" align="left" width="100%" colSpan="2">
							<P>
								<TABLE id="Table5" cellSpacing="1" cellPadding="1" width="100%" align="center" border="0">
									<TBODY>
										<TR>
											<TD align="left" width="100%">
												<P><FONT face="Tahoma" size="2">Kepada Yth.&nbsp; </FONT>
												</P>
											</TD>
										</TR>
										<TR>
											<TD style="HEIGHT: 3px" align="left" width="100%"><asp:label id="LBL_CUST_NAME" runat="server" MaxLength="100" ForeColor="#0000C0" Font-Size="X-Small"></asp:label><FONT face="Tahoma" size="2"><STRONG></STRONG></FONT></TD>
										</TR>
										<TR>
											<TD align="left" width="100%" style="HEIGHT: 23px"><asp:label id="LBL_ADDR" runat="server" MaxLength="100" ForeColor="#0000C0" Font-Size="X-Small"></asp:label><FONT face="Tahoma" size="2"><STRONG></STRONG></FONT></TD>
										</TR>
										<TR>
											<TD style="HEIGHT: 23px" align="left" width="100%">
												<asp:label id="LBL_ADDR2" runat="server" ForeColor="#0000C0" Font-Size="X-Small" MaxLength="100"></asp:label></TD>
										</TR>
										<TR>
											<TD style="HEIGHT: 23px" align="left" width="100%">
												<asp:label id="LBL_ADDR3" runat="server" ForeColor="#0000C0" Font-Size="X-Small" MaxLength="100"></asp:label></TD>
										</TR>
										<TR>
											<TD style="HEIGHT: 20px" align="left" width="100%"><asp:label id="LBL_CITY" runat="server" MaxLength="100" ForeColor="#0000C0" Font-Size="X-Small"></asp:label><FONT face="Tahoma" size="2"><STRONG></STRONG></FONT></TD>
										</TR>
										<TR>
											<TD align="left" width="100%"><asp:label id="LBL_POSTCODE" runat="server" MaxLength="100" ForeColor="#0000C0" Font-Size="X-Small"></asp:label><FONT face="Tahoma" size="2"><STRONG></STRONG></FONT></TD>
										</TR>
										<TR>
										</TR>
										<P></P>
						</TD>
					<TR>
						<TD vAlign="top" align="left" width="100%"></TD>
					</TR>
					<TR>
						<TD vAlign="top" align="left" width="100%" colSpan="2"><P><FONT face="Tahoma"><FONT size="2">Perihal 
										: <STRONG>Permohonan Kredit Saudara</STRONG></FONT></FONT></P>
							<P><STRONG><FONT face="Tahoma" size="2">
										<asp:label id="LBL_NOMINAL_CP_LIMIT" runat="server" MaxLength="100" ForeColor="Black" ReadOnly="True"
											Font-Size="X-Small" Visible="False"></asp:label></FONT></STRONG></P>
						</TD>
						<TD vAlign="top" align="left" width="100%"></TD>
					</TR>
					<TR>
						<TD vAlign="top" align="left" width="100%" colSpan="2">
							<P class="MsoNormal"><SPAN style="TEXT-ALIGN: justify; mso-ansi-language: EN-US"><FONT face="Tahoma" size="2">Terima 
										kasih kami sampaikan atas kepercayaan Bapak/Ibu/Saudara terhadap Bank Mandiri. 
										Setelah memproses permohonan Bapak/Ibu/Saudara untuk memperoleh fasilitas 
										kredit </FONT>
									<asp:label id="LBL_PRODUCTDESC1" runat="server" MaxLength="100" ForeColor="#0000C0" ReadOnly="True"
										Font-Size="X-Small"></asp:label>&nbsp;,<FONT face="Tahoma" size="2"> &nbsp;dengan 
										ini kami beritahukan bahwa secara prinsip Bank Mandiri dapat menyetujui 
										permohonan kredit&nbsp; </FONT>
									<asp:label id="LBL_PRODUCTDESC2" runat="server" MaxLength="100" ForeColor="#0000C0" ReadOnly="True"
										Font-Size="X-Small"></asp:label><FONT face="Tahoma" size="2">&nbsp; Saudara 
										dengan limit sementara sebesar Rp.&nbsp; </FONT>
									<asp:label id="LBL_CP_LIMIT" runat="server" MaxLength="100" ForeColor="#0000C0" ReadOnly="True"
										Font-Size="X-Small"></asp:label><FONT face="Tahoma"><FONT size="2"> , sepanjang 
											Saudara dapat memenuhi kondisi-kondisi sebagai berikut:</FONT></FONT></SPAN></P>
						</TD>
						<TD vAlign="top" align="left" width="100%"></TD>
					</TR>
				</TABLE>
				<TABLE cellSpacing="1" cellPadding="1" width="100%" align="center" border="0">
					<TR>
						<TD style="HEIGHT: 5px" align="left" width="3%"></TD>
						<TD style="HEIGHT: 5px" align="left" width="100%"><FONT face="Tahoma" size="2"></FONT></TD>
						<TD style="HEIGHT: 5px" align="left" width="100%"></TD>
					</TR>
					<TR>
						<TD vAlign="top" align="center" width="3%"></TD>
						<TD vAlign="top" align="center" width="100%">
							<TABLE id="Table1" cellSpacing="0" cellPadding="0" width="100%" border="0">
								<TR>
									<TD vAlign="top" width="3%"><FONT face="Tahoma" size="2">1.</FONT></TD>
									<TD>
										<P class="MsoNormal"><SPAN style="mso-ansi-language: EN-US"><FONT face="Tahoma"><FONT size="2">Dokumen 
														yang dibutuhkan sudah lengkap dan telah diserahkan kepada Bank 
														selambat-lambatnya 14 (empat belas) hari kalender setelah tanggal surat ini, 
														yaitu sebagai berikut:
														<o:p></o:p></FONT></FONT></SPAN></P>
									</TD>
								</TR>
							</TABLE>
						</TD>
						<TD vAlign="top" align="center" width="100%"></TD>
					</TR>
					</TR>
					<TR>
						<TD vAlign="top" align="center" width="3%" style="HEIGHT: 673px"></TD>
						<TD vAlign="top" align="center" width="100%" style="HEIGHT: 673px"><asp:panel id="PNL_PERSONAL" runat="server" DESIGNTIMEDRAGDROP="750" Height="676px">
								<TABLE id="Table2" cellSpacing="0" cellPadding="0" width="100%" border="0">
									<TR>
										<TD style="HEIGHT: 20px" width="3%"><FONT face="Tahoma" size="2"></FONT></TD>
										<TD style="WIDTH: 19px; HEIGHT: 20px" borderColor="black" align="center" width="19"><FONT face="Tahoma" size="2">a.</FONT></TD>
										<TD style="HEIGHT: 20px" borderColor="black"><FONT face="Tahoma" size="2">Copy 
												KTP/identitas pemohon &amp; suami/istri</FONT></TD>
									</TR>
									<TR>
										<TD width="3%"><FONT face="Tahoma" size="2"></FONT></TD>
										<TD style="WIDTH: 19px" borderColor="black" align="center" width="19"><FONT face="Tahoma" size="2">b.</FONT></TD>
										<TD borderColor="black"><FONT face="Tahoma" size="2">Copy surat nikah/cerai (apabila 
												ada)</FONT></TD>
									</TR>
									<TR>
										<TD width="3%"><FONT face="Tahoma" size="2"></FONT></TD>
										<TD style="WIDTH: 19px" borderColor="black" align="center" width="19"><FONT face="Tahoma" size="2">c.</FONT></TD>
										<TD borderColor="black"><FONT face="Tahoma" size="2">Copy Kartu Keluarga</FONT></TD>
									</TR>
									<TR>
										<TD style="HEIGHT: 21px" width="3%"><FONT face="Tahoma" size="2"></FONT></TD>
										<TD style="WIDTH: 19px; HEIGHT: 21px" borderColor="black" align="center" width="19"><FONT face="Tahoma" size="2">d.</FONT></TD>
										<TD style="HEIGHT: 21px" borderColor="black"><FONT face="Tahoma" size="2">Foto terakhir 
												pemohon uk 6x6 (2 lbr)</FONT></TD>
									</TR>
									<TR>
										<TD width="3%"><FONT face="Tahoma" size="2"></FONT></TD>
										<TD style="WIDTH: 19px" vAlign="top" borderColor="#000000" align="center" width="19"><FONT face="Tahoma" size="2">e.</FONT></TD>
										<TD borderColor="#000000"><FONT face="Tahoma" size="2">Legalitas usaha</FONT></TD>
									</TR>
									<TR>
										<TD width="3%"><FONT face="Tahoma" size="2"></FONT></TD>
										<TD style="WIDTH: 19px" vAlign="top" borderColor="#000000" align="center" width="19"><FONT face="Tahoma" size="2"></FONT></TD>
										<TD borderColor="#000000"><FONT face="Tahoma" size="2">&nbsp;- SIUP</FONT></TD>
									</TR>
									<TR>
										<TD width="3%"><FONT face="Tahoma" size="2"></FONT></TD>
										<TD style="WIDTH: 19px" vAlign="top" borderColor="#000000" align="center" width="19"><FONT face="Tahoma" size="2"></FONT></TD>
										<TD borderColor="#000000"><FONT face="Tahoma" size="2">&nbsp;- TDP/TDR</FONT></TD>
									</TR>
									<TR>
										<TD style="HEIGHT: 19px" width="3%"><FONT face="Tahoma" size="2"></FONT></TD>
										<TD style="WIDTH: 19px; HEIGHT: 19px" vAlign="top" borderColor="#000000" align="center"
											width="19"><FONT face="Tahoma" size="2"></FONT></TD>
										<TD style="HEIGHT: 19px" borderColor="#000000"><FONT face="Tahoma" size="2">&nbsp;- 
												SITU</FONT></TD>
									</TR>
									<TR>
										<TD style="HEIGHT: 15px" width="3%"><FONT face="Tahoma" size="2"></FONT></TD>
										<TD style="WIDTH: 19px; HEIGHT: 15px" vAlign="top" borderColor="#000000" align="center"
											width="19"><FONT face="Tahoma" size="2"></FONT></TD>
										<TD style="HEIGHT: 15px" borderColor="#000000"><FONT face="Tahoma" size="2">&nbsp;- 
												Lain-lain:</FONT></TD>
									</TR>
									<TR>
										<TD width="3%"><FONT face="Tahoma" size="2"></FONT></TD>
										<TD style="WIDTH: 19px" vAlign="top" borderColor="#000000" align="center" width="19"><FONT face="Tahoma" size="2"></FONT></TD>
										<TD borderColor="#000000"><FONT face="Tahoma" size="2">&nbsp;&nbsp;&nbsp; </FONT>
											<asp:label id="LBL_LGL" runat="server" ForeColor="#0000C0" Font-Size="X-Small" Height="11px"
												TextMode="MultiLine"></asp:label></TD>
									</TR>
									<TR>
										<TD width="3%"><FONT face="Tahoma" size="2"></FONT></TD>
										<TD style="WIDTH: 19px" borderColor="black" align="center" width="19"><FONT face="Tahoma" size="2">f.</FONT></TD>
										<TD borderColor="black"><FONT face="Tahoma" size="2">NPWP <FONT style="VERTICAL-ALIGN: super" size="1">
													1)</FONT></FONT></TD>
									</TR>
									<TR>
										<TD style="HEIGHT: 22px" width="3%"><FONT face="Tahoma" size="2"></FONT></TD>
										<TD style="WIDTH: 19px; HEIGHT: 22px" borderColor="black" align="center" width="19"><FONT face="Tahoma" size="2">9.</FONT></TD>
										<TD style="HEIGHT: 22px" borderColor="black"><FONT face="Tahoma" size="2">Rekening 
												koran 6 bulan terakhir</FONT></TD>
									</TR>
									<TR>
										<TD style="HEIGHT: 13px" width="3%"><FONT face="Tahoma" size="2"></FONT></TD>
										<TD style="WIDTH: 19px; HEIGHT: 13px" vAlign="bottom" borderColor="black" align="center"
											width="19"><FONT face="Tahoma" size="2">h.</FONT></TD>
										<TD style="HEIGHT: 13px" borderColor="black"><FONT style="VERTICAL-ALIGN: sub" face="Tahoma" size="2">SPT 
												Pajak tahu terakhir <FONT style="VERTICAL-ALIGN: super" size="1">1)</FONT></FONT></TD>
									</TR>
									<TR>
										<TD width="3%"><FONT face="Tahoma" size="2"></FONT></TD>
										<TD style="WIDTH: 19px" borderColor="#000000" align="center" width="19"><FONT face="Tahoma" size="2">i.</FONT></TD>
										<TD borderColor="#000000"><FONT face="Tahoma" size="2">Copy dokumen kepemilikan agunan</FONT></TD>
									</TR>
									<TR>
										<TD width="3%"><FONT face="Tahoma" size="2"></FONT></TD>
										<TD style="WIDTH: 19px" borderColor="#000000" align="center" width="19"><FONT face="Tahoma" size="2">j.</FONT></TD>
										<TD borderColor="#000000"><FONT face="Tahoma" size="2">Bukti pembayaran PBB tahun 
												terakhir</FONT></TD>
									</TR>
									<TR>
										<TD width="3%"><FONT face="Tahoma" size="2"></FONT></TD>
										<TD style="WIDTH: 19px" borderColor="#000000" align="center" width="19"><FONT face="Tahoma" size="2">k.</FONT></TD>
										<TD borderColor="#000000"><FONT face="Tahoma" size="2">Laporan keuangan 2 tahun 
												terakhir</FONT></TD>
									</TR>
									<TR>
										<TD width="3%"><FONT face="Tahoma" size="2"></FONT></TD>
										<TD style="WIDTH: 19px" borderColor="#000000" align="center" width="19"><FONT face="Tahoma" size="2">l.</FONT></TD>
										<TD borderColor="#000000"><FONT face="Tahoma" size="2">Dokumentasi tambahan untuk KMK:</FONT></TD>
									</TR>
									<TR>
										<TD width="3%"><FONT face="Tahoma" size="2"></FONT></TD>
										<TD style="WIDTH: 19px" borderColor="#000000" align="center" width="19"><FONT face="Tahoma" size="2"></FONT></TD>
										<TD borderColor="#000000"><FONT face="Tahoma" size="2">&nbsp;- Realisasi pembelian 
												&amp; penjualan 12 bulan terakhir</FONT></TD>
									</TR>
									<TR>
										<TD width="3%"><FONT face="Tahoma" size="2"></FONT></TD>
										<TD style="WIDTH: 19px" borderColor="#000000" align="center" width="19"><FONT face="Tahoma" size="2"></FONT></TD>
										<TD borderColor="#000000"><FONT face="Tahoma" size="2">&nbsp;- Rencana pembelian &amp; 
												penjualan 12 bulan yad</FONT></TD>
									</TR>
									<TR>
										<TD width="3%"><FONT face="Tahoma" size="2"></FONT></TD>
										<TD style="WIDTH: 19px" borderColor="#000000" align="center" width="19"><FONT face="Tahoma" size="2">m.</FONT></TD>
										<TD borderColor="#000000"><FONT face="Tahoma" size="2">Dokumen tambahan untuk KMK 
												Kontraktor :</FONT></TD>
									</TR>
									<TR>
										<TD width="3%"><FONT face="Tahoma" size="2"></FONT></TD>
										<TD style="WIDTH: 19px" borderColor="#000000" align="center" width="19"><FONT face="Tahoma" size="2"></FONT></TD>
										<TD borderColor="#000000"><FONT face="Tahoma" size="2">&nbsp;- Realisasi proyek 12 
												bulan terakhir</FONT></TD>
									</TR>
									<TR>
										<TD width="3%"><FONT face="Tahoma" size="2"></FONT></TD>
										<TD style="WIDTH: 19px" borderColor="#000000" align="center" width="19"><FONT face="Tahoma" size="2"></FONT></TD>
										<TD borderColor="#000000"><FONT face="Tahoma" size="2">&nbsp;- Rencana proyek yang akan 
												dikerjakan 12 bulan yad</FONT></TD>
									</TR>
									<TR>
										<TD width="3%"><FONT face="Tahoma" size="2"></FONT></TD>
										<TD style="WIDTH: 19px" borderColor="#000000" align="center" width="19"><FONT face="Tahoma" size="2"></FONT></TD>
										<TD borderColor="#000000"><FONT face="Tahoma" size="2">&nbsp;- Rencana biaya proyek 
												yang akan dikerjakan 12 bulan yad</FONT></TD>
									</TR>
									<TR>
										<TD width="3%"><FONT face="Tahoma" size="2"></FONT></TD>
										<TD style="WIDTH: 19px" borderColor="#000000" align="center" width="19"><FONT face="Tahoma" size="2"></FONT></TD>
										<TD borderColor="#000000"><FONT face="Tahoma" size="2">&nbsp;- Kontrak kerja proyek 
												yang akan dibiayai</FONT></TD>
									</TR>
									<TR>
										<TD width="3%"><FONT face="Tahoma" size="2"></FONT></TD>
										<TD style="WIDTH: 19px" borderColor="#000000" align="center" width="19"><FONT face="Tahoma" size="2">n.</FONT></TD>
										<TD borderColor="#000000"><FONT face="Tahoma" size="2">Dokumen tambahan untuk KI :</FONT></TD>
									</TR>
									<TR>
										<TD width="3%"><FONT face="Tahoma" size="2"></FONT></TD>
										<TD style="WIDTH: 19px" borderColor="#000000" align="center" width="19"><FONT face="Tahoma" size="2"></FONT></TD>
										<TD borderColor="#000000"><FONT face="Tahoma" size="2">&nbsp;- Rincian biaya investasi, 
												sumber pelunasan</FONT></TD>
									</TR>
									<TR>
										<TD width="3%"><FONT face="Tahoma" size="2"></FONT></TD>
										<TD style="WIDTH: 19px" borderColor="#000000" align="center" width="19"><FONT face="Tahoma" size="2"></FONT></TD>
										<TD borderColor="#000000"><FONT face="Tahoma" size="2">&nbsp;- Spesifikasi obyek</FONT></TD>
									</TR>
									<TR>
										<TD width="3%"><FONT face="Tahoma" size="2"></FONT></TD>
										<TD style="WIDTH: 19px" borderColor="#000000" align="center" width="19"><FONT face="Tahoma" size="2">o.</FONT></TD>
										<TD borderColor="#000000"><FONT face="Tahoma" size="2">Dokumen tambahan untuk NCL :</FONT></TD>
									</TR>
									<TR>
										<TD width="3%"><FONT face="Tahoma" size="2"></FONT></TD>
										<TD style="WIDTH: 19px" borderColor="#000000" align="center" width="19"><FONT face="Tahoma" size="2"></FONT></TD>
										<TD borderColor="#000000"><FONT face="Tahoma" size="2">&nbsp;- Kontrak / SPPK / PO / 
												undangan tender</FONT></TD>
									</TR>
									<TR>
										<TD width="3%"><FONT face="Tahoma" size="2"></FONT></TD>
										<TD style="WIDTH: 19px" borderColor="#000000" align="center" width="19"><FONT face="Tahoma" size="2"></FONT></TD>
										<TD borderColor="#000000"><FONT face="Tahoma" size="2">&nbsp;- Kontrak / Dokumen dasar 
												penerbitan LC atau SKBDN </FONT>
										</TD>
									</TR>
									<TR>
										<TD width="3%"></TD>
										<TD style="WIDTH: 19px" borderColor="#000000" align="center" width="19"></TD>
										<TD borderColor="#000000"></TD>
									</TR>
									<TR>
										<TD width="3%"></TD>
										<TD borderColor="#000000" align="center" width="19"></TD>
										<TD borderColor="#000000"><U><FONT style="TEXT-ALIGN: justify" face="Tahoma" size="2">Ket:</FONT></U>&nbsp;&nbsp;<FONT style="VERTICAL-ALIGN: super" size="1">1)</FONT>
											Tidak diperlukan apabila permohonan kredit s/d Rp 50 juta</TD>
									</TR>
								</TABLE>
							</asp:panel></TD>
						<TD vAlign="top" align="center" width="100%" style="HEIGHT: 673px"></TD>
					</TR>
					<TR>
						<TD width="3%" style="HEIGHT: 71px"></TD>
						<TD align="justified" width="100%" style="HEIGHT: 71px">
							<TABLE id="Table6" cellSpacing="0" cellPadding="0" width="100%" border="0">
								<TR>
									<TD width="3%"><FONT face="Tahoma" size="2">2. </FONT>
									</TD>
									<TD><FONT face="Tahoma" size="2">Bank telah melakukan verifikasi data / dokumen pemohon 
											dan seluruh data tersebut telah dibuktikan kebenarannya</FONT></TD>
								</TR>
								<TR>
									<TD width="3%"><FONT face="Tahoma" size="2">3.</FONT></TD>
									<TD><FONT face="Tahoma" size="2">Bank telah melakukan penilaian / appraisal atas agunan 
											kredit pemohon dan hasilnya memenuhi ketentuan yang berlaku</FONT></TD>
								</TR>
							</TABLE>
						</TD>
						<TD style="HEIGHT: 71px" width="100%"></TD>
					</TR>
					<TR>
						<TD width="3%"></TD>
						<TD align="justified" width="100%">
							<P><FONT face="Tahoma" size="2" style="TEXT-ALIGN: justify">Dalam hal dokumen yang 
									dipersyaratkan untuk keperluan permohonan fasilitas kredit ini adalah dalam 
									bentuk copy, maka Saudara berkewajiban untuk menunjukan kepada Bank asli 
									dokumen dimaksud.</FONT></P>
						</TD>
						<TD width="100%"></TD>
					</TR>
					<TR>
						<TD width="3%"></TD>
						<TD align="justified" width="100%"><FONT face="Tahoma" size="2"></FONT></TD>
						<TD width="100%"></TD>
					</TR>
					<TR>
						<TD style="HEIGHT: 30px" width="3%"></TD>
						<TD align="justified" width="100%" style="HEIGHT: 30px"><FONT face="Tahoma" size="2" style="TEXT-ALIGN: justify">Apabila 
								dokumen-dokumen sebagaimana tersebut diatas telah Saudara sampaikan kepada Bank 
								pada waktu penyampaian aplikasi kredit, maka Saudara tidak perlu menyampaikan 
								dokumen-dokumen dimaksud.</FONT></TD>
						<TD style="HEIGHT: 30px" width="100%"></TD>
					</TR>
					<TR>
						<TD width="3%"></TD>
						<TD align="justified" width="100%"><FONT face="Tahoma" size="2"></FONT></TD>
						<TD width="100%"></TD>
					</TR>
					<TR>
						<TD width="3%"></TD>
						<TD align="justified" width="100%"><FONT face="Tahoma" size="2">Apabila dari hasil 
								verifikasi diketahui salah satu dokumen Saudara tidak benar dan atau hasil 
								verifikasi tidak memenuhi ketentuan yang berlaku di Bank, maka Bank berhak 
								untuk menolak permohonan Kredit
								<asp:label id="LBL_PRODUCTDESC3" runat="server" MaxLength="100" ForeColor="#0000C0" ReadOnly="True"
									Font-Size="X-Small"></asp:label>
								&nbsp;Saudara.</FONT></TD>
						<TD width="100%"></TD>
					</TR>
					<TR>
						<TD width="3%"></TD>
						<TD align="justified" width="100%"><FONT face="Tahoma" size="2"></FONT></TD>
						<TD width="100%"></TD>
					</TR>
					<TR>
						<TD width="3%"></TD>
						<TD align="justified" width="100%"><FONT face="Tahoma" size="2" style="TEXT-ALIGN: justify">Apabila 
								telah terdapat kelengkapan data dan dokumen dari Saudara sebagaimana telah 
								diuraikan diatas yang didukung dengan Verifikasi dari bank terhadap kebenaran 
								data dan dokumen dimaksud serta adanya hasil penilaian yang memadai terhadap 
								barang agunan kredit saudara, maka Bank akan memberikan surat ditindak lanjuti 
								dengan penandatangan Perjanjian Kredit.</FONT></TD>
						<TD width="100%"></TD>
					</TR>
					<TR>
						<TD width="3%"></TD>
						<TD align="justified" width="100%"><FONT face="Tahoma" size="2"></FONT></TD>
						<TD width="100%"></TD>
					</TR>
					<TR>
						<TD width="3%"></TD>
						<TD align="justified" width="100%"><FONT face="Tahoma" size="2">Dalam hal menolak 
								permohonan kredit Saudara, maka :</FONT></TD>
						<TD width="100%"></TD>
					</TR>
					<TR>
						<TD width="3%"></TD>
						<TD align="justified" width="100%">
							<TABLE id="Table7" cellSpacing="0" cellPadding="0" width="100%" border="0">
								<TR>
									<TD width="3%"><FONT face="Tahoma" size="2">&nbsp;-</FONT></TD>
									<TD><FONT face="Tahoma" size="2">Bank tidak wajib mengembalikan seluruh dokumen yang 
											telah diserahkan tersebut kepada Saudara.</FONT></TD>
								</TR>
								<TR>
									<TD width="3%"><FONT face="Tahoma" size="2">&nbsp;-</FONT></TD>
									<TD><FONT face="Tahoma" size="2">Bank tidak mengembalikan biaya penilaian/appraisal 
											agunan yang telah dibayar oleh Saudara.</FONT></TD>
								</TR>
								<TR>
									<TD width="3%" vAlign="top"><FONT face="Tahoma" size="2">&nbsp;-</FONT></TD>
									<TD><FONT face="Tahoma" size="2">Saudara selaku pemohon dengan ini membebaskan Bank 
											dari segala tanggung jawab hukum atau kerugian yang mungkin timbul sehubungan 
											dengan pernyataan dalam surat ini. </FONT>
									</TD>
								</TR>
							</TABLE>
						</TD>
						<TD width="100%"></TD>
					</TR>
					<TR>
						<TD width="3%"></TD>
						<TD align="justified" width="100%"><FONT face="Tahoma" size="2">Demikian disampaikan, 
								atas perhatian dan kerjasama Saudara kami ucapkan terima kasih.</FONT></TD>
						<TD width="100%"></TD>
					</TR>
					<TR>
						<TD width="3%"></TD>
						<TD align="justified" width="100%">
							<P><FONT face="Tahoma" size="2"></FONT>&nbsp;</P>
							<P><FONT face="Tahoma" size="2"></FONT>&nbsp;</P>
						</TD>
						<TD width="100%"></TD>
					</TR>
					<TR>
						<TD width="3%"></TD>
						<TD align="justified" width="100%">
							<P><FONT size="2"><FONT face="Tahoma"><STRONG>PT. BANK MANDIRI (Persero) Tbk</STRONG> </FONT>
								</FONT>
							</P>
						</TD>
						<TD width="100%"></TD>
					</TR>
					<TR>
						<TD width="3%"></TD>
						<TD width="100%">
							<asp:label id="LBL_BRANCH" runat="server" ForeColor="#0000C0" Font-Size="X-Small" MaxLength="100"></asp:label>
						</TD>
						<TD width="100%"></TD>
					</TR>
					<TR>
						<TD style="HEIGHT: 101px" vAlign="bottom" width="3%"></TD>
						<TD style="HEIGHT: 101px" vAlign="bottom" width="100%">
							<asp:label id="LBL_OFFICER" runat="server" ForeColor="#0000C0" Font-Size="X-Small" MaxLength="100"></asp:label></TD>
						<TD style="HEIGHT: 101px" vAlign="bottom" width="100%"></TD>
					</TR>
					<TR>
						<TD width="3%"></TD>
						<TD width="100%"><FONT face="Tahoma" size="2">
								<asp:label id="LBL_BO" runat="server" ForeColor="#0000C0" Font-Size="X-Small" MaxLength="100"></asp:label></FONT></TD>
						<TD width="100%"></TD>
					</TR>
					<TR>
						<TD align="center" width="3%"></TD>
						<TD align="center" width="100%"></FONT>
						</TD>
						<TD align="center" width="100%"></TD>
					</TR>
					<tr>
						<TD align="center" width="3%"></TD>
						<td align="center" width="100%">&nbsp;&nbsp;&nbsp;</td>
						<TD align="center" width="100%"></TD>
					</tr>
				</TABLE>
		</form>
		<CENTER></CENTER>
		</TD></TR></TBODY></TABLE></CENTER>
	</body>
</HTML>
