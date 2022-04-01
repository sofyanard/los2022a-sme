<%@ Page language="c#" Codebehind="AsuransiJaminan_Final.aspx.cs" AutoEventWireup="True" Inherits="SME.CreditOperations.AsuransiJaminan_Final" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>Asuransi Jaminan</title>
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
						<TD style="WIDTH: 115px" align="center"></TD>
						<TD align="center" style="WIDTH: 618px">&nbsp;&nbsp;</TD>
						<TD align="center"></TD>
					</TR>
					<tr>
						<TD style="WIDTH: 111px; HEIGHT: 81px"></TD>
						<td style="WIDTH: 618px; HEIGHT: 81px">
							<TABLE id="Table1" cellSpacing="1" cellPadding="1" width="496" border="0" style="WIDTH: 496px; HEIGHT: 67px">
								<TR>
									<TD style="WIDTH: 87px"><FONT face="Tahoma" size="2">Nomor</FONT></TD>
									<TD style="WIDTH: 8px"><FONT face="Tahoma" size="2">:</FONT></TD>
									<TD>
										<asp:Label id="LBL_NO_SURAT" runat="server" ForeColor="Blue" Font-Size="X-Small" Font-Names="Tahoma"
											Height="8px" Font-Bold="True"></asp:Label><FONT face="Tahoma"></FONT></TD>
								</TR>
								<TR>
									<TD style="WIDTH: 87px"><FONT face="Tahoma" size="2">Tanggal</FONT></TD>
									<TD style="WIDTH: 8px"><FONT face="Tahoma" size="2">:</FONT></TD>
									<TD>
										<asp:Label id="LBL_TANGGAL" runat="server" ForeColor="Blue" Font-Size="X-Small" Font-Names="Tahoma"
											Height="8px" Font-Bold="True"></asp:Label><FONT face="Tahoma"></FONT></TD>
								</TR>
								<TR>
									<TD style="WIDTH: 87px"><FONT face="Tahoma" size="2">Lampiran</FONT></TD>
									<TD style="WIDTH: 8px"><FONT face="Tahoma" size="2">:</FONT></TD>
									<TD>
										<asp:Label id="LBL_LAMPIRAN" runat="server" Font-Bold="True" Height="8px" Font-Names="Tahoma"
											Font-Size="X-Small" ForeColor="Blue"></asp:Label></TD>
								</TR>
							</TABLE>
							<BR>
						</td>
						<TD style="HEIGHT: 81px"></TD>
					</tr>
					<tr>
						<TD style="WIDTH: 111px"></TD>
						<td style="WIDTH: 618px"><FONT face="Tahoma"><FONT size="2"><STRONG>Kepada Yth :</STRONG></FONT>
								<BR>
							</FONT>
							<asp:Label id="LBL_NAMA_PT" runat="server" ForeColor="Blue" Font-Size="X-Small" Font-Names="Tahoma"
								Height="8px" Font-Bold="True"></asp:Label><BR>
							<asp:Label id="LBL_ALAMAT1_PT" runat="server" ForeColor="Blue" Font-Size="X-Small" Font-Names="Tahoma"
								Height="8px" Font-Bold="True"></asp:Label><BR>
							<asp:Label id="LBL_ALAMAT2_PT" runat="server" ForeColor="Blue" Font-Size="X-Small" Font-Names="Tahoma"
								Height="8px" Font-Bold="True"></asp:Label><BR>
							<asp:Label id="LBL_ALAMAT3_PT" runat="server" ForeColor="Blue" Font-Size="X-Small" Font-Names="Tahoma"
								Height="8px" Font-Bold="True"></asp:Label><BR>
							<asp:Label id="LBL_TELP_PT" runat="server" ForeColor="Blue" Font-Size="X-Small" Font-Names="Tahoma"
								Height="8px" Font-Bold="True"></asp:Label><BR>
							<BR>
							<BR>
						</td>
						<TD></TD>
					</tr>
					<TR>
						<TD style="WIDTH: 111px"></TD>
						<TD style="WIDTH: 618px"><FONT face="Tahoma" size="2">u.p. </FONT>
							<asp:Label id="LBL_UP" runat="server" ForeColor="Blue" Font-Size="X-Small" Font-Names="Tahoma"
								Height="8px" Font-Bold="True"></asp:Label><BR>
							<BR>
						</TD>
						<TD></TD>
					</TR>
					<tr>
						<TD style="WIDTH: 111px"></TD>
						<td style="WIDTH: 618px"><FONT face="Georgia" size="2"><FONT face="Tahoma">Perihal :&nbsp;<STRONG>Penutupan 
										asuransi agunan atas nama
										<asp:Label id="LBL_DEBITUR" runat="server" ForeColor="Blue" Font-Size="X-Small" Font-Names="Tahoma"
											Height="8px" Font-Bold="True"></asp:Label></STRONG></FONT></FONT>
							<BR>
							<BR>
						</td>
						<TD></TD>
					</tr>
					<tr>
						<TD style="WIDTH: 111px; HEIGHT: 19px"></TD>
						<td style="WIDTH: 618px; HEIGHT: 19px"><FONT face="Tahoma" size="2">Dengan hormat,<BR>
								<BR>
							</FONT>
						</td>
						<TD style="HEIGHT: 19px"></TD>
					</tr>
					<tr>
						<TD style="WIDTH: 111px; HEIGHT: 100px"></TD>
						<td style="VERTICAL-ALIGN: baseline; WIDTH: 619px; HEIGHT: 100px; TEXT-ALIGN: justify">
							<P><FONT size="2"><FONT face="Tahoma">Sehubungan dengan telah disetujuinya pemberian 
										penambahan fasilitas kredit kepada Debitur tersebut diatas, dengan ini kami 
										minta bantuan Saudara untuk melaksanakan penutupan asuransi dengan rincian 
										sebagai berikut :<BR>
										<BR>
										<TABLE id="Table2" cellSpacing="0" cellPadding="0" width="100%" border="0">
											<TBODY>
												<TR>
													<TD style="WIDTH: 13px; HEIGHT: 15px" vAlign="top"><FONT size="2">1.</FONT></TD>
													<TD style="WIDTH: 179px; HEIGHT: 15px" vAlign="top"><FONT size="2"><STRONG>Nama Tertanggung</STRONG></FONT></TD>
													<TD style="WIDTH: 10px; HEIGHT: 15px; TEXT-ALIGN: justify" vAlign="top"><FONT size="2">:</FONT></TD>
													<TD style="HEIGHT: 15px; TEXT-ALIGN: justify"><FONT size="2"><FONT size="2">
																<asp:Label id="LBL_NAMA_TANGGUNG" runat="server" ForeColor="Blue" Font-Size="X-Small" Font-Names="Tahoma"
																	Height="8px" Font-Bold="True"></asp:Label>
															</FONT></FONT>
													</TD>
												</TR>
												<TR>
													<TD style="WIDTH: 13px" vAlign="top"><FONT size="2">2.</FONT></TD>
													<TD style="WIDTH: 179px" vAlign="top"><FONT size="2">Alamat Tertanggung</FONT></TD>
													<TD style="WIDTH: 10px; TEXT-ALIGN: justify" vAlign="top"><FONT size="2">:</FONT></TD>
													<TD style="TEXT-ALIGN: justify"><FONT size="2">
															<asp:Label id="LBL_ALAMAT_TANGGUNG" runat="server" ForeColor="Blue" Font-Size="X-Small" Font-Names="Tahoma"
																Height="8px" Font-Bold="True"></asp:Label></FONT>
													</TD>
												</TR>
												<TR>
													<TD style="WIDTH: 13px; HEIGHT: 14px" vAlign="top"><FONT size="2">3.</FONT></TD>
													<TD style="WIDTH: 179px; HEIGHT: 14px" vAlign="top"><FONT size="2"><STRONG>Obyek 
																Pertanggungan</STRONG></FONT></TD>
													<TD style="WIDTH: 10px; HEIGHT: 14px" vAlign="top"><FONT size="2">:</FONT></TD>
													<TD style="HEIGHT: 14px"><FONT size="2">
															<asp:Label id="LBL_OBYEK_TANGGUNG" runat="server" ForeColor="Blue" Font-Size="X-Small" Font-Names="Tahoma"
																Height="8px" Font-Bold="True"></asp:Label></FONT>
													</TD>
												</TR>
												<TR>
													<TD style="WIDTH: 13px" vAlign="top"><FONT size="2">4.</FONT></TD>
													<TD style="WIDTH: 179px" vAlign="top"><FONT size="2">Nilai Pertanggungan</FONT></TD>
													<TD style="WIDTH: 10px; TEXT-ALIGN: justify" vAlign="top"><FONT size="2">:</FONT></TD>
													<TD style="TEXT-ALIGN: justify"><FONT size="2">Rp.&nbsp;
															<asp:Label id="LBL_NILAI_TANGGUNG" runat="server" ForeColor="Blue" Font-Size="X-Small" Font-Names="Tahoma"
																Height="8px" Font-Bold="True"></asp:Label>&nbsp;,-</FONT>
													</TD>
												</TR>
												<TR>
													<TD style="WIDTH: 13px" vAlign="top"><FONT size="2">5.</FONT></TD>
													<TD style="WIDTH: 179px" vAlign="top"><FONT size="2">Lokasi Pertanggungan</FONT></TD>
													<TD style="WIDTH: 10px" vAlign="top"><FONT size="2">:</FONT></TD>
													<TD><FONT size="2">
															<asp:Label id="LBL_LOKASI_TANGGUNG" runat="server" ForeColor="Blue" Font-Size="X-Small" Font-Names="Tahoma"
																Height="8px" Font-Bold="True"></asp:Label></FONT>
													</TD>
												</TR>
												<TR>
													<TD style="WIDTH: 13px" vAlign="top"><FONT size="2">6.</FONT></TD>
													<TD style="WIDTH: 179px" vAlign="top"><FONT size="2">Jangka Waktu Pertanggungan</FONT></TD>
													<TD style="WIDTH: 10px" vAlign="top"><FONT size="2">:</FONT></TD>
													<TD><FONT size="2">
															<asp:Label id="LBL_WAKTU_TANGGUNG" runat="server" ForeColor="Blue" Font-Size="X-Small" Font-Names="Tahoma"
																Height="8px" Font-Bold="True"></asp:Label>&nbsp;bulan tmt.penutupan 
															asuransi sejak diterimanya surat ini.</FONT>
													</TD>
												</TR>
												<TR>
													<TD style="WIDTH: 13px; HEIGHT: 13px" vAlign="top"><FONT size="2">7.</FONT></TD>
													<TD style="WIDTH: 179px; HEIGHT: 13px" vAlign="top"><FONT size="2"><STRONG>Banker's Clause</STRONG></FONT></TD>
													<TD style="WIDTH: 10px; HEIGHT: 13px" vAlign="top"><FONT size="2">:</FONT></TD>
													<TD style="HEIGHT: 13px"><FONT size="2"><STRONG>PT. BANK MANDIRI (Persero)</STRONG></FONT></TD>
												</TR>
												<TR>
													<TD style="WIDTH: 13px" vAlign="top"><FONT size="2">8.</FONT></TD>
													<TD style="WIDTH: 179px" vAlign="top"><FONT size="2">Lain-lain</FONT></TD>
													<TD style="WIDTH: 10px" vAlign="top"><FONT size="2">:</FONT></TD>
													<TD><FONT size="2">
															<asp:PlaceHolder id="PH_LAIN_LAIN" runat="server"></asp:PlaceHolder></FONT></TD>
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
						<td style="WIDTH: 618px"><FONT face="Tahoma" size="2">Apabila ada data lainnya yang 
								Saudara perlukan dalam rangka hal tersebut diatas, mohon diinformasikan kepada 
								kami dalam kesempatan pertama dengan&nbsp;
								<asp:Label id="LBL_CP_BM" runat="server" Font-Bold="True" Height="8px" Font-Names="Tahoma"
									Font-Size="X-Small" ForeColor="Blue"></asp:Label>&nbsp;<STRONG>telp.</STRONG>
								<asp:Label id="LBL_CP_BM_PHN" runat="server" Font-Bold="True" Height="8px" Font-Names="Tahoma"
									Font-Size="X-Small" ForeColor="Blue"></asp:Label>
								<BR>
								<BR>
								<BR>
							</FONT>
						</td>
						<TD></TD>
					</tr>
					<tr>
						<TD style="WIDTH: 111px"></TD>
						<td style="WIDTH: 618px"><FONT face="Tahoma" size="2">Hormat kami,<BR>
								<STRONG>PT. BANK MANDIRI (PERSERO)</STRONG></FONT></td>
						<TD><STRONG></STRONG></TD>
					</tr>
					<tr>
						<TD style="WIDTH: 111px"><STRONG></STRONG></TD>
						<td style="WIDTH: 618px"><FONT face="Georgia" size="2">
								<asp:Label id="LBL_JCCO_TTD" runat="server" Font-Bold="True" Height="8px" Font-Names="Tahoma"
									Font-Size="X-Small" ForeColor="Blue"></asp:Label></FONT></td>
						<TD><STRONG></STRONG></TD>
					</tr>
					<tr>
						<TD style="WIDTH: 111px"><STRONG></STRONG></TD>
						<td style="WIDTH: 618px"><FONT face="Georgia" size="2">
								<asp:Label id="LBL_ALAMAT_JCCO_TTD" runat="server" Font-Bold="True" Height="8px" Font-Names="Tahoma"
									Font-Size="X-Small" ForeColor="Blue"></asp:Label></FONT></td>
						<TD></TD>
					</tr>
					<tr>
						<TD style="WIDTH: 111px"></TD>
						<td style="WIDTH: 618px">
							<P><BR>
								<BR>
								&nbsp;</P>
						</td>
						<TD></TD>
					</tr>
					<tr>
						<TD style="WIDTH: 111px"></TD>
						<td style="WIDTH: 618px"><U><FONT face="Georgia" size="2">
									<asp:Label id="LBL_NAMA_TTD" runat="server" Font-Bold="True" Height="8px" Font-Names="Tahoma"
										Font-Size="X-Small" ForeColor="Blue"></asp:Label></FONT></U></td>
						<TD></TD>
					</tr>
					<tr>
						<TD style="WIDTH: 111px"></TD>
						<td style="WIDTH: 618px"><FONT face="Georgia" size="2">
								<asp:Label id="LBL_DEPT_TTD" runat="server" Font-Bold="True" Height="8px" Font-Names="Tahoma"
									Font-Size="X-Small" ForeColor="Blue"></asp:Label></FONT></td>
						<TD></TD>
					</tr>
					<tr>
						<TD style="WIDTH: 111px"></TD>
						<td style="WIDTH: 618px"></td>
						<TD></TD>
					</tr>
					<TR>
						<TD style="WIDTH: 111px" align="center"></TD>
						<TD align="center" style="WIDTH: 618px"></TD>
						<TD align="center"></TD>
					</TR>
				</TABLE>
			</center>
		</form>
	</body>
</HTML>
