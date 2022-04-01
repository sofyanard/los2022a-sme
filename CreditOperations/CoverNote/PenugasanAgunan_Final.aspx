<%@ Page language="c#" Codebehind="PenugasanAgunan_Final.aspx.cs" AutoEventWireup="True" Inherits="SME.CreditProposal.PenugasaAgunan_Final" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>Surat Penugasan Agunan</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../style.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body leftMargin="0" topMargin="0" MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<center>
				<TABLE cellSpacing="2" cellPadding="2" width="100%">
					<TR>
						<TD class="TDBGColor2" style="WIDTH: 115px" align="center"></TD>
						<TD align="center" style="WIDTH: 529px"><INPUT id="BTN_PRINT" style="WIDTH: 101px; HEIGHT: 24px" onclick="javascript:window.print();"
								type="button" value="Print" name="BTNCANCEL">&nbsp;<INPUT id="BTNCANCEL" style="WIDTH: 101px; HEIGHT: 24px" type="button" value="Cancel" onclick="javascript:history.back(-1)">&nbsp;<INPUT id="BTN_CLOSE" style="WIDTH: 101px; HEIGHT: 24px" onclick="javascript:window.close();"
								type="button" value="Close" name="Button1"></TD>
						<TD class="TDBGColor2" align="center"></TD>
					</TR>
					<tr>
						<TD style="WIDTH: 111px; HEIGHT: 81px"></TD>
						<td style="WIDTH: 529px; HEIGHT: 81px">
							<TABLE id="Table1" cellSpacing="1" cellPadding="1" width="496" border="0" style="WIDTH: 496px; HEIGHT: 67px">
								<TR>
									<TD style="WIDTH: 87px"><FONT face="Tahoma" size="2">Nomor</FONT></TD>
									<TD style="WIDTH: 8px"><FONT face="Tahoma" size="2">:</FONT></TD>
									<TD><FONT face="Tahoma" size="2">
											<asp:Label id="LBL_NO_SURAT" runat="server" Width="296px" ForeColor="Blue" Font-Size="X-Small"
												Font-Names="Tahoma" Height="8px"></asp:Label></FONT></TD>
								</TR>
								<TR>
									<TD style="WIDTH: 87px"><FONT face="Tahoma" size="2">Tanggal</FONT></TD>
									<TD style="WIDTH: 8px"><FONT face="Tahoma" size="2">:</FONT></TD>
									<TD><FONT size="2"><FONT face="Tahoma">
												<asp:Label id="LBL_TANGGAL" runat="server" Width="296px" ForeColor="Blue" Font-Size="X-Small"
													Font-Names="Tahoma" Height="8px"></asp:Label></FONT></FONT></TD>
								</TR>
								<TR>
									<TD style="WIDTH: 87px"><FONT face="Tahoma" size="2">Lampiran</FONT></TD>
									<TD style="WIDTH: 8px"><FONT face="Tahoma" size="2">:</FONT></TD>
									<TD><FONT size="2">
											<asp:Label id="LBL_LAMPIRAN" runat="server" Height="8px" Font-Names="Tahoma" Font-Size="X-Small"
												ForeColor="Blue"></asp:Label></FONT></TD>
								</TR>
							</TABLE>
							<BR>
						</td>
						<TD style="HEIGHT: 81px"></TD>
					</tr>
					<tr>
						<TD style="WIDTH: 111px"></TD>
						<td style="WIDTH: 529px"><FONT face="Tahoma"><FONT size="2">Kepada Yth :</FONT>
								<BR>
							</FONT>
							<asp:Label id="LBL_NAMA_APPRAISER" runat="server" Width="464px" ForeColor="Blue" Font-Size="X-Small"
								Font-Names="Tahoma" Height="8px"></asp:Label><BR>
							<asp:Label id="LBL_ALAMAT1_APPRAISER" runat="server" Width="464px" ForeColor="Blue" Font-Size="X-Small"
								Font-Names="Tahoma" Height="8px"></asp:Label><BR>
							<asp:Label id="LBL_ALAMAT2_APPRAISER" runat="server" Width="464px" ForeColor="Blue" Font-Size="X-Small"
								Font-Names="Tahoma" Height="8px"></asp:Label><BR>
							<asp:Label id="LBL_ALAMAT3_APPRAISER" runat="server" Width="464px" ForeColor="Blue" Font-Size="X-Small"
								Font-Names="Tahoma" Height="8px"></asp:Label><BR>
							<asp:Label id="LBL_TELP_APPRAISER" runat="server" Width="464px" ForeColor="Blue" Font-Size="X-Small"
								Font-Names="Tahoma" Height="8px"></asp:Label><BR>
							<BR>
						</td>
						<TD></TD>
					</tr>
					<TR>
						<TD style="WIDTH: 111px"></TD>
						<TD style="WIDTH: 529px"><FONT face="Tahoma" size="2">u.p.
								<asp:Label id="LBL_UP" runat="server" Width="464px" ForeColor="Blue" Font-Size="X-Small" Font-Names="Tahoma"
									Height="8px"></asp:Label>
							</FONT>
							<BR>
							<BR>
						</TD>
						<TD></TD>
					</TR>
					<tr>
						<TD style="WIDTH: 111px"></TD>
						<td style="WIDTH: 529px"><FONT face="Georgia" size="2"><FONT face="Tahoma">Perihal :&nbsp;
									<asp:Label id="LBL_PERIHAL" runat="server" Width="464px" ForeColor="Blue" Font-Size="X-Small"
										Font-Names="Tahoma" Height="8px"></asp:Label></FONT></FONT>
							<BR>
							<BR>
						</td>
						<TD></TD>
					</tr>
					<tr>
						<TD style="WIDTH: 111px; HEIGHT: 19px"></TD>
						<td style="WIDTH: 529px; HEIGHT: 19px"><FONT face="Tahoma" size="2">Dengan hormat,<BR>
								<BR>
							</FONT>
						</td>
						<TD style="HEIGHT: 19px"></TD>
					</tr>
					<tr>
						<TD style="WIDTH: 111px; HEIGHT: 100px"></TD>
						<td style="VERTICAL-ALIGN: baseline; WIDTH: 529px; HEIGHT: 100px; TEXT-ALIGN: justify">
							<P><FONT size="2"><FONT face="Tahoma">Menunjuk Surat Saudara No.
										<asp:Label id="LBL_NO_SURAT_REF" runat="server" ForeColor="Blue" Font-Size="X-Small" Font-Names="Tahoma"
											Height="8px"></asp:Label>&nbsp;tanggal&nbsp;
										<asp:Label id="LBL_TGL_SURAT_REF" runat="server" ForeColor="Blue" Font-Size="X-Small" Font-Names="Tahoma"
											Height="8px"></asp:Label>&nbsp;perihal Proposal Jasa Konsultan Penilaian, 
										dengan ini kami menugaskan kepada perusahaan Saudara untuk melakukan penilaian 
										terhadap agunan kredit (calon) Debitur kami dengan penjelasan sebagai berikut :<BR>
										<BR>
										<TABLE id="Table2" cellSpacing="0" cellPadding="0" width="100%" border="0">
											<TBODY>
												<TR>
													<TD style="WIDTH: 17px" vAlign="top"><FONT size="2">1.</FONT></TD>
													<TD style="TEXT-ALIGN: justify"><FONT size="2">Saat ini kami memerlukan jasa penilai 
															agunan yang tepat dan akurat untuk menilai agunan kredit (calon) Debitur yang 
															umumnya berupa kendaraan, ruko/kios atau tanah/bangunan/rumah yang berlokasi di 
															perumahan/komplek di sekitar Jabotabek.<BR>
														</FONT>
													</TD>
												</TR>
												<TR>
													<TD style="WIDTH: 17px" vAlign="top"><FONT size="2">2.</FONT></TD>
													<TD style="TEXT-ALIGN: justify"><FONT size="2">Untuk itu, kami bermaksud melakukan 
															kerjasama dengan Saudara dalam penilaian agunan kredit (calon) debitur kami 
															dengan penjelasan sebagai berikut :<BR>
															<TABLE id="Table3" cellSpacing="0" cellPadding="0" width="100%" border="0">
																<TR>
																	<TD style="WIDTH: 17px" vAlign="top"><FONT size="2">a.</FONT></TD>
																	<TD style="TEXT-ALIGN: justify"><FONT size="2">Ruang lingkup penilaian, bentuk laporan 
																			hasil penilaian agunan, dan metode/tata cara perhitungan minimal yang harus 
																			dipergunakan pada prinsipnya sama dengan Consumer Loan Group PT. Bank Mandiri 
																			(Persero). </FONT>
																	</TD>
																</TR>
																<TR>
																	<TD style="WIDTH: 17px" vAlign="top"><FONT size="2">b.</FONT></TD>
																	<TD style="TEXT-ALIGN: justify"><FONT size="2">Penilaian agunan (calon) debitur 
																			dilakukan setelah adanya permintaan dan penugasan tertulis dari kami. </FONT>
																	</TD>
																</TR>
																<TR>
																	<TD style="WIDTH: 17px" vAlign="top"><FONT size="2">c.</FONT></TD>
																	<TD style="TEXT-ALIGN: justify"><FONT size="2">Laporan hasil penilaian agunan (calon) 
																			debitur disampaikan kepada kami dalam 2 (dua) rangkap dan dilengkapi dengan 
																			foto fisik agunan. </FONT>
																	</TD>
																</TR>
																<TR>
																	<TD style="WIDTH: 17px" vAlign="top"><FONT size="2">d.</FONT></TD>
																	<TD style="TEXT-ALIGN: justify"><FONT size="2">Pembayaran biaya penilaian agunan 
																			dilakukan selambat-lambatnya
																			<asp:Label id="LBL_WAKTU_BAYAR" runat="server" ForeColor="Blue" Font-Size="X-Small" Font-Names="Tahoma"
																				Height="8px"></asp:Label>&nbsp;(
																			<asp:Label id="LBL_WAKTU_BAYAR_BILANG" runat="server" ForeColor="Blue" Font-Size="X-Small"
																				Font-Names="Tahoma" Height="8px"></asp:Label>&nbsp;) minggu setelah asli 
																			laporan hasil penilaian agunan kami terima, secara giral ke rekening Saudara. </FONT>
																	</TD>
																</TR>
															</TABLE>
														</FONT>
													</TD>
												</TR>
												<TR>
													<TD style="WIDTH: 17px" vAlign="top"><FONT size="2">3.</FONT></TD>
													<TD><FONT size="2">Obyek yang akan Saudara nilai sebanyak (perincian terlampir) :<BR>
															<TABLE id="Table4" cellSpacing="0" cellPadding="0" width="100%" border="0">
																<TR>
																	<TD style="WIDTH: 17px"><FONT size="2">a.</FONT></TD>
																	<TD style="WIDTH: 232px"><FONT size="2">
																			<asp:Label id="LBL_NAMA_COLLATERAL" runat="server" ForeColor="Blue" Font-Size="X-Small" Font-Names="Tahoma"
																				Height="8px"></asp:Label>
																		</FONT>
																	</TD>
																	<TD><FONT size="2"><FONT size="2">=&nbsp;
																				<asp:Label id="LBL_JUMLAH_COLL" runat="server" ForeColor="Blue" Font-Size="X-Small" Font-Names="Tahoma"
																					Height="8px"></asp:Label>
																				&nbsp;obyek</FONT></FONT></TD>
																</TR>
															</TABLE>
														</FONT>
													</TD>
												</TR>
												<TR>
													<TD style="WIDTH: 17px" vAlign="top"><FONT size="2">4.</FONT></TD>
													<TD style="TEXT-ALIGN: justify"><FONT size="2">Hasil penilaian agunan tersebut, agar 
															dilaporkan kepada kami dalam jangka waktu selambat-lambatnya
															<asp:Label id="LBL_WAKTU_LAPORAN" runat="server" ForeColor="Blue" Font-Size="X-Small" Font-Names="Tahoma"
																Height="8px"></asp:Label>&nbsp;(
															<asp:Label id="LBL_WAKTU_LAPORAN_BILANG" runat="server" ForeColor="Blue" Font-Size="X-Small"
																Font-Names="Tahoma" Height="8px"></asp:Label>&nbsp;) hari kerja setelah 
															Saudara terima surat pelaksanaan kerja ini.<BR>
														</FONT>
													</TD>
												</TR>
												<TR>
													<TD style="WIDTH: 17px" vAlign="top"><FONT size="2">5.</FONT></TD>
													<TD><FONT size="2">Fee atas penilaian obyek agunan sebagai berikut :<BR>
															<TABLE id="Table5" cellSpacing="0" cellPadding="0" width="100%" border="0">
																<TBODY>
																	<TR>
																		<TD style="WIDTH: 15px" vAlign="top"><FONT size="2">a.</FONT></TD>
																		<TD vAlign="top"><FONT size="2">
																				<asp:Label id="LBL_NAMA_COLL_FEE" runat="server" ForeColor="Blue" Font-Size="X-Small" Font-Names="Tahoma"
																					Height="8px"></asp:Label>&nbsp;: Rp.
																				<asp:Label id="LBL_COLL_FEE" runat="server" ForeColor="Blue" Font-Size="X-Small" Font-Names="Tahoma"
																					Height="8px"></asp:Label>&nbsp;per obyek. </FONT>
																		</TD>
																	</TR>
																</TBODY>
															</TABLE>
														</FONT>
													</TD>
												</TR>
												<TR>
													<TD style="WIDTH: 17px" vAlign="top"><FONT size="2">6.</FONT></TD>
													<TD><FONT size="2">Lain - lain :<BR>
															<TABLE id="Table6" cellSpacing="0" cellPadding="0" width="100%" border="0">
																<TR>
																	<TD style="WIDTH: 15px" vAlign="top"><FONT size="2">a.</FONT></TD>
																	<TD style="TEXT-ALIGN: justify"><FONT size="2">PT. Bank Mandiri (Persero) tidak 
																			bertanggung jawab terhadap kemungkinan terjadinya kerugian Saudara atas 
																			pekerjaan yang sedang Saudara laksanakan.<BR>
																		</FONT>
																	</TD>
																</TR>
																<TR>
																	<TD style="WIDTH: 15px" vAlign="top"><FONT size="2">b.</FONT></TD>
																	<TD style="TEXT-ALIGN: justify"><FONT size="2">Saudara berkewajiban untuk merahasiakan 
																			segala informasi/keterangan dan catatan yang diperoleh dari PT. Bank Mandiri 
																			(Persero), dan melarang Saudara untuk menggunakan informasi tersebut diluar 
																			tugas yang diberikan oleh kami. </FONT>
																	</TD>
																</TR>
															</TABLE>
														</FONT>
													</TD>
												</TR>
											</TBODY>
										</TABLE>
									</FONT></FONT>
							</P>
						</td>
						<TD style="HEIGHT: 100px"></TD>
					</tr>
					<tr>
						<TD style="WIDTH: 111px"></TD>
						<td style="VERTICAL-ALIGN: baseline; WIDTH: 529px; TEXT-ALIGN: justify"><FONT face="Tahoma" size="2">Sebagai 
								tanda diterimanya pekerjaan ini, harap Saudara sampaikan kembali tembusan surat 
								ini setelah ditandatangai.<BR>
								<BR>
							</FONT>
						</td>
						<TD></TD>
					</tr>
					<tr>
						<TD style="WIDTH: 111px"></TD>
						<td style="WIDTH: 529px"><FONT face="Tahoma" size="2">Demikian, terima kasih atas 
								perhatian dan kerjasama baik Saudara.
								<BR>
								<BR>
								<BR>
							</FONT>
						</td>
						<TD></TD>
					</tr>
					<tr>
						<TD style="WIDTH: 111px"></TD>
						<td style="WIDTH: 529px"><FONT face="Tahoma" size="2">Hormat kami,<BR>
								<STRONG>PT. BANK MANDIRI (PERSERO)</STRONG></FONT></td>
						<TD><STRONG></STRONG></TD>
					</tr>
					<tr>
						<TD style="WIDTH: 111px"><STRONG></STRONG></TD>
						<td style="WIDTH: 529px"><STRONG><FONT face="Georgia" size="2">
									<asp:Label id="LBL_JCCO_TTD" runat="server" Width="457" ForeColor="Blue" Font-Size="X-Small"
										Font-Names="Tahoma" Height="8px"></asp:Label></FONT></STRONG></td>
						<TD><STRONG></STRONG></TD>
					</tr>
					<tr>
						<TD style="WIDTH: 111px"><STRONG></STRONG></TD>
						<td style="WIDTH: 529px"><STRONG><FONT face="Georgia" size="2">
									<asp:Label id="LBL_ALAMAT_JCCO_TTD" runat="server" Width="457px" ForeColor="Blue" Font-Size="X-Small"
										Font-Names="Tahoma" Height="8px"></asp:Label></FONT></STRONG></td>
						<TD></TD>
					</tr>
					<tr>
						<TD style="WIDTH: 111px"></TD>
						<td style="WIDTH: 529px">
							<P><BR>
								<BR>
								<STRONG>&nbsp;</STRONG></P>
						</td>
						<TD></TD>
					</tr>
					<tr>
						<TD style="WIDTH: 111px"></TD>
						<td style="WIDTH: 529px"><STRONG><U><FONT face="Georgia" size="2">
										<asp:Label id="LBL_NAMA_TTD" runat="server" Width="457px" ForeColor="Blue" Font-Size="X-Small"
											Font-Names="Tahoma" Height="8px"></asp:Label></FONT></U></STRONG></td>
						<TD></TD>
					</tr>
					<tr>
						<TD style="WIDTH: 111px; HEIGHT: 23px"></TD>
						<td style="WIDTH: 529px; HEIGHT: 23px"><STRONG><FONT face="Georgia" size="2">
									<asp:Label id="LBL_DEPT_TTD" runat="server" Width="457px" ForeColor="Blue" Font-Size="X-Small"
										Font-Names="Tahoma" Height="8px"></asp:Label></FONT></STRONG></td>
						<TD style="HEIGHT: 23px"></TD>
					</tr>
					<tr>
						<TD style="WIDTH: 111px"></TD>
						<td style="WIDTH: 529px"></td>
						<TD></TD>
					</tr>
					<TR>
						<TD class="TDBGColor2" style="WIDTH: 111px" align="center"></TD>
						<TD align="center" style="WIDTH: 529px"></TD>
						<TD class="TDBGColor2" align="center"></TD>
					</TR>
				</TABLE>
			</center>
		</form>
	</body>
</HTML>
