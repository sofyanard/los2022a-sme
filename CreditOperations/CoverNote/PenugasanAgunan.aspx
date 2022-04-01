<%@ Page language="c#" Codebehind="PenugasanAgunan.aspx.cs" AutoEventWireup="True" Inherits="SME.CreditProposal.PenugasanAgunan" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>Surat Penugasan Agunan</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../style.css" type="text/css" rel="stylesheet">
		<!-- #include file="../../include/cek_all.html" -->
	</HEAD>
	<body leftMargin="0" topMargin="0" MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<center>
				<TABLE cellSpacing="2" cellPadding="2" width="100%">
					<TR>
						<TD style="WIDTH: 115px" align="center"></TD>
						<TD align="center" style="WIDTH: 529px">
							<asp:button id="BTN_VIEW" Runat="server" Text="View" Width="100px" onclick="BTN_VIEW_Click"></asp:button>&nbsp;<INPUT id="BTN_CLOSE" style="WIDTH: 101px; HEIGHT: 24px" onclick="javascript:window.close();"
								type="button" value="Close" name="BTNCANCEL"></TD>
						<TD align="center"></TD>
					</TR>
					<tr>
						<TD style="WIDTH: 111px; HEIGHT: 81px"></TD>
						<td style="WIDTH: 529px; HEIGHT: 81px">
							<TABLE id="Table1" cellSpacing="1" cellPadding="1" width="496" border="0" style="WIDTH: 496px; HEIGHT: 67px">
								<TR>
									<TD style="WIDTH: 87px"><FONT face="Tahoma" size="2">Nomor</FONT></TD>
									<TD style="WIDTH: 8px"><FONT face="Tahoma" size="2">:</FONT></TD>
									<TD>
										<asp:TextBox id="TXT_NO_SURAT" runat="server" Width="384px" Height="21px" Font-Names="Tahoma"
											Font-Size="X-Small" ForeColor="Blue">DNW.JCK.JCO/            /2003</asp:TextBox><FONT face="Tahoma"></FONT></TD>
								</TR>
								<TR>
									<TD style="WIDTH: 87px"><FONT face="Tahoma" size="2">Tanggal</FONT></TD>
									<TD style="WIDTH: 8px"><FONT face="Tahoma" size="2">:</FONT></TD>
									<TD>
										<asp:TextBox id="TXT_TANGGAL" runat="server" Width="112px" Height="21px" Font-Names="Tahoma"
											Font-Size="X-Small" ForeColor="Blue" ReadOnly="True" BorderColor="Black"></asp:TextBox><FONT face="Tahoma"></FONT></TD>
								</TR>
								<TR>
									<TD style="WIDTH: 87px"><FONT face="Tahoma" size="2">Lampiran</FONT></TD>
									<TD style="WIDTH: 8px"><FONT face="Tahoma" size="2">:</FONT></TD>
									<TD>
										<asp:TextBox id="TXT_LAMPIRAN" runat="server" Width="112px" ForeColor="Blue" Font-Size="X-Small"
											Font-Names="Tahoma" Height="22px">-</asp:TextBox></TD>
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
							<asp:TextBox id="TXT_NAMA_APPRAISER" runat="server" Width="384px" Height="21px" Font-Names="Tahoma"
								Font-Size="X-Small" ForeColor="Blue" ReadOnly="True" BorderColor="Black"></asp:TextBox><BR>
							<asp:TextBox id="TXT_ALAMAT1_APPRAISER" runat="server" Width="384px" Height="20px" Font-Names="Tahoma"
								Font-Size="X-Small" ForeColor="Blue" ReadOnly="True" BorderColor="Black"></asp:TextBox><BR>
							<asp:TextBox id="TXT_ALAMAT2_APPRAISER" runat="server" Width="384px" Height="20px" Font-Names="Tahoma"
								Font-Size="X-Small" ForeColor="Blue" ReadOnly="True" BorderColor="Black"></asp:TextBox><BR>
							<asp:TextBox id="TXT_ALAMAT3_APPRAISER" runat="server" Width="384px" Height="20px" Font-Names="Tahoma"
								Font-Size="X-Small" ForeColor="Blue" ReadOnly="True" BorderColor="Black"></asp:TextBox><BR>
							<asp:TextBox id="TXT_TELP_APPRAISER" runat="server" Width="384px" Height="20px" Font-Names="Tahoma"
								Font-Size="X-Small" ForeColor="Blue" ReadOnly="True" BorderColor="Black"> Telp/Fax.</asp:TextBox><BR>
							<BR>
						</td>
						<TD></TD>
					</tr>
					<TR>
						<TD style="WIDTH: 111px"></TD>
						<TD style="WIDTH: 529px"><FONT face="Tahoma" size="2">u.p. </FONT>
							<asp:TextBox id="TXT_UP" runat="server" Width="384px" ForeColor="Blue" Font-Size="X-Small" Font-Names="Tahoma"
								Height="21px"></asp:TextBox><BR>
							<BR>
						</TD>
						<TD></TD>
					</TR>
					<tr>
						<TD style="WIDTH: 111px"></TD>
						<td style="WIDTH: 529px"><FONT face="Georgia" size="2"><FONT face="Tahoma">Perihal :&nbsp;
									<asp:TextBox id="TXT_PERIHAL" runat="server" Width="464px" ForeColor="Blue" Font-Size="X-Small"
										Font-Names="Tahoma" Height="21px">Pelaksanaan Kerja Penilaian Agunan Kredit (calon) Debitur Bank Mandiri</asp:TextBox></FONT></FONT>
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
										<asp:TextBox id="TXT_NO_SURAT_REF" runat="server" Width="176px" ForeColor="Blue" Font-Size="X-Small"
											Font-Names="Tahoma" Height="21px">198/SP/PP-PFF/VI/2003</asp:TextBox>
										tanggal
										<asp:TextBox id="TXT_TGL_SURAT_REF" runat="server" Width="120px" ForeColor="Blue" Font-Size="X-Small"
											Font-Names="Tahoma" Height="21px">4 Juni 2003</asp:TextBox>
										perihal Proposal Jasa Konsultan Penilaian, dengan ini kami menugaskan kepada 
										perusahaan Saudara untuk melakukan penilaian terhadap agunan kredit (calon) 
										Debitur kami dengan penjelasan sebagai berikut :<BR>
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
																			<asp:TextBox id="TXT_WAKTU_BAYAR" runat="server" Width="43px" ForeColor="Blue" Font-Size="X-Small"
																				Font-Names="Tahoma" Height="21px">2</asp:TextBox>
																			(
																			<asp:TextBox id="TXT_WAKTU_BAYAR_BILANG" runat="server" Width="75px" ForeColor="Blue" Font-Size="X-Small"
																				Font-Names="Tahoma" Height="21px">dua</asp:TextBox>&nbsp;) minggu setelah 
																			asli laporan hasil penilaian agunan kami terima, secara giral ke rekening 
																			Saudara. </FONT>
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
																	<TD><FONT size="2">
																			<asp:TextBox id="TXT_NAMA_COLLATERAL" runat="server" Width="272px" ForeColor="Blue" Font-Size="X-Small"
																				Font-Names="Tahoma" Height="21px" ReadOnly="True" BorderColor="Black">Tanah/Bangunan/Rumah</asp:TextBox>
																		</FONT>
																	</TD>
																	<TD><FONT size="2"><FONT size="2">=
																				<asp:TextBox id="TXT_JUMLAH_COLL" runat="server" Width="75px" ForeColor="Blue" Font-Size="X-Small"
																					Font-Names="Tahoma" Height="21px">1</asp:TextBox>
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
															<asp:TextBox id="TXT_WAKTU_LAPORAN" runat="server" Width="75px" ForeColor="Blue" Font-Size="X-Small"
																Font-Names="Tahoma" Height="21px">6</asp:TextBox>
															(
															<asp:TextBox id="TXT_WAKTU_LAPORAN_BILANG" runat="server" Width="75px" ForeColor="Blue" Font-Size="X-Small"
																Font-Names="Tahoma" Height="21px">enam</asp:TextBox>) hari kerja setelah 
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
																				<asp:TextBox id="TXT_NAMA_COLL_FEE" runat="server" Width="192px" ForeColor="Blue" Font-Size="X-Small"
																					Font-Names="Tahoma" Height="21px" ReadOnly="True" BorderColor="Black">Tanah/Bangunan/Rumah</asp:TextBox>
																				&nbsp;: Rp.
																				<asp:TextBox id="TXT_COLL_FEE" runat="server" Width="72px" ForeColor="Blue" Font-Size="X-Small"
																					Font-Names="Tahoma" Height="21px"></asp:TextBox>&nbsp;per obyek. </FONT>
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
						<td style="WIDTH: 529px"><STRONG><FONT face="Georgia" size="2"><EM>
										<asp:TextBox id="TXT_JCCO_TTD" runat="server" Width="232px" ForeColor="Blue" Font-Size="X-Small"
											Font-Names="Tahoma" Height="21px">Jakarta City Operations</asp:TextBox></EM></FONT></STRONG></td>
						<TD><STRONG></STRONG></TD>
					</tr>
					<tr>
						<TD style="WIDTH: 111px"><STRONG></STRONG></TD>
						<td style="WIDTH: 529px"><STRONG><FONT face="Georgia" size="2"><EM>
										<asp:TextBox id="TXT_ALAMAT_JCCO_TTD" runat="server" Width="232px" ForeColor="Blue" Font-Size="X-Small"
											Font-Names="Tahoma" Height="21px">Jakarta Sudirman</asp:TextBox></EM></FONT></STRONG></td>
						<TD></TD>
					</tr>
					<tr>
						<TD style="WIDTH: 111px"></TD>
						<td style="WIDTH: 529px">
							<P><BR>
								<BR>
								&nbsp;</P>
						</td>
						<TD></TD>
					</tr>
					<tr>
						<TD style="WIDTH: 111px"></TD>
						<td style="WIDTH: 529px"><STRONG><U><FONT face="Georgia" size="2"><EM>
											<asp:TextBox id="TXT_NAMA_TTD" runat="server" Width="232px" ForeColor="Blue" Font-Size="X-Small"
												Font-Names="Tahoma" Height="21px" Font-Underline="True">Basu Fitri Manugrahani</asp:TextBox></EM></FONT></U></STRONG></td>
						<TD></TD>
					</tr>
					<tr>
						<TD style="WIDTH: 111px"></TD>
						<td style="WIDTH: 529px"><STRONG><FONT face="Georgia" size="2"><EM>
										<asp:TextBox id="TXT_DEPT_TTD" runat="server" Width="232px" ForeColor="Blue" Font-Size="X-Small"
											Font-Names="Tahoma" Height="21px">JCO Manager</asp:TextBox></EM></FONT></STRONG></td>
						<TD></TD>
					</tr>
					<tr>
						<TD style="WIDTH: 111px"></TD>
						<td style="WIDTH: 529px"></td>
						<TD></TD>
					</tr>
					<TR>
						<TD style="WIDTH: 111px" align="center"></TD>
						<TD align="center" style="WIDTH: 529px">
							<asp:button id="BTN_VIEW_2" Runat="server" Text="View" Width="100px" onclick="BTN_VIEW_2_Click"></asp:button></TD>
						<TD align="center"></TD>
					</TR>
				</TABLE>
			</center>
		</form>
	</body>
</HTML>
